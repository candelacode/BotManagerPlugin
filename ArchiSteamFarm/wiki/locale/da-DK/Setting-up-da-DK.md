# Opsætning

Hvis du ankom her for første gang, velkommen! We're very happy to see yet another traveler that is interested in our project, although bear in mind that with great power comes great responsibility - ASF is capable of doing a lot of different Steam-related tasks, but only as long as you **care enough to learn how to use it**. Faktisk læsning wiki at følge vores retningslinjer og lære mere om forskellige ASF-koncepter vil i sidste ende belønne dig med unikke evner at bruge et af de mest kraftfulde Steam-værktøjer, der er tilgængelige fra i dag.

Vi anbefaler dig at gøre **én ting ad gangen**. ASF berører en masse forskellige aspekter, hvoraf nogle er temmelig trivielle, andre kan være alt for komplekse. Du behøver ikke at forstå eller læse om alt på én gang, og vi faktisk anbefale dig at tage det let. Slap af, pluk dig selv en drik valg, dedikere en time af din tid og dykke ned i vores forelæsning - vi kan love, at det vil være værd at din tid.

Lad os starte fra det grundlæggende - ASF er en konsol-app i sit princip, hvilket betyder, at det ikke automatisk vil gyde en grafisk grænseflade, som du generelt er vant til. ASF er universel app, der hovedsagelig fungerer som en tjeneste (daemon), og ikke en desktop app. En af dens vigtigste brug sager mener kører på serveren maskiner, som desktop apps er helt uegnet til. Det mener kun den absolutte kerne af programmet selv, selv, fordi ASF faktisk **gør** indeholder sin egen grafiske grænseflade - i form af dens indbyggede ASF-ui frontend men vi kommer ned til den del i god tid - vi nævner bare dette med det samme, så du ikke går i panik, når du ser sort konsolskærm eller noget.

Når du får ASF binære filer, programmet vil kræve konfiguration fra dig, som specificerer, hvad præcis du forventer for ASF at opnå. Du kan starte programmet uden konfiguration, i dette tilfælde ASF vil starte i standardindstillinger, så du kan bruge e. . ASF-ui for den oprindelige konfiguration, men bortset fra, at det ikke vil gøre meget uden din tidligere handling.

Det vil gøre for nu, lad os begynde!

---

## OS-specifik opsætning

