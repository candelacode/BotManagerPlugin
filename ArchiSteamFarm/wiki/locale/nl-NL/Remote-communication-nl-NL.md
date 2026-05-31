# Communicatie op afstand

Deze sectie beschrijft de externe communicatie die ASF omvat, met inbegrip van nadere uitleg over hoe je het kunt beïnvloeden. Hoewel we niets hieronder beschouwen als kwaadaardig of ongewenst, en we zijn ook niet wettelijk verplicht om het openbaar te maken. We willen dat u de programmafunctionaliteit beter begrijpt, vooral met betrekking tot uw privacy en gegevens die worden gedeeld.

## Steam

ASF communiceert met Steam netwerk (**[CM servers](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), evenals **[Steam API](https://steamcommunity.com/dev)**, **[Steam winkel](https://store.steampowered.com)** en **[Steam community](https://steamcommunity.com)**.

Het is niet mogelijk om een van de bovenstaande communicatie uit te schakelen. omdat het de basis is waarop ASF is gebaseerd om de basisfunctionaliteit te leveren. Als je niet comfortabel bent met bovenstaand gebruik van ASF zul je ASF moeten vermijden.

## Steam groep

ASF communiceert met onze **[Steam groep](https://steamcommunity.com/groups/archiasf)**. De groep biedt je aankondigingen, vooral nieuwe versies, kritieke problemen, Steam problemen en andere dingen die belangrijk zijn om de community op de hoogte te houden. Het stelt u ook in staat om onze technische ondersteuning te gebruiken, door vragen te stellen, problemen op te lossen, problemen te melden of verbeteringen aan te brengen. Wanneer je inlogt, worden accounts die in ASF worden gebruikt automatisch lid van de groep.

Je kunt kiezen om je aan de groep deel te nemen door `SteamGroup` vlag uit te schakelen in bot's **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** instellingen.

## GitHub

ASF communiceert met **[GitHub API](https://api.github.com)** om **[ASF releases](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** op te halen voor de update functionaliteit. Dit wordt gedaan als onderdeel van auto-updates (als u **[`UpdatePeriode (`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** ingeschakeld), evenals `update` **[commando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Je kunt de communicatie van ASF met GitHub beïnvloeden via **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** eigenschap - het instellen op `Geen` resulteert in het uitschakelen van volledige update-functionaliteit. inclusief GitHub communicatie in dit opzicht.

## ASF's server

ASF communiceert met **[onze eigen server](https://asf.justarchi.net)** voor meer geavanceerde functionaliteit. Dit omvat met name de volgende aspecten:
- Controlebedragen van ASF builds gedownload van GitHub naar onze eigen onafhankelijke database om ervoor te zorgen dat alle gedownloade versies legitiem zijn (zonder malware, MITM-aanvallen of andere manipulatie)
- Ophalen van lijst met slechte bots voor het filteren als je `FilterBadBots` algemene configuratie-instelling is ingeschakeld.
- Announcing your bot in **[our listing](https://asf.justarchi.net/STM)** if you've enabled `SteamTradeMatcher` in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** and meet other criteria
- Downloaden van beschikbare bots om te handelen van **[onze lijst](https://asf.justarchi.net/STM)** als je `MatchActively` hebt ingeschakeld in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** en voldoet aan andere criteria

Als veiligheidsmaatregel is het niet mogelijk om checksum verificatie voor ASF uit te schakelen. Je kunt echter automatisch updates volledig uitschakelen als je dit wilt voorkomen, zoals hierboven beschreven in het GitHub gedeelte.

U kunt de instelling `FilterBadBots` uitschakelen als u wilt voorkomen dat de lijst van de server wordt opgehaald.

U kunt kiezen voor opt-out om te worden aangekondigd in de lijst door `Publicatie` vlag uit te schakelen in bot's **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** instellingen. Dit kan handig zijn als u `SteamTradeMatcher` bot wilt uitvoeren zonder op hetzelfde moment te worden aangekondigd.

Het downloaden van bots uit onze lijst is verplicht voor `MatchActively` instelling, je moet die instelling uitschakelen als je dat niet wil accepteren.