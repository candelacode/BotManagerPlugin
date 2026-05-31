# Налаштування з низьким споживанням пам'яті

This is exact opposite of **[high-performance setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup)** and typically you want to follow those tips if you want to decrease ASF's memory usage, for cost of lowering overall performance.

---

ASF за визначенням надзвичайно легкий виразний ресурс, в залежності від вашого використання навіть 128 Мб VPS для Linux здатен його запустити, хоча не рекомендується використовувати цю низьку швидкість і не може призвести до різних проблем. Під час світла, ASF не боїться запитувати OS більше пам'яті, якщо потрібна така пам'ять, щоб ASF працював оптимальною швидкістю.

ASF як програма намагається бути максимально оптимізованою та ефективною як це можливо, яка також запам'ятовує ресурси під час виконання програми. Коли мова йде про пам'ять, ASF надає перевагу продуктивності над споживанням пам'яті, що може призвести до тимчасової пам'яті "імпульсів", поміченого, наприклад, з рахунками які мають посилання на 3+ значки, оскільки ASF буде витягувати та аналізувати першу сторінку, прочитану з неї кількість сторінок, потім запустіть процедуру отримання завдання для кожної з додаткових сторінок, що призводить до збору та аналізу сторінок. Це "видатно" використання пам'яті (порівняно з мінімальним мінімумом для операції) може різко прискорити процес виконання та загальну ефективність, для збільшення вартості використання пам'яті, необхідно провести паралельні всі ці дії. Подібні речі відбуваються з іншими основними завданнями ASF, які можуть бути виконані паралельно, наприклад, при розборі активних пропозицій обміну, ASF може проаналізувати їх усі відразу, оскільки вони незалежні один від одного. On top of that, ASF (C# runtime) will **not** return unused memory back to OS immediately afterwards, which you can quickly notice in form of ASF process only taking more and more memory, but (almost) never giving that memory back to the OS. Деякі люди вже можуть вважати це сумнівним, можливо навіть підозрюваним витоку пам'яті, але не хвилюйтесь, все це слід очікувати.

ASF надзвичайно добре оптимізовано, та використовує доступні ресурси якомога більше. High memory usage of ASF doesn't mean that ASF actively **uses** that memory and **needs it**. Дуже часто ASF буде зберігати виділену пам'ять як "кімнату" для майбутніх дій, оскільки ми можемо значно підвищити продуктивність, якщо нам не потрібно запитувати ОС для кожного фрагменту пам'яті, який ми збираємося використовувати. The runtime should automatically release unused ASF memory back to OS when OS will **truly** need it. **[Unused memory is wasted memory](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. You run into issues when the memory you **need** is higher than the memory that is available for you, not when ASF keeps some extra allocated with purpose of speeding up functions that will execute in a moment. Ви зіткнулися з проблемами, коли ядро Linux закінчується процесом ASF через OOM (поза пам'яті), не тоді, коли ви бачите процес ASF як найпопулярніший споживач пам'яті в `htop`.

