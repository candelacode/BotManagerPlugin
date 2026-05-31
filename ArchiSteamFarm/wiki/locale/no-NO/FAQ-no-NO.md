# OSS

Vår grunnleggende FAQ dekker vanlige spørsmål og svar du måtte ha. Se vår **[utvidet FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ)** for en mindre vanlig problemstilling.

# Tabell over innhold

* [Generelt](#general)
* [Sammenligning med lignende verktøy](#comparison-with-similar-tools)
* [Sikkerhet / Personvern / VAC / Utestengelser / Tjenester](#security--privacy--vac--bans--tos)
* [Diverse](#misc)
* [Problemer](#issues)

---

## Generelt

### Hva er ASF?
### Hvorfor påstår programmet at det ikke er noen gårdsbruk på kontoen min?
### Hvorfor ASF oppdager ikke alle mine spill?
### Hvorfor er kontoen min begrenset?

Før du prøver å forstå hva ASF er, bør du forsikre deg om at du forstår hva Steam-kort er, og hvordan man skaffer dem, som er pent beskrevet i offisielle FAQ **[her](https://steamcommunity.com/tradingcards/faq)**.

Kort sagt, Steam-kort er samlbare objekter som du kvalifiserer for når du eier et bestemt spill, og kan brukes til å lage merker, selge på Steam-markedet eller andre formål med valget.

Kjernepunkter oppgis igjen her fordi folk generelt ikke vil godta dem og foretrekker å late som at de ikke finnes:

- **Du må eie spillet på Steam-kontoen din for å kunne motta kortslipp fra den. Familiedeling eier ikke og teller ikke.**
- **Spillet ditt kan ikke merkes som [privat](https://help.steampowered.com/faqs/view/1150-C06F-4D62-4966), ASF vil automatisk hoppe over slike partier under farmen.**
- **Du kan ikke bruke spillet uendelig, alle spill har fikset antall kort. Når du slipper alle disse (rundt halvparten av fullt sett), er spillet ikke en kandidat til oppdrett lenger. Det spiller ingen rolle om du har solgt, lagd eller glemt hva som har skjedd med kortene du har skaffet, Når du går tom for kortdroper, er spillet ferdig.**
- **Du kan ikke slippe kort fra F2P-spill uten å bruke noen penger på dem. Dette betyr permanent F2P-spill som Team Fortress 2 eller Dota 2. Eier av F2P-spill gir ikke oppgavelapper til deg.**
- **Du kan ikke slippe oppgavelapper på [begrenset konto](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A), uavhengig av egne spill og deres aktiveringsmetode.**
- **Betalt spill du har fått gratis under en kampanje kan ikke kjøpes av kortslipp, uansett hva som vises på butikksiden.**

SÃ¥ som du kan se, blir Steam-kort tildelt deg for Ã¥ spille et spill du kjøpte eller F2P-spill du setter penger til. Hvis du spiller et slikt spill lenge nok, vil alle kort for det spillet til slutt droppe inventaret ditt. om du gjør det mulig å fullføre et merke (etter å ha fått igjen halvdelen av settet), selg dem eller gjør alt det du vil.

Nå som vi har forklart det grunnleggende ved Steam, kan vi forklare ASF. Programmet er ganske kompleks til å forstå fullt, så i stedet for å grave i alle de tekniske detaljene, gir vi en helt forenklet forklaring nedenfor.

ASF logger inn på din Steam konto gjennom vår innebygde og egendefinerte Steam-klient implementering ved hjelp av dine oppgitte legitimasjoner. After successfully logging in, it parses your **[badges](https://steamcommunity.com/my/badges)** in order to find games that are available for farming (`X` card drops remaining). Etter at du har analysert alle sider og satt opp en sluttliste over partier som er tilgjengelig, velger ASF den mest effektive algoritmen for oppdrett, og starter prosessen. Prosessen er avhengig av valgt **[-kort algoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** , men vanligvis består den av å spille kvalifisert spill og periodisk (pluss hver gjenstandsslipp) å sjekke om spillet er fullt besøkt allerede - hvis ja, ASF kan fortsette med neste tittel, bruk av den samme prosedyren, inntil alle partier er kommet til fart.

Husk at forklaringen ovenfor er forenklet og ikke beskrive dusin ekstra funksjoner og funksjoner som ASF tilbyr. Besøk resten av **[vår wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki)** hvis du vil vite alle ASF-detaljer. Jeg forsøkte å gjøre det enkelt nok å forstå for alle, uten å ta inn tekniske detaljer - oppfordres til å grave ut hyrder.

Nå som program - ASF tilbyr noe magi. Først må den ikke laste ned noen av dine spillfiler, den kan spille spill med en gang. For det andre: Det er helt uavhengig av din normale Steam-klient - du trenger ikke at Steam-klienten kjører eller til og med installeres i det hele tatt. For det tredje: Det er automatisert løsning - noe som betyr at ASF automatisk gjør alt bak ryggen din, uten å ha behov for å fortelle hva du skal gjøre – noe som sparer deg brått og tid. Til slutt må den ikke lure Steam-nettverk ved å behandle emulering (som f.eks Idle Master bruker), fordi den kan kommunisere med den direkte. Det er også superraskt og lett, det er en fantastisk løsning for alle som vil få kort lett uten å stresse - det kommer spesielt nyttig ved å la det løpe i bakgrunnen og gjøre noe annet eller spiller i frakoblet modus.

Alt det ovenfor er fint, men ASF har også tekniske begrensninger som håndheves av Steam - vi kan ikke dyrke ut spill du ikke eier, vi kan ikke kjøre gårdsspill for å få ekstra dråper forbi den håndhevede grensen, og vi kan ikke bruke spill mens du spiller. Alt dette bør være ”logisk”, og ta hensyn til hvordan ASF fungerer. men det er hyggelig å merke seg at ASF ikke har stormakter og ikke gjør noe fysisk umulig. så ha det i tankene – det er i utgangspunktet det samme som hvis du har fortalt noen å logge inn på kontoen din fra en annen PC og dyrk disse spillene for deg.

Så for å oppsummere - ASF er et program som hjelper deg med å slippe kortene du er kvalifisert for, uten mye hersker. Den har også flere andre funksjoner, men la oss holde seg til denne for nå.

---

### Må jeg legge ved mine kontoanvisninger?

**Ja**. ASF krever dine kontoopplysninger på samme måte som den offisielle Steam-klienten gjør som den samme metoden for Steam-nettverksinteraksjon. Dette betyr ikke at du må sette dine kontodetaljer i ASF-konfigurasjoner, du kan fortsette å bruke ASF med tom `SteamLogin` og/eller `SteamPassword`, og skriv inn data i hvert ASF kjører, når det kreves (i tillegg til flere andre påloggingslegitimater, henviser til konfigurasjon). På denne måten lagres ikke detaljene dine hvor som helst, men selvfølgelig ASF kan ikke starte automatisk uten hjelp fra før. ASF tilbyr også flere andre måter å øke **[sikkerhet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**, så vær fri å lese den delen av wikien hvis du er avansert bruker. Hvis du ikke har det, og du ønsker ikke å sette dine kontoopplysninger i ASF-konfigurasjoner, gjør det ganske enkelt ikke, og setter dem i stedet selv ved når ASF ber om dem.

Husk at ASF-verktøy er for din personlige bruk, og at innloggingsinformasjon aldri forlater din datamaskin. Du deler heller ikke dem med noen i kroppen, som oppfyller **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** - en veldig viktig ting som mange glemmer om. Du sender ikke dine detaljer til våre servere eller tredjepart. Du sender bare direkte til Steam-servere som drives av Radiatortermostat. Vi vet ikke din legitimasjon, og vi kan heller ikke gjenopprette dem for deg, uansett om du har satt dem i dine konfigurasjoner eller ikke.

---

### Hvor lenge må jeg vente på at kort skal slippe?

**så lenge det tar** - på alvor. Hvert spill har forskjellige jordbruks vanskelighetsgrad satt av utvikler/publiserer, og det er helt opp til dem hvor fort kort blir slettet. Vanlig spill følger 1 dråpe per 30 minutter med spilling, men det er også spill som kreves fra deg til å spille enda flere timer før du dropper kort. I tillegg kan kontoen din bli begrenset fra å motta kortdråper fra spill du ikke spilte nok tid ennå, som angitt i **[ytelse](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** avsnitt. Ikke forsøk å gjøre gjetninger for hvor lang tid ASF skal gårde med tittelen - Det er ikke opp til deg, heller ikke ASF å bestemme. Det er ingenting du kan gjøre for å gjøre det raskere, og det finnes ingen "feil" relatert til oppgavelapper som ikke slippes rettidig - du kontrollerer ikke oppgavelappens prosess og gjør heller ikke så god som helhet. I beste fall får du i gjennomsnitt 1 dråpe per 30 minutter. I verste fall vil du ikke motta noe kort selv de første 4 timene siden du startet med ASF. Begge disse situasjonene er normale og dekkes i vår **[prestasjon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**.

---

### Jordbruk tar for lang tid, kan jeg nok øke farten på den?

Det eneste som i stor grad påvirker driftshastighet, er valgt **[-oppgavelappenes algoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** for botinstansen. Alt annet har ubetydelig effekt og vil ikke gjøre oppdrett raskere, mens noen handlinger som å starte ASF-prosessen flere ganger vil også **gjøre det verre**. Har du virkelig lyst til å ta hvert eneste sekund fra jordbruksprosessen, så ASF lar deg finjustere noen kjernevariabler som `FarmingDelay` - alle blir forklart i **[konfigurasjon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Men som jeg sa, er effekten ubetydelig, å velge en god oppgavelappbruksalgoritme som skal hensyntas er ett og det eneste avgjørende valget som kan påvirke anleggets hastighet i stor grad, Alt annet er rent kosmetisk. I stedet for å bekymre seg om driftshastighet, bare kast ASF og la det gjøre sin jobb - Jeg kan forsikre deg om at det gjør det på den mest effektive måten jeg kan komme inn på. Jo mindre du bryr deg, desto mer vil du bli fornøyd.

---

### Men ASF sa at oppdrett vil ta omtrent X tid!

ASF gir deg en grov tilnærming basert på antall oppgavelapper du må slippe, eller din valgte algoritme – dette er ikke noe sted nær den tiden du vil bruke på å dyrke og dyrke som vanligvis er lengre enn dette da ASF forutsetter kun beste tilfelle, og ignorerer alle Steam Network quirks, internett-frakobling, overbelastning av Steam-servere og på samme måte. Det bør ses på som en generell indikator hvor lenge du kan forvente at ASF vil være landbrukende, svært ofte i beste fall siden den faktiske tiden vil være forskjellig, selv i enkelte tilfeller. Som nevnt ovenfor, prøv ikke å gjette hvor lenge spillet vil bli framhatt, det er ikke opp til deg, heller ikke ASF å bestemme.

---

### Kan ASF virke på min android/smarttelefon?

ASF er et C# program som krever arbeidsgjennomføring av .NET. Android became a valid platform starting with .NET 6.0, however, there is currently a major blocker in making ASF happen on Android due to **[lack of ASP.NET runtime available on it](https://github.com/dotnet/aspnetcore/issues/35077)**. Selv om det ikke er et naturlig alternativ tilgjengelig, er det ordentlige og fungerende bygg for GNU/Linux på ARM-arkitektur. så det er helt mulig å bruke noe som **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** for å installere Linux, så bruk ASF så Linux chroot som vanlig.

Når/hvis alle ASF-krav er oppfylt, vil vi vurdere å utgi en offisiell Android-bygg.

---

### Kan ASF gårdsgjenstander fra Steam-spill, for eksempel CS:GO eller Unturned?

**No**, this is against **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** and Valve clearly stated that with last wave of community bans for farming TF2 items. ASF er et Steam-kort-program, ikke spill bonden - den har ingen mulighet til å spille spill, og og det er ikke planlagt å legge til slike funksjoner i framtiden, først og fremst på grunn av at Steam bryter med bruksvilkårene. Vennligst ikke spør om dette - det beste du kan få er en rapport fra noen saltet bruker og du har problemer. Det samme gjelder for alle andre typer jordbruket, for eksempel dråper fra CS:GO sendinger. ASF har utelukkende fokus på Steam-handelskort.

---

### Kan jeg velge hvilke spill som skal være farlig?

**Yes**, through several different ways. Hvis du ønsker å endre standardrekkefølgen i køen til oppdrett, da er det hva `FarmingOrders` **[bot konfigurasjon egenskap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** kan brukes til. Hvis du ønsker å svarteliste spill manuelt fra å bli kjøpt automatisk, du kan bruke inaktiv svarteliste som er tilgjengelig med `fb` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Hvis du ønsker å dyrke alt, men gir noen apper prioritet over alt andre, som er hvilken hvilende prioritert kø tilgjengelig med `fq` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** kan brukes for. Og til slutt hvis du vil gårde spesifikke spill bare av ditt valg så kan du erklære `FarmPriorityQueueOnly` i bot's **[`FarmingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)** for å oppnå dette, sammen med å legge til valgte apper til uvirksom prioritetskøen.

I tillegg til å administrere automatisk kortdriftsmodul, som er beskrevet ovenfor, du kan også bytte ASF til manuell Oppstillingsmodus med `play` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, eller bruk andre feilaktige eksterne innstillinger som `GamesPlayedWhileIdle` **[robotens konfigurasjonsegenskap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

---

### Jeg er ikke interessert i kortdråper, jeg vil kaste ut timeverk som jeg har spilt istedet - er det mulig?

Ja, ASF lar deg gjøre det på minst flere måter.

Den beste måten å oppnå det på er å bruke **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** sin konfigurasjon eiendom som skal spille de valgte appIDene dine når ASF ikke har noen oppgavelapper å dyrke. Hvis du ønsker å spille spill hele tiden, selv om du får kort fra andre spill, så kan du kombinere den med **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**Derfor vil ASF kun bruke de spillene til kortslipp som du har satt eksplisitt eller alternativt **[`FarmingPausedByStandard`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**som vil forårsake at kortdriftsmodulen blir satt på pause før du lar pausere det selv.

Du kan også bruke **[`spille`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#commands-1)** kommandoen, som vil føre til at ASF spiller dine valgte spill. Husk imidlertid at `spiller` bare bør brukes til spill du vil spille midlertidig, siden det ikke er en vedvarende tilstand, som får ASF til å gå tilbake til standardtilstanden. . På frakobling fra Steam-nettverket. Derfor anbefaler vi deg å bruke `GamesPlayedWhileIdle`, med mindre du virkelig ønsker å starte de valgte spillene dine for en kort periode, og deretter gå tilbake til den generelle flyten.

---

### Jeg er Linux / macOS bruker, vil ASF gårdsspill som ikke er tilgjengelig for mitt OS? Vil ASF gård 64-bit spill når jeg kjører den på 32-biters OS?

Ja, ASF bebutter ikke engang med å laste ned aktuelle spillfiler, så det fungerer med alle lisenser knyttet til din Steam-konto, uansett hvilken som helst plattform eller tekniske krav. Det bør også fungere for spill knyttet til bestemt region (regionlåste spill) selv når du ikke er i matchende regionen. Selv om vi ikke garanterer at (det fungerte sist vi prøvet).

---

## Sammenligning med lignende verktøy

---

### Er ASF lik Idle Master?

Den eneste likheten er generelt sett med begge programmene, som er dyrket Steam-spill for å motta kortfall. Alt annet, innbefattet selve oppdrettsmetoden, programstruktur, funksjonalitet, kompatibilitet, brukte algoritmer, spesielt kildekoden selv, er helt forskjellige og de to programmene har ikke noe vanlig med hverandre, selv kjernefundamentet - IM kjører på. ET Framework, ASF på .NET (Core). ASF ble opprettet for å løse i.m. problemer som ikke var mulig å løse med en enkel koderedigering - derfor er ASF skrevet fra bunnen av, uten å bruke en enkelt kodelinje eller til og med generell idé fra IM, fordi kode og ideene er helt feilaktige til å begynne med. IM og ASF er som Windows og Linux - begge operativsystemer kan installeres på din PC, men deler nesten ikke noe med hverandre, bortsett fra å tjene lignende formål.

Dette er også hvorfor du ikke bør sammenligne ASF med i.m. forventninger. Du bør behandle ASF og IM som helt uavhengige programmer med egne eksklusive sett av funksjoner. Noen av dem overlappet veldig og du kan begge finne en bestemt egenskap i men svært sjelden fungerer siden ASF tjener formålet med en helt annen måte enn IM.

---

### Er det verdt å bruke ASF, hvis jeg for øyeblikket bruker Idle Master og det fungerer fint for meg?

**Ja**. ASF er mye mer pålitelig og inkluderer mange innebygde funksjoner som er **crucial** uavhengig av hvordan du gårder, that IM simply simply not offer.

ASF har rett logikk for **upubliserte spill** - IM skal forsøke å bønde spill som har kort tilført allerede, selv om de ikke var frigitt ennå. Selvsagt er det ikke mulig å bruke disse partiene før de legger ut datoen, så driftsprosessen din blir sittende. Dette krever at du enten legger den til i svartelisten, venter på utgivelse eller hopp over manuelt. Ingen av disse løsningene er gode, og alle krever oppmerksomheten din - ASF går automatisk over i uutløste spill (midlertidig), og returnerer tilbake til dem senere når de er helt unngår problemene og håndterer problemet på en effektiv måte.

ASF har også korrekt logikk i **serie** videoer. Det er mange videoer på Steam som har kort, men annonseres ennå med feil `appID` på merkesiden som for eksempel **[Double Fine Adventure](https://store.steampowered.com/app/402590)** - IM vil falskt gård feil `appID`, som skal gi ingen dråper og en prosess som sitter fast. Igjen må du enten svarteliste det eller hoppe over manuelt, begge kreve din oppmerksomhet. ASF oppdager automatisk riktig `appID` for oppdrett, noe som fører til kortfall.

I tillegg til det, ASF er **mye mer stabil og pålitelig** når det kommer til nettverksproblemer og Steam spørringer - det meste av tiden og krever ikke din oppmerksomhet til enhver tid konfigurert, Selv om IM ofte bryter for mange krever ekstra rettelser eller rett og slett ikke fungerer uansett. Det er også helt avhengig av Steam-klienten din, noe som betyr at den ikke kan fungere når Steam-klienten din opplever noen alvorlige problemer. ASF fungerer som det skal så lenge den kan koble seg til Steam-nettverk og krever ikke at Steam klient kjører eller blir installert.

De er 3 **svært viktige** punkter hvorfor du bør vurdere å bruke ASF, siden de direkte berører alle gårdbrukere Steam-kort og det er ingen måte å si "dette betyr ikke for meg", da det skjer Steam-vedlikehold og virvler til alle. Det er dusin av ekstra mindre og viktigere grunner som du kan lære om i resten av FAQen. So shortly speaking, **yes**, du burde bruke ASF selv når du ikke trenger noen ekstra ASF-funksjon som er tilgjengelig sammenlignet med IM.

I tillegg til dette avsluttes IM offisielt og kan brekke helt i fremtiden, uten noen genser for å fikse det, med tanke på mye kraftigere løsninger (ikke bare ASF). IM fungerer ikke for mange og det er bare tallet som går opp, ikke ned. Du bør unngå å bruke foreldet programvare på førsteplassen, ikke bare IM, men også andre avskrekkede programmer. Ingen aktiv vedlikeholder betyr at ingen bryr seg om hvorvidt den fungerer eller ikke, og **ingen er ansvarlig for sin funksjonalitet**, som er en viktig sak i sikkerheten. Det er nok at det kommer en kritisk feil, noe som forårsaker faktiske problemer med Steam-infrastrukturen - med ingen som fikser det, Steam kan gi en annen banebølge hvor du blir slått av uten at du er klar over at dette er et problem, da allerede har skjedd med folk som bruker, gjetter hva, foreldede versjoner av ASF.

---

### Hvilke interessante funksjoner har ASF tilbud som Idle Master ikke om?

Det kommer an på hva du anser som "interessant" for deg. Hvis du planlegger å bruke flere konti enn ett, så er svaret allerede åpenbart siden ASF lar deg drive alle med en overlegen løsning. redde ressurser, herjessering og kompatibilitetsspørsmål. Men hvis du spør dette spørsmålet, sannsynligvis ikke har du det angitte behovet, så la oss evaluere andre fordeler som gjelder for én enkelt konto i ASF.

Først og fremst du har noen innebygde funksjoner nevnt **[over](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** som er kjerne for oppdrett uavhengig av ditt sluttmål, svært ofte at det alene allerede er nok til å vurdere å bruke ASF. Men dere vet allerede at så la oss flytte på noen flere interessante trekk:

- **Du kan gårde offline** (`OnlineStatus` i `Frakoblet` innstilling. Jordbruk offline gjør det mulig for deg å hoppe over din Steam status helt, hvilket lar deg drive med ASF mens du viser "Online" på Steam samtidig, uten vennene dine merker at ASF spiller et spill på dine vegne. Dette er overlegen funksjonen, siden det lar deg forbli pålogget i Steam-klienten din, og ikke irritere vennene dine med konstante spillendringer, eller misvisende dem til å tenke at du spiller et spill mens du i virkeligheten ikke er det. Dette punktet alene gjør det verdt å bruke ASF hvis du respekterer dine egne venner, men det er bare begynnelsen. Det er også fint å merke seg at denne funksjonen ikke har noe å gjøre med Steam personverninnstillinger - hvis du lanserer spillet selv, deretter vises du ordentlig når du er i spillet, noe som bare gjør ASF-del usynlig og ikke påvirker kontoen din i det hele tatt.

- **Du kan hoppe over refunderbare spill** (`SkipRefundableGames` i `FarmingPreferences` funksjon). ASF har riktig innebygd logikk for refunderbare spill og du kan konfigurere ASF for ikke å kjøre refunderbare spill automatisk. Dette gjør at du kan vurdere deg selv om ditt nykjøpte spill av Steam-butikken var verdt pengene dine. uten ASF som forsøker å slippe oppgavelapper fra dette så snart som mulig. Hvis du spiller det i 2+ timer eller 2 uker siden kjøpet, så ASF vil fortsette med det spillet siden det ikke kan refunderes lenger. Inntil du har full kontroll på om du har den eller ikke, og du enkelt kan refundere den hvis nødvendig, refundere den uten å måtte svarteliste manuelt at spillet eller ikke bruker ASF for hele varigheten.

- **Du kan hoppe over ikke-spilte spill** (`SkipUnplayedGames` i bot's `FarmingPreferences` funksjon). ASF har riktig innebygd logikk for timer i spill og du kan konfigurere ASF til ikke spill uten spill automatisk. Dette gjør at du kan kontrollere deg selv spillene du spiller og bruker uten å måtte svarteliste alle dem manuelt, eller hoppe over å bruke ASF helt.

- **You can automatically mark new items as received** (`BotBehaviour` of `DismissInventoryNotifications` feature). Jordbruk med ASF vil resultere i at du får dråper på kontoen din. Du vet allerede at dette skjer, så la ASF tydelig fortelle deg at ubrukelig varsel, for at bare viktige ting skal gjøre oppmerksomheten igjen. Selvsagt bare hvis du vil.

- **Du kan tilpasse foretrukket driftsperiode med flere tilgjengelige alternativer** (`FarmingOrders` funksjoner. Kanskje vil du kaste ut de nykjøpte spillene dine først? Eller dine eldste enere? Ut fra antall kortfall? Merkenivåene du allerede er laget? Spilte timer? Alfabetically? I følge AppID? Eller kan kanskje være helt tilfeldig? Det er helt opp til deg å bestemme.

- **ASF kan hjelpe deg med å fullføre settene** (`TradingPreferences` med `SteamTradeMatcher` -funksjonen). Med en litt mer avansert tinkering, du kan konvertere din ASF til helt utvalgte brukerbot som automatisk vil akseptere **[STM](https://www.steamtradematcher.com)** tilbud, hjelper deg hver dag til å matche dine sett uten noen brukerinteraksjon. ASF inkluderer også sin egen ASF 2FA-modul, slik at du kan importere din Steam mobile autentisering, og lar deg fullt ut automatisere hele prosessen med å motta bekreftelser. Eller du ønsker å godta manuelt og la ASF bare gjøre opp for disse handlene for deg? Det er igjen, helt opp til deg å bestemme.

- **ASF kan innløse nøkler i bakgrunnen for deg** (**[bakgrunnsspill løser inn](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** funksjonen). Du har kanskje hundre nøkler fra forskjellige bunter som du er for lat til å innløse deg selv. å gå gjennom haug med vinduer, og godkjenne Steam-vilkår om og om igjen. Hvorfor ikke kopiere og lime inn listen av nøkler i ASF og la den gjøre sin jobbet? ASF vil automatisk innløse alle disse nøklene i bakgrunnen, gi deg passende output for å gi deg beskjed om hvordan hvert innløsningsforsøk viser seg. Hvis du har hundrevis av nøkler er du dessuten garantert å bli takstbegrenset av Steam før eller senere, og ASF vet også om det, det vil tålmodig vente på at hastighetsgrensen skal gå bort, og gjenoppta der den er igjen.

Vi kunne nå gå på og på med hele **[ASF wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**, peker ut hver eneste funksjon i programmet, men vi må tegne en linje et sted. Det er det, det er en liste med funksjoner du kan nyte som ASF bruker, hvor bare ett av dem lett kunne anses som en stor grunn til å aldri se tilbake, og vi oppført **lot** av dem, med enda flere du kan lære om i resten av vår wiki. Vh ja, og vi gikk ikke engang i detalj med ting som ASFs API slik at du kunne skrive dine egne kommandoer, eller fantastiske bots administrasjon, siden vi ville ha det enkle.

---

### Er ASF raskere enn Ons Master?

**Ja**, selv om forklaringen er ganske komplisert.

På hver nye prosess ble spawnet og avsluttet i systemet, Steam-klienten sender automatisk en forespørsel som inneholder alle spillene du spiller nå - denne måten dampnettet kan beregne timer og gjøre oppgavelappene slipp. Men dampnettverket teller tiden din du spiller med ett sekunds intervall, og sende en ny forespørsel nullstiller gjeldende status. Hvis du kom inn/dreper ny prosess hvert 0,5 sekunder, vil du aldri slippe noe kort fordi hver 0. andre dampklient vil sende en ny forespørsel, og et dampnettverk vil aldri telle selv ett sekund av spilletiden. Dessuten på grunn av hvordan operativsystemet fungerer, er det faktisk ganske vanlig å se at nye prosesser blir oppstått/avsluttet uten at du gjør noe, selv så selv om du ikke gjør noe på PCen din - det er mange prosesser som fortsatt arbeider i bakgrunnen, og som avslutter andre prosesser hele tiden. Idle master er basert på dampklienten, så denne mekanismen påvirker deg hvis du bruker den.

ASF er ikke basert på dampklient, og har sin egen implementering av dampklienter. Takket være det, hva ASF gjør, er det ikke å gyte noen prosesser, men sender faktisk en virkelig forespørsel om damp nettverk som vi begynte å spille et spill. Dette er samme forespørsel som skulle sendes av dampklient, men fordi vi har kontroll over ASF-damp klienten, trenger vi ikke sette i gang nye prosesser, og vi er ikke som etterligner dampklient etter å ha sendt forespørsel om hver prosessendring, så mekanismen som forklares ovenfor påvirker oss ikke. Takket være det er aldri at vi avbryter ett annet intervall på dampnettsiden, og det øker driftshastigheten vår.

---

### Men er forskjellen virkelig merkbar?

Nr. Avbruddene som skjer med normal dampklient og inaktiv mester har ubetydelig effekt på kortfallene, Det er derfor ingen merkbar forskjell som vil gjøre ASF bedre.

However, there **is** a difference, and you can clearly notice that, as depending on how busy your OS is, cards **will** drop faster, from a few seconds to even a few minutes, if you're extremely unlucky. Selv om jeg ikke ville vurdere å bruke ASF bare fordi det slipper kort fortere, siden både ASF og Idle Master blir påvirket av hvordan steam nett fungerer. ASF reagerer bare med dampnettet mer effektivt. Idle Master kan ikke styre hva damp klienten faktisk gjør (det er ikke inaktiv masterfeil, men damp klienten selv).

---

### Kan ASF gård ha flere partier på en gang?

**Ja**, selv om ASF vet bedre når man skal bruke funksjonen, basert på valgte **[oppgavelapper Oppgavealgoritmen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Kortfall slippes når man jordbruker flere spill på nær null, dette er grunnen til at ASF bruker flere spill som oppdrett utelukkende for timer for å overvinne `HoursUntilCardDrops` raskere, i opptil `32` -spill på en gang. Dette er også grunnen til at du bør fokusere på konfigurasjonsdelen av ASF, og la algoritmer bestemme hva som er den beste måten å nå målet på – det du synes er riktig, er ikke nødvendigvis riktig i virkeligheten, så vil det på en gang ikke gi deg noen kortslipp.

---

### Kan ASF hoppe over spill raskt?

**Ingen**, ASF støtter ikke og oppfordrer verken bruk av **[Steam glitches](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance#steam-glitches)**.

---

### Kan ASF automatisk spille hvert spill i X timer før oppgavelapper legges til?

**Ingen**, hele punktet for Steam-kortsystemendringen var å kjempe med falsk statistikk og spøkelse av spillere. ASF vil ikke bidra til at det ikke er planlagt mer enn nødvendig, tilføyelse av en slik funksjon, og vil ikke skje. Hvis du får kortdråper på vanlig måte, vil ASF dyrke dem så snart som mulig.

---

### Kan jeg spille et spill mens ASF er bonde?

**No**. ASF, i motsetning til andre verktøy som integrerer med Steam-klienten din, har sin uavhengige implementering av den klienten inkludert, og Steam-nettverk tillater bare **en Steam-klient når** spiller et spill. Du kan imidlertid koble fra ASF når du liker ved å starte et spill (og klikke "OK" når du spør om Steam-nettverket bør koble fra andre klienter) - ASF vil da vente til du er ferdig med å spille, og gjenoppta prosessen etterpå. Alternativt kan du fortsatt spille i frakoblet modus når du vil, hvis det er tilfredsstillende for deg.

Husk at oppgavelappene mister raten når flere partier spilles nær null likevel, det derfor ikke finnes noen direkte fordeler ved å kunne gjøre det med andre verktøy, mens det er en stor fordel med ingen forstyrring av andre spill som lanseres med ASF, som er helt avgjørende. . VAC-viser.

---

## Sikkerhet / Personvern / VAC / Utestengelser / Tjenester

---

### Kan jeg få forbud mot VAC til å bruke denne?

Nei, det er ikke mulig fordi ASF (forskjellig fra noen andre verktøy, for eksempel Idle Master, SGI eller SAM) påvirker ikke på noen måte med både damplissør og prosessene. Det er fysisk umulig å få VAC forbud for å bruke ASF, selv når man leker på sikrede servere mens ASF kjører - dette er fordi **ASF ikke engang krever at Steam-klient installeres i hele** for å kunne fungere som de skal. ASF er ett av de bare få oppdrettsprogrammene som i dag kan garantere at VAC-gratis.

---

### Kan du bruke ASF forhindre meg å spille på VAC-sikrede servere, som oppgitt **[her](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**?

ASF krever ikke at Steam-klienten kjører eller til og med installeres i det hele tatt. Ifølge dette begrepet skal det **ikke** forårsake VACrelaterte spørsmål. fordi ASF garanterer mangel på forstyrrende Steam-klient og alle dens prosesser - dette er hovedpunktet når vi snakker om VAC-free garantier som ASF tilbyr.

Ifølge brukere og beste av min kunnskap er dette akkurat nå. siden ingen rapporterte eventuelle problemer som er angitt i koblingen ovenfor mens du bruker ASF. Vi kunne ikke reprodusere problemet ovenfor med ASF også, mens vi tydelig reproduserer det med Idle Master.

Husk imidlertid at ventil fremdeles kan legge ASF til svartelisten på et bestemt tidspunkt, men det er helt tull som selv om de gjør det, du kan fortsatt spille VAC-sikrede spill fra PC'en din, og du kan bruke ASF samtidig . . på serveren din, så jeg er ganske sikker på at de vet veldig bra at ASF ikke bør være en mistenkt VAC-viser, De vil ikke gjøre våre løgn hardere ved å svarteliste ASF uten grunn. Men i verste fall vil du ikke være i stand til å spille, som angitt over, Siden VAC- fri garanti for ASF fortsatt er her uavhengig om Steam blacklists ASF-binær, eller ikke (og kan fortsatt starte ASF på en annen maskin uten at Steam-klienten blir installert i det hele tatt). Nå er det ikke behov for å gjøre noe av det, og la oss håpe det holder seg slik.

---

### Er det trygt?

Hvis du spør om ASF er sikker som programvare, noe som betyr at det ikke vil forårsake noen skade på datamaskinen din, vil ikke stjele dine private data, installere virus eller andre ting som det - det er trygt. ASF er fri for malware, stealing, cryptocurrency miners og hvilken som helst (og alle) annen tvilsom kan anses som skadelige eller uønskede av brukeren. I tillegg til at vi har en dedikert **[fjernkommunikasjon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** -delen som dekker våre retningslinjer for personvern og ASF-oppførsel som går utover det du konfigurerte programmet selv å gjøre.

Vår kode er åpen kildekode, og distribuerte binarer utarbeides alltid fra **[offentlig tilgjengelige kilder](https://en.wikipedia.org/wiki/Open-source_software)** av **[automatiserte og klarerte kontinuerlige integrasjonssystemer](https://en.wikipedia.org/wiki/Build_automation)**, og ikke engang utviklere selv. Hver versjon er reproduserbar av vårt build-skript og vil resultere i nøyaktig samme kode som **[deterministic](https://en.wikipedia.org/wiki/Deterministic_system)** IL (binær). Hvis du av hvilken som helst grunn ikke stoler på bygningene våre, kan du alltid kompilere og bruke ASF fra kilden, inkludert alle biblioteker som ASF er i bruk (som SteamKit2), som er åpen kildekode også.

Det er imidlertid hele tiden tillit til utvikler(ne) av søknaden din, så du bør avgjøre deg selv om du anser å være sikker eller ikke, og potensielt støtte beslutningen med tekniske argumenter beskrevet ovenfor. Ikke blindt tro på noe bare fordi vi sa det - kontroller deg selv ettersom det er eneste måten å gjøre deg sikker på.

---

### Kan jeg bli utestengt for dette?

For å svare på det spørsmålet, bør vi se nærmere på **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Steam forbyr ikke ved bruk av flere kontoer, faktisk **[tillater det](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)** , som innebærer at du kan bruke samme mobilautentisering på mer enn én konto. Det det det det derimot ikke tillater er, er å dele kontoer med andre personer, men det gjør vi ikke.

Det eneste virkelige punktet som behandler ASF er følgende:
> Du kan ikke bruke Cheat, automatiseringsprogramvare (botter), mods, hacks eller andre uautoriserte tredjeparts programvare, for å modifisere eller automatisere noen prosess for "Subscription Marketplace".

Spørsmålet er hva som faktisk skjer med Subscription Marketplace . Som vi leser:

> Et eksempel på et abonnement på markedet er Steam Community Market

Vi endrer ikke eller automatiserer markedsprosessen for abonnementsplassering, hvis vi etter abonnementsmarkedsplassen forstår vi damp eller damp butikken. Likevel...

> Ventiler kan avbryte kontoen eller alle bestemte abonnement(er) når som helst i tilfelle (a) ventiler slutter å gi slike abonnementer til samme sted generelt, eller (b) du bryter alle vilkår for denne avtalen (inkludert eventuelle abonnementsvilkår eller regler for bruk).

Som for hver Steam-programvare, ASF er ikke godkjent av Radiatortermostat og jeg kan ikke garantere at du ikke blir suspendert hvis Radiatortermostat plutselig bestemmer at de utestenger kontoer som bruker ASF nå. Det er svært usannsynlig å tenke på at ASF brukes på mer enn noen få millioner av Steam-kontoer. siden den første utgivelsen som skjedde for over 10 år siden - men likevel en mulighet, uansett hvilken sannsynlighet som faktisk var.

Spesielt fordi:
> Når det gjelder alle abonnementer, innhold og tjenester som ikke er bestilt av Radiatortermostat, Radiatortermostaten viser ikke noe tilsvarende tredjeparts innhold som er tilgjengelig på Steam eller gjennom andre kilder. Ventiler påtar seg ikke ansvar eller ansvar for slikt tredjepartsinnhold. En programvare for anvendelse fra tredjeparter kan imidlertid brukes av bedrifter til forretningsformål. du kan kun få slik programvare via Steam til privat privat bruk.

Ventilen anerkjenner imidlertid tydelig "Steam idlers" og den er som nevnt i **[her](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**, så hvis du spurte meg, Jeg er ganske sikker på at hvis de ikke var klare med dem, ville de allerede gjøre noe i stedet for å peke på at de kunne forårsake problemer VAC-vise. Hovedordet her er **Steam** idlers, for eksempel ASF og ikke **spill** -idlere.

Vær oppmerksom på at over bare er vår tolkning av **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** og ulike punkter - ASF er lisensiert under Apache 2. Lisens, som tydelig sier:

```
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
```

Du bruker denne programvaren på egen risiko. Det er svært usannsynlig at du kan bli forbudt på det, men hvis du gjør det, kan du bare skylde på det.

---

### Ble noen utestengt for det?

**Ja**hadde vi minst en del hendelser som til nå resulterte i en slags Steam-suspensjon. Og om ASF selv var rotårsaken eller ikke er helt annen historie som vi sannsynligvis aldri blir kjent med.

Første tilfelle involverte en fyr med over 1000 + botter og får forbudt handel (sammen med alle botter), mest sannsynlig på grunn av overdreven bruk av `loot ASF` utført på alle bots samtidig, eller andre mistenkelige engangseffekter med handel i løpet av kort tid.

> Hei XXX, Takk for at du kontaktet Steam støtte Det ser ut som denne kontoen ble brukt til å håndtere et nettverk av bot kontoer. Flytting bryter med Steam-abonnenten.

Vennligst bruk noen fornuft og ikke anta at du kan gjøre såpass gal ting bare fordi ASF lar deg gjøre det. Å gjøre `loot ASF` på over 1k av bots kan enkelt betraktes som en **[DDoS](https://en.wikipedia.org/wiki/DDoS)** angrep, Jeg er selv ikke sjokkert over at noen ble forbudt for en slik ting. Behold minimum greit bruk i forhold til Steam-tjenesten, og **er mest sannsynlig** vil du være fin.

Andre tilfelle involverte en fyr med 170+ botter som fikk utestengelse under Steams salg 2017 Winter Sale.

> Kontoen din ble blokkert for brudd på avtalen om abonnentens Steam. Ved å dømme av utvekslinger og andre faktorer, ble denne kontoen brukt til ulovlig innsamling av samlingskort på Steam, så vel som relatert og ikke bare næringsvirksomhet. Kontoen er permanent blokkert, og Steam-støtte kan ikke gi ytterligere støtte på dette problemet.

Denne saken er igjen svært vanskelig å analysere, på grunn av uklar respons fra Steam støtte som knapt tilbyr noen detaljer. Basert på min personlige tankegang utvekslet denne brukeren Steam-kort for noen typer penger (havn i en bot? eller på annen måte prøvde å kontante ut på Steam. I tilfelle du var uskyldig vil dette også være ulovlig i følge **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Vi har ikke mulighet til å fortelle deg hva du kan gjøre med handelskortene innhentet gjennom ASF - men den aktuelle brukeren klarte ikke bare å lage distinksjoner med dem.

Tredje tilfelle involverte bruker med 120+ bots som er forbudt for brudd på **[Steam online conduct](https://store.steampowered.com/online_conduct?l=english)**.

> Hei XXX, Takk for at du kontaktet Steam støtte Dette og andre regnskap er benyttet for flom nettinfrastrukturen vår, noe som bryter med Steam på nett. Kontoen er permanent blokkert, og Steam-støtte kan ikke gi ytterligere støtte på dette problemet.

Dette tilfellet er litt enklere å analysere på grunn av ekstra detaljer fra brukeren. Det tilsynelatende var at brukeren brukte **en svært utdatert ASF-versjon** som inkluderte en feil som forårsaket ASF for å sende overdrevent antall forespørsler til Steam-tjenere. Feilen fantes ikke ved første gang, men ble aktivert på grunn av Steam-brytningsendring som ble løst i fremtidig versjon. **ASF støttes kun i [nyeste stabile versjon](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) utgitt på GitHub**.

Du kan ikke anta at noe utdatert ASF-versjon vil fungere som den har til enhver tid, spesielt fordi Steam stadig endrer seg, uansett om du liker det eller ikke. Hvis det skjer globalt, blir det raskt patchet og gitt ut til alle brukere som en bugfix. Venve forbyr ikke over en million av AF-brukere på grunn av vår eller deres feil, av åpenbare grunner. Hvis du med vilje fraskriver deg fra å bruke oppdaterte ASF, deretter er du i et svært lite mindretall av brukere som er **eksponert for hendelser som denne** på grunn av **uten støtte**, siden det ikke ser på noen over din utdaterte versjon av ASF, ingen som fikser det og ingen påser at du ikke kommer til å fengsle utestengt ved bare å åpne det. **Vennligst bruk oppdatert programvare**, ikke bare ASF, men alle andre applikasjoner også.

Siste tilfelle skjedde rundt juni 2021, ifølge brukeren:

> Med bruk av programmet har jeg foretatt en boosterpakke med 28 regninger i 3 år og med 128 utgjør de siste 6 månedene. Jeg var på nett med maksimalt 15 kontoer samtidig som jeg skulle lage boosterpakker, og sende dem til hovedkontoen. I forrige måned økte jeg antall nettbaserte kontoer samtidig til 20 og 1 uke etter at alle kontoer ble utestengt. Denne eposten er ikke til å gi dere, tvert i mot var jeg alltid kjent med konsekvensene. Jeg ville at dere skulle vite hvilke typer adferd som resulterer i en permanent forbud.

Det er vanskelig å si om økning i samtidige kontoer er den direkte årsaken til utestengelsen, Det ville jeg ikke telle til, istedet mener jeg at regnskapstall alene var hovedkularen, økte konsoller med nettbaserte kontoer førte sannsynligvis bare til at brukeren ble bedt om det, fordi han klart hadde langt flere bots enn anbefalingen.

---

All of the incidents above have one thing in common - ASF is just a tool and it's **your** decision how you're going to make use of it. Du blir ikke utestengt for å bruke ASF direkte, men for **hvordan** du bruker det. Det kan være ett redskap for hjelpere, bare én enkelt konto, eller et massivt oppdrettsnettverk laget av tusenvis av boter. Jeg tilbyr uansett ikke råd og du bør avgjøre om du skal bruke ASF i det første stedet. Jeg gjemmer ikke noe informasjon som kan hjelpe deg, f.eks. det faktum at ASF fikk noen personer forbudt (og i hvilken kontekst), siden jeg ikke har noen grunn til å - Det er ditt valg hva du vil gjøre med den informasjonen.

Hvis du spør meg - bruk noe til felles, unngå å eie flere bots enn anbefalingen, ikke send hundrevis av fag samtidig. Alltid bruk oppdatert ASF versjon og du _skal_ være fin. Every single incident of this nature for **some reason** always happened to people that have disregarded our recommendations, best practices and suggestions, believing that they know better than us e.g. how many bots they can run. Enten det bare er en tilfeldighet eller en faktisk faktor, er det opp til deg å bestemme. Vi tilbyr ikke noe juridisk råd, og bare en tanker om at du kan være nyttig, eller ser bort fra dem helt og opererer bare på fakta som er koblet ovenfor.

---

### Hvilken personverninformasjon ASF opplysninger?

Du finner en detaljert forklaring i Avsnitt **[for fjernkommunikasjon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** Du bør gjennomgå det hvis du bryr deg om personvernet ditt, for eksempel hvis du lurer på hvorfor kontoer som brukes i ASF blir med i vår Steam-gruppe. ASF samler ikke inn noen sensitiv informasjon, og deler den ikke med noen tredjepart.

---

## Diverse

---

### Jeg bruker ustøttet OS som 32-biters Windows, kan jeg fortsatt bruke siste versjon av ASF?

Ja, og den versjonen støttes ikke på noen måte, bare ikke offisielt bygget. Sjekk ut **[kompatibilitet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** seksjonen for generisk variant. ASF har ingen sterk avhengighet av OS, og den kan jobbe hvor som helst der du får til. ET kjøretid, som inkluderer 32-bit Windows, selv om det ikke finnes noen `win-x86` OS-spesifikk pakke fra oss.

---

### ASF er god! Kan jeg gi en donasjon?

Ja, og vi er svært glade for å høre at du har glede av prosjektet vårt! Du finner forskjellige donasjonsmuligheter under hver **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** og også **[på hovedsiden](https://github.com/JustArchiNET/ArchiSteamFarm)**. Det er hyggelig å merke seg at vi i tillegg til generiske pengedonasjoner også aksepterer Steam items, Så ingenting skal hindre deg i å donere skall, nøkler eller en liten del av kortene som du har kjøpt med ASF hvis du ønsker det. Takk på forhånd for din sjenerøsitet!

---

### Jeg bruker Steam foreldrePIN for å beskytte kontoen min, må jeg skrive inn noe sted?

Ja, du må sette det i `SteamParentalCode` bot konfigurasjonsegenskapen. Dette er hovedsakelig fordi ASF har tilgang til mange beskyttede deler av Steam-kontoen din og det er umulig for ASF å operere uten den.

---

### Jeg ønsker ikke ASF å bruke noen spill som standard, men jeg ønsker å bruke ekstra ASF-funksjoner. Er dette mulig?

Ja, hvis du bare vil starte ASF med pausede oppgavelapper oppdrett, modul du kan angi `FarmingPausedByStandard` i `FarmingPreferences` bot config property for å oppnå det. This will allow you to `resume` it during runtime.

Hvis du vil deaktivere kortoppdrett modulen fullstendig, og sørger for at den aldri vil kjøre uten å eksplisitt fortelle den annerledes. deretter anbefaler vi å angi `FarmPriorityQueueOnly` i bot's `FarmingPreferences`, som i stedet for bare pauser den, vil deaktivere gården helt inntil du legger til spillene i uvirksom prioritert kø selv.

Med oppgavelappdriftsmodulen pauset/deaktivert, kan du bruke ekstra ASF-funksjoner, som `GamesPlayedWhileIdle`.

---

### Kan ASF minimere oppføringen?

ASF er en konsollapp, det er ikke noe vindu som kan bli minimert, fordi OSs vindu lages for deg. Du kan imidlertid bruke et tredjepartsverktøy som kan gjøre dette, for eksempel **[RBTray](https://github.com/benbuck/rbtray)** for Windows, or **[skjerm](https://linux.die.net/man/1/screen)** for Linux/macOS. Dette er bare eksempler, det finnes mange andre apper med liknende funksjonalitet.

---

### Hvis du bruker ASF, bevarer du muligheten for å motta boosterpakker?

**Ja**. ASF bruker samme metode for å logge inn på Steam nettverk som den offisielle kunden, Det bevarer derfor også muligheten til å motta boosterpakker med konti som brukes i ASF. Dessuten krever ikke hensynet til å fornye evnen innlemme i Steam-samfunnet, så du trygt kan bruke `OnlineStatus` i `Tilkoblet` hvis du ønsker det.

---

### Er det noen måte å kommunisere med ASF?

Ja, gjennom flere ulike måter. Sjekk **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** -seksjonen for mer info.

---

### Jeg vil hjelpe med ASF-oversettelse, hva trenger jeg å gjøre?

Takk for din interesse! Du kan finne alle detaljene i vår **[localization](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** del.

---

### Jeg har bare en (hoved) konto lagt til ASF, kan jeg likevel utstede kommandoer gjennom dampchat?

**Ja**, den er forklart i **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#notes)** seksjonen. Du kan gjøre det ved å bruke Steam gruppe-chat, selv om du bruker **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** kan bli enklere for deg.

---

### ASF ser ut til å fungere, men jeg mottar ingen kortdrops!

Oppdrett hastighet avviker fra spill til spill, som du kan lese i **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Det tar en stund, vanligvis **flere timer per spill**, oppgavelappen skal ikke slippe i løpet av noen få minutter siden programmet ble lansert Om du kan se at ASF aktivt sjekker kortstatusen, og brytere spillet etter at gjeldende er helt dyrket, så fungerer alt fint ut. Det er mulig at du har aktivert et alternativ som `DismissInventoryNotifications` av `BotBehaviour` som automatisk avviser inventarvarsler. Sjekk ut **[sin konfigurasjon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** for detaljer.

---

### Hvordan helt stopper ASF-prosessen for min konto?

Bare skru av ASF-prosessen, for eksempel ved å klikke [X] i Windows. Hvis du i stedet ønsker å stoppe en bestemt bot ved ditt valg, men behold at andre kjører, ta en titt på `Aktivert` **[bot konfigurasjons egenskap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**, eller `stopp` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Dersom du i stedet ønsker å stoppe den automatiske jordbruksprosessen, men beholde ASF som kjører på kontoen din, deretter gjelder det feltet `FarmingPausedByStandard` alternativet `FarmingPreferences` i **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** og `pause` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** er for.

---

### Hvor mange boter kan jeg løpe med ASF?

ASF som et program har ingen hard øvre grense i botten instanser, så du kan løpe så mye du har minnet på maskinen din, Men du er fortsatt begrenset av Steam-nettverket og andre Steam-tjenester. For tiden kan du løpe opp til 100-200 botter med én enkelt IP og én enkel ASF-forekomst. Det er mulig å kjøre flere botter med flere IP-adresser og flere ASF-tilfeller, ved å jobbe rundt IP-begrensninger. Husk at hvis du bruker en stor mengde bots, må du kontrollere tallet sitt selv. Som å sørge for at alle faktisk logger inn og arbeider samtidig. ASF ble ikke svekket for det enorme antallet botter, og hovedregelen gjelder at **de flere bots du har, jo flere problemer du vil støte på**. Man legger også merke til at grensen generelt avhenger av mange interne faktorer, det er ca. i stedet for en nøyaktig grense - du vil sannsynligvis kunne kjøre flere/mindre bots enn angitt ovenfor.

ASF team foreslår **owning** opp til **10 Steam-kontoer totalt**, og kjører derfor også opp til **10 botter totalt**. Alt over støttes ikke og gjøres for eget risiko, mot vårt forslag som er gjort her. Denne anbefalingen er basert på interne retningslinjer for ventiler, samt våre egne forslag. Om du skal følge denne regelen eller ikke er ditt valg, ASF som et verktøy vil ikke gå mot din egen vilje, selv om det vil føre til at Steam-kontoen din blir suspendert for å gjøre det. Derfor vil ASF vise deg en advarsel hvis du går over det vi anbefaler, men fortsatt la deg kjøre noe du vil ha på egen risiko og mangel på vår støtte.

---

### Kan jeg ha flere ASF-instanser da?

Du kan kjøre så mange ASF-forekomster på en maskin som du ønsker, forutsatt at hver instans har sin egen katalog og sine egne konfigurasjoner, og konto som brukes i én instans brukes ikke i en annen en. Spør deg imidlertid hvorfor du vil gjøre det. ASF er optimalisert for å kunne håndtere mer enn hundre kontoer samtidig, og som lanserer fra hundre botter i egne ASF-instanser bryter frem, tar flere OS-ressurser (som CPU og minne), og forårsaker en potensiell synkronisering problemer mellom frittstående ASF-tilfeller, Siden ASF tvinges til å dele sine grensebrytere med andre tilfeller.

Therefore, my **strong suggestion** is, always run maximum of one ASF instance per one IP/interface. Dersom du har flere IP/grensesnitt, så kan du likevel kjøre flere ASF-tilfeller, med hver forekomst bruker sin egen IP/interface eller unik `WebProxy` innstilling. Hvis du ikke gjør det, så lanserer du mer ASF-forekomster fullstendig mindre, siden du ikke får noe ved å starte mer enn 1 forekomst per enkelt IP/grensesnitt. På magisk vis vil Steam ikke la deg kjøre flere bots bare fordi du har lansert dem i en annen ASF-forekomst. og ASF begrenser deg ikke til å begynne med.

Selvsagt er det fortsatt gyldig brukstilfeller for flere ASF-forekomster på samme nettverksgrensesnitt, for eksempel å være vert for ASF-tjenester for dine venner med hver venn som har sin egen unike ASF-instans for å garantere isolasjon mellom bots og selv AF-prosessene selv, Men du unngår ikke å unnvike noen Steam begrensninger på denne måten, det er helt forskjellige formål.

---

### Hva er betydningen av status når du innløser en nøkkel?

Statusen angir hvordan innløsningsforsøk har gått ut. Det finnes mange ulike statuser som er mulig, de fleste er:

| Status:                 | Beskrivelse                                                                                                                                                                                                    |
| ----------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| NoDetaljene             | "OK" status som viser suksess - nøkkelen ble satt på nytt.                                                                                                                                                     |
| Tidsavbrudd             | Steam-nettverk svarte ikke på gitt tid, vi vet ikke om nøkkelen ble innløst, eller ikke (mest sannsynlig var det, men du kan prøve igjen).                                                                     |
| Badaktiveringskode      | Den oppgitte nøkkelen er ugyldig (ikke gjenkjent som en gyldig nøkkel av Steam-nettverk).                                                                                                                      |
| Duplikataktiveringskode | Den oppgitte nøkkelen ble allerede innløst fra en annen konto, eller trukket tilbake av utvikler/utgiver.                                                                                                      |
| Allerede Kjøpt          | Kontoen din eier allerede `pakkeID` som er koblet til denne nøkkelen. Husk at dette ikke indikerer om nøkkelen er `DuplicateActivationCode` eller ikke - kun at den er gyldig og ikke brukes i dette forsøket. |
| Begrenset Land          | Dette er regionlåst nøkkel, og kontoen din er ikke i det gyldige området som har tillatelse til å innløse det.                                                                                                 |
| DoesNotOwnRequiredApp   | Du kan ikke løse inn nøkkelen mens du mangler en annen app - det meste basespillet når du prøver å løse inn DLC pakken.                                                                                        |
| Frekvensbegrenset       | Du har gjort for mange innløsningsforsøk og kontoen din er midlertidig blokkert. Prøv igjen om en time.                                                                                                        |

---

### Er du tilknyttet en oppgavelapp/innsats tjeneste?

**No**. ASF er ikke knyttet til en tjeneste og alle slike krav er mangelfulle. Steam-kontoen din er din og du kan bruke kontoen din på hvilken som helst måte du ønsker, men ventilen som tydelig er oppgitt i **[offisiell ToS](https://store.steampowered.com/subscriber_agreement)**:

> Du er ansvarlig for konfidensialiteten av ditt brukernavn og passord og for sikkerheten til ditt datasystem. Venve er ikke ansvarlig for bruk av passord og konto eller all kommunikasjon og aktivitet på Steam på grunn av bruk av ditt brukernavn og passord hos deg, eller av enhver person som du med hensikt eller av uaktsomhet har forvist din pålogging og/eller passord i strid med denne fortrolighetsbestemmelsen.

ASF er lisensiert på liberal Apache 2.0 License, som gir andre utviklere mulighet til å integrere ASF ytterligere med egne prosjekter og tjenester lovlig. Slike tredjepartsprosjekter som benytter ASF er imidlertid ikke garantert å være sikre, gjennomgått, relevante eller juridiske i henhold til **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Hvis du vil vite vår mening, **oppfordrer vi deg på det sterkeste til å IKKE dele informasjon om din konto med tredjepartstjenester**. Dersom en slik tjeneste viser seg å være en **typisk svindel**, vil du bli forlatt alene med problemet. mest sannsynlig uten Steam-kontoen din og ASF vil ikke ta noe ansvar for at tredjeparts tjenester hevder å være sikker og sikker, fordi ASF-teamet ikke autoriserte verken noe av disse. Med andre ord, **bruker du dem med din egen risiko, mot vårt forslag gjort over**.

I tillegg til den offisielle **[fastslår Steam ToS](https://store.steampowered.com/subscriber_agreement)** tydelig at:

> Du kan ikke åpene, dele eller ellers tillate andre å bruke passord eller konto, unntatt som ellers spesifikt godkjent av Radiatortermostat.

Det er din konto og ditt valg. Bare si at ingen advarte deg. ASF som program møter alle regler som er nevnt over, da du ikke deler detaljene dine med noen, og du bruker programmet for din egen personlige bruk, men alle andre "oppgavelappsdriftstjenester" krever fra deg dine kontoopplysninger, slik at den også bryter regelen ovenfor (faktisk flere av dem). Som med **[tilbyr vi](https://store.steampowered.com/subscriber_agreement)** evaluering, vi tilbyr ikke noe juridisk råd, og du må selv bestemme om du ønsker å bruke disse tjenestene, eller ikke - i henhold til oss **bryter det direkte med [Steam ToS](https://store.steampowered.com/subscriber_agreement)** og kan medføre suspensjon hvis Radiatortermostat finner ut. Like pointed out above, **we strongly recommend to NOT use any of such services**.

---

## Problemer

---

### Et av partiene mine har kjøpt i mer enn 10 timer nå, men jeg fikk fortsatt ingen kort fra den!

Årsaken til det kan være knyttet til kjent Steam, noe som skjer når du har to lisenser for samme spill, hvor en av dem slipper kortet begrenset. Dette skjer vanligvis når du aktiverer spill gratis under en massegiveaway på Steam, og deretter aktiver en nøkkel for samme spill (men uten begrensninger), e. fra en betalt pakke. Hvis en slik situasjon inntreffer, rapporterer Steam på distinksjonssiden om at spillet fortsatt har oppgavelapper å falle, men uansett hvor mye du spiller spillet - oppgavelappene vil aldri slippe på grunn av gratis lisens på kontoen din. Siden det ikke er et ASF-problem, men en Steam en, kan vi ikke omgå den på ASFs side og du må løse den selv.

Det er to måter å løse spørsmålet på. For det første kan du svarteliste dette spillet i ASF, enten med `fbadd` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** eller med `svarteliste` **[konfigurasjons egenskap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Dette forhindrer ASF fra å prøve ut i gårdskort fra dette spillet, men vil ikke løse det underliggende problemet som hindrer deg i å hente kortslipp fra det aktuelle spillet. For det andre: Du kan bruke Steam-støtte selvbetjeningsverktøy for å fjerne gratis lisens fra kontoen din, og la det kun stå i full lisens som inkluderer kortslippene. For å gjøre det, Først besøk din **[lisenser og produktviktige aktiveringer](https://store.steampowered.com/account/licenses)** siden og lokaliser både gratis og betalt lisens for det aktuelle spillet. Det er vanligvis ganske enkelt - begge har lignende navn, men gratis har "begrenset gratis pakke" eller annen "promo" i lisensnavnet, pluss "komplimentær" i "anskaffelsesmetode" feltet. Noen ganger er det kanskje mer lurt, for eksempel hvis gratispakken var i en pakke og har et annet navn. Hvis du har funnet to lisenser som den - er det virkelig problemet, beskrevet her. og du kan trygt fjerne fri lisens uten å miste spillet.

In order to remove the free license from your account, visit **[Steam support page](https://help.steampowered.com/wizard/HelpWithGame)** and put the affected game name into the search field, the game should be available in "products" section, click on it. Alternativt kan du bare bruke `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` link og erstatt `<appID>` med appID for spillet som forårsaker feil. Etterpå vil du klikke på "Jeg ønsker å permanent fjerne dette spillet fra kontoen min og deretter velge den feilaktige lisensen som du har funnet ovenfor, vanligvis den med "begrenset gratis pakke" i navnet (eller lignende). Etter fjerning av fri lisens, bør ASF kunne slippe oppgavelapper fra det berørte spillet uten problemer, du skal starte jordbruksoperasjonen på nytt etter fjerningen for å være sikker på at Steam henter opp en riktig lisens denne gangen.

---

### ASF oppdager ikke spill `X` som tilgjengelig for gårdbruk, men vet jeg at den inkluderer Steam trading cards!

Det er to grunner til dette. Først og fremst er det faktum at du refererer til **Steam store** hvor spillet er annonsert som kort slippes et. Dette er **feil** antagelse, siden det rett og slett sier at spillet **har** kortdråper inkludert men ikke nødvendigvis denne funksjonen for det spillet er **aktivert** umiddelbart. Du kan lese mer om dette i **[offisiell kunngjøring](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**.

Kort og godt, kortslipp ikonet i Steam butikken betyr ikke noe. sjekk **[distinksjonsidene](https://steamcommunity.com/my/badges)** for bekreftelse på om et spill har kortdråper aktivert eller ikke - dette er også hva ASF gjør. Hvis spillet ditt ikke vises på listen som et spill med kort mulig å droppe så er dette spillet **ikke** som er mulig å dyrke, uansett årsak.

Andre sak er mindre åpenbare, og det er situasjonen når du kan se at spillet ditt er tilgjengelig med kortdråper på din distinksjonside, Samtidig blir det ikke dyrket av ASF med en gang. Med mindre du treffer en annen feil, slik som ASF ikke kan sjekke merkesidene (beskrevet nedenfor), det er rett og slett en cache effekt på Steam siden ASF fortsatt rapporterer på utdaterte emblemer. Dette problemet bør løse seg selv før eller senere, når cachen blir ugyldig. Det er heller ingen måte å fikse dette på vår side.

Selvsagt antar at du har ASF som standard uberørt innstillinger, siden du også kan legge dette spillet til i svartelisten, bruk valgte `FarmingPreferences` som `FarmPriorityQueueOnly` eller `SkipRefundableGames`, og så videre.

---

### Hvorfor spilltid av spill oppdrettet gjennom ASF øker ikke?

Det gjør, men **er ikke i sanntid**. Steam registrerer spilltiden din i faste intervaller og tidsplaner for den, men du er ikke garantert å få den oppdatert umiddelbart øyeblikket du fjerner økten, la deg alene under da. Selv om spilltiden ikke er oppdatert i sanntid betyr ikke det at den ikke er registrert, oppdateres vanligvis hvert 30. minutt.

---

### Hva er forskjellen mellom en advarsel og en feil i loggen?

ASF skriver i sin logg en haug med informasjon om ulike loggelister. Vårt mål er å forklare **nettopp** hva ASF gjør, blant annet hva Steam-spørsmål den må forholde seg til, eller andre problemer å løse. Det meste av tiden er ikke alt relevant, Derfor har vi to store nivåer i ASF når det gjelder problemer - et varslingsnivå og feilnivå.

Generell ASF-regel er at advarsler er **ikke** feiler, og de bør derfor rapporteres **ikke**. En advarsel er en indikator for deg på at noe potensielt ikke ville skje. Uansett om den ikke reagerte, API ved å kaste feil eller nettverkstilkoblingen din er nede - det er en advarsel, – og det betyr at vi forventet at det skal skje, så ikke brer ASF-utviklingen med den. Selvfølgelig står du fritt til å spørre om dem eller få hjelp ved å bruke vår kundestøtte, men man bør ikke anta at dette er ASF-feil verdt rapportering (med mindre man bekrefter noe annet).

Feil på den andre siden indikerer en situasjon som ikke skal skje, derfor er de verdt å rapportere så lenge du har sørget for at det ikke er du som forårsaker dem. Hvis det er en felles situasjon vi forventer å skje, konverteres det til en advarsel i stedet. Ellers er det en feil som burde korrigeres, ikke ignoreres stille, forutsatt at det ikke er et resultat av din egen tekniske feil. For eksempel sette ugyldig innhold i `ASF. sønn` -filen vil kaste en feil, siden ASF ikke kan analysere det, men du som putter den der, så du bør ikke rapportere at feilen til oss (med mindre du bekrefter at ASF er feil og at strukturen din faktisk er helt riktig).

I en TL;DR setning – rapport feil, ikke rapporter advarsler. Du kan fortsatt spørre om advarsler og motta hjelp i våre kundestøtteseksjoner.

---

### ASF starter ikke, programvinduet lukkes umiddelbart!

Under normale forhold vil ethvert ASF-krasj eller -avkjørsel skape en `log. xt` i programmets mappe for deg å vise, som kan brukes til å finne årsaken til det. I tillegg til at noen få siste loggfiler er arkivert i `logger` mappen, siden hovedkatalogen `for loggen. xt` -filen overskrives med hver ASF kjører.

Hvis allikevel ikke kjøretiden for .NET er i stand til å starte på maskinen din, vil ikke `log.txt` bli generert. Hvis det skjer deg så har du sannsynligvis glemt å installere .NET forutsetningene som er beskrevet i **[og på](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)** guiden. Andre vanlige problemer inkluderer forsøk på å starte feil ASF-variant for OS, eller på annen måte manglende naturlig .NET kjøretidsavhengighet. Hvis konsollvinduet lukker for raskt for å lese meldingen, åpne den uavhengige konsollen og start ASF-binærfilen derfra. For eksempel på Windows, åpne ASF-katalog, hold `Shift`, høyre-klikk inne i mappen og velg "*åpne kommandolinduet her*" (eller *powershell*), deretter skriv inn konsollen `. ArchiSteamFarm.exe` og bekreft med enter. På denne måten får du presise meldinger om at ASF ikke starter ordentlig.

Hvis det ikke er noe utdata, og du er i Windows, den vanlige årsaken til at det ikke har alle tilgjengelige Windows oppdateringer installert - forsikre deg om at du bruker det oppdaterte OS, siden vi ikke støtter ASF på Windows uten å møte denne betingelsen noen av måtene.

---

### ASF sparker min Steam-klient-økt mens jeg spiller! / *Denne kontoen er logget på en annen PC*

Dette dukker opp som en melding i Steam overlegg om at kontoen blir brukt et annet sted mens du spiller. Det kan være to ulike grunner.

En årsak er at ødelagte pakker (spill) som spesielt ikke holder en spillelås ordentlig, Like fullt regner kunden med at denne låsen er eiet. Et eksempel på en slik pakke vil være Skyrim SE. Steam-klienten lanserer spillet riktig, men at spillet ikke registrerer seg som det brukes. Som følge av dette ser ASF at det er fritt å gjenoppta prosessen, og slik den gjør det, og at sparker deg ut av Steam nettverk siden Steam plutselig oppdager at kontoen er i bruk på et annet sted.

Andre grunn kan komme opp hvis du spiller på PCen din mens ASF venter (spesielt på en annen maskin), og du mister nettverkstilkoblingen. I dette tilfellet markerer Steam-nettverket deg som frakoblet og utgivelser spillelås (som over), som utløser ASF (f.eks. på en annen maskin) i å gjenoppta bønden. Når PCen kommer tilbake på nettet, kan ikke Steam hente spillelås lenger (det er nå holdt av ASF, også lik ovenfor) og viser samme melding.

Begge årsakene på ASF-siden er faktisk veldig vanskelige å løse, siden ASF rett og slett gjenopptar oppdrett når Steam nettverk informerer om at kontoen er fri til å brukes igjen. Det er det som skjer normalt når du lukker spillet, men med ødelagte pakker kan dette skje umiddelbart, selv om spillet ditt fortsatt kjører. ASF har ingen måte å vite om du ble oppkoblet, sluttet å spille et spill eller at du fortsatt spiller et spill som ikke holder spille lås på riktig måte.

Den eneste riktige løsningen på dette problemet er automatisk satt på pause `på pause` før du begynner å spille, for å gjenoppta det med `, gjenoppta` når du er ferdig. Alternativt kan du bare ignorere problemet og gjøre det samme som hvis du spiller med offline Steam-klient.

---

### `frakoblet fra Steam!` - Jeg kan ikke opprette forbindelse med Steam-servere.

ASF har kun **prøv** for å etablere forbindelse med Steam-servere, og det er mange grunner til ikke å gjøre det, blant annet manglende internettforbindelse, Steam går ned, din brannmurblokkeringsforbindelse, tredjepartsverktøy, feil konfigurerte ruter eller midlertidige feil. Du kan aktivere `Feilsøk` modus for å sjekke ut mer detaljert logg som sier eksakte feilårsaker, Selv om det vanligvis bare er forårsaket av dine egne handlinger, som å bruke "CS:GO MM Server Picker" som svarteliste mange Steam IPer og gjøre det veldig vanskelig for deg å nå Steam nettverket.

ASF vil gjøre sitt beste for å opprette forbindelse, som inkluderer ikke bare spør om den oppdaterte listen over servere, men også å prøve en annen IP når siste mislykkes, så hvis det virkelig er et midlertidig problem med en bestemt server eller rute, vil ASF koble til før eller senere. Men hvis du er bak en brannmur eller på en annen måte ikke kan nå Steam-servere, da trenger du åpenbart å fikse deg selv ved potensielt hjelp av `Debug` -modus.

Det er også mulig at maskinen din ikke kan opprette forbindelse til Steam-servere ved hjelp av standardprotokoll i ASF. Du kan endre protokoller at ASF er tillatt å bruke ved å endre `SteamProtocols` globale konfigurasjonsegenskaper. For eksempel hvis du har problemer med å nå Steam med `UDP` protokollen (f.eks. På grunn av brannmurer, vil du kanskje ha mer lykke med `TCP` eller `WebSocket`.

Situasjonen ved at en har feil servere blir cachet svært usannsynlig, for eksempel på grunn av flytting av ASF `config` mappe fra én maskin til en annen maskin plassert i helt forskjellige land, slette `ASF. b` for å oppdatere Steam-servere på neste start kan hjelpe deg. Veldig ofte er det ikke nødvendig og må ikke gjøres da denne listen oppdateres automatisk ved første lansering. I tillegg til når tilkoblingen er etablert - nevner vi bare det som en måte å rense alt i forbindelse med listen over Steam-servere bufret av ASF.

---

### `kan ikke logge inn på Steam: TryAnotherCM/Invalid`, `ServiceUtilgjengelig/ugyldig`

I likhet med ovenfor, er serveren du har koblet til med, utilgjengelig. Vanligvis skjer under Steam vedlikeholdsvindu, det er ikke noe du kan gjøre med dette. ASF vil automatisk prøve med en annen server til det skjer med din forespørsel. Det bør ikke vare lenger enn en time maksimum.

---

### `Kunne ikke hente informasjon om emblemer, vil prøve igjen senere!`

Vanligvis betyr det at du bruker Steam foreldrekode for å få tilgang til kontoen din, men du glemte å sette den i ASF konfigurasjon. Du må angi gyldig PIN-kode i `SteamParentalCode` bot config property, ellers vil ASF ikke kunne få tilgang til mesteparten av web-innholdet, derfor vil ikke kunne fungere skikkelig. Gå til **[sin konfigurasjon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** for å lære mer om `SteamParentalCode`.

Andre grunner er blant annet midlertidig Steam-problem, nettverksproblem eller lignende. Hvis problemet ikke løser seg etter flere timer og du er sikker på at du har konfigurert ASF på en riktig måte, kan du gjerne fortelle oss om det.

---

### ASF mislykkes med `Forespørsel feilet etter 5 forsøk` feil!

Vanligvis betyr det at du bruker Steam foreldrekode for å få tilgang til kontoen din, men du glemte å sette den i ASF konfigurasjon. Du må angi gyldig PIN-kode i `SteamParentalCode` bot config property, ellers vil ASF ikke kunne få tilgang til mesteparten av web-innholdet, derfor vil ikke kunne fungere skikkelig. Gå til **[sin konfigurasjon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** for å lære mer om `SteamParentalCode`.

Hvis foreldrePIN-koden ikke er årsaken, er dette en den vanligste feilen, og du bør brukes til det, det betyr rett og slett at ASF sendte en forespørsel til Steam Network, og ikke fikk et gyldig svar, 5 ganger på rad. Vanligvis betyr det at Steam enten er nede eller har vanskeligheter med eller vedlikehold – ASF er klar over slike problemer og du bør ikke bekymre deg for dem, med mindre de kommer konstant lenger enn flere timer, og andre brukere har ikke slike problemer.

Hvordan sjekker du om Steam er ute av gang? **[Steam-status](https://steamstat.us)** er en utmerket kilde til å sjekke om Steam **bør være** hvis du merker feil, spesielt relatert til samfunnet eller Web API, så har Steam vanskeligheter. Det kan hende du vil forlate ASF alene og la den gjøre jobben etter kort tid med nedadgående tid, eller slutte og vente selv.

Det er imidlertid ikke alltid tilfellet, som i noen situasjoner vil Steam-problemer kanskje ikke oppdages av Steam Status, For eksempel skjedde det ved at ventilen brøt HTTPS-støtten for Steam-Community 7. juni 2016 - ved bruk av **[SteamCommunity](https://steamcommunity.com)** gjennom HTTPS kastet en feil. Derfor er det heller ikke åpenbart å stole på Steam status, så er det best å sjekke om alt fungerer som det skulle.

I tillegg til det, inneholder Steam ulike frekvensbegrensende tiltak som midlertidig vil forby IP-en din hvis du gjør et stort antall forespørsler samtidig. ASF er klar over det og tilbyr deg flere forskjellige grensebrytere i konfigurasjonen, som du skal gjøre bruk av. Standard innstillinger ble endret basert på **sane** antall bots, hvis du bruker så stor mengde at selv Steam forteller deg at du skal gå, så takker du dem enten helt til det ikke lenger forteller deg, eller så gjør du som du har sagt. Jeg antar at en annen måte ikke er et alternativ for dere, så gå til det emnet og følg nøye med på `WebLimiterDelay` som er en generell begrenser som gjelder for alle nettforespørsler.

Det finnes ingen "gullløv" som fungerer for alle, fordi blokker er sterkt påvirket av tredjeparts faktorer, Det er derfor du må eksperimentere deg selv og finne en verdi som fungerer for deg. Du kan også ignorere hva jeg sier og bruker noe som `10000` som er garantert å fungere riktig, men prøv ikke å klage på hvordan din ASF reagerer på alt på 10 sekunder og hvordan distinksjon tar 5 minutter. I tillegg til det, det er helt mulig at ingen begrenser vil gjøre noe som helst fordi du har så store mengder botter at du sitter på **[hard grense](#how-many-bots-can-i-run-with-asf)** som ble nevnt ovenfor. Ja, det er helt mulig at du kan logge inn uten problemer med Steam-nettverket (klienten), men Steam web (nettside) vil nekte å høre på deg dersom du har 100 økter etablert samtidig. ASF krever både Steam-nettverk og Steam web for å være samarbeid, det tar bare en nedover for å gjøre deg problemer du ikke kommer til å gjenvinne.

Hvis ingenting hjelper og du ikke har anelse om hva som er ødelagt, du kan alltid aktivere `Debug` modus og se deg selv i ASF-loggen hvorfor nøyaktig forespørsler feiler. For eksempel:

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Forbidden <- HEAD https://steamcommunity.com/my/edit/settings
```

Se den `forbudte` koden? Dette betyr at du har blitt midlertidig utestengt for mye av forespørslene, fordi du ikke endret `WebLimiterDelay` som er riktig ennå (forutsetter at du har samme feilkode for alle andre forespørsler også). Det kan være andre grunner som er ført opp der, som `InternalServerFeil`, `TjenesteUnavailable` og timeouts som indikerer vedlikehold / problemer. Du kan alltid prøve å besøke lenken som nevnt av ASF selv, og kontrollere om den fungerer - hvis det ikke fungerer, så vet du hvorfor ASF ikke har tilgang til det heller. Dersom det gjør det, og samme feil ikke forsvinner etter en dag eller to, kan det være verdt å undersøke og rapportere.

Før du gjør det bør **forsikre deg om at feilen er verdt å rapportere på første sted**. Hvis det er nevnt i denne FAQ, for eksempel handelsrelatert problem, så er det ut. Hvis det er midlertidig problem som skjedde en eller to ganger, spesielt når nettverket ditt var ustabilt eller Steam var nede, - det er ute. Hvis du derimot kunne reprodusere problemet ditt flere ganger på rad, over 2 dager, restartet ASF så vel som maskinen din i prosessen og sørg for at det ikke er noen FAQ oppføring her for å hjelpe til med å løse det da kan det være verdt å spørre om.

---

### ASF ser ut til å fryse og ikke skrive ut noe på konsollen til jeg trykker på en nøkkel!

Du bruker sannsynligvis Windows og konsollen har aktivert QuickEdit modus. Se **[denne](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** -spørsmålet på StackOverflow for teknisk forklaring. Du bør deaktivere QuickEdit modus ved å høyreklikke på ASF-konsollvinduet, åpne egenskaper og huke av i riktig rekkefølge.

---

### ASF kan ikke akseptere eller sende handler!

Det åpenbare første - nye kontoer starter som begrenset. Inntil du låser opp konto ved å laste inn lommeboken eller ved å bruke $5 i butikken. ASF kan ikke godta verken sende trader ved å bruke denne kontoen. I dette tilfellet vil ASF opplyse at inventaret virker tomt, fordi alle kortene som er i det er ikke-handlbart.

Hvis du ikke bruker **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, Det er mulig at ASF faktisk akseptert/sendt handel, men du må bekrefte dette via din e-post. Hvis du bruker klassisk 2FA, må du også bekrefte handelen via din autentiserer. Bekreftelser er **obligatoriske** nå, så hvis du ikke vil akseptere dem av deg selv, vurder å importere autentiseringen til ASF 2FA.

Legg også merke til at du kun kan handle med dine venner, og personer med kjent handelslenke. Hvis du prøver å starte *Bot -> Mestre* handel, slik som `loot`, da må du enten ha botten din på din venneliste eller din `SteamTradeToken` erklært i botens konfigurasjon. Sørg for at tokenet er gyldig - annet, du vil ikke kunne sende en byttehandel.

Til slutt, husk at nye enheter har blitt låst med 7 dager i handel, så hvis du har lagt til kontoen din i ASF, Vent minst 7 dager – alt bør jobbe etter den perioden. Denne begrensningen inkluderer **** som godtar **og** som sender handel. Den utløser ikke, og det er personer som kan sende og ta imot trading umiddelbart. Majority of the people are affected though, and the lock **will** happen, even if you can send and accept trades through your steam client on the same machine. Bare vent tålmodig, det er ikke noe du kan gjøre for å gjøre det raskere. På samme måte kan du få en lignende lås for fjerning/bytte av diverse Steam-sikkerhetsrelaterte innstillinger, for eksempel 2FA, SteamGuard, passord, e-post og likeså. Generelt bør du sjekke om du kan sende en handel fra den kontoen du selv har, hvis ja, akkurat sannsynlig er det klassisk 7 dager lås fra ny enhet.

Og til slutt, husk at en konto kan ha bare 5 ventende fag til en annen, så ASF vil ikke kunne sende fag hvis du allerede har 5 (eller flere) ventende handler. Dette er sjelden et problem, men det er også verdt å nevne, spesielt hvis du angir ASF for å automatisk sende handler, enda du ikke bruker ASF 2FA og glemte å bekrefte dem.

Hvis ingenting hjalp, kan du alltid aktivere `Debug` -modusen og sjekk hvorfor forespørsler feiler. Vær oppmerksom på at Steam snakker useriøst i det meste av tiden, og grunnen gir kanskje ikke noen logisk betydning, eller så er det helt feil - hvis du bestemmer deg for å tolke denne grunnen, må du forsikre deg om at du har god kunnskap om Steam og spørringene. Det er også ganske vanlig å se dette problemet uten noen logisk årsak, og eneste forslag til løsning i dette tilfellet er å tilføre konto på nytt til ASF (og vente 7 dager igjen). Noen ganger fikser dette problemet seg også *magisk*, på samme måte som det knuser. Vanligvis er det enten 7 dager handelslås, midlertidig dampproblem, eller begge deler. Det er best å gi det noen dager før du manuelt sjekker hva som er galt, med mindre du har lyst til å feilsøke den virkelige saken (og vil vanligvis bli tvunget til å vente uansett, Feilmelding vil ikke gi noen mening og heller ikke hjelpe deg i det minste sett).

I alle tilfeller kan ASF bare **prøv** for å sende en riktig forespørsel til Steam for å godta/sende handel. Om Steam godtar den forespørselen, eller ikke, faller utenfor virkeområdet til ASF, og ASF vil ikke magisk gjøre den fungerer. Det er ingen bug knyttet til den funksjonen, og det er heller ikke noe å forbedre fordi logikk skjer utenfor ASF. Du må derfor ikke be om å fikse ting som ikke er ødelagt, og spør heller ikke hvorfor ASF ikke kan godta eller sende handler - **Jeg vet ikke, og ASF vet ikke hverken**. Enten gjør noe med det, eller reparer deg selv, hvis du vet det bedre.

---

### Hvorfor må jeg legge inn 2FA/SteamGuard koden på hver innlogging? / *Fjernet utløpte innloggingsnøkkel*

ASF bruker innloggingsnøkler (hvis du holdt `UseLoginKeys` aktivert) for å beholde legitimasjon gyldig, samme mekanisme som Steam bruker - 2FA/SteamGuard token er kun nødvendig én gang. Men på grunn av Steam nettverksproblemer og spørringer, er det helt mulig at innloggingsnøkkel ikke er lagret i nettverket, vi har allerede sett slike problemer ikke bare med ASF, men med vanlig dampklient også (et behov for å skrive inn innloggings-+ passord ved hver kjøring, uavhengig av "husk meg"-alternativ).

Du kan fjerne `BotName.db` og `BotName. i` (hvis tilgjengelig) av en berørt konto og prøv å koble ASF til kontoen en gang til, men det vil sannsynligvis ikke gjøre noe. Noen brukere har rapportert at **[ikke autoriserer alle enheter](https://store.steampowered.com/twofactor/manage)** på Steam-siden til å hjelpe, ved å endre passord gjør det samme. Men de er kun bekymret for at de ikke engang er garantert i arbeid. den virkelige ASF-baserte løsningen er å importere din autentifikator som **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** - på denne måten ASF kan generere tokens automatisk når de er nødvendig, og du trenger ikke legge inn dem manuelt. Vanligvis løser problemet seg på magisk måte etter en stund, så du kan bare vente på det å skje. Selvfølgelig kan du også spørre Radiatortermostat om løsning, fordi jeg ikke kan tvinge Steam-nettverk til å godta innloggingstastene våre.

Som side du kan også slå av innloggingsnøkler med `UseLoginKeys` config property satt til `false`, men dette vil ikke løse problemet, bare hoppe over den innledende innloggingsnøkkelfeilen. ASF er allerede klar over problemet som er forklart her og vil prøve det beste ikke bruke innloggingsnøkler hvis det kan garantere seg selv alle påloggingslegitimasjoner, så det er ikke nødvendig å justere `UseLoginKeys` manuelt hvis du kan oppgi alle innloggingsdetaljer sammen med ASF 2FA.

---

### Jeg får feil: *Kan ikke logge inn på Steam: `Invalidpassord` eller `RateLimitExceeded`*

Det kan bety mye av dem, noen av dem omfatter:

- Ugyldig innlogging/passordkombinasjon (åpenbart)
- Utløpt innloggingsnøkkel som brukes av ASF for innlogging
- For mange mislykkede påloggingsforsøk på kort tid (anti-brutestyrke)
- For mange påloggingsforsøk på kort tid (frekvensbegrensning)
- Krav om fastklemming for å logge inn (mest sannsynlig forårsaket av to grunner ovenfor)
- Eventuelle andre grunner til Steam-nettverk kan ha forhindret deg i å logge inn

Når det gjelder anti-brutekraft og hastighetsbegrensning, forsvinner problemet etter en stund, så bare vent og ikke prøver å logge inn i mellomtiden. Hvis du treffer dette problemet hyppig, kanskje er det klokt å øke `LoginLimiterDelay` config property of ASF. Overdreven oppstart av programmet og andre tilsiktede innloggingsforespørsler vil definitivt ikke hjelpe med det problemet, så prøv å unngå det hvis mulig.

Ved utløpt innloggingsnøkkel - ASF vil gamle fjerne en og be om ny ved neste innlogging (som vil kreve fra deg å ha 2FA token hvis kontoen er 2FA-beskyttet. Hvis kontoen din bruker ASF 2FA, vil token bli generert og brukt automatisk). Dette kan skje naturlig over tid, men hvis du får dette problemet ved hver innlogging, det er mulig at Steam av en eller annen grunn bestemte seg for å ignorere lagerforespørsler i innloggingen, som nevnt i utgaven **[over](#why-do-i-have-to-put-2fasteamguard-code-on-each-login--removed-expired-login-key)**. Du kan selvfølgelig deaktivere `Bruktsnøkler` fullstendig, men som ikke løser problemet, bare unngå å fjerne utløpte innloggingsnøkler hver gang. Realløsningen, som i forhold til det ovenfor, er å bruke ASF 2FA.

Og sist, hvis du brukte feil brukernavn og passord kombinasjon, helt klart at du må korrigere dette. eller deaktiver bot som prøver å koble til med disse legitimasjonene. ASF kan ikke gjette seg selv om `Invalidpassord` betyr ugyldige legitimasjoner, eller noen av grunnene ovenfor vil derfor fortsette å prøve til det lykkes.

Husk at ASF har et eget innebygd system for å reagere slik at steam rykninger virker, Til slutt vil den koble til og fortsette sin jobb, og det er derfor ikke nødvendig å gjøre noe hvis problemet er midlertidig. Omstart av ASF for magisk å fikse problemer vil bare gjøre ting verre (siden ny ASF ikke vet tidligere ASF-tilstand om ikke å kunne logge inn, og prøv å koble til i stedet for venting), så unngå å gjøre det, med mindre du vet hva du gjør.

Endelig kan som for hver Steam-forespørsel - ASF kun **prøve** for å logge inn med dine oppgitte legitimasjon. Om en anmodning vil lykkes eller ikke er utenfor virkeområdet og logikken til ASF - det finnes ingen feil, og ingenting kan fikses og ikke forbedres her.

---

### Jeg kan ikke fylle inn innloggingsdetaljer som ASF ber om
### `System.Invalideringuttak: Kan ikke lese nøkler når programmet enten ikke har en konsoll eller når konsoll inngang er omdirigert`
### `System.IOException: Innløp/ut-feil`
### `RequestInput() input er ugyldig!`

Dersom denne feilen skjedde under ASF inngang (f.eks. du kan se `GetUserInput()` i stacktracen) og dermed skyldes det miljø som forbyr ASF fra å lese standard inngang av din konsoll. Det kan oppstå på grunn av mange årsaker, men den vanligste er at du kjører ASF i feil miljø (f.eks. i `system d`, `ingenhup` eller `&` bakgrunn i stedet for e. . `skjerm` på Linux). Hvis ASF ikke får tilgang til standardinnspillet, vil du se denne feilen logget og ASFs manglende mulighet til å bruke detaljene dine under kjøring.

Normalt skal du korrigere det ovennevnte problemet, dvs. tillate at ASF får tilgang til standard innsats, slik at du kan oppgi detaljene. Hvis du **forventer at** likevel dette skjer, så du **har tenkt at** skal kjøre ASF i input-less environment, deretter bør du uttrykkelig fortelle ASF at det er tilfellet. ved angivelse av **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** modus godt. Dette vil fortelle ASF aldri å be om brukerinndata under noen omstendigheter, slik at du kan kjøre ASF i input-less environments på en sikker måte. Du kan svare på valgte ledetekster med andre midler i denne modus, for eksempel i ASF-ui.

---

### `System.Net.Http.WinHttpException: En sikkerhetsfeil oppstod`

Denne feilen skjer når ASF ikke kan etablere sikker forbindelse med gitt server, nesten utelukkende på grunn av SSL-sertifikatfeil.

I nesten alle tilfeller skyldes denne feilen **feil dato / tid på maskinen**. Hver SSL-sertifikat har utgått dato og utløpsdato. Hvis datoen er ugyldig og av de to grensene kan sertifikatet ikke klareres på grunn av en potensiell **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)** angrep og ASF nekter å gjøre en forbindelse.

Observerte løsninger er å angi datoen for din maskin på riktig måte. Det er sterkt anbefalt å bruke automatisk datosynkronisering, som naturlig synkronisering tilgjengelig i Windows, eller `ntpd` i Linux.

Hvis du har sørget for at datoen på maskinen er passende og feilen ikke ønsker å forsvinne. SSL-sertifikater som systemet truster kan være utdaterte eller ugyldige. I så fall bør du sørge for at maskinen din kan opprette sikre tilkoblinger, for eksempel ved å sjekke om du kan få tilgang til `https://github. om` med alle nettlesere du velger, eller CLI-verktøy som `curl`. Dersom du bekrefter at dette fungerer ordentlig, kan du gjerne be oss om støtte.

---

### `System.Threading.Tasks.TaskCanceledException: En oppgave ble avbrutt`

Denne advarselen innebærer at Steam ikke svarte på ASF-forespørsel i tide. Vanligvis forårsakes Steam-nettverket, og påvirker ikke ASF på noen måte. I andre tilfeller er det det samme som at forespørselen mislykkes etter 5 turer. Rapportering av dette problemet er ikke det meste av tiden, da vi ikke kan tvinge Steam til å svare på våre forespørsler.

---

### `Type initialiserer for 'System.Security.Cryptography.CngKeyLite' kastet et unntak`

Dette problemet er nesten utelukkende forårsaket av deaktivert/stoppet `CNG Key Isolation` Windows service. som tilbyr kryptografiske kjernefunksjoner for ASF, uten at programmet ikke er i stand til å kjøre. Du kan fikse dette problemet ved å starte `tjenester. sc` og sørge for at `CNG nøkkelisolasjon` ikke har deaktivert oppstart og kjører for øyeblikket.

---

### ASF blir oppdaget som en skadelig programvare av mitt antivirus! Hva skjer?

**Sørg for at du lastet ned ASF fra klarert kilde**. Den eneste offisielle og pålitelige kilden er **[ASF-utgivelser](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** side på GitHub (og dette er også kilden for ASF auto-oppdateringer) - **all annen kilde er ikke klarert av definisjonen og kan inneholde skadelig programvare lagt til av andre personer** - du skal ikke stole på andre nedlastingssteder, Kontroller at ASF alltid kommer fra oss.

Hvis du bekreftet at ASF er lastet ned fra klarerte kilder, er det svært sannsynlig at det er en falsk positiv. Denne **skjedde tidligere**, **skjer akkurat nå**, og **vil skje i fremtiden**. Hvis du er bekymret for den faktiske sikkerheten ved bruk av ASF, foreslår jeg at ASF skannes med mange forskjellige AVs for faktisk deteksjonsratio, for eksempel gjennom **[VirusTotal](https://www.virustotal.com)** (eller annen webtjeneste ditt som denne).

If the AV that you're using falsely detects ASF as a malware, then **it's a good idea to send this file sample back to developers of your AV, so they can analyze it and improve their detection engine**, as clearly it's not working as good as you think it does. Det er ingen problem i ASF-kode, og det er heller ikke noe å fikse for oss, siden vi ikke distribuerer skadelig programvare første sted, Derfor gir det ikke mening å rapportere falske-positiver til oss. Vi anbefaler på det varmeste å sende ASF-prøve for videre analyse, slik som angitt ovenfor, men hvis du ikke ønsker å forstyrre dem. da kan du alltid legge til ASF til noen typer AV-unntak, deaktivere AV-en eller bruke et annet. Likevel er vi vant til at AVs er dum. Dette skjer som hver og mens noen AV oppdager ASF som et virus, som vanligvis varer veldig kort og blir raskt patchet opp på en fortøyning, men som vi oppdaget ovenfor - **skjedde det**, **skjer alltid** og **vil skje** hele tiden. ASF mangler en ondsinnet kode, du kan gå gjennom ASF-kode og selv kompilere fra kilden selv. Vi er ikke hackere for å obfuskere ASF-kode for å skjule dem for AV-heuristikk og falske positive, Vi regner altså ikke med å rette opp hva som ikke er brutt - det finnes ingen "virus" for at vi skal fikse.