# Fjernkommunikation

Dette afsnit uddyber fjernkommunikation, som ASF omfatter, herunder yderligere forklaring på, hvordan man kan påvirke det. Mens vi ikke betragter noget nedenfor som ondsindet eller på anden måde uønsket, og heller ikke vi er juridisk forpligtet til at afsløre det, vi vil have dig til bedre at forstå programmets funktionalitet, især med hensyn til dit privatliv og data, der deles.

## Steam

ASF kommunikerer med Steam-netværk (**[CM servere](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), samt **[Steam API](https://steamcommunity.com/dev)**, **[Steam butik](https://store.steampowered.com)** og **[Steam community](https://steamcommunity.com)**.

Det er ikke muligt at deaktivere nogen af ovenstående kommunikation, da det er det centrale fundament ASF er baseret på for at give sin grundlæggende funktionalitet. Du skal afstå fra at bruge ASF, hvis du ikke er komfortabel med ovenstående.

## Steam gruppe

ASF kommunikerer med vores **[Steam-gruppe](https://steamcommunity.com/groups/archiasf)**. Gruppen giver dig meddelelser, især nye versioner, kritiske problemer, Steam-problemer og andre ting, der er vigtige for at holde fællesskabet opdateret. Det giver dig også mulighed for at bruge vores tekniske support ved at stille spørgsmål, løse problemer, rapportere problemer eller foreslå forbedringer. Som standard vil konti brugt i ASF automatisk tilslutte sig gruppen ved login.

Du kan vælge at fravælge at deltage i gruppen ved at deaktivere `SteamGroup` flag i bot's **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** indstillinger.

## GitHub

ASF kommunikerer med **[GitHub API](https://api.github.com)** for at hente **[ASF udgivelser](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** for opdateringsfunktionaliteten. Dette gøres som en del af auto-opdateringer (hvis du har bevaret **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** aktiveret) samt `update` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Du kan påvirke ASF's kommunikation med GitHub via **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** egenskaben - hvis den sættes til `Ingen` vil resultere i deaktivering af hele opdateringsfunktionalitet, herunder GitHub kommunikation i denne henseende.

## ASF's server

ASF kommunikerer med **[vores egen server](https://asf.justarchi.net)** for mere avanceret funktionalitet. Dette omfatter især:
- Verificerer checksums af ASF builds downloadet fra GitHub mod vores egen uafhængige database for at sikre, at alle downloadede builds er legitime (gratis malware, MITM-angreb eller anden manipulering)
- Henter liste over dårlige bots til filtrering, hvis du har holdt `FilterBadBots` globale konfigurationsindstilling aktiveret.
- Annoncerer din bot i **[vores liste](https://asf.justarchi.net/STM)** , hvis du har aktiveret `SteamTradeMatcher` i **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** og opfylder andre kriterier
- Downloader aktuelt tilgængelige bots at handle fra **[vores liste](https://asf.justarchi.net/STM)** hvis du har aktiveret `MatchActively` i **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** og opfylder andre kriterier

Som en sikkerhedsforanstaltning er det ikke muligt at deaktivere checksum verifikation for ASF bygninger. Du kan dog deaktivere auto-opdateringer helt, hvis du gerne vil undgå dette, som beskrevet ovenfor i GitHub sektionen.

Du kan deaktivere `FilterBadBots` indstilling, hvis du vil undgå at hente listen fra serveren.

Du kan beslutte at fravælge at blive annonceret i listen ved at deaktivere `PublicListing` flag i bot's **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** indstillinger. Dette kan være nyttigt, hvis du vil køre `SteamTradeMatcher` bot uden at blive annonceret på samme tid.

Download af bots fra vores liste er obligatorisk for `MatchActively` indstilling, du skal deaktivere denne indstilling, hvis du ikke er villig til at acceptere det.