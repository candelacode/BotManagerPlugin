# Argumenty wiersza poleceń

ASF zawiera obsługę kilku argumentów wiersza poleceń, które mogą wpływać na środowisko wykonawcze programu. Te mogą być używane przez zaawansowanych użytkowników, aby określić, jak program powinien działać. W porównaniu z domyślnym plikiem konfiguracyjnym `ASF.json`, argumenty wiersza polecenia są używane do inicjalizacji rdzenia (np. `--path`), ustawienia specyficzne dla platformy (np. `--system-required`) lub wrażliwe dane (np. `--cryptkey`).

---

## Stosowanie

Stosowanie zależy od twojego systemu operacyjnego i ASF.

Natywny:

```shell
dotnet ArchiSteamFarm.dll --argument --otherOne
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --otherOne
```

Argumenty wiersza polecenia są również obsługiwane w ogólnych skryptach pomocniczych, takich jak `ArchiSteamFarm.cmd` lub `ArchiSteamFarm.sh`. In addition to that, you can also use `ASF_ARGS` environment property, like stated in our **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** and **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** sections.

Jeśli argument zawiera spacje, nie zapomnij go uwzględnić. Te dwa są złe:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Bad!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Bad!
```

Jednak te dwa są całkowicie w porządku:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Argumenty

`--cryptkey <key>` lub `--cryptkey=<key>` - uruchomi ASF z niestandardowym kluczem kryptograficznym `<key>`. Ta opcja wpływa na **[bezpieczeństwo](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** i spowoduje, że ASF użyje niestandardowego klucza `<key>` zamiast domyślnego klucza zapisanego na stałe w pliku wykonywalnym. Ponieważ ta właściwość wpływa na domyślny klucz szyfrowania (do celów szyfrowania), jak również na sól (do celów haszowania), Pamiętaj, że wszystko zaszyfrowane/hashowane tym kluczem będzie wymagało przekazania go po każdym uruchomieniu ASF.

Nie ma wymogu dotyczącego długości lub znaków `<key>` , ale ze względów bezpieczeństwa zalecamy wybranie wystarczająco długiego hasła z eu. . losowe 32 znaki, na przykład używając `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; polecenie echo` na Linux.

Miło wspomnieć, że istnieją również dwa inne sposoby na podanie tych szczegółów: `--cryptkey-file` i `--input-cryptkey`.

Ze względu na charakter tej właściwości, możliwe jest również ustawienie klucza kryptograficznego, deklarując zmienną środowiskową `ASF_CRYPTKEY` , które mogą być bardziej odpowiednie dla osób, które chciałyby uniknąć wrażliwych szczegółów w argumentach dotyczących tego procesu.

---

`--cryptkey-file <path>` lub `--cryptkey-file=<path>` - rozpocznie ASF niestandardowym kluczem kryptograficznym odczytywanym z `<path>` pliku. Służy to temu samemu celowi co `--cryptkey <key>` wyjaśnionemu powyżej, tylko mechanizm się różni, ponieważ ta właściwość będzie czytać `<key>` od dostarczonego `<path>`. Jeśli używasz tego razem z `--path`, wziąć pod uwagę fakt, że względna ścieżka będzie różna w zależności od kolejności argumentów, tj. . czy przełączysz `--path` przed lub po `--cryptkey-file`.

Ze względu na charakter tej właściwości, możliwe jest również ustawienie pliku klucza kryptowaluta, deklarując zmienną środowiskową `ASF_CRYPTKEY_FILE` , które mogą być bardziej odpowiednie dla osób, które chciałyby uniknąć wrażliwych szczegółów w argumentach dotyczących tego procesu.

---

`--ignore-unsupported-environment` - spowoduje zignorowanie przez ASF problemów związanych z działaniem w niewspieranym środowisku, które normalnie są sygnalizowane z błędem i wymuszonym wyjściem. Nieobsługiwane środowisko obejmuje na przykład uruchomione `win-x64` specyficzne budowanie na `linux-x64`. Podczas gdy ta flaga pozwoli ASF na podjęcie próby uruchomienia takich scenariuszy, należy poinformować, że nie wspieramy tych oficjalnie i zmusza ASF do zrobienia tego w całości **na własne ryzyko**. Ważne jest, aby zaznaczyć, że **wszystkie** z nieobsługiwanych scenariuszy środowiskowych **można skorygować**. Zdecydowanie zalecamy rozwiązanie nierozstrzygniętych problemów zamiast deklarowania tego argumentu.

---

`--input-cryptkey` - podczas uruchamiania ASF zapyta o `--cryptkey`. Ta opcja może być przydatna dla ciebie, jeśli zamiast dostarczać klawisz kryptograficzny, czy to w zmiennych środowiskowych, czy w pliku, wolałbyś nie zapisywać go nigdzie i zamiast tego wprowadzić go ręcznie przy każdym uruchomieniu ASF.

---

`--minimized` - spowoduje zminimalizowanie okna konsoli ASF wkrótce po uruchomieniu. Przydatne głównie w scenariuszach auto-startu, ale mogą być również wykorzystywane poza nimi. Wariant ten wymaga odpowiedniego wsparcia środowiska – może nie działać poprawnie we wszystkich możliwych scenariuszach.

---

`--network-group <group>` lub `--network-group=<group>` - spowoduje uruchomienie ograniczników ASF z niestandardową grupą sieciową `<group>` Ta opcja wpływa na działanie ASF w **[wiele instancji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** przez sygnalizowanie, że dana instancja jest zależna tylko od instancji współdzielących tę samą grupę sieciową, i niezależnie od reszty. Zazwyczaj chcesz użyć tej właściwości tylko wtedy, gdy przekierowujesz żądania ASF przez niestandardowy mechanizm (np. różne adresy IP) i chcesz samodzielnie ustawić grupy sieciowe, bez polegania na ASF aby robić to automatycznie (co obecnie obejmuje uwzględnianie tylko `WebProxy`. Pamiętaj, że przy użyciu niestandardowej grupy sieciowej jest to unikalny identyfikator w lokalnej maszynie, i ASF nie weźmie pod uwagę żadnych innych szczegółów, takich jak wartość `WebProxy` , pozwalając . . rozpocznij dwa przypadki z różnymi wartościami `WebProxy` , które nadal są od siebie zależne.

Ze względu na charakter tej właściwości, można również ustawić wartość deklarując zmienną środowiskową `ASF_NETWORK_GROUP` , które mogą być bardziej odpowiednie dla osób, które chciałyby uniknąć wrażliwych szczegółów w argumentach dotyczących tego procesu.

---

`--no-config-migrate` - domyślnie ASF automatycznie migruje pliki konfiguracyjne do najnowszej składni. Migracja obejmuje przekształcenie przestarzałych właściwości na najnowsze, usuwanie właściwości z wartościami domyślnymi (ponieważ nie mają one żadnego skutku), jak również ogólne czyszczenie pliku (sprostowanie wcięć i podobne). To prawie zawsze dobry pomysł, ale może się zdarzyć szczególna sytuacja, w której wolałbyś ASF nigdy nie nadpisywać plików konfiguracyjnych automatycznie. Na przykład możesz chcesz `chmod 400` swoje pliki konfiguracyjne (tylko do odczytu dla właściciela) lub umieść `chattr +i` nad nimi, w rezultacie odmowa dostępu do zapisu dla wszystkich. . jako środek bezpieczeństwa. Zazwyczaj zalecamy utrzymanie migracji konfiguracji włączonej, ale jeśli masz szczególny powód, aby go wyłączyć i zamiast tego wolałaby, aby ASF tego nie robił, możesz użyć tego przełącznika do osiągnięcia tego celu. Pamiętajmy jednak, że zapewnienie prawidłowych ustawień ASF stanie się od teraz na Twojej nowej odpowiedzialności, zwłaszcza w odniesieniu do deprekacji i refaktoringu właściwości w przyszłych wersjach ASF.

---

`--no-config-watch` - domyślnie ASF ustawia `FileSystemWatcher` na twoim katalogu `config` , aby słuchać wydarzeń związanych ze zmianami plików, aby mogła interaktywnie dostosowywać się do nich. Na przykład, obejmuje to zatrzymanie botów przy usuwaniu konfiguracji, ponowne uruchomienie bota po zmianie konfiguracji, lub wczytywanie kluczy do **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** po wrzuceniu ich do katalogu `config`. Ten przełącznik pozwala wyłączyć takie zachowanie, co spowoduje całkowite zignorowanie wszystkich zmian w katalogu `config` , wymaganie od Państwa ręcznego wykonania takich czynności, jeżeli uzna to za właściwe (co zazwyczaj oznacza ponowne uruchomienie procesu). Zalecamy utrzymanie włączonych zdarzeń konfiguracyjnych, ale jeśli masz szczególny powód do ich wyłączenia i zamiast tego wolałaby, aby ASF tego nie robił, możesz użyć tego przełącznika do osiągnięcia tego celu.

---

`--no-restart` - domyślnie ASF jest zgodny z **[`AutoRestart`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#autorestart)** właściwość konfiguracji, które możesz użyć do określenia, czy ponowne uruchomienie jest dozwolone w razie potrzeby. Niektóre rozwiązania, które zapewniamy przejmują zarządzanie procesami i są wyraźnie niezgodne z funkcją automatycznego ponownego uruchomienia ASF, takie jak uruchomienie ASF w `docker` lub `systemd`, ponieważ wymagają one jedynie wyjścia z systemu, ponieważ ich obowiązkiem jest jego ponowne uruchomienie w późniejszym terminie, jeżeli uzna to za stosowne. Ponieważ dowolna edycja konfiguracji jest niechciana z doświadczenia użytkownika, ta zmiana po prostu nadpisuje twoją właściwość `AutoRestart` poprzez wyraźne inicjowanie jej do `false`, nawet jeśli określiłeś inaczej w konfiguracji. Dzięki temu ASF może być z wyprzedzeniem informowany o prowadzeniu działalności w takim środowisku, bez wymogu podania kompatybilnego `AutoRestart: false` plik konfiguracyjny.

Oprócz powyższego, `--no-restart`, w przeciwieństwie do `AutoRestart: false`, uniemożliwi również używanie polecenia `restartu` lub w inny sposób wyda proces ASF do ponownego uruchomienia, ponieważ przełącznik wyraźnie stwierdza, że nie jest kompatybilny z taką konfiguracją, podczas gdy `Właściwość AutoRestart` określa tylko domyślne zachowanie.

Zazwyczaj możesz (i powinieneś) kontrolować zachowanie wyjaśnione tutaj w pliku konfiguracyjnym, aczkolwiek jeśli używasz ASF wewnątrz własnego skryptu lub innego podobnego środowiska, możesz również użyć tego przełącznika, który uniemożliwi ASF ponowne uruchomienie się.

---

`--no-steam-parental-generation` - domyślnie ASF automatycznie spróbuje wygenerować kody rodzicielskie Steam, jak opisano w **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** właściwość konfiguracyjna. Jednakże, ponieważ może to wymagać nadmiernej ilości zasobów systemu operacyjnego, ten przełącznik pozwala wyłączyć to zachowanie, co spowoduje pominięcie automatycznego generowania ASF i przejście od razu do zapytania użytkownika o kod PIN, co w normalnych warunkach dzieje się tylko wtedy, gdy autogeneracja zakończyła się niepowodzeniem. Zazwyczaj zalecamy utrzymanie włączonej generacji, ale jeśli masz szczególny powód, aby go wyłączyć i zamiast tego wolałaby, aby ASF tego nie robił, możesz użyć tego przełącznika do osiągnięcia tego celu.

---

`--path <path>` lub `--path=<path>` - ASF zawsze przechodzi do własnego katalogu po uruchomieniu. Określając ten argument, ASF przejdzie do podanego katalogu po inicjalizacji, który pozwala na używanie niestandardowej ścieżki dla różnych części aplikacji (w tym `config`, `loguje katalogi`, `plugins` i `www` oraz `NLog. plik onfig` ), bez potrzeby duplikowania pliku binarnego w tym samym miejscu. To może być szczególnie przydatne, jeśli chcesz oddzielić plik binarny od aktualnej konfiguracji, tak jak to ma miejsce w opakowaniach podobnych do Linuxa - w ten sposób możesz użyć jednego (aktualnego) binarnego z kilkoma różnymi konfiguracjami. Ścieżka może być względna zgodnie z aktualnym miejscem binarnym ASF lub bezwzględna. Pamiętaj, że to polecenie wskazuje na nowy "ASF home" - katalog, który ma taką samą strukturę jak oryginalny ASF, z katalogiem `config` w środku, zobacz poniższy przykład wyjaśnienia.

Ze względu na charakter tej właściwości, możliwe jest również ustawienie oczekiwanej ścieżki deklarując zmienną środowiskową `ASF_PATH` , które mogą być bardziej odpowiednie dla osób, które chciałyby uniknąć wrażliwych szczegółów w argumentach dotyczących tego procesu.

Jeśli rozważasz użycie tego argumentu wiersza poleceń do uruchamiania wielu instancji ASF, zalecamy czytanie naszej strony zarządzania **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** w ten sposób.

Przykłady:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Bezwzględna ścieżka
dotnet /opt/ASF/ArchiSteamFarm.dll --path .. TargetDirectory # Względna ścieżka działa również
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # To samo co zmienna env
```

