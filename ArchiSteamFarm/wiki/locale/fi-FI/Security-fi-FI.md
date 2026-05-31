# Turvallisuus

## Salaus

ASF tukee tällä hetkellä seuraavia salausmenetelmiä määritelmänä `ECryptoMethod`:

| Arvo | Nimi                           |
| ---- | ------------------------------ |
| 0    | PlainText                      |
| 1    | AES                            |
| 2    | ProtectedDataForForCurrentUser |
| 3    | YmpäristöMuuttuja              |
| 4    | Tiedosto                       |

Niiden tarkka kuvaus ja vertailu on saatavilla alla.

### Asetus

Jotta voidaan luoda salattu salasana, esim. `SteamPassword` käyttöön sinun tulee suorittaa `salata` **[komento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** valitsemallasi salauksella ja alkuperäisellä pelkkällä tekstisalasanalla. Myöhemmin laita salattu merkkijono että sinulla `SteamPassword` bot config ominaisuus, ja lopuksi muuttaa `salasanaFormat` sellaiseksi, joka vastaa valittua salausmenetelmää. Jotkin muodot eivät vaadi `-salausta` komentoa, esimerkiksi `EnvironmentVariable` tai `File`, vaan määritä niille sopiva polku.

---

### `PlainText`

Tämä on yksinkertaisin ja turvaton tapa tallentaa salasana, joka on määritelty `ECryptoMethod` ja `0` -standardin mukaisesti. ASF odottaa merkkijonon olevan pelkkä teksti - salasana sen suorassa muodossa. Se on helpoin käyttää ja 100% yhteensopiva kaikkien asetusten kanssa, siksi se on oletustapa säilyttää salaisuuksia, täysin turvaton varastointi.

---

### `AES`

Nykyisten standardien mukaan turvallisina pidetyt **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** tapa tallentaa salasanan on määritelty `ECryptoMethod` of `1`. ASF odottaa merkkijonon olevan **[base64-enkoodattu](https://en.wikipedia.org/wiki/Base64)** merkkijono, joka johtaa AES-salattuun tavutaulukkoon käännöksen jälkeen, joka sitten pitäisi purkaa käyttämällä mukana **[alustusvektori](https://en.wikipedia.org/wiki/Initialization_vector)** ja ASF salausavain.

Yllä oleva menetelmä takaa turvallisuuden niin kauan kuin hyökkääjä ei tiedä ASF:n salausavainta, jota käytetään salauksen purkamiseen ja salasanojen salaukseen. ASF mahdollistaa avaimen määrittämisen `--cryptkey` **[komentoriviargumentin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**kautta, jota sinun pitäisi käyttää maksimaalisen turvallisuuden takaamiseksi. Jos päätät jättää sen pois, ASF käyttää omaa avaintaan, joka on **tunnettu** ja kovakoodattu sovellukseen, eli kuka tahansa voi kääntää ASF salauksen ja saada salauksen salasanan. Se vaatii vielä jonkin verran työtä, eikä se ole niin helppo tehdä, mutta mahdollista, Siksi sinun pitäisi melkein aina käyttää `AES` salausta omalla `--cryptkey` joka pidetään salassa. ASF:ssa käytetty AES-menetelmä tarjoaa turvallisuutta, jonka pitäisi olla tyydyttävä ja se on tasapainossa yksinkertaisuuden `PlainText` ja monimutkaisuuden `ProtectedDataForCurrentUser`, mutta se on erittäin suositeltavaa käyttää sitä mukautetun `--cryptkey`.

Jos sitä käytetään oikein (pitkä, mukautettu `--cryptkey`), takaa turvallisen säilytyksen erittäin korkean turvallisuuden.

---

### `ProtectedDataForForCurrentUser`

Nykyisten standardien mukaan turvallisina pidetyt **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** tapa tallentaa salasana on määritelty `ECryptoMethod` of `2`. Tämän menetelmän suurin etu on samaan aikaan suurin haitta - salausavaimen käytön sijaan (kuten `AES`), tiedot on salattu kirjautumistietojen avulla tällä hetkellä kirjautuneessa käyttäjässä, mikä tarkoittaa, että on mahdollista purkaa tiedot **vain** koneella, jonka salattu on, ja sen lisäksi vain **** jonka käyttäjä on myöntänyt salauksen.

Tämä varmistaa, että vaikka lähetät koko `Bot. poika` salattu `SteamPassword` käyttäen tätä menetelmää jollekulle muulle, ne eivät voi purkaa salasanaa ilman suoraa pääsyä tietokoneeseen. Tämä on erinomainen turvatoimenpide, mutta samalla sillä on suuri haitta, että se on yhteensopimattomampi. koska salasana, joka on salattu tällä menetelmällä, ei ole yhteensopiva minkään muun käyttäjän eikä koneen kanssa - mukaan lukien **oma** jos päätät e. . asenna käyttöjärjestelmä uudelleen. Tämä on suositeltava menetelmä, jos sinun ei tarvitse käyttää configs tahansa muu kone kuin oma, ja että et myöskään vaadi koneiden välistä yhteensopivuutta.

**Huomaa, että tämä vaihtoehto on käytettävissä vain koneissa, joissa on Windows-käyttöjärjestelmä jo nyt.**

---

### `YmpäristöMuuttuja`

Muistiin perustuva tallennustila on määritelty `ECryptoMethod` of `3`. ASF lukee salasanan ympäristömuuttujasta, jonka nimi on määritelty salasanakenttään (esim. `SteamPassword`). Esimerkiksi asetus `SteamPassword` `ASF_PASSWORD_MYACCOUNT` ja `PasswordFormat` to `3` aiheuttaa ASF arvioida `${ASF_PASSWORD_MYACCOUNT}` ympäristömuuttuja ja käytä mitä tahansa sille on määritetty salasanana.

Muista varmistaa, että ASF-prosessin ympäristömuuttujat eivät ole käytettävissä luvattomilla käyttäjillä, koska se voittaa koko tarkoitus käyttää tätä menetelmää.

---

### `Tiedosto`

Tiedostopohjainen tallennustila (mahdollisesti ASF config-hakemiston ulkopuolella) on määritelty `ECryptoMethod` of `4` -järjestelmäksi. ASF lukee salasanan tiedostopolusta, joka on määritetty salasanakenttään (esim. `SteamPassword`). Määritetty polku voi olla joko ehdoton tai suhteellinen ASF:n "koti" sijaintiin (kansio, jossa on `config` -hakemiston sisällä, ottaen huomioon `--path` **[komentoriviparametri](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). Tätä menetelmää voidaan käyttää esimerkiksi **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**, jotka luovat tällaisia tiedostoja käytettäväksi, mutta voidaan käyttää myös Dockerin ulkopuolella, jos luot itse sopivan tiedoston. Esimerkiksi, asettamalla `SteamPassword` `/etc/secrets/MyAccount. ass` ja `PasswordFormat` to `4` aiheuttaa ASF lukea `/etc/secrets/MyAccount. ass` ja käytä mitä on kirjoitettu kyseiseen tiedostoon tilin salasanana.

Muista varmistaa, että luvattomat käyttäjät eivät voi lukea salasanaa sisältävää tiedostoa, koska se estää koko tämän menetelmän käytön.

---

## Salauksen suositukset

Jos yhteensopivuus ei ole ongelma sinulle, ja olet hyvä tapa miten `ProtectedDataForCurrentUser` -menetelmä toimii, se on **suositeltu** vaihtoehto tallentaa salasanan ASF, koska se tarjoaa parhaan turvallisuuden ja mukavuuden. `AES` -menetelmä on hyvä valinta ihmisille, jotka vielä haluavat käyttää konfiguraatioitaan millä tahansa koneella, jota he haluavat, kun taas `PlainText` on yksinkertaisin tapa tallentaa salasana, jos et välitä, että kukaan voi tutkia JSON konfiguraatiotiedostoa sitä varten.

Muista, että kaikkia salausmenetelmiä pidetään **epäturvallisina** , jos hyökkääjällä on pääsy tietokoneeseen. ASF on voitava purkaa salattuja salasanoja ja jos koneellasi käynnissä oleva ohjelma pystyy siihen, sitten mikä tahansa muu ohjelma käynnissä samalla koneella pystyy tekemään niin, liian. `ProtectedDataForCurrentUser` on turvallisin variantti, sillä **jopa toinen käyttäjä, joka käyttää samaa PC:tä, ei voi purkaa sitä**, mutta tietojen salauksen purkaminen on vielä mahdollista, jos joku pystyy varastamaan kirjautumistietosi ja koneen tiedot ASF asetustiedoston lisäksi.

Edistyneille kokoonpanoille voit käyttää `EnvironmentVariable` ja `File` -toimintoja. Niiden käyttökelpoisuus on rajallinen, `EnvironmentVariable` on hyvä idea, jos haluat saada salasanan jonkinlaisen mukautetun ratkaisun kautta ja tallentaa sen yksinomaan muistiin, kun `tiedosto` on hyvä esimerkiksi **[Docker salaisuuksia](https://docs.docker.com/engine/swarm/secrets)**. Molemmat ovat salaamattomia kuitenkin, joten voit periaatteessa siirtää riskin ASF asetustiedostosta mihin valitset.

Edellä määriteltyjen salausmenetelmien lisäksi on mahdollista myös välttää salasanojen määrittelyä kokonaan, Esimerkiksi `SteamPassword` käyttämällä tyhjää merkkijonoa tai `null` arvoa. ASF kysyy sinulta salasanasi, kun se on tarpeen, eikä tallenna sitä minne tahansa, mutta pidä muistia käynnissä olevasta prosessista, kunnes suljet sen. Vaikka se on turvallisin tapa käsitellä salasanoja (he eivät ole tallentanut minne tahansa), se on myös kaikkein hankalin, koska sinun täytyy syöttää salasanasi manuaalisesti kunkin ASF ajaa (kun se vaaditaan). Jos se ei ole ongelma sinulle, tämä on paras veto turvallisesti, koska et voi vuotaa jotain, mitä ei ole olemassa.

---

## Salauksen Purku

ASF ei tue mitään tapaa purkaa jo salattuja salasanoja, koska salauksen purkumenetelmiä käytetään vain sisäisesti datan käyttämiseen prosessin sisällä. Jos haluat peruuttaa salausmenettelyn, esim. siirtämällä ASF toiseen koneeseen käytettäessä `ProtectedDataForCurrentUser`, sitten yksinkertaisesti toista menettely alusta alkaen uudessa ympäristössä.

---

## Viihdytys

ASF tukee tällä hetkellä seuraavia tiivistämismenetelmiä `EHashingMethod` -menetelmän määritelmänä:

| Arvo | Nimi      |
| ---- | --------- |
| 0    | PlainText |
| 1    | SCrypt    |
| 2    | Pbkdf2    |

Niiden tarkka kuvaus ja vertailu on saatavilla alla.

### Asetus

Jotta tiiviste voidaan luoda, esim. `IPCPassword` -käytön osalta, sinun tulee suorittaa `hash` **[komento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** sopivalla nopeuttamismenetelmällä, jonka valitsit ja alkuperäisen tekstisalasanasi. Laita jälkeen hashed merkkijono, joka sinulla `IPCPassword` ASF config ominaisuus, ja lopuksi muuttaa `IPCPasswordFormat` sellaiseksi, joka vastaa valitsemaasi hashing menetelmää.

---

### `PlainText`

Tämä on yksinkertaisin ja turvaton tapa kiirehtiä salasanaa, joka määritellään `EHashingMethod` of `0` ASF luo alkuperäiseen syötteeseen vastaavan hashin. Se on helpoin käyttää ja 100% yhteensopiva kaikkien asetusten kanssa, siksi se on oletustapa säilyttää salaisuuksia, täysin turvaton varastointi.

---

### `SCrypt`

Nykyisten standardien mukaan turvallisina pidetyt **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** tapa kiirehtiä salasanan on määritelty `EHashingMethod` of `1`. ASF käyttää `SCrypt` -toteutusta käyttäen `8` -lohkoja, `8192` iteraatiota, `32` hash pituus ja salausavain suolana luodakseen joukon tavuja. Tuloksena olevat tavut koodataan sitten **[base64](https://en.wikipedia.org/wiki/Base64)** merkkijonoksi.

ASF sallii suolan määrittämisen tälle menetelmälle `--cryptkey` **[komentoriviargumentin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**kautta, jota sinun pitäisi käyttää maksimaalisen turvallisuuden. Jos päätät jättää sen pois, ASF käyttää omaa avaintaan, joka on **tunnettu** ja kovakoodattu sovellukseen, tarkoittaen hashing on vähemmän turvallinen.

Jos käytetään oikein (mukautettu suola, pitkä salasana), takaa erittäin korkean turvallisuuden turvallista varastointia.

---

### `Pbkdf2`

Nykyisten standardien vuoksi heikko **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** tapa kiirehtiä salasanan on määritelty `EHashingMethod` of `2`. ASF käyttää `Pbkdf2` -toteutusta käyttäen `10000` -iteraatiota, `32` hash pituus ja salausavain suolana, jossa `SHA-256` hmac algoritmina. Tuloksena olevat tavut koodataan sitten **[base64](https://en.wikipedia.org/wiki/Base64)** merkkijonoksi.

ASF sallii suolan määrittämisen tälle menetelmälle `--cryptkey` **[komentoriviargumentin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**kautta, jota sinun pitäisi käyttää maksimaalisen turvallisuuden. Jos päätät jättää sen pois, ASF käyttää omaa avaintaan, joka on **tunnettu** ja kovakoodattu sovellukseen, tarkoittaen hashing on vähemmän turvallinen.

---

## Hashing suositukset

Jos haluat käyttää hashing-menetelmää joidenkin salaisuuksien tallentamiseen, kuten `IPCPassword`, Suosittelemme käyttämään `SCrypt` mukautettua suolaa, koska se tarjoaa erittäin kunnollisen turvallisuuden brute-pakkoyrityksiä vastaan.

`Pbkdf2` on saatavilla vain yhteensopivuussyistä, pääasiassa siksi, että meillä on jo toimiva (ja tarpeellinen) toteutus muihin käyttötarkoituksiin eri puolilla Steam-alustaa (e. . vanhempien kynät). Sitä pidetään edelleen turvallisena, mutta heikkona vaihtoehtoihin verrattuna (esim. `SCrypt`).