# Logowanie

ASF pozwala skonfigurować własny moduł logowania, który będzie używany podczas pracy. Możesz to zrobić umieszczając specjalny plik o nazwie `NLog.config` w katalogu aplikacji. Możesz przeczytać całą dokumentację NLog na **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**, ale dodatkowo znajdziesz tutaj kilka przydatnych przykładów.

---

## Domyślne logowanie

Domyślnie ASF loguje się do `ColoredConsole` (standardowe wyjście) i `Plik`. `File` logging zawiera plik `log.txt` w katalogu programu oraz katalog `logs` do celów archiwalnych.

Używanie niestandardowej konfiguracji NLog automatycznie wyłącza domyślną konfigurację ASF, twoja konfiguracja całkowicie nadpisuje **** domyślne logowanie ASF, co oznacza, że jeśli chcesz zachować. . nasz cel `ColoredConsole` , a następnie musisz go zdefiniować **samodzielnie**. Pozwala to nie tylko dodawać **dodatkowe** cele logowania, ale również wyłączyć lub zmodyfikować te **domyślne**.

Jeśli chcesz użyć domyślnego logowania ASF bez żadnych modyfikacji, nie musisz nic robić - nie musisz też definiować go w niestandardowym `NLog. onfig`. Dla celów odniesienia odpowiednikiem rejestrowanych domyślnych znaków ASF byłoby:

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

## Integracja ASF

ASF zawiera ładne sztuczki kodowe, które zwiększają jego integrację z NLog, umożliwiając łatwiejsze łapanie konkretnych wiadomości.

NLog-specific `${logger}` variable will always distinguish the source of the message - it will be either `BotName` of one of your bots, or `ASF` if message comes from ASF process directly. W ten sposób możesz z łatwością łapać wiadomości z uwzględnieniem określonych botów, lub ASF proces (tylko), zamiast wszystkiego, oparty na nazwie loggera.

ASF próbuje odpowiednio oznaczać wiadomości na podstawie poziomów rejestrowania dostarczanych przez NLog, co umożliwia pobieranie tylko określonych wiadomości z określonych poziomów logów zamiast z nich. Oczywiście, poziom logowania dla określonej wiadomości nie może być dostosowany, ponieważ ASF podejmuje decyzję o tym, jak poważny jest podany komunikat, ale z pewnością możesz sprawić, że ASF będzie mniej lub bardziej cichy, jak się wydaje.

ASF rejestruje dodatkowe informacje, takie jak wiadomości użytkownika/czatu na `Trace` poziom logowania. Domyślne logi ASF tylko na poziomie `Debug` i wyższym, co ukrywa te dodatkowe informacje, ponieważ nie jest potrzebny dla większości użytkowników, a także klucze wyjściowe zawierające potencjalnie ważniejsze wiadomości. Możesz jednak wykorzystać te informacje poprzez ponowne włączenie poziomu logowania `Trace` , szczególnie w połączeniu z logowaniem tylko jednego wybranego przez Ciebie bota, ze szczególnym wydarzeniem jesteś zainteresowany.

Zasadniczo ASF stara się sprawić, by był on dla Ciebie jak najłatwiejszy i wygodniejszy, aby rejestrować tylko wiadomości, których chcesz zamiast zmuszać cię do ręcznego filtrowania ich za pomocą narzędzi innych firm, takich jak `grep` i tak dalej. Po prostu skonfiguruj NLog poprawnie jak napisano poniżej, i powinieneś być w stanie określić nawet bardzo złożone zasady rejestrowania z niestandardowymi celami, takimi jak całe bazy danych.

