# Oppsett av høy ytelse

Dette er nøyaktig i motsatt retning av **[lavminneoppsett](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** og vil vanligvis følge disse tipsene hvis du ønsker å øke ASF-ytelsen ytterligere (i form av CPU-hastighet), for potensielle kostnader for økt minnebruk.

---

ASF forsøker allerede å foretrekke ytelse når det gjelder generell balansert styring. Derfor er det ikke mye du kan gjøre mer for å øke innsatsen ytterligere, men du er ikke helt ute av alternativer. Husk imidlertid at disse alternativene ikke er aktivert som standard, noe som betyr at de ikke er gode nok til å anse dem balansert for de fleste bruksområder, Derfor bør du selv avgjøre om hukommelsen øker slik at den kan aksepteres for deg.

---

## Runtime tuning (avansert)

Under triksene **involver alvorlig minne-økning** og bør derfor brukes med forsiktighet.

Anbefalt måte å bruke disse innstillingene på er gjennom `DOTNET_` miljøegenskaper. Du kan selvsagt også bruke andre metoder, f.eks. `runtimeconfig. sønn`, men noen innstillinger kan ikke velges på denne måten. og oppå den ASF vil erstatte din egendefinerte `runtimeconfig. sønn` med egen oppdatering som kan, derfor anbefaler vi miljøegenskaper som du enkelt kan sette før prosessen starter.

.NET kjøretid tillater deg til **[å justere søppelpost](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** på mange måter effektiv finstyring av GC-prosessen i henhold til dine behov. Vi har dokumentert under egenskaper som er spesielt viktige etter vår vurdering.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Konfigurere om applikasjonen bruker samling av arbeidstasjon eller søppelpost fra tjeneren.

Du kan lese den eksakte spesifikke av server GC på **[fundamentaler av søppelpost](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF benytter seg av søppelpost som standard. Dette skyldes hovedsakelig den gode balansen mellom minnebruk og ytelse, som er mer enn nok til bare noen få boter, da vanlig én enkelt samtidig bakgrunnsGC-tråden er rask nok til å håndtere hele minnet allokert av ASF.

I dag har vi imidlertid mye prosessorkjerner som ASF kan ha stor nytte av, sier konsernsjef Helge Lund. ved å ha en egen GC-tråd per hver CPU vCore som er tilgjengelig. Dette kan sterkt forbedre ytelsen under tunge ASF-oppgaver, slik som parkerings- og merkesider eller inventar, siden hver CPU vCore kan hjelpe i motsetning til bare 2 (hoved- og GC). Server GC anbefales for maskiner med 3 CPU vCores og mer, arbeidsstasjon GC blir automatisk tvunget hvis maskinen har bare 1 CPU vCore, og hvis du har nøyaktig 2, kan du vurdere å prøve ut både (resultatene kan variere).

Tjeneren GC selv fører ikke til en veldig enorm minneøkning bare ved å være aktiv, men har mye større generasjonsstørrelser, og er derfor langt mer lat når det gjelder å gi oss minne tilbake til OS. Du kan finne deg selv på et sted hvor GC for server øker ytelsen betraktelig, og du vil fortsette å bruke det men samtidig kan du ikke ha råd til at enorm minne øker som kommer ut av bruk. Heldigvis for deg, så finnes det et «beste av begge verdener», ved hjelp av server GC med **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** konfigurasjonen satt til `0`, som fortsatt vil aktivere server GC, men begrense generasjonsstørrelser og fokusere mer på minne. Alternativt kan du også eksperimentere med en annen eiendom, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**, eller til og med begge deler på samme tid.

Hvis minnet ikke er et problem for deg (som GC fortsatt tar med seg selv i betraktning ditt tilgjengelige hukommelse og tweaks), Det er mye bedre å ikke endre de egenskapene i det hele tatt og oppnå bedre resultater.

---

Du kan aktivere valgte egenskaper ved å sette riktige miljøvariabler. For eksempel, på Linux (skall):

```shell
eksporter DOTNET_gcServer=1

./ArchiSteamFarm # For OS-spesifikk versjon
./ArchiamFarm.sh # For generisk versjon
```

Or on Windows (powershell):

```powershell
$Env:DOTNET_gcServer=1

.\ArchiSteamFarm.exe # For OS-spesifikk versjon
.\ArchiSteamFarm.cmd # For generisk bygging
```

---

## Anbefalt optimalisering

- Sørg for at du bruker standardverdien `OptimizationMode` som er `MaxPerformance`. Dette er den klart viktigste innstillingen å bruke `MinMemoryusage` -verdien har dramatiske effekter på ytelsen.
- Aktiver server GC. Serverens GC kan øyeblikkelig bli sett på som aktiv av signifikant minne økning i forhold til stasjonær GC. Dette vil fremkalle en GC-tråd for hver CPU-tråd som maskinen din har for å utføre GC operasjoner parallelt med maksimal hastighet.
- Hvis du ikke har råd til minne på grunn av server GC, vurder å justere **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** og/eller **[`GCHeapHardPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** for å oppnå "de beste av begge verdenene". Men om minnet har råd til det, da er det bedre å holde den på standard - server GC allerede tweaks seg selv under kjøring tiden og er smart nok til å bruke mindre minne når OS virkelig trenger det.

Å anvende anbefalinger over lar deg ha overlegne ASF-ytelse som bør være lysere raskt, selv med hundrevis eller tusenvis av aktiverte botter. Prosessor bør ikke være en flaskehals lenger, da ASF kan bruke hele CPU-effekten ved behov, og reduser tiden til å bare minimum. Neste steg ville være prosessor- og RAM-oppgraderinger, eller at arbeidsmengde splittes på tvers av flere servere og ASF-instanser.