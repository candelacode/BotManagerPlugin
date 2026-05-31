# Întrebări frecvente

Întrebările noastre frecvente de bază acoperă întrebările standard şi răspunsurile pe care le puteţi avea. Pentru probleme mai puţin comune, vă rugăm să vizitaţi în schimb **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ)**.

# Cuprins

* [General](#general)
* [Comparație cu instrumente similare](#comparison-with-similar-tools)
* [Securitate / Confidențialitate / VAC / Ban / ToS](#security--privacy--vac--bans--tos)
* [Diverse](#misc)
* [Probleme](#issues)

---

## General

### Ce este ASF?
### De ce programul pretinde că nu există nimic de cultivat în contul meu?
### De ce ASF nu detectează toate jocurile mele?
### De ce este limitat contul meu?

Înainte de a încerca să înțelegeți ce este ASF, ar trebui să vă asigurați că înțelegeți ce sunt cardurile Steam. și cum să le obțineți, care este minunat descris în secțiunea oficială de întrebări frecvente **[aici](https://steamcommunity.com/tradingcards/faq)**.

Pe scurt, cardurile Steam sunt obiecte colectibile pentru care ești eligibil când deții un anumit joc, și pot fi utilizate pentru a fabrica insigne, pentru a vinde pe piața Steam sau orice alt scop la alegere.

În acest sens se menţionează încă o dată punctele principale: pentru că, în general, oamenii nu doresc să fie de acord cu ei și preferă să pretindă că acestea nu există:

- **Trebuie să deții jocul pe contul tău Steam pentru a fi eligibil pentru orice card nu mai este disponibil. Partajarea familiei nu este proprietate și nu contează.**
- **Jocul tău nu poate fi marcat ca [privat](https://help.steampowered.com/faqs/view/1150-C06F-4D62-4966), ASF va sări automat astfel de jocuri în timpul fermierilor.**
- **Nu poți cultiva jocul infinit, fiecare joc are un număr fix de picături cu cardul. Odată ce le scapi pe toate (aproximativ jumătate din setul complet), jocul nu mai este un candidat pentru agricultură. Nu contează dacă ai vândut, tranzacționat, meșteșugit sau uitat ce s-a întâmplat cu acele cărți pe care le-ai obținut, odată ce ai rămas fără cărți scăpate, jocul este terminat.**
- **Nu poți renunța la cărți din jocurile F2P fără să cheltui bani în ele. Aceasta înseamnă jocuri F2P permanent, cum ar fi Team Fortress 2 sau Dota 2. Deținerea de jocuri F2P nu îți acordă picături cu cărți.**
- **Nu poți plasa carduri pe [conturi limitate](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A), indiferent de jocurile deținute și de metoda lor de activare.**
- **Jocurile plătite pe care le-ai obținut gratuit în timpul unei promoții nu pot fi cultivate pentru picături cu cardul, indiferent de ce este afișat pe pagina magazinului.**

Aşa cum puteţi vedea, cărţile Steam vă sunt acordate pentru că aţi jucat un joc pe care l-aţi cumpărat, sau jocul F2P în care ai investit. Dacă joci astfel de joc suficient de mult, toate cardurile pentru acel joc vor fi aruncate în inventar, vă permite să completați o insignă (după ce ați obținut jumătatea rămasă din set), să o vindeți sau să faceți orice altceva doriți.

Acum că am explicat elementele de bază ale Steam, putem explica ASF. Programul însuși este destul de complex pentru a înțelege complet, așa că în loc să săpăm în detaliile tehnice, vom oferi o explicație foarte simplificată mai jos.

ASF se conectează în contul tău Steam prin intermediul implementării noastre personalizate a clientului Steam folosind credențialele furnizate. După autentificarea cu succes, analizează insignele tale **[](https://steamcommunity.com/my/badges)** pentru a găsi jocuri disponibile pentru agricultură (`X` picături rămase). După analizarea tuturor paginilor și construirea unei liste finale de jocuri disponibile, ASF alege cel mai eficient algoritm de agricultură și începe procesul. Procesul depinde de alegerea **[carduri algoritmul farmaceutic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** dar, de obicei, constă în jocuri eligibile și periodic (plus la fiecare meniu de obiect) verificarea dacă jocul este cultivat deja în întregime - dacă da, ASF poate continua cu titlul următor, folosind aceeași procedură, până când toate jocurile sunt complet cultivate.

Rețineți că explicația de mai sus este simplificată și nu descrie zeci de funcții și caracteristici suplimentare pe care ASF le oferă. Vizitează restul de **[wiki-ul nostru](https://github.com/JustArchiNET/ArchiSteamFarm/wiki)** dacă vrei să afli fiecare detaliu ASF. Am încercat să-l fac destul de simplu pentru toată lumea, fără a aduce detalii tehnice - utilizatorii avansați sunt încurajați să sape mai adânc.

Acum ca un program - ASF oferă ceva magie. În primul rând, nu trebuie să descarce niciunul dintre fișierele jocului, poate juca imediat. În al doilea rând, este complet independent de clientul tău normal de Steam - nu trebuie să ai clientul Steam activ sau chiar instalat. În al treilea rând, este o soluție automatizată - ceea ce înseamnă că ASF face automat totul în spatele spatelor. fără a fi nevoie să îi spui ce să facă - ceea ce vă salvează şi timpul. În cele din urmă, nu trebuie să păcălească rețeaua Steam prin emulare (pe care, de exemplu, o folosește Idle Master), deoarece poate comunica direct cu ea. Este de asemenea super rapid şi uşor, fiind o soluţie uimitoare pentru toţi cei care doresc să obţină cărţi cu uşurinţă fără multe complicaţii - este deosebit de utilă lăsând-o să fugă pe fundal în timp ce face altceva, sau chiar în modul offline.

Toate cele de mai sus sunt frumoase, dar ASF are, de asemenea, unele limitări tehnice care sunt impuse de Steam - nu putem să exploatăm jocurile pe care nu le dețineți, nu putem să facem jocuri pentru totdeauna pentru a depăși limita forțată, și nu putem să facem jocuri în timp ce te joci. Toate acestea ar trebui să fie „logice”, având în vedere modul în care funcționează ASF, dar e frumos să observi că ASF nu are super-puteri şi nu va face ceva fizic imposibil, așa că țineți cont de acest lucru - este practic la fel ca și cum ați spune cuiva să se conecteze în contul dvs. de pe un alt PC și să faceți aceste jocuri pentru voi.

Deci pentru a rezuma - ASF este un program care te ajută să renunți la acele cărți pentru care ești eligibil, fără prea multe complicații. Oferă de asemenea și alte funcții, dar hai să rămânem la asta deocamdată.

---

### Trebuie să-mi pun datele de autentificare ale contului?

**Da**. ASF necesită acreditările contului tău în acelaşi fel în care face clientul oficial Steam, ca şi cum foloseşte aceeaşi metodă pentru interacţiunea cu reţeaua Steam. Cu toate acestea, acest lucru nu înseamnă că trebuie să puneți datele de autentificare ale contului în configurările ASF, puteți continua să utilizați ASF cu `SteamLogin` și/sau `SteamPassword`, și introduceți datele pentru fiecare rulare ASF, atunci când este necesar (precum și mai multe alte date de autentificare, consultați configurația). În acest fel detaliile tale nu sunt salvate nicăieri, dar bineînțeles ASF nu poate porni automat fără ajutorul tău. ASF oferă, de asemenea, și alte modalități de a crește **[securitate](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**, nu ezita să citești acea parte a wiki-ului dacă ești utilizator avansat. Dacă nu, și nu doriți să puneți acreditările contului în configurările ASF, pur și simplu nu face asta, și să le introduci așa cum este necesar când ASF le cere.

Țineți cont de faptul că instrumentul ASF este pentru uz personal și datele de autentificare nu părăsesc niciodată calculatorul. De asemenea, nu le împărtășiți cu nimeni, care împlinește **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** - un lucru foarte important pe care mulți oameni îl uită uitat. Nu trimiți detaliile tale către serverele noastre sau către terți, doar direct către serverele Steam operate de Valve. Nu cunoaștem datele tale de identificare și, de asemenea, nu le putem recupera pentru tine, indiferent dacă le pui sau nu.

---

### Cât timp trebuie să aştept ca cartonaşele să cadă?

**Atât timp cât ia** - în serios. Fiecare joc are diferite dificultăți în agricultură de către dezvoltator/editor, și depinde în totalitate de cât de repede sunt aruncate cărțile. Majoritatea jocurilor urmează 1 picătură în 30 de minute de la joc, dar există și jocuri care vă cer să jucați chiar cu câteva ore înainte de a da o carte. În plus, contul tău ar putea fi restricționat să primească picături de card din jocurile pe care nu le-ai jucat suficient de mult timp încă, așa cum este menționat în secțiunea **[Performanța](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Nu încerca să ghicești cât timp ar trebui ASF să dea un titlu - nu depinde de tine, nici ASF să decidă. Nu se poate face nimic pentru a-l face mai rapid, şi nu există nici un "bug" legat de faptul că cărţile nu sunt aruncate în timp util - nu controlaţi procesul de scăpare a cartonaşelor şi nici ASF. În cel mai bun caz, vei primi în medie 1 scădere în 30 de minute. În cel mai rău caz, nu vei primi niciun card nici timp de 4 ore de la începerea ASF. Ambele situaţii sunt normale şi sunt acoperite în secţiunea **[performanţa](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**.

---

### Agricultura durează prea mult, pot cumva să o accelerez mai mult?

Singurul lucru care afectează în mare măsură viteza agriculturii este selectat **[cardă algoritmul de fermieri](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** pentru instanța botului tău. Toate celelalte aspecte au un efect neglijabil și nu vor face agricultura mai rapidă, în timp ce unele acțiuni cum ar fi lansarea ASF de mai multe ori vor chiar **vor înrăutăți procesul**. Dacă aveţi într-adevăr nevoie să faceţi fiecare secundă din procesul agricol, apoi ASF vă permite să perfecționați câteva variabile agricole de bază, cum ar fi `FarmingDelay` - toate sunt explicate în **[configurația](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Cu toate acestea, după cum am spus, efectul este neglijabil. și alegerea algoritmului de creștere a cardurilor adecvate pentru anumite date este una și singura opțiune esențială care poate afecta foarte mult viteza agriculturii; orice altceva este pur cosmetic. În loc să se îngrijoreze viteza agricolă, doar să lansăm ASF şi să îl lăsăm să îşi facă treaba - vă pot asigura că face acest lucru în cel mai eficient mod în care aş putea veni. Cu cât îți pasă mai puțin, cu atât vei fi mai mulțumit.

---

### ASF a spus însă că agricultura va dura aproape X timp!

ASF vă oferă aproximare aproximativă pe baza numărului de carduri de care aveți nevoie pentru a scădea, și algoritmul ales de dvs. - acesta nu este nicăieri aproape de timpul real pe care îl veți petrece pentru agricultură, care este de obicei mai lung, deoarece ASF presupune numai cele mai bune cazuri și ignoră toate interogările la rețeaua Steam, deconectări de la internet, supraîncărcarea serverelor Steam și la fel. Aceasta ar trebui văzută doar ca un indicator general privind durata de așteptare a ASF la agricultură; foarte adesea în cel mai bun caz, deoarece timpul efectiv diferă, chiar şi în unele cazuri semnificativ. Așa cum s-a subliniat mai sus, nu încercați să ghiciți cât timp va fi cultivat jocul, nu depinde de voi, nici ASF să decidă.

---

### Poate ASF să funcționeze pe androidul/smartphone-ul meu?

ASF este un program C# care necesită implementarea .NET. Android a devenit o platformă validă începând cu .NET 6. , totuși, în prezent există un blocant major în a face ASF să se întâmple pe Android din cauza lipsei **[de ASP. Interval ET disponibil pe site-ul](https://github.com/dotnet/aspnetcore/issues/35077)**. Chiar dacă nu există o opțiune nativă disponibilă, există construcții corecte și funcționale pentru GNU/Linux pe arhitectura ARM, așa că este complet posibil să folosești ceva ca **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** pentru a instala Linux, apoi să utilizaţi ASF în astfel de chroot Linux ca de obicei.

Dacă toate cerinţele ASF sunt îndeplinite, vom lua în considerare eliberarea unui Android oficial construit.

---

### Pot feri obiecte ASF din jocuri de Steam, cum ar fi CS:GO sau Unturnedrept?

**Nu**, este împotriva lui **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** și Valve a afirmat clar că, având în vedere ultimul val de interdicții în favoarea producției de articole TF2. ASF este un program de creștere a cardurilor Steam, nu fermier de obiecte din jocuri - nu are nicio capacitate de a cultiva jocuri de noroc, si nu se intampla sa adaugi o astfel de caracteristica in viitor, intotdeauna din cauza violarii termenilor de utilizare ai Steam. Vă rugăm să nu întrebați despre acest lucru - cel mai bun lucru pe care îl puteți obține este un raport de la un utilizator sărat și aveți probleme. Același lucru este valabil și pentru toate celelalte tipuri de agricultură, cum ar fi agricultura scade, din emisiunile CS:GO. ASF se concentrează exclusiv pe cardurile de tranzacționare cu abur.

---

### Pot alege care jocuri ar trebui să fie cultivate?

**Da**, prin mai multe moduri diferite. Dacă doriți să modificați ordinea implicită a cozii de creștere, apoi pentru asta poate fi folosit `FeringOrders` **[configurația botului](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**. Dacă doriţi să primiţi manual lista neagră pe care jocurile nu sunt cultivate automat, poți utiliza lista neagră inactivă disponibilă cu `fb` **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Dacă doriţi să fercați totul, dar acordați prioritate unor aplicații față de orice altceva, pentru care poate fi folosită lista de priorități inactive cu `fq` **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. And finally, if you want to farm specific games of your choice only, then you can declare `FarmPriorityQueueOnly` in bot's **[`FarmingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)** in order to achieve this, together with adding your selected apps to idle priority queue.

Pe lângă gestionarea modulului de creștere automată a cardurilor care a fost descris mai sus, poți de asemenea să schimbi ASF în modul manual de farmare cu `play` **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, sau folosește alte setări externe pentru erori cum ar fi `GamesPlayedWhileIdle` **[proprietatea bot de configurare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

---

### Nu mă interesează picăturile cu cardul, aș vrea să fac ore jucate în schimb, e posibil?

Da, ASF vă permite să faceți acest lucru cel puțin în mai multe moduri.

Cel mai bun mod de a realiza acest lucru este de a utiliza proprietatea de configurare **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** , care va reda appID-urile alese atunci când ASF nu are carduri de fermă. Dacă doriți să vă jucați jocurile tot timpul, chiar dacă aveți picături de cărți din alte jocuri, apoi îl puteți combina cu **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, astfel ASF va exploata doar acele jocuri pentru cărți pe care le setați explicit sau, alternativ, **[`FeringPausedByDefault`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, care va face ca modulul de creștere a cardurilor să fie întrerupt până când îl veți anula.

Poți folosi, de asemenea, comanda **[`Joacă`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#commands-1)** , ceea ce va face ca ASF să joace jocurile tale selectate. However, keep in mind that `play` should be used only for games you want to play temporarily, as it's not a persistent state, causing ASF to revert back to default state e.g. upon disconnection from Steam network. Prin urmare, vă recomandăm să utilizați `GamesPlayedWhileIdle`, numai dacă doriţi într-adevăr să începeţi jocurile selectate doar pentru o perioadă scurtă de timp, şi apoi reveniţi înapoi la fluxul general.

---

### Sunt utilizator Linux / macOS, va avea ASF jocuri de fermă care nu sunt disponibile pentru sistemul meu de operare? ASF va cultiva jocuri pe 64 de biți când o voi rula pe 32-bit OS?

Da, ASF nici măcar nu se deranjează cu descărcarea fişierelor de joc reale, așa că va funcționa cu toate licențele legate de contul tău Steam, indiferent de orice platformă sau cerințe tehnice. De asemenea, ar trebui să funcționeze pentru jocuri legate de o anumită regiune (jocuri blocate în regiune) chiar și atunci când nu sunteți în regiunea potrivită. deşi nu garantăm acest lucru (a funcţionat ultima dată când am încercat).

---

## Comparație cu instrumente similare

---

### Este ASF similar cu Idle Master?

Singura asemănare este scopul general al ambelor programe, şi anume cultivarea jocurilor Steam pentru a primi picături de card. Toate celelalte, inclusiv metoda propriu-zisă, structura programelor, funcționalitatea, compatibilitatea, algoritmii utilizați, în special codul sursă în sine, este complet diferit, iar cele două programe nu au nimic comun unul cu celălalt, chiar şi fundaţia de bază - IM funcţionează. Cadrul ET, ASF pe .NET (Core). ASF a fost creat pentru a rezolva probleme IM care nu au fost posibile pentru a rezolva cu o simplă editare de cod - acesta este motivul pentru care ASF a fost scris de la zero, fără a folosi o singură linie de cod sau chiar o idee generală din partea IM, pentru că acel cod şi acele idei au fost complet greşite de la început. IM și ASF sunt ca Windows și Linux - ambele sunt sisteme de operare și ambele pot fi instalate pe PC-ul dvs., dar ele nu împărtăşesc aproape nimic între ele, în afară de faptul că servesc unui scop similar.

Acesta este și motivul pentru care nu ar trebui să comparați ASF cu IM, pe baza așteptărilor IMI. Trebuie să trataţi programele ASF şi IM ca programe complet independente, cu propriile seturi exclusive de caracteristici. Unele se suprapun, într-adevăr, și puteți găsi o caracteristică specială în ambele dintre ele, dar foarte rar, întrucât ASF își servește scopul, cu o abordare complet diferită față de IM.

---

### Merită să folosești ASF, dacă folosesc în prezent Idle Master și funcționează bine pentru mine?

**Da**. ASF este mult mai fiabil și include multe funcții încorporate care sunt **cruciale** indiferent de modul în care fermieri, acel IM pur şi simplu nu oferă.

ASF has proper logic for **unreleased games** - IM will attempt to farm games that have cards added already, even if they weren't released yet. Desigur, nu este posibilă cultivarea acestor jocuri până la data lansării, astfel încât procesul tău de creștere va fi blocat. Acest lucru va necesita fie să îl adăugați la lista neagră, așteptați pentru lansare, fie săriți manual. Niciuna dintre aceste soluții nu este bună și toate au nevoie de atenția dumneavoastră - ASF sare automat peste cursele jocurilor nelansate (temporar), şi se întoarce la ele mai târziu, evitând complet problema şi tratând-o în mod eficient.

ASF are, de asemenea, logica corectă a videoclipurilor din seria ****. Există multe videoclipuri pe Steam care au carduri, dar sunt anunțate cu un `appID` greșit pe pagina de insigne, cum ar fi **[Dublu Fine Adventure](https://store.steampowered.com/app/402590)** - IM va fi fals fericit `appID`, care nu va produce nicio picătură și nici un proces blocat. Încă o dată, va trebui să o listați pe lista neagră sau să săriți manual, ambele necesitând atenție. ASF descoperă automat `appID` corespunzător pentru agricultură, ceea ce duce la picături cu cartele.

În plus, ASF este **mult mai stabil şi mai fiabil** când vine vorba de probleme de reţea şi Steam - funcţionează de cele mai multe ori şi nu necesită atenţia ta deloc configurat, în timp ce IM se întrerupe adesea pentru multe persoane, necesită soluţii suplimentare sau pur şi simplu nu funcţionează oricum. De asemenea, depinde în totalitate de clientul tău Steam, ceea ce înseamnă că nu poate funcționa când clientul tău Steam se confruntă cu probleme grave. ASF funcționează corect atât timp cât se poate conecta la rețeaua Steam și nu necesită rularea sau chiar instalarea clientului Steam.

Acelea sunt de 3 **foarte important** arată de ce ar trebui să iei în considerare utilizarea ASF, întrucât aceste cartonaşe afectează în mod direct pe toată lumea şi nu se poate spune că „acest lucru nu mă ia în considerare”; din moment ce toată lumea are de suferit de pe urma întreținerii Steam și a viciilor. Există zeci de motive în plus de care puteţi învăţa în restul FAQ din ce în ce mai importante. Atât de curând vorbind, **da**, trebuie să utilizați ASF chiar și atunci când nu aveți nevoie de o funcție ASF suplimentară disponibilă în comparație cu IM.

În plus, administrarea i.m. este întreruptă în mod oficial şi se poate întrerupe complet în viitor; fără ca cineva să-l deranjeze, având în vedere existenţa unor soluţii mult mai puternice (nu doar ASF). IM deja nu funcţionează pentru mulţi oameni, şi acel număr creşte doar şi nu scade. Ar trebui să evitaţi să utilizaţi în primul rând un software învechit, nu numai pe IM, ci şi pe toate celelalte programe învechite. Niciun mentor activ înseamnă că nimănui nu îi pasă dacă funcționează sau nu și **nimeni nu este responsabil pentru funcționalitatea sa**, care este o chestiune esențială din punctul de vedere al securității. Este suficient să existe un bug critic care să provoace probleme reale infrastructurii Steam - nimeni nu îl repară, Steam poate emite un alt val de interdicții în care vei fi lovit fără a fi conștient de faptul că aceasta este o problemă, cum s-a întâmplat deja cu oamenii care folosesc, ghiciţi ce versiune învechită a ASF.

---

### Ce caracteristici interesante ASF oferă Idle Master nu?

Depinde de ceea ce consideri a fi interesant pentru tine. Dacă plănuiești să cultivi mai multe conturi, atunci răspunsul este deja evident deoarece ASF îți permite să le cultivi pe toate cu o singură soluție superioară, economisirea de resurse, dificultăţi şi probleme de compatibilitate. Cu toate acestea, dacă pui această întrebare, cel mai probabil nu ai această nevoie specială, Deci să evaluăm alte beneficii care se aplică unui singur cont folosit în ASF.

În primul rând, aveți unele caracteristici integrate menționate **[mai sus](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** care sunt esențiale pentru agricultură indiferent de scopul dumneavoastră final; și foarte adesea doar acest lucru este suficient pentru a lua în considerare utilizarea ASF. Dar știți deja asta, așa că haideți să trecem la câteva caracteristici mai interesante:

- **Puteţi face fermă offline** (`OnlineStatus` în `Setare offline`. Agricultura offline face posibilă omiterea completă a stării tale de Steam în joc, care vă permite să creați cu ASF în timp ce afișați "Online" pe Steam în același timp, fără ca prietenii tăi să observe că ASF joacă un joc în numele tău. Aceasta este o caracteristică superioară, deoarece îți permite să rămâi online în clientul tău Steam, în timp ce nu îți enervezi prietenii cu schimbări constante în joc, sau să îi inducă în eroare gândindu-te că joci un joc în timp ce în realitate nu ești. Acest punct în sine merită să folosești ASF dacă îți respecți proprii prieteni, dar este doar începutul. De asemenea, este frumos să reții că această caracteristică nu are nimic de-a face cu setările de confidențialitate Steam - dacă lansezi jocul chiar tu, apoi vei arăta cum se cuvine prietenilor tăi, făcând doar parte ASF invizibilă și neafectând deloc contul tău.

- **Puteți sări peste jocurile rambursabile** (`SkipRefundableGames` în funcția `FeringPreferințe`). ASF are logica încorporată corectă pentru jocuri rambursabile și puteți configura ASF pentru jocuri nerambursabile automat. Acest lucru îți permite să te evaluezi dacă jocul tău cumpărat recent de la magazinul Steam merită banii tăi, fără ca ASF să încerce să renunțe la carduri cât mai curând posibil. Dacă îl joci timp de 2 ore sau 2 săptămâni de la cumpărare, apoi ASF va continua cu acel joc deoarece nu mai poate fi rambursat. Până atunci, aveţi control complet dacă vă place sau nu şi puteţi rambursa cu uşurinţă dacă este necesar, fără a fi nevoit să lista neagră manual acel joc sau să nu folosească ASF pe toată durata acestuia.

- **Poţi sări peste jocurile nejucate** (`SkipUnplayedGames` în funcția `FermierePreferinţe`). ASF are logica încorporată adecvată pentru ore în jocuri și puteți configura ASF pentru a nu completa jocurile nejucate automat. Acest lucru vă permite să vă controlați jocurile pe care le jucați și le farmați, fără a fi nevoie să le listați manual pe toate sau să omiteți folosind ASF în întregime.

- **Puteţi marca automat elementele noi ca fiind primite** (`BotBehaviour` of `DismissInventoryNotifications`). Agricultura cu ASF va duce la primirea de noi picături cu cardul în contul tău. Știți deja că acest lucru se va întâmpla, așa că lăsați ASF să șteargă notificarea inutilă pentru dvs., asigurarea faptului că numai lucruri importante vă vor atrage atenţia. Bineînțeles, numai dacă vrei.

- **Puteți personaliza ordinea agricolă preferată cu mai multe opțiuni disponibile** (`Caracteristica Ferma`. Poate că vreți să vă faceți mai întâi jocurile cumpărate recent? Sau pe cele mai vechi? În funcție de numărul de scăderi ale numărului de cărți? Niveluri insigne pe care le-ai creat deja? Ore jucate? Alfabetic? Conform ID-urilor? Sau poate complet aleatoriu? Asta depinde în întregime de voi.

- **ASF vă poate ajuta să completați seturile** (`TradingPreferences` cu `SteamMatcher`). Cu un pic mai avansat, poți transforma ASF-ul tău în bot complet recomandat care va accepta automat **[STM](https://www.steamtradematcher.com)** oferte, te ajută în fiecare zi să potrivești seturile tale fără nicio interacțiune a utilizatorului. ASF include chiar și propriul său modul ASF 2FA care vă permite să importați autentificatorul mobil Steam și vă permite să automatizați complet întregul proces cu acceptarea confirmărilor de asemenea. Sau, poate vrei să accepți manual și să lași ASF doar să pregătească acele tranzacții pentru tine? Încă o dată, este la latitudinea dumneavoastră să decideţi.

- **ASF poate răscumpăra cheile în fundal pentru tine** (**[revendicare jocuri de fundal](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. Poate ai o sută de chei din diferite pachete pe care eşti prea leneş să te revendici, mergând prin grămadă de ferestre și convenind asupra termenilor și condițiilor Steam iar și iar. De ce să nu lipiți lista de chei în ASF și să o lăsați să își facă treaba? ASF va răscumpăra automat toate acele chei din fundal, cu condiția să aveți o ieșire corespunzătoare pentru a vă anunța cum s-a terminat fiecare răscumpărare. Mai mult decât atât, dacă ai sute de chei, ai garanția că vei limita rata de schimb de la Steam mai devreme sau mai târziu și ASF știe de asemenea despre asta, va aștepta cu răbdare ca limita de viteză să dispară și va relua unde a plecat.

Acum am putea continua cu **[ASF wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**, indică fiecare caracteristică a programului, dar trebuie să trasăm undeva o linie. Acesta este el, aceasta este o listă de caracteristici de care vă puteți bucura ca utilizator ASF, unde doar una dintre acestea ar putea fi considerată cu uşurinţă un motiv major de a nu privi niciodată înapoi, şi de fapt am enumerat **o mulţime** de ele, cu şi mai multe despre care puteţi învăţa pe restul wiki-ului nostru. Ah da, și nici măcar nu am intrat în detalii cu lucruri cum ar fi API-ul ASF care vă permit să vă scrieți propriile comenzi, sau un management minunat al boților, pentru că am vrut să îl păstrăm simplu.

---

### ASF este mai rapid decât Idle Master?

**Da**, deși explicația este destul de complicată.

La fiecare proces nou a dat naștere și s-a încheiat în sistemul dvs., Clientul cu aburi trimite automat o cerere care conține toate jocurile pe care le jucați în prezent - în acest fel rețeaua de aburi poate calcula orele și face cartele să cadă. Cu toate acestea, rețeaua de aburi contorizează timpul jucat în intervale de 1 secundă, iar trimiterea de noi solicitări resetează starea curentă. Cu alte cuvinte, dacă ai fi spawn/ucis un nou proces la fiecare 0,5 secunde, nu ai fi aruncat niciodată un card pentru fiecare 0. al doilea client Steam ar trimite o nouă cerere și o rețea de aburi nu ar număra nici măcar o secundă din timpul de joc. Mai mult, din cauza modului în care funcționează sistemul de operare, este destul de frecvent să vezi că noile procese sunt generate/terminate fără ca tu să faci nimic, așa că chiar dacă nu faci nimic pe PC-ul tău - încă mai sunt multe procese care funcționează în fundal, se crează/se termină tot timpul. Idle master este bazat pe Steam client, deci acest mecanism te afectează dacă îl folosești.

ASF nu se bazează pe clientul de abur, ci are propria implementare din partea clientului de aburi. Datorită acestui lucru, ASF nu creează niciun proces, dar de fapt trimiţând o cerere reală reţelei de abur că am început să jucăm un joc. Aceasta este aceeaşi cerere care va fi trimisă de clientul Steam dar pentru că avem control efectiv asupra clientului de abur ASF, nu trebuie să declanşăm noi procese, şi nu imităm clientul cu aburi în ceea ce priveşte solicitarea de trimitere la fiecare proces se schimbă, astfel încât mecanismul explicat mai sus nu ne afectează. Mulţumită acestui lucru, nu am întrerupt niciodată acel interval de o secundă pe straturile web ale aburului, iar acest lucru ne sporeşte viteza de creştere.

---

### Dar este diferenţa cu adevărat observabilă?

Nu. Întreruperile care se petrec cu clientul normal de abur şi cu stăpânul de ralanti, au un efect neglijabil asupra picăturilor de carte, deci nu este nicio diferență vizibilă care ar face ASF superior.

However, there **is** a difference, and you can clearly notice that, as depending on how busy your OS is, cards **will** drop faster, from a few seconds to even a few minutes, if you're extremely unlucky. Deși nu aș lua în considerare utilizarea ASF doar pentru că scade cărțile mai repede, întrucât atât ASF cât și Idle Master sunt afectate de modul în care funcționează Internetul de Steam, ASF interacționează mai eficient cu rețeaua de abur, în timp ce Idle Master nu poate controla ce face de fapt clientul de aburi (deci nu este vina lui Idle Master, ci clientul cu abur).

---

### ASF poate cultiva mai multe jocuri simultan?

**Da**, deși ASF știe mai bine când să utilizeze această caracteristică, pe baza algoritmului de creștere</a></strong> selectat **

carduri de farming. Cardul scade rata atunci când farmarea mai multor jocuri este aproape de zero, Acesta este motivul pentru care ASF folosește mai multe jocuri din agricultură doar ore pentru a depăși `HoursUntilCardDrops` mai repede, pentru jocuri de până la `32` în același timp. Acesta este și motivul pentru care ar trebui să vă concentrați pe partea de configurare a ASF, și lăsați algoritmii să decidă care este cel mai bun mod de a atinge obiectivul - ceea ce credeți că este corect, nu este neapărat corect în realitate, cultivarea simultană a mai multor jocuri nu vă va oferi nici un fel de picături cu cartele.</p> 



---



### ASF poate sări rapid prin jocuri?

**Nu**, ASF nu acceptă, nici nu încurajează utilizarea **[Steam](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance#steam-glitches)**.



---



### ASF poate juca automat fiecare joc cu X ore înainte ca cardurile să fie adăugate?

**Nu**, întregul punct al schimbării sistemului cărţilor Steam a fost să lupte cu statistici false şi jucători fantomă. ASF nu va contribui la acest lucru mai mult decât este necesar, adăugând că această caracteristică nu este planificată și nu va avea loc. În cazul în care jocul dvs. primește cardul în mod obișnuit, ASF îl va cultiva cât mai curând posibil.



---



### Pot să joc cât timp ASF cultivă?

**Nu**. ASF, spre deosebire de alte instrumente care se integrează cu clientul tău Steam, are inclusă implementarea independentă a acelui client, și rețeaua Steam permite doar lui **un client Steam la un moment dat** să joace un joc. Cu toate acestea, puteți deconecta ASF oricând vă place pornind un joc (și apăsând "OK" când sunteți întrebat dacă rețeaua Steam ar trebui să deconecteze alt client) - ASF va aștepta cu răbdare până când ați terminat de redat, și reluați procesul după aceea. Alternativ, poți continua să te joci în modul offline oricând, îți place, dacă acest lucru este satisfăcător pentru tine.

Ține cont că rata cărților scade atunci când joci mai multe jocuri este oricum aproape, prin urmare, nu există beneficii directe ca urmare a acestui lucru cu alte instrumente, cu toate că există beneficii importante de a nu interveni în alte jocuri lansate cu ASF, ceea ce este esențial. . VAC înţelept.



---



## Securitate / Confidențialitate / VAC / Ban / ToS



---



### Pot obține interdicția VAC pentru utilizarea acestui lucru?

Nu, nu este posibil pentru că ASF (spre deosebire de alte instrumente, cum ar fi Idle Master, SIG sau SAM) nu interferează în niciun fel cu clientul cu aburul și nici cu procesele acestuia. Este fizic imposibil să obții interdicția VAC pentru utilizarea ASF, chiar și în timpul jocului pe servere securizate cât timp ASF rulează - deoarece **ASF nici măcar nu necesită instalarea unui client Steam la un nivel de** pentru a funcționa corect. ASF este unul dintre puținele programe agricole care pot garanta în prezent că nu conțin CAV.



---



### Poate folosi ASF mă împiedică să joc pe servere VAC, conform declarației **[aici](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**?

ASF nu necesită rularea clientului Steam sau chiar instalarea acestuia. According to this concept, it should **not** cause any VAC-related issues, because ASF guarantees lack of interfering with Steam client and all its processes - this is the main point when talking about VAC-free guarantee that ASF offers.

Conform utilizatorilor şi din cunoştinţele mele, acest lucru se întâmplă chiar în prezent, întrucât nimeni nu a raportat probleme precum cele menționate în linkul de mai sus în timp ce utilizau ASF. Nu am putut reproduce problema de mai sus și cu ASF, în timp ce o reproducem în mod clar cu Idle Master.

Cu toate acestea, aveți în vedere faptul că Valve ar putea încă adăuga ASF pe lista neagră la un moment dat, dar este o absurditate ca și cum ar face asta, încă poți juca jocuri securizate cu VAC de pe calculatorul tău și poți folosi ASF în același timp. . pe serverul dvs., deci sunt destul de sigur că știu foarte bine că ASF nu ar trebui să fie un VAC suspect, și nu ne vor face viața mai grea listând ASF fără niciun motiv. Totuși, în cel mai rău caz nu vei putea juca, cum este menționat mai sus, pentru că garantarea fără FACV a ASF este încă aici, indiferent dacă Steam listează pe lista neagră ASF, sau nu (și încă poți lansa ASF pe orice altă mașină fără ca clientul Steam să fie instalat deloc). În acest moment nu este nevoie să facem nimic din toate acestea şi să sperăm că va rămâne aşa.



---



### Este sigură?

Dacă întrebați dacă ASF este sigur ca un software, ceea ce înseamnă că nu va provoca nicio deteriorare a calculatorului, nu-ți va fura datele private, nu va instala viruși sau alte lucruri de genul acesta - este în siguranță. ASF nu prezintă malware, furt de date, minerii criptovalutari și oricare (și toți) alt comportament îndoielnic care poate fi considerat răuvoitor sau nedorit de către utilizator. În plus, avem o secțiune dedicată **[de comunicare la distanță](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** care acoperă politica noastră de confidențialitate și comportamentul ASF care depășește ceea ce ați configurat programul pentru a vă face singur.

Codul nostru este open-source, binarele distribuite sunt întotdeauna compilate din **[surse publice](https://en.wikipedia.org/wiki/Open-source_software)** de **[sisteme automate şi de încredere de integrare continuă](https://en.wikipedia.org/wiki/Build_automation)**, şi nici măcar dezvoltatorii înşişi. Fiecare construcție este reproductibilă urmărind scriptul nostru de construcții și va rezulta exact în același , **[deterministic](https://en.wikipedia.org/wiki/Deterministic_system)** IL (mari) cod. Dacă din orice motiv nu ai încredere în construcțiile noastre, poți oricând să compilezi și să folosești ASF de la sursă, incluzând toate bibliotecile pe care le folosește ASF (cum ar fi SteamKit2), care sunt de asemenea open-source.

În cele din urmă, este întotdeauna o chestiune de încredere pentru dezvoltatorul/dezvoltatorii aplicației tale, astfel încât ar trebui să vă decideți dacă considerați ASF sigur sau nu, sprijinind eventual decizia dumneavoastră cu argumente tehnice specificate mai sus. Nu credeți orbește doar pentru că am spus acest lucru - verificați-vă, deoarece acesta este singurul mod de a fi sigur.



---



### Pot fi interzis pentru asta?

Pentru a răspunde la această întrebare, ar trebui să aruncăm o privire mai atentă la **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Steam doesn't prohibit using of multiple accounts, in fact, **[it allows it](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)** implying that you can use same mobile authenticator on more than one account. Cu toate acestea, nu permite partajarea conturilor cu alți oameni, dar nu facem asta aici.

Singurul punct real care ia în considerare ASF este următorul:


> Nu puteți folosi Cheats, software de automatizare (bot-uri), mod-uri, hack-uri sau orice alt software de terță parte neautorizat, pentru a modifica sau automatiza orice proces de abonament Marketplace

Întrebarea este care este de fapt procesul abonamentului pe piaţă. După cum putem citi:



> Un exemplu de piață de abonamente este piața comunitară a aburului

Nu modificăm sau automatizăm procesul de piaţă a abonamentelor, dacă prin abonament marketplace înţelegem piaţa comunitară a aburului sau magazinul de aburi. Totuşi...



> Valva poate anula în orice moment contul sau orice abonament particular în cazul în care (a) Valva încetează să mai furnizeze astfel de abonamente abonaților situați în mod similar, în general, sau (b) încălcați orice termeni ai acestui acord (inclusiv orice termeni de abonament sau reguli de utilizare).

Prin urmare, la fel ca în cazul fiecărui program Steam, ASF nu este autorizat de Valve și nu pot garanta că nu veți fi suspendat dacă Valve decide brusc că interzice conturile folosind ASF acum. Acest lucru este foarte puțin probabil, având în vedere faptul că ASF este utilizat în mai mult de câteva milioane de conturi de Steam; de la prima sa lansare, care a avut loc cu peste 10 ani în urmă - dar încă o posibilitate, indiferent de probabilitatea reală.

Mai ales deoarece:


> În ceea ce privește toate abonamentele, conținut și servicii care nu sunt create de Valve, Valve nu afișează un astfel de conținut terț, disponibil pe Steam sau prin alte surse. Valva nu își asumă nicio responsabilitate sau răspundere pentru conținutul acestor părți terțe. Unele programe informatice ale aplicațiilor terțe pot fi utilizate de întreprinderi în scopuri comerciale - cu toate acestea, puteți achiziționa astfel de programe numai prin intermediul Steam pentru uz personal personal.

Cu toate acestea, Valve recunoaşte clar că "Steam idlers" există, aşa cum a declarat **[aici](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**, deci dacă m-ai întrebat. Sunt destul de sigur că dacă nu ar fi fost în regulă cu ei, ar fi făcut deja ceva în loc să arate că ar putea cauza probleme VAC. Cuvântul cheie este **Steam** , de exemplu ASF, și nu **joc** idlers.

Vă rugăm să reţineţi că mai sus este doar interpretarea noastră de **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** şi diferite puncte - ASF este licenţiat în conformitate cu Apache 2. Licență, care precizează în mod clar:



```
Cu excepția cazului în care legea aplicabilă sau este de acord în scris, software-ul
distribuit sub licență este distribuit pe un BASIS "AS IS",
FĂRĂ ATENȚIILE SAU CONDIȚIILE DE ORICE BIND, fie expres, fie implicit.
```


Folosești acest software pe propriul risc. Este extrem de improbabil să primești interdicție pentru asta, dar dacă o faci, poți da vina doar pe tine însuți.



---



### A fost interzis cineva pentru ea?

**Da**, am avut cel puţin câteva incidente până acum care au avut ca rezultat suspendarea Steam. Dacă ASF însuși a fost cauza principală sau nu este o poveste complet diferită, pe care probabil nu o vom putea ști niciodată.

Primul caz a implicat un tip cu peste 1000 de roboți cărora li s-a interzis accesul la tranzacționare (împreună cu toți roboții), cel mai probabil din cauza utilizării excesive de `loot ASF` executat la toți boții deodată, sau alte tranzacții suspecte într-o perioadă foarte scurtă de timp.



> Salut XXX, Iti multumim ca ai contactat serviciul Steam. Se pare că acest cont a fost folosit pentru a administra o rețea de conturi de boți. Punterea este o încălcare a Acordului de abonat la Steam.

Vă rugăm, folosiți un bun simț și nu presupuneți că puteți face lucruri atât de nebune doar pentru că ASF vă permite să faceți asta. `loot ASF` pe peste 1 k de boți poate fi considerat cu ușurință un atac **[DDoS](https://en.wikipedia.org/wiki/DDoS)** , şi personal nu sunt şocat de faptul că cineva a fost banat pentru aşa ceva. Menține un minim de utilizare echitabilă în ceea ce privește serviciul Steam și **cel mai probabil** vei fi bine.

Al doilea caz a fost legat de un tip cu peste 170 de roboți care a fost interzis în timpul Vânzării de Iarnă Steam 2017.



> Contul tău a fost blocat pentru încălcarea acordului abonatului Steam. Judecând după burse şi alţi factori, acest cont a fost folosit pentru a colecta în mod ilegal carduri colectabile pe Steam, precum şi activităţi conexe şi nu doar activităţi comerciale. Contul a fost blocat permanent și Asistența Steam nu poate oferi sprijin suplimentar în această problemă.

Acest caz este încă o dată foarte greu de analizat, din cauza unui răspuns vag, din partea sprijinului Steam, care abia oferă detalii. Bazându-mă pe gândurile mele personale, acest utilizator a schimbat probabil carduri Steam pentru un fel de bani (nivelul bot-ului? sau într-un alt mod a încercat să retragă pe Steam. În cazul în care nu știți, acest lucru este ilegal și conform lui **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Nu suntem în măsură să îți spunem ce poți face cu cardurile de tranzacționare obținute prin ASF - dar utilizatorul în cauză nu doar a creat insigne cu ei.

Al treilea caz a implicat un utilizator cu 120 de boți cărora le este interzis accesul pentru încălcarea **[Steam online comportament](https://store.steampowered.com/online_conduct?l=english)**.



> Salut XXX, Iti multumim ca ai contactat serviciul Steam. Acest cont, precum și altele, au fost utilizate pentru inundarea infrastructurii noastre de rețea, ceea ce reprezintă o încălcare a comportamentului online Steam. Contul a fost blocat permanent și Asistența Steam nu poate oferi sprijin suplimentar în această problemă.

Acest caz este puțin mai ușor de analizat datorită detaliilor suplimentare furnizate de utilizator. Se pare că utilizatorul utiliza **o versiune ASF foarte învechită** care a inclus o eroare care a cauzat ASF să trimită un număr excesiv de cereri către serverele Steam. Problema în sine nu a existat la început, dar a fost activată datorită schimbării de rupere a Steam care a fost rezolvată în versiunea viitoare. **ASF este suportat doar în [ultima versiune stabilă](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) lansată pe GitHub**.

Nu poți presupune că o versiune învechită a ASF va funcționa la fel cum lucra pentru totdeauna, mai ales pentru că Steam se schimbă în mod constant, indiferent dacă vă place sau nu. Dacă astfel de lucruri se întâmplă la nivel global, este rapid modificat şi eliberat pentru toţi utilizatorii ca un bugfix. Din motive evidente, supapa nu va interzice brusc peste un milion de utilizatori ASF din cauza sau a greșelii noastre. Cu toate acestea, dacă renunțați intenționat la utilizarea ASF actualizat, apoi, prin definiție, ești într-o minoritate foarte mică de utilizatori care sunt **expuși la incidente precum aceste** din cauza **fără suport**, pentru că nimeni nu urmărește versiunea dvs. învechită de ASF, nimeni nu îl repară și nimeni nu se asigură că nu vei fi absolut interzis doar lansându-l. **Vă rugăm să folosiți software actualizat**, nu doar ASF, ci și toate celelalte aplicații.

Cel mai recent caz a avut loc în jurul lunii iunie a anului 2021, potrivit utilizatorului:



> Folosind programul tău, am făcut pachete de rapel cu 28 de conturi pentru 3 ani și 128 de conturi pentru ultimele 6 luni. Am fost online cu maxim 15 conturi simultan pentru a face pachete de rapel și pentru a le trimite către contul principal. Luna trecută, am crescut numărul de conturi online simultan la 20 şi 1 săptămână după aceea, toate conturile mele au fost interzise. Acest e-mail nu este de a vă învinovăţi, dimpotrivă, am fost întotdeauna conştient de consecinţe. Vroiam să ştiţi ce tipuri de comportament au ca rezultat o interdicţie permanentă.

Este greu de spus dacă creșterea conturilor concurente online a fost cauza directă a interdicției, Nu aș conta pe asta, în schimb cred că doar numărul de conturi a fost principalul vinovat, creșterea gradului de convalență a conturilor online a atras probabil atenția asupra utilizatorului în cauză, întrucât are în mod clar mult mai mulți roboți decât recomandarea noastră.



---

Toate incidentele de mai sus au un singur lucru în comun - ASF este doar o unealtă și este decizia **** cum o veți folosi. Nu vi se interzice utilizarea ASF în mod direct, ci pentru **cum** îl utilizați. Poate fi un instrument de ajutor pentru agricultură doar un singur cont, sau o imensă rețea agricolă realizată din mii de boți. În orice caz, nu vă ofer sfaturi legale și ar trebui să vă decideți despre utilizarea ASF de la bun început. Nu ascund nicio informație care te-ar putea ajuta, de ex. faptul că ASF a interzis anumite persoane (și în ce context), pentru că nu am niciun motiv - este alegerea ta ce vrei să faci cu aceste informaţii.

If you ask me - use some common sense, avoid owning more bots than our recommendation, do not send hundreds of trades at the same time, always use up-to-date ASF version and you _should_ be fine. Fiecare incident de această natură pentru **un motiv oarecare** s-a întâmplat întotdeauna persoanelor care nu au luat în considerare recomandările noastre, cele mai bune practici și sugestii, crezând că ei știu mai bine decât noi. . câți roboți pot alerga. Fie că este doar o coincidență sau un factor real, este la latitudinea ta să decidi. Nu oferim sfaturi juridice, doar spunându-ți gândurile noastre că poți găsi de folos, fie să nu le ia în considerare în întregime şi să nu funcţioneze decât pe baza faptelor menţionate anterior.



---



### Ce informații ASF despre confidențialitate?

Puteţi găsi explicaţii detaliate în secţiunea **[de comunicare la distanţă](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. Ar trebui să-l revizuiești dacă îți pasă de confidențialitatea ta, de exemplu dacă te întrebi de ce sunt utilizate conturile ASF în grupul nostru Steam. ASF nu colectează nicio informație sensibilă și nu o partajează cu terți.



---



## Diverse



---



### Folosesc sisteme de operare nesuportate, cum ar fi Windows-ul de 32 biți, mai pot folosi cea mai recentă versiune de ASF?

Da, și această versiune nu este în niciun caz acceptată, pur și simplu nu este construită oficial. Vezi secțiunea **[compatibilitate](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** pentru varianta generică. ASF nu are nicio dependență puternică de OS, și poate funcționa oriunde ai putea să lucrezi. ET runtime, care include 32-bit Windows, chiar dacă nu există un pachet `win-x86` specific OSCE de la noi.



---



### ASF este grozav! Pot face o donație?

Da, și suntem foarte fericiți să auzim că vă bucurați de proiectul nostru! Puteți găsi diverse posibilități de donare la fiecare **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** și, de asemenea, **[pe pagina principală](https://github.com/JustArchiNET/ArchiSteamFarm)**. Este frumos de observat că, pe lângă donațiile generice de bani, acceptăm și articole Steam, așa că nimic nu te oprește să donezi skin-uri, chei sau o mică parte din cărțile pe care le-ai cultivat cu ASF dacă dorești. Îți mulțumim în avans pentru generozitatea ta!



---



### Folosesc PIN parental Steam pentru a-mi proteja contul, trebuie să-l introduc undeva?

Da, trebuie să îl setați în proprietatea de configurare a botului `SteamParentalCode`. Acest lucru se datorează în principal faptului că ASF accesează multe părți protejate ale contului tău Steam și este imposibil ca ASF să funcționeze fără el.



---



### Nu vreau ca ASF să adune niciun joc în mod implicit, dar vreau să folosesc funcții ASF suplimentare. Este acest lucru posibil?

Da, dacă vrei doar să începi ASF cu modulul de creștere a cardurilor pauză, poți seta `FeringPausedByImplicit` în `FeringPreferințe` proprietatea botului pentru a realiza acest lucru. This will allow you to `resume` it during runtime.

Dacă doriţi să dezactivaţi complet cardurile modul de creştere şi să vă asiguraţi că nu va rula niciodată fără să spuneți altfel în mod explicit, apoi recomandăm să se seteze `FarmPriorityQueueOnly` în secţiunea `Fermiere Preferinţe`, care, în loc să îl pauze, va dezactiva complet ferma până când vei adăuga jocurile la lista de aşteptare fără prioritate.

With cards farming module paused/disabled, you can make use of extra ASF features, such as `GamesPlayedWhileIdle`.



---



### ASF poate minimiza în tăviță?

ASF este o aplicație de consolă, nu există nicio fereastră care să fie minimizată, deoarece fereastra este creată pentru tine de sistemul de operare. Cu toate acestea, poți folosi orice unealtă terță parte capabilă să facă asta, cum ar fi **[RBTray](https://github.com/benbuck/rbtray)** pentru Windows, sau **[ecranul](https://linux.die.net/man/1/screen)** pentru Linux/macOS. Acestea sunt doar exemple, există multe alte aplicații cu funcționalitate similară.



---



### Utilizarea ASF păstrează eligibilitatea pentru primirea pachetelor de rapel?

**Da**. ASF folosește aceeași metodă de conectare la rețeaua Steam ca și clientul oficial, Prin urmare, Comisia conserve și capacitatea de a primi ambalaje de rapel pentru conturile care sunt utilizate în ASF. Mai mult, păstrarea acestei abilități nici măcar nu necesită logare în comunitatea Steam, astfel încât să puteți utiliza în siguranță `OnlineStatus` în setarea `Offline` dacă doriți.



---



### Există vreo modalitate de a comunica cu ASF?

Da, în mai multe moduri. Vezi secțiunea **[de comenzi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** pentru mai multe informații.



---



### Aș vrea să ajut cu traducerea ASF, ce trebuie să fac?

Vă mulțumim pentru interesul dvs! Poți găsi toate detaliile în secțiunea de localizare **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)**.



---



### Am un singur cont (principal) adăugat la ASF, pot emite în continuare comenzi prin chat-ul cu aburi?

**Da**, este explicat în sectiunea **[comenzile](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#notes)**. Poți face acest lucru prin conversația de grup Steam, deși folosești **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** îți poate fi mai ușor pentru tine.



---



### ASF pare să funcționeze, dar nu primesc nicio picătură de carte!

Rata de creştere a cărţilor diferă de la joc la joc, după cum puteţi citi în **[performanţă](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Durează un timp, de obicei **mai multe ore pe joc**, și nu ar trebui să te aștepți ca cărțile să scadă în câteva minute de la lansarea unui program. Dacă puteți vedea că ASF verifică activ starea cardurilor și comută jocul după ce cel actual este complet cultivat, atunci totul funcționează bine. Este posibil ca ați activat o opțiune cum ar fi `DismissInventoryNotifications` of `BotBehaviour` care respinge automat notificările de inventar. Vezi **[configuraţia](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** pentru detalii.



---



### Cum să opresc complet procesul ASF pentru contul meu?

Pur și simplu închide procesul ASF, de exemplu făcând clic pe [X] pe Windows. Dacă dorești în schimb să oprești un anumit bot ales de tine, dar să îi păstrezi pe ceilalți care rulează, apoi aruncați o privire la `Activat` **[configurația botului](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**, sau `oprește` Comanda **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. If you instead want to stop automatic farming process, yet keep ASF running for your account, then that's what `FarmingPausedByDefault` option of `FarmingPreferences` in **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** and `pause` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** is for.



---



### Câți boți pot alerga cu ASF?

ASF ca program nu are o limită superioară dură de cazuri de bot, astfel încât să puteți rula la fel de mult pe cât aveți memorie pe calculator, cu toate acestea, ești încă limitat de rețeaua Steam și de alte servicii Steam. În prezent poți alerga până la 100-200 de boți cu un singur IP și o singură instanță ASF. Este posibil să rulezi mai mulți roboți cu mai multe IP-uri și mai multe instanțe ASF, lucrând în jurul limitărilor IP. Rețineți că dacă folosiți acea cantitate mare de boți, ar trebui să le controlați singur, astfel încât să se asigure că toţi se autentifică şi lucrează în acelaşi timp. ASF nu a fost reglat pentru acel număr uriaș de boți, si regula generala aplica ca **cu cat aveti mai multi boti, cu atat mai multe probleme veti întâlni**. De asemenea, observați că limita de mai sus depinde, în general, de mulți factori interni; este o aproximare mai degrabă decât o limită strictă - cel mai probabil vei putea rula mai mulți boți/mai puțin decât cei specificați mai sus.

Echipa ASF sugerează **deținerea de** până la **10 conturi Steam în total**, și, prin urmare, în total, până la **10 boți în total**. Orice de mai sus nu este acceptat şi făcut pe propriul risc, în ciuda sugestiilor noastre făcute aici. Această recomandare se bazează pe orientările interne privind valva, precum și pe propriile noastre sugestii. Dacă vei respecta această regulă sau nu este alegerea ta, ASF ca instrument nu va fi împotriva voinței tale, chiar dacă va duce la suspendarea conturilor tale de Steam pentru acest lucru. Prin urmare, ASF vă va afișa un avertisment dacă veți depăși ceea ce recomandăm, dar vă permite în continuare să suportaţi orice doriţi pe propriul risc şi pe lipsa sprijinului nostru.



---



### Pot rula mai multe instanțe ASF atunci?

Puteți rula cât mai multe instanțe ASF pe o mașină cum doriți, presupunând că fiecare instanță are propriul său director și propriile configurații, iar contul utilizat într-o instanță nu este utilizat în alta. Cu toate acestea, întrebaţi-vă de ce doriţi să faceţi acest lucru. ASF este optimizat pentru a gestiona mai mult de o sută de conturi în același timp, și lansarea acelei sute de roboți în propriile instanțe ASF degradează performanța; ia mai multe resurse OS (cum ar fi CPU și memorie) și cauzează posibile probleme de sincronizare între instanțele ASF independente, având în vedere că ASF este forțat să partajeze limitele sale cu alte cazuri.

Prin urmare, sugestia mea **puternică** este, întotdeauna rulează maxim o instanță ASF pe o IP/interfață. Dacă ai mai multe IP-uri/interfețe, poți rula mai multe instanțe ASF, cu fiecare instanță folosind propria sa interfață IP/sau setare unică `WebProxy`. Dacă nu faceți, lansarea mai multor instanțe ASF este complet inutilă, deoarece nu veți câștiga nimic lansând mai mult de 1 instanță la un singur IP/interfață. Steam nu îți va permite în mod magic să rulezi mai mulți roboți doar pentru că i-ai lansat într-un alt exemplu ASF, ASF nu te limitează la început.

Desigur, există încă cazuri de utilizare valabile pentru mai multe instanțe ASF pe aceeași interfață de rețea. cum ar fi găzduirea serviciului ASF pentru prietenii tăi cu fiecare prieten care are propria sa instanță ASF unică pentru a garanta izolarea între boți și chiar procesele ASF, cu toate acestea, nu eludați limitările de Steam în acest fel, acesta este un scop complet diferit.



---



### Care este sensul statutului când revendici o cheie?

Starea indică cum s-a dovedit încercarea de răscumpărare. Sunt posibile numeroase statute diferite, cele mai frecvente includ:

| Status               | Descriere                                                                                                                                                                                                                                    |
| -------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Nimic                | Status "OK" care indică succesul - cheia a fost cu succes răscumpărată.                                                                                                                                                                      |
| Expirare             | Rețeaua Steam nu a răspuns în timp dat, nu știm dacă cheia a fost revendicată sau nu (cel mai probabil era, dar poți încerca din nou).                                                                                                       |
| BadActivationCod     | Cheia furnizată este nevalidă (nu este recunoscută ca fiind o cheie validă de către rețeaua Steam).                                                                                                                                          |
| DuplicateActivareCod | Cheia furnizată a fost deja răscumpărată de un alt cont sau revocată de dezvoltator/editor.                                                                                                                                                  |
| Deja Achiziționat    | Contul dvs. deţine deja pachetul `pachetageID` care este conectat cu această cheie. Țineți cont că acest lucru nu indică dacă cheia este `DuplicateActivationCode` sau nu - doar că este validă și nu a fost utilizată în această încercare. |
| Țară restricționată  | Aceasta este o cheie blocată de o regiune și contul dvs. nu este în regiunea validă care o poate revendica                                                                                                                                   |
| DoesNotOwnNecesitApp | Nu poți revendica acea cheie deoarece îți lipsește altă aplicație - în principal joc de bază atunci când încerci să revendici pachetul DLC.                                                                                                  |
| RateLimitate         | Ai făcut prea multe încercări de răscumpărare și contul tău a fost blocat temporar. Încercați din nou într-o oră.                                                                                                                            |




---



### Sunteți afiliat la orice carduri de utilizare a agriculturii/ralanti?

**Nu**. ASF nu este afiliat la niciun serviciu și toate cererile de acest tip sunt false. Contul tău de Steam este proprietatea ta și îți poți folosi contul în orice mod dorești, dar Valve clar menționat la **[ToS oficial](https://store.steampowered.com/subscriber_agreement)** că:



> Sunteți responsabil pentru confidențialitatea autentificării și a parolei dvs. și pentru securitatea sistemului dvs. informatic. Valve nu este responsabil pentru utilizarea parolei și a contului sau pentru toată comunicarea și activitatea de pe Steam care rezultă din utilizarea numelui de conectare și a parolei de către dvs., sau de către orice persoană căreia îi este posibil să îi fi dezvăluit în mod intenționat sau prin neglijență numele de utilizator și/sau parola dumneavoastră, cu încălcarea acestei dispoziții privind confidențialitatea.

ASF este autorizat cu licență liberal Apache 2.0, ceea ce permite altor dezvoltatori să integreze ASF în mod legal propriile proiecte și servicii. Cu toate acestea, astfel de proiecte terțe care utilizează ASF nu au garanția de a fi sigure, revizuite, adecvate sau legale în conformitate cu **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Dacă doriți să ne cunoașteți opinia, **vă încurajăm să NU împărtășiți niciun fel de detalii de cont cu terți servicii**. If such service turns out to be a **typical scam**, you'll be left alone with the problem, most likely without your Steam account and ASF won't take any responsibility for third-party services claiming to be safe and secure, because ASF team did not authorize neither reviewed any of those. Cu alte cuvinte, **le folosiți pe propriul risc, în raport cu sugestia noastră de mai sus**.

În plus, oficialul **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** precizează în mod clar că:



> Nu puteți dezvălui, distribui sau permite altora să vă folosească parola sau contul, cu excepția cazului în care altfel este autorizat în mod specific de către Valve.

Este contul tău și alegerea ta. Nu spuneți că nimeni nu v-a avertizat. ASF ca program îndeplinește toate regulile menționate mai sus, deoarece nu partajezi detaliile contului tău cu nimeni, și utilizați programul pentru uz personal, dar orice alt serviciu de cultivare a cardurilor necesită din datele de identificare a contului, astfel încât încalcă regula de mai sus (de fapt câteva dintre ele). Ca și cu **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** evaluare, nu oferim nicio consiliere juridică și ar trebui să decideți singur dacă doriți să folosiți aceste servicii, sau nu - conform nouăi **încalcă direct [Steam ToS](https://store.steampowered.com/subscriber_agreement)** și poate duce la suspendare în cazul în care se descoperă Valve. Ca și cele menționate mai sus, **vă recomandăm insistent să NU utilizați niciunul dintre aceste servicii**.



---



## Probleme



---



### Unul dintre jocurile mele este cultivat mai mult de 10 ore deja, dar tot nu am primit nici o carte!

Motivul ar putea fi legat de problema cunoscută a Steam, care se întâmplă atunci când ai două licențe pentru același joc, dintre care una are picături de card limitate. Acest lucru se întâmplă de obicei atunci când activezi jocul gratuit în timpul unui giveaway în masă pe Steam, și apoi activați o cheie pentru același joc (fără limitări), e. . dintr-un pachet plătit. Dacă se întâmplă astfel de situații, Steam raportează pe pagina de insigne că jocul încă mai are carduri de scădere, dar indiferent cât de mult joci jocul - cardurile nu vor scădea niciodată din cauza licenței gratuite din contul tău. Deoarece nu este o problemă ASF, ci una Steam, nu putem să o ocolim cumva de partea ASF și trebuie să o rezolvați singur.

Există două modalităţi de a rezolva problema. În primul rând, poți lista neagră acest joc în ASF, fie cu comanda `fbadd` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** sau cu `Blacklist` **[configureaza proprietatea](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Acest lucru va împiedica ASF să încerce cărți de exploatare din acest joc, dar nu va rezolva problema de bază, care vă împiedică să obțineți picături cu cardul din jocul afectat. În al doilea rând, poți utiliza instrumentul de self-service Steam pentru a elimina licența gratuită din contul tău, lăsând doar licența completă care include picăturile cu cardul. În acest scop, în primul rând, vizitați licențele dvs. **[și activarea cheilor de produs](https://store.steampowered.com/account/licenses)** pagina și locați atât licența gratuită, cât și cea plătită pentru jocul afectat. De obicei este destul de ușor - ambele au nume similar, dar gratis are "pachet promoțional limitat" sau alt "promoție" în numele licenței, plus "complimentar" în câmpul "metoda de achiziţie". Uneori poate fi mai complicat, de exemplu dacă pachetul gratuit a fost într-un pachet și are un nume diferit. Dacă ați găsit două astfel de licențe - atunci este într-adevăr problema descrisă aici. și puteți elimina în siguranță licența gratuită fără a pierde jocul.

Pentru a elimina licența gratuită din contul dvs., vizitează **[Pagina de suport Steam](https://help.steampowered.com/wizard/HelpWithGame)** şi pune numele jocului afectat în câmpul de căutare, jocul ar trebui să fie disponibil în secțiunea "produse", apăsați pe el. Alternativ, poți doar să folosești linkul `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` și să înlocuiești `<appID>` cu appID al jocului care cauzează probleme. După aceea, faceţi clic pe "Vreau să elimin definitiv acest joc din contul meu" şi apoi selectaţi licenţa gratuită defectă pe care aţi găsit-o mai sus, de obicei cel care conține în nume (sau similar) un pachet promoțional limitat și gratuit. După eliminarea licenței gratuite, ASF ar trebui să poată renunța fără probleme la cardurile din jocul afectat, ar trebui să reporniți operația de creștere după eliminare doar pentru a vă asigura că Steam ia licența corectă de data asta.



---



### ASF nu detectează jocul `X` ca fiind disponibil pentru agricultură, dar știu că include și cartonașe de tranzacționare Steam!

Există două motive principale în acest sens. Primul și cel mai evident motiv este faptul că te referi la **Steam store** unde jocul dat este anunțat ca un joc cu cartelă suspendat. Aceasta este o ipoteză **greșită** , deoarece spune pur și simplu că jocul **are** cartonașe incluse, dar nu neapărat această funcţie pentru acel joc este **activată imediat**. Poți citi mai multe despre asta în **[anunț oficial](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**.

Pe scurt, pictograma picăturilor din magazinul Steam nu înseamnă nimic, verifică pagina de insignă **[](https://steamcommunity.com/my/badges)** pentru a confirma dacă un joc are picături de card activate sau nu - iată ce face ASF. Dacă jocul tău nu apare pe listă ca un joc cu cărți care poate fi scăpat, apoi acest joc este **nu** posibil la fermă, indiferent de motiv.

A doua problemă este mai puţin evidentă, și este situația când poți vedea că jocul tău este într-adevăr disponibil cu cartele pe pagina ta de insigne, Cu toate acestea, nu este cultivat imediat de ASF. Dacă nu lovești alte probleme, cum ar fi dacă ASF nu poate verifica paginile de insigne (descrise mai jos), este pur și simplu un efect de cache și pe partea ASF Steam încă raportează pagina de insigne învechită. Această problemă ar trebui să se rezolve mai devreme sau mai târziu, când geocutia este invalidată. De asemenea, nu există nicio modalitate de a rezolva această problemă de partea noastră.

Desigur, toate astea presupun că rulezi ASF cu setări implicite neatinse, pentru că ai putea adăuga acest joc și la lista neagră de ferme, utilizează `Ferma Preferințe` cum ar fi `FermPriorityQueueOnly` sau `SkipRefundableGames`și așa mai departe.



---



### De ce nu crește timpul de joacă al jocurilor cultivate prin ASF?

Face asta, dar **nu în timp real**. Steam înregistrează timpul de joacă în intervale fixe și programează actualizarea pentru ea, dar nu ai garanția că acesta a fost actualizat imediat ce ai părăsit sesiunea, cu atât mai puțin în timpul ei. Doar pentru că timpul de joacă nu este actualizat în timp real nu înseamnă că nu este înregistrat, este actualizat de obicei la fiecare 30 de minute.



---



### Care este diferența dintre un avertisment și o eroare în jurnal?

ASF scrie în jurnalul său o grămadă de informații despre diferite niveluri de înregistrare. Obiectivul nostru este să explicăm **exact** ceea ce face ASF, inclusiv cu ce probleme are de rezolvat Steam sau cu ce alte probleme trebuie depăşite. De cele mai multe ori nu totul este relevant, Acesta este motivul pentru care în ASF sunt utilizate două niveluri majore în ceea ce privește problemele - un nivel de avertizare și un nivel de eroare.

General ASF rule is that warnings are **not** errors, therefore they should **not** be reported. Un avertisment este un indicator pentru tine că ceva potențial nedorit se întâmplă. Indiferent dacă Steam nu reacționează, API aruncă erori sau conexiunea la rețea este oprită - este un avertisment, și asta înseamnă că ne așteptam să se întâmple, așa că nu deranja dezvoltarea ASF cu ea. Bineînțeles că sunteți liber să întrebați despre ele sau să obțineți ajutor folosind ajutorul nostru, dar nu ar trebui să presupunem că acestea sunt erori ASF care merită raportate (dacă nu vom confirma contrariul).

Erorile indică, pe de altă parte, o situație care nu ar trebui să aibă loc, de aceea merită să fie raportate atâta timp cât ai fost sigur că nu tu eşti cel care le cauzează. Dacă ne așteptăm să se întâmple o situație comună, atunci aceasta va fi transformată într-un avertisment. Altfel, este posibil ca o eroare să fie corectată, nu ignorată, presupunând că nu este rezultatul propriei probleme tehnice. De exemplu, introducerea conținutului nevalid în `ASF. Fișierul fiului` va arunca o eroare, deoarece ASF nu va putea să o analizeze, dar tu ai fost cel care a pus-o acolo, așa că nu ar trebui să ne raportați eroarea (dacă nu ați confirmat că ASF este greșit și structura dvs. este de fapt absolut corectă).

Într-unul din TL; fraza DR - raportează erori, nu raporta avertismente. Puteţi întreba despre avertismente şi primi ajutor în secţiunile noastre de suport.



---



### ASF nu pornește, fereastra programului se închide imediat!

În condiții normale, orice prăbușire sau ieșire ASF va genera un jurnal `. xt` în directorul programului pentru a vizualiza acest lucru, care poate fi folosit pentru a găsi cauza lui. În plus, câteva ultime fișiere jurnal sunt de asemenea arhivate în directorul `logs` , de la logul principal `. Fișierul xt` este suprascris cu fiecare rulare ASF.

Cu toate acestea, dacă nici măcar .NET nu poate porni pe calculator, atunci `log.txt` nu va fi generat. Dacă vi se întâmplă acest lucru, cel mai probabil ați uitat să instalați .NET premise așa cum se menționează în **[configurarea](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)** ghid. Alte probleme comune includ încercarea de a lansa o variantă ASF greșită pentru SO sau în alt mod lipsa dependențelor native .NET runtime. Dacă fereastra de consolă se închide prea curând pentru a citi mesajul, atunci deschideți o consolă independentă și lansați ASF de acolo. De exemplu pe Windows, deschide directorul ASF, țineți apăsat `Shift`, click dreapta în interiorul dosarului și alege "*deschide fereastra de comandă*" (sau *powershell*), apoi tastați în consola `. ArchiSteamFarm.exe` și confirmă cu enter. În acest fel veți primi un mesaj precis de ce ASF nu pornește în mod corespunzător.

Dacă nu există ieșire și ești pe Windows, cauza obișnuită pentru asta nu este să ai toate actualizările Windows instalate - asigură-te că folosești sistemul de operare actualizat, pentru că nu acceptăm rularea ASF pe Windows fără a îndeplini această condiție.



---



### ASF dă afară sesiunea mea de Client Steam în timp ce red! / *Acest cont este conectat pe un alt PC*

Acesta apare ca un mesaj în Steam suprapus că contul este folosit în altă parte în timp ce joci. Această problemă poate avea două motive diferite.

Un motiv este cauzat de pachete (jocuri) sparte, care în mod specific nu dețin un bloc de joc corect, Se așteaptă totuși ca acel blocaj să fie pus de client. Un exemplu de astfel de pachet ar fi Skyrim SE. Clientul tău Steam lansează jocul în mod corect, dar acel joc nu se înregistrează ca fiind folosit. Din această cauză, ASF vede că este liber să reia procesul, ceea ce face și asta te lovește din rețeaua Steam, deoarece Steam detectează brusc că contul este folosit în alt loc.

Al doilea motiv ar putea apărea dacă te joci pe calculatorul tău în timp ce ASF așteaptă (în special pe o altă mașinărie) și îți pierzi conexiunea la rețea. În acest caz, rețeaua Steam vă marchează ca offline și eliberează blocarea jocului (cum ar fi de mai sus), ceea ce declanșează ASF (de exemplu, pe o altă mașină) pentru a relua agricultura. Când PC-ul tău se întoarce online, Steam nu mai poate dobândi blocarea jocului (este acum deținută de ASF, de asemenea similar cu cele de mai sus) și prezintă același mesaj.

Ambele cauze de pe partea ASF sunt de fapt foarte greu de lucrat. pe măsură ce ASF pur şi simplu îşi reia activitatea agricolă odată ce reţeaua Steam o informează despre acest cont este liberă să fie folosită din nou. Asta se întâmplă în mod normal când închizi jocul, dar cu pachete stricate, acest lucru se poate întâmpla imediat, chiar dacă jocul tău este încă în desfășurare. ASF nu are nici o modalitate de a ști dacă ai fost deconectat, înceta să joci un joc sau că încă joci un joc care nu se blochează în mod corespunzător.

Singura soluție corectă pentru această problemă este întreruperea manuală a bot-ului cu `pauză` înainte de a începe redarea, şi reluarea cu `reluaţi` după ce aţi terminat. Alternativ, poți ignora problema și poți acționa la fel ca și cum ai juca cu clientul Steam offline.



---



### `Deconectat de la Steam!` - nu pot stabili o conexiune cu serverele Steam.

ASF poate doar **încerca** pentru a stabili o conexiune cu serverele Steam, și poate eșua din mai multe motive, inclusiv din cauza lipsei unei conexiuni la internet, Steam fiind în jos, conexiunea de blocare a firewall-ului, instrumente terțe, rute configurate incorect sau defecțiuni temporare. Puteți activa modul `Depanare` pentru a verifica mai multe jurnale verbose care să conțină motive exacte de eșec cu toate că, de obicei, este cauzată pur şi simplu de propriile acţiuni, cum ar fi folosirea "CS:GO MM Server Picker" care listează pe lista neagră o mulțime de IP-uri Steam, făcând foarte greu pentru tine să ajungi la rețeaua Steam.

ASF va face tot posibilul pentru a stabili o conexiune, care include nu doar întrebări despre lista actualizată de servere, ci și încercarea unui alt IP atunci când ultimul eșuează, așa că dacă este cu adevărat o problemă temporară cu un anumit server sau rută, ASF se va conecta mai devreme sau mai târziu. Cu toate acestea, dacă ești în spatele firewall-ului sau în alt mod nu poți ajunge la serverele Steam, apoi evident că trebuie să îl repari singur, cu ajutorul potențial `Debug`.

De asemenea, este posibil ca aparatul tău să nu poată stabili o conexiune cu serverele Steam folosind protocolul implicit în ASF. Puteți modifica protocoalele pe care ASF le poate utiliza prin modificarea `SteamProtocols` proprietățile de configurare globală. De exemplu, dacă aveţi probleme cu atingerea protocolului Steam cu `UDP` (de ex. datorită firewall-urilor, poate vei avea mai mult noroc cu `TCP` sau `WebSocket`.

Într-o situaţie foarte improbabilă de a avea servere incorecte, de exemplu, datorită mutării folderului ASF `config` de la o mașină la alta localizată în țară complet diferită, ştergere `ASF. b` pentru a reîmprospăta serverele Steam la următoarea lansare ar putea ajuta. De multe ori nu este nevoie şi nu trebuie făcut, deoarece acea listă este reîmprospătată automat la prima lansare. precum şi atunci când conexiunea este stabilită - o menţionăm doar ca pe o modalitate de a şterge orice are legătură cu lista de servere Steam prinse de ASF.



---



### `Nu se poate conecta la Steam: TryAnotherCM/`nevalid , `ServiceIndisponibil/`

Ca în cele de mai sus, dar de data aceasta serverul cu care te-ai conectat este explicit indisponibil. De obicei se întâmplă în timpul ferestrei de mentenanță Steam, nu se poate face nimic în această privință, ASF va reîncerca automat cu un alt server până când se întâmplă ca unul să accepte solicitarea sa. Nu ar trebui să dureze mai mult de o oră.



---



### `Nu s-a putut obține informații despre insigne, va încerca din nou mai târziu!`

De obicei, înseamnă că folosești PIN parental Steam pentru a-ți accesa contul, dar ai uitat să îl pui în configurație ASF. Trebuie să introduceți un PIN valid în proprietatea de configurare a botului `SteamParentalCode` , În caz contrar, ASF nu va putea accesa cea mai mare parte a conținutului web, prin urmare nu va putea funcționa corespunzător. Mergeți la **[configurația](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** pentru a afla mai multe despre `SteamParentalCode`.

Printre alte motive se numără problema temporară a Steam, problema de reţea sau altele. Dacă problema nu se va rezolva singur după câteva ore și ești sigur că ai configurat ASF în mod adecvat, nu ezita să ne anunți despre asta.



---



### ASF nu a reușit cu `Solicitare eșuată după 5 încercări` erori!

De obicei, înseamnă că folosești PIN parental Steam pentru a-ți accesa contul, dar ai uitat să îl pui în configurație ASF. Trebuie să introduceți un PIN valid în proprietatea de configurare a botului `SteamParentalCode` , În caz contrar, ASF nu va putea accesa cea mai mare parte a conținutului web, prin urmare nu va putea funcționa corespunzător. Mergeți la **[configurația](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** pentru a afla mai multe despre `SteamParentalCode`.

Dacă codul PIN parental nu este motivul, atunci aceasta este cea mai frecventă eroare, şi ar trebui să vă obişnuiţi cu asta, înseamnă pur și simplu că ASF a trimis o cerere către rețeaua Steam, și nu a primit un răspuns valabil, de 5 ori la rând. De obicei, înseamnă că aburul de la Steam este fie descrescător, fie se confruntă cu dificultăţi sau întreţinere - ASF este conştient de astfel de probleme şi nu ar trebui să vă îngrijoraţi în legătură cu acestea, dacă nu au loc în mod constant mai mult de câteva ore şi dacă alţi utilizatori nu au astfel de probleme.

Cum să verifici dacă Steam este în scădere? **[Steam](https://steamstat.us)** este o sursă excelentă de a verifica dacă Steam **ar trebui să fie** în plus, dacă observați erori, în special legate de API comunitar sau Web, atunci Steam are dificultăți. Poate vrei să lași ASF singur și să îi lase să își facă treaba după un scurt timp de reducere sau să renunțe la el și să te aștepți singur.

Totuși, acest lucru nu este întotdeauna valabil, deoarece, în unele situații, este posibil ca problemele cu Steam să nu fie detectate de Steam Status, De exemplu, un astfel de caz s-a produs atunci când Valve a stricat sprijinul HTTPS pentru Comunitatea Steam 7 iunie 2016 - accesând **[SteamCommunity](https://steamcommunity.com)** prin HTTPS arunca o eroare. Prin urmare, nu aveţi nici o încredere orbeşte în statutul de Steam, cel mai bine este să verificaţi dacă totul funcţionează aşa cum ar trebui.

În plus, Steam include diferite măsuri de limitare a ratei care vă vor interzice temporar IP-ul dacă faceți un număr excesiv de cereri simultan. ASF este conștient de acest lucru și vă oferă mai multe limite diferite în configurare, de care ar trebui să faceți utilizare. Setările implicite au fost ajustate în funcție de numărul de boți **sane** , dacă folosești atât de mult încât până și Steam îți spune să pleci, apoi fie le schimbi până când nu îţi mai spune asta, fie faci cum ţi se spune. Presupun că a doua cale nu este pentru voi, așa că citiți subiectul respectiv și acordați o atenție specială `WebLimiterDelay` care este un limiter general care se aplică la toate cererile web.

Nu există nici o "regulă de aur" care să funcţioneze pentru toată lumea, deoarece blocurile sunt influenţate puternic de factori terţiari, De aceea trebuie să experimentezi singur şi să găseşti o valoare care să funcţioneze pentru tine. De asemenea, poți ignora ceea ce spun și folosi ceva precum `10000` care este garantat că funcționează corect, dar apoi nu vă plânge cum reacționează ASF la tot în 10 secunde și cum durează 5 minute analiza insignelor. În plus, este complet posibil ca nici un limiter să nu facă nimic pentru că ai un număr uriaș de boți pe care îi lovești **[limita grea](#how-many-bots-can-i-run-with-asf)** care a fost menționată mai sus. Da, este complet posibil să te autentifici fără probleme în rețeaua Steam (client), dar Steam web (site) refuză să te asculte dacă ai 100 de sesiuni stabilite simultan. ASF necesită ca atât rețeaua Steam cât și rețeaua de Steam să fie cooperante, este nevoie doar de una în jos pentru a te face să întâmpini probleme de la care nu te vei reveni.

Dacă nimic nu te ajută şi nu ai nici un indiciu ce se strică, poți să activezi întotdeauna modul `Depanare` și să te vezi în jurnalul ASF de ce cererile au eșuat. De exemplu:



```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Forbidden <- HEAD https://steamcommunity.com/my/edit/settings
```


Vezi codul `Forbidden`? Asta înseamnă că ai fost interzis temporar pentru o cantitate excesivă de solicitări, pentru că nu ați modificat `WebLimiterDelay` corect (presupunând că primiți același cod de eroare și pentru toate celelalte solicitări). Ar putea fi și alte motive enumerate acolo, cum ar fi `InternalServerError`, `ServiceUnavailable` și timeout-uri care indică Steam întreținere/probleme. Puteți întotdeauna să vizitați chiar dvs. link-ul menționat de ASF și să verificați dacă funcționează - dacă nu, apoi știi de ce ASF nu poate accesa așa ceva. Dacă da, şi aceeaşi eroare nu dispare după o zi sau două, ar putea merita să fie investigată şi raportată.

Înainte de a face acest lucru, ar trebui să **asigurați-vă că eroarea merită să fie raportată în primul rând**. Dacă este menţionată în acest FAQ, cum ar fi problema legată de comerţ, atunci asta se întâmplă. Dacă s-a întâmplat o dată sau de două ori o problemă temporară, în special când rețeaua ta era instabilă sau Steam era în jos - asta s-a terminat. Cu toate acestea, dacă ați putea reproduce problema de mai multe ori la rând, pe parcursul a 2 zile, reporniți ASF și mașina dvs. în proces și asigurați-vă că nu există aici nicio intrare de întrebări frecvente pentru a ajuta la rezolvarea acesteia, ar putea merita să ne întrebăm despre acest lucru.



---



### ASF pare să înghețe și nu imprimă nimic pe consolă până când apăs o cheie!

Cel mai probabil folosești Windows și consola ta are modul Editare rapidă. Consultați **[această întrebare](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** pe StackOverflow pentru explicații tehnice. Ar trebui să dezactivați modul de editare rapidă făcând clic pe fereastra de comandă ASF, deschizând proprietăți și debifând caseta de selectare corespunzătoare.



---



### ASF nu poate accepta sau trimite tranzacții!

Evident primul lucru - conturile noi încep ca fiind limitate. Până când deblocați contul prin încărcarea portofelului său sau cheltuirea a $5 în magazin, ASF nu poate accepta nici să trimită tranzacții folosind acest cont. În acest caz, ASF va declara că inventarul pare gol, pentru că fiecare card care este în el nu este tranzacționabil.

Apoi, dacă nu folosești **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, este posibil ca ASF să fie de fapt acceptat/trimisă, dar trebuie să îl confirmați prin e-mail. De asemenea, dacă folosești 2FA clasică, trebuie să confirmi tranzacția prin autentificatorul tău. Confirmările sunt **obligatorii** acum, deci dacă nu vrei să le accepți de unul singur, ia în considerare importul autentificatorului tău în ASF 2FA.

De asemenea, observi că poți tranzacționa doar cu prietenii tăi și cu linkul de tranzacționare cunoscut. Dacă încercați să inițiați tranzacția *Bot -> Master* , cum ar fi `loot`, apoi trebuie fie să aveți botul în lista de prieteni, fie `SteamTradeken` declarat în configurația Bot. Asigură-te că token-ul este valid - altfel, nu vei putea trimite o tranzacție.

În cele din urmă, țineți minte că noile dispozitive au blocare de 7 zile de tranzacționare, așa că dacă tocmai ați adăugat contul la ASF, aşteaptă cel puţin 7 zile - totul ar trebui să funcţioneze după această perioadă. Această limitare include de la **ambele** acceptând tranzacțiile **și**. Acest lucru nu declanșează întotdeauna și există persoane care pot trimite și accepta tranzacții instant. Majority of the people are affected though, and the lock **will** happen, even if you can send and accept trades through your steam client on the same machine. Aşteptaţi răbdare, nu puteţi face nimic pentru a-l face mai rapid. De asemenea, puteţi primi o blocare similară pentru îndepărtarea/modificarea diferitelor setări legate de securitatea Steam, cum ar fi 2FA, SteamGuard, parolă, e-mail şi similar. În general, verificați dacă puteți trimite o tranzacție din acel cont, dacă da, este foarte probabil ca 7 zile să fie blocate de pe noul dispozitiv.

Și, în cele din urmă, nu uita că un cont poate avea doar 5 tranzacții în așteptare la altul, astfel ASF va eșua în a trimite tranzacții dacă aveți 5 (sau mai multe) în așteptare de la acel bot pentru a le accepta deja. Aceasta este rareori o problemă, dar merită menționată, în special dacă setezi ASF să trimită tranzacții automate. Încă nu folosești ASF 2FA și ai uitat să le confirmi.

În cazul în care nimic nu a ajutat, puteți întotdeauna să activați modul `Depanare` și să verificați de ce cererile nu reușesc. Vă rugăm să reţineţi că în cea mai mare parte a timpului vorbeşte despre absurdităţi şi că este posibil ca motivele să nu aibă sens logic, sau poate fi chiar complet incorect - dacă decideţi să interpretaţi acest motiv, asiguraţi-vă că aveţi cunoştinţe decente despre Steam şi ghearele sale. Este destul de obişnuit să vezi această problemă fără nici un motiv logic, și singura soluție sugerată în acest caz este să adăugați din nou contul la ASF (și să așteptați 7 zile din nou). Câteodată această problemă se rezolvă de asemenea *magic*, la fel cum se rupe. Cu toate acestea, de obicei sunt fie blocaje comerciale de 7 zile, fie probleme temporare cu aburul, fie ambele. Cel mai bine este să îi dai câteva zile înainte de a verifica manual ce este greșit, decât dacă aveţi nevoie să depanaţi cauza reală (şi, de obicei, veţi fi obligat să aşteptaţi oricum, pentru că mesajul de eroare nu va avea niciun sens, nici nu vă va ajuta în cele mai mici măsuri).

În orice caz, ASF poate doar **încerca** să trimită o cerere corectă către Steam pentru a accepta/trimite tranzacții. Dacă Steam acceptă această cerere sau nu, este în afara domeniului de aplicare al ASF, iar ASF nu o va face să funcționeze în mod magic. Nu există o eroare legată de această funcție, și nici nu există nimic de îmbunătățit, pentru că logica se întâmplă în afara ASF. Prin urmare, nu solicitați să fixați lucruri care nu sunt stricate, și de asemenea nu întrebați de ce ASF nu poate accepta sau trimite tranzacții - **Nu știu, iar ASF nu știe nici**. Fie ai de-a face cu el, fie te repari, dacă știi mai bine.



---



### De ce trebuie să pun codul 2FA/SteamGuard pe fiecare autentificare? / *S-a eliminat cheia de conectare*

ASF folosește chei de conectare (dacă ai păstrat `UseLoginKeys` activat) pentru păstrarea acreditărilor valide, același mecanism pe care îl folosește Steam - 2FA/SteamGuard este necesar doar o singură dată. Cu toate acestea, din cauza problemelor de rețea Steam și a ghilimelelor, este complet posibil ca cheia de conectare să nu fie salvată în rețea, Am văzut deja astfel de probleme nu numai cu ASF, dar și cu client cu abur obișnuit (nevoia de a introduce numele de utilizator + parola la fiecare rulare, indiferent de opțiunea "Ține minte mine").

Ai putea șterge `BotName.db` și `BotName. în` (dacă este disponibil) de cont afectat și încearcă din nou să conectezi ASF la contul tău, dar acest lucru probabil nu va face nimic. Unii utilizatori au raportat că **[de a dezautoriza toate dispozitivele](https://store.steampowered.com/twofactor/manage)** în partea Steam ar trebui să ajute, schimbarea parolei va face la fel. Cu toate acestea, acestea sunt doar măsuri care nu sunt garantate nici măcar la locul de muncă, adevărata soluție ASF este să importe autentificatorul ca **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** - în acest fel ASF poate genera tokeni automat atunci când sunt necesari, şi nu trebuie să le introduci manual. De obicei, problema se rezolvă în mod magic după ceva timp, astfel încât să puteți pur și simplu aștepta ca acest lucru să se întâmple. Bineînțeles că poți cere și Valve soluție, pentru că nu pot forța rețeaua Steam să accepte cheile noastre de conectare.

Ca o notă laterală, puteți dezactiva, de asemenea, cheile de conectare cu `UseLoginKeys` proprietatea setată la `false`, dar acest lucru nu va rezolva problema, săriți peste primul eșec al cheii de conectare. ASF este deja conștient de problema explicată aici și va încerca cel mai bine să nu utilizeze cheile de conectare dacă poate să garanteze toate datele de autentificare, așa că nu este nevoie să modificați `UseLoginKeys` manual dacă puteți furniza toate detaliile de autentificare împreună cu ASF 2FA.



---



### Am ajuns la eroare: *nu se poate conecta la Steam: `Parolă Invalidă` sau `RateLimitExceeded`*

Această eroare poate însemna multe lucruri, unele dintre ele includ:

- Combinatie invalida de autentificare/parola (evident)
- Cheie de conectare expirată utilizată de ASF pentru logare în
- Prea multe încercări de conectare nereușite într-o perioadă scurtă de timp (anti-brutefort)
- Prea multe încercări de conectare într-o perioadă scurtă de timp (limitarea ratei)
- Cerința de autentificare a captcha (este foarte probabil să fie cauzată de două motive de mai sus)
- Orice alt motiv pentru care rețeaua Steam poate avea împiedicarea conectării

In cazul anti-brutefortului si limitarii ratei, problema va disparea dupa un timp, asa ca asteptati si nu incercati sa va conectati intre timp. Dacă ați lovit frecvent această problemă, poate că este înțelept să măriți `LoginLimiteray` proprietatea de configurare a ASF. Repornește programul în exces și alte cereri de conectare intenționate/neintenționate nu vor ajuta cu această problemă, așa că încercați să evitați dacă este posibil.

În cazul expirării cheii de conectare - ASF o va elimina pe cea veche și va solicita una nouă la următoarea conectare (care va necesita să puneți token-ul 2FA, dacă contul dvs. este protejat cu 2FA. Dacă contul dvs. utilizează ASF 2FA, token va fi generat și utilizat automat). Acest lucru se poate întâmpla în mod firesc în timp, dar dacă întâmpinați această problemă la fiecare conectare, este posibil ca Steam dintr-un anumit motiv să fi decis să ignore cererile noastre cheie de salvare, așa cum este menționat în problema **[mai sus](#why-do-i-have-to-put-2fasteamguard-code-on-each-login--removed-expired-login-key)**. Poți desigur să dezactivezi `UseLoginKeys` în întregime, dar acest lucru nu va rezolva problema, doar evitați de fiecare dată să eliminați cheile de conectare expirate. Soluția reală, ca în cazul problemei de mai sus, este utilizarea ASF 2FA.

Și, în cele din urmă, dacă ai folosit combinația greșită de conectare + parolă, evident trebuie să corectezi asta, sau dezactivați botul care încearcă să se conecteze folosind aceste acreditări. ASF nu poate ghici pe cont propriu dacă `InvalidParola` înseamnă acreditări nevalide, sau oricare dintre motivele enumerate mai sus, prin urmare va încerca în continuare până când va reuși.

Reține că ASF are propriul său sistem încorporat pentru a reacționa în mod corespunzător la interceptările aburului, în cele din urmă, se va conecta şi îşi va relua postul, prin urmare nu este necesar să facă nimic dacă problema este temporară. Repornirea ASF pentru a rezolva problemele magic va înrăutăți lucrurile doar deoarece noul ASF nu va ști starea ASF anterioară de a nu se putea autentifica, și încercați să vă conectați în loc să așteptați), astfel încât evitați să faceți asta dacă nu știți ce faceți.

În cele din urmă, la fel ca în cazul fiecărei solicitări Steam - ASF poate doar **încerca** să se autentifice folosind acreditările furnizate. Dacă cererea respectivă va reuși sau nu este exclusă din domeniul de aplicare și logica ASF - nu există niciun bug, şi nimic nu poate fi stabilit fără a fi îmbunătăţit în această privinţă.



---



### Nu pot introduce detaliile de autentificare pe care ASF le solicită


### `System.InvalidOperationException: Nu se pot citi cheile atunci când aplicația nu are consolă sau când intrarea consolei a fost redirecționată`


### `Sistem.IOExcepție: Eroare de intrare/ieșire`


### `SolicestInput() nu este validă!`

Dacă s-a produs această eroare în timpul intrării ASF (de ex. poți vedea `GetUserInput()` în stacktrace) apoi este cauzat de mediul tău care interzice ASF să citească intrarea standard a consolei tale. Acest lucru se poate întâmpla din multe motive, dar cel mai frecvent este să rulezi ASF într-un mediu greșit (de exemplu, în fundalul `systemd`, `nohup` sau `&` în loc de . . `ecranul` pe Linux). Dacă ASF nu poate accesa intrarea standard, atunci veți vedea această eroare înregistrată și incapacitatea ASF de a utiliza detaliile în timpul runtime.

În mod normal ar trebui să corectați problema de mai sus, adică să permiteți ASF să acceseze intrarea standard pentru a putea furniza detaliile. Cu toate acestea, dacă **așteptați ca** să se întâmple, astfel încât **intenționați să** să ruleze ASF într-un mediu fără intrare, apoi ar trebui să spuneţi în mod explicit ASF că este cazul, prin setarea **[`Modul`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** în mod corespunzător. Acest lucru va spune ASF să nu solicite niciodată intrarea utilizatorului în nicio circumstanță, permițându-ți să rulezi ASF în condiții de siguranță în medii fără input. Puteți răspunde solicitărilor de intrare selectate prin alte mijloace în acest mod, de ex. în ASF-ui.



---



### `System.Net.Http.WinH41/Excepție: A apărut o eroare de securitate`

Această eroare se întâmplă atunci când ASF nu poate stabili o conexiune securizată cu serverul dat, aproape exclusiv din cauza mistrustului certificatului SSL.

În aproape toate cazurile, această eroare este cauzată de **data sau ora greșită pe mașina dvs**. Fiecare certificat SSL a emis data și data expirării. Dacă data dvs. nu este validă și din aceste două limite, atunci certificatul nu poate fi de încredere din cauza unui potențial **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)** atac și ASF refuză să facă o conexiune.

Soluţia evidentă este de a stabili data în mod corespunzător pe aparat. Este foarte recomandat să utilizaţi sincronizarea automată a datelor, cum ar fi sincronizarea nativă disponibilă pe Windows, sau `ntpd` pe Linux.

Dacă v-ați asigurat că data de pe mașină este potrivită și eroarea nu vrea să dispară, Certificate SSL care ar putea fi învechite sau invalide. În acest caz ar trebui să vă asigurați că mașina dvs. poate stabili conexiuni securizate, de exemplu verificând dacă puteți accesa `https://github. om` cu orice browser ales de dumneavoastră, sau unealtă CLI cum ar fi `curl`. Dacă aţi confirmat că acest lucru funcţionează corect, nu ezitaţi să ne solicitaţi sprijin.



---



### `System.Threading.Tasks.TaskCanceledException: O sarcină a fost anulată`

Această avertizare înseamnă că Steam nu a răspuns la solicitarea ASF într-un timp dat. De obicei, este cauzată de sughițurile de rețea Steam și nu afectează ASF în niciun fel. În alte cazuri, este la fel ca cererea de eșec după 5 încercări. Raportarea acestei probleme nu are sens de cele mai multe ori, deoarece nu putem forţa Steam să răspundă la solicitările noastre.



---



### `Inițializatorul de tip pentru 'System.Security.Cryptography.CngKeyLite' a aruncat o excepție`

Această problemă este cauzată aproape exclusiv de serviciul Windows dezactivat/oprit `CNG Key Isolation` , care oferă funcționalități de criptare pentru ASF, fără de care programul nu poate rula. Puteți rezolva această problemă lansând serviciile `. SC` și asigurarea că serviciul `CNG Key Isolation` Windows nu a dezactivat pornirea și rulează în prezent.



---



### ASF este detectat ca malware de către AntiVirusul meu! Ce se întâmplă?

**Asigurați-vă că ați descărcat ASF de la sursa de încredere**. Singura sursă oficială și de încredere este **[versiuni ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** pagină pe GitHub (și aceasta este, de asemenea, sursa pentru actualizări automate ASF) - **orice altă sursă nu are încredere prin definiție și poate conține programe malware adăugate de alte persoane** - nu ar trebui să aveți încredere în nicio altă locație, Asigură-te că ASF-ul tău vine întotdeauna de la noi.

Dacă ați confirmat că ASF este descărcat de la sursă de încredere, atunci foarte probabil este pur și simplu un fals pozitiv. Acest **s-a întâmplat în trecut**, **se întâmplă chiar acum**, iar **se va întâmpla în viitorul**. Dacă sunteţi îngrijorat de siguranţa reală când utilizaţi ASF, atunci vă sugerez scanarea ASF cu multe VV diferite pentru raportul real de detecţie, de exemplu prin **[VirusTotal](https://www.virustotal.com)** (sau orice alt serviciu web ales de tine ca aceasta).

Dacă AV pe care îl utilizați detectează fals ASF ca malware, apoi **este o idee bună să trimiți acest eșantion de fișier înapoi dezvoltatorilor adresei tale AV, astfel încât să îl poată analiza și îmbunătăți motorul lor de detectare**pentru că, în mod clar, nu funcționează la fel de bine cum crezi că este. Nu există nicio problemă în codul ASF și nu există nimic de rezolvat pentru noi, deoarece nu distribuim programe malware în primul rând, Prin urmare, nu are niciun sens să ne raportezi aceste fals pozitive. Vă recomandăm să trimiteți un eșantion ASF pentru analize suplimentare, cum ar fi cele menționate mai sus, dar dacă nu doriți să vă deranjați cu el, apoi poți întotdeauna adăuga ASF la un fel de excepții AV, dezactivează AV sau pur și simplu folosește altul. Din păcate, suntem obișnuiți ca VV să fie stupid, ca o dată în același timp, unele AV detectează ASF ca un virus, care, de obicei, durează foarte puţin şi este ştearsă rapid de către dezvoltatori, dar după cum am subliniat mai sus - **s-a întâmplat**, **se întâmplă** și **se va întâmpla** tot timpul. ASF nu include niciun cod răuvoitor, puteți revizui codul ASF și chiar compila de la sursa proprie. Nu suntem hackeri care să umble codul ASF pentru a ascunde de heuristica AV și fals pozitive; aşa că nu aşteptaţi de la noi să reparăm ceea ce nu este rupt - nu există un "virus" pe care să îl rezolvăm.