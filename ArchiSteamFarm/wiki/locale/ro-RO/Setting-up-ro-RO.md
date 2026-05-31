# Configurare

Dacă ai ajuns aici pentru prima dată, bine ai venit! Suntem foarte fericiţi să vedem încă un călător interesat de proiectul nostru, cu toate că trebuie să se ţină seama de faptul că, cu o mare putere, aceasta este în măsură să îndeplinească o mulţime de sarcini diferite legate de Steam; dar numai atâta timp cât ai **grijă să înveți cum să-l folosești**. Într-adevăr, citind wiki, urmând liniile noastre și învățând mai multe despre diferite concepte ASF te va răsplăti în cele din urmă cu abilitatea unică de a folosi unul dintre cele mai puternice unelte Steam disponibile începând de azi.

We recommend you to do **one thing at a time**. ASF atinge multe aspecte diferite, dintre care unele sunt destul de triviale, altele pot fi excesiv de complexe. Nu trebuie să înțelegi sau să citești imediat despre orice și de fapt vă recomandăm să îl luați ușor. Relaxează, alege o băutură la alegere, dedică o oră din timpul tău și scufundă-te în prelegerea noastră - putem promite că va merita foarte mult timp.

Să începem de la elementele de bază - ASF este o aplicație de consolă în principiu, ceea ce înseamnă că nu va genera automat o interfață grafică cu care sunteți obișnuit în general. ASF este o aplicație universală care acționează în principal ca un serviciu (daemon), și nu ca o aplicație pentru desktop. Unul dintre cazurile sale principale de utilizare consideră că rulează pe servere, pentru care aplicațiile desktop sunt complet neadecvate. Aceasta ia însă în considerare doar nucleul absolut al programului, pentru că ASF de fapt **face** include propria sa interfață grafică - în forma încorporată a ASF-ui frontend, dar vom ajunge la acea parte în timp util - menționăm asta imediat ca să nu vă panicați când vedeți consola neagră sau așa ceva.

Odată ce obții fișiere binare ASF, programul va necesita configurare de la tine, care specifică ce anume aștepți ca ASF să obțină. Poți porni programul fără configurare, în acest caz ASF va lansa în setările implicite, permițându-ți să îl utilizezi. . ASF-ui pentru configurația inițială, dar nu va face prea multe fără acțiunea anterioară.

Asta se va întâmpla deocamdată, să începem!

---

## Configurare specifica fiecarui sistem de operare

