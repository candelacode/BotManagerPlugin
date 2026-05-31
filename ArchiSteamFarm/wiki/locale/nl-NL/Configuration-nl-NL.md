# Configuratie

Deze pagina is gewijd aan het configureren van ASF. Het dient als een complete documentatie van de `config` directory, zodat je ASF naar eigen voorkeur kunt instellen.

* **[Inleiding](#introduction)**
* **[Webtoepassing ConfigGenerator](#web-based-configgenerator)**
* **[ASF-Ui configuratie](#asf-ui-configuration)**
* **[Handmatige configuratie](#manual-configuration)**
* **[Globale configuratie](#global-config)**
* **[Bot-configuratie](#bot-config)**
* **[Bestandsstructuur](#file-structure)**
* **[JSON toewijzing](#json-mapping)**
* **[Compatibiliteitstoewijzing](#compatibility-mapping)**
* **[Configureer compatibiliteit](#configs-compatibility)**
* **[Automatisch herladen](#auto-reload)**

---

## Inleiding

De ASF-configuratie is onderverdeeld in twee hoofdonderdelen: globale (proces) configuratie en de configuratie van elke bot. Elke bot heeft zijn eigen bot-configuratiebestand met de naam `BotNaam.json` (waarbij `BotNaam` de naam is van de bot). De globale ASF (proces) configuratie is een enkel bestand met de naam `ASF.json`.

Een bot is één steam account dat deelneemt aan het ASF-proces. Om goed te kunnen werken, heeft ASF minstens **een** gedefinieerde bot instantie nodig. Er is geen process-force-limiet van bot-instanties, dus je kunt zoveel bots (steam accounts) gebruiken als je wilt.

ASF gebruikt **[JSON](https://en.wikipedia.org/wiki/JSON)** formaat voor het opslaan van de configuratiebestanden. Het is menselijk, leesbaar en zeer universeel formaat waarin je het programma kunt configureren. Maak je echter geen zorgen, je hoeft geen JSON te kennen om ASF te configureren. Ik heb het net genoemd voor het geval je al een ASF-configuratie met een soort bash-script zou willen creëren.

Configuratie kan op verschillende manieren gebeuren. Je kunt onze **[Web-based ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)**gebruiken, een lokale app onafhankelijk van ASF. Je kunt onze **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC frontend gebruiken voor configuratie direct gedaan in ASF. Als laatste kun je altijd configuratiebestanden handmatig genereren, zoals hieronder een vaste JSON-structuur is opgegeven. We zullen de beschikbare opties kort uitleggen.

---

## Webtoepassing ConfigGenerator

Het doel van onze **[Web-based ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** is om u een vriendelijke frontend te bieden die wordt gebruikt voor het genereren van ASF configuratiebestanden. Web-gebaseerde ConfigGenerator is 100% gebaseerd op klant, wat betekent dat de gegevens die je invoegt nergens worden verzonden, maar alleen lokaal worden verwerkt. Dit garandeert zekerheid en betrouwbaarheid. omdat het zelfs kan werken **[offline](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** als je alle bestanden wilt downloaden en `index wilt uitvoeren. tml` in je favoriete browser.

Web-gebaseerde ConfigGenerator is geverifieerd om correct te werken in Chrome en Firefox, maar het zou wel goed moeten werken in alle meest populaire javascript-ingeschakelde browsers.

Het gebruik is vrij simpel - selecteer of je `ASF` of `Bot` configuratie wilt genereren door naar het juiste tabblad over te schakelen, zorg ervoor dat de gekozen versie van het configuratiebestand overeenkomt met uw ASF-versie, voer dan alle details in en druk op de knop "download". Verplaats dit bestand naar ASF `config` directory, het overschrijven van bestaande bestanden indien nodig. Herhaal voor eventuele verdere wijzigingen en verwijs naar de rest van deze sectie voor uitleg van alle beschikbare opties om te configureren.

---

## ASF-Ui configuratie

Met onze **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC interface kunt u ook ASF configureren. en is een superieure oplossing voor het herconfigureren van ASF na het genereren van de initiële configuraties vanwege het feit dat het de ingestelde configuraties kan bewerken. in tegenstelling tot Web-based ConfigGenerator die ze statisch genereert.

Om ASF-ui, moet je onze **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface zelf ingeschakeld hebben. `IPC` is standaard ingeschakeld, dus u kunt het direct benaderen, zolang u het niet zelf hebt uitgeschakeld.

Na het starten van het programma, navigeer naar ASF's **[IPC adres](http://localhost:1242)**. Als alles goed werkte, kan je de ASF configuratie ook daar veranderen.

---

## Handmatige configuratie

In het algemeen bevelen we het gebruik van onze ConfigGenerator of ASF-ui, aan omdat het veel makkelijker is en ervoor zorgt dat je geen fout maakt in het JSON-structuur. maar als je om een of andere reden niet wilt, dan kun je ook handmatig de juiste configuraties aanmaken. Controleer de JSON-voorbeelden hieronder voor een goede start in een goede structuur. kunt u de inhoud naar een bestand kopiëren en gebruiken als basis voor uw configuratie. Aangezien u geen van onze frontend gebruikt, zorg er dan voor dat uw configuratie **[geldig is](https://jsonlint.com)**, ASF zal weigeren om het te laden als het niet kan worden verwerkt. Zelfs als het een geldige JSON is, moet je er ook voor zorgen dat alle eigenschappen het juiste type hebben, zoals vereist door ASF. Voor een goede JSON-structuur van alle beschikbare velden, raadpleeg **[JSON mapping](#json-mapping)** en onze documentatie hieronder.

---

## Globale configuratie

De globale configuratie staat in het `ASF.json` bestand en heeft de volgende structuur:

```json
{
    "AutoRestart": waar,
    "Blacklist": [],
    "CommandPrefix": "! ,
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "Huidigecultuur": nul,
    "Debug": false,
    "StandaardBot": null,
    "FarmingDelay": 15,
    "FilterBadBots": waar,
    "GeschenkgreniterDelaa": 1,
    "Hoofdles": false,
    "IdleFarmingPeriod": 8,
    "Inventaris LimiterDelay": 4,
    "IPC": waar,
    "IPCPassword": null,
    "IPCPasswordFormaat": 0,
    "LicenseID": null,
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldDuration": 15,
    "MinFarmingDelayAfterBlock": 60,
    "OptimalisatieModus": 0,
    "PluginsUpdateList": [],
    "PluginsUpdateMode": 0,
    "ShutdownIfPossible": false,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocollen": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Alle opties zijn hieronder uitgelegd:

### `Automatisch herstarten`

`bool` type met standaard waarde `true`. Deze eigenschap definieert of ASF een zelf-herstart mag uitvoeren wanneer nodig. Er zijn een paar evenementen die een zelf-start vereisen van ASF zoals ASF update (gedaan met `UpdatePeriod` of `update` commando), evenals `ASF. zoon` config edit, `herstart` commando en ook. Doorgaans bevat herstarten twee delen - het maken van nieuw proces en het voltooien van het huidige. De meeste gebruikers moeten er prima in zijn en deze eigenschap met de standaard waarde `true`houden, , Maar - als je ASF uitvoert via je eigen script en/of met `dotnet`, u wilt misschien volledige controle hebben over het starten van het proces. en vermijd een situatie zoals een nieuw (herstart) ASF-proces dat op de achtergrond stil draait en niet op de voorgrond van het script, dat samen met het oude ASF-proces beëindigd is. Dit is met name van belang gezien het feit dat het nieuwe proces niet langer uw directe kind zal zijn, waardoor u niet meer in staat zou zijn. . om de standaard console-invoer daarvoor te gebruiken.

Als dat het geval is, deze eigenschap indien speciaal voor u en u kunt het instellen op `false`. Houd er echter rekening mee dat in een dergelijk geval **u** verantwoordelijk is voor het herstarten van het proces. Dit is van belang omdat ASF alleen zal stoppen in plaats van nieuw proces (bijvoorbeeld na het update), dus als er geen logica door je is toegevoegd, werkt het gewoon niet meer totdat je het opnieuw start. ASF sluit altijd af met de juiste foutcode die aangeeft hoe succesvol (nul) of niet-succesvol (niet-nul) is op deze manier kun je de juiste logica in je script toevoegen om te voorkomen dat ASF automatisch heropstart in geval van een storing, of maak ten minste een lokale kopie van `log. xt` voor verdere analyse. Houd er ook rekening mee dat `herstart` commando altijd ASF zal herstarten, ongeacht hoe deze eigenschap is ingesteld. omdat deze eigenschap het standaardgedrag definieert, terwijl `het commando` opnieuw opstart en het proces altijd opnieuw opstart. Tenzij u een reden heeft om deze functie uit te schakelen, moet u deze ingeschakeld houden.

---

### `Geblokkeerde`

`ImmutableHashSet<uint>` type met de standaard waarde van leeg zijn. Zoals de naam suggereert, definieert deze globale configuratie-eigenschap appIDs (spellen) die volledig genegeerd zullen worden door het automatische ASF-productieproces. Helaas houdt Steam van het vlaggen van zomer/winterverkoop badges als "beschikbaar voor kaarten drop", die het ASF-proces verwart door de indruk te wekken dat het een geldig spel is dat gekweekt zou moeten worden. Als er geen zwarte lijst was, zou ASF uiteindelijk een spel "hangen" in de landbouw houden dat in feite geen spel is. en wacht oneindig lang tot de kaarten vallen dat niet zal gebeuren. De zwarte lijst van ASF dient om die badges te markeren als niet beschikbaar voor landbouw, Dus we kunnen ze stilzwijgend negeren als we besluiten wat ze moeten doen, en niet in de val trappen.

ASF bevat standaard twee blacklists - `SalesBlacklist`, welke hard gecodeerd is in de ASF-code en niet mogelijk te bewerken en normale `blacklist`, die hier gedefinieerd is. `SalesBlacklist` wordt samen met de ASF-versie bijgewerkt en bevat meestal alle "slecht" appIDs op het moment van release, dus als je ASF up-to-date gebruikt, hoef je je eigen `blacklist` niet te behouden. Het belangrijkste doel van deze eigenschap is om je in staat te stellen om nieuwe, niet-bekend op de dag van ASF-release-appID's te blokkeren, wat niet zou moeten worden gekweekt. Hardcoded `Verkooplijst` wordt zo snel mogelijk geüpdatet. Daarom ben je niet verplicht om je eigen `blacklist` bij te werken als je de nieuwste ASF versie gebruikt, maar zonder `Blacklist` zou je gedwongen worden ASF te updaten om "te blijven uitvoeren" wanneer Radiatorkraan nieuwe verkoop badge publiceert - ik wil je niet dwingen de nieuwste ASF-code te gebruiken Daarom is deze eigenschap hier om je toe te staan ASF zelf te "fixen" als je om een of andere reden niet wilt of niet kunt update naar nieuwe hardcoded `SalesBlacklist` in de nieuwe ASF release, maar je wilt je oude ASF actief houden. Tenzij u een **sterke** reden heeft om deze eigenschap te bewerken, moet u deze op standaard houden.

Als je in plaats daarvan op zoek bent naar een bot-gebaseerde blacklist kijk dan bij `fb`, `fbadd` en `fbrm` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `CommandPrefix`

`string` type met standaard waarde van `!`. Deze eigenschap specificeert **hoofdlettergevoelig** voorvoegsel gebruikt voor ASF **[commando's](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Met andere woorden, dit is wat je moet vooraf aan elk ASF-commando om ASF naar je te laten luisteren. Het is mogelijk om deze waarde in te stellen op `null` of leeg om ASF geen opdrachtprefix te geven, in dat geval voer je opdrachten in met hun platte ID's. Maar dit zal in potentie de prestaties van ASF verminderen omdat ASF is geoptimaliseerd om bericht niet verder te verwerken als het niet begint met `CommandPrefix` - als je opzettelijk besluit om het niet te gebruiken ASF zal gedwongen worden om alle berichten te lezen en erop te reageren, zelfs als ze geen ASF-commando's zijn. Daarom wordt aanbevolen om een aantal `CommandPrefix`te blijven gebruiken, zoals `/` als de standaard waarde van `niet bevalt!`. Voor consistentie heeft `CommandPrefix` invloed op het gehele ASF-proces. Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

### `Vertraging`

`byte` type met de standaard waarde van `10`. ASF zal ervoor zorgen dat er ten minste `ConfirmationsLimiterDelay` seconden zijn tussen twee opeenvolgende 2FA bevestigingen die aanvragen ophalen om te voorkomen dat er een rate-limit wordt geactiveerd - die worden gebruikt door **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** gedurende e. . `2faok` commando, en op basis die nodig is bij het uitvoeren van verschillende handelsgerelateerde operaties. De standaardwaarde is ingesteld op basis van onze tests en mag niet worden verlaagd als je geen problemen wilt veroorzaken. Tenzij u een **sterke** reden heeft om deze eigenschap te bewerken, moet u deze op standaard houden.

---

### `ConnectionTime-out`

`byte` type met de standaardwaarde van `90`. Deze eigenschap definieert time-outs voor verschillende netwerkacties gedaan door ASF, in seconden. `ConnectionTimeout` definieert time-out in seconden voor HTTP en IPC verzoeken, `ConnectionTimeout / 10` definieert het maximum aantal mislukte hartslag while `ConnectionTimeout / 30` definieert het aantal minuten dat we toestaan voor het initiële netwerkverbindingsverzoek van Steam. Standaardwaarde van `90` zou prima moeten zijn voor de meerderheid van mensen, echter als u een trage netwerkverbinding of PC heeft je wilt dit aantal misschien verhogen naar iets hoger (zoals `120`). Hou in gedachten dat grotere waarden de langzame of zelfs ontoegankelijke Steam servers niet op magische wijze zullen fixen, dus moeten we niet oneindig wachten op iets dat niet zal gebeuren en het later gewoon nog eens proberen. Als deze waarde te hoog wordt ingezet, zal er sprake zijn van buitensporige vertraging in het vangen van netwerkproblemen, evenals in een afname van de algehele prestaties. Een te lage waarde zal ook de algehele stabiliteit en prestaties doen afnemen, aangezien ASF nog steeds bezig is een geldige aanvraag in te trekken. Het lager stellen van deze waarde dan standaard heeft daarom geen voordeel in het algemeen omdat Steam-servers van tijd tot tijd super traag zijn en meer tijd nodig hebben voor het verwerken van ASF-verzoeken. Standaardwaarde is een balans tussen het geloven dat onze netwerkverbinding stabiel is, en het twijfelen in Steam-netwerk om ons verzoek af te handelen binnen de aangegeven time-out. Als je sneller problemen wilt detecteren en ASF opnieuw wilt verbinden/reageren, de standaardwaarde moet doen (of heel lichtelijk hieronder, zoals `60`, waardoor ASF minder patiënt is). Als je in plaats daarvan merkt dat ASF bezig is met netwerkproblemen, zoals falende verzoeken, hartslag die verloren gaat of verbinding met Steam wordt onderbroken, het is waarschijnlijk zinvol om deze waarde te verhogen als je zeker weet dat **niet** veroorzaakt wordt door je netwerk, maar door Steam zelf, omdat ASF door het verhogen van de tijdslimieten meer "patient" maakt en niet wordt beslist om direct opnieuw verbinding te maken.

Een voorbeeldsituatie die een toename van deze onroerend goed kan vereisen, is ASF in staat stellen om te gaan met een zeer grote handelsaanbod dat ruim 2 minuten kan duren om volledig geaccepteerd en behandeld te worden door Steam. Door het verhogen van standaard time-out, ASF zal meer geduld hebben en langer wachten alvorens te besluiten dat de transactie niet doorgaat en de oorspronkelijke aanvraag opzegt.

Een andere situatie kan worden veroorzaakt door een zeer trage machine of internetverbinding, waarvoor meer tijd nodig is voor het verwerken van de gegevens die worden verzonden. Dit is vrij zeldzame staat, aangezien de CPU/netwerk bandbreedte bijna nooit een bottleneck is, maar nog steeds een mogelijkheid die het vermelden waard is.

Kortom, de standaardwaarde moet in de meeste gevallen fatsoenlijk zijn, maar misschien wilt u deze eventueel verhogen als dat nodig is. Toch is het ook niet erg zinvol om ver boven de standaardwaarde te gaan, aangezien grotere timeouts ontoegankelijke Steam servers niet magisch zullen oplossen. Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

### `Huidigecultuur`

`string` type met standaard waarde van `nul`. Standaard probeert ASF je besturingssysteemtaal te gebruiken, en gebruikt het liever vertaalde tekenreeksen in die taal indien beschikbaar. Dit is mogelijk dankzij onze community die probeert **[localiseert](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** ASF in alle populairste talen. Als je om een of andere reden geen eigen OS wil gebruiken Je kan deze configuratie-eigenschap gebruiken om elke geldige taal te kiezen die je in plaats daarvan wilt gebruiken. Voor een lijst van alle beschikbare culturen, bezoek **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** en zoek naar `Taaltag`. Het is leuk om te zien dat ASF beide specifieke culturen accepteert, zoals `"nl-NL"`, maar ook neutrale, zoals `"en"`. Het opgeven van de huidige cultuur zal ook invloed hebben op andere culturele specifieke gedragingen, zoals valuta/datumformaat en dergelijke. Houd er rekening mee dat je mogelijk extra font/taalpakketten nodig hebt om taalspecifieke tekens correct weer te geven, als je een niet-native cultuur gekozen hebt die er gebruik van maakt. Meestal wilt u gebruik maken van deze configuratie-eigenschap als u de voorkeur geeft aan ASF in het Engels in plaats van de moedertaal.

---

### `Debug`

`bool` type met standaard waarde van `false`. Deze eigenschap definieert of proces moet worden uitgevoerd in debug modus. In debug modus maakt ASF een speciale `debug` map aan naast de `config`, welke de hele communicatie tussen ASF en Steam servers bijhoudt. Debug informatie kan vervelende problemen met betrekking tot netwerkvorming en algemene ASF workflow helpen te vinden. Bovendien zullen sommige programma-routines veel uitgebreider zijn, zoals `WebBrowser` met een exacte reden waarom sommige verzoeken niet lukken - deze items worden naar het normale ASF-logboek geschreven. **Je moet ASF niet uitvoeren in de Debug modus, tenzij de ontwikkelaar** hierom vraagt. ASF in debug modus **vermindert de prestaties**, **beïnvloedt de stabiliteit negatief** en is **veel uitgebreider op verschillende plaatsen**, dus het moet alleen **only** opzettelijk op korte termijn worden gebruikt voor het opsporen van een bepaald probleem. het probleem reproduceren of meer informatie krijgen over een falende aanvraag, en wel **niet** voor een normale uitvoering van het programma. Je ziet **veel** nieuwe fouten, issues, en uitzonderingen - zorg ervoor dat je een goede kennis hebt van ASF Steam en zijn kwaken als je besluit om dit allemaal zelf te analyseren, want niet alles is relevant.

**WAARSCHUWING:** als je deze modus inschakelt omvat het loggen van **potentieel gevoelige** informatie zoals logins en wachtwoorden die je gebruikt om in te loggen op Steam (vanwege het registreren van netwerken). Die gegevens zijn geschreven naar zowel de map `debug` als de standaard `log. xt` (dat is nu opzettelijk veel uitgebreider om deze info te loggen). Het is niet raadzaam om een foutopsporingsbericht te plaatsen dat is gegenereerd door ASF, op een openbare locatie, De ontwikkelaar van ASF moet je er altijd aan herinneren om het naar zijn e-mail of een andere veilige locatie te sturen. We slaan deze gevoelige gegevens niet op, en maken ook geen gebruik van Ze zijn geschreven als onderdeel van debug routines omdat hun aanwezigheid relevant kan zijn voor het probleem dat van invloed is op u. We zouden het liefst hebben als je ASF niet veranderde, maar als je je zorgen maakt, kun je die gevoelige details op de juiste manier aanpassen.

> Redacte houdt in dat gevoelige details, bijvoorbeeld met sterren, moeten worden vervangen. Je moet afzien van het volledig verwijderen van de gevoelige lijnen, want deze kunnen alleen maar relevant zijn en moeten behouden blijven.

---

### `StandaardBot`

`string` type met standaard waarde van `nul`. In sommige scenarios ASF functies met een concept van een standaard bot die iets afhandelt - bijvoorbeeld IPC-commando's of interactieve console wanneer je geen doelbot opgeeft. Met deze eigenschap kunt u de standaard bot kiezen die verantwoordelijk is voor het verwerken van dergelijke scenario's, door de `BotName` hier te plaatsen. Als de opgegeven bot niet bestaat, of als je een standaardwaarde van `null`gebruikt, zal ASF eerst geregistreerde bot gesorteerd hebben op alfabetisch. Meestal wilt u gebruik maken van deze configuratie-eigenschap als u `[Bots]` argument in IPC en interactieve console commando's wilt weglaten, en kies altijd dezelfde bot als de standaard voor dergelijke gesprekken.

---

### `Boerderij Vertraging`

`byte` type met de standaardwaarde van `15`. Om ASF te laten werken zal het elke `Boerderij Vertraging` minuten controleren als het misschien al alle kaarten laat vallen. Een te lage waarde van deze eigenschap kan ertoe leiden dat er te veel stoomverzoeken worden verzonden, terwijl het te hoog is, kan ASF nog steeds "boerderij" titel krijgen voor maximaal `Foutvertraging` minuten nadat het volledig gekweekt is. Standaardwaarde moet uitstekend zijn voor de meeste gebruikers, maar als je veel bots draait, je kunt overwegen om het te verhogen tot iets als `30` minuten om stoomverzoeken die worden verzonden te beperken. Het is leuk om op te merken dat ASF gebruik maakt van event-gebaseerde mechanismen en de gamebadge pagina van elk Steam item controleert, dus in het algemeen **hoeven we het niet eens te controleren met een vaste tijd**, maar omdat we het Steam netwerk niet volledig vertrouwen - we controleren game badge pagina toch, als we het niet hebben gecontroleerd door de kaart die in de laatste `FarmingVertraging` minuten niet hebben laten vallen (in het geval dat het Steam-netwerk ons niet heeft geïnformeerd over item dat is gevallen of dergelijke dingen heeft gedaan). Assuming that Steam network is working properly, decreasing this value **will not improve farming efficiency in any way**, while **increasing network overhead significantly** - it's recommended only to increase it (if needed) from default of `15` minutes. Tenzij u een **sterke** reden heeft om deze eigenschap te bewerken, moet u deze op standaard houden.

---

### `FilterBadBots`

`bool` type met standaard waarde `true`. Deze eigenschap bepaalt of ASF handelsaanbiedingen die worden ontvangen van bekende en gemarkeerde slechte spelers automatisch zal verminderen. Om dat te doen, zal ASF communiceren met onze server op basis die nodig is om een lijst van geblokkeerde Steam determinators op te halen. De bots worden beheerd door mensen die zijn geclassificeerd als schadelijk voor het ASF-initiatief door ons. zoals degene die onze **[gedragscode](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**schenden, gebruik de geleverde functionaliteit en middelen zoals **[`Publicing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** om andere mensen te misbruiken en uit te buiten. of doen regelrechte criminele activiteiten zoals het lanceren van DDoS aanvallen op de server. Aangezien ASF een sterk standpunt inneemt ten aanzien van algehele eerlijkheid, eerlijkheid en samenwerking tussen zijn gebruikers om de hele gemeenschap te laten gedijen, deze eigenschap is standaard ingeschakeld en filtert daarom bots die we als schadelijk hebben geclassificeerd voor aangeboden diensten. Tenzij je een **sterke** reden hebt om deze eigenschap te bewerken zoals het niet eens zijn met onze verklaring en het opzettelijk laten werken van deze bots (met het exploiteren van je rekeningen), moet je deze op standaard houden.

---

### `GiftsLimiterDelay`

`byte` type met de standaardwaarde van `1`. ASF zal ervoor zorgen dat er ten minste `GiftsLimiterDelay` seconden is tussen twee opeenvolgende geschenken/key/licentieafhandeling (inwissel) om te voorkomen dat het tarief wordt geactiveerd. Daarnaast zal het ook worden gebruikt als globale limiter voor aanvragen voor spellijsten, zoals die uitgegeven door `owns` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Tenzij u een **sterke** reden heeft om deze eigenschap te bewerken, moet u deze op standaard houden.

---

### `Hoofd`

`bool` type met standaard waarde van `false`. Deze eigenschap definieert of proces moet worden uitgevoerd in headless modus. In de headless mode gaat ASF ervan uit dat het op een server draait of in een andere niet-interactieve omgeving Daarom zal zij niet proberen informatie te lezen via console-invoer. Dit omvat op aanvraag details (accountgegevens zoals 2FA-code, SteamGuard code wachtwoord of een andere variabele die nodig is om ASF te laten werken) en alle andere console inputs (zoals interactieve opdrachtconsole). Met andere woorden, `Headless` modus is gelijk aan het maken van de ASF console alleen-lezen. Deze instelling is vooral handig voor gebruikers die ASF op hun servers draaien, in plaats van te vragen. . voor de 2FA-code zal ASF de operatie stilletjes annuleren door een account te stoppen. Tenzij je ASF op een server draait, en je hebt eerder bevestigd dat ASF in niet-headless mode kan werken, u moet deze eigenschap uitgeschakeld houden. Elke gebruikersinteractie wordt geweigerd wanneer in de headless mode en je accounts zullen niet werken als ze **een** console input vereisen tijdens het opstarten. Dit is handig voor servers, omdat ASF zijn pogingen om in te loggen op het account wanneer gevraagd wordt om inloggegevens, kan afbreken in plaats van te wachten (oneindig) op een gebruiker om deze op te geven.

Door deze modus in te schakelen kunt u de vereiste console-invoer via andere middelen invoeren, d.w.z. ASF-ui (ASF API), of via **[`input`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#input-command)** commando. Als u niet zeker weet hoe u deze eigenschap instelt, laat het dan staan met de standaardwaarde van `false`.

---

### `IdleFarmingPeriode`

`byte` type met de standaardwaarde van `8`. Wanneer ASF niets te farmen heeft, zal het periodiek elke `IdleFarmingPeriod` uren controleren als de account misschien nieuwe partijen te boerderij krijgt. Deze functie is niet nodig wanneer we praten over nieuwe games die we krijgen, omdat ASF slim genoeg is om in dit geval automatisch de badge pagina's te bekijken. `IdleFarmingPeriod` is vooral voor situaties zoals oude games waar we al handelskaarten hebben toegevoegd. In dit geval is er geen gebeurtenis, dus ASF moet periodiek de badge pagina's controleren als we dit gedekt willen hebben. Waarde van `0` schakelt deze functie uit. Vink ook aan: `ShutdownOnFarmingFinished` voorkeur in `BoeringVoorkeuren`.

---

### `VoorraadLimiterVertraging`

`byte` type met de standaardwaarde van `4`. ASF zal ervoor zorgen dat er ten minste `Inventaris LimiterDelay` seconden is tussen twee opeenvolgende web inventaris verzoeken om het activeren van de limiet te voorkomen - deze worden bijvoorbeeld gebruikt tijdens het markeren van voorraadmeldingen als gelezen, kan ook worden gebruikt door externe plug-ins die de inventaris van andere gebruikers ophalen. Deze eigenschap wordt niet gebruikt voor het ophalen van onze eigen inventaris, aangezien ASF daarvoor veel efficiëntere oproepen van het interne netwerk gebruikt. dus het zal op geen enkele manier invloed hebben op commando's als `loot` of `transfer`. Standaardwaarde van `4` is ingesteld op basis van inventarisatie van meer dan 100 opeenvolgende bot instanties, en zou de meeste, zo niet alle, gebruikers tevreden moeten stellen. U kunt het echter willen verlagen, of zelfs veranderen naar `0` als u een zeer lage hoeveelheid bots heeft, ASF zal de vertraging negeren en veel sneller de Steam inventarisaties markeren. Be warned though, as setting it too low **will** result in Steam temporarily banning your IP, and that will prevent you from making any calls at all. Je moet deze waarde misschien ook verhogen als je veel bots gebruikt met veel voorraadverzoeken, Hoewel u in dit geval waarschijnlijk moet proberen het aantal van die verzoeken te beperken. Tenzij u een **sterke** reden heeft om deze eigenschap te bewerken, moet u deze op standaard houden.

---

### `IPC`

`bool` type met standaard waarde `true`. Deze eigenschap definieert of ASF's **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** server samen met het proces moet starten. IPC maakt interprocess-communicatie mogelijk, inclusief het gebruik van **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, door het opstarten van een lokale HTTP-server. Als u niet van plan bent om IPC-integratie met ASF te gebruiken, inclusief onze ASF-ui, kunt u deze optie veilig uitschakelen. Anders is het een goed idee om het ingeschakeld te houden (standaard optie).

---

### `IPCPassword`

`string` type met standaard waarde van `nul`. Deze eigenschap definieert verplicht wachtwoord voor elke API-oproep gedaan via IPC en fungeert als een extra beveiligingsmaatregel. Indien ingesteld op niet-lege waarde, zullen alle IPC-aanvragen extra `wachtwoord` eigenschappen vereisen die ingesteld zijn op het hier opgegeven wachtwoord. Standaardwaarde van `null` zal een behoefte van het wachtwoord overslaan, waardoor ASF alle query's respecteert. Daar komt nog bij dat het inschakelen van deze optie schakelt ook ingebouwd IPC anti-bruteforce mechanisme in dat tijdelijk zal verbieden, gegeven `IPAddress` na het versturen van te veel ongeoorloofde verzoeken in zeer korte tijd. Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

### `IPCPasswordFormaat`

`byte` type met de standaard waarde van `0`. Deze eigenschap definieert het formaat van `IPCPassword` eigenschap en gebruikt `EHashingMethod` als onderliggend type. Raadpleeg de sectie **[Security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** als je meer wilt leren omdat u ervoor moet zorgen dat `IPCPassword` eigenschap inderdaad een wachtwoord bevat dat overeenkomt met `IPCPasswordFormat`. In other words, when you change `IPCPasswordFormat` then your `IPCPassword` should be **already** in that format, not just aiming to be. Tenzij je weet wat je aan het doen bent, moet je het houden met de standaardwaarde van `0`.

---

### `LicentieID`

`Richtlijn?` type met de standaard waarde van `null`. Deze eigenschap staat onze **[sponsors](https://github.com/sponsors/JustArchi)** toe om ASF te verbeteren met optionele functies die betaalde middelen vereisen om te werken. Op dit moment kun je gebruik maken van **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** functie in `ItemsMatcher` plugin.

Hoewel we je aanbevelen om gebruik te maken van GitHub omdat het maandelijkse en eenmalige niveaus biedt, volledige automatisering toestaat en je directe toegang geeft we **ondersteunen ook** alle andere momenteel beschikbare **[donatieopties](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. Zie **[deze post](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** voor instructies over hoe doneren met andere methodes om een handmatige licentie te krijgen die geldig is voor een bepaalde periode.

Ongeacht de gebruikte methode, als je ASF sponsor, kun je een licentie krijgen **[hier](https://asf.justarchi.net/User/Status)**. Je moet je aanmelden met GitHub om je identiteit te bevestigen, wij vragen alleen om openbare informatie voor alleen-lezen, wat je gebruikersnaam is. `LicenseID` is gemaakt van 32 hexadecimale tekens, zoals `f6a0529813f74d119982eb4fe43a9a24`.

**Zorg ervoor dat je je `LicenseID` niet deelt met andere mensen**. Aangezien het op persoonlijke basis wordt uitgegeven, kan het worden ingetrokken als het wordt uitgelekt. Als u dat per ongeluk hebt meegemaakt, kunt u vanaf dezelfde plaats een nieuwe creëren.

Tenzij je extra ASF-functies wilt inschakelen, is het niet nodig om de licentie te verkrijgen/verstrekken.

---

### `LoginLimiterVertraging`

`byte` type met de standaard waarde van `10`. ASF zorgt ervoor dat er ten minste `LoginLimiterDelay` seconden is tussen twee opeenvolgende verbindingspogingen om het activeren van de limiet te voorkomen. Standaardwaarde van `10` is ingesteld op basis van het verbinden van meer dan 100 bot instanties, en zou de meeste (zo niet alle) gebruikers tevreden moeten stellen. Je kunt het echter verhogen of verlagen of zelfs veranderen naar `0` als je een zeer lage hoeveelheid bots hebt, ASF zal de vertraging negeren en veel sneller met Steam verbinden. Be warned though, as setting it too low while having too many bots **will** result in Steam temporarily banning your IP, and that will prevent you from logging in **at all**, with `InvalidPassword/RateLimitExceeded` error - and that also includes your normal Steam client, not only ASF. Hetzelfde geldt als je te veel bots draait, vooral samen met andere Steam clients/tools met hetzelfde IP adres. Hoogstwaarschijnlijk moet je deze waarde verhogen om logins over langere tijd te verspreiden.

Als nevenopmerking wordt deze waarde ook gebruikt als belastingbalansbuffer in alle ASF-geplande acties, zoals transacties in `SendTradePeriod`. Tenzij u een **sterke** reden heeft om deze eigenschap te bewerken, moet u deze op standaard houden.

---

### `MaxFarmingTime`

`byte` type met de standaard waarde van `10`. Zoals je zou moeten weten, werkt Steam niet altijd naar behoren. Soms kunnen zich rare situaties voordoen zoals onze speeltijd die niet wordt opgenomen, ondanks het feit dat we in feite een spel spelen. ASF zal het kweken van een enkel spel in de solo modus mogelijk maken voor maximaal `MaxFarmingTime` uur, en overweeg dat het na die periode volledig gekweekte is. Dit is nodig om het landbouwproces niet te bevriezen in geval van rare situaties. maar ook als Steam om een of andere reden een nieuwe badge vrijgeeft die ASF ervan zou weerhouden verder te gaan (zie: `Blacklist`). Standaardwaarde van `10` uur moet genoeg zijn om alle stoomkaarten uit één spel te laten vallen. Als deze eigenschap te laag wordt ingesteld, worden geldige spellen overgeslagen (en ja, er zijn geldige spelletjes die zelfs 9 uur op de boerderij duren, terwijl een te hoge positie kan leiden tot bevriezing van het landbouwproces. Houd er rekening mee dat deze eigenschap slechts van invloed is op een enkel spel in een enkele boerderij sessie (dus na het doorlopen van de hele wachtrij ASF zal terugkeren naar die titel), het is ook niet gebaseerd op de totale speeltijd maar op de interne ASF-landbouwtijd, dus ASF zal ook naar die titel terugkeren na een herstart. Tenzij u een **sterke** reden heeft om deze eigenschap te bewerken, moet u deze op standaard houden.

---

### `MaxTradeHoldDuration`

`byte` type met de standaardwaarde van `15`. Deze eigenschap definieert de maximale duur van de wachttijd in dagen die we bereid zijn te accepteren - ASF verwerpt transacties die langer dan `MaxTradeHoldDuration` dagen worden gehouden. zoals gedefinieerd in **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** sectie. Deze optie is alleen zinvol voor bots met `TradingPreferences` of `SteamTradeMatcher`, omdat het geen invloed heeft op `Master`/`SteamOwnerID` transacties, geen donaties. Handelsregels zijn ergerlijk voor iedereen en niemand wil er echt mee omgaan. ASF moet werken aan liberale regels en iedereen helpen ongeacht of deze optie al dan niet in de handel is - is standaard ingesteld op `15`. Maar als je in plaats daarvan alle transacties zou afwijzen, kan je hier `0` specificeren. Houd er rekening mee dat deze optie niet van invloed is op kaarten met korte levensduur en automatisch wordt geweigerd voor mensen met handelskaarten, zoals beschreven in **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** sectie, Het is dus niet nodig iedereen wereldwijd af te wijzen, alleen om die reden niet. Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.


---

### `MinFarmingVertragerAfterBlok`

`byte` type met de standaard waarde van `60`. Deze eigenschap definieert een minimum aantal tijd, in seconden, welke ASF zal wachten voor het hervatten van kaarten als het eerder losgekoppeld is van `LoggedInElsewhere`, wat gebeurt wanneer je besluit om de huidige landbouw ASF geforceerd te ontkoppelen door een spel te starten. Deze vertraging is vooral om gemak en overhead redenen Het maakt het bijvoorbeeld mogelijk om het spel te herstarten zonder opnieuw te hoeven vechten met ASF om je account te bezetten omdat het slot voor een split seconde beschikbaar was. Als gevolg van het feit dat terugvordering van de sessie veroorzaakt dat `InElsewhere` de verbinding verbreekt, moet ASF de volledige verbindingprocedure doorlopen welke de machine en het Steam netwerk extra onder druk zet, waardoor het voorkomen van extra ontkoppelingen, indien mogelijk, de voorkeur heeft. Standaard is dit geconfigureerd op `60` seconden, dit zou genoeg moeten zijn om het spel zonder veel gedoe te herstarten. Er zijn echter scenario's wanneer u geïnteresseerd zou kunnen zijn in het verhogen ervan. bijvoorbeeld als je netwerk vaak verbroken is en ASF te snel overneemt, waardoor je gedwongen bent om zelf door het verbindingproces heen te gaan. We staan een maximumwaarde van `255` toe voor deze eigenschap, die genoeg zou moeten zijn voor alle algemene scenario's. Naast het bovenstaande is het ook mogelijk om de vertraging te verminderen, of zelfs geheel verwijderen met een waarde `0`, hoewel dit om bovengenoemde redenen meestal niet wordt aanbevolen. Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

### `Optimalisatiemodus`

`byte` type met de standaard waarde van `0`. Deze eigenschap definieert de optimalisatiemodus die ASF de voorkeur geeft tijdens de runtime. Momenteel ondersteunt ASF twee modi - `0` die `MaxPerformance`wordt genoemd, en `1` die `MinMemoryUsage` wordt genoemd. Standaard geeft ASF er de voorkeur aan zo veel mogelijk gelijktijdig (gelijkwaardig) uit te voeren. dit verbetert de prestaties door load-balanceerwerk in alle CPU cores, meerdere CPU threads, meerdere sockets en meerdere threadpool taken. ASF zal bijvoorbeeld bij het controleren op games naar je boerderij vragen naar je eerste badge pagina en na het ontvangen van een aanvraag arriveerde. ASF zal lezen hoeveel badge pagina's je daadwerkelijk hebt, en zal elkaar dan gelijktijdig opvragen. Dit is wat je zou moeten willen **bijna altijd**, omdat de overhead in de meeste gevallen minimaal is en de voordelen van asynchrone ASF-code zelfs op de oudste hardware kunnen worden gezien met een enkele CPU-kern en zeer beperkt vermogen. Echter, als veel taken parallel worden verwerkt, is ASF runtime verantwoordelijk voor hun onderhoud, bijvoorbeeld sockets open, threads levend houden en taken behandelen dit kan leiden tot meer geheugengebruik van tijd tot tijd, en als u extreem beperkt bent door het beschikbare geheugen, je kunt deze eigenschap veranderen naar `1` (`MinMemoryUsage`) om ASF te dwingen zo weinig mogelijk taken te gebruiken. en meestal op een synchrone manier draaien, mogelijk naar parallelle code. Overweeg om deze eigenschap alleen te wisselen als je eerder **[laag geheugen setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** hebt gelezen en je bewust gigantische prestaties wilt opofferen, voor een zeer klein geheugenverlies dat boven het hoofd daalt. Meestal is deze optie **veel erger** dan wat je kunt bereiken met andere mogelijke manieren zoals het beperken van je ASF-gebruik of het afstemmen van runtime garbagecollector, zoals uitgelegd in **[low-memory setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Daarom moet u `MinMemoryUsage` gebruiken als een **laatste resort**, meteen voor de runtime recompilatie, als je geen tevredenstellende resultaten kunt bereiken met andere (veel beter) opties. Tenzij u een **sterke** reden heeft om deze eigenschap te bewerken, moet u deze op standaard houden.

---

### `PluginsUpdateList`

`ImmutableHashSet<string>` type met de standaard waarde van leeg zijn. Deze eigenschap definieert een lijst van plugin assembly-namen die zijn geblokkeerd of op de witte lijst staan voor automatische updates, zoals per `PluginsUpdateMode` hieronder gedefinieerd.

Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

### `PluginsUpdateMode`

`byte` type met de standaard waarde van `0`. Deze eigenschap definieert de update-modus van plug-ins die betekenis geven aan `PluginsUpdateList` hierboven gedefinieerd. Door deze eigenschap aan te geven, kunt u gemakkelijk automatische updates voor alle plugins behalve deze aan-/uitschakelen.

- Waarde van `0`, genaamd `Whitelist`, **schakelt** automatisch bijwerken van alle plugins uit, behalve de plugins gedefinieerd in `PluginsUpdateList`.
- Waarde van `1`, genaamd `blacklist`, **maakt** automatische update van alle plugins mogelijk, behalve de plugins die gedefinieerd zijn in `PluginsUpdateList`.

**ASF team wil je eraan herinneren dat je voor je eigen veiligheid automatische updates van vertrouwde partijen** nodig hebt. Houd in gedachten dat kwaadaardige plugins zelf kunnen besluiten om zichzelf te updaten of externe opdrachten **uit te voeren ongeacht** van deze instelling. Dit is waarom deze instelling alleen van toepassing is op het bijwerken van plugins door ASF. en je moet er nog steeds voor zorgen dat je naar behoren elke plugin die je hebt gebruikt hebt geverifieerd.

Updates van plug-ins worden standaard uitgevoerd, samen met ASF updatereroutine - **[`UpdateChannel`](#updatechannel)** en **[`UpdatePeriode`](#updateperiod)**. Standaard ASF update mechanismen zoals `update` commando zal ook de optionele update van plugins activeren. Als je in plaats daarvan plugins handmatig wilt bijwerken zonder de ASF versie op hetzelfde moment te updaten, biedt `updateplugins` commando een dergelijke mogelijkheid.

Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

### `Afsluiten.Mogelijk`

`bool` type met standaard waarde van `false`. Indien ingeschakeld, zal ASF het proces proberen af te sluiten indien mogelijk, dat wil zeggen wanneer alle geregistreerde bots zijn gestopt. Dit kan vooral handig zijn wanneer gecombineerd met `Afgerond met AhutdownOnFarmingAfgerond` op alle bot instanties, omdat ASF op deze manier automatisch kan stoppen als de laatste bots klaar zijn met het kweken.

Omdat de verwachting van de meerderheid van de gebruikers is dat het proces te allen tijde draait. . voor `IPC` gebruik is deze optie standaard uitgeschakeld.

---

### `SteamMessagePrefix`

`string` type met de standaard waarde van `"/me "`. Deze eigenschap definieert een voorvoegsel dat zal worden toegevoegd aan alle Steam berichten die worden verzonden door ASF. Standaard gebruikt ASF `"/me "` voorvoegsel om bot berichten makkelijker te onderscheiden door ze in verschillende kleuren te laten zien bij Steam chat. Een andere waardevolle vermelding is `"/pre "` voorvoegsel dat vergelijkbaar resultaat behaalt, maar met een andere opmaak. Je kunt deze eigenschap ook op lege tekenreeks of `null` zetten om de prefix volledig te gebruiken en alle ASF-berichten op een traditionele manier uit te schakelen. Het is leuk om op te merken dat deze eigenschap alleen Steam berichten beïnvloedt - reacties die via andere kanalen (zoals IPC) zijn geretourneerd, worden niet beïnvloed. Tenzij u het standaard ASF-gedrag wilt aanpassen, is het een goed idee om het standaard te laten.

---

### `SteamOwnerID`

`ulong` type met de standaard waarde van `0`. Deze eigenschap definieert Steam ID in een 64-bit vorm van ASF proces eigenaar, en lijkt erg op `Master` toestemming voor de opgegeven bot instantie (maar globaal in de plaats). Je wilt deze eigenschap bijna altijd instellen op ID van je eigen Steam-account. `Master` toestemming bevat volledige controle over zijn bot instantie, maar globale commando's zoals `verlaten`, `herstart` of `update` zijn alleen gereserveerd voor `SteamOwnerID` Dit is handig omdat je misschien bots wilt uitvoeren voor je vrienden terwijl ze het ASF-proces niet kunnen besturen, zoals het afsluiten via `exit` commando. Standaardwaarde van `0` geeft aan dat er geen eigenaar is van ASF. dat betekent dat niemand globale ASF-commando's zal kunnen uitgeven. Houd er rekening mee dat deze eigenschap exclusief van toepassing is op Steam chat. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, evenals interactieve console, zal je nog steeds toestaan om `Eigenaar` commando's uit te voeren, zelfs als deze eigenschap niet is ingesteld.

---

### `SteamProtocollen`

`byte flags` type met de standaard waarde van `7`. Deze eigenschap definieert Steam protocollen die ASF zal gebruiken bij het verbinden met Steam servers, welke als hieronder zijn gedefinieerd:

| Waarde | Naam      | Beschrijving                                                                                     |
| ------ | --------- | ------------------------------------------------------------------------------------------------ |
| 0      | Geen      | Geen protocol                                                                                    |
| 1      | TCP       | **[Transmission Control Protocol](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2      | UDP       | **[User Datagram Protocol](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**               |
| 4      | Websocket | **[Websocket](https://en.wikipedia.org/wiki/WebSocket)**                                         |

Merk op dat deze eigenschap `vlaggen` veld is, dus het is mogelijk om een combinatie van beschikbare waarden te kiezen. Bekijk **[json mapping](#json-mapping)** als je meer wilt leren. Er wordt geen enkele markering ingeschakeld die resulteert in `Geen` optie, en die optie is op zichzelf ongeldig.

ASF zal standaard alle beschikbare Steam protocollen gebruiken als een maatregel voor het vechten met downtime en andere soortgelijke Steam problemen. Meestal wilt u deze eigenschap wijzigen als u wilt beperken tot het gebruik van slechts één of twee specifieke protocollen. Dergelijke maatregelen kunnen in verschillende situaties nodig zijn. Als u bijvoorbeeld UDP-verkeer op uw firewall hebt geblokkeerd en u wilt ervoor zorgen dat alleen TCP-verkeer doorgaat, of als je `WebProxy` gebruikt en het ook wilt gebruiken voor de Steam client connectie. omdat alleen `WebSocket` protocol dit ondersteunt.

Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

### `UpdateChannel`

`byte` type met de standaardwaarde van `1`. Deze eigenschap definieert updatekanaal dat wordt gebruikt, of voor auto-updates (als `UpdatePeriode` groter is dan `0`), of meldingen bijwerken (andere). Momenteel ondersteunt ASF drie updatekanalen - `0` die `Geen`heet, `1`, die `Stable`wordt genoemd, en `2`, die `PreRelease` heet. `Stable` kanaal is het standaard release kanaal, dat door de meerderheid van de gebruikers moet worden gebruikt. `PreRelease` kanaal naast `Stable` releases, ook **pre-releases** toegewijde voor geavanceerde gebruikers en andere ontwikkelaars om nieuwe functies te testen, bevestig bugfixes of geef feedback over geplande verbeteringen. **PreRelease versies bevatten vaak ongepatchte bugs, work-in-progress functies of herschreven implementaties**. Als je jezelf niet als geavanceerde gebruiker beschouwt, blijf dan met standaard `1` (`Stable`) het updatekanaal. `PreRelease` kanaal is gewijd aan gebruikers die weten hoe ze bugs moeten melden, omgaan met problemen en feedback geven - er wordt geen technische ondersteuning gegeven. Bekijk ASF **[release cycle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** als je meer wilt leren. U kunt ook `UpdateChannel` instellen op `0` (`Geen`), als u alle versiecontroles wilt verwijderen. `UpdateChannel` op `0` zetten zal volledige functionaliteit met betrekking tot updates, inclusief `update` commando. Het gebruik van `Geen` kanaal is **sterk afgeraden** als gevolg van allerlei problemen (genoemd in `UpdatePeriod` beschrijving hieronder).

**Unless you know what you're doing**, we **strongly** recommend to keep it at default.

---

### `UpdatePeriode`

`byte` type met de standaard waarde van `24`. Deze eigenschap definieert hoe vaak ASF moet controleren op automatische updates. Updates zijn niet alleen cruciaal voor het ontvangen van nieuwe functies en kritieke beveiligingspatronen, maar ook voor het ontvangen van bugfixes, prestatieverbeteringen, stabiliteitsverbeteringen en meer. Wanneer een waarde groter is dan `0` is ingesteld, zal ASF automatisch downloaden, vervangen. en herstart zichzelf (als `AutoRestart` toestaan) wanneer er een nieuwe update beschikbaar is. Om dit te bereiken, zal ASF elke `UpdatePeriod` uur controleren als er een nieuwe update beschikbaar is op onze GitHub repo. Een waarde van `0` schakelt automatische updates uit, maar u kunt nog steeds `bijwerken` commando handmatig uitvoeren. U kunt ook geïnteresseerd zijn in het instellen van de juiste `UpdateChannel` dat `UpdatePeriode` moet volgen.

Update-proces van ASF omvat het bijwerken van de gehele mapstructuur die ASF gebruikt, maar zonder je eigen configuraties of databases te aanraken in `config` map - dit betekent dat eventuele extra bestanden die niets met ASF te maken hebben verloren kunnen gaan tijdens het updaten. Standaardwaarde van `24` is een goede balans tussen onnodige controles en ASF die vers genoeg is.

Tenzij je een **sterke** reden hebt om deze functie uit te schakelen, u moet auto-updates ingeschakeld houden binnen redelijke `UpdatePeriod` **voor uw eigen goede**. Dit is niet alleen omdat we niets ondersteunen behalve de nieuwste stabiele ASF-release, maar ook omdat **we onze beveiligingsgarantie alleen geven voor de nieuwste versie**. Als je verouderde ASF-versie gebruikt, maak je jezelf opzettelijk bloot aan allerlei problemen, van kleine bugs, door defecte functionaliteit, eindigend met **[permanente Steam account onderbrekingen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**, dus raden wij **sterk aan**, voor je eigen goede, om er altijd voor te zorgen dat je ASF-versie up-to-date is. Auto-updates stellen ons in staat om snel op allerlei problemen te reageren door problematische code uit te schakelen of te patchen voordat deze kan escaleren - als u zich er niet voor kunt afmelden. je verliest al onze veiligheidsgaranties en de gevolgen van het uitvoeren van code die mogelijk schadelijk kan zijn. niet alleen naar het Steam netwerk, maar ook (per definitie) naar je eigen Steam account.

---

### `WebLimiterVertraging`

`ushort` type met de standaardwaarde van `300`. Deze eigenschap definieert, in miliseconden, het minimum aantal vertragingen tussen het sturen van twee opeenvolgende verzoeken naar dezelfde Steam web-service. Such delay is required as **[AkamaiGhost](https://www.akamai.com)** service that Steam uses internally includes rate-limiting based on global number of requests sent across given time period. Onder normale omstandigheden is bijna een blok moeilijk te realiseren, maar onder zeer zware werklasten met een grote voortdurende rij verzoeken, het is mogelijk om het te activeren als we voortdurend te veel verzoeken sturen over te korte tijdsperiode.

Standaardwaarde is ingesteld op basis van veronderstelling dat ASF de enige tool is die toegang heeft tot Steam web-diensten, in het bijzonder `steamcommunity. om`, `api.steampowered.com` en `store.steampowered.com`. Als u andere tools gebruikt die verzoeken naar dezelfde webservices verzenden, dan moet u ervoor zorgen dat uw tool dezelfde functionaliteit van `WebLimiterDelay` bevat en beide op de standaard waarde instellen wat `600` zou zijn. Dit garandeert dat onder geen enkele omstandigheid meer dan 1 verzoek per `300` ms.

In het algemeen het verlagen van `WebLimiterDelay` met de standaard waarde is **sterk ontmoedigd** omdat het kan leiden tot verschillende IP-gerelateerde blokken, Een aantal daarvan kan permanent zijn. Standaardwaarde is goed genoeg voor het draaien van een enkele ASF-instantie op de server, en ASF gebruiken in normale scenario samen met de originele Steam client. Het zou juist moeten zijn voor het grootste deel van het gebruik, en u zou het alleen moeten verhogen (nooit minder). Kortom: globale aantal verzoeken van één IP adres naar één Steam domein mag nooit groter zijn dan 1 verzoek per `300` ms.

Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

### `WebProxy`

`string` type met standaard waarde van `nul`. Deze eigenschap definieert een webproxy adres dat wordt gebruikt voor interne http-gerelateerde communicatie, vooral voor diensten zoals `github. om`, `api.steampowered.com`, `steamcommunity.com` en `store.steampowered.com`. Het is van toepassing op algemene (niet-bot specifieke) communicatie, evenals bot-specifieke communicatie als hun equivalent `WebProxy` configuratie-eigenschap niet is ingesteld. Verlenging van ASF-verzoeken kan buitengewoon nuttig zijn om verschillende soorten firewalls te omzeilen, met name de grote firewall in China.

Deze eigenschap is gedefinieerd als uri tekenreeks:

> Een URI-tekenreeks is samengesteld uit een schema (ondersteund: http/https/socks4/socks4a/socks5), een host en een optionele poort. Een voorbeeld van een complete uri string is `"http://contoso.com:8080"`.

Als uw proxy gebruikersauthenticatie vereist, moet u ook `WebProxyUsername` en/of `WebProxyPassword` instellen. Als dat niet nodig is, is het voldoende om dit eigendom alleen op te zetten.

Als je ook een proxying internal Steam netwerk communicatie (CMs) nodig hebt, dan zorg je ervoor om **[`SteamProtocols`](#steamprotocols)** Boot te configureren naar een waarde die alleen het vervoer van websocket toestaat. . Een waarde van `4`, omdat alleen websockets ondersteund worden voor proxying.

Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

### `WebProxyWachtwoord`

`string` type met standaard waarde van `nul`. Deze eigenschap definieert het wachtwoordveld dat wordt gebruikt in de basis, digest, NTLM, en Kerberos authenticatie die wordt ondersteund door een target `WebProxy` machine met proxy-functionaliteit. Als uw proxy geen gebruikersreferenties vereist, is het niet nodig om hier iets in te voeren. Het gebruik van deze optie is alleen zinvol als `WebProxy` ook wordt gebruikt, anders heeft het geen effect.

Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

### `WebProxyUsername`

`string` type met standaard waarde van `nul`. Deze eigenschap definieert een gebruikersnaam veld dat gebruikt wordt in de basis, digest, NTLM, en Kerberos authenticatie die wordt ondersteund door een target `WebProxy` machine met proxy-functionaliteit. Als uw proxy geen gebruikersreferenties vereist, is het niet nodig om hier iets in te voeren. Het gebruik van deze optie is alleen zinvol als `WebProxy` ook wordt gebruikt, anders heeft het geen effect.

Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

## Bot-configuratie

Zoals u al zou moeten weten, moet elke bot zijn eigen configuratie hebben op basis van het voorbeeld JSON systeem hieronder. Begin met beslissen hoe je de bot een naam wilt geven (bijv. `1.json`, `main. son`, `primary.json` of `AnythingElse.json`) en ga naar de configuratie.

**Mededeling:** Bot kan niet genoemd worden `ASF` (omdat dat trefwoord is gereserveerd voor de globale configuratie), ASF negeert ook alle configuratiebestanden die beginnen met een punt.

De bot-configuratie heeft de volgende structuur:

```json
{
    "AcceptGifts": onwaar,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Ingeschakeld": false,
    "Boerderijen": [],
    "BoerderingVoorkeuren": 0,
    "GamesPlayedWhileIdle": [],
    "GamingDeviceType": 1,
    "HoursUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "MachineNaam": null,
    "MatchableTypes": [5],
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "PasswordFormaat": 0,
    "RuilingVoorkeuren": 0,
    "RemoteCommunication": 3,
    "SendTradePeriod": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPerie": 60,
    "TradingPreferences": 0,
    "Overdraagbare Types": [1, 3, 5],
    "UseLoginKeys": waar,
    "UserInterfaceModus": 0,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Alle opties zijn hieronder uitgelegd:

### `AcceptGifts`

`bool` type met standaard waarde van `false`. Wanneer ingeschakeld, zal ASF automatisch alle Steam geschenken (met inbegrip van portemonnee cadeaukaarten) accepteren en inwisselen die naar de bot worden verzonden. Dit omvat ook cadeaus die verzonden worden van andere gebruikers dan die welke gedefinieerd zijn in `SteamUserPermissions`. Houd er rekening mee dat geschenken die naar een e-mailadres zijn gestuurd, niet rechtstreeks naar de klant worden doorgestuurd, dus ASF accepteert deze niet zonder jouw hulp.

Deze optie is alleen aanbevolen voor alt-accounts, omdat het zeer waarschijnlijk is dat je niet automatisch alle geschenken wilt inwisselen die naar je primaire account zijn verstuurd. Als u niet zeker weet of deze functie ingeschakeld moet worden of niet, houd deze dan met de standaardwaarde van `false`.

---

### `Botgedrag`

`byte flags` type met de standaard waarde van `0`. Deze eigenschap definieert ASF bot-achtig gedrag tijdens verschillende evenementen en is hieronder gedefinieerd:

| Waarde | Naam                              | Beschrijving                                                                                                            |
| ------ | --------------------------------- | ----------------------------------------------------------------------------------------------------------------------- |
| 0      | Geen                              | Geen speciale bot gedrag, magere standaardinstellingen                                                                  |
| 1      | Ontwerp InvalidFriendInvites      | Zal ervoor zorgen dat ASF ongeldige vriend uitnodigingen verwerpt (in plaats van negeren)                               |
| 2      | Handelsannulering afwijzen        | Zal ervoor zorgen dat ASF ongeldige handelsaanbiedingen afwijst (in plaats van negeren)                                 |
| 4      | Afwijzen InvalidGroupInvites      | Zal ervoor zorgen dat ASF ongeldige uitnodigingen voor de groep verwerpt (in plaats van negeren)                        |
| 8      | Verwijder InventarisNotificaties  | Zal ervoor zorgen dat ASF alle voorraadmeldingen automatisch verwijdert                                                 |
| 16     | Ontvangen berichtengelezen        | Zal ervoor zorgen dat ASF alle ontvangen berichten automatisch als gelezen markeert                                     |
| 32     | Wordt gelezen                     | Zal ervoor zorgen dat ASF berichten van andere ASF-bots automatisch markeert (draait in dezelfde instantie) als gelezen |
| 64     | UitschakelenIncomingTradesParsing | Zal ASF nooit inkomende handelsaanbiedingen verwerken                                                                   |

Merk op dat deze eigenschap `vlaggen` veld is, dus het is mogelijk om een combinatie van beschikbare waarden te kiezen. Bekijk **[json mapping](#json-mapping)** als je meer wilt leren. Geen enkele van de resultaten van vlaggen inschakelen in `Geen` optie.

In het algemeen wil je deze eigenschap wijzigen als je verwacht verschillende automatiseringsinstellingen met betrekking tot bot's activiteit te wijzigen. Bij de standaardinstellingen moet ASF in niet-invasieve modus draaien, waardoor alleen nuttige automatisering mogelijk is die niet tegen de wil van de gebruiker ingaat.

Ongeldige vriendschapsuitnodiging is een uitnodiging die niet komt van gebruiker met `FamilySharing` rechten (gedefinieerd in `SteamUserPermissions`) of hoger. ASF in normale modus negeert deze uitnodigingen, zoals je zou verwachten, waardoor je de vrije keuze krijgt om ze te accepteren of niet. `Afwijzen VriendInvites` zal ervoor zorgen dat deze uitnodigingen automatisch worden geweigerd, welke de optie voor andere mensen praktisch zal uitschakelen om je toe te voegen aan hun vriendenlijst (zoals ASF zal al deze verzoeken weigeren, behalve mensen die worden gedefinieerd in `SteamUserPermissies`). Tenzij u alle vriendschapsuitnodigingen zonder meer wilt weigeren, moet u deze optie niet inschakelen.

Ongeldige handelsaanbieding is een aanbieding die niet wordt geaccepteerd via de ingebouwde ASF-module. Meer over deze kwestie vindt u in de sectie **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** die expliciet definieert welke soorten handel ASF automatisch wil accepteren. Geldige transacties worden ook gedefinieerd door andere instellingen, vooral `TradingPreferences`. `Afwijzen Onvalide Transacties` zullen ervoor zorgen dat alle ongeldige transactieaanbiedingen worden geweigerd, in plaats van genegeerd. Tenzij u alle handelsaanbiedingen zonder meer wilt ontkennen die niet automatisch door ASF worden geaccepteerd, moet u deze optie niet inschakelen.

Ongeldige groepsuitnodiging is een uitnodiging die niet afkomstig is van `SteamMasterClanID` groep. ASF in normale modus negeert deze groepsuitnodigingen, zoals je zou verwachten. laat je zelf beslissen of je lid wilt worden van een bepaalde Steam-groep of niet. `Afwijzen InvalidGroupInvites` zorgt ervoor dat al deze groepsuitnodigingen automatisch worden geweigerd, het effectief onmogelijk maken om je uit te nodigen voor een andere groep dan `SteamMasterClanID`. Tenzij u alle groepsuitnodigingen zonder meer wilt weigeren, moet u deze optie niet inschakelen.

`DismissInventoryNotifications` is uiterst nuttig wanneer je begint vervelend te worden door een constante Steam melding over het ontvangen van nieuwe items. ASF kan de notificatie zelf niet verwijderen, omdat die ingebouwd is in je Steam client, maar het is in staat om de notificatie automatisch te wissen na het ontvangen van de melding, die geen "nieuwe items in de inventaris" meer zal laten staan. Als u verwacht dat u zichzelf evalueert van alle ontvangen items (met name kaarten gekookt met ASF), dan moet u deze optie niet inschakelen. Denk eraan dat als je gek begint te worden, dit als een optie wordt aangeboden.

`MarkReceivedMessagesAsRead` will automatically mark **all** messages being received by the account on which ASF is running, both private and group, as read. Dit moet meestal alleen door Alt-accounts worden gebruikt om de "nieuw bericht" melding te wissen die bijvoorbeeld komt bij het uitvoeren van ASF commando's. We raden deze optie niet aan voor primaire accounts, tenzij u uzelf wilt verwijderen uit een soort van nieuwe berichten meldingen, **inclusief** degene die gebeurde toen je offline was, ervan uitgaande dat ASF nog open was om hem te ontslaan.

`MarkBotMessagesAsRead` werkt op een vergelijkbare manier door alleen bot berichten als gelezen te markeren. Houd er echter rekening mee dat wanneer je die optie op groep gebruikt met je bots en andere mensen Steam implementatie van de erkenning van chatbericht **ook** erkent alle berichten die zich voordeden **voor** het bericht dat je hebt gemarkeerd, dus als je toevallig geen niet-gerelateerd bericht wilt missen, wat tussenin gebeurde, dan wil je meestal vermijden om deze functie te gebruiken. Het is natuurlijk ook riskant wanneer je meerdere primaire accounts hebt (bijvoorbeeld van verschillende gebruikers) die in dezelfde ASF-instantie draaien, omdat je ook hun normale out-of-ASF-berichten kunt missen.

`IncomingTradesParsing` zal ervoor zorgen dat ASF geen inkomende handelsaanbiedingen kan parsen, dit betekent dat de gehele handelsfunctionaliteit gerelateerd aan die functie niet operationeel zal zijn. Omdat ASF standaard in de minst invasieve modus werkt, accepteren alleen handelsaanbiedingen van `Master` gebruikers en hoger, Nooit andere handelsaanbiedingen aanraken - inkomende transacties parsen is standaard ingeschakeld. Deze instelling is het meest zinvol voor mensen die geen extra aanvragen/overhead willen hebben met betrekking tot transacties die parseren en de hele logica buiten spel zetten. bijvoorbeeld omdat ze weten dat hun bots nooit master-trade aanvragen zullen ontvangen, en daarom hoeft ASF helemaal niet deel te nemen aan hun handelsactiviteiten. Houd er rekening mee dat deze optie ook alle andere opties die afhankelijk zijn van inkomende transacties zal uitschakelen zoals `AcceptDonaties` of `SteamTradeMatcher` - aangepaste plugins zullen inkomende handelsaanbiedingen ook niet op gebruikelijke wijze kunnen verwerken.

Als je niet zeker weet hoe je deze optie moet configureren, laat het dan het beste standaard achter.

---

### `CompleteTypesToSend`

`ImmutableHashSet<byte>` type met de standaard waarde van leeg zijn. Als ASF klaar is met het voltooien van een bepaalde set itemtypes die hier zijn gespecificeerd, het kan automatisch stoomhandel verzenden met alle voltooide sets naar de gebruiker met `Master` permissie, wat erg handig is als je een bot account wilt gebruiken voor een bepaalde account. . STM matching, tijdens het verplaatsen van voltooid wordt ingesteld op een ander account. Deze optie werkt hetzelfde als `loot` commando, Houd er daarom rekening mee dat het gebruiker met `Master` permissie vereist U heeft mogelijk ook een geldige `SteamTradeToken`nodig, evenals het gebruik van een account dat in aanmerking komt voor de handel.

Vanaf vandaag worden de volgende itemtypes ondersteund bij deze instelling:

| Waarde | Naam            | Beschrijving                                                              |
| ------ | --------------- | ------------------------------------------------------------------------- |
| 3      | FoilTradingCard | Folie variant van `TradingCard`                                           |
| 5      | TradingCard     | Steam trading kaart, wordt gebruikt voor het maken van badges (niet foil) |

Houd er rekening mee dat, ongeacht de bovenstaande instellingen, ASF zal alleen vragen naar **[Steam community items](https://steamcommunity.com/my/inventory/#753_6)** (`appID` van 753, `contextID` van 6), dus alle spelitems, geschenken en op vergelijkbare wijze zijn per definitie uitgesloten van het handelsaanbod.

Als gevolg van extra overhead bij het gebruik van deze optie het wordt aangeraden om het alleen te gebruiken op bot-accounts die een realistische kans hebben om sets alleen te voltooien - bijvoorbeeld het heeft geen zin om te activeren als je al `SendOnFarmingFinished` voorkeur gebruikt in `FarmingPreferences`, `SendTradePeriode` of `loot` commando op gebruikelijke basis.

Als je niet zeker weet hoe je deze optie moet configureren, laat het dan het beste standaard achter.

---

### `CustomGamePlayedWhileFarming`

`string` type met standaard waarde van `nul`. Als ASF landbouwer is, kan het zichzelf weergeven als "niet-stoam spel: `CustomGamePlayedWhileFarming`in plaats van momenteel gekookt spel. Dit kan handig zijn als je je vrienden wilt laten weten dat je aan het eten bent, toch wil je geen gebruik maken van `OnlineStatus` van `Offline`. ASF kan de werkelijke volgorde van het Steam netwerk niet garanderen. Dit is dus slechts een suggestie die al dan niet op de juiste wijze kan worden weergegeven. Met name aangepaste naam zal niet worden weergegeven in `Complex` landbouwalgoritme als ASF alle `32` slots vult met spellen die uren nodig hebben om te worden opgeblazen. Standaardwaarde van `null` schakelt deze functie uit.

ASF biedt een paar speciale variabelen die je optioneel in je tekst kunt gebruiken. `{0}` zal worden vervangen door ASF door `AppID` van momenteel gekweekte spel(s), terwijl `{1}` zal worden vervangen door ASF door `GameName` van momenteel gekookte spel(s).

---

### `CustomGamePlayedWhileIdle`

`string` type met standaard waarde van `nul`. Vergelijkbaar met `CustomGamePlayedWhileFarming`, maar voor de situatie wanneer ASF niets te doen heeft (als account is volledig bemaakt). ASF kan de werkelijke volgorde van het Steam netwerk niet garanderen. Dit is dus slechts een suggestie die al dan niet op de juiste wijze kan worden weergegeven. Als je `GamesPlayedWhileIdle` samen met deze optie gebruikt, houd dan in gedachten dat `GamesPlayedWhileIdle` prioriteit krijgt, Daarom kunt u niet meer dan `31` van hen verklaren, als anders `CustomGamePlayedWhileIdle` zal het slot voor een aangepaste naam niet kunnen bezetten. Standaardwaarde van `null` schakelt deze functie uit.

---

### `Ingeschakeld`

`bool` type met standaard waarde van `false`. Deze eigenschap definieert of bot is ingeschakeld. Ingeschakelde bot instantie (`true`) zal automatisch starten wanneer ASF wordt uitgevoerd, terwijl uitgeschakelde bot instantie (`false`) handmatig moet worden gestart. Elke bot is standaard uitgeschakeld, dus je wilt deze eigenschap waarschijnlijk overschakelen naar `waar` voor al je bots die automatisch gestart moeten worden.

---

### `FarmingOrders`

`ImmutableList<byte>` type met de standaard waarde om leeg te zijn. Deze eigenschap definieert de **voorkeur** farming order die wordt gebruikt door ASF voor gegeven bot account. Momenteel volgen er landbouworders beschikbaar:

| Waarde | Naam                   | Beschrijving                                                                                                        |
| ------ | ---------------------- | ------------------------------------------------------------------------------------------------------------------- |
| 0      | Ongesorteerd           | Niet sorteren, verbetert de CPU prestaties                                                                          |
| 1      | AppIDsOplopend         | Probeer eerst games te verbouwen met de laagste `appIDs`                                                            |
| 2      | Aflopend               | Probeer eerst games te bewerken met de hoogste `appIDs`                                                             |
| 3      | Oplopend               | Probeer spellen te boerderen met de laagste hoeveelheid kaarten die eerst over is                                   |
| 4      | Aflopend               | Probeer spellen te boerderen waarbij het hoogste aantal kaarten eerst daalt                                         |
| 5      | Uuroplopend            | Probeer spellen te bewerken met het laagste aantal uren dat als eerste gespeeld wordt                               |
| 6      | Aflopend               | Probeer spellen te herbouwen met het hoogste aantal uren dat als eerste gespeeld wordt                              |
| 7      | NamesAscending         | Probeer spellen te bewerken in alfabetische volgorde, te beginnen met A                                             |
| 8      | NamesAflopend          | Probeer spellen te bewerken in de omgekeerde alfabetische volgorde, te beginnen met Z                               |
| 9      | Willekeurig            | Probeer spellen te bewerken in een totaal willekeurige volgorde (verschillend op elke uitvoering van het programma) |
| 10     | BadgeLevelsOplopend    | Probeer eerst een boerderij te maken met de laagste badge levels                                                    |
| 11     | Aflopend               | Probeer spellen te boerderen met de hoogste badge niveaus eerst                                                     |
| 12     | Inwisseldatum oplopend | Probeer de oudste partijen op onze rekening eerst te herbouwen                                                      |
| 13     | Aflopend               | Probeer de nieuwste games eerst te herbouwen op onze rekening                                                       |
| 14     | MarketableOplopend     | Probeer spellen te bewerken met niet verkoopbare kaarten eerst (waarschuwing: duur om te berekenen)                 |
| 15     | MarketableAflopend     | Probeer spellen te bewerken met marketable card drops eerst (waarschuwing: duur om te berekenen)                    |

Aangezien deze eigenschap een array is, kunt u verschillende instellingen gebruiken in uw vaste bestelling. U kunt bijvoorbeeld waarden van `15`toevoegen, `11` en `7` om eerst op verhandelbare spellen te sorteren vervolgens door degenen met het hoogste badge en ten slotte alfabetisch. Zoals je kunt raden, is de volgorde van belang, zoals omgekeerd één (`7`, `11` en `15`) bereikt iets heel anders (sorteert spellen alfabetisch eerst. en omdat de spelnamen uniek zijn, zijn de andere twee feitelijk nutteloos. De meerderheid van de mensen zal waarschijnlijk slechts één orde gebruiken, van allemaal, maar in het geval dat je wilt, kun je ook verder sorteren door extra parameters.

Merk ook het woord "proberen" in alle bovenstaande omschrijvingen - de werkelijke ASF-bestelling is zwaar beïnvloed door geselecteerde **[kaarten landbouw algoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** en sortering heeft alleen invloed op resultaten die ASF ziet als dezelfde prestaties. Bijvoorbeeld, in `Simple` algoritme, geselecteerde `Boerderijen` moeten volledig gerespecteerd worden in de huidige landbouwsessie (omdat elk spel dezelfde prestatiegraad heeft), terwijl in `Complex` algoritme de werkelijke order uren als eerste wordt beïnvloed. en vervolgens gesorteerd volgens de gekozen `FarmingOrders`. Dit zal tot verschillende resultaten leiden, omdat spelen met de bestaande speeltijd een prioriteit hebben boven andere. zo effectief zal ASF liever spellen geven die al zijn doorgegeven `HoursUntilCardDrops` eerst. en pas daarna sorteer je deze spellen verder op jouw gekozen `FarmingOrders`. Hetzelfde geldt als ASF al opgevoed spellen heeft verloren, de resterende wachtrij zal eerst op uren sorteren (dat zal de tijd die nodig is om een van de resterende titels te knippen verlagen naar `HoursUntilCardDrops`). Daarom is deze configuratieeigenschap slechts een **suggestie** dat ASF zal proberen te respecteren zolang het de prestaties niet negatief beïnvloedt (in dit geval geeft ASF altijd de voorkeur aan landbouwprestaties boven `FarmingOrders`).

Er is ook landbouw prioriteit wachtrij die toegankelijk is via `fq` **[commando's](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Als het gebruikt wordt, wordt de werkelijke landbouworder eerst gesorteerd op prestaties, dan op basis van de landbouwrij en uiteindelijk op basis van je `FarmingOrders`.

---

### `BoerderijVoorkeuren`

`byte flags` type met de standaard waarde van `0`. Deze eigenschap definieert ASF gedrag gerelateerd aan de landbouw, en is hieronder gedefinieerd:

| Waarde | Naam                            |
| ------ | ------------------------------- |
| 0      | Geen                            |
| 1      | FarmingPausedByStandaard        |
| 2      | ShutdownOnFarmingAfgerond       |
| 4      | SendOnFarmingAfgerond           |
| 8      | FarmPriorityQueueOnly           |
| 16     | Overschrijfbare Spellen         |
| 32     | SkipUnplayedGames               |
| 64     | RiskyCardsDiscovery inschakelen |
| 256    | AutoUnpackBoosterPacks          |

Merk op dat deze eigenschap `vlaggen` veld is, dus het is mogelijk om een combinatie van beschikbare waarden te kiezen. Bekijk **[json mapping](#json-mapping)** als je meer wilt leren. Geen enkele van de resultaten van vlaggen inschakelen in `Geen` optie.

Alle opties zijn hieronder beschreven.

`FarmingPausedByDefault` definieert de eerste status van `Kaartboer` module. Normaal gesproken zal bot automatisch landbouwer starten bij het starten, ofwel vanwege `` of `start` commando. Het gebruik van `FarmingPausedByDefault` kan gebruikt worden als je handmatig `het automatische landbouwproces` wilt hervatten bijvoorbeeld omdat je `de hele tijd` wilt gebruiken en nooit automatische `Kaarten` module wilt gebruiken - dit werkt precies hetzelfde als `pauze` **[commando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

`ShutdownOnFarmingFinished` stelt je in staat om bot af te sluiten zodra het is voltooid. Normaal gesproken is ASF een account aan het "bezeten" voor de hele tijd dat het proces actief is. Wanneer dit account wordt uitgevoerd met landbouw, controleert ASF periodiek het (elke `IdleFarmingPeriod` uren), als in de tussentijd misschien nieuwe stoomkaarten worden toegevoegd om de landbouw weer op gang te brengen zonder het proces opnieuw op gang te brengen. Dit is nuttig voor de meerderheid van de mensen, aangezien ASF de landbouw automatisch kan hervatten wanneer dat nodig is. Maar misschien wilt u het proces daadwerkelijk stopzetten als er sprake is van een volledige farce, dat kunt u bereiken door deze vlag te gebruiken. Indien ingeschakeld, zal ASF doorgaan met uitloggen wanneer de account volledig is befarmed, wat betekent dat deze niet meer periodiek wordt gecontroleerd of bezet. Je moet zelf beslissen of je ASF de hele tijd aan deze bot instantie wil laten werken of misschien moet ASF er een einde aan maken wanneer er landbouw wordt bedreven.

Deze optie is het meest zinvol om te combineren met `SluitIfIfMogelijk`, dus wanneer alle accounts zijn gestopt, zal ASF ook afsluiten. zet je machine op rust en laat je andere acties plannen, zoals slaap of afsluiten op hetzelfde moment van de laatste kaartdaling.

`SendOnFarmingFinished` stelt je in staat om automatisch stoommhandel te verzenden met daarin alles wat tot dit punt is opgeslagen naar gebruiker met `Master` permissie, dat heel handig is als u zich niet wilt bezighouden met handelen. Deze optie werkt hetzelfde als `loot` commando, Houd er daarom rekening mee dat het gebruiker met `Master` permissie vereist U heeft mogelijk ook een geldige `SteamTradeToken`nodig, evenals het gebruik van een account dat in aanmerking komt voor de handel. Naast het initiëren van `loot` na het voltooien van de landbouw ASF zal ook `loot` initiëren op elke melding van nieuwe items (wanneer niet landbouwert), en na het voltooien van elke transactie die resulteert in nieuwe artikelen (altijd) wanneer deze optie actief is. Dit is vooral handig voor "doorsturen" items ontvangen van andere mensen naar ons account. Meestal zal je **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** samen met deze functie willen gebruiken, hoewel het geen vereiste is als u van plan bent om 2FA-bevestigingen handmatig op tijd te behandelen.

`FarmPriorityQueueOnly` definieert of ASF alleen voor automatische landbouw apps moet overwegen die je zelf hebt toegevoegd aan de prioritaire landbouw wachtrij die beschikbaar is met `fq` **[commando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Als deze optie is ingeschakeld, zal ASF alle `appIDs` overslaan die ontbreken in de lijst staat je in staat om spellen te kiezen voor automatische ASF-landbouw. Houd er rekening mee dat als je geen spellen aan de wachtrij hebt toegevoegd, ASF zal doen alsof er niets te eten is op je account.

`SkipRefundableGames` definieert of ASF spellen moet overslaan die nog steeds terug te betalen zijn van automatische landbouw. Een terugbetaalbaar spel is een spel dat je de afgelopen 2 weken via Steam Store hebt gekocht en nog niet langer dan 2 uur hebt gespeeld zoals gezegd op **[Steam refunds](https://store.steampowered.com/steam_refunds)** pagina. ASF negeert standaard het Steam restitutiebeleid volledig en kweekt alles, zoals de meeste mensen zouden verwachten. Je kan deze vlag echter wel gebruiken als je wilt dat ASF je spellen niet te snel betaalbaar maakt. laat je deze spellen zelf beoordelen en terugbetalen indien nodig zonder je zorgen te maken over ASF die speeltijd negatief beïnvloedt. Houd er rekening mee dat als je deze optie inschakelt, spellen die je in Steam Store hebt gekocht niet door ASF zullen worden gebruikt voor maximaal 14 dagen vanaf de wisseldatum. die als niets boer zal laten zien als je account geen eigenaar is van iets anders.

`SkipUnplayedGames` definieert of ASF spellen moet overslaan die je nog niet hebt gelanceerd. Ongespeelde game in deze context betekent dat je precies geen speeltijd hebt die er voor staat op Steam. Als je deze vlag gebruikt, dan zullen dergelijke spellen worden overgeslagen totdat Steam een speeltijd registreert. Dit stelt je in staat om beter te bepalen welke spellen ASF in aanmerking komt voor de boerderij. Sla die spellen over die je nog niet hebt kunnen uitproberen, de geselecteerde Steam-functies nuttiger houden - zoals het suggereren van onspeelde spellen om te spelen.

`Inschakelen van RiskyCardsDiscovery` maakt extra terugvallen mogelijk die veroorzaakt wanneer ASF niet één of meer badge pagina's kan laden en daarom niet in staat is om games te vinden die beschikbaar zijn voor de landbouw. In het bijzonder kunnen sommige accounts met een enorme hoeveelheid kaartdruppels leiden tot een situatie waarbij het laden van badges niet meer mogelijk is (als gevolg van overhead), en deze rekeningen zijn voor de landbouw onmogelijk omdat we de informatie niet kunnen laden op basis waarvan we het proces kunnen starten. Deze optie staat het gebruik van een alternatief algoritme toe welke een combinatie van boosters gebruikt om te maken en booster packs waarvoor het account in aanmerking komt om potentieel beschikbare spellen te vinden die kunnen worden inactief dan spendeer te veel middelen voor het verifiëren en ophalen van vereiste informatie. en probeert het proces te starten op basis van een beperkte hoeveelheid gegevens en informatie om uiteindelijk een situatie te bereiken wanneer de badgepasta geladen wordt en we kunnen gebruik maken van een normale benadering. Houd er rekening mee dat als deze terugval wordt gebruikt, ASF alleen werkt met beperkte gegevens. Het is dan ook volkomen normaal dat ASF veel minder druppels vindt dan in werkelijkheid - in een later stadium van het landbouwproces zullen er andere dalingen zijn.

Deze optie wordt "risky" genoemd voor een zeer goede reden - het is extreem traag en vereist een aanzienlijke hoeveelheid middelen (inclusief netwerkverzoeken) om te kunnen werken. Daarom is **niet aan te raden** om te worden ingeschakeld, en vooral niet op lange termijn. Gebruik deze optie alleen als je hebt vastgesteld dat je account lijdt aan het laden van badge pagina's en ASF kan er niet op bedienen. het niet laden van de noodzakelijke informatie om het proces te starten. Ook al hebben we ons best gedaan om het proces zoveel mogelijk te optimaliseren. het is nog steeds mogelijk om deze optie te backfire en het kan ongewenste resultaten veroorzaken zoals tijdelijke en misschien zelfs permanente bans van Steam zijde voor het verzenden van te veel verzoeken en anders overhead veroorzaken op Steam servers. Daarom waarschuwen we je op voorhand en bieden we deze optie zonder enige garanties, je gebruikt deze op eigen risico.

`AutoUnpackBoosterPacks` zal automatisch alle boosterpakketten uitpakken wanneer je nieuwe items krijgt. Dit zal u in staat stellen om direct extra kaartdrops te krijgen, die misschien wel gewild zijn in combinatie met andere opties (bv. . `SteamTradeMatcher` of `CompleteTypesToSend`).

---

### `GamesPlayedWhileIdle`

`ImmutableHashSet<uint>` type met de standaard waarde van leeg zijn. Als ASF niets te kweken heeft kan deze je opgegeven Steam games spelen (`appIDs`) in plaats daarvan. Het op een dergelijke manier spelen verhoogt je "uren spelen" van die spellen, maar niets anders dan dat. Om deze functie goed te laten werken. je Steam account **moet** een geldige licentie hebben voor alle `appIDs` die je hier opgeeft Hieronder vallen ook F2P-spelletjes. Deze functie kan op hetzelfde moment worden ingeschakeld met `CustomGamePlayedWhileIdle` om je geselecteerde spellen te spelen terwijl je een aangepaste status in het Steam-netwerk toont. maar in dit geval, zoals in `CustomGamePlayedWhileFarming` geval, is de werkelijke weergavevolgorde niet gegarandeerd. Houd er rekening mee dat Steam ASF alleen laat spelen tot `32` `appIDs` in totaal, Daarom kunt u maar even veel spelletjes in dit eigendom maken.

---

### `GamingApparaattype`

`ushort` type met de standaardwaarde van `1`. Deze eigenschap kan wat extra online functies op het Steam platform inschakelen en is hieronder gedefinieerd:

| Waarde | Naam        | Beschrijving                     |
| ------ | ----------- | -------------------------------- |
| 1      | StandaardPC | Geen speciale modus, standaard   |
| 544    | Steamdek    | Presenteer zichzelf als Steamdek |

Het onderliggende `EGamingDeviceType` type waarop deze eigenschap is gebaseerd bevat meer beschikbare waarden. Zij hebben echter tot op de bodem van onze kennis tot op heden geen enkel effect gesorteerd en zijn daarom voor de zichtbaarheid ervan gekort.

Als u niet zeker weet hoe u deze eigenschap instelt, laat dan staan met de standaardwaarde van `1`.

---

### `UurenUntilCardDrops`

`byte` type met de standaardwaarde van `3`. Deze eigenschap definieert of het account een beperking heeft van een kaart en zo ja, voor hoeveel beginuren. Beperkte kaart druppels betekent dat het account geen kaart drops van een bepaald spel ontvangt totdat het spel ten minste `HoursUntilCardDrops` uren wordt gespeeld. Helaas is er geen magische manier om dat te detecteren, dus ASF vertrouwt op jou. Deze eigenschap is van invloed op **[kaarten landbouw algoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** dat zal worden gebruikt. Het correct instellen van deze eigenschap zal de winst maximaliseren en de tijd beperken die vereist is voor kaarten die worden geteeld. Vergeet niet dat er geen duidelijk antwoord is op de vraag of je een of andere waarde moet gebruiken, aangezien het volledig afhankelijk is van je account. It seems that older accounts which never asked for refund have unrestricted card drops, so they should use a value of `0`, while new accounts and those who did ask for refund have restricted card drops with a value of `3`. Dit is echter slechts een theorie, en mag niet als regel worden beschouwd. De standaardwaarde voor deze eigenschap is gebaseerd op "minder kwaad " en de meeste gebruiksgevallen.

---

### `LootableTypes`

`ImmutableHashSet<byte>` type met de standaardwaarde van `1, 3, 5` stoam voorwerptypes. Deze eigenschap definieert ASF gedrag bij het plunderen - beide handleidingen, met behulp van een **[commando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, evenals automatische eigenschappen, door één of meer configuratie eigenschappen. ASF zorgt ervoor dat alleen items uit `LootableTypes` worden opgenomen in een transactieaanbod, Met deze eigenschap kunt u kiezen wat u wilt ontvangen in een transactieaanbod dat naar u wordt verzonden.

| Waarde | Naam                   | Beschrijving                                                                       |
| ------ | ---------------------- | ---------------------------------------------------------------------------------- |
| 0      | Unknown                | Elk type dat niet in een van de hieronder passen                                   |
| 1      | BoosterPack            | Booster pakket met 3 willekeurige kaarten uit een spel                             |
| 2      | Emoticon               | Emoticon om te gebruiken in Steam Chat                                             |
| 3      | FoilTradingCard        | Folie variant van `TradingCard`                                                    |
| 4      | Profielachtergrond     | Profielachtergrond om te gebruiken op je Steam profiel                             |
| 5      | TradingCard            | Steam trading kaart, wordt gebruikt voor het maken van badges (niet foil)          |
| 6      | SteamGems              | Steam edelstenen worden gebruikt voor het maken van boosters, ook zakken opgenomen |
| 7      | VerkoopItem            | Speciale items toegekend gedurende Steam verkoop                                   |
| 8      | Verbruiksartikelen     | Speciaal verbruikbare items die verdwijnen nadat ze gebruikt zijn                  |
| 9      | Profilewijziger        | Speciale voorwerpen die het Steam profiel uiterlijk kunnen aanpassen               |
| 10     | Sticker                | Speciale voorwerpen die gebruikt kunnen worden in Steam chat                       |
| 11     | ChatEffect             | Speciale voorwerpen die gebruikt kunnen worden in Steam chat                       |
| 12     | MiniProfileAchtergrond | Speciale achtergrond voor Steam profiel                                            |
| 13     | AvatarProfileFrame     | Speciaal avatar frame voor Steam profiel                                           |
| 14     | AnimatedAvatar         | Speciale geanimeerde avatar voor Steam profiel                                     |
| 15     | Toetsenbord            | Speciaal toetsenbord skin voor het Steam dek                                       |
| 16     | OpstartVideo           | Speciale opstart video voor Steam deck                                             |

Houd er rekening mee dat, ongeacht de bovenstaande instellingen, ASF zal alleen vragen naar **[Steam community items](https://steamcommunity.com/my/inventory/#753_6)** (`appID` van 753, `contextID` van 6), dus alle spelitems, geschenken en op vergelijkbare wijze zijn per definitie uitgesloten van het handelsaanbod.

Standaard ASF-instelling is gebaseerd op het meest voorkomende gebruik van de bot, met het plunderen van alleen boosterpakketten, en handelskaarten (inclusief foils). De hier gedefinieerde eigenschap laat u toe om dat gedrag te veranderen op de manier die u tevreden stelt. Houd er rekening mee dat alle types die niet zijn gedefinieerd zullen worden weergegeven als `Onbekend` type, wat vooral belangrijk is wanneer Radiatorkraan nieuwe Steam items uitbrengt, die ook wordt gemarkeerd als `Unknown` door ASF, totdat het hier wordt toegevoegd (in de toekomstige release). Daarom is het over het algemeen niet aanbevolen om `Onbekend` type op te nemen in je `LootableTypes`, tenzij je weet wat je aan het doen bent en je begrijpt ook dat ASF je volledige voorraad in een trade aanbieding zal sturen als Steam netwerk opnieuw gebroken wordt en al je items als `Onbekend` rapporteren. Mijn sterke suggestie is om geen `Onbekend` type in de `LootableTypes`op te nemen, zelfs als je verwacht alles te plunderen (anders).

---

### `MachineNaam`

`string` type met standaard waarde van `nul`. ASF zal deze eigenschap gebruiken bij het inloggen op het Steam netwerk welke gebruikt kan worden voor aanpassingen met betrekking tot hoe Steam precies de ASF-machine en sessie zal weergeven. . bij het weergeven van apparaten die momenteel zijn ingelogd **[hier](https://store.steampowered.com/account/authorizeddevices)**.

ASF biedt een paar speciale variabelen die je optioneel in je tekst kunt gebruiken. `{0}` zal worden vervangen door de naam van de machine zoals voorzien door uw OS, `{1}` zal worden vervangen door ASF's publieke identificatie, terwijl `{2}` wordt vervangen door ASF's versie.

Tenzij je weet wat je aan het doen bent, moet je het houden met de standaardwaarde van `null`. In dit geval beslist ASF intern over de juiste waarde, dat is `{0} ({1}/{2})` vanaf vandaag. Houd er rekening mee dat dit slechts een suggestie is dat het Steam-netwerk volledig kan of kan respecteren.

---

### `MatchableTypes`

`ImmutableHashSet<byte>` type met standaard waarde `5` Steam item types. Deze eigenschap definieert welke Steam item types toegestaan zijn om overeen te komen wanneer `SteamTradeMatcher` optie in `TradingPreferences` is ingeschakeld. Types zijn hieronder gedefinieerd:

| Waarde | Naam                   | Beschrijving                                                                       |
| ------ | ---------------------- | ---------------------------------------------------------------------------------- |
| 0      | Unknown                | Elk type dat niet in een van de hieronder passen                                   |
| 1      | BoosterPack            | Booster pakket met 3 willekeurige kaarten uit een spel                             |
| 2      | Emoticon               | Emoticon om te gebruiken in Steam Chat                                             |
| 3      | FoilTradingCard        | Folie variant van `TradingCard`                                                    |
| 4      | Profielachtergrond     | Profielachtergrond om te gebruiken op je Steam profiel                             |
| 5      | TradingCard            | Steam trading kaart, wordt gebruikt voor het maken van badges (niet foil)          |
| 6      | SteamGems              | Steam edelstenen worden gebruikt voor het maken van boosters, ook zakken opgenomen |
| 7      | VerkoopItem            | Speciale items toegekend gedurende Steam verkoop                                   |
| 8      | Verbruiksartikelen     | Speciaal verbruikbare items die verdwijnen nadat ze gebruikt zijn                  |
| 9      | Profilewijziger        | Speciale voorwerpen die het Steam profiel uiterlijk kunnen aanpassen               |
| 10     | Sticker                | Speciale voorwerpen die gebruikt kunnen worden in Steam chat                       |
| 11     | ChatEffect             | Speciale voorwerpen die gebruikt kunnen worden in Steam chat                       |
| 12     | MiniProfileAchtergrond | Speciale achtergrond voor Steam profiel                                            |
| 13     | AvatarProfileFrame     | Speciaal avatar frame voor Steam profiel                                           |
| 14     | AnimatedAvatar         | Speciale geanimeerde avatar voor Steam profiel                                     |
| 15     | Toetsenbord            | Speciaal toetsenbord skin voor het Steam dek                                       |
| 16     | OpstartVideo           | Speciale opstart video voor Steam deck                                             |

Natuurlijk zijn er types die u voor deze eigenschap moet gebruiken meestal alleen `2`, `3`, `4` en `5`, omdat alleen die typen door STM worden ondersteund. ASF bevat de juiste logica voor het ontdekken van de zeldzaamheid van de items, daarom is het ook veilig om emoticons of achtergronden aan te passen, omdat ASF naar behoren alleen die voorwerpen van hetzelfde spel en type zal overwegen die ook dezelfde zeldzaamheid hebben.

**ASF is geen handelsbot** en **geeft niets om de marktprijs**. Als u items van dezelfde zeldzaamheid van dezelfde set niet als dezelfde prijsrichting beschouwt, dan is deze optie NIET voor u. Beoordeel twee keer als u deze verklaring begrijpt en accepteert voordat u besluit deze instelling te wijzigen.

Tenzij je weet wat je aan het doen bent, moet je het behouden met de standaardwaarde van `5`.

---

### `Online vlaggen`

`ushort vlaggen` type met standaard waarde van `0`. Deze eigenschap werkt als aanvulling op **[`OnlineStatus`](#onlinestatus)** en specificeert additionele online aanwezigheidsfuncties die zijn aangekondigd voor het Steam netwerk. Vereist **[`OnlineStatus`](#onlinestatus)** anders dan `Offline`en wordt als hieronder gedefinieerd:

| Waarde | Naam               | Beschrijving                                         |
| ------ | ------------------ | ---------------------------------------------------- |
| 0      | Geen               | Geen speciale online aanwezigheidsvlaggen, standaard |
| 2      | InJoinableGame     | Klant is in een joinable spel                        |
| 8      | RemotePlayTogether | Client gebruikt een externe sessie                   |
| 256    | ClientTypeWeb      | Client gebruikt de webinterface                      |
| 512    | ClientTypeMobiel   | Client gebruikt een mobiele app                      |
| 1024   | ClientTypeTenfoot  | Client gebruikt grote afbeelding                     |
| 2048   | ClientTypeVR       | Client gebruikt VR-headset                           |

Merk op dat deze eigenschap `vlaggen` veld is, dus het is mogelijk om een combinatie van beschikbare waarden te kiezen. Bekijk **[json mapping](#json-mapping)** als je meer wilt leren. Geen enkele van de resultaten van vlaggen inschakelen in `Geen` optie.

De onderliggende `EPersonaStateFlag` type waarop deze eigenschap is gebaseerd met meer beschikbare vlaggen, Zij hebben echter tot op de bodem van onze kennis tot op heden geen enkel effect gesorteerd en zijn daarom voor de zichtbaarheid ervan gekort.

Als u niet zeker weet hoe u deze eigenschap instelt, laat dan staan met de standaardwaarde van `0`.

---

### `OnlineStatus`

`byte` type met de standaardwaarde van `1`. Deze eigenschap specificeert de Steam community status waarmee de bot zal worden aangekondigd na het inloggen in het Steam netwerk. Momenteel kunt u kiezen uit een van de onderstaande statussen:

| Waarde | Naam           |
| ------ | -------------- |
| 0      | Offline        |
| 1      | Online         |
| 2      | Bezig          |
| 3      | Afwezig        |
| 4      | Uitstellen     |
| 5      | LookingToTrade |
| 6      | LookingToPlay  |
| 7      | Onzichtbaar    |

`Offline` status is uiterst nuttig voor primaire accounts. Zoals je zou moeten weten toont het houden van een spel eigenlijk je stoom status als "Speelt spel: XXX", die misleidend kan zijn voor je vrienden, waardoor je hen verwart dat je een spel speelt terwijl je het in feite alleen maar kweekt. Het gebruik van `Offline` status lost dat probleem op - je account zal nooit worden getoond als "in-game" wanneer je stoomkaarten met ASF gebruikt. Dit is mogelijk dankzij het feit dat ASF zich niet hoeft aan te melden bij de Steam Community om goed te werken. dus in feite spelen we deze spellen, verbonden met Steam-netwerk, maar zonder onze online aanwezigheid te aankondigen. Hou er rekening mee dat afgespeelde spellen die de offline status gebruiken nog steeds meetellen voor je speeltijd en laten zien als "recent gespeeld" op je profiel.

Daarnaast is deze functie ook belangrijk als je meldingen en ongelezen berichten wilt ontvangen wanneer ASF actief is, terwijl je de Steam client niet tegelijkertijd open houdt. Dit komt omdat ASF werkt als een Steam-client zelf, en of ASF het wil of niet. Steam zendt al die berichten en andere gebeurtenissen uit. Dit is geen probleem als je zowel ASF als je eigen Steam client actief hebt, omdat beide clients precies dezelfde evenementen ontvangen. Echter, als ASF gewoon draait, kan Steam-netwerk bepaalde events en berichten markeren als "bezorgd", ondanks dat je traditionele Steam client het niet heeft ontvangen omdat het niet aanwezig is. Offline status lost dit probleem ook op, omdat ASF in dit geval nooit wordt beschouwd bij evenementen in de gemeenschap dus alle ongelezen berichten en andere gebeurtenissen worden goed gemarkeerd als ongelezen wanneer je terugkomt.

Het is belangrijk om op te merken dat ASF die draait op `Offline` modus **niet** in staat zal zijn om commando's te ontvangen op de gebruikelijke Steam chat manier. als chat en als geheel is de aanwezigheid van de gemeenschap in feite volledig offline. Een oplossing voor dit probleem is het gebruik van `onzichtbare` modus die op een vergelijkbare manier werkt (niet de status aan het onthullen), maar houd de mogelijkheid om berichten te ontvangen en te reageren (dus ook een mogelijkheid om meldingen en ongelezen berichten af te wijzen zoals hierboven genoemd). `onzichtbare` modus heeft het meest zin op ALT-accounts dat je niet wilt onthullen (status-wise), maar nog steeds in staat om opdrachten te verzenden.

Er is echter één vangst met `onzichtbare` modus - het gaat niet goed met primaire accounts. Dit komt omdat **elke** Steam sessie die momenteel online **is, de status geeft** aan zelfs als ASF dat niet doet. Dit wordt veroorzaakt door de huidige limitatie/bug van het Steam netwerk dat niet mogelijk is om te worden verholpen aan ASF kant. dus als u `onzichtbare` modus wilt gebruiken, moet u er ook voor zorgen dat **alle ** alle** andere sessies met hetzelfde account ook `onzichtbare` modus gebruiken. Dit zal het geval zijn op alt-rekeningen waar ASF hopelijk de enige actieve sessie is, maar op primaire accounts zul je bijna altijd als `Online` aan je vrienden willen laten zien. Verbergen van alleen ASF-activiteit, en in dit geval zal `onzichtbare` modus volledig nutteloos voor u zijn (we raden in plaats daarvan aan om `Offline` modus te gebruiken). Hopelijk wordt deze beperking/bug uiteindelijk in de toekomst opgelost door Radiatorkraan, maar ik zou niet verwachten dat dit te allen tijde gebeurt...</p>

Als je niet zeker weet hoe je deze eigenschap moet instellen, het wordt aangeraden om een waarde van `0` (`Offline`) te gebruiken voor primaire accounts, en standaard `1` (`Online`) anders.

---

### `Wachtwoordformaat`

`byte` type met de standaard waarde van `0` (`PlainText`). Deze eigenschap definieert het formaat van `SteamPassword` eigenschap, en ondersteunt momenteel waarden die zijn opgegeven in de **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** sectie. Je zou de daar opgegeven instructies moeten volgen. omdat u ervoor moet zorgen dat `SteamPassword` eigenschap inderdaad een wachtwoord bevat dat overeenkomt met `PasswordFormat`. In other words, when you change `PasswordFormat` then your `SteamPassword` should be **already** in that format, not just aiming to be. Tenzij je weet wat je aan het doen bent, moet je het houden met de standaardwaarde van `0`.

Als je besluit om `PasswordFormat` te wijzigen van een bot die ten minste één keer heeft ingelogd op het Steam netwerk Het is mogelijk dat je eenmalige decodeerfout krijgt bij de start van de volgende bot, dit wordt veroorzaakt door het feit dat `PasswordFormat` ook wordt gebruikt met betrekking tot automatische versleuteling/decodering van gevoelige eigenschappen in `Bot. b` databasebestand. Je kunt deze fout veilig negeren, aangezien ASF alleen van deze situatie kan herstellen. Als het echter constant gebeurt, bijvoorbeeld bij elke herstart, moet het worden onderzocht.

---

### `Inwisselvoorkeuren`

`byte flags` type met de standaard waarde van `0`. Deze eigenschap definieert ASF gedrag bij het inwisselen van productsleutels, en is als hieronder gedefinieerd:

| Waarde | Naam                                | Beschrijving                                                                                                                            |
| ------ | ----------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| 0      | Geen                                | Geen voorkeuren voor speciale inwisselingen, standaard                                                                                  |
| 1      | Doorsturen                          | Toekennen niet beschikbaar om in te wisselen voor andere bots                                                                           |
| 2      | Distributie                         | Verdeel alle sleutels onder zichzelf en andere bots                                                                                     |
| 4      | KeepMissingGames                    | Houd sleutels voor (mogelijk) ontbrekende spellen wanneer doorgaat, waardoor ze ongebruikt blijven                                      |
| 8      | VerlangWalletKeyOnBadActivationCode | Stel dat `BadActivationCode` sleutels gelijk zijn aan `CannotRedeemCodeFromClient`, en probeer ze daarom te verzilveren als wallet keys |

Merk op dat deze eigenschap `vlaggen` veld is, dus het is mogelijk om een combinatie van beschikbare waarden te kiezen. Bekijk **[json mapping](#json-mapping)** als je meer wilt leren. Geen enkele van de resultaten van vlaggen inschakelen in `Geen` optie.

`Doorsturen` zorgt ervoor dat bot een sleutel doorstuurt die niet mogelijk is in te wisselen, aan een andere verbonden en ingelogd bot die dat specifieke spel mist (indien mogelijk om te controleren). De meest voorkomende situatie is het doorsturen van `AlreadyGekochte` spel naar een andere bot die dat specifieke spel mist, deze optie dekt echter ook andere scenario's, zoals `DoesNotOwnRequiredApp`, `RateLimited` of `Beperkt Land`.

`Distributie` zorgt ervoor dat bot alle ontvangen sleutels onder zichzelf en andere bots verdeelt. Dit betekent dat elke bot een enkele sleutel van de partij krijgt. Meestal wordt dit alleen gebruikt wanneer je meerdere sleutels voor hetzelfde spel inwisselt, en je wilt ze gelijkelijk verdelen over je bots, in plaats van sleutels te gebruiken voor verschillende spellen. Deze functie heeft geen zin als u slechts één sleutel inwisselt in een enkele `inwisselactie` actie (er zijn geen extra sleutels te verspreiden).

`KeepMissingGames` zal bot dwingen om `doorsturen` over te slaan wanneer we niet zeker kunnen zijn of de sleutel die wordt ingewisseld eigendom is van onze bot, of niet. This basically means that `Forwarding` will apply **only** to `AlreadyPurchased` keys, instead of covering also other cases such as `DoesNotOwnRequiredApp`, `RateLimited` or `RestrictedCountry`. Meestal wilt u deze optie gebruiken op de primaire account, om ervoor te zorgen dat sleutels die erop worden ingewisseld niet verder worden doorgestuurd als je bot bijvoorbeeld tijdelijk `RateLimited` wordt. Zoals je kunt aanraden uit de beschrijving, heeft dit veld absoluut geen effect als `Doorsturen` niet is ingeschakeld.

`AssumeWalletKeyOnBadActivationCode` zal ervoor zorgen dat `BadActivationCode` toetsen worden behandeld als `CannotRedeemCodeFromClient`, en resulteert er daarom in dat ASF probeert ze te gebruiken als portemonnee sleutel. Dit is nodig omdat Steam portemonnee sleutels kan aankondigen als `BadActivationCode` (en niet `CannotRedeemCodeFromClient` zoals het gebruikt), ASF zal nooit proberen om ze in te wisselen. We raden **tegen** aan door deze voorkeur te gebruiken, omdat het zal resulteren in ASF pogingen om elke ongeldige sleutel als portemonnee code in te wisselen resulteert in een buitensporig aantal (mogelijk ongeldig) verzoeken verzonden naar de Steam service, met alle mogelijke consequenties. In plaats daarvan we raden aan om `ForceAssumeWalletKey` **[`te gebruiken in ^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** mode terwijl we willens en wetens portemonnee sleutels gebruiken, welke de benodigde werktijd alleen inschakelt wanneer dit nodig is, op basis van de benodigde werkwijze.

Het inschakelen van zowel `doorsturen` en `Distributing` zal de distributiefunctie bovenop het doorsturen van een eigenschap toevoegen. waardoor ASF eerst probeert één sleutel op alle bots in te wisselen (vooruitstrevend) voordat je naar de volgende gaat (verdelen). Meestal wilt u deze optie alleen gebruiken wanneer u `Doorsturen`, maar met een gewijzigd gedrag van het wisselen van de bot bij gebruik van de sleutel in plaats van altijd in de volgorde te gaan met elke sleutel (wat `alleen` zou zijn). Dit gedrag kan nuttig zijn als je weet dat de meerderheid of zelfs al je sleutels aan hetzelfde spel zijn gekoppeld, omdat in deze situatie `Doorsturen` alleen zal proberen om alles op één bot eerst in te wisselen (wat logisch is als je sleutels zijn voor unieke spellen), en `Doorsturen` + `Distributeren` zal de bot op de volgende toets zetten, "verdelen" de taak van het inwisselen van nieuwe sleutel naar een andere bot dan de aanvankelijke (wat logisch is als de sleutels voor hetzelfde spel zijn, één zinloze poging overslaan per sleutel).

De werkelijke bots volgorde voor alle wisselscenario's is alfabetisch, exclusief bots die niet beschikbaar zijn (niet aangesloten, gestopt of soortgelijk). Houd er rekening mee dat er per IP en per account een uurlimiet is voor het verzilveren van pogingen, en elke verzilvering probeer die niet eindigde met `OK` draagt bij aan mislukte pogingen. ASF zal zijn best doen om het aantal `AlreadyGekocht` fouten te minimaliseren, bijvoorbeeld door te proberen te voorkomen dat een sleutel wordt doorgestuurd naar een andere bot die al eigenaar is van dat specifieke spel, maar het werkt niet altijd gegarandeerd door hoe Steam licenties behandelt. Het inwisselen van vlaggen zoals `vooruitsturen` of `Distributing` zal je altijd meer kans maken om `RateLimited` te raken.

Houd er ook rekening mee dat je geen sleutels kunt doorsturen of distribueren naar bots waar je geen toegang toe hebt. Dat zou voor de hand moeten liggen maar zorg ervoor dat je ten minste `Operator` bent van alle bots die je wilt opnemen in je inwisselingsproces bijvoorbeeld met `status ASF` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `RemoteCommunication`

`byte flags` type met standaard waarde `3`. Deze eigenschap definieert het gedrag per bot ASF als het gaat om communicatie met externe diensten van derden en is als hieronder gedefinieerd:

| Waarde | Naam       | Beschrijving                                                                                                                                                                                                                                                      |
| ------ | ---------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0      | Geen       | Geen communicatie van derden toegestaan, weergave van geselecteerde ASF-functies onbruikbaar                                                                                                                                                                      |
| 1      | Steamgroep | Staat communicatie toe met **[ASF's Steam groep](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                    |
| 2      | Publicatie | Allows communication with **[ASF's STM listing](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** in order to being listed, if user has also enabled `SteamTradeMatcher` in **[`TradingPreferences`](#tradingpreferences)** |

Merk op dat deze eigenschap `vlaggen` veld is, dus het is mogelijk om een combinatie van beschikbare waarden te kiezen. Bekijk **[json mapping](#json-mapping)** als je meer wilt leren. Geen enkele van de resultaten van vlaggen inschakelen in `Geen` optie.

Deze optie omvat niet alle communicatie van derden door ASF, alleen die welke niet door andere instellingen worden gesuggereerd. Als je bijvoorbeeld de automatische updates van ASF hebt ingeschakeld, zal ASF communiceren met zowel GitHub (voor downloads) als onze server (voor checksum verificatie), zoals volgens je configuratie. Vergelijk, het inschakelen van `MatchActively` in **[`TradingPreferences`](#tradingpreferences)** impliceert communicatie met onze server om vermelde bots op te halen, die vereist is voor die functionaliteit.

Verdere uitleg over dit onderwerp is beschikbaar in **[externe communicatie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** sectie. Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

### `VerzendingPeriode`

`byte` type met de standaard waarde van `0`. Deze eigenschap werkt erg vergelijkbaar met `SendOnFarmingFinished` voorkeur in `BoeringVoorkeuren`, met één verschil - in plaats van de handel te sturen wanneer er landbouw wordt bedreven we kunnen het ook elke `SendTradePeriode` uur sturen, ongeacht hoeveel we nog moeten vertrekken. This is useful if you want to `loot` your alt accounts on usual basis instead of waiting for it to finish farming. Standaardwaarde van `0` schakelt deze functie uit, als je wilt dat je bot je handel stuurt. . Elke dag moet je `24` hier plaatsen.

Meestal zal je **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** samen met deze functie willen gebruiken, hoewel het geen vereiste is als u van plan bent om 2FA-bevestigingen handmatig op tijd te behandelen. Als u niet zeker weet hoe u deze eigenschap instelt, laat dan staan met de standaardwaarde van `0`.

---

### `SteamLogin`

`string` type met standaard waarde van `nul`. Deze eigenschap definieert je Steam login - degene die je gebruikt om in te loggen op stoom. Naast het definiëren van de Steam login hier je kan ook de standaardwaarde van `null` behouden als je bij elke ASF start je Steam login wilt invoeren in plaats van deze in de configuratie te zetten. Dit kan handig zijn als je geen gevoelige data in het configuratiebestand wilt opslaan.

---

### `SteamMasterClanID`

`ulong` type met de standaard waarde van `0`. Deze eigenschap definieert de stoamID van de stoomgroep die bot automatisch zou moeten toetreden, inclusief zijn groeps-chat. U kunt de steamID van uw groep controleren door naar de **[pagina](https://steamcommunity.com/groups/archiasf)**te navigeren en dan `/memberslistxml? ml=1` aan het einde van de link, dus de link ziet er als **[dit](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. Dan kun je stoamID van je groep krijgen van het resultaat, het is in `<groupID64>` tag. Bovenstaande zou het zijn `103582791440160998`. Naast het proberen deel te nemen aan deze groep bij het opstarten, zal de bot ook automatisch groepsuitnodigingen voor deze groep accepteren. wat het mogelijk maakt om je bot handmatig uit te nodigen als je groep een privé lidmaatschap heeft. Als je geen groep voor je bots hebt, moet je deze eigenschap behouden met de standaardwaarde van `0`.

---

### `SteamOuderCode`

`string` type met standaard waarde van `nul`. Deze eigenschap definieert je stoomouderlijk PIN. ASF heeft toegang nodig tot bronnen die beschermd worden door het stoomouderschap, dus als je die functie gebruikt, je moet ASF ouderlijke ontgrendelingspincode geven, zodat deze normaal kan werken. Standaardwaarde van `null` betekent dat er geen steam ouderlijk PIN nodig is om dit account te ontgrendelen. en dit is waarschijnlijk wat je wilt als je geen stoomouderlijke functionaliteit gebruikt.

In beperkte omstandigheden is ASF ook in staat om zelf een geldige Steam ouders-code te genereren. dat overmatige hoeveelheid OS-bronnen en extra tijd vereist om te voltooien, maar om nog maar te zwijgen dat het gegarandeerd niet zal lukken, Daarom raden we aan om niet te vertrouwen op die functie en in plaats daarvan geldige `SteamParentalCode` in de config te plaatsen om ASF te gebruiken. Als ASF bepaalt dat de PIN-code alleen moet worden gegenereerd, vraagt het je om invoer.

---

### `SteamWachtwoord`

`string` type met standaard waarde van `nul`. Deze eigenschap definieert uw Steam wachtwoord - degene die u gebruikt om in te loggen op stoom. Naast het definiëren van het Steam wachtwoord hier je kan ook de standaardwaarde van `null` behouden als je je Steam wachtwoord wilt invoeren bij elke ASF start in plaats van het in de configuratie te zetten. Dit kan handig zijn als je geen gevoelige data in het configuratiebestand wilt opslaan.

---

### `SteamTradeToken`

`string` type met standaard waarde van `nul`. Wanneer je je bot op je vriendenlijst hebt, dan kan bot direct een handel naar je sturen zonder je zorgen te maken over het handelstoken Daarom kunt u deze eigenschap op de standaardwaarde van `null` laten staan. Als je besluit om je bot NIET op je vriendenlijst te zetten dan moet je een trade token genereren en invullen als de gebruiker waarnaar deze bot transacties verwacht te verzenden. In andere woorden, deze eigenschap moet worden gevuld met een handelstoken van het account dat is gedefinieerd met `Master` toestemming in `SteamUserPermissions` of **deze** bot instantie.

Om uw token te vinden, is aangemelde gebruiker met `Master` toestemming navigeer **[hier](https://steamcommunity.com/my/tradeoffers/privacy)** en neem een kijkje in uw trade URL. Het token dat we zoeken is gemaakt van 8 tekens na `&token=` onderdeel in je trade URL. U moet deze 8 tekens hier kopiëren en plaatsen, zoals `SteamTradeToken`. Bevat niet alle trading URL, noch `&token=` deel, alleen de token zelf (8 tekens).

---

### `SteamUserPermissies`

`ImmutableDictionary<ulong, byte>` type met de standaard waarde om leeg te zijn. Deze eigenschap is een woordenboekeigenschap die de Steam gebruiker in kaart brengt, geïdentificeerd door zijn 64-bit stoam ID, naar `byte` nummer dat zijn toestemming aangeeft in ASF instantie. Momenteel beschikbare bot permissies in ASF worden gedefinieerd als:

| Waarde | Naam          | Beschrijving                                                                                                                                                                                                               |
| ------ | ------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0      | Geen          | Geen speciale machtiging, dit is voornamelijk een referentiewaarde die is toegewezen aan stoom-IDs die ontbreken in dit woordenboek - er is geen noodzaak om iemand met deze machtiging te definiëren                      |
| 1      | FamilySharing | Biedt minimale toegang voor gebruikers die familie delen. Nogmaals, dit is voornamelijk een referentiewaarde omdat ASF automatisch stoom-ID's kan ontdekken die we hebben toegestaan voor het gebruik van onze bibliotheek |
| 2      | Operator      | Biedt toegang tot bepaalde botinstanties, hoofdzakelijk licenties toevoegen en sleutels inwisselen                                                                                                                         |
| 3      | Master        | Biedt volledige toegang tot deze bot instantie                                                                                                                                                                             |

Kortom, dit eigendom stelt u in staat om machtigingen te gebruiken voor bepaalde gebruikers. Permissies zijn vooral belangrijk voor toegang tot ASF **[commando's](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, maar ook voor het inschakelen van veel ASF-functies, zoals het accepteren van transacties. U kunt bijvoorbeeld uw eigen account instellen als `Master`, en geef `Operator` toegang tot 2-3 van je vrienden zodat ze makkelijk de sleutels voor je bot kunnen inwisselen met ASF, terwijl **niet** in aanmerking komt. . om het te stoppen. Dankzij dat je gemakkelijk machtigingen kunt toewijzen aan bepaalde gebruikers en ze de bot laat gebruiken voor wat gespecificeerd door jou.

We raden aan om precies één gebruiker in te stellen als `Master`, en elk bedrag dat je wilt als `Operators` en hieronder. Hoewel het technisch mogelijk is om meerdere `Masters` in te stellen, werkt ASF er goed mee. bijvoorbeeld door al hun verzonden transacties aan de bot te accepteren, ASF zal slechts één van hen gebruiken (met de laagste stoom-ID) voor elke actie die een enkel doel vereist, bijvoorbeeld een `loot` verzoek. dus ook eigenschappen zoals `SendOnFarmingFinished` voorkeur in `FarmingPreferences` of `SendTradePeriod`. Als u deze beperkingen heel goed begrijpt, vooral het feit dat `loot` verzoek altijd items zal sturen naar de `Master` met de laagste stoom-ID, ongeacht de `Master` die het commando daadwerkelijk uitvoerden, dan kunt u hier meerdere gebruikers definiëren met `Master` toestemming, maar we raden nog steeds een enkel masterplan aan.

Het is leuk om op te merken dat er nog een extra `Eigenaar` permissie is, die wordt aangeduid als `SteamOwnerID` globale configuratie eigenaar. Je kunt `Eigenaar` toestemming geven aan iemand hier, als `SteamUserPermissions` eigenschap definieert alleen rechten die gerelateerd zijn aan de bot bijvoorbeeld: en niet ASF als een proces. Voor bot-gerelateerde taken wordt `SteamOwnerID` hetzelfde behandeld als `Master`, dus het definiëren van je `SteamOwnerID` is hier niet nodig.

---

### `Handelsperiode`

`byte` type met de standaard waarde van `60`. Normaal gesproken behandelt ASF inkomende transacties in direct nadat je een melding hebt ontvangen, maar soms kan het vanwege Steam storingen niet op dat moment en dergelijke handelsaanbiedingen blijven genegeerd totdat de volgende handelsmelding of bot herstart plaatsvindt, wat kan leiden tot annulering van transacties of items die later niet beschikbaar zijn. Als deze parameter is ingesteld op een niet-nulwaarde, zal ASF elke `TradeCheckPeriod` minuten additioneel controleren op dergelijke uitstaande transacties. Standaardwaarde wordt geselecteerd met een saldo tussen extra verzoeken om stoomservers en het verlies van inkomende transacties. Echter, als je ASF alleen gebruikt voor de boerderijkaarten, en niet van plan bent om automatisch inkomende transacties te verwerken, je kunt het instellen op `0` om deze functie volledig uit te schakelen. Anderzijds als je bot deelneemt aan openbare [ASF's STM listing](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) of andere geautomatiseerde diensten als een trade bot, u wilt deze parameter misschien verlagen tot `15` minuten om alle transacties tijdig te verwerken.

---

### `TradingPreferences`

`byte flags` type met de standaard waarde van `0`. Deze eigenschap definieert ASF gedrag tijdens het handelen en is als hieronder gedefinieerd:

| Waarde | Naam                | Beschrijving                                                                                                                                                                                                                 |
| ------ | ------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0      | Geen                | Geen speciale handelspreferenties, standaard                                                                                                                                                                                 |
| 1      | Accepteer Donaties  | Accepteert transacties waarin we niets verliezen                                                                                                                                                                             |
| 2      | SteamTradeMatcher   | Neem actief deel aan **[STM](https://www.steamtradematcher.com)**-achtige transacties. Bezoek **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** voor meer info                    |
| 4      | WedstrijdAlles      | Vereist `SteamTradeMatcher` om te worden ingesteld, en in combinatie hiermee - accepteert ook slechte trades naast goede en neutrale trades                                                                                  |
| 8      | DontAcceptBotTrades | Accepteert niet automatisch `loot` transacties van andere bot instanties                                                                                                                                                     |
| 16     | Wedstrijd actief    | Actief neemt deel aan **[STM](https://www.steamtradematcher.com)**-achtige transacties. Bezoek **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** voor meer info |

Merk op dat deze eigenschap `vlaggen` veld is, dus het is mogelijk om een combinatie van beschikbare waarden te kiezen. Bekijk **[json mapping](#json-mapping)** als je meer wilt leren. Geen enkele van de resultaten van vlaggen inschakelen in `Geen` optie.

For further explanation of ASF trading logic, and description of every available flag, please visit **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** section.

---

### `Overdraagbare Types`

`ImmutableHashSet<byte>` type met de standaardwaarde van `1, 3, 5` stoam voorwerptypes. This property defines which Steam item types will be considered for transfering between bots, during `transfer` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. ASF zorgt ervoor dat alleen items van `TransferableTypes` worden opgenomen in een transactieaanbod, Met deze eigenschap kunt u kiezen wat u wilt ontvangen in een transactieaanbod dat naar een van uw bots wordt verzonden.

| Waarde | Naam                   | Beschrijving                                                                       |
| ------ | ---------------------- | ---------------------------------------------------------------------------------- |
| 0      | Unknown                | Elk type dat niet in een van de hieronder passen                                   |
| 1      | BoosterPack            | Booster pakket met 3 willekeurige kaarten uit een spel                             |
| 2      | Emoticon               | Emoticon om te gebruiken in Steam Chat                                             |
| 3      | FoilTradingCard        | Folie variant van `TradingCard`                                                    |
| 4      | Profielachtergrond     | Profielachtergrond om te gebruiken op je Steam profiel                             |
| 5      | TradingCard            | Steam trading kaart, wordt gebruikt voor het maken van badges (niet foil)          |
| 6      | SteamGems              | Steam edelstenen worden gebruikt voor het maken van boosters, ook zakken opgenomen |
| 7      | VerkoopItem            | Speciale items toegekend gedurende Steam verkoop                                   |
| 8      | Verbruiksartikelen     | Speciaal verbruikbare items die verdwijnen nadat ze gebruikt zijn                  |
| 9      | Profilewijziger        | Speciale voorwerpen die het Steam profiel uiterlijk kunnen aanpassen               |
| 10     | Sticker                | Speciale voorwerpen die gebruikt kunnen worden in Steam chat                       |
| 11     | ChatEffect             | Speciale voorwerpen die gebruikt kunnen worden in Steam chat                       |
| 12     | MiniProfileAchtergrond | Speciale achtergrond voor Steam profiel                                            |
| 13     | AvatarProfileFrame     | Speciaal avatar frame voor Steam profiel                                           |
| 14     | AnimatedAvatar         | Speciale geanimeerde avatar voor Steam profiel                                     |
| 15     | Toetsenbord            | Speciaal toetsenbord skin voor het Steam dek                                       |
| 16     | OpstartVideo           | Speciale opstart video voor Steam deck                                             |

Houd er rekening mee dat, ongeacht de bovenstaande instellingen, ASF zal alleen vragen naar **[Steam community items](https://steamcommunity.com/my/inventory/#753_6)** (`appID` van 753, `contextID` van 6), dus alle spelitems, geschenken en op vergelijkbare wijze zijn per definitie uitgesloten van het handelsaanbod.

Standaard ASF-instelling is gebaseerd op het meest voorkomende gebruik van de bot, met alleen boosterpakketten en handelskaarten (met inbegrip van foils). De hier gedefinieerde eigenschap laat u toe om dat gedrag te veranderen op de manier die u tevreden stelt. Houd er rekening mee dat alle types die niet zijn gedefinieerd zullen worden weergegeven als `Onbekend` type, wat vooral belangrijk is wanneer Radiatorkraan nieuwe Steam items uitbrengt, die ook wordt gemarkeerd als `Unknown` door ASF, totdat het hier wordt toegevoegd (in de toekomstige release). Daarom is het over het algemeen niet aan te raden om `Onbekend` type op te nemen in je `overdraagbare Types`, tenzij je weet wat je aan het doen bent en je begrijpt ook dat ASF je volledige voorraad in een trade aanbieding zal sturen als Steam netwerk opnieuw gebroken wordt en al je items als `Onbekend` rapporteren. Mijn sterke suggestie is om geen `Unknown` type in de `overdraagbare Types`toe te voegen, zelfs als je verwacht dat je alles overdraagt.

---

### `UseLoginKeys`

`bool` type met standaard waarde `true`. Deze eigenschap definieert of ASF inlog keys mechanisme moet gebruiken voor dit Steam account. Login keys mechanisme werkt erg vergelijkbaar met de optie "onthoud mij" van de officiële Steam client waarmee ASF de tijdelijke login sleutel kan opslaan en gebruiken voor de volgende login poging, effectief een behoefte aan het opgeven van wachtwoord, Steam-Guard of 2FA-code overgeslagen zolang onze inlogsleutel geldig is. Inlog-sleutel wordt opgeslagen in het `BotName.db` bestand en automatisch bijgewerkt. Daarom hoef je geen wachtwoord/SteamGuard/2FA code te verstrekken nadat je bent ingelogd met ASF maar één keer.

Inlog-toetsen worden standaard gebruikt zodat je geen `SteamPassword`hoeft in te voeren, SteamGuard of 2FA code (wanneer u ****[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**niet gebruikt) bij elke login. Het is ook superieur omdat de login sleutel slechts één keer kan worden gebruikt en op geen enkele manier uw oorspronkelijke wachtwoord onthult. Precies dezelfde methode wordt gebruikt door je originele Steam client, die je accountnaam en login sleutel opslaat voor je volgende login poging, effectief hetzelfde als het gebruik van `SteamLogin` met `UseLoginKeys` en lege `SteamPassword` in ASF.</p>

Maar sommige mensen zouden zich zelfs zorgen kunnen maken over dit kleine detail Daarom is deze optie hier voor je beschikbaar als je ervoor wilt zorgen dat ASF geen token meer opslaat die het mogelijk maakt om de vorige sessie te hervatten nadat deze is gesloten, wat zal resulteren in volledige authenticatie verplicht zijn bij elke inlogpoging. Het uitschakelen van deze optie werkt precies hetzelfde als het niet controleren van "onthoud mij" in officiële Steam cliënt. Tenzij je weet wat je aan het doen bent, moet je het houden met de standaardwaarde van `true`.

---

### `Modus`

`byte` type met de standaard waarde van `0`. Deze eigenschap specificeert de interface-modus van de gebruiker waarmee de bot zal worden aangekondigd na het inloggen op het Steam netwerk. Het kan invloed hebben op hoe het account zichtbaar is, bijvoorbeeld op de Steam chat, als je presentie dit toestaat via `OnlineStatus`. Momenteel kunt u kiezen uit een van de onderstaande modi:

| Waarde | Naam       | Beschrijving                 |
| ------ | ---------- | ---------------------------- |
| `0`    | VGUI       | Standaard Steam client modus |
| `1`    | Tenfoot    | Grote afbeeldingsmodus       |
| `2`    | Mobiel     | Steam mobiele app            |
| `3`    | Internet   | Webbrowser sessie            |
| `5`    | MobileChat | Steam mobiele chat app       |

Het onderliggende `EUIMode` type waarop deze eigenschap is gebaseerd bevat echter meer beschikbare waarden. Voor zover wij weten hebben ze vanaf vandaag geen enkel effect en daarom is er geen enkele zichtbaarheid meer geboden. Je zou ook geïnteresseerd kunnen zijn in het checken van `GamingDeviceType`, omdat sommige extra functies daar zijn ingeschakeld.

Als u niet zeker weet hoe u deze eigenschap instelt, laat dan staan met de standaardwaarde van `0`.

---

### `WebProxy`

`string` type met standaard waarde van `nul`. Deze eigenschap definieert een webproxy-adres dat wordt gebruikt voor bot-specifieke interne http-gerelateerde communicatie, vooral voor diensten zoals `api. teampowered.com`, `steamcommunity.com` en `store.steampowered.com`. Indien niet ingesteld, zal ASF de globale `WebProxy` instelling gebruiken die hierboven is aangegeven. Verlenging van ASF-verzoeken kan buitengewoon nuttig zijn om verschillende soorten firewalls te omzeilen, met name de grote firewall in China.

Deze eigenschap is gedefinieerd als uri tekenreeks:

> Een URI-tekenreeks is samengesteld uit een schema (ondersteund: http/https/socks4/socks4a/socks5), een host en een optionele poort. Een voorbeeld van een complete uri string is `"http://contoso.com:8080"`.

Als uw proxy gebruikersauthenticatie vereist, moet u ook `WebProxyUsername` en/of `WebProxyPassword` instellen. Als dat niet nodig is, is het voldoende om dit eigendom alleen op te zetten.

Als je ook een proxying internal Steam netwerk communicatie (CMs) nodig hebt, dan zorg je ervoor om **[`SteamProtocols`](#steamprotocols)** Boot te configureren naar een waarde die alleen het vervoer van websocket toestaat. . Een waarde van `4`, omdat alleen websockets ondersteund worden voor proxying.

Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

### `WebProxyWachtwoord`

`string` type met standaard waarde van `nul`. Deze eigenschap definieert het wachtwoordveld dat wordt gebruikt in de basis, digest, NTLM, en Kerberos authenticatie die wordt ondersteund door een target `WebProxy` machine met proxy-functionaliteit. Als uw proxy geen gebruikersreferenties vereist, is het niet nodig om hier iets in te voeren. Het gebruik van deze optie is alleen zinvol als `WebProxy` ook wordt gebruikt, anders heeft het geen effect.

Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

### `WebProxyUsername`

`string` type met standaard waarde van `nul`. Deze eigenschap definieert een gebruikersnaam veld dat gebruikt wordt in de basis, digest, NTLM, en Kerberos authenticatie die wordt ondersteund door een target `WebProxy` machine met proxy-functionaliteit. Als uw proxy geen gebruikersreferenties vereist, is het niet nodig om hier iets in te voeren. Het gebruik van deze optie is alleen zinvol als `WebProxy` ook wordt gebruikt, anders heeft het geen effect.

Tenzij u een reden heeft om deze eigenschap te bewerken, dient u deze op standaard te houden.

---

## Bestandsstructuur

ASF gebruikt een vrij eenvoudige bestandsstructuur.

```text
・・📁 config
ρρρρASF. zoon
・・ASF.db
ρρBot1. zoon
½ ½ Engles Bot1.db
ρρexceeds Bot2. zoon
½ ½ ½ Bot2.db
format@@6 ρρρ...
├── ArchiSteamFarm.dll
├── log.txt
└── ...
```

Om ASF naar nieuwe locatie te verplaatsen, bijvoorbeeld een andere PC, is het voldoende om `config` map alleen te verplaatsen/kopiëren. en dat is de aanbevolen manier om elke vorm van "ASF backups", te doen omdat je altijd het resterende (programma) deel kunt downloaden van GitHub, zonder het risico te lopen interne ASF-bestanden te corrigeren, b.v. . door een foutieve back-up.

`log.txt` bestand bevat het log gegenereerd door de laatste ASF run. Dit bestand bevat geen gevoelige informatie en is uiterst nuttig als het gaat om problemen, crasht of gewoon als informatie over wat er is gebeurd bij ASF. We zullen heel vaak vragen stellen over dit bestand als je problemen of fouten tegenkomt. ASF beheert automatisch dit bestand voor jou, maar je kunt ASF **[logging](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging)** module verder aanpassen als je geavanceerde gebruiker bent.

`config` map is de plaats waar ASF configuratie heeft, inclusief alle bots.

`ASF.json` is een globaal ASF configuratiebestand. Deze configuratie wordt gebruikt om te bepalen hoe ASF zich gedraagt als een proces, wat van invloed is op alle bots en programma's zelf. Hier vind je de globale accommodaties, zoals de ASF-proceseigenaar, auto-updates of foutopsporing.

`BotName.json` is een configuratie van de opgegeven bot instantie. Deze configuratie wordt gebruikt voor het opgeven van hoe een bot instantie zich gedraagt. Daarom zijn deze instellingen alleen voor die bot specifiek en niet over andere instellingen gedeeld. Dit stelt je in staat bots te configureren met verschillende instellingen en niet noodzakelijkerwijs allemaal op precies dezelfde manier. Elke bot heeft een unieke identifier, gekozen door jou in plaats van `BotName`.

Behalve configuratiebestanden gebruikt ASF ook `config` directory voor het opslaan van databases.

`ASF.db` is een globaal ASF databasebestand. Het fungeert als een wereldwijde persistente opslag en wordt gebruikt voor het opslaan van verschillende informatie gerelateerd aan ASF-proces, zoals IP's van lokale Steam servers. **Je moet dit bestand niet bewerken**.

`BotName.db` is een database van de opgegeven bot instantie. Dit bestand wordt gebruikt voor het opslaan van cruciale data over een bepaalde bot instantie in blijvende opslag, zoals login sleutels of ASF 2FA. **Je moet dit bestand niet bewerken**.

`BotName.keys` is een speciaal bestand dat kan worden gebruikt voor het importeren van sleutels naar **[achtergrond spellen redeemer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. Het is niet verplicht en niet gegenereerd, maar herkend door ASF. Dit bestand wordt automatisch verwijderd nadat sleutels succesvol zijn geïmporteerd.

`BotName.maFile` is een speciaal bestand dat kan worden gebruikt voor het importeren van **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**. Het is niet verplicht en niet gegenereerd, maar herkend door ASF als je `BotName` nog geen ASF 2FA gebruikt. Dit bestand wordt automatisch verwijderd nadat ASF 2FA succesvol is geïmporteerd.

---

## JSON toewijzing

Elke configuratie eigenschap heeft zijn type. Type van de eigenschap definieert waarden die daarvoor geldig zijn. U kunt alleen waarden gebruiken die geldig zijn voor het opgegeven type - als u een ongeldige waarde gebruikt vervolgens zal ASF niet in staat zijn om uw configuratie te parsen.

**We raden ten zeerste aan ConfigGenerator te gebruiken voor het genereren van configuraties** - het behandelt de meeste dingen op laag niveau (zoals types validatie) voor jou, dus je hoeft alleen maar de juiste waarden in te voeren, en je hoeft ook geen variabele types te begrijpen die hieronder zijn opgegeven. Deze sectie is voornamelijk voor mensen die handmatig configuraties genereren/bewerken, zodat ze weten welke waarden ze kunnen gebruiken.

Soorten die gebruikt worden door ASF zijn native C# types, die hieronder zijn opgegeven:

---

`bool` - Booleaanse type accepteert alleen `true` en `false` waarden.

Voorbeeld: `"Ingeschakeld": waar`

---

`byte` - Niet-ondertekend byte type, het accepteren van alleen getallen van `0` tot `255` (inclusief).

Voorbeeld: `"ConnectionTimeout": 90`

---

`ushort` - Niet-ondertekend kort type, accepteert alleen gehele getallen van `0` tot `65535` (inclusive).

Voorbeeld: `"WebLimiterDelay": 300`

---

`uint` - Ontworpen integer type, accepteert alleen getallen van `0` tot `4294967295` (inclusief).

---

`ulong` - Niet-ondertekend lang integer type, accepteert alleen gehele getallen van `0` tot `18446744073709551615` (inclusief).

Voorbeeld: `"SteamMasterClanID": 103582791440160998`

---

`string` - String type, accepteert elke reeks tekens, inclusief lege reeks `""` en `nul`. Lege volgorde en `null` waarde worden door ASF hetzelfde behandeld Dus het is tot uw voorkeur welke u wilt gebruiken (we houden vast aan `null`).

Voorbeelden: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MyAccountName"`

---

`Guid?` - Nullable UUID type, in JSON gecodeerd als string. UUID is gemaakt van 32 hexadecimale tekens, variërend van `0` tot `9` en `een` tot `f`. ASF accepteert verschillende geldige formaten - kleine letters, hoofdletters, met en zonder streepjes. Naast een geldig UUID, aangezien deze eigenschap nulbaar is een speciale waarde van `null` wordt geaccepteerd om het gebrek aan UUID aan te geven.

Voorbeelden: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableList<valueType>` - Onveranderbare collectie (lijst) van waarden in gegeven `valueType`. In JSON, is het gedefinieerd als een reeks van elementen in de gegeven `waardetype`. ASF maakt gebruik van `List` om aan te geven dat een bepaalde eigenschap meerdere waarden ondersteunt en dat hun bestelling relevant kan zijn.

Voorbeeld voor `ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` - Onveranderbare collectie (set) van unieke waarden in gegeven `waardetype`. In JSON, is het gedefinieerd als een reeks van elementen in de gegeven `waardetype`. ASF maakt gebruik van `HashSet` om aan te geven dat bepaalde eigenschap alleen zin heeft voor unieke waarden en dat de volgorde er niet toe doet Daarom zal het opzettelijk alle mogelijke duplicaten negeren tijdens het parsen (als je ze toch hebt opgegeven).

Voorbeeld voor `ImmutableHashSet<uint>`: `"Blacklist": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>` - Onveranderbaar woordenboek (kaart) dat een unieke sleutel in zijn `keyType`, voor de waarde opgegeven in `waardetype`. In JSON, wordt het gedefinieerd als een object met sleutelwaarde paren. Houd er rekening mee dat `keyType` in dit geval altijd wordt geciteerd, zelfs als het type waarde is zoals `ulong`. Er is ook een strikte eis dat de sleutel uniek is voor de kaart, ditmaal ook door JSON afgedwongen.

Voorbeeld voor `ImmutableDictionary<ulong, byte>`: `"SteamUserPermissions": { "76561198174813138": 3, "765611981748137": 1 }`

---

`vlaggen` - Markeringen attribuut combineert verschillende eigenschappen tot één eindwaarde door het toepassen van bitwise operaties. Dit stelt u in staat om elke mogelijke combinatie van verschillende toegestane waarden op hetzelfde moment te kiezen. De uiteindelijke waarde wordt opgebouwd als een optelsom van waarden van alle mogelijke opties.

Bijvoorbeeld, de volgende definitie:

| Waarde | Naam |
| ------ | ---- |
| 0      | Geen |
| 1      | A    |
| 2      | B    |
| 4      | C    |

Er zijn precies 3 zinvolle, beschikbare vlaggen om aan te zetten/uit (`A`, `B`, `C`), en daarom `8` mogelijke in totaal geldige combinaties:

| Definitieve waarde | Vlaggen ingeschakeld |
| ------------------ | -------------------- |
| 0                  | `Geen`               |
| 1                  | `A`                  |
| 2                  | `B`                  |
| 3                  | `A` + `B`            |
| 4                  | `C`                  |
| 5                  | `A` + `C`            |
| 6                  | `B` + `C`            |
| 7                  | `A` + `B` + `C`      |

Om het bovenstaande mogelijk te maken moet per definitie elke zelfstandige vlag dus de macht van twee zijn. Dit is waarom extra vlag in bovenstaande voorbeeld, `D`, zou moeten dragen waarde van `8` of hoger.

Normaal gesproken zullen grafische tools de berekening voor je maken. Als je de configuratie handmatig bewerkt, je kunt altijd de rekenmachine gebruiken en de onderliggende waarden van alle vlaggen die je wilt inschakelen samenvoegen - zoals in het voorbeeld hierboven.

Voorbeeld: `"SteamProtocols": 7` (welke vlaggen met waarde van `1`toestaat, `2` en `4`, zoals hierboven uitgelegd)

---

## Compatibiliteitstoewijzing

Als gevolg van JavaScript-beperkingen van het niet in staat zijn om de eenvoudige `ulong` velden goed te serialiseren in JSON wanneer je de web-based ConfigGenerator gebruikt, `ulong` velden worden weergegeven als tekenreeksen met `s_` prefix in de resulterende configuratie. Dit geldt bijvoorbeeld voor `"SteamOwnerID": 76561198006963719` dat door onze ConfigGenerator als `"s_SteamOwnerID": "76561198006963719"`. ASF heeft de juiste logica voor het automatisch afhandelen van deze tekenreeks, dus `s_` invoergegevens in de configuraties zijn geldig en correct gegenereerd. Als u zelf configuraties genereert, raden we u aan om indien mogelijk met de originele `ulong` velden vast te houden. maar als je dit niet kunt doen, u kunt dit schema ook volgen en ze als tekenreeksen coderen met `s_` prefix die aan hun namen is toegevoegd. We hopen deze JavaScript-beperking uiteindelijk op te lossen.

---

## Configureer compatibiliteit

ASF heeft de hoogste prioriteit om compatibel te blijven met oudere configuraties. Zoals u al zou moeten weten, worden ontbrekende configuratie-eigenschappen behandeld op dezelfde manier als ze zouden worden gedefinieerd met hun **standaard waarden**. Daarom, als nieuwe configuratie-eigenschap wordt ingevoerd in een nieuwe versie van ASF, zullen alle configuraties **compatibel blijven met nieuwe versie** en ASF zal de nieuwe configuratie-eigenschap behandelen zoals het zal worden gedefinieerd met de **standaardwaarde**. U kunt configuratie-eigenschappen altijd toevoegen, verwijderen of bewerken op basis van uw behoeften.

We raden aan om de gedefinieerde configuratie-eigenschappen alleen te beperken voor degene die je wilt wijzigen omdat u op deze manier automatisch standaardwaarden overneemt voor alle andere waarden, Niet alleen uw configuratie schoon houden, maar ook de compatibiliteit verbeteren in het geval we besluiten om een standaardwaarde te wijzigen voor eigenschap die u niet expliciet wilt instellen (e.a. . `WebLimiterVertraging`).

Als gevolg van bovenstaande zal ASF uw configuraties automatisch migreren/optimaliseren door ze opnieuw te formatteren en velden die de standaardwaarde vasthouden te verwijderen. Je kunt dit gedrag uitschakelen met `--no-config-migrate` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** als je een specifieke reden hebt. bijvoorbeeld je gebruikt alleen-lezen configuratiebestanden en je wilt niet dat ASF deze wijzigt.

---

## Automatisch herladen

ASF is zich bewust van het feit dat configuraties "on-the-fly" worden gewijzigd - dankzij dat, ASF automatisch:
- Maak (en begin) nieuwe bot instantie, wanneer je de configuratie aanmaakt
- Stop (indien nodig) en verwijder oude bot bijstand, wanneer je de configuratie verwijdert
- Stop (en start, indien nodig) elke bot bijstand, wanneer je de configuratie bewerkt
- Herstart (indien nodig) de bot onder nieuwe naam, wanneer je de configuratie hernoem

Al het bovenstaande is transparant en zal automatisch worden uitgevoerd zonder dat het programma opnieuw moet worden opgestart of andere (niet) bot-instanties te doden.

Naast dit zal ASF ook zichzelf herstarten (als `AutoRestart` toestaat) als je de core-ASF `ASF.json` configuratie wijzigt. Evenzo zal het programma stoppen als je het verwijdert of hernoemt.

Je kunt dit gedrag uitschakelen met `--no-config-watch` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** als je een specifieke reden hebt. bijvoorbeeld niet van ASF willen reageren op bestandswijzigingen in `config` map.