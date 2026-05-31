# Logger

ASF lar deg konfigurere din egen egendefinerte loggingsmodul som vil bli brukt under kjøretid. Det gjør du ved å sette en spesiell fil med navn `NLog.config` i mappe for programmet. Du kan lese hele dokumentasjonen til NLog på **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**, men i tillegg til at du finner noen nyttige eksempler her.

---

## Standard logging

Som standard logger ASF til `ColoredConsole` (standard utgang) og `fil`. `File` logging omfatter `log.txt` -filen i programmets mappe, og `logger` mappe for arkivformål.

Bruker egendefinert NLog-konfigurasjon automatisk deaktiverer standard ASF-konfigurasjon, din config overstyrer **fullstendig** standard ASF-logging, hvilket betyr det hvis du vil beholde e. . Vårt mål `ColoredConsole` , deretter må du definere det **selv**. Dette lar deg ikke bare legge til **ekstra** loggemål, men også deaktivere eller endre **standard**.

Hvis du vil bruke standard ASF-logging uten modifikasjoner, du trenger ikke å gjøre noe, du trenger ikke definere den i egendefinert `NLog. konfigurasjon`. For å kunne se at standardlogging av hardkodet ASF tilsvarende:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir:cached=true}/logs/log.txt" archiveOldFileOnStartup="true" archiveSuffixFormat=".{1:yyyyMMdd-HHmmss}" fileName="${currentdir:cached=true}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- Below becomes active when ASF's IPC interface is started -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="File" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- Below becomes active when ASF's IPC interface is enabled -->
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="History" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## ASF integrasjon

ASF inkluderer noen fine kodetriks som forbedrer integrasjonen med NLog, slik at du lettere kan fange bestemte meldinger.

NLog-spesifikk `${logger}` variabelen vil alltid skille meldingskilden - den vil enten være `BotName` av en av dine bots, eller `ASF` hvis meldinger kommer direkte fra ASF-prosessen. På denne måten kan du enkelt fange meldinger som tar hensyn til bestemte bot(er) eller ASF-prosess (kun for alle), i stedet for alle, basert på loggens navn.

ASF prøver å markere meldinger på riktig måte basert på godkjente loggenivåer, som gjør det mulig å fange bare bestemte meldinger fra spesifikke loggnivåer i stedet for alle dem. Selvsagt kan ikke loggingsnivå for bestemte meldinger tilpasses, da det er ASF hardkodet avgjørelser hvor alvorlig meldingen er, men du kan definitivt gjøre ASF mindre eller mer stille, som du ikke behøver å gjøre det.

ASF logger ekstra informasjon, slik som bruker/chat-meldinger på `Trace` loggnivå. Standard ASF-loggene bare `Debug` nivå og over, som gjemmer den ekstra informasjonen siden det ikke trengs for flertallet av brukerne, pluss clutters resultat som inneholder potensielt viktigere meldinger. Du kan imidlertid benytte denne informasjonen ved å reaktivere `Trace` loggenivå, spesielt i kombinasjon med logging av bare én bestemt bot av ditt valg, med spesiell hendelse du er interessert i.

Generelt sett forsøker ASF å gjøre det så enkelt og praktisk for deg som mulig. å logge bare meldinger du vil i stedet for å tvinge deg til å manuelt filtrere dem gjennom tredjepartsverktøy, for eksempel `grep` og like. Bare konfigurer NLog som skrevet nedenfor, og du bør kunne spesifisere selv svært komplekse loggingsregler med tilpassede mål som alle databaser.

Vedrørende versjonering - ASF forsøk på å alltid sende med mest oppdaterte versjoner av NLog som er tilgjengelig på **[NuGet](https://www.nuget.org/packages/NLog)** på tidspunktet for ASF-utgivelse. Det bør ikke være et problem å bruke alle funksjoner du finner på NLog wiki i i ASF - bare sørg for at du også bruker oppdaterte ASF.

Som en del av ASF-integrering inneholder ASF også støtte til ytterligere ASF NLogg-logginn, som vil bli forklart nedenfor.

---

## Eksempler

Eksempler nedenfor viser hvordan du kan tilpasse loggingen til din mening.

Som en starter vil vi bruke bare **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)** mÃ¥l. Vår første `NLog.config` vil se slik ut:

