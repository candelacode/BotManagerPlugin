# Kirjaus

ASF sallii sinun määrittää oman mukautetun loggaus moduulin, jota käytetään suoritettaessa aikaa. Voit tehdä niin laittamalla erikoistiedoston nimeltä `NLog.config` sovelluksen hakemistoon. Voit lukea koko dokumentaation NLog **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**, mutta sen lisäksi, että löydät joitakin hyödyllisiä esimerkkejä myös täältä.

---

## Oletusarvoinen loki

Oletuksena ASF on kirjautumassa `ColoredConsole` (standardi lähtö) ja `File`. `Tiedosto` loggaus sisältää `log.txt` tiedoston ohjelman hakemistossa ja `lokit` hakemiston arkistointia varten.

Käyttämällä mukautettua NLog config poistaa automaattisesti ASF asetukset config ohittaa **täysin** oletuksena ASF logging, mikä tarkoittaa, että jos haluat pitää e. . meidän `värikonsoli` tavoite, sinun täytyy määritellä se **itse**. Tämän avulla voit paitsi lisätä **ylimääräistä** loggaus kohteita, myös poistaa käytöstä tai muokata **oletus** niitä.

Jos haluat käyttää ASF oletuskirjautumista ilman muutoksia sinun ei tarvitse tehdä mitään - sinun ei myöskään tarvitse määritellä sitä mukautetussa `NLogissa. onfig`. Viitteen osalta vastaava kovakoodattu ASF-oletuskirjaus olisi kuitenkin seuraava:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir:cached=true}/logs/log.txt" archiveOldFileOnStartup="true" archiveSuffixFormat=".{1:yyyyMMdd-HHmmss}" fileName="${currentdir:cached=true}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- Below becomes active when ASF's IPC interface is started -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="File" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- Below becomes active when ASF's IPC interface is enabled -->
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="History" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## ASF:n integrointi

ASF sisältää muutamia kivoja koodin temppuja, jotka parantavat sen integrointia NLog, jonka avulla voit saalis tiettyjä viestejä helpommin.

NLog-specific `${logger}` muuttuja erottaa aina viestin lähteen - se on joko `BotName` yhdestä botistasi, tai `ASF` , jos viesti tulee suoraan ASF-prosessista. Näin voit helposti kiinni viestejä harkitsee tiettyjä botti(s), tai ASF prosessi (vain) sen sijaan, että ne kaikki perustuvat nimen logger.

ASF yrittää merkitä viestit asianmukaisesti NLog-toimitettujen lokitasojen perusteella, joka mahdollistaa sen, että voit saalis vain tiettyjä viestejä tietyn lokitason sijasta kaikki niistä. Tietysti tietyn viestin lokitasoa ei voi muokata, koska se on ASF hardcoded päätös, kuinka vakava annettu viesti on, mutta voit varmasti tehdä ASF vähemmän / hiljaisempaa, kuten näet.

ASF kirjautuu ylimääräisiä tietoja, kuten käyttäjä-/chat-viestit `Trace` kirjautumistasolla. Oletus ASF kirjaaminen lokit vain `Debug` taso ja ylhäällä, joka piilottaa lisätietoja, koska sitä ei tarvita suurimmalle osalle käyttäjistä, plus kytkimien tuotos, joka sisältää mahdollisesti tärkeämpiä viestejä. Voit kuitenkin hyödyntää näitä tietoja ottamalla `Trace` -kirjaustason uudelleen käyttöön, erityisesti yhdessä kirjautumisen kanssa vain yksi tietty botti valintasi, ja erityinen tapahtuma olet kiinnostunut.

Yleisesti ottaen ASF yrittää tehdä siitä mahdollisimman helppoa ja kätevää, lokiin vain haluamasi viestit sen sijaan, että pakotat manuaalisesti suodattamaan ne kolmannen osapuolen työkalujen, kuten `grep` ja niin edelleen. Määritä NLog oikein kuten alla on kirjoitettu, ja sinun pitäisi pystyä määrittämään jopa hyvin monimutkainen puunkorjuun säännöt mukautettuja kohteita, kuten koko tietokantoja.

