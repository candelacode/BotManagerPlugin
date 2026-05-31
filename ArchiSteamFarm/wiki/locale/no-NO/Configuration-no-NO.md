# Konfigurasjon

Denne siden er dedikert for ASF-konfigurasjon. Den fungerer som en fullstendig dokumentasjon av `config` mappen, slik at du kan finjustere ASF etter dine behov.

* **[Introduksjon](#introduction)**
* **[Web-basert konfigurator](#web-based-configgenerator)**
* **[ASF-ui konfigurasjon](#asf-ui-configuration)**
* **[Manuell konfigurasjon](#manual-configuration)**
* **[Global konfigurasjon](#global-config)**
* **[Bot config](#bot-config)**
* **[Fil struktur](#file-structure)**
* **[JSON mapping](#json-mapping)**
* **[Kartlegging av kompatibilitet](#compatibility-mapping)**
* **[Configs kompatibilitet](#configs-compatibility)**
* **[Auto-last på nytt](#auto-reload)**

---

## Introduksjon

ASF-konfigurasjonen er delt i to hoveddeler - global (prosess) konfigurasjon og konfigurasjon av hver bot. Hver bot har sin egen bot konfigurasjonsfil som heter `BotName. sønn` (hvor `BotName` er navnet på boten), mens global ASF (prosess) konfigurasjon er en enkelt fil som heter `ASF. sønn`.

En bot er en enkelt dampdel som tar del i ASF-prosessen. For å fungere skikkelig, trenger ASF minst **en** definert bothandelsinstans. Det er ingen prosessbetinget grense for bot instanser, så du kan bruke så mange botter (dampkontoer) som du vil.

ASF bruker **[JSON](https://en.wikipedia.org/wiki/JSON)** format for lagring av sine konfigurasjonsfiler. Det er et menneskevennlig, lesbart og meget universelt format som du kan konfigurere programmet. Ikke bekymre deg, du trenger ikke å vite JSON for å konfigurere ASF. Jeg nevnte nettopp det dersom du allerede ønsker å massere ASF konfigurerer seg med en slags grunnleggende skript.

Konfigurasjonen kan gjøres på flere måter. Du kan bruke vår **[Web-basert Configator](https://justarchinet.github.io/ASF-WebConfigGenerator)**, som er en lokal app uavhengig av ASF. Du kan bruke våre **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC frontend for konfigurasjon gjort direkte i ASF. Til slutt kan du alltid generere konfigurasjonsfiler manuelt, da de følger en fast JSON-struktur spesifisert nedenfor. Vi vil forklare kort tid de tilgjengelige alternativene.

---

## Web-basert konfigurator

Hensikten med vår **[Web-baserte Configator](https://justarchinet.github.io/ASF-WebConfigGenerator)** er å gi deg en vennlig frontend som brukes til å generere ASF-konfigurasjonsfiler. Web-basert ConfigGenerator er 100% klientbasert, noe som betyr at detaljene du sender inn ikke sendes hvor som helst, men behandles lokalt. Dette garanterer sikkerhet og pålitelighet, siden det kan til og med arbeide **[frakoblet](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** hvis du ønsker å laste ned alle filene og kjøre `indeksen. tml` i din favoritt-nettleser.

Web-basert ConfigGenerator er verifisert for å kjøre riktig på Chrome og Firefox, men bør fungere riktig i alle de mest populære nettleserne for javascript-aktivert.

Bruken er ganske enkelt - velg om du vil generere `ASF` eller `Bot` konfigurasjon ved å bytte til riktig fane, sørge for at valgte versjon av konfigurasjonsfilen samsvarer med ASF-frigivelsen, deretter legg inn alle detaljer og trykk "nedlasting" knappen. Flytt denne filen til ASF `config` mappen, og skriv over eksisterende filer hvis nødvendig. Gjenta for alle mulige ytterligere endringer og se resten av denne delen for forklaring av alle tilgjengelige alternativer for å konfigurere.

---

## ASF-ui konfigurasjon

Vårt **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC grensesnitt lar deg konfigurere ASF også, og er overlegen løsning for å konfigurere ASF etter å ha generert de første konfigurasjonene på grunn av at det er mulig å redigere konfigurasjonene på plass, i motsetning til den nettbaserte konfiguratoren, som genererer dem statisk.

For å bruke ASF-ui må du ha vårt **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** grensesnitt aktivert selv. `IPC` er aktivert som standard, derfor kan du bruke den med en gang, så lenge du ikke har deaktiver den selv.

Etter å ha lansert programmet, bare navigerer du til ASF's **[IPC adresse](http://localhost:1242)**. Hvis alt fungerer ordentlig, kan du endre ASF-konfigurasjon derfra.

---

## Manuell konfigurasjon

Generelt anbefaler vi sterkt å bruke enten vår ConfigGenerator eller ASF-ui, siden det er mye enklere og sikrer at du ikke vil gjøre en feil i JSON-strukturen, men hvis du av en eller annen grunn ikke vil det, kan du også opprette riktige konfigurasjoner manuelt. Sjekk JSON-eksemplene nedenfor for en god start i riktig konstruksjon. du kan kopiere innholdet til en fil og bruke det som et grunnlag for konfigurasjonen. Siden du ikke bruker noen av våre nettsider, sørg for at konfigurasjonen er **[gyldig](https://jsonlint.com)**, Hvis ASF ikke kan leses inn da ASF nektes å laste den igjen. Selv om det er en gyldig JSON, må du også forsikre deg om at alle egenskapene har riktig type, som krevd av ASF. For riktig JSON-struktur for alle tilgjengelige felter, se **[JSON tilordning](#json-mapping)** og vår dokumentasjon nedenfor.

---

## Global konfigurasjon

Global config er lokalisert i `ASF.json` -filen og har følgende struktur:

```json
{
    "AutoRestart": sant,
    "Blacklist": [],
    "CommandPrefix": "! ,
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "Nåværende": null,
    "Debug": false,
    "Standardbot": null,
    "FarmingDelay": 15,
    "FilterBadBots": sann,
    "GiftsLimiterDelay": 1,
    "Hodefri": false,
    "IdleFarmingPerio": 8,
    "InventoryLimiterDelay": 4,
    "IPC": true,
    "IPCPassword": null,
    "IPCPasswordFormat": 0,
    "Lisens-ID": null,
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldation": 15,
    "MinFarmingDelayAfterBlock": 60,
    "OptimaliseringMode": 0,
    "PluginsUpdateList": [],
    "PluginsUpdateMode": 0,
    "ShutdownIfPossible": false,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Alle alternativer er forklart nedenfor:

### `AutoOmstart`

`bool` type with default value of `true`. Denne egenskapen definerer hvis ASF er lov til å foreta en selvomstart ved behov. Det er noen hendelser som krever fra ASF en selvstart som ASF-oppdatering (ferdig med `UpdatePeriod` eller `oppdatere` kommandoen, samt `ASF. son` konfigurasjon, `starter` -kommando og på samme måte. Ofte inkluderer omstart to deler - oppretting av ny prosess og fullføring av gjeldende prosess. De fleste brukere burde være fine med den og beholde denne egenskapen med standardverdien `true`, derimot – hvis du kjører ASF gjennom ditt eget skript og/eller med `dotnet`, det kan hende du ønsker å ha full kontroll over å starte prosessen, og unngå en situasjon som å ha en ny (gjenoppstartet) ASF-prosess som har et sted i bakgrunnen som det er stille stille og ikke i forgrunnen til statsskriveren, men de drev sammen med gamle ASF-prosesser. Dette er spesielt viktig med tanke på at den nye prosessen ikke lenger vil være ditt direkte barn, noe som gjør at du ikke klarer å gjøre det. . for å bruke standard konsoll inngang for den.

Hvis det er tilfellet, denne egenskapen hvis spesielt for deg og du kan sette den til `false`. Husk imidlertid at **du** er ansvarlig for å starte prosessen på nytt. Dette er på noen vis viktig siden ASF bare vil gå ut i stedet for å sette i gang nye prosesser (f.eks. etter oppdatering), så hvis det ikke er logisk lagt til av deg, vil det bare slutte å fungere før du starter den igjen. ASF utelater alltid med riktig feilkode som indikerer suksess (null) eller ikke suksess (ikke-null), denne måten du kan legge til riktig logikk i skriptet ditt som bør unngå automatisk omstart av ASF hvis det skulle oppstå feil. eller i det minste lage en lokal kopi av `log. xt` for videre analyse. Also keep in mind that `restart` command will always restart ASF regardless of how this property is set, as this property defines default behaviour, while `restart` command always restarts the process. Med mindre du har en grunn til å deaktivere denne funksjonen, bør du beholde den aktivert.

---

### `Svarteliste`

`ImmutableHashSet<uint>` typen med standardverdien for å være tom. Som navnet antyder, definerer denne globale konfigurasjonsegenskapen appIDs (spill) som vil bli helt ignorert ved automatisk ASF-oppdrett. Dessverre elsker Steam å flagge sommer / vintersalg av skilt som "tilgjengelige for kortfall", som forvirrer ASF-prosessen ved å få det til å tro at det er et gyldig spill som skal fares. Skulle det ikke finnes noen form for svarteliste, ville ASF til slutt "hang" på oppdrett et spill som faktisk ikke er et spill, og vent uendelig på kortdråpe som ikke vil skje. ASF-svartelisten tjener som formål å merke disse merkene, som ikke er tilgjengelig for jordbruk, så vi kan stille bort fra dem når vi bestemmer hva vi skal parre seg, og ikke falle i fellen.

ASF inkluderer to svartelister som standard - `SalesBlacklist`, som er hardkodet inn i ASF-koden og ikke mulig å redigere, og normal `svarteliste`, som er definert her. `SalesBlacklist` oppdateres sammen med ASF versjon og inkluderer vanligvis alle "dårlige" apper på frigivelsestidspunktet, så hvis du bruker oppdatert ASF da trenger du ikke å opprettholde din egen `svarteliste` definert her. Hovedformålet med denne egenskapen er å gjøre deg i stand til å svarteliste ny, intet kjent på tidspunktet for ASF-lanseringsapIDer, som ikke skal fares. Herdet `SalesBlacklist` blir oppdatert så fort som mulig. derfor er det ikke nødvendig å oppdatere din egen `svarteliste` hvis du bruker siste ASF versjon, men uten `svarteliste` du måtte ha blitt tvunget til å oppdatere ASF for å "fortsette å gå" når Radiatortermostaten utgir nytt salgsmerke - Jeg vil ikke tvinge deg til å bruke siste ASF-kode, Derfor er denne eiendommen her for å tillate deg å «fiksere» ASF deg selv hvis du av en eller annen grunn ikke ønsker det, eller ikke kan oppdatering til nye hardkodet `SalesBlacklist` i ny ASF-utgivelse, men du ønsker likevel å holde din gamle ASF kjørende. Med mindre du har en **sterk** grunn til å redigere denne egenskapen, bør du beholde den som standard.

Hvis du leter etter bot-basert svarteliste i stedet, ta en titt på `fb`, `fbadd` og `fbrm` **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `Kommandoprefiks`

`string` type with default value of `!`. Denne egenskapen spesifiserer **case-sensitive** prefiks for ASF **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Dette er med andre ord hva du må forberede til hver ASF-kommando for å få ASF til å lytte til deg. Det er mulig å sette denne verdien til `null` eller tom for å gjøre ASF uten kommando prefiks, i så fall legger du inn kommandoer med sin ren identifikatorer. Men gjør det mulig å redusere ASFs ytelse fordi ASF er optimalisert for å ikke analysere melding ytterligere hvis den ikke starter med `CommandPrefix` - hvis dere med vilje bestemmer å ikke bruke den, ASF vil bli tvunget til å lese alle meldinger og svare på dem, selv om de ikke er ASF-kommandoer. Derfor anbefales det å fortsette å bruke noen `CommandPrefix`, for eksempel `/` hvis du ikke liker standardverdien `!`. For konsistens, `CommandPrefix` påvirker hele ASF-prosessen. Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

### `ConfirmationsLimiterDelay`

`byte` type with default value of `10`. ASF vil sørge for at det blir minst `ConfirmationsLimiterDelay` sekunder mellom to påfølgende 2FA bekreftelser som henter forespørsler for å unngå at rate-limit utløses – de brukes av **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** under e. . `2faok` -kommando, så vel som nødvendig når man utfører ulike handelsrelaterte operasjoner. Standardverdien ble satt basert på testene våre og bør ikke senkes hvis du ikke vil kjøre på problemer. Med mindre du har en **sterk** grunn til å redigere denne egenskapen, bør du beholde den som standard.

---

### `Tidsavbrudd for tilkobling`

`byte` type med standardverdien for `90`. Denne egenskapen definerer timeouts for ulike nettverkshandlinger utført av ASF, i sekunder. Spesielt definerer `ConnectionTimeout` timeout i sekunder for HTTP og IPC forespørsler, `TilkoblingsTidsavbrudd / 10` definerer maksimalt antall mislykkede hjerteslag, mens `ConnectionTimeout / 30` definerer antall minutter vi tillater innledende tilkoblingsforespørsel for Steam nettverksforbindelse. Standardverdien for `90` bør være fin for de fleste personer, men hvis du har litt treg nettverkstilkobling eller PC, du kanskje ønsker å øke dette tallet til noe høyere (som `120`). Husk at større verdier ikke vil på magisk vis rette opp trege eller til og med utilgjengelige Steam-servere, så vi skulle ikke vente på noe som ikke skjer, og bare prøv på nytt senere. Ved å sette for høy verdi vil det føre til for stor forsinkelse i fangstproblemene i nettverket, samt reduksjon av samlet ytelse. Ved å sette for lav verdi vil også områdestabilitet og ytelse reduseres, da ASF også vil avbryte en gyldig forespørsel fortsatt. Derfor har ikke denne verdien lavere enn standard noen fordel generelt. siden Steam-servere ofte vil være saktere fra tid til annen, og kan kreve mer tid for å analysere ASF-forespørsler. Standardverdi er en balanse mellom en tro om at nettverksforbindelsen vår er stabil, og tviler i Steam-nettverket for å håndtere vår forespørsel i angitt tid. Hvis du ønsker å oppdage problemer raskere og gjøre ASF-gjentilkobling/-svar raskere, standardverdien bør gjøre (eller svært svakt under, som `60`, noe som gjør ASF mindre pasient). Hvis du i stedet merker at ASF går inn i nettverksproblemer, for eksempel mislykket forespørsler, hjerteslag som går tapt eller tilkobling til Steam avbrutt, det er sannsynligvis fornuftig å øke denne verdien hvis du er sikker på at det er **ikke** forårsaket av nettverket ditt, Men ved Steam selv, da tidsavbrudd øker blir ASF mer «pasient» og avgjør ikke å koble til med en gang.

Et eksempel på en situasjon som kan kreve at denne eiendommen får ASF til å forholde seg til et meget enorm handelstilbud som kan ta drøyt 2+ minutter å akseptere og håndteres av Steam. Ved økende standard tidsavbrudd, ASF blir pasienten mer og venter lenger før avgjørelsen om at handelen ikke går gjennom og avgir den opprinnelige forespørselen.

En annen situasjon kan være forårsaket av svært lav maskin eller Internett-tilkobling som krever mer tid for å håndtere dataene som skal overføres. Dette er ganske sjelden kondisjon, siden CPU/nettverksbåndbredde nesten aldri er en flaskehals, men det er fortsatt en mulighet å nevne.

Kort sagt må standardverdien være anstendig i de fleste tilfeller, men du kan ønske å øke den ved behov. Men å gå langt over standardverdien gjør heller ikke mye mening, siden større tidsavbrudd vil på magisk vis ikke fikse utilgjengelige Steam-tjenere. Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

### `NåleKultur`

`string` type with default value of `null`. Som standard vil ASF forsøke å bruke operativsystemets språk og foretrekke å bruke oversatte strenger hvis dette språket er tilgjengelig. Dette er mulig takket være vårt samfunn som prøver **[lokaliserer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** ASF på alle mest populære språk. Hvis du av en eller annen grunn ikke ønsker å bruke ditt OS-morsmål du kan bruke denne konfigurasjonsegenskapen til å velge et gyldig språk du ønsker å bruke i stedet. For en liste over alle tilgjengelige kulturer, besøk **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** og se etter `Språk tag`. Det er fint å notere at ASF aksepterer begge spesifikke kulturer, som `"nb-NOB"`, men også nøytrale som `"en"`. Spesifiser gjeldende kultur vil også påvirke annen kulturspesifikk oppførsel, som valuta/datoformat og lik. Vær oppmerksom på at du kan behøve ytterligere skrifttype/språkpakker for å vise språkspesifikke tegn, hvis du har valgt en ikke-stedlig kultur som gjør bruk av dem. Vanligvis vil du bruke denne konfigurasjonsegenskapen hvis du foretrekker ASF på engelsk i stedet for ditt morsmål.

---

### `Debug`

`bool` type with default value of `false`. Denne egenskapen definerer om prosessen skal kjøre under feilsøkingsmodus. Når i feilsøkingsmodus oppretter ASF en spesiell `debug` mappe ved siden av `config`, som holder styr på all kommunikasjon mellom ASF og Steam-servere. Debug informasjon kan hjelpe med å oppdage stygge problemer relatert til nettverk og generell ASF-arbeidsflyt. I tillegg vil det være langt mer ordner noen programrutiner, for eksempel `WebBrowser` som oppgir nøyaktig grunn til at noen forespørsler feiler - disse oppføringene er skrevet i normal ASF-logg. **Du bør ikke kjøre ASF i Debug modus, med mindre du blir spurt av utvikler**. Running ASF in debug mode **decreases performance**, **affects stability negatively** and is **far more verbose in various places**, so it should be used **only** intentionally, in short-run, for debugging particular issue, reproducing the problem or getting more info about a failing request, and alike, but **not** for normal program execution. Du vil se **mye** av nye feil, problemer. og unntak – sørg for at du har anstendig kunnskap om ASF, Steam og kva for å analysere alt av sjølv selv, siden ikkje alt er relevant.

**ADVARSEL:** aktivering av denne modusen inkluderer logging av **potensielt følsom** -informasjon som påloggingsinformasjon og passord som du bruker for innlogging til å logge inn på Steam (på grunn av nettverkslogging). Den dataene er skrevet til både `debug` og til standard `log. xt` (som nå med hensikt ordner mye mer for å logge denne informasjonen). Du bør ikke skrive feilsøk innhold generert av ASF på noen offentlig sted, ASF-utvikleren bør alltid påminne deg om å sende den til e-posten, eller andre sikre steder. Vi lagrer ikke og bruker ikke disse sensitive detaljene, De er skrevet som en del av feilsøkingsrutinene ettersom deres tilstedeværelse kan være relevant for problemet som påvirker deg. Du bør gjerne foretrekke hvis du ikke endret ASF-logging på noen måte, men hvis du er bekymret, kan du gjøre disse følsomme detaljene riktig opp på nytt.

> Redacting innebærer å erstatte sensitive detaljer, for eksempel med stjerner. Du bør avstå fra å fjerne følsomme linjer i sin helhet, da det kan være relevant og bør ivaretas.

---

### `Standard^Bot`

`string` type with default value of `null`. I noen scenarioer ASF fungerer med et konsept en standard bot som er ansvarlig for å håndtere noe - for eksempel IPC kommandoer eller interaktiv konsoll når du ikke angir målbot. Denne egenskapen lar deg velge standard bot ansvarlig for å håndtere slike scenarier, ved å sette `BotName` her. Hvis angitt bot ikke eksisterer, eller du bruker en standardverdi for `null`, vil ASF velge første registrerte bot sortert alfabetisk i stedet. Typisk vil du bruke denne konfigurasjonsegenskapen hvis du vil utelate `[Bots]` argument i IPC og interaktive konsoll kommandoer, og alltid velg samme bot som den som er standard for slike samtaler.

---

### `FarmingDelay`

`byte` type with default value of `15`. For at ASF skal fungere, sjekker det for øyeblikket Oppdrettsspillet `FarmingDelay` minutter, hvis det kanskje hadde kuttet alle kortene allerede. Hvis denne egenskapen er for lav, kan det føre til at mye dampforespørsler blir sendt, mens du setter det for høyt kan føre til en "gård" fortsatt "gård" gitt tittelen for opp til `FarmingDelay` minutter etter at den er helt oppbrukt. Standard verdi må være utmerket for de fleste brukere, men hvis du har mange bots kjører, du kan vurdere å øke den til noe som f.eks. `30` minutter for å begrense dampforespørsler som sendes. Det er fint å legge merke til at ASF bruker hendelsesbasert mekanisme og kontrollerer spillemblemet på hver Steam-gjenstand som er droppet, så generelt i **trenger vi ikke engang sjekke det i faste tidsintervaller**, men siden vi ikke stoler på Steam-nettverk helt på - sjekker spillemblemsiden likevel, hvis vi ikke sjekker den gjennom kortfallet hendelsen i siste `FarmingDelay` minutter (dersom ikke Steam-nettverket informerte oss om at varen var droppet eller ting som detat). Forutsatt at Steam-nettverket fungerer som det skal, vil ikke redusere verdien **forbedre jordbrukseffektivitet på noen måte**, mens **øker nettverkets overhode signifikant** - det anbefales kun å øke den (hvis nødvendig) fra standard `15` minutter. Med mindre du har en **sterk** grunn til å redigere denne egenskapen, bør du beholde den som standard.

---

### `Filteremblemer`

`bool` type with default value of `true`. Kjennetegn som definerer hvorvidt ASF automatisk vil redusere tilbud mottatt fra kjente og markerte dårlige aktører. For å gjøre det, vil ASF kommunisere med vår server som nødvendig for å hente en liste over svartelistede Steam-identifikatorer. The bots listed are operated by people that are classified as harmful towards ASF initiative by us, such as those that violate our **[code of conduct](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, use provided functionality and resources by us such as **[`PublicListing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** in order to abuse and exploit other people, or are doing outright criminal activity such as launching DDoS attacks on the server. Siden ASF har et sterkt utgangspunkt for allmenn rettferdighet, ærlighet og samarbeid mellom brukerne for å gjøre hele samfunnet til fly, Denne egenskapen er aktivert som standard, og derfor ASF filtrerer bots som vi har klassifisert som skadelige for tjenester som tilbys. Med mindre du har en **sterk** grunn til å redigere denne egenskapen, slik som uenig i vårt utsagn og med hensikt å la botene operere (inkludert utnyttelse av dine kontoer), bør du holde den til standard.

---

### `GiftsLimiterDelay`

`byte` type with default value of `1`. ASF vil sikre at minst `GiftsLimiterDelay` sekunder mellom to påfølgende gave/nøkkel/lisenshåndtering (innløsning) forespørsler for å unngå å utløse rate-grense. I tillegg til at dette også vil bli brukt som global grenseverdi for spilllisteforespørsler, som den som er utstedt av `eier` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Med mindre du har en **sterk** grunn til å redigere denne egenskapen, bør du beholde den som standard.

---

### `Hodeløs`

`bool` type with default value of `false`. Denne egenskapen definerer om prosessen skal kjøre i hodeløs modus. Når hodeløs modus forutsetter ASF at den kjører på en server eller i et annet ikke-interaktivt miljø derfor vil den ikke forsøke å lese informasjon gjennom konsoll innlegg. Dette inkluderer informasjon om din registrering (konto som 2FA-kode, SteamGuard kode, passord eller enhver annen variabel som kreves for at ASF skal fungere) så vel som alle andre konsoll inndata (som interaktiv kommandolonsolgt). Med andre ord er `Headless` -modus lik å gjøre ASF-konsoll skrivebeskyttet. Denne innstillingen er hovedsakelig nyttig for brukere som kjører ASF på sine servere, i stedet for å spørre etter det. . For 2FA kode vil ASF stille stille driften, ved å stoppe en konto. Med mindre du kjører ASF på en server, og du tidligere bekreftet at ASF er i stand til å operere uten headless modus, du bør ikke holde denne egenskapen deaktivert. All brukerinteraksjon vil bli avvist når brukeren er i hodeløs modus, og kontoene dine kjøres ikke hvis de krever **hvilken som helst** konsoll inngang under start. Dette er nyttig for servere, siden ASF kan avbryte og logge seg på kontoen når du spør om legitimasjoner, i stedet for å vente (infinitelt) til brukeren skal foreskrive disse.

Aktivering av denne modusen lar deg levere nødvendige konsollinndata via andre måter, dvs. ASF-ui (ASF API), eller gjennom **[`input`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#input-command)** kommandoen. Hvis du ikke er sikker på hvordan du angir denne egenskapen, la den med standardverdien av `false`.

---

### `IdleFarmingPeriod`

`byte` type with default value of `8`. Når ASF ikke har noe å dyrke, vil det periodisk sjekke hver `IdleFarmingPeriod` timer hvis kanskje konto ble noe nytt spill å dyrke på. Denne funksjonen er ikke nødvendig når du snakker om nye spill vi får, siden ASF er smart nok til å automatisk sjekke distinksjonsider i denne saken. `IdleFarmingPeriod` er hovedsaklig for situasjoner slik som gamle spill som vi allerede har lagt til med handelskort. I dette tilfellet finnes det ingen hendelse, så ASF må sjekke merkesider periodisk hvis vi ønsker å ha dette dekket. Verdien av `0` deaktiverer denne funksjonen. Også kryss: `ShutdownOnFarmingEnished` preferanse i `FarmingPreferences`.

---

### `InventoryLimiterDelay`

`byte` type with default value of `4`. ASF vil sikre at det blir minst `InventoryLimiterDelay` sekunder på mellom to påfølgende web-inventarforespørsler for å unngå å utløse hastighetsgrensen – disse brukes for eksempel under merking av lagervarsler som lest, kan også brukes av tredjeparts plugins som henter inventar for andre brukere. Denne eiendommen benyttes ikke til å hente vår egen varebeholdning fordi ASF bruker mye mer effektivt internt nettverk for det, så det påvirker ikke kommandoer som `loot` eller `overføring` på noen måte. Standardverdien for `4` ble satt basert på merking av inventar på over 100 påfølgende robotinstanser, og bør tilfredsstille de fleste (hvis ikke alle) av brukerne. Du ønsker kanskje å redusere den, eller til og med endre til `0` hvis du har svært lave mengder med bots, Så ASF vil ignorere forsinkelsen og merke Steam-inventar mye raskere. Be warned though, as setting it too low **will** result in Steam temporarily banning your IP, and that will prevent you from making any calls at all. Du må også øke denne verdien hvis du kjører mange botter med mye inventar du trenger, selv om du i dette tilfellet sannsynligvis bør prøve å begrense antall av disse forespørsler i stedet. Med mindre du har en **sterk** grunn til å redigere denne egenskapen, bør du beholde den som standard.

---

### `IPC`

`bool` type with default value of `true`. Denne egenskapen definerer hvis ASF's **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** -serveren skal starte sammen med prosessen. IPC tillater interprosesskommunikasjon, inkludert bruk av **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, ved å starte en lokal HTTP server. Hvis du ikke har planer om å bruke noen tredjeparts IPC integrasjon med ASF, inkludert vår ASF-ui, kan du trygt deaktivere dette alternativet. Ellers er det en god idé å holde den aktivert (standardalternativ).

---

### `IPCPassord`

`string` type with default value of `null`. Denne egenskapen definerer obligatorisk passord for hver API-samtale utført via IPC og tjener som et ekstra sikkerhetstiltak. Når angitt til ikke-tom verdi, vil alle IPC forespørsler kreve ekstra `passord` eiendom satt til det angitte passordet. Standard verdi av `null` vil hoppe over et behov for passordet, noe som gjør ASF respekterer alle spørringer. I tillegg til det, aktivering av dette alternativet aktiverer også innebygde IPC anti-bruteforce mekanisme som midlertidig vil forby gitt `IPAddress` etter å ha sendt for mange uautoriserte forespørsler om kort tid. Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

### `IPCPasswordFormat`

`byte` type with default value of `0`. Denne egenskapen definerer formatet på `IPCPassword` egenskapen og bruker `EHashingMethod` som underliggende type. Se **[Security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** -delen hvis du vil lære mer, siden du må være sikker på at `IPCPassword` egenskapen inkluderer passord ved samsvaring i `IPCPasswordFormat`. med andre ord når du endrer `IPCPasswordFormat` skal da `IPCPassword` være **allerede** i det formatet, ikke bare sikte på å være. Med mindre du vet hva du gjør, bør du holde det med standardverdien av `0`.

---

### `Lisens-ID`

`Guid?` type with default value of `null`. Denne egenskapen tillater våre **[sponsorer](https://github.com/sponsors/JustArchi)** å forbedre ASF med valgfrie funksjoner som krever at de betalte ressursene virker. Foreløpig kan dette gjøre bruk av **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** funksjonen i `ItemsMatcher` plugin.

While we recommend you to utilize GitHub since it offers monthly and one-time tiers, as well as allows full automation and gives you immediate access, we **also** support all other currently-available **[donation options](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. Se **[denne posten](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** for instruksjoner om hvordan du donerer ved hjelp av andre metoder for å få en manuell lisens gyldig i den aktuelle perioden.

Uansett metode som brukes, hvis du er ASF-sponsor, kan du få din lisens **[her](https://asf.justarchi.net/User/Status)**. Du må logge på med GitHub for å bekrefte identiteten din. Vi ber bare om informasjon om lese, som er ditt brukernavn. `LicenseID` er laget av 32 heksadesimale tegn, slik som `f6a0529813f74d119982eb4fe43a9a24`.

**bør du forsikre deg om at du ikke deler din `LicenseID` med andre personer**. Siden det er utstedt på personlig basis, kan det bli trukket tilbake hvis det er lekket ut. Hvis det skjer en sjanse til deg ved et uhell, kan du generere en ny fra samme sted.

Med mindre du ønsker å aktivere ekstra ASF-funksjoner, er det ikke nødvendig å oppnå/oppgi lisensen.

---

### `LoginLimiterDelay`

`byte` type with default value of `10`. ASF vil sikre at minst `LoginLimiterDelay` sekunder mellom to påfølgende tilkoblingsforsøk for å unngå å utløse rate-grense. Standardverdien for `10` ble satt basert på oppkopling av mer enn 100 botthendelser og bør tilfredsstille de fleste (hvis ikke alle) av brukerne. Du ønsker kanskje å øke/redusere den, eller til og med endre til `` hvis du har svært liten mengde bots, Så ASF vil ignorere forsinkelsen og koble til Steam mye raskere. Vær advart selv om å sette det for lavt mens du har for mange bots **vil** resultere i Steam midlertidig utestengelse av din IP, og som vil forhindre deg fra å logge deg inn **i hele**, med `InvalidPassword/RateLimitExceeded` -feil - og som også har en normal Steam-klient, ikke bare ASF. Likeledes hvis du kjører for mange bots, spesielt sammen med andre Steam-klienter/verktøy med samme IP-adresse, mest sannsynlig trenger du å øke denne verdien for å spre innlogginger over lengre tid.

Som en sidemeddel brukes denne verdien også som last-balanseringsbuffer for alle ASF-planlagte handlinger, for eksempel handler i `SendTradePeriod`. Med mindre du har en **sterk** grunn til å redigere denne egenskapen, bør du beholde den som standard.

---

### `MaxFarmingTime`

`byte` type with default value of `10`. Som du burde vite fungerer ikke Steam alltid som de skal, noen ganger kan det skje slike situasjoner som spilltiden vår ikke er registrert, til tross for at den spiller et spill. ASF vil tillate oppdrett et enkelt spill i solomodus for maksimalt `MaxFarmingTime` timer, og anser den som fullt oppdrettet etter den perioden. Dette er et krav om ikke å fryse jordbruksprosessen ved at det skjer rare situasjoner, men også hvis Steam av en eller annen grunn slukker et nytt merke som vil hindre ASF i å progrediere videre (se: `svarteliste`). Standardverdien for `10` timer skal være nok til å slippe alle dampkort fra ett spill. Hvis denne egenskapen er for lav, kan det føre til at gyldige spill hoppes over (og ja, det er gyldige partier som også tar 9 timer på gård), samtidig som det settes for høyt, kan føre til at oppdrett fryses ut. Vær oppmerksom på at denne egenskapen påvirker bare ett enkelt spill under én jordbruksøkt (som etter at hele køen ASF vil returnere til den tittelen), Det er heller ikke basert på samlet spilletid, men intern ASF-jordbrukstid, så ASF vil også vende tilbake til den etter en omstart. Med mindre du har en **sterk** grunn til å redigere denne egenskapen, bør du beholde den som standard.

---

### `MaxTradeHoldDuration`

`byte` type with default value of `15`. Denne egenskapen definerer maksimal handelsandel i dager som vi er villig til å akseptere - ASF vil avvise handler som avholdes for mer enn `MaxTradeHoldDuration` dager, som definert i **[handel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** avsnitt. Dette alternativet gir mening bare for bots med `TradingPreferences` av `SteamTradeMatcher`, siden det ikke påvirker `Master`/`SteamOwnerID` fager, ingen donasjoner. Handelsfestene er irriterende for alle, og ingen ønsker å håndtere dem. ASF skal arbeide med liberale regler og hjelpe alle, uansett om det er på handel hold eller ikke - det er derfor dette alternativet er satt til `15` som standard. Hvis du likevel ønsker å avvise alle handler som er berørt av handelen, kan du spesifisere `` her. Vær oppmerksom på at kort levetid ikke påvirkes av dette valget og avviste automatisk for personer med handelsbeholdning, som beskrevet i **[handel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** delen, Derfor er det ikke nødvendig å avvise alle på grunn av det. Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.


---

### `MinFarmingDelayAfterBlock`

`byte` type with default value of `60`. Denne egenskapen definerer minimum tidsbeløp i sekunder, hvilken ASF som vil vente før kort startes opp igjen hvis den tidligere ble frakoblet til `LoggedInElsewhere`, noe som skjer når du bestemmer deg for å tvangskoble fra nåværende oppdrett ASF ved å åpne et spill. Denne forsinkelsen omfatter hovedsakelig av bekvemmelighets- og overordneårsaker, for eksempel lar det deg starte spillet på nytt uten å måtte kjempe med ASF-okkupere kontoen din igjen fordi spillelåsen var tilgjengelig i et delt sekund. På grunn av det faktum at tilbakeføring av økten forårsaker `LoggedInElsewhere` frakoblet, må ASF gå gjennom hele forbindelsesprosedyren, som setter ekstra trykk på maskinen og Steam-nettverket, og der det er mulig, bør det foretrekkes ytterligere frakobling. Som standard er denne konfigurert på `60` sekunder, som skal være nok til at du kan starte spillet på nytt uten mye hersking. Det er imidlertid scenarioer når du ønsker å øke denne, for eksempel hvis nettverket ditt kobles fra ofte og ASF tar for raskt over, noe som fører til at det tvinges til å gå gjennom nettilkoblingsprosessen selv. Vi tillater maksimumsverdien på `255` for denne egenskapen, som burde være nok for alle vanlige scenarier. I tillegg til det som er nevnt ovenfor, er det også mulig å redusere forsinkelsen. eller til og med fjerne det helt med en verdi av `0`, Selv om dette vanligvis ikke anbefales på grunn av årsaker som er angitt ovenfor. Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

### `OptimaliseringModus`

`byte` type with default value of `0`. Denne egenskapen definerer optimaliseringsmodus som ASF vil foretrekke under kjøretid. For øyeblikket støtter ASF to moduser - `0` som kalles `MaxPerformance`, og `1` som heter `MinMemoryusage`. Som standard foretrekker ASF-målinger å kjøre så mange som mulig parallelt (samtidig) som forbedrer ytelsen ved å laste balanseringsarbeid over alle CPU-kjerner, flere CPU-gjenger, flere kontakter og flere trådpool-oppgaver. For eksempel vil ASF be om din første merkeside når du ser etter spill å bli dyrket, og så når forespørselen er ankommet, ASF leser fra det hvor mange distinksjonsider du faktisk har, og be så hverandre om samtidig. Dette er hva du skal ha **nesten alltid**, Siden overhodet i de fleste tilfeller er minimal og nytte av asynkront ASF-kode kan sees selv i den eldste maskinvaren med en enkelt CPU-kjerne og stor begrenset kraft. Men etter at mange oppgaver blir behandlet parallelt, har ASF runtid ansvaret for vedlikeholdet, f.eks. holde kontakter åpne, tråder i live og oppgaver som skal behandles, som kan resultere i økt minnebruk fra tid til annen, og hvis du er ekstremt begrenset av tilgjengelig minne, du vil kanskje bytte denne egenskapen til `1` (`MinMemoryusage`) for å tvinge ASF til å bruke så små oppgaver som mulig. og kjører vanligvis muligens parallell asynkronisk kode på en synkronisert måte. Du bør bare vurdere å bytte denne egenskapen hvis du tidligere har lest **[lavminneoppsett](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** , og du ønsker med hensikt å ofre gigantisk ytelsesbooster for en veldig liten hukommelsestankegang. Dette alternativet er vanligvis **mye verre** enn hva du kan oppnå med andre mulige veier, som ved å begrense ASF-bruk eller innstilling av søppeltømming, som forklart i **[lavt minne-oppsett](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Derfor bør du bruke `MinMemoryusage` som en **siste sortering**, rett før runtime rekompilering, hvis du ikke kunne oppnå tilfredsstillende resultater med andre (mye bedre) alternativer. Med mindre du har en **sterk** grunn til å redigere denne egenskapen, bør du beholde den som standard.

---

### `PluginsUpdateList`

`ImmutableHashSet<string>` typen med standardverdien for å være tom. Denne egenskapen definerer liste over navn på plugin som er svartelistet eller hvitelistet for å bli vurdert for automatiske oppdateringer, i `PluginsUpdateMode` definert nedenfor.

Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

### `PluginsUpdateMode`

`byte` type with default value of `0`. Denne egenskapen definerer oppdateringsmodus til plugins som gir betyr `PluginsUpdateList` definert ovenfor. Ved å spesifisere denne egenskapen kan du enkelt aktivere/deaktivere automatiske oppdateringer for alle utvidelser bortsett fra de som er deklarert.

- Verdien av `0`, kalt `Whitelist`, **deaktiverer** automatisk oppdatering av alle plugins, bortsett fra de som er definert i `PluginsUpdateList`.
- Verdi av `1`, kalt `svarteliste`, **aktiverer** automatisk oppdatering av alle plugins, bortsett fra de som er definert i `PluginsUpdateList`.

**ASF-team ønsker å minne deg på at du for din egen sikkerhet bør aktivere automatiske oppdateringer bare fra klarerte parter**. Husk at ondsinnede plugins kan velge å oppdatere seg selv eller utføre fjernkommandoer **uavhengig** i denne innstillingen, dette er grunnen til at denne innstillingen gjelder oppdateringen til tilleggsprogrammer som tilbys ekskludert, og du bør fortsatt forsikre deg om at du har bekreftet hver plugin som du har bestemt å bruke.

Updates of plugins are performed by default along with ASF update routine - **[`UpdateChannel`](#updatechannel)** and **[`UpdatePeriod`](#updateperiod)**. Standard ASF oppdateringsmekanismer som `oppdater` vil også utløse valgfrie utvidelser oppdatering. Hvis du i stedet ønsker å oppdatere plugins manuelt uten å oppdatere ASF-versjonen samtidig, `oppdater eplugins` kommandoen tilbyr slik mulighet.

Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

### `Avsluttende Mulig`

`bool` type with default value of `false`. Når aktivert vil ASF forsøke å stenge prosessen om mulig, det vil si når alle dine registrerte botter er stoppet. Dette kan være spesielt nyttig når det kombineres med `ShutdownOnFarmingended` på alle dine botthendelser, Siden dette vil ASF bli lov til å automatisk slå av når den siste av dine botter er bøndende.

Siden det til enhver tid er forventninger til de fleste brukere, skal prosessen være i gang. . For `IPC` bruk er dette alternativet deaktivert som standard.

---

### `SteamMessagePrefiks`

`string` type med standardverdien `"/me "`. Denne egenskapen definerer et prefiks som vil bli lagt til alle Steam-meldinger som sendes av ASF. Som standard er ASF bruker `"/me "` prefiks for å skille robotmeldinger lettere ved å vise dem i en annen farge på Steam-chat. Et annet eksempel er at `"/pre "` prefiks som oppnår et lignende resultat, men bruker forskjellig formatering. Du kan også sette denne egenskapen til tom streng eller `null` for å deaktivere bruk av prefiks helt og så sende alle ASF-meldinger på en tradisjonell måte. Det er hyggelig å merke seg at denne egenskapen påvirker Steam-meldinger - svar som returneres gjennom andre kanaler (som IPC) ikke påvirkes. Med mindre du ønsker å tilpasse standard ASF-oppførsel, er det lurt å forlate den til standard.

---

### `SteamOwnerID`

`ulong` type with default value of `0`. Denne egenskapen definerer Steam ID i 64-bit form av ASF prosesseier, og er veldig lik `Master` tillatelse til gitt bot instans (men global i stedet). Du vil nesten alltid sette denne egenskapen til ID for din egen Steam-konto. `Master` tillatelser inkluderer full kontroll over sin bot forekomst, men globale kommandoer som `exit`, `restart` eller `oppdaterer` er kun reservert for `SteamOwnerID`. Dette er praktisk - for du vil kanskje kjøre boter for dine venner, mens de ikke lar seg kontrollere ASF-prosessen, for eksempel avslutte den ved hjelp av `avslutt` kommando. Standardverdien for `0` angir at det ikke er noen eier av ASF-prosessen, noe som betyr at ingen vil kunne utstede globale ASF-kommandoer. Husk bare at denne egenskapen gjelder på Steam-chat. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, samt interaktiv konsoll, vil fremdeles tillate deg å utføre kommandoene `eier` selv om denne egenskapen ikke er satt.

---

### `SteamProtokoller`

`byte flagg` type med standardverdien `7`. Denne egenskapen definerer Steam-protokoller som ASF vil bruke ved tilkobling til Steam-servere som er definert som nedenfor:

| Verdi | Navn      | Beskrivelse                                                                                         |
| ----- | --------- | --------------------------------------------------------------------------------------------------- |
| 0     | Ingen     | No protocol                                                                                         |
| 1     | TCP       | **[Kontrollprotokoll for overføring](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2     | UDP       | **[Bruker Datagram Protokoll](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**               |
| 4     | WebSocket | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                                            |

Vennligst merk at denne egenskapen er `flagg` feltet, derfor er det mulig å velge en kombinasjon av tilgjengelige verdier. Sjekk ut **[json mapping](#json-mapping)** hvis du ønsker å lære mer. Ikke aktivering av flaggresultater i `Ingen` alternativ, og det alternativet er ugyldig av seg selv.

Som standard vil ASF bruke alle tilgjengelige Steam protokoller som et tiltak for å bekjempe med nedetid og andre lignende Steam-problemer. Du vil vanligvis endre denne egenskapen hvis du ønsker å begrense ASF til å bruke kun ett eller to spesifikke protokoller. I ulike situasjoner kan det være nødvendig med tiltak for eksempel hvis du har blokkert UDP-trafikk på brannmuren din og du vil sørge for at bare TCP-trafikk går gjennom, eller hvis du bruker `WebProxy` og ønsker å bruke den også for Steam klientens tilkobling, som bare `WebSocket` protokoll støtter det.

Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

### `Oppdateringskanal`

`byte` type with default value of `1`. Denne egenskapen definerer oppdateringskanalen som brukes, enten for automatiske oppdateringer (hvis `oppdaterings periode` er større enn `0`), eller oppdatere varsler (annet er oppdatert). For tiden ASF støtter tre oppdateringskanaler - `0` som kalles `Ingen`, `1`, som heter `Stable`og `2`, som kalles `preRelease`. `Stable` kanal er standardutgivelseskanalen, som skal brukes av de fleste brukere. `PreRelease` kanal i tillegg til `Stable` utgivelser, omfatter også **forhåndsutgivelser** dedikert for avanserte brukere og andre utviklere for å teste nye funksjoner; bekrefte feilrettinger eller gi tilbakemeldinger om planlagte forbedringer. **Forhåndsversjoner, inneholder ofte utsendte feil, elementer i gang på gang, eller gjenskrevne implementasjoner**. Hvis du ikke anser deg som avansert bruker, vennligst fortsett med standard `1` (`Stabell`) oppdateringskanal. `PreRelease` kanal er dedikert til brukere som vet hvordan man rapporterer feil, behandle problemer og gi tilbakemelding – ingen teknisk støtte vil bli gitt. Sjekk ASF **[frigjøringssyklus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** hvis du vil lære mer. Du kan også angi `UpdateChannel` til `0` (`Ingen`), hvis du ønsker å fullstendig fjerne alle versjonskontroller. Ved å sette `Oppdateringskanal` til `0` vil hele funksjonen bli deaktivert i forbindelse med oppdateringer, inkludert `oppdatere` kommandoen. Bruk av `Ingen` kanal er **sterkt frarådet** på grunn av at du eksponerer deg selv alle slags problemer (nevnt i `UpdatePeriod` beskrivelsen nedenfor).

**Unless you know what you're doing**, we **strongly** recommend to keep it at default.

---

### `Oppdateringsperiode`

`byte` type with default value of `24`. Denne egenskapen definerer hvor ofte ASF bør se etter auto-oppdateringer. Oppdateringer er av avgjørende betydning for å motta nye funksjoner og kritiske sikkerhetskorrigeringer, men også for å motta feilrettinger, ytelsesforbedring, stabilitetsforbedringer og mer. Når en verdi større enn `0` er satt, vil ASF automatisk lastes ned, erstatte og restarte seg selv (hvis `AutoStart` tillatelser) når ny oppdatering er tilgjengelig. For å oppnå dette, vil ASF sjekke hver `UpdatePeriod` timer hvis ny oppdatering er tilgjengelig på vårt GitHub repo. En verdi av `0` deaktiverer auto-oppdateringer, men tillater deg fremdeles å kjøre `oppdatering` manuelt. Kanskje du også er interessert i å sette passende `UpdateChannel` at `UpdatePeriod` bør følge.

Oppdateringsprosessen av ASF innebærer å oppdatere hele mappestrukturen som ASF bruker. men uten å berøre dine egne konfigurasjoner eller databaser lokalisert i `config` - dette betyr at eventuelle ekstra filer som ikke er relatert til ASF i mappen, kan gå tapt under oppdateringen. Standardverdien for `24` er en god balanse mellom unødvendige kontroller, og ASF som er fersk nok.

Med mindre du har en **sterk** grunn til å deaktivere denne funksjonen, Automatisk oppdatering aktivert innen rimelig `Oppdateringsperiode` **bør du holde automatiske oppdateringer aktivert for ditt eget gode**. Dette er ikke bare fordi vi ikke støtter noe, men nyeste stabile ASF-utgivelser, men også fordi **gir vi vår sikkerhetsgaranti bare for siste versjon**. Hvis du bruker utdatert ASF-versjon, da er du bevisst eksponert for alle typer problemer, fra små feil, gjennom ødelagt funksjonalitet. slutter med **[permanente Steam-kontosuspensjoner](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**så vi **anbefaler sterkt at**– til din egen gode – alltid sikrer at din ASF-versjon er oppdatert. Automatiske oppdateringer lar oss reagere raskt på alle typer problemer ved å deaktivere eller patchere problematisk kode før det blir eskalert - hvis du velger ute du mister alle sikkerhetsgarantiene våre, og det er risiko ved å kjøre kode som kan være potensielt skadelige, ikke bare på Steam-nettverk, men også (på definisjon) til din egen Steam-konto.

---

### `WebLimiterDelay`

`ushort` type with default value of `300`. Denne egenskapen definerer minimum antall forsinkelser mellom å sende to påfølgende forespørsler til samme Steam nettjeneste. En slik forsinkelse er nødvendig som **[AkamaiGhost](https://www.akamai.com)** -tjenesten som Steam bruker internt inkluderer hastighetsbegrensende basert på et globalt antall forespørsler som er sendt over en gitt tidsperiode. Under normale omstendigheter er akamai-blokk ganske vanskelig å oppnå, men med en enorm pågående køen for forespørsler, vil det likevel være vanskelig å oppnå, Det er mulig å utløse den hvis vi fortsetter å sende for mange forespørsler over for kort tidsperiode.

Standardverdi ble satt basert på forutsetningen om at ASF er det eneste verktøyet som bruker Steam nettjenester, særlig `steamcommunity. om`, `api.steampowered.com` og `store.steampowered.com`. Hvis du bruker andre verktøy som sender forespørsler til samme nettjenester, bør du sørge for at verktøyet har lignende funksjonalitet av `WebLimiterDelay` og sette begge til en dobbel standardverdi, som vil være `600`. Denne garantien garanterer at du under ingen omstendigheter vil overstige å sende mer enn 1 forespørsel per `300` ms.

Generelt senke `WebLimiterDelay` under standardverdi er **sterkt frarådet** , da det kan føre til ulike IP-relaterte blokker, noen av disse kan være permanente. Standardverdi er god nok til å kjøre en enkelt ASF-forekomst på serveren; I tillegg til å bruke ASF i normalt scenario sammen med den opprinnelige dampklienten. Den bør være korrekt ved de fleste bruk, og den skal kun økes (aldri lavere). Kort globalt nummer av alle forespørsler sendt fra en enkelt IP til et enkelt Steam-domene bør aldri overstige mer enn 1 forespørsel per `300` ms.

Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

### `Webproxy`

`string` type with default value of `null`. Denne egenskapen definerer en webproxy adresse som vil bli brukt til intern http-related communication, spesielt for tjenester som `github. om`, `api.steampowered.com`, `steamcommunity.com` og `store.steampowered.com`. Den gjelder for generell (ikke-bot spesifisert) kommunikasjon, i tillegg til bot-spesifikk kommunikasjon hvis deres tilsvarende `WebProxy` ikke er satt. Angående ASF-forespørsler kan være uvanlig nyttige for å omgå ulike typer brannmurer, særlig den store brannmuren i Kina.

Denne egenskapen er definert som URI streng:

> En URI-streng er sammensatt av en ordning (støttet: http/https/socks4/socks4a/socks5), en vert, og en valgfri port. Et eksempel på en fullstendig uri streng er `"http://contoso.com:80"`.

Dersom proxy krever brukerautentisering, må du også sette opp `WebProxyUsername` og/eller `WebProxyPassword`. Etablering av denne eiendommen er tilstrekkelig dersom det ikke oppstår et slikt behov.

Hvis du også trenger proxytting av interne Steam-nettverk (CMs) da bør du sørge for å konfigurere **[`SteamProtocols`](#steamprotocols)** botens eiendom til en verdi som bare tillater Websocket transport, i. . Verdien `4`, da bare websockets støttes for proxying.

Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

### `Nettstedspassord`

`string` type with default value of `null`. Denne egenskapen definerer passordfeltet som brukes i grunnleggende, digest, NTLM, og Kerberos godkjenning som støttes av en mål- `WebProxy` maskin som sørger for proxy-funksjonalitet. Hvis din proxy ikke krever brukerlegitimasjon er det ikke nødvendig for deg å legge inn noe her. Å bruke dette alternativet er fornuftig bare hvis `WebProxy` er brukt, siden det ikke har noen effekt.

Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

### `WebProxyUsername`

`string` type with default value of `null`. Denne egenskapen definerer navnefeltet for brukernavn som brukes i basisk, digest, NTLM, og Kerberos godkjenning som støttes av en mål- `WebProxy` maskin som sørger for proxy-funksjonalitet. Hvis din proxy ikke krever brukerlegitimasjon er det ikke nødvendig for deg å legge inn noe her. Å bruke dette alternativet er fornuftig bare hvis `WebProxy` er brukt, siden det ikke har noen effekt.

Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

## Bot config

Som du bør vite allerede, bør hver bot ha sin egen konfigurasjon basert på eksempel JSON-struktur under. Begynn med å bestemme hvordan du vil navngi boten din (f.eks. `1.json`, `er. son`, `primary.json` eller `AnythingElse.json`) og hode over til konfigurasjon.

**Merknad:** Bot kan ikke navngis `ASF` (som det søkeordet er reservert for global konfigurasjon), ASF vil også ignorere alle konfigurasjonsfiler som starter med en prikk.

Konfigureringen av boten har følgende struktur:

```json
{
    "AcceptGifts": false,
    "BotBehaviour": 0,
    "FullførtTypesToSend": [],
    "TilpassetPlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Aktivert": false,
    "FarmingOrders": [],
    "FarmingPreferanser": 0,
    "GamesPlayedWhileIdle": [],
    "GamingDeviceType": 1,
    "HoursUntilCardDrops": 3,
    "LootableTyper": [1, 3, 5],
    "Maskinnavn": null,
    "MatchbleTyper": [5],
    "OnlineFlagger": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "RedeemingPreferanser": 0,
    "RemoteCommunication": 3,
    "SendTradePeriod": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferanser": 0,
    "TransferableTyper": [1, 3, 5],
    "UseLoginKeys": Sant,
    "Brukergrensesnitt": 0,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Alle alternativer er forklart nedenfor:

### `Aksepterte gaver`

`bool` type with default value of `false`. Når aktivert vil ASF automatisk akseptere og løse inn alle dampgaver (inkludert lommebok gavekort) sendt til boten. Dette inkluderer også gaver sendt fra andre brukere enn de som er definert i `SteamBrukerTillatelser`. Husk at gaver som sendes til e-postadressen, ikke videresendes direkte til kunden, så ASF vil ikke akseptere uten hjelp.

Dette valget anbefales bare for 'alt' kontoer. siden det er svært sannsynlig at du ikke automatisk vil innløse alle gaver som sendes til din primære konto. Hvis du er usikker på om du vil ha denne funksjonen aktivert eller ikke, behold den med standardverdien `false`.

---

### `Bunnoppførsel`

`byte flagg` type med standardverdien `0`. Denne egenskapen definerer ASF bot-lignende atferd under ulike hendelser, og er definert som nedenfor:

| Verdi | Navn                             | Beskrivelse                                                                                           |
| ----- | -------------------------------- | ----------------------------------------------------------------------------------------------------- |
| 0     | Ingen                            | Ingen spesiell bot oppførsel, bar-standardinnstillinger                                               |
| 1     | AvvisingInvalidVennInvitasjoner  | Vil forårsake at ASF avviser (i stedet for å ignorere) ugyldige venneinvitasjoner                     |
| 2     | Avvist Invalideringshjelp        | Vil forårsake at ASF avviser (i stedet for å ignorere) ugyldige tilbud                                |
| 4     | Avviste ugyldiggjøringer         | Vil forårsake at ASF avviser (i stedet for ignorering) ugyldige gruppeinvitasjoner                    |
| 8     | DismissInventorynotifikasjoner   | Vil forårsake ASF automatisk avvise alle inventarvarsler                                              |
| 16    | MarkReceivedMessagesAsRead       | Vil forårsake at ASF automatisk markerer alle mottatte meldinger som lest                             |
| 32    | MarkBotMessagesAsLes             | Vil forårsake ASF automatisk markere meldinger fra andre ASF-botter (kjører i samme instans) som lest |
| 64    | Deaktivere IncomingTradesParsing | Vil forårsake at ASF aldri behandler innkommende tilbud                                               |

Vennligst merk at denne egenskapen er `flagg` feltet, derfor er det mulig å velge en kombinasjon av tilgjengelige verdier. Sjekk ut **[json mapping](#json-mapping)** hvis du ønsker å lære mer. Ikke aktiverer noen av flaggresultatene i `Ingen` alternativ.

Vanligvis vil du endre denne innstillingen hvis du forventer å endre forskjellige automatiseringsinnstillinger relatert til botens aktivitet. Standardinnstillingene innebærer at ASF kjører ikke-invasiv modus, som bare muliggjør en gunstig automatisering som ikke går mot brukerens vilje.

Ugyldig venneinvitasjon er en invitasjon som ikke kommer fra bruker med `FamilySharing` tillatelse (definert i `SteamUserPermissions`) eller over. ASF i normal modus ignorerer disse invitasjonene slik du ville vente, hvis du skulle velge fritt om du skulle akseptere dem, eller ikke. `AvvistInvalidFriendInvites` gjør at disse invitasjonene automatisk blir avvist, som praktisk talt vil deaktivere alternativet for andre til å legge deg til sin venneliste (som ASF, vil avslå alle slike forespørsler, bortsett fra personer definert i `SteamUserPermissions`). Med mindre du vil reise rett bort alle venneinvitasjoner, bør du ikke aktivere denne instillingen.

Ugyldig handelstilbud er et tilbud som ikke er akseptert gjennom innebygd ASF-modul. Mer om denne saken kan finnes i **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** -delen som eksplisitt definerer hvilke typer handels-ASF som er villig til å akseptere automatisk. Gyldige handler er også definert av andre innstillinger, spesielt `TradingPreferences`. `AvvistInvalidTrades` vil føre til at alle tilbud vedrørende omsetning vil bli avvist, i stedet for å bli ignorert. Med mindre du vil reise rett ut for all handel tilbyr som ikke automatisk godkjennes av ASF, skal du ikke aktivere dette alternativet.

Ugyldig gruppeinvitasjon er en invitasjon som ikke kommer fra `SteamMasterClanID` gruppen. ASF i normal modus ignorerer disse gruppene invitasjoner, som du ønsker å vente gjør det mulig å avgjøre deg selv om du vil bli med i den bestemte Steam-gruppen eller ikke. `Avvist InvalidGroupInvites` medfører at alle invitasjonene i gruppen blir automatisk avvist, gjør det faktisk umulig å invitere deg til noen andre grupper enn `SteamMasterClanID`. Med mindre du ønsker å strømme opp alle gruppeinvitasjoner, bør du ikke aktivere denne innstillingen.

`DismissInventoryNotifications` er svært nyttig når du begynner å bli irritert av konstant Steam-varsel om å motta nye elementer. ASF kan ikke kvitteres av selve varselet, da det er innebygd i Steam-klienten din men det er i stand til å automatisk fjerne varselet etter å ha mottatt det, noe som ikke lenger forlater «nye elementer i inventar» varselet om det. Hvis du forventer å vurdere deg selv alle mottatte varer (spesielt kort oppdrettet med ASF), bør du selvsagt ikke aktivere dette alternativet. Når du begynner å gå galt, husk at dette tilbys som et alternativ.

`MarkReceivedMessagesAsRead` markerer automatisk **alle** meldinger som mottas av kontoen ASF er i bruk på, både privat og gruppe, som lest. Denne bør vanligvis brukes av alt av kontoer for å slette "ny melding" varsler som kommer fra for eksempel når du utfører ASF-kommandoer. Vi anbefaler ikke dette valget for primærkontoer, med mindre du ønsker å klippe deg selv fra en type nye meldinger til meldinger. **inkludert** de som skjedde mens du var frakoblet, forutsatt at ASF fortsatt var åpen og manglet den.

`MarkBotMessagesAsRead` fungerer på en lignende måte ved å merke kun botemeldinger som lest. Husk imidlertid at når du bruker den muligheten i gruppesamtaler med dine boter og andre mennesker, Steam implementering av å bekrefte chat-melding **også** erkjenner alle meldinger som skjedde **før** den du valgte å merke, så hvis du på en sjanse ønsker du ikke å gå glipp av relatert melding som skjedde mellom, vil du typisk unngå å bruke denne funksjonen. Den er også risikabelt når du har flere primærkontoer (f.eks. fra forskjellige brukere) som kjører i samme ASF-eksempel, da du også kan gå glipp av sine normale meldinger utenfor ASF.

`DisableIncomingTradesParsing` vil stoppe ASF fra å analysere innkommende handelstilbud, dette betyr at hele handelsfunksjonaliteten knyttet til det som vil være ikke-operativ. Siden ASF fungerer i den minst invasive modusen som standard godtar du bare handelstilbud fra `Master` brukere og over. aldri å berøre andre varetilbud - innkommende varetolking er aktivert som standard. Denne innstillingen er mest fornuftig for personer som ønsker å sørge for at det ikke finnes flere forespørsler/overhead knyttet til hele prosessen med å endre og deaktivere hele logikk; for eksempel fordi de vet at botene deres aldri vil motta superhandelsforespørsler, Derfor kreves ikke ASF-deltakelse i deres handelsaktivitet i det hele tatt. Husk at med dette alternativet angitt, vil deaktivere alle andre alternativer som er avhengige av innkommende handlinger, slik som `Godkjenning` eller `SteamTradeMatcher` - egendefinerte plugins vil ikke kunne behandle innkommende tilbud på vanlig måte.

Hvis du er usikker på hvordan du konfigurerer dette alternativet, er det best å la det stå til standard.

---

### `CompleteTypesToSend`

`ImmutableHashSet<byte>` typen med standardverdien for å være tom. Når ASF gjennomføres med å fullføre et gitt sett av enhetstyper som er angitt her, det kan automatisk sende damphandel med alle ferdige sett til brukeren med `Master` -tillatelse, som er veldig praktisk hvis du vil bruke en bot konto for e. . STM matcher, mens du flytter ferdige sett til en annen konto. Dette alternativet fungerer som `loot` -kommandoen, Husk derfor at den krever bruker med `Master` tillatelse innstilt. du kan også trenge en gyldig `SteamTradeToken`, i tillegg til å bruke en konto som er berettiget til å handle i førsteplass.

Per i dag støttes følgende enhetstyper i denne innstillingen:

| Verdi | Navn            | Beskrivelse                                                  |
| ----- | --------------- | ------------------------------------------------------------ |
| 3     | FoilTradingCard | Oljevariant av `TradingCard`                                 |
| 5     | TradingCard     | Steam-handelskort, som brukes til å lage merker (ikke-folie) |

Vær oppmerksom på at uansett instillingene ovenfor ASF vil kun be om **[Steam-fellesskapsposter](https://steamcommunity.com/my/inventory/#753_6)** (`appID` av 753, `kontekstID` av 6), så alle spill, gaver og på samme måte er utelukket fra fagtilbudet som definisjon.

på grunn av ekstra overhode med dette alternativet, det anbefales å bruke det bare på bot kontoer som har realistiske sjanser for å fullføre sine egne, for eksempel Det er ingen mening å aktivere hvis du allerede bruker `SendOnFarmingferdig` preferanse i `FarmingPreferanser`, `SendTradeperiode` eller `loot` kommando på vanlig grunnlag.

Hvis du er usikker på hvordan du konfigurerer dette alternativet, er det best å la det stå til standard.

---

### `Tilpassning PlayedWhileFarming`

`string` type with default value of `null`. Når ASF oppdrett kan det vise seg som "Playing non-steam spill: `CustomGamePlayedWhileFarming`" i stedet for for spill som kjøres. Dette kan være nyttig hvis du ønsker å la vennene dine vite at du bruker men du vil ikke bruke `OnlineStatus` fra `Frakoblet`. Vær oppmerksom på at ASF ikke kan garantere faktisk visningsordre av Steam-nettverk, derfor er dette bare et forslag som kan, eller ikke kan vise ordentlig. Det er særlig Egendefinert navn vises ikke i `Complex` Oppdage algoritme hvis ASF fyller alle `32` plasser med spill som krever at timer legges i basen. Standardverdien for `null` deaktiverer denne funksjonen.

ASF tilbyr noen spesielle variabler som du eventuelt kan bruke i teksten din. `{0}` erstattes med ASF med `AppID` av nåværende spill(er), mens `{1}` erstattes med ASF med `GameName` av nå.

---

### `CustomGamePlayedWhileIdle`

`string` type with default value of `null`. Lik `CustomGamePlayedWhileFarming`, men for situasjonen når ASF ikke har noe å gjøre (som konto er helt forsinket). Vær oppmerksom på at ASF ikke kan garantere faktisk visningsordre av Steam-nettverk, derfor er dette bare et forslag som kan, eller ikke kan vise ordentlig. Hvis du bruker `GamesPlayedWhileIdle` sammen med denne muligheten, så husk på at `GamesPlayedWhileIdle` setter prioritet, derfor kan du ikke deklarere mer enn `31` av dem, ellers vil ikke `CustomGamePlayedWhileIdle` kunne okkupere plassen for tilpasset navn. Standardverdien for `null` deaktiverer denne funksjonen.

---

### `Aktivert`

`bool` type with default value of `false`. Denne egenskapen definerer hvis boten er aktivert. Aktivert bot forekomst (`true`) vil automatisk starte når ASF kjøres, mens deaktivert bot instans (`false`) må startes manuelt. Som standard er hver bot deaktivert, så du vil sannsynligvis bytte denne egenskapen til `sann` for alle dine botter som skal startes automatisk.

---

### `Jordordre`

`ImmutableList<byte>` type med standardverdien for å være tom. Denne egenskapen definerer **foretrukket** -drifts-rekkefølgen som brukes av ASF for gitt bot konto. For tiden finnes det følgende landbruksordre:

| Verdi | Navn                            | Beskrivelse                                                                                        |
| ----- | ------------------------------- | -------------------------------------------------------------------------------------------------- |
| 0     | Avbestilt                       | Ingen sortering, noe bedre CPU-ytelse                                                              |
| 1     | App-Ascending                   | Prøv å gårdsspill med laveste `appIDs` først                                                       |
| 2     | Applikasjonstallering           | Prøv å gårdsspill med høyest `appIDs` først                                                        |
| 3     | KortDropsAscending              | Prøv å gårdsspill med lavest antall kortdråper gjenstår først                                      |
| 4     | CardDropsDescending             | Prøv å gårdsspill med høyest antall kortdråper gjenstår først                                      |
| 5     | Stigende                        | Prøv å gårdsspill med lavest antall timer spilt først                                              |
| 6     | Timer                           | Prøv å gårdsspill med høyest antall timer spilt først                                              |
| 7     | NavneAscending                  | Prøv å farm spill i alfabetisk rekkefølge, som starter fra A                                       |
| 8     | Navnesynkende                   | Prøv å farm spill i omvendt alfabetisk rekkefølge, med start fra Z                                 |
| 9     | Tilfeldig                       | Prøv å koble spill fra gård helt tilfeldig rekkefølge (forskjellig fra hver kjøring av programmet) |
| 10    | BadgeNivåStigende               | Prøv å farm spill med laveste distinksjonsnivåer først                                             |
| 11    | BadgeNivåSynkende               | Prøv å gårde spill med høyeste distinksjonsnivåer først                                            |
| 12    | Gjenta datotids-scending        | Prøv å gårde eldste spill på kontoen vår først                                                     |
| 13    | Gjenopprett dateTimesDescending | Prøv å gårde nyeste spill på kontoen vår først                                                     |
| 14    | MarketableAscending             | Forsøk å gårde spill med betalbare kort dråper først (advarsel: dyrt å kalkulere)                  |
| 15    | MarketableDescending            | Prøv å gårde spill med salgbare kortslipp først (advarsel: kostbare å kalkulere)                   |

Siden denne egenskapen er en matrise, lar den deg bruke flere forskjellige innstillinger i den faste rekkefølgen. Du kan for eksempel inkludere verdier for `15`, `11` og `7` for å sortere etter omsettelige spill først, så etter de med høyest distinksjonsnivå, og til slutt alfabetisk. Som du kan gjete, så er bestillingen faktisk tellere, slik den er reversert (`7`, `11` og `15`) oppnår noe helt annerledes (sorter alfabetisk først spill og på grunn av at spillnavnene er unike, er de to faktisk brukelig). Majoriteten av folk vil antakelig bruke kun én rekkefølge ut av dem, I tilfelle du vil, kan du også sortere lenger etter ekstra parametere.

Vær også oppmerksom på ordet "prøve" i alle de ovennevnte beskrivelsene - den faktiske ASF-rekkefølgen blir sterkt påvirket av valgte **[oppgavelappenes algoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** og sortering, vil bare påvirke resultater som ASF betrakter samme ytelse. For eksempel i `Simple` algoritme, valgte `FarmingOrdre` bør respekteres i gjeldende jordbruksøkt (som alle deler har samme ytelsesverdi), mens den faktiske rekkefølgen i `Kompleks` påvirkes av timer først, og deretter sortert etter valgte `FarmingOrders`. Dette vil føre til forskjellige resultater, siden spill med eksisterende spilltid vil prioritere mer andre, så effektivt ASF foretrekker spill som allerede har bestått påkrevet `HoursUntilCardDrops` først, og bare sorter disse spillene videre av dine valgte `FarmingOrders`. Så fort ASF går tom for allerede startede spill, vil sortere gjenstående kø etter timer først (dette vil redusere tiden nødvendig for å støte rester av gjenværende titler til `HoursUntilCardDrops`). Derfor er denne konfigurasjonsegenskapen bare et **forslag** som ASF prøver å respektere, Så lenge det ikke påvirker ytelse negativt (da vil ASF alltid foretrekke driftsytelse over `FarmingOrders`).

Det er også jord-prioritert kø som er tilgjengelig gjennom `fq` **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Hvis den brukes, sorteres ordrereserven først og fremst av utførelse, så av driftskøyten, og endelig av `FarmingOrders`.

---

### `Farminginnstillinger`

`byte flagg` type med standardverdien `0`. Denne egenskapen definerer ASF-adferd knyttet til jordbruk, og er definert som følgende:

| Verdi | Navn                      |
| ----- | ------------------------- |
| 0     | Ingen                     |
| 1     | FarmingPausedByStandard   |
| 2     | Avsluttende               |
| 4     | SendOnFarmingings Ferdig  |
| 8     | FarmPriorityKeueBare      |
| 16    | SkipRefunderbare spill    |
| 32    | Hopp over                 |
| 64    | EnableRiskyCardsDiscovery |
| 256   | AutoUnpackBoosterPacks    |

Vennligst merk at denne egenskapen er `flagg` feltet, derfor er det mulig å velge en kombinasjon av tilgjengelige verdier. Sjekk ut **[json mapping](#json-mapping)** hvis du ønsker å lære mer. Ikke aktiverer noen av flaggresultatene i `Ingen` alternativ.

Alle alternativene blir beskrevet nedenfor.

`FarmingPausedByStandard` definerer første tilstand på `CardsFarmer` modul. Normalt vil bot starte Oppdrett automatisk når den er startet, enten på grunn av `Enabled` eller `start` -kommandoen. Using `FarmingPausedByDefault` can be used if you want to manually `resume` automatic farming process, for example because you want to use `play` all the time and never use automatic `CardsFarmer` module - this works exactly the same as `pause` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

`Avsluttende OnFarmingFerdiggjort` lar deg slå av botten når den er ferdig med å dyrke den. Normalt er ASF «okkupert» en konto for hele tiden av prosessen som er aktiv. Når det er gitt konto med gårdsbruk, undersøkes ASF regelmessig (hver `IdleFarmingPeriod` timer), hvis kanskje noen nye spill med dampkort ble lagt til i mellomtiden, så den kan gjenoppta driften av avtalen uten å måtte starte prosessen på nytt. Det er nyttig for de fleste fordi ASF kan automatisk gjenoppta jordbruk ved behov. Men du vil faktisk stoppe prosessen når en gitt konto er fullt farlig, kan du oppnå det ved å bruke dette flagget. Når aktivert vil ASF fortsette med å logge av når kontoen er helt fart, noe som betyr at det ikke lenger blir kontrollert eller okkupert. Du bør selv bestemme om du foretrekker ASF å arbeide med gitt bot instans hele tiden, eller om kanskje ASF skal stoppe det når en jordbruksprosess gjøres.

Dette alternativet gjør den mest mening å kombineres med `ShutdownIfPossible`, Så når alle kontoer stoppes, vil ASF også stenges ned. sette maskinen din i ro og lar deg planlegge andre handlinger, slik som søvn eller slå av på samme tidspunkt som siste kortfaller.

`SendOnFarmingingings Ferdig` lar deg automatisk sende damphandel som inneholder alt som kjøres opp til dette punktet til brukeren med `Mestre` -tillatelse, noe som er veldig praktisk hvis du ikke vil plage deg med dine varemerker. Dette alternativet fungerer som `loot` -kommandoen, Husk derfor at den krever bruker med `Master` tillatelse innstilt. du kan også trenge en gyldig `SteamTradeToken`, i tillegg til å bruke en konto som er berettiget til å handle i førsteplass. I tillegg til å starte `loot` etter å ha fullført landbruket, ASF vil også sette i gang `loot` på hver nye elementmelding (ikke parkering), og etter at du har fullført hver handel med nye varer (alltid) når dette alternativet er aktivt. Dette er spesielt nyttig for å "videresending" artikler vi mottar fra andre til vår konto. Typisk vil du bruke **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** sammen med denne funksjonen, Selv om det ikke er et krav hvis du har tenkt å håndtere 2FA bekreftelser manuelt til rett tid.

`FarmPriorityQueueOnly` defines if ASF should consider for automatic farming only apps that you added yourself to priority farming queue available with `fq` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Når dette valget er aktivert, vil ASF hoppe over alle `appIDs` som mangler på listen, effektivt slik at du kan kjøre spill med kirsebær-plukking for automatisk ASF-landing. Husk at hvis du ikke la inn noen spill i køen, så vil ASF fungere som om det ikke er noe å gårde på kontoen din.

`SkipRefundableGames` definerer om ASF skal hoppe over spill som fortsatt er refunderbare fra automatisk landbruk. Et refunderbart spill er et spill som du kjøpte de siste 2 ukene via Steam Store og ikke spilte lenger enn 2 timer ennå, som angitt på **[gir Steam refusjoner](https://store.steampowered.com/steam_refunds)** siden. Som standard ignorerer ASF Steam refusjonspolicy helt og gårder alt, ettersom de fleste ville forvente. Men du kan bruke dette flagget hvis du ønsker å sørge for at ASF ikke vil dyrke noe av dine refunderbare spill for snart, tillater deg å evaluere disse spillene selv og refundere om nødvendig uten å bekymre deg om ASF påvirker spilltiden negativt. Vær oppmerksom på at hvis du aktiverer dette alternativet, vil ikke spill du kjøpte fra Steam Store skaffes av ASF i inntil 14 dager siden innløsningsdato, som vil vise som ingenting å gårde hvis kontoen din ikke eier noe annet.

`SkipUnplayedGames` definerer om ASF skal hoppe over spill som du ikke startet ennå. Spillet i denne sammenhengen betyr at du ikke har nøyaktig ingen spilletid tatt opp for Steam. Hvis du bruker dette flagget, vil slike spill hoppes over til Steam registrerer seg når som helst for dem. Dette gjør at du kan kontrollere bedre hvilke spill ASF som er kvalifisert til å drive med gårde, hoppet over dem du ikke har mulighet til å prøve ut ennå, å holde valgte Steam funksjoner mer nyttig - som å foreslå spillende spill å spille.

`EnableRiskyCardsDiscovery` gjør ekstra reserveløsning som utløser når ASF ikke kan laste inn en eller flere distinksjonsider og derfor ikke kan finne spill tilgjengelig for gårdbruk. Spesielt kan enkelte kontoer med massivt kortfall forårsake en situasjon hvor lastemerkede sider ikke lenger er mulig (på grunn av overhodet), – og disse kontoene er umulig for jordbruket på en sikker måte fordi vi ikke kan laste inn informasjonen ut fra å kunne starte prosessen. I disse praktiske tilfellene, tillater dette alternativet alternativ algoritme som skal brukes. som bruker en kombinasjon av booster som er mulige å lage og boosterpakke, kontoen kan brukes for å finne potensielt tilgjengelige spill å være uvirksom, deretter bruk av for mye ressurser til å kontrollere og hente nødvendig informasjon, og forsøker å starte prosessen med oppdrett med begrenset mengde data og informasjon for å komme fram til etter hvert å ha nådd en situasjon når sidedistinksjoner er passert, og vi vil kunne bruke en normal tilnærming. Det gjøres oppmerksom på at når denne reserveløsningen brukes, opererer ASF kun med begrensede data. Derfor er det helt normalt for ASF å finne mye mindre dråper enn i virkeligheten – andre dråper vil bli funnet i senere fase av oppdrettsprosessen.

Dette valget kalles "risky" for en svært god årsak - det er ekstremt treg og krever betydelige mengder ressurser (inkludert nettverksforespørsler) for drift, derfor er det **anbefaler ikke** å være aktivert, og spesielt på lang sikt. Du burde bruke dette alternativet kun hvis du tidligere har bestemt at kontoen din ikke kan laste emblemer og ASF ikke kan operere på den, alltid at nødvendig informasjon ikke ble lastet inn for å starte prosessen. Selv om vi gjorde vårt beste for å optimalisere prosessen mest mulig mulig. Det er fortsatt mulig for dette alternativet å reservere, og det kan føre til uønskede utfall: for eksempel midlertidig og kanskje permanente utestengelser fra Steam siden for å sende for mange forespørsler og ellers forårsaket overhodet på Steam-servere. Derfor advarer vi deg på forhånd, og vi tilbyr dette alternativet med absolutt ingen garantier, du bruker det på egen risiko.

`AutoUnpackosterpakker` vil automatisk pakke ut alle boosterpakker ved mottak av nye varsler. Da kan du umiddelbart få flere kortslippere som kanskje er ønsket, spesielt i kombinasjon med andre alternativer. . `SteamTradeMatcher` eller `KomplettTypesSend`).

---

### `GamesPlayedWhileindle`

`ImmutableHashSet<uint>` typen med standardverdien for å være tom. Hvis ASF ikke har noe å drive med på, kan den i stedet spille dine angitte dampspill (`appIDs`. Slik spiller du spill på spillet, øker du "timer spillet" av disse spillene, men ingenting annet enn det. In order for this feature to work properly, your Steam account **must** own a valid license to all the `appIDs` that you specify here, this includes F2P games as well. Denne funksjonen kan bli aktivert samtidig med `CustomGamePlayedWhileIdle` for å spille dine valgte spill mens du viser egendefinert status i Steam-nettverk men i dette tilfellet, som i `CustomGamePlayedWhileFarming` -tilfellet, er ikke den faktiske visningsordren garantert. Merk at Steam tillater ASF kun å spille opp til `32` `appIDs` totalt. derfor kan du legge til bare så mange spill på denne egenskapen.

---

### `GamingDeviceType`

`ushort` type with default value of `1`. Denne egenskapen kan aktivere noen flere online funksjoner på Steam-plattformen, og er definert som nedenfor:

| Verdi | Navn       | Beskrivelse                       |
| ----- | ---------- | --------------------------------- |
| 1     | StandardPC | Ingen spesiell modus, standard    |
| 544   | Dampteri   | Presenter seg selv som Steam Deck |

Den underliggende `EGamingDeviceType` typen som denne egenskapen er basert på inkluderer mer tilgjengelige verdier, Men etter det beste av vår kunnskap har de helt ikke gjort noe med dagens virkning, derfor ble de tilintetgjort for synlighet.

Hvis du er usikker på hvordan du setter denne egenskapen, la den være med standardverdien av `1`.

---

### `HoursUntilCarddrop`

`byte` type with default value of `3`. Denne eiendommen definerer hvis kontoen har kort dråper begrenset, og hvis ja, for hvor mange innledende timer. Begrensede kortdråper betyr at kontoen ikke mottar noen kortdråper fra gitt spill før spillet spilles av minst `HoursUntilCardDrops` timer. Dessverre er det ingen magiske måter å oppdage det, så ASF er avhengig av deg. Denne egenskapen har innvirkning på **[-oppgavelappens algoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** som vil bli brukt. Å sette riktig innhold vil maksimere resultatene og minimere tiden som kreves for at oppgavelappen skal forsvinne. Husk at det ikke finnes noe opplagt svar om du skal bruke en eller en annen verdi, siden den fullt ut avhenger av kontoen din. Det virker som om eldre kontoer som aldri krever refusjon har frie kortfaller, så de bør bruke en verdi av `0`, mens nye kontoer og de som ba om tilbakebetaling har begrenset kortfall med en verdi `3`. Dette er imidlertid bare teorien, og skal ikke tas som regel. Standardverdien for denne egenskapen ble satt med utgangspunkt i "mindre ond" og de fleste brukstilfeller.

---

### `Loobordtyper`

`ImmutableHashSet<byte>` type med standardverdi av `1, 3, 5` dampelementtyper. Denne egenskapen definerer ASF-oppførsel ved plyndring - begge manualer ved å bruke en **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, så vel som automatisk én, gjennom én eller flere konfigurasjonsegenskaper. ASF vil sikre at kun elementer fra `LootableTypes` vil bli inkludert i et handelstilbud. Derfor kan du velge hva du vil motta i et handelstilbud som sendes til deg.

| Verdi | Navn               | Beskrivelse                                                    |
| ----- | ------------------ | -------------------------------------------------------------- |
| 0     | Ukjent             | Hver type som ikke passer inn i noen av de nedenfor            |
| 1     | Boosterpakke       | Boosterpakke med 3 tilfeldige kort fra et spill                |
| 2     | Uttrykksikon       | Uttrykksikon som skal brukes i Steam Chat                      |
| 3     | FoilTradingCard    | Oljevariant av `TradingCard`                                   |
| 4     | Profilbakgrunn     | Profilbakgrunn for bruk på din Steam-profil                    |
| 5     | TradingCard        | Steam-handelskort, som brukes til å lage merker (ikke-folie)   |
| 6     | SteamGems          | Damp blir brukt til fremstilling av boostere, inkludert sekker |
| 7     | SalgGjenstand      | Spesialvarer som tildeles under Steam-salg                     |
| 8     | Forbruksvare       | Spesiell forbruksvarer som forsvinner etter bruk               |
| 9     | ProfilModifikator  | Spesial elementer som kan endre Steam profil utseende          |
| 10    | Klistremerke       | Spesiell gjenstander som kan brukes i Steam-chat               |
| 11    | ChatEffect         | Spesiell gjenstander som kan brukes i Steam-chat               |
| 12    | MiniProfilBakgrunn | Spesiell bakgrunn for Steam-profil                             |
| 13    | AvatarProfileFrame | Spesiell avatarramme for Steam profil                          |
| 14    | AnimatedAvatar     | Spesiell animert avatar for Steam-profil                       |
| 15    | Tastatur           | Spesiell tastaturskin for Steam-dekk                           |
| 16    | OppstartVideo      | Spesiell startvideo for Steam deck                             |

Vær oppmerksom på at uansett instillingene ovenfor ASF vil kun be om **[Steam-fellesskapsposter](https://steamcommunity.com/my/inventory/#753_6)** (`appID` av 753, `kontekstID` av 6), så alle spill, gaver og på samme måte er utelukket fra fagtilbudet som definisjon.

Standard ASF-innstilling er basert på den vanligste bruken av botten med kun plyndring av boosterpakker, og handelskort (inkludert folier). Egenskapen som defineres her lar deg endre oppførselen på hvilken måte som er oppfylt for deg. Husk at alle typer som ikke er definert ovenfor, vil vises som `Ukjent` type, noe som er spesielt viktig når ventilen frigir nye Steam-elementer, som vil bli merket som `Ukjent` av ASF også, til det er lagt til her (i fremtidig utgivelse). That's why in general it's not recommended to include `Unknown` type in your `LootableTypes`, unless you know what you're doing, and you also understand that ASF will send your entire inventory in a trade offer if Steam Network gets broken again and reports all your items as `Unknown`. Min sterke forslag er ikke å inkludere `Ukjent` -type i `LootableTypes`, selv om du forventer å plyndre alt (annet).

---

### `Maskinnavn`

`string` type with default value of `null`. ASF vil bruke denne egenskapen når du logger inn på Steam-nettverk, som kan brukes til tilpasninger når det gjelder hvordan nøyaktig Steam vil vise ASF-maskin og økt e. . når du viser enheter som er logget inn på **[her](https://store.steampowered.com/account/authorizeddevices)**.

ASF tilbyr noen spesielle variabler som du eventuelt kan bruke i teksten din. `{0}` blir erstattet med maskinnavn som angitt av OS, `{1}` blir erstattet med ASFs offentlige identifikator, mens `{2}` erstattes av ASFs versjon.

Med mindre du vet hva du gjør, bør du holde den med standardverdien av `null`. I dette tilfellet vil ASF beslutte internt om riktig verdi, som er `{0} ({1}/{2})` per i dag. Husk at dette er bare en forestilling om at Steam-nettverket kan eller ikke respektere seg fullt ut.

---

### `MatchbleTyper`

`ImmutableHashSet<byte>` type med standardverdi av `5` elementtyper. Denne egenskapen definerer hvilke Steam elementtyper som er tillatt å matche når `SteamTradeMatcher` alternativ i `TradingPreferences` er aktivert. Typer definert som nedenfor:

| Verdi | Navn               | Beskrivelse                                                    |
| ----- | ------------------ | -------------------------------------------------------------- |
| 0     | Ukjent             | Hver type som ikke passer inn i noen av de nedenfor            |
| 1     | Boosterpakke       | Boosterpakke med 3 tilfeldige kort fra et spill                |
| 2     | Uttrykksikon       | Uttrykksikon som skal brukes i Steam Chat                      |
| 3     | FoilTradingCard    | Oljevariant av `TradingCard`                                   |
| 4     | Profilbakgrunn     | Profilbakgrunn for bruk på din Steam-profil                    |
| 5     | TradingCard        | Steam-handelskort, som brukes til å lage merker (ikke-folie)   |
| 6     | SteamGems          | Damp blir brukt til fremstilling av boostere, inkludert sekker |
| 7     | SalgGjenstand      | Spesialvarer som tildeles under Steam-salg                     |
| 8     | Forbruksvare       | Spesiell forbruksvarer som forsvinner etter bruk               |
| 9     | ProfilModifikator  | Spesial elementer som kan endre Steam profil utseende          |
| 10    | Klistremerke       | Spesiell gjenstander som kan brukes i Steam-chat               |
| 11    | ChatEffect         | Spesiell gjenstander som kan brukes i Steam-chat               |
| 12    | MiniProfilBakgrunn | Spesiell bakgrunn for Steam-profil                             |
| 13    | AvatarProfileFrame | Spesiell avatarramme for Steam profil                          |
| 14    | AnimatedAvatar     | Spesiell animert avatar for Steam-profil                       |
| 15    | Tastatur           | Spesiell tastaturskin for Steam-dekk                           |
| 16    | OppstartVideo      | Spesiell startvideo for Steam deck                             |

Selvsagt omfatter typer du vanligvis bare `2`, `3`, `4` og `5`, som bare disse typene støttes av STM. ASF inneholder riktig logikk for å oppdage sjeldenhet av objektene, derfor er det også trygt å matche følelser eller bakgrunner, siden ASF ordentlig vil ta hensyn til rettferdig kun de elementene fra samme spill og type, som også deler samme raritet.

Vær oppmerksom på at **ASF ikke er en handelsbot** og **IKKE vil bry seg om markedsprisen**. Hvis du ikke tar for deg varer i samme rettighet fra samme sett som for å være samme prisviss, så IKKE dette alternativet for deg. Vennligst vurder to ganger hvis du forstår og godtar denne utsagnet før du bestemmer deg for å endre denne innstillingen.

Med mindre du vet hva du gjør, bør du holde det med standardverdien av `5`.

---

### `Onlineflagg`

`ushort flagg` type med standardverdien `0`. Denne egenskapen fungerer som et supplement til **[`OnlineStatus`](#onlinestatus)** og angir flere online tilstedeværelsesfunksjoner kunngjort i Steam-nettverket. Krever **[`OnlineStatus`](#onlinestatus)** bortsett fra `er frakoblet`og er definert som nedenfor:

| Verdi | Navn               | Beskrivelse                                            |
| ----- | ------------------ | ------------------------------------------------------ |
| 0     | Ingen              | Ingen spesielle online tilstedeværelsesflagg, standard |
| 2     | InJoinableGame     | Klienten er i samspill                                 |
| 8     | RemotePlayTogether | Klienten bruker ekstern spilling sammen økt            |
| 256   | ClientTypeWeb      | Klienten bruker webgrensesnitt                         |
| 512   | KlientTypeMobil    | Klienten bruker mobilappen                             |
| 1024  | ClientTypeTenfoot  | Klienten bruker stort bilde                            |
| 2048  | ClientTypeVR       | Klienten bruker VR headset                             |

Vennligst merk at denne egenskapen er `flagg` feltet, derfor er det mulig å velge en kombinasjon av tilgjengelige verdier. Sjekk ut **[json mapping](#json-mapping)** hvis du ønsker å lære mer. Ikke aktiverer noen av flaggresultatene i `Ingen` alternativ.

Den underliggende `EPersonaStateFlag` typen som denne egenskapen er basert på inkluderer mer tilgjengelige flagg, Men etter det beste av vår kunnskap har de helt ikke gjort noe med dagens virkning, derfor ble de tilintetgjort for synlighet.

Hvis du er usikker på hvordan du setter denne egenskapen, la den være med standardverdien av `0`.

---

### `OnlineStatus`

`byte` type with default value of `1`. Denne eiendommen spesifiserer Steam-samfunnsstatus som boten vil bli annonsert etter å ha logget inn på Steam-nettverket. Du kan velge en av følgende statuser:

| Verdi | Navn           |
| ----- | -------------- |
| 0     | Frakoblet      |
| 1     | Pålogget       |
| 2     | Opptatt        |
| 3     | Borte          |
| 4     | Utsett         |
| 5     | LookingToTrade |
| 6     | Se etter spill |
| 7     | Usynlig        |

`Tilstandsstatus` er ekstremt nyttig for primærkontoer. Som du burde vite viser jordbruk et spill faktisk din damp status som "Spilling spill: XXX", som kan være misvisende til vennene dine, forvirre dem at du spiller et spill mens du faktisk bare har det du vil tjene. Ved å bruke `Frakoblet` løser du dette problemet - kontoen din vil aldri bli vist som "i spill" når du driver dampkort med ASF. Det er mulig takket være at ASF ikke trenger å logge inn på Steam Community for å fungere ordentlig, så vi faktisk spiller disse spillene, koblet til Steam-nettverket, men uten å kunngjøre vår online-tilstedeværelse i det hele tatt. Husk at spill med frakoblet status vil telle mot din spilletid, og vise som "nylig spilt" på profilen din.

I tillegg er denne funksjonen viktig hvis du vil motta varsler og uleste meldinger når ASF kjører, mens du ikke har en Steam-klient åpent samtidig. Det skyldes at ASF fungerer som en Steam-klient selv, og om ASF ønsker det eller ikke Steam sender alle meldinger og andre arrangementer til den. Dette er ikke et problem hvis dere har både ASF og din egen Steam-klient kjører, siden begge klienter får nøyaktig samme hendelser. Hvis imidlertid bare ASF kjører, kan Steam-nettverk merke visse hendelser og meldinger som "levert", til tross for at den tradisjonelle Steam-klienten din ikke er tilstede. Frakoblet status løser også dette problemet, siden ASF aldri vurderes for noen samfunnshendelser i dette tilfellet. så alle uleste meldinger og andre hendelser vil bli riktig merket som uleste når du kommer tilbake.

Det er viktig å merke seg at ASF kjører på `Offline` modus vil **ikke** kunne motta kommandoer i vanlig Steam chat måte, så vel som hele samfunnets tilstedeværelse er faktisk helt og helt frakoblet. En løsning til dette problemet bruker `Usynlig` -modus i stedet som fungerer på en lignende måte (ikke eksponerer status), men har muligheten til å motta og svare på meldinger (slik at det også er et potensial for å avvise meldinger og uleste meldinger som angitt ovenfor). `Usynlig` -modus gjør den mest fornuftige annets kontoer som du ikke vil utsette (status), men kan fremdeles sende kommandoer til.

Men det er en fangst med `usynlig` -modus - den går ikke godt i bruk av primærkontoer. Dette er fordi **any** Steam-økt som for tiden er pålogget **eksponerer** statusen, selv om ASF selv ikke er det. Dette er forårsaket av gjeldende begrensninger/feil av Steam-nettverket som ikke er mulig å bli fikset på ASF-siden, så hvis du vil bruke `Usynlig` -modus, må du også forsikre deg om at **alle** andre økter til samme konto bruker `Usynlig` -modus også. Dette vil skje ved stans i kontoene hvor ASF forhåpentligvis er den eneste aktive sesjonen, men på hovedkontoen vil du nesten alltid foretrekke å vise som `Online` til vennene dine, Skjuler bare ASF-aktivitet, og i denne modusen `usynlig` er helt ubrukelig for deg (vi anbefaler å bruke `Offline` modus i stedet). Forhåpentligvis denne begrensningen/feilen vil bli løst i fremtiden av ventilen, men jeg vil ikke forvente at det skal skje noen gang...

Hvis du er usikker på hvordan du setter opp denne egenskapen, det er anbefalt å bruke en verdi av `0` (`Frakoblet`for primærkontoer, og standard `1` (`Online`) ellers.

---

### `Passordformat`

`byte` type med standardverdien `0` (`PlainText`). Denne egenskapen definerer formatet på `verdien fra SteamPassword` og støtter for tiden verdier spesifisert i **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** delen. Du må følge instruksene som er angitt der. da du må forsikre deg om at `SteamPassword` ikke inneholder passord ved samsvaring i `passordformat`. med andre ord når du endrer `PasswordFormat` må da `SteamPassword` være **allerede** i det formatet, ikke bare sikte på å være. Med mindre du vet hva du gjør, bør du holde det med standardverdien av `0`.

Hvis du bestemmer deg for å endre `PasswordFormat` av en bot som allerede har logget inn på Steam-nettverket minst én gang, det er mulig at du får engangs dekrypter feil ved neste bots start - dette er forårsaket av at `PasswordFormat` også brukes i forhold til automatisk kryptering/dekryptering av sensitive egenskaper i `Bot. b` databasefil. Du kan trygt ignorere at feilen siden ASF vil kunne komme tilbake fra denne situasjonen alene. Hvis det skjer konstant, men for eksempel hver omstart, bør det undersøkes.

---

### `Redeeminginnstillinger`

`byte flagg` type med standardverdien `0`. Denne egenskapen definerer ASF-atferd ved innløsning av cd-nøkler og er definert som nedenfor:

| Verdi | Navn                          | Beskrivelse                                                                                                                 |
| ----- | ----------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| 0     | Ingen                         | Ingen spesielle innløsningsinnstillinger, standard                                                                          |
| 1     | Videresender                  | Videresend nøkler er ikke tilgjengelige for å løse inn til andre boter                                                      |
| 2     | Fordeler                      | Distribuer alle nøkler blant seg selv og andre boter                                                                        |
| 4     | KeepMissingGames              | Behold nøkler for (potensielt) manglende spill under videresende, og etterlat dem ubrukte                                   |
| 8     | AssumeWalletKeyOnBadationCode | Forsett at `BadActivationCode` nøkler er lik `CannotRedeemCodeFromClient`, og prøv derfor å løse dem inn som lommeboknøkler |

Vennligst merk at denne egenskapen er `flagg` feltet, derfor er det mulig å velge en kombinasjon av tilgjengelige verdier. Sjekk ut **[json mapping](#json-mapping)** hvis du ønsker å lære mer. Ikke aktiverer noen av flaggresultatene i `Ingen` alternativ.

`Forwarding` will cause bot to forward a key that is not possible to redeem, to another connected and logged on bot that is missing that particular game (if possible to check). Den vanligste situasjonen er å videresende `Anskaffet` spill til en annen bot som mangler det bestemte spillet, men dette alternativet dekker også andre scenarier, slikt som `DoesNotOwnRequiredApp`, `RateLimited` eller `OmrådetLand`.

`distribuerer` vil føre til at alle mottatte nøkler distribueres mellom seg og andre boter. Det betyr at hver bot vil få én nøkkel fra batchen. Vanligvis brukes dette bare når du innløser mange nøkler til samme spill, Og du vil fordele dem jevnt mellom dine boter, i motsetning til å innløse nøkler mot forskjellige spill. Denne funksjonen gir ingen mening hvis du bare løser inn én nøkkel i en `redeem` handling (som det er ingen ekstra nøkler å distribueres).

`KeepMissingGames` vil få bot til å hoppe over `Forwarding` når vi ikke kan være sikker på om nøkkel blir innløst faktisk eid av vår bot, eller ikke. Dette betyr i utgangspunktet at `videresending` kun vil bruke **** på `Grupperte` nøkler som er under bruk, i stedet for å dekke andre saker som `DoesNotOwnRequiredApp`, `RateLimited` eller `RestrictedCountry`. Vanligvis ønsker du å bruke dette alternativet på primær konto, for å sikre at nøkler som innløses på det vil ikke bli videresendt videre hvis boten din for eksempel blir midlertidig `ratLimited`. Som du kan gjette av beskrivelsen, har dette feltet absolutt ingen effekt hvis `Forwarding` ikke er aktivert.

`AssumeWalletKeyOnBadationCode` gjør at `BadActivationCode` nøkler skal behandles som `CannoteemCodeFromClient`, resultere i ASF og prøver derfor å løse dem inn som lommeboknøkler. Dette er nødvendig fordi Steam kunne annonsere lommeboknøkler som `BadActivationCode` (og ikke `CannotRedeemCodeFromClient` som det er brukt til), resulterende i ASF forsøker aldri å innløse dem. Men vi anbefaler likevel at **mot** bruker denne innstillingen, som det vil resultere i ASF som prøver å løse inn hver ugyldig nøkkel som en lommebokkode, resulterende i for stor mengde (potensielt ugyldige) forespørsler sendt til Steam-tjenesten, med alle de potensielle konsekvensene. I stedet vi anbefaler å bruke `ForceAssumeWalletKey` **[`innløser^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** modus mens du bevisst løsner, som vil aktivere den nødvendige runden bare når det er nødvendig, ved behov.

Aktivering av både `videresending` og `distribuerer` vil legge til distribueringsfunksjon oppå viderekobling en, som får ASF til å innløse en nøkkel på alle botter først (fremover) før du går til den neste (distribuerer). Typisk vil du bruke dette alternativet bare når du vil `Videresending`, men med endret oppførsel for å slå boten på nøkkel som brukes, i stedet for alltid å gå i rekkefølge med hver nøkkel (som ville være `videresende` alene). This behaviour can be beneficial if you know that majority or even all of your keys are tied to the same game, because in this situation `Forwarding` alone would try to redeem everything on one bot firstly (which makes sense if your keys are for unique games), and `Forwarding` + `Distributing` will switch the bot on the next key, "distributing" the task of redeeming new key onto another bot than the initial one (which makes sense if keys are for the same game, skipping one pointless attempt per key).

Riktig bots orden i alle innløsningsscenarier er alfabetisk sett bortsett fra botter som ikke er tilgjengelige (ikke tilkoblet, stoppet eller likeså). Vær oppmerksom på at det er per IP og per konto timelister for innløsende forsøk, og alle innløsere prøver som ikke var ferdig med `OK` bidrar til mislykkede forsøk. ASF vil gjøre sitt beste for å minimere antall `AlreadyPurchased` feiler, f.eks ved å forsøke å unngå videresending av en nøkkel til en annen bot som allerede eier det bestemte spillet, men det er ikke alltid garantert å fungere på grunn av hvordan Steam håndterer lisenser. Bruk av flagg som `videresending` eller `Distribuering` vil alltid øke din likelyhood til å treffe `Vurderingsbegrenset`.

Husk også at du ikke kan videresende eller distribuere nøkler til botter som du ikke har tilgang til. Dette bør være åpenbart men sørg for at du er minst `operatør` av alle botene du vil inkludere i innløsningsprosessen, for eksempel med `status ASF` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `Fjernkommunikasjon`

`byte flagg` type med standardverdien `3`. Denne egenskapen definerer atferd per bot ASF når den gjelder kommunikasjon med fjernstyrte, tredjeparts tjenester, og er definert som nedenfor:

| Verdi | Navn                     | Beskrivelse                                                                                                                                                                                                                                                    |
| ----- | ------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Ingen                    | Ingen tillatt tredjeparts kommunikasjon, som gjengir valgte ASF-funksjoner er ubrukelige                                                                                                                                                                       |
| 1     | Dampegruppe              | Tillater kommunikasjon med **[ASFs Steam-gruppe](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                 |
| 2     | Publikasjonens oppføring | Tillater kommunikasjon med **[ASF's STM-liste](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** for å bli oppført hvis brukeren også har aktivert `SteamTradeMatcher` i **[`TradingPreferences`](#tradingpreferences)** |

Vennligst merk at denne egenskapen er `flagg` feltet, derfor er det mulig å velge en kombinasjon av tilgjengelige verdier. Sjekk ut **[json mapping](#json-mapping)** hvis du ønsker å lære mer. Ikke aktiverer noen av flaggresultatene i `Ingen` alternativ.

Dette alternativet inkluderer ikke alle tredjeparts kommunikasjon som tilbys av ASF, bare de som ikke er underforstått av andre innstillinger. Hvis du har aktivert ASFs automatiske oppdateringer, ASF vil for eksempel kommunisere med både GitHub (for nedlastinger) og vår server (for kontrollsum verifikasjon), i henhold til din konfigurasjon. Likeledes, aktivering av `MatchActively` i **[`TradingPreferences`](#tradingpreferences)** innebærer kommunikasjon med vår server for å hente listet opp bots, som er påkrevd for den funksjonaliteten.

Ytterligere forklaring på dette emnet er tilgjengelig i Avsnitt **[ekstern kommunikasjon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

### `SendTradePeriode`

`byte` type with default value of `0`. Denne egenskapen fungerer som en veldig lik `SendOnFarmingferdig` preferanse i `FarmingPreferences`, med én forskjell – i stedet for å sende handel når oppdrett foregår, Vi kan også sende den hver `SendTradePeriode` timer, uansett hvor mye vi har til gård igjen. Dette er nyttig hvis du vil `loot` dine stalt kontoer på vanlig basis i stedet for å vente på at den skal bli oppdrett. Standardverdien for `0` deaktiverer denne funksjonen hvis du vil at din bot skal sende deg til å handle. . hver dag bør du legge `24` her.

Typisk vil du bruke **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** sammen med denne funksjonen, Selv om det ikke er et krav hvis du har tenkt å håndtere 2FA bekreftelser manuelt til rett tid. Hvis du er usikker på hvordan du setter denne egenskapen, la den være med standardverdien av `0`.

---

### `Steampålogging`

`string` type with default value of `null`. Denne egenskapen definerer dampinnlogging - den du bruker for å logge inn på damp. I tillegg til å definere dampinnlogging her, du kan også beholde standardverdien av `null` hvis du vil skrive inn din dampinnlogging på hver ASF oppstart i stedet for å sette den i konfigurasjonen. Dette kan være nyttig for deg hvis du ikke vil lagre sensitive data i konfigurasjonsfilen.

---

### `SteamMasterClanID`

`ulong` type with default value of `0`. Denne egenskapen definerer steamID for dampgruppen som boten skal automatisk delta i, inkludert gruppesamtale. You can check steamID of your group by navigating to its **[page](https://steamcommunity.com/groups/archiasf)**, then adding `/memberslistxml?xml=1` to the end of the link, so the link will look like **[this](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. Deretter kan du få steamID i gruppen din fra resultatet, det er i `<groupID64>` taggen. I ovennevnte eksempel ville det være `103582791440160998`. I tillegg til å forsøke å bli med i en gitt gruppe ved oppstart, vil boten automatisk akseptere invitasjoner til denne gruppen. som gjør det mulig for deg å invitere boten din manuelt hvis gruppen din har privat medlemskap. Hvis du ikke har noen gruppe dedikert for dine bots, bør du beholde denne egenskapen med standardverdien ``.

---

### `SteamParentalkode`

`string` type with default value of `null`. Denne egenskapen definerer din foreldreløse PIN. ASF krever tilgang til ressurser som er beskyttet av dampforeldre, derfor hvis du bruker denne funksjonen, du bør ha ASF med foreldrelås PIN-koden, slik at den kan operere normalt. Standardverdien for `null` betyr at det ikke er nødvendig med noen Steam-foreldrekode for å låse opp denne kontoen, og dette er sannsynligvis hva du ønsker hvis du ikke bruker steam foreldrefunksjonalitet.

I begrensede tilfeller kan ASF også generere en gyldig innsatt Steam-foreldrekode selv. selv om det krever for mye av OS-ressurser og ekstra tid for å fullføre, for å nevne at det ikke er garantert å lykkes, derfor anbefaler vi å ikke stole på den funksjonen og i stedet sette inn gyldig `SteamParentalCode` i konfigurasjonen for ASF som skal brukes. Hvis ASF fastslår at PIN er påkrevd, og det ikke er mulig å generere en av disse selv, vil du be om inngang.

---

### `SteamPassord`

`string` type with default value of `null`. Denne egenskapen definerer damppassordet ditt - det du bruker for å logge inn på på damp. I tillegg til å definere damppassord her, du kan også beholde standardverdien av `null` hvis du vil skrive inn ditt Steam-passord for hver ASF-oppstart i stedet for å sette det i konfigurasjonen. Dette kan være nyttig for deg hvis du ikke vil lagre sensitive data i konfigurasjonsfilen.

---

### `SteamTradeToken`

`string` type with default value of `null`. Når du har din bot på vennelisten, kan du sende en handel til deg uten å bekymre deg om å bytte token. derfor kan du forlate denne egenskapen til standardverdien av `null`. Hvis du derimot bestemmer deg for å IKKE ha din bot på vennelisten din, deretter må du generere og fylle et handelstoken siden brukeren som denne boten forventer å sende transaksjoner til. med andre ord Denne egenskapen bør fylles med handelstoken for kontoen som er definert med `Master` tillatelse i `SteamUserPermissions` av **denne** botten forekomsten.

For å finne din token, som bruker med `Master` -tilgang naviger **[her](https://steamcommunity.com/my/tradeoffers/privacy)** og ta en titt på handelsadressen din. Tokenet vi leter etter er laget av 8 tegn fra `&token=` del i handelsURL. Du bør kopiere de 8 tegnene her, som `SteamTradeToken`. Ikke inkluder hele trading URL, ingen `&token=` -del, bare token selv (8 tegn).

---

### `Steambrukerrettigheter`

`ImmutableDictionary<ulong, byte>` -type med standardverdien for å være tom. Denne egenskapen er en ordbok som kartlegger en Steam-bruker med sin 64-biters damp-ID, til `byte` nummer som angir sin tillatelse i ASF-tilfeller. Tilgjengelige bot rettigheter i ASF er definert som:

| Verdi | Navn          | Beskrivelse                                                                                                                                                                                             |
| ----- | ------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Ingen         | Ingen spesiell tillatelse, dette er hovedsakelig en referanseverdi som er tildelt damp-IDer som mangler i denne ordlisten - det er ikke nødvendig å definere noen som har denne tillatelsen             |
| 1     | Familiedeling | Tilbyr minimum tilgang for familiedeling av brukere. Igjen er dette hovedsakelig en referanseverdi siden ASF er i stand til å automatisk oppdage damp-IDer som vi har tillatt å bruke biblioteket vårt. |
| 2     | Operatør      | Gir grunnleggende tilgang til gitte bot-forekomster, som hovedsakelig legger til lisenser og innløse nøkler                                                                                             |
| 3     | Mester        | Gir full tilgang til gitt bot forekomst                                                                                                                                                                 |

Kort sagt, denne egenskapen lar deg håndtere tillatelser for gitte brukere. Rettigheter er hovedsakelig viktige for tilgang til ASF **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, men også for å tillate mange ASF-funksjoner, for eksempel aksept av handler. For eksempel vil du kanskje sette din egen konto til `Master`, og gi `Operatør` tilgang til 2-3 av vennene dine slik at de enkelt kan innløse nøkler for boten din med ASF, mens **ikke** kvalifiseres. for å stoppe den. Takket være at du enkelt kan tilordne tillatelser til gitte brukere og la dem bruke boten din til noen spesifisert av deg grader.

We recommend to set exactly one user as `Master`, and any amount you wish as `Operators` and below. Selv om det er teknisk mulig å sette flere `Mestere` og ASF vil fungere riktig med dem, for eksempel ved å godta alle sine handler sendt til boten, ASF bruker bare én av dem (med laveste damp-ID) for hvert tiltak som krever ett enkelt mål, for eksempel en `loot` -forespørsel, så også egenskaper som `SendOnFarmingFerdig` preferanse i `FarmingPreferences` eller `SendTradePeriod`. Hvis du forstår disse begrensningene fullstendig, spesielt det faktum at `loot` alltid vil sende varer til `Mester` med laveste damp-ID, uavhengig av `Master` som faktisk utførte kommandoen, så kan du definere flere brukere med `Master` -tillatelse her, men vi anbefaler fortsatt en enkelt masterordning.

It's nice to note that there is one more extra `Owner` permission, which is declared as `SteamOwnerID` global config property. You can't assign `Owner` permission to anybody here, as `SteamUserPermissions` property defines only permissions that are related to the bot instance, and not ASF as a process. For botrelaterte oppgaver, `SteamOwnerID` behandles det samme som `Master`, så den definerer din `SteamOwnerID` her er ikke nødvendig.

---

### `TradeCheckPeriode`

`byte` type with default value of `60`. Normalt ASF håndterer inngående tilbud rett etter å ha mottatt varsel om en, men noen ganger på grunn av Steam glitches det ikke kan gjøre det på det tidspunktet. og slike handelstilbud kan ikke sees bort fra før neste handelsmelding eller bot starter på nytt, som kan føre til at handlene blir kansellert eller elementer ikke er tilgjengelige senere på det tidspunktet. Hvis dette parameteret er satt til en ikke-null verdi, vil ASF i tillegg sjekke for slike utestående fag hver `TradeCheckPeriode` minutter. Standardverdi er valgt med saldo mellom flere forespørsler til damptjenere og tap av innkommende handler. Hvis du bare bruker ASF til gårdskort og ikke planlegger å automatisk behandle noen innkommende handler, du kan sette den til `0` for å deaktivere denne funksjonen fullstendig. På den andre hånden hvis boten din deltar i den offentlige [ASAs STM oppføring](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) eller tilbyr andre automatiske tjenester som handelsbot, du ønsker kanskje å redusere denne parameteren til `15` minutter, eller så for å behandle alle handler innen rimelig tid.

---

### `TradingPreferences`

`byte flagg` type med standardverdien `0`. Denne egenskapen definerer ASF-atferd i handel, og er definert som nedenfor:

| Verdi | Navn                  | Beskrivelse                                                                                                                                                                                                             |
| ----- | --------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Ingen                 | Ingen spesielle handelspreferanser, standard                                                                                                                                                                            |
| 1     | Aksepterte donasjoner | Aksepterer handler der vi ikke mister noe                                                                                                                                                                               |
| 2     | SteamTradeMatcher     | Faktisk deltar i **[STM](https://www.steamtradematcher.com)**lignende fagområder. Besøk **[handel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** for mer info                        |
| 4     | MatchAlt              | Krever `SteamTradeMatcher` og i kombinasjon med den – også aksepteres dårlig handel i tillegg til gode og nøytrale                                                                                                      |
| 8     | DontAcceptBotTrades   | Godkjenn ikke automatisk `loot` trades fra andre bot instanser                                                                                                                                                          |
| 16    | Matchactively         | Aktivt deltar i **[STM](https://www.steamtradematcher.com)**-lignende handler. Besøk **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** for mer informasjon |

Vennligst merk at denne egenskapen er `flagg` feltet, derfor er det mulig å velge en kombinasjon av tilgjengelige verdier. Sjekk ut **[json mapping](#json-mapping)** hvis du ønsker å lære mer. Ikke aktiverer noen av flaggresultatene i `Ingen` alternativ.

For ytterligere forklaring av ASF handel logikk og beskrivelse av hvert tilgjengelige flagg, besøk **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**.

---

### `Overføringstyper`

`ImmutableHashSet<byte>` type med standardverdi av `1, 3, 5` dampelementtyper. Denne egenskapen definerer hvilke Steam item typer som vil bli vurdert for overføring mellom bots, under `transfer` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. ASF vil sikre at kun elementer fra `TransferableTypes` vil bli inkludert i et handelstilbud, Derfor kan du velge hva du vil motta i et handelstilbud som blir sendt til en av dine boter.

| Verdi | Navn               | Beskrivelse                                                    |
| ----- | ------------------ | -------------------------------------------------------------- |
| 0     | Ukjent             | Hver type som ikke passer inn i noen av de nedenfor            |
| 1     | Boosterpakke       | Boosterpakke med 3 tilfeldige kort fra et spill                |
| 2     | Uttrykksikon       | Uttrykksikon som skal brukes i Steam Chat                      |
| 3     | FoilTradingCard    | Oljevariant av `TradingCard`                                   |
| 4     | Profilbakgrunn     | Profilbakgrunn for bruk på din Steam-profil                    |
| 5     | TradingCard        | Steam-handelskort, som brukes til å lage merker (ikke-folie)   |
| 6     | SteamGems          | Damp blir brukt til fremstilling av boostere, inkludert sekker |
| 7     | SalgGjenstand      | Spesialvarer som tildeles under Steam-salg                     |
| 8     | Forbruksvare       | Spesiell forbruksvarer som forsvinner etter bruk               |
| 9     | ProfilModifikator  | Spesial elementer som kan endre Steam profil utseende          |
| 10    | Klistremerke       | Spesiell gjenstander som kan brukes i Steam-chat               |
| 11    | ChatEffect         | Spesiell gjenstander som kan brukes i Steam-chat               |
| 12    | MiniProfilBakgrunn | Spesiell bakgrunn for Steam-profil                             |
| 13    | AvatarProfileFrame | Spesiell avatarramme for Steam profil                          |
| 14    | AnimatedAvatar     | Spesiell animert avatar for Steam-profil                       |
| 15    | Tastatur           | Spesiell tastaturskin for Steam-dekk                           |
| 16    | OppstartVideo      | Spesiell startvideo for Steam deck                             |

Vær oppmerksom på at uansett instillingene ovenfor ASF vil kun be om **[Steam-fellesskapsposter](https://steamcommunity.com/my/inventory/#753_6)** (`appID` av 753, `kontekstID` av 6), så alle spill, gaver og på samme måte er utelukket fra fagtilbudet som definisjon.

Standard ASF-innstilling er basert på den vanligste bruken av botten med overføring av kun boosterpakker, og handelspartnerkort (inkludert folier). Egenskapen som defineres her lar deg endre oppførselen på hvilken måte som er oppfylt for deg. Husk at alle typer som ikke er definert ovenfor, vil vises som `Ukjent` type, noe som er spesielt viktig når ventilen frigir nye Steam-elementer, som vil bli merket som `Ukjent` av ASF også, til det er lagt til her (i fremtidig utgivelse). That's why in general it's not recommended to include `Unknown` type in your `TransferableTypes`, unless you know what you're doing, and you also understand that ASF will send your entire inventory in a trade offer if Steam Network gets broken again and reports all your items as `Unknown`. Min sterke forslag er ikke å inkludere `Ukjent` -type i `TransferableTypes`, selv om du forventer å overføre alt.

---

### `BrukLogg nøkler`

`bool` type with default value of `true`. Denne egenskapen definerer hvis ASF bør bruke tilgangsnøkkelmekanisme for denne Steam-kontoen. Innloggingsnøkler fungerer veldig likt den offisielle Steamklientens "husk meg" alternativ, som gjør det mulig for ASF å lagre og bruke midlertidig engangsbruk innloggingsnøkkel til neste påloggingsforsøk, Hopper faktisk over behov for å oppgi passord, Steam-vakten eller 2FA-kode så lenge innloggingsnøkkelen er gyldig. Login nøkkelen er lagret i `BotName.db` -filen og oppdatert automatisk. Dette er grunnen til at du ikke trenger å oppgi passord/SteamGuard/2FA kode etter innlogging med ASF bare én gang.

Innloggingsnøkler blir brukt som standard for ditt bekvemmelighet, så du ikke trenger å skrive inn `SteamPassword`, SteamGuard eller 2FA-kode (hvis du ikke bruker **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**) på hver pålogging. Det er også overlegen alternativ siden påloggingsnøkkel kan brukes kun på én gang, og viser ikke det opprinnelige passordet ditt på noen måte. Nøyaktig den samme metoden blir brukt av din originale Steam-klient, som sparer ditt kontonavn og innloggingsnøkkel til din neste påloggingsforsøk, faktisk er det samme som å bruke `SteamLogin` med `UseLoginKeys` og tom `SteamPassword` i ASF.

Men noen kan være bekymret for de små detaljene, Derfor er dette valget tilgjengelig her hvis du ønsker å forsikre deg om at ASF ikke lagrer noen slags token som tillater gjenopptakelse av tidligere sesjon etter avsluttning, som vil resultere i at full autentisering er obligatorisk i hvert innloggingsforsøk. Deaktivering av dette alternativet fungerer akkurat som det ikke krysser av for "husk meg" i offisiell Steam-klient. Med mindre du vet hva du gjør, bør du holde det med standardverdien `sann`.

---

### `Brukergrensesnitt`

`byte` type with default value of `0`. Denne egenskapen angir brukergrensesnittmodus som boten vil bli annonsert etter at du har logget inn på Steam-nettverket. Det kan påvirke hvordan kontoen er synlig, f.eks på Steam-chatten, hvis din tilstedeværelse tillater at gjennom `OnlineStatus`. Du kan velge en av under modus:

| Verdi | Navn       | Beskrivelse                |
| ----- | ---------- | -------------------------- |
| `0`   | VGUI       | Standard Steam-klientmodus |
| `1`   | Tenfoot    | Stor bildemodus            |
| `2`   | Mobil      | Steam mobilapp             |
| `3`   | Nett       | Nettleser økt              |
| `5`   | MobileChat | Steam mobils chat app      |

Den underliggende typen `EUIMode` som denne egenskapen er basert på inkluderer imidlertid mer tilgjengelige verdier. Etter det beste av vår kunnskap har de helt fra i dag ikke gjort noe med dagens virkning, derfor var de tilsiktet. Du kan også være interessert i å sjekke `GamingDeviceType`, siden noen tilleggsfunksjoner er aktivert der.

Hvis du er usikker på hvordan du setter denne egenskapen, la den være med standardverdien av `0`.

---

### `Webproxy`

`string` type with default value of `null`. Denne egenskapen definerer en webproxy-adresse som vil bli brukt for bot-spesifikk intern http-relatert kommunikasjon, spesielt for tjenester som `api. teampowered.com`, `steamcommunity.com` og `store.steampowered.com`. Hvis ikke angitt, vil ASF bruke global `WebProxy` innstilling spesifisert ovenfor i stedet. Angående ASF-forespørsler kan være uvanlig nyttige for å omgå ulike typer brannmurer, særlig den store brannmuren i Kina.

Denne egenskapen er definert som URI streng:

> En URI-streng er sammensatt av en ordning (støttet: http/https/socks4/socks4a/socks5), en vert, og en valgfri port. Et eksempel på en fullstendig uri streng er `"http://contoso.com:80"`.

Dersom proxy krever brukerautentisering, må du også sette opp `WebProxyUsername` og/eller `WebProxyPassword`. Etablering av denne eiendommen er tilstrekkelig dersom det ikke oppstår et slikt behov.

Hvis du også trenger proxytting av interne Steam-nettverk (CMs) da bør du sørge for å konfigurere **[`SteamProtocols`](#steamprotocols)** botens eiendom til en verdi som bare tillater Websocket transport, i. . Verdien `4`, da bare websockets støttes for proxying.

Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

### `Nettstedspassord`

`string` type with default value of `null`. Denne egenskapen definerer passordfeltet som brukes i grunnleggende, digest, NTLM, og Kerberos godkjenning som støttes av en mål- `WebProxy` maskin som sørger for proxy-funksjonalitet. Hvis din proxy ikke krever brukerlegitimasjon er det ikke nødvendig for deg å legge inn noe her. Å bruke dette alternativet er fornuftig bare hvis `WebProxy` er brukt, siden det ikke har noen effekt.

Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

### `WebProxyUsername`

`string` type with default value of `null`. Denne egenskapen definerer navnefeltet for brukernavn som brukes i basisk, digest, NTLM, og Kerberos godkjenning som støttes av en mål- `WebProxy` maskin som sørger for proxy-funksjonalitet. Hvis din proxy ikke krever brukerlegitimasjon er det ikke nødvendig for deg å legge inn noe her. Å bruke dette alternativet er fornuftig bare hvis `WebProxy` er brukt, siden det ikke har noen effekt.

Med mindre du har en grunn til å redigere denne egenskapen, bør du beholde den til standard.

---

## Fil struktur

ASF bruker ganske enkel filstruktur.

```text
∙∙📁 config
″εεε∙ASF. son
ofimεεε∙ASF.db
εε″Bot1. son
ofimεε∙Bot1.db
εεε″Bot2. son
➠ εεεεεBot2.db
＋ εε″...
∙ε″ArchiSteamFarm.dll
ε″″″log.txt
εε″...
```

For å flytte ASF til ny sted, for eksempel en annen PC, er det nok å flytte/kopiere `config` katalogen alene, og det er den anbefalte måten å gjøre alle former for "ASF-sikkerhetskopier", på siden du alltid kan laste ned den gjenværende (programmet) delen fra GitHub, uten å risikere å avbryte interne ASF-filer, e. . gjennom en defekt sikkerhetskopiering.

`log.txt` inneholder loggen generert av din siste ASF kjører. Denne filen inneholder ingen sensitiv informasjon, og er svært nyttig når det gjelder problemer. krasjer eller rett og slett som en informasjon om hva som skjedde i siste ASF kjører. Vi vil ofte spørre om denne filen hvis du kommer inn på problemer eller feil. ASF behandler filen automatisk for deg, men du kan ytterligere tilpasse ASF **[logging](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging)** modul hvis du er avansert bruker.

Mappen `config` er stedet som innehar konfigurasjon for ASF, inkludert alle bottene.

`ASF.json` er en global ASF-konfigurasjonsfil. Denne konfigurasjonen brukes til å angi hvordan ASF fungerer som en prosess, som påvirker alle botene og programmet selv. Du kan finne globale egenskaper der, slik som ASF prosesseier, auto-oppdateringer eller feilsøking.

`BotName.json` er en konfigurasjon av gitt bot instans. Denne konfigurasjonen brukes til å angi hvordan gitt bot forekomst oppfører seg, derfor er disse innstillingene spesifikke for den boten bare og ikke delt på tvers av andre. Dette gjør at du kan konfigurere bots med ulike forskjellige innstillinger, og ikke nødvendigvis alle som jobber på akkurat samme måte. Hver bot navngis med unik identifikator, valgt av deg i stedet for `BotName`.

Bortsett fra konfigurasjonsfiler, ASF bruker også `config` mappen for lagring av databaser.

`ASF.db` er en global ASF-databasefil. Det virker som en global vedvarende lagring, og brukes til å lagre forskjellig informasjon knyttet til ASF-prosesser, for eksempel IP-adresser til lokale Steam-tjenere. **Du kan ikke redigere denne filen**.

`BotName.db` er en database med gitt bot instans. Denne filen brukes til å lagre viktige data om gitt bot instans i vedvarende lagring, som innloggingsnøkler eller ASF 2FA. **Du kan ikke redigere denne filen**.

`BotName.keys` er en spesiell fil som kan brukes til å importere nøkler til **[bakgrunnsspill innløser](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. Det er ikke obligatorisk eller ikke generert, men gjenkjent av ASF. Denne filen slettes automatisk etter at nøkler er importert.

`BotName.maFile` er en spesialfil som kan brukes til å importere **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**. Det er ikke obligatorisk eller ikke generert, men gjenkjent av ASF hvis `BotName` ikke bruker ASF 2FA ennå. Denne filen slettes automatisk etter at ASF 2FA er importert.

---

## JSON mapping

Alle konfigurasjonsinnstillinger har sin type. Type egenskap definerer verdier som er gyldige for den. Du kan bare bruke verdier som er gyldige for den angitte typen - hvis du bruker ugyldig verdi, da vil ASF ikke kunne analysere konfigurasjonen din.

**Vi anbefaler på det sterkeste å bruke ConfigGenerator til generering av configs** - den håndterer mesteparten av lavnivåinnholdet (for eksempel validering) for deg, så du bare trenger å sette inn gode verdier, og du trenger ikke forstå variable typer som er angitt nedenfor. Denne delen er for folk som genererer/redigerer konfigurasjoner manuelt, slik at de vet hvilke verdier de kan bruke.

Typer som brukes av ASF, er vanlige C# typer, som er angitt nedenfor:

---

`bool` - Boolsk type godtar bare `sann` og `falske verdier`.

Eksempel: `"Aktivert": true`

---

`byte` - Usignert byte type, godta kun heltall fra `0` til `255` (inkludert).

Eksempel: `"ConnectionTimeout": 90`

---

`ushort` - Usignert korttype, godtar bare heltall fra `0` til `65535` (inkludert).

Eksempel: `"WebLimiterDelay": 300`

---

`uint` - Usignert heltall, godtar bare heltall fra `0` til `4294967295` (inklusive).

---

`ulong` - Usignert langt heltall, og aksepter kun heltall fra `0` til `18446744073709551615` (inkluderende).

Eksempel: `"SteamMasterClanID": 103582791440160998`

---

`streng` - strengstype, godtar alle tegnsekvenser inkludert tom sekvens `""` og `null`. Tom sekvens og `null` -verdien behandles samme av ASF, så det er opp til din preferanse som en du vil bruke (vi registrerer med `null`).

Eksempler: `"SteamLogin": null`, `"Steamlogin": ""`, `"SteamLogin": "MyAccountName"`

---

`Guid?` - Nullabel UUID-type, i JSON kodet som streng. UUID er laget av 32 heksadesimale tegn, i området fra `0` til `9` og `a` til `f`. ASF aksepterer variasjonen i gyldige formater - små bokstaver, store bokstaver, med og uten bindestreker. I tillegg til gyldig UUID, ettersom denne egenskapen er null, en spesiell verdi av `null` er akseptert for å indikere mangel på UUID å leverandør.

Eksempler: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableList<valueType>` - Immutable collection (list) of values in given `valueType`. I JSON er det definert som en liste med elementer i gitt `valueType`. ASF bruker `liste` for å indikere at gitt egenskap støtter flere verdier og at deres rekkefølge kan være relevant.

Eksempel for `ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` - Immutable collection (set) av unike verdier i gitt `verditype`. I JSON er det definert som en liste med elementer i gitt `valueType`. ASF bruker `HashSet` for å vise at gitt egenskap er fornuftig bare for unike verdier og at deres ordre ikke har noe å gjøre, Derfor vil det med hensikt ignorere eventuelle duplikater under analysering (hvis du fant dem uansett).

Eksempel for `ImmutableHashSet<uint>`: `"Blacklist": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>` - Immutable ordbok (kart) som kartlegger en unik nøkkel spesifisert i sin `nøkkeltype`, til verdien angitt i `-verditype`. I JSON er det definert som et objekt med nøkkelverdi-par. Husk at `keyType` alltid angis i dette tilfellet, selv om det er en verdi som f.eks. `ulong`. Det stilles også strenge krav til at nøkkel skal være unikt på tvers av kartet, også denne gangen ble tvunget av JSON.

Eksempel for `ImmutableDictionary<ulong, byte>`: `"SteamUserPermissions": { "765611981748138": 3, "76561198174813137": 1 }`

---

`markerer` - Flaggs-attributt kombinerer flere ulike egenskaper til en endelig verdi ved å bruke bitkloke operasjoner. Det gjør at du kan velge en mulig kombinasjon av ulike forskjellige tillatte verdier samtidig. Den endelige verdien bygges som en sum av verdier av alle aktiverte alternativer.

For eksempel gitt følgende definisjon:

| Verdi | Navn  |
| ----- | ----- |
| 0     | Ingen |
| 1     | A     |
| 2     | B     |
| 4     | K     |

Det er nøyaktig 3 meningsfulle, tilgjengelige flagg til å skru på/av (`A`, `B`, `C`), og derfor `8` vil mulige gyldige kombinasjoner samlet sett:

| Endelig verdi | Aktiverte flagg |
| ------------- | --------------- |
| 0             | `Ingen`         |
| 1             | `A`             |
| 2             | `B`             |
| 3             | `A` + `B`       |
| 4             | `K`             |
| 5             | `A` + `C`       |
| 6             | `B` + `C`       |
| 7             | `A` + `B` + `C` |

For at ovennevnte skal kunne muliggjøres må et enkelt frittstående flagg derfor være to-makt. This is why additional flag in above example, `D`, would need to carry value of `8` or greater.

Vanligvis vil grafiske verktøy gjøre beregningen for deg. Hvis du redigerer konfigurasjon manuelt, du kan alltid bruke kalkulator og bare legge sammen underliggende verdier for alle flaggene du ønsker å aktivere - som i eksempel ovenfor.

Eksempel: `"SteamProtocols": 7` (som muliggjør flagg med verdi på `1`, `2` og `4`, som forklart over)

---

## Kartlegging av kompatibilitet

Grunnet JavaScript-begrensninger ved at det ikke er mulig å serialisere enkelt `ulong` felter i JSON når du bruker nettbasert konfigurator, `ulong` felt vil bli rendert som strenger med `s_` prefiks i konfigurasjonen. Dette inkluderer for eksempel `"SteamOwnerID": 76561198006963719` som skal skrives av vår ConfigGenerator som `"s_SteamOwnerID": "76561198006963719"`. ASF inkluderer korrekt logikk for håndtering av denne strengtilordning automatisk, slik at `s_` oppføringer i dine konfigurasjoner er faktisk gyldig og riktig generert. Hvis du genererer configs selv, anbefaler vi å holde deg med originale `ulong` felter hvis mulig, men hvis du ikke klarer å gjøre det, du kan også følge dette programmet og kode dem som strenger med `s_` -prefiks som er lagt til på deres navn. Etter hvert håper vi å finne denne JavaScript-begrensningen på.

---

## Configs kompatibilitet

Det er høyest prioritet for ASF å forbli kompatibel med eldre konfigurasjoner. Som du allerede bør vite behandles manglende konfigurasjonsegenskaper de samme som de ble definert med **standardverdiene**. Hvis ny konfigurasjons egenskap blir introdusert i ny versjon av ASF, vil alle konfigurasjonene dine forbli **kompatibel** med ny versjon, og ASF vil behandle den nye konfigurasjonsegenskapen som angitt med **standardverdien**. Du kan alltid legge til, fjerne eller redigere konfigurasjonsegenskapene avhengig av dine behov.

Vi anbefaler å begrense definerte konfigurasjonsegenskaper bare til de du vil endre, siden du automatisk arver standardverdier for alle andre, ikke bare holde konfigurasjonen ren, men også økende kompatibilitet i tilfelle vi bestemmer oss for å endre standardverdi for eiendom du ikke vil angi deg selv (e. . `WebLimiterDelay`).

På grunn av ovenstående vil ASF automatisk migrere/optimalisere dine konfigurasjoner ved å omformatere dem og fjerne felt som inneholder standardverdi. Du kan deaktivere denne oppførselen med `--no-config-migrate` **[kommandolinjeargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** hvis du har en bestemt grunn, for eksempel gir du skrivebeskyttede konfigurasjonsfiler og du ønsker ikke ASF for å endre dem.

---

## Auto-last på nytt

ASF er klar over konfigurasjoner som endres "på-fly" - takket være at ASF vil automatisk:
- Opprett (og begynne, hvis nødvendig) ny bot forekomst når du oppretter konfigurasjonen
- Stopp (hvis nødvendig) og fjern gammel bot når du sletter dets konfigurasjon
- Stopp (og begynne, hvis nødvendig) hvilken som helst bot når du redigerer konfigurasjonen
- Omstart (om nødvendig) boten er under nytt navn når du ombestemmer konfigurasjonen

Alt ovenfor er gjennomsiktig og vil bli gjort automatisk uten å måtte starte programmet på nytt, eller å drepe andre (upåvirkede) botter.

I tillegg til det, vil ASF også starte seg selv på nytt (hvis `AutoRestart` permits) hvis du endrer kjernen ASF `ASF.json` konfigurert. På samme måte vil programmet avslutte hvis du sletter eller gir det nytt navn.

Du kan deaktivere denne oppførselen med `--no-config-watch` **[kommandolinje-argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** hvis du har en bestemt grunn, for eksempel ønsker du ikke fra ASF for å reagere på filendringer i `config` -mappen.