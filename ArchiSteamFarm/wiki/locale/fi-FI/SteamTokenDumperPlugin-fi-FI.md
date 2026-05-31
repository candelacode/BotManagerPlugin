# SteamTokenDumperPlugin -laajennus

`SteamTokenDumperPlugin` on virallinen ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** kehittämämme jonka avulla voit osallistua **[SteamDB](https://steamdb.info)** projekti jakamalla pakettipoletteja, sovelluspoletteja ja depot-avaimia, joihin Steam-tilisi voi käyttää. Laajennetut tiedot kerätyistä tiedoista ja miksi SteamDB tarvitsee niitä löytyvät SteamDB:n **[Token Dumper](https://steamdb.info/tokendumper)** sivulta. Lähetettyihin tietoihin ei sisälly mitään potentiaalisesti arkaluonteisia tietoja, eikä niillä ole mitään turvallisuusriskiä, kuten edellä kuvatussa kuvauksessa todetaan.

---

## Liitännäisen käyttöönotto

ASF mukana `SteamTokenDumperPlugin` niputetaan yhdessä julkaisu, mutta itse plugin on oletuksena pois päältä. Voit ottaa liitännäisen käyttöön asettamalla `SteamTokenDumperPluginEnabled` ASF globaali asetusominaisuus `true`, JSON syntaksissa:

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

Käynnistettäessä ASF ohjelma, plugin kertoo sinulle, onko se otettu käyttöön onnistuneesti standardin ASF kirjaaminen mekanismi. Voit myös ottaa plugin käyttöön web-pohjaisen config generator.

---

## Tekniset tiedot

Kun käytössä, plugin käyttää botteja että olet käynnissä ASF tietojen keräämiseen muodossa pakettikuponkia, sovelluspoletteja ja depot-avaimia, joihin boteillasi on pääsy. Tietojen keruumoduuli sisältää passiivisia ja aktiivisia rutiineja, joiden on tarkoitus minimoida tietojen keräämisen aiheuttama lisäajo.

Jotta suunniteltu käyttötapaus voitaisiin täyttää, edellä kuvatun tiedon keräämisen lisäksi tietojen toimittaminen rutiininomaisesti aloitetaan, koska se on vastuussa siitä, mitä tietoja on toimitettava SteamDB:lle säännöllisesti. Tämä rutiini palaa `1` tunnin kuluessa ASF:n alkamisesta ja toistaa itsensä joka `24` tunnin välein. Plugin tekee parhaansa minimoida määrä tietoja, jotka on lähetettävä, siksi on mahdollista, että joitakin tietoja, jotka plugin kerää määritetään hyödyttömiä toimittaa, ja siksi ohitettu (esimerkiksi sovelluspäivitys, joka ei muuta käyttötunnusta).

Liitännäinen käyttää pysyvää välimuistitietokantaa, joka on tallennettu `config/SteamTokenDumper.cache` -sijaintiin, joka palvelee samaa tarkoitusta kuin ASF:lle `config/ASF.db`. Tiedostoa käytetään kerättyjen ja lähetettyjen tietojen tallentamiseen ja sen työn määrän minimoimiseen, joka on tehtävä eri ASF-ajojen välillä. Tiedoston poisto aiheuttaa prosessin uudelleenkäynnistyksen tyhjästä, jota on vältettävä mahdollisuuksien mukaan.

---

## Tiedot

ASF sisältää tietolähteen `steamID` pyynnössä, joka on määritetty `SteamOwnerID` jonka asetit ASF:ään, tai jos et ole tehnyt, botin Steam-tunnus, joka omistaa useimmat lisenssit. Ilmoitettu rahoittaja saattaa saada SteamDB:ltä joitakin lisäetuja jatkuvaan apuun (e. . lahjoittaja listalla verkkosivuilla), mutta se on täysin SteamDB:n harkinnan mukaista.

Joka tapauksessa SteamDB henkilökunta haluaisi kiittää sinua etukäteen avustasi. Toimitettujen tietojen avulla SteamDB voi käyttää erityisesti seuratakseen paketteja koskevia tietoja, sovellukset ja varikot, jotka eivät enää olisi mahdollisia ilman apuasi.

---

## Komento

STD plugin comes with an extra ASF command, `std [Bots]`, which allows you to trigger refresh and submission for selected bots on demand. Komennon käyttö ei vaadi konfigurointia, jonka avulla voit ohittaa automaattisen keräämisen ja lähettämisen ja hallita prosessia manuaalisesti. Luonnollisesti se voidaan myös suorittaa käytössä config, joka yksinkertaisesti laukaista tavallisen keräily- ja toimittamismenettelyt odotettua aikaisemmin.

Suosittelemme `!std ASF` käynnistääksesi päivityksen kaikille käytettävissä oleville boteille. Voit kuitenkin myös laukaista sen valituille, jos haluat.

---

## Kehittynyt asetus

Meidän plugin tukee kehittyneitä config joka voi tulla hyödyllinen ihmisille, jotka haluavat nipistää sisäiset mieltymyksensä.

Kehittyneen kokoonpanon rakenne sijaitsee `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Enabled": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretPackageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Kaikki vaihtoehdot on selitetty alla:

### `Käytössä`

`bool` tyyppi oletusarvo `false`. Tämä ominaisuus toimii samoin kuin `SteamTokenDumperPluginEnabled` juuritason ominaisuuden edellä selitetty ja sitä voidaan käyttää, omistettu ihmisille, jotka haluaisivat olla koko plugin-liittyvä config omassa rakenteessaan (niin todennäköisimmin ne, jotka jo käyttävät muita kehittyneitä ominaisuuksia selitetään alla).

---

### `SecretAppID:t`

`ImmutableHashSet<uint>` tyyppi, jonka oletusarvo on tyhjä. Tämä ominaisuus määrittää `appIDs` jota plugin ei ratkaise, ja jos ne on jo ratkaistu, ei lähetä tunnusta. Tämä ominaisuus voi olla hyödyllinen ihmisille, joilla on mahdollisuus tutustua julkaisemattomiin kohteisiin, erityisesti kehittäjiin, kustantajiin tai suljettuihin beetatestaajiin.

---

### `SecretDepotID:t`

`ImmutableHashSet<uint>` tyyppi, jonka oletusarvo on tyhjä. Tämä ominaisuus määrittää `depotIDs` , että plugin ei ratkaista, ja jos ne on jo ratkaistu, ei lähetä avain. Tämä ominaisuus voi olla hyödyllinen ihmisille, joilla on mahdollisuus tutustua julkaisemattomiin kohteisiin, erityisesti kehittäjiin, kustantajiin tai suljettuihin beetatestaajiin.

---

### `SecretPackageID:t`

`ImmutableHashSet<uint>` tyyppi, jonka oletusarvo on tyhjä. Tämä ominaisuus määrittää `pakettitunnukset` (tunnetaan myös nimellä `alatunnukset`), jota liitännäinen ei ratkaise, ja jos ne on jo ratkaistu, ei lähetä tunnusta. Tämä ominaisuus voi olla hyödyllinen ihmisille, joilla on mahdollisuus tutustua julkaisemattomiin kohteisiin, erityisesti kehittäjiin, kustantajiin tai suljettuihin beetatestaajiin.

---

### `SkipAutoGrantPackages`

`bool` tyyppi, jonka oletusarvo on `true`. Tämä ominaisuus toimii hyvin samankaltaisesti kuin `SecretPackageIDs` ja kun se on käytössä, aiheuttaa sen, että `AutoGrant` :n `EPaymentMethod` -paketit ohitetaan ratkaisurutiinin aikana. `AutoGrant` -maksutapaa käyttää **[Steamworks](https://partner.steamgames.com)** myöntääkseen automaattisesti paketteja kehittäjän tileille. Vaikka tämä ei ole yhtä selvää kuin muut `Salainen` -vaihtoehdot, eikä siis takaa mitään (koska sinulla voi olla muita paketteja kuin `AutoGrant` joita et vieläkään halua toimittaa), sen pitäisi olla tarpeeksi hyvä sivuuttamaan suurin osa salaisista paketeista, ellei jopa kaikki. Tämä asetus on oletusarvoisesti käytössä, koska ihmiset, joilla on pääsy `AutoGrant` -paketteihin, eivät juuri koskaan halua vuotaa niitä suurelle yleisölle, ja sen vuoksi `false` -arvon käyttäminen on hyvin tilannellista.

---

## Lisäselvitykset

Perimmäisellä tasolla jokainen Steam-tili omistaa joukon paketteja (lisenssit, tilaukset), jotka on luokiteltu niiden `-paketin` (tunnetaan myös nimellä `alatunniste`). Jokainen paketti voi sisältää useita sovelluksia, jotka niiden `appID` on luokitellut . Jokaiseen sovellukseen voi sitten sisältyä useita `depotID` -luokituksen mukaisia varikoita.

```text
¶ ¶ sub/124923
¶ ¶ app/292030
¶ ¼ depot/292031
¶ ¼ depot/378648
¶ ¶ ...
¶ • app/378649
¶ • ...
└── ...
```

Meidän plugin sisältää kaksi rutiineja, joissa otetaan huomioon ohitetut kohteet - ratkaista rutiini ja lähetyksen rutiini.

Ratkaisu rutiini on vastuussa ratkaista puu voit nähdä edellä. Paketit/sovellukset/varikot etukäteen mustalle listalle voit leikata puuta tehokkaasti mustalla listatulla oksalla/lehdellä ilman, että tarvitsee täsmentää sen jäljellä olevat osat. Yllä olevassa esimerkissämme, jos pakettia `124923` ei huomioitu, joko `SecretPackageIDs` tai `SkipAutoGrantPackages`, ja se oli ainoa oma paketti, joka liittyy `292030` appID, sitten appID `292030` ei ratkaistu myöskään, ja määritelmän mukaan, jos ei ollut muita ratkaistuja sovelluksia, jotka liittyivät `292031` ja `378648` varikkoihin, sitten he eivät selviäisi myöskään. Pidä kuitenkin mielessä, että jos plugin on jo ratkaissut puun, niin tehokkaasti tämä vain lopettaa tietyn kohteen päivittämisen (esim. uudet sovellukset lisätty), se ei tee plugin "unohtaa" olemassa olevista kohteista, jotka oli jo ratkaistu (e. . apps found in that package before you decided to blacklist it). Jos olet juuri ottanut käyttöön joitakin ohitusvaihtoehtoja, ja haluaa varmistaa, että ASF ei harjoita jo ratkaistua puuta, voit harkita kertaluonteinen poistaminen `config/SteamTokenDumper. ache` tiedosto, jossa plugin pitää sen välimuisti.

Lähetys rutiini on vastuussa lähettämällä pakettipoletteja, sovelluspoletteja ja depot näppäimiä jo ratkaistu kohteita (ratkaisemalla rutiini edellä). Täällä mustalla listalla on välitön vaikutus, sillä vaikka plugin on jo ratkaissut tiedot, toimittaminen rutiini ei itse asiassa lähetä sitä SteamDB jos olet mustalla listalla, riippumatta siitä, onko se ratkaistu tai ei. Pidä kuitenkin mielessä, että emme puhu puu enää tässä vaiheessa, lähetys rutiini ei tiedä, tuleeko sovellusta koskevat tiedot tästä tai tuosta paketista, joten se vain ohittaa tietoa erityisesti mustalla listalla kohteita, riippumatta suhteesta he ovat muiden kanssa.

Suurin osa kehittäjistä ja kustantajista, riittää pitämään `SkipAutoGrantPackages` käytössä, mahdollisesti valtuutettu vain `SecretPackageIDs` koska se tehokkaasti leikkaa puun alussa haara ja takaa, että sovellukset ja varikot edelleen ei saa lähettää niin kauan kuin muuta pakettia linkittää samaan sovellukseen. Jos haluat olla kaksinkertainen, lisäksi voit käyttää myös `SecretAppIDs`, joka ohittaa sovelluksen ratkaisun, vaikka on olemassa joitakin muita lisenssejä, joita et ole mustalla listalla. Käyttämällä `SecretDepotIDs` ei pitäisi olla tarpeen, ellei sinulla ole erityistä erityinen tarve (kuten vain tietyn varaston ohittaminen vielä lähettäessä tietoja paketeista ja sovelluksista), tai jos haluat lisätä vielä yksi kerros on kolminkertainen turvallinen.