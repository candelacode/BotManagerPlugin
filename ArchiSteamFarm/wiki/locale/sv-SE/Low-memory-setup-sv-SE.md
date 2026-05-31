# Konfiguration av lågt minne

Detta är exakt motsatsen till **[högpresterande installation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup)** och vanligtvis vill du följa dessa tips om du vill minska ASFs minnesanvändning, för kostnader för att sänka den totala prestandan.

---

ASF är extremt lätt på resurser per definition, beroende på din användning även 128 MB VPS med Linux kan köra det, även om att gå så lågt rekommenderas inte och kan leda till olika frågor. Även om det är lätt, ASF är inte rädd för att be OS om mer minne, om sådant minne behövs för ASF att fungera med optimal hastighet.

ASF som en applikation försöker vara så optimerad och effektiv som möjligt, vilket också tar hänsyn till resurser som används under genomförandet. När det gäller minne föredrar ASF prestanda framför minnesförbrukning, vilket kan resultera i temporärt minne "spikes", som kan märkas t.ex. med konton med 3+ badge sidor, som ASF kommer att hämta och tolka första sidan, läsa från det totala antalet sidor, starta sedan hämta uppgift för varje extra sida, vilket resulterar i samtidig hämtning och tolkning av återstående sidor. Att "extra" minnesanvändning (jämfört med minimal användning) dramatiskt kan påskynda utförandet och den totala prestandan, för kostnaden för ökad minnesanvändning som behövs för att göra alla dessa saker parallellt. Liknande saker händer med alla andra allmänna ASF uppgifter som kan köras parallellt, t.ex. med parsning av aktiva handelserbjudanden kan ASF tolka alla på en gång, eftersom de alla är oberoende av varandra. Ovanpå det kommer ASF (C# runtime) **inte** returnera oanvänt minne tillbaka till OS omedelbart efteråt, som du snabbt märker i form av ASF-processen endast tar mer och mer minne, men (nästan) aldrig ge det minnet tillbaka till OS. Vissa människor kanske redan finner det tvivelaktigt, kanske till och med misstänker ett minnesläckage, men oroa dig inte, allt detta är att vänta.

ASF är extremt väl optimerad och utnyttjar tillgängliga resurser så mycket som möjligt. Hög minnesanvändning av ASF betyder inte att ASF aktivt **använder** att minne och **behöver det**. Mycket ofta ASF kommer att hålla allokerat minne som "rum" för framtida åtgärder, eftersom vi drastiskt kan förbättra prestandan om vi inte behöver be OS för varje minnesblock som vi är på väg att använda. Runtime bör automatiskt släppa oanvänt ASF-minne tillbaka till OS när OS kommer **verkligen** behöver det. **[Oanvänt minne är bortkastat minne](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. Du stöter på problem när minnet du **behöver** är högre än det minne som är tillgängligt för dig, inte när ASF håller några extra allokerade med syfte att påskynda funktioner som kommer att köras i ett ögonblick. Du stöter på problem när din Linux-kärna dödar ASF-processen på grund av OOM (ur minnet), inte när du ser ASF process som toppminne konsument i `htop`.

**[Garbage collection](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** process som används i ASF är en mycket komplex mekanism, smart nog att ta hänsyn till inte bara ASF själv, men även ditt operativsystem och andra processer. När du har en hel del ledigt minne, ASF kommer att be om vad som behövs för att förbättra prestandan. Detta kan vara lika mycket som 1 GB (med server GC). När ditt OS-minne är nära att vara full, ASF kommer automatiskt att släppa en del av det tillbaka till OS för att hjälpa saker att slå sig ner, vilket kan resultera i en total ASF-minnesanvändning så lågt som 50 MB. Skillnaden mellan 50 MB och 1 GB är enorm, men så är skillnaden mellan små 512 MB VPS och stora dedikerade server med 32 GB. Om ASF kan garantera att detta minne kommer till nytta, och samtidigt inget annat kräver det just nu, Det kommer att föredra att hålla den och automatiskt optimera sig själv baserat på rutiner som utfördes i det förflutna. Den GC som används i ASF är självstämande och kommer att uppnå bättre resultat ju längre processen är igång.

Detta är också varför ASF processminne varierar från installation till installation, som ASF kommer att göra sitt bästa för att använda tillgängliga resurser i **så effektivt sätt som möjligt**, och inte på ett fast sätt som det gjordes under Windows XP-tider. Den faktiska (verkliga) minnesanvändningen som ASF använder kan verifieras med `stats` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, och är oftast runt 4 MB för bara några bots, upp till 30 MB om du använder saker som **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** och andra avancerade funktioner. Kom ihåg att minnet som returneras av kommandot `stats` också innehåller ledigt minne som inte har återtagits av sophämtaren än. Allt annat är delat runtime minne (ca 40-50 MB) och rum för utförande (varierande). Det är också därför samma ASF kan använda så lite som 50 MB i dåligt minne VPS miljö, när du använder upp till 1 GB på skrivbordet. ASF anpassar sig aktivt till din miljö och kommer att försöka hitta optimal balans för att varken sätta ditt operativsystem under tryck, eller begränsa sin egen prestanda när du har en hel del oanvänt minne som kan sättas i bruk.

---

Naturligtvis, Det finns en hel del sätt hur du kan hjälpa till att peka ASF i rätt riktning när det gäller det minne du förväntar dig att använda. I allmänhet om du inte behöver göra det, är det bäst att låta sophämtaren arbeta i fred och göra vad den anser är bäst. Men detta är inte alltid möjligt, till exempel om din Linuxserver också är värd för flera webbplatser, MySQL-databas och PHP arbetare, då har du inte riktigt råd ASF krympa sig själv när du kör nära OOM, eftersom det är oftast för sent och prestanda nedbrytning kommer tidigare. Detta är oftast när du kan vara intresserad av ytterligare stämning, och därför läsa denna sida.

Nedan förslag är indelade i några kategorier med varierande svårigheter.

---

## ASF inställning (lätt)

Nedan tricks **påverkar inte prestanda negativt** och kan säkert appliceras på alla inställningar.

- Kör **[generisk version](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** av ASF om möjligt. Generisk version av ASF använder mindre minne eftersom det inte innehåller runtime inuti, inte kommer som en enda fil, behöver inte packa upp sig själv på språng och är därför mindre och har mindre minnesfotavtryck. OS-specifika paket är praktiska och smidiga, men de levereras också med allt som behövs för att starta ASF, vilket är något du kan ta hand om dig själv och använda generisk ASF variant istället.
- Kör aldrig mer än en ASF-instans. ASF är tänkt att hantera obegränsat antal robotar på en gång, och om du inte binder varje ASF instans till olika gränssnitt/IP-adress, du bör ha exakt **en** ASF-process, med flera bottar (om det behövs).
- Använd `ShutdownOnFarmingAvslutad` i botens `FarmingPreferences`. Active bot tar mer resurser än avaktiverad. Det är inte en betydande räddning, eftersom tillståndet av bot fortfarande måste behållas, men du sparar en del resurser, särskilt alla resurser relaterade till nätverk, såsom TCP-uttag. Du kan alltid ta upp andra robotar om det behövs.
- Håll dina robotar nummer låga. Inte `Aktiverad` bot instans tar mindre resurser, eftersom ASF inte bry sig om att starta det. Kom också ihåg att ASF måste skapa en bot för var och en av dina konfigurationer, om du inte behöver `starta` given bot och du vill spara lite extra minne, du kan tillfälligt byta namn på `Bot. son` till t.ex. `Bot.json.bak` för att undvika att skapa status för din handikappade bot instans i ASF. På så sätt kommer du inte att kunna `starta` det utan att döpa om det tillbaka, men ASF kommer inte heller att bry sig om att behålla tillståndet av denna bot i minnet, lämnar utrymme för andra saker (mycket liten spara, i 99. % fall du inte bör bry dig om det, bara hålla dina robotar med `Aktiverade` av `false`).
- Finjustera dina konfigurationer. Speciellt global ASF-konfiguration har många variabler att justera, till exempel genom att öka `LoginLimiterDelay` kommer du ta upp dina robotar långsammare, vilket kommer att tillåta redan startat instans att hämta märken under tiden, i motsats till att ta upp dina robotar snabbare, vilket kommer att ta mer resurser eftersom fler robotar kommer att göra stort arbete (såsom parsning av märken) samtidigt. Ju mindre arbete som måste göras samtidigt - desto mindre minne som använts.

Det är några saker du kan tänka på när du arbetar med minnesanvändning. Men de sakerna har ingen "avgörande" materia om minnesanvändning, eftersom minnesanvändning kommer mestadels från saker ASF har att ta itu med, och inte från interna strukturer som används för kortodling.

De mest resurskrävande funktionerna är:
- Utmärkelse: sida tolkning
- Inventering parsning

Vilket innebär att minnet kommer att spika mest när ASF har att göra med att läsa märkessidor, och när det handlar om dess inventering (e. . skicka handel eller arbeta med STM). Detta beror på att ASF har att ta itu med riktigt stora mängder data - minnesanvändningen av din favorit webbläsare som lanserar dessa två sidor kommer inte att vara lägre än så. Tyvärr, det är så det fungerar - minska antalet dina märken, och hålla antalet dina inventarier låga, som kan säkert hjälpa till.

---

## Runtime tuning (avancerat)

Nedan tricks **involverar prestandaförsämring** och bör användas med försiktighet.

Det rekommenderade sättet att tillämpa dessa inställningar är genom `DOTNET_` miljöegenskaper. Naturligtvis kan du också använda andra metoder, t.ex. `runtimeconfig. son`, men vissa inställningar är omöjliga att ställa in på detta sätt, och ovanpå att ASF kommer att ersätta din anpassade `runtimeconfig. son` med egen på nästa uppdatering, därför rekommenderar vi miljöegenskaper som du enkelt kan ställa in innan du startar processen.

.NET runtime låter dig **[justera sophämtaren](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** på många sätt, effektivt finjustera GC-processen efter dina behov. Vi har dokumenterat nedan fastigheter som är särskilt viktiga enligt vår mening.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Anger den tillåtna GC-heapanvändningen som en procentandel av det totala fysiska minnet.

Den "hårda" minnesgränsen för ASF-processen, den här inställningen låter GC endast använda en delmängd av totalt minne och inte allt av det. Det kan bli särskilt användbart i olika serverliknande situationer där du kan dedikera en fast procentandel av serverns minne för ASF, men aldrig mer än så. Var uppmärksam på att begränsa minnet för ASF att använda kommer inte magiskt göra alla de som krävs minne allokeringar försvinner, därför ställa in detta värde för lågt kan resultera i att köra in i ut ur minnesscenarier, där ASF-processen kommer att tvingas att sluta.

Å andra sidan, ställa in detta värde tillräckligt högt är ett perfekt sätt att säkerställa att ASF aldrig kommer att använda mer minne än du realistiskt har råd med, ge din maskin lite andrum även under tung belastning, samtidigt som programmet kan göra sitt jobb så effektivt som möjligt.

### [`GCConveMemory`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Konfigurerar sophämtaren för att bevara minnet på bekostnad av mer frekventa sophämtningar och eventuellt längre paustider.

Ett värde mellan 0-9 kan användas. Ju större värde desto mer GC kommer att optimera minnet över prestanda.

### [`GCHighMemProcent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Anger mängden minne som används varefter GC blir mer aggressiv.

Denna inställning konfigurerar minneströskeln för hela ditt OS, som en gång passerade, gör att GC blir mer aggressiv och försöker hjälpa OS att sänka minnesbelastningen genom att köra mer intensiv GC-process och därmed släppa mer fritt minne tillbaka till OS. Det är en bra idé att ställa in den här egenskapen till maximalt antal minne (som procent) som du anser vara "kritiskt" för hela din OS prestanda. Standard är 90%, och oftast vill du behålla det i 80-97% sortiment, eftersom för lågt värde kommer att orsaka onödig aggression från GC och prestanda nedbrytning utan anledning, medan för högt värde kommer att lägga onödig belastning på ditt OS, med tanke på ASF kan släppa en del av sitt minne för att hjälpa.

### **[`GCLatencyLevel`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Anger den GC-latensnivå som du vill optimera för.

Detta är odokumenterad egendom som visade sig fungera exceptionellt bra för ASF, genom att begränsa storleken på GC-generationer och i resultatet göra GC-rensa dem oftare och mer aggressivt. Standard (balanserad) latensnivå är `1`, men du kan använda `0`, vilket kommer att stämma för minnesanvändning.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> När vi trimma den engagerade utrymmet mer aggressivt för den efemära sömmen. Detta används för att köra många instanser av serverprocesser där de vill hålla så lite minne som möjligt.

Detta ger lite förbättring, men kan göra GC ännu mer aggressiv när systemet kommer att vara lågt på minne, speciellt för ASF som använder sig av trådbassänguppgifter kraftigt.

---

Du kan aktivera valda egenskaper genom att ställa in lämpliga miljövariabler. Till exempel, på Linux (skal):

```shell
# Glöm inte att ställa in dem om du planerar att använda dem
exportera DOTNET_GCHeapHardLimitPercent=0x4B # 75% som hex
exportera DOTNET_GCHighMemPercent=0x50 # 80% som hex

exportera DOTNET_GCConserveMemory=9
export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

. ArchiSteamFarm # För OS-specifik bygg
./ArchiSteamFarm.sh # För generisk bygg
```

Eller på Windows (powershell):

```powershell
# Glöm inte att ställa in dessa om du planerar att använda dem
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% som hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80% som hex

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOT_gcTrimCommitOnLowMemory=1

. ArchiSteamFarm.exe # För OS-specifika bygg
.\ArchiSteamFarm.cmd # För generisk bygg
```

Speciellt `GCLatencyLevel` kommer mycket användbart eftersom vi verifierade att runtime verkligen optimerar koden för minne och därför sjunker genomsnittlig minnesanvändning avsevärt, även med server GC. Det är ett av de bästa knepen som du kan använda om du vill sänka ASF-minnesanvändningen betydligt samtidigt som du inte försämrar prestandan för mycket med `OptimeringLäge`.

---

## ASF stämning (mellan)

Nedan tricks **innebär allvarlig prestandaförsämring** och bör användas med försiktighet.

- Som en sista utväg kan du ställa in ASF för `MinMinderminneAnvändning` genom `OptimeringLäge` **[global konfigurationsegenskap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**. Läs noga dess syfte, eftersom detta är allvarliga prestanda försämring för nästan inga minnesfördelar. Detta är typiskt **det sista du vill göra**, långt efter att du gått igenom **[runtime tuning](#runtime-tuning-advanced)** för att se till att du tvingas göra detta. Om inte helt avgörande för din installation avråder vi från att använda `MinMemoryUsage`, även i minnesbegränsade miljöer.

---

## Rekommenderad optimering

- Börja från enkla ASF setup tricks, använd **[generisk ASF variant](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** och kontrollera om du kanske bara använder din ASF på ett felaktigt sätt som att starta processen flera gånger för alla dina botar, eller hålla dem alla aktiva om du behöver bara en eller två för att autostart.
- Om det fortfarande inte räcker, aktivera alla konfigurationsegenskaper som anges ovan genom att ställa in lämpliga miljövariabler för `DOTNET_`. Speciellt `GCLatencyLevel` erbjuder betydande förbättringar körtid för lite kostnad på prestanda.
- Om inte ens det hjälpte aktiverar som en sista utväg `MinMemoryUsage` `OptimizationMode`. Detta tvingar ASF att utföra nästan allt i synkron, materia, vilket gör att det fungerar mycket långsammare men inte heller förlitar sig på trådpool för att balansera saker och ting när det gäller parallellt utförande.

Det är fysiskt omöjligt att minska minnet ännu mer, din ASF är redan kraftigt degraderad när det gäller prestanda och du tömde alla dina möjligheter, både kodmässigt och körtidsmässigt. Överväg att lägga till lite extra minne för ASF att använda, även 128 MB skulle göra stor skillnad.