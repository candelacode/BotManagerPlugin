# Elementy przestarzałe

Robimy wszystko, co w naszej mocy, aby stosować konsekwentną politykę deprekacji, aby zarówno rozwój, jak i stosowanie były znacznie bardziej spójne.

---

## Czym jest deprecjacja?

Deprecjacja to proces mniejszych lub większych zmian powodujących przestarzałe wcześniej używane opcje, argumenty, funkcjonalności lub przypadki wykorzystania. Deprecjacja zazwyczaj oznacza, że dany element został po prostu przekształcony w inną (podobną) formę, i powinieneś zapewnić w odpowiednim czasie, aby odpowiednio przełączyć. W takim przypadku po prostu przesuwa się daną funkcjonalność do bardziej odpowiedniego miejsca.

ASF zmienia się szybko i zawsze uderza o poprawę sytuacji. To niestety oznacza, że możemy zmienić lub przenieść niektóre istniejące funkcje do innego segmentu programu, aby skorzystać z nowych funkcji, kompatybilność lub stabilność. Dzięki temu nie musimy trzymać się przestarzałych lub po prostu bolesnych decyzji rozwojowych, które podjęliśmy wiele lat temu. Zawsze staramy się zapewnić rozsądną wymianę, która odpowiada oczekiwanemu wykorzystaniu wcześniej dostępnej funkcjonalności, Z tego względu przestarzałość jest w większości nieszkodliwa i wymaga drobnych poprawek do poprzedniego użycia.

---

## Etapy amortyzacji

ASF będzie przechodził dwa etapy deprekacji, co będzie znacznie łatwiejsze i mniej kłopotliwe.

### Etap 1

Etap 1 ma miejsce, gdy dana funkcja staje się przestarzała, przy natychmiastowej dostępności innego rozwiązania (lub jeśli nie ma planów jej ponownego wprowadzenia).

Na tym etapie ASF wydrukuje odpowiednie ostrzeżenie w przypadku użycia przestarzałej funkcji. Tak długo, jak będzie to możliwe, ASF spróbuje naśladować stare zachowanie i zachowuje zgodność z nim. ASF pozostanie na etapie 1 w odniesieniu do tej funkcjonalności co najmniej do następnej stabilnej wersji. Jest to moment, w którym - miejmy nadzieję - bez naruszania kompatybilności możesz odpowiednio zmienić wszystkie swoje narzędzia i wzorce, aby zaspokoić nowe zachowanie. Możesz potwierdzić, czy zrobiłeś wszystkie odpowiednie zmiany, nie widząc już ostrzeżenia o przestarzałości.

### Etap 2

Etap 2 jest zaplanowany po zakończeniu etapu 1 wyjaśnionego powyżej i zostaje uwolniony w stabilnym uwalnianiu. Ten etap wprowadza całkowite usunięcie przestarzałych funkcji, co oznacza, że ASF nie będzie nawet uznawać, że próbujesz używać przestarzałych funkcji, niech się to uszanuje, ponieważ po prostu nie istnieje w bieżącym kodzie. ASF nie będzie już drukować żadnych ostrzeżeń, ponieważ nie rozpoznaje tego, co próbujesz zrobić.

---

## Podsumowanie

Masz mniej więcej **pełny miesiąc** aby wykonać odpowiedni przełącznik, który powinien być więcej niż wystarczający, nawet jeśli jesteś przypadkowym użytkownikiem ASF. Po tym okresie ASF nie gwarantuje, że stare ustawienia będą miały jakikolwiek wpływ (etap 2), skutecznie sprawić, by niektóre funkcje przestały działać bez zauważenia. Jeśli uruchamiasz ASF po ponad miesiącu bezczynności, rekomendowane jest dla Ciebie **[zacznij od podstaw](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** ponownie, lub przeczytaj wszystkie dzienniki zmian, które przegapiłeś i dostosuj ręcznie do aktualnych.

W większości przypadków pominięcie ostrzeżenia o deprekacji nie spowoduje nieprzydatności ogólnej funkcji ASF, ale raczej powrót do domyślnego zachowania (co może lub może nie odpowiadać Twoim preferencjom).

---

## Przykład

Przenieśliśmy preV3.1.2.2 `--server` **[argument linii poleceń](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** do `IPC` **[globalna właściwość konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**

### Etap 1

Etap 1 miał miejsce w wersji V3.1.2.2, gdzie dodaliśmy odpowiednie ostrzeżenie o użyciu `--server`. Nieaktualny argument `--server` został automatycznie zamapowany na `IPC: prawdziwa` globalna właściwość konfiguracji, skuteczne działanie dokładnie tak samo jak stary `--server` przełącza się na czas. Umożliwiło to wszystkim dokonanie odpowiedniego przełączania, zanim ASF przestanie akceptować stary argument.

### Etap 2

Etap 2 miał miejsce w wersji V3.1.3.0, bezpośrednio po wersji V3.1.2.9 stabilnej w etapie 1 wyjaśnionym powyżej. Etap 2 spowodował przerwanie rozpoznawania argumentu `--server` w ogóle, traktowanie go jak każdego innego nieważnego argumentu, który nie ma już żadnego wpływu na program. Dla osób, które nadal nie zmieniły użycia `--server` na `IPC: true`, spowodowało to, że IPC przestała funkcjonować całkowicie, ponieważ ASF nie stosowała już odpowiedniego mapowania.