# Suorityskyky

ASF:n ensisijaisena tavoitteena on viljely mahdollisimman tehokkaasti, perustuu kahdentyyppisiin tietoihin, joita se voi käyttää - pieni joukko käyttäjän toimittamia tietoja, joita ASF ei voi arvata tai tarkistaa omin avuin, ja suurempi joukko tietoja, jotka voidaan automaattisesti tarkistaa ASF.

Automaattisessa tilassa ASF ei salli sinun valita pelejä, jotka pitäisi viljellä, eikä voit vaihtaa kortteja maatalouden algoritmi. **ASF tietää paremmin kuin sinä, mitä sen pitäisi tehdä ja mitä päätöksiä sen pitäisi tehdä, jotta maatilan mahdollisimman nopeasti**. Sinun tavoitteena on asettaa config ominaisuudet kunnolla, koska ASF ei voi arvata niitä omasta, kaikki muu on katettu.

---

Jokin aika sitten venttiili muutti algoritmia korttien putoamiseksi. Siitä lähtien voimme luokitella höyrytilejä kahteen luokkaan: **joissa** -korttia on rajoitettu, ja **ilman**. Ainoa ero näiden kahden tyypin välillä on se, että tilit joilla on rajoitettu kortti putoaa ei saa mitään korttia annetusta pelistä ennen kuin he pelaavat peliä vähintään `X` tuntia. Näyttää siltä, että vanhemmilla tileillä, jotka eivät koskaan pyytäneet hyvitystä, on **rajoittamaton kortin pudotukset**, kun uudet tilit ja ne, jotka pyysivät hyvitystä, ovat **rajoittaneet kortin pudotuksia**. Tämä on kuitenkin vain teoriaa, eikä sitä pitäisi pitää sääntönä. Siksi **ei ole selvää vastaus**, ja ASF luottaa siihen, että **sinä** kerrot sille mikä tapaus on sopiva tilillesi.

---

ASF sisältää tällä hetkellä kaksi maatalouden algoritmia:

**`Yksinkertainen`** algoritmi toimii parhaiten tileille, joilla on rajoittamattomia korttien pudotuksia. Tämä on ASF:n käyttämä ensisijainen algoritmi. Botti löytää pelejä maatilalle, ja maatiloille ne yksi-kerralla, kunnes kaikki kortit on pudonnut. Tämä johtuu siitä, että kortti putoaa vauhtia, kun maatalouden useampi kuin yksi peli on lähellä nollaa ja täysin tehoton.

**`Complex`** on uusi algoritmi, joka on toteutettu auttamaan rajoitettuja tilejä maksimoimaan voitot. ASF käyttää ensin standardia **`Simple`** algoritmia kaikissa peleissä, jotka ohittivat `TuntiUntilCardDrops` tuntia peliaikaa, sitten jos ei pelejä >= `TunnitUntilCardDrops` tuntia on jäljellä, se maatiloi kaikki pelit (enintään `32` raja) < `TuntiUntilCardDrops` tuntia jäljellä samanaikaisesti, kunnes jokin niistä osuu `TuntiUntilCardDrops` tunnin merkki, sitten ASF jatkaa silmukkaa alusta alkaen (käytä **`Simple`** tuossa pelissä, palaa samanaikaisesti < `TuntiUntilCardDrops` ja niin edelleen). Voimme tässä tapauksessa käyttää useita pelejä maanviljely viemällä tuntia pelejä meidän täytyy tilalla asianmukaista arvoa ensin. Muista, että tuotantotuntien aikana ASF **ei ole** maatilan kortteja, joten se ei myöskään tarkista mitään korttia putoaa kyseisenä aikana (edellä mainituista syistä).

Tällä hetkellä ASF valitsee korttien maanviljelyn algoritmi perustuu puhtaasti `HoursUntilCardDrops` config ominaisuus (joka on asetettu ****). Jos `tuntia UntilCardDrops` on asetettu `0`, **`Yksinkertainen`** algoritmi käytetään muuten **`Monimutkainen`** algoritmi käytetään sen sijaan - konfiguroidaan soittoaikaa kaikissa peleissä määrättyyn määrään tunteja ennen kasvatusta ne korttien putoamiseksi.

