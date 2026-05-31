# Kurulum

Buraya ilk kez geldiyseniz, hoş geldiniz! We're very happy to see yet another traveler that is interested in our project, although bear in mind that with great power comes great responsibility - ASF is capable of doing a lot of different Steam-related tasks, but only as long as you **care enough to learn how to use it**. Indeed, reading wiki, following our guidelines and learning more about various ASF concepts will eventually reward you with unique skill of using one of the most powerful Steam tools available as of today.

We recommend you to do **one thing at a time**. ASF touches a lot of different aspects, some of which are rather trivial, other can be overly complex. You don't need to understand or read about everything at once, and we actually recommend you to take it easy. Relax, pick yourself a beverage of choice, dedicate an hour of your time and dive into our lecture - we can promise that it'll be well worth your time.

Let's start from the basics - ASF is a console app in its principle, which means that it won't automatically spawn a graphical interface that you're in general used to. ASF is universal app that mainly acts as a service (daemon), and not a desktop app. One of its main use cases considers running on the server machines, which desktop apps are entirely unsuitable for. That considers only the absolute core of the program though, because ASF actually **does** include its own graphical interface - in form of its built-in ASF-ui frontend, but we'll get down to that part in due time - we're just mentioning this right away so you won't panic when seeing black console screen or something.

Once you obtain ASF binary files, the program will require configuration from you, which specifies what exactly you expect for ASF to achieve. You can start the program without configuration, in this case ASF will launch in default settings, allowing you to use e.g. ASF-ui for the initial configuration, but other than that it won't do much without your prior action.

That will do for now, let's start!

---

## İşletim sistemine özgü kurulum

Genel olarak, işte önümüzdeki birkaç dakika içinde yapacağımız şey:
- We'll install **[.NET prerequisites](#net-prerequisites)**.
- Then we'll download **[latest ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** in appropriate OS-specific variant.
- Next we'll extract the archive into new location.
- Then we'll **[configure ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- And finally, we'll launch ASF and see its magic.

Some of the steps are self-explanatory, other will require more attention from you. Don't worry, we've got you covered.

---

### .NET ön gereksinimleri

İlk adım, işletim sisteminizin ASF'yi düzgün şekilde başlatabilmesini sağlamaktır. You don't need to know that, but ASF is written in C#, based on .NET platform and may require native libraries that are not available on your platform yet. Think of it like DirectX for the 3D games, or engine for starting your car.

Depending on whether you use Windows, Linux or macOS, you will have different requirements. The reference document is **[.NET prerequisites](https://docs.microsoft.com/dotnet/core/install)**, but for the sake of simplicity we've also detailed all needed packages below, so you don't need to read it at all, unless you run into problems or you'll have additional questions.

Kullanmakta olduğunuz üçüncü taraf yazılımlar tarafından yüklendiği için bazı (hatta tüm) bağımlılıkların sisteminizde zaten mevcut olması tamamen normaldir. Still, that doesn't need to be the case, so you should run appropriate installer for your OS - without those dependencies ASF won't launch at all, and you'll barely get any useful information for telling you what's wrong.

Keep in mind that you don't need to do anything else for OS-specific builds, especially installing .NET SDK or even runtime, since OS-specific package includes all of that already. You need only .NET prerequisites (dependencies) to run .NET runtime included in ASF - so only the things that we specify below, without any other additions.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** for 64-bit, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** for 32-bit or **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** for 64-bit ARM)
- Tüm Windows güncellemelerinin zaten yüklü olduğundan emin olmanız şiddetle önerilir. If you don't have them enabled, then at the very least you need **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** and **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, but more updates may be needed. You don't need to worry about that if your Windows is up-to-date, or at least recent enough.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Paket adları, kullandığınız Linux dağıtımına bağlıdır, en yaygın olanları listeledik. Hepsini işletim sisteminiz için yerel paket yöneticisi ile edinebilirsiniz (Debian için `apt` veya CentOS için `yum` gibi). Those are pretty standard libraries that should be available regardless of what distribution you're using, it's only a matter of finding out how they're called in your environment of choice.

- `ca-certificates` (standard trusted SSL certificates to make HTTPS connections)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, latest version for your distribution, for example `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-libs`, latest version for your distribution, at least `1.1.X`)
- `libstdc++6` (`libstdc++`, `5.0` veya daha yüksek bir versiyon)
- `zlib1g` (`zlib`)

