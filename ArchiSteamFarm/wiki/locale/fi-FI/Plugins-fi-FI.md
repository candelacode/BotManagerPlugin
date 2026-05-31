# Liitännäiset

ASF sisältää tuen mukautetuille liitännäisille, joita voidaan ladata ajon aikana. Liitännäisten avulla voit muokata ASF käyttäytymistä, esimerkiksi lisäämällä mukautettuja komentoja, mukautetun kaupankäynnin logiikkaa tai koko integraation kolmannen osapuolen palveluihin ja APIin.

Tällä sivulla kuvataan ASF liitännäiset käyttäjien näkökulmasta - selitys, käyttö ja samoin. Jos haluat tarkastella kehittäjän näkökulmaa, siirrä **[tässä](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)** sen sijaan.

---

## Käyttö

ASF lataa liitännäiset `plugins` -hakemistosta, joka on sijoitettu ASF kansioon. Se on suositeltu käytäntö (joka tulee pakolliseksi plugin automaattinen päivitys) säilyttää oma hakemisto jokaiselle plugin että haluat käyttää, joka voi perustua pois sen nimi, kuten `MyPlugin`. Näin johtaa lopullinen puu rakenne `plugins/MyPlugin`. Lopuksi, kaikki binaaritiedostot plugin pitäisi laittaa sisällä, että oma kansio, ja ASF oikein löytää ja käyttää plugin uudelleenkäynnistyksen jälkeen.

Yleensä liitännäisten kehittäjät julkaisevat plugins muodossa `zip` tiedosto binäärien sisällä, mikä tarkoittaa, että sinun pitäisi purkaa zip-tiedosto omaan alakansioon `plugins` -hakemiston sisällä.

Jos plugin ladattiin onnistuneesti, näet sen nimen ja version lokissa. Sinun pitäisi keskustella plugin kehittäjät jos kysymyksiä, ongelmia tai käyttöä liittyvät plugins että olet päättänyt käyttää.

Löydät joitakin esiteltyjä liitännäisiä meidän **[kolmannen osapuolen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** osiossa.

**Huomaa, että ASF liitännäiset voivat olla ilkivaltaisia**. Sinun pitäisi aina varmistaa, että käytät liitännäisiä tekemät kehittäjät, joihin voit luottaa, jopa ne kolmannen osapuolen osiosta. ASF kehittäjät eivät voi enää taata sinulle tavanomaisia ASF etuja (kuten haittaohjelmistojen puute tai VAC-vapaa) jos päätät käyttää mukautettuja liitännäisiä. Sinun täytyy ymmärtää, että liitännäiset ovat täysin hallinnassa ASF prosessi kun ladattu, koska emme voi myös tukea asetuksia, jotka käyttävät mukautettuja plugins, koska et enää käynnissä vanilja ASF koodi.

---

## Yhteensopivuus

Riippuen pluginin monimutkaisuudesta, laajuudesta ja paljon muita tekijöitä, on täysin mahdollista, että sinun täytyy käyttää **[geneerinen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** ASF -variantti, sen sijaan, että suositeltaisiin **[OS-spesifinen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. Tämä johtuu siitä, että OS-spesifinen variantti sisältää vain ASF:n itsensä tarvitsemat ydintoiminnot. ja plugin voi vaatia osia, jotka eivät kuulu tärkein ASF soveltamisalaa, seurauksena on yhteensopimaton trimmed OS-erityisiä rakennuksia.

Yleensä, kun käytät kolmannen osapuolen laajennuksia, suosittelemme käyttämään ASF geneerinen variantti maksimaalisen yhteensopivuuden. Kuitenkin kaikki liitännäiset eivät ehkä vaadi sitä - katso lisäosan tiedot, jotta voit selvittää, pitääkö sinun käyttää yleistä ASF varianttia vai ei.

---


## Automaattiset päivitykset

ASF on sisäänrakennettu mekanismi liitännäisten automaattiset päivitykset. For that feature to work, first of all, your plugin of choice needs to **[support](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)** that mechanism. Jos olet ladannut plugin, joka tukee automaattisia päivityksiä, ASF ilmoittaa sen lokissa asianmukaisesti aikana plugin alustus, kuten "liitännäinen on poistettu käytöstä automaattisista päivityksistä" tai "liitännäinen on rekisteröity ja otettu käyttöön automaattisia päivityksiä".

By default, automatic updates for custom plugins are **disabled**, due to security reasons. Voit määrittää automaattisia päivityksiä config käyttämällä **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** ja/tai **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)**suosittelemme lukemaan kuvauksen niistä config ominaisuudet lisätietoja. On myös mukava huomata, että kuten ASF päivitykset, voit päättää pitää automaattiset päivitykset poissa käytöstä ja sitten päivittää tarvittaessa. manuaalinen perusta, myöntämällä `updateplugins` **[komento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

Molemmat lähestymistavat voit päivittää ei mitään, jotkut tai kaikki mukautetut plugins että olet ladannut prosessiin.