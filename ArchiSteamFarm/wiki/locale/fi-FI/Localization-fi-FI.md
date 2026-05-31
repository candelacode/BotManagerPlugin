# Lokalisointi

ASF on powered by Crowdin palvelu, joka mahdollistaa sen, että kaikki voivat auttaa kääntämään ASF kaikille kielille puhutaan maailmanlaajuisesti. Saat yksityiskohtaisemman selvityksen siitä, miten Crowdin toimii, tutustu **[Crowdin johdantoon](https://support.crowdin.com/crowdin-intro)**.

Jos olet kiinnostunut siitä, mitä parhaillaan tapahtuu, voit tarkistaa **[ASF Crowdin aktiviteetti](https://crowdin.com/project/archisteamfarm/activity_stream)**.

---

## Soveltamisala

Alustamme tukee tärkeimmän ASF-ohjelmamme lokalisointia sekä kokonaista lokalisoitavaa sisältöä, jota tarjoamme yhdessä sen kanssa. Tämä sisältää erityisesti meidän ASF-WebConfigGenerator, ASF-ui sekä meidän wiki. Kaikki tämä on mahdollista kääntää kautta kätevä crowdin käyttöliittymä.

---

## Rekisteröityminen

Jos haluat auttaa ASF:ää joko kääntämällä, tarkistamalla tai hyväksymällä käännöksiä, ole hyvä ja rekisteröidy meidän **[Crowdin projektin sivulla](https://crowdin.com/project/archisteamfarm)**. Rekisteröinti on helppoa ja täysin ilmainen! Kirjautumisen jälkeen voit valita kieliä, joihin haluat saada määrityksen, sitten siirtyä ASF jouset ja auttaa muuta yhteisöä kääntämällä ASF kaikille suosituimpia kieliä!

---

### Kääntäminen

Jos valitsemasi kieli puuttuu vielä joistakin kielistä, voit napata ne ja aloittaa käännöksen työstämisen. Yritimme tehdä parhaamme sen hyväksi, että käännökset olisivat joustavia, Siksi monet merkkijonot sisältävät ylimääräisiä muuttujia, jotka ASF antaa aikana - ne on suljettu suluissa numero, kuten `{0}`. Tämän avulla voit muuttaa merkkijonon oletuksena olevaa ASF-muotoa, esim. siirtämällä ASF:n tarjoamaa muuttujaa paikassa, joka täyttää kielesi ja käännöksesi sen sijaan, että se olisi pakotettu tiukkaan yhteyteen ja muotoon. Tämä on erityisen tärkeää RTL-kielillä, kuten heprealla.

Voit esimerkiksi olla merkkijono, kuten:

> Meillä on {0} pelejä maatilalle.

Mutta perustuu omalla kielelläsi, seuraava lause voisi olla järkevä:

> Tilan pelien määrä on yhtä suuri kuin {0}.

Tai:

> {0} on maatilan pelien määrä.

Joustavuus on varattu erityisesti sinulle, joten voit hieman muuttaa ASF lausetta sopivaksi kielesi paremmin ja siirtää ASF antanut numeron tai muita tietoja paikassa, joka sopii käännös (sen sijaan kääntää kunkin osan itsenäisesti). Tämä parantaa käännösten yleistä laatua.

---

### Uudelleentarkastelu

Jos joku muu on jo kääntänyt merkkijonon, voit äänestää sen puolesta. Äänestyksen avulla on mahdollista valita paras vaihtoehto käännöksestä, sijaan kiinni alkuperäisen ehdotuksen - tämä parantaa yleistä käännöksen laatua entisestään. Voit äänestää jo saatavilla olevista ehdotuksista tai ehdottaa omaa käännöstäsi, joka menee saman prosessin läpi. Lopulta valitaan lopullinen merkkijono joko perustuu eniten äänestetty ehdotus, tai valinta oikolukija valittu kyseiselle kielelle, joka henkilökohtaisesti hyväksyy annettu käännös (perustuu myös äänestyksiä).

**Sinun ei tarvitse hyväksyntää nähdäksesi käännetyt merkkijonot ASF**. Hyväksyntä tarkoittaa yksinkertaisesti sitä, että joku meistä luotti on tarkastellut sisältöä, kuten - poiminut lopullisen version käännöksestä. On täysin hienoa, että yhteisölähtöisiä käännöksiä ei hyväksytä, missä äänestät parhaan käännöksen puolesta. Niin kauan kuin se on käännetty, kaikki on hyvin! Ja jos luulet, että nykyinen käännös on huono, voit aina äänestää parempi, tai ehdottaa yksi itse.

---

### Oikoluku

On hyvä ajatus saada johdonmukainen käännös, vaikka se voisi ottaa vapauden yhteisön tarkastelu/äänestysprosessi edellä selitetään. Tämä johtuu pääasiassa siitä, että väärät käännökset, jotka eivät välttämättä ole huonoja, voivat saada niin paljon ääniä, että ei ole enää mahdollista ehdottaa parempaa käännöstä, vaikka jollakulla olisi sellaista.

Jos sinulla on aiempia maksuosuudet Crowdin tai jokin muu lokalisointi alusta/palvelu, että voimme tarkistaa ja olettaa, että luotettava, olemme iloisia antaessamme sinulle lukijan todisteen pääsyn tietylle kielelle, jota annat, joten voit hyväksyä annetun käännöksen ja tehdä siitä johdonmukainen. Todisteiden lukeminen ei ole helppo tehtävä, varsinkin koska ASF voi olla hyvin "tekninen" ajoittain ja todella vaikea kääntää, mutta ymmärrämme, että sitä tarvitaan usein täydelliseen käännökseen. Siksi jos voit auttaa todiste lukea annetun kielen, **[kerro meille](https://crowdin.com/messages/create/13177432/240376)**, mutta pitää mielessä, että sinun täytyy varmuuskopioida pyyntösi aiemman lokalisointi maksuosuudet, että voimme tarkistaa (e. . työskentelevät ASF lokalisointi Crowdiin, tai minkä tahansa muun projektin). Voimme myös sallia edistyneempien käyttäjien poimia alustavan näytön lukemisen, jos tunnemme ne henkilökohtaisesti ja he pystyvät tekemään yhteistyötä muun yhteisön kanssa lokalisoida ASF tällä kielellä parhaiten.

Yleiset säännöt koskevat todisteiden lukemista - älä kiirehdi, kuuntele käyttäjiäsi, työskennellä projektipäällikkö, ratkaista ongelmia, varmista, että teet asiat paremmin ja ei huonommin.

---

### Ongelmat

Jos sinulla on ongelmia erityisesti käännös, esim. et tiedä miten kääntää se, hyväksytty käännös on virheellinen, tarvitset tarkempia yhteydessä, tai vastaava, lähetä kommentti tietyn merkkijonon alle ja merkitse se [X] Issue.

**Ole hyvä ja vältä vikamerkkiä, jos et tarvitse teknistä/kehitysselitystä tai admin action**. Olet vapaa käyttämään kommentteja keskusteluun, joka liittyy käännös annetun merkkijonon, mutta ongelmaa tulee käyttää vain silloin, kun tarvitset lisää teknistä selitystä tai hallinnoijan korjausta, ja se tyypillisesti liittyy joku, joka ei edes puhu kieltä olet kääntää, niin pitäkää kiinni englannista kirjoittaessanne, kun kirjoitamme huomautuksen (jotta voimme ymmärtää, mitä asia on).

Tällä hetkellä on neljä tuettua tyyppistä ongelmaa:
- Yleinen kysymys - kaikkeen muuhun, joka ei sovi mihinkään ongelmaan. Yleensä tätä tyyppiä **tulisi välttää**, ikään kuin ongelma ei sovi sitten se on erittäin todennäköistä **ei** käännösongelma. Tämä vaihtoehto on kuitenkin saatavilla kaikissa muissa tapauksissa.
- Nykyinen käännös on väärä - tätä pitäisi käyttää **vain** jos käännös oli valmiiksi hyväksytty todiste lukija jo, ja uskot, että se on väärin, esimerkiksi se on typo tai sinulla on voimassa ehdotus miten parantaa sitä. Tätä tyyppiä ei saa koskaan käyttää käännöksissä, joita yhteisö käyttää (äänestys) kuten tässä tapauksessa sinun pitäisi ottaa yhteyttä käyttäjän tietyn käännöksen ja pyytää häneltä korjausta, tai yksinkertaisesti äänestää paremmasta käännöksestä, kuten kohdassa todetaan. Me poistamme käännöksen hyväksymisen ja ilmoitamme kielestä vastaavalle asianmukaiselle lukijalle, jotta voimme ottaa huomioon kommenttisi ja tarkistaa sen uudelleen.
- Asiayhteydellisten tietojen puuttuminen - tätä sinun pitäisi käyttää, jos et ole varma, mikä osa ASF olet kääntänyt, mikä on tietyn merkkijonon konteksti tai sen tarkoitus. Tämä tyyppi pitäisi käyttää vain ASF kehitys, se tarkoittaa, että tarvitset teknistä apua, koska et ole varma, miten sinun pitäisi kääntää annettu merkkijono.
- Virheitä lähdemerkkijonossa - tätä tulee käyttää vain, jos uskot, että alkuperäinen (English) merkkijono on virheellinen. Melko harvinaisia, mutta me kaikki emme puhu englantia natiivisti. niin voit vapaasti käyttää sitä, jos sinulla on yleinen käsitys siitä, miten sitä voitaisiin parantaa. Vaihtoehtoisesti, koska tämä liittyy tiukasti kehitykseen, voit käyttää **[GitHub ongelmia](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** tähän tarkoitukseen, jos haluat.

---

### Käännöksen edistyminen

Jokaisella kielellä on kaksi valmiustasoa - käännös, ja todistusaineisto.

Kieltä pidetään **käännettynä** , kun sen kääntämisen edistyminen saavuttaa 100%. Tässä vaiheessa jokaisella lokalisoitavalla ASF:n käyttämällä merkkijonolla on oikea merkitys, mikä on hienoa. Kuitenkin joka ei tarkoita, että ei ole parantamisen varaa - yhteisön äänestys on käytössä koko ajan, ja voit silti ehdottaa parempaa käännöstä jo käännetyt osat, sen lisäksi, että äänestetään olemassa olevista äänestyksistä. Huomioithan, että täysin käännetyt kielet voivat silti pudota alle 100% kun muutamme olemassa olevia kieliä tai lisäämme uusia kieliä kehityksen aikana. Voit määrittää asianmukaisia crowdin ilmoituksia, jos haluat vastaanottaa sähköpostia kun näin tapahtuu.

Valituilla kielillä voi olla sopivia kielenlukijoita, jotka vahvistavat käännökset ja hyväksyvät lopulliset versiot. Tämä on lopullinen pass jälkeen käännös tapahtuu ja mahdollistaa edelleen parantaa lokalisointi.

ASF sisältää tietyn kielen **mahdollisimman pian**, mikä tarkoittaa, että sitä ei tarvitse hyväksyä, tai jopa 100% käännetty. Varsinaiset merkkijonot, joita käytetään ovat aina suosituimpia äänten osalta, ellei valittu oikolukija päätetty toisin (harvinainen). Näin ollen näet yrityksesi sisällytetään aivan seuraava ASF julkaisu - meidän automaatiojärjestelmät yhdistää käännökset Crowdin takaisin ASF repo päivittäin.

---

## Puuttuvat kielet

Oletuksena ASF projekti on avoin käännös vain top 30 kielet, joita puhutaan maailmanlaajuisesti. Jos haluat lisätä toisen (tai paikallisen murteen jo käytettävissä olevaan), **[kerro meille](https://crowdin.com/messages/create/13177432/240376)** ja me lisäämme sen ASAP. Emme halua avata useita satoja eri kieliä, jos kukaan ei aio kääntää niitä, siksi rajoitamme sen johonkin oikeudenmukaiseen numeroon. Älä epäröi ottaa yhteyttä meihin, jos haluat kääntää joitakin ei-listattu kieli, meidän on erittäin helppo lisätä toinen. Varmista vain, että sinulla on todellista tahtoa ja päättäväisyyttä kääntää ASF kielellesi, ennen kuin päätät ottaa yhteyttä meihin.

Jos haluat täydellisen luettelon kaikista käytettävissä olevista kielistä, jotka ASF voidaan kääntää, **[klikkaa tästä](https://developer.crowdin.com/language-codes)**.

---

## Pluralisointi

Jokaisella kielellä on omat sääntönsä moniarvoisuuden suhteen. Nämä säännöt löytyvät **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** -sivustosta, joka määrittää niiden lukumäärän ja täsmälliset kieliolosuhteet.

Teemme parhaamme tarjotaksemme sinulle joustavan lokalisoinnin, ja niin kauan kuin mahdollista, tähän sisältyy myös monikkomuoto. Esimerkiksi me kääntää seuraavat merkkijono puolaksi tänään:

> Julkaistu {PLURAL:n·{n} kk{n} kks} sitten

`PLURAL` avainsana täällä on käsitelty erityisellä tavalla, koska sen avulla voit sisällyttää kaikki monikkomuodot, joita kielesi tukee. Jos katsot CLDR, huomaat, että Englanti on vain 2 kardinaalilomakkeet - "yksi" ja "muu". And as you can see above, we have both of those defined - `{n} month` and `{n} months`.

Kuitenkin meidän puolan kieli todella sisältää 4 niistä - "yksi", "muutamat", "monet" ja "muu". Tämä tarkoittaa sitä, että meidän pitäisi määritellä kaikki ne loppuun. Lokalisointi työkalut ovat jo tarpeeksi älykkäitä valita sopiva monikkomuoto perustuu kielisääntöihin, siksi sinun tarvitsee vain määritellä kaikki ne käännös:

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

This way we've defined all 4 plural forms for our Polish language, and since our localization library already knows the exact rules, it'll properly use the correct form for provided `{n}` number.

Ei ole pakollista määritellä kaikkia kielesi käyttämiä monikkomuokia. Jos sitä ei ole, lokalisointikirjastomme käyttää paikassaan viimeksi määriteltyä lomaketta. Se on hyvä idea määritellä kaikki monikkomuodot, joita kielesi käyttää, mutta joissakin tapauksissa jäljelle jäävät monikkomuodot voivat olla samat kuin viimeinen, jolloin niitä ei tarvitse toistaa. Meidän edellä olevassa esimerkissä se oli pakollinen, koska "muu" muodossa puolaksi kuukausia on "miesia¶ ca", eikä "miesietään" kuten "monina".

---

## Wiki

Meidän crowdin alustan avulla voit myös lokalisoida jopa wiki itse. Tämä on erittäin tehokas työkalu, koska sen avulla voit luoda koko ASF dokumentaatio äidinkielellesi, ratkaista tehokkaasti viimeinen kysymys, kun se tulee ASF lokalisointi. Yhdessä ohjelman käännöksen ja sen kaikkien osien kanssa lokalisointi on valmis.

Wiki on hieman erikoinen tässä suhteessa, koska se on online-apua, jossa sinun ei tarvitse kiinni alkuperäisestä lauseesta liikaa. Tämä tarkoittaa, että haluat olla mahdollisimman luonnollinen omalla kielelläsi, ja toimittaa alkuperäisen merkityksen ja apua - ei välttämättä kiinni alkuperäisestä merkkijono, käytetyt sanat ja todellinen välimerkkejä. Älä pelkää kirjoittaa merkkijonoa uudelleen joksikin paljon luonnollisemmaksi omalla kielelläsi, niin kauan kuin pidät yleisen suunnan ja apua sisältyy lauseeseen.

---

### Globaalit linkit

Meidän crowdin alustan avulla voit myös mukauttaa alkuperäistä tekstiä, jotta se osoittaa uusia (lokalisoitu) sijainteja.

ASF sisältää linkkejä lähes jokaisella sivulla helpottaa navigointia sekä sivupalkin oikealla puolella. Mahtava tosiasia on, että voit muokata kaikkea, "korjaaminen" linkkejä osoittaa asianmukaista lokalisoituja sivuja omalla kielelläsi. Se vaatii olla hieman varovainen tekemään, mutta se on mahdollista.

Esimerkiksi ASF **[kotisivu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)** sisältää muun muassa seuraavanlaisen teksin:

> Jos olet uusi käyttäjä, suosittelemme aloittamaan **[asettamalla](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** -opas.

Joka on alun perin kirjoitettu:

```markdown
Jos olet uusi käyttäjä, suosittelemme aloittamaan **[asetus päälle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** -oppaan avulla.
```

On crowdin, ensimmäinen asia sinun pitäisi tehdä, on menossa editorin asetukset ja varmistaa, että HTML tagit on asetettu "Näytä" sinulle. Tämä on erittäin tärkeää, jos päätät lokalisoida wikin.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Nyt, kääntämisen aikana crowdin, riippuen muotoilusta, näet ASF linkkejä tekstissä joko seuraavasti:

* Teksti kääntää yhdessä HTML-tageja (suurin osa merkkijonoja, jossa vain osa lause on linkki)
* Käännettävä merkkijono, jossa on linkki `Piilotetut tekstit` -> `Linkin osoitteet` (harvinainen, jossa koko merkkijono on linkki, yleisin sivupalkissa - ne vaativat oikolukijan pääsy kääntää, surullisesti)

Yllä olevassa esimerkissä se on ensimmäinen tapaus (koska vain "perustaminen" on linkki), joten crowdin näemme sen seuraavasti:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Riippumatta tapauksesta, ensin sinun pitäisi kopioida lähdemerkkijono ja kääntää se tavalliseen tapaan jättäen koko HTML (jos läsnä) ennallaan. Tämä olisi esimerkki puolan kielen käännöksestä:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Nyt, jos linkki on yleinen linkki, joka osoittaa Wikin ulkopuolella (esim. viimeisimpään ASF julkaisuun), voit jättää sen koska se on koska et halua muokata sitä. Voit tallentaa sen ja siirtyä eteenpäin.

Kuitenkin, jos linkki **tekee** osoittaa edelleen Wikin sisällä, kuten edellä, voit oikeasti korjata sen osoittaa uusi (lokalisoitu) sijainti. Voit tehdä tämän lisäämällä huolellisesti `-locale` kohteen URL-osoitteeseen `<a>` , kuten alla:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Ole erittäin varovainen tästä, ja varmistaa, että URL todellakin on olemassa, koska jos teet virheen, että linkki lopettaa toimintansa. Jos onnistut, sinulla on nyt täysin toimiva käännös linkin osoittaa käännetty (meidän tapauksessa `Setting-up-pl-PL`) sivu.

Yllä olevien vaiheiden tekeminen kääntää HTML takaisin merkitsemiseen:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

Ja lopuksi wikin teksti:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

Kun HTML ei ole olemassa (toinen tapaus), Tämä on vielä helpompaa, koska voit vain mennä `piilotettuja tekstejä` -> `Linkin osoitteet`.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

Sieltä voit helposti korjata linkin osoittamaan uuteen sijaintiin ilman, että se edes häiritsee HTML:ää lainkaan:

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Paikalliset linkit

Eri puolilla wikiä löydät myös paikallisia linkkejä, jotka viittaavat tiettyyn osaan asiakirjan. Näihin linkkeihin kuuluu `#` -merkki, joka ilmaisee verkkoselaimen, että sen pitäisi siirtyä asiakirjan kyseiseen osioon.

Nämä ovat nyt erityistapauksia, koska nämä linkit perustuvat nykyisen asiakirjan osien nimiin. Vaikka URL-osoitteet meillä on yleissopimus lisätä `-locale` URL-osoitteeseen, ja se toimii kaikkialla, osion nimet käännetään sinulle ja muille ihmisille, joten sinun täytyy varmistaa, että ne osoittavat oikea sijainti.

Voit esimerkiksi löytää `#introduction` -linkin meidän **[asetuksista](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#introduction)** osiosta:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Koska aiomme kääntää "Johdanto" sana "Wprowadzenie" meidän puolankielellä, meidän täytyy korjata tämä linkki, koska se lopettaa toiminnan hetkellä teemme tämän.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

Tällä tavoin paikallinen linkki toimii edelleen, koska se nyt osoittaa nimi osio, jota käytämme. Voit korjata linkkejä HTML-tageihin täsmälleen samalla tavalla.

---

### Koodilohkot

Ole erittäin varovainen, kun käännät lauseita `<code></code>` -kuution sisällä. Koodilohko ilmaisee kiinteät ASF koodinimet tai termit, joita ei pitäisi kääntää. Esimerkiksi:

> Tämä on erityisen hyödyllistä, jos sinulla on paljon lunastavia avaimia ja olet varmasti lyönyt <code>RateLimited</code> -tilan ennen kuin olet tehnyt koko erän.

Kuten näet, `RateLimited` sana tässä on koodilohkon sisällä ja ilmoittaa sisäisen ASF koodin tilaa, jota ei pitäisi kääntää. Samoin sinun ei pitäisi kääntää muita koodilohkoja, kuten asetusten ominaisuuksien nimiä (esim. `TradingPreferences`), enum jäseniä (e. . `Vakaa` ja `PreRelease` vaihtoehtoja `UpdateChannel`) ja samoin.

Kuitenkin, vain koska näitä sanoja ei pitäisi kääntää, ei tarkoita, ettet voi lisätä asianmukaista käännöstä vieressä, esimerkiksi suluissa.

> Ta funkcja jest wyjątkowo użyteczna w przypadku aktywacji dużej ilości kluczy i gwarancji napotkania statusu <code>RateLimited</code> (zbyt częstej aktywacji) przed ukończeniem całej partii.

Kuten näette edellä, olemme lisänneet "zbyt cze stej aktywacji", kirjaimellisesti "liian usein aktivointi" `RateLimited` vieressä kääntääkseen tämän tilan ystävällisellä tavalla, säilyttäen samalla alkuperäisen ASF tarkoittaen sitä, että käyttäjä voi nähdä käytön aikana. Samalla tavalla voit kääntää/selittää muita, samankaltaisia tapauksia eri sanoja ja lauseita.

Jos uskot, että jotain sopimatonta on sisällytetty koodilohkoon, tai että on olemassa teksti, joka ei ole koodilohkossa mutta jonka pitäisi olla sen sisällä, voit vapaasti kysyä joukosta luomalla sopiva **[ongelma](#issues)**. Tämä on myös käytännöllinen esimerkki paikallisen yhteyden käytöstä.

---

## Sali fame

Haluaisimme osoittaa ikuisen kiitollisuutemme ihmisille, jotka ovat viettäneet merkittävän määrän aikaansa ja tahtoaan tehdäkseen ASF:n lokalisoinnista paremman. Heidän ponnistuksensa on uskomatonta, ja voit nauttia täydellisistä käännöksistä, mukaan lukien wiki, enimmäkseen niiden ansiosta. Se on tunnusmerkki arvostuksesta, kaikille tässä luetelluille henkilöille tarjotaan vapaa pääsy **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** -ominaisuuteen **[pyynnöstä](https://crowdin.com/messages/create/13177432/240376)**.

| Avustaja                                                   | Kielet          |
| ---------------------------------------------------------- | --------------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, Espanja |
| **[Dead_Sam](https://crowdin.com/profile/Dead_Sam)**       | Portugali (BR)  |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | Kiina (CN)      |
| **[DragonTaki](https://crowdin.com/profile/dragontaki)**   | Kiina (TW)      |
| **[LittleFreak](https://crowdin.com/profile/littlefreak)** | Saksa           |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | Venäjä, Ukraina |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT, Saksa   |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | Kiina (HK)      |

Kiitos kaikille parantaa meidän ASF lokalisointi laatu!