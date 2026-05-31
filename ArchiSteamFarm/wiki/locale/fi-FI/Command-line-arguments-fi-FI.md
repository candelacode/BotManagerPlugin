# Komentoriviargumentit

ASF sisältää tuen useille komentoriviparametreille, jotka voivat vaikuttaa ohjelman suoritusaikaan. Kokeneet käyttäjät voivat käyttää niitä ohjelman toiminnan määrittämiseen. Verrattuna oletustapaan `ASF.json` konfiguraatiotiedoston, komentorivin argumentteja käytetään ydinalustukseen (esim. `--path`), alustakohtaiset asetukset (esim. `--system-required`) tai arkaluonteiset tiedot (esim. `--cryptkey`).

---

## Käyttö

Käyttö riippuu käyttöjärjestelmästäsi ja ASF-maustasi.

Yleiset:

```shell
dotnet ArchiSteamFarm.dll --argument --otherOne
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --otherOne
```

Komentoriviargumentteja tuetaan myös yleisissä apuohjelmissa, kuten `ArchiSteamFarm.cmd` tai `ArchiSteamFarm.sh`. Tämän lisäksi voit kanssa käyttää `ASF_ARGS` ympäristöominaisuutta, kuten meidän **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** ja **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** osiossa.

Jos argumentissasi on välilyöntejä, älä unohda lainata sitä. Nuo kaksi olevat väärässä:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Bad!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Bad!
```

Nämä kaksi ovat kuitenkin hyviä:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Argumentit

`--cryptkey <key>` tai `--cryptkey=<key>` - alkaa ASF mukautetulla salausavaimella `<key>` arvolla. Tämä asetus vaikuttaa **[turvallisuus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** ja aiheuttaa ASF:n käyttämään mukautettua `<key>` -näppäintä sen sijaan, että oletuksena olisi kovakoodattu suoritettavaksi. Koska tämä ominaisuus vaikuttaa oletussalausavaimeen (salaustarkoituksiin) sekä suolaan (tiivistämistarkoituksiin), pitää mielessä, että kaikki salattu/hajautettu tällä avaimella vaatii sen väliin jokaisen ASF suoritettavan.

`<key>` pituus tai merkit eivät vaadi mutta turvallisuussyistä suosittelemme valitsemaan tarpeeksi pitkän salasanan, joka on tehty e. . satunnainen 32 merkkiä, esimerkiksi käyttämällä `tr -dc A-Za-z0-9 < /dev/urandom ≠ head -c 32; echo` komento Linuxissa.

On hienoa mainita, että on olemassa myös kaksi muuta tapaa antaa tämä tieto: `--cryptkey-file` ja `--input-cryptkey`.

Tämän ominaisuuden luonteen vuoksi on myös mahdollista asettaa salausavain ilmoittamalla `ASF_CRYPTKEY` ympäristömuuttuja, joka voi olla sopivampi ihmisille, jotka haluavat välttää arkaluonteisia yksityiskohtia prosessin perusteluissa.

---

`--cryptkey-file <path>` tai `--cryptkey-file=<path>` - käynnistyy ASF mukautetulla salausavaimella, joka on luettu `<path>` tiedostosta. Tämä palvelee samaa tarkoitusta kuin edellä kuvattu `--cryptkey <key>` vain mekanismi eroaa, koska tämä ominaisuus lukee `<key>` annetusta `<path>` sijaan. Jos käytät tätä yhdessä `--path`kanssa, katsoa, että suhteellinen polku on erilainen riippuen siitä, kuinka hyvin väitteet ovat, i. . vaihda `--path` ennen tai jälkeen `--cryptkey-file`.

Tämän ominaisuuden luonteen vuoksi on myös mahdollista asettaa avaintiedosto ilmoittamalla `ASF_CRYPTKEY_FILE` ympäristömuuttuja, joka voi olla sopivampi ihmisille, jotka haluavat välttää arkaluonteisia yksityiskohtia prosessin perusteluissa.

---

`--ignore-unsupported-environment` - aiheuttaa ASF:n jättämään huomiotta ongelmat, jotka liittyvät toimintaan ilman tukea joka normaalisti on signalized kanssa virhe ja pakko poistua. Ei-tuettu ympäristö sisältää esimerkiksi ajon `win-x64` OS-specific build on `linux-x64`. Vaikka tämä lippu sallii ASF yrittää toimia tällaisissa skenaarioissa, olla neuvonut, että emme tue näitä virallisesti ja pakotat ASF tehdä sen kokonaan **omalla vastuulla**. On tärkeää huomauttaa, että **kaikki** ympäristöskenaarioista **voidaan korjata**. Suosittelemme painokkaasti korjaamaan jäljellä olevat ongelmat sen sijaan, että julistaisimme tämän väitteen.

---

`--input-cryptkey` - saa ASF kysymään `--cryptkey` käynnistyksen aikana. Tämä vaihtoehto voi olla hyödyllinen sinulle, jos sen sijaan, että annat salausavaimen, olipa kyseessä sitten ympäristömuuttujat tai tiedosto, et halua, että sitä ei tallenneta minne tahansa ja syötä se manuaalisesti jokaiseen ASF-aikaan.

---

`--minimized` - tekee ASF konsoliikkunasta pienennetyn pian käynnistyksen jälkeen. Hyödyllinen pääasiassa auto-start skenaarioita, mutta voidaan käyttää myös niiden ulkopuolella. Tämä vaihtoehto edellyttää asianmukaista ympäristötukea – se ei välttämättä toimi kunnolla kaikissa mahdollisissa tilanteissa.

---

`--network-group <group>` tai `--network-group =<group>` - aiheuttaa ASF sisään rajoittimiinsa, joilla on mukautettu verkko ryhmä `<group>`. Tämä asetus vaikuttaa ASF:n toimintaan **[useassa esiintymässä](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** viestittämällä että annettu instanssi on riippuvainen vain kohdista, jotka jakavat saman verkkoryhmän, ja riippumaton muista. Tyypillisesti haluat käyttää tätä ominaisuutta vain jos reitität ASF pyyntöjä mukautetun mekanismin kautta (esim. eri IP-osoitteet) ja haluat asettaa verkkoryhmiä itse, ilman riippuvuutta ASF tehdä sen automaattisesti (sisältää tällä hetkellä ottaa huomioon vain `WebProxy`). Muista, että kun käytät mukautettua verkkoryhmää, tämä on paikallisen koneen yksilöllinen tunniste, ja ASF ei ota huomioon muita tietoja, kuten `WebProxy` arvo, jolloin voit e. . aloittaa kaksi instanssia eri `WebProxy` arvoilla, jotka ovat edelleen riippuvaisia toisistaan.

Tämän ominaisuuden luonteen vuoksi on myös mahdollista asettaa arvo ilmoittamalla `ASF_NETWORK_GROUP` ympäristömuuttuja, joka voi olla sopivampi ihmisille, jotka haluavat välttää arkaluonteisia yksityiskohtia prosessin perusteluissa.

---

`--no-config-migrate` - oletuksena ASF siirtää asetustiedostosi automaattisesti uusimpaan syntaksiin. Muuttoliike sisältää vanhentuneiden ominaisuuksien muuntamisen uusiksi ominaisuuksiksi, ominaisuuksien poistamisen oletusarvoilla (koska niillä ei ole vaikutusta), sekä tiedoston puhdistus yleensä (sisennyksen korjaaminen ja samoin). Tämä on lähes aina hyvä idea, mutta saatat olla tietty tilanne, jossa haluat ASF koskaan ylikirjoittaa asetustiedostot automaattisesti. Esimerkiksi saatat haluta `chmod 400` asetustiedostosi (lue lupa vain omistajalle) tai laittaa `chattr +i` niiden päälle, tuloksena on kirjoitusoikeuksien epääminen kaikilta, e. . turvatoimenpiteenä . Yleensä suosittelemme pitämään config migraatio käytössä, mutta jos sinulla on erityinen syy poistaa se käytöstä ja mieluummin ASF ei tee sitä, voit käyttää tätä kytkintä tämän tavoitteen saavuttamiseksi. Muistakaa kuitenkin, että oikeiden asetusten tarjoaminen ASF:lle tulee tästä lähtien teidän uudesta vastuustanne, erityisesti myöhemmissä ASF-versioissa esiintyvien ominaisuuksien deprecations and refactors of properties in future ASF (Deprecations and refactors).

---

`--no-config-watch` - oletuksena ASF asettaa `FileSystemWatcher` `config` -hakemiston päälle, jotta voit kuunnella tiedostojen muutoksiin liittyviä tapahtumia, jotta se voi vuorovaikutteisesti sopeutua niihin. Tämä sisältää esimerkiksi asetusten poistamisen pysäyttämisen, botin uudelleenkäynnistyksen konfiguroinnin muuttamisen yhteydessä, tai lataamalla avaimet **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** kun pudotat ne `config` -hakemistoon. Tämän kytkimen avulla voit poistaa käytöstä tällaisen käytöksen, mikä saa ASF:n jättämään täysin huomiotta kaikki muutokset `config` -hakemistossa, vaatii sinulta tällaisia toimia manuaalisesti, jos se katsotaan tarkoituksenmukaiseksi (yleensä tarkoittaa prosessin uudelleenkäynnistämistä). Suosittelemme pitämään config tapahtumat käytössä, mutta jos sinulla on erityinen syy poistaa ne käytöstä ja mieluummin ASF ei tee sitä, voit käyttää tätä kytkintä tämän tavoitteen saavuttamiseksi.

---

`--no-restart` - oletuksena ASF seuraa **[`AutoRestart`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#autorestart)** config ominaisuus, jota voit käyttää määritettäessä, onko uudelleenkäynnistys sallittu tarvittaessa. Jotkin ratkaisut, jotka tarjoamme vastuun prosessinhallinnasta ja jotka ovat yksiselitteisesti yhteensopimattomia ASF:n automaattisen uudelleenkäynnistyksen kanssa, kuten ASF `docker` tai `systemd`, koska he vaativat vain poistumisprosessia, koska heidän velvollisuutensa on käynnistää se uudelleen, jos se katsotaan aiheelliseksi. Koska mielivaltainen config-muokkaus ei ole haluttu käyttökokemuksesta, tämä kytkin yksinkertaisesti ohittaa `AutoRestart` config ominaisuuden käynnistämällä sen nimenomaisesti `false`, vaikka olet määrittänyt muuten config. Tämän ansiosta ASF:lle voidaan etukäteen tiedottaa tällaisessa ympäristössä tapahtuvasta toiminnasta, ilman vaatimusta saada aikaan yhteensopiva `AutoRestart: false` config-tiedosto.

Edellä mainittujen lisäksi `--no-restart`, päinvastoin kuin `AutoRestart: false`, Kielletään myös käyttämästä `-komentoa` uudelleen tai muutoin ASF-prosessin käynnistämisestä uudelleen, koska kytkin ilmaisee selvästi, että se ei ole yhteensopiva tällaisen asennuksen kanssa, kun taas `Autouudelleenkäynnistys` määrittää vain oletustoiminnon.

Normaalisti voit (ja pitäisi) hallita käyttäytymistä, joka on selitetty tässä asetustiedostossa. joskin jos käytät ASF:ää mukautetun skriptin tai muun vastaavan ympäristön sisällä, voit myös haluta käyttää tätä kytkintä, joka estää ASF aloittaa itsensä uudelleen.

---

`--no-steam-parental-generation` - oletuksena ASF yrittää automaattisesti luoda Steam vanhempien PIN-koodit, kuten on kuvattu **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** kokoonpano. Kuitenkin, koska se saattaa vaatia liikaa OS-resursseja, tämä kytkin sallii sinun poistaa kyseisen käytöksen, joka johtaa ASF ohittaa automaattisen sukupolven ja mene suoraan pyytää käyttäjän PIN-koodi, sen sijaan, mikä on mitä normaalisti tapahtuu vain, jos automaattinen sukupolvi on epäonnistunut. Yleensä suosittelemme, että sukupolvi pidetään käytössä, mutta jos sinulla on erityinen syy poistaa se käytöstä ja mieluummin ASF ei tee sitä, voit käyttää tätä kytkintä tämän tavoitteen saavuttamiseksi.

---

`--path <path>` tai `--path=<path>` - ASF navigoi aina omaan hakemistoonsa käynnistyksessä. Määrittelemällä tämän argumentin ASF navigoi annettuun hakemistoon alustuksen jälkeen, jonka avulla voit käyttää mukautettua polkua eri sovellusosille (mukaan lukien `config`, `kirjautuu`, `liitännäiset` ja `www` hakemistot sekä `NLog. onfig` tiedosto), ilman kaksinkertaista binary samassa paikassa. Se voi olla erityisen hyödyllistä, jos haluat erottaa binääri todellisesta config, kuten se on tehty Linux-kaltainen pakkaus - tällä tavalla voit käyttää yhtä (ajan tasalla) binääri useita eri asetuksia. Polku voi olla joko suhteellinen ASF-binäärin nykyisen paikan mukaan tai absoluuttinen. Muista, että tämä komento osoittaa uuteen "ASF kotiin" - hakemistoon joka on rakenteeltaan sama kuin alkuperäinen ASF, `config` -hakemiston sisällä, katso alla esimerkiksi selitys.

Tämän ominaisuuden luonteen vuoksi on myös mahdollista asettaa odotettu polku ilmoittamalla `ASF_PATH` ympäristömuuttuja, joka voi olla sopivampi ihmisille, jotka haluavat välttää arkaluonteisia yksityiskohtia prosessin perusteluissa.

Jos harkitset, että käytät tätä komentoriviparametria useiden ASF:n tapausten suorittamiseen, Suosittelemme lukemaan **[hallinta sivu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** tällä tavalla.

Esimerkkejä:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Absolute path
dotnet /opt/ASF/ArchiSteamFarm.dll --path .. TargetDirectory # Relatiivinen polku toimii samoin
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # Sama kuin env muuttuja
```