W odniesieniu do wersji - ASF stara się zawsze wysyłać z najnowszą wersją NLog dostępną na **[NuGet](https://www.nuget.org/packages/NLog)** w momencie wydania ASF. Korzystanie z żadnej funkcji, którą możesz znaleźć na wiki NLog w ASF - po prostu upewnij się, że używasz również aktualnego ASF.

W ramach integracji ASF ASF ASF obejmuje również wsparcie dla dodatkowych celów w zakresie rejestrowania logów ASF, co zostanie wyjaśnione poniżej.

---

## Przykłady

Przykłady poniżej pokazują jak możesz dostosować logowanie do swoich potrzeb.

Jako starter użyjemy tylko celu **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)**. Nasze początkowe `NLog.config` będzie wyglądać tak:

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

Wyjaśnienie powyższej konfiguracji jest dość proste - definiujemy jeden cel logowania ****, czyli `ColoredConsole`, następnie przekierowujemy **wszystkich logentów** (`*`) poziomu `Debugowanie` i wyższego do celu `ColoredConsole` , który zdefiniowaliśmy wcześniej.

Jeśli zaczniesz ASF z powyżej `NLog. onfig` teraz, tylko cel `ColoredConsole` będzie aktywny, i ASF nie zapisze do `Plik`, niezależnie od konfiguracji ASF Nlog.

Ponieważ nie zdefiniowaliśmy wielu właściwości, takich jak `layout`, został on zainicjowany do domyślnej wbudowanej wartości, w tym przypadku `${longdate}|${level:uppercase=true}|${logger}|${message}`. Możemy go dostosować, na przykład rejestrując tylko wiadomość:

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

Jeśli uruchomisz ASF teraz, zauważysz tę datę, poziom i nazwa rejestratora zniknęły - zostawiając cię tylko z wiadomościami ASF w formacie `Funkcja() Wiadomość`.

Możemy również zmodyfikować konfigurację aby zalogować się do więcej niż jednego celu. Let's log to `ColoredConsole` and **[`File`](https://github.com/nlog/nlog/wiki/File-target)** at the same time.

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

I gotowe, teraz zalogujemy wszystko do `ColoredConsole` i `File`. Czy zauważyłaś, że możesz również określić niestandardową `nazwę pliku` i dodatkowe opcje?

