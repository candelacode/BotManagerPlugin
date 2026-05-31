# Ведення журналу

ASF дозволяє налаштувати свій власний модуль журналу, який буде використовуватися під час роботи. Ви можете зробити це, поставивши спеціальний файл з ім'ям `NLog.config` у каталог застосунку. Ви можете прочитати всю документацію NLog on **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**але на додаток до цього можна знайти й кілька корисних прикладів.

---

## Реєстрація за замовчуванням

Типово, ASF це журналювання `ColoredConsole` (стандартний вивід) та `File`. Журналювання `File` включає файл `log.txt` в каталозі каталогу програми, а `журнали` для використання в архіві.

Using custom NLog config automatically disables default ASF config, your config overrides **completely** default ASF logging, which means that if you want to keep e.g. our `ColoredConsole` target, then you must define it **yourself**. Це дозволяє Вам не тільки додати **додаткові** ярлики для журналу, а й вимкнути або змінити **стандартних**.

Якщо ви бажаєте використовувати типовий ASF вхід без будь-яких модифікацій, не потрібно робити нічого - не потрібно визначати в користувацькому `NLog. конфігурація`. Однак, для посилання еквівалентного складному протоколу ASF за замовчуванням буде бути:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir:cached=true}/logs/log.txt" archiveOldFileOnStartup="true" archiveSuffixFormat=".{1:yyyyMMdd-HHmmss}" fileName="${currentdir:cached=true}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- Below becomes active when ASF's IPC interface is started -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="File" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- Below becomes active when ASF's IPC interface is enabled -->
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="History" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## Інтеграція ASF

ASF має декілька гарних хитрощів з коду, які прискорюють інтеграцію за допомогою NLog, що дозволяє вам легше ловити конкретні повідомлення.

NLog-specific `${logger}` variable will always distinguish the source of the message - it will be either `BotName` of one of your bots, or `ASF` if message comes from ASF process directly. Таким чином, ви можете легко спіймати повідомлення, які розглядають конкретних ботів(ів), або процес ASF (тільки), замість усіх їх, на основі назви логгера.

ASF намагається позначити повідомлення належним чином, на основі NLog-наданих рівнів журналу, що дає можливість ловити тільки конкретні повідомлення з певних рівнів журналу, а не всі з них. Звичайно, журналювання рівня конкретного повідомлення не може бути змінено, так як це складне рішення наскільки серйозним є дане повідомлення, але ви безумовно можете зробити ASF менше/більш мовчазним, коли ви бачите вміст.

ASF logs extra info, such as user/chat messages on `Trace` logging level. Журнал ASF за замовчуванням лише `Налагодження` рівня та вище, що приховує цю додаткову інформацію, оскільки це не потрібно для більшості користувачів, а також для депутатів вихід, що містять потенційно важливіші повідомлення. You can however make use of that information by re-enabling `Trace` logging level, especially in combination with logging only one specific bot of your choice, with particular event you're interested in.

In general, ASF tries to make it as easy and convenient for you as possible, to log only messages you want instead of forcing you to manually filter it through third-party tools such as `grep` and alike. Просто налаштуйте NLog належним чином, як написано нижче, і ви зможете вказати навіть дуже складні правила ведення логів за допомогою користувацьких цілей, таких як вся база даних.

