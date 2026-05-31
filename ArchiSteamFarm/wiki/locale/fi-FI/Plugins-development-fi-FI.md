# Liitännäisten kehittäminen

ASF sisältää tuen mukautetuille liitännäisille, joita voidaan ladata ajon aikana. Liitännäisten avulla voit muokata ASF käyttäytymistä, esimerkiksi lisäämällä mukautettuja komentoja, mukautetun kaupankäynnin logiikkaa tai koko integraation kolmannen osapuolen palveluihin ja APIin.

Tällä sivulla kuvataan ASF plugins kehittäjien näkökulmasta - luominen, ylläpito, julkaisu ja samoin. If you want to view user's perspective, move **[here](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** instead.

---

## Ydin

Liitännäiset ovat tavallisia .NET-kirjastoja, jotka määrittelevät luokan, joka perii ASF:ssä ilmoitetusta yhteisestä `IPlugin`-käyttöliittymästä. Voit kehittää liitännäisiä täysin riippumatta mainline ASF ja käyttää niitä uudelleen nykyisissä ja tulevissa ASF versiot, niin kauan kuin sisäinen ASF API on yhteensopiva. Liitännäisjärjestelmä, jota käytetään ASF:ssä, perustuu `System. omposition`, joka tunnetaan aiemmin nimellä **[Managed Extensibility Framework](https://docs.microsoft.com/dotnet/framework/mef)**, jonka avulla ASF voi löytää ja ladata kirjastojasi ajon aikana.

---

### Näin pääset alkuun

Olemme valmistelleet **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate)** sinulle, jota voit (ja pitäisi) käyttää perustana plugin projekti. Mallin käyttö on **ei vaadittu** (kuten voit tehdä kaiken tyhjästä), mutta suosittelemme voimakkaasti poimia sen, koska se voi dramaattisesti kickstart oman kehityksen ja leikata aikaa tarvitaan saada kaikki asiat kuntoon. Yksinkertaisesti tarkistaa **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** mallista ja se opastaa sinua. Huolimatta me peitämme alla olevat perusteet siltä varalta, että halusit aloittaa tyhjästä, tai saada ymmärtämään paremmin käsitteitä käytetään plugin malli - sinun ei yleensä tarvitse tehdä mitään, jos olet päättänyt käyttää plugin malli.

Projektin pitäisi olla standardi . ET library targetting appropriate framework of your target ASF version as specified in the **[compilation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation)** osio.

Projektin tulee viitata pää`ArchiSteamFarm`-kokoonpanoon, joko sen esirakennettu `ArchiSteamFarm. ll` kirjasto, jonka olet ladannut osana julkaisua, tai lähdeprojektia (esim. jos olet päättänyt lisätä ASF-puun alimoduulina). Tämän avulla voit tutustua ja löytää ASF rakenteita, menetelmiä ja ominaisuuksia, erityisesti ydin `IPlugin` käyttöliittymä, joka sinun täytyy periä seuraavassa vaiheessa. Projektin on myös viitattava `System.Composition.AttributedModel` vähintään siten, että voit `[Export]` sinun `IPlugin`si ASF:ää varten. Sen lisäksi saatat haluta tai joutua viittaamaan muihin yleisiin kirjastoihin tulkitseaksesi tietorakenteita, joita sinulle annetaan joissakin rajapinnoissa, mutta ellet tarvitse niitä nimenomaisesti, se riittää toistaiseksi.

Jos teit kaiken kunnolla, `csproj` on samanlainen kuin alla:

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>verkko10.</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <! - Koska lataat liitännäisen ASF-prosessiin, joka sisältää jo nämä riippuvuudet, IncludeAssets="compile" avulla voit jättää ne lopullisesta tulostuksesta -->
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" IncludeAssets="compile" Version="10.0.0" />
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="10.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="C:\\Path\To\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" />

    <! - Jos rakennus ladatulla DLL binaarilla, käytä tätä sen sijaan <ProjectReference> yläpuolella -->
    <! - <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" /> -->
  </ItemGroup>
</Project>
```

Koodin puolella, plugin luokan on perittävä `IPlugin` käyttöliittymä (joko nimenomaisesti, tai implisiittisesti perillä erikoistuneempi käyttöliittymä, kuten `IASF`) ja `[Export(typeof(IPlugin))]` ASF tunnistamaan ne suoritettaessa Läpinäkyvin esimerkki, jonka avulla voidaan saavuttaa seuraavat tavoitteet:

```csharp
Järjestelmä;
käyttäen System.Compositionia;
käyttäen System.Threading.Tasks;
käyttäen ArchiSteamFarm-sovellusta;
käyttäen ArchiSteamFarm-laajennuksia;

