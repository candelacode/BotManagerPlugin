# Сторонние разработки

Этот раздел включает в себя различные дополнения сторонних разработчиков, разработанные специально (или в основном) для использования совместно с ASF. Они покрывают весь спектр начиная с плагинов для ASF, простых веб-приложений, включая простые веб-приложения и внутренние библиотеки для удобства дальнейшей интеграции, и заканчивая полнофункциональными ботами для других платформ. Если вы хотите добавить что-то в этот список - свяжитесь с нами на нашем сервере Discord или в нашей группе Steam.

Пожалуйста, обратите внимание, что программы ниже **не** поддерживаются разработчиками ASF и поэтому **мы не даём никаких гарантий относительно них**, особенно в части безопасности, надёжности и соответствия соглашению подписчика Steam. Этот список поддерживается только для справок. Вы всегда должны быть уверены, что сторонняя утилита, которую вы собираетесь использовать, является безопасной и достаточно легальной для вас, поскольку вы используете их на свой страх и риск.

---

## Плагины для ASF

### **[CatPoweredPlugins](https://github.com/CatPoweredPlugins)** (**[Rudokhvist](https://github.com/Rudokhvist)**)

- **[ASFAchievementManager](https://github.com/CatPoweredPlugins/ASFAchievementManager)**, плагин для ASF, который позволяет управлять достижением Steam.
- **[BirthdayPlugin](https://github.com/CatPoweredPlugins/BirthdayPlugin)**, плагин для ASF для получения поздравлений с днем рождения.
- **[CaseInsensitiveASF](https://github.com/CatPoweredPlugins/CaseInsensitiveASF)**, плагин для ASF делает имена ботов нечувствительными к регистру.
- **[CommandAliasPlugin](https://github.com/CatPoweredPlugins/CommandAliasPlugin)**, плагин для ASF для настройки пользовательских псевдонимов команд для команд ASF.
- **[CommandlessRedeem](https://github.com/CatPoweredPlugins/CommandlessRedeem)**, плагин для ASF повторно реализовывать ключ без команды.
- **[ItemDispenser](https://github.com/CatPoweredPlugins/ItemDispenser)**, плагин для ASF автоматически принимать запрос на торговлю для определенных типов предметов.
- **[SelectiveLootAndTransferPlugin](https://github.com/CatPoweredPlugins/SelectiveLootAndTransferPlugin)**, плагин для ASF, предоставляющий дополнительные команды `передачи` для передачи Steam элементов.

### **[Citrinate](https://github.com/Citrinate)**

- **[BoosterManager](https://github.com/Citrinate/BoosterManager)**, плагин для ASF, предоставляющий простой в использовании интерфейс для превращения самоцветов в наборы карточек, а также различные функции для управления инвентарем и лотами, размещенными на Торговой площадке.
- **[CS2Interface](https://github.com/Citrinate/CS2Interface)**, плагин для ASF, позволяющий взаимодействовать с Counter-Strike 2 с помощью **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**.
- **[FreePackages](https://github.com/Citrinate/FreePackages)**, плагин для ASF, который находит бесплатные пакеты в Steam и добавляет их на ваш аккаунт.

### **[VITA](https://github.com/ezhevita)**

- **[FriendAccepter](https://github.com/ezhevita/FriendAccepter)**, плагин для ASF, позволяющий автоматически принимать все приглашения в друзья.
- **[GameRemover](https://github.com/ezhevita/GameRemover)**, плагин для ASF, реализующий команду удаления лицензий Steam для выбранных экземпляров ботов.
- **[GetEmail](https://github.com/ezhevita/GetEmail)**, плагин для ASF, реализующий команду для получения адресов электронной почты заданных экземпляров ботов непосредственно из Steam.
- **[ResetAPIKey](https://github.com/ezhevita/ResetAPIKey)**, плагин для ASF, реализующий команду сброса ключа API для выбранных экземпляров ботов.

### Другое

- **[ASFEnhance](https://github.com/chr233/ASFEnhance)**, плагин для ASF, дополняющий его различными новыми функциями, особенно командами.
- **[ASFFreeGames](https://github.com/maxisoft/ASFFreeGames)**, плагин для ASF, позволяющий автоматически собирать бесплатные steam-игры, выложенные на reddit.

---

## Интеграции

- **[ASFBot](https://github.com/dmcallejo/ASFBot)**, бот для telegram, написанный на python и интегрированный с ASF.
- **[ASF STM](https://greasyfork.org/en/scripts/404754-asf-stm)** - userscript для тех, кто хочет отправлять автоматизированные торговые предложения ботам в нашем **[листинге ASF STM](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** через веб-браузер без использования функции `MatchActively`, предоставляемой ASF.
- **[simple-asf-bot](https://github.com/deluxghost/simple-asf-bot)**, другой (минимальный) робот телеграммы, написанный на Python с интеграцией ASF.

---

## Библиотеки

- **[ASF-IPC](https://github.com/deluxghost/ASF_IPC)**, библиотека на языке python для удобной интеграции с интерфейсом ASF IPC.

---

## Пакетная установка

- **[репозиторий AUR #1](https://aur.archlinux.org/packages/asf)**, позволяющий легко установить ASF на Arch linux.
- **[репозиторий AUR #2](https://aur.archlinux.org/packages/archisteamfarm-bin)**, позволяющий легко установить ASF на Arch linux.
- **[репозиторий Homebrew](https://formulae.brew.sh/formula/archi-steam-farm)**, позволяющий легко установить ASF на macOS.
- **[репозиторий Nix](https://search.nixos.org/packages?channel=unstable&show=ArchiSteamFarm&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, позволяющий легко установить ASF на дистрибутивы с Nix.
- **[репозиторий NixOS](https://search.nixos.org/options?channel=unstable&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, позволяющий легко установить ASF на дистрибутивы с NixOS.
- **[Scoop](https://scoop.sh/#/apps?q=ArchiSteamFarm)**позволяет легко установить ASF в окне.
- **[Winget](https://github.com/microsoft/winget-pkgs/tree/master/manifests/j/JustArchiNET/ArchiSteamFarm)**, позволяющий легко установить ASF на Windows.

---

## Инструменты

- **[CS2Script](https://github.com/Citrinate/CS2Script)**, позволяет управлять вашими единицами хранения Counter-Strike 2 с помощью плагина **[CS2Интерфейс](https://github.com/Citrinate/CS2Interface)**.
- **[Keys extractor](https://umaim.github.io/SKE)**, позволяет вам копировать/вставлять ключи в различных форматах и формировать команду `redeem` для ASF. Вы найдёте подробности в **[репозитории на GitHub](https://github.com/PixvIO/SKE)**.
- **[ASF Mass Config Editor](https://github.com/genesix-eu/ASF_MCE)**, позволяет проще управлять большим количеством конфигурационных файлов ASF.

---

## Хотите найти больше?

Мы рекомендуем **[ArchiSteamFarm](https://github.com/topics/archisteamfarm)** тема на GitHub для всех проектов, которые интегрируются с ASF. Имейте в виду, однако, что не связанные с ASF проектами могут также пытаться использовать тег, обычно для самопродвижения, так что при двойной проверке всегда будет хорошая идея.