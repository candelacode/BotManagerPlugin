# MatcherPlugin

`ItemsMatcherPlugin` is officieel ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** dat ASF uitbreidt met ASF STM listing functies. Met name dit omvat `Publicatie` in **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** en `MatchActively` in **[`Tradingvoorkeuren`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. ASF komt met `ItemsMatcherPlugin` gebundeld met de release, daarom is het meteen klaar voor gebruik.

---

## `Publicatie`

Een openbare lijst, zoals de naam impliceert, is een overzicht van de momenteel beschikbare ASF STM bots. Het bevindt zich op **[onze website](https://asf.justarchi.net/STM)**, automatisch beheerd en gebruikt als een openbare dienst voor beide ASF-gebruikers die gebruik maken van `MatchActively`, evenals ASF en niet-ASF-gebruikers voor handmatige matching.

Om vermeld te worden moet u aan een reeks vereisten voldoen. At the minimum, you must have allowed `PublicListing` in `RemoteCommunication` (default setting), `SteamTradeMatcher` enabled in `TradingPreferences`, **[public inventory](https://steamcommunity.com/my/edit/settings)** privacy settings, an **[unrestricted](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** account and **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** active. Extra vereisten omvatten 2FA actief sinds ten minste 15 dagen, laatste wachtwoordwijziging meer dan 5 dagen geleden ontbreken van enige rekeningbeperkingen zoals vergrendelingen, economische verboden en handelsverboden. Naturally, you must also have at least one (tradable) item in your inventory from specified `MatchableTypes`, such as trading cards. Daarnaast worden bots met meer dan `500000` items niet geaccepteerd vanwege overhead We raden u aan om in dit geval uw inventaris te splitsen over meerdere accounts.

Terwijl `Publicatie` standaard is ingeschakeld Houd er rekening mee dat u **niet** zal tonen op de website als u niet aan alle vereisten voldoet. vooral `SteamTradeMatcher`, die standaard niet is ingeschakeld. Voor mensen die niet aan de criteria voldoen, zelfs als ze `PublicListing` ingeschakeld hebben gehouden, communiceert ASF op geen enkele manier met de server. De openbare lijst is ook alleen compatibel met de laatste stabiele versie van ASF en kan achterhaalde bots niet weergeven, vooral als ze kern missen, die alleen in nieuwere versies te vinden is.

### Hoe het precies werkt

ASF verzendt na het inloggen eerste data waarvan alle eigenschappen die openbaar staan gebruikt worden. Vervolgens verstuurt ASF elke 10 minuten een zeer kleine "heartbeat" aanvraag die onze server waarschuwt dat de bot nog steeds actief is. Als om een of andere reden de hartslag niet arriveerde, bijvoorbeeld door netwerkproblemen, dan zal ASF elke minuut opnieuw proberen, totdat de server het registreert. Op deze manier weet onze server precies welke bots nog steeds lopen en bereid zijn om handelsaanbiedingen te accepteren. ASF zal ook een eerste aankondiging sturen op basis die nodig is, bijvoorbeeld als deze detecteert dat onze inventaris is veranderd sinds de vorige.

We tonen alle geschikte ASF-accounts die actief waren in de **de laatste 15 minuten**. Gebruikers worden gesorteerd volgens hun relatieve nut - `MatchEverything` bots die worden getoond met `Elke` banner die alle 1:1 trades accepteert, dan unieke spellen tellen, en ten slotte items tellen.

### API

ASF STM toont alleen ASF bots op tijd. Er is geen manier om nu derden bots op onze lijst te zetten, omdat we hun code niet eenvoudig kunnen bekijken en ervoor kunnen zorgen dat ze voldoen aan onze volledige handelslogica. Deelname aan de lijst vereist daarom de laatste stabiele ASF-versie, hoewel deze uitgevoerd kan worden met aangepaste **[plugins](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

Voor consumenten op de beurs hebben we een heel eenvoudig **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** eindpunt dat je kunt gebruiken. Het bevat alle gegevens die we hebben, behalve inventarisaties van gebruikers die alleen deel uitmaken van `MatchActively` functie.

### Privacy Beleid

Als u ermee akkoord gaat om in onze lijst op te nemen, door `SteamTradeMatcher` in te schakelen en niet te weigeren `PublicListing`, zoals hierboven aangegeven, zullen we tijdelijk enkele details van je Steam account opslaan op onze server om de verwachte functionaliteit te bieden.

Openbare informatie (blootgelegd door Steam aan alle geïnteresseerde partij) omvatten:
- Je Steam identificator (in 64-bit formulier, voor het genereren van links)
- Uw bijnaam (voor weergave)
- Je avatar (hash, voor weergave)

Voorwaardelijk publieke informatie (blootgelegd door Steam aan elke belanghebbende partij als je voldoet aan de vereisten voor het lijst) omvatten:
- Je **[inventaris](https://steamcommunity.com/my/inventory/#753_6)** (zodat mensen `MatchActively` tegen je voorwerpen kunnen gebruiken).

Privéinformatie (geselecteerde gegevens benodigd voor het verstrekken van de functionaliteit) omvatten:
- Je **[handelstoken](https://steamcommunity.com/my/tradeoffers/privacy)** (zodat mensen buiten je vriendenlijst je transacties kunnen sturen)
- Uw `MatchableTypes` instelling (voor weergave doeleinden en matching)
- Uw `MatchEverything` instelling (voor weergavedoeleinden en matching)
- Uw `MaxTradeHoldDuration` instelling (zodat anderen weten of u bereid bent hun transacties te accepteren)

Sinds het moment dat je geen gebruik meer maakt (aankondiging) van onze lijst, worden jouw gegevens binnen maximaal 15 minuten niet meer beschikbaar voor algemeen publiek. en wordt anders maximaal twee weken op onze server gehouden - na die periode wordt alles automatisch verwijderd. Om dat te laten gebeuren is van u geen actie nodig.

---

## `Wedstrijd actief`

`MatchActively` de instelling is actieve versie van **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** inclusief interactief bijhouden waarin de bot transacties naar andere mensen zal sturen. Het kan staande werken of samenwerken met `SteamTradeMatcher` instelling. Deze functie vereist dat `LicenseID` wordt ingesteld, omdat het gebruik maakt van externe server en betaalde middelen om te werken.

Om van die optie gebruik te maken, moet u aan een aantal vereisten voldoen. Minimaal moet je een **[Onbeperkt](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** account hebben. **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** actief en ten minste één geldig type in `MatchableTypes`zoals handelskaarten. Extra vereisten omvatten 2FA actief sinds ten minste 15 dagen, laatste wachtwoordwijziging meer dan 5 dagen geleden ontbreken van enige rekeningbeperkingen zoals vergrendelingen, economische verboden en handelsverboden.

Als je aan alle bovenstaande vereisten voldoet, ASF zal periodiek communiceren met onze **[openbare ASF STM listing](#publiclisting)** om bots actief te vergelijken die momenteel beschikbaar zijn.

Tijdens het matchen, zal de ASF bot zijn eigen inventaris ophalen, dan communiceren met onze server om alle mogelijke `MatchableTypes` te vinden die overeenkomen met andere, momenteel beschikbare bots. Dankzij het direct communiceren met onze server Dit proces vereist één verzoek en we hebben onmiddellijke informatie of een beschikbare bot iets interessants voor ons biedt - als een match wordt gevonden, ASF zal de transactie automatisch verzenden en bevestigen

Deze module moet transparant zijn. Het koppelen start in ongeveer `1` uur sinds ASF start, en zal zichzelf elke `6` uur herhalen (indien nodig). `MatchActief` functie is bedoeld om te worden gebruikt als lange termijn, periodieke maatregel om ervoor te zorgen dat we actief op weg zijn naar sets voltooid, Maar mensen die geen ASF 24/7 gebruiken kunnen ook overwegen een `match` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** te gebruiken. De doelgebruikers van deze module zijn primaire accounts en "stash" alt-accounts, hoewel het kan worden gebruikt door een bot die niet is ingesteld op `MatchEverything`. Daarnaast worden bots met meer dan `500000` items niet geaccepteerd voor bijstemming vanwege overhead We raden u aan om in dit geval uw inventaris te splitsen over meerdere accounts.

ASF doet zijn best om het aantal verzoeken en druk dat wordt gegenereerd door deze optie te minimaliseren, terwijl tegelijkertijd de efficiëntie van de bijpassende bovengrens wordt geoptimaliseerd. Het exacte algoritme van het kiezen van bots om te matchen en anders het hele proces te organiseren is ASF implementatie gedetailleerd en kan veranderen met betrekking tot terugkoppeling, situatie en mogelijke toekomstige ideeën.

The current version of the algorithm makes ASF prioritize `Any` bots first, especially those with better diversity of games that their items are from. When running out of `Any` bots, ASF will move on to the `Fair` ones upon same diversity rule. ASF zal proberen om ten minste eenmaal samen te werken met elke beschikbare bot om ervoor te zorgen dat we niet ontbreken aan een mogelijke set vooruitgang.

`MatchActively` houdt rekening met bots die u hebt geblokkeerd van handelen via `tbadd` **[commando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** en probeert ze niet actief te verwerken. Dit kan worden gebruikt om ASF te vertellen welke bots het nooit zou moeten overeenkomen, zelfs als ze mogelijk dupes voor ons zouden hebben.

ASF zal ook zijn best doen om ervoor te zorgen dat de handelsaanbiedingen worden uitgevoerd. Bij de volgende uitvoering, wat normaal gesproken over 6 uur gebeurt, zal ASF alle lopende handelsaanbiedingen annuleren die nog steeds niet zijn geaccepteerd. en laat stoomID's die eraan deelnemen prioriteren om hopelijk eerst meer actieve bots te verkiezen. Als de afgehakte bots nog steeds de laatste zijn die de wedstrijd hebben die we nodig hebben, zullen we nog steeds proberen deze te evenaren (opnieuw).

---

### Waarom heb ik een `LicenseID` nodig om `MatchActively` te gebruiken? Was het niet eerder vrij?

ASF is en blijft gratis en open source, zoals het al bij de start van het project in oktober 2015 werd vastgesteld. Broncode van `ItemsMatcher` plugin en daarom `MatchActively` functie is beschikbaar in onze repository, terwijl ASF-programma volledig niet-commercieel is, verdienen we niets door bijdragen eraan te leveren, te bouwen of te publiceren. In de afgelopen 7+ jaren heeft ASF een enorme hoeveelheid ontwikkeling ontvangen. en het wordt nog steeds verbeterd en verrijkt met elke maandelijkse stabiele release, meestal door één persoon, **[JustArchi](https://github.com/JustArchi)** - zonder strings bijgevoegd. De enige financiering die we krijgen is die van niet-verplichte donaties van onze gebruikers.

Lange tijd, tot oktober 2022, `MatchActively` functie was onderdeel van de ASF kern en beschikbaar voor iedereen om te gebruiken. In oktober 2022, Radiatorkraan, het bedrijf achter Steam, heeft zeer strenge snelheden ingesteld bij het ophalen van inventarisaties van andere bots - die de vorige functie volledig kapot hebben gemaakt zonder de mogelijkheid om dit probleem op te lossen. Als gevolg van het feit dat deze functie volledig is verdwenen zonder enige kans op refixatie. het moest worden verwijderd uit de ASF-kern als verouderd.

`MatchActively` werd heropend als onderdeel van de officiële `ItemsMatcher` plugin die ASF verder verbetert met actieve kaarten die overeenkomende functionaliteit gebaseerd op een volledig geherformuleerd concept. Herstellen `MatchActively` functie vereist van ons **buitengewone hoeveelheid werk** om ASF te maken volledig nieuwe service gehost op een server met meer dan honderd betaalde proxies verbonden voor het oplossen van inventarissen, alles om ASF-klanten toe te staan gebruik te maken van `MatchActively` zoals voorheen. Vanwege de hoeveelheid werk die ermee gemoeid is, evenals bronnen die niet gratis zijn en op maandelijkse basis door ons betaald moeten worden (domein, server, proxies), we hebben besloten deze functionaliteit aan onze sponsors aan te bieden, dat wil zeggen mensen die het ASF-project al maandelijks ondersteunen, dankzij wie we de betaalde middelen beschikbaar kunnen stellen.

Ons doel is niet om hiervan te profiteren, maar eerder dek de **maandelijkse kosten** die exclusief gekoppeld zijn aan het aanbieden van deze optie - daarom bieden we deze in principe voor niets aan. maar we moeten er een beetje voor betalen, omdat we niet elke maand honderden dollars uit onze eigen zakken kunnen betalen gewoon om het voor jou beschikbaar te maken. We zijn echt niet in staat om over de prijs te discussiëren, de Radiatorkraan heeft ons deze kosten opgedrongen. en het alternatief is om dergelijke functies helemaal niet beschikbaar te hebben welke natuurlijk van toepassing is als je besluit, om welke reden dan ook, dat je onze plugin niet kunt rechtvaardigen op die voorwaarden.

In elk geval begrijpen we dat `MatchActively` niet voor iedereen is. en we hopen dat je ook begrijpt waarom we het niet gratis kunnen aanbieden. Als niemand wilde helpen om de kosten van deze functie te dekken, zou het gewoon niet bestaan om te beginnen. zoals we gedwongen zouden zijn om te bezuinigen op maandelijkse uitgaven die niemand wil dragen. Gelukkig bevinden we ons in een betere positie dan dat, en je kunt zelf beslissen of je bereid bent om `MatchActively` op die voorwaarden te gebruiken of niet.

---

### Hoe krijg ik toegang?

`ItemsMatcher` wordt aangeboden als deel van maandelijkse $5 + sponsor tier op **[JustArchi's GitHub](https://github.com/sponsors/JustArchi)**. Het is ook mogelijk om eenmalige sponsoren te worden, hoewel in dit geval de licentie slechts een maand geldig is (met de mogelijkheid tot verlenging op dezelfde manier). Zodra je een sponsor van $5 tier (of hoger) bent geworden, lees dan **[configuratie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** om `LicenseID` te verkrijgen en in te vullen. Daarna hoeft u alleen `MatchActively` in `TradingPreferences` van uw gekozen bot in te schakelen.

De licentie staat u toe om een beperkt aantal aanvragen naar de server te sturen. $5 staat je toe om `MatchActively` te gebruiken voor één bot-account (4 aanvragen per dag), en elke extra $5 voegt twee bot-accounts toe (8 aanvragen per dag). Als u bijvoorbeeld op drie rekeningen wilt draaien, wordt dat gedekt door $10 en hoger.