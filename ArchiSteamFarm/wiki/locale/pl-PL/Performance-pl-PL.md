# Wydajność

Głównym celem afrykańskiego pomoru świń jest jak najskuteczniejsze gospodarstwo, w oparciu o dwa rodzaje danych, które mogą działać – niewielki zestaw danych dostarczanych przez użytkowników, który nie jest w stanie odgadnąć/sprawdzić samodzielnie, i większy zestaw danych, które mogą być automatycznie sprawdzane przez ASF.

W trybie automatycznym ASF nie pozwala wybrać gier, które powinny być farmane, ani nie pozwala na zmianę algorytmu rolniczego kart. **ASF wie lepiej, co powinien zrobić i jakie decyzje powinien podjąć, aby polować tak szybko jak to możliwe**. Twoim celem jest poprawne ustawienie właściwości, ponieważ ASF nie może ich odgadnąć samodzielnie, wszystko inne jest uwzględnione.

---

Jakiś czas temu Głowica zmieniła algorytm upuszczania karty. Począwszy od tego punktu możemy skategoryzować konta parowe według dwóch kategorii: te **z** upuszczają karty z ograniczeniem i te **bez**. Jedyną różnicą pomiędzy tymi dwoma typami jest fakt, że konta z ograniczonymi kroplami karty nie mogą otrzymać żadnej karty z danej gry dopóki nie grają w grę przez co najmniej `X` godzin. It seems that older accounts that never asked for refund have **unrestricted card drops**, while new accounts and those who did ask for refund have **restricted card drops**. Jest to jednak tylko teoria i zasadniczo nie powinno być traktowane jako zasada. Dlatego też **nie ma oczywistej odpowiedzi**, i ASF opiera się na **Ty** informując, który przypadek jest odpowiedni dla Twojego konta.

---

ASF obejmuje obecnie dwa algorytmy rolnicze:

**`Simple`** algorytm działa najlepiej dla kont, które mają nieograniczone zwroty karty. Jest to podstawowy algorytm używany przez ASF. Bot znajdzie gry do hodowli, a gospodarza je jeden po drugim, aż wszystkie karty zostaną zrzucone. Dzieje się tak, ponieważ liczba kart spada, gdy rolnictwo więcej niż jedna gra jest bliska zera i całkowicie nieskuteczna.

**`Complex`** to nowy algorytm, który został zaimplementowany, aby pomóc ograniczyć konta, aby zmaksymalizować ich zyski. ASF użyje najpierw standardowego **`Prosty algorytm`** we wszystkich partiach, które przeszły `HoursUntilCardDrops` godzin zabawy, a następnie jeśli nie ma gier z >= `Godziny` godzin, poprowadzi wszystkie gry (do wartości `32` limit) z < `GodzinUntilCardDrops` godzin pozostających jednocześnie, dopóki którykolwiek z nich nie trafi `HoursUntilCarddrops` godzin, następnie ASF będzie kontynuować pętlę od początku (użyj **`Simple`** na tej grze, wróć do równoczesnego na < `HoursUntilCardDrops` i tak dalej). W tym przypadku możemy korzystać z wielu gier w celu wypychania w godzinach rozgrywki, które musimy najpierw przeznaczyć na gospodarstwo rolne. Pamiętaj, że w godzinach chowu ASF **nie** kart hodowlanych, więc nie będzie sprawdzać żadnych kropli karty w tym okresie (z powodów podanych powyżej).

Obecnie ASF wybiera algorytm rolniczy kart oparty wyłącznie na `HoursUntilCardDrops` właściwość konfiguracji (która jest ustawiona przez ****). Jeśli `HoursUntilCardDrops` jest ustawiony na `0`, **`Prosty Algorytm`** zostanie użyty, w przeciwnym razie Zamiast tego użyty zostanie algorytm **`Complex`** - skonfigurowany do nadmiarowego czasu gry we wszystkich grach do określonej liczby godzin przed założeniem ich na karty

---

### **There is no obvious answer which algorithm is better for you**.

Jest to jeden z powodów, dla których nie wybierzesz algorytmu rolniczego kart zamiast tego, mówisz ASF, jeśli konto ma ograniczony spadek czy nie. Jeśli konto ma nieograniczone drogi, **`Prosty`** algorytm **będzie działać lepiej** na tym koncie, ponieważ nie będziemy marnować czasu na doprowadzenie wszystkich gier do `X` - stosunek kart do liczby kart jest bliski 0% podczas uprawiania wielu gier. Z drugiej strony, jeśli na Twoim koncie znajduje się zablokowany spadek karty, **`Complex`** algorytm będzie lepszy dla Ciebie, ponieważ nie ma żadnego punktu w solo rolnicze, jeśli gra nie osiągnęła `HoursUntilCardDrops` godzin jeszcze - więc najpierw będziemy uprawiać **czas gry** , **a następnie** karty w trybie solo.

