# Konfiguracja

Jeśli przyjechałeś tu po raz pierwszy, witamy! Bardzo cieszymy się, widząc jeszcze jednego podróżnego, który jest zainteresowany naszym projektem, chociaż należy pamiętać, że z wielką potęgą wiąże się wielka odpowiedzialność - ASF jest w stanie wykonywać wiele różnych zadań związanych z Steamem, ale tylko tak długo, jak jesteś **wystarczająco troszczy, aby dowiedzieć się jak używać go**. Faktycznie czytanie wiki, zgodnie z naszymi wytycznymi i dowiedzieć się więcej o różnych koncepcjach ASF ostatecznie wynagrodzi Cię unikalną umiejętnością korzystania z jednego z najpotężniejszych narzędzi Steam dostępnych od dziś.

Zalecamy wykonanie **jednej rzeczy na raz**. ASF dotyka wielu różnych aspektów, z których niektóre są raczej trywialne, a inne mogą być zbyt skomplikowane. Nie musisz rozumieć ani przeczytać wszystkiego na raz i tak naprawdę zalecamy Ci to łatwo. Uluźnij się, wybierz swój wybór. poświęć godzinę czasu i włożyć do naszego wykładu - możemy obiecać, że będzie warty twojego czasu.

Zacznijmy od podstaw - ASF jest aplikacją konsoli w zasadzie co oznacza, że nie pojawi się automatycznie interfejs graficzny, do którego zazwyczaj używasz. ASF jest uniwersalną aplikacją, która działa głównie jako usługa (demon), a nie aplikacja stacjonarna. Jedno z przypadków jego głównego zastosowania rozważa działanie na urządzeniach serwera, dla których aplikacje stacjonarne są całkowicie nieodpowiednie. That considers only the absolute core of the program though, because ASF actually **does** include its own graphical interface - in form of its built-in ASF-ui frontend, but we'll get down to that part in due time - we're just mentioning this right away so you won't panic when seeing black console screen or something.

Po otrzymaniu plików binarnych ASF program będzie wymagał od Ciebie konfiguracji, która określa, czego dokładnie oczekujesz od ASF. Możesz uruchomić program bez konfiguracji, w tym przypadku ASF uruchomi się w ustawieniach domyślnych, umożliwiając Ci użycie. . ASF-ui dla początkowej konfiguracji, ale inne niż ta nie zrobią zbyt wiele bez wcześniejszego działania.

Na razie to zrobimy zaczynajmy!

---

## Ustawienia specyficzne dla systemu