```xml
<?xml version="1.0" koding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Forklaringen på ovennevnte konfigurasjon er ganske enkel - vi definerer ett **loggingsmål**, som er `ColoredConsole`, så vi omdirigerer **alle loggere** (`*`) av nivå `Debug` og høyere til `ColoredConsole` mål vi definert tidligere.

Hvis du begynner ASF med over `NLog. Konfigurasjon` nå, bare `Fargekonsoll` er aktivt og ASF vil ikke skrive til `Fil`, uavhengig av hardkodet ASF NLog konfigurasjon.

Since we didn't define a lot of properties, such as `layout`, it was initialized to a default built-in value, in this case `${longdate}|${level:uppercase=true}|${logger}|${message}`. Vi kan bare tilpasse det, for eksempel ved loggemelding:

```xml
<?xml version="1.0" koding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Hvis du starter ASF nå, vil du legge inn den datoen, level og loggnavn forsvunnet - og du får bare ASF-meldinger i formatet `Function() Melding`.

Vi kan også endre konfigurasjonen for å logge til mer enn ett mål. Let's log to `ColoredConsole` and **[`File`](https://github.com/nlog/nlog/wiki/File-target)** at the same time.

```xml
<?xml version="1. " koding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Debug" writeTo="File" />
  </rules>
</nlog>
```

Og ferdig logger vi alt til `ColoredConsole` og `fil`. Merket du at du også kan angi egendefinert `fileName` og ekstra alternativer?

