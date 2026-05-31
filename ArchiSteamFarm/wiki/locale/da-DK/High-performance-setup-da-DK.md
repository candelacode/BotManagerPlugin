# Højydelsesopsætning

Dette er præcis det modsatte af **[lav hukommelse opsætning](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** og typisk ønsker du at følge disse tips, hvis du ønsker yderligere at øge ASF ydeevne (i form af CPU hastighed), for potentielle omkostninger til øget hukommelsesforbrug.

---

ASF forsøger allerede at foretrække ydeevne, når det kommer til generel balanceret tuning, derfor er der ikke meget du kan gøre for yderligere at øge dens ydeevne, selv om du ikke er helt ude af muligheder enten. Men husk på, at disse muligheder ikke er aktiveret som standard, hvilket betyder, at de ikke er gode nok til at overveje dem afbalanceret for de fleste anvendelser, derfor bør du selv bestemme, om det er acceptabelt for dig at øge hukommelsen som følge af dem.

---

## Runtime tuning (avanceret)

Under tricks **involverer alvorlig hukommelsesstigning** og bør derfor anvendes med forsigtighed.

Den anbefalede måde at anvende disse indstillinger på er gennem `DOTNET_` miljøegenskaber. Selvfølgelig kan du også bruge andre metoder, f.eks. `runtimeconfig. son`, men nogle indstillinger er umulige at indstille på denne måde, og oven i denne ASF vil erstatte din brugerdefinerede `runtimeconfig. Søn` med sine egne på den næste opdatering, derfor anbefaler vi miljøegenskaber, som du nemt kan indstille før start af processen.

.NET runtime giver dig mulighed for at **[finjustere garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** på mange måder, effektivt finjustere GC-processen i henhold til dine behov. Vi har dokumenteret nedenstående egenskaber, der er særligt vigtige efter vores mening.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Konfigurerer om programmet bruger workstation garbage collection eller server garbage collection.

Du kan læse den nøjagtige specifikke af serveren GC på **[fundamentals of garbage collection](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF bruger arbejdsstationen garbage collection som standard. Dette er primært på grund af en god balance mellem hukommelse forbrug og ydeevne, som er mere end nok til blot et par bots, som regel en enkelt sideløbende baggrund GC tråd er hurtig nok til at håndtere hele hukommelsen allokeret af ASF.

Men i dag har vi en masse CPU-kerner, som ASF kan drage stor fordel af, ved at have en dedikeret GC-tråd pr. CPU vCore der er tilgængelig. Dette kan i høj grad forbedre ydeevnen under tunge ASF opgaver såsom parsing badge sider eller opgørelsen, da hver CPU vCore kan hjælpe, i modsætning til kun 2 (main og GC). Server GC anbefales til maskiner med 3 CPU vCores og mere, arbejdsstation GC bliver automatisk tvunget hvis din maskine har kun 1 CPU vCore, og hvis du har præcis 2 så kan du overveje at prøve begge (resultater kan variere).

Server GC selv ikke resulterer i en meget stor hukommelse stigning ved bare at være aktiv, men det har meget større generation størrelser, og derfor er langt mere doven, når det kommer til at give hukommelse tilbage til OS. Du kan finde dig selv i et sødt sted, hvor server GC øger ydeevnen betydeligt, og du vil gerne fortsætte med at bruge det, men på samme tid har du ikke råd til den enorme hukommelse stigning, der kommer ud af at bruge det. Heldigvis for dig, er der en "bedste af begge verdener" indstilling, ved at bruge server GC med **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** konfigurationsejendom sat til `0`, som stadig vil aktivere server GC, men begrænse generering størrelser og fokusere mere på hukommelse. Alternativt kan du også eksperimentere med en anden ejendom, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**eller endda begge dele på samme tid.

Men hvis hukommelse ikke er et problem for dig (som GC stadig tager hensyn til din tilgængelige hukommelse og tilpasser sig selv), det er en meget bedre idé ikke at ændre disse egenskaber overhovedet, opnå overlegen ydeevne i resultatet.

---

Du kan aktivere valgte egenskaber ved at indstille passende miljøvariabler. For eksempel, på Linux (shell):

```shell
Eksport DOTNET_gcServer=1

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generisk build
```

Eller på Windows (powershell):

```powershell
$Env:DOTNET_gcServer=1

.\ArchiSteamFarm.exe # For OS-specifik build
.\ArchiSteamFarm.cmd # For generisk build
```

---

## Anbefalet optimering

- Sørg for, at du bruger standardværdien af `OptimizationMode` som er `MaxPerformance`. Dette er langt den vigtigste indstilling, da brugen af værdien `MinMemoryUsage` har dramatiske virkninger på ydeevnen.
- Aktiver server GC. Server GC kan umiddelbart ses som værende aktiv af betydelig hukommelse stigning i forhold til arbejdsstation GC. Dette vil gyde en GC tråd for hver CPU tråd din maskine har for at udføre GC operationer parallelt med maksimal hastighed.
- Hvis du ikke har råd til hukommelse stigning på grund af server GC, overvej tweaking **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** og/eller **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** for at opnå "det bedste fra begge verdener". Men hvis din hukommelse har råd til det, så er det bedre at holde det på standard - server GC allerede tweaks sig selv under runtime og er smart nok til at bruge mindre hukommelse, når dit OS virkelig har brug for det.

Anvendelse af ovenstående anbefalinger giver dig mulighed for at have overlegen ASF ydeevne, der bør være blazing hurtigt, selv med hundredvis eller tusindvis af aktiverede bots. CPU bør ikke være en flaskehals længere, da ASF er i stand til at bruge hele din CPU strøm, når det er nødvendigt, skære den nødvendige tid til bare minimum. Det næste skridt ville være CPU og RAM opgraderinger, eller opdele arbejdsbyrde på tværs af flere servere og ASF forekomster.