Nie zaślepiaj `HoursUntilCardDrops` tylko dlatego, że ktoś ci powiedział, aby wykonać testy, porównaj wyniki i na podstawie otrzymanych danych, zdecyduj, która opcja powinna być lepsza dla Ciebie. Jeśli włożysz w to pewien minimalny wysiłek, upewnisz się, że ASF działa z maksymalną możliwą wydajnością dla Twojego konta, który prawdopodobnie chcesz, biorąc pod uwagę, że czytasz teraz tę stronę wiki. Gdyby istniało rozwiązanie, które działa dla wszystkich, nie otrzymałbyś wyboru - ASF sam zdecydowałaby.

---

### Jaki jest najlepszy sposób na sprawdzenie, czy Twoje konto jest ograniczone?

Upewnij się, że masz kilka gier z **bez nagrań** do hodowli, najlepiej 5+, i uruchom ASF z `HoursUntilCardDrops` z `0`. Dobrym pomysłem byłoby, gdybyś nic nie grał w okresie chowu w celu uzyskania dokładniejszych wyników (najlepiej uruchomić ASF w nocy). Pozwól ASF hodować 5 gier, a następnie sprawdzić logi w celu uzyskania wyników.

ASF wyraźnie stwierdza, kiedy karta dla danej gry została odrzucona. Jesteś zainteresowany najszybszą kroplą karty uzyskaną przez ASF. Na przykład, jeśli Twoje konto jest nieograniczone, pierwszy spadek karty powinien nastąpić po około 30 minutach od rozpoczęcia działalności rolniczej. If you notice **at least one** game that did drop card in those initial 30 minutes, then this is an indicator that your account is **not** restricted and should use `HoursUntilCardDrops` of `0`.

Z drugiej strony jeśli zauważysz, że **co** gra zajmuje co najmniej `X` liczbę godzin, zanim wyrzuci swoją pierwszą kartę, wtedy jest to wskaźnik dla Ciebie, do czego powinieneś ustawić `HoursUntilCardDrops`. Większa liczba (jeśli nie wszystkie) ograniczonych użytkowników wymaga co najmniej `3` godzin zabawy dla kart do upuszczenia, i jest to również domyślna wartość dla `HoursUntilCardDrops`.

Pamiętaj, że gry mogą mieć różną szybkość, właśnie dlatego powinieneś przetestować, czy twoja teoria jest słuszna z **co najmniej** 3 gier, najlepiej 5+, aby upewnić się, że nie podchodzisz do fałszywych wyników zbieżności. Spadek karty jednej gry w mniej niż godzinę to potwierdzenie, że Twoje konto **nie jest ograniczone** i może użyć `HoursUntilCardDrops` z `0`, ale aby potwierdzić, że Twoje konto **jest ograniczone** , potrzebujesz co najmniej kilku gier, które nie upuszczają kart, dopóki nie naciśniesz stałej oceny.

Należy zauważyć, że w przeszłości `HoursUntilCardDrops` był tylko `0` lub `2`, i dlatego ASF miał pojedynczą właściwość `CardDropsRestricted` , która pozwoliła na zmianę tych dwóch wartości. Po ostatnich zmianach zauważyliśmy, że nie tylko większość użytkowników wymaga `3` godzin zamiast poprzednich `2` teraz, ale również to, że `HoursUntilCardDrops` jest teraz dynamiczne i może trafić na dowolną wartość dla każdego konta.

Ostatecznie decyzja leży w gestii pana.

I aby jeszcze bardziej pogorszyć to zjawisko - doświadczyłem przypadków, kiedy ludzie przechodzili z stanu ograniczonego do stanu nieograniczonego i na odwrót - z powodu błędu Steam (tak, mamy wiele z nich) lub z powodu pewnych korekt logicznych dokonywanych przez Valve. Więc nawet jeśli potwierdziłeś, że Twoje konto jest ograniczone (lub nie), nie uważają, że pozostanie tak - aby przejść od nieograniczonej do ograniczonej, wystarczy poprosić o zwrot pieniędzy. Jeśli uważasz, że poprzednio ustawiona wartość nie jest już właściwa, zawsze możesz ponownie przetestować i zaktualizować ją odpowiednio.

---

Domyślnie ASF zakłada, że `HoursUntilCardDrops` to `3`, jako negatywny skutek ustawienia tego na `3` , gdy powinien być mniejszy niż w inny sposób. Dzieje się tak dlatego, że w najgorszym możliwym przypadku będziemy marnować `3` godzin produkcji rolnej na partie `32` , w porównaniu z marnowaniem `3` godzin produkcji rolnej na każdą grę jeśli `HoursUntilCardDrops` domyślnie ustawiono na `0`. Jednak nadal powinieneś dostosować tę zmienną, aby dopasować swoje konto do maksymalnej wydajności, ponieważ jest to tylko ślepy odgadnięcie oparte na potencjalnych wadach i większości użytkowników (więc próbujemy domyślnie wybrać "mniejszy zł").

Obecnie dwa powyższe algorytmy są wystarczające dla wszystkich obecnie możliwych scenariuszy kont, w celu jak najskuteczniejszego prowadzenia gospodarstwa, w związku z tym nie planuje się dodawania żadnych innych.

Miło jest zauważyć, że ASF obejmuje również tryb ręcznego chowu, który może być aktywowany przez polecenie `graj`. Więcej na ten temat znajdziesz w komendach **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

