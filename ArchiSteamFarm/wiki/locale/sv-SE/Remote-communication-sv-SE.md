# Fjärrkommunikation

Detta avsnitt går vidare på fjärranalys som ASF inkluderar, inklusive ytterligare förklaring på hur man kan påverka den. Medan vi inte anser något nedan som skadliga eller på annat sätt oönskade, och varken vi är juridiskt skyldiga att avslöja det, vi vill att du bättre förstår programmets funktionalitet särskilt när det gäller din integritet och data som delas.

## Ånga

ASF kommunicerar med Steam-nätverket (**[CM-servrar](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), såväl som **[Steam API](https://steamcommunity.com/dev)**, **[Steam store](https://store.steampowered.com)** och **[Steam community](https://steamcommunity.com)**.

Det är inte möjligt att inaktivera någon av ovanstående kommunikation, eftersom det är kärnan stiftelsen ASF bygger på för att ge sin grundläggande funktionalitet. Du måste avstå från att använda ASF om du inte är bekväm med ovanstående.

## Ånggrupp

ASF kommunicerar med vår **[Steam-grupp](https://steamcommunity.com/groups/archiasf)**. Gruppen ger dig notiser, särskilt nya versioner, kritiska problem, Steam-problem och andra saker som är viktiga för att hålla gemenskapen uppdaterad. Det gör det också möjligt för dig att använda vår tekniska support genom att ställa frågor, lösa problem, rapportera problem eller föreslå förbättringar. Som standard kommer konton som används i ASF automatiskt att gå med i gruppen när du loggar in.

Du kan välja att inte ansluta till gruppen genom att inaktivera `SteamGroup` flaggan i botens **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** inställningar.

## GitHub

ASF kommunicerar med **[GitHubs API](https://api.github.com)** för att hämta **[ASF släpper](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** för uppdateringsfunktionaliteten. Detta görs som en del av automatiska uppdateringar (om du har behållit **[`Uppdateringsperiod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** aktiverad), samt `uppdatera` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Du kan påverka ASF:s kommunikation med GitHub genom **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** egenskap - sätt den till `Ingen` kommer att resultera i att inaktivera hela uppdateringsfunktionalitet, inklusive GitHub-kommunikation i detta avseende.

## ASF:s server

ASF kommunicerar med **[vår egen server](https://asf.justarchi.net)** för mer avancerad funktionalitet. Detta omfattar i synnerhet följande:
- Verifiera kontrollsummor av ASF bygger hämtade från GitHub mot vår egen oberoende databas för att säkerställa att alla nedladdade byggen är legitima (fri från skadlig kod, MITM-attacker eller annan manipulering)
- Hämtar lista över dåliga robotar för filtrering om du har behållit `FilterBadBots` globala konfigurationsinställningar aktiverade.
- Meddela din bot i **[vår lista](https://asf.justarchi.net/STM)** om du har aktiverat `SteamTradeMatcher` i **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** och uppfylla andra kriterier
- Hämtar för närvarande tillgängliga botar att handla från **[vår lista](https://asf.justarchi.net/STM)** om du har aktiverat `MatchActively` i **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** och uppfyller andra kriterier

Som en säkerhetsåtgärd är det inte möjligt att inaktivera verifiering av kontrollsummor för ASF-byggnader. Du kan dock inaktivera automatiska uppdateringar helt om du vill undvika detta, som beskrivs ovan i avsnittet GitHub.

Du kan inaktivera `FilterBadBots` inställningen om du vill undvika att hämta listan från servern.

Du kan välja att avanmäla dig från att visas i listningen genom att inaktivera `Publicera` flaggan i botens **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** inställningar. Detta kan vara användbart om du vill köra `SteamTradeMatcher` bot utan att tillkännages samtidigt.

Att ladda ner robotar från vår lista är obligatoriskt för `MatchActively` inställning, du måste inaktivera den inställningen om du inte vill acceptera det.