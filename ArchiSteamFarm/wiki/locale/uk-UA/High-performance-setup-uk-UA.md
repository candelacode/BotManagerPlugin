# Налаштування високої продуктивності

Це зовсім протилежне від **[налаштування низької пам'яті](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** і зазвичай ви хочете дотримуватися цих порад, якщо ви бажаєте підвищити продуктивність ASF (у значенні швидкості процесору), для потенційної вартості збільшеного використання пам'яті.

---

ASF уже бажає надати перевагу продуктивності якщо йдеться про загальне збалансоване налаштування, Отже, ви не можете зробити багато щоб збільшити його ефективність, хоча й не цілком у вас є варіанти розвитку. Але майте на увазі, що ці параметри не включені за замовчуванням, а це означає, що вони недостатньо здібні, щоб врівноважувати їх більшість використання. Тому ви повинні вирішити себе, якщо зростаюча пам'ять і є прийнятним для вас.

---

## Налаштування Runtime (розширені)

Below tricks **involve serious memory increase** and should therefore be used with caution.

The recommended way of applying those settings is through `DOTNET_` environment properties. Of course, you could also use other methods, e.g. `runtimeconfig.json`, but some settings are impossible to be set this way, and on top of that ASF will replace your custom `runtimeconfig.json` with its own on the next update, therefore we recommend environment properties that you can set easily prior to launching the process.

.NET runtime allows you to **[tweak garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** in a lot of ways, effectively fine-tuning the GC process according to your needs. Ми задокументовані нижче властивостей, що особливо важливі для нашої думки.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Налаштовує, чи використовує додаток збір непотрібних станцій або збір непотрібних даних.

You can read the exact specific of the server GC at **[fundamentals of garbage collection](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF використовує колекцію сміття для робочих станцій за замовчуванням. Це головним чином через відчутний баланс між використанням та виконанням пам'яті, який більш ніж достатньо для всього кількох ботів, як зазвичай використовується окремий паралельний фоновий потік GC досить швидко, щоб обробляти всю пам'ять, що виділена ASF.

Але сьогодні ми маємо багато ядер процесора, з яких ASF може отримати значно більше користі, маючи виділену тему GC на кожен ЦП, яка доступна. Це може значно поліпшити продуктивність під час важких завдань ASF, таких як синтаксичний значок сторінок або інвентар, оскільки кожен ЦП може допомогти, на відміну від всього 2 (головний і GC). Сервер GC рекомендується для машин 3 ядер на ЦП і більше, робота GC автоматично змушена, якщо Ваш комп'ютер має тільки 1 ЦП vCore, і якщо ви маєте рівно 2, то можете розглянути можливість того, що обидва спроби (результати можуть змінюватися).

Саме сервер GC не призводить до дуже великого зростання пам'яті просто за рахунок активності, але він має набагато більші розміри генерації, і тому набагато лінивіші, коли справа доходить до повернення пам'яті до ОС. Ви можете опинитися в "солодкому місці", де GC значно підвищує продуктивність, і ви б хотіли його використовувати, але водночас ви не можете собі дозволити, що велике збільшення пам'яті вже не використовується. Luckily for you, there is a "best of both worlds" setting, by using server GC with **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** configuration property set to `0`, which will still enable server GC, but limit generation sizes and focus more on memory. Alternatively, you might also experiment with another property, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**, or even both of them at the same time.

Однак, якщо пам'ять не є проблемою для вас (як GC все ще враховує вашу доступну пам'ять і налаштовує себе), набагато краще - не змінювати ці властивості взагалі, досягати кращого в результаті.

---

Ви можете увімкнути обрані властивості, встановивши відповідні змінні середовища. Наприклад, на Linux (shell):

```shell
export DOTNET_gcServer=1

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

Або на Windows (powershell):

```powershell
$Env:DOTNET_gcServer=1

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

---

## Рекомендована оптимізація

- Ensure that you're using default value of `OptimizationMode` which is `MaxPerformance`. This is by far the most important setting, as using `MinMemoryUsage` value has dramatic effects on performance.
- Увімкнути GC. Сервер GC можна негайно розглядати як активний через значне збільшення пам'яті порівняно з GC. Це призведе до створення потоку GC для кожного потокового процесора, який ваш комп'ютер має для виконання GC операцій паралельно з максимальною швидкістю.
- If you can't afford memory increase due to server GC, consider tweaking **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** and/or **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** to achieve "the best of both worlds". Однак, якщо ваша пам'ять може собі це дозволити, потім, краще тримати його за замовчуванням - сервер GC вже налаштований під час роботи і є досить розумним, щоб використовувати менше пам'яті, коли ваша ОС буде справді потребувати його.

Застосування рекомендацій вище дозволяє підвищувати продуктивність ASF, що має запускатися швидко навіть у сотнях або тисячах увімкнених ботів. При потребі ЦП не має бути місцем вузького процесора, тому що ASF може використовувати все необхідне переривання часу для мінімального нуля. Наступним кроком буде оновлення ЦП та ОЗУ або розділення робочого навантаження на декілька серверів і екземплярів ASF.