# IPC

ASF має свій унікальний IPC інтерфейс для подальшої взаємодії з процесом. IPC розшифровується для відеозв'язку **[](https://en.wikipedia.org/wiki/Inter-process_communication)** і в найпростішому визначенні це "веб-інтерфейс" ASF, на основі **[Kestrel HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel)** , який може бути використаний для подальшої інтеграції з процесом, обоє як фронтенд для кінцевого користувача (ASF-ui) та серверний інтерфейс для третьої інтеграції (ASF API).

IPC можна використовувати для багатьох різних речей, залежно від ваших потреб і навичок. For example, you can use it for fetching status of ASF and all bots, sending ASF commands, fetching and editing global/bot configs, adding new bots, deleting existing bots, submitting keys for **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** or accessing ASF's log file. Всі ці дії викриті нашим API, це означає, що ви можете програмувати власні інструменти та сценарії, які зможуть спілкуватися з ASF та впливати на нього протягом роботи. На додаток до цього, вибрані дії (такі як надсилання команд) також реалізовані нашим ASF-ui що дозволяє легко отримати доступ до них через дружній веб-інтерфейс.

---

# Використання

Якщо ви не відключили IPC через `IPC` **[глобальної властивості](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, він включений за замовчуванням. ASF запустить IPC його журнал який ви можете використати для перевірки, якщо інтерфейс IPC запустився належним чином:

```text
ASF|ASF|Запуск IPC сервера...
Сервер Start() готовий!
```

Сервер httf тепер слухає вибрані кінцеві точки. If you didn't provide a custom configuration file for IPC, it'll be `localhost`, both IPv4-based **[127.0.0.1](http://127.0.0.1:1242)** and IPv6-based **[[::1]](http://[::1]:1242)** on default `1242` port. Ви можете отримати доступ до нашого інтерфейсу IPC через посилання вище, але тільки з тієї ж машини, що і один процес ASF.

Інтерфейс IPC з ASF відкриває три різні способи доступу до нього, залежно від запланованого використання.

На найнижчому рівні є **[API](#asf-api)** який є основою нашого інтерфейсу IPC і дає змогу працювати всім іншим. Це те, що ви хочете використовувати у ваших власних інструментах, корисних копалинах і проектах, щоб спілкуватися безпосередньо з ASF.

У середньому світі існує наша **[Модель Swagger документації](#swagger-documentation)** , яка виступає як фронтенд до API ASF. Ця функція є повною документацією ASF API і також дозволяє вам швидше звернутися до неї. Це те, що ви хочете перевірити, якщо ви плануєте написати інструмент, корисність чи інші проекти, які мають спілкуватися з ASF через свій API.

На найвищому рівні це **[ASF-ui](#asf-ui)** який базується на нашому ASF API та надає зручний спосіб виконувати різні дії ASF. Це наш інтерфейс IPC за замовчуванням, призначений для кінцевих користувачів, і ідеальний приклад того, що ви можете створювати з ASF API. If you'd like, you can use your own custom web UI to use with ASF, by specifying `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** and using custom `www` directory located there.

---

# ASF-ui

ASF-ui - це общинний проект що спрямований на створення зручного графічного веб-інтерфейсу для кінцевих користувачів. Для того щоб цього досягти, він поводиться як зовнішній інтерфейс для нашої **[API](#asf-api)**дозволяє легко робити різні дії. Це типовий інтерфейс, з яким поставляється ASF.

Як було зазначено вище, ASF-ui - це проект спільноти, який не підтримується основними розробниками ASF. It follows its own flow in **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** which should be used for all related questions, issues, bug reports and suggestions.

Ви можете використовувати ASF-ui для загального керування процесом ASF. Це дозволяє просто керувати ботами, змінювати налаштування, командами надсилання та досягти вибраної іншої функціональності зазвичай доступні за допомогою ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

Наш API ASF типовий **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** веб-API, який базується на JSON як його первинному форматі даних. Ми намагаємося точно описати відповідь, використовуючи обидва коди статусу HTTP (де це доречно), так само як і відповідь ви можете обробити себе для того, щоб знати, чи успішний запит, а якщо ні, то чому.

Наш ASF API може бути доступний, надіславши відповідні запити до відповідного `/Api` терміналу. Ви можете використовувати ці кінцеві точки API, щоб створити власні скрипти хелперів, інструменти, GUI і таке інше. Це саме те, чого досягає наш ASF-ui за капоною, і кожен інший інструмент може досягти те саме. API ASF офіційно підтримується та підтримується основною командою ASF.

Для повної документації доступних кінцевих точок, описів, запитів, відповідей та кодів статусу http і всього іншого, що розглядають API ASF, будь ласка, зверніться до нашої **[swagger документації](#swagger-documentation)**.

![ASF API](https://github.com/user-attachments/assets/08c3d4ad-ea77-403d-a18a-b75c3d0a3097)


---

# Користувацька конфігурація

Наш інтерфейс IPC підтримує додатковий файл конфігурації `IPC.config` , який слід розмістити у стандартній теці налаштувань `ASF`.

Коли він доступний, цей файл визначає розширену конфігурацію http сервера ASF, разом із іншими налаштуваннями, пов'язаними з IPC. Якщо у вас немає конкретної потреби, вам нема причин використовувати цей файл, для ASF вже використовує розсудливі значення за замовчуванням.

Файл конфігурації базується на наступній структурі JSON:

```json
{
    "Kestrel": {
        "Endpoints": {
            "example-http4": {
                "Url": "http://127.0.0.1:1242"
            },
            "example-http6": {
                "Url": "http://[::1]:1242"
            },
            "example-https4": {
                "Url": "https://127.0.0.1:1242",
                "Certificate": {
                    "Path": "/path/to/certificate.pfx",
                    "Password": "passwordToPfxFileAbove"
                }
            },
            "example-https6": {
                "Url": "https://[::1]:1242",
                "Certificate": {
                    "Path": "/path/to/certificate.pfx",
                    "Password": "passwordToPfxFileAbove"
                }
            }
        },
        "KnownNetworks": [
            "10.0.0.0/8",
            "172.16.0.0/12",
            "192.168.0.0/16"
        ],
        "PathBase": "/"
    }
}
```

`Кінцеві точки` - це набір кінцевих точок, в кожній окремій кінці його унікальне ім'я (наприклад `example-http4`) та `Url` властивість яка визначає `Protocol://Host:Port` прослуховуючу адресу. За замовчуванням, ASF слухає на IPv4 та IPv6 https адреси, але ми додали для вас приклади https для використання, якщо це необхідно. Ви повинні оголосити про себе тільки ті кінцеві точки, які вам потрібні, ми включили 4 приклади вище, щоб можна було відредагувати їх простіше.

`Host` accepts either `localhost`, a fixed IP address of the interface it should listen on (IPv4/IPv6), or `*` value that binds ASF's http server to all available interfaces. Використання інших значень, як `mydomain.com` або `192.168.0.` так само як `*`, немає реалізації IP, Тому будьте вкрай обережні при використанні значень `Host` , які дозволяють віддалений доступ. Це дозволить отримати доступ до IPC інтерфейсу ASF з інших машин, що може становити ризик безпеки. We strongly recommend to use `IPCPassword` (and preferably your own firewall too) **at a minimum** in this case.

`KnownNetworks` - Це **не обов'язкова** змінна визначає мережеві адреси, які ми вважаємо гідними довіри. За замовчуванням ASF налаштований на контурний інтерфейс (`localhost`, та ж машина) **тільки**. Ця властивість використовується двома способами. По-перше, якщо ви опускаєте `IPCPassword`тоді ми дозволимо тільки машинам з відомих мереж отримати доступ до API ASF, і заперечувати всіх інших як міру безпеки. По-друге, ця властивість має вирішальне значення для зворотних зв'язків з ASF, так як ASF буде шанувати свої заголовки тільки якщо зворотний проксі-сервер знаходиться в межах відомих мереж. Формування заголовків є вирішальним у відношенні до антижорстокого механізму сили ASF, як замість того, щоб заборонити зворотний проксі у випадку проблеми, вона забороняє IP адресу, вказану зворотним проксі-сервером в якості джерела оригінального повідомлення. Будь обережними з мережами, які ви вкажете тут, оскільки це дозволяє потенційну атаку розвороту IP та несанкціонований доступ, якщо довіра машина буде порушена або неправильно налаштована.

`PathBase` - This is **optional** base path that will be used by IPC interface. За замовчуванням `/` і не повинні бути потрібні для зміни більшості випадків використання. Змінюючи цю властивість, ви плануєте проводити весь інтерфейс IPC у довільному префіксі, наприклад `http://localhost:1242/MyPrefix` замість `http://localhost:1242`. Використання користувацького `PathBase` може захотіти у поєднанні з певними налаштуваннями зворотного проксі-сервера, в якому ви хочете вказати лише конкретний URL. наприклад `мідоум. om/ASF` замість усього `mydomain.com`. Normally that would require from you to write a rewrite rule for your web server that would map `mydomain.com/ASF/Api/X` -> `localhost:1242/Api/X`, but instead you can define a custom `PathBase` of `/ASF` and achieve easier setup of `mydomain.com/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

Якщо вам не потрібно буде вказати власний основний шлях, то найкраще залишити його за замовчуванням.

## Приклад конфігурацій

### Зміна порту за замовчуванням

The following config simply changes default ASF listening port from `1242` to `1337`. You can pick any port you like, but we recommend `1024-32767` range, as other ports are typically **[registered](https://en.wikipedia.org/wiki/Registered_port)**, and may for example require `root` access on Linux.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP4": {
                "Url": "http://127.0.0.1:1337"
            },
            "HTTP6": {
                "Url": "http://[::1]:1337"
            }
        }
    }
}
```

---

### Заборона доступу з усіх IP адрес

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

If you do not require access from all sources, but for example your LAN only, then it's much better idea to check local IP address of the machine hosting ASF, for example `192.168.0.10` and use it instead of `*` in example config above. Sadly that's only possible if your LAN address is always the same, as otherwise you'll probably have more satisfying results with `*` and your own firewall on top of that allowing only local subnets to access ASF's port.

---

# Автентифікація

ASF IPC interface by default does not require any sort of authentication, as `IPCPassword` is set to `null`. Однак, якщо `IPCPassword` увімкнено за допомогою якого встановлено будь-яке непусте значення. для кожного дзвінка в ASF API потребує пароль, який відповідає встановленому `IPCPassword`. Якщо ви пропустити автентифікацію або ввести неправильний пароль, ви отримаєте `401 - Несанкціонована` помилка. After 5 failed authentication attempts (wrong password), you'll get temporarily blocked with `403 - Forbidden` error.

Аутентифікація може бути виконана двома окремими способами.

## `Автентифікація` в заголовку

Загалом, ви повинні використовувати **[HTTP-заголовки запитів](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)**, встановивши поле `Авторизація` з своїм паролем як значення. Спосіб виконання це залежить від фактичного інструменту, який ви використовуєте, для доступу до інтерфейсу IPC ASF, наприклад, якщо ви використовуєте `curl` то ви повинні додати `-H 'Authentication: MyPassword'` як параметр. Таким чином аутентифікація передається в заголовках запиту, де вона дійсно повинна відбуватися.

## `password` parameter in query string

Alternatively you can append `password` parameter to the end of the URL you're about to call, for example by calling `/Api/ASF?password=MyPassword` instead of `/Api/ASF` alone. Цей підхід досить хороший, але очевидно, він викриває пароль у відкритому доступі, що не завжди є доречним. На додачу, що це додатковий аргумент у рядку запиту, цей вигляд ускладнює зовнішній вигляд URL і змушує його відчути, що він є специфічним для URL, а пароль застосовується до усього зв'язку ASF API.

---

Обидва способи підтримуються, і вони повністю залежить від вас, який саме ви хочете вибрати. Рекомендуємо використовувати HTTP заголовки повсюди, в яких ви можете, як це використовується, а не рядок запиту. Проте, ми також підтримуємо рядок запиту, в основному через різні обмеження, пов'язані з запитом заголовків. Хороший приклад включає в себе відсутність користувацьких заголовків під час ініціювання з'єднання з веб-сокетом в javascript (навіть якщо він повністю дійсний відповідно до RFC). У цій ситуації рядок запиту є єдиним способом авторизації.

---

# Документація Swagger

Our IPC interface, in additon to ASF API and ASF-ui also includes swagger documentation, which is available under `/swagger` **[URL](http://localhost:1242/swagger)**. Документація Swagger служить посередником між нашим API реалізацією та іншими інструментами використання (наприклад, ASF-ui). It provides a complete documentation and availability of all API endpoints in **[OpenAPI](https://swagger.io/resources/open-api)** specification that can be easily consumed by other projects, allowing you to write and test ASF API with ease.

Окрім використання нашої пошукової документації як повної специфікації API ASF, ви також можете використовувати його як зручний спосіб виконувати різні кінцеві точки API, головним чином ті, що не реалізовані ASF-ui. Оскільки наша система болотної документації автоматично генерується з коду ASF, ви гарантуєте, що документація завжди буде актуальна за допомогою кінцевих точок API, до яких включно з ASF.

![Документація Swagger](https://github.com/user-attachments/assets/ce998e08-f5db-46b0-a9e8-e6b69abd94bb)


---

# ЧаПи

### Чи безпечний і безпечний інтерфейс IPC інтерфейсу ASF у безпеці?

ASF за замовчуванням запускає лише на `localhost` адресах, це означає, що доступ до ASF IPC з будь-якого іншого комп'ютера, але ваше власне **є неможливим**. Якщо ви не змінюєте кінцеві точки, атакуючий потрібен прямий доступ до вашої власної машини для доступу до ASF IPC, Отже, воно таке ж безпечне, як воно може бути, і немає можливості для будь-кого отримати доступ до нього, навіть з вашої власної локалі.

Однак, якщо ви вирішили змінити типовий `localhost` адреси прив'язки до чогось іншого, тоді ви повинні встановити вірні правила брандмауера **собі** для того, щоб дозволити тільки авторизовані IP-адреси отримати доступ до інтерфейсу ASF IPC. На додаток до цього, вам необхідно встановити `IPCPassword`, бо ASF відмовиться дати іншим машинам доступ до ASF API без одного, що додає ще один рівень додаткового безпеки. Ви також можете захотіти запустити інтерфейс ASF за зворотним проксі-сервером, у цьому випадку, який надалі пояснюється нижче.

### Чи можу я отримати доступ до API через мої власні інструменти або скрипти користувача?

Так, саме для цього був розроблений ASF API, і ви можете користуватися будь-чим, що може надіслати HTTP-запит для доступу до нього. Local userscripts follow **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** logic, and we allow access from all origins for them (`*`), as long as `IPCPassword` is set, as an extra security measure. Це дозволяє вам виконувати різні запити автентифіковані ASF API, не дозволяючи потенційно шкідливим сценаріям зробити це автоматично (як це потрібно було б знати у вашій `IPCPassword` для цього).

### Чи можна дистанційно отримувати доступ до IPC з іншого комп'ютера ASF?

Так, ми рекомендуємо використовувати зворотний проксі-сервер для цього. Таким чином, ви можете отримати доступ до веб-сервера типовим чином, який потім буде отримувати доступ до IPC ASF на тому ж самому комп'ютері. Alternatively, if you don't want to run with a reverse proxy, you can use **[custom configuration](#enabling-access-from-all-ips)** with appropriate URL for that. Наприклад, якщо ваш пристрій працює в VPN за допомогою адреси `10.8.0.1` , тоді ви можете встановити `http://10.8.0. :1242` прослуховування URL в файлі IPC, що дозволило б IPC отримати доступ від вашого особистого VPN, але не з ніде іншого.

### Чи можна використовувати IPC ASF за зворотним проксі-сервером, таким як Apache or Nginx?

**Yes**, our IPC is fully compatible with such setup, so you're free to host it also in front of your own tools for extra security and compatibility, if you'd like to. In general ASF's Kestrel http server is very secure and possesses no risk when being connected directly to the internet, but putting it behind a reverse-proxy such as Apache or Nginx could provide extra functionality that wouldn't be possible to achieve otherwise, such as securing ASF's interface with a **[basic auth](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Приклад конфігурації Nginx можна знайти нижче. We've included full `server` block, although you're interested mainly in `location` ones. Please refer to **[nginx documentation](https://nginx.org/en/docs)** if you need further explanation.

```nginx
server {
    listen *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /path/to/your/fullchain.pem;
    ssl_certificate_key /path/to/your/privkey.pem;

    location ~* /Api/NLog {
        proxy_pass http://127.0.0.1:1242;

        # Only if you need to override default host
#       proxy_set_header Host 127.0.0.1;

        # X-headers should always be specified when proxying requests to ASF
        # They're crucial for proper identification of original IP, allowing ASF to e.g. ban the actual offenders instead of your nginx server
        # Specifying them allows ASF to properly resolve IP addresses of users making requests - making nginx work as a reverse proxy
        # Not specifying them will cause ASF to treat your nginx as the client - nginx will act as a traditional proxy in this case
        # If you're unable to host nginx service on the same machine as ASF, you most likely want to set KnownNetworks appropriately in addition to those
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;

        # We add those 3 extra options for websockets proxying, see https://nginx.org/en/docs/http/websocket.html
        proxy_http_version 1.1;
        proxy_set_header Connection "Upgrade";
        proxy_set_header Upgrade $http_upgrade;
    }

    location / {
        proxy_pass http://127.0.0.1:1242;

        # Only if you need to override default host
#       proxy_set_header Host 127.0.0.1;

        # X-headers should always be specified when proxying requests to ASF
        # They're crucial for proper identification of original IP, allowing ASF to e.g. ban the actual offenders instead of your nginx server
        # Specifying them allows ASF to properly resolve IP addresses of users making requests - making nginx work as a reverse proxy
        # Not specifying them will cause ASF to treat your nginx as the client - nginx will act as a traditional proxy in this case
        # If you're unable to host nginx service on the same machine as ASF, you most likely want to set KnownNetworks appropriately in addition to those
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
    }
}
```

Нижче ви можете знайти приклад конфігурації Apache. Будь ласка, перегляньте **[apache documentation](https://httpd.apache.org/docs)** якщо вам потрібне подальше пояснення.

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

### Чи можу я отримати доступ до інтерфейсу IPC через протокол HTTPS?

**Yes**, you can achieve it through two different ways. Рекомендований спосіб використання зворотнього проксі-сервера для цього, де ви можете отримати доступ до Вашого веб-сервера за допомогою https, як і завжди, та з'єднайте їх з інтерфейсом IPC вашого ASF на тій самій машині. Таким чином, ваш трафік повністю зашифрований і вам не потрібно ніяким чином змінювати IPC для підтримки таких налаштувань.

Second way includes specifying a **[custom config](#custom-configuration)** for ASF's IPC interface where you can enable https endpoint and provide appropriate certificate directly to our Kestrel http server. Цей спосіб рекомендується, якщо ви не використовуєте будь-який інший веб-сервер і не хочете запускати один виключно для ASF. В іншому випадку набагато простіше досягти задовільної установки, використовуючи зворотний проксі-механізм.

---

### During startup of IPC I'm getting an error: `System.IO.IOException: Failed to bind to address, An attempt was made to access a socket in a way forbidden by its access permissions`

Це означає, що щось інше на вашому комп"ютері або вже використовує цей порт, або зарезервовано для майбутнього використання. Це може бути ви, якщо ви намагаєтеся запустити другий екземпляр ASF на тій же машині, але найчастіше це Windows виключає порт `1242` з вашого використання, тому вам доведеться перемістити ASF до іншого порту. Для цього виконайте приклад **[наприклад config](#changing-default-port)** вище, і просто спробуйте вибрати інший порт, наприклад `12420`.

Of course you could also try to find out what is blocking port `1242` from ASF usage, and remove that, but that's usually far more troublesome than simply instructing ASF to use another port, so we'll skip elaborating further on that here.

---

### Чому я отримую `403 Заборонена` помилка при не використанні `IPCPassword`?

ASF має додатковий захід безпеки, який за замовчуванням, дозволяє використовувати лише багаторазовий інтерфейс (`localhost`, ваш власний машин) для доступу до API ASF без `IPCPassword` встановив у файлі config. This is because using `IPCPassword` should be a **minimum** security measure set by everybody who decides to expose ASF interface further.

Зміни були продиктовані тим, що велика кількість ASF приймала в усьому світі необізнаних користувачів сприймалася з шкідливих намірів, зазвичай покидаючи людей без облікових записів і без елементів по них. Зараз ми можемо сказати, що "вони могли б прочитати цю сторінку, перш ніж відкрити ASF для всього світу", але замість цього має більш сенс забороняти незахищені налаштування ASF за замовчуванням, і вимагають від користувачів дій, якщо вони хочуть явно дозволити, які ми розкриваємо нижче.

In particular, you're able to override our decision by specifying the networks which you trust to reach ASF without `IPCPassword` specified, you can set those in `KnownNetworks` property in custom config. However, unless you **really** know what you're doing and fully understand the risks, you should instead use `IPCPassword` as declaring `KnownNetworks` will allow everybody from those networks to access ASF API unconditionally. Ми серйозні, люди вже стріляли самі в ногу, вірячи свої зворотні прокльоси і правила iptables були безпечними, але вони були, `IPCPassword` є першим та іноді останнім опікуном, якщо ви вирішите відмовитися від цього простого, проте дуже ефективного і безпечного механізму, ви будете винні лише в собі.