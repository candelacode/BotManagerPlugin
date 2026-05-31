# Lavt-minne oppsett

Dette er eksakt motsatt av **[høy-ytelsesoppsett](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup)** og vil vanligvis følge disse tipsene hvis du ønsker å redusere den ASFs minnebruk, for kostnader til reduksjon av samlet ytelse.

---

ASF er ekstremt lettvint på ressurser til definisjon, avhengig av bruken din 128 MB VPS med Linux kan kjøre den, Selv om det går så er lavt er ikke anbefalt og kan føre til ulike problemer. Selv om det er lys, er ASF ikke redd for å be OS om mer minne, hvis slik minne trengs for at ASF skal kunne operere med optimal hastighet.

ASF som en søknad forsøker å bli mest mulig optimalisert og effektiv som også tar i betraktning at ressurser blir brukt under utførelse. Når det gjelder minne, setter ASF seg bedre ut over minnebruk, noe som kan gi midlertidige minnebruk som f.eks. føles oppmerksom på sykler. med kontoer med 3+ merkesider, ettersom ASF vil hente og analysere første side, lese fra det totale antall sider, start deretter henting av oppgave for hver ekstra side, som resulterer i samtidig henting og analyse av gjenværende sider. At "ekstra" minnebruk (sammenlignet med bare et minimum ved operasjon) kan medføre en dramatisk hastighet på utførelsen og den totale ytelsen. for prisen på økt minnebruk som krever for å gjøre alle ting parallelt. Tilsvarende skjer det med alle andre generelle ASF-oppgaver som kan drives parallelt, f.eks. med tolkning av aktive handelstilbud, ASF kan analysere alle disse samtidig, da de er alle uavhengige av hverandre. På toppen av dette vil ASF (C# kjøretid) **ikke** returnere ubrukt minne tilbake til OS umiddelbart etterpå, som raskt kan legge merke til i form av ASF-prosess tar bare mer og mer hukommelse, men (alest) gir aldri det minne tilbake til OS. Det kan være noe personer som allerede er krevende, kanskje mistenker en hukommelseslekkasje, men ikke bekymre deg, alt er å forvente.

ASF er svært godt optimalisert, og utnytter så mye som mulig. Høyt minnebruk av ASF betyr ikke at ASF aktivt **bruker** som minne og **trenger det**. Svært ofte vil ASF beholde tildelt minne som "rom" til fremtidige handlinger. fordi vi kan øke ytelsen drastisk hvis vi ikke trenger å be OS om hver minnedel som vi er i ferd med å bruke. The runtime should automatically release unused ASF memory back to OS when OS will **truly** need it. **[Unused memory is wasted memory](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. Når minnet om **trenger** er mer enn minnet som er tilgjengelig for deg, ikke når ASF holder noen ekstra allokert med tanke på fremskynding funksjoner som vil utføre i et øyeblikk. Du løper til problemer når Linux-kjernen din dreper ASF-prosessen på grunn av OOM (ute av minnet), ikke når du ser ASF-prosess som toppminneforbruker i `på toppen`.

**[Garbage samling](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** -prosessen brukt i ASF er en svært kompleks mekanisme. smart nok til å ta hensyn til ikke selv ASF, men også til OS og andre prosesser. Når du har mye fri hukommelse, vil ASF be om alt som trengs for å forbedre prestasjonen. Dette kan være til og med 1 GB (med server GC). Når OS-minnet er nær full, vil ASF automatisk sende noe av det tilbake til OS for å hjelpe ting å gjøre opp. noe som kan gi totalt sett ASF-minneforbruk så lavt som 50 MB. Forskjellen mellom 50 MB og 1 GB er stor, men så er forskjellen mellom liten 512 MB VPS og stor dedikert server med 32 GB. Hvis ASF kan garantere at dette minnet vil være nyttig, og samtidig at ingenting annet krever det akkurat nå, Ønsker å holde det og automatisk optimalisere seg basert på rutiner som tidligere ble utført. GC som brukes i ASF er selvstyrende, og vil gi bedre resultater når prosessen går lenger.

Derfor varierer ASF-prosessminne fra oppsett til installasjon, og derfor varierer det. siden ASF vil gjøre sitt beste for å bruke tilgjengelige ressurser i **så effektiv som mulig**, og ikke på en fast måte som det ble gjort under Windows XP-tider. Selve (virkelig) minnebruk som ASF bruker kan verifiseres med `stats` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, og er vanligvis rundt 4 MB for bare noen få bots, opptil 30 MB hvis du bruker ting som **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** og andre avanserte funksjoner. Husk at minnet returnert av `statistikk` -kommandoen også inkluderer gratis minne som ikke er gjenvunnet av søppelpost enda. Alt annet er delt runtidsminne (rundt 40-50 MB) og rom for gjennomføring (variert). Dette er også grunnen til at samme ASF kan bruke så lite som 50 MB i et lavminnebasert VPS-miljø. mens du bruker opptil 1 GB på skrivebordet ditt. ASF tilpasser seg aktivt ditt miljø og vil forsøke å finne optimal balanse for verken å sette OS under press, begrense eller begrense egen ytelse når du har mye ubrukt hukommelse som kan bli tatt i bruk.

---

Selvsagt det er mange måter du kan hjelpe til med å peke ASF på riktig retning på i forhold til det du forventer å bruke. Generelt hvis du ikke trenger å gjøre det, det er best å la søppeltønstrere arbeide i fred, og gjøre det som kjennes best. Men dette er ikke alltid mulig, for eksempel hvis din Linux-server også er vert for flere nettsteder, MySQL database og PHP arbeidstakere, så kan du ikke virkelig ha råd til ASF og krympe seg selv når du kjører nær OOM, da det vanligvis er for sent og ytelsesforringelse kommer raskere. Dette er vanligvis når du vil være interessert i å styre seg videre, og dermed lese denne siden.

Under er forslag delt inn i noen få kategorier, med varierte vanskeligheter.

---

## ASF oppsett (lett)

Under triks **påvirker ikke ytelsen negativt** og kan brukes trygt på alle oppsett.

- Kjør **[generisk versjon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** av ASF hvis mulig. Generisk versjon av ASF bruker mindre minne siden den ikke inneholder innebygd kjøretid, ikke kommer som én fil, ikke trenger å pakke ut på rad, og er derfor mindre og har mindre hukommelse. OS-spesifikke pakker er praktiske og mulige, men de samles også med alt som trengs for å lansere ASF, som du kan ta vare på deg selv og bruke generisk ASF-variant i stedet.
- Kjør aldri mer enn én ASF-instans. ASF er ment å håndtere ubegrenset antall bots alt til én gang, og med mindre du binder hver ASF-forekomst til forskjellig grensesnitt/IP-adresse, du må ha nøyaktig **en** ASF-prosess med flere bots (hvis nødvendig).
- Gjør bruk av `ShutdownOnFarmingFinished` i bot's `FarmingPreferences`. Active bot bruker mer ressurser enn deaktivert. Det er ikke en vesentlig sparing ettersom tilstanden til boten fortsatt må sitte der. men du sparer litt ressurser spesielt alle ressurser relatert til nettverk, slik som TCP-kontakter. Du kan alltid ta med andre bots hvis nødvendig.
- Hold botten nummeret lavt. Not `Enabled` bot instance takes less resources, as ASF doesn't bother starting it. Also keep in mind that ASF has to create a bot for each of your configs, therefore if you don't need to `start` given bot and you want to save some extra memory, you can temporarily rename `Bot.json` to e.g. `Bot.json.bak` in order to avoid creating state for your disabled bot instance in ASF. This way you won't be able to `start` it without renaming it back, but ASF also won't bother keeping state of this bot in memory, leaving room for other things (very small save, in 99.9% cases you shouldn't bother with it, just keep your bots with `Enabled` of `false`).
- Fullfør konfigurasjonene dine. Spesielt global ASF config har mange variabler å justere, for eksempel ved å øke `LoginLimiterDelay` vil du ta med din bots tregere, som vil tillate allerede startet forekomst å hente distinksjoner i mellomtiden, i motsetning til å få opp boten din raskere, som vil ta mer ressurser når flere botter vil gjøre større arbeid (slik som parkeringsdistinksjoner) samtidig. Den mindre jobben som må gjøres samtidig - det blir brukt mindre minne.

Det er et par ting du kan ha i tankene når du håndterer minnebruken. De tingene har imidlertid ikke noen "korsorial" rolle på hukommelsesbruk, fordi minnebruk hovedsakelig kommer fra ting ASF må forholde seg til, og ikke fra intern struktur som brukes på kortparkering.

De mest ressurskrevende funksjonene er:
- Merke side analysering
- Tolkning av inventar

Hvilken betyr at minne vil samle mest når ASF arbeider med å lese distinksjoner, og når det har å gjøre med inventaret (e. e. . sende handel eller arbeid med STM). Dette fordi ASF må håndtere virkelig store mengder data - minnebruken av favoritt-nettleseren din som åpner disse to sidene vil ikke være lavere enn det. Beklager, det er slik det fungerer - reduser antall distinksjoner, og behold antall av inventaret ditt lavt, så kan du få hjelp.

---

## Runtime tuning (avansert)

Under triksene **involverer ytelsesnedbrytning** og bør brukes med forsiktighet.

Anbefalt måte å bruke disse innstillingene på er gjennom `DOTNET_` miljøegenskaper. Du kan selvsagt også bruke andre metoder, f.eks. `runtimeconfig. sønn`, men noen innstillinger kan ikke velges på denne måten. og oppå den ASF vil erstatte din egendefinerte `runtimeconfig. sønn` med egen oppdatering som kan, derfor anbefaler vi miljøegenskaper som du enkelt kan sette før prosessen starter.

.NET kjøretid tillater deg til **[å justere søppelpost](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** på mange måter effektiv finstyring av GC-prosessen i henhold til dine behov. Vi har dokumentert under egenskaper som er spesielt viktige etter vår vurdering.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Spesifiserer tillatt GC-haug-bruk som en prosentandel av det fysiske minnet.

"hard" minne grense for ASF-prosess, denne innstillingen retter GC til å bare bruke en undergruppe av totalt minne og ikke alt. Det kan bli spesielt nyttig i ulike serverlignende situasjoner der du kan dedikere en fast prosentandel av serverens minne for ASF, men aldri mer enn det. Vær oppmerksom på at begrensende minne for ASF som skal brukes, ikke vil på en magisk måte gjøre alle plasser til minne igjen. Når denne verdien er for lav, vil det derfor kunne føre til at ASF-prosessen går inn i minnemoduser, hvor ASF-prosessen vil bli tvunget til å avslutte.

På den andre hånden å sette denne verdien høy nok er en perfekt måte å sikre at ASF aldri vil bruke mer minne enn du kan realistisk etterpå, som gir maskinen litt pusterom selv under kraftig belastning, mens programmet fremdeles gjør jobben så effektivt som mulig.

### [`GCConserveMemory`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Konfigurerer garasjesamleren til å holde minnet over bekostning av hyppigere garasjesamlinger og muligens lengre pausetider.

En verdi mellom 0-9 kan brukes. Jo større verdi, desto mer GC vil optimalisere minnet med ytelse.

### [`GCHighMemPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Angir mengden minne som blir brukt hvorfor. GC blir mer aggressiv.

Denne innstillingen konfigurerer minnegrensen til hele OSet, som så ble passert, får GC til å bli mer aggressiv og forsøke å hjelpe OS til å redusere minnebruken ved å drive mer intensiv GC-prosess og føre til at friere minne frigjøres til OS. Det er en god idé å sette denne egenskapen til maksimal mengde minne (som prosentandel) som du anser som "kritisk" for hele din OS-ytelse. Standard er 90 %, og du ønsker å beholde den innen 80–97 %, siden for lav verdi av null vil forårsake unødvendig aggresjon fra GC og ytelsesforringelse av ingen grunn, Selv om for høy verdi vil sette unødvendig belastning på OSS ditt, vurderer dette å gi ASF noe av minnet om hjelpen.

### **[`GCLatyNivå`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Spesifiserer GC latensnivå som du vil optimalisere for.

Dette er udokumentert eiendom som viste seg å fungere usedvanlig godt for ASF, ved å begrense størrelsen på GC-generasjoner og føre til at GC-generasjonene renser dem oftere og mer aggressivitet. Standard (saldo) latensnivå er `1`, men du kan bruke `0`som vil takke for minnebruk.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> Når vi setter målingen av fellesskapet mer aggressivt for flytiden Dette brukes til å kjøre mange forekomster av serverprosesser der de vil ha så lite minne forbegått som mulig.

Dette gir liten forbedring, men kan gjøre GC enda mer aggressiv når systemet vil ligge lavt i minnet, spesielt for ASF som bruker oppgaver som gjengebassenget i stor grad.

---

Du kan aktivere valgte egenskaper ved å sette riktige miljøvariabler. For eksempel, på Linux (skall):

```shell
# Ikke glem å stemme de hvis du planlegger å bruke
eksportere DOTNET_GCHeapHardLimit5%) =0x4B # 75% som hex
eksport DOTNET_GCHighMemaris =0x50 # 80% som hex

eksport DOTNETTNET_GCConserveMemory=9
eksport DOTNET_GCLatencyLevel=0
export DOTNETNET_gcTrimCommitOnMemory=1

ArchiSteamFarm # For OS-spesifikk versjon
./ArchiSteamFarm.sh # For generisk bygg
```

Or on Windows (powershell):

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

Spesielt `GCLatencyLevel` vil komme svært nyttig da vi bekreftet at kjøretiden faktisk optimaliserer kode for minne og dermed dermed kunne brukes betydelig. til og med server GC. Det er et av de beste triksene du kan bruke om du vil redusere ASF-minnebruken betydelig, samtidig som du ikke bryter ned ytelsen med `OptimalisationMode`.

---

## ASF-justering (mellomlig)

Nedenfor triks **involverer alvorlig ytelsesforringelse** og bør brukes med forsiktighet.

- Som en siste utvei, kan du finjustere ASF for `MinMemoryUsage` gjennom `OptimizationMode` **[global konfigurasjon-egenskap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**. Les nøye dette formål, siden dette er en alvorlig ytelsesnedbrytning for nesten ingen minnegevinster. Dette er vanligvis **det siste du vil gjøre**, lenge etter at du har gått gjennom **[rulletidsjustering](#runtime-tuning-advanced)** for å forsikre deg om at du er tvunget til å gjøre dette. Med mindre vi helt kritisk for oppsettet ditt, fraråder vi å bruke `MinMemoryusage`, selv i minnebegrensende omgivelser.

---

## Anbefalt optimalisering

- Start på enkle ASF-oppsetttriks bruk **[generisk ASF-variant](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** og sjekk om du kanskje bare bruker ASF på feil måte, som starter prosessen flere ganger for alle dine boter, eller holde alle aktive, hvis du trenger bare en eller to for å autostarte.
- Hvis det fortsatt ikke er nok, aktiver alle konfigurasjonsegenskapene ovenfor ved å sette passende `DOTNET_` miljøvariabler. Spesielt `GCLatencyLevel` tilbyr betydelige kjøretidsforbedringer for lite kostnader på ytelse.
- Hvis selv det ikke hjalp som siste gang du aktiverer `MinMemoryUsage` `OptimizationMode`. Dette tvinger ASF til å utføre nesten alt i synkront materiale, å få den til å fungere mye langsommere men også å basere seg på gjengepoolen på å balansere ting når det gjelder parallell gjennomføring.

Det er fysisk umulig å redusere minnet enda lengre, Ditt ASF er allerede hardt nedbrutt når det gjelder fremføring, og du tar ut alle dine muligheter, både samtidig med klok og med klok. Vurder å legge til ekstra minne for ASF som skal brukes, selv 128 MB vil utgjøre en stor forskjell.