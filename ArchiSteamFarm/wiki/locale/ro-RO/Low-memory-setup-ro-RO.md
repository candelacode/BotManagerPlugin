# Configurare memorie redusă

Aceasta este exact opusul lui **[de înaltă performanță configurare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup)** și de obicei doriți să urmați acele sfaturi dacă doriți să reduceți utilizarea memoriei ASF, costul scăderii performanţei globale.

---

ASF este extrem de ușor prin definiție pentru resurse, în funcție de utilizarea ta chiar și 128 MB VPS cu Linux este capabil să o ruleze, chiar dacă nivelul scăzut nu este recomandat şi poate duce la diverse probleme. În timp ce este lumină, ASF nu se teme să ceară mai multă memorie SG, dacă o astfel de memorie este necesară pentru ca ASF să funcționeze cu o viteză optimă.

ASF ca o cerere încearcă să fie cât mai optimizată și mai eficientă posibil, ceea ce ia în considerare, de asemenea, resursele utilizate în timpul execuției. Când vine vorba de memorie, ASF preferă performanța în raport cu consumul de memorie, ceea ce poate duce temporar la "spikes", ce poate fi observat, de ex. cu conturi care au 3+ pagini de insignă, ASF va prelua și analiza prima pagină, citite din numărul total de pagini, apoi lansa sarcina de preluare pentru fiecare pagină suplimentară, ceea ce duce la preluarea și parcarea simultană a paginilor rămase. Acea utilizare a memoriei "extra" (comparată cu minimul de operare gol) poate accelera dramatic execuția și performanța generală, la costul unei utilizări mai mari a memoriei necesare pentru a face toate acele lucruri în paralel. Lucruri similare se întâmplă cu toate celelalte sarcini ASF generale, care pot fi executate în paralel, de exemplu: cu oferte de tranzacționare active, ASF le poate analiza pe toate simultan, deoarece toate sunt independente una de cealaltă. On top of that, ASF (C# runtime) will **not** return unused memory back to OS immediately afterwards, which you can quickly notice in form of ASF process only taking more and more memory, but (almost) never giving that memory back to the OS. Unii oameni ar putea să o considere deja discutabilă, poate chiar suspectați o scurgere de memorie, dar nu vă faceți griji, se așteaptă ca toate astea.

ASF este extrem de bine optimizat și utilizează cât mai mult posibil resursele disponibile. Utilizarea mare de memorie a ASF nu înseamnă că ASF folosește **activ** care memoria și **au nevoie de el**. Adesea, ASF va păstra memoria ca „cameră” pentru acțiunile viitoare, pentru că putem îmbunătăţi drastic performanţa dacă nu avem nevoie să cerem OS pentru fiecare bucăţică de memorie pe care urmează să o folosim. The runtime should automatically release unused ASF memory back to OS when OS will **truly** need it. **[Memoria neutilizată este memoria pierdută](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. Ai întâmpinat probleme atunci când memoria pe care o ai **are nevoie de** este mai mare decât memoria disponibilă pentru tine, nu atunci când ASF păstrează unele resurse suplimentare alocate cu scopul de a accelera funcțiile care se vor executa imediat. Te lovești de probleme când kernel-ul tău Linux omoară procesul ASF din cauza OOM (din memorie), nu când vezi procesul ASF ca consumator de memorie de top în `htop`.

**[Procesul de colectare a gunoiului](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** folosit în ASF este un mecanism foarte complex, suficient de inteligent pentru a lua în considerare nu numai ASF însuși, ci și sistemul dvs. de operare și alte procese. Când ai o grămadă de memorie gratuită, ASF va cere tot ce este necesar pentru a îmbunătăți performanța. Acest lucru poate fi chiar până la 1 GB (cu serverul GC). Când memoria sistemului de operare este aproape de a fi completă, ASF va elibera automat o parte din aceasta înapoi în sistemul de operare pentru a ajuta lucrurile să se regleze, care poate duce la o utilizare globală a memoriei ASF de până la 50 MB. Diferenţa între 50 MB şi 1 GB este imensă, dar la fel este diferenţa dintre 512 MB VPS şi serverul imens dedicat cu 32 GB. Dacă ASF poate garanta că această memorie va fi utilă, și în același timp nimic altceva nu o cere acum, va prefera să o păstreze și să se optimizeze automat pe baza rutinelor care au fost executate în trecut. GC utilizat în ASF se autoreglează și va obține rezultate mai bune cu cât mai mult este în desfășurare procesul.

Acesta este și motivul pentru care memoria procesului ASF variază de la configurare la configurare, ca ASF va face tot posibilul pentru a utiliza resursele disponibile în **mod cât mai eficient posibil**, și nu într-un mod fix ca și cum ar fi fost făcut în timpul de Windows XP. Utilizarea actuală (reală) a memoriei utilizată de ASF poate fi verificată cu `statistici` **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, şi de obicei este de aproximativ 4 MB pentru doar câţiva boţi, până la 30 MB dacă utilizaţi chestii precum **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** şi alte caracteristici avansate. Rețineți că memoria returnată de comanda `statistici` include și memorie gratuită, care nu a fost încă recuperată de colectorul de gunoi. Orice altceva este memorie partajată în timpul rulării (aproximativ 40-50 MB) şi spaţiu de execuţie (variat). Acesta este și motivul pentru care același ASF poate utiliza până la 50 MB în mediul VPN cu memorie scăzută, în timp ce folosești până la 1 GB pe desktop. ASF se adaptează în mod activ la mediul dumneavoastră și va încerca să găsească un echilibru optim pentru a nu pune SG sub presiune, nici nu se limitează performanțele acestuia atunci când ai multă memorie neutilizată care ar putea fi pusă în folosință.

---

Bineînțeles, Există o mulțime de moduri în care puteți ajuta la punctarea ASF în direcția corectă în ceea ce privește memoria pe care o așteptați să o folosiți. În general, dacă nu ai nevoie să faci asta, cel mai bine este să laşi colectorul de gunoi să lucreze în pace şi să facă tot ceea ce consideră a fi cel mai bine. Dar acest lucru nu este întotdeauna posibil, de exemplu dacă serverul dvs Linux găzduieşte de asemenea mai multe site-uri, baza de date MySQL şi muncitori PHP, atunci nu vă puteți permite ASF să se micșoreze atunci când alergați aproape de OOM, deoarece de obicei este prea târziu și degradarea performanței intervine mai devreme. Acest lucru se întâmplă de obicei atunci când ați putea fi interesat de ajustări ulterioare, și, prin urmare, de citirea acestei pagini.

Sugestiile de mai jos sunt împărțite în câteva categorii, cu dificultăți variate.

---

## Configurare ASF (ușor)

Mai jos trucurile **nu afectează performanţa în mod negativ** şi pot fi aplicate în siguranţă la toate configurările.

- Rulează **[versiunea generică](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** a ASF dacă este posibil. Versiunea generică de ASF folosește mai puțină memorie deoarece nu include rularea în interior, nu vine ca un singur fișier, nu trebuie să se dezîmpacheteze singuri în rulare și, prin urmare, este mai mică și are mai puțină memorie Pachetele specifice OS‑urilor sunt utile și convenabile, dar sunt de asemenea combinate cu tot ceea ce este necesar pentru a lansa ASF, ceea ce este ceva ce puteţi avea grijă de dumneavoastră şi utilizaţi în schimb varianta generică ASF.
- Nu rula niciodată mai mult de o instanță ASF. ASF este menit să gestioneze un număr nelimitat de boți în același timp și dacă nu legați fiecare instanță ASF la o interfață diferită/adresă IP, ar trebui să aveți exact **un proces** ASF cu mai mulți boți (dacă este necesar).
- Folosiți `ShutdownOnFarmed` în robotul `Preferințe agricole`. Robotul activ ia mai multe resurse decât unul. Nu este o economie semnificativă, deoarece starea de bot încă trebuie menținută, dar economisiți o anumită cantitate de resurse, în special toate resursele legate de rețea, cum ar fi socket-urile TCP. Poți să aduci mereu alți roboți, dacă este necesar.
- Păstrează-ți boții numărul lor scăzut. Nu `Activat instanța bot` ia mai puține resurse, deoarece ASF nu se deranjează să pornească de la ea. Also keep in mind that ASF has to create a bot for each of your configs, therefore if you don't need to `start` given bot and you want to save some extra memory, you can temporarily rename `Bot.json` to e.g. `Bot.json.bak` in order to avoid creating state for your disabled bot instance in ASF. This way you won't be able to `start` it without renaming it back, but ASF also won't bother keeping state of this bot in memory, leaving room for other things (very small save, in 99.9% cases you shouldn't bother with it, just keep your bots with `Enabled` of `false`).
- Reglaţi perfect configuraţiile. În special configurația ASF globală are multe variabile de ajustat, de exemplu mărind `LoginLimiterDelay` veți aduce mai încet roboții mai lent, care va permite instanței deja începute să preia insigne între timp, spre deosebire de aducerea mai rapidă a roboților tăi; care va consuma mai multe resurse, deoarece mai mulți roboți vor face o muncă importantă (cum ar fi pararea insignelor) în același timp. Cu cât munca este mai puţin necesară în acelaşi timp - cu atât mai puţină memorie folosită.

Acestea sunt câteva lucruri pe care le puteţi avea în vedere atunci când abordaţi folosirea memoriei. Cu toate acestea, aceste lucruri nu au nicio importanţă "crucială" în ceea ce priveşte utilizarea memoriei, pentru că utilizarea memoriei vine în cea mai mare parte din lucrurile de care trebuie să se ocupe ASF, şi nu din structurile interne folosite pentru fermele cu carduri.

Cele mai importante funcții ale resurselor sunt:
- Analiza paginii de ecuson
- Analiză inventar

Ceea ce înseamnă că memoria va apăsa cel mai mult atunci când ASF se ocupă de citirea paginilor de ecuson și când se ocupă de inventarul său (e. . trimiterea de tranzacții sau de lucru cu STM). Acest lucru se datorează faptului că ASF trebuie să se ocupe de o cantitate foarte mare de date - utilizarea memoriei browserului tău preferat care lansează aceste două pagini nu va fi mai mică decât atât. Ne pare rău, așa funcționează - micșorează numărul de pagini de insignă și păstrează numărul de articole de inventar scăzut, asta poate ajuta, cu siguranță.

---

## Reglaj Runtime (avansat)

Sub trucurile **implică degradarea performanţei** şi trebuie folosit cu precauţie.

Modul recomandat de aplicare a acestor setări este prin intermediul proprietăților de mediu `DOTNET_`. Bineînțeles, ați putea folosi și alte metode, de ex. `runtimeconfig.json`, dar unele setări sunt imposibil de stabilit în acest fel, și pe deasupra ASF va înlocui fișierul personalizat `runtimeconfig.json` cu cel propriu la următoarea actualizare, de aceea recomandăm proprietățile de mediu pe care le puteți seta cu ușurință înainte de a lansa procesul.

.NET runtime vă permite să **[tweak](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** în multe feluri, ajustarea eficientă a procesului GC în funcție de nevoile dumneavoastră. Am prezentat mai jos proprietăți care sunt deosebit de importante în opinia noastră.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Specifică utilizarea admisibilă a GC heap ca procent din memoria fizică totală.

Limita de memorie "hard" pentru procesul ASF, această setare ajustează GC pentru a utiliza doar un subset de memorie totală și nu toate. Acesta poate deveni deosebit de util în diferite situaţii similare serverului unde puteţi dedica un procent fix din memoria serverului pentru ASF, dar niciodată mai mult de atât. Atenționați că limitarea memoriei pentru ASF nu va face ca memoria necesară să dispară în mod magic, Prin urmare, stabilirea unei astfel de valori prea mici ar putea duce la abandonarea scenariilor de memorie, în cazul în care procesul ASF va fi forțat să înceteze.

Pe de altă parte, setarea acestei valori suficient de ridicate este o modalitate perfectă de a ne asigura că ASF nu va folosi niciodată mai multă memorie decât vă puteți permite în mod realist, a da mașinii o cameră de respirat chiar și sub sarcină grea, permițând în același timp programului să își facă treaba cât mai eficient posibil.

### [`GCConserveMemorie`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Configurează colectorul de gunoi pentru a conserva memoria în detrimentul colecţiilor de gunoi mai frecvente şi poate al perioadelor de pauză mai lungi.

Se poate folosi o valoare între 0-9. Cu cât valoarea este mai mare, cu atât mai mult GC va optimiza memoria față de performanță.

### [`GCHighMemcent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Specifică cantitatea de memorie folosită după care GC devine mai agresiv.

Această setare configurează pragul de memorie pentru întregul sistem de operare, care odată a trecut determină GC să devină mai agresiv și încearcă să ajute SG să reducă sarcina de memorie prin derularea unui proces mai intensiv de GC și, prin urmare, să elibereze mai multă memorie gratuită către OS. Este o idee bună să setezi această proprietate la cantitatea maximă de memorie (în procente) pe care o consideri "critică" pentru întreaga performanţă a sistemului tău de operare. Implicit este de 90%, și de obicei doriți să îl păstrați în intervalul 80-97%, deoarece o valoare prea mică provoacă agresivitate inutilă din partea GC şi degradarea performanţelor fără motiv, în timp ce valoarea prea mare va pune o sarcină inutilă pe OS, considerând că ASF ar putea elibera memoria acestuia pentru a ajuta.

### **[`GCLatencyLevel`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Specifică nivelul de latență GC pentru care dorești să optimizezi.

Aceasta este o proprietate nedocumentată care s-a dovedit a funcționa excepțional de bine pentru ASF, prin limitarea dimensiunilor generaţiilor de GC şi prin urmare să le elimine mai frecvent şi mai agresiv. Nivelul de latență implicit (balanc) este `1`, dar puteți utiliza `0`, care va regla pentru utilizarea memoriei.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> Când este setat reducem mai agresiv spațiul dedicat pentru segmentul efemer. Acest lucru este folosit pentru a rula mai multe cazuri de procese de server, unde vor să păstreze cât mai puțină memorie activată posibil.

Acest lucru nu aduce nicio îmbunătățire, dar poate face GC și mai agresiv atunci când sistemul va avea un nivel scăzut de memorie, în special pentru fondurile ASF, care utilizează în mare măsură sarcinile threadpool (threadpool).

---

Puteți activa proprietățile selectate prin setarea variabilelor de mediu adecvate. De exemplu, pe Linux (carcasă):

```shell
# Don't forget to tune those if you're planning to make use of them
export DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
export DOTNET_GCHighMemPercent=0x50 # 80% as hex

export DOTNET_GCConserveMemory=9
export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

Sau pe Windows (powershell):

```powershell
# Don't forget to tune those if you're planning to make use of them
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80% as hex

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

Mai ales `GCLatencyLevel` va deveni foarte util deoarece am verificat că timpul de execuție optimizează codul pentru memorie și, prin urmare, scade semnificativ utilizarea medie a memoriei, chiar și cu serverul GC. Este unul dintre cele mai bune trucuri pe care le poți aplica dacă vrei să reduci semnificativ utilizarea memoriei ASF fără a degrada performanța prea mult cu `OptimizationMode`.

---

## Acord ASF (intermediar)

Sub trucurile **implică degradarea gravă a performanţei** şi trebuie utilizată cu precauţie.

- În ultimă instanță, puteți modifica ASF pentru `MinMemoryUsage` prin `OptimizationMode` **[proprietatea configurării globale](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**. Își citește cu atenție scopul, deoarece aceasta este o degradare gravă a performanței pentru aproape niciun beneficiu legat de memorie. Acesta este de obicei **ultimul lucru pe care vrei să-l faci**, mult timp după ce treci prin **[alergând](#runtime-tuning-advanced)** pentru a te asigura că ești forțat să faci asta. Dacă nu este absolut critic pentru configurare, vom descuraja folosirea `MinMemoryUsage`, chiar și în mediile cu constrângeri de memorie.

---

## Optimizare recomandată

- Pornește de la simple trucuri de configurare ASF, folosește varianta **[a ASF generică](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** și verifică dacă poate doar folosești ASF într-un mod greșit, cum ar fi pornirea procesului de mai multe ori pentru toți boții tăi, sau păstrarea tuturor active dacă aveţi nevoie doar de unul sau doi pentru a porni automat.
- Dacă încă nu este suficient, activați toate proprietățile de configurare listate mai sus prin setarea corespunzătoare `DOTNET_` variabile de mediu. În special `GCLatencyLevel` oferă îmbunătățiri semnificative în timpul rulării pentru costuri mici asupra performanței.
- Dacă nici chiar asta nu a ajutat, ca soluție de ultimă instanță activează `MinMemoryUsage` `OptimizationMode`. Acest lucru forțează ASF să execute aproape totul în materie sincronă, a-l face să funcţioneze mult mai încet, dar nu să se bazeze şi pe un fir de discuţii, pentru a echilibra lucrurile atunci când este vorba despre execuţia paralelă.

Este fizic imposibil să reduci şi mai mult memoria, ASF-ul tău este deja foarte degradat din punctul de vedere al performanței și ți-ai epuizat toate posibilitățile, atât în sensul codului, cât și în timpul rulării. Luați în considerare adăugarea unei amintiri suplimentare pentru ASF de utilizat, chiar și 128 MB ar face o diferență mare.