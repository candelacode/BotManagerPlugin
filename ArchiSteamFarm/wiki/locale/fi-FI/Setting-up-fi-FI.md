# Aloittaminen

Jos olet täällä ensimmäistä kertaa, Tervetuloa! Olemme erittäin iloisia nähdessämme jälleen yhden matkustajan, joka on kiinnostunut projektistamme, vaikka muistaa, että suuri valta tulee suuri vastuu - ASF pystyy tekemään paljon erilaisia Steamin liittyviä tehtäviä, mutta vain niin kauan kuin **hoitaa tarpeeksi oppia käyttämään sitä**. Todellakin, lukeminen wiki, Noudattamalla ohjeitamme ja oppimalla lisää erilaisista ASF-konsepteista saat lopulta palkintoja ainutlaatuisella taidolla käyttää yhtä tehokkaimmista Steam-työkaluista jo nykyäänkin.

Suosittelemme sinua tekemään **yhden asian kerrallaan**. ASF koskettaa monia eri näkökohtia, joista jotkut ovat melko triviaaleja, muut voivat olla liian monimutkaisia. Sinun ei tarvitse ymmärtää tai lukea kaikkea kerralla, ja suosittelemme todella ottamaan sen helposti. Rentoutua, valitse itse juoma valinnanvaraa, omistaa tunnin aikaa ja sukeltaa luentoomme - voimme luvata, että se on hyvin aikaa arvoinen.

Aloitetaan perusasiat - ASF on konsolisovellus sen periaatteessa, mikä tarkoittaa, että se ei automaattisesti luoda graafinen käyttöliittymä, johon olet yleisesti tottuneet. ASF on yleinen sovellus, joka toimii pääasiassa palveluna (taustasovellus) eikä työpöytäsovelluksena. Yksi sen pääkäyttötapauksista on se, että palvelinkoneilla on ajettavana, mihin työpöytäsovellukset ovat täysin sopimattomia. Se pitää vain ohjelman ehdotonta ydintä vaikka, koska ASF itse asiassa **ei** sisällytä omaa graafista käyttöliittymäänsä - sisäänrakennetun ASF-ui frontendin muodossa, mutta tulemme alas tuohon osaan hyvissä ajoin - olemme juuri mainitsemassa tämän heti, jotta et paniikkia nähdessäsi mustaa konsolinäyttöä tai jotain.

Kun saat ASF binary tiedostoja, ohjelma vaatii konfiguraatio sinulta, joka määrittelee, mitä odotat ASF saavuttaa. Voit käynnistää ohjelman ilman konfiguraatiota, tässä tapauksessa ASF käynnistää oletusasetukset, jolloin voit käyttää e. . ASF-ui alustavaan määritykseen, mutta muu kuin se, että se ei tee paljoakaan ilman aikaisempaa toimintaa.

Se tehdään nyt, aloitetaan!

---

## Käyttöjärjestelmättäinen käyttöönotto