nimiavaruutta YourNamespace. ourPluginName;

[Export(typeof(IPlugin))]
julkinen sinetöity luokka YourPluginName : IPlugin {
	¶ public string Name => nameof(YourPluginName);
	¶ public Version Version => typeof(YourPluginName). ssembly.GetName().Version;

	"unnamed@@0public Task OnLoaded() {
		"unnamed@@0ASF.ArchiLogger.LogGenericInfo("Hei World!");

		− return Tehtävä.CompletedTehtävä;
	"unnamed@@0}
}
```

Jotta voit käyttää plugin, sinun täytyy ensin kääntää se. Voit tehdä sen joko IDE:stä tai projektisi juurihakemiston sisällä komennon kautta:

```shell
# Jos projektisi on itsenäinen (ei tarvitse määritellä sen nimeä, koska se on ainoa)
dotnet julkaista -c "Release" -o "out"

# Jos projektisi on osa ASF lähdepuuta (välttääksesi tarpeettomien osien)
dotnet julkaisee YourPluginName -c "Release" -o "out"
```

Myöhemmin plugin on valmis käyttöönottoon. It's up to you how exactly you want to distribute and publish your plugin, but we recommend creating a zip archive where you'll put your compiled plugin together with its **[dependencies](#plugin-dependencies)**. Näin käyttäjä tarvitsee yksinkertaisesti purkaa zip-arkistosi itsenäiseen alihakemistoon heidän `plugins` hakemistonsa sisällä eikä tee mitään muuta.

Tämä on vain perusskenaario saada sinut alkuun. Meillä on **[`ExamplePlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** projekti, joka näyttää sinulle esimerkiksi rajapintoja ja toimintoja, jotka voit tehdä oman plugin, mukaan lukien hyödyllisiä kommentteja. Voit vapaasti katsoa jos haluat oppia työkoodista tai löytää `ArchiSteamFarm. lugins` nimiavaruus itse ja viitata mukana dokumentaatio kaikki käytettävissä olevat vaihtoehdot. Aiomme myös syventää joitakin keskeisiä käsitteitä alla selittämään niitä paremmin.