---

### **Ei ole selvää vastausta, joka algoritmi on parempi sinulle**.

Tämä on yksi syy miksi et valitse korttien maatalouden algoritmi, sen sijaan kerrot ASF jos tili on rajoitettu putoaa tai ei. Jos tilillä on rajoittamattomia pudotuksia, **`Simple`** algoritmi **toimii paremmin** tällä tilillä, koska emme tuhlaa aikaa tuodessamme kaikki pelit `X` tuntia - kortit pudotussuhde on lähes 0% kun maatalouden useita pelejä. Toisaalta, jos tilisi kortin tippoja on rajoitettu, **`Complex`** algoritmi on sinulle parempi, koska ei ole mitään järkeä maatalouden yksin jos peli ei tavoita `TuntiUntilCardDrops` tuntia vielä - joten me maatila **peliaika** ensimmäinen, **ja** korttia yksinään.

Älä sokeasti aseta `TuntiUntilCardDrops` vain koska joku käski sinua - tehdä testejä, verrata tuloksia ja perustuu saamiisi tietoihin, päätä, minkä vaihtoehdon pitäisi olla sinulle parempi. Jos laitat siihen vähän vaivaa, varmistat, että ASF toimii mahdollisimman tehokkaasti tilillesi, mikä on luultavasti mitä haluat, kun otetaan huomioon, että luet tätä wikisivulta juuri nyt. Jos olisi olemassa ratkaisu, joka toimii kaikille, sinulle ei annettaisi vaihtoehtoa - ASF päättäisi itse.

---

### Mikä on paras tapa saada selville, jos tilisi on rajoitettu?

Varmista, että sinulla on joitakin pelejä **ei playtime kirjataan** tilalle, mieluiten 5+, ja suorita ASF `tunninUntilCardDrops` ja `0`. Olisi hyvä idea, jos et pelaa mitään aikana maatalouden aikana tarkempia tuloksia (parasta ajaa ASF yöllä). Anna ASF maatilalla nuo 5 peliä, ja sen jälkeen tarkistaa loki tuloksia.

ASF ilmoittaa selvästi, kun kortti tietyn pelin on pudonnut. Olet kiinnostunut nopein kortti pudotus saavuttaa ASF. Esimerkiksi, jos tilisi on rajoittamaton, ensimmäinen kortti pudotus pitäisi tapahtua noin 30 minuutin kuluttua aloitat maanviljelyn. Jos huomaat **vähintään yksi** peli, joka ei pudota kortti näissä alkuperäisissä 30 minuuttia, sitten tämä on osoitin, että tilisi on **ei** rajoitettu ja pitäisi käyttää `TunsUntilCardDrops` of `0`.

Toisaalta, kun taas jos huomaat, että **joka** peli kestää vähintään `X` tuntia ennen kuin se pudottaa ensimmäisen kortin, sitten tämä on indikaattori sinulle mitä sinun pitäisi asettaa `Tunnit UntilCardDrops`. Suurin osa rajoitetuista käyttäjistä (jos ei kaikki) vaatii vähintään `3` tuntia pelattavaa korttia ja tämä on myös oletusarvo `HoursUntilCardDrops` -asetukselle.

Muista, että peleissä voi olla eri pudotusnopeus, tästä syystä sinun pitäisi testata, jos teoria on oikeassa **vähintään** 3 peliä, mieluiten 5+ varmistaaksesi, että et pääse vääriin tuloksiin sattumalla. Yhden pelin pudotus alle tunnissa on vahvistus siitä, että tilisi **ei ole** rajoitettu ja että voit käyttää `TuntiaUntilCardDrops` `0`, mutta sen vahvistamiseksi, että tilisi **on** rajoitettu, tarvitset ainakin useita pelejä, jotka eivät pudota kortteja, kunnes osut kiinteän merkin.

