# Configuratie met hoge prestaties

Dit is precies het tegenovergestelde van **[low-memory setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** en meestal wil je deze tips volgen als je de ASF prestaties wilt verhogen (in termen van CPU-snelheid), voor potentiële kosten van een verhoogd geheugengebruik.

---

ASF heeft al de voorkeur gegeven aan prestaties als het gaat om algemene gebalanceerde aanpassing, Daarom kunt u niet veel doen om de prestaties verder te verhogen, hoewel u ook niet volledig buiten de mogelijkheden valt. Houd er echter rekening mee dat deze opties standaard niet zijn ingeschakeld, dat betekent dat ze niet goed genoeg zijn om ze in evenwicht te houden voor het merendeel van de toepassingen, Daarom moet u zelf beslissen of de geheugenverhoging die door hen wordt teweeggebracht, voor u aanvaardbaar is.

---

## Runtime tuning (geavanceerd)

Onder trucs **betekent een ernstige geheugenstijging** en moet daarom voorzichtig worden gebruikt.

De aanbevolen manier om deze instellingen toe te passen is door `DOTNET_` omgevingseigenschappen. Natuurlijk kunt u ook andere methoden gebruiken, bijvoorbeeld `runtimeconfig. zoon`, maar sommige instellingen zijn niet mogelijk om deze weg in te stellen en daarnaast zal ASF je aangepaste `runtimeconfig. zoon` met zijn eigen, bij de volgende update, raden we daarom milieueigenschappen aan die u eenvoudig kunt instellen voordat het proces wordt gestart.

.NET runtime staat je toe **[tweak garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** op veel manieren effectief het GC proces aan uw wensen bijstellen. We hebben hieronder gedocumenteerd welke bijzonder belangrijk voor ons zijn.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Configureert of de applicatie gebruikmaakt van garbage collection of garbage collectie.

Je kunt de exacte specifieke van de server GC lezen bij **[fundamentalen van de garbagecollection](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF gebruikt standaard garbagecollection op het werkstation. Dit is voornamelijk te wijten aan een goede balans tussen geheugengebruik en prestaties, wat meer dan genoeg is voor slechts een paar bots, zoals gewoonlijk een enkele gelijktijdige achtergrond thread snel genoeg is om het volledige geheugen toegewezen door ASF te verwerken.

Vandaag de dag hebben we echter een heleboel CPU-cores waarvan ASF veel kan profiteren. door een speciale GC thread te hebben per elke CPU vCore die beschikbaar is. Dit kan de prestaties aanzienlijk verbeteren tijdens zware ASF-taken zoals het verwerken van badgepagina's of de inventaris, aangezien elke CPU vCore kan helpen, in tegenstelling tot slechts 2 (hoofd- en GC). Server GC wordt aanbevolen voor machines met 3 CPU vCores en meer, GC wordt automatisch afgedwongen als uw machine slechts 1 CPU vCore heeft, en als je precies 2 hebt, kun je het proberen (de resultaten kunnen variëren).

Server GC resulteert niet in een zeer grote geheugenstijging door alleen maar actief te zijn, maar het heeft een veel grotere generatiekans en is daarom veel luizer als het gaat om het teruggeven van geheugen aan OS. U kunt zich op een zoete plek bevinden waar server GC de prestaties aanzienlijk verbetert en u wilt het blijven gebruiken maar tegelijkertijd kun je je die enorme geheugenstijging niet veroorloven die voortkomt uit het gebruik ervan. Gelukkig voor jou is er een "beste van beide werelden" instelling. door server GC te gebruiken met **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** configuratie-eigenschap ingesteld op `0`, welke server GC nog steeds inschakelt, maar de grootte van de generatie beperkt en zich meer op het geheugen concentreert. Als alternatief kun je ook experimenteren met een andere eigenschap, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**, of zelfs beide tegelijk.

Echter, als geheugen geen probleem voor u is (aangezien GC nog steeds rekening houdt met uw beschikbare geheugen en zichzelf aanpast), het is een veel beter idee om deze eigenschappen helemaal niet te veranderen en betere prestaties te behalen.

---

U kunt de geselecteerde eigenschappen inschakelen door de juiste omgevingsvariabelen in te stellen. Bijvoorbeeld, op Linux (shell):

```shell
exporteer DOTNET_gcServer=1

./ArchiSteamFarm # Voor OS-specifieke build
./ArchiSteamFarm.sh # Voor generieke build
```

Of op Windows (powershell):

```powershell
$Env:DOTNET_gcServer=1

.\ArchiSteamFarm.exe # Voor OS-specifieke build
.\ArchiSteamFarm.cmd # Voor generieke build
```

---

## Aanbevolen optimalisatie

- Zorg ervoor dat u de standaardwaarde van `OptimizationModus` gebruikt, welke `MaxPerformance` is. Dit is verreweg de belangrijkste instelling, omdat het gebruik van `MinMemoryUsage` waarde dramatische effecten heeft op de prestaties.
- Schakel server GC in. Server GC kan onmiddellijk worden gezien als actief door aanzienlijke geheugenstijging ten opzichte van de werkplaats GC. Dit zal voor elke CPU-thread die je machine heeft een GC thread laten zien om tegelijkertijd met maximale snelheid bewerkingen uit te voeren.
- If you can't afford memory increase due to server GC, consider tweaking **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** and/or **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** to achieve "the best of both worlds". Maar als uw geheugen het zich kan veroorloven. dan is het beter om het op standaard te houden - server GC past zichzelf al aan tijdens de runtime en is slim genoeg om minder geheugen te gebruiken wanneer uw OS het echt nodig heeft.

Door bovenstaande aanbevelingen toe te passen, kunt u superieure ASF-prestaties hebben die snel omhoog gaan, zelfs met honderden of duizenden ingeschakelde bots. De CPU mag geen bottleneck meer zijn, omdat ASF uw volledige CPU-kracht kan gebruiken wanneer dat nodig is, en de vereiste tijd kan verkorten om het minimum te bereiken. De volgende stap zou zijn CPU-en RAM upgrades, of het splitsen van werklast over verschillende servers en ASF-instanties.