## Błyszczarki parowe

Algorytm upuszczania kart nie zawsze działa tak, jak powinien, i jest to całkowicie możliwe, aby pojawiły się różne bryły Steam, takie jak karty upuszczane na kontach zastrzeżonych, karty są upuszczane przy zamknięciu/przełączaniu gry, karty w ogóle się nie upuszczają, gdy gra jest grana i podobnie.

Ta sekcja dotyczy głównie osób, które zastanawiają się, dlaczego ASF nie robi **X**, takie jak szybsze przełączanie gier na karty rolne.

Co to jest **Steam glitch** - określona akcja wyzwalająca **niezdefiniowane zachowanie** , który jest **nieprzeznaczony, nieudokumentowany i uważany za błąd logiczny**. It's **unreliable by definition**, which means that it can't be reproduced reliably with clean testing environment, and therefore, coded without resorting to hacks that are supposed to guess when glitch is happening and how to fight with it / abuse it. Zwykle jest to tymczasowe dopóki deweloperzy nie naprawią błędów logicznych, chociaż niektóre różne glitery mogą pozostać niezauważone przez bardzo długi czas.

Dobrym przykładem tego, co uważa się za **glitch Steam** nie jest to, że niezbyt często upuszczana karta podczas zamykania gry, które mogą być nadużywane do pewnego stopnia z funkcją pominięcia gry bezczynnego mistrza.

- **Niezdefiniowane zachowanie** - nie możesz powiedzieć, czy po uruchomieniu glitcha zostanie upuszczone 0 lub 1 karty.
- **Niezamierzone** - w oparciu o doświadczenia i zachowanie sieci Steam, które nie skutkują takim samym zachowaniem podczas wysyłania pojedynczego żądania.
- **Nieudokumentowane** - jest wyraźnie udokumentowane na stronie Steam, w jaki sposób odbierane są karty, i **w każdym miejscu** wyraźnie stwierdzono, że jest on uzyskiwany przez **grający w**, NIE zamykaj gier, zdobywaj osiągnięć, przełączaj gry lub uruchamiaj jednocześnie 32 gier.
- **Uznany za wadliwość logiczną** - zamykanie gier lub przełączanie ich nie powinno mieć wpływu na upuszczanie kart, które są wyraźnie określone jako uzyskane przez **zyskiwanie czasu gry**.
- **Niewiarygodny z definicji nie może być odtworzony niezawodnie** - nie działa dla wszystkich, i nawet gdyby zadziałała dla Ciebie jednocześnie, nie mogła już działać po raz drugi.

Teraz, gdy zdaliśmy sobie sprawę, czym jest Steam glitch i fakt, że karty są upuszczane, gdy gra zostanie zamknięta **jest** , możemy przejść do drugiego punktu - **ASF z definicji nie nadużywa sieci Steam, i robi wszystko, co w jej mocy, aby spełnić wymogi Steam ToS, jego protokołów i ogólnie akceptowane**. Spamming Steam network z ciągłym otwieraniem/zamykaniem gier można uznać za **[DoS](https://en.wikipedia.org/wiki/Denial-of-service_attack)** i **bezpośrednio narusza [Steam Online Conduct](https://store.steampowered.com/online_conduct/?l=english)**.

> Jako subskrybent Steam zgadzasz się przestrzegać następujących zasad postępowania.
> 
> Nie będziesz:
> 
> Instytut atakuje na serwer Steam lub w inny sposób zakłóca Steam.

Nie ma znaczenia, czy możesz uruchomić Steam glitch z innymi programami (takimi jak IM), i nie ma również znaczenia, czy zgadzasz się z nami i rozważasz takie zachowanie jak atak DoS, lub nie - to zawór musi to ocenić, ale jeśli uznajemy to za eksploatację/nadużywanie niezamierzonych zachowań poprzez nadmierne żądania sieci Steam, wtedy możesz być pewien, że zawór będzie miał podobny pogląd na ten temat.

ASF to **nigdy** nie skorzysta z exploitów Steam, nadużyć, hacks lub jakakolwiek inna aktywność, którą uważamy za **nielegalną lub niechcianą** według Steam ToS, Steam Online Conduct lub inne zaufane źródło, które mogą wskazywać na to, że aktywność ASF jest niechciana przez sieć Steam, zgodnie z sekcją **[wnoszący wkład](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)**.

Jeśli chcesz za wszelką cenę ryzykować swoje konto Steam do chowu kilku centów kart szybciej niż zwykle, niestety, ASF nigdy nie zaoferuje czegoś takiego w trybie automatycznym, chociaż nadal masz `graj` **[polecenie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** , które może być użyte jako narzędzie do robienia wszystkiego, co chcesz, pod względem interakcji z siecią Steam. Nie zalecamy korzystania z glitches Steam i wykorzystywania ich do własnych zysków - nie tylko z ASF, ale również przy użyciu innych narzędzi. Jednak w końcu to Twoje konto. i pański wybór, co z tym chcesz zrobić - pamiętaj, że ostrzeliśmy.