Yleisesti ottaen tässä on, mitä teemme seuraavien minuuttien aikana:
- Asennamme **[.NET Edellytykset](#net-prerequisites)**.
- Sitten ladataan **[uusin ASF julkaisu](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** sopivassa OS-spesifisessä versiossa.
- Seuraavaksi puretaan arkisto uuteen paikkaan.
- Sitten **[konfiguroidaan ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- Ja lopuksi, me käynnistää ASF ja nähdä sen taikuutta.

Jotkut vaiheet ovat itsestään selviä, muut vaativat enemmän huomiota teiltä. Älä huoli, olemme peittäneet sinut.

---

### .NET edellytykset

Ensimmäiseksi pitää varmistaa voiko käyttöjärjestelmälläsi edes käynnistää ASF kunnolla. Sinun ei tarvitse tietää sitä, mutta ASF on kirjoitettu C#, perustuu . ET -alusta ja saattaa vaatia kotimaisia kirjastoja, jotka eivät ole vielä saatavilla alustallasi. Ajattele sitä kuten DirectX:ää 3D-pelejä varten tai auton käynnistämistä varten.

Riippuen siitä, käytätkö Windows, Linux tai macOS, sinulla on erilaisia vaatimuksia. Viiteasiakirja on **[. ET Edellytykset](https://docs.microsoft.com/dotnet/core/install)**, mutta yksinkertaisuuden vuoksi olemme myös yksityiskohtaisesti kaikki tarvittavat paketit alla, joten sinun ei tarvitse lukea sitä lainkaan, ellet joudu ongelmiin tai sinulla on lisäkysymyksiä.

On täysin normaalia, että järjestelmässäsi on jo olemassa joitakin (tai jopa kaikkia) riippuvuuksia, koska käytät kolmannen osapuolen ohjelmistoja, joita käytät. Silti sen ei tarvitse olla tapaus, joten sinun pitäisi käyttää asianmukaista asentajaa käyttöjärjestelmässäsi - ilman näitä riippuvuuksia ASF ei käynnisty lainkaan, ja saat tuskin mitään hyödyllistä tietoa kertoa sinulle mitä on vialla.

Muista, että sinun ei tarvitse tehdä mitään muuta OS-erityisiä rakennuksia, erityisesti asentaminen. ET SDK tai jopa ajoaika, koska OS-erityinen paketti sisältää kaikki tämä jo. Tarvitset vain .NET Edellytykset (riippuvuudet) ajaa . ET ajoaika sisältyy ASF - niin vain asioita, jotka määrittelemme alla, ilman muita lisäyksiä.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** 64-bitille, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** 32-bittiselle tai **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** 64-bit ARM)
- On erittäin suositeltavaa varmistaa, että kaikki Windows-päivitykset on jo asennettu. Jos niitä ei ole käytössä, sitten ainakin tarvitset **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** ja **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, mutta lisää päivityksiä saattaa olla tarpeen. Sinun ei tarvitse huolehtia siitä, että jos Windows on ajan tasalla, tai ainakin viimeisin tarpeeksi.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Paketin nimet riippuvat käyttämästäsi Linux-jakelusta, olemme lisänneet kaikkein yleisimmät jakelut. Voit hankkia ne kaikki omaperäisen pakettihallinnan kautta käyttöjärjestelmässäsi (kuten `apt` Debianille tai `yum` CentOS:lle). Nämä ovat melko vakiomuotoisia kirjastoja, joiden pitäisi olla saatavilla riippumatta siitä, mitä käytät, Kyse on vain siitä, miten heitä kutsutaan valinnanvaraisessa ympäristössäsi.

- `ca-sertifikaatit` (vakio luotettu SSL-sertifikaatti HTTPS-yhteyksien luomiseksi)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, uusin versio jakelustasi, esimerkiksi `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-libs`, uusin versio jakelustasi, vähintään `1.1.X`)
- `libstdc++6` (`libstdc++`, versiossa `5.0` tai uudempi)
- `zlib1g` (`zlib`)

Ainakin suurimman osan näistä pitäisi olla jo syntyperäisesti saatavilla järjestelmässäsi. Esimerkiksi, minimaalinen asennus Debian-stabiili vaatii yleensä vain `libicu76`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- Et tarvitse mitään erityisesti, mutta sinulla pitäisi olla uusin versio macOS, vähintään 12.0+

---

### Lataaminen

Koska meillä on jo kaikki tarvittavat riippuvuudet, seuraava vaihe on ladata **[viimeisin ASF julkaisu](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF on saatavilla monissa versioissa, mutta olet kiinnostunut paketista, joka vastaa käyttöjärjestelmää ja arkkitehtuuria. Esimerkiksi, jos käytät `64`-bit `Win`dows, niin haluat `ASF-win-x64` paketin. Jos haluat lisätietoja saatavilla olevista vaihtoehdoista, käy **[yhteensopivuus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** -osiossa. ASF pystyy myös toimimaan ympäristöissä, joita emme rakenna OS-spesifistä pakettia varten, kuten **32-bittinen Windows**, mutta tarvitset **[geneerisiä asetuksia](#generic-setup)**.

![Laitteet](https://i.imgur.com/Ym2xPE5.png)

Latauksen jälkeen aloita zip-tiedoston purkamisesta omaan kansioon. Jos tarvitset tietyn työkalun siihen, **[7-zip](https://www.7-zip.org)** tekee, mutta kaikki tavalliset apuohjelmat, kuten sisäänrakennettu Windows-louhinta tai `unzip` Linux/macOS:sta.

Ole suositeltavaa purkaa ASF **omaan hakemistoonsa** eikä mihinkään olemassa olevaan hakemistoon, jota jo käytät johonkin muuhun - se on tärkeää. ASF sisältää automaattisen päivityksen ominaisuus, joka korvaa sen omat tiedostot, ja joka yleensä poistaa kaikki vanhat ja liittymättömät tiedostot päivityksen yhteydessä, mikä puolestaan voi johtaa siihen, että menetät mitään liittymätöntä asetat ASF hakemistoon. Jos sinulla on ylimääräisiä skriptejä tai tiedostoja, joita haluat käyttää ASF: llä, se ei ole ongelma, luoda oma kansio niille, voit aina laittaa ASF yhteen kansioon syvemmälle.

Esimerkki rakenne voisi näyttää tältä:

```text
C:\ASF (johon laitat omat asiat)
    ¶ MyNotes. xt (valinnainen)
    ¶ AsfMakeMeCoffeeScript.bat (valinnainen)
    ¶ (... (kaikki muut valinnaiset tiedostot, valinnainen)
    ☐ Core (omistettu vain ASF:lle, jossa poimia arkisto)
         ¶ ArchiSteamFarm (. xe)
         - config
         - logit
         - plugins
         - www
         - (...)
```

---

### Konfigurointi

Olemme nyt valmiita tekemään viimeisen vaiheen, konfiguraatio. ASF toimii "bottien" konseptin kanssa, jokainen botti on yleensä yksi Steam-tili, jota haluat käyttää ASF:n sisällä. Voit julistaa niin monta bottia kuin haluat, mutta aloittelijalle keskitymme vain yhteen niistä - yleensä päätiliisi. ASF on myös ei-botin asetustiedostoja, tärkein on yleinen asetustiedosto, joka vaikuttaa kaikkiin bootteihin instanssissa.

Peukalon yleinen sääntö on, että **jos et tiedä tai ymmärrä joitakin asetuksia, sinun pitäisi jättää se sen oletusarvo muuttamatta mitään**. ASF tarjoaa lukemattomia tapoja konfiguroida, muokata ja nipistää lähes kaikki ominaisuudet, mutta kuten edellä mainittiin, yrittää ymmärtää sitä heti lepakko on kanin reikä, joka voi nopeasti vetää sinut vakavaan sekaannukseen, jos ei **[suoraan kuilun](https://www.youtube.com/watch?v=KK3KXAECte4)**. Sen sijaan suosittelemme ensin toimivaa esimerkkiä, ja vasta sitten alkaa kaivaa lisävaihtoehtoja, **[konfiguraation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** avulla wikissä kun vaihdat **yhtä asiaa kerrallaan**.

ASF konfiguraatio voidaan tehdä useilla tavoilla - kautta sisäänrakennettu ASF-ui frontend, itsenäinen web config generaattori, tai manuaalisesti. Tämä selitetään syvyydessä **[kokoonpanossa](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** , joten viittaa, että jos haluat tarkempia tietoja. Käytämme itsenäistä web config generaattori lähtökohtana, koska se toimii vaikka jostain syystä ASF-ui ei käynnisty tai toimi oikein.

Mene meidän **[web config generator](https://justarchinet.github.io/ASF-WebConfigGenerator)** sivu suosikki selaimella. Suosittelemme Chromea tai Firefoxia, mutta sillä ei pitäisi olla väliä niin kauan kuin selaimesi toimii kaiken muun osalta.

Sivuston avaamisen jälkeen vaihda "Bot"-välilehteen. Sinun pitäisi nyt nähdä samanlainen sivu kuin alla:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Jos sattumalta versio ASF että olet juuri ladattu on vanhempi kuin mitä config generaattori on asetettu oletusarvoisesti, yksinkertaisesti valita ASF versio pudotusvalikosta. Tämä voi (harvinainen) tapahtua, koska config generaattori voidaan tuottaa configs uudempia (pre-release) ASF versioita, joita ei ole merkitty vakaiksi vielä. Olet ladannut viimeisimmän vakaan ASF:n julkaisun, joka on todennettu toimivan luotettavasti, joten se voi olla hieman vanhempi kuin absoluuttinen huippuluokan versio, joka ei täysin sovellu ensimmäiseen käyttöön.

Aloita **laittamalla nimi botti** kenttään merkitty punaisena, nimeltään `Nimi`. Tämä voi olla mikä tahansa nimi, jota haluat käyttää, kuten lempinimesi, tilin nimi, numero tai mikä tahansa muu. On vain yksi sana jota et voi käyttää, `ASF`, koska tämä avainsana on varattu maailmanlaajuiselle asetustiedostolle. Lisäksi botti nimi ei voi alkaa pisteellä (ASF tahallisesti ohittaa noita tiedostoja). Suosittelemme myös, että vältät käyttämästä välilyöntejä, voit käyttää `_` sananerotinta tarvittaessa - ei tiukkaa vaatimusta, mutta sinulla on vaikeaa aikaa käyttää ASF komentoja muuten.

Botti nimi päätetty? Suuri seuraavassa vaiheessa, **muutos `Käytössä` kytkin on**, että yksi määrittää, onko botti pitäisi aloittaa ASF automaattisesti käynnistämisen jälkeen (ohjelman). Ei näin ollen ASF ilmoittaa, että botti on poistettu käytöstä asetustiedostossa ja se odottaa, että syötteesi aloittaa sen, mikä ei ole sitä, mitä haluamme tehdä tässä esimerkissä.

Seuraavaksi on tulossa kaksi herkkää ominaisuutta: `SteamLogin` ja `SteamPassword`. Voit tehdä toisen päätöksen täällä - joko voit laittaa Steam-kirjautumistiedot näihin kahteen ominaisuuteen, tai voit päättää olla tekemättä sitä, jättäen ne tyhjäksi.

ASF vaatii kirjautumistietojasi, koska se sisältää Steam-asiakkaan oman toteutuksen ja tarvitsee samat tiedot kirjautuakseen sisään kuin se, jota käytät itse. Kirjautumistietojasi ei tallenneta minne tahansa vaan tietokoneellesi ASF `config` -hakemistossa (kun lataat generoidun config -asetuksen). Web-config generaattori on asiakaspohjainen sovellus, joka tarkoittaa, että kaikki mitä teet sisällä meidän itsenäinen web config-generaattori sivusto on käynnissä paikallisesti selaimessasi luoda voimassa ASF configs, ilman tietoja olet syöttää koskaan jättää tietokoneen ensin, joten ei tarvitse huolehtia mahdollisista arkaluonteisia tietoja vuotaa. Jos kuitenkin jostain syystä et halua laittaa valtakirjoja sinne, ymmärrämme sen, ja voit laittaa ne manuaalisesti myöhemmin luotuja tiedostoja, tai jättää ne kokonaan ja toimia ilman niitä.

Jos päätät syöttää käyttäjätunnuksesi, ASF voi kirjautua automaattisesti sisään käynnistyksen aikana, joka yhdessä valinnainen 2FA tehokkaasti voit vain kaksoisnapsauttamalla ohjelmaa suorittaa kaiken. Jos päätät jättää ne pois, sitten ASF **pyytää sinua** syöttämään nämä tiedot tarvittaessa - tämä lähestymistapa ei tallenna niitä minne tahansa, mutta ASF ei luonnollisesti pysty toimimaan ilman apuasi. Se on sinulle mikä tapa haluat enemmän, ja voit myös löytää lisätietoja **[asetukset](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** -osiossa, kuten tavallisesti.

Kuten puoli huomata, voit myös päättää jättää vain yhden kentän tyhjäksi, kuten `SteamPassword`. ASF voi sitten käyttää kirjautumisesi automaattisesti, mutta pyytää tarvittaessa salasanaa (samanlainen kuin Steam-asiakas). Jos sattumalta käytät 4-numeroista vanhempien pinniä avata tili, suosittelemme myös laittamaan sen `SteamParentalPin` -laatikkoon, vaikka myös tässä tapauksessa voit vain jättää tämän tyhjäksi, ja sen sijaan tarkkailla kuinka heikko, että suojelu on, koska ASF voi myös "murtaa" itse vain muutamassa sekunnissa sisäänkirjautumisen jälkeen. Hups.

Seuraamisen jälkeen kaikki edellä, niin jälleen kerran, **botti nimi**, **käytössä kytkin**, ja **kirjautumistiedot** , Web-sivusi näyttää nyt samalta kuin alla:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Voit nyt lyödä "download"-painiketta ja meidän web config generaattori luo uuden `json` tiedosto perustuu valitsemallasi nimellä. Tallenna tiedosto `config` -hakemistoon, joka sijaitsee kansiossa, jonka sisällä olet poistanut zip-tiedoston edellisestä vaiheesta.

Onnittelut! Olet juuri suorittanut ASF bot kokoonpanon. On paljon enemmän löytää, mutta nyt tämä on kaikki mitä tarvitset.

---

### ASF:n käynnistys

Tiedän, että olet odottanut tätä hetkeä, emmekä voi pitää sinua pidempään, kun olet nyt valmis käynnistämään ohjelman ensimmäistä kertaa. Yksinkertaisesti kaksoiskaksoiskappale `ArchiSteamFarm` binary ASF-hakemistossa. Voit myös aloittaa sen konsolista.

Nyt olisi hyvä aika tarkastella meidän **[etäviestintää](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** -osiota, jos olet huolissasi siitä, että ASF on ohjelmoitu, erityisesti toiminnot, jotka se tekee nimessäsi, kuten liittyminen Steam-ryhmäämme oletuksena. Voit aina poistaa valitut toiminnot käytöstä myöhemmin, jos et pidä niistä, ASF yksinkertaisesti tulee järkeviä oletuksia, ja meidän täytyi tehdä joitakin päätöksiä yleisestä käytöstä, joka koskee suurin osa käyttäjäperustamme, sekä oman näkemyksemme ohjelmasta sen periaatteessa.

Olettaen kaikki meni hyvin, joka enimmäkseen pitää asentaa kaikki tarvittavat riippuvuudet ensimmäisessä vaiheessa, ja konfigurointi ASF kolmannessa ASF pitäisi käynnistää kunnolla, löytää ensimmäinen bot, ja yrittää kirjautua:

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF vaatii todennäköisesti vielä yhden yksityiskohdan sinulta - 2FA päästäksesi tiliin (ellet ole poistanut SteamGuardin kokonaan, sitten ei). Yksinkertaisesti seuraa ruudulla olevia ohjeita, voit antaa koodin tunnistautumisesta/sähköpostiosoitteesta tai hyväksyä vahvistuksen mobiilisovelluksessa.

Jokin meni pieleen?

#### ASF ei aloita lainkaan, ei konsoli-ikkunaa

Joko olet kadonnut .NET -edellytykset tai olet ladannut konetta varten väärän ASF-vaihtoehdon. Jos et tiedä mikä on vialla, tarkista meidän **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** jotta voit selvittää tarkan ongelman, ja jos olet edelleen jumissa, saavuta **[tuki](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### Botteja ei määritelty

You didn't put generated config into the `config` directory. Joitakin muita yleisiä virheitä tässä vaiheessa voi olla manuaalisesti muuttaa laajennus `.json` esim. `. xt`, ja jotkut käyttöjärjestelmät (esim. Ikkunat), kuten piilottaa yhteisiä laajennuksia oletuksena, joten varmista, että tiedosto on oikeassa paikassa ja myös sopiva nimi.

#### Tätä bottia ei aloiteta, koska se on poistettu käytöstä asetustiedostossa

Unohdit kääntää `Käytössä olevan` kytkimen, joka kertoo ASF käynnistämään botin automaattisesti. Ellei se tietenkään ollut teidän aikomuksenne, mutta silloin teidän pitäisi jo osata suorittaa komentoja, yksinkertaisesti `käynnistä` botti viestin jälkeen.

#### `Virheellinen Salasana`

Kirjautumistietosi ovat mitä todennäköisimmin väärässä. Tarkista `SteamLogin` ja `SteamPassword` generoidussa configissa, jos he ovat väärässä, korjaa ne palaamalla konfiguraatiovaiheeseen. Jos sinulla on yhä ongelmia, yritä käyttää samoja kirjautumistunnuksia omassa Steam-asiakasohjelmassasi - sinun ei pitäisi myöskään kirjautua sisään, ja ehkä saat enemmän tietoa mikä on väärin tällä tavalla.

#### Kaikki hyvää?

Kun olet läpäissyt alkuperäisen kirjautumisportin, jos tietosi ovat oikeita, kirjaudut sisään onnistuneesti, ja ASF aloittaa maanviljelyn käyttämällä oletusasetuksia, joihin et koskettanut nyt:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Tämä osoittaa, että ASF on nyt menestyksekkäästi tekemässä työtään tililläsi, joten voit nyt minimoida ohjelman ja tehdä jotain muuta. Mene eteenpäin, olet ansainnut sen, ehkä täyttää, että juoma valintasi ainakin!

Maanviljelyskortit ovat aiheena toinen pitkä artikkeli näin, mutta periaatteessa: riittävän ajan jälkeen (riippuen **[suorituskyvystä](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), näet Steam kaupankäynnin kortteja hitaasti pudotetaan. Of course, for that to happen you must have valid games to farm, showing as "you can get X more card drops from playing this game" on your **[badges page](https://steamcommunity.com/my/badges)** - if there are no games to farm, then ASF will state that there is nothing to do, as stated in our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, which answers the most common question people have at this point, wondering why despite owning whopping 14 games on their account, ASF claims there's nothing to do - no, it's not a bug.

Tähän päättyy hyvin perustavanlaatuinen perustavanlaatuinen oppaamme. Kuten jokaisessa RPG pelissä, olet suorittanut opetusohjelman, ja jätämme sinut koko ASF maailma tutkia nyt. Voit esimerkiksi nyt päättää, haluatko asettaa ASF:n pidemmälle, tai antaa sen tehdä työnsä oletusasetuksissa. Me peitämme vielä muutamia perustietoja, jos haluat lukea hieman enemmän, niin jätä koko wiki löytääksesi.

---

### Laajennettu konfiguraatio

#### Maatalous useita tilejä kerralla

ASF tukee useamman kuin yhden tilin viljelyä aikana, joka on sen ensisijainen tehtävä. Voit lisätä lisää tilejä ASF:ään luomalla lisää bottiasetustiedostoja, täsmälleen samalla tavalla kuin olet luonut ensimmäisen vain muutama minuutti sitten. Sinun täytyy varmistaa vain kaksi asiaa:

- Ainutlaatuinen botin nimi, jos sinulla on jo ensimmäinen botti nimeltä `Päätili`, sinulla ei voi olla toista samaa nimeä.
- Voimassa olevat kirjautumistiedot, kuten `SteamLogin`, `SteamPassword` ja `SteamParentalCode` (jos olet päättänyt täyttää ne)

Toisin sanoen, yksinkertaisesti hypätä konfigurointi uudelleen ja tehdä täsmälleen sama, vain toinen tai kolmas tili. Muista käyttää yksilöllisiä nimiä kaikille bottiisi, jotta ei ylikirjoiteta olemassa olevia confiksejä.

---

#### Asetusten muutto

Meidän itsenäinen web config-generaattori, voit muuttaa olemassa olevia asetuksia täsmälleen samalla tavalla - luomalla uuden config tiedosto. Klikkaa "vaihda edistyneitä asetuksia" ja katso mitä voit löytää. Tässä esimerkissä muutamme `CustomGamePlayedWhileFarming` -asetusta, jonka avulla voit asettaa mukautetun nimen näkyviin, kun ASF on viljelemässä, sen sijaan, että näyttäisi todellista peliä.

Analysoidaan tämä ensin hieman. Jos käytät ASF:ää ja aloitat maanviljelyn, huomaat oletusasetuksissa, että Steam-tilisi on nyt pelissä:

![Steam](https://i.imgur.com/1VCDrGC.png)

Se on järkevää, kun kaikki ASF juuri kertoi Steam-alustalle, että pelaamme peliä, tarvitsemme kortteja siitä, eikö? Mutta hei, voimme muokata tätä! Ota käyttöön lisäasetukset, jos et ole vielä valmis, ja etsi sitten `CustomGamePlayedWhileFarming`. Yksinkertaisesti laittaa mukautetun tekstin, jonka haluat näyttää siellä, kuten "Idling kortit":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Lataa nyt uusi asetustiedosto täsmälleen samalla tavalla, ja sitten **korvaa** vanhan asetustiedoston uudella tiedostolla. Voit myös poistaa vanhan asetustiedoston ja laittaa uuden sen tilalle tietenkin.

ASF on melko fiksu ja sen pitäisi huomata, että olet muuttanut config, jonka pitäisi sitten automaattisesti poimia ja soveltaa, ilman ohjelman uudelleenkäynnistys. Jos jokin sattuma, että ei tapahdu, voit yksinkertaisesti käynnistää ohjelman uudelleen, jotta uusi config poimitaan. Sen jälkeen sinun pitäisi huomata, että ASF näyttää nyt mukautetun tekstin edellisessä paikassa:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

Tämä vahvistaa, että olet onnistuneesti muokannut config. täsmälleen samalla tavalla voit muuttaa globaaleja ASF ominaisuuksia, vaihtamalla bottivälilehdestä "ASF"-välilehteen, lataamalla luodun `ASF. poika` config-tiedosto ja laita se `config-` hakemistoon.

ASF asetusten muokkaaminen voidaan tehdä paljon helpommaksi käyttämällä ASF-ui frontend, joka selitetään tarkemmin alla.

---

#### ASF-uin käyttäminen

Kuten edellä mainittiin, ASF on konsoli sovellus ja ei käynnistä graafista käyttöliittymää oletuksena. Työskentelemme kuitenkin aktiivisesti **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** -frontenssissä meidän IPC-käyttöliittymällemme, joka voi olla erittäin kunnollinen ja käyttäjäystävällinen tapa käyttää erilaisia ASF ominaisuuksia.

Jotta voit käyttää ASF-uia, sinulla on oltava `IPC` käytössä, joka on oletusasetus, joten ellet manuaalisesti poista sitä, se on jo aktiivinen. Kun käynnistät ASF, sinun pitäisi pystyä vahvistamaan, että se kunnolla aloitti IPC-käyttöliittymän automaattisesti:

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC, pähkinänkuoressa, on sisäänrakennettu ASF web-palvelin, joka alkaa paikallisesti koneellasi, jonka avulla voit olla vuorovaikutuksessa sen kanssa suosikkiverkkoselaimesi avulla. Olettaen, että se alkoi oikein, voit käyttää ASF:n IPC-rajapintaa napsauttamalla **[tätä](http://localhost:1242)** -linkkiä, niin kauan kuin ASF on käynnissä, samasta koneesta. Voit käyttää ASF-uia erilaisiin tarkoituksiin, esim. paikan päällä olevien asetustiedostojen muokkaamiseen tai **[komentojen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** lähettämiseen. Voit vapaasti katsoa ympärillesi, jotta voit selvittää kaikki ASF-ui toiminnot.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Yhteenveto

Olet onnistuneesti perustanut ASF:n käyttämään Steam-tilejäsi ja olet jo muokannut sen mielellesi hieman. Jos seurasit koko oppaamme, onnistuit myös muokkaamaan ASF:ää ASF-ui-käyttöliittymämme kautta ja aloit löytää sen toiminnallisuudet. Tämä lopettaa meidän opetusohjelma, mutta jätämme sinut joitakin lisäosoittimia juttuja, että saatat olla kiinnostunut "sivutehtävät", jos vaaditte:

- Meidän **[konfiguraatio](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** -osio selittää sinulle mitä **kaikki** ne eri asetukset, jotka olet nähnyt oikeasti tekevän, ja mitä muuta ASF voi tarjota sinulle. Muista vain nesteyttää kunnolla lukemisen aikana, sinua on varoitettu.
- Jos olet kompastunut johonkin ongelmaan tai sinulla on jokin yleinen kysymys, harkitse meidän **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**, jonka pitäisi kattaa kaikki, tai ainakin valtaosa kysymyksistä ja asioista, joita sinulla voi olla.
- Jos haluat oppia kaiken ASF ja miten se voi tehdä elämästäsi helpompaa, pää yli muiden **[meidän wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. Käytä sivupalkkia on oikeus valita aihe, joka kiinnostaa sinua.
- Ja lopuksi jos olet saanut selville meidän ohjelma on hyödyllinen sinulle ja arvostat valtava määrä työtä, joka on tehty siihen, voit myös harkita pieni **[lahjoitus](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** meidän syytä. ASF on rakkauden työntekijä, olemme tehneet kovasti töitä vapaa-ajallamme viimeisten 10 vuoden ajan, jotta tämä kokemus on mahdollista sinulle, ja olemme erittäin ylpeitä siitä - jopa $ 1 on erittäin arvostettu ja osoittaa, että välität. Joka tapauksessa on paljon hauskaa!

---

## Yleiset asetukset

Tämä liite on edistyneille käyttäjille, jotka haluavat asettaa ASF:n toimimaan **[geneerisessä](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)** -versiossa. Vaikka käyttö on ongelmallisempaa kuin **[OS-spesifiset variantit](#os-specific-setup)**, sillä on myös lisäetuja.

Haluat käyttää `geneeristä` varianttia pääasiassa kun:
- Käytät käyttöjärjestelmää että emme rakenna OS-erityistä pakettia (kuten 32-bittinen Windows)
- Sinulla on jo .NET Runtime/SDK, tai haluat asentaa ja käyttää yhtä
- Haluat minimoida ASF rakennekoon ja muistin jalanjäljen käsittelemällä itse ajoaikaa koskevat vaatimukset
- Haluat käyttää mukautettua **[liitännäistä](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** joka vaatii `geneerisen` ASF toiminnon kunnolla (koska natiivi riippuvuudet puuttuvat)

Tietenkin voit käyttää sitä myös missä tahansa muussa skenaariossa haluat, mutta edellä on järkeä.

Pidä kuitenkin mielessä, että geneeriset asetukset sisältävät käänteen - **sinä** ovat vastuussa .NET ajoajasta tässä tapauksessa. Tämä tarkoittaa, että jos .NET SDK (runtime) ei ole käytettävissä, vanhentunut, tai rikki, ASF yksinkertaisesti ei toimi. Siksi emme täysin suosittele tätä asetusta rento käyttäjille, koska sinun täytyy nyt varmistaa, että . ET SDK (runtime) vastaa ASF vaatimuksia ja voi ajaa ASF, vastakohtana **us** varmistaa, että . ET ajoaika niputetaan ASF voi tehdä niin.

`geneeriselle` -paketille voit seurata koko OS-spesifistä opasta vain kahdella pienellä muutoksella. Sen lisäksi, että asennat .NET Edellytykset, haluat myös asentaa .NET SDK, ja sen sijaan, että lataat ja ottaa OS-spesifisen `ArchiSteamFarm (. xe)` suoritettava tiedosto, voit nyt ladata ja sinulla on geneerinen `ArchiSteamFarm.dll` binary vain. Kaikki muu on täsmälleen samaa.

Ylimääräiset vaiheet:
- Asenna **[.NET Edellytykset](#net-prerequisites)**.
- Asenna **[.NET SDK](https://www.microsoft.com/net/download)** (tai vähintään ASP.NET Core ja .NET suoritukset) käyttöjärjestelmäsi sopivaksi. Todennäköisesti haluat käyttää asentajaa. Katso **[ajoaika vaatimukset](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** jos et ole varma minkä version asentaa.
- Lataa **[viimeisin ASF julkaisu](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** `geneerinen` versio.
- Pura arkisto uuteen sijaintiin.
- **[Määritä ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**täsmälleen samalla tavalla kuin edellä on kuvattu.
- Käynnistä ASF joko käyttämällä apukomentosarjaa tai suorittamalla `dotnet /path/to/ArchiSteamFarm.dll` manuaalisesti suosikkikuoresta.

ASF:n tavanomaisessa versiossa ei ole konekohtaista binääriä, kun kaikki sitä kutsutaan `geneerinen` syystä - se on platform-agnostinen rakennus, joka voi toimia kaikkialla, joten älä odota `exe` tiedostoa siellä.

Tämän vuoksi olemme liittäneet sen apukomentosarjoihin (kuten `ArchiSteamFarm.cmd` Windowsille ja `ArchiSteamFarmille. h` Linux/macOS), jotka sijaitsevat vieressä `ArchiSteamFarm.dll` binary. Voit käyttää niitä, jos et halua suorittaa `dotnet` -komentoa manuaalisesti.

On selvää, auttaja skriptit eivät toimi, jos et asenna. ET SDK ja sinulla ei ole `dotnet` suoritettavaa `PATH`. They're also entirely optional to use, you can always `dotnet /path/to/ArchiSteamFarm.dll` manually if you'd like to, as under the hood with some extra tweaks, that's exactly what those scripts are doing anyway.