# Docker

ASF is available as **[docker container](https://www.docker.com/what-container)**. Our docker packages are currently available on **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** as well as **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

It's important to note that running ASF in Docker container is considered **advanced setup**, which is **not needed** for vast majority of users, and typically gives **no advantages** over container-less setup. If you're considering Docker as a solution for running ASF as a service, for example making it start automatically with your OS, then you should consider reading **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** section instead and set up a proper `systemd` service which will be **almost always** a better idea than running ASF in a Docker container.

Running ASF in Docker container usually involves **several new problems and issues** that you'll have to face and resolve yourself. This is why we **strongly** recommend you to avoid it unless you already have Docker knowledge and don't need help understanding its internals, about which we won't elaborate here on ASF wiki. Цей розділ здебільшого для дійсних випадків дуже складних конструкцій, Наприклад, щодо розширеного мережевого або безпеки поза стандартним пісочником, який ASF поставляється у службі `systemd` (яка вже забезпечує вищу ізоляцію процесу через дуже просунуті механізми безпеки). Для такої кількості людей ми пояснюємо вам кращі поняття ASF цілком відповідно до Docker, і тільки те, що ви вважаєте, що у вас є адекватні знання Docker, якщо ви вирішите використовувати його разом з ASF.

---

## Мітки

ASF доступно через декілька типів **[тегів](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `основний`

Generic build of ASF that is built from the very latest commit in `main` branch, which works the same as grabbing latest artifact directly from our **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pipeline. Це найвищий рівень помилкового програмного забезпечення, присвяченого розробникам і досвідченим користувачам для цілей розробки. The image is being updated with each commit in the `main` GitHub branch, therefore you can expect very often changes (and stuff being broken). Помітити поточний стан проекту ASF, які не обов'язково гарантуються стабільним або тестовим, так само, як зазначають у нашому циклі випуску. **Цей тег не повинен використовуватися у жодному виробничому середовищі**. Корисно для перевірки, чи конкретний коміт виправив вашу проблему, не чекаючи навіть попереднього випуску з цим комітом.


### `відпущено`

Звичайна збірка ASF яка завжди вказує на останню версію **[випускає](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** версію ASF, включаючи попередні релізи. Compared to `main` tag, image here is being updated each time a new GitHub tag is pushed. Присвячується просуванням / силовим користувачам, які люблять жити на краю того, що можна одночасно вважати стабільним та свіжим. На практиці це працює так само, як рухомий тег, який вказує на останній випуск `<unk> .C.D` під час потягування. Please note that using this tag is equal to using our **[pre-releases](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `стабільна`

Generic build of ASF that always points to the latest **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF version. Compared to `released` tag, image here is being updated once new stable version of ASF is made available. Рекомендується для людей, які шукають стабільний варіант `випущений` тег, згаданий вище.

### `останній`

OS-specific build of ASF that always points to the latest **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF version. In comparison with others, this is the **only tag** that includes ASF auto-updates. Мета цього тегу - надати добре типовий контейнер Docker, здатний запускати самооновлення, сумісну для ОС. Через це зображення не необхідно оновлювати, як можна часто, коли включена версія ASF завжди може оновлюватись при потребі.

Of course, `UpdatePeriod` can be safely turned off (set to `0`), but in this case you should probably use `stable` release instead. Так само ви можете змінити типовий `UpdateChannel` для того, щоб замість цього слідкувати за попередніми релізами.

Due to the fact that the `latest` image comes with capability of auto-updates, it includes bare OS with OS-specific `linux` ASF version, contrary to all other tags that include OS with .NET runtime and `generic` ASF version. Це тому, що для нових (оновлень) версій ASF також знадобиться новіше середовище виконання, ніж зображення може бути створене разом що в іншому випадку потребує відновлення зображення з нуля, піднесення запланованого використання.

### `С.Р.`

Звичайна збірка ASF що вказує на фіксовану версію ASF, яка відповідає тегу. У порівнянні з вище тегами цей тег повністю заморожений, це означає, що зображення не буде оновлено після публікації. Це працює подібно до наших релізів GitHub, які ніколи не торкалися після початкового випуску, що гарантує вам стабільне і заморожене середовище. Зазвичай ви повинні використовувати цей тег, коли ви хочете користуватися якимсь конкретний випуск ASF, і ви очікуєте детермінований результат збірки (e. . Керуйте версіями ASF собі самостійно).

---

## Яка для мене мітка?

Це залежить від того, що ви шукаєте. Для більшості користувачів, `останній` тег повинен бути найкращим у тому що він пропонує саме те, що робить настільний ASF, тільки в спеціальному контейнері Docker як сервіс. Однак, це не зовсім те, як докер потрібно використовувати - зазвичай ви очікуєте відновлення контейнерів і не запускати їх назавжди, і у цьому випадку ви повинні подумати про `стабільне` або `випущений` , який слідує рекомендаціям для докерівних принципів. Lastly, if you want to run some fixed ASF version instead, then naturally `A.B.C.D` releases are what you're looking for.

Ми зазвичай не заставляємо пробувати `основні` збірки, тому що ми тут позначимо поточний стан проекту ASF. Ніщо не гарантує, що така держава буде працювати належним чином, але, звичайно, ви більш ніж бажані дати їм спробувати вашу зацікавлену розробку ASF.

---

## Архітектури

ASF docker image is currently built on `linux` platform targetting 3 architectures - `x64`, `arm` and `arm64`. You can read more about them in **[compatibility](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** section.

Наші теги використовують багатоплатформний маніфест, що значить, що Docker встановлений на вашому комп’ютері автоматично вибере правильне зображення для Вашої платформи при потягуванні зображення. If by any chance you'd like to pull a specific platform image which doesn't match the one you're currently running, you can do that through `--platform` switch in appropriate docker commands, such as `docker run`. See docker documentation on **[image manifest](https://docs.docker.com/registry/spec/manifest-v2-2)** for more info.

---

## Використання

Для повного посилання ви повинні використовувати **[офіційну документацію docker](https://docs.docker.com/engine/reference/commandline/docker)**, ми покриваємо базові використання в цьому посібнику, вас привітають до занурення у нього.

### Hello ASF!

По-перше, ми повинні перевірити, чи наш докер працює навіть правильно, це буде обслуговувати як наш ASF "Привіт світ":

```shell
docker запускає - name asf --pull завжди --rm justarchi/archisteamfarm
```

`docker запускає` новий контейнер для docker ASF і запускає його на передньому плані (`-it`). `--pull always` ensures that up-to-date image will be pulled first, and `--rm` ensures that our container will be purged once stopped, since we're just testing if everything works fine for now.

Якщо все закінчилося успішно, після натягування всіх шарів та початкового контейнера, ви повинні відмітити, що ASF запущено та повідомив нас, що немає визначених ботів, добре - ми перевірили, що ASF в док-станції працює належним чином. Hit `CTRL+C` to terminate the ASF process and therefore also the container.

If you take a closer look at the command then you'll notice that we didn't declare any tag, which automatically defaulted to `latest` one. If you want to use other tag than `latest`, for example `released`, then you should declare it explicitly:

```shell
docker запустити - воно --name asf --pull завжди --rm justarchi/archisteamfarm:випущено
```

---

## Використовується гучність

Якщо ви користуєтеся ASF у контейнері для докеру, то очевидно, що вам потрібно налаштувати саму програму. Ви можете робити це різними способами, але рекомендовано було б створити директорію ASF `config` на локальному комп'ютері, а потім монтувати його як спільний об'єм у контейнері ASF.

For example, we'll assume that your ASF config folder is in `/home/archi/ASF/config` directory. Цей каталог містить ядерний `ASF.json` та також ботів, які ми хочемо запустити. Now all we need to do is simply attaching that directory as shared volume in our docker container, where ASF expects its config directory (`/app/config`).

```shell
docker запустив -it -v /home/archi/ASF/config:/app/config --name asf --pull завжди justarchi/archisteamfarm
```

Саме так, тепер контейнер ASF docker буде використовувати спільний каталог вашого комп'ютера з режимом читання запису, це все, що потрібно для налаштування ASF. Аналогічним чином ви можете монтувати інші гучності, якими ви хотіли б поділитися з ASF, наприклад `/app/logs` or `/app/plugins`.

Звичайно, це лише один конкретний спосіб досягти того, чого ми хочемо, нічого не зупиняє вас, наприклад, створення власного `Dockerfile` яке скопіює ваші конфігураційні файли в каталог " `/app/config` у контейнері ASF. Ми обробляємо базове використання цього посібника.

### Права на рівень гучності

ASF контейнер за замовчуванням ініціалізований за замовчуванням `root` користувач, це дає змогу обробляти речі з внутрішніми дозволами, а потім зрештою перейти до `asf` (UID `1000`) користувача для решти частини основного процесу. While this should be satisfying for the vast majority of users, it does affect the shared volume as newly-generated files will be normally owned by `asf` user, which may not be desired situation if you'd like some other user for your shared volume.

Є два шляхи, як ви можете змінити користувача ASF працює. Перше, що рекомендується, - оголосити `ASF_UID` змінну середовища з цільовим UID, який ви хочете запустити under. Second, alternative one, is to pass `--user` **[flag](https://docs.docker.com/engine/reference/run/#user)**, which is directly supported by docker.

Наприклад, ви можете перевірити `uid` наприклад за допомогою команди `id -u` а потім оголосити його зазначеним вище. Наприклад, якщо ваш цільовий користувач має `uid` в 1001:

```shell
docker запустив -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull завжди justarchi/archisteamfarm

# Або якщо ви розумієте обмеження нижче
докер запускайте -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull завжди justarchi/archisteamfarm
```

Різниця між `ASF_UID` та `--user` є тонкою, але важливою. `ASF_UID` is custom mechanism supported by ASF, in this scenario docker container still starts as `root`, and then ASF startup script starts main binary under `ASF_UID`. When using `--user` flag, you're starting whole process, including ASF startup script as given user. Перша опція дозволяє запуску сценарію запуску ASF для роботи з дозволами та іншими матеріалами автоматично для вас, вирішення деяких загальних проблем, які ви мабуть спричинили, Наприклад, це гарантує, що директорії `/app` і `/asf` фактично належать `ASF_UID`. У другому сценарії, оскільки ми не виконуємо як `root`, ми не можемо цього зробити, і очікується, що ви впоралися з усім цим і заздалегідь.

If you've decided to use `--user` flag, you need to change ownership of all ASF files from default `1000` to your new custom user. Це можна зробити, виконавши наступну команду:

```shell
# Виконати тільки якщо ви не використовуєте ASF_UID
docker - u root asf_container_name chown -hR 1001 /app /asf
```

Це потрібно виконати лише один раз після створення контейнера з `докер запускається`і тільки якщо ви вирішили використовувати користувацького користувача через `--user` docker. Також не забудьте змінити аргумент `1001` у команді вище на `UID` ви насправді бажаєте запустити ASF under.

### Гучність з SELinux

If you're using SELinux in enforced state on your OS, which is the default for example on RHEL-based distros, then you should mount the volume appending `:Z` option, which will set correct SELinux context for it.

```
docker запустив -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull завжди justarchi/archisteamfarm
```

Це дозволить ASF створити файли, які посилаються на об'єм всередині контейнерів для docker.

---

## Синхронізація декількох екземплярів

ASF includes support for multiple instances synchronization, as stated in **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** section. Під час запуску ASF у контейнері ви можете опціонально виконати "opt-in" у процесі, у випадку, якщо ви запускаєте декілька контейнерів із ASF і ви бажаєте щоб вони працювали один з одним.

За замовчуванням, кожен ASF працює у контейнері для докерок, це означає, що синхронізація не відбуватиметься. In order to enable synchronization between them, you must bind `/tmp/ASF` path in every ASF container that you want to synchronize, to one, shared path on your docker host, in read-write mode. Це досягається так само, як пов'язувати об'єм, який було описано вище, з різними шляхами:

```shell
mkdir -p /tmp/ASF-g1
docker запустити -v /tmp/ASF-g1:/tmp/ASF -/home/archi/config/config:/app/config --name asf1 --pull archi/archisteamfarm
docker run -v /tmp/ASF-g1mp/home/joF/configapp/config --name asf2 --pull завжди just/archisteamfarm
І так далі, і це, усі ASF контейнери синхронізовані один з одним
```

Ми рекомендуємо пов'язати `/tmp/ASF` директорію тимчасового `/tmp` на вашому пристрої, але звичайно, ви вільні обирати будь-яку іншу інформацію, яка задовільняє вашому використанню. Кожен контейнер ASF, який потрібно синхронізувати з каталогом `/tmp/ASF` спільно з іншими контейнерами, які беруть участь у тому ж процесі синхронізації.

Як ви ймовірно здогадалися з прикладу вище, також можливо створити дві або більше "груп синхронізації", приєднуючись до різних шляхів хоста docker в `/tmp/ASF`.

Монтування `/tmp/ASF` не рекомендується, якщо ви явно не хочете синхронізувати два або більше контейнерів ASF. Ми не рекомендуємо монтувати `/tmp/ASF` для одноконтейнерів, оскільки він не дає абсолютно жодних переваг, якщо ви очікуєте запустити лише один контейнер ASF, і це дійсно може викликати проблеми, яких можна було б уникнути в іншому випадку.

---

## Аргументи командного рядка

ASF дозволяє вам передати **[аргументи командного рядка](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** у контейнері docker через змінні середовища. Для підтримуваних перемикачів слід використовувати конкретні змінні середовища і `ASF_ARGS` для решти. Це можна досягти за допомогою `-e` перемикач, доданий в `docker запустіть`, наприклад:

```shell
docker запустив -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull завжди justarchi/archisteamfarm
```

This will properly pass your `--cryptkey` argument to ASF process being run inside docker container, as well as other args. Звичайно, якщо ви досвідчений користувач, ви також можете змінити `ENTRYPOINT` або додати `CMD` і передати ваші аргументи самостійно.

Якщо ви не хочете вказати користувацький ключ шифрування або інші додаткові параметри, зазвичай не потрібно включати жодних спеціальних змінних середовища, оскільки наші контейнери docker вже налаштовані для запуску з розумним очікуваним параметром `--no-restart`, так що прапор не потрібно вказувати явно на `ASF_ARGS`.

---

## IPC

Assuming you didn't change the default value for `IPC` **[global configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, it's already enabled. Однак ви повинні зробити дві додаткові речі, щоб IPC працював у контейнері Docker. По-перше, ви повинні використовувати `IPCPassword` або змінити значення за замовчуванням `KnownNetworks` в користувацькому `IPC. onfig` що дозволяє вам підключатися ззовні не використовуючи одного. Якщо ви не знаєте, що ви робите, просто використовуйте `IPCPassword`. По-друге, необхідно змінити типову адресу прослуховування `localhost`, оскільки докер не може прямувати поза мережею і петлі інтерфейсу. An example of a setting that will listen on all interfaces would be `http://*:1242`. Звичайно, можна також використовувати більш обмежуючі з'єднання, такі як локальна мережа LAN або VPN. але це повинен бути маршрут назовні - `localhost` не буде робити, оскільки маршрут проходить вже не в гостьовій машині.

For doing the above you should use **[custom IPC config](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** such as the one below:

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

Як тільки ми налаштуємо IPC на не-циклічному інтерфейсі, нам потрібно повідомити docker для відображення `1242/tcp` порт `-P` або `-p` switch.

Наприклад, ця команда викриє інтерфейс IPC ASF на хостинг-сервер (лише ):

```shell
docker запустив -it -p 127.0.0.1:1242:1242 -p [:1]:1242:1242 --name asf --pull завжди justarchi/archisteamfarm
```

If you set everything properly, `docker run` command above will make **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface work from your host machine, on standard `localhost:1242` route that is now properly redirected to your guest machine. Також приємно відзначити, що ми не досліджуємо цей маршрут, так що з'єднання можна зробити тільки в хваті на стані, і, і, таким чином, зберігати його у безпеці. Звичайно, ви можете встановити маршрут далі, якщо ви знаєте, що ви робите і забезпечити відповідні заходи безпеки.

---

### Повний приклад

Поєднання цілих знань вище, приклад повної установки буде виглядати наступним чином:

```shell
docker запустив -p 127.0.0.1:1242:1242 -p [:1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name -- name asf -always --restart unless-stopped justarchi/archisteamfarm
```

This assumes that you'll use a single ASF container, with all ASF config files in `/home/archi/ASF/config`. Ви повинні змінити шлях конфігурації до тієї, яка відповідає вашому комп’ютеру. It's also possible to provide custom plugins for ASF, which you can put in `/home/archi/ASF/plugins`. Ці налаштування також готові до додаткового використання IPC, якщо ви вирішили включити `IPC. конфігурація` у вашому каталозі налаштувань з вмістом нижче, як тут:

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

Ви можете досягти такого ж ефекту `докер запустіть команду` , використовуючи наступний `docker створений` config:

```yaml
version: "3.8"
services:
  asf:
    image: justarchi/archisteamfarm
    container_name: asf
    restart: unless-stopped
    ports:
      - "127.0.0.1:1242:1242"
      - "[::1]:1242:1242"
    volumes:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

З речей, окрім того, що ми вже обговорювали вище, ми додали `--restart unless-stopped` до обох прикладів, щоб запустити цей контейнер автоматично після перезавантаження комп'ютера. Ви можете видалити/змінити його відповідно до ваших потреб.

---

## Pro tips

Коли у вас вже є табір контейнерів ASF, вам не потрібно використовувати `докер працювати` кожного разу. Ви можете легко зупинити/запустити контейнер для docker ASF за допомогою `docker зупинити asf` і `docker запустити asf`. Keep in mind that if you're not using `latest` tag then using up-to-date ASF will still require from you to `docker stop`, `docker rm` and `docker run` again. Це тому, що вам потрібно перебудувати ваш контейнер зі свіжого зображення docker ASF кожен раз, коли ви бажаєте використовувати версію ASF включені в це зображення. В `останній тег` , ASF включив функцію автоматичного оновлення так що повторне створення зображення не є необхідним для використання оновленого ASF (але для цього корисно робити це час від часу до того, щоб використовувати свіже. Залежності під час виконання ET та базової ОС, які можуть бути потрібні при переході через основні оновлення ASF).

As hinted by above, ASF in tag other than `latest` won't automatically update itself, which means that **you** are in charge of using up-to-date `justarchi/archisteamfarm` repo. Це має багато переваг, як, зазвичай, додаток не повинен торкатися власного коду при запуску, але ми також розуміємо зручність, бо не потрібно турбуватися про версію ASF у вашому контейнері. If you care about good practices and proper docker usage, `released` tag is what we'd suggest instead of `latest`, but if you can't be bothered with it and you just want to make ASF both work and auto-update itself, then `latest` will do.

Ви зазвичай повинні запустити ASF у контейнері з `заголовками: true` глобальний параметр. Це явно скаже ASF, що ви знаходитесь не у наданні відсутніх відомостей, і це не має запитувати їх. Of course, for initial setup you should consider leaving that option at `false` so you can easily set up things, but in long-run you're typically not attached to ASF console, therefore it'd make sense to inform ASF about that and use `input` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** if need arises. Таким чином, ASF не буде змушений чекати безкінечну кількість вхідних даних, які не будуть відбуватися (і витрачають ресурси, які це роблять). Це також дозволить ASF запустити у неінтерактивному режимі всередині контейнера, який необхідно використовувати, наприклад у відношенні до пересилання сигналів, що дозволяє ASF граційно закрити `докер зупинити asf` запиту.