On tärkeää huomata, että aiemmin `tunnitUntilCardDrops` oli vain `0` tai `2`, ja tämän vuoksi ASF:llä oli yksi `CardDropsRajoitettu` ominaisuus, jonka avulla voitiin vaihtaa näiden kahden arvon välillä. Viimeaikaisten muutosten myötä huomasimme, että paitsi suurin osa käyttäjistä vaatii nyt `3` tuntia edellisen `2` tilalle, mutta myös että `TuntiUntilCardDrops` on nyt dynaaminen ja voi osua mihin tahansa arvoon tilikohtaisesti.

Loppujen lopuksi tietenkin päätös on teidän vastuullanne.

Ja tehdä siitä vielä pahempaa - olen kokenut tapauksia, kun ihmiset siirtyivät rajoitetusti tilaan ja päinvastoin - joko Steam-bugin takia (voi, kyllä, meillä on monia niistä), tai koska joitakin logiikan muutoksia Valve. Joten vaikka olisit vahvistanut, että tilisi on rajoitettu (tai ei), älä usko, että se pysyy näin - jotta voidaan siirtyä rajoittamaton rajoittaa se riittää pyytämään hyvitystä. Jos sinusta tuntuu, että aiemmin määritetty arvo ei enää ole asianmukainen, voit aina tehdä testin uudelleen ja päivittää sen mukaisesti.

---

