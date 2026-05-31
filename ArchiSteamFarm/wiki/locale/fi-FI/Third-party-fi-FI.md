# Kolmannet osapuolet

Tämä osio sisältää useita kolmannen osapuolen lisäyksiä, jotka on kirjoitettu yksinomaan (tai pääasiassa) käytettäväksi yhdessä ASF:n kanssa. Ne vaihtelevat ASF-liitännäisistä yksinkertaisiin web-sovelluksiin ja sisäisiin kirjastoihin integrointia varten ja päättyvät täysin varustellun botit muille alustoille. Jos haluat lisätä jotain listaan, ilmoita siitä Discordissa tai Steam-ryhmässämme.

Huomaa, että alla olevat ohjelmat eivät ole **** ASF kehittäjien ylläpitämä ja siksi **emme anna mitään takuuta niistä**, erityisesti turvallisuuden, turvallisuuden tai Steam ToS -vaatimusten osalta. Tämä luettelo säilyy ainoastaan viitteellisenä. Sinun tulisi aina varmistaa, että käyttämäsi kolmannen osapuolen apuohjelma on turvallinen ja tarpeeksi legit sinulle, kun käytät kaikkia niitä omalla vastuullasi.

---

## ASF-laajennukset

### **[CatPoweredPlugins](https://github.com/CatPoweredPlugins)** (**[Rudokhvist](https://github.com/Rudokhvist)**)