Jos sen sijaan esimerkiksi plugin haluat oppia todellisia hankkeita, on olemassa useita virallisia plugins kehittänyt meidän, esim. **[`ItemsMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.ItemsMatcher)**, **[`MobileAuthenticator`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.MobileAuthenticator)** tai **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)**. Sen lisäksi, että on olemassa myös muiden kehittäjien kehittämiä liitännäisiä, meidän **[third-party](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** osiossa.

---

### API saatavuus

ASF, lukuun ottamatta sitä, mitä sinulla on pääsy rajapintoihin itse, altistaa sinulle paljon sen sisäisiä sovellusliittymiä, joita voit käyttää, jotta voit laajentaa toiminnallisuutta. Esimerkiksi, jos haluat lähettää jonkinlaisen uuden pyynnön Steamin verkkoon, sinun ei tarvitse toteuttaa kaikkea tyhjästä, käsitellä erityisesti kaikkia asioita, jotka meidän on pitänyt käsitellä ennen sinua. Käytä vain meidän `Bot. rchiWebHandler`, joka paljastaa jo paljon `UrlWithSession()`-menetelmiä, joita voit käyttää käsitellä kaikkia alemman tason tavaroita, kuten todennusta, istunnon päivitystä tai web-rajoitus sinulle. Samoin voit lähettää web-pyyntöjä Steam-alustan ulkopuolelle, käyttää standardia .NET `HttpClient`-luokkaa, mutta se on paljon parempi idea käyttää `Bot. rchiWebHandler.WebBrowser`, joka on käytettävissä sinulle, joka taas tarjoaa sinulle hyödyllisen käden, esimerkiksi suhteessa uudelleen epäonnistuneiden pyyntöjen.

Meillä on hyvin avoin politiikka sovellusrajapinnan saatavuutemme osalta, Joten jos haluat käyttää jotain, että ASF koodi jo sisältää, simply **[open an issue](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** and explain in it your planned use case of our ASF internal API. Meillä ei todennäköisesti ole mitään vastaan, kunhan käyttötapaus on järkevä. Tämä sisältää myös kaikki uusia IPlugin-rajapintoja koskevat ehdotukset, jotka voisi olla järkevää lisätä olemassa olevan toiminnon laajentamiseksi.

ASF API -saatavuudesta huolimatta mikään ei kuitenkaan estä sinua esimerkiksi 'Discord. et\` kirjasto sovelluksessasi ja sillan luominen Discord-botin ja ASF-komentojesi välille, koska plugin voi olla riippuvuuksia omasta. Mahdollisuudet ovat loputtomia, ja teimme parhaamme antaa sinulle niin paljon vapautta ja joustavuutta kuin mahdollista sisällä teidän plugin, joten ei ole keinotekoisia rajoja mitään - plugin on ladattu tärkein ASF prosessi ja voi tehdä mitään, mikä on realistisesti mahdollista tehdä sisällä C# koodi.

---

### API compatibility

On tärkeää korostaa, että ASF on kuluttajasovellus eikä tyypillinen kirjasto, jossa on kiinteä API pinta, joka voi riippua ehdoitta. Tämä tarkoittaa, että et voi olettaa, että plugin kerran koottu pitää työskennellä kaikkien tulevien ASF julkaisut riippumaton, se on yksinkertaisesti mahdotonta, jos haluamme jatkaa ohjelman kehittämistä, eikä pysty sopeutumaan aina käynnissä oleviin Steam-muutoksiin taka-ajojen vuoksi yhteensopivuus ei ole meidän tapauksemme sopivaa. Tämän pitäisi olla loogista sinulle, mutta on tärkeää korostaa tätä tosiasiaa.

Teemme parhaamme pitääksemme ASF:n julkiset osat toiminnassa ja vakaina, mutta emme pelkää rikkoa yhteensopivuutta, jos syntyy tarpeeksi hyviä syitä, seuraavat meidän **[deprecation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation)** politiikkaa prosessissa. Tämä on erityisen tärkeää ASF:n sisäisissä rakenteissa, jotka ovat sinulle alttiita osana ASF:n infrastruktuuria (esim. `ArchiWebHandler`), jota voitaisiin parantaa (ja näin ollen kirjoittaa uudelleen) osana ASF parannuksia jossakin tulevista versioista. Teemme parhaamme ilmoittaaksemme sinulle asianmukaisesti muutoslokeissa, ja sisällytämme asianmukaiset varoitukset ajon aikana vanhentuneista ominaisuuksista. Emme aio kirjoittaa kaikkea uudelleen sen uudelleenkirjoittamisen vuoksi, joten voit olla melko varma, että seuraava pieni ASF versio ei vain yksinkertaisesti tuhota plugin kokonaan vain koska se on korkeampi versionumero, mutta pitää silmällä muutoslokit ja satunnainen todentaminen, jos kaikki toimii hyvin on erittäin hyvä ajatus.

---

### Liitännäisten riippuvuudet

Liitännäisesi sisältää oletusarvoisesti vähintään kaksi riippuvuutta, `ArchiSteamFarm`-viite sisäiselle API:lle (`IPlugin`) ja `System'lle 'PackageReference`. omposition.AttributedModel`, joka tarvitaan, jotta se voidaan tunnistaa ASF-liitännäiseksi (`[Export]`-lauseke). Sen lisäksi, että se voi sisältää enemmän riippuvuuksia suhteessa mitä olet päättänyt tehdä teidän plugin (e. .`Discord.Net\`-kirjasto, jos olet päättänyt integroida Discordiin.

Koodisi tuloste sisältää ytimen `YourPluginName.dll` kirjastosi sekä kaikki riippuvuudet, joihin olet viitannut. Koska olet kehittänyt plugin jo toimiva ohjelma, sinun ei tarvitse ja jopa **ei pitäisi sisältää** riippuvuuksia, joita ASF jo sisältää, esimerkiksi `ArchiSteamFarm`, `SteamKit2` tai `AngleSharp`. Stripping alas rakentaa pois riippuvuudet jaettu ASF ei ole ehdoton vaatimus plugin toimimaan, mutta niin tekee niin dramaattisesti leikata muistin jalanjälki ja koko plugin, yhdessä suorituskyvyn lisäämisen kanssa, koska ASF jakaa omat riippuvuutensa kanssasi, ja lataa vain ne kirjastot, joista se ei tiedä itsestään.

Yleensä suositellaan, että mukaan otetaan vain ne kirjastot, joita ASF ei sisällä, tai ne sisältyvät väärään tai yhteensopimattomaan versioon. Esimerkkejä näistä olisi ilmeisesti `YourPluginName.dll`, mutta esimerkiksi `Discord.Net.dll`, jos päätät olla riippuvainen siitä, koska ASF ei sisällytä sitä itse. ASF:n kanssa jaettujen kirjastojen yhdistäminen voi silti olla järkevää, jos haluat varmistaa API-yhteensopivuuden (esim. on varma, että `AngleSharp`, joka olet riippuvainen plugin on aina versiossa `X` eikä se, että ASF alusten kanssa), mutta ilmeisesti se tulee hinta lisääntynyt muistin/koon ja huonompi suorituskyky, ja siksi olisi arvioitava huolellisesti.

Jos tiedät, että riippuvuus, jota tarvitset sisältyy ASF, voit merkitä sen merkillä `IncludeAssets="compile"`, kuten näytimme edellä olevassa esimerkissä `csproj`. Tämä käskee kääntäjää välttämään viittatun kirjaston julkaisemista, sillä ASF sisältää jo tämän kirjaston. Samoin Huomaa, että viittaamme ASF-projektiin `ExcludeAssets="all" Private="false"`, joka toimii hyvin samalla tavalla - kertoen kääntäjälle että hän ei tuota ASF-tiedostoja (kuten käyttäjällä on jo ne). Tämä pätee vain silloin, kun viitataan ASF-projektiin, sillä jos viittaat `dll`-kirjastoon, et tuota ASF-tiedostoja osana lisäosaasi.

Jos olet hämmentynyt yllä olevasta lausekkeesta ettet tiedä paremmin, tarkista mitkä `dll`-kirjastot sisältyvät `ASF-yleistilaan. ip` paketti ja varmistaa, että plugin sisältää vain ne, jotka eivät ole osa sitä vielä. Tämä on vain `YourPluginName.dll` kaikkein yksinkertaisimmille laajennuksille. Jos saat ongelmia aikana ajoaika suhteen joidenkin kirjastojen, myös niitä vaikuttaa kirjastot samoin. Jos kaikki muu epäonnistuu, voit aina päättää niputtaa kaiken.

---

### Natiiviset riippuvuudet

Natiivi riippuvuudet syntyy osana OS-erityisiä rakennuksia, koska ei ole . ET ajoaika saatavilla isäntämaassa ja ASF on käynnissä oman .NET ajoaika, joka on niputettu osaksi OS-erityinen rakennus. Jotta rakennuksen kokoa voitaisiin minimoida, ASF leikaa sen alkuperäiset riippuvuudet sisältämään vain koodin, joka voidaan mahdollisesti saavuttaa ohjelman sisällä, joka tehokkaasti leikkaa käyttämättömiä osia ajoajan. Tämä voi luoda mahdollisen ongelman sinulle suhteen teidän plugin, jos yhtäkkiä huomaat itsesi tilanteessa, jossa plugin riippuu joistakin. ET ominaisuus, jota ei käytetä ASF:ssä, ja siksi OS-spesifiset rakennukset eivät voi suorittaa sitä kunnolla, yleensä heittää `System.MissingMethodException` tai `System.Reflection.ReflectionTypeLoadException` prosessissa. Koska plugin kasvaa koko ja tulee yhä monimutkaisempi, Ennemmin tai myöhemmin osut pinnalle, joka ei kuulu OS-spesifisen rakennuksemme piiriin.

Tämä ei ole koskaan ongelma geneeristen rakennusten kanssa, koska ne eivät koskaan käsittele natiivi riippuvuuksia ensisijaisesti (kuten heillä on täydellinen työaika isäntä, suorittaa ASF). Siksi on suositeltavaa käyttää **käyttää liitännäistä geneerisissä versioissa yksinomaan**, mutta ilmeisesti, että on oma haittapuoli leikkaus plugin käyttäjiltä, jotka ovat käynnissä OS-erityisiä rakennuksia ASF. Jos mietit, onko ongelma liittyy syntyperäisiin riippuvuuksiin, voit myös käyttää tätä menetelmää todentamiseen, lataa plugin ASF geneerinen versio ja katso, jos se toimii. Jos se tekee, sinulla on liitännäisen riippuvuudet katettu, ja se on natiivi riippuvuuksia aiheuttaa ongelmia.

Valitettavasti jouduimme tekemään vaikean valinnan sen välillä, että koko ajoaika julkaistaisiin osana OS-rakennuksiamme, ja päättää leikata se pois käyttämättömistä ominaisuuksista, jolloin rakentaa yli 80 MB pienempi kuin täyteen. Olemme valinneet toisen vaihtoehdon, ja se on valitettavasti mahdotonta voit sisällyttää puuttuvat ajoaika ominaisuuksia yhdessä plugin. Jos projektisi vaatii pääsyn ajo-ominaisuuksiin, jotka on jätetty pois, sinun täytyy sisällyttää täysi . ET ajoaika, josta olet riippuvainen, ja se tarkoittaa käynnissä plugin `generic` ASF maku. Et voi suorittaa plugin OS-erityisiä rakennuksia, koska nämä rakennukset ovat yksinkertaisesti puuttuu ajoaika ominaisuus, että tarvitset, ja . ET juokseva aika nyt ei pysty "yhdistäminen" natiivi riippuvuus, joka olisit voinut tarjota oman. Ehkä se paranee eräänä päivänä tulevaisuudessa, mutta nyt se ei yksinkertaisesti ole mahdollista.

ASF: n OS-erityiset rakennukset sisältävät paljain minimi ylimääräistä toiminnallisuutta, joka on tarpeen suorittaa viralliset plugins. Sen lisäksi, että mahdollista, Tämä myös hieman laajentaa pintaa ylimääräisiä riippuvuuksia tarvitaan kaikkein perus plugins. Siksi kaikki plugins ei tarvitse murehtia natiivi riippuvuuksia aloittaa - vain ne, jotka menevät pidemmälle kuin mitä ASF ja viralliset plugins suoraan tarvitsevat. Tämä tehdään ylimääräisenä, sillä jos meidän on joka tapauksessa otettava mukaan synnynnäisiä riippuvuuksia omasta käytöstämme, voimme myös lähettää ne suoraan ASF:ään, jolloin ne ovat saatavilla ja siten helpommin peitetyt myös sinulle. Valitettavasti tämä ei ole aina tarpeeksi, ja kun plugin saa isompi ja monimutkaisempi, todennäköisyys juoksee trimmed toiminnallisuutta kasvaa. Siksi suosittelemme yleensä käyttämään mukautettuja plugins `generic` ASF maku yksinomaisesti. Voit silti manuaalisesti tarkistaa, että OS-erityinen rakentaa ASF on kaikki, että plugin vaatii sen toiminnallisuutta - mutta koska se muuttuu päivityksiä sekä meidän, voi olla hankalaa ylläpitää.

Joskus voi olla mahdollista "workaround" puuttuvat ominaisuudet joko käyttämällä vaihtoehtoisia vaihtoehtoja tai toteuttamalla ne uudelleen teidän plugin. Tämä ei kuitenkaan ole aina mahdollista tai elinkelpoinen, varsinkin jos puuttuva ominaisuus tulee kolmannen osapuolen riippuvuuksista, jotka sisältyvät osana plugin. Voit aina yrittää ajaa plugin OS-erityinen versio ja yrittää saada se toimimaan, mutta se voi tulla liikaa vaivaa pitkällä aikavälillä, varsinkin jos haluat koodistasi vain toimimaan, eikä taistella ASF pinnalla.

---

## Automaattiset päivitykset

ASF tarjoaa sinulle kaksi liitäntää automaattisten päivitysten toteuttamiseen liitännäisessä:

- `IGitHubPluginUpdates`, joka tarjoaa helpon tavan toteuttaa GitHub-pohjaisia päivityksiä, jotka vastaavat yleistä ASF-päivitysmekanismia
- `IPluginUpdates`, joka tarjoaa sinulle alemman tason toiminnallisuuden, joka mahdollistaa mukautetun päivitysmekanismin, jos tarvitset jotain monimutkaisempaa

---

### **[`IGithubPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs)**

Vähimmäistarkistuslista asioista, joita tarvitaan päivityksiä varten, jotta ne toimisivat:

- Sinun täytyy ilmoittaa `RepositoryName`, joka määrittelee, mistä päivitykset vedetään.
- Sinun täytyy käyttää GitHubin antamia tunnisteita ja julkaisuja. Tagin tulee olla muodoltaan parsable liitännäisen versioon, esim. `1.0.0.0`.
- `Version` liitännäisen omaisuuden on vastattava tagia, josta se tulee. Tämä tarkoittaa sitä, että tunnisteen `1.2.3.4` alla olevan binäärin on esitettävä muodossa `1.2.3.4`.
- Jokainen tag pitäisi olla asianmukainen julkaisu saatavilla GitHub kanssa zip tiedoston julkaisu voimavara, joka sisältää plugin binary tiedostoja. Binary tiedostojen, jotka sisältävät sinun `IPlugin` luokkia pitäisi olla saatavilla juurihakemistoon zip-tiedostossa.

Tämän ansiosta ASF:n mekanismi voi

- Selvitä laajennuksesi nykyinen `Version`, esim. `1.0.1`.
- Käytä GitHub API hakeaksesi viimeisimmät `tag`, joka on saatavilla `RepositoryName`-repossa, esim. `1.0.2`.
- Päätä, että `1.0.2` > `1.0.1`, tarkista `1.0.2`-tagin julkaisu löytääksesi `.zip`-tiedoston liitännäisen päivityksellä.
- Lataa `.zip`-tiedosto, pura se ja laita sen sisältö hakemistoon, joka sisälsi `YourPlugin.dll` ennen.
- Käynnistä ASF uudelleen ladataksesi liitännäisen `1.0.2`-versiossa.

Muut huomautukset:

- Liitännäisen päivitykset voivat edellyttää asianmukaisia ASF asetusarvoja, nimittäin **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)** ja/tai **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)**.
- Meidän plugin malli sisältää jo kaiken mitä tarvitset, yksinkertaisesti **[rename](https://github.com/JustArchiNET/ASF-PluginTemplate?tab=readme-ov-file#renaming-myawesomeplugin)** lisäosa oikeisiin arvoihin, ja se tulee treenaamaan laatikosta.
- Voit käyttää uusimman julkaisun ja esijulkaisujen yhdistelmää, niitä käytetään 'UpdateChannel\`-muodossa, jonka käyttäjä on määritellyt.
- There is `CanUpdate` boolean property you can override for disabling/enabling plugins update on your side, esimerkiksi jos haluat ohittaa päivitykset tilapäisesti tai jonkin muun syyn kautta.
- On mahdollista saada useita zip-tiedostoja julkaisussa, jos haluat kohdistaa eri ASF versiot. Katso `GetTargetReleaseAsset()` **[remarks](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs#L79-L106)**. Esimerkiksi, sinulla voi olla `MyPlugin-V6-0.zip` sekä `MyPlugin.zip`, joka aiheuttaa ASF versiossa `V6. .x.x` valitaksesi ensimmäisen, kun taas kaikki muut ASF versiot käyttävät toista versiota.
- Jos yllä oleva ei riitä sinulle ja tarvitset mukautetun logiikan oikean `. ip`-tiedosto, voit ohittaa `GetTargetReleaseAsset()` -funktion ja tarjota artifaktin ASF:lle.
- Jos liitännäisen on tehtävä lisätyötä ennen päivitystä tai sen jälkeen, voit ohittaa `OnPluginUpdateProceeding()` ja/tai `OnPluginUpdateFinished()`-menetelmät.

---

### **[`IPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IPluginUpdates.cs)**

Tämä käyttöliittymä mahdollistaa mukautetun logiikan päivityksille, jos jostain syystä `IGithubPluginUpdates` ei riitä sinulle, Esimerkiksi koska sinulla on tunnisteita, jotka eivät osaa versioita, tai koska et käytä GitHub alusta ollenkaan.

On olemassa yksi `GetTargetReleaseURL()`-toiminto, jonka voit ohittaa, joka odottaa sinulta `Uri?` lisäosan päivityssijainnista. ASF tarjoaa sinulle joitakin keskeisiä muuttujia, jotka liittyvät asiayhteyteen funktio kutsuttiin, mutta muu kuin se, olet vastuussa toteuttaa kaikki mitä tarvitset kyseisessä funktiossa ja tarjota ASF URL, jota pitäisi käyttää, tai `null`, jos päivitys ei ole saatavilla.

Muut kuin se, se on samanlainen kuin GitHub päivitykset, jossa URL pitäisi osoittaa `. ip` tiedosto binaaritiedostoilla, jotka ovat saatavilla juurihakemistossa. Sinulla on myös `OnPluginUpdateProceeding()` ja `OnPluginUpdateFinished()` -menetelmiä.