Oletuksena ASF olettaa, että `tuntia UntilCardDrops` on `3`, koska negatiivinen vaikutus tämän asettamisesta `3` kun sen pitäisi olla vähemmän on pienempi kuin tehdään toisin päin. Tämä johtuu siitä, että pahimmassa mahdollisessa tapauksessa tuhlaamme `3` tuntia maataloutta `32` -peliä kohden, verrattuna tuhlaamiseen `3` tuntia maanviljelystä jokaista peliä kohti, jos `TuntiUntilCardDrops` asetettiin oletuksena `0`. Sinun pitäisi kuitenkin edelleen virittää tätä muuttujaa vastaamaan tiliäsi maksimaalisen tehokkuuden takaamiseksi. koska tämä on vain sokea arvaus, joka perustuu mahdollisiin haittoihin ja suurimpaan osaan käyttäjistä (niin yritämme oletusarvoisesti valita "pienemmän pahan".

Tällä hetkellä kaksi edellä mainittua algoritmia riittää kaikkiin tällä hetkellä mahdollisiin tilitilanteisiin, viljelemään mahdollisimman tehokkaasti, minkä vuoksi ei ole tarkoitus lisätä muita viljelmiä.

On mukava huomata, että ASF sisältää myös manuaalisen maatalouden tila, joka voidaan aktivoida `play` -komennolla. Voit lukea siitä lisää **[komennoista](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

## Höyryn glitches

Korttien pudotusalgoritmi ei aina toimi niin kuin sen pitäisi, ja se on täysin mahdollista eri Steam glitches tapahtua, kuten kortit, jotka jätetään rajoitetuille tileille ja kortit, jotka putoavat pelin sulkemiseen tai vaihtamiseen, kortteja ei pudota ollenkaan, kun peliä pelataan, ja samoin.

Tämä osio on lähinnä ihmisille, jotka ihmettelevät, miksi ASF ei tee **X**, kuten nopeasti vaihtaa pelejä maatilan kortteja nopeammin.

Mikä on **Steam glitch** - erityinen toiminto käynnistää **määrittelemätöntä** käyttäytymistä, joka on **, jota ei ole tarkoitettu dokumentoimattomaksi ja jota pidetään loogisena virheenä**. Se **epäluotettava määritelmän**, mikä tarkoittaa, että sitä ei voida toistaa luotettavasti puhtaalla testausympäristöllä, ja siksi, koodattu turvautumatta hakata, jotka pitäisi arvata, kun glitch tapahtuu ja miten taistella sitä / väärinkäyttää sitä. Tyypillisesti se on väliaikainen, kunnes kehittäjät korjaavat logiikan virheen, vaikka jotkut misc glitches voi jäädä huomaamatta hyvin pitkän ajan.

Hyvä esimerkki siitä, mitä pidetään **Steam glitch** ei ole se epätavallinen tilanne, että kortti pudotetaan, kun peli suljetaan, jota voidaan väärinkäyttää jossain määrin tyhjänpäiväisen maisterin pelin ohitustoiminto.

- **Määrittelemätön käyttäytyminen** - et voi sanoa, onko 0 tai 1 korttia pudotetaan, kun käynnistät glitchin.
- **Ei tarkoitettu** - Steam-verkon aiemman kokemuksen ja käyttäytymisen perusteella, joka ei johda samaan käyttäytymiseen yksittäisen pyynnön lähettämisessä.
- **Dokumentoimaton** - se on selvästi dokumentoitu Steam-sivustolla, miten kortteja saadaan, ja **joka ikisessä paikassa** on selvästi todettu, että se on saatu **pelaamalla**, EI lopeta pelejä, saa saavutuksia, pelejä vaihtaa tai käynnistää 32 peliä samanaikaisesti.
- **Pidetty logiikan virhe** - sulkeminen peli (t) tai niiden vaihtaminen ei pitäisi olla lopputulos kortteja pudotetaan, jotka on selvästi todettu saavutettavan **saamassa peliaikaa**.
- **Epäluotettava määritelmällisesti, ei voida toistaa luotettavasti** - se ei toimi kaikille. ja vaikka se olisi toiminut sinulle kerran, se ei voinut enää toimia toisen kerran.

Nyt kun tajusimme, mitä Steam glitch on, ja se, että kortit pudotetaan, kun peli suljetaan **on** yksi, voimme siirtyä toiseen kohtaan - **ASF ei käytä Steam-verkkoa millään tavalla väärin määritelmällä, ja se tekee parhaansa täyttääkseen Steam ToS, sen protokollat ja mikä on yleisesti hyväksytty**. Spamming Steam network with constant game opening/closing requests can be considered a **[DoS attack](https://en.wikipedia.org/wiki/Denial-of-service_attack)** and **directly violates [Steam Online Conduct](https://store.steampowered.com/online_conduct/?l=english)**.

> Steam-tilaajana sinä sitoudut noudattamaan seuraavia menettelytapoja koskevia sääntöjä.
> 
> Et tule:
> 
> Instituutti hyökkää Steam-palvelimella tai muutoin häiritsee Steamia.

Ei ole väliä, pystytkö laukaisemaan Steam-hehkutuksen muilla ohjelmilla (kuten IM), ja se ei myöskään ole väliä, jos olet samaa mieltä kanssamme ja harkita tällaista käyttäytymistä DoS hyökkäys, tai ei - se on venttiili arvioida tätä, mutta jos pidämme sitä hyödyntää/väärinkäyttää ei-tarkoitettu käyttäytyminen liiallisia Steam-verkon pyyntöjä, sitten voit olla melko varma, että venttiili on samanlainen näkemys tästä.

ASF on **ei koskaan** aikoo hyödyntää Steam-räjähdyksiä, väärinkäytöksiä, hakata tai muuta toimintaa, joka näemme **laittomaksi tai ei-toivotuksi** mukaan Steam TS, Steam Online Conduct tai mikä tahansa muu luotettu lähde, joka voisi osoittaa, että ASF toiminta ei ole Steam-verkossa, Kuten on todettu **[osallistuu](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)** -osiossa.

Jos haluat hinnalla millä hyvänsä vaarantaa Steam-tilisi viljelemään muutaman sentin kortteja tavallista nopeammin, niin valitettavasti ASF ei koskaan tarjoa jotain tällaista automaattisessa tilassa, vaikka sinulla on edelleen `toistamassa` **[komentoa](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** , jota voidaan käyttää työkaluksi tehdä mitä tahansa Steam-verkon vuorovaikutuksen suhteen. Emme suosittele hyödyntämään Steam glitches ja hyödyntämään niitä oman hyödyn - ei vain ASF, mutta millä tahansa muulla työkalulla samoin. Loppujen lopuksi se on kuitenkin tilisi ja valintasi mitä haluat tehdä sen kanssa - vain pitää mielessä, että me varoitimme sinua.