```text
¶ 📁 /opt
¶ ¶ 📁 ASF
¶ ¶ ⚙️ ArchiSteamFarm.dll
¶ ¶ ...
\ \ \ 📁 TargetDirectory
¶ \ \ 📁 config
- \ \ \ 📁 lokit (generated)
\ \ \ 📁 plugins (valinnainen)
\ \ \ \ 📁 www (valinnainen)
− 📄 log. xt (luotu)
• • 📄 NLog.config (valinnainen)
− ...
```

---

`--service` - tätä kytkintä käyttää pääasiassa meidän `järjestelmä` palvelu ja pakottaa `` `totta`. Ellei sinulla ole erityistä tarvetta, sen sijaan sinun pitäisi määrittää `Headless` -ominaisuus suoraan asetuksessasi. Tämä kytkin on täällä, joten meidän `-järjestelmämme` -palvelu ei tarvitse koskettaa globaalia configiasi mukauttaakseen sen omaan ympäristöönsä. Tietenkin, jos sinulla on samanlainen tarve niin voit myös käyttää tätä kytkin (muuten olet parempi globaali config ominaisuus).

---

`--system-vaadittu` - tämän kytkimen ilmoittaminen aiheuttaa sen, että ASF yrittää viestittää käyttöjärjestelmän että prosessi vaatii järjestelmän olevan toiminnassa koko elinkaarensa ajan. Tämä voi osoittautua erityisen hyödylliseksi, kun maanviljely tietokoneen tai kannettavan tietokoneen yöllä, koska ASF pystyy pitämään järjestelmän hereillä kun se on käynnissä. Tämä ominaisuus on tällä hetkellä tuettu Linuxissa ja Windowsissa.

Linuxissa sinun on toimittava kunnolla **[dbus](https://en.wikipedia.org/wiki/D-Bus)** ja kirjautumisprosessi tukee **[`Inhibit()`](https://systemd.io/INHIBITOR_LOCKS/)** -toimintoa. Kaksi suosituinta esikuvaa, `systeemi` sekä `elogind`, vahvistetaan tukemaan sitä. Suurimman osan työpöytäympäristöistä (kuten Gnome tai KDE) pitäisi toimia laatikossa, koska ne ovat jo riippuvaisia tästä toiminnallisuudesta omia tarpeitaan.

Ikkunoita koskevia erityisvaatimuksia ei ole, sen pitäisi toimia laatikossa.