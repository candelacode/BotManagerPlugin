# Konfiguration

Denne side er dedikeret til ASF konfiguration. Det fungerer som en komplet dokumentation af `config` mappe, så du kan tune ASF til dine behov.

* **[Introduktion](#introduction)**
* **[Webbaseret KonfigGenerator](#web-based-configgenerator)**
* **[ASF-ui konfiguration](#asf-ui-configuration)**
* **[Manuel konfiguration](#manual-configuration)**
* **[Global konfiguration](#global-config)**
* **[Bot config](#bot-config)**
* **[Fil struktur](#file-structure)**
* **[JSON kortlægning](#json-mapping)**
* **[Kortlægning af kompatibilitet](#compatibility-mapping)**
* **[Konfigner kompatibilitet](#configs-compatibility)**
* **[Auto-genindlæs](#auto-reload)**

---

## Introduktion

ASF konfiguration er opdelt i to store dele - global (proces) konfiguration, og konfiguration af hver bot. Hver bot har sin egen bot konfigurationsfil med navnet `BotName. Søn` (hvor `BotName` er navnet på botten, mens den globale ASF (process) konfiguration er en enkelt fil med navnet `ASF. Søn`.

En bot er en enkelt damp konto, der tager del i ASF proces. For at kunne fungere ordentligt, har ASF brug for mindst **én** defineret bot-instans. Der er ingen proceshåndhævet grænse for bot instanser, så du kan bruge så mange bots (damp konti), som du vil.

ASF bruger **[JSON](https://en.wikipedia.org/wiki/JSON)** format til lagring af sine konfigurationsfiler. Det er menneske-venlige, læsbare og meget universelle format, hvor du kan konfigurere programmet. Bare rolig, du behøver ikke at vide JSON for at konfigurere ASF. Jeg har lige nævnt det i tilfælde af at du allerede ønsker at masse-oprette ASF configs med en slags bash script.

Konfiguration kan gøres på flere måder. Du kan bruge vores **[Web-baserede ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)**, som er en lokal app uafhængig af ASF. Du kan bruge vores **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC frontend til konfiguration udført direkte i ASF. Endelig kan du altid generere config filer manuelt, som de følger fast JSON struktur angivet nedenfor. Vi vil kort forklare de tilgængelige muligheder.

---

## Webbaseret KonfigGenerator

Formålet med vores **[Webbaseret ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** er at give dig en venlig frontend der bruges til at generere ASF konfigurationsfiler. Web-baseret ConfigGenerator er 100% klient-baseret, hvilket betyder, at de oplysninger, du indtaster, ikke bliver sendt nogen vegne, men behandles kun lokalt. Dette garanterer sikkerhed og pålidelighed da det endda kan fungere **[offline](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** , hvis du vil downloade alle filerne og køre `-indeks. tml` i din foretrukne browser.

Webbaseret ConfigGenerator er bekræftet at køre korrekt på Chrome og Firefox, men det bør fungere korrekt i alle mest populære javascript-aktiverede browsere.

Brugen er ganske enkel - vælg om du vil generere `ASF` eller `Bot` config ved at skifte til en korrekt fane. sikre, at valgte version af config fil matcher din ASF udgivelse, og derefter indtaste alle detaljer og trykke på "download" knappen. Flyt denne fil til ASF `config` -mappen, overskrive eksisterende filer om nødvendigt. Gentag for alle eventuelle yderligere ændringer og henvise til resten af dette afsnit for forklaring af alle tilgængelige muligheder for at konfigurere.

---

## ASF-ui konfiguration

Vores **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC interface giver dig mulighed for også at konfigurere ASF og er overlegen løsning til omkonfigurering af ASF efter at have genereret de oprindelige konfigurationer på grund af det faktum, at det kan redigere konfigurationen på stedet, i modsætning til web-baseret ConfigGenerator, som genererer dem statisk.

For at bruge ASF-ui, skal du have vores **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface aktiveret selv. `IPC` er aktiveret som standard, derfor kan du få adgang til det med det samme, så længe du ikke selv har deaktiveret det.

Efter lanceringen af programmet, skal du blot navigere til ASF's **[IPC adresse](http://localhost:1242)**. Hvis alt fungerede korrekt, kan du også ændre ASF-konfiguration derfra.

---

## Manuel konfiguration

Generelt anbefaler vi kraftigt at bruge enten vores ConfigGenerator eller ASF-ui, da det er meget lettere og sikrer, at du ikke vil begå en fejl i JSON struktur, men hvis du af en eller anden grund ikke ønsker det, så kan du også oprette rigtige konfigurationer manuelt. Tjek JSON eksempler nedenfor for en god start i ordentlig struktur, du kan kopiere indholdet til en fil og bruge det som en base for din config. Da du ikke bruger nogen af vores frontends, skal du sikre dig, at din config er **[gyldig](https://jsonlint.com)**, da ASF vil nægte at indlæse det, hvis det ikke kan fortolkes. Selv hvis det er en gyldig JSON, du også nødt til at sikre, at alle egenskaber har den rigtige type, som krævet af ASF. For korrekt JSON struktur af alle tilgængelige felter, se afsnittet **[JSON mapping](#json-mapping)** og vores dokumentation nedenfor.

---

## Global konfiguration

Global config er placeret i `ASF.json` fil og har følgende struktur:

```json
{
    "AutoGenstart": true,
    "Blacklist": [],
    "CommandPrefix": "! ,
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "CurrentCulture": null,
    "Debug": false,
    "DefaultBot": null,
    "FarmingDelay": 15,
    "FilterBadBots": sandt,
    "GiftsLimiterDelay": 1,
    "Headless": false,
    "IdleFarmingPeriod": 8,
    "InventoryLimiterDelay": 4,
    "IPC": sandt,
    "IPCPassword": null,
    "IPCPasswordFormat": 0,
    "LicenseID": null
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldVarighed": 15,
    "MinFarmingDelayAfterBlock": 60,
    "Optimeringstilstand": 0,
    "PluginsUpdateList": [],
    "PluginsUpdateMode": 0,
    "ShutdownIfPossible": false,
    "SteamMessagePrefix": "/me "
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Alle muligheder er forklaret nedenfor:

### `AutoRestart`

`bool` type med standardværdi af `true`. Denne egenskab definerer om ASF har lov til at udføre en selvgenstart efter behov. Der er et par begivenheder, der vil kræve en selvgenstart fra ASF, såsom ASF opdatering (udført med `UpdatePeriod` eller `opdatering` kommando) samt `ASF. son` config edit, `genstart` kommando og ligeledes. Typisk indeholder genstart to dele - skabe ny proces, og færdiggøre nuværende en. De fleste brugere bør være fint med det og holde denne egenskab med standardværdi af `true`, dog - hvis du kører ASF gennem dit eget script og/eller med `dotnet`, du måske ønsker at have fuld kontrol over at starte processen, og undgå en situation såsom at have en ny (genstartet) ASF proces kører et eller andet sted lydløst i baggrunden og ikke i forgrunden af scriptet, der forlod sammen med gamle ASF proces. Dette er især vigtigt i betragtning af, at den nye proces ikke længere vil være dit direkte barn, hvilket ville gøre dig ude af stand til at gøre det. . for at bruge standard konsol-input til det.

Hvis det er tilfældet, denne egenskab hvis specielt for dig, og du kan indstille den til `false`. Men husk på, at i sådanne tilfælde **du** er ansvarlig for at genstarte processen. Dette er på en eller anden måde vigtigt, da ASF kun afslutter i stedet for at gyde ny proces (f.eks. efter opdatering), så hvis der ikke er nogen logik tilføjet af dig, vil det simpelthen stoppe med at arbejde, indtil du starter det igen. ASF afslutter altid med en korrekt fejlkode, der indikerer succes (nul) eller manglende succes (nul) på denne måde er du i stand til at tilføje korrekt logik i dit script, som bør undgå auto-genstart ASF i tilfælde af fejl, eller i det mindste udfærdige en lokal kopi af `log. xt` til yderligere analyse. Husk også på, at kommandoen `genstart` altid vil genstarte ASF, uanset hvordan denne egenskab er indstillet, da denne egenskab definerer standardadfærd, mens kommandoen `genstart` altid genstarter processen. Medmindre du har en grund til at deaktivere denne funktion, bør du holde den aktiveret.

---

### `Blacklist`

`ImmutableHashSet<uint>` type med standardværdi for at være tom. Som navnet antyder, denne globale config ejendom definerer appID'er (spil), der vil blive fuldstændig ignoreret af automatiske ASF landbrugsproces. Desværre Steam elsker at markere sommer/vinter salg badges som "tilgængelig for kort drop", hvilket forvirrer ASF-processen ved at få den til at tro, at det er et gyldigt spil, der bør opdrættes. Hvis der ikke var nogen form for sortliste, ville ASF i sidste ende "hænge" ved at drive et spil, der faktisk ikke er et spil, og vent uendeligt på kort drop, der ikke vil ske. ASF sortliste har til formål at markere disse badges som ikke tilgængelige for landbrug så vi kan lydløst ignorere dem, når de beslutter, hvad de skal gård, og ikke falde i fælden.

ASF indeholder som standard to sortlister - `SalesBlacklist`, som er hardcoded i ASF-koden og ikke muligt at redigere, og normal `Blacklist`, som er defineret her. `SalesBlacklist` opdateres sammen med ASF version og indeholder typisk alle "dårlige" appID'er på udgivelsestidspunktet, så hvis du bruger up-to-date ASF, så behøver du ikke at vedligeholde din egen `Blacklist` defineret her. Hovedformålet med denne ejendom er at give dig mulighed for at sortliste nye, ikke-kendte på tidspunktet for ASF release appIDs, som ikke bør opdrættes. Hardcoded `SalesBlacklist` opdateres så hurtigt som muligt Derfor er du ikke forpligtet til at opdatere din egen `Blacklist` , hvis du bruger den seneste ASF version, men uden `Blacklist` ville du være tvunget til at opdatere ASF for at "blive ved med at køre", når Valve udgiver nyt salgsmærke - jeg vil ikke tvinge dig til at bruge seneste ASF-kode derfor denne ejendom er her for at tillade dig at "fastgøre" ASF dig selv, hvis du af en eller anden grund ikke ønsker at, eller kan ikke, opdatere til nye hardcoded `SalesBlacklist` i ny ASF-udgivelse, men du vil alligevel holde din gamle ASF kørende. Medmindre du har en **stærk** grund til at redigere denne egenskab, bør du beholde den som standard.

Hvis du leder efter bot-baseret sortliste i stedet, så kig på `fb`, `fbadd` og `fbrm` **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `CommandPrefix`

`streng` type med standardværdi af `!`. Denne egenskab angiver præfikset **case sensitive** for ASF **[kommandoerne](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Med andre ord, dette er, hvad du har brug for at forberede til hver ASF kommando for at gøre ASF lytte til dig. Det er muligt at sætte denne værdi til `null` eller tom for at gøre ASF bruge ingen kommando prefix, i hvilket tilfælde du indtaster kommandoer med deres almindelige identifikatorer. Men gør det vil potentielt reducere ASF's ydeevne, da ASF er optimeret til ikke at fortolke meddelelsen yderligere, hvis den ikke starter med `CommandPrefix` - hvis du bevidst beslutter dig for ikke at bruge den, ASF vil blive tvunget til at læse alle meddelelser og reagere på dem, selvom de ikke er ASF kommandoer. Derfor anbefales det at fortsætte med at bruge nogle `CommandPrefix`såsom `/` hvis du ikke kan lide standard værdi af `!`. For konsistens påvirker `CommandPrefix` hele ASF-processen. Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

### `ConfirmationsLimiterDelay`

`byte` type med standardværdi `10`. ASF vil sikre, at der vil være mindst `ConfirmationsLimiterDelay` sekunder i mellem to på hinanden følgende 2FA bekræftelser, der henter anmodninger for at undgå at udløse hastighedsgrænse - dem bruges af **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** i løbet af e. . `2faok` kommando samt efter behov ved udførelse af forskellige handelsrelaterede operationer. Standardværdien blev sat baseret på vores tests og bør ikke sænkes, hvis du ikke ønsker at løbe ind i problemer. Medmindre du har en **stærk** grund til at redigere denne egenskab, bør du beholde den som standard.

---

### `ConnectionTimeout`

`byte` type med standardværdi `90`. Denne egenskab definerer timeouts for forskellige netværkshandlinger udført af ASF, på få sekunder. Navnlig definerer `ConnectionTimeout` timeout i sekunder for HTTP og IPC anmodninger, `ConnectionTimeout / 10` definerer maksimalt antal fejlslagne hjerteslag, mens `ConnectionTimeout / 30` definerer antallet af minutter, som vi tillader for første Steam netværksforbindelsesanmodning. Standardværdien på `90` bør være fin for de fleste mennesker, men hvis du har ret langsom netværksforbindelse eller PC, du måske ønsker at øge dette tal til noget højere (som `120`). Husk, at større værdier ikke magisk løser langsomme eller endda utilgængelige Steam-servere, så vi ikke bør vente uendeligt på noget, der ikke vil ske, og bare prøve igen senere. Indstilling af denne værdi for høj vil resultere i overdreven forsinkelse i fangst af netværksproblemer samt i reduktion af den samlede ydeevne. Indstilling af denne værdi for lav vil også reducere den samlede stabilitet og ydeevne, da ASF vil afbryde gyldig anmodning stadig blive fortolket. Derfor har indstilling af denne værdi lavere end standard ingen fordel i almindelighed. da Steam-servere har tendens til at være super langsomme fra tid til anden og kunne kræve mere tid til parsing af ASF-anmodninger. Standardværdien er en balance mellem at tro, at vores netværksforbindelse er stabil, og at tvivle på Steam-netværket for at håndtere vores anmodning i en given timeout. Hvis du ønsker at opdage problemer før og få ASF til at genforbinde/reagere hurtigere, standardværdien bør gøre (eller meget lidt nedenfor, såsom `60`, hvilket gør ASF mindre patient). Hvis du i stedet bemærker, at ASF kører ind i netværksproblemer, såsom svigtende anmodninger, hjerteslag, der går tabt eller forbindelse til Steam afbrudt, det giver sandsynligvis mening at øge denne værdi, hvis du er sikker på, at det er **ikke** forårsaget af dit netværk, men af Steam selv, som stigende timeouts gør ASF mere "patient" og ikke beslutter at genoprette forbindelsen med det samme.

Et eksempel situation, der kan kræve en stigning i denne ejendom er at lade ASF til at håndtere en meget stor handel tilbud, der kan tage godt 2+ minutter at blive fuldt accepteret og håndteret af Steam. Som stigende standard timeout, ASF vil være mere tålmodig og vente længere, før det beslutter, at handlen ikke går igennem, og opgive den oprindelige anmodning.

En anden situation kan være forårsaget af meget langsom maskine eller internetforbindelse, der kræver mere tid til at håndtere de data, der bliver overført. Dette er temmelig sjælden tilstand, da CPU/netværk båndbredde er næsten aldrig en flaskehals, men stadig en mulighed værd at nævne.

Kort sagt, standardværdien skal være anstændig for de fleste tilfælde, men du kan ønske at øge den, hvis det er nødvendigt. Stadig, at gå langt over standardværdien giver heller ikke megen mening, da større timeouts ikke magisk løser utilgængelige Steam-servere. Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

### `CurrentCulture`

`streng` type med standardværdi af `null`. Som standard forsøger ASF at bruge dit operativsystem sprog, og vil foretrække at bruge oversatte strenge på det sprog, hvis det er tilgængeligt. Dette er muligt takket være vores fællesskab, der forsøger at **[lokalisere](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** ASF på alle de mest populære sprog. Hvis du af en eller anden grund ikke ønsker at bruge dit OS modersmål, du kan bruge denne konfigurationsegenskab til at vælge hvilket som helst gyldigt sprog, du ønsker at bruge i stedet. For en liste over alle tilgængelige kulturer, besøg **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** og søg efter `Sprogtag`. Det er rart at bemærke, at ASF accepterer begge specifikke kulturer, såsom `"en-GB"`, men også neutrale, såsom `"en"`. Angivelse af nuværende kultur vil også påvirke andre kultur-specifik adfærd, såsom valuta/dato format og ens. Bemærk, at du kan have brug for yderligere skrifttype/sprogpakker til at vise sprogspecifikke tegn korrekt, hvis du valgte ikke-indfødte kultur, der gør brug af dem. Typisk ønsker du at gøre brug af denne config ejendom, hvis du foretrækker ASF på engelsk i stedet for dit modersmål.

---

### `Debug`

`bool` type med standardværdi af `false`. Denne egenskab definerer om processen skal køre i fejlfindingstilstand. Når i fejlfindingstilstand opretter ASF en særlig `debug` mappe ved siden af `config`, som holder styr på hele kommunikationen mellem ASF og Steam-servere. Debug information kan hjælpe med at spotte grimme problemer i forbindelse med netværk og generel ASF arbejdsgang. Hertil kommer, at nogle program rutiner vil være langt mere verbose, såsom `WebBrowser` med angivelse af præcis årsag til, at nogle anmodninger ikke er i stand - disse poster er skrevet til normal ASF log. **Du bør ikke køre ASF i fejlfindingstilstand, medmindre de bliver spurgt af udvikler**. Kører ASF i fejlfindingstilstand **nedsætter ydeevnen** **påvirker stabiliteten negativt** og er **langt mere verbose forskellige steder**, så det skal kun bruges **kun** forsætligt, i korte løb, til fejlfinding bestemt problem, gengive problemet eller få mere info om en fejlbehæftet anmodning, og ens, men **ikke** for normal programudførelse. Du vil se **en masse** af nye fejl, problemer, og undtagelser - sørg for, at du har en anstændig viden om ASF Damp og dens særheder, hvis du beslutter dig for at analysere alt dette selv, da ikke alt er relevant.

**ADVARSEL:** aktivering af denne tilstand omfatter logning af **potentielt følsomme** -oplysninger såsom logins og adgangskoder, som du bruger til at logge ind på Steam (på grund af netværkslogning). Disse data er skrevet til både `debug` mappe, samt standard `log. xt` (det er nu med vilje meget mere verbose for at logge denne info). Du bør ikke sende debug indhold genereret af ASF på nogen offentlig placering, ASF udvikler bør altid minde dig om at sende det til hans e-mail, eller en anden sikker placering. Vi lagrer ikke, og gør heller ikke brug af disse følsomme oplysninger, de er skrevet som en del af fejlfindingsrutiner, da deres tilstedeværelse kan være relevant for det problem, der påvirker dig. Vi ville foretrække, hvis du ikke ændrede ASF logning på nogen måde, men hvis du er bekymret, er du fri til at ændre disse følsomme oplysninger korrekt.

> Redacting indebærer at erstatte følsomme detaljer, for eksempel med stjerner. Du bør afholde dig fra at fjerne følsomme linjer helt, da deres rene eksistens kan være relevant og bør bevares.

---

### `DefaultBot`

`streng` type med standardværdi af `null`. I nogle scenarier fungerer ASF med et koncept om en standard bot, der er ansvarlig for at håndtere noget - for eksempel IPC kommandoer eller interaktiv konsol, når du ikke angiver target bot. Denne egenskab tillader dig at vælge standard bot ansvarlig for håndtering af sådanne scenarier, ved at sætte dens `BotName` her. Hvis givet bot ikke findes, eller du bruger en standardværdi på `null`, vil ASF vælge først registreret bot sorteret alfabetisk i stedet. Typisk ønsker du at gøre brug af denne config egenskab, hvis du ønsker at udelade `[Bots]` argument i IPC og interaktive konsol kommandoer, og altid vælge den samme bot som standard en for sådanne opkald.

---

### `FarmingDelay`

`byte` type med standardværdi af `15`. For at ASF skal fungere, vil det kontrollere aktuelt opdrættede spil hvert `FarmingDelay` minutter, hvis det måske droppede alle kort allerede. Indstilling af denne egenskab for lav kan resultere i overdreven mængde damp anmodninger bliver sendt, mens indstilling for høj kan resultere i ASF stadig "farming" givet titel for op til `FarmingDelay` minutter efter det er fuldt opdrættet. Standardværdi bør være fremragende for de fleste brugere, men hvis du har mange bots kører, kan du overveje at øge den til noget i retning af `30` minutter for at begrænse dampanmodninger bliver sendt. Det er rart at bemærke, at ASF bruger begivenhedsbaseret mekanisme og kontrollerer spil badge side på hver Steam element droppet, så generelt **behøver vi ikke engang at tjekke det i faste tidsintervaller**, men da vi ikke har fuld tillid til Steam-netværket - tjekker vi spilbadge-siden alligevel, hvis vi ikke tjekkede det gennem kortet blev droppet begivenhed i sidste `FarmingDelay` minutter (i tilfælde af at Steam-netværket ikke informerede os om element droppet eller ting som dette). Antages det, at Steam-netværk fungerer korrekt, vil faldende denne værdi **ikke forbedre landbrugseffektiviteten på nogen måde**, mens **øger netværkets overhead markant** - det anbefales kun at øge det (hvis nødvendigt) fra standard `15` minutter. Medmindre du har en **stærk** grund til at redigere denne egenskab, bør du beholde den som standard.

---

### `FilterBadBots`

`bool` type med standardværdi af `true`. Denne ejendom definerer, om ASF automatisk vil afvise handelstilbud, der modtages fra kendte og markerede dårlige skuespillere. For at gøre det, kommunikerer ASF med vores server efter behov for at hente en liste over sortlistede Steam-identifikatorer. De anførte bots drives af folk, der er klassificeret som skadelige for ASF initiativ af os, såsom dem, der overtræder vores **[Code of conduct](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, brug leveret funktionalitet og ressourcer af os såsom **[`PublicListing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** for at misbruge og udnytte andre personer eller gør direkte kriminel aktivitet såsom at lancere DDoS-angreb på serveren. Da ASF har en stærk holdning til generel retfærdighed, ærlighed og samarbejde mellem sine brugere for at få hele samfundet til at trives denne ejendom er aktiveret som standard, og derfor ASF filtre bots, som vi har klassificeret som skadelige fra tjenester, der tilbydes. Medmindre du har en **stærk** grund til at redigere denne egenskab, såsom uenighed med vores erklæring og med vilje tillade disse robotter at operere (herunder udnytte dine konti), bør du holde det som standard.

---

### `GiftsLimiterDelay`

`byte` type med standardværdi af `1`. ASF vil sikre, at der vil være mindst `GiftsLimiterDelay` sekunder mellem to på hinanden følgende gave/nøgle/licenshåndtering (indløsning) anmodninger for at undgå at udløse satsgrænsen. Ud over at det også vil blive brugt som global limiter for spillisteforespørgsler såsom den, der er udstedt af `ejer` **[-kommandoen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Medmindre du har en **stærk** grund til at redigere denne egenskab, bør du beholde den som standard.

---

### `Headless`

`bool` type med standardværdi af `false`. Denne egenskab definerer om processen skal køre i hovedløs tilstand. Når den er i hovedløs tilstand, antager ASF, at den kører på en server eller i et andet ikke-interaktivt miljø vil den derfor ikke forsøge at læse oplysninger gennem konsolinput. Dette omfatter on-demand detaljer (kontooplysninger såsom 2FA-kode, SteamGuard kode password eller enhver anden variabel, der kræves for ASF at operere) samt alle andre konsolindgange (såsom interaktiv kommandokonsol). Med andre ord, `Headless` tilstand er lig med at gøre ASF konsollen skrivebeskyttet. Denne indstilling er hovedsagelig nyttig for brugere, der kører ASF på deres servere, i stedet for at spørge e. . For 2FA-kode vil ASF lydløst afbryde operationen ved at stoppe en konto. Medmindre du kører ASF på en server, og du tidligere bekræftet, at ASF er i stand til at operere i ikke-hovedløs tilstand, du bør holde denne egenskab deaktiveret. Enhver brugerinteraktion vil blive nægtet, når i hovedløs tilstand, og dine konti vil ikke køre, hvis de kræver **enhver** -konsol-input under start. Dette er nyttigt for servere, da ASF kan afbryde forsøg på at logge på kontoen, når der bliver bedt om legitimationsoplysninger, i stedet for at vente (uendeligt) for brugeren at give dem.

Aktivering af denne tilstand vil give dig mulighed for at levere nødvendig konsol-input på andre måder, dvs. ASF-ui (ASF API), eller gennem **[`input`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#input-command)** kommando. Hvis du ikke er sikker på, hvordan du sætter denne egenskab, så lad den være med standardværdien af `false`.

---

### `IdleFarmingPeriod`

`byte` type med standardværdi `8`. Når ASF ikke har noget at dyrke, vil det periodisk kontrollere alle `IdleFarmingPeriod` timer, hvis måske konto fik nogle nye spil til at bedrifte. Denne funktion er ikke nødvendig, når du taler om nye spil, vi får, da ASF er smart nok til automatisk at tjekke badge sider i dette tilfælde. `IdleFarmingPeriod` er primært i situationer som gamle spil, vi allerede har fået tilføjet handelskort. I dette tilfælde er der ingen hændelse, så ASF er nødt til periodisk at tjekke badge sider, hvis vi ønsker at få dette dækket. Værdi af `0` deaktiverer denne funktion. Kontrol: `ShutdownOnFarmingFinished` præference i `FarmingPreferences`.

---

### `InventoryLimiterDelay`

`byte` type med standardværdi `4`. ASF vil sikre, at der vil være mindst `InventoryLimiterDelay` sekunder mellem to på hinanden følgende anmodninger om webinventar for at undgå at udløse hastighedsgrænse - dem bruges for eksempel under markeringen af lagermeddelelser som læst, kan også bruges af tredjeparts plugins hente opgørelse af andre brugere. Denne ejendom bruges ikke til at hente vores egen beholdning, da ASF bruger meget mere effektiv interne netværk opkald til det, så det vil ikke påvirke kommandoer som `loot` eller `overføre` på nogen måde. Standardværdien af `4` blev fastsat på grundlag af markeringsopgørelser af over 100 på hinanden følgende bot-tilfælde og bør tilfredsstille de fleste (hvis ikke alle) af brugerne. Du kan dog ønske at reducere den, eller endda ændre til `0` , hvis du har meget lav mængde bots, så ASF ignorerer forsinkelsen og markerer Steam-lagerbeholdninger meget hurtigere. Men bliv advaret, da indstillingen for lav **vil** resultere i Steam midlertidigt at forbyde din IP, og det vil forhindre dig i at foretage nogen opkald overhovedet. Du kan også være nødt til at øge denne værdi, hvis du kører en masse bots med en masse lagerforespørgsler, selvom du i dette tilfælde sandsynligvis skal forsøge at begrænse antallet af disse anmodninger i stedet. Medmindre du har en **stærk** grund til at redigere denne egenskab, bør du beholde den som standard.

---

### `IPC`

`bool` type med standardværdi af `true`. Denne egenskab definerer, om ASF's **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** server skal starte sammen med processen. IPC tillader interproceskommunikation, herunder brug af **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, ved at starte en lokal HTTP-server. Hvis du ikke har til hensigt at bruge nogen tredjeparts-IPC-integration med ASF, herunder vores ASF-ui, kan du uden risiko deaktivere denne mulighed. Ellers, er det en god idé at holde det aktiveret (standardindstilling).

---

### `IPCPassword`

`streng` type med standardværdi af `null`. Denne egenskab definerer obligatorisk adgangskode for hvert API-opkald udført via IPC og fungerer som en ekstra sikkerhedsforanstaltning. Når sat til ikke-tom værdi, vil alle IPC-anmodninger kræve ekstra `adgangskode` -egenskaben sat til adgangskoden angivet her. Standardværdien for `null` vil springe et behov for adgangskoden, hvilket får ASF til at respektere alle forespørgsler. Ud over det, aktivering af denne indstilling muliggør også indbygget IPC anti-bruteforce mekanisme, som midlertidigt vil forbyde givet `IPAddress` efter at have sendt for mange uautoriserede anmodninger på meget kort tid. Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

### `IPCPasswordFormat`

`byte` type med standardværdi `0`. Denne egenskab definerer `IPCPassword` -egenskaben og bruger `EHashingMethod` som underliggende type. Se venligst **[Security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** -sektionen, hvis du ønsker at lære mere, da du skal sikre, at `IPCPassword` -egenskaben faktisk indeholder adgangskode i matchende `IPCPasswordFormat`. Med andre ord, når du ændrer `IPCPasswordFormat` så skal dit `IPCPassword` være **allerede** i dette format, ikke bare sigter mod at være. Medmindre du ved, hvad du laver, skal du holde det med standardværdi på `0`.

---

### `LicenseID`

`Guid?` type med standardværdi af `null`. Denne ejendom tillader vores **[sponsorer](https://github.com/sponsors/JustArchi)** at forbedre ASF med valgfrie funktioner, der kræver betalte ressourcer for at arbejde. For nu, giver dette dig mulighed for at gøre brug af **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** funktion i `ItemsMatcher` plugin.

Mens vi anbefaler dig at udnytte GitHub, da det tilbyder månedlige og engangs-niveauer, samt giver fuld automatisering og giver dig øjeblikkelig adgang, we **also** support all other currently available **[donation options](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. Se **[dette indlæg](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** for instruktioner om, hvordan man donerer ved hjælp af andre metoder for at få en manuel licens gyldig for en given periode.

Uanset hvilken metode du bruger, kan du få din licens **[her](https://asf.justarchi.net/User/Status)**. Du skal logge ind med GitHub for at bekræfte din identitet, vi beder kun om skrivebeskyttet offentlig information, som er dit brugernavn. `LicenseID` er lavet af 32 hexadecimale tegn, såsom `f6a0529813f74d119982eb4fe43a9a24`.

**Sørg for, at du ikke deler dit `LicenseID` med andre personer**. Da det er udstedt på personligt grundlag, kan det blive tilbagekaldt, hvis det er lækket. Hvis det tilfældigvis skete for dig ved et uheld, kan du generere en ny fra samme sted.

Medmindre du ønsker at aktivere ekstra ASF funktioner, er der ingen grund til at opnå/levere licensen.

---

### `LoginLimiterDelay`

`byte` type med standardværdi `10`. ASF vil sikre, at der vil være mindst `LoginLimiterDelay` sekunder mellem to på hinanden følgende forbindelsesforsøg for at undgå at udløse hastighedsgrænse. Standardværdien af `10` blev sat baseret på tilslutning af over 100 bot instanser, og skulle tilfredsstille de fleste (hvis ikke alle) af brugerne. Du kan dog ønske at stige/reducere den, eller endda ændre til `0` , hvis du har meget lav mængde bots, så ASF vil ignorere forsinkelsen og oprette forbindelse til Steam meget hurtigere. Vær dog advaret om, da indstilling af det for lavt, mens du har for mange bots **vil** resultere i Steam midlertidigt at forbyde din IP, og det vil forhindre dig i at logge på **på alle**, med `InvalidPassword/RateLimitOverskredet` fejl - og det omfatter også din normale Steam-klient, ikke kun ASF. Ligeledes hvis du kører for mange bots, især sammen med andre Steam-klienter/-værktøjer ved hjælp af den samme IP-adresse, mest sandsynligt skal du øge denne værdi for at sprede logins over længere tid.

Som en sidebemærkning anvendes denne værdi også som load-balanceringsbuffer i alle ASF-planlagte handlinger, såsom handler i `SendTradePeriod`. Medmindre du har en **stærk** grund til at redigere denne egenskab, bør du beholde den som standard.

---

### `MaxFarmingTime`

`byte` type med standardværdi `10`. Som du bør vide, er Steam ikke altid fungerer korrekt, nogle gange underlige situationer kan ske, såsom at vores spilletid ikke bliver registreret, på trods af, at i virkeligheden spille et spil. ASF vil tillade landbrug et enkelt spil i solo mode i maksimalt `MaxFarmingTime` timer, og overveje det fuldt opdrættet efter denne periode. Dette er nødvendigt for ikke at fastfryse landbrugsprocessen i tilfælde af underlige situationer, der sker, men også hvis Steam af en eller anden grund har udgivet et nyt badge, der vil forhindre ASF i at gå videre (se: `Blacklist`). Standardværdien af `10` timer skal være nok til at slippe alle dampkort fra et spil. Indstilling af denne egenskab for lav kan resultere i, at gyldige spil springes over (og ja, der er gyldige spil, der tager op til 9 timer til at dyrke spil), samtidig med at den sættes for højt, kan resultere i, at landbrugsprocessen bliver frosset. Bemærk venligst, at denne ejendom kun påvirker et enkelt spil i en enkelt landbrugssession (så efter at have været igennem hele køen vil ASF vende tilbage til denne titel) også det er ikke baseret på total spilletid, men intern ASF landbrugstid, så ASF vil også vende tilbage til denne titel efter en genstart. Medmindre du har en **stærk** grund til at redigere denne egenskab, bør du beholde den som standard.

---

### `MaxTradeHoldDuration`

`byte` type med standardværdi af `15`. Denne egenskab definerer maksimal varighed af handel hold i dage, som vi er villige til at acceptere - ASF vil afvise handler, der holdes i mere end `MaxTradeHoldVarighed` dage. som defineret i afsnit **[-handel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**. Denne indstilling giver kun mening for bots med `TradingPreferences` af `SteamTradeMatcher`, da det ikke påvirker `Master`/`SteamOwnerID` handler, heller ikke donationer. Handelen er irriterende for alle, og ingen ønsker virkelig at håndtere dem. ASF skal arbejde på liberale regler og hjælpe alle, uanset om på handel hold eller ej - det er derfor, denne mulighed er sat til `15` som standard. Men hvis du i stedet foretrækker at afvise alle handler, der påvirkes af handlen, kan du angive `0` her. Overvej venligst, at kort med kort levetid ikke påvirkes af denne mulighed og automatisk afvises for folk med handel holdninger, som beskrevet i afsnittet **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** så der er ingen grund til globalt at afvise alle kun på grund af det. Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.


---

### `MinFarmingDelayAfterBlock`

`byte` type med standardværdi `60`. Denne ejendom definerer minimum tid, i sekunder, hvilken ASF vil vente, før genoptagelse af kort landbrug, hvis den tidligere er blevet afbrudt med `LoggedInElsewhere`, hvilket sker, når du beslutter dig for kraftigt at afbryde nuværende landbrug ASF ved at lancere et spil. Denne forsinkelse eksisterer hovedsagelig af bekvemmeligheds- og generalgrunde for eksempel giver det dig mulighed for at genstarte spillet uden at skulle kæmpe med ASF indtager din konto igen, kun fordi spille lås var tilgængelig for et split sekund. På grund af at genindvinding af sessionen forårsager `LoggedInElsewhere` afbrydelse, skal ASF gennemgå hele genforbindelsesproceduren. som lægger yderligere pres på maskinen og Steam-netværket, er det derfor at foretrække at undgå yderligere afbrydelser, hvis det er muligt. Som standard er dette konfigureret på `60` sekunder, hvilket skal være nok til at tillade dig at genstarte spillet uden meget besvær. Men der er scenarier, når du kunne være interesseret i at øge det, for eksempel hvis dit netværk afbryder ofte og ASF overtager for tidligt, hvilket medfører, at du bliver tvunget til at gå gennem genforbindelsesprocessen selv. Vi tillader en maksimal værdi på `255` for denne ejendom, hvilket skal være nok for alle fælles scenarier. Ud over ovenstående, er det også muligt at reducere forsinkelsen, eller endda fjerne det helt med en værdi på `0`, selv om det normalt ikke anbefales på grund af ovennævnte årsager. Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

### `OptimizationMode`

`byte` type med standardværdi `0`. Denne egenskab definerer optimeringstilstand, som ASF vil foretrække under kørsel. I øjeblikket ASF understøtter to tilstande - `0` , som kaldes `MaxPerformance`, `1` som kaldes `MinMemoryUsage`. Som standard foretrækker ASF at køre så mange ting parallelt (samtidigt) som muligt. som forbedrer ydeevnen ved load-balancering arbejde på tværs af alle CPU-kerner, flere CPU-tråde, flere stikkontakter og flere tråde opgaver. For eksempel vil ASF bede om din første badge side, når du tjekker for spil til gård, og derefter når anmodning ankommet, ASF vil læse fra det, hvor mange badge sider du rent faktisk har, derefter anmode om hinanden sideløbende. Dette er, hvad du skal have **næsten altid**, som overhead i de fleste tilfælde er minimal og fordele fra asynkron ASF kode kan ses selv på de ældste hardware med en enkelt CPU kerne og stærkt begrænset strøm. Men med mange opgaver, der behandles parallelt, er ASF driftstid ansvarlig for deres vedligeholdelse, f.eks. holde stikkontakter åbne, tråde i live og opgaver der behandles hvilket kan resultere i øget hukommelsesforbrug fra tid til anden, og hvis du er ekstremt begrænset af tilgængelig hukommelse, kan du skifte denne ejendom til `1` (`MinMemoryUsage`) for at tvinge ASF til at bruge så få opgaver som muligt og typisk kører mulig-til-parallel asynkron kode på en synkron måde. Du bør kun overveje at skifte denne egenskab, hvis du tidligere har læst **[lav hukommelse setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** og du med vilje vil ofre gigantisk ydeevne boost, for en meget lille hukommelse overhead nedgang. Normalt er denne indstilling **meget værre** end hvad du kan opnå med andre mulige måder, såsom ved at begrænse din ASF brug eller tuning runtime garbage collector, som forklaret i **[lav hukommelse setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Derfor bør du bruge `MinMemoryUsage` som en **sidste udvej**, lige før runtime genkompilering, hvis du ikke kunne opnå tilfredsstillende resultater med andre (meget bedre) muligheder. Medmindre du har en **stærk** grund til at redigere denne egenskab, bør du beholde den som standard.

---

### `PluginsUpdateList`

`ImmutableHashSet<string>` type med standardværdi for at være tom. Denne egenskab definerer liste over plugin samling navne, der er enten sortlistet eller hvidlistet for at blive taget i betragtning for automatiske opdateringer, som pr. `PluginsUpdateMode` defineret nedenfor.

Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

### `PluginsUpdateMode`

`byte` type med standardværdi `0`. Denne egenskab definerer plugins-opdateringstilstand, der giver mening til `PluginsUpdateList` defineret ovenfor. Ved at angive denne egenskab kan du nemt aktivere/deaktivere automatiske opdateringer for alle plugins undtagen dem, der er erklæret.

- Værdi af `0`, kaldet `Whitelist`, **deaktiverer automatisk opdatering af** af alle plugins, undtagen dem der er defineret i `PluginsUpdateList`.
- Værdi af `1`, kaldet `Blacklist`, **aktiverer** automatisk opdatering af alle plugins, undtagen dem der er defineret i `PluginsUpdateList`.

**ASF team vil gerne minde dig om, at for din egen sikkerhed, bør du kun aktivere automatiske opdateringer fra betroede parter**. Husk, at ondsindede plugins kan beslutte at opdatere sig selv eller udføre eksterne kommandoer **uanset** i denne indstilling, Dette er grunden til, at denne indstilling gælder for ASF-forudsat plugins opdatering funktionalitet, udelukkende, og du bør stadig sikre, at du har behørigt verificeret hver plugin, som du har besluttet at bruge.

Opdateringer af plugins udføres som standard sammen med ASF update rutine - **[`UpdateChannel`](#updatechannel)** og **[`UpdatePeriod`](#updateperiod)**. Standard ASF opdatering mekanismer såsom `update` kommando vil også udløse valgfri plugins opdatering. Hvis du i stedet ønsker at opdatere plugins manuelt uden at opdatere ASF-version på samme tid, tilbyder kommandoen `updateplugins` en sådan mulighed.

Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

### `ShutdownIfPossible`

`bool` type med standardværdi af `false`. Når aktiveret, vil ASF forsøge at lukke processen, hvis det er muligt, det vil sige, når alle dine registrerede bots stoppes. Dette kan være særligt nyttigt, når det kombineres med `ShutdownOnFarmingFinished` på alle dine bot-instanser, da denne måde ASF vil få lov til automatisk at lukke ned, når den sidste af dine robotter slutter landbrug.

Siden forventning hos de fleste af brugerne er at få processen til at køre på alle tidspunkter, e. . for brug af `IPC` , denne indstilling er som standard deaktiveret.

---

### `SteamMessagePrefix`

`streng` type med standardværdi af `"/me "`. Denne egenskab definerer et præfiks som vil blive foranstillet til alle Steam-beskeder sendes af ASF. Som standard bruger ASF `"/me "` præfiks for lettere at skelne bot beskeder ved at vise dem i forskellige farver på Steam chat. En anden værdig omtale er `"/pre "` præfiks som opnår lignende resultat, men bruger forskellig formatering. Du kan også indstille denne egenskab til tom streng eller `null` for at deaktivere brugen af præfiks helt og output alle ASF beskeder på en traditionel måde. Det er rart at bemærke, at denne egenskab kun påvirker Steam-meddelelser - svar returneret gennem andre kanaler (såsom IPC) er ikke påvirket. Medmindre du ønsker at tilpasse standard ASF adfærd, er det en god idé at lade det være som standard.

---

### `SteamOwnerID`

`ulong` type med standardværdi af `0`. Denne egenskab definerer Steam ID i 64-bit form af ASF proces ejer, og er meget lig `Master` tilladelse af given bot instans (men global i stedet). Du ønsker næsten altid at indstille denne egenskab til ID for din egen Steam-hovedkonto. `Master` tilladelse omfatter fuld kontrol over hans bot eksempel, men globale kommandoer såsom `exit`, `genstart` eller `opdatering` er kun reserveret til `SteamOwnerID`. Dette er praktisk, da du måske ønsker at køre bots for dine venner, mens de ikke tillader dem at styre ASF-processen, såsom at afslutte den via kommandoen `exit`. Standardværdi på `0` angiver, at der ikke er nogen ejer af ASF-processen, hvilket betyder, at ingen vil være i stand til at udstede globale ASF kommandoer. Husk, at denne egenskab kun gælder for Steam-chat. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**samt interaktiv konsol, vil stadig tillade dig at udføre `Ejer` kommandoer, selvom denne egenskab ikke er angivet.

---

### `SteamProtocols`

`byte flag` type med standardværdi `7`. Denne egenskab definerer Steam-protokoller, som ASF vil bruge ved tilslutning til Steam-servere, som er defineret som nedenfor:

| Værdi | Navn      | Beskriveslse                                                                                     |
| ----- | --------- | ------------------------------------------------------------------------------------------------ |
| 0     | None      | No protocol                                                                                      |
| 1     | TCP       | **[Transmission Control Protocol](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2     | UDP       | **[User Datagram Protocol](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**               |
| 4     | WebSocket | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                                         |

Bemærk venligst, at denne egenskab er `flag` feltet, derfor er det muligt at vælge en hvilken som helst kombination af tilgængelige værdier. Tjek **[json mapping](#json-mapping)** hvis du gerne vil lære mere. Aktiverer ingen af flag resulterer i `Ingen` valgmulighed, og denne mulighed er ugyldig af sig selv.

Som standard vil ASF bruge alle tilgængelige Steam-protokoller som en foranstaltning til at kæmpe med nedetider og andre lignende Steam-problemer. Typisk vil du ændre denne egenskab, hvis du kun vil begrænse ASF til at bruge en eller to specifikke protokoller. Sådanne foranstaltninger kan være nødvendige i forskellige situationer — for eksempel hvis du har blokeret UDP trafik på din firewall og du ønsker at sikre, at kun TCP trafik går igennem, eller hvis du bruger `WebProxy` og ønsker at bruge den også til Steam-klientforbindelse, som kun `WebSocket` -protokollen understøtter dette.

Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

### `UpdateChannel`

`byte` type med standardværdi af `1`. Denne egenskab definerer opdateringskanalen som bruges, enten for auto-opdateringer (hvis `UpdatePeriod` er større end `0`) eller opdaterer notifikationer (ellers ). ASF understøtter i øjeblikket tre opdateringskanaler - `0` , som kaldes `Ingen`, `1`, som kaldes `Stabil`og `2`, som kaldes `PreRelease`. `Stabil` kanal er standard release kanal, som bør anvendes af de fleste brugere. `PreRelease` kanal i tillæg til `Stabil` udgivelser, omfatter også **præudgivelser** dedikeret til avancerede brugere og andre udviklere for at teste nye funktioner bekræft fejlrettelser eller giv feedback om planlagte forbedringer. **PreRelease versioner indeholder ofte unpatched bugs, work-in-progress features eller omskrevet implementeringer**. Hvis du ikke betragter dig selv avanceret bruger, så bliv venligst med standard `1` (`Stabil`) opdateringskanal. `PreRelease` kanal er dedikeret til brugere, der ved, hvordan man rapporterer fejl, behandle spørgsmål og give feedback - der vil ikke blive givet teknisk støtte. Tjek ASF **[udgivelsescyklus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** , hvis du vil lære mere. Du kan også indstille `UpdateChannel` til `0` (`Ingen`), hvis du vil fjerne alle versionskontroller. Indstilling af `UpdateChannel` til `0` vil helt deaktivere hele funktionalitet relateret til opdateringer, herunder `opdatering` kommando. Brug af `Ingen` kanal er **kraftigt frarådet** på grund af at udsætte dig selv for alle slags problemer (nævnt i `UpdatePeriod` beskrivelse nedenfor).

**Medmindre du ved, hvad du laver**, anbefaler vi **på det kraftigste** at holde det som standard.

---

### `UpdatePeriod`

`byte` type med standardværdi `24`. Denne egenskab definerer hvor ofte ASF skal kontrollere for auto-opdateringer. Opdateringer er afgørende ikke kun for at modtage nye funktioner og kritiske sikkerhedsrettelser, men også for at modtage fejlrettelser, forbedringer af ydeevnen, stabilitetsforbedringer og meget mere. Når en værdi større end `0` er angivet, vil ASF automatisk downloade, erstatte og genstart sig selv (hvis `AutoGenstart` tillader), når ny opdatering er tilgængelig. For at opnå dette, vil ASF tjekke alle `UpdatePeriod` timer, hvis ny opdatering er tilgængelig på vores GitHub repo. En værdi på `0` deaktiverer auto-opdateringer, men giver dig stadig mulighed for at udføre kommandoen `opdatering` manuelt. Du kan også være interesseret i at indstille passende `UpdateChannel` , som `UpdatePeriod` skal følge.

Den opdaterede ASF indebærer en opdatering af hele mappestrukturen, som ASF bruger men uden at røre dine egne configs eller databaser placeret i mappen `config` - det betyder, at eventuelle ekstra filer der ikke er relateret til ASF i mappen kan gå tabt under opdatering. Standardværdien af `24` er en god balance mellem unødvendige kontroller og ASF, der er frisk nok.

Medmindre du har en **stærk** grund til at deaktivere denne funktion, du bør holde auto-opdateringer aktiveret inden for rimelige `UpdatePeriod` **for din egen gode**. Dette er ikke kun fordi vi ikke understøtter noget, men den seneste stabile ASF-udgivelse, men også fordi **giver vi kun vores sikkerhedsgaranti for seneste version**. Hvis du bruger forældet ASF-version, så du bevidst udsætter dig selv for alle slags problemer, fra små bugs, gennem brudt funktionalitet, ending with **[permanent Steam account suspensions](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**, så vi **anbefaler kraftigt**for dit eget bedste, for altid at sikre, at din ASF-version er opdateret. Auto-opdateringer giver os mulighed for at reagere hurtigt på alle slags problemer ved at deaktivere eller lappe problematiske kode, før den kan eskalere - hvis du fravælger det, du mister alle vores sikkerhedsgarantier og risici konsekvenser af at køre kode, der kan være potentielt skadelige, ikke kun til Steam-netværket, men også (pr. definition) til din egen Steam-konto.

---

### `WebLimiterDelay`

`ushort` type med standardværdi `300`. Denne egenskab definerer i milisekunder, det mindste antal forsinkelser mellem at sende to på hinanden følgende anmodninger til den samme Steam-web-service. En sådan forsinkelse er påkrævet som **[AkamaiGhost](https://www.akamai.com)** -tjenesten, som Steam bruger internt, inkluderer hastighedsbegrænsning baseret på det globale antal anmodninger, der sendes på tværs af en given tidsperiode. Under normale omstændigheder er akamai blok temmelig svært at opnå, men under meget tunge arbejdsbyrder med en enorm løbende kø af anmodninger det er muligt at udløse det, hvis vi bliver ved med at sende for mange anmodninger på tværs af for kort tid.

Standardværdien blev sat baseret på antagelsen om, at ASF er det eneste værktøj, der tilgår Steam-web-tjenester, især `-dampfællesskab. om`, `api.steampowered.com` og `store.steampowered.com`. Hvis du bruger andre værktøjer til at sende anmodninger til de samme web-tjenester, så skal du sørge for, at dit værktøj indeholder lignende funktionalitet af `WebLimiterDelay` og indstille både til dobbelt standardværdi som ville være `600`. Dette garanterer, at du under ingen omstændigheder vil overskride afsendelse af mere end 1 anmodning pr. `300` ms.

Generelt sænker `WebLimiterDelay` under standardværdi er **kraftigt afskrækket** , da det kan føre til forskellige IP-relaterede blokke, nogle af dem kan være permanente. Standardværdien er god nok til at køre en enkelt ASF instans på serveren samt ved hjælp af ASF i normalt scenario sammen med originale Steam-klient. Det bør være korrekt for de fleste anvendelser, og du bør kun øge det (aldrig sænke det). Kort sagt, globalt antal af alle anmodninger sendt fra en enkelt IP til et enkelt Steam-domæne må aldrig overstige mere end 1 anmodning pr. `300` ms.

Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

### `WebProxy`

`streng` type med standardværdi af `null`. Denne egenskab definerer en webproxy-adresse, der vil blive brugt til intern http-relateret kommunikation, især til tjenester såsom `github. om`, `api.steampowered.com`, `steamcommunity.com` og `store.steampowered.com`. Det gælder for generel (ikke-bot specifikke) kommunikation, samt bot-specifik kommunikation, hvis deres tilsvarende `WebProxy` konfigurationsegenskaber ikke er angivet. Proxying ASF anmodninger kunne være usædvanligt nyttigt for omgå forskellige former for firewalls, især den store firewall i Kina.

Denne egenskab er defineret som uri streng:

> En URI-streng består af et system (understøttet: http/https/socks4/socks4a/socks5), en vært og en valgfri port. Et eksempel på en komplet uri streng er `"http://contoso.com:8080"`.

Hvis din proxy kræver brugergodkendelse, skal du også konfigurere `WebProxyBrugernavn` og/eller `WebProxyPassword`. Hvis der ikke er et sådant behov, er det tilstrækkeligt at oprette denne ejendom alene.

Hvis du også har brug for proxying intern Steam-netværkskommunikation (CM'er) så skal du sikre dig at konfigurere **[`SteamProtocols`](#steamprotocols)** bots ejendom til en værdi, der tillader kun websocket transport, i. . a value of `4`, as only websockets are supported for proxying.

Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

### `WebProxyPassword`

`streng` type med standardværdi af `null`. Denne egenskab definerer password felt bruges i grundlæggende, fordøjelse, NTLM, og Kerberos godkendelse, der understøttes af et mål `WebProxy` maskine leverer proxy funktionalitet. Hvis din proxy ikke kræver brugeroplysninger, er der ingen grund til, at du indtaster noget her. Brug af denne indstilling giver kun mening, hvis `WebProxy` bruges så godt, da det ikke har nogen effekt ellers.

Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

### `WebProxyUsername`

`streng` type med standardværdi af `null`. Denne egenskab definerer brugernavn feltet der bruges i grundlæggende, fordøjelse, NTLM, og Kerberos godkendelse, der understøttes af et mål `WebProxy` maskine leverer proxy funktionalitet. Hvis din proxy ikke kræver brugeroplysninger, er der ingen grund til, at du indtaster noget her. Brug af denne indstilling giver kun mening, hvis `WebProxy` bruges så godt, da det ikke har nogen effekt ellers.

Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

## Bot config

Som du bør vide allerede, hver bot bør have sin egen config baseret på eksempel JSON struktur nedenfor. Start med at beslutte, hvordan du vil navngive din bot (f.eks. `1.json`, `main. Søn`, `primær.json` eller `AnythingElse.json`) og gå over til konfiguration.

**Bemærk:** Bot kan ikke navngives `ASF` (da dette søgeord er reserveret til global konfiguration) ASF vil også ignorere alle konfigurationsfiler startende med en prik.

Bot config har følgende struktur:

```json
{
    "AcceptGifts": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null
    "CustomGamePlayedWhileIdle": null,
    "Aktiveret": false,
    "FarmingOrders": [],
    "FarmingPreferences": 0,
    "GamesPlayedWhileIdle": [],
    "GamingDeviceType": 1,
    "HoursUntilCardDrops": 3,
    "LootableTyper": [1, 3, 5],
    "MachineName": null,
    "MatchableTypes": [5],
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "Adgangskodeformat": 0,
    "Indløsningspræferencer": 0,
    "Fjernkommunikation": 3,
    "SendTradePeriod": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "TransferableTypes": [1, 3, 5],
    "UseLoginKeys": true,
    "UserInterfaceMode": 0,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Alle muligheder er forklaret nedenfor:

### `AcceptGifts`

`bool` type med standardværdi af `false`. Når aktiveret, vil ASF automatisk acceptere og indløse alle dampgaver (herunder tegnebogs gavekort) sendt til boten. Dette omfatter også gaver sendt fra andre brugere end dem, der er defineret i `SteamUserPermissions`. Husk, at gaver sendt til e-mail-adresse ikke direkte videresendt til klienten, så ASF vil ikke acceptere dem uden din hjælp.

Denne indstilling anbefales kun til alt konti, da det er meget sandsynligt, at du ikke vil automatisk indløse alle gaver, der sendes til din primære konto. Hvis du er usikker på, om du vil have denne funktion aktiveret eller ej, så behold den med standardværdien `false`.

---

### `BotBehaviour`

`byte flag` type med standardværdi `0`. Denne egenskab definerer ASF bot-lignende adfærd under forskellige begivenheder og er defineret som nedenfor:

| Værdi | Navn                          | Beskriveslse                                                                                      |
| ----- | ----------------------------- | ------------------------------------------------------------------------------------------------- |
| 0     | None                          | Ingen særlige bot adfærd, sane standardindstillinger                                              |
| 1     | RejectInvalidFriendInvites    | Vil få ASF til at afvise (i stedet for at ignorere) ugyldige venneinvitationer                    |
| 2     | RejectInvalidTrades           | Vil få ASF til at afvise (i stedet for at ignorere) ugyldige handelstilbud                        |
| 4     | RejectInvalidGroupInvites     | Vil få ASF til at afvise (i stedet for at ignorere) ugyldige gruppeinvitationer                   |
| 8     | DismissInventoryNotifications | Vil få ASF til automatisk at afvise alle lagernotifikationer                                      |
| 16    | MarkReceivedMessagesAsRead    | Vil få ASF til automatisk at markere alle modtagne beskeder som læst                              |
| 32    | MarkBotMessagesAsRead         | Vil få ASF til automatisk at markere beskeder fra andre ASF bots (kører i samme instans) som læst |
| 64    | DisableIncomingTradesParsing  | Vil få ASF til aldrig at behandle indgående handelstilbud                                         |

Bemærk venligst, at denne egenskab er `flag` feltet, derfor er det muligt at vælge en hvilken som helst kombination af tilgængelige værdier. Tjek **[json mapping](#json-mapping)** hvis du gerne vil lære mere. Aktiverer ikke nogen af flag resulterer i `Ingen` valgmulighed.

Generelt ønsker du at ændre denne egenskab, hvis du forventer at ændre forskellige automatiseringsindstillinger relateret til bot's aktivitet. Standardindstillingerne involverer ASF, der kører i ikke-invasiv tilstand, hvilket kun muliggør gavnlig automatisering, der ikke går imod brugerens vilje.

Ugyldig venneinvitation er en invitation, der ikke kommer fra bruger med `FamilySharing` tilladelse (defineret i `SteamUserPermissions`eller derover. ASF i normal tilstand ignorerer disse invitationer, som du ville forvente, giver dig frit valg om at acceptere dem, eller ej. `Afviste InvalidFriendInvites` vil få disse invitationer til automatisk at blive afvist som praktisk talt vil deaktivere mulighed for andre personer til at tilføje dig til deres venneliste (som ASF vil nægte alle sådanne anmodninger, bortset fra personer defineret i `SteamUserPermissions`). Medmindre du vil afvise alle venneinvitationer, bør du ikke aktivere denne indstilling.

Ugyldigt handelstilbud er et tilbud, der ikke accepteres gennem indbygget ASF-modul. Mere om dette kan findes i **[handel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** -sektionen, som eksplicit definerer, hvilke typer af handel ASF er villige til at acceptere automatisk. Gyldige handler er også defineret af andre indstillinger, især `TradingPreferences`. `RejectInvalidTrades` vil få alle ugyldige handelstilbud til at blive afvist, i stedet for at blive ignoreret. Medmindre du vil afvise alle handelstilbud, der ikke automatisk accepteres af ASF, bør du ikke aktivere denne mulighed.

Ugyldig gruppeinvitation er en invitation, der ikke kommer fra `SteamMasterClanID` gruppen. ASF i normal tilstand ignorerer disse gruppeinvitationer, som du ville forvente, giver dig mulighed for selv at beslutte, om du vil deltage i bestemt Steam-gruppe eller ej. `Afvis InvalidGroupInvites` vil få alle disse gruppe til at blive automatisk afvist effektivt at gøre det umuligt at invitere dig til andre grupper end `SteamMasterClanID`. Medmindre du ønsker at afvise alle gruppeinvitationer, bør du ikke aktivere denne indstilling.

`DismissInventoryNotifications` er yderst nyttigt, når du begynder at blive irriteret over konstant Steam notifikation om at modtage nye elementer. ASF kan ikke slippe af med selve meddelelsen, da den er indbygget i din Steam-klient, men det er i stand til automatisk at rydde underretningen efter at have modtaget den, som ikke længere vil efterlade "nye elementer i opgørelsen" notifikation hængende rundt. Hvis du forventer at evaluere dig selv alle modtagne elementer (især kort opdrættet med ASF), så skal du naturligvis ikke aktivere denne mulighed. Når du begynder at gå vanvittigt, så husk at dette tilbydes som en mulighed.

`MarkReceivedMessagesAsRead` vil automatisk markere **alle** -beskeder, der modtages af den konto, hvor ASF kører, både privat og gruppe, som læst. Dette bør typisk kun bruges af alt konti for at rydde "ny besked" notifikation, der kommer fra dig under udførelse af ASF kommandoer. Vi anbefaler ikke denne mulighed for primære konti, medmindre du ønsker at skære dig selv fra nogen form for nye meddelelser **inklusive** dem, der skete, mens du var offline, forudsat at ASF stadig var efterladt åben afvise det.

`MarkBotMessagesAsRead` virker på samme måde ved at markere kun bot-beskeder som læst. Men husk på, at når du bruger denne mulighed på gruppechats med dine bots og andre mennesker, Steam-implementering af anerkendelse af chatbesked **også** anerkender alle beskeder, der skete **før** den du besluttede at markere, så hvis du ved en tilfældighed ikke ønsker at gå glip af ikke-relateret meddelelse, der skete derimellem, du typisk ønsker at undgå at bruge denne funktion. Det er naturligvis også risikabelt, når du har flere primære konti (f.eks. fra forskellige brugere), der kører i den samme ASF instans, som du også kan gå glip af deres normale out-of-ASF beskeder.

`DisableIncomingTradesParsing` vil forhindre ASF i at parsing indgående handelstilbud, dette betyder, at hele handelsfunktionaliteten relateret til det vil være ikke-operativt. Da ASF fungerer i den mindst invasive tilstand som standard, accepterer kun handelstilbud fra `Master` brugere og derover, aldrig at røre ved andre handelstilbud - indgående handler parsing er aktiveret som standard. Denne indstilling giver mest mening for folk, der ønsker at sikre ingen yderligere anmodninger/overhead relateret til handler parsing, invaliderende hele logikken i processen, for eksempel fordi de ved, at deres robotter aldrig vil modtage master trade anmodninger, og kræver derfor slet ikke ASF, der deltager i deres handelsaktivitet. Husk, at have denne indstilling angivet vil deaktivere alle andre muligheder, der afhænger af indgående handler samt, såsom `AcceptDonations` eller `SteamTradeMatcher` - tilpassede plugins vil også være ude af stand til at behandle indgående handelstilbud på sædvanlig måde.

Hvis du er usikker på, hvordan du konfigurerer denne indstilling, er det bedst at lade den være som standard.

---

### `CompleteTypesToSend`

`ImmutableHashSet<byte>` type med standardværdi for at være tom. Når ASF er færdig med at udfylde et bestemt sæt af elementtyper, der er angivet her, det kan automatisk sende damp handel med alle færdige sæt til brugeren med `Master` tilladelse, hvilket er meget praktisk, hvis du gerne vil bruge givet bot konto til e. . STM matching, mens du flytter færdige sæt til en anden konto. Denne indstilling virker på samme måde som `loot` -kommando, husk derfor på, at det kræver bruger med `Master` tilladelse sæt, du kan også have brug for en gyldig `SteamTradeToken`, samt brug af en konto, der er berettiget til handel i første omgang.

Fra i dag understøttes følgende varetyper i denne indstilling:

| Værdi | Navn            | Beskriveslse                                                          |
| ----- | --------------- | --------------------------------------------------------------------- |
| 3     | FoilTradingCard | Foil variant af `TradingCard`                                         |
| 5     | TradingCard     | Steam-handelskort, der bruges til fremstilling af badges (ikke folie) |

Bemærk venligst, at uanset ovenstående indstillinger ASF vil kun bede om **[Steam community elementer](https://steamcommunity.com/my/inventory/#753_6)** (`appID` på 753, `contextID` af 6), så alle spilelementer, gaver og ligeledes er udelukket fra handelstilbuddet pr. definition.

På grund af ekstra overhead for brug af denne indstilling, det anbefales kun at bruge det på bot konti, der har en realistisk chance for at færdiggøre sæt på egen hånd - for eksempel det giver ingen mening at aktivere, hvis du allerede bruger `SendOnFarmingFinished` præference i `FarmingPreferences`, `SendTradePeriod` eller `loot` kommando på sædvanlig basis.

Hvis du er usikker på, hvordan du konfigurerer denne indstilling, er det bedst at lade den være som standard.

---

### `CustomGamePlayedWhileFarming`

`streng` type med standardværdi af `null`. Når ASF er landbrug, kan det vise sig som "Spille ikke-damp spil: `CustomGamePlayedWhileFarming`" i stedet for aktuelt opdrættet spil. Dette kan være nyttigt, hvis du gerne vil lade dine venner vide, at du landbruger, alligevel ønsker du ikke at bruge `OnlineStatus` af `Offline`. Bemærk venligst, at ASF ikke kan garantere den faktiske visningsordre på Steam-netværket, dette er derfor kun et forslag, der kan eller ikke kan vise sig korrekt. Navnlig brugerdefineret navn vil ikke vises i `Complex` landbrugsalgoritme hvis ASF udfylder alle `32` slots med spil, der kræver timer til at blive stødt. Standardværdi for `null` deaktiverer denne funktion.

ASF giver et par specielle variabler, som du eventuelt kan bruge i din tekst. `{0}` vil blive erstattet af ASF med `AppID` for nuværende opdrættede spil(er), mens `{1}` vil blive erstattet af ASF med `GameName` af nuværende opdrættede spil(er).

---

### `CustomGamePlayedWhileIdle`

`streng` type med standardværdi af `null`. Svarende til `CustomGamePlayedWhileFarming`, men for den situation, hvor ASF ikke har noget at gøre (som kontoen er fuldt gennemført). Bemærk venligst, at ASF ikke kan garantere den faktiske visningsordre på Steam-netværket, dette er derfor kun et forslag, der kan eller ikke kan vise sig korrekt. Hvis du bruger `GamesPlayedWhileIdle` sammen med denne mulighed, så husk på, at `GamesPlayedWhileIdle` får prioritet, du kan derfor ikke deklarere mere end `31` af dem, da ellers `CustomGamePlayedWhileIdle` ikke vil være i stand til at besætte pladsen for brugerdefineret navn. Standardværdi for `null` deaktiverer denne funktion.

---

### `Enabled`

`bool` type med standardværdi af `false`. Denne egenskab definerer om bot er aktiveret. Aktiveret bot instans (`true`) vil automatisk starte på ASF kørsel, mens deaktiveret bot instans (`false`) skal startes manuelt. Som standard er hver bot deaktiveret, så du sandsynligvis ønsker at skifte denne egenskab til `true` for alle dine bots, der skal startes automatisk.

---

### `FarmingOrders`

`ImmutableList<byte>` type med standardværdi for at være tom. Denne ejendom definerer **foretrukne** landbrugsordre brugt af ASF for given bot konto. I øjeblikket er der følgende landbrugsordrer tilgængelige:

| Værdi | Navn                      | Beskriveslse                                                                              |
| ----- | ------------------------- | ----------------------------------------------------------------------------------------- |
| 0     | Unordered                 | Ingen sortering, en smule bedre CPU-præstation                                            |
| 1     | AppIDsAscending           | Prøv at drive spil med laveste `appIDs` først                                             |
| 2     | AppIDsDescending          | Prøv at drive spil med højeste `appIDs` først                                             |
| 3     | CardDropsAscending        | Prøv at drive spil med laveste antal kort dråber resterende første                        |
| 4     | CardDropsDescending       | Prøv at drive spil med højeste antal kort dråber resterende første                        |
| 5     | HoursAscending            | Prøv at drive spil med laveste antal timer spillet først                                  |
| 6     | HoursDescending           | Prøv at drive spil med højeste antal timer spillet først                                  |
| 7     | NamesAscending            | Prøv at drive spil i alfabetisk rækkefølge, startende fra A                               |
| 8     | NamesDescending           | Prøv at drive spil i omvendt alfabetisk rækkefølge, startende fra Z                       |
| 9     | Random                    | Prøv at drive spil i helt tilfældig rækkefølge (forskellige på hver kørsel af programmet) |
| 10    | BadgeLevelsAscending      | Prøv at drive spil med laveste badge niveauer først                                       |
| 11    | BadgeLevelsDescending     | Prøv at drive spil med højeste badge niveauer først                                       |
| 12    | RedeemDateTimesAscending  | Prøv at opdrætte ældste spil på vores konto først                                         |
| 13    | RedeemDateTimesDescending | Prøv at opdrætte nyeste spil på vores konto først                                         |
| 14    | MarketableAscending       | Prøv at drive spil med uomsættelige kort dråber først (advarsel: dyre at beregne)         |
| 15    | MarketableDescending      | Prøv at drive spil med salgbare kort dråber først (advarsel: dyre at beregne)             |

Da denne egenskab er et array, det giver dig mulighed for at bruge flere forskellige indstillinger i din faste ordre. For eksempel kan du inkludere værdier af `15`, `11` og `7` for først at sortere efter salgbare spil derefter af dem med højeste badge niveau, og endelig alfabetisk. Som du kan gætte, betyder ordren faktisk noget, som omvendt en (`7`, `11` og `15`) opnår noget helt andet (sorterer spil alfabetisk først, og på grund af spilnavne er unikke, de to andre er effektivt ubrugelig). Flertallet af mennesker vil sandsynligvis kun bruge én orden ud af dem alle, men hvis du vil, kan du også sortere yderligere efter ekstra parametre.

Læg også mærke til ordet "forsøg" i alle ovenstående beskrivelser - den faktiske ASF ordre er stærkt påvirket af udvalgte **[kort landbrug algoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** og sortering vil påvirke kun resultater, som ASF anser den samme ydeevnevis. For eksempel, i `Simple` algoritme, valgt `FarmingOrders` skal respekteres fuldt ud i den aktuelle landbrugssession (da hvert spil har samme ydeevneværdi), mens i `Complex` algoritme faktisk ordre er påvirket af timer først, og derefter sorteret efter valgte `FarmingOrders`. Dette vil føre til forskellige resultater, da spil med eksisterende spilletid vil have en prioritet i forhold til andre, så effektivt vil ASF foretrække spil, der allerede bestået kræves `HoursUntilCardDrops` for det første og først derefter sortere disse spil yderligere af din valgte `FarmingOrders`. Ligeledes når ASF løber tør for allerede stødte spil, vil sortere resterende kø efter timer først (da det vil reducere tiden til at bumpe nogen af de resterende titler til `HoursUntilCardDrops`). Derfor er denne config ejendom kun et **forslag** , som ASF vil forsøge at respektere, så længe det ikke påvirker ydeevnen negativt (i dette tilfælde vil ASF altid foretrække landbrugsbedriften frem for `FarmingOrders`).

Der er også landbrugets prioritetskø som er tilgængelig via kommandoerne `fq` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Hvis det bruges, faktisk landbrug ordre sorteres først efter performance, derefter efter landbrug kø, og endelig af din `FarmingOrders`.

---

### `FarmingPreferences`

`byte flag` type med standardværdi `0`. Denne ejendom definerer ASF adfærd i forbindelse med landbrug og defineres som nedenfor:

| Værdi | Navn                      |
| ----- | ------------------------- |
| 0     | None                      |
| 1     | FarmingPausedByDefault    |
| 2     | ShutdownOnFarmingFinished |
| 4     | SendOnFarmingFinished     |
| 8     | FarmPriorityQueueOnly     |
| 16    | SkipRefundableGames       |
| 32    | SkipUnplayedGames         |
| 64    | EnableRiskyCardsDiscovery |
| 256   | AutoUnpackBoosterPacks    |

Bemærk venligst, at denne egenskab er `flag` feltet, derfor er det muligt at vælge en hvilken som helst kombination af tilgængelige værdier. Tjek **[json mapping](#json-mapping)** hvis du gerne vil lære mere. Aktiverer ikke nogen af flag resulterer i `Ingen` valgmulighed.

Alle mulighederne er beskrevet nedenfor.

`FarmingPausedByDefault` definerer indledende tilstand af `CardsFarmer` modul. Normalt vil bot automatisk starte landbrug, når det er startet, enten på grund af `aktiveret` eller `starte` -kommandoen. Brug af `FarmingPausedByDefault` kan bruges, hvis du ønsker at manuelt `genoptage` automatisk landbrugsproces, for eksempel fordi du ønsker at bruge `afspil` hele tiden og aldrig bruge automatisk `CardsFarmer` modul - dette virker præcis det samme som `pause` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

`ShutdownOnFarmingFinished` giver dig mulighed for at lukke bot, når det er gjort landbrug. Normalt er ASF "optagende" en konto for hele tiden af processen er aktiv. Når givet konto er udført med landbrug, ASF regelmæssigt kontrollerer det (hver `IdleFarmingPeriod` timer), hvis måske nogle nye spil med dampkort blev tilføjet i mellemtiden, så det kan genoptage landbruget af denne konto uden behov for at genstarte processen. Dette er nyttigt for de fleste mennesker, da ASF automatisk kan genoptage landbruget, når det er nødvendigt. Men du kan faktisk ønsker at stoppe processen, når en given konto er fuldt opdrættet, kan du opnå det ved at bruge dette flag. Når aktiveret, vil ASF fortsætte med at logge af når konto er fuldt opdrættet, hvilket betyder, at det ikke vil blive kontrolleret regelmæssigt eller optaget længere. Du bør selv beslutte, om du foretrækker ASF til at arbejde på given bot eksempel for hele tiden, eller om ASF måske skulle standse den, når landbrugsprocessen er afsluttet.

Denne indstilling giver mest mening at blive kombineret med `ShutdownIfPossible`, så når alle konti er stoppet, vil ASF også lukke, sætte din maskine i hvile og så du kan planlægge andre handlinger, såsom søvn eller nedlukning i samme øjeblik af sidste kort droppe.

`SendOnFarmingFinished` giver dig mulighed for automatisk at sende damphandel, der indeholder alt opdrættet op til dette punkt til brugeren med `Master` tilladelse, som er meget praktisk, hvis du ikke ønsker at bekymre dig om handler selv. Denne indstilling virker på samme måde som `loot` -kommando, husk derfor på, at det kræver bruger med `Master` tilladelse sæt, du kan også have brug for en gyldig `SteamTradeToken`, samt brug af en konto, der er berettiget til handel i første omgang. Ud over at indlede `loot` efter endt opdræt ASF vil også indlede `loot` på hver ny vare meddelelse (når ikke landbrug) og efter at have afsluttet hver handel, der resulterer i nye varer (altid), når denne indstilling er aktiv. Dette er især nyttigt for "videresending" elementer modtaget fra andre personer til vores konto. Typisk vil du bruge **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** sammen med denne funktion, selvom det ikke er et krav, hvis du har til hensigt at håndtere 2FA bekræftelser manuelt i tide.

`FarmPriorityQueueOnly` definerer, om ASF kun bør overveje automatiske landbrugs apps, som du tilføjede dig selv til prioriteret landbrugskø tilgængelig med `fq` **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Når denne indstilling er aktiveret, vil ASF springe alle `appIDs` , der mangler på listen, over effektivt giver dig mulighed for at cherry-pick spil til automatisk ASF landbrug. Husk, at hvis du ikke har tilføjet nogen spil til køen, så ASF vil handle, som om der ikke er noget at drive på din konto.

`SkipRefundableGames` definerer, om ASF skal springe over spil, der stadig refunderes fra automatisk landbrug. Et refunderbart spil er et spil, som du har købt i de sidste 2 uger gennem Steam Butik og ikke spillet længere end 2 timer endnu, som angivet på **[Steam tilbagebetaling](https://store.steampowered.com/steam_refunds)** side. Som standard ignorerer ASF Steam-tilbagebetalingspolitikken helt og gårder alt, som de fleste mennesker ville forvente. Du kan dog bruge dette flag, hvis du ønsker at sikre, at ASF ikke vil drive nogen af dine refunderbare spil for tidligt, så du kan evaluere disse spil selv og refundere, hvis det er nødvendigt, uden at bekymre sig om ASF påvirker spilletid negativt. Bemærk venligst, at hvis du aktiverer denne mulighed, så vil spil, du har købt i Steam Store, ikke blive opdrættet af ASF i op til 14 dage siden indløsningsdatoen. som vil vise sig som intet til gården, hvis din konto ikke ejer noget andet.

`SkipUnplayedGames` definerer om ASF skal springe over spil, som du ikke har startet endnu. Uspillede spil i denne sammenhæng betyder, at du har præcis ingen spilletid optaget for det på Steam. Hvis du bruger dette flag, vil sådanne spil blive sprunget over, indtil Steam registrerer en spilletid for dem. Dette giver dig mulighed for at styre bedre, hvilke spil ASF er berettiget til at gårde, springe over dem, som du ikke havde en chance for at prøve endnu, at holde de valgte Steam-funktioner mere nyttige - såsom at foreslå uspillede spil at spille.

`EnableRiskyCardsDiscovery` muliggør yderligere tilbagefald, der udløser, når ASF ikke er i stand til at indlæse en eller flere badge sider og derfor ikke kan finde spil til landbrug. Navnlig kan nogle konti med massiv mængde af kort dråber forårsage en situation, hvor indlæsning af badge sider ikke længere er muligt (på grund af overhead), og disse regnskaber er umulige for landbruget, udelukkende fordi vi ikke kan indlæse de oplysninger, som vi kan starte processen på. For disse håndgribelige kasser, tillader denne indstilling at alternativ algoritme bruges, som anvender en kombination af boostere, der er muligt for at fremstille og boosterpakker, som kontoen er berettiget til for at finde potentielt tilgængelige spil at inaktiv derefter bruge for mange ressourcer til at verificere og hente nødvendige oplysninger, og forsøger at starte processen med landbrug på begrænset mængde data og oplysninger for i sidste ende at nå en situation, når badge side belastninger, og vi vil være i stand til at bruge normal tilgang. Bemærk, at når denne fallback anvendes, fungerer ASF kun med begrænsede data Derfor er det helt normalt for ASF at finde langt færre dråber end i virkeligheden - andre dråber vil blive fundet på et senere tidspunkt i landbrugsprocessen.

Denne indstilling kaldes "risky" af en meget god grund - det er ekstremt langsomt og kræver betydelige mængder af ressourcer (herunder netværksanmodninger) til drift, Derfor er det **ikke anbefalet** at blive aktiveret, og især på lang sigt. Du bør kun bruge denne mulighed, hvis du tidligere har bestemt, at din konto lider af at være ude af stand til at indlæse badge sider og ASF kan ikke operere på det, altid undlader at indlæse nødvendige oplysninger for at starte processen. Selv om vi gjorde vores bedste for at optimere processen så meget som muligt det er stadig muligt for denne mulighed at backfire, og det kan forårsage uønskede resultater, såsom midlertidige og måske endda permanente bans fra Steam-siden for at sende for mange anmodninger og ellers forårsage overhead på Steam-servere. Derfor advarer vi dig på forhånd, og vi tilbyder denne mulighed med absolut ingen garantier, du bruger det på egen risiko.

`AutoUnpackBoosterPacks` vil automatisk pakke alle boosterpakker ud, når de modtager nye elementnotifikationer. Dette vil give dig mulighed for straks at erhverve yderligere kortdråber, hvilket kan være ønsket scenarie især i kombination med andre muligheder (f. eks. . `SteamTradeMatcher` eller `CompleteTypesToSend`).

---

### `GamesPlayedWhileIdle`

`ImmutableHashSet<uint>` type med standardværdi for at være tom. Hvis ASF ikke har noget at drive det kan spille dine angivne damp spil (`appIDs`) i stedet. Afspilning af spil på en sådan måde øger dine "spilletider" af disse spil, men intet andet end det. In order for this feature to work properly, your Steam account **must** own a valid license to all the `appIDs` that you specify here, this includes F2P games as well. Denne funktion kan aktiveres samtidig med `CustomGamePlayedWhileIdle` for at spille dine valgte spil, mens du viser brugerdefineret status i Steam-netværket, men i dette tilfælde, som i `CustomGamePlayedWhileFarming` tilfælde, er den faktiske visningsordre ikke garanteret. Bemærk venligst, at Steam tillader ASF kun at spille op til `32` `appIDs` i alt, derfor kan du sætte kun så mange spil i denne ejendom.

---

### `GamingDeviceType`

`ushort` type med standardværdi af `1`. Denne egenskab kan aktivere nogle yderligere online funktioner på Steam-platformen og er defineret som nedenfor:

| Værdi | Navn       | Beskriveslse                      |
| ----- | ---------- | --------------------------------- |
| 1     | StandardPC | Ingen speciel tilstand, standard  |
| 544   | Dampdæk    | Præsentér sig selv som Steam Deck |

Den underliggende `EGamingDeviceType` type, som denne ejendom er baseret på indeholder flere tilgængelige værdier, Men efter vores bedste viden har de absolut ingen virkning fra i dag, derfor blev de skåret for synlighed.

Hvis du ikke er sikker på, hvordan du sætter denne ejendom, så lad den være med standardværdien `1`.

---

### `HoursUntilCardDrops`

`byte` type med standardværdi af `3`. Denne egenskab definerer om konto har kort dråber begrænset, og hvis ja, for hvor mange indledende timer. Begrænset kort dråber betyder, at kontoen ikke modtager nogen kort dråber fra et givet spil, før spillet spilles i mindst `HoursUntilCardDrops` timer. Desværre er der ingen magisk måde at opdage det, så ASF er afhængig af dig. Denne egenskab påvirker **[kort opdrætalgoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** , der vil blive brugt. Indstilling af denne egenskab korrekt vil maksimere overskud og minimere den tid, der kræves for kort til at blive opdrættet. Husk, at der ikke er noget indlysende svar, om du skal bruge en eller anden værdi, da det helt afhænger af din konto. Det ser ud til, at ældre konti, der aldrig har bedt om tilbagebetaling, har ubegrænset kort drops, så de skal anvende en værdi af `0`, mens nye konti og dem, der har bedt om tilbagebetaling, har begrænset kort dråber med en værdi af `3`. Dette er dog kun teori, og bør ikke tages som hovedregel. Standardværdien for denne egenskab blev sat baseret på "mindre ondt" og de fleste brugssager.

---

### `LootableTypes`

`ImmutableHashSet<byte>` type med standardværdi af `1, 3, 5` dampelementtyper. Denne egenskab definerer ASF adfærd ved plyndring - begge manual, ved hjælp af en **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, samt automatisk, gennem en eller flere konfigurationsegenskaber. ASF vil sikre, at kun varer fra `LootableTypes` vil blive inkluderet i et handelstilbud, Derfor giver denne ejendom dig mulighed for at vælge, hvad du ønsker at modtage i et handelstilbud, der sendes til dig.

| Værdi | Navn                | Beskriveslse                                                           |
| ----- | ------------------- | ---------------------------------------------------------------------- |
| 0     | Unknown             | Hver type, der ikke passer ind i nogen af nedenstående                 |
| 1     | BoosterPack         | Booster pakke med 3 tilfældige kort fra et spil                        |
| 2     | Emoticon            | Emoticon til brug i Steam Chat                                         |
| 3     | FoilTradingCard     | Foil variant af `TradingCard`                                          |
| 4     | ProfileBackground   | Profilbaggrund til brug på din Steam-profil                            |
| 5     | TradingCard         | Steam-handelskort, der bruges til fremstilling af badges (ikke folie)  |
| 6     | SteamGems           | Dampperler, der bruges til fremstilling af boostere, medfølgende sække |
| 7     | SalgGenstand        | Specielle elementer tildelt under Steam-salg                           |
| 8     | Forbrugsstoffer     | Særlige forbrugsvarer, der forsvinder efter brug                       |
| 9     | ProfileModifier     | Særlige elementer, der kan ændre Steam-profilens udseende              |
| 10    | Klistermærke        | Særlige genstande, der kan bruges på Steam chat                        |
| 11    | ChatEffect          | Særlige genstande, der kan bruges på Steam chat                        |
| 12    | MiniProfileBaggrund | Speciel baggrund for Steam-profil                                      |
| 13    | AvatarProfileFrame  | Speciel avatarramme til Steam-profil                                   |
| 14    | AnimatedAvatar      | Speciel animeret avatar til Steam-profil                               |
| 15    | TastaturSkin        | Specielt tastaturskin til Steam-dæk                                    |
| 16    | StartupVideo        | Speciel opstartsvideo til Steam-dæk                                    |

Bemærk venligst, at uanset ovenstående indstillinger ASF vil kun bede om **[Steam community elementer](https://steamcommunity.com/my/inventory/#753_6)** (`appID` på 753, `contextID` af 6), så alle spilelementer, gaver og ligeledes er udelukket fra handelstilbuddet pr. definition.

Standard ASF indstilling er baseret på den mest almindelige brug af bot, med plyndring kun booster pakker og handelskort (herunder folie). Den her definerede egenskab giver dig mulighed for at ændre denne adfærd på en eller anden måde, der tilfredsstiller dig. Husk venligst at alle typer der ikke er defineret ovenfor vil blive vist som `Ukendt` type hvilket er særlig vigtigt, når Ventilen frigiver et nyt Steam-element det vil også blive markeret som `Unknown` af ASF, indtil det er tilføjet her (i den fremtidige udgivelse). Det er derfor, det generelt ikke anbefales at inkludere `Ukendt` type i din `LootableTypes`, medmindre du ved, hvad du laver, og du forstår også, at ASF vil sende hele dit inventar i et handelstilbud, hvis Steam Network bliver brudt igen og rapporterer alle dine varer som `Ukendt`. Mit stærke forslag er ikke at inkludere `Ukendt` type i `LootableTypes`, selv om du forventer at plyndre alt (ellers).

---

### `MachineName`

`streng` type med standardværdi af `null`. ASF vil bruge denne egenskab, når du logger på Steam-netværket, som kan bruges til tilpasning i forhold til, hvordan præcis Steam vil vise ASF maskine og session, e. . ved visning af enheder, der er logget ind **[her](https://store.steampowered.com/account/authorizeddevices)**.

ASF giver et par specielle variabler, som du eventuelt kan bruge i din tekst. `{0}` vil blive erstattet af maskinens navn som angivet af dit operativsystem `{1}` vil blive erstattet af ASF's offentlige id, mens `{2}` vil blive erstattet af ASF's version.

Medmindre du ved, hvad du laver, skal du holde det med standardværdien af `null`. I dette tilfælde vil ASF internt beslutte den korrekte værdi, som er `{0} ({1}/{2})` fra i dag. Husk, at dette kun er et forslag om, at Steam-netværket kan, eller måske ikke, fuldt ud respekteres.

---

### `MatchableTypes`

`ImmutableHashSet<byte>` type med standardværdi af `5` Steam item typer. Denne egenskab definerer hvilken Steam-genstandstyper der må matches, når `SteamTradeMatcher` indstilling i `TradingPreferences` er aktiveret. Typer defineres som nedenfor:

| Værdi | Navn                | Beskriveslse                                                           |
| ----- | ------------------- | ---------------------------------------------------------------------- |
| 0     | Unknown             | Hver type, der ikke passer ind i nogen af nedenstående                 |
| 1     | BoosterPack         | Booster pakke med 3 tilfældige kort fra et spil                        |
| 2     | Emoticon            | Emoticon til brug i Steam Chat                                         |
| 3     | FoilTradingCard     | Foil variant af `TradingCard`                                          |
| 4     | ProfileBackground   | Profilbaggrund til brug på din Steam-profil                            |
| 5     | TradingCard         | Steam-handelskort, der bruges til fremstilling af badges (ikke folie)  |
| 6     | SteamGems           | Dampperler, der bruges til fremstilling af boostere, medfølgende sække |
| 7     | SalgGenstand        | Specielle elementer tildelt under Steam-salg                           |
| 8     | Forbrugsstoffer     | Særlige forbrugsvarer, der forsvinder efter brug                       |
| 9     | ProfileModifier     | Særlige elementer, der kan ændre Steam-profilens udseende              |
| 10    | Klistermærke        | Særlige genstande, der kan bruges på Steam chat                        |
| 11    | ChatEffect          | Særlige genstande, der kan bruges på Steam chat                        |
| 12    | MiniProfileBaggrund | Speciel baggrund for Steam-profil                                      |
| 13    | AvatarProfileFrame  | Speciel avatarramme til Steam-profil                                   |
| 14    | AnimatedAvatar      | Speciel animeret avatar til Steam-profil                               |
| 15    | TastaturSkin        | Specielt tastaturskin til Steam-dæk                                    |
| 16    | StartupVideo        | Speciel opstartsvideo til Steam-dæk                                    |

Selvfølgelig omfatter typer, som du skal bruge til denne ejendom, typisk kun `2`, `3`, `4` og `5`, da kun disse typer understøttes af STM. ASF indeholder korrekt logik for at opdage sjældenheden af de elementer, derfor er det også sikkert at matche emotikoner eller baggrunde, da ASF korrekt vil overveje fair kun de elementer fra samme spil og type, der også har samme sjældenhed.

Bemærk, at **ASF ikke er en trading bot** og **vil IKKE bekymre sig om markedsprisen**. Hvis du ikke overveje elementer af samme sjældenhed fra samme sæt til at være den samme pris-klog, så er denne mulighed IKKE for dig. Vurder venligst to gange, hvis du forstår og er enig i denne erklæring, før du beslutter dig for at ændre denne indstilling.

Medmindre du ved, hvad du laver, skal du holde det med standardværdi på `5`.

---

### `OnlineFlag`

`ukorte flag` type med standardværdi `0`. Denne egenskab fungerer som supplement til **[`OnlineStatus`](#onlinestatus)** og angiver yderligere online tilstedeværelse funktioner annonceret på Steam netværk. Kræver **[`OnlineStatus`](#onlinestatus)** bortset fra `Offline`og er defineret som nedenfor:

| Værdi | Navn               | Beskriveslse                                        |
| ----- | ------------------ | --------------------------------------------------- |
| 0     | None               | Ingen særlige online tilstedeværelse flag, standard |
| 2     | InJoinableGame     | Klienten er i et fælles spil                        |
| 8     | RemotePlayTogether | Klienten bruger ekstern afspilning sammen session   |
| 256   | ClientTypeWeb      | Klienten bruger webgrænseflade                      |
| 512   | ClientTypeMobile   | Klienten bruger mobil-app                           |
| 1024  | ClientTypeTenfoot  | Klienten bruger et stort billede                    |
| 2048  | ClientTypeVR       | Klienten bruger VR headset                          |

Bemærk venligst, at denne egenskab er `flag` feltet, derfor er det muligt at vælge en hvilken som helst kombination af tilgængelige værdier. Tjek **[json mapping](#json-mapping)** hvis du gerne vil lære mere. Aktiverer ikke nogen af flag resulterer i `Ingen` valgmulighed.

Den underliggende `EPersonaStateFlag` type som denne ejendom er baseret på indeholder flere tilgængelige flag Men efter vores bedste viden har de absolut ingen virkning fra i dag, derfor blev de skåret for synlighed.

Hvis du ikke er sikker på, hvordan du sætter denne egenskab, så lad den være med standardværdien `0`.

---

### `OnlineStatus`

`byte` type med standardværdi af `1`. Denne egenskab angiver Steam-fællesskabsstatus, som botten vil blive annonceret med efter at have logget ind på Steam-netværket. I øjeblikket kan du vælge en af nedenstående statusser:

| Værdi | Navn           |
| ----- | -------------- |
| 0     | Offline        |
| 1     | Online         |
| 2     | Busy           |
| 3     | Away           |
| 4     | Snooze         |
| 5     | LookingToTrade |
| 6     | LookingToPlay  |
| 7     | Invisible      |

`Offline` status er yderst nyttig for primære konti. Som du bør vide, landbrug et spil faktisk viser din damp status som "Spille spillet: XXX", som kan være vildledende til dine venner, forvirre dem, at du spiller et spil, mens du faktisk kun dyrker det. Brug af `Offline` status løser dette problem - din konto vil aldrig blive vist som "i spillet", når du dyrker dampkort med ASF. Dette er muligt, fordi ASF ikke behøver at logge ind på Steam-fællesskabet for at fungere ordentligt, så vi faktisk spiller disse spil, er forbundet til Steam-netværket, men uden at annoncere vores online tilstedeværelse overhovedet. Husk, at spillede spil ved hjælp af offline status stadig tæller med i din spilletid, og vis som "nyligt spillede" på din profil.

Derudover er denne funktion også vigtig, hvis du ønsker at modtage meddelelser og ulæste meddelelser, når ASF kører, mens du ikke holder Steam-klienten åben på samme tid. Dette skyldes, at ASF fungerer som en Steam-klient selv, og om ASF ønsker det eller ej, Steam sender alle disse beskeder og andre begivenheder til det. Dette er ikke et problem, hvis du har både ASF og din egen Steam-klient kører, da begge klienter modtager præcis de samme begivenheder. Men hvis blot ASF kører, kan Steam-netværket markere visse begivenheder og meddelelser som "leveret" på trods af at din traditionelle Steam-klient ikke har modtaget den, fordi den ikke er til stede. Offline status løser også dette problem, da ASF aldrig er taget i betragtning for nogen community events i dette tilfælde, så alle ulæste beskeder og andre begivenheder vil blive markeret som ulæste, når du kommer tilbage.

Det er vigtigt at bemærke, at ASF kører på `Offline` mode vil **ikke** være i stand til at modtage kommandoer på sædvanlig Steam chat måde, som chaten, såvel som hele fællesskabet tilstedeværelse er i virkeligheden helt offline. En løsning på dette problem er at bruge `Usynlig` tilstand i stedet, som virker på samme måde (ikke udsætter status), men bevarer evnen til at modtage og reagere på meddelelser (så også et potentiale for at afvise meddelelser og ulæste beskeder som angivet ovenfor). `Usynlig` tilstand giver mest mening på alt konti, som du ikke ønsker at udsætte (status-vis), men stadig være i stand til at sende kommandoer til.

Men der er en fangst med `usynlig` mode - det går ikke godt med primære konti. Dette skyldes, at **enhver** Steam-session, der i øjeblikket er online **afslører** status, selv om ASF selv ikke gør det. Dette skyldes den aktuelle begrænsning / fejl i Steam-netværket, der ikke er muligt at blive rettet på ASF-siden så hvis du ønsker at bruge `Usynlig` tilstand, skal du også sikre, at **alle** andre sessioner til den samme konto bruger `Usynlig` tilstand så godt. Dette vil være tilfældet på alt konti, hvor ASF forhåbentlig er den eneste aktive session, men på primære konti foretrækker du næsten altid at vise som `Online` til dine venner, skjuler kun ASF-aktivitet og i dette tilfælde `Usynlig` -tilstand vil være helt ubrugelig for dig (vi anbefaler at bruge `Offline` -tilstand i stedet). Forhåbentlig vil denne begrænsning / fejl i sidste ende blive løst i fremtiden af Valve, men jeg ville ikke forvente, at det vil ske når som helst...

Hvis du er usikker på, hvordan du opsætter denne egenskab, det anbefales at bruge en værdi på `0` (`Offline`) til primære konti, og standard `1` (`Online`) ellers.

---

### `PasswordFormat`

`byte` type med standardværdi `0` (`almindelig tekst`). Denne egenskab definerer formatet af egenskaben `SteamPassword` og understøtter i øjeblikket værdier angivet i afsnittet **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**. Du skal følge de instruktioner, der er angivet der, da du skal sikre, at `SteamPassword` -egenskaben faktisk indeholder adgangskode i matchende `PasswordFormat`. Med andre ord, når du ændrer `PasswordFormat` så skal din `SteamPassword` være **allerede** i dette format, ikke bare sigter mod at være. Medmindre du ved, hvad du laver, skal du holde det med standardværdi på `0`.

Hvis du beslutter dig for at ændre `PasswordFormat` på en bot, der allerede har logget ind på Steam-netværket mindst én gang det er muligt, at du får en gang dekryptere fejl på den næste bot start - dette skyldes det faktum, at `PasswordFormat` også bruges i forhold til automatisk kryptering / dekryptering af følsomme egenskaber i `Bot. b` database fil. Du kan trygt ignorere denne fejl, da ASF vil være i stand til at komme sig efter denne situation på egen hånd. Men hvis det sker konstant, f.eks. hver genstart, bør det undersøges.

---

### `RedeemingPreferences`

`byte flag` type med standardværdi `0`. Denne egenskab definerer ASF-adfærd ved indløsning af cd-nøgler og er defineret som nedenfor:

| Værdi | Navn                                  | Beskriveslse                                                                                                                   |
| ----- | ------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------ |
| 0     | None                                  | Ingen specielle indløsningspræferencer, standard                                                                               |
| 1     | Forwarding                            | Fremad nøgler utilgængelige til indløsning til andre bots                                                                      |
| 2     | Distributing                          | Fordel alle nøgler blandt sig selv og andre bots                                                                               |
| 4     | KeepMissingGames                      | Behold nøgler til (potentielt) manglende spil ved videresendelse, efterlader dem ubrugte                                       |
| 8     | AntagelseWalletKeyOnBadActivationCode | Antag at `BadActivationCode` nøgler er lig med `CannotRedeemCodeFromClient`, og prøv derfor at indløse dem som tegnebogsnøgler |

Bemærk venligst, at denne egenskab er `flag` feltet, derfor er det muligt at vælge en hvilken som helst kombination af tilgængelige værdier. Tjek **[json mapping](#json-mapping)** hvis du gerne vil lære mere. Aktiverer ikke nogen af flag resulterer i `Ingen` valgmulighed.

`Forwarding` vil få bot til at fremsende en nøgle, der ikke er muligt at indløse, til en anden tilsluttet og logget på bot, der mangler det pågældende spil (hvis muligt at kontrollere). Den mest almindelige situation er at videresende `Allerede Købt` spil til en anden bot, der mangler det pågældende spil, men denne mulighed dækker også andre scenarier, såsom `DoesNotOwnRequiredApp`, `RateLimited` eller `RestrictedCountry`.

`Distribuering` vil få bot til at distribuere alle modtagne nøgler blandt sig selv og andre bots. Det betyder, at hver bot vil få en enkelt nøgle fra partiet. Typisk bruges dette kun, når du indløser mange nøgler til det samme spil, og du ønsker at jævnt fordele dem blandt dine bots, i stedet for at indløse nøgler til forskellige forskellige spil. Denne funktion giver ingen mening, hvis du kun indløser én nøgle i en enkelt `indløse` handling (da der ikke er nogen ekstra nøgler at distribuere).

`KeepMissingGames` vil få bot til at springe `Forwarding` , når vi ikke kan være sikre på, om nøglen bliver indløst er ejet af vores bot, eller ej. Dette betyder dybest set, at `Forwarding` kun vil anvende **** på `allerede købte` nøgler, i stedet for også at dække andre sager såsom `DoesNotOwnRequiredApp`, `RateLimited` eller `Begrænset land`. Typisk vil du bruge denne indstilling på primær konto, for at sikre, at nøgler indløses på det vil ikke blive videresendt yderligere, hvis din bot for eksempel bliver midlertidigt `RateLimited`. Som du kan gætte fra beskrivelsen, har dette felt absolut ingen effekt, hvis `Forwarding` ikke er aktiveret.

`AssumeWalletKeyOnBadActivationCode` vil få `BadActivationCode` til at blive behandlet som `CannotRedeemCodeFromClient`, og derfor resultere i, at ASF forsøger at indløse dem som tegnebogsnøgler. Dette er nødvendigt, fordi Steam kan annoncere tegnebogsnøgler som `BadActivationCode` (og ikke `CannotRedeemCodeFromClient` som det bruges til), resulterer i, at ASF aldrig forsøger at indløse dem. Men vi anbefaler **mod** ved hjælp af denne præference, da det vil resultere i, at ASF forsøger at indløse hver ugyldig nøgle som en tegnebogskode, resulterer i overdreven mængde (potentielt ugyldige) anmodninger sendt til Steam-tjenesten, med alle de potentielle konsekvenser. I stedet, vi anbefaler at bruge `ForceAssumeWalletKey` **[`indløse^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** mode mens bevidst indløse tegnebogsnøgler, som kun gør det muligt at finde den nødvendige løsning, når den er nødvendig, efter behov.

Aktivering af både `Forwarding` og `Distributing` vil tilføje distributionsfunktionen oven på videresendelse en, hvilket gør at ASF forsøger at indløse en nøgle på alle bots først (videresendt), før du flytter til den næste (distribution). Typisk vil du kun bruge denne indstilling, når du ønsker `Forwarding`, men med ændret opførsel ved at skifte bot på nøglen, der anvendes, i stedet for altid at gå i orden med hver nøgle (som ville være `Videresend` alene). Denne adfærd kan være gavnlig, hvis du ved, at flertallet eller endda alle dine nøgler er bundet til det samme spil, fordi `Forwarding` alene i denne situation ville forsøge at indløse alt på én bot først (hvilket giver mening, hvis dine nøgler er til unikke spil), og `Videresend` + `Distribuering` vil skifte bot på den næste nøgle, "distribuerer" opgaven med at indløse ny nøgle til en anden bot end den oprindelige (hvilket giver mening, hvis nøgler er til samme spil, springe et meningsløst forsøg pr. nøgle).

Den faktiske bots rækkefølge for alle indløsningsscenarier er alfabetisk ekskl. bots, der er utilgængelige (ikke forbundet, stoppet eller lignende). Vær opmærksom på, at der er per IP og per konto timegrænse for indløsning forsøg, og enhver indløsning forsøg, der ikke sluttede med `OK` bidrager til mislykkede forsøg. ASF vil gøre sit bedste for at minimere antallet af `allerede købte` -fejl, f.eks. ved at forsøge at undgå at videresende en nøgle til en anden bot, der allerede ejer det pågældende spil, men det er ikke altid garanteret at arbejde på grund af hvordan Steam håndterer licenser. Brug af indløsning flag såsom `Forwarding` eller `Distributing` vil altid øge din sandsynlighed for at ramme `RateLimited`.

Husk også, at du ikke kan videresende eller distribuere nøgler til bots, som du ikke har adgang til. Det bør være indlysende, men sørg for, at du mindst er `Operatør` af alle de robotter, du ønsker at inkludere i din indløsningsproces, for eksempel med `status ASF` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `RemoteCommunication`

`byte flag` type med standardværdi `3`. Denne ejendom definerer per-bot ASF adfærd, når det kommer til kommunikation med fjernbetjening, tredjepartstjenester, og er defineret som nedenfor:

| Værdi | Navn             | Beskriveslse                                                                                                                                                                                                                                                      |
| ----- | ---------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | None             | Ingen tilladt tredjepartskommunikation, gengivelse af valgte ASF funktioner ubrugelig                                                                                                                                                                             |
| 1     | SteamGroup       | Tillader kommunikation med **[ASF's Steam-gruppe](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                   |
| 2     | Offentliggørelse | Tillader kommunikation med **[ASF's STM liste](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** for at blive opført hvis brugeren også har aktiveret `SteamTradeMatcher` i **[`TradingPreferences`](#tradingpreferences)** |

Bemærk venligst, at denne egenskab er `flag` feltet, derfor er det muligt at vælge en hvilken som helst kombination af tilgængelige værdier. Tjek **[json mapping](#json-mapping)** hvis du gerne vil lære mere. Aktiverer ikke nogen af flag resulterer i `Ingen` valgmulighed.

Denne indstilling omfatter ikke alle tredjepartskommunikation, der tilbydes af ASF, kun dem, der ikke er underforstået af andre indstillinger. Hvis du for eksempel har aktiveret ASF's auto-opdateringer, vil ASF kommunikere med både GitHub (til downloads) og vores server (til checksum verificering), som pr din konfiguration. Ligeledes aktivering af `MatchActively` i **[`TradingPreferences`](#tradingpreferences)** indebærer kommunikation med vores server for at hente listede bots, som er påkrævet for denne funktionalitet.

Yderligere forklaring på dette emne er tilgængelig i afsnittet **[fjernkommunikation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

### `SendTradePeriod`

`byte` type med standardværdi `0`. Denne ejendom fungerer meget lig `SendOnFarmingFinished` præference i `FarmingPreferences`, med én forskel - i stedet for at sende handel, når landbruget er færdigt Vi kan også sende det hver `SendTradePeriod` timer, uanset hvor meget vi har at drive til venstre. Dette er nyttigt, hvis du ønsker at `loot` dine alt konti på sædvanlig basis i stedet for at vente på, at det er færdiggjort landbrug. Standardværdien af `0` deaktiverer denne funktion, hvis du vil have din bot til at sende dig handle. . Hver dag bør du sætte `24` her.

Typisk vil du bruge **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** sammen med denne funktion, selvom det ikke er et krav, hvis du har til hensigt at håndtere 2FA bekræftelser manuelt i tide. Hvis du ikke er sikker på, hvordan du sætter denne egenskab, så lad den være med standardværdien `0`.

---

### `SteamLogin`

`streng` type med standardværdi af `null`. Denne ejendom definerer dit damp-login - den, du bruger til at logge ind til at dampe. Ud over at definere damp login her, kan du også beholde standardværdien af `null` , hvis du ønsker at indtaste dit damp-login ved hver ASF-opstart i stedet for at sætte det i konfigurationen. Dette kan være nyttigt for dig, hvis du ikke ønsker at gemme følsomme data i config fil.

---

### `SteamMasterClanID`

`ulong` type med standardværdi af `0`. Denne egenskab definerer damp-ID for damp-gruppen som bot automatisk skal deltage, herunder sin gruppechat. Du kan tjekke damp af din gruppe ved at navigere til sin **[side](https://steamcommunity.com/groups/archiasf)**, derefter tilføje `/memberslistxml? ml=1` til slutningen af linket, så linket vil se ud som **[denne](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. Så kan du få damp af din gruppe fra resultatet, det er i `<groupID64>` tag. I ovenstående eksempel ville det være `103582791440160998`. Udover at forsøge at deltage i en given gruppe ved opstart, vil botten også automatisk acceptere gruppe invitationer til denne gruppe, hvilket gør det muligt for dig at invitere din bot manuelt, hvis din gruppe har privat medlemskab. Hvis du ikke har nogen gruppe dedikeret til dine bots, bør du beholde denne egenskab med standardværdi på `0`.

---

### `SteamParentalCode`

`streng` type med standardværdi af `null`. Denne ejendom definerer din damp forældrepinkode. ASF kræver adgang til ressourcer, der er beskyttet af damp forældremyndighed, derfor hvis du bruger denne funktion, du skal give ASF med PIN-kode til oplåsning af forældrene, så den kan fungere normalt. Standardværdi for `null` betyder, at der ikke kræves nogen damp forældrepinkode for at låse denne konto op, og det er nok hvad du ønsker, hvis du ikke bruger damp forældrenes funktionalitet.

Under begrænsede omstændigheder kan ASF også selv generere en gyldig Steam-forældre-kode. selv om det kræver for mange OS-ressourcer og ekstra tid til at fuldføre for ikke at nævne, at det ikke er garanteret at lykkes, Derfor anbefaler vi ikke at stole på denne funktion og i stedet sætte gyldig `SteamParentalCode` i config for ASF at bruge. Hvis ASF bestemmer, at PIN er påkrævet, og det vil ikke være i stand til at generere en på egen hånd, vil det bede dig om input.

---

### `SteamPassword`

`streng` type med standardværdi af `null`. Denne ejendom definerer din damp adgangskode - den, du bruger til at logge ind til at dampe. Ud over at definere damp adgangskode her, kan du også beholde standardværdien af `null` , hvis du ønsker at indtaste din damp adgangskode ved hver ASF opstart i stedet for at sætte den i konfigurationen. Dette kan være nyttigt for dig, hvis du ikke ønsker at gemme følsomme data i config fil.

---

### `SteamTradeToken`

`streng` type med standardværdi af `null`. Når du har din bot på din venneliste, så bot kan sende en handel til dig med det samme uden at bekymre sig om handel token, derfor kan du efterlade denne egenskab til standardværdi af `null`. Hvis du beslutter dig for IKKE at have din bot på din venneliste, så skal du generere og udfylde en handel token som brugeren at denne bot forventer at sende handler til. Med andre ord, denne egenskab skal udfyldes med handelstoken for den konto, der er defineret med `Master` tilladelse i `SteamUserPermissions` af **denne** bot instans.

For at finde dit token, som logget ind bruger med `Master` tilladelse, navigér **[her](https://steamcommunity.com/my/tradeoffers/privacy)** og tag et kig på din handels-URL. Den token vi leder efter er lavet af 8 tegn efter `&token=` del i din handel URL. Du bør kopiere og sætte disse 8 tegn her, som `SteamTradeToken`. Medtag ikke hele handel URL, hverken `&token=` del, kun selve token (8 tegn).

---

### `SteamUserPermissions`

`ImmutableDictionary<ulong, byte>` type med standardværdien for at være tom. Denne egenskab er en ordbogsegenskab, som kort givet Steam-bruger identificeret af hans 64-bit damp-id, til `byte` -nummer, der angiver hans tilladelse i ASF instans. Nuværende tilgængelige bot tilladelser i ASF er defineret som:

| Værdi | Navn          | Beskriveslse                                                                                                                                                                                                   |
| ----- | ------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | None          | Ingen særlig tilladelse dette er hovedsageligt en referenceværdi, der er tildelt til damp-ID'er mangler i denne ordbog - der er ingen grund til at definere nogen med denne tilladelse                         |
| 1     | FamilySharing | Giver minimal adgang for brugere til familiesammendeling. Endnu en gang er dette primært en referenceværdi, da ASF er i stand til automatisk at opdage damp-ID'er, som vi tilladt for at bruge vores bibliotek |
| 2     | Operator      | Giver grundlæggende adgang til givne bot-instanser, hovedsageligt tilføje licenser og indløsningsnøgler                                                                                                        |
| 3     | Master        | Giver fuld adgang til given bot instans                                                                                                                                                                        |

Kort sagt, denne ejendom giver dig mulighed for at håndtere tilladelser for givne brugere. Tilladelser er vigtige primært for adgang til ASF **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, men også for at muliggøre mange ASF funktioner, såsom at acceptere handler. For eksempel kan du ønsker at indstille din egen konto som `Master`, og give `Operator` adgang til 2-3 af dine venner, så de nemt kan indløse nøgler til din bot med ASF mens **ikke** er støtteberettiget. . for at stoppe det. Takket være at du nemt kan tildele tilladelser til givne brugere og lade dem bruge din bot til nogle specificeret af dig grad.

Vi anbefaler at indstille præcis én bruger som `Master`og ethvert beløb, du ønsker som `Operators` og nedenfor. Mens det er teknisk muligt at indstille flere `Masters` og ASF vil fungere korrekt sammen med dem, for eksempel ved at acceptere alle deres handler, der sendes til bot, ASF vil kun bruge en af dem (med laveste damp-ID) for hver handling, der kræver et enkelt mål, for eksempel en `loot` anmodning, så også ejendomme som `SendOnFarmingFinished` præference i `FarmingPreferences` eller `SendTradePeriod`. Hvis du fuldt ud forstår disse begrænsninger, især det faktum, at `loot` anmodning altid vil sende varer til `Master` med laveste damp-id, uanset den `Master` , der rent faktisk udførte kommandoen derefter kan du definere flere brugere med `Master` tilladelse her, men vi anbefaler stadig en enkelt master-ordning.

Det er rart at bemærke, at der er en ekstra `Ejer` tilladelse, som er erklæret som `SteamOwnerID` global config ejendom. Du kan ikke tildele `Ejer` tilladelse til nogen her, da `SteamUserPermissions` -egenskaben definerer kun tilladelser, der er relateret til bot-instansen og ikke ASF som en proces. For bot-relaterede opgaver behandles `SteamOwnerID` den samme som `Master`, så det er ikke nødvendigt at definere dit `SteamOwnerID` her.

---

### `TradeCheckPeriod`

`byte` type med standardværdi `60`. Normalt håndterer ASF indgående handel tilbud lige efter at have modtaget meddelelse om en, men nogle gange på grund af Steam glitches det ikke kan gøre det på det tidspunkt, og sådanne handelstilbud forbliver ignoreret indtil næste handel notifikation eller bot genstart opstår, som kan medføre, at handlerne annulleres, eller at genstande, der ikke er tilgængelige på det pågældende senere tidspunkt, ikke er tilgængelige. Hvis denne parameter er sat til en ikke-nul-værdi, vil ASF desuden tjekke for sådanne udestående handler hver `TradeCheckPeriod` minutter. Standardværdien er valgt med balance mellem yderligere forespørgsler til dampservere og tab af indgående handler i tankerne. Men hvis du bare bruger ASF til gårdkort, og ikke planlægger at automatisk behandle indkommende handler, kan du indstille den til `0` for at deaktivere denne funktion helt. På den anden side, hvis din bot deltager i offentlige [ASF's STM notering](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) eller leverer andre automatiserede tjenester som en trade bot, du kan ønske at reducere denne parameter til `15` minutter eller deromkring, at behandle alle handler i tide.

---

### `TradingPreferences`

`byte flag` type med standardværdi `0`. Denne egenskab definerer ASF-adfærd ved handel og defineres som nedenfor:

| Værdi | Navn                | Beskriveslse                                                                                                                                                                                                        |
| ----- | ------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | None                | Ingen specielle handelspræferencer, standard                                                                                                                                                                        |
| 1     | AcceptDonations     | Accepterer handler, hvor vi ikke mister noget                                                                                                                                                                       |
| 2     | SteamTradeMatcher   | Passivt deltager i **[STM](https://www.steamtradematcher.com)**-lignende handler. Besøg **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** for mere info                  |
| 4     | MatchEverything     | Kræver `SteamTradeMatcher` at være indstillet og i kombination med det - accepterer også dårlige handler ud over gode og neutrale handler                                                                           |
| 8     | DontAcceptBotTrades | Accepterer ikke automatisk `loot` handler fra andre bot instanser                                                                                                                                                   |
| 16    | MatchActively       | Deltager aktivt i **[STM](https://www.steamtradematcher.com)**-lignende handler. Besøg **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** for mere info |

Bemærk venligst, at denne egenskab er `flag` feltet, derfor er det muligt at vælge en hvilken som helst kombination af tilgængelige værdier. Tjek **[json mapping](#json-mapping)** hvis du gerne vil lære mere. Aktiverer ikke nogen af flag resulterer i `Ingen` valgmulighed.

For yderligere forklaring af ASF handelslogik, og beskrivelse af alle tilgængelige flag, besøg afsnittet **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**.

---

### `TransferableTypes`

`ImmutableHashSet<byte>` type med standardværdi af `1, 3, 5` dampelementtyper. Denne egenskab definerer hvilke Steam-elementtyper der vil blive taget i betragtning ved overførsel mellem bots, under `overførsel` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. ASF vil sikre, at kun varer fra `TransferableTypes` vil blive inkluderet i et handelstilbud Derfor giver denne ejendom dig mulighed for at vælge, hvad du ønsker at modtage i en handel tilbud, der bliver sendt til en af dine bots.

| Værdi | Navn                | Beskriveslse                                                           |
| ----- | ------------------- | ---------------------------------------------------------------------- |
| 0     | Unknown             | Hver type, der ikke passer ind i nogen af nedenstående                 |
| 1     | BoosterPack         | Booster pakke med 3 tilfældige kort fra et spil                        |
| 2     | Emoticon            | Emoticon til brug i Steam Chat                                         |
| 3     | FoilTradingCard     | Foil variant af `TradingCard`                                          |
| 4     | ProfileBackground   | Profilbaggrund til brug på din Steam-profil                            |
| 5     | TradingCard         | Steam-handelskort, der bruges til fremstilling af badges (ikke folie)  |
| 6     | SteamGems           | Dampperler, der bruges til fremstilling af boostere, medfølgende sække |
| 7     | SalgGenstand        | Specielle elementer tildelt under Steam-salg                           |
| 8     | Forbrugsstoffer     | Særlige forbrugsvarer, der forsvinder efter brug                       |
| 9     | ProfileModifier     | Særlige elementer, der kan ændre Steam-profilens udseende              |
| 10    | Klistermærke        | Særlige genstande, der kan bruges på Steam chat                        |
| 11    | ChatEffect          | Særlige genstande, der kan bruges på Steam chat                        |
| 12    | MiniProfileBaggrund | Speciel baggrund for Steam-profil                                      |
| 13    | AvatarProfileFrame  | Speciel avatarramme til Steam-profil                                   |
| 14    | AnimatedAvatar      | Speciel animeret avatar til Steam-profil                               |
| 15    | TastaturSkin        | Specielt tastaturskin til Steam-dæk                                    |
| 16    | StartupVideo        | Speciel opstartsvideo til Steam-dæk                                    |

Bemærk venligst, at uanset ovenstående indstillinger ASF vil kun bede om **[Steam community elementer](https://steamcommunity.com/my/inventory/#753_6)** (`appID` på 753, `contextID` af 6), så alle spilelementer, gaver og ligeledes er udelukket fra handelstilbuddet pr. definition.

Standard ASF indstilling er baseret på den mest almindelige brug af bot, med overførsel kun booster pakker og handelskort (herunder folie). Den her definerede egenskab giver dig mulighed for at ændre denne adfærd på en eller anden måde, der tilfredsstiller dig. Husk venligst at alle typer der ikke er defineret ovenfor vil blive vist som `Ukendt` type hvilket er særlig vigtigt, når Ventilen frigiver et nyt Steam-element det vil også blive markeret som `Unknown` af ASF, indtil det er tilføjet her (i den fremtidige udgivelse). Derfor anbefales det generelt ikke at inkludere `Ukendt` type i din `TransferableTypes`, medmindre du ved, hvad du laver, og du forstår også, at ASF vil sende hele dit inventar i et handelstilbud, hvis Steam Network bliver brudt igen og rapporterer alle dine varer som `Ukendt`. Mit stærke forslag er ikke at inkludere `Ukendt` typen i `TransferableTypes`, selv om du forventer at overføre alt.

---

### `UseLoginKeys`

`bool` type med standardværdi af `true`. Denne egenskab definerer om ASF skal bruge login nøgle-mekanisme for denne Steam-konto. Login nøgler mekanisme fungerer meget lig den officielle Steam-klientens "husk mig" indstilling, hvilket gør det muligt for ASF at gemme og bruge midlertidig engangs brug login-nøgle til næste logonforsøg springe effektivt over et behov for at levere adgangskode, Steam Guard eller 2FA-kode, så længe vores login-nøgle er gyldig. Login-nøgle gemmes i filen `BotName.db` og opdateres automatisk. Det er derfor, du ikke behøver at angive adgangskode/SteamGuard/2FA-kode efter indlogning med succes med ASF bare én gang.

Login-nøgler bruges som standard for din bekvemmelighed, så du ikke behøver at indtaste `SteamPassword`, SteamGuard eller 2FA-kode (når du ikke bruger **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**) på hvert login. Det er også overlegen alternativ, da login-nøgle kan bruges kun for en enkelt gang og ikke afslører din oprindelige adgangskode på nogen måde. Præcis den samme metode bruges af din oprindelige Steam-klient, som gemmer dit kontonavn og login-nøgle til dit næste logonforsøg effektivt at være det samme som at bruge `SteamLogin` med `UseLoginKeys` og tom `SteamPassword` i ASF.

Men nogle mennesker kan være bekymrede over selv denne lille detalje, Derfor er denne mulighed tilgængelig her for dig, hvis du gerne vil sikre, at ASF ikke vil gemme nogen form for token, der ville tillade genoptagelse af tidligere session efter at være blevet lukket, hvilket vil resultere i fuld autentificering er obligatorisk for hvert loginforsøg. Deaktivering af denne indstilling vil virke præcis det samme som ikke at markere "husk mig" i den officielle Steam-klient. Medmindre du ved, hvad du laver, skal du holde det med standard værdi af `true`.

---

### `UserInterfaceMode`

`byte` type med standardværdi `0`. Denne egenskab angiver brugergrænsefladetilstand, som botten vil blive annonceret med efter logning på Steam-netværket. Det kan påvirke hvordan kontoen er synlig f.eks. på Steam-chaten, hvis din tilstedeværelse tillader det gennem `OnlineStatus`. I øjeblikket kan du vælge en af nedenstående tilstande:

| Værdi | Navn       | Beskriveslse                   |
| ----- | ---------- | ------------------------------ |
| `0`   | VGUI       | Standard Steam klient tilstand |
| `1`   | Tenfoot    | Stor billedtilstand            |
| `2`   | Mobil      | Steam mobil app                |
| `3`   | Web        | Webbrowser session             |
| `5`   | MobileChat | Steam mobil chat app           |

Den underliggende `EUIMode` type, som denne ejendom er baseret på, omfatter dog flere tilgængelige værdier. så vidt vi ved, har de absolut ingen virkning fra i dag, derfor blev de skåret for synlighed. Du kan også være interesseret i at kontrollere `GamingDeviceType`, da nogle yderligere funktioner er aktiveret der.

Hvis du ikke er sikker på, hvordan du sætter denne egenskab, så lad den være med standardværdien `0`.

---

### `WebProxy`

`streng` type med standardværdi af `null`. Denne egenskab definerer en webproxy-adresse, der vil blive brugt til bot-specifik intern http-relateret kommunikation, især til tjenester såsom `api. teampowered.com`, `steamcommunity.com` og `store.steampowered.com`. Hvis ikke angivet, vil ASF i stedet bruge den globale `WebProxy` -indstilling, der er angivet ovenfor. Proxying ASF anmodninger kunne være usædvanligt nyttigt for omgå forskellige former for firewalls, især den store firewall i Kina.

Denne egenskab er defineret som uri streng:

> En URI-streng består af et system (understøttet: http/https/socks4/socks4a/socks5), en vært og en valgfri port. Et eksempel på en komplet uri streng er `"http://contoso.com:8080"`.

Hvis din proxy kræver brugergodkendelse, skal du også konfigurere `WebProxyBrugernavn` og/eller `WebProxyPassword`. Hvis der ikke er et sådant behov, er det tilstrækkeligt at oprette denne ejendom alene.

Hvis du også har brug for proxying intern Steam-netværkskommunikation (CM'er) så skal du sikre dig at konfigurere **[`SteamProtocols`](#steamprotocols)** bots ejendom til en værdi, der tillader kun websocket transport, i. . a value of `4`, as only websockets are supported for proxying.

Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

### `WebProxyPassword`

`streng` type med standardværdi af `null`. Denne egenskab definerer password felt bruges i grundlæggende, fordøjelse, NTLM, og Kerberos godkendelse, der understøttes af et mål `WebProxy` maskine leverer proxy funktionalitet. Hvis din proxy ikke kræver brugeroplysninger, er der ingen grund til, at du indtaster noget her. Brug af denne indstilling giver kun mening, hvis `WebProxy` bruges så godt, da det ikke har nogen effekt ellers.

Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

### `WebProxyUsername`

`streng` type med standardværdi af `null`. Denne egenskab definerer brugernavn feltet der bruges i grundlæggende, fordøjelse, NTLM, og Kerberos godkendelse, der understøttes af et mål `WebProxy` maskine leverer proxy funktionalitet. Hvis din proxy ikke kræver brugeroplysninger, er der ingen grund til, at du indtaster noget her. Brug af denne indstilling giver kun mening, hvis `WebProxy` bruges så godt, da det ikke har nogen effekt ellers.

Medmindre du har en grund til at redigere denne egenskab, bør du holde den som standard.

---

## Fil struktur

ASF bruger ganske enkel filstruktur.

```text
ØJE📁 config
- ØJEBLIK - ASF. Søn
- Ør- Ør- Ør- ASF.db
- Ør- Bot1. Sson
- Ørk - Bot1.db
- Ør- Bot2. Sson
- Ørk - Bot2.db
- Ør...
├── ArchiSteamFarm.dll
├── log.txt
└── ...
```

For at flytte ASF til ny placering, for eksempel en anden pc, er det nok til at flytte/kopiere `config` mappe alene, og det er den anbefalede måde at gøre enhver form for "ASF backups", da du altid kan downloade den resterende (program) del fra GitHub, mens ikke risikere korrumperende interne ASF-filer, e. gennem en defekt backup.

`log.txt` -filen indeholder loggen genereret af din sidste ASF-kørsel. Denne fil indeholder ikke følsomme oplysninger, og er yderst nyttig, når det kommer til spørgsmål, nedbrud eller blot som en information til dig, hvad der skete i sidste ASF kørsel. Vi vil meget ofte spørge om denne fil, hvis du løber ind i problemer eller fejl. ASF administrerer automatisk denne fil for dig, men du kan yderligere justere ASF **[logging](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging)** modul, hvis du er avanceret bruger.

`config` mappe er det sted, der holder konfiguration for ASF, herunder alle dens bots.

`ASF.json` er en global ASF konfigurationsfil. Denne config bruges til at angive, hvordan ASF opfører sig som en proces, der påvirker alle bots og programmet selv. Du kan finde globale egenskaber der, såsom ASF proces ejer, auto-opdateringer eller fejlfinding.

`BotName.json` er en config af given bot instans. Denne config bruges til at angive, hvordan given bot instans opfører sig, Derfor er disse indstillinger kun specifikke for den pågældende bot og ikke deles på tværs af andre. Dette giver dig mulighed for at konfigurere bots med forskellige indstillinger og ikke nødvendigvis alle af dem arbejder på nøjagtig samme måde. Hver bot er navngivet ved hjælp af entydig identifikator, valgt af dig i stedet for `BotName`.

Bortset fra config filer, ASF bruger også `config` mappe til lagring af databaser.

`ASF.db` er en global ASF databasefil. Det fungerer som en global vedvarende lagring og bruges til at gemme forskellige oplysninger relateret til ASF-processen, såsom IP'er på lokale Steam-servere. **Du bør ikke redigere denne fil**.

`BotName.db` er en database over en given bot instans. Denne fil bruges til lagring af vigtige data om given bot instans i vedvarende lagring, såsom login-nøgler eller ASF 2FA. **Du bør ikke redigere denne fil**.

`BotName.keys` er en særlig fil, der kan bruges til at importere nøgler til **[baggrundsspil indløser](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. Det er ikke obligatorisk og ikke genereret, men anerkendt af ASF. Denne fil slettes automatisk, efter at nøgler er importeret.

`BotName.maFile` er en særlig fil, der kan bruges til at importere **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**. Det er ikke obligatorisk og ikke genereret, men genkendt af ASF, hvis dit `BotName` ikke bruger ASF 2FA endnu. Denne fil slettes automatisk, efter at ASF 2FA er importeret.

---

## JSON kortlægning

Hver konfigurationsegenskab har sin type. Egenskabens type definerer værdier, der er gyldige for den. Du kan kun bruge værdier, der er gyldige for en given type - hvis du bruger ugyldig værdi, så ASF vil ikke være i stand til at parse din config.

**Vi anbefaler stærkt at bruge ConfigGenerator til at generere configs** - det håndterer de fleste af de lav-niveau ting (såsom typer validering) for dig, så du kun behøver at indtaste rigtige værdier, og du behøver heller ikke at forstå de variable typer, der er angivet nedenfor. Denne sektion er primært for folk genererer / redigerer konfigurationer manuelt, så de ved, hvilke værdier de kan bruge.

Typer anvendt af ASF er indfødte C# typer, som er angivet nedenfor:

---

`bool` - Boolesk type accepterer kun `sande` og `falske` værdier.

Eksempel: `"Enabled": true`

---

`byte` - Usigneret byte type, accepterer kun heltal fra `0` til `255` (inklusive).

Eksempel: `"ConnectionTimeout": 90`

---

`ushort` - Usigneret kort type, accepterer kun heltal fra `0` til `65535` (inklusive).

Eksempel: `"WebLimiterDelay": 300`

---

`uint` - Usigneret heltalstype, der kun accepterer heltal fra `0` til `4294967295` (inklusive).

---

`ulong` - Usigneret lang heltalstype, der kun accepterer heltal fra `0` til `18446744073709551615` (inklusive).

Eksempel: `"SteamMasterClanID": 103582791440160998`

---

`streng` - Streng type, accepterer enhver sekvens af tegn, herunder tom sekvens `""` og `null`. Tom sekvens og `null` -værdien behandles samme af ASF så det er op til dine præferencer, som du ønsker at bruge (vi holder os til `null`).

Eksempler: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MyAccountName"`

---

`Guid?` - Nullable UUID type, i JSON kodet som streng. UUID er lavet af 32 hexadecimale tegn, spænder fra `0` til `9` og `a` til `f`. ASF accepterer forskellige gyldige formater - små bogstaver, store bogstaver, med og uden bindestreger. Udover gyldig UUID, da denne egenskab er ugyldig, en særlig værdi af `null` accepteres for at angive manglende UUID at levere.

Eksempler: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableList<valueType>` - Immutable collection (list) of values in given `valueType`. I JSON, er det defineret som en række elementer i givne `værditype`. ASF bruger `Liste` til at angive, at den givne ejendom understøtter flere værdier, og at deres ordre kan være relevant.

Eksempel på `ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` - uforanderlig samling (sæt) af unikke værdier i given `værdiType`. I JSON, er det defineret som en række elementer i givne `værditype`. ASF bruger `HashSet` til at angive, at den givne egenskab kun giver mening for unikke værdier, og at deres ordre ikke betyder noget, derfor vil det bevidst ignorere eventuelle potentielle dubletter under parsing (hvis du tilfældigvis leverer dem alligevel).

Eksempel for `ImmutableHashSet<uint>`: `"Blacklist": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>` - Formutable dictionary (map) that maps a unique key specified in its `keyType`, til værdi angivet i `-værditype`. I JSON defineres det som et objekt med nøgleværdipar. Husk, at `keyType` altid er citeret i dette tilfælde, selv om det er værditype såsom `ulong`. Der er også et strengt krav om, at nøglen er unik på tværs af kortet, denne gang håndhæves af JSON samt.

Eksempel for `ImmutableDictionary<ulong, byte>`: `"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`

---

`flag` - Flags attribut kombinerer flere forskellige egenskaber i en endelig værdi ved at anvende bitklog operationer. Dette giver dig mulighed for at vælge enhver mulig kombination af forskellige tilladte værdier på samme tid. Den endelige værdi er beregnet som en sum af værdier for alle aktiverede indstillinger.

For eksempel angivet følgende definition:

| Værdi | Navn |
| ----- | ---- |
| 0     | None |
| 1     | A    |
| 2     | B    |
| 4     | C    |

Der er præcis 3 meningsfulde, tilgængelige flag til at tænde/slukke (`A`, `B`, `C`), og derfor `8` mulige gyldige kombinationer samlet:

| Endelig værdi | Aktiverede flag |
| ------------- | --------------- |
| 0             | `None`          |
| 1             | `A`             |
| 2             | `B`             |
| 3             | `A` + `B`       |
| 4             | `C`             |
| 5             | `A` + `C`       |
| 6             | `B` + `C`       |
| 7             | `A` + `B` + `C` |

For at gøre ovennævnte muligt skal hvert enkelt enkeltstående flag derfor pr. definition være to beføjelser. Dette er grunden til, at yderligere flag i ovenstående eksempel, `D`, ville være nødt til at bære værdien af `8` eller større.

Normalt vil grafiske værktøjer gøre beregningen for dig. Hvis du redigerer konfigurationer manuelt, du kan altid bruge lommeregner og blot tilføje de underliggende værdier af alle de flag, du ønsker at aktivere - som i eksempel ovenfor.

Eksempel: `"SteamProtocols": 7` (som muliggør flag med en værdi af `1` `2` og `4`som forklaret ovenfor)

---

## Kortlægning af kompatibilitet

På grund af JavaScript-begrænsninger ved at være ude af stand til at serialisere simple `ulong` felter i JSON når du bruger web-baseret ConfigGenerator, `ulong` felter vil blive gengivet som strenge med `s_` præfiks i den resulterende konfiguration. Dette omfatter for eksempel `"SteamOwnerID": 76561198006963719` , der vil blive skrevet af vores ConfigGenerator som `"s_SteamOwnerID": "76561198006963719"`. ASF indeholder korrekt logik til at håndtere denne strengkortlægning automatisk, så `s_` poster i dine konfigurationer er faktisk gyldige og korrekt genereret. Hvis du selv genererer konfigurationer, anbefaler vi om muligt at holde sig til originale `ulong` felter men hvis du ikke kan gøre det, du kan også følge dette skema og indkode dem som strenge med `s_` præfiks tilføjet til deres navne. Vi håber at kunne løse denne JavaScript-begrænsning i sidste ende.

---

## Konfigner kompatibilitet

Det er topprioritet for ASF at forblive kompatibel med ældre konfigurationer. Som du allerede burde vide, behandles manglende konfigurationsegenskaber de samme som de ville blive defineret med deres **standardværdier**. Derfor, hvis ny konfigurationsegenskab bliver introduceret i ny version af ASF, vil alle dine konfigurationer forblive **kompatible** med ny version, and ASF will treat that new config property as it d be defined with its **default value**. Du kan altid tilføje, fjerne eller redigere config egenskaber efter dine behov.

Vi anbefaler kun at begrænse definerede konfigurationsegenskaber til dem, du ønsker at ændre, da du på denne måde automatisk arver standardværdier for alle andre, ikke kun holde din config ren, men også øge kompatibiliteten i tilfælde af at vi beslutter at ændre en standardværdi for egenskab, som du ikke ønsker at angive eksplicit selv (f. eks. . `WebLimiterDelay`).

På grund af ovenstående, vil ASF automatisk migrere / optimere dine konfigurationer ved at omformatere dem og fjerne felter, der holder standardværdi. Du kan deaktivere denne adfærd med `--no-config-migrere` **[kommandolinje argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** hvis du har en bestemt årsag, for eksempel du leverer read-only config filer, og du ønsker ikke ASF til at ændre dem.

---

## Auto-genindlæs

ASF er klar over, at konfigurer bliver ændret "on-the-fly" - takket være dette, ASF automatisk:
- Opret (og start, hvis nødvendigt) ny bot instans, når du opretter dens config
- Stop (hvis nødvendigt) og fjern gamle bot instans, når du sletter dens config
- Stop (og start, hvis nødvendigt) en bot instans, når du redigerer dens config
- Genstart (hvis nødvendigt) botten under nyt navn, når du omdøber dens config

Alle ovenstående er gennemsigtige og vil blive gjort automatisk uden behov for at genstarte programmet, eller dræbe andre (upåvirkede) bot forekomster.

Derudover vil ASF også genstarte sig selv (hvis `AutoGenstart` tilladelser), hvis du modificerer core ASF `ASF.json` config. Ligeledes program vil afslutte, hvis du sletter eller omdøbe det.

Du kan deaktivere denne adfærd med `--no-config-watch` **[kommandolinje argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** hvis du har en bestemt årsag, for eksempel ønsker du ikke fra ASF til at reagere på fil ændringer i `config` mappe.