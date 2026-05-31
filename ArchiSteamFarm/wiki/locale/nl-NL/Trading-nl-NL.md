# Ruilhandel

ASF biedt ondersteuning voor Steam niet-interactieve (offline) transacties. Zowel het ontvangen (accepteren/weigeren) als het verzenden van transacties is direct beschikbaar en vereist geen speciale configuratie, maar heeft een onbeperkt Steam account nodig (de Steam account die al 5$ heeft uitgegeven in de winkel). Slechts beperkte handelsfunctionaliteit is beschikbaar voor beperkte accounts.

---

## Logisch

First of all, it's possible to disable **all** incoming trade offers, by using `DisableIncomingTradesParsing` flag in `BotBehaviour`. Als je dat gebruikt, zoals de naam impliceert, zal alle functionaliteit met betrekking tot inkomende transacties worden uitgeschakeld, die onder de standaard logica valt, evenals alle extra functies die beschikbaar zijn die afhankelijk zijn van het reageren op het inkomende handelsaanbod. Omdat de standaardinstellingen al niet-opdringerig zijn, je zou deze optie alleen moeten gebruiken als je absoluut niet van ASF van plan bent om iets te doen dat gerelateerd is aan de inkomende transacties.

De onderstaande verklaart logica wanneer inkomende transacties worden geparseerd, dat is de standaardoptie.

ASF zal altijd alle transacties accepteren, ongeacht de items, verzonden van gebruiker met `Master` (of hoger) toegang tot de bot. Dit staat niet alleen gemakkelijk het plunderen van stoomkaarten toe die door het bot worden bewerkt, maar maakt het ook mogelijk om Steam items te beheren die bot vastzet in de inventaris - inclusief die van andere spellen (zoals CS:GO).