Regarding versioning - ASF tries to always ship with most up-to-date version of NLog that is available on **[NuGet](https://www.nuget.org/packages/NLog)** at the time of ASF release. Це не повинно бути проблемою для використання будь-якої функції, яку ви можете знайти на NLog wiki у ASF - переконайтеся, що ви також використовуєте найсучасніший ASF.

Як частина інтеграції ASF також включає підтримку для додаткових цільових подій у журналі ASF, які будуть пояснені нижче.

---

## Приклади

Наприклад: наведено нижче як ви можете налаштувати логування відповідно до ваших вподобань.

Як початківець використаємо **[Ціль ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)** тільки цільової </strong>. Початковий `NLog.config` виглядатиме так:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Пояснення над конфігурацією є досить простим - ми визначимо одну **місце для журналювання**, що є `ColoredConsole`тоді ми перенаправляємо **усіх журналів** (`*`) рівня `Debug` та вище вказаної в `ColoredConsole` цілі, яку ми визначили раніше.

Якщо ви запускаєте ASF вище `NLog. конфігурація` зараз ціль `ColoredConsole` буде активна, і ASF не буде писати в `файл`, незважаючи на запрограмовану конфігурацію NLog ASF.

Since we didn't define a lot of properties, such as `layout`, it was initialized to a default built-in value, in this case `${longdate}|${level:uppercase=true}|${logger}|${message}`. Ми можемо налаштувати, наприклад, лише для журналювання:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Якщо ви запустите ASF зараз, ви помітите цю дату, ім'я рівня і logger зникло - залишивши лише повідомлення ASF у форматі `Повідомлення Function()`.

Ми також можемо змінити налаштування на запис у більш ніж одній цілі. Let's log to `ColoredConsole` and **[`File`](https://github.com/nlog/nlog/wiki/File-target)** at the same time.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Debug" writeTo="File" />
  </rules>
</nlog>
```

And done, we'll now log everything to `ColoredConsole` and `File`. Чи ви помітили, що також можете вказати користувацьке `fileName` та додаткові параметри?

Нарешті, ASF використовує різні рівні журналу, щоб полегшити вам розуміння того, що відбувається. Ми можемо використати цю інформацію для зміни логи тяжкості. Let's say that we want to log everything (`Trace`) to `File`, but only `Warning` and above **[log level](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** to the `ColoredConsole`. We can achieve that by modifying our `rules`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Warn" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Trace" writeTo="File" />
  </rules>
</nlog>
```

Тепер наша `ColoredConsole` буде відображати лише попередження і вище, і при цьому реєструвати все в `File`. Далі ви можете налаштувати його для журналу, наприклад тільки `Info` і т. д.

Останнє, давайте зробимо щось трохи складніше і зафіксувати всі повідомлення до файлу, але тільки від бота з ім'ям `LogBot`.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="LogBotFile" fileName="${currentdir:cached=true}/LogBot.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="LogBot" minlevel="Trace" writeTo="LogBotFile" />
  </rules>
</nlog>
```

Ви можете побачити як ми використали інтеграцію ASF вище та краще уточнити джерело повідомлення на основі властивостей `${logger}`.

---

## Розширене використання

Перевищені приклади є досить простими і щоб показати вам, як легко визначити власні правила ведення журналу, які можуть бути використані з ASF. You can use NLog for various different things, including complex targets (such as keeping logs in `Database`), logs rotation (such as removing old `File` logs), using custom `Layout`s, declaring your own `<when>` logging filters and much more. Я закликаю вас прочитати увесь **[NLog documentation](https://github.com/nlog/nlog/wiki/Configuration-file)** щоб дізнатися про кожен варіант, доступний для Вас, дозволяє детально налаштовувати модуль входу ASF у той час, коли ви бажаєте. Це дійсно потужний інструмент і налаштування журналу ASF ніколи не було простішим.

---

## Обмеження

ASF will temporarily disable **all** rules that include `ColoredConsole` or `Console` targets when expecting user input. Таким чином, якщо ви хочете тримати журналом для інших цілей, навіть якщо ASF очікує на вхід користувача, вам слід визначити ці цілі із їх власними правилами, як показано на прикладах вище, замість того, щоб вводити багато цілей в `написати` подібного правила (якщо це не ваша бажана поведінка). Виконується тимчасове відключення цілей на консоль, щоб підтримувати очищення консолі при очікуванні на вводі користувача.

---

## Логування чату

ASF includes extended support for chat logging by not only recording all received/sent messages on `Trace` logging level, but also exposing extra info related to them in **[event properties](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Це тому, що нам потрібно обробляти повідомлення в чаті як команди, так що нам нічого не коштуватиме логувати ці події, щоб зробити можливим для вас додати додаткову логіку (наприклад, щоб ASF ваш особистий архів для спілкування у Steam).

### Властивості події

| Ім'я         | Опис                                                                                                                                                                                                                              |
| ------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Луна         | `тип bool`. This is set to `true` when message is being sent from us to the recipient, and `false` otherwise.                                                                                                                     |
| Повідомлення | `рядок` тип. Це справжнє речення/отримане повідомлення.                                                                                                                                                                           |
| ID чат-групи | `ulong` type. Це ID групового чату для надіслань/отриманих повідомлень. Will be `0` when no group chat is used for transmitting this message.                                                                                     |
| ID чата      | `ulong` type. Це ID `ChatGroupID` каналу для речень/отриманих повідомлень. Will be `0` when no group chat is used for transmitting this message.                                                                                  |
| Steam ID     | `ulong` type. Це ідентифікатор користувача Steam для відправлення/отриманих повідомлень. Може бути `0` , коли жоден користувач не підключений до передачі повідомлень (e. . коли ми відправляємо повідомлення до групового чату). |

### Приклад

Цей приклад базується на нашому `ColoredConsole` базовому прикладі вище. Before trying to understand it, I strongly recommend to take a look **[above](#examples)** in order to learn about basics of NLog logging firstly.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="ChatLogFile" fileName="${currentdir:cached=true}/logs/chat/${event-properties:item=ChatGroupID}-${event-properties:item=ChatID}${when:when='${event-properties:item=ChatGroupID}' == 0:inner=-${event-properties:item=SteamID}}.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss} ${event-properties:item=Message} ${when:when='${event-properties:item=Echo}' == true:inner=-&gt;:else=&lt;-} ${event-properties:item=SteamID}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="MainAccount" level="Trace" writeTo="ChatLogFile">
      <filters defaultAction="Log">
        <when condition="not starts-with('${message}','OnIncoming') and not starts-with('${message}','SendMessage')" action="Ignore" />
      </filters>
    </logger>
  </rules>
</nlog>
```

Ми почали з нашого базового `ColoredConsole` та продовжили його далі. Перше і найголовніше, ми підготували постійний файл журналу для кожного групового каналу та користувача Steam, це можна завдяки додатковим властивостям, які ASF наражає нас якимось чином. Ми також вирішили перейти до користувальницької карти, яка записує лише поточну дату, повідомлення, відправлення/отримання інформації і самого користувача Steam. Lastly, we've enabled our chat logging rule only for `Trace` level, only for our `MainAccount` bot and only for functions related to chat logging (`OnIncoming*` which is used for receiving messages and echos, and `SendMessage*` for ASF messages sending).

Приклад вище згенерує `логи/chat/0-76561198069026042.txt` при розмові з **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 як ти це робиш? -> 76561198069026042
2018-07-26 01:38:38 Я займаюся гарним, як щодо тебе? <- 76561198069026042
```

Звичайно, це лише робочий приклад з кількома хитрощами на графіку, показаними практично. Ви можете розширити цю ідею до своїх власних потреб, таких як додаткові фільтрації, власний порядок, персональний макет, фіксувати тільки отримані повідомлення і так далі.

### Інший приклад

This one uses `SteamTarget` in order to send a message to the main bot's steamID (`76561198006963719`) when bot named `archi` receives a donation trade. Вимагає іншого бота в процесі (оскільки ви не можете відправляти повідомлення самому собі).

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" />
  </targets>

  <rules>
    <logger name="archi" level="Trace" writeTo="Steam">
      <filters defaultAction="Ignore">
        <when condition="starts-with('${message}','ParseTrade() Accepted donation trade: ')" action="Log" />
      </filters>
    </logger>
  </rules>
</nlog>
```

---

## ASF цілі

In addition to standard NLog logging targets (such as `ColoredConsole` and `File` explained above), you can also use custom ASF logging targets.

Для досягнення максимального доповнення, визначення цілей ASF буде відповідати умові документації по NLog

---

### SteamЦіль

Як ви можете здогадатися, ця мета використовує чат-повідомлення для логування повідомлень ASF. Можна налаштувати його на використання групового чату або приватного чату. На додаток до визначення цілі пар ваших повідомлень, ви також можете вказати `botName` бота, який повинен надіслати їх.

Підтримується у всіх середовищах, що використовуються ASF.

---

#### Синтаксис конфігурації
```xml
<targets>
  <target type="Steam"
          name="String"
          layout="Layout"
          chatGroupID="Ulong"
          steamID="Ulong"
          botName="Layout" />
</targets>
```

Read more about using the [Configuration File](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Параметри

##### Загальні налаштування
_name_ - Name of the target.

---

##### Налаштування зовнішнього вигляду
_layout_ - Text to be rendered. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Required. За замовчуванням: `${level:uppercase=true}|${logger}|${message}`

---

##### Параметри SteamTarget

_chatGroupID_ - ID групи, оголошеної як 64-бітне ціле число без знаку. Не потрібно. Defaults to `0` which will disable group chat functionality and use private chat instead. When enabled (set to non-zero value), `steamID` property below acts as `chatID` and specifies ID of the channel in this `chatGroupID` that the bot should send messages to.

_steamID_ - SteamID declared as 64-bit long unsigned integer of target Steam user (like `SteamOwnerID`), or target `chatID` (when `chatGroupID` is set). Обов'язково. За замовчуванням `0` , яка повністю вимикає журналювання цілі.

_botName_ - Ім'я бота (як він визнаний ASF, чутливим до регістру), яке буде відправляти повідомлення в `steamID` оголошене вище. Не потрібно. За замовчуванням `null` , яка буде автоматично вибирати **будь-які** підключені боти. It's recommended to set this value appropriately, as `SteamTarget` does not take into account many Steam limitations, such as the fact that you must have `steamID` of the target on your friendlist. This variable is defined as [layout](https://github.com/NLog/NLog/wiki/Layouts) type, therefore you can use special syntax in it, such as `${logger}` in order to use the bot that generated the message.

---

#### Приклади SteamTarget

In order to write all messages of `Debug` level and above, from bot named `MyBot` to steamID of `76561198006963719`, you should use `NLog.config` similar to below:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**Notice:** Our `SteamTarget` is custom target, so you should make sure that you're declaring it as `type="Steam"`, NOT `xsi:type="Steam"`, as xsi is reserved for official targets supported by NLog.

Коли ви запускаєте ASF з `NLog. налаштування` подібне до вище, `MyBot` почне надсилати повідомлення `76561198006963719` користувач Steam з усіма звичайними повідомленнями у журналі ASF. Пам'ятайте, що `MyBot` повинен бути підключений для того, щоб надсилати повідомлення, тепер усі початкові повідомлення ASF, які відбулися до того, як наш бот міг підключатися до мережі Steam, не буде переслано.

Звичайно, `SteamTarget` має усі типові функції, які ви можете очікувати від універсального `TargetWithLayout`тому ви можете використати його в поєднанні з e. . користувацькі макети, імена або розширені правила журналювання. Приклад вище - лише найголовніший.

---

#### Скріншоти

![Знімок екрану](https://i.imgur.com/5juKHMt.png)

---

#### Застереження

Будьте обережні коли ви вирішили поєднати `Debug` рівень логування чи нижче у Вашому `SteamTarget` з `steamID` , який займає участь у процесі ASF. Це може призвести до потенційного `StackOverflowException` , тому що ви створите нескінченний цикл ASF що приймає повідомлення, потім журналювання через Steam, в результаті чого необхідно увійти в систему. Currently the only possibility for it to happen is to log `Trace` level (where ASF records its own chat messages), or `Debug` level while also running ASF in `Debug` mode (where ASF records all Steam packets).

Коротше кажучи, якщо ваше `steamID` приймає участь у одному процесі ASF, потім `minlevel` журналювання вашого `SteamTarget` має бути `Інформація` (або `Debug` , якщо ви також не використовуєте ASF в `Debug` режим) або вище. Alternatively you can define your own `<when>` logging filters in order to avoid infinite logging loop, if modifying level is not appropriate for your case. Це застереження застосовується також до групових чатів.

---

### HistoryTarget

This target is used internally by ASF for providing fixed-size logging history in `/Api/NLog` endpoint of **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** that can be afterwards consumed by ASF-ui and other tools. Загалом, ви повинні визначити цю ціль лише у тому випадку, якщо ви вже використовуєте конфігурацію NLog для інших налаштувань, а також ви хочете, щоб журнал був викритий у API, ASF. . для ASF-ui. It can also be declared when you'd want to modify default layout or `maxCount` of saved messages.

Підтримується у всіх середовищах, що використовуються ASF.

---

#### Синтаксис конфігурації
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Read more about using the [Configuration File](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Параметри

##### Загальні налаштування
_name_ - Name of the target.

---

##### Налаштування зовнішнього вигляду
_layout_ - Text to be rendered. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Required. Default: `${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### Параметри призначення історії

_maxCount_ - Максимальна кількість збережених журналів історії на вимогу. Не потрібно. За замовчуванням `20` , який є хорошим балансом для забезпечення історії, пам'ятаючи все ще про використання пам'яті, що вичерпається за потребами для зберігання. Must be greater than `0`.