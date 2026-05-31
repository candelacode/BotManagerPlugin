# Docker

ASF on saatavana **[telakkaläiliönä](https://www.docker.com/what-container)**. Lääkärin paketit ovat tällä hetkellä saatavilla **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** sekä **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

On tärkeää huomata, että ASF:n käyttö Docker-kontissa katsotaan **edistyneeksi asetukseksi**, joka on **ei tarvita** suurimmalle osalle käyttäjiä ja tyypillisesti antaa **ei etuja** yli konttittoman asennuksen. Jos pidät Dockeria ratkaisuna ASF:n käyttämiseen palveluna esimerkiksi siten, että se alkaa automaattisesti käyttöjärjestelmälläsi, sitten kannattaa harkita **[hallinnan](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** osion lukemista ja luoda oikea `järjestelmä` palvelu, joka on **lähes aina** parempi idea kuin käyttää ASF Docker säiliössä.

ASF:n käyttö Docker-kontissa sisältää yleensä **useita uusia ongelmia ja ongelmia** , jotka sinun on kohdattava ja ratkaistava itse. Siksi me **vahvasti** suosittelemme, että vältät sen, ellei sinulla jo ole Docker-tietoa ja et tarvitse auttaa sisäistensä ymmärtämiseen, josta emme kehitä tässä ASF wiki. Tämä osio on enimmäkseen pätevä käyttöön tapauksissa, joissa kokoonpano on hyvin monimutkainen, Esimerkiksi edistyneen verkottumisen tai tavanomaista hiekkalaatikkoa pidemmälle menevän turvallisuuden osalta, jota ASF tarjoaa `-järjestelmän` palveluun (joka takaa jo nyt ylivoimaisen prosessin eristämisen erittäin kehittyneiden turvamekaniikan kautta). Niille kourallinen määrä ihmisiä, täällä selitämme parempia ASF käsitteet koskien sen Docker yhteensopivuus, ja vain se, olet oletettu riittävän Docker tietoa itse, jos päätät käyttää sitä yhdessä ASF.

---

## Tunnisteet

ASF on saatavilla useiden **[-tagien](https://hub.docker.com/r/justarchi/archisteamfarm/tags)** kautta:


### `pääasiallinen`

Yleinen rakenne ASF joka on rakennettu viimeisimmästä sitoumus `päähaara` joka toimii samoin kuin tartu viimeisin artifakti suoraan meidän **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** putkisto. Se on korkein taso bugged ohjelmisto omistettu kehittäjille ja edistyneille käyttäjille kehitystarkoituksiin. Kuvaa päivitetään jokaisen toimituksen yhteydessä `:n päähaarassa` GitHub siksi voit odottaa hyvin usein muutoksia (ja tavaraa on rikki). Se on täällä merkitä nykytilaa ASF projektin, jonka ei välttämättä ole taattu olevan vakaa tai testattu, aivan kuten meidän vapauttamissyklissämme. **Tätä tunnistetta ei saa käyttää missään tuotantoympäristössä**. Hyödyllinen tarkistaa, onko tietty toimitus korjata ongelman kohtaat, odottamatta edes pre-release kanssa commit.


### `julkaistu`

Tavallinen ASF:n rakenne, joka osoittaa aina viimeisimmän **[julkaistun](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF-version, mukaan lukien esijulkaisut. Verrattuna `pää-` -tagiin, kuvaa päivitetään tässä joka kerta, kun uusi GitHub -tagi painetaan. Omistettu edistyneille / virrankäyttäjille, jotka rakastavat elää reunalla mitä voidaan pitää vakaana ja tuoreena samaan aikaan. Käytännössä se toimii samalla tavalla kuin vierintämerkki, joka osoittaa viimeisimmän `A.B.C.D` -julkaisun vetämishetkellä. Huomioithan, että tämän tagin käyttö on yhtä suuri kuin **[esijulkaisut](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `vakaa`

Tavallinen ASF:n rakenne, joka osoittaa aina uusimman **[vakaan](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF-version. Verrattuna `julkaistuun` -tagiin, kuvaa päivitetään tässä heti, kun uusi vakaa versio ASF:stä on saatavilla. Suositellaan ihmisille, jotka etsivät vakaata versiota `julkaistiin` tagi edellä.

### `viimeisin`

OS-specific build of ASF that always osoittaa uusin **[vakaa](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF versio. Verrattuna muihin tämä on **vain tagi** , joka sisältää ASF auto-päivitykset. Tämän tunnisteen tavoitteena on tarjota sane oletus Docker säiliö, joka pystyy juoksemaan itsepäivittyvä, OS-erityinen rakentaa ASF. Tämän vuoksi kuvaa ei tarvitse päivittää niin usein kuin mahdollista, kuten myös ASF versio pystyy aina päivittämään itsensä tarvittaessa.

Tietenkin `UpdatePeriod` voidaan turvallisesti kytkeä pois päältä (asetettu `0`), mutta tässä tapauksessa sinun pitäisi luultavasti käyttää `vakaa` julkaisu sijaan. Samoin voit muokata oletusta `UpdateChannel` seurataksesi ennakkoilmoituksia sen sijaan, jos haluat.

Johtuen siitä, että `uusin` kuva tulee kyky automaattiset päivitykset, se sisältää paljaat OS OS-spesifinen `linux` ASF versio, toisin kuin kaikki muut tunnisteet, jotka sisältävät OS kanssa . ET runtime ja `geneerinen` ASF versio. Tämä johtuu siitä, että uudempi (päivitetty) ASF versio saattaa myös vaatia uudemman ajon kuin yksi kuva voitaisiin mahdollisesti rakentaa, joka muuten edellyttäisi kuvan uudelleenrakentamista tyhjästä, mitätöi suunnitellun käyttö-tapauksen.

### `A.B.C.D`

Yleinen rakenne ASF, joka osoittaa kiinteän ASF versio vastaa tagia. Edellä mainittuihin tageihin verrattuna tämä tagi on täysin jäädytetty, mikä tarkoittaa, että kuvaa ei päivitetä, kun se on julkaistu. Tämä toimii kuten meidän GitHub julkaisuja, joita ei koskaan koskettanut jälkeen ensimmäinen julkaisu, joka takaa sinulle vakaa ja jäädytetty ympäristö. Tyypillisesti sinun pitäisi käyttää tätä tagia, kun haluat käyttää joitakin erityisiä ASF julkaisu ja odottaa deterministinen tulos rakennuksen (e. . hallinta ASF versiot itse sijaan).

---

## Mikä tag on paras minulle?

Se riippuu siitä, mitä etsit. Suurimmalle osalle käyttäjistä `uusinta` -tunnusta pitäisi olla paras, koska se tarjoaa tarkalleen mitä työpöydän ASF tekee, aivan erityinen Docker kontti palveluna . Kuitenkin, tämä ei välttämättä ole miten telakka pitäisi käyttää - normaalisti sinun odotetaan rakentaa kontit eikä ajaa niitä ikuisesti, ja tässä tapauksessa kannattaa harkita `vakaa` tai `julkaistu` merkki, joka seuraa Docker ohjeita. Lopuksi, jos haluat käyttää kiinteää ASF versiota, niin luonnollisesti `A.B.C.D` julkaisut ovat mitä etsit.

Olemme yleensä lannistaa kokeilemaan `main` rakentaa, koska ne ovat täällä meille merkitä nykytilaa ASF projekti. Mikään ei takaa, että tällainen valtio toimii asianmukaisesti, mutta tietysti olet enemmän kuin tervetullut antamaan heille kokeilla, jos olet kiinnostunut ASF:n kehittämisestä.

---

## Arkkitehtuurit

ASF docker image is currently built on `linux` platform targetting 3 architectures - `x64`, `arm` ja `arm64`. Voit lukea niistä lisää **[yhteensopivuudesta](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** -osiossa.

Tunnisteemme käyttävät usean alustan manifestia mikä tarkoittaa, että työkoneeseesi asennettu Docker valitsee automaattisesti oikean kuvan laiturille, kun vedät kuvaa. Jos sattumalta haluat vetää tietyn alustan kuvan, joka ei vastaa parhaillaan käynnissä olevaa kuvaa, voit tehdä sen `--platform` -kytkimen kautta sopivilla Docker komennoilla, kuten `docker ajaa`. Katso lisätietoja Docker dokumentaatiosta **[image manifest](https://docs.docker.com/registry/spec/manifest-v2-2)**.

---

## Käyttö

Täydelliseen viittaukseen sinun tulee käyttää **[virallista lääkäridokumentaatiota](https://docs.docker.com/engine/reference/commandline/docker)**, me kattaa vain peruskäyttö tässä oppaassa, olet enemmän kuin tervetullut kaivaa syvemmälle.

### Hello ASF!

Ensinnäkin meidän pitäisi tarkistaa, jos meidän telakka toimii jopa oikein, tämä toimii ASF "hello world":

```shell
telakka ajaa -it --name asf --pull always --rm justarchi/archisteamfarm
```

`telakkaajo` luo sinulle uuden ASF telakkakontin ja toimii sen edustalla (`-it`). `--pull aina` varmistaa, että ajantasainen kuva vedetään ensin, ja `--rm` varmistaa, että konttimme tyhjennetään kun se pysäytetään, koska testaamme vain jos kaikki toimii hyvin toistaiseksi.

Jos kaikki päättyi onnistuneesti, vedettyään kaikki kerrokset ja aloitusastia, sinun tulee huomata, että ASF on asianmukaisesti käynnistetty ja ilmoittanut meille, että ei ole määriteltyjä bootteja, mikä on hyvä - vahvistimme, että ASF telakka toimii kunnolla. Hit `CTRL+C` lopettamaan ASF-prosessin ja näin ollen myös kontin.

Jos katsot komentoa lähemmin, huomaat, että emme ilmoittaneet mitään tagia, joka automaattisesti laiminlöi `viimeisimmän` yhden. Jos haluat käyttää muita tunnisteita kuin `viimeisin`, esimerkiksi `julkaistu`, sinun tulee ilmoittaa se nimenomaisesti:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm:released
```

---

## Äänenvoimakkuuden käyttö

Jos käytät ASF telakkalaatikossa ja sinun täytyy tietenkin määrittää ohjelma itse. Voit tehdä sen eri tavoin, mutta suositeltavaa olisi luoda ASF `config` hakemiston paikallinen kone, kiinnitä se sitten yhteisenä äänenvoimakkuutena ASF telakkaastiassa.

Oletamme esimerkiksi, että ASF config-kansiosi on `/home/archi/ASF/config` -hakemistossa. Tämä hakemisto sisältää ytimen `ASF.json` sekä botit, joita haluamme suorittaa. Nyt meidän tarvitsee vain liittää, että hakemisto on jaettu tilavuus meidän telakka kontti, jossa ASF odottaa asetushakemistonsa (`/app/config`).

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Ja se on, nyt ASF telakka säiliö käyttää jaettu hakemistoon paikallisen koneen luku- kirjoitus tilassa, joka on kaikki mitä tarvitset konfigurointiin ASF. Vastaavasti voit yhdistää muita taltioita, joita haluat jakaa ASF:llä, kuten `/app/logs` tai `/app/plugins`.

Tämä on tietenkin vain yksi konkreettinen tapa saavuttaa se, mitä haluamme, mikään ei estä sinua esim. luoda oma `Dockerfile` , joka kopioi config tiedostot `/app/config` hakemistoon sisällä ASF docker kontti. Käsittelemme vain tämän oppaan peruskäyttöä.

### Äänenvoimakkuuden oikeudet

ASF säiliö on oletusarvoisesti alustettu `root` -käyttäjälle, jonka avulla se voi käsitellä sisäisiä käyttöoikeuksia ja sitten lopulta vaihtaa `asf` (UID `1000`) käyttäjä jäljellä olevan osan pääprosessi. Vaikka tämän pitäisi olla tyydyttävä valtaosa käyttäjistä, se vaikuttaa jaettuun tilavuuteen, koska uudet tiedostot ovat yleensä `asf` -käyttäjän omistuksessa, mikä ei ehkä ole haluttu tilanne, jos haluat jonkin muun käyttäjän jaettua äänenvoimakkuutta.

On kaksi tapaa voit muuttaa käyttäjän ASF on käynnissä. Ensimmäinen suositellaan, on ilmoittaa ympäristömuuttujalle `ASF_UID` ja tavoite UID jonka haluat suorittaa alle. Toiseksi, vaihtoehtona on siirtää `--user` **[lippu](https://docs.docker.com/engine/reference/run/#user)**, jota suoraan tukee telakka.

Voit tarkistaa `uid` esimerkiksi `id -u` -komennon ja ilmoittaa sen siten kuin yllä on määritelty. Esimerkiksi, jos kohdekäyttäjälläsi on `uid` / 1001:

```shell
docker run -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm

# Vaihtoehtoisesti, jos ymmärrät
telakan ajon rajoitukset -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Ero `ASF_UID` ja `--user` -lipun välillä on hienoa, mutta tärkeää. `ASF_UID` on ASF tukema mukautettu mekanismi, tässä skenaariossa telakkakontti alkaa edelleen `juuri-`, ja sitten ASF käynnistyskomentosarja käynnistää pääbinäärin `ASF_UID`. Kun käytät `--user` lippua, aloitat koko prosessin, mukaan lukien ASF startup skripti annetun käyttäjän. Ensimmäinen vaihtoehto sallii ASF käynnistyskomentosarjan käsitellä automaattisesti käyttöoikeuksia ja muita asioita sinulle, ratkaista joitakin yhteisiä ongelmia, jotka olet mahdollisesti aiheuttanut, Se esimerkiksi varmistaa, että `/app` ja `/asf` hakemistot ovat `ASF_UID` todella omistuksessa. Toisessa skenaariossa, koska emme ole käynnissä `root`, me emme voi tehdä sitä, ja sinun odotetaan hoitavan kaiken itse etukäteen.

Jos olet päättänyt käyttää `--user` lippua, sinun täytyy vaihtaa kaikkien ASF tiedostojen omistus oletuksena `1000` uudelle mukautetulle käyttäjälle. Voit tehdä niin suorittamalla komennon alla:

```shell
# Suorita vain, jos et käytä ASF_UID
telakkaa exec -u root asf_container_name chown -hR 1001 /app /asf
```

Tämä on tehtävä vain kerran sen jälkeen, kun olet luonut säiliön `telakalla ajaa`, ja vain jos päätät käyttää mukautettua käyttäjää `--user` -telakkalipun kautta. Älä myöskään unohda muuttaa `1001` -argumenttia yläpuolella olevassa komennossa `UID` -parametriin, jonka haluat todella ajaa ASF:ää.

### Tilavuus SELinuux-valmisteella

Jos käytät SELinuxia pakollisessa tilassa käyttöjärjestelmässäsi, joka on oletuksena esimerkiksi RHEL-pohjaisissa levykkeissä, sitten sinun pitäisi liittää äänenvoimakkuus lisätään `:Z` -asetus, joka asettaa SELinux-kontekstin oikeaksi.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull always justarchi/archisteamfarm
```

Näin ASF voi luoda tiedostoja, jotka kohdistetaan äänenvoimakkuuteen telakkalaatikon sisällä.

---

## Useita instansseja synkronointi

ASF sisältää tuen useiden instanssien synkronointiin, kuten **[hallinta](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** -osiossa. Kun käytät ASF:ää telakkalaatikossa voit vaihtoehtoisesti "opt-in" osaksi prosessia, Jos käytät useita kontteja ASF:n kanssa ja haluat, että ne synkronoituvat keskenään.

Oletuksena jokainen telakkisäiliön sisällä kulkeva ASF on valmiustilassa, mikä tarkoittaa, että synkronointia ei tapahdu. Jotta voit ottaa synkronoinnin käyttöön niiden välillä, sinun täytyy sitoa `/tmp/ASF` -polku jokaisessa ASF kontissa, jonka haluat synkronoida. yhdeksi, jaettu polku telakkasi isännässä, luku- kirjoitustilassa. Tämä saavutetaan täsmälleen sama kuin sitova määrä, joka on kuvattu edellä, vain eri reittejä:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/cong --name asf2 --pull always justarchi/archisteamfarm
# Ja niin edelleen, kaikki ASF säiliöt on nyt synkronoitu keskenään
```

Suosittelemme sitomaan ASF: n `/tmp/ASF` hakemiston myös väliaikaiseen `/tmp` hakemistoon kone, mutta tietenkin voit vapaasti valita minkä tahansa muun joka täyttää käyttösi. Jokaisella ASF-säiliöllä, jonka odotetaan olevan synkronoitu, olisi oltava `/tmp/ASF` -hakemistonsa jaettuna muiden samaan synkronointiprosessiin osallistuvien säiliöiden kanssa.

Kuten olet varmaan arvaillut yllä olevasta esimerkistä, on myös mahdollista luoda kaksi tai useampia "synkronointiryhmiä", sitomalla eri tohtorintutkan polut ASF:n `/tmp/ASF`.

Asennus `/tmp/ASF` on täysin valinnainen eikä sitä itse asiassa suositeta, ellet nimenomaisesti halua synkronoida kahta tai useampaa ASF-konttia. Emme suosittele asennusta `/tmp/ASF` yhden kontin käyttöön, koska se ei tuo mitään hyötyä, jos odotat ajaa vain yksi ASF kontti, ja se voi itse asiassa aiheuttaa ongelmia, jotka voitaisiin muuten välttää.

---

## Komentoriviltä syötettävät komennot

ASF sallii sinun siirtää **[komentoriviparametrit](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** telakkalaitteessa ympäristömuuttujien kautta. Sinun tulisi käyttää tiettyjä ympäristömuuttujia tuetuille kytkimille ja `ASF_ARGS` muille. Tämä voidaan saavuttaa `-e` -kytkimellä, joka on lisätty `telakan ajoon`, esimerkiksi:

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull always justarchi/archisteamfarm
```

Tämä läpäisee `--cryptkey` -parametrisi ASF-prosessiin, joka suoritetaan telakka-astiassa ja muissa kaarissa. Tietenkin, jos olet kehittynyt käyttäjä, voit myös muokata `ENTRYPOINT` tai lisätä `CMD` ja läpäistä mukautetut argumentit itse.

Ellet halua tarjota mukautettua salausavainta tai muita edistyneitä vaihtoehtoja, sinun ei yleensä tarvitse sisällyttää mitään erityisiä ympäristömuuttujia, koska meidän telakka säiliöt on jo määritetty ajaa sane odotettu oletusvaihtoehto `--no-restart`, niin , että lippua ei tarvitse erikseen mainita `ASF_ARGS`.

---

## IPC

Olettaen, että et muuttanut oletusarvoa `IPC` **[yleinen asetusominaisuus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, se on jo käytössä. Sinun on kuitenkin tehtävä kaksi muuta asiaa IPC toimimaan Docker säiliössä. Ensinnäkin, sinun täytyy käyttää `IPCPassword` tai muokata oletus `KnownNetworks` mukautetun `IPC. onfig` jotta voit muodostaa yhteyden ulkopuolelta ilman yhden käyttämistä. Ellet tiedä mitä olet tekemässä, käytä vain `IPCPassword`. Toiseksi, sinun täytyy muokata oletuksena kuunteluosoitetta `localhost`, koska telakka ei voi reitittää liikenteen ulkopuolella takaisin rajapintaan. Esimerkkinä asetuksesta, joka kuuntelee kaikkia liitäntöjä, olisi `http://*:1242`. Tietenkin voit myös käyttää rajoittavampia sitovia, kuten vain paikallinen LAN- tai VPN-verkko, mutta sen on oltava reitti, johon pääsee ulkopuolelta - `localhost` ei tee, koska reitti on kokonaan vieraskoneen sisällä.

Yllä olevan tekemiseksi sinun pitäisi käyttää **[mukautettua IPC config](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** kuten alla:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Kun olemme perustaneet IPC ei-loopback-rajapintaan, Meidän on kerrottava telakkalle kartoittamaan ASF:n `1242/tcp` portti joko `-P` tai `-p` kytkimellä.

Tämä komento esimerkiksi altistaisi ASF IPC -käyttöliittymän isäntäkoneelle (vain):

```shell
telakka ajaa -it -p 127.0.0.1:1242:1242 -p [:1]:1242:1242 --name asf --pull always justarchi/archisteamfarm
```

Jos asetat kaiken oikein, `docker run` -komento yllä tekee **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** käyttöliittymän toimii isäntäkoneellasi, vakiona `localhost:1242` reitillä, joka on nyt oikein ohjattu vieraskoneeseesi. On myös mukava huomata, että emme paljasta tätä reittiä eteenpäin, niin yhteys voidaan tehdä vain sisällä telakka isäntä, ja siksi pitää se turvallisena. Tietenkin voit paljastaa reitin pidemmälle, jos tiedät mitä teet ja varmistaa asianmukaiset turvatoimet.

---

### Täydellinen esimerkki

Koko yllä olevan tiedon yhdistäminen, esimerkki täydellisestä asennuksesta näyttäisi tältä:

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull always --restart unless-stopped justarchi/archisteamfarm
```

Tämä olettaa, että käytät yhtä ASF konttia, jossa on kaikki ASF asetustiedostot `/home/archi/ASF/config`. Sinun pitäisi muokata config-polkua sen polun mukaan, joka vastaa konettasi. On myös mahdollista tarjota mukautettuja liitännäisiä ASF, jonka voit laittaa `/home/archi/ASF/plugins`. Tämä asetus on valmis myös valinnaiseen IPC-käyttöön, jos olet päättänyt sisällyttää `IPC: n. onfig` config-hakemistossa, jossa on kuten alla:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Voit saavuttaa saman vaikutuksen kuin `docker run` -komennolla edellä käyttämällä seuraavia `docker compose` config:

```yaml
versio: "3. "
palvelut:
  asf:
    kuva: justarchi/archisteamfarm
    container_name: asf
    uudelleenkäynnistys: ilman pysäytettyä
    porttia:
      - "127. .0.1:1242:1242"
      - "[:1]:1242:1242"
    tilavuudet:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/pluggins
```

Muista asioista kuin jo keskustelimme edellä, olemme lisänneet `--uudelleenkäynnistä keskeytymättömästi` kumpaankin yllä olevaan esimerkkiin, jotta tämä säiliö voidaan käynnistää automaattisesti koneen uudelleenkäynnistyksen jälkeen. Voit poistaa tai muuttaa sen tarpeisiisi sopivaksi.

---

## Pro tips

When you already have your ASF docker container ready, you don't have to use `docker run` every time. Voit helposti pysäyttää tai aloittaa ASF telakka-astian `telakka-asf` ja `telakka-asf`. Muista, että jos et käytä `viimeisintä` -tagia, joka sitten käyttää ajan tasalla olevaa ASF vaatii sinulta `telakka-pysäkin`, `telakka rm` ja `telakka ajaa` uudelleen. Tämä johtuu siitä, että sinun on rakennettava kontti uudelleen tuoreesta ASF telakkakuvasta aina kun haluat käyttää kyseisen kuvan sisältämää ASF versiota. `viimeisimmässä` -tagiin ASF on sisällyttänyt mahdollisuuden päivittää itseään, joten uudelleenrakentaminen kuva ei ole tarpeen käyttää ajan tasalla ASF (mutta se on silti hyvä idea tehdä se ajoittain käyttääkseen tuoretta . ET ajoaikojen riippuvuudet ja taustalla oleva OS, joita saattaa olla tarpeen hyppäämällä läpi suurten ASF versioiden päivitykset).

Kuten edellä on mainittu, ASF muussa kuin `viimeisimmässä` -tunnisteessa ei päivitä itseään automaattisesti. Tämä tarkoittaa, että **sinä** olet vastuussa ajan tasalla olevan `justarchi / archisteamfarm` repo. Tällä on monia etuja, kuten tyypillisesti sovelluksen ei pitäisi koskettaa sen omaa koodia, kun se käynnistetään, mutta ymmärrämme myös mukavuus, joka tulee siitä, että ei tarvitse huolehtia ASF versio lääkärisi säiliössä. Jos vältät hyvistä toimintatavoista ja asianmukaisesta lääkäreiden käytöstä, `julkaistu` tagi on mitä ehdottaisimme sen sijaan `uusin`, mutta jos et voi häiritä sitä ja haluat vain tehdä ASF sekä toimii että päivittää itseään, `viimeisin` tehdään.

Tavallisesti sinun pitäisi ajaa ASF telakka-astiassa, jossa on `Headless: true` globaali asetus. Tämä kertoo selvästi ASF että et ole täällä antaa puuttuvat tiedot, ja sen ei pitäisi pyytää niitä. Tietenkin, alustavaa asennusta varten kannattaa harkita tämän vaihtoehdon jättämistä `false` jotta voit helposti perustaa asioita, mutta pitkällä aikavälillä et yleensä ole kiinnitetty ASF konsoli, Siksi olisi järkevää ilmoittaa siitä ASF:lle ja käyttää tarvittaessa `input` **[komentoa](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** Näin ASF ei tarvitse odottaa äärettömän paljon käyttäjän syöttöä, joka ei tapahdu (ja tuhlata resursseja tehdessään niin). Se mahdollistaa myös sen, että ASF voi toimia ei-interaktiivisessa tilassa kontin sisällä, mikä on ratkaisevan tärkeää esimerkiksi lähettävien signaalien osalta, jotta ASF voi sulavasti sulkea `docker stop asf` -pyynnön.