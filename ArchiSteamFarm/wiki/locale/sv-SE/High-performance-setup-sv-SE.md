# Högpresterande konfiguration

Detta är exakt motsatsen till **[låg-minneskonfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** och typiskt vill du följa dessa tips om du vill öka ASF-prestanda ytterligare (i termer av CPU-hastighet), för potentiella kostnader för ökad minnesanvändning.

---

ASF försöker redan att föredra prestanda när det gäller allmän balanserad stämning, därför finns det inte mycket du kan göra för att ytterligare öka sin prestanda, även om du inte är helt ur alternativ heller. Men tänk på att dessa alternativ inte är aktiverade som standard, vilket innebär att de inte är bra nog att överväga dem balanserade för de flesta användningsområden, Därför bör du själv bestämma om minnet ökar med dem är acceptabelt för dig.

---

## Runtime tuning (avancerat)

Nedan tricks **innebär allvarlig minnesökning** och bör därför användas med försiktighet.

Det rekommenderade sättet att tillämpa dessa inställningar är genom `DOTNET_` miljöegenskaper. Naturligtvis kan du också använda andra metoder, t.ex. `runtimeconfig. son`, men vissa inställningar är omöjliga att ställa in på detta sätt, och ovanpå att ASF kommer att ersätta din anpassade `runtimeconfig. son` med egen på nästa uppdatering, därför rekommenderar vi miljöegenskaper som du enkelt kan ställa in innan du startar processen.

.NET runtime låter dig **[justera sophämtaren](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** på många sätt, effektivt finjustera GC-processen efter dina behov. Vi har dokumenterat nedan fastigheter som är särskilt viktiga enligt vår mening.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Konfigurerar om programmet använder arbetsstation sophämtning eller server sophämtning.

Du kan läsa den exakta specifika av servern GC på **[grunderna i sophämtning](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF använder arbetsstationen sophämtning som standard. Detta beror främst på en bra balans mellan minnesanvändning och prestanda, vilket är mer än tillräckligt för bara ett fåtal botar, som vanligt en samtidig bakgrund GC-tråd är tillräckligt snabb för att hantera hela minnet som tilldelas av ASF.

Men idag har vi en hel del CPU-kärnor som ASF kan dra stor nytta av, genom att ha en dedikerad GC-tråd per varje CPU vCore som finns tillgänglig. Detta kan avsevärt förbättra prestandan under tunga ASF-uppgifter som att tolka märkessidor eller inventeringen, eftersom varje CPU vCore kan hjälpa, i motsats till bara 2 (main och GC). Server GC rekommenderas för maskiner med 3 CPU vCores och mer, arbetsstation GC automatiskt om din maskin har bara 1 CPU vCore, och om du har exakt 2 då kan du överväga att prova båda (resultaten kan variera).

Server GC själv resulterar inte i en mycket stor minnesökning genom att bara vara aktiv, men det har mycket större generationsstorlekar, och därför är mycket lata när det gäller att ge minne tillbaka till OS. Du kan hitta dig själv i en söt plats där servern GC ökar prestanda avsevärt och du vill fortsätta att använda det, men samtidigt har du inte råd med den enorma minnesökning som kommer ut av att använda den. Lyckligtvis för dig finns det en "bästa av två världar" inställning, genom att använda servern GC med **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** konfigurationsegenskap inställd på `0`, som fortfarande kommer att aktivera server GC, men begränsa generationsstorlekar och fokusera mer på minne. Alternativt kan du också experimentera med en annan egendom, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**, eller till och med båda samtidigt.

Men om minnet inte är ett problem för dig (som GC fortfarande tar hänsyn till ditt tillgängliga minne och tweaks själv), Det är en mycket bättre idé att inte ändra dessa egenskaper alls, uppnå överlägsen prestanda i resultatet.

---

Du kan aktivera valda egenskaper genom att ställa in lämpliga miljövariabler. Till exempel, på Linux (skal):

```shell
export DOTNET_gcServer=1

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

Eller på Windows (powershell):

```powershell
$Env:DOTNET_gcServer=1

.\ArchiSteamFarm.exe # För OS-specifik bygg
.\ArchiSteamFarm.cmd # För generisk bygg
```

---

## Rekommenderad optimering

- Se till att du använder standardvärdet för `OptimizationMode` som är `MaxPerformance`. Detta är den överlägset viktigaste inställningen, eftersom att använda värdet `MinMemoryUsage` har dramatiska effekter på prestanda.
- Aktivera server GC. Server GC kan omedelbart ses som aktiv av betydande minnesökning jämfört med arbetsstation GC. Detta kommer att skapa en GC-gänga för varje CPU-gänga som din maskin har för att utföra GC-drift parallellt med maximal hastighet.
- Om du inte har råd med minnesökning på grund av server GC, överväga att tweaking **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** och/eller **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** för att uppnå "det bästa av två världar". Men om ditt minne har råd med det, då är det bättre att hålla det som standard - servern GC anpassar sig redan under körtiden och är smart nog att använda mindre minne när ditt operativsystem verkligen behöver det.

Tillämpa rekommendationer ovan kan du ha överlägsen ASF prestanda som bör vara blazing snabbt även med hundratals eller tusentals aktiverade botar. CPU bör inte vara en flaskhals längre, eftersom ASF kan använda hela din CPU ström när det behövs, kapning krävs tid till naken minimum. Nästa steg skulle vara CPU- och RAM-uppgraderingar, eller delning av arbetsbelastning mellan flera servrar och ASF-instanser.