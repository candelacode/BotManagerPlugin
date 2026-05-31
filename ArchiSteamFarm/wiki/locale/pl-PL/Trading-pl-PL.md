# Handel

ASF zawiera wsparcie dla nieinteraktywnych (offline) transakcji Steam. Zarówno odbieranie (akceptacja/odrzucenie), jak i wysyłanie transakcji jest dostępne od razu i nie wymaga specjalnej konfiguracji, ale oczywiście wymaga nieograniczonego konta Steam (które wydało już równowartość 5 dolarów amerykańskich w sklepie). Dla ograniczonych rachunków dostępne są tylko ograniczone funkcje handlowe.

---

## Logika

First of all, it's possible to disable **all** incoming trade offers, by using `DisableIncomingTradesParsing` flag in `BotBehaviour`. Używanie tej nazwy spowoduje wyłączenie wszystkich funkcji związanych z przetwarzaniem przychodzących transakcji, który zawiera poniżej domyślnej logiki, jak również wszystkie dodatkowe dostępne funkcje, które zależą od reakcji na przychodzącą ofertę transakcyjną. Ponieważ domyślne ustawienia są już nieinwazyjne, powinieneś rozważyć skorzystanie z tej opcji tylko wtedy, gdy nie masz absolutnie żadnych zamiarów ze strony ASF co zrobić w ogóle z transakcjami przychodzącymi.

Poniższe wyjaśnia logikę, gdy przetwarzanie ofert przychodzących jest włączone, co jest domyślną opcją.

ASF zawsze akceptuje wszystkie transakcje, niezależnie od przedmiotów, wysłane od użytkownika z dostępem `Master` (lub wyższym) do bota. Pozwala to nie tylko na łatwe kopanie kartami parowymi produkowanymi przez instancję bota, ale pozwala również na łatwe zarządzanie przedmiotami Steam, które botują stashy w ekwipunku - w tym z innych gier (takich jak CS:GO).

