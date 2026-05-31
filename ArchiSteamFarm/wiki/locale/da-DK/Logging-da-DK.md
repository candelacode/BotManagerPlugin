# Logføring

ASF giver dig mulighed for at konfigurere din egen brugerdefinerede logning modul, der vil blive brugt under kørsel. Du kan gøre det ved at sætte en særlig fil med navnet `NLog.config` i applikationens mappe. Du kan læse hele dokumentationen af NLog på **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**, men derudover finder du også nogle nyttige eksempler her.

---

## Standard logning

Som standard logger ASF til `ColoredConsole` (standard output) og `File`. `File` logning inkluderer `log.txt` fil i programmets mappe, og `logs` mappe til arkivformål.

Brug af brugerdefineret NLog config deaktiverer automatisk ASF standardindstilling, din config tilsidesætter **helt** standard ASF logging, hvilket betyder, at hvis du ønsker at beholde e. . vores `ColoredConsole` mål, så skal du definere det **dig selv**. Dette giver dig mulighed for ikke kun at tilføje **ekstra** logning mål, men også deaktivere eller ændre **standard** dem.

Hvis du ønsker at bruge standard ASF logning uden ændringer, du behøver ikke at gøre noget - du behøver heller ikke at definere det i brugerdefinerede `NLog. onfig`. For reference dog, svarende til hardcoded ASF standard logning ville være:

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

## ASF integration

ASF indeholder nogle nice kode tricks, der forbedrer sin integration med NLog, så du kan fange specifikke meddelelser lettere.

NLog-specifik `${logger}` variabel vil altid skelne kilden til meddelelsen - det vil være enten `BotName` på en af dine bots, eller `ASF` , hvis meddelelsen kommer fra ASF proces direkte. På denne måde kan du nemt fange beskeder overvejer specifikke bot(s), eller ASF proces (kun), i stedet for dem alle, baseret på navnet på loggeren.

ASF forsøger at markere meddelelser passende baseret på NLog-leverede logningsniveauer, hvilket gør det muligt for dig at fange kun specifikke meddelelser fra specifikke logniveauer i stedet for dem alle. Selvfølgelig kan logning niveau for specifik besked ikke tilpasses, da det er ASF hardcoded beslutning, hvor alvorlig given besked er, men du kan helt sikkert gøre ASF mindre/mere lydløs, som du finder det passende.

ASF logger ekstra info, såsom bruger / chat beskeder på `Trace` logning niveau. Standard ASF logning logs kun `Fejlsøg` niveau og over, som skjuler denne ekstra information, da det ikke er nødvendigt for de fleste brugere, plus clutters output indeholder potentielt vigtigere meddelelser. Du kan dog gøre brug af disse oplysninger ved at genaktivere `Trace` logningsniveau, især i kombination med logning kun én bestemt bot efter eget valg, med særlige hændelser, du er interesseret i.

Generelt forsøger ASF at gøre det så nemt og bekvemt for dig som muligt, for at logge kun beskeder du ønsker i stedet for at tvinge dig til manuelt at filtrere det gennem tredjepartsværktøjer såsom `grep` og ens. Du skal blot konfigurere NLog korrekt som skrevet nedenfor, og du bør være i stand til at angive selv meget komplekse logning regler med brugerdefinerede mål såsom hele databaser.

Med hensyn til versionering - ASF forsøger altid at sende med den nyeste version af NLog, der er tilgængelig på **[NuGet](https://www.nuget.org/packages/NLog)** på tidspunktet for ASF udgivelse. Det bør ikke være et problem at bruge nogen funktion, du kan finde på NLog wiki i ASF - bare sørg for at du også bruger up-to-date ASF.

Som led i ASF-integrationen omfatter ASF også støtte til yderligere mål for ASF NLog logging, som vil blive forklaret nedenfor.

---

## Eksempler

Eksempler nedenfor viser dig, hvordan du kan tilpasse logning til din smag.

Som starter bruger vi kun målet **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)**. Vores oprindelige `NLog.config` vil se sådan ud:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Forklaringen på ovenstående config er ret enkel - vi definerer et **logningsmål**, som er `ColoredConsole`, derefter vi omdirigere **alle loggere** (`*`) på niveau `Debug` og højere til `ColoredConsole` mål, vi definerede tidligere.

