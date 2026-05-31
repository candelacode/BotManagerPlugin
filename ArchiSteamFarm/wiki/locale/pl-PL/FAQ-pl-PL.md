# FAQ

Nasze podstawowe najczęściej zadawane pytania obejmują standardowe pytania i odpowiedzi, które możesz posiadać. Mniej typowych sprawach zamiast odwiedź nasze **[FAQ rozszerzone](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ)**.

# Spis treści

* [Ogólne](#general)
* [Porównanie z podobnych narzędzi](#comparison-with-similar-tools)
* [Bezpieczeństwa / prywatności / VAC / bany / ToS](#security--privacy--vac--bans--tos)
* [Różne](#misc)
* [Problemy](#issues)

---

## Ogólne

### Co to jest ASF?
### Dlaczego program twierdzi, że w moim sprawozdaniu nie ma nic do hodowli?
### Dlaczego ASF nie wykrywa wszystkich moich gier?
### Dlaczego moje konto jest ograniczone?

Zanim spróbujesz zrozumieć, co to jest ASF, powinieneś upewnić się, że rozumiesz jakie są karty Steam, i jak je uzyskać, co jest ładnie opisane w oficjalnym FAQ **[tutaj](https://steamcommunity.com/tradingcards/faq)**.

Krótko mówiąc, karty Steam są kolekcjonowania przedmiotów, które możesz skorzystać, gdy posiadanie danej gry, i może służyć za wytwarzanie odznak, sprzedaży na rynku Steam lub innych celów wybranych przez użytkownika.

Tutaj ponownie podano główne punkty. ponieważ ludzie na ogół nie chcą się z nimi zgadzać i wolą udawać, że nie istnieją:

- **Musisz posiadać grę na swoim koncie Steam, aby móc korzystać z jakichkolwiek kropli karty. Udostępnianie rodziny nie jest właścicielem i nie liczy się.**
- **Twoja gra nie może być oznaczona jako [prywatny](https://help.steampowered.com/faqs/view/1150-C06F-4D62-4966), ASF automatycznie pominnie takie gry podczas rolnictwa.**
- **Nie możesz prowadzić hodowli gry w nieskończoność, każda gra ma ustaloną liczbę kart do gry. Kiedy upuścisz wszystkie z nich (około połowy pełnego zestawu), gra nie jest już kandydatem do rolnictwa. Nie ma znaczenia, czy sprzedałeś, handlujesz, wykonałeś lub zapomniałeś co stało się z tymi kartami, które otrzymałeś, gdy skończysz z kartami kropkowymi, gra zostanie zakończona.**
- **Nie możesz wyrzucać kart z gier F2P bez wydawania w nich pieniędzy. Oznacza to trwale gry F2P, takie jak Forteca Drużynowa 2 lub Dota 2. Posiadanie gier F2P nie daje Ci kart spadkowych.**
- **Nie możesz wyrzucać kart do [limitowanych kont](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A), niezależnie od posiadanych gier i sposobu ich aktywacji.**
- **Płatne gry, które otrzymałeś za darmo podczas promocji, nie mogą być uprawiane na krople kart, niezależnie od tego, co jest wyświetlane na stronie sklepu.**

Jak widzisz, karty Steam są przyznawane za grę którą kupiłeś, lub Gra F2P, na którą przeznaczyłeś pieniądze. Jeśli zagrasz wystarczająco długo w grę, wszystkie karty dla tej gry zostaną ostatecznie wyrzucone do twojego ekwipunku, umożliwia ukończenie odznaki (po otrzymaniu pozostałej połowy zestawu), sprzedaj je lub zrób cokolwiek innego.

Teraz, gdy wyjaśniliśmy podstawy Steam, możemy wyjaśnić ASF. Sam program jest dość skomplikowany do pełnego zrozumienia, więc zamiast wykopywać we wszystkich szczegółach technicznych, zaoferujemy bardzo uproszczone wyjaśnienie poniżej.

ASF loguje się na Twoje konto Steam poprzez naszą wbudowaną, niestandardową implementację Steam przy użyciu dostarczonych danych logowania. Po pomyślnym zalogowaniu, analizuje Twoje odznaki **[](https://steamcommunity.com/my/badges)** w celu znalezienia gier, które są dostępne dla rolnictwa (`X` kropli kart). Po analizowania wszystkich stron i konstruowania ostateczna lista gier, które są dostępne, ASF wybiera najbardziej efektywny algorytm rolnictwo i rozpoczyna się proces. Proces zależy od wybranego **[kart rolniczych, algorytmu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** , ale zazwyczaj polega na graniu w kwalifikującą się grę i okresowo (plus na każdym spadku przedmiotu) sprawdzając, czy gra jest już w pełni uprawiana - jeśli tak, ASF może przejść do następnego tytułu, stosując tę samą procedurę, aż do pełnego ukończenia wszystkich gier.

Należy pamiętać, że powyżej jest uproszczony i nie opisują kilkanaście dodatkowych funkcji i funkcje, które oferuje ASF. Jeśli chcesz wiedzieć każdy szczegół ASF, odwiedź reszty **[naszej wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki)**. Ja postarałem się zrobić to dość proste do zrozumienia dla wszystkich, bez wprowadzania techniczne szczegóły - zaawansowani użytkownicy są zachęcani do kopać głębiej.

Teraz jako program - ASF oferuje trochę magii. Po pierwsze, nie musi pobierać żadnych plików gry, może grać w gry od razu. Po drugie, jest całkowicie niezależny od normalnego klienta Steam - nie musisz mieć uruchomionego lub nawet zainstalowanego klienta Steam. Po trzecie, jest to rozwiązanie zautomatyzowane, co oznacza, że ASF automatycznie robi wszystko za twoją plecami, bez potrzeby mówienia o tym, co robić - co oszczędza cię i czas. Na koniec nie musi ona usuwać sieci Steam poprzez emulację procesu (która np. używa Idle Master - jest używana), ponieważ może z nią komunikować się bezpośrednio. Jest również bardzo szybka i lekka, będąc niesamowitym rozwiązaniem dla każdego, kto chce łatwo uzyskać karty bez większych trudności - jest to szczególnie użyteczne, pozostawiając je w tle podczas robienia czegoś innego, lub nawet gra w trybie offline.

Wszystko to jest miłe; ale ASF ma również pewne ograniczenia techniczne, które są egzekwowane przez Steam - nie możemy prowadzić gier których nie posiadasz, nie możemy prowadzić gier na zawsze, aby uzyskać dodatkowe krople przekraczające wymuszony limit i nie możemy uprawiać gier podczas gry. Wszystko to powinno być „logiczne”, biorąc pod uwagę sposób funkcjonowania ASF, ale miło jest zauważyć, że ASF nie posiada supermocy i nie zrobi czegoś, co jest fizycznie niemożliwe, aby o tym pamiętać - jest to zasadniczo takie same, jak gdybyś kazał komuś zalogować się na swoim koncie z innego komputera i pogospodarować te gry dla Ciebie.

Podsumowując, ASF jest programem, który pomaga odrzucić te karty, do których się kwalifikujesz, bez kłopotów. Oferuje również kilka innych funkcji, ale na razie trzymajmy się tej funkcji.

---

### Czy muszę podać moje dane uwierzytelniające?

**Użytkownik:** %s ASF wymaga poświadczenia konta w taki sam sposób, jak oficjalny klient Steam, ponieważ używa tej samej metody interakcji z siecią Steam. Nie oznacza to jednak, że musisz umieścić dane konta w konfiguracjach ASF, możesz nadal używać ASF z pustym `SteamLogin` i/lub `SteamPassword`, i wprowadź dane dotyczące każdego ASF, gdy jest to wymagane (jak również kilka innych danych logowania, należy odnieść się do konfiguracji). W ten sposób Twoje dane nie są nigdzie zapisywane, ale oczywiście ASF nie może autostartować bez Twojej pomocy. ASF oferuje również kilka innych sposobów zwiększenia Twojego **[bezpieczeństwa](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**, więc możesz przeczytać tę część wiki, jeśli jesteś zaawansowanym użytkownikiem. Jeśli nie, i nie chcesz umieszczać danych konta w konfiguracjach ASF, następnie po prostu nie rób tego i zamiast tego wprowadź je tak, jakby były potrzebne, gdy ASF prosi o nie.

Pamiętaj, że narzędzie ASF jest przeznaczone do użytku osobistego, a Twoje dane logowania nigdy nie opuszczają Twojego komputera. Nie dzielisz się nimi również z nikim, który spełnia **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** - bardzo ważną rzeczą, o której wielu ludzi zapomina. Nie wysyłasz swoich danych do naszych serwerów lub do niektórych osób trzecich, tylko bezpośrednio na serwery Steam obsługiwane przez Valve. Nie znamy Twoich danych logowania i nie jesteśmy w stanie ich odzyskać za Ciebie, niezależnie od tego, czy umieścisz je w swoich konfiguracjach czy nie.

---

### Jak długo trzeba czekać na przesyłkę?

**Tak długo, jak trwa** - poważnie. Każda gra ma różne trudności z rolnictwem ustawione przez dewelopera/wydawcę i to do nich należy jak szybkie karty są upuszczane. Większość gier pojawia się po 1 kropli na 30 minut gry, ale są także gry, które wymagają od Ciebie grania nawet kilka godzin przed wyrzuceniem karty. Ponadto Twoje konto może być ograniczone przez otrzymywanie kart z gier, które jeszcze nie grałeś, jak podano w sekcji **[wydajność](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Nie próbuj robić odgadnięć, jak długo ASF powinno dawać tytuł - nie zależy od ciebie, ani od ASF. Nie możesz nic zrobić, aby uczynić to szybciej, i nie ma "błędu" związanego z nieupuszczaniem kart w odpowiednim czasie - nie kontrolujesz procesu upuszczania kart ani ASF. W najlepszym przypadku otrzymasz średnio 1 kroplę na 30 minut. W najgorszym przypadku nie otrzymasz żadnej karty nawet przez 4 godziny od rozpoczęcia ASF. Obie te sytuacje są normalne i uwzględnione w sekcji **[wydajność](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**.

---

### Rolnictwo trwa zbyt długo, czy mogę to przyspieszyć?

Jedyną rzeczą, która w dużym stopniu wpływa na prędkość chowu, jest wybrana **[karty rolnicze](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** dla twojego bota. Wszystko inne ma znikomy wpływ i nie przyspieszy rolnictwa, podczas gdy niektóre działania, takie jak wielokrotne uruchamianie procesu ASF, nawet **pogorszą to**. Jeżeli naprawdę wzywa się do uczynienia co sekundę z procesu produkcji rolnej, następnie ASF pozwala dostosować niektóre podstawowe zmienne rolnicze, takie jak `FarmingDelay` - wszystkie są wyjaśnione w **[konfiguracja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Jednakże, jak już powiedziałem, skutki są znikome, wybór właściwego algorytmu rolniczego kart dla danego rachunku jest jednym i jedynym decydującym wyborem, który może w znacznym stopniu wpłynąć na prędkość rolnictwa, wszystko inne jest czystym kosmetykiem. Zamiast martwić się o szybkość produkcji rolnej, po prostu uruchom ASF i pozwolę sobie wykonać swoje zadanie - mogę państwa zapewnić, że robi to w najbardziej efektywny sposób, jaki mogłbym wymyślić. Im mniej cię opiekujesz, tym więcej cię usatysfakcjonuje.

---

### Ale ASF powiedział, że rolnictwo zajmie około X razy!

ASF daje przybliżone przybliżenie w oparciu o liczbę kart potrzebnych do upuszczenia, i wybrany przez Ciebie algorytm - nie jest on w żadnym miejscu zbliżony do czasu jaki będziesz spędzać na rolnictwie, który jest zazwyczaj dłuższy niż ten, ponieważ ASF przyjmuje tylko najlepsze przykłady i ignoruje wszystkie zapytania sieci Steam, odłączenia internetowe, przeciążenie serwerów Steam i podobne. Należy postrzegać jedynie jako ogólny wskaźnik, jak długo można oczekiwać, że ASF będzie uprawiać, bardzo często w najlepszym przypadku, ponieważ w niektórych przypadkach czas rzeczywisty będzie się znacznie różnił. Jak wskazano powyżej, nie próbuj zgadywać, jak długo gra będzie farmowana, nie zależy od ciebie, ani od ASF.

---

### Czy ASF może pracować na moim telefonie/smartfonie?

ASF jest programem C# wymagającym prawidłowego wdrożenia .NET. Android stał się poprawną platformą zaczynającą się od .NET 6. , jednak obecnie istnieje główny bloker tworzenia ASF na Androidzie z powodu **[braku ASP. ET runtime dostępny na nim](https://github.com/dotnet/aspnetcore/issues/35077)**. Mimo że nie ma dostępnej opcji natywnej, istnieją odpowiednie i funkcjonujące wersje GNU/Linux na architekturze ARM, więc całkowicie możliwe jest użycie czegoś takiego jak **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** do instalacji Linux, następnie użycie ASF w takim chroot Linux jak zwykle.

Kiedy/Jeśli wszystkie wymagania ASF zostaną spełnione, rozważymy wydanie oficjalnej wersji Android.

---

### Czy ASF może obsługiwać przedmioty z gier parowych, takie jak CS:GO czy Unturne?

**No**, Jest to sprzeczne z **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** i zawór wyraźnie stwierdził, że z ostatnią falą zakazów społeczności dla przedmiotów TF2. ASF jest programem rolniczym kart Steam, a nie rolnikiem przedmiotów do gry - nie ma żadnych możliwości w zakresie przedmiotów do gry rolniczej, i nie planuje się dodawania tej funkcji w przyszłości, kiedykolwiek z powodu naruszenia warunków korzystania ze Steam. Proszę, nie pytajcie o to - najlepszą rzeczą jest sprawozdanie od jakiegoś sałatowego użytkownika i masz problemy. To samo dotyczy wszystkich innych rodzajów rolnictwa, takich jak spadek produkcji rolnej z nadawców CS:GO. ASF koncentruje się wyłącznie na kartach transakcyjnych Steam.

---

### Czy mogę wybrać, które gry powinny być uprawiane?

**Tak**, na kilka różnych sposobów. Jeśli chcesz zmienić domyślną kolejkę rolniczą, potem to jest to, do czego można użyć `FarmingOrders` **format@@2[konfiguracja bota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**. Jeśli chcesz ręcznie dodać do czarnej listy gry, które będą automatycznie produkowane, możesz użyć bezczynności czarnej listy, która jest dostępna z poleceniem `fb` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. If you'd like to farm everything but give some apps priority over everything else, that is what idle priority queue available with `fq` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** can be used for. And finally, if you want to farm specific games of your choice only, then you can declare `FarmPriorityQueueOnly` in bot's **[`FarmingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)** in order to achieve this, together with adding your selected apps to idle priority queue.

In addition to managing automatic cards farming module which was described above, you can also switch ASF to manual farming mode with `play` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, or use some other misc external settings such as `GamesPlayedWhileIdle` **[bot configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

---

### Nie jestem zainteresowany kroplami kart, zamiast tego chciałbym rozegrać godziny na farmie, czy to możliwe?

Tak, ASF pozwala na to zrobić przynajmniej na kilka sposobów.

Najlepszym sposobem osiągnięcia tego celu jest wykorzystanie właściwości konfiguracji **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** , który odtwarza wybrane przez Ciebie identyfikatory aplikacji, gdy ASF nie ma żadnych kart do hodowli. Jeśli chcesz grać w swoje gry przez cały czas, nawet jeśli masz karty z innych gier, następnie możesz połączyć go z **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, więc ASF będzie prowadził tylko te gry dla kropli karty, które wyraźnie ustawiłeś lub alternatywnie, **[`FarmingPausedByDefault`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**co spowoduje, że moduł rolniczy zostanie wstrzymany, dopóki nie zniesz go sam.

You can also make use of the **[`play`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#commands-1)** command, which will cause ASF to play your selected games. Pamiętaj, że `play` powinien być używany tylko do gier, które chcesz tymczasowo grać, ponieważ nie jest to stan trwały, powodując powrót ASF do stanu domyślnego. . po odłączeniu od sieci Steam. Dlatego zalecamy użycie `GamesPlayedWhileIdle`, chyba że faktycznie chcesz rozpocząć wybrane gry tylko przez krótki okres czasu, a następnie powrócić do ogólnego przepływu.

---

### Jestem użytkownikiem Linux / macOS, czy gry ASF farm nie są dostępne dla mojego systemu operacyjnego? Czy ASF farm 64-bitowe gry kiedy uruchamiam je na 32-bitowym systemie operacyjnym?

Tak, ASF nawet nie przeszkadza z pobieraniem rzeczywistych plików gry, więc będzie działać z wszystkimi licencjami związanymi z Twoim kontem Steam, niezależnie od jakichkolwiek platform czy wymagań technicznych. Powinien on również działać dla gier związanych z określonym regionem (gry zablokowane w regionie), nawet jeśli nie jesteś w regionie pasującym, chociaż nie gwarantujemy tego (to działało ostatnio próbowaliśmy).

---

## Porównanie z podobnych narzędzi

---

### Czy ASF jest podobny do Idle Master?

Jedynym podobieństwem jest ogólny cel obu programów, którym jest uprawianie gier Steam w celu otrzymywania kropli kartowych. Wszystko inne, w tym rzeczywista metoda chowu, struktura programu, funkcjonalność, kompatybilność, stosowane algorytmy, w szczególności sam kod źródłowy, jest zupełnie inny i te dwa programy nie mają nic wspólnego ze sobą, nawet podstawowe fundamenty - IM działa . ET Framework, ASF na .NET (Core). ASF został utworzony w celu rozwiązania problemów z IM, które nie były możliwe przy pomocy prostej edycji kodu - dlatego ASF został napisany od zera, bez używania jednej linii kodowej lub nawet ogólnego pomysłu od IM, ponieważ ten kod i te pomysły były całkowicie wadliwe na początku. IM i ASF są takie jak Windows i Linux - oba są systemami operacyjnymi i mogą być zainstalowane na Twoim komputerze, ale prawie nic się nie dzieli, oprócz służenia podobnym celom.

Dlatego też nie powinieneś porównywać ASF z IM w oparciu o oczekiwania IM. Powinieneś traktować ASF i IM jako całkowicie niezależne programy z własnymi ekskluzywnymi zestawami funkcji. Niektóre z nich nakładają się na siebie i można znaleźć w obu tych elementach, lecz bardzo rzadko, ponieważ ASF realizuje swój cel przy całkowicie innym podejściu niż IM.

---

### Czy warto użyć ASF, jeśli obecnie używam Idle Master i to dla mnie dobrze działa?

**Użytkownik:** %s ASF jest o wiele bardziej niezawodny i zawiera wiele wbudowanych funkcji, które są **kluczowe** niezależnie od sposobu chowu, Ten IM po prostu nie oferuje.

ASF posiada właściwą logikę dla **niezwolnionych gier** - IM spróbuje polować gry, które już dodały karty, nawet jeśli nie zostały jeszcze uwolnione. Oczywiście nie jest możliwe prowadzenie tych gier do daty wydania, więc Twój proces rolniczy zostanie utknięty. To będzie wymagało dodania go do czarnej listy, poczekaj na wydanie lub pominąć ręcznie. Żadne z tych rozwiązań nie jest dobre i wszystkie z nich wymagają Twojej uwagi - ASF automatycznie pomija rolnictwo niezwolnionych gier (tymczasowo), i wracają do nich później, kiedy tylko się znajdują, całkowicie unikając problemu i skutecznie się nim zajmują.

ASF also has proper logic of **series** videos. Na platformie Steam jest wiele filmów, które mają karty, ale są one ogłaszane z niewłaściwym `appID` na stronie odznaki, takie jak **[Dwustronna Przygoda](https://store.steampowered.com/app/402590)** - IM fałszywie zły rolnik `appID`, co nie spowoduje utknięcia kropli i procesu. Po raz kolejny musisz dodać do czarnej listy lub pominąć ręcznie - obie wymagają Twojej uwagi. ASF automatycznie odkryje poprawny `appID` dla celów rolniczych, co powoduje odrzuty karty.

Dodatkowo, ASF jest **o wiele bardziej stabilny i niezawodny** w przypadku problemów z siecią i zapytań Steam - działa większość czasu i w ogóle nie wymaga Twojej uwagi w momencie skonfigurowania, podczas gdy IM często przerywa się dla wielu ludzi, wymaga dodatkowych poprawek lub po prostu nie działa bez poprawy. Jest również w pełni zależny od Twojego klienta Steam, co oznacza, że nie może działać kiedy klient Steam doświadcza żadnych poważnych problemów. ASF działa poprawnie, o ile może podłączyć się do sieci Steam i nie wymaga od klienta Steam działającego lub nawet zainstalowanego.

Są to 3 **bardzo ważne** punkty, dla których należy rozważyć użycie ASF, ponieważ mają one bezpośredni wpływ na wszystkie hodowlane karty parowe i nie ma możliwości powiedzenia "to mnie nie uważa”, ponieważ serwisy serwisowe i biurowe są dostępne dla wszystkich. Istnieje tuzina dodatkowych mniej i ważniejszych powodów, o których możesz dowiedzieć się w pozostałych FAQ. Krótko mówiąc, **tak**, powinieneś używać ASF nawet wtedy, gdy nie potrzebujesz żadnych dodatkowych funkcji ASF dostępnych w porównaniu z IM.

Ponadto oficjalnie zaprzestano stosowania IM i w przyszłości może się całkowicie złamać. bez kimkolwiek zwłoki do naprawienia tego problemu, biorąc pod uwagę istnienie dużo potężniejszych rozwiązań (nie tylko ASF). IM już nie działa dla wielu ludzi, a ta liczba rośnie, a nie spada. W pierwszym rzędzie należy unikać używania przestarzałego oprogramowania, nie tylko IM, ale również wszystkich innych przestarzałych programów. Żaden aktywny opiekun nie oznacza, że nikt nie zastanawia się, czy działa, a **nikt nie jest odpowiedzialny za jego funkcjonalność**, co jest kwestią o zasadniczym znaczeniu dla bezpieczeństwa. Wystarczy, że pojawi się krytyczny błąd powodujący rzeczywiste problemy dla infrastruktury Steam - nikt go nie naprawi, Steam może wydać kolejną falę banów, w której zostaniesz uderzony, nawet nie będąc świadomym tego problemu, jak to już się stało z ludźmi używającymi, zgadaj, co przestarzała wersja ASF.

---

### Jakie interesujące funkcje ASF oferuje Idle Master nie?

To zależy od tego, co uważasz za „interesujące”. Jeśli planujesz gospodarstwo więcej niż jeden, odpowiedź jest już oczywista, ponieważ ASF pozwala na gospodarstwo wszystkich z nich jednym nadrzędnym rozwiązaniem, oszczędzanie zasobów, trudności i problemy związane z kompatybilnością. Jeśli jednak zadasz to pytanie, najprawdopodobniej nie masz tej szczególnej potrzeby, więc dokonajmy oceny innych świadczeń, które mają zastosowanie do jednego konta używanego w ASF.

Przede wszystkim, masz kilka wbudowanych funkcji wymienionych **[powyżej](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** , które są rdzeniem gospodarki niezależnie od celu końcowego, i bardzo często już to samo w sobie wystarczy do rozważenia stosowania ASF. Ale już to wiesz, więc przejdźmy do kilku bardziej interesujących funkcji:

- **Możesz farm offline** (`OnlineStatus` w ustawieniach `Offline`. Rolnictwo offline umożliwia Ci całkowite pominięcie statusu Steam w grze, który pozwala na prowadzenie hodowli z ASF podczas wyświetlania "Online" w Steam w tym samym czasie, bez zauważenia, że ASF gra w Twoją grę. Jest to lepsza funkcja, ponieważ pozwala Ci pozostać online w Twoim kliencie Steam, nie denerwując znajomych z ciągłymi zmianami w grze, lub wprowadzając ich w błąd myśli, że grasz w grę, podczas gdy w rzeczywistości nie jesteś. Sam ten punkt sprawia, że warto korzystać z ASF, jeśli szanujesz własnych przyjaciół, ale to dopiero początek. Miło jest również zauważyć, że ta funkcja nie ma nic wspólnego z ustawieniami prywatności Steam - jeśli sam uruchomisz grę, wtedy pokażesz swoim znajomym w grze, co sprawia, że tylko część ASF jest niewidoczna i w ogóle nie wpływa na Twoje konto.

- **You can skip refundable games** (`SkipRefundableGames` in bot's `FarmingPreferences` feature). ASF ma właściwą wbudowaną logikę dla gier podlegających zwrotowi i możesz skonfigurować ASF do gier niepodlegających zwrotowi automatycznie. Pozwala Ci to ocenić, czy twoja nowo zakupiona gra w sklepie Steam była warta Twoich pieniędzy, bez próby jak najszybszego wyrzucenia z niego kart ASF. Jeśli grasz na 2+ godzin lub minęły 2 tygodnie od zakupu, wtedy ASF będzie kontynuował tę grę, ponieważ nie będzie już zwracana. Do tego czasu masz pełną kontrolę nad tym, czy cieszy się Pan/Pani przyjemnością czy nie, i w razie potrzeby można z łatwością zwrócić pieniądze, bez konieczności ręcznego umieszczania tej gry na czarnej liście lub nieużywania ASF przez cały czas.

- **Możesz pominąć niezagrane gry** (`Pomiń Nieodtwarzane gry` w funkcji `FarmingPreferences`. ASF ma właściwą wbudowaną logikę dla godzin w grach i możesz skonfigurować ASF, aby nie grać w gry bez gry. Pozwala Ci to kontrolować gry grane i farmy bez konieczności ręcznego dodawania ich do czarnej listy lub pomijania całkowicie z ASF.

- **Możesz automatycznie oznaczać nowe przedmioty jako otrzymane** (funkcja`BotBehaviour` of `DismissInventoryNotifications`) Rolnictwo za pomocą ASF spowoduje otrzymanie nowych kart przez Twoje konto. Już wiesz, że tak się stanie, więc pozwól, aby ASF wyjaśnił, że bezużyteczne powiadomienia dla Ciebie, zadbanie o to, by tylko ważne sprawy zwróciły państwa uwagę. Oczywiście, tylko jeśli chcesz.

- **Możesz dostosować preferowaną kolejność rolniczą z większą liczbą dostępnych opcji** (funkcja`Zamówienia rolnicze`. Być może chcesz najpierw zagospodarować swoje nowo zakupione gry? Lub najstarszych? Według liczby upuszczeń kart? Poziomy odznak, które już stworzyłeś? Przegrane godziny? Alfabetycznie? Według AppID? Czy może być w pełni losowy? To do ciebie należy decyzja.

- **ASF może pomóc Ci w ukończeniu zestawu** (`TradingPreferences` z funkcją `SteamTradeMatcher`. Z nieco bardziej zaawansowanym oponowaniem, możesz przekonwertować ASF na w pełni funkcjonalnego bota użytkownika, który automatycznie zaakceptuje oferty **[STM](https://www.steamtradematcher.com)** , pomagając Ci każdego dnia dopasować zestawy bez interakcji z użytkownikami. ASF zawiera nawet swój własny moduł ASF 2FA, który pozwala importować swój mobilny uwierzytelniacz Steam i pozwoli Ci w pełni zautomatyzować cały proces z akceptacją potwierdzeń. Albo może chcesz zaakceptować ręcznie i pozwolić ASF na przygotowanie tylko tych transakcji dla Ciebie? To jeszcze raz w pełni zależy od Ciebie.

- **ASF może wymieniać klucze w tle dla ciebie** (funkcja**[w grach w tle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. Być może masz sto kluczy z różnych pakietów, które jesteś zbyt leniwy, aby umorzyć, przechodzenie przez kilka okien i wyrażanie zgody na nieustanne warunki Steam. Dlaczego nie skopiować/wkleić listy kluczy do ASF i pozwolić mu wykonać swoje zadanie? ASF automatycznie wyrealizuje wszystkie klucze w tle, zapewniając Ci odpowiednie dane wyjściowe, aby wiedzieć jak każda próba wykupu się pojawiła. Co więcej, jeśli masz setki kluczy, masz gwarancję, że Steam ograniczy szybciej lub później szybciej, i ASF wie o tym również cierpliwie poczekają aż limit szybkości spadnie i wróci do miejsca, w którym pozostało.

Możemy teraz kontynuować z całym **[ASF wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**, wskazywanie każdej cechy programu, ale musimy gdzieś narysować linię. To jest ta lista funkcji, które możesz cieszyć się jako użytkownik ASF, gdzie tylko jeden z nich można z łatwością uznać za główny powód, aby nigdy nie spojrzeć wstecz, i w rzeczywistości umieściliśmy listę **wiele** , a jeszcze więcej możesz dowiedzieć się więcej na pozostałych stronach naszej wiki. Ah Tak, a nawet nie poszliśmy w szczegółach takich rzeczy jak API ASF, które pozwalają zaszyfrować własne komendy; lub niesamowitym zarządzaniem botami, ponieważ chcieliśmy zachować to prosto.

---

### Czy ASF jest szybszy od Idle Mastera?

**Tak**, chociaż wyjaśnienie jest dość skomplikowane.

Przy każdym nowym procesie pojawił się i zakończył w Twoim systemie, klient Steam automatycznie wysyła żądanie zawierające wszystkie Twoje gry, które aktualnie grasz. W ten sposób sieć Steam może obliczyć godziny i zrzucić kartę. Jednak sieć Steam liczy Twój czas grany w 1-sekundowe przedziały, a wysłanie nowego żądania resetuje aktualny status. Innymi słowy, jeśli tworzyłeś/zabiłeś nowy proces co 0,5 sekundy, nigdy nie wyrzucisz żadnej karty, ponieważ co 0. drugi klient Steam wysłałby nowe żądanie, a sieć Steam nigdy nie liczyłaby nawet 1 sekundę czasu gry. Ponadto, ze względu na działanie systemu operacyjnego, dość często widać, że nowe procesy pojawiają się lub kończą bez robienia czegokolwiek, więc nawet jeśli nie robisz nic na swoim komputerze - jest wiele procesów nadal działa w tle, tworzyć/zamykając inne procesy przez cały czas. Bezczynny mistrz opiera się na kliencie parowym, więc ten mechanizm wpływa na Ciebie, jeśli go używasz.

ASF nie opiera się na kliencie Steam, ma własną implementację klienta Steam. Dzięki temu ASF nie powraca żadnego procesu, ale w rzeczywistości wysyła jedną, prawdziwą prośbę do sieci Steam, że zaczęliśmy grać w grę. To jest ta sama prośba, która zostałaby wysłana przez klienta Steam, ale ponieważ mamy faktyczną kontrolę nad klientem pary ASF, nie musimy tworzyć nowych procesów, i nie miemy się z klientem Steam w związku z wysyłaniem żądań przy każdej zmianie procesu, więc powyższy mechanizm nie ma wpływu na nas. Dzięki temu nigdy nie przerywamy tej drugiej przerwy po stronie parowej, co zwiększa szybkość produkcji rolnej.

---

### Ale czy różnica jest naprawdę zauważalna?

Nie. Przerwy występujące z normalnym klientem pary wodnej i bezczynnym kierownikiem mają nieistotny wpływ na krople karty, więc nie ma zauważalnej różnicy, która sprawiłaby przewagę ASF.

Jednak **jest** różnicą i możesz wyraźnie zauważyć, że w zależności od tego, jak zajęty jest Twój system operacyjny, Karty **będą** spadać szybciej, z kilku sekund do kilku minut, jeśli jesteś niezwykle nieszczęśliwy. Chociaż nie rozważałbym użycia ASF tylko dlatego, że porusza karty szybciej, ponieważ zarówno ASF, jak i Idle Master mają wpływ na działanie sieci Steam, ASF tylko bardziej skutecznie oddziałuje z parą wodną, podczas gdy Idle Master nie może kontrolować tego, co klient Steam faktycznie robi (więc nie jest to usterka Idle Master, ale sam klient Steam).

---

### Czy ASF może prowadzić wiele gier jednocześnie?

**Yes**, although ASF knows better when to use that feature, based on selected **[cards farming algorithm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Wskaźnik spadków karty, gdy rolnictwo wielu gier jest bliskie zeru, właśnie dlatego ASF używa wielu gier uprawianych wyłącznie przez godziny w celu przezwyciężenia `HoursUntilCardDrops` szybciej, dla gier do `32` naraz. Dlatego też powinieneś skupić się na części konfiguracji ASF, i pozwól, aby algorytmy decydowały, co jest najlepszym sposobem na osiągnięcie tego celu - co uważasz za słuszne, niekoniecznie jest w rzeczywistości, rolnictwo wielu gier na raz nie dostarczy Ci żadnych kropel karty.

---

### Czy ASF może pominąć gry szybko?

**No**, ASF nie obsługuje, ani nie zachęca do używania **[glitches](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance#steam-glitches)**.

---

### Czy ASF może automatycznie grać w każdą grę przez X godzin przed dodaniem kart?

**No**, całym punktem zmiany w systemie kart Steam była walka z fałszywymi statystykami i graczami z duchami. ASF nie przyczyni się do tego bardziej niż jest to konieczne, dodanie tej funkcji nie jest planowane i nie będzie miało miejsca. Jeśli twoja gra otrzymuje krople karty w zwykły sposób, ASF jak najszybciej je hoduje.

---

### Czy mogę zagrać w grę, gdy ASF jest rolnikiem?

**Nr**. ASF, w przeciwieństwie do innych narzędzi, które integrują się z Twoim klientem Steam, posiada jego niezależną implementację do tego klienta, i sieć Steam pozwala tylko **jednemu klientowi Steam w czasie** grać. Możesz jednak odłączyć ASF w dowolnym momencie, gdy chcesz, rozpoczynając grę (oraz klikając "OK" kiedy zapytasz, czy sieć Steam powinna odłączyć innego klienta) - ASF będzie cierpliwie czekać, aż skończysz grać, a następnie wznowić proces. Alternatywnie, nadal możesz grać w trybie offline w dowolnym momencie, jeśli to dla Ciebie satysfakcjonuje.

Pamiętaj, że wskaźnik upuszczania kart podczas gry w wielu grach i tak jest bliski zeru, w związku z tym nie ma żadnych bezpośrednich korzyści z możliwości korzystania z kilku innych narzędzi, choć istnieją znaczne korzyści z braku ingerencji w inne gry uruchamiane za pomocą ASF, co ma kluczowe znaczenie. . VAC-wise.

---

## Bezpieczeństwa / prywatności / VAC / bany / ToS

---

### Czy mogę dostać banowanie VAC za jego użycie?

Nie, nie jest to możliwe, ponieważ ASF (w przeciwieństwie do niektórych innych narzędzi, takich jak Idle Master, Usługi świadczone w ogólnym interesie gospodarczym lub SAM) nie zakłócają w żaden sposób klienta parowego ani jego procesów. fizycznie niemożliwe jest uzyskanie banu VAC za korzystanie z ASF, nawet podczas odtwarzania na zabezpieczonych serwerach, gdy ASF jest uruchomiony - dzieje się tak dlatego, że **ASF nawet nie wymaga zainstalowania Steam Client w ogóle** w celu poprawnego działania. ASF jest jednym z jedynych programów rolniczych, które obecnie mogą gwarantować brak VAC.

---

### Czy korzystanie z ASF uniemożliwia mi granie na serwerach zabezpieczonych przez VAC, jak stwierdzono **[tutaj](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**?

ASF nie wymaga, aby klient Steam był w ogóle uruchomiony, a nawet zainstalowany. According to this concept, it should **not** cause any VAC-related issues, because ASF guarantees lack of interfering with Steam client and all its processes - this is the main point when talking about VAC-free guarantee that ASF offers.

Według użytkowników i mojej najlepszej wiedzy to właśnie teraz, ponieważ nikt nie zgłosił żadnych problemów takich jak podane w linku powyżej podczas korzystania z ASF. Nie mogliśmy odtworzyć problemu z ASF i jednoznacznie go odtwarzać z Idle Master.

Należy jednak pamiętać, że Głowica może w pewnym momencie dodać ASF do czarnej listy, ale to kompletny nonsens, nawet jeśli to robią, nadal możesz grać w gry zabezpieczone przez VAC z komputera i używać ASF w tym samym czasie. . na Twoim serwerze, więc jestem pewien, że doskonale wiedzą, że ASF nie powinno być podejrzanym VAC, i nie sprawią, że nasze życie będzie utrudnione przez ASF na czarnej liście bez powodu. Nadal w najgorszym przypadku nie będziesz w stanie grać, jak stwierdzono wyżej, ponieważ gwarancja ASF bez VAC jest nadal tutaj, niezależnie od tego, czy Steam czarna lista binarna ASF, lub nie (i nadal możesz uruchomić ASF na dowolnym innym urządzeniu bez zainstalowania klienta Steam). Obecnie nie ma potrzeby żadnego z tych działań i miejmy nadzieję, że tak się stanie.

---

### Czy to jest bezpieczne?

Jeśli zapytasz, czy ASF jest bezpieczny jako oprogramowanie, co oznacza, że nie spowoduje żadnych obrażeń dla komputera, nie kradnie Twoich prywatnych danych, wirusów ani żadnych innych rzeczy takich jak ta - jest bezpieczna. ASF jest wolny od złośliwego oprogramowania, kradzieży danych, wydobywcy kryptowalut i wszelkie (i wszystkie) inne wątpliwe zachowanie, które mogą zostać uznane za złośliwe lub niechciane przez użytkownika. Ponadto mamy specjalną sekcję **[zdalna komunikacja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** obejmującą naszą politykę prywatności i zachowanie ASF, która wykracza poza to, co skonfigurowałeś do samodzielnego działania.

Nasz kod jest open source, i rozproszone pliki binarne są zawsze kompilowane z **[publicznie dostępnych źródeł](https://en.wikipedia.org/wiki/Open-source_software)** przez **[zautomatyzowane i zaufane systemy ciągłej integracji](https://en.wikipedia.org/wiki/Build_automation)**, a nawet samych deweloperów. Każda kompilacja jest odtwarzalna za pomocą naszego skryptu budowy, a jej wynik będzie dokładnie taki sam, **[deterministyczny](https://en.wikipedia.org/wiki/Deterministic_system)** IL (binarny) kod. Jeśli z jakiegokolwiek powodu nie ufasz naszym kompilacjom, zawsze możesz kompilować i używać ASF ze źródła, włączając w to wszystkie biblioteki, których ASF używa (takie jak SteamKit2), które również są otwartym oprogramowaniem.

Ostatecznie jednak zawsze jest to kwestia zaufania dla programistów Twojej aplikacji. więc powinieneś samodzielnie zdecydować, czy uważasz, że ASF jest bezpieczny czy nie, potencjalnie potwierdzając swoją decyzję argumentami technicznymi określonymi powyżej. Proszę nie myśleć w coś tylko dlatego, że tak powiedzieliśmy, - sprawdź siebie, ponieważ jest to jedyny sposób na pewność.

---

### Czy mogę za to dostać bana?

Aby odpowiedzieć na to pytanie, powinniśmy przyjrzeć się bliżej **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Steam nie zakazuje korzystania z wielu kont w rzeczywistości **[pozwala na](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)** , co oznacza, że możesz użyć tego samego uwierzytelniającego mobilnego na więcej niż jednym koncie. Jednak nie pozwala na dzielenie się kontami z innymi ludźmi, ale nie robimy tego tutaj.

Jedyną realną kwestią, która uważa ASF, jest:
> Nie możesz używać czeków, oprogramowania automatyzacyjnego (botów), modów, hakerów ani żadnego innego nieautoryzowanego oprogramowania firm trzecich, aby modyfikować lub zautomatyzować proces Subskrypcji Marketplace.

Pytanie brzmi, co w rzeczywistości jest procesem Marketplace subskrypcji. Jak możemy czytać:

> Przykładem rynku subskrypcji jest Rynek Społeczności Steam

Nie modyfikujemy ani nie automatyzujemy procesu subskrypcji Marketplace jeśli przez subskrypcję rynek rynkowy rozumiemy rynek społecznościowy parowy lub sklep parowy. Jednak...

> Głowica może anulować Twoje konto lub jakąkolwiek konkretną(-e) subskrypcję(-e) w dowolnym momencie, w przypadku gdy a) zawór przestanie dostarczać takie subskrypcje ogólnie dla podobnie usytuowanych subskrybentów, lub b) naruszają Państwo jakiekolwiek warunki niniejszej Umowy (w tym wszelkie warunki subskrypcji lub zasady użytkowania).

Dlatego, tak jak w przypadku każdego oprogramowania Steam, ASF nie jest autoryzowany przez Głowicę i nie mogę zagwarantować, że nie zostaniesz zawieszony, jeśli Głowica nagle zdecyduje, że teraz zbanują konta używające ASF. Jest to bardzo mało prawdopodobne, biorąc pod uwagę fakt, że ASF jest wykorzystywane na ponad kilka milionów kont Steam, od czasu pierwszego uwolnienia, które miało miejsce ponad 10 lat temu - ale nadal istnieje możliwość, niezależnie od rzeczywistego prawdopodobieństwa.

W szczególności ponieważ:
> W odniesieniu do wszystkich subskrypcji, treści i usług, które nie są autorem zaworu, Zawór nie wyświetla takich treści stron trzecich dostępnych na Steam ani za pośrednictwem innych źródeł. Głowica nie ponosi odpowiedzialności ani odpowiedzialności za takie treści osoby trzeciej. Niektóre oprogramowanie zewnętrzne może być wykorzystywane przez przedsiębiorstwa do celów biznesowych – jednakże możesz nabyć takie oprogramowanie tylko za pośrednictwem Steam do osobistego użytku.

Jednakże Głowica wyraźnie potwierdza istnienie "Steam iders", jak stwierdzono **[tutaj](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**, więc jeśli mnie o to poprosiłeś, Jestem pewien, że jeśli nie byli w porządku, zrobiliby już coś zamiast wskazać, że mogą powodować problemy VAC-wise. Słowo kluczowe tutaj to **Steam** idler, na przykład ASF, a nie **gra**.

Pamiętaj, że powyżej jest tylko nasza interpretacja **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** i różnych punktów - ASF jest licencjonowana w Apache 2. Licencja, która wyraźnie określa:

```
O ile nie jest to wymagane przez prawo właściwe lub nie zostało uzgodnione na piśmie, oprogramowanie
dystrybuowane na podstawie licencji jest rozpowszechniane na BASIS „AS IS”,
BEZ GWARANCJI LUB WARUNKÓW JAKOŚCI KIND, wyrażonych lub dorozumianych.
```

Używasz tego oprogramowania na własne ryzyko. Jest bardzo mało prawdopodobne, aby można było za to zakazać, ale jeśli tak zrobisz, można za to obwinić tylko siebie.

---

### Czy ktoś został na to zbanowany?

**Tak**mieliśmy do tej pory co najmniej kilka incydentów, które doprowadziły do pewnego rodzaju zawieszenia. Czy ASF jest główną przyczyną czy nie jest zupełnie inną historią, której prawdopodobnie nigdy nie będziemy się dowiedzieć.

Pierwszy przypadek dotyczył gościa z ponad 1000 botów objętych zakazem handlu (razem ze wszystkimi botami), najprawdopodobniej ze względu na nadmierne użycie `loot ASF` wykonywane na wszystkich botach jednocześnie, lub innych podejrzanych transakcji jednostronnych w bardzo krótkim czasie.

> Witaj XXX, Dziękujemy za skontaktowanie się z działem wsparcia Steam. Wygląda na to, że to konto zostało użyte do zarządzania siecią kont botów. Botting jest pogwałceniem umowy o subskrybentach Steam.

Proszę, używaj zdrowego rozsądku i nie zakładaj, że możesz robić tak szalone rzeczy tylko dlatego, że ASF pozwala ci to zrobić. Wykonanie `loot ASF` na ponad 1 k botów można z łatwością uznać za **[DDoS](https://en.wikipedia.org/wiki/DDoS)** , i osobiście nie jestem zszokowany, że ktoś został zbanowany na takie rzeczy. Zachowaj minimum uczciwego korzystania z usługi Steam i **najprawdopodobniej** będziesz w porządku.

Druga sprawa dotyczyła gościa z ponad 170 botami zbanowanego podczas zimowej sprzedaży Steam 2017 r.

> Twoje konto zostało zablokowane z powodu naruszenia umowy Steam subskrybenta. Sądząc po giełdach i innych czynnikach, konto to zostało wykorzystane do nielegalnego pobierania kart ściągalnych na Steam, a także działalności powiązanej, a nie tylko handlowej. Konto zostało trwale zablokowane i obsługa Steam nie może zapewnić dodatkowego wsparcia w tym problemie.

Ten przypadek jest po raz kolejny bardzo trudny do przeanalizowania ze względu na niejasną odpowiedź ze strony wsparcia Steam, która praktycznie nie oferuje żadnych szczegółów. Na podstawie moich osobistych przemyśleń, ten użytkownik prawdopodobnie wymienił karty Steam na jakiś rodzaj pieniędzy (podnoś poziom bota? lub w inny sposób próbował wypłacić na Steam. Jeśli nie wiesz, jest to również nielegalne zgodnie z **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Nie jesteśmy w stanie ci powiedzieć, co możesz zrobić z kartami handlowymi otrzymanymi za pośrednictwem ASF - ale dany użytkownik zdecydowanie nie tylko wytwarzał z nimi odznaki.

Trzecia sprawa dotyczyła użytkownika z ponad 120+ botów zbanowanych z powodu naruszenia **[Steam online](https://store.steampowered.com/online_conduct?l=english)**.

> Witaj XXX, Dziękujemy za skontaktowanie się z działem wsparcia Steam. Te i inne konta zostały wykorzystane do zatopienia naszej infrastruktury sieciowej, co stanowi naruszenie zachowania Steam online. Konto zostało trwale zablokowane i obsługa Steam nie może zapewnić dodatkowego wsparcia w tym problemie.

Ten przypadek jest nieco łatwiejszy do przeanalizowania ze względu na dodatkowe szczegóły podane przez użytkownika. Wygląda na to, że użytkownik używał **bardzo przestarzałej wersji ASF** , która zawierała błąd powodujący wysyłanie zbyt dużej liczby żądań do serwerów Steam. Sam błąd nie istniał na początku, ale został aktywowany z powodu zmiany łamania Steam, która została naprawiona w przyszłej wersji. **ASF jest obsługiwany tylko w [najnowszej stabilnej wersji](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) wydanej na GitHub**.

Nie można założyć, że jakaś przestarzała wersja ASF będzie działać tak samo, jak używana do pracy na zawsze, zwłaszcza dlatego, że Steam stale się zmienia niezależnie od tego, czy podoba Ci się czy nie. Jeśli coś takiego dzieje się globalnie, szybko jest on naprawiany i udostępniany wszystkim użytkownikom jako poprawka błędów. Zawór nie będzie nagle zakazywał ponad milion użytkowników ASF z powodu naszego lub ich błędu, z oczywistych powodów. Jeżeli jednak umyślnie rezygnujesz z korzystania z aktualnego ASF, następnie z definicji jesteś w bardzo małej liczbie użytkowników, którzy są narażeni **na zdarzenia takie jak** z powodu **bez wsparcia**, ponieważ nikt nie obserwuje twojej przestarzałej wersji ASF, nikt go nie naprawił i nikt nie zapewni, że nie zostaniesz całkowicie zbanowany tylko poprzez jego uruchomienie. **Użyj aktualnego oprogramowania**, nie tylko ASF, ale również wszystkich innych aplikacji.

Według użytkownika ostatni przypadek miał miejsce około czerwca 2021 r.:

> Korzystając z pańskiego programu, przygotowuję pakiety przypominające z 28 kontami przez 3 lata i 128 kont przez ostatnie 6 miesięcy. Byłem online z maksymalnie 15 kont jednocześnie, aby tworzyć pakiety wzmacniające i wysyłać je na główne konto. W ubiegłym miesiącu jednocześnie zwiększyłem liczbę kont internetowych do 20 i tydzień po tym okresie wszystkie moje konta zostały zablokowane. Wręcz przeciwnie, zawsze wiedziałem o konsekwencjach tej poczty elektronicznej. Chciałbym, abyś wiedział, jakie zachowania skutkują trwałym zakazem.

Trudno stwierdzić, czy wzrost liczby równoległych kont internetowych był bezpośrednim powodem zakazu, Nie liczę na to, zamiast tego uważam, że główną winą była sama liczba kont, więcej kont kont kont internetowych prawdopodobnie zwróciło uwagę na danego użytkownika, ponieważ ma on zdecydowanie więcej botów niż nasza rekomendacja.

---

Wszystkie powyższe zdarzenia mają jedną wspólną rzecz - ASF jest tylko narzędziem i jest **twoim** decydujesz, jak z niego korzystasz. Nie zostaniesz zbanowany za korzystanie z ASF bezpośrednio, ale dla **jak** używasz. Może to być narzędzie pomocne w rolnictwie tylko jednego konta, czy też masowa sieć rolnicza utworzona z tysięcy botów. W każdym razie nie oferuję porady prawnej i w pierwszym rzędzie powinieneś zdecydować się na korzystanie z ASF. Nie ukrywam żadnych informacji, które mogłyby Ci pomóc, np. fakt, że ASF jest zakazana (i w jakim kontekście), ponieważ nie mam powodu, aby - to wybrać co chcesz zrobić z tymi informacjami.

Jeśli mnie prosisz - użyj zdrowego rozsądku, unikaj posiadania większej liczby botów niż nasze zalecenia, nie wysyłaj setek transakcji w tym samym czasie, zawsze używaj aktualnej wersji ASF, a _powinien_ być w porządku. Every single incident of this nature for **some reason** always happened to people that have disregarded our recommendations, best practices and suggestions, believing that they know better than us e.g. how many bots they can run. Bez względu na to, czy jest to tylko zbieżność czy jakiś faktyczny czynnik, to do Ciebie należy decyzja. Nie oferujemy żadnej porady prawnej, dając Ci tylko nasze myśli, że możesz okazać się przydatny, lub lekceważy je w całości i działają wyłącznie na podstawie faktów z nimi związanych.

---

### Jakie informacje o ochronie prywatności ujawniają ASF?

Szczegółowe wyjaśnienie można znaleźć w sekcji **[zdalna komunikacja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. Powinieneś ją przejrzeć, jeśli dbasz o swoją prywatność, np. jeśli zastanawiasz się, dlaczego konta są używane w ASF dołączają do naszej grupy Steam. ASF nie gromadzi żadnych poufnych informacji i nie udostępnia ich osobom trzecim.

---

## Różne

---

### Używam niewspieranego systemu operacyjnego, takiego jak 32-bitowy Windows, czy mogę nadal używać najnowszej wersji ASF?

Tak, ta wersja nie jest w żaden sposób wspierana, po prostu nie jest formalnie budowana. Check out **[compatibility](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** section for generic variant. ASF nie ma żadnej silnej zależności od systemu operacyjnego i może działać gdziekolwiek możesz dostać pracę. ET runtime, który obejmuje 32-bitowe Windows, nawet jeśli nie ma od nas żadnego `win-x86`.

---

### ASF jest świetny! Czy mogę dokonać dotacji?

Tak, i bardzo cieszymy się, że lubisz nasz projekt! Możesz znaleźć różne możliwości darowizny pod każdym **[wydanie](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** oraz **[na stronie głównej](https://github.com/JustArchiNET/ArchiSteamFarm)**. Miło jest zauważyć, że oprócz ogólnych darowizn na pieniądze akceptujemy także przedmioty Steam, więc nic nie powstrzymuje cię przed oddawaniem skórek, kluczy lub niewielkiej części kart, które posiadasz za pomocą ASF, jeśli chcesz. Z góry dziękuję za swoją hojną witrynę!

---

### Używam kodu PIN rodzicielskiego Steam, aby chronić moje konto, czy muszę wprowadzić go gdzieś?

Tak, musisz ustawić to w konfiguracji bota `SteamParentalCode`. Dzieje się tak głównie dlatego, że ASF ma dostęp do wielu chronionych części Twojego konta Steam i nie jest możliwe, aby ASF działał bez niego.

---

### Nie chcę, aby ASF domyślnie prowadził żadne gry, ale chcę użyć dodatkowych funkcji ASF. Czy to możliwe?

Tak, jeśli chcesz uruchomić ASF z modułem rolniczym wstrzymanej karty, możesz ustawić `FarmingPausedByDefault` w `FarmingPreferences` właściwość konfiguracji bota aby to osiągnąć. Pozwoli to `wznowić` w czasie pracy.

Jeśli chcesz całkowicie wyłączyć moduł rolniczy kart i upewnij się, że nigdy nie będzie działał bez wyraźnego powiadomienia o tym w inny sposób, następnie zalecamy ustawienie `FarmPriorityQueueOnly` w botu `FarmingPreferences`, która zamiast po prostu zatrzymuje ją, całkowicie wyłączy rolnictwo dopóki nie dodasz gier do kolejki bezczynności.

Z modułem rolniczym wstrzymanym/wyłączonym, możesz użyć dodatkowych funkcji ASF, takich jak `GamesPlayedWhileIdle`.

---

### Czy ASF może zminimalizować do zasobnika?

ASF jest aplikacją konsoli, nie ma okna do zminimalizowania, ponieważ okno jest utworzone dla Ciebie przez system operacyjny. Możesz jednak użyć dowolnego narzędzia firm trzecich, takiego jak **[RBTray](https://github.com/benbuck/rbtray)** dla Windows, lub **[ekran](https://linux.die.net/man/1/screen)** dla Linux/macOS. Są to tylko przykłady, istnieje wiele innych aplikacji o podobnej funkcjonalności.

---

### Czy korzystanie z ASF zachowuje kwalifikowalność do otrzymywania pakietów uzupełniających?

**Tak**. ASF używa tej samej metody, aby zalogować się do sieci Steam co oficjalny klient, w związku z tym zachowuje możliwość otrzymywania pakietów przypominających na konta, które są wykorzystywane w ASF. Co więcej, zachowanie tej zdolności nie wymaga nawet zalogowania się do społeczności Steam, więc możesz bezpiecznie używać `OnlineStatus` w ustawieniach `Offline` jeśli chcesz.

---

### Czy jest jakiś sposób komunikowania się z ASF?

Tak, na kilka różnych sposobów. Check out **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** section for more info.

---

### Chciałbym pomóc w tłumaczeniu ASF, co muszę zrobić?

Dziękujemy za zainteresowanie! Wszystkie szczegóły znajdziesz w naszej sekcji **[lokalizacja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)**.

---

### Mam tylko jedno (główne) konto dodane do ASF, czy nadal mogę wydawać polecenia przez czat Steam?

**Yes**, jest to wyjaśnione w sekcji **[polecenia](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#notes)**. Możesz to zrobić przez czat grupowy Steam, chociaż użycie **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** może być dla Ciebie łatwiejsze.

---

### ASF wydaje się działać, ale nie otrzymuję żadnych upuszczeń karty!

Poziom produkcji rolnej kart różni się w zależności od gry, ponieważ można przeczytać w **[wydajność](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Zajmie to chwilę, zazwyczaj **kilka godzin na grę**, i nie powinieneś oczekiwać, że karty spadną w ciągu kilku minut od uruchomienia programu. Jeśli widzisz, że ASF aktywnie sprawdza status kart i przełącza grę po tym jak jest w pełni farmowana, wszystko działa w porządku. Możliwe, że włączyłeś opcję `DismissInventoryNotifications` dla `BotBehaviour` , która automatycznie odrzuca powiadomienia o inwentaryzacji. Check out **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** for details.

---

### Jak całkowicie zatrzymać proces ASF dla mojego konta?

Po prostu zamknij proces ASF, na przykład klikając [X] na Windows. If instead you want to stop a particular bot of your choice but keep other ones running, then take a look at `Enabled` **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**, or `stop` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Jeśli zamiast tego chcesz zatrzymać automatyczny proces rolniczy, przy czym ASF będzie działał dla swojego konta, następnie opcja `FarmingPausedByDefault` dla `FarmingPreferences` w **[konfiguracja bota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** i `wstrzymaj` **[polecenie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### Ile botów mogę biegać z ASF?

ASF jako program nie ma żadnego twardego górnego limitu instancji botów, więc możesz działać tak długo, jak masz pamięć na swoim komputerze, jednak nadal jesteś ograniczony przez sieć Steam i inne usługi Steam. Obecnie możesz uruchomić do 100-200 botów z pojedynczym adresem IP i pojedynczą instancją ASF. Można uruchomić więcej botów z większą liczbą IP i większą liczbą instancji ASF, pracując wokół ograniczeń IP. Pamiętaj, że jeśli używasz tej dużej ilości botów, powinieneś samodzielnie kontrolować ich numer, takie jak upewnienie się, że wszyscy z nich faktycznie logują się i pracują jednocześnie. ASF nie został udoskonalony dla tej ogromnej liczby botów, a reguła ogólna ma zastosowanie do **im więcej masz botów, tym więcej problemów napotkasz**. Zauważ, że powyższy limit zasadniczo zależy od wielu czynników wewnętrznych. przybliżenie zamiast ścisłego limitu - najprawdopodobniej będziesz w stanie uruchomić więcej lub mniej botów niż określono powyżej.

Zespół ASF sugeruje **posiadanie** do **10 kont Steam w sumie**, a zatem również działa do **10 botów w sumie**. Żaden z powyższych elementów nie jest popierany i robiony na własne ryzyko, wbrew naszej sugestii, którą tutaj przedstawiliśmy. Zalecenie to opiera się na wytycznych zaworu wewnętrznego oraz na naszych własnych sugestiach. Bez względu na to, czy będziesz przestrzegać tej reguły, czy nie, ASF jako narzędzie nie będzie wbrew Twojemu woli, nawet jeśli spowoduje to zawieszenie twoich kont Steam. W związku z tym ASF wyświetli ostrzeżenie, jeśli przejdziesz powyżej rekomendacji, ale nadal pozwalaj na to, co chcecie na własne ryzyko i brak naszego wsparcia.

---

### Czy mogę wtedy uruchomić więcej instancji ASF?

Możesz uruchomić tyle instancji ASF na jednej maszynie, ile chcesz, zakładając, że każda instancja ma własny katalog i własne konfiguracje, i konto używane w jednej instancji nie jest używane w innym. Zapytaj jednak siebie, dlaczego chce pan to zrobić. ASF jest zoptymalizowany do obsługi więcej niż stu kont w tym samym czasie, i wystrzeliwanie, że sto botów we własnych instancjach ASF pogarsza wydajność, pobiera więcej zasobów OS (takich jak CPU i pamięć) i powoduje potencjalne problemy z synchronizacją pomiędzy samodzielnymi instancjami ASF, ponieważ ASF jest zmuszony do dzielenia się ogranicznikami z innymi instancjami.

Therefore, my **strong suggestion** is, always run maximum of one ASF instance per one IP/interface. Jeśli masz więcej IP/interfejsów za pomocą wszystkich środków, możesz uruchomić więcej instancji ASF, z każdą instancją używającą własnych ustawień IP/interfejsu lub unikalnych ustawień `WebProxy`. Jeśli nie, uruchomienie większej liczby instancji ASF jest całkowicie bezcelowe, ponieważ nie uzyskasz niczego podczas uruchamiania więcej niż 1 instancji na jeden IP/interfejs. Steam nie będzie magicznie pozwalał na uruchamianie więcej botów tylko dlatego, że wystrzeliłeś je w innej instancji ASF, i ASF nie ogranicza Cię do rozpoczęcia.

Oczywiście nadal istnieją ważne przypadki użycia wielu instancji ASF na tym samym interfejsie sieciowym, na przykład hosting ASF service dla Twoich znajomych z każdym znajomym posiadającym własną wyjątkową instancję ASF w celu zagwarantowania izolacji między botami a nawet ASF same w sobie, jednak w ten sposób nie obchodzisz żadnych ograniczeń Steam, jest to zupełnie inny cel.

---

### Jaki jest sens statusu przy wykupywaniu klucza?

Status wskazuje, jak okazała się podana próba umorzenia. Istnieje wiele możliwych statusów, najczęściej spotykane to:

| Status                  | Opis                                                                                                                                                                                                        |
| ----------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Brak szczegółów         | Status "OK" wskazujący na sukces - klucz został pomyślnie wycofany.                                                                                                                                         |
| Upłynął limit czasu     | Sieć Steam nie odpowiedziała w danym czasie, nie wiemy czy klucz został zrealizowany czy nie (najprawdopodobniej było, ale możesz spróbować ponownie).                                                      |
| Kod BadActivationCode   | Podany klucz jest nieprawidłowy (nie rozpoznany jako jakikolwiek poprawny klucz przez sieć Steam).                                                                                                          |
| DuplicateActivationCode | Podany klucz został już wykupiony przez inne konto lub anulowany przez programista/wydawcę.                                                                                                                 |
| Już zakupiony           | Twoje konto posiada już `packageID` , który jest połączony z tym kluczem. Pamiętaj, że nie oznacza to, czy kluczem jest `DuplicateActivationCode` - tylko że jest poprawny i nie został użyty w tej próbie. |
| Kraj zastrzeżony        | To jest klucz zablokowany przez rejestrację, a Twoje konto nie jest w prawidłowym regionie, który może go wykupić.                                                                                          |
| DoesNotOwnRequiredApp   | Nie możesz zrealizować tego klucza, ponieważ brakuje innej aplikacji - głównie bazowa gra, gdy próbujesz wykupić pakiet DLC.                                                                                |
| StawkaOgraniczona       | Zbyt wiele prób wykupu i Twoje konto zostało tymczasowo zablokowane. Spróbuj ponownie za godzinę.                                                                                                           |

---

### Czy jesteś powiązany z jakimikolwiek usługami w zakresie prowadzenia działalności rolniczej/farmy?

**Nr**. ASF nie jest powiązany z żadną usługą i wszystkie takie roszczenia są fałszywe. Twoje konto Steam to Twoja własność i możesz używać swojego konta w dowolny sposób, jaki chcesz, ale zawór wyraźnie określony w **[oficjalny ToS](https://store.steampowered.com/subscriber_agreement)** , że:

> Jesteś odpowiedzialny za poufność swojego logowania i hasła oraz za bezpieczeństwo systemu komputerowego. Głowica nie jest odpowiedzialna za używanie hasła i konta ani za całą komunikację i aktywność na Steam, które wynikają z używania przez Ciebie nazwy użytkownika i hasła, lub przez jakąkolwiek osobę, której możesz umyślnie lub przez zaniedbanie ujawnić swój login lub hasło z naruszeniem niniejszego postanowienia poufności.

ASF jest licencjonowana na liberalnej licencji Apache 2.0, która umożliwia innym programistom dalszą integrację ASF z własnymi projektami i usługami legalnymi. Jednakże takie zewnętrzne projekty wykorzystujące ASF nie są gwarantowane, aby były bezpieczne, weryfikowane, odpowiednie lub legalne zgodnie z **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. If you want to know our opinion, **we strongly encourage you to NOT share ANY of your account details with third-party services**. Jeśli taka usługa okaże się **typowym oszustwem**, zostaniesz sam w sobie z problemem. najprawdopodobniej bez Twojego konta Steam i ASF nie weźmie żadnej odpowiedzialności za usługi firm trzecich, które twierdzą, że są bezpieczne i bezpieczne, ponieważ zespół ASF nie autoryzował żadnego z nich. Innymi słowy, **używasz ich na własne ryzyko, wbrew naszej sugestiom przedstawionym powyżej**.

Ponadto urzędnik **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** wyraźnie stwierdza, że:

> Możesz nie ujawnić, udostępniać lub w inny sposób zezwolić innym na używanie hasła lub konta, o ile Valve nie autoryzuje inaczej.

To Twoje konto i twój wybór. Po prostu nie mówi, że nikt cię nie ostrzegał. ASF jako program spełnia wszystkie wyżej wymienione reguły, ponieważ nie udostępniasz nikomu danych swojego konta, i używasz programu do własnego użytku osobistego, ale każda inna "usługa rolnicza" wymaga od Ciebie danych logowania, więc narusza ona powyższą regułę (tak naprawdę kilka z nich). Podobnie jak w **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** ocena, nie oferujemy żadnej porady prawnej i powinieneś sam zdecydować, czy chcesz korzystać z tych usług, lub nie - według nas **bezpośrednio narusza [Steam ToS](https://store.steampowered.com/subscriber_agreement)** i może skutkować zawieszeniem, jeśli Głowica się znajdzie. Jak wskazano powyżej, **zdecydowanie zalecamy NIE używać żadnej z takich usług**.

---

## Problemy

---

### Jedna z moich gier jest uprawiana przez ponad 10 godzin, ale wciąż nie otrzymałem z niej żadnych kart!

Powód ten mógłby być związany ze znanym problemem Steam, co dzieje się, gdy posiadasz dwie licencje na tę samą grę, z których jedna ma ograniczoną liczbę upuszczonych kart. Zwykle dzieje się tak, gdy aktywujesz grę za darmo podczas masowego prezentu na Steam, i następnie aktywuj klucz dla tej samej gry (bez ograniczeń), e. . z płatnego pakietu. Jeśli taka sytuacja się wydarzy, Steam zgłasza na stronie odznaki, że gra nadal ma karty do wyrzucenia, ale bez względu na to, ile grasz w grę - karty nigdy nie znikną z powodu bezpłatnej licencji na Twoim koncie. Ponieważ nie jest to problem ASF, ale Steam, nie możemy w jakiś sposób ominąć go po stronie ASF i musisz go rozwiązać samodzielnie.

Istnieją dwa sposoby rozwiązania problemu. Po pierwsze, możesz czarować tę grę w ASF, albo z `fbadd` **[komenda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** lub z `Czarna lista` **[właściwość konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** To uniemożliwi ASF próbowanie kart z tej gry, ale nie rozwiąże podstawowego problemu, który uniemożliwia Ci otrzymywanie upuszczonych kart z dotkniętej gry. Po drugie, możesz użyć narzędzia obsługi technicznej Steam, aby usunąć bezpłatną licencję z konta, pozostawiając tylko pełną licencję zawierającą karty do karty. Aby to zrobić, najpierw odwiedź swoją stronę **[licencje i aktywacje kluczy produktu](https://store.steampowered.com/account/licenses)** i zlokalizuj bezpłatną i płatną licencję dla dotkniętej gry. Zazwyczaj jest to dość łatwe - oba mają podobną nazwę, ale darmowy ma "ograniczony darmowy pakiet promocyjny" lub inne "promocje" w nazwie licencji, plus „komplementarność” w polu „metoda nabycia”. Czasami może to być bardziej skomplikowane, na przykład jeśli darmowy pakiet był w pewnym pakiecie i ma inną nazwę. Jeśli znalazłeś dwie licencje takie jak ta - to rzeczywiście problem opisany tutaj, i możesz bezpiecznie usunąć bezpłatną licencję bez utraty gry.

In order to remove the free license from your account, visit **[Steam support page](https://help.steampowered.com/wizard/HelpWithGame)** and put the affected game name into the search field, the game should be available in "products" section, click on it. Alternatively, you can just use `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` link and replace `<appID>` with appID of the game that causes troubles. Następnie kliknij "Chcę trwale usunąć tę grę z mojego konta", a następnie wybierz wadliwą bezpłatną licencję, którą znalazłeś powyżej, zazwyczaj ten z „ograniczonym bezpłatnym pakietem promocyjnym” w nazwie (lub podobnym). Po usunięciu bezpłatnej licencji, ASF powinien mieć możliwość wyrzucania kart z dotkniętej gry, bez problemów, powinieneś ponownie uruchomić operację rolniczą po usunięciu, aby mieć pewność, że Steam odbierze odpowiednią licencję tym razem.

---

### ASF nie wykrywa gry `X` jako dostępnej dla rolnictwa, ale wiem, że zawiera karty handlowe Steam!

Są tu dwa główne powody. Pierwszym i najbardziej oczywistym powodem jest fakt, że mówisz o **sklepie Steam** , gdzie dana gra jest ogłaszana jako gra z włączoną kartą. This is **wrong** assumption, as it simply states that the game **has** card drops included, but not necessarily this function for that game is **enabled** right away. You can read more about this in **[official announcement](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**.

Krótko mówiąc, ikona karty w sklepie Steam nic nie znaczy, sprawdź swoje strony **[odznaki](https://steamcommunity.com/my/badges)** w celu potwierdzenia, czy gra ma włączone krople kart - to również robi ASF. If your game doesn't appear on the list as a game with cards possible to drop, then this game is **not** possible to farm, regardless of reason.

Druga kwestia jest mniej oczywista, i jest to sytuacja, kiedy zobaczysz, że twoja gra jest dostępna z kroplami karty na stronie odznaki, jeszcze od razu nie jest produkowany przez ASF. chyba że uderzysz w jakiś inny błąd, taki jak ASF nie może sprawdzić odznaki (opisany poniżej), jest to po prostu efekt pamięci podręcznej i na stronie ASF nadal zgłasza nieaktualne odznaki. Ten problem powinien rozwiązać się szybciej lub później, gdy pamięć podręczna zostanie unieważniona. Nie ma też możliwości naprawienia tego problemu po naszej stronie.

Oczywiście wszystko to zakłada, że używasz ASF z domyślnymi nietkniętymi ustawieniami, ponieważ możesz dodać tę grę do czarnej listy rolniczej, użyj zaznaczonych `FarmingPreferences` takich jak `FarmPriorityQueueOnly` lub `Pomijanie Gier`i tak dalej.

---

### Dlaczego czas gry uprawianej przez ASF nie rośnie?

It does, but **not in real-time**. Steam rejestruje Twój czas odtwarzania w stałych odstępach czasu i aktualizuje harmonogramy dla niego, ale nie masz gwarancji, że zostanie on zaktualizowany natychmiast po opuszczeniu sesji, nie mówiąc już o tym. Tylko dlatego, że czas odtwarzania nie jest aktualizowany w czasie rzeczywistym nie oznacza, że nie jest zapisywany, zazwyczaj aktualizowany co 30 minut.

---

### Jaka jest różnica między ostrzeżeniem a błędem w dzienniku?

ASF zapisuje do swojego dziennika kilka informacji na temat różnych poziomów logowania. Naszym celem jest wyjaśnienie **dokładnie** co robi ASF, w tym kwestie związane z platformą Steam lub inne problemy wymagające rozwiązania. Większość czasu nie wszystko jest istotne, Dlatego też w ASF wykorzystuje się dwa główne poziomy problemów - poziom ostrzegania i poziom błędu.

Ogólna reguła ASF jest taka, że ostrzeżenia to **nie** błędy, dlatego też powinny **nie** być zgłaszane. Ostrzeżenie jest dla Ciebie sygnałem, że coś może się zdarzyć. Bez względu na to, czy Steam nie zareagował, błędy w rzucaniu API lub przerwaniu połączenia sieciowego - jest to ostrzeżenie, i oznacza to, że spodziewaliśmy się, że tak się stanie, więc nie przeszkadzaj sobie z rozwojem ASF. Oczywiście możesz o nich zapytać lub uzyskać pomoc korzystając z naszego wsparcia, ale nie powinieneś zakładać, że są to błędy ASF warte zgłoszenia (chyba że potwierdzamy inaczej).

Z drugiej strony błędy wskazują na sytuację, która nie powinna mieć miejsca, dlatego warto zgłaszać tak długo, jak upewnisz się, że to nie Ty, kto je powoduje. Jeśli będzie to powszechna sytuacja, której się spodziewamy, to zostanie ona przekonwertowana na ostrzeżenie. W przeciwnym razie może być to błąd, który powinien zostać skorygowany, a nie milcząco ignorowany, zakładając, że nie jest to rezultat Twojego problemu technicznego. Na przykład umieszczanie nieprawidłowej zawartości w `ASF. plik son` rzuci błąd, ponieważ ASF nie będzie w stanie go przetworzyć, ale to Ty umieściłeś go, więc nie powinieneś zgłaszać nam tego błędu (chyba że potwierdziłeś, że ASF jest złe, a Twoja struktura jest całkowicie poprawna).

W jednym zdaniu TL; DR - zgłaszaj błędy, nie zgłaszaj ostrzeżeń. Nadal możesz zapytać o ostrzeżenia i uzyskać pomoc w naszych sekcjach wsparcia.

---

### ASF nie uruchamia się, okno programu natychmiast się zamyka!

W normalnych warunkach każda awaria ASF lub wyjście spowoduje wygenerowanie dziennika `. xt` w katalogu programu do wyświetlenia, co może być użyte do znalezienia przyczyny. Ponadto kilka ostatnich plików dziennika jest również zarchiwizowanych w katalogu `logs` , ponieważ główny dziennik `jest zarchiwizowany. Plik xt` jest nadpisany z każdym uruchomionym ASF.

Jednakże, jeśli nawet .NET nie jest w stanie uruchomić komputera, to `log.txt` nie zostanie wygenerowany. Jeśli tak się stanie, najprawdopodobniej zapomniałeś zainstalować warunki wstępne .NET, zgodnie z instrukcją **[konfigurującą](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. Inne częste problemy to próba uruchomienia błędnego wariantu ASF dla systemu operacyjnego lub w inny sposób brak natywnych zależności czasu pracy .NET. Jeśli okno konsoli zamyka się zbyt wcześnie, aby przeczytać wiadomość, otwórz niezależną konsolę i uruchom z niej plik binarny ASF. Na przykład na Windows, otwórz katalog ASF, przytrzymaj `Shift`, kliknij prawym przyciskiem myszy wewnątrz folderu i wybierz "*otwórz okno poleceń tutaj*" (lub *powershell*), a następnie wpisz do konsoli `. ArchiSteamFarm.exe` i potwierdź z enter. W ten sposób otrzymasz precyzyjny komunikat, dlaczego ASF nie zaczyna się poprawnie.

Jeśli nie ma wyjścia i jesteś w systemie Windows, zwykła przyczyna braku wszystkich zainstalowanych aktualizacji systemu Windows - upewnij się, że używasz aktualnego systemu operacyjnego, ponieważ nie obsługujemy uruchamiania ASF w systemie Windows bez spełnienia tego warunku.

---

### ASF wyrzuca sesję mojego klienta Steam podczas gry! / *To konto jest zalogowane na innym PC*

Pokazuje to jako wiadomość w nakładce Steam, że konto jest używane gdzieś innego podczas gry. Kwestia ta może mieć dwa różne powody.

Jedną z przyczyn jest uszkodzone pakiety (gry), które nie trzymają blokady gry we właściwy sposób, oczekuje, że klient będzie miał do czynienia z zablokowaniem. Przykładem takiego pakietu byłby Skyrim SE. Twój klient Steam uruchamia grę poprawnie, ale ta gra nie rejestruje się jako używana. W związku z tym ASF widzi możliwość wznowienia procesu, co się dzieje, i to wyrzuca cię z sieci Steam, ponieważ Steam nagle wykryje, że konto jest używane w innym miejscu.

Drugi powód może pojawić się, jeśli grasz na swoim komputerze podczas oczekiwania ASF (zwłaszcza na innym komputerze) i stracisz połączenie sieciowe. W tym przypadku sieć Steam oznacza cię jako offline i odblokowuje blokadę (jak wyżej), która włącza ASF (np. na innym urządzeniu) do wznowienia działalności rolniczej. Gdy Twój komputer wróci do trybu online, Steam nie może już odtwarzać blokady (obecnie znajduje się w posiadaniu ASF, podobnie jak powyżej) i pokazuje ten sam komunikat.

Obie przyczyny po stronie ASF są w rzeczywistości bardzo trudne do pracy, ponieważ ASF po prostu wznawia działalność rolniczą, gdy sieć Steam poinformuje ją, że konto może zostać ponownie wykorzystane. To właśnie dzieje się normalnie po zamknięciu gry, ale z uszkodzonymi pakietami może się to zdarzyć natychmiast, nawet jeśli twoja gra nadal działa. ASF nie może wiedzieć, czy jesteś rozłączony, przestał grać w grę lub nadal grasz w grę, która nie gra we właściwy sposób.

Jedynym właściwym rozwiązaniem tego problemu jest ręczne wstrzymanie bota z `wstrzymanie` przed rozpoczęciem odtwarzania, i wznawiając go z `wznawiaj` kiedy skończysz. Alternatywnie możesz po prostu zignorować problem i postępować tak samo, jak w przypadku grania z klientem Steam offline.

---

### `Rozłączono od Steam!` - Nie mogę nawiązać połączenia z serwerami Steam.

ASF może tylko **spróbować** aby nawiązać połączenie z serwerami Steam, i może się nie powieść z wielu powodów, w tym z powodu braku połączenia z Internetem, Steam jest wyłączony, zapora blokująca połączenie, narzędzia innych firm, niepoprawnie skonfigurowane trasy lub tymczasowe awarie. Możesz włączyć tryb `Debug` aby sprawdzić dokładniejszy log, podając dokładne przyczyny awarii, chociaż zazwyczaj jest to spowodowane przez twoje własne czynności, na przykład używanie "CS:GO MM Server Picker", które czaruje wiele adresów IP Steam, co sprawia, że bardzo trudno jest Ci dotrzeć do sieci Steam.

ASF dołoży wszelkich starań, aby nawiązać połączenie, co obejmuje nie tylko zapytanie o zaktualizowaną listę serwerów, ale również próbę innego adresu IP, gdy ostatni błąd się nie powiedzie, więc jeśli jest to naprawdę tymczasowy problem z określonym serwerem lub trasą, ASF połączy się wcześniej lub później. Jeśli jednak jesteś za zaporą lub w inny sposób nie możesz dotrzeć do serwerów Steam, następnie oczywiście musisz naprawić to sam, z potencjalną pomocą trybu `Debug`.

Możliwe, że Twoja maszyna nie jest w stanie nawiązać połączenia z serwerami Steam przy użyciu domyślnego protokołu w ASF. Możesz zmienić protokoły, których ASF może używać poprzez modyfikację globalnej właściwości konfiguracji `SteamProtocols`. Na przykład, jeśli masz problemy z osiągnięciem protokołu Steam z `UDP` (np. z powodu zapory sieciowej), być może będziesz miał więcej szczęścia z `TCP` lub `WebSocket`.

W bardzo mało prawdopodobnej sytuacji spowodowanej niepoprawnymi serwerami będącymi w pamięci podręcznej, na przykład z powodu przeniesienia folderu ASF `config` z jednej maszyny do innej maszyny znajdującej się w zupełnie innym kraju, usuwanie `ASF. b` w celu odświeżenia serwerów Steam przy następnym uruchomieniu może pomóc. Bardzo często jest to niepotrzebne i nie musi być zrobione, ponieważ lista jest automatycznie odświeżana przy pierwszym uruchomieniu, jak również kiedy połączenie zostanie nawiązane - wspominamy je tylko o sposobie czyszczenia czegokolwiek związanego z listą serwerów Steam buforowanych przez ASF.

---

### `Nie można zalogować się do Steam: TryAnotherCM/Invalid`, `ServiceUnavable/Invalid`

Jak wyżej, ale tym razem połączony serwer jest wyraźnie niedostępny. Zwykle dzieje się w oknie konserwacji Steam, nic nie możesz z tym zrobić, ASF będzie automatycznie ponowić próbę z innym serwerem, dopóki nie zaakceptuje się żądania. Nie powinno to trwać dłużej niż najwyżej godzina.

---

### `Nie można uzyskać informacji o odznakach, spróbuje ponownie później!`

Zazwyczaj oznacza to, że używasz kodu PIN rodzicielskiego Steam, aby uzyskać dostęp do swojego konta, ale zapomniałeś umieścić go w konfiguracji ASF. Musisz wprowadzić poprawny PIN w konfiguracji bota `SteamParentalCode` , w przeciwnym razie ASF nie będzie miał dostępu do większości treści internetowych, w związku z czym nie będzie w stanie działać prawidłowo. Przejdź do **[konfiguracja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** aby dowiedzieć się więcej o `SteamParentalCode`.

Inne powody obejmują tymczasowy problem Steam, problem sieciowy lub podobny. Jeśli problem nie rozwiąże się po kilku godzinach i jesteś pewien, że skonfigurowałeś ASF właściwie, możesz nam o tym poinformować.

---

### ASF nie spełnia wymagań `Żądanie nie powiodło się po 5 próbach` błędów!

Zazwyczaj oznacza to, że używasz kodu PIN rodzicielskiego Steam, aby uzyskać dostęp do swojego konta, ale zapomniałeś umieścić go w konfiguracji ASF. Musisz wprowadzić poprawny PIN w konfiguracji bota `SteamParentalCode` , w przeciwnym razie ASF nie będzie miał dostępu do większości treści internetowych, w związku z czym nie będzie w stanie działać prawidłowo. Przejdź do **[konfiguracja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** aby dowiedzieć się więcej o `SteamParentalCode`.

Jeśli PIN rodzicielski nie jest powodem, to jest to najczęstszy błąd i powinieneś się do tego użyć, oznacza to po prostu, że ASF wysłał zapytanie do Steam Network i nie uzyskał prawidłowej odpowiedzi 5 razy z rzędu. Zazwyczaj oznacza to, że Steam nie działa lub ma pewne trudności lub konserwację - ASF jest świadomy takich problemów i nie powinieneś się ich martwić, jeśli nie zdarzają się one ciągle dłużej niż przez kilka godzin, a inni użytkownicy nie mają takich problemów.

Jak sprawdzić, czy Steam jest wyłączony? **[Status Steam](https://steamstat.us)** jest doskonałym źródłem sprawdzania, czy Steam **powinien być** up jeśli zauważysz błędy, szczególnie związane ze społecznością lub Web API, to Steam ma trudności. Możesz zrezygnować z ASF w pojedynkę i pozwolić mu wykonać swoją pracę po krótkim czasie przestoju lub wyjść i poczekać samemu.

Jednak nie zawsze tak jest, ponieważ w niektórych sytuacjach problemy Steam mogą nie być wykrywane przez Steam Status, na przykład taki przypadek miał miejsce, gdy zawór przerwał obsługę HTTPS dla społeczności Steam 7 czerwca 2016 r. - dostęp do **[SteamCommunity](https://steamcommunity.com)** przez HTTPS powodował błąd. Dlatego też nie ufajcie sobie zaufaniu Steam Status, najlepiej sprawdzić, czy wszystko działa jak powinno.

Ponadto Steam zawiera różne środki ograniczające stawki opłat, które czasowo zbanują Twój adres IP, jeśli zgłosisz nadmierną liczbę żądań jednocześnie. ASF jest tego świadomy i oferuje kilka różnych ograniczników w konfiguracji, z których powinieneś korzystać. Domyślne ustawienia zostały ulepszone na podstawie liczby botów **sane** , jeśli używasz tak ogromnej kwoty, że nawet Steam każe cię odejść, wtedy albo dostosowujesz je, dopóki nie powiedzie ci, albo zrobisz to, co powiedziesz. Zakładam, że druga droga nie jest dla Ciebie opcją, więc przejdź do czytania tego tematu i zwróć szczególną uwagę na `WebLimiterDelay` , który jest ogólnym ogranicznikiem, który dotyczy wszystkich żądań sieciowych.

Nie ma „złotej reguły”, która działa dla wszystkich, ponieważ bloki są w dużym stopniu uzależnione od czynników zewnętrznych. Dlatego musisz się eksperymentować i znaleźć wartość, która dla Ciebie działa. Możesz również zignorować to, co mówię, i użyć czegoś takiego, jak `10000` , co jest gwarantowane poprawnie, ale nie narzekaj, jak ASF reaguje na wszystko za 10 sekund i jak parsowanie odznak zajmuje 5 minut. In addition to that, it's entirely possible that no limiter will do anything because you have so huge amount of bots that you're hitting **[hard limit](#how-many-bots-can-i-run-with-asf)** that was mentioned above. Tak, jest całkowicie możliwe, że będziesz mógł zalogować się bez problemów do sieci Steam (klient), ale strona Steam (strona internetowa) odmówi słuchania Ciebie, jeśli masz 100 sesji utworzonych jednocześnie. ASF wymaga, aby zarówno sieć Steam, jak i sieć Steam działały w ramach współpracy, wystarczy tylko jeden raz, aby rozwiązać problemy, z których nie odzyskasz.

Jeśli nic nie pomoże, a pacjent nie ma wskazówek, co jest uszkodzone, możesz zawsze włączyć tryb `Debug` i zobaczyć siebie w dzienniku ASF dlaczego żądania są błędne. Na przykład:

```text
WenalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Zabronione <- HEAD https://steamcommunity.com/my/edit/settings
```

Zobacz ten kod `zabroniony`? Oznacza to, że zostałeś tymczasowo zbanowany z powodu zbyt dużej ilości żądań, ponieważ nie dostosowałeś jeszcze `WebLimiterDelay` (zakładając, że otrzymasz ten sam kod błędu również dla wszystkich innych żądań). Istnieją inne powody wymienione w tym wykazie, takie jak `InternalServerError`, `ServiceUnavavailable` i limit czasu, które wskazują na konserwację/problemy Steam. Zawsze możesz spróbować odwiedzić link wymieniony przez ASF i sprawdzić, czy działa - jeśli nie, wtedy wiesz, dlaczego ASF nie ma dostępu do tego. Jeśli tak się stanie, a ten sam błąd nie zniknie po upływie jednego lub dwóch dni, warto zbadać i zgłosić.

Zanim to zrobisz, powinieneś **upewnij się, że błąd jest warty zgłoszenia w pierwszym miejscu**. Jeśli wspomniano w tym FAQ, jak na przykład problem związany z handlem, to się stało. Jeśli jest to tymczasowy problem, który zdarzył się raz lub dwa razy, szczególnie gdy Twoja sieć była niestabilna lub Steam został wyłączony - to się stanie. Jeśli jednak byłeś w stanie powtórzyć swoją sprawę kilkakrotnie z rzędu, przez 2 dni, zrestartowano ASF oraz urządzenie w procesie i upewniono się, że nie ma tutaj wpisu FAQ, aby pomóc w rozwiązaniu problemu, wtedy warto o to zapytać.

---

### ASF wydaje się zamrozić i nic nie drukuje na konsoli dopóki nie naciśnę klawisza!

Najprawdopodobniej używasz systemu Windows, a konsola ma włączony tryb Szybkiej Edycji. Zobacz **[to pytanie](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** na StackOverflow dla wyjaśnienia technicznego. Powinieneś wyłączyć tryb QuickEdit klikając prawym przyciskiem myszy na okno konsoli ASF, otwierając właściwości i odznaczając odpowiednie pole wyboru.

---

### ASF nie może przyjmować ani wysyłać transakcji!

Najpierw rzecz jasna - nowe konta zaczynają się jako ograniczone. Dopóki nie odblokowasz konta poprzez załadowanie portfela lub wydanie 5 dolarów w sklepie, ASF nie może zaakceptować żadnych transakcji za pomocą tego konta. W tym przypadku ASF poda, że ekwipunek wydaje się pusty, ponieważ każda karta, która jest w nim niewymienialna.

Następnie, jeśli nie używasz **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, Możliwe, że ASF faktycznie zaakceptował/wysłała transakcję, ale musisz ją potwierdzić pocztą elektroniczną. Podobnie, jeśli używasz klasycznego 2FA, musisz potwierdzić transakcję za pośrednictwem swojego uwierzytelniacza. Potwierdzenia są teraz **obowiązkowe** , więc jeśli nie chcesz przyjmować ich samodzielnie, rozważ zaimportowanie swojego uwierzytelniającego do ASF 2FA.

Zauważ, że możesz handlować tylko ze swoimi przyjaciółmi oraz ze znanym linkiem handlowym. If you're trying to initiate *Bot -> Master* trade, such as `loot`, then you need to either have your bot on your friendlist, or your `SteamTradeToken` declared in Bot's config. Upewnij się, że token jest prawidłowy - w przeciwnym razie nie będziesz mógł wysłać transakcji.

Na koniec pamiętaj, że nowe urządzenia mają 7-dniową blokadę transakcji, więc jeśli właśnie dodałeś swoje konto do ASF, odczekać co najmniej 7 dni - wszystko powinno działać po tym okresie. To ograniczenie obejmuje **oba** akceptujące **i** wysyłające transakcje. Nie zawsze się to wyzwala, i są ludzie, którzy mogą natychmiast wysyłać i akceptować transakcje. Dotknęła jednak znaczna część ludzi, a blokada **stanie się** , nawet jeśli możesz wysyłać i akceptować transakcje za pośrednictwem klienta Steam na tym samym komputerze. Po prostu zaczekaj cierpliwie, nie ma nic do zrobienia aby to przyspieszyć. Podobnie, możesz uzyskać podobną blokadę do usunięcia/zmiany różnych ustawień związanych z bezpieczeństwem Steam, takich jak 2FA, SteamGuard, hasło, e-mail i podobne. Zaznacz, czy możesz samodzielnie wysłać transakcję z tego rachunku, jeśli tak, to bardzo prawdopodobne jest klasyczna 7-dniowa blokada z nowego urządzenia.

I wreszcie pamiętaj, że jeden rachunek może mieć tylko 5 oczekujących transakcji do innego, więc ASF nie będzie wysyłać transakcji, jeśli masz 5 (lub więcej) oczekujących od tego bota do zaakceptowania. To rzadko jest problem, ale warto również wspomnieć, szczególnie jeśli ustawisz ASF na automatyczne wysyłanie transakcji, jeszcze nie używasz ASF 2FA i zapomniałeś je potwierdzić.

Jeśli nic nie pomogło, zawsze możesz włączyć tryb `Debug` i sprawdzić samemu dlaczego żądania się nie powiodły. Pamiętaj, że Steam mówi w większości przypadków nonsensu i podany powód może nie mieć żadnego logicznego sensu, lub może być nawet całkowicie niepoprawny - jeśli zdecydujesz się zinterpretować ten powód, upewnij się, że masz przyzwoitą wiedzę na temat Steam i jego zapytań. Jest również dość powszechne widzenie tej kwestii bez żadnego logicznego powodu, i jedynym sugerowanym rozwiązaniem w tym przypadku jest ponowne dodanie konta do ASF (i odczekanie 7 dni ponownie). Czasami ten problem również naprawia siebie *magicznie*, tak samo jak pęka. Zazwyczaj jednak jest to tylko 7-dniowa blokada handlu, tymczasowy problem z parą wodną, albo oba te problemy. Najlepiej dać mu kilka dni przed ręcznym sprawdzeniem, co jest złe, chyba że będziesz chciał debugować prawdziwą przyczynę (i zwykle będziesz zmuszony czekać, ponieważ komunikat o błędzie nie będzie miał żadnego sensu, ani nie pomoże Ci w najmniejszym stopniu).

W każdym razie ASF może tylko **spróbować** wysłać do Steam odpowiednią prośbę o akceptację/wysłanie transakcji. Bez względu na to, czy Steam akceptuje to żądanie, czy nie, nie jest on objęty zakresem ASF, a ASF nie sprawdzi go magicznie. Nie ma żadnych błędów związanych z tą funkcją i nie ma też nic do ulepszenia, ponieważ logika dzieje się poza ASF. W związku z tym nie należy żądać napraw, które nie są naruszone, i nie pytaj również, dlaczego ASF nie może przyjmować ani wysyłać transakcji - **nie wiem, a ASF nie zna ani**. Zajrzyj się tym lub ustaw się, jeśli wiesz lepiej.

---

### Dlaczego muszę umieścić kod 2FA/SteamGuard przy każdym logowaniu? / *Usunięto wygasły klucz logowania*

ASF używa kluczy logowania (jeśli zachowałeś `UseLoginKeys` włączony) w celu zachowania ważności poświadczeń, ten sam mechanizm do użycia przez Steam - token 2FA/SteamGuard jest wymagany tylko raz. Jednak z powodu problemów i zapytań z sieci Steam, jest całkowicie możliwe, że klucz logowania nie jest zapisany w sieci. już widzieliśmy takie problemy nie tylko z ASF, ale także ze zwykłym klientem Steam (należy wprowadzić login + hasło przy każdym uruchomieniu, niezależnie od opcji "zapamiętaj mnie").

Możesz usunąć `BotName.db` i `BotName. w` (jeśli jest dostępny) konta i spróbuj połączyć ASF z Twoim kontem ponownie, ale prawdopodobnie nic nie zrobi. Niektórzy użytkownicy zgłosili, że **[deautoryzacja wszystkich urządzeń](https://store.steampowered.com/twofactor/manage)** po stronie Steam powinna pomóc, zmiana hasła zrobi to samo. Są to jednak jedynie prace, które nawet nie są zagwarantowane do pracy, prawdziwym rozwiązaniem opartym na ASF jest importowanie Twojego uwierzytelniającego jako **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** - w ten sposób ASF może generować tokeny automatycznie, gdy są potrzebne, i nie musisz wprowadzać ich ręcznie. Zwykle problem magicznie rozwiązuje się po jakimś czasie, więc możesz po prostu zaczekać na to. Oczywiście możesz również poprosić Głowicę o rozwiązanie, ponieważ nie mogę zmusić sieci Steam do zaakceptowania naszych kluczy logowania.

Uwaga boczna możesz również wyłączyć klucze logowania za pomocą `UseLoginKeys` konfiguracja ustawiona na `false`, ale to nie rozwiąże problemu, tylko pomiń początkowy błąd klucza logowania. ASF jest już świadomy problemu wyjaśnionego tutaj i dołoży wszelkich starań, aby nie używać kluczy logowania, jeśli może zagwarantować sobie wszystkie dane logowania, więc nie ma potrzeby dostosowywania `UseLoginKeys` ręcznie, jeśli możesz podać wszystkie dane logowania razem z ASF 2FA.

---

### Wystąpił błąd: *Nie można zalogować się do Steam: `Nieprawidłowe hasło` lub `RateLimitExceed`*

Ten błąd może oznaczać wiele rzeczy, a niektóre z nich obejmują:

- Nieprawidłowa kombinacja logowania/hasła (oczywiście)
- Klucz logowania wygasł używany przez ASF do logowania
- Zbyt wiele nieudanych prób logowania w krótkim czasie (antybruteforce)
- Zbyt wiele prób logowania w krótkim okresie czasu (ograniczający)
- Wymóg zalogowania captcha (bardzo prawdopodobne jest spowodowane dwoma powodami powyżej)
- Jakiekolwiek inne powody mogą uniemożliwić zalogowanie się do sieci Steam

W przypadku antybruteforce i ograniczenia szybkości problem zniknie po jakimś czasie, więc po prostu zaczekaj i nie próbuj się zalogować w międzyczasie. Jeśli często uderzysz w ten problem, być może mądrze byłoby zwiększyć `LoginLimiterDelay` właściwość ASF. Nadmierne uruchamianie programu i inne celowe lub nieumyślne żądania logowania zdecydowanie nie pomogą w tym problemie, więc spróbuj go uniknąć, jeśli to możliwe.

W przypadku wygasłego klucza logowania - ASF usunie stary i poprosi o nowy przy następnym logowaniu (co będzie wymagało od Ciebie wprowadzenia tokenu 2FA, jeśli Twoje konto jest chronione dwufazowo. Jeśli twoje konto używa ASF 2FA, token zostanie wygenerowany i użyty automatycznie). Może się to oczywiście zdarzyć z czasem, ale jeśli pojawi się ten problem przy każdym logowaniu, jest możliwe, że Steam z jakiegoś powodu zdecydował się zignorować nasze prośby o zapisanie klucza logowania, jak wspomniano w problemie **[powyżej](#why-do-i-have-to-put-2fasteamguard-code-on-each-login--removed-expired-login-key)**. Możesz oczywiście wyłączyć `UseLoginKeys` całkowicie, ale to nie rozwiąże problemu, tylko unikaj konieczności usuwania wygasłych kluczy logowania za każdym razem. Prawdziwym rozwiązaniem, zgodnie z powyższą kwestią, jest stosowanie ASF 2FA.

I wreszcie, jeśli użyłeś niewłaściwego logowania + hasła, oczywiście musisz to poprawić, lub wyłącz bota, który próbuje połączyć się za pomocą tych poświadczeń. ASF nie może sam zgadywać, czy `Nieprawidłowe hasło` oznacza nieprawidłowe poświadczenia, lub którykolwiek z wyżej wymienionych powodów, dlatego będzie próbował dopóki nie zakończy się powodzeniem.

Należy pamiętać, że ASF ma własny wbudowany system umożliwiający odpowiednią reakcję na zapytania z parą wodną, w końcu połączy i wznowi swoją pracę, dlatego nie wymaga się nic do zrobienia jeśli problem ma charakter tymczasowy. Ponowne uruchomienie ASF w celu magicznego rozwiązania problemów tylko pogorszy sytuację (ponieważ nowy ASF nie zna poprzedniego stanu ASF i nie będzie mógł się zalogować, i spróbuj połączyć się zamiast czekać), więc unikaj tego jeśli nie wiesz, co robisz.

Na koniec, tak jak w przypadku każdego żądania Steam - ASF może tylko **spróbować** aby się zalogować, używając dostarczonych danych logowania. Czy ta prośba zakończy się sukcesem, czy nie, jest poza zakresem i logiką ASF - nie ma błędu, i nic nie można naprawić w tym względzie.

---

### Nie mogę wprowadzić danych logowania, o które prosi ASF
### `System.InvalidOperationExcepation: Nie można odczytać kluczy gdy aplikacja nie posiada konsoli lub gdy dane wejściowe konsoli zostały przekierowane`
### `System.IOException: Błąd wejścia/wyjścia`
### `Wejście RequestInput() jest nieprawidłowe!`

Jeśli ten błąd wystąpił podczas wprowadzania ASF (np. możesz zobaczyć `GetUserInput()` w stacktrace), a następnie jest to spowodowane przez twoje środowisko, które zakazuje ASF czytania standardowego wejścia konsoli. Może się to zdarzyć z wielu powodów, ale najczęstszym z nich jest używanie ASF w niewłaściwym środowisku (np. w tle `systemd`, `nohup` lub `&` zamiast e. . `ekran` na Linux). Jeśli ASF nie może uzyskać dostępu do standardowych danych wejściowych, zobaczysz ten błąd zalogowany i niezdolność ASF do korzystania ze swoich danych podczas pracy.

Zazwyczaj powinieneś naprawić powyższy problem, tj. zezwolić ASF na dostęp do standardowego wprowadzania danych, aby można było podać szczegóły. Jeśli jednak **spodziewasz się, że** tak się stanie, więc **zamierzasz** uruchomić ASF w środowisku bezwejściowym, wtedy powinieneś wyraźnie powiedzieć ASF, że tak jest, ustawiając tryb **[`Bezgłowne`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** odpowiednio. Spowoduje to, że ASF nigdy nie poprosi o dane wejściowe użytkownika w żadnych okolicznościach, co pozwoli bezpiecznie uruchomić ASF w środowiskach bez wprowadzania danych. Możesz odpowiedzieć na wybrane zapytania wejściowe w inny sposób w tym trybie, np. w ASF-ui.

---

### `System.Net.Http.WinHttpWyjąt: Wystąpił błąd bezpieczeństwa`

Ten błąd ma miejsce, gdy ASF nie może nawiązać bezpiecznego połączenia z danym serwerem, prawie wyłącznie z powodu braku zaufania certyfikatu SSL.

W prawie wszystkich przypadkach ten błąd jest spowodowany przez **złą datę/czas na urządzeniu**. Każdy certyfikat SSL wydał datę i datę ważności. Jeśli Twoja data jest nieprawidłowa i poza tymi dwoma granicami, certyfikat nie może zostać zaufany ze względu na potencjalny atak **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)** i ASF odmawia nawiązania połączenia.

Oczywistym rozwiązaniem jest odpowiednie ustawienie daty na maszynie. Zalecane jest użycie automatycznej synchronizacji dat, takiej jak natywna synchronizacja dostępna w systemie Windows, lub `ntpd` na systemie Linux.

Jeśli upewniłeś się, że data na komputerze jest odpowiednia i błąd nie chce zniknąć, Certyfikaty SSL, których zaufanie systemowe może być nieaktualne lub nieprawidłowe. In this case you should ensure that your machine can establish secure connections, for example by checking if you can access `https://github.com` with any browser of your choice, or CLI tool such as `curl`. Jeśli potwierdziliście państwo, że to działa, proszę nas o wsparcie.

---

### `System.Threading.Zadania anulowaneWyjątek: Zadanie zostało anulowane`

To ostrzeżenie oznacza, że Steam nie odpowiedział na żądanie ASF w danym czasie. Zwykle jest to spowodowane czkawką sieciową Steam i w żaden sposób nie wpływa na ASF. W innych przypadkach jest to takie samo jak żądanie nieudane po 5 próbach. Zgłaszanie tego problemu nie ma sensu, ponieważ nie możemy zmusić Steam do odpowiedzi na nasze żądania.

---

### `Inicjator typu 'System.Security.Cryptography.CngKeyLite' rzucił wyjątek`

Ten problem jest prawie wyłącznie spowodowany wyłączeniem/zatrzymaniem `klucza CNG` usługi Windows, która zapewnia podstawowe funkcje kryptograficzne ASF, bez których program nie jest w stanie uruchomić. Możesz rozwiązać ten problem uruchamiając usługi `. sc` i upewnij się, że `CNG Key Isolation` Usługa Windows nie wyłączyła uruchamiania i jest obecnie uruchomiona.

---

### ASF jest wykrywany jako złośliwe oprogramowanie przez mój Antywirus! Co się dzieje?

**Upewnij się, że pobrałeś ASF z zaufanego źródła**. Jedynym oficjalnym i zaufanym źródłem jest **[ASF wydanie](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** na stronie GitHub (i jest to również źródło automatycznej aktualizacji ASF) - **każde inne źródło jest z definicji niezaufane i może zawierać złośliwe oprogramowanie dodane przez inne osoby** - nie powinieneś ufać żadnej innej lokalizacji pobierania, upewnij się, że twój ASF zawsze pochodzi od nas.

Jeśli potwierdzisz, że ASF jest pobierany z zaufanego źródła, to bardzo prawdopodobne jest, że po prostu jest fałszywie dodatni. This **happened in the past**, **is happening right now**, and **will happen in the future**. Jeśli jesteś zaniepokojony rzeczywistym bezpieczeństwem stosowania ASF, sugeruję skanowanie ASF z wieloma różnymi AVs w celu wykrycia rzeczywistego współczynnika wykrywania, na przykład przez **[VirusTotal](https://www.virustotal.com)** (lub dowolną wybraną przez Ciebie usługę internetową.

Jeśli AV, którego używasz fałszywie wykryje ASF jako złośliwego oprogramowania, następnie **jest dobrym pomysłem na wysłanie tego pliku z powrotem do deweloperów Twojego AV, aby mogli analizować i usprawnić swój silnik wykrywania**, ponieważ wyraźnie nie działa tak dobrze, jak sądzisz. Nie ma problemu w kodzie ASF i nie ma dla nas żadnych rozwiązań, ponieważ w pierwszym rzędzie nie dystrybuujemy złośliwego oprogramowania, dlatego nie ma sensu informować nas o tych fałszywych pozytywach. Zalecamy wysłanie próbki ASF do dalszej analizy, jak podano powyżej, ale jeśli nie chcesz jej przeszkadzać, wtedy zawsze możesz dodać ASF do pewnego rodzaju wyjątków AV, wyłączyć AV lub po prostu użyć innego. Niestety jesteśmy przyzwyczajeni do głuchych AV, ponieważ każdy raz na jakiś czas niektóre AV wykrywa ASF jako wirus, które zazwyczaj utrzymuje się bardzo krótko i jest szybko naprawiane przez dewelopery, ale jak wskazaliśmy powyżej - **zdarzyło się**, **dzieje się** i **będzie się powtarzać** przez cały czas. ASF nie zawiera żadnego złośliwego kodu, możesz przejrzeć kod ASF, a nawet skompilować ze źródła. Nie jesteśmy hakerami, aby ukryć kod ASF w celu ukrycia się przed heuristyką AV i fałszywymi dodatkami, więc nie spodziewaj się od nas naprawienia tego, co nie jest łamane - nie ma "wirusa" do naprawienia.