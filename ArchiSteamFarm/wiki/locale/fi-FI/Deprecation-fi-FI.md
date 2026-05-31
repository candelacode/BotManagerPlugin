# Deprekaatio

Teemme parhaamme noudattaaksemme johdonmukaista deprecation käytäntöä, jotta sekä kehitystyö että käyttö olisivat paljon johdonmukaisempia.

---

## Mikä on vanhentumis?

Deprecation on prosessi pienempiä tai suurempia rikkovia muutoksia, jotka tekevät aiemmin käytettyjä vaihtoehtoja, argumentteja, toimintoja tai käyttötapauksia vanhentuneita. Vanhentuminen tarkoittaa yleensä sitä, että annettu asia yksinkertaisesti kirjoitettiin uudelleen toiseen (samanlaiseen) muotoon, ja sinun pitäisi varmistaa hyvissä ajoin, että voit tehdä sopiva kytkin siihen. Tässä tapauksessa se on yksinkertaisesti liikkuu annettu toiminnallisuutta sopivampi paikka.

ASF muuttuu nopeasti ja tulee aina paremmaksi. Tämä valitettavasti tarkoittaa, että voimme muuttaa tai siirtää joitakin olemassa olevia toimintoja toiseen osaan ohjelmasta, jotta se voi hyötyä uusista ominaisuuksista, yhteensopivuus tai vakaus. Kiitos että meidän ei tarvitse pysyä vanhentuneita tai yksinkertaisesti tuskallisesti vääriä kehityspäätöksiä, jotka teimme vuosia sitten. Yritämme aina tarjota kohtuullinen korvaus, joka sopii odotettu käyttö aiemmin saatavilla toimintoja, minkä vuoksi vanheneminen on enimmäkseen vaaratonta ja vaatii pieniä korjauksia aiempaan käyttöön.

---

## Vanhenemisvaiheet

ASF seuraa kahta epämuodostuman vaihetta ja tekee siirtymisestä paljon helpompaa ja vähemmän hankalaa.

### Vaihe 1

Vaihe 1 tapahtuu, kun annettu ominaisuus vanhentuu, ja välitön saatavuus toinen ratkaisu (tai kukaan jos ei ole suunnitelmia ottaa se uudelleen käyttöön).

Tässä vaiheessa ASF tulostaa asianmukaisen varoituksen, kun käytetään vanhentuneita toimintoja. Niin kauan kuin se on mahdollista, ASF yrittää jäljitellä vanhaa käyttäytymistä ja pitää sen yhteensopivena. ASF jatkaa tämän toiminnon osalta vaiheessa 1 vähintään seuraavaan vakaaseen versioon. Tämä on hetki, jolloin voit toivottavasti rikkomatta yhteensopivuutta tehdä sopivan kytkimen kaikkiin työkaluihin ja kuvioihin uuden käyttäytymisen tyydyttämiseksi. Voit vahvistaa, teitkö kaikki tarvittavat muutokset siten, että et enää näe vanhentumisvaroitusta.

### Vaihe 2

Vaihe 2 on ajoitettu jälkeen vaiheen 1 edellä selostettu tapahtuu ja vapautuu vakaa vapauttaa. Tämä vaihe sisältää vanhentuneen ominaisuuden täydellisen poistamisen, mikä tarkoittaa, että ASF ei edes ota huomioon, että yrität käyttää vanhentunutta ominaisuutta, sallikaa kunnioittaa sitä, koska sitä ei yksinkertaisesti ole nykyisessä koodissa. ASF ei enää tulosta mitään varoitusta, koska se ei enää tunnista mitä yrität tehdä.

---

## Yhteenveto

Sinulla on enemmän tai vähemmän **koko kuukausi** jotta sopiva kytkin, jonka pitäisi olla enemmän kuin tarpeeksi vaikka olet rento ASF käyttäjä. Sen jälkeen ASF ei enää takaa, että vanhoilla asetuksilla olisi mitään vaikutusta (vaihe 2), tehokkaasti tiettyjen ominaisuuksien lopettaa toiminta kokonaan huomaamatta. Jos käynnistät ASF:n yli kuukauden kestäneen käyttämättömyyden jälkeen, on suositeltavaa **[aloittaa tyhjästä](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** uudelleen, tai lukea kaikki muutokset että olet unohtanut ja manuaalisesti mukauttaa käyttösi nykyiseen.

Useimmissa tapauksissa deprecation varoituksen huomiotta jättäminen ei tee ASF:n yleistä toiminnallisuutta käyttökelvottomaksi, vaan palaamalla oletuskäyttäytymiseen (joka voi tai ei välttämättä vastaa henkilökohtaisia asetuksiasi).

---

## Esimerkki

Siirsimme pre-V3.1.2.2 `--server` **[komentorivin argumentin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** `IPC` **[globaalin konfiguraation ominaisuuden](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**.

### Vaihe 1

Vaihe 1 tapahtui versiossa V3.1.2.2 jossa lisäsimme asianmukaisen varoituksen `--server`. Now-obsolete `--server` argumentti kartoitettiin automaattisesti `IPC: true` globaali config ominaisuus, toimii tehokkaasti täsmälleen samalla tavalla kuin vanha `--server` -kytkin aikaa varten. Tämä mahdollisti sen, että kaikki voivat tehdä sopivan vaihdon, ennen kuin ASF lakkaa hyväksymästä vanhaa argumenttia.

### Vaihe 2

Vaihe 2 tapahtui versiossa V3.1.3.0, heti V3.1.2.9 vakaan jälkeen vaiheessa 1 edellä selitetään. Vaihe 2 aiheutti ASF:n lopettavan `--server` -argumentin tunnistamisen ollenkaan. kohtelemalla sitä kuin kaikkia muita virheellisiä argumentteja hyväksyttäisiin, joilla ei enää ole mitään vaikutusta ohjelmaan. Ihmisille, jotka eivät vieläkään muuttaneet käyttöä `--server` osaksi `IPC: true`, Se sai IPC:n lopettamaan toiminnan kokonaan, koska ASF ei enää tehnyt asianmukaista kartoitusta.