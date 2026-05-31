# Zarządzanie

Ta część obejmuje tematy związane z optymalnym zarządzaniem procesem ASF. Chociaż nie jest to bezwzględnie obowiązkowe do użycia, to obejmuje kilka wskazówek, sztuczek i dobrych praktyk, które chcielibyśmy podzielić, zwłaszcza dla administratorów systemów, osób pakujących ASF do użytku w repozytoriach zewnętrznych oraz zaawansowanych użytkowników i tak dalej.

---

## Usługa `systemd` dla Linux

W wariantach `general` i `linux` ASF występuje z `ArchiSteamFarm@. plik ervice` , który jest plikiem konfiguracyjnym usługi dla **[`systemd`](https://systemd.io)** Jeśli chcesz uruchomić ASF jako usługę, na przykład aby uruchomić go automatycznie po uruchomieniu urządzenia, następnie usługa `systemd` jest prawdopodobnie najlepszym sposobem na jej wykonanie, dlatego zalecamy go zamiast samodzielnie zarządzać nim przez `nohup`, `ekran` lub tak dalej.

Po pierwsze, utwórz konto dla użytkownika, który chcesz uruchomić ASF, zakładając, że jeszcze nie istnieje. Użyjemy użytkownika `asf` dla tego przykładu, jeśli zdecydowałeś się użyć innego, musisz zastąpić użytkownika `asf` we wszystkich naszych przykładach poniżej wybranym. Nasza usługa nie pozwala na uruchomienie ASF jako `root`, ponieważ jest uważana za **[złą praktykę](#never-run-asf-as-administrator)**.

```sh
su # Lub sudo -i, aby dostać się do powłoki głównej
useradd -m asf # Utwórz konto, które zamierzasz uruchomić ASF
```

Następnie rozpakuj ASF do folderu `/home/asf/ArchiSteamFarm`. The folder structure is important for our service unit, it should be `ArchiSteamFarm` folder in your `$HOME`, so `/home/<user>`. Jeśli wszystko zrobiłeś poprawnie, istnieje plik `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service`. Jeśli używasz wariantu `linux` i nie rozpakowałeś pliku na Linux, ale na przykład użyto transferu plików z systemu Windows, wtedy musisz również `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

Zrobimy wszystkie poniższe działania jako `root`, więc dotrzemy do jego powłoki z `su` lub `sudo -i`.

Po pierwsze, dobrym pomysłem jest zapewnienie, aby nasz folder nadal należał do naszego użytkownika `asf` , `zainstaluj -hR jako:asf /home/asf/ArchiSteamFarm` wykonany gdy to zrobisz. The permissions could be wrong e.g. if you've downloaded and/or unpacked the zip file as `root`.

Po drugie, jeśli używasz ogólnego wariantu ASF, musisz upewnić się, że polecenie `dotnet` jest rozpoznawane i w jednym ze standardowych miejsc: `/usr/local/bin`, `/usr/bin` lub `/bin`. Jest to wymagane dla naszej usługi systemowej, która wykonuje polecenie `dotnet /path/to/ArchiSteamFarm.dll`. Sprawdź, czy `dotnet --info` działa dla Ciebie, jeśli tak, wpisz polecenie `-v dotnet` , aby dowiedzieć się, gdzie się znajduje. Jeśli używałeś oficjalnego instalatora, powinien być w `/usr/bin/dotnet` lub w jednym z dwóch innych miejsc, co jest w porządku. If it's in custom location such as `/usr/share/dotnet/dotnet`, create a **[symlink](https://wikipedia.org/wiki/Symbolic_link)** for it using `ln -s "$(command -v dotnet)" /usr/bin/dotnet`. Teraz `polecenie -v dotnet` powinno zgłosić `/usr/bin/dotnet`, co sprawi, że nasz system będzie działał. Jeśli używasz wariantu specyficznego dla OS, nie musisz nic robić w tym względzie.

Następnie wykonaj `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/systemd/system/ArchiSteamFarm\@. ervice`, to stworzy link symboliczny do naszej deklaracji serwisowej i zarejestruje go w systemie ``. Link symboliczny pozwoli ASF na automatyczną aktualizację jednostki `systemd` w ramach aktualizacji ASF - w zależności od Twojej sytuacji, możesz użyć tego podejścia lub po prostu `cp` plik i zarządzaj nim samodzielnie, jakkolwiek chcesz.

Następnie upewnij się, że `systemd` rozpoznaje naszą usługę:

```
Systemctl status ArchiSteamFarm@asf

: ArchiSteamFarm@asf.service - ArchiSteamFarm Service (asf)
     Załadowany: załadowane (/etc/systemd/system/ArchiSteamFarm@. ervice; wyłączona; preset dostawcy: włączony)
     Aktywny: nieaktywny (martwy)
       Dokumenty: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Zwróć szczególną uwagę na użytkownika, który deklarujemy po `@`, w naszym przypadku `asf`. Nasza jednostka usługowa systemowa oczekuje od Ciebie zgłoszenia użytkownika, ponieważ wpływa na dokładne miejsce binarnego `/home/<user>/ArchiSteamFarm`, a także system użytkownika spowoduje pojawienie się procesu.

Jeśli system zwrócił dane wyjściowe podobne do powyższego, wszystko jest w porządku i prawie skończyliśmy. Pozostało już teraz uruchomienie naszej usługi jako wybranego użytkownika: `systemctl start ArchiSteamFarm@asf`. Poczekaj na sekundę lub dwie, a możesz sprawdzić status ponownie:

```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (asf)
     Załadowany: załadowany (/etc/systemd/system/ArchiSteamFarm@.service; wyłączony; ustawienie wykonawcze: włączone)
     Aktywny: aktywny (uruchomiony) od (...)
       Dokumenty: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   Main PID: (...)
(...)
```

Jeśli `systemd` określa `jako aktywne (uruchomione)`, oznacza to, że wszystko poszło dobrze i możesz sprawdzić, czy proces ASF powinien być uruchomiony, np. z `journalctl -r`, ponieważ ASF domyślnie zapisuje również na jego wyjściu konsoli, który jest rejestrowany przez `systemd`. Jeśli jesteś zadowolony z konfiguracji, którą masz teraz, możesz powiedzieć `systemd` , aby automatycznie uruchomił usługę podczas uruchamiania, wykonując `system, włącz polecenie ArchiSteamFarm@asf`. To wszystko.

Jeśli chcesz zatrzymać proces, po prostu wykonaj `systemctl stop ArchiSteamFarm@asf`. Podobnie, jeśli chcesz wyłączyć ASF uruchamiane automatycznie przy starcie, `systemctl wyłącz ArchiSteamFarm@asf` zrobi to dla ciebie, jest bardzo proste.

Pamiętaj, że ponieważ nie ma standardowego wejścia włączonego dla naszej usługi `systemd` , nie będziesz w stanie wprowadzać swoich danych za pośrednictwem konsoli w zwykły sposób. Uruchamianie przez `systemd` jest równoważne ze specyfikacją **[`Bez względu na: ustawienie`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** i zawiera wszystkie jego konsekwencje. Na szczęście dla ciebie, bardzo łatwo jest zarządzać ASF poprzez **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, które zalecamy w przypadku konieczności podania dodatkowych szczegółów podczas logowania lub dalszego zarządzania procesem ASF.

### Zmienne środowiskowe

Możliwe jest dostarczenie dodatkowych zmiennych środowiskowych do naszej usługi `systemd` , które będziesz zainteresowany na przykład użyć niestandardowego `--cryptkey` **[argumentu wiersza poleceń](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**, dlatego określenie zmiennej środowiskowej `ASF_CRYPTKEY`.

Aby dostarczyć niestandardowe zmienne środowiskowe, utwórz folder `/etc/asf` (w przypadku, gdy nie istnieje), `mkdir -p /etc/asf`. Zalecamy `chown -hR root:root /etc/asf && chmod 700 /etc/asf` aby upewnić się, że tylko użytkownik `root` ma dostęp do odczytu tych plików, ponieważ mogą zawierać wrażliwe właściwości, takie jak `ASF_CRYPTKEY`. Następnie napisz do pliku `/etc/asf/<user>` , gdzie `<user>` jest użytkownikiem świadczącym usługę (`asf` w naszym przykładzie powyżej, tak `/etc/asf/asf`).

Plik powinien zawierać wszystkie zmienne środowiskowe, które chcesz przekazać do procesu. Te, które nie mają dedykowanej zmiennej środowiskowej, można zadeklarować w `ASF_ARGS`:

```sh
# Zgłoś tylko te, których naprawdę potrzebujesz
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# I wszystkie inne, których jesteś zainteresowany
```

### Część nadrzędna jednostki usługowej

Dzięki elastyczności `systemd`, możliwe jest nadpisanie części jednostki ASF przy jednoczesnym zachowaniu oryginalnego pliku jednostki i umożliwieniu ASF jej aktualizacji, na przykład w ramach automatycznej aktualizacji.

W tym przykładzie chcielibyśmy zmodyfikować domyślne zachowanie jednostki ASF `systemd` od restartu tylko po udanym uruchomieniu i ponownym uruchomieniu również po krytycznych awariach. Aby to zrobić, nadpiszemy właściwość `Restart` pod `[Service]` od domyślnego `do` do `zawsze`. Po prostu wykonaj `systemctl edit ArchiSteamFarm@asf`, naturalnie zastępując `asf` docelowym użytkownikiem usługi. Następnie dodaj zmiany, jak wskazano przez `systemd` we właściwej sekcji:

```sh
### Edycja /etc/systemd/system/system/ArchiSteamFarm@asf.service.d/override. onf
### Wszystko, co tutaj i komentarz poniżej stanie się nową zawartością pliku

format@@2
Restart=zawsze

### Wiersze poniżej tego komentarza zostaną odrzucone

### /etc/systemd/system/ArchiSteamFarm@asf. ervice
# [Install]
# WantedBy=multi-user. arget
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm. ll --no-restart --service --system-required
# Restart=on-successful
# RestartSec=1s
# SyslogIdentifier=asf-%i
# User=%i
# (...)
```

I to jest, teraz twoja jednostka działa tak samo, jak gdyby miała tylko `Restart=zawsze` w `[Service]`.

Of course, alternative is to `cp` the file and manage it yourself, but this allows you for flexible changes even if you decided to keep original ASF unit, for example with a **[symlink](https://wikipedia.org/wiki/Symbolic_link)**.

---

## Nigdy nie uruchamiaj ASF jako administratora!

ASF zawiera własną walidację czy proces jest uruchamiany jako administrator (`root`) czy nie. Running as `root` is **not** required for any kind of operation done by the ASF process, assuming properly configured environment it's operating in, and therefore should be regarded as a **bad practice**. This means that on Windows, ASF should **never** be executed with "run as administrator" setting, and on Unix ASF should have a **dedicated user account** for itself, or re-use your own in case of a desktop system.

W celu dalszego opracowania na *dlaczego* zniechęcamy do uruchamiania ASF jako `root`, Odnosi się do **[superuser](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** i innych zasobów. Jeśli nadal nie jesteś przekonany, zapytaj samego siebie, co się stanie z twoim urządzeniem, jeśli ASF proces wykonał polecenie `rf /*` bezpośrednio po jego uruchomieniu.

### Używam jako `root` , ponieważ ASF nie może zapisać do swoich plików

Oznacza to, że masz błędnie skonfigurowane uprawnienia do plików, które ASF próbuje uzyskać. Powinieneś zalogować się jako konto `root` (albo za pomocą `su` lub `sudo -i`), a następnie **skorygować** poprzez wydanie polecenia `-hR asf:asf /path/to/ASF` , zastąp `jako:asf` użytkownikiem, że uruchomisz ASF pod nim oraz `/path/to/ASF`. Jeśli jakakolwiek szansa używasz niestandardowego `--path` informującego użytkownika ASF o używaniu innego katalogu, powinieneś ponownie wykonać to samo polecenie również dla tej ścieżki.

Po tym zrobieniu nie powinieneś już otrzymywać żadnych problemów związanych z ASF nie będąc w stanie pisać własnych plików, ponieważ właśnie zmieniłeś właściciela wszystkiego, co ASF jest zainteresowany użytkownikiem, proces ASF zostanie uruchomiony.

### Używam jako `root` , ponieważ nie wiem jak to zrobić w innym przypadku

```sh
su # lub sudo -i, aby dostać się do powłoki głównej
useradd -m asf # Utwórz konto, które zamierzasz uruchomić ASF pod
w asf:asf /path/to/ASF # Upewnij się, że nowy użytkownik ma dostęp do katalogu ASF
su asf -c /path/to/ASF/ArchiSteamFarm # lub sudo -u asf /path/to/ASF/ArchiSteamFarm, aby faktycznie uruchomić program pod twoim użytkownikiem
```

That would be doing it manually, it's much easier to use our **[`systemd` service](#systemd-service-for-linux)** explained above.

### Wiem lepiej i nadal chcę działać jako `root`

ASF nie przeszkadza ci w tym działaniu, wyświetla tylko ostrzeżenie z krótkim powiadomieniem. Po prostu nie być zszokowany, jeśli jakiś dzień z powodu błędu w programie, wysadzi cały system operacyjny z całkowitą utratą danych - zostałeś ostrzeżony.

---

## Wiele instancji

ASF jest kompatybilny z uruchomieniem wielu instancji procesu na tym samym maszynie. Przypadki mogą być całkowicie niezależne lub pochodzić z tej samej lokalizacji binarnej (w takim przypadku chcesz uruchomić je z innym argumentem `--path` **format@@2[wiersza poleceń](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**).

Podczas uruchamiania wielu instancji z tego samego binarnego, pamiętaj, że zwykle powinieneś wyłączyć automatyczne aktualizacje we wszystkich ich konfiguracjach, ponieważ nie ma synchronizacji między nimi w odniesieniu do automatycznej aktualizacji. Jeśli chcesz nadal włączać automatyczne aktualizacje, zalecamy samodzielne instancje, ale nadal możesz uruchomić aktualizacje, o ile możesz upewnić się, że wszystkie inne instancje ASF są zamknięte.

ASF dołoży wszelkich starań, aby utrzymać minimalną ilość komunikacji obejmującej cały system operacyjny z innymi instancjami ASF. Obejmuje to sprawdzenie katalogu konfiguracyjnego ASF w innych instancjach, oprócz dzielenia się kluczowymi ogranicznikami procesu skonfigurowanymi z `*LimiterDelay` **[globalne właściwości konfiguracyjne](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, zagwarantowanie, że korzystanie z wielu przypadków ASF nie spowoduje powstania problemu ograniczającego szybkość. Jeśli chodzi o aspekty techniczne, wszystkie platformy wykorzystują nasz dedykowany mechanizm niestandardowych bloków plików ASF tworzonych w katalogu tymczasowym, który jest `C:\Users\<YourUser>\AppData\Local\Temp\ASF` na Windows, oraz `/tmp/ASF` na Unix.

Nie jest wymagane dla uruchamiania instancji ASF aby dzielić te same właściwości `*LimiterDelay` , mogą użyć różnych wartości, ponieważ każdy ASF doda swoje skonfigurowane opóźnienie do czasu wydania po nabyciu blokady. Jeśli skonfigurowany `*LimiterDelay` jest ustawiony na `0`, instancja ASF całkowicie pominnie oczekiwanie na zablokowanie danego zasobu, które jest współdzielone z innymi instancjami (które mogą nadal utrzymywać współdzielony zamek ze sobą). Po ustawieniu na jakąkolwiek inną wartość, ASF poprawnie zsynchronizuje się z innymi instancjami ASF i czeka na jego obrót, następnie odblokuj blokadę po skonfigurowanym opóźnieniu, pozwalając na kontynuowanie innych instancji.

ASF bierze pod uwagę ustawienie `WebProxy` przy podejmowaniu decyzji o wspólnym zakresie, co oznacza, że dwa instancje ASF używające różnych konfiguracji `WebProxy` nie będą współdzielić swoich ograniczników. Jest to zaimplementowane w celu umożliwienia `WebProxy` konfiguracji do działania bez nadmiernych opóźnień, zgodnie z oczekiwaniami z różnych interfejsów sieciowych. Powinno to być wystarczająco dobre dla większości przypadków użycia, jednak jeśli masz określoną konfigurację niestandardową, w której jesteś np. routing żąda siebie w inny sposób, możesz samodzielnie określić grupę sieciową poprzez argument `--network-group` **[wiersza poleceń](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**, co pozwoli zadeklarować grupę ASF, która będzie zsynchronizowana z tą instancją. Pamiętaj, że niestandardowe grupy sieciowe są wykorzystywane wyłącznie, co oznacza, że ASF nie będzie już używał `WebProxy` do określania właściwej grupy, jako osoba odpowiedzialna za grupowanie w tym przypadku.

Jeśli chcesz wykorzystać nasze **[`systemd` usługę](#systemd-service-for-linux)** objaśnioną powyżej dla wielu instancji ASF, jest bardzo proste, po prostu użyj innego użytkownika dla naszej deklaracji usługi `ArchiSteamFarm@` i podążaj za pozostałymi krokami. Będzie to równoznaczne z uruchomieniem wielu instancji ASF z różnymi binarami, dzięki czemu mogą one również automatycznie aktualizować i działać niezależnie od siebie.