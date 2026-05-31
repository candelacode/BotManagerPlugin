# Ekstern kommunikasjon

I dette avsnittet belyses det på fjernkommunikasjon som ASF inkluderer, herunder nærmere forklaring på hvordan en kan påvirke den. Selv om vi ikke vurderer noe under som fiendtlig eller på annen måte uønsket, er vi heller ikke lovlig forpliktet til å offentliggjøre det, vi ønsker at du skal bedre forstå programfunksjonaliteten spesielt når det gjelder ditt privatliv og data som blir delt.

## Damp

ASF kommuniserer med Steam-nettverk (**[CM servere](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), i tillegg til **[Steam API](https://steamcommunity.com/dev)**, **[Steam butikk](https://store.steampowered.com)** og **[Steam-samfunnet](https://steamcommunity.com)**.

Det er ikke mulig å deaktivere kommunikasjon som ovenfor, siden det er kjernefundamentet ASF er basert på for å gi dens grunnleggende funksjonalitet. Du må avstå fra å bruke ASF hvis du ikke er komfortabel med det ovenfor.

## Steam gruppe

ASF kommuniserer med vår **[Steam-gruppe](https://steamcommunity.com/groups/archiasf)**. Gruppen gir deg kunngjøringer, spesielt nye versjoner, kritiske saker, Steam-problemer og andre ting som er viktige for å holde samfunnet oppdatert. Det gir deg også mulighet til å bruke vår tekniske støtte ved å stille spørsmål, løse problemer, rapportere problemer eller foreslå forbedringer. Som standard vil kontoer i ASF automatisk bli med i gruppen ved innlogging.

Du kan bestemme å velge bort fra gruppen ved å deaktivere `SteamGroup` flagg i **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** -innstillinger.

## GitHub

ASF kommuniserer med **[GitHub's API](https://api.github.com)** for å hente **[ASF utgivelser](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** for oppdatering. Dette gjøres som del av auto-oppdateringer (hvis du har holdt **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** aktivert), i tillegg til `oppdaterer` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Du kan påvirke ASFs kommunikasjon med GitHub gjennom **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** egenskapen - å sette den til `Ingen` vil resultere i å deaktivere hele oppdateringsfunksjonaliteten. Her er det også GitHub kommunikasjon.

## ASF's server

ASF kommuniserer med **[vår egen server](https://asf.justarchi.net)** for mer avansert funksjonalitet. Spesielt omfatter dette følgende:
- Verifikasjon av kontrollsum av ASF bygger lastet ned fra GitHub mot vår egen uavhengige database for å sikre at alle nedlastede versjoner er legitime (gratis malware, MITM-angrep eller annen manipulering)
- Henter liste over dårlige bots for filtrering dersom du har beholdt `FilterBadBots` global konfigurasjonsinnstilling aktivert.
- Announcing your bot in **[our listing](https://asf.justarchi.net/STM)** if you've enabled `SteamTradeMatcher` in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** and meet other criteria
- Laster ned tilgjengelige bots for handel fra **[vår oppføring](https://asf.justarchi.net/STM)** hvis du har aktivert `MatchActively` i **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** og oppfyller andre kriterier

Som et sikkerhetstiltak, er det ikke mulig å deaktivere sjekksum verifikasjon for ASF-bygg. Men du kan deaktivere automatiske oppdateringer fullstendig hvis du ønsker å unngå dette, som beskrevet over i GitHub delen.

Du kan deaktivere `FilterBadBots` hvis du ønsker å unngå å hente listen fra serveren.

Du kan bestemme å velge bort å bli annonsert i oppføringen ved å deaktivere `PublicListing` flagg i bot's **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** -innstillinger. Dette kan være nyttig hvis du ønsker å kjøre `SteamTradeMatcher` -bot uten å bli annonsert samtidig.

Å laste ned bots fra oppføringen vår er obligatorisk for `MatchActively` . Du må deaktivere den innstillingen hvis du er uvillig til å akseptere det.