- **[ASFAchievementManager](https://github.com/CatPoweredPlugins/ASFAchievementManager)**, plugin ASF, jonka avulla voit hallita Steam-saavutuksia.
- **[BirthdayPlugin](https://github.com/CatPoweredPlugins/BirthdayPlugin)**, plugin ASF saada syntymäpäivä onnittelut.
- **[CaseInsensitiveASF](https://github.com/CatPoweredPlugins/CaseInsensitiveASF)**, ASF plugin botin nimet case-insensitive.
- **[CommandAliasPlugin](https://github.com/CatPoweredPlugins/CommandAliasPlugin)**, ASF asettaa mukautetun komennon aliaksia ASF komentoja.
- **[CommandlessRedeem](https://github.com/CatPoweredPlugins/CommandlessRedeem)**, plugin ASF toteuttaa avaimen lunastus ilman komentoa.
- **[ItemDispenser](https://github.com/CatPoweredPlugins/ItemDispenser)**, plugin ASF automaattisesti hyväksyä kaupan pyyntö tietyntyyppisille kohteita.
- **[SelectiveLootAndTransferPlugin](https://github.com/CatPoweredPlugins/SelectiveLootAndTransferPlugin)**, plugin ASF tarjoaa kehittyneen `siirto` komento siirtää Steam-kohteita.

### **[Sitrinaatti](https://github.com/Citrinate)**

- **[BoosterManager](https://github.com/Citrinate/BoosterManager)**, plugin ASF tarjoaa helppokäyttöinen käyttöliittymä kääntämällä jalokivet osaksi booster paketteja sekä erilaisia ominaisuuksia hallintaan inventories ja markkinalistat.
- **[CS2Interface](https://github.com/Citrinate/CS2Interface)**, ASF:n liitännäinen, jonka avulla voit olla vuorovaikutuksessa Counter-Strike 2:n kanssa käyttäen **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**.
- **[Vapaapaketit](https://github.com/Citrinate/FreePackages)**, ASF plugin joka löytää ilmaisia paketteja Steamissä ja lisää ne tilillesi.

### **[Vita](https://github.com/ezhevita)**

- **[FriendAccepter](https://github.com/ezhevita/FriendAccepter)**, ASF hyväksyy automaattisesti kaikki ystäväkutsut.
- **[GameRemover](https://github.com/ezhevita/GameRemover)**-liitännäinen, jolla ASF toteuttaa komennon Steam-lisenssien poistamiseksi valituille bottiinstansseille.
- **[GetEmail](https://github.com/ezhevita/GetEmail)**, plugin ASF toteuttaa komennon noutaa sähköpostiosoite tietyn botin instansseja suoraan Steamista.
- **[ResetAPIKey](https://github.com/ezhevita/ResetAPIKey)**, plugin ASF toteuttaa komennon nollata API-avain valituille botin instansseille.

### Muu

- **[ASFEnhance](https://github.com/chr233/ASFEnhance)**, ASF parantaa sitä eri uusia ominaisuuksia, erityisesti komentoja.
- **[ASFFreeGames](https://github.com/maxisoft/ASFFreeGames)**, ASF plugin mahdollistaa automaattisesti kerätä ilmaiseksi höyrypelejä lähetetty reddit.

---

## Integraatiot

- **[ASFBot](https://github.com/dmcallejo/ASFBot)**, pythonilla kirjoitettu telegram botti ASF integraatiolla.
- **[ASF STM userscript](https://greasyfork.org/en/scripts/404754-asf-stm)**, niille, jotka haluavat lähettää automatisoituja tarjouksia boteille meidän **[ASF STM listalle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** verkkoselaimen kautta, ilman `MatchActively` -ominaisuutta, jonka ASF tarjosi.
- **[yksinkertainen asf-bot](https://github.com/deluxghost/simple-asf-bot)**, toinen (minimaalinen) sähkö bot kirjoitettu python featuring ASF integraatio.

---

## Kirjastot

- **[ASF-IPC](https://github.com/deluxghost/ASF_IPC)**, python-kirjasto integroitavaksi ASF:n IPC-liitäntään.

---

## Pakkaus

- **[AUR repo #1](https://aur.archlinux.org/packages/asf)**, jonka avulla voit helposti asentaa ASF arkki linux.
- **[AUR repo #2](https://aur.archlinux.org/packages/archisteamfarm-bin)**, jonka avulla voit helposti asentaa ASF arkki linux.
- **[Homebrew](https://formulae.brew.sh/formula/archi-steam-farm)**, jonka avulla voit helposti asentaa ASF:n macOS:iin.
- **[Nix](https://search.nixos.org/packages?channel=unstable&show=ArchiSteamFarm&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, jonka avulla voit helposti asentaa ASF:n Nixin levyille.
- **[NixOS](https://search.nixos.org/options?channel=unstable&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, jonka avulla voit määrittää ja asentaa ASF NixOS:n kanssa.
- **[Scoop](https://scoop.sh/#/apps?q=ArchiSteamFarm)**, jolloin voit asentaa ASF:n helposti ikkunoihin.
- **[Winget](https://github.com/microsoft/winget-pkgs/tree/master/manifests/j/JustArchiNET/ArchiSteamFarm)**, jonka avulla voit asentaa ASF:n helposti ikkunoihin.

---

## Työkalut

- **[CS2Script](https://github.com/Citrinate/CS2Script)**, voit hallita Counter-Strike 2 tallennusyksikköjä **[CS2Interface](https://github.com/Citrinate/CS2Interface)** -liitännäisen avulla.
- **[avainten puristin](https://umaim.github.io/SKE)**, voit kopioida avaimet eri muodoissa ja luoda `lunastaa` komennon ASF:lle. Katso lisätietoja **[GitHub repo](https://github.com/PixvIO/SKE)**
- **[ASF Mass Config Editor](https://github.com/genesix-eu/ASF_MCE)**, jonka avulla voit hallita useita ASF configs helpommin.

---

## Haluatko lukea lisää?

Suosittelemme **[ArchiSteamFarm](https://github.com/topics/archisteamfarm)** -aihetta GitHubissa kaikkiin projekteihin, jotka integroituvat ASF:ään. Muistakaa kuitenkin, että ASF-hankkeisiin, jotka eivät liity toisiinsa, voi myös yrittää käyttää tunnistetta, yleensä itseedistäminen, joten se on aina hyvä idea kaksinkertaisen tarkistaa.