# IPC

ASF sisältää oman ainutlaatuisen IPC-käyttöliittymänsä, jota voidaan käyttää jatkovuorovaikutuksessa prosessin kanssa. IPC tarkoittaa **[prosessienvälistä viestintää](https://en.wikipedia.org/wiki/Inter-process_communication)** ja yksinkertaisimmassa määritelmässä tämä on "ASF web-käyttöliittymä", joka perustuu **[Kestrel HTTP -palvelimeen](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel)** , jota voidaan käyttää integrointiin prosessin kanssa, sekä frontend loppukäyttäjälle (ASF-ui), ja backend kolmannen osapuolen integraatiot (ASF API).

IPC:tä voidaan käyttää moniin eri asioihin, riippuen tarpeista ja taidoista. Voit esimerkiksi käyttää sitä ASF:n ja kaikkien bottien tilan noutamiseen, ASF-komentojen lähettämiseen sekä globaalien / bottikonfiittien noutamiseen ja muokkaamiseen. uusien bottien lisääminen, olemassa olevien bottien poistaminen, näppäinten lähettäminen **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** tai ASF:n lokitiedostoon käyttäminen. Kaikki nämä toimet ovat alttiita meidän API, mikä tarkoittaa, että voit koodata omia työkaluja ja skriptejä, jotka pystyvät kommunikoimaan ASF:n kanssa ja vaikuttamaan siihen ajon aikana. Sen lisäksi valikoidut toiminnot (kuten komennot) toteutetaan myös ASF-ui -järjestelmällämme, jonka avulla voit helposti käyttää niitä ystävällisen web-käyttöliittymän kautta.

---

# Käyttö

Ellet poistanut IPC:tä manuaalisesti `IPC` **[yleisen konfigurointiominaisuuden](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, se on oletusarvoisesti käytössä. ASF ilmoittaa IPC käynnistää lokiaan, jota voit käyttää tarkistamaan, onko IPC käyttöliittymä käynnistetty oikein:

```text
INFO - ASF Start() Käynnistetään IPC-palvelinta...
INFO ASF Start() IPC palvelin valmis!
```

ASF:n http-palvelin kuuntelee nyt valittuja päätepisteitä. Jos et toimittanut mukautettua määritystiedostoa IPC:lle, se tulee olemaan `localhost`, molemmat IPv4-pohjainen **[127. .0.1](http://127.0.0.1:1242)** ja IPv6-pohjainen **[[:1]](http://[::1]:1242)** oletusarvolla `1242` portti. Voit käyttää IPC-rajapintaa yllä olevien linkkien läpi, mutta vain samalta koneelta kuin ASF-prosessista.

ASF: n IPC-käyttöliittymä paljastaa kolme eri tapaa käyttää sitä, riippuen suunnitellusta käytöstä.

Alimmalla tasolla on **[ASF API](#asf-api)** joka on IPC-käyttöliittymämme ydin ja mahdollistaa kaiken muun toiminnan. Tämä on mitä haluat käyttää omissa työkaluissa, apuvälineissä ja projekteissa, jotta voit kommunikoida suoraan ASF:n kanssa.

Keskipitkällä pohjalla on meidän **[Swaggerin dokumentaatio](#swagger-documentation)** joka toimii ASF API:lle. Siinä on täydellinen dokumentaatio ASF API ja voit myös käyttää sitä helpommin. Tämä on mitä haluat tarkistaa, jos aiot kirjoittaa työkalu, Hyödykkeet tai muut hankkeet, joiden on tarkoitus kommunikoida ASF:n kanssa API:n kautta.

Korkeimmalla tasolla on **[ASF-ui](#asf-ui)** joka perustuu ASF APIimme ja tarjoaa käyttäjäystävällisen tavan suorittaa erilaisia ASF toimintoja. Tämä on meidän oletuksena IPC käyttöliittymä suunniteltu loppukäyttäjille, ja täydellinen esimerkki siitä, mitä voit rakentaa ASF API. Jos haluat, voit käyttää omia mukautettuja web käyttöliittymiä käyttää ASF tarkentamalla `--path` **[komentoriviargumentti](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** ja käyttämällä mukautettua `www` hakemistoa joka sijaitsee siellä.

---

# ASF-ui

ASF-ui on yhteisöprojekti, jonka tavoitteena on luoda käyttäjäystävällinen graafinen käyttöliittymä loppukäyttäjille. Tämän saavuttamiseksi se toimii etualalla meidän **[ASF API](#asf-api)**, jonka avulla voit tehdä erilaisia toimia helposti. Tämä on oletuksena käyttöliittymä, jonka ASF tulee.

Kuten edellä todettiin, ASF-ui on yhteisöhanke, jota ASF:n ydinkehittäjät eivät ylläpidä. Se seuraa omaa virtaustaan **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** jota tulisi käyttää kaikissa asiaan liittyvissä kysymyksissä, ongelmissa, vikailmoituksissa ja ehdotuksissa.

Voit käyttää ASF-uia ASF-prosessin yleiseen hallintaan. Sen avulla voidaan esimerkiksi hallita botteja, muokata asetuksia, lähettää komentoja ja saavuttaa valittuja muita toimintoja, jotka ovat yleensä saatavilla ASF:n kautta.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

Meidän ASF API on tyypillinen **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** web API, joka perustuu JSON sen ensisijainen tietomuoto. Teemme parhaamme kuvataksemme vastausta tarkasti, käyttämällä molempia HTTP-statuskoodeja (tarvittaessa), sekä vastauksen, voit jäsentää itseäsi, jotta tietää, onko pyyntö onnistunut, ja jos ei, niin miksi.

ASF API-rajapintaamme voi käyttää lähettämällä asianmukaisia pyyntöjä asianmukaisiin `/API` -päätepisteisiin. Voit käyttää näitä API päätepisteitä tehdä omia apukomentosarjoja, työkaluja, käyttöliittymiä ja samankaltaisia. Tämä on juuri sitä, mitä meidän ASF-ui saavuttaa huppu, ja kaikki muut välineet voivat saavuttaa samoin. ASF API on ASF -ryhmän virallisesti tukema ja ylläpitämä.

Täydellinen dokumentaatio saatavilla olevia päätepisteitä, kuvauksia, pyyntöjä, vastauksia, http status koodit ja kaikki muu ottaen huomioon ASF API, Katso meidän **[swagger dokumentaatio](#swagger-documentation)**.

![ASF API](https://github.com/user-attachments/assets/08c3d4ad-ea77-403d-a18a-b75c3d0a3097)


---

# Mukautetut asetukset

IPC käyttöliittymämme tukee ylimääräistä config-tiedostoa, `IPC.config` , joka pitäisi laittaa standardin ASF `config` hakemistoon.

Jos saatavilla, tämä tiedosto määrittää ASF:n Kestrel http -palvelimen edistyneen kokoonpanon yhdessä muun IPC-aiheisen virityksen kanssa. Ellei sinulla ole tiettyä tarvetta, sinulla ei ole mitään syytä käyttää tätä tiedostoa, Koska ASF käyttää jo järkeviä oletuksia tässä tapauksessa.

Konfiguraatiotiedosto perustuu seuraavaan JSON rakenteeseen:

```json
{
    "Kestrel": {
        "Endpoints": {
            "example-http4": {
                "Url": "http://127. .0. :1242"
            },
            "example-http6": {
                "Url": "http://[:1]:1242"
            },
            "example-ċ4": {
                "Url": "https://127. .0.1:1242",
                "Certificate": {
                    "Polku": "/path/to/certificate. fx",
                    "Salasana": "salasanaToPfxFileAbove"
                }
            },
            "example-ċ6": {
                "Url": "https://[:1]:1242",
                "Certificate": {
                    "Polku": "/path/to/certificate. fx",
                    "Salasana": "salasanaToPfxFileAbove"
                }
            }
        },
        "Tiedeverkostot": [
            "10. .0.0/8",
            "172.16.0. /12",
            "192.168.0. /16"
        ],
        "PathBase": "/"
    }
}
```

`päätepisteet` - Tämä on kokoelma päätepisteitä, jokainen päätepiste, jolla on oma ainutlaatuinen nimi (kuten `esimerkki-http4`) ja `Url` ominaisuus, joka määrittää `Protocol://Host:Port` kuunteluosoite. Oletuksena ASF kuuntelee IPv4- ja IPv6-http-osoitteita, mutta olemme lisänneet https-esimerkkejä, joita voit käyttää tarvittaessa. Sinun pitäisi ilmoittaa vain ne päätepisteet, joita tarvitset, olemme sisällyttäneet yllä 4 esimerkkiä, jotta voit muokata niitä.

`Host` hyväksyy joko `localhost`, kiinteä IP-osoite käyttöliittymän jota pitäisi kuunnella (IPv4/IPv6), tai `*` arvo, joka sitoo ASF:n http-palvelinta kaikkiin käytettävissä oleviin rajapintoihin. Käyttämällä muita arvoja, kuten `mydomain.com` tai `192.168.0.` toimii samalla tavalla kuin `*`, IP- suodatus ei ole toteutettu, ole siis erittäin varovainen, kun käytät `Host` -arvoja, jotka mahdollistavat etäkäytön. Näin mahdollistetaan muiden koneiden pääsy ASF:n IPC-rajapintaan, mikä saattaa aiheuttaa turvallisuusriskin. Suosittelemme käyttämään `IPCPassword` (ja mieluiten myös omaa palomuuria) **vähintään** tässä tapauksessa.

`KnownNetworks` - Tämä **valinnainen** -muuttuja määrittää verkkoosoitteet, joita pidämme luotettavina. Oletuksena ASF on määritetty luottamaan loopback-käyttöliittymään (`localhost`, sama laite) **vain**. Tätä ominaisuutta käytetään kahdella tavalla. Ensinnäkin, jos jätät `IPCPassword`, sitten sallimme vain tunnettujen verkkojen koneiden pääsyn ASF:n sovellusrajapintaan, ja kiellämme kaikki muut turvatoimenpiteenä. Toiseksi tämä kiinteistö on ratkaisevan tärkeä ASF:ään pääsyyn liittyvien käänteislähetysten kannalta, kuten ASF kunnioittaa sen otsikot vain, jos reverse-proxy palvelin on peräisin tunnettujen verkkojen sisällä. Otsaajien kunniaaminen on ratkaisevan tärkeää ASF:n synnytystä ehkäisevän mekanismin kannalta, sen sijaan, että se kieltäisi käänteisen valtakirjan käytön ongelmatilanteessa. se kieltää IP-osoitteen, jonka kääntäjä on määrittänyt alkuperäisen viestin lähteenä. Ole erittäin varovainen määrittämiesi verkkojen kanssa koska se mahdollistaa mahdollisen IP-paikannuksen hyökkäyksen ja luvattoman käytön, jos luotettu kone on vaarantunut tai määritetty väärin.

`PathBase` - Tämä on **valinnainen** peruspolku, jota käytetään IPC liitäntä. Oletuksena on `/` eikä sitä pitäisi vaatia muuttamaan suurimmassa osassa käyttötapauksia. Muuttamalla tätä ominaisuutta isännöit koko IPC-käyttöliittymän mukautetulla etuliitteellä, esimerkiksi `http://localhost:1242/MyPrefix` pelkästään `http://localhost:1242` sijaan. Käyttämällä mukautettua `PathBase` voidaan haluta yhdessä käännetyn välityspalvelimen erityisasetusten kanssa, jos haluat välittää vain tietyn URL-osoitteen, esimerkiksi `mydomain. om/ASF` koko `mydomain.com` verkkotunnuksen sijaan. Normaalisti se edellyttäisi sinulta kirjoittaa uudelleenkirjoitus sääntö Web serverille, joka kartoittaisi `mydomain. om/ASF/Api/X` -> `localhost:1242/Api/X`, mutta sen sijaan voit määrittää mukautetun `PathBase` ja `/ ASF` ja saavuttaa helpompaa asetukset `mydomain. om/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

Ellet todella tarvitse määrittää mukautetun peruspolku, se on parasta jättää oletusarvoisesti.

## Esimerkki config

### Muuttaa oletusporttia

Seuraava asetus yksinkertaisesti muuttaa oletuksena ASF kuunteluportin `1242` `1337`. Voit valita haluamasi portin, mutta suosittelemme `1024-32767` -aluetta, koska muut satamat ovat tyypillisesti **[rekisteröity](https://en.wikipedia.org/wiki/Registered_port)**, ja voivat esimerkiksi vaatia `root` -käyttöoikeuden Linuxissa.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP4": {
                "Url": "http://127. .0. :1337"
            },
            "HTTP6": {
                "Url": "http://[:1]:1337"
            }
        }
    }
}
```

---

### Ota käyttöön pääsy kaikilta IP-osoitteilta

Seuraava asetus sallii etäyhteyden kaikista lähteistä, siksi sinun pitäisi **varmistaa, että olet lukenut ja ymmärtänyt meidän tietoturva-ilmoitus, että**, saatavilla edellä.

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

Jos et vaadi pääsyä kaikista lähteistä, mutta esimerkiksi vain lähiverkkosi, sitten se on paljon parempi idea tarkistaa paikallinen IP-osoite koneen hosting ASF, esimerkiksi `192. 68.0.10` ja käytä sitä `*` -sovelluksen sijasta. Valitettavasti se on mahdollista vain, jos LAN-osoite on aina sama, Kuten muuten sinulla on luultavasti enemmän tyydyttäviä tuloksia `*` ja oma palomuuri sen päällä, että vain paikalliset aliverkot pääsevät ASF:n satamaan.

---

# Todennus

ASF IPC liitäntä oletuksena ei vaadi minkäänlaista todentamista, koska `IPCPassword` on asetettu `null`. Kuitenkin, jos `IPCPassword` on käytössä asettamalla johonkin ei-tyhjään arvoon, joka puhelu ASF:n API:lle vaatii salasanan, joka vastaa asetettua `IPCPassword`. Jos jätät tunnistautumisen pois tai syötät väärän salasanan, saat `401 - Luvaton` virheen. Viiden autentikointiyrityksen (väärä salasana) jälkeen saat väliaikaisesti estetty `403 - kielletty` virhe.

Todennus voidaan tehdä kahdella eri tavalla.

## `Todennus` otsikko

Yleensä sinun pitäisi käyttää **[HTTP pyynnön otsikot](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)**, asettamalla `Authentication` -kenttää salasanallasi arvoksi. Tapa tehdä se riippuu todellinen työkalu, jota käytät päästäksesi ASF IPC käyttöliittymä, Esimerkiksi, jos käytät `curl` niin sinun pitäisi lisätä `-H 'Authentication: MyPassword'` parametriksi. Tällä tavoin todentaminen tehdään pyynnön otsikoissa, joissa se itse asiassa olisi tehtävä.

## `salasana` parametri kyselyn merkkijonossa

Vaihtoehtoisesti voit lisätä `salasanan` parametrin soittamasi URL-osoitteen loppuun, esimerkiksi soittamalla `/Api/ASF? assword=MyPassword` pelkän `/Api/ASF` sijasta. Tämä lähestymistapa on tarpeeksi hyvä, mutta ilmeisesti se paljastaa salasanan avoimessa, mikä ei välttämättä ole aina tarkoituksenmukaista. Sen lisäksi, että se on lisäargumentti kyselyn merkkijono, joka vaikeuttaa URL-osoitteen ulkoasua ja tekee siitä tuntuvan, että se on URL-spesifinen, kun taas salasana koskee koko ASF API kommunikointia.

---

Molemmat tavat ovat tuettuja, ja se on täysin sinun, jonka haluat valita. Suosittelemme käyttämään HTTP-otsakkeita kaikkialla, missä pystyt, sillä se on tarkoituksenmukaisempaa kuin kyselyn merkkijono. Kannatamme kuitenkin myös kyselyn merkkijonoa pääasiassa siksi, että pyyntöjen otsikoihin liittyy erilaisia rajoituksia. Hyvä esimerkki on mukautetun otsikon puuttuminen käynnistettäessä websocket yhteys javascript (vaikka se on täysin voimassa mukaan RFC). Tässä tilanteessa kysely merkkijono on ainoa tapa todentaa.

---

# Swaggerin dokumentaatio

IPC-käyttöliittymämme, ASF API:n ja ASF-uin lisänä sisältää myös swaggerin dokumentaation, joka on saatavilla `/swagger` **[URL](http://localhost:1242/swagger)**. Swaggerin dokumentaatio toimii keski-ihmisenä API-toteutuksemme ja muiden sitä käyttävien työkalujen välillä (esim. ASF-ui). It provides a complete documentation and availability of all API endpoints in **[OpenAPI](https://swagger.io/resources/open-api)** specification that can be easily consumed by other projects, allowing you to write and test ASF API with ease.

Sen lisäksi, että käytämme swagger-dokumentaatiota ASF API:n täydellisenä eritelmänä, voit myös käyttää sitä käyttäjäystävällinen tapa suorittaa erilaisia API päätepisteitä, lähinnä ne, joita ei ole toteutettu ASF-ui. Koska meidän swagger dokumentaatio syntyy automaattisesti ASF koodi, sinulla on tae siitä, että dokumentaatio on aina ajan tasalla API-päätepisteissä, joita ASF:n versiosi sisältää.

![Swaggerin dokumentaatio](https://github.com/user-attachments/assets/ce998e08-f5db-46b0-a9e8-e6b69abd94bb)


---

# UKK

### Onko ASF:n IPC-käyttöliittymä turvallinen ja turvallinen?

ASF kuuntelee oletusarvoisesti vain `localhost` -osoitteissa, mikä tarkoittaa, että ASF IPC -järjestelmän käyttö mistä tahansa koneesta, mutta oma **on mahdotonta**. Jos et muokkaa oletusarvoisia päätepisteitä, hyökkääjä tarvitsisi suoran pääsyn omalle koneellesi, jotta voit käyttää ASF:n IPC:tä, Siksi se on niin turvallinen kuin se voi olla, ja ei ole mitään muuta mahdollisuutta käyttää sitä, edes omasta LAN.

Jos päätät kuitenkin muuttaa oletusta `localhost` sitoo osoitteita johonkin muuhun, sitten sinun pitäisi asettaa asianmukaiset palomuurin säännöt **itse** jotta vain valtuutetut IP-osoitteet voivat käyttää ASF:n IPC-rajapintaa. Sen lisäksi, että sinun täytyy perustaa `IPCPassword`, kuten ASF kieltäytyy antamasta muiden koneiden käyttää ASF API ilman yksi, mikä lisää toisen kerroksen ylimääräistä turvallisuutta. Saatat myös haluta käyttää ASF:n IPC-rajapintaa käänteisen välityspalvelimen takana tässä tapauksessa, mikä selitetään tarkemmin alla.

### Voinko käyttää ASF APIa omien työkalujeni tai käyttäjäkomentojeni kautta?

Kyllä, tämä on mitä ASF API on suunniteltu ja voit käyttää mitä tahansa pystyy lähettämään HTTP pyyntö käyttää sitä. Paikalliset käyttäjät seuraavat **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** logiikkaa, ja sallimme pääsyn kaikista alkuperäistä niille (`*`), niin kauan kuin `IPCPassword` on asetettu, ylimääräisenä turvatoimenpiteenä. Tämän avulla voit suorittaa erilaisia todennettuja ASF API pyyntöjä, sallimatta mahdollisesti pahansuopia skriptejä tehdä se automaattisesti (kuten heidän täytyy tietää `IPCPassword` tekemään).

### Voinko käyttää ASF:n IPC:tä etänä esimerkiksi toisesta koneesta?

Kyllä, suosittelemme käyttämään käänteistä välityspalvelinta tähän. Näin voit käyttää web-palvelinta tyypillisellä tavalla, joka sitten käyttää ASF IPC saman koneen. Vaihtoehtoisesti, jos et halua käyttää käänteistä välitystä, voit käyttää **[mukautettua asetusta](#enabling-access-from-all-ips)** sopivalla URL-osoitteella. Esimerkiksi, jos koneesi on VPN:ssä, jossa on `10.8.0.1` osoite, voit asettaa `http://10.8.0. :1242` kuunteleminen URL-osoite IPC config, joka mahdollistaisi IPC pääsy yksityisen VPN, mutta ei missään muualla.

### Voinko käyttää ASF IPC takana käänteinen välityspalvelin, kuten Apache tai Nginx?

**Kyllä**, IPC on täysin yhteensopiva tällaisten asetusten kanssa, joten voit isännöidä sitä myös omien työkalujesi edessä lisäturvallisuuden ja yhteensopivuuden takaamiseksi, jos haluat. ASF:n Kestrel http -palvelin on yleensä erittäin turvallinen, eikä sillä ole mitään vaaraa, kun se on suoraan yhteydessä Internetiin, mutta laittamalla sen taakse reverse-proxy kuten Apache tai Nginx voisi tarjota ylimääräistä toiminnallisuutta, joka ei olisi mahdollista saavuttaa muuten, kuten ASF:n käyttöliittymän turvaaminen **[perusauth](https://en.wikipedia.org/wiki/Basic_access_authentication)** -toiminnolla.

Esimerkki Nginx konfiguraatio löytyy alta. Olemme sisällyttäneet täyden `-palvelimen` -lohkon, vaikka olet kiinnostunut pääasiassa `sijainnista` -lohkosta. Katso **[nginx dokumentaatio](https://nginx.org/en/docs)** jos tarvitset lisäselvityksiä.

```nginx
server {
    listen *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /path/to/your/fullchain.pem;
    ssl_certificate_key /path/to/your/privkey.pem;

    location ~* /Api/NLog {
        proxy_pass http://127.0.0.1:1242;

        # Only if you need to override default host
#       proxy_set_header Host 127.0.0.1;

        # X-headers should always be specified when proxying requests to ASF
        # They're crucial for proper identification of original IP, allowing ASF to e.g. ban the actual offenders instead of your nginx server
        # Specifying them allows ASF to properly resolve IP addresses of users making requests - making nginx work as a reverse proxy
        # Not specifying them will cause ASF to treat your nginx as the client - nginx will act as a traditional proxy in this case
        # If you're unable to host nginx service on the same machine as ASF, you most likely want to set KnownNetworks appropriately in addition to those
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;

        # We add those 3 extra options for websockets proxying, see https://nginx.org/en/docs/http/websocket.html
        proxy_http_version 1.1;
        proxy_set_header Connection "Upgrade";
        proxy_set_header Upgrade $http_upgrade;
    }

    location / {
        proxy_pass http://127.0.0.1:1242;

        # Only if you need to override default host
#       proxy_set_header Host 127.0.0.1;

        # X-headers should always be specified when proxying requests to ASF
        # They're crucial for proper identification of original IP, allowing ASF to e.g. ban the actual offenders instead of your nginx server
        # Specifying them allows ASF to properly resolve IP addresses of users making requests - making nginx work as a reverse proxy
        # Not specifying them will cause ASF to treat your nginx as the client - nginx will act as a traditional proxy in this case
        # If you're unable to host nginx service on the same machine as ASF, you most likely want to set KnownNetworks appropriately in addition to those
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
    }
}
```

Esimerkki Apache- konfiguraatio löytyy alta. Katso **[apache dokumentaatio](https://httpd.apache.org/docs)** jos tarvitset lisäselvityksiä.

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerName asf.mydomain. om

        SSLEngine
        SSLCertificateFile /path/to/your/fullchain. em
        SSLCertificateKeyFile /path/to/your/privkey. em

        # TODO: Apache ei voi tehdä tapauskohtaista vastaavuutta kunnolla, joten me hardcode kaksi yleisimmin käytettyjä tapauksia
        ProxyPass "/api/nlog" "ws://127. .0. :1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0. :1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### Voinko käyttää IPC-rajapintaa HTTPS-protokollan kautta?

**Kyllä**, voit saavuttaa sen kahdella eri tavalla. Suositeltu tapa olisi käyttää käänteinen välityspalvelin sitä, jossa voit käyttää web-palvelinta kautta https kuten tavallista, ja liittää sen kautta ASF IPC käyttöliittymä samassa koneessa. Näin liikennesuorituksesi on täysin salattu, eikä sinun tarvitse muokata IPC:tä millään tavalla tukeaksesi tällaista asetusta.

Toinen tapa on määrittää **[mukautettu config](#custom-configuration)** ASF:n IPC-rajapinnalle, jossa voit ottaa https -päätepisteen käyttöön ja tarjota asianmukaisen sertifikaatin suoraan Kestrel http -palvelimelle. Tällä tavoin suositellaan, jos et käytä mitään muuta web-palvelinta etkä halua käyttää sitä yksinomaan ASF:lle. Muuten on paljon helpompi saavuttaa tyydyttävä asennus käyttämällä käänteinen välityspalvelin mekanismi.

---

### IPC käynnistyksen aikana saan virhe: `System.IO. OPoikkeus: Osoitteen sitominen epäonnistui. Pistokkeeseen yritettiin päästä tavalla, joka on estetty sen käyttöoikeudet`

Tämä virhe osoittaa, että jokin muu koneessasi on jo käyttänyt porttia tai varannut sen myöhempää käyttöä varten. Tämä voi olla sinä, jos yrität ajaa toista ASF instanssia samalla koneella, mutta useimmiten se on Windows pois portti `1242` käytöstä, joten sinun täytyy siirtää ASF toiseen satamaan. Voit tehdä sen, noudata **[esimerkki config](#changing-default-port)** edellä, ja yksinkertaisesti yrittää valita toisen sataman, kuten `12420`.

Tietenkin voit myös yrittää selvittää, mikä estää portti `1242` ASF käytöstä, ja poistaa, että: mutta se on yleensä paljon hankalampaa kuin yksinkertaisesti ohjeistaa ASF käyttää toista satamaa, joten jätämme kehittelemään edelleen että täällä.

---

### Miksi saan `403 kielletty` virheen käyttämättä `IPCPassword`?

ASF sisältää ylimääräisen turvatoimenpiteen, jolla oletusarvoisesti sallitaan vain palautusliittymä (`localhost`, Omalla koneellasi voit käyttää ASF API:a ilman asetusta `IPCPassword` Tämä johtuu siitä, että `IPCPassword` -laitteen käytön tulisi olla **vähintään** -turvatoimenpide, jonka kaikki päättävät paljastaa ASF-liitännän edelleen.

Muutoksen sanelee se, että tietämättömien käyttäjien maailmanlaajuisesti isännöimiä valtavia määriä ASF:itä otettiin haltuunsa pahansuopien tarkoitusperien vuoksi, yleensä jättää ihmiset ilman tilejä ja ilman eriä niitä. Nyt voisimme sanoa, "he voisivat lukea tämän sivun ennen kuin avattiin ASF koko maailmalle", mutta sen sijaan on järkevämpää estää turvattomat ASF asetukset oletusarvoisesti, ja vaatia käyttäjiltä toimia, jos he nimenomaisesti haluavat sallia sen, jota me kehitämme alla.

Erityisesti voit ohittaa päätöksemme määrittelemällä verkot, joihin luotat päästäksesi ASF:ään ilman `IPCPassword` määritettyä, voit asettaa ne `KnownNetworks` ominaisuudessa mukautetussa config. Kuitenkin, ellet **todella** tiedä mitä teet ja täysin riskejä, sinun pitäisi sen sijaan käyttää `IPCPassword` julistamiseksi `KnownNetworks` antaa kaikille näistä verkoista pääsyn ASF API ehdoitta. Olemme vakavia, ihmiset olivat jo ammunta jalka uskoo käänteisiä lähettiläät ja iptables säännöt olivat turvallisia, mutta he olivat, `IPCPassword` on ensimmäinen ja joskus viimeinen huoltaja, jos päätät jättäytyä pois tästä yksinkertaisesta, mutta erittäin tehokkaasta ja turvallisesta mekanismista, voit syyttää vain itseäsi.