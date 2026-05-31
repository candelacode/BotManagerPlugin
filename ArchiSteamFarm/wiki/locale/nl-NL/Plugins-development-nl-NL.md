# Plugins ontwikkeling

ASF biedt ondersteuning voor aangepaste plug-ins die tijdens het starten geladen kunnen worden. Met plugins kunt u ASF-gedrag aanpassen, bijvoorbeeld door het toevoegen van aangepaste commando's, aangepaste handelsideologie of hele integratie met diensten van derden en API's.

Deze pagina beschrijft ASF plugins van ontwikkelaars - creëren, onderhouden, publiceren en ook gebruiken. Als je het perspectief van de gebruiker wilt bekijken, plaats dan **[here](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

---

## Login

Plugins zijn standaard .NET bibliotheken die een klasse die van de gemeenschappelijke `IPlugin` interface die in ASF wordt gedeclareerd, definiëren. Je kunt plugins ontwikkelen geheel onafhankelijk van het mainline ASF en ze hergebruiken in de huidige en toekomstige ASF-versies, zolang de interne ASF API compatibel blijft. Plugin systeem gebruikt in ASF is gebaseerd op `System. omposition`, voorheen bekend als **[Extensibility Framework](https://docs.microsoft.com/dotnet/framework/mef)** waarmee ASF tijdens de runtime bibliotheken kan ontdekken en laden.

---

### Starten

We hebben **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate)** voor je voorbereid, die je kunt (en zou moeten gebruiken) als basis voor je plugin project. Het gebruik van het sjabloon is **geen vereiste** (omdat je alles vanaf het begin kunt doen), maar we raden ten zeerste aan om het op te pakken omdat het je ontwikkeling drastisch kan vertragen en de benodigde tijd kan verkorten om alles goed te doen. Bekijk gewoon de **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** van de template en het zal je verder helpen. Hoe dan ook, we bedekken de basis hieronder voor het geval je bij nul wilt beginnen, of leer de concepten die gebruikt worden in de plugin template beter te begrijpen - het hoeft meestal niet te doen als je besloten hebt om gebruik te maken van onze plugin template.

Je project moet een standaard zijn. ET library target het juiste kader van je ASF versie, zoals aangegeven in de **[compilation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation)** sectie.

Het project moet verwijzen naar het hoofd `ArchiSteamFarm` assemblee, ofwel het voorgeprogrammeerde `ArchiSteamFarm. llll` bibliotheek die je hebt gedownload als onderdeel van de release, of het bronproject (bijvoorbeeld als je hebt besloten om ASF boom als submodule toe te voegen). Hiermee krijg je toegang tot ASF structuren, methoden en eigenschappen en ontdek je vooral de kern van de `IPlugin` interface waarvan u moet erven in de volgende stap. Het project moet ook `System.Composition.AttributedModel` als minimum gebruiken, wat je toestaat om `[Export]` je `IPlugin` te gebruiken voor ASF. Daar komt nog bij dat je kunt andere gemeenschappelijke bibliotheken willen/nodig hebben om de gegevensstructuren te interpreteren die je in sommige interfaces hebt gekregen, Maar als u ze niet expliciet nodig hebt, is dat voorlopig voldoende.

Als je alles goed hebt gedaan, zal jouw `csproj` gelijk zijn aan hieronder:

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <! - Omdat je de plugin laadt in het ASF-proces, dat deze afhankelijkheden al bevat, Met IncludeAssets="compile" kun je de einduitvoer verlaten -->
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" IncludeAssets="compile" Version="10.0.0" />
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="10.0.0" />
  </ItemGroup>

  <ItemGroup><ItemGroup>
    <ProjectReference Include="C:\\Path\To\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" />

    <! - Als het bouwen met de gedownloade DLL binary, gebruik dit in plaats van <ProjectReference> boven -->
    <! - <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" /> -->
  </ItemGroup>
</Project>
```

Van de kant van de code moet uw plugin klasse erven van de `IPlugin` interface (expliciet of impliciet door het overnemen van meer gespecialiseerde interface, zoals `IASF`) en `[Export(typeof(IPlugin)]` om ASF te herkennen tijdens de runtime. Het meest in het oog springende voorbeeld dat dit zou zijn:

```csharp
met behulp van System;
met behulp van System.Composie;
met behulp van System.Threading.Tasks;
met behulp van ArchiSteamFarm;
met behulp van ArchiSteamFarm.Plugins;

namespace YourNamespace. ourPluginName;

[Export(type(IPlugin)]
openbare klasse YourPluginName : IPlugin {
	Ø openbare string Name => nameof(YourPluginName);
	zuelpublic Version => typeof(YourPluginName). ssembly.GetName().Version;

	ľpublic Task OnLoaded() {
		→ASF.ArchiLogger.LogGenericInfo("Hello World!");

		gevallend return Task.CompletedTask;
	ns. }
 } }
```

Om gebruik te kunnen maken van uw plugin, moet u deze eerst compileren. U kunt dat doen vanuit uw IDE, of vanuit de hoofdmap van uw project via een commando:

```shell
# Als je project zelfstandig is (hoef je de naam niet te definiëren omdat het de enige is)
dotnet publiceren -c "Release" -o "out"

# Als je project deel uitmaakt van de ASF bron boom (om onnodige onderdelen te compileren)
dotnet publiceren YourPluginName -c "Release" -o "out"
```

Daarna is je plugin klaar voor implementatie. Het is aan jou om te bepalen hoe je jouw plugin wilt verspreiden en publiceren, maar we raden aan een zip-archief te maken waar je de gecompileerde plugin samen met de **[dependencies](#plugin-dependencies)**. Op deze manier moet de gebruiker je zip-bestand uitpakken tot een zelfstandige submap in de `plugins` map en niets anders doen.

Dit is slechts het meest basale scenario om je op weg te helpen. We hebben een **[`ExamplePlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** project dat je voorbeelden van interfaces en acties laat zien, die je kunt doen binnen je eigen plugin, inclusief nuttige opmerkingen. Neem gerust een kijkje of je van een werkende code wilt leren, of ontdek \`ArchiSteamFarm. lugins' om jezelf een naam te geven en lees de bijbehorende documentatie voor alle beschikbare opties. We zullen ook verder ingaan op enkele kernbegrippen hieronder om ze beter uit te leggen.

Als in plaats van de voorbeeldplugin die u wilt leren van echte projecten, zijn er verschillende officiële plugins ontwikkeld door ons, bv. **[`ItemsMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.ItemsMatcher)**, **[`MobileAuthenticator`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.MobileAuthenticator)** of **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)**. Daarnaast zijn er ook plugins ontwikkeld door andere ontwikkelaars, in onze **[third-party](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** sectie.

---

### API beschikbaarheid

ASF, behalve waar je toegang tot hebt in de interfaces zelf geeft u veel van zijn interne API's waar u gebruik van kunt maken om de functionaliteit uit te breiden. Als je bijvoorbeeld een nieuw verzoek wilt sturen naar Steam web, dan hoef je niet alles van nul te implementeren. specifiek omgaan met alle kwesties die we voor je hebben behandeld. Gebruik gewoon onze `Bot. rchiWebHandler` wat al veel `UrlWithSession()` methodes blootstelt om te gebruiken alle dingen op lager niveau zoals authenticatie, sessie vernieuwen of web limitatie voor u afhandelen. Hetzelfde geldt voor het verzenden van webverzoeken buiten het Steam platform, je zou de standaard `HttpClient` klasse kunnen gebruiken, maar het is veel beter om `Bot te gebruiken. rchiWebHandler.WebBrowser` die beschikbaar is voor jou, wat je weer een handige hand biedt, bijvoorbeeld met betrekking tot mislukte verzoeken.

We hebben een zeer open beleid met betrekking tot onze API beschikbaarheid, dus als je gebruik wilt maken van iets dat ASF code al bevat, simpelweg **[open een probleem](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** en leg hier je geplande gebruikscase van de interne API van onze ASF uit. We zullen waarschijnlijk niets tegen hebben, zolang het maar zin heeft om je verhaal te gebruiken. Dit bevat ook alle suggesties met betrekking tot nieuwe `IPlugin` interfaces die zinnig kunnen zijn om toe te voegen om bestaande functies uit te breiden.

Ongeacht de ASF API beschikbaarheid verhindert niets je bijvoorbeeld dat `Discord. et` library in je applicatie en maak een brug tussen je Discord bot en ASF commando's, Omdat uw plugin zelf ook afhankelijkheden kan hebben. De mogelijkheden zijn eindeloos en we hebben ons best gedaan om u zoveel vrijheid en flexibiliteit te geven binnen uw plugin, dus er zijn geen kunstmatige limieten op alles - de plugin wordt geladen in het hoofdASF-proces en kan alles doen wat realistisch gezien mogelijk is vanuit C# code.

---

### API compatibility

Het is belangrijk om te benadrukken dat ASF een consumententoepassing is en niet een typische bibliotheek met vast API-oppervlak waarvan je onvoorwaardelijk kunt vertrouwen. Dit betekent dat je niet kunt aannemen dat de plugin eenmaal gecompileerd blijft werken met alle toekomstige ASF releases niets, hoe dan ook. het is gewoon onmogelijk als we het programma verder willen ontwikkelen en niet in staat zijn zich aan te passen aan voortdurend lopende Steam-wisselingen omwille van achterwaartse compatibiliteit is gewoon niet geschikt voor ons geval. Dit zou logisch voor u moeten zijn, maar het is belangrijk om dat feit te benadrukken.

We zullen ons best doen om openbare onderdelen van ASF werkbaar en stabiel te houden maar we zijn niet bang om de compatibiliteit te breken als er genoeg redenen zijn, volgt onze **[deprecation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation)** beleid in het proces. Dit is vooral belangrijk met betrekking tot interne ASF-structuren die aan u worden blootgesteld als onderdeel van de ASF-infrastructuur (bijv. `ArchiWebHandler`) deze kunnen worden verbeterd (en daarom herschrijven) als onderdeel van ASF verbeteringen in een van de toekomstige versies. We zullen ons best doen om je op de juiste manier op de hoogte te stellen van de changelogs, en gepaste waarschuwingen tijdens de runtime over verouderde functies. We zijn niet van plan om alles te herschrijven omwille van het herschrijven ervan. zodat je er vrij zeker van kunt zijn dat de volgende minor ASF versie niet alleen de plugin vernietigt omdat deze een hoger versienummer heeft, maar het is een heel goed idee om een oogje in het zeil te houden op de changelogs en af en toe te controleren als alles goed werkt.

---

### Plugin afhankelijkheden

De plugin zal ten minste twee afhankelijkheden standaard toevoegen, `ArchiSteamFarm` referentie voor de interne API (`IPlugin` ten minste), en `PackageReference` van `System. Positie.AttributedModel` die nodig is om als ASF plugin te worden herkend om te beginnen met (`[Export]` clause). Daarnaast kan het meer afhankelijkheden bevatten met betrekking tot wat je hebt besloten te doen in je plugin (bijv. . `Discord.Net` bibliotheek als je hebt besloten te integreren met Discord).

De uitvoer van je build zal je core `YourPluginName.dll` bibliotheek bevatten, evenals alle afhankelijkheden waarnaar je hebt verwezen. Omdat je een plugin ontwikkelt naar al werkend programma, hoeft je dat niet te doen, en zelfs **moeten** afhankelijkheden omvatten die ASF al omvat, bijvoorbeeld `ArchiSteamFarm`, `SteamKit2` of `AngleSharp`. Het afbreken van je bouw afhankelijkheden gedeeld met ASF is niet de absolute voorwaarde voor het werken van je plugin maar als je dit doet zal de geheugenvoetafdruk en de grootte van je plugin dramatisch knipperen, samen met het verhogen van de prestaties, vanwege het feit dat ASF zijn eigen afhankelijkheden met u zal delen, en zal alleen die bibliotheken laden die het van zichzelf niet weet.

Over het algemeen is het een aanbevolen praktijk om alleen die bibliotheken op te nemen die ASF niet omvat, of bevat in de foute/incompatibele versie. Voorbeelden hiervan zijn duidelijk `YourPluginName.dl`, maar bijvoorbeeld ook `Discord.Net.dlll` als je ervan afhankelijk zou willen zijn, omdat ASF het zelf niet bevat. Gebundelde libraries die worden gedeeld met ASF kunnen nog steeds zinvol zijn als je voor de compatibiliteit van de API wilt zorgen (bijv. wees er zeker van dat `AngleSharp` waar je van afhankelijk bent in de plugin altijd in versie `X` zal zijn en niet de versie waar ASF vanaf komt), dat moet natuurlijk een prijs zijn voor een hogere geheugengrootte en slechtere prestaties, en daarom moet er zorgvuldig worden geëvalueerd.

Als je weet dat de afhankelijkheid die je nodig hebt is opgenomen in ASF, Je kunt het markeren met `IncludeAssets="compile"` zoals we je hebben laten zien in het voorbeeld `csproj` hierboven. Dit zal de compiler vertellen om de gerefereerde bibliotheek zelf te vermijden, omdat ASF die al bevat. Vergelijk, merk op dat we verwijzen naar het ASF-project met `ExcludeAssets="alle" Private="false"` dat op een heel gelijkaardige manier werkt - de compiler vertelt dat hij geen ASF-bestanden produceert (omdat de gebruiker ze al heeft). Dit geldt alleen voor het ASF-project, want als je verwijst naar een 'dll' bibliotheek, maak je geen ASF-bestanden als onderdeel van je plugin.

Als je verward bent over bovenstaande opdracht en je weet het niet beter, controleer dan welke `dl` bibliotheken zijn opgenomen in `ASF-generic. ip` pakket en zorg ervoor dat je plugin alleen die bevat die er nog geen deel van uitmaken. Dit zal alleen `YourPluginName.dl` zijn voor de meest eenvoudige plugins. Als je tijdens de runtime problemen krijgt met sommige bibliotheken, vermeld dan ook de getroffen bibliotheken. Als al het andere niet lukt, kun je altijd besluiten om alles te bundelen.

---

### Native afhankelijkheden

Oorspronkelijke afhankelijkheden worden gegenereerd als onderdeel van OS-specifieke versies, omdat er geen is. ET runtime beschikbaar op de host en ASF loopt door zijn eigen .NET runtime die is gebundeld als onderdeel van OS-specifieke build. Om de bouwgrootte te minimaliseren, trimt ASF zijn oorspronkelijke afhankelijkheden naar alleen de code die mogelijk binnen het programma kan worden bereikt, die de ongebruikte delen van de runtime effectief verlaagt. Dit kan een potentieel probleem voor u maken met betrekking tot uw plug-in, als je plotseling jezelf te weten komt in een situatie waarin je plug-in afhankelijk is van bepaalde . ET functie die niet wordt gebruikt in ASF, en daarom kunnen OS-specifieke builds het niet goed uitvoeren. Meestal gegooid `System.MissingMethodException` of `System.Reflection.ReflectionTypeLoadException` in het proces. Naarmate de plugin groter wordt en steeds complexer wordt, Vroeg of laat kun je het oppervlak raken dat niet door onze OS-specifieke versie wordt gedekt.

Dit is nooit een probleem met generieke gebouwen, omdat deze nooit in de eerste plaats te maken hebben met inheemse afhankelijkheden (omdat ze volledige werktijd op de host hebben, voert ASF uit). Daarom is het een aanbevolen praktijk om de **plugin in generieke versies exclusief te gebruiken**, maar dat heeft duidelijk zijn eigen nadeel van het knippen van de plugin van gebruikers die draaien op OS-specifieke versies van ASF. Als je je afvraagt of je probleem gerelateerd is aan inheemse afhankelijkheden, je kunt deze methode ook gebruiken voor verificatie, de plugin laden in generieke ASF bouwen en kijken of het werkt. Als het dit doet, heb je plugin afhankelijkheden gedekt, en het is de native afhankelijkheden die problemen veroorzaken.

Helaas hebben we een moeilijke keuze moeten maken tussen het publiceren van hele runtime als onderdeel van onze OS-specifieke builds, en besluit om het uit ongebruikte functies te knippen, waardoor de bouw van meer dan 80 MB kleiner is dan de volledige versie. We hebben de tweede optie gekozen, en het is helaas onmogelijk voor u om de ontbrekende runtime functies samen met uw plugin toe te voegen. Als je project toegang nodig heeft tot runtime functies die niet beschikbaar zijn, moet je er volledig van toevoegen. ET runtime waar je van afhankelijk bent, en dat betekent dat je de plugin in 'generic' ASF smaak draait. Je kunt de plugin niet uitvoeren in OS-specifieke versies, omdat deze versies simpelweg een runtime functie missen die je nodig hebt, en . ET runtime is op dit moment niet in staat om je eigen afhankelijkheid te "samenvoegen" die je met ons had kunnen opbrengen. Misschien zal het ooit in de toekomst verbeteren, maar vanaf nu is het gewoon niet mogelijk.

ASF's OS-specifieke versies bevatten een minimale extra functionaliteit die nodig is om onze officiële plugins uit te voeren. Behalve dat dit mogelijk is, breidt dit de oppervlakte ook enigszins uit tot extra afhankelijkheden die nodig zijn voor de meest basale plugins. Daarom zullen niet alle plug-ins zich zorgen moeten maken over afhankelijkheden van inheemse volken om te beginnen - alleen afhankelijkheden die verder gaan dan wat ASF en onze officiële plug-ins direct nodig hebben. Dit gebeurt als een extra, want als we voor ons eigen gebruik toch nog de inheemse afhankelijkheden zelf moeten meenemen we kunnen ze ook direct met ASF verzenden, zodat ze beschikbaar zijn en daardoor makkelijker te dekken, ook voor jou. Helaas is dit niet altijd voldoende, en aangezien je plugin groter en complexer wordt, neemt de kans toe dat je op trimde functionaliteit werkt. Daarom raden we je meestal aan om je eigen plug-ins alleen maar uit te voeren in `generic` ASF-aroma's. Je kunt nog steeds handmatig controleren of de OS-specifieke versie van ASF alles bevat wat de plugin nodig heeft voor de functionaliteit - maar aangezien die verandert op zowel je updates als de onze, Het zou lastig kunnen zijn om te handhaven.

Soms kan het mogelijk zijn om ontbrekende functies te "werken" door gebruik te maken van alternatieve opties of ze opnieuw te implementeren in uw plugin. Dit is echter niet altijd mogelijk of levensvatbaar, vooral niet als de ontbrekende functie afkomstig is van afhankelijkheden van derden die u als onderdeel van uw plugin toevoegt. U kunt altijd proberen uw plugin uit te voeren in OS-specifieke build en proberen het te laten werken, maar het kan op de lange termijn te veel gedoe worden, vooral als je uit je code wilt werken in plaats van te vechten met ASF-oppervlak.

---

## Automatische updates

ASF biedt je twee interfaces voor het implementeren van automatische updates in je plugin:

- `IGitHubPluginUpdates` biedt een eenvoudige manier om op GitHub gebaseerde updates te implementeren, vergelijkbaar met het algemene ASF updatemechanisme
- `IPluginUpdates` biedt je een lagere functionaliteit die het mogelijk maakt om een aangepast update-mechanisme in te stellen als je iets complexers nodig hebt

---

### **[`IGithubPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs)**

De minimale checklist van dingen die nodig zijn om updates te laten werken:

- Je moet `RepositoryName` beschrijven waar de updates vandaan gehaald worden.
- U moet gebruik maken van tags en releases van GitHub. Tag moet in formaat parsable zijn met een plugin versie, bijvoorbeeld `1.0.0`.
- `Versie` eigenschap van de plugin moet overeenkomen met de tag waar het vandaan komt. Dit betekent dat binary beschikbaar onder tag `1.2.3.4` zichzelf moet presenteren als `1.2.3.4`.
- Elke tag moet een passende release beschikbaar hebben op GitHub met zip bestandsbestand dat binaire pluginbestanden bevat. De binaire bestanden die je `IPlugin` classes bevatten moeten beschikbaar zijn in de hoofdmap in het zip-bestand.

Dit maakt het mechanisme in ASF mogelijk om:

- Los de huidige `Versie` van je plugin op, b.v. `1.0.1`.
- Gebruik de GitHub API voor het ophalen van de laatste `tag` beschikbaar in `RepositoryName` repo, bijvoorbeeld `1.0.2`.
- Bepaal dat `1.0.2` > `1.0.1`, controleer de release van `1.0.2` tag om het `.zip` bestand met de plugin update te vinden.
- Download dat `.zip` bestand, pak het uit en zet de inhoud ervan in de map die eerst `YourPlugin.dl` bevat.
- Herstart ASF om de plugin te laden in `1.0.2` versie.

Aanvullende notities:

- Plugin updates kunnen de juiste ASF configuratie waarden vereisen, namelijk **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)** en/of **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)**.
- Ons plugin sjabloon bevat al alles wat u nodig heeft. eenvoudig **[rename](https://github.com/JustArchiNET/ASF-PluginTemplate?tab=readme-ov-file#renaming-myawesomeplugin)** de plugin naar echte waarden, en hij werkt uit de box.
- Je kunt de combinatie van de nieuwste versie gebruiken, evenals de pre-releases, ze zullen worden gebruikt per `UpdateChannel` die de gebruiker heeft gedefinieerd.
- Er is `CanUpdate` booleaanse eigenschap die je kunt overschrijven voor het uitzetten/inschakelen van plug-ins update aan je kant, bijvoorbeeld als u tijdelijk updates wilt overslaan of om een andere reden.
- Het is mogelijk om meerdere zip-bestanden in de versie te hebben als je andere ASF-versies wilt nastreven. Zie `GetTargetReleaseAsset()` **[remarks](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs#L79-L106)**. U kunt bijvoorbeeld `MyPlugin-V6-0.zip` hebben evenals `MyPlugin.zip`, wat ASF veroorzaakt in versie `V6. .x.x` om de eerste te kiezen, alle andere ASF versies gebruiken de tweede.
- Als bovenstaande niet genoeg is voor jou en je hebt aangepaste logica nodig om de juiste `te kiezen. ip` bestand, je kunt de `GetTargetReleaseAsset()` functie overschrijven en het artefact voor ASF aanbieden.
- Als uw plugin voor / na het bijwerken extra werk moet doen, kunt u `OnPluginUpdateProceeding()` en/of `OnPluginUpdateFinished()` methoden overschrijven.

---

### **[`IPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IPluginUpdates.cs)**

Dit scherm stelt u in staat om aangepaste logica voor updates toe te passen als op een of andere manier `IGithubPluginUpdates` niet voldoende is voor u, bijvoorbeeld omdat je tags hebt die niet parseren voor versies, of omdat je helemaal geen GitHub platform gebruikt.

Er is een enkele `GetTargetReleaseURL()` functie om te overschrijven, welke verwacht van jou `Uri?` van de doel plugin update locatie. ASF biedt je een aantal kernvariabelen die betrekking hebben op de context waarin de functie is aangeroepen, maar verder niet. Je bent verantwoordelijk voor het implementeren van alles wat je nodig hebt in die functie en geeft ASF de URL die gebruikt moet worden. of `null` als de update niet beschikbaar is.

Anders is het vergelijkbaar met GitHub updates, waar de URL naar een ` moet wijzen. ip` bestand met de binaire bestanden beschikbaar in de hoofdmap. Je hebt ook `OnPluginUpdateProceeding()` en `OnPluginUpdateFinished()` methoden beschikbaar.