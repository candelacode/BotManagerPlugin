# ItemsMatcherPlugin

`ItemsMatcherPlugin` er offisiell ASF **[tillegg](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** som utvider ASF med ASF STM oppføringsfunksjoner. Det er særlig dette inkluderer `PublicListing` i **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** og `MatchActively` i **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. ASF kommer med `ItemsMatcherPlugin` sammen med utgivelsen, derfor er den klar for bruk umiddelbart.

---

## `Publikasjonens oppføring`

Offentlig notering, som navnet innebærer, er en liste over tilgjengelige ASF-STM-boter. Det ligger på **[på vårt nettsted](https://asf.justarchi.net/STM)**, håndtert automatisk og brukes som offentlig tjeneste for både ASF-brukere som bruker `MatchActively`, I tillegg til ASF-- og ikke-ASF-brukere for manuell matching.

Du har et sett med krav som skal oppfylles for å kunne oppføres. På et minimum må du ha tillatt `PublicListing` i `RemoteCommunication` (standardinnstilling). `SteamTradeMatcher` aktivert i `TradingPreferences`, **[offentlig inventar](https://steamcommunity.com/my/edit/settings)** personverninnstillinger, en **[ubegrenset](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** konto og **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** aktiv. Ytterligere krav inkluderer 2FA som er aktive siden minst 15 dager, siste passordendring for mer enn 5 dager siden Mangel på noen konto begrenser seg som låsninger, økonomiske forbud og handelsforbud. Naturlig nok må du også ha minst én (omsettelig) vare i inventaret ditt fra spesifiserte `MatchableTypes`, slik som handelskort. I tillegg godtas ikke botter med mer enn `500000` gjenstander på grunn av for mye overhodet, Vi anbefaler å dele opp lagerbeholdningen på flere kontoer i denne saken.

While `PublicListing` is enabled by default, please note that you will **not** be displayed on the website if you do not meet all of the requirements, especially `SteamTradeMatcher`, which isn't enabled by default. For personer som ikke oppfyller kriteriene, selv om de beholdt `PublicListing` aktivert, kommuniserer ASF ikke med serveren på noen måte. Offentlig liste er også kompatibel med nyeste stabile versjon av ASF og kan nekte å vise utdaterte boter, spesielt hvis de mangler kjernefunksjonalitet som finnes bare i nyere versjoner.

### Hvordan den fungerer nøyaktig

ASF sender innledende data én gang etter innlogging, som inneholder alle egenskaper som er den offentlige oppføringen bruker av. Deretter sender ASF en meget liten "heartbeat" forespørsel om å varsle serveren om at boten fortsatt er oppe og kjører. Om hjerteslagene ikke kom noen gang, for eksempel på grunn av nettverksproblemer, Da sender ASF den på nytt hver minutt, til server registrerer den. Denne måten serveren vår vet nøyaktig hvilke boter som fortsatt kjører og er klar for å akseptere handelstilbud. ASF vil også sende innledende kunngjøring ved behov, for eksempel hvis den oppdager at lagerbeholdningen har endret seg siden den forrige.

Vi viser alle kvalifiserte ASF-kontoer som var aktive i **siste 15 minutter**. Brukere er sortert etter deres relative nytten - `MatchEverything` bots som blir vist med `Ethvert` banner som godtar alle 1:1 handler, så unike spill teller, og endelig antall gjenstander.

### API

ASF STM notering aksepterer bare ASF-botter for tid. Det er ingen måte å liste tredjepartsroboter på listen vår for nå, Ettersom vi ikke kan gjennomgå koden sin enkelt og sikre at de oppfyller hele logikken vår. Deltakelse i oppføringen krever derfor nyeste stabile ASF-versjon, men kan kjøre med egendefinerte **[tillegg](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

Vi har et veldig enkelt **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** endepunkt som du kan bruke. Det omfatter alle data vi har, bortsett fra varelager hos brukere som er en del av `MatchActively` alene.

### Retningslinjer for personvern

Hvis du samtykker i å bli oppført i vår oppføring, ved å aktivere `SteamTradeMatcher` og ikke avvise `PublicListing`, som angitt ovenfor, vil vi midlertidig lagre noen av dine Steam-kontodetaljer på serveren vår for å gi den forventede funksjonaliteten.

Informasjon om offentlig bruk (eksponert av Steam av alle interesserte parter) inkluderer:
- Steam-identifikatoren din (i 64-bit, for å generere lenker)
- Kallenavnet ditt (for visningsformål)
- Din avatar (hash, for å vise formål)

Eventuelt offentlig informasjon (utsatt av Steam til hver interessepart hvis du oppfyller kravene til oppføring) inkluderer:
- Ditt **[inventar](https://steamcommunity.com/my/inventory/#753_6)** (slik at folk kan bruke `MatchActively` mot dine gjenstander).

Privat info (valgte data kreves for å sørge for funksjonalitet) inkluderer:
- Din **[tradingstoken](https://steamcommunity.com/my/tradeoffers/privacy)** (så folk utenfor vennelisten din kan sende deg handel)
- Din `MatchbleTypes` innstilling (for vise formål og treff)
- Din `MatchEverything` innstilling (for vis formål og partnerskap)
- Din `MaxTradeHoldDuration` innstilling (så andre vet om du er villig til å akseptere handlingene sine)

Siden du slutter å bruke (kunngjøring) oppføringen vår blir dataene dine utilgjengelige for publikum innen maksimalt 15 minutter, og beholdes på serveren vår i maksimalt to uker – alt blir automatisk slettet etter den perioden. Det kreves ingen handling av deg for at det skal skje.

---

## `Matchactively`

`MatchActively` er aktiv versjon av **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** inkludert interaktive matchinger hvor botten vil sende handler til andre. Den kan fungere alene eller sammen med `SteamTradeMatcher`. Denne funksjonen krever at `LicenseID` settes da den bruker tredjeparts server og betalte ressurser for å fungere.

For å gjøre bruk av det alternativet har du et sett med krav som skal oppfylles. På et minimum må du ha en **[ubegrenset](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** konto, **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** aktiv og minst én gyldig type i `Matchabletype`, slik som handelskort. Ytterligere krav inkluderer 2FA som er aktive siden minst 15 dager, siste passordendring for mer enn 5 dager siden Mangel på noen konto begrenser seg som låsninger, økonomiske forbud og handelsforbud.

Hvis du oppfyller alle kravene ovenfor, ASF vil med jevne mellomrom kommunisere med vår **[offentlig ASF STM liste](#publiclisting)** for å aktivt matche bots som er tilgjengelig for øyeblikket.

Under matching vil ASF-bot hente sitt eget inventar. kommuniser deretter med vår server for å finne alle `MatchableTypes` samsvarer med andre, tilgjengelige boter. Takk for at du kommuniserer direkte med serveren vår, denne prosessen krever en enkelt forespørsel, og vi har umiddelbar informasjon om hvilken som helst tilgjengelig bot tilbyr noe interessant for oss - hvis det blir funnet en match ASF vil sende og bekrefte handelstilbudet automatisk.

Denne modulen skal være gjennomsiktig. Matchingen vil starte på ca `1` time siden ASF-start, og vil gjenta seg hver `6` timer (hvis nødvendig). `MatchActively` har som mål å bli brukt som et langsiktig, regelmessig tiltak for å sikre at vi aktivt går på vei mot å fullføre settingen. men personer som ikke kjører ASF 24/7 kan også vurdere å bruke `match` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Målbrukere av denne modulen er primærkontoer og "stash" alt kontoer, Selv om den kan brukes av en hvilken som helst bot som ikke er satt til `MatchEverything`. I tillegg godtas ikke botter med mer enn `500000` gjenstander for å matche på grunn av for mye overhode, Vi anbefaler å dele opp lagerbeholdningen på flere kontoer i denne saken.

ASF gjør det best for å minimere mengden av forespørsler og trykk som genereres ved bruk av dette alternativet, samtidig som effektiviteten til den øvre grensen er maksimert. Nøyaktig algoritme ved å velge bots til samsvar og organisere hele prosessen på annen måte er ASFs gjennomføringsdetaljer og kan endre informasjon om tilbakemeldinger, situasjon og mulige framtidige ideer.

Gjeldende versjon av algoritmen gjør ASF til prioritering av `Alle` botter først, spesielt de med et bedre mangfold av spill som deres gjenstander kommer fra. Når du går ut av `Alle` -boter, vil ASF bevege seg på `Fair` på samme regel for mangfold. ASF vil forsøke å samsvare med alle tilgjengelige bot minst én gang, for å sikre at vi ikke mangler en mulig framdrift.

`MatchActively` tar kontoproboter som du svartelistet fra handel gjennom `tbadd` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** og forsøker ikke å tilvirke dem aktivt. Dette kan brukes til å fortelle ASF om hvilke botter det aldri skal være like, selv om de ville ha potensielle dukker for oss å bruke.

ASF vil også gjøre sitt beste for å sikre at tilbudene i handelen skjer. På neste bane, noe som normalt skjer innen 6 timer, vil ASF kansellere eventuelle ventende handelstilbud som ennå ikke var akseptert, Og rive steamIDer med på å forhåpentligvis foretrekke mer aktive botter først. Men om prioriterte botter er de siste som har den kampen vi trenger, forsøker vi likevel å matche dem (igjen).

---

### Hvorfor trenger jeg en `LicenseID` for å bruke `MatchActively`? Var det ikke gratis før?

ASF er og står igjen, fri og åpen kildekode slik det ble etablert i oppstarten av prosjektet tilbake i oktober 2015. Kildekode til `ItemsMatcher` og utvidelsen `MatchActively` er tilgjengelig i vårt depot, Mens ASF-programmet er ikke-kommersielt, tjener vi ikke noe fra bidrag til det, bygging eller publisering. De siste 7 årene har ASF fått enorm utvikling og det blir fremdeles forbedret og utvidet med hver månedlige stabile utgivelse, for det meste av én person, **[JustArchi](https://github.com/JustArchi)** - uten noen strenger tilknyttet. Det eneste vi får er av ikke-obligatoriske bidrag som kommer fra våre brukere.

`MatchActively` lang, fram til oktober 2022, var en del av ASF-kjernen og tilgjengelig for alle å bruke. I oktober 2022, Valve, selskapet bak Steam, har satt svært alvorlige frekvensgrenser for å hente varelager hos andre botter - som har gjort tidligere funksjonalitet helt ødelagt, uten mulighet for løsning for å løse dette problemet. På grunn av at funksjonen er blitt fullstendig defundert uten mulighet for å bli fikset, den måtte fjernes fra ASF-kjerne som obsolet.

`MatchActively` ble gjenopptatt som en del av den offisielle `ItemsMatcher` utvidelsen som forbedrer ASF med aktivt kort som samsvarer med funksjonaliteten. Grunnlag på et komplett omarbeidende konsept. Resurrecting `MatchActively` funksjonen krever av oss **ekstraordinær verdi av arbeid** for å opprette ASF-backend, helt nye tjenester levert på en server; med mer enn hundre betalte fullmakter til å løse varelager, alle utelukkende tillate ASF-klienter å benytte `Matchtively` slik før. på grunn av arbeidsmengden som er involvert, samt ressurser som ikke er gratis og som krever at de betales månedlig av oss (domene, servere, pris), vi har bestemt oss for å tilby denne funksjonen til våre sponsorer, det er: Personer som allerede støtter ASF-prosjektet månedlig, og takket være dem som får de betalte ressursene tilgjengelig.

Vårt mål er ikke å dra nytte av det, men sjelden, dekk **månedlige kostnader** som er utelukkende knyttet til dette alternativet - derfor tilbyr vi det i utgangspunktet for intet, men vi må ta betalt litt for det, siden vi ikke kan betale hundrevis av dollar fra våre egne lommer hver måned, bare for å gjøre den tilgjengelig for deg. Vi har ikke egentlig vært i stand til å diskutere prisen heller, den er Valve som tvinger disse kostnadene på oss, og alternativet er ikke tilgjengelig for en slik funksjon i det hele tatt. Hvilket selvfølgelig gjelder hvis du avgjør av en eller annen grunn, at du ikke kan rettferdiggjøre ved hjelp av vår plugin på disse vilkårene.

I alle tilfeller forstår vi at `MatchActively` ikke er for alle, og vi håper at dere også forstår hvorfor vi ikke kan tilby den gratis. Hvis ingen var interessert i å bidra til å dekke kostnadene ved denne funksjonen, ville det rett og slett ikke eksistere med Vi bør som sagt måtte kutte de månedlige utgiftene som ingen er villige til å holde. Takk, vi er i en bedre stilling enn det, og du kan avgjøre deg selv om du er villig til å bruke `MatchActively` på disse vilkårene, eller ikke.

---

### Hvordan kan jeg få tilgang?

`ItemsMatcher` tilbys som en del av månedlig $5+ sponsor tier på **[JustArchi's GitHub](https://github.com/sponsors/JustArchi)**. Det er også mulig å bli engangsstøtte, selv om lisensen i dette tilfellet bare vil være gyldig i en måned (med mulighet for å utvide på samme måte). Når du blir sponsor for $5 tier (eller høyere), les **[konfigurasjonen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** for å få og fylle ut `lisensID`. Etterpå trenger du bare å aktivere `MatchActively` i `TradingPreferences` av din bot.

Lisensen lar deg sende begrenset mengde forespørsler til serveren. $5 tier lar deg bruke `MatchActively` for én bot konto (4 forespørsler daglig), og hver $5 legger til to botten kontoer (8 forespørsler daglig). Hvis du for eksempel vil kjøre den på tre kontoer, vil det dekkes med $10 tier og høyere.