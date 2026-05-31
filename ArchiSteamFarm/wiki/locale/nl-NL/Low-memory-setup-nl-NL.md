# Configuratie met laag geheugenverbruik

Dit is precies het tegenovergestelde van **[hoogwaardige setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup)** en u wilt deze tips volgen als u het geheugengebruik van ASF wilt verminderen, voor de kosten van het verlagen van de totale prestaties.

---

ASF is extreem licht op bronnen per definitie, afhankelijk van uw gebruik zelfs 128 MB VPS met Linux is in staat om het uit te voeren, Dat lage niveau wordt echter niet aanbevolen en kan tot verschillende kwesties leiden. Als het licht is, is ASF niet bang om OS te vragen om meer geheugen, als ASF dit geheugen nodig heeft om met optimale snelheid te werken.

ASF als een applicatie probeert zo veel mogelijk geoptimaliseerd en efficiënt mogelijk te zijn, wat ook rekening houdt met het gebruik tijdens de uitvoering. Als het om geheugen gaat, geeft ASF de voorkeur aan prestaties boven geheugengebruik, wat kan resulteren in tijdelijk geheugen "pieken", dat kan worden opgemerkt bvb. met accounts met 3 + badge pagina's, omdat ASF de eerste pagina ophaalt en verwerkt zal worden, lees het totaal aantal pagina's, vervolgens het ophalen van taken voor elke extra pagina, wat resulteert in het tegelijk ophalen en parsen van resterende pagina's. Dat "extra" geheugengebruik (vergeleken met minimum voor operatie) de uitvoering en algehele prestaties drastisch kan versnellen voor de kosten van meer geheugengebruik die nodig zijn om al deze dingen tegelijkertijd te doen. Vergelijkbare dingen gebeuren met alle andere algemene ASF-taken die parallel kunnen worden uitgevoerd, b.v. Met het verwerken van actieve handelsaanbiedingen kan ASF ze allemaal tegelijk parsen, omdat ze allemaal onafhankelijk van elkaar zijn. Bovendien, zal ASF (C# runtime) niet ongebruikt geheugen teruggeven **niet** direct daarna terug naar OS wat je snel kan zien in de vorm van ASF-proces neemt alleen maar meer en meer geheugen, maar (bijna) geeft dat geheugen nooit terug aan het besturingssysteem. Sommige mensen vinden het misschien al twijfelachtig. Misschien vermoedt een geheugenlek, maar maak je geen zorgen, dit is allemaal te verwachten.

ASF is zeer goed geoptimaliseerd en maakt zo veel mogelijk gebruik van de beschikbare middelen. High memory usage of ASF doesn't mean that ASF actively **uses** that memory and **needs it**. Heel vaak zal ASF geheugen toewijzen als "kamer" voor toekomstige acties omdat we prestaties drastisch kunnen verbeteren als we niet elk geheugenchunk dat we gaan gebruiken om OS te vragen. De runtime zal ongebruikt ASF-geheugen automatisch weer vrijgeven aan de OS, wanneer het besturingssysteem **echt** nodig heeft. **[Ongebruikt geheugen is verspild geheugen](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. U wordt geconfronteerd met problemen wanneer het geheugen dat u **nodig heeft** hoger is dan het geheugen dat beschikbaar is voor u, niet als ASF wat extra wordt toegewezen met als doel functies te versnellen die binnen een moment worden uitgevoerd. Je wordt geconfronteerd met problemen wanneer de Linux kernel een einde maakt aan ASF proces door OOM (zonder geheugen), niet wanneer je ASF-proces ziet als best geheugengebruik in `htop`.