Ogólnie rzecz biorąc, oto co zrobimy w ciągu najbliższych kilku minut:
- We'll install **[.NET prerequisites](#net-prerequisites)**.
- Then we'll download **[latest ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** in appropriate OS-specific variant.
- Następnie wyodrębnimy archiwum do nowej lokalizacji.
- Następnie **[skonfigurujemy ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- I wreszcie, uruchomimy ASF i zobaczymy jego magię.

Niektóre z tych działań są bardzo zrozumiałe, inne będą wymagać od Ciebie większej uwagi. Nie martw się, mamy cię zająć.

---

### Wymagania wstępne .NET

Pierwszym krokiem jest zapewnienie, że system operacyjny może nawet prawidłowo uruchomić ASF. Nie musisz tego wiedzieć, ale ASF jest napisany w C#, na podstawie . Platforma ET i może wymagać bibliotek natywnych, które nie są jeszcze dostępne na Twojej platformie. Pomyśl jak DirectX dla gier 3D lub silnik do uruchamiania samochodu.

W zależności od tego, czy używasz Windows, Linux czy macOS, będziesz miał różne wymagania. Dokument referencyjny to **[. Wymagania ET](https://docs.microsoft.com/dotnet/core/install)**, ale dla uproszczenia wyszczególniliśmy również wszystkie potrzebne pakiety poniżej, więc nie musisz wcale czytać, chyba że napotkasz problemy lub masz dodatkowe pytania.

To zupełnie normalne, że niektóre (lub nawet wszystkie) zależności już istnieją w Twoim systemie z powodu zainstalowania przez oprogramowanie innych firm, których używasz. Mimo to nie musi tak być, więc powinieneś uruchomić odpowiedni instalator dla systemu operacyjnego - bez tych zależności ASF nie uruchomi się w ogóle, i nie otrzymasz praktycznie żadnych przydatnych informacji do powiedzenia ci, co jest nie tak.

Pamiętaj, że nie musisz robić nic innego dla specyficznych dla OS, zwłaszcza instalacji. ET SDK lub nawet czas uruchomienia, ponieważ pakiet specyficzny dla OSS obejmuje już wszystkie te elementy. Do uruchomienia potrzebne są tylko warunki wstępne .NET (zależności). Czas pracy ET zawarty w ASF - tylko te rzeczy, które wyszczególnimy, bez żadnych innych uzupełnień.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** dla 64-bitów, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** dla 32-bitowych lub **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** dla 64-bitowych ARM)
- Jest wysoce zalecane, aby upewnić się, że wszystkie aktualizacje systemu Windows są już zainstalowane. Jeśli nie masz ich włączonych, następnie co najmniej potrzebujesz **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** i **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, ale może być potrzebne więcej aktualizacji. Nie musisz się o to martwić, jeśli Twój system Windows jest aktualny lub przynajmniej aktualny.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Nazwy pakietów zależą od dystrybucji, której używasz, wyszczególniliśmy najczęstsze z nich. Możesz uzyskać je z natywnym menedżera pakietów dla systemu operacyjnego (jak np. `apt` dla Debiana lub `yum` dla CentOS). Są to całkiem standardowe biblioteki, które powinny być dostępne niezależnie od tego, której dystrybucji używasz, to tylko kwestia dowiedzenia się, jak są nazywane w wybranym przez Ciebie środowisku.

- `ca-certificates` (standardowe zaufane certyfikaty SSL do tworzenia połączeń HTTPS)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, najnowsza wersja Twojej dystrybucji, na przykład `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-libs`, najnowsza wersja Twojej dystrybucji, co najmniej `1.1.X`)
- `libstdc++6` (`libstdc++`, w wersji `5.0` lub wyższej)
- `zlib1g` (`zlib`)

Przynajmniej większość z nich powinna być już dostępna w Twoim systemie. Na przykład minimalna instalacja Debian stabilna wymaga zwykle tylko `libicu76`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- Nie potrzebujesz niczego konkretnie, ale powinieneś mieć zainstalowaną najnowszą wersję macOS, co najmniej 12.0 +

---

### Pobieranie

