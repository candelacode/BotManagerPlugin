# Hallinta

Tässä osassa käsitellään aiheita, jotka liittyvät ASF-prosessin parhaaseen mahdolliseen hallintaan. Vaikka se ei ole ehdottomasti pakollinen käytössä, se sisältää joukko vinkkejä, temppuja ja hyviä käytäntöjä, jotka haluaisimme jakaa, erityisesti järjestelmänvalvojille, ihmiset pakkaavat ASF:n käytettäväksi kolmannen osapuolen arkistoissa sekä edistyneille käyttäjille ja niin edelleen.

---

## `järjestelmä` -palvelu Linuxille

`geneerisissä` ja `linux` versioissa, ASF mukana `ArchiSteamFarm@. ervice` tiedosto, joka on palvelun asetustiedosto **[`systemd`](https://systemd.io)**. Jos haluat käyttää ASF:ää palveluna esimerkiksi käynnistääksesi sen automaattisesti koneen käynnistymisen jälkeen, sitten asianmukainen `järjestelmä` palvelu on luultavasti paras tapa tehdä se, Siksi suosittelemme sitä sen sijaan, että hallinnoimme sitä omakohtaisesti `nohup`, `näyttö` tai niin edelleen.

Ensinnäkin luo tili käyttäjälle, jonka haluat käyttää ASF:ää, jos sitä ei vielä ole. Käytämme `asf` -käyttäjää tässä esimerkissä, jos päätät käyttää toista käyttäjää, sinun täytyy korvata `asf` käyttäjä kaikissa alla olevissa esimerkeissämme valitsemallasi käyttäjällä. Palvelumme ei salli sinun ajaa ASF `root`, koska sitä pidetään **[huono käytäntö](#never-run-asf-as-administrator)**.

```sh
su # Tai sudo -i, päästä root kuori
useradd -m asf # Luo tili aiot käyttää ASF alle
```

Seuraavaksi pura ASF `/home/asf/ArchiSteamFarm` -kansioon. Kansion rakenne on tärkeä palveluyksiköllemme, sen pitäisi olla `ArchiSteamFarm` -kansio `$HOME`, niin `/home/<user>`. Jos teit kaiken oikein, on olemassa `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service` tiedosto. Jos käytät `linux` -varianttia ja et poistanut tiedostoa Linuxista, mutta esimerkiksi käyttänyt tiedostojen siirtoa Windowsista, sitten sinun täytyy myös `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

Teemme kaikki alla olevat toiminnot `root`, joten pääset sen kuoreen `su` tai `sudo -i`.

Ensinnäkin se on hyvä idea varmistaa, että kansiomme kuuluu edelleen meidän `asf` käyttäjä, `jahr asf:asf /home/asf/ArchiSteamFarm` suoritettu kerran sen jälkeen. Käyttöoikeudet voivat olla virheellisiä esimerkiksi jos olet ladannut ja/tai purkanut zip-tiedoston `root`.

Toiseksi, jos käytät ASF:n geneeristä muunnelmaa, sinun on varmistettava, että `dotnet` -komento on tunnistettu ja jossakin vakiosijainnista: `/usr/local/bin`, `/usr/bin` tai `/bin`. Tätä tarvitaan järjestelmäpalvelussamme, joka suorittaa `dotnet /path/to/ArchiSteamFarm.dll` komennon. Tarkista, toimiiko `dotnet --info` sinulle, jos kyllä, kirjoita `komento -v dotnet` selvittääksesi, missä se sijaitsee. Jos olet käyttänyt virallista asentajaa, sen pitäisi olla `/usr/bin/dotnet` tai toisessa kahdesta muusta paikasta, joka on kunnossa. Jos se on mukautetussa paikassa, kuten `/usr/share/dotnet/dotnet`, luo sille **[symlink](https://wikipedia.org/wiki/Symbolic_link)** käyttäen `ln -s "$(command -v dotnet)" /usr/bin/dotnet`. Nyt `komento -v dotnet` pitäisi raportoida `/usr/bin/dotnet`, mikä myös saa järjestelmämme yksikön toimimaan. Jos käytät OS-spesifistä versiota, sinun ei tarvitse tehdä mitään tässä suhteessa.

Seuraava, execute `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/systemd/system/ArchiSteamFarm\@. ervice`, tämä luo symbolisen linkin palveluilmoitukseen ja rekisteröi sen `systemd`. Symbolisen linkin avulla ASF voi päivittää `järjestelmäsi` automaattisesti osana ASF päivitystä - riippuen tilanteestasi, saatat haluta käyttää tätä lähestymistapaa, tai yksinkertaisesti `cp` tiedosto ja hallita sitä itse, miten haluat.

Varmista jälkeenpäin, että `järjestelmä` tunnistaa palvelumme:

```
systemctl status ArchiSteamFarm@asf

¶ ArchiSteamFarm@asf.service - ArchiSteamFarm Service (asf)
     Ladattu: ladattu (/etc/systemd/system/ArchiSteamFarm@. ervie; pois käytöstä; Toimittaja esiasetettu: käytöstä)
     Aktiivinen: inaktiivinen (dead)
       Asiakirjat: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Kiinnitä erityistä huomiota käyttäjäön, jonka ilmoitamme `@`, se on `asf` meidän tapauksessamme. Järjestelmämme palveluyksikkö odottaa sinulta ilmoittavan käyttäjän, koska se vaikuttaa tarkka paikka binary `/home/<user>/ArchiSteamFarm`, sekä todellinen käyttäjä järjestelmä luo prosessi kuin.

Jos järjestelmä palasi tuotos samanlainen kuin edellä, kaikki on kunnossa, ja olemme melkein valmis. Nyt kaikki jäljellä on todella aloittaa palvelumme valitsemallamme käyttäjällä: `systemctl aloittaa ArchiSteamFarm@asf`. Odota toinen tai kaksi, ja voit tarkistaa tilan uudelleen:

```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (asf)
     Ladattu: ladattu (/etc/systemd/system/ArchiSteamFarm@.service; pois käytöstä; Toimittaja esi: käytössä)
     Aktiivinen (käynnissä) alkaen (...)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   Main PID: (...)
(...)
```

Jos `järjestelmä` ilmoittaa `aktiivisena (käynnissä)`, se tarkoittaa, että kaikki sujui hyvin, ja voit tarkistaa, että ASF prosessi on käynnissä, esimerkiksi `journalctl -r`, sillä ASF kirjoittaa oletusarvoisesti myös konsolin tuotoksen, joka on tallennettu `systemd`. Jos olet tyytyväinen asetuksiin juuri nyt, voit kertoa `system` käynnistääksesi palvelusi automaattisesti käynnistyksen aikana, Suorittamalla `systemctl ota käyttöön ArchiSteamFarm@asf` komennon. Siinä kaikki.

Jos sattumalta haluat pysäyttää prosessin, suorita `systemctl stop ArchiSteamFarm@asf`. Samoin jos haluat poistaa ASF:n käynnistyksen automaattisesti käynnistyksen aikana, `systemctl pois käytöstä ArchiSteamFarm@asf` tekee sen sinulle, se on hyvin yksinkertainen.

Huomioithan, että koska `järjestelmä` -palveluun ei ole käytössä vakiosyöttöä, et voi syöttää tietojasi konsolin kautta tavalliseen tapaan. `-järjestelmän läpi kulkeva` vastaa **[`-pääntön: todellinen`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** -asetus ja siihen liittyy kaikki sen seuraukset. Onneksi sinulle, on erittäin helppo hallita ASF **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, jota suosittelemme, jos sinun täytyy toimittaa lisätietoja kirjautumisen aikana tai muuten hallita ASF prosessia edelleen.

### Ympäristön muuttujat

On mahdollista toimittaa uusia ympäristömuuttujia `-järjestelmämme` palveluun jota olet kiinnostunut tekemään, jos haluat esimerkiksi käyttää mukautettua `--cryptkey` **[komentoriviparametria](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**, määritellään näin ollen ympäristömuuttuja `ASF_CRYPTKEY`.

Jotta tarjota mukautettuja ympäristömuuttujia, luoda `/etc/asf` kansio (mikäli sitä ei ole olemassa), `mkdir -p /etc/asf`. Suosittelemme `chown -hR juuri:root /etc/asf && chmod 700 /etc/asf` sen varmistamiseksi, että vain `root` käyttäjällä on pääsy lukea näitä tiedostoja, koska ne saattavat sisältää herkkiä ominaisuuksia, kuten `ASF_CRYPTKEY`. Myöhemmin kirjoita `/etc/asf/<user>` tiedostoon jossa `<user>` on käyttäjä, jolla käytät palvelua yllä olevassa esimerkissä (`asf` niin `/etc/asf/asf`).

Tiedoston pitäisi sisältää kaikki ympäristömuuttujat, jotka haluat antaa prosessille. Ne, joilla ei ole erityistä ympäristömuuttujaa, voidaan ilmoittaa `ASF_ARGS`:

```sh
# Julistaa vain ne, joita tarvitset
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# Ja kaikki muut ovat kiinnostuneita
```

### Ensisijainen osa palveluyksiköstä

Kiitos joustavuuden `järjestelmä`, ASF on mahdollista korvata osa ASF yksikkö säilyttäen silti alkuperäisen yksikön tiedosto ja antaa ASF päivittää sen esimerkiksi osana automaattisia päivityksiä.

Tässä esimerkissä haluaisimme muokata ASF `-järjestelmän` -yksikön käyttäytymistä aloittamalla uudelleen vain menestyksestä, aloittamalla uudelleen myös kuolemaan johtavia kaatumisia. Voidakseen tehdä niin, ohitamme `uudelleenkäynnistyksen` ominaisuuden `[Service]` oletusarvosta `menestyksen` - `aina`. Yksinkertaisesti suorita `systemctl edit ArchiSteamFarm@asf`, luonnollisesti korvaa `asf` palvelun kohderyhmällä. Lisää sitten muutokset `järjestelmän` ohjeiden mukaisesti oikeaan osioon:

```sh
### Muokkaaminen /etc/systemd/system/ArchiSteamFarm@asf.service.d/override. onf
### Kaikista tämän ja alla olevan kommentin välillä tulee tiedoston uusi sisältö

[Service]
Restart=aina

### Tämän kommentin alla olevat rivit hylätään

### /etc/systemd/system/ArchiSteamFarm@asf. ervice
# [Install]
# WantedBy=multi-user. arget
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm. ll --no-restart --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# Käyttäjä=%i
# (...)
```

Ja se on, nyt laitteesi toimii samalla tavalla kuin jos sillä olisi vain `Restart=aina` `[Service]` alla.

Vaihtoehtona on tietenkin `cp` tiedosto ja hallita sitä itse, mutta tämä mahdollistaa joustavat muutokset, vaikka olet päättänyt säilyttää alkuperäisen ASF yksikön, Esimerkiksi **[symlink](https://wikipedia.org/wiki/Symbolic_link)**.

---

## Älä koskaan aja ASF:ää järjestelmänvalvojaksi!

ASF sisältää oman validoinnin, onko prosessi käynnissä järjestelmänvalvojana (`root`) vai ei. `root` on **ei** vaadittu mihin tahansa ASF-prosessin suorittamaan toimintaan, olettaen, että ympäristö on asianmukaisesti konfiguroitu, ja siksi sitä olisi pidettävä **huono käytäntö**. This means that on Windows, ASF should **never** be executed with "run as administrator" setting, and on Unix ASF should have a **dedicated user account** for itself, or re-use your own in case of a desktop system.

Lisäselvityksiä varten *miksi* meidän lannistaa ajaa ASF kuin `root`, viittaavat **[superuser](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** ja muihin resursseihin. Jos et vieläkään ole vakuuttunut, kysy itseltäsi, mitä koneellesi tapahtuisi, jos ASF suoritettiin `rm -rf /*` komento heti käynnistyksen jälkeen.

### Suoritan `root` -arvona, koska ASF ei voi kirjoittaa tiedostoja

Tämä tarkoittaa, että sinulla on väärin määritetyt oikeudet tiedostoja ASF yrittää käyttää. Sinun pitäisi kirjautua `root` -tiliksi (joko `su` tai `sudo -i`) ja sitten **oikea** oikeudet myöntämällä `chown -hR asf:asf /path/to/ASF` komennon, korvaamalla `asf:asf` käyttäjällä, jonka käytät ASF:ää, ja `/path/to/ASF` vastaavasti. Jos sattumalta käytät mukautettua `--path` kertomalla ASF käyttäjälle käyttämään eri hakemistoa, sinun pitäisi suorittaa sama komento uudelleen myös tälle polulle.

Sen jälkeen sinun ei pitäisi enää saada mitään ongelmia, jotka liittyvät ASF ei voi kirjoittaa yli omia tiedostoja, Koska olet juuri muuttanut kaikkien ASF on kiinnostunut käyttäjälle, ASF prosessi on todella käynnissä.

### `root` , koska en tiedä miten tehdä sitä muuten

```sh
su # Tai sudo -i, päästä root shell
useradd -m asf # Luo tili aiot ajaa ASF alle
chown -hR asf:asf /path/to/ASF # Varmista, että uusi käyttäjä voi käyttää ASF-hakemistoon
su asf -c /path/to/ASF/ArchiSteamFarm # Or sudo -u asf /path/to/ASF/ArchiSteamFarm, käynnistää ohjelman itse käyttäjän alla
```

Se tekisi sen manuaalisesti, se on paljon helpompi käyttää meidän **[`järjestelmä` palvelu](#systemd-service-for-linux)** edellä selitetään.

### Tiedän paremmin ja haluan silti ajaa `root`

ASF ei voimakkaasti estä sinua tekemästä niin, vain näyttää varoituksen lyhyellä varoitusajalla. Älä vain ole järkyttynyt, jos yksi päivä takia vika ohjelmassa se räjäyttää koko käyttöjärjestelmäsi täydellisellä tietojen menetyksellä - sinua on varoitettu.

---

## Useita instansseja

ASF on yhteensopiva sen kanssa, että samassa koneessa ajetaan useita prosessin ilmentymiä. Tapaukset voivat olla täysin itsenäisiä tai peräisin samasta binäärinen sijainti (siinä tapauksessa, haluat suorittaa ne eri `--path` **[komentoriviparametri](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**).

Kun käynnissä useita instansseja samasta binaarista, pidä mielessä, että sinun pitäisi tyypillisesti poistaa automaattiset päivitykset käytöstä kaikissa niiden konfiguroissa, koska niiden välillä ei ole synkronointia liittyen automaattiset päivitykset. Jos haluat pitää automaattiset päivitykset käytössä, suosittelemme erillisiä tapauksia, mutta voit silti tehdä päivityksiä toimimaan, kunhan voit varmistaa, että kaikki muut ASF instanssit on suljettu.

ASF tekee parhaansa säilyttääkseen vähimmäismäärän OS-laajuista ja prosessikohtaista viestintää muiden ASF:n tapausten kanssa. Tämä sisältää ASF tarkistaa asetushakemiston muissa tapauksissa, sekä jakavat ydin prosessinlaajuiset rajoittimet, jotka on määritetty `*LimiterDelay` **[maailmanlaajuiset asetusominaisuudet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, Sen varmistaminen, että useiden ASF-tapausten suorittaminen ei aiheuta mahdollisuutta puuttua korkoja rajoittavaan ongelmaan. Teknisten näkökohtien osalta kaikki alustat käyttävät omaa mekanismiamme mukautettujen ASF tiedostopohjaisten lukkojen väliaikaista hakemistoa varten, joka on `C:\Users\<YourUser>\AppData\Local\Temp\ASF` Windowsissa ja `/tmp/ASF` Unix.

ASF-ilmentymiä ei tarvitse käyttää samojen `*LimiterDelay` -ominaisuuksien jakamiseksi, ne voivat käyttää eri arvoja, koska jokainen ASF lisää oman konfiguroitu viive julkaisuaikaan ostamisen jälkeen. Jos määritetty `*LimiterDelay` on asetettu `0`, ASF instanssi ohittaa kokonaan odottamassa tietyn resurssin, joka on jaettu muiden instanssien (jotka voisivat mahdollisesti säilyttää jaettu lukitus keskenään). Kun asetettu johonkin muuhun arvoon, ASF synkronoi oikein muiden ASF instanssien kanssa ja odottaa sen vuoroa, vapauta lukitus määritetyn viiveen jälkeen, jolloin muut esiintymät voivat jatkua.

ASF ottaa huomioon `WebProxy` -asetuksen, kun päätetään jaetusta laajuudesta, mikä tarkoittaa, että kaksi ASF tapausta, joissa käytetään eri `WebProxy` -konfiguraatiota, eivät jaa rajoittimiaan keskenään. Tämä on toteutettu, jotta `WebProxy` -asetukset voivat toimia ilman liiallisia viivästyksiä, kuten eri verkkoliitynnät odottavat. Tämän pitäisi olla tarpeeksi hyvä useimmissa käyttötapauksissa kuitenkin, jos sinulla on erityinen mukautettu asetus, jossa olet esim. reititys pyytää itseäsi eri tavalla, voit määrittää verkkoryhmän itse `--network-group` **[komentoriviargumentin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**kautta, jonka avulla voit ilmoittaa ASF ryhmä, joka synkronoidaan tämän instanssin. Muista, että mukautettuja verkkoryhmiä käytetään yksinomaisesti, mikä tarkoittaa, että ASF ei enää käytä `WebProxy` oikean ryhmän määrittämiseen, kuten olet vastuussa ryhmittely tässä tapauksessa.

Jos haluat käyttää meidän **[`järjestelmä` -palvelua](#systemd-service-for-linux)** selitetty yllä useita ASF instansseja, se on hyvin yksinkertainen, käytä vain toista käyttäjää meidän `ArchiSteamFarm @` palveluilmoitus ja seuraa muita ohjeita. Tämä vastaa useita ASF instansseja eri binääreillä, joten ne voivat myös päivittää automaattisesti ja toimia toisistaan riippumatta.