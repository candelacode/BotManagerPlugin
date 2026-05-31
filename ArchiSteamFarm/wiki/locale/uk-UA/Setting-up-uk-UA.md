# Налаштування

Якщо ви тут вперше, ласкаво просимо! We're very happy to see yet another traveler that is interested in our project, although bear in mind that with great power comes great responsibility - ASF is capable of doing a lot of different Steam-related tasks, but only as long as you **care enough to learn how to use it**. Дійсно, читання wiki, виконуйте наші рекомендації та вивчайте більше про різні концепції ASF з часом ви отримаєте унікальну майстерність використання одного з найпотужніших інструментів Steam, доступних для сьогодення.

Ми рекомендуємо вам зробити **одну річ за раз**. ASF торкається багатьох різних аспектів, деякі з яких досить звичайні, деякі з них можуть бути надто складними. Вам не потрібно знати або читати про все відразу, і ми дійсно рекомендуємо вам це пройти. Розслабтеся, виберіть собі напої вибору, Присвяткуйте годину свого часу та занурюйтеся в нашу лекцію - ми можемо обіцяти, що буде добре вартістю вашого часу.

Давайте почнемо з основ. ASF це консольна програма в її принципі, що означає що він не буде автоматично спавн графічний інтерфейс, до якого ви звикли. ASF це універсальний додаток, який головним чином працює як сервіс (демон) чи не застосунок для робочого столу. Один з його основних випадків вважає роботу на серверних машинах, який програми для ПК зовсім не придатні. That considers only the absolute core of the program though, because ASF actually **does** include its own graphical interface - in form of its built-in ASF-ui frontend, but we'll get down to that part in due time - we're just mentioning this right away so you won't panic when seeing black console screen or something.

Після того як ви отримаєте двійкові файли ASF, програма буде вимагати від вас конфігурації, яка визначає що саме ви очікуєте досягти ASF. Ви можете запустити програму без конфігурації, у цьому випадку, ASF запуститься в стандартних налаштуваннях, що дозволить вам використовувати е. . ASF-ui для початкової конфігурації, але крім того вона не буде робити багато без вашої попередньої дії.

Це буде робити зараз, давайте розпочнемо!

---

## Налаштування для конкретної ОС

