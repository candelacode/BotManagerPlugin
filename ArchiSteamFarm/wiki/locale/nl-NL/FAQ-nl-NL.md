# Veelgestelde vragen

Onze FAQ behandelt standaardvragen en antwoorden die je kunt hebben. Voor minder voorkomende zaken bezoek in plaats daarvan onze **[uitgebreide FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ)**.

# Inhoudsopgave

* [Algemeen](#general)
* [Vergelijking met soortgelijke gereedschappen](#comparison-with-similar-tools)
* [Beveiliging / Privacy / VAC / Bans / ToS](#security--privacy--vac--bans--tos)
* [Diversen](#misc)
* [Problemen](#issues)

---

## Algemeen

### Wat is ASF?
### Waarom beweert het programma dat er niets op mijn account te bewerken is?
### Waarom detecteert ASF niet al mijn spellen?
### Waarom is mijn account beperkt?

Voordat je probeert te begrijpen wat ASF is, moet je ervoor zorgen dat je begrijpt wat Steam-kaarten zijn. en hoe ze te verkrijgen, wat mooi wordt beschreven in de officiële FAQ **[hier](https://steamcommunity.com/tradingcards/faq)**.

Kortom: Steamkaarten zijn verzamelbare items waar je voor in aanmerking komt wanneer je een bepaald spel hebt, en kan worden gebruikt voor het maken van badges, het verkopen op de Steam markt of elk ander doel van je keuze.

Kernpunten worden hier nogmaals naar voren gebracht. omdat mensen het in het algemeen niet met hen eens willen zijn en liever doen alsof die niet bestaan:

- **U moet het spel bezitten op uw Steam account om in aanmerking te komen voor elke kaart die het gebruikt. Gezinsdelen is geen eigendom en telt niet.**
- **Je spel kan niet worden gemarkeerd als [privé](https://help.steampowered.com/faqs/view/1150-C06F-4D62-4966), ASF zal deze spellen automatisch overslaan tijdens het boerenbedrijf.**
- **Je kunt het spel niet oneindig bewerken, elk spel heeft een vast aantal kaartjes. Zodra je ze allemaal hebt laten vallen (ongeveer de helft van de volledige set), is het spel geen kandidaat meer voor het boerenbedrijf. Het maakt niet uit of je hebt verkocht, verhandeld, vervaardigd of vergeten wat er is gebeurd met de kaarten die je hebt gekregen, zodra je geen kaart meer hebt, is het spel klaar.**
- **Je kunt geen kaarten uit F2P-spellen laten vallen zonder er geld in uit te geven. Dit betekent permanent F2P spellen zoals Team Fortress 2 of Dota 2. Het bezit van F2P spellen geeft je geen kaartjes.**
- **Je kunt geen kaarten laten vallen op [beperkte accounts](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A), ongeacht eigen games en hun activatiemethode.**
- **Betaalde spellen die je gratis hebt gekregen tijdens een kortingsactie kunnen niet worden gekookt door kaart druppels, ongeacht wat er wordt weergegeven op de winkelpagina.**

Zo ziet je dat, Steam-kaarten worden uitgereikt voor het spelen van een spel dat je gekocht hebt. of het F2P-spel waar je geld in hebt gestoken. Als je dit spel lang genoeg speelt, zullen alle kaarten voor dat spel uiteindelijk in je inventaris komen te staan, maak het mogelijk om een badge in te vullen (na de resterende helft van de set te hebben ontvangen), deze te verkopen of te doen wat je maar wilt.

Nu we de basisprincipes van Steam hebben uitgelegd, kunnen we ASF uitleggen. Het programma zelf is behoorlijk complex om volledig te begrijpen, dus in plaats van in alle technische details in te graven, geven we hieronder een zeer vereenvoudigde uitleg.

ASF logt in op je Steam account via onze ingebouwde, aangepaste Steam client implementatie met je verstrekte inloggegevens. Na het succesvol inloggen het verwerkt je **[badges](https://steamcommunity.com/my/badges)** om spellen te vinden die beschikbaar zijn voor landbouw (`X` kaarten die resterend zijn). Na het parsen van alle pagina's en het bouwen van een definitieve lijst van spellen die beschikbaar zijn, kiest ASF het meest efficiënte landbouwalgoritme en start het proces. Het proces is afhankelijk van de gekozen **[kaarten landbouw algoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** maar meestal bestaat het uit het spelen van geldig spel en periodiek (plus op elk item drop) controleren of het spel al volledig gekookt is - als ja, ASF kan doorgaan met de volgende titel, met dezelfde procedure, totdat alle spellen volledig gekweekt zijn.

Houd er rekening mee dat bovenstaande verklaring vereenvoudigd is en geen tientallen extra functies en functies van ASF beschrijft. Bezoek de rest van **[onze wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki)** als je elk ASF detail wilt weten. Ik heb geprobeerd het makkelijk genoeg te maken om het voor iedereen te begrijpen, zonder technische details in te voeren - geavanceerde gebruikers worden aangemoedigd om dieper te graven.

Nu als programma - ASF biedt wat magie. Ten eerste, het hoeft geen van je spelbestanden te downloaden, het kan meteen spellen spelen. Ten tweede is het volledig onafhankelijk van je normale Steam client - je hoeft Steam client niet te laten draaien of zelfs helemaal te installeren. Ten derde is de geautomatiseerde oplossing - wat betekent dat ASF automatisch alles achter je rug doet. zonder dat je hoeft te vertellen wat je moet doen - wat je tijd en tijd bespaart. Tot slot hoeft het Steam netwerk niet te misleiden door middel van proces emulatie (welke bijvoorbeeld Idle Master gebruikt), omdat het direct met het kan communiceren. Het is ook super snel en lichtgewicht Het is een verbazingwekkende oplossing voor iedereen die gemakkelijk kaarten wil krijgen zonder veel gedoe - het is vooral handig door het op de achtergrond te laten draaien terwijl je iets anders doet. of zelfs in offlinemodus.

Alles wat hierboven staat is mooi, maar ASF heeft ook een aantal technische beperkingen die worden opgelegd door Steam - we kunnen geen spellen boerderijen fokken die je niet bezit, we kunnen geen spelletjes voor altijd boerderijen om extra druppels voorbij de afgedwongen limiet te krijgen, en we kunnen geen spelletjes verbouwen terwijl je aan het spelen bent. Dat zou allemaal "logisch" moeten zijn, gezien de manier waarop ASF werkt. maar het is leuk om op te merken dat ASF geen superbevoegdheden heeft en niet iets doet dat fysiek onmogelijk is. Dus houd dat in gedachten - het is in feite hetzelfde als dat je iemand hebt verteld om in te loggen op je account vanaf een andere PC en die spellen voor je te bouwen.

Dus om het samen te vatten - ASF is een programma waarmee je kaarten kunt laten vallen waarvoor je in aanmerking komt, zonder al te veel gedoe. Het biedt ook een aantal andere functies, maar laten we er nu mee doorgaan.

---

### Moet ik mijn accountgegevens invoeren?

**Ja**. ASF vereist je accountgegevens op dezelfde manier als de officiële Steam client doet, omdat het dezelfde methode voor Steam netwerk interactie gebruikt. Dit betekent echter niet dat je je accountgegevens in ASF-configuraties moet invoeren, je kan ASF blijven gebruiken met lege `SteamLogin` en/of `SteamPassword`, en voer die gegevens in voor elke ASF draait, indien nodig (evenals meerdere andere inloggegevens, verwijzen naar de configuratie). Op deze manier worden jouw gegevens nergens opgeslagen, maar ASF kan natuurlijk niet automatisch starten zonder jouw hulp. ASF biedt ook verschillende andere manieren om je **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**te verhogen, dus voel je vrij om dat deel van de wiki te lezen als je geavanceerde gebruiker bent. Zo niet, en je wilt je accountreferenties niet in ASF configureren, Doe dat dan gewoon niet, en voer ze in plaats daarvan zoals nodig in als ASF om hen vraagt.

Houd er rekening mee dat ASF-tool voor je persoonlijke gebruik is en dat je inloggegevens je computer nooit achterlaten. Je deelt ze ook niet met iemand, die volmaakt **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** - een heel belangrijk ding dat veel mensen vergeten. Je stuurt je gegevens niet naar onze servers of een derde partij, alleen direct naar Steam servers die door Radiatorkraan worden beheerd. We kennen uw inloggegevens niet en we zijn ook niet in staat om ze voor u te herstellen, ongeacht of u ze in uw configuraties plaatst of niet.

---

### Hoe lang moet ik wachten tot de kaarten uitvallen?

**zolang het** - serieus neemt. Elk spel heeft verschillende landbouwproblemen ingesteld door ontwikkelaar/uitgever, en het is helemaal aan hen om te zien hoe snelle kaarten worden geschrapt. De meerderheid van de partijen volgt 1 druppel per 30 minuten aan het spelen, maar er zijn ook spellen die van u verlangen om zelfs enkele uren te spelen voordat u een kaart laat vallen. Daarnaast kan je account worden beperkt in het ontvangen van kaartdrops van spellen die je nog niet genoeg tijd hebt gespeeld, zoals aangegeven in **[prestatie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** sectie. Probeer niet te raden hoe lang ASF een titel moet krijgen - het is niet aan jou, noch ASF om te beslissen. Er is niets dat je kunt doen om het sneller te maken, en er is geen "bug" gerelateerd aan kaarten die niet tijdig worden laten vallen - u heeft geen controle over het laten vallen van kaarten, en ASF. In het beste geval ontvangt u een gemiddelde van 1 druppel per 30 minuten. In het slechtste geval zul je zelfs 4 uur geen kaart meer ontvangen sinds ASF. Beide situaties zijn normaal en worden behandeld in onze **[prestatie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** sectie.

---

### Landbouw duurt te lang, kan ik het op de een of andere manier versnellen?

Het enige wat de snelheid van de landbouw zwaar beïnvloedt is geselecteerde **[kaarten landbouwalgoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** voor je bot instantie. Al het andere heeft een verwaarloosbaar effect en maakt de landbouw niet sneller, terwijl sommige acties, zoals het starten van de ASF-procedure, het **zelfs erger zullen maken**. Als u er werkelijk op aandringt om van het landbouwproces elke seconde de tweede te maken. vervolgens stelt ASF je in staat om enkele kern-landbouwvariabelen zoals `FarmingDelay` - ze worden allemaal uitgelegd in **[configuratie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Zoals ik echter al zei, is het effect verwaarloosbaar. en het kiezen van echte kaarten landbouwalgoritme voor gegeven account is één en de enige cruciale keuze die de snelheid van de landbouw sterk kan beïnvloeden, Al het andere is puur cosmetisch. In plaats van zich zorgen te maken over landbouwsnelheid, Start gewoon ASF en laat het zijn werk doen - ik kan je verzekeren dat het de meest effectieve manier is waarop ik kon komen. Hoe minder u zich voelt, hoe meer u tevreden zult zijn.

---

### Maar ASF heeft gezegd dat het ongeveer X tijd zal kosten voor de landbouw!

ASF geeft je ruwe geschatte op basis van het aantal kaarten dat je moet laten vallen, en jouw gekozen algoritme - dit ligt niet bij de werkelijke tijd die je gaat besteden aan het kweken, die meestal langer is dan dit, omdat ASF alleen het beste geval aanneemt en alle Steam Netwerk kwartieren negeert, internet verbreekt de verbindingen, overbelasting van Steam servers en op vergelijkbare wijze. Het moet alleen worden gezien als een algemene indicator hoe lang ASF landbouwer kan worden, Heel vaak in het beste geval, want de feitelijke tijd zal verschillen, zelfs in sommige gevallen aanzienlijk. Zoals hierboven werd aangegeven, probeer niet te raden hoe lang een gegeven spel zal worden verduren, het is niet aan jou, noch ASF om te beslissen.

---

### Kan ASF werken op mijn Android / smartphone?

ASF is een C# programma dat werkimplementatie van .NT vereist. Android is een geldig platform geworden vanaf .NET 6. , op dit moment is er echter een grote blocker om ASF te laten gebeuren op Android als gevolg van het ontbreken van **[ASP. ET runtime beschikbaar](https://github.com/dotnet/aspnetcore/issues/35077)**. Hoewel er geen inheemse optie beschikbaar is, zijn er goede en werkende builds voor GNU/Linux op ARM-architectuur, dus het is volledig mogelijk om iets als **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** te gebruiken voor het installeren van Linux, dan ASF gebruiken in dergelijke Linux-chroot zoals gebruikelijk.

Wanneer/als alle ASF-vereisten zijn voldaan, overwegen we een officiële Android-versie vrij te geven.

---

### Kan ASF voorwerpen van Steam spellen zoals CS:GO of niet draaien?

**Geen**, dit is tegen **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** en Radiatorkraan hebben duidelijk verklaard dat met de laatste golf van communityverboden voor het kweken van TF2 items. ASF is een Steamkaarten-landbouwprogramma, geen spelitems - het heeft geen mogelijkheden om spel te bewerken, en het is niet van plan om dergelijke functies toe te voegen in de toekomst, ooit, voornamelijk vanwege het schenden van Steam-gebruiksvoorwaarden. Vraag hier alstublieft niet naar - het beste dat u kunt krijgen is een melding van een of andere zout gebruiker en u heeft problemen. Hetzelfde geldt voor alle andere vormen van landbouw, zoals het verdwijnen van landbouw uit CS:GO-uitzendingen. ASF richt zich uitsluitend op Steam-handelskaarten.

---

### Kan ik kiezen welke spellen moeten worden uitgevoerd?

**Ja**, op verschillende manieren. Als u de standaard volgorde van de wachtrij wilt wijzigen, dan kan `FarmingOrders` **[bot configuratie eigenschap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** gebruikt worden. Als je handmatig wilt blacklist spellen die automatisch worden gekweekt, je kan een inactieve blacklist gebruiken die beschikbaar is bij `fb` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Als je alles wilt kweken, maar geef enkele apps voorrang boven alles. daar is een inactieve prioriteitswachtrij beschikbaar met `fq` **[opdracht](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** kan worden gebruikt. En tot slot, als u alleen specifieke spelletjes wilt spelen met uw eigen keuze. dan kan je `FarmPriorityQueueOnly` opgeven in bot's **[`BoeringVoorkeuren`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)** om dit te bereiken samen met het toevoegen van uw geselecteerde apps aan de wachtrij met prioriteit.

Naast het beheren van bovenstaande landbouwmodule voor automatische kaarten je kan ASF ook overschakelen naar de handmatige landbouwmodus met `play` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, of gebruik andere misc externe instellingen zoals `GamesPlayedWhileIdle` **[bot configuratie eigenschap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

---

### Ik ben niet geïnteresseerd in het droppen van kaarten, zou ik graag de gespeelde uren willen boerderen?

Ja, met ASF kun je dat op zijn minst meerdere manieren doen.

De beste manier om dat te bereiken is door gebruik te maken van **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** configuratie eigenschap, die jouw gekozen appIDs zal afspelen wanneer ASF geen kaarten mag boerderen. Als je je voortdurend spellen wilt spelen, zelfs als je kaarten hebt uit andere spellen, dan kan je het combineren met **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, ASF werkt dus alleen die spellen voor kaartjes die jij expliciet hebt ingesteld, of als alternatief **[`FarmingPausedByStandaard`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, dit zal ervoor zorgen dat de landbouwmodule voor kaarten wordt gepauzeerd totdat u deze zelf loskoppelt.

Je kunt ook gebruik maken van het **[`play`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#commands-1)** commando, waardoor ASF de geselecteerde spellen zal spelen. Houd er echter rekening mee dat `play` alleen mag worden gebruikt voor spellen die je tijdelijk wilt spelen. omdat het geen aanhoudende staat is, waardoor ASF terugkeert naar de standaard staat. . wanneer de verbinding van het Steam netwerk wordt verbroken. Daarom raden we je aan om `GamesPlayedWhileIdle`te gebruiken, tenzij je inderdaad je geselecteerde spellen wilt starten voor een korte periode, en dan terug naar de algemene stroom.

---

### Ik ben Linux / macOS-gebruiker, zal ASF landbouwspellen die niet beschikbaar zijn voor mijn besturingssysteem? Zal ASF 64-bits spellen hebben als ik deze op een 32-bits besturingssysteem loop?

Ja, ASF stoort niet eens bij het downloaden van de werkelijke spelbestanden, dus zal het werken met alle licenties die zijn gekoppeld aan je Steam account, ongeacht eventuele platform of technische vereisten. Het zou ook moeten werken voor spellen gekoppeld aan specifieke regio (region-locked games) zelfs als je niet in de overeenkomende regio bent, hoewel we dat niet garanderen (de laatste keer dat we het hebben geprobeerd).

---

## Vergelijking met soortgelijke gereedschappen

---

### Is ASF vergelijkbaar met Idle Master?

De enige gelijkenis is het algemene doel van beide programma's, dat is Steam-spellen verzamelen om kaart druppels te ontvangen. Alle andere methoden, inclusief de eigenlijke landbouwmethode, programmastructuur, functionaliteit, compatibiliteit, gebruikte algoritmen, vooral de broncode zelf. is totaal anders en die twee programma's hebben niets gelijks met elkaar, zelfs de kern - het IM loopt voort op . ET Framework, ASF op .NET (Core). ASF is gemaakt om IM-problemen op te lossen die niet opgelost konden worden met een eenvoudige code edit - daarom is ASF van nul geschreven, zonder gebruik te maken van één regel, of zelfs een algemeen idee van IM, omdat die code en die ideeën aanvankelijk helemaal niet kloppen. IM en ASF zijn zoals Windows en Linux - beide zijn besturingssystemen en beide kunnen worden geïnstalleerd op uw PC, maar ze delen bijna niets met elkaar, behalve dat ze hetzelfde doel dienen.

Daarom moet je ASF ook niet vergelijken met IM gebaseerd op IM verwachtingen. Je moet ASF en IM behandelen als volledig onafhankelijke programma's met hun eigen exclusieve set functies. Sommige daarvan overlappen elkaar inderdaad en u vindt er een bijzonder kenmerk in. maar zelden omdat ASF zijn doel dient met een totaal andere aanpak dan IM.

---

### Is het de moeite waard om ASF te gebruiken, als ik Idle Master gebruik en het goed werkt voor mij?

**Ja**. ASF is veel betrouwbaarder en bevat veel ingebouwde functies die **cruciaal** zijn, ongeacht de manier waarop je boerderij maakt, dat IM biedt gewoon niet.

ASF heeft de juiste logica voor **niet vrijgegeven spellen** - IM zal proberen games te bewerken die al kaarten hebben toegevoegd, zelfs als ze nog niet zijn vrijgelaten. Het is natuurlijk niet mogelijk om deze spellen te fokken tot de vrijgavedatum, dus je landbouwproces zal vastlopen. Dit vereist dat u het op de zwarte lijst toevoegt, wacht op de release, of sla het handmatig over. Geen van deze oplossingen is goed, en ze vereisen allemaal je aandacht - ASF slaat automatisch het kweken van niet-vrijgegeven spellen over (tijdelijk), en kom later terug wanneer ze het probleem volledig uit de weg gaan en efficiënt aanpakken.

ASF heeft ook een goede logica van **series** video's. Er zijn veel video's op Steam met kaarten, maar worden met verkeerde `appID` aangekondigd op de badges pagina. zoals **[Dubbel Fijn Avontuur](https://store.steampowered.com/app/402590)** - IM zal faliekant boerenfout maken `appID`, die geen druppels en geen proces zal opleveren. Nogmaals, je moet het of blacklisten, of handmatig overslaan, beide vereisen je aandacht. ASF ontdekt automatisch de juiste `appID` voor landbouw die resulteert in kaart dalingen.

Daar komt nog bij dat ASF is **veel stabieler en betrouwbaarder** wanneer het aankomt op netwerkproblemen en Steam-eigenaren - het werkt de meeste tijd en hoeft geen aandacht te hebben wanneer het eenmaal is geconfigureerd. terwijl IM vaak voor veel mensen pakt, extra reparaties vereist of gewoon niet werkt. Het is ook volledig afhankelijk van je Steam client, wat betekent dat het niet kan werken wanneer je Steam client ernstige problemen ondervindt. ASF werkt goed zolang het verbinding kan maken met een Steam-netwerk, en vereist niet dat Steam-client wordt uitgevoerd of zelfs wordt geïnstalleerd.

Dit zijn 3 **zeer belangrijke** punten waarom je zou moeten overwegen ASF te gebruiken. omdat ze rechtstreeks van invloed zijn op iedereen Steamkaarten en er geen manier is om te zeggen "dit is niet van mij", omdat er overal stoomwentelingen en eigenaardigheden plaatsvinden. Er zijn tientallen extra belangrijke redenen waarover je in de rest van de FAQ zou kunnen leren. Dus binnenkort **yes**, je moet ASF gebruiken, zelfs als je geen extra ASF functie nodig hebt die beschikbaar is in vergelijking met IM.

Bovendien wordt de IM officieel stopgezet en kan het in de toekomst volledig doorbreken. zonder dat iemand de moeite neemt om het op te lossen, gezien het bestaan van veel krachtiger oplossingen (niet alleen ASF). IM werkt al niet voor veel mensen en dat aantal gaat alleen maar omhoog, niet omlaag. U moet het gebruik van verouderde software in de eerste plaats voorkomen, niet alleen het IM, maar ook alle andere verouderde programma's. Geen actieve onderhouder betekent dat niemand kan schelen of het werkt of niet, en **is verantwoordelijk voor de functionaliteit**, dat voor de veiligheid van cruciaal belang is. Het is genoeg dat er een kritieke bug zal zijn die echte problemen veroorzaakt aan Steam-infrastructuur - zonder dat iemand het repareert Steam kan een andere ban golf uitvaardigen waarin je geraakt wordt zonder dat je weet dat dit een probleem is. zoals al gebeurd is met mensen die gebruikten, raad eens wat verouderde versie van ASF.

---

### Welke interessante functies ASF biedt Idle Master niet?

Het hangt af van wat u als "interessant" beschouwt. Als je van plan bent om meer rekeningen te bewerken dan één, dan is het antwoord al duidelijk, aangezien ASF je in staat stelt ze allemaal te bewerken met één superieure oplossing, sparen van hulpbronnen, gedoe en compatibiliteitsproblemen. Als je die vraag echter stelt, heb je waarschijnlijk niet deze specifieke behoefte. dus laten we andere voordelen evalueren die gelden voor één enkel account dat wordt gebruikt in ASF.

In de eerste plaats je hebt een aantal ingebouwde functies genoemd **[boven](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** die kern zijn voor de landbouw ongeacht je einddoel, en heel vaak is dat alleen al voldoende om het gebruik van ASF te overwegen. Maar dat weet u al, dus laten we nu overgaan tot enkele interessante eigenschappen:

- **Je kunt offline** bewerken (`OnlineStatus` in `Offline` setting. Landbouw offline maakt het mogelijk dat je je Steam in-game status volledig overslaat, waarmee je ASF kunt bewerken terwijl je "Online" op Steam tegelijkertijd laat zien zonder dat je vrienden zelfs maar merken dat ASF een spel voor jou speelt. Dit is een superieure functie, omdat het je in staat stelt om online te blijven in je Steam client, zonder je vrienden te irriteren met constante spelveranderingen. of misleid ze om te denken dat je een spel speelt, terwijl je dat in werkelijkheid niet doet. Dit punt alleen al maakt het de moeite waard ASF te gebruiken als je je eigen vrienden respecteert, maar het is nog maar het begin. Het is ook leuk om op te merken dat deze functie niets te maken heeft met Steam privacy instellingen - als u het spel zelf lanceert dan zul je als in-game aan je vrienden laten zien, waardoor alleen ASF onderdeel onzichtbaar wordt en je account helemaal niet wordt beïnvloed.

- **Je kan spellen overslaan** (`SkipRefundableGames` in bot's `FarmingPreferences` functie). ASF heeft de juiste ingebouwde logica voor het terugverdienen van spellen en je kunt ASF configureren om spellen niet automatisch terug te krijgen. Dit stelt je in staat om jezelf te beoordelen als je nieuw aangekochte spel van Steam winkel je geld waard was, zonder dat ASF de kaarten er zo snel mogelijk uit probeert te halen. Als je het 2 uur speelt, of 2 weken voorbij sinds je aankoop, daarna zal ASF doorgaan met dat spel omdat het niet meer terugbetaalbaar is. Tot dan hebt u de volledige controle of u er al dan niet van houdt en kunt u deze gemakkelijk terugbetalen indien nodig. zonder dat je dit spel handmatig hoeft te blacklist of geen ASF gebruikt voor de hele duur.

- **Je kan onspeelde spellen overslaan** (`SkipUnplayedGames` in bot's `FarmingPreferences` functie). ASF heeft een goede ingebouwde logica voor uren in spellen en je kunt ASF configureren om geen onspeelde spellen automatisch te kunnen fokken. Dit stelt je in staat om jezelf te besturen van de spellen die je speelt en boerderijen, zonder ze handmatig te blacklist of ga over met ASF als geheel.

- **U kunt automatisch nieuwe items markeren als ontvangen** (`BotGedrag` of `DismissInventoryNotifications` functie). Het telen met ASF zal ervoor zorgen dat je account nieuwe creditcarddalingen ontvangt. Je weet al dat dit zal gebeuren, dus laat ASF deze nutteloze melding voor je wissen, ervoor te zorgen dat alleen belangrijke zaken uw aandacht opwekken. Natuurlijk alleen als je dat wilt.

- **U kunt de voorkeursbestelling aanpassen met meer opties** (`BoeringOrders` functie). Misschien wil je je nieuw gekochte spellen eerst kopen? Of uw oudste Op basis van het aantal gevallen van een kaart? Badge levels die je al hebt gemaakt? Afgespeelde uren? Alfabetisch? Volgens AppID's? Of misschien volledig willekeurig? Dat is helemaal aan jou om te beslissen.

- **ASF kan u helpen uw sets** te voltooien (`TradingPreferences` met `SteamTradeMatcher` functie). Met een beetje geavanceerder verkleinen je kunt ASF omzetten in een volledige gebruikers-bot die automatisch **[STM](https://www.steamtradematcher.com)** aanbiedingen zal accepteren, help je elke dag te koppelen aan je sets zonder enige gebruikersinteractie. ASF bevat zelfs een eigen ASF 2FA module waarmee je je Steam mobiele authenticator kunt importeren en je het hele proces volledig kan automatiseren met het accepteren van bevestigingen. Of, wilt u misschien handmatig accepteren en ASF alleen deze transacties op u laten voorbereiden? Ook dat is weer volledig aan jou om te beslissen.

- **ASF kan sleutels inwisselen op de achtergrond van je** (**[achtergrond spellen die](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** functie gebruiken). Misschien heb je honderden sleutels van verschillende bundels die je te lui bent om zelf in te wisselen door een heleboel ramen gaan en Steam-voorwaarden steeds opnieuw accepteren. Waarom kopieer en plak je lijst met sleutels niet in ASF en laat het zijn werk doen? ASF zal al deze sleutels automatisch inwisselen op de achtergrond, waardoor je de juiste uitvoer krijgt om je te laten weten hoe elke inwisselpoging is verlopen. Bovendien, als je honderden sleutels hebt, wordt je gegarandeerd beperkt door Steam en zal je vroeg of laat worden en ASF weet dat ook al, het zal geduldig wachten tot de prijslimiet verdwijnt en verdergaan waar hij gebleven is.

We kunnen nu verder gaan met hele **[ASF wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**, alle functies van het programma eruit lichten, maar we moeten ergens een grens trekken. Dit is het, dit is een lijst met functies die je als ASF-gebruiker kunt genieten, waar slechts één van die twee gemakkelijk als een belangrijke reden kan worden beschouwd om nooit terug te kijken. en we hebben eigenlijk **veel** genoemd, met nog meer kun je leren over de rest van onze wiki. Ah ja, en we hebben niet eens in detail getreden met zaken als ASF's API waarmee u uw eigen commando's kunt scripteren, of geweldige bots management, omdat we het simpel wilden houden.

---

### Is ASF sneller dan Idle Master?

**Ja**, maar de uitleg is nogal ingewikkeld.

Bij elk nieuw proces is gespawned en beëindigd op je systeem Steam-client stuurt automatisch een verzoek met al je spellen die je momenteel aan het spelen bent - op deze manier kan stoomnetwerk uren berekenen en kaarten laten vallen. Het stoomnetwerk telt echter de tijd die in 1 seconde intervallen wordt gespeeld, en het versturen van een nieuw verzoek stelt de huidige status opnieuw in. Met andere woorden, als je elke 0.5 seconde een nieuw proces hebt gespawn/gedood, dan zul je nooit een kaart laten vallen want elke 0. De tweede stoomclient zou een nieuw verzoek sturen en stoomnetwerk zou nooit eens één seconde speltijd tellen. Bovendien, door hoe operating system werkt, is het eigenlijk vrij gebruikelijk om te zien dat nieuwe processen worden voortgebracht/beëindigd zonder dat je iets doet. dus zelfs als je niets doet op je PC - er zijn nog veel processen die nog steeds werken op de achtergrond, spawnen/beëindigen van andere processen. Idle master is gebaseerd op stoomcliënt, dus dit mechanisme beïnvloedt je als je het gebruikt.

ASF is niet gebaseerd op stoomcliënt, het heeft zijn eigen stoomklant. Dankzij dat, wat ASF doet, is het niet spawnen van een proces, maar eigenlijk één, echt verzoek om stoomnetwerk te versturen, dat we een spel begonnen te spelen. Dit is hetzelfde verzoek dat verzonden zou worden door de Steam client, maar omdat we de werkelijke controle hebben over de ASF-stuurprogramma hoeven we geen nieuwe processen te spawnen, en we mimiteren geen stoomcliënt voor het verzenden van verzoek bij elke proceswijziging, dus het bovenstaande mechanisme heeft geen invloed op ons. Daardoor onderbreken we die tweede interval op de stoominternetzijde nooit en dat verhoogt onze landbouwsnelheid.

---

### Maar is het verschil echt merkbaar?

Nee. De onderbrekingen met normale stoomcliënt en inactieve meester hebben een verwaarloosbaar effect op de kaartdalingen. Dus het is geen merkbaar verschil dat ASF superieur zou maken.

Er is echter **een verschil** en u kunt dat duidelijk merken, afhankelijk van hoe druk uw OS is. kaarten **zullen** sneller druppelen, van een paar seconden tot zelfs een paar minuten, als je extreem ongelukkig bent. Hoewel ik niet zou overwegen ASF alleen te gebruiken omdat het kaarten sneller laat vallen, omdat zowel ASF als Idle Master beïnvloed worden door hoe stoom web werkt. ASF interacties met een stoommachtigd web zijn effectiever terwijl Idle Master niet kan bepalen wat de stoomcliënt feitelijk doet (dus het is niet Idle Master's schuld, maar de steam client zelf).

---

### Kan ASF meerdere spellen tegelijk produceren?

**Ja**, hoewel ASF beter weet wanneer deze functie moet worden gebruikt, gebaseerd op het geselecteerde **[kaarten farming algoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Kaart drops wanneer meerdere spellen dicht bij nul zijn, Dit is de reden waarom ASF meerdere spellen uitsluitend gedurende uren gebruikt om `HoursUntilCardDrops` sneller te beheren, voor maximaal `32` spellen tegelijk. Dit is ook de reden waarom je je zou moeten concentreren op het configuratie-gedeelte van de ASF en laat algoritmen bepalen wat de beste manier is om het doel te bereiken - wat volgens jou juist is. In werkelijkheid hoeft het niet per se juist te zijn om meerdere spelletjes tegelijk te kweken en je geen kaartjes te geven.

---

### Kan ASF snel door spellen heen?

**Nee**, ASF ondersteunt dit niet, noch moedigt gebruik aan van **[Steam glitches](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance#steam-glitches)**.

---

### Kan ASF gedurende X uur automatisch elk spel spelen voordat de kaarten worden toegevoegd?

**Nee**, het hele punt van Steam-kaarten systeem veranderde door te vechten met valse statistieken en spookspelers. ASF zal daar niet meer dan nodig aan bijdragen. Het toevoegen van een dergelijke functie is niet gepland en zal niet gebeuren. Als je spel op de gebruikelijke manier een creditcard ontvangt zal ASF ze zo snel mogelijk boerderijen.

---

### Kan ik een spel spelen terwijl ASF aan het verbouwen is?

**Geen**. ASF heeft, in tegenstelling tot sommige andere tools die integreren met jouw Steam client, zijn onafhankelijke implementatie van die client inclusief en het Steam netwerk staat slechts **één Steam client tegelijk** toe om een spel te spelen. Je kan ASF echter op elk moment ontkoppelen door een spel te starten (en op "OK" te klikken wanneer gevraagd wordt of een andere client moet worden losgekoppeld) - ASF zal geduldig wachten tot je klaar bent met spelen, en daarna het proces hervatten. Je kunt ook nog steeds offline modus spelen op elk gewenst moment, als dat voor je bevredigend is.

Houd in gedachten dat kaarten een drop rate hebben bij het spelen van meerdere spellen toch bijna nul is. Er zijn dus geen directe voordelen als we dat met een aantal andere instrumenten kunnen doen. terwijl er sterke voordelen zijn dat we ons niet bemoeien met andere spellen die gestart zijn met ASF, wat cruciaal is. . VAC-wijs.

---

## Beveiliging / Privacy / VAC / Bans / ToS

---

### Kan ik VAC-verbod krijgen om dit te gebruiken?

Nee, dat is niet mogelijk omdat ASF (in tegenstelling tot andere tools zoals Idle Master, Idle SGI of SAM) mengt zich op geen enkele manier met stoomcliënt of zijn processen. Het is fysiek onmogelijk om VAC-ban te krijgen voor het gebruik van ASF. zelfs tijdens het spelen op beveiligde servers terwijl ASF actief is - dit komt omdat **ASF niet eens vereist dat Steam Client helemaal** geïnstalleerd is om goed te werken. ASF is een van de weinige landbouwprogramma's die op dit moment VAC-vrij kunnen garanderen.

---

### Kan ASF gebruiken om te voorkomen dat ik speel op door VAC-beveiligde servers, zoals aangegeven **[hier](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**?

ASF vereist niet dat de Steam client actief of zelfs geïnstalleerd is. Volgens dit concept zou **niet** geen VAC-gerelateerde problemen moeten veroorzaken. omdat ASF onvoldoende bemoeien heeft met Steam-client en al zijn processen. Dit is het belangrijkste punt wanneer je praat over VAC-vrije garantie die ASF biedt.

Volgens de gebruikers en mijn beste kennis is dat nu het geval. omdat niemand problemen heeft gerapporteerd zoals aangegeven in de link hierboven terwijl er ASF wordt gebruikt. We konden de bovenstaande kwestie met ASF niet ook reproduceren terwijl het duidelijk met Idle Master reproduceert.

Houd er echter rekening mee dat Radiatorkraan op een gegeven moment nog ASF aan de zwarte lijst kan toevoegen. maar het is volslagen onzin alsof ze dat wel doen. je kan nog steeds VAC-beveiligde spellen spelen van je PC, en ASF tegelijkertijd gebruiken. . op je server, dus ik ben er vrij zeker van dat ze heel goed weten dat ASF geen verdachte VAC-wise, zou moeten zijn en ze zullen onze liften niet moeilijker maken door ASF zonder reden te blokkeren. Toch zal je in het slechtste geval niet kunnen spelen, zoals hierboven gezegd, omdat VAC-vrije garantie van ASF hier nog steeds is, ongeacht de Steam blacklist ASF binary, of niet (en je kan ASF nog steeds opstarten op een andere machine zonder dat Steam client überhaupt geïnstalleerd is). Dat hoeven we op dit moment niet te doen, en laten we hopen dat het zo blijft.

---

### Is het veilig?

Als je vraagt of ASF veilig is als software, betekent dit dat het geen schade aan je computer zal veroorzaken, zal je privégegevens niet stelen, virussen of andere dergelijke dingen installeren - het is veilig. ASF is vrij van malware, data stelen, cryptocurrency miners en alle (en alle) andere twijfelachtige gedragingen die door de gebruiker als kwaadaardig of ongewenst kunnen worden beschouwd. Daarnaast hebben we een speciale **[remote communicatie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** sectie die betrekking heeft op ons privacybeleid en ASF gedrag dat verder gaat dan wat je zelf hebt geconfigureerd.

Onze code is open-source, en gedistribueerde binaries worden altijd gecompileerd uit **[openbare bronnen](https://en.wikipedia.org/wiki/Open-source_software)** door **[geautomatiseerde en vertrouwde continue integratie systemen](https://en.wikipedia.org/wiki/Build_automation)**, en zelfs de ontwikkelaars zelf niet. Elke build wordt reproduceerbaar door het volgen van ons build script en zal resulteren in precies hetzelfde, **[deterministische](https://en.wikipedia.org/wiki/Deterministic_system)** IL (binary) code. Als je om welke reden dan ook onze gebouwen niet vertrouwt, kan je ASF altijd compileren en gebruiken vanaf de bron, inclusief alle bibliotheken die ASF gebruikt (zoals SteamKit2), die ook open source zijn.

Uiteindelijk is het echter altijd een kwestie van vertrouwen voor de ontwikkelaar(s) van uw applicatie, dus moet je zelf beslissen of je ASF al dan niet veilig vindt, met hierboven gespecificeerde technische argumenten. Geloof niet blindelings iets alleen maar omdat we het gezegd hebben - controleer uzelf, want dat is de enige manier om zeker te zijn.

---

### Kan ik hierdoor verbannen worden?

Om die vraag te beantwoorden, moeten we een kijkje nemen op **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Steam verbiedt het gebruik van meerdere accounts niet, inderdaad, **[staat het toe](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)** te suggereren dat u dezelfde mobiele authenticator kunt gebruiken op meerdere accounts. Wat het echter niet toestaat is het delen van accounts met andere mensen, maar dat doen we hier niet.

Het enige echte punt dat ASF beschouwt is het volgende:
> Je mag geen Cheats, Automation software (bots), mods, hacks of andere ongeoorloofde software van derden gebruiken om elk Subscription Marketplace proces aan te passen of te automatiseren.

De vraag is wat eigenlijk een proces van Subscription Marketplace is. Zoals we kunnen lezen:

> Een voorbeeld van een Subscription Marketplace is de Steam Community Market

We wijzigen het marktproces van abonnementen niet of automatiseren, als we via de marktplaats van abonnementen de stoomgemeenschap of de stoomwinkel begrijpen. Gezond...

> Radiatorkraan kan uw account of een bepaald abonnement op elk gewenst moment annuleren in het geval dat (a) Valve stopt met het verstrekken van dergelijke abonnementen aan vergelijkbare abonnementen in het algemeen of (b) u schendt alle voorwaarden van deze overeenkomst (inclusief eender welk abonnement of regels van toepassing).

Daarom, zoals bij elke Steam software, ASF is niet geautoriseerd door Radiatorkraan en ik kan u niet garanderen dat u niet wordt geschorst als Valve ineens besluit dat ASF nu een account gebruikt. Dit is uiterst onwaarschijnlijk gezien het feit dat ASF wordt gebruikt op meer dan een paar miljoen Steam-accounts, sinds zijn eerste vrijlating gebeurde dat meer dan tien jaar geleden - maar nog steeds een mogelijkheid, ongeacht de reële waarschijnlijkheid.

Vooral omdat:
> Met betrekking tot alle abonnementen, inhoud en diensten die niet door Radiatorkraan worden geschreven, Radiatorkraan geeft geen scherm dat dit soort inhoud van derden beschikbaar is op Steam of via andere bronnen. Radiatorkraan neemt geen verantwoordelijkheid of aansprakelijkheid voor de inhoud van een dergelijke derde partij. Een aantal applicatiesoftware van derden kan door bedrijven voor zakelijke doeleinden worden gebruikt - echter u kunt dergelijke software alleen verkrijgen via Steam voor persoonlijk gebruik.

Echter, Radiatorkraan erkent duidelijk dat "Steam idlers" bestaat, zoals gezegd **[hier](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**, dus als je mij vraagt, Ik ben er vrij zeker van dat als ze er niet goed mee waren, ze al iets zouden doen in plaats van erop te wijzen dat ze VAC-wijs problemen kunnen veroorzaken. Het sleutelwoord hier is **Steam** idlers, bijvoorbeeld ASF, en niet **game** idlers.

Houd er rekening mee dat hierboven alleen onze interpretatie is van **[Steam ToS](https://store.steampowered.com/subscriber_agreement)</a>** en verschillende punten - ASF heeft een licentie onder Apache 2. Licentie, die duidelijk staat:

```
Tenzij de toepasselijke wetgeving vereist of inschrijfbaar is aangenomen, wordt software
die onder de licentie wordt gedistribueerd via een "AS IS" BASIS,
WITHOUT GARANTIES OF CONDITIONS VAN EEN KIND, uitdrukken of impliceren.
```

U gebruikt deze software op eigen risico. Het is extreem onwaarschijnlijk dat je hiervoor verbannen kunt worden, maar als je dat wel doet, kun je dat alleen zelf kwalijk nemen.

---

### Is er iemand voor verbannen?

**Ja**, we hebben tot nu toe minstens een paar incidenten gehad die hebben geleid tot een soort Steam opschorting. Of ASF zelf de oorzaak was of niet, is een heel ander verhaal dat we waarschijnlijk nooit zullen weten.

De eerste geval betrof een man met meer dan 1000+ bots die handel verbannen krijgen (samen met alle bots), Waarschijnlijk door overmatig gebruik van `loot ASF` op alle bots uitgevoerd of andere verdachte eenzijdige handel in een zeer korte tijd.

> Hallo XXX, Bedankt voor het contacteren van Steam Support. Het lijkt erop dat dit account is gebruikt om een netwerk van bot-accounts te beheren. Het bouwen is een schending van de Akkoorden van Steam-abonnees.

Gebruik alsjeblieft wat gezond verstand en ga er niet van uit dat je zulke krankzinnige dingen alleen kunt doen omdat ASF je toestaat om dat te doen. `loot ASF` uit op meer dan 1k bots kan gemakkelijk als een **[DDoS](https://en.wikipedia.org/wiki/DDoS)** aanval worden beschouwd, en persoonlijk ben ik niet geschokt dat iemand zoiets verboden heeft. Hou minimum aan eerlijk gebruik met betrekking tot Steam-service, en **waarschijnlijk** ben je prima.

Tweede zaak ging over een man met meer dan 170 bots die verbannen werden tijdens de Winter verkoop van Steam's 2017 in de winterverkoop.

> Uw account werd geblokkeerd wegens schending van de overeenkomst van abonnee Steam. Te oordelen naar uitwisselingen en andere factoren werd dit account gebruikt om illegaal verzamelde kaarten op stoom te verzamelen. naast aanverwante en niet alleen commerciële activiteiten. Het account is permanent geblokkeerd en Steam Support kan geen extra ondersteuning bieden voor dit probleem.

Deze zaak is opnieuw zeer moeilijk te analyseren, vanwege de vage reactie van Steam-ondersteuning, die nauwelijks details biedt. Gebaseerd op mijn persoonlijke gedachten, heeft deze gebruiker waarschijnlijk Steam kaarten ingeruild voor wat geld (level up bot? of op een andere manier probeerde uit te betalen op Steam. Voor het geval je het niet wist, is dit ook illegaal volgens **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. We kunnen je niet vertellen wat je kunt doen met de handelskaarten die je via ASF hebt gekregen - maar de gebruiker in kwestie heeft zeker geen badges met hem gemaakt.

Derde geval betrof gebruiker met 120+ bots die verbannen zijn wegens schending van **[Steam online gedrag](https://store.steampowered.com/online_conduct?l=english)**.

> Hallo XXX, Bedankt voor het contacteren van Steam Support. Dit en andere accounts zijn gebruikt om onze netwerkinfrastructuur te overstromen, wat een schending is van het online gedrag van Steam. Het account is permanent geblokkeerd en Steam Support kan geen extra ondersteuning bieden voor dit probleem.

Deze zaak is een beetje makkelijker te analyseren vanwege extra details van de gebruiker. Blijkbaar gebruikte de gebruiker **een zeer verouderde ASF versie** die een bug bevatte waardoor ASF te veel verzoeken naar Steam servers stuurde. De bug zelf bestond niet eerst maar was geactiveerd door Steam breekbare wijzigingen die in de toekomstige versie zijn opgelost. **ASF wordt alleen ondersteund in [laatste stabiele versie](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) uitgebracht op GitHub**.

Je kunt er niet van uitgaan dat een verouderde ASF-versie hetzelfde werkt als vroeger om eeuwig te werken, vooral omdat Steam voortdurend verandert, ongeacht of je het leuk vindt of niet. Als zoiets wereldwijd gebeurt, wordt het snel gepatreerd en vrijgegeven aan alle gebruikers als een bugfix. Radiatorkraan zal om voor de hand liggende redenen plotseling niet meer dan een miljoen gebruikers van ASF verbieden vanwege onze of hun fout. Maar als je opzettelijk ontslag neemt met actuele ASF, dan ben je per definitie in een zeer kleine minderheid van gebruikers **blootgesteld aan incidenten zoals deze** door **geen ondersteuning**, er is niemand die je verouderde versie van ASF volgt niemand repareert het en niemand zorgt ervoor dat je niet direct verbannen wordt door het te lanceren. **Gebruik moderne software**, niet alleen ASF, maar ook alle andere applicaties.

Het laatste geval vond plaats rond juni 2021, aldus de gebruiker:

> Met jouw programma heb ik al een boosterpakket gemaakt met 28 rekeningen voor 3 jaar en met 128 rekeningen voor de laatste 6 maanden. Ik was online met maximaal 15 accounts tegelijkertijd om booster packs te maken en deze naar de hoofdaccount te sturen. Vorige maand heb ik het aantal online accounts tegelijkertijd verhoogd tot twintig en daarna zijn al mijn accounts verboden. Deze e-mail is niet aan u te verwijten, integendeel, ik was altijd op de hoogte van de gevolgen. Ik wilde u vragen welke gedragingen tot een permanent verbod leiden.

Het is moeilijk te zeggen of de toename van het aantal gelijktijdige accounts online de directe reden was voor het verbod. Ik zou daar niet op rekenen, maar ik denk dat alleen het aantal rekeningen de hoofdschuldigen was. meer concurrentie van online accounts vestigde waarschijnlijk net de aandacht op de gebruiker in kwestie, omdat hij duidelijk veel meer bots had dan onze aanbeveling.

---

Alle bovenstaande incidenten hebben één ding gemeen - ASF is gewoon een hulpmiddel en het is **je** beslissing hoe je er gebruik van gaat maken. Je wordt niet direct verbannen voor het gebruik van ASF, maar voor **hoe** je het gebruikt. Het kan slechts één enkel hulpmiddel zijn voor het kweken van helper of een uit duizenden bots bestaand gigantisch landbouwnetwerk. In ieder geval bied ik geen juridisch advies aan en je moet zelf beslissen over je ASF-gebruik. Ik verberg geen informatie die jou kan helpen, b.v. het feit dat ASF enkele mensen heeft verboden (en in welke context), Omdat ik geen reden heb - is het uw keuze wat u met die informatie wilt doen.

Als u mij vraagt - gebruik uw gezond verstand, zorg dan dat u niet meer bots bezit dan onze aanbeveling, verzend niet honderden transacties op hetzelfde moment, gebruik altijd de actuele ASF-versie en je _zou_ prima moeten zijn. Elk individueel incident van deze aard voor **reden** is altijd overkomen bij mensen die onze aanbevelingen hebben genegeerd, beste praktijken en suggesties, in de overtuiging dat ze beter weten dan wij. . Hoeveel bots kunnen ze rennen. Of het nu een toeval is of een actuele factor, jij moet beslissen. We bieden geen juridisch advies, maar geven je onze gedachten die je nuttig kunt vinden, of de veronachtzaming daarvan volledig en alleen maar op bovengenoemde feiten stoelt.

---

### Welke privacyinformatie geeft ASF aan?

U vindt gedetailleerde uitleg in **[externe communicatie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** sectie. Je moet het bekijken als je om je privacy geeft, bijvoorbeeld als je je afvraagt waarom accounts die in ASF worden gebruikt lid zijn van onze Steam groep. ASF verzamelt geen gevoelige informatie en deelt deze niet met derden.

---

## Diversen

---

### Ik gebruik niet-ondersteunde OS zoals 32-bit Windows, kan ik nog steeds de nieuwste versie van ASF gebruiken?

Ja, en die versie wordt op geen enkele manier ondersteund, alleen niet officieel opgebouwd. Check **[compatibiliteit](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** sectie voor generieke variant. ASF is niet sterk afhankelijk van de OS, en het kan overal werken waar je aan het werk kan. ET runtime, inclusief 32-bit Windows, zelfs als er geen `win-x86` OS-specifiek pakket van ons is.

---

### ASF is geweldig! Kan ik een donatie doen?

Ja, en we zijn erg blij te horen dat je geniet van ons project! You can find various donation possibilities under every **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** and also **[on the main page](https://github.com/JustArchiNET/ArchiSteamFarm)**. Het is leuk om op te merken dat we naast het generieke geld ook Steam items accepteren, dus niets weerhoudt je ervan skins, sleutels of een klein deel van de kaarten te doneren die je met ASF hebt gekweekt, als je dat wilt. Bij voorbaat dank voor uw vrijgevigheid!

---

### Om mijn account te beschermen gebruik ik ouderdomspinnen,moet ik het ergens invoeren?

Ja, u moet het instellen in `SteamParentalCode` bot configuratie eigenschap. Dit komt voornamelijk omdat ASF toegang heeft tot veel beschermde onderdelen van je Steam-account en ASF zonder deze niet kan werken.

---

### Ik wil niet dat ASF standaard spellen produceert, maar ik wil wel extra ASF functies gebruiken. Is dat mogelijk?

Ja, als je gewoon ASF wilt starten met een gepauzeerde kaartbewerkingsmodule, je kan `FarmingPausedByDefault` in `FarmingVoorkeuren` bot configuratie instellen om dat te bereiken. Dit zorgt ervoor dat je `kan hervatten` tijdens de uitvoering.

Als u de kaartbewerkingsmodule volledig wilt uitschakelen en ervoor wilt zorgen dat deze nooit wordt uitgevoerd zonder dat u het expliciet anders vertelt. dan raden we aan om `FarmPriorityQueueOnly` in te stellen in bot `BoeringVoorkeuren`, welke in plaats van gewoon te pauzeren, de landbouw volledig uit te schakelen totdat je de spellen zelf toevoegt aan de wachtrij met prioriteit inactiveert.

Met kaarten kweekmodule gepauzeerd/uitgeschakeld, kunt u gebruik maken van extra ASF-functies, zoals `GamesPlayedWhileIdle`.

---

### Kan ASF naar trace minimaliseren?

ASF is een console app, er is geen venster om te minimaliseren, omdat het venster voor jou is gemaakt door je besturingssysteem. U kunt echter elke tool van derden gebruiken die daartoe in staat is, zoals **[RBtray](https://github.com/benbuck/rbtray)** voor Windows, of **[scherm](https://linux.die.net/man/1/screen)** voor Linux/macOS. Dit zijn slechts voorbeelden, er zijn veel andere apps met dezelfde functionaliteit.

---

### Is het gebruik van ASF in aanmerking komen voor het ontvangen van boosterpakketten?

**Ja**. ASF gebruikt dezelfde methode om in te loggen op het Steam netwerk als de officiële client, Daardoor behouden we ook de mogelijkheid om pepspakketten te ontvangen voor rekeningen die in ASF worden gebruikt. Bovendien is het behoud van die vaardigheid niet eens vereist dat je inlogt in Steam gemeenschap zodat je veilig `OnlineStatus` kan gebruiken in `Offline` instelling als je dat wilt.

---

### Is er een manier om met ASF te communiceren?

Ja, op verschillende manieren. Bekijk **[commando's](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** sectie voor meer info.

---

### Ik wil graag helpen met de ASF-vertaling, wat moet ik doen?

Dank u voor uw belang! U vindt alle details in onze **[sectie lokalisatie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)**

---

### Ik heb maar één (hoofd) account toegevoegd aan ASF, kan ik nog steeds commando's uitgeven via Steam chat?

**Ja**, het wordt uitgelegd in **[commando's](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#notes)** sectie. Je kunt dit doen via de Steam groepschat chat, hoewel het gebruik van **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** voor je makkelijker zou kunnen zijn.

---

### ASF lijkt te werken, maar ik krijg geen kaart drops!

Kaartkwekerij verschilt van spel tot spel, zoals je kunt lezen in **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Het duurt een tijdje meestal **enkele uren per spel**, en u mag niet verwachten dat kaarten binnen enkele minuten zullen vallen sinds het starten van een programma. Als je ziet dat ASF de status van de kaarten actief controleert en het spel verandert na de huidige volledig farmed, dan werkt alles prima. Het is mogelijk dat je een optie hebt ingeschakeld zoals `DismissInventoryNotifications` of `BotBehaviour` die automatisch voorraadmeldingen verwijdert. Bekijk **[configuratie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** voor details.

---

### Hoe stop ik de ASF-procedure volledig voor mijn account?

Sluit eenvoudig het ASF-proces af, bijvoorbeeld door op [X] te klikken op Windows. Als je in plaats daarvan een bepaalde bot van je keuze wilt stoppen maar andere actief willen houden, vervolgens kijken naar `Ingeschakeld` **[bot config eigenschap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**, of `stop` **[commando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. If you instead want to stop automatic farming process, yet keep ASF running for your account, then that's what `FarmingPausedByDefault` option of `FarmingPreferences` in **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** and `pause` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** is for.

---

### Hoeveel bots kan ik rennen met ASF?

ASF als programma heeft geen harde bovengrens van bot instanties, zodat je zo veel mogelijk geheugen op je machine kunt hebben, Maar je wordt nog steeds beperkt door het Steam-netwerk en andere Steam-diensten. Momenteel kunt u tot 100-200 bots draaien met een enkel IP en een enkele ASF-instantie. Het is mogelijk om meer bots te runnen met meer IP's en meer ASF-instanties, door het werken met IP-beperkingen. Houd er rekening mee dat als je zoveel bots gebruikt, je zelf hun nummer moet regelen bijvoorbeeld om ervoor te zorgen dat ze allemaal in feite ingelogd zijn en op hetzelfde moment werken. ASF was niet aangepast voor dat grote aantal bots, en de algemene regel is van toepassing dat **hoe meer bots je hebt, hoe meer problemen je tegenkomt**. Merk ook op dat de bovengrens in het algemeen afhankelijk is van veel interne factoren, De benadering is eerder dan een strikte limiet - je kunt hoogstwaarschijnlijk meer bots dan hierboven opslaan.

ASF stelt **eigenaar** tot **10 Steam accounts in totaal**voor, en loopt dus ook uit naar **10 bots in totaal**. Alles wat daarboven staat wordt niet gesteund en gedaan op eigen risico, tegen onze suggestie die hier is gedaan. Deze aanbeveling is gebaseerd op de interne richtsnoeren van de Radiatorkraan en op onze eigen suggesties. Of je nu aan deze regel gaat voldoen of niet, is jouw keuze, ASF als tool zal niet tegen je eigen wil ingaan. Zelfs als het ertoe zal leiden dat je Steam accounts hiervoor worden opgeschort. Daarom zal ASF je een waarschuwing geven als je verder gaat dan wat we aanbevelen. maar laat u nog steeds toe om op eigen risico en met gebrek aan steun alles te doen wat u maar wilt.

---

### Kan ik dan meer ASF-servers gebruiken?

Je kunt zo veel ASF instanties op één machine uitvoeren als je wilt, ervan uitgaande dat elke instantie zijn eigen map en eigen configuraties heeft, en het account dat gebruikt wordt in een ander geval niet gebruikt. Maar vraag uzelf af waarom u dat wilt doen. ASF is geoptimaliseerd om meer dan honderd rekeningen op hetzelfde moment te verwerken en de lancering van die honderd bots in hun eigen ASF-instanties degradeert de prestaties, gebruikt meer OS middelen (zoals CPU en geheugen), en veroorzaakt een potentiële synchronisatie problemen tussen zelfstandige ASF-instanties, omdat ASF gedwongen wordt zijn limiters te delen met andere instanties.

Mijn **sterke suggestie** wordt daarom altijd maximaal uitgevoerd op één ASF-instantie per één IP/interface. Als u meer IPs/interfaces heeft, kunt u op alle manieren meer ASF-instanties runnen. met elk exemplaar dat zijn eigen IP/interface of unieke `WebProxy` instelling gebruikt. Als je dat niet doet, is het volledig zinloos om meer ASF-instanties op te starten, omdat je niets wint van het starten van meer dan 1 instantie per één IP/interface. Steam zal je niet in staat stellen om meer bots te draaien alleen omdat je ze hebt gelanceerd in een andere ASF-instantie. en ASF beperkt je in het begin niet.

Natuurlijk zijn er nog steeds geldige gebruiksgevallen voor meerdere ASF-instanties op dezelfde netwerkinterface, zoals het hosten van ASF-service voor je vrienden met een eigen unieke ASF-instantie om het isoleren tussen bots en zelfs de ASF-processen zelf te garanderen. Echter, je omzeilt geen Steam beperkingen op deze manier, dat is een heel ander doel.

---

### Wat is de betekenis van status bij het inwisselen van een sleutel?

Status geeft aan hoe gegeven inwisselpoging is gelukt. Er zijn veel verschillende statussen mogelijk, meest voorkomende zijn:

| Status                  | Beschrijving                                                                                                                                                                                                                                    |
| ----------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Gedetailleerd           | "OK" status geeft aan dat de sleutel succesvol is ingewisseld.                                                                                                                                                                                  |
| Time-out                | Steam-netwerk heeft niet gereageerd in de gegeven tijd, we weten niet of de sleutel is ingewisseld, of niet (zeer waarschijnlijk, maar je kunt het opnieuw proberen).                                                                           |
| BadActivatieCode        | De opgegeven sleutel is ongeldig (niet herkend als een geldige sleutel door Steam netwerk).                                                                                                                                                     |
| Dupliceer ActivatieCode | De opgegeven sleutel is al door een ander account inwisseld, of ingetrokken door ontwikkelaar/uitgever.                                                                                                                                         |
| AlreadyGekocht          | Je account is al eigenaar van `packageID` die verbonden is met deze sleutel. Hou er rekening mee dat dit niet aangeeft of de sleutel `DuplicateActivationCode` of niet is - alleen dat het geldig is en het werd niet gebruikt bij deze poging. |
| BeperktLand             | Deze sleutel is geblokkeerd en je account is niet in de geldige regio die het mag inwisselen.                                                                                                                                                   |
| DoesNotOwnRequiredApp   | Je kan die sleutel niet inwisselen omdat je geen andere app mist - voornamelijk het basisspel wanneer je probeert DLC-pakket in te wisselen.                                                                                                    |
| Beoordeeld              | Je hebt te veel inwisselpogingen gedaan en je account werd tijdelijk geblokkeerd. Probeer het over een uur opnieuw.                                                                                                                             |

---

### Bent u geassocieerd met een boerderij/idling service?

**Geen**. ASF is niet geaffilieerd met een service en al deze claims zijn onjuist. Je Steam account is je eigendom en je kan je account gebruiken op de manier die je maar wilt. maar Radiatorkraan heeft duidelijk gezegd in **[officiële ToS](https://store.steampowered.com/subscriber_agreement)** dat:

> U bent verantwoordelijk voor de vertrouwelijkheid van uw login en wachtwoord en voor de beveiliging van uw computersysteem. Radiatorkraan is niet verantwoordelijk voor het gebruik van uw wachtwoord en Account of voor alle communicatie en activiteiten op Steam die voortvloeien uit het gebruik van uw inlognaam en wachtwoord door u, of iemand aan wie u uw login en/of wachtwoord opzettelijk hebt opengegeven in strijd met deze vertrouwelijkheidsbepaling.

ASF heeft een licentie op de liberale Apache 2.0-licentie, die andere ontwikkelaars in staat stelt ASF verder te integreren met hun eigen projecten en diensten. Dergelijke projecten van derden die ASF gebruiken, zijn echter niet gegarandeerd veilig en gereviest, gepast of legaal volgens **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Als u onze mening wilt weten, **wij raden u aan om GEEN van uw accountgegevens te delen met diensten van derden**. Als een dergelijke dienst een **typische zwendel**blijkt te zijn, dan ben je alleen met het probleem achtergebleven. Waarschijnlijk zonder je Steam account en ASF zullen geen verantwoordelijkheid nemen voor diensten van derden die beweren veilig en veilig te zijn, omdat het ASF-team geen van beide heeft geautoriseerd. Met andere woorden, **gebruikt u ze op eigen risico, tegen onze suggestie hierboven gemaakt**.

De officiële **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** geeft duidelijk aan dat:

> U mag niet onthullen, delen of anderszins toestaan dat anderen uw wachtwoord of account gebruiken, behalve als u anders specifiek gemachtigd bent door Radiatorkraan.

Het is jouw account en jouw keuze. Zeg gewoon niet dat niemand je heeft gewaarschuwd. ASF als een programma voldoet aan alle hierboven vermelde regels, omdat je je accountgegevens met niemand deelt. en je gebruikt het programma voor je eigen gebruik maar elke andere "kaartbewerkingsservice" vereist wel uw accountgegevens, dus het is ook in strijd met de bovenstaande regel (eigenlijk meerdere daarvan). Like **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** evaluatie, We bieden geen juridisch advies en je moet zelf beslissen of je gebruik wilt maken van deze diensten. of niet - volgens ons **schendt het direct [Steam ToS](https://store.steampowered.com/subscriber_agreement)** en kan het resulteren in opschorting als Radiatorkraan het verstaat. Zoals hierboven gezegd, **raden we ten sterkste aan om geen gebruik te maken van dergelijke diensten**.

---

## Problemen

---

### Een van mijn spellen is nu al meer dan 10 uur gekweekt, maar ik heb er nog steeds geen kaartjes van gekregen!

De reden hiervoor kan verband houden met de bekende Steam-kwestie. wat gebeurt als je twee licenties voor hetzelfde spel hebt, waarvan er één een beperkt aantal kaarten bevat. Dit gebeurt meestal wanneer je het spel kosteloos activeert tijdens een massale uitreiking op Steam, en activeer dan een sleutel voor hetzelfde spel (maar zonder beperkingen), e. . van een betaalde bundel. Als dit gebeurt rapporteert Steam op de badge pagina dat het spel nog steeds kaarten te geven heeft, maar het maakt niet uit hoeveel je het spel speelt - kaarten zullen nooit laten vallen als gevolg van gratis licentie op je account. Aangezien het geen ASF-probleem is maar een Steam-probleem, kunnen we het niet omzeilen aan ASF's kant, en je moet het zelf oplossen.

Er zijn twee manieren om dit probleem op te lossen. Ten eerste kun je dit spel in ASF blacklisten, hetzij met `fbadd` **[commando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** of met `Blacklist` **[configuratie-eigenschap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Dit voorkomt dat ASF kaarten van dit spel probeert te verwijderen, maar lost het onderliggende probleem niet op, waardoor u geen creditcarddrops uit het getroffen spel kunt krijgen. Ten tweede kun je Steam support self-service tool gebruiken om gratis licentie van je account te verwijderen, waarbij je alleen de volledige licentie achterlaat die de kaart drops bevat. Om dit te doen Bezoek eerst je **[licenties en product key activaties](https://store.steampowered.com/account/licenses)** pagina en zoek dan zowel gratis als betaald voor het getroffen spel. Meestal is het vrij eenvoudig - beide hebben een vergelijkbare naam, maar gratis een "beperkte gratis promotionele pakket" of een andere "promo" in de naam van de licentie, plus 'complimentary' in het veld 'acquisitie methode'. Soms kan het lastiger zijn, bijvoorbeeld als het gratis pakket in een bundel zit en een andere naam heeft. Als je twee dergelijke licenties hebt gevonden - dan is het probleem dat hier wordt beschreven, inderdaad en u kunt veilig de gratis licentie verwijderen zonder het spel te verliezen.

Om de gratis licentie van uw account te verwijderen bezoek **[Steam ondersteuningspagina](https://help.steampowered.com/wizard/HelpWithGame)** en zet de betrokken spelnaam in het zoekveld. het spel moet beschikbaar zijn in het "producten"-gedeelte, klik erop U kunt ook `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` link gebruiken en vervangen `<appID>` door appID van het spel dat problemen veroorzaakt. Klik daarna op "Ik wil dit spel permanent uit mijn account verwijderen" en selecteer vervolgens de gratis onjuiste licentie die je hierboven hebt gevonden, meestal degene met "beperkt gratis promotiepakket" in de naam (of vergelijkbaar). Na het verwijderen van de gratis licentie moet ASF in staat zijn om kaarten zonder problemen uit het getroffen spel te laten vallen. je moet de landbouwbewerking herstarten nadat de verwijdering is uitgevoerd om zeker te zijn dat Steam deze keer de juiste licentie oppakt.

---

### ASF detecteert het spel `X` niet als beschikbaar voor landbouw, toch weet ik dat het Steam handelskaarten bevat!

Daar zijn twee belangrijke redenen voor. De eerste en meest voor de hand liggende reden is het feit dat je refereert aan **Steam store** waar een bepaald spel wordt aangekondigd als kaart in te schakelen. Dit is **verkeerde** veronderstelling, omdat het gewoon stelt dat het spel **een** kaartjes heeft inbegrepen, maar niet noodzakelijk deze functie voor dat spel is **direct ingeschakeld**. U kunt hier meer over lezen in **[officiële aankondiging](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**.

Kortom: kaart dropt het icoontje in de Steam winkel niet van alles. Controleer je **[badge pagina's](https://steamcommunity.com/my/badges)** voor bevestiging of een spel kaart al dan niet ingeschakeld heeft - dit is ook wat ASF doet. Als je spel niet in de lijst wordt weergegeven als een spel met kaarten die mogelijk zijn om te laten vallen, dan is dit spel **niet** mogelijk om te boerderijen, ongeacht de rede.

Tweede kwestie is minder evident, en het is de situatie wanneer je kunt zien dat je spel beschikbaar is met kaarten die op je badge pagina staan. Toch wordt het niet meteen gekookt door ASF. Tenzij je iets anders tegenkomt, zoals ASF kan de badge pagina's niet controleren (hieronder beschreven), Het is gewoon een cache effect en op de ASF side Steam rapporteert nog steeds verouderde badges pagina. Dit probleem moet vroeg of laat opgelost worden, wanneer de cache ongeldig wordt. Er is ook geen manier om dit aan onze kant op te lossen.

Natuurlijk veronderstelt dat je ASF draait met standaard onaangetaste instellingen, aangezien je dit spel ook aan de lijst kunt toevoegen gebruik geselecteerde `FarmingPreferences` zoals `FarmPriorityQueueOnly` of `SkipRefundableGames`, enzovoort.

---

### Waarom neemt de speeltijd van spellen die via ASF worden gekweekt niet toe?

Dat doet het, maar **niet in real-time**. Steam neemt je speeltijd op in vaste intervallen en schema's update ervoor, maar je hebt niet gegarandeerd dat het onmiddellijk wordt bijgewerkt op het moment dat je de sessie afsluit, laat staan tijdens het begin. Het is niet omdat het spel in real-time niet bijgewerkt is, dat het normaal gesproken elke 30 minuten bijgewerkt is.

---

### Wat is het verschil tussen een waarschuwing en een fout in het logboek?

ASF schrijft naar zijn log een aantal informatie over verschillende logniveaus. Onze doelstelling is om **precies** uit te leggen wat ASF doet. inclusief welke Steam-problemen het moet oplossen, of andere problemen die het moet oplossen. Meestal is niet alles relevant, Daarom worden in ASF twee belangrijke niveaus gebruikt in termen van problemen, namelijk een waarschuwingsniveau en foutenniveau.

Algemene ASF-regel is dat waarschuwingen **niet** fouten zijn, daarom moeten ze **niet** worden gerapporteerd. Een waarschuwing is voor u een indicator dat er mogelijk iets ongewenst is. Of het nu was Steam niet reageerde, API gooit fouten of je netwerkverbinding is offline - het is een waarschuwing, en het betekent dat we het verwachtten dat het zou gebeuren, dus maak de ontwikkeling van ASF er niet mee bezig. Natuurlijk ben je vrij om over hen te vragen of hulp te krijgen door onze ondersteuning te gebruiken maar je moet er niet van uitgaan dat dit ASF-fouten zijn die rapporteren waard zijn (tenzij we het anders bevestigen).

Fouten van de andere kant wijzen op een situatie die niet mag gebeuren. Daarom zijn ze het vermelden waard zolang je ervoor hebt gezorgd dat je niet degene bent die ze veroorzaakt. Als het een algemene situatie is die we verwachten, dan zal deze worden omgezet naar een waarschuwing. Anders is het mogelijk een bug die moet worden gecorrigeerd, niet stilzwijgend wordt genegeerd, ervan uitgaande dat het geen resultaat van uw eigen technische probleem is. Bijvoorbeeld, het plaatsen van ongeldige inhoud in `ASF. son` bestand zal een fout gooien, omdat ASF niet in staat zal zijn om het te parsen, maar jij was degene die het daar heeft neergezet. Dus je moet die fout niet aan ons melden (tenzij je hebt bevestigd dat ASF fout is en je structuur in feite helemaal correct is).

In één TL; DR zin - foutenmeldingen melden, geen waarschuwingen. U kunt nog steeds vragen over waarschuwingen en hulp ontvangen in onze support secties.

---

### ASF start niet en het programmavenster sluit onmiddellijk!

Onder normale omstandigheden zal elke ASF crash of exit een `log genereren. xt` in de map van het programma om te bekijken, welke kan worden gebruikt om de oorzaak daarvan te vinden. Als aanvulling hierop worden een paar laatste logbestanden ook gearchiveerd in `logs` directory, sinds het hoofd `log. xt` bestand is overschreven met elk ASF uitgevoerd

Echter, als zelfs .NET runtime niet in staat is om op uw machine op te starten, dan wordt `log.txt` niet gegenereerd. Als dat je overkomt, ben je waarschijnlijk vergeten om .NET vereisten te installeren, zoals aangegeven in **[het opzetten van](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)** handleiding. Andere algemene problemen zijn het proberen om een verkeerde ASF-variant te starten voor je OS, of op een andere manier het missen van native .NET runtime afhankelijkheden. Als het console venster te snel sluit om het bericht te lezen, open dan een onafhankelijke console en start ASF binary daarvandaan. Bijvoorbeeld op Windows, open ASF-directory, houd `Shift`ingedrukt , rechtermuisklik in de map en kies "*open opdrachtvenster hier*" (of *powershell*), Typ dan in de console `. ArchiSteamFarm.exe` en bevestig met enter. Op deze manier krijg je precies bericht waarom ASF niet goed begint.

Als er geen output is, en je op Windows, de gebruikelijke reden daarvoor is dat niet alle beschikbare Windows-updates geïnstalleerd zijn - zorg ervoor dat u up-to-date OS gebruikt. omdat we het draaien van ASF op Windows niet ondersteunen zonder aan die voorwaarde te voldoen.

---

### ASF kickt mijn Steam Client sessie terwijl ik aan het spelen ben! / *Dit account is ingelogd op een andere PC*

Dit toont als een bericht in Steam overlay dat het account ergens anders wordt gebruikt tijdens het spelen. Deze kwestie kan twee verschillende redenen hebben.

Een reden is veroorzaakt door defecte pakketten (games) die specifiek niet goed een speelslot bevatten. verwacht toch dat die vergrendeling bezworen wordt door de klant. Een voorbeeld van een dergelijk pakket zou Skyrim SE zijn. Je Steam client lanceert het spel goed, maar dat spel registreert zichzelf niet als in gebruik. Daarom ziet ASF het vrij om het proces te hervatten, wat het doet en dat kickt je uit het Steam netwerk, omdat Steam plotseling detecteert dat het account op een andere plaats wordt gebruikt.

Een tweede reden kan opduiken als je op je PC speelt terwijl ASF wacht (vooral op een andere machine) en je netwerkverbinding wordt verloren. In dit geval markeert het Steam-netwerk je als offline en zorgt het voor het spelen van lock (zoals hierboven), welke ASF (bijvoorbeeld op een andere machine) activeert om de boerderij te hervatten. Wanneer je PC online terugkomt, kan Steam geen speelklok meer krijgen (dat is nu vastgehouden door ASF, Vergelijkbaar met boven) en laat hetzelfde bericht zien.

Beide oorzaken aan de ASF-kant zijn eigenlijk erg moeilijk te verwerken, als ASF gewoon de landbouw hervat zodra Steam-netwerk het informeert dat het account gratis opnieuw gebruikt kan worden. Dit is wat er normaal gebeurt wanneer je het spel sluit, maar met kapotte pakketten kan dit onmiddellijk gebeuren, zelfs als je spel nog steeds loopt. ASF heeft geen manier om te weten of je de verbinding verbroken hebt, stopte met het spelen van een spel of dat je nog steeds een spel speelt dat lock niet op de juiste manier houdt.

De enige juiste oplossing voor dit probleem is handmatig je bot pauzeren met `pauzeren` voordat je begint met spelen, en hervat het met `hervat` zodra je klaar bent. Als alternatief kun je gewoon het probleem negeren en hetzelfde doen als wanneer je offline Steam client hebt gespeeld.

---

### `Verbinding met Steam!` - Ik kan geen verbinding maken met Steam servers.

ASF kan alleen **** proberen om verbinding te maken met Steam servers, en het kan mislukken vanwege vele redenen, waaronder het ontbreken van een internetverbinding. Steam aan het worden, uw firewall verbinding blokkeert, gereedschappen van derden, verkeerd geconfigureerde routes of tijdelijke mislukkingen. U kunt `Debug` modus inschakelen om meer verbose log te bekijken met exacte falen redenen Hoewel het meestal gewoon door je eigen acties wordt veroorzaakt zoals het gebruik van "CS:GO MM Server Picker" dat veel Steam IPs blacklist; dit maakt het erg moeilijk voor je om het Steam netwerk te bereiken.

ASF zal zijn best doen om verbinding te maken, dit omvat niet alleen vragen over de bijgewerkte lijst van servers maar ook het proberen van een ander IP wanneer de laatste mislukt dus als het echt een tijdelijk probleem is met een specifieke server of route, zal ASF vroeg of laat verbinding maken. Echter, als je achter een firewall bent of op een andere manier Steam servers niet kan bereiken, dan moet je het natuurlijk zelf repareren, met potentiële hulp van `Debug` modus.

Het is ook mogelijk dat jouw machine geen verbinding kan maken met Steam servers met behulp van het standaardprotocol in ASF. Je kunt protocollen wijzigen die ASF mag gebruiken door `SteamProtocols` globale configuratie eigenschappen te wijzigen. Bijvoorbeeld, als je problemen ondervindt om Steam te bereiken met `UDP` protocol (bijv. Als gevolg van firewalls), heb je misschien meer geluk met `TCP` of `WebSocket`.

In een zeer onwaarschijnlijke situatie dat onjuiste servers worden gecached, bijvoorbeeld omdat ASF `config` map van de ene machine naar een andere machine verplaatst wordt op een heel ander land, Verwijder `ASF. b` om Steam servers te verversen bij de volgende lancering kan helpen. Heel vaak is het niet nodig en hoeft het niet gedaan te worden, omdat die lijst automatisch wordt vernieuwd bij de eerste lancering. evenals wanneer de verbinding is ontstaan - we noemen het slechts als een manier om alles te verwijderen wat gerelateerd is aan een lijst van Steam servers gecached door ASF.

---

### `Niet in staat om in te loggen op Steam: TryAnotherCM/Ongeldige`, `ServiceOnbeschikbaar/Ongeldig`

Zoals per hierboven, maar deze keer is de server waarmee je verbinding hebt gemaakt expliciet niet beschikbaar. Meestal gebeurt dit tijdens het onderhoud van Steam venster, er is niets dat je hieraan kunt doen. ASF zal automatisch opnieuw proberen met een andere server totdat de aanvraag is geaccepteerd. Het mag niet langer duren dan een uur.

---

### `Kon badges informatie niet ophalen, zal het later opnieuw proberen!`

Meestal betekent dit dat je een Steam ouderlijk PIN-code gebruikt om toegang te krijgen tot je account, maar dat je het bent vergeten om het in ASF-configuratie te zetten. U moet een geldige pincode invoeren `SteamParentalCode` bot configuratie eigenschap, Anders kan ASF geen toegang krijgen tot de meeste webinhoud, waardoor het niet goed kan werken. Ga naar **[configuratie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** om meer te leren over `SteamParentalCode`.

Andere redenen zijn onder meer het tijdelijke Steam probleem, netwerkprobleem of op vergelijkbare wijze. Als het probleem zichzelf na enkele uren niet kan oplossen en je er zeker van bent dat je ASF correct hebt geconfigureerd, voel je dan vrij om ons hiervan op de hoogte te stellen.

---

### ASF faalt `Verzoek is mislukt na 5 pogingen` fouten!

Meestal betekent dit dat je een Steam ouderlijk PIN-code gebruikt om toegang te krijgen tot je account, maar dat je het bent vergeten om het in ASF-configuratie te zetten. U moet een geldige pincode invoeren `SteamParentalCode` bot configuratie eigenschap, Anders kan ASF geen toegang krijgen tot de meeste webinhoud, waardoor het niet goed kan werken. Ga naar **[configuratie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** om meer te leren over `SteamParentalCode`.

Als ouderlijke pincode niet de reden is, is dit een zeer gebruikelijke fout en daar moet u aan wennen. het betekent gewoon dat ASF een verzoek naar het Steam netwerk heeft gestuurd, en geen geldig antwoord heeft gekregen, 5 keer per keer. Meestal betekent dit dat Steam onderweg is of problemen heeft of onderhoud heeft - ASF is zich bewust van dergelijke problemen en je hoeft je geen zorgen over ze te maken. tenzij ze constant langer dan enkele uren aan het gebeuren zijn, en andere gebruikers hebben dergelijke problemen niet.

Hoe te controleren of Steam offline is? **[Steam Status](https://steamstat.us)** is een uitstekende bron om te controleren of Steam **omhoog moet zijn,** . als u fouten opmerkt, vooral gerelateerd aan de Community of Web API, dan heeft Steam problemen. Misschien wil je ASF alleen verlaten en laat het na korte tijd zijn werk doen, of stoppen en wacht jezelf.

Dat is echter niet altijd het geval, want in sommige situaties kunnen Steam-problemen niet worden gedetecteerd door Steam-Status, voor een dergelijk geval gebeurde bijvoorbeeld toen Valve de HTTPS-support voor Steam Community op 7 juni 2016 brak - toegang tot **[SteamCommunity](https://steamcommunity.com)** via HTTPS gooide een fout. Vertrouw Steam Status dus ook niet blindeloos. Het is het beste om jezelf te controleren of alles werkt zoals verondersteld wordt.

Daarnaast bevat Steam verschillende tariefbeperkende maatregelen die tijdelijk uw IP zullen verbannen als u te veel verzoeken tegelijk doet. ASF is zich hiervan bewust en biedt verschillende limiters in de config, waar je gebruik van moet maken. Standaardinstellingen werden aangepast op basis van **Sane** aantal bots, als je zo veel gebruikt dat zelfs Steam je vertelt dat je weg moet gaan, dan pas je ze aan totdat het je niet meer vertelt of je doet wat je wordt verteld. Ik neem aan dat u geen andere keuze hebt dan een tweede manier. ga dus lezen over dat onderwerp en besteed speciale aandacht aan `WebLimiterDelay` die een algemene limiet is die van toepassing is op alle webverzoeken.

Er is geen "gouden regel" die voor iedereen werkt, omdat blokken zwaar worden beïnvloed door factoren van derden, Daarom moet je jezelf experimenteren en een waarde vinden die voor je werkt. Je kunt ook negeren wat ik zeg en iets als `10000` gebruiken dat gegarandeerd correct zal werken. maar dan niet klagen hoe je ASF reageert op alles in 10 seconden en hoe badge parsen 5 minuten in beslag neemt. Daar komt nog bij dat het is heel goed mogelijk dat geen begrenzers iets zullen doen, omdat je zo veel bots hebt dat je **[harde limiet](#how-many-bots-can-i-run-with-asf)** aanraakt die hierboven werd genoemd. Ja, het is heel goed mogelijk dat je kan inloggen zonder problemen op het Steam-netwerk (client), maar Steam-web (website) zal weigeren naar je te luisteren als je 100 sessies tegelijk hebt opgericht. ASF vereist zowel het Steam-netwerk als het Steam web om mee te werken, het kost maar één om problemen te maken waar je geen oplossing voor hebt.

Als niets helpt en je weet niet wat kapot is, je kan altijd `Debug` modus inschakelen en jezelf zien in ASF log waarom precies verzoeken mislukken. Bijvoorbeeld:

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Verboden <- HEAD https://steamcommunity.com/my/edit/settings
```

Zie je dat `Verboden` -code? Dit betekent dat je tijdelijk verbannen bent voor een te hoog aantal verzoeken, omdat je `WebLimiterDelay` nog niet goed hebt aangepast (ga ervan uit dat je ook dezelfde foutcode krijgt voor alle andere verzoeken). Er kunnen andere redenen zijn die hier vermeld worden, zoals `InternalServerError`, `ServiceUnavailable` en time-outs die duiden op Steam onderhoud/problemen. Je kunt altijd zelf proberen de link die ASF vermeldt te bezoeken en te controleren of het werkt - als dat niet het geval is, dan weet je waarom ASF dat ook niet kan bereiken. Als dat het geval is en dezelfde fout niet na een of twee dagen verdwijnt, is het wellicht de moeite waard om te onderzoeken en te rapporteren.

Voordat u dat doet, moet u **controleren of de fout het rapporteren waard is op de eerste plaats**. Als het genoemd wordt in deze FAQ, zoals het handelsgerelateerde probleem, dan is dat wel. Als het een of twee keer een tijdelijk probleem was, vooral wanneer je netwerk instabiel was of Steam voorbij was - dat is uit. Als je je probleem echter meerdere keren op rij kon reproduceren, over twee dagen, heeft ASF en jouw machine opnieuw opgestart en ervoor gezorgd dat er geen FAQ-invoer is om het op te lossen. Dan is het misschien wel de moeite waard om erover na te denken.

---

### ASF lijkt te bevriezen en laat niets printen in de console totdat ik op een toets druk!

U gebruikt waarschijnlijk Windows en uw console heeft QuickEdit modus ingeschakeld. Raadpleeg **[](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** vraag over StackOverflow voor technische uitleg. U moet QuickEdit modus uitschakelen door met de rechtermuisknop op uw ASF console venster te klikken, eigenschappen te openen en het vinkje uit te vinken.

---

### ASF kan geen transacties accepteren of versturen!

Duidelijk eerst - nieuwe accounts beginnen als beperkt. Totdat u een account ontgrendelt door de portemonnee te laden of $5 in de winkel uitgeeft, kan ASF geen transacties accepteren die worden verzonden met dit account. In dit geval zal ASF verklaren dat de inventaris leeg lijkt, omdat elke kaart die erin zit niet verhandelbaar is.

Vervolgens, als je geen **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**gebruikt, het is mogelijk dat ASF in feite de transactie heeft geaccepteerd/verstuurd, maar dat moet je bevestigen via je e-mail. Als je klassieke 2FA gebruikt, moet je de transactie via je authenticator bevestigen. Bevestigingen zijn **verplicht** nu, dus als je ze niet zelf wilt accepteren, kun je je authenticator importeren in ASF 2FA.

Merk ook op dat u alleen kunt handelen met uw vrienden en mensen met een bekende handelslink. Als je *Bot -> Master* handel probeert te starten, zoals `loot`, vervolgens moet je je bot op je vriendenlijst zetten, of moet je `SteamTradeToken` in Bot's configuratie worden gedeclareerd. Zorg ervoor dat het token geldig is - anders kan je geen transactie sturen.

Denk er ten slotte aan dat nieuwe apparaten 7 dagen handel vergrendeling hebben, dus als je net je account aan ASF hebt toegevoegd wacht ten minste 7 dagen - alles zou na die periode moeten werken. Deze beperking omvat **zowel** die **en** verzenden van transacties. Het wordt niet altijd geactiveerd, en er zijn mensen die direct transacties kunnen verzenden en accepteren. De meerderheid van de bevolking heeft echter te maken met deze gebeurtenis, en de lock **zal** gebeuren zelfs als je op dezelfde machine transacties kunt verzenden en accepteren via je steam cliënt. Wacht geduldig, er is niets dat je kunt doen om het sneller te maken. Op dezelfde manier kan je een vergelijkbaar slot krijgen voor het verwijderen/wijzigen van verschillende Steam beveiligings-instellingen zoals 2FA, SteamGuard, wachtwoord, e-mail en op dezelfde manier. Controleer in het algemeen of je een transactie vanaf dat account zelf kunt verzenden, zo ja, dan is het waarschijnlijk een klassiek 7-daagse vergrendeling op een nieuw apparaat.

En ten slotte mogen we niet vergeten dat de ene rekening slechts 5 lopende transacties mag hebben in de andere. ASF zal dus geen transacties versturen als je 5 (of meer) in behandeling hebt van die ene bot om al te accepteren. Dit is zelden een probleem, maar het is ook het vermelden waard, vooral als je ASF in staat stelt automatisch transacties te verzenden, Je gebruikt nog geen ASF 2FA en bent vergeten deze te bevestigen.

Als niets helpt, kun je altijd `Debug` modus inschakelen en jezelf controleren waarom verzoeken mislukken. Houd er rekening mee dat Steam meestal onzin spreekt en dat de reden hiervoor misschien niet logisch is. of kan zelfs volledig onjuist zijn - als je besluit om deze reden te interpreteren, zorg er dan voor dat je voldoende kennis hebt over Steam en zijn eigenschappen. Het is ook vrij gebruikelijk om dat probleem zonder logische reden te zien en de enige voorgestelde oplossing in dit geval is het opnieuw toevoegen van het account aan ASF (en wacht 7 dagen opnieuw). Soms lost dit probleem zichzelf op *magische*, op dezelfde manier als het breekt. Maar meestal gaat het gewoon om 7 dagen handelslot, tijdelijke stoommachtigheid of beide. Het is best om het een paar dagen te geven voordat je handmatig controleert wat er mis is. tenzij je een aansporing hebt om de echte oorzaak te debuggen (en meestal zul je sowieso gedwongen worden om te wachten, Omdat een foutmelding geen zin heeft, helpt jou ook niet in de geringste).

In elk geval kan ASF alleen **een** proberen om een passend verzoek naar Steam te sturen om de ruil te accepteren/verzenden. Of Steam dat verzoek accepteert of niet, valt buiten het bereik van ASF, en ASF zal het magisch niet laten werken. Er is geen bug die met die functie te maken heeft, en er is ook niets te verbeteren, omdat de logica buiten de ASF valt. Vraag daarom niet om het repareren van dingen die niet gebroken zijn, en vraag ook niet waarom ASF geen transacties kan accepteren of verzenden - **ik weet het niet, en ASF weet evenmin**. Verhandel ermee of repareer uzelf, als u beter weet.

---

### Waarom moet ik 2FA/SteamGuard code op elke login plaatsen? / *Verlopen login sleutel verwijderd*

ASF gebruikt inlogtoetsen (als je `UseLoginKeys` ingeschakeld hebt gehouden om de aanmeldgegevens geldig te houden, hetzelfde mechanisme dat Steam gebruikt - 2FA/SteamGuard token is slechts één keer vereist. Vanwege Steam-netwerkproblemen en koppelingen is het echter volledig mogelijk dat de inlogsleutel niet is opgeslagen in het netwerk, we hebben dergelijke problemen niet alleen met ASF gezien maar ook met reguliere steam client (een noodzaak om login + wachtwoord in te voeren bij elke uitvoering, ongeacht de "onthoud mij" optie).

Je kunt `BotNaam.db` en `BotName verwijderen. in` (indien beschikbaar) van een getroffen account en probeer ASF opnieuw aan je account te koppelen, maar dat zal waarschijnlijk niets doen. Sommige gebruikers hebben gerapporteerd dat **[het autoriseren van alle apparaten](https://store.steampowered.com/twofactor/manage)** aan Steam-zijde zou moeten helpen, het veranderen van een wachtwoord zal hetzelfde doen. Het gaat echter alleen om werk dat niet eens gegarandeerd is. de echte ASF-based oplossing is om je authenticator te importeren als **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** - op deze manier kan ASF automatisch tokens genereren wanneer ze nodig zijn. en je hoeft ze niet handmatig in te voeren. Normaal gesproken lost het probleem zichzelf na enige tijd op met de maaltijd, dus je kunt daar gewoon op wachten. Natuurlijk kunt u ook Radiatorkraan om oplossingen vragen, omdat ik het Steam netwerk niet kan dwingen om onze login sleutels te accepteren.

Als nevenaantekening Je kunt ook inlogsleutels uitschakelen met `UseLoginKeys` configuratie-eigenschap ingesteld op `false`, maar dit zal het probleem niet oplossen, alleen de eerste login sleutel overslaan. ASF is al op de hoogte van het hier uitgebrachte probleem en zal zijn best doen om geen login sleutels te gebruiken als het zichzelf kan garanderen dus is het niet nodig om `UseLoginKeys` handmatig aan te passen als je alle inloggegevens kunt verstrekken samen met ASF 2FA.

---

### Ik krijg fout: *Niet in staat om in te loggen op Steam: `InvalidPassword` of `RateLimitOverschreden`*

Deze fout kan veel betekenen. Sommige ervan zijn:

- Ongeldige login/wachtwoord combinatie (klaarblijkelijk)
- Verlopen login sleutel die ASF gebruikt om in te loggen
- Te veel mislukte inlogpogingen in korte tijd (anti-bruteforce)
- Te veel inlogpogingen in korte tijd (tariefbeperking)
- Vereisten van captcha om in te loggen (waarschijnlijk veroorzaakt door twee redenen hierboven)
- Elke andere reden waarom het Steam netwerk je misschien verhindert in te loggen

In het geval van anti-bruteforce en tariefbeperking zal het probleem na een tijdje verdwijnen, dus wacht gewoon en probeer ondertussen niet in te loggen. Als u dat probleem vaak raakt, is het misschien verstandig om de configuratie van ASF `LoginLimiterDelay` te verhogen. Overmatige herstart van het programma en andere opzettelijke of niet-opzettelijke inlogverzoeken helpen absoluut niet met dat probleem, dus probeer het indien mogelijk te vermijden.

In geval van verlopen login sleutel - ASF zal de oude verwijderen en vragen om een nieuwe op de volgende login (wat vereist is van het plaatsen van 2FA token als uw account 2FA-beveiligd is. Als je account ASF 2FA gebruikt, wordt het token automatisch gegenereerd en gebruikt). Dat kan natuurlijk in de loop der tijd gebeuren, maar als je dit probleem bij elke aanmelding krijgt, het is mogelijk dat Steam om een of andere reden heeft besloten onze login key save verzoeken te negeren, zoals vermeld in issue **[boven](#why-do-i-have-to-put-2fasteamguard-code-on-each-login--removed-expired-login-key)**. Je kunt natuurlijk `UseLoginKeys` volledig uitschakelen, maar dat lost het probleem niet op, vermijd alleen elke keer de verlopen inlogcodes te verwijderen. De echte oplossing, zoals in de bovenstaande kwestie, is het gebruik van het ASF 2FA.

En tot slot, als u de verkeerde combinatie van login + wachtwoord hebt gebruikt, moet u dit natuurlijk corrigeren. of schakel bot uit die probeert te verbinden met deze inloggegevens. ASF kan op zichzelf niet raden of `OngeldigWachtwoord` ongeldige inloggegevens betekent, of een van de hierboven genoemde redenen, daarom zal hij blijven proberen totdat het slaagt.

Houd er rekening mee dat ASF zijn eigen ingebouwde systeem heeft om dienovereenkomstig te reageren op stoomwandelingen, Uiteindelijk zal het zijn baan verbinden en hervatten en daarom is het niet nodig om iets te doen als het probleem tijdelijk is. Het opnieuw opstarten van ASF om op magische wijze problemen op te lossen maakt de dingen alleen maar erger (omdat de nieuwe ASF niet weet dat ASF niet in staat is om in te loggen) en probeer te verbinden in plaats van te wachten), dus vermijd dat als je weet wat je doet.

Tot slot, net als bij elke Steam aanvraag - ASF kan alleen **proberen** om in te loggen, door gebruik te maken van je opgegeven gegevens. Of dat verzoek zal lukken of niet, is buiten het bereik en de logica van ASF - er is geen bug, Ook op dit punt kan er niets worden verbeterd.

---

### Ik kan geen inloggegevens invoeren die ASF vraagt
### `System.InvalidOperationUitzondering: Sleutels kunnen niet worden gelezen als de toepassing geen console heeft of wanneer de invoer van de console is omgeleid`
### `Systeem.IO.Exception: Invoer/uitvoer fout`
### `RequestInput() invoer is ongeldig!`

Als deze fout is opgetreden tijdens de ASF invoer (bijv. je kan `GetUserInput()` in de stacktrace) zien en worden veroorzaakt door jouw omgeving, die het lezen van standaard invoer van jouw console verbiedt. Dat kan gebeuren vanwege veel redenen, maar de meest voorkomende is dat je ASF gebruikt in de verkeerde omgeving (bijv. in de `systemd`, `nohup` of `&` achtergrond in plaats van e. . `scherm` op Linux). Als ASF geen toegang heeft tot de standaard invoer, zie je dat deze fout gelogd is en dat ASF je gegevens niet kan gebruiken tijdens de runtime.

Normaal gesproken moet je bovenstaande kwestie corrigeren, d.w.z. ASF toegang geven tot standaard invoer, zodat je de details kunt opgeven. Als u **** dit echter verwacht, dus u **wilt** draaien in input-less omgeving, dan moet je ASF expliciet vertellen dat het zo is. door **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** correct in te stellen. Dit zal ASF vertellen nooit om gebruikersinvoer te vragen onder welke omstandigheid dan ook, waardoor je ASF in veilige omgevingen zonder input kunt uitvoeren. Je kunt de geselecteerde invoeraanwijzingen met andere middelen in deze modus beantwoorden, bijvoorbeeld in de ASF-ui.

---

### `System.Net.Http.WinHttpException: Er is een beveiligingsfout opgetreden`

Deze fout gebeurt wanneer ASF geen beveiligde verbinding kan maken met de gegeven server, bijna uitsluitend vanwege wantrouwen met het SSL-certificaat.

In bijna alle gevallen wordt deze fout veroorzaakt door **verkeerde datum/tijd op je machine**. Elk SSL-certificaat heeft uitgiftedatum en vervaldatum. Als je datum ongeldig is en buiten deze twee grenzen, dan kan het certificaat niet worden vertrouwd vanwege een potentieel **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)** aanval en ASF weigeren een verbinding te maken.

Een duidelijke oplossing is om de datum op je machine op de juiste manier in te stellen. Het wordt sterk aanbevolen om automatische datumsynchronisatie te gebruiken, zoals native synchronisatie beschikbaar op Windows, of `ntpd` op Linux.

Als je er zeker van bent dat de datum op je computer geschikt is en de fout niet weg wil gaan. SSL-certificaten die uw systeem vertrouwt kunnen verouderd of ongeldig zijn. In dit geval moet u ervoor zorgen dat uw machine veilige verbindingen kan aanleggen, bijvoorbeeld door te controleren of u `https://github kunt benaderen. om` met elke browser van uw keuze, of CLI tool zoals `curl`. Als u hebt bevestigd dat dit goed werkt, kunt u ons om steun vragen.

---

### `System.Threading.Tasks.TaskCanceledException: Een taak werd geannuleerd`

Deze waarschuwing betekent dat Steam niet heeft geantwoord op het ASF-verzoek in de gegeven tijd. Meestal wordt het veroorzaakt door het netwerk van Steam en heeft het geen invloed op ASF. In andere gevallen is het hetzelfde als het verzoek dat na 5 pogingen mislukte. Het melden van dit probleem heeft meestal geen zin, omdat we Steam niet kunnen dwingen om te reageren op onze verzoeken.

---

### `Het type initializer voor 'System.Security.Cryptography.CngKeyLite' gaf een uitzondering`

Dit probleem wordt bijna exclusief veroorzaakt door uitgeschakeld/gestopt `CNG Key Isolation` Windows service, deze biedt de kern van cryptografie functionaliteit voor ASF, zonder welke het programma niet kan worden uitgevoerd. Je kunt dit probleem oplossen door `diensten op te starten. sc` en zorg ervoor dat `CNG Key Isolation` Windows service het opstarten niet heeft uitgeschakeld en momenteel actief is.

---

### ASF wordt door mijn AntiVirus als malware gedetecteerd! Wat gebeurt er?

**Zorg ervoor dat je ASF van vertrouwde bron** hebt gedownload. De enige officiële en vertrouwde bron is **[ASF releases](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** pagina op GitHub (en dit is ook de bron voor automatische updates) - **elke andere bron wordt per definitie niet vertrouwd en kan malware door andere mensen** bevatten - je hoeft geen andere downloadlocatie te vertrouwen, zorg ervoor dat je ASF altijd van ons komt.

Als je hebt bevestigd dat ASF wordt gedownload van vertrouwde bron, dan is het waarschijnlijk gewoon een vals positief signaal. Deze **gebeurde in het verleden**, **gebeurt nu**, en **zal gebeuren in de toekomst**. Als je je zorgen maakt over de werkelijke veiligheid bij het gebruik van ASF, dan raad ik aan ASF te scannen met verschillende AV's voor de werkelijke detectie verhouding, bijvoorbeeld via **[VirusTotal](https://www.virustotal.com)** (of elke andere webservice zoals deze).

Als de AV die je gebruikt, ASF foutief detecteert als malware, dan **is een goed idee om dit bestandsvoorbeeld terug te sturen naar de ontwikkelaars van je AV, zodat ze het kunnen analyseren en hun detectie-engine**kunnen verbeteren, zo goed werkt het duidelijk niet zo goed als je denkt dat het werkt. Er is geen probleem in de ASF-code, en er is ook niets om ons op te lossen, omdat we malware helemaal niet verspreiden. Het heeft dan ook geen zin om die valse voorstellingen aan ons te melden. We raden ten zeerste aan om ASF sample te verzenden voor verdere analyse zoals hierboven vermeld, maar als je er geen moeite mee wilt doen, dan kun je altijd ASF toevoegen aan een soort AV uitzonderingen, je AV uitschakelen of een andere gebruiken. Sadly, we're used to AVs being stupid, as every once in a while some AV detects ASF as a virus, which usually lasts very short and is being patched up quickly by the devs, but like we pointed out above - **it happened**, **happens** and **will happen** all the time. ASF bevat geen kwaadaardige code, je kunt de ASF-code opnieuw bekijken en zelfs compileren uit de bron. We zijn geen hackers om ASF-code te verdoezelen om zich te verbergen van AV heuristiek en valse positieven. Verwacht dus niet van ons dat we repareren wat niet gebroken is - er is geen "virus" voor ons om te repareren.