Hvis du starter ASF med ovenstående `NLog. onfig` nu, kun `ColoredConsole` mål vil være aktiv, og ASF vil ikke skrive til `Fil`uanset hardcoded ASF NLog konfiguration.

Da vi ikke definerede en masse egenskaber, såsom `layout`, blev det initialiseret til en standard indbygget værdi, i dette tilfælde `${longdate}- ${level:uppercase=true}-${logger}-${message}`. Vi kan tilpasse det, for eksempel ved kun at logge besked:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Hvis du starter ASF nu, vil du bemærke denne dato, level and logger name forsvandt - forlader dig kun med ASF beskeder i format `Function() Message`.

Vi kan også ændre config til at logge på mere end et mål. Lad os logge på `ColoredConsole` og **[`File`](https://github.com/nlog/nlog/wiki/File-target)** på samme tid.

```xml
<?xml version="1. " encoding="utf-8" ?>
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

Og færdig, vil vi nu logge alt til `ColoredConsole` og `File`. Har du bemærket, at du også kan angive brugerdefinerede `fileName` og ekstra muligheder?

Endelig bruger ASF forskellige log-niveauer, for at gøre det lettere for dig at forstå, hvad der foregår. Vi kan bruge disse oplysninger til at ændre sværhedsgradslogning. Lad os sige, at vi ønsker at logge alt (`Trace`) til `File`, men kun `Advarsel` og over **[log niveau](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** til `ColoredConsole`. Det kan vi opnå ved at ændre vores `regler`:

```xml
<?xml version="1. " encoding="utf-8" ?>
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

Det er det, nu vil vores `ColoredConsole` kun vise advarsler og over, mens du stadig logger alt til `File`. Du kan yderligere justere det til at logge f.eks. `Info` og nedenfor, og så videre.

Endelig lad os gøre noget lidt mere avanceret og logge alle beskeder til fil, men kun fra bot ved navn `LogBot`.

```xml
<?xml version="1. " encoding="utf-8" ?>
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

Du kan se, hvordan vi brugte ASF integration ovenfor og nemt skelnede kilde til meddelelsen baseret på `${logger}` ejendom.

---

## Avanceret brug

Ovenstående eksempler er ret enkle og lavet til at vise dig, hvor nemt det er at definere dine egne logningsregler, der kan bruges med ASF. Du kan bruge NLog til forskellige ting, herunder komplekse mål (såsom at holde logs i `Database`), logs rotation (såsom fjernelse af gamle `File` logger) bruger brugerdefinerede `Layout`s, erklærer dine egne `<when>` logningsfiltre og meget mere. Jeg opfordrer dig til at læse hele **[NLog dokumentation](https://github.com/nlog/nlog/wiki/Configuration-file)** for at lære om alle muligheder, der er tilgængelige for dig, giver dig mulighed for at finjustere ASF logning modul på den måde, du ønsker. Det er et virkelig kraftfuldt værktøj og tilpasse ASF logning var aldrig nemmere.

---

## Begrænsninger

ASF vil midlertidigt deaktivere **alle** regler, der omfatter `ColoredConsole` eller `Console` mål, når du forventer brugerinput. Derfor, hvis du ønsker at holde logning for andre mål, selv når ASF forventer brugerinput, bør du definere disse mål med deres egne regler, som vist i ovenstående eksempler i stedet for at sætte mange mål i `skrive til` af samme regel (medmindre dette er din ønskede adfærd). Midlertidig deaktivering af konsolmål gøres for at holde konsollen ren, når du venter på brugerinput.

---

## Chat logning

ASF omfatter udvidet understøttelse af chat-logning ved ikke kun at optage alle modtagede/sendte beskeder på `Trace` logningsniveau men også udsætte ekstra info relateret til dem i **[begivenhedsegenskaber](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Dette skyldes, at vi alligevel skal håndtere chatbeskeder som kommandoer - så det ikke koster os noget at logge disse begivenheder for at gøre det muligt for dig at tilføje ekstra logik (såsom at gøre ASF dit personlige Steam-chatarkiv).

### Egenskaber for begivenheder

| Navn        | Beskriveslse                                                                                                                                                                                                                     |
| ----------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Echo        | `bool` type. Dette er indstillet til `sand` når besked sendes fra os til modtageren, og `falsk` ellers.                                                                                                                          |
| Message     | `streng` type. Dette er den faktiske afsendte/modtagne besked.                                                                                                                                                                   |
| ChatGroupID | `ulong` type. Dette er ID på gruppechatten for sendte/modtagne beskeder. Vil være `0` , når ingen gruppe chat bruges til at sende denne besked.                                                                                  |
| ChatID      | `ulong` type. Dette er ID for `ChatGroupID` kanalen for send/modtagne meddelelser. Vil være `0` , når ingen gruppe chat bruges til at sende denne besked.                                                                        |
| SteamID     | `ulong` type. Dette er ID'et for Steam-brugeren for sendte/modtagne beskeder. Kan være `0` , når ingen bestemt bruger er involveret i overførslen af meddelelser (f. eks. . når det er os at sende en besked til en gruppechat). |

### Eksempel

Dette eksempel er baseret på vores `ColoredConsole` grundlæggende eksempel ovenfor. Før du forsøger at forstå det, Jeg anbefaler på det kraftigste at tage et kig **[over](#examples)** for at lære om grundlæggende NLog logning først.

```xml
<?xml version="1. " encoding="utf-8" ?>
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

Vi har startet fra vores grundlæggende `ColoredConsole` eksempel og udvidet det yderligere. Først og fremmest vi har udarbejdet en permanent chat logfil pr. gruppe kanal og Steam bruger - dette er muligt takket være ekstra egenskaber, som ASF udsætter for os på en fancy måde. Vi har også besluttet at gå med et brugerdefineret layout, der kun skriver aktuel dato, meddelelsen, sendt/modtaget info og Steam-bruger selv. Endelig har vi kun aktiveret vores chat logging regel for `Trace` niveau, kun for vores `MainAccount` bot og kun for funktioner relateret til chat logging (`OnIncoming*` , som bruges til at modtage beskeder og ekkoer, og `SendMessage*` for ASF beskeder sender).

Eksemplet ovenfor vil generere `logs/chat/0-0-76561198069026042.txt` fil, når du taler med **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 how are you doing? -> 76561198069026042
2018-07-26 01:38:38 Jeg gør stor, hvad med dig? <- 76561198069026042
```

Selvfølgelig er dette blot et arbejdseksempel med et par pæne layout tricks viste på praktisk måde. Du kan yderligere udvide denne idé til dine egne behov, såsom ekstra filtrering, brugerdefineret ordre, personlige layout, optagelse kun modtagne beskeder og så videre.

### Et andet eksempel

Denne bruger `SteamTarget` for at sende en meddelelse til hovedbottens damp-ID (`76561198006963719`) når bot med navnet `archi` modtager en donation handel. Kræver en anden bot i processen (da du ikke kan sende beskeder til dig selv).

```xml
<?xml version="1. " encoding="utf-8" ?>
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

Ud over standard NLog logning mål (såsom `ColoredConsole` og `File` forklaret ovenfor), du kan også bruge brugerdefinerede ASF logning mål.

For maksimal fuldstændighed følger definitionen af ASF-mål NLog-dokumentationskonventionen.

---

### SteamTarget

Som du kan gætte, bruger dette mål Steam-chat-beskeder til at logge ASF-beskeder. Du kan konfigurere den til at bruge enten en gruppechat eller privat chat. Udover at angive et Steam-mål for dine beskeder du kan også angive `botName` på den bot, der formodes at sende dem.

Understøttet i alle miljøer, der anvendes af ASF.

---

#### Konfiguration Syntaks
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

Læs mere om at bruge [Configuration File](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametre

##### Generelle Indstillinger
_navn_ - Navn på målet.

---

##### Layout Indstillinger
_layout_ - Tekst skal gengives. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Kræves. Standard: `${level:uppercase=true}¤${logger}¤${message}`

---

##### SteamTarget Indstillinger

_chatGroupID_ - ID på gruppechatten erklæret som 64-bit langt usigneret heltal. Ikke påkrævet. Standard er `0` , som vil deaktivere gruppechat-funktionalitet og bruge privat chat i stedet. Når aktiveret (sæt til ikke-nul værdi), `steamID` egenskaben nedenfor fungerer som `chatID` og angiver ID for kanalen i dette `chatGroupID` som botten skal sende beskeder til.

_steamID_ - SteamID erklæret som 64-bit lang usigneret heltal af målet Steam bruger (som `SteamOwnerID`), eller mål `chatID` (når `chatGroupID` er sat). Påkrævet. Defaults to `0` , which disables logging target entielt. (Automatic Copy)

_botName_ - Navnet på botten (som det er genkendt af ASF, case-sensitive), der vil sende beskeder til `steamID` erklæret ovenfor. Ikke påkrævet. Defaults to `null` which will automatically select **any** currently connected bot. Det anbefales at indstille denne værdi korrekt, da `SteamTarget` ikke tager højde for mange Steam-begrænsninger, såsom det faktum, at du skal have `steamID` af målet på din venliste. Denne variabel er defineret som [layout](https://github.com/NLog/NLog/wiki/Layouts) type, derfor kan du bruge særlig syntaks i det, såsom `${logger}` for at bruge den bot, der genererede beskeden.

---

#### SteamTarget Eksempler

For at skrive alle beskeder af `fejlsøg` niveau og derover fra bot ved navn `MyBot` til dampID af `76561198006963719`, skal du bruge `NLog. onfig` svarende til nedenfor:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**Bemærk:** Vores `SteamTarget` er tilpasset mål, så du bør sørge for, at du erklærer det som `type="Steam"`, IKKE `xsi:type="Steam"`, da xsi er reserveret til officielle mål understøttet af NLog.

Når du starter ASF med `NLog. onfig` ligner ovenstående, `MyBot` vil starte beskederne `76561198006963719` Steam bruger med alle sædvanlige ASF log beskeder. Husk, at `MyBot` skal være forbundet for at sende beskeder, så alle indledende ASF-meddelelser, der er sket, før vores bot kunne oprette forbindelse til Steam-netværket, vil ikke blive videresendt.

Selvfølgelig har `SteamTarget` alle typiske funktioner, som du kunne forvente fra generisk `TargetWithLayout`, så du kan bruge det i forbindelse med e. . brugerdefinerede layouts, navne eller avancerede logningsregler. Eksemplet ovenfor er kun det mest basale.

---

#### Skærmbilleder

![Screenshot](https://i.imgur.com/5juKHMt.png)

---

#### Kløver

Vær forsigtig, når du beslutter dig for at kombinere `fejlsøg` logningsniveau eller derunder i din `SteamTarget` med `steamID` , der deltager i ASF processen. Dette kan føre til potentiel `StackOverflowException` , fordi du vil oprette en uendelig løkke af ASF modtager given besked, derefter logge det gennem Steam, hvilket resulterer i en anden besked, der skal logges. I øjeblikket er den eneste mulighed for at det sker, at logge `Trace` niveau (hvor ASF registrerer sine egne chat-meddelelser) eller `Fejlsøg` -niveau, mens du også kører ASF i `Fejlsøg` -tilstand (hvor ASF registrerer alle Steam-pakker).

Kort sagt, hvis din `steamID` deltager i den samme ASF proces, derefter `minlevel` logningsniveauet for din `SteamTarget` bør være `Info` (eller `fejlfinding` , hvis du også kører ASF i `fejlfinding` tilstand) og derover. Alternativt kan du definere din egen `<when>` logning filtre for at undgå uendelig logning loop, hvis ændring af niveau ikke er passende for din sag. Dette forbehold gælder også for gruppechats.

---

### HistoryTarget

Dette mål bruges internt af ASF til at levere fast størrelse logningshistorik i `/Api/NLog` endepunkt i **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** , der efterfølgende kan forbruges af ASF-ui og andre værktøjer. Generelt bør du kun definere dette mål, hvis du allerede bruger brugerdefinerede NLog config for andre tilpasninger, og du ønsker også, at loggen skal være udsat i ASF API, e. . for ASF- ui. Det kan også erklæres, når du ønsker at ændre standard layout eller `maxCount` af gemte beskeder.

Understøttet i alle miljøer, der anvendes af ASF.

---

#### Konfiguration Syntaks
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Læs mere om at bruge [Configuration File](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametre

##### Generelle Indstillinger
_navn_ - Navn på målet.

---

##### Layout Indstillinger
_layout_ - Tekst skal gengives. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Kræves. Standard: `${date:format=yyyy-MM-dd HH\:mm\:ss}ţ${processname}-${processid}ategor${level:uppercase=true}ateg${logger}æn${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### Indstillinger For HistorikMål

_maxCount_ - Maksimal mængde lagrede logs til on-demand historik. Ikke påkrævet. Standard er `20` , som er en god balance for at give initial historik mens stadig huske hukommelsesforbrug, der kommer ud af opbevaring krav. Skal være større end `0`.