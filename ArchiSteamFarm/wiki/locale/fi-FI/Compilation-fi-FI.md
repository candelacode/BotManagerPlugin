# Suorittaminen

Tiedostojen kokoaminen on prosessi suoritettavan tiedoston luomiseen. Tämä on mitä haluat tehdä, jos haluat lisätä omia muutoksia ASF, tai jos jostain syystä et luota virallisella **[julkaisee](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**. Jos olet käyttäjä eikä kehittäjä, todennäköisimmin haluat käyttää jo valmiiksi koottuja binääriä, mutta jos haluat käyttää omia tai oppia jotain uutta, jatka lukemista.

ASF voidaan kääntää millä tahansa tällä hetkellä tuetulla alustalla, kunhan sinulla on kaikki tarvittavat työkalut.

---

## .NET SDK

Riippumatta alustan, sinun on täysi .NET SDK (ei vain suoritettaessa) kokoamaan ASF. Asennusohjeet löytyvät **[.NET lataussivulta](https://dotnet.microsoft.com/download)**. Sinun täytyy asentaa sopiva .NET SDK versio käyttöjärjestelmällesi. Onnistuneen asennuksen jälkeen `dotnet` -komennon tulisi olla toiminnassa ja toiminnassa. Voit tarkistaa, toimiiko se `dotnet --info` -palvelun kanssa. Varmista myös, että .NET SDK sopii ASF **[-ajovaatimukset](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## Suorittaminen

Olettaen, että sinulla on .NET SDK operatiivinen ja sopiva versio, yksinkertaisesti navigoida lähde ASF hakemistoon (kloonattu tai ladattu ja unpacked ASF repo) ja suorittaa:

```shell
dotnet julkaista ArchiSteamFarm -c "Release" -o "out/generic"
```

Jos käytät Linux/macOS:ia, voit sen sijaan käyttää `cc.sh` skriptiä, joka tekee samoin, hieman monimutkaisemmalla tavalla.

Jos kooste päättyi onnistuneesti, löydät ASF `source` maun `ulkona / geneerinen` hakemistosta. Tämä on sama kuin virallinen `geneerinen` ASF rakennus, mutta se on pakottanut `UpdateChannel` ja `UpdatePeriod` `0`, joka on sopiva itsensä rakentamiseen.

### OS-spesifinen

Voit myös luoda OS-spesifisen .NET-paketin, jos sinulla on tietty tarve. Yleensä sinun ei pitäisi tehdä sitä, koska olet juuri koonnut `geneerinen` maku, jonka voit suorittaa jo asennetulla . ET ajoaika, että olet käyttänyt kooste ensin, mutta vain jos haluat :

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/linux-x64" -r "linux-x64" --self-contained
```

Tietenkin korvaa `linux-x64` OS-arkkitehtuurilla, jonka haluat kohdistaa, kuten `win-x64`. Tämä versio on myös poistettu käytöstä. Rakennettaessa `--self-contained` voit vaihtoehtoisesti ilmoittaa vielä kahdesta kytkimestä: `-p:PublishTrimmed=true` tuottaa leikatun rakennuksen, kun `-p:PublishSingleFile=true` tuottaa yhden tiedoston. Molempien lisääminen johtaa samoihin asetuksiin, joita käytämme omiin rakennuksiimme.

### ASF-ui

Edellä mainitut vaiheet ovat kaikki, mitä tarvitaan ASF:n täysimääräiseen perustamiseen. voit *myös* olla kiinnostunut rakentamaan **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, graafisen web-käyttöliittymän. ASF sivulta sinun tarvitsee vain pudottaa ASF-ui -rakennuksen tuotosta standardissa `ASF-ui/dist` sijainnissa, sitten rakentaa ASF sen kanssa (uudelleen, jos tarpeen).

ASF-ui on osa ASF:n lähdepuuta **[git alimoduulina](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, varmista, että olet kloonannut repon `git kloonilla --recursive`, koska muuten sinulla ei ole vaadittuja tiedostoja. Tarvitset myös toimivan NPM:n, **[Node.js](https://nodejs.org)** mukana mukana. Jos käytät Linux/macOSia, suosittelemme `cc. h` käsikirjoitus, joka kattaa automaattisesti rakennuksen ja kuljetuksen ASF-ui (jos mahdollista, eli jos täytät juuri mainitsemamme vaatimukset).

Sen lisäksi, että `cc. h` käsikirjoitus, kiinnitämme myös yksinkertaistetut rakennusohjeet, Katso lisätietoja **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)**. Suorita seuraavat komennot ASF:n lähdepuiden sijainnista niin kuin edellä:

```shell
rm -rf "ASF-ui/dist" # ASF-ui ei puhdista itseään vanhan version jälkeen

npm ci --prefix ASF-ui
npm run-skripti deploy --prefix ASF-ui

rm -rf "out/generic/www" # Varmista, että rakennuksemme tuotos on puhdas vanhoista tiedostoista
dotnet julkaisee ArchiSteamFarm -c "Release" -o "out/generic" # Tai vastaavasti mitä tarvitset kuten yllä on
```

Sinun pitäisi nyt pystyä löytämään ASF-ui tiedostot `-kansiostasi / yleinen/www` -hakemistosta. ASF pystyy palvelemaan näitä tiedostoja selaimessasi.

Alternatively, you can simply build ASF-ui, whether manually or with the help of our repo, then copy the build output over to `${OUT}/www` folder manually, where `${OUT}` is the output folder of ASF that you've specified with `-o` parameter. This is exactly what ASF is doing as part of the build process, it copies `ASF-ui/dist` (if exists) over to `${OUT}/www`, nothing special, and can also be done post-build as you can see, if needed.

---

## Kehitys

Jos haluat muokata ASF koodia, voit käyttää mitä tahansa. Tätä tarkoitusta varten yhteensopiva ET IDE, vaikka se onkin valinnaista, koska voit myös muokata muistilehtiöllä ja kääntää `dotnet` -komennon kanssa.

Jos sinulla ei ole parempaa valintaa, voimme suositella **[JetBrains Rider](https://www.jetbrains.com/rider)** ja **[Visual Studio Code](https://code.visualstudio.com/download)**, ensimmäinen on ensisijainen IDE, että ASF joukkue on henkilökohtaisesti käyttää, ja toinen on toteuttamiskelpoinen vaihtoehto. Molemmat ohjelmat ovat poikkialustaisia ja saatavilla Linuxissa, macOS:ssa ja Windowsissa.

---

## Tunnisteet

`` päähaara ei ole taattu olevan tilassa, joka mahdollistaa onnistuneen koostamisen tai virheettömän ASF suorituksen ensinnäkin, koska se on kehityshaara aivan kuten meidän **[julkaisusykli](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. Jos haluat koota tai viitata ASF lähteestä, sitten sinun pitäisi käyttää sopivaa **[tag](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** tähän tarkoitukseen, joka takaa ainakin onnistuneen koostamisen ja erittäin todennäköisesti myös virheettömän suorituksen (jos rakennus on merkitty vakaaksi julkaisuksi). Jotta voit tarkistaa puun nykyisen "terveyttä", voit käyttää CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Viralliset julkaisut

Viralliset ASF julkaisut on koonnut **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, viimeisin . ET SDK, joka vastaa ASF **[ajoaika vaatimuksia](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. Suoritettujen testien jälkeen kaikki paketit otetaan käyttöön julkaisuvälineenä, myös GitHubissa. Tämä takaa myös avoimuuden, koska GitHub käyttää aina virallista julkista lähdettä kaikkiin rakennuksiin, ja voit vertailla tarkistussummia GitHub esineiden kanssa GitHub release resursseja. ASF kehittäjät eivät kokoa tai julkaise rakentaa itseään lukuun ottamatta yksityistä kehitysprosessia ja vianetsintää.

Edellä esitetyn lisäksi ASF:n ylläpitäjät validoivat ja julkaisevat päivitysten tarkistussummia GitHubista riippumattomalla ASF-palvelimella lisäturvatoimenpiteenä. Tämä vaihe on pakollinen nykyisille liitännäisjärjestelmille, jotka pitävät julkaisua voimassa olevana ehdokkaana automaattisten päivitysten toiminnallisuudelle.