Versioinnin osalta ASF yrittää aina lähettää uusimman version NLog joka on saatavilla **[NuGet](https://www.nuget.org/packages/NLog)** ASF julkaisuhetkellä. Sen ei pitäisi olla ongelma käyttää mitään ominaisuuksia, jotka löydät NLog wiki ASF - vain varmista, että käytät myös ajan tasalla ASF.

ASF sisältää osana ASF:n integrointia myös tuen ASF:n NLog -lokitavoitteille, jotka selvitetään jäljempänä.

---

## Esimerkkejä

Alla olevat esimerkit näyttävät, miten voit muokata kirjautumista mieleesi.

Aloittajana käytämme vain **[värikonsoli](https://github.com/nlog/nlog/wiki/ColoredConsole-target)** -tavoitetta. Alustava `NLog.config` näyttää tältä:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Selitys edellä config on melko yksinkertainen - määrittelemme yhden **logging tavoite**, joka on `VäriKonsoli`, sitten ohjaamme uudelleen **kaikki** (`*`) tason `vianjäljitys` ja korkeammalle tasolle `Värikonsoli` tavoite me olemme määritelleet aikaisemmin.

Jos aloitat ASF:n yllä `NLog. onfig` nyt, vain `ColoredConsole` kohde on aktiivinen, ja ASF ei kirjoita `tiedostoon`, riippumatta kovakoodatuista ASF NLog -asetuksista.

Koska emme määrittäneet paljon ominaisuuksia, kuten `layout`, se oli alustettu oletusarvoon sisäänrakennettuun arvoon, tässä tapauksessa `${longdate}¶ ${level:uppercase=true}¶${logger}¶${message}`. Voimme muokata sitä, esimerkiksi kirjautumalla viesti vain:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Jos käynnistät ASF:n nyt, huomaat sen päivämäärän, taso ja loggerin nimi katosi - jättäen vain ASF viestit muodossa `Funktio () Viesti`.

Voimme myös muokata config kirjautuaksesi useampaan kuin yhteen kohteeseen. Kirjaudutaan samaan aikaan `värikonsoliin` ja **[`tiedostoon`](https://github.com/nlog/nlog/wiki/File-target)**

```xml
<?xml versio ="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Debug" writeTo="File" />
  </rules>
</nlog>
```

Ja tehty, me nyt kirjaamme kaiken `ColoredConsole` ja `File`. Huomasitko että voit myös määrittää mukautetun `fileName` ja lisävaihtoehtoja?

Lopuksi, ASF käyttää eri lokitasoja, jotta voit helpommin ymmärtää, mitä on tekeillä. Voimme käyttää näitä tietoja muokataksemme vakavuuskirjautumista. Sanotaan, että haluamme kirjata kaiken (`Trace`) `File`, mutta vain `varoitus` ja yli **[lokitaso](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** `värikonsoli`. Voimme saavuttaa tämän muuttamalla `sääntöjä`:

```xml
<?xml versio ="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Warn" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Trace" writeTo="File" />
  </rules>
</nlog>
```

Se on se, nyt meidän `värikonsoli` näyttää vain varoitukset ja edellä, samalla kun kirjaat kaiken `tiedostoon`. Voit edelleen säätää sitä kirjautuaksesi esim. vain `Info` ja sen alla, ja niin edelleen.

Lopuksi tehkäämme jotain hieman edistyneempää ja kirjaudutaan kaikki viestit tiedostoon, mutta vain botti nimeltä `LogBot`.

```xml
<?xml versio ="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="LogBotFile" fileName="${currentdir:cached=true}/LogBot.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="LogBot" minlevel="Trace" writeTo="LogBotFile" />
  </rules>
</nlog>
```

Voit nähdä, miten käytämme ASF integraatiota edellä ja helposti erottaa viestin lähde perustuu `${logger}` ominaisuus.

---

## Edistynyt käyttö

Yllä olevat esimerkit ovat melko yksinkertaisia ja ne on tehty näyttämään kuinka helppoa on määritellä omat puunkorjuusäännöt, joita voidaan käyttää ASF:llä. Voit käyttää NLog eri asioita, mukaan lukien monimutkaisia kohteita (kuten säilyttää lokit `tietokanta`), lokit kierto (kuten poistamalla vanhat `File` loki), käyttämällä mukautettuja `Asettelu`s, ilmoittamalla omat `<when>` kirjaussuodattimet ja paljon muuta. Kehotan sinua lukemaan koko **[NLog dokumentaatio](https://github.com/nlog/nlog/wiki/Configuration-file)** oppimaan jokaisesta käytettävissäsi olevasta vaihtoehdosta, jonka avulla voit hienosäätää ASF loggaus moduulin haluamallasi tavalla. Se on todella tehokas työkalu ja mukauttaminen ASF kirjaaminen ei ollut koskaan helpompaa.

---

## Rajoitukset

ASF poistaa väliaikaisesti käytöstä **kaikki** säännöt, jotka sisältävät `värikonsolin` tai `konsolin` tavoitteet odotettaessa käyttäjän panosta. Siksi jos haluat pitää kirjautumisen muihin kohteisiin, vaikka ASF odottaa käyttäjän panosta, sinun pitäisi määritellä nämä tavoitteet omia sääntöjään, kuten edellä esitetyissä esimerkeissä sen sijaan asettaa monia kohteita `writeTo` saman säännön (ellei tämä ole haluttu käyttäytyminen). Konsolien kohteiden tilapäinen poistaminen käytöstä on tehty, jotta konsoli pysyy puhtaana odottaessaan käyttäjän syötettä.

---

## Keskustelun kirjaaminen

ASF sisältää laajennetun tuen chat-kirjautumiseen tallentamalla kaikki vastaanotetut / lähetetyt viestit `Trace` -loggaustasolla, mutta myös paljastaa niihin liittyviä lisätietoja **[tapahtuman ominaisuudet](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Tämä johtuu siitä, että meidän täytyy käsitellä chat-viestejä komentoina joka tapauksessa, joten se ei maksa meille mitään kirjata näitä tapahtumia, jotta voit lisätä ylimääräistä logiikkaa (kuten tehdä ASF henkilökohtainen Steam chattailuarkisto).

### Tapahtuman ominaisuudet

| Nimi          | Kuvaus                                                                                                                                                                                                                           |
| ------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Echo          | `bool` tyyppi. Tämä on asetettu `true` kun viestiä lähetetään vastaanottajalle, ja `false` muuten.                                                                                                                               |
| Viesti        | `merkkijono` tyyppi. Tämä on todellinen lähetetty tai vastaanotettu viesti.                                                                                                                                                      |
| ChatGroupID   | `ulong` type. Tämä on ryhmäkeskustelun ID lähetettäville / vastaanotetuille viesteille. `0` kun mitään ryhmächattia ei käytetä tämän viestin lähettämiseen.                                                                      |
| ChatID        | `ulong` type. Tämä on `ChatGroupID` -kanavan tunnus lähetettäville ja vastaanotetuille viesteille. `0` kun mitään ryhmächattia ei käytetä tämän viestin lähettämiseen.                                                           |
| Höyrytunniste | `ulong` type. Tämä on Steam-käyttäjän tunnus lähetettäville / vastaanotetuille viesteille. Voi olla `0` kun mikään tietty käyttäjä ei ole mukana viestin lähetyksessä (e. . kun se on meidän lähettää viestin ryhmäkeskusteluun. |

### Esimerkki

Tämä esimerkki perustuu `ColoredConsole` -perusesimerkkiin. Ennen kuin yritämme ymmärtää sitä, Suosittelen ehdottomasti katsomaan **[edellä](#examples)** jotta voit tutustua NLog kirjautumisen perusteisiin ensin.

```xml
<?xml versio ="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="ChatLogFile" fileName="${currentdir:cached=true}/logs/chat/${event-properties:item=ChatGroupID}-${event-properties:item=ChatID}${when:when='${event-properties:item=ChatGroupID}' == 0:inner=-${event-properties:item=SteamID}}.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss} ${event-properties:item=Message} ${when:when='${event-properties:item=Echo}' == true:inner=-&gt;:else=&lt;-} ${event-properties:item=SteamID}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="MainAccount" level="Trace" writeTo="ChatLogFile">
      <filters defaultAction="Log">
        <when condition="not starts-with('${message}','OnIncoming') and not starts-with('${message}','SendMessage')" action="Ignore" />
      </filters>
    </logger>
  </rules>
</nlog>
```

Olemme aloittaneet perusmallimme `värikonsoli` -esimerkistä ja laajentaneet sitä edelleen. Ennen kaikkea olemme laatineet pysyvän chat lokitiedoston kunkin ryhmän kanava ja Steam-käyttäjä - tämä on mahdollista ansiosta ylimääräisiä ominaisuuksia, jotka ASF paljastaa meille fancy tavalla. Olemme myös päättäneet mennä mukautetun asettelu, joka kirjoittaa vain nykyisen päivämäärän, viestin, lähettää/vastaanotetun tiedon ja Steam-käyttäjän itse. Lopuksi olemme ottaneet käyttöön chat-kirjaussääntömme vain `Trace` -tasolle, vain meidän `Päätili` botti ja vain toimintoja, jotka liittyvät chatin kirjautumiseen (`OnIncoming*` , jota käytetään viestien ja echosin vastaanottamiseen, ja `SendMessage*` ASF-viestien lähettämiseen).

Yllä oleva esimerkki tuottaa `logs/chat/0-0-76561198069026042.txt` tiedoston puhuttaessa **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 miten te teette? -> 76561198069026042
2018-07-26 01:38:38 Teen paljon, miten sinusta? <- 76561198069026042
```

Tietenkin tämä on vain toimiva esimerkki, jossa muutamia kivoja layout temppuja näkyi käytännössä. Voit laajentaa tätä ideaa edelleen omiin tarpeisiisi, kuten ylimääräiseen suodatukseen, mukautettuun järjestykseen, henkilökohtaiseen asetteluun, vain vastaanotettujen viestien tallentamiseen ja niin edelleen.

### Toinen esimerkki

Tämä käyttää `SteamTarget` viestin lähettämiseksi pääbotin höyrytunnisteeseen (`76561198006963719`) kun botti on nimeltään `archi` saa lahjoituksen. Vaatii toisen botin prosessissa (koska et voi lähettää viestejä itse).

```xml
<?xml versio ="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" />
  </targets>

  <rules>
    <logger name="archi" level="Trace" writeTo="Steam">
      <filters defaultAction="Ignore">
        <when condition="starts-with('${message}','ParseTrade() Accepted donation trade: ')" action="Log" />
      </filters>
    </logger>
  </rules>
</nlog>
```

---

## ASF:n tavoitteet

Tavallisten NLog lokikohteiden (kuten `ColoredConsole` ja `File` selitetään edellä), lisäksi voit myös käyttää mukautettuja ASF loggaus tavoitteita.

Jotta ASF-tavoitteet olisivat mahdollisimman kattavia, ne määritellään NLog dokumentaatiosopimuksen mukaisesti.

---

### SteamTarget

Kuten voit arvata, tämä kohde käyttää Steam-chat-viestejä ASF-viestien kirjautumiseen. Voit määrittää sen käyttääksesi joko ryhmächattia tai yksityistä chattia. Sen lisäksi, että määrität Steam-kohteen viesteillesi, voit myös määrittää `botName` botti, joka on tarkoitus lähettää näille.

Tuetaan kaikissa ASF:n käyttämissä ympäristöissä.

---

#### Asetukset Syntaksi
```xml
<targets>
  <target type="Steam"
          name="String"
          layout="Layout"
          chatGroupID="Ulong"
          steamID="Ulong"
          botName="Layout" />
</targets>
```

Lue lisää [Konfiguraatiotiedoston](https://github.com/NLog/NLog/wiki/Configuration-file) käytöstä .

---

#### Parametrit

##### Yleiset Asetukset
_nimi_ - Kohteen nimi.

---

##### Asettelun Asetukset
_asettelu_ - renderoitava teksti. [Asettelu](https://github.com/NLog/NLog/wiki/Layouts) Vaaditaan. Oletus: `${level:uppercase=true}\${logger}-${message}`

---

##### SteamTarget Asetukset

_chatGroupID_ - Ryhmäkeskustelun tunnus julistettu 64-bittiseksi pitkäksi allekirjoittamattomaksi kokonaislukuksi. Ei vaadita. Oletuksena on `0` , joka poistaa ryhmächatin toiminnon käytöstä ja käyttää sen sijaan yksityistä chattia. Kun käytössä (asetetaan ei-nolla-arvoksi), `steamID` -ominaisuus alla toimii `chatID` ja määrittää kanavan tunnuksen tässä `chatGroupID` johon botin pitäisi lähettää viestejä.

_steamID_ - SteamID julistettu 64-bittiseksi allekirjoittamattomaksi kohdekäyttäjän kokonaislukuksi (kuten `SteamOwnerID`), tai kohde `chatID` (kun `chatGroupID` on asetettu). Pakollinen. Oletukset `0` , joka poistaa kirjautumisen kohteen kokonaan.

_botName_ - Botin nimi (kuten ASF on tunnustanut, kirjainkoolla herkkä), joka lähettää viestejä `höyrytunnisteeseen` edellä. Ei vaadita. Oletuksena on `null` , joka valitsee automaattisesti **mikä tahansa** tällä hetkellä kytketty botti. On suositeltavaa määrittää tämä arvo oikein, koska `SteamTarget` ei ota huomioon monia Steam-rajoituksia, kuten se, että sinulla täytyy olla kohde `höyryID` ystävälistallasi. This variable is defined as [layout](https://github.com/NLog/NLog/wiki/Layouts) type, therefore you can use special syntax in it, such as `${logger}` in order to use the bot that generated the message.

---

#### SteamTarget Esimerkkejä

Jotta voit kirjoittaa kaikki viestit `Debug` taso ja edellä, botti nimeltä `MyBot` ja `76561198006963719`höyrytunniste, sinun tulee käyttää `NLog. onfig` samanlainen kuin alla:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**Huomautus:** Meidän `SteamTarget` on mukautettu tavoite, joten kannattaa varmistaa, että ilmoitat sen nimellä `type="Steam"`, EI `xsi:type="Steam"`, koska xsi on varattu NLogin tukemille virallisille kohteille.

Kun käynnistät ASF:n `NLogin avulla. onfig` samanlainen kuin edellä, `MyBot` aloittaa viestien lähettämisen `76561198006963719` Steam-käyttäjä kaikilla tavallisilla ASF lokiviesteillä. Muista, että `MyBot` on oltava yhteydessä viestien lähettämiseksi joten kaikkia ensimmäisiä ASF-viestejä, jotka tapahtuivat ennen kuin bottimme voisi muodostaa yhteyden Steam-verkkoon, ei siirretä.

Tietenkin `SteamTarget` on kaikki tyypilliset toiminnot, joita voit odottaa geneerisiltä `TargetWithLayout`, joten voit käyttää sitä yhdessä e. . mukautettuja asetteluja, nimiä tai kehittyneitä kirjautumissääntöjä. Yllä oleva esimerkki on vain kaikkein perusluonteisin esimerkki.

---

#### Kuvakaappaukset

![Kuvakaappaus](https://i.imgur.com/5juKHMt.png)

---

#### Caveats

Ole varovainen, kun päätät yhdistää `Debug` -kirjaustason tai sen alapuolella `SteamTarget` -näppäimen `höyryID` -näppäimeen, joka osallistuu ASF-prosessiin. Tämä voi johtaa mahdolliseen `StackOverflowPoikkeus` , koska luot äärettömän silmukan ASF:lle annetusta viestistä, sitten kirjata se kautta Steam, jolloin toinen viesti, joka on kirjattava. Tällä hetkellä ainoa mahdollisuus sen tapahtumiseen on kirjautua `Trace` -tasolle (jossa ASF tallentaa omat chat-viestit), tai `Debug` -tason ollessa myös ASF `Debug` -tilassa (jossa ASF tallentaa kaikki Steam-paketit).

Lyhyesti sanottuna, jos `steamID` osallistuu samaan ASF-prosessiin, sitten `minitason` kirjautumistason `SteamTarget` pitäisi olla `Info` (tai `Debug` jos et myöskään käytä ASF:ää `Debug` -tilassa) ja edellä. Vaihtoehtoisesti voit määritellä omat `<when>` loggaus suodattimet välttääksesi äärettömän loggauksen jos tason muuttaminen ei sovi sinun tapauksessasi. Tämä mahdollisuus koskee myös ryhmäkeskusteluja.

---

### HistoryTarget

ASF käyttää tätä kohdetta sisäisesti tarjotakseen kiinteäkokoisen kirjaushistorian `/Api/NLog` -päätepisteessä **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** , jota ASF-ui ja muut työkalut voivat käyttää jälkeenpäin. Yleensä sinun pitäisi määrittää tämä kohde vain, jos käytät jo mukautettua NLog config muita räätälöintiä ja haluat myös lokin olevan alttiina ASF API, e. . ASF-uille Se voidaan myös ilmoittaa, kun haluat muokata oletusasettelua tai `maxCount` tallennetuista viesteistä.

Tuetaan kaikissa ASF:n käyttämissä ympäristöissä.

---

#### Asetukset Syntaksi
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Lue lisää [Konfiguraatiotiedoston](https://github.com/NLog/NLog/wiki/Configuration-file) käytöstä .

---

#### Parametrit

##### Yleiset Asetukset
_nimi_ - Kohteen nimi.

---

##### Asettelun Asetukset
_asettelu_ - renderoitava teksti. [Asettelu](https://github.com/NLog/NLog/wiki/Layouts) Vaaditaan. Oletus: `${date:format=yy-MM-dd HH\:mm\:ss}${processname}-${processid}¶ ${level:uppercase=true}•${logger}¶${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### HistoriaKohteen Asetukset

_maxCount_ - Maksimi määrä tallennettuja lokeja tilauksesta. Ei vaadita. Oletukset `20` , joka on hyvä tasapaino alkuperäisen historian, vaikka silti pitää mielessä muistin käyttö, joka tulee ulos tallennustilan vaatimukset. Täytyy olla suurempi kuin `0`.