ASF zal trade aanbod afwijzen, ongeacht inhoud, van elke (niet-meester) gebruiker die op de zwarte lijst staat van trading module. Blacklist is opgeslagen in standaard `BotName. b` database en kan worden beheerd via `tb`, `tbadd` en `tbrm` **[commando's](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Dit zou moeten werken als een alternatief voor het standaard gebruikersblok aangeboden door Steam - gebruik met de nodige voorzichtigheid.

ASF accepteert dat alle `loot`-achtige transacties worden verzonden over bots, tenzij `DontAcceptBotTrades` is aangegeven in `TradingPreferences`. Kortom: standaard `TradingPreferences` van `Geen` zal ervoor zorgen dat ASF automatisch transacties accepteert van gebruiker met `Master` toegang tot de bot (hierboven uitgelegd), evenals alle donatie transacties van andere bots die deelnemen aan ASF-processen.

Wanneer u `AcceptDonaties` inschakelt in uw `HandelsVoorkeuren`, ASF zal ook donatie handel accepteren - een handel waarin bot account geen items kwijtraakt. Deze eigenschap heeft alleen invloed op niet-bot accounts, omdat bot accounts worden beïnvloed door `DontAcceptBotTrades`. `AcceptDonaties` stelt u in staat om gemakkelijk donaties van andere mensen te accepteren en bots die niet deelnemen aan ASF-processen.

Het is leuk om op te merken dat `AcceptDonaties` geen **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, omdat er geen bevestiging nodig is als we geen items verliezen.

U kunt ook ASF handelingsmogelijkheden verder aanpassen door `TradingPreferences` dienovereenkomstig aan te passen. Een van de belangrijkste `TradingPreferences` functies is `SteamTradeMatcher` optie, die ervoor zorgt dat ASF ingebouwde logica gebruikt voor het accepteren van transacties die u helpen ontbrekende badges te vervolledigen, die bijzonder nuttig is in samenwerking met de openbare lijst van **[SteamTradeMatcher](https://www.steamtradematcher.com)</a>**, maar ook zonder die lijst kan werken. Het is hieronder verder beschreven.

---

## `SteamTradeMatcher`

Wanneer `SteamTradeMatcher` actief is, ASF zal gebruik maken van een vrij complex algoritme om te controleren of de handel aan STM-regels voldoet en ten minste neutraal tegenover ons is. De werkelijke logica is de volgende:

- Weiger de transactie als we iets kwijtraken behalve item types die zijn opgegeven in onze `MatchableTypes`.
- Verwerp de transactie als we niet ten minste hetzelfde aantal items ontvangen op basis van per spel, per type en per rariteit.
- Afwijzen van de handel als de gebruiker om speciale Steam zomer/winterse verkoopkaarten vraagt, en in de handel zit.
- Weiger de trade hold duration ( `MaxTradeHoldDuration` global config property
- Verwerp de handel als we geen `MatchEverything` hebben ingesteld, en het is slechter dan neutraal voor ons.
- Accepteer de handel als we deze niet afwijzen door middel van een van de bovenstaande punten.

Het is leuk om op te merken dat ASF ook overbetaling ondersteunt - de logica werkt goed wanneer de gebruiker iets extra's toevoegt aan de handel, zolang aan alle bovenstaande voorwaarden wordt voldaan.

De eerste vier weigeringen moeten voor iedereen vanzelfsprekend zijn. De laatste is de echte dupes-logica die de huidige stand van onze inventarisatie controleert en bepaalt wat de status van de handel is.

- Handel is **goed** als onze vooruitgang op weg is naar voltooiing vooruit. Voorbeeld: A (eer) -> A B (na)
- Handel is **neutraal** als onze vooruitgang op weg naar voltooiing in-tact blijft. Voorbeeld: A B (eer) -> A C (na)
- Handel is **bad** als onze voortgang op weg is naar voltooiingsdeclines. Voorbeeld: A C (eer) -> A (na)

STM werkt alleen op goede transacties, wat betekent dat gebruiker met STM voor dupes matching altijd alleen goede transacties voor ons mag voorstellen. ASF is echter liberaal en accepteert ook neutrale handel, omdat we in die handel eigenlijk niets verliezen, dus er is geen echte reden om ze af te wijzen. Dit is vooral handig voor uw vrienden, omdat zij uw buitensporige kaarten kunnen verwisselen zonder STM te gebruiken zolang je geen voortgang kwijtraakt.

Standaard zal ASF slechte transacties afwijzen - dit is bijna altijd wat je wilt als gebruiker. Maar u kunt optioneel `MatchEverything` inschakelen in uw `TradingPreferences` om ASF alle dupe transacties te laten accepteren, inclusief **slechte Eten**. Dit is alleen handig als u een 1:1 handelsbot onder uw account wilt uitvoeren. omdat je begrijpt dat **ASF je niet langer zal helpen om verder te gaan in de richting van badge voltooiing, en zorg dat je bereid bent helemaal je voltooide set te verliezen voor N dupes van dezelfde kaart**. Als je een handelsbot met opzet wilt draaien die **nooit** hoort een set te voltooien en zou de inventaris moeten aanbieden aan elke geïnteresseerde gebruiker, dan kan je die optie inschakelen.

Ongeacht uw gekozen `TradingPreferences`, een transactie die door ASF wordt afgewezen, betekent niet dat u het zelf niet kunt accepteren. Als je de standaardwaarde van `BotBehaviour`hebt behouden, die niet bevat `Afwijzen Onvalide Trades`, ASF zal deze transacties gewoon negeren - laat je zelf beslissen of je er geïnteresseerd in bent of niet. Hetzelfde geldt voor transacties buiten `MatchableTypes`, evenals alles - de module moet je helpen om STM trades te automatiseren, niet beslissen wat een goede handel is en wat niet. De enige uitzondering op deze regel is wanneer u spreekt over gebruikers die u op de zwarte lijst van handelsmodule hebt gezet met behulp van `tbadd` commando - transacties van deze gebruikers worden onmiddellijk afgewezen ongeacht `BotBehaviour` instellingen.

Het wordt sterk aangeraden om **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** te gebruiken wanneer u deze optie inschakelt, omdat deze functie zijn hele potentieel verliest als u besluit om handmatig elke transactie te bevestigen. `SteamTradeMatcher` werkt naar behoren zelfs zonder de mogelijkheid om transacties te bevestigen, maar het kan een backlog met bevestigingen genereren als je ze niet op tijd accepteert.