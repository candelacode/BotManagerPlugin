# Loggen

ASF stelt je in staat om de eigen aangepaste logging module te configureren die tijdens de runtime zal worden gebruikt. Je kunt dit doen door het plaatsen van een speciaal bestand genaamd `NLog.config` in de applicatiemap. U kunt de gehele documentatie van NLog on **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**lezen, , maar daarnaast vind je hier ook enkele handige voorbeelden.

---

## Standaard logboek

ASF logt standaard in op `ColoredConsole` (standaard uitvoer) en `Bestand`. `Bestand` logging bevat `log.txt` bestand in het programma map en `logs` map voor archiefdoeleinden.

Het gebruik van aangepaste NLog configuratie schakelt de standaard ASF configuratie uit, uw configuratie overschrijft **volledig** standaard ASF logging, wat betekent dat als u wilt behouden. . ons `ColoredConsole` doel, dan moet je het zelf definiëren ****. Dit stelt je in staat om niet alleen **extra** logdoelen, maar ook **standaard** uit te schakelen of aan te passen.

Als u gebruik wilt maken van de standaard ASF logging zonder enige wijziging, je hoeft niets te doen - je hoeft het ook niet te definiëren in aangepaste `NLog. configuratie`. Voor wat betreft de standaardlogboeknaam ASF zou dat echter het volgende zijn:

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

## ASF integratie

ASF bevat leuke code-trucs die de integratie met NLogin verbeteren, waardoor je makkelijker specifieke berichten kunt ophalen.

NLog-specifieke `${logger}` variabele maakt altijd onderscheid tussen de bron van het bericht - het is `BotName` van een van je bots, of `ASF` als het bericht direct van het ASF-proces komt. Op deze manier kun je gemakkelijk berichten krijgen met specifieke bot(s), of het ASF-proces (alleen) in plaats van allemaal, gebaseerd op de naam van de logger.

ASF probeert op de juiste manier berichten te markeren op basis van log-niveaus van NLog, Hierdoor kunt u alleen specifieke berichten halen op specifieke logniveaus in plaats van alle. Natuurlijk kan het logboekniveau voor een specifiek bericht niet worden aangepast, omdat het een hardgecodeerde beslissing is hoe serieus een bericht is maar je kunt zeker ASF minder/stiller maken, zoals je wilt.

ASF logt extra info, zoals gebruiker/chatberichten op `Trace` logging level. Standaard ASF logboeklogboeken alleen `Debug` niveau en hoger, wat die extra informatie verbergt. omdat het niet nodig is voor de meerderheid van de gebruikers, plus clutters uitvoer die mogelijk belangrijkere berichten bevat. U kunt echter gebruik maken van die informatie door `Trace` logniveau opnieuw in te schakelen vooral in combinatie met het loggen van slechts één specifieke bot van je keuze, met een bepaald evenement waarin je bent geïnteresseerd.

ASF probeert het over het algemeen zo eenvoudig en handig mogelijk te maken om alleen berichten te loggen die je wilt in plaats van je te dwingen om het handmatig te filteren via externe tools zoals `grep` en gelijken. Configureer NLog naar behoren zoals hieronder geschreven en u moet in staat zijn om zelfs zeer complexe logregels te specificeren met aangepaste doelen zoals hele databases.

Over versiebeheer - ASF probeert altijd te verzenden met de meest recente versie van NLog die beschikbaar is op **[NuGet](https://www.nuget.org/packages/NLog)** ten tijde van ASF release. Het mag geen probleem zijn om een functie te gebruiken die je kunt vinden op de NLog wiki in ASF - zorg ervoor dat je ook de nieuwste ASF gebruikt.

Als onderdeel van de ASF-integratie biedt ASF ook ondersteuning voor de extra ASF NLog logboekdoelen, die hieronder worden uitgelegd.

---

## Voorbeelden

Voorbeelden hieronder laten u zien hoe u het logboek naar uw zin kunt aanpassen.

Als een starter zullen we alleen **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)** doel gebruiken. Onze eerste `NLog.config` zal er zo uitzien:

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

De uitleg van bovenstaande configuratie is vrij simpel - we definiëren een **log doel**, dat is `ColoredConsole`, dan omleiden we **alle loggers** (`*`) van level `Debug` en hoger naar `ColoredConsole` doel dat we eerder gedefinieerd hebben.

Als je ASF start met bovenstaande `NLog. onfig` nu, alleen `ColoredConsole` doel zal actief zijn, en ASF zal niet naar `Bestand`schrijven, ongeacht de hardcoded ASF NLog configuratie.

