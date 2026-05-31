# UKK

UKK-sivumme sisältää tavallisimpia kysymyksiä ja vastauksia. Vähemmän yleisiä asioita varten lue sen sijaan lisää **[laajennetusta UKK:sta](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ)**.

# Sisällysluettelo

* [Yleiset](#general)
* [Vertailu samanlaisten työkalujen kanssa](#comparison-with-similar-tools)
* [Turvallisuus / Yksityisyys / VAC / Bannit / Käyttöehdot](#security--privacy--vac--bans--tos)
* [Sekalaiset](#misc)
* [Ongelmat](#issues)

---

## Yleinen

### Mikä on ASF?
### Miksi ohjelma väittää, ettei minun tililläni ole mitään tilaa?
### Miksi ASF ei havaitse kaikkia pelejäni?
### Miksi tiliäni on rajoitettu?

Ennen kuin yrität ymmärtää mikä ASF on, sinun tulee varmistaa, että ymmärrät mitä Steamin kortit ovat ja miten niitä hankitaan, josta kerrotaan hienosti virallisessa UKK:ssa **[täällä](https://steamcommunity.com/tradingcards/faq)**.

Lyhyesti sanottuna, Steamin kortit ovat kerättäviä esineitä, joita voit saada tietyn pelin omistaessasi. Niitä voidaan käyttää merkkien luomiseen, myymiseen Steamin kauppapaikalla, tai mihin tahansa muuhun valitsemaasi tarkoitukseen.

Ydinkohdat on mainittu jälleen täällä, koska ihmiset yleensä eivät halua olla samaa mieltä heidän kanssaan ja mieluummin teeskennellä, että niitä ei ole olemassa:

- **Jos haluat saada pelin kortteja, sinun tulee omistaa se Steam-tililläsi. Perheiden jakaminen ei ole omistusoikeutta eikä sitä lasketa.**
- **Peliäsi ei voida merkitä [yksityiseksi](https://help.steampowered.com/faqs/view/1150-C06F-4D62-4966), ASF ohittaa tällaiset pelit automaattisesti maanviljelyn aikana.**
- **Ei voi farmata peliä loputtomasti, jokaisella pelillä on vain tietty määrä korttien pudotuksia. Kun pudotat kaikki (noin puolet koko sarjasta), peli ei ole enää ehdokas maatalouteen. Ei ole väliä onko olet myynyt, myynyt, nikkaroinut tai unohtanut, mitä sait korteillesi, kun loput kortin putoaa, peli on valmis.**
- **Ilmaispelit eivät pudota kortteja, ellet ensin käytä niihin rahaa. Tämä tarkoittaa pysyvästi F2P pelejä, kuten Team Fortress 2 tai Dota 2. F2P-pelien omistaminen ei anna sinulle korttisi pudotusta.**
- **Et voi pudottaa kortteja [rajatuille tileille](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)riippumatta omistamista peleistä ja niiden aktivointitavasta.**
- **Maksullisia pelejä, jotka olet saanut ilmaiseksi myynninedistämisen aikana, ei voi viljellä kortin pudotuksia, riippumatta siitä, mitä näkyy kaupan sivulla.**

Joten kuten huomaat, Steamin kortteja myönnetään sinulle, kun pelaat ostamaasi peliä, tai ilmaispeliä, johon olet käyttänyt rahaa. Jos pelaat tällaista peliä tarpeeksi kauan, kaikki kyseisen pelin kortit putoavat lopulta tavaraluetteloosi, jolloin voit luoda merkin (saatuasi loputkin koko setistä), myydä ne tai tehdä mitä tahansa muuta.

Nyt kun olemme selittäneet Steamin perusteet, voimme selittää ASF:n. Ohjelma itsessään on melko monimutkainen ymmärtää täysin, joten syvällisen teknisen läpikäynnin sijasta, tarjoamme yksinkertaisen selityksen alapuolella.

ASF kirjautuu Steam-tilillesi meidän sisäänrakentamamme, mukautetun Steam-asiakassovelluksen kautta, antamiasi kirjautumistietoja käyttämällä. After successfully logging in, it parses your **[badges](https://steamcommunity.com/my/badges)** in order to find games that are available for farming (`X` card drops remaining). Kun kaikki sivut on jäsennetty ja lopullinen sopivien pelin lista on luotu, ASF valitsee tehokkaimman farmausalgoritmin ja aloittaa prosessin. Prosessi riippuu valitusta **[korteista maatalouden algoritmi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** mutta yleensä se koostuu pelaa tukikelpoista peliä ja säännöllisesti (plus jokainen kohde pudota) tarkistaa, onko peli täysin viljellyt jo - jos kyllä, ASF voi jatkaa seuraavan otsikon käyttäen samaa menettelyä, kunnes kaikki pelit ovat täysin viljeltyjä.

Muista, että yllä oleva selitys on yksinkertaistettu, eikä se kuvaa tusinaa muuta ASF:n tarjoamaa lisäominaisuutta ja toimintoa. Käy muualla **[meidän wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki)** jos haluat tietää kaikki ASF yksityiskohdat. Yritin tehdä siitä tarpeeksi yksinkertaisen ymmärtää kaikille, tuodmatta teknisiä yksityiskohtia - kehittyneitä käyttäjiä kannustetaan kaivaa syvemmälle.

Nyt ohjelma - ASF tarjoaa taikuutta. Ensinnäkin, sen ei tarvitse ladata mitään pelin tiedostoja, se voi pelata pelejä heti. Toiseksi, se on täysin riippumaton normaalista Steam-asiakkaastasi - sinun ei tarvitse käyttää Steam-asiakasohjelmaa tai edes asentaa sitä ollenkaan. Kolmanneksi se on automatisoitu ratkaisu - mikä tarkoittaa, että ASF tekee automaattisesti kaiken selkäsi takana, ilman tarvetta kertoa mitä tehdä - mikä säästää vaivaa ja aikaa. Lopuksi, sen ei tarvitse huijata Steam-verkkoa prosessoimalla emulointia (mm. Idle Master käyttää), koska se voi kommunikoida sen kanssa suoraan. Se on myös erittäin nopea ja kevyt, on hämmästyttävä ratkaisu kaikille, jotka haluavat saada kortteja helposti ilman paljon vaivaa - se tulee erityisen hyödyllistä jättämällä se käynnissä taustalla tehdessään jotain muuta, tai jopa pelaa offline-tilassa.

Kaikki edellä on mukavaa, mutta ASF:llä on myös joitakin teknisiä rajoituksia, joita Steam valvoo - emme voi maatilan pelejä, joita et omista, emme voi maatilan pelejä ikuisesti saada ylimääräisiä pudotuksia ohi pakotettu raja, emmekä voi maatilan pelejä pelattaessa. Kaiken tämän pitäisi olla "looginen", kun otetaan huomioon, miten ASF toimii, mutta on mukava huomata, että ASF ei ole supervaltaa ja ei tee jotain, joka on fyysisesti mahdotonta, niin pitää tämä mielessä - se on pohjimmiltaan sama kuin jos olet käskenyt jonkun kirjautua tilillesi toisen PC ja maatilan näitä pelejä sinulle.

Joten summa - ASF on ohjelma, joka auttaa pudottaa ne kortit olet oikeutettu, ilman paljon vaivaa. Se tarjoaa myös useita muita toimintoja, mutta pidetään kiinni tämän toistaiseksi.

---

### Pitääkö minun antaa steam kirjautumistietoni?

**Kyllä.** ASF tarvitsee tilisi tunnukset samalla tavalla kuin virallinen Steam-asiakas, koska se käyttää samaa menetelmää Steam-verkon vuorovaikutuksessa. Tämä ei kuitenkaan tarkoita, että sinun täytyy laittaa käyttäjätunnukset ASF configs, voit jatkaa ASF:n käyttöä tyhjänä `SteamLogin` ja/tai `SteamPassword`, ja syötä nämä tiedot jokaisesta ASF toimii, kun vaaditaan (sekä useita muita kirjautumistunnuksia, katso konfiguraatio). Näin tietojasi ei tallenneta missään, mutta ASF ei tietenkään voi käynnistää automaattisesti ilman apuasi. ASF tarjoaa myös useita muita tapoja lisätä **[turvallisuus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**, niin voit vapaasti lukea, että osa wiki jos olet edistynyt käyttäjä. Jos et ole, etkä halua laittaa tilisi tunnuksia ASF configs, sitten yksinkertaisesti älä tee sitä, ja sen sijaan syötä ne tarvittaessa, kun ASF pyytää niitä.

Pidä mielessä, että ASF työkalu on henkilökohtaiseen käyttöön ja käyttäjätunnuksesi eivät koskaan jätä tietokonetta. Et myöskään jaa niitä kenenkään kanssa, joka täyttää **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** - erittäin tärkeä asia, josta monet unohtavat. Et lähetä tietojasi palvelimillemme tai kolmannelle osapuolellemme, vain suoraan Valven ylläpitämille Steam-palvelimille. Emme tunne käyttäjätietojasi emmekä myöskään pysty palauttamaan niitä sinulle, riippumatta siitä, laitatko ne konfifeihin vai ei.

---

### Kuinka kauan pitää odottaa että kortteja alkaa tippumaan?

**Niin kauan kuin se ottaa** - vakavasti. Jokainen peli on erilainen maatalouden vaikeus asettaa kehittäjä / julkaisija, ja se on täysin heille kuinka nopeita kortteja pudotetaan. Suurin osa peleistä seuraa 1 pudotusta 30 minuutin pelissä, mutta on myös pelejä vaativat voit pelata jopa useita tunteja ennen pudottamalla kortti. Sen lisäksi, että tilisi voitaisiin rajoittaa vastaanottamasta korttisi tippoja peleistä, joita et ole vielä pelannut, kuten on ilmoitettu **[suorituskyky](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** -osassa. Älä yritä arvata, kuinka kauan ASF pitäisi maatilan annettu otsikko - se ei ole sinun, eikä ASF päättää. Ei ole mitään, mitä voit tehdä nopeuttaaksesi, ja ei ole "bug" liittyvät kortit ei pudota ajoissa - et ohjaa kortteja pudottamalla prosessi, ei ASF. Parhaassa tapauksessa saat keskimäärin 1 tippa 30 minuutissa. Pahimmassa tapauksessa et saa mitään korttia edes 4 tuntia ASF:n aloittamisen jälkeen. Molemmat näistä tilanteista ovat normaaleja ja ne kuuluvat **[-suoritukseemme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** -osiossa.

---

### Maanviljely kestää liian kauan, voinko jotenkin nopeuttaa sitä?

Ainoa asia, joka vaikuttaa voimakkaasti maanviljelyn nopeuteen, on valittu **[korttien maanviljelyn algoritmi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** botti instanssi. Kaikilla muilla toimilla on vain vähäinen vaikutus, eivätkä ne nopeuta maanviljelyä, vaikka jotkut toimet, kuten käynnistäminen ASF prosessi useita kertoja, jopa **pahentaa**. Jos teillä on todella halu tehdä joka ikinen sekunti maatalousprosessista, ASF sallii hienosäätää joitakin maatalouden keskeisiä muuttujia, kuten `FarmingDelay` - kaikki ne selitetään **[kokoonpanossa](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Kuten sanoin, vaikutus on kuitenkin vähäinen. ja oikean korttien maanviljelyn algoritmi tietylle tilille on yksi ja ainoa ratkaiseva valinta, joka voi vaikuttaa voimakkaasti maanviljelyn nopeuteen, kaikki muu on puhdasta kosmetiikkaa. Sen sijaan, että olisimme huolestuneita maanviljelyn nopeudesta, juuri käynnistää ASF ja anna sen tehdä työnsä - Voin vakuuttaa teille, että se tekee sen tehokkain tapa voisi keksiä. Mitä vähemmän välität, sitä enemmän olet tyytyväinen.

---

### Mutta ASF sanoi, että maanviljely kestää noin X aikaa!

ASF antaa sinulle karkea lähentämisestä perustuu määrä kortteja sinun täytyy pudottaa, ja valitsemasi algoritmi - tämä ei ole missään lähellä todellista aikaa, että vietät maanviljelyyn, joka on yleensä pidempi kuin tämä, koska ASF olettaa vain parhaan tapauksen ja jättää kaikki Steam Network quirks, internetyhteyden katkaisu, Steam-palvelimien ylikuormitus ja samoin. Sitä olisi pidettävä vain yleisenä indikaattorina, kuinka kauan voidaan odottaa ASF:n olevan viljelyssä, hyvin usein parhaassa tapauksessa, koska todellinen aika vaihtelee, jopa merkittävästi joissakin tapauksissa. Kuten edellä mainittiin, älä yritä arvata, kuinka kauan annettu peli viljellään, se ei ole sinun, eikä ASF päättää.

---

### Voiko ASF työskennellä Android / älypuhelimeni?

ASF on C# ohjelma, joka vaatii työskentelyä .NET. Androidista tuli kelvollinen alusta alkaen .NET 6:sta. , kuitenkin, on tällä hetkellä suuri esto tehdä ASF tapahtua Android johtuu **[puute ASP. ET runtime available on it](https://github.com/dotnet/aspnetcore/issues/35077)**. Vaikka tarjolla ei ole natiivi vaihtoehto, on olemassa asianmukainen ja toimiva rakentaa GNU/Linuxille ARM-arkkitehtuuri, joten on täysin mahdollista käyttää jotain **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** asentamiseen Linux, sitten käyttää ASF kuten Linux chroot tavallisesti.

Milloin, jos kaikki ASF vaatimukset täyttyvät, harkitsemme virallisen Android-version julkaisemista.

---

### Voiko ASF tilata Steam-peleistä, kuten CS:GO tai Unturny?

**No**, Tämä on vastoin **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** ja Valve totesi selvästi, että viimeisen aallon aikana yhteisön kieltää viljelyn TF2-kohteita. ASF on Steam-korttien maatalousohjelma, ei pelien kohteita maanviljelijä - sillä ei ole mitään valmiuksia maatalouden peli kohteita, eikä tällaista ominaisuutta ole tarkoitus lisätä tulevaisuudessa, koskaan, lähinnä koska rikkoo Steamin käyttöehtoja. Älä kysy tästä - paras voit saada on raportti joiltakin suolainen käyttäjä ja sinulla on ongelmia. Sama pätee kaikkeen muuhun maatalouteen, kuten maatalouden vähenemiseen CS:GO -lähetyksissä. ASF keskittyy Steam kaupankäynnin kortteja yksinomaan.

---

### Voinko valita, mitkä pelit pitäisi viljellä?

**Kyllä**, kautta useita eri tapoja. Jos haluat muuttaa maatalouden jonon oletusjärjestystä, sitten se mihin `FarmingOrders` **[botti konfigurointiominaisuutta](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** voidaan käyttää. Jos haluat manuaalisesti mustalle listalle, että pelejä viljellään automaattisesti, voit käyttää idle blacklist joka on saatavilla `fb` **[komento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Jos haluat tilata kaiken, mutta antaa joitakin sovelluksia etusijalla kaikkeen muuhun, että mitä idle prioriteettijono saatavilla `fq` **[komennolla](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** voidaan käyttää. Ja lopuksi, jos haluat maatilan erityisiä pelejä vain, sitten voit ilmoittaa `FarmPriorityQueueOnly` botissa **[`FarmingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)** tämän tavoitteen saavuttamiseksi, yhdessä valittujen sovellusten lisäämisen kanssa idle prioriteettijono.

Sen lisäksi, että hallinnoi automaattisia kortteja maatalouden moduuli, joka on kuvattu edellä, Voit myös vaihtaa ASF manuaaliseen maataloustilaan `toistamalla` **[komennon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, tai käytä muita sekalaisia ulkoisia asetuksia, kuten `GamesPlayedWhileIdle` **[botti asetukset](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

---

### En ole kiinnostunut korttipudotuksista, haluaisin maatilan tunteja pelataan sen sijaan, onko se mahdollista?

Kyllä, ASF sallii sinun tehdä sen läpi ainakin useilla tavoilla.

Paras tapa saavuttaa tämä on käyttää **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** asetusominaisuutta, joka soittaa valitsemasi sovellustunnukset, kun ASF ei ole kortteja tilalle. Jos haluat pelata pelejä koko ajan, vaikka sinulla on kortti putoaa muista peleistä, sitten voit yhdistää sen **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, niin ASF tilalla vain ne pelit kortti putoaa, että olet nimenomaisesti asettaa, tai vaihtoehtoisesti, **[`FarmingPausedByDefault`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**mikä aiheuttaa korttien maanviljely moduuli pysäytetään, kunnes et pysäytä sitä itse.

Voit myös käyttää **[`pelata`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#commands-1)** komentoa, mikä aiheuttaa sen, että ASF pelaa valitut pelit. Pidä kuitenkin mielessä, että `pelata` pitäisi käyttää vain peleissä, jotka haluat pelata väliaikaisesti, koska se ei ole pysyvä tila, jolloin ASF palaa oletustilaan e. . kun yhteys Steam-verkkoon on katkaistu. Siksi suosittelemme käyttämään `GamesPlayedWhileIdle`, ellet todellakaan halua aloittaa valitut pelit vain lyhyen ajan, ja sitten palata yleiseen virtaukseen.

---

### Olen Linux / macOS käyttäjä, onko ASF maatilan pelejä, jotka eivät ole käytettävissä minun OS? Aikooko ASF maatilan 64-bittiset pelit, kun käyn sitä 32-bittisellä käyttöjärjestelmällä?

Kyllä, ASF ei edes vaivaa lataamalla varsinaisia pelitiedostoja, joten se toimii kaikkien sinun Steam-tiliisi sidottujen lisenssiesi kanssa riippumatta mistä tahansa alustasta tai teknisistä vaatimuksista. Sen pitäisi myös toimia pelejä sidottu tietylle alueelle (region-lukittuja pelejä) vaikka et ole vastaava alue, vaikka emme takaa, että (se toimi viime kerralla yritettynä).

---

## Vertailu samanlaisten työkalujen kanssa

---

### Onko ASF samanlainen kuin Idle Master?

Ainoa samankaltaisuus on molempien ohjelmien yleinen tarkoitus, joka on Steam-pelien viljely kortinpudotusten vastaanottamiseksi. Kaikki muu, mukaan lukien varsinainen viljelymenetelmä, ohjelman rakenne, toiminnallisuus, yhteensopivuus, käytetyt algoritmit, erityisesti itse lähdekoodi, on täysin erilainen ja nämä kaksi ohjelmaa eivät ole mitään yhteistä keskenään, jopa ydinperusta - IM on käynnissä . ET Framework, ASF on .NET (Core). ASF luotiin ratkaisemaan infrastruktuurin ongelmia, joita ei voitu ratkaista yksinkertaisella koodin muokkauksella - siksi ASF kirjoitettiin tyhjästä, käyttämättä yhtä koodia tai edes yleistä ajatusta IM:stä, koska koodi ja nuo ajatukset olivat aluksi täysin puutteellisia. IM ja ASF ovat kuten Windows ja Linux - molemmat ovat käyttöjärjestelmiä ja molemmat voidaan asentaa tietokoneeseen. mutta ne jakavat lähes mitään toistensa kanssa lukuun ottamatta palvelemaan samanlaista tarkoitusta.

Tämä on myös siksi sinun ei pitäisi verrata ASF IM odotuksia. Sinun pitäisi kohdella ASF ja IM täysin itsenäisiä ohjelmia omalla yksinomainen joukko ominaisuuksia. Jotkut niistä todellakin päällekkäin ja voit löytää tietyn ominaisuuden molemmissa niissä, mutta hyvin harvoin, koska ASF palvelee tarkoituksensa täysin erilainen lähestymistapa verrattuna IM.

---

### Onko sen arvoista käyttää ASF, jos käytän tällä hetkellä Idle Master ja se toimii hyvin minulle?

**Kyllä.** ASF on paljon luotettavampi ja sisältää monia sisäänrakennettuja toimintoja, jotka ovat **ratkaiseva** riippumatta siitä, miten maatilan, että IM yksinkertaisesti ei tarjoa.

ASF on asianmukainen logiikka **julkaisemattomia pelejä** - IM yrittää maatilan pelejä, jotka ovat kortteja jo lisätty, vaikka niitä ei vielä julkaistu. Tietenkin, se ei ole mahdollista maatilan näitä pelejä ennen julkaisupäivää, joten maatalouden prosessi on jumissa. Tämä edellyttää sinun joko lisätä sen mustalle listalle, odottaa julkaisua, tai ohittaa manuaalisesti. Kumpikaan näistä ratkaisuista ei ole hyvä, ja ne kaikki vaativat huomiota - ASF automaattisesti ohittaa maatalouden julkaisemattomia pelejä (tilapäisesti), ja palaa takaisin niihin myöhemmin, kun ne ovat, täysin välttää ongelma ja käsitellä sitä tehokkaasti.

ASF on myös asianmukainen logiikka **sarjan** videot. Steamissä on monia videoita, joissa on kortteja, mutta niistä ilmoitetaan väärä `appID` merkeissä, kuten **[Double Fine Adventure](https://store.steampowered.com/app/402590)** - IM virheellisesti maatila väärin `appID`, joka tuottaa mitään pudotuksia ja prosessi on jumissa. Jälleen kerran, sinun täytyy joko mustalla listalla tai ohittaa manuaalisesti, molemmat vaativat huomiota. ASF havaitsee automaattisesti viljelyalan asianmukaisen `appID` -sovelluksen, joka johtaa kortin katoamiseen.

Sen lisäksi ASF on **paljon vakaampi ja luotettavampi** verkko-ongelmien ja Steam-ovien osalta - se toimii suurimman osan ajasta eikä vaadi huomiotasi kerralla Vaikka IM usein taukoja monille ihmisille, vaatii ylimääräisiä korjauksia tai yksinkertaisesti ei toimi siitä riippumatta. Se on myös täysin riippuvainen Steam-asiakkaastasi, mikä tarkoittaa, että se ei voi toimia, kun Steam-asiakkaasi kokevat vakavia ongelmia. ASF toimii kunnolla niin kauan kuin se voi muodostaa yhteyden Steam-verkkoon, eikä vaadi Steam-ohjelman käyttöä tai asennusta.

Nämä ovat 3 **erittäin tärkeä** pistettä, miksi kannattaa harkita ASF:n käyttöä, koska ne vaikuttavat suoraan kaikkiin maatalouden Steam-kortteja, eikä ole mitään keinoa sanoa, "tämä ei pidä minua", Koska Steam-huoltoa ja ovelia tapahtuu kaikille. On tusinaa ylimääräistä vähemmän ja enemmän tärkeitä syitä, joista voit oppia muualla FAQ. Niin pian puhuen, **kyllä**, sinun pitäisi käyttää ASF vaikka et tarvitse mitään ylimääräistä ASF ominaisuus, joka on saatavilla verrattuna IM.

Sen lisäksi IM on virallisesti lopetettu ja voi murtautua kokonaan tulevaisuudessa, ilman kukaan vaivaa korjata sitä, ottaen huomioon paljon tehokkaampia ratkaisuja (ei vain ASF). IM ei jo toimi paljon ihmisiä, ja se numero on vain menossa ylös, ei alas. Sinun pitäisi välttää käyttämästä vanhentunut ohjelmisto ensinnäkin, ei vain IM mutta kaikki muut vanhentuneet ohjelmat samoin. Yksikään aktiivinen ylläpitäjä ei välitä siitä, toimiiko se vai ei, ja **kukaan ei ole vastuussa sen toiminnallisuudesta**, joka on turvallisuuden kannalta ratkaisevan tärkeä. Riittää, että siellä on kriittinen vika, joka aiheuttaa todellisia ongelmia Steam-infrastruktuuriin - kukaan ei korjaa sitä, Steam voi antaa toisen bändiaallon, jossa saat osuma ilman edes tietoinen tästä on kysymys, kuten on jo tapahtunut ihmisille, arvata mitä, vanhentunut versio ASF.

---

### Mitä mielenkiintoisia ominaisuuksia ASF tarjoaa, että Idle Master ei?

Se riippuu mitä pidät "mielenkiintoinen" sinulle. Jos aiot maatilalla useampia tilejä kuin yksi, vastaus on jo ilmeinen, koska ASF voit maatilata ne kaikki yhdellä ylivoimainen ratkaisu, säästää resursseja, vaivaa, ja yhteensopivuus kysymyksiä. Jos kuitenkin pyydät tätä kysymystä, todennäköisimmin sinulla ei ole tätä tarvetta, Arvioidaan muita etuja, joita sovelletaan yhteen ASF:ssä käytettyyn tiliin.

Ennen kaikkea sinulla on joitakin sisäänrakennettuja ominaisuuksia, jotka on mainittu **[](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** yläpuolella ja jotka ovat maatalouden ytimessä päämäärästäsi riippumatta, ja hyvin usein, että yksin on jo tarpeeksi harkita ASF. Mutta tiedät jo, niin siirrytään joitakin mielenkiintoisia ominaisuuksia:

- **Voit tilata offline** (`OnlineStatus` `Offline` -asetuksessa). Maanviljely offline-tilassa mahdollistaa sen, että voit ohittaa pelin Steam-tilan kokonaan, jonka avulla voit tilata ASF ja näyttää "Online" Steamissä samaan aikaan, ilman ystäväsi edes huomaa, että ASF pelaa peliä puolestasi. Tämä on ylivoimainen ominaisuus, koska sen avulla voit pysyä verkossa Steam-asiakas, mutta ei ärsyttää ystäviäsi jatkuvilla muutoksilla, tai harhaan heitä ajatella, että pelaat peliä kun todellisuudessa et ole. Tämä kohta yksin tekee kannattavan käyttää ASF jos kunnioitat omia ystäviäsi, mutta se on vasta alkua. On myös mukava huomata, että tällä ominaisuudella ei ole mitään tekemistä Steamin yksityisyysasetusten kanssa - jos käynnistät pelin itse, sitten voit kunnolla näyttää pelissä ystävillesi tehden vain ASF osa näkymätön ja ei vaikuta tiliisi lainkaan.

- **Voit ohittaa hyvittävät pelit** (`SkipRefundableGames` botissa `FarmingPreferences` ominaisuus). ASF on asianmukaisesti sisäänrakennettu logiikka palautettavia pelejä ja voit määrittää ASF ei maatilan palautettavia pelejä automaattisesti. Tämän avulla voit arvioida itseäsi, jos vastikään ostettu peli Steam-kaupasta oli rahojen arvoinen, ilman ASF yrittää pudottaa kortteja siitä mahdollisimman pian. Jos pelaat sitä 2+ tuntia, tai 2 viikkoa kuluu ostoksen, sitten ASF jatkaa tätä peliä, koska se ei ole enää palautettavissa. Siihen asti sinulla on täysi valta nauttia siitä tai ei, ja voit helposti palauttaa sen tarvittaessa. ei tarvitse manuaalisesti mustalla listalla, että peli tai ei käytä ASF koko ajan.

- **Voit ohittaa pelaamattomat** (`SkipUnplayedGames` botissa `FarmingPreferences` ominaisuus). ASF on rakennettu logiikka tuntikausia pelejä ja voit määrittää ASF ei maatilan pelaamattomia pelejä automaattisesti. Näin voit hallita itse pelejä pelaat ja maatila, ilman manuaalisesti mustalle listalle kaikki tai ohita ASF kokonaan.

- **Voit automaattisesti merkitä uudet kohteet vastaanotetuiksi** (`BotBehaviour` `DismissInventoryNotifications` -ominaisuudeksi). Tilin viljely ASF:llä johtaa siihen, että tilisi saa uusia kortteja. Tiedätte jo, että näin tapahtuu, joten antakaa ASF selväksi, että hyödytön ilmoitus sinulle, sen varmistaminen, että vain tärkeät asiat herättävät huomionne. Tietenkin, vain jos haluat.

- **Voit muokata haluamasi viljelytilausta enemmän käytettävissä olevilla vaihtoehdoilla** (`FarmingOrders` ominaisuus). Ehkä haluat tilata äskettäin ostetut pelit ensin? Tai vanhimmat? Mukaan määrä kortin pudotuksia? Merkin tasot olet jo nikkaroinut? Pelattuja tunteja? Aakkosuus? Mukaan AppID? Tai ehkä täysin satunnainen? Se on täysin sinun päätettäväksi.

- **ASF voi auttaa sinua suorittamaan sarjasi** (`TradingPreferences` `SteamTradeMatcher` -ominaisuudella). Jossa hieman edistyksellisempi sävytys, voit muuntaa ASF täysin varustellun user-botin, joka automaattisesti hyväksyy **[STM](https://www.steamtradematcher.com)** tarjouksia, auttaa sinua joka päivä vastaamaan sarjojasi ilman käyttäjän vuorovaikutusta. ASF sisältää jopa oman ASF 2FA moduulin, jonka avulla voit tuoda Steam-mobiiliautentikoinnin ja voit automatisoida koko prosessin täysin hyväksymällä vahvistukset samoin. Tai ehkä haluat hyväksyä manuaalisesti ja anna ASF vain valmistella näitä kauppoja sinulle? Se on jälleen kerran täysin teidän päätettävissänne.

- **ASF voi lunastaa avaimet taustalla** (**[taustapelit lunastaja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** ominaisuus). Ehkä sinulla on sata avaimia eri nippuja, että olet liian laiska lunastaa itseäsi, menee läpi joukko ikkunoita ja hyväksyy Steamin käyttöehdot yhä uudelleen. Miksi ei kopioida listaasi avaimista ASF:ään ja anna sen tehdä työtä? ASF automaattisesti lunastaa kaikki nämä avaimet taustalla, tarjoaa sinulle asianmukaiset tuotos kertoa sinulle, miten jokainen lunastaa yritys osoittautui. Lisäksi, jos sinulla on satoja avaimia, voit varmasti saada hintarajoja Steamin ennemmin tai myöhemmin, ja ASF tietää myös, että se kärsivällisesti odottaa, että korko-raja mennään pois, ja jatkaa minne se lähti.

Voisimme nyt jatkaa ja jatkaa koko **[ASF wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**, osoitetaan ohjelman jokainen ominaisuus, mutta meidän on piirrettävä rivi jonnekin. Tämä on se, tämä on luettelo ominaisuuksista, joista voit nauttia ASF käyttäjänä, jossa vain yksi niistä voidaan helposti pitää suurin syy koskaan katsoa takaisin, ja me itse asiassa listasimme **paljon** niistä, ja vielä enemmän voit oppia muualla wikissämme. Ah kyllä, ja emme edes mennä yksityiskohtiin asioita, kuten ASF API, jonka avulla voit kirjoittaa omia komentoja, tai mahtava botit hallinta, koska halusimme pitää sen yksinkertaisena.

---

### Onko ASF nopeampi kuin Idle Master?

**Kyllä**, vaikka selitys on melko monimutkainen.

Jokaisessa uudessa prosessissa luotu ja lopetettu järjestelmässäsi, höyryasiakas lähettää automaattisesti pyynnön, joka sisältää kaikki pelit, joita pelaat tällä hetkellä - näin höyryverkko voi laskea tunteja ja tehdä kortteja pudota. Höyryverkko laskee kuitenkin yhden sekunnin välein pelatun ajan, ja uuden pyynnön lähettäminen palauttaa nykyisen tilan. Toisin sanoen, jos luot uuden prosessin 0,5 sekunnin välein, et koskaan pudottaa mitään korttia, koska joka 0. toinen höyry asiakas lähettäisi uuden pyynnön ja höyry verkko ei koskaan laskea edes 1 sekunnin peliaikaa. Lisäksi käyttöjärjestelmän toimivuuden vuoksi on itse asiassa melko tavallista nähdä uusia prosesseja syntyvä/lopetettavan ilman, että edes teet mitään, joten vaikka et tee mitään tietokoneella - on olemassa monia prosesseja vielä toimii taustalla, kutetaan/lopettaa muita prosesseja koko ajan. Idle master perustuu höyryasiakkaaseen, joten tämä mekanismi vaikuttaa sinuun, jos käytät sitä.

ASF ei perustu höyryasiakkaaseen, sillä on oma höyryasiakkaan toteuttaminen. Sen ansiosta ASF ei synny mitään prosessia, mitä se tekee, mutta itse lähettää yhden, todellinen pyyntö höyryä verkossa, että aloimme pelaa peliä. Tämä on sama pyyntö, jonka höyryasiakas lähettäisi mutta koska meillä on todellinen hallinta ASF höyry asiakas, meidän ei tarvitse luoda uusia prosesseja, ja emme ole matkia höyryasiakas lähetä pyyntöä jokaisen prosessin muutoksen, joten edellä kuvattu mekanismi ei vaikuta meihin. Sen ansiosta emme koskaan keskeytä että 1 sekunnin välein höyryn web-puolella, ja joka parantaa maatalouden nopeutta.

---

### Mutta onko ero todella havaittavissa?

Nro Tavanomaisen höyryasiakkaan ja käyttämättömän päällikön kanssa tapahtuvilla keskeytyksillä on vähäinen vaikutus korttien pudotuksiin, joten se ei ole mitään havaittavaa eroa, joka tekisi ASF esimies.

Kuitenkin, **on** ero, ja voit selvästi huomata, että riippuen kuinka kiireinen käyttöjärjestelmä on, kortit **laskee** nopeammin, muutamasta sekunnista jopa muutamaan minuuttiin, jos olet erittäin epäonninen. Vaikka en harkitsisi käyttää ASF vain koska se putoaa kortteja nopeammin, koska sekä ASF ja Idle Master vaikuttavat miten höyry web toimii, ASF vain vuorovaikutuksessa höyry web tehokkaammin, Vaikka Idle Master ei voi hallita mitä höyryasiakas todella tekee (joten se ei ole Idle Masterin vika, vaan höyryasiakkaan itse).

---

### Voiko ASF maatila useita pelejä kerrallaan?

**Kyllä**, vaikka ASF tietää paremmin, milloin käyttää tätä ominaisuutta, perustuu valittuihin **[kortteja maatalouden algoritmi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Kortti putoaa nopeus, kun maatalouden useita pelejä on lähellä nolla, tämän vuoksi ASF käyttää useita pelejä maatalouden yksinomaan tuntikausia voittaakseen `HoursUntilCardDrops` nopeammin, enintään `32` pelejä kerralla. Tämä on myös syy sinun pitäisi keskittyä kokoonpano osa ASF, ja anna algoritmien päättää, mikä on paras tapa saavuttaa tavoite - mitä luulet on oikeassa, ei ole välttämättä oikeassa todellisuudessa, maatalouden useita pelejä kerralla ei tarjota sinulle mitään kortti putoaa.

---

### Voiko ASF ohittaa pelin nopeasti?

**No**, ASF ei tue eikä rohkaise **[Steam glitches](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance#steam-glitches)**.

---

### Voiko ASF pelata automaattisesti jokaista peliä X tuntia ennen korttien lisäämistä?

**Ei**, koko kohta Steam-korttien järjestelmän muutos oli taistella vääriä tilastoja ja haamupelaajia. ASF ei edistä että enemmän kuin tarpeen, lisäämällä tällainen ominaisuus ei ole suunniteltu ja ei tapahdu. Jos peli saa kortin putoaa tavalliseen tapaan, ASF tilalla ne mahdollisimman pian.

---

### Voinko pelata peliä, kun ASF on viljelemässä?

**No**. ASF, toisin kuin jotkut muut työkalut, jotka integroituvat Steam-asiakas, on sen riippumaton täytäntöönpano kyseisen asiakkaan mukana, ja Steam-verkko sallii vain **yhden Steam-asiakkaan kerrallaan** pelaamaan peliä. Voit kuitenkin katkaista ASF:n yhteyden milloin tahansa aloittamalla pelin (ja klikkaamalla "OK", kun kysytään, pitäisikö Steam-verkon katkaista yhteys toiseen asiakkaaseen) - ASF odottaa kärsivällisesti kunnes pelaat ja jatkaa prosessia jälkeenpäin. Vaihtoehtoisesti voit silti pelata offline-tilassa milloin haluat, jos se on tyydyttävä sinulle.

Muista, että kortit pudota hintaa, kun pelaa useita pelejä on lähellä nolla joka tapauksessa, näin ollen ei ole suoraa hyötyä siitä, että se on joidenkin muiden välineiden kanssa, vaikka on olemassa vahvoja etuja ei häiritä muita pelejä käynnistettiin ASF, mikä on ratkaisevan tärkeää. . VAC-viisas.

---

## Turvallisuus / Yksityisyys / VAC / Bannit / Käyttöehdot

---

### Voinko saada VAC kiellon tämän käyttämisestä?

Ei, se ei ole mahdollista, koska ASF (toisin kuin jotkut muut työkalut, kuten Idle Master, SGI tai SAM ei millään tavalla puutu höyryasiakkaaseen eikä sen prosesseihin. On fyysisesti mahdotonta saada VAC kielto käyttää ASF, jopa pelaamisen aikana suojatuilla palvelimilla, kun ASF on käynnissä - tämä johtuu siitä, että **ASF ei edes vaadi Steam-asiakkaan asentamista kaikkiin** toimiakseen oikein. ASF on yksi harvoista viljelyohjelmista, jotka voivat tällä hetkellä taata VAC-vapauden.

---

### Voiko ASF estää minua pelaamasta VAC-suojatuilla palvelimilla, kuten on todettu **[tässä](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**?

ASF ei vaadi Steam-asiakkaan toimintaa tai edes asentamista lainkaan. According to this concept, it should **not** cause any VAC-related issues, because ASF guarantees lack of interfering with Steam client and all its processes - this is the main point when talking about VAC-free guarantee that ASF offers.

Käyttäjien ja parhaan tietämykseni mukaan näin on juuri nyt, kuten kukaan ei ilmoittanut edellä mainitussa linkissä mainituista ongelmista ASF:n käytön yhteydessä. Emme voineet jäljentää ongelmaa edellä ASF samoin, mutta selvästi jäljentää sitä Idle Master.

Pidä kuitenkin mielessä, että venttiili voisi vielä jossain vaiheessa lisätä ASF mustalle listalle. mutta se on täydellinen hölynpölyä kuin vaikka he tekevät sen, voit silti pelata VAC-suojattuja pelejä tietokoneelta ja käyttää ASF samaan aikaan e. . palvelimellasi, joten olen melko varma, että he tietävät hyvin, että ASF ei pitäisi olla epäilty VAC-viisas, ja he eivät tee meidän hissejä vaikeampaa mustalle listalle ASF ilman syytä. Pahimmassa tapauksessa et kuitenkaan voi pelata, kuten edellä, koska ASF:n VAC-vapaa takuu on edelleen olemassa riippumatta siitä, onko Steam blacklists ASF binary, tai ei (ja voit silti käynnistää ASF millä tahansa koneella ilman Steam-asiakas ollenkaan). Juuri nyt ei ole tarvetta tehdä mitään sellaista, ja toivokaamme, että se pysyy näin.

---

### Onko se turvallista?

Jos kysyt, onko ASF turvallinen ohjelmistona, mikä tarkoittaa, että se ei aiheuta vahinkoa tietokoneellesi, ei varasta yksityistietojasi, asenna viruksia tai muita sellaisia - se on turvallista. ASF ei sisällä haittaohjelmia, tietojen varastamista, kryptovaluutan kaivostyöläiset ja kaikki (ja kaikki) muut epäilyttävät käytökset, joita käyttäjä voi pitää pahansuopina tai ei-toivottuina. Sen lisäksi meillä on oma **[etäviestintä](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** osio joka kattaa tietosuojakäytäntömme ja ASF käytöksemme, joka menee pidemmälle kuin mitä olet määrittänyt ohjelman tehdä itse.

Koodimme on avoin lähdekoodi, ja hajautetut binaarit on aina koottu **[julkisesti saatavilla olevista lähteistä](https://en.wikipedia.org/wiki/Open-source_software)** **[automatisoiduista ja luotetuista jatkuvan integraation järjestelmistä](https://en.wikipedia.org/wiki/Build_automation)**, eikä edes kehittäjät itse. Jokainen rakennus on toistettavissa seuraamalla meidän build skriptiä ja johtaa täsmälleen samaan, **[deterministinen](https://en.wikipedia.org/wiki/Deterministic_system)** IL (binääri) koodi. Jos et jostain syystä luota meidän rakennuksiin, voit aina koota ja käyttää ASF lähteestä, sisältäen kaikki kirjastot, joita ASF käyttää (kuten SteamKit2), jotka ovat myös avoimia.

Loppujen lopuksi se on kuitenkin aina luottamuksellinen asia sovelluksesi kehittäjille/kehittäjille, joten sinun pitäisi itse päättää, pitäisikö ASF turvallista vai ei, mahdollisesti tukemalla päätöstäsi edellä mainituilla teknisillä perusteilla. Älä sokeasti usko jotain vain koska me sanoimme niin - tarkista itse, koska se on ainoa tapa tehdä varma.

---

### Voinko saada kiellon tämän vuoksi?

Vastataksemme tähän kysymykseen meidän pitäisi tarkastella lähemmin **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Steam ei estä käyttämästä useita tilejä, itse asiassa **[se sallii sen](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)** olettaen, että voit käyttää samaa mobiilivarmentajaa useammalla kuin yhdellä tilillä. Mitä se kuitenkaan ei salli on jakaa tilejä muiden ihmisten kanssa, mutta emme tee sitä täällä.

Ainoa todellinen seikka, jossa ASF katsoo, on seuraava:
> Et saa käyttää huijausta, automaatio-ohjelmistoa (bottia), modeja, hakkeroituja tai muita luvattomia kolmannen osapuolen ohjelmistoja, muokata tai automatisoida mitään tilausmarkkinaprosessia.

Kysymys on, mitä itse asiassa on tilausmarkkina prosessi. Kuten voimme lukea:

> Esimerkkinä tilausmarkkinasta on Steam-yhteisön markkinat (Steam Community Markets)

Emme muokkaa tai automatisoi tilausmarkkinaprosessia, jos tilauksen markkinapaikan kautta ymmärrämme höyryyhteisön markkinoita tai höyrykauppaa. Silti...

> Venttiili voi peruuttaa tilisi tai minkä tahansa tietyn tilauksen milloin tahansa siinä tapauksessa, että (a) Venttiili lakkaa tarjoamasta tällaisia tilauksia samalla tavalla sijaitseville Tilaajille yleensä, tai (b) rikkot tämän sopimuksen ehtoja (mukaan lukien kaikki tilausehdot tai Käyttösäännöt).

Näin ollen, kuten jokainen Steam-ohjelmisto, ASF ei ole Valenttiili valtuuttama enkä voi taata, että et joudu keskeyttämään, jos Venttiili yhtäkkiä päättää kieltävänsä tilit ASF:llä nyt. Tämä on erittäin epätodennäköistä, kun otetaan huomioon, että ASF:ää käytetään yli muutamassa miljoonassa Steam-tilissä. koska sen ensimmäinen julkaisu, joka tapahtui yli 10 vuotta sitten - mutta silti mahdollisuus, riippumatta todellisesta todennäköisyydestä.

Erityisesti seuraavista syistä:
> Kaikista tilauksista, sisällöstä ja palveluista, jotka eivät ole Valven valtuuttamia, Venttiili ei näytä tällaista kolmannen osapuolen sisältöä saatavilla Steamissä tai muiden lähteiden kautta. Venttiili ei vastaa tai vastaa tällaisesta kolmannen osapuolen sisällöstä. Jotkin kolmannen osapuolen sovellusohjelmistot ovat yritysten käytettävissä liiketoimintatarkoituksiin - kuitenkin, voit hankkia tällaisia ohjelmistoja vain Steamin kautta henkilökohtaiseen käyttöön.

However, Valve clearly acknowledges "Steam idlers" existing, as stated **[here](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**, so if you asked me, I'm pretty sure that if they weren't fine with them, they'd already do something instead of pointing out that they could cause problems VAC-wise. Avainsana tässä on **Steam** idlers, esimerkiksi ASF, eikä **peli** idlers.

Huomioithan, että yllä on vain meidän tulkinta **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** ja useita pisteitä - ASF on lisensoitu Apache 2. Lisenssi, jossa selvästi mainitaan:

```
Ellei sovellettavassa lainsäädännössä toisin edellytetä tai ellei lisenssillä levitetään
-ohjelmistoa kirjallisesti "AS IS" -järjestelmässä,
ILMAN TIETOJA TAI NIIDEN EDELLYTYKSIÄ joko suoraan tai epäsuorasti.
```

Käytät tätä ohjelmistoa omalla vastuullasi. On erittäin epätodennäköistä, että voit saada kiellon siitä, mutta jos teet, voit syyttää vain itseäsi.

---

### Saako joku porttikiellon siitä?

**Kyllä**, meillä oli ainakin muutamia välikohtauksia niin pitkälle, että johti jonkinlainen Steam-suspensio. Onko ASF itse oli juuri syy tai ei ole täysin eri tarina, että emme luultavasti koskaan saa tietää.

Ensimmäinen tapaus mukana kaveri yli 1000+ botteja saada kauppaa kielletty (yhdessä kaikkien bottejen), todennäköisimmin siksi, että `ryöstäjä ASF` suoritettiin kaikissa veneissä kerralla, tai muita epäilyttäviä yksipuolisia kauppoja hyvin lyhyessä ajassa.

> Hei XXX, Kiitos ottaa yhteyttä Steam-tukeen. Näyttää siltä, että tätä tiliä käytettiin bottitilien verkon hallintaan. Botting on Steam-tilauksen sopimuksen vastainen.

Käytä jotain tervettä järkeä ja älä oleta, että voit tehdä niin hullu asioita vain koska ASF voit tehdä sen. `ryöstely ASF` yli 1k botteja voidaan helposti pitää **[DDoS](https://en.wikipedia.org/wiki/DDoS)** hyökkäyksenä, ja henkilökohtaisesti en ole järkyttynyt siitä, että joku sai kiellettyä tuollaista. Pidä minimi kohtuullisen käytön suhteen Steam-palveluun ja **todennäköisimmin** sinun on hyvä olla.

Toisessa tapauksessa kaveri 170+ botteja saada kielletty aikana Steam 2017 Winter Sale.

> Tilisi oli suljettu tilaajan Steamin sopimuksen rikkomisen vuoksi. Vaihtojen ja muiden tekijöiden perusteella tätä tiliä käytettiin keräyskorttien laittomaan keräämiseen Steamissa, sekä siihen liittyvät ja ei vain kaupallinen toiminta. Tili on pysyvästi estetty ja Steam-tuki ei voi antaa lisätukea tässä asiassa.

Tämä tapaus on jälleen erittäin vaikea analysoida, koska Steam-tuki on epämääräinen vastaus, joka tuskin tarjoaa mitään yksityiskohtia. Henkilökohtaisten ajatusteni perusteella tämä käyttäjä luultavasti vaihtoi Steam-kortteja jonkinlaiselle rahalle (taso ylöspäin? tai jollakin muulla tavalla yritti lunastaa Steam. Jos et tiennyt, tämä on myös laitonta mukaan **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Emme pysty kertomaan mitä voit tehdä kaupankäynnin kortteja saatu ASF - mutta käyttäjä ei todellakaan ole vain venyttää merkkejä heidän kanssaan.

Kolmas tapaus koski käyttäjää, jolla oli 120 + botin porttikieltoa **[Steam-verkkokäyttäytymisen](https://store.steampowered.com/online_conduct?l=english)** rikkomisen vuoksi.

> Hei XXX, Kiitos ottaa yhteyttä Steam-tukeen. Tätä ja muita tilejä käytettiin verkon infrastruktuurin tulvimiseen, mikä on Steamin verkkokäyttäytymisen vastaista. Tili on pysyvästi estetty ja Steam-tuki ei voi antaa lisätukea tässä asiassa.

Tämä tapaus on hieman helpompi analysoida, koska käyttäjän antamat tarkemmat tiedot. Ilmeisesti käyttäjä käytti **hyvin vanhentunutta ASF-versiota** , joka sisälsi vian, joka aiheutti ASF:n lähettämään liikaa pyyntöjä Steam-palvelimille. Itse bugia ei ollut olemassa ensin, mutta se oli aktivoitu Steam-murtomuutoksen vuoksi, joka korjattiin tulevassa versiossa. **ASF on tuettu vain [viimeisin vakaa versio](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) julkaistiin GitHub**.

Et voi olettaa, että jokin vanhentunut ASF versio toimii samalla tavalla kuin se käytetään ikuisesti, varsinkin koska Steam muuttuu jatkuvasti riippumatta pidät siitä tai et. Jos tällaista tapahtuu maailmanlaajuisesti, se on nopeasti korjataan ylös ja vapautetaan kaikille käyttäjille kuin bugfix. Venttiili ei yhtäkkiä estä yli miljoona ASF-käyttäjää meidän tai heidän virheensä vuoksi, ilmeisistä syistä. Jos kuitenkin tarkoituksellisesti luovut ajantasaisen ASF:n käytöstä, sitten määritelmän mukaan olet hyvin pieni vähemmistö käyttäjistä, jotka ovat **alttiina tällaisille** tapahtumille johtuen **ei tukea**, koska kukaan ei tarkkaile vanhentuneen ASF:n versiota, kukaan ei korjaa sitä eikä kukaan varmista, että et saa suoraa kieltoa käynnistämällä sen. **Ole hyvä ja käytä ajan tasalla olevaa**, paitsi ASF , myös kaikki muut sovellukset .

Viimeisin tapaus tapahtui noin kesäkuussa 2021 käyttäjän mukaan:

> Ohjelmaasi avulla olen tehnyt tehostepaketteja, joissa on 28 tiliä 3 vuotta ja 128 tiliä viimeisen 6 kuukauden aikana. Olin verkossa enintään 15 tiliä samanaikaisesti tehdä booster paketteja ja lähettää ne päätilille. Viime kuussa nostin samanaikaisesti sähköisten tilien lukumäärää 20 ja sen jälkeen kaikki tilini kiellettiin. Tämä sähköpostiosoite ei ole syyllinen sinuun, päinvastoin, olin aina tietoinen seurauksista. Halusin sinun tietävän, millainen käytös johtaa pysyvään kieltoon.

On vaikea sanoa, oliko samanaikaisten tilien kasvu verkossa ollut suora syy kieltoon, En luottaisi siihen, vaan uskon, että pelkkien tilien määrä oli pääsyyllinen, lisääntynyt concurrency online tilien luultavasti juuri kiinnitti huomiota käyttäjän, koska hän selvästi oli paljon enemmän botteja kuin meidän suositus.

---

Kaikilla edellä mainituilla tapahtumilla on yksi yhteinen asia - ASF on vain työkalu ja se on **sinun** päätös miten aiot hyödyntää sitä. Et saa porttikieltoa ASF:n suoraan, mutta **kuinka** käytät sitä. Se voi olla apuväline maanviljely vain yhden tilin, tai massiivinen viljelyverkosto on tehty tuhansista botteja. Joka tapauksessa en tarjoa oikeudellista neuvontaa, ja sinun pitäisi päättää itse ASF käyttö ensin. En piilota mitään tietoa, joka voisi auttaa sinua, esim. se, että ASF sai joitakin ihmisiä kiellettyä (ja missä yhteydessä), koska minulla ei ole mitään syytä - se on sinun valintasi, mitä haluat tehdä kyseisen tiedon.

Jos kysyt minulta - käytä tervettä järkeä, vältä enemmän botteja kuin meidän suositus, älä lähetä satoja kauppoja samaan aikaan, käytä aina ajan tasalla olevaa ASF versiota ja _pitäisi_ olla hieno. Jokainen yksittäinen tapaus tällaista **jostain syystä** aina tapahtunut ihmisille, jotka ovat laiminlyöneet meidän suosituksia, parhaat käytännöt ja ehdotukset uskovat, että he tietävät meitä paremmin. . kuinka monta bottia he voivat juosta. Olipa kyseessä vain sattuma tai jokin todellinen tekijä, se on sinun päätettävissäsi. Emme tarjoa mitään oikeudellista neuvontaa, vain antaa sinulle ajatuksia, jotka voit löytää hyödyllisiä, tai jättää ne kokonaan huomiotta ja toimia vain edellä mainittuihin seikkoihin liittyen.

---

### Mitä tietosuojatietoja ASF paljastaa?

Löydät yksityiskohtaisen selityksen **[etäviestinnästä](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** -osiosta. Sinun tulisi tarkistaa se jos välität yksityisyydestäsi, esim. jos ihmettelet, miksi ASF käyttää tilejä ovat liittymässä Steam-ryhmään. ASF ei kerää mitään arkaluonteisia tietoja, eikä jaa sitä kolmannen osapuolen kanssa.

---

## Sekalaiset

---

### Käytän tukematonta käyttöjärjestelmää, kuten 32-bittistä Windowsia, voinko silti käyttää viimeisintä ASF:n versiota?

Kyllä, ja että versio ei ole tuettu millään tavalla, vain ei virallisesti rakennettu. Katso **[yhteensopivuus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** -osio geneeriselle variantille. ASF ei ole vahva riippuvuus OS, ja se voi toimia missä tahansa voit saada työ. ET ajoaika, joka sisältää 32-bittinen Windows, vaikka ei ole `win-x86` OS-spesifinen paketti meiltä.

---

### ASF on loistava! Voinko tehdä lahjoituksen?

Kyllä, ja olemme hyvin iloisia kuullessamme että nautit projektistamme! Voit löytää erilaisia lahjoitusmahdollisuuksia jokaisen **[julkaisun](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ja myös **[pääsivulla](https://github.com/JustArchiNET/ArchiSteamFarm)**. On mukava huomata, että geneeristen rahojen lisäksi hyväksymme myös Steam-kohteita, joten mikään ei estä sinua lahjoittamasta nahkoja, avaimia tai pieni osa kortteja, että olet tarttunut ASF jos haluat. Kiitos etukäteen anteliaisuudestasi!

---

### Käytän Steam vanhempien PIN-koodia suojatakseni tiliäni, pitääkö minun syöttää se jonnekin?

Kyllä, sinun täytyy asettaa se `SteamParentalCode` bot config ominaisuus. Tämä johtuu pääasiassa siitä, että ASF käyttää monia Steam-tilisi suojattuja osia ja ASF:n on mahdotonta toimia ilman sitä.

---

### En halua ASF tilata oletuksena mitään pelejä, mutta haluan käyttää ylimääräisiä ASF ominaisuuksia. Onko tämä mahdollista?

Kyllä, jos haluat vain aloittaa ASF keskeytetty korttien viljelymoduuli, voit asettaa `FarmingPausedByDefault` `FarmingPreferences` botti config ominaisuuden tämän saavuttamiseksi. Tämä mahdollistaa sinun `jatkaa` sen suorittamisen aikana.

Jos haluat täysin poistaa kortit maatalouden moduuli ja varmistaa, että se ei koskaan toimi ilman nimenomaisesti kertoa sitä muuten, sitten suosittelemme asettamaan `FarmPriorityQueueOnly` botissa `FarmingPreferences`, joka sen sijaan vain keskeyttää sen, poistaa maatalouden kokonaan, kunnes lisäät pelejä tyhjäksi prioriteettijono itse.

Korttien kasvatus moduuli keskeytetty/pois päältä, voit käyttää ylimääräisiä ASF ominaisuuksia, kuten `GamesPlayedWhileIdle`.

---

### Voiko ASF minimoida tarjottimen?

ASF on konsolisovellus, ei ole pienennettävää ikkunaa, koska käyttöjärjestelmä on luonut ikkunan sinulle. Voit kuitenkin käyttää mitä tahansa kolmannen osapuolen työkalua, kuten **[RBTray](https://github.com/benbuck/rbtray)** Windowsille, tai **[](https://linux.die.net/man/1/screen)** Linux/macOS:lle. Nämä ovat vain esimerkkejä, on monia muita sovelluksia, joilla on samankaltainen toiminto.

---

### Säilyttääkö ASF:n käyttö kelpoisuuden saada tehostepakkauksia?

**Kyllä**. ASF käyttää samaa menetelmää kirjautuakseen Steam-verkkoon kuin virallinen asiakas, Näin ollen se säilyttää myös kyvyn saada tehostepakkauksia tileille, joita käytetään ASF:ssä. Lisäksi tämän kyvyn säilyttäminen ei vaadi edes kirjautumista Steam-yhteisöön, joten voit turvallisesti käyttää `OnlineStatus` `Offline` -asetusta jos haluat.

---

### Onko mitään keinoa kommunikoida ASF:n kanssa?

Kyllä, useilla eri tavoilla. Tutustu **[komentoihin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** -osio saadaksesi lisätietoja.

---

### Haluaisin auttaa ASF käännös, mitä minun täytyy tehdä?

Kiitos kiinnostuksestasi! You can find all details in our **[localization](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** section.

---

### Minulla on vain yksi (main) tili lisätty ASF:ään, voinko silti antaa komentoja höyrykeskustelun kautta?

**Kyllä**, se on selitetty **[komennoissa](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#notes)**. Voit tehdä niin Steam-ryhmän chatin kautta, vaikka **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** voi olla sinulle helpompaa.

---

### ASF näyttää toimivan, mutta en saa mitään korttipudotuksia!

Korttien viljely nopeus poikkeaa pelistä peliin, kuten voit lukea **[suorituskyky](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Se kestää jonkin aikaa, yleensä **useita tunteja per peli**, ja sinun ei pitäisi odottaa korttien pudota muutamassa minuutissa ohjelman käynnistämisen jälkeen. Jos näet, että ASF aktiivisesti tarkistaa korttien tilaa, ja kytkee pelin jälkeen nykyinen on täysin viljellyt, niin kaikki toimii hyvin. On mahdollista, että olet ottanut käyttöön vaihtoehdon, kuten `DismissInventoryNotifications` of `BotBehaviour` -toiminnon, joka automaattisesti poistaa inventaarioilmoitukset. Katso lisätietoja **[asetukset](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**

---

### Kuinka täysin pysäyttää ASF prosessi minun tilin?

Yksinkertaisesti sammuttaa ASF prosessi, esimerkiksi klikkaamalla [X] Windows. Jos sen sijaan haluat lopettaa tietyn botti valintasi, mutta pitää muut käynnissä, sitten katsomaan `Käytössä` **[bot config ominaisuus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**, tai `pysäytä` **[komento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Jos haluat sen sijaan lopettaa automaattisen viljelyn mutta pitää ASF käynnissä tililläsi, sitten se mitä `FarmingPausedByDefault` vaihtoehto `FarmingPreferences` **[bot config ominaisuus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** ja `tauko` **[komento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** on tarkoitettu.

---

### Kuinka monta bottia voin ajaa ASF:llä?

ASF ohjelmana ei ole kovaa ylärajaa botin ilmentymiä, joten voit ajaa niin paljon kuin sinulla on muistia koneellasi, Steam-verkosto ja muut Steam-palvelut ovat kuitenkin edelleen rajallisia. Tällä hetkellä voit ajaa jopa 100-200 bottia yhdellä IP-osoitteella ja yhdellä ASF-esiintymällä. On mahdollista ajaa enemmän botteja enemmän IP-osoitteita ja enemmän ASF instansseja, toimimalla IP-rajoituksia. Pidä mielessä, että jos käytät suurta määrää botteja, sinun pitäisi hallita niiden määrä itse, kuten varmistaa, että kaikki ne itse asiassa ovat kirjautumalla sisään ja työskentelemällä samanaikaisesti. ASF ei viritetty että valtava määrä botteja, ja yleissääntöä sovelletaan, että **mitä enemmän botteja sinulla on, sitä enemmän ongelmia kohtaat**. Huomaa myös, että edellä mainittu raja riippuu yleensä monista sisäisistä tekijöistä, se on pikemminkin lähentäminen kuin tiukka raja - todennäköisimmin voit ajaa enemmän / vähemmän botit kuin edellä.

ASF Group ehdottaa **omistaa** **10 Steam-tiliä yhteensä**, ja näin ollen myös **10 botit yhteensä**. Kaikkea edellä mainittua ei tueta ja tehdä omalla vastuullanne, tässä esitettyä ehdotustamme. Tämä suositus perustuu sisäisiin venttiilin ohjeisiin sekä omiin ehdotuksiimme. Olitpa menossa noudattamaan tätä sääntöä tai ei ole valintasi, ASF työkaluksi ei mene vastoin omaa tahtoasi, vaikka se johtaisi siihen, että Steam-tilisi keskeytetään sen tekemiseksi. Siksi ASF näyttää sinulle varoituksen, jos menet yli mitä suosittelemme, mutta silti voit ajaa mitä haluat omalla riskilläsi ja puutteella tukemme.

---

### Voinko sitten ajaa enemmän ASF tapauksia?

Voit ajaa yhtä monta ASF instanssia kuin haluat, olettaen, että jokaisella instanssillä on oma hakemistonsa ja omat konfiguraationsa, ja yhdessä tapauksessa käytettyä tiliä ei käytetä toisessa tapauksessa. Kysy kuitenkin itseltäsi, miksi haluat tehdä sen. ASF on optimoitu käsittelemään yli sata tiliä samaan aikaan, ja käynnistää että sata botit omassa ASF tapauksissa heikentää suorituskykyä, vie enemmän käyttöjärjestelmän resursseja (kuten CPU ja muisti), ja aiheuttaa mahdollisia synkronointiongelmia välillä itsenäinen ASF instansseja, Koska ASF on pakotettu jakamaan rajoittimiaan muiden tilanteiden kanssa.

Siksi minun **vahva ehdotus** on, aina ajaa enintään yksi ASF instanssi per yksi IP/liitäntä. Jos sinulla on enemmän IP/liitäntöjä, voit kaikin keinoin ajaa enemmän ASF instansseja, jokainen instanssi käyttää omaa IP/käyttöliittymää tai ainutlaatuista `WebProxy` asetusta. Jos ei, käynnistämällä enemmän ASF instansseja on täysin turhaa, koska et saa mitään käynnistämällä enemmän kuin 1 instanssi per yksittäinen IP/käyttöliittymä. Steam ei taianomaisesti salli sinun ajaa enemmän botteja vain koska olet käynnistänyt ne toisessa ASF esimerkiksi, ja ASF ei rajoita sinua aluksi.

Tietenkin on edelleen päteviä käyttötapauksia useita ASF tapauksissa samassa verkkoliitäntä, kuten ASF-palvelun ylläpitäminen ystävillesi kullakin ystävällä on oma ainutlaatuinen ASF instanssi, jotta voidaan taata eristäminen botteja ja jopa ASF itse prosessoi kuitenkin, et kiertää mitään Steam-rajoituksia tällä tavalla, se on täysin eri tarkoitus.

---

### Mikä merkitys statuksella on, kun lunastaa avaimen?

Tila ilmaisee, kuinka annettu lunastusyritys osoittautui. On olemassa monia erilaisia tiloja mahdollisia, yleisimpiä niitä:

| Tila                       | Kuvaus                                                                                                                                                                                                                  |
| -------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| NoDetail                   | "OK" tila osoittaa menestystä - avain poistettiin onnistuneesti.                                                                                                                                                        |
| Aikakatkaisu               | Steam-verkko ei vastannut annetussa ajassa, emme tiedä, onko avain lunastettu tai ei (todennäköisesti oli, mutta voit yrittää uudelleen).                                                                               |
| BadAktivointikoodi         | Annettu avain on virheellinen (ei tunnistettu kelvolliseksi avaimeksi Steam-verkossa).                                                                                                                                  |
| DuplikaattiAktivointikoodi | Annettu avain on jo lunastettu jokin muu tili tai peruttu kehittäjä/kustantaja.                                                                                                                                         |
| Jo Ostettu                 | Tilisi omistaa jo `-pakettitunnuksen` , joka on yhdistetty tähän avaimeen. Muista, että tämä ei tarkoita, onko avain `DuplicateActivationCode` vai ei - vain että se on voimassa ja sitä ei käytetty tässä yrityksessä. |
| Rajoitettu Maa             | Tämä on region-lukittu avain ja tilisi ei ole voimassa alueella, jolla on lupa lunastaa se.                                                                                                                             |
| DoesNotOwnRequiredApp      | Et voi lunastaa tätä avainta koska olet puuttuu jokin muu sovellus - lähinnä peruspeli, kun yrität lunastaa DLC-paketin.                                                                                                |
| RateLimited                | Olet tehnyt liian monta lunastamisyritystä ja tilisi oli tilapäisesti estetty. Yritä uudelleen tunnin kuluttua.                                                                                                         |

---

### Oletko sidoksissa mitään kortteja viljely / idling palvelu?

**No**. ASF ei ole sidoksissa mihinkään palveluun ja kaikki tällaiset väitteet ovat vääriä. Steam-tilisi on omaisuutesi ja voit käyttää tiliäsi haluamallasi tavalla, mutta venttiili selvästi todetaan **[virallinen ToS](https://store.steampowered.com/subscriber_agreement)** että:

> Olet vastuussa kirjautumisesi ja salasanasi luottamuksellisuudesta ja siitä, että tietojärjestelmäsi on turvallinen. Venttiili ei ole vastuussa salasanasi ja käyttäjätilisi käytöstä tai kaikesta Steamissä tapahtuvasta viestinnästä ja toiminnasta, joka johtuu kirjautumisnimesi ja salasanasi käytöstä, tai kuka tahansa henkilö, jolle olet tahallisesti tai huolimattomasti paljastanut käyttäjätunnuksesi ja/tai salasanasi tämän salassapitosäännöksen vastaisesti.

ASF on lisensoitu liberaalille Apache 2.0 -lisenssille, jonka avulla muut kehittäjät voivat integroida ASF:n edelleen omiin projekteihinsa ja palveluihinsa laillisesti. ASF:ää hyödyntävien kolmansien osapuolten hankkeiden ei kuitenkaan voida taata olevan turvallisia, tarkistetuja, asianmukaisia tai laillisia **[Steam-käyttöjärjestelmä](https://store.steampowered.com/subscriber_agreement)** mukaisesti. Jos haluat tietää mielipiteemme, **me vahvasti kannustaa sinua EIVÄT jakaa tilitietojasi kolmannen osapuolen palveluilla**. Jos tällainen palvelu osoittautuu **tyypillinen huijaus**, voit jättää yksin ongelman kanssa todennäköisimmin ilman Steam-tiliäsi ja ASF ei ota vastuuta kolmannen osapuolen palveluista, jotka väittävät olevansa turvallisia ja turvallisia, koska ASF joukkue ei valtuuttanut kumpikaan tarkastaa niitä. Toisin sanoen, **käytät niitä omalla vastuullasi, vastaan ehdotusta, joka on yli**.

Sen lisäksi virallisessa **[Steam-ToS](https://store.steampowered.com/subscriber_agreement)** todetaan selkeästi, että:

> Et saa paljastaa, jakaa tai muutoin sallia muiden käyttää salasanaasi tai tiliäsi muuten kuin Valven nimenomaisesti valtuuttamana.

Se on tilisi ja valintasi. Älä vain sano, että kukaan ei varoittanut sinua. ASF ohjelmana täyttää kaikki edellä mainitut säännöt, koska et jaa tilisi tietoja kenellekään, ja käytät ohjelmaa omaan henkilökohtaiseen käyttöön, mutta kaikki muut "kortit maatalouden palvelu" vaatii sinulta tilitietosi, joten se myös rikkoo edellä olevaa sääntöä (itse asiassa useita niistä). Kuten **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** -arvioinnissa, emme tarjoa mitään oikeudellista neuvontaa, ja sinun pitäisi päättää itse, jos haluat käyttää näitä palveluja, tai ei - meidän mukaamme **se rikkoo suoraan [Steam ToS](https://store.steampowered.com/subscriber_agreement)** ja voi johtaa suspensioon, jos venttiili löydetään. Kuten edellä mainittiin, **suosittelemme, ettemme käytä mitään tällaisia palveluja**.

---

## Ongelmat

---

### Yksi peleistäni on viljellyt yli 10 tuntia nyt, mutta en vieläkään saanut kortteja siitä!

Syy tähän voisi liittyä tiedossa olevaan Steamin ongelmaan, joka tapahtuu, kun sinulla on kaksi lisenssiä samaan peliin, joista toisella on kortti putoaa rajoitettu. Tämä tapahtuu yleensä, kun aktivoi pelin ilmaiseksi aikana massa kylkiäinen Steam, ja sitten aktivoida avain samaan peliin (mutta ilman rajoituksia), e. . alkaen maksettu nippu. Jos tällainen tilanne tapahtuu, Steam raportit kunniamerkki sivulla, että peli on vielä kortteja pudota, mutta ei väliä kuinka paljon pelaat peliä - kortit eivät koskaan pudota koska ilmainen lisenssi tilillesi. Koska se ei ole ASF ongelma vaan Steam, emme voi jotenkin kiertää sitä ASF puolella, ja sinun täytyy ratkaista se itse.

On olemassa kaksi tapaa ratkaista ongelma. Ensinnäkin, voit mustalle listalle tämän pelin ASF, joko `fbadd` **[-komennolla](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** tai `mustalla` **[-asetuksilla](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Tämä estää ASF yrittää maatilan kortteja tästä pelistä, mutta ei ratkaise taustalla oleva ongelma, joka estää sinua saamasta kortin putoaa vaikuttaa peliin. Toiseksi, voit käyttää Steam-tuen itsepalvelutyökalua poistaaksesi ilmaisen lisenssin tililtäsi jättäen vain täyden lisenssin, joka sisältää kortin pudotuksen. Voidakseen tehdä niin, käy ensin **[-lisensseissä ja tuoteavaimissa aktivoinneissa](https://store.steampowered.com/account/licenses)** -sivulla ja löydä sekä ilmainen että maksullinen lisenssi vaikuttaa peliin. Yleensä se on melko helppoa - molemmilla on samanlainen nimi, mutta vapaa on "rajoitettu vapaa myynninedistämispaketti" tai muu "promo" lisenssin nimessä, plus "complimentary" "hankintamenetelmällä" kentällä. Joskus se voi olla hankalampaa, esimerkiksi jos ilmainen paketti oli jossain nippu ja on eri nimi. Jos olet löytänyt kaksi lisenssiä kuten se - niin se on todellakin ongelma kuvattu täällä, ja voit turvallisesti poistaa ilmaisen lisenssin menettämättä peliä.

Jotta voit poistaa ilmaisen lisenssin tililtäsi, vieraile **[Steam-tukisivu](https://help.steampowered.com/wizard/HelpWithGame)** ja laita pelin nimi hakukenttään, pelin pitäisi olla saatavilla "tuotteet" -osiossa, klikkaa sitä. Vaihtoehtoisesti voit käyttää vain `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` -linkkiä ja korvata `<appID>` pelin, joka aiheuttaa ongelmia. Jälkeen, klikkaa "Haluan pysyvästi poistaa tämän pelin tililtäni" ja valitse sitten viallinen ilmainen lisenssi, jonka olet löytänyt edellä, yleensä yksi kanssa "rajoitettu vapaa myynninedistämispaketti" nimessä (tai vastaava). Kun ilmainen lisenssi on poistettu, ASF olisi voitava pudottaa kortteja kärsivän pelin ongelmitta, sinun pitäisi käynnistää viljelytoiminta uudelleen poistamisen jälkeen vain varmistaaksesi, että Steam hakee oikean lisenssin tällä kertaa.

---

### ASF ei havaitse peliä `X` viljelyä varten, mutta tiedän, että se sisältää Steam-kaupankäyntikortteja!

Tähän on kaksi pääasiallista syytä. Ensimmäinen ja ilmeisin syy on se, että viittaat **Steam-myymälään** , jossa annettu peli ilmoitetaan korttipudotuksina käytössä olevana pelinä. Tämä on **väärä** oletus, koska se yksinkertaisesti sanoo, että peli **on** kortti putoaa mukana, mutta ei välttämättä tämä toiminto on **käytössä** heti. Tästä voit lukea lisää **[virallisesta ilmoituksesta](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**.

Lyhyesti sanottuna, kortti pudottaa kuvaketta Steam-kauppaan ei tarkoita mitään, tarkista **[-merkkisivut](https://steamcommunity.com/my/badges)** saadaksesi vahvistuksen siitä, onko pelin korttipudotus käytössä vai ei - tämä on myös mitä ASF tekee. Jos pelisi ei näy luettelossa pelinä jossa on mahdollista pudottaa kortteja, sitten tämä peli on **ei** mahdollista maatilalle, riippumatta syystä.

Toinen asia ei ole yhtä ilmeinen. ja se on tilanne, kun voit nähdä, että peli todellakin on saatavilla kortti tippaa teidän merkki sivulla, kuitenkaan ASF ei viljele sitä heti. Ellet lyödä jotain muuta bugia, kuten ASF ei pysty tarkastamaan merkkisivustoja (kuvattu alla), se on yksinkertaisesti välimuisti vaikutus ja ASF puolella Steam on edelleen raportointi vanhentuneita merkkejä sivu. Tämän ongelman pitäisi ratkaista ennemmin tai myöhemmin, kun välimuisti mitätöidään. Ei ole myöskään mitään keinoa korjata tätä meidän puolellamme.

Tietenkin kaikki tämä olettaa, että olet käynnissä ASF oletuksena koskemattomia asetuksia, koska voit myös lisätä tämän pelin maatalouden mustalle listalle, käytä valittua `FarmingPreferences` kuten `FarmPriorityQueueOnly` tai `SkipRefundableGames`ja niin edelleen.

---

### Miksi pelaamisen aikaa viljellyt ASF ei lisää?

Se on, mutta **ei reaaliajassa**. Steam tallentaa soittoaikasi kiinteinä aikaväleinä ja aikataulujen päivityksinä sitä varten, mutta et ole taatusti on se päivittää välittömästi kun lopetat istunnon, saati sen aikana. Vain koska peliaikaa ei päivitetä reaaliaikaisesti ei tarkoita, että se ei ole tallennettu, se on yleensä päivitetty 30 minuutin välein.

---

### Mitä eroa on varoituksella ja virheellä lokissa?

ASF kirjoittaa sen log joukko tietoja eri puunkorjuutasoilla. Tavoitteenamme on selittää **tarkasti** mitä ASF tekee, mukaan lukien mitä Steam-ongelmia sen on käsiteltävä, tai muita ongelmia ratkaistava. Suurimman osan ajasta kaikki ei ole merkityksellistä, Tämän vuoksi ASF:ssä on käytössä kaksi suurta tasoa, jotka liittyvät ongelmiin - varoitustaso ja virhetaso.

ASF:n yleinen sääntö on, että varoitukset eivät ole **** -virheitä, joten ne olisi **ei** ilmoitettava. Varoitus on sinulle merkki siitä, että jotain mahdollisesti ei-toivottua tapahtuu. Olipa kyseessä Steam ei reagoi, API heittää virheitä tai verkkoyhteyden ollessa alhaalla - se on varoitus, ja se tarkoittaa, että odotimme sen tapahtuvan, joten älä häiritse ASF kehitystä sen kanssa. Tietenkin voit vapaasti kysyä niistä tai saada apua käyttämällä meidän tukea, mutta sinun ei pitäisi olettaa, että nämä ovat ASF virheitä raportoinnin arvoinen (ellemme vahvista muuta).

Toisaalta virheet osoittavat tilanteen, jota ei pitäisi tapahtua, siksi he kannattaa raportoida niin kauan kuin olet varmistanut, että se ei ole kuka aiheuttaa niitä. Jos se on yleinen tilanne, että odotamme tapahtuvan, niin se muunnetaan varoitukseksi. Muuten se on mahdollisesti bug joka pitäisi korjata, ei hiljaa sivuuttaa, olettaen, että se ei johdu oman teknisen ongelman. Esimerkiksi, laita virheellinen sisältö `ASF. poika` tiedosto heittää virheen, koska ASF ei pysty jäsentämään sitä, mutta se oli sinä, joka laitat sen sinne, Joten sinun ei pitäisi ilmoittaa tätä virhettä meille (ellet ole vahvistanut, että ASF on väärässä ja rakenne on itse asiassa täysin oikea).

Yhdessä TL;DR-virkkeessä - raportti virheitä, älä ilmoita varoituksista. Voit edelleen kysyä varoituksia ja saada apua meidän tukiosiossa.

---

### ASF ei käynnisty, ohjelman ikkuna sulkeutuu välittömästi!

Tavallisissa olosuhteissa mikä tahansa ASF:n kaatuminen tai poistuminen tuottaa `-lokin. xt` ohjelman hakemistossa, jota voit tarkastella ja jota voidaan käyttää sen syyn löytämiseen. Sen lisäksi muutamia viimeisimpiä lokitiedostoja arkistoidaan myös `lokeissa` hakemistoon, koska päälokilla `on loki. xt` tiedosto on ylikirjoitettu jokaisen ASF suoritettaessa.

Kuitenkin, jos .NET ei pysty käynnistämään konetta, niin `log.txt` ei luoda. Jos näin tapahtuu sinulle, unohdit todennäköisimmin asentaa .NET -ehdot, kuten **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)** -oppaan asettamisessa on todettu. Muita yleisiä ongelmia ovat yrittää käynnistää väärä ASF variantti käyttöjärjestelmässäsi, tai muulla tavalla puuttuu natiivi .NET runtime riippuvuuksia. Jos konsoli-ikkuna sulkeutuu liian pian lukeaksesi viestin, avaa sitten itsenäinen konsoli ja käynnistä sieltä ASF binääri. Esimerkiksi Windowsissa, avaa ASF-hakemisto, pidä `Shift`pohjassa hiiren oikealla painikkeella kansion sisällä ja valitse "*Avaa komennot tässä*" (tai *powershell*), sitten kirjoita konsoliin `. ArchiSteamFarm.exe` ja vahvista enter. Näin saat tarkan viestin siitä, miksi ASF ei aloita kunnolla.

Jos ei ole tulosta, ja olet Windowsissa, Tavallinen syy tähän ei ole kaikkia saatavilla olevia Windows-päivityksiä asennettuna - varmista, että käytät ajan tasalla olevaa käyttöjärjestelmää, koska emme tue ASF:n käyttöä Windowsissa täyttämättä ehtoa kummallakaan tavalla.

---

### ASF potkii Steam-asiakasistuntoani samalla kun pelän! / *Tämä tili on kirjautunut toiselle PC*

Tämä näkyy viestinä Steamin päällyksessä, että tiliä käytetään jonnekin muualle, kun pelaat. Tällä asialla voi olla kaksi eri syytä.

Yksi syy on rikkoutuneet paketit (pelit), jotka eivät erityisesti pidä pelaaminen lukko kunnolla, kuitenkin odottaa, että lukko on hallussaan asiakkaan toimesta. Esimerkkinä tällaisesta paketista olisi Skyrim SE. Steam-asiakkaasi käynnistää pelin kunnolla, mutta sitä peliä ei rekisteröidä käytettäväksi. Sen vuoksi, ASF näkee että se voi vapaasti jatkaa prosessia, mitä se tekee, ja tämä potkii sinut pois Steam-verkosta, kun Steam yhtäkkiä havaitsee että tiliä käytetään toisessa paikassa.

Toinen syy voisi tulla esiin, jos pelaat tietokoneella, kun taas ASF odottaa (erityisesti toisella koneella) ja menetät verkkoyhteyden. Tässä tapauksessa Steam-verkko merkitsee sinut offline-tilaksi ja vapauttaa pelaamisen lukon (kuten yllä), joka laukaisee ASF:n (esim. toisella koneella) viljelyn jatkamiseen. Kun tietokoneesi tulee takaisin verkossa, Steam ei voi enää hankkia pelaamista lukko (joka on nyt ASF, samanlainen kuin edellä) ja näyttää saman viestin.

Molemmat syyt ASF puolella ovat itse asiassa hyvin vaikea huolestua, ASF yksinkertaisesti jatkaa maanviljelyä, kun Steam-verkko ilmoittaa sille että tiliä voidaan käyttää uudelleen. Tämä on mitä tapahtuu normaalisti, kun suljet pelin, mutta rikki paketteja tämä voi tapahtua heti, vaikka peli on vielä käynnissä. ASF:llä ei ole mitään keinoa tietää, oletko yhteydessäsi, lopetti pelin pelaamisen tai että olet vielä pelaamassa peliä, joka ei pidä pelaamista lukitus asianmukaisesti.

Ainoa oikea ratkaisu tähän ongelmaan on pysäyttää botti manuaalisesti `tauko` ennen kuin aloitat pelaamisen. ja jatkaen sitä `kanssa jatkaen` kun olet valmis. Vaihtoehtoisesti voit vain ohittaa ongelman ja toimia samalla tavalla kuin pelaat offline Steam-asiakkaan kanssa.

---

### `Yhteys Steamiin!` - En voi luoda yhteyttä Steam-palvelimille.

ASF voi vain **yrittää** luoda yhteyden Steam-palvelimille, ja se voi epäonnistua monista syistä, kuten internetyhteyden puuttuminen, Höyry on alhaalla, palomuurin esto yhteys, kolmannen osapuolen työkalut, väärin määritetyt reitit tai väliaikaisia vikoja. Voit ottaa käyttöön `Debug` -tilan tarkistaaksesi enemmän verbose log -lokia, josta ilmenee virheiden täsmälliset syyt. vaikka yleensä se johtuu yksinkertaisesti oman toiminnan, kuten käyttämällä "CS:GO MM Server Picker", joka mustat listaa paljon Steam-IP-osoitteita, joten sinun on hyvin vaikea päästä Steam-verkkoon.

ASF tekee parhaansa yhteyden luomiseksi, joka sisältää paitsi kysyä päivitetyn luettelon palvelimia, mutta myös yrittää toisen IP-kun viimeinen epäonnistuu, joten jos se on todella väliaikainen ongelma jonkin tietyn palvelimen tai reitin, ASF yhdistää ennemmin tai myöhemmin. Kuitenkin, jos olet palomuurin takana tai jollakin muulla tavalla ei pääse Steam-palvelimille, sitten ilmeisesti sinun täytyy korjata se itse, mahdollisesti `Debug` -tilassa.

On myös mahdollista, että koneesi ei pysty luomaan yhteyttä Steam-palvelimiin käyttäen oletusprotokollaa ASF. Voit muuttaa protokollia, joita ASF voi käyttää muuttamalla `SteamProtocols` -konfiguraatioominaisuutta. Esimerkiksi, jos sinulla on ongelmia päästä Steamiin `UDP` -protokollan avulla (esim. palomuurien vuoksi), ehkä sinulla on enemmän onnea `TCP` tai `WebSocket` kanssa.

On hyvin epätodennäköistä, että virheellisiä palvelimia välimuistiin, esimerkiksi siirtämällä ASF `config` -kansion koneesta toiseen koneeseen, joka sijaitsee täysin eri maassa, Poistetaan `ASF. b` Steam-palvelinten päivittämiseksi seuraavan käynnistyksen yhteydessä voi olla apua. Hyvin usein sitä ei tarvita eikä sitä tarvitse tehdä, koska kyseinen lista päivitetään automaattisesti ensimmäisen käynnistyksen yhteydessä, sekä kun yhteys on muodostettu - me vain mainita sen keinona puhdistaa mitään liittyvät luetteloon Steam-palvelimia välimuistissa ASF.

---

### `Ei voitu kirjautua Steamiin: TryAnotherCM/Invalid`, `ServiceEi saatavilla / virheellinen`

Kuten edellä, mutta tällä kertaa palvelin, johon olet yhdistänyt, ei ole nimenomaisesti saatavilla. Yleensä tapahtuu Steamin huoltoikkunan aikana, ei ole mitään tekemistä, ASF yrittää automaattisesti uudelleen toisella palvelimella, kunnes se hyväksyy pyynnön. Se ei saa kestää pidempään kuin tunti enintään.

---

### `Merkkejä ei voitu saada, yritä myöhemmin uudelleen!`

Yleensä se tarkoittaa, että käytät Steam vanhempien PIN-koodia päästäksesi tiliisi, mutta unohdit laittaa sen ASF asetukseen. Sinun täytyy asettaa kelvollinen PIN `SteamParentalCode` bot config ominaisuus, muuten ASF ei voi käyttää suurinta osaa verkkosisältöä, joten se ei voi toimia kunnolla. Head over to **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** in order to learn more about `SteamParentalCode`.

Muita syitä ovat väliaikainen Steam-ongelma, verkkoongelma tai vastaava. Jos ongelma ei ratkaise itseään useita tunteja ja olet varma, että olet määrittänyt ASF oikein, voit kertoa meille siitä.

---

### ASF ei onnistunut `Pyyntö epäonnistui viiden yrityksen` virheen jälkeen!

Yleensä se tarkoittaa, että käytät Steam vanhempien PIN-koodia päästäksesi tiliisi, mutta unohdit laittaa sen ASF asetukseen. Sinun täytyy asettaa kelvollinen PIN `SteamParentalCode` bot config ominaisuus, muuten ASF ei voi käyttää suurinta osaa verkkosisältöä, joten se ei voi toimia kunnolla. Head over to **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** in order to learn more about `SteamParentalCode`.

Jos vanhempien PIN ei ole syy, niin tämä on yleisin virhe, ja sinun pitäisi tottua siihen, se tarkoittaa yksinkertaisesti sitä, että ASF lähetti pyynnön Steam-verkostoon, eikä saanut voimassa olevaa vastausta, viisi kertaa peräkkäin. Yleensä se tarkoittaa, että Steam on joko alas tai on joitakin vaikeuksia tai ylläpitoon - ASF on tietoinen tällaisista asioista ja sinun ei pitäisi huolehtia niistä, ellei niitä tapahdu jatkuvasti pidempään kuin useita tunteja, ja muilla käyttäjillä ei ole tällaisia ongelmia.

Miten tarkistaa, onko Steam alhaalla? **[Steam-tila](https://steamstat.us)** on erinomainen tarkistamisen lähde, jos Steam **pitäisi olla** ylös, jos havaitset virheitä, jotka liittyvät erityisesti yhteisön tai Web APIin, Steam on vaikeuksissa. Saatat haluta jättää ASF yksin ja antaa sen tehdä työnsä jälkeen lyhyen aikaa seisokkeja, tai lopettaa sen ja odottaa itseäsi.

Näin ei kuitenkaan aina ole, sillä joissakin tilanteissa Steam-tila ei välttämättä havaitse Steam-ongelmia, Esimerkiksi tällainen tapaus tapahtui, kun Valve rikkoi HTTPS-tukea Steam-yhteisölle 7. kesäkuuta 2016 - pääsy **[SteamCommunity](https://steamcommunity.com)** HTTPS-järjestelmän kautta heitti virheen. Älä siis luota sokeasti Steam-tilaan, joten on parasta tarkistaa itseäsi, jos kaikki toimii niin kuin pitäisi.

Sen lisäksi, että Steam sisältää erilaisia korkoja rajoittavia toimenpiteitä, jotka tilapäisesti kieltää IP jos teet liikaa pyyntöjä kerralla. ASF on tietoinen siitä, että ja tarjoaa useita eri rajoittimia config, jota sinun pitäisi käyttää. Oletusasetukset olivat tweaked perustuen **sane** määrä botteja, jos käytät niin valtavaa määrää, että jopa Steam käskee sinua menemään, sitten joko nipistää ne kunnes se ei enää kerro sinulle, tai teet kuten sinulle kerrotaan. Oletan, että toinen tapa ei ole teille vaihtoehto, niin mene lukea tästä aiheesta ja kiinnittää erityistä huomiota `WebLimiterDelay` , joka on yleinen rajoitin, joka koskee kaikkia web-pyyntöjä.

Ei ole olemassa "kultaista sääntöä", joka toimii kaikille, koska kuutioihin vaikuttavat voimakkaasti kolmannen osapuolen tekijät, siksi sinun täytyy kokeilla itseäsi ja löytää arvo, joka toimii sinulle. Voit myös sivuuttaa sen, mitä sanon, ja käyttää jotain sellaista kuin `10000` , joka on taattu toimimaan oikein, mutta sitten älä valita, miten ASF reagoi kaiken 10 sekunnissa ja miten kunniamerkki jäsennys kestää 5 minuuttia. In addition to that, it's entirely possible that no limiter will do anything because you have so huge amount of bots that you're hitting **[hard limit](#how-many-bots-can-i-run-with-asf)** that was mentioned above. Kyllä, on täysin mahdollista, että voit kirjautua sisään ilman ongelmia Steam-verkkoon (asiakas), mutta Steam web (sivusto) kieltäytyy kuuntelemasta sinua, jos sinulla on 100 istuntoa perustettu kerralla. ASF vaatii sekä Steam-verkostoa että Steam-verkkoa toimimaan yhteistyössä, vain yksi alas saadaksesi ongelmat, joita et saa takaisin.

Jos mitään auttaa ja sinulla ei ole aavistustakaan, mikä on rikki, voit aina ottaa käyttöön `Debug` -tilan ja nähdä itsesi ASF lokissa, miksi pyynnöt epäonnistuvat. Esimerkiksi:

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Kielletty <- HEAD https://steamcommunity.com/my/edit/settings
```

Katso, että `kielletty` koodi? Tämä tarkoittaa, että olet tilapäisesti kielletty liikaa pyyntöjä, koska et tallentanut `WebLimiterDelay` oikein vielä (olettaen, että saat saman virhekoodin myös kaikille muille pyynnöille). Siellä voi olla muita syitä, kuten `InternalServerError`, `ServiceEi saatavilla` ja aikakatkaisut, jotka viittaavat Steam-ylläpitoon/ongelmiin. Voit aina kokeilla ASF:n mainitsemaa linkkiä ja tarkistaa, toimiiko se - jos se ei ole, sitten tiedät miksi ASF ei pääse siihen käsiksi. Jos niin käy, ja sama virhe ei mene pois päivän tai kahden jälkeen, se voi olla tutkimisen ja raportoinnin arvoinen.

Ennen kuin teet että sinun pitäisi **varmista, että virhe kannattaa raportoida ensisijaisesti**. Jos se mainitaan tässä FAQ, kuten kaupankäyntiin liittyvä kysymys, niin se on pois. Jos se on väliaikainen ongelma, joka tapahtui kerran tai kahdesti, varsinkin kun verkko oli epävakaa tai Steam oli alas - se on pois. Jos kuitenkin pystyit jäljentämään ongelmasi useita kertoja peräkkäin, kahden päivän ajan, käynnistettiin uudelleen ASF sekä koneen prosessissa ja varmisti, että ei ole FAQ merkintä täällä auttaa ratkaisemaan sitä, sitten tämä voi olla syytä kysyä.

---

### ASF näyttää jäätyvän eikä tulostaa mitään konsoliin ennen kuin painan avainta!

Käytät todennäköisesti Windowsia ja konsolissasi on QuickEdit -tila käytössä. Katso tekninen selitys **[tämä](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** kysymys StackOverflowista. QuickEdit tila pitäisi poistaa käytöstä napsauttamalla ASF konsoli ikkunaa, avaamalla ominaisuuksia ja poistamalla oikean valintaruudun.

---

### ASF ei voi hyväksyä tai lähettää kauppoja!

Ilmeinen asia ensin - uudet tilit alkavat rajallisina. Ennen kuin avaat tilin lataamalla lompakkonsa tai käyttämällä 5 dollaria kaupassa, ASF ei voi hyväksyä sitä, että se ei lähetä kauppoja käyttämällä tätä tiliä. Tässä tapauksessa ASF toteaa, että tavaraluettelo vaikuttaa tyhjältä, koska jokainen siinä oleva kortti ei ole vaihdettavissa.

Seuraavaksi jos et käytä **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, on mahdollista, että ASF itse asiassa hyväksytään/lähetetty kauppa, mutta sinun täytyy vahvistaa se sähköpostitse. Vastaavasti, jos käytät klassinen 2FA, sinun täytyy vahvistaa kaupan kautta todentaja. Vahvistukset ovat nyt **pakollisia** , joten jos et halua hyväksyä niitä itse, harkitse tunnistautumisen tuomista ASF 2FA:han.

Huomaa myös, että voit käydä kauppaa vain ystäviesi kanssa, ja ihmiset, joilla on tunnettu kauppalinkki. Jos yrität aloittaa *Bot -> Master* kaupan, kuten `ryöstää`, sitten sinun täytyy joko botti ystävällesi, tai `SteamTradeToken` on ilmoitettu Botin konfiguroinnissa. Varmista, että tunnus on voimassa - muuten et voi lähettää kauppaa.

Muista myös, että uudet laitteet ovat 7 päivän kaupan lukko, joten jos olet juuri lisännyt tilisi ASF, odota vähintään 7 päivää - kaiken pitäisi toimia sen jälkeen. Tämä rajoitus sisältää **sekä** jotka hyväksyvät **ja** kaupat. Se ei aina laukaise, ja on ihmisiä, jotka voivat lähettää ja hyväksyä kauppoja välittömästi. Vaikuttaa kuitenkin suurin osa ihmisistä, ja lukko **tulee** tapahtumaan, vaikka voit lähettää ja hyväksyä kauppoja kautta höyry asiakkaan samassa koneessa. Odota vain kärsivällisesti, ei ole mitään voit tehdä tehdä sen nopeammin. Samoin, voit saada samanlainen lukitus poistaa / muuttaa erilaisia Steam-turvallisuuteen liittyviä asetuksia, kuten 2FA, SteamGuard, salasana, sähköposti ja samoin. Yleensä tarkista, että voit lähettää kaupan että tili itse, jos kyllä, hyvin todennäköisesti se on klassinen 7 päivää lukita uusi laite.

Ja lopuksi, pitää mielessä, että yksi tili voi olla vain 5 odottamassa kauppoja toiseen, niin ASF ei lähetä kauppoja, jos sinulla on 5 (tai enemmän) odottamassa niitä että yksi botti hyväksyä jo. Tämä on harvoin ongelma, mutta se on myös syytä mainita, varsinkin jos asetat ASF automaattisesti lähettää kaupat, silti et käytä ASF 2FA:ta ja unohdit itse vahvistaa ne.

Jos mitään ei autettu, voit aina ottaa käyttöön `Debug` -tilan ja tarkistaa itse, miksi pyynnöt epäonnistuvat. Huomaa, että Steam puhuu roskaa suurimman osan ajasta, ja jos syy ei ehkä ole looginen järke, tai voi olla jopa täysin virheellinen - jos päätät tulkita tuota syytä, varmista, että sinulla on kunnollista tietoa Steamistä ja sen ovelista. On myös melko tavallista nähdä, että ongelma ilman loogista syytä, ja ainoa ehdotettu ratkaisu tässä tapauksessa on lisätä tilin uudelleen ASF (ja odottaa 7 päivää uudelleen). Joskus tämä ongelma korjaa myös itsensä *maagisesti*, samalla tavalla kuin se hajoaa. Kuitenkin, yleensä se on vain joko 7-päivän kaupan lukko, väliaikainen höyry ongelma, tai molemmat. Se on parasta antaa muutaman päivän ennen manuaalisesti tarkistaa, mikä on vialla, ellet ole joitakin halu debug todellinen syy (ja yleensä sinun on pakko odottaa muutenkin, koska virheviesti ei ole järkevä, eikä auta sinua pienimmässä).

Joka tapauksessa ASF voi vain **yrittää** lähettää asianmukaisen pyynnön Steamiin hyväksyä/lähettääksesi kaupan. Riippumatta siitä, hyväksyykö Steam tämän pyynnön vai ei, se ei kuulu ASF:n soveltamisalaan, eikä ASF tee sitä taianomaisesti. Tähän ominaisuuteen liittyvää bugia ei ole, eikä mitään parannettavaa, koska logiikkaa tapahtuu ASF:n ulkopuolella. Siksi älä pyydä vahvistamisesta tavaraa, joka ei ole rikki, eivätkä myöskään kysy miksi ASF ei voi hyväksyä tai lähettää kauppoja - **En tiedä, ja ASF ei tiedä kumpaakaan**. Joko käsitellä sitä, tai korjata itse, jos tiedät paremmin.

---

### Miksi minun täytyy laittaa 2FA/SteamGuard koodi jokaiseen kirjautumiseen? / *Poistettu vanhentunut kirjautumisavain*

ASF käyttää kirjautumisavaimia (jos pidät `KäytäLoginKeys` käytössä) tietojen pitämiseksi voimassa, Sama mekanismi, jota Steam käyttää - 2FA/SteamGuard token vaaditaan vain kerran. Steam-verkon ongelmien ja ovien vuoksi on kuitenkin täysin mahdollista, että kirjautumisavainta ei tallenneta verkossa, Olemme jo nähneet tällaisia ongelmia paitsi ASF, mutta säännöllinen höyry asiakas sekä (tarve syöttää kirjautuminen + salasana jokaisessa suorituksessa, riippumatta "muista minut" vaihtoehto).

Voit poistaa `BotName.db` ja `pullon. vuonna` (jos saatavilla) vaikuttaa tiliin ja yrittää linkittää ASF tilillesi jälleen, mutta se ei todennäköisesti tee mitään. Jotkut käyttäjät ovat ilmoittaneet, että **[kieltää kaikkien laitteiden](https://store.steampowered.com/twofactor/manage)** Steam-puolella pitäisi auttaa, salasanan vaihtaminen tekee samoin. Ne ovat kuitenkin vain pelottavia, joilla ei ole edes takuuta työskennellä. todellinen ASF-pohjainen ratkaisu on tuoda tunnistautumisesi **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** - näin ASF voi luoda tunnisteita automaattisesti, kun niitä tarvitaan, ja sinun ei tarvitse syöttää niitä manuaalisesti. Yleensä kysymys maagisesti ratkaisee itsensä jonkin ajan kuluttua, joten voit yksinkertaisesti odottaa, että tapahtuu. Tietenkin voit myös pyytää venttiiliä ratkaisuun, koska en voi pakottaa Steam-verkostoa hyväksymään kirjautumisavaimia.

Kuten edellä on mainittu, voit myös kytkeä kirjautumisavaimet pois päältä `UseLoginKeys` config ominaisuus asetettu `false`, mutta tämä ei ratkaise ongelmaa, vain ohita alkuperäinen kirjautumisavain epäonnistui. ASF on jo tietoinen tässä selostetusta ongelmasta ja yrittää parhaansa olla käyttämättä kirjautumisavaimia, jos se voi taata itselleen kaikki kirjautumistunnukset, joten ei tarvitse säätää `UseLoginKeys` manuaalisesti, jos voit antaa kaikki kirjautumistiedot yhdessä ASF 2FA:n kanssa.

---

### Saan virhe: *Ei voitu kirjautua Steamiin: `InvalidPassword` tai `RateLimitExceeded`*

Tämä virhe voi tarkoittaa paljon asioita, jotkut niistä ovat:

- Virheellinen kirjautuminen/salasanayhdistelmä (ilmeisesti)
- Vanhentunut kirjautumisavain, jota ASF käyttää kirjautumiseen
- Liian monta epäonnistunutta kirjautumisyritystä lyhyessä ajassa (anti-bruteforce)
- Liian monta kirjautumisyritystä lyhyessä ajassa (verokannan rajoittaminen)
- Vaatimus captcha kirjautua sisään (erittäin todennäköisesti johtuu kahdesta syystä)
- Mikä tahansa muu syy Steam Network saattaa estää sinua kirjautumasta sisään

Bruteforce ja korko rajoittaminen, ongelma katoaa jonkin ajan kuluttua, joten vain odottaa ja älä yritä kirjautua sisään sillä välin. Jos osut tätä ongelmaa usein, ehkä on viisasta lisätä `LoginLimiterDelay` ASF:n config -ominaisuutta. Excessive ohjelma käynnistyy uudelleen ja muut tarkoitukselliset/ei-tarkoituksellinen kirjautuminen pyynnöt varmasti ei auta ongelman kanssa, joten yritä välttää se jos mahdollista.

Mikäli kirjautumisavain on vanhentunut - ASF poistaa vanhan ja pyytää uuden kirjautumisen yhteydessä (jota tarvitset laittamalla 2FA tunnuksen, jos tilisi on 2FA-suojattu. Jos tilisi käyttää ASF 2FA, tunnus luodaan ja käytetään automaattisesti). Tämä voi luonnollisesti tapahtua ajan mittaan, mutta jos saat tämän ongelman jokaisesta kirjautumisesta, on mahdollista, että Steam jostain syystä päätti jättää huomiotta meidän kirjautumisavain tallentaa pyyntöjä, kuten edellä</a></strong> kohdassa **

mainitaan. Voit tietenkin poistaa `UseLoginKeys` kokonaan käytöstä, mutta se ei ratkaise ongelmaa, vain välttää tarvetta poistaa vanhentunut kirjautumisavaimet joka kerta. Todellinen ratkaisu, kuten edellä on esitetty, on ASF 2FA:n käyttö.</p> 

Ja lopuksi, jos käytät väärää kirjautuminen + salasanan yhdistelmä, sinun täytyy tietenkin korjata tämä, tai poista käytöstä botti, joka yrittää yhdistää näitä tunnuksia. ASF ei voi arvata yksin, tarkoittaako `InvalidPassword` virheellisiä tunnuksia, tai jokin edellä luetelluista syistä, joten se pitää yrittää kunnes se onnistuu.

Pidä mielessä, että ASF on oma sisäänrakennettu järjestelmä reagoida vastaavasti höyryn nokkaus, lopulta se yhdistää ja jatkaa työtään, joten se ei tarvitse tehdä mitään, jos ongelma on väliaikainen. Uudelleenkäynnistäminen ASF jotta maagisesti korjata ongelmia vain pahentaa asioita (koska uusi ASF ei tiedä aiemman ASF tila ei voi kirjautua sisään, ja yrittää yhdistää sen sijaan odottaa), joten välttää tekemästä sitä, ellet tiedä mitä teet.

Lopuksi, kuten jokaisella Steam-pyynnöllä - ASF voi vain **yrittää** kirjautua sisään käyttämällä annettuja tunnistetietoja. Se, onnistuuko tämä pyyntö vai ei, ei ole ASF:n soveltamisala ja logiikka - virheitä ei ole, eikä mitään voida vahvistaa kumpaakaan parannusta tässä suhteessa.



---



### En voi syöttää kirjautumistietoja, joita ASF pyytää


### `System.InvalidationException: Näppäimiä ei voi lukea, kun sovelluksessa ei ole konsolia tai kun konsolin syöte on ohjattu uudelleen`


### `System.IO.IOPoikkeus: Syöttö-/ulostulovirhe`


### `PyyntöInput() syöte on virheellinen!`

Jos tämä virhe tapahtui ASF syötön aikana (esim. näet `GetUserInput()` pinoamisessa ja sen aiheuttajana on ympäristösi, joka estää ASF:ää lukemasta konsolin vakiosyöttöä. Tämä voi tapahtua monista syistä, mutta yleisin on käyttää ASF väärässä ympäristössä (esim. `systemd`, `nohup` tai `&` taustan sijaan e. . `näyttö` Linuxissa). Jos ASF ei pääse käsiksi sen vakiotuloon, näet tämän virheen kirjautuneena ja ASF:n kyvyttömyyden käyttää tietojasi suorituksen aikana.

Normaalisti sinun pitäisi korjata edellä oleva ongelma, eli anna ASF käyttää standardi syöttöä, jotta voit antaa tiedot. Kuitenkin, jos **odottaa** tämän tapahtuvan, joten **aikoo** ajaa ASF käyttökelvottomassa ympäristössä, sitten sinun pitäisi nimenomaisesti kertoa ASF että se on, asettamalla **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** -tila asianmukaisesti. Tämä kertoo ASF:lle, että se ei koskaan pyydä käyttäjäpalautetta missään olosuhteissa, jolloin voit käyttää ASF:ää käyttökelvottomissa ympäristöissä. Voit vastata valittuihin syöttökehotuksiin muilla tämän tilan keinoilla, esim. ASF-uissa.



---



### `System.Net.Http.WinHttpException: A security error occurred`

Tämä virhe tapahtuu, kun ASF ei pysty määrittämään suojattua yhteyttä annettuun palvelimeen lähes yksinomaan SSL-varmenteen epäluottamuksen vuoksi.

Lähes kaikissa tapauksissa tämä virhe johtuu **väärästä päivämäärästä/ajasta koneessasi**. Jokainen SSL-todistus on antanut päivämäärän ja viimeisen voimassaolopäivän. Jos päivämääräsi on virheellinen ja näiden kahden rajan ulkopuolella, varmenteeseen ei voi luottaa, koska mahdollinen **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)** -hyökkäys ja ASF kieltäytyy muodostamasta yhteyttä.

Ilmeinen ratkaisu on asettaa päivämäärä koneellesi asianmukaisesti. On erittäin suositeltavaa käyttää automaattista päivämäärän synkronointia, kuten natiivia synkronointia Windowsissa, tai `ntpd` Linuxissa.

Jos olet varmistanut, että päivämäärä koneessa on sopiva ja virhe ei halua poistua, SSL-varmenteet, joihin järjestelmäsi luottaa voi olla vanhentunut tai virheellinen. Tässä tapauksessa sinun pitäisi varmistaa, että koneesi pystyy luomaan turvallisia yhteyksiä esimerkiksi tarkistamalla, voiko sinulla käyttää `https://githubia. om` millä tahansa selaimella valintasi tai CLI-työkalulla, kuten `curl`. Jos vahvistitte, että tämä toimii asianmukaisesti, voitte vapaasti pyytää meiltä tukea.



---



### `System.Threading.Tasks.TehtäväPeruutettuPoikkeus: Tehtävä peruutettiin`

Tämä varoitus tarkoittaa, että Steam ei vastannut ASF:n pyyntöön annetussa ajassa. Yleensä se johtuu Steamin verkostoituminen hikka ja ei vaikuta ASF millään tavalla. Muissa tapauksissa se on sama kuin pyyntö epäonnistuu jälkeen 5 yritystä. Tämän ongelman raportointi ei ole järkevää suurimman osan ajasta, koska emme voi pakottaa Steamiä vastaamaan pyyntöihimme.



---



### `Tyyppi initiaattori 'System.Security.Cryptography.CngKeyLite' heitti poikkeuksen`

Tämä ongelma johtuu lähes yksinomaan käytöstä poistettu/pysäytetty `CNG Key Isolation` Windows-palvelu. joka tarjoaa keskeisen salaustoiminnon ASF:lle, jota ilman ohjelma ei pysty suorittamaan. Voit korjata tämän ongelman käynnistämällä `palveluita. sc` ja sen varmistaminen, että `CNG Key Isolation` Windows-palvelu ei ole pois päältä käynnistys ja on parhaillaan käynnissä.



---



### Anti-Virus havaitsee ASF:n haittaohjelmistona! Mitä on meneillään?

**Varmista, että latasit ASF luotetusta lähteestä**. Ainoa virallinen ja luotettu lähde on **[ASF julkaisut](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** sivu GitHubissa (ja tämä on myös ASF automaattisten päivitysten lähde) - **mikä tahansa muu lähde ei ole luotettava ja voi sisältää muiden ihmisten** lisäämiä haittaohjelmia - sinun ei pitäisi luottaa mihinkään muuhun latauspaikkaan, varmista, että ASF tulee aina meiltä.

Jos vahvistit, että ASF on ladattu luotetusta lähteestä, niin hyvin todennäköisesti se on yksinkertaisesti väärä positiivinen. Tämä **tapahtui aiemmin**, **tapahtuu juuri nyt**, ja **tapahtuu tulevaisuudessa**. Jos olet huolissasi todellisesta turvallisuudesta ASF:ää käytettäessä, ehdotan ASF:n skannaamista monilla erilaisilla AV:illä todelliselle tunnistussuhteelle, esimerkiksi **[VirusTotal](https://www.virustotal.com)** -palvelun kautta (tai minkä tahansa muun valitsemasi verkkopalvelun kautta näin).

Jos AV että käytät väärin tunnistaa ASF haittaohjelmana, sitten **on hyvä idea lähettää tämä tiedosto näyte takaisin kehittäjille AV, jotta he voivat analysoida sitä ja parantaa niiden havaitseminen moottori**, niin selvästi se ei toimi niin hyvä kuin luulet sen tekevän. ASF-koodissa ei ole ongelmia, eikä meille ole myöskään mitään korjattavaa, koska emme ole levittämässä haittaohjelmia ensiksi, Siksi ei ole mitään järkeä ilmoittaa meille näistä valheellisista myönteisistä asioista. Suosittelemme lähettämään ASF-näytteen edellä mainittuun tapaiseen jatkoanalyysiin, mutta jos et halua vaivautua sen kanssa, sitten voit aina lisätä ASF jonkinlaisiin AV poikkeuksia, poistaa AV tai yksinkertaisesti käyttää toista. Valitettavasti olemme tottuneet AVS on tyhmä, koska joka kerta jonkin aikaa AV tunnistaa ASF viruksena, joka yleensä kestää hyvin lyhyt ja on paikallaan ylös nopeasti devs, mutta kuten me huomautimme edellä - **se tapahtui**, **tapahtuu** ja **tapahtuu** koko ajan. ASF ei sisällä mitään ilkivaltaista koodia, voit tarkistaa ASF-koodin ja jopa koota lähteestä itse. Emme ole hakkereita hämärtää ASF koodi piilottaa AV heuristics ja vääriä positiivisia, niin älä odota meiltä korjata, mitä ei ole rikki - ei ole "virus" meille korjata.