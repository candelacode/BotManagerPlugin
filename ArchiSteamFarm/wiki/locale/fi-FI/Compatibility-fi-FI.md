# Yhteensopivuus

ASF on C# sovellus, joka on käynnissä .NET alustalla. Tämä tarkoittaa, että ASF ei ole käännetty suoraan **[laitekoodiin](https://en.wikipedia.org/wiki/Machine_code)** joka on käynnissä suorittimella, mutta **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)** , joka vaatii CIL-yhteensopivan ajoajan sen suorittamiseksi.

Tällä lähestymistavalla on valtava määrä etuja, koska CIL on alustasta riippumaton, minkä vuoksi ASF voi toimia natiivisti monissa käytettävissä käyttöjärjestelmissä, erityisesti Windowsissa, Linuxissa ja macOS:ssa. Ei ole vain emulointia tarvitaan, mutta myös tukea kaikille alustan ja laitteistoon liittyvät optimoinnit, kuten CPU SSE ohjeet. Sen ansiosta ASF voi saavuttaa erinomaisen suorituskyvyn ja optimoinnin, samalla kun se tarjoaa täydellisen yhteensopivuuden ja luotettavuuden.

Tämä tarkoittaa myös sitä, että ASF:llä ei ole **erityistä käyttöjärjestelmän vaatimusta**, koska se vaatii **ajoaika** että OS eikä OS itse. Niin kauan kuin ajoaika on suorittamassa ASF-koodia kunnolla, sillä ei ole väliä, onko taustalla OS Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii tai leivänpaahdin - kunhan **[. ET for it](https://dotnet.microsoft.com/download/dotnet)**, **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** on olemassa `geneerisessä` versiossa).

Kuitenkin, riippumatta siitä, missä käytät ASF, sinun on varmistettava, että kohdealusta on **[.NET Edellytykset](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** asennettu. Nämä ovat matalan tason kirjastoja, joita tarvitaan oikeisiin ajoaikatoimintoihin ja ehdottoman ytimeen, jotta ASF toimisi ensin. Hyvin todennäköisesti sinulla voi olla joitakin niistä (tai jopa kaikki) jo asennettu.

---

## ASF pakkaus

ASF sisältää kaksi päämakua - geneerinen pakkaus ja OS-spesifinen. Toiminnalliselta kannalta molemmat paketit ovat täsmälleen samat, ne pystyvät myös päivittämään itsensä automaattisesti. Ainoa ero niiden välillä on se, onko ASF **geneerinen** -paketti mukana myös **OS-spesifisen** virtaa varten.

---

### Yleiset

Yleinen paketti on alusta-agnostinen rakennus, joka ei sisällä konekohtaista koodia. Tämä asetus edellyttää, että .NET ajoaika on jo asennettu käyttöjärjestelmässäsi **sopivassa versiossa**. Me kaikki tiedämme, miten hankala on pitää riippuvuudet ajan tasalla, siksi tämä paketti on täällä lähinnä ihmisille, että **jo käyttää** . ET ja eivät halua kopioida ajoaikaa vain ASF jos he voivat hyödyntää mitä he ovat jo asentaneet. Yleinen paketti avulla voit myös ajaa ASF **missä tahansa, kunhan voit saada työtä täytäntöönpano . ET runtime**, riippumatta siitä, onko olemassa OS-specific ASF build for it, tai ei.

Ei ole suositeltavaa käyttää geneerinen maku, jos olet rento tai jopa kehittynyt käyttäjä, joka vain haluaa tehdä ASF työtä eikä kaivaa . Tekniset yksityiskohdat. Toisin sanoen - jos tiedät mitä tämä on, voit käyttää sitä, muuten on paljon parempi käyttää OS-spesifistä pakettia alla.

---

### OS-spesifinen

OS-kohtainen paketti, lukuun ottamatta yleiseen pakettiin sisältyvää hallittua koodia, sisältää myös tietylle alustalle tarkoitetun kotoperäisen koodin. Toisin sanoen, OS-erityinen paketti **sisältää jo oikea . ET runtime sisällä**, jonka avulla voit täysin ohittaa koko asennus sotku ja vain käynnistää ASF suoraan. Käyttöjärjestelmäkohtainen paketti, kuten voit arvata nimestä, on OS-spesifinen ja jokainen OS vaatii oman version - esimerkiksi Windows vaatii PE32+ `ArchiSteamFarm. xe` binary kun taas Linux toimii Unix ELF `ArchiSteamFarm` binäärin. Kuten ehkä tiedätte, nämä kaksi tyyppiä eivät ole keskenään yhteensopivia.

ASF on tällä hetkellä saatavilla seuraavissa OS-spesifisissä varianteissa:

- `linux-arm` toimii 32-bittisellä ARM-pohjaisella (ARMv7+) GNU/Linux käyttöjärjestelmällä, jossa on glibc 2.35/musl 1.2.3 ja uudempi. Tämä muunnelma kattaa alustoja kuten Vadelma Pi 2 (ja uudempi), se **ei** toimii vanhempien ARM arkkitehtuurit, kuten ARMv6 löytyy Raspberry Pi 0 & 1, Se ei myöskään toimi käyttöoikeuksien kanssa, jotka eivät toteuta vaadittua GNU/Linux-ympäristöä (kuten Android).
- `linux-arm64` toimii 64-bittisessä ARM-pohjaisessa (ARMv8+) GNU/Linux käyttöjärjestelmässä, jossa on glibc 2.27/musl 1.2.3 ja uudempi. Tämä muunnelma kattaa alustoja kuten Vadelma Pi 3 (ja uudempi), se **ei** toimi 32-bittisellä käyttöjärjestelmällä, joka ei vaadi 64-bittisiä kirjastoja (kuten 32-bittinen Vadelma Pi OS), Se ei myöskään toimi käyttöoikeuksien kanssa, jotka eivät toteuta vaadittua GNU/Linux-ympäristöä (kuten Android).
- `linux-x64` toimii 64-bittisellä GNU/Linux-käyttöjärjestelmällä, jossa on glibc 2.27/musl 1.2.3 ja uudempi.
- `osx-arm64` toimii 64-bittisessä ARM-pohjaisessa (Apple silicon) macOS OS:ssa versiossa 13 ja uudemmassa versiossa.
- `osx-x64` toimii 64-bittisissä macOS-käyttöjärjestelmissä versiossa 15 ja uudemmissa versioissa.
- `win-arm64` toimii **ajan tasalla** 64-bittisessä ARM-pohjaisessa (ARMv8+) Windows-käyttöjärjestelmissä versiossa 10, 11 ja uudemmissa versioissa.
- `win-x64` toimii **ajan tasalla** 64-bittinen Windows-käyttöjärjestelmä versiossa 10, 11, Server 2016+ ja uudempi.

Tietenkin, vaikka sinulla ei olisi OS-spesifistä pakettia OS-arkkitehtuuriyhdistelmää varten, voit aina asentaa sopivan paketin. ET juoksee itseäsi ja ajaa yleistä ASF-makua, mikä on myös tärkein syy siihen, miksi se on alun perin olemassa. Generic ASF build is platform-agnostic and will run on any platform that has a working .NET runtime. Tämä on tärkeää huomata - ASF vaatii .NET ajoaika, ei mitään tiettyä käyttöjärjestelmää tai arkkitehtuuria. Esimerkiksi, jos käytät 32-bittinen Windows sitten huolimatta ei omistettu `win-x86` ASF versio, voit silti asentaa . ET SDK in `win-x86` versio ja suorita yleinen ASF vain hienosti. Emme yksinkertaisesti voi kohdistaa jokaista OS-arkkitehtuuriyhdistelmää, joka on olemassa ja jota joku käyttää, joten meidän on piirrettävä jonnekin. x86 on hyvä esimerkki tästä linjasta, koska se on vanhentunut arkkitehtuuri ainakin vuodesta 2004.

Jos haluat täydellisen listan kaikista tuetuista alustaista ja käyttöoikeuksista .NET 10.0, vieraile **[release notes](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md)**.

---

## Kiitoaikaa koskevat vaatimukset

Jos käytät OS-pakettia, sinun ei tarvitse huolehtia ajoaikaa koskevista vaatimuksista, koska ASF aina laivoilla, joilla on vaadittu ja ajantasainen ajoaika, joka toimii kunnolla niin kauan kuin sinulla on **[. ET Edellytykset](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** asennettu ja ajan tasalla. Toisin sanoen, **sinun ei tarvitse asentaa . ET ajo tai SDK**, koska OS-kohtaiset rakennukset vaativat vain natiivi OS riippuvuuksia (Edellytykset) ja mitään muuta.

Kuitenkin, jos yrität ajaa **geneerinen** ASF paketti, sinun täytyy varmistaa, että .NET ajoaika tukee alustan vaaditaan ASF.

ASF ohjelmana kohdennetaan **.NET 10.0** (`verkko10.`) juuri nyt, mutta se voi kohdistaa uudemman alustan tulevaisuudessa. `verkko10,0` on tuettu 10.0.100 SDK:sta (10.0. ajo), vaikka ASF voisi mieluummin **viimeisin ajoaika koontihetkellä**, joten sinun tulee varmistaa, että sinulla on koneellasi saatavilla **[uusin SDK](https://dotnet.microsoft.com/download)** (tai ainakin suoritettava). Tavallinen ASF-variantti voi kieltäytyä käynnistämästä, jos ajoaikasi on vanhempi kuin määritelty minimi tuettu versio koosteen aikana.

Jos olet epävarma, tarkista, mitä **[jatkuva integrointi käyttää](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** GitHubin ASF-julkaisujen kokoamiseen ja käyttöönottoon. Löydät `dotnet --info` ulostulon jokaisesta rakennuksesta osana .NET vahvistusvaihetta.