Omdat we veel eigenschappen niet hebben gedefinieerd, zoals `lay-out`, was het geïnitialiseerd tot een standaard ingebouwde waarde in dit geval `${longdate}+unnamed@@0 ${level:uppercase=true}/h${logger}/h${message}`. We kunnen het aanpassen, bijvoorbeeld door alleen een bericht te loggen:

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

Als je ASF nu opent, zul je die datum opmerken. level en logger naam verdween. Je kreeg alleen ASF berichten in formaat van `Function() Message`.

We kunnen de configuratie aanpassen om meer dan één doel te loggen. Laten we naar `ColoredConsole` en **[`Bestand`](https://github.com/nlog/nlog/wiki/File-target)** tegelijkertijd loggen.

```xml
<?xml version="1.0" encoding="utf-8" ?>
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

En klaar, we loggen nu alles in op `ColoredConsole` en `Bestand`. Heeft u gemerkt dat u ook aangepaste `bestandsnaam` en extra opties kunt specificeren?

Ten slotte gebruikt ASF verschillende logboeken, om het voor je makkelijker te maken om te begrijpen wat er aan de hand is. We kunnen die informatie gebruiken om de ernst van de houtkap aan te passen. Laten we zeggen dat we alles willen loggen (`Trace`) naar `Bestand`, maar alleen `Waarschuwing` en hoger dan **[log niveau](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)</a>** naar de `ColoredConsole`. We kunnen dat bereiken door onze `regels` te wijzigen:

```xml
<?xml version="1.0" encoding="utf-8" ?>
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

Dat is het, nu onze `ColoredConsole` alleen waarschuwingen en hoger laat zien, terwijl ze nog steeds alles logt naar `Bestand`. Je kunt het nog meer aanpassen om te loggen, bijvoorbeeld `Info` en hieronder, enzovoort.

Tot slot, laten we iets meer geavanceerde berichten doen en alle berichten loggen om te besteden, maar alleen van een bot genaamd `LogBot`.

```xml
<?xml version="1.0" encoding="utf-8" ?>
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

U kunt zien hoe we ASF integratie hierboven en gemakkelijk de bron van het bericht hebben gebruikt op basis van `${logger}` eigendom.

---

## Geavanceerd gebruik

De bovenstaande voorbeelden zijn vrij eenvoudig en gemaakt om je te laten zien hoe gemakkelijk het is om je eigen logregels te definiëren die bij ASF gebruikt kunnen worden. Je kunt NLog gebruiken voor verschillende dingen, inclusief complexe doelen (zoals het bijhouden van logs in `Database`), logs rotatie (zoals het verwijderen van oude `bestand` logboeken) met behulp van aangepaste `Lay-out`s, met een eigen `<when>` logging filters en nog veel meer. Ik moedig je aan om de hele **[NLog documentatie](https://github.com/nlog/nlog/wiki/Configuration-file)** door te lezen om te leren over elke optie die voor jou beschikbaar is. geeft je de mogelijkheid om ASF log-module op een manier te verfijnen. Het is een zeer krachtig gereedschap en het aanpassen van ASF was nooit gemakkelijker.

---

## Beperkingen

ASF zal tijdelijk **alle** regels uitschakelen die `ColoredConsole` of `Console` doelen bevatten bij het verwachten van gebruikersinvoer. Als je daarom wilt blijven loggen voor andere doelen, zelfs als ASF gebruikersinvoer verwacht, moet je die doelen definiëren met hun eigen regels zoals getoond in bovenstaande voorbeelden, in plaats van veel doelen in `writeTo` van dezelfde regel te zetten (tenzij dit je gewenste gedrag is). Tijdelijke uitschakelen van console-doelen wordt gedaan om de console leeg te houden bij het wachten op de gebruiker invoer.

---

## Chat logboek

ASF bevat uitgebreide ondersteuning voor chat logging door niet alleen alle ontvangen/verzonden berichten op `Trace` log niveau op te nemen maar ook extra info onthullen die met hen verband houdt in **[event eigenschappen](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Dit komt omdat we chatberichten toch als opdrachten moeten behandelen dus het kost ons niets om deze gebeurtenissen te loggen om het mogelijk te maken extra logica toe te voegen (zoals het maken van je persoonlijke Steam chatarchief).

### Event eigenschappen

| Naam        | Beschrijving                                                                                                                                                                                                                    |
| ----------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Echo        | `bool` type. This is set to `true` when message is being sent from us to the recipient, and `false` otherwise.                                                                                                                  |
| bericht     | `string` type. Dit is het actuele verzonden/ontvangen bericht.                                                                                                                                                                  |
| ChatGroupID | `ulong` type. Dit is het ID van de groepschat voor verzonden/ontvangen berichten. Zal `0` worden wanneer er geen groepschat wordt gebruikt om dit bericht te verzenden.                                                         |
| ChatID      | `ulong` type. Dit is de ID van het `ChatGroupID` kanaal voor verzonden/ontvangen berichten. Zal `0` worden wanneer er geen groepschat wordt gebruikt om dit bericht te verzenden.                                               |
| SteamID     | `ulong` type. Dit is de ID van de Steam gebruiker voor verzonden/ontvangen berichten. Kan `0` worden wanneer geen bepaalde gebruiker betrokken is bij het bericht (bijv. . wanneer we een bericht sturen naar een groeps-chat). |

### Voorbeeld

Dit voorbeeld is gebaseerd op onze `ColoredConsole` basisvoorbeeld hierboven. Voordat je probeert het te begrijpen Ik raad ten zeerste aan om een kijkje te nemen **[boven](#examples)** om eerst te leren over de basisprincipes van NLog loggen.

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

We zijn begonnen met ons basisvoorbeeld `ColoredConsole` en hebben het verder uitgebreid. In de eerste plaats we hebben een permanent chatlogbestand voorbereid per groepskanaal en Steam gebruiker - dit is mogelijk dankzij extra eigenschappen die ASF op een mooie manier aan ons blootstelt. We hebben ook besloten om met een aangepaste lay-out te gaan die alleen de huidige datum schrijft, het bericht, verzonden/ontvangen info en de Steam gebruiker zelf. Tot slot hebben we onze chat logging regel alleen ingeschakeld voor `Trace` level, alleen voor onze `Hoofdaccount` bot en alleen voor functies gerelateerd aan chat-log (`OnInkomend*` die wordt gebruikt voor het ontvangen van berichten en echos, en `VerzendenBericht*` voor het verzenden van ASF berichten).

Het voorbeeld hierboven zal `logs/chat/0-0-76561198069026042.txt` bestand genereren wanneer je praat met **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 hoe gaat het met je? -> 76561198069026042
2018-07-26 01:38:38 Ik doe het geweldig, hoe zit het met je? <- 76561198069026042
```

Natuurlijk is dit slechts een werkend voorbeeld met een paar mooie uitzettrucs die in de praktijk te zien zijn. Je kunt dit idee verder uitbreiden naar je eigen behoeften, zoals extra filteren, aangepaste volgorde, persoonlijke lay-out, het opnemen van alleen ontvangen berichten, enzovoort.

### Een ander voorbeeld

Deze persoon maakt gebruik van `SteamTarget` om een bericht te sturen naar de steamID van de hoofdbot (`76561198006963719`) wanneer bot `archi` een donatie transactie ontvangt. Vereist een andere bot in het proces (omdat je geen berichten kunt sturen naar jezelf).

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

## ASF doelen

Naast standaard NLog logging doelen (zoals `ColoredConsole` en `Bestand` hierboven uitgelegd), je kunt ook eigen ASF-logboekdoelen gebruiken.

Voor maximale volledigheid, de definitie van ASF doelen zal volgen op de NLog documentatie conventie.

---

### SteamDoel

Zoals je kunt raden, gebruikt dit doel Steam chat berichten om ASF berichten te loggen. Je kunt dit configureren om ofwel een groepschat of een privéchat te gebruiken. Naast het specificeren van een Steam doel voor je berichten, je kan ook opgeven `botName` van de bot die deze zou moeten versturen.

Ondersteund in alle omgevingen gebruikt door ASF.

---

#### Configuratie syntaxis
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

Lees meer over het gebruik van het [configuratiebestand](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parameters

##### Algemene Opties
_naam_ - Naam van het doel.

---

##### Lay-out opties
_lay-out_ - tekst die moet worden weergegeven. [Layout](https://github.com/NLog/NLog/wiki/Layouts) vereist. Standaardinstelling: `${level:uppercase=true}½${logger}${message}`

---

##### SteamTarget Opties

_chatGroupID_ - ID van de groepschat aangemerkt als 64-bit lang niet-ondertekend geheel getal. Niet vereist. Standaard ingesteld op `0` waarmee de groepschat functionaliteit wordt uitgeschakeld en privé chat wordt gebruikt. Wanneer ingeschakeld (ingesteld op niet-nul waarde), `steamID` eigenschap hieronder fungeert als `chatID` en geeft ID aan van het kanaal in deze `chatGroupID` waar de bot berichten naar moet sturen.

_steamID_ - SteamID gedeclareerd als 64-bit lang niet ondertekend integer van de target Steam gebruiker (zoals `SteamOwnerID`), of doel `chatID` (wanneer `chatGroupID` is ingesteld). Vereist. Standaard `0` wat het loggen van doel volledig uitschakelt.

_botName_ - Naam van de bot (zoals het herkend door ASF, hoofdlettergevoelig) die berichten zal sturen naar `steamID` hierboven verklaard. Niet vereist. Standaard `null` die automatisch **zal selecteren als een** momenteel aangesloten bot. Het wordt aangeraden om deze waarde op de juiste manier in te stellen, omdat `SteamTarget` geen rekening houdt met vele beperkingen op Steam zoals het feit dat je `steamID` van het doel op je vriendenlijst moet hebben. Deze variabele is gedefinieerd als [lay-out](https://github.com/NLog/NLog/wiki/Layouts) type, daarom kun je er speciale syntaxis in gebruiken zoals `${logger}` om de bot te gebruiken die het bericht heeft gegenereerd.

---

#### SteamTarget Voorbeelden

Om alle berichten van `Debug` niveau en hoger te schrijven, van bot genaamd `MyBot` tot steamID van `76561198006963719`, moet je `NLog.` gelijkaardig aan hieronder:

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

**Melding:** Onze `SteamTarget` is aangepast doelwit, dus moet je ervoor zorgen dat je het als `type="Steam"`noemt, NIET `xsi:type="Steam"`, omdat xsi is gereserveerd voor officiële doelen ondersteund door NLog.

Wanneer je ASF opstart met `NLog. configuratie` vergelijkbaar met hierboven, `MyBot` zal beginnen met berichten `76561198006963719` Steam gebruiker met alle gebruikelijke ASF logberichten. Houd in gedachten dat `MyBot` moet zijn verbonden om berichten te kunnen verzenden, dus alle initiële ASF berichten die zijn gebeurd voordat onze bot verbinding kon maken met het Steam netwerk, zullen niet worden doorgestuurd.

Natuurlijk heeft `SteamTarget` alle typische functies die je van algemene `TargetWithLayout`kunt verwachten, zodat je het kunt gebruiken in combinatie met e. . aangepaste lay-outs, namen of geavanceerde logging regels. Het voorbeeld hierboven is slechts het meest fundamenteele.

---

#### Schermafbeeldingen

![Screenshot](https://i.imgur.com/5juKHMt.png)

---

#### Opmerkingen

Wees voorzichtig wanneer je besluit om `Debug` logniveau of lager te combineren in je `SteamTarget` met `steamID` die deelnemen aan het ASF-proces. Dit kan leiden tot een mogelijke `StackOverflowException` omdat je een oneindige lus van ASF maakt die een bepaald bericht ontvangt. vervolgens via Steam loggen, wat resulteert in een ander bericht dat geregistreerd moet worden. Currently the only possibility for it to happen is to log `Trace` level (where ASF records its own chat messages), or `Debug` level while also running ASF in `Debug` mode (where ASF records all Steam packets).

Kortom, als je `steamID` deelneemt aan hetzelfde ASF-proces, dan moet `minlevel` logging level van je `SteamTarget` `Info` (of `Debug` zijn als je ook niet ASF gebruikt in `Debug` modus) en hoger. Als alternatief kunt u uw eigen `<when>` logging filters definiëren om oneindige logging loop te voorkomen, als u het niveau niet wijzigt voor uw zaak. Dit voorbehoud is ook van toepassing op groepsgesprekken.

---

### HistoryTarget

Dit doel wordt intern gebruikt door ASF voor het verstrekken van loggeschiedenis met vaste grootte in `/Api/NLog` eindpunt van **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** die daarna kan worden verbruikt door ASF-ui en andere hulpmiddelen. In het algemeen moet u dit doel alleen definiëren als u al aangepaste NLog config gebruikt voor andere aanpassingen en u wilt dat het logboek ook zichtbaar is in ASF API, bv. . voor ASF-ui. Het kan ook worden aangegeven wanneer je de standaard lay-out wilt wijzigen of `maxCount` van opgeslagen berichten.

Ondersteund in alle omgevingen gebruikt door ASF.

---

#### Configuratie syntaxis
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Lees meer over het gebruik van het [configuratiebestand](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parameters

##### Algemene Opties
_naam_ - Naam van het doel.

---

##### Lay-out opties
_lay-out_ - tekst die moet worden weergegeven. [Layout](https://github.com/NLog/NLog/wiki/Layouts) vereist. Standaard: `${date:format=yyyy-MM-dd HH\:mm\:ss}##${processname}-${processid}## ${level:upcase=true}‧${logger}x^${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### HistoryTarget Opties

_maxCount_ - Maximum aantal opgeslagen logs voor on-demand geschiedenis. Niet vereist. Standaard is `20` een goede balans voor het verstrekken van de eerste geschiedenis. waarbij het geheugengebruik dat niet aan de opslagvereisten voldoet, nog steeds in het oog wordt gehouden. Moet groter zijn dan `0`.