Взагалі, ось що нам з вами треба зробити за наступні кілька хвилин:
- Ми встановимо **[.NET передумови](#net-prerequisites)**.
- Тоді ми завантажимо **[останній реліз ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** у відповідний варіант для конкретної ОС.
- Далі ми виберемо архів до нового розташування.
- Then we'll **[configure ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- І, нарешті, ми запустимо ASF та побачимо його магію.

Деякі кроки пояснюють, але інші потребують більше уваги від вас. Не хвилюйся, ми покрили.

---

### Передумови для .NET

Перший крок це переконатися, що ваша ОС взагалі може коректно запустити ASF. Не потрібно цього знати, але ASF написаний на C#. Платформа ET повинна потребувати нативні бібліотеки, які ще не доступні на вашій платформі. Подумайте про це як DirectX для 3D ігор або двигун створення власного авто.

В залежності від того, чи будете ви використовувати Windows, Linux чи macOS, у вас будуть різні вимоги. The reference document is **[.NET prerequisites](https://docs.microsoft.com/dotnet/core/install)**, but for the sake of simplicity we've also detailed all needed packages below, so you don't need to read it at all, unless you run into problems or you'll have additional questions.

Цілком нормально, якщо деякі (або навіть усі) залежності вже існують у вашій системі через те, що були встановлені якимось програмним забезпеченням, яким ви вже користуєтесь. Однак, це не обов'язково має бути так, так що вам потрібно запустити відповідний інсталятор для вашої ОС - без цих залежностей ASF взагалі не запуститься, і ви заледве отримаєте будь-яку корисну інформацію за те, що не має рації.

Пам'ятайте, що вам не потрібно більше нічого для запуску пакетів ASF для конкретної ОС, особливо встановлювати .NET SDK чи навіть середовище виконання, оскільки пакет для конкретної ОС вже включає все це до свого складу. Вам потрібні лише передумови .NET (залежності), щоб запускати. Середовище виконання ET в ASF - тому лише речі, які ми вкажемо нижче, без будь-яких інших додатків.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** for 64-bit, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** for 32-bit or **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** for 64-bit ARM)
- Наполегливо рекомендуємо переконатися, що усі оновлення Windows вже встановлені. If you don't have them enabled, then at the very least you need **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** and **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, but more updates may be needed. Вам не потрібно турбуватися про те, що якщо ваші вікна оновлені, або, принаймні, пізніше.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Назви пакетів залежать від обраного дистрибутиву Linux, тож ми наводимо найпоширеніші з них. Ви можете отримати усі з них через стандартний менеджер пакетів у вашій ОС (такий як `apt` для Debian чи `yum` для CentOS). Це досить стандартні бібліотеки, які повинні бути доступні, незалежно від того, який дистрибутив Ви використовуєте, лише питання пошуку як вони називаються у середовищі вибору.

- `сертифікати ca-certificates` (стандартні надійні SSL сертифікати для з'єднання HTTPS)
- `libc6` (`libc`)
- `libgc-s1` (`libgc1`, `libgcc`)
- `libicu` (`icu-libs`, остання версія для вашого дистрибутиву, наприклад `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-libs`, latest version for your distribution, at least `1.1.X`)
- `libstdc+6` (`libstdc++`, у версії `5.0` або вище)
- `zlib1g` (`zlib`)

Принаймні більшість з них мають бути вже нативно доступні у вашій системі. Наприклад, мінімальна установка Debian стабільна зазвичай вимагає лише `libicu76`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- Вам не потрібно нічого конкретно, але вам потрібно встановити останню версію macOS, принаймні 12.0+

---

### Завантаження

Оскільки ми вже маємо всі необхідні передумови, наступний крок це завантаження **[останнього випуску ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF наявний у декількох варіантах, але вам потрібен пакет який відповідає вашій операційній системі та архітектури. Наприклад, якщо ви користуєтесь `64`-розрядною `Win`dows, то вам потрібен пакет `ASF-win-x64`. Для отримання додаткової інформації щодо існуючих варіантів, дивіться розділ **[сумісність](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-uk-UA)**. ASF також може працювати з середовищами, для яких ми не робимо пакет для конкретної ОС, наприклад **32-розрядна Windows**, але для цього вам знадобляться **[загальні налаштування](#generic-setup)**.

![Файли](https://i.imgur.com/Ym2xPE5.png)

Після завантаження, почніть з того щоб розпакувати файл zip до окремої папки. If you require a specific tool for that, **[7-zip](https://www.7-zip.org)** will do, but all standard utilities like built-in Windows extraction or `unzip` from Linux/macOS should work without problems as well.

Be advised to unpack ASF to **its own directory** and not to any existing directory you're already using for something else - that's important. ASF має автоматичну функцію оновлень, яка замінює його власні файли, та зазвичай буде видаляти всі старі та непов'язані з цим файли під час оновлення, це може призвести до втрати будь чого, що ви приклали до каталогу ASF. Якщо у вас є якісь додаткові скрипти чи файли, які ви хочете використовувати з ASF, це не проблема, створіть для них окрему папку, ви завжди можете поставити ASF на одну папку глибше.

Приклад того, як може виглядати ця структура:

```text
C:\ASF (куди ви виклали свої власні речі)
    ───Times MyNotes. xt (опціонально)
    ── AsfMakeMeCoffeScript.bat (опціонально)
    ─── (... (будь-які інші файли вибору, опціональні)
    ───Core (присвячені лише ASF, де ви вилучаєте архів)
         59 59 59 інструкцій ArchiSteamFarm(. xe)
         ── config
         ─── logs
         ─── plugins
         ── www 
 ─w
         ──54 (...)
```

---

### Конфігурація

Тепер ми готові зробити останній крок, конфігурацію. ASF працює з концепцією "ботів", кожен бот зазвичай є одним обліковим записом Steam, яким ви хочете користуватися в ASF. Ви можете оголосити скільки схожих ботів, але для початківця ми зосередимось лише на одному з них - зазвичай ваш основний обліковий запис. ASF також має файли конфігурації не ботів, найважливіше - це глобальний файл конфігурації, який впливає на всіх ботів інстансу.

The general rule of thumb is that **if you don't know, or don't understand some setting, you should leave it with its default value, without changing anything**. ASF offers countless ways to configure, customize and tweak almost all of its features, but like mentioned above, trying to understand it right off the bat is a rabbit hole that may quickly drag you into severe confusion, if not **[straight into the abyss](https://www.youtube.com/watch?v=KK3KXAECte4)**. Instead, we recommend to have a working example first, and only then start digging into additional options, with the help of **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** page on the wiki, while changing **one thing at a time**.

Конфігурація ASF може бути зроблена кількома способами - через наш вбудований інтерфейс ASF-ua, автономний веб генератор конфігурацій, або вручну. Це докладно пояснюється у розділі **[конфігурації](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-uk-UA)**, тому зверніться до нього якщо вам потрібна детальна інформація. Ми будемо використовувати веб генератор конфігурацій автономні у якості початкової точки, тому що він працює, навіть якщо з певних причин ASF-ui не зможе працювати належним чином.

Перейдіть до нашої **[веб генератор конфігурацій](https://justarchinet.github.io/ASF-WebConfigGenerator)** за допомогою вашого улюбленого браузера. Ми рекомендуємо Chrome чи Firefox, але це не має значення, поки ваш браузер працює для всього іншого.

Після відкриття сторінки, перейдіть на вкладку "Бот". Ви маєте побачити сторінку схожу на приведену нижче:

![Вкладка Bot](https://i.imgur.com/aF3k8Rg.png)

Якщо за якихось обставин завантажена вами версія ASF більш стара, ніж генератор конфігурацій використовує за замовчуванням, просто оберіть потрібну версію ASF з випадного меню. Це може (зрідко) статися, бо генератор конфігурацій може бути використаний для генерації конфігурацій новішої (pre-release) версії ASF, яка ще не позначена як стабільна. Ви завантажили останню стабільну версію ASF, яка перевірена щодо надійної роботи. так що вона може бути трохи старшою, ніж абсолютна версія попереду, яка зовсім не підпадає для першого використання.

Start from **putting name for your bot** into the field highlighted as red, called `Name`. Це може бути будь яке ім'я, яким ви б хотіли користатися, наприклад нікнейм, ім'я акаунта, номер, чи щось інше. Є лише одно слово, яке ви не можете обрати, `ASF`, бо це є ключове слово, зарезервоване для файлу глобальної конфігурації. На додаток до цього, ім'я вашого бота не може починатися з крапки (ASF навмисно ігнорує такі файли). We also recommend that you avoid using spaces, you can use `_` as a word separator if needed - not a strict requirement, but you'll have hard time using ASF commands otherwise.

Назва бота вирішила? Чудово, на наступному кроці **зміна `ввімкнена` перемикачем на**, що визначає, чи повинен ваш бот запускатися ASF автоматично після запуску (програми). Це не викличе видачу ASF на те, що ваш бот відключений у файлі конфігурації, і вона чекатиме поки ваші дані почнуть роботу, що не те що ми хочемо робити в цьому прикладі.

Now, there are two sensitive properties coming up next: `SteamLogin` and `SteamPassword`. Можете вирішити це тут - можна або вводити дані свого облікового запису Steam у відповідності з цими двома властивостями, чи можете ви вирішити проти цього, не залишивши їх порожніми.

ASF потребує ваші облікові дані бо він має вбудовану реалізацію клієнта Steam, і для входу потребує те ж саме, що й офіційних клієнт яким ви користуєтесь. Your login credentials are not saved anywhere but on your PC in ASF `config` directory only (once you download the generated config). Наш веб генератор конфігурацій - це клієнтський додаток, що означає що все, що ви робите на нашому веб-сайті веб веб веб беконфіг працює локально в вашому браузері для генерації дійсних конфігурацій ASF, без деталей, які ви вводите ніколи в першу чергу свій ПК, тому немає необхідності турбуватися про витік будь-яких конфіденційних даних. Однак, якщо з будь-якої причини не хочете вводити в те свої облікові дані там, ми це розуміємо, і ви можете потім передати їх вручну у згенеровані файли, або без них почати роботу без них.

Якщо ви вирішите ввести ваші облікові дані, ASF зможе автоматично увійти під час запуску, які разом з необов'язковими 2FA ефективно дозволять вам просто двічі клацнути на програму, щоб все це виконати. If you decide to omit them, then ASF will **ask you** to input those details when needed - that approach won't save them anywhere, but naturally ASF won't be able to operate without your help. It's up to you which way you prefer more, and you can also find additional information in **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section, as usual.

As a side note, you can also decide to leave just one field empty, such as `SteamPassword`. ASF тоді буде мати можливість використовувати ваш логін автоматично, але буде запитувати пароль, якщо необхідно (як і варіант Steam Client). If by any chance you're using 4-digit parental pin to unlock your account, we also recommend to put it inside `SteamParentalPin` box, although also in this case you can just leave this empty, and instead observe how weak that protection is, because ASF can also "crack" it itself within mere seconds after logging in. Ой.

After following with everything above, so once again, **bot name**, **enabled switch**, and **login credentials** , your web page will now look similar to the one below:

![Вкладка Bot 2](https://i.imgur.com/yf54Ouc.png)

Тепер ви можете просто натиснути кнопку "Скачати" і наш веб генератор конфігурацій згенерує новий файл `json` на базі обраного імені. Save that file into `config` directory which is located in the folder inside which you've extracted the zip file in the previous step.

Вітаємо! Ви тільки що завершили створення дуже простої конфігурації для бота ASF. Є набагато більше, щоб виявити, але наразі це все, що вам потрібно.

---

### Запуск ASF

Я знаю, що ви чекали на цей момент, і ми не можемо вас затримати, оскільки ви вже готові до першого запуску програми. Просто клацніть двічі по виконуваному файлу `ArchiSteamFarm` у каталозі ASF. Ви також можете запустити його з консолі.

Now would be a good time to review our **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section if you're concerned about stuff that ASF is programmed to do, especially actions that it'll take in your name, such as joining our Steam group by default. Ви завжди можете відключити функції пізніше, якщо вам не сподобається їм, ASF просто має розумні значення за замовчуванням, ми мусили прийняти якесь рішення про загальне використання, що стосується більшості наших користувачів, а також наша власна думка про програму в її принципі.

Припустимо, що все пройшло добре, що, в основному, зберігає всі необхідні залежності на перший крок, та налаштування ASF на третьому рівні, ASF має правильно запустити запуск, знайти вашого першого бота та спробувати увійти до системи:

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF все ще потребує ще одну детальну інформацію від вас - 2FA для доступу до облікового запису (якщо ви не вимкнули SteamGuard повністю, а потім ні). Просто дотримуйтесь інструкцій на екрані, ви можете надати код від автентифікатора/електронної пошти або прийняти підтвердження в мобільному додатку.

Щось пішло не так?

#### ASF взагалі не запускається, немає вікна консолі

Або вам відсутні .NET prerequisites, або завантажили невірний варіант ASF для вашого комп'ютера. If you don't know what's wrong, check our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** for a possible way to find out exact problem, and if you're still stuck, reach for our **[support](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### Ботів не визначено

You didn't put generated config into the `config` directory. Деякі інші поширені помилки на цьому кроці можуть включати в себе змінення розширення `.json` , наприклад, у `. xt`, і деякі операційні системи (напр. Windows) люблять приховувати загальні розширення за замовчуванням, щоб ваші файли були в тому ж місці, а також відповідному імені.

#### Не запущений бот, тому що він відключений у файлі конфігурації

Ви забули повернути `включений` перемикач, який вказує ASF на те, що ASF запускає вашого бота автоматично. Unless that was your intention of course, but then you should already know how to execute commands, simply `start` your bot after that message.

#### `Неправильний пароль`

Ваші облікові дані введені невірно. Перевірте свою `SteamLogin` та `SteamPassword` у згенерованій конфігурації, якщо вони помиляються, повертайтеся до кроку конфігурації. Якщо у вас все ще виникають проблеми, спробуйте використовувати логін і облікові дані у власному клієнті Steam, вам також слід не вдатися до системи, і, можливо, ви отримаєте більше інформації про те, що не так.

#### Все добре?

Після проходження початкового входу, якщо припустити, що ваші дані є вірними, ви успішно увійдете, і ASF почне фармити за допомогою типових налаштувань, яких ви не торкалися зараз:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Це доводить що ASF тепер успішно працює з вашим обліковим записом, тому ви можете згорнути програму і зайнятися чимось іншим. Ну все, ти заслужив на це, можливо поповнив, що принаймні випив свій вибір!

Farming cards is a subject for another lengthy article like this, but in principle: after enough of time (depending on **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), you'll see Steam trading cards slowly being dropped. Of course, for that to happen you must have valid games to farm, showing as "you can get X more card drops from playing this game" on your **[badges page](https://steamcommunity.com/my/badges)** - if there are no games to farm, then ASF will state that there is nothing to do, as stated in our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, which answers the most common question people have at this point, wondering why despite owning whopping 14 games on their account, ASF claims there's nothing to do - no, it's not a bug.

На цьому ми завершуємо наш дуже простий посібник з налаштування. Як і в кожній RPG грі, ви завершили навчання, і ми залишимо вам увесь світ ASF, щоб вивчити зараз. Наприклад, ви можете вирішити чи бажаєте ви конфігурувати ASF далі, чи дозволити йому робити свою роботу в налаштуваннях за замовчуванням. Ми розглянемо ще кілька основних деталей, якщо ви хочете прочитати трохи більше, то залишимо вам усю wiki для знаходження.

---

### Додаткова конфігурація

#### Фарм декількох облікових записів одразу

ASF підтримує фермерство декількох облікових записів за один раз, що є його основною функцією. Ви можете додати більше облікових записів до ASF просто згенерувавши більше конфігураційних файлів ботів, точно так само як ви згенерували перший кільки хвилин тому. Вам треба забезпечити лише дві речі:

- Унікальне ім'я боту, якщо у вас вже є ваш перший бот з ім'ям `MainAccount`, ви не можете мати іншого з тим же ім'ям.
- Valid login details, such as `SteamLogin`, `SteamPassword` and `SteamParentalCode` (if you've decided to fill them)

Інакше кажучи, перейдіть знову до конфігурації і робіть те ж саме, тільки для другого або третього облікового запису. Не забудьте використовувати унікальні імена для всіх ваших ботів, щоб не перезаписувати існуючі конфігурації.

---

#### Зміна налаштувань

На нашому автономному веб-генераторі конфігурацій ви змінюєте існуючі налаштування так само - генеруючи новий файл конфігурації. Натисніть на "переключити додаткові налаштування" та подивіться, що там для вас знайти. У цьому прикладі ми змінимо налаштування `CustomGamePlayedWhileFarming` яке дозволяє встановити яке ім'я користувача при роботі ASF замість відображення даної гри.

Давайте спочатку проаналізуємо. Якщо ви запустите ASF і почнете фармити в стандартних налаштуваннях, то ви побачите, що ваш обліковий запис Steam зараз у грі:

![Steam](https://i.imgur.com/1VCDrGC.png)

Це має сенс, адже усі ASF просто сказав платформі Steam, що ми граємо в гру, нам потрібні карти з цього, правда? Але агов, ми можемо підлаштувати це! Увімкніть розширені налаштування, якщо ви ще не зробили, тоді знайти `CustomGamePlayedWhileFarming`. Просто додайте довільний текст, який ви хочете там показати, наприклад "Idling cards":

![Вкладка Bot 3](https://i.imgur.com/gHqdEqb.png)

Тепер скачайте новий файл конфігурації так само як і раніше, та **перезапишіть** ваш старий файл конфігурації на новий. Звичайно, ви можете також видалити старий файл конфігурації та покласти новий на його місце.

ASF досить розумний і має помітити, що ви змінили конфігурацію, який буде автоматично забрати і застосувати, без перезавантаження програми. Якщо будь-який шанс цього не сталося, ви можете просто перезапустити програму для того, щоб впевнитися що ви підняли нову конфігурацію. Після цього ви повинні помітити, що ASF тепер відображає ваш власний текст у попередньому місці:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

Це підтверджує що ви успішно відредагували вашу конфігурацію. Саме таким чином ви можете змінити глобальні параметри ASF, для цього перейдіть на вкладку "ASF", скачайте згенерований `ASF. son` файл конфігурації і помістивши його в каталог конфігурації ``.

Редагування конфігурацій ASF можна зробити набагато легше за допомогою нашого інтерфейсу ASF-ua, що буде пояснюватися нижче.

---

#### Використання ASF-ui

Як ми вже згадували раніше, ASF це консольна програма і не запускає графічний інтерфейс користувача за замовчуванням. Однак ми активно парацюємо над інтерфейсом **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-uk-UA#asf-ui)** для нашого IPC, який може бути гідним та зручним способом скористатися різними можливостями ASF.

Щоб використовувати ASF-ui, ви повинні увімкнути `IPC` який є параметром за замовчуванням, тому, якщо ви не вимкнули його вручну, він вже активний. Як тільки ви запустите ASF, ви повинні мати можливість підтвердити, що він належним чином запустив інтерфейс IPC:

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC, Головним чином, є вбудований веб-сервер ASF, який запущено локально на вашому пристрої, дозволяє взаємодіяти з ним за допомогою вашого улюбленого веб-переглядача. Assuming that it started correctly, you can access ASF's IPC interface by clicking **[this](http://localhost:1242)** link, as long as ASF is running, from the same machine. You can use ASF-ui for various purposes, e.g. editing the config files in-place or sending **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Ви вільні вивчати цей інтерфейс з метою дізнатися про усі можливості ASF-ui.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Підсумок

Ви успішно налаштували використання у ASF ваших облікових записів, і навіть трошки настроїли додаткові опції. Якщо ви дотримувалися усього нашого посібника, то вам також вдалося налаштувати ASF за допомогою нашого інтерфейсу ASF-ui і почати знаходити його функціональності. Це завершує наш підручник, але ми залишаємо вам додаткові вказівники для того, що вас можуть зацікавити "бічні квести", якщо ви наполягаєте:

- Our **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section will explain to you  what **all** those different settings you've seen actually do, and what else ASF can offer to you. Коли читаєш - нас попереджали.
- If you've stumbled upon some issue or you have some generic question, consider our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**, which should cover all, or at least a vast majority of questions and issues that you may have.
- Якщо ви бажаєте дізнатися геть усе про ASF, і про те як воно може зробити ваше життя легшим, ознайомтеся й з рештою **[нашої wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-uk-UA)**. Скористайтеся бічною панеллю праворуч для вибору теми, що вас цікавить.
- And finally, if you found out our program to be useful for you and you appreciate the massive amount of work that was put into it, you can also consider a small **[donation](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** to our cause. ASF це праця з любові, ми багато працювали за останні 10 років протягом останніх 10 років щоб зробити цей досвід максимально можливим для вас, і ми дуже пишаємося цим - навіть $1 дуже цінний і показує, чого вам не потрібен. У будь-якому випадку, отримаєте багато задоволення!

---

## Універсальне налаштування

This appendix is for advanced users that want to set up ASF to run in **[generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)** variant. While being more troublesome in usage than **[OS-specific variants](#os-specific-setup)**, it also comes with additional benefits.

Ви бажаєте використовувати `загальний` варіант головним чином, коли:
- Ви використовуєте ОС, для якої ми не робимо пакунок під конкретну ОС (наприклад 32-розрядна Windows)
- У вас вже є .NET Runtime/SDK, або ви хочете встановити та використовувати один
- Ви бажаєте мінімізувати розмір структури ASF та дані про об'єм пам'яті, зробивши обробку вимог середовища виконання самостійно
- You want to use a custom **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** which requires a `generic` setup of ASF to run properly (due to missing native dependencies)

Звичайно, ви можете використовувати його також в будь-якому іншому сценарії, який ви хочете, але вище має сенс.

However, keep in mind that generic setup comes with a twist - **you** are in charge of .NET runtime in this case. Це означає, що якщо ваш .NET SDK (runtime) недоступний, застарілий чи зламаний, ASF просто не спрацює. This is why we totally don't recommend this setup for casual users, since you now need to ensure that your .NET SDK (runtime) matches ASF requirements and can run ASF, as opposed to **us** ensuring that our .NET runtime bundled with ASF can do so.

Для пакету `generic` , ви можете дотримуватися інструкції, визначеного для ОС, з лише двома невеличкими змінами. In addition to installing .NET prerequisites, you also want to install .NET SDK, and instead of downloading and having OS-specific `ArchiSteamFarm(.exe)` executable file, you'll now download and have a generic `ArchiSteamFarm.dll` binary only. Усе решта точно те ж саме.

Тож, разом з додатковими кроками, вам треба:
- Встановити **[передумови для .NET](#net-prerequisites)**.
- Install **[.NET SDK](https://www.microsoft.com/net/download)** (or at least ASP.NET Core and .NET runtimes) appropriate for your OS. Найвірогідніше ви схочете скористуватися інсталятором. Зверніться до розділу "**[Вимоги середовища виконання](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-uk-UA#Вимоги-середовища-виконання<)**", якщо не впевнені яку версію вам потрібно встановити.
- Скачати **[останній випуск ASf](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** в універсальному (`generic`) варіанті.
- Розпакувати архів до нового розташування.
- **[Налаштувати ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, точно так само, як описано вище.
- Запустити ASF або за використавши допоміжний скрипт, або виконавши команду `dotnet /path/to/ArchiSteamFarm.dll` вручну з вашої улюбленої консолі.

Generic variant of ASF does not have machine-specific binary, after all it's called `generic` for a reason - it's platform-agnostic build that can work everywhere, so don't expect `exe` file there.

Ось чому ми об'єднали його за допомогою допоміжних скриптів (наприклад, `ArchiSteamFarm.cmd` для Windows та `ArchiSteamFarm. h` для Linux/macOS), які розташовані поруч з двійковим файлом `ArchiSteamFarm.dll`. Ви можете використовувати їх, якщо ви не хочете виконувати команду `dotnet` вручну.

Obviously, helper scripts won't work if you didn't install .NET SDK and you don't have `dotnet` executable available in your `PATH`. They're also entirely optional to use, you can always `dotnet /path/to/ArchiSteamFarm.dll` manually if you'd like to, as under the hood with some extra tweaks, that's exactly what those scripts are doing anyway.