În general, iată ce vom face în următoarele minute:
- Vom instala **[.NET condiţii](#net-prerequisites)**.
- Apoi vom descărca **[ultima versiune ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** în variantă corespunzătoare specifică OS.
- Apoi vom extrage arhiva într-o locație nouă.
- Apoi vom **[configura ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- Şi în final, vom lansa ASF şi îi vom vedea magia.

Unii dintre paşi sunt de la sine înţeleşi, alţii vor necesita mai multă atenţie din partea dumneavoastră. Nu-ți face griji, te avem acoperit.

---

### Cerințe prealabile NET

Primul pas este să vă asigurați că sistemul dvs. de operare poate lansa ASF în mod corespunzător. Nu trebuie să știi asta, dar ASF este scris în C#, pe baza . Platforma ET și poate avea nevoie de biblioteci native care nu sunt încă disponibile pe platforma dvs. Gândiți-vă ca DirectX pentru jocurile 3D, sau ca motor pentru pornirea mașinii.

În funcţie de modul în care utilizaţi Windows, Linux sau macOS, veţi avea cerinţe diferite. Documentul de referinţă este **[. Premisele ET](https://docs.microsoft.com/dotnet/core/install)**, dar de dragul simplităţii am detaliat toate pachetele necesare mai jos, așa că nu trebuie să-l citești deloc, cu excepția cazului în care întâmpini probleme sau vei avea întrebări suplimentare.

Este perfect normal ca unele (sau chiar toate) dependențe să existe deja în sistemul tău datorită faptului că sunt instalate de un software terț pe care îl folosești. Totuşi, nu trebuie să fie aşa, ar trebui să rulați instalatorul adecvat pentru sistemul de operare - fără ca ASF să nu fie lansat deloc, și abia veți primi informații utile pentru a vă spune ce e în neregulă.

Țineți cont de faptul că nu trebuie să faceți nimic altceva pentru construcțiile specifice OS, în special instalând . ET, SDK sau chiar perioada de execuție, deoarece pachetul specific privind OS, include deja toate acestea. Aveți nevoie doar de .NET condiții (dependență) pentru a rula . Intervalul de timp al ET inclus în ASF - deci numai lucrurile pe care le specificăm mai jos, fără alte completări.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Actualizare de redistribuire Microsoft C++](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** pentru 64 biți, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** pentru 32-bit sau **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** pentru 64-bit ARM)
- Este foarte recomandat să te asiguri că toate actualizările Windows sunt deja instalate. Dacă nu le aveți activate, apoi cel puţin ai nevoie de **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** şi **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**dar este posibil să fie necesare mai multe actualizări. Nu trebuie să vă faceţi griji pentru asta dacă Windows este actualizat sau cel puţin recent suficient.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Numele pachetelor depind de distributia Linux pe care o folositi, am listat cele mai comune dintre ele. Le puteți obține pe toate cu managerul nativ de pachete pentru sistemul de operare (cum ar fi `apt` pentru Debian sau `yum` pentru CentOS). Acelea sunt biblioteci standard care ar trebui să fie disponibile indiferent de distribuţia pe care o foloseşti, e doar o chestiune de a afla cum se numesc ei în mediul vostru de a alege.

- `ca-certificate` (certificate SSL standard de încredere pentru a face conexiuni HTTPS)
- `libc6` (`libc`)
- `libgcc-s1` (`libgc1`, `libgcc`)
- `libicu` (`icu-libs`, ultima versiune pentru distribuția dvs., de exemplu `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-lib-libs`, cea mai recentă versiune pentru distribuția dvs., cel puțin `1.1.X`)
- `libstdc+6` (`libstdc++`, în versiunea `5.0` sau mai mare)
- `zlib1g` (`zlib`)

Cel puţin majoritatea acestora ar trebui să fie deja disponibile pe sistemul dumneavoastră. De exemplu, instalarea minimă a Debian stable necesită de obicei doar `libicu76`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- Nu aveți nevoie de nimic specific, dar ar trebui să aveți instalată cea mai recentă versiune de macOS, cel puțin 12.0+

---

### Descărcare

Deoarece avem deja toate dependențele, următorul pas este descărcarea **[ultimei versiuni ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF este disponibil în multe variante, dar ești interesat de pachetul care se potrivește cu sistemul tău de operare și arhitectura. De exemplu, dacă folosești versiunea Windows `64`-bit, atunci îți dorești `pachetul ASF-win-x64`. Pentru mai multe informații despre variantele disponibile, vizitați secțiunea **[compatibilitate](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**. ASF este de asemenea capabilă să funcționeze în mediile în care nu construim pachetul specific OS, cum ar fi **32-bit Windows**, dar vei avea nevoie de **[configurare generică](#generic-setup)** pentru asta.

![Active](https://i.imgur.com/Ym2xPE5.png)

După descărcare, pornește extragerea fișierului zip în propriul său director. Dacă aveţi nevoie de o unealtă specifică pentru asta, **[7-zip](https://www.7-zip.org)** o să facă, dar toate utilitățile standard, cum ar fi extracția Windows încorporată sau `dezarhivează` din Linux/macOS ar trebui să funcționeze fără probleme.

Fii sfătuit să dezarhivezi ASF la **propriul său director** şi nu la nici un director existent pe care îl foloseşti deja pentru altceva - asta e important. ASF include funcția de auto-actualizare, care înlocuiește propriile fișiere, și care de obicei va șterge toate fișierele vechi și neasociate la actualizare, care la rândul tău poate duce la pierderea a ceva ce nu ești legat de tine introdus în directorul ASF. Dacă aveţi scripturi sau fişiere suplimentare pe care doriţi să le utilizaţi cu ASF, aceasta nu este o problemă, creați un dosar dedicat pentru aceștia, puteți întotdeauna pune ASF într-un singur folder mai profund.

Un exemplu de structură ar putea arăta în felul următor:

```text
C:\ASF (unde îți pui propriile lucruri)
    • ─ MyNotes. xt (opțional)
    <unk> ─ AsfMakeMeCoffeeScript.bat (opțional)
    • ─ (... (orice alte fişiere la alegere, opţional)
    <unk> 3.2.3 ─ Nuclee (dedicate doar ASF, unde extragi arhiva)
         <unk> ─ ArchiSteamFarm(. xe)
         • ─ configurare
         Ribavirin ─ jurnale
         • ─ plugin-uri
         <unk> ─ www
         <unk> ─ (...)
```

---

### Configurare

Acum suntem gata să facem ultimul pas, configurația. ASF funcționează cu conceptul de "boți", fiecare bot este de obicei un singur cont Steam pe care doriți să-l utilizați în interiorul ASF. Poți declara cât de mulți roboți dorești, dar pentru început ne vom concentra doar pe unul dintre ei - de obicei contul tău principal. ASF are, de asemenea, fișiere de configurare non-bot, cel mai important este fișierul de configurare global, care afectează toți roboții de exemplu.

Regula generală a degetului mare este că **dacă nu știți, sau nu înțelegeți ceva setări, ar trebui să îl lăsați cu valoarea sa implicită, fără a schimba nimic**. ASF oferă nenumărate moduri de a configura, personaliza și modifica aproape toate caracteristicile sale, dar ca cele menționate mai sus, încercarea de a o înţelege chiar de pe liliac este o gaură la iepure care vă poate trage rapid într-o stare de confuzie severă, dacă nu **[direct în abyss](https://www.youtube.com/watch?v=KK3KXAECte4)**. În schimb, recomandăm să avem mai întâi un exemplu funcţional şi doar apoi să începem săparea în opţiuni suplimentare; cu ajutorul paginii **[configuraţia](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** de pe wiki, în timp ce schimbați **câte un lucru la un moment dat**.

Configurarea ASF poate fi făcută în mai multe moduri - prin intermediul sistemului nostru de date ASF-ui frontend, un generator de configurare web independent, sau manual. Acest lucru este explicat în detaliu în secțiunea **[configurația](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** , așa că dacă doriți informații mai detaliate. Vom utiliza un generator de configurări web autonome ca punct de plecare, deoarece acesta funcționează chiar dacă, dintr-un anumit motiv, ASF-ui nu reușește să înceapă sau să funcționeze corect.

Navighează la pagina noastră **[configurator web](https://justarchinet.github.io/ASF-WebConfigGenerator)** cu browser-ul tău preferat. Îți recomandăm Chrome sau Firefox, dar nu ar trebui să conteze atâta timp cât browserul tău funcționează pentru orice altceva.

După deschiderea paginii, comutați la fila "Bot". Acum ar trebui să vedeți o pagină similară cu cea de mai jos:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Dacă cu orice șansă versiunea ASF pe care tocmai ați descărcat-o este mai veche decât ce generator de configurări este setat să folosească în mod implicit, pur și simplu alegeți versiunea ASF din meniul derulant. Acest lucru se poate întâmpla (rar) deoarece generatorul de configurări poate fi folosit pentru generarea de configurări către versiuni ASF mai noi (pre-lansare) care nu au fost marcate ca stabile încă. Ați descărcat ultima versiune stabilă de ASF care este verificată pentru a lucra în mod fiabil, astfel încât poate fi puţin mai veche decât versiunea absolută de ultimă oră, care este total inadecvată pentru prima utilizare.

Începe de la **punând numele pentru botul tău** în câmpul evidențiat ca roșu, numit `Numele`. Acesta poate fi orice nume pe care doriţi să îl folosiţi, cum ar fi porecla, numele contului, un număr sau orice altceva. Există un singur cuvânt pe care nu îl poți folosi, `ASF`, deoarece acel cuvânt cheie este rezervat pentru fișierul de configurare globală. În plus, numele botului nu poate începe cu un punct (ASF ignoră intenționat aceste fișiere). De asemenea, vă recomandăm să evitaţi utilizarea spaţiilor, poți utiliza `_` ca și separator de cuvinte dacă este necesar - nu o cerință strictă, dar vei avea dificultăți în a folosi comenzi ASF altfel.

Numele bot-ului a decis? Grozav, în pasul următor, **modifică `Comutator activat` pentru a fi pe**, cel care definește dacă bot-ul tău ar trebui să fie pornit de ASF automat după lansare (a programului). Nu se face acest lucru va determina ASF să declare că bot-ul este dezactivat în fișierul de configurare, şi va aştepta ca intrarea dumneavoastră să o înceapă, ceea ce nu vrem să facem în acest exemplu.

Urmează două proprietăți sensibile: `SteamLogin` și `SteamPassword`. Puteţi lua o altă decizie aici - fie puteţi pune detaliile de autentificare ale Steam în aceste două proprietăţi, sau puteți decide să nu faceți acest lucru, lăsându-le goale.

ASF are nevoie de datele de autentificare pentru că include propria sa implementare a clientului Steam și are nevoie de aceleași detalii pentru a te autentifica ca și cel pe care îl folosești. Datele de autentificare nu sunt salvate nicăieri, ci doar pe calculatorul tău din ASF `config` (odată ce descarci configurația generată). Generatorul nostru de configurări web este o aplicație bazată pe client, ceea ce înseamnă că tot ce faceți în interiorul site-ului nostru standalone web config-generator de configurări web rulează local în browser pentru a genera configurații ASF valabile, fără detalii puneţi vreodată la loc PC-ul vostru, aşa că nu trebuie să vă faceţi griji cu privire la o posibilă scurgere de date sensibilă. Totuşi, dacă din orice motiv nu vrei să îţi pui acreditările acolo, noi înţelegem asta, şi le puteţi pune manual în fişiere generate mai târziu, sau le omiţi în întregime şi funcţiona fără ele.

Dacă decideți să introduceți credențialele, ASF va putea să se autentifice automat la pornire, care împreună cu 2FA opţional vă va permite să faceţi doar un dublu clic pe program pentru a rula totul. If you decide to omit them, then ASF will **ask you** to input those details when needed - that approach won't save them anywhere, but naturally ASF won't be able to operate without your help. Depinde de tine în ce fel preferi mai mult și poți găsi și informații suplimentare în secțiunea **[configurația](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** , ca de obicei.

Ca o notă laterală, puteți decide, de asemenea, să lăsați un singur câmp gol, cum ar fi `SteamPassword`. ASF va putea utiliza autentificarea automat, dar va solicita în continuare parola dacă este necesar (similar cu Steam Client). Dacă cu orice șansă folosești un pin parental de 4 cifre pentru a-ți debloca contul, recomandăm, de asemenea, să fie plasat în căsuța `SteamParentalPin` , chiar şi în acest caz, puteţi să lăsaţi acest lucru gol şi să observaţi în schimb cât de slabă este protecţia, pentru că ASF poate "crăpa" și ea însăși în doar câteva secunde după autentificare. Ups.

După ce urmăriți cu totul de mai sus, deci încă o dată, **numele botului**, **a activat comutarea**, și **credențialele de conectare** , pagina web va arăta acum similar cu cea de mai jos:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Acum puteți apăsa butonul "download" și generatorul nostru de configurații web va genera un nou fișier `json` în funcție de numele ales. Salvați fișierul în directorul `config` care se află în folderul în interiorul căruia ați extras fișierul zip în pasul anterior.

Felicitări! Tocmai ați terminat configurația foarte elementară a bot-ului ASF. Mai sunt multe de descoperit, dar deocamdată asta e tot ce ai nevoie.

---

### Funcționare ASF

Ştiu că aţi aşteptat acest moment, şi nu vă putem menţine mai mult, pentru că sunteți gata să lansați programul pentru prima dată. Doar dublu click `ArchiSteamFarm` binar în directorul ASF. De asemenea, îl puteţi porni din consolă.

Acum ar fi un moment bun să revizuim secțiunea **[de comunicare la distanță](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** dacă sunteți preocupați de lucrurile pe care ASF este programat să le facă, în special acţiunile pe care le va lua în numele tău, cum ar fi alăturarea implicită a grupului nostru Steam. Puteți dezactiva întotdeauna funcționalitățile selectate mai târziu dacă nu le place, ASF pur și simplu vine cu valori implicite de bun simț, şi a trebuit să luăm o decizie cu privire la utilizarea generală care se aplică majorităţii bazei noastre de utilizatori, în principiu, precum şi propria noastră viziune asupra programului.

Presupunând că totul a mers bine, care în mare parte consideră că instalarea tuturor dependenţelor necesare în primul pas, și configurarea ASF în cel de-al treilea, ASF trebuie să lanseze în mod corespunzător, să descopere primul bot și să încerce să se conecteze:

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF va mai necesita probabil încă un detaliu de la tine - 2FA pentru a accesa contul (cu excepția cazului în care ai dezactivat complet SteamGuard, apoi nu). Pur și simplu urmați instrucțiunile de pe ecran, puteți să furnizați codul de la autentificator/e-mail sau să acceptați confirmarea în aplicația mobilă.

Ceva nu a mers bine?

#### ASF nu pornește deloc, nici o fereastră de consolă

Fie lipsesc condițiile .NET, fie ați descărcat o variantă incorectă de ASF pentru mașina dvs. Dacă nu știi ce e greșit, verificați **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** pentru o posibilă modalitate de a găsi o problemă exactă, iar dacă încă ești blocat, accesează **[suport](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### Niciun bot definit

Nu ați pus configurația generată în directorul `config`. Alte greșeli comune din acest pas ar putea include schimbarea manuală a extensiei de la `.json` de ex. la `. xt`și unele sisteme de operare (de ex. Ferestre) le place să ascundă extensiile comune în mod implicit, astfel încât să te asiguri că fișierul tău este în locul potrivit și cu numele corespunzător.

#### Nu pornește acest bot pentru că este dezactivat în fișierul de configurare

Ai uitat să reîntoarci comutatorul `Activat` , care spune ASF să pornească robotul automat Unless that was your intention of course, but then you should already know how to execute commands, simply `start` your bot after that message.

#### `Parolă invalidă`

Acreditările dvs. de conectare sunt cel mai probabil greșite. Verifică `SteamLogin` și `SteamPassword` în configurația generată, dacă sunt greșite, corectați-le revenind la pasul de configurare. Dacă încă întâmpini probleme, încearcă să folosești aceleași date de autentificare în propriul tău client Steam - ar trebui să nu te autentifici, şi poate veţi obţine mai multe informaţii despre ce e greşit în acest mod.

#### Totul e bun?

După ce treci prin poarta de conectare inițială, presupunând că detaliile tale sunt corecte, te vei autentifica cu succes, și ASF va începe agricultura folosind setările implicite pe care nu le-ați atins deocamdată:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Acest lucru dovedește că ASF își face treaba cu succes în contul tău, astfel încât acum poți minimiza programul și face altceva. Mergeți mai departe, meritați, poate reumpleți cel puțin băutura aleasă de tine!

Cardurile agricole reprezintă un subiect pentru un alt articol durabil ca acesta, dar în principiu: după destul timp (în funcție de **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), vei vedea cartonașele de tranzacționare Steam fiind scăpate încet. Desigur, pentru ca acest lucru să se întâmple, trebuie să ai jocuri valide la fermă, arătând ca "poți obține X mai multe picături de carduri pentru a juca acest joc" pe pagina **[de insigne](https://steamcommunity.com/my/badges)** - dacă nu există jocuri de ferm, apoi ASF va declara că nu există nimic de făcut, după cum se menţionează în **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, care răspunde la întrebarea cea mai comună pe care o au oamenii în acest moment, Se întreabă de ce, în ciuda faptului că are 14 jocuri pe cont, ASF pretinde că nu este nimic de făcut - nu, nu este o eroare.

Aceasta încheie ghidul nostru de configurare foarte simplu. La fel ca în fiecare joc RPG, ai terminat tutorialul, și îți lăsăm toată lumea ASF să fie explorată acum. De exemplu, acum puteți decide dacă doriți să configurați ASF mai departe sau să îl lăsați să își facă treaba în setările implicite. Vom acoperi câteva detalii de bază dacă dorești să citești mai mult, apoi îți vom lăsa întregul wiki pentru descoperire.

---

### Configurație extinsă

#### Agricultura mai multe conturi dintr-o dată

ASF sprijină agricultura mai mult de un singur cont în același timp, care este funcția sa principală. Puteți adăuga mai multe conturi în ASF prin generarea mai multor fișiere de configurare ale botului, exact în acelaşi mod în care aţi generat primul dumneavoastră acum câteva minute. Trebuie să vă asigurați doar două lucruri:

- Numele robotului unic, dacă deja ai primul tău bot numit `MainAccount`, nu poți avea altul cu același nume.
- Detalii de autentificare valide, cum ar fi `SteamLogin`, `SteamPassword` și `SteamParentalCode` (dacă ați decis să le completați)

Cu alte cuvinte, pur și simplu săriți din nou la configurare și faceți exact același lucru, doar pentru al doilea sau al treilea cont. Amintiți-vă să utilizați nume unice pentru toți roboții, pentru a nu suprascrie configurațiile existente.

---

#### Modificare setări

În generatorul nostru de configurări web independent, schimbi setările existente în exact același mod - prin generarea unui fișier de configurare nou. Dă click pe "comută setările avansate" și vezi ce este acolo pentru a descoperi. În acest exemplu, vom schimba setarea `CustomGamePlayedWhileFarming` , care vă permite să setați numele personalizat afișat când ASF este în fermă, în loc să afișați jocul real.

Să analizăm mai întâi acest lucru. Dacă rulați ASF și începeți agricultura, în setările implicite veți vedea că contul dvs. Steam este în joc acum:

![Steam](https://i.imgur.com/1VCDrGC.png)

E logic, după ce ASF tocmai a spus platformei Steam că jucăm jocul, avem nevoie de cărţi de la ea, nu? Dar hei, putem personaliza asta! Comută setările avansate dacă nu ai făcut încă, apoi găsește `CustomGamePlayedWhileFerma`. Pur și simplu puneți orice text personalizat pe care doriți să îl afișați acolo, cum ar fi "Idling cards":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Acum descarcă fișierul de configurare nou exact în același mod, apoi **suprascrie** vechiul fișier de configurare cu unul nou. De asemenea, poți șterge vechiul fișier de configurare și să îl pui pe cel nou în locul lui desigur.

ASF este destul de inteligent și ar trebui să observe că ai schimbat configurarea, pe care apoi ar trebui să o preia și să o aplice automat, fără repornirea programului. Dacă nu s-a întâmplat cu orice șansă, pur și simplu poți reporni programul pentru a te asigura că noua configurație este preluată. După ce faceți acest lucru, ar trebui să observați că ASF afișează acum textul personalizat în locul anterior:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

Aceasta confirma ca ati editat cu succes configuratia. Exact în același mod în care puteți schimba proprietățile ASF globale, trecând de la fila bot la fila "ASF", descărcarea a generat `ASF. Fișierul de configurare al fiului` și introducerea lui în directorul de configurare ``.

Editarea configurărilor ASF poate fi mult mai ușoară folosind frontend-ul nostru ASF-ui, care va fi explicat mai jos.

---

#### Folosind ASF-ui

După cum am menționat anterior, ASF este o aplicație de consolă și nu lansează o interfață grafică de utilizator în mod implicit. Cu toate acestea, lucrăm activ la **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** frontend la interfața noastră IPC, care poate fi o modalitate foarte decentă și ușor de utilizat de a accesa diverse caracteristici ASF.

Pentru a folosi ASF-ui, trebuie să ai `IPC` activat, care este opțiunea implicită, așa că dacă nu ai dezactivat-o manual, este deja activă. Odată ce lansați ASF, ar trebui să puteți confirma că a pornit automat interfața IPC:

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC, pe scurt, este încorporat în serverul web ASF care pornește local pe calculatorul tău, permiteți-vă să interacționați cu el folosind browserul web favorit. Presupunând că a început corect, puteți accesa interfața IPC a ASF făcând clic pe **[acest](http://localhost:1242)** link, atât timp cât ASF rulează, de la aceeași mașină. Poți folosi ASF-ui pentru diferite scopuri, de ex. editarea fișierelor de configurare sau trimiterea de la **[comenzi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Simte-te liber să privești în jur pentru a afla toate funcționalitățile ASF-ui;

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Rezumat

Ați configurat cu succes ASF pentru a utiliza conturile Steam și l-ați personalizat deja unui pic mai mult decât vă place dvs. Dacă ai urmat întregul nostru ghid, ai reușit, de asemenea, să ajustezi ASF prin interfața noastră ASF-ui și ai început să descoperi funcționalitățile acestuia. Aici încheiem tutorialul, dar vă lăsăm cu câteva indicii suplimentare la lucruri de care ați putea fi interesat, "misiuni laterale", dacă insistați:

- Secţiunea noastră **[configuraţia](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** vă va explica ce **toate** toate setările diferite pe care le-aţi văzut de fapt fac, și ce altceva vă poate oferi ASF. Nu uita să hidratezi corect în timpul citirii, ai fost avertizat.
- Dacă ați dat peste o problemă sau aveți o întrebare generică, luați în considerare **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**, care ar trebui să acopere totul, sau cel puţin marea majoritate a întrebărilor şi problemelor pe care le puteţi avea.
- Dacă vrei să înveți totul despre ASF și cum îți poate face viața mai ușoară, mergi înainte la restul lui **[wiki-ul nostru](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. Utilizați bara laterală din dreapta pentru a alege subiectul care vă interesează.
- Şi în final, dacă ați aflat că programul nostru este util pentru dvs. și apreciați volumul uriaș de muncă care a fost depus, poți lua în considerare și o mică donație **[](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** pentru cauza noastră. ASF este o muncă de dragoste, am muncit din greu în timpul nostru liber în ultimii 10 ani pentru a vă face posibilă această experiență, și suntem foarte mândri de ea - până și $1 este foarte apreciat și arată că îți pasă. În orice caz, distracție plăcută!

---

## Configurare generică

Acest apendice este pentru utilizatorii avansați care doresc să configureze ASF pentru a rula în varianta **[generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)**. În timp ce este mai supărător în utilizare decât **[variantele specifice OSspecific](#os-specific-setup)**, vine de asemenea cu beneficii suplimentare.

Vrei să folosești varianta `generică` în principal atunci când:
- Utilizați sistemul de operare pentru care nu construim pachete specifice OS-ului (cum ar fi ferestrele de 32 biți)
- Aveți deja .NET Runtime/SDK, sau doriți să instalați și să utilizați unul
- Doriți să minimizați dimensiunea structurii ASF și amprenta de memorie prin manipularea cerințelor de rulare
- Doriți să utilizați o configurare particularizată **[plugin-ul](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** care necesită un `generic` pentru a rula corect (din cauza lipsei dependențelor native)

Bineînţeles, îl puteţi folosi şi în orice alt scenariu doriţi, dar cele de mai sus au cel mai bun sens.

Cu toate acestea, aveți în vedere faptul că configurarea generică vine cu o răsucire - **tu** sunteți responsabil de .NET runtime în acest caz. Asta înseamnă că dacă .NET SDK (runtime) nu este disponibil, expirat sau stricat, ASF pur și simplu nu va funcționa. De aceea nu recomandăm această configurare pentru utilizatorii ocazionali, deoarece acum trebuie să te asiguri că ai . ET SDK (runtime) corespunde cerințelor ASF și poate rula ASF, spre deosebire de **noi** asigurându-ne că . Un pachet de timp rulat al ET cu ASF poate face acest lucru.

Pentru pachetul `generic` puteţi urma întregul ghid specific OS, cu doar două mici modificări. In addition to installing .NET prerequisites, you also want to install .NET SDK, and instead of downloading and having OS-specific `ArchiSteamFarm(.exe)` executable file, you'll now download and have a generic `ArchiSteamFarm.dll` binary only. Toate celelalte sunt exact la fel.

Cu pași suplimentari:
- Instalaţi **[.NET condiţii](#net-prerequisites)**.
- Instalați **[.NET SDK](https://www.microsoft.com/net/download)** (sau cel puțin ASP.NET Core și .NET runtimes) adecvate pentru sistemul dvs. de operare. Cel mai probabil vrei să folosești un instalator. Consultați **[cerințele de execuție](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** dacă nu sunteți sigur ce versiune să instalați.
- Descarcă **[ultima versiune ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** în varianta `generic`.
- Extrage arhiva intr-o locatie noua.
- **[Configurați ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, în exact același mod ca cel descris mai sus.
- Lansați ASF fie folosind un script ajutător, fie executând `dotnet/path/to/ArchiSteamFarm.dll` manual din coșul dvs. preferat.

Varianta generică a ASF nu are binar specific mașinii, după tot ce se numeşte `generic` pentru un motiv - este o construcţie de platform-agnostic care poate funcţiona peste tot, așa că nu te aștepta la fișierul `exe` acolo.

Acesta este motivul pentru care l-am împachetat cu scripturi ajutătoare (cum ar fi `ArchiSteamFarm.cmd` pentru Windows și `ArchiSteamFarm. h` pentru Linux/macOS), care sunt situate lângă `ArchiSteamFarm.dll` binar. Le puteți folosi dacă nu doriți să executați comanda `dotnet` manual.

Evident, scripturile ajutătoare nu vor funcţiona dacă nu aţi instalat. SDK ET și nu aveți `dotnet` executabil disponibil în `PATH`. Sunt complet opționale de utilizat, poți întotdeauna `dotnet/path/to/ArchiSteamFarm. Va fi de tip` manual, dacă ai vrea, ca în cazul unor modificări suplimentare, asta face oricum acele scripturi.