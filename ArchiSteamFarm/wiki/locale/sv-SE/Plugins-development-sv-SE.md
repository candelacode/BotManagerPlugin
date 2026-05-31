# Utveckling av plugins

ASF innehåller stöd för anpassade plugins som kan laddas under körtid. Plugins låter dig anpassa ASF-beteende, till exempel genom att lägga till anpassade kommandon, anpassad handelslogik eller hela integrationen med tredjepartstjänster och API:er.

Denna sida beskriver ASF plugins från utvecklare perspektiv - att skapa, underhålla, publicera och likaså. Om du vill visa användarens perspektiv, flytta **[here](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** istället.

---

## Kärna

Plugins är standard .NET-bibliotek som definierar en klass som ärver från vanligt `IPlugin`-gränssnitt deklarerat i ASF. Du kan utveckla plugins helt oberoende av mainline ASF och återanvända dem i nuvarande och framtida ASF-versioner, så länge internt ASF API förblir kompatibelt. Plugin-system som används i ASF är baserat på `System. omposition`, tidigare känd som **[Managed Extensibility Framework](https://docs.microsoft.com/dotnet/framework/mef)** som tillåter ASF att upptäcka och ladda dina bibliotek under körtid.

---

### Komma igång

Vi har förberett **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate)** för dig, som du kan (och bör) använda som bas för ditt pluginprojekt. Att använda mallen är **inte ett krav** (som du kan göra allt från början), men vi rekommenderar starkt att plocka upp det eftersom det kan drastiskt kickstarta din utveckling och skära i tid som krävs för att få allt rätt. Kolla bara in **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** i mallen så vägleder den dig vidare. Oavsett, vi täcker grunderna nedan om du vill börja från början, eller få förstå bättre begrepp som används i plugin mallen - du behöver inte normalt göra något av det om du har beslutat att använda vår plugin mall.

Ditt projekt ska vara en standard. ET-bibliotek med lämplig ram för din ASF-version, som anges i avsnittet **[compilation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation)** .

Projektet måste referera till `ArchiSteamFarm`-assembly, antingen dess förbyggda `ArchiSteamFarm. ll` bibliotek som du har hämtat som en del av utgåvan, eller källprojektet (t.ex. om du bestämde dig för att lägga till ASF-träd som en delmodul). Detta ger dig tillgång till och upptäcka ASF strukturer, metoder och egenskaper, speciellt kärnan `IPlugin`-gränssnitt som du måste ärva från i nästa steg. Projektet måste också referera `System.Composition.AttributedModel` till det minimum, vilket gör att du kan `[Export]` din `IPlugin` för ASF att använda. Förutom det, du kanske vill/behöver referera till andra vanliga bibliotek för att tolka de datastrukturer som ges till dig i vissa gränssnitt, men om du inte behöver dem uttryckligen, det kommer att vara tillräckligt för nu.

Om du gjorde allt på rätt sätt kommer din `csproj` att likna nedan:

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <! - Eftersom du laddar plugin in i ASF-processen, som redan innehåller dessa beroenden, IncludeAssets="compile" låter dig utelämna dem från den slutliga utmatningen -->
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" IncludeAssets="compile" Version="10.0.0" />
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="10.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="C:\\Path\To\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" />

    <! - Om du bygger med nedladdad DLL binär, använd detta istället för <ProjectReference> ovan -->
    <! - <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" /> -->
  </ItemGroup>
</Project>
```

Från kodsidan måste din plugin-klass ärva från `IPlugin`-gränssnittet (antingen explicit, eller underförstått genom att ärva från mer specialiserat gränssnitt, såsom `IASF`) och `[Export(ty<unk> f(IPlugin)]` för att kännas igen av ASF under körtid. Det mest nakna exemplet som uppnår detta skulle vara följande:

```csharp
använder System;
med System.Composition;
med System.Threading.Tasks;
med hjälp av ArchiSteamFarm;
med hjälp av ArchiSteamFarm.Plugins;

namnrymd YourNamespace. Vårt PluginName;

[Export(ty<unk> f(IPlugin))]
offentlig förseglad klass YourPluginName : IPlugin {
	<unk> public string Name => nameof(YourPluginName);
	<unk> public Version => ty<unk> f(YourPluginName). ssembly.GetName().Version;

	<unk> public Task OnLoaded() {
		<unk> <unk> ASF.ArchiLogger.LogGenericInfo("Hello World!");

		<unk> <unk> return Task.CompletedTask;
	<unk> }
}
```

För att använda din plugin, måste du först sammanställa den. Du kan göra det antingen från din IDE, eller från rotkatalogen i ditt projekt via ett kommando:

```shell
# Om ditt projekt är fristående (inget behov av att definiera dess namn eftersom det är det enda)
dotnet publish -c "Release" -o "out"

# Om ditt projekt är en del av ASF-källkodsträdet (för att undvika att kompilera onödiga delar)
dotnet publicera YourPluginName -c "Release" -o "out"
```

Efteråt är din plugin redo för distribution. Det är upp till dig hur exakt du vill distribuera och publicera din plugin, men vi rekommenderar att du skapar ett zip-arkiv där du sätter din kompilerade plugin tillsammans med dess **[dependencies](#plugin-dependencies)**. Detta sätt användaren kommer helt enkelt att behöva packa upp ditt zip-arkiv till en fristående underkatalog i deras `plugins`-katalog och göra inget annat.

Detta är bara det mest grundläggande scenariot för att komma igång. Vi har **[`ExamplePlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** projekt som visar exempel gränssnitt och åtgärder som du kan göra i din egen plugin, inklusive användbara kommentarer. Ta gärna en titt om du vill lära dig av en fungerande kod eller upptäck \`ArchiSteamFarm. lugins' namnrymd själv och hänvisa till den medföljande dokumentationen för alla tillgängliga alternativ. Vi kommer också att vidareutveckla några kärnkoncept nedan för att förklara dem bättre.

Om i stället för exempel plugin du vill lära dig från verkliga projekt, det finns flera officiella plugins som utvecklats av oss, t.ex. **[`ItemsMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.ItemsMatcher)**, **[`MobileAuthenticator`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.MobileAuthenticator)** eller **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)**. Utöver det finns det också plugins som utvecklats av andra utvecklare, i vår **[third-party](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** sektion.

---

### API tillgänglighet

ASF, bortsett från vad du har tillgång till i gränssnitten själva, exponerar för dig en hel del av dess interna API:er som du kan använda dig av, för att utöka funktionaliteten. Om du till exempel vill skicka någon form av ny begäran till Steams webb behöver du inte implementera allt från början, särskilt att ta itu med alla de frågor som vi har haft att ta itu med framför dig. Använd helt enkelt vår `Bot. rchiWebHandler` som redan exponerar en hel del `UrlWithSession()` metoder för dig att använda, hanterar alla saker på lägre nivå såsom autentisering, sessionsuppdatering eller webbbegränsning för dig. Likaså, för att skicka webbförfrågningar utanför Steam-plattformen, kan du använda standard .NET `HttpClient` klass, men det är mycket bättre idé att använda `Bot. rchiWebHandler.WebBrowser` som är tillgänglig för dig, vilket återigen erbjuder dig en hjälpsam hand, till exempel när det gäller att försöka misslyckade förfrågningar.

Vi har en mycket öppen policy när det gäller vår API-tillgänglighet, så om du vill använda något som ASF-koden redan innehåller, helt enkelt **[öppna ett problem](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** och förklara i det ditt planerade användningsfall av vårt ASF:s interna API. Vi kommer troligtvis inte att ha något emot, så länge ditt användningsfall är vettigt. Detta inkluderar också alla förslag när det gäller nya `IPlugin`-gränssnitt som kan vara vettigt att läggas till för att utöka befintlig funktionalitet.

Oavsett ASF API-tillgänglighet hindrar dock ingenting dig från t.ex. `Discord. et` bibliotek i din applikation och skapa en bro mellan din Discord bot och ASF kommandon, eftersom din plugin kan också ha beroenden på egen hand. Möjligheterna är oändliga, och vi gjorde vårt bästa för att ge dig så mycket frihet och flexibilitet som möjligt i din plugin, så det finns inga artificiella gränser för något - din plugin är laddad i den huvudsakliga ASF-processen och kan göra allt som är realistiskt möjligt att göra inifrån C# kod.

---

### API compatibility

Det är viktigt att betona att ASF är ett konsumentprogram och inte ett typiskt bibliotek med fast API-yta som du kan lita på villkorslöst. Detta innebär att du inte kan anta att din plugin en gång sammanställts kommer att fortsätta att arbeta med alla framtida ASF utgåvor oavsett, Det är helt enkelt omöjligt om vi vill fortsätta utveckla programmet ytterligare, och att inte kunna anpassa sig till pågående Steam-ändringar för bakåtkompatibiliteten är helt enkelt inte lämpligt för vårt fall. Detta bör vara logiskt för dig, men det är viktigt att belysa detta faktum.

Vi kommer att göra vårt bästa för att hålla offentliga delar av ASF arbetar och stabil, men vi kommer inte att vara rädda för att bryta kompatibiliteten om tillräckligt goda skäl uppstår, följer vår **[deprecation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation)** policy i processen. Detta är särskilt viktigt när det gäller interna ASF-strukturer som utsätts för dig som en del av ASF-infrastruktur (t.ex. `ArchiWebHandler`) som kunde förbättras (och därför skrivas om) som en del av ASF-förbättringar i en av de framtida versionerna. Vi kommer att göra vårt bästa för att informera dig på lämpligt sätt i ändringsloggarna och inkludera lämpliga varningar under körtiden om föråldrade funktioner. Vi har inte för avsikt att skriva om allt för att skriva om det, så att du kan vara ganska säker på att nästa mindre ASF version inte bara helt enkelt förstöra din plugin helt bara för att den har ett högre versionsnummer, men att hålla ett öga på ändringsloggar och tillfällig verifiering om allt fungerar bra är en mycket bra idé.

---

### Tillägg beroenden

Din plugin kommer att innehålla minst två beroenden som standard, `ArchiSteamFarm`-referens för internt API (`IPlugin` på minst) och `PackageReference` i `System. omposition.AttributedModel` som krävs för att bli igenkänd som ASF-plugin för att börja med (`[Export]` klausul). Förutom att det kan innehålla fler beroenden när det gäller vad du har beslutat att göra i din plugin (e. . `Discord.Net` bibliotek om du har bestämt dig för att integrera med Discord).

Utmatningen av din bygga kommer att inkludera din kärna `YourPluginName.dll` bibliotek, liksom alla beroenden som du har refererat. Eftersom du utvecklar en plugin till redan fungerande program, behöver du inte, och även **borde inte** inkludera beroenden som ASF redan inkluderar, till exempel `ArchiSteamFarm`, `SteamKit2` eller `AngleSharp`. Minska dina byggberoenden som delas med ASF är inte det absoluta kravet för att din plugin ska fungera, men gör det kommer att dramatiskt skära minnesavtryck och storleken på din plugin, tillsammans med öka prestandan, på grund av det faktum att ASF kommer att dela sina egna beroenden med dig, och kommer att ladda endast de bibliotek som den inte vet om sig själv.

I allmänhet är det en rekommenderad praxis att endast inkludera de bibliotek som ASF antingen inte inkluderar, eller inkluderar i den felaktiga / inkompatibla versionen. Exempel på dessa skulle vara uppenbarligen `YourPluginName.dll`, men till exempel också `Discord.Net.dll` om du bestämde dig för att bero på det, som ASF inte inkluderar det själv. Paketeringsbibliotek som delas med ASF kan fortfarande vara meningsfullt om du vill säkerställa API-kompatibilitet (t.ex. vara säker på att `AngleSharp` som du är beroende av i din plugin kommer alltid att vara i version `X` och inte den som ASF fartyg med), men naturligtvis gör det kommer till ett pris av ökat minne/storlek och sämre prestanda, och därför bör utvärderas noggrant.

Om du vet att det beroende som du behöver ingår i ASF, du kan markera det med `IncludeAssets="kompilera"` som vi visade dig i exemplet `csproj` ovan. Detta kommer att tala om för kompilatorn att undvika publicering refererade bibliotek själv, eftersom ASF redan inkluderar det. Likaså märker att vi refererar till ASF-projektet med `ExcludeAssets="alla" Private="false"` som fungerar på ett mycket liknande sätt - säger till kompilatorn att inte producera några ASF-filer (som användaren redan har dem). Detta gäller endast när du refererar till ASF-projekt, eftersom om du refererar till ett `dll`-bibliotek, då producerar du inte ASF-filer som en del av din plugin.

Om du är förvirrad om ovanstående uttalande och du inte vet bättre, kontrollera vilka `dll`-bibliotek som ingår i `ASF-generic. ip` paket och se till att din plugin innehåller bara de som inte är en del av det ännu. Detta kommer bara `YourPluginName.dll` för de mest enkla plugins. Om du får några problem under körning när det gäller vissa bibliotek, inkludera de drabbade bibliotek också. Om allt annat misslyckas kan du alltid bestämma dig för att bunta ihop allt.

---

### Inhemska beroenden

Inhemska beroenden genereras som en del av OS-specifika byggen, eftersom det inte finns någon . ET runtime tillgänglig på värden och ASF körs genom sin egen .NET runtime som är paketerad som en del av OS-specifik bygga. För att minimera byggstorleken, ASF trims sina inhemska beroenden att endast inkludera den kod som kan nås inom programmet, som effektivt skär de oanvända delarna av körtiden. Detta kan skapa ett potentiellt problem för dig när det gäller din plugin, om plötsligt du ta reda på dig själv i en situation där din plugin beror på vissa . ET-funktionen som inte används i ASF, och därför OS-specifika byggen kan inte köra det korrekt, vanligtvis kasta `System.MissingMethodException` eller `System.Reflection.ReflectionTypeLoadException` i processen. När din plugin växer i storlek och blir mer och mer komplex, förr eller senare träffar du ytan som inte täcks av vårt OS-specifika bygge.

Detta är aldrig ett problem med generiska byggnationer, eftersom de aldrig har att göra med inhemska beroenden i första hand (som de har fullständig arbetstid på värden, kör ASF). Det är därför det är en rekommenderad praxis att **använda din plugin i generiska byggen exklusivt**, men uppenbarligen som har sin egen nackdel med att skära din plugin från användare som kör OS-specifika byggen av ASF. Om du undrar om ditt problem är relaterat till inhemska beroenden, du kan också använda denna metod för verifiering, ladda din plugin i ASF generisk bygga och se om det fungerar. Om det gör det, har du plugin beroenden omfattas, och det är de inhemska beroenden som orsakar problem.

Tyvärr var vi tvungna att göra ett svårt val mellan att publicera hela körtiden som en del av våra OS-specifika byggen, och beslutar att klippa ut det av oanvända funktioner, vilket gör bygget över 80 MB mindre jämfört med den fulla. Vi har valt det andra alternativet, och det är tyvärr omöjligt för dig att inkludera de saknade runtime funktioner tillsammans med din plugin. Om ditt projekt kräver tillgång till körtidsfunktioner som utelämnas, måste du inkludera fullt. ET runtime som du är beroende av, och det innebär att köra din plugin i `generic` ASF smak. Du kan inte köra din plugin i OS-specifika byggen, eftersom dessa byggen helt enkelt saknar en körtidsfunktion som du behöver, och . ET runtime från och med nu är oförmögen att "slå samman" infödda beroende som du kunde ha försett med vår egen. Kanske kommer det att förbättras en dag i framtiden, men nu är det helt enkelt inte möjligt.

ASF: s OS-specifika byggen inkluderar det absoluta minimum av ytterligare funktionalitet som krävs för att köra våra officiella plugins. Bortsett från att det är möjligt, Detta utvidgar också något ytan till extra beroenden som krävs för de mest grundläggande plugins. Därför behöver inte alla plugins oroa sig för inhemska beroenden till att börja med - bara de som går utöver vad ASF och våra officiella plugins direkt behöver. Detta görs som ett extra, eftersom om vi ändå måste inkludera ytterligare inhemska beroenden själva för våra egna användningsfall. vi kan lika gärna skicka dem direkt med ASF, vilket gör dem tillgängliga, och därmed lättare att täcka, även för dig. Tyvärr är detta inte alltid tillräckligt, och som din plugin blir större och mer komplex, sannolikheten för att köra in trimmade funktioner ökar. Därför rekommenderar vi vanligtvis att du kör dina anpassade plugins i `generic` ASF smak exklusivt. Du kan fortfarande manuellt verifiera att OS-specifika bygga av ASF har allt som din plugin kräver för dess funktionalitet - men eftersom det ändras på dina uppdateringar samt vår, det kan vara knepigt att upprätthålla.

Ibland kan det vara möjligt att "lösa" saknade funktioner genom att antingen använda alternativa alternativ eller omimplementera dem i din plugin. Detta är dock inte alltid möjligt eller livskraftigt, särskilt om den saknade funktionen kommer från tredje part beroenden som du inkluderar som en del av din plugin. Du kan alltid försöka köra din plugin i OS-specifika bygga och försöka få det att fungera, men det kan bli för mycket krångel i längden, särskilt om du vill från din kod till bara fungera, snarare än slåss med ASF yta.

---

## Automatiska uppdateringar

ASF erbjuder dig två gränssnitt för att genomföra automatiska uppdateringar i din plugin:

- `IGitHubPluginUpdates` ger dig enkelt sätt att implementera GitHub-baserade uppdateringar som liknar den allmänna ASF-uppdateringsmekanismen
- `IPluginUpdates` ger dig funktionalitet på lägre nivå som möjliggör anpassad uppdateringsmekanism, om du behöver något mer komplext

---

### **[`IGithubPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs)**

Den minsta checklistan över saker som krävs för att uppdateringar ska fungera:

- Du måste deklarera `RepositoryName`, som definierar varifrån uppdateringarna hämtas.
- Du måste använda dig av taggar och utgåvor som tillhandahålls av GitHub. Taggen måste vara i formatet liknelse till en plugin-version, t.ex. `1.0.0.0`.
- `Version` egenskap för plugin måste matcha tagg som den kommer från. Detta innebär att binär tillgänglig under taggen `1.2.3.4` måste presentera sig som `1.2.3.4`.
- Varje tagg bör ha lämplig release tillgänglig på GitHub med zip-fil release tillgång som innehåller dina plugin binära filer. De binära filerna som inkluderar dina `IPlugin`-klasser bör vara tillgängliga i rotkatalogen i zip-filen.

Detta kommer att tillåta mekanismen i ASF att:

- Lös aktuell `Version` av din plugin, t.ex. `1.0.1`.
- Använd GitHub API för att hämta senaste `tag` tillgänglig i `RepositoryName` repo, t.ex. `1.0.2`.
- Bestäm den där `1.0.2` > `1.0.1`, kontrollera versionen av `1.0.2`-taggen för att hitta `.zip`-filen med plugin-uppdateringen.
- Ladda ner den `.zip`-filen, extrahera den och lägg dess innehåll i katalogen som inkluderade `YourPlugin.dll` innan.
- Starta om ASF för att ladda din plugin i `1.0.2` version.

Ytterligare anteckningar:

- Pluginuppdateringar kan kräva lämpliga ASF-konfigurationsvärden, nämligen **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)** och/eller **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)**.
- Vår plugin mall innehåller redan allt du behöver, helt enkelt **[rename](https://github.com/JustArchiNET/ASF-PluginTemplate?tab=readme-ov-file#renaming-myawesomeplugin)** plugin till korrekta värden, och det kommer att fungera ur rutan.
- Du kan använda en kombination av senaste versionen såväl som förhandsutgåvor, de kommer att användas enligt `UpdateChannel` användaren har definierat.
- Det finns `CanUpdate` boolesk egenskap som du kan åsidosätta för att inaktivera/aktivera plugins uppdatering på din sida, till exempel om du vill hoppa över uppdateringar tillfälligt, eller av någon annan anledning.
- Det är möjligt att ha flera zip-filer i utgåvan om du vill rikta olika ASF-versioner. Se `GetTargetReleaseAsset()` **[remarks](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs#L79-L106)**. Till exempel kan du ha `MyPlugin-V6-0.zip` samt `MyPlugin.zip`, vilket kommer att orsaka ASF i version `V6. .x.x` för att välja den första, medan alla andra ASF-versioner kommer att använda den andra.
- Om ovanstående inte är tillräckligt för dig och du behöver anpassad logik för att välja rätt `. ip`-filen kan du åsidosätta funktionen `GetTargetReleaseAsset()` och tillhandahålla artefakten för ASF att använda.
- Om din plugin behöver göra lite extra arbete före/efter uppdatering kan du åsidosätta `OnPluginUpdateProceeding()` och/eller `OnPluginUpdateFinished()` metoder.

---

### **[`IPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IPluginUpdates.cs)**

Detta gränssnitt låter dig implementera anpassad logik för uppdateringar om av någon anledning `IGithubPluginUpdates` inte är tillräckligt för dig, till exempel för att du har taggar som inte tolkar versioner, eller för att du inte använder GitHub-plattformen alls.

Det finns en enda `GetTargetReleaseURL()` funktion som du kan åsidosätta, vilket förväntar sig av dig `Uri?` av uppdateringsplats för målplugin. ASF ger dig några centrala variabler som relaterar till sammanhanget funktionen kallades med, men andra än det, du ansvarar för att implementera allt du behöver i den funktionen och tillhandahålla ASF den URL som ska användas, eller `null` om uppdateringen inte är tillgänglig.

Annat än så, det liknar GitHub uppdateringar, där URL:en ska peka på en `. ip`-filen med de binära filerna som finns i rotkatalogen. Du har också `OnPluginUpdateProceeding()` och `OnPluginUpdateFinished()` tillgängliga metoder.