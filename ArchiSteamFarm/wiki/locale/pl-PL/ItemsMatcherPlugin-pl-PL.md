# ItemsMatcherPlugin

`ItemsMatcherPlugin` jest oficjalną wtyczką ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** , która rozszerza ASF o funkcje listy ASF STM. W szczególności Obejmuje to `PublicListing` w **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** i `MechActive` w **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. ASF jest z `ItemsMatcherPlugin` połączony z wydaniem, dlatego jest gotowy do użycia.

---

## `Publikacja`

Publiczna lista, jak sugeruje nazwa, jest listą aktualnie dostępnych botów ASF STM. Znajduje się na **[naszej stronie](https://asf.justarchi.net/STM)**, zarządzane automatycznie i wykorzystywane jako usługi publiczne zarówno dla użytkowników ASF, którzy korzystają z `MechActive`, oraz użytkowników ASF i innych niż ASF do ręcznego dopasowywania.

Aby być na liście, masz zestaw wymagań do spełnienia. Musi być co najmniej dozwolone `PublicListing` w `RemoteCommunication` (ustawienie domyślne), `SteamTradeMatcher` włączone w serwisie `TradingPreferences`, **[Publiczny inwentarz](https://steamcommunity.com/my/edit/settings)** ustawienia prywatności, a konto **[nieograniczone](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** i **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** aktywne. Dodatkowe wymogi obejmują 2FA aktywne od co najmniej 15 dni, ostatnia zmiana hasła ponad 5 dni temu, brak jakichkolwiek ograniczeń na rachunkach, takich jak blokady, zakazy ekonomiczne i zakazy handlu. Oczywiście musisz mieć co najmniej jeden (tradable) przedmiot w swoim ekwipunku z określonego `MatchableTypes`, na przykład karty handlowe. Ponadto boty o więcej niż `500000` nie są akceptowane z powodu nadmiernych kosztów ogólnych, w tym przypadku zalecamy podzielenie twojego ekwipunku na kilka kont.

Gdy `PublicListing` jest domyślnie włączony, należy pamiętać, że **nie** będzie wyświetlany na stronie internetowej, jeśli nie spełniasz wszystkich wymagań, zwłaszcza `SteamTradeMatcher`, który nie jest domyślnie włączony. Dla osób, które nie spełniają kryteriów, nawet jeśli `PublicListing` jest włączony, ASF w żaden sposób nie komunikuje się z serwerem. Publiczna lista jest również kompatybilna tylko z najnowszą stabilną wersją ASF i może odmówić wyświetlania przestarzałych botów, zwłaszcza jeśli brakuje im podstawowych funkcji, które można znaleźć tylko w nowszych wersjach.

### Jak to działa

ASF wysyła wstępne dane raz po zalogowaniu, które zawierają wszystkie właściwości publiczne aukcje, z których korzysta. Następnie, co 10 minut ASF wysyła jedną, bardzo małą prośbę o "bicie serca", która powiadomi nasz serwer, że bot jest nadal uruchomiony i działa. Jeśli z jakiegoś powodu bicie serca nie dotarło, na przykład z powodu problemów związanych z tworzeniem sieci kontaktów. wtedy ASF będzie ponawiać wysyłanie go co minutę, dopóki serwer nie zarejestruje go. W ten sposób nasz serwer wie dokładnie, które boty są nadal uruchomione i gotowe do akceptowania ofert handlowych. ASF wyśle również wstępne ogłoszenie w miarę potrzeb, na przykład jeśli wykryje, że nasz ekwipunek uległ zmianie od poprzedniego.

Wyświetlamy wszystkie kwalifikujące się konta ASF, które były aktywne w **ostatnich 15 minut**. Users are sorted according to their relative usefulness - `MatchEverything` bots which are shown with `Any` banner that accept all 1:1 trades, then unique games count, and finally items count.

### API

Lista ASF STM akceptuje tylko boty ASF na razie Na razie nie ma możliwości wyświetlania botów firm trzecich na naszej liście, ponieważ nie możemy łatwo przejrzeć ich kodu i upewnić się, że spełniają one całą naszą logikę handlową. Udział w liście wymaga więc najnowszej stabilnej wersji ASF, chociaż może działać z niestandardowymi wtyczkami **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

For consumers of the listing, we have a very simple **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** endpoint that you can use. Zawiera ono wszystkie dane, które posiadamy, oprócz inwentarza użytkowników, które są częścią `Dopasowywnie` tylko funkcje.

### Polityka prywatności

Jeśli zgadzasz się na umieszczanie się na naszej liście, poprzez włączenie `SteamTradeMatcher` i nie odrzucenie `PublicListing`, jak określono powyżej, tymczasowo przechowujemy niektóre dane Twojego konta Steam na naszym serwerze w celu zapewnienia oczekiwanej funkcjonalności.

Informacje publiczne (udostępniane przez Steam każdej zainteresowanej stronie) zawierają:
- Twój identyfikator Steam (w 64-bitowej formie do generowania linków)
- Twój pseudonim (do celów wyświetlacza)
- Twój awatar (hash, do celów wyświetlacza)

Warunkowo publiczne informacje (udostępniane przez Steam każdej zainteresowanej stronie, jeśli spełniasz wymagania dotyczące listy) obejmują:
- Twój **[ekwipunek](https://steamcommunity.com/my/inventory/#753_6)** (aby ludzie mogli użyć `<code> Dopasować` do Twoich przedmiotów).

Prywatne informacje (wybrane dane wymagane do zapewnienia funkcjonalności) obejmują:
- Your **[trading token](https://steamcommunity.com/my/tradeoffers/privacy)** (so people outside of your friendlist can send you trades)
- Twoje ustawienie `Dopasowalne Typy` (dla celów wyświetlania i dopasowywania)
- Twoje ustawienie `MatchEverything` (dla celów wyświetlania i dopasowania)
- Twoje ustawienie `MaxTradeHoldDuration` (aby inni ludzie wiedzieli, czy chcesz zaakceptować swoje transakcje)

Od chwili, gdy przestaniesz używać (ogłaszać) naszej listy, Twoje dane stają się niedostępne dla ogółu społeczeństwa w ciągu maksymalnie 15 minut, i jest w przeciwnym razie trzymany na naszym serwerze maksymalnie przez dwa tygodnie - wszystko jest automatycznie usuwane po tym okresie. Żadna akcja nie jest wymagana, aby tak się stało.

---

## `MatchActively`

`MatchActive` to aktywna wersja **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** włącznie z interaktywnym dopasowaniem, w którym bot wyśle transakcje innym osobom. Może działać samodzielnie, lub razem z ustawieniami `SteamTradeMatcher`. Ta funkcja wymaga ustawienia `LicenseID` , ponieważ wykorzystuje serwer zewnętrzny i opłacone zasoby do działania.

Aby skorzystać z tej opcji, masz zestaw wymagań, które należy spełnić. Co najmniej musisz mieć konto **[bez ograniczeń](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** aktywny i co najmniej jeden prawidłowy typ w `Dopasowalne Typy`, takie jak karty handlowe. Dodatkowe wymogi obejmują 2FA aktywne od co najmniej 15 dni, ostatnia zmiana hasła ponad 5 dni temu, brak jakichkolwiek ograniczeń na rachunkach, takich jak blokady, zakazy ekonomiczne i zakazy handlu.

Jeżeli spełniasz wszystkie powyższe wymagania, ASF będzie okresowo komunikować się z naszym **[publicznym ASF STM listującym](#publiclisting)** w celu aktywnego dopasowania botów, które są obecnie dostępne.

Podczas dopasowania bota ASF pobierze swój własny ekwipunek, a następnie połącz się z naszym serwerem, aby znaleźć wszystkie możliwe `dopasowane typy` dopasowane do innych aktualnie dostępnych botów. Dzięki bezpośredniej komunikacji z naszym serwerem, ten proces wymaga jednego wniosku i mamy natychmiastową informację, czy jakikolwiek dostępny bot oferuje coś interesującego dla nas - jeśli zostanie znaleziony dopasowanie, ASF automatycznie wyśle i potwierdzi ofertę handlową.

Ten moduł powinien być przeźroczywy. Dopasowanie rozpocznie się w przybliżeniu za około `1` godzinę od rozpoczęcia ASF i będzie powtarzać każdy `6` godzin (w razie potrzeby). Funkcja `Dopasowanie` ma być używana jako długoterminowy, okresowy środek, aby upewnić się, że aktywnie zmierzamy do ukończenia zestawów, jednak osoby, które nie korzystają z ASF 24/7, mogą również rozważyć użycie polecenia `match` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Docelowymi użytkownikami tego modułu są konta podstawowe i konta „stash”, chociaż może być używany przez bota, który nie jest ustawiony na `MatchEverything`. Ponadto boty o więcej niż `500000` nie są akceptowane do dopasowania ze względu na nadmierne koszty ogólne, w tym przypadku zalecamy podzielenie twojego ekwipunku na kilka kont.

ASF robi wszystko, co w jej mocy, aby zminimalizować ilość żądań i nacisków wygenerowanych przy użyciu tej opcji, przy jednoczesnym maksymalizacji skuteczności dopasowania do górnej granicy. Dokładny algorytm wyboru botów do dopasowania i w inny sposób zorganizowania całego procesu, jest szczegółami wdrażania funduszu ASF i może się zmienić w odniesieniu do informacji zwrotnych, sytuacji i ewentualnych przyszłych pomysłów.

Obecna wersja algorytmu sprawia, że ASF jest priorytetem `dowolnych botów` , zwłaszcza tych, którzy mają większą różnorodność gier z których pochodzą. Po wyczerpaniu `dowolnych botów` ASF przejdzie do `uczciwych` zgodnie z tą samą zasadą różnorodności. ASF spróbuje dopasować każdego dostępnego bota przynajmniej raz, aby upewnić się, że nie brakuje nam możliwego postępu w ustawieniu.

`MatchActively` takes into account bots that you blacklisted from trading through `tbadd` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** and will not attempt to actively match them. Może to być użyte do informowania ASF, które boty nigdy nie powinny się zgadzać, nawet jeśli mają potencjalne kanały do użycia.

ASF dołoży również wszelkich starań, aby zapewnić realizację ofert handlowych. W następnym uruchomieniu, które zazwyczaj ma miejsce w ciągu 6 godzin, ASF anuluje wszystkie oczekujące oferty handlowe, które nadal nie zostały zaakceptowane, i odłóż od priorytetu SteamID biorących w nich udział, aby najpierw preferować więcej aktywnych botów. Jeśli jednak są to ostatnie boty z dopasowaniem, którego potrzebujemy, to nadal będziemy starali się ich dopasować (ponownie).

---

### Dlaczego potrzebuję `LicenseID` aby używać `Dopasowywnie`? Nie było to wcześniej darmowe?

ASF jest i pozostaje darmowym i otwartym oprogramowaniem, tak jak zostało ustanowione na początku projektu w październiku 2015 r. Kod źródłowy wtyczki `ItemsMatcher` i dlatego funkcja `Dopasowanie` jest dostępna w naszym repozytorium, podczas gdy program ASF jest całkowicie niekomercyjny, nie zarabiamy nic z wkładu do niego, nie budujemy ani nie publikujemy. W ciągu ostatnich 7+ lat ASF otrzymała ogromną ilość rozwoju, i jest nadal ulepszany i ulepszany za pomocą każdego comiesięcznego stabilnego wydania, głównie przez jedną osobę, **[JustArchi](https://github.com/JustArchi)** - bez załączonych ciągów. Jedynym finansowaniem, które otrzymujemy, jest nieobowiązkowe darowizny od naszych użytkowników.

Przez bardzo długi czas, do października 2022 r., funkcja `MatchActive` była częścią rdzenia ASF i dostępna dla wszystkich do użycia. W październiku 2022 r. Valve, przedsiębiorstwo za Steam, wprowadził bardzo surowe limity szybkości pobierania inwentarza innych botów - co spowodowało całkowite złamanie poprzedniej funkcji, bez możliwości rozwiązania tego problemu. W związku z tym ze względu na fakt, że dana cecha stała się całkowicie zdefenowana bez szans na jej rozwiązanie, musiał zostać usunięty z rdzenia ASF jako przestarzały.

`Dopasowanie` zostało przywrócone jako część oficjalnej wtyczki `ItemsMatcher` , która dodatkowo zwiększa ASF z aktywnymi kartami pasującymi do funkcji, oparcie się na całkowicie przebudowanej koncepcji. Resurrecting `MatchActively` wymaga od nas **niezwykłej pracy** aby utworzyć ASF backend, całkowicie nowa usługa hostowana na serwerze, z ponad sto płatnych pełnomocnictw dołączonych do restrukturyzacji inwentaryzacji, wszystko wyłącznie po to, aby umożliwić klientom ASF korzystanie z `Dopasowywnie` tak jak wcześniej. Ze względu na wielkość zaangażowanej pracy, jak również zasoby, które nie są darmowe i wymagają płatności miesięcznych przez nas (domena, serwer, proxy), zdecydowaliśmy się zaoferować tę funkcjonalność naszym sponsorom, to znaczy, ludzie, którzy już wspierają projekt ASF co miesiąc, dzięki którym możemy udostępnić te płatne środki.

Naszym celem nie jest czerpanie z niego zysków, ale raczej, pokrycie kosztów **miesięcznych** , które są związane wyłącznie z oferowaniem tej opcji - dlatego zasadniczo nie oferujemy jej za nic, ale musimy za to nieco obciążyć, ponieważ każdego miesiąca nie możemy płacić setek dolarów z naszych kieszeni, po prostu aby udostępnić to Tobie. Naprawdę nie możemy również omówić ceny, to Głowica, która wymusiła na nas te koszty, a alternatywą jest brak takiej funkcji, które oczywiście ma zastosowanie, jeśli z jakiegokolwiek powodu nie możesz uzasadnić użycia naszej wtyczki na tych warunkach.

W każdym razie rozumiemy, że `Dopasowanie` nie jest dla wszystkich, i mamy nadzieję, że rozumiesz również, dlaczego nie możemy zaoferować go za darmo. Jeżeli nikt nie był zainteresowany pomocą w pokryciu kosztów tej funkcji, to po prostu nie istniałaby, aby zacząć od tej funkcji. jako byliśmy zmuszeni do cięcia miesięcznych wydatków, których nikt nie chce utrzymać. Na szczęście jesteśmy w lepszej pozycji niż ta i możesz samodzielnie zdecydować, czy chcesz użyć `MatchActive` na tych terminach lub nie.

---

### Jak mogę uzyskać dostęp?

`ItemsMatcher` is offered as part of monthly $5+ sponsor tier on **[JustArchi's GitHub](https://github.com/sponsors/JustArchi)**. Możliwe jest również bycie jednorazowym sponsorem, chociaż w tym przypadku licencja będzie ważna tylko przez miesiąc (z możliwością przedłużenia na ten sam sposób). Kiedy zostaniesz sponsorem o poziomie $5 (lub wyższym) przeczytaj sekcję **[konfiguracja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** , aby uzyskać i wypełnić `LicenseID`. Następnie musisz włączyć tylko `MatchActive` w `TradingPreferences` wybranego bota.

Licencja pozwala wysyłać ograniczoną liczbę żądań do serwera. $5 tier pozwala na użycie `MechActive` dla jednego konta bota (4 żądania dziennie), i każdy dodatkowy $5 dodaje jeszcze dwa konta botów (8 żądań dziennie). Na przykład, jeśli chcesz uruchomić go na trzech kontach, to będzie to kwota 10 dolarów i wyższa.