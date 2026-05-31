# Дистанційне з'єднання

Цей розділ використовує на віддаленому зв'язку, до якого ASF, включаючи подальші пояснення щодо того, як саме він може вплинути на нього. Поки ми нічого не розглядаємо як шкідливий чи недооцінений, і поки ми юридично не зобов'язуємо його розв'язати, ми хочемо, щоб ви краще розуміли функціональність програми, особливо що стосується Вашої конфіденційності та передачі даних.

## Steam

ASF спілкується з мережею Steam (**[CM серверів](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), як і **[Steam API](https://steamcommunity.com/dev)**, **[Магазин Steam](https://store.steampowered.com)** і **[спільнота Steam](https://steamcommunity.com)**.

Неможливо відключити будь-який вищезгаданий режим, так як це основний фундамент ASF заснований на тому, щоб забезпечити його основну функціональність. Вам потрібно буде утриматися від користування ASF, якщо вам не зручно з вищезгаданим випадком.

## Парова група

ASF спілкується з нашою **[Steam групою](https://steamcommunity.com/groups/archiasf)**. Група надає вам нові оголошення, особливо нові версії, критичні проблеми, проблеми Steam та інші важливі для підтримання оновлення спільноти. Це також дозволяє вам використовувати нашу технічну підтримку, задаючи питання, вирішуючи проблеми, повідомляючи про проблеми або пропонуючи покращення. За замовчуванням, облікові записи які використовуються в ASF, автоматично приєднаються до групи при вході.

You can decide to opt-out of joining the group by disabling `SteamGroup` flag in bot's **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** settings.

## GitHub

ASF communicates with **[GitHub's API](https://api.github.com)** in order to fetch **[ASF releases](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** for the update functionality. This is done as part of auto-updates (if you've kept **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** enabled), as well as `update` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. You can influence ASF's communication with GitHub through **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** property - setting it to `None` will result in disabling entire update functionality, including GitHub communication in this regard.

## Сервер ASF

ASF спілкується з **[нашим власним сервером](https://asf.justarchi.net)** для більш просунутого функціоналу. Зокрема, це включає в себе:
- Перевірка контрольних сум ASF збірки, завантажених з GitHub, на нашу власну незалежну базу даних, щоб переконатися в тому, що всі завантажені збірки є законними (безкоштовні шкідливі програмне забезпечення, Атака МІТМ чи інше тампер)
- Отримання списку невдалих ботів для фільтрації, якщо ви тримали `FilterBadBots` включено глобальне налаштування конфігурації.
- Announcing your bot in **[our listing](https://asf.justarchi.net/STM)** if you've enabled `SteamTradeMatcher` in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** and meet other criteria
- Downloading currently available bots to trade from **[our listing](https://asf.justarchi.net/STM)** if you've enabled `MatchActively` in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** and meet other criteria

Як заходи безпеки, неможливо відключити перевірку контрольної суми для ASF біблів. Однак ви можете повністю відключити автооновлення, якщо ви хочете уникнути цього, як це описано вище в розділі GitHub.

Ви можете вимкнути установку `FilterBadBots` , якщо ви хочете уникнути отримання списку з сервера.

You can decide to opt-out of being announced in the listing by disabling `PublicListing` flag in bot's **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** settings. Це може бути корисно, якщо ви хотіли б запустити `SteamTradeMatcher` бот без повідомлення в той же час.

Downloading bots from our listing is mandatory for `MatchActively` setting, you'll need to disable that setting if you're unwilling to accept that.