Bunların en azından çoğunluğu sisteminizde yerel olarak mevcut olmalıdır. For example, the minimal installation of Debian stable usually requires only `libicu76`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- You don't need anything specifically, but you should have latest version of macOS installed, at least 12.0+

---

### İndirme

Gerekli tüm bağımlılıklara zaten sahip olduğumuzdan, bir sonraki adım **[ASF'nin son sürümü](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**'nü indirme işlemidir. ASF'nin birçok çeşidi mevcuttur, ancak işletim sisteminize ve mimarinize uygun paketle ilgileniyorsunuz. Örneğin, `64`-bit `Win`dows kullanıyorsanız, `ASF-win-x64` paketini istiyorsunuz. Mevcut varyantlar hakkında daha fazla bilgi için, **[Erişilebilirlik](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** adresini ziyaret edin. ASF is also able to run in the environments that we're not building OS-specific package for, such as **32-bit Windows**, but you'll need **[generic setup](#generic-setup)** for that.

![Assets](https://i.imgur.com/Ym2xPE5.png)

İndirdikten sonra, zip dosyasını kendi klasörüne çıkarmaya başlayın. If you require a specific tool for that, **[7-zip](https://www.7-zip.org)** will do, but all standard utilities like built-in Windows extraction or `unzip` from Linux/macOS should work without problems as well.

Be advised to unpack ASF to **its own directory** and not to any existing directory you're already using for something else - that's important. ASF includes auto-updates feature, which replaces its own files, and that will usually delete all old and unrelated files when upgrading, which in turn may lead to you losing anything unrelated you put into the ASF directory. If you have any extra scripts or files that you want to use with ASF, that's not a problem, create a dedicated folder for those, you can always put ASF in one folder deeper.

An example structure could look like this:

```text
C:\ASF (where you put your own things)
    ├── MyNotes.txt (optional)
    ├── AsfMakeMeCoffeeScript.bat (optional)
    ├── (...) (any other files of your choice, optional)
    └── Core (dedicated to ASF only, where you extract the archive)
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         ├── www
         └── (...)
```

---

### Yapılandırma

We're now ready to do the very last step, the configuration. ASF works with concept of "bots", each bot is usually a single Steam account that you'd like to use inside ASF. You can declare as many bots as you'd like, but for the starter we'll focus on just one of them - usually your main account. ASF also has non-bot configuration files, the most important one is global configuration file, which affects all bots in the instance.

The general rule of thumb is that **if you don't know, or don't understand some setting, you should leave it with its default value, without changing anything**. ASF offers countless ways to configure, customize and tweak almost all of its features, but like mentioned above, trying to understand it right off the bat is a rabbit hole that may quickly drag you into severe confusion, if not **[straight into the abyss](https://www.youtube.com/watch?v=KK3KXAECte4)**. Instead, we recommend to have a working example first, and only then start digging into additional options, with the help of **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** page on the wiki, while changing **one thing at a time**.

ASF configuration can be done in several ways - through our built-in ASF-ui frontend, a standalone web config generator, or manually. This is explained in-depth in **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section, so refer to that if you want more detailed information. We'll use standalone web config generator as a starting point, because it works even if for some reason ASF-ui fails to start or work correctly.

Navigate to our **[web config generator](https://justarchinet.github.io/ASF-WebConfigGenerator)** page with your favourite browser. We recommend Chrome or Firefox, but it should not matter as long as your browser works for everything else.

After opening the page, switch to "Bot" tab. You should now see a page similar to the one below:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

If by any chance the version of ASF that you've just downloaded is older than what config generator is set to use by default, simply choose your ASF version from the dropdown menu. This can (rarely) happen, as the config generator can be used for generating configs to newer (pre-release) ASF versions that weren't marked as stable yet. You've downloaded latest stable release of ASF that is verified to work reliably, so it might be a bit older than the absolute cutting edge version, which is totally not suitable for the first-time use.

Start from **putting name for your bot** into the field highlighted as red, called `Name`. This can be any name you'd like to use, such as your nickname, account name, a number, or anything else. There is only one word that you can't use, `ASF`, as that keyword is reserved for global config file. In addition to that your bot name can't start with a dot (ASF intentionally ignores those files). We also recommend that you avoid using spaces, you can use `_` as a word separator if needed - not a strict requirement, but you'll have hard time using ASF commands otherwise.

Bot name decided? Great, in the next step, **change `Enabled` switch to be on**, that one defines whether your bot is supposed to be started by ASF automatically after launch (of the program). Not doing that will cause ASF to state that your bot is disabled in the configuration file, and it'll wait for your input to start it, which is not what we want to be doing in this example.

Now, there are two sensitive properties coming up next: `SteamLogin` and `SteamPassword`. You can make another decision here - either you can put your Steam login details in those two properties, or you can decide against doing that, leaving them empty.

ASF requires your login credentials because it includes its own implementation of Steam client and needs the same details to log in as the one that you use yourself. Your login credentials are not saved anywhere but on your PC in ASF `config` directory only (once you download the generated config). Our web config generator is client-based application which means that everything you're doing inside our standalone web config-generator website is running locally in your browser to generate valid ASF configs, without details you're inputting ever leaving your PC in the first place, so there is no need to worry about any possible sensitive data leak. Still, if you for whatever reason don't want to put your credentials there, we understand that, and you can put them manually later in generated files, or omit them entirely and operate without them.

If you decide to input your credentials, ASF will be able to automatically log in during startup, which together with optional 2FA will effectively allow you to just double-click the program to run everything. If you decide to omit them, then ASF will **ask you** to input those details when needed - that approach won't save them anywhere, but naturally ASF won't be able to operate without your help. It's up to you which way you prefer more, and you can also find additional information in **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section, as usual.

As a side note, you can also decide to leave just one field empty, such as `SteamPassword`. ASF will then be able to use your login automatically, but will still ask for password if needed (similar to Steam Client). If by any chance you're using 4-digit parental pin to unlock your account, we also recommend to put it inside `SteamParentalPin` box, although also in this case you can just leave this empty, and instead observe how weak that protection is, because ASF can also "crack" it itself within mere seconds after logging in. Oops.

After following with everything above, so once again, **bot name**, **enabled switch**, and **login credentials** , your web page will now look similar to the one below:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

You can now hit "download" button and our web config generator will generate new `json` file based on your chosen name. Save that file into `config` directory which is located in the folder inside which you've extracted the zip file in the previous step.

Congratulations! You've just finished the very basic ASF bot configuration. There's a lot more to discover, but for now this is everything that you need.

---

### Running ASF

I know you've been waiting for this moment, and we can't hold you longer, as you're now ready to launch the program for the first time. Simply double-click `ArchiSteamFarm` binary in ASF directory. You can also start it from the console.

Now would be a good time to review our **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section if you're concerned about stuff that ASF is programmed to do, especially actions that it'll take in your name, such as joining our Steam group by default. You can always disable selected functionalities later on if you won't like them, ASF simply comes with sensible defaults, and we had to make some decision about general use that applies to the majority of our userbase, as well as our own view on the program in its principle.

Assuming everything went well, which mostly considers installing all required dependencies in the first step, and configuring ASF in the third one, ASF should launch properly, discover your first bot, and attempt to log in:

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF will most likely still require one more detail from you - 2FA to access the account (unless you disabled SteamGuard completely, then no). Simply follow the instructions on the screen, you can provide code from authenticator/e-mail, or accept the confirmation in the mobile app.

Something went wrong?

#### ASF doesn't start at all, no console window

Either you're missing .NET prerequisites, or you've downloaded incorrect variant of ASF for your machine. If you don't know what's wrong, check our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** for a possible way to find out exact problem, and if you're still stuck, reach for our **[support](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### No bots defined

You didn't put generated config into the `config` directory. Some other common mistakes in this step might include manually changing extension from `.json` e.g. to `.txt`, and some operating systems (e.g. Windows) like to hide common extensions by default, so ensure your file is in appropriate place and also with appropriate name.

#### Not starting this bot because it's disabled in configuration file

You forgot to flip the `Enabled` switch which tells ASF to start your bot automatically. Unless that was your intention of course, but then you should already know how to execute commands, simply `start` your bot after that message.

#### `InvalidPassword`

Your login credentials are most likely wrong. Check your `SteamLogin` and `SteamPassword` in the generated config, if they're wrong, correct them by going back to the configuration step. If you're still having issues, try to use the same login credentials in your own Steam client - you should also fail to log in, and perhaps you'll get more information on what's wrong this way.

#### All good?

After passing through initial login gate, assuming your details are correct, you'll successfully log in, and ASF will start farming using default settings that you didn't touch as of now:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

This proves that ASF is now successfully doing its job on your account, so you can now minimize the program and do something else. Go ahead, you deserved it, maybe refill that drink of your choice at least!

Farming cards is a subject for another lengthy article like this, but in principle: after enough of time (depending on **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), you'll see Steam trading cards slowly being dropped. Of course, for that to happen you must have valid games to farm, showing as "you can get X more card drops from playing this game" on your **[badges page](https://steamcommunity.com/my/badges)** - if there are no games to farm, then ASF will state that there is nothing to do, as stated in our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, which answers the most common question people have at this point, wondering why despite owning whopping 14 games on their account, ASF claims there's nothing to do - no, it's not a bug.

This concludes our very basic setting up guide. Like in every RPG game, you've finished the tutorial, and we're leaving you whole ASF world to explore now. For example you can now decide whether you want to configure ASF further, or let it do its job in default settings. We'll cover a few more basic details if you'd like to read a bit more, then leave you entire wiki for discovery.

---

### Extended configuration

#### Farming several accounts at once

ASF supports farming more than one account at a time, which is its primary function. You can add more accounts to ASF by generating more bot config files, in exactly the same way as you've generated your first one just a few minutes ago. You need to ensure only two things:

- Unique bot name, if you already have your first bot named `MainAccount`, you can't have another one with the same name.
- Valid login details, such as `SteamLogin`, `SteamPassword` and `SteamParentalCode` (if you've decided to fill them)

In other words, simply jump to configuration again and do exactly the same, just for your second or third account. Remember to use unique names for all of your bots, to not overwrite existing configs.

---

#### Changing settings

In our standalone web config-generator, you change existing settings in exactly the same way - by generating a new config file. Click on "toggle advanced settings" and see what is there for you to discover. In this example, we'll change `CustomGamePlayedWhileFarming` setting, which allows you to set custom name being displayed when ASF is farming, instead of showing actual game.

Let's analyze this a bit first. If you run ASF and start farming, in default settings you'll see that your Steam account is in-game now:

![Steam](https://i.imgur.com/1VCDrGC.png)

That makes sense, after all ASF just told the Steam platform that we're playing the game, we need cards from it, right? But hey, we can customize this! Toggle advanced settings if you haven't done in yet, then find `CustomGamePlayedWhileFarming`. Simply put any custom text that you want to display there, such as "Idling cards":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Now download the new config file in exactly the same way, then **overwrite** your old config file with new one. You can also delete your old config file and put the new one in its place of course.

ASF is pretty smart and it should notice that you've changed the config, which it should then automatically pick up and apply, without a program restart. If by any chance that didn't happen, you can simply restart the program to ensure your new config is picked up. After doing that, you should notice that ASF now displays your custom text in the previous place:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

This confirms that you've successfully edited your config. In exactly the same way you can change global ASF properties, by switching from bot tab to "ASF" tab, downloading generated `ASF.json` config file and putting it in your `config` directory.

Editing your ASF configs can be done much easier by using our ASF-ui frontend, which will be explained further below.

---

#### Using ASF-ui

As we mentioned before, ASF is a console app and doesn't launch a graphical user interface by default. However, we're actively working on **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** frontend to our IPC interface, which can be a very decent and user-friendly way to access various ASF features.

In order to use ASF-ui, you need to have `IPC` enabled, which is the default option, so unless you manually disabled it, it's already active. Once you launch ASF, you should be able to confirm that it properly started the IPC interface automatically:

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC, in a nutshell, is built-in ASF's web server that starts locally on your machine, allowing you to interact with it using your favourite web browser. Assuming that it started correctly, you can access ASF's IPC interface by clicking **[this](http://localhost:1242)** link, as long as ASF is running, from the same machine. You can use ASF-ui for various purposes, e.g. editing the config files in-place or sending **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Feel free to take a look around in order to find out all ASF-ui functionalities.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Özet

You've successfully set up ASF to use your Steam accounts and you've already customized it to your liking a little. If you followed our entire guide, then you also managed to tweak ASF through our ASF-ui interface and started discovering its functionalities. This concludes our tutorial, but we're leaving you with some additional pointers to stuff that you may be interested in, "side quests", if you insist:

- Our **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section will explain to you  what **all** those different settings you've seen actually do, and what else ASF can offer to you. Just remember to hydrate properly while reading, you've been warned.
- If you've stumbled upon some issue or you have some generic question, consider our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**, which should cover all, or at least a vast majority of questions and issues that you may have.
- If you want to learn everything about ASF and how it can make your life easier, head over to the rest of **[our wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. Use the sidebar on the right to pick the subject that interests you.
- And finally, if you found out our program to be useful for you and you appreciate the massive amount of work that was put into it, you can also consider a small **[donation](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** to our cause. ASF is labor of love, we've been working hard in our free time for the last 10+ years to make this experience possible for you, and we're very proud of it - even $1 is highly appreciated and shows that you care. In any case, have lots of fun!

---

## Generic setup

This appendix is for advanced users that want to set up ASF to run in **[generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)** variant. While being more troublesome in usage than **[OS-specific variants](#os-specific-setup)**, it also comes with additional benefits.

You want to use `generic` variant mainly when:
- You're using OS that we don't build OS-specific package for (such as 32-bit Windows)
- You already have .NET Runtime/SDK, or want to install and use one
- You want to minimize ASF structure size and memory footprint by handling runtime requirements yourself
- You want to use a custom **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** which requires a `generic` setup of ASF to run properly (due to missing native dependencies)

Of course, you can use it also in any other scenario you want, but the above make the most sense.

However, keep in mind that generic setup comes with a twist - **you** are in charge of .NET runtime in this case. This means that if your .NET SDK (runtime) is unavailable, outdated, or broken, ASF simply won't work. This is why we totally don't recommend this setup for casual users, since you now need to ensure that your .NET SDK (runtime) matches ASF requirements and can run ASF, as opposed to **us** ensuring that our .NET runtime bundled with ASF can do so.

For `generic` package, you can follow entire OS-specific guide above, with only two small changes. In addition to installing .NET prerequisites, you also want to install .NET SDK, and instead of downloading and having OS-specific `ArchiSteamFarm(.exe)` executable file, you'll now download and have a generic `ArchiSteamFarm.dll` binary only. Everything else is exactly the same.

With extra steps:
- **[.NET ön gereksinimlerini](#net-prerequisites)** yükleyin.
- Install **[.NET SDK](https://www.microsoft.com/net/download)** (or at least ASP.NET Core and .NET runtimes) appropriate for your OS. You most likely want to use an installer. Refer to **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** if you're not sure which version to install.
- Download **[latest ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** in `generic` variant.
- Arşivi yeni bir lokasyon içerisine çıkartın.
- **[Configure ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, in exactly the same way as described above.
- Launch ASF by either using a helper script or executing `dotnet /path/to/ArchiSteamFarm.dll` manually from your favourite shell.

Generic variant of ASF does not have machine-specific binary, after all it's called `generic` for a reason - it's platform-agnostic build that can work everywhere, so don't expect `exe` file there.

This is why we've bundled it with helper scripts (such as `ArchiSteamFarm.cmd` for Windows and `ArchiSteamFarm.sh` for Linux/macOS), which are located next to `ArchiSteamFarm.dll` binary. You can use those if you don't want to execute `dotnet` command manually.

Obviously, helper scripts won't work if you didn't install .NET SDK and you don't have `dotnet` executable available in your `PATH`. They're also entirely optional to use, you can always `dotnet /path/to/ArchiSteamFarm.dll` manually if you'd like to, as under the hood with some extra tweaks, that's exactly what those scripts are doing anyway.