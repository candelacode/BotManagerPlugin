# Konfiguracja

Ta strona jest przeznaczona do konfiguracji ASF. Służy jako pełna dokumentacja katalogu `config` , umożliwiając dostosowanie ASF do Twoich potrzeb.

* **[Wprowadzenie](#introduction)**
* **[Generator konfiguracji sieci Web](#web-based-configgenerator)**
* **[Konfiguracja ASF-ui](#asf-ui-configuration)**
* **[Ręczna konfiguracja](#manual-configuration)**
* **[Ustawienia globalne](#global-config)**
* **[Ustawienia bota](#bot-config)**
* **[Struktura pliku](#file-structure)**
* **[Mapowanie JSON](#json-mapping)**
* **[Mapowanie zgodności](#compatibility-mapping)**
* **[Zgodność konfiguracji](#configs-compatibility)**
* **[Automatyczne przeładowanie](#auto-reload)**

---

## Wprowadzenie

Konfiguracja ASF jest podzielona na dwie główne części - globalna (proces) konfiguracja i konfiguracja każdego bota. Każdy bot ma swój własny plik konfiguracyjny bota o nazwie `BotName. syn` (gdzie `BotName` jest nazwą bota), podczas gdy globalna konfiguracja ASF (proces) jest pojedynczym plikiem o nazwie `ASF. syn`.

Bot jest pojedynczym kontem parowym, który bierze udział w procesie ASF. Aby działać poprawnie, ASF potrzebuje co najmniej **jednej instancji określonego bota**. Nie ma narzuconego przez proces limitu instancji botów, więc możesz użyć tyle botów (kont Steam), ile chcesz.

ASF używa formatu **[JSON](https://en.wikipedia.org/wiki/JSON)** do przechowywania plików konfiguracyjnych. Jest to przyjazny dla człowieka, czytelny i bardzo uniwersalny format, w którym można skonfigurować program. Nie martw się jednak, nie musisz znać JSON aby skonfigurować ASF. Wspominałem o tym, gdybyś już chciał masowo tworzyć konfiguracje ASF z jakiegoś skryptu bash.

Konfiguracja może być wykonana na kilka sposobów. Możesz użyć naszego **[Web ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)**, który jest lokalną aplikacją niezależną od ASF. You can use our **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC frontend for configuration done directly in ASF. Na koniec zawsze możesz generować pliki konfiguracyjne ręcznie, ponieważ są zgodne ze strukturą JSON określoną poniżej. Wkrótce wyjaśnimy dostępne opcje.

---

## Generator konfiguracji sieci Web

Celem naszego **[Web ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** jest zapewnienie przyjaznego frontendu używanego do generowania plików konfiguracyjnych ASF. Konfiguracja sieciowa jest w 100% oparta na klientach, co oznacza, że dane, które wprowadzasz, nie są nigdzie wysyłane, ale przetwarzane lokalnie. Gwarantuje to bezpieczeństwo i niezawodność, ponieważ może nawet działać **[offline](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** jeśli chcesz pobrać wszystkie pliki i uruchomić indeks `. tml` w swojej ulubionej przeglądarce.

Generator konfiguracji sieciowej jest sprawdzany poprawnie, aby działać poprawnie w przeglądarkach Chrome i Firefox, ale powinien działać poprawnie we wszystkich najpopularniejszych przeglądarkach z dostępem do JavaScript.

Użycie jest dość proste - zaznacz czy chcesz wygenerować konfigurację `ASF` czy `Bot` przełączając się na właściwą kartę, upewnij się, że wybrana wersja pliku konfiguracyjnego pasuje do twojego wydania ASF, a następnie wprowadź wszystkie szczegóły i naciśnij przycisk "Pobierz". Przenieś ten plik do katalogu ASF `config` , nadpisując istniejące pliki w razie potrzeby. Powtórzyć dla wszystkich ewentualnych dalszych modyfikacji i w celu wyjaśnienia wszystkich dostępnych opcji należy odnieść się do pozostałej części niniejszej sekcji.

---

## Konfiguracja ASF-ui

Our **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC interface allows you to configure ASF as well, and is superior solution for reconfiguring ASF after generating the initial configs due to the fact that it can edit the configs in-place, as opposed to Web-based ConfigGenerator which generates them statically.

Aby korzystać z ASF-ui, musisz mieć włączony interfejs **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**. `IPC` jest domyślnie włączony, dlatego możesz uzyskać dostęp od razu, dopóki nie wyłączyłeś go.

Po uruchomieniu programu po prostu przejdź do ASF **[adres IPC](http://localhost:1242)**. Jeśli wszystko działało prawidłowo, możesz również zmienić konfigurację ASF.

---

## Ręczna konfiguracja

Generalnie zalecamy użycie naszego ConfigGenerator lub ASF-ui, ponieważ jest znacznie łatwiejszy i gwarantuje, że nie popełnisz błędu w strukturze JSON, ale jeśli z jakiegoś powodu nie chcesz, możesz również ręcznie utworzyć odpowiednie konfiguracje. Sprawdź przykłady JSON poniżej dla dobrego startu w odpowiedniej strukturze, możesz skopiować zawartość do pliku i użyć jej jako podstawy dla konfiguracji. Ponieważ nie używasz żadnej z naszych frontendów, upewnij się, że Twoja konfiguracja jest **[ważna](https://jsonlint.com)**, ponieważ ASF odmówi załadowania, jeśli nie może zostać przetworzony. Nawet jeśli jest to poprawny JSON, musisz również upewnić się, że wszystkie właściwości mają odpowiedni typ, zgodnie z wymogami ASF. Aby uzyskać odpowiednią strukturę JSON wszystkich dostępnych pól, zapoznaj się z sekcją **[mapowanie JSON](#json-mapping)** i naszą dokumentacją poniżej.

---

## Ustawienia globalne

Globalna konfiguracja znajduje się w pliku `ASF.json` i ma następującą strukturę:

```json
{
    "AutoRestart": true,
    "Blacklist": [],
    "CommandPrefix": "! ,
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "CurrentCulture": null,
    "Debug": false,
    "DefaultBot": null,
    "FarmingDelay": 15,
    "FilterBadBots": true,
    "GiftsLimiterDelay": 1,
    "Bezwaga": false,
    "IdleFarmingPeriod": 8,
    "InventoryLimiterDelay": 4,
    "IPC": true,
    "IPCPassword": null,
    "IPCPasswordFormat": 0,
    "LicenseID": null,
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldDuration": 15,
    "MinFarmingDelayAfterBlock": 60,
    "OptimizationMode": 0,
    "PluginsUpdateList": [],
    "PluginsUpdateMode": 0,
    "ShutdownIfPossible": false,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Wszystkie opcje zostały wyjaśnione poniżej:

### `AutoRestart`

`bool` typ z domyślną wartością `true`. Ta właściwość definiuje, czy ASF ma prawo do samodzielnego restartu w razie potrzeby. Istnieje kilka zdarzeń, które będą wymagały restartu ASF np. aktualizacja ASF (wykonana z poleceniem `UpdatePeriod` lub `aktualizacja` ) oraz `ASF. son` config edit, `restart komendy` i podobnie. Zazwyczaj restart obejmuje dwie części - tworzenie nowego procesu i zakończenie obecnego procesu. Większość użytkowników powinna być w dobrym stanie i zachować tę właściwość z domyślną wartością `true`, jednak - jeśli używasz ASF przez swój własny skrypt i/lub `dotnet`, być może chcesz mieć pełną kontrolę nad rozpoczęciem procesu, i unikać sytuacji, takich jak uruchomienie nowego (ponownego) ASF gdzieś w tle, a nie w pierwszym rzędzie skryptu, który zakończył się wraz ze starym procesem ASF. Jest to szczególnie ważne, biorąc pod uwagę fakt, że nowy proces nie będzie już Twoim bezpośrednim dzieckiem, co sprawi, że nie będzie pan w stanie zrobić. . aby użyć standardowych danych wejściowych konsoli.

Jeśli tak jest, ta właściwość, jeśli jest dla Ciebie i możesz ją ustawić na `false`. However, keep in mind that in such case **you** are responsible for restarting the process. Jest to w jakiś sposób ważne, ponieważ ASF wyjdzie tylko zamiast tworzenia nowego procesu (np. po uaktualnieniu), więc jeśli nie dodasz logiki, po prostu przestanie działać dopóki nie uruchomisz jej ponownie. ASF zawsze wychodzi z prawidłowym kodem błędu wskazującym sukces (zero) lub niepowodzenie (niezero), w ten sposób możesz dodać odpowiednią logikę w swoim skrypcie, co powinno zapobiec automatycznemu ponownemu uruchomieniu ASF w przypadku awarii, lub przynajmniej utwórz lokalną kopię dziennika `. xt` do dalszej analizy. Pamiętaj, że komenda `restartu` zawsze zrestartuje ASF niezależnie od tego, jak ta właściwość jest ustawiona, ponieważ ta właściwość definiuje domyślne zachowanie, podczas gdy polecenie `uruchom ponownie` zawsze restartuje proces. Jeśli nie masz powodu do wyłączenia tej funkcji, powinieneś ją utrzymać.

---

### `Blacklist`

`ImmutableHashSet<uint>` typ z domyślną wartością bycia pustym. Jak sugeruje nazwa, ta globalna właściwość konfiguracyjna definiuje identyfikatory aplikacji (gry), które będą całkowicie ignorowane przez automatyczny proces rolniczy ASF. Niestety Steam uwielbia oznaczać letnie i zimowe odznaki sprzedaży jako „dostępne do upuszczenia kart”, co myli proces ASF poprzez przekonanie, że jest to ważna gra, która powinna być wyhodowana. Gdyby nie istniała jakakolwiek czarna lista, ASF w końcu "zawiesił" w rolnictwie, która w rzeczywistości nie jest grą, i poczekaj nieskończenie na upuszczenie karty, co się nie wydarzy. Czarna lista ASF służy do oznaczenia tych odznak jako niedostępnych dla rolnictwa, więc możemy je milcząco ignorować przy podejmowaniu decyzji, co należy uprawiać i nie wpadać w pułapkę.

ASF zawiera domyślnie dwie czarne listy - `SalesBlacklist`, który jest sprzężony z kodem ASF i nie jest możliwy do edycji, oraz normalna czarna lista ``, która jest tutaj zdefiniowana. `SalesBlacklist` jest aktualizowany wraz z ASF wersją i zazwyczaj zawiera wszystkie "złe" identyfikatory aplikacji w momencie wydania, więc jeśli używasz aktualnego ASF, nie musisz utrzymywać swojej własnej czarnej listy `` zdefiniowanej tutaj. Głównym celem tej właściwości jest umożliwienie czarnej listy nowych, nieznanych w momencie tworzenia ASF aplikacji ID, które nie powinny być uprawiane. Utwardzony `SalesBlacklist` jest aktualizowany tak szybko, jak to możliwe, dlatego nie musisz aktualizować swojej własnej czarnej listy `` jeśli używasz najnowszej wersji ASF, ale bez `Czarnej Listy` zostaniesz zmuszony do aktualizacji ASF w celu "utrzymania działania", gdy Głowica wyda nową odznakę sprzedaży - nie chcę zmusić Cię do użycia najnowszego kodu ASF, dlatego ta właściwość jest tutaj, aby umożliwić Ci "naprawę" ASF, jeśli z jakiegoś powodu nie chcesz lub nie możesz, aktualizacja do nowej, hartowanej listy `SalesBlacklist` w nowej wersji ASF, a mimo to chcesz utrzymać starą wersję ASF uruchomioną. Jeśli nie masz silnego **** powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

Jeśli szukasz czarnej listy bota, spójrz na `fb`, `fźd` i `fbrm` **[polecenia](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `CommandPrefix`

`string` typ z domyślną wartością `!`. Ta właściwość określa prefiks **uwzględniający wielkość liter** używany dla poleceń ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Innymi słowy, to właśnie musisz wcześniej dodać do każdej komendy ASF, aby ASF słuchała. Możliwe jest ustawienie tej wartości na `null` lub puste, aby ASF nie używał prefiksu poleceń, w którym to przypadku wprowadzasz polecenia z ich zwykłymi identyfikatorami. Jednakże wykonanie tego spowoduje potencjalne zmniejszenie wydajności ASF, ponieważ ASF jest zoptymalizowane, aby nie analizować wiadomości dalej, jeśli nie zaczyna się od `CommandPrefix` - jeśli umyślnie zdecydujesz się jej nie używać, ASF będzie zmuszony odczytywać wszystkie wiadomości i odpowiadać na nie, nawet jeśli nie są one poleceniami ASF. Dlatego też zaleca się używanie niektórych poleceń `CommandPrefix`, np. `/` jeśli nie lubisz wartości domyślnej `!`. Dla spójności, `CommandPrefix` wpływa na cały proces ASF. Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `ConfirmationsLimiterDelay`

`byte` type with default value of `10`. ASF zapewni, że będzie co najmniej `ConfirmationsLimiterDelay` sekund pomiędzy dwoma kolejnymi potwierdzeniami 2FA pobierającymi żądania, aby uniknąć wyzwalania limitu szybkości - są one używane przez **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** podczas e. . `polecenie 2faok` , jak również na zasadach zgodnych z potrzebami podczas wykonywania różnych operacji związanych z handlem. Domyślna wartość została ustawiona na podstawie naszych testów i nie powinna być obniżana, jeśli nie chcesz wpadać w problemy. Jeśli nie masz silnego **** powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `ConnectionTimeout`

`byte` type with default value of `90`. Ta właściwość definiuje czasy dla różnych akcji sieciowych wykonywanych przez ASF w sekundach. W szczególności, `ConnectionTimeout` definiuje limit czasu w sekundach dla żądań HTTP i IPC, `Limit czasu połączenia/10` definiuje maksymalną liczbę nieudanych akcji serca, while `Timeout / 30` definiuje liczbę minut, na którą zezwalamy na początkowe żądanie połączenia Steam. Domyślna wartość `90` powinna być dobra dla większości ludzi, jednak jeśli masz dość wolne połączenie sieciowe lub PC możesz zwiększyć tę liczbę do czegoś wyższego (jak `120`). Pamiętaj, że większe wartości nie naprawią magicznie powolnych lub nawet niedostępnych serwerów Steam, więc nie powinniśmy czekać na coś, co się nie wydarzy, i po prostu spróbować ponownie później. Ustanowienie zbyt wysokiej wartości spowoduje nadmierne opóźnienie w połowach problemów z siecią, jak również zmniejszenie ogólnej wydajności. Ustawienie tej wartości za niska zmniejszy ogólną stabilność i wydajność, ponieważ ASF przerwie ważne żądanie nadal przetwarzane. W związku z tym ustalenie tej wartości niższej od wartości domyślnej nie ma żadnej przewagi w ogóle, ponieważ serwery Steam są zazwyczaj bardzo wolne od czasu do czasu i mogą potrzebować więcej czasu na analizowanie żądań ASF. Wartość domyślna to równowaga między przekonaniem, że nasze połączenie sieciowe jest stabilne a wątpliwościami w sieci Steam, aby obsłużyć nasze żądanie w określonym czasie. Jeśli chcesz wcześniej wykryć problemy i przyspieszyć ponowne połączenie/reagowanie ASF, wartość domyślna powinna zrobić (lub bardzo lekko poniżej, jak `60`, co sprawia, że ASF mniej pacjenta). Jeśli zamiast tego zauważysz, że ASF działa na problemy z siecią, takie jak nieudane żądania, utracone bicie serca lub przerwane połączenie ze Steam, zwiększenie tej wartości prawdopodobnie ma sens, jeśli jesteś pewien, że jest **nie** spowodowane przez Twoją sieć. ale przez samą Steam, ponieważ wydłużenie czasu sprawia, że ASF jest bardziej „pacjent” i nie podejmuje decyzji o ponownym połączeniu.

Przykładowa sytuacja, która może wymagać zwiększenia tej nieruchomości, pozwala ASF na zajmowanie się bardzo wielkimi ofertami handlowymi, które mogą zająć ponad 2 minuty, aby mogły być w pełni zaakceptowane i obsługiwane przez Steam. Przez zwiększenie domyślnego limitu czasu, ASF będzie bardziej cierpliwy i poczekać dłużej, zanim zdecyduje, że transakcja nie zostanie zrealizowana i porzuci pierwotnych żądań.

Inna sytuacja może być spowodowana bardzo powolnym połączeniem maszynowym lub internetowym, które wymaga więcej czasu na przetwarzanie przesyłanych danych. Jest to dość rzadki stan, ponieważ pasmo CPU/sieć prawie nigdy nie jest wąskim gardłem, ale warto wspomnieć o takiej możliwości.

Krótko mówiąc, wartość domyślna powinna być przyzwoita w większości przypadków, ale w razie potrzeby może być ona zwiększona. Wciąż jednak daleko powyżej wartości domyślnej również nie ma sensu, ponieważ większe limity czasu nie naprawią magicznie niedostępnych serwerów Steam. Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `CurrentCulture`

`string` typ z domyślną wartością `null`. Domyślnie ASF próbuje używać języka systemu operacyjnego i wolą używać przetłumaczonych ciągów w tym języku, jeśli jest on dostępny. Jest to możliwe dzięki naszej społeczności, która próbuje **[zlokalizować](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** ASF we wszystkich popularnych językach. Jeśli z jakiegoś powodu nie chcesz używać swojego języka ojczystego systemu operacyjnego, możesz użyć tej właściwości konfiguracyjnej do wybrania dowolnego poprawnego języka, którego chcesz użyć. For a list of all available cultures, please visit **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** and look for `Language tag`. Miło jest zauważyć, że ASF akceptuje obie specyficzne kultury, takie jak `"en-GB"`, ale także neutralne, takie jak `"en"`. Określanie obecnej kultury będzie miało również wpływ na inne zachowania charakterystyczne dla kultury, takie jak format waluty i daty. Pamiętaj, że być może potrzebujesz dodatkowych paczek czcionek/języków do poprawnego wyświetlania znaków specyficznych dla języka, jeśli wybrałeś nierodzimą kulturę, która z nich korzysta. Zazwyczaj chcesz użyć tej właściwości konfiguracyjnej, jeśli wolisz ASF w języku angielskim zamiast swojego języka ojczystego.

---

### `Debug`

`bool` typ z domyślną wartością `false`. Ta właściwość definiuje czy proces powinien być uruchomiony w trybie debugowania. Gdy w trybie debugowania, ASF tworzy specjalny katalog `debugowania` obok konfiguracji ``, która śledzi całą komunikację między serwerami ASF i Steam. Informacje debugowania mogą pomóc w wykrywaniu nietypowych problemów związanych z tworzeniem sieci i ogólnym przepływem pracy ASF. Ponadto niektóre procedury programu będą znacznie bardziej szczegółowe, Na przykład `WebBrowser` podając dokładny powód, dla którego niektóre zapytania są nieskuteczne - te wpisy są zapisywane w normalnym dzienniku ASF. **Nie powinieneś uruchamiać ASF w trybie debugowania, chyba że zapytał o to deweloper**. Uruchamianie ASF w trybie debugowania **zmniejsza wydajność**, **ma negatywny wpływ na stabilność** i jest **znacznie bardziej precyzyjny w różnych miejscach**, więc powinien być używany tylko **** celowo, w krótkim czasie, do debugowania konkretnego problemu, odtwarzanie problemu lub otrzymywanie więcej informacji o błędnym żądaniu, ale **nie** dla normalnego wykonania programu. You will see **a lot** of new errors, issues, and exceptions - make sure that you have a decent knowledge about ASF, Steam and its quirks if you decide to analyze all of that yourself, as not everything is relevant.

**OSTRZEŻENIE:** włączenie tego trybu obejmuje rejestrowanie informacji **potencjalnie wrażliwych** takich jak logowania i hasła, których używasz do logowania do Steam (ze względu na logowanie w sieci). Te dane są zapisywane do katalogu `debugowania` oraz standardowego logu `. xt` (teraz jest to celowo dużo bardziej dokładne, aby zalogować te informacje). Nie powinieneś publikować zawartości debugowania generowanej przez ASF w żadnym miejscu publicznym, Deweloper ASF powinien zawsze przypominać Ci o wysłaniu go na swój adres e-mail lub inne bezpieczne miejsce. Nie przechowujemy ani nie korzystamy z tych wrażliwych szczegółów, są napisane w ramach procedur debugowania, ponieważ ich obecność może być istotna dla problemu, który cię dotyka. Wolałbyśmy, gdybyś w żaden sposób nie zmienił logowania ASF, ale jeśli jesteś zaniepokojony, możesz odpowiednio naprawić te wrażliwe szczegóły.

> Redakcja polega na zastąpieniu szczególnie chronionych szczegółów, na przykład gwiazdkami. Powinien pan powstrzymać się od całkowicie usuwania wrażliwych linii, ponieważ ich czyste istnienie może być istotne i powinno być zachowane.

---

### `Domyślny Bot`

`string` typ z domyślną wartością `null`. W niektórych scenariuszach ASF działa z koncepcją domyślnego bota odpowiedzialnego za obsługę czegoś - na przykład komendy IPC lub interaktywna konsola, gdy nie określisz docelowego bota. Ta właściwość pozwala wybrać domyślnego bota odpowiedzialnego za obsługę takich scenariuszy, umieszczając `BotName` tutaj. Jeśli dany bot nie istnieje, lub użyjesz domyślnej wartości `null`, ASF wybierze pierwszy zarejestrowany bot posortowany alfabetycznie. Zazwyczaj chcesz użyć tej właściwości konfiguracyjnej, jeśli chcesz pominąć argument `[Bots]` w IPC i interaktywnych poleceń konsoli, i zawsze wybierz ten sam bot co domyślny dla takich połączeń.

---

### `FarmingDelay`

`byte` type with default value of `15`. Aby ASF działał, będzie sprawdzać aktualnie utrzymywane gry co `Opóźnienie FarmingDelay` czy może zrzuci już wszystkie karty. Ustawienie tej właściwości zbyt niska może spowodować wysłanie nadmiernej ilości żądań pary, podczas ustawienia, zbyt wysokie może spowodować, że ASF nadal "farming" nadał tytuł do `FarmingDelay` minut po jego pełnej farmie. Domyślna wartość powinna być doskonała dla większości użytkowników, ale jeśli masz wiele uruchomionych botów, możesz rozważyć zwiększenie go do czegoś takiego jak `30` minut, aby ograniczyć wysyłanie żądań parowych. Miło jest zauważyć, że ASF używa mechanizmu zdarzeń i sprawdza odznakę gry na każdej zrzuconej pozycji Steam, więc ogólnie **nie musimy nawet sprawdzać go w stałych odstępach czasu**, ale ponieważ nie ufamy w pełni sieci Steam - sprawdzamy i tak stronę odznaki gry, gdybyśmy nie sprawdziliśmy, czy karta została usunięta w ostatnim wydarzeniu `FarmingDelay` minut (w przypadku, gdy sieć Steam nie poinformowała nas o porzuconych przedmiotach lub o podobnych rzeczach). Zakładając, że sieć Steam działa poprawnie, zmniejszenie tej wartości **w żaden sposób nie poprawi wydajności gospodarki rolnej**, podczas gdy **znacznie zwiększa sieć** - zalecane jest tylko zwiększenie jej (w razie potrzeby) z domyślnej wartości `15` minut. Jeśli nie masz silnego **** powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `Filtruj boty`

`bool` typ z domyślną wartością `true`. Ta właściwość określa, czy ASF automatycznie odrzuci oferty handlowe, które są otrzymywane od znanych i oznaczonych złych aktorów. W tym celu ASF będzie komunikować się z naszym serwerem zgodnie z potrzebami w celu pobrania listy identyfikatorów Steam umieszczonych na czarnej liście. Wymienione boty są przez nas obsługiwane przez osoby, które są przez nas sklasyfikowane jako szkodliwe dla inicjatywy ASF, takie jak te, które naruszają nasz kodeks postępowania **[](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, korzystanie z zapewnionej funkcjonalności i zasobów przez nas, takich jak **[`PublicListing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** w celu wykorzystywania i wykorzystywania innych ludzi, lub wykonują bezwzględną aktywność przestępczą, taką jak uruchamianie ataków DDoS na serwerze. Ponieważ ASF ma zdecydowane stanowisko w sprawie ogólnej sprawiedliwości, uczciwości i współpracy między swoimi użytkownikami, tak aby całe społeczeństwo mogło prosperować, ta właściwość jest domyślnie włączona i dlatego ASF filtruje boty, które zaklasyfikowaliśmy jako szkodliwe z oferowanych usług. Jeśli nie masz silnego **** powodu do edycji tej właściwości, Na przykład nie zgadzamy się z naszym oświadczeniem i umyślnie pozwalając tym botom na działanie (w tym na eksploatację Twoich konta), powinieneś go utrzymywać domyślnie.

---

### `GiftsLimiterDelay`

`byte` type with default value of `1`. ASF zapewni, że będzie co najmniej `GiftsLimiterDelay` sekund pomiędzy dwoma kolejnymi żądaniami obsługi prezentów/klucz/licencji, aby uniknąć wyzwalania limitu szybkości. In addition to that it'll also be used as global limiter for game list requests, such as the one issued by `owns` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Jeśli nie masz silnego **** powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `Headless`

`bool` typ z domyślną wartością `false`. Ta właściwość definiuje czy proces powinien działać w trybie bezgłownym. W trybie bezgłowy ASF zakłada, że działa na serwerze lub w innym nieinteraktywnym środowisku, w związku z tym nie będzie próbowała czytać żadnych informacji za pomocą danych wejściowych konsoli. Obejmuje to szczegóły na żądanie (dane uwierzytelniające, takie jak kod 2FA, kod SteamGuard, hasło lub jakakolwiek inna zmienna wymagana do działania ASF), jak również wszystkie inne wejścia konsoli (takie jak interaktywna konsola poleceń). Innymi słowy, tryb `Headless` jest równy temu, aby konsola ASF była tylko do odczytu. To ustawienie jest przydatne głównie dla użytkowników obsługujących ASF na ich serwerach, zamiast pytania. . dla kodu 2FA, ASF bez wyjątku przerwie operację, zatrzymując konto. Jeśli nie używasz ASF na serwerze i wcześniej potwierdziłeś, że ASF jest w stanie działać w trybie innym niż bezgłowny, powinieneś zachować tę właściwość wyłączoną. Każda interakcja użytkownika zostanie odrzucona w trybie bezgłownym, i twoje konta nie będą działać, jeśli będą wymagały wejścia **lub** konsoli podczas uruchamiania. Jest to przydatne dla serwerów, ponieważ ASF może przerwać próby zalogowania się na konto gdy zostanie poproszony o poświadczenia, zamiast czekać (nieskończono) na dostarczenie ich przez użytkownika.

Włączenie tego trybu pozwoli na dostarczenie wymaganych danych wejściowych konsoli za pomocą innych środków, np. ASF-ui (ASF API) lub przez **[`input`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#input-command)**. Jeśli nie jesteś pewien, jak ustawić tę właściwość, pozostaw ją z domyślną wartością `false`.

---

### `IdleFarmingPeriod`

`byte` type with default value of `8`. Gdy ASF nie ma nic do hodowli, będzie okresowo sprawdzać co `IdleFarmingPeriod` godzin, jeśli na koncie znajdzie się kilka nowych gier do hodowli. Ta funkcja nie jest potrzebna, gdy mówimy o nowych grach, które otrzymujemy, ponieważ ASF jest na tyle inteligentny, aby automatycznie sprawdzać strony odznak w tym przypadku. `IdleFarmingPeriod` jest głównie w takich sytuacjach, jak stare gry, które już dodaliśmy karty handlowe. W tym przypadku nie ma zdarzenia, więc ASF musi okresowo sprawdzać strony odznak, jeśli chcemy to uwzględnić. Wartość `0` wyłącza tę funkcję. Sprawdź również: `ShutdownOnFarmingFfinished` preferencje w `FarmingPreferences`.

---

### `InventoryLimiterDelay`

`byte` type with default value of `4`. ASF zapewni, że będzie co najmniej `InventoryLimiterDelay` sekund pomiędzy dwoma kolejnymi żądaniami w ekwipunku sieci, aby uniknąć wyzwalania limitu szybkości - są one używane na przykład podczas znakowania powiadomień inwentarza jako przeczytane, może być również używany przez wtyczki firm trzecich pobierające inwentaryzację innych użytkowników. Ta własność nie jest wykorzystywana do pobierania naszego własnego ekwipunku, ponieważ ASF wykorzystuje o wiele bardziej efektywną sieć wewnętrzną do tego celu, więc nie wpłynie to w żaden sposób na polecenia takie jak `loot` lub `transfer`. Domyślna wartość `4` została ustawiona na podstawie oznaczania zapasów ponad 100 kolejnych instancji botów, i powinny spełniać większość (jeśli nie wszystkie) użytkowników. Możesz jednak je zmniejszyć, a nawet zmienić na `0` , jeśli masz bardzo małą liczbę botów, tak więc ASF zignoruje opóźnienie i znaczy zapasy Steam znacznie szybciej. Be warned though, as setting it too low **will** result in Steam temporarily banning your IP, and that will prevent you from making any calls at all. Może być również konieczne zwiększenie tej wartości, jeśli używasz wielu botów z wieloma żądaniami w ekwipunku, chociaż w tym przypadku prawdopodobnie powinieneś spróbować ograniczyć liczbę tych żądań. Jeśli nie masz silnego **** powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `IPC`

`bool` typ z domyślną wartością `true`. Ta właściwość określa, czy serwer ASF **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** powinien zaczynać się razem z procesem. IPC umożliwia komunikację międzyprocesową, w tym korzystanie z **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**przez uruchomienie lokalnego serwera HTTP. Jeśli nie zamierzasz korzystać z integracji IPC z ASF, w tym z ASF, możesz bezpiecznie wyłączyć tę opcję. W przeciwnym razie dobrym pomysłem jest utrzymanie włączenia (opcja domyślna).

---

### `IPCPassword`

`string` typ z domyślną wartością `null`. Ta właściwość definiuje obowiązkowe hasło dla każdego połączenia API wykonanego przez IPC i służy jako dodatkowy środek bezpieczeństwa. Gdy ustawiono wartość niepustą, wszystkie żądania IPC będą wymagały dodatkowej własności `hasło` ustawionej na hasło podane tutaj. Domyślna wartość `null` pominie potrzebę hasła, przy czym ASF respektuje wszystkie zapytania. Dodatkowo, włączenie tej opcji umożliwia również wbudowany mechanizm antybruteforce IPC, który tymczasowo zbanuje podany `IPAddress` po wysłaniu zbyt wielu nieautoryzowanych żądań w bardzo krótkim czasie. Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `Format IPCPasswordFormat`

`byte` type with default value of `0`. Ta właściwość definiuje format własności `IPCPassword` i używa `EHashingMethod` jako typu bazowego. Proszę zapoznać się z sekcją **[Security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** jeśli chcesz dowiedzieć się więcej, ponieważ musisz upewnić się, że właściwość `IPCPassword` rzeczywiście zawiera hasło w pasującym `IPCPasswordFormat`. Innymi słowy, gdy zmienisz `IPCPasswordFormat` to twój `IPCPassword` powinien być **już** w tym formacie, nie tylko dążyć. Dopóki nie wiesz, co robisz, powinieneś zachować domyślną wartość `0`.

---

### `LicenseID`

`Guid?` wpisz domyślną wartość `null`. Ta właściwość pozwala naszym **[sponsorom](https://github.com/sponsors/JustArchi)** ulepszyć ASF za pomocą opcjonalnych funkcji, które wymagają opłaconych zasobów do pracy. For now, this allows you to make use of **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** feature in `ItemsMatcher` plugin.

While we recommend you to utilize GitHub since it offers monthly and one-time tiers, as well as allows full automation and gives you immediate access, we **also** support all other currently-available **[donation options](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. See **[this post](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** for instructions on how to donate using other methods in order to get a manual license valid for given period.

Niezależnie od zastosowanej metody, jeśli jesteś ASF sponsorem, możesz uzyskać licencję **[tutaj](https://asf.justarchi.net/User/Status)**. Będziesz musiał zalogować się za pomocą GitHub w celu potwierdzenia swojej tożsamości, prosimy tylko o publiczne informacje tylko do odczytu, które są Twoją nazwą użytkownika. `LicenseID` składa się z 32 znaków szesnastkowych, takich jak `f6a0529813f74d119982eb4fe43a9a24`.

**Upewnij się, że nie udostępniasz swojego `LicenseID` innym osobom**. Ponieważ jest wydawany na zasadach osobistych, może zostać odwołany w razie jego wycieku. Jeśli z jakiegoś powodu zdarzy się to przypadkowo, możesz wygenerować nowy z tego samego miejsca.

Jeśli nie chcesz włączyć dodatkowych funkcji ASF, nie ma potrzeby uzyskania/dostarczania licencji.

---

### `LoginLimiterDelay`

`byte` type with default value of `10`. ASF zapewni, że będzie co najmniej `LoginLimiterDelay` sekund pomiędzy dwoma kolejnymi próbami połączenia w celu uniknięcia wyzwalania limitu szybkości. Domyślna wartość `10` została ustawiona na podstawie połączenia ponad 100 instancji botów i powinna spełniać większość (jeśli nie wszystkie) użytkowników. Możesz jednak go zwiększyć/zmniejszyć lub nawet zmienić na `0` , jeśli masz bardzo małą liczbę botów, aby ASF zignorował opóźnienie i połączył się ze Steam znacznie szybciej. Be warned though, as setting it too low while having too many bots **will** result in Steam temporarily banning your IP, and that will prevent you from logging in **at all**, with `InvalidPassword/RateLimitExceeded` error - and that also includes your normal Steam client, not only ASF. Podobnie, jeśli używasz zbyt dużej liczby botów, zwłaszcza razem z innymi klientami/narzędziami Steam używającymi tego samego adresu IP, najprawdopodobniej będziesz musiał zwiększyć tę wartość, aby rozprzestrzeniać loginy przez dłuższy czas.

W notatce bocznej ta wartość jest również używana jako bufor równoważący obciążenie we wszystkich akcjach zaplanowanych przez ASF, takich jak transakcje w `SendTradePeriod`. Jeśli nie masz silnego **** powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `MaxFarmingTime`

`byte` type with default value of `10`. Jak powinieneś wiedzieć, Steam nie zawsze działa prawidłowo, czasami dziwne sytuacje mogą się zdarzyć, że nasz czas gry nie jest zapisywany, mimo że w rzeczywistości gra w grę. ASF umożliwi rolnikowi pojedynczą grę w trybie solo maksymalnie przez `MaxFarmingTime` godziny i rozważy ją w pełni wyprodukowaną po tym okresie. Jest to konieczne, aby nie zamrozić procesu produkcji rolnej w przypadku dziwnych sytuacji, ale również jeśli z jakiegoś powodu Steam wydał nową odznakę, która powstrzyma ASF od dalszych postępów (patrz `Czarna lista`). Domyślna wartość `10` godzin powinna być wystarczająca do upuszczenia wszystkich kart parowych z jednej gry. Ustawienie tej właściwości może spowodować pominięcie ważnych gier (i tak, istnieją ważne gry zajęte nawet do 9 godzin w gospodarstwie), podczas gdy zbyt wysokie stawki mogą skutkować zamrożeniem procesu produkcji rolnej. Należy pamiętać, że ta właściwość dotyczy tylko jednej gry w jednej sesji rolniczej (więc po przechodzeniu przez całą kolejkę ASF powróci do tego tytułu), nie opiera się również na całkowitym czasie zabawy, ale na wewnętrznym czasie wegetacji ASF, więc ASF również wróci do tego tytułu po ponownym uruchomieniu. Jeśli nie masz silnego **** powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `MaxTradeHoldDuration`

`byte` type with default value of `15`. Ta właściwość określa maksymalny czas trwania transakcji w dniach, które jesteśmy gotowi zaakceptować - ASF odrzuci transakcje, które są przechowywane przez więcej niż `MaxTradeHoldDuration` dni, zgodnie z definicją w sekcji **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**. Ta opcja ma sens tylko dla botów z `TradingPreferences` of `SteamTradeMatcher`, ponieważ nie ma wpływu na transakcje `Mistrz`/`SteamOwnerID` , ani na darowizny. Gospodarki są irytujące dla wszystkich i nikt naprawdę nie chce sobie z nimi poradzić. ASF ma pracować nad liberalnymi przepisami i pomagać wszystkim, niezależnie od tego, czy w transakcjach utrzymuje lub nie - dlatego ta opcja jest domyślnie ustawiona na `15`. Jednakże, jeśli zamiast tego wolisz odrzucić wszystkie transakcje, na które mają wpływ handlowcy, możesz podać `0` tutaj. Proszę wziąć pod uwagę, że ta opcja nie ma wpływu na karty o krótkiej żywotności, i automatycznie odrzucić je dla osób posiadających karty handlowe, zgodnie z opisem w sekcji **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** więc nie ma potrzeby globalnego odrzucania wszystkich tylko z tego powodu. Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.


---

### `MinFarmingDelayAfterBlock`

`byte` type with default value of `60`. Ta właściwość definiuje minimalny czas, w sekundach, który ASF będzie czekał przed wznowieniem hodowli kart, jeśli wcześniej został odłączony od `LoggedInElsewhere`, co dzieje się w momencie, gdy zdecydujesz się na zdecydowane odłączenie ASF od obecnego rolnictwa, uruchamiając grę. Opóźnienie to występuje głównie z przyczyn wygodnych i ogólnych, na przykład pozwala na ponowne uruchomienie gry bez konieczności walki z ASF zajmującym Twoje konto tylko dlatego, że blokada gry była dostępna przez sekundę rozdania. Ze względu na fakt, że rekultywacja sesji powoduje rozłączenie `LoggedInElsewhere` ASF musi przejść przez całą procedurę ponownego połączenia, który powoduje dodatkowe ciśnienie na maszynę i sieć parową, a tym samym w miarę możliwości zaleca się unikanie dodatkowych odłączeń. Domyślnie jest to skonfigurowane w `60` sekund, co powinno być wystarczające, aby umożliwić ponowne uruchomienie gry bez większych problemów. Istnieją jednak scenariusze, w których można się zainteresować ich zwiększeniem, na przykład jeśli Twoja sieć często się rozłącza, a ASF przejmuje zbyt wcześnie, co powoduje konieczność samodzielnego połączenia się. Dopuszczamy maksymalną wartość `255` dla tej właściwości, która powinna wystarczyć dla wszystkich typowych scenariuszy. Oprócz powyższego możliwe jest również zmniejszenie opóźnienia, lub nawet usuń go całkowicie z wartością `0`, chociaż zazwyczaj nie jest to zalecane z powodów podanych powyżej. Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `OptimizationMode`

`byte` type with default value of `0`. Ta właściwość definiuje tryb optymalizacji, który ASF będzie preferował podczas pracy. Obecnie ASF obsługuje dwa tryby - `0` o nazwie `MaxPerformance`, i `1` o nazwie `MinMemoryUsage`. Domyślnie ASF woli uruchamiać jak najwięcej rzeczy równolegle (równocześnie) jak to możliwe, która zwiększa wydajność poprzez równoważenie obciążenia we wszystkich rdzeni procesora, wielu wątkach procesora, wielu gniazd i wielu zadaniach nici. Na przykład ASF poprosi o pierwszą stronę odznaki podczas sprawdzania gier do hodowli, a następnie po otrzymaniu żądania, ASF przeczyta z niej ile stron odznaki posiadasz, a następnie zażądaj nawzajem jednocześnie. To właśnie powinieneś chcieć **prawie zawsze**, ponieważ w większości przypadków koszt ogólny jest minimalny, a korzyści z asynchronicznego kodu ASF mogą być widoczne nawet na najstarszym sprzęcie z pojedynczym rdzeniem CPU i bardzo ograniczoną mocą. Jednak przy wielu zadaniach przetwarzanych równolegle, czas pracy ASF jest odpowiedzialny za ich utrzymanie, np. przechowywanie gniazd otwartych, żywych wątków i przetwarzanych zadań, co może skutkować zwiększeniem zużycia pamięci od czasu do czasu i jeśli jesteś bardzo ograniczony dostępną pamięcią, możesz zmienić tę właściwość na `1` (`MinMemoryUsage`) aby zmusić ASF do korzystania z jak najmniejszych zadań, i zazwyczaj działa możliwy do równoległego asynchroniczny kod w sposób synchroniczny. Powinieneś rozważyć zmianę tej właściwości tylko wtedy, gdy przeczytałeś wcześniej **[konfigurację pamięci](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** i celowo chcesz poświęcić gigantyczne zwiększenie wydajności, za bardzo małą pamięć zmniejsza się. Usually this option is **much worse** than what you can achieve with other possible ways, such as by limiting your ASF usage or tuning runtime's garbage collector, as explained in **[low-memory setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. W związku z tym powinieneś użyć `MinMemoryUsage` jako **ostatniej instancji**, bezpośrednio przed ponownym kompilacją, jeśli nie mogłeś osiągnąć zadowalających wyników z innymi (dużo lepszymi) opcjami. Jeśli nie masz silnego **** powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `PluginsUpdateList`

`ImmutableHashSet<string>` typ z domyślną wartością bycia pustym. Ta właściwość definiuje listę nazw zespołów pluginów, które są czarnej lub białej listy do rozważania automatycznych aktualizacji, jak na `PluginsUpdateMode` zdefiniowano poniżej.

Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `PluginsUpdateMode`

`byte` type with default value of `0`. Ta właściwość definiuje tryb aktualizacji wtyczek, który nadaje znaczenie `PluginsUpdateList` zdefiniowany powyżej. Określając tę właściwość możesz z łatwością włączyć/wyłączyć automatyczne aktualizacje dla wszystkich wtyczek poza tymi zadeklarowanymi.

- Wartość `0`, o nazwie `Biała lista`, **wyłącza** automatyczną aktualizację wszystkich wtyczek, z wyjątkiem tych zdefiniowanych w `PluginsUpdateList`.
- Wartość `1`, o nazwie `Czarna lista`, **włącza** automatyczną aktualizację wszystkich wtyczek, z wyjątkiem tych zdefiniowanych w `PluginsUpdateList`.

**ASF team would like to remind you that, for your own safety, you should enable automatic updates only from trusted parties**. Pamiętaj, że złośliwe wtyczki mogą samodzielnie zaktualizować się lub wykonać zdalne polecenia **niezależnie od** tego ustawienia, dlatego to ustawienie stosuje się wyłącznie do aktualizacji wtyczek dostarczanych przez ASF, i nadal powinieneś upewnić się, że poprawnie zweryfikowałeś każdą wtyczkę, którą zdecydowałeś się użyć.

Aktualizacje wtyczek są wykonywane domyślnie wraz z rutyną aktualizacji ASF - **[`Aktualizacja Kanału`](#updatechannel)** i **[`Aktualizacja`](#updateperiod)** Standardowe mechanizmy aktualizacji ASF, takie jak `update` , również wyzwalają opcjonalne aktualizacje wtyczek. Jeśli zamiast tego chcesz aktualizować wtyczki ręcznie bez jednoczesnej aktualizacji wersji ASF, polecenie `updateplugins` oferuje taką możliwość.

Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `Wyłączono Ifpossible`

`bool` typ z domyślną wartością `false`. Po włączeniu ASF spróbuje zamknąć proces, jeśli to możliwe, to znaczy, gdy wszystkie zarejestrowane boty zostaną zatrzymane. Może to być szczególnie przydatne w połączeniu z `ShutdownOnFarmingFfinished` we wszystkich instancjach bota, ponieważ w ten sposób ASF będzie mógł automatycznie zamknąć, gdy ostatni z Twoich botów zakończy produkcję.

Ponieważ oczekuje się, że większość użytkowników będzie działała przez cały czas. . dla `IPC` ta opcja jest domyślnie wyłączona.

---

### `SteamMessagePrefix`

`string` typ z domyślną wartością `"/me "`. Ta właściwość definiuje prefiks, który będzie poprzedzony wszystkimi wiadomościami Steam wysyłanymi przez ASF. Domyślnie ASF używa prefiksu `"/me "` w celu łatwiejszego odróżnienia wiadomości bota, pokazując je w innym kolorze na czacie Steam. Inną wartą wzmianką jest prefiks `"/pre "` , który osiąga podobny wynik, ale używa innego formatowania. Możesz również ustawić tę właściwość na pusty ciąg znaków lub `null` , aby wyłączyć używanie całości przedrostka i wysyłanie wszystkich wiadomości ASF w tradycyjny sposób. Miło jest zauważyć, że ta właściwość wpływa tylko na wiadomości Steam - odpowiedzi zwracane przez inne kanały (takie jak IPC) nie są naruszone. Jeśli nie chcesz dostosować standardowego zachowania ASF, to dobrym pomysłem jest pozostawienie go domyślnie.

---

### `SteamOwnerID`

`ulong` typ z domyślną wartością `0`. Ta właściwość definiuje Steam ID w 64-bitowej formie właściciela procesu ASF, i jest bardzo podobny do uprawnienia `Mistrz` dla danej instancji bota (ale zamiast tego globalnego). Prawie zawsze chcesz ustawić tę właściwość na ID swojego głównego konta Steam. Pozwolenie `Mistrz` zawiera pełną kontrolę nad jego instancją bota, ale globalne komendy takie jak `Wyjdź`, `restart` lub `aktualizacja` są zarezerwowane tylko dla `SteamOwnerID`. Jest to wygodne, ponieważ możesz uruchomić boty dla znajomych, nie pozwalając im na kontrolowanie procesu ASF, np. zamykanie go przez polecenie `Wyjdź`. Domyślna wartość `0` określa, że nie ma właściciela procesu ASF, co oznacza, że nikt nie będzie w stanie wydawać globalnych poleceń ASF. Pamiętaj, że ta właściwość dotyczy wyłącznie czatu Steam. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, jak również interaktywna konsola, nadal pozwoli Ci wykonać polecenia `Właściciel` nawet jeśli ta właściwość nie jest ustawiona.

---

### `SteamProtocols`

`byte flags` type with default value of `7`. Ta właściwość definiuje protokoły Steam, które ASF będzie używał podczas łączenia z serwerami Steam, które są zdefiniowane poniżej.

| Wartość | Nazwa     | Opis                                                                                          |
| ------- | --------- | --------------------------------------------------------------------------------------------- |
| 0       | None      | No protocol                                                                                   |
| 1       | TCP       | **[Protokół kontroli przesyłu](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2       | UDP       | **[Protokół Datagram użytkownika](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**     |
| 4       | WebSocket | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                                      |

Zauważ, że ta właściwość jest polem `flagi` , dlatego możliwe jest wybranie dowolnej kombinacji dostępnych wartości. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Nie włączanie żadnej flagi skutkuje opcją `None` i ta opcja jest niepoprawna dla siebie.

Domyślnie ASF użyje wszystkich dostępnych protokołów Steam jako środka walki z przestojami i innymi podobnymi problemami Steam. Zazwyczaj chcesz zmienić tę właściwość, jeśli chcesz ograniczyć ASF do użycia tylko jednego lub dwóch określonych protokołów. Takie środki mogą być potrzebne w różnych sytuacjach, na przykład jeśli zablokowałeś ruch UDP na swojej zaporze i chcesz upewnić się, że tylko ruch TCP przechodzi lub jeśli używasz `WebProxy` i chcesz użyć go również do połączenia Steam, tylko protokół `WebSocket` obsługuje to.

Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `UpdateChannel`

`byte` type with default value of `1`. Ta właściwość definiuje kanał aktualizacji, który jest używany, albo dla automatycznych aktualizacji (jeśli `Aktualizacja Okresu` jest większa niż `0`) lub aktualizacja powiadomień (w przeciwnym razie). Obecnie ASF obsługuje trzy kanały aktualizacji - `0` o nazwie `None`, `1`, który nazywa się `Stabilnym`i `2`, nazywanym `PreRelease`. Kanał `Stabilny` jest domyślnym kanałem wydania, który powinien być używany przez większość użytkowników. Kanał `PreRelease` oprócz wydania `Stabilne` , zawiera również **wstępne wydania** przeznaczone dla zaawansowanych użytkowników i innych programistów w celu przetestowania nowych funkcji, potwierdź poprawki błędów lub udziel informacji zwrotnej o planowanych ulepszeniach. **Wersje PreRelease często zawierają niezmodyfikowane błędy, funkcje w toku lub przekreślone implementacje**. Jeśli nie uważasz się za użytkownika zaawansowanego, pozostań domyślnym `1` (`Stabilny`) kanał aktualizacji. Kanał `PreRelease` jest dedykowany użytkownikom, którzy wiedzą, jak zgłaszać błędy, rozwiązywanie problemów i udzielanie informacji zwrotnych - nie zostanie udzielone wsparcie techniczne. Sprawdź ASF **[cykl wydania](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** jeśli chcesz dowiedzieć się więcej. Możesz również ustawić `UpdateChannel` na `0` (`None`), jeśli chcesz całkowicie usunąć wszystkie kontrole wersji. Ustawienie `UpdateChannel` na `0` całkowicie wyłączy całą funkcjonalność związaną z aktualizacjami, w tym polecenie `aktualizacja`. Korzystanie z kanału `Brak` jest **zdecydowanie zniechęcone** ze względu na narażenie się na wszelkiego rodzaju problemy (wymienione w `Aktualizacja` poniżej).

**Dopóki nie wiesz, co robisz**, **stanowczo** zalecamy utrzymanie go domyślnie.

---

### `UpdatePeriod`

`byte` type with default value of `24`. Ta właściwość definiuje jak często ASF powinien sprawdzać auto-aktualizacje. Aktualizacje mają kluczowe znaczenie nie tylko dla otrzymywania nowych funkcji i krytycznych poprawek bezpieczeństwa, ale także dla otrzymywania poprawek błędów, poprawy wydajności, poprawy stabilności i więcej. Gdy wartość większa niż `0` jest ustawiona, ASF będzie automatycznie pobierać, wymieniać, i zrestartuj się (jeśli `AutoRestart` zezwoli), gdy nowa aktualizacja jest dostępna. Aby to osiągnąć, ASF będzie sprawdzać co `UpdatePeriod` godzin, jeśli nowa aktualizacja jest dostępna na naszym repozytorium GitHub. Wartość `0` wyłącza automatyczne aktualizacje, ale nadal pozwala na ręczne wykonanie polecenia `aktualizacja`. Możesz również być zainteresowany ustawieniem odpowiedniego `UpdateChannel` , że `UpdatePeriod` powinien naśladować.

Proces aktualizacji ASF obejmuje aktualizację całej struktury folderów używanej przez ASF, ale bez dotykania własnych konfiguracji lub baz danych znajdujących się w katalogu `config` - oznacza to, że wszelkie dodatkowe pliki niezwiązane z ASF w jego katalogu mogą zostać utracone podczas aktualizacji. Domyślna wartość `24` to dobra równowaga między niepotrzebnymi kontrolami a ASF, która jest wystarczająco nowa.

Unless you have a **strong** reason to disable this feature, you should keep auto-updates enabled within reasonable `UpdatePeriod` **for your own good**. To nie tylko dlatego, że nie obsługujemy niczego poza najnowszą stabilną wersją ASF, ale również dlatego, że **dajemy naszą gwarancję bezpieczeństwa tylko dla najnowszej wersji**. Jeśli używasz przestarzałej wersji ASF, to celowo wystawiasz się na wszelkiego rodzaju problemy, od małych błędów, przez uszkodzoną funkcjonalność, kończenie z **[permanentne zawieszenia konta Steam](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**, więc **stanowczo polecamy**, na własne dobro, aby zawsze upewnić się, że twoja wersja ASF jest aktualna. Automatyczne aktualizacje pozwalają nam szybko reagować na wszystkie problemy, wyłączając lub patchując problematyczny kod, zanim będzie mógł eskalować się - jeśli się to zdecydujesz, tracisz wszystkie nasze gwarancje bezpieczeństwa i ryzykowne konsekwencje związane z funkcjonowaniem kodu, które mogą być potencjalnie szkodliwe, nie tylko do sieci Steam, ale także (z definicji) na własne konto Steam.

---

### `WebLimiterDelay`

`ushort` typ z domyślną wartością `300`. Ta właściwość definiuje, w milisekundach, minimalną ilość opóźnienia pomiędzy wysłaniem dwóch kolejnych żądań do tej samej usługi sieciowej Steam. Takie opóźnienie jest wymagane jako usługa **[AkamaiGhost](https://www.akamai.com)** używana wewnętrznie przez Steam zawiera ograniczenie szybkości w oparciu o całkowitą liczbę żądań wysłanych w danym okresie. W normalnych warunkach blok akamajski jest raczej trudny do osiągnięcia, ale przy bardzo dużym obciążeniu pracą z ogromną ciągłą kolejką żądań, jest możliwe wyzwalanie, jeśli nadal wysyłamy zbyt wiele żądań w zbyt krótkim okresie.

Default value was set based on assumption that ASF is the only tool accessing Steam web-services, in particular `steamcommunity.com`, `api.steampowered.com` and `store.steampowered.com`. Jeśli używasz innych narzędzi wysyłających zapytania do tych samych usług internetowych, powinieneś upewnić się, że twoje narzędzie zawiera podobną funkcjonalność `WebLimiterDelay` i ustaw oba podwójne wartości domyślne, który miałby wartość `600`. Gwarantuje to, że w żadnym wypadku nie przekroczysz wysłania więcej niż 1 żądanie na `300` ms.

Zasadniczo obniżenie `WebLimiterDelay` pod domyślną wartością jest **zdecydowanie zniechęcone** , ponieważ może prowadzić do powstania różnych bloków związanych z IP, niektóre z nich mogą mieć charakter stały. Domyślna wartość jest wystarczająco dobra aby uruchomić pojedynczą instancję ASF na serwerze, jak również korzystanie z ASF w normalnym scenariuszu wraz z oryginalnym klientem Steam. Powinny być poprawne w większości zastosowań i należy je tylko zwiększać (nigdy nie zmniejszać). Krótko mówiąc, całkowita liczba wszystkich żądań wysłanych z pojedynczego adresu IP do pojedynczej domeny Steam nigdy nie powinna przekraczać więcej niż 1 żądania na `300` ms.

Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `WebProxy`

`string` typ z domyślną wartością `null`. This property defines a web proxy address that will be used for internal http-related communication, especially to services such as `github.com`, `api.steampowered.com`, `steamcommunity.com` and `store.steampowered.com`. Stosuje się to do ogólnej (niespecyficznej) komunikacji, jak również do komunikacji specyficznej dla bota, jeśli ich odpowiednik `WebProxy` nie jest ustawiony. Przesyłanie żądań ASF mogłoby być wyjątkowo użyteczne dla ominięcia różnego rodzaju zapory, zwłaszcza wielkich zapory ogniowej w Chinach.

Ta właściwość jest zdefiniowana jako ciąg uri:

> Ciąg URI składa się ze schematu (wspierany: http/https/socks4/socks4a/socks5), hosta i opcjonalnego portu. Przykładem kompletnego ciągu uri jest `"http://contoso.com:8080"`.

Jeśli serwer proxy wymaga uwierzytelniania użytkownika, musisz również skonfigurować `WebProxyUsername` i/lub `WebProxyPassword`. Jeżeli nie ma takiej potrzeby, wystarczy samo założenie tego majątku.

Jeśli potrzebujesz proxy wewnętrznej komunikacji z siecią Steam (CM), wtedy powinieneś skonfigurować **[`SteamProtocols`](#steamprotocols)** właściwości bota do wartości, która pozwala tylko na transport websocket. i. . wartość `4`, ponieważ tylko websockets są obsługiwane dla proxying.

Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `WebProxyPassword`

`string` typ z domyślną wartością `null`. Ta właściwość definiuje pole hasła używane w podstawie, skrócie, NTLM, i uwierzytelnianie Kerberos obsługiwane przez docelową maszynę `WebProxy` zapewniającą funkcję proxy. Jeśli serwer proxy nie wymaga danych logowania użytkownika, nie ma potrzeby wprowadzania cokolwiek tutaj. Użycie tej opcji ma sens tylko wtedy, gdy `WebProxy` jest również używane, ponieważ w przeciwnym razie nie ma żadnego efektu.

Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `WebProxyUsername`

`string` typ z domyślną wartością `null`. Ta właściwość definiuje pole nazwy użytkownika używane w podstawie, skrócie, NTLM, i uwierzytelnianie Kerberos obsługiwane przez docelową maszynę `WebProxy` zapewniającą funkcję proxy. Jeśli serwer proxy nie wymaga danych logowania użytkownika, nie ma potrzeby wprowadzania cokolwiek tutaj. Użycie tej opcji ma sens tylko wtedy, gdy `WebProxy` jest również używane, ponieważ w przeciwnym razie nie ma żadnego efektu.

Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

## Ustawienia bota

Jak już wiesz, każdy bot powinien mieć własną konfigurację na podstawie przykładowej struktury JSON poniżej. Zacznij od decyzji jak chcesz nazwać swojego bota (np. `1.json`, `głównie. syn`, `primary.json` lub `AnythingElse.json`) i przejdź do konfiguracji.

**Uwaga:** Bot nie może być nazwany `ASF` (ponieważ to słowo kluczowe jest zarezerwowane dla globalnej konfiguracji), ASF zignoruje również wszystkie pliki konfiguracyjne zaczynające się od kropki.

Konfiguracja bota ma następującą strukturę:

```json
{
    "AcceptGifts": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Włączony": false,
    "Zamówienia rolnicze": [],
    "Preferencje rolnicze": 0,
    "GamesPlayedWhileIdle": [],
    "GamingDeviceType": 1,
    "HoursUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "MachineName": null,
    "MatchableTypes": [5]
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "RedeemingPreferences": 0,
    "RemoteCommunication": 3,
    "SendTradePeriod": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "TransferableTypes": [1, 3, 5],
    "UseLoginKeys": true,
    "UserInterfaceMode": 0,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Wszystkie opcje zostały wyjaśnione poniżej:

### `AcceptGifts`

`bool` typ z domyślną wartością `false`. Po włączeniu ASF automatycznie przyjmie i wykorzysta wszystkie prezenty parowe (w tym karty podarunkowe portfela) wysłane do bota. Obejmuje to również prezenty wysyłane przez użytkowników innych niż zdefiniowane w `SteamUserPermissions`. Pamiętaj, że prezenty wysłane na adres e-mail nie są bezpośrednio przekazywane do klienta, więc ASF nie zaakceptuje ich bez Twojej pomocy.

Ta opcja jest zalecana tylko dla kont alt, ponieważ jest bardzo prawdopodobne, że nie chcesz automatycznie wymieniać wszystkich prezentów wysłanych na Twoje konto główne. Jeśli nie jesteś pewien, czy ta funkcja jest włączona, czy nie, zachowaj ją z domyślną wartością `false`.

---

### `BotBehaviour`

`byte flags` type with default value of `0`. Ta właściwość definiuje zachowania botpodobnego do ASF podczas różnych wydarzeń i jest zdefiniowana poniżej:

| Wartość | Nazwa                         | Opis                                                                                                                           |
| ------- | ----------------------------- | ------------------------------------------------------------------------------------------------------------------------------ |
| 0       | None                          | Brak zachowania bota, ustawienia domyślne sane                                                                                 |
| 1       | RejectInvalidFriendInvites    | Spowoduje odrzucenie (zamiast ignorowania) nieprawidłowych zaproszeń znajomych                                                 |
| 2       | RejectInvalidTrades           | Spowoduje odrzucenie (zamiast ignorowania) nieprawidłowych ofert handlowych                                                    |
| 4       | RejectInvalidGroupInvites     | Spowoduje odrzucenie (zamiast ignorowania) nieprawidłowych zaproszeń do grupy                                                  |
| 8       | DismissInventoryNotifications | Spowoduje automatyczne odrzucenie wszystkich powiadomień o ekwipunku przez ASF                                                 |
| 16      | MarkReceivedMessagesAsRead    | Spowoduje automatyczne oznaczanie wszystkich otrzymanych wiadomości jako przeczytanych przez ASF                               |
| 32      | MarkBotMessagesAsRead         | Spowoduje automatyczne oznaczanie wiadomości przez ASF przez inne boty ASF (działające w tej samej instancji) jako przeczytane |
| 64      | Wyłączono TradesParsing       | Spowoduje, że ASF nigdy nie przetwarza ofert przychodzących                                                                    |

Zauważ, że ta właściwość jest polem `flagi` , dlatego możliwe jest wybranie dowolnej kombinacji dostępnych wartości. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Nie włącza żadnej z flag daje wynik w opcji `Brak`.

Generalnie chcesz zmodyfikować tę właściwość, jeśli chcesz zmienić różne ustawienia automatyzacji związane z aktywnością bota. Ustawienia domyślne obejmują ASF pracujący w trybie nieinwazyjnym, co umożliwia jedynie korzystną automatyzację, która nie jest sprzeczna z wolą użytkownika.

Nieprawidłowe zaproszenie znajomych to zaproszenie, które nie pochodzi od użytkownika z uprawnieniem `FamilySharing` (zdefiniowanym w `SteamUserPermissions`lub wyżej. ASF w trybie normalnym ignoruje te zaproszenia, zgodnie z oczekiwaniami, dając Ci wolny wybór, czy je zaakceptować, czy nie. `RejectInvalidFriendIninvite` spowoduje automatyczne odrzucenie tych zaproszeń, która praktycznie wyłączy opcję dodawania cię do listy znajomych dla innych osób (ponieważ ASF odrzuci wszystkie takie żądania, oprócz osób zdefiniowanych w `SteamUserPermissions`). Jeśli nie chcesz całkowicie odmówić wszystkim znajomym, nie powinieneś włączyć tej opcji.

Nieprawidłowa oferta handlowa to oferta, która nie jest akceptowana za pomocą wbudowanego modułu ASF. Więcej na ten temat można znaleźć w sekcji **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** , która wyraźnie określa, jakie rodzaje transakcji ASF jest skłonne akceptować automatycznie. Prawidłowe transakcje są również zdefiniowane przez inne ustawienia, szczególnie `TradingPreferences`. `RejectInvalidTrades` spowoduje odrzucenie wszystkich nieprawidłowych ofert handlowych zamiast ignorowania. Jeśli nie chcesz całkowicie odmówić wszystkich ofert handlowych, które nie są automatycznie akceptowane przez ASF, nie powinieneś włączyć tej opcji.

Nieprawidłowe zaproszenie do grupy to zaproszenie, które nie pochodzi z grupy `SteamMasterClanID`. ASF w trybie normalnym ignoruje zaproszenia do grupy, zgodnie z oczekiwaniami, pozwalając Ci na samodzielne decydowanie czy chcesz dołączyć do konkretnej grupy Steam czy nie. `RejectInvalidGroupInZaproszenia` spowodują, że wszystkie zaproszenia do grupy zostaną automatycznie odrzucone, skutecznie uniemożliwiając zaproszenie do żadnej innej grupy niż `SteamMasterClanID`. Jeśli nie chcesz całkowicie odmówić wszystkim zaproszeniom do grupy, nie powinieneś włączyć tej opcji.

`Odrzuć InventoryNotifications` jest niezwykle przydatny, gdy zaczniesz być irytowany ciągłym powiadomieniem Steam o otrzymywaniu nowych przedmiotów. ASF nie może się pozbyć samego powiadomienia, ponieważ jest wbudowany w Twój klient Steam, ale jest w stanie automatycznie wyczyścić powiadomienie po jego otrzymaniu, co nie spowoduje już zawieszenia powiadomienia "nowe elementy w ekwipunku". Jeśli spodziewasz się samodzielnie ocenić wszystkie otrzymane przedmioty (zwłaszcza karty z ASF), to naturalnie nie powinieneś włączyć tej opcji. Kiedy zaczynasz szaleć, pamiętaj, że oferuje się to jako opcję.

`MarkReceivedMessagesAsRead` automatycznie oznaczy wszystkie wiadomości **wszystkie** otrzymywane przez konto, na którym ASF jest uruchomione, zarówno prywatny, jak i grupa, w czytaniu. Zazwyczaj powinno być używane przez konta alt tylko w celu wyczyszczenia powiadomienia "nowa wiadomość" pochodzącego np. od Ciebie podczas wykonywania poleceń ASF. Nie zalecamy tej opcji dla kont podstawowych, chyba że chcesz usunąć się z powiadomień o nowych wiadomościach, **włącznie z** te, które miały miejsce w trybie offline, zakładając, że ASF nadal pozostawało otwarte.

`MarkBotMessagesAsRead` działa w podobny sposób, oznaczając tylko wiadomości bota jako przeczytane. Pamiętaj, że podczas korzystania z tej opcji na czatach grupowych z Twoimi botami i innymi osobami, implementacja Steam w celu potwierdzenia wiadomości czatu **również** potwierdza wszystkie wiadomości, które wydarzyły się **przed** to, które zdecydowałeś się oznaczyć, więc jeśli jakakolwiek szansa nie chcesz przegapić niepowiązanej wiadomości, która wydarzyła się między sobą, zwykle chcesz uniknąć korzystania z tej funkcji. Oczywiście jest to również ryzykowne, gdy masz wiele rachunków głównych (np. od różnych użytkowników) działających w tej samej instancji ASF, ponieważ możesz również przegapić ich normalne wiadomości spoza ASF.

`DisableIncomingTradesParsing` powstrzyma ASF od analizowania przychodzących ofert handlowych, co oznacza, że cała związana z tym funkcjonalność transakcyjna nie będzie działać. Ponieważ ASF działa domyślnie w trybie najmniej inwazyjnym, akceptując tylko oferty handlowe od użytkowników `Master` i powyżej, nigdy nie dotykaj innych ofert handlowych - parsowanie przychodzących transakcji jest domyślnie włączone. To ustawienie ma jak największy sens dla ludzi, którzy chcieliby zapewnić brak dodatkowych żądań/kosztów ogólnych związanych z przetwarzaniem transakcji, wyłączając całą logikę w procesie, na przykład ponieważ wiedzą, że ich boty nigdy nie będą otrzymywać podstawowych zleceń handlowych, i w związku z tym nie wymagają od ASF udziału w ich działalności handlowej. Pamiętaj, że wybranie tej opcji spowoduje wyłączenie wszystkich innych opcji, które zależą również od transakcji przychodzących, Takie jak `AcceptDonations` lub `SteamTradeMatcher` - niestandardowe wtyczki nie będą również w stanie przetworzyć przychodzących ofert handlowych w zwykły sposób.

Jeśli nie jesteś pewien, jak skonfigurować tę opcję, najlepiej zostawić ją domyślnie.

---

### `CompleteTypesToSend`

`ImmutableHashSet<byte>` typ z domyślną wartością bycia pustym. W przypadku gdy ASF wykonuje się z wypełnieniem określonego zestawu typów pozycji w niniejszym punkcie, może automatycznie wysyłać transakcje parowe ze wszystkimi gotowymi zestawami do użytkownika z uprawnieniami `Mistrz` , co jest bardzo wygodne, jeśli chcesz użyć danego konta bota dla e. . Dopasowanie STM, podczas przenoszenia gotowych zestawów na inne konto. Ta opcja działa tak samo jak polecenie `loot` , dlatego pamiętaj, że wymaga on uprawnienia użytkownika z `Master` , możesz również potrzebować poprawnego `SteamTradeToken`, a także korzystanie z rachunku kwalifikującego się w pierwszej kolejności.

Na dzień dzisiejszy w tym ustawieniu obsługiwane są następujące typy przedmiotów:

| Wartość | Nazwa           | Opis                                                                    |
| ------- | --------------- | ----------------------------------------------------------------------- |
| 3       | FoilTradingCard | Wariant foliowy `TradingCard`                                           |
| 5       | TradingCard     | Karta handlowa z parą wodną, używana do tworzenia odznak (niefoliowych) |

Pamiętaj, że niezależnie od powyższych ustawień, ASF zapyta tylko o **[elementy społeczności Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` z 753, `contextID` z 6), więc wszystkie przedmioty gry, prezenty i podobne, są z definicji wyłączone z oferty handlowej.

Ze względu na dodatkowe ogólne zastosowanie tej opcji, zaleca się używanie go tylko na kontach botów, które mają realną szansę na samodzielne wykończenie zestawów - na przykład nie ma sensu aktywować, jeśli używasz już opcji `SendOnFarmingFfinished` w `FarmingPreferences`, Komenda `SendTradePeriod` lub `loot` na zwykłych zasadach.

Jeśli nie jesteś pewien, jak skonfigurować tę opcję, najlepiej zostawić ją domyślnie.

---

### `CustomGamePlayedWhileFarming`

`string` typ z domyślną wartością `null`. Gdy ASF jest gospodarstwem rolnym, może wyświetlać się jako "Gra nieparowa: `CustomGamePlayedWhileFarming`zamiast aktualnie uprawianej gry. Może to być przydatne, jeśli chcesz poinformować znajomych o rolnictwie, jeszcze nie chcesz używać `OnlineStatus` z `Offline`. Pamiętaj, że ASF nie może zagwarantować aktualnej kolejności wyświetlania sieci Steam, w związku z tym jest to jedynie sugestia, która może lub nie może być odpowiednio umieszczona. W szczególności niestandardowa nazwa nie będzie wyświetlana w algorytmie rolniczym `Complex` jeśli ASF wypełnia wszystkie pola `32` z grami wymagającymi godzin spustu. Domyślna wartość `null` wyłącza tę funkcję.

ASF dostarcza kilka zmiennych specjalnych, których możesz opcjonalnie użyć w swoim tekście. `{0}` zostanie zastąpiony przez ASF na `AppID` aktualnie produkowanych gry/rozgrywek/rozgrywanych w warunkach fermowych, podczas gdy `{1}` zostanie zastąpiony przez ASF na `GameName` obecnie hodowanych gr.

---

### `CustomGamePlayedWhileIdle`

`string` typ z domyślną wartością `null`. Podobnie jak `CustomGamePlayedWhileFarming`, ale w sytuacji, gdy ASF nie ma nic do zrobienia (jako konto jest w pełni przygotowane). Pamiętaj, że ASF nie może zagwarantować aktualnej kolejności wyświetlania sieci Steam, w związku z tym jest to jedynie sugestia, która może lub nie może być odpowiednio umieszczona. Jeśli używasz `GamesPlayedWhileIdle` razem z tą opcją, pamiętaj, że `GamesPlayedWhileIdle` otrzymuje priorytet, w związku z tym nie można zadeklarować więcej niż `31` z nich, jako inaczej `CustomGamePlayedWhileIdle` nie będzie w stanie zajmować gniazda dla własnej nazwy. Domyślna wartość `null` wyłącza tę funkcję.

---

### `Enabled`

`bool` typ z domyślną wartością `false`. Ta właściwość definiuje czy bot jest włączony. Włączone instancje bota (`true`) automatycznie rozpoczną się po uruchomieniu ASF, podczas gdy wyłączona instancja bota (`false`) będzie musiała zostać uruchomiona ręcznie. Domyślnie każdy bot jest wyłączony, więc prawdopodobnie chcesz przełączyć tę właściwość na `true` dla wszystkich botów, które powinny być uruchamiane automatycznie.

---

### `FarmingOrders`

`Niezmienna lista<byte>` z domyślną wartością bycia pustym. This property defines the **preferred** farming order used by ASF for given bot account. Obecnie dostępne są następujące zlecenia rolnicze:

| Wartość | Nazwa                     | Opis                                                                                                   |
| ------- | ------------------------- | ------------------------------------------------------------------------------------------------------ |
| 0       | Unordered                 | Brak sortowania, nieznacznie poprawia wydajność procesora                                              |
| 1       | AppIDsAscending           | Najpierw spróbuj polować gry z najniższym `appIDs`                                                     |
| 2       | AppIDsDescending          | Najpierw spróbuj polować gry z najwyższymi `appIDs`                                                    |
| 3       | CardDropsAscending        | Spróbuj polować gry z najmniejszą liczbą kropli kart, które pozostały najpierw                         |
| 4       | CardDropsDescending       | Spróbuj polować gry z największą liczbą kropli kart, które pozostały najpierw                          |
| 5       | HoursAscending            | Najpierw spróbuj polować gry z najmniejszą liczbą godzin                                               |
| 6       | HoursDescending           | Najpierw spróbuj polować gry z największą liczbą godzin                                                |
| 7       | NamesAscending            | Spróbuj polować gry w kolejności alfabetycznej, począwszy od A                                         |
| 8       | NamesDescending           | Spróbuj polować gry w odwrotnej kolejności alfabetycznej, począwszy od Z                               |
| 9       | Random                    | Spróbuj polować gry w całkowicie losowo wybranej kolejności (różnej przy każdym uruchomieniu programu) |
| 10      | BadgeLevelsAscending      | Spróbuj najpierw polować gry z najniższym poziomem odznaki                                             |
| 11      | BadgeLevelsDescending     | Najpierw spróbuj polować gry z najwyższymi poziomami odznaki                                           |
| 12      | RedeemDateTimesAscending  | Najpierw wypróbuj najstarsze gry na naszym koncie                                                      |
| 13      | RedeemDateTimesDescending | Najpierw pogospodaruj najnowsze gry na naszym koncie                                                   |
| 14      | MarketableAscending       | Najpierw staraj się rozgrywać gry z niezbywalnymi kartami (ostrzeżenie: drogie do obliczenia)          |
| 15      | MarketableDescending      | Spróbuj najpierw rozgrywać gry z marketingowymi kroplami karty (ostrzeżenie: drogie obliczenia)        |

Ponieważ ta właściwość jest tablicą, pozwala ci używać kilku różnych ustawień w Twoim stałym zamówieniu. Na przykład możesz uwzględnić wartości `15`, `11` i `7` w celu sortowania najpierw według gier marketingowych, następnie przez tych, którzy mają najwyższy poziom odznaki i w końcu alfabetycznie. Jak można się zgadzać, zamówienie ma znaczenie jako odwrócone (`7`, `11` i `15`) osiąga coś zupełnie innego (najpierw sortuje gry alfabetycznie, i ze względu na unikalne nazwy gry, pozostałe dwie są faktycznie bezużyteczne). Większa liczba osób prawdopodobnie wykorzysta tylko jedną kolejność spośród wszystkich z nich, ale jeśli chcesz, możesz również sortować dalej według dodatkowych parametrów.

Zauważa również słowo "prób" we wszystkich powyższych opisach - wybrana **[karta rolnicza algorytm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** , a sortowanie wpłynie tylko na wyniki, które ASF uznaje za takie samo wydajność. Na przykład w algorytmie `Simple` , wybrane `Zamówienia Rolnicze` powinny być w pełni przestrzegane w bieżącej sesji rolnej (każda gra ma taką samą wartość wydajności), podczas gdy w `Complex` algorytm rzeczywiste zlecenie jest najpierw uzależnione od godzin, a następnie posortowane zgodnie z wybranym `Zamówienia Rolnicze`. To doprowadzi do różnych wyników, ponieważ gry z istniejącym czasem gry będą miały pierwszeństwo przed innymi. tak skutecznie ASF preferuje gry, które zostały już przekazane wymagane `HoursUntilCardDrops` najpierw i tylko potem posortuj te gry dalej według wybranego `Zlecenia Rolnicze`. Podobnie, gdy ASF skończy już zabijać gry, sortuje pozostałe kolejki po pierwszych godzinach (ponieważ to zmniejszy czas potrzebny do zrzucenia pozostałych tytułów do `HoursUntilCardDrops`). Dlatego ta właściwość konfiguracyjna jest tylko **sugestią** , którą ASF spróbuje uszanować, tak długo, jak nie wpłynie negatywnie na wydajność (w tym przypadku ASF zawsze preferuje wydajność rolniczą nad `Zlecenia Rolnicze`).

Istnieje również kolejka priorytetu rolnictwa, która jest dostępna za pośrednictwem poleceń `fq` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Jeśli jest używana, rzeczywiste zamówienie rolnicze jest najpierw posortowane według wydajności, następnie według kolejki rolniczej, a na koniec według `Zlecenia Rolnicze`.

---

### `Ustawienia Rolnictwa`

`byte flags` type with default value of `0`. Właściwość ta definiuje zachowania ASF związane z rolnictwem i definiuje się jak poniżej:

| Wartość | Nazwa                       |
| ------- | --------------------------- |
| 0       | None                        |
| 1       | FarmingPausedByDefault      |
| 2       | ShutdownOnFarmingFinished   |
| 4       | SendOnFarmingFinished       |
| 8       | Tylko FarmPriorityQueueOnly |
| 16      | Pominięte gry               |
| 32      | Pomiń niezagrane gry        |
| 64      | EnableRiskyCardsDiscovery   |
| 256     | AutoUnpackBoosterPacks      |

Zauważ, że ta właściwość jest polem `flagi` , dlatego możliwe jest wybranie dowolnej kombinacji dostępnych wartości. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Nie włącza żadnej z flag daje wynik w opcji `Brak`.

Wszystkie opcje opisano poniżej.

`FarmingPausedByDefault` definiuje początkowy stan modułu `CardsFarmer`. Zazwyczaj bot automatycznie rozpocznie proces rolniczy po jego uruchomieniu, z powodu polecenia `Włączone` lub `uruchom`. Używanie `FarmingPausedByDefault` może być używane jeśli chcesz ręcznie `wznowić` automatyczny proces rolniczy, na przykład, ponieważ chcesz używać `graj` przez cały czas i nigdy nie używaj automatycznego modułu `CardsFarmer` - działa dokładnie tak samo jak `wstrzymuje` **[polecenie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**

`ShutdownOnFarmingFfinished` pozwala zamknąć bota po zakończeniu działalności rolniczej. Zwykle ASF „zajmuje” konto przez cały czas aktywności. Gdy dane konto jest wykonywane w rolnictwie, ASF okresowo sprawdza je (każdy `IdleFarmingPeriod` godzin), jeśli w międzyczasie dodano kilka nowych gier z kartami parowymi, aby mógł wznowić działalność rolniczą bez konieczności ponownego uruchomienia procesu. Jest to użyteczne dla większości ludzi, ponieważ ASF może w razie potrzeby automatycznie wznowić działalność rolniczą. Jednak w rzeczywistości możesz zatrzymać ten proces, gdy dane konto jest w pełni rozwinięte, możesz to osiągnąć, używając tej flagi. Po włączeniu ASF będzie kontynuował wylogowanie, gdy konto jest w pełni położone, co oznacza, że nie będzie już okresowo sprawdzane ani zajęte. Powinieneś sam zdecydować, jeśli wolisz ASF pracować na danej instancji bota przez cały czas, lub jeśli ASF powinien go zatrzymać w trakcie procesu rolniczego.

Ta opcja ma największy sens do połączenia z `ShutdownIfPossible`, więc po zatrzymaniu wszystkich kont ASF również zostanie wyłączony, pozostawienie urządzenia w spoczynku i umożliwienie zaplanowania innych czynności, takich jak spanie lub wyłączenie w tym samym momencie ostatniego opadania karty.

`SendOnFarmingFfinished` pozwala automatycznie wysyłać parę handlową zawierającą wszystkie produkty wyhodowane do tego punktu użytkownikowi z uprawnieniami `Master` , co jest bardzo wygodne, jeśli nie chcesz przeszkadzać sobie transakcjami. Ta opcja działa tak samo jak polecenie `loot` , dlatego pamiętaj, że wymaga on uprawnienia użytkownika z `Master` , możesz również potrzebować poprawnego `SteamTradeToken`, a także korzystanie z rachunku kwalifikującego się w pierwszej kolejności. In addition to initiating `loot` after finishing farming, ASF will also initiate `loot` on each new items notification (when not farming), and after completing each trade that results in new items (always) when this option is active. Jest to szczególnie przydatne w przypadku przekazywania na nasze konto produktów otrzymanych od innych osób. Zazwyczaj chcesz użyć **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** razem z tą funkcją, chociaż nie jest to wymaganie, jeśli zamierzasz ręcznie obsługiwać potwierdzenia 2FA w odpowiednim czasie.

`FarmPriorityQueueOnly` definiuje, czy ASF powinien uwzględniać dla automatycznych aplikacji rolniczych, które dodałeś do priorytetowej kolejki rolniczej dostępnej z `fq` **[polecenia](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Gdy ta opcja jest włączona, ASF pominnie wszystkie `appIDs` , których brakuje na liście, skutecznie pozwalając Ci na wybieranie gier do automatycznej hodowli ASF. Pamiętaj, że jeśli nie dodałeś żadnych gier do kolejki, ASF będzie działał tak, jakby na Twoim koncie nie było nic do farmienia.

`SkipRefundableGames` określa, czy ASF powinien pominąć gry, które nadal podlegają zwrotowi z automatycznej hodowli. Gra podlegająca zwrotowi to gra, którą kupiłeś w ciągu ostatnich 2 tygodni w sklepie Steam i która nie grała jeszcze dłużej niż 2 godziny, jak podano na stronie **[Steam refunduje](https://store.steampowered.com/steam_refunds)**. Domyślnie ASF ignoruje politykę zwrotu kosztów w całości i gospodaruje wszystko, czego oczekuje większość ludzi. Możesz jednak użyć tej flagi, jeśli chcesz upewnić się, że ASF nie przepychnie żadnych twoich gier podlegających zwrotowi, umożliwienie samodzielnej oceny tych gier i zwrotu, jeśli to konieczne, bez obaw, że ASF ma negatywny wpływ na czas gry. Pamiętaj, że jeśli włączysz tę opcję, gry, które kupiłeś w sklepie Steam nie będą prowadzone przez ASF przez okres do 14 dni od daty realizacji, które nie będą pokazywać jako nic do hodowli, jeśli Twoje konto nie posiada niczego innego.

`SkipUnplayedGames` określa, czy ASF powinien pominąć gry, których jeszcze nie uruchomiłeś. Niegrana gra w tym kontekście oznacza, że nie masz dla niej żadnych nagrań na Steamie. Jeśli używasz tej flagi, takie gry zostaną pominięte, dopóki Steam nie zarejestruje dla nich czasu gry. Pozwala Ci to lepiej kontrolować, które gry ASF kwalifikują się do hodowli, pomijając te, których jeszcze nie miałeś szansy wypróbować, utrzymywanie wybranych funkcji Steam bardziej przydatnych - takich jak sugerowanie niezagranych gier do gry.

`EnableRiskyCardsDiscovery` umożliwia dodatkowe awaryjne urządzenie, które wyzwala się, gdy ASF nie może załadować jednej lub więcej odznak i dlatego nie jest w stanie znaleźć gier dostępnych dla rolnictwa. W szczególności niektóre konta z dużą ilością kropli kart mogą spowodować sytuację, w której wczytywanie odznak nie jest już możliwe (ze względu na koszty ogólne), i te konta są niemożliwe dla rolnictwa wyłącznie dlatego, że nie możemy załadować informacji, na podstawie których możemy rozpocząć proces. W tych pomocnych przypadkach opcja ta pozwala na zastosowanie alternatywnego algorytmu. w której wykorzystuje się kombinację wzmacniaczy możliwych do stworzenia i wzmocnienia pakietów, dla których konto jest uprawnione, w celu znalezienia potencjalnie dostępnych gier do bezczynności, następnie wydać zbyt dużą ilość środków na weryfikację i pobranie wymaganych informacji, i próba rozpoczęcia procesu produkcji rolnej na ograniczonej ilości danych i informacji, aby ostatecznie osiągnąć sytuację, kiedy ładowanie odznaki będzie w stanie zastosować zwykłe podejście. Należy pamiętać, że gdy ta rezerwa jest używana, ASF działa tylko z ograniczonymi danymi, w związku z tym w pełni normalne jest, aby ASF znalazł dużo mniej kropli niż w rzeczywistości - na późniejszym etapie procesu rolniczego znajdą się inne kropli.

This option is called "risky" for a very good reason - it's extremely slow and requires significant amount of resources (including network requests) for operation, therefore it's **not recommended** to be enabled, and especially in long-term. Powinieneś użyć tej opcji tylko wtedy, gdy wcześniej ustaliłeś, że Twoje konto nie jest w stanie załadować odznak, a ASF nie może na nim działać, zawsze nie można załadować informacji niezbędnych do rozpoczęcia procesu. Nawet jeśli uczyniliśmy wszystko, co w naszej mocy, by jak najlepiej zoptymalizować ten proces, nadal możliwe jest wystrzelenie tej opcji i może to spowodować niepożądane wyniki, takie jak tymczasowe i może nawet stałe zakazy wysyłania zbyt wielu żądań i powodowania przekierowania na serwery Steam. Dlatego ostrzegamy Cię z wyprzedzeniem i oferujemy tę opcję bez żadnych gwarancji, używasz jej na własne ryzyko.

`AutoUnpackBoosterPacks` automatycznie rozpakuje wszystkie paczki wzmacniające po otrzymaniu powiadomienia o nowych przedmiotach. Pozwoli to na natychmiastowe nabycie dodatkowych kropli karty, które mogą być pożądane, zwłaszcza w połączeniu z innymi opcjami (e. . `SteamTradeMatcher` lub `CompleteTypesToSend`).

---

### `GamesPlayedWhileIdle`

`ImmutableHashSet<uint>` typ z domyślną wartością bycia pustym. Jeśli ASF nie ma nic do hodowli, to zamiast tego może grać w wybrane gry parowe (`appIDs`. Granie w gry w taki sposób zwiększa liczbę Twoich godzin w grze, ale nic innego niż poza nim. In order for this feature to work properly, your Steam account **must** own a valid license to all the `appIDs` that you specify here, this includes F2P games as well. Ta funkcja może być włączona w tym samym czasie z `CustomGamePlayedWhileIdle` , aby grać w wybrane gry podczas wyświetlania własnego statusu w sieci Steam, ale w tym przypadku, podobnie jak w przypadku `, CustomGamePlayedWhileFarming` , faktyczna kolejność wyświetlania nie jest gwarantowana. Pamiętaj, że Steam pozwala ASF grać tylko do `32` `appIDs` łącznie, dlatego możesz umieścić tylko tyle gier na tej własności.

---

### `Urządzenie do grania`

`ushort` typ z domyślną wartością `1`. Ta właściwość może włączyć kilka dodatkowych funkcji online na platformie Steam i jest zdefiniowana jak poniżej:

| Wartość | Nazwa          | Opis                             |
| ------- | -------------- | -------------------------------- |
| 1       | Standardowy PC | Brak trybu specjalnego, domyślny |
| 544     | SteamDeck      | Prezentuj się jako talia Steam   |

Podstawowy typ `EGamingDeviceType` , że ta właściwość jest oparta na bardziej dostępnych wartościach, jednak, zgodnie z naszą najlepszą wiedzą, od dziś nie przynoszą one żadnych efektów, dlatego zostały one odcięte ze względu na widoczność.

Jeśli nie jesteś pewien, jak ustawić tę właściwość, pozostaw ją z domyślną wartością `1`.

---

### `HoursUntilCardDrops`

`byte` type with default value of `3`. Ta właściwość definiuje czy konto ma ograniczone upuszczanie karty i jeśli tak, to przez ile początkowych godzin. Ograniczone upuszczanie kart oznacza, że konto nie otrzymuje żadnych upuszczonych kart z danej gry dopóki gra nie będzie grana przez co najmniej `HoursUntilCardDrops` godzin. Niestety nie ma magicznego sposobu na wykrycie tego, tak więc ASF polega na was. This property affects **[cards farming algorithm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** that will be used. Ustawienie tej właściwości poprawnie zmaksymalizuje zyski i zminimalizuje czas potrzebny na farmie. Pamiętaj, że nie ma oczywistej odpowiedzi, czy powinieneś użyć jednej czy drugiej wartości, ponieważ w pełni zależy od Twojego konta. Wygląda na to, że starsze konta, które nigdy nie zwróciły się o zwrot, mają nieograniczone zrzuty karty, więc powinni użyć wartości `0`, podczas gdy nowe konta i ci, którzy zwrócili się o zwrot mają ograniczoną liczbę kart o wartości `3`. Jest to jednak tylko teoria i zasadniczo nie powinno być traktowane jako zasada. Wartość domyślna dla tej właściwości została ustawiona na podstawie „mniejszego zła” i większości przypadków używania.

---

### `LootableTypes`

`ImmutableHashSet<byte>` typ z domyślną wartością `1, 3, 5` elementów pary. Ta właściwość definiuje zachowanie ASF podczas wydobywania - obydwa ręcznie, używając polecenia **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, jak również automatyczne, poprzez jedną lub więcej właściwości konfiguracyjnych. ASF zapewni, że tylko przedmioty z `LootableTypes` będą zawarte w ofercie handlowej, dlatego ta właściwość pozwala wybrać to, co chcesz otrzymać w ofercie handlowej, która jest wysyłana do Ciebie.

| Wartość | Nazwa                 | Opis                                                                    |
| ------- | --------------------- | ----------------------------------------------------------------------- |
| 0       | Unknown               | Każdy typ, który nie pasuje do żadnego z poniższych                     |
| 1       | BoosterPack           | Pakiet Booster zawierający 3 losowe karty z gry                         |
| 2       | Emoticon              | Emotikona do użycia na Czacie Steam                                     |
| 3       | FoilTradingCard       | Wariant foliowy `TradingCard`                                           |
| 4       | ProfileBackground     | Tło profilu do użycia na Twoim profilu Steam                            |
| 5       | TradingCard           | Karta handlowa z parą wodną, używana do tworzenia odznak (niefoliowych) |
| 6       | SteamGems             | Klejnoty parowe używane do wytwarzania pobudzarek, w tym worki          |
| 7       | SaleItem              | Specjalne przedmioty przyznane podczas sprzedaży Steam                  |
| 8       | Consumable            | Specjalne przedmioty zużywalne, które znikają po użyciu                 |
| 9       | ProfileModifier       | Specjalne przedmioty, które mogą modyfikować wygląd profilu Steam       |
| 10      | Sticker               | Specjalne przedmioty, które mogą być użyte na czacie Steam              |
| 11      | ChatEffect            | Specjalne przedmioty, które mogą być użyte na czacie Steam              |
| 12      | MiniProfileBackground | Specjalne tło dla profilu Steam                                         |
| 13      | AvatarProfileFrame    | Specjalna ramka awatara dla profilu Steam                               |
| 14      | AnimatedAvatar        | Specjalny animowany awatar dla profilu Steam                            |
| 15      | Skórka klawiatury     | Specjalna skórka klawiatury dla talii Steam                             |
| 16      | Uruchamianie wideo    | Specjalny film startowy dla talii Steam                                 |

Pamiętaj, że niezależnie od powyższych ustawień, ASF zapyta tylko o **[elementy społeczności Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` z 753, `contextID` z 6), więc wszystkie przedmioty gry, prezenty i podobne, są z definicji wyłączone z oferty handlowej.

Domyślne ustawienie ASF opiera się na najczęstszym użyciu bota, z wykorzystaniem tylko pakietów wzmacniających oraz kart handlowych (w tym folii). Zdefiniowana tutaj właściwość pozwala na zmianę tego zachowania w jakikolwiek sposób, który Cię satysfakcjonuje. Pamiętaj, że wszystkie typy nie zdefiniowane powyżej będą wyświetlane jako `Nieznany typ` , co jest szczególnie ważne, gdy zawór uwalnia trochę nowego elementu Steam, który zostanie oznaczony jako `Unknown` również przez ASF, dopóki nie zostanie dodany tutaj (w przyszłej wersji). Dlatego zasadniczo nie zaleca się umieszczania `Nieznany typ` w twoim `LootableTypes`, chyba że wiesz, co robisz, i rozumiesz również, że ASF wyśle cały twój ekwipunek w ofercie handlowej, jeśli Steam Network zostanie ponownie zniszczony i zgłosi wszystkie Twoje przedmioty jako `Nieznane`. Moją silną sugestią jest nie uwzględnianie `Unknown` type in the `LootableTypes`, nawet jeśli spodziewasz się wydobyć wszystko (inne).

---

### `Nazwa maszyny`

`string` typ z domyślną wartością `null`. ASF will use this property when logging in to Steam network, which can be used for customization in regards to how exactly Steam will display ASF machine and session, e.g. when displaying devices that are currently logged in **[here](https://store.steampowered.com/account/authorizeddevices)**.

ASF dostarcza kilka zmiennych specjalnych, których możesz opcjonalnie użyć w swoim tekście. `{0}` zostanie zastąpiony nazwą maszyny podaną przez system operacyjny, `{1}` zostanie zastąpiony publicznym identyfikatorem ASF, gdy `{2}` zostanie zastąpiony wersją ASF.

Dopóki nie wiesz, co robisz, powinieneś zachować domyślną wartość `null`. In this case, ASF will decide internally about the proper value, which is `{0} ({1}/{2})` as of today. Pamiętaj, że jest to tylko sugestia, że sieć Steam może lub nie może w pełni szanować.

---

### `MatchableTypes`

`ImmutableHashSet<byte>` typ z domyślną wartością `5` typu przedmiotów Steam. Ta właściwość definiuje, które typy produktów Steam mogą być dopasowane, gdy opcja `SteamTradeMatcher` w `TradingPreferences` jest włączona. Rodzaje są określone poniżej:

| Wartość | Nazwa                 | Opis                                                                    |
| ------- | --------------------- | ----------------------------------------------------------------------- |
| 0       | Unknown               | Każdy typ, który nie pasuje do żadnego z poniższych                     |
| 1       | BoosterPack           | Pakiet Booster zawierający 3 losowe karty z gry                         |
| 2       | Emoticon              | Emotikona do użycia na Czacie Steam                                     |
| 3       | FoilTradingCard       | Wariant foliowy `TradingCard`                                           |
| 4       | ProfileBackground     | Tło profilu do użycia na Twoim profilu Steam                            |
| 5       | TradingCard           | Karta handlowa z parą wodną, używana do tworzenia odznak (niefoliowych) |
| 6       | SteamGems             | Klejnoty parowe używane do wytwarzania pobudzarek, w tym worki          |
| 7       | SaleItem              | Specjalne przedmioty przyznane podczas sprzedaży Steam                  |
| 8       | Consumable            | Specjalne przedmioty zużywalne, które znikają po użyciu                 |
| 9       | ProfileModifier       | Specjalne przedmioty, które mogą modyfikować wygląd profilu Steam       |
| 10      | Sticker               | Specjalne przedmioty, które mogą być użyte na czacie Steam              |
| 11      | ChatEffect            | Specjalne przedmioty, które mogą być użyte na czacie Steam              |
| 12      | MiniProfileBackground | Specjalne tło dla profilu Steam                                         |
| 13      | AvatarProfileFrame    | Specjalna ramka awatara dla profilu Steam                               |
| 14      | AnimatedAvatar        | Specjalny animowany awatar dla profilu Steam                            |
| 15      | Skórka klawiatury     | Specjalna skórka klawiatury dla talii Steam                             |
| 16      | Uruchamianie wideo    | Specjalny film startowy dla talii Steam                                 |

Oczywiście typy, których powinieneś używać dla tej właściwości, zazwyczaj obejmują tylko `2`, `3`, `4` i `5`, ponieważ tylko te typy są obsługiwane przez STM. ASF zawiera właściwą logikę do odkrywania rzadkości przedmiotów, dlatego też bezpieczne jest dopasowanie emotikonów lub tła, ponieważ ASF poprawnie uwzględni sprawiedliwe tylko te przedmioty z tej samej gry i typu, które również mają tę samą rzadkość.

Pamiętaj, że **ASF nie jest botem handlowym** a **NIE będzie dbał o cenę rynkową**. Jeśli nie uważasz elementów tej samej rzadkości z tego samego zestawu za tę samą cenę, to ta opcja NIE jest dla ciebie. Proszę ocenić dwukrotnie, jeśli rozumiesz i zgadzasz się z tą instrukcją, zanim zdecydujesz się zmienić to ustawienie.

Dopóki nie wiesz, co robisz, powinieneś zachować domyślną wartość `5`.

---

### `Flagi online`

`ushort flags` typ z domyślną wartością `0`. This property works as supplement to **[`OnlineStatus`](#onlinestatus)** and specifies additional online presence features announced to Steam network. Wymaga **[`OnlineStatus`](#onlinestatus)** innego niż `Offline`i jest zdefiniowany jak poniżej:

| Wartość | Nazwa               | Opis                                              |
| ------- | ------------------- | ------------------------------------------------- |
| 0       | None                | Brak specjalnych flag obecności online, domyślnie |
| 2       | InJoinableGame      | Klient jest w grze dołączonej                     |
| 8       | Zdalny PlayTogether | Klient używa zdalnej gry razem sesji              |
| 256     | ClientTypeWeb       | Klient używa interfejsu WWW                       |
| 512     | KlientTypeMobile    | Klient używa aplikacji mobilnej                   |
| 1024    | ClientTypeTenfoot   | Klient używa dużego obrazu                        |
| 2048    | ClientTypeVR        | Klient używa zestawu słuchawkowego VR             |

Zauważ, że ta właściwość jest polem `flagi` , dlatego możliwe jest wybranie dowolnej kombinacji dostępnych wartości. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Nie włącza żadnej z flag daje wynik w opcji `Brak`.

Podstawowy typ `EPersonaStateFlg` , że ta właściwość jest oparta na większej ilości dostępnych flag, jednak, zgodnie z naszą najlepszą wiedzą, od dziś nie przynoszą one żadnych efektów, dlatego zostały one odcięte ze względu na widoczność.

Jeśli nie jesteś pewien, jak ustawić tę właściwość, pozostaw ją z domyślną wartością `0`.

---

### `OnlineStatus`

`byte` type with default value of `1`. Ta właściwość określa status społeczności Steam, że bot zostanie ogłoszony po zalogowaniu się do sieci Steam. Obecnie możesz wybrać jeden z poniższych statusów:

| Wartość | Nazwa               |
| ------- | ------------------- |
| 0       | Offline             |
| 1       | Online              |
| 2       | Zajęty              |
| 3       | Nieobecny(a)        |
| 4       | Drzemka             |
| 5       | LookingToTrade      |
| 6       | Szukam kogoś do gry |
| 7       | Niewidoczny         |

Status `Offline` jest niezwykle przydatny dla kont głównych. Jak powinieneś wiedzieć, rolnictwo gry pokazuje twój status pary jako "Gra gra: XXX", które mogą wprowadzać w błąd przyjaciół, myląc ich, że grasz w grę, podczas gdy w rzeczywistości tylko uprawiasz tę grę. Używanie statusu `Offline` rozwiązuje ten problem - Twoje konto nigdy nie będzie wyświetlane jako "w grze", gdy używasz kart parowych z ASF. Jest to możliwe dzięki temu, że ASF nie musi się zalogować do Wspólnoty Steam w celu prawidłowego działania, więc gramy w te gry, połączone z siecią Steam, ale bez ogłoszenia naszej obecności w Internecie. Pamiętaj, że grane gry o statusie offline będą nadal wliczane do Twojego czasu gry i będą wyświetlane jako "ostatnio grane" na Twoim profilu.

Ponadto ta funkcja jest ważna jeśli chcesz otrzymywać powiadomienia i nieprzeczytane wiadomości, gdy ASF jest uruchomiony, podczas gdy klient Steam nie jest otwarty w tym samym czasie. Dzieje się tak, ponieważ ASF działa jako sam klient Steam i czy ASF chciałaby go czy nie, Steam wysyła do niego wszystkie te wiadomości i inne wydarzenia. To nie jest problem, jeśli masz zarówno ASF, jak i swojego własnego klienta Steam, ponieważ obaj klienci otrzymują dokładnie te same zdarzenia. Jeśli jednak tylko ASF jest uruchomiony, sieć Steam może oznaczać niektóre zdarzenia i wiadomości jako „dostarczone”, mimo że Twój tradycyjny klient Steam nie otrzymuje go z powodu nieobecności. Ten problem rozwiązuje również status offline, ponieważ ASF nigdy nie jest brany pod uwagę przy żadnych wydarzeniach społecznościowych w tym przypadku, więc wszystkie nieprzeczytane wiadomości i inne zdarzenia będą prawidłowo oznaczone jako nieprzeczytane po powrocie.

It's important to note that ASF running on `Offline` mode will **not** be able to receive commands in usual Steam chat way, as the chat, as well as entire community presence is in fact, entirely offline. Rozwiązaniem tego problemu jest tryb `Niewidzialny` , który działa w podobny sposób (nie wyświetla statusu), ale zachowuje możliwość odbierania i odpowiadania na wiadomości (także możliwość odrzucenia powiadomień i nieprzeczytanych wiadomości, jak wskazano powyżej). Tryb `Niewidzialny` ma najwięcej sensu na kontach alt, których nie chcesz wystawić (status wise), ale nadal może wysyłać polecenia.

Istnieje jednak jeden połów z trybem `Niewidzialny` - nie idzie on dobrze z kontami podstawowymi. This is because **any** Steam session that is currently online **exposes** the status, even if ASF itself does not. This is caused by the current limitation/bug of the Steam network that isn't possible to be fixed on ASF side, so if you want to use `Invisible` mode you will also need to ensure that **all** other sessions to the same account use `Invisible` mode as well. Będzie to miało miejsce w przypadku rachunków alt, gdzie ASF jest jedyną aktywną sesją, ale na kontach podstawowych prawie zawsze wolisz pokazać jako `Online` znajomym, ukrywanie tylko aktywności ASF, i w tym przypadku tryb `Niewidoczny` będzie dla Ciebie całkowicie bezużyteczny (zamiast tego zalecamy użycie trybu `Offline`). Miejmy nadzieję, że ten ograniczenie/błąd zostanie ostatecznie rozwiązany w przyszłości przez Głowicę, ale nie spodziewam się, że wkrótce tak się stanie...

Jeśli nie jesteś pewien, jak skonfigurować tę właściwość, zaleca się użycie wartości `0` (`Offline`) dla kont podstawowych, i domyślne `1` (`Online`) w innym przypadku.

---

### `PasswordFormat`

`byte` type with default value of `0` (`PlainText`). Ta właściwość definiuje format właściwości `SteamPassword` i obecnie obsługuje wartości określone w sekcji **[Bezpieczeństwo](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**. Powinieneś postępować zgodnie z instrukcjami tam podanymi, ponieważ musisz upewnić się, że właściwość `SteamPassword` rzeczywiście zawiera hasło w formacie `Hasła`. Innymi słowy, gdy zmienisz `PasswordFormat` to twój `SteamPassword` powinien być **już** w tym formacie, nie tylko dążyć. Dopóki nie wiesz, co robisz, powinieneś zachować domyślną wartość `0`.

Jeśli zdecydujesz się zmienić `PasswordFormat` bota, który przynajmniej raz zalogował się do sieci Steam, istnieje możliwość, że po pierwszym odszyfrowaniu następnego bota pojawi się błąd - jest to spowodowane faktem, że `PasswordFormat` jest również używany w odniesieniu do automatycznego szyfrowania/odszyfrowania wrażliwych właściwości w `Bot. b` plik bazy danych. Możesz bezpiecznie zignorować ten błąd, ponieważ ASF będzie w stanie samodzielnie wyjść z tej sytuacji. Jeśli jednak dzieje się tak na stałe, np. po ponownym uruchomieniu, należy go zbadać.

---

### `RedeemingPreferences`

`byte flags` type with default value of `0`. Właściwość ta definiuje zachowanie ASF podczas realizacji kluczy cd i jest zdefiniowana jak poniżej:

| Wartość | Nazwa                              | Opis                                                                                                                       |
| ------- | ---------------------------------- | -------------------------------------------------------------------------------------------------------------------------- |
| 0       | None                               | Brak specjalnych preferencji redeemingu, domyślnych                                                                        |
| 1       | Forwarding                         | Przekaż klawisze niedostępne do wykorzystania do innych botów                                                              |
| 2       | Distributing                       | Rozdziel wszystkie klucze między sobą i inne boty                                                                          |
| 4       | KeepMissingGames                   | Zachowaj klucze dla (potencjalnie) brakujących gier podczas przekazywania, pozostawiając je nieużywane                     |
| 8       | AssumeWalletKeyOnBadActivationCode | Załóżmy, że klucze `BadActivationCode` są równe `CannotRedeemCodeFroment`, a zatem spróbuj wykupić je jako klucze portfela |

Zauważ, że ta właściwość jest polem `flagi` , dlatego możliwe jest wybranie dowolnej kombinacji dostępnych wartości. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Nie włącza żadnej z flag daje wynik w opcji `Brak`.

`Przekazywanie` spowoduje, że bot przeniesie klucz, który nie jest możliwy do wykupu, do innego połączonego i zalogowanego na botze, którego brakuje w danej grze (jeśli to możliwe do sprawdzenia). Najczęstszą sytuacją jest przekierowywanie gry `Zakupionej już` do innego bota, któremu brakuje tej konkretnej gry, wariant ten obejmuje również inne scenariusze, Na przykład `DoesNotOwnRequiredApp`, `RateLimited` lub `RestrictedCountry`.

`Dystrybucja` spowoduje, że boty rozprowadzają wszystkie otrzymane klucze między sobą i innymi botami. Oznacza to, że każdy bot otrzyma jeden klucz z partii. Zazwyczaj jest to używane tylko wtedy, gdy realizujesz wiele kluczy dla tej samej gry, i chcesz równomiernie rozdzielić je pomiędzy boty, a nie wymieniać klucze dla różnych gier. Ta funkcja nie ma sensu, jeśli realizujesz tylko jeden klucz w jednej akcji `realizuj` (ponieważ nie ma żadnych dodatkowych kluczy do rozmieszczenia).

`KeepMissingGames` sprawi, że bot pominie `Przekazywanie` kiedy nie możemy być pewni, czy klucz będący przedmiotem transakcji jest w rzeczywistości własnością naszego bota, lub nie. Zasadniczo oznacza to, że `Przekazywanie` będzie stosować **tylko** do `Już zakupione` klucze, zamiast obejmować również inne sprawy, takie jak `DoesNotOwnRequiredApp`, `RateLimited` lub `RestrictedCountry`. Zazwyczaj chcesz użyć tej opcji na koncie głównym, aby upewnić się, że klucze będące na niej nie będą dalej przekazywane, jeśli Twój bot, na przykład, stanie się tymczasowo `RateLimited`. Jak można odgadnąć na podstawie opisu, to pole nie ma absolutnie żadnego efektu, jeśli `Przekierowanie` nie jest włączone.

`AssumeWalletKeyOnBadActivationCode` spowoduje, że klucze `BadActivationCode` będą traktowane jako `CannotRedeemCodeFromClient`, i dlatego też ASF próbuje wymienić je jako klucze portfela. Jest to potrzebne, ponieważ Steam może ogłaszać klucze portfela jako `BadActivationCode` (a nie `CannotRedeemCodeFromClient` tak jak to było w użyciu), w wyniku czego ASF nigdy nie próbuje ich wykupić. Jednakże zalecamy **przeciwko** przy użyciu tej preferencji, ponieważ spowoduje to, że ASF próbuje wykupić każdy niepoprawny klucz jako kod portfela, skutkujące nadmierną ilością (potencjalnie nieważnych) żądań wysłanych do usługi Steam, ze wszystkimi potencjalnymi konsekwencjami. Zamiast tego, zalecamy użycie trybu `ForceAssumeWalletKey` **[`wyprzedaż ^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** podczas świadomego wykupu kluczy portfeli, które włączą wymagane warsztaty tylko wtedy, gdy jest to wymagane, zgodnie z potrzebami.

Włączenie zarówno `Przesyłanie` i `Dystrybucja` doda funkcję dystrybucji do przekazania, co sprawia, że ASF próbuje wykupić jeden klucz na wszystkich botach przed przejściem do następnego (dystrybucja). Zazwyczaj chcesz użyć tej opcji tylko wtedy, gdy chcesz `Przekierowanie`, ale ze zmienionym zachowaniem polegającym na przełączaniu bota na klucz, zamiast zawsze wchodzić w kolejność z każdym kluczem (który byłby `Przesyłanie` samodzielnie). To zachowanie może być korzystne, jeśli wiesz, że większość lub nawet wszystkie klucze są powiązane z tą samą grą, ponieważ w tej sytuacji tylko `Przekaż` spróbowałby, najpierw wykupić wszystko na jednym bocie (co ma sens, jeśli twoje klucze są dla różnych gier), i `Przekazywanie` + `Dystrybucja` przełączy bota na następnym kluczu, "dystrybucja" zadanie realizacji nowego klucza na innego bota niż początkowy (co ma sens, jeśli klucze są dla tej samej gry, pominięcie jednej bezpunktowej próby na klucz).

Rzeczywiste zamówienie botów dla wszystkich scenariuszy wykupu jest alfabetyczne, z wyłączeniem botów, które są niedostępne (nie są połączone, zatrzymane lub podobne). Pamiętaj, że istnieje dzienny limit wykupu dla każdego konta i dla każdego konta, i każde wykupienie próbne, które nie zakończyło się `OK` przyczynia się do nieudanych prób. ASF zrobi wszystko, co w jego mocy, aby zminimalizować liczbę błędów `już zakupionych` , np. starając się uniknąć przekazywania klucza do innego bota, który jest już właścicielem tej gry, ale nie zawsze ma gwarancję pracy ze względu na to, jak Steam obsługuje licencje. Korzystanie z wykupujących flag, takich jak `Przekazywanie` lub `Rozprowadzanie` zawsze zwiększy prawdopodobieństwo trafienia `RateLimited`.

Pamiętaj, że nie możesz przekazywać ani dystrybuować kluczy do botów, do których nie masz dostępu. To powinno być oczywiste, ale upewnij się, że jesteś co najmniej `Operator` wszystkich botów, które chcesz włączyć do procesu wykupu, na przykład z `status ASF` **[polecenie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `Komunikacja zdalna`

`byte flags` type with default value of `3`. Właściwość ta definiuje zachowanie ASF dla bota w odniesieniu do komunikacji ze zdalnymi służbami osób trzecich i jest zdefiniowana jak poniżej:

| Wartość | Nazwa            | Opis                                                                                                                                                                                                                                                         |
| ------- | ---------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| 0       | None             | Brak dozwolonej komunikacji, renderowanie wybranych funkcji ASF jest bezużyteczne                                                                                                                                                                            |
| 1       | Grupa SteamGroup | Pozwala na komunikację z **[grupą Steam ASF](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                   |
| 2       | Publikacja       | Pozwala na komunikację z **[ASF na liście](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** aby być na liście, jeśli użytkownik włączył również `SteamTradeMatcher` w **[`TradingPreferences`](#tradingpreferences)** |

Zauważ, że ta właściwość jest polem `flagi` , dlatego możliwe jest wybranie dowolnej kombinacji dostępnych wartości. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Nie włącza żadnej z flag daje wynik w opcji `Brak`.

Ta opcja nie obejmuje komunikacji z osobami trzecimi oferowanej przez ASF, tylko te, które nie są dorozumiane przez inne ustawienia. Na przykład, jeśli włączyłeś automatyczną aktualizację ASF, ASF będzie komunikować się z GitHub (dla pobierania) i z naszym serwerem (dla weryfikacji sumy kontrolnej), zgodnie z twoją konfiguracją. Podobnie, włączenie `Dopasowanie` w **[`TradingPreferences`](#tradingpreferences)** implikuje komunikację z naszym serwerem, aby pobrać wymienione boty, które są wymagane dla tej funkcji.

Dalsze wyjaśnienia na ten temat są dostępne w sekcji **[zdalna komunikacja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `SendTradePeriod`

`byte` type with default value of `0`. Ta właściwość działa bardzo podobna do preferencji `SendOnFarmingFinished` w `FarmingPreferences`, z jedną różnicą - zamiast wysyłać handel, gdy rolnictwo jest prowadzone, możemy również wysłać je co `SendTradePeriod` godzin, niezależnie od tego, ile musimy opuścić gospodarstwo rolne. This is useful if you want to `loot` your alt accounts on usual basis instead of waiting for it to finish farming. Domyślna wartość `0` wyłącza tę funkcję, jeśli chcesz, aby Twój bot wysłał Ci transakcję. . każdego dnia powinieneś umieścić `24` tutaj.

Zazwyczaj chcesz użyć **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** razem z tą funkcją, chociaż nie jest to wymaganie, jeśli zamierzasz ręcznie obsługiwać potwierdzenia 2FA w odpowiednim czasie. Jeśli nie jesteś pewien, jak ustawić tę właściwość, pozostaw ją z domyślną wartością `0`.

---

### `SteamLogin`

`string` typ z domyślną wartością `null`. Ta właściwość definiuje Twój login Steam - ten który używasz do logowania do Steam. Oprócz zdefiniowania logowania Steam tutaj, możesz również zachować domyślną wartość `null` jeśli chcesz wprowadzić swój login Steam przy każdym uruchomieniu ASF zamiast umieścić go w konfiguracji. To może być przydatne dla Ciebie, jeśli nie chcesz zapisywać poufnych danych w pliku konfiguracyjnym.

---

### `SteamMasterClanID`

`ulong` typ z domyślną wartością `0`. Ta właściwość definiuje SteamID grupy Steam, do której powinien się automatycznie dołączać bot, w tym czat grupowy. Możesz sprawdzić SteamID swojej grupy, przechodząc do jej strony **[](https://steamcommunity.com/groups/archiasf)**, a następnie dodając `/memberslistxml? ml=1` na końcu linku, więc link będzie wyglądał jak **[ten](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. Then you can get steamID of your group from the result, it's in `<groupID64>` tag. W powyższym przykładzie będzie to `103582791440160998`. Oprócz próby dołączenia do danej grupy przy starcie, bot automatycznie zaakceptuje zaproszenia do tej grupy, co umożliwia ręczne zaproszenie bota, jeśli twoja grupa ma prywatne członkostwo. Jeśli nie masz żadnej grupy dedykowanej dla twoich botów, powinieneś zachować tę właściwość z domyślną wartością `0`.

---

### `SteamParentalCode`

`string` typ z domyślną wartością `null`. Ta właściwość definiuje Twój kod rodzicielski pary PIN. ASF wymaga dostępu do zasobów chronionych za pomocą pary rodzicielskiej, dlatego jeśli korzystasz z tej funkcji, należy zapewnić ASF odblokowujący kod PIN dla rodziców, aby mógł on działać normalnie. Domyślna wartość `null` oznacza, że nie ma kodu PIN rodzicielskiego do odblokowania tego konta, i to prawdopodobnie jest to, co chcesz, jeśli nie używasz funkcji rodzicielskich z parą wodną.

W ograniczonych okolicznościach ASF jest również w stanie wygenerować poprawny kod rodzicielski Steam, choć wymaga to zbyt dużej ilości zasobów systemu operacyjnego i dodatkowego czasu na dokończenie, nie wspominając, że nie ma gwarancji powodzenia, dlatego zalecamy nie polegać na tej funkcji i zamiast tego umieść ważne `SteamParentalCode` w konfiguracji do użycia ASF. Jeśli ASF ustali, że kod PIN jest wymagany, a nie będzie w stanie wygenerować kodu samodzielnie, poprosi Cię o wprowadzenie.

---

### `Hasło Steam`

`string` typ z domyślną wartością `null`. Ta właściwość definiuje Twoje hasło Steam - które używasz do logowania do Steam. Oprócz zdefiniowania hasła Steam tutaj, możesz również zachować domyślną wartość `null` jeśli chcesz wprowadzić hasło steam przy każdym uruchomieniu ASF zamiast umieścić je w konfiguracji. To może być przydatne dla Ciebie, jeśli nie chcesz zapisywać poufnych danych w pliku konfiguracyjnym.

---

### `SteamTradeToken`

`string` typ z domyślną wartością `null`. Gdy masz bota na liście znajomych, bota może wysłać do Ciebie transakcję bez obaw o token handlowy, dlatego możesz pozostawić tę właściwość domyślną `null`. Jeśli jednak zdecydujesz się NIE mieć swojego bota na liście znajomych, wtedy będziesz musiał wygenerować i wypełnić token transakcyjny jako użytkownik, do którego bot oczekuje wysyłać transakcje. Innymi słowy, ta właściwość powinna być wypełniona tokenem transakcyjnym konta, który jest zdefiniowany za pomocą uprawnień `Master` w `SteamUserPermissions` of **this** bot instance.

Aby znaleźć swój token, jako zalogowany użytkownik z uprawnieniami `Mistrz` , Nawiguj **[tutaj](https://steamcommunity.com/my/tradeoffers/privacy)** i zajrzyj do swojego adresu URL. Token, którego szukamy, jest wykonany z 8 znaków po `&token=` część adresu URL. Powinieneś skopiować i umieścić 8 znaków tutaj, jako `SteamTradeToken`. Nie uwzględniaj całego adresu URL, ani `&token=` , tylko sam token (8 znaków).

---

### `SteamUserPermissions`

`Niezmienny słownik<ulong, byte>` typ z domyślną wartością bycia pustym. Ta właściwość jest właściwością słownika, która mapuje danego użytkownika Steam zidentyfikowanego za pomocą 64-bitowego identyfikatora Steam ID, do `bajtu` , który określa jego uprawnienia w instancji ASF. Obecnie dostępne uprawnienia bota w ASF są zdefiniowane jako:

| Wartość | Nazwa         | Opis                                                                                                                                                                                                                                                        |
| ------- | ------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0       | None          | Brak specjalnych uprawnień, jest to głównie wartość odniesienia, która jest przypisana do brakujących identyfikatorów Steam w tym słowniku - nie ma potrzeby definiowania nikogo z tym uprawnieniem                                                         |
| 1       | FamilySharing | Zapewnia minimalny dostęp dla użytkowników współdzielonej rodziny. Po raz kolejny jest to głównie wartość referencyjna, ponieważ ASF jest w stanie automatycznie odkrywać identyfikatory pary, na które zezwoliliśmy w celu korzystania z naszej biblioteki |
| 2       | Operator      | Zapewnia podstawowy dostęp do danych instancji botów, głównie dodawania licencji i wykupywania kluczy                                                                                                                                                       |
| 3       | Master        | Zapewnia pełny dostęp do danej instancji bota                                                                                                                                                                                                               |

Krótko mówiąc, ta właściwość pozwala ci na obsługę uprawnień dla podanych użytkowników. Uprawnienia są ważne głównie dla dostępu do poleceń ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, ale także dla umożliwienia wielu funkcji ASF, takich jak akceptowanie transakcji. Na przykład możesz ustawić własne konto jako `Mistrz`, i daj `Operator` dostęp do 2-3 znajomych, aby mogli łatwo wykupić klucze dla Twojego bota z ASF, podczas gdy **nie** kwalifikuje się . . aby go zatrzymać. Dzięki temu możesz z łatwością przypisać uprawnienia do określonych użytkowników i pozwolić im używać bota do określonego przez Ciebie stopnia.

Zalecamy ustawienie dokładnie jednego użytkownika jako `Mistrz`i każdej kwoty, którą chcesz jako `Operatorzy` i poniżej. While it's technically possible to set multiple `Masters` and ASF will work correctly with them, for example by accepting all of their trades sent to the bot, ASF will use only one of them (with lowest steam ID) for every action that requires a single target, for example a `loot` request, so also properties like `SendOnFarmingFinished` preference in `FarmingPreferences` or `SendTradePeriod`. Jeśli doskonale rozumiecie te ograniczenia, zwłaszcza fakt, że żądanie „ `loot` zawsze będzie wysyłać przedmioty do „Mistrza `` o najniższym ID parowym, niezależnie od `Mistrza` , który faktycznie wykonał polecenie, wtedy możesz zdefiniować wielu użytkowników z uprawnieniami `Mistrz` tutaj, ale nadal zalecamy pojedynczy schemat główny.

Miło jest zauważyć, że jest jeszcze jedno dodatkowe zezwolenie `Właściciel` , które jest zadeklarowane jako `SteamOwnerID` globalna właściwość konfiguracji. Nie możesz przypisać uprawnienia `Właściciel` do nikogo tutaj, jako `SteamUserPermissions` definiuje tylko uprawnienia związane z instancją bota, a nie ASF jako proces. Dla zadań związanych z botami `SteamOwnerID` jest traktowany tak samo jak `Mistrz`, więc zdefiniowanie `OwnerID` tutaj nie jest konieczne.

---

### `Okres TradeCheckPeriod`

`byte` type with default value of `60`. Zwykle ASF obsługuje przychodzące oferty handlowe zaraz po otrzymaniu powiadomienia o jednym, ale czasami ze względu na Steam nie może to zrobić w tym momencie, i takie oferty handlowe pozostają ignorowane do czasu następnego powiadomienia o transakcji lub ponownego uruchomienia bota, które mogą prowadzić do anulowania transakcji lub niedostępności przedmiotów w tym późniejszym czasie. Jeśli ten parametr jest ustawiony na wartość niezerową, ASF będzie dodatkowo sprawdzać dla takich zaległych transakcji co `TradeCheckPeriod` minut. Domyślna wartość jest wybierana z równowagą pomiędzy dodatkowymi żądaniami do serwerów Steam i utratą transakcji przychodzących. Jeśli jednak używasz ASF na kartach rolnych i nie planujesz automatycznie przetwarzać żadnych transakcji przychodzących, możesz ustawić go na `0` , aby całkowicie wyłączyć tę funkcję. Z drugiej strony jeśli Twój bot uczestniczy w publicznej liście [ASF STM](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) lub świadczy inne zautomatyzowane usługi jako bot, możesz zmniejszyć ten parametr do `15` minut, aby terminowo przetworzyć wszystkie transakcje.

---

### `TradingPreferences`

`byte flags` type with default value of `0`. Ta właściwość definiuje zachowanie ASF podczas handlu i jest zdefiniowana jak poniżej:

| Wartość | Nazwa               | Opis                                                                                                                                                                                                                                   |
| ------- | ------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0       | None                | Brak specjalnych preferencji handlowych, domyślnie                                                                                                                                                                                     |
| 1       | AcceptDonations     | Akceptuje transakcje, w których nic nie tracimy                                                                                                                                                                                        |
| 2       | SteamTradeMatcher   | Uczestniczy w **[STM](https://www.steamtradematcher.com)**- podobnych transakcji. Odwiedź **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** po więcej informacji                            |
| 4       | MatchEverything     | Wymaga, aby `SteamTradeMatcher` był ustawiony i w połączeniu z nim akceptuje również złe transakcje oprócz dobrych i neutralnych transakcji                                                                                            |
| 8       | DontAcceptBotTrades | Doesn't automatically accept `loot` trades from other bot instances                                                                                                                                                                    |
| 16      | MatchActively       | Aktywnie uczestniczy w **[STM](https://www.steamtradematcher.com)**- podobnych transakcji. Odwiedź **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** po więcej informacji |

Zauważ, że ta właściwość jest polem `flagi` , dlatego możliwe jest wybranie dowolnej kombinacji dostępnych wartości. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Nie włącza żadnej z flag daje wynik w opcji `Brak`.

Aby uzyskać dalsze wyjaśnienia dotyczące logiki handlu ASF i opisu każdej dostępnej flagi, odwiedź sekcję **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**.

---

### `TransferableTypes`

`ImmutableHashSet<byte>` typ z domyślną wartością `1, 3, 5` elementów pary. Ta właściwość definiuje, które typy przedmiotów Steam będą brane pod uwagę przy przenoszeniu pomiędzy botami, podczas `transfer` **[polecenie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. ASF zapewni, że w ofercie handlowej uwzględnione zostaną tylko przedmioty z `TransferableTypes` , dlatego ta właściwość pozwala wybrać to, co chcesz otrzymać w ofercie handlowej, która jest wysyłana do jednego z twoich botów.

| Wartość | Nazwa                 | Opis                                                                    |
| ------- | --------------------- | ----------------------------------------------------------------------- |
| 0       | Unknown               | Każdy typ, który nie pasuje do żadnego z poniższych                     |
| 1       | BoosterPack           | Pakiet Booster zawierający 3 losowe karty z gry                         |
| 2       | Emoticon              | Emotikona do użycia na Czacie Steam                                     |
| 3       | FoilTradingCard       | Wariant foliowy `TradingCard`                                           |
| 4       | ProfileBackground     | Tło profilu do użycia na Twoim profilu Steam                            |
| 5       | TradingCard           | Karta handlowa z parą wodną, używana do tworzenia odznak (niefoliowych) |
| 6       | SteamGems             | Klejnoty parowe używane do wytwarzania pobudzarek, w tym worki          |
| 7       | SaleItem              | Specjalne przedmioty przyznane podczas sprzedaży Steam                  |
| 8       | Consumable            | Specjalne przedmioty zużywalne, które znikają po użyciu                 |
| 9       | ProfileModifier       | Specjalne przedmioty, które mogą modyfikować wygląd profilu Steam       |
| 10      | Sticker               | Specjalne przedmioty, które mogą być użyte na czacie Steam              |
| 11      | ChatEffect            | Specjalne przedmioty, które mogą być użyte na czacie Steam              |
| 12      | MiniProfileBackground | Specjalne tło dla profilu Steam                                         |
| 13      | AvatarProfileFrame    | Specjalna ramka awatara dla profilu Steam                               |
| 14      | AnimatedAvatar        | Specjalny animowany awatar dla profilu Steam                            |
| 15      | Skórka klawiatury     | Specjalna skórka klawiatury dla talii Steam                             |
| 16      | Uruchamianie wideo    | Specjalny film startowy dla talii Steam                                 |

Pamiętaj, że niezależnie od powyższych ustawień, ASF zapyta tylko o **[elementy społeczności Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` z 753, `contextID` z 6), więc wszystkie przedmioty gry, prezenty i podobne, są z definicji wyłączone z oferty handlowej.

Domyślne ustawienie ASF opiera się na najczęstszym użyciu bota, z przenoszeniem tylko pakietów wzmacniających oraz kart handlowych (w tym folii). Zdefiniowana tutaj właściwość pozwala na zmianę tego zachowania w jakikolwiek sposób, który Cię satysfakcjonuje. Pamiętaj, że wszystkie typy nie zdefiniowane powyżej będą wyświetlane jako `Nieznany typ` , co jest szczególnie ważne, gdy zawór uwalnia trochę nowego elementu Steam, który zostanie oznaczony jako `Unknown` również przez ASF, dopóki nie zostanie dodany tutaj (w przyszłej wersji). Dlatego na ogół nie zaleca się umieszczania `Unknown` type in your `TransferableTypes`, chyba że wiesz, co robisz, i rozumiesz również, że ASF wyśle cały twój ekwipunek w ofercie handlowej, jeśli Steam Network zostanie ponownie zniszczony i zgłosi wszystkie Twoje przedmioty jako `Nieznane`. Moja silna sugestia nie zawiera `Unknown` type in the `TransferableTypes`, nawet jeśli chcesz przenieść wszystko.

---

### `UseLoginKeys`

`bool` typ z domyślną wartością `true`. Ta właściwość określa, czy ASF powinien używać mechanizmu kluczy logowania dla tego konta Steam. Mechanizm kluczy logowania działa bardzo podobnie jak opcja "zapamiętaj mnie" oficjalnego klienta Steam, co umożliwia ASF przechowywanie i używanie tymczasowego jednorazowego klucza logowania do następnej próby logowania, skutecznie pomijając potrzebę podania hasła, Steam Guard lub kodu 2FA, o ile nasz klucz logowania jest prawidłowy. Klucz logowania jest przechowywany w pliku `BotName.db` i aktualizowany automatycznie. Dlatego nie musisz podawać hasła/kodu SteamGuard/2FA po zalogowaniu się pomyślnie za pomocą ASF tylko raz.

Klucze logowania są domyślnie używane dla Twojej wygody, więc nie musisz wprowadzać `SteamPassword`, Kod SteamGuard lub 2FA (jeśli nie używasz **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**) przy każdym logowaniu. Jest to również lepsza alternatywa, ponieważ klucz logowania może być używany tylko jednorazowo i w żaden sposób nie ujawnia Twojego oryginalnego hasła. Dokładnie ta sama metoda jest używana przez Twojego oryginalnego klienta Steam, który zapisuje nazwę konta i klucz logowania do następnej próby logowania, tak samo jak w `SteamLogin` z `UseLoginKeys` i puste `SteamPassword` w ASF.

Niektórzy mogą być jednak zaniepokojeni nawet tym mało szczegółowym, dlatego ta opcja jest dostępna dla Ciebie, jeśli chcesz upewnić się, że ASF nie przechowuje żadnego tokenu, który pozwoliłby na wznowienie poprzedniej sesji po jej zamknięciu, co spowoduje obowiązkowe pełne uwierzytelnianie przy każdej próbie logowania. Wyłączenie tej opcji będzie działać dokładnie tak samo, jak nie sprawdzaj "zapamiętaj mnie" w oficjalnym kliencie Steam. Jeśli nie wiesz, co robisz, powinieneś zachować domyślną wartość `true`.

---

### `Tryb interfejsu użytkownika`

`byte` type with default value of `0`. Ta właściwość określa tryb interfejsu użytkownika, który zostanie ogłoszony z botem po zalogowaniu się do sieci Steam. Może to mieć wpływ na widoczność konta, np. na czacie Steam, jeśli Twoja obecność pozwala na to przez `OnlineStatus`. Obecnie możesz wybrać jeden z poniższych trybów:

| Wartość | Nazwa      | Opis                            |
| ------- | ---------- | ------------------------------- |
| `0`     | VGUI       | Domyślny tryb klienta Steam     |
| `1`     | Tenfoot    | Tryb dużych zdjęć               |
| `2`     | Komórka    | Aplikacja mobilna Steam         |
| `3`     | Web        | Sesja przeglądarki internetowej |
| `5`     | MobileChat | Aplikacja czatu mobilnego Steam |

Podstawowy typ `EUIMode` polega na tym, że ta właściwość jest oparta na bardziej dostępnych wartościach, jednakże zgodnie z naszą najlepszą wiedzą, od dziś nie przynoszą one żadnych efektów, dlatego zostały one wycięte ze względu na widoczność. Możesz także być zainteresowany sprawdzeniem `GamingDeviceType`, ponieważ są tam włączone dodatkowe funkcje.

Jeśli nie jesteś pewien, jak ustawić tę właściwość, pozostaw ją z domyślną wartością `0`.

---

### `WebProxy`

`string` typ z domyślną wartością `null`. Ta właściwość definiuje adres serwera proxy, który będzie używany do wewnętrznej komunikacji wewnętrznej dla botów httprelated communication, zwłaszcza do usług takich jak `api. teampowered.com`, `steamcommunity.com` i `store.steampowered.com`. Jeśli nie jest ustawiony, ASF użyje globalnego ustawienia `WebProxy` określonego powyżej. Przesyłanie żądań ASF mogłoby być wyjątkowo użyteczne dla ominięcia różnego rodzaju zapory, zwłaszcza wielkich zapory ogniowej w Chinach.

Ta właściwość jest zdefiniowana jako ciąg uri:

> Ciąg URI składa się ze schematu (wspierany: http/https/socks4/socks4a/socks5), hosta i opcjonalnego portu. Przykładem kompletnego ciągu uri jest `"http://contoso.com:8080"`.

Jeśli serwer proxy wymaga uwierzytelniania użytkownika, musisz również skonfigurować `WebProxyUsername` i/lub `WebProxyPassword`. Jeżeli nie ma takiej potrzeby, wystarczy samo założenie tego majątku.

Jeśli potrzebujesz proxy wewnętrznej komunikacji z siecią Steam (CM), wtedy powinieneś skonfigurować **[`SteamProtocols`](#steamprotocols)** właściwości bota do wartości, która pozwala tylko na transport websocket. i. . wartość `4`, ponieważ tylko websockets są obsługiwane dla proxying.

Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `WebProxyPassword`

`string` typ z domyślną wartością `null`. Ta właściwość definiuje pole hasła używane w podstawie, skrócie, NTLM, i uwierzytelnianie Kerberos obsługiwane przez docelową maszynę `WebProxy` zapewniającą funkcję proxy. Jeśli serwer proxy nie wymaga danych logowania użytkownika, nie ma potrzeby wprowadzania cokolwiek tutaj. Użycie tej opcji ma sens tylko wtedy, gdy `WebProxy` jest również używane, ponieważ w przeciwnym razie nie ma żadnego efektu.

Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

### `WebProxyUsername`

`string` typ z domyślną wartością `null`. Ta właściwość definiuje pole nazwy użytkownika używane w podstawie, skrócie, NTLM, i uwierzytelnianie Kerberos obsługiwane przez docelową maszynę `WebProxy` zapewniającą funkcję proxy. Jeśli serwer proxy nie wymaga danych logowania użytkownika, nie ma potrzeby wprowadzania cokolwiek tutaj. Użycie tej opcji ma sens tylko wtedy, gdy `WebProxy` jest również używane, ponieważ w przeciwnym razie nie ma żadnego efektu.

Jeśli nie masz powodu do edycji tej właściwości, powinieneś zachować ją domyślnie.

---

## Struktura pliku

ASF używa dość prostej struktury plików.

```text
<unk> <unk> <unk> <unk> 📁 config
<unk> <unk> <unk> <unk> <unk> ASF. syn
<unk> <unk> <unk> <unk> <unk> ASF.db
<unk> <unk> <unk> Bot1. syn
<unk> <unk> <unk> <unk> <unk> <unk> Bot1.db
<unk> <unk> <unk> <unk> <unk> Bot2. syn
<unk> <unk> <unk> <unk> <unk> Bot2.db
<unk> <unk> <unk> <unk> <unk> ...
├── ArchiSteamFarm.dll
├── log.txt
└── ...
```

Aby przenieść ASF do nowej lokalizacji, na przykład do innego komputera, wystarczy przenieść / skopiować `config` , sam katalog i to jest zalecany sposób wykonywania dowolnej formy „kopii zapasowych ASF”, ponieważ zawsze możesz pobrać pozostałą część (program) z GitHub, nie ryzykując uszkodzonych wewnętrznych plików ASF. . poprzez wadliwą kopię zapasową.

Plik `log.txt` zawiera dziennik wygenerowany przez twoje ostatnie uruchomienie ASF. Ten plik nie zawiera żadnych poufnych informacji i jest niezwykle przydatny w przypadku problemów, awaria lub po prostu informacja o tym, co się stało w ostatnim uruchomieniu ASF. Bardzo często zadajemy pytanie o ten plik w przypadku problemów lub błędów. ASF automatycznie zarządza tym plikiem dla Ciebie, ale możesz dalej dostosowywać ASF **[rejestrowanie modułu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging)** jeśli jesteś zaawansowanym użytkownikiem.

Katalog `config` jest miejscem, które posiada konfigurację ASF, w tym wszystkie jego boty.

`ASF.json` jest globalnym plikiem konfiguracyjnym ASF. Ta konfiguracja jest używana do określenia, jak ASF zachowuje się jako proces, który wpływa na wszystkie boty i sam program. Tutaj znajdziesz globalne właściwości, takie jak właściciel procesu ASF, auto-aktualizacje lub debugowanie.

`BotName.json` jest konfiguracją danej instancji bota. Ta konfiguracja jest używana do określenia sposobu zachowania danej instancji bota, dlatego te ustawienia są specyficzne tylko dla tego bota i nie są współdzielone dla innych. Pozwala to skonfigurować boty z różnymi ustawieniami i niekoniecznie wszystkie z nich działają dokładnie w ten sam sposób. Każdy bot jest nazwany za pomocą unikalnego identyfikatora, wybranego przez Ciebie zamiast `BotName`.

Oprócz plików konfiguracyjnych, ASF używa również katalogu `config` do przechowywania baz danych.

`ASF.db` jest globalnym plikiem bazy danych ASF. Działa on jako globalne trwałe przechowywanie i jest wykorzystywany do zapisywania różnych informacji związanych z procesem ASF, takich jak IP lokalnych serwerów Steam. **Nie powinieneś edytować tego pliku**.

`BotName.db` jest bazą danych danej instancji bota. Ten plik jest używany do przechowywania kluczowych danych o danej instancji bota w pamięci trwałej, takich jak klucze logowania lub ASF 2FA. **Nie powinieneś edytować tego pliku**.

`BotName.keys` jest specjalnym plikiem, który może być użyty do importowania kluczy do **[w grach w tle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. Nie jest to obowiązkowe i nie jest generowane, ale rozpoznawane przez ASF. Ten plik jest automatycznie usuwany po pomyślnym zaimportowaniu kluczy.

`BotName.maFile` jest specjalnym plikiem, który może być użyty do importowania **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**. To nie jest obowiązkowe i nie jest generowane, ale rozpoznawane przez ASF, jeśli `BotName` nie używa jeszcze ASF 2FA. Ten plik jest automatycznie usuwany po pomyślnym zaimportowaniu ASF 2FA.

---

## Mapowanie JSON

Każda właściwość konfiguracji ma swój typ. Typ właściwości definiuje wartości, które są dla niej ważne. Możesz używać tylko wartości, które są ważne dla danego typu - jeśli używasz nieprawidłowej wartości, wtedy ASF nie będzie w stanie przetworzyć twojej konfiguracji.

**Zdecydowanie zalecamy użycie ConfigGenerator do generowania konfiguracji** - obsługuje większość rzeczy niskiego poziomu (takich jak sprawdzanie typów) dla Ciebie, więc musisz tylko wprowadzić właściwe wartości, a także nie musisz rozumieć podanych poniżej typów zmiennych. Ta sekcja dotyczy głównie ludzi generujących/edycji konfiguracji ręcznie, więc oni wiedzą, jakie wartości mogą użyć.

Typy używane przez ASF to natywne typy C# określone poniżej:

---

`bool` - typ logiczny akceptujący tylko wartości `true` i `false`.

Przykład: `"Enabled": true`

---

`byte` - Unsigned byte type, accepting only integers from `0` to `255` (inclusive).

Przykład: `"ConnectionTimeout": 90`

---

`ushort` - Niepodpisany krótki typ, akceptujący tylko liczby całkowite od `0` do `65535` (włącznie).

Przykład: `"WebLimiterDelay": 300`

---

`uint` - Niepodpisany typ liczby całkowitej, akceptując tylko liczby całkowite od `0` do `4294967295` (włącznie).

---

`ulong` - Niepodpisany typ liczby całkowitej, akceptując tylko liczby całkowite od `0` do `18446744073709551615` (włącznie).

Przykład: `"SteamMasterClanID": 103582791440160998`

---

`ciąg` - typ ciągu, akceptacja dowolnej sekwencji znaków, w tym pusta sekwencja `""` i `null`. Pusta sekwencja i wartość `null` są traktowane tak samo przez ASF, więc to zależy od Twojej preferencji, której chcesz użyć (trzymamy się z `null`).

Przykłady: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MyAccountName"`

---

`Guid?` - Nullable UUID type w JSON zakodowany jako ciąg znaków. UUID składa się z 32 znaków szesnastkowych, w zakresie od `0` do `9` i `a` do `f`. ASF akceptuje różnorodność ważnych formatów - małych liter, dużych liter, z myślnikami i bez nich. Oprócz poprawnego UUID, ponieważ ta właściwość jest niepoprawna, dopuszczona jest specjalna wartość `null` wskazująca brak UUID do dostarczenia.

Przykłady: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableList<valueType>` - Niezmienna kolekcja (lista) wartości w danym `valueType`. W JSON, jest zdefiniowany jako tablica elementów w danym `valueType`. ASF używa `List` do wskazania, że dana właściwość obsługuje wiele wartości i że ich kolejność może być istotna.

Przykład dla `ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` - Niezmienna kolekcja (zespół) unikalnych wartości w `valueType`. W JSON, jest zdefiniowany jako tablica elementów w danym `valueType`. ASF używa `HashSet` do wskazania, że dana właściwość ma sens tylko dla unikalnych wartości i że ich kolejność nie ma znaczenia, dlatego celowo zignoruje wszelkie potencjalne duplikaty podczas analizowania (jeśli mimo to zdarzyło się je dostarczyć).

Przykład dla `ImmutableHashSet<uint>`: `"Blacklist": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>` - Niezmienny słownik (mapa), który mapuje unikalny klucz określony w jego `keyType`, do wartości określonej w `valueType`. W JSON jest zdefiniowany jako obiekt z kluczowymi parami. Pamiętaj, że `keyType` jest zawsze cytowany w tym przypadku, nawet jeśli jest to typ wartości taki jak `ulong`. Istnieje również ścisły wymóg, aby klucz był unikalny na mapie, tym razem egzekwowany również przez JSON.

Przykład dla `ImmutableDictionary<ulong, byte>`: `"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`

---

`flags` - Atrybut Flagi łączy kilka różnych właściwości w jedną wartość końcową poprzez zastosowanie operacji bitwise Pozwala to wybrać jednocześnie dowolną kombinację różnych dozwolonych wartości. Wartość końcowa jest konstruowana jako suma wartości wszystkich dostępnych opcji.

Na przykład podano następującą definicję:

| Wartość | Nazwa |
| ------- | ----- |
| 0       | None  |
| 1       | A     |
| 2       | B     |
| 4       | C     |

There are exactly 3 meaningful, available flags to switch on/off (`A`, `B`, `C`), and therefore `8` possible valid combinations overall:

| Wartość końcowa | Włączone flagi  |
| --------------- | --------------- |
| 0               | `None`          |
| 1               | `A`             |
| 2               | `B`             |
| 3               | `A` + `B`       |
| 4               | `C`             |
| 5               | `A` + `C`       |
| 6               | `B` + `C`       |
| 7               | `A` + `B` + `C` |

Z definicji, w celu umożliwienia wprowadzenia powyższego, każda samodzielna flaga musi być zatem potęgą dwóch. Dlatego też dodatkowa flaga w powyższym przykładzie, `D`musiałaby mieć wartość `8` lub większą.

Zazwyczaj narzędzia graficzne wykonają dla Ciebie obliczenie. Jeśli edytujesz konfiguracje ręcznie, możesz zawsze użyć kalkulatora i po prostu dodać razem podstawowe wartości wszystkich flag, które chcesz włączyć - jak na przykład powyżej.

Przykład: `"SteamProtocols": 7` (który umożliwia flagi o wartości `1`, `2` i `4`, jak wyjaśniono powyżej)

---

## Mapowanie zgodności

Ze względu na ograniczenia JavaScript uniemożliwiające poprawne serializowanie prostych pól `ulong` w JSON podczas używania konfiguratora konfiguracyjnego web, `ulong` pola będą renderowane jako ciągi z prefiksem `s_` w powstałej konfiguracji. Obejmuje to na przykład `"SteamOwnerID": 76561198006963719` , który zostanie napisany przez nasz ConfigGenerator jako `"s_SteamOwnerID": "76561198006963719"`. ASF zawiera właściwą logikę do automatycznego mapowania tego ciągu, więc wpisy `s_` w konfiguracjach są poprawne i poprawnie wygenerowane. Jeśli sam generujesz konfiguracje, zalecamy trzymanie się oryginalnych pól `ulong` jeśli to możliwe, ale jeśli nie możesz tego zrobić, możesz również śledzić ten schemat i zakodować go jako ciąg znaków z prefiksem `s_` dodanym do ich nazw. Mamy nadzieję, że ostatecznie rozwiążemy to ograniczenie JavaScript.

---

## Zgodność konfiguracji

Najwyższym priorytetem dla ASF jest pozostawanie kompatybilne ze starszymi konfiguracjami. As you should already know, missing config properties are treated the same as they would be defined with their **default values**. Therefore, if new config property gets introduced in new version of ASF, all your configs will remain **compatible** with new version, and ASF will treat that new config property as it'd be defined with its **default value**. Zawsze możesz dodawać, usuwać lub edytować właściwości konfiguracyjne zgodnie ze swoimi potrzebami.

Zalecamy ograniczenie zdefiniowanych właściwości konfiguracyjnych tylko do tych, które chcesz zmienić. ponieważ w ten sposób automatycznie dziedziczysz domyślne wartości dla wszystkich innych, nie tylko zachowywanie konfiguracji w czystości, ale także zwiększanie kompatybilności w przypadku, gdy zdecydujemy się na zmianę wartości domyślnej dla właściwości, której nie chcesz jednoznacznie ustawić (e. . `WebLimiterDelay`).

W związku z powyższym ASF automatycznie migruje/zoptymalizuje Twoje konfiguracje poprzez ich przeformatowanie i usuwanie pól, które utrzymują domyślną wartość. Możesz wyłączyć to zachowanie za pomocą `--no-config-migrate` **[argument linii poleceń](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** jeśli masz określony powód, na przykład udostępniasz pliki konfiguracyjne tylko do odczytu i nie chcesz, aby ASF je modyfikował.

---

## Automatyczne przeładowanie

ASF jest świadomy, że konfiguracje są modyfikowane w trybie "on-fly" - dzięki temu ASF automatycznie będzie:
- Utwórz (i start, w razie potrzeby) nową instancję bota, gdy utworzysz jego konfigurację
- Zatrzymaj (w razie potrzeby) i usuń starą instancję bota, po usunięciu konfiguracji
- Zatrzymaj (i start, w razie potrzeby) dowolną instancję bota, podczas edycji konfiguracji
- Uruchom ponownie (w razie potrzeby) bota pod nową nazwą, gdy zmienisz nazwę jego konfiguracji

Wszystkie powyższe elementy są przezroczyste i zostaną wykonane automatycznie bez potrzeby ponownego uruchomienia programu lub zabijania innych (bezstycznych) instancji botów.

Ponadto ASF uruchomi się ponownie (jeśli `AutoRestart` zezwoli na modyfikację) jeśli zmodyfikujesz konfigurację ASF `ASF.json`. Podobnie program zakończy się, jeśli usuniesz program lub zmienisz jego nazwę.

Możesz wyłączyć to zachowanie z `--no-config-watch` **[argument linii poleceń](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** jeśli masz określony powód, na przykład nie chcesz, aby ASF reagował na zmiany w pliku w folderze `config`.