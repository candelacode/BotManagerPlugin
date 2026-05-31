# Alhaisen muistin asetelma

Tämä on täysin päinvastainen kuin **[korkean suorituskyvyn asetukset](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup)** ja yleensä haluat seurata näitä vinkkejä, jos haluat vähentää ASF:n muistin käyttöä, kokonaissuorituskyvyn alentamisesta aiheutuvat kustannukset.

---

ASF on määritelmän mukaan erittäin kevyt resursseista riippuen jopa 128 MB VPS Linuxilla pystyy käyttämään sitä, vaikka tämä alhainen ei ole suositeltavaa ja voi johtaa erilaisiin kysymyksiin. Kun ASF on kevyt, se ei pelkää pyytää OS enemmän muistia, jos tällaista muistia tarvitaan ASF toimimaan optimaalinen nopeus.

ASF pyrkii sovelluksena olemaan mahdollisimman paljon optimoitu ja tehokas, mikä pitää mielessä myös resurssien käytön toteutuksen aikana. Muistin osalta ASF pitää parempana suorituskykyä muistinkulutuksen kustannuksella, mikä voi johtaa väliaikaiseen "spikes"-muistiin, joka voidaan havaita esim. tilit ottaa 3+ kunniamerkki sivuja, kuten ASF noutaa ja jäsentää ensimmäisen sivun, lukea siitä kokonaismäärä sivuja, käynnistä sitten hae tehtävä jokaiselle ylimääräiselle sivulle, mikä johtaa samanaikaiseen hakuun ja jäljellä olevien sivujen jäsentämiseen. Että "extra" muistin käyttö (verrattuna paljain minimi käyttöön) voi dramaattisesti nopeuttaa suorituskykyä ja yleistä suorituskykyä, kustannukset lisääntynyt muistin käyttö, joka on tarpeen tehdä kaikki nämä asiat rinnakkain. Sama koskee kaikkia muita ASF:n yleisluonteisia tehtäviä, joita voidaan hoitaa rinnakkain, esimerkiksi jäsentämällä aktiivisia kauppatarjouksia ASF voi jäsentää ne kaikki kerralla, koska ne kaikki ovat riippumattomia toisistaan. Päälle, että ASF (C# ajoaika) **ei** palauta käyttämätön muisti takaisin OS välittömästi jälkeenpäin, jonka voit nopeasti huomata muodossa ASF prosessi vain ottaen enemmän ja enemmän muistia, mutta (melkein) ei koskaan anna muistia takaisin OS. Jotkut ihmiset saattavat jo pitää sitä kyseenalaisena, ehkä jopa epäilee muistivuotoa, mutta älä huoli, kaikki tämä on odotettavissa.

ASF on erittäin hyvin optimoitu ja hyödyntää käytettävissä olevia resursseja mahdollisimman paljon. ASF:n korkea muistin käyttö ei tarkoita, että ASF aktiivisesti **käyttää** , että muisti ja **tarvitsee**. Hyvin usein ASF pitää varattua muistia "huoneessa" tulevissa toimissa, koska voimme merkittävästi parantaa suorituskykyä, jos meidän ei tarvitse kysyä OS jokaisen muistipalan, että olemme käyttämässä. Suoritusaika vapauttaa automaattisesti käyttämättömän ASF muistin takaisin käyttöjärjestelmään, kun OS **todella** tarvitsee sitä. **[Käyttämätön muisti on tuhlattu](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. Voit törmätä ongelmiin, kun **tarvitsee** muistia on korkeampi kuin muisti on käytettävissäsi, ei silloin, kun ASF pitää joitakin ylimääräisiä kohdennettuja tarkoituksena nopeuttaa toimintoja, jotka suoritetaan hetken kuluttua. Voit törmätä ongelmiin, kun Linux-ytimen tappaa ASF-prosessia OOM (muistin ulkopuolella), ei kun näet ASF prosessin huippumuistin kuluttajana `htop`.

**[Jätekokoelma](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** prosessi, jota käytetään ASF:ssä, on hyvin monimutkainen mekanismi, tarpeeksi älykäs ottamaan huomioon paitsi ASF itse, mutta myös OS ja muut prosessit. Kun sinulla on paljon vapaata muistia, ASF pyytää mitä tarvitaan suorituskyvyn parantamiseksi. Tämä voi olla jopa 1 Gt (palvelimen GC kanssa). Kun käyttöjärjestelmäsi muisti on lähellä täynnä, ASF vapauttaa automaattisesti osan siitä takaisin käyttöjärjestelmään auttaakseen asioita asettumaan alas, joka voi johtaa yleisesti ASF muistin käyttö jopa 50 MB. Ero 50 Mt ja 1 Gt on valtava, mutta niin on ero pienten 512 MB VPS ja valtava omistettu palvelin 32 GB. Jos ASF voi taata, että tämä muisti tulee käyttökelpoiseksi, ja samalla mikään muu ei vaadi sitä juuri nyt, se pitää sen mieluummin ja optimoi itsensä automaattisesti perustuen rutiineihin, jotka on suoritettu aiemmin. ASF käyttää GC on itseviritys ja saavuttaa parempia tuloksia mitä kauemmin prosessi on käynnissä.

Tämä on myös syy siihen, miksi ASF prosessimuisti vaihtelee asetuksesta asetukseen, ASF tekee parhaansa käyttääkseen käytettävissä olevia resursseja **mahdollisimman tehokkaasti**, eikä kiinteässä tavalla, kuten se tehtiin Windows XP aikoina. Varsinainen (todellinen) muistin käyttö, jota ASF käyttää, voidaan tarkistaa `tilastot` **[komennolla](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**ja on yleensä noin 4 MB vain muutaman botteja, enintään 30 Mt, jos käytät sellaisia asioita kuin **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** ja muita kehittyneitä ominaisuuksia. Pidä mielessä, että `tilastot` -komennon palauttama muisti sisältää myös vapaan muistin, jota ei ole vielä regeneroitu roskakeräilijällä. Kaikki muu on jaettu ajoaika muisti (noin 40-50 MB) ja tilaa suorittaa (vaihteleva). Tämän vuoksi sama ASF voi käyttää jopa 50 Mt VPS-muistia alhaisen muistin ympäristössä. kun käytät työpöydälläsi jopa enintään 1 Gt. ASF on aktiivisesti sopeutunut ympäristöönsä ja yrittää löytää optimaalisen tasapainon, jotta kumpikaan laittaa OS paineen alle, eikä rajoita omaa suorituskykyä kun sinulla on paljon käyttämätöntä muistia, joka voidaan ottaa käyttöön.

---

Tietenkin, on olemassa paljon tapoja, miten voit auttaa kohta ASF oikeaan suuntaan kannalta muisti sinun odottaa käyttävän. Yleensä jos sinun ei tarvitse tehdä sitä, on parasta antaa roskien keräilijän työskennellä rauhassa ja tehdä mitä se katsoo parhaaksi. Mutta tämä ei ole aina mahdollista, esimerkiksi jos Linux-palvelin on myös isännöi useita sivustoja, MySQL tietokanta ja PHP työntekijöitä, niin sinulla ei ole todella varaa ASF kutistuu kun ajaa lähellä OOM, koska se on yleensä liian myöhäistä ja suorituskyvyn heikkeneminen tulee nopeammin. Tämä on yleensä, kun voit olla kiinnostunut edelleen virittää, ja siksi lukea tätä sivua.

Alla olevat ehdotukset on jaettu muutamiin luokkiin, joilla on vaihtelevia vaikeuksia.

---

## ASF asetukset (helppoa)

Alla olevat temppuja **eivät vaikuta suorituskykyyn negatiivisesti** ja voidaan turvallisesti soveltaa kaikkiin asennuksiin.

- Suorita ASF:n **[geneerinen versio](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** jos mahdollista. Generic version ASF käyttää vähemmän muistia, koska se ei sisällä runtime sisällä, ei tule yksittäinen tiedosto, ei tarvitse purkaa itseään juoksemassa, ja siksi se on pienempi ja sillä on vähemmän muistijalanjälkeä. Käyttöjärjestelmäkohtaiset paketit ovat käteviä ja käteviä, mutta ne on myös niputettu kaikki mitä tarvitaan ASF:n käynnistämiseen. joka on jotain voit huolehtia itsestäsi ja käyttää yleistä ASF variantti sijaan.
- Älä koskaan suorita useampaa kuin yhtä ASF-instanssia. ASF on tarkoitettu käsittelemään rajattoman määrän botteja kerralla, ja ellet sido jokaista ASF instanssia eri liitäntä-/IP-osoitteeseen, sinulla pitäisi olla täsmälleen **yksi** ASF prosessi, jossa on useita bootteja (jos tarpeen).
- Käytä `ShutdownOnFarmingFinished` botissa `FarmingPreferences`. Aktiivinen botti vie enemmän resursseja kuin deaktivoitu. Se ei ole merkittävä säästää, koska tilaa botti on vielä säilytettävä, mutta säästät jonkin verran resursseja, erityisesti kaikki verkostoitumiseen liittyvät resurssit, kuten TCP pistorasiat. Voit tarvittaessa aina tuoda esille muita botteja.
- Pidä botit alhaisina. Ei `Käytössä` botti instanssi vie vähemmän resursseja, koska ASF ei vaivaudu aloittamaan sitä. Pidä myös mielessä, että ASF on luoda botti kunkin teidän configs, siksi jos sinun ei tarvitse `käynnistää` annettu botti ja haluat tallentaa ylimääräistä muistia, Voit väliaikaisesti uudelleennimetä `Bot. Poika` esim. `Bot.json.bak` , jotta ei luoda tilaa pois käytöstä poistetulle botille ASF:ssä. This way you won't be able to `start` it without renaming it back, but ASF also won't bother keeping state of this bot in memory, leaving room for other things (very small save, in 99.9% cases you shouldn't bother with it, just keep your bots with `Enabled` of `false`).
- Viritä konfiguraatioitasi. Varsinkin globaalilla ASF configilla on monia muuttujia jotka mukautetaan, esimerkiksi lisäämällä `LoginLimiterDelay` nostat botit hitaammin, joka mahdollistaa jo aloitettu instanssi noutaa merkkejä sillä välin, vastakohtana nostaa jopa teidän botteja nopeammin, joka vie enemmän resursseja, koska enemmän botteja tekee suurta työtä (kuten jäsennys badges) samanaikaisesti. Mitä vähemmän työtä on tehtävä samanaikaisesti - sitä vähemmän muistia on käytetty.

Nämä ovat muutamia asioita, joita voit pitää mielessä käsiteltäessä muistin käyttöä. Näillä asioilla ei kuitenkaan ole mitään "ratkaisevan tärkeää" merkitystä muistin käytössä, koska muistin käyttö tulee enimmäkseen asioita, jotka ASF on käsiteltävä, eikä sisäisiä rakenteita käytetään korttien viljelyyn.

Suurimmat resurssit ovat seuraavat:
- Merkkisivun jäsennys
- Varaston jäsennys

Mikä tarkoittaa, että muisti spike eniten, kun ASF on tekemisissä lukeminen kunniamerkki sivuja, ja kun se käsittelee sen varaston (e. . kaupan lähettäminen tai työskentely STM:n kanssa). Tämä johtuu siitä, että ASF on käsiteltävä todella valtava määrä dataa - muistin käyttö suosikki selain käynnistää nämä kaksi sivua ei ole yhtään vähemmän. Anteeksi, niin se toimii - vähentää määrä merkkisivustojasi, ja pitää määrä tavaraluettelon kohteita alhainen, joka voi varmasti auttaa.

---

## Runtime tuning (advanced)

Alla oleviin temppuihin **liittyy suorituskyvyn heikkenemistä** , ja niitä on käytettävä varoen.

Suositeltu tapa soveltaa näitä asetuksia on `DOTNET_` ympäristöominaisuuksien kautta. Tietenkin voit käyttää myös muita menetelmiä, esim. `runtimeconfig. poika`, mutta joitakin asetuksia on mahdotonta asettaa tällä tavalla, ja tämän päälle ASF korvaa mukautetun `runtimeconfig. poika` yksinään seuraavassa päivityksessä, joten suosittelemme ympäristöominaisuuksia, jotka voit asettaa helposti ennen prosessin käynnistämistä.

.NET ajon avulla voit **[nipistää roskat kerääjä](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** monin tavoin, hienosäätämällä GC-prosessia tehokkaasti sinun tarpeidesi mukaan. Olemme dokumentoineet alla ominaisuuksia, jotka ovat meille erityisen tärkeitä.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Määrittää sallitun GC-kasan käytön prosentteina fyysisen muistin kokonaismäärästä.

ASF prosessin "kova" muistin rajoitus, tämä asetus virittää GC käyttää vain kokonaismuistin osajoukkoa eikä kaikkea sitä. Se voi olla erityisen hyödyllinen eri palvelimen kaltaisissa tilanteissa, joissa voit omistaa kiinteän prosenttiosuuden palvelimen muistia ASF, mutta ei koskaan enempää. On suositeltavaa, että rajoittava muisti ASF käyttää ei maagisesti tehdä kaikki vaaditut muistin varaamista pois, Tämän arvon asettaminen liian alhaiseksi saattaa johtaa siihen, että muistiskenaariot loppuvat, jolloin ASF:n prosessi pakotetaan lopettamaan.

Toisaalta, kun taas tämän arvon asettaminen tarpeeksi korkeaksi on täydellinen tapa varmistaa, että ASF ei käytä koskaan enemmän muistia kuin sinulla on realistisesti varaa, antaa koneellesi jonkin verran hengitystilaa jopa raskaan kuorman alla, mutta silti ohjelman avulla se voi tehdä työnsä mahdollisimman tehokkaasti.

### [`GCConserveMemory`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Määrittää jätekerääjän säilyttämään muistia tavallisempien jätekokoelmien kustannuksella ja mahdollisesti pidemmän tauon ajan.

Arvoa 0–9 voidaan käyttää. Mitä suurempi arvo on, sitä enemmän GC optimoi muistin suorituskyvystä.

### [`GCHighMemPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Määrittää käytetyn muistin määrän, jonka jälkeen GC muuttuu aggressiivisemmaksi.

Tämä asetus määrittää koko käyttöjärjestelmän muistin kynnyksen, joka kerran hyväksyttiin, aiheuttaa GC tulla aggressiivisempi ja yrittää auttaa OS alentaa muistin kuormitus käynnissä intensiivisempi GC prosessi ja johtaa vapauttamalla enemmän vapaata muistia takaisin käyttöjärjestelmään. On hyvä ajatus asettaa tämän ominaisuuden maksimaalinen määrä muistia (prosentteina), jota pidät "kriittisen" koko käyttöjärjestelmän suorituskyvystä. Oletus on 90%, ja yleensä haluat säilyttää sen 80-97%, koska liian alhainen arvo aiheuttaa tarpeetonta aggressiivisuutta GC ja suorituskyvyn heikkeneminen ilman syytä, Vaikka liian korkea arvo laittaa tarpeetonta kuormitusta käyttöjärjestelmässäsi, ottaen huomioon ASF voi vapauttaa joitakin sen muistia auttaa.

### **[`GCLatencyLevel`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Määrittää GC latenssitason, johon haluat optimoida.

Tämä on dokumentoimaton ominaisuus, joka osoittautui poikkeuksellisen hyvin ASF, rajoittamalla GC sukupolvien kokoa ja tämän seurauksena GC puhdistaa ne useammin ja aggressiivisemmin. Oletus (tasapainotettu) latenssitaso on `1`, mutta voit käyttää `0`, joka virittää muistin käyttöön.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> Kun asetetaan, me leikata sitoutuneen tilan aggressiivisemmin varten ephemeral seg. Tätä käytetään useiden palvelinprosessien suorittamiseen, joissa he haluavat pitää mahdollisimman vähän muistia sitoutuneena.

Tämä tarjoaa vähän parannusta, mutta voi tehdä GC vieläkin aggressiivisempaa, kun järjestelmä on alhainen muistissa, erityisesti ASF:ssä, jossa hyödynnetään voimakkaasti ketjupoolin tehtäviä.

---

Voit ottaa valitut ominaisuudet käyttöön asettamalla sopivia ympäristömuuttujia. Esimerkiksi Linuxissa (kuori):

```shell
# Älä unohda virittää niitä, jos aiot käyttää niitä
vienti DOTNET_GCHeapHardLimitPercent=0x4B # 75 % kuin hex
vienti DOTNET_GCHighMemPercent=0x50 # 80 % kuin hex

vienti DOTNET_GCConserveMemory=9
vienti DOTNET_GCLatencyLevel=0
vienti DOTNET_gcTrimCommitOnLowMemory=1

. ArchiSteamFarm # OS-spesifisille rakennuksille
./ArchiSteamFarm.sh # geneerisille rakennuksille
```

Tai Windowsissa (powershell):

```powershell
# Älä unohda virittää niitä, jos aiot käyttää niitä
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75 % hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80 % hex

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

. ArchiSteamFarm.exe # OS-spesifisille rakennuksille
.\ArchiSteamFarm.cmd # Yleisille rakennuksille
```

Varsinkin `GCLatencyLevel` tulee erittäin hyödyllinen, koska vahvistimme, että ajoaika todella optimoi koodin muistia ja siten laskee keskimääräisen muistin käytön merkittävästi, jopa palvelimen GC. Se on yksi parhaista temppuja, joita voit käyttää, jos haluat huomattavasti alentaa ASF muistin käyttöä mutta ei heikentää suorituskykyä liikaa `optimointitila`.

---

## ASF viritys (väli)

Alla oleviin temppuihin **liittyy vakava suorituskyvyn heikkeneminen** , ja niitä on käytettävä varoen.

- Viimeisenä keinona, voit virittää ASF `MinMemoryUsage` `optimointitila` **[globaali asetusominaisuus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**. Lue huolellisesti sen tarkoitus, koska tämä on vakava suorituskyvyn heikkeneminen lähes ilman muistietuja. Tämä on tyypillisesti **viimeinen asia, jonka haluat tehdä**, kauan sen jälkeen, kun käyt läpi **[ajoajan virityksen](#runtime-tuning-advanced)** varmistaaksesi, että sinun on pakko tehdä tämä. Ellemme ole ehdottoman kriittisiä asetuksillesi, emme kannata käyttää `MinMemoryUsage`, jopa muistin rajoittamissa ympäristöissä.

---

## Suositeltu optimointi

- Aloita yksinkertaisista ASF asetukset temppuja, käytä **[yleistä ASF-varianttia](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** ja tarkista, että ehkä käytät ASF:ää väärällä tavalla, kuten käynnistämällä prosessin useita kertoja kaikille botteillesi, tai pitää kaikki ne aktiivisena, jos tarvitset vain yhden tai kaksi käynnistääksesi automaattisesti.
- Jos se ei vielä riitä, ota kaikki edellä luetellut asetukset käyttöön asettamalla sopiva `DOTNET_` ympäristömuuttujat. Erityisesti `GCLatencyLevel` tarjoaa merkittäviä ajoaikojen parannuksia suorituskyvyn pieniin kustannuksiin.
- Jos se ei auttanut, viimeisenä keinona ottaa käyttöön `MinMemoryUsage` `Optimointitila`. Tämä pakottaa ASF:n suorittamaan lähes kaiken synkronisessa asiassa, jotta se toimii paljon hitaammin, mutta ei myöskään tukeutua kiertoradalla tasapainottaa asioita kun se tulee rinnakkainen toteuttaminen.

On fyysisesti mahdotonta vähentää muistia entisestään, ASF on jo voimakkaasti heikentynyt suorituskyvyn kannalta ja olet ehtinyt kaikki mahdollisuutesi, sekä koodiviisas että runtime-viisas. Harkitse ylimääräisen muistin lisäämistä ASF käyttää, jopa 128 MB olisi suuri ero.