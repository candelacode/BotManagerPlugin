# Управління

Цей розділ охоплює предмети, пов'язані з управлінням процесом ASF оптимальним способом. Досі, хоч вони й не обов'язкові для використання, є низка порад, хитрощів та добрих практик, якими ми хотіли б поділитись, особливо для адміністраторів системи, люди записують ASF для використання у репозиторіях сторонніх розробників, а також для просунутих користувачів так само.

---

## `systemd` служби для Linux

In `generic` and `linux` variants, ASF comes with `ArchiSteamFarm@.service` file, which is a configuration file of the service for **[`systemd`](https://systemd.io)**. Якщо ви бажаєте запустити ASF як сервіс, наприклад для того, щоб запустити його автоматично після запуску вашого комп'ютера, і відповідний сервіс `systemd` - це, мабуть, найкращий спосіб зробити це, Тому ми наполегливо рекомендуємо користуватися ним замість управління ним через `nohup`, `screen` або подібне.

По-перше, створіть обліковий запис для користувача, якого ви бажаєте запустити ASF, якщо він ще не існує. Наприклад ми використаємо користувача `asf` , якщо ви вирішили використати інший, вам потрібно замінити `asf` користувачем у всіх наших прикладах нижче вибраних. Наш сервіс не дозволяє вам запустити ASF як `root`бо він вважається **[поганою практикою](#never-run-asf-as-administrator)**.

```sh
Введіть # Або sudo -i, щоб потрапити до оболонки
user-m asf # Створити обліковий запис, який ви маєте намір запустити ASF під
```

Далі, розпакувати ASF до папки `/home/asf/ArchiSteamFarm` The folder structure is important for our service unit, it should be `ArchiSteamFarm` folder in your `$HOME`, so `/home/<user>`. If you did everything correctly, there will be `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service` file existing. Якщо ви використовуєте `linux` варіант і не розпакувати файл в Linux, але наприклад використаний передача файлів від Windows, тоді вам також потрібно зробити `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

We'll do all below actions as `root`, so get to its shell with `su` or `sudo -i`.

Firstly it's a good idea to ensure that our folder still belongs to our `asf` user, `chown -hR asf:asf /home/asf/ArchiSteamFarm` executed once will do it. Дозволи можуть бути неправильними, напр. якщо ви завантажили та/або розпакували zip-файл як `root`.

По-друге, якщо ви використовуєте універсальний варіант ASF, переконайтеся, що команда `dotnet` розпізнана і всередині однієї із стандартних розташувань: `/usr/local/bin` `/usr/bin` або `/bin`. This is required for our systemd service which executes `dotnet /path/to/ArchiSteamFarm.dll` command. Check if `dotnet --info` works for you, if yes, type `command -v dotnet` to find out where it's located. Якщо ви використали офіційний інсталятор, він повинен бути в `/usr/bin/dotnet` або в одній з двох інших розташуваннях, як слід стверджувати. If it's in custom location such as `/usr/share/dotnet/dotnet`, create a **[symlink](https://wikipedia.org/wiki/Symbolic_link)** for it using `ln -s "$(command -v dotnet)" /usr/bin/dotnet`. Тепер, `command -v dotnet` слід повідомити про `/usr/bin/dotnet`, що також зробить нашу системну роботу. Якщо ви використовуєте варіант для конкретної ОС, то вам нічого не потрібно робити в цьому плані.

Далі, виконати `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/systemd/system/ArchiSteamFarm\@. ervice`, це створить символічне посилання на нашу послугову декларацію та зареєструє її в `systemd`. Символічне посилання дозволить ASF оновити `systemd` автоматично як частина оновлення ASF - в залежності від вашої ситуації, ви можете використовувати цей підхід, або просто `cp` файл і керувати ним самостійно, як вам заманеться.

Після цього переконайтеся, що `системний` розпізнає нашу послугу:

```
systemctl status ArchiSteamFarm@asf

○ ArchiSteamFarm@asf.service - ArchiSteamFarm Service (on asf)
     Loaded: loaded (/etc/systemd/system/ArchiSteamFarm@.service; disabled; vendor preset: enabled)
     Active: inactive (dead)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Pay special attention to the user we declare after `@`, it's `asf` in our case. Our systemd service unit expects from you to declare the user, as it influences the exact place of the binary `/home/<user>/ArchiSteamFarm`, as well as the actual user systemd will spawn the process as.

Якщо система повернула вивід так само, як і вище, все в порядку, і ми майже закінчили. Тепер все, що залишилося, насправді починається з нашої послуги за обраним користувачем: `systemctl start ArchiSteamFarm@asf`. Зачекайте секунду або два, і можете знову перевірити статус:

```
ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm@asf.service - ArchiSteamFarm (на asf)
     Завантажено: завантажено (/etc/system/system/ArchiSteamFarm@.service; вимкнено, підсилюється: увімкнено
     Активний (running) з ...)
       Документа: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   Головний PID: (...)
(...)
```

If `systemd` states `active (running)`, it means everything went well, and you can verify that ASF process should be up and running, for example with `journalctl -r`, as ASF by default also writes to its console output, which is recorded by `systemd`. Якщо ви задоволені налаштуваннями зараз, ви можете сказати `systemd` щоб автоматично запустити сервіс під час завантаження, виконання `systemctl вмикає ArchiSteamFarm@asf`. На цьому все.

Якщо ви захочете зупинити процес, просто виконайте `systemctl зупинити ArchiSteamFarm@asf`. Аналогічно, якщо ви бажаєте вимкнути роботу ASF автоматично при завантаженні, `systemctl вимкнути ArchiSteamFarm@asf` зробить це для вас простим.

Будь ласка, зверніть увагу, що немає ввімкненого стандартного вводу для нашого `systemd` сервісу format@@1. ви не зможете вводити свої дані в консоль звичайним способом. Running through `systemd` is equivalent to specifying **[`Headless: true`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** setting and comes with all its implications. На щастя для вас, дуже легко керувати ASF через **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**які ми рекомендуємо у випадку, якщо під час входу потрібно вказати додаткові дані або іншим чином керувати процесом ASF.

### Змінні середовища

It's possible to supply additional environment variables to our `systemd` service, which you'll be interested in doing in case you want to for example use a custom `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**, therefore specifying `ASF_CRYPTKEY` environment variable.

Для того, щоб вказати власні змінні середовища, створіть теку `/etc/asf` (у разі, якщо її не існує), `mkdir -p /etc/asf`. We recommend to `chown -hR root:root /etc/asf && chmod 700 /etc/asf` to ensure that only `root` user has access to read those files, because they might contain sensitive properties such as `ASF_CRYPTKEY`. Afterwards, write to a `/etc/asf/<user>` file, where `<user>` is the user you're running the service under (`asf` in our example above, so `/etc/asf/asf`).

Файл повинен містити всі змінні середовища, які ви хотіли б надати процесу. Ті, хто не має спеціальної змінної середовища, можуть бути оголошені в `ASF_ARGS`:

```sh
# Declare only those that you actually need
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# And any other ones you're interested in
```

### Перерахунок службової одиниці

Thanks to the flexibility of `systemd`, it's possible to overwrite part of ASF unit while still preserving the original unit file and allowing ASF to update it for example as part of auto-updates.

У цьому прикладі ми б хотіли змінити типову поведінку об'єкту ASF `systemd` після перезапуску тільки у успішному запуску, для відновлення роботи з фатальними помилками. In order to do so, we'll override `Restart` property under `[Service]` from default of `on-success` to `always`. Просто виконайте `systemctl редагуйте ArchiSteamFarm@asf`, природно замінивши `asf` цільовим користувачем вашого сервісу. Then add your changes as indicated by `systemd` in proper section:

```sh
### Editing /etc/systemd/system/ArchiSteamFarm@asf.service.d/override.conf
### Anything between here and the comment below will become the new contents of the file

[Service]
Restart=always

### Lines below this comment will be discarded

### /etc/systemd/system/ArchiSteamFarm@asf.service
# [Install]
# WantedBy=multi-user.target
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm.dll --no-restart --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# User=%i
# (...)
```

And that's it, now your unit acts the same as if it had only `Restart=always` under `[Service]`.

Звичайно, альтернатива `cp` файл і впорядкувати його самостійно, але це дозволяє гнучкі зміни, навіть якщо ви вирішили залишити оригінальний підрозділ ASF, наприклад з **[символічним](https://wikipedia.org/wiki/Symbolic_link)**.

---

## Ніколи не запускати ASF як адміністратора!

ASF має свою перевірку, чи запускається процес з правами адміністратора (`root`), або ні. Running as `root` is **not** required for any kind of operation done by the ASF process, assuming properly configured environment it's operating in, and therefore should be regarded as a **bad practice**. This means that on Windows, ASF should **never** be executed with "run as administrator" setting, and on Unix ASF should have a **dedicated user account** for itself, or re-use your own in case of a desktop system.

For further elaboration on *why* we discourage running ASF as `root`, refer to **[superuser](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** and other resources. Якщо ви все ще не переконані, запитайте себе, що станеться з Вашою машиною, якщо процес ASF буде виконаний `rm -rf /*` відразу після запуску.

### I run as `root` because ASF can't write to its files

Це означає, що ви неправильно налаштовані дозволи для файлів ASF, намагається отримати доступ. You should login as `root` account (either with `su` or `sudo -i`) and then **correct** the permissions by issuing `chown -hR asf:asf /path/to/ASF` command, substituting `asf:asf` with the user that you'll run ASF under, and `/path/to/ASF` accordingly. If by any chance you're using custom `--path` telling ASF user to use the different directory, you should execute the same command again for that path as well.

Після цього вам більше не потрібно давати жодних проблем, пов'язаних із ASF, у змозі записати свої власні файли, коли ви щойно змінили власника всього, що цікавиться користувачем, у якому буде виконаний процес ASF.

### I run as `root` because I don't know how to do it otherwise

```sh
Су # Або судо -і, щоб потрапити до оболонки
користувач додає -m asf # Створити обліковий запис, який ви маєте намір запустити ASF під запитом
- власник ASF важить -hR asf:asf /path/to/ASF # Переконайся, що ваш новий користувач має доступ до теки ASF
А А це налаштування -c /path/to/ASF/ArchiSteamFarm # Або su-u asf /path/to/ASF/ArchiSteamFarm, фактично запустити програму під вашим користувачем
```

That would be doing it manually, it's much easier to use our **[`systemd` service](#systemd-service-for-linux)** explained above.

### I know better and I still want to run as `root`

ASF примусово не зупинить вас зробити це, лише познайомтеся з коротким попередженням. Просто не будьте шоковані якщо одного дня через помилку у програмі він підірве всю ОС з повною втратою даних - вас попередили.

---

## Кілька екземплярів

ASF сумісний з кількома екземплярами процесу на одному комп'ютері. The instances can be completely standalone or derived from the same binary location (in which case, you want to run them with different `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**).

При запуску кількох випадків з одного і того ж двійкового файлів, майте на увазі, що зазвичай слід вимкнути автоматичне оновлення в усіх їх конфігураціях, оскільки немає синхронізації між ними для автоматичного оновлення. Якщо ви хочете увімкнути автоматичне оновлення, ми рекомендуємо автономні екземпляри, але ви можете зробити оновлення працюючими, якщо ви зможете забезпечити закриті всі інші екземпляри ASF.

ASF буде робити все можливе, щоб зберегти мінімальну кількість OS-вседоступних, крос-процесорних комунікацій з іншими екземплярами ASF. This includes ASF checking its configuration directory against other instances, as well as sharing core process-wide limiters configured with `*LimiterDelay` **[global config properties](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, ensuring that running multiple ASF instances will not cause a possibility to run into a rate-limiting issue. Звертаючись до технічних аспектів, усі платформи використовують наш спеціальний механізм персоналізації файлів ASF, створених в тимчасовому каталозі, це `C:\Users\<YourUser>\AppData\Local\Temp\ASF` на Windows, а `/tmp/ASF` для Unix.

It's not required for running ASF instances to share the same `*LimiterDelay` properties, they can use different values, as each ASF will add its own configured delay to the release time after acquiring the lock. If the configured `*LimiterDelay` is set to `0`, ASF instance will entirely skip waiting for the lock of given resource that is shared with other instances (that could potentially still maintain a shared lock with each other). Коли потрібне будь-яке інше значення, ASF буде коректно синхронізувати з іншими екземплярами ASF і чекати своєї черги, потім випустити блокування після налаштованої затримки, дозволяючи іншим екземплярам продовжити.

ASF запам'ятовує налаштування `WebProxy` під час вирішення спільної області, це означає, що два екземпляри ASF з використанням різних конфігурацій `WebProxy` не будуть ділитися своїми обмеженнями між собою. Це реалізовано для того, щоб дозволити встановити `WebProxy` без надмірних затримок, як це очікувалося з різних мережевих інтерфейсів. This should be good enough for majority of use cases, however, if you have a specific custom setup in which you're e.g. routing requests yourself in a different way, you can specify network group yourself through `--network-group` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**, which will allow you to declare ASF group that will be synchronized with this instance. Майте на увазі, що власні мережеві групи використовуються виключно так, що це означає, що ASF більше не буде використовувати `WebProxy` для визначення правої групи, як ви і в цьому випадку заряджаєтесь.

If you'd like to utilize our **[`systemd` service](#systemd-service-for-linux)** explained above for multiple ASF instances, it's very simple, just use another user for our `ArchiSteamFarm@` service declaration and follow with the rest of the steps. Це буде еквівалентно запуску декількох екземплярів ASF з різними двійковими можливостями, а також вони можуть автооновлювати та самостійно працювати між собою.