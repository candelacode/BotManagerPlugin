# Tredjepart

Dette avsnittet omfatter ulike tredjepartstillegg som er skrevet utelukkende (eller fastsatt) til bruk sammen med ASF. De strekker seg fra ASF-plugins, gjennom enkle web-programmer og interne biblioteker for integrering, og slutter med fullverdige botter for andre plattformer. Hvis du ønsker å legge til noe til listen, la oss få vite det på Discord eller på vår Steam-gruppe.

Vær oppmerksom på at programmet under er **ikke** vedlikeholdt av ASF-utviklere og derfor **vi ikke gir noen garanti for dem**, spesielt når det gjelder sikkerhet, sikkerhet eller Steam ToS overholdelse. Denne listen vedlikeholdes bare for referanse. Du bør alltid påse at tredjeparts nytte er i ferd med å bruke er trygt og legitim nok for deg, når du bruker alle dem på eget ansvar.

---

## ASF plugins

### **[CatPoweredPlugins](https://github.com/CatPoweredPlugins)** (**[Rudokhvist](https://github.com/Rudokhvist)**)

- **[ASFAchievementManager](https://github.com/CatPoweredPlugins/ASFAchievementManager)**, plugin for ASF som gir deg mulighet til å administrere Steam-prestasjoner.
- **[BirthdayPlugin](https://github.com/CatPoweredPlugins/BirthdayPlugin)**, plugin for ASF for å motta bursdagsgratulasjoner.
- **[CaseInsensitiveASF](https://github.com/CatPoweredPlugins/CaseInsensitiveASF)**, plugin til ASF for å lage bot navn usynlig.
- **[CommandAliasPlugin](https://github.com/CatPoweredPlugins/CommandAliasPlugin)**, plugin for ASF å sette opp egendefinerte kommandoen aliaser for ASF-kommandoer.
- **[CommandlessRedeem](https://github.com/CatPoweredPlugins/CommandlessRedeem)**, plugin for ASF for å reimplementere nøkkel innløste uten en kommando.
- **[ItemDispenser](https://github.com/CatPoweredPlugins/ItemDispenser)**, plugin for ASF å automatisk godta forespørsel om visse typer element(er) elementer.
- **[SelectiveLootAndTransferPlugin](https://github.com/CatPoweredPlugins/SelectiveLootAndTransferPlugin)**, plugin for ASF som tilbyr avansert `overføring` kommando for å overføre Steam-elementer.

### **[Kitrinat](https://github.com/Citrinate)**

- **[BoosterManager](https://github.com/Citrinate/BoosterManager)**, plugin for ASF som gir et brukervennlig grensesnitt for å gjøre egne temaer om til boosterpakker, samt ulike funksjoner for å administrere lager- og markedsoppføringer.
- **[CS2Interface](https://github.com/Citrinate/CS2Interface)**, plugin for ASF som lar deg kommunisere med Counter-Strike 2 ved å bruke **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**.
- **[FreePackages](https://github.com/Citrinate/FreePackages)**, plugin for ASF som finner gratis pakker på Steam og legger dem til kontoen din.

### **[Vita](https://github.com/ezhevita)**

- **[FriendAccepter](https://github.com/ezhevita/FriendAccepter)**, plugin for ASF for å automatisk akseptere alle venneinvitasjoner.
- **[GameRemover](https://github.com/ezhevita/GameRemover)**, plugin for ASF som implementerer en kommando for å fjerne Steam-lisenser for valgte bot forekomster.
- **[GetEmail](https://github.com/ezhevita/GetEmail)**, plugin for ASF som implementerer en kommando for å hente e-post adressen til gitt bot forekomster direkte fra Steam.
- **[ResetAPIKey](https://github.com/ezhevita/ResetAPIKey)**, plugin for ASF som implementerer en kommando for å nullstille API-nøkkel for valgte bot forekomster.

### Annet

- **[ASFEnhance](https://github.com/chr233/ASFEnhance)**, plugin for ASF øker med forskjellige nye funksjoner, spesielt kommandoer.
- **[ASFFreeGames](https://github.com/maxisoft/ASFFreeGames)**, plugin for ASF slik at en automatisk kan samle gratis spill av steam ved reddit.

---

## Integrasjoner

- **[ASFBot](https://github.com/dmcallejo/ASFBot)**, telegram bot skrevet i python med ASF-integrasjon.
- **[ASF STM userscript](https://greasyfork.org/en/scripts/404754-asf-stm)**, for de som vil sende automatiserte tilbud til bots på vår **[ASF STM liste](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** gjennom nettleser, uten å bruke `MatchActively` funksjonen gitt av ASF.
- **[simple-asf-bot](https://github.com/deluxghost/simple-asf-bot)**, en annen (minimal) telegram-bot skrevet med python med ASF-integrering.

---

## Biblioteker

- **[ASF-IPC](https://github.com/deluxghost/ASF_IPC)**, python biblioteket for ytterligere integrasjon med ASFs IPC grensesnitt.

---

## Emballasje

- **[AUR repo #1](https://aur.archlinux.org/packages/asf)**, slik at du enkelt kan installere ASF på bue linux.
- **[AUR repo #2](https://aur.archlinux.org/packages/archisteamfarm-bin)**, slik at du enkelt kan installere ASF på bue linux.
- **[Homebrew](https://formulae.brew.sh/formula/archi-steam-farm)**, slik at du enkelt kan installere ASF på macOS.
- **[Nix](https://search.nixos.org/packages?channel=unstable&show=ArchiSteamFarm&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, slik at du enkelt kan installere ASF på distroer med Nix.
- **[NixOS](https://search.nixos.org/options?channel=unstable&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**lar deg konfigurere og installere ASF med NixOS.
- **[Scoop](https://scoop.sh/#/apps?q=ArchiSteamFarm)**, slik at du enkelt kan installere ASF på vinduer.
- **[Winget](https://github.com/microsoft/winget-pkgs/tree/master/manifests/j/JustArchiNET/ArchiSteamFarm)**, slik at du enkelt kan installere ASF på vinduer.

---

## Verktøy

- **[CS2Script](https://github.com/Citrinate/CS2Script)**, gir deg mulighet til å administrere dine To-Strike 2 lagringsenheter ved hjelp av **[CS2Interface](https://github.com/Citrinate/CS2Interface)** plugin.
- **[Keys extractor](https://umaim.github.io/SKE)**, lar deg kopiere og lime tastene i ulike formater og lage `innløser` kommando for ASF. Sjekk **[GitHub repo](https://github.com/PixvIO/SKE)** for mer informasjon.
- **[ASF-Mass Config Editor](https://github.com/genesix-eu/ASF_MCE)**, som gjør det enklere å administrere flere ASF-konfigurasjoner samtidig.

---

## Vil du finne mer?

Vi anbefaler **[ArchiSteamFarm](https://github.com/topics/archisteamfarm)** emne på GitHub for alle prosjekter som integrerer med ASF. Husk imidlertid at uknyttet til ASF-prosjekter også kan forsøke å bruke taggen, som vanligvis er til selvå promotere, så det er alltid lurt å dobbeltsjekke.