Ponieważ mamy już wszystkie wymagane zależności, następnym krokiem jest pobieranie **[najnowszej wersji ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF jest dostępny w wielu wariantach, ale jesteś zainteresowany pakietem, który pasuje do Twojego systemu operacyjnego i architektury. Na przykład, jeśli używasz `64`-bit `Win`dows, wtedy chcesz `ASF win-x64`. Aby uzyskać więcej informacji o dostępnych wariantach, odwiedź sekcję **[kompatybilność](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**. ASF jest również w stanie działać w środowiskach, dla których nie budujemy specyficznego dla OS. Na przykład **32-bit Windows**, ale do tego będziesz potrzebował **[ogólnej konfiguracji](#generic-setup)**.

![Zasoby](https://i.imgur.com/Ym2xPE5.png)

Po pobraniu, zacznij rozpakowywać plik zip do własnego folderu. Jeśli potrzebujesz do tego konkretnego narzędzia, **[7-zip](https://www.7-zip.org)** to zrobi, ale wszystkie standardowe narzędzia takie jak wbudowana ekstrakcja Windows lub `unzip` z Linux/macOS również powinny działać bez problemów.

Polecamy rozpakować ASF do **swojego własnego katalogu** , a nie do żadnego istniejącego katalogu, którego już używasz dla czegoś innego - to jest ważne. ASF zawiera funkcję auto-aktualizacji, która zastępuje własne pliki, a która zwykle usunie wszystkie stare i niepowiązane pliki podczas aktualizacji, co z kolei może doprowadzić do utraty wszystkiego, co nie jest możliwe w katalogu ASF. Jeśli masz dodatkowe skrypty lub pliki, których chcesz używać z ASF, to nie jest to problem, utwórz dedykowany katalog dla nich, zawsze możesz umieścić ASF w jednym folderze głębszej.

Przykładowa struktura może wyglądać tak:

```text
C:\ASF (gdzie umieścisz swoje własne rzeczy)
    <unk> ·MyNotes. xt (opcjonalnie)
    † AsfMakeMeCoffeeScript.bat (opcjonalnie)
    † (... (wszelkie inne wybrane pliki, opcjonalne)
    <unk> Core (przeznaczone tylko dla ASF, gdzie wyodrębniasz archiwum)
         <unk> <unk> <unk> ArchiSteamFarm(. xe)
         <unk> config
         <unk> logi
         <unk> wtyczki
         † www
         <unk> <unk> (...)
```

---

### Konfiguracja

Jesteśmy teraz gotowi do wykonania ostatniego kroku, konfiguracji. ASF działa z koncepcją "botów", każdy bot jest zwykle pojedynczym kontem Steam, które chcesz używać w ASF. Możesz zadeklarować tyle botów ile chcesz, ale dla początkujących skupimy się tylko na jednym z nich - zazwyczaj na Twoim głównym koncie. ASF posiada również pliki konfiguracyjne inne niż boty, najważniejszy jest globalny plik konfiguracyjny, który dotyczy wszystkich botów w tej instancji.

Ogólna reguła kciuka jest taka, że **jeśli nie wiesz lub nie rozumiesz jakiegoś ustawienia, powinieneś zostawić go z jego wartością domyślną, bez zmiany niczego**. ASF oferuje niezliczone sposoby konfiguracji, dostosowywania i dostosowywania prawie wszystkich swoich funkcji, ale jak wspomniano powyżej, próba zrozumienia go od razu u u nietoperza jest dziurą królika, która może szybko przeciągnąć pacjenta w stan poważnego splątania, jeśli nie **[wprost do przełamania](https://www.youtube.com/watch?v=KK3KXAECte4)**. Zamiast tego zalecamy najpierw stworzenie sprawdzającego się przykładu, a dopiero potem zacznij kopać w dodatkowe opcje. z pomocą strony **[konfiguracja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** na wiki, podczas zmiany **jedna rzecz na raz**.

Konfiguracja ASF może być wykonana na kilka sposobów - poprzez nasz wbudowany interfejs ASF-ui, samodzielny generator konfiguracji sieci lub ręcznie. Zostało to szczegółowo wyjaśnione w sekcji **[konfiguracja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** , więc zapoznaj się z tym, jeśli chcesz uzyskać bardziej szczegółowe informacje. Jako punkt wyjścia użyjemy samodzielnego generatora konfiguracji sieci, ponieważ działa nawet jeśli z jakiegoś powodu ASF-ui nie zacznie działać poprawnie.

Navigate to our **[web config generator](https://justarchinet.github.io/ASF-WebConfigGenerator)** page with your favourite browser. Zalecamy Chrome lub Firefox, ale nie powinno to mieć znaczenia tak długo, jak Twoja przeglądarka działa dla wszystkich innych.

Po otwarciu strony, przejdź na zakładkę "Bot". Powinieneś teraz zobaczyć stronę podobną do tej poniżej:

![Zakładka z botami](https://i.imgur.com/aF3k8Rg.png)

Jeśli jakakolwiek szansa wersja ASF, którą właśnie pobrałeś, jest starsza niż domyślnie ustawiony generator konfiguracji, po prostu wybierz swoją wersję ASF z rozwijanego menu. Może się to zdarzyć (rzadko), ponieważ generator konfiguracyjny może być używany do generowania konfiguracji do nowszych (wstępnych) wersji ASF, które nie zostały jeszcze oznaczone jako stabilne. Pobrano najnowszą stabilną wersję ASF, która jest weryfikowana aby działać niezawodnie, więc może być nieco starsza niż wersja bezwzględnej krawędzi, która jest całkowicie nieodpowiednia do pierwszego użycia.

Zacznij od **umieszczając nazwę bota** w polu podświetlonym jako czerwony, o nazwie `Nazwa`. To może być każda nazwa, którą chcesz użyć, taka jak pseudonim, nazwa konta, numer lub cokolwiek innego. Jest tylko jedno słowo, którego nie możesz użyć, `ASF`, ponieważ to słowo kluczowe jest zarezerwowane dla globalnego pliku konfiguracyjnego. Ponadto nazwa bota nie może zaczynać się od kropki (ASF celowo ignoruje te pliki). Zalecamy również unikanie korzystania z spacji, możesz użyć `_` jako separatora słów w razie potrzeby - a nie ścisłego wymogu, ale będziesz miał trudny czas przy użyciu komend ASF.

Nazwa bota została ustalona? Świetnie, w następnym kroku **change `Włączone` włączone, aby być na**, określa, czy bot ma być uruchamiany automatycznie przez ASF po uruchomieniu (programu). Brak tego spowoduje, że ASF stwierdzi, że Twój bot jest wyłączony w pliku konfiguracyjnym, i będzie czekać na uruchomienie twojego wejścia, co nie jest tym, co chcemy robić w tym przykładzie.

Teraz pojawiają się dwie wrażliwe właściwości: `SteamLogin` i `SteamPassword`. Możesz podjąć kolejną decyzję tutaj - albo możesz umieścić swoje dane logowania do Steam w tych dwóch właściwościach, lub mogą Państwo zdecydować się przeciwko takiemu postępowaniu, pozostawiając je puste.

ASF wymaga Twoich danych logowania, ponieważ zawiera własną implementację klienta Steam i potrzebuje tych samych danych, aby zalogować się jak ta, z której korzystasz. Twoje dane logowania nie są nigdzie zapisywane, ale tylko na komputerze ASF `config` (po pobraniu wygenerowanej konfiguracji). Nasz generator konfiguracji sieci web jest aplikacją opartą na kliencie, co oznacza, że wszystko, co robisz wewnątrz naszej autonomicznej strony konfig-generator sieci web działa lokalnie w przeglądarce, aby wygenerować prawidłowe konfiguracje ASF, bez szczegółowych informacji wprowadzasz kiedykolwiek w pierwszym rzędzie swoje komputery osobiste, więc nie ma potrzeby martwić się o ewentualne wycieki wrażliwych danych. Jeśli jednak z jakiegoś powodu nie chcesz tam umieszczać swoich poświadczeń, rozumiemy, że i możesz umieścić je ręcznie później w wygenerowanych plikach lub pominąć je całkowicie i działać bez nich.

Jeśli zdecydujesz się wprowadzić swoje poświadczenia, ASF będzie mógł automatycznie zalogować się podczas uruchamiania, które wraz z opcjonalnym 2FA skutecznie pozwoli ci kliknąć dwukrotnie na program aby uruchomić wszystko. If you decide to omit them, then ASF will **ask you** to input those details when needed - that approach won't save them anywhere, but naturally ASF won't be able to operate without your help. To zależy od ciebie, w jaki sposób wolisz więcej i jak zwykle znajdziesz dodatkowe informacje w sekcji **[konfiguracja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.

Na odwrocie możesz również zdecydować o pozostawieniu tylko jednego pola pustego, takiego jak `SteamPassword`. ASF będzie wtedy mógł używać twojego logowania automatycznie, ale w razie potrzeby poprosi o hasło (podobnie jak Steam Client). Jeśli masz jakąś szansę, używasz 4-cyfrowego pinu rodzicielskiego do odblokowania konta, zalecamy również umieszczenie go w polu `SteamParentalPin` , choć w tym przypadku można po prostu pozostawić to puste, a zamiast tego obserwować, jak słaba jest ta ochrona, ponieważ ASF może również "pęknąć" sam w ciągu zaledwie kilku sekund po zalogowaniu. Ups.

Po podążaniu ze wszystkimi powyższymi, więc po raz kolejny **nazwa bota**, **włączono przełącznik**, i **poświadczenia logowania** , twoja strona internetowa będzie wyglądała podobnie jak poniżej:

![Zakładka z botami 2](https://i.imgur.com/yf54Ouc.png)

Teraz możesz kliknąć przycisk "pobierz", a nasz generator konfiguracyjny wygeneruje nowy plik `json` na podstawie wybranej nazwy. Zapisz ten plik w katalogu `config` , który znajduje się w folderze, w którym rozpakowałeś plik zip w poprzednim kroku.

Gratulacje! Właśnie ukończyłeś bardzo prostą konfigurację bota ASF. Jest dużo więcej do odkrycia, ale na razie jest to wszystko, czego potrzebujesz.

---

### Uruchamianie ASF

Wiem, że czekałeś na tę chwilę i nie możemy cię dłużej przetrzymywać, kiedy jesteś teraz gotowy do uruchomienia programu po raz pierwszy. Po prostu dwukrotnie kliknij `ArchiSteamFarm` w pliku binarnym ASF. Możesz to również uruchomić z konsoli.

Teraz byłby dobry czas, aby przejrzeć naszą sekcję **[zdalna komunikacja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** jeśli jesteś zaniepokojony tym, co ASF jest zaprogramowane, zwłaszcza działania, które podejmie w Twoim imieniu, takie jak domyślne dołączenie do naszej grupy Steam. Zawsze możesz wyłączyć wybrane funkcje później, jeśli ich nie spodobają, ASF po prostu ma sensowne wartości domyślne, i musieliśmy podjąć decyzję w sprawie ogólnego zastosowania, która ma zastosowanie do większości naszej bazy użytkowników; jak również nasz własny pogląd na ten program w swojej zasadzie.

Zakładając, że wszystko poszło dobrze, w pierwszym kroku rozważa się zainstalowanie wszystkich wymaganych zależności, i konfigurowanie ASF w trzecim miejscu, ASF powinien uruchomić poprawnie, odkryć swojego pierwszego bota i spróbować zalogować się:

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF będzie prawdopodobnie wymagał więcej szczegółów od Ciebie - 2FA aby uzyskać dostęp do konta (chyba że całkowicie wyłączyłeś SteamGuard, a następnie nie). Po prostu postępuj zgodnie z instrukcjami na ekranie, możesz podać kod z uwierzytelniacza/e-maila lub zaakceptować potwierdzenie w aplikacji mobilnej.

Coś poszło nie tak?

#### ASF nie zaczyna się wcale, nie ma okna konsoli

Albo brakuje warunków .NET, albo pobrałeś niepoprawny wariant ASF dla swojego komputera. Jeśli nie wiesz, co jest źle, sprawdź nasz **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** aby uzyskać dokładny problem, i jeśli nadal utkniesz, skontaktuj się z naszym **[wsparciem](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### Nie zdefiniowano botów

Nie umieściłeś wygenerowanej konfiguracji w katalogu `config`. Niektóre częste błędy w tym kroku mogą obejmować ręczną zmianę rozszerzenia z `.json` np. na `. xt`i niektóre systemy operacyjne (np. Windows) lubią domyślnie ukrywać wspólne rozszerzenia, więc upewnij się, że plik jest w odpowiednim miejscu i posiada odpowiednią nazwę.

#### Nie uruchamianie tego bota, ponieważ jest ono wyłączone w pliku konfiguracyjnym

Zapomniałeś obrócić `Włączony` przełącznik, który informuje ASF o automatycznym uruchomieniu bota. O ile nie było to oczywiste, ale wtedy powinieneś wiedzieć, jak wykonywać polecenia, po prostu `uruchom` swojego bota po tej wiadomości.

#### `Nieprawidłowe hasło`

Twoje dane logowania są najprawdopodobniej błędne. Sprawdź swoje `SteamLogin` i `SteamPassword` w wygenerowanej konfiguracji, jeśli są błędne, popraw je, wracając do etapu konfiguracji. Jeśli nadal masz problemy, spróbuj użyć tych samych danych logowania we własnym kliencie Steam - nie powinieneś się zalogować, i być może otrzymasz więcej informacji na temat tego, co jest w ten sposób niewłaściwe.

#### Wszystko dobrze?

Po przejściu przez początkową bramkę logowania, zakładając, że dane są poprawne, zalogujesz się pomyślnie, i ASF rozpocznie działalność rolniczą przy użyciu domyślnych ustawień, których nie dotknąłeś:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

To dowodzi, że ASF z powodzeniem wykonuje swoje zadanie na Twoim koncie, więc możesz teraz zminimalizować program i zrobić coś innego. Idź dalej, na to zasługowałeś, być może napełnij co najmniej wybrane przez siebie napoje!

Karty rolnicze są przedmiotem innego długiego artykułu takiego jak ten, ale co do zasady: po upływie wystarczająco czasu (w zależności od **[wydajność](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), zobaczysz, że karty handlowe są powoli odrzucane. Oczywiście, aby tak się stało, musisz mieć ważne gry do hodowli, pokazując jako "możesz uzyskać więcej X kropli kart, grając w tę grę" na swojej stronie **[odznaki](https://steamcommunity.com/my/badges)** - jeśli nie ma żadnych gier do hodowli, wtedy ASF poinformuje, że nie ma nic do zrobienia, jak stwierdzono w naszym **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, który odpowiada na najczęściej zadawane pytania w tym momencie, zastanawia się, dlaczego mimo zabudowy 14 gier na ich koncie, ASF twierdzi, że nic nie ma do zrobienia - nie, nie jest to błąd.

Na tym kończy się nasz podstawowy przewodnik po ustanowieniu. Podobnie jak w każdej grze RPG, ukończyłeś samouczek, a teraz zostawiamy Ci cały świat ASF. Na przykład możesz teraz zdecydować, czy chcesz skonfigurować ASF dalej, czy też pozwól mu wykonać swoje zadanie w ustawieniach domyślnych. Zajmiemy się kilkoma dodatkowymi szczegółami, jeśli chcesz przeczytać trochę więcej, a następnie zostaw cię całą wiki do odkrycia.

---

### Konfiguracja rozszerzona

#### Rolnictwo kilku kont na raz

ASF wspiera rolnictwo więcej niż jeden rachunek w danym czasie, który jest jego podstawową funkcją. Możesz dodać więcej kont do ASF generując więcej plików konfiguracyjnych bota, w dokładnie taki sam sposób, jak kilka minut temu wygenerowałeś. Musisz zapewnić tylko dwie rzeczy:

- Unikalna nazwa bota, jeśli masz już swojego pierwszego bota o nazwie `MainAccount`, nie możesz mieć innego bota o tej samej nazwie.
- Prawidłowe dane logowania, takie jak `SteamLogin`, `SteamPassword` i `SteamParentalCode` (jeśli zdecydowałeś się je wypełnić)

Innymi słowy, po prostu przejdź ponownie do konfiguracji i zrób to samo, tylko na drugie lub trzecie konto. Pamiętaj, aby używać unikalnych nazw dla wszystkich botów, aby nie nadpisywać istniejących konfiguracji.

---

#### Zmiana ustawień

W naszym autonomicznym generatorze konfiguracji, zmieniasz istniejące ustawienia w taki sam sposób - generując nowy plik konfiguracyjny. Kliknij na "przełącz zaawansowane ustawienia" i zobacz co jest dla ciebie do odkrycia. W tym przykładzie zmienimy ustawienie `CustomGamePlayedWhileFarming` , która pozwala ustawić niestandardową nazwę wyświetlaną podczas hodowli ASF, zamiast pokazywać rzeczywistą grę.

Najpierw przeanalizujmy to. Jeśli uruchomisz ASF i rozpoczniesz działalność rolniczą, w ustawieniach domyślnych zobaczysz, że Twoje konto Steam jest w grze:

![Steam](https://i.imgur.com/1VCDrGC.png)

Ma to sens po tym, jak ASF właśnie powiedział platformie Steam, że gramy w grę, potrzebujemy z niej kart - prawda? Ale hej, możemy to dostosować! Przełącz ustawienia zaawansowane, jeśli jeszcze nie skończyłeś, a następnie znajdź `CustomGamePlayedWhileFarming`. Po prostu wprowadź dowolny niestandardowy tekst, który chcesz tam wyświetlić, taki jak "Idling kart":

![Zakładka z botami 3](https://i.imgur.com/gHqdEqb.png)

Now download the new config file in exactly the same way, then **overwrite** your old config file with new one. Możesz również usunąć stary plik konfiguracyjny i umieścić nowy w jego miejscu.

ASF jest dość inteligentny i powinien mieć na uwadze, że zmieniłeś konfigurację, który powinien następnie automatycznie odebrać i zastosować bez ponownego uruchomienia programu. Jeśli jakakolwiek szansa na to, że się nie wydarzyła, możesz po prostu uruchomić ponownie program, aby upewnić się, że Twoja nowa konfiguracja zostanie podniesiona. Po tym powinieneś zauważyć, że ASF wyświetla teraz niestandardowy tekst w poprzednim miejscu:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

Potwierdza to, że pomyślnie edytowałeś konfigurację. W dokładnie ten sam sposób możesz zmienić globalne właściwości ASF, przechodząc z zakładki bota na zakładkę ASF, pobierając wygenerowane `ASF. syn` plik konfiguracyjny i umieszczenie go w katalogu `konfiguracja`.

Edycja Twoich konfiguracji ASF może być znacznie łatwiejsza poprzez korzystanie z naszej frontendu ASF-ui, co zostanie wyjaśnione poniżej.

---

#### Używając interfejsu ASF

Jak już wspomnialiśmy, ASF jest aplikacją konsoli i domyślnie nie nie uruchamia graficznego interfejsu użytkownika. Jednakże aktywnie pracujemy nad **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** frontend do naszego interfejsu IPC, który może być bardzo przyzwoitym i przyjaznym dla użytkownika sposobem dostępu do różnych funkcji ASF.

Aby używać ASF-ui, musisz mieć włączoną `IPC` , która jest domyślną opcją, więc jeśli nie wyłączysz jej ręcznie, jest już aktywna. Po uruchomieniu ASF powinieneś być w stanie potwierdzić, że poprawnie uruchomił interfejs IPC automatycznie:

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC w skrócie jest wbudowanym serwerem ASF, który rozpoczyna się lokalnie na Twoim komputerze, pozwalając na interakcję z nim za pomocą swojej ulubionej przeglądarki internetowej. Zakładając, że rozpoczął się on poprawnie, możesz uzyskać dostęp do interfejsu IPC ASF klikając **[ten link](http://localhost:1242)** , tak długo, jak ASF działa z tej samej maszyny. Możesz użyć ASF-ui do różnych celów, np. edycji plików konfiguracyjnych na miejscu lub wysyłania poleceń **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Nie zapoznaj się ze wszystkimi funkcjami ASF.

![Interfejs-ASF](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Podsumowanie

Pomyślnie skonfigurowałeś ASF aby używać swoich kont Steam i już niewiele go dostosowałeś. Jeśli śledziłeś cały nasz przewodnik, to udało Ci się również dostosować ASF za pośrednictwem naszego interfejsu ASF-ui i zaczęto odkrywać jego funkcje. Na tym kończy się nasz samouczek, ale zostawiamy Ci kilka dodatkowych wskazówek, które możesz zainteresować, "boczne zadania", jeśli nalegasz:

- Nasza sekcja **[konfiguracja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** wyjaśni Ci co **wszystkie** te różne ustawienia, które faktycznie widziałeś, i co może zaoferować ASF. Pamiętaj po prostu o prawidłowo uwodnionym podczas czytania, zostaniesz ostrzeżony.
- If you've stumbled upon some issue or you have some generic question, consider our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**, which should cover all, or at least a vast majority of questions and issues that you may have.
- Jeśli chcesz dowiedzieć się wszystkiego o ASF i jak może to ułatwić Twoje życie, wróć do reszty **[naszej wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. Użyj paska bocznego po prawej, aby wybrać temat, który Cię interesuje.
- I wreszcie, jeśli dowiedziałeś, że nasz program jest dla Ciebie przydatny i doceniasz ogromną ilość pracy, którą włożono, możesz również rozważyć mały **[darowizna](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** dla naszej przyczyny. ASF jest pracownikiem miłości, ciężko pracowaliśmy w naszym wolnym czasie przez ostatnie 10 lat, aby umożliwić Ci to doświadczenie, i jesteśmy z tego bardzo dumni - nawet $1 jest bardzo doceniany i pokazuje, że troszczisz. W każdym razie dużo zabawy!

---

## Konfiguracja ogólna

Ten dodatek jest przeznaczony dla zaawansowanych użytkowników, którzy chcą skonfigurować ASF do uruchomienia w wariancie **[ogólny](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)**. Chociaż jest to bardziej problematyczne w użytkowaniu niż **[specyficzne warianty](#os-specific-setup)**, to wiąże się z dodatkowymi korzyściami.

Chcesz użyć wariantu `Ogólne` głównie gdy:
- Używasz systemu operacyjnego, który nie budujemy pakietu specyficznego dla systemu operacyjnego (takiego jak 32-bitowy Windows)
- Masz już .NET Runtime/SDK lub chcesz zainstalować i użyć jednego
- Chcesz zminimalizować rozmiar struktury ASF i ślad pamięci poprzez samodzielne obsługę wymagań czasu pracy
- You want to use a custom **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** which requires a `generic` setup of ASF to run properly (due to missing native dependencies)

Oczywiście można z niego korzystać również w każdym innym scenariuszu, który chcecie, ale powyższe mają najwięcej sensu.

Pamiętaj, że ogólna konfiguracja ma skręt - **** jest w tym przypadku odpowiedzialna za .NET runtime Oznacza to, że jeśli twój .NET SDK (czas uruchomienia) jest niedostępny, nieaktualny lub uszkodzony, ASF po prostu nie zadziała. Dlatego nie polecamy tej konfiguracji dla dorywczych użytkowników, ponieważ teraz musisz się upewnić. ET SDK (czas pracy) pasuje do wymagań ASF i może uruchamiać ASF, w przeciwieństwie do **nas** zapewniając, że nasz . Może to zrobić ET runtime dołączony do ASF.

W przypadku `ogólny pakiet` możesz postępować zgodnie z całym przewodnikiem dotyczącym konkretnego OS, z tylko dwoma małymi zmianami. Oprócz warunków instalacji .NET chcesz również zainstalować .NET SDK, zamiast pobierać i mieć specyficzne funkcje `ArchiSteamFarm(. xe)` plik wykonywalny, teraz pobierzesz i będziesz mieć ogólny `ArchiSteamFarm.dll`. Wszystko inne jest dokładnie takie same.

Z dodatkowymi krokami:
- Install **[.NET prerequisites](#net-prerequisites)**.
- Zainstaluj **[.NET SDK](https://www.microsoft.com/net/download)** (lub co najmniej ASP.NET Core i .NET runtimes) odpowiednie dla systemu operacyjnego. Najprawdopodobniej chcesz użyć instalatora. Zobacz **[wymagania czasu pracy](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** jeśli nie jesteś pewien, która wersja ma zostać zainstalowana.
- Download **[latest ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** in `generic` variant.
- Wypakuj archiwum do nowej lokalizacji.
- **[Konfiguruj ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**w dokładnie taki sam sposób, jak opisano powyżej.
- Uruchom ASF używając skryptu pomocniczego lub wykonując `dotnet /path/to/ArchiSteamFarm.dll` ręcznie z twojej ulubionej powłoki.

Ogólny wariant ASF nie posiada binarnego specyficznego dla maszyny, po tym jak `General` z powodu - jest to platforma-agnostyczna budowa, która może działać wszędzie, więc nie spodziewaj się tam pliku `exe`.

Właśnie dlatego połączyliśmy je ze skryptami pomocniczymi (takimi jak `ArchiSteamFarm.cmd` dla Windows i `ArchiSteamFarm. h` dla Linux/macOS), które znajdują się obok `ArchiSteamFarm.dll`. Możesz ich użyć jeśli nie chcesz ręcznie wykonać polecenia `dotnet`.

Oczywiście skrypty pomocy nie zadziałają, jeśli nie zainstalowałeś. ET SDK i nie masz `dotnet` pliku wykonywalnego w `PATH`. They're also entirely optional to use, you can always `dotnet /path/to/ArchiSteamFarm.dll` manually if you'd like to, as under the hood with some extra tweaks, that's exactly what those scripts are doing anyway.