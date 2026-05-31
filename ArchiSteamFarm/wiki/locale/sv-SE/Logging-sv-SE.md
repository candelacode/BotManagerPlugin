# Loggar

ASF låter dig konfigurera din egen anpassade loggningsmodul som kommer att användas under körtid. Du kan göra det genom att sätta specialfilen som heter `NLog.config` i appens katalog. Du kan läsa hela dokumentationen av NLog på **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**, men förutom att du hittar några användbara exempel här också.

---

## Standard loggning

Som standard loggar ASF `ColoredConsole` (standard utgång) och `fil`. `File` loggning inkluderar `log.txt` fil i programmets katalog och `loggar` katalog för arkiveringsändamål.

Använda anpassade NLog config inaktiverar automatiskt standard ASF config, din config åsidosätter **helt** standard ASF-loggning, vilket innebär att om du vill behålla e. . vårt `ColoredConsole` mål, då måste du definiera det **själv**. Detta gör att du inte bara kan lägga till **extra** loggningsmål, utan även inaktivera eller ändra **standard**.

Om du vill använda standard ASF loggning utan några ändringar, du behöver inte göra något - du behöver inte heller definiera det i anpassad `NLog. onfig`. För referens dock, motsvarar hårdkodad ASF standardloggning skulle vara:

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

ASF innehåller några fina kod tricks som förbättrar dess integration med NLog, så att du kan fånga specifika meddelanden lättare.

NLog-specifik `${logger}` variabel kommer alltid att skilja källan till meddelandet - det kommer att vara antingen `BotName` av en av dina botar, eller `ASF` om meddelandet kommer från ASF-processen direkt. På så sätt kan du enkelt fånga meddelanden med tanke på specifika bot(er), eller ASF process (endast), i stället för alla av dem, baserat på namnet på loggern.

ASF försöker markera meddelanden på lämpligt sätt baserat på NLog-tillhandahållna loggningsnivåer, vilket gör det möjligt för dig att endast fånga specifika meddelanden från specifika loggnivåer istället för dem alla. Självklart, loggningsnivå för specifika meddelanden kan inte anpassas, eftersom det är ASF-hårdkodat beslut hur allvarligt givet meddelande är, men du kan definitivt göra ASF mindre/mer tyst, som du tycker passar.

ASF loggar extra information, till exempel användar-/chattmeddelanden på `Trace` loggningsnivå. Standard ASF-loggningsloggar endast `Debug` -nivå och högre, vilket döljer den extra informationen, eftersom det inte behövs för majoriteten av användare, plus skräp utdata som innehåller potentiellt viktigare meddelanden. Du kan dock använda den informationen genom att återaktivera `Trace` loggningsnivå, särskilt i kombination med att logga endast en specifik bot som du valt, med särskilda evenemang du är intresserad av.

I allmänhet försöker ASF göra det så enkelt och bekvämt för dig som möjligt, för att logga endast meddelanden du vill istället för att tvinga dig att manuellt filtrera det genom tredjepartsverktyg som `grep` och liknande. Konfigurera helt enkelt NLog korrekt som skrivet nedan, och du bör kunna ange även mycket komplexa loggningsregler med anpassade mål som hela databaser.

När det gäller versionshantering - ASF försöker alltid leverera den senaste versionen av NLog som finns tillgänglig på **[NuGet](https://www.nuget.org/packages/NLog)** vid tidpunkten för ASF-utgåvan. Det bör inte vara ett problem att använda någon funktion du kan hitta på NLog wiki i ASF - se bara till att du också använder up-to-date ASF.

Som en del av ASF integration inkluderar ASF även stöd för ytterligare ASF NLog loggningsmål, vilket kommer att förklaras nedan.

---

## Exempel

Exempel nedan visar hur du kan anpassa loggning efter dina önskemål.

Som startare kommer vi endast att använda **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)**. Vår första `NLog.config` kommer att se ut så här:

