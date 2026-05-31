# Сторонні розробки

Цей розділ включає в себе різні сторонні доповнення, записані виключно (або здебільшого ) для використання разом з ASF. Вони варіюють від ASF плагінів за допомогою простих веб-застосунків і внутрішніх бібліотек для інтеграції, і завершуються повнофункціональними ботами для інших платформ. Якщо ви хочете додати щось до списку, дайте нам знати в Discord або в нашій групі Steam.

Please note that below programs are **not** maintained by ASF developers and therefore **we give no guarantee about any of them**, especially in terms of security, safety or Steam ToS compliance. Цей список підтримується тільки за посиланням на сайт. Ви повинні завжди переконатися, що сторонні утиліти, які ви збираєтеся використовувати, є достатньо безпечним та легальним для вас, коли ви використовуєте їх все на власний ризик.

---

## ASF plugins

### **[CatPoweredPlugins](https://github.com/CatPoweredPlugins)** (**[Rudokhvist](https://github.com/Rudokhvist)**)

- **[ASFAchievementManager](https://github.com/CatPoweredPlugins/ASFAchievementManager)**, плагін для ASF, який дозволяє керувати досягненнями Steam.
- **[BirthdayPlugin](https://github.com/CatPoweredPlugins/BirthdayPlugin)**, плагін для отримання ASF щоб отримати привітання.
- **[CaseInsensitiveASF](https://github.com/CatPoweredPlugins/CaseInsensitiveASF)</a>**, плагін ASF робить бота нечутливим до регістру.
- **[CommandAliasPlugin](https://github.com/CatPoweredPlugins/CommandAliasPlugin)**, плагін для ASF налаштування користувацьких псевдонімів команди ASF.
- **[CommandlessRedeem](https://github.com/CatPoweredPlugins/CommandlessRedeem)**, plugin for ASF to re-implement key redeeming without a command.
- **[ItemDispenser](https://github.com/CatPoweredPlugins/ItemDispenser)**, плагін для ASF автоматично приймає запит торгівлі на певні типи елементів.
- **[SelectiveLootAndTransferPlugin](https://github.com/CatPoweredPlugins/SelectiveLootAndTransferPlugin)**, плагін для перенесення просунутої `передачі` команді з переказу елементів Steam.

### **[Цитринати](https://github.com/Citrinate)**

- **[Менеджер завантаження](https://github.com/Citrinate/BoosterManager)**плагін для ASF, який забезпечує простий у використанні інтерфейс для перетворення коштовностей в підсилювач пакетів, а також різні функції для керування запасами та каталогами ринку.
- **[CS2Interface](https://github.com/Citrinate/CS2Interface)**, plugin for ASF that allows you to interact with Counter-Strike 2 using **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**.
- **[FreePackages](https://github.com/Citrinate/FreePackages)**, плагін для ASF, який знаходить безкоштовні пакети на Steam і додає їх до вашого облікового запису.

### **[Віта](https://github.com/ezhevita)**

- **[FriendAccepter](https://github.com/ezhevita/FriendAccepter)**, плагін для ASF автоматично прийме всі запрошення у друзів.
- **[GameRemover](https://github.com/ezhevita/GameRemover)**, плагін для ASF реалізації ліцензії Steam для обраних екземплярів бота.
- **[GetEmail](https://github.com/ezhevita/GetEmail)**, плагін для генерації команди ASF для отримання адреси електронної пошти безпосередньо з Steam.
- **[Скидання APIKey](https://github.com/ezhevita/ResetAPIKey)**, плагін для ASF в реалізації команди скидання ключа API для обраних екземплярів бота.

### Інше

- **[ASFEnhance](https://github.com/chr233/ASFEnhance)**, плагін для покращення ASF з різними новими функціями, особливо командами.
- **[ASFFreeGames](https://github.com/maxisoft/ASFFreeGames)**, плагін для ASF дозволяє автоматично збирати безкоштовні ігри з steam опубліковані на reddit.

---

## Інтеграції

- **[ASFBot](https://github.com/dmcallejo/ASFBot)**, Telegram бот написаний на Python з інтеграцією ASF.
- **[запис користувача STM ASF](https://greasyfork.org/en/scripts/404754-asf-stm)**для тих, хто хоче надіслати автоматичні торгові пропозиції до ботів в нашому **[STM listing](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** через браузер, без використання функції `MatchActively` від ASF.
- **[simple-asf-bot](https://github.com/deluxghost/simple-asf-bot)**, інший (мінімальний) Telegram бот написаний з використанням python інтеграції ASF.

---

## Бібліотеки

- **[ASF-IPC](https://github.com/deluxghost/ASF_IPC)**, бібліотека Python для подальшої інтеграції з інтерфейсом ASF's IPC.

---

## Пакування

- **[AUR repo #1](https://aur.archlinux.org/packages/asf)**, allowing you to easily install ASF on arch linux.
- **[AUR repo #2](https://aur.archlinux.org/packages/archisteamfarm-bin)**, allowing you to easily install ASF on arch linux.
- **[Homebrew](https://formulae.brew.sh/formula/archi-steam-farm)**, що дозволяє легко встановити ASF на macOS.
- **[Nix](https://search.nixos.org/packages?channel=unstable&show=ArchiSteamFarm&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**і дозволяє легко встановити ASF на дистрибутиви з Nix.
- **[NixOS](https://search.nixos.org/options?channel=unstable&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, що дозволяє вам налаштувати та встановити ASF за допомогою NixOS.
- **[Scoop](https://scoop.sh/#/apps?q=ArchiSteamFarm)**, що дозволяє легко встановити ASF на вікна.
- **[Winget](https://github.com/microsoft/winget-pkgs/tree/master/manifests/j/JustArchiNET/ArchiSteamFarm)**, allowing you to easily install ASF on windows.

---

## Інструменти

- **[CS2Script](https://github.com/Citrinate/CS2Script)**- дає змогу керувати плагіном Counter-Strike 2 складових за допомогою **[CS2Interface](https://github.com/Citrinate/CS2Interface)**
- **[Keys extractor](https://umaim.github.io/SKE)**, allows you to copy-paste keys in various formats and create `redeem` command for ASF. Check **[GitHub repo](https://github.com/PixvIO/SKE)** for more details.
- **[Масовий редактор ASF](https://github.com/genesix-eu/ASF_MCE)**, який дозволяє більш легко керувати кількома конфігураціями ASF.

---

## Бажаєте знайти більше?

We recommend **[ArchiSteamFarm](https://github.com/topics/archisteamfarm)** topic on GitHub for all projects that integrate with ASF. Майте на увазі, однак, що це не пов'язане з проектами ASF, також може спробувати використовувати цей тег, зазвичай для самовдосконалення, тому завжди є хороша ідея пройти подвійну перевірку.