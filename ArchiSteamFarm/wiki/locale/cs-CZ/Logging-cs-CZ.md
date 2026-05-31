# Logování

ASF vám umožňuje nakonfigurovat vlastní logovací modul, který bude použit během běhu jízdy. Můžete tak učinit vložením zvláštního souboru s názvem `NLog.config` do adresáře aplikace. Celou dokumentaci NLog na **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**si můžete přečíst ale kromě toho najdete i některé užitečné příklady.

---

## Výchozí logování

Ve výchozím nastavení ASF zapisuje do `ColoredConsole` (standardní výstup) a `File`. `File` logování zahrnuje `log.txt` soubor v adresáři programu a `logy` pro účely archivace.

Použití vlastní konfigurace NLog automaticky zakáže výchozí konfiguraci ASF, vaše nastavení přepíše **kompletně** výchozí ASF logování, což znamená, že pokud chcete mít e. . náš cíl `ColoredConsole` , pak jej musíte definovat **sám**. This allows you to not only add **extra** logging targets, but also disable or modify **default** ones.

Pokud chcete použít výchozí protokolování ASF bez jakýchkoli úprav, nemusíte dělat nic - také to nemusíte definovat ve vlastním `NLog. onfig`. Pro referenční údaje by však ekvivalent standardního protokolu ASF byl tento:

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

## Integrace ASF

ASF obsahuje několik pěkných triků, které zlepšují jeho integraci s NLog, což vám umožní snadněji chytit konkrétní zprávy.

Specifická proměnná `${logger}` bude vždy rozlišovat zdroj zprávy - bude to buď `BotName` jednoho z vašich botů, nebo `ASF` pokud zpráva pochází z postupu ASF přímo. Tímto způsobem můžete snadno chytat zprávy s ohledem na konkrétního bota, nebo ASF proces (pouze), místo všech na základě jména loggeru.

ASF se pokouší vhodně označovat zprávy na základě úrovně protokolování poskytnutého NLog, který vám umožňuje chytat pouze konkrétní zprávy z konkrétních úrovní logu namísto všech těchto zpráv. Úroveň protokolování pro konkrétní zprávu samozřejmě nemůže být upravena, protože ASF tvrdě kódované rozhodnutí o tom, jak je daná zpráva vážná, ale jistě můžete aplikaci ASF ztišit/zticha, jak to považujete za vhodné.

ASF logy navíc, například uživatelské/chatové zprávy na `Trace` úrovni logování. Výchozí protokoly ASF pouze `Debug` úrovně a vyšší, což skrývá další informace, protože to není potřeba pro většinu uživatelů, plus spojovací výstupy obsahující potenciálně důležitější zprávy. Tyto informace však můžete využít opětovným povolením `Trace` logovací úrovně, zvláště v kombinaci s logováním pouze jednoho konkrétního bota dle vašeho výběru, s konkrétní událostí, o kterou se zajímáte.

Obecně se ASF snaží udělat to pro vás co nejjednodušší a nejvýhodnější, pro zaznamenávání pouze zpráv, které chcete, namísto toho, abyste vás nutili ručně filtrovat pomocí nástrojů třetích stran, jako je `grep` a podobně. Jednoduše nakonfigurujte NLog správně, jak je uvedeno níže, a měli byste být schopni specifikovat i velmi složitá logovací pravidla s vlastními cíli, jako jsou celé databáze.

Pokud jde o verzi - ASF se pokouší vždy dodávat s nejaktuálnější verzí NLog, která je k dispozici na **[NuGet](https://www.nuget.org/packages/NLog)** v době vydání ASF. Nemělo by být problém s použitím jakékoli funkce, kterou můžete najít na NLog wiki v ASF - jen se ujistěte, že používáte aktuální ASF.

V rámci integrace ASF obsahuje ASF také podporu pro další cíle ASF NLog logování, což bude vysvětleno níže.

---

## Příklady

Příklady níže ukazují, jak si můžete přizpůsobit logování podle vašich představ.

Jako začátek použijeme pouze cíl **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)**. Naše počáteční `NLog.config` bude vypadat takto:

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

Vysvětlení výše uvedené konfigurace je poměrně jednoduché - definujeme jeden **logovací cíl**, což je `ColoredConsole`pak přesměrujeme **všechny logery** (`*`) z úrovně `Debug` a vyšší na `ColoredConsole` cíl, který jsme definovali dříve.

