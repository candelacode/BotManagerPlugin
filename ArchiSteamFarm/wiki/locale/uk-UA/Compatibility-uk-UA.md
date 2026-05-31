# Сумісність

ASF це C# застосунок, що працює на .NET платформі. Це означає, що ASF не скомпілюється прямо в **[машинний код](https://en.wikipedia.org/wiki/Machine_code)** який працює на вашому ядра, але в **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)** який вимагає CIL-сумісний runtime для його виконання.

Такий підхід має гігантський обсяг переваг, так як CIL є незалежним від платформи, саме тому ASF може натично працювати на багатьох доступних ОС, особливо на Windows, Linux та macOS. Не тільки потрібна емуляція, але й підтримує всі пов'язані з платформами та оптимізації, пов'язані з обладнанням, такі як команди ЦП. Завдяки цьому, ASF може отримати кращу продуктивність та оптимізацію, при наявності ідеальної сумісності та надійності.

Це також означає, що ASF має **без конкретних вимог ОС**, оскільки це вимагає роботи **runtime** на цій ОС і не саму ОС. As long as that runtime is executing ASF code properly, it does not matter whether underlying OS is Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii or your toaster - as long as there is **[.NET for it](https://dotnet.microsoft.com/download/dotnet)**, there is **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** for it (in `generic` variant).

Однак, незалежно від того, куди ви запускаєте ASF, ви повинні переконатися, що ваша цільова платформа має **[.NET prerequisites](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** встановлена. Це низькорівневі бібліотеки, які потрібні для належної функціональності середовища виконання і абсолютно базової роботи ASF для першої роботи. Ймовірно, що у вас вже є деякі з них (або навіть всі) встановлені.

---

## Пакет ASF

ASF поставляється на 2 основні смаки - звичайний пакет та конкретна ОС. Обидва пакунки є однаковими. Вони можуть самостійно оновлюватись. The only difference between them is whether or not ASF **generic** package also comes with **OS-specific** runtime to power it.

---

### Загальні

Загальний пакунок це платформа-агностична конструкція, яка не містить будь-який специфічний для техніки. This setup requires from you to have .NET runtime already installed on your OS **in appropriate version**. We all know how troublesome it is to keep dependencies up-to-date, therefore this package is here mainly for people that **already use** .NET and don't want to duplicate their runtime solely for ASF if they can make use of what they have installed already. Generic package also allows you to run ASF **anywhere, as long as you can obtain working implementation of .NET runtime**, regardless if there exists OS-specific ASF build for it, or not.

Рекомендується використовувати загальні flavour якщо ви випадкові або навіть розширений користувач, який просто хоче змусити ASF працювати без помилок у . Технічні деталі ET. Іншими словами, якщо ви знаєте, що це таке, ви можете ним скористатися, інакше краще використовувати пакет для конкретної ОС, пояснений нижче.

---

### конкретна ОС

Додаток для конкретної ОС, крім коду керованого в загальних пакетах, також включає вбудований код для даної платформи. Іншими словами, пакет **для ОС вже включає у себе вірні дані. ET runtime всередині**, який дозволяє повністю пропустити весь безлад встановлення і просто запустити ASF. ОС пакет, який ви можете вгадати з назви, це конкретна ОС OS, і кожна ОС потребує своєї власної версії - наприклад Windows потребує ПЕ32+ `Архів SteamFarm. xe` бінарний файл Linux працює з Unix ELF `ArchiSteamFarm` binary. Як ви знаєте, ці два типи не сумісні один з одним.

ASF наразі доступний в наступних варіаціях для конкретної ОС:

- `linux-arm` працює на 32-розрядному базі ARMS (ARMv7+) GNU/Linux ОС з glibc 2.35/musl 1.2.3 і новішими. This variant covers platforms such as Raspberry Pi 2 (and newer), it will **not** work with older ARM architectures, such as ARMv6 found in Raspberry Pi 0 & 1, it will also not work with OSes that do not implement required GNU/Linux environment (such as Android).
- `linux-arm64` працює на базі 64-бітних ARMS (ARMv8+) GNU/Linux OSes з glibc 2.27/musl 1.2.2.3 і новіше. This variant covers platforms such as Raspberry Pi 3 (and newer), it will **not** work with 32-bit OSes that do not have required 64-bit libraries available (such as 32-bit Raspberry Pi OS), it will also not work with OSes that do not implement required GNU/Linux environment (such as Android).
- `linux-x64` працює на 64-bit GNU/Linux OSes з glibc 2.27/musl 1.2.2.3 і новіше.
- `osx-arm64` працює на базі 64-бітних ARMA (Apple silicon) macOS OSes у версії 13 і новішій версії.
- `osx-x64` працює на 64-розрядній macOS ОС у версії 15 та новішій версії.
- `win-arm64` працює **найновішою версією** 64-розрядною ARM (ARMv8+) ОС Windows у версії 10, 11 і новіше.
- `win-x64` працює **найсучаснішою** 64-розрядною ОС Windows у версії 10, 11, Server 2016+ і новіше.

Звичайно, навіть якщо у вас немає пакетів для конкретної ОС-архітектури, ви завжди можете встановити відповідний пункт. Завдяки ET вона працює самостійно і запускає смак ASF, а також головна причина того, чому вона існує в першу чергу. Звичайний збірка ASF це платформа агностика і буде виконуватися на будь-якій платформі, яка має робочий .NET час. Важливо зазначити. ASF потребує .NET runtime, не якась конкретна ОС чи архітектура. For example, if you're running 32-bit Windows then despite of no dedicated `win-x86` ASF version, you can still install .NET SDK in `win-x86` version and run generic ASF just fine. Ми просто не можемо націлити кожну комбінацію OS-архітектуру, яка існує і використовується чимось, тому ми маємо десь провести лінію. x86 - це хороший приклад цієї лінії, оскільки вона застаріла архітектура, щонайменше з 2004 року.

For a complete list of all supported platforms and OSes by .NET 10.0, visit **[release notes](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md)**.

---

## Виконувані вимоги

Якщо ви використовуєте пакет для ОС, то вам не потрібно турбуватися про вимоги під час виконання, тому що ASF завжди здійснює обов’язкові та найновіші робочі години, які будуть працювати належним чином, якщо ви маєте **[. ET передумови](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** встановлено і оновлені в актуальному стані. Іншими словами, **вам не потрібно встановлювати. ET runtime або SDK**, оскільки збірки, специфічні для ОС вимагають тільки нативні залежності системи (передумови) і нічого іншого.

Проте, якщо ви намагаєтеся запустити **загальний пакет** ASF ви повинні переконатися, що ваш .NET runtime підтримує платформу, необхідну ASF.

ASF як програма націлена на **.NET 10.0** (`net10.`) прямо зараз, але він може націлити на нову платформу в майбутньому. `net10.0` is supported since 10.0.100 SDK (10.0.0 runtime), although ASF might prefer **latest runtime at the moment of compilation**, so you should ensure that you have **[latest SDK](https://dotnet.microsoft.com/download)** (or at least runtime) available for your machine. Звичайний варіант ASF може відмовитись від запуску, якщо ваш runtime старший за вказаний мінімально підтримуваний під час компіляції.

Якщо ви сумніваєтеся, що таке **[безперервна інтеграція використовує](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** для компіляції та розгортання релізів ASF на GitHub. Ви можете знайти `dotnet --info` на кожній збірці цього кроку перевірки .NET.