**[колекція сміття](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** процес, який використовується в ASF це дуже складний механізм, досить розумно, щоб зобразити не тільки ASF себе, а й ОС та інші процеси. Коли у вас є багато безкоштовної пам'яті, ASF буде запитувати у будь-якому випадку, щоб підвищити продуктивність. Це може бути навіть так само, як 1 GB (з сервером GC). Коли ваша ОС пам'ять буде закрита до повного заряду, ASF автоматично випустить деякі з них до ОС, щоб допомогти у справах нестабільності, який може спричинити загальне використання пам'яті ASF до 50 МБ. Різниця між 50 МБ до 1 ГБ величезна, але це різниця між невеликою 512 МБ ВП та величезним виділеним сервером із 32 ГБ. Якщо ASF може гарантувати, що ця пам'ять буде корисною, і одночасно її більше не потрібно тут, Це віддасть перевагу тримати його і автоматично оптимізувати себе на основі процедур, які були страчені в минулому. GC, що використовується в ASF є самостійним налаштуванням і буде досягати кращих результатів, коли процес запуститься.

This is also why ASF process memory varies from setup to setup, as ASF will do its best to use available resources in **as efficient way as possible**, and not in a fixed way like it was done during Windows XP times. The actual (real) memory usage that ASF is using can be verified with `stats` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, and is usually around 4 MB for just a few bots, up to 30 MB if you use stuff like **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** and other advanced features. Keep in mind that memory returned by `stats` command also includes free memory that hasn't been reclaimed by garbage collector yet. Усе інше поділене оперативною пам'яттю (близько 40-50 МБ) та місця для виконання (різне). Ось чому той самий ASF може використовувати як 50 МБ у середовищі слабкої пам'яті, навіть по 1 Гб на вашому робочому столі. ASF активно адаптується до вашого середовища і намагатиметься знайти оптимальний баланс для того, щоб не класти вашу ОС під тиском, не обмежує продуктивність, коли у вас буде багато невикористаної пам'яті, що може бути використана.

---

Звичайно, Є багато шляхів яким ви можете допомогти направляти ASF у правильному напрямку спогаду, який ви очікуєте використовувати. Загалом, якщо вам не потрібно цього робити, найкраще дозволити збиранню сміття працювати у мирі і робити все, що в них найкраще. Але це не завжди можливо, наприклад, якщо ваш сервер Linux також розміщує кілька веб-сайтів, MySQL баз даних і PHP workers, після цього ви не можете дозволити собі ASF скорочуватися, коли ви наближаєтеся до OOM, бо деградація продуктивності зазвичай стається швидше. Це, як правило, коли ви можете зацікавитися подальшим налаштуванням, і тому читати цю сторінку.

Нижче пропозицій поділяються на кілька категорій з різними труднощами.

---

## Налаштування ASF (легко)

Below tricks **do not affect performance negatively** and can be safely applied to all setups.

- Запустіть **[загальну версію](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** з ASF, якщо це можливо. Загальна версія ASF використовує менше пам'яті, оскільки вона не включає runtime всередині, не зайшла як окремий файл, не потрібно розпаковувати себе на запуску, а тому це менше і має менший об'єм пам'яті. Для конкретної ОС пакети зручні і зручні, але вони також об'єднуються з усіма необхідними для запуску ASF, це щось, про що ви можете потурбуватися та замість цього використовувати варіант ASF.
- Ніколи не запускати більше ніж один екземпляр ASF. ASF is meant to handle unlimited number of bots all at once, and unless you're binding every ASF instance to different interface/IP address, you should have exactly **one** ASF process, with multiple bots (if needed).
- Використовувати `ShutdownOnFarmingЗавершено` в `FarmingPreferences`. Активний бот бере більше ресурсів, ніж деактивований. Це не істотний збереження, тому що стан бота все ще повинен зберігатися, але ви зберігаєте деякі ресурси, особливо всі ресурси, пов'язані з мережею, наприклад TCP сокети. Ви завжди можете знайти інших ботів, якщо потрібно.
- Тримайте ваші боти за числом низьким. Not `Enabled` bot instance takes less resources, as ASF doesn't bother starting it. Also keep in mind that ASF has to create a bot for each of your configs, therefore if you don't need to `start` given bot and you want to save some extra memory, you can temporarily rename `Bot.json` to e.g. `Bot.json.bak` in order to avoid creating state for your disabled bot instance in ASF. This way you won't be able to `start` it without renaming it back, but ASF also won't bother keeping state of this bot in memory, leaving room for other things (very small save, in 99.9% cases you shouldn't bother with it, just keep your bots with `Enabled` of `false`).
- Точно налаштовуйте свої конфігурації. Особливо глобальний конфігурація ASF має багато змінних для коригування, наприклад, збільшивши `LoginLimiterDelay` ви отримаєте повільніше за ботів, яке дозволить ім'я вже почав отримувати значки тим часом, на відміну від залучення вашого бота швидше, який буде зайняти більше ресурсів, як більше ботів зробить велику роботу (наприклад, парсингові значки) одночасно. Чим менше роботи потрібно виконати в той же час - тим менше використовувати пам'ять.

Це те, про що ви можете пам'ятати, коли відбувається використання пам'яті. Проте, ці речі не мають "хрестоні" матерії в використанні пам'яті, так як використання пам'яті походить із речей, з якими ASF має справлятися, а не з внутрішніх структур, які використовуються для фармуху.

Найбільш потужні функції:
- Розбір сторінки зі значками
- Аналіз інвентарю

Це означає, що пам'ять більше коливається коли ASF має справу з сторінками для читання значків, а коли він має справу з інвентарем (наприклад e. . відправлення угоди або робота з STM ). Це тому, що ASF має мати справу з великою кількістю даних - використання улюбленого браузера, яке запускає ці дві сторінки, буде не нижчим. На жаль, так воно працює, зменшення кількості сторінок зі значками, і кількість елементів інвентарю зменшується, а це може бути впевнено у цьому.

---

## Налаштування Runtime (розширені)

Below tricks **involve performance degradation** and should be used with caution.

The recommended way of applying those settings is through `DOTNET_` environment properties. Of course, you could also use other methods, e.g. `runtimeconfig.json`, but some settings are impossible to be set this way, and on top of that ASF will replace your custom `runtimeconfig.json` with its own on the next update, therefore we recommend environment properties that you can set easily prior to launching the process.

.NET runtime allows you to **[tweak garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** in a lot of ways, effectively fine-tuning the GC process according to your needs. Ми задокументовані нижче властивостей, що особливо важливі для нашої думки.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Визначає допустиме використання динамічної пам'яті у відсотках від загальної фізичної пам'яті.

Кількість "жорстких" пам'яті для процесу ASF, це налаштування налаштовує GC на використання лише підмножину загальної пам'яті і не все це. Це може стати особливо корисним в різних ситуаціях, що схожі на сервер, де ви можете присвятити фіксований відсоток пам'яті вашого сервера для ASF, але ніколи не більше. Рекомендовано підправити обмеження пам'яті для використання ASF не буде магічним чином робити всі ці необхідні алокації пам'яті зникають, Тому встановити це значення занадто мале може призвести до того, що процес ASF завершиться поза сценаріями в пам'яті.

З іншої сторони, налаштування цього значення достатньо високе для ідеального способу переконатися, що ASF ніколи не буде використовувати більше пам'яті, ніж ви можете реально собі дозволити, даючи вашій машині дихальній кімнаті навіть під великим завантаженням, все ще дозволяючи програмі робити свою роботу якомога ефективніше.

### [`GCConserveMemory`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Налаштовує збирач непотрібних даних для збереження пам'яті за рахунок складніших колекцій непотрібних даних і, можливо, довше паузи часу.

Можна використовувати значення 0-9. Чим більше значення, тим більше GC буде оптимізувати пам'ять для збільшення продуктивності.

### [`Відсоток пам'яті GCHighMemcent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Визначає кількість пам'яті, яку використовує GC стає більш агресивним.

Цей параметр налаштовує поріг пам'яті всього ОС, яка після проходження, Через те, що GC стає більш агресивним і спробує допомогти ОС зменшити навантаження на пам'ять, запустивши більш інтенсивний процес GC, що призводить до збільшення вільної пам'яті в ОС. Варто встановити цю властивість на максимальну кількість пам'яті (у відсотках), яку ви вважаєте "критичною" за продукцію вашої ОС. За замовчуванням 90%, і, як правило, ви хочете зберегти її в діапазоні 80-97%, занадто низьке значення призведе до непотрібної агресії GC та погіршення продуктивності без причини, поки занадто високе значення приведе до непотрібного завантаження на вашу ОС, розглядаючи можливість ASF випустити частину своєї пам'яті для допомоги.

### **[`Клатенсівел`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Визначає рівень затримки GC, який потрібно оптимізувати.

Це недокументована власність, яка виявилася винятково хорошою для ASF, Обмежуючи розмір поколінь GC і в результаті змушуючи GC чистити їх швидше і більш агресивно. Default (balanced) latency level is `1`, but you can use `0`, which will tune for memory usage.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> Коли ми ставимо цей простір більш агресивно для ефемерної затоки. Використовується для використання багатьох випадків серверних процесів, де вони хочуть зберегти якомога більше пам'яті.

Це пропонує небагато покращень, але може зробити ГК ще більш агресивним, коли система буде низькою в пам'яті, особливо для ASF, який значно використовує завдання threadpool завдань.

---

Ви можете увімкнути обрані властивості, встановивши відповідні змінні середовища. Наприклад, на Linux (shell):

```shell
# Don't forget to tune those if you're planning to make use of them
export DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
export DOTNET_GCHighMemPercent=0x50 # 80% as hex

export DOTNET_GCConserveMemory=9
export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

Або на Windows (powershell):

```powershell
# Don't forget to tune those if you're planning to make use of them
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80% as hex

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

Особливо `GCLatencyLevel` буде дуже корисним, оскільки ми підтвердили, що середовище роботи дійсно оптимізує код пам'яті і тому значно скидає середній обсяг використання пам'яті навіть з сервером GC. It's one of the best tricks that you can apply if you want to significantly lower ASF memory usage while not degrading performance too much with `OptimizationMode`.

---

## Налаштування ASF (проміжний)

Below tricks **involve serious performance degradation** and should be used with caution.

- As a last resort, you can tune ASF for `MinMemoryUsage` through `OptimizationMode` **[global config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**. Читайте ретельно його мету, оскільки це серйозна деградація продуктивності для майже не користі пам'яті. This is typically **the last thing you want to do**, long after you go through **[runtime tuning](#runtime-tuning-advanced)** to ensure that you're forced to do this. Якщо для ваших налаштувань не є абсолютно критичним, ми відмовляємося використовувати `MinMemoryUsage`навіть у обмеженому пам'яті.

---

## Рекомендована оптимізація

- Почати із простих хитрощів налаштування ASF, використовуй **[загальний варіант ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** і перевірте, чи ви просто користуєтеся ASF неправильним способом, як запуск процесу декілько разів для усіх ваших ботів, або тримати всі активні додатки, якщо вам потрібно лише один або два для автозапуску.
- If it's still not enough, enable all configuration properties listed above by setting appropriate `DOTNET_` environment variables. Особливо, що `GCLatencyLevel` пропонує значні покращення робочого часу для невеликих витрат на продуктивність.
- Якщо навіть це не допомогло, в якості останнього скасування увімкніть `MinMemoryUsage` `оптимізаційний режим`. Це змушує ASF виконувати майже все у синхронному матерії, що працює набагато повільніше, але також не покладатися на пул потоку, щоб збалансувати речі, коли йдеться про паралельне виконання.

Зіткнення пам'яті фізично неможливе, навіть далі, ваш ASF вже погіршується з огляду на продуктивність і ви виснажили всі можливості, обидва code-wise та runtime-wise. Нагадайте, якщо вам потрібно додати трохи додаткової пам'яті для ASF, навіть 128 МБ зробили б велику різницю.