Til slutt bruker ASF ulike loggnivåer, for å gjøre det enklere for deg å forstå hva som skjer. Vi kan bruke denne informasjonen for å endre alvorlighetsgradlogging. La oss si at vi vil logge alt (`Trace`) til `fil`, men bare `Advarsel` og høyere **[loggnivå](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** til `FaroredKonsoll`. Vi kan oppnå det ved å endre våre `regler`:

```xml
<?xml version="1. " koding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Warn" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Trace" writeTo="File" />
  </rules>
</nlog>
```

That's it, now our `ColoredConsole` will show only warnings and above, while still logging everything to `File`. Du kan justere den ytterligere til å logge for eksempel bare `Info` og under, og så videre.

La oss gjøre noe mer avansert og logge alle meldinger å file, men bare fra botter som heter `LogBot`.

```xml
<?xml version="1. " koding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="LogBotFile" fileName="${currentdir:cached=true}/LogBot.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="LogBot" minlevel="Trace" writeTo="LogBotFile" />
  </rules>
</nlog>
```

Du kan se hvordan vi brukte ASF-integrasjon over og enkelt utskilte meldingskilden basert på `${logger}` -egenskapen.

---

## Avansert bruk

Eksemplene ovenfor er ganske enkle og vise deg hvor enkelt det er å definere dine egne loggregler som kan brukes sammen med ASF. You can use NLog for various different things, including complex targets (such as keeping logs in `Database`), logs rotation (such as removing old `File` logs), using custom `Layout`s, declaring your own `<when>` logging filters and much more. Jeg oppfordrer deg til å lese gjennom hele **[NLogg dokumentasjon](https://github.com/nlog/nlog/wiki/Configuration-file)** for å lære om alle muligheter som er tilgjengelig for deg, Lar deg finjustere ASF-loggingsmodulen slik du vil. Det er et veldig sterkt verktøy for å tilpasse ASF-logging ble aldri enklere.

---

## Begrensninger

ASF vil midlertidig deaktivere **alle** regler som inkluderer `ColoredConsoll` eller `konsoll` når brukeren forventer inndata fra brukeren. Hvis du ønsker å logge mot andre mål selv om ASF forventer at brukerinnspillet, bør du derfor definere disse målene med egne regler, som vist i eksempler ovenfor, i stedet for å sette mange mål i `skriv til` av samme regel (med mindre dette er din ønsket oppførsel). Midlertidig deaktivering av konsollmål er gjort for å kunne holde konsollen rent når man venter på inndata fra brukeren.

---

## Chat logging

ASF inkluderer utvidet støtte til chat logging ved ikke bare å ta opp alle mottatt/sendte meldinger på `Trace` loggnivå, men også eksponerer ekstra informasjon relatert til dem i **[hendelsesegenskaper](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Dette er fordi vi må håndtere chat melding når kommandoene likevel er så det koster oss ikke noe å logge disse hendelsene for å gjøre det mulig for deg å legge til ekstra logikk (for eksempel å gjøre ASF din personlige Steam chatting arkiv).

### Egenskaper for arrangementet

| Navn          | Beskrivelse                                                                                                                                                                                              |
| ------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Ekko          | `bool` type. This is set to `true` when message is being sent from us to the recipient, and `false` otherwise.                                                                                           |
| Melding       | `streng` type. Dette er selve sendingen/mottatt meldingen.                                                                                                                                               |
| ChatGruppe ID | `ulong` type. Dette er ID-en til gruppe-chatten for sendt/mottatt meldinger. Vil være `` når ingen gruppesamtale brukes til å sende denne meldingen.                                                     |
| ChatID        | `ulong` type. Dette er ID-en til `ChatGroupID` kanalen for sendt/mottatt meldinger. Vil være `` når ingen gruppesamtale brukes til å sende denne meldingen.                                              |
| SteamID       | `ulong` type. Dette er ID til Steam-brukeren for sendt/mottatt meldinger. Kan være `0` når ingen bestemt bruker er involvert i meldingsoverføringen (e. . Når vi sender en melding til en gruppesamtale. |

### Eksempel

Dette eksemplet er basert på vårt `ColoredConsole` grunnleggende eksempel over. Before trying to understand it, I strongly recommend to take a look **[above](#examples)** in order to learn about basics of NLog logging firstly.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="ChatLogFile" fileName="${currentdir:cached=true}/logs/chat/${event-properties:item=ChatGroupID}-${event-properties:item=ChatID}${when:when='${event-properties:item=ChatGroupID}' == 0:inner=-${event-properties:item=SteamID}}.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss} ${event-properties:item=Message} ${when:when='${event-properties:item=Echo}' == true:inner=-&gt;:else=&lt;-} ${event-properties:item=SteamID}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="MainAccount" level="Trace" writeTo="ChatLogFile">
      <filters defaultAction="Log">
        <when condition="not starts-with('${message}','OnIncoming') and not starts-with('${message}','SendMessage')" action="Ignore" />
      </filters>
    </logger>
  </rules>
</nlog>
```

Vi har startet fra vårt grunnleggende eksempel `ColoredConsole` og utvidet det videre. Først og fremst Vi har forberedt en permanent loggfil for chat per hver gruppe-kanal og -bruker - dette er mulig takket være ekstra egenskaper som ASF utsetter for oss på en fancy måte. Vi har også besluttet å gå med et tilpasset oppsett som bare skriver gjeldende dato, melding, sendt/mottatt info og Steam bruker selv. Endelig har vi aktivert vår regel for chat logging bare for `Trace` nivå, kun for vår `MainAccount` -bot og bare for funksjoner knyttet til chat logging (`OnIncoming*` som brukes for å motta meldinger og ekkoer, og `SendMessage*` for ASF meldinger sendt).

Eksemplet ovenfor vil generere `logs/chat/0-0-76561198069026042.txt` når vi snakker med **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 hvordan gjør du? -> 76561198069026042
2018-07-26 01:38:38 Jeg gjør bra, hva med deg? <- 76561198069026042
```

Selvfølgelig er dette bare et arbeidseksempel med noen få fine oppskriftstriks som ble vist praktisk og forståelig. Du kan utvide ideen til dine egne behov, for eksempel ekstra filtrering, egendefinert rekkefølge, personlig oppsett, ta opp kun mottatte meldinger og så videre.

### Et annet eksempel

Denne bruker `SteamTarget` for å sende en melding til hovedbotens steamID (`76561198006963719`) når botten heter `archi` mottar et donasjonshandel. Krever en annen bot i prosessen (siden du ikke kan sende meldinger til deg selv).

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" />
  </targets>

  <rules>
    <logger name="archi" level="Trace" writeTo="Steam">
      <filters defaultAction="Ignore">
        <when condition="starts-with('${message}','ParseTrade() Accepted donation trade: ')" action="Log" />
      </filters>
    </logger>
  </rules>
</nlog>
```

---

## ASF mål

I tillegg til standard NLogg-mål (for eksempel `ColoredConsole` og `Fil` forklart over), du kan også bruke tilpassede ASF-loggingsmål.

For å oppnå best mulig definisjon av ASF-mål vil de følge NLog-dokumentasjonskonvensjonen.

---

### SteamMål

Som du kan gjete, så bruker dette målet Steam chat meldinger for å logge ASF-meldinger. Du kan konfigurere den for å bruke enten en gruppesamtale, eller en privat chat. I tillegg til å angi et Steam-mål for meldingene dine, du kan også spesifisere `botName` av botten som skal sende dem.

Støttet i alle miljøer som brukes av ASF.

---

#### Konfigurasjons syntaks
```xml
<targets>
  <target type="Steam"
          name="String"
          layout="Layout"
          chatGroupID="Ulong"
          steamID="Ulong"
          botName="Layout" />
</targets>
```

Les mer om å bruke [konfigurasjonsfil](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametere

##### Generelle alternativer
_navn_ - navnet på målet.

---

##### Oppsett alternativer
_layout_ - Tekst som skal vises. [Layout](https://github.com/NLog/NLog/wiki/Layouts) kreves. Standard: `${level:uppercase=true}″${logger}″${message}`

---

##### SteamTarget alternativer

_chatGroupID_ - ID for gruppe-chatten erklært som 64-bit usignert heltall. Ikke nødvendig. Standardinnstillingene til `0` som vil deaktivere gruppens chatfunksjonalitet og bruke privat chat i stedet. When enabled (set to non-zero value), `steamID` property below acts as `chatID` and specifies ID of the channel in this `chatGroupID` that the bot should send messages to.

_steamID_ - SteamID erklært som 64-bit usignert heltall av målets Steam-bruker (som `SteamOwnerID`), eller mål `chatID` (når `chatGroupID` er angitt). Påkrevd. Standarder til `0` som fullstendig deaktiverer loggingsmål.

_botName_ - Navnet på botten (som det er gjenkjent av ASF, case-sensitive) som vil sende meldinger til `steamID` erklært over. Ikke nødvendig. Standardinnstillingene til `null` som automatisk velger **hvilken som helst** som er tilkoblet bot. Det er anbefalt å sette denne verdien riktig, siden `SteamTarget` ikke tar hensyn til mange Steam-begrensninger, som det faktum at du må ha `steamID` av målet på vennelisten din. Denne variabelen er definert som [layout](https://github.com/NLog/NLog/wiki/Layouts) type, derfor kan du bruke spesiell syntaks i den. slike som `${logger}` for å bruke botten som genererte meldingen.

---

#### Eksempler på dampmål

For å skrive alle meldinger av `Debug` nivå og over, fra bot som heter `MyBot` til steamID av `76561198006963719`, skal du bruke `NLog. konfigurasjon` lik nedenfor:

```xml
<?xml version="1.0" koding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**Notice:** Our `SteamTarget` is custom target, so you should make sure that you're declaring it as `type="Steam"`, NOT `xsi:type="Steam"`, as xsi is reserved for official targets supported by NLog.

Når du starter ASF med `NLog. konfigurasjon` som ligner ovenfor `MyBot` starter en melding `76561198006963719` bruker Steam med alle vanlige ASF-loggmeldinger. Husk at `MyBot` må være koblet til for å sende meldinger, så alle initielle ASF-meldinger som skjedde før boten vår kan koble til Steam-nettverket, vil ikke bli videresendt.

Selvsagt har `SteamTarget` alle typiske funksjoner du kunne forvente fra generisk `TargetWithLayout`, så du kan bruke den sammen med andre. . egendefinerte oppsett, navn eller avanserte loggregler. Eksemplet over er bare den mest grunnleggende.

---

#### Skjermbilder

![Skjermbilde](https://i.imgur.com/5juKHMt.png)

---

#### Hav

Vær forsiktig når du bestemmer å kombinere `Debug` logge nivå eller nedenfor i `SteamTarget` med `steamID` som tar del i ASF-prosessen. Dette kan føre til potensiell `StackOverflowException` fordi du vil lage en uendelig løkke av ASF som mottar den gitte meldingen. deretter logge den inn gjennom Steam, noe som resulterer i en annen melding som må logges. Foreløpig er den eneste muligheten det skal skje, å logge `Trace` nivå (hvor ASF lagrer sine egne chat-meldinger), eller `Feilsøk` -nivå under kjøring av ASF i `Debug` -modus (der ASF-poster alle Steam-pakker).

Kort sagt, hvis din `steamID` deltar i samme ASF-prosess, så bør logge `minnivå` på din `SteamTarget` være `Info` (eller `Debug` hvis du ikke kjører ASF i `Debug` modde) og ovenfor. Alternativt kan du definere din egen `<when>` loggefilter for å unngå uendelig loggetid, hvis det ikke er aktuelt å endre nivået i ditt tilfelle. Denne maten gjelder også grupper samtaler.

---

### HistoryTarget

Dette målet brukes internt av ASF for å angi faststørrelse loggehistorie i `/Api/NLog` endepunkt **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** som kan etterpå forbrukes av ASF-ui og andre verktøy. Generelt bør du definere dette målet bare hvis du allerede bruker en egendefinert NLog config for andre tilpasninger, og du vil at loggen skal bli eksponert i ASF API, e. . for ASF-ui. Det kan også erklæres når du ønsker å endre standardoppsettet eller `maks antall` med lagrede meldinger.

Støttet i alle miljøer som brukes av ASF.

---

#### Konfigurasjons syntaks
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Les mer om å bruke [konfigurasjonsfil](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametere

##### Generelle alternativer
_navn_ - navnet på målet.

---

##### Oppsett alternativer
_layout_ - Tekst som skal vises. [Layout](https://github.com/NLog/NLog/wiki/Layouts) kreves. Default: `${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### HistoryMål Innstillinger

_maks antall_ - Maksimal antall lagrede logger for nettbasert historie. Ikke nødvendig. Standarder til `20` som er en god balanse for å tilby innledende historie, Husk Husk i minnebruk som ikke kommer ut av lagringskravene. Må være større enn `0`.