```xml
<?xml version="1.0" kodning="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Förklaringen av ovanstående konfiguration är ganska enkel - vi definierar ett **loggningsmål**, som är `ColoredConsole`, sedan omdirigerar vi **alla loggers** (`*`) på nivå `Debug` och högre till `ColoredConsole` mål som vi definierade tidigare.

Om du startar ASF med ovan `NLog. onfig` nu, endast `ColoredConsole` mål kommer att vara aktiv, och ASF skriver inte till `File`, oavsett hårdkodad ASF NLog konfiguration.

Eftersom vi inte definierade en hel del egenskaper, såsom `layout`, det initierades till ett standard inbyggt värde, i detta fall `${longdate}<unk> ${level:uppercase=true}<unk>${logger}<unk>${message}`. Vi kan anpassa det, till exempel genom att endast logga meddelande:

```xml
<?xml version="1.0" kodning="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Om du startar ASF nu, kommer du att märka det datumet, nivå och logger namn försvann - lämnar dig bara med ASF-meddelanden i format `Function() Meddelande`.

Vi kan också ändra konfigurationen för att logga till fler än ett mål. Vi loggar till `ColoredConsole` och **[`File`](https://github.com/nlog/nlog/wiki/File-target)** samtidigt.

```xml
<?xml version ="1. " kodning = "utf-8" ?>
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

Och klar, vi kommer nu att logga allt till `ColoredConsole` och `fil`. Har du märkt att du också kan ange anpassade `filnamn` och extra alternativ?

Slutligen använder ASF olika loggnivåer för att göra det lättare för dig att förstå vad som pågår. Vi kan använda den informationen för att ändra allvarlighetsgraden. Låt oss säga att vi vill logga allt (`Trace`) till `fil`, men bara `varning` och över **[loggnivå](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** till `ColoredConsole`. Vi kan uppnå detta genom att ändra våra `regler`:

```xml
<?xml version ="1. " kodning = "utf-8" ?>
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

Det är det, nu visar vår `ColoredConsole` bara varningar och ovan, medan du fortfarande loggar allt till `fil`. Du kan ytterligare justera den för att logga t.ex. endast `Info` och nedan, och så vidare.

Slutligen, låt oss göra något lite mer avancerat och logga alla meddelanden till filen, men bara från bot som heter `LogBot`.

```xml
<?xml version ="1. " kodning = "utf-8" ?>
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

Du kan se hur vi använde ASF-integration ovan och enkelt särskilja källan till meddelandet baserat på `${logger}` egenskap.

---

## Avancerad användning

Exemplen ovan är ganska enkla och gjorda för att visa dig hur enkelt det är att definiera dina egna loggningsregler som kan användas med ASF. Du kan använda NLog för olika saker, inklusive komplexa mål (såsom att hålla loggar i `Databas`), loggar rotation (såsom att ta bort gamla `fil` loggar), använda anpassade `Layout`s, deklarera dina egna `<when>` loggfilter och mycket mer. Jag uppmuntrar dig att läsa igenom hela **[NLog dokumentation](https://github.com/nlog/nlog/wiki/Configuration-file)** för att lära dig om varje alternativ som är tillgängligt för dig, så att du kan finjustera ASF-loggningsmodulen på det sätt du vill. Det är ett riktigt kraftfullt verktyg och att anpassa ASF-loggning var aldrig enklare.

---

## Begränsningar

ASF kommer tillfälligt inaktivera **alla** regler som inkluderar `ColoredConsole` eller `Console` mål när användaren förväntar sig inmatning. Därför, om du vill fortsätta logga för andra mål även när ASF förväntar sig användarinmatning, bör du definiera dessa mål med sina egna regler, som visas i exempel ovan, istället för att sätta många mål i `skrivaTill` av samma regel (om inte detta är ditt önskade beteende). Tillfällig inaktivering av konsolmål görs för att hålla konsolen ren i väntan på användarinmatning.

---

## Loggning av chatt

ASF inkluderar utökat stöd för chatt loggning genom att inte bara spela in alla mottagna/skickade meddelanden på `Trace` loggningsnivå, men också exponera extra information relaterad till dem i **[händelse fastigheter](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Detta beror på att vi måste hantera chattmeddelanden som kommandon ändå, så det kostar oss inget att logga dessa händelser för att göra det möjligt för dig att lägga till extra logik (såsom att göra ASF till ditt personliga Steam-chattarkiv).

### Egenskaper för händelse

| Namn        | Beskrivning                                                                                                                                                                                                                            |
| ----------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Eko         | `Bool` typ. Detta är satt till `true` när meddelandet skickas från oss till mottagaren, och `false` annars.                                                                                                                            |
| Meddelande  | `sträng` typ. Detta är det faktiska skickade/mottagna meddelandet.                                                                                                                                                                     |
| ChatGroupID | `ulong` type. Detta är ID för gruppchatten för skickade/mottagna meddelanden. Kommer att vara `0` när ingen gruppchatt används för att överföra detta meddelande.                                                                      |
| ChatID      | `ulong` type. Detta är ID för `ChatGroupID` -kanalen för skickade/mottagna meddelanden. Kommer att vara `0` när ingen gruppchatt används för att överföra detta meddelande.                                                            |
| SteamID     | `ulong` type. Detta är ID för Steam-användaren för skickade/mottagna meddelanden. Kan vara `0` när ingen specifik användare är involverad i meddelandeöverföringen (e. . när det är vi som skickar ett meddelande till en gruppchatt). |

### Exempel

Detta exempel är baserat på vårt `ColoredConsole` grundläggande exempel ovan. Innan du försöker förstå det, Jag rekommenderar starkt att ta en titt på **[ovanför](#examples)** för att lära mig om grunderna i NLog loggning först.

```xml
<?xml version ="1. " kodning = "utf-8" ?>
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

Vi har startat från vårt grundläggande `ColoredConsole` exempel och utökat det ytterligare. Först och främst Vi har förberett en permanent chattloggfil per varje gruppkanal och Steam-användare - detta är möjligt tack vare extra egenskaper som ASF exponerar för oss på ett fint sätt. Vi har också bestämt oss för att gå med en anpassad layout som endast skriver aktuellt datum, meddelandet, skickat/tagit emot information och Steam-användaren själv. Slutligen har vi aktiverat vår chatt loggningsregel endast för `Trace` nivå, bara för vår `MainAccount` bot och endast för funktioner relaterade till chatt loggning (`OnIncoming*` som används för att ta emot meddelanden och ekos, och `SendMessage*` för ASF-meddelanden skickas).

Exemplet ovan kommer att generera `logs/chat/0-0-76561198069026042.txt` fil när du pratar med **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 hur gör du? -> 76561198069026042
2018-07-26 01:38:38 Jag gör bra, vad sägs om dig? <- 76561198069026042
```

Naturligtvis är detta bara ett arbetsexempel med några fina layout tricks visade på praktiskt sätt. Du kan ytterligare utöka denna idé till dina egna behov, såsom extra filtrering, anpassad beställning, personlig layout, inspelning endast mottagna meddelanden och så vidare.

### Ett annat exempel

Den här använder `SteamTarget` för att skicka ett meddelande till huvudbotens steamID (`76561198006963719`) när bot som heter `archi` får en donationshandel. Kräver en annan bot i processen (eftersom du inte kan skicka meddelanden till dig själv).

```xml
<?xml version ="1. " kodning = "utf-8" ?>
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

Förutom standard NLog loggningsmål (såsom `ColoredConsole` och `fil` förklaras ovan), du kan också använda anpassade ASF-loggningsmål.

För maximal fullständighet följer definitionen av ASF-mål NLog dokumentationskonvention.

---

### SteamTarget

Som du kan gissa använder detta mål Steam-chattmeddelanden för att logga ASF-meddelanden. Du kan konfigurera den för att använda en gruppchatt eller privat chatt. Förutom att ange ett Steam-mål för dina meddelanden, du kan också ange `botName` för den bot som ska skickas dem.

Stöds i alla miljöer som används av ASF.

---

#### Konfiguration Syntax
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

Läs mer om att använda [konfigurationsfil](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametrar

##### Allmänna inställningar
_namn_ - Namn på målet.

---

##### Layout alternativ
_layout_ - Text som ska renderas. [Layout](https://github.com/NLog/NLog/wiki/Layouts) krävs. Standard: `${level:uppercase=true}<unk>${logger}<unk>${message}`

---

##### SteamTarget alternativ

_chatGroupID_ - ID för gruppchatten deklarerades som 64-bitars länge osignerat heltal. Krävs inte. Standardvärdet är `0` som inaktiverar gruppchattens funktionalitet och använder privat chatt istället. När aktiverad (sätt till icke-nollvärde), `steamID` egenskapen nedan fungerar som `chatID` och anger ID för kanalen i denna `chatGroupID` som roboten ska skicka meddelanden till.

_steamID_ - SteamID deklarerat som 64-bitars länge osignerat heltal av mål-användare (som `SteamOwnerID`), eller rikta `chatID` (när `chatGroupID` är satt). Krävs. Standardvärdet är `0` som inaktiverar loggningsmålet helt.

_botName_ - Namnet på boten (som den känns igen av ASF, skiftlägeskänslig) som kommer att skicka meddelanden till `steamID` deklarerat ovan. Krävs inte. Standardvärdet är `null` som automatiskt väljer **någon** ansluten bot. Det rekommenderas att ställa in detta värde på lämpligt sätt, eftersom `SteamTarget` inte tar hänsyn till många Steam-begränsningar, till exempel det faktum att du måste ha `steamID` av målet på din vänlista. Denna variabel definieras som [layout](https://github.com/NLog/NLog/wiki/Layouts) typ, därför kan du använda särskild syntax i det, till exempel `${logger}` för att använda den bot som genererade meddelandet.

---

#### Exempel på SteamTarget

För att skriva alla meddelanden på `felsöka` nivå och högre, från bot som heter `MyBot` till steamID av `76561198006963719`, du bör använda `NLogg. onfig` liknande nedan:

```xml
<?xml version="1.0" kodning="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**Observera:** Vårt `SteamTarget` är anpassat mål, så du bör se till att du deklarerar det som `type="Steam"`, INTE `xsi:type="Steam"`, eftersom xsi är reserverad för officiella mål som stöds av NLog.

När du startar ASF med `NLog. onfig` liknande ovan, `MyBot` startar meddelanden `76561198006963719` Steam-användare med alla vanliga ASF-loggmeddelanden. Tänk på att `MyBot` måste vara ansluten för att kunna skicka meddelanden, så alla inledande ASF-meddelanden som hände innan vår bot kunde ansluta till Steam-nätverket, kommer inte att vidarebefordras.

Självklart, `SteamTarget` har alla typiska funktioner som du kan förvänta dig från generisk `TargetWithLayout`, så att du kan använda den tillsammans med e. . anpassade layouter, namn eller avancerade loggningsregler. Exemplet ovan är bara det mest grundläggande.

---

#### Skärmdumpar

![Skärmdump](https://i.imgur.com/5juKHMt.png)

---

#### Grottor

Var försiktig när du bestämmer dig för att kombinera `Debug` loggningsnivå eller nedan i din `SteamTarget` med `steamID` som deltar i ASF-processen. Detta kan leda till potentiell `StackOverflowException` eftersom du skapar en oändlig loop av ASF som tar emot givet meddelande, logga sedan igenom Steam, vilket resulterar i ett annat meddelande som måste loggas. För närvarande är den enda möjligheten för det att hända att logga `Trace` nivå (där ASF registrerar sina egna chattmeddelanden), eller `felsöka` -nivå medan du även kör ASF i `felsöka` -läge (där ASF spelar in alla Steam-paket).

Kort sagt, om din `ångmaskin` deltar i samma ASF-process, sedan `minlevel` loggningsnivån för din `SteamTarget` bör vara `Info` (eller `Debug` om du inte heller kör ASF i `Debug` läge) och högre. Alternativt kan du definiera din egen `<when>` loggning filter för att undvika oändlig loggning loop, om ändring av nivå inte är lämplig för ditt fall. Detta förbehåll gäller även gruppchattar.

---

### HistoryTarget

Detta mål används internt av ASF för att tillhandahålla loggningshistorik i `/Api/NLog` -slutpunkt för **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** som sedan kan konsumeras av ASF-ui och andra verktyg. I allmänhet bör du definiera detta mål endast om du redan använder anpassad NLog konfiguration för andra anpassningar och du vill också att loggen ska exponeras i ASF API, e. . för ASF-ui. Det kan också deklareras när du vill ändra standard layout eller `maxCount` för sparade meddelanden.

Stöds i alla miljöer som används av ASF.

---

#### Konfiguration Syntax
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Läs mer om att använda [konfigurationsfil](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametrar

##### Allmänna inställningar
_namn_ - Namn på målet.

---

##### Layout alternativ
_layout_ - Text som ska renderas. [Layout](https://github.com/NLog/NLog/wiki/Layouts) krävs. Standard: `${date:format=yyyy-MM-dd HH\:mm\:ss}<unk>${processname}-${processid}<unk> ${level:uppercase=true}<unk>${logger}<unk>${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### Inställningar för historikMål

_maxCount_ - Maximalt antal lagrade loggar för on-demand historik. Krävs inte. Standardvärdet är `20` vilket är en bra balans för att ge ursprunglig historia, samtidigt hålla i åtanke minnesanvändning som kommer ut ur lagringskrav. Måste vara större än `0`.