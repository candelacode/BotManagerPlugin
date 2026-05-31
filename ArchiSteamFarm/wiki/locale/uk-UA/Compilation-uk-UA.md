# Компіляція

Компіляція - це процес створення виконуваного файлу. This is what you want to do if you want to add your own changes to ASF, or if you for whatever reason don't trust executable files provided in official **[releases](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**. Якщо ви користувач і не розробник, швидше за все, ви хочете використовувати вже скомпільовані двійки, але якщо ви хочете використовувати власні або дізнатися щось нове, продовжити читання.

ASF може бути скомпільовано на будь-якій підтримуваній платформі, якщо у вас є всі необхідні інструменти.

---

## .NET SDK

Незалежно від платформи, ви повинні мати повний .NET SDK (не просто runtime) для компіляції ASF. Інструкції з встановлення можна знайти на сторінці завантаження **[.NET](https://dotnet.microsoft.com/download)**. Вам необхідно встановити відповідну версію .NET SDK для вашої ОС. Після успішного встановлення, команда `dotnet` повинна працювати та працювати. You can verify if it works with `dotnet --info`. Also ensure that your .NET SDK matches ASF **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## Компіляція

Припускається, що у вас є операційна система .NET SDK і у відповідній версії, просто перейдіть до каталогу ASF (клоновані чи завантажені та завантажені файли ASF репозиторії) та виконайте команду:

```shell
dotnet публікувати архів SteamFarm -c "Реліз" -o "out/generic"
```

Якщо ви використовуєте Linux/macOS, то ви можете замість цього використати `cc.sh` , який виконуватиме теж саме, трохи складніше.

Якщо компіляція завершилася успішно, ви можете знайти ваш ASF у каталозі `вихідний` подач `аут/звичайної` This is the same as official `generic` ASF build, but it has forced `UpdateChannel` and `UpdatePeriod` of `0`, which is appropriate for self-builds.

### конкретна ОС

Ви також можете згенерувати пакет для конкретної ОС, якщо у вас є потреба. In general you shouldn't do that because you've just compiled `generic` flavour that you can run with your already-installed .NET runtime that you've used for the compilation in the first place, but just in case you want to:

```shell
dotnet публікувати Архів SteamFarm -c "Реліза" -o "out/linux-x64" -r "linux-x64" --власноруч
```

Звичайно, замінити `linux-64` на архітектуру ОС, на яку ви хочете націлити, наприклад `win-x64`. Ця збірка також матиме оновлення вимкнені. When building `--self-contained` you can also optionally declare two more switches: `-p:PublishTrimmed=true` will produce trimmed build, while `-p:PublishSingleFile=true` will produce a single file. Додавання обох призведе до того ж налаштування, які ми використовуємо для власних будівель.

### ASF-ui

While the above steps are everything that is required to have a fully working build of ASF, you may *also* be interested in building **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, our graphical web interface. З боку ASF просто потрібно скинути ASF-ui побудувати вихідний код у стандартному `ASF-ui/dist` потім побудова ASF з ним (знову ж таки, при необхідності).

ASF-ui is part of ASF's source tree as a **[git submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, ensure that you've cloned the repo with `git clone --recursive`, as otherwise you'll not have the required files. Вам також знадобиться робоча NPM, **[Node.js](https://nodejs.org)** включно з ним. If you're using Linux/macOS, we recommend our `cc.sh` script, which will automatically cover building and shipping ASF-ui (if possible, that is, if you're meeting the requirements we've just mentioned).

In addition to the `cc.sh` script, we also attach the simplified build instructions below, refer to **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** for additional documentation. З місця розташування вихідного дерева ASF, так як і вище, виконувати наступні команди:

```shell
rm -rf "ASF-ui/dist" # ASF-ui doesn't clean itself after old build

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # Ensure that our build output is clean of the old files
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic" # Or accordingly to what you need as per the above
```

You should now be able to find the ASF-ui files in your `out/generic/www` folder. ASF зможе обслуговувати ці файли у вашому браузері.

Alternatively, you can simply build ASF-ui, whether manually or with the help of our repo, then copy the build output over to `${OUT}/www` folder manually, where `${OUT}` is the output folder of ASF that you've specified with `-o` parameter. This is exactly what ASF is doing as part of the build process, it copies `ASF-ui/dist` (if exists) over to `${OUT}/www`, nothing special, and can also be done post-build as you can see, if needed.

---

## Розробка

Якщо ви хочете редагувати код ASF, ви можете користуватися будь-ким. Для цієї мети ET сумісний IDE, хоча і це не обов'язково, оскільки ви можете також редагувати записником і компілювати з командою `dotnet` описаною вище.

If you don't have a better pick, we can recommend **[JetBrains Rider](https://www.jetbrains.com/rider)** and **[Visual Studio Code](https://code.visualstudio.com/download)**, with first one being the preferred IDE that ASF team is personally using, and second one being viable alternative. Обидві програми є крос-платформеними та доступними на Linux, macOS та Windows.

---

## Мітки

`main` branch is not guaranteed to be in a state that allows successful compilation or flawless ASF execution in the first place, since it's development branch just like stated in our **[release cycle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. If you want to compile or reference ASF from source, then you should use appropriate **[tag](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** for that purpose, which guarantees at least successful compilation, and very likely also flawless execution (if build was marked as stable release). In order to check the current "health" of the tree, you can use our CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Офіційні релізи

Офіційні релізи ASF зібрані **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, із останнім. ET SDK, який відповідає ASF **[вимогам робочого процесу](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. Після проходження тестів, всі пакети будуть розгорнуті як реліз, а також на GitHub. Це також гарантує прозорість, оскільки GitHub завжди використовує офіційне суспільне джерело для всіх будівель, і ви можете порівняти контрольні суми артефактів GitHub з випуском активів. Розробники ASF не збирають або не публікують збірки, окрім приватних процесів розробки та налагодження.

На додаток до вищесказаного, супроводжуючі ASF вручну підтверджують та публікують контрольні суми збірки на незалежних від GitHub, віддалений сервер ASF в якості додаткової програми безпеки. Цей крок обов'язковий для існуючих ASF вважати реліз дійсним кандидатом у функції автоматичного оновлення.