**[Garbage collection](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** proces dat wordt gebruikt in ASF is een zeer complex mechanisme. slim genoeg om niet alleen rekening te houden met ASF zelf, maar ook met je OS en andere processen. Zodra u veel gratis geheugen heeft, zal ASF vragen wat nodig is om de prestaties te verbeteren. Dit kan zelfs maar 1 GB zijn (met server GC). Wanneer uw OS geheugen dicht bij vol is, zal ASF een deel ervan automatisch terugsturen naar de OS om te helpen dit te verhelpen. dit kan resulteren in een globaal geheugengebruik van 50 MB. Het verschil tussen 50 MB en 1 GB is enorm, maar dat geldt ook voor het verschil tussen kleine 512 MB VPS en een enorme toegewijde server met 32 GB. Als ASF kan garanderen dat dit geheugen nuttig is, en niets anders vereist het op dit moment het zal het verkiezen om het te behouden en zichzelf automatisch te optimaliseren op basis van routines die in het verleden zijn uitgevoerd. De GC gebruikt in ASF past zichzelf aan en zal betere resultaten bereiken als het proces langer draait.

Dit is ook de reden waarom het geheugen van ASF varieert van de setup tot de installatie, omdat ASF zijn best zal doen om de beschikbare middelen in **zo efficiënt mogelijk**te gebruiken, en niet op een vaste manier zoals het is gedaan tijdens Windows XP tijden. Het werkelijke (echte) geheugengebruik dat ASF gebruikt kan worden geverifieerd met `statistieken` **[opdracht](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, en is meestal ongeveer 4 MB voor slechts een paar bots, tot 30 MB als je spullen zoals **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** en andere geavanceerde functies gebruikt. Houd er rekening mee dat het geheugen van `stats` commando ook vrij geheugen bevat dat nog niet is teruggevorderd door garbage collector. Al het andere is gedeeld runtime geheugen (ongeveer 40-50 MB) en ruimte voor uitvoering (vary). Dit is ook de reden waarom hetzelfde ASF maar liefst 50 MB kan gebruiken in de VPS-omgeving met weinig geheugen wanneer je zelfs tot 1 GB op je bureaublad gebruikt. ASF past zich actief aan aan je omgeving aan en zal proberen een optimale balans te vinden om je OS niet onder druk te zetten zijn eigen prestaties beperken ook niet wanneer u veel ongebruikt geheugen heeft dat in gebruik kan worden genomen.

---

Natuurlijk, er zijn veel manieren waarop u ASF kunt helpen in de juiste richting te wijzen als het gaat om het geheugen dat u verwacht. In het algemeen als je het niet hoeft te doen, is het het beste om garbagecollector in vrede te laten werken en te doen wat zij het beste acht. Maar dit is niet altijd mogelijk, bijvoorbeeld als uw Linux server ook meerdere websites, MySQL database en PHP werknemers hosting Dan kan je het je niet veroorloven om ASF zichzelf te krimpen als je dichtbij OM loopt, omdat het meestal te laat is en prestatiedegradatie eerder komt. Dit is meestal wanneer je geïnteresseerd zou kunnen zijn in verdere tuning, en daarom deze pagina kunt lezen.

Onderstaande suggesties worden met verschillende problemen onderverdeeld in een paar categorieën.

---

## ASF setup (eenvoudig)

Onder trucs **heeft geen negatieve invloed op de prestaties** en kan veilig worden toegepast op alle opties.

- Voer **[algemene versie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** uit, indien mogelijk. Generieke versie van ASF gebruikt minder geheugen omdat er geen runtime in zit, komt niet als een enkel bestand, niet nodig om zichzelf uit te pakken tijdens uitvoeren, en is daarom kleiner en heeft minder geheugen voetafdruk. OS-specifieke pakketten zijn handig en handig, maar ze zijn ook gebundeld met alles wat nodig is om ASF te starten Hier kan je zelf voor zorgen en in plaats daarvan generieke ASF-variant gebruiken.
- Werkt nooit meer dan één ASF-instantie. ASF is bedoeld om in één keer onbeperkt aantal bots te verwerken, en tenzij je elke ASF-instantie koppelt aan een ander interface/IP-adres, je zou exact **één** ASF-proces moeten hebben, met meerdere bots (indien nodig).
- Maak gebruik van `ShutdownOnFarmingFinished` in bot's `BoetederingsVoorkeuren`. Actieve bot neemt meer bronnen in beslag dan gedeactiveerd. Het is geen significante besparing, omdat de toestand van bot nog steeds moet worden bewaard, maar je bespaart een aantal bronnen, vooral alle bronnen met betrekking tot netwerken, zoals TCP-sockets. Je kunt altijd andere bots opvoeden als dat nodig is.
- Houd uw bots nummer laag. Niet `Ingeschakeld` bot instantie gebruikt minder middelen, omdat ASF niet de moeite heeft om het te starten. Also keep in mind that ASF has to create a bot for each of your configs, therefore if you don't need to `start` given bot and you want to save some extra memory, you can temporarily rename `Bot.json` to e.g. `Bot.json.bak` in order to avoid creating state for your disabled bot instance in ASF. Op deze manier kan je `starten` zonder het terug te noemen. maar ASF zal ook de status van deze bot niet in het geheugen houden, waardoor er ruimte blijft voor andere dingen (heel kleine besparing, in 99. % gevallen die je niet zou moeten aandoen, houd gewoon je bots met `ingeschakeld` van `false`).
- Uw configuraties finalizeren. Vooral de globale ASF configuratie heeft vele variabelen om aan te passen, bijvoorbeeld door het verhogen van `LoginLimiterDelay` zal je de bots langzamer brengen, die in de tussentijd al begonnen is om badges op te halen in plaats van je bots sneller te brengen, die meer middelen zullen gebruiken, omdat meer bots tegelijkertijd belangrijk werk zullen doen (zoals medailles) Hoe minder werk er tegelijkertijd moet worden verricht - hoe minder geheugengebruik.

Dat zijn een paar dingen die u in gedachten kunt houden als het gaat om geheugengebruik. Deze dingen hebben echter geen "cruciaal" rol in het geheugengebruik, Omdat geheugengebruik voornamelijk afkomstig is van dingen die ASF moet aanpakken, en niet van interne structuren die worden gebruikt voor kaartenkwekerij.

De meeste zware functies zijn:
- Badge pagina verwerken
- Inventaris verwerken

Dit betekent dat het geheugen het meeste zal pieken wanneer ASF te maken heeft met het lezen van badges, en wanneer het te maken heeft met zijn inventaris (bv. . het verzenden van handel of het werken met STM). Dit komt omdat ASF te maken heeft met een enorme hoeveelheid gegevens - het geheugengebruik van je favoriete browser die twee pagina's zal niet lager zijn dan dat. Sorry, dat is hoe het werkt - verminder het aantal van je badge pagina's, en houd het aantal voorraaditems laag, dat kan zeker helpen.

---

## Runtime tuning (geavanceerd)

Onder trucs **omvat prestatiedegradatie** en moet voorzichtig worden gebruikt.

De aanbevolen manier om deze instellingen toe te passen is door `DOTNET_` omgevingseigenschappen. Natuurlijk kunt u ook andere methoden gebruiken, bijvoorbeeld `runtimeconfig. zoon`, maar sommige instellingen zijn niet mogelijk om deze weg in te stellen en daarnaast zal ASF je aangepaste `runtimeconfig. zoon` met zijn eigen, bij de volgende update, raden we daarom milieueigenschappen aan die u eenvoudig kunt instellen voordat het proces wordt gestart.

.NET runtime staat je toe **[tweak garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** op veel manieren effectief het GC proces aan uw wensen bijstellen. We hebben hieronder gedocumenteerd welke bijzonder belangrijk voor ons zijn.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Specificeert het toegestane GC heap gebruik als een percentage van het totale fysieke geheugen.

De "hard" geheugenlimiet voor ASF-proces, deze instelling neemt GC in om alleen een totale geheugenset te gebruiken en niet allemaal. Het kan bijzonder nuttig worden in verschillende server-achtige situaties waar je een vast percentage van het servergeheugen aan ASF kunt toewijzen maar nooit meer dan dat. Houd er rekening mee dat het beperken van het geheugen voor ASF niet al die benodigde geheugentoewijzingen op magische wijze zal doen verdwijnen, Een te lage waarde zou er dus toe kunnen leiden dat er geen geheugen meer is, waarbij ASF-proces gedwongen zal worden te beëindigen.

Anderzijds het instellen van deze hoge waarde is een perfecte manier om ervoor te zorgen dat ASF nooit meer geheugen zal gebruiken dan je je realistisch kan veroorloven. geeft je machine een ademkamer die zelfs onder zware druk staat, terwijl het programma zijn werk nog steeds zo efficiënt mogelijk kan doen.

### [`GCConserveGeheugen`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Configureert de garbagecollector om het geheugen te conserveren ten koste van frequentere garbagecollecties en mogelijk langere perioden.

Een waarde tussen 0-9 kan gebruikt worden. Hoe groter de waarde, hoe meer GC het geheugen zal optimaliseren ten opzichte van de prestaties.

### [`GCHighMemPercentage`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Specificeert de hoeveelheid geheugen die wordt gebruikt hierna welke GC agressiever wordt.

Deze instelling configureert de geheugendrempel van uw hele OS, welke eenmaal is verstreken, zorgt ervoor dat GC agressiever wordt en probeert het OS te helpen de geheugenbelasting te verlagen door het intensievere GC proces uit te voeren en resulteert daardoor meer vrije geheugen terug naar het besturingssysteem. Het is een goed idee om deze eigenschap in te stellen op maximale hoeveelheid geheugen (als percentage) die u als "kritisch" voor uw gehele OS prestaties beschouwt. Standaard is 90%, en meestal wil je het binnen 80-97% bereik houden, omdat een te lage waarde onnodige agressie van de GC en prestatiedegradatie zal veroorzaken zonder reden terwijl een te hoge waarde onnodige belasting op je OS plaatst, overwegende dat ASF je geheugen zou kunnen vrijgeven om je te helpen.

### **[`GCLatencyNiveau`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Specificeert het GC latency niveau waar u voor wilt optimaliseren.

Dit is een ongedocumenteerde eigenschap die uitzonderlijk goed werkte voor ASF, door de grootte van de GC generaties te beperken en deze hierdoor vaker en agressiever te laten verwijderen. Standaard (evenwicht) latency level is `1`, maar je kunt `0`gebruiken voor geheugengebruik.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> Wanneer we dit instellen snijden we de geëngageerde ruimte agressiever voor de ephemerale taferelen. Dit wordt gebruikt voor het uitvoeren van veel serverprocessen waar ze zo weinig mogelijk geheugen gecommitteerd willen houden.

Dit biedt weinig verbetering, maar kan GC nog agressiever maken wanneer het systeem laag in het geheugen zal zijn, speciaal voor ASF dat veel gebruik maakt van threadpool taken.

---

U kunt de geselecteerde eigenschappen inschakelen door de juiste omgevingsvariabelen in te stellen. Bijvoorbeeld, op Linux (shell):

```shell
# Don't forget to tune those if you're planning to make use of them
export DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
export DOTNET_GCHighMemPercent=0x50 # 80% as hex

export DOTNET_GCConserveMemory=9
export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

Of op Windows (powershell):

```powershell
# Don't forget to tune those if you're planning to make use of them
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80% as hex

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

Vooral `GCLatencyLevel` zal zeer nuttig zijn omdat we hebben geverifieerd dat de runtime code inderdaad voor geheugen optimaliseert en daarom het gemiddelde geheugengebruik aanzienlijk verlaagt zelfs met server GC. Het is een van de beste trucs die je kunt toepassen als je het ASF-geheugengebruik aanzienlijk wilt verlagen terwijl je de prestaties niet te veel degradeert met `OptimizationModus`.

---

## ASF afstemmen (tussen)

Onder trucs **gaat het om een ernstige prestatiedegradatie** en moet voorzichtig worden gebruikt.

- Als laatste redmiddel, kunt u ASF instellen voor `MinMemoryUsage` via `OptimizationModus` **[globale configuratie-eigenschap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**. Lees zorgvuldig het doel ervan, omdat dit een ernstige prestatiedegradatie is voor bijna geen geheugenvoordelen. Dit is meestal **het laatste ding dat je wilt doen**, lang nadat je door **[runtime tuning](#runtime-tuning-advanced)** bent gegaan om ervoor te zorgen dat je dit gedwongen bent. Tenzij absoluut cruciaal zijn voor je installatie, ontmoedigen we het gebruik van `MinMemoryUsage`, zelfs in gedenkgebonden omgevingen.

---

## Aanbevolen optimalisatie

- Start bij eenvoudige ASF setup trucs gebruik **[algemene ASF variant](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** en controleer of je misschien de ASF op een verkeerde manier gebruikt, zoals het meerdere keren starten van het proces voor al je bots, of ze allemaal actief houden als je maar een of twee nodig hebt om automatisch te starten.
- Als het nog niet genoeg is, schakel dan alle bovenstaande configuratie-eigenschappen in door de juiste `DOTNET_` omgevingsvariabelen in te stellen. Vooral `GCLatencyLevel` biedt aanzienlijke runtime verbeteringen voor weinig kosten op prestaties.
- Als zelfs dat niet helpt, als laatste redmiddel `MinMemoryUsage` `OptimizationModus` inschakelen. Deze forceert ASF om bijna alles in synchroon te zetten, ervoor zorgen dat het veel langzamer werkt, maar ook dat het niet op draadpool vertrouwt om een evenwicht te vinden in de parallelle uitvoering.

Het is fysiek onmogelijk om het geheugen nog verder te verlagen uw ASF is al zwaar gedegradeerd in termen van prestaties en u heeft al uw mogelijkheden uitgeput, zowel code-wijze als runtime-wijs. Overweeg om wat extra geheugen toe te voegen voor ASF om te gebruiken, zelfs 128 MB zou een groot verschil maken.