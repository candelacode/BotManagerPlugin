# Handel

ASF inkluderer støtte til ikke-interaktive (offline) handel. Både mottak (godta/avslått) og sending av handler er tilgjengelig med en gang, og krever ikke spesielle konfigurasjoner, men krever selvsagt ubegrenset Steam-konto (den som allerede har brukt 5$ i butikken). Bare begrenset handelsfunksjonalitet er tilgjengelig for begrensede kontoer.

---

## Logikk

Først av alt er det mulig å deaktivere **alle** innkommende trade offers, ved å bruke `DisableIncomingTradesParsing` flagg i `BotBehaviour`. Bruker dette, ettersom navnet innebærer, vil deaktivere all funksjonalitet knyttet til parsering av innkommende handler, som inkluderer under standard logikk, samt alle ekstra funksjoner som er tilgjengelige som avhenger av å reagere på det innkommende handelstilbudet. Siden standardinnstillinger allerede er ikke-påtrengende du bør vurdere å bruke dette alternativet kun hvis du i det hele tatt ikke har noen hensikt fra ASF å gjøre noe relatert til de innkommende handlene.

Følgende forklarer logikk når innkommende handel tilbyr analysering er aktivert, noe som er standardalternativet.

ASF vil alltid akseptere alle handler, uavhengig av elementer, sendt fra bruker med `Master` (eller høyere) tilgang til boten. Dette gjør det ikke bare enkelt å plyndre dampkort som anskaffes av botten på grunn av dette. men gjør det også enkelt å administrere Steam-gjenstander som botter på inventaret - også de fra andre spill (for eksempel CS:GO).

ASF vil avvise handelstilbudet uavhengig av innhold, fra en ikke-master-bruker som er svartelistet fra handelsmodulen. Svartelisten lagres i standard `BotName. b` database, og kan administreres via `tb`, `tbadd` og `tbrm` **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Dette burde fungere som et alternativ til standard brukerblokk som tilbys av Steam – bruk med forsiktighet.

ASF vil akseptere alle `loot`lignende handler som sendes på tvers av bots, med mindre `DontBotTrades` er angitt i `TradingPreferences`. Kort standard `TradingPreferences` av `Ingen` vil føre til at ASF automatisk aksepterer handler fra bruker med `Master` tilgang til boten (forklart over), samt all donasjon handler fra andre botter som deltar i ASF-prosessen.

Når du aktiverer `AkseptDonations` i din `TradingPreferences`, ASF vil også akseptere handel med en donasjon - en handel hvor bot konto ikke taper gjenstander. Denne egenskapen påvirker bare ikke-bot kontoer, da bot kontoer er påvirket av `DontAcceptBotTrades`. `AkseptDonations` tillater deg enkelt å akseptere donasjoner fra andre mennesker, og også bots som ikke deltar i ASF-prosessen.

Det er hyggelig å merke seg at `AcceptDonations` ikke krever **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, Ettersom det ikke er noen bekreftelse på at vi ikke mister noen elementer.

Du kan også ytterligere tilpasse ASF-handelsevner ved å endre `TradingPreferences` tilsvarende. En av de viktigste funksjonene `TradingPreferences` er `SteamTradeMatcher` som vil føre til at ASF bruker innebygd logikk for å godta fag som hjelper deg med å fullføre manglende merker, som er spesielt nyttig i samarbeid med offentlig børsnotering av **[SteamTradeMatcher](https://www.steamtradematcher.com)**, men kan også fungere uten det. Den er nærmere beskrevet nedenfor.

---

## `SteamTradeMatcher`

Når `SteamTradeMatcher` er aktiv, ASF vil bruke ganske kompleks algoritme når en sjekker om handelen passerer STM-regler og er minst nøytrale mot oss. Den faktiske logikken er følgende:

- Avvis handelen hvis vi mister noe, men produkttypene angitt i `MatchbleTyper`.
- Avvis handelen hvis vi ikke mottar minst det samme antallet enheter på per-spill, per-type og per raritet.
- Avvis handelen hvis brukeren spør om spesielle Steam-sommer/vintersalgskort og har en handelsbeholdning.
- Avvis handelen hvis handelsens varighet overstiger `MaxTradeHoldDuration` global konfigurasjons eiendom.
- Avvis handelen hvis vi ikke har `MatchEverything` satt, og det er verre enn nøytralt for oss.
- Aksepter handelen hvis vi ikke avviste den gjennom noen av punktene ovenfor.

Det er fint å merke seg at ASF også støtter overbetalende - logikken vil fungere riktig når brukeren legger til noe ekstra i handelen, så lenge alle betingelsene over er oppfylt.

Først 4 avslag bør være åpenbare for alle. I den siste inngår «dupes logikk» som sjekker gjeldende tilstand i bokføringen vår, og bestemmer hva som er status for handelen.

- Handel er **god** hvis utviklingen mot å stå ferdig frem. Eksempel: A A (før) -> A B (etter)
- Handel er **nøytral** hvis vi utvikler oss mot ferdigstillelsesopphold i takt. Eksempel: A B (før) -> A C (etter)
- Handel er **dårlig** hvis vår fremgang mot å ferdigstille faller. Eksempel: A C (før) -> A A (etter)

STM opererer bare på gode handler, noe som innebærer at brukeren som bruker STM for dupes matching, alltid foreslår gode handler for oss. ASF er likevel liberal, og den aksepterer også nøytrale handeler. fordi vi i disse handlene ikke mister noe, så det er ingen virkelig grunn til å avslå dem. Dette er spesielt nyttig for vennene dine, siden de kan bytte de store kortene uten å bruke STM i det hele tatt, Så lenge du ikke mister noens fremdrift.

Som standard vil ASF avvise dårlige handler - dette er nesten alltid det du vil ha som bruker. Men du kan eventuelt aktivere `MatchEverything` i din `TradingPreferences` for å gjøre ASF til vår dupe handel, inkludert **er uheldige**. Dette er nyttig bare hvis du ønsker å kjøre en 1:1 trade bot under din konto, etter hvert som du forstår at **ASF ikke lenger vil hjelpe deg med å fullføre merket, og få skaden til å miste hele ferdigstilte settet for N dupes av samme kort**. Hvis du vil med hensikt kjøre en handelsbot som er **aldri** ment å fullføre noe, og bør tilby hele beholdningen til alle interesserte brukere og deretter kan du aktivere dette alternativet.

Uansett hvor du valgte `TradingPreferences`, betyr ikke et handel som avvises av ASF at du ikke kan akseptere det selv. Hvis du holdt standardverdien for `BotBehaviour`, som ikke inkluderer `AvvistInvalidTrades`, ASF kan bare ignorere handlene – slik at du kan bestemme deg selv om du er interessert i dem eller ikke. Samme gis for handler med produkter utenfor `MatchbleTypes`, i tillegg til alt annet - modulen skal hjelpe deg med å automatisere STM handel, ikke bestemme hva som er god handel, og hva som ikke. Det eneste unntaket fra denne regelen er når du snakker om brukere som du svartelistet fra handelsmodulen med `tbadd` kommandoen - verdener fra disse brukerne blir umiddelbart avvist uavhengig av `BotBehaviour` innstillinger.

Det anbefales å bruke **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** når du aktiverer dette alternativet, da denne funksjonen mister hele sitt potensiale hvis du velger å manuelt bekrefte alle handeler. `SteamTradeMatcher` vil fungere ordentlig selv uten mulighet til å bekrefte handel, men den kan generere etterslep av bekreftelser hvis du ikke godtar dem i tide.