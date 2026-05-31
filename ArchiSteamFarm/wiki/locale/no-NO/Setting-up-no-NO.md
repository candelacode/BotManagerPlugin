# Definer

Kom hit for første gang du kom deg vel! We're very happy to see yet another traveler that is interested in our project, although bear in mind that with great power comes great responsibility - ASF is capable of doing a lot of different Steam-related tasks, but only as long as you **care enough to learn how to use it**. Faktisk lesing wiki, Ved å følge våre retningslinjer og lære mer om ulike ASF-konsepter vil du til slutt belønne deg med unike ferdigheter for å bruke et av de kraftigste Steam-verktøyene som finnes i dag.

Vi anbefaler deg å gjøre **en ting av gangen**. ASF berører mye forskjellige aspekter, noen av dem er ganske trihetteglass, andre kan være for komplisert. Du trenger ikke å forstå eller lese om alt på én gang, og vi anbefaler faktisk at du tar det enkelt. Avslapp. Velg deg selv en drikke av valgt, Sett inn en time på din tid og dykk inn i vårt foredrag - vi kan love at det vil være bra verdt din tid.

La oss starte fra grunnleggende - ASF er en konsoll app i prinsippet. noe som betyr at det ikke automatisk vil spawne et grafisk grensesnitt som du er generelt brukt. ASF er en universell app som hovedsakelig fungerer som en tjeneste (daemon), og ikke en skrivebordsapp. Én av sine viktigste brukstilfeller antar å kjøre på servermaskinene, som skrivebordsapper er helt uegnet for. Det behandler bare den absolutte kjernen av programmet, selv Fordi ASF faktisk **inkluderer** sitt eget grafiske grensesnitt - i form av det innebygde ASF-ui frontenden, men vi kommer ned til den delen innen rimelig tid - vi nevner bare dette med en gang, slik at du ikke får panikk når du ser solkremen på sort skjerm.

Når du får frem ASF-binære filer, vil programmet kreve konfigurasjoner fra deg som angir hva du forventer at ASF skal oppnå. Du kan starte programmet uten konfigurasjon, i dette tilfellet vil ASF starte i standardinnstillinger, slik at du kan bruke e. . ASF-ui for den første konfigurasjonen, men annet enn at den ikke vil gjøre mye uten din tidligere handling.

Det vil gjøre nå, la oss begynne!

---

## OS-spesifikt oppsett