```text
<unk> <unk> <unk> <unk> 📁 /opt
<unk> <unk> <unk> <unk> 📁 ASF
<unk> <unk> <unk> <unk> ⚙️ ArchiSteamFarm.dll
<unk> <unk> <unk> <unk> <unk> <unk> ...
<unk> <unk> <unk> <unk> 📁 TargetDirectory
<unk> <unk> <unk> <unk> <unk> 📁 config
<unk> <unk> <unk> 📁 logs (wygenerowany)
<unk> <unk> <unk> <unk> <unk> 📁 plugins (opcjonalnie)
<unk> <unk> <unk> <unk> 📁 www (opcjonalnie)
<unk> <unk> <unk> <unk> 📄 log. xt (wygenerowany)
<unk> <unk> <unk> <unk> 📄 NLog.config (opcjonalnie)
<unk> <unk> <unk> <unk> ...
```

---

`--service` - ten przełącznik jest używany głównie przez naszą usługę `systemd` i wymusza `Headless` of `true`. Jeśli nie masz konkretnej potrzeby, zamiast tego powinieneś skonfigurować własność `Headless` bezpośrednio w konfiguracji. Ten przełącznik jest tutaj, więc nasza usługa `systemd` nie będzie musiała dotykać konfiguracji globalnej, aby dostosować ją do własnego środowiska. Oczywiście, jeśli masz podobną potrzebę, możesz również skorzystać z tego przełącznika (inaczej jesteś lepszy z globalną właściwością konfiguracyjną).

---

`--system-required` - oświadczenie, że ten przełącznik spowoduje, że ASF spróbuje podpisać system operacyjny, że proces wymaga uruchomienia systemu przez cały okres jego użytkowania. Może to być szczególnie przydatne podczas nocnego chowu na komputerze osobistym lub laptopie, ponieważ ASF będzie w stanie obudzić twój system podczas jego działania. Ta funkcja jest obecnie obsługiwana przez Linux i Windows.

W systemie Linux będziesz potrzebował poprawnie pracować **[dbus](https://en.wikipedia.org/wiki/D-Bus)** z demonem logowania, który obsługuje funkcję **[`Inhibit()`](https://systemd.io/INHIBITOR_LOCKS/)** Dwa najpopularniejsze demony `systemd` oraz `elogind`zostały potwierdzone, aby to wspierać. Większość środowisk stacjonarnych (takich jak Gnome czy KDE) powinna być dostępna bez opakowania, ponieważ już teraz zależą od tej funkcjonalności dla własnych potrzeb.

Nie ma specjalnych wymogów dotyczących okien i okien nie powinny być wypełniane.