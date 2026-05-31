# Tredjepart

Detta avsnitt innehåller olika tredjepartstillägg skrivna exklusivt (eller huvudsakligen) för användning tillsammans med ASF. De sträcker sig från ASF-plugins, genom enkla webbapplikationer och interna bibliotek för integration, slutar med fullt utrustade robotar för andra plattformar. Om du vill lägga till något i listan, låt oss veta det på Discord eller på vår Steam-grupp.

Observera att nedan program är **inte** underhålls av ASF-utvecklare och därför **ger vi ingen garanti om någon av dem**, särskilt när det gäller säkerhet, säkerhet eller efterlevnad av Steam ToS. Denna lista bibehålls endast för referens. Du bör alltid se till att tredjepartsverktyget du är på väg att använda är säkert och legit nog för dig, som du använder dem alla på egen risk.

---

## ASF plugins

### **[CatPoweredPlugins](https://github.com/CatPoweredPlugins)** (**[Rudokhvist](https://github.com/Rudokhvist)**)

- **[ASFAchievementManager](https://github.com/CatPoweredPlugins/ASFAchievementManager)**, plugin för ASF som låter dig hantera Steam-prestationer.
- **[BirthdayPlugin](https://github.com/CatPoweredPlugins/BirthdayPlugin)**, plugin för ASF att ta emot födelsedags gratulationer.
- **[CaseInsensitiveASF](https://github.com/CatPoweredPlugins/CaseInsensitiveASF)**, plugin för ASF att göra bot namn fall-okänsliga.
- **[CommandAliasPlugin](https://github.com/CatPoweredPlugins/CommandAliasPlugin)**, plugin för ASF att ställa in egna kommandoalias för ASF-kommandon.
- **[CommandlessRedeem](https://github.com/CatPoweredPlugins/CommandlessRedeem)**, plugin för ASF att återimplementera nyckellösning utan kommando.
- **[ItemDispenser](https://github.com/CatPoweredPlugins/ItemDispenser)**, plugin för ASF att automatiskt acceptera handel begäran för vissa typer av objekt.
- **[SelectiveLootAndTransferPlugin](https://github.com/CatPoweredPlugins/SelectiveLootAndTransferPlugin)**, plugin för ASF som tillhandahåller avancerad `överföring` kommando för överföring av Steam-objekt.

### **[Citrinera](https://github.com/Citrinate)**

- **[BoosterManager](https://github.com/Citrinate/BoosterManager)**, plugin för ASF ger en enkel att använda gränssnitt för att förvandla pärlor till boosterpaket samt olika funktioner för att hantera lager och marknadslistor.
- **[CS2Interface](https://github.com/Citrinate/CS2Interface)**, plugin för ASF som låter dig interagera med Counter-Strike 2 med **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**.
- **[FreePackages](https://github.com/Citrinate/FreePackages)**, plugin för ASF som hittar gratis paket på Steam och lägger till dem på ditt konto.

### **[Vita](https://github.com/ezhevita)**

- **[FriendAccepter](https://github.com/ezhevita/FriendAccepter)**, plugin för ASF att automatiskt acceptera alla väninbjudningar.
- **[GameRemover](https://github.com/ezhevita/GameRemover)**, plugin för ASF implementerar ett kommando för att ta bort Steam licenser för valda bot instanser.
- **[GetEmail](https://github.com/ezhevita/GetEmail)**, plugin för ASF att implementera ett kommando för att hämta e-postadressen för angivna bot instanser direkt från Steam.
- **[ÅterställaAPIKey](https://github.com/ezhevita/ResetAPIKey)**, plugin för ASF implementera ett kommando för att återställa API-nyckel för valda bot instanser.

### Annat

- **[ASFEnhance](https://github.com/chr233/ASFEnhance)**, plugin för ASF förbättra den med olika nya funktioner, särskilt kommandon.
- **[ASFFreeGames](https://github.com/maxisoft/ASFFreeGames)**, plugin för ASF tillåter en att automatiskt samla gratis ångspel postat på reddit.

---

## Integrationer

- **[ASFBot](https://github.com/dmcallejo/ASFBot)**, telegram bot skriven i python med ASF integration.
- **[ASF STM userscript](https://greasyfork.org/en/scripts/404754-asf-stm)**, för dig som vill skicka automatiska byteserbjudanden till robotar på vår **[ASF STM lista](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** via webbläsare, utan att använda `MatchActively` -funktionen som tillhandahålls av ASF.
- **[simple-asf-bot](https://github.com/deluxghost/simple-asf-bot)**, en annan (minimal) telegram bot skriven i python med ASF integration.

---

## Bibliotek

- **[ASF-IPC](https://github.com/deluxghost/ASF_IPC)**, python-bibliotek för vidare integration med ASFs IPC-gränssnitt.

---

## Förpackning

- **[AUR repo #1](https://aur.archlinux.org/packages/asf)**, så att du enkelt kan installera ASF på båge linux.
- **[AUR repo #2](https://aur.archlinux.org/packages/archisteamfarm-bin)**, så att du enkelt kan installera ASF på båge linux.
- **[Homebrew](https://formulae.brew.sh/formula/archi-steam-farm)**, så att du enkelt kan installera ASF på macOS.
- **[Nix](https://search.nixos.org/packages?channel=unstable&show=ArchiSteamFarm&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, så att du enkelt kan installera ASF på distros med Nix.
- **[NixOS](https://search.nixos.org/options?channel=unstable&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, så att du kan konfigurera och installera ASF med NixOS.
- **[Scoop](https://scoop.sh/#/apps?q=ArchiSteamFarm)**, så att du enkelt kan installera ASF på fönster.
- **[Winget](https://github.com/microsoft/winget-pkgs/tree/master/manifests/j/JustArchiNET/ArchiSteamFarm)**, så att du enkelt kan installera ASF på fönster.

---

## Verktyg

- **[CS2Script](https://github.com/Citrinate/CS2Script)**, låter dig hantera dina Counter-Strike 2-lagringsenheter med hjälp av **[CS2Interface](https://github.com/Citrinate/CS2Interface)** plugin.
- **[Keys extractor](https://umaim.github.io/SKE)**, låter dig kopiera-klistra in nycklar i olika format och skapa `lösa in` kommandot för ASF. Kontrollera **[GitHub repo](https://github.com/PixvIO/SKE)** för mer information.
- **[ASF Mass Config Editor](https://github.com/genesix-eu/ASF_MCE)**, som gör det möjligt att hantera flera ASF-konfigurationer lättare.

---

## Vill du hitta mer?

Vi rekommenderar **[ArchiSteamFarm](https://github.com/topics/archisteamfarm)** ämne på GitHub för alla projekt som integrerar med ASF. Tänk dock på att unrelated till ASF-projekt kan också försöka att använda taggen, Vanligtvis för självmarknadsföring, så det är alltid en bra idé att dubbelkolla.