Na koniec ASF używa różnych poziomów logów, aby ułatwić Ci zrozumienie, co się dzieje. Możemy wykorzystać te informacje do modyfikacji logowania dotkliwości. Powiedzmy, że chcemy zalogować wszystko (`Trace`) do pliku ``, ale tylko `ostrzeżenie` i powyżej **[log poziom](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** do `ColoredConsole`. Możemy to osiągnąć, zmieniając nasze zasady ``:

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

That's it, now our `ColoredConsole` will show only warnings and above, while still logging everything to `File`. Możesz go dalej dostosować, aby zalogować np. `Info` i poniżej i tak dalej.

Wreszcie, zrobimy coś bardziej zaawansowanego i zalogujmy wszystkie wiadomości do pliku, ale tylko z bota o nazwie `LogBot`.

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

Możesz zobaczyć, jak użyliśmy integracji ASF powyżej i z łatwością wyróżniono źródło wiadomości na podstawie właściwości `${logger}`.

---

## Zaawansowane użycie

Powyższe przykłady są dość proste i pokazują, jak łatwo jest zdefiniować własne zasady logowania, które mogą być używane w ASF. Możesz użyć NLog dla różnych rzeczy, w tym złożonych celów (takich jak przechowywanie logów w `Baza danych`), rotacja logów (np. usunięcie starego `pliku` logów), używając niestandardowego układu ``, uznając swoje własne filtry logowania `<when>` i wiele więcej. Zachęcam cię do przeczytania całej dokumentacji **[NLog](https://github.com/nlog/nlog/wiki/Configuration-file)** aby dowiedzieć się o każdej dostępnej dla Ciebie opcji, pozwalając na dopracowanie modułu logowania ASF w sposób, jaki chcesz. To naprawdę potężne narzędzie i dostosowanie logowania ASF nigdy nie było łatwiejsze.

---

## Ograniczenia

ASF tymczasowo wyłączy **wszystkie reguły** zawierające cele `ColoredConsole` lub `Konsoli` podczas oczekiwania na dane wejściowe użytkownika. Dlatego, jeśli chcesz nadal logować dla innych celów, nawet jeśli ASF oczekuje danych wejściowych użytkownika, powinieneś zdefiniować te cele z własnymi zasadami, jak pokazano w przykładach powyżej, zamiast umieszczać wiele celów w `writeTo` tej samej reguły (chyba że jest to Twoje pożądane zachowanie). Tymczasowe wyłączenie celów konsoli jest wykonane, aby konsola pozostała czysta podczas oczekiwania na wejście użytkownika.

---

## Logowanie Chat

ASF zawiera rozszerzone wsparcie dla logowania czatu poprzez nie tylko nagrywanie wszystkich odebranych/wysłanych wiadomości na poziomie logowania `Trace` , ale również wystawia dodatkowe informacje związane z nimi w **[właściwości zdarzenia](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Dzieje się tak, ponieważ i tak musimy obsługiwać wiadomości czatu jako polecenia, więc rejestracja tych wydarzeń nie kosztuje nas nic, aby umożliwić dodanie dodatkowej logiki (takiej jak tworzenie ASF osobistego archiwum czatów Steam).

### Właściwości wydarzenia

| Nazwa              | Opis                                                                                                                                                                                                                                 |
| ------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Echo               | Typ `bool`. To jest ustawione na `true` kiedy wiadomość jest wysyłana od nas do odbiorcy, a `false` w przeciwnym razie.                                                                                                              |
| Wiadomość          | Typ `string`. Jest to rzeczywista wiadomość/odebrana wiadomość.                                                                                                                                                                      |
| ID Czatu grupowego | `ulong` type. To jest ID czatu grupowego dla wysyłanych/odebranych wiadomości. Będzie `0` , gdy żaden czat grupowy nie jest używany do przesyłania tej wiadomości.                                                                   |
| ID Czatu           | `ulong` type. To jest ID kanału `ChatGroupID` dla wysyłanych lub odbieranych wiadomości. Będzie `0` , gdy żaden czat grupowy nie jest używany do przesyłania tej wiadomości.                                                         |
| SteamID            | `ulong` type. To jest ID użytkownika Steam dla wysyłanych lub odebranych wiadomości. Może być `0` , gdy żaden konkretny użytkownik nie jest zaangażowany w transmisję wiadomości (e. . kiedy wysyłamy wiadomość do czatu grupowego). |

### Przykład

Ten przykład jest oparty na naszym podstawowym przykładzie `ColoredConsole` powyżej. Zanim spróbujemy to zrozumieć, Zdecydowanie zalecam spojrzenie **[powyżej](#examples)** aby najpierw dowiedzieć się o podstawach logowania Nlog.

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

Zaczęliśmy od naszego podstawowego `ColoredConsole` i rozszerzyliśmy go dalej. Przede wszystkim, przygotowaliśmy stały plik dziennika czatu dla każdego kanału grupowego i użytkownika Steam - jest to możliwe dzięki dodatkowym właściwościom, które ASF wystawia nam w fantastyczny sposób. Zdecydowaliśmy się również przejść z niestandardowym układem, który zapisuje tylko bieżącą datę, wiadomość, informację wysłaną/odebraną oraz sam użytkownik Steam. Wreszcie, włączyliśmy naszą regułę rejestrowania czatu tylko dla poziomu `Trace` , tylko dla bota `MainAccount` i tylko dla funkcji związanych z logowaniem czatu (`Przychodzenie*` , które są używane do odbierania wiadomości i echo, i `SendMessage*` dla wysyłania wiadomości ASF).

Przykład powyżej wygeneruje plik `logs/chat/0-0-76561198069026042.txt` podczas rozmowy z **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 w jaki sposób jesteś? -> 76561198069026042
2018-07-26 01:38:38 robię świetnie, co z tobą? <- 76561198069026042
```

Oczywiście jest to tylko dobry przykład z kilkoma ładnymi sztuczkami graficznymi pokazanymi w praktyce. Możesz dalej rozszerzać ten pomysł na własne potrzeby, takie jak filtrowanie dodatkowe, zamówienie niestandardowe, układ osobisty, nagrywanie tylko otrzymanych wiadomości itd.

### Inny przykład

Ta opcja używa `SteamTarget` w celu wysłania wiadomości do SteamID głównego bota (`76561198006963719`) kiedy bot o nazwie `archi` otrzymuje darowiznę. Wymaga innego bota w procesie (ponieważ nie możesz wysyłać wiadomości do siebie).

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

## Cele ASF

Oprócz standardowych celów logowania Nlog (takich jak `ColoredConsole` i `File` objaśnione powyżej), możesz również używać niestandardowych celów logowania ASF.

Dla maksymalnej kompletności określenie celów ASF będzie zgodne z konwencją dotyczącą dokumentacji Nlog.

---

### Cel Steam

Jak się zgadza, ten cel wykorzystuje wiadomości czatu Steam do rejestrowania wiadomości ASF. Możesz go skonfigurować, aby używać czatu grupowego lub czatu prywatnego. Oprócz określenia celu Steam dla Twoich wiadomości, możesz również określić `botName` bota, który ma je wysłać.

Obsługiwane we wszystkich środowiskach wykorzystywanych przez ASF.

---

#### Składnia konfiguracji
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

Dowiedz się więcej o użyciu pliku konfiguracyjnego [](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametry

##### Opcje ogólne
_name_ - Nazwa celu.

---

##### Opcje układu
_layout_ - Tekst do renderowania. [Układ](https://github.com/NLog/NLog/wiki/Layouts) wymagany. Domyślnie: `${level:uppercase=true}|${logger}|${message}`

---

##### Opcje SteamTarget

_chatGroupID_ - ID czatu grupowego zadeklarowanego jako 64-bitowa liczba całkowita. Niewymagane. Domyślnie `0` , który wyłączy funkcje czatu grupowego i zamiast tego użyje czatu prywatnego. Gdy włączone (ustaw na wartość inną niż zero), Poniższa właściwość `steamID` działa jako `chatID` i określa ID kanału w tym `chatGroupID` , do którego bot powinien wysyłać wiadomości.

_steamID_ - SteamID deklarowany jako 64-bitowa niepodpisana liczba całkowita docelowego użytkownika Steam (jak `SteamOwnerID`), lub cel `chatID` (kiedy `chatGroupID` jest ustawiony). Wymagane. Domyślnie `0` , który całkowicie wyłącza cel logowania.

_botName_ - Nazwa bota (jak rozpoznaje ASF, wielkość liter ma znaczenie), który będzie wysyłał wiadomości do `steamID` podanego powyżej. Niewymagane. Domyślnie `null` , który automatycznie wybierze **dowolnego** aktualnie podłączonego bota. Zalecane jest odpowiednie ustawienie tej wartości, ponieważ `SteamTarget` nie uwzględnia wielu ograniczeń Steam, na przykład fakt, że musisz mieć `steamID` celu na liście znajomych. Ta zmienna jest zdefiniowana jako typ [layout](https://github.com/NLog/NLog/wiki/Layouts) , dlatego możesz użyć w niej specjalnej składni, takie jak `${logger}` w celu użycia bota, który wygenerował wiadomość.

---

#### Przykłady SteamTarget

Aby zapisać wszystkie wiadomości na poziomie `Debugowania` i wyższym, od bota o nazwie `MyBot` do SteamID `76561198006963719`, powinieneś użyć `NLog. onfig` podobny do poniżej:

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

**Uwaga:** Nasz `SteamTarget` jest niestandardowym celem, więc powinieneś upewnić się, że deklarujesz to jako `type="Steam"`, NIE `xsi:type="Steam"`, ponieważ xsi jest zarezerwowany dla oficjalnych celów obsługiwanych przez NLog.

Podczas uruchamiania ASF z `NLog. onfig` podobny do powyższego, `MyBot` rozpocznie wiadomość `76561198006963719` Użytkownik Steam ze wszystkimi zwykłymi wiadomościami ASF. Pamiętaj, że `MyBot` musi być połączony w celu wysyłania wiadomości, więc wszystkie początkowe wiadomości ASF, które miały miejsce przed połączeniem naszego bota z siecią Steam, nie będą przekazywane.

Oczywiście `SteamTarget` ma wszystkie typowe funkcje, których można oczekiwać od ogólnego `TargetWithLayout`, aby można było go stosować w połączeniu z e. . niestandardowe układy, nazwy lub zaawansowane zasady logowania. Powyższy przykład jest tylko najbardziej podstawowy.

---

#### Zrzuty ekranu

![Zrzut ekranu](https://i.imgur.com/5juKHMt.png)

---

#### Zastrzeżenia

Zachowaj ostrożność, gdy zdecydujesz się połączyć `Debugowanie` poziom logowania lub poniżej w `SteamTarget` z `steamID` , który bierze udział w procesie ASF. Może to prowadzić do potencjalnego `StackOverflowException` , ponieważ utworzysz nieskończoną pętlę ASF otrzymującą daną wiadomość, następnie logowanie go przez Steam, skutkując kolejną wiadomością, która wymaga logowania. Obecnie jedyną możliwością jest zalogowanie poziomu `Trace` (gdzie ASF zapisuje własne wiadomości czatu), lub `poziom` przy użyciu ASF w trybie `Debug` (gdzie ASF zapisuje wszystkie pakiety Steam).

Krótko mówiąc, jeśli `steamID` bierze udział w tym samym procesie ASF, następnie `minlevel` poziom logowania twojego `SteamTarget` powinien być `Info` (lub `Debugowanie` jeśli nie używasz również ASF w trybie `Debugowanie` i wyższy). Alternatywnie możesz zdefiniować własne `<when>` filtry logowania, aby uniknąć nieskończonej pętli logowania, jeśli zmiana poziomu nie jest odpowiednia dla Państwa przypadku. To zastrzeżenie dotyczy również czatów grupowych.

---

### HistoryTarget

Ten cel jest używany wewnętrznie przez ASF do dostarczania historii logowania o ustalonej wielkości w `/Api/NLog` punkt końcowy **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** , który może być następnie zużyty przez ASF-ui i inne narzędzia. Generalnie powinieneś zdefiniować ten cel tylko jeśli używasz niestandardowej konfiguracji NLog dla innych dostosowań, a także chcesz aby wpis był widoczny w ASF API, e. . dla ASF-ui. Można to również zadeklarować, gdy chcesz zmodyfikować domyślny układ lub `maxCount` zapisanych wiadomości.

Obsługiwane we wszystkich środowiskach wykorzystywanych przez ASF.

---

#### Składnia konfiguracji
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Dowiedz się więcej o użyciu pliku konfiguracyjnego [](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametry

##### Opcje ogólne
_name_ - Nazwa celu.

---

##### Opcje układu
_layout_ - Tekst do renderowania. [Układ](https://github.com/NLog/NLog/wiki/Layouts) wymagany. Domyślnie: `${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### Opcje HistoryTargetu

_maxCount_ - Maksymalna ilość zapisanych dzienników dla historii na żądanie. Niewymagane. Domyślnie `20` , który jest dobrym saldem dla początkowej historii, przy jednoczesnym pamiętaniu o wykorzystaniu pamięci, która nie jest wymagana do przechowywania. Musi być większa niż `0`.