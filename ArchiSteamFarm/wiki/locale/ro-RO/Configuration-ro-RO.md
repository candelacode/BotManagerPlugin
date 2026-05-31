# Configurare

Această pagină este dedicată configurării ASF. Acesta servește ca documentație completă a directorului `config` , permițându-ți să ajustezi ASF la nevoile tale.

* **[Introducere](#introduction)**
* **[ConfigGenerator web](#web-based-configgenerator)**
* **[Configurare ASF-ui](#asf-ui-configuration)**
* **[Configurare manuală](#manual-configuration)**
* **[Configurare globală](#global-config)**
* **[Bot config](#bot-config)**
* **[Structura fișierului](#file-structure)**
* **[Mapare JSON](#json-mapping)**
* **[Cartografierea compatibilității](#compatibility-mapping)**
* **[Compatibilitate configurări](#configs-compatibility)**
* **[Autoreîncărcare](#auto-reload)**

---

## Introducere

Configurația ASF este împărțită în două părți majore - configurația globală (proces) și configurația fiecărui bot. Fiecare bot are propriul fișier de configurare al botului numit `BotName. son` (unde `BotName` este numele botului), în timp ce configurația ASF (proces) globală este un singur fișier numit `ASF. son`.

Un bot este un singur cont de abur care ia parte la procesul ASF. In order to work properly, ASF needs at least **one** defined bot instance. Nu există o limită de aplicare a proceselor în cazul boților, astfel încât să poți folosi cât de mulți boți (conturi de abur) dorești.

ASF folosește formatul **[JSON](https://en.wikipedia.org/wiki/JSON)** pentru stocarea fișierelor sale de configurare. Este un format prietenos cu oamenii, lizibil și foarte universal în care poți configura programul. Nu vă faceți totuși griji, nu trebuie să îl cunoașteți pe JSON pentru a configura ASF. L-am menționat doar în cazul în care ai vrea deja să creezi în masă configurații ASF cu un fel de script de bas.

Configurarea poate fi realizată în mai multe moduri. Poți folosi **[Web-based ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)**, care este o aplicație locală independentă de ASF. Puteţi utiliza **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC frontend pentru configurare făcută direct în ASF. În cele din urmă, puteţi genera întotdeauna fişiere de configurare manual, deoarece acestea urmăresc o structură fixă JSON specificată mai jos. Vom explica în scurt timp opţiunile disponibile.

---

## ConfigGenerator web

Scopul **[Web-based ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** este de a vă oferi un frontend prietenos, utilizat pentru generarea fișierelor de configurare ASF. ConfigGeneratorul bazat pe web este 100% bazat pe client, ceea ce înseamnă că detaliile pe care le puneți nu sunt trimise nicăieri, ci procesate doar local. Acest lucru garantează siguranţa şi fiabilitatea, cum poate merge chiar şi **[offline](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** dacă doriţi să descărcaţi toate fişierele şi să executaţi indexul `. tml` în browserul tău preferat.

ConfigGeneratorul web este verificat pentru a rula corect pe Chrome și Firefox, dar ar trebui să funcționeze corect în toate cele mai populare browsere activate cu javascript.

Utilizarea este destul de simplă - selectați dacă doriți să generați `ASF` sau `Bot` prin comutarea la fila corectă, asigură-te că versiunea aleasă a fișierului de configurare se potrivește cu versiunea ASF, apoi introdu toate detaliile și apasă butonul "download". Mută acest fișier în directorul ASF `config` , suprascriind fișierele existente dacă este necesar. Se repetă pentru toate modificările ulterioare și se referă la restul acestei secțiuni pentru explicarea tuturor opțiunilor disponibile pentru configurare.

---

## Configurare ASF-ui

Interfaţa noastră **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC vă permite să configuraţi şi ASF, și este o soluție superioară pentru reconfigurarea ASF după generarea configurărilor inițiale, datorită faptului că poate edita configurările în loc; spre deosebire de ConfigGeneratorul web care le generează static.

Pentru a folosi ASF-ui, trebuie să aveți activată interfața **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**. `IPC` este activat în mod implicit, prin urmare îl puteți accesa imediat, atâta timp cât nu l-ați dezactivat singur.

După lansarea programului, pur și simplu navighează la ASF **[adresa IPC](http://localhost:1242)**. Dacă totul a funcționat corect, puteți schimba și configurația ASF de acolo.

---

## Configurare manuală

În general, vă recomandăm să utilizați fie ConfigGeneratorul nostru, fie ASF-ui, este mult mai uşor şi nu veţi face o greşeală în structura JSON, dar dacă dintr-un motiv nu vrei, atunci poți crea manual configurații corecte. Verificați exemplele JSON de mai jos pentru un început bun în structura corespunzătoare, poți copia conținutul într-un fișier și îl poți folosi ca bază pentru configurarea ta. Deoarece nu utilizați niciunul dintre frontend-urile noastre, asigurați-vă că configurarea dvs. este **[valid](https://jsonlint.com)**, ca ASF va refuza să îl încarce dacă nu poate fi analizat. Chiar dacă este un JSON valabil, trebuie să te asiguri că toate proprietățile au tipul corect, așa cum este cerut de ASF. Pentru o structură JSON corespunzătoare tuturor câmpurilor disponibile, vezi secțiunea **[maparea JSON](#json-mapping)** și documentația noastră de mai jos.

---

## Configurare globală

Configurarea globală este localizată în fișierul `ASF.json` și are următoarea structură:

```json
{
    "AutoRestart": adevărat,
    "Negru": [],
    "CommandPrefix": "! ,
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "Current Culture": null,
    "Depanare": false,
    "DefaultBot": null,
    "Întârziere agricolă": 15,
    "FilterBadBots": adevărat,
    "GiftsLimiterDelay": 1,
    "Cefalee": fals,
    "IdleFarmingPeriod": 8,
    "InventoryLimiterDelay": 4,
    "IPC": adevărat,
    "IPCPassword": null,
    "IPCPasswordFormat": 0,
    "LicenseID": null,
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldDuration": 15,
    "MinFarmingDelayAfterBlock": 60,
    "OptimizationMode": 0,
    "PluginsUpdateList": [],
    "PluginsUpdateMode": 0,
    "ShutdownIfPossible": false,
    "SteamMessagePrefix": "/me",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "Parola WebProxy": null,
    "WebProxyUsername": null
}
```

---

Toate opțiunile sunt explicate mai jos:

### `Repornire automată`

`bool` tip cu valoarea implicită `true`. Această proprietate definește dacă ASF este permis să efectueze o auto-repornire atunci când este necesar. Există câteva evenimente care vor necesita din ASF o auto-repornire, cum ar fi actualizarea ASF (finalizată cu comanda `UpdatePeriod` sau `actualizează` ), precum și comanda `ASF. Editarea configurării fiului` , `repornește comanda` și la fel. De obicei, repornirea include două părți - crearea unui nou proces și finalizarea celui actual. Majoritatea utilizatorilor ar trebui să fie în regulă cu ea și să păstreze această proprietate cu valoarea implicită de `true`, totuși - dacă rulați ASF prin propriul script și/sau cu `dotnet`, poate doriţi să aveţi control deplin asupra începerii procesului, evitarea, de asemenea, a unei situații cum ar fi desfășurarea unui nou proces ASF (repornire) în mod tacit, pe fundal; și nu în prim-planul script-ului, care a ieșit împreună cu vechiul proces ASF. Acest lucru este deosebit de important având în vedere faptul că un nou proces nu va mai fi copilul dumneavoastră direct, ceea ce vă va face imposibili. . pentru a utiliza sistemul standard de introducere a consolei.

În acest caz, această proprietate dacă este special pentru tine și o poți seta la `false`. Cu toate acestea, țineți cont că în acest caz **tu** ești responsabil pentru repornirea procesului. Acest lucru este cumva important deoarece ASF va ieși doar în loc să creeze un nou proces (de exemplu, dupa actualizare), daca nu exista logica adaugata de tine, pur si simplu se va inceta sa functioneze pana cand se va reporni. ASF iese întotdeauna cu un cod de eroare corect indicând succesul (zero) sau lipsa de succes (non-zero), în acest fel puteți adăuga logica corectă în script care ar trebui să evite repornirea automată a ASF în caz de eșec sau cel puţin fă o copie locală de jurnal `. xt` pentru o analiză suplimentară. De asemenea, rețineți că comanda `reporniți` va reporni întotdeauna ASF indiferent de modul în care este activată această proprietate, ca această proprietate definește comportamentul implicit, în timp ce `repornește` comanda întotdeauna repornește procesul. Dacă nu aveți un motiv să dezactivați această caracteristică, ar trebui să o păstrați activată.

---

### `Lista neagră`

`ImmutableHashSet<uint>` tip cu valoarea implicită a fi goală. După cum sugerează numele, această proprietate de configurare globală definește appID-urile (jocurile) care vor fi complet ignorate de procesul automat de creștere ASF. Din păcate, Steam iubește să arboreze insignele de vânzare vară/iarnă ca fiind „disponibile pentru carduri desființate”, care derutează procesul ASF făcându-l să creadă că este un joc valid care ar trebui cultivat. Dacă nu ar exista nicio listă neagră, ASF ar „agăța” în cultivarea unui joc care de fapt nu este un joc; şi aşteptaţi infinit ca cărţile să cadă ce nu se va întâmpla. Lista neagră ASF servește scopului de a marca aceste insigne ca fiind indisponibile pentru agricultură; astfel încât să le putem ignora în tăcere atunci când decidem ce să cultivăm și nu să cădem în capcană.

ASF include în mod implicit două liste negre - `SalesBlacklist`, care este hardcodat în codul ASF și nu poate fi editat, și normal `Blacklist`, care este definit aici. `SalesBlacklist` este actualizat împreună cu versiunea ASF și de obicei include toate aplicațiile "rele" în momentul lansării, așa că dacă utilizați ASF actualizat, nu trebuie să vă mențineți propriul `Blacklist` definit aici. Scopul principal al acestei proprietăți este să vă permită listarea pe lista neagră nouă, necunoscută în momentul lansării de aplicații ASF, care nu ar trebui să fie cultivată. Hardcoded `SalesBlacklist` este actualizat cât mai rapid posibil, prin urmare nu ai nevoie să îți actualizezi propria listă neagră `` dacă folosești cea mai recentă versiune ASF, dar fără `Lista neagră` ar fi forțat să actualizați ASF pentru a "păstra rularea" atunci când Valve eliberează noua insignă de vânzare - nu vreau să vă forțez să utilizați cel mai recent cod ASF, prin urmare această proprietate este aici pentru a vă permite să "fixați" ASF chiar dumneavoastră dacă, dintr-un anumit motiv, nu vreți, sau nu poți, actualizează la noi hardcoded `SalesBlacklist` într-o nouă lansare ASF, totuși vrei să păstrezi în funcțiune ASF vechi. Dacă nu aveți un motiv **strong** pentru a edita această proprietate, ar trebui să o păstrați în mod implicit.

Dacă sunteţi în căutarea unei liste negre bazate pe bot, aruncaţi o privire la `fb`, `fbadd` şi `fbrm` **[comenzi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `Prefix`

`șir` tip cu valoarea implicită `!`. This property specifies **case-sensitive** prefix used for ASF **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Cu alte cuvinte, asta este ceea ce trebuie să prepuneți fiecărei comenzi ASF pentru a face ASF să vă asculte pe dumneavoastră. Este posibil să setezi această valoare la `null` sau gol pentru a face ASF să folosească fără prefix de comandă, caz în care introduci comenzi cu identificatorii lor simpli. Cu toate acestea, făcând acest lucru va scădea performanța ASF, deoarece ASF este optimizat pentru a nu analiza mesajul mai departe dacă nu începe cu `CommandPrefix` - dacă decizi intenționat să nu îl folosești, ASF va fi forțat să citească toate mesajele și să le răspundă, chiar dacă nu sunt comenzi ASF. Prin urmare, este recomandat să continuați să utilizați `CommandPrefix`, cum ar fi `/` dacă nu vă place valoarea implicită de `!`. Pentru consecvență, `CommandPrefix` afectează întregul proces ASF. Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

### `ConfirmăriLimiterÎntârziere`

`byte` tip cu valoarea implicită de `10`. ASF se va asigura că vor exista cel puțin `ConfirmationsLimiterDelay` secunde între două confirmări consecutive de 2FA care preiau cereri pentru a evita declanșarea limitei ratei - acelea sunt folosite de **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** în timpul ei. . Comanda `2faok` , precum și la nevoie, atunci când se efectuează diferite operațiuni legate de tranzacționare. Valoarea implicită a fost setată pe baza testelor noastre și nu ar trebui să fie redusă dacă nu doriți să întâmpinați probleme. Dacă nu aveți un motiv **strong** pentru a edita această proprietate, ar trebui să o păstrați în mod implicit.

---

### `ConectareExpirare`

`byte` tip cu valoarea implicită de `90`. Această proprietate definește termenele-limită pentru diferite acțiuni de rețea realizate de ASF, în secunde. În particular, `ConnectionTimeout` definește timeout în secunde pentru cereri HTTP și IPC, `ConnectionTimeout / 10` definește numărul maxim de bătăi ale inimii eșuate, în timp ce `ConnectionTimeout / 30` definește numărul de minute pe care le permitem pentru solicitarea inițială de conectare la rețeaua Steam. Valoarea implicită de `90` ar trebui să fie bună pentru majoritatea oamenilor, cu toate acestea, dacă ai o conexiune mai lentă la rețea sau PC, poate doriţi să creşteţi acest număr la ceva mai mare (cum ar fi `120`). Țineți cont de faptul că valori mai mari nu vor repara magic servere Steam lente sau chiar inaccesibile, așa că nu ar trebui să așteptăm infinit ceva ce nu se va întâmpla și pur și simplu să încercăm din nou mai târziu. Stabilirea unei valori prea mari va duce la întârzieri excesive în prinderea problemelor de rețea, precum și la scăderea performanței globale. Dacă setezi această valoare prea scăzută, va scădea și stabilitatea și performanța în ansamblu, deoarece ASF va renunța la cererea valabilă încă analizată. Prin urmare, setarea acestei valori mai mici decât cea implicită nu are niciun avantaj în general, deoarece serverele Steam tind să fie foarte lente din când în când și ar putea necesita mai mult timp pentru analizarea cererilor ASF. Valoarea implicită este un echilibru între a crede că conexiunea noastră la rețea este stabilă și a avea îndoieli în rețeaua Steam să gestioneze cererea noastră în timp util. Dacă doriți să detectați problemele mai devreme și faceți ASF reconectare/răspuns mai rapid, valoarea implicită ar trebui să facă (sau foarte ușor mai jos, cum ar fi `60`, făcând ASF mai puțin pacient). Dacă observați în schimb că ASF se lovește de probleme de rețea, cum ar fi cereri eșuate, bătăi cardiace pierdute sau conexiune la Steam întreruptă, este probabil logic să crești această valoare dacă ești sigur că este **nu** cauzată de rețeaua ta, dar prin Steam în sine, deoarece creșterea timpului face ASF mai „pacient” și nu decide să se reconecteze imediat.

Un exemplu care ar putea necesita creșterea acestei proprietăți este permiterea ASF să facă față unor oferte comerciale foarte mari care pot dura peste 2 minute pentru a fi pe deplin acceptate și manipulate de Steam. Prin creșterea perioadei implicite, ASF va fi mai mult pacient și va aștepta mai mult înainte de a decide că comerțul nu trece și va abandona cererea inițială.

O altă situație ar putea fi cauzată de o funcționare foarte lentă a mașinii sau a conexiunii la internet care necesită mai mult timp pentru gestionarea datelor transmise. Aceasta este o stare destul de rară, deoarece lăţimea de bandă CPU/reţea nu este aproape niciodată o strangulare, dar încă merită menţionată.

Pe scurt, valoarea implicită ar trebui să fie decentă pentru majoritatea cazurilor, dar este posibil să doriți să o măriți dacă este necesar. Totuși, mergând cu mult deasupra valorii implicite nu prea are sens, deoarece timpii mai mari nu vor repara magic servere Steam inaccesibile. Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

### `Curent`

`șir` tip cu valoarea implicită `null`. ASF încearcă implicit să folosească limba sistemului tău de operare și va prefera să folosească șiruri traduse în acea limbă, dacă sunt disponibile. Acest lucru este posibil datorită comunității noastre care încearcă să **[localizare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** ASF în cele mai populare limbi. Dacă dintr-un motiv sau altul nu vrei să folosești limbajul nativ al sistemului de operare, puteți folosi această proprietate de configurare pentru a alege orice limbă validă pe care doriți să o utilizați. Pentru o listă a tuturor culturilor disponibile, vă rugăm să vizitaţi **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** şi să căutaţi `Eticheta lingvistică`. Este frumos să rețineți că ASF acceptă ambele culturi specifice, cum ar fi `"en-GB"`, dar şi neutre, cum ar fi `"en"`. Specificarea culturii actuale va afecta și alte comportamente specifice culturii, cum ar fi formatul monedei/datei și același comportament. Vă rugăm să rețineți că este posibil să aveți nevoie de pachete adiționale de font/limbă pentru afișarea corectă a caracterelor specifice limbilor, dacă ați ales cultura nativă care le utilizează. De obicei vrei să folosești această proprietate de configurare dacă preferi ASF în limba engleză în loc de limba ta nativă.

---

### `Debug`

`bool` tip cu valoarea implicită de `false`. Această proprietate definește dacă procesul ar trebui să ruleze în modul de depanare. Când este în modul de depanare, ASF creează un director special `debug` de lângă configurația ``, care ține evidența întregii comunicări dintre serverele ASF și Steam. Informațiile de depanare pot ajuta la identificarea problemelor neplăcute legate de rețele și de fluxul general de lucru ASF. În plus, unele rutine de program vor fi mult mai verbale, cum ar fi `WebBrowser` declarând motivul exact pentru care unele solicitări nu reușesc - aceste intrări sunt scrise într-un jurnal ASF normal. **Nu ar trebui să rulați ASF în modul de depanare, cu excepția cazului în care dezvoltatorul**. Running ASF in debug mode **decreases performance**, **affects stability negatively** and is **far more verbose in various places**, so it should be used **only** intentionally, in short-run, for debugging particular issue, reproducing the problem or getting more info about a failing request, and alike, but **not** for normal program execution. Veţi vedea **mult** de erori noi, probleme, și excepții - asigură-te că ai cunoștințe decente despre ASF, Steam şi ghemurile sale dacă decizi să analizezi toate astea, deoarece nu totul este relevant.

**ATENŢIE:** activarea acestui mod include logarea de **a informaţiilor potenţial sensibile** cum ar fi autentificările şi parolele pe care le utilizaţi pentru autentificarea în Steam (din cauza logării în reţea). Aceste date sunt scrise atât în directorul `depanare` , cât şi în logul standard `. xt` (acesta este acum în mod intenționat mult mai selectiv pentru a înregistra aceste informații). Nu trebuie să postați conținut de depanare generat de ASF în nicio locație publică, Dezvoltatorul ASF trebuie să vă reamintească întotdeauna că l-ați trimis prin e-mail sau prin altă locație sigură. Nu stocăm, nici nu folosim aceste detalii sensibile, sunt scrise ca parte a rutinelor de depanare deoarece prezența lor ar putea fi relevantă pentru problema care vă afectează. Am prefera să nu modificați logarea ASF în vreun fel, dar dacă sunteți îngrijorat, sunteți liber să redați aceste detalii sensibile în mod corespunzător.

> Redactarea implică înlocuirea detaliilor sensibile, de exemplu cu stele. Ar trebui să vă abțineți de la eliminarea completă a liniilor sensibile, deoarece existența lor pură ar putea fi relevantă și ar trebui păstrată.

---

### `Bot Implicit`

`șir` tip cu valoarea implicită `null`. În unele scenarii, ASF funcționează cu conceptul de bot implicit responsabil de manipularea a ceva - de exemplu, comenzi IPC sau consolă interactivă atunci când nu specificați botul țintă. Această proprietate vă permite să alegeți bot-ul implicit responsabil pentru manipularea unor astfel de scenarii, punând `BotName` aici. Dacă botul dat nu există, sau utilizaţi o valoare implicită de `null`, ASF va alege primul bot înregistrat sortat alfabetic. De obicei doriţi să utilizaţi această proprietate de configurare dacă doriţi să omiteţi punctul `[Bots]` în argumentul IPC şi comenzi de consolă interactivă, și întotdeauna alegeți același bot ca cel implicit pentru astfel de apeluri.

---

### `Întârziere agricolă`

`byte` tip cu valoarea implicită de `15`. In order for ASF to work, it will check currently farmed game every `FarmingDelay` minutes, if it perhaps dropped all cards already. Setarea excesivă a acestei proprietăți poate duce la trimiterea unui număr excesiv de cereri de abur, în timp ce setează prea mult poate duce la un titlu ASF încă "farm" dat pentru până la `Ferma Întârziată` la câteva minute după ce este complet crescut. Valoarea implicită trebuie să fie excelentă pentru majoritatea utilizatorilor, dar dacă ai mulți boți care rulează, puteți lua în considerare creșterea acestuia la ceva ca `30` minute pentru a limita trimiterea cererilor de aburi. Este frumos să reții că ASF folosește un mecanism bazat pe evenimente și verifică pagina de insignă a jocului pe fiecare articol Steam abandonat, astfel încât, în general, **nici măcar nu trebuie să-l verificăm la intervale fixe de timp**, dar pentru că nu avem încredere deplină în rețeaua Steam - verificăm oricum pagina de insignă a jocului, dacă nu am verificat-o prin eveniment abandonat de pe card în ultimele `FarmingDelay` minute (în cazul în care rețeaua Steam nu ne-a informat despre elementul aruncat sau despre alte lucruri precum acesta). Presupunând că rețeaua Steam funcționează corect, micșorând această valoare **nu va îmbunătăți în niciun fel eficiența agriculturii**, în timp ce **crește cheltuielile de rețea semnificativ** - este recomandat doar să o măriți (dacă este necesar) de la valoarea implicită de `15` minute. Dacă nu aveți un motiv **strong** pentru a edita această proprietate, ar trebui să o păstrați în mod implicit.

---

### `FilterBadBots`

`bool` tip cu valoarea implicită `true`. Această proprietate definește dacă ASF va refuza automat tranzacționarea ofertelor primite de la actori incorecți cunoscuți și marcați. Pentru a face asta, ASF va comunica cu serverul nostru la nevoie pentru a prelua o listă de identificatori Steam listați pe lista neagră. Roboții enumerați sunt exploatați de persoane care sunt clasificate ca fiind dăunătoare pentru inițiativa ASF de către noi, cum ar fi cele care încalcă codul nostru **[de conduită](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, utilizează funcţionalitatea şi resursele furnizate de noi, cum ar fi **[`PublicListing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** pentru a abuza şi exploata alte persoane, sau desfășoară activități infracționale directe, cum ar fi lansarea de atacuri DDoS pe server. Întrucât ASF are o poziție fermă cu privire la corectitudinea generală, onestitate și cooperare între utilizatorii săi, pentru ca întreaga comunitate să prospere, această proprietate este activată în mod implicit și, prin urmare, ASF filtrează boții pe care i-am clasificat ca dăunători din serviciile oferite. Dacă nu aveți un motiv **strong** pentru a edita această proprietate, cum ar fi să nu fim de acord cu declarația noastră și să permitem în mod intenționat acestor roboți să funcționeze (inclusiv să vă exploateze conturile), ar trebui să o păstrați în mod implicit.

---

### `GiftsLimiterDelay`

`byte` tip cu valoarea implicită de `1`. ASF se va asigura că vor exista cel puțin `GiftsLimiterDelay` secunde între două cereri consecutive de acordare a cadoului/cheiei/licenței (revendicare) pentru a evita declanșarea limitei vitezei. În plus față de asta, va fi folosit și ca număr maxim global pentru cererile din lista de jocuri, precum cel emis de `owns` **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Dacă nu aveți un motiv **strong** pentru a edita această proprietate, ar trebui să o păstrați în mod implicit.

---

### `Nerespectare`

`bool` tip cu valoarea implicită de `false`. Această proprietate definește dacă procesul ar trebui să ruleze în modul fără cap. Când în modul fără cap, ASF presupune că rulează pe un server sau în alt mediu non-interactiv, prin urmare, nu va încerca să citească nicio informație prin intermediul consolei. Aceasta include detalii la cerere (acreditarea contului, cum ar fi codul 2FA, codul SteamGuard; parolă sau orice altă variabilă necesară pentru ca ASF să funcționeze), precum și toate celelalte intrări ale consolei (cum ar fi consola de comandă interactivă). Cu alte cuvinte, modul `Headless` este egal cu crearea doar pentru consola ASF în citire. Această setare este utilă în principal pentru utilizatorii care rulează ASF pe serverele lor, în loc să întrebe. . pentru codul 2FA, ASF va anula silențios operațiunea prin oprirea unui cont. Dacă nu rulați ASF pe un server și ați confirmat anterior că ASF este capabil să opereze în modul non-headless ar trebui să păstrați această proprietate dezactivată. Orice interacţiune a utilizatorului va fi refuzată atunci când este în modul fără cap, iar conturile nu vor rula dacă au nevoie de intrarea de la **orice** consolă la pornire. Acest lucru este util pentru servere, deoarece ASF poate renunța la încercarea de a se conecta la cont atunci când li se solicită acreditări, în loc să aștepte (infinit) ca utilizatorul să le furnizeze.

Activarea acestui mod vă va permite să furnizați intrarea necesară a consolei prin alte mijloace, adică ASF-ui (ASF API), sau prin comanda **[`input`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#input-command)**. Dacă nu sunteți sigur cum să setați această proprietate, lăsați-o cu valoarea implicită de `false`.

---

### `IdleFarmingPeriod`

`byte` tip cu valoarea implicită `8`. Când ASF nu are nimic de crescut, va verifica periodic fiecare `IdleFarmPerioingPeriod` ore dacă poate contul a primit câteva jocuri noi pentru a ferma. Această caracteristică nu este necesară atunci când vorbim despre jocuri noi primim, deoarece ASF este suficient de inteligent pentru a verifica automat paginile de insignă în acest caz. `IdleFarmingPeriod` este în principal pentru situații precum jocurile vechi pe care le avem deja cu carduri de tranzacționare adăugate. În acest caz nu există niciun eveniment, deci ASF trebuie să verifice periodic paginile de insignă dacă dorim ca acest lucru să fie acoperit. Valoarea `0` dezactivează această caracteristică. Verifică, de asemenea: `ShutdownOnFarmingTerminat` preferință în `Preferințe agricole`.

---

### `InventoryLimiterDelay`

`byte` tip cu valoarea implicită de `4`. ASF se va asigura că vor exista cel puțin `InventoryLimiterDelay` secunde între două cereri consecutive de inventar web pentru a evita declanșarea limitei vitezei - cele care sunt utilizate, de exemplu, în timpul marcării notificărilor de inventar ca citire, ar putea fi folosit, de asemenea, de plugin-uri terțe care preiau inventarul altor utilizatori. Această proprietate nu este utilizată pentru preluarea propriului nostru inventar, deoarece ASF utilizează un apel mai eficient la rețea internă, așa că nu va afecta în niciun fel comenzile ca `loot` sau `transfer`. Valoarea implicită de `4` a fost setată pe baza inventarelor de marcaj a peste 100 de cazuri consecutive de bot, şi trebuie să satisfacă majoritatea (dacă nu toate) utilizatorilor. Cu toate acestea, puteți dori să o scădeți, sau chiar să schimbați la `0` dacă aveți un număr foarte mic de boți, astfel ASF va ignora întârzierea și va marca inventarele Steam mult mai repede. Be warned though, as setting it too low **will** result in Steam temporarily banning your IP, and that will prevent you from making any calls at all. De asemenea, ar putea fi nevoie să creșteți această valoare dacă rulați mulți roboți cu o mulțime de cereri de inventar, deşi în acest caz probabil ar trebui să încercaţi să limitaţi numărul acestor solicitări. Dacă nu aveți un motiv **strong** pentru a edita această proprietate, ar trebui să o păstrați în mod implicit.

---

### `IPC`

`bool` tip cu valoarea implicită `true`. Această proprietate definește dacă serverul ASF **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** ar trebui să înceapă împreună cu acest proces. IPC permite comunicarea între procese, inclusiv utilizarea **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, prin pornirea unui server HTTP local. Dacă nu intenționați să utilizați orice integrare IPC terță parte cu ASF, inclusiv ASF-ui, puteți dezactiva în siguranță această opțiune. În caz contrar, este o idee bună să-l păstrăm activat (opțiunea implicită).

---

### `IPCPassword`

`șir` tip cu valoarea implicită `null`. Această proprietate definește parola obligatorie pentru fiecare apel API efectuat prin IPC și servește ca măsură suplimentară de securitate. Când este setat pe valoare non-goală, toate cererile IPC vor necesita extra `parola` proprietatea setată la parola specificată aici. Valoarea implicită de `null` va sări peste nevoia parolei, făcând ASF să respecte toate interogările. În plus, activând această opțiune activează, de asemenea, mecanismul IPC anti-brutefort, care va interzice temporar utilizarea `IPaddress` după trimiterea prea multor cereri neautorizate într-un timp foarte scurt. Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

### `IPCPasswordFormat`

`octeți` tip cu valoarea implicită de `0`. Această proprietate definește formatul de proprietate `IPCPassword` și folosește `Metoda EHash` ca tip de bază. Vă rugăm să consultaţi secţiunea **[Securitate](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** dacă doriţi să aflaţi mai multe, pentru că va trebui să vă asiguraţi că proprietatea `IPCPassword` include într-adevăr parola în potrivirea cu `IPCPasswordFormat`. Cu alte cuvinte, când schimbi `IPCPasswordFormat` atunci `IPCPassword` ar trebui să fie **deja** în acel format, nu doar să încerci să fii. Dacă nu știi ce faci, ar trebui să îl păstrezi cu valoarea implicită de `0`.

---

### `LicenseID`

`Ghid ?` tip cu valoarea implicită `null`. Această proprietate permite sponsorilor noștri **[](https://github.com/sponsors/JustArchi)** să mărească ASF cu caracteristici opționale care necesită resurse plătite pentru a funcționa. Deocamdată, acest lucru vă permite să utilizaţi opţiunea **[`Potrivire`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** în plugin-ul `ItemsMatcher`.

În timp ce vă recomandăm să utilizați GitHub deoarece acesta oferă un nivel lunar și unic, precum și permite automatizarea completă și vă oferă acces imediat, noi **deasemenea** acceptăm toate celelalte opțiuni de donație **[disponibile în prezent](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. Vezi **[acest post](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** pentru instrucțiuni despre cum să donezi folosind alte metode pentru a obține o licență manuală valabilă pentru o anumită perioadă.

Indiferent de metoda folosită, dacă ești sponsor ASF, poți obține licența **[aici](https://asf.justarchi.net/User/Status)**. Va trebui să te conectezi cu GitHub pentru a-ți confirma identitatea, noi cerem doar informații publice cu citire, care sunt numele tău de utilizator. `LicenseID` este compus din 32 de caractere hexadecimale, cum ar fi `f6a0529813f74d119982eb4fe43a9a24`.

**Asigurați-vă că nu partajați licența `` cu alte persoane**. Din moment ce este emis pe baze personale, ar putea fi revocat în caz de scurgere. Dacă din întâmplare vi s-a întâmplat acest lucru din greșeală, puteți genera unul nou din același loc.

Dacă nu doriți să activați funcționalități ASF suplimentare, nu este nevoie să obțineți/furnizați licența.

---

### `LoginLimiterÎntârziere`

`byte` tip cu valoarea implicită de `10`. ASF se va asigura că va exista cel puțin `LoginLimiterDelay` secunde între două încercări consecutive de conectare pentru a evita declanșarea limitei vitezei. Valoarea implicită de `10` a fost setată pe baza conectării a peste 100 de roboți, și ar trebui să satisfacă majoritatea (dacă nu toate) utilizatorilor Cu toate acestea, puteți dori să o măriți/micșorați, sau chiar să schimbați la `0` dacă aveți o cantitate foarte mică de boți, astfel ASF va ignora întârzierea și se va conecta la Steam mult mai repede. Be warned though, as setting it too low while having too many bots **will** result in Steam temporarily banning your IP, and that will prevent you from logging in **at all**, with `InvalidPassword/RateLimitExceeded` error - and that also includes your normal Steam client, not only ASF. De asemenea, dacă rulezi un număr excesiv de boți, în special împreună cu alți clienți Steam/unelte care folosesc aceeași adresă IP, cel mai probabil va trebui să creșteți această valoare pentru a răspândi datele de conectare pe o perioadă mai lungă de timp.

Ca o notă laterală, această valoare este de asemenea folosită ca încărcare-echilibrare tampon în toate acțiunile programate pentru ASF, cum ar fi tranzacțiile în `SendTradePeriod`. Dacă nu aveți un motiv **strong** pentru a edita această proprietate, ar trebui să o păstrați în mod implicit.

---

### `MaxFarmingTime`

`byte` tip cu valoarea implicită de `10`. După cum ar trebui să știți, Steam nu funcționează întotdeauna în mod corespunzător, uneori se pot întâmpla situații ciudate precum timpul nostru de joacă care nu a fost înregistrat, în ciuda faptului că jucăm un joc. ASF va permite cultivarea unui singur joc într-un mod individual pentru maxim `MaxFarmingTime` ore și considerați-l complet cultivat după acea perioadă. Acest lucru este necesar pentru a nu îngheța procesul de producție agricolă în cazul în care se întâmplă situații ciudate, dar și dacă, dintr-un anumit motiv, Steam a lansat o nouă insignă care ar opri ASF să progreseze mai departe (vedeți: `Blacklist`). Valoarea implicită de `10` ore ar trebui să fie suficientă pentru a plasa toate cartonașele cu aburi dintr-un singur joc. Setarea prea mică a acestei proprietăți poate duce la omiterea jocurilor valide (și da, există jocuri valabile, care durează chiar până la 9 ore, în timp ce instalarea acestora la un nivel prea ridicat poate duce la îngheţarea proceselor agricole. Vă rugăm să rețineți că această proprietate afectează numai un singur joc într-o singură sesiune de creștere (așa că după trecerea prin întreaga coadă ASF va reveni la acel titlu), de asemenea nu se bazează pe timpul total de redare, ci pe timpul intern de producție ASF, astfel încât ASF se va întoarce la acel titlu după o repornire. Dacă nu aveți un motiv **strong** pentru a edita această proprietate, ar trebui să o păstrați în mod implicit.

---

### `MaxTradeHoldDuration`

`byte` tip cu valoarea implicită de `15`. Această proprietate definește durata maximă a tranzacției în zile pe care suntem dispuși să le acceptăm - ASF va respinge tranzacțiile care sunt deținute pentru mai mult de `MaxTradeHoldDuration` zile, conform definiției de la punctul **[de tranzacționare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**. Această opțiune are sens numai pentru roboții cu `Preferințe` pentru `SteamTradeMatcher`, deoarece nu afectează tranzacțiile `Master`/`SteamOwnerID` , nici donații. Organizaţiile comerciale sunt enervante pentru toată lumea şi nimeni nu vrea cu adevărat să se ocupe de ele. ASF ar trebui să lucreze la normele liberale și să îi ajute pe toți, indiferent dacă este în așteptare sau nu - acesta este motivul pentru care această opțiune este setată în mod implicit la `15`. Cu toate acestea, dacă preferați să respingeți toate tranzacțiile afectate de deținerile de tranzacții, puteți specifica `0` aici. Vă rugăm să luați în considerare faptul că aceste carduri cu durată scurtă de viață nu sunt afectate de această opțiune și respinse automat pentru persoanele care efectuează tranzacții, așa cum este descris în secțiunea **[de tranzacționare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** , deci nu este nevoie să respingem pe toată lumea doar din această cauză. Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.


---

### `MinFarmingDelayAfterBlock`

`byte` tip cu valoarea implicită de `60`. Această proprietate definește timpul minim, în secunde, care ASF va aștepta înainte de a relua cardurile de creștere dacă a fost deconectat anterior de la `LoggedInElsewhere`, care se întâmplă atunci când decizi să deconectezi forțat ASF-ul actual în agricultură lansând un joc. Această întârziere există în principal din motive de confort și de cheltuieli generale; de exemplu, vă permite să reporniți jocul fără a fi nevoie să luptați cu ASF ocupând din nou contul dvs. doar pentru că blocarea jocului a fost disponibilă pentru o secundă. Din cauza faptului că recuperarea sesiunii cauzează `LoggedInElsewhere` deconectare, ASF trebuie să parcurgă întreaga procedură de reconectare, care exercită o presiune suplimentară asupra maşinii şi a reţelei Steam, evitând astfel deconectările suplimentare, dacă este posibil, este de preferat. În mod implicit, acesta este configurat la `60` secunde, ceea ce ar trebui să fie suficient pentru a permite repornirea jocului fără prea multe complicații. Cu toate acestea, există scenarii în care aţi putea fi interesat să îl creşteţi. de exemplu, în cazul în care rețeaua dvs. se deconectează adesea, iar ASF preia funcția prea curând, ceea ce face ca procesul de reconectare să fie forțat chiar dumneavoastră. Permitem o valoare maximă de `255` pentru această proprietate, care ar trebui să fie suficientă pentru toate scenariile comune. În plus față de cele de mai sus, este posibilă și scăderea întârzierii, sau chiar eliminați-l în întregime cu o valoare de `0`, deşi de obicei acest lucru nu este recomandat din motivele menţionate mai sus. Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

### `OptimizareMod`

`octeți` tip cu valoarea implicită de `0`. Această proprietate definește modul de optimizare pe care ASF îl va prefera în timpul rulării. În prezent, ASF acceptă două moduri - `0` care se numește `MaxPerformance`, şi `1` care se numeşte `MinMemoryUsage`. ASF implicit preferă să ruleze cât mai multe lucruri în paralel (concomitent) posibil, care îmbunătăţeşte performanţa prin activitatea de echilibrare a încărcării la nivelul tuturor nucleelor CPU, fire multiple ale procesorului, mai multe sock-uri şi multiple sarcini de threadpool (grupuri multiple). De exemplu, ASF va solicita prima pagină cu insigne atunci când verifici jocuri pentru a ferma și apoi o dată ce ai primit cererea, ASF va citi de la ea câte pagini de insigne de fapt, apoi va solicita unul altuia concomitent câte pagini. Asta este ceea ce ar trebui să vrei **aproape întotdeauna**, întrucât cheltuielile de regie în cele mai multe cazuri sunt minime, iar beneficiile de pe urma codului ASF asincron pot fi văzute chiar şi pe cele mai vechi hardware-uri cu un singur nucleu al procesorului şi cu o putere foarte limitată în timp. Cu toate acestea, având în vedere că multe sarcini sunt prelucrate în paralel, timpul alocat ASF este responsabil pentru întreținerea lor, de exemplu: menținerea unor buzunare deschise, a unor fire vii și a unor sarcini în curs de prelucrare; care poate duce la o utilizare sporită a memoriei din când în când, și dacă ești extrem de constrâns de memoria disponibilă, poate doriţi să schimbaţi această proprietate la `1` (`Memorie`) pentru a forţa ASF să utilizeze cât mai puţine sarcini posibil, și în mod tipic care rulează posibil cod asincron, sincron spre paralel. Ar trebui să luați în considerare comutarea acestei proprietăți numai dacă ați citit anterior **[configurare de memorie mică](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** și doriți în mod intenționat să sacrificați stimulul de performanță gigantică, pentru o foarte mică pierdere a memoriei. De obicei, această opțiune este **mult mai rău** decât ceea ce se poate realiza cu alte modalități posibile, cum ar fi limitarea utilizării ASF sau reglarea colectorului de gunoi în timpul rulării, după cum se explică în **[configurare cu memorie mică](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Prin urmare, ar trebui să utilizați `MinMemoryUsage` ca **ultima soluție**, chiar înainte de recompilarea timpului rulat, dacă nu puteai obține rezultate satisfăcătoare cu alte opțiuni (mai bine). Dacă nu aveți un motiv **strong** pentru a edita această proprietate, ar trebui să o păstrați în mod implicit.

---

### `PluginsUpdateList`

`ImmutableHashSet<string>` tip cu valoarea implicită a fi goală. Această proprietate definește lista de nume de asamblare a plugin-urilor care sunt fie lista neagră, fie lista albă pentru a fi luate în considerare pentru actualizări automate, ca pe `PluginsUpdateMode` definit mai jos.

Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

### `PluginsUpdateMode`

`octeți` tip cu valoarea implicită de `0`. Această proprietate defineşte modul de actualizare a plugin-urilor care dă sens lui `PluginsUpdateList` definit mai sus. Prin specificarea acestei proprietăți puteți activa/dezactiva cu ușurință actualizările automate pentru toate plugin-urile, cu excepția celor declarate.

- Valoarea `0`, numită `Whitelist`, **dezactivează actualizarea automată** a tuturor plugin-urilor, cu excepția celor definite în `PluginsUpdateList`.
- Valoarea `1`, numită `Blacklist`, **permite actualizarea automată** a tuturor plugin-urilor, cu excepția celor definite în `PluginsUpdateList`.

**Echipa ASF ar dori să vă reamintească că, pentru siguranța proprie, ar trebui să activați actualizările automate doar de la părțile de încredere**. Țineți cont de faptul că plugin-urile malițioase pot decide să se actualizeze sau să execute comenzi de la distanță **indiferent** de această setare, acesta este motivul pentru care această setare se aplică exclusiv plugin-urilor furnizate de ASF-, și ar trebui să vă asigurați că ați verificat corespunzător fiecare plugin pe care ați decis să îl folosiți.

Actualizările plugin-urilor sunt efectuate implicit împreună cu rutina de actualizare ASF - **[`UpdateChannel`](#updatechannel)** şi **[`UpdatePeriod`](#updateperiod)**. Mecanismele standard de actualizare ASF cum ar fi `update` vor declanșa și actualizarea plugin-urilor opționale. Dacă dorești în schimb să actualizezi plugin-urile manual fără a actualiza versiunea ASF în același timp, `updateplugins` comandă oferă astfel de posibilități.

Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

### `Oprire Ifposibil`

`bool` tip cu valoarea implicită de `false`. Când este activată, ASF va încerca să închidă procesul dacă este posibil, adică atunci când toți roboții înregistrați sunt opriți. Acest lucru poate fi util în special când este combinat cu `ShutdownOnFarmingFined` în toate cazurile botului tău, din acest motiv, ASF va fi permis să închidă automat atunci când ultimul bot termină agricultura.

Deoarece aşteptarea majorităţii utilizatorilor este ca procesul să fie rulat în orice moment, e aşa. . pentru utilizarea `IPC` , această opțiune este dezactivată în mod implicit.

---

### `Prefix SteamMessagePrefix`

`șir` tip cu valoarea implicită `"/me "`. Această proprietate definește un prefix care va fi preatașat la toate mesajele Steam trimise de ASF. ASF folosește implicit `"/me"` prefixul pentru a distinge mai ușor mesajele botului afișându-le în culori diferite în chat-ul Steam. O altă mențiune demnă este `"/pre "` prefixul care atinge rezultate similare, dar folosește o formatare diferită. De asemenea, puteți seta această proprietate pe un șir gol sau `null` pentru a dezactiva utilizarea prefixului în întregime și a afișa toate mesajele ASF într-un mod tradițional. Este frumos să remarci că această proprietate afectează doar mesajele Steam - răspunsurile returnate prin alte canale (cum ar fi IPC) nu sunt afectate. Dacă nu doriți să personalizați comportamentul standard ASF, este o idee bună să îl lăsați la un nivel implicit.

---

### `SteamOwnerID`

`ulong` tip cu valoarea implicită `0`. Această proprietate defineşte ID-ul Steam în forma 64-bit de proprietar a procesului ASF, și este foarte asemănător cu `Master` permisiunea acordată instanței botului (dar global în schimb). Aproape întotdeauna doriți să setați această proprietate pe ID-ul propriului cont principal Steam. `Permisiunea de Master` include controlul complet asupra instanței botului său, dar comenzi globale cum ar fi `exit`, `reîncepe` sau `actualizează` sunt rezervate doar pentru `SteamOwnerID`. Acest lucru este convenabil, deoarece poate doriți să rulați roboți pentru prietenii dumneavoastră, cât timp nu le permite să controleze procesul ASF, cum ar fi ieșirea din comanda `exit`. Valoarea implicită a `0` specifică faptul că nu există proprietar al procesului ASF, ceea ce înseamnă că nimeni nu va putea emite comenzi ASF la nivel mondial. Reţineţi că această proprietate se aplică exclusiv chat-ului Steam. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, precum şi consola interactivă, încă vă va permite să executați comenzi `Proprietarul` chiar dacă această proprietate nu este setată.

---

### `Protocoale`

`bat steagurile` cu valoarea implicită `7`. Această proprietate definește protocoalele Steam pe care ASF le va utiliza atunci când se conectează la serverele Steam, care sunt definite mai jos:

| Valoare | Nume      | Descriere                                                                                                    |
| ------- | --------- | ------------------------------------------------------------------------------------------------------------ |
| 0       | Nimic     | No protocol                                                                                                  |
| 1       | TCP       | **[Protocolul privind controlul transmiterii](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2       | UDP       | **[Protocolul Datagram utilizator](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**                   |
| 4       | WebSocket | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                                                     |

Vă rugăm să rețineți că această proprietate este câmpul `steag` , prin urmare este posibil să alegeți orice combinație de valori disponibile. Vezi **[harta json](#json-mapping)** dacă vrei să afli mai multe. Nu activarea nici unui steag duce la opțiunea `None` , iar această opțiune nu este validă de unul singur.

În mod implicit, ASF va utiliza toate protocoalele de Steam disponibile ca o măsură pentru a lupta cu timpi favorabili și alte probleme similare legate de Steam. De obicei doriți să schimbați această proprietate dacă doriți să limitați ASF în a utiliza doar unul sau două protocoale specifice. Astfel de măsuri ar putea fi necesare în diverse situaţii; de exemplu dacă ai blocat traficul UDP pe firewall-ul tău și vrei să te asiguri că doar traficul TCP va trece, sau dacă utilizaţi `WebProxy` şi doriţi să-l utilizaţi şi pentru conexiunea cu clientul Steam, ca doar protocolul `WebSocket` îl acceptă.

Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

### `ActualizareCanal`

`byte` tip cu valoarea implicită de `1`. Această proprietate defineşte canalul de actualizare care este utilizat, fie pentru actualizări automate (dacă `UpdatePeriod` este mai mare decât `0`), fie actualizări (altfel). În prezent, ASF acceptă trei canale de actualizare - `0` care se numește `None`, `1`, care se numește `Stable`și `2`, care se numește `Prelansare` Canalul `Stable` este canalul de lansare implicit, care ar trebui folosit de majoritatea utilizatorilor. `Prerelease` canal, în plus față de versiunile `Stable` , include de asemenea **pre-lansări** dedicate utilizatorilor avansați și altor dezvoltatori pentru a testa noi caracteristici, confirmați erorile sau oferiți feedback despre îmbunătățirile planificate. **Versiunile de pre-lansare conțin adesea erori nepatrate, caracteristici în curs de lucru sau implementări rescrise**. Dacă nu te consideri utilizator avansat, te rugăm să rămâi cu canalul de actualizare `1` (`Stable`). `Canalul Prerelease` este dedicat utilizatorilor care știu cum să raporteze erorile, să abordeze problemele și să ofere feedback - nu se va acorda asistență tehnică. Vezi ASF **[ciclu de eliberare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** dacă dorești să afli mai multe. De asemenea, puteți seta `UpdateChannel` la `0` (`None`), dacă doriți să eliminați complet toate verificările versiunilor. Setarea `UpdateChannel` la `0` va dezactiva complet întreaga funcționalitate legată de actualizări, inclusiv comanda `actualizare`. Utilizarea canalului `None` este **puternic descurajată de** din cauza tuturor problemelor (menționate în descrierea `UpdatePeriod` de mai jos).

**Dacă nu știi ce faci**, noi **puternic** recomandăm să fie păstrat la valori implicite.

---

### `ActualizarePerioadă`

`byte` tip cu valoarea implicită de `24`. Această proprietate definește cât de des ASF ar trebui să verifice pentru actualizări automate. Actualizările sunt cruciale nu numai pentru a primi noi caracteristici și paturi critice de securitate, ci și pentru a primi bugfixuri, îmbunătățiri ale performanței, îmbunătățiri ale stabilității și multe altele. Atunci când este setată o valoare mai mare de `0` , ASF se va descărca automat, înlocuiește, și reporniți singur (dacă `AutoReart` permite) când este disponibilă o nouă actualizare. Pentru a realiza acest lucru, ASF va verifica fiecare `UpdatePeriod` ore dacă este disponibilă o nouă actualizare pe GitHub repo. O valoare de `0` dezactivează actualizările automate, dar încă îți permite să execuți comanda `actualizează` manual. S-ar putea să fiți interesați să setați `UpdateChannel` pe care `UpdatePeriod` trebuie să îl urmeze.

Procesul de actualizare a ASF implică actualizarea întregii structuri de dosare pe care ASF o folosește, dar fără a îți atinge propriile configurații sau baze de date localizate în directorul `config` - asta înseamnă că orice fișiere suplimentare neasociate cu ASF în directorul său pot fi pierdute în timpul actualizării. Valoarea implicită de `24` este un bun echilibru între verificările inutile, iar ASF este suficient de proaspăt.

Dacă nu ai un motiv **strong** pentru a dezactiva această caracteristică, trebuie să păstrați actualizările automate activate într-un termen rezonabil `UpdatePeriod` **pentru propriul dumneavoastră**. Asta nu se întâmplă doar pentru că noi nu oferim nimic altceva decât cea mai recentă versiune stabilă ASF, dar și pentru că **oferim garanția noastră de securitate doar pentru cea mai recentă versiune**. If you're using outdated ASF version then you're intentionally exposing yourself to all kind of issues, from small bugs, through broken functionality, ending with **[permanent Steam account suspensions](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**, so we **strongly recommend**, for your own good, to always ensure that your ASF version is up to date. Actualizările automate ne permit să reacționăm rapid la toate tipurile de probleme dezactivând sau modificând codul problematic înainte de a escalada - dacă renunțați la el, pierdeți toate garanțiile noastre de securitate și consecințele riscului de a rula un cod care ar putea fi potențial dăunător, nu numai la rețeaua Steam, ci și (prin definiție) la propriul cont Steam.

---

### `WebLimiterÎntârziere`

`ushort` tip cu valoarea implicită `300`. Această proprietate definește, în milisecunde, valoarea minimă de întârziere între trimiterea a două cereri consecutive către același serviciu web Steam. O astfel de întârziere este necesară ca **[AkamaiGhost](https://www.akamai.com)** serviciu pe care Steam îl utilizează pe plan intern include limitarea ratei pe baza numărului global de cereri trimise în perioada dată. În condiții normale, blocul akamai este destul de greu de realizat, dar în condiții de muncă foarte grele cu o imensă listă de cereri în curs, este posibil să îl declanșăm dacă continuăm să trimitem prea multe cereri pe o perioadă prea scurtă de timp.

Valoarea implicită a fost setată pe baza ipotezei că ASF este singurul instrument care accesează serviciile web Steam, în special de la `steamcommunity om`, `api.steampowered.com` și `store.steampowered.com`. Dacă folosiți alte instrumente care trimit cereri către aceleași servicii web, atunci ar trebui să vă asigurați că instrumentul dvs. include funcționalități similare ale `WebLimiterDelay` și setați ambele valori duble, care ar fi `600`. Acest lucru garantează că în niciun caz veți depăși trimiterea a mai mult de o cerere per `300` ms.

În general, reducerea `WebLimiterDelay` sub valoarea implicită este **puternic descurajat** deoarece ar putea duce la diverse blocuri legate de IP, unele dintre acestea pot fi permanente. Valoarea implicită este suficient de bună pentru a rula o singură instanță ASF pe server, precum și utilizarea ASF în scenariul normal, împreună cu clientul original Steam. Ar trebui să fie corect pentru majoritatea utilizărilor şi ar trebui să îl creşteţi doar (nu să-l coborâţi niciodată). Pe scurt, numărul global al tuturor cererilor trimise de la un singur IP la un singur domeniu Steam nu trebuie să depășească niciodată mai mult de o cerere per `300` ms.

Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

### `WebProxy`

`șir` tip cu valoarea implicită `null`. Această proprietate defineşte o adresă proxy care va fi folosită pentru comunicarea internă http, în special pentru servicii cum ar fi `github. om`, `api.steampowered.com`, `steamcommunity.com` și `store.steampowered.com`. Se aplică comunicării generale (non-bot specific), precum și comunicării specifice bot-ului, în cazul în care proprietatea de configurare echivalentă `WebProxy` nu este setată. Proxidarea cererilor ASF ar putea fi extrem de utilă pentru ocolirea diferitelor tipuri de ziduri de protecție, în special a marelui firewall din China.

Această proprietate este definită ca șir de caractere:

> Un şir URI este compus dintr-o schemă (sprijinită: http/https/socks4/socks4a/socks5), o gazdă şi un port opţional. Un exemplu de șiruri complete este `"http://contoso.com:8080"`.

Dacă proxy-ul dvs. necesită autentificarea utilizatorului, va trebui de asemenea să configurați `WebProxyUsername` și/sau `WebProxyPassword`. Dacă nu există o astfel de necesitate, numai crearea acestei proprietăți este suficientă.

Dacă aveți nevoie și de proxing pentru comunicarea internă prin rețeaua Steam (CM), atunci ar trebui să vă asigurați că configurați proprietatea **[`SteamProtocols`](#steamprotocols)** bot la o valoare care permite doar transportul de websocket i. . o valoare de `4`, ca doar websockets sunt acceptate pentru proxying.

Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

### `Parola WebProxyParolă`

`șir` tip cu valoarea implicită `null`. Această proprietate definește parola folosită în baza, digest, NTLM, și autentificarea Kerberos care este suportată de un aparat țintă `WebProxy` care oferă funcționalitate proxy. Dacă proxy-ul tău nu necesită acreditări de utilizator, nu este nevoie să introduci nimic aici. Folosirea acestei opțiuni are sens numai în cazul în care `WebProxy` este folosit, deoarece nu are niciun efect în caz contrar.

Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

### `WebProxyUsername`

`șir` tip cu valoarea implicită `null`. Această proprietate definește câmpul de utilizator utilizat în baza, digestul, NTLM, și autentificarea Kerberos care este suportată de un aparat țintă `WebProxy` care oferă funcționalitate proxy. Dacă proxy-ul tău nu necesită acreditări de utilizator, nu este nevoie să introduci nimic aici. Folosirea acestei opțiuni are sens numai în cazul în care `WebProxy` este folosit, deoarece nu are niciun efect în caz contrar.

Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

## Bot config

Așa cum ar trebui să știți deja, fiecare bot ar trebui să aibă propria configurație bazată pe exemplu structura JSON de mai jos. Începe să decizi cum vrei să numești botul tău (de ex. `1.json`, `principal. son`, `primary.json` sau `AnythingElse.json`) și mergeți la configurare.

**Notificare:** Botul nu poate fi numit `ASF` (deoarece cuvântul cheie este rezervat pentru configurarea globală), ASF va ignora de asemenea toate fișierele de configurare începând cu un punct.

Configurarea botului are următoarea structură:

```json
{
    "AcceptGifts": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileAgricultură": null,
    "CustomGamePlayedWhileIdle": null,
    "Activat": fals,
    "Comenzi agricole": [],
    "Preferinţe agricole": 0,
    "GamesPlayedWhileIdle": [],
    "GamingDeviceType": 1,
    "HoursUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "MachineName": null,
    "MatchableTypes": [5]
    "Semnale Online": 0,
    "Stare Online": 1,
    "Format": 0,
    "Renunţare": 0,
    "Telecomunicaţie": 3,
    "SendTradePeriod": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0;
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "TransferabileTypes": [1, 3, 5],
    "UseLoginKeys": adevărat,
    "UserInterfaceMode": 0,
    "WebProxy": null,
    "Parola WebProxy": null,
    "WebProxyUsername": null
}
```

---

Toate opțiunile sunt explicate mai jos:

### `Acceptă cadouri`

`bool` tip cu valoarea implicită de `false`. Când este activat, ASF va accepta și valorifica automat toate cadourile de abur (inclusiv cardurile de cadou ale portofelului) trimise către bot. Aceasta include și cadouri trimise de la alți utilizatori decât cei definiți în `SteamUserPermissions`. Ține cont de faptul că cadourile trimise la adresa de e-mail nu sunt transmise direct clientului, deci ASF nu le va accepta pe cele fără ajutorul tău.

Această opțiune este recomandată numai pentru conturile de alt element, pentru că este foarte probabil să nu vrei să răscumperi automat toate cadourile trimise în contul tău principal. Dacă nu sunteţi sigur că doriţi această caracteristică activată sau nu, păstraţi-o cu valoarea implicită de `false`.

---

### `Comportament`

`bat steagurile` cu valoarea implicită de `0`. Această proprietate definește comportamentul similar robotului ASF în timpul diferitelor evenimente și este definită după cum urmează:

| Valoare | Nume                              | Descriere                                                                                                     |
| ------- | --------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| 0       | Nimic                             | Niciun comportament special pentru bot, setările implicite sane                                               |
| 1       | Injectare InvalidFriendInvitații  | Va face ASF să respingă (în loc de ignorare) invitații de prietenie nevalide                                  |
| 2       | Injectare InvalidTrade            | Va determina ASF să respingă (în loc să ignore) oferte de tranzacționare nevalide                             |
| 4       | Injectare InvalidGroupInvitații   | Va face ASF să respingă (în loc de ignorare) invitații de grup nevalide                                       |
| 8       | DismissInventoryNotificări        | Va determina ASF să respingă automat toate notificările din inventar                                          |
| 16      | MarkReceivedMessagesCitiți        | Va determina ASF să marcheze automat toate mesajele primite ca citite                                         |
| 32      | MarkBotMessagesCitiți             | Va determina ASF să marcheze automat mesajele de la alți roboți ASF (rulând în același caz) ca și cele citite |
| 64      | DezactiveazăIncomingTradesParsing | Va determina ASF să nu proceseze niciodată ofertele de tranzacționare primite                                 |

Vă rugăm să rețineți că această proprietate este câmpul `steag` , prin urmare este posibil să alegeți orice combinație de valori disponibile. Vezi **[harta json](#json-mapping)** dacă vrei să afli mai multe. Nu activarea steagurilor duce la opțiunea `None`.

În general, doriți să modificați această proprietate dacă așteptați să schimbați diverse setări de automatizare legate de activitatea bot-ului. Setările implicite implică ASF care rulează în modul non-invaziv, ceea ce permite doar automatizarea benefică care nu contravine voinței utilizatorului.

Invitația de prietenie nevalidă este o invitație care nu vine de la utilizatorul `FamilySharing` (definită în `SteamUserPermissions`) sau mai sus. ASF în modul normal ignoră acele invitații, după cum ați aștepta, oferindu-vă libertatea de a alege dacă să le acceptați sau nu. `RejectInvalidFriendInvitații` va cauza respingerea automată a acestor invitații, care practic va dezactiva opțiunea ca alte persoane să te adauge la lista lor de prieteni (deoarece ASF va refuza toate aceste cereri, în afară de persoanele definite în `SteamUserPermissions`). Dacă nu vrei să negi categoric toate invitațiile prietenilor, nu ar trebui să activezi această opțiune.

Ofertă comercială nevalidă este o ofertă care nu este acceptată prin modulul ASF încorporat. Mai multe aspecte pot fi găsite în secțiunea **[de tranzacționare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** care definește explicit ce tipuri de tranzacționare ASF este dispus să accepte automat. Tranzacțiile valide sunt definite și de alte setări, în special `TradingPreferences`. `Respingerea InvalidTrades` va cauza respingerea tuturor ofertelor de tranzacție invalidă, în loc să fie ignorată. Dacă nu vrei să negi categoric toate ofertele de tranzacționare care nu sunt acceptate automat de ASF, nu ar trebui să activezi această opțiune.

Invitația de grup nevalidă este o invitație care nu vine din grupul `SteamMasterClanID`. ASF în modul normal ignoră acele invitații de grup, după cum ați aștepta; vă permite să vă decideți dacă doriți să vă alăturați sau nu unui anumit grup Steam. `RejectInvalidGroupInvitații` va cauza respingerea automată a tuturor acelor invitații de grup, efectiv făcând imposibilă invitarea în orice alt grup decât `SteamMasterClanID`. Dacă nu vrei să interzici categoric toate invitațiile grupului, nu ar trebui să activezi această opțiune.

`DismissInventoryNotifications` este extrem de util atunci când începi să fii deranjat de notificarea Steam constantă despre primirea de elemente noi. ASF nu poate scăpa de notificare în sine, deoarece aceasta este încorporată în clientul tău Steam, dar este în măsură să șteargă automat notificarea după ce o primeți, care nu va mai lăsa în jur, prin intermediul notificărilor "elemente noi în inventar". Dacă vă aşteptaţi să vă evaluaţi toate articolele primite (în special cardurile cultivate cu ASF), atunci în mod natural nu ar trebui să activaţi această opţiune. Când începeți să vă înnebuniți, amintiți-vă că aceasta este oferită ca opțiune.

`MarkReceivedMessagesAsRead` va marca automat **toate mesajele** primite de contul pe care rulează ASF, atât privat, cât și de grup, la citire. Acest lucru ar trebui de obicei folosit de alte conturi doar pentru a șterge notificările "mesaj nou" care vin de la dvs. de ex. în timpul executării comenzilor ASF. Nu recomandăm această opțiune pentru conturile principale, cu excepția cazului în care doriți să vă tăiați de la orice fel de notificări pentru mesaje, **inclusiv** cele care s-au întâmplat în timp ce erați offline, presupunând că ASF a rămas deschis și că nu l-ați închis.

`MarkBotMessagesAsRead` funcţionează în mod similar prin marcarea doar a mesajelor de bot ca citit. Cu toate acestea, rețineți că atunci când utilizați această opțiune pe discuțiile de grup cu roboții și alte persoane, Implementarea cu abur a recunoașterii mesajului de chat **și** recunoaște toate mesajele care s-au întâmplat cu **înainte de** pe care ai decis să le marchezi, dacă cu orice șansă nu vrei să ratezi mesajul neasociat care s-a întâmplat intermediar, de obicei vrei să eviți să folosești această caracteristică. Evident, este riscant și atunci când ai mai multe conturi primare (ex. de la utilizatori diferiți) care rulează în aceeași instanță ASF, deoarece poți pierde mesajele lor normale în afara ASF.

`DisableIncomingTradesParsing` va opri ASF să analizeze ofertele de tranzacționare primite, acest lucru înseamnă că întreaga funcționalitate de tranzacționare legată de asta nu va fi funcțională. Deoarece ASF funcționează în modul cel mai puțin invaziv în mod implicit, acceptând numai ofertele de tranzacționare ale utilizatorilor de la `Master` și mai mult, nu se atinge niciodată alte oferte de tranzacționare - analiza tranzacțiilor primite este activată în mod implicit. Această setare este cea mai utilă pentru persoanele care doresc să se asigure că nu există cereri/cheltuieli suplimentare legate de parcarea tranzacțiilor, dezactivând întreaga logică în proces; de exemplu, pentru că știu că roboții lor nu vor primi niciodată cereri de tranzacționare, și, prin urmare, nu necesită deloc ASF care participă la activitatea lor de tranzacționare. Rețineți că dacă aveți această opțiune specificată va dezactiva toate celelalte opțiuni care depind și de tranzacțiile primite, cum ar fi `AcceptDonations` sau `SteamTradeMatcher` - plugin-urile personalizate vor fi, de asemenea, incapabile să proceseze ofertele de tranzacționare primite în mod obișnuit.

Dacă nu sunteți sigur cum să configurați această opțiune, este cel mai bine să o lăsați în mod implicit.

---

### `CompleteTypesToSend`

`ImmutableHashSet<byte>` tip cu valoarea implicită a fi goală. Când ASF este făcut cu completarea unui set dat de tipuri de elemente specificat aici, poate trimite automat schimbul de aburi cu toate seturile terminate către utilizatorul cu permisiunea `Master` , care este foarte convenabil dacă doriți să utilizați contul de bot dat. . Potrivire STM în timpul mutării seturilor terminate într-un alt cont. Această opțiune funcționează la fel ca comanda `loot` , Prin urmare, aveți în vedere faptul că necesită un utilizator cu setul de permisiuni `Master` , este posibil să aveți nevoie și de un `SteamTradeToken`valabil, precum și utilizarea unui cont care este eligibil pentru tranzacționare în primul rând.

Începând de astăzi, următoarele tipuri de articole sunt sprijinite în acest context:

| Valoare | Nume            | Descriere                                                                          |
| ------- | --------------- | ---------------------------------------------------------------------------------- |
| 3       | FoilTradingCard | Variantă de folie `TradingCard`                                                    |
| 5       | TradingCard     | Card de tranzacționare cu aburi, folosit pentru meșteșugirea insignelor (non-foil) |

Vă rugăm să reţineţi că indiferent de setările de mai sus, ASF va cere doar **[Articole ale comunității Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` din 753, `context` din 6), astfel încât toate obiectele de joc, cadourile și de asemenea sunt excluse prin definiție din oferta comercială.

Datorită costurilor suplimentare de utilizare a acestei opțiuni, este recomandat să fie folosit doar în conturile de roboți care au o șansă realistă de a termina seturi pe cont propriu - de exemplu, nu are nici un sens să activezi dacă deja folosești `SendOnFarmingTerminat` preferință în `FermeaPreferințe`, `Comanda SendTradePeriod` sau `loot` în mod obișnuit.

Dacă nu sunteți sigur cum să configurați această opțiune, este cel mai bine să o lăsați în mod implicit.

---

### `Personalizat GamePlayedWhileFerma`

`șir` tip cu valoarea implicită `null`. Când ASF este în agricultură, se poate afișa ca "Redarea jocului fără abur: `CustomGamePlayedWhileFarming`în loc de jocul actual cultivat. Acest lucru poate fi util dacă doriți să vă informați prietenii că faceți fermă, Totuşi, nu doriţi să utilizaţi `OnlineStatus` din `Offline`. Vă rugăm să rețineți că ASF nu poate garanta ordinea de afișare efectivă a rețelei Steam, Prin urmare, aceasta este doar o sugestie care poate sau nu să fie afişată în mod corespunzător. În special, numele personalizat nu va fi afișat în algoritmul de creștere `Complex` dacă ASF umple toate sloturile `32` cu jocuri care necesită ore pentru a fi blocate. Valoarea implicită a lui `null` dezactivează această caracteristică.

ASF oferă câteva variabile speciale pe care le poți folosi opțional în textul tău. `{0}` va fi înlocuit de ASF cu `AppID` din momentan de joc farmed, în timp ce `{1}` va fi înlocuit de ASF cu `GameName` al jocului(elor) cultivat(e) în prezent.

---

### `Personalizat GamePlayedWhileIdle`

`șir` tip cu valoarea implicită `null`. Similar cu `CustomGamePlayedWhileFarming`, dar pentru situația în care ASF nu are nimic de făcut (deoarece contul este complet cultivat). Vă rugăm să rețineți că ASF nu poate garanta ordinea de afișare efectivă a rețelei Steam, Prin urmare, aceasta este doar o sugestie care poate sau nu să fie afişată în mod corespunzător. Dacă folosiți `GamesPlayedWhileIdle` împreună cu această opțiune, atunci rețineți că `GamesPlayedWhileIdle` devine prioritar, prin urmare nu poți declara mai mult de `31` dintre ele, în caz contrar `CustomGamePlayedWhileIdle` nu va putea ocupa slotul pentru nume personalizat. Valoarea implicită a lui `null` dezactivează această caracteristică.

---

### `Activat`

`bool` tip cu valoarea implicită de `false`. Această proprietate definește dacă bot-ul este activat. Instanța botului activată (`true`) va porni automat la rularea ASF, cât timp robotul este dezactivat (`false`) va trebui să înceapă manual. În mod implicit, fiecare bot este dezactivat, așa că probabil vrei să schimbi această proprietate pe `true` pentru toți roboții tăi, care ar trebui să pornească automat.

---

### `Comenzi pentru agricultură`

`ImmutableLista<byte>` tip cu valoarea implicită a fi goală. Această proprietate definește comanda agricolă **preferată** folosită de ASF pentru un anumit cont de bot. În prezent sunt disponibile următoarele comenzi de curs:

| Valoare | Nume                    | Descriere                                                                                            |
| ------- | ----------------------- | ---------------------------------------------------------------------------------------------------- |
| 0       | Neordonat               | Nicio sortare, îmbunătățire ușoară a performanței procesorului                                       |
| 1       | AppIDsCrescător         | Încercaţi să creşteţi jocurile cu cele mai mici `appID-uri`                                          |
| 2       | AppIDsDescrescător      | Încercaţi să creşteţi jocurile cu cel mai înalt `appIDs` primul                                      |
| 3       | CardDropsCrescător      | Încearcă să faci jocuri cu cel mai mic număr de cărți rămase mai întâi                               |
| 4       | CardDropsDescendent     | Încearcă să faci jocuri cu cel mai mare număr de cărți rămase mai întâi                              |
| 5       | Ore ascendent           | Încercați să faceți jocuri cu cel mai mic număr de ore jucate mai întâi                              |
| 6       | OoreiDescendent         | Încercaţi să creşteţi jocurile cu cel mai mare număr de ore jucate primul                            |
| 7       | NumeCrescător           | Încercați să faceți jocuri în ordine alfabetică, începând de la A                                    |
| 8       | NumesDescendent         | Încercați să faceți jocuri în ordine alfabetică inversă, începând de la Z                            |
| 9       | Aleator                 | Încercați să faceți jocuri în ordine total aleatorie (diferită pe fiecare derulare a programului)    |
| 10      | BadgeLevelsCrescător    | Încercați mai întâi să faceți jocuri cu cele mai mici niveluri de insignă                            |
| 11      | BadgeLevelsDescendent   | Încercați mai întâi să faceți jocuri cu cele mai mari niveluri de insignă                            |
| 12      | RedeDateTimesCrescător  | Încercați mai întâi să cultivați cele mai vechi jocuri de pe contul nostru                           |
| 13      | RedeDateTimesDescendent | Încercați mai întâi să cultivați cele mai noi jocuri de pe contul nostru                             |
| 14      | MarketableCrescător     | Încercați mai întâi să cultivați jocuri cu cartele necomercializate (avertisment: scump de calculat) |
| 15      | MarketableDescendent    | Încercați mai întâi să cultivați jocuri cu cartele comercializabile (avertisment: scump de calculat) |

Deoarece această proprietate este o array, vă permite să utilizaţi mai multe setări diferite în comanda dvs. fixă. De exemplu, poți include valori `15`, `11` și `7` pentru a sorta mai întâi după jocurile comercializabile, apoi de cei cu cel mai înalt nivel de insignă, şi în final alfabetic. După cum puteți ghici, ordinea contează de fapt, ca una inversă (`7`, `11` și `15`) realizează ceva complet diferit (sortează jocurile alfabetic mai întâi, și datorită faptului că numele jocurilor sunt unice, celelalte două sunt efectiv inutile). Majoritatea oamenilor vor folosi probabil doar o singură ordine din toate astea, dar în cazul în care vrei, poți sorta mai departe cu parametri în plus.

Also notice the word "try" in all above descriptions - the actual ASF order is heavily affected by selected **[cards farming algorithm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** and sorting will affect only results that ASF considers same performance-wise. De exemplu, în algoritmul `Simple` , selectat `Comenzile agricole` ar trebui respectate pe deplin în actuala sesiune agricolă (întrucât fiecare joc are aceeași valoare de performanță); în cazul în care în `Ordinul real al algoritmului Complex` este afectat cu câteva ore mai întâi, şi apoi sortat în conformitate cu `FarmingOrders`. Acest lucru va duce la rezultate diferite, deoarece jocurile cu timpul de joacă existent vor avea prioritate față de ceilalți, atât de eficient, ASF va prefera jocurile care au trecut deja de la `HoursUntilCardDrops` primul, şi doar apoi sortând aceste jocuri mai departe după `FarmingOrders`. De asemenea, de îndată ce ASF se retrage din jocuri deja umflate, va sorta lista de așteptare rămasă mai întâi cu ore (ceea ce va scădea timpul necesar pentru a lovi oricare dintre titlurile rămase la `OoursUntilCardDrops`). Therefore, this config property is only a **suggestion** that ASF will try to respect, as long as it doesn't affect performance negatively (in this case, ASF will always prefer farming performance over `FarmingOrders`).

Există, de asemenea, coada de aşteptare cu prioritate a agriculturii, care este accesibilă prin comanda `fq` **[de comenzi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Dacă este folosit, ordinea de producție reală este sortată în primul rând după performanță, apoi după coada de creștere, și în final după `FarmingOrders`.

---

### `Preferințe agricole`

`bat steagurile` cu valoarea implicită de `0`. Această proprietate definește comportamentul ASF legat de agricultură și este definită după cum urmează:

| Valoare | Nume                           |
| ------- | ------------------------------ |
| 0       | Nimic                          |
| 1       | FarmarePausedByImplicit        |
| 2       | ÎnchidereOnFarmingFinalizat    |
| 4       | SendOnFarmingFinalizat         |
| 8       | Prioritate agricolăDoar        |
| 16      | IgnorabileJocuri               |
| 32      | Omitere Jocuri                 |
| 64      | ActiveazăRiskyCardsDescoperire |
| 256     | AutoUnpackBoosterPacks         |

Vă rugăm să rețineți că această proprietate este câmpul `steag` , prin urmare este posibil să alegeți orice combinație de valori disponibile. Vezi **[harta json](#json-mapping)** dacă vrei să afli mai multe. Nu activarea steagurilor duce la opțiunea `None`.

Toate opțiunile sunt descrise mai jos.

`FarmingPausedByImplicit` definește starea inițială a modulului `CardsFermier`. În mod normal, botul va porni automat agricultura când a început, fie din cauza comenzii `Activat` sau `începe cu comanda`. Using `FarmingPausedByDefault` can be used if you want to manually `resume` automatic farming process, for example because you want to use `play` all the time and never use automatic `CardsFarmer` module - this works exactly the same as `pause` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

`ShutdownOnFarmingFined` vă permite să închideți botul odată ce a terminat agricultura. În mod normal, ASF „ocupă” un cont pentru ca procesul să fie activ în întregime. Când se face cont dat cu agricultura, ASF verifică periodic (la fiecare `IdleFarmingPeriod` ), dacă între timp au fost adăugate probabil noi jocuri cu abur, astfel încât să poată relua activitatea agricolă a contului respectiv, fără a fi nevoie să repornească procesul. Acest lucru este util pentru majoritatea persoanelor, deoarece ASF poate relua automat agricultura atunci când este necesar. Cu toate acestea, poate doriţi să opriţi procesul atunci când contul dat este complet cultivat, puteţi obţine acest lucru folosind acest steag. Când este activat, ASF va continua să se deconecteze atunci când contul este complet crescut, ceea ce înseamnă că nu va mai fi verificat periodic sau ocupat. Ar trebui să te decizi dacă preferi ca ASF să lucreze la un anumit exemplu de bot pentru tot timpul, sau dacă poate că ASF ar trebui să înceteze atunci când se realizează procesul agricol.

Această opțiune are sens să fie combinată cu `ShutdownIfPosible`, așa că atunci când toate conturile sunt oprite, ASF se va închide, de asemenea, aşezarea maşinii în repaus, permiţându-vă să programaţi alte acţiuni, cum ar fi somnul sau oprirea în acelaşi moment al ultimului card de picurare.

`SendOnFarmingFined` vă permite să trimiteți automat comerțul cu aburi, conținând tot ce este cultivat până la acest punct către utilizatorul cu permisiunea `Master` , care este foarte convenabil dacă nu vrei să te deranjezi cu tranzacționarea. Această opțiune funcționează la fel ca comanda `loot` , Prin urmare, aveți în vedere faptul că necesită un utilizator cu setul de permisiuni `Master` , este posibil să aveți nevoie și de un `SteamTradeToken`valabil, precum și utilizarea unui cont care este eligibil pentru tranzacționare în primul rând. În plus față de inițierea lui `loot` după finalizarea fermei agricole, ASF va iniția, de asemenea, `loot` pentru fiecare notificare de articole noi (atunci când nu este în agricultură), și după finalizarea fiecărei tranzacții care are ca rezultat elemente noi (întotdeauna) atunci când această opțiune este activă. Acest lucru este util în special pentru "transmiterea" produselor primite de la alte persoane către contul nostru. De obicei vei dori să folosești **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** împreună cu această caracteristică, deși nu este o cerință dacă intenționați să gestionați manual confirmările 2FA în timp util.

`FarmPriorityQueueOnly` definește dacă ASF ar trebui să ia în considerare doar aplicațiile de agricultură automată pe care le-ați adăugat la lista de populație agricolă de prioritate disponibilă cu `fq` **[comenzile](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Când această opțiune este activată, ASF va sări peste toate `appID-urile` care lipsesc din listă, îți permite efectiv să culegi jocuri cherry-pick pentru farmarea automată ASF. Țineți cont de faptul că dacă nu ați adăugat niciun joc la coadă, ASF va acționa ca și cum nu ar fi nimic de cultivat în contul dvs.

`SkipRefundableGames` definește dacă ASF ar trebui să sară peste jocurile care sunt încă rambursabile din agricultura automată. Un joc rambursabil este un joc pe care l-ai cumpărat în ultimele 2 săptămâni prin Steam Store și care nu a jucat mai mult de 2 ore încă, conform afirmaţiei de la **[Restituiri Steam](https://store.steampowered.com/steam_refunds)** pagină. ASF ignoră implicit politica de restituire a Steam în întregime şi exploatează totul, aşa cum se aşteaptă majoritatea oamenilor. Cu toate acestea, poți folosi acest steag dacă vrei să te asiguri că ASF nu va ferma nici unul din jocurile tale rambursabile prea curând, permiteți-vă să evaluați singur acele jocuri și să le rambursați, dacă este necesar, fără a vă face griji că ASF afectează negativ timpul de joc. Te rugăm să reții că dacă activezi această opțiune, atunci jocurile pe care le-ai cumpărat din Magazinul Steam nu vor fi cultivate de ASF timp de până la 14 zile de la data răscumpărării, care nu va arăta ca nimic pentru fermă dacă contul tău nu are nimic altceva.

`SkipUnplayedGames` definește dacă ASF ar trebui să sară peste jocurile pe care nu le-ați lansat încă. Jocul nejucat în acest context înseamnă că nu ai exact timpul de joacă înregistrat pe Steam. Dacă folosești acest steag, atunci astfel de jocuri vor fi omise până când Steam va înregistra timpul de joacă pentru ele. Acest lucru îți permite să controlezi mai bine care jocuri ASF sunt eligibile pentru fermă, sărindu-le pe cele pe care nu ai avut nicio șansă să le încerci încă, păstrarea funcțiilor Steam selectate mai utile - cum ar fi sugerarea unor jocuri nejucate de jucat.

`ActiveRiskyCardsDiscovery` permite o rezervă suplimentară care se declanșează atunci când ASF nu poate încărca una sau mai multe pagini de insigne și, prin urmare, nu poate găsi jocurile disponibile pentru agricultură. În special, unele conturi cu o cantitate mare de cărți aruncate ar putea cauza o situație în care paginile de insigne de încărcare nu mai sunt posibile (din cauza cheltuielilor generale), și aceste conturi sunt imposibile pentru agricultură doar pentru că nu putem încărca informația bazată pe care putem începe procesul. Pentru acele cazuri superficiale, această opțiune permite utilizarea unui algoritm alternativ, care utilizează o combinație de propulsoare posibilă pentru a ambarcațiuni și ambalaje de detonare pentru care este eligibil contul, pentru a găsi eventuale jocuri disponibile de inactiv, să cheltuiască apoi o cantitate excesivă de resurse pentru verificarea şi preluarea informaţiilor solicitate; și încercând să înceapă procesul de producție pe baza unui număr limitat de date și informații pentru a ajunge în cele din urmă la o situație în care pagina încărcată cu insignă și vom putea folosi abordarea normală. Vă rugăm să rețineți că, atunci când această rezervă este utilizată, ASF funcționează doar cu date limitate, prin urmare, este absolut normal ca ASF să găsească mult mai puține picături decât în realitate - alte picături vor fi găsite în etapa ulterioară a procesului agricol.

Această opțiune se numește "riscantă" dintr-un motiv foarte întemeiat - este extrem de lentă și necesită o cantitate semnificativă de resurse (inclusiv cereri de rețea) pentru operare, prin urmare este **nu recomandă** să fie activat, şi în special pe termen lung. Ar trebui să folosiți această opțiune numai dacă ați stabilit anterior că contul dvs. suferă de incapacitatea de a încărca paginile insigne și ASF nu pot funcționa pe ele, nu se încarcă întotdeauna informațiile necesare pentru începerea procesului. Chiar dacă am face tot posibilul pentru a optimiza procesul cât mai mult posibil, este încă posibil ca această opțiune să se răstoarne și ar putea cauza rezultate nedorite, cum ar fi interdicții temporare și poate chiar permanente din partea Steam pentru a trimite prea multe cereri și pentru a provoca cheltuieli suplimentare pe serverele Steam. Prin urmare, vă avertizăm anticipat și vă oferim această opțiune fără garanții, o folosiți pe propriul risc.

`AutoUnpackBoosterPacks` va dezîmpacheta automat toate pachetele de rapel după primirea notificării articolelor noi. Acest lucru vă va permite să achiziționați imediat picături suplimentare cu cardul, ceea ce ar putea fi un scenariu dorit, în special în combinație cu alte opțiuni (e. . `SteamTradeMatcher` sau `CompleteTypesToSend`).

---

### `GamesPlayedWhileIdle`

`ImmutableHashSet<uint>` tip cu valoarea implicită a fi goală. Dacă ASF nu are nimic de exploatat, poate juca în schimb jocurile de abur specificate (`appIDs`). Jucarea jocurilor în acest fel măreşte "orele jucate" ale acelor jocuri, dar nimic altceva în afara ei. In order for this feature to work properly, your Steam account **must** own a valid license to all the `appIDs` that you specify here, this includes F2P games as well. Această caracteristică poate fi activată în același timp cu `CustomGamePlayedWhileIdle` pentru a juca jocurile selectate în timp ce se afișează starea personalizată în rețeaua Steam, dar în acest caz, ca în cazul `CustomGamePlayedWhileFarming` , ordinea efectivă de afișare nu este garantată. Te rugăm să reții că Steam permite ASF să redea doar până la `32` total de aplicații `` . de aceea poți pune la fel de multe jocuri în această proprietate.

---

### `Tipul de gamingDeviceType`

`ushort` tip cu valoarea implicită `1`. Această proprietate poate activa unele funcții online suplimentare pe platforma Steam și este definită mai jos:

| Valoare | Nume          | Descriere                         |
| ------- | ------------- | --------------------------------- |
| 1       | Standardizare | Fără mod special, implicit        |
| 544     | SteamPagină   | Prezenti el insusi ca punte Steam |

Baza `EGamingDeviceType` pe care se bazează această proprietate include mai multe valori disponibile, Cu toate acestea, după cunoştinţele noastre, acestea nu au niciun efect începând de astăzi, prin urmare au fost reduse din punctul de vedere al vizibilităţii.

Dacă nu sunteți sigur cum să setați această proprietate, lăsați-o cu valoarea implicită de `1`.

---

### `Ore UntilCardDrops`

`byte` tip cu valoarea implicită de `3`. Această proprietate definește dacă contul are un card restricționat și dacă da, pentru câte ore inițiale inițiale. Restricționat card picături înseamnă că contul nu primește nici un card de la jocul dat până când jocul nu este jucat pentru cel puțin `HoursUntilCardDrops` ore. Din păcate nu există o cale magică de a detecta asta, așa că ASF se bazează pe tine. Această proprietate afectează **[carduri de agricultor algoritmul](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** care vor fi utilizate. Stabilirea corectă a acestei proprietăți va maximiza profiturile și va minimiza timpul necesar pentru ca cardurile să fie cultivate. Amintește-ți că nu există niciun răspuns evident dacă ar trebui să folosești o valoare sau alta, deoarece aceasta depinde pe deplin de contul tău. Se pare că vechile conturi care nu au solicitat niciodată rambursarea au renunțat la o sumă nerestricționată de carduri, astfel încât să folosească o valoare de `0`, în timp ce conturile noi și cei care au solicitat rambursarea au restricționat reducerea numărului de carduri cu o valoare de `3`. Acest lucru este însă doar teoretic și nu ar trebui să fie considerat în regulă. Valoarea implicită pentru această proprietate a fost setată pe baza "mai puțin rău" și a majorității cazurilor de utilizare.

---

### `Tipuri Lootable`

`ImmutableHashSet<byte>` tip cu valoarea implicită de `1, 3, 5` tipuri de elemente Steam. Această proprietate definește comportamentul ASF la jefuire - ambele manuale, folosind comanda **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, precum și una automată, prin una sau mai multe proprietăți de configurare. ASF se va asigura că numai elementele de la `LootableTypes` vor fi incluse într-o ofertă de tranzacționare, prin urmare, această proprietate vă permite să alegeți ceea ce doriți să primiți într-o ofertă de tranzacționare care vă este trimisă.

| Valoare | Nume               | Descriere                                                                          |
| ------- | ------------------ | ---------------------------------------------------------------------------------- |
| 0       | Necunoscut         | Fiecare tip care nu se potrivește cu niciunul dintre cele de mai jos               |
| 1       | BoosterPack        | Pachet de rapel care conține 3 carduri aleatorii dintr-un joc                      |
| 2       | Emoticon           | Emoticon de utilizat în Steam Chat                                                 |
| 3       | FoilTradingCard    | Variantă de folie `TradingCard`                                                    |
| 4       | ProfileFundal      | Profil fundal folosit pe profilul tău Steam                                        |
| 5       | TradingCard        | Card de tranzacționare cu aburi, folosit pentru meșteșugirea insignelor (non-foil) |
| 6       | SteamGems          | Bijuterii cu abur utilizate pentru meşteşuguri de arsuri, inclusiv saci            |
| 7       | SaleElement        | Articole speciale acordate în timpul vânzărilor Steam                              |
| 8       | Consumabil         | Articole consumabile speciale care dispar după folosire                            |
| 9       | ProfilModifier     | Elemente speciale care pot modifica aspectul profilului Steam                      |
| 10      | Sticker            | Articole speciale care pot fi folosite pe Steam chat                               |
| 11      | ChatEffect         | Articole speciale care pot fi folosite pe Steam chat                               |
| 12      | Fundal MiniProfile | Fundal special pentru profilul Steam                                               |
| 13      | AvatarProfileCadru | Cadru special de avatar pentru profilul Steam                                      |
| 14      | AnimatedAvatar     | Avatar special animat pentru profilul Steam                                        |
| 15      | Tastatură          | Piele de tastatură specială pentru puntea Steam                                    |
| 16      | StartupVideo       | Video de pornire special pentru puntea Steam                                       |

Vă rugăm să reţineţi că indiferent de setările de mai sus, ASF va cere doar **[Articole ale comunității Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` din 753, `context` din 6), astfel încât toate obiectele de joc, cadourile și de asemenea sunt excluse prin definiție din oferta comercială.

Setarea implicită ASF se bazează pe utilizarea cea mai frecventă a botului, cu jefuirea numai a pachetelor de rapel și a cardurilor de tranzacționare (inclusiv a foliilor). Proprietatea definită aici vă permite să modificaţi acest comportament în orice mod care vă satisface pe dumneavoastră. Vă rugăm să reţineţi că toate tipurile care nu sunt definite mai sus vor fi afişate ca tip `Necunoscut` , care este deosebit de important atunci când Valve eliberează un nou articol Steam, care va fi marcat și ca `Necunoscut` de ASF până când va fi adăugat aici (în versiunile viitoare). De aceea, în general, nu este recomandat să includeți `Unknown` type in your `LootableTypes`, dacă nu știi ce faci, și de asemenea înțelegeți că ASF va trimite întregul dvs. inventar într-o ofertă de tranzacționare dacă rețeaua Steam primește din nou defecțiune și raportează toate articolele dvs. ca `` Necunoscut . Sugestia mea puternică este de a nu include `Necunoscut` type în `LootableTypes`, chiar dacă te aștepți să lootezi totul (altele).

---

### `Mașină/Nume`

`șir` tip cu valoarea implicită `null`. ASF va utiliza această proprietate atunci când se conectează la rețeaua Steam, care poate fi folosit pentru personalizare în ceea ce privește modul exact de afișare a aburului ASF și a sesiunii, e. . la afișarea dispozitivelor care sunt în prezent înregistrate în **[aici](https://store.steampowered.com/account/authorizeddevices)**.

ASF oferă câteva variabile speciale pe care le poți folosi opțional în textul tău. `{0}` will be replaced by machine name as provided by your OS, `{1}` will be replaced by ASF's public identifier, while `{2}` will be replaced by ASF's version.

Dacă nu știi ce faci, ar trebui să o păstrezi cu valoarea implicită de `null`. În acest caz, ASF va decide intern cu privire la valoarea corectă, care este `{0} ({1}/{2})` începând de astăzi. Reţineţi că aceasta este doar o sugestie conform căreia reţeaua Steam poate sau nu să respecte pe deplin această situaţie.

---

### `Tipuri de potriviri`

`ImmutableHashSet<byte>` tip cu valoarea implicită de `5` tipuri de elemente Steam. Această proprietate definește tipurile de articole Steam cărora li se permite să li se potrivească când opțiunea `SteamMatcher` în `TradingPreferences` este activată. Tipurile sunt definite după cum urmează:

| Valoare | Nume               | Descriere                                                                          |
| ------- | ------------------ | ---------------------------------------------------------------------------------- |
| 0       | Necunoscut         | Fiecare tip care nu se potrivește cu niciunul dintre cele de mai jos               |
| 1       | BoosterPack        | Pachet de rapel care conține 3 carduri aleatorii dintr-un joc                      |
| 2       | Emoticon           | Emoticon de utilizat în Steam Chat                                                 |
| 3       | FoilTradingCard    | Variantă de folie `TradingCard`                                                    |
| 4       | ProfileFundal      | Profil fundal folosit pe profilul tău Steam                                        |
| 5       | TradingCard        | Card de tranzacționare cu aburi, folosit pentru meșteșugirea insignelor (non-foil) |
| 6       | SteamGems          | Bijuterii cu abur utilizate pentru meşteşuguri de arsuri, inclusiv saci            |
| 7       | SaleElement        | Articole speciale acordate în timpul vânzărilor Steam                              |
| 8       | Consumabil         | Articole consumabile speciale care dispar după folosire                            |
| 9       | ProfilModifier     | Elemente speciale care pot modifica aspectul profilului Steam                      |
| 10      | Sticker            | Articole speciale care pot fi folosite pe Steam chat                               |
| 11      | ChatEffect         | Articole speciale care pot fi folosite pe Steam chat                               |
| 12      | Fundal MiniProfile | Fundal special pentru profilul Steam                                               |
| 13      | AvatarProfileCadru | Cadru special de avatar pentru profilul Steam                                      |
| 14      | AnimatedAvatar     | Avatar special animat pentru profilul Steam                                        |
| 15      | Tastatură          | Piele de tastatură specială pentru puntea Steam                                    |
| 16      | StartupVideo       | Video de pornire special pentru puntea Steam                                       |

Desigur, tipurile pe care ar trebui să le utilizați pentru această proprietate includ de obicei doar `2`, `3`, `4` și `5`, ca și cum doar aceste tipuri sunt acceptate de STM. ASF include logica corectă pentru a descoperi raritatea obiectelor, prin urmare este sigur să se potrivească cu emoticoanele sau fundalurile, ca ASF va lua în considerare în mod corect numai acele elemente din același joc și tip, care au și aceeași raritate.

Te rugăm să reții că **ASF nu este un bot de tranzacționare** și **NU va avea grijă de prețul pieței**. Dacă nu considerați elemente de aceeași raritate din același set ca și preț, atunci această opțiune NU este pentru dvs. Vă rugăm să evaluați de două ori dacă înțelegeți și sunteți de acord cu această declarație înainte de a decide să schimbați această setare.

Dacă nu știi ce faci, ar trebui să îl păstrezi cu valoarea implicită de `5`.

---

### `Steaguri Online`

`ushort flags` tip cu valoarea implicită `0`. Această proprietate funcționează ca supliment la **[`OnlineStatus`](#onlinestatus)** și specifică caracteristicile de prezență online suplimentare anunțate pentru rețeaua Steam. Necesită **[`OnlineStatus`](#onlinestatus)** altul decât `Offline`, şi este definit ca mai jos:

| Valoare | Nume                 | Descriere                                               |
| ------- | -------------------- | ------------------------------------------------------- |
| 0       | Nimic                | Nu sunt steaguri de prezență online speciale, implicit  |
| 2       | InJoinableGame       | Clientul este în joc alăturat                           |
| 8       | DistanțăPlayÎmpreună | Clientul folosește sesiunea de joc la distanță împreună |
| 256     | ClientTypeWeb        | Clientul folosește interfața web                        |
| 512     | ClientTypeMobil      | Clientul folosește aplicația pentru mobil               |
| 1024    | ClientTypeTenfoot    | Clientul folosește o imagine mare                       |
| 2048    | ClientTypeVR         | Clientul utilizează setul cu cască VR                   |

Vă rugăm să rețineți că această proprietate este câmpul `steag` , prin urmare este posibil să alegeți orice combinație de valori disponibile. Vezi **[harta json](#json-mapping)** dacă vrei să afli mai multe. Nu activarea steagurilor duce la opțiunea `None`.

`EPersonaStateFlag` pe care se bazează această proprietate include mai multe steaguri disponibile, Cu toate acestea, după cunoştinţele noastre, acestea nu au niciun efect începând de astăzi, prin urmare au fost reduse din punctul de vedere al vizibilităţii.

Dacă nu sunteți sigur cum să setați această proprietate, lăsați-o cu valoarea implicită de `0`.

---

### `Status "Online"`

`byte` tip cu valoarea implicită de `1`. Această proprietate specifică statutul de comunitate Steam cu care bot-ul va fi anunțat după autentificarea în rețeaua Steam. În prezent puteţi alege una dintre stările de mai jos:

| Valoare | Nume           |
| ------- | -------------- |
| 0       | Deconectat     |
| 1       | Conectat       |
| 2       | Ocupat         |
| 3       | Plecat         |
| 4       | Amânare        |
| 5       | LookingToTrade |
| 6       | CăutareToPlay  |
| 7       | Invizibil      |

`Starea offline` este extrem de utilă pentru conturile primare. După cum ar trebui să știți, cultivarea unui joc arată de fapt starea ta de aburi ca "Joaca joacă: XXX", care pot induce în eroare prietenii tăi, să-i încurci că joci un joc în timp ce de fapt doar faci ferme. Folosind statutul `Offline` rezolvă această problemă - contul tău nu va fi niciodată afișat ca "în joc" când ești cartonașe de abur cu ASF. Acest lucru este posibil datorită faptului că ASF nu trebuie să se alăture Comunității Steam pentru a funcționa în mod corespunzător, așa că de fapt jucăm acele jocuri, conectate la rețeaua Steam, dar fără să ne anunțăm prezența online. Țineți cont de faptul că jocurile jucate folosind starea offline vor conta în continuare pe timpul tău de joacă și vor arăta ca "joacă recent" pe profilul tău.

În plus, această funcție este, de asemenea, importantă dacă doriți să primiți notificări și mesaje necitite atunci când ASF rulează, fără a ţine clientul Steam deschis în acelaşi timp. Acest lucru se datorează faptului că ASF acționează ca un client de Steam însuși, și că ASF și-ar dori sau nu ASF, Steam transmite aceste mesaje și alte evenimente. Aceasta nu este o problemă dacă aveți atât ASF cât și propriul dvs. client Steam, deoarece ambii clienți primesc exact aceleași evenimente. Cu toate acestea, dacă se execută doar ASF, rețeaua Steam ar putea marca anumite evenimente și mesaje ca fiind „livrate”, în ciuda faptului că clientul tău tradițional Steam nu îl primește din cauza faptului că nu este prezent. Statutul offline rezolvă și această problemă, deoarece ASF nu este luat niciodată în considerare pentru niciun eveniment al comunității în acest caz, astfel încât toate mesajele necitite și alte evenimente vor fi marcate în mod corespunzător ca necitite atunci când vă întoarceți.

It's important to note that ASF running on `Offline` mode will **not** be able to receive commands in usual Steam chat way, as the chat, as well as entire community presence is in fact, entirely offline. O soluție la această problemă este folosind modul `Invizibil` care funcționează într-un mod similar (nu expune statusul), dar păstrează capacitatea de a primi și de a răspunde la mesaje (astfel și posibilitatea de a respinge notificările și mesajele necitite, astfel cum au fost menționate mai sus). `Modul` invizibil are cel mai bun sens pe conturile altora pe care nu vrei sa le expui (status-wise), dar încă mai poți trimite comenzi.

Cu toate acestea, există o singură captură cu modul `Invizibil` - nu merge bine cu conturile primare. Acest lucru se datorează faptului că **orice sesiune** Steam care este momentan online **expune** starea, chiar dacă ASF în sine nu este. This is caused by the current limitation/bug of the Steam network that isn't possible to be fixed on ASF side, so if you want to use `Invisible` mode you will also need to ensure that **all** other sessions to the same account use `Invisible` mode as well. Acesta va fi cazul conturilor de alt tip în care ASF este singura sesiune activă, dar în conturile primare vei prefera aproape întotdeauna să arăți ca `Online` prietenilor tăi, ascunderea doar a activității ASF, iar în acest caz modul `Invizibil` va fi complet inutil pentru dvs. (vă recomandăm să utilizaţi în schimb modul `Offline`). Să sperăm că această limitări/eroare va fi rezolvată în cele din urmă în viitor de către Valve, dar nu m-aș aștepta ca asta să se întâmple curând...

Dacă nu sunteți sigur cum să configurați această proprietate, este recomandat să utilizaţi o valoare de `0` (`Offline`) pentru conturile principale, și implicit `1` (`Online`) altfel.

---

### `Formatul parolei`

`octeți` tip cu valoarea implicită de `0` (`PlainText`). Această proprietate definește formatul de proprietate `SteamPassword` și acceptă în prezent valorile specificate în secțiunea **[de securitate](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**. Ar trebui să urmaţi instrucţiunile specificate acolo, pentru că va trebui să vă asigurați că proprietatea `SteamPassword` include într-adevăr parola în potrivirea cu `PasswordFormat`. Cu alte cuvinte, când schimbi `Parolă` atunci `SteamPassword` ar trebui să fie **deja** în acel format, nu doar să încerci să fii. Dacă nu știi ce faci, ar trebui să îl păstrezi cu valoarea implicită de `0`.

Dacă decideți să schimbați `Parola` unui bot care s-a logat deja la rețeaua Steam cel puțin o dată, este posibil să primești o eroare unică de decriptare la începutul următorului bot - acest lucru este cauzat de faptul că `PasswordFormat` este folosit și în ceea ce privește criptarea/decriptarea automată a proprietăților sensibile în `Bot. b Fișier bază de date`. Poți ignora în siguranță acea eroare, pentru că ASF va putea să se redreseze din această situație pe cont propriu. Cu toate acestea, dacă se întâmplă în mod constant, de exemplu la fiecare repornire, ar trebui investigat.

---

### `RenunțarePreferințe`

`bat steagurile` cu valoarea implicită de `0`. Această proprietate definește comportamentul ASF la răscumpărarea tastelor cd și este definită mai jos:

| Valoare | Nume                               | Descriere                                                                                                                                           |
| ------- | ---------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0       | Nimic                              | Nu există preferințe speciale de răscumpărare, implicit                                                                                             |
| 1       | Redirecționare                     | Formatează cheile indisponibile pentru a revendica alți roboți                                                                                      |
| 2       | Distribuire                        | Distribuie toate cheile între ei și alți boți                                                                                                       |
| 4       | KeepMissingGames                   | Păstrați tastele pentru (potențial) jocuri lipsă în timp ce înaintați, lăsându-le neutilizate                                                       |
| 8       | AssumeWalletKeyOnBadActivationCode | Presupuneți că tastele `BadActivationCode` sunt egale cu `CannotRedeemCodeFromClient`și, prin urmare, încercați să le răscumpărați ca chei portofel |

Vă rugăm să rețineți că această proprietate este câmpul `steag` , prin urmare este posibil să alegeți orice combinație de valori disponibile. Vezi **[harta json](#json-mapping)** dacă vrei să afli mai multe. Nu activarea steagurilor duce la opțiunea `None`.

`Transmiterea` va face ca botul să înainteze o cheie care nu este posibilă pentru a redenumi, conectat și conectat la un alt bot care lipsește acel joc (dacă este posibil pentru verificare). Cea mai comună situație este transmiterea către un alt bot care nu are acel joc anume prin jocul `AlreadyPurchased` , dar această opțiune acoperă și alte scenarii, ca `DoesNotOwnRequiredApp`, `RateLimited` sau `RestrictedCountry`.

`Distribuirea` va cauza botului să distribuie toate cheile primite între el și alți boți. Asta înseamnă că fiecare bot va primi o singură cheie din lot. De obicei, acest lucru este folosit doar când revendici mai multe chei pentru același joc, și vrei să le distribui în mod egal între roboți, spre deosebire de revendicarea cheilor pentru diferite jocuri. Această caracteristică nu are sens dacă răscumpărați o singură cheie într-o singură acțiune de tip `revendică` (deoarece nu există chei suplimentare pentru a fi distribuite).

`KeepMissingGames` va face ca botul să sară peste `Redirecționarea` când nu putem fi siguri dacă cheia care este răscumpărată este de fapt deținută de botul nostru, sau nu. Acest lucru înseamnă practic că `Redirecționarea` se va aplica tastele **doar** `Tastele` deja achiziționate, în loc să acopere și alte cazuri, cum ar fi `DoesNotOwnRequiredApp`, `RateLimited` sau `RestrictedCountry`. De obicei vrei să folosești această opțiune în contul principal, pentru a se asigura că cheile răscumpărate nu vor fi redirecționate mai departe în cazul în care botul tău de exemplu devine temporar `RateLimited`. După cum puteți ghici din descriere, acest câmp nu are niciun efect dacă `Redirecționarea` nu este activată.

`AssumeWalletKeyOnBadActivationCode` va cauza ca tastele `BadActivationCode` să fie tratate ca `CannotRedeemCodeFromClient`, și de aceea rezultă în ASF care încearcă să le revendice ca chei portofel. Acest lucru este necesar deoarece Steam ar putea anunța cheile portofelului ca `BadActivationCode` (nu `CannotRedeemCodeFromClient` așa cum a fost folosit), rezultând în ASF care nu încearcă niciodată să le revendice. Cu toate acestea, recomandăm **împotriva** folosind această preferință, deoarece va duce la încercarea ASF de a revendica fiecare cheie nevalidă ca cod portofel, rezultând un număr excesiv de cereri (potențial invalide) trimise serviciului Steam, cu toate consecințele potențiale. În schimb, îți recomandăm să folosești modul `ForceAssumeWalletKey` **[`redeem^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** în timp ce rămâi cu bună știință cheile portofelului, care va permite lucrările necesare numai atunci când este necesar, la nevoie.

Activând atât `Redirecționarea` cât și `Distributing` va adăuga funcția de distribuție peste una de redirecționare, care face ca ASF să încerce să revendice o cheie pentru toți roboții mai întâi (înainte) înainte de a trece la următorul (distribuția). De obicei vrei să folosești această opțiune doar când vrei `Redirecționarea`, dar cu un comportament modificat de comutare a bot-ului pe tasta utilizată, în loc de a merge în ordine cu fiecare cheie (care ar fi `Redirecționare` singură). Acest comportament poate fi benefic dacă știți că majoritatea sau chiar toate cheile sunt legate de același joc, pentru că în această situație `Redirecționarea` singur ar încerca să răscumpere totul mai întâi de la un singur bot (ceea ce are sens dacă cheile sunt pentru jocuri unice), și `Redirecționarea` + `Distribuire` va comuta botul pe următoarea cheie, „distribuirea” sarcinii de a recupera o nouă cheie către un alt bot decât cel inițial (care are sens dacă cheile sunt pentru același joc; săriți peste o încercare inutilă per tastă).

Ordinea boților reali pentru toate scenariile de răscumpărare este alfabetică, cu excepția boților care nu sunt disponibili (nu sunt conectați, opriți sau similari). Te rugăm să reții că există o limită de oră pe IP și pe cont pentru rambursarea încercărilor, iar fiecare răscumpărare nu s-a încheiat cu `OK` contribuie la încercările eșuate. ASF va face tot posibilul pentru a reduce la minimum numărul de erori `deja achiziționate` , de ex. încercând să evite transmiterea unei chei către un alt bot care deține deja acel joc, dar nu este întotdeauna garantat că funcţionează datorită modului în care Steam manipulează licenţele. Folosind răscumpărarea steagurilor cum ar fi `Redirecționarea` sau `Distribuire` întotdeauna vă va crește probabilitatea să atingeți `RateLimited`.

De asemenea, aveți în vedere faptul că nu puteți redirecționa sau distribui chei către boții la care nu aveți acces. Acest lucru ar trebui să fie evident. dar asigură-te că ești cel puțin `Operatorul` al tuturor roboților pe care vrei să îi incluzi în procesul tău de răscumpărare, de exemplu cu `status ASF` **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `TelecomunicațieComunicare`

`bat steagurile` cu valoarea implicită `3`. Această proprietate definește comportamentul per-bot ASF atunci când vine vorba de comunicarea cu servicii de la distanță și servicii de terță parte și este definită ca mai jos:

| Valoare | Nume       | Descriere                                                                                                                                                                                                                                                        |
| ------- | ---------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0       | Nimic      | Nicio comunicare de terță parte permisă, care face caracteristicile ASF selectate inutilizabile                                                                                                                                                                  |
| 1       | SteamGroup | Permite comunicarea cu **[grupul Steam al ASF](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                     |
| 2       | Publicare  | Permite comunicarea cu **[listarea STM a ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** pentru a fi listată, dacă utilizatorul a activat și `SteamTradeMatcher` în **[`TradingPreferences`](#tradingpreferences)** |

Vă rugăm să rețineți că această proprietate este câmpul `steag` , prin urmare este posibil să alegeți orice combinație de valori disponibile. Vezi **[harta json](#json-mapping)** dacă vrei să afli mai multe. Nu activarea steagurilor duce la opțiunea `None`.

Această opțiune nu include toate comunicările cu terți oferite de ASF, doar cele care nu sunt implicite de alte setări. De exemplu, dacă ați activat actualizările automate ale ASF, ASF va comunica atât cu GitHub (pentru descărcări) cât și cu serverul nostru (pentru verificarea cifrei), conform configurației. De asemenea, activând `Potrivire` în **[`TradingPreferences`](#tradingpreferences)** implică comunicarea cu serverul nostru pentru a prelua boții listați, care este necesară pentru această funcționalitate.

Mai multe explicații cu privire la acest subiect sunt disponibile în secțiunea **[de comunicare la distanță](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

### `SendTradePeriod`

`octeți` tip cu valoarea implicită de `0`. Această proprietate funcționează foarte asemănător cu `SendOnFarmingFined` preferințe în `Ferma Preferințe`, cu o singură diferenţă - în loc să se trimită comerţul atunci când se realizează agricultura, îi putem trimite și la fiecare `SendTradePeriod` ore, indiferent de cât de mult a mai rămas pentru fermă. This is useful if you want to `loot` your alt accounts on usual basis instead of waiting for it to finish farming. Valoarea implicită de `0` dezactivează această caracteristică, dacă vrei ca bot-ul să îți trimită tranzacția. . în fiecare zi, ar trebui să pui `24` aici.

De obicei vei dori să folosești **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** împreună cu această caracteristică, deși nu este o cerință dacă intenționați să gestionați manual confirmările 2FA în timp util. Dacă nu sunteți sigur cum să setați această proprietate, lăsați-o cu valoarea implicită de `0`.

---

### `Conectare la SteamLogin`

`șir` tip cu valoarea implicită `null`. Aceasta proprietate defineste autentificarea cu aburi - cea pe care o folosesti pentru a te conecta la abur. În plus față de definirea aburului, conectați-vă aici, poți păstra de asemenea valoarea implicită de `null` dacă vrei să introduci autentificarea cu aburi la fiecare pornire ASF în loc să o pui în config. Acest lucru poate fi util pentru tine dacă nu vrei să salvezi datele sensibile în fișierul de configurare.

---

### `SteamMasterClanID`

`ulong` tip cu valoarea implicită `0`. Această proprietate definește steamID-ul grupului de aburi la care bot-ul ar trebui să se alăture automat, inclusiv chat-ul de grup. Puteţi verifica steamID al grupului dvs navigând la pagina **[](https://steamcommunity.com/groups/archiasf)**, apoi adăugaţi `/memberslistxml? ml=1` până la finalul link-ului, astfel încât link-ul va arăta ca **[acest](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. Apoi poți obține steamID al grupului tău din rezultat, este `<groupID64>` tag. În exemplul de mai sus ar fi `103582791440160998`. În plus față de încercarea de a se alătura grupului dat la pornire, botul va accepta automat invitații din grup în acest grup, care vă permite să vă invitați robotul manual în cazul în care grupul dvs. are statut privat. Dacă nu aveți niciun grup dedicat boților dvs., ar trebui să păstrați această proprietate cu valoarea implicită de `0`.

---

### `SteamParentalCode`

`șir` tip cu valoarea implicită `null`. Aceasta proprietate defineste codul PIN parental de aburi. ASF necesită acces la resurse protejate de abur, prin urmare dacă folosești această funcție, trebuie să furnizaţi ASF cu PIN pentru deblocare parentală, astfel încât să poată funcţiona normal. Valoarea implicită a lui `null` înseamnă că nu este necesar un PIN de Steam parental pentru a debloca acest cont, şi asta e probabil ce vrei dacă nu foloseşti funcţionalitatea părintească cu aburi.

În circumstanțe limitate, ASF este, de asemenea, în măsură să genereze chiar un cod parental valid Steam deşi acest lucru necesită o cantitate excesivă de resurse din OS, precum şi timp suplimentar pentru finalizare, ca să nu mai menţionăm că nu este garantat că reuşeşte, de aceea recomandăm să nu se bazeze pe această caracteristică și să puneți un `SteamParentalCode` în configurația pentru ca ASF să o folosească. Dacă ASF determină că este necesar PIN, și nu va putea genera unul singur, vă va cere să îl introduceți.

---

### `Parolă SteamPassword`

`șir` tip cu valoarea implicită `null`. Aceasta proprietate defineste parola de abur - cea pe care o folosesti pentru autentificarea in abur. În plus față de definirea parolei abur, aici, poți păstra și valoarea implicită de `null` dacă dorești să introduci parola de Steam la fiecare pornire ASF în loc să o pui în config. Acest lucru poate fi util pentru tine dacă nu vrei să salvezi datele sensibile în fișierul de configurare.

---

### `SteamTradeken`

`șir` tip cu valoarea implicită `null`. Când ai botul pe lista ta de prieteni, atunci robotul îți poate trimite imediat o tranzacție fără să îți facă griji cu privire la token-ul comercial, prin urmare puteți lăsa această proprietate la valoarea implicită de `null`. Dacă totuși decizi să NU ai botul pe lista ta de prieteni, atunci va trebui să generați și să completați un token de tranzacționare, deoarece utilizatorul la care acest bot așteaptă să trimită tranzacții. Cu alte cuvinte, această proprietate ar trebui să fie completată cu un token de tranzacționare al contului care este definit cu permisiunea de la `Master` în `SteamUserPermissions` din **acest caz** bot.

Pentru a-ți găsi tokenul, ca utilizator conectat cu permisiunea `Master` , Navigați **[aici](https://steamcommunity.com/my/tradeoffers/privacy)** și aruncați o privire la adresa URL comercială. Tokenul pe care îl căutăm este alcătuit din 8 caractere după `&token=` parte din URL-ul tău de tranzacționare. Ar trebui să copiați și să puneți aceste 8 caractere aici, ca `SteamTradeToken`. Nu include întregul URL de tranzacționare, nici `&token=` , doar tokenul în sine (8 caractere).

---

### `SteamUserPermisiuni`

`ImmutableDictionary<ulong, byte>` tip cu valoarea implicită de a fi goală. This property is a dictionary property which maps given Steam user identified by his 64-bit steam ID, to `byte` number that specifies his permission in ASF instance. Permisiunile botului disponibile în ASF sunt definite ca:

| Valoare | Nume              | Descriere                                                                                                                                                                                                                                                                        |
| ------- | ----------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0       | Nimic             | Fără permisiune specială, aceasta este în principal o valoare de referinţă care este atribuită ID-urilor de abur care lipsesc în acest dicţionar - nu este nevoie să definim pe nimeni cu această permisiune                                                                     |
| 1       | Partajare familie | Oferă acces minim pentru utilizatorii de partajare familială. (Automatic Translation) Încă o dată, aceasta este în principal o valoare de referință deoarece ASF este capabilă să descopere automat ID-urile cu aburi pe care ni le-am permis pentru a folosi biblioteca noastră |
| 2       | Operator          | Oferă acces de bază la anumite instanțe ale roboților, adăugând în principal licențe și taste de revendicare                                                                                                                                                                     |
| 3       | Maestru           | Oferă acces deplin la o anumită instanță de bot                                                                                                                                                                                                                                  |

Pe scurt, această proprietate vă permite să gestionați permisiunile pentru anumiți utilizatori. Permisiunile sunt importante în principal pentru accesul la comenzile ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, dar și pentru a permite multe funcții ASF, cum ar fi acceptarea de tranzacții. De exemplu, poate doriţi să vă setaţi propriul cont ca `Master`, și oferă lui `Operator` acces la 2-3 dintre prietenii tăi astfel încât aceștia să poată răscumpăra cu ușurință chei pentru botul tău cu ASF, în timp ce **nu** este eligibil. . pentru a o opri. Mulțumită faptului că poți atribui cu ușurință permisiuni anumitor utilizatori și să îi lași să folosească botul pentru unele specificate de grad.

Îți recomandăm să setezi un singur utilizator ca `Master`, și orice sumă pe care o dorești ca `Operatori` și mai jos. În timp ce din punct de vedere tehnic este posibil să setezi mai multe `Masters` și ASF va funcționa corect cu acestea, de exemplu, prin acceptarea tuturor tranzacțiilor trimise către bot, ASF va utiliza doar unul dintre acestea (cu cel mai scăzut ID cu abur) pentru fiecare acțiune care necesită un singur țint; de exemplu o cerere `loot` așa, de asemenea, proprietăți precum `SendOnFarmingFining` în `Preferințe agricole` sau `SendTradePeriod`. Dacă înțelegi perfect aceste limitări, în special faptul că cererea `loot` va trimite întotdeauna articole la `Master` cu cel mai mic ID cu abur, indiferent de maestrul `` care a executat efectiv comanda, apoi poți defini mai mulți utilizatori cu permisiunea `Master` aici, dar încă recomandăm o singură schemă de maestru.

Este frumos să notezi că mai există încă o permisiune `Proprietarul` , care este declarat ca `SteamOwnerID` proprietate globală de configurare. Nu puteți atribui permisiunea `Proprietarului` nimănui aici, ca `SteamUserPermissions` proprietate definește doar permisiunile care sunt legate de zona botului și nu ASF ca un proces. Pentru sarcinile legate de bot, `SteamOwnerID` este tratat ca `Master`, astfel încât definirea `SteamOwnerID` aici nu este necesară.

---

### `TradeCheckPeriod`

`byte` tip cu valoarea implicită de `60`. În mod normal, ASF se ocupă de ofertele de tranzacționare primite imediat după primirea notificării despre una, dar uneori din cauza Steam nu poate face asta în acel moment, și astfel de oferte de tranzacționare rămân ignorate până la următoarea notificare a tranzacției sau la repornirea botului, care poate duce la anularea unor tranzacții sau la indisponibilitatea unor articole în acel moment ulterior. Dacă acest parametru este setat la o valoare non-zero, ASF va verifica în plus pentru astfel de tranzacții restante la fiecare `TradeCheckPeriod` minute. Valoarea implicită este selectată cu echilibru între cereri suplimentare pentru serverele de Steam și pierderea tranzacțiilor primite. Cu toate acestea, dacă pur și simplu folosești ASF pentru a cultiva carduri și nu intenționezi să procesezi automat orice tranzacție primită, îl puteţi seta la `0` pentru a dezactiva această caracteristică complet. Pe de altă parte, dacă botul tău participă la public [ASF listare STM](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) sau oferă alte servicii automate ca un bot de tranzacționare, poate doriți să reduceți acest parametru la `15` minute, pentru a procesa toate tranzacțiile în timp util.

---

### `TradingPreferences`

`bat steagurile` cu valoarea implicită de `0`. Această proprietate definește comportamentul ASF atunci când este în tranzacționare și este definită după cum urmează:

| Valoare | Nume                | Descriere                                                                                                                                                                                                                              |
| ------- | ------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0       | Nimic               | Fără preferințe speciale de tranzacționare, implicit                                                                                                                                                                                   |
| 1       | Acceptări           | Acceptă tranzacții în care nu pierdem nimic                                                                                                                                                                                            |
| 2       | SteamTradeMatcher   | Participă cu ușurință la tranzacțiile de tip **[STM](https://www.steamtradematcher.com)**. Vizitați **[tranzacționare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** pentru mai multe informații    |
| 4       | Potrivire           | Necesită ca `SteamTradeMatcher` să fie setat, și în combinație cu acesta - acceptă, de asemenea, tranzacțiile rele în plus față de cele bune și neutre                                                                                 |
| 8       | DontAcceptBotTrades | Nu acceptă automat tranzacțiile `loot` din alte instanțe ale botului                                                                                                                                                                   |
| 16      | Potrivire           | Participă activ la tranzacții de tip **[STM](https://www.steamtradematcher.com)**. Vizitați **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** pentru mai multe informații |

Vă rugăm să rețineți că această proprietate este câmpul `steag` , prin urmare este posibil să alegeți orice combinație de valori disponibile. Vezi **[harta json](#json-mapping)** dacă vrei să afli mai multe. Nu activarea steagurilor duce la opțiunea `None`.

Pentru explicații suplimentare privind logica de tranzacționare ASF și descrierea fiecărui steag disponibil, vă rugăm să vizitați secțiunea **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**.

---

### `Tipuri transferabile`

`ImmutableHashSet<byte>` tip cu valoarea implicită de `1, 3, 5` tipuri de elemente Steam. Această proprietate definește tipurile de elemente Steam care vor fi luate în considerare pentru a fi transferate între boți, în timpul transferului `` **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. ASF se va asigura că numai elementele de la `TransferableTypes` vor fi incluse într-o ofertă de tranzacționare, prin urmare, această proprietate vă permite să alegeți ceea ce doriți să primiți într-o ofertă de tranzacționare care este trimisă unuia dintre roboții dvs.

| Valoare | Nume               | Descriere                                                                          |
| ------- | ------------------ | ---------------------------------------------------------------------------------- |
| 0       | Necunoscut         | Fiecare tip care nu se potrivește cu niciunul dintre cele de mai jos               |
| 1       | BoosterPack        | Pachet de rapel care conține 3 carduri aleatorii dintr-un joc                      |
| 2       | Emoticon           | Emoticon de utilizat în Steam Chat                                                 |
| 3       | FoilTradingCard    | Variantă de folie `TradingCard`                                                    |
| 4       | ProfileFundal      | Profil fundal folosit pe profilul tău Steam                                        |
| 5       | TradingCard        | Card de tranzacționare cu aburi, folosit pentru meșteșugirea insignelor (non-foil) |
| 6       | SteamGems          | Bijuterii cu abur utilizate pentru meşteşuguri de arsuri, inclusiv saci            |
| 7       | SaleElement        | Articole speciale acordate în timpul vânzărilor Steam                              |
| 8       | Consumabil         | Articole consumabile speciale care dispar după folosire                            |
| 9       | ProfilModifier     | Elemente speciale care pot modifica aspectul profilului Steam                      |
| 10      | Sticker            | Articole speciale care pot fi folosite pe Steam chat                               |
| 11      | ChatEffect         | Articole speciale care pot fi folosite pe Steam chat                               |
| 12      | Fundal MiniProfile | Fundal special pentru profilul Steam                                               |
| 13      | AvatarProfileCadru | Cadru special de avatar pentru profilul Steam                                      |
| 14      | AnimatedAvatar     | Avatar special animat pentru profilul Steam                                        |
| 15      | Tastatură          | Piele de tastatură specială pentru puntea Steam                                    |
| 16      | StartupVideo       | Video de pornire special pentru puntea Steam                                       |

Vă rugăm să reţineţi că indiferent de setările de mai sus, ASF va cere doar **[Articole ale comunității Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` din 753, `context` din 6), astfel încât toate obiectele de joc, cadourile și de asemenea sunt excluse prin definiție din oferta comercială.

Setarea implicită ASF se bazează pe utilizarea cea mai frecventă a botului, cu transferul doar al pachetelor de rapel și al cardurilor de tranzacționare (inclusiv al foliilor). Proprietatea definită aici vă permite să modificaţi acest comportament în orice mod care vă satisface pe dumneavoastră. Vă rugăm să reţineţi că toate tipurile care nu sunt definite mai sus vor fi afişate ca tip `Necunoscut` , care este deosebit de important atunci când Valve eliberează un nou articol Steam, care va fi marcat și ca `Necunoscut` de ASF până când va fi adăugat aici (în versiunile viitoare). De aceea, în general, nu este recomandat să includeți `Necunoscut` type în `TransferableTypes`, dacă nu știi ce faci, și de asemenea înțelegeți că ASF va trimite întregul dvs. inventar într-o ofertă de tranzacționare dacă rețeaua Steam primește din nou defecțiune și raportează toate articolele dvs. ca `` Necunoscut . Sugestia mea puternică este de a nu include tipul `Necunoscut` în `TransferableTypes`, chiar dacă te aștepți să transferi totul.

---

### `Taste de utilizare`

`bool` tip cu valoarea implicită `true`. Această proprietate definește dacă ASF ar trebui să utilizeze mecanismul cheilor de conectare pentru acest cont Steam. Mecanismul cheilor de conectare funcţionează foarte asemănător cu opţiunea oficială a clientului Steam "memorează-mă", care face posibil ca ASF să stocheze și să utilizeze tasta de conectare unică temporară pentru următoarea încercare de conectare, omite efectiv o nevoie de a furniza parola, Steam Guard sau cod 2FA atât timp cât cheia noastră de conectare este validă. Cheia de conectare este stocată în fişierul `BotName.db` şi actualizată automat. De aceea nu este nevoie să furnizați parolă/cod SteamGuard/2FA după ce v-ați conectat cu succes cu ASF o singură dată.

Tastele de conectare sunt utilizate în mod implicit pentru confortul tău, deci nu trebuie să introduci `SteamPassword`, SteamGuard sau cod 2FA (când nu se utilizează **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**) pe fiecare autentificare. Este de asemenea o alternativă superioară deoarece cheia de conectare poate fi folosită doar o singură dată şi nu dezvăluie în niciun fel parola originală. Exact aceeași metodă este folosită de clientul tău original Steam, care vă salvează numele de cont și cheia de conectare pentru următoarea încercare de autentificare, este în mod efectiv la fel ca în cazul `SteamLogin` cu `UseLoginKeys` și golește `SteamPassword` în ASF.

Cu toate acestea, unele persoane ar putea fi îngrijorate chiar şi de acest mic detaliu. de aceea această opțiune este disponibilă aici pentru tine dacă vrei să te asiguri că ASF nu va stoca niciun fel de token care ar permite reluarea sesiunii anterioare după ce a fost închis, care va duce la obligativitatea autentificării complete la fiecare încercare de autentificare. Dezactivarea acestei opțiuni va funcționa exact la fel ca verificarea "țineți-mă" în clientul oficial Steam. Dacă nu știi ce faci, ar trebui să îl păstrezi cu valoarea implicită de `true`.

---

### `UserInterfaceMod`

`octeți` tip cu valoarea implicită de `0`. Această proprietate specifică modul de interfață utilizator cu care bot-ul va fi anunțat după autentificarea în rețeaua Steam. Ar putea influența modul în care contul este vizibil, de exemplu în conversația Steam, dacă prezența dvs. permite acest lucru prin intermediul `OnlineStatus`. În prezent puteţi alege unul dintre modurile de mai jos:

| Valoare | Nume       | Descriere                         |
| ------- | ---------- | --------------------------------- |
| `0`     | VGUI       | Modul client Steam implicit       |
| `1`     | Tenfoot    | Mod imagine mare                  |
| `2`     | Mobil      | Aplicația mobilă Steam            |
| `3`     | Web        | Sesiune browser web               |
| `5`     | MobileChat | Aplicație pentru chat mobil Steam |

Baza `EUIMode` tip care această proprietate se bazează include mai multe valori disponibile, cu toate acestea, în deplină cunoştinţă de cauză că nu au niciun efect începând de astăzi, prin urmare au fost reduse din punct de vedere vizibil. De asemenea, ați putea fi interesat să verificați `GamingDeviceType`, deoarece unele caracteristici suplimentare sunt activate acolo.

Dacă nu sunteți sigur cum să setați această proprietate, lăsați-o cu valoarea implicită de `0`.

---

### `WebProxy`

`șir` tip cu valoarea implicită `null`. Această proprietate definește o adresă proxy care va fi utilizată pentru comunicațiile interne http, specifice bot-ului, în special pentru servicii precum `api. teapowered.com`, `steamcommunity.com` și `store.steampowered.com`. Dacă nu este setat, ASF va utiliza setarea globală `WebProxy` specificată mai sus. Proxidarea cererilor ASF ar putea fi extrem de utilă pentru ocolirea diferitelor tipuri de ziduri de protecție, în special a marelui firewall din China.

Această proprietate este definită ca șir de caractere:

> Un şir URI este compus dintr-o schemă (sprijinită: http/https/socks4/socks4a/socks5), o gazdă şi un port opţional. Un exemplu de șiruri complete este `"http://contoso.com:8080"`.

Dacă proxy-ul dvs. necesită autentificarea utilizatorului, va trebui de asemenea să configurați `WebProxyUsername` și/sau `WebProxyPassword`. Dacă nu există o astfel de necesitate, numai crearea acestei proprietăți este suficientă.

Dacă aveți nevoie și de proxing pentru comunicarea internă prin rețeaua Steam (CM), atunci ar trebui să vă asigurați că configurați proprietatea **[`SteamProtocols`](#steamprotocols)** bot la o valoare care permite doar transportul de websocket i. . o valoare de `4`, ca doar websockets sunt acceptate pentru proxying.

Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

### `Parola WebProxyParolă`

`șir` tip cu valoarea implicită `null`. Această proprietate definește parola folosită în baza, digest, NTLM, și autentificarea Kerberos care este suportată de un aparat țintă `WebProxy` care oferă funcționalitate proxy. Dacă proxy-ul tău nu necesită acreditări de utilizator, nu este nevoie să introduci nimic aici. Folosirea acestei opțiuni are sens numai în cazul în care `WebProxy` este folosit, deoarece nu are niciun efect în caz contrar.

Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

### `WebProxyUsername`

`șir` tip cu valoarea implicită `null`. Această proprietate definește câmpul de utilizator utilizat în baza, digestul, NTLM, și autentificarea Kerberos care este suportată de un aparat țintă `WebProxy` care oferă funcționalitate proxy. Dacă proxy-ul tău nu necesită acreditări de utilizator, nu este nevoie să introduci nimic aici. Folosirea acestei opțiuni are sens numai în cazul în care `WebProxy` este folosit, deoarece nu are niciun efect în caz contrar.

Dacă nu aveți un motiv pentru a edita această proprietate, trebuie să o păstrați implicit.

---

## Structura fișierului

ASF folosește o structură de fișiere destul de simplă.

```text
ΤΤηλ📁 config
Εθρα, ─ ASF. fiul
T ─ ASF.db
Ταλαγω. fiul
<unk> <unk> ─ Bot1.db
<unk> <unk> <unk> ─ Bot2. fiul
<unk> <unk> ─ Bot2.db
<unk> <unk> <unk> ─ ...
• ─ ArchiSteamFarm.dll
• ─ log.txt
<unk> ─ ...
```

Pentru a muta ASF într-o nouă locație, de exemplu un alt PC, este suficient să muti sau să copiezi directorul `config` singur. şi acesta este modul recomandat de a face orice formă de "backup-uri ASF", pentru că întotdeauna puteți descărca partea (program) rămasă din GitHub, în timp ce nu riscați să corupeți fișierele interne ASF, . printr-o copie de rezervă defectă.

Fișierul `log.txt` conține jurnalul generat de ultima execuție ASF. Acest dosar nu conține informații sensibile și este extrem de util atunci când este vorba de probleme, se prăbușește sau pur și simplu ca o informație pentru voi ce s-a întâmplat în ultimul ASF. Vom întreba foarte des despre acest fișier dacă întâmpini probleme sau erori. ASF administrează automat acest fișier pentru tine, dar poți schimba în continuare ASF **[logging](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging)** dacă ești utilizator avansat.

Directorul `config` este locul care conține configurația ASF, inclusiv toți boții săi.

`ASF.json` este un fișier de configurare ASF global. Această configurație este utilizată pentru specificarea modului în care ASF se comportă ca un proces, care afectează toți roboții și programul în sine. Poți găsi proprietăți globale acolo, cum ar fi proprietarul procesului ASF, actualizări automate sau depanare.

`BotName.json` este o configurare a unei anumite instanțe de bot. Această configurație este utilizată pentru specificarea modului în care se comportă instanța botului dat, Prin urmare, aceste setări sunt specifice doar acelui bot și nu sunt partajate cu alte roboți. Acest lucru vă permite să configurați roboții cu diferite setări și nu neapărat toate funcționează exact în același mod. Fiecare bot este numit folosind identificator unic, ales de tine în locul `BotName`.

În afară de fișierele de configurare, ASF folosește de asemenea directorul `config` pentru stocarea bazelor de date.

`ASF.db` este un fișier ASF al bazei de date. Acesta acționează ca o stocare globală persistentă și este utilizat pentru a salva diverse informații legate de procesul ASF, cum ar fi IP-urile serverelor locale Steam. **Nu trebuie să editați acest fișier**.

`BotName.db` este o bază de date cu o anumită instanță de bot. Acest fișier este folosit pentru a stoca date cruciale despre un anumit caz de bot în depozitarea persistentă, cum ar fi cheile de conectare sau ASF 2FA. **Nu trebuie să editați acest fișier**.

`BotName.keys` este un fişier special care poate fi folosit pentru importul de chei în **[de jocuri de fundal redator](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. Nu este obligatoriu și nu este generat, ci recunoscut de ASF. Acest fișier este șters automat după ce cheile au fost importate cu succes.

`BotName.maFile` este un fișier special care poate fi folosit pentru importul **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**. Nu este obligatoriu și nu este generat, dar recunoscut de ASF dacă `BotName` nu folosește ASF 2FA încă. Acest fișier este șters automat după ce ASF 2FA a fost importat cu succes.

---

## Mapare JSON

Fiecare proprietate de configurare are are tipul. Tipul proprietății definește valorile care sunt valabile pentru ea. Puteți folosi doar valori care sunt valide pentru un anumit tip - dacă folosiți o valoare invalidă, apoi ASF nu va putea analiza configurația dvs.

**Vă recomandăm insistent să utilizaţi ConfigGenerator pentru generarea configs** - acesta se ocupă de majoritatea lucrurilor de nivel scăzut (cum ar fi tipurile de validare) pentru voi, deci trebuie doar să introduci valori corecte, și de asemenea nu trebuie să înțelegi tipurile de variabile specificate mai jos. Această secțiune este în principal pentru persoanele care generează/editează manual configurații, astfel încât să știe ce valori pot folosi.

Tipurile utilizate de ASF sunt tipuri de C# native, care sunt specificate mai jos:

---

`bool` - tip Boolean acceptând doar `true` și `valori false`.

Exemplu: `"Activat": adevărat`

---

`octeți` - Tip octet nesemnat, acceptând doar numere întregi de la `0` la `255` (inclusiv).

Exemplu: `"ConexiuneTimeout": 90`

---

`ushort` - Tip scurt nesemnat, acceptând doar numere întregi de la `0` la `65535` (inclusiv).

Exemplu: `"WebLimiterDelay": 300`

---

`uint` - Tip întreg nesemnat, acceptând doar numere întregi de la `0` la `4294967295` (inclusiv).

---

`ulong` - nesemnat tip întreg lung, acceptând doar numere întregi de la `0` la `18446744073709551615` (inclusiv).

Exemplu: `"SteamMasterClanID": 103582791440160998`

---

`șirul` - Tip String, acceptând orice secvență de caractere, inclusiv secvența goală `""` și `null`. Secvența goală și valoarea `null` sunt tratate la fel de către ASF, așa că depinde de preferința ta pe care vrei să o folosești (vom lipi cu `null`).

Exemple: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MyAccountName"`

---

`Ghid?` - tip UUID vizibil, în JSON codificat ca șir. UUID este alcătuit din 32 de caractere hexadecimale, în intervalul `0` până la `9` şi `un` până la `f`. ASF acceptă o varietate de formate valabile - litere mici, mari, cu și fără cratime. În plus față de UUID valabil, deoarece această proprietate este nulă, o valoare specială de `null` este acceptată pentru a indica lipsa UUID de furnizat.

Exemple: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableLista<valueType>` - Colecție immutabilă (listă) de valori în `valueType`. În JSON, este definit ca array de elemente în `valueType`. ASF utilizează `Lista` pentru a indica faptul că proprietatea dată suportă mai multe valori și că ordinea lor poate fi relevantă.

Exemplu pentru `ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` - Colecție immutabilă (set) a valorilor unice în data de `valueType`. În JSON, este definit ca array de elemente în `valueType`. ASF folosește `HashSet` pentru a indica faptul că proprietatea dată are sens numai pentru valori unice și că ordinea lor nu contează, prin urmare, va ignora intenționat orice posibile duplicate în timpul parcării (dacă s-a întâmplat să le furnizați oricum).

Exemplu pentru `ImmutableHashSet<uint>`: `"Negru": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>` - Dicționar imutabil (map) care hărțuiește o cheie unică specificată în tastatura `de tip`la valoarea specificată în valoarea sa ``. În JSON, este definit ca un obiect cu perechi cheie-valoare. Țineți cont că `keyType` este întotdeauna citat în acest caz, chiar dacă este tip de valoare precum `ulong`. Există, de asemenea, o cerință strictă ca cheia să fie unică pe hartă, de această dată și JSON.

Exemplu pentru `ImmutableDictionary<ulong, byte>`: `"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`

---

`steaguri` - Atributul Flags combină mai multe proprietăți diferite într-o valoare finală prin aplicarea operațiunilor bitwise Acest lucru vă permite să alegeți în același timp orice combinație posibilă de diferite valori permise. Valoarea finală este construită ca o sumă de valori a tuturor opțiunilor activate.

De exemplu, următoarea definiţie:

| Valoare | Nume  |
| ------- | ----- |
| 0       | Nimic |
| 1       | A     |
| 2       | p     |
| 4       | C     |

Există exact 3 steaguri disponibile, semnificative pentru pornire/oprire (`A`, `B`, `C`și, prin urmare, `8` combinații posibile valabile în total:

| Valoare finală | Steaguri activate |
| -------------- | ----------------- |
| 0              | `Nimic`           |
| 1              | `A`               |
| 2              | `p`               |
| 3              | `A` + `B`         |
| 4              | `C`               |
| 5              | `A` + `C`         |
| 6              | `B` + `C`         |
| 7              | `A` + `B` + `C`   |

Prin definiţie, pentru a face posibil cele de mai sus, fiecare steag individual trebuie, prin urmare, să fie puterea a două. Acesta este motivul pentru care un steag suplimentar de mai sus, `D`, ar trebui să poarte valoarea de `8` sau mai mare.

De obicei, uneltele grafice vor face calculul pentru tine. Dacă editați configurări manual, puteţi utiliza întotdeauna calculatorul şi pur şi simplu adăugaţi împreună valorile de bază ale tuturor steagurilor pe care doriţi să le activaţi - ca de exemplu de mai sus.

Exemplu: `"SteamProtocols": 7` (care permite steagurilor cu valoarea `1`, `2` şi `4`, conform explicaţiilor de mai sus)

---

## Cartografierea compatibilității

Din cauza limitărilor JavaScript de a fi incapabil să serializezi câmpurile simple `ulong` din JSON când utilizezi ConfigGenerator web, Câmpurile `ulong` vor fi redate ca șiruri de caractere cu `s_` prefix în configurația rezultată. Aceasta include, de exemplu, `"SteamOwnerID": 76561198006963719` care va fi scris de ConfigGeneratorul nostru ca `"s_SteamOwnerID": "76561198006963719"`. ASF include logica corectă pentru manipularea automată a acestui șir de cartografiere, astfel încât intrările de tip `s_` din configurările dvs. sunt într-adevăr valide și generate corect. Dacă dvs. generați configurări, vă recomandăm să păstrați câmpurile originale `ulong` dacă este posibil, dar dacă nu poți face acest lucru, poți urmări, de asemenea, această schemă și să o codezi ca șiruri de caractere cu `s_` prefix adăugat la numele lor. Sperăm să rezolvăm până la urmă această limitare JavaScript.

---

## Compatibilitate configurări

Este prioritar ca ASF să rămână compatibil cu configurații mai vechi. După cum ar trebui să știți deja, proprietățile de configurare lipsă sunt tratate la fel cum ar fi definite cu valorile implicite **ale lor**. Prin urmare, dacă o nouă proprietate de configurare va fi introdusă în noua versiune de ASF, toate configurările dvs. vor rămâne **compatibil** cu o versiune nouă, și ASF va trata acea nouă proprietate de configurare ca fiind definită cu **valoarea implicită**. Puteți adăuga, elimina sau edita întotdeauna proprietățile configurării în funcție de nevoile dvs.

Vă recomandăm să limitați proprietățile definite doar la cele pe care doriți să le modificați, datorită faptului că moștenești automat valorile implicite pentru toate celelalte nu numai că păstrați configurația curată, dar de asemenea creșteți compatibilitatea, în cazul în care decidem să schimbăm o valoare implicită pentru proprietate pe care nu doriți să o setați în mod explicit (e. . `WebLimiterDelay`).

Datorită celor de mai sus, ASF va migra automat/optimiza configurările prin reformatarea lor și ștergerea câmpurilor care dețin valoarea implicită. You can disable this behaviour with `--no-config-migrate` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** if you have a specific reason, for example you're providing read-only config files and you don't want ASF to modify them.

---

## Autoreîncărcare

ASF este conștient de modificările aduse "la bord" - datorită acestui lucru, ASF va fi automat :
- Creați (și începeți, dacă este cazul) o nouă instanță de bot atunci când creați configurația acestuia
- Opriți (dacă este necesar) și eliminați vechiul bot la ștergerea configurației acestuia
- Opriți (și începeți, dacă este necesar), orice instanță de bot când editați configurația
- Reporniți (dacă este necesar) bot-ul sub noul nume, când redenumiți configurația

Toate cele de mai sus sunt transparente și se vor face automat fără a fi nevoie de repornirea programului sau de omorârea altor cazuri de roboți (neafectați).

În plus, ASF va reporni și el (dacă `AutoRestart` permits) dacă modificați configurația de bază ASF `ASF.json`. De asemenea, programul va renunța dacă îl ștergi sau îl redenumești.

Puteţi dezactiva acest comportament cu `--no-config-watch` **[argumentul de virgulă](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** dacă aveţi un anumit motiv, de exemplu nu doriţi de la ASF pentru a reacţiona la modificările de fişier în directorul de configurare ``.