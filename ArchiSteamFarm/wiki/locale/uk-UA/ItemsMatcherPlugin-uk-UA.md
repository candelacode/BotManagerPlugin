# Модуль предметів sMatcherPlugin

`ItemsMatcherPlugin` це офіційний ASF **[плагін](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** який розширює ASF на ASF STM перелічені функції. In particular, this includes `PublicListing` in **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** and `MatchActively` in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. ASF постачається з `ItemsMatcherPlugin` разом з випуском і тому він готовий до використання прямо зараз.

---

## `Публічний список`

Публічний список, тому що ім'я має на увазі - список доступних ботів ASF. It's located on **[our website](https://asf.justarchi.net/STM)**, managed automatically and used as a public service for both ASF users that make use of `MatchActively`, as well as ASF and non-ASF users for manual matching.

Для того, щоб бути переліченим, у вас є набір вимог, які потрібно виконати. At the minimum, you must have allowed `PublicListing` in `RemoteCommunication` (default setting), `SteamTradeMatcher` enabled in `TradingPreferences`, **[public inventory](https://steamcommunity.com/my/edit/settings)** privacy settings, an **[unrestricted](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** account and **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** active. Додаткові вимоги включають 2FA активним з 15 днів, остання зміна пароля більше 5 днів тому, відсутність будь-яких обмежень на рахунок таких обмежень, як блокування коштів, економічні заборони та торгові банки. Naturally, you must also have at least one (tradable) item in your inventory from specified `MatchableTypes`, such as trading cards. In addition to that, bots with more than `500000` items are not accepted due to excessive overhead, we recommend to split your inventory across several accounts in this case.

While `PublicListing` is enabled by default, please note that you will **not** be displayed on the website if you do not meet all of the requirements, especially `SteamTradeMatcher`, which isn't enabled by default. Для людей, які не відповідають критеріям, навіть якщо вони тримали `PublicListing` , ASF взагалі не спілкується з сервером жодним чином. Публічний список також сумісний із лише останньою стабільною версією ASF, і може відмовитись від відображення застарілих ботів, особливо якщо у них відсутні основні функціональності, які можна знайти лише на новіших версіях.

### Як це працює

ASF відправляє початкові дані один раз після входу в систему, які містять усі параметри, які публічні списки використовуються. Потім, кожні 10 хвилин ASF відправляє один, дуже маленький запит на "серце", який повідомляє про те, що бот досі працює та працює. А якщо з якоїсь причини серцебиття не вийде, наприклад, через проблеми з мережею потім ASF буде намагатися надсилати його щохвилини до сервера його реєстрації. Таким чином наш сервер точно знає, які боти досі працюють і готові приймати торгову пропозицію. ASF також буде відправляти початкове оголошення на потрібній основі, наприклад якщо він виявить, що наш інвентар змінився з попереднього.

We display all eligible ASF accounts that were active in the **last 15 minutes**. Users are sorted according to their relative usefulness - `MatchEverything` bots which are shown with `Any` banner that accept all 1:1 trades, then unique games count, and finally items count.

### API

ASF STM список приймає лише боти ASF на час. Зараз немає можливості перерахувати сторонніх ботів в нашому списку, оскільки ми не можемо легко переглянути їх код і забезпечити вони відповідають нашій логіці цілої торгівлі. Участь у списку необхідно мати останню стабільну версію ASF, хоча вона може працювати з плагінами **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

For consumers of the listing, we have a very simple **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** endpoint that you can use. It includes all the data we have, apart from inventories of users which are part of `MatchActively` feature exclusively.

### Політика конфіденційності

Якщо ви погоджуєтесь із списком у нашому списку, увімкнувши `SteamTradeMatcher` і не відмовляючись від `публічного розміщення`як зазначено вище, ми тимчасово збережемо деталі вашого облікового запису Steam, щоб надати необхідну функціональність.

Публічна інформація (викрита Steam для кожної зацікавленої сторони) включає в себе:
- Ваш ідентифікаціонер Steam (у 64-бітній формі, для генерації посилань)
- Ваш псевдонім (цілі відображення)
- Ваш аватар (хеш, для цілей відображення)

Умови публічної інформації (викрито Steam для кожної зацікавленої сторони, якщо ви задовольняєте вимоги списку) включає:
- Your **[inventory](https://steamcommunity.com/my/inventory/#753_6)** (so people can use `MatchActively` against your items).

Приватна інформація (потрібні дані для забезпечення функціональності) включає:
- Your **[trading token](https://steamcommunity.com/my/tradeoffers/privacy)** (so people outside of your friendlist can send you trades)
- Параметр `Тип відповідності (` для відображення і збіг)
- Ваше значення `відповідне значення` (для цілей і співпадіння)
- Ваша `MaxTradeHolduration` настройка (щоб інші люди знали, чи готові ви прийняти їх угоди)

З моменту, коли ви припиняєте використовувати (анонсування) наш список, ваші дані стають недоступними для широкого загалу протягом максимум 15 хвилин, і інакше зберігається на нашому сервері максимум протягом двох тижнів - все буде автоматично видалено після цього періоду. Для цього не потрібно жодних дій.

---

## `МатчАктивлі`

`MatchActively` setting is active version of **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** including interactive matching in which the bot will send trades to other people. It can work standalone, or together with `SteamTradeMatcher` setting. This feature requires `LicenseID` to be set, as it uses third-party server and paid resources to operate.

Для того, щоб скористатися цією опцією, у вас є набір вимог, які потрібно виконати. Як мінімум, у вас має бути **[необмежений](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** акаунт, **

[ ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)</strong> активна та принаймні один правильний тип в `MatchableTypes`такі як торгові картки. Додаткові вимоги включають 2FA активним з 15 днів, остання зміна пароля більше 5 днів тому, відсутність будь-яких обмежень на рахунок таких обмежень, як блокування коштів, економічні заборони та торгові банки.</p> 

If you meet all of the requirements above, ASF will periodically communicate with our **[public ASF STM listing](#publiclisting)** in order to actively match bots that are currently available.

During matching, ASF bot will fetch its own inventory, then communicate with our server with it to find all possible `MatchableTypes` matches from other, currently available bots. Завдяки спілкуванню безпосередньо з нашим сервером, цей процес потребує одного запиту і ми маємо безпосередню інформацію про те, чи пропонує будь-який доступний бот нам щось цікаве - якщо відповідність знайдена, ASF буде відправлятися і підтверджено пропозицію по угоді.

Цей модуль має бути прозорим. Matching will start in approximately `1` hour since ASF start, and will repeat itself each `6` hours (if needed). `MatchActively` feature is aimed to be used as a long-run, periodical measure to ensure that we're actively heading towards sets completion, however, people that are not running ASF 24/7 may also consider using a `match` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Цільові користувачі цього модуля є основними обліковими записами і обліковими записами стами, хоча і може бути використаний будь-яким ботом, який не встановлено в `MatchEverything`. На додаток до цього, боти з більш ніж `500000 одиниць` не приймаються для відповідності надмірних накладних витрат, ми рекомендуємо розбивати ваш інвентар на кількох облікових записах.

ASF робить все можливе, щоб мінімізувати кількість запитів та тиску, які створюються за допомогою цього параметра, в той же час максимізуючи ефективність відповідної верхньої межі. Точний алгоритм вибору ботів для відповідності та організації всього процесу, це деталі реалізації ASF та можуть змінюватися стосовно зворотного зв’язку, ситуації та можливих майбутніх ідей.

The current version of the algorithm makes ASF prioritize `Any` bots first, especially those with better diversity of games that their items are from. When running out of `Any` bots, ASF will move on to the `Fair` ones upon same diversity rule. ASF намагатиметься підставити всіх доступних ботів принаймні один раз, щоб переконатися, що у нас немає можливого прогресу.

`MatchActively` takes into account bots that you blacklisted from trading through `tbadd` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** and will not attempt to actively match them. Це може використовуватись для того, щоб сказати ASF, які боти він повинен ніколи не співпадати, навіть якщо вони мають потенційні порти для використання.

ASF також буде робити все можливе, щоб переконатися, що торги проходять пропозиції. При наступному запуску, що зазвичай відбувається через 6 годин, ASF скасує всі пропозиції відкладеної торгівлі, які ще не були прийняті, і позбавити паймовиків, які беруть участь у них, сподіваючись, спочатку віддають перевагу більше активних ботів. Однак, якщо депріоритетизовані боти є останніми матчами, які нам потрібні, ми все ще спробуємо встановити відповідність (знову).



---



### Why do I need a `LicenseID` to use `MatchActively`? Хіба це не було вільно раніше?

ASF є безкоштовним та відкритим вихідним кодом, як він був створений на початку проекту знову в жовтні 2015 року. Вихідний код плагіна `ItemsMatcher` , і тому функція `MatchActively` доступна в нашому репозиторії, в той час як програма ASF зовсім не комерційна, ми нічого не заробляємо від внесків до неї, прибираємо чи публікації. За останні 7+ років ASF отримав надзвичайно велику кількість розвитку, він все ще вдосконалюється і посилюється з кожною щомісячним стабільним релізом здебільшого однією людиною, **[JustArchi](https://github.com/JustArchi)** - без прикріплених рядків. Єдине фінансування, яке ми отримуємо, це від необов'язкових пожертв, які надходять від наших користувачів.

For a very long time, until October 2022, `MatchActively` feature was part of ASF core and available for everyone to use. У жовтні 2022 р. Valve, компанія позаду Steam, розмістив дуже суворі обмеження швидкості при отриманні інвентарів інших ботів - які зробили попередній функціональність повністю зламаним, без можливості вирішити цю проблему. Тому через той факт, що функція стала цілком нефункціональною, без шансів бути фіксованою, його потрібно було видалити з ядра ASF в якості застарілого.

`MatchActively` був відновлений як частина офіційного `ItemsMatcher` плагін який підвищує ASF з активними картами відповідно до функціональності, на основі повністю переробленої концепції. Resurrecting `MatchActively` feature required from us **extraordinary amount of work** to create ASF backend, entirely new service hosted on a server, with more than a hundred of paid proxies attached for resolving inventories, all exclusively to allow ASF clients to make use of `MatchActively` like before. Через суму виконання, також і ресурси, які не вільні і вимагають сплати щомісяця (домен, сервер, закономірності), Ми вирішили надати цю функціональність нашим спонсорам, це: люди які вже підтримують проект ASF щомісячно, завдяки кому ми можемо зробити ці платні ресурси доступними.

Our goal isn't to profit from it, but rather, cover the **monthly costs** that are exclusively linked with offering this option - that's why we offer it basically for nothing, but we do have to charge a little for it as we can't pay hundreds of dollars from our own pockets each month, just to make it available for you. Ми не в змозі також обговорювати ціну, це Valve що змусило нас ці витрати, і альтернатива - не мати таких можливостей взагалі, який у будь-якому випадку застосовується якщо ви вирішите, з будь-якої причини, що не можете виправдати використання нашого плагіну на цих умовах.

In any case, we understand that `MatchActively` is not for everybody, and we hope that you also understand why we can't offer it for free. Якщо б ніхто не був зацікавлений в тому, щоб покрити витрати на цю функцію, не існували б, оскільки ми б змушені скорочуватися за щомісячні витрати, які ніхто не бажає підтримувати. На щастя, ми в кращій позиції, і ви можете вирішити себе, якщо хочете використати `MatchActively` на цих умовах, чи ні.



---



### Як я можу отримати доступ?

`ItemsMatcher` пропонується в якості частини щомісячного $5+ спонсорського рівня **[GitHub JustArchi's GitHub](https://github.com/sponsors/JustArchi)**. Також це можливо стати одноразовим спонсором, хоча в цьому випадку ліцензія буде дійсна тільки для місяця (з можливістю розширення в тому ж порядку). Once you become a sponsor of $5 tier (or higher), read **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** section to obtain and fill `LicenseID`. Afterwards, you only need to enable `MatchActively` in `TradingPreferences` of your chosen bot.

Ліцензія дозволяє надсилати обмежену кількість запитів на сервер. $5 tier дозволяє вам використовувати `MatchActively` для одного облікового запису бота (4 запити щодня), і кожна додаткова сума $5 додає ще два рахунки ботів (8 запитів щодня). Наприклад, якщо ви хочете запустити їх на трьох рахунках, то це буде покрито на 10$ рівня і вище.