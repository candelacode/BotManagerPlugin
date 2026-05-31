# Tredjepart

Dette afsnit omfatter forskellige tredjepartstilføjelser, der udelukkende er skrevet (eller hovedsageligt) til brug sammen med ASF. De spænder fra ASF plugins, gennem enkle web-applikationer og interne biblioteker til integration, slutter med fuldt udstyret bots til andre platforme. Hvis du vil tilføje noget til listen, så lad os vide på Discord eller på vores Steam-gruppe.

Bemærk, at nedenstående programmer er **ikke** vedligeholdes af ASF udviklere, og derfor **giver vi ingen garanti for nogen af dem**, især med hensyn til sikkerhed, sikkerhed eller Steam ToS overholdelse. Denne liste opretholdes kun for henvisning. Du bør altid sikre, at den tredjeparts hjælpeprogram, du er ved at bruge, er sikker og legit nok for dig, som du bruger dem alle på egen risiko.

---

## ASF plugins

### **[CatPoweredPlugins](https://github.com/CatPoweredPlugins)** (**[Rudokhvist](https://github.com/Rudokhvist)**)

- **[ASFAchievementManager](https://github.com/CatPoweredPlugins/ASFAchievementManager)**, plugin til ASF, der giver dig mulighed for at administrere Steam-præstationer.
- **[BirthdayPlugin](https://github.com/CatPoweredPlugins/BirthdayPlugin)**, plugin til ASF til at modtage fødselsdag tillykke.
- **[CaseInsensitiveASF](https://github.com/CatPoweredPlugins/CaseInsensitiveASF)**, plugin til ASF for at gøre bot navne case-ufølsomme.
- **[CommandAliasPlugin](https://github.com/CatPoweredPlugins/CommandAliasPlugin)**, plugin til ASF til at opsætte brugerdefinerede kommandoaliaser til ASF kommandoer.
- **[CommandlessRedeem](https://github.com/CatPoweredPlugins/CommandlessRedeem)**, plugin til ASF til at genimplementere nøgle indløsning uden en kommando.
- **[ItemDispenser](https://github.com/CatPoweredPlugins/ItemDispenser)**, plugin til ASF til automatisk at acceptere handel anmodning om visse typer af varer.
- **[SelectiveLootAndTransferPlugin](https://github.com/CatPoweredPlugins/SelectiveLootAndTransferPlugin)**, plugin til ASF leverer avanceret `overførsel` kommando til overførsel af Steam elementer.

### **[Citrinat](https://github.com/Citrinate)**

- **[BoosterManager](https://github.com/Citrinate/BoosterManager)**, plugin til ASF giver en nem at bruge interface til at gøre ædelstene til booster pakker samt forskellige funktioner til styring af lagerbeholdninger og markedsfortegnelser.
- **[CS2Interface](https://github.com/Citrinate/CS2Interface)**, plugin til ASF, der giver dig mulighed for at interagere med Counter-Strike 2 ved hjælp af **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**.
- **[FreePackages](https://github.com/Citrinate/FreePackages)**, plugin til ASF, der finder gratis pakker på Steam og tilføjer dem til din konto.

### **[Vita](https://github.com/ezhevita)**

- **[FriendAccepter](https://github.com/ezhevita/FriendAccepter)**, plugin til ASF til automatisk at acceptere alle venneinvitationer.
- **[GameRemover](https://github.com/ezhevita/GameRemover)**, plugin til ASF implementere en kommando til at fjerne Steam-licenser for valgte bot forekomster.
- **[GetEmail](https://github.com/ezhevita/GetEmail)**, plugin til ASF implementere en kommando til at hente e-mail-adresse på givne bot forekomster direkte fra Steam.
- **[ResetAPIKey](https://github.com/ezhevita/ResetAPIKey)**, plugin til ASF implementere en kommando til at nulstille API-nøgle for udvalgte bot forekomster.

### Andre

- **[ASFEnhance](https://github.com/chr233/ASFEnhance)**, plugin til ASF styrke det med forskellige nye funktioner, især kommandoer.
- **[ASFFreeGames](https://github.com/maxisoft/ASFFreeGames)**, plugin til ASF, så en til automatisk at indsamle gratis dampspil lagt ud på reddit.

---

## Integrationer

- **[ASFBot](https://github.com/dmcallejo/ASFBot)**, telegram bot skrevet i python med ASF integration.
- **[ASF STM userscript](https://greasyfork.org/en/scripts/404754-asf-stm)**, for dem, der ønsker at sende automatisk handel tilbud til bots på vores **[ASF STM liste](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** via webbrowser, uden at bruge `MatchActively` funktion leveret af ASF.
- **[simple-asf-bot](https://github.com/deluxghost/simple-asf-bot)**, en anden (minimal) telegram bot skrevet i python med ASF integration.

---

## Biblioteker

- **[ASF-IPC](https://github.com/deluxghost/ASF_IPC)**, python-bibliotek til yderligere integration med ASF's IPC-grænseflade.

---

## Emballage

- **[AUR repo #1](https://aur.archlinux.org/packages/asf)**, så du nemt kan installere ASF på arch linux.
- **[AUR repo #2](https://aur.archlinux.org/packages/archisteamfarm-bin)**, så du nemt kan installere ASF på arch linux.
- **[Homebrew](https://formulae.brew.sh/formula/archi-steam-farm)**, så du nemt kan installere ASF på macOS.
- **[Nix](https://search.nixos.org/packages?channel=unstable&show=ArchiSteamFarm&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, så du nemt kan installere ASF på distros med Nix.
- **[NixOS](https://search.nixos.org/options?channel=unstable&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, så du kan konfigurere og installere ASF med NixOS.
- **[Scoop](https://scoop.sh/#/apps?q=ArchiSteamFarm)**, så du nemt kan installere ASF på vinduer.
- **[Winget](https://github.com/microsoft/winget-pkgs/tree/master/manifests/j/JustArchiNET/ArchiSteamFarm)**, så du nemt kan installere ASF på vinduer.

---

## Værktøjer

- **[CS2Script](https://github.com/Citrinate/CS2Script)**giver dig mulighed for at administrere dine Counter-Strike 2 lagringsenheder ved hjælp af **[CS2Interface](https://github.com/Citrinate/CS2Interface)** plugin.
- **[Keys extractor](https://umaim.github.io/SKE)**, giver dig mulighed for at kopiere indsæt nøgler i forskellige formater og oprette `indløse` kommando til ASF. Tjek **[GitHub repo](https://github.com/PixvIO/SKE)** for flere detaljer.
- **[ASF Mass Config Editor](https://github.com/genesix-eu/ASF_MCE)**, som gør det lettere at administrere flere ASF konfigurationer.

---

## Vil du finde mere?

Vi anbefaler **[ArchiSteamFarm](https://github.com/topics/archisteamfarm)** emne på GitHub for alle projekter, der integreres med ASF. Husk dog, at uden relation til ASF projekter kan også forsøge at bruge tag, normalt til selvpromovering, så det er altid en god idé at dobbelttjek.