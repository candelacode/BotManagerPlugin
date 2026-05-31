# IPC

ASF obejmuje swój własny unikalny interfejs IPC, który może być wykorzystywany do dalszej interakcji z procesem. IPC oznacza **[międzyprocesowa komunikacja](https://en.wikipedia.org/wiki/Inter-process_communication)** i w najprostszej definicji jest to "interfejs internetowy ASF" oparty na **[Serwer HTTP Kestrel](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel)** , który może być użyty do dalszej integracji z procesem, zarówno jako frontend dla użytkownika końcowego (ASF-ui), jak i backend dla integracji stron trzecich (ASF API).

IPC może być wykorzystywany w wielu różnych rzeczach, w zależności od Twoich potrzeb i umiejętności. Na przykład możesz użyć go do pobierania statusu ASF i wszystkich botów, wysyłania poleceń ASF, pobierania i edycji konfiguracji globalnych/bota, dodawanie nowych botów, usuwanie istniejących botów, przesyłanie kluczy dla **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** lub dostęp do pliku dziennika ASF. Wszystkie te działania są ujawniane przez nasz API, co oznacza, że możesz kodować własne narzędzia i skrypty, które będą w stanie komunikować się z ASF i wpływać na nie w czasie pracy. Dodatkowo, wybrane działania (takie jak wysyłanie poleceń) są również wdrażane przez nasz ASF-ui, który umożliwia łatwy dostęp do nich za pośrednictwem przyjaznego interfejsu internetowego.

---

# Stosowanie

Jeśli nie wyłączyłeś ręcznie IPC przez `IPC` **[globalna właściwość konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, domyślnie jest włączona. ASF poda uruchomienie IPC w logu, którego można użyć do sprawdzenia, czy interfejs IPC został poprawnie uruchomiony:

```text
INFO|ASF|Start() Uruchamianie serwera IPC...
ASF|Start() serwer IPC gotowy!
```

Serwer http ASF jest teraz nasłuchiwany na wybranych punktach końcowych. Jeśli nie podałeś niestandardowego pliku konfiguracyjnego dla IPC, będzie to `localhost`, oba bazujące na IPv4 **[127. .0.1](http://127.0.0.1:1242)** i bazujące na IPv6 **[[:1]](http://[::1]:1242)** domyślny port `1242`. Możesz uzyskać dostęp do naszego interfejsu IPC przez powyższe linki, ale tylko z tej samej maszyny, co uruchomiony proces ASF.

Interfejs IPC ASF ujawnia trzy różne sposoby dostępu do niego, w zależności od planowanego użycia.

Na najniższym poziomie jest **[ASF API](#asf-api)** , który jest podstawą naszego interfejsu IPC i pozwala na działanie wszystkiego innego. To właśnie chcesz użyć we własnych narzędziach, narzędziach i projektach, aby bezpośrednio komunikować się z ASF.

Na średnim terenie znajduje się nasza **[Dokumentacja Swagger](#swagger-documentation)** , która działa jako frontend dla ASF API. Zawiera pełną dokumentację ASF API, a także umożliwia łatwiejszy dostęp do niej. To właśnie chcesz sprawdzić, czy planujesz napisać narzędzie, projekty użyteczności publicznej lub inne projekty, które mają komunikować się z ASF za pośrednictwem interfejsu API.

Na najwyższym poziomie jest **[ASF-ui](#asf-ui)** , który opiera się na naszym API ASF i zapewnia przyjazny dla użytkownika sposób wykonania różnych akcji ASF. Jest to nasz domyślny interfejs IPC zaprojektowany dla użytkowników końcowych i doskonały przykład tego, co możesz zbudować z ASF API. Jeśli chcesz, możesz użyć własnego własnego interfejsu internetowego do używania z ASF, określając `--path` **[argument wiersza poleceń](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** i używając niestandardowego katalogu `www` znajdującego się w tym miejscu.

---

# Interfejs-ASF

ASF-ui jest projektem społecznościowym, którego celem jest stworzenie przyjaznego dla użytkownika interfejsu graficznego dla użytkowników końcowych. Aby to osiągnąć, działa jako frontend do naszego **[ASF API](#asf-api)**, pozwalając na wykonywanie różnych czynności z łatwością. To jest domyślny interfejs użytkownika.

Jak stwierdzono powyżej, ASF-ui jest projektem społecznościowym, który nie jest utrzymywany przez głównych deweloperów ASF. Podąża za własnym przepływem w **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** , który powinien być używany dla wszystkich powiązanych pytań, problemów, raportów o błędach i sugestii.

Można używać ASF-ui do ogólnego zarządzania procesem ASF. Pozwala na przykład na zarządzanie botami, modyfikowanie ustawień, wysyłanie poleceń i osiąganie wybranych innych funkcji zwykle dostępnych za pomocą ASF.

![Interfejs-ASF](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# API ASF

Nasze ASF API jest typowe **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** webAPI oparte na JSON jako głównym formacie danych. Robimy wszystko, co w naszej mocy, aby dokładnie opisać odpowiedź, używając obu kodów statusu HTTP (w stosownych przypadkach), oprócz odpowiedzi możesz przeanalizować siebie, aby dowiedzieć się, czy żądanie zakończyło się sukcesem, a jeśli nie, to dlaczego.

Dostęp do naszego API ASF można uzyskać poprzez wysyłanie odpowiednich żądań do odpowiednich punktów końcowych `/Api`. Możesz użyć tych punktów końcowych API, aby stworzyć własne skrypty, narzędzia, GUI i tak dalej. Właśnie to osiąga nasz ASF-ui, a każde inne narzędzie może osiągnąć to samo. ASF API jest oficjalnie obsługiwane i utrzymywane przez zespół ASF.

Dla pełnej dokumentacji dostępnych punktów końcowych, opisów, żądań, odpowiedzi, kodów statusu http i wszystkiego innego uwzględniając ASF API, zapoznaj się z naszą dokumentacją **[swagger](#swagger-documentation)**.

![API ASF](https://github.com/user-attachments/assets/08c3d4ad-ea77-403d-a18a-b75c3d0a3097)


---

# Konfiguracja niestandardowa

Nasz interfejs IPC obsługuje dodatkowy plik konfiguracyjny, `IPC.config` , który powinien być umieszczony w standardowym katalogu `config`.

Jeśli jest dostępny, ten plik określa zaawansowaną konfigurację serwera ASF Kestrel http wraz z innymi regulacjami związanymi z IPC. Jeśli nie masz konkretnej potrzeby, nie ma powodu, aby używać tego pliku, ponieważ ASF już używa rozsądnych wartości domyślnych w tym przypadku.

Plik konfiguracyjny opiera się na następującej strukturze JSON:

```json
{
    "Kestrel": {
        "Endpoints": {
            "example-http4": {
                "Url": "http://127. .0. :1242"
            },
            "example-http6": {
                "Url": "http://[::1]:1242"
            },
            "przykład-https4": {
                "Url": "https://127. .0.1:1242”,
                "Certyfikat": {
                    "Ścieżka": "/path/to/certyfikat. fx",
                    "Hasło": "passwordToPfxFileAbove"
                }
            },
            "przykład-https6": {
                "Url": "https://[::1]:1242",
                "Certyfikat": {
                    "Ścieżka": "/path/to/certyfikat. fx",
                    "Hasło": "passwordToPfxFileAbove"
                }
            }
        },
        "KnownNetworks": [
            "10. .0.0/8",
            "172.16.0. /12",
            "192.168.0. /16"
        ],
        "ŚcieżkaBa": "/"
    }
}
```

`Punkty końcowe` - Jest to zbiór punktów końcowych, każdy punkt końcowy ma własną unikalną nazwę (taką jak `example-http4`) i `URL` właściwości, która określa `Protocol://Host:Port` adres nasłuchiwania. Domyślnie ASF nasłuchuje adresów IPv4 i IPv6 http, ale w razie potrzeby dodaliśmy przykłady https do użycia. Powinieneś zadeklarować tylko te punkty końcowe, których potrzebujesz, zawarliśmy 4 przykładowe punkty powyżej, aby łatwiej je edytować.

`Host` akceptuje `localhost`, stały adres IP interfejsu, na którym powinien go słuchać (IPv4/IPv6), lub `*` wartość, która łączy serwer http ASF ze wszystkimi dostępnymi interfejsami. Używanie innych wartości, takich jak `mydomain.com` lub `192.168.0.` działa tak samo jak `*`, nie ma zaimplementowanego filtrowania IP, dlatego bądź niezwykle ostrożny, gdy używasz wartości `Host` , które pozwalają na zdalny dostęp. Umożliwi to dostęp do interfejsu IPC ASF z innych maszyn, co może stanowić zagrożenie dla bezpieczeństwa. Zdecydowanie zalecamy użycie słowa `IPCPassword` (i najlepiej twojego własnego zapory) **co najmniej** w tym przypadku.

`KnownNetworks` - Ta zmienna **opcjonalna** określa adresy sieci, które uważamy za wiarygodne. Domyślnie ASF jest skonfigurowany do interfejsu zaufania (`localhost`, ten sam komputer) **tylko**. Ta właściwość jest używana na dwa sposoby. Po pierwsze, jeśli opuścisz `IPCPassword`, wtedy zezwolimy tylko maszynom z znanych sieci na dostęp do interfejsu ASF i zaprzeczamy wszystkim innym jako środkom bezpieczeństwa. Po drugie, właściwość ta ma kluczowe znaczenie w odniesieniu do odwracalnych pełnomocników mających dostęp do ASF, ponieważ ASF będzie honorować swoje nagłówki tylko wtedy, gdy serwer odwrotnego serwera proxy pochodzi ze znanych sieci. Nadzór nad nagłówkami ma kluczowe znaczenie w odniesieniu do mechanizmu antybruteforce ASF, ponieważ zamiast zakazywać odwrotnego wskaźnika zastępczego w przypadku problemu, zbanuje IP określone przez odwrotne proxy jako źródło oryginalnej wiadomości. Bądź niezwykle ostrożny z sieciami, które tutaj określasz, ponieważ umożliwia potencjalny atak na spoofing IP i nieautoryzowany dostęp w przypadku, gdy zaufana maszyna jest zagrożona lub niesłusznie skonfigurowana.

`PathBase` - Jest to **opcjonalna** ścieżka podstawowa, która będzie używana przez interfejs IPC. Domyślnie `/` i nie powinno być wymagane do modyfikowania większości przypadków używania. Zmieniając tę właściwość, będziesz przechowywać cały interfejs IPC na niestandardowym prefiksie, na przykład `http://localhost:1242/MyPrefix` zamiast `http://localhost:1242` sam. Używanie niestandardowych `PathBase` może być wymagane w połączeniu ze specyficzną konfiguracją odwróconego serwera proxy, w którym chcesz używać tylko określonego adresu URL, na przykład `mydome. om/ASF` zamiast całej domeny `mydomain.com`. Zwykle wymagałoby to od Ciebie zapisania reguły przepisywania dla twojego serwera internetowego, która miałaby mapować domenę `. om/ASF/Api/X` -> `localhost:1242/Api/X`, ale zamiast tego możesz zdefiniować niestandardową `PathBase` z `/ASF` i uzyskać łatwiejszą konfigurację domeny `. om/ASF/Api/X` -> `localhost:1242/ASF/Api/X`

Jeśli naprawdę musisz określić niestandardową ścieżkę bazową, najlepiej zostawić ją domyślnie.

## Przykładowe konfiguracje

### Zmiana domyślnego portu

Następująca konfiguracja po prostu zmienia domyślny port nasłuchujący ASF z `1242` na `1337`. Możesz wybrać dowolny port jaki chcesz, ale polecamy zasięg `1024-32767` , ponieważ inne porty są zazwyczaj **[zarejestrowane](https://en.wikipedia.org/wiki/Registered_port)**, i może na przykład wymagać dostępu `root` na Linux.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP4": {
                "Url": "http://127. .0. :1337"
            },
            "HTTP6": {
                "Url": "http://[::1]:1337"
            }
        }
    }
}
```

---

### Włączenie dostępu do wszystkich adresów IP

The following config will allow remote access from all sources, therefore you should **ensure that you read and understood our security notice about that**, available above.

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

Jeśli nie potrzebujesz dostępu ze wszystkich źródeł, ale na przykład tylko z sieci LAN, wtedy znacznie lepiej jest sprawdzić lokalny adres IP maszyny hostującej ASF, na przykład `192. 68.0.10` i użyj go zamiast `*` w przykładowej konfiguracji powyżej. Niestety jest to możliwe tylko wtedy, gdy Twój adres LAN jest zawsze taki sam, ponieważ w przeciwnym razie prawdopodobnie będziesz miał więcej zadowalających wyników z `*` i swoją własną zaporą na tej podstawie, pozwalając tylko lokalnym podsieciom na dostęp do portu ASF.

---

# Uwierzytelnianie

Domyślnie interfejs ASF IPC nie wymaga żadnego rodzaju uwierzytelnienia, ponieważ `IPCPassword` jest ustawiony na `null`. Jednakże, jeśli `IPCPassword` jest włączony, gdy jest ustawiony na dowolną wartość niepustą, każde wywołanie API ASF wymaga hasła pasującego do ustawionego `IPCPassword`. Jeśli pominiesz uwierzytelnianie lub wpiszesz nieprawidłowe hasło, otrzymasz błąd `401 - Nieautoryzowany`. Po 5 nieudanych próbach uwierzytelniania (złe hasło) zostaniesz tymczasowo zablokowany za pomocą błędu `403 - Zabroniony`.

Uwierzytelnianie można wykonać na dwa odrębne sposoby.

## Nagłówek `Uwierzytelnianie`

Generalnie powinieneś używać nagłówków żądań **[HTTP](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)**, przez ustawienie pola `Authentication` z hasłem jako wartością. Sposób wykonania tego zależy od rzeczywistego narzędzia, którego używasz do uzyskania dostępu do interfejsu IPC ASF, na przykład jeśli używasz `curl` , powinieneś dodać `-H 'Uwierzytelnienie: MyPassword'` jako parametr. W ten sposób uwierzytelnianie jest przekazywane w nagłówkach wniosku, gdzie faktycznie powinno się to odbywać.

## `password` parametr w ciągu zapytania

Alternatywnie możesz dodać parametr `hasło` na końcu adresu URL, do którego dzwonisz, na przykład dzwoniąc do `/Api/ASF? assword=MyPassword` zamiast `/Api/ASF` pojedynczo. Takie podejście jest wystarczająco dobre, ale oczywiście ujawnia się w otwartym hasła, które niekoniecznie zawsze jest właściwe. Dodatkowo jest to dodatkowy argument w ciągu zapytania, co komplikuje wygląd adresu URL i sprawia, że jest on specyficzny dla URL, podczas gdy hasło stosuje się do całej komunikacji ASF API.

---

Oba sposoby są obsługiwane i to od ciebie zależy, który chcesz wybrać. Zalecamy używanie nagłówków HTTP wszędzie tam, gdzie możesz, ponieważ użycie jest bardziej odpowiednie niż ciąg zapytań. Jednakże wspieramy również ciąg zapytań, głównie ze względu na różne ograniczenia związane z nagłówkami żądań. Dobrym przykładem jest brak nagłówków niestandardowych podczas uruchamiania połączenia websocket w javascript (nawet jeśli jest on całkowicie ważny zgodnie z RFC). W tej sytuacji ciąg zapytań jest jedynym sposobem na uwierzytelnienie.

---

# Dokumentacja wagonu

Nasz interfejs IPC w dodatku do ASF API i ASF-ui zawiera również dokumentację swagger, który jest dostępny pod adresem `/swagger` **[URL](http://localhost:1242/swagger)**. Dokumentacja Swagger służy jako średni człowiek między naszą implementacją API a innymi narzędziami używającymi jej (np. ASF-ui). Zapewnia pełną dokumentację i dostępność wszystkich punktów końcowych API w **[OpenAPI](https://swagger.io/resources/open-api)** specyfikacji, które mogą być łatwo wykorzystane przez inne projekty, pozwalając na łatwe zapisywanie i testowanie ASF API.

Poza wykorzystaniem naszej dokumentacji swagger jako kompletnej specyfikacji ASF API, możesz również użyć go jako przyjaznego dla użytkownika sposobu wykonywania różnych punktów końcowych API, głównie tych, które nie są zaimplementowane przez ASF-ui. Ponieważ nasza dokumentacja swagger jest generowana automatycznie z kodu ASF, masz gwarancję, że dokumentacja będzie zawsze aktualna z punktami końcowymi API, które zawiera twoja wersja ASF.

![Dokumentacja wagonu](https://github.com/user-attachments/assets/ce998e08-f5db-46b0-a9e8-e6b69abd94bb)


---

# FAQ

### Czy interfejs IPC ASF jest zabezpieczony i bezpieczny w użyciu?

ASF domyślnie nasłuchuje tylko na adresach `localhost` , co oznacza, że dostęp do IPC ASF z dowolnej innej maszyny, ale Twój własny **jest niemożliwy**. Jeśli nie zmodyfikujesz domyślnych punktów końcowych, atakujący potrzebowałby bezpośredniego dostępu do własnej maszyny, aby uzyskać dostęp do IPC ASF, dlatego jest tak bezpieczny, jak może być i nikt inny nie ma możliwości dostępu do niego, nawet z Twojego LAN.

Jeśli jednak zdecydujesz się zmienić domyślny `localhost` powiąż adresy z czymś innym, wtedy powinieneś ustawić właściwe reguły zapory **sam** aby zezwolić tylko autoryzowanym adresom IP na dostęp do interfejsu IPC ASF. Oprócz tego musisz skonfigurować `IPCPassword`, ponieważ ASF odmówi innym maszynom dostępu do ASF API bez jednego, co dodaje kolejną warstwę dodatkowego zabezpieczenia. W tym przypadku może również chcieć uruchomić interfejs IPC ASF za odwróconym proxy, co zostało wyjaśnione poniżej.

### Czy mogę uzyskać dostęp do ASF API za pomocą własnych narzędzi lub skryptów użytkownika?

Tak, do czego zaprojektowano ASF API i możesz użyć wszystkiego, co można wysłać zapytanie HTTP aby uzyskać do niego dostęp. Lokalne skrypty użytkowników śledzą logikę **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** , a my pozwalamy im na dostęp ze wszystkich źródeł (`*`), tak długo jak `IPCPassword` jest ustawiony jako dodatkowy środek bezpieczeństwa. Pozwala to na wykonywanie różnych uwierzytelnionych żądań ASF API, bez zezwalania na potencjalnie złośliwe skrypty na wykonywanie tego zadania automatycznie (ponieważ muszą znać twój `IPCPassword` , aby to zrobić).

### Czy mogę uzyskać zdalny dostęp do IPC ASF, np. z innej maszyny?

Tak, zalecamy użycie w tym celu odwrotnego proxy. W ten sposób możesz uzyskać dostęp do swojego serwera w typowy sposób, który następnie uzyska dostęp do IPC ASF na tym samym komputerze. Alternatywnie, jeśli nie chcesz uruchamiać z odwróconym proxy, możesz użyć **[niestandardowej konfiguracji](#enabling-access-from-all-ips)** z odpowiednim adresem URL. Na przykład, jeśli Twój komputer jest w sieci VPN z adresem `10.8.0.1` , możesz ustawić `http://10.8.0. :1242` nasłuchiwanie adresu URL w konfiguracji IPC, co umożliwiłoby dostęp IPC z Twojego prywatnego VPN, ale nie z nigdzie indziej.

### Czy mogę użyć ASF IPC za odwróconym proxy takim jak Apache lub Nginx?

**Tak**, nasz IPC jest w pełni kompatybilny z taką konfiguracją, więc możesz przechowywać go również przed własnymi narzędziami do zapewnienia dodatkowego bezpieczeństwa i kompatybilności, jeśli chcesz. Serwer HTTP Kestrel Kestrel jest na ogół bardzo bezpieczny i nie ma żadnego ryzyka podczas bezpośredniego połączenia z Internetem, ale umieszczenie go za odwróconym proxy takim jak Apache lub Nginx może zapewnić dodatkowe funkcje, których osiągnięcie nie byłoby możliwe w przeciwnym wypadku, np. zabezpieczenie interfejsu ASF za pomocą podstawowego **[autoryzacji](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Przykładowa konfiguracja Nginx znajduje się poniżej. Uwzględniliśmy cały blok `serwer` , chociaż jesteś zainteresowany głównie `lokalizacją`. Proszę zapoznać się z dokumentacją **[nginx](https://nginx.org/en/docs)** jeśli potrzebujesz dalszych wyjaśnień.

```nginx
serwer {
    nasłuchuje *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certific/path/to/your/fullchain. em;
    ssl_certificate_key /path/to/your/privkey. em;

    lokalizacja ~* /Api/NLog {
        proxy_pass http://127.0.0. :1242;

        # Tylko jeśli chcesz nadpisać domyślny host
# proxy_set_header Host 127. .0. ;

        # nagłówki X powinny być zawsze określane, gdy żądania proxy do ASF
        # Są kluczowe dla prawidłowej identyfikacji pierwotnego IP, zezwalanie ASF np. zbanuj rzeczywistych sprawców zamiast twojego serwera nginx
        # Określanie ich pozwala ASF na prawidłowe rozwiązywanie adresów IP użytkowników składających wnioski - sprawiając, że nginx działa jako odwrócony serwer proxy
        # Nieokreślanie ich sprawi, że ASF będzie traktować twój nginx jako klienta - nginx będzie działał jako tradycyjne proxy w tym przypadku
        # Jeśli nie możesz hostować usługi nginx na tym samym komputerze co ASF, najprawdopodobniej chcesz odpowiednio ustawić KnownNetworks oprócz tych
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;

        # Dodajemy te 3 dodatkowe opcje dla proxy'ów websocket, zobacz https://nginx. rg/pl/docs/http/websocket.html
        proxy_http_version 1. ;
        połączenie proxy_set_header "Upgrade";
        Ulepszenie proxy_set_header $http_upgrade;
    }

    lokalizacja / {
        proxy_pass http://127. .0. :1242;

        # Tylko jeśli chcesz nadpisać domyślny host
# proxy_set_header Host 127. .0. ;

        # nagłówki X powinny być zawsze określone, gdy żądania proxy do ASF
        # Są kluczowe dla prawidłowej identyfikacji pierwotnego IP, zezwalanie ASF np. zbanuj rzeczywistych sprawców zamiast twojego serwera nginx
        # Określanie ich pozwala ASF na prawidłowe rozwiązywanie adresów IP użytkowników składających wnioski - sprawiając, że nginx działa jako odwrócony serwer proxy
        # Nieokreślanie ich sprawi, że ASF będzie traktować twój nginx jako klienta - nginx będzie działał jako tradycyjne proxy w tym przypadku
        # Jeśli nie możesz hostować usługi nginx na tym samym komputerze co ASF, najprawdopodobniej chcesz ustawić KnownNetworks jako dodatek do tych
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-forwarded-Proto $scheme,
        proxy_set_header X-forwarded-Server $host;
    }
}
```

Przykładowa konfiguracja Apache znajduje się poniżej. Proszę zapoznać się z dokumentacją **[apache](https://httpd.apache.org/docs)** jeśli potrzebujesz dalszych wyjaśnień.

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerName asf.mydomain.com

        SSLEngine On
        SSLCertificateFile /path/to/your/fullchain.pem
        SSLCertificateKeyFile /path/to/your/privkey.pem

        # TODO: Apache can't do case-insensitive matching properly, so we hardcode two most commonly used cases
        ProxyPass "/api/nlog" "ws://127.0.0.1:1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0.1:1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### Czy mogę uzyskać dostęp do interfejsu IPC za pomocą protokołu HTTPPS?

**Tak**możesz to osiągnąć na dwa różne sposoby. Zalecanym sposobem byłoby użycie odwróconego serwera proxy, w którym możesz uzyskać dostęp do swojego serwera internetowego za pomocą HTTP jak zwykle, i podłącz się przez nią za pomocą interfejsu IPC ASF na tej samej maszynie. W ten sposób Twój ruch jest w pełni zaszyfrowany i nie musisz modyfikować IPC w żaden sposób, aby obsługiwać taką konfigurację.

Drugi sposób obejmuje określenie **[niestandardowej konfiguracji](#custom-configuration)** dla interfejsu IPC ASF, gdzie możesz włączyć punkt końcowy https i dostarczyć odpowiedni certyfikat bezpośrednio do naszego serwera http Kestrel. W ten sposób zaleca się, jeśli nie używasz żadnego innego serwera internetowego i nie chcesz go uruchamiać wyłącznie dla ASF. W przeciwnym razie znacznie łatwiej jest uzyskać zadowalającą konfigurację poprzez zastosowanie mechanizmu odwrotnego proxy.

---

### Podczas uruchamiania IPC otrzymuję błąd: `System.IO. Wyjątek: Nie udało się powiązać z adresem, podjęto próbę uzyskania dostępu do gniazda w sposób zabroniony przez jego uprawnienia dostępu`

Ten błąd wskazuje, że coś innego na twoim komputerze albo już używa tego portu, albo zarezerwował go do przyszłego użytku. Może to być Ty, jeśli próbujesz uruchomić drugą instancję ASF na tej samej maszynie, ale najczęściej to Windows wyłączający port `1242` z użytkowania, dlatego musisz przenieść ASF do innego portu. Aby to zrobić, wykonaj **[przykład config](#changing-default-port)** powyżej, i po prostu spróbuj wybrać inny port, taki jak `12420`.

Oczywiście możesz również spróbować dowiedzieć się, co blokuje port `1242` z użycia ASF i usunąć to, ale jest to zazwyczaj o wiele bardziej kłopotliwe niż polecenie ASF do korzystania z innego portu, więc pominniemy tutaj dalsze prace nad tym zagadnieniem.

---

### Dlaczego błąd `403 Zabroniony` podczas nieużywania `IPCPassword`?

ASF zawiera dodatkowy środek bezpieczeństwa, który domyślnie pozwala na tylko interfejs pętli zwrotnej (`localhost`, twój własny komputer), aby uzyskać dostęp do ASF API bez `IPCPassword` ustawiony w konfiguracji. This is because using `IPCPassword` should be a **minimum** security measure set by everybody who decides to expose ASF interface further.

Zmiana ta była podyktowana faktem, że ogromna liczba ASF utrzymywanych na całym świecie przez nieświadomych użytkowników została przejęta ze względu na złośliwe intencje, zwykle pozostawia ludzi bez kont i bez pozycji na nim. Teraz moglibyśmy powiedzieć, że „mogliby odczytać tę stronę przed otwarciem ASF dla całego świata”, a zamiast tego bardziej sensowne jest niezezwalanie na niepewne konfiguracje ASF, i wymagają od użytkowników działania, jeśli wyraźnie chcą na to zezwolić, o czym mówimy poniżej.

W szczególności możesz zastąpić naszą decyzję określając sieci, którym ufasz do ASF bez `IPCPassword` określone, możesz ustawić je w własności `KnownNetworks` w konfiguracji niestandardowej. However, unless you **really** know what you're doing and fully understand the risks, you should instead use `IPCPassword` as declaring `KnownNetworks` will allow everybody from those networks to access ASF API unconditionally. Jesteśmy poważni, ludzie już strzelali w piechotę, wierząc w swoje odwrotne pełnomocnictwo, a zasady zapamiętywania były bezpieczne, ale byli `IPCPassword` jest pierwszym, a czasami ostatnim strażnikiem, Jeśli zdecydujesz się zrezygnować z tego prostego, ale bardzo skutecznego i bezpiecznego mechanizmu, tylko sam może się obwinić.