Generelt er her hvad vi vil gøre i de næste par minutter:
- Vi vil installere **[.NET forudsætninger](#net-prerequisites)**.
- Så downloader vi **[seneste ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** i en passende OS-specifik variant.
- Næste vil vi udtrække arkivet til ny placering.
- Så vil vi **[konfigurere ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- Og endelig, vi vil lancere ASF og se dens magi.

Nogle af trinene er selvforklarende, andre vil kræve mere opmærksomhed fra dig. Bare rolig, vi har fået dig dækket.

---

### .NET forudsætninger

Første skridt er at sikre, at dit operativsystem kan endda starte ASF korrekt. Du behøver ikke at vide det, men ASF er skrevet i C #, baseret på. ET platform og kan kræve indfødte biblioteker, der ikke er tilgængelige på din platform endnu. Tænk på det som DirectX for 3D-spil, eller motor for at starte din bil.

Afhængigt af om du bruger Windows, Linux eller macOS, vil du have forskellige krav. Referencedokumentet er **[. ET forudsætninger](https://docs.microsoft.com/dotnet/core/install)**, men for enkelthedens skyld har vi også detaljeret alle nødvendige pakker nedenfor, så du ikke behøver at læse den overhovedet, medmindre du løber ind i problemer, eller du har yderligere spørgsmål.

Det er helt normalt, at nogle (eller endda alle) afhængigheder allerede findes på dit system på grund af at blive installeret af tredjeparts software, som du bruger. Stadig, det behøver ikke at være tilfældet, så du bør køre passende installationsprogram til dit operativsystem - uden disse afhængigheder ASF vil ikke starte overhovedet, og du får knap nogen nyttige oplysninger til at fortælle dig, hvad der er forkert.

Husk, at du ikke behøver at gøre noget andet for OS-specifikke bygninger, især installation . ET SDK eller endda driftstid, da OS-specifik pakke indeholder alle disse allerede. Du behøver kun .NET forudsætninger (afhængigheder) for at køre . ET runtime inkluderet i ASF - så kun de ting, vi angiver nedenfor, uden andre tilføjelser.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** for 64-bit, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** for 32-bit eller **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** for 64-bit ARM)
- Det anbefales stærkt at sikre, at alle Windows-opdateringer allerede er installeret. Hvis du ikke har dem aktiveret, så i det mindste du har brug for **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** og **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, men der kan være behov for flere opdateringer. Du behøver ikke at bekymre dig om det, hvis din Windows er up-to-date, eller i det mindste nyere nok.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Pakkenavne afhænger af Linux-distributionen, som du bruger, vi har listet de mest almindelige. Du kan få dem alle med native pakkehåndtering til dit operativsystem (såsom `apt` for Debian eller `yum` for CentOS). Disse er temmelig standard biblioteker, der bør være tilgængelige, uanset hvilken fordeling du bruger, det er kun et spørgsmål om at finde ud af, hvordan de kaldes i dit foretrukne miljø.

- `ca-certificates` (standard betroede SSL-certifikater til at oprette HTTPS-forbindelser)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, seneste version til din distribution, for eksempel `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-libs`, seneste version til din distribution, mindst `1.1.X`)
- `libstdc++6` (`libstdc++`, i version `5.0` eller højere)
- `zlib1g` (`zlib`)

Mindst et flertal af dem bør allerede indbygget tilgængelig på dit system. For eksempel kræver den minimale installation af Debians stabil normalt kun `libicu76`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- Du behøver ikke noget specifikt, men du bør have den nyeste version af macOS installeret, mindst 12.0+

---

### Downloader

Da vi allerede har alle krævede afhængigheder, er næste trin at downloade **[seneste ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF er tilgængelig i mange varianter, men du er interesseret i pakke, der matcher dit operativsystem og arkitektur. Hvis du f.eks. bruger `64`-bit `Win`dows, så vil du have `ASF-win-x64` -pakke. For mere information om tilgængelige varianter, besøg afsnittet **[kompatibilitet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**. ASF er også i stand til at køre i de miljøer, som vi ikke bygger OS-specifik pakke for, såsom **32-bit Windows**, men du skal bruge **[generisk opsætning](#generic-setup)** til det.

![Assets](https://i.imgur.com/Ym2xPE5.png)

Efter download, start fra udpakning af zip-filen i sin egen mappe. Hvis du har brug for et specifikt værktøj til det, vil **[7-zip](https://www.7-zip.org)** gøre, men alle standard værktøjer som indbygget Windows-udvinding eller `unzip` fra Linux / macOS bør også fungere uden problemer.

Vær opmærksom på at udpakke ASF til **sin egen mappe** og ikke til nogen eksisterende mappe, du allerede bruger til noget andet - det er vigtigt. ASF indeholder auto-opdateringer funktion, som erstatter sine egne filer, og som normalt vil slette alle gamle og ikke-relaterede filer, når du opgraderer hvilket igen kan føre til, at du mister noget ikke-relateret du lægger i ASF mappe. Hvis du har nogen ekstra scripts eller filer, som du ønsker at bruge med ASF, det er ikke et problem, oprette en dedikeret mappe til dem, kan du altid sætte ASF i en mappe dybere.

Et eksempel på en struktur kunne se sådan ud:

```text
C:\ASF (hvor du placerer dine egne ting)
    - M - MyNotes. xt (valgfri)
    - M - AsfMakeMeCoffeeScript.bat (valgfri)
    - ... (alle andre filer efter eget valg, valgfri)
    - Core (dedikeret til ASF alene, hvor du udpakke arkivet)
         ¤ ArchiSteamFarm (. xe)
         - opdatering: config
         ° ° C - logs
         ° ° C - plugins
         ° C - K
         ° C - ( ...)
```

---

### Konfiguration

Vi er nu klar til at gøre det allersidste skridt, konfigurationen. ASF arbejder med begrebet "bots", hver bot er normalt en enkelt Steam-konto, som du gerne vil bruge inde i ASF. Du kan erklære så mange bots som du gerne vil have, men for starteren vil vi fokusere på blot en af dem - normalt din hovedkonto. ASF har også ikke-bot konfigurationsfiler, den vigtigste er global konfigurationsfil, som påvirker alle bots i det tilfælde.

Den generelle tommelfingerregel er, at **, hvis du ikke kender, eller ikke forstår nogle indstillinger, du bør efterlade den med dens standardværdi uden at ændre noget**. ASF tilbyder utallige måder at konfigurere, tilpasse og justere næsten alle dens funktioner, men som nævnt ovenfor, forsøger at forstå det lige ud for bat er en kanin hul, der kan hurtigt trække dig ind i alvorlig forvirring, if not **[straight into the abyss](https://www.youtube.com/watch?v=KK3KXAECte4)**. I stedet anbefaler vi at have et fungerende eksempel først, og først derefter begynde at grave ind i yderligere muligheder, ved hjælp af **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** side på wikien, mens du ændrer **en ting ad gangen**.

ASF konfiguration kan gøres på flere måder - gennem vores indbyggede ASF-ui frontend, en standalone web config generator, eller manuelt. Dette forklares indgående i afsnittet **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** , så referer til det, hvis du ønsker mere detaljerede oplysninger. Vi vil bruge standalone web config generator som udgangspunkt, fordi det virker, selvom af en eller anden grund ASF-ui ikke starter eller fungerer korrekt.

Naviger til vores **[web config generator](https://justarchinet.github.io/ASF-WebConfigGenerator)** side med din foretrukne browser. Vi anbefaler Chrome eller Firefox, men det bør ikke noget så længe din browser virker for alt andet.

Efter åbning af siden, skift til fanen "Bot". Du bør nu se en side svarende til den nedenfor:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Hvis ved nogen chance den version af ASF, du lige har hentet, er ældre end hvad config generator er indstillet til brug som standard, vælg blot din ASF-version fra rullemenuen. Dette kan (sjældent) ske, da config generator kan bruges til at generere configs til nyere (pre-release) ASF versioner, der ikke blev markeret som stabil endnu. Du har downloadet seneste stabile version af ASF, der er bekræftet at arbejde pålideligt, så det kan være lidt ældre end den absolutte forkant version, som er helt ikke egnet til første gang.

Start med **at sætte navn på din bot** i feltet markeret som rød, kaldet `Name`. Indeværende kunne være hvilken som helst benævne jer gerne ville gerne bruge, såsom jeres øgenavn, konto benævne, et nummer, eller noget andet. Der er kun ét ord, som du ikke kan bruge, `ASF`, da dette søgeord er reserveret til global konfigurationsfil. Ud over at dit bot navn ikke kan starte med en prik (ASF bevidst ignorerer disse filer). Vi anbefaler også, at du undgår at bruge rum, du kan bruge `_` som ordseparator, hvis det er nødvendigt - ikke et strengt krav, men du har svært ved at bruge ASF kommandoer ellers.

Bot navn besluttet? Super, i det næste trin, **ændre `Aktiveret` skifte til at være på**, at man definerer, om din bot formodes at være startet af ASF automatisk efter lanceringen (af programmet). Ikke at gøre det vil få ASF til at angive, at din bot er deaktiveret i konfigurationsfilen, og det vil vente til dit input til at starte det, hvilket ikke er hvad vi ønsker at gøre i dette eksempel.

Nu er der to følsomme egenskaber kommer op næste: `SteamLogin` og `SteamPassword`. Du kan træffe en anden beslutning her - du kan enten sætte dine Steam-login-oplysninger i disse to egenskaber, eller du kan beslutte dig for at gøre det, efterlader dem tomme.

ASF kræver dine loginoplysninger, fordi det indeholder sin egen implementering af Steam-klient og har brug for de samme oplysninger for at logge ind som den, du selv bruger. Dine loginoplysninger gemmes ikke hvor som helst, men på din pc i ASF `config` mappen (når du downloader den genererede config). Vores web config generator er klient-baseret program, hvilket betyder, at alt hvad du gør inde i vores standalone web config-generator hjemmeside kører lokalt i din browser til at generere gyldige ASF configs, uden detaljer, du indtaster nogensinde forlader din pc i første omgang, så der er ingen grund til at bekymre sig om eventuelle følsomme data lækage. Stadig, hvis du af en eller anden grund ikke ønsker at sætte dine legitimationsoplysninger der, vi forstår, at, og du kan sætte dem manuelt senere i genererede filer, eller udelade dem helt og fungere uden dem.

Hvis du beslutter dig for at indtaste dine legitimationsoplysninger, vil ASF automatisk kunne logge ind under opstart, som sammen med valgfri 2FA effektivt vil give dig mulighed for bare at dobbeltklikke på programmet til at køre alt. Hvis du beslutter dig for at udelade dem, så ASF vil **bede dig** om at indtaste disse oplysninger, når det er nødvendigt - denne tilgang vil ikke gemme dem nogen steder, men naturligvis ASF vil ikke være i stand til at operere uden din hjælp. Det er op til dig, hvilken vej du foretrækker mere, og du kan også finde yderligere oplysninger i **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** sektion, som sædvanligt.

Som en side bemærkning, kan du også beslutte at efterlade kun et felt tomt, såsom `SteamPassword`. ASF vil derefter kunne bruge dit login automatisk, men vil stadig bede om adgangskode, hvis det er nødvendigt (svarende til Steam-klient). Hvis du på nogen måde bruger 4-cifrede forældrepinen til at låse din konto op, Vi anbefaler også at placere det i boksen `SteamParentalPin` men også i dette tilfælde kan du bare efterlade denne tomme, og i stedet observere, hvor svag denne beskyttelse er, fordi ASF også kan "revne" sig selv inden for få sekunder efter logning ind. Ups.

Efter at have fulgt med alt ovenfor, så igen **bot name**, **aktiveret switch**, **loginoplysninger** , din webside vil nu se ud som den nedenfor:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Du kan nu trykke på "download" knappen og vores web config generator vil generere ny `json` fil baseret på dit valgte navn. Gem filen i mappen `config` , som er placeret i den mappe, hvori du har udtrukket zip-filen i det foregående trin.

Tillykke! Du har netop afsluttet den meget grundlæggende ASF bot konfiguration. Der er meget mere at opdage, men for nu er det alt, hvad du har brug for.

---

### Kører ASF

Jeg ved, du har ventet på dette øjeblik, og vi kan ikke holde dig længere, som du nu er klar til at starte programmet for første gang. Simpelthen dobbeltklik på `ArchiSteamFarm` binær i ASF mappe. Du kan også starte det fra konsollen.

Nu vil det være et godt tidspunkt at gennemgå vores **[fjernkommunikation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** -sektion, hvis du er bekymret over ting, som ASF er programmeret til at gøre, især handlinger, som det vil tage i dit navn, såsom at deltage i vores Steam-gruppe som standard. Du kan altid deaktivere udvalgte funktioner senere, hvis du ikke kan lide dem, ASF simpelthen kommer med fornuftige standardindstillinger, og vi var nødt til at træffe en beslutning om almindelig brug, der gælder for størstedelen af vores userbase, såvel som vores eget syn på programmet i princippet.

Antag, at alt gik godt, som for det meste anser installation af alle nødvendige afhængigheder i det første skridt, og konfiguration af ASF i den tredje, ASF skal starte korrekt, opdage din første bot, og forsøge at logge ind:

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF vil sandsynligvis stadig kræve en yderligere detalje fra dig - 2FA for at få adgang til kontoen (medmindre du har deaktiveret SteamGuard helt, så nej). Du skal blot følge instruktionerne på skærmen, du kan angive kode fra autentificering/e-mail, eller acceptere bekræftelsen i mobil-appen.

Noget gik galt?

#### ASF starter slet ikke, intet konsolvindue

Enten mangler du .NET forudsætninger, eller du har hentet forkert variant af ASF til din maskine. Hvis du ikke ved, hvad der er forkert, Tjek vores **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** for en mulig måde at finde ud af eksakt problem, og hvis du stadig sidder fast, nå til vores **[support](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### Ingen bots defineret

Du har ikke sat genereret config i mappen `config`. Nogle andre almindelige fejl i dette trin kan omfatte manuelt at ændre udvidelse fra `.json` fx til `. xt`og nogle operativsystemer (f.eks. Windows) gerne skjule almindelige udvidelser som standard, så sørg for at din fil er på passende sted og også med passende navn.

#### Start ikke denne bot, fordi den er deaktiveret i konfigurationsfilen

Du har glemt at vende `aktiverede` -knappen, som fortæller ASF at starte din bot automatisk. Medmindre det var din hensigt selvfølgelig, men så bør du allerede vide, hvordan man udfører kommandoer, blot `starte` din bot efter denne besked.

#### `InvalidPassword`

Dine loginoplysninger er højst sandsynligt forkerte. Tjek din `SteamLogin` og `SteamPassword` i den genererede konfiguration, hvis de tager fejl, korrigér dem ved at gå tilbage til konfigurationstrinnet. Hvis du stadig har problemer, så prøv at bruge de samme loginoplysninger i din egen Steam-klient - du bør også undlade at logge ind, og måske får du flere oplysninger om, hvad der er galt på denne måde.

#### Alt godt?

Når du har passeret gennem den indledende login-gate, vil du logge ind med succes under forudsætning af, at dine oplysninger er korrekte, og ASF vil starte landbruget ved hjælp af standardindstillinger, som du ikke røre fra nu:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Dette beviser, at ASF nu med succes gør sit arbejde på din konto, så du kan nu minimere programmet og gøre noget andet. Gå videre, du fortjente det, måske genopfylde, at drikke af dit valg i det mindste!

Landkort er et emne for en anden langvarig artikel som denne, men i princippet: efter tilstrækkelig tid (afhængigt af **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**) vil du se Steam-handelskort langsomt blive droppet. Selvfølgelig, for at det kan ske, skal du have gyldige spil til gård, viser som "du kan få X flere kort dråber fra at spille dette spil" på din **[badges side](https://steamcommunity.com/my/badges)** - hvis der ikke er nogen spil at gårde, så vil ASF erklære, at der ikke er noget at gøre som angivet i vores **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, som besvarer de mest almindelige spørgsmål folk har på dette tidspunkt, undrende hvorfor på trods af at eje kæmpestore 14 spil på deres konto, ASF hævder, at der er intet at gøre - nej, det er ikke en fejl.

Dette er afslutningen på vores meget grundlæggende etablering guide. Ligesom i alle RPG spil, du har afsluttet tutorial, og vi forlader dig hele ASF verden for at udforske nu. For eksempel kan du nu beslutte, om du vil konfigurere ASF yderligere, eller lade det gøre sit arbejde i standardindstillinger. Vi vil dække et par flere grundlæggende detaljer, hvis du gerne vil læse lidt mere, og derefter efterlade dig hele wiki til opdagelse.

---

### Udvidet konfiguration

#### Landbrug flere regnskaber på én gang

ASF støtter landbruget mere end én konto ad gangen, hvilket er dets primære funktion. Du kan tilføje flere konti til ASF ved at generere flere bot config filer, på nøjagtig samme måde som du har genereret din første for blot et par minutter siden. Du skal kun sikre to ting:

- Unikt bot navn, hvis du allerede har din første bot ved navn `MainAccount`, kan du ikke have en anden med samme navn.
- Gyldige loginoplysninger, såsom `SteamLogin`, `SteamPassword` og `SteamParentalCode` (hvis du har besluttet at udfylde dem)

Med andre ord, blot hoppe til konfiguration igen og gøre præcis det samme, bare for din anden eller tredje konto. Husk at bruge unikke navne til alle dine bots, for ikke at overskrive eksisterende configs.

---

#### Ændrer indstillinger

I vores standalone web config-generator, du ændrer eksisterende indstillinger på nøjagtig samme måde - ved at generere en ny config fil. Klik på "skifte avancerede indstillinger" og se, hvad der er der for dig at opdage. I dette eksempel vil vi ændre indstillingen `CustomGamePlayedWhileFarming` , som giver dig mulighed for at indstille brugerdefineret navn, der vises, når ASF er landbrug, i stedet for at vise det faktiske spil.

Lad os analysere dette lidt først. Hvis du kører ASF og begynder at drive landbrug, kan du i standardindstillingerne se, at din Steam-konto er i spil nu:

![Steam](https://i.imgur.com/1VCDrGC.png)

Det giver mening, efter at alle ASF lige har fortalt Steam-platformen, at vi spiller spillet, vi har brug for kort fra det, ikke? Men hey, vi kan tilpasse dette! Slå avancerede indstillinger til/fra hvis du endnu ikke har gjort det, så find `CustomGamePlayedWhileFarming`. Du skal blot sætte en brugerdefineret tekst, som du ønsker at vise der, såsom "Idling-kort":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Download nu den nye konfigurationsfil på nøjagtig samme måde, og **overskriv** din gamle konfigurationsfil med ny. Du kan også slette din gamle config fil og sætte den nye på sin plads selvfølgelig.

ASF er temmelig smart og det bør bemærke, at du har ændret config, som det derefter automatisk afhente og anvende, uden et program genstart. Hvis der ved nogen tilfældighed, der ikke skete, kan du blot genstarte programmet for at sikre din nye config er afhentet. Efter at gøre det, bør du bemærke, at ASF nu viser din brugerdefinerede tekst på det foregående sted:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

Dette bekræfter, at du har redigeret din config. På nøjagtig samme måde kan du ændre de globale ASF-egenskaber, ved at skifte fra bot-fanen til fanen "ASF", downloade genererede `ASF. son` config fil og sætte den i din `config` mappe.

Redigering af dine ASF-konfigurationer kan gøres meget lettere ved hjælp af vores ASF-ui frontend, som vil blive forklaret yderligere nedenfor.

---

#### Brug af ASF-ui

Som vi nævnte før, ASF er en konsol-app og starter ikke en grafisk brugergrænseflade som standard. Men vi arbejder aktivt på **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** frontend to our IPC interface, som kan være en meget anstændig og brugervenlig måde at få adgang til forskellige ASF-funktioner.

For at kunne bruge ASF-ui, skal du have `IPC` aktiveret, som er standardindstillingen, så medmindre du manuelt deaktiverer den, er den allerede aktiv. Når du starter ASF, bør du være i stand til at bekræfte, at det korrekt startede IPC interface automatisk:

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC, i en nøddeskal, er indbygget ASF's webserver, der starter lokalt på din maskine, giver dig mulighed for at interagere med det ved hjælp af din foretrukne webbrowser. Antages det, at det er startet korrekt, kan du få adgang til ASF's IPC-interface ved at klikke på **[dette](http://localhost:1242)** link, så længe ASF kører, fra samme maskine. Du kan bruge ASF-ui til forskellige formål, f.eks. redigering af konfigurationsfiler på stedet eller afsendelse af **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Du er velkommen til at tage et kig rundt for at finde ud af alle ASF-ui funktioner.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Summary

Du har opsat ASF til at bruge dine Steam-konti, og du har allerede tilpasset den til din smag. Hvis du fulgte hele vores guide, så lykkedes det dig også at justere ASF gennem vores ASF-ui interface og begyndte at opdage dens funktioner. Dette afslutter vores tutorial, men vi forlader dig med nogle yderligere henvisninger til ting, som du kan være interesseret i, "side quests", hvis du insisterer:

- Vores **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** sektion vil forklare dig, hvad **alle** de forskellige indstillinger, du har set rent faktisk gør, og hvad ASF ellers kan tilbyde dig. Bare husk at hydrere korrekt, mens du læser, du er blevet advaret.
- Hvis du snubler over et problem, eller du har et generisk spørgsmål, så overvej vores **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**, som bør dække alle eller i det mindste et stort flertal af spørgsmål og spørgsmål, som du måtte have.
- Hvis du ønsker at lære alt om ASF, og hvordan det kan gøre dit liv nemmere, Gå over til resten af **[vores wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. Brug sidepanelet til højre for at vælge det emne, der interesserer dig.
- Og endelig, hvis du fandt ud af vores program til at være nyttigt for dig, og du værdsætter den massive mængde arbejde, der blev lagt i det, du kan også overveje en lille **[donation](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** til vores sag. ASF arbejder for kærlighed, vi har arbejdet hårdt i vores fritid i de sidste 10 + år for at gøre denne oplevelse mulig for dig, og vi er meget stolte af det - selv $1 er højt værdsat og viser, at du passer. Under alle omstændigheder har det sjovt!

---

## Generisk opsætning

Dette appendiks er for avancerede brugere, der ønsker at oprette ASF til at køre i **[generisk](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)** variant. Mens det er mere besværligt i brug end **[OS-specifikke varianter](#os-specific-setup)**, kommer det også med yderligere fordele.

Du ønsker at bruge `generisk` variant hovedsagelig når:
- Du bruger OS, at vi ikke bygger OS-specifik pakke til (såsom 32-bit Windows)
- Du har allerede .NET Runtime/SDK, eller ønsker at installere og bruge en
- Du ønsker at minimere ASF struktur størrelse og hukommelse fodaftryk ved håndtering runtime krav dig selv
- Du ønsker at bruge et brugerdefineret **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** , som kræver en `generisk` -opsætning af ASF for at køre korrekt (på grund af manglende indfødte afhængigheder)

Selvfølgelig kan du bruge det også i ethvert andet scenario, du ønsker, men ovenstående giver mest mening.

Husk dog på, at generisk opsætning kommer med et twist - **du** er ansvarlig for .NET runtime i dette tilfælde. Det betyder, at hvis din .NET SDK (runtime) er utilgængelig, forældet eller brudt, vil ASF simpelthen ikke virke. Det er derfor, vi helt ikke anbefaler denne opsætning for afslappede brugere, da du nu skal sikre, at din . ET SDK (runtime) matcher ASF krav og kan køre ASF, i modsætning til **os** sikre at vores . ET runtime bundtet med ASF kan gøre det.

For `generisk` pakke, kan du følge hele OS-specifik vejledning ovenfor, med kun to små ændringer. Ud over at installere .NET forudsætninger ønsker du også at installere .NET SDK, og i stedet for at downloade og have OS-specifikke `ArchiSteamFarm(. xe)` eksekverbar fil, du vil nu downloade og har en generisk `ArchiSteamFarm.dll` binær kun. Alt andet er nøjagtig det samme.

Med ekstra trin:
- Installer **[.NET forudsætninger](#net-prerequisites)**.
- Installer **[.NET SDK](https://www.microsoft.com/net/download)** (eller i det mindste ASP.NET Core og .NET runtimes) passende til dit operativsystem. Du vil højst sandsynligt bruge en installatør. Se **[runtime krav](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** , hvis du ikke er sikker på, hvilken version der skal installeres.
- Download **[seneste ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** i `generisk` variant.
- Udpak arkivet til ny placering.
- **[Konfigurer ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**på nøjagtig samme måde som beskrevet ovenfor.
- Start ASF ved enten at bruge et hjælperscript eller udføre `dotnet /path/to/ArchiSteamFarm.dll` manuelt fra din foretrukne shell.

Generisk variant af ASF har ikke maskinspecifik binær Det hedder trods alt `generisk` af en grund - det er platform-agnostisk bygning, der kan arbejde overalt, så vent ikke `exe` fil der.

Det er derfor, vi har bundtet det med hjælpere scripts (såsom `ArchiSteamFarm.cmd` til Windows og `ArchiSteamFarm. h` for Linux/macOS), som er placeret ved siden af `ArchiSteamFarm.dll` binær. Du kan bruge dem, hvis du ikke ønsker at udføre kommandoen `dotnet` manuelt.

Selvfølgelig hjælper scripts vil ikke virke, hvis du ikke installere . ET SDK og du ikke har eksekverbar `dotnet` i din `PATH`. De er også helt valgfri at bruge, kan du altid `dotnet /sti/til/ArchiSteamFarm. vil` manuelt, hvis du gerne vil, som under hætten med nogle ekstra tweaks, det er præcis, hvad disse scripts gør alligevel.