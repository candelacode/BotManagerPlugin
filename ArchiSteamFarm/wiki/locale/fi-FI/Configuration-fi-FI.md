# Konfigurointi

Tämä sivu on omistettu ASF-konfiguraatioille. Se toimii täydellisenä dokumentaationa `config` -hakemistossa, jonka avulla voit virittää ASF:ää tarpeisiisi.

* **[Johdanto](#introduction)**
* **[Web-pohjainen Konfiguraatio](#web-based-configgenerator)**
* **[ASF-ui asetukset](#asf-ui-configuration)**
* **[Manuaalinen määritys](#manual-configuration)**
* **[Yleiset asetukset](#global-config)**
* **[Bot config](#bot-config)**
* **[Tiedoston rakenne](#file-structure)**
* **[JSON kartoitus](#json-mapping)**
* **[Yhteensopivuuden kartoitus](#compatibility-mapping)**
* **[Yhteensopivuus konfigurojen kanssa](#configs-compatibility)**
* **[Automaattinen Uudelleenlataus](#auto-reload)**

---

## Johdanto

ASF konfiguraatio on jaettu kahteen pääosaan - globaali (prosessi) konfiguraatio, ja konfiguraatio jokaisen botin. Jokaisella botti on oma botti asetustiedosto nimeltä `BotName. poika` (jossa `BotName` on bottien nimi), kun taas yleinen ASF (process) konfiguraatio on yksi tiedosto nimeltä `ASF. poika`.

Botti on yksi höyry tili, joka osallistuu ASF prosessiin. Jotta ASF toimisi kunnolla, se tarvitsee vähintään **yhden** määritellyn bottiesiintymän. Ei ole mitään prosessivalvottua rajaa bottiesiintymiä, joten voit käyttää niin monta bottia (höyrytilejä) kuin haluat.

ASF käyttää **[JSON](https://en.wikipedia.org/wiki/JSON)** -formaattia asetustiedostojen tallentamiseen. Se on ihmisystävällinen, luettavissa ja hyvin universaali muoto, jossa voit määrittää ohjelman. Älä kuitenkaan huoli, sinun ei tarvitse tietää JSON, jotta voit määrittää ASF. Mainitsin juuri sen, jos haluat jo luoda massan ASF configs jonkinlainen bash script.

Konfiguraatio voidaan tehdä monin tavoin. Voit käyttää meidän **[Web-pohjainen ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)**, joka on paikallinen sovellus riippumaton ASF. Voit käyttää meidän **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC frontend konfiguraatio tehdään suoraan ASF. Lopuksi, voit aina luoda config-tiedostoja manuaalisesti, koska ne noudattavat kiinteää JSON rakennetta määritetty alla. Selitämme pian käytettävissä olevat vaihtoehdot.

---

## Web-pohjainen Konfiguraatio

Tarkoituksena meidän **[Web-pohjainen ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** on tarjota sinulle ystävällinen frontend jota käytetään tuottamaan ASF asetustiedostoja. Web-pohjainen ConfigGenerator on 100% asiakaslähtöinen, mikä tarkoittaa, että syötön tietoja ei lähetetä missään, mutta käsitellään vain paikallisesti. Tämä takaa turvallisuuden ja luotettavuuden. koska se voi jopa toimia **[offline](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** jos haluat ladata kaikki tiedostot ja suorita `indeksi. tml` suosikkiselaimessasi.

Web-pohjainen ConfigGenerator on vahvistettu toimimaan oikein Chromessa ja Firefoxissa, mutta sen pitäisi toimia oikein kaikissa suosituimmissa javascript-yhteensopiviissa selaimissa.

Käyttö on melko yksinkertainen - valitse haluatko luoda `ASF` tai `Bot` config vaihtamalla oikean välilehden, varmista, että valittu asetustiedoston versio vastaa ASF julkaisuasi, ja syötä kaikki tiedot ja paina "download"-painiketta. Siirrä tämä tiedosto ASF `config` -hakemistoon, tarvittaessa korvaa olemassa olevat tiedostot. Toista kaikki mahdolliset lisämuutokset ja viittaa tämän osan loppuosaan, jotta selitetään kaikki konfiguraation käytettävissä olevat vaihtoehdot.

---

## ASF-ui asetukset

Meidän **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC käyttöliittymän avulla voit määrittää myös ASF ja on ylivoimainen ratkaisu ASF:n uudelleenmäärittämiseen sen jälkeen, kun alkuperäinen config on luotu, koska se voi muokata confis paikalla, toisin kuin Web-pohjainen ConfigGenerator, joka luo niitä staattisesti.

Jotta voit käyttää ASF-uia, meidän **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** -käyttöliittymämme on aktivoitu itse. `IPC` on oletusarvoisesti käytössä, joten voit käyttää sitä heti, kunhan et itse poistanut sitä käytöstä.

Ohjelman käynnistämisen jälkeen navigoi ASF:n **[IPC-osoitteeseen](http://localhost:1242)**. Jos kaikki toimii kunnolla, voit muuttaa ASF konfiguraatiota siellä.

---

## Manuaalinen määritys

Yleisesti ottaen suosittelemme käyttämään joko meidän ConfigGenerator tai ASF-ui, koska se on paljon helpompaa ja varmistaa, et tee virhettä JSON rakenteessa, mutta jos jostain syystä et halua, voit myös luoda oikea configs manuaalisesti. Tarkista JSON-esimerkit alla ja aloita hyvä rakenne kunnolla, voit kopioida sisällön tiedostoon ja käyttää sitä pohjana sinun config . Koska et käytä mitään meidän frontends, varmista, että config on **[kelvollinen](https://jsonlint.com)**, koska ASF kieltäytyy lataamasta sitä, jos sitä ei voida jäsentää. Vaikka se olisi kelvollinen JSON, sinun on myös varmistettava, että kaikki ominaisuudet ovat oikeantyyppisiä, kuten ASF vaatii. Kaikkien käytettävissä olevien kenttien JSON-rakenteen osalta katso **[JSON-kartoitus](#json-mapping)** -osio ja alla oleva dokumentaatiomme.

---

## Yleiset asetukset

Global config sijaitsee `ASF.json` tiedostossa ja sillä on seuraava rakenne:

```json
{
    "AutoRestart": true,
    "Blacklist": [],
    "CommandPrefix": "! ,
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "Nykykulttuuri": null,
    "Debug": false,
    "DefaultBot": null,
    "FarmingDelay": 15,
    "FilterBadBots": true,
    "GiftsLimiterDelay": 1,
    "Headless": false,
    "IdleFarmingPeriod": 8,
    "InventoryLimiterDelay": 4,
    "IPC": true,
    "IPCPassword": null,
    "IPCPasswordFormat": 0,
    "LicenseID": null,
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldDuration": 15,
    "MinFarmingDelayAfterBlock": 60,
    "Optimointitila": 0,
    "PluginsUpdateList": [],
    "PluginsUpdateMode": 0,
    "ShutdownIfPossible": false,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Kaikki vaihtoehdot on selitetty alla:

### `Automaattisen Uudelleenkäynnistyksen`

`bool` tyyppi, jonka oletusarvo on `true`. Tämä ominaisuus määrittelee, onko ASF sallittua käynnistää itsensä uudelleen, kun se on tarpeen. On olemassa muutamia tapahtumia, jotka vaativat ASF itsensä uudelleenkäynnistys, kuten ASF päivitys (tehty `UpdatePeriod` tai `päivitä` komento) sekä `ASF. poika` config muokkaa, `käynnistä` komento ja samoin. Tyypillisesti, uudelleenkäynnistys sisältää kaksi osaa - luoda uuden prosessin, ja viimeistely nykyinen yksi. Useimpien käyttäjien pitäisi olla hyvin sen kanssa ja pitää tämä ominaisuus oletusarvo `true`, however - if you running ASF through your own script and/or with `dotnet`, saatat haluta saada täyden hallinnan prosessin aloittamisesta, ja välttää tilanne, kuten uusi (uudelleenkäynnistetty) ASF prosessi käynnissä jonnekin hiljaisesti taustalla, eikä käsikirjoituksen edustalla, joka päättyi yhdessä vanhan ASF-prosessin kanssa. Tämä on erityisen tärkeää, kun otetaan huomioon, että uusi prosessi ei ole enää suora lapsi, mikä tekisi sinut mahdottomaksi. . käyttää standardi konsoli syöte sitä.

Jos näin on, tämä ominaisuus, jos erityisesti sinulle ja voit asettaa sen `false`. Pidä kuitenkin mielessä, että tällaisessa tapauksessa **olet** vastuussa prosessin uudelleenkäynnistämisestä. Tämä on jotenkin tärkeää, sillä ASF poistuu vain uuden prosessin asemesta (esim. päivityksen jälkeen), joten jos sinulla ei ole lisättyä logiikkaa, se yksinkertaisesti lakkaa toimimasta, kunnes aloitat sen uudestaan. ASF poistuu aina asianmukaisella virhekoodilla, joka osoittaa onnistumisen (nolla) tai epäonnistumisen (ei-nolla), Näin voit lisätä oikean logiikan skriptissäsi, joka pitäisi välttää automaattista uudelleenkäynnistämistä ASF jos epäonnistuu, tai tee vähintään paikallinen kappale `-lokista. xt` lisäanalyysejä varten. Pidä myös mielessä, että `uudelleenkäynnistys` -komento käynnistyy aina ASF:n uudelleen riippumatta siitä, miten tämä ominaisuus on asetettu, koska tämä ominaisuus määrittää oletustoiminnon, kun taas `käynnistä` komento aina käynnistää prosessin uudelleen. Ellei sinulla ole syytä poistaa tätä ominaisuutta, sinun pitäisi pitää se käytössä.

---

### `Mustalista`

`ImmutableHashSet<uint>` tyyppi, jonka oletusarvo on tyhjä. Kuten nimestä voi päätellä, tämä globaali config ominaisuus määrittää sovellustunnukset (pelit), jotka jätetään kokonaan huomiotta automaattisen ASF viljelyprosessissa. Valitettavasti Steam rakastaa lippu kesä / talvi myynti merkit "saatavilla kortteja pudota", joka sekoittaa ASF prosessi tekemällä uskoa, että se on voimassa peli, joka olisi viljeltävä. Jos ei ollut mitään mustaa listaa, ASF olisi lopulta "roikkua" maatalouden peli, joka ei itse asiassa ole peli, ja odota äärettömän paljon kortteja pudota, että ei tapahdu. ASF-mustalla listalla on tarkoitus merkitä kyseiset merkit sellaisiksi, ettei niitä voida käyttää viljelyyn, niin voimme hiljaa sivuuttaa heidät päättäessämme, mitä tilalle, emmekä joudu ansaan.

ASF sisältää oletusarvoisesti kaksi mustaa listaa - `SalesBlacklist`, joka on kovakoodattu ASF koodi ja ei ole mahdollista muokata, ja normaali `Blacklist`, joka on määritelty tässä. `SalesBlacklist` päivitetään yhdessä ASF-version kanssa, ja tyypillisesti se sisältää kaikki "huonot" appidit julkaisuhetkellä, Joten jos käytät ajan tasalla ASF niin sinun ei tarvitse ylläpitää omaa `Blacklist` on määritelty täällä. Tämän omaisuuden päätarkoitus on antaa sinulle mustalle listalle uusia, tuntemattomia ASF julkaisun appIDs, jota ei pitäisi viljellä. Koodattu `MyymäläMustalista` päivitetään mahdollisimman nopeasti, siksi sinun ei tarvitse päivittää omaa `Blacklist` jos käytät viimeisintä ASF versiota, mutta ilman `Blacklist` sinun olisi pakko päivittää ASF "jatkaa" kun Valve julkaisee uuden myyntimerkin - En halua pakottaa sinua käyttämään uusinta ASF-koodia, siksi tämä ominaisuus on täällä antaa sinulle "korjaaminen" ASF itse, jos jostain syystä et halua tai voi, päivittää uusiin kovakoodattuihin `myyntiMustalistalle` uudessa ASF-julkaisussa, mutta silti haluat pitää vanhan ASF:n käynnissä. Ellei sinulla ole **vahvaa** syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

Jos etsit bottipohjaista mustaa listaa sen sijaan, katso `fb`, `fbadd` ja `fbrm` **[komentoja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `Komentoetuliite`

`merkkijono` oletusarvo `!`. Tämä ominaisuus määrittää **tapausherkän** etuliitteen, jota käytetään ASF **[komentoihin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Toisin sanoen, tämä on mitä sinun on käytettävä ennen jokaista ASF-komentoa, jotta ASF kuuntelee sinua. It's possible to set this value to `null` or empty in order to make ASF use no command prefix, in which case you input commands with their plain identifiers. Kuitenkin tekemällä niin mahdollisesti vähentää ASF:n suorituskykyä, koska ASF on optimoitu olemaan jäsentämättä viestiä pidemmälle, jos se ei käynnistä `CommandPrefix` - jos päätät tarkoituksella olla käyttämättä sitä, ASF pakotetaan lukemaan kaikki viestit ja vastaamaan niihin, vaikka ne eivät ole ASF-komentoja. Tämän vuoksi on suositeltavaa käyttää `komentoetuliitettä`, kuten `/` jos et pidä `oletusarvosta!`. Johdonmukaisuuden osalta `komentoetuliite` vaikuttaa koko ASF-prosessiin. Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `VahvistuksetLimiterDelay`

`tavu`-tyyppi, jonka oletusarvo on `10`. ASF varmistaa, että kahden peräkkäisen 2FA-vahvistuksen välillä on vähintään `ConfirmationsLimiterDelay` -sekuntia kahden peräkkäisen 2FA-vahvistuksen välillä, jotta vältytään nostamasta korkoa – **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** käyttää niitä e aikana. . `2faok` komento sekä tarpeen mukaan suoritettaessa erilaisia kaupankäyntiin liittyviä toimintoja. Oletusarvo määritettiin testiemme perusteella eikä sitä pitäisi alentaa, jos et halua puuttua ongelmiin. Ellei sinulla ole **vahvaa** syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `Yhteyden Aikakatkaisu`

`tavu`-tyyppi, jonka oletusarvo on `90`. Tämä ominaisuus määrittää kellonajat eri verkkotoimintoja varten ASF sekunnissa. Erityisesti `ConnectionTimeout` määrittää aikakatkaisun sekunteina HTTP- ja IPC-pyyntöjen osalta, `ConnectionTimeout / 10` määrittelee epäonnistuneiden sykkeiden enimmäismäärän, kun taas `ConnectionTimeout / 30` määrittelee kuinka monta minuuttia annamme ensimmäisen Steamin verkkoyhteyspyynnön. Oletusarvo `90` pitäisi olla hyvä valtaosa ihmisistä, kuitenkin, jos sinulla on melko hidas verkkoyhteys tai PC, saatat haluta lisätä tämän numeron johonkin korkeampaan (kuten `120`). Muista, että isommat arvot eivät maagisesti korjaa hitaita tai edes saavuttamattomia Steam-palvelimia, joten meidän ei pitäisi loputtomasti odottaa jotain, joka ei tapahdu ja yksinkertaisesti yritä myöhemmin uudelleen. Tämän arvon asettaminen liian korkeaksi johtaa verkkoihin liittyvien kysymysten ratkaisemisen liialliseen viivästymiseen ja yleisen suorituskyvyn heikkenemiseen. Tämän arvon liian alhainen asettaminen heikentää yleistä vakautta ja suorituskykyä, koska ASF keskeyttää pätevän pyynnön edelleen jäsennettynä. Tämän arvon asettaminen oletusarvoa pienemmäksi ei sen vuoksi hyödy yleensä, koska Steam-palvelimet ovat yleensä erittäin hitaita ajoittain, ja voi vaatia enemmän aikaa jäsentämiseen ASF pyynnöt. Oletusarvo on tasapaino sen välillä, että uskomme, että verkkoyhteytemme on vakaa, ja epäilemme Steam-verkossa, että voimme käsitellä pyyntöämme tietyssä ajassa. Jos haluat havaita ongelmat ennemmin ja tehdä ASF uudelleenyhdistää/reagoida nopeammin, Oletusarvon tulisi olla (tai hyvin hieman alempi, kuten `60`, mikä vähentää potilaan ASF:tä). Jos sen sijaan huomaat, että ASF on menossa verkko-ongelmiin, kuten epäonnistuneet pyynnöt, sydämen lyönnit katoavat tai yhteys Steamiin keskeytyy, on luultavasti järkevää lisätä tätä arvoa, jos olet varma, että se on **ei** aiheuttama verkkosi, mutta Steam itse, koska yhä aikakatkaisut tekee ASF enemmän "potilas" ja ei päätä yhdistää heti.

Esimerkkinä tilanne, joka voi vaatia tämän omaisuuden lisäämistä, antaa ASF käsitellä erittäin valtava kaupan tarjouksia, jotka voivat kestää yli 2+ minuuttia täysin hyväksyä ja hoitaa Steam. Nostamalla oletusaikaa ASF on kärsivällisempi ja odottaa kauemmin ennen kuin päätetään, että kauppa ei mene läpi ja luopua alkuperäisestä pyynnöstä.

Toinen tilanne voi johtua hyvin hitaasta kone- tai internetyhteydestä, joka vaatii enemmän aikaa siirrettävien tietojen käsittelemiseen. Tämä on melko harvinainen tila, koska CPU/verkon kaistanleveys on lähes koskaan pullonkaula, mutta silti mahdollisuus mainita.

Lyhyesti sanottuna, oletusarvon pitäisi olla kunnon useimmissa tapauksissa, mutta voit halutessasi lisätä sitä tarvittaessa. Silti menee paljon yli oletusarvo ei ole järkevää myöskään, koska isompi aikakatkaisu ei maagisesti korjata saavuttamattomia Steam-palvelimia. Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `Nykyinen Kulttuuri`

`merkkijono` jonka oletusarvo on `null`. Oletuksena ASF yrittää käyttää käyttöjärjestelmän kieltä, ja mieluummin käyttää käännettyjä merkkijonoja tällä kielellä, jos saatavilla. Tämä on mahdollista yhteisömme ansiosta, joka yrittää **[lokalisoida](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** ASF kaikilla suosituimmilla kielillä. Jos jostain syystä et halua käyttää käyttöjärjestelmäsi äidinkieltä, voit käyttää tätä config ominaisuutta valitaksesi minkä tahansa kelvollisen kielen, jota haluat käyttää sen sijaan. Jos haluat luettelon kaikista käytettävissä olevista kulttuureista, käy **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** ja etsi `kielen tunnus`. On mukava huomata, että ASF hyväksyy molemmat kulttuurit kuten `"en-GB"`, mutta myös neutraaleja, kuten `"en"`. Nykyisen kulttuurin määrittäminen vaikuttaa myös muuhun kulttuurikohtaiseen käyttäytymiseen, kuten valuutta-/päiväysmuotoon ja niin edelleen. Huomioithan, että saatat tarvita lisää kirjasin/kielipaketteja kielikohtaisten merkkien näyttämiseksi kunnolla, jos olet valinnut ei-äidinkielisen kulttuurin, joka käyttää niitä. Tyypillisesti haluat käyttää tätä config omaisuutta, jos haluat ASF Englanti sijaan oman äidinkielen.

---

### `Vianetsintä`

`bool` tyyppi oletusarvo `false`. Tämä ominaisuus määrittelee, onko prosessi suoritettava vianjäljitystilassa. Kun vianjäljitystilassa ASF luo erityisen `virheenjäljityksen` hakemiston `config`viereen , joka pitää kirjaa koko viestinnästä ASF:n ja Steam-palvelimien välillä. Vianjäljitystiedot voivat auttaa havaitsemaan ikäviä kysymyksiä, jotka liittyvät verkostoitumiseen ja yleiseen ASF työnkulkuun. Sen lisäksi, että jotkut ohjelma rutiinit on paljon verbose, kuten `WebBrowser` ilmoittaa tarkan syyn miksi jotkin pyynnöt epäonnistuvat - nuo merkinnät on kirjoitettu tavalliseen ASF-lokiin. **Sinun ei pitäisi käyttää ASF:ää vianetsintätilassa, ellei kehittäjä** sitä pyytä. Käynnissä ASF virheenkorjaustilassa **vähentää suorituskykyä**, **vaikuttaa vakauteen negatiivisesti** ja on **paljon enemmän verbose eri paikoissa**, joten sitä olisi käytettävä **vain tarkoituksellisesti** lyhyellä aikavälillä, virheenjäljityksen erityisongelmaan, toistetaan ongelma tai saada lisätietoja epäonnistuneesta pyynnöstä ja niin edelleen, mutta **ei** normaalin ohjelman suorittamiseen. You will see **a lot** of new errors, issues, and exceptions - make sure that you have a decent knowledge about ASF, Steam and its quirks if you decide to analyze all of that yourself, as not everything is relevant.

**VAROITUS:** tämän tilan käyttöönotto sisältää kirjautumisen **mahdollisesti arkaluontoisiin** tietoihin, kuten kirjautumisiin ja salasanoihin, joita käytät kirjautuessasi Steamiin (verkkokirjautumisen vuoksi). Nämä tiedot on kirjoitettu sekä `debug` -hakemistoon että standardiin `lokiin. xt` (se on nyt tarkoituksellisesti paljon verbose kirjautua tähän tietoon). Sinun ei pitäisi julkaista ASF:n tuottamaa vianjäljityssisältöä missään julkisessa paikassa, ASF-kehittäjän tulisi aina muistuttaa sinua lähettämästä se sähköpostiisi tai muuhun turvalliseen sijaintiin. Emme säilytä emmekä käytä noita arkaluonteisia yksityiskohtia, ne on kirjoitettu osana debug rutiineja, koska niiden läsnäolo voi olla merkityksellistä ongelma, joka vaikuttaa sinuun. Olisimme parempia, jos et muuttaisi ASF kirjautumista millään tavalla, mutta jos olet huolissasi, voit punnita nämä arkaluonteiset tiedot asianmukaisesti.

> Redacting edellyttää arkaluonteisten yksityiskohtien korvaamista esimerkiksi tähdillä. Teidän pitäisi pidättäytyä kokonaan poistamasta arkaluontoisia linjoja, koska niiden puhdas olemassaolo voi olla merkityksellistä ja se pitäisi säilyttää.

---

### `OletusBotti`

`merkkijono` jonka oletusarvo on `null`. Joissakin skenaarioissa ASF toiminnot konsepti oletusbotin vastuulla käsitellä jotain - esimerkiksi IPC komentoja tai interaktiivinen konsoli, kun et määritä kohde botti. Tämän ominaisuuden avulla voit valita oletusbotin vastuussa tällaisten skenaarioiden käsittelystä laittamalla sen `BotName` tähän. Jos annettu botti ei ole olemassa tai käytät oletusarvoa `null`, ASF valitsee sen sijaan ensin rekisteröidyn bot-lajitellun aakkosjärjestyksen. Tyypillisesti haluat käyttää tätä config ominaisuutta, jos haluat jättää pois `[Bots]` argumentin IPC ja interaktiivinen konsoli komentoja, ja aina valita sama botti kuin oletuksena yksi tällaisille puheluille.

---

### `FarmingDelay`

`tavu`-tyyppi, jonka oletusarvo on `15`. Jotta ASF toimii, se tarkistaa tällä hetkellä viljellyn pelin joka `FarmingDelay` minuuttia, jos se ehkä putosi kaikki kortit jo. Tämän kiinteistön liian alhainen asettaminen voi johtaa liialliseen höyryjen pyyntöjen lähettämiseen, kun asetus on liian korkea, voi johtaa ASF edelleen "maanviljelys" annettu otsikko `FarmingDelay` minuuttia sen jälkeen, kun se on täysin viljelty. Oletusarvon pitäisi olla erinomainen useimmille käyttäjille, mutta jos sinulla on monta bottia käynnissä, voit harkita sen lisäämistä jotain `30` minuuttia, jotta voidaan rajoittaa höyrypyyntöjen lähettämistä. On mukava huomata, että ASF käyttää tapahtumapohjaista mekanismia ja tarkistaa pelin kunniamerkki sivu jokaisen Steam-kohteen pudotettu, joten yleensä **meidän ei edes tarvitse tarkistaa se kiintein aikavälein**, mutta koska emme täysin luota Steam-verkkoon - tarkistamme pelin kunniamerkkisivun joka tapauksessa, jos emme tarkista, että kortti on pudonnut viime `FarmingDelay` minuuttia (jos Steam-verkko ei kertonut meille esineestä on pudonnut tai kamaa näin). Olettaen, että Steam-verkko toimii kunnolla, pienentämällä tätä arvoa **ei paranna maatalouden tehokkuutta millään tavalla**, kun taas **kasvaa verkon yläpuolella merkittävästi** - on suositeltavaa vain lisätä sitä (jos tarpeen) oletuksena `15` minuuttia. Ellei sinulla ole **vahvaa** syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `SuodatinBadBotit`

`bool` tyyppi, jonka oletusarvo on `true`. Tämä ominaisuus määrittää, onko ASF automaattisesti estää kaupan tarjouksia, jotka on saatu tunnetuista ja merkittyjä huonoja toimijoita. Jotta näin tehtäisiin, ASF kommunikoi palvelimen kanssa tarvittavalla tavalla hakeakseen listan mustalla listalla olevista Steam-tunnisteista. Luetteloon merkittyjä robotteja käyttävät ihmiset, jotka on luokiteltu haitallisiksi ASF-aloitteelle meiltä, kuten ne, jotka rikkovat meidän **[käytännesääntöjä](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, käyttää meille tarjottuja toimintoja ja resursseja kuten **[`Julkistamalla`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** muiden ihmisten hyväksikäytön ja hyväksikäytön edistämiseksi, tai tekee suoranaista rikollista toimintaa, kuten käynnistää DDoS-hyökkäyksiä palvelimelle. Koska ASF suhtautuu vahvasti yleiseen oikeudenmukaisuuteen, rehellisyyteen ja yhteistyöhön käyttäjien välillä, jotta koko yhteisö voisi kukoistaa. tämä ominaisuus on oletusarvoisesti käytössä, ja siksi ASF suodattimet bots että olemme luokitelleet haitalliseksi palveluista tarjotaan. Ellei sinulla ole **vahvaa** syytä muokata tätä ominaisuutta, kuten eri mieltä meidän lausuma ja tarkoituksella sallia noiden botteja toimimaan (mukaan lukien hyödyntämällä tilejäsi), sinun pitäisi pitää se oletusarvoisesti.

---

### `GiftsLimiterDelay`

`tavua` , jonka oletusarvo on `1`. ASF varmistaa, että vähintään `GiftsLimiterDelay` sekuntia on kahden peräkkäisen lahjan/avaimen/lisenssin käsittelyn (lunastaminen) välillä välttääkseen koron nostamisen. Sen lisäksi sitä käytetään myös maailmanlaajuisena rajoittona peliluettelon pyynnöille, kuten `omistaa` **[komennon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Ellei sinulla ole **vahvaa** syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `Päätön`

`bool` tyyppi oletusarvo `false`. Tämä ominaisuus määrittelee, onko prosessi ajettava päättömässä tilassa. Kun headless tilassa, ASF olettaa, että se toimii palvelimella tai muussa ei-interaktiivisessa ympäristössä, komissio ei siis yritä lukea tietoja konsolin avulla. Tämä sisältää tilauksen tiedot (tilitiedot kuten 2FA-koodi, SteamGuard koodi, salasana tai muu muuttuja, jota ASF tarvitsee käyttääkseen) sekä kaikki muut konsolin syötteet (kuten interaktiivinen komentorivikonsoli). Toisin sanoen `Headless` -tila on yhtä suuri kuin ASF-konsolin lukeminen. Tämä asetus on hyödyllinen lähinnä käyttäjille, jotka käyttävät ASF:ää palvelimillaan sen sijaan, että pyytäisivät sitä. . 2FA-koodin osalta ASF keskeyttää toimenpiteen hiljaa pysäyttämällä tilin. Ellet käytä ASF:ää palvelimella ja olet aiemmin vahvistanut, että ASF pystyy toimimaan ilman päätä -tilassa, sinun pitäisi pitää tämä ominaisuus poissa käytöstä. Käyttäjien välinen vuorovaikutus evätään päättömässä tilassa, ja tilisi eivät toimi, jos ne vaativat **mitä tahansa** konsolia käynnistyksen aikana. Tämä on hyödyllinen palvelimille, koska ASF voi keskeyttää yrittämisen kirjautua tilille, kun sitä pyydetään sen sijaan, että odottaisi (loputtomasti) käyttäjää tarjoamaan näitä.

Tämän tilan käyttöönotto sallii sinun syöttää vaaditun konsolin muilla tavoilla, eli ASF-ui (ASF API), tai **[`tulo`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#input-command)** komennon kautta. Jos et ole varma kuinka asettaa tämän ominaisuuden, jätä se oletusarvoon `false`.

---

### `IdleFarmingPeriod`

`tavua` , jonka oletusarvo on `8`. Kun ASF:llä ei ole mitään tilaa, se tarkistaa ajoittain joka `IdleFarmingPeriod` -tuntia, jos ehkä tili sai tilalle uusia pelejä. Tätä ominaisuutta ei tarvita puhuttaessa uusista peleistä, joita pyydämme, koska ASF on tarpeeksi fiksu tarkistamaan automaattisesti sivut tässä tapauksessa. `IdleFarmingPeriod` on pääasiassa tilanteissa, kuten vanhoja pelejä meillä jo on kaupankäynnin kortteja lisätty. Tässä tapauksessa ei ole tapahtumaa, joten ASF on tarkastettava säännöllisesti merkkien sivut, jos haluamme saada tämän katetuksi. `0` poistaa tämän ominaisuuden. Tarkista myös: `ShutdownOnFarmingValmistui` asetus `FarmingPreferences`.

---

### `InventoryLimiterDelay`

`tavu`-tyyppi, jonka oletusarvo on `4`. ASF varmistaa, että vähintään `InventoryLimiterDelay` sekuntia on kahden peräkkäisen verkkoinventaariopyynnön välillä, jotta vältyttäisiin nostamasta korkoa – niitä käytetään esimerkiksi varasto-ilmoitusten merkitsemisessä luetuksi saattaa myös käyttää kolmannen osapuolen liitännäisiä hakemalla tavaraluettelon muille käyttäjille. Tätä ominaisuutta ei käytetä oman tavaraluettelomme hakemiseen, koska ASF käyttää paljon tehokkaampaa sisäistä verkkoa edellyttämällä, että joten se ei vaikuta komentoihin kuten `loot` tai `siirto` millään tavalla. Oletusarvo `4` määritettiin yli 100 peräkkäisen botin varaston perusteella, ja on täytettävä useimmat (jos eivät kaikki) käyttäjiä. Voit kuitenkin halutessasi vähentää sitä tai jopa vaihtaa `0` jos sinulla on hyvin pieni määrä botteja, niin ASF ohittaa viiveen ja merkitse Steam-tavaraluettelot paljon nopeammin. Be warned though, as setting it too low **will** result in Steam temporarily banning your IP, and that will prevent you from making any calls at all. Voit myös joutua lisäämään tätä arvoa, jos käytät paljon botteja, joilla on paljon varastopyyntöjä, vaikka tässä tapauksessa sinun pitäisi luultavasti yrittää rajoittaa määrää näiden pyyntöjen sijaan. Ellei sinulla ole **vahvaa** syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `IPC`

`bool` tyyppi, jonka oletusarvo on `true`. Tämä ominaisuus määrittelee, onko ASF:n **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** -palvelin aloitettava yhdessä prosessin kanssa. IPC mahdollistaa prosessin välisen viestinnän, mukaan lukien **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, käynnistämällä paikallisen HTTP-palvelimen. Jos et aio käyttää mitään kolmannen osapuolen IPC-integraatiota ASF:ään, mukaan lukien ASF-ui, voit poistaa tämän vaihtoehdon käytöstä turvallisesti. Muuten se on hyvä idea pitää se päällä (oletusvaihtoehto).

---

### `IPCPassword`

`merkkijono` jonka oletusarvo on `null`. Tämä ominaisuus määrittelee pakollisen salasanan jokaiselle API-puhelulle IPC:n kautta ja toimii ylimääräisenä turvatoimenpiteenä. Kun arvo on asetettu ei-tyhjään arvoon, kaikki IPC-pyynnöt vaativat ylimääräisen `salasanan` ominaisuuden, joka on määritetty tässä salasanassa. Oletusarvo `null` ohittaa salasanan tarpeen, jolloin ASF kunnioittaa kaikkia kyselyjä. Sen lisäksi sallii tämän vaihtoehdon myös sisäänrakennettu IPC -bruteforce -mekanismi, joka tilapäisesti kieltää `IPAddress` lähettämisen jälkeen liian monta luvatonta pyyntöä hyvin lyhyessä ajassa. Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `IppasswordFormaatti`

`tavu`-tyyppi, jonka oletusarvo on `0`. Tämä ominaisuus määrittelee `IPCPassword` -ominaisuuden muodon ja käyttää `EHashingMethod` -ominaisuutta perustana olevana tyyppinä. Katso **[Security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** -osiota, jos haluat lisätietoja kuten sinun täytyy varmistaa, että `IPCPassword` ominaisuus todellakin sisältää salasanan vastaavassa `IPCPasswordFormat`. Toisin sanoen, kun muutat `IPCPasswordFormat` sitten `IPCPassword` pitäisi olla **jo** tuossa muodossa, ei vain pyritään olemaan. Ellet tiedä mitä olet tekemässä, sinun pitäisi pitää se oletusarvo `0`.

---

### `LisenssiID`

`Guid?` tyyppi, jonka oletusarvo on `null`. Tämä ominaisuus sallii meidän **[sponsorit](https://github.com/sponsors/JustArchi)** parantaa ASF valinnaisia ominaisuuksia, jotka vaativat maksettuja resursseja työskennellä. Tällä hetkellä voit käyttää **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** -ominaisuutta `TuotteetMatcher` -liitännäisessä.

Vaikka suosittelemme käyttämään GitHub koska se tarjoaa kuukausittain ja kertaluonteisia tasoja, sekä mahdollistaa täyden automaation ja antaa sinulle välittömän käytön, me **** myös tukevat kaikkia muita tällä hetkellä saatavilla olevia **[lahjoitusvaihtoehtoja](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. Katso **[tämä viesti](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** ohjeet siitä, miten lahjoittaa käyttämällä muita menetelmiä, jotta manuaalinen lisenssi on voimassa tietyn ajan.

Käytetystä menetelmästä riippumatta, jos olet ASF sponsori, voit saada lisenssin **[tässä](https://asf.justarchi.net/User/Status)**. Sinun täytyy kirjautua sisään GitHubilla vahvistaaksesi henkilöllisyytesi, pyydämme vain vain luettavaa julkista tietoa, joka on käyttäjänimesi. `Lisenssitunnus` on tehty 32 heksadesimaalista, kuten `f6a0529813f74d119982eb4fe43a9a24`.

**Varmista, että et jaa `lisenssiä` muiden ihmisten kanssa**. Koska se on annettu henkilökohtaisesti, se voi perua, jos se vuotaa. Jos sattumalta näin sattui sinulle vahingossa, voit luoda uuden saman paikan.

Ellei haluat ottaa käyttöön ylimääräisiä ASF toimintoja, ei ole tarvetta saada / tarjota lisenssiä.

---

### `LoginLimiterDelay`

`tavu`-tyyppi, jonka oletusarvo on `10`. ASF varmistaa, että kahden peräkkäisen yhteyden välillä on vähintään `LoginLimiterDelay` sekuntia nopeuden rajoittamisen välttämiseksi. Oletusarvo `10` määritettiin perustuen yli 100 botti instanssien yhdistämiseen, ja pitäisi tyydyttää useimmat (jos ei kaikki) käyttäjille. Voit kuitenkin halutessasi lisätä tai pienentää sitä tai jopa vaihtaa kohtaan `0` jos bottien määrä on hyvin pieni, niin ASF ohittaa viiveen ja yhteyden Steamiin paljon nopeammin. Be warned though, as setting it too low while having too many bots **will** result in Steam temporarily banning your IP, and that will prevent you from logging in **at all**, with `InvalidPassword/RateLimitExceeded` error - and that also includes your normal Steam client, not only ASF. Vastaavasti, jos käytät liikaa botteja, erityisesti yhdessä muiden Steam-asiakkaiden/työkalujen kanssa käyttäen samaa IP-osoitetta, todennäköisimmin sinun täytyy lisätä tätä arvoa, jotta tunnukset leviävät pidempään ajanjaksoon.

Sivuhuomautuksena voidaan mainita, että tätä arvoa käytetään myös kuormituksen tasapainottavana puskurina kaikissa ASF-aikataulun toiminnoissa, kuten `SendTradePeriod` -kaupassa. Ellei sinulla ole **vahvaa** syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `MaxFarmingTime`

`tavu`-tyyppi, jonka oletusarvo on `10`. Kuten sinun pitäisi tietää, Steam ei aina toimi asianmukaisesti, joskus outoja tilanteita voi tapahtua, kuten meidän peliaikaa ei kirjata, vaikka itse asiassa pelaa peliä. ASF sallii yhden riistan viljelyn yksinään enintään `MaxFarmingTime` -tunnin ajan ja harkitsee sitä täysin viljeltynä kyseisen ajanjakson jälkeen. This is required to not freeze farming process in case of weird situations happening, but also if for some reason Steam released a new badge that would stop ASF from progressing further (see: `Blacklist`). Oletusarvo `10` tuntia pitäisi riittää pudottamaan kaikki höyry kortit yhdestä pelistä. Tämän ominaisuuden liian alhainen voi johtaa voimassa olevia pelejä ohitetaan (ja kyllä, on voimassa pelit jopa jopa 9 tuntia maatilalle), kun taas asettamalla se liian korkea voi johtaa maatalouden prosessi jäädytetään. Huomioithan, että tämä ominaisuus vaikuttaa vain yhteen peliin yhdellä viljelyjaksolla (niin sen jälkeen, kun menee läpi koko jono ASF palaa kyseiseen otsikkoon), myös se ei perustu kokonaispeliaikaa, mutta sisäinen ASF maanviljely aikaa, joten ASF palaa myös että otsikko uudelleenkäynnistyksen jälkeen. Ellei sinulla ole **vahvaa** syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `MaxTradeHoldDuration`

`tavu`-tyyppi, jonka oletusarvo on `15`. Tämä ominaisuus määrittää enimmäiskesto kaupan hallussa päivinä, jotka olemme valmiita hyväksymään - ASF hylkää kaupat, joita pidetään yli `MaxTradeHoldDuration` päivää, siten kuin se on määritelty kaupankäyntijaksossa **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**. Tämä vaihtoehto on järkevä vain boteille `TradingPreferences` of `SteamTradeMatcher`, koska se ei vaikuta `Master`/`SteamOwnerID` kaupat, eivät lahjoitukset. Kauppa on ärsyttävää kaikille, eikä kukaan todellakaan halua käsitellä niitä. ASF:n on määrä työskennellä liberaalien sääntöjen parissa ja auttaa kaikkia, riippumatta siitä, onko kaupassa vai ei - siksi tämä valinta on oletusarvoisesti `15`. Kuitenkin, jos haluat sen sijaan hylätä kaikki kaupat, joihin kauppa vaikuttaa, voit määrittää `0` täällä. Harkitse sitä, että tämä vaihtoehto ei vaikuta kortteihin, joissa on lyhyt käyttöikä ja että ne hylätään automaattisesti ihmisillä, joilla on kaupankäynti, **[kaupankäyntijakson](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** mukaisesti kuvatulla tavalla, ei siis ole tarpeen hylätä kaikkia maailmanlaajuisesti vain sen vuoksi. Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.


---

### `MinFarmingDelayAfterBlock`

`tavu`-tyyppi, jonka oletusarvo on `60`. Tämä ominaisuus määrittää minimimäärän sekunteina, mikä ASF odottaa ennen kuin uudelleen korttien kasvatus, jos se on aiemmin katkaistu `LoggedInElsewhere`, joka tapahtuu, kun päätät voimallisesti katkaista nykyisen maatalouden ASF käynnistämällä pelin. Tämä viivästys johtuu pääasiassa mukavuussyistä ja ilmakehän vuoksi. Esimerkiksi sen avulla voit käynnistää pelin uudelleen ilman taistella ASF miehittää tilisi uudelleen vain koska pelaaminen lukitus oli käytettävissä split sekunti. Koska istunnon uudelleen käynnistäminen aiheuttaa `LoggedInElsewhere` -yhteyden katkaisemisen, ASF:n on käytävä läpi koko uudelleenyhdistämismenettely, joka aiheuttaa lisäpainetta koneelle ja höyryverkolle, joten on suositeltavampaa välttää lisäkytkennän katkeamista, jos mahdollista. Oletuksena tämä on määritetty `60` sekunnissa, minkä pitäisi riittää jotta voit käynnistää pelin uudelleen ilman paljon vaivaa. On kuitenkin olemassa skenaarioita, kun voit olla kiinnostunut lisäämään sitä, esimerkiksi, jos verkkosi katkaisee usein ja ASF ottaa liian pian haltuunsa, mikä aiheuttaa sen, että se joutuu itse läpikäymään uudelleenyhteyden prosessin. Sallimme maksimi arvo `255` tälle kiinteistölle, jonka pitäisi riittää kaikkiin yhteisiin skenaarioihin. Edellä mainitun lisäksi on myös mahdollista vähentää viivästystä, tai jopa poista se kokonaan arvo `0`, vaikka sitä ei yleensä suositella edellä mainittujen syiden vuoksi. Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `Optimointitila`

`tavu`-tyyppi, jonka oletusarvo on `0`. Tämä ominaisuus määrittää optimointitilan, jota ASF suosii ajon aikana. Tällä hetkellä ASF tukee kahta tilaa - `0` , jota kutsutaan nimellä `MaxPerformance`, ja `1` , jota kutsutaan nimellä `MinMemoryUsage`. Oletuksena ASF pitää parempana ajaa mahdollisimman monta asiaa rinnakkain (samanaikaisesti) kuin mahdollista, joka parantaa suorituskykyä kuormituksen tasapainottamalla työtä kaikissa suorittimen ytimissä, useita suoritinlankoja, useita pistorasioita ja useita ketjupoolin tehtäviä. Esimerkiksi ASF pyytää ensimmäisen merkkisivun, kun tarkistat pelejä maatilalle, ja sitten kun pyyntö saapui, ASF lukee siitä kuinka monta merkkisivustoa sinulla itse asiassa on, ja sitten pyytää toisiaan samanaikaisesti. Tämä on mitä sinun pitäisi haluta **lähes aina**, koska yläpuolella useimmissa tapauksissa on minimaalinen ja hyödyt asynkroninen ASF koodi voidaan nähdä jopa vanhin laitteisto yhdellä CPU ydin ja erittäin rajoitettu teho. Kuitenkin monia tehtäviä käsitellään rinnakkain, ASF ajoaika on vastuussa niiden huolto, esim. pitää pistorasiat avoimina, säikeet elävinä ja käsiteltävinä, joka voi johtaa siihen, että muistin käyttö lisääntyy ajoittain, ja jos käytettävissä oleva muisti rajoittaa sinua suuresti, saatat haluta vaihtaa tämän ominaisuuden `1` (`MinMemoryUsage`) pakottaaksesi ASF:n käyttämään mahdollisimman vähän tehtäviä, ja tyypillisesti käynnissä mahdollisesta rinnakkaiseen asynkroninen koodi synkronoidulla tavalla. Tämän ominaisuuden vaihtaminen kannattaa harkita vain, jos luet aiemmin **[muistin alhaisen asennuksen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** ja haluat tarkoituksella uhrata valtavan suorituskyvyn, hyvin pieni muistin yläpuolella lasku. Yleensä tämä vaihtoehto on **paljon huonompi** kuin mitä voit saavuttaa muilla mahdollisilla tavoilla, kuten rajoittamalla ASF käyttöä tai tuning runtime n roskat kerääjä, kuten selitettiin **[muistin alhaisen asennuksen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Siksi sinun pitäisi käyttää `MinMemoryUsage` **viime lomakeskuksena**, juuri ennen runtime recompilation, jos et voi saavuttaa tyydyttäviä tuloksia muiden (paljon parempi) vaihtoehtoja. Ellei sinulla ole **vahvaa** syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `PluginsUpdateList`

`ImmutableHashSet<string>` tyyppi, jonka oletusarvo on tyhjä. Tämä ominaisuus määrittelee luettelon liitännäisten kokoonpanojen nimistä, jotka ovat joko mustalla listalla tai sallittuja automaattisia päivityksiä varten, `PluginsUpdateMode` on määritelty alla.

Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `PluginsUpdateMode`

`tavu`-tyyppi, jonka oletusarvo on `0`. Tämä ominaisuus määrittää liitännäisten päivitystilan, joka antaa merkityksen `PluginsUpdateList` on määritelty yllä. Määrittämällä tämän ominaisuuden voit ottaa käyttöön / poistaa käytöstä automaattisia päivityksiä kaikki liitännäiset lukuun ottamatta ilmoitettuja.

- Arvo `0`, kutsutaan `valkoiseksi`, **poistaa käytöstä** kaikkien lisäosien automaattisen päivityksen, lukuun ottamatta lisäosien `päivityslistan` määritettyjä päivityksiä.
- `1`, nimeltään `Blacklist`, **mahdollistaa** kaikkien lisäosien automaattisen päivityksen, lukuun ottamatta lisäosien `päivityslistan` määritettyjä päivityksiä.

**ASF tiimi haluaa muistuttaa sinua siitä, että oman turvallisuutesi vuoksi sinun pitäisi ottaa käyttöön automaattiset päivitykset vain luotettavilta osapuolilta**. Muista, että ilkivaltaiset liitännäiset voivat päättää päivittää itseään tai suorittaa etäkomentoja **riippumatta** tästä asetuksesta, tämän vuoksi tämä asetus koskee yksinomaan ASF:n tarjoamia liitännäisiä ja sinun pitäisi silti varmistaa, että olet asianmukaisesti todennettu jokainen plugin että olet päättänyt käyttää.

Päivitykset liitännäisistä tehdään oletuksena yhdessä ASF päivityksen rutiini - **[`UpdateChannel`](#updatechannel)** ja **[`UpdatePeriod`](#updateperiod)**. Standardi ASF päivitysmekanismit, kuten `päivitys` -komento käynnistää myös valinnaisen lisäosien päivityksen. Jos sen sijaan haluat päivittää liitännäisiä manuaalisesti päivittämättä ASF versiota samaan aikaan, `päivitysplugins` -komento tarjoaa tällaisen mahdollisuuden.

Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `SammuttaIfMahdollinen`

`bool` tyyppi oletusarvo `false`. Kun asetus on käytössä, ASF yrittää pysäyttää prosessin mikäli mahdollista, eli kun kaikki rekisteröidyt botit on pysäytetty. Tämä voi olla erityisen hyödyllistä, kun yhdistettynä `ShutdownOnFarmingFinished` -toimintoon kaikissa bottiesiintymisissäsi, koska näin ASF voi automaattisesti sammuttaa kun viimeinen botteja päättyy maanviljely.

Koska odotus valtaosa käyttäjistä on oltava prosessi käynnissä kaikkina aikoina, e. . `IPC` käytölle, tämä asetus on oletuksena pois päältä.

---

### `SteamMessageEtuliite`

`merkkijono` on oletusarvo `"/me "`. Tämä ominaisuus määrittelee etuliitteen, joka on asetettu ennakkoon kaikille ASF:n lähettämille Steam-viesteille. Oletuksena ASF käyttää `"/me "` etuliitettä, jotta bottiviestit voidaan erottaa helpommin näyttämällä ne eri värillä Steam-keskustelussa. Toinen arvokas maininta on `"/pre "` etuliite, joka saavuttaa samanlaisen tuloksen, mutta käyttää eri muotoilua. Voit myös asettaa tämän ominaisuuden tyhjään merkkijonoon tai `null` poistaaksesi käytöstä käyttämällä täysin etuliitettä ja tulostaaksesi kaikki ASF viestit perinteisellä tavalla. On mukava huomata, että tämä ominaisuus vaikuttaa vain Steam-viesteihin - muiden kanavien (kuten IPC) kautta palautetut vastaukset eivät vaikuta siihen. Ellet halua muokata standardia ASF käyttäytymistä, se on hyvä idea jättää se oletusarvoisesti.

---

### `SteamOwnerID`

`ulong` -tyyppi, jonka oletusarvo on `0`. Tämä ominaisuus määrittää Steam ID 64-bittisen ASF prosessin omistaja, ja on hyvin samanlainen kuin `Master` lupa tietyn bottiesiintymän (mutta maailmanlaajuinen sijaan). Olet melkein aina halukas asettamaan tämän ominaisuuden tunnukseksi oman pääSteam-tilisi tunnukselle. `Master` lupa sisältää täyden hallinnan hänen bottiesimerkiksi, mutta globaalit komennot kuten `exit`, `` tai `päivitys` on varattu vain `SteamOwnerID`. Tämä on kätevää, sillä saatat haluta ajaa botteja ystävillesi, elleivät ne pysty hallitsemaan ASF-prosessia, kuten sen poistumista `-poistumiskomennon` kautta. Oletusarvo `0` määrittää, että ASF-prosessin omistajaa ei ole, Mikä tarkoittaa, että kukaan ei pysty antamaan maailmanlaajuisia ASF-komentoja. Pidä mielessä, että tämä ominaisuus koskee yksinomaan Steam-keskustelua. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, sekä interaktiivinen konsoli voit silti suorittaa `Omistaja` komentoja, vaikka tätä ominaisuutta ei olekaan asetettu.

---

### `SteamProtocols`

`tavuliput` tyyppi, jonka oletusarvo on `7`. Tämä ominaisuus määrittää Steam-protokollat, joita ASF käyttää yhdistettäessä Steam-palvelimia, jotka on määritelty alla:

| Arvo | Nimi      | Kuvaus                                                                                           |
| ---- | --------- | ------------------------------------------------------------------------------------------------ |
| 0    | Tyhjä     | No protocol                                                                                      |
| 1    | TCP       | **[Transmission Control Protocol](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2    | UDP       | **[Käyttäjän Datagramman Protokolla](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**     |
| 4    | WebSocket | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                                         |

Huomaa, että tämä ominaisuus on `liput` kenttä, joten on mahdollista valita jokin yhdistelmä käytettävissä olevia arvoja. Tutustu **[json kartoitukseen](#json-mapping)** jos haluat oppia lisää. Jos lippuja ei oteta käyttöön, tulos on `Yksikään` vaihtoehto, ja tämä valinta on virheellinen itsestään.

Oletuksena ASF käyttää kaikkia saatavilla olevia Steam-protokollia keinona torjua seisokkeja ja muita vastaavia Steam-ongelmia. Tyypillisesti haluat muuttaa tätä ominaisuutta, jos haluat rajoittaa ASF käyttää vain yksi tai kaksi tiettyä protokollia. Tällaisia toimenpiteitä voitaisiin tarvita eri tilanteissa, esimerkiksi jos olet estänyt UDP liikennettä palomuurilla ja haluat varmistaa, että vain TCP-liikenne menee läpi, tai jos käytät `WebProxy` ja haluat käyttää sitä myös Steam-asiakasyhteyteen, koska vain `WebSocket` -protokolla tukee sitä.

Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `Päivityskanava`

`tavu`-tyyppi, jonka oletusarvo on `1`. Tämä ominaisuus määrittää päivityskanavan, jota käytetään, joko automaattisia päivityksiä varten (jos `UpdatePeriod` on suurempi kuin `0`), tai päivitä ilmoituksia (muuten). Tällä hetkellä ASF tukee kolmea päivityskanavaa - `0` , jota kutsutaan nimellä `Ei`, `1`, jota kutsutaan nimellä `Stable`ja `2`, jota kutsutaan nimellä `PreRelease`. `Vakaa` kanava on oletusjulkaisukanava, jota pitäisi käyttää useimpien käyttäjien keskuudessa. `PreRelease` -kanava `Vakaa` -julkaisujen lisäksi, sisältää myös **pre-releases** omistettu edistyneille käyttäjille ja muille kehittäjille uusien ominaisuuksien testaamiseksi, vahvista virhekorjauksia tai anna palautetta suunnitelluista parannuksista. **PreRelease versiot sisältävät usein korjaamattomia vikoja, käynnissä olevia ominaisuuksia tai uudelleenkirjoitettuja toteutuksia**. Jos et pidä itseäsi edistyneenä käyttäjänä, ole hyvä ja pysy oletuksena `1` (`Vakaa`) päivityskanavalla. `PreRelease` -kanava on omistettu käyttäjille, jotka osaavat raportoida virheistä, käsitellä asioita ja antaa palautetta - teknistä tukea ei anneta. Tutustu ASF **[julkaisu sykli](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** jos haluat lisätietoja lisää. Voit myös asettaa `UpdateChannel` `0` (`Ei`), jos haluat poistaa kaikki versiotarkistukset. Asettaminen `UpdateChannel` `0` poistaa kokonaan käytöstä kaikki päivityksiin liittyvät toiminnot, mukaan lukien `päivitys` komennon. `Mikään` kanava on **voimakkaasti masentunut** johtuen itsesi altistamisesta kaikenlaisille ongelmille (mainittu `UpdatePeriod` kuvauksessa alla).

**Ellet tiedä mitä teet**, me **vahvasti** suosittelemme, että se pidetään oletusarvoisena.

---

### `Päivitysaika`

`tavu`-tyyppi, jonka oletusarvo on `24`. Tämä ominaisuus määrittelee, kuinka usein ASF tarkistaa automaattisen päivityksen. Päivitykset ovat ratkaisevan tärkeitä paitsi uusien ominaisuuksien ja kriittisten turvakorjausten saamiseksi, myös virhekorjauksia, suorituskyvyn parannuksia, vakautta parannuksia ja paljon muuta. Kun arvo on suurempi kuin `0` on asetettu, ASF lataa automaattisesti, korvaa ja käynnistä itse uudelleen (jos `automaattinen uudelleenkäynnistys` sallii) kun uusi päivitys on saatavilla. Tämän saavuttamiseksi ASF tarkistaa joka `UpdatePeriod` tunnin välein, jos uusi päivitys on saatavilla meidän GitHub repo. Arvo `0` poistaa automaattisesti päivitykset, mutta silti voit suorittaa `päivittää` komennon manuaalisesti. Saatat myös olla kiinnostunut asettamaan sopiva `UpdateChannel` jota `UpdatePeriod` noudattaa.

ASF:n päivitysprosessiin kuuluu koko kansiorakenteen päivitys, jota ASF käyttää, mutta koskematta omia `config` -hakemistoon sijoitettuja konfiguroja tai tietokantoja - tämä tarkoittaa, että kaikki ylimääräiset tiedostot, jotka eivät liity ASF:ään sen hakemistossa, voivat hävitä päivityksen aikana. Oletusarvo `24` on hyvä tasapaino tarpeettomien tarkistusten ja riittävän tuoreen ASF:n välillä.

Ellei sinulla ole **vahva** syy poistaa tämä ominaisuus käytöstä, sinun pitäisi pitää automaattiset päivitykset käytössä kohtuullisessa `UpdatePeriod` **oman hyvän** aikana. Tämä ei johdu vain siitä, että emme tue mitään muuta kuin viimeisintä vakaata ASF-julkaisua, mutta myös koska **annamme turvatakuu vain uusimman version**. Jos käytät vanhentuneita ASF versio niin olet tarkoituksella altistaa itsesi kaikenlaisia kysymyksiä, pieniä bugeja, rikkoutuneen toiminnallisuuden, päättyy **[pysyvä Steam-tili suspensioita](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**, joten suosittelemme **vahvasti**, omaksi hyvyytesi varmistaaksesi, että ASF versio on ajan tasalla. Automaattisten päivitysten avulla voimme reagoida nopeasti kaikenlaisiin ongelmiin poistamalla käytöstä tai korjaamalla ongelmallisen koodin ennen kuin se voi laajentua - jos suljet sen pois, menetät kaikki turvatakuumme ja käytännesääntöjen käytöstä aiheutuvat riskiseuraukset, jotka voivat olla haitallisia, ei vain Steam-verkkoon, vaan myös (määritelmän mukaan) omaan Steam-tiliisi.

---

### `WebLimiterDelay`

`ushort` tyyppi, jonka oletusarvo on `300`. Tämä ominaisuus määrittelee välikappaleissa pienimmän viiveen kahden peräkkäisen pyynnön lähettämisen välillä samaan Steam-palveluun lähetettäessä. Tällainen viive on tarpeen **[AkamaiGhost](https://www.akamai.com)** -palvelussa, jota Steam käyttää sisäisesti, sisältää hintarajoituksen koko tietyn ajanjakson aikana lähetettyjen pyyntöjen maailmanlaajuisen määrän perusteella. Tavallisissa olosuhteissa akamai-lohkoa on melko vaikea saavuttaa, mutta hyvin raskaissa työkuormissa on valtava jatkuva pyyntöjono, se on mahdollista käynnistää, jos lähetämme jatkuvasti liian monta pyyntöä liian lyhyessä ajassa.

Oletusarvo määritettiin olettaen, että ASF on ainoa työkalu Steamin verkkopalveluihin, erityisesti `höyryyhteisöön. om`, `api.steampowered.com` ja `store.steampowered.com`. Jos käytät muita työkaluja lähettämällä pyyntöjä samoihin web-palveluihin, sinun tulee varmistaa, että työkalusi sisältää samanlaisia toimintoja `WebLimiterDelay` ja asettaa molemmat kaksinkertaiseksi oletusarvoon, joka olisi `600`. Tämä takaa, että et missään olosuhteissa ylitä yli yhden pyynnön per `300` ms.

Yleisesti ottaen `WebLimiterDelay` -arvon alentaminen oletusarvon alla on **voimakkaasti masentunut** koska se voi johtaa erilaisiin IP:hen liittyviin lohkoihin, joista osa on mahdollista olla pysyviä. Oletusarvo on tarpeeksi hyvä suorittamaan yksi ASF instanssi palvelimella, sekä käyttämällä ASF normaalissa skenaariossa yhdessä alkuperäisen Steamin asiakas. Sen pitäisi olla oikea suurin osa käytöstä, ja sinun pitäisi vain lisätä sitä (ei koskaan alentaa sitä). Lyhyesti sanottuna kaikkien pyyntöjen, jotka lähetetään yhdeltä IP-osoitteelta yhdelle Steam-verkkotunnukselle, kokonaismäärä ei saisi koskaan ylittää yhtä pyyntöä `300` ms kohden.

Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `Webvälityspalvelin`

`merkkijono` jonka oletusarvo on `null`. Tämä ominaisuus määrittää web-välityspalvelimen osoitteen, jota käytetään sisäiseen http-viestintään, erityisesti palveluihin, kuten `github. om`, `api.steampowered.com`, `steamcommunity.com` ja `store.steampowered.com`. Se koskee yleistä (ei-botin spesifistä) viestintää sekä bottikohtaista viestintää, jos niiden vastaavaa `WebProxy` konfiguraatioominaisuutta ei ole asetettu. ASF-pyyntöjen esittäminen voisi olla poikkeuksellisen hyödyllistä ohittaa erilaisia palomuureja, erityisesti Kiinan suuri palomuuri.

Tämän ominaisuuden katsotaan olevan uri merkkijono:

> URI-merkkijono koostuu järjestelmästä (tuettu: http/https/socks4/socks4a/socks5), isännästä ja valinnaisesta portista. Esimerkki täydellisestä uri merkkijonosta on `"http://contoso.com:8080"`.

Jos välityspalvelin vaatii käyttäjän tunnistautumista, sinun täytyy myös perustaa `WebProxyUsername` ja/tai `WebProxyPassword`. Jos tällaista tarvetta ei ole, yksin tämän omaisuuden perustaminen riittää.

Jos tarvitset myös sisäisen Steam-verkkoliikenteen (CM:t) lähettämistä, sitten sinun pitäisi varmistaa määrittää **[`SteamProtocols`](#steamprotocols)** bot's property to a value that allows only websocket transport, i. . arvo `4`, koska proxying tukee vain websockets .

Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `WebProxyPassword`

`merkkijono` jonka oletusarvo on `null`. Tämä ominaisuus määrittää salasanakenttä käytetään perustiedot, digest, NTLM, ja Kerberos autentikointi, jota tukee kohde `WebProxy` kone tarjoaa välityspalvelimen toiminnallisuutta. Jos välityspalvelusi ei vaadi käyttäjätunnuksia, sinun ei tarvitse syöttää mitään tähän. Tämän vaihtoehdon käyttäminen on järkevää vain, jos `WebProxy` käytetään samoin, koska sillä ei ole mitään vaikutusta toisin.

Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `WebProxyUsername`

`merkkijono` jonka oletusarvo on `null`. Tämä ominaisuus määrittää käyttäjätunnuksen kenttä käytetään perus-, digest, NTLM, ja Kerberos autentikointi, jota tukee kohde `WebProxy` kone tarjoaa välityspalvelimen toiminnallisuutta. Jos välityspalvelusi ei vaadi käyttäjätunnuksia, sinun ei tarvitse syöttää mitään tähän. Tämän vaihtoehdon käyttäminen on järkevää vain, jos `WebProxy` käytetään samoin, koska sillä ei ole mitään vaikutusta toisin.

Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

## Bot config

Kuten sinun pitäisi tietää jo, jokaisella botti pitäisi olla oma config perustuu esimerkki JSON rakenne alla. Aloita päättämästä, miten haluat nimetä botin (esim. `1.json`, `merkittävä. poika`, `primary.json` tai `AnythingElse.json`) ja mene konfiguraatioon.

**Huomautus:** Botia ei voida nimetä `ASF` (koska tämä avainsana on varattu globaalille confifille), ASF ohittaa myös kaikki asetustiedostot, jotka alkavat pisteellä.

Botti configissa on seuraava rakenne:

```json
{
    "AcceptGifts": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Päällä": false,
    "FarmingOrders": [],
    "FarmingAsetukset": 0,
    "GamesPlayedWhileIdle": [],
    "GamingDeviceType": 1,
    "TuntiUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "Koneenimi": null,
    "MatchableTypes": [5]
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "LunastaminenAsetukset": 0,
    "Etäviestintä": 3,
    "SendTradePeriod": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "Siirrettävät tyypit": [1, 3, 5],
    "UseLoginKeys": true,
    "UserInterfaceMode": 0,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Kaikki vaihtoehdot on selitetty alla:

### `Hyväksytyt Lahjat`

`bool` tyyppi oletusarvo `false`. Kun se on käytössä, ASF hyväksyy ja lunastaa automaattisesti kaikki botiin lähetetyt höyrylahjat (mukaan lukien lompakon lahjakortit). Tämä sisältää myös muilta kuin `SteamUserPermissions` -kohdassa määritellyiltä käyttäjiltä lähetetyt lahjat. Muista, että sähköpostiosoitteeseen lähetettyjä lahjoja ei lähetetä suoraan asiakkaalle, joten ASF ei hyväksy niitä ilman apuasi.

Tämä vaihtoehto on suositeltavaa vain alt tileille, koska on hyvin todennäköistä, että et halua automaattisesti lunastaa kaikkia ensisijaiselle tilillesi lähetettyjä lahjoja. Jos olet epävarma haluatko tämän ominaisuuden olevan käytössä tai ei, pidä se oletusarvolla `false`.

---

### `BotBehaviour`

`tavuliput` tyyppi, jonka oletusarvo on `0`. Tämä ominaisuus määrittelee ASF botti-kaltaisen käyttäytymisen eri tapahtumissa, ja se määritellään alla:

| Arvo | Nimi                             | Kuvaus                                                                                                                    |
| ---- | -------------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| 0    | Tyhjä                            | Ei erityistä botin käyttäytymistä, järjetön oletusasetukset                                                               |
| 1    | HylätInvalidiFriendInvites       | Saattaa ASF:n hylkäämään (sen sijaan, että jätettäisiin huomiotta) virheellisiä ystäväkutsuja                             |
| 2    | HylätInvalidiTrades              | Saattaa ASF:n hylkäämään (sen sijaan, että jätettäisiin huomiotta) virheellisiä kauppatarjouksia                          |
| 4    | HylätInvalidGroupKutsut          | Saattaa ASF:n hylkäämään (sen sijaan, että jätettäisiin huomiotta) virheellisiä ryhmäkutsuja                              |
| 8    | HylkäyksetInventoryNotifications | aiheuttaa sen, että ASF hylkää automaattisesti kaikki varastoilmoitukset                                                  |
| 16   | Vastaanotetut ViestitLue         | aiheuttaa sen, että ASF merkitsee automaattisesti kaikki vastaanotetut viestit luetuiksi                                  |
| 32   | MarkBotMessagesAsRead            | aiheuttaa sen, että ASF merkitsee automaattisesti muiden ASF bottejen viestit (käynnissä samassa tapauksessa) kuin luettu |
| 64   | Estä SaapuvatTradesParsing       | Saattaa ASF koskaan käsitellä saapuvia kauppatarjouksia                                                                   |

Huomaa, että tämä ominaisuus on `liput` kenttä, joten on mahdollista valita jokin yhdistelmä käytettävissä olevia arvoja. Tutustu **[json kartoitukseen](#json-mapping)** jos haluat oppia lisää. Lippuja ei oteta käyttöön `Ei mitään` -vaihtoehtoa.

Yleensä haluat muokata tätä ominaisuutta, jos haluat muuttaa bottien toimintaan liittyviä erilaisia automaatioasetuksia. Oletusasetukset sisältävät ASF ajon ei-invasiivisessa tilassa, joka mahdollistaa vain hyödyllisen automaation, joka ei ole käyttäjän tahdon vastainen.

Virheellinen ystäväkutsu on kutsu, joka ei tule käyttäjältä `FamilySharing` -käyttöoikeudella (määritelty `SteamUserPermissions`-järjestelmässä) tai yllä. ASF normaalitilassa jättää kutsut huomiotta, kuten olisit odottanut, antaen sinulle ilmaisen valinnan, hyväksytäänkö ne vai ei. `HylätInvalidFriendInvites` aiheuttaa kutsujen automaattisen hylkäämisen, joka käytännössä poistaa mahdollisuuden muille ihmisille lisätä sinut heidän ystävälistaan (kuten ASF kieltää kaikki tällaiset pyynnöt, lukuun ottamatta henkilöitä, jotka on määritelty kohdassa `SteamUserPermissions`). Ellet halua suoraan kieltää kaikkia ystäväkutsuja, sinun ei pitäisi ottaa tätä vaihtoehtoa käyttöön.

Virheellinen tarjous on tarjous, jota ei hyväksytä sisäänrakennetun ASF-moduulin kautta. Asiasta löytyy lisätietoja **[kaupankäynnistä](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** , jossa määritellään selvästi, minkä tyyppisiä kauppaa ASF on valmis hyväksymään automaattisesti. Kelvolliset kaupat määritellään myös muissa asetuksissa, erityisesti `TradingPreferences`. `HylätInvalidiTrades` aiheuttaa virheellisten kauppatarjousten hylkäämisen sen sijaan, että ne jätetään huomiotta. Ellet halua suoralta kädeltä evätä kaikkia ASF:n automaattisesti hyväksymiä kaupan tarjouksia, sinun ei pitäisi ottaa tätä vaihtoehtoa käyttöön.

Virheellinen ryhmäkutsu on kutsu, joka ei tule `SteamMasterClanID` -ryhmästä. ASF normaalitilassa ohittaa nämä ryhmäkutsut, kuten olisit odottanut, jonka avulla voit itse päättää, haluatko liittyä tiettyyn Steam-ryhmään vai ei. `HylätInvalidGroupInvites` aiheuttaa kaikkien ryhmän kutsujen hylkäämisen automaattisesti, tehokkaasti mahdotonta kutsua sinua mihinkään muuhun ryhmään kuin `SteamMasterClanID`. Ellet halua suoraan kieltää kaikkia ryhmäkutsuja, sinun ei pitäisi ottaa tätä vaihtoehtoa käyttöön.

`DismissInventoryNotifications` on erittäin hyödyllinen, kun aloitat ärsyttävän jatkuvan Steam-ilmoituksen uusien kohteiden vastaanottamisesta. ASF ei pääse eroon itse ilmoituksesta, koska se on sisäänrakennettu Steam-asiakkaaseesi, mutta se voi automaattisesti tyhjentää ilmoituksen saatuaan sen, joka ei enää jätä "uusia kohteita varastoon" ilmoitus roikkuu ympäri. Jos odotat arvioida itseäsi kaikki vastaanotetut kohteet (erityisesti ASF-kortit, sinun ei luonnollisestikaan pitäisi ottaa tätä vaihtoehtoa käyttöön. Kun aloitat hulluksi, muista, että tämä on tarjolla vaihtoehto.

`MarkReceivedViestitLue` merkitsee automaattisesti **kaikki** viestit jotka vastaanotetaan tilillä, jolla ASF on käynnissä, sekä yksityinen että ryhmä, kuten luettua. Tätä tyypillisesti tulee käyttää vain alt-tileillä, jotta voit tyhjentää esimerkiksi sinulta tulevan "uuden viestin" ilmoituksen ASF-komentoja suoritettaessa. Emme suosittele tätä vaihtoehtoa ensisijaisille tileille, ellet halua leikata itseäsi mistään uusista viesteistä, **, mukaan lukien** , jotka tapahtuivat ollessasi offline-tilassa, olettaen, että ASF oli vielä auki hylkää sen.

`MarkBotMessagesLue` toimii samalla tavalla merkitsemällä vain bottiviestit luetuiksi. Pidä kuitenkin mielessä, että kun käytät tätä vaihtoehtoa ryhmäkeskusteluissa bottien ja muiden ihmisten kanssa, Steam-toteutus chat-viestin vastaanottamiseksi **myös** hyväksyy kaikki viestit, jotka tapahtuivat **ennen** jonka päätit merkitä, joten jos sattumalta et halua jättää väliin liittymätöntä viestiä, jonka välillä tapahtui, haluat yleensä välttää tämän ominaisuuden käyttöä. Ilmeisesti se on myös riskialtista, kun sinulla on useita ensisijaisia tilejä (esim. eri käyttäjiltä), jotka toimivat samassa ASF-esimerkissä, koska voit myös jättää huomioimatta niiden normaaleja ASF-viestejä.

`DisableIncomingTradesParsing` estää ASF:n jäsentelemästä tulevia kauppatarjouksia, mikä tarkoittaa sitä, että koko kaupankäyntitoiminto, joka ei ole toimiva. Koska ASF toimii oletusarvoisesti vähiten invasiivisessa tilassa hyväksyen vain kaupalliset tarjoukset `Master` käyttäjiltä ja edellä, koskaan koskettaa muita tarjouksia - saapuvat kaupat jäsennys on käytössä oletusarvoisesti. Tämä asetus on kaikkein järkevin ihmisille, jotka haluavat varmistaa, että mitään ylimääräisiä pyyntöjä / yläpuolella liittyvät kaupat parsing, poistamalla koko logiikka prosessissa, esimerkiksi siksi, että he tietävät, että heidän boteerinsa eivät koskaan saa mestarikaupallisia pyyntöjä, eivätkä näin ollen edellytä ASF:ää osallistumaan niiden kaupankäyntitoimintaan lainkaan. Muista, että tämän vaihtoehdon määritteleminen poistaa kaikki muut vaihtoehdot, jotka riippuvat myös saapuvista vaihtoehdoista, kuten `AcceptDonations` tai `SteamTradeMatcher` - mukautetut liitännäiset eivät myöskään pysty käsittelemään saapuvia kauppatarjouksia tavalliseen tapaan.

Jos et ole varma miten määrittää tämä vaihtoehto, se on parasta jättää oletusarvoisesti.

---

### `CompleteTypesToSend`

`ImmutableHashSet<byte>` tyyppi, jonka oletusarvo on tyhjä. Kun ASF on valmis täyttämällä tietyn joukon määritettyjä tuotetyyppejä, jotka on määritetty täällä. se voi lähettää höyryä automaattisesti kaikkien valmiiden sarjojen kanssa käyttäjälle `Master` -luvalla, joka on erittäin kätevä, jos haluat käyttää annettua bottitiliä e. . STM matching, siirrettäessä valmiita sarjoja joillekin muille tilille. Tämä asetus toimii samalla tavalla kuin `loot` -komento pitäkää siis mielessä, että se vaatii käyttäjän `Master` -oikeudet asetettuina, voit myös tarvita voimassa olevan `SteamTradeToken`, sen lisäksi, että käytetään tiliä, joka on alun perin kaupankäynnin kohteena.

Tästä päivästä lähtien seuraavat tuotetyypit ovat tuettuja tässä asetuksessa:

| Arvo | Nimi            | Kuvaus                                                               |
| ---- | --------------- | -------------------------------------------------------------------- |
| 3    | FoilTradingCard | `TradingCard` -kela muunnos                                          |
| 5    | TradingCard     | Höyrynvaihtokortti, jota käytetään merkkien nikkarointiin (ei folio) |

Huomaa, että riippumatta yllä olevista asetuksista ASF pyytää vain **[Steam-yhteisön kohteita](https://steamcommunity.com/my/inventory/#753_6)** (`appID` of 753, `kontekstID` of 6), joten kaikki peliesineet, lahjat ja niin ikään eivät kuulu kauppatarjouksen määritelmän mukaan.

Tämän vaihtoehdon käytön yleistymisen vuoksi on suositeltavaa käyttää sitä vain bot tilejä, joilla on realistinen mahdollisuus viimeistely asetetaan itse - esimerkiksi ei ole järkevää aktivoida jos käytät jo `SendOnFarmingFinished` -asetusta `FarmingPreferences`, `SendTradePeriod` tai `ryöstää` -komento tavallisesti.

Jos et ole varma miten määrittää tämä vaihtoehto, se on parasta jättää oletusarvoisesti.

---

### `CustomGamePlayedWhileFarming`

`merkkijono` jonka oletusarvo on `null`. Kun ASF on viljelemässä, se voi näyttää itsensä "Playing ei-höyry peli: `CustomGamePlayedWhileFarming`" sijasta tällä hetkellä viljellyn pelin. Tämä voi olla hyödyllistä, jos haluat kertoa ystävillesi, että olet maanviljely, silti et halua käyttää `OnlineStatus` ja `Offline`. Huomioithan, että ASF ei voi taata Steam-verkon todellista näyttöjärjestystä, näin ollen tämä on vain ehdotus, joka voi näkyä tai ei voi näkyä oikein. Erityisesti mukautettu nimi ei näy `Complex` -maatalouden algoritmissa, jos ASF täyttää kaikki `32` -paikat peleillä, jotka vaativat tuntikausia törmäyksessä. Oletusarvo `null` poistaa tämän ominaisuuden.

ASF tarjoaa muutamia erityisiä muuttujia, joita voit halutessasi käyttää tekstissäsi. `{0}` korvataan ASF `sovelluksella` tällä hetkellä viljellystä pelistä, kun taas `{1}` korvataan ASF:llä `pelinimi` tällä hetkellä viljellystä pelistä.

---

### `CustomGamePlayedWhileIdle`

`merkkijono` jonka oletusarvo on `null`. Kuten `CustomGamePlayedWhileFarming`, mutta tilanteessa, jossa ASF:llä ei ole mitään tekemistä (tilillä on täysin tilattu). Huomioithan, että ASF ei voi taata Steam-verkon todellista näyttöjärjestystä, näin ollen tämä on vain ehdotus, joka voi näkyä tai ei voi näkyä oikein. Jos käytät `GamesPlayedWhileIdle` yhdessä tämän vaihtoehdon kanssa, pidä mielessä, että `GamesPlayedWhileIdle` saa prioriteetin, siksi et voi ilmoittaa enempää kuin `31` niistä, kuten muuten `CustomGamePlayedWhileIdle` ei voi miehittää paikkaa mukautetun nimen. Oletusarvo `null` poistaa tämän ominaisuuden.

---

### `Käytössä`

`bool` tyyppi oletusarvo `false`. Tämä ominaisuus määrittelee, onko botti käytössä. Käytössä oleva botti instanssi (`true`) käynnistyy automaattisesti ASF käynnissä, kun pois päältä otettu bottiesiintymä (`false`) on käynnistettävä manuaalisesti. Oletuksena jokainen botti on poistettu käytöstä, joten haluat luultavasti vaihtaa tämän ominaisuuden `toteen` kaikille bottisillesi, jotka pitäisi aloittaa automaattisesti.

---

### `Maanviljelystilaukset`

`ImmutableList<byte>` tyyppi, jonka oletusarvo on tyhjä. Tämä ominaisuus määrittää **suositellun** viljelyjärjestyksen, jota ASF käyttää tietylle bottitilille. Tällä hetkellä käytössä on seuraavat tuotantotilaukset:

| Arvo | Nimi                     | Kuvaus                                                                              |
| ---- | ------------------------ | ----------------------------------------------------------------------------------- |
| 0    | Järjestämätön            | Ei lajittelua, hieman parantaa suorittimen suorituskykyä                            |
| 1    | SovelluksetNouseva       | Yritä maatilan pelejä alin `appIDs` ensin                                           |
| 2    | Sovellukset Laskeva      | Yritä maatilan pelejä korkein `appIDs` ensin                                        |
| 3    | CardDropsNouseva         | Yritä maatilan pelejä, joissa alin määrä korttia putoaa jäljellä ensin              |
| 4    | Korttipudotukset Laskeva | Yritä maatilan pelejä, joissa suurin määrä kortti putoaa jäljellä ensin             |
| 5    | TuntiaNouseva            | Yritä maatilan pelejä alin määrä tuntia pelataan ensin                              |
| 6    | Tuntia Laskeva           | Yritä maatilan pelejä suurin määrä tunteja pelataan ensin                           |
| 7    | NimiNouseva              | Yritä maatilan pelejä aakkosjärjestyksessä, alkaen A                                |
| 8    | Nimet Laskeva            | Yritä maatilan pelejä käänteisessä aakkosjärjestyksessä, alkaen Z                   |
| 9    | Satunnainen              | Yritä maatilan pelejä täysin satunnaisessa järjestyksessä (eri kunkin ajon ohjelma) |
| 10   | MerkkitasoNouseva        | Yritä maatilan pelejä alin kunniamerkki tasot ensin                                 |
| 11   | MerkkitasoLaskeva        | Yritä maatilan pelejä korkein kunniamerkki tasot ensin                              |
| 12   | Lunasta Ajat Nousevasti  | Yritä maatilan vanhimmat pelit tilillämme ensin                                     |
| 13   | Lunasta Ajat Laskeva     | Yritä maatilan uusimmat pelit tilillämme ensin                                      |
| 14   | Marketable Nouseva       | Yritä maatilan pelejä markkinoimaton kortti putoaa ensin (varoitus: kallis laskea)  |
| 15   | Marketable Laskeva       | Yritä maatilan pelejä myyntikelpoinen kortti putoaa ensin (varoitus: kallis laskea) |

Koska tämä ominaisuus on taulukko, sen avulla voit käyttää useita eri asetuksia kiinteässä järjestyksessä. Voit esimerkiksi sisällyttää arvot `15`, `11` ja `7` lajitellakseen ensin markkinakelpoisten pelien mukaan, sitten ne, joilla on korkein merkki tasolla, ja lopulta aakkosjärjestyksessä. Kuten arvata, tilauksella todella on merkitystä, käänteinen yksi (`7`, `11` ja `15`saavuttavat jotain täysin erilaista (lajittelee pelit aakkosjärjestyksessä ensiksi, ja koska pelien nimet ovat ainutlaatuisia, kaksi muuta ovat tehokkaasti hyödytön). Suurin osa ihmisistä käyttää todennäköisesti vain yhtä tilausta kaikista niistä, mutta jos haluat, voit myös lajitella edelleen ylimääräisiä parametreja.

Huomioi myös sana "yrittää" edellä mainituissa kuvauksissa - varsinainen ASF-tilaus vaikuttaa voimakkaasti valittuihin **[kortteihin maatalouden algoritmi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** ja lajittelu vaikuttaa vain tuloksiin, joita ASF pitää yhtä suorituskykyisinä. Esimerkiksi `Simple` algoritmissa, valittu `FarmingOrders` tulisi olla täysin kunnioitettu nykyisessä viljelyistunnossa (koska jokaisella pelillä on sama suoritusarvo), kun `Complex` algoritmi todellinen järjestys vaikuttaa tunnit ensin ja sitten lajiteltu valitun `FarmingOrders` mukaisesti. Tämä johtaa erilaisiin tuloksiin, koska pelit, joissa on olemassa peliaikaa, ovat etusijalla muihin verrattuna, niin tehokkaasti ASF suosii pelejä, jotka jo ohitettu vaaditut `HoursUntilCardDrops` ensiksi, ja vasta sitten lajitella nämä pelit edelleen valitsemasi `FarmingOrders`. Samoin, kun ASF loppuu jo bumped pelejä, se lajittelee jäljellä olevan jonon tuntikohtaisesti ensin (jolloin jäljellä olevien nimikkeiden törmäämiseen tarvitaan aikaa `HoursUntilCardDrops`). Siksi tämä config ominaisuus on vain **ehdotus** , jota ASF yrittää kunnioittaa, niin kauan kuin se ei vaikuta suorituskykyyn negatiivisesti (tässä tapauksessa ASF pitää aina parempana maatalouden suorituskykyä kuin `FarmingOrders`).

On myös maanviljelyn prioriteettijono, joka on käytettävissä `fq` **[komentojen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** kautta. Jos sitä käytetään, varsinainen tilaus lajitellaan ensin suorituksella, sitten viljelyjonolla, ja lopuksi `FarmingOrders` -tilauksella.

---

### `MaanviljelysPreferenssit`

`tavuliput` tyyppi, jonka oletusarvo on `0`. Tämä ominaisuus määrittelee maatalouden ASF:n käyttäytymisen, ja se määritellään seuraavassa:

| Arvo | Nimi                            |
| ---- | ------------------------------- |
| 0    | Tyhjä                           |
| 1    | FarmingPausedByDefault          |
| 2    | ShutdownOnFarmingValmistui      |
| 4    | SendonFarmingValmistui          |
| 8    | Vain FarmPriorityQueueOnly      |
| 16   | SkipRefundableGames             |
| 32   | SkipUnplayedGames               |
| 64   | Ota KäyttöönRiskyCardsDiscovery |
| 256  | AutoUnpackBoosterPacks          |

Huomaa, että tämä ominaisuus on `liput` kenttä, joten on mahdollista valita jokin yhdistelmä käytettävissä olevia arvoja. Tutustu **[json kartoitukseen](#json-mapping)** jos haluat oppia lisää. Lippuja ei oteta käyttöön `Ei mitään` -vaihtoehtoa.

Kaikki vaihtoehdot on kuvattu alla.

`FarmingPausedByDefault` määrittelee `CardsFarmer` -moduulin alkutilan. Tavallisesti botti aloittaa maanviljelyn automaattisesti, kun se käynnistetään, joko `Käytössä` tai `käynnistää` komennon. Käyttämällä `FarmingPausedByDefault` voidaan käyttää, jos haluat manuaalisesti `jatkaa automaattista viljelyprosessia` Esimerkiksi koska haluat käyttää `soittaa` koko ajan eikä koskaan käytä automaattista `CardsFarmer` moduulia - tämä toimii täsmälleen samalla tavalla kuin `tauko` **[komento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

`ShutdownOnFarmingFinished` sallii sinun sammuttaa botin, kun se on tehty viljelyyn. Normaalisti ASF on "miehittämässä" tili koko prosessin ollessa aktiivinen. Viljelyllä on tehtävä tilitys säännöllisin väliajoin ASF tarkastaa sen (joka `IdleFarmingPeriod` -tunti), jos ehkä joitakin uusia pelejä höyrykortteja lisättiin sillä välin, jotta se voi aloittaa uudelleen maanviljelyn kyseisen tilin ilman tarvetta käynnistää prosessi uudelleen. Tämä on hyödyllistä useimmille ihmisille, koska ASF voi tarvittaessa automaattisesti jatkaa maanviljelyä. Voit kuitenkin itse asiassa haluta lopettaa prosessin, kun annettu tili on täysin viljellyt, voit saavuttaa sen käyttämällä tätä lippua. Kun asetus on käytössä, ASF jatkaa kirjautumista, kun tili on täysin viljellyt, mikä tarkoittaa, että sitä ei tarkisteta ajoittain tai ole enää käytössä. Sinun pitäisi itse päättää, jos haluat ASF työskennellä tietyn botin esimerkiksi koko ajan, tai jos ASF:n olisi ehkä lopetettava se, kun maatalousprosessi on tehty.

Tämä valinta on kaikkein järkevin yhdistettynä `ShutdownIfPossible`, niin kun kaikki tilit on pysäytetty, myös ASF sulkee, laittamalla koneesi lepäämään ja sallimalla sinun ajoittaa muita toimintoja, kuten nukkua tai sammuttaa samalla hetkellä viimeisen kortin pudottaminen.

`SendOnFarmingFinished` sallii sinun lähettää automaattisesti höyrykauppaa, joka sisältää kaiken tähän asti tilatun käyttäjälle `Master` -luvalla, joka on erittäin kätevä, jos et halua vaivata kanssa kauppoja itse. Tämä asetus toimii samalla tavalla kuin `loot` -komento pitäkää siis mielessä, että se vaatii käyttäjän `Master` -oikeudet asetettuina, voit myös tarvita voimassa olevan `SteamTradeToken`, sen lisäksi, että käytetään tiliä, joka on alun perin kaupankäynnin kohteena. Sen lisäksi, että käynnistetään `ryöstö` maanviljelyn päättymisen jälkeen, ASF käynnistää myös `erän` jokaisesta uudesta ilmoituksesta (kun ei viljely) ja täytettyään jokaisen kaupan, joka johtaa uusia kohteita (aina) kun tämä vaihtoehto on aktiivinen. Tämä on erityisen hyödyllistä "huolinta" kohteita, jotka on saatu muilta ihmisiltä tilillemme. Tyypillisesti haluat käyttää **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** yhdessä tämän ominaisuuden kanssa, Vaikka se ei ole vaatimus, jos aiot käsitellä 2FA vahvistukset manuaalisesti oikea-aikaisesti.

`FarmPriorityQueueOnly` määrittelee, jos ASF harkitsee automaattista maanviljelyä vain sovelluksissa, jotka olet lisännyt itsellesi prioriteettimaanviljelyn jonoon saatavilla `fq` **[komennoilla](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. When this option is enabled, ASF will skip all `appIDs` that are missing on the list, effectively allowing you to cherry-pick games for automatic ASF farming. Muista, että jos et lisännyt yhtään peliä jonoon ASF toimii ikään kuin ei olisi mitään tilalla tililläsi.

`SkipRefundableGames` määrittelee, pitäisikö ASF ohittaa pelit, jotka edelleen palautetaan automaattisesta viljelystä. Palautettava peli on peli, jonka olet ostanut 2 viime viikon aikana Steam Store ja ei pelannut yli 2 tuntia vielä, Kuten on ilmoitettu **[Steamin palautukset](https://store.steampowered.com/steam_refunds)** sivulla. ASF jättää oletusarvoisesti Steam-palautukset kokonaan huomiotta ja maatiloilla kaiken, kuten useimmat ihmiset odottaisivat. Voit kuitenkin käyttää tätä lippua, jos haluat varmistaa, että ASF ei tilata mitään palautettavia pelejä liian pian, jonka avulla voit arvioida näitä pelejä itse ja palautus tarvittaessa, ilman huolta ASF vaikuttaa peliaikaan negatiivisesti. Huomioithan, että jos otat tämän vaihtoehdon käyttöön, ASF ei vilkaise Steam-kaupasta ostamiasi pelejä 14 päivän ajan lunastuspäivästä, joka ei näy mitään maatilalla, jos tili ei omista mitään muuta.

`SkipUnplayedGames` määrittelee, jos ASF ohittaa pelit, joita et vielä käynnistänyt. Pelaamaton peli tässä yhteydessä tarkoittaa, että sinulla ei ole mitään soittoaikaa tallennettu sille Steam. Jos käytät tätä lippua, tällaiset pelit ohitetaan, kunnes Steam rekisteröi niille minkä tahansa pelattavan ajan. Näin voit hallita paremmin mitkä pelit ASF on oikeutettu maatilalle, ohittamalla ne, jotka sinulla ei ollut mahdollisuutta kokeilla vielä, pitää valitut Steam-ominaisuudet hyödyllisempiä - kuten viittaa pelattaviin peleihin.

`EnableRiskyCardsDiscovery` mahdollistaa lisävaraston, joka laukaisee kun ASF ei pysty lataamaan yhtä tai useampaa merkkisivua eikä sen vuoksi löydä viljelyyn saatavilla olevia pelejä. Erityisesti jotkin tilit, joissa on valtava määrä kortteja, saattavat aiheuttaa tilanteen, jossa merkkien lataussivut eivät ole enää mahdollisia (ylikuormituksen vuoksi), ja nämä tilit ovat maatalouden kannalta mahdottomia vain siksi, että emme voi ladata tietoja, joiden perusteella voimme aloittaa prosessin. Näissä kourallisissa tapauksissa tämä vaihtoehto mahdollistaa vaihtoehtoisen algoritmin käytön, jossa käytetään yhdistelmää tehosteita, joita voidaan käyttää käsiteollisuudessa ja tehostepakkauksissa, tilille voidaan myöntää löytääkseen mahdollisesti saatavilla olevia pelejä joutilaiksi, käyttää sen jälkeen liikaa varoja tarvittavien tietojen tarkistamiseen ja hakemiseen, ja yrittää aloittaa maatalouden prosessi rajallisella määrällä tietoja ja tietoja, jotta lopulta saavuttaa tilanne, kun merkkisivu kuormitetaan ja voimme käyttää normaalia lähestymistapaa. Huomioithan, että kun tätä varmennusta käytetään, ASF toimii vain rajallisin tiedoin. Siksi on täysin normaalia, että ASF löytää paljon vähemmän pudotuksia kuin todellisuudessa - muita pudotuksia löytyy myöhemmin maatalouden prosessissa.

Tätä vaihtoehtoa kutsutaan "riski" erittäin hyvästä syystä - se on erittäin hidas ja vaatii huomattavan määrän resursseja (mukaan lukien verkkopyynnöt) toiminnalle, Siksi **ei ole suositeltavaa** ottaa käyttöön, ja erityisesti pitkällä aikavälillä. Sinun tulee käyttää tätä asetusta vain, jos olet aiemmin määrittänyt, että tilisi ei pysty lataamaan merkkisivustoja eikä ASF voi toimia sillä, prosessin käynnistämiseksi tarvittavia tietoja ei aina ole ladattu. Vaikka olisimme tehneet parhaamme optimoidaksemme prosessin mahdollisimman paljon, se on vielä mahdollista tämän vaihtoehdon takaisin, ja se voi aiheuttaa ei-toivottuja tuloksia, kuten väliaikaiset ja ehkä jopa pysyvät kiellot Steamin puolelta liian monien pyyntöjen lähettämiseksi ja muuten aiheuttaen yläpuolella Steam-palvelimia. Siksi varoitamme sinua etukäteen ja tarjoamme tämän vaihtoehdon ilman takuita, käytät sitä omalla vastuullasi.

`AutoUnpackBoosterPacks` purkaa automaattisesti kaikki tehostepaketit saatuaan uusia kohteita ilmoituksen. Tämän avulla voit heti hankkia ylimääräistä korttia putoaa, mikä voisi olla haluttu skenaario erityisesti yhdessä muiden vaihtoehtojen (e. . `SteamTradeMatcher` tai `CompleteTypesToSend`).

---

### `PelitPelitWhileIdle`

`ImmutableHashSet<uint>` tyyppi, jonka oletusarvo on tyhjä. Jos ASF:llä ei ole mitään tilaa, se voi pelata määritettyjä höyrypelejä (`appIDs`). Pelien pelaaminen tällä tavalla lisää näiden pelien "tuntia" mutta ei mitään muuta sen ulkopuolelle. In order for this feature to work properly, your Steam account **must** own a valid license to all the `appIDs` that you specify here, this includes F2P games as well. Tämä ominaisuus voidaan ottaa käyttöön samanaikaisesti `CustomGamePlayedWhileIdle` kanssa, jotta voit pelata valittuja pelejä näyttäen samalla mukautetun tilan Steam-verkossa, mutta tässä tapauksessa, kuten `CustomGamePlayedWhileFarming` -tapauksessa, varsinaista näyttötilausta ei ole taattu. Huomaa, että Steam sallii ASF:n pelata vain `32` `appidit` yhteensä, siksi voit laittaa vain niin monta peliä tässä omaisuutta.

---

### `GamingLaitetyyppi`

`ushort` tyyppi, jonka oletusarvo on `1`. Tämä ominaisuus voi ottaa käyttöön joitakin muita online-ominaisuuksia Steam-alustalla, ja on määritelty alla:

| Arvo | Nimi       | Kuvaus                      |
| ---- | ---------- | --------------------------- |
| 1    | StandardPC | Ei erikoistilaa, oletus     |
| 544  | Steamdeck  | Näytä itsensä Steam Deck:nä |

Taustalla oleva `EGamingDeviceType` tyyppi, johon tämä ominaisuus perustuu, sisältää enemmän saatavilla olevia arvoja, kuitenkin parhaan tietämyksemme mukaan niillä ei ole mitään vaikutusta tästä päivästä alkaen, joten ne on leikattu näkyvyyteen.

Jos et ole varma kuinka asettaa tämän ominaisuuden, jätä se oletusarvoon `1`.

---

### `TuntiaUntilCardDrops`

`tavu`-tyyppi, jonka oletusarvo on `3`. Tämä ominaisuus määrittää, onko tili on korttia on rajoitettu, ja jos kyllä, kuinka monta aloitustuntia. Rajoitettu kortin pudotus tarkoittaa, että tili ei saa tippoja annetusta pelistä ennen kuin peliä pelataan vähintään `TuntiaUntilCardDrops` tuntia. Valitettavasti ei ole mitään maagista tapaa havaita, joten ASF luottaa sinuun. Tämä ominaisuus vaikuttaa **[korttien viljelyalgoritmi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** että käytetään. Tämän omaisuuden kunnolla maksimoida voitot ja minimoida aika, joka tarvitaan korttien viljelyyn. Muista, että ei ole selvää vastausta siihen, pitäisikö sinun käyttää yhtä tai toista arvoa, koska se riippuu täysin tilistasi. Näyttää siltä, että vanhemmilla tileillä, jotka eivät koskaan pyytäneet hyvitystä, on rajoittamattomia korttien laskuja, joten niiden pitäisi käyttää arvoa `0`, kun taas uudet tilit ja palautusta pyytäneet ovat rajoittaneet korttien pudotuksia `3`. Tämä on kuitenkin vain teoriaa, eikä sitä pitäisi pitää sääntönä. Oletusarvo tälle omaisuudelle määritettiin "vähäisempi paha" ja suurin osa käyttötapauksista.

---

### `Lootable-tyypit`

`ImmutableHashSet<byte>` tyyppi, jonka oletusarvo on `1, 3, 5` höyrytuotetyypit. Tämä ominaisuus määrittää ASF käyttäytymisen kun ryöstät - molemmat manuaalinen, käyttäen **[komentoa](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, sekä automaattinen yksi, yhden tai useamman kokoonpano ominaisuuksia. ASF varmistaa, että kauppatarjoukseen sisällytetään vain `LootableTypes` -tyyppiset tuotteet, siksi tämä ominaisuus voit valita, mitä haluat saada kaupan tarjous, joka lähetetään sinulle.

| Arvo | Nimi                | Kuvaus                                                               |
| ---- | ------------------- | -------------------------------------------------------------------- |
| 0    | Tuntematon          | Jokainen tyyppi, joka ei sovi mihinkään alla olevaan                 |
| 1    | BoosterPack         | Booster-pakkaus, joka sisältää 3 satunnaista korttia pelistä         |
| 2    | Hymiö               | Hymiö jota käytetään Steam Chatissa                                  |
| 3    | FoilTradingCard     | `TradingCard` -kela muunnos                                          |
| 4    | Profiilitausta      | Profiilin tausta jota käytetään Steam-profiilissasi                  |
| 5    | TradingCard         | Höyrynvaihtokortti, jota käytetään merkkien nikkarointiin (ei folio) |
| 6    | SteamGems           | Steam-helmiä käytetään tehosteaineiden nikkarointiin, mukana säkit   |
| 7    | MyymäläItem         | Erityiset tuotteet myönnetään Steam-myynnin aikana                   |
| 8    | Kulutus             | Erityisiä kulutushyödykkeitä, jotka katoavat käytön jälkeen          |
| 9    | ProfileModifier     | Erikoiskohteet, jotka voivat muokata Steam-profiilin ulkoasua        |
| 10   | Tarra               | Erikoiskohteet, joita voidaan käyttää Steam-keskustelussa            |
| 11   | ChatEffect          | Erikoiskohteet, joita voidaan käyttää Steam-keskustelussa            |
| 12   | MiniprofiiliTausta  | Steam-profiilin erityinen tausta                                     |
| 13   | AvatarProfiiliKehys | Steamin profiilin erityinen profiilikuva                             |
| 14   | AnimatedAvatar      | Erityinen animoitu profiilikuva Steamiin                             |
| 15   | NäppäimistöSkin     | Erityinen näppäimistön iho Steam-kannelle                            |
| 16   | StartupVideo        | Erityinen aloitusvideo Steamin pakalle                               |

Huomaa, että riippumatta yllä olevista asetuksista ASF pyytää vain **[Steam-yhteisön kohteita](https://steamcommunity.com/my/inventory/#753_6)** (`appID` of 753, `kontekstID` of 6), joten kaikki peliesineet, lahjat ja niin ikään eivät kuulu kauppatarjouksen määritelmän mukaan.

Oletus ASF asetus perustuu yleisimpään käyttöön bot, jossa ryöstää vain booster paketteja, ja kaupankäynnin kortteja (mukaan lukien folio). Tässä määritelty ominaisuus antaa sinulle mahdollisuuden muuttaa tuota käyttäytymistä millä tahansa tavalla, joka tyydyttää sinua. Muista, että kaikki tyypit, joita ei ole määritelty edellä, näytetään `Tuntematon` tyyppinä, mikä on erityisen tärkeää, kun Valve vapauttaa joitakin uusia Steam-kohteita, että merkitään `Tuntematon` ASF samoin, kunnes se on lisätty tähän (tulevaisuudessa julkaisu). Siksi yleensä ei ole suositeltavaa sisällyttää `Tuntematon` tyyppi `LootableTypes`, ellet tiedä mitä olet tekemässä, ja ymmärrät myös, että ASF lähettää koko tavaraluettelosi kauppatarjouksessa, jos Steam Network hajoaa uudelleen ja raportoi kaikki tavarasi `Tuntematon`. Minun vahva ehdotukseni ei ole sisällyttää `Tuntematon` tyyppi `LootableTypes`, vaikka odotat ryöstää kaikki (muu).

---

### `Konenimi`

`merkkijono` jonka oletusarvo on `null`. ASF käyttää tätä ominaisuutta kirjautuessaan Steamin verkkoon, jota voidaan käyttää räätälöinnin suhteen miten tarkalleen Steam näyttää ASF kone ja istunto, e. . kun näytetään laitteita, jotka ovat tällä hetkellä kirjautuneet **[tässä](https://store.steampowered.com/account/authorizeddevices)**.

ASF tarjoaa muutamia erityisiä muuttujia, joita voit halutessasi käyttää tekstissäsi. `{0}` korvataan koneen nimellä käyttöjärjestelmäsi mukaisesti, `{1}` korvataan ASF:n julkisella tunnisteella, kun taas `{2}` korvataan ASF:n versiolla.

Ellet tiedä mitä olet tekemässä, sinun pitäisi pitää se oletusarvo `null`. Tässä tapauksessa ASF päättää sisäisesti asianmukaisesta arvosta, joka on `{0} ({1}/{2})` tästä päivästä alkaen. Muista, että tämä on vain ehdotus, jonka mukaan Steam-verkko voi tai ei voi täysin kunnioittaa.

---

### `MatchableTypit`

`ImmutableHashSet<byte>` tyyppi, jonka oletusarvo on `5` Steam tuotetyyppejä. Tämä ominaisuus määrittelee, mitkä Steam-tuotetyypit ovat sallittuja kun `SteamTradeMatcher` -vaihtoehto `TradingPreferences` on käytössä. Tyypit määritellään seuraavasti:

| Arvo | Nimi                | Kuvaus                                                               |
| ---- | ------------------- | -------------------------------------------------------------------- |
| 0    | Tuntematon          | Jokainen tyyppi, joka ei sovi mihinkään alla olevaan                 |
| 1    | BoosterPack         | Booster-pakkaus, joka sisältää 3 satunnaista korttia pelistä         |
| 2    | Hymiö               | Hymiö jota käytetään Steam Chatissa                                  |
| 3    | FoilTradingCard     | `TradingCard` -kela muunnos                                          |
| 4    | Profiilitausta      | Profiilin tausta jota käytetään Steam-profiilissasi                  |
| 5    | TradingCard         | Höyrynvaihtokortti, jota käytetään merkkien nikkarointiin (ei folio) |
| 6    | SteamGems           | Steam-helmiä käytetään tehosteaineiden nikkarointiin, mukana säkit   |
| 7    | MyymäläItem         | Erityiset tuotteet myönnetään Steam-myynnin aikana                   |
| 8    | Kulutus             | Erityisiä kulutushyödykkeitä, jotka katoavat käytön jälkeen          |
| 9    | ProfileModifier     | Erikoiskohteet, jotka voivat muokata Steam-profiilin ulkoasua        |
| 10   | Tarra               | Erikoiskohteet, joita voidaan käyttää Steam-keskustelussa            |
| 11   | ChatEffect          | Erikoiskohteet, joita voidaan käyttää Steam-keskustelussa            |
| 12   | MiniprofiiliTausta  | Steam-profiilin erityinen tausta                                     |
| 13   | AvatarProfiiliKehys | Steamin profiilin erityinen profiilikuva                             |
| 14   | AnimatedAvatar      | Erityinen animoitu profiilikuva Steamiin                             |
| 15   | NäppäimistöSkin     | Erityinen näppäimistön iho Steam-kannelle                            |
| 16   | StartupVideo        | Erityinen aloitusvideo Steamin pakalle                               |

Tietenkin tyypit, joita sinun pitäisi käyttää tähän ominaisuuteen tyypillisesti sisältävät vain `2`, `3`, `4` ja `5`, koska STM tukee vain näitä tyyppejä. ASF sisältää asianmukaisen logiikan esineiden harvinaisuuden havaitsemiseksi, joten se on myös turvallista sovittaa hymiöitä tai taustat, koska ASF ottaa asianmukaisesti huomioon oikeudenmukaisesti vain nämä kohteet samasta pelistä ja tyypistä, jotka myös jakavat saman harvinaisuuden.

Huomioithan, että **ASF ei ole kaupankäynnin botti** ja **EI välitä markkinahinnasta**. Jos et pidä samaa harvinaisuutta olevia kohteita samasta sarjasta samaa hintapuolta, niin tämä vaihtoehto EI ole sinulle. Arvioi kaksi kertaa, jos ymmärrät ja hyväksyt tämän lausunnon ennen kuin päätät muuttaa tätä asetusta.

Ellet tiedä mitä olet tekemässä, sinun pitäisi pitää se oletusarvo `5`.

---

### `OnlineFlags`

`kortteli liput` tyyppi oletusarvo `0`. Tämä ominaisuus toimii täydennyksenä **[`OnlineStatus`](#onlinestatus)** ja määrittää muita Steam-verkkoon ilmoitettuja online-läsnäolon ominaisuuksia. Vaatii **[`OnlineStatus`](#onlinestatus)** muun kuin `offline-tilassa`, ja on määritelty alla:

| Arvo | Nimi              | Kuvaus                                             |
| ---- | ----------------- | -------------------------------------------------- |
| 0    | Tyhjä             | Ei erityistä online läsnäolo lippuja, oletus       |
| 2    | InJoinableGame    | Asiakas on yhteiskäytössä                          |
| 8    | Etäsoitto Yhdessä | Asiakas käyttää etäsoittoa yhdessä istunnon kanssa |
| 256  | ClientTypeWeb     | Asiakas käyttää web-käyttöliittymää                |
| 512  | ClientTypeMobile  | Asiakas käyttää mobiilisovellusta                  |
| 1024 | ClientTypeTenfoot | Asiakas käyttää isoa kuvaa                         |
| 2048 | ClientTypeVR      | Asiakas käyttää VR-kuulokkeita                     |

Huomaa, että tämä ominaisuus on `liput` kenttä, joten on mahdollista valita jokin yhdistelmä käytettävissä olevia arvoja. Tutustu **[json kartoitukseen](#json-mapping)** jos haluat oppia lisää. Lippuja ei oteta käyttöön `Ei mitään` -vaihtoehtoa.

Taustalla oleva `EPersonaStateFlag` tyyppi, jonka tämä ominaisuus perustuu sisältää enemmän saatavilla olevia lippuja, kuitenkin parhaan tietämyksemme mukaan niillä ei ole mitään vaikutusta tästä päivästä alkaen, joten ne on leikattu näkyvyyteen.

Jos et ole varma kuinka asettaa tämän ominaisuuden, jätä se oletusarvoon `0`.

---

### `OnlineStatus`

`tavu`-tyyppi, jonka oletusarvo on `1`. Tämä ominaisuus määrittää Steam-yhteisön tilan, jonka botista ilmoitetaan Steam-verkkoon kirjautumisen jälkeen. Tällä hetkellä voit valita yhden alla olevat tilat:

| Arvo | Nimi             |
| ---- | ---------------- |
| 0    | Ei paikalla      |
| 1    | Paikalla         |
| 2    | Varattu          |
| 3    | Poissa           |
| 4    | Torkku           |
| 5    | KatsotaanToTrade |
| 6    | KatsotaanToPlay  |
| 7    | Näkymätön        |

`Offline` tila on erittäin hyödyllinen ensisijaisille tileille. Kuten sinun pitäisi tietää, maatalous peli todella näyttää höyry tila "Pelaa peli: XXX", joka voi olla harhaanjohtava ystäville, hämmentää heitä, että pelaat peliä, kun itse olet vain maatalouden sitä. Käyttämällä `Offline` tila ratkaisee ongelman - tilisi ei koskaan näytetä "in-game" kun olet maatalouden höyrykortteja ASF. Tämä on mahdollista sen ansiosta, että ASF:n ei tarvitse kirjautua Steam-yhteisöön, jotta se toimisi asianmukaisesti, joten me itse asiassa pelaamme näitä pelejä, kytketty Steam-verkkoon, mutta ilmoittamatta online-läsnäolostamme lainkaan. Muista, että offline-tilalla pelatut pelit lasketaan edelleen kohti soittoaikaa ja näytetään "äskettäin soitettuina" profiilissasi.

Tämän lisäksi tämä ominaisuus on tärkeä, jos haluat vastaanottaa ilmoituksia ja lukemattomia viestejä ASF on käynnissä, mutta ei pidä Steam-ohjelmaa auki samaan aikaan. Tämä johtuu siitä, että ASF toimii itse Steam-asiakkaana ja haluaako ASF sitä vai ei, Steam lähettää kaikki nämä viestit ja muut tapahtumat siihen. Tämä ei ole ongelma, jos sinulla on sekä ASF että oma Steam-asiakas, koska molemmat asiakkaat saavat täsmälleen samat tapahtumat. Jos kuitenkin vain ASF on käynnissä, Steam-verkko voi merkitä tiettyjä tapahtumia ja viestejä "toimitettuina", vaikka perinteinen Steam-asiakas ei ole vastaanottanut sitä, koska se ei ole läsnä. Offline-tila ratkaisee myös tämän ongelman, koska ASF ei koskaan harkitse mitään yhteisötapahtumista tässä tapauksessa, joten kaikki lukemattomat viestit ja muut tapahtumat merkitään asianmukaisesti lukemattomiksi kun tulet takaisin.

On tärkeää huomata, että ASF toimii `Offline` -tilassa **ei** voi vastaanottaa komentoja tavallisella Steam chat-tavalla, koska chat, sekä koko yhteisön läsnäolo on itse asiassa täysin offline. Ratkaisu tähän ongelmaan on käyttää `Näkymätön` -tilaa, joka toimii samalla tavalla (ei paljasta tilaa), mutta pitää pystyä vastaanottamaan ja vastaamaan viesteihin (niin voi myös hylätä ilmoitukset ja lukemattomat viestit edellä todetulla tavalla). `Näkymätön` -tila on kaikkein järkevin tileille, joita et halua paljastaa (tilaviisainen), mutta silti voi lähettää komentoja.

On kuitenkin olemassa yksi saalis `Näkymätön` -tilassa - se ei mene hyvin ensisijaisilla tileillä. Tämä johtuu siitä, että **mikä tahansa** Steam-istunto, joka on tällä hetkellä verkossa **paljastaa** statuksen, vaikka ASF itse ei ole. Tämä johtuu Steam-verkon nykyisestä rajoituksesta/viasta, jota ei ole mahdollista korjata ASF:n puolella, joten jos haluat käyttää `Näkymätön` -tilaa, sinun on myös varmistettava, että **kaikki** muut istunnot samaan tiliin käyttävät myös `Näkymätön` -tilaa. Näin tapahtuu tileillä, joissa ASF on toivottavasti ainoa aktiivinen istunto, mutta ensisijaisilla tileillä haluat melkein aina näyttää `Online` ystävillesi, vain ASF:n toiminnan peittäminen, ja tässä tapauksessa `Näkymätön` tila on täysin hyödytön sinulle (suosittelemme käyttämään `Offline` -tilaa). Toivottavasti tämä rajoitus / bug lopulta ratkaistaan tulevaisuudessa Valve, mutta en odottaa, että se tapahtuu milloin tahansa...

Jos olet epävarma kuinka voit määrittää tämän ominaisuuden, ensisijaisille tileille on suositeltavaa käyttää arvoa `0` (`Offline`), ja oletus `1` (`Online`) muuten.

---

### `SalasanaFormaatti`

`byte` type with default value of `0` (`PlainText`). Tämä ominaisuus määrittelee `SteamPassword` -ominaisuuden muodon ja tukee tällä hetkellä **[-tietoturvan](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** mukaisia arvoja. Sinun tulee noudattaa siinä määriteltyjä ohjeita, koska sinun täytyy varmistaa, että `SteamPassword` ominaisuus todellakin sisältää salasanan matching `PasswordFormat`. Toisin sanoen, kun muutat `salasanaFormat` sitten `SteamPassword` pitäisi olla **jo** tuossa muodossa, ei vain pyritään olemaan. Ellet tiedä mitä olet tekemässä, sinun pitäisi pitää se oletusarvo `0`.

Jos päätät vaihtaa `PasswordFormat` botista, joka on jo kirjautunut Steam-verkkoon ainakin kerran, On mahdollista, että saat kertakäyttöisen salauksen virheen seuraavan botin käynnistyessä - tämä johtuu siitä, että `PasswordFormat` käytetään myös herkkien ominaisuuksien automaattisen salauksen tai salauksen purkamisen suhteen `Botissa. b` tietokantatiedosto. Voit turvallisesti sivuuttaa tämän virheen, koska ASF pystyy toipumaan tästä tilanteesta yksin. Jos se kuitenkin tapahtuu jatkuvasti, esim. jokainen uudelleenkäynnistys, se pitäisi tutkia.

---

### `LunastusPreferenssit`

`tavuliput` tyyppi, jonka oletusarvo on `0`. Tämä ominaisuus määrittää ASF:n käyttäytymisen cd-avainten lunastettaessa, ja se määritellään seuraavassa:

| Arvo | Nimi                               | Kuvaus                                                                                                                                       |
| ---- | ---------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------- |
| 0    | Tyhjä                              | Ei erityisiä lunastusasetuksia, oletus                                                                                                       |
| 1    | Eteenpäin                          | Välitä avaimet eivät ole käytettävissä lunastamaan muita botteja                                                                             |
| 2    | Jakaminen                          | Jaa kaikki avaimet keskenään ja muut botit                                                                                                   |
| 4    | KeepMissingGames                   | Säilytä näppäimet (mahdollisesti) puuttuviin peleihin välitettäessä, jättäen ne käyttämättömiksi                                             |
| 8    | AssumeWalletKeyOnBadActivationCode | Oletetaan, että `BadActivationCode` avaimet ovat yhtä suuria kuin `CannotRedeemCodeFromClient`, ja siksi yritä lunastaa ne lompakon avaimina |

Huomaa, että tämä ominaisuus on `liput` kenttä, joten on mahdollista valita jokin yhdistelmä käytettävissä olevia arvoja. Tutustu **[json kartoitukseen](#json-mapping)** jos haluat oppia lisää. Lippuja ei oteta käyttöön `Ei mitään` -vaihtoehtoa.

`Eteenpäinvälitys` aiheuttaa botti lähettää avaimen, joka ei ole mahdollista lunastaa, toiseen kytketty ja kirjautunut botti, joka puuttuu kyseisen pelin (jos mahdollista tarkistaa). Yleisin tilanne on toimittaa `jo ostettu` peli toiseen bottiin, josta puuttuu kyseinen peli, mutta tämä vaihtoehto kattaa myös muut skenaariot, kuten `DoesNotOwnRequiredApp`, `RateLimited` tai `Rajoitettu maa`.

`` jakelu aiheuttaa botti jakaa kaikki vastaanotetut avaimet keskenään ja muut botteja. Tämä tarkoittaa, että jokainen botti saa yhden avaimen erästä. Tyypillisesti tätä käytetään vain kun lunastat monta avainta samaan peliin, ja haluat tasaisesti jakaa ne botteja, toisin kuin lunastaa avaimet eri eri pelejä. Tämä ominaisuus ei ole järkevää, jos lunastat vain yhden avaimen yhdessä `lunastaa` toiminnon (koska ei ole ylimääräisiä avaimia jaettavaksi).

`KeepMissingGames` aiheuttaa botin ohittamisen `Eteenpäin` kun emme voi olla varmoja, onko avain lunastettu itse asiassa meidän panoksemme, tai ei. Tämä tarkoittaa pohjimmiltaan sitä, että `Eteenpäinvälitys` soveltaa **vain** `jo ostettuihin` avaimiin, sen sijaan, että käsiteltäisiin myös muita tapauksia, kuten `DoesNotOwnRequiredApp`, `RateLimited` tai `Rajoitettu maa`. Tyypillisesti haluat käyttää tätä valintaa ensisijaisella tilillä, varmistaa, että avaimet lunastetaan sillä ei välitetä eteenpäin, jos botti esimerkiksi tulee tilapäisesti `RateLimited`. Kuten voit arvata kuvauksesta, tällä alalla ei ole mitään vaikutusta, jos `Eteenpäinvälitys` ei ole käytössä.

`AssumeWalletKeyOnBadActivationCode` aiheuttaa `BadActivationCode` -avaimia, joita käsitellään `CannotRedeemCodeFromClient`, Näin ollen ASF yrittää lunastaa ne lompakon avaimet. Tätä tarvitaan, koska Steam saattaa ilmoittaa lompakon avaimista `BadActivationCode` (ja ei `CannotRedeemCodeFromClient` sellaisena kuin sitä käytettiin), tuloksena ASF ei koskaan yritä lunastaa niitä. Suosittelemme kuitenkin **vastaan** käyttämällä tätä asetusta, koska se johtaa ASF yrittää lunastaa jokainen virheellinen avain lompakon koodi, Steam-palveluun lähetettyjen (mahdollisesti mitättömien) pyyntöjen määrä on liian suuri, millä on kaikki mahdolliset seuraukset. Sen sijaan Suosittelemme käyttämään `ForceAssumeWalletKey` **[`lunastamaan ^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** samalla kun tietoisesti lunastavat lompakkoavaimet, joka mahdollistaa tarvittavan workaround vain kun se tarvitaan, on tarpeen mukaan.

Ottamalla käyttöön sekä `Eteenpäinvälitys` että `Distributing` lisää jakeluominaisuuden lähetyksen päälle yhden, joka tekee ASF yrittää lunastaa yhden avaimen kaikki botit ensin (huolinta) ennen kuin siirrytään seuraavalle (jakelu). Typically you want to use this option only when you want `Forwarding`, but with altered behaviour of switching the bot on key being used, instead of always going in-order with every key (which would be `Forwarding` alone). Tämä käyttäytyminen voi olla hyödyllistä, jos tiedät, että enemmistö tai jopa kaikki avaimet ovat sidoksissa samaan peliin, koska tässä tilanteessa `Eteenpäinvälittävä` yksin yrittäisi lunastaa kaiken yhdellä botti ensin (mikä on järkevää, jos avaimet ovat ainutlaatuisia pelejä), ja `` + `Jakaminen` vaihtaa bottia seuraavalla avaimella, "jakaa" tehtävä lunastaa uusi avain toiseen botti kuin alkuperäinen (joka on järkevää, jos avaimet ovat samaa peliä, ohitetaan yksi turha yritys avainta kohden).

Varsinainen bot-tilaus kaikille lunastamisskenaarioille on aakkosellinen, lukuun ottamatta käytettävissä olevia botteja, joita ei ole liitetty (ei kytketty, pysäytetty tai vastaava). Muistathan, että on olemassa per IP ja per tili tuntikohtainen määrä lunastamista yritykset, ja jokainen lunastus yrittää joka ei päättynyt `OK` myötävaikuttaa epäonnistuneiden kokeilujen. ASF tekee parhaansa minimoidakseen `jo ostettujen` -vikojen määrän, esim. yrittämällä välttää välittäminen avain toiseen bot, joka jo omistaa että erityisesti peli, mutta se ei ole aina taattu työtä johtuen miten Steam käsittelee lisenssejä. Käyttämällä lippujen lunastamista, kuten `Välittämällä` tai `Jakamalla` lisää aina todennäköisyyttä osua `RateLimited`.

Pidä myös mielessä, että et voi välittää tai jakaa avaimia boteihin, joihin sinulla ei ole pääsyä. Tämän pitäisi olla itsestään selvää. mutta varmista, että olet vähintään `Operaattori` kaikista niistä boteista, jotka haluat sisällyttää lunastusprosessiin, esimerkiksi `status ASF` **[komennolla](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `Etäviestintä`

`tavuliput` tyyppi, jonka oletusarvo on `3`. Tämä ominaisuus määrittelee -botti ASF käyttäytymistä, kun kyse on viestinnästä kauko-, kolmannen osapuolen palveluihin, ja on määritelty alla:

| Arvo | Nimi          | Kuvaus                                                                                                                                                                                                                                                                             |
| ---- | ------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0    | Tyhjä         | Ei sallita kolmannen osapuolen viestintää, renderöi valitut ASF-ominaisuudet käyttökelvottomiksi                                                                                                                                                                                   |
| 1    | Steam-ryhmä   | Sallii viestinnän **[ASF:n Steam-ryhmän](https://steamcommunity.com/groups/archiasf)** kanssa                                                                                                                                                                                      |
| 2    | Julkaiseminen | Mahdollistaa viestinnän **[ASF:n STM-listalle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** listautumisen mahdollistamiseksi, jos käyttäjä on myös ottanut käyttöön `SteamTradeMatcher` **[`TradingPreferences`](#tradingpreferences)** |

Huomaa, että tämä ominaisuus on `liput` kenttä, joten on mahdollista valita jokin yhdistelmä käytettävissä olevia arvoja. Tutustu **[json kartoitukseen](#json-mapping)** jos haluat oppia lisää. Lippuja ei oteta käyttöön `Ei mitään` -vaihtoehtoa.

Tämä vaihtoehto ei sisällä kaikkia ASF:n tarjoamia kolmannen osapuolen viestejä, vain niitä, joita muut asetukset eivät oleta. Jos esimerkiksi olet ottanut käyttöön ASF:n automaattiset päivitykset, ASF kommunikoi sekä GitHubin (lataukset) että palvelimen (tarkistussummavahvistukset) kanssa konfiguraatiosi mukaan. Samoin ottaa käyttöön `MatchActively` **[`TradingPreferences`](#tradingpreferences)** tarkoittaa yhteydenpitoa palvelimemme kanssa noteerattujen bottien noutamiseksi, jota tarvitaan kyseisen toiminnon osalta.

Lisäselvityksiä tästä aiheesta on saatavilla **[etäviestinnässä](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** -osiossa. Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `SendTradePeriod`

`tavu`-tyyppi, jonka oletusarvo on `0`. Tämä ominaisuus toimii hyvin samanlainen kuin `SendOnFarmingFinished` preferenssi `FarmingPreferences`, yhdellä erolla - sen sijaan, että lähetettäisiin kauppaa, kun maanviljely tehdään, Voimme myös lähettää sen joka `SendTradePeriod` tunnin välein riippumatta siitä, kuinka paljon maatilalla on jäljellä. Tämä on hyödyllistä, jos haluat `ryöstää` sinun alt tiliesi tavalliseen tapaan sen sijaan, että odottaisit sitä lopettamaan maanviljelyn. Oletusarvo `0` poistaa tämän ominaisuuden, jos haluat botti lähettää sinulle kaupan e. . joka päivä, sinun pitäisi laittaa `24` tähän.

Tyypillisesti haluat käyttää **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** yhdessä tämän ominaisuuden kanssa, Vaikka se ei ole vaatimus, jos aiot käsitellä 2FA vahvistukset manuaalisesti oikea-aikaisesti. Jos et ole varma kuinka asettaa tämän ominaisuuden, jätä se oletusarvoon `0`.

---

### `SteamKirjaudu`

`merkkijono` jonka oletusarvo on `null`. Tämä ominaisuus määrittelee höyryn sisäänkirjautumisen - sen, jota käytät höyryn sisäänkirjautumiseen. Sen lisäksi, että määritellään höyry kirjautuminen täällä, voit myös pitää oletuksena arvo `null` jos haluat syöttää höyryä kirjautuminen jokaisessa ASF käynnistys sen sijaan, että laitat sen config. Tämä voi olla sinulle hyödyllistä, jos et halua tallentaa arkaluontoisia tietoja asetustiedostoon.

---

### `SteamMasterClanID`

`ulong` -tyyppi, jonka oletusarvo on `0`. Tämä ominaisuus määrittelee höyryryhmän höyrytunnisteen, johon botti automaattisesti liittyy, mukaan lukien sen ryhmächat. Voit tarkistaa höyrytunnisteen ryhmästäsi navigoimalla sen **[sivu](https://steamcommunity.com/groups/archiasf)**, sitten lisäämällä `/memberslistxml? ml=1` linkin päähän, joten linkki näyttää **[tämä](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. Sitten voit saada höyrytunnisteen ryhmästäsi tuloksesta, se on `<groupID64>` -tunnuksessa. Edellä olevassa esimerkissä se olisi `103582791440160998`. Sen lisäksi, että yritämme liittyä annettuun ryhmään käynnistyksessä, botti hyväksyy automaattisesti myös ryhmäkutsut tähän ryhmään, mikä mahdollistaa sen, että voit kutsua botin manuaalisesti, jos ryhmälläsi on yksityinen jäsenyys. Jos sinulla ei ole ryhmää, joka on omistettu botteillesi, sinun tulee pitää tämä ominaisuus oletusarvolla `0`.

---

### `SteamParentalCode`

`merkkijono` jonka oletusarvo on `null`. Tämä ominaisuus määrittelee höyryn PIN-koodin. ASF edellyttää pääsyä höyryvanhemmilla suojattuihin resursseihin, joten jos käytät tätä ominaisuutta, sinun pitäisi antaa ASF vanhempien lukituksen PIN-koodi, jotta se voi toimia normaalisti. Oletusarvo `null` tarkoittaa, että ei ole höyryä vanhemman PIN-koodia, jota tarvitaan tämän tilin avaamiseksi. ja tämä on luultavasti mitä haluat, jos et käytä höyryä vanhempien toimintoja.

Rajoitetuissa olosuhteissa ASF pystyy myös luomaan kelvollisen Steam-vanhempainkoodin, itse Vaikka se vaatii liikaa käyttöjärjestelmän resursseja ja lisäaikaa loppuunsaattamiseen, puhumattakaan siitä, että se ei ole taattu menestyä, Siksi suosittelemme olemaan tukeutumatta tähän ominaisuuteen ja sen sijaan laita kelvollinen `SteamParentalCode` ASF käyttöön asetetussa asetuksessa. Jos ASF määrittää, että PIN-koodi on pakollinen, ja se ei pysty luomaan sitä yksin, se kysyy sinulta syötettä.

---

### `SteamPassword`

`merkkijono` jonka oletusarvo on `null`. Tämä ominaisuus määrittelee höyrysalasanan - sen, jota käytät höyryn sisäänkirjautumiseen. Sen lisäksi, että määritellään höyryn salasanan täällä, voit myös pitää oletuksena arvo `null` jos haluat syöttää höyrysalasanan jokaisessa ASF käynnistys sen sijaan, että laitat sen config. Tämä voi olla sinulle hyödyllistä, jos et halua tallentaa arkaluontoisia tietoja asetustiedostoon.

---

### `SteamTradeToken`

`merkkijono` jonka oletusarvo on `null`. Kun sinulla on botti ystäväsi lista, niin botti voi lähettää kaupan sinulle heti murehtimatta kaupan token, siksi voit jättää tämän ominaisuuden oletusarvoon `null`. Jos kuitenkin päätät olla sinun botti ystäväsi listalla, sitten sinun täytyy luoda ja täyttää kaupan token kuin käyttäjä, että tämä botti odottaa lähettää kaupat. Toisin sanoen, Tämä ominaisuus pitäisi täyttää kaupallisella tunnuksella tilille, joka on määritelty `Master` -luvalla `SteamUserPermissions` -luvassa **tässä** botti instanssissa.

Löytää token, kuten kirjautunut käyttäjä `Master` luvalla, navigoi **[tässä](https://steamcommunity.com/my/tradeoffers/privacy)** ja katso kaupan URL-osoite. Haemme merkki on tehty 8 merkkiä jälkeen `&token=` osa kaupan URL. Sinun pitäisi kopioida ja laittaa nämä 8 merkkiä tähän, kuten `SteamTradeToken`. Älä sisällytä koko kaupankäynnin URL, kumpikaan `&token=` osa, vain merkki itse (8 merkkiä).

---

### `SteamUserPermissions`

`Immutable Dictionary<ulong, byte>` tyyppi, jonka oletusarvo on tyhjä. Tämä ominaisuus on sanakirja ominaisuus, joka karttoja antanut Steam käyttäjä tunnistaa hänen 64-bittinen höyry ID, `tavu` -numero, joka määrittää hänen lupansa ASF tapauksessa. Tällä hetkellä käytettävissä olevat botin käyttöoikeudet ASF-järjestelmässä määritellään seuraavasti:

| Arvo | Nimi           | Kuvaus                                                                                                                                                                                                       |
| ---- | -------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| 0    | Tyhjä          | Ei erityislupaa, tämä on lähinnä viitearvo, joka on määritetty tässä sanakirjassa puuttuville höyryn tunnisteille - ei ole tarvetta määritellä ketään, jolla on tämä lupa                                    |
| 1    | PerheJakaminen | Tarjoaa vähimmäiskäyttöoikeudet perheille jakaville käyttäjille. Jälleen kerran, tämä on lähinnä viitearvo, koska ASF pystyy automaattisesti löytämään höyrytunnisteet, jotka sallimme käyttää kirjastoamme. |
| 2    | Operaattori    | Tarjoaa peruskäyttöoikeuden annettuihin bottiesiintymiin, lähinnä lisenssien lisäämiseen ja avainten lunastamiseen                                                                                           |
| 3    | Mestari        | Tarjoaa täyden pääsyn annettuun botin instanssiin                                                                                                                                                            |

Lyhyesti sanottuna, tämän ominaisuuden avulla voit käsitellä käyttöoikeuksia tietyille käyttäjille. Oikeudet ovat tärkeitä pääasiassa ASF **[komentojen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**käytön kannalta, mutta myös monien ASF ominaisuuksien, kuten kaupankäynnin hyväksymisen. Voit esimerkiksi haluta asettaa oman tilinsä `Master`, ja anna `Operaattorille` pääsy 2-3 ystävistäsi, jotta he voivat helposti lunastaa botin avaimet ASF:llä, **ei** ole tukikelpoinen e. . sen pysäyttämiseksi. Kiitos että voit helposti määrittää käyttöoikeuksia annetuille käyttäjille ja anna heidän käyttää bottia joihinkin määritelty olet astetta.

Suosittelemme asettamaan täsmälleen yhden käyttäjän `Master`, ja minkä tahansa summan haluat `Operaattorit` ja alla. Vaikka on teknisesti mahdollista asettaa useita `Masters` ja ASF toimii oikein niiden kanssa, esimerkiksi hyväksymällä kaikki niiden kaupat lähetetään panokselle, ASF käyttää vain yhtä niistä (matalin höyryn tunniste) jokaiseen toimeen, joka edellyttää yhtä tavoitetta, esimerkiksi `loot` -pyyntö, niin myös ominaisuuksia, kuten `SendOnFarmingValmistunut` mieltymys `FarmingPreferences` tai `SendTradePeriod`. Jos ymmärrät täysin nämä rajoitukset, erityisesti se, että `loot` pyyntö lähettää aina kohteita `Master` kanssa alhaisin höyry ID, riippumatta `Mestari` , joka suoritti komennon, sitten voit määritellä useita käyttäjiä `Master` -käyttöoikeudella tässä, mutta suosittelemme silti yhtä pääjärjestelmää.

On mukava huomata, että on vielä yksi ylimääräinen `Owner` -lupa, joka on julistettu `SteamOwnerID` maailmanlaajuiseksi config -omaisuudeksi. Et voi määrittää `Omistaja` lupaa kenellekään täällä, kuten `SteamUserPermissions` ominaisuus määrittelee vain oikeudet, jotka liittyvät bottiesimerkkiin, eikä ASF prosessina. bottiin liittyvissä tehtävissä `SteamOwnerID` kohdellaan samalla tavalla kuin `Master`, joten `SteamOwnerID` ei ole tässä tarpeen.

---

### `Kaupantarkistusjakso`

`tavu`-tyyppi, jonka oletusarvo on `60`. Normaalisti ASF käsittelee saapuvan kaupan tarjouksia heti saatuaan ilmoituksen yhdestä, mutta joskus koska Steam glitches se ei voi tehdä sitä tuolloin, ja tällainen kauppa tarjoukset jäävät huomiotta kunnes seuraava kaupan ilmoitus tai bot uudelleenkäynnistys tapahtuu, mikä voi johtaa kauppojen peruuttamiseen tai esineitä, jotka eivät ole myöhemmin käytettävissä. Jos tämä parametri on asetettu ei-nollaarvoon, ASF tarkistaa lisäksi tällaiset jäljellä olevat kaupat joka `TradeCheckPeriod` minuutissa. Oletusarvo on valittu tasapainolla lisäpyyntöjen välillä höyrypalvelimille ja menettämällä saapuvat kaupat mielessä. Kuitenkin, jos olet vain käyttää ASF maatilakortteja, ja älä suunnittele automaattisesti käsitellä saapuvia kauppoja, voit asettaa sen `0` poistaaksesi tämän ominaisuuden käytöstä kokonaan. Toisaalta, kun taas jos botti osallistuu julkisiin [ASF:n STM listalle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) tai tarjoaa muita automatisoituja palveluita kauppapanoksena Voit halutessasi pienentää tätä parametria `15` minuuttiin tai näin käsitelläksesi kaikki kaupat ajoissa.

---

### `TradingPreferences`

`tavuliput` tyyppi, jonka oletusarvo on `0`. Tämä ominaisuus määrittää ASF:n käyttäytymisen kaupankäynnissä, ja se määritellään alla:

| Arvo | Nimi                   | Kuvaus                                                                                                                                                                                                                                        |
| ---- | ---------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0    | Tyhjä                  | Ei erityisiä kaupankäyntisuosituksia, oletusarvot                                                                                                                                                                                             |
| 1    | Hyväksymislahjoitukset | Hyväksyy kaupat, joissa emme menetä mitään                                                                                                                                                                                                    |
| 2    | SteamTradeMatcher      | Passiivisesti osallistuu **[STM](https://www.steamtradematcher.com)**-tyyppisiin kauppoihin. Vieraile **[kaupankäynnin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** lisätietoja                          |
| 4    | MatchEverything        | Vaatii `SteamTradeMatcher` asetettavaksi ja yhdessä sen kanssa - hyväksyy myös hyviä ja neutraaleja kauppoja                                                                                                                                  |
| 8    | DontAcceptBotTrades    | Ei automaattisesti hyväksy `ryöstöä` muista botti instansseista                                                                                                                                                                               |
| 16   | MatchActively          | Osallistuu aktiivisesti **[STM](https://www.steamtradematcher.com)**-tyyppisiin kauppoihin. Vieraile **[TuotteetMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** saadaksesi lisätietoja |

Huomaa, että tämä ominaisuus on `liput` kenttä, joten on mahdollista valita jokin yhdistelmä käytettävissä olevia arvoja. Tutustu **[json kartoitukseen](#json-mapping)** jos haluat oppia lisää. Lippuja ei oteta käyttöön `Ei mitään` -vaihtoehtoa.

Lisäselvityksiä ASF kaupankäynnin logiikka ja kuvaus jokaisen käytettävissä olevan lipun, käy **[kaupankäynnin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** osiossa.

---

### `Siirrettävät Tyypit`

`ImmutableHashSet<byte>` tyyppi, jonka oletusarvo on `1, 3, 5` höyrytuotetyypit. Tämä ominaisuus määrittelee, mitkä Steam-tuotetyypit otetaan huomioon siirrettäessä bottien välillä, `siirron` **[komennon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. ASF varmistaa, että kaupalliseen tarjoukseen sisällytetään ainoastaan `-siirtotyyppisistä` peräisin olevista tuotteista, siksi tämä ominaisuus voit valita, mitä haluat saada kaupan tarjous, joka on lähetetty yksi sinun botteja.

| Arvo | Nimi                | Kuvaus                                                               |
| ---- | ------------------- | -------------------------------------------------------------------- |
| 0    | Tuntematon          | Jokainen tyyppi, joka ei sovi mihinkään alla olevaan                 |
| 1    | BoosterPack         | Booster-pakkaus, joka sisältää 3 satunnaista korttia pelistä         |
| 2    | Hymiö               | Hymiö jota käytetään Steam Chatissa                                  |
| 3    | FoilTradingCard     | `TradingCard` -kela muunnos                                          |
| 4    | Profiilitausta      | Profiilin tausta jota käytetään Steam-profiilissasi                  |
| 5    | TradingCard         | Höyrynvaihtokortti, jota käytetään merkkien nikkarointiin (ei folio) |
| 6    | SteamGems           | Steam-helmiä käytetään tehosteaineiden nikkarointiin, mukana säkit   |
| 7    | MyymäläItem         | Erityiset tuotteet myönnetään Steam-myynnin aikana                   |
| 8    | Kulutus             | Erityisiä kulutushyödykkeitä, jotka katoavat käytön jälkeen          |
| 9    | ProfileModifier     | Erikoiskohteet, jotka voivat muokata Steam-profiilin ulkoasua        |
| 10   | Tarra               | Erikoiskohteet, joita voidaan käyttää Steam-keskustelussa            |
| 11   | ChatEffect          | Erikoiskohteet, joita voidaan käyttää Steam-keskustelussa            |
| 12   | MiniprofiiliTausta  | Steam-profiilin erityinen tausta                                     |
| 13   | AvatarProfiiliKehys | Steamin profiilin erityinen profiilikuva                             |
| 14   | AnimatedAvatar      | Erityinen animoitu profiilikuva Steamiin                             |
| 15   | NäppäimistöSkin     | Erityinen näppäimistön iho Steam-kannelle                            |
| 16   | StartupVideo        | Erityinen aloitusvideo Steamin pakalle                               |

Huomaa, että riippumatta yllä olevista asetuksista ASF pyytää vain **[Steam-yhteisön kohteita](https://steamcommunity.com/my/inventory/#753_6)** (`appID` of 753, `kontekstID` of 6), joten kaikki peliesineet, lahjat ja niin ikään eivät kuulu kauppatarjouksen määritelmän mukaan.

Oletus ASF asetus perustuu yleisimpään käyttöön bot, jossa siirtämällä vain booster paketteja, ja kaupankäynnin kortteja (mukaan lukien folio). Tässä määritelty ominaisuus antaa sinulle mahdollisuuden muuttaa tuota käyttäytymistä millä tahansa tavalla, joka tyydyttää sinua. Muista, että kaikki tyypit, joita ei ole määritelty edellä, näytetään `Tuntematon` tyyppinä, mikä on erityisen tärkeää, kun Valve vapauttaa joitakin uusia Steam-kohteita, että merkitään `Tuntematon` ASF samoin, kunnes se on lisätty tähän (tulevaisuudessa julkaisu). Siksi yleensä ei ole suositeltavaa sisällyttää `Tuntematon` tyyppi `siirrettäviin`, ellet tiedä mitä olet tekemässä, ja ymmärrät myös, että ASF lähettää koko tavaraluettelosi kauppatarjouksessa, jos Steam Network hajoaa uudelleen ja raportoi kaikki tavarasi `Tuntematon`. Minun vahva ehdotukseni ei ole sisällyttää `Tuntematon` tyyppi `siirrettävissä olevat tyypit`, vaikka olisit valmis siirtämään kaiken.

---

### `Käytä Kirjautumisavaimia`

`bool` tyyppi, jonka oletusarvo on `true`. Tämä ominaisuus määrittelee, jos ASF käyttää kirjautumisavaimet mekanismia tälle Steam-tilille. Kirjautumisavaimet mekanismi toimii hyvin samanlainen kuin virallinen Steam-asiakkaan "muista minut" -vaihtoehto, which make it possible for ASF to store and use temporary kertatime use login key for next logon attempt, tehokkaasti ohittaen salasanan, Steam Guard tai 2FA koodin tarjoamisen tarpeen niin kauan kuin kirjautumisavain on voimassa. Kirjautumisavain on tallennettu `BotName.db` tiedostoon ja päivitetty automaattisesti. Siksi sinun ei tarvitse antaa salasanaa/SteamGuard/2FA koodia kirjauduttuasi onnistuneesti ASF:llä vain kerran.

Kirjautumisavaimet ovat oletusarvoisesti käytössä avullesi, joten sinun ei tarvitse syöttää `SteamPassword`, SteamGuard tai 2FA koodi (kun ei käytä **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**) jokaisessa sisäänkirjautumisessa. Se on myös ylivoimainen vaihtoehto, koska kirjautumisavain voidaan käyttää vain yhden kerran eikä paljasta alkuperäistä salasanaa millään tavalla. Alkuperäinen Steam-asiakasohjelma käyttää aivan samaa menetelmää, joka tallentaa tilisi nimen ja kirjautumisavaimen seuraavalle kirjautumisyrityksellesi, tehokkaasti sama kuin `SteamLogin` kanssa `UseLoginKeys` ja tyhjä `SteamPassword` ASF.

Jotkut ihmiset voivat kuitenkin olla huolissaan jopa tästä pienestä yksityiskohdasta, siksi tämä vaihtoehto on käytettävissä täällä, jos haluat varmistaa, että ASF ei tallenna mitään tunnusta, joka mahdollistaisi edellisen istunnon jatkamisen sulkemisen jälkeen, joka johtaa siihen, että täysi todennus on pakollinen jokaisessa kirjautumisyrityksessä. Tämän vaihtoehdon poistaminen käytöstä toimii täsmälleen samalla tavalla kuin "muista minut" ei tarkista virallista Steam-asiakasta. Ellet tiedä mitä olet tekemässä, sinun pitäisi pitää se oletusarvolla `tosi`.

---

### `Käyttäjäliittymätila`

`tavu`-tyyppi, jonka oletusarvo on `0`. Tämä ominaisuus määrittää käyttöliittymätilan jonka botti julkistetaan sen jälkeen, kun se on kirjautunut Steam-verkkoon. Se voi vaikuttaa siihen, miten tili näkyy esim. Steam-keskustelussa, jos läsnäolosi sallii sen `OnlineStatus` -palvelun kautta. Tällä hetkellä voit valita jonkin alla olevista tiloista:

| Arvo | Nimi       | Kuvaus                |
| ---- | ---------- | --------------------- |
| `0`  | VGUI       | Steamin oletustila    |
| `1`  | Tenfoot    | Suuren kuvan tila     |
| `2`  | Mobiili    | Steam mobiilisovellus |
| `3`  | Verkko     | Selaimen istunto      |
| `5`  | MobileChat | Steam mobiilisovellus |

Kohde-etuutena oleva `EUIMode` -tyyppi, jonka tämä ominaisuus perustuu kuitenkin käytettävissä oleviin arvoihin, parhaan tietämyksemme mukaan niillä ei ole mitään vaikutusta kuin nyt, joten ne on leikattu näkyvyyttä. Lisäksi, saatat olla kiinnostunut tarkistamaan `GamingDeviceType`, koska joitakin lisäominaisuuksia on otettu käyttöön.

Jos et ole varma kuinka asettaa tämän ominaisuuden, jätä se oletusarvoon `0`.

---

### `Webvälityspalvelin`

`merkkijono` jonka oletusarvo on `null`. Tämä ominaisuus määrittää web-välityspalvelimen osoitteen, jota käytetään bottikohtaiseen sisäiseen http-liittyvään viestintään, erityisesti palveluihin, kuten `api. teampowered.com`, `steamcommunity.com` ja `store.steampowered.com`. Jos sitä ei ole asetettu, ASF käyttää sen sijaan globaalia `WebProxy` -asetusta. ASF-pyyntöjen esittäminen voisi olla poikkeuksellisen hyödyllistä ohittaa erilaisia palomuureja, erityisesti Kiinan suuri palomuuri.

Tämän ominaisuuden katsotaan olevan uri merkkijono:

> URI-merkkijono koostuu järjestelmästä (tuettu: http/https/socks4/socks4a/socks5), isännästä ja valinnaisesta portista. Esimerkki täydellisestä uri merkkijonosta on `"http://contoso.com:8080"`.

Jos välityspalvelin vaatii käyttäjän tunnistautumista, sinun täytyy myös perustaa `WebProxyUsername` ja/tai `WebProxyPassword`. Jos tällaista tarvetta ei ole, yksin tämän omaisuuden perustaminen riittää.

Jos tarvitset myös sisäisen Steam-verkkoliikenteen (CM:t) lähettämistä, sitten sinun pitäisi varmistaa määrittää **[`SteamProtocols`](#steamprotocols)** bot's property to a value that allows only websocket transport, i. . arvo `4`, koska proxying tukee vain websockets .

Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `WebProxyPassword`

`merkkijono` jonka oletusarvo on `null`. Tämä ominaisuus määrittää salasanakenttä käytetään perustiedot, digest, NTLM, ja Kerberos autentikointi, jota tukee kohde `WebProxy` kone tarjoaa välityspalvelimen toiminnallisuutta. Jos välityspalvelusi ei vaadi käyttäjätunnuksia, sinun ei tarvitse syöttää mitään tähän. Tämän vaihtoehdon käyttäminen on järkevää vain, jos `WebProxy` käytetään samoin, koska sillä ei ole mitään vaikutusta toisin.

Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

### `WebProxyUsername`

`merkkijono` jonka oletusarvo on `null`. Tämä ominaisuus määrittää käyttäjätunnuksen kenttä käytetään perus-, digest, NTLM, ja Kerberos autentikointi, jota tukee kohde `WebProxy` kone tarjoaa välityspalvelimen toiminnallisuutta. Jos välityspalvelusi ei vaadi käyttäjätunnuksia, sinun ei tarvitse syöttää mitään tähän. Tämän vaihtoehdon käyttäminen on järkevää vain, jos `WebProxy` käytetään samoin, koska sillä ei ole mitään vaikutusta toisin.

Ellei sinulla ole syytä muokata tätä ominaisuutta, sinun pitäisi pitää se oletusarvoisena.

---

## Tiedoston rakenne

ASF käyttää melko yksinkertaista tiedostorakennetta.

```text
¶ 📁 config
- ASF. Poika
☐ ASF.db
¶ - Bot1. poika
¶ - Bot1.db
- Bot2. poika
¶ - Bot2.db
◄ ...
¶ ArchiSteamFarm.dll
¶ log.txt
◄ ...
```

Voit siirtää ASF uuteen sijaintiin, esimerkiksi toiseen tietokoneeseen, riittää liikuttamaan tai kopioimaan `config` -hakemistoa yksin, ja se on suositeltu tapa tehdä mitään "ASF varmuuskopioita", koska voit aina ladata jäljellä olevan (ohjelman) osan GitHubista, mutta et vaaranna sisäisten ASF-tiedostojen korruptoitumista, e. . viallisen varmuuskopion kautta.

`log.txt` tiedostossa on viimeisen ASF:n tuottama lokki. Tämä tiedosto ei sisällä mitään arkaluonteisia tietoja, ja se on erittäin hyödyllinen, kun on kyse ongelmista, kaatuu tai yksinkertaisesti informaationa sinulle mitä tapahtui viime ASF ajaa. Kysymme hyvin usein tästä tiedostosta, jos kohtaat ongelmia tai vikoja. ASF hallinnoi tätä tiedostoa automaattisesti, mutta voit edelleen säätää ASF **[kirjautumalla](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging)** moduuliin, jos olet edistynyt käyttäjä.

`config` -hakemisto on paikka, jolla on ASF:lle konfigurointi, mukaan lukien kaikki sen bottit.

`ASF.json` on globaali ASF asetustiedosto. Tätä asetusta käytetään määrittämään, miten ASF käyttäytyy prosessina, joka vaikuttaa kaikkiin botit ja itse ohjelma. Löydät sieltä globaaleja ominaisuuksia, kuten ASF-prosessin omistaja, automaattiset päivitykset tai vianetsintä.

`BotName.json` on tietyn botin konfigurointi. Tätä asetusta käytetään määritettäessä, miten annettu botti esimerkiksi käyttäytyy, siis nämä asetukset ovat erityisiä vain botti eikä jaeta muiden kanssa. Tämän avulla voit määrittää botit eri asetuksia eikä välttämättä kaikki toimivat täsmälleen samalla tavalla. Jokainen botti on nimetty yksilöllisellä tunnisteella, jonka olet valinnut tilalle `BotName`.

Asetustiedostojen lisäksi ASF käyttää myös `config` -hakemistoa tietokantojen tallentamiseen.

`ASF.db` on maailmanlaajuinen ASF-tietokantatiedosto. Se toimii maailmanlaajuisena pysyvänä tallennustilana, ja sitä käytetään erilaisten ASF-prosessiin liittyvien tietojen, kuten paikallisten Steam-palvelimien IP-osoitteiden, tallentamiseen. **Sinun ei pitäisi muokata tätä tiedostoa**.

`BotName.db` on tietokanta annetusta bottiesiintymästä. Tätä tiedostoa käytetään tietyn botin tärkeiden tietojen tallentamiseen pysyvässä tallennustilassa, kuten kirjautumisnäppäimillä tai ASF 2FA:lla. **Sinun ei pitäisi muokata tätä tiedostoa**.

`BotName.keys` on erityinen tiedosto, jota voidaan käyttää avainten tuomisessa **[taustapelien lunastajaan](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. Se ei ole pakollista eikä luotu, mutta ASF tunnustaa. Tämä tiedosto poistetaan automaattisesti, kun avaimet on tuotu onnistuneesti.

`BotName.maFile` on erikoistiedosto, jota voidaan käyttää **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**. Se ei ole pakollista eikä luotu, mutta ASF tunnistaa, jos `BotName` ei käytä ASF 2FA:ta. Tämä tiedosto poistetaan automaattisesti ASF 2FA:n tuonnin jälkeen.

---

## JSON kartoitus

Jokaisella konfiguraatio-ominaisuudella on sen tyyppi. Omaisuuden tyyppi määrittelee arvot, jotka ovat voimassa sitä varten. Voit käyttää vain arvoja, jotka ovat voimassa annettuun tyyppiin - jos käytät virheellistä arvoa, sitten ASF ei voi jäsentää konfiguraatiota.

**Suosittelemme vahvasti käyttämään ConfigGeneratoria configs** - se käsittelee suurimman osan matalan tason tavarasta (kuten tyypit validointi) sinulle, joten sinun tarvitsee vain syöttää oikeita arvoja, ja sinun ei myöskään tarvitse ymmärtää alla mainittuja muuttujatyyppejä. Tämä osio on tarkoitettu lähinnä ihmisille, jotka tuottavat / muokkaavat confiksejä manuaalisesti, joten he tietävät, mitä arvoja he voivat käyttää.

ASF:n käyttämät tyypit ovat kotoperäisiä C# tyyppejä, jotka on määritelty alla:

---

`bool` - Boolean tyyppi hyväksyy vain `true` ja `vääriä` arvoja.

Esimerkki: `"Käytössä": true`

---

`tavu` - allekirjoittamaton tavutyyppi, joka hyväksyy vain kokonaislukuja `0` `255` (sisältää).

Esimerkki: `"ConnectionTimeout": 90`

---

`ushort` - allekirjoittamaton lyhyt tyyppi, vain kokonaislukua `0` `65535` (sisältyen).

Esimerkki: `"WebLimiterDelay": 300`

---

`uint` - Allekirjoittamaton kokonaisluku tyyppi, joka hyväksyy vain kokonaislukuja `0` `4294967295` (sisältää).

---

`ulong` - Allekirjoittamaton pitkä kokonaisluku tyyppi, joka hyväksyy vain kokonaislukuja `0` `18446744073709551615` (sisältää).

Esimerkki: `"SteamMasterClanID": 103582791440160998`

---

`merkkijono` - merkkijono, hyväksyen minkä tahansa sarjan merkkejä, mukaan lukien tyhjä järjestys `""` ja `nolla`. Tyhjä järjestys ja ASF kohtelee `null` -arvoa samalla tavalla. Joten se on oman mieltymyksesi mukaan jota haluat käyttää (me kiinni kanssa `null`).

Esimerkit: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MyAccountName"`

---

`Opas?` - Nullable UUID tyyppi, JSON merkkijonoksi. UUID on valmistettu 32 heksadesimaalista, välillä `0` – `9` ja `a` – `f`. ASF hyväksyy erilaisia kelvollisia formaatteja - pieni, iso kirjain, väliviivoilla ja ilman. Voimassa olevan UUID:n lisäksi, koska tämä ominaisuus on mitätöitävä, hyväksytään `null` -arvon erityisarvo, joka ilmaisee UUID:n puuttumisen.

Esimerkkejä: `"LisenssiID": null`, `"LisenssiID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableList<valueType>` - Immutable collection (list) of values in given `valueType`. JSONissa se on määritelty joukko elementtejä annetuissa `arvotyyppi`. ASF käyttää `luetteloa` osoittaakseen, että tietty ominaisuus tukee useita arvoja ja että niiden järjestys voi olla relevantti.

Esimerkki `Immutablelist<byte>`: `"Maataloustilat": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` - Immutable collection (set) yksilöllisiä arvoja annettu `arvotyyppi`. JSONissa se on määritelty joukko elementtejä annetuissa `arvotyyppi`. ASF käyttää `HashSet` osoittaakseen, että annettu ominaisuus on järkevää vain ainutlaatuisille arvoille ja että niiden järjestyksellä ei ole väliä, siksi se tahallisesti sivuuttaa mahdolliset kaksoiskappaleet jäsennyksen aikana (jos sait toimittaa ne joka tapauksessa).

Esimerkki `ImmutableHashSet<uint>`: `"Blacklist": [267420, 303700, 335590]`

---

`Immutable Dictionary<keyType, valueType>` - Immutable dictionary (kartta), joka kartoittaa sen `avaintyyppi`, arvo on määritetty sen `arvotyyppi`. JSONissa se on määritelty objektiksi, jolla on avainarvoparia. Muista, että `keyType` on aina lainattu tässä tapauksessa, vaikka sen arvo tyyppi, kuten `ulong`. On myös tiukka vaatimus siitä, että avain on ainutlaatuinen kautta kartan, tällä kertaa täytäntöön JSON samoin.

Esimerkki `ImmutableDictionary<ulong, byte>`: `"SteamUserPermissions": { "76561198174813138": 3, "765611981748137": 1 }`

---

`liput` - Lippujen attribuutti yhdistää useita eri ominaisuuksia yhdeksi lopulliseksi arvoksi käyttämällä bitwise toimintoja. Näin voit valita minkä tahansa mahdollisen yhdistelmän eri sallittuja arvoja samanaikaisesti. Lopullinen arvo on laskettu kaikkien käytössä olevien vaihtoehtojen arvojen summana.

Esimerkiksi seuraava määritelmä:

| Arvo | Nimi  |
| ---- | ----- |
| 0    | Tyhjä |
| 1    | A     |
| 2    | B     |
| 4    | C     |

There are exactly 3 meaningful, available flags to switch on/off (`A`, `B`, `C`), and therefore `8` possible valid combinations overall:

| Lopullinen arvo | Käytössä olevat liput |
| --------------- | --------------------- |
| 0               | `Tyhjä`               |
| 1               | `A`                   |
| 2               | `B`                   |
| 3               | `A` + `B`             |
| 4               | `C`                   |
| 5               | `A` + `C`             |
| 6               | `B` + `C`             |
| 7               | `A` + `B` + `C`       |

Jotta edellä mainittu olisi mahdollista, jokaisen itsenäisen lipun on sen vuoksi oltava kahden toimivalta. Tämän vuoksi esimerkiksi `D`-merkinnän lisäarvon olisi oltava `8` tai suurempi.

Yleensä graafiset työkalut tekevät laskelman puolestasi. Jos muokkaat asetuksia manuaalisesti, voit aina käyttää laskinta ja yksinkertaisesti lisätä yhteen alla olevat arvot kaikista lipuista, jotka haluat ottaa käyttöön - kuten yllä olevassa esimerkissä.

Esimerkki: `"SteamProtocols": 7` (joka mahdollistaa liput arvon `1`, `2` ja `4`, kuten edellä on selitetty)

---

## Yhteensopivuuden kartoitus

Koska JavaScriptin rajoitukset eivät pysty kunnolla serialisoimaan yksinkertaisia `ulong` -kenttiä JSONissa, kun käytät web-pohjaista ConfigGeneratoria, `ulong` -kentät renderöidään merkkijonoina, joilla on `s_` etuliite tuloksena olevassa konfiguroissa. Tämä sisältää esimerkiksi `"SteamOwnerID": 76561198006963719` , jonka kirjoittavat meidän ConfigGenerator nimellä `"s_SteamOwnerID": "76561198006963719"`. ASF sisältää oikean logiikan tämän merkkijonokartoituksen käsittelyyn automaattisesti, joten `s_` asetukset ovat oikeita ja oikein luotuja. Jos luot asetuksia itse, suosittelemme pysymään alkuperäisillä `ulong` -kentillä, jos mahdollista, mutta jos et pysty tekemään niin, Voit myös seurata tätä teemaa ja koodata ne merkkijonoina, joiden nimiin on lisätty `s_` -etuliite. Toivomme voivamme ratkaista tämän JavaScript-rajoituksen lopulta.

---

## Yhteensopivuus konfigurojen kanssa

On ensisijaisen tärkeää, että ASF pysyy yhteensopiva vanhempien asetusten kanssa. Kuten sinun pitäisi jo tietää, puuttuvat config ominaisuudet käsitellään samalla tavalla kuin ne olisi määritelty niiden **oletusarvot**. Siksi, jos uusi config ominaisuus otetaan käyttöön uudessa ASF versiossa, kaikki config pysyy **yhteensopiva** uuden version kanssa, ja ASF kohtelee tätä uutta config ominaisuutta määriteltynä sen **oletusarvolla**. Voit aina lisätä, poistaa tai muokata config ominaisuuksia tarpeiden mukaan.

Suosittelemme rajaamaan määritetyt config ominaisuudet vain niille, joita haluat muuttaa, koska näin voit automaattisesti periä oletusarvot kaikille muille, paitsi pitää config puhdas, mutta myös lisätä yhteensopivuus jos päätämme muuttaa oletusarvo omaisuutta, että et halua nimenomaisesti asettaa itseäsi (e. . `WebLimiterDelay`).

Edellä esitetyn vuoksi ASF siirtää/optimoi asetuksesi muotoilemalla ne uudelleen ja poistamalla oletusarvoa pitävät kentät. Voit poistaa tämän käytöksen käytöstä käyttämällä `--no-config-migrate` **[komentoriviparametria](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** jos sinulla on jokin tietty syy, Esimerkiksi tarjoat vain luku -asetustiedostoja etkä halua ASF: n muokkaavan niitä.

---

## Automaattinen Uudelleenlataus

ASF on tietoinen confis on muutettu "on-the-fly" - ansiosta, että ASF automaattisesti:
- Luo (ja aloita tarvittaessa) uusi bottiesimerkki, kun luot sen konfiguroinnin
- Pysäytä (jos tarpeen) ja poista vanha botti ilmentymä, kun poistat sen config
- Pysäytä (ja aloita tarvittaessa) mikä tahansa bottiesimerkki, kun muokkaat sen konfiguraatiota
- Käynnistä uudelleen (jos tarpeen) botti uudella nimellä, kun uudelleennimeät sen asetukset

Kaikki edellä mainitut ovat läpinäkyviä ja tehdään automaattisesti ilman tarvetta käynnistää ohjelma uudelleen, tai tappaa muita (vaikuttamattomia) bottiesiintymiä.

Tämän lisäksi ASF käynnistää itsensä uudelleen (jos `Autouudelleenkäynnistys` salli), jos muokkaat core ASF `ASF.json` -konfiguraatiota. Samoin ohjelma sulkee, jos poistat tai nimesi uudelleen.

Voit poistaa tämän käytöksen käytöstä käyttämällä `--no-config-watch` **[komentoriviparametria](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** jos sinulla on jokin tietty syy, Esimerkiksi et halua ASF:ltä reagoida tiedostomuutoksiin `config` -hakemistossa.