# Docker

ASF jest dostępny jako **[docker container](https://www.docker.com/what-container)**. Nasze pakiety docker są obecnie dostępne na **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** oraz **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

Należy pamiętać, że uruchomienie ASF w Docker kontenera jest uważane za **zaawansowaną konfigurację**, które jest **niepotrzebne** dla zdecydowanej większości użytkowników i zazwyczaj nie daje **żadnych korzyści** w porównaniu z konfiguracją bez kontenerów. Jeśli uważasz Docker za rozwiązanie uruchamiające ASF jako usługę, na przykład powodując, że zaczyna się automatycznie z systemem operacyjnym, wtedy powinieneś rozważyć przeczytanie sekcji **[zarządzanie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** i skonfigurować poprawną usługę `systemd` , która będzie prawie zawsze **** - lepszym pomysłem niż uruchamianie ASF w Dockeer.

Running ASF in Docker container usually involves **several new problems and issues** that you'll have to face and resolve yourself. Właśnie dlatego **stanowczo** zalecamy uniknięcie go, chyba że posiadasz już wiedzę Dockera i nie potrzebujesz pomocy w zrozumieniu jego wewnętrznych, o których nie będziemy tutaj dyskutować na wiki ASF. Niniejsza sekcja dotyczy głównie ważnych przypadków stosowania bardzo złożonych układów, na przykład w odniesieniu do zaawansowanych sieci lub zabezpieczeń wykraczających poza standardową piaskownicę, z którą ASF jest wyposażony w usługę `systemd` (która zapewnia już lepszą izolację procesu dzięki bardzo zaawansowanym mechanikom bezpieczeństwa). Dla garstkiej liczby osób tutaj wyjaśniamy lepsze pojęcia ASF w odniesieniu do kompatybilności z Dockerem, i tylko tak zakładasz, że posiadasz odpowiednią wiedzę dokującą, jeśli zdecydujesz się korzystać z niej razem z ASF.

---

## Znaczniki

ASF jest dostępny za pomocą kilku typów tagów **[](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `główny`

Generic build of ASF that is built from the very latest commit in `main` branch, which works the same as grabbing latest artifact directly from our **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pipeline. Jest to najwyższy poziom błędnego oprogramowania dedykowanego programistom i zaawansowanym użytkownikom do celów rozwojowych. Obraz jest aktualizowany z każdym zatwierdzeniem w gałęzi `main` GitHub, w związku z tym można oczekiwać bardzo częstych zmian (załamania rzeczy). Jest tutaj, aby oznaczyć aktualny stan projektu ASF, który niekoniecznie musi być stabilny lub przetestowany, tak jak wskazano w naszym cyklu uwalniania. **Ten tag nie powinien być używany w żadnym środowisku produkcyjnym**. Przydatne do weryfikacji, czy konkretny commit naprawił problem, z którym się spotkasz, nie czekając nawet na wstępne wydanie z tym zatwierdzeniem.


### `wydany`

Ogólna konstrukcja ASF, która zawsze wskazuje na najnowszą wersję **[wydaną](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF, w tym przed wydaniem. W porównaniu z tagiem `main` obraz jest aktualizowany za każdym razem, gdy nowy tag GitHub jest wciśnięty. Dedykowany dla zaawansowanych/zasilanych, którzy uwielbiają żyć na krawędzi tego, co można uznać za stabilne i świeże w tym samym czasie. W praktyce działa to samo co znacznik kroczący wskazujący na najnowsze wydanie `A.B.C.D` w momencie ciągnięcia. Pamiętaj, że użycie tego tagu jest takie samo jak używanie naszego **[przed wydaniem](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `stabilna`

Ogólna konstrukcja ASF, która zawsze wskazuje na najnowszą wersję **[stabilną](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF. W porównaniu z tagiem `wydanym` obraz jest aktualizowany po udostępnieniu nowej stabilnej wersji ASF. Zalecane dla osób, które szukają stabilnego wariantu `wydanego wyżej`.

### `najnowsza`

Konstrukcja ASF, która zawsze wskazuje na najnowszą wersję **[stabilną](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF. In comparison with others, this is the **only tag** that includes ASF auto-updates. Celem tego tagu jest zapewnienie domyślnego kontenerowego węzła, który jest zdolny do samodzielnej aktualizacji, specyficznej dla OS-a budowy ASF. Z tego względu obraz nie musi być aktualizowany tak często, jak to możliwe, wersja ASF będzie zawsze w stanie dokonać aktualizacji, jeśli zajdzie taka potrzeba.

Oczywiście `UpdatePeriod` można bezpiecznie wyłączyć (ustaw `0`), ale w tym przypadku prawdopodobnie powinieneś użyć wersji `stabilnej`. Podobnie możesz modyfikować domyślne `Aktualizacja Kanału` w celu śledzenia prewydania jeśli chcesz.

Ze względu na fakt, że obraz `najnowszy` ma możliwość automatycznej aktualizacji, zawiera niepoprawny system operacyjny w wersji `linux` ASF, w przeciwieństwie do wszystkich innych tagów, które zawierają system operacyjny z . ET runtime and `general` ASF. Dzieje się tak, ponieważ nowsza (zaktualizowana) wersja ASF może również wymagać nowszej wersji niż ta, z którą obraz mógłby być zbudowany, które w przeciwnym razie wymagałyby odtworzenia obrazu od zera, co zniwelowałoby planowane zastosowanie.

### `A.B.C.D`

Ogólna kompilacja ASF, która wskazuje na stałą wersję ASF pasującą do tagu. W porównaniu z powyższymi tagami, ten tag jest całkowicie zamrożony, co oznacza, że obraz tutaj nie zostanie zaktualizowany po opublikowaniu. Działa to podobnie do naszych wydań GitHub, które nigdy nie są dotykane po wydaniu początkowym, co gwarantuje ci stabilne i mrożone środowisko. Zazwyczaj powinieneś użyć tego tagu, gdy chcesz użyć specyficznej wersji ASF i oczekiwać deterministycznych rezultatów budowy (np. . zarządzanie wersjami ASF samodzielnie).

---

## Który tag jest dla mnie najlepszy?

To zależy od tego, czego szukasz. For majority of users, `latest` tag should be the best one as it offers exactly what desktop ASF does, just in special Docker container as a service. Jednakże niekoniecznie jest to sposób, w jaki należy używać dockera - zwykle oczekuje się, że przebudujesz kontenery i nie uruchamiaj ich na zawsze, i w tym przypadku powinieneś uznać znacznik `stabilny` lub `wydany` za zgodny z wytycznymi dockera. Wreszcie, jeśli chcesz zamiast tego uruchomić pewną stałą wersję ASF, to naturalnie `A.B.C.D` są tym, czego szukasz.

Zwykle zniechęcamy do próby `main` , ponieważ są one dla nas tutaj, aby oznaczyć aktualny stan projektu ASF. Nic nie gwarantuje, że takie państwo będzie działało właściwie, ale oczywiście jesteś bardzo mile widziany, aby spróbować jeśli jesteś zainteresowany rozwojem ASF.

---

## Architektury

Obraz docker ASF jest obecnie zbudowany na platformie `linux` ukierunkowanej na 3 architektury - `x64`, `ramię` i `arm64`. Więcej o nich można przeczytać w sekcji **[kompatybilność](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**.

Nasze tagi używają manifestu wieloplatformowego, co oznacza, że Docker zainstalowany na twoim komputerze automatycznie wybierze odpowiedni obraz dla Twojej platformy podczas ściągania obrazu. Jeśli jakakolwiek szansa chcesz ściągnąć określony obraz platformy, który nie pasuje do tego, który aktualnie działasz, możesz to zrobić przez `--platform` przełącz odpowiednie polecenia dockera, takie jak docker `, uruchom`. Zobacz dokumentację docker na temat **[manifest obrazu](https://docs.docker.com/registry/spec/manifest-v2-2)** po więcej informacji.

---

## Stosowanie

Do pełnego odniesienia należy użyć **[oficjalnej dokumentacji dockera](https://docs.docker.com/engine/reference/commandline/docker)**, pokryjemy tylko podstawowe użycie w tym przewodniku, jesteś więcej niż mile widziany, aby kopać głębsze.

### Cześć ASF!

Po pierwsze, powinniśmy zweryfikować, czy nasz dokowiec działa poprawnie, będzie to nasz ASF "hello world":

```shell
docker uruchom -it --name asf --pull zawsze --rm justarchi/archisteamfarm
```

`docker run` tworzy nowy kontener dla Ciebie ASF i uruchamia go na pierwszym planie (`-it`). `--pull zawsze` zapewnia, że aktualny obraz zostanie najpierw pobrany, i `--rm` gwarantuje, że nasz kontener zostanie wyczyszczony po zatrzymaniu, ponieważ po prostu sprawdzamy, czy wszystko działa dobrze.

Jeśli wszystko zakończyło się pomyślnie, po ściągnięciu wszystkich warstw i uruchomieniu kontenera, powinieneś zauważyć, że ASF prawidłowo zaczął i poinformował nas, że nie ma zdefiniowanych botów, co jest dobre - sprawdziliśmy, że ASF w docker działa poprawnie. Wciśnij `CTRL+C` , aby zakończyć proces ASF i tym samym również pojemnik.

Jeśli przyjrzysz się bliżej komendy, zauważysz, że nie zadeklarowaliśmy żadnego tagu, automatycznie domyślnie `najnowsze`. Jeśli chcesz użyć tagu innego niż `najnowszy`, na przykład `wydany`, powinieneś zadeklarować go wyraźnie:

```shell
docker uruchom -it --name asf --pull zawsze --rm justarchi/archisteamfarm:zwolniony
```

---

## Używanie głośności

Jeśli używasz ASF w pojemniku z dockerami, musisz oczywiście skonfigurować sam program. Możesz to zrobić na różne sposoby, ale zalecanym byłoby utworzenie katalogu ASF `config` na lokalnej maszynie, następnie zamontuj go jako współdzieloną objętość w pojemniku z dokowalnikiem ASF.

Na przykład zakładamy, że twój folder konfiguracyjny ASF znajduje się w katalogu `/home/archi/ASF/config`. Ten katalog zawiera rdzeń `ASF.json` , jak również boty, które chcemy uruchomić. Teraz musimy tylko załączyć ten katalog jako współdzielony wolumen w naszym pojemniku z dockerami, gdzie ASF oczekuje katalogu konfiguracyjnego (`/app/config`).

```shell
docker uruchom -it -v /home/archi/ASF/config:/app/config --name asf --pull zawsze justarchi/archisteamfarm
```

I to właśnie teraz, Twój kontener z dokowalami ASF użyje udostępnionego katalogu z lokalną maszyną w trybie odczytu, które są potrzebne do konfigurowania ASF. W podobny sposób możesz zamontować inne głośności, które chcesz udostępnić ASF, takie jak `/app/logs` lub `/app/plugins`.

Oczywiście jest to tylko jeden konkretny sposób osiągnięcia tego, czego chcemy, nic nie powstrzymuje państwa od np.: tworzenie własnego pliku `Dockerfile` , który skopiuje pliki konfiguracyjne do katalogu `/app/config` wewnątrz kontenera docker ASF. Zajmujemy tylko podstawowe użycie w tym przewodniku.

### Uprawnienia głośności

Kontener ASF jest domyślnie inicjowany z domyślnym `root` , który umożliwia obsługę rzeczy uprawnień wewnętrznych, a następnie przełącz na użytkownika `asf` (UID `1000`) dla pozostałej części głównego procesu. Powinno to być zadowalające dla zdecydowanej większości użytkowników, wpływa na współdzielony wolumen ponieważ nowo wygenerowane pliki będą normalnie własnością użytkownika `asf` , co może nie być pożądane, jeśli chcesz jakieś innego użytkownika dla twojej współdzielonej objętości.

Istnieją dwa sposoby na zmianę użytkownika ASF. Pierwszą, zalecaną, jest deklarowanie zmiennej środowiskowej `ASF_UID` z docelowym UID, który chcesz uruchomić. Po drugie, alternatywną jest przekazanie `--user` **[flaga](https://docs.docker.com/engine/reference/run/#user)**, która jest bezpośrednio wspierana przez docker.

Możesz sprawdzić swój `uid` na przykład za pomocą polecenia `id -u` , a następnie zadeklarować zgodnie z powyższym poleceniem. Na przykład, jeśli docelowy użytkownik ma `uid` z 1001:

```shell
docker run -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull zawsze justarchi/archisteamfarm

# Alternatywnie, jeśli rozumiesz ograniczenia poniżej
docker uruchom -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull zawsze justarchi/archisteamfarm
```

Różnica pomiędzy flagą `ASF_UID` i `--user` jest subtelna, ale ważna. `ASF_UID` jest niestandardowym mechanizmem obsługiwanym przez ASF, w tym scenariuszu kontener docker nadal rozpoczyna się jako `root`, a następnie skrypt startowy ASF uruchamia główny binarny w `ASF_UID`. Gdy używasz flagi `--user` , rozpoczynasz cały proces, w tym skrypt startowy ASF jako podanego użytkownika. Pierwsza opcja pozwala skryptowi startowemu ASF automatycznie obsługiwać uprawnienia i inne rzeczy dla Ciebie, rozwiązując niektóre powszechne problemy, które mogłeś spowodować, na przykład zapewnia, że katalogi `/app` i `/asf` są faktycznie własnością `ASF_UID`. In second scenario, since we're not running as `root`, we can't do that, and you're expected to handle all of that yourself in advance.

Jeśli zdecydowałeś się użyć flagi `--user` , musisz zmienić właściciela wszystkich plików ASF z domyślnego `1000` na nowego użytkownika niestandardowego. Możesz to zrobić wykonując polecenie poniżej:

```shell
# Wykonaj tylko jeśli nie używasz ASF_UID
docker exec -u root asf_container_name chown -hR 1001 /app /asf
```

Należy to zrobić tylko raz po utworzeniu kontenera z docker `uruchom`, i tylko wtedy, gdy zdecydujesz się używać niestandardowego użytkownika przez flagę docker `--user`. Nie zapomnij również zmienić argumentu `1001` powyżej na `UID` , w którym chcesz uruchomić ASF.

### Objętość z SELinux

Jeśli używasz SELinux w stanie wymuszonym na systemie operacyjnym, który jest domyślnym na przykład na distronach opartych na RHEL, następnie powinieneś zamontować opcję `:Z` , która poprawi dla niej kontekst SELinux.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull zawsze justarchi/archisteamfarm
```

Umożliwi to ASF tworzenie plików ukierunkowanych na głośność wewnątrz kontenera dockera.

---

## Synchronizacja wielu instancji

ASF obejmuje obsługę synchronizacji wielu instancji, jak podano w sekcji **[Zarządzanie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)**. Podczas uruchamiania ASF w kontenerze docker możesz opcjonalnie „opt-in” w procesie, w przypadku gdy używasz wielu kontenerów z ASF i chciałbyś je zsynchronizować.

Domyślnie każdy ASF działający wewnątrz kontenera docker jest gotowy, co oznacza, że synchronizacja nie ma miejsca. Aby włączyć synchronizację między nimi, musisz powiązać ścieżkę `/tmp/ASF` w każdym kontenerem ASF, który chcesz zsynchronizować, do jednej, udostępnionej ścieżki na Twoim serwerze dockera, w trybie odczytu zapisu. Jest to osiągane dokładnie w taki sam sposób, jak wiążące objętość, która została opisana powyżej, przy użyciu różnych ścieżek:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull zawsze justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull zawsze justarchi/archisteamfarm
# itd. wszystkie kontenery ASF są teraz zsynchronizowane ze sobą
```

Zalecamy powiązanie katalogu ASF `/tmp/ASF` również z tymczasowym katalogiem `/tmp` na twoim komputerze, ale oczywiście możesz wybrać inny, który satysfakcjonuje Twoje użycie. Każdy kontener ASF, który ma być zsynchronizowany, powinien mieć katalog `/tmp/ASF` udostępniony innym kontenerom, które biorą udział w tym samym procesie synchronizacji.

Jak prawdopodobnie zgadnąłeś na przykładzie powyżej, możliwe jest również utworzenie dwóch lub więcej "grup synchronizacji", łącząc różne ścieżki hosta docker z ASF `/tmp/ASF`.

Montaż `/tmp/ASF` jest całkowicie opcjonalny i nie jest zalecany, chyba że wyraźnie chcesz zsynchronizować dwa lub więcej kontenerów ASF. Nie zalecamy montowania `/tmp/ASF` dla pojedynczego kontenera, ponieważ nie przynosi absolutnie żadnych korzyści, jeśli spodziewamy się uruchomienia tylko jednego kontenera ASF, i może faktycznie spowodować problemy, których w przeciwnym razie można uniknąć.

---

## Argumenty wiersza poleceń

ASF pozwala na przekazywanie argumentów **[wiersza poleceń](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** w kontenerze docker poprzez zmienne środowiskowe. Powinieneś użyć określonych zmiennych środowiskowych dla obsługiwanych przełączników, a `ASF_ARGS` dla reszty. Można to osiągnąć z przełącznikiem `-e` dodanym do `docker run`, na przykład:

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull zawsze justarchi/archisteamfarm
```

To poprawnie przekaże twoją argument `--cryptkey` do procesu ASF uruchamianego wewnątrz kontenera docker oraz innych argumentów. Oczywiście, jeśli jesteś zaawansowanym użytkownikiem, możesz również zmodyfikować `ENTRYPOINT` lub dodać `CMD` i przekazać swoje własne argumenty.

Jeśli nie chcesz podać niestandardowego klucza szyfrowania lub innych zaawansowanych opcji, zwykle nie musisz zawierać żadnych specjalnych zmiennych środowiskowych, ponieważ nasze kontenery docker są już skonfigurowane do uruchomienia z oczekiwaną domyślną opcją `--no-restart`, tak, że flaga nie musi być wyraźnie określona w `ASF_ARGS`.

---

## IPC

Zakładając, że nie zmieniłeś wartości domyślnej dla `IPC` **[globalna właściwość konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**jest już włączona. Należy jednak zrobić dwie dodatkowe rzeczy, aby IPC działała w Docker'u. Po pierwsze, musisz użyć `IPCPassword` lub zmodyfikować domyślne `KnownNetworks` w niestandardowym `IPC. onfig` , aby umożliwić połączenie z zewnątrz bez użycia jednego. Jeśli nie wiesz co robisz, po prostu użyj `IPCPassword`. Po drugie, musisz zmodyfikować domyślny adres nasłuchujący `localhost`, ponieważ docker nie może przekierować poza ruch do interfejsu pętli. Przykładem ustawienia, które będzie słuchać na wszystkich interfejsach będzie `http://*:1242`. Oczywiście możesz również używać bardziej restrykcyjnych powiązań, takich jak lokalna sieć LAN lub sieć VPN, ale musi to być trasa dostępna z zewnątrz - `localhost` tego nie zrobi, ponieważ trasa znajduje się całkowicie w maszynie gościa.

Aby to zrobić, powinieneś użyć **[niestandardowej konfiguracji IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** takiej jak poniższa konfiguracja:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Po skonfigurowaniu IPC na interfejsie non-loopback, musimy poinformować dockera, aby mapować port ASF `1242/tcp` z przełącznikiem `-P` lub `-p`.

Na przykład to polecenie narażałoby interfejs ASF IPC na działanie komputera (tylko):

```shell
docker run -it -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull zawsze justarchi/archisteamfarm
```

If you set everything properly, `docker run` command above will make **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface work from your host machine, on standard `localhost:1242` route that is now properly redirected to your guest machine. Miło jest również zauważyć, że nie wystawiamy tej drogi dalej, więc połączenie może być wykonane tylko w obrębie hosta dockera i tym samym zapewnić jego bezpieczeństwo. Oczywiście, jeśli wiesz co robisz i zapewnisz odpowiednie środki bezpieczeństwa.

---

### Uzupełnij przykład

Łącząc całą powyższą wiedzę, przykład pełnej konfiguracji wyglądałby tak:

```shell
docker run -p 127.0.0.1:1242:1242 -p [:1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull zawsze --restart unless-stopped justarchi/archisteamfarm
```

Zakłada się, że użyjesz pojedynczego kontenera ASF, ze wszystkimi plikami ASF w `/home/archi/ASF/config`. Powinieneś zmodyfikować ścieżkę konfiguracji do tej, która pasuje do Twojego komputera. Można również dostarczyć niestandardowe wtyczki dla ASF, które można umieścić w `/home/archi/ASF/plugins`. Ta konfiguracja jest również gotowa do opcjonalnego użycia IPC, jeśli zdecydowałeś się na włączenie `IPC. onfig` w katalogu konfiguracyjnym z zawartością taką jak poniżej:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Możesz osiągnąć ten sam efekt polecenia `docker run` powyżej, używając następującej konfiguracji `docker`:

```yaml
wersja: "3. "
usługi:
  jako:
    obraz: justarchi/archisteamfarm
    container_name: asf
    restart: unless-stopped
    ports:
      - "127. .0.1:1242:1242"
      - "[::1]:1242"
    objętość:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

Z innych spraw niż omówiliśmy wyżej, Dodaliśmy `--restart unless-stopped` do obu przykładów powyżej, aby uruchomić ten kontener automatycznie po ponownym uruchomieniu komputera. Możesz go usunąć/zmienić tak, aby odpowiadał Twoim potrzebom.

---

## Porady

When you already have your ASF docker container ready, you don't have to use `docker run` every time. Możesz łatwo zatrzymać/uruchomić kontener docker ASF z `docker stop asf` i `start asf`. Keep in mind that if you're not using `latest` tag then using up-to-date ASF will still require from you to `docker stop`, `docker rm` and `docker run` again. Dzieje się tak, ponieważ musisz przebudować swój kontener z świeżego obrazu docker ASF za każdym razem, gdy chcesz używać wersji ASF dołączonej do tego obrazu. W tagu `najnowszy` ASF uwzględnił możliwość automatycznej aktualizacji, więc odbudowa obrazu nie jest konieczna do używania aktualnego ASF (ale jest to nadal dobry pomysł, aby robić to od czasu do czasu w celu użycia nowego . Zależności ET runtime i bazowy system operacyjny, które mogą być potrzebne podczas przeskakywania przez główne aktualizacje wersji ASF).

Jak wskazano powyżej, ASF w tagu innym niż `najnowsze` nie będzie automatycznie aktualizować, co oznacza, że **Ty** jest odpowiedzialny za korzystanie z aktualnego repozytorium `justarchi/archisteamfarm`. Ma to wiele zalet, ponieważ zazwyczaj aplikacja nie powinna dotykać własnego kodu podczas uruchamiania, ale rozumiemy również wygodę wynikającą z tego, że nie musisz martwić się o wersję ASF w Twoim pojemniku z dockerami. Jeśli dbasz o dobre praktyki i właściwe stosowanie domieszki, Tag `wydany` jest tym, co sugerowalibyśmy zamiast `najnowszej`, ale jeśli nie możesz się z tym oburzyć i po prostu chcesz zrobić ASF zarówno samodzielnie, jak i automatyczną aktualizację, następnie `najnowsze` zrobi to.

Zazwyczaj należy uruchomić ASF w kontenerem docker z `Headless: true` globalne ustawienie. Będzie to wyraźnie informować ASF, że nie jesteś tu w celu podania brakujących szczegółów i nie powinno o to prosić. Oczywiście, dla początkowej konfiguracji powinieneś rozważyć pozostawienie tej opcji w `false` , aby można było łatwo skonfigurować rzeczy, ale w dłuższej perspektywie zazwyczaj nie jesteś podłączony do konsoli ASF, dlatego zasadne byłoby poinformowanie ASF o tym i użycie polecenia `` **[w razie potrzeby](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. W ten sposób ASF nie będzie musiał czekać nieskończenie na wprowadzanie przez użytkownika, które nie nastąpi (i marnotrawienie zasobów w tym czasie). It will also allow ASF to run in non-interactive mode inside container, which is crucial e.g. in regards to forwarding signals, making it possible for ASF to gracefully close on `docker stop asf` request.