Generelt sett er det dette vi skal gjøre i løpet av de neste minuttene:
- Vi skal installere **[.NET forutsetningene](#net-prerequisites)**.
- Deretter laster vi ned **[siste ASF-utgivelse](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** i riktig OS-spesifikk variant.
- Neste steg ut av arkivet til ny plassering.
- Then we'll **[configure ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- Og til slutt vil vi starte ASF og se på magien.

Noen av trinnene er selvforklarende, det andre vil kreve mer oppmerksomhet fra deg. Ikke bekymre deg, vi har deg dekket.

---

### .NET forutsetninger

Første steg er å påse at ditt OS kan til og med starte ASF riktig. Du trenger ikke vite det, men ASF er skrevet i C#, basert på . ET-plattform og kan kreve innebygde biblioteker som ikke er tilgjengelige på plattformen din ennå. Tenk på det som DirectX for 3D-spillene eller motoren for å starte bilen din.

Avhengig av om du bruker Windows, Linux eller macOS vil du ha forskjellige krav. Referansedokumentet er **[. ET forutsetter](https://docs.microsoft.com/dotnet/core/install)**, men for enkelhets skyld har vi også detaljert alle nødvendige pakker nedenfor, så du ikke trenger å lese den i det hele tatt, med mindre du løper inn i problemer, eller du har flere spørsmål.

Det er helt normalt at noen (eller til og med alle) avhengigheter allerede eksisterer på grunn av at du er installert av tredjeparts programvare som du bruker. Det trenger likevel ikke å være tilfellet. så du bør kjøre riktig installasjonsprogram for ditt OS - uten disse avhengighetene ASF vil ikke starte i det hele tatt, og du får knapt all nyttig informasjon for å fortelle deg hva som er feil.

Husk at du ikke trenger å gjøre noe annet for OS-spesifikke bygg, og da spesielt installere . ET SDK eller til og med kjøretid, siden OS-spesifikk pakke inneholder alt dette allerede. Dere trenger bare .NET forutsetninger (avhengigheter) for å kjøre . ET kjøretid som er inkludert i ASF - så det er kun tingene vi angir nedenfor, uten andre tillegg.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributerbar oppdatering](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** for 64-bit, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** for 32-bit eller **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** for 64-bit ARM)
- Det er sterkt anbefalt å sikre at alle Windows-oppdateringer er allerede installert. Hvis du ikke har dem aktivert, deretter den minste du trenger **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** og **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, Det kan være behov for flere oppdateringer. Du trenger ikke bekymre deg for at hvis Windows er oppdatert, eller i det minste nylig nok.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Pakkenavnene avhenger av Linux distribusjonen du bruker, vi har listet de vanligste. Du kan få alle med innebygd pakkebehandler for ditt OS (for eksempel `kjapt` for Debian eller `yum` for senter). De er fine standardbiblioteker som skal være tilgjengelige uansett hvilken distribusjon du bruker. det er bare snakk om å finne ut hvordan de er kalt i ditt valgmiljø.

- `ca-certificates` (standard klarerte SSL-sertifikater for å gjøre HTTPS-tilkoblinger)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, siste versjon for din distribusjon, for eksempel `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libsl`, `openssl-libs`, nyeste versjon for distribusjon, minst `1.1.X`)
- `libstdc+6` (`libstdc++`, i versjon `5.0` eller høyere)
- `zlib1g` (`zlib`)

Minst et flertall av disse skal allerede være naturlig tilgjengelig på systemet ditt. For eksempel krever den minimale installasjonen av Debian stabil, vanligvis bare `libicu76`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- Du trenger ikke noe spesifikt, men du bør ha den nyeste versjonen av macOS installert, minst 12.0+

---

### Laster ned

Siden vi allerede har nødvendige avhengigheter lastes neste steg ned **[siste utgave av ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF finnes i mange varianter, men du er interessert i en pakke som passer til operativsystemet og arkitekturen. For eksempel, hvis du bruker `64`- bit `Vinn`dows, så ønsker du at `ASF-win-x64` pakken. For mer informasjon om tilgjengelige varianter, besøk **[kompatibilitet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** avsnitt. ASF er også i stand til å kjøre i miljøene som vi ikke bygger OS-spesifikk pakke for, for eksempel **32-bit Windows**, men du trenger **[generisk oppsett](#generic-setup)** for det.

![Eiendeler](https://i.imgur.com/Ym2xPE5.png)

Etter nedlasting, start fra å pakke ut zip-filen til sin egen mappe. Hvis du trenger et spesifikt verktøy for det, **[7-zip](https://www.7-zip.org)** vil da men alle standardverktøy som innebygd Windows-ekstraksjon eller `unzip` fra Linux/macOS bør også fungere uten problemer.

anbefales å pakke ut ASF til **sin egen katalog,** og ikke til en eksisterende mappe du allerede bruker for noe annet - det er viktig å gjøre. ASF inkluderer auto-oppdateringer, som erstatter egne filer, og det vil vanligvis slette alle gamle og userelaterte filer ved oppgradering, som i sin tur kan føre til at du mister noe som ikke er relatert til ASF-mappen. Hvis du har ekstra skript eller filer som du vil bruke med ASF, er det ikke et problem, opprett en dedikert mappe for de da, du kan alltid legge ASF i én mappe samtidig.

Et eksempel på en struktur kan se slik ut:

```text
C:\ASF (hvor du putter dine egne ting)
    ⋅MyNotes. xt (valgfritt)
    εεεFirst, AsfMakeMeCoffeeScript.bat (valgfritt)
    ########(... (alle andre filer av ditt valg, valgfri)
    ARS Core (dedikert kun til ASF, hvor du pakker ut arkivet)
         ################ArchiSteamFarm(. xe) A)
         echten∙config
         ° F format@@6 ″log
         ⋅εPlugins
         εεwww
         ＋ ∙(...)
```

---

### Konfigurasjon

Nå er vi klare til å gjøre det siste trinnet, konfigurasjonen. ASF fungerer med konseptet "bots", hver bot er vanligvis en enkelt Steam-konto du ønsker å bruke inne i ASF. Du kan erklære så mange botter som du ønsker, men for startskuddet vil vi fokusere på bare en av dem - vanligvis din hovedkonto. ASF har også ikke-bot konfigurasjonsfiler, den viktigste er global konfigurasjonsfil som påvirker alle botene i forekomsten.

Hovedregelen for tommelen er at **hvis du ikke vet eller ikke forstår noen innstilling, du bør la den ligge med sin standardverdi uten å endre noe**. ASF tilbyr utallige måter å konfigurere, tilpasse og svake nesten alle funksjoner, men som nevnt ovenfor, prøver å forstå det med rett utslag i flaggermusen er et kaninhull som raskt kan dra deg til alvorlig forvirring, hvis ikke **[rett inn i kortene](https://www.youtube.com/watch?v=KK3KXAECte4)**. I stedet anbefaler vi å få et arbeidseksempel først, og bare begynne å grave i ekstra alternativer. ved hjelp av **[konfigurasjon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** side på wiki, under endring av **én ting ved en gang**.

ASF-konfigurasjoner kan gjøres på flere måter - gjennom vår innebygde ASF-ui frontend, en frittstående konfigurasjonsgenerator for enkeltstående web, eller manuelt. Dette er forklart inngående i **[konfigurasjonen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** avsnitt, så referer til det hvis du vil ha mer detaljert informasjon. Vi vil bruke frittstående konfigurasjonsgenerator som startpunkt fordi det fungerer selv om ASF-ui av en eller annen grunn ikke starter eller fungerer riktig.

Gå til vår **[konfigurasjonsgenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** side med din favorittnettleser. Vi anbefaler Chrome eller Firefox, men det bør ikke ha så lenge nettleseren din fungerer for alt annet.

Etter at siden er åpnet, bytt til "Bot"-fanen. Nå skal du få se en side tilsvarende den som er nedenfor:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Hvis denne versjonen av ASF som du nettopp har lastet ned er eldre enn hva konfigurasjonsgeneratoren er satt til å bruke som standard, Velg kun din ASF versjon fra nedtrekksmenyen. Dette kan (sjelden) skje, siden konfigurasjonsgeneratoren kan brukes for generering av konfigurasjoner til nyere (forhånds-utgivelse) ASF-versjoner som ikke var merket som stabil ennå. Du har lastet ned siste stabile utgivelse av ASF som er bekreftet for å fungere pålitelig, Derfor kan den være litt eldre enn den absolutte skjærekantversjonen, som er fullstendig ikke egnet for førstegangsbruk.

Start fra **sette navn for din bot** inn i feltet som er uthevet som rødt, kalt `Name`. Dette kan være hvilket som helst navn du vil bruke, slik som ditt kallenavn, kontonavn, et nummer eller noe annet. Det er bare ett ord du ikke kan bruke, `ASF`, siden nøkkelordet er reservert for den globale konfigurasjonsfilen. I tillegg til at botten ikke kan starte med et punktum (ASF med vilje ignorerer disse filene). Vi anbefaler også at du unngår å bruke lokaler, du kan bruke `_` som et ordskille om nødvendig - ikke et strengt krav, men du har hard tid med ASF-kommandoer ellers.

Bot-navn bestemt? Flott, i neste trinn, **change `Aktivert` bytte for å være på**, man definerer om botten din skal startes med ASF automatisk etter oppstart (av programmet). Ikke gjør det som vil føre til at ASF blir slått av som boten din er deaktivert i konfigurasjonsfilen, og det venter på at du setter i gang det, som ikke er det vi ønsker å gjøre i dette eksemplet.

Nå er det to følsomme egenskaper som kommer neste: `SteamLogin` og `SteamPassword`. Du kan ta en annen beslutning her - du kan enten ta Steam innloggingsdetaljene i disse to egenskapene, eller du kan avgjøre om du vil gjøre det, og la dem være tomme.

ASF krever påloggingsinformasjon fordi den inkluderer en egen implementasjon av Steam-klient og trenger samme detaljer for å logge inn som den du bruker selv. Innloggingsopplysningene dine lagres ikke hvor som helst, men på PC'en din i ASF `config` mappen, (kun når du laster ned den genererte konfigurasjonen). Vår konfigurasjonsgenerator er klientbasert applikasjon, noe som betyr at alt du gjør innenfor vår frittstående web-config-generator-nettside kjører lokalt i nettleseren din for å generere gyldige ASF-konfigurasjoner, uten detaljer om hvordan du forlater PCen din på første sted, så det er ikke nødvendig å bekymre deg for eventuell sensitiv datalekkasje. Men hvis du av hvilken som helst grunn ikke vil sette legitimasjon der, forstår vi det, og du kan legge dem manuelt senere i genererte filer, eller utelate dem helt og operere uten dem.

Hvis du bestemmer deg for å logge inn legitimasjon, ASF vil kunne logge inn automatisk under oppstart, som sammen med valgfri 2FA faktisk vil la deg bare dobbeltklikke på programmet for å gjennomføre alt. Hvis du bestemmer deg for å utelate dem, så ASF vil **be deg** om å legge inn disse detaljene når det trengs - den tilnærmingen vil ikke lagre dem hvor som helst, Men naturlig ASF vil ikke være i stand til å operere uten hjelp. Det er opp til deg hvilken måte du foretrekker mer, og du kan også finne tilleggsinformasjon i **[konfigurasjonen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** som vanlig.

Som et sidenotat kan du også velge å la bare ett felt stå tomt, slik som `SteamPassword`. ASF vil da kunne bruke din innlogging automatisk, men vil fortsatt be om passord ved behov (ligner på Steam Client). Hvis du på noen måte bruker en 4-sifret foreldrenål for å låse opp kontoen din vi anbefaler også å putte den inne i `SteamParentalPin` -boksen. Selv om også i denne saken kan dere bare la dette tomt, og i stedet observere hvor svak beskyttelsen er, fordi ASF også kan "risse" det i løpet av bare sekunder etter innlogging. Oops.

Etter å ha brukt alt ovenfor, så en gang til, **bot navn**, **er aktivert**, og **påloggingsinformasjon** , din nettside vil nå se lik ut:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Du kan nå trykke "download" knappen og vår konfigurasjonsgenerator vil generere ny `json` fil basert på ditt valgte navn. Lagre filen i `config` mappen som ligger i mappen du har hentet ut zip-filen i forrige trinn.

Gratulerer! Du har nettopp fullført en grunnleggende ASF-bot konfigurasjon. Det er mye mer å ødelegge, men for nå er dette alt du trenger.

---

### Kjører ASF

Jeg vet at du venter i øyeblikket og vi kan ikke holde deg lenger, siden du nå er klar til å starte programmet for første gang. Dobbeltklikk `ArchiSteamFarm` binært i ASF-mappen. Du kan også starte det fra konsollen.

Nå ville det være god tid å gjennomgå vår **[fjernkommunikasjon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** -del hvis du er bekymret for tingene som ASF er programmert til å gjøre, spesielt handlinger som det vil ta med ditt navn, slik som å bli med i vår Steam-gruppe som standard. Du kan alltid deaktivere valgte funksjoner senere hvis du ikke liker dem, ASF kommer bare med fornuftige standarder, og vi måtte ta en viss avgjørelse om generell bruk som gjelder for flertallet av vårt brukergrunnlag, I tillegg til vårt eget syn på programmet i sitt prinsipp.

Forutsatt at alt gikk bra, regnet mest etter å ha installert alle de nødvendige avhengighetene i det første trinnet, og konfigurerer ASF i den tredje og ASF bør starte ordentlig, oppdage din første bot, og forsøke å logge inn:

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF vil sannsynligvis fortsatt kreve én detalj fra deg - 2FA for å få tilgang til kontoen (med mindre du fullstendig deaktivert SteamGuard og så nei). Bare følg instruksjonene på skjermen, kan du legge inn kode fra autentisering/e-post, eller godta bekreftelsen i mobilappen.

Noe gikk galt?

#### ASF starter ikke i det hele tatt, ingen konsollvindu

Enten mangler du .NET-betingelser, eller du har lastet ned feil variant av ASF for maskinen din. Hvis du ikke vet hva som er galt, sjekk vår **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** for en mulig måte å finne et nøyaktig problem på. og hvis du fortsatt sitter fast, ta kontakt med vår **[støtte](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### Ingen boter definert

Du har ikke satt generert konfigurasjon i `config` -mappen. Noen andre vanlige feil i dette trinnet kan inkludere manuelt å endre utvidelse fra `.json` f.eks `. xt`og enkelte operativsystemer (f.eks. Windows) vil gjerne skjule felles utvidelser som standard, slik at filen din er på egnet sted og også med riktig navn.

#### Starter ikke denne boten fordi den er deaktivert i konfigurasjonsfilen

Du har glemt å snu `aktivert` -bryteren som forteller ASF å starte botten din automatisk. Med mindre det var din rettslig intensjon, men da bør du allerede vite hvordan du skal utføre kommandoer, bare `start` botten din etter den meldingen.

#### `Ugyldig passord`

Innloggingsopplysningene dine er mest sannsynlig feil. Sjekk `SteamLogin` og `SteamPassword` i den genererte konfigurasjonen hvis de er feil, rett dem opp ved å gå tilbake til konfigurasjonssteget. Hvis du fortsatt har problemer, prøv å bruke samme påloggingslegitimasjon i din egen Steam-klient - du bør også feile å logge inn, og du får kanskje mer informasjon om hva som er galt denne måten.

#### Alt god?

Etter at du har passert den første innloggingen, forutsetter at dine detaljer er riktige, vil du logge inn med suksess og ASF vil begynne å drive oppdrett med standardinnstillinger som du ikke har berørt som nå:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Dette beviser at ASF nå lykkes med å gjøre jobben på kontoen din, slik at du nå kan minimere programmet og gjøre noe annet. Og i det samme skal I avvente det, og likeså det som skal gjemmes av det til evig tid!

Pansekort er et emne for ytterligere en langvarig artikkel, slik som dette, men i prinsippet: etter nok tid (avhengig av **[ytelse](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), Du vil se at Steam bytingskort langsomt blir sluppet. Selvfølgelig må du ha gyldige spill å drive med på, viser at "du kan få tak i X flere kortstokker når du spiller dette spillet" på din **[merkes side](https://steamcommunity.com/my/badges)** - hvis det ikke er noen spill å spille på da vil ASF opplyse at det ikke er noe å gjøre, som angitt i vår **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, som svarer de vanligste spørsmålene folk har på dette punktet, Å lure på hvorfor til tross for å eie 14 spill på sin konto, så er ASF hevder det ikke noe å gjøre - nei, det er ikke en feil.

Dette avslutter vår meget grunnleggende brukerveiledning. Som i hvert RPG-spill, er du ferdig med opplæringen, og vi lar deg se hele ASF-verden nå. For eksempel kan du nå bestemme om du ønsker å konfigurere ASF ytterligere, eller la den gjøre sin jobb i standardinnstillingene. Vi vil dekke noen grunnleggende detaljer hvis du ønsker å lese litt mer, og la deg legge igjen hele wiki for å finne funnet.

---

### Utvidet konfigurasjon

#### Jordbruk flere kontoer engang

ASF støtter jordbruket mer enn én konto av gangen, noe som er dens primære funksjon. Du kan legge til flere kontoer i ASF ved å generere flere bot konfigurasjonsfiler, på akkurat samme måte som du har generert den første for noen minutter siden. Du trenger bare å sikre to ting:

- Unik bot navn, hvis du allerede har din første bot ved navn `MainAccount`, kan du ikke ha ett annet med samme navn.
- Gyldig innloggingsdetaljer, som `SteamLogin`, `SteamPassword` og `SteamParentalCode` (hvis du har bestemt deg for å fylle ut dem)

Med andre ord, bare hoppe til konfigurasjon igjen og gjør nøyaktig det samme, bare for din andre eller tredje konto. Husk å bruke unike navn for alle dine boter, ikke overskrive eksisterende konfigurasjoner.

---

#### Endre innstillinger

I vår frittstående web config-generator endrer du eksisterende innstillinger på akkurat samme måte ved å generere en ny konfigurasjonsfil. Klikk på "Aktiver avanserte innstillinger" og se hva som er der for å oppdage. I dette eksemplet, vil vi endre `CustomGamePlayedWhileFarming` -innstilling, som lar deg angi egendefinert navn vises når ASF er deling, i stedet for å vise faktisk spill.

La oss analysere dette litt først. Hvis du kjører ASF og begynner å dyrke, i standardinnstillinger, vil du se at Steam-kontoen din er i spillet nå:

![Damp](https://i.imgur.com/1VCDrGC.png)

Det fornuftig, etter all ASF fortalte Steam-plattformen at vi spiller spillet, trenger vi kort fra denne, ikke sant? Men hey, vi kan tilpasse dette! Veksle avanserte innstillinger hvis du ikke har gjort det med ennå, finn `CustomGamePlayedWhileFarming`. Sett en egendefinert tekst som du vil vise der, som for eksempel "Idling kort":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Last ned den nye konfigurasjonsfilen på eksakt samme måte, og **overskriv** din gamle konfigurasjonsfil med den nye. Du kan også slette den gamle konfigurasjonsfilen og sette den nye i stedet for selvfølgelig.

ASF er ganske smart og det skal merke at du har endret konfigurasjonen, som den deretter skulle automatisk plukke opp og poste, uten at programmet starter på nytt. Hvis du ikke har skjedd, kan du bare starte programmet på nytt for å sikre at din nye konfigurasjon blir plukket opp. Etter dette bør du merke deg at ASF nå viser din egendefinerte tekst tidligere sted:

![Damp 2](https://i.imgur.com/vZg0G8P.png)

Dette bekrefter at du har redigert din konfigurasjon. På nøyaktig samme måte kan du endre globale ASF-egenskaper, ved å bytte fra bot tab til "ASF" tab, laste ned generert `ASF. sønn` konfigurasjonsfil og sette den i `config` mappen.

Redigering av ASF-konfigurasjonene kan gjøres mye enklere ved å bruke vår ASF-ui-frontend, som vil bli beskrevet nærmere nedenfor.

---

#### Bruk ASF-ui

Som vi nevnte før, er ASF en konsoll app og starter ikke et grafisk brukergrensesnitt som standard. Imidlertid jobber vi aktivt med **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** frontend til vårt IPC grensesnitt, som kan være en svært anstendig og brukervennlig måte å få tilgang til ulike ASF-funksjoner.

For å bruke ASF-ui må du ha `IPC` aktivert. som er standardalternativet, så med mindre du deaktiverer det, er allerede aktiv. Når du starter ASF, skal du kunne bekrefte at det ordentlig startet IPC-grensesnittet automatisk:

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC, i et nøtt-ell, er innebygd ASFs webserver som starter lokalt på maskinen din, gjør det mulig å kommunisere med din favoritt-nettleser. Forutsatt at den startet riktig, kan du få tilgang til ASFs IPC grensesnitt ved å klikke **[denne](http://localhost:1242)** link, Så lenge ASF kjører, fra samme maskin. Du kan bruke ASF-ui for ulike formål, for eksempel redigering av konfigurasjonsfiler på plass eller sending av **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Du er velkommen til å ta en titt rundt for å finne alle ASF-ui-funksjoner.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Summary

Du har nå satt opp ASF for å bruke Steam-kontoene, og du har allerede tilpasset den slik at du liker det. Hvis du fulgte hele vår veiledning, klarte du også å tilpasse ASF gjennom vårt ASF-ui grensesnitt og startet å oppdage dets funksjoner. Dette avslutter vår veiledning, men vi gir deg en del ekstra pointers til ting du kan være interessert i, "side quests", hvis du insisterer:

- Vår **[-konfigurasjon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** -seksjon vil forklare hva **alle** de ulike innstillingene du har sett faktisk gjør, og hva andre ASF kan tilby deg. Husk å hydrere ordentlig mens du leser, du har blitt advart.
- Hvis du har støt på en eller annen sak eller har noen generiske spørsmål, vurder **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**som skal dekke alle eller minst et stort flertall av spørsmål og spørsmål du måtte ha.
- Vil du lære alt om ASF og hvordan det kan gjøre livet ditt enklere, gå over til resten av **[vår wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. Bruk sidepanelet på høyre side til å velge det temaet du er interessert i.
- Og til slutt, hvis du finner ut at programmet vårt er nyttig for deg og du setter pris på den enorme mengden arbeid som ble lagt inn i det, du kan også tenke deg en liten **[donasjon](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** på vår sak. ASF er labor av kjærlighet, vi har jobbet hardt i vår fritid de siste 10+ årene for å gjøre denne opplevelsen mulig for deg, og vi er svært stolte av den - selv $1 er høyt verdsatt og viser at du bryr deg. I alle tilfeller, ha masse gøy!

---

## Generisk oppsett

Dette vedlegget er for avanserte brukere som vil sette opp ASF i **[generisk](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)** variant. Mens det er mer problematisk i bruk enn **[OS-spesifikke varianter](#os-specific-setup)**, kommer det også med noen ekstra fordeler.

Du vil bruke `generisk` varianten hovedsakelig når:
- Du bruker OS som vi ikke bygger OS-spesifikk pakke for (f.eks 32-bit Windows)
- Du har allerede .NET Runtime/SDK, eller ønsker å installere en
- Du ønsker å minimalisere ASF-strukturstørrelsen og minnefotavtrykket ved å håndtere kravene til kjøretid selv
- Du vil bruke en egendefinert **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** som krever et `generisk` oppsett av ASF for å kjøre riktig (på grunn av manglende naturlig avhengigheter)

Du kan selvsagt også bruke den i et annet scenario du ønsker, men ovennevnte er den mest mening.

Husk likevel at generisk oppsett kommer med en vri - **du** tar betalt for .NET rulletid i dette tilfellet. Det betyr at hvis din .NET SDK (runtime) er utilgjengelig, utdatert eller ødelagt, så vil ASF ikke virke. Dette er grunnen til at vi ikke helt anbefaler dette oppsettet for uformelle brukere, siden du nå må forsikre deg om at du er. ET SDK (runtime) samsvarer med ASF-krav og kan kjøre ASF, i motsetning til **** som sikrer at vi . ET runtime som er bundet med ASF kan gjøre det.

For `generic` package, you can follow entire OS-specific guide above, with only two small changes. I tillegg til å installere .NET-forutsetninger ønsker du også å installere .NET SDK, og i stedet for å laste ned og ha OS-spesifikk `ArchiSteamFarm(. xe)` kjørbar fil, du vil nå laste ned og bare ha en generisk `ArchiSteamFarm.dll` binærfil. Alt annet er nøyaktig det samme.

Med ekstra trinn:
- Installer **[.NET forutsetninger](#net-prerequisites)**.
- Installer **[.NET SDK](https://www.microsoft.com/net/download)** (eller minst ASP.NET Core og .NET runtimes) som passer for ditt OS. Du vil sannsynligvis bruke en installatør. Se **[kjøretidskrav](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** hvis du ikke er sikker på hvilken versjon du vil installere.
- Last ned **[siste ASF-utgave](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** på `generisk` variant.
- Pakk ut arkivet til ny plassering.
- **[Konfigurer ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, på nøyaktig samme måte som beskrevet ovenfor.
- Start ASF ved å bruke en hjelper skript eller utføre `dotnet /path/to/ArchiSteamFarm.dll` manuelt fra ditt favorittskall.

Generisk variant av ASF har ikke maskinspesifikk binær, når alt heter `generic` for en grunn - det er plattform-agnostisk bygg som kan fungere overalt, så ikke forventer `exe` -filen der.

Dette er grunnen til at vi har samlet det med hjelperskript (som `ArchiSteamFarm.cmd` for Windows og `ArchiSteamFarm. h` for Linux/macOS), som er lokalisert ved siden av `ArchiSteamFarm.dll` -binær. Du kan bruke disse hvis du ikke ønsker å kjøre `dotnet` kommando manuelt.

Eventuelt ikke hjelper skript fungerer heller ikke hvis du ikke installerte . ET SDK og du har ikke `dotnet` kjørbar i `PATH`. De er også helt valgfrie for bruk, du kan alltid `dotnet /path/to/ArchiSteamFarm. lad` manuelt hvis du ønsker det, likesom under panseret med noen ekstra tweaks, så er det akkurat hva disse skriptene gjør likevel.