# ItemsMatcherPlugin

`TuotteetMatcherPlugin` on virallinen ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** , joka laajentaa ASF STM listaus ominaisuuksia. Erityisesti Tämä sisältää `PublicListing` **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** ja `MatchActively` in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. ASF mukana tulee `TuotteetMatcherPlugin` mukana yhdessä julkaisu, joten se on valmis käyttöön heti.

---

## `Julkaiseminen`

Julkinen lista, kuten nimi kertoo, on listaus tällä hetkellä saatavilla ASF STM botteja. Se sijaitsee **[sivuillamme](https://asf.justarchi.net/STM)**, hallinnoidaan automaattisesti ja käytetään julkisena palveluna molemmille ASF:n käyttäjille, jotka käyttävät `MatchActively`, sekä ASF ja muut kuin ASF käyttäjät manuaaliseen yhdistämiseen.

Jotta voit olla listattu, sinulla on joukko vaatimuksia täyttää. Vähintään sinun on täytynyt sallia `PublicListing` in `RemoteCommunication` (default setting), `SteamTradeMatcher` käytössä `TradingPreferences`, **[julkinen tavaraluettelo](https://steamcommunity.com/my/edit/settings)** yksityisyysasetukset, **[rajoittamaton](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** ja **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** aktiivinen. Lisävaatimukset sisältävät 2FA käytössä vähintään 15 päivää, viimeinen salasana vaihtuu yli 5 päivää sitten, tilirajoitusten puuttuminen, kuten työsulkut, taloudelliset kiellot ja kaupan kieltäminen. Luonnollisesti, sinulla on oltava myös vähintään yksi (vaihdettavissa) kohde tavaraluettelossa määritelty `MatchableTypes`, kuten kaupankäyntikortteja. Sen lisäksi bootteja, joissa on enemmän kuin `500000` kohdetta, ei hyväksytä liiallisen yläpinnan vuoksi, suosittelemme jakamaan tavaraluettelosi useille tileille tässä tapauksessa.

Vaikka `Julkistaminen` on oletusarvoisesti käytössä, Huomaa, että et **ole** näytetään verkkosivuilla, jos et täytä kaikkia vaatimuksia, erityisesti `SteamTradeMatcher`, joka ei ole oletusarvoisesti käytössä. Ihmisille, jotka eivät täytä kriteerejä, vaikka he pitivät `PublicListing` käytössä, ASF ei kommunikoi palvelimen kanssa millään tavalla. Julkinen listaus on myös yhteensopiva vain uusimman vakaan version ASF ja voi kieltäytyä näyttämästä vanhentuneita botteja, varsinkin jos niistä puuttuu ydintoiminto, joka löytyy vain uudemmista versioista.

### Miten se juuri toimii

ASF lähettää alustavaa dataa kerran sisäänkirjautumisen jälkeen, joka sisältää kaikki kiinteistöt julkinen listaus hyödyntää. Sitten joka 10 minuutti ASF lähettää yhden, hyvin pieni "heartbeat" pyyntö, joka ilmoittaa palvelimellemme, että botti on edelleen käynnissä. Jos jostain syystä sydämen syke ei tullut, esimerkiksi verkottumisongelmien vuoksi, sitten ASF yrittää lähettää sen uudelleen joka minuutti, kunnes palvelin rekisteröi sen. Tällä tavoin palvelimemme tietää tarkasti, mitkä botit ovat edelleen käynnissä ja valmiita hyväksymään kauppatarjouksia. ASF lähettää myös tarvittavan alustavan ilmoituksen, esimerkiksi jos se havaitsee, että varastomme on muuttunut edellisen ilmoituksen jälkeen.

Näytämme kaikki hyväksyttävät ASF tilit, jotka olivat aktiivisia **viimeisen 15 minuuttia**. Käyttäjät on lajiteltu niiden suhteellisen hyödyllisyyden mukaan - `MatchEverything` -botit, jotka on esitetty `millä tahansa` bannerilla, jotka hyväksyvät kaikki 1:1 kaupat, sitten ainutlaatuisia pelejä määrä, ja lopulta kohteita lasketaan.

### API

ASF STM -listaus hyväksyy vain ASF botit toistaiseksi. Ei ole mitään keinoa luetella kolmannen osapuolen botteja listauksellamme toistaiseksi, koska emme voi tarkistaa niiden koodi helposti ja varmistaa, että ne täyttävät koko kaupankäynnin logiikka. Osallistuminen listalle vaatii viimeisimmän vakaan ASF version, vaikka se voi ajaa custom **[plugins](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

Listauksen kuluttajille meillä on hyvin yksinkertainen **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** päätetapahtuma, jota voit käyttää. Se sisältää kaikki saatavilla olevat tiedot lukuun ottamatta käyttäjien varastoja, jotka ovat osa `MatchActively` -ominaisuutta.

### Yksityisyyden suoja

Jos suostut listalle listalle ottamalla käyttöön `SteamTradeMatcher` ja kieltäytymällä `Listing`, kuten edellä on määritelty, me tallennamme väliaikaisesti joitakin Steam-tilisi tietoja palvelimellemme, jotta voimme tarjota odotetun toiminnon.

Julkiset tiedot (joita Steam paljastaa kaikille kiinnostuneille) sisältävät:
- Steam-henkilöllisyystodistuksesi (64-bittisessä muodossa, linkkien luomiseksi)
- Nimimerkkisi (näytettäväksi)
- Sinun avatar (hash, näytettäväksi)

Ehdollinen julkinen tieto (Steam altistuu kaikille asianomaisille osapuolille, jos täytät listausvaatimukset) sisältää:
- Sinun **[-tavaraluettelosi](https://steamcommunity.com/my/inventory/#753_6)** (jotta ihmiset voivat käyttää `MatchActively` -tavaroitasi vastaan).

Yksityinen tieto (toiminnon tarjoamiseen tarvittavat valitut tiedot) sisältää:
- Sinun **[kaupankäynnin tunniste](https://steamcommunity.com/my/tradeoffers/privacy)** (niin ihmiset ulkopuolella ystävällislistalta voi lähettää sinulle kauppaa)
- Sinun `MatchableTypes` asetus (näyttötarkoituksiin ja vastaavuuteen)
- `MatchEverything` -asetus (näytön ja vastaavuuden osalta)
- Sinun `MaxTradeHoldDuration` asetus (joten muut ihmiset tietävät, haluatko hyväksyä heidän kaupankäyntinsä)

Siitä hetkestä lähtien, kun lopetat listautumisen (ilmoittamisen) käytön, tietosi eivät enää ole suuren yleisön saatavilla enintään 15 minuutin kuluessa, ja muuten pidetään palvelimellamme enintään kaksi viikkoa - kaikki poistetaan automaattisesti tämän ajanjakson jälkeen. Sinulta ei vaadita toimia, jotta se tapahtuisi.

---

## `MatchActively`

`MatchActively` -asetus on aktiivinen versio **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** mukaan lukien interaktiivinen haku, jossa botti lähettää kaupat muille ihmisille. Se voi toimia yksin, tai yhdessä `SteamTradeMatcher` -asetuksen kanssa. Tämä ominaisuus vaatii `Lisenssitunniste` asetettavan, koska se käyttää kolmannen osapuolen palvelinta ja maksettuja resursseja toimiakseen.

Jotta voisit käyttää tätä vaihtoehtoa, sinulla on joukko vaatimuksia täyttää. Vähintään sinulla on oltava **[rajoittamaton](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** -tili, **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** aktiivinen ja vähintään yksi kelvollinen tyyppi `Tyypeissä`, kuten kaupankäynnin kortteja. Lisävaatimukset sisältävät 2FA käytössä vähintään 15 päivää, viimeinen salasana vaihtuu yli 5 päivää sitten, tilirajoitusten puuttuminen, kuten työsulkut, taloudelliset kiellot ja kaupan kieltäminen.

Jos täytät kaikki edellä esitetyt vaatimukset ASF kommunikoi ajoittain **[julkisen ASF STM listalle](#publiclisting)** voidakseen aktiivisesti sovittaa yhteen tällä hetkellä saatavilla olevat botit.

Yhdistämisen aikana ASF botti hakee oman tavaraluettelonsa, sitten kommunikoida palvelimen kanssa sen kanssa löytääksesi kaikki mahdolliset `MatchableTypes` -ottelut muilta, tällä hetkellä saatavilla olevilta botteilta. Kiitos kommunikoida suoraan palvelimen kanssa, tämä prosessi vaatii yhden pyynnön ja meillä on välitöntä tietoa siitä, onko käytettävissä botti tarjoaa meille jotain mielenkiintoista - jos vastaavuus löytyy, ASF lähettää ja vahvistaa kaupan tarjouksen automaattisesti.

Tämän moduulin on tarkoitus olla läpinäkyvä. Yhdistäminen alkaa noin `1` tunnissa ASF käynnistyksen jälkeen ja toistaa itsensä joka `6` tunnissa (jos tarpeen). `MatchActively` -ominaisuutta on tarkoitus käyttää pitkäaikaisena, määräaikaisena toimenpiteenä sen varmistamiseksi, että olemme aktiivisesti menossa kohti valmistumista, kuitenkin käyttäjät, jotka eivät käytä ASF 24/7 voi myös harkita `ottelua` **[komento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Tämän moduulin kohderyhmät ovat ensisijaisia tilejä ja "stash" alt tilejä, vaikka sitä voidaan käyttää millä tahansa bottilla, jota ei ole asetettu `MatchEverything`. Sen lisäksi botteja, joissa on enemmän kuin `500000` kohdetta, ei hyväksytä vastaamiseen liiallisen yläpinnan vuoksi, suosittelemme jakamaan tavaraluettelosi useille tileille tässä tapauksessa.

ASF tekee parhaansa minimoidakseen tämän vaihtoehdon avulla syntyneiden pyyntöjen ja paineiden määrän, kun taas samaan aikaan maksimoidaan tehokkuus vastaa ylärajaa. Tarkka algoritmi valita botit vastaamaan ja muuten järjestää koko prosessin, on ASF:n täytäntöönpanon yksityiskohta ja voi muuttaa palautetta, tilannetta ja mahdollisia tulevia ideoita.

Algoritmin nykyinen versio tekee ASF priorisoivaksi `Mikä tahansa` bots ensin. erityisesti ne, joilla on parempi moninaisuus pelejä, että niiden tuotteet ovat kotoisin. Kun `mikä tahansa` botti, ASF siirtyy `Fair` -tasolle saman monimuotoisuutta koskevan säännön mukaisesti. ASF yrittää sovittaa yhteen jokaisen käytettävissä olevan botin ainakin kerran, varmistaakseen, että emme puutu mahdollisesta edistyksestä.

`MatchActively` ottaa huomioon botit, joita mustalla listalla olet kaupankäynnissä `tbadd` **[komennon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** eikä yritä aktiivisesti sovittaa niitä. Tätä voidaan käyttää kertomaan ASF:lle mitkä botit sitä ei pitäisi milloinkaan vastaaa, vaikka heillä olisikin mahdollisia dupeja käyttääksemme.

ASF tekee myös parhaansa varmistaakseen, että tarjoukset ovat käymässä läpi. Seuraavalla kierroksella, joka normaalisti tapahtuu 6 tunnissa, ASF peruu vireillä olevat tarjoukset, joita ei vielä hyväksytty, ja depriorisoida höyrytunnisteet, jotka osallistuvat niihin, toivottavasti mieluummin aktiivisempia botteja ensin. Silti jos depriitioidut botit ovat viimeisiä, joilla on tarvitsemamme ottelu, yritämme silti sovittaa ne yhteen (uudelleen).

---

### Miksi tarvitsen `lisenssinumeron` käyttääkseni `MatchActively`? Eikö se ollut aiemmin ilmaista?

ASF on vapaa ja avoin, kuten se perustettiin hankkeen alussa lokakuussa 2015. Lähdekoodi `ItemsMatcher` plugin ja siksi `MatchActively` ominaisuus on saatavilla arkistossamme, vaikka ASF ohjelma on täysin ei-kaupallinen, emme ansaitse mitään maksuosuuksista, rakentaa tai julkaista. Viimeisten 7 vuoden aikana ASF on saanut valtavan määrän kehitystä, ja se on edelleen parannettu ja parannettu joka kuukausittainen vakaa julkaisu enimmäkseen yksi henkilö, **[JustArchi](https://github.com/JustArchi)** - merkkijonoja ei ole liitetty. Ainoa rahoitus, jota saamme muilta kuin pakollisilta lahjoituksilta, tulee käyttäjiltämme.

Jo hyvin pitkään, lokakuuhun 2022 asti, `MatchActively` -ominaisuus oli osa ASF ydintä ja kaikkien käytettävissä. Lokakuussa 2022 Valve, Steamin takana oleva yritys, on asettanut erittäin tiukat nopeusrajoitukset muiden bottejen varastojen hakemiselle, mikä teki aiemmasta toiminnosta täysin rikki, joilla ei ole mahdollisuutta ratkaista tätä ongelmaa. Siksi, koska se, että ominaisuus on tullut täysin hauras, ilman mahdollisuutta olla kiinteä, se oli poistettava ASF:n ytimestä vanhentuneena.

`MatchActively` herätettiin henkiin osana virallista `esineetMatcher` plugin, joka edelleen parantaa ASF aktiivisilla korteilla vastaavia toimintoja, perustuu täysin uudistettu konsepti. Resurrecting `MatchActively` ominaisuus vaaditaan meiltä **ylimääräinen määrä työtä** luoda ASF taustaosa, täysin uusi palvelu isännöi palvelimella, jossa on yli sata maksullista edustajaa varastojen ratkaisemiseksi, kaikki yksinomaan jotta ASF asiakkaat voivat käyttää `MatchActively` kuten ennen. Työn määrän vuoksi tehtävä työ sekä resursseja, jotka eivät ole ilmaisia ja jotka meidän on maksettava kuukausittain (verkkotunnus, palvelin, proxies), olemme päättäneet tarjota tämän toiminnon sponsoreillemme, eli ihmiset, jotka jo tukevat ASF-hanketta kuukausittain, joiden ansiosta voimme asettaa maksetut varat saataville.

Tavoitteemme ei ole hyötyä siitä, vaan pikemminkin kattaa **kuukausittaiset kustannukset** , jotka liittyvät yksinomaan tämän vaihtoehdon tarjoamiseen - siksi tarjoamme sitä pohjimmiltaan tyhjäksi, mutta meidän täytyy veloittaa hieman siitä, koska emme voi maksaa satoja dollareita omista taskuistamme joka kuukausi, vain jotta se on käytettävissä. Emme oikeastaan pysty keskustelemaan hinnasta, se on venttiili, joka pakotti nämä kustannukset meillekin, ja vaihtoehtona on, ettei tällaista ominaisuutta ole saatavilla, mikä tietenkin pätee jos päätät, mistä tahansa syystä, että et voi perustella meidän plugin näillä ehdoilla.

Joka tapauksessa ymmärrämme, että `MatchActively` ei ole kaikille, ja toivomme, että ymmärrät myös, miksi emme voi tarjota sitä ilmaiseksi. Jos kukaan ei olisi kiinnostunut auttamaan tämän ominaisuuden kustannusten kattamisessa, se ei yksinkertaisesti olisi olemassa, kuten meidän olisi pakko leikata kuukausittaisia menoja, joita kukaan ei ole valmis ylläpitämään. Onneksi olemme paremmassa asemassa kuin se, ja voit päättää itse, haluatko käyttää `MatchActively` noilla ehdoilla vai ei.

---

### Miten voin saada yhteyden?

`TuotteetMatcher` tarjotaan osana kuukausittaista 5+ $:n sponsoritasoa **[JustArchin GitHub](https://github.com/sponsors/JustArchi)**. On myös mahdollista tulla kertaluonteiseksi sponsoriksi, vaikka tässä tapauksessa lisenssi on voimassa vain kuukauden (jonka voimassaoloa voidaan jatkaa samalla tavalla). Kun olet tullut sponsori $5 tier (tai uudempi), lue **[konfiguraatio](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** osio saada ja täyttää `Lisenssi`. Jälkeen, sinun tarvitsee vain ottaa käyttöön `MatchActively` valitun botin `TradingPreferences`.

Lisenssi sallii sinun lähettää rajoitetun määrän pyyntöjä palvelimelle. $5 -taso antaa sinun käyttää `MatchActively` yhdelle bottitilille (4 pyyntöä päivittäin), ja jokainen ylimääräinen $5 lisää kaksi bottitiliä (8 pyyntöä päivittäin). Esimerkiksi, jos haluat käyttää sitä kolmella tilillä, se katetaan $ 10 tasoa ja korkeampi.