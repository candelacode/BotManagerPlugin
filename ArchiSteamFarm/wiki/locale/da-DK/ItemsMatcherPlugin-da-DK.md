# ElementMatcher- Pluginname

`ItemsMatcherPlugin` er officielt ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** der udvider ASF med ASF STM listning funktioner. Navnlig Dette omfatter `PublicListing` i **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** og `MatchActively` i **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. ASF leveres med `ItemsMatcherPlugin` bundtet sammen med udgivelsen, derfor er den klar til brug med det samme.

---

## `Offentliggørelse`

Offentlig notering, som navnet antyder, er en liste over ASF STM bots. Det er placeret på **[vores hjemmeside](https://asf.justarchi.net/STM)**, managed automatically and used as a public service for both ASF users that make use of `MatchActively`, samt ASF og ikke-ASF brugere til manuel matching.

For at blive opført, har du et sæt af krav at opfylde. Du skal som minimum have tilladt `PublicListing` i `RemoteCommunication` (standardindstilling), `SteamTradeMatcher` aktiveret i `TradingPreferences`, **[public inventory](https://steamcommunity.com/my/edit/settings)** privacy settings, en **[ubegrænset](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** konto og **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** aktiv. Yderligere krav inkluderer 2FA aktiv siden mindst 15 dage, sidste adgangskodeskift mere end 5 dage siden mangel på kontobegrænsninger såsom låsepunkter, økonomiske forbud og handelsforbud. Selvfølgelig skal du også have mindst én (omsættelig) vare i din inventar fra angivne `MatchableTypes`, såsom handelskort. Hertil kommer, at bots med mere end `500000` ikke accepteres på grund af overdreven store generalomkostninger. vi anbefaler at opdele din inventar på flere konti i dette tilfælde.

Mens `PublicListing` er aktiveret som standard, Bemærk, at du vil **ikke** blive vist på hjemmesiden, hvis du ikke opfylder alle kravene, især `SteamTradeMatcher`, som ikke er aktiveret som standard. For folk, der ikke opfylder kriterierne, selv om de holdt `PublicListing` aktiveret, kommunikerer ASF ikke med serveren på nogen måde. Offentlig notering er også kun kompatibel med den seneste stabile version af ASF og kan nægte at vise forældede bots især hvis de mangler kernefunktionalitet, der kun findes i nyere versioner.

### Sådan virker det præcist

ASF sender oprindelige data en gang efter logning ind, der indeholder alle ejendomme offentlig notering gør brug af. Derefter, hver 10 minutter ASF sender en, meget lille "hjerteslag" anmodning, der meddeler vores server, at botten stadig er i gang. Hvis af en eller anden grund hjerteslag ikke ankomme, for eksempel på grund af netværk spørgsmål, så ASF vil prøve at sende det igen hvert minut, indtil serveren registrerer det. På denne måde ved vores server præcist, hvilke bots der stadig kører og klar til at acceptere handel tilbud. ASF vil også sende en indledende meddelelse efter behov, for eksempel hvis den opdager, at vores opgørelse har ændret sig siden den foregående.

Vi viser alle godkendte ASF-konti, der var aktive i **sidste 15 minutter**. Brugere er sorteret efter deres relative anvendelighed - `MatchEverything` bots som vises med `Ethvert` banner som accepterer alle 1:1 handler, så unikke spil tæller, og endelig elementer tæller.

### API

ASF STM notering kun accepterer ASF bots for tiden. Der er ingen måde at liste tredjeparts bots på vores liste for nu, da vi ikke nemt kan gennemgå deres kode og sikre, at de opfylder hele vores handelslogik. Deltagelse i listen kræver derfor den seneste stabile ASF-version, selvom den kan køre med tilpassede **[plugins](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

For forbrugere af listen, har vi et meget simpelt **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** endepunkt, som du kan bruge. Det omfatter alle de data, vi har, bortset fra opgørelser af brugere, som er en del af `MatchActively` har eksklusivt.

### Privatliv politik

Hvis du accepterer at blive opført på vores liste, ved at aktivere `SteamTradeMatcher` og ikke nægte `PublicListing`, som angivet ovenfor gemmer vi midlertidigt nogle af dine Steam-kontooplysninger på vores server for at kunne levere den forventede funktionalitet.

Offentlig info (eksponeret af Steam for alle interesserede parter) omfatter:
- Din Steam-identifikator (i 64-bit form til at generere links)
- Dit kaldenavn (til visningsformål)
- Din avatar (hash, til visning)

Betinget offentlig info (eksponeret af Steam for alle interesserede parter, hvis du opfylder noteringskravene) omfatter:
- Dit **[inventar](https://steamcommunity.com/my/inventory/#753_6)** (så folk kan bruge `MatchActively` mod dine varer).

Privat info (udvalgte data, der kræves for at levere funktionen) omfatter:
- Dit **[handelstoken](https://steamcommunity.com/my/tradeoffers/privacy)** (så folk uden for din venneliste kan sende dig handler)
- Din `MatchableTypes` indstilling (til visningsformål og matching)
- Din `MatchEverything` indstilling (til visningsformål og matching)
- Din `MaxTradeHoldVarighed` indstilling (så andre mennesker ved, om du er villig til at acceptere deres handler)

Siden det øjeblik du holder op med at bruge (annonceret) vores opslag, bliver dine data ikke tilgængelige for offentligheden inden for højst 15 minutter, og opbevares ellers på vores server i højst to uger - alt slettes automatisk efter denne periode. Der kræves ingen handling fra jer, for at det kan ske.

---

## `MatchActively`

`MatchActively` -indstillingen er aktiv version af **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** inklusive interaktiv matchning, hvor botten vil sende handler til andre personer. Det kan arbejde enkeltvis eller sammen med indstillingen `SteamTradeMatcher`. Denne funktion kræver, at `LicenseID` er indstillet, da den bruger tredjepartsserver og betalte ressourcer til at operere.

For at gøre brug af denne mulighed, har du et sæt af krav til at opfylde. Du skal som minimum have en **[ubegrænset](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** -konto **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** aktiv og mindst en gyldig type i `MatchableTypes`, såsom handelskort. Yderligere krav inkluderer 2FA aktiv siden mindst 15 dage, sidste adgangskodeskift mere end 5 dage siden mangel på kontobegrænsninger såsom låsepunkter, økonomiske forbud og handelsforbud.

Hvis du opfylder alle ovenstående krav, ASF kommunikerer med jævne mellemrum med vores **[public ASF STM listing](#publiclisting)** for aktivt at matche bots, der i øjeblikket er tilgængelige.

Under matchning vil ASF bot hente sin egen beholdning, derefter kommunikere med vores server med det for at finde alle mulige `MatchableTypes` kampe fra andre, aktuelt tilgængelige bots. Takket være at kommunikere direkte med vores server, denne proces kræver en enkelt anmodning, og vi har øjeblikkelig information om nogen tilgængelige bot tilbyder noget interessant for os - hvis match er fundet, ASF vil sende og bekræfte handel tilbud automatisk.

Dette modul skal være gennemsigtigt. Matchning vil starte om cirka `1` time siden ASF starter, og vil gentage sig selv hver `6` timer (hvis nødvendigt). `MatchActively` -funktionen har til formål at blive brugt som en langvarig, periodisk foranstaltning for at sikre, at vi er aktivt på vej mod færdiggørelse af sæt, dog, personer, der ikke kører ASF 24/7, kan også overveje at bruge en `match` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Målgruppen brugere af dette modul er primære konti og "stash" alt konti, selvom det kan bruges af enhver bot, der ikke er indstillet til `MatchEverything`. Hertil kommer, at bots med mere end `500000` varer ikke accepteres til matchning på grund af overdreven overhead, vi anbefaler at opdele din inventar på flere konti i dette tilfælde.

ASF gør sit bedste for at minimere mængden af anmodninger og pres, der genereres ved hjælp af denne mulighed samtidig med at effektiviteten af at matche med den øvre grænse maksimeres. Den nøjagtige algoritme til at vælge bots til at matche og på anden måde organisere hele processen, er ASF's gennemførelsesdetaljer og kan ændres med hensyn til feedback, situation og mulige fremtidige idéer.

Den nuværende version af algoritmen gør ASF prioritere `Enhver` bots først, især dem med bedre mangfoldighed af spil, at deres elementer er fra. Når du løber tør for `Enhver` bots, vil ASF gå videre til `Fair` dem efter samme mangfoldighed regel. ASF vil forsøge at matche alle tilgængelige bot mindst én gang for at sikre, at vi ikke mangler på et muligt sæt fremskridt.

`MatchActively` tager højde for bots, som du sortlistede fra handel via `tbadd` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** og vil ikke forsøge at aktivt matche dem. Dette kan bruges til at fortælle ASF, hvilke bots det aldrig bør matche, selv om de ville have potentielle dupes for os at bruge.

ASF vil også gøre sit bedste for at sikre, at handelstilbuddene gennemføres. På næste run, hvilket normalt sker på 6 timer, vil ASF annullere ethvert afventende handelstilbud, der stadig ikke blev accepteret, og deprioritize damme-IDs, der tager del i dem for forhåbentlig at foretrække mere aktive bots først. Stadig, hvis deprioriteret bots er de sidste, der har den match vi har brug for, vil vi stadig forsøge at matche dem (igen).

---

### Hvorfor har jeg brug for et `LicenseID` for at bruge `MatchActively`? Var det ikke gratis før?

ASF er og forbliver fri og open source, da det blev etableret ved projektets start i oktober 2015. Kildekode til `ItemsMatcher` -plugin og derfor `MatchActively` -funktionen er tilgængelig i vores arkiv, mens ASF program er helt ikke-kommercielt, vi ikke tjener noget som helst af bidrag til det, bygning eller offentliggørelse. I løbet af de sidste 7+ år har ASF modtaget enorme mængder af udvikling, og det er stadig ved at blive forbedret og forbedret med hver månedlige stabil udgivelse mest af en enkelt person, **[JustArchi](https://github.com/JustArchi)** - uden vedhæftede strenge. Den eneste finansiering, vi modtager, er fra ikke-obligatoriske donationer, der kommer fra vores brugere.

I meget lang tid, indtil oktober 2022, `MatchActively` funktionen var en del af ASF kerne og tilgængelig for alle at bruge. I oktober 2022, Valve, virksomheden bag Steam, har sat meget strenge hastighedsgrænser for at hente opgørelser af andre bots - som gjorde tidligere funktionalitet helt brudt, uden mulighed for en løsning på dette problem. Derfor, på grund af det faktum, at funktionen er blevet helt hedengjort med ingen chance for at blive rettet, det måtte fjernes fra ASF-kernen som forældet.

`MatchActively` blev genoplivet som en del af officielle `ItemsMatcher` plugin, der yderligere forbedrer ASF med aktive kort matchende funktionalitet, basere sig på et helt omarbejdet koncept. Resurrecting `MatchActively` funktion kræves af os **ekstraordinær mængde arbejde** for at oprette ASF backend, helt ny service hostet på en server, med mere end hundrede lønnede fuldmagter til opgørelse af opgørelser alle udelukkende for at give ASF kunder mulighed for at gøre brug af `MatchActively` som før. På grund af den mængde arbejde, der er involveret, samt ressourcer, der ikke er gratis og kræver at blive betalt på månedsbasis af os (domæne, server, fuldmagter) vi har besluttet at tilbyde denne funktionalitet til vores sponsorer, dvs., personer, der allerede støtter ASF-projektet på månedsbasis, takket være hvem vi kan stille disse betalte ressourcer til rådighed.

Vores mål er ikke at drage fordel af det, men snarere, dække de **månedlige omkostninger** , der udelukkende er knyttet til at tilbyde denne mulighed - det er derfor, vi tilbyder det dybest set for ingenting, men vi er nødt til at opkræve lidt for det, da vi ikke kan betale hundredvis af dollars fra vores egne lommer hver måned, bare for at gøre det tilgængeligt for dig. Vi er ikke rigtig i stand til at diskutere prisen enten, det er ventil, der tvang disse omkostninger for os, og alternativet er ikke at have en sådan funktion til rådighed overhovedet. hvilket naturligvis gælder, hvis du af en eller anden grund beslutter, at du ikke kan retfærdiggøre at bruge vores plugin på disse vilkår.

Under alle omstændigheder forstår vi, at `MatchActively` ikke er for alle, og vi håber, at du også forstår, hvorfor vi ikke kan tilbyde det gratis. Hvis ingen var interesseret i at bidrage til at dække omkostningerne ved denne egenskab, ville det simpelthen ikke eksistere til at begynde med, som vi ville blive tvunget til at skære ned på månedlige udgifter, som ingen er villige til at vedligeholde. Heldigvis, vi er i bedre position end det, og du kan beslutte dig selv, om du er villig til at bruge `MatchActively` på disse vilkår, eller ej.

---

### Hvordan kan jeg få adgang?

`ItemsMatcher` tilbydes som en del af det månedlige $5+ sponsor niveau på **[JustArchi's GitHub](https://github.com/sponsors/JustArchi)**. Det er også muligt at blive engangs sponsor, selvom licensen i dette tilfælde kun er gyldig i en måned (med mulighed for forlængelse på samme måde). Når du er blevet sponsor for $5-lags (eller højere), læs **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** sektionen for at opnå og udfylde `LicenseID`. Derefter behøver du kun at aktivere `MatchActively` i `TradingPreferences` af din valgte bot.

Licensen giver dig mulighed for at sende en begrænset mængde anmodninger til serveren. $5-niveau giver dig mulighed for at bruge `MatchActively` til en bot-konto (4 anmodninger dagligt) og hver ekstra $5 tilføjer yderligere to bot konti (8 anmodninger dagligt). For eksempel, hvis du ønsker at køre det på tre konti, der vil være dækket af $ 10 niveau og højere.