ASF odrzuci ofertę handlową, niezależnie od treści, od dowolnego (niegłównego) użytkownika, który jest na czarnej liście z modułu tradingowego. Czarna lista jest przechowywana w standardowym `BotName. b` baza danych i może być zarządzana przez `tb`, `tbadd` i `tbrm` **[polecenia](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Powinno to działać jako alternatywa dla standardowego bloku użytkownika oferowanego przez Steam - używaj ostrożnie.

ASF zaakceptuje wszystkie transakcje typu `loot`wysyłane przez boty, chyba że `DontAcceptBotTrades` jest określone w `TradingPreferences`. Krótko mówiąc, domyślnie `TradingPreferences` of `None` spowoduje automatyczne akceptowanie transakcji od użytkownika z `Master` do bota (objaśnienie powyżej), jak również wszelkie transakcje darowizn od innych botów, które uczestniczą w procesie ASF.

When you enable `AcceptDonations` in your `TradingPreferences`, ASF will also accept any donation trade - a trade in which bot account is not losing any items. Ta właściwość dotyczy tylko kont innych niż bot, ponieważ konta botów są naruszone przez `DontAcceptBotTrades`. `AkceptDarowizny` pozwalają na łatwe przyjmowanie darowizn od innych osób, a także botów, które nie uczestniczą w procesie ASF.

Miło jest zauważyć, że `AcceptDonations` nie wymaga **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, ponieważ nie ma wymaganego potwierdzenia, jeśli nie tracimy żadnych przedmiotów.

Możesz również dostosować możliwości handlu ASF poprzez odpowiednią modyfikację `TradingPreferences`. Jedną z głównych funkcji `TradingPreferences` jest opcja `SteamTradeMatcher` , która sprawi, że ASF będzie używał wbudowanej logiki akceptowania transakcji, które pomogą Ci ukończyć brakujące odznaki, która jest szczególnie przydatna we współpracy z publiczną listą **[SteamTradeMatcher](https://www.steamtradematcher.com)**, ale może również działać bez niej. Poniżej opisano to bardziej szczegółowo.

---

## `SteamTradeMatcher`

Gdy `SteamTradeMatcher` jest aktywny, ASF będzie używał dość skomplikowanego algorytmu sprawdzania, czy handel przechodzi reguły STM i jest co najmniej neutralny. Rzeczywista logika jest następująca:

- Odrzuć transakcję, jeśli tracimy cokolwiek oprócz typów przedmiotów określonych w naszym `Dopasowalnych Typów`.
- Odrzuć handel, jeśli nie otrzymujemy co najmniej tej samej liczby przedmiotów na grę, według typu i według rzadkości.
- Odrzuć transakcję, jeśli użytkownik prosi o specjalne karty sprzedaży Steam latem/zimowe i ma zlecenie handlowe.
- Odrzuć transakcję, jeśli czas trwania transakcji przekracza `MaxTradeHoldDuration` globalna właściwość konfiguracji.
- Odrzuć transakcję, jeśli nie mamy ustawionego `MatchEverything` i jest to dla nas gorsze niż neutralne.
- Zaakceptuj handel, jeśli nie odrzuciliśmy go przez żaden z powyższych punktów.

Miło jest zauważyć, że ASF obsługuje również nadpłacanie - logika będzie działać poprawnie, gdy użytkownik doda coś dodatkowego do transakcji, pod warunkiem spełnienia wszystkich powyższych warunków.

Pierwsze 4 odrzucenie predykatów powinno być oczywiste dla wszystkich. Ostatnia z nich obejmuje faktyczną logikę węzłów, która sprawdza obecny stan naszego spisu i decyduje, jaki jest status handlu.

- Trade is **good** if our progress towards set completion advances. Przykład: A (przed) -> A B (po)
- Handel jest **neutralny** jeśli nasz postęp na drodze do ukończenia pozostaje w kontakcie. Przykład: A B (przed) -> A C (po)
- Handel jest **zły** jeśli nasze postępy na drodze do ustawiania ukończenia spadają. Przykład: A C (przed) -> A (po)

STM działa tylko na dobrych transakcjach, co oznacza, że użytkownik korzystający z STM do dopasowywania kanałów powinien zawsze sugerować tylko dobre transakcje dla nas. ASF ma jednak charakter liberalny i akceptuje neutralne transakcje, ponieważ w tych transakcjach nic nie stracimy, więc nie ma prawdziwego powodu do ich odrzucenia. Jest to szczególnie przydatne dla Twoich przyjaciół, ponieważ mogą zamienić nadmierne karty bez korzystania ze STM w ogóle, dopóki nie stracisz żadnego ustawionego postępu.

Domyślnie ASF odrzuci złe transakcje - jest to prawie zawsze to, co chcesz jako użytkownik. However, you can optionally enable `MatchEverything` in your `TradingPreferences` in order to make ASF accept all dupe trades, including **bad ones**. To jest przydatne tylko wtedy, gdy chcesz uruchomić bota handlowego 1:1 pod swoim kontem, jak rozumiesz, że **ASF nie pomoże Ci już w realizacji odznaki, i skłonić Cię do utraty całego gotowego zestawu dla N kanałów tej samej karty**. If you want to intentionally run a trade bot that is **never** supposed to finish any set, and should offer its whole inventory to every interested user, then you can enable that option.

Niezależnie od wybranego przez siebie `TradingPreferences`, transakcja została odrzucona przez ASF nie oznacza, że nie możesz zaakceptować jej samodzielnie. Jeśli zachowałeś domyślną wartość `BotBehaviour`, która nie zawiera `RejectInvalidTrades`, ASF po prostu zignoruje te transakcje - pozwalając Ci na samodzielne decydowanie, czy jesteś zainteresowany lub nie. To samo dotyczy transakcji z przedmiotami spoza `MatchableTypy`, tak samo jak wszystko inne - moduł powinien pomóc Ci zautomatyzować transakcje STM, nie decydować o tym, co jest dobrym handlem, a co nie. Jedynym wyjątkiem od tej reguły jest mówienie o użytkownikach, którzy na czarnej liście korzystają z modułu tradingowego za pomocą polecenia `tbadd` - transakcje z tych użytkowników są natychmiast odrzucane niezależnie od ustawień `BotBehaviour`.

Zaleca się używanie **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** po włączeniu tej opcji, ponieważ ta funkcja traci cały swój potencjał, jeśli zdecydujesz się ręcznie potwierdzić każdą wymianę. `SteamTradeMatcher` będzie działać poprawnie nawet bez możliwości potwierdzenia transakcji, ale może wygenerować zaległe potwierdzenia, jeśli nie akceptujesz ich na czas.