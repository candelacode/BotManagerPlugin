# Kaksivaiheinen tunnistautuminen

Steamiin kuuluu kaksivaiheinen tunnistautumisjärjestelmä, joka vaatii lisäyksityiskohtia tiliin liittyvään toimintaan. Voit lukea lisää siitä **[täällä](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** ja **[täällä](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. Tämä sivu katsoo, että 2FA järjestelmä sekä meidän ratkaisu, joka integroituu siihen, kutsutaan ASF 2FA.

---

# ASF logiikka

Riippumatta siitä, käyttääkö ASF 2FA:ta tai ei, ASF sisältää asianmukaisen logiikan ja on täysin tietoinen 2FA Steamin suojaamista tileistä. Se kysyy sinulta vaaditut tiedot, kun niitä tarvitaan (kuten sisäänkirjautumisen aikana). Vaikka voit manuaalisesti antaa nämä tiedot, tietyt ASF-toiminnot (kuten `MatchActively`) edellyttävät ASF 2FA -toiminnallisuutta bottitililläsi, joka voi automaattisesti vastata 2FA-kehotteisiin automaattisesti, aina kun ASF sitä vaatii.

---

# ASF 2FA

ASF 2FA on sisäänrakennettu moduuli, joka vastaa 2FA-ominaisuuksien tarjoamisesta ASF-prosessiin, kuten kuponkien tuottamisesta ja vahvistusten hyväksymisestä. Se voi toimia joko itsenäisessä tilassa, tai monistamalla olemassa olevat todentajan tiedot (jotta voit käyttää nykyistä varmentajaa ja ASF 2FA samaan aikaan).

Voit tarkistaa, käyttääkö bottitiliäsi jo ASF 2FA suorittamalla `2fa` **[komentoja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Ilman ASF 2FA:n perustamista, kaikki standardin `2fa` komennot eivät ole toimintakykyisiä, mikä tarkoittaa, että botti ei ole käytettävissä kehittyneitä ASF ominaisuuksia, jotka edellyttävät moduulin olevan toiminnassa.

---

# Suositukset

On olemassa monia tapoja tehdä ASF 2FA:sta toimintakykyinen, tässä me sisällytämme suosituksemme teidän nykytilanteenne perusteella:

- Jos käytät jo epävirallista kolmannen osapuolen sovellusta, jonka avulla voit poimia 2FA-yksityiskohdat helposti, vain **[tuonti](#import)** ASF:lle.
- Jos käytät virallista sovellusta etkä välitä 2FA tunnuksiesi palauttamisesta, paras tapa on poistaa 2FA käytöstä, sitten **[luo](#creation)** uusia 2FA tunnuksia käyttämällä **[yhteinen todennus](#joint-authenticator)**, jonka avulla voit käyttää virallista sovellusta ja ASF 2FA. Tämä menetelmä **ei vaadi root**, Jailbreaking tai mitään edistynyttä tietoa, tuskin seuraavat ohjeita kirjoitettu, ja on luultavasti parempi tässä skenaariossa.
- Jos käytät virallista sovellusta etkä halua luoda uudelleen 2FA tunnuksiasi, asetuksesi ovat hyvin rajalliset, tyypillisesti tarvitset root ja ylimääräistä fiddling ympäri **[tuonti](#import)** nuo tiedot, ja jopa että se voisi olla mahdotonta.
- Jos et käytä 2FA vielä ja älä välitä, Suosittelemme käyttämään ASF 2FA:a yhdessä **[itsenäisen varmentajan](#standalone-authenticator)** tai **[yhteisvarmentajan](#joint-authenticator)** kanssa (sama kuin edellä).

Alla keskustelemme kaikista mahdollisista vaihtoehdoista ja meille tunnetuista menetelmistä.

---

## Luominen

ASF mukana virallinen `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** , joka jatkaa ASF 2FA, jonka avulla voit linkittää täysin uuden 2FA todentaja. Tämä voi olla hyödyllistä, jos et pysty tai halua käyttää muita työkaluja ja älä välitä ASF 2FA tulossa tärkein (ja ehkä vain) todentaja. Luominen prosessia käytetään myös yhteis-todennusmenetelmällä, luonnollisesti tässä skenaariossa todentaja voi olla rinnakkain kahdessa paikassa kerralla - molemmat tuottavat samat koodit ja molemmat voivat vahvistaa samat vahvistukset.

### Yhteiset toimenpiteet molempia skenaarioita varten

Ei ole väliä, jos aiot käyttää ASF itsenäisenä tai yhteisvarmentaja, sinun täytyy tehdä nämä alustus vaiheet:

1. Luo ASF botti kohdetilille, käynnistä se ja kirjaudu sisään, kuten luultavasti jo teit.
2. Määritä toimiva ja operatiivinen puhelinnumero tilille **[tässä](https://store.steampowered.com/phone/manage)** botin käyttöön Näin voit vastaanottaa tekstiviestikoodin ja sallia tarvittaessa palautuksen. Tämä vaihe ei ole pakollinen kaikissa skenaarioissa, mutta suosittelemme sitä ellet tiedä mitä teet.
3. Varmista, ettet käytä vielä 2FA:ta tilillesi, jos et, poista se käytöstä ensin. Tämä **** laittaa tilisi tilapäiseen kauppaan, ei ole mitään keinoa sen ympärille, Vain **[tuonti](#import)** voi ohittaa sen.
4. Suorita `2fainit [Bot]` komento korvaamalla `[Bot]` bottisi nimellä.

Jos sait menestyksekkään vastauksen, seuraavat kaksi asiaa ovat tapahtuneet:

- Uusi `<Bot>.maFile.PENDING` tiedosto on luotu ASF `config` hakemistossa.
- Steamista lähetettiin tekstiviesti sille puhelinnumerolle, jonka olet määrittänyt yllä olevalle tilille. Jos et ole asettanut puhelinnumeroa, sen sijaan lähetettiin sähköposti tilin sähköpostiosoitteeseen.

Todentajan tiedot eivät ole vielä käytössä, mutta voit tarkistaa luodun tiedoston, jos haluat. Jos haluat olla kaksinkertainen turvallinen, voit esimerkiksi jo kirjoittaa peruutuskoodi. Seuraavat vaiheet riippuvat valitusta skenaariosta.

### Yksilöllinen todentaja

Jos haluat käyttää ASF tärkein (tai jopa vain) todentaja, nyt sinun täytyy tehdä lopullinen viimeistely vaihe:

5. Suorita `2fafinalize [Bot] <ActivationCode>` -komento, korvataan `[Bot]` bottisi nimellä ja `<ActivationCode>` koodilla, jonka olet saanut tekstiviestillä tai sähköpostilla edellisessä vaiheessa.

### Yhteinen todentaja

Jos haluat olla sama todentaja sekä ASF että virallinen Steam-mobiilisovellus, nyt sinun täytyy tehdä seuraavaa, hankalampia vaiheita:

5. **Älä huomioi** tekstiviesti- tai sähköpostikoodia, jonka olet saanut edellisessä vaiheessa.
6. Asenna Steam-mobiilisovellus, jos sitä ei ole vielä asennettu, ja avaa se. Mene Steam Guard -välilehteen ja lisää uusi todentaja noudattamalla sovelluksen ohjeita.
7. Kun todentaja mobiilisovelluksessa on lisätty ja toimi, palaa ASF. Nyt viimeistelyn sijaan meidän tarvitsee vain ilmoittaa ASF:lle, että mobiilisovellus on jo aktivoinut aiemmin luodut yksityiskohdat:
 - Odota, kunnes seuraava 2FA-koodi on esitetty Steam-mobiilisovelluksessa, ja käytä komentoa `2fafinalized [Bot] <2FACodeFromApp>` korvaten `[Bot]` bottisi nimellä ja `<2FACodeFromApp>` tällä hetkellä Steam-mobiilisovelluksessa olevalla koodilla - sama koodi, jota käytät Steamiin kirjautumiseen (**EI** jota olet jo käyttänyt aktivointiin). Jos ASF:n luoma koodi ja antamasi koodi ovat samanarvoiset, ASF olettaa, että todennus on lisätty oikein ja jatkaa tuonti äskettäin luotu todentaja.
 - Suosittelemme vahvasti tekemään edellä olevan varmistaaksemme, että käyttäjätunnuksesi ovat voimassa. Kuitenkin, jos et halua (tai et voi) tarkistaa, jos koodit ovat samat ja tiedät mitä olet tekemässä, voit sen sijaan käyttää komentoa `2fafinalizedforce [Bot]`, korvataan `[Bot]` bottisi nimellä. ASF olettaa, että todentaja on lisätty oikein ja jatkaa uuden todentajan tuontia. Huomaa, että tässä tilassa ASF ei pysty tarkistamaan, vastaavatko koodit, mikä tarkoittaa, että voit mahdollisesti tuoda virheelliset (ei aktivoidut) käyttäjätunnukset.

### Viimeistelyn jälkeen

Jos kaikki toimi kunnolla, aiemmin luotu `<Bot>.maFile.PENDING` tiedosto nimettiin `<Bot>.maFile.NEW`. Tämä osoittaa, että 2FA-käyttäjätunnuksesi ovat nyt voimassa ja aktiivisia. Suosittelemme, että liikutat tiedoston `config` -hakemiston ulkopuolelle ja **tallenna se turvalliseen paikkaan**. Sen lisäksi, että jos olet päättänyt käyttää itsenäinen varmentaja, sitten suosittelemme avaamaan tiedoston valitsemaasi editoriin ja kirjoittamaan alaspäin `revocation_code`, joka sallii sinulle, kuten nimestä ilmenee, peruuttaa todentajan siltä varalta, että menetät sen. Yhteisessä autentikointimenetelmässä sinun olisi pitänyt tehdä se jo Steam-mobiilisovelluksessa, mutta voit tehdä saman siinä tapauksessa, että sinun täytyy tehdä.

Mitä tulee teknisiin yksityiskohtiin, luotu `maFile` sisältää kaikki tiedot, jotka olemme saaneet Steam-palvelimelta tunnistautumisen linkittämisen aikana, ja sen lisäksi, että `device_id` -kenttä, jota saatetaan tarvita muiden (kolmannen osapuolen) todentajien osalta, jos koskaan päätät tuoda `maFile` niihin.

ASF tuo todentajan automaattisesti kun menettely on valmis, ja siksi `2fa` ja muiden siihen liittyvien komentojen pitäisi nyt olla toiminnassa botin tilille, johon linkitsit todentajan. Suosittelemme sinua varmistamaan tämän.

---

## Tuonti

Tuontiprosessi edellyttää jo linkitettyä ja toiminnallista todentajaa, jota ASF tukee. Meillä on ohjeita muutamaan viralliseen ja epäviralliseen 2FA:n lähteeseen, manuaalisen menetelmän päällä, jonka avulla voit itse antaa vaaditut tiedot. Huomioithan, että näitä ohjeita tulisi käyttää **vain** jos käytät jo annettua ratkaisua - koska tässä käsittelyssä on mukana kolmannen osapuolen sovelluksia ja työkaluja, **emme suosittele käyttämään niitä**, ja me mainitsemme sen yksinomaan ihmisille, jotka ovat jo päättäneet käyttää niitä ja haluavat tuoda luodut tiedot ASF 2FA.

Yleensä tuontiprosessiin kuuluu `maFile` pudottaminen sopivassa muodossa ASF:n `config` -hakemistoon, ASF poistaa tämän tiedoston ja poistaa sen automaattisesti turvallisuussyistä.

Kaikki seuraavat oppaat vaativat sinulta, että **toimii ja toimii** varmentajaa käytetään annetulla työkalulla/sovelluksella. ASF 2FA ei toimi oikein, jos tuot virheellisiä tietoja, joten varmista, että todentaja toimii oikein ennen kuin yrität tuoda ne. Tähän kuuluu testaaminen ja todentaminen, että seuraavat autentikointitoiminnot toimivat asianmukaisesti:
- Voit luoda kuponkia ja ne tokenit ovat Steam-verkoston hyväksymiä (voit kirjautua niiden kanssa)
- Voit hakea vahvistuksia, ja ne saapuvat mobiililaitteeseen autentikointi
- Voit reagoida vahvistuksiin, ja Steam-verkko tunnistaa ne oikein vahvistettuina / hylätyinä

Varmista, että todennuslaitteesi toimii tarkistamalla, toimiiko yllä olevat toiminnot - jos ne eivät toimi, ne eivät myöskään toimi ASF:ssä.

### Android puhelin

In general for importing authenticator from your Android phone you will need **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))** access. Alla olevat ohjeet vaativat sinulta melko kunnollista tietoa Android-modausmaailmassa, emme varmasti aio selittää joka askel täällä, vieraile **[XDA](https://xdaforums.com)** ja muut resurssit lisätietoihin/apuun.

**Tästä päivästä lähtien ei ole tiedossa, vahvistettu louhintamenetelmä, joka toimii edelleen. Voit kuitenkin yrittää seurata alla olevia vaiheita esim. vanhentuneella sovellusversiolla, mutta emme takaa, että se toimii oikein. Harkitse sen sijaan nivelentodentajan menetelmää.**

<details>
  <summary>Arkistoinnin ohjeet</summary>

Olettaen, että sinulla on virallinen **[Steam-sovellus](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** toimii ja toimii (alla tarvitaan laitteesi rooting your device):

- Asenna **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** ja ota Zygisk käyttöön asetuksissa.
- Asenna **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** Zygiskille ja varmista, että se toimii.
- Asenna **[SteamGuardDump](https://github.com/YifePlayte/SteamGuardDump/releases/latest)** tai **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** LSPosed moduuli ja ota se käyttöön LSPosed asetuksissa.
- Pakota Steam sovellus, sitten avata se, höyry vartija yksityiskohdat pitäisi nyt olla saatavilla kopioida leikepöydälle.

Nyt kun olet onnistuneesti poistanut vaaditut tiedot, poista moduuli käytöstä estääksesi automaattisen kopioinnin joka kerta kopioi sitten tilin `jaetun` ja `identity_secret` arvo, jonka aiot lisätä ASF 2FA:han, uuteen tekstitiedostoon, jonka rakenne on alapuolella:

```json
{
  "Shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Korvaa jokainen `STRING` arvo sopivalla yksityisellä avaimella poimituista yksityiskohdista. Kun teet sen, nimeä tiedosto uudelleen nimellä `BotName. aFile`, jossa `BotName` on nimi bot olet lisäämällä ASF 2FA, ja laita se ASF:n `config` -hakemistoon, jos et ole vielä.

Käynnistä ASF, jonka pitäisi huomata tiedosto ja tuoda se. Oletetaan, että olet tuonut oikean tiedoston voimassa olevine salaisuuksineen, kaiken pitäisi toimia kunnolla, minkä voit tarkistaa käyttämällä `2fa` komentoja. Jos olet tehnyt virheen, voit aina poistaa `Bot.db` ja aloittaa alusta tarvittaessa.

</details>

### SteamDesktopAuthenticator

Jos sinulla on jo todennustoiminto käynnissä SDA:ssa, sinun pitäisi huomata, että `steamID.maFile` tiedosto on saatavilla `maFiles` -kansiossa. Varmista, että `maFile` on salaamattomassa muodossa, koska ASF ei voi purkaa SDA-tiedostoja - salaamattoman tiedoston sisällön pitäisi alkaa `{` ja päättyä `}` -merkillä. Tarvittaessa voit ensin poistaa SDA- asetuksista salauksen ja ottaa sen käyttöön uudelleen, kun olet valmis. Kun tiedosto on salaamattomassa muodossa, kopioi se ASF:n `config` -hakemistoon.

Voit nyt uudelleennimetä `steamID.maFile` `BotName. aFile` ASF config-hakemistossa, jossa `BotName` on botin nimi, johon lisäät ASF 2FA. Vaihtoehtoisesti voit jättää sen sellaisenaan, ASF valitsee sen automaattisesti sisäänkirjautumisen jälkeen. Tiedoston uudelleennimeäminen auttaa ASF:ää mahdollistamalla ASF 2FA:n käytön ennen sisäänkirjautumista, jos et tee sitä, sitten tiedosto voidaan valita vasta, kun ASF onnistuneesti kirjautuu sisään (kuten ASF ei tiedä `steamID` tilisi ennen kirjautumista sisään).

Käynnistä ASF, jonka pitäisi huomata tiedosto ja tuoda se. Oletetaan, että olet tuonut oikean tiedoston voimassa olevine salaisuuksineen, kaiken pitäisi toimia kunnolla, minkä voit tarkistaa käyttämällä `2fa` komentoja. Jos olet tehnyt virheen, voit aina poistaa `Bot.db` ja aloittaa alusta tarvittaessa.

### WinAuth

Luo ensin uusi tyhjä `BotName. aFile` ASF config-hakemistossa, jossa `BotName` on botin nimi, johon lisäät ASF 2FA. Jos annat väärän nimen, ASF ei valitse sitä.

Käynnistetään nyt WinAuth kuten tavallisesti. Klikkaa hiiren oikealla painikkeella Steam-kuvaketta ja valitse "Show SteamGuard and Recovery Code". Tarkista sitten "Salli kopio". Sinun pitäisi huomata JSON rakenne sinulle tuttu ikkunan alareunassa, alkaen `{`. Kopioi koko teksti `BotName.maFile` tiedostoon, jonka olet luonut edellisessä vaiheessa.

Käynnistä ASF, jonka pitäisi huomata tiedosto ja tuoda se. Oletetaan, että olet tuonut oikean tiedoston voimassa olevine salaisuuksineen, kaiken pitäisi toimia kunnolla, minkä voit tarkistaa käyttämällä `2fa` komentoja. Jos olet tehnyt virheen, voit aina poistaa `Bot.db` ja aloittaa alusta tarvittaessa.

### Manuaalinen

Jos olet edistynyt käyttäjä, voit myös luoda maFile manuaalisesti. Tätä voidaan käyttää, jos haluat tuoda todennuksen muista lähteistä kuin ne, jotka olemme edellä kuvattu. Sillä pitäisi olla **[voimassa oleva JSON rakenne](https://jsonlint.com)**

```json
{
  "Shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Standardissa tunnistautumistiedoissa on enemmän kenttiä - ASF jättää ne kokonaan huomiotta tuonnin aikana, koska niitä ei tarvita. Sinun ei tarvitse poistaa niitä - ASF tarvitsee vain kelvollisen JSON-toiminnon, jossa on kaksi edellä kuvattua pakollista kenttää, ja se ohittaa lisäkentät (jos sellaisia on). Tietenkin sinun täytyy korvata `STRING` -paikanmerkki yllä olevassa esimerkissä kelvollisilla arvoilla tilillesi. Jokaisen `STRING` tulisi olla base64-enkoodattu tavujen edustus, ja sen tulisi olla yksityinen avain.

---

## UKK

### Miten ASF käyttää 2FA-moduulia?

Jos ASF 2FA on käytettävissä, ASF käyttää sitä automaattiseen vahvistukseen kaupasta, jonka ASF lähettää/hyväksyy. Se pystyy myös automaattisesti tuottamaan 2FA kuponkia tarpeen mukaan, esimerkiksi jotta kirjautua sisään. Sen lisäksi, että ASF 2FA ottaa käyttöön myös `2fa` komennot sinua varten.

### Miten voin saada 2FA-tunnuksen?

Tarvitset 2FA tunnuksen käyttääksesi 2FA-suojattua tiliä, joka sisältää jokaisen ASF 2FA -tilin myös. Jos olet päättänyt käyttää itsenäistä autentikointia, sinun pitäisi käyttää `2fa <BotNames>` -komentoa luodaksesi tilapäisen tunnuksen tietyille bottiinstansseille. Kaikissa muissa skenaarioissa suosittelemme käyttämään alkuperäistä varmentajaa, jota olet käyttänyt, vaikka voit käyttää komentoa myös, jos se on helpompaa sinulle.

### Voinko käyttää alkuperäistä varmentajaa, kun se on tuotu ASF 2FA:ksi?

Kyllä, alkuperäinen varmentaja pysyy toiminnallisena ja voit käyttää sitä yhdessä ASF 2FA:n kanssa. Muistakaa kuitenkin, että jos mitätöit sen millä tahansa menetelmällä, linkitetyt ASF 2FA -tunnukset eivät myöskään ole enää voimassa.

### Kuinka poistaa ASF 2FA?

Yksinkertaisesti pysäytä ASF ja poista siihen liittyvä ASF 2FA:n `BotName.db` linkitetyllä ASF 2FA:lla. Tämä valinta poistaa liitetyn 2FA:n ASF:llä, mutta ei mitätöi (poista linkkiä) todentajaasi. Jos sen sijaan haluat mitätöidä todentajan sen lisäksi että poistat sen ASF (ensin), sinun pitäisi poistaa se valitsemallasi alkuperäisellä todentajalla. Jos et voi tehdä sitä jostain syystä, esimerkiksi koska käytät ASF 2FA:ta itsenäisessä tilassa, käytä sitten peruutuskoodia, jonka olet saanut asennuksen aikana, Steam-sivustolla. Todentajan mitätöinti ASF: n kautta ei ole mahdollista.

### Linkitin todennuksen kolmannen osapuolen sovelluksessa, sitten tuotu ASF. Voinko nyt yhdistää sen uudelleen puhelimeeni?

**No**. Näin mitätöidä aiemmin tuodut käyttäjätunnukset ja ASF 2FA lopettaa toimintansa (tuottamalla koodeja ei enää hyväksytä Steam). Ensiksi päättää, missä haluat alkuperäistä tai kolmannen osapuolen todentajaa paikannetaan, ja sitten tuo se ASF 2FA:ksi.

### Käytän yhteistä todentajaa, voinko siirtää sovellukseni toiseen puhelimeen?

**No**. Mitä höyryä todetaan "liikkuva" tai "siirtää" todentaja, on todella yhtä mitätöimistä vanha yksi ja määrittämällä uusia, yhdessä vaiheessa. Näin voit ohittaa esim. jonkin verran liiallista jäähtymistä verrattuna näihin kahteen vaiheeseen itsenäisesti, mutta ASF:n osalta tämä itse asiassa mitätöi aiemmin ASF:ssä luetut, jolloin koko ASF 2FA -moduuli ei ole toiminnassa.

Suositeltu tapa on poistaa autentikointi kokonaan vanhassa puhelimessa ja käyttää yhteistä autentikointimenetelmää uudelleen uudessa puhelimessa. Jos olet jo siirtänyt todennuksesi, vanhat ASF 2FA -tunnukset on jo mitätöity, joten ainoa jäljellä nyt on poistaa "siirretty" todentaja, ja linkittää uuden yhden käyttäen yhteinen todentaja menetelmä uudelleen.

### Käyttääkö ASF 2FA:ta paremmin kuin kolmannen osapuolen todentaja asetettu hyväksymään kaikki vahvistukset?

**Kyllä**, monin tavoin. First and most important one - using ASF 2FA **significantly** increases your security, as ASF 2FA module ensures that ASF will only accept automatically its own confirmations, so even if attacker does request a trade that is harmful, ASF 2FA will **not** accept such trade, as it was not generated by ASF. Turvallisuusosan lisäksi ASF 2FA:n käyttö tuo myös suorituskyky- ja optimointietuja, kuten ASF 2FA hakee ja hyväksyy vahvistukset heti niiden syntymisen jälkeen, ja vasta sitten, toisin kuin tehoton äänestysten vahvistukset kukin X minuuttia, joka on saavutettu muilla ratkaisuilla. Ei ole mitään syytä käyttää kolmannen osapuolen todentajaa ASF 2FA:n päällä, jos aiot automatisoida ASF:n luomia vahvistuksia - sitä varten ASF 2FA on juuri ja sen käyttö ei ole ristiriidassa sinun kanssasi vahvistaen kaiken muun valintasi varmentajana. Suosittelemme lämpimästi ASF 2FA:n käyttöä koko ASF toimintaan.