Pokud spustíte ASF s `NLog. onfig` nyní bude aktivní pouze `ColoredConsole` , a ASF nebude zapisovat do `souboru`bez ohledu na hardkódované ASF NLog.

Protože jsme nedefinovali mnoho vlastností, jako je `rozložení`, byla inicializována na výchozí vestavěnou hodnotu. v tomto případě `${longdate}|${level:uppercase=true}|${logger}|${message}` Můžeme jej upravit, například logováním pouze zprávy:

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

Pokud nyní spustíte aplikaci ASF, všimnete si toho data, úroveň a název logeru zmizel - zanechal jste pouze s ASF zprávami ve formátu `Funkční () zpráva`.

Také můžeme upravit konfiguraci pro přihlášení na více než jeden cíl. Pojďme se přihlásit do `ColoredConsole` a **[`Soubor`](https://github.com/nlog/nlog/wiki/File-target)** současně.

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

A hotovo, budeme nyní zaznamenávat vše do `ColoredConsole` a `File`. Všimli jste si, že můžete také zadat vlastní `fileName` a další možnosti?

A konečně, ASF používá různé úrovně logů, aby vám usnadnil pochopení toho, co se děje. Tyto informace můžeme použít pro úpravu zaznamenávání závažnosti. Řekněme, že chceme zaznamenat vše (`Trace`) do `File`, ale pouze `Varování` a nad **[úroveň logů](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** `ColoredConsole`. Toho můžeme dosáhnout změnou našich `pravidel`:

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

To je to, nyní naše `ColoredConsole` zobrazí pouze upozornění a výše, zatímco stále vše zaznamenává do `File`. Můžete ho dále upravit, aby se protokolovalo např. pouze `Info` a níže a tak dále.

Konečně udělejme něco trochu pokročilejšího a zaznamenávejme všechny zprávy do souboru, ale pouze od bota s názvem `LogBot`.

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

Můžete vidět, jak jsme použili ASF integraci nad a snadno odlišitelný zdroj zprávy na základě vlastnosti `${logger}`.

---

## Pokročilé používání

Příklady uvedené výše jsou poměrně jednoduché a ukázaly, jak snadné je definovat vlastní logovací pravidla, která lze použít s ASF. Můžete použít NLog pro různé věci, včetně složitých cílů (např. uchovávání logů v `Database`), rotace logů (jako například odstranění starých `souborů` logů), používání vlastního `rozložení`a vyhlašování vlastního `<when>` logovacích filtrů a mnohem více. Doporučuji vám, abyste si přečetli celou **[NLog dokumentaci](https://github.com/nlog/nlog/wiki/Configuration-file)** a zjistili všechny možnosti, které máte k dispozici. umožňuje doladit ASF logovací modul tak, jak chcete. Je to opravdu výkonný nástroj a přizpůsobení ASF logování nikdy nebylo snadné.

---

## Omezení

ASF dočasně zakáže **všechna** pravidla, která zahrnují `ColoredConsole` nebo `Console` cíle pro očekávaný vstup uživatele. Proto pokud chcete pokračovat v logování pro jiné cíle, i když ASF očekává vstup uživatele, měli byste definovat tyto cíle s vlastními pravidly, jak je uvedeno v příkladech výše, místo vkládání mnoha cílů do `writeTo` stejného pravidla (pokud to není vaše chtěné chování). Dočasné vypnutí cílů konzole je prováděno, aby konzole byla při čekání na vstup uživatele čistá.

---

## Logování chatu

ASF zahrnuje rozšířenou podporu logování chatu tím, že nejen nahrává všechny přijaté a odeslané zprávy na úrovni logování `Trace` , ale také vystavování dalších informací o nich v **[vlastnostech události](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Je to proto, že stejně musíme zpracovat zprávy v chatu jako příkazy, takže nám nic nestojí zaznamenávání těchto událostí, aby bylo možné přidat další logiku (jako například ASF váš osobní archiv chatování na Steamu).

### Vlastnosti události

| Jméno            | L 343, 22.12.2009, s. 1).                                                                                                                                                                                    |
| ---------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Echo             | `bool typu`. Toto je nastaveno na `true` , když od nás odesílá zpráva příjemci, a `false` v opačném případě.                                                                                                 |
| Zpráva           | `řetězec` typ. Jedná se o odeslanou/obdrženou zprávu.                                                                                                                                                        |
| ID skupiny chatů | `ulong` type. Toto je ID skupinového chatu pro odeslané a přijaté zprávy. Bude `0` , když se pro přenos této zprávy nepoužívá žádný skupinový chat.                                                          |
| ID chatu         | `ulong` type. Toto je ID kanálu `ChatGroupID` pro odeslané a přijaté zprávy. Bude `0` , když se pro přenos této zprávy nepoužívá žádný skupinový chat.                                                       |
| SteamID          | `ulong` type. Toto je ID uživatele Steam pro odeslané a přijaté zprávy. Může být `0` , pokud není do přenosu zprávy zapojen žádný konkrétní uživatel (např. . když nám pošleme zprávu do skupinového chatu). |

### Příklad

Tento příklad vychází ze základního příkladu výše uvedeného `ColoredConsole`. Před pokusem se o pochopení, Důrazně doporučuji podívat se **[nad](#examples)** abyste se nejprve dozvěděli o základech NLog logování.

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

Začali jsme z našeho základního příkladu `ColoredConsole` a rozšířili jsme jej dále. V první řadě Připravili jsme trvalý chatový log soubor pro každý skupinový kanál a uživatele Steam - to je možné díky dalším vlastnostem, které nám ASF představí úžasným způsobem. Také jsme se rozhodli přejít s vlastním rozložením, které píše pouze aktuální datum, zprávu, odeslané informace a samotného uživatele Steamu. Nakonec jsme povolili naše logovací pravidlo pro chat pouze pro `Trace` , pouze pro náš `MainAccount` bota a pouze pro funkce související s logováním chatu (`OnIncoming*` , které se používají pro přijímání zpráv a echos, a `Odeslat zprávu*` pro odesílání zpráv ASF).

Výše uvedený příklad vygeneruje soubor `logs/chat/0-0-76561198069026042.txt` , když mluví s **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 jak to děláte? -> 76561198069026042
2018-07-26 01:38:38 dělám skvělé? <- 76561198069026042
```

Samozřejmě je to jen pracovní příklad s několika pěknými rozvrženými triky ukázané praktickým způsobem. Můžete dále rozšířit tuto myšlenku na své vlastní potřeby, jako je filtrování navíc, vlastní objednávka, osobní rozložení, záznam pouze přijatých zpráv atd.

### Další příklad

Toto používá `SteamTarget` k odeslání zprávy hlavnímu botovi steamID (`76561198006963719`), když bota jménem `archi` obdrží obchod s dárci. Vyžaduje v procesu jiného bota (protože nemůžete posílat zprávy sobě).

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

## Cíle ASF

Kromě standardních NLog logovacích cílů (jako je `ColoredConsole` a `soubor` vysvětlený výše), můžete také použít vlastní ASF logovací cíle.

Pro maximální úplnost se definice cílů ASF řídí úmluvou NLog.

---

### SteamTarget

Jak můžete odhadnout, tento cíl používá Steam chat zprávy pro protokolování ASF zpráv. Můžete jej nakonfigurovat pro použití skupinového chatu nebo soukromého chatu. Kromě stanovení cíle Steamu pro vaše zprávy, můžete také zadat `botName` bota, který je má odeslat.

Podporováno ve všech prostředích využívaných ASF.

---

#### Konfigurace syntaxe
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

Přečtěte si více o používání [konfiguračního souboru](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametry

##### Obecné možnosti
_název_ - Název cíle.

---

##### Možnosti rozvržení
_rozložení_ - text, který má být vykreslen. [rozložení](https://github.com/NLog/NLog/wiki/Layouts) vyžadováno. Výchozí: `${level:uppercase=true}|${logger}|${message}`

---

##### Možnosti SteamTarget

_chatGroupID_ - ID skupinového chatu deklarovaného jako 64bitové dlouhé celé číslo. Není nutné stanovit MRL. Výchozí hodnota je `0` , což zakáže funkci skupinového chatu a místo toho použije soukromý chat. Je-li povoleno (nastavit na nenulovou hodnotu), Vlastnost `steamID` funguje jako `chatID` a specifikuje ID kanálu v tomto `chatGroupID` , do kterého by měl bota posílat zprávy.

_steamID_ - SteamID je deklarován jako 64bitové dlouhé celé číslo cílového uživatele Steam (jako `SteamOwnerID`) nebo cílový `chatID` (když je nastaveno `chatGroupID`) Povinné. Výchozí nastavení je `0` , které zcela zakáže logování.

_botName_ - Název bota (jak je rozpoznán ASF, malá a velká písmena), který bude odesílat zprávy do `steamID` uvedené výše. Není nutné stanovit MRL. Výchozí nastavení je `null` , které automaticky vybere **jakýkoliv** aktuálně připojený bot. Doporučujeme tuto hodnotu nastavit, protože `SteamTarget` nebere v úvahu mnoho omezení ze Steamu, jako je skutečnost, že musíte mít `steamID` cíle na vašem seznamu přátel. Tato proměnná je definována jako typ [rozložení](https://github.com/NLog/NLog/wiki/Layouts) , proto v ní můžete použít speciální syntaxi, jako `${logger}` pro použití bota, který vytvořil zprávu.

---

#### Příklady SteamTarget

pro zápis všech zpráv na úrovni `Debug` a vyšší, z bota jménem `MyBot` na steamID `76561198006963719`, měli byste použít `NLog. onfig` podobně jako níže:

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

**Poznámka:** Náš `SteamTarget` je vlastní cíl, abyste se ujistili, že jej deklarujete jako `type="Steam"`, NENÍ `xsi:type="Steam"`, protože xsi je vyhrazen pro oficiální cíle podporované NLog.

Když spustíte ASF s `NLog. onfig` podobné výše `MyBot` začne zasílat zprávy `76561198006963719` uživatel Steam se všemi obvyklými protokoly ASF. Mějte na paměti, že `MyBot` musí být připojen, aby bylo možné posílat zprávy, takže všechny úvodní zprávy ASF, které se staly dříve, než se náš bot mohl připojit k síti Steam, nebudou předány.

`SteamTarget` má samozřejmě všechny typické funkce, které byste mohli očekávat od generické `TargetWithLayout`, takže ho můžete použít společně s e. . vlastní rozvržení, jména nebo pravidla pokročilého logování. Výše uvedený příklad je pouze ten nejzákladnější.

---

#### Snímek obrazovky

![Snímek obrazovky](https://i.imgur.com/5juKHMt.png)

---

#### Kavárna

Buďte opatrní, když se rozhodnete kombinovat úroveň protokolování `ladění` nebo níže ve vašem `SteamTarget` s `steamID` , které se účastní procesu ASF. To může vést k možnému `StackOverflowException` , protože vytvoříte nekonečnou smyčku pro příjem dané zprávy, poté se přihlásí přes Steam, což vede k další zprávě, která musí být přihlášena. V současné době je jedinou možností, aby se to stalo, logování `Trace` úrovně (kde ASF nahrává své vlastní chatové zprávy), nebo `na úrovni Debug` při běhu ASF v režimu `Debug` (kde ASF nahrává všechny Steam pakety).

Stručně řečeno, pokud se váš `steamID` účastní stejného procesu ASF, pak úroveň protokolování `min-level` v `SteamTarget` by měla být `Info` (nebo `ladění` , pokud také nepoužíváte ASF v režimu `Ladění` ) a výše. Případně můžete definovat vlastní `<when>` logovací filtry, aby se zabránilo nekonečné logovací smyčce, pokud není úprava úrovně pro váš případ vhodná. Tato výhrada platí i pro skupinové chaty.

---

### HistoryTarget

Tento cíl používá interně ASF pro vytvoření fixní historie protokolování v `/Api/NLog` koncovém bodu **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** , který může být následně spotřebován ASF-ui a dalšími nástroji. Obecně byste měli definovat tento cíl pouze v případě, že již používáte vlastní NLog konfiguraci pro další přizpůsobení a také chcete, aby byl log zobrazen v ASF API, e. . pro ASF-ui. Může být také deklarován, pokud chcete změnit výchozí rozložení nebo `maxCount` uložených zpráv.

Podporováno ve všech prostředích využívaných ASF.

---

#### Konfigurace syntaxe
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Přečtěte si více o používání [konfiguračního souboru](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametry

##### Obecné možnosti
_název_ - Název cíle.

---

##### Možnosti rozvržení
_rozložení_ - text, který má být vykreslen. [rozložení](https://github.com/NLog/NLog/wiki/Layouts) vyžadováno. Výchozí: `${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### Možnosti HistoryTarget

_maxCount_ - Maximální množství uložených logů pro historii na vyžádání. Není nutné stanovit MRL. Výchozí nastavení `20` , což je dobrý zůstatek pro poskytování počáteční historie, při současném vědomí využití paměti, které přichází z požadavků na úložiště. Musí být větší než `0`.