# Lav-hukommelsesopsætning

Dette er præcis det modsatte af **[højtydende opsætning](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup)** , og du ønsker typisk at følge disse tips, hvis du ønsker at reducere ASF's hukommelsesforbrug, for udgifter til sænkning af den samlede præstation.

---

ASF er ekstremt let på ressourcer pr. definition, afhængigt af din brug selv 128 MB VPS med Linux er i stand til at køre det, selv om gå, at lav ikke anbefales og kan føre til forskellige problemer. Mens de er lys, ASF er ikke bange for at spørge OS for mere hukommelse, hvis en sådan hukommelse er nødvendig for ASF til at operere med optimal hastighed.

ASF som et program forsøger at være så meget optimeret og effektiv som muligt, hvilket også tager hensyn til ressourcer, der anvendes under udførelsen. Når det kommer til hukommelse, foretrækker ASF ydeevne frem for hukommelsesforbrug, hvilket kan resultere i midlertidig hukommelse "spikes", der kan bemærkes f.eks med konti med 3+ badge sider, som ASF vil hente og fortolke første side, læse fra det samlede antal sider, start derefter hente opgaven for hver ekstra side, hvilket resulterer i samtidige hentning og parsing af resterende sider. At "ekstra" hukommelsesforbrug (sammenlignet med bare minimum for operation) kan dramatisk fremskynde udførelsen og den samlede ydeevne, for omkostningerne ved øget hukommelsesforbrug, der er nødvendig for at gøre alle disse ting parallelt. Lignende ting sker til alle andre generelle ASF opgaver, der kan køres parallelt, fx med parsing aktive handel tilbud, ASF kan parse dem alle på én gang, da de alle er uafhængige af hinanden. Oven i det, vil ASF (C# runtime) **ikke** returnere ubrugt hukommelse tilbage til OS umiddelbart efter, som du hurtigt kan mærke i form af ASF proces kun tager mere og mere hukommelse, men (næsten) aldrig give denne hukommelse tilbage til operativsystemet. Nogle mennesker kan allerede finde det tvivlsomt, måske endda mistanke om en hukommelse læk, men bare rolig, alt dette kan forventes.

ASF er ekstremt godt optimeret og gør brug af de tilgængelige ressourcer så meget som muligt. Høj hukommelsesforbrug af ASF betyder ikke, at ASF aktivt **bruger** den hukommelse og **har brug for det**. Meget ofte vil ASF holde allokeret hukommelse som "rum" til fremtidige handlinger, fordi vi drastisk kan forbedre ydeevnen, hvis vi ikke behøver at spørge OS for hver hukommelse chunk, som vi er ved at bruge. Runtime bør automatisk frigive ubrugt ASF hukommelse tilbage til OS når OS vil **virkelig** har brug for det. **[Ubrugt hukommelse spildes](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. Du løber ind i problemer, når hukommelsen du **behøver** er højere end den hukommelse, der er tilgængelig for dig, ikke når ASF holder nogle ekstra allokeret med det formål at fremskynde funktioner, der vil udføre om et øjeblik. Du løber ind i problemer, når din Linux-kerne dræber ASF-processen på grund af OOM (ud af hukommelse), ikke når du ser ASF proces som top hukommelse forbruger i `htop`.

**[Garbage collection](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** -processen, der anvendes i ASF, er en meget kompleks mekanisme, smart nok til at tage hensyn ikke kun ASF selv, men også din OS og andre processer. Når du har en masse fri hukommelse, vil ASF bede om hvad der er nødvendigt for at forbedre ydeevnen. Dette kan være lige så meget som 1 GB (med server GC). Når din OS hukommelse er tæt på at være fuld, vil ASF automatisk frigive noget af det tilbage til OS for at hjælpe tingene afgøre ned, hvilket kan resultere i en samlet ASF hukommelsesforbrug så lavt som 50 MB. Forskellen mellem 50 MB og 1 GB er enorm, men så er forskellen mellem lille 512 MB VPS og stor dedikeret server med 32 GB. Hvis ASF kan garantere, at denne hukommelse vil blive nyttig, og samtidig intet andet kræver det lige nu, vil foretrække at holde det og automatisk optimere sig selv baseret på rutiner, der blev henrettet i fortiden. GC bruges i ASF er selv-tuning og vil opnå bedre resultater jo længere processen kører.

Dette er også grunden til ASF proces hukommelse varierer fra opsætning til opsætning, da ASF vil gøre sit bedste for at udnytte de tilgængelige ressourcer i **så effektivt som muligt**og ikke på en fast måde, som det blev gjort under Windows XP gange. Det faktiske (real) hukommelsesforbrug, som ASF bruger, kan verificeres med `statistik` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, og er normalt omkring 4 MB for blot et par bots, op til 30 MB hvis du bruger ting som **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** og andre avancerede funktioner. Husk, at hukommelsen returneres af `statistik` kommando indeholder også gratis hukommelse, der ikke er blevet regenereret af garbage collector endnu. Alt andet er delt runtime hukommelse (omkring 40-50 MB) og plads til udførelse (variere). Dette er også grunden til, at den samme ASF kan bruge så lidt som 50 MB i lav hukommelse VPS miljø, mens du bruger selv op til 1 GB på skrivebordet. ASF tilpasser sig aktivt til dit miljø og vil forsøge at finde den optimale balance for hverken at sætte dit operativsystem under pres. eller begrænse sin egen ydeevne, når du har en masse ubrugt hukommelse, der kunne sættes i brug.

---

Selvfølgelig der er en masse måder, hvordan du kan hjælpe med at pege ASF i den rigtige retning med hensyn til den hukommelse, du forventer at bruge. Generelt hvis du ikke behøver at gøre det, er det bedst at lade skrald samler arbejde i fred og gøre, hvad det mener er bedst. Men dette er ikke altid muligt, for eksempel hvis din Linux-server også er vært for flere hjemmesider, MySQL-database og PHP-medarbejdere. så har du ikke rigtig råd til ASF skrumper sig selv, når du løber tæt på OOOM, da det normalt er for sent og forringelse af ydeevnen kommer tidligere. Dette er normalt, når du kunne være interesseret i yderligere tuning, og derfor læse denne side.

Nedenfor forslag er opdelt i et par kategorier, med varieret sværhedsgrad.

---

## ASF opsætning (let)

Under tricks **påvirker ikke ydeevnen negativt** og kan anvendes sikkert på alle opsætninger.

- Kør **[generisk version](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** af ASF om muligt. Generisk version af ASF bruger mindre hukommelse, da det ikke omfatter runtime indeni, kommer ikke som enkelt fil, behøver ikke at pakke sig ud på fart, og er derfor mindre og har mindre hukommelse fodaftryk. OS-specifikke pakker er praktiske og praktiske, men de er også bundtet med alt det nødvendige for at lancere ASF, hvilket er noget, du kan tage sig af dig selv og bruge generisk ASF variant i stedet.
- Kør aldrig mere end én ASF instans. ASF er beregnet til at håndtere ubegrænset antal bots alle på én gang, og medmindre du er bindende hver ASF instans til forskellige interface/IP-adresse, du skal have præcis **en** ASF proces, med flere bots (hvis nødvendigt).
- Gør brug af `ShutdownOnFarmingFinished` i bot's `FarmingPreferences`. Aktiv bot tager flere ressourcer end deaktiveret en. Det er ikke en betydelig gemme, da tilstand af bot stadig skal bibeholdes, men du sparer en vis mængde ressourcer, især alle ressourcer relateret til netværk, såsom TCP stikkontakter. Du kan altid opdrage andre bots, hvis det er nødvendigt.
- Hold dine bots tal lave. Ikke `Aktiveret` bot instans tager færre ressourcer, da ASF ikke generer at starte den. Husk også, at ASF er nødt til at oprette en bot for hver af dine konfigurationer, derfor, hvis du ikke behøver at `starte` given bot og du vil gemme nogle ekstra hukommelse, du kan midlertidigt omdøbe `Bot. Søn` til f.eks. `Bot.json.bak` for at undgå at skabe status for din deaktiverede bot-instans i ASF. På denne måde vil du ikke være i stand til at `starte` den uden at omdøbe den tilbage men ASF vil heller ikke genere at holde tilstand af denne bot i hukommelse, hvilket giver plads til andre ting (meget lille gemme, i 99. % tilfælde, du ikke bør bekymre dig om det, bare holde dine bots med `aktiveret` af `false`).
- Finjuster dine konfigurationer. Især global ASF config har mange variabler at justere, for eksempel ved at øge `LoginLimiterDelay` du vil bringe dine bots langsommere som vil gøre det muligt allerede startet instans at hente badges i mellemtiden, i stedet for at opdrage dine bots hurtigere, som vil tage flere ressourcer, da flere bots vil gøre stort arbejde (såsom parsing badges) på samme tid. Jo mindre arbejde der skal gøres på samme tid - jo mindre hukommelse der bruges.

Det er et par ting, du kan huske på, når det drejer sig om hukommelsesforbrug. Men disse ting har ikke nogen "afgørende" stof på hukommelsesforbrug, fordi hukommelsen hovedsagelig kommer fra ting ASF har at beskæftige sig med, og ikke fra interne strukturer, der anvendes til kort landbrug.

De fleste ressourcer-tunge funktioner er:
- Fortolkning af skilteside
- Fortolkning af inventar

Hvilket betyder, at hukommelsen vil spike mest, når ASF beskæftiger sig med at læse badge sider, og når det beskæftiger sig med sin opgørelse (f. eks. . sende handel eller arbejde med STM). Dette skyldes, at ASF er nødt til at beskæftige sig med virkelig stor mængde data - hukommelsesbrugen af din foretrukne browser lancering disse to sider vil ikke være nogen lavere end det. Beklager, sådan fungerer det - formindsk antallet af dine badge-sider, og hold antallet af dine lagervarer lavt, hvilket helt sikkert kan hjælpe.

---

## Runtime tuning (avanceret)

Under tricks **involverer nedbrydning af ydeevnen** og bør anvendes med forsigtighed.

Den anbefalede måde at anvende disse indstillinger på er gennem `DOTNET_` miljøegenskaber. Selvfølgelig kan du også bruge andre metoder, f.eks. `runtimeconfig. son`, men nogle indstillinger er umulige at indstille på denne måde, og oven i denne ASF vil erstatte din brugerdefinerede `runtimeconfig. Søn` med sine egne på den næste opdatering, derfor anbefaler vi miljøegenskaber, som du nemt kan indstille før start af processen.

.NET runtime giver dig mulighed for at **[finjustere garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** på mange måder, effektivt finjustere GC-processen i henhold til dine behov. Vi har dokumenteret nedenstående egenskaber, der er særligt vigtige efter vores mening.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Angiver den tilladte brug af GC heap som en procentdel af den samlede fysiske hukommelse.

Den "hårde" hukommelse grænse for ASF proces, denne indstilling tuner GC til at bruge kun en delmængde af den samlede hukommelse og ikke det hele. Det kan blive særligt nyttigt i forskellige server-lignende situationer, hvor du kan dedikere en fast procentdel af serverens hukommelse til ASF, men aldrig mere end det. Vær opmærksom på, at begrænsning af hukommelse til ASF til brug ikke vil magisk gøre alle de krævede hukommelse allokeringer gå væk, at sætte denne værdi for lav kan resultere i at løbe tør for hukommelsesscenarier, hvor ASF-processen vil blive tvunget til at ophøre.

På den anden side, indstilling af denne værdi høj nok er en perfekt måde at sikre, at ASF aldrig vil bruge mere hukommelse end du realistisk har råd til, giver din maskine nogle vejrtrækning værelse selv under tung belastning, samtidig med at programmet til at gøre sit arbejde så effektivt som muligt.

### [`GCConserveMemory`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Konfigurerer skrald opkøber at spare hukommelse på bekostning af hyppigere skrald samlinger og muligvis længere pausetider.

En værdi mellem 0-9 kan bruges. Jo større værdi, jo mere GC vil optimere hukommelse over ydeevne.

### [`GCHighMemPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Angiver mængden af hukommelse der bruges hvorefter GC bliver mere aggressiv.

Denne indstilling konfigurerer hukommelsestærsklen for hele dit OS, som engang passerede, forårsager GC til at blive mere aggressiv og forsøg på at hjælpe OS sænke hukommelsesbelastningen ved at køre mere intensiv GC-proces og i resultatet frigive mere fri hukommelse tilbage til operativsystemet. Det er en god idé at indstille denne ejendom til maksimal mængde hukommelse (som procentdel), som du anser for "kritisk" for hele din OS ydeevne. Standard er 90%, og som regel ønsker du at holde det i 80-97% interval, da for lav værdi vil forårsage unødvendig aggression fra GC og forringelse af ydeevnen uden grund, mens for høj værdi vil lægge unødvendig belastning på dit operativsystem, overvejer ASF kunne frigive nogle af sin hukommelse til at hjælpe.

### **[`GCLatencyLevel`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Angiver det GC latensniveau, du vil optimere for.

Dette er ikke dokumenteret egenskab, der viste sig at fungere usædvanligt godt for ASF ved at begrænse størrelsen af GC-generationer og dermed gøre GC rense dem oftere og mere aggressivt. Standard (balanceret) latensniveau er `1`, men du kan bruge `0`, som vil indstille til hukommelsesforbrug.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> Når sat vi trimme den engagerede plads mere aggressivt for den flygtige seg. Dette bruges til at køre mange forekomster af server processer, hvor de ønsker at holde så lidt hukommelse engageret som muligt.

Dette giver lidt forbedring, men kan gøre GC endnu mere aggressiv, når systemet vil være lavt på hukommelse, især for ASF, som gør brug af trådpulje opgaver kraftigt.

---

Du kan aktivere valgte egenskaber ved at indstille passende miljøvariabler. For eksempel, på Linux (shell):

```shell
# Glem ikke at indstille dem, hvis du planlægger at gøre brug af dem
eksportere DOTNET_GCHeapHardLimitPercent=0x4B # 75% som hex
eksport DOTNET_GCHighMemPercent=0x50 # 80% som hex

eksport DOTNET_GCConserveMemory=9
eksport DOTNET_GCLatencyLevel=0
eksport DOTNET_gcTrimCommitOnLowMemory=1

. ArchiSteamFarm # For OS-specifik build
./ArchiSteamFarm.sh # For generisk build
```

Eller på Windows (powershell):

```powershell
# Glem ikke at indstille dem, hvis du planlægger at gøre brug af dem
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% som hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80% som hex

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

. ArchiSteamFarm.exe # For OS-specifik build
.\ArchiSteamFarm.cmd # For generisk build
```

Især `GCLatencyLevel` vil komme meget nyttigt, da vi bekræftede, at runtime faktisk optimerer kode til hukommelse og derfor falder gennemsnitlig hukommelsesforbrug betydeligt, selv med server GC. Det er et af de bedste tricks som du kan anvende, hvis du ønsker at sænke ASF hukommelsesforbruget betydeligt uden at nedbryde ydeevnen for meget med `OptimizationMode`.

---

## ASF tuning (intermediær)

Under tricks **involverer alvorlig nedbrydning af ydeevnen** og bør anvendes med forsigtighed.

- Som en sidste udvej, kan du tune ASF for `MinMemoryUsage` via `OptimizationMode` **[global config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**. Læs omhyggeligt dens formål, da dette er alvorlig ydeevne forringelse for næsten ingen hukommelse fordele. Dette er typisk **den sidste ting du ønsker at gøre**, længe efter du går igennem **[runtime tuning](#runtime-tuning-advanced)** for at sikre, at du er tvunget til at gøre dette. Medmindre det er absolut kritisk for din opsætning, modvirker vi at bruge `MinMemoryUsage`, selv i hukommelsesbegrænsede miljøer.

---

## Anbefalet optimering

- Start fra simple ASF setup tricks, brug **[generisk ASF variant](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** og tjek om du måske bare bruger din ASF på en forkert måde, såsom at starte processen flere gange for alle dine bots, eller holde dem alle aktiv, hvis du kun har brug for en eller to for at autostart.
- Hvis det stadig ikke er nok, aktivér alle konfigurationsegenskaber anført ovenfor ved at sætte passende `DOTNET_` miljøvariabler. Især `GCLatencyLevel` tilbyder betydelige runtime forbedringer for lidt omkostninger på ydeevne.
- Hvis selv det ikke hjalp som en sidste udvej aktiveres `MinMemoryUsage` `OptimizationMode`. Dette tvinger ASF til at udføre næsten alt i synkronstof, gør det arbejde meget langsommere, men også ikke stole på tråd pulje til at afbalancere ting ud, når det kommer til parallel udførelse.

Det er fysisk umuligt at mindske hukommelsen yderligere, din ASF er allerede stærkt forringet i form af ydeevne, og du udtømte alle dine muligheder, både kode-kloge og runtime-kloge. Overvej at tilføje nogle ekstra hukommelse til ASF til at bruge, selv 128 MB ville gøre en stor forskel.