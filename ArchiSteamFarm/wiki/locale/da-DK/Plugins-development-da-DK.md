# Udvikling af plugins

ASF inkluderer understøttelse af brugerdefinerede plugins, der kan indlæses under runtime. Plugins giver dig mulighed for at tilpasse ASF adfærd, for eksempel ved at tilføje brugerdefinerede kommandoer, brugerdefineret handel logik eller hele integration med tredjeparts tjenester og API'er.

Denne side beskriver ASF plugins fra udviklere perspektiv - oprettelse, vedligeholdelse, udgivelse og ligeledes. Hvis du ønsker at se brugerens perspektiv, flyt **[here](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** i stedet.

---

## Kerne

Plugins er standard .NET biblioteker, der definerer en klasse arvet fra almindelig `IPlugin` grænseflade erklæret i ASF. Du kan udvikle plugins helt uafhængigt af mainline ASF og genbruge dem i nuværende og fremtidige ASF versioner, så længe intern ASF API forbliver kompatibel. Plugin-system, der bruges i ASF, er baseret på `System. omposition`, tidligere kendt som **[Managed Extensibility Framework](https://docs.microsoft.com/dotnet/framework/mef)** som tillader ASF at opdage og indlæse dine biblioteker under kørsel.

---

### Kom godt i gang

Vi har udarbejdet **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate)** til dig, som du kan (og burde) bruge som base for dit plugin-projekt. Brug af skabelonen er **ikke et krav** (som du kan gøre alt fra bunden), men vi anbefaler stærkt at samle det op, da det kan drastisk kickstart din udvikling og skære på tid kræves for at få alle ting i orden. Bare tjek **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** af skabelonen, og det vil guide dig yderligere. Uanset hvad, vil vi dække det grundlæggende nedenfor, hvis du ønskede at starte fra bunden, eller få bedre at forstå de begreber, der anvendes i plugin skabelonen - du behøver normalt ikke at gøre noget af det, hvis du har besluttet at bruge vores plugin skabelon.

Dit projekt bør være en standard . ET bibliotek targetting appropriate framework of your target ASF version, as specified in the **[compilation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation)** section.

Projektet skal henvise til main `ArchiSteamFarm` forsamling, enten dens forudbyggede `ArchiSteamFarm. ll` bibliotek, som du har hentet som en del af udgivelsen, eller kildeprojektet (f.eks. hvis du besluttede at tilføje ASF træ som et delmodul). Dette vil give dig adgang til og opdage ASF strukturer, metoder og egenskaber, især kernen `IPlugin` interface, som du skal arve fra i det næste trin. Projektet skal også referere `System.Composition.AttributedModel` som minimum, som giver dig mulighed for at `[Export]` din `IPlugin` for ASF at bruge. Ud over det, du kan ønske/behov for at henvise til andre almindelige biblioteker for at fortolke de datastrukturer, der er givet til dig i nogle grænseflader, men medmindre du har brug for dem udtrykkeligt, vil det være nok for nu.

Hvis du gjorde alt ordentligt, vil din `csproj` ligne nedenfor:

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <! - Da du indlæser plugin i ASF processen, som allerede omfatter disse afhængigheder, InkludeAssets="compile" giver dig mulighed for at udelade dem fra det endelige output -->
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" IncludeAssets="compile" Version="10.0.0" />
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="10.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="C:\\Path\To\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" />

    <! - If building with downloaded DLL binary, use this instead of <ProjectReference> above -->
    <! - <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" /> -->
  </ItemGroup>
</Project>
```

Fra kodesiden, skal din plugin klasse arve fra `IPlugin` grænseflade (enten eksplicit, eller implicit ved at arve fra mere specialiserede interface, såsom »IASF«) og »[Export(typeaf(IPlugin))]« for at blive anerkendt af ASF under kørsel. Det mest nøgne eksempel, der opnås, at det ville være følgende:

```csharp
brug af System;
ved hjælp af System.Composition;
ved hjælp af System.Threading.Tasks;
ved hjælp af ArchiSteamFarm;
ved hjælp af ArchiSteamFarm.Plugins;

namespace YourNamespace. ourPluginName;

[Export(typeof(IPlugin))]
public sealed class YourPluginName : IPlugin {
	evident public string Name => nameof(YourPluginName);
	open, public Version => typeof(YourPluginName). ssembly.GetName().Version;

	řpublic Task OnLoaded() {
		řřřasF.ArchiLogger.LogGenericInfo("Hej Verden!");

		řřřreturn Opgave.FuldførtOpgave;
	ř}
}
```

For at gøre brug af dit plugin, skal du først kompilere det. Du kan gøre det enten fra din IDE, eller fra rodmappen i dit projekt via en kommando:

```shell
# Hvis dit projekt er standalone (ingen grund til at definere sit navn, da det er den eneste)
dotnet publicere -c "Release" -o "out"

# Hvis dit projekt er en del af ASF kildetræ (for at undgå at kompilere unødvendige dele)
dotnet publicere YourPluginName -c "Release" -o "out"
```

Bagefter, dit plugin er klar til implementering. Det er op til dig, hvordan præcis du ønsker at distribuere og udgive dit plugin, men vi anbefaler at oprette et zip-arkiv, hvor du vil sætte dit kompilerede plugin sammen med dets **[dependencies](#plugin-dependencies)**. På denne måde vil brugeren blot nødt til at pakke din zip-arkiv ud i en standalone undermappe inde i deres `plugins` mappe og gøre intet andet.

Dette er kun det mest grundlæggende scenarie for at få dig i gang. Vi har **[`EksempelPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** projekt, der viser dig eksempel grænseflader og handlinger, som du kan gøre i dit eget plugin, herunder nyttige kommentarer. Du er velkommen til at tage et kig på, hvis du gerne vil lære af en arbejdskode, eller opdager `ArchiSteamFarm. selv lugins` namespace og referer til den medfølgende dokumentation for alle tilgængelige muligheder. Vi vil også uddybe nogle centrale begreber nedenfor for at forklare dem bedre.

Hvis du i stedet for eksempel plugin ønsker at lære af virkelige projekter, er der flere officielle plugins udviklet af os, f.eks **[`ItemsMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.ItemsMatcher)**, **[`MobileAuthenticator`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.MobileAuthenticator)** eller **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)**. Derudover er der også plugins udviklet af andre udviklere, i vores **[third-party](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** sektion.

---

### API tilgængelighed

ASF, bortset fra hvad du har adgang til i grænsefladerne selv, udsætter for dig en masse af sine interne API'er, som du kan gøre brug af, for at udvide funktionaliteten. For eksempel, hvis du gerne vil sende en form for ny anmodning til Steam-web, så behøver du ikke at implementere alt fra bunden især beskæftiger sig med alle de problemer, vi har haft at håndtere før dig. Du skal blot bruge vores `Bot. rchiWebHandler` som allerede udsætter en masse `UrlWithSession()` metoder til at bruge håndtere alle de lavere niveauer ting såsom godkendelse, session refresh eller web begrænsning for dig. Ligeledes for at sende webanmodninger uden for Steam-platformen, kan du bruge standard .NET `HttpClient` klasse, men det er meget bedre at bruge `Bot. rchiWebHandler.WebBrowser` der er tilgængelig for dig, som igen tilbyder dig en nyttig hånd, for eksempel i forhold til at prøve mislykkede anmodninger.

Vi har en meget åben politik med hensyn til vores API-tilgængelighed, så hvis du gerne vil gøre brug af noget, ASF kode allerede omfatter, simpelthen **[åbne et problem](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** og forklare i det din planlagte brug tilfælde af vores ASF's interne API. Vi vil sandsynligvis ikke have noget imod, så længe din brug kasse giver mening. Dette omfatter også alle forslag i forhold til nye IPlugin-grænseflader, der kunne give mening at blive tilføjet for at udvide eksisterende funktionalitet.

Uanset ASF API tilgængelighed er der dog intet, der forhindrer dig i f.eks. at inkludere `Discord. et` bibliotek i dit program og oprette en bro mellem din Discord bot og ASF kommandoer, da din plugin også kan have afhængigheder på sin egen. Mulighederne er uendelige, og vi gjorde vores bedste for at give dig så meget frihed og fleksibilitet som muligt inden for dit plugin, så der er ingen kunstige begrænsninger på noget - din plugin er indlæst i den vigtigste ASF proces og kan gøre alt, der er realistisk muligt at gøre fra inden for C # kode.

---

### API compatibility

Det er vigtigt at understrege, at ASF er et forbrugerprogram og ikke et typisk bibliotek med fast API-overflade, som du kan afhænge af betingelsesløst. Det betyder, at du ikke kan antage, at dit plugin når kompileret vil fortsætte med at arbejde med alle fremtidige ASF udgivelser uanset, det er simpelthen umuligt, hvis vi ønsker at fortsætte med at udvikle programmet yderligere, at være ude af stand til at tilpasse sig til stadigt igangværende Steam-ændringer af hensyn til baglæns kompatibilitet er bare ikke egnet til vores sag. Dette bør være logisk for jer, men det er vigtigt at fremhæve dette faktum.

Vi vil gøre vores bedste for at holde offentlige dele af ASF arbejde og stabil men vi vil ikke være bange for at bryde kompatibiliteten, hvis gode nok grunde opstår, følger vores **[deprecation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation)** politik i processen. Dette er især vigtigt i forhold til interne ASF strukturer, der er udsat for dig som en del af ASF infrastruktur (f.eks. `ArchiWebHandler`) som kunne forbedres (og derfor omskrivning) som en del af ASF forbedringer i en af de fremtidige versioner. Vi vil gøre vores bedste for at informere dig korrekt i changelogs og inkludere passende advarsler under kørslen om forældede funktioner. Vi har ikke til hensigt at omskrive alt for at omskrive det, så du kan være temmelig sikker på, at den næste mindre ASF version ikke bare bare ødelægge dit plugin udelukkende fordi det har en højere version nummer, men at holde øje med changelogs og lejlighedsvis kontrol, hvis alt fungerer fint er en meget god idé.

---

### Plugin afhængigheder

Dit plugin vil indeholde mindst to afhængigheder som standard, `ArchiSteamFarm` reference for intern API (`IPlugin` i det mindste), og `PackageReference` af `System. omposition.AttributedModel` der kræves for at blive genkendt som ASF plugin til at begynde med (`[Export]` klausul). Ud over det, kan det omfatte flere afhængigheder i forhold til, hvad du har besluttet at gøre i dit plugin (f. eks. . `Discord.Net` bibliotek, hvis du har besluttet at integrere med Discord).

Outputtet fra din build vil omfatte din kerne `YourPluginName.dll` bibliotek, samt alle de afhængigheder, du har refereret til. Da du er ved at udvikle et plugin til allerede fungerende program, behøver du ikke, og selv **bør ikke** omfatte afhængigheder, som ASF allerede omfatter, for eksempel `ArchiSteamFarm`, `SteamKit2` eller `AngleSharp`. At fjerne dine afhængigheder, der deles med ASF, er ikke det absolutte krav for dit plugin til at fungere men gør det vil dramatisk skære hukommelsen fodaftryk og størrelsen af dit plugin, sammen med øget præstation, fordi ASF vil dele sine egne afhængigheder med dig, og vil kun indlæse de biblioteker, som det ikke kender til sig selv.

Generelt er det en anbefalet praksis at medtage kun de biblioteker, som ASF enten ikke omfatter, eller inkluderer i den forkerte/inkompatible version. Eksempler på dem ville naturligvis `YourPluginName.dll`, men for eksempel også `Discord.Net.dll` hvis du besluttede at afhænge af det, da ASF ikke omfatter det selv. Bundtning biblioteker, der deles med ASF, kan stadig give mening, hvis du ønsker at sikre API-kompatibilitet (f.eks. være sikker på, at `AngleSharp` som du er afhængig af i dit plugin vil altid være i version `X` og ikke den, ASF skibe med), men selvfølgelig gør det kommer for en pris på øget hukommelse/størrelse og dårligere ydeevne, og derfor bør nøje evalueres.

Hvis du ved, at den afhængighed, du har brug for, er inkluderet i ASF, du kan markere det med `IncludeAssets="compile"` som vi viste dig i eksemplet `csproj` ovenfor. Dette vil fortælle compileren for at undgå at offentliggøre refererede bibliotek selv, da ASF allerede omfatter denne. Ligeledes varsel om, at vi refererer til ASF projektet med `ExcludeAssets="all" Private="false"` som virker på en meget lignende måde - at fortælle compiler til ikke at producere nogen ASF filer (som brugeren allerede har dem). Dette gælder kun, når du refererer til ASF projekt, da hvis du refererer til et `dll` bibliotek, så du ikke producerer ASF filer som en del af dit plugin.

Hvis du er forvirret over ovenstående erklæring, og du ikke ved bedre, skal du kontrollere, hvilke `dll` biblioteker der er inkluderet i `ASF-generic. ip` pakke og sikre, at dit plugin kun omfatter dem, der ikke er en del af det endnu. Dette vil kun være `YourPluginName.dll` for de mest enkle plugins. Hvis du får nogen problemer under runtime i forhold til nogle biblioteker, omfatter de berørte biblioteker samt. Hvis alt andet mislykkes, kan du altid beslutte at bundle alt.

---

### Indfødte afhængigheder

Indfødte afhængigheder genereres som en del af OS-specifikke bygninger, da der ikke er nogen . ET runtime tilgængelig på værten og ASF kører gennem sin egen .NET runtime, der er bundtet som en del af OS-specifik bygning. For at minimere den byggestørrelse, ASF trimmer sine indfødte afhængigheder til at omfatte kun den kode, der kan nås inden for programmet, som effektivt skærer de ubrugte dele af driftstiden. Dette kan skabe et potentielt problem for dig i forhold til dit plugin, hvis pludselig du finder ud af dig selv i en situation, hvor dit plugin afhænger af nogle. ET-funktion, der ikke bruges i ASF, og derfor kan OS-specifikke builds ikke udføre det korrekt, normalt smide `System.Manglende MetodeUndtagelse` eller `System.ReflektionTypeLoadException` i processen. Som dit plugin vokser i størrelse og bliver mere og mere kompleks, Før eller senere vil du ramme den overflade, der ikke er dækket af vores OS-specifikke bygning.

Dette er aldrig et problem med generiske bygninger, fordi de aldrig beskæftiger sig med indfødte afhængigheder i første omgang (som de har fuldført arbejdstiden på værten, udføre ASF). Det er derfor, det er en anbefalet praksis at \*\* bruge dit plugin i generiske builds eksklusivt\*\*, men naturligvis der har sin egen ulempe ved at skære dit plugin fra brugere, der kører OS-specifikke builds af ASF. Hvis du spekulerer på, om dit problem er relateret til indfødte afhængigheder, du kan også bruge denne metode til verifikation, indlæse dit plugin i ASF generisk build og se om det virker. Hvis det gør, har du plugin afhængigheder dækket, og det er de indfødte afhængigheder forårsager problemer.

Desværre var vi nødt til at træffe et hårdt valg mellem at udgive hele driftstiden som en del af vores OS-specifikke bygninger, og beslutter at skære det ud af ubrugte funktioner, hvilket gør bygningen over 80 MB mindre i forhold til den hele. Vi har valgt den anden mulighed, og det er desværre umuligt for dig at inkludere de manglende runtime funktioner sammen med dit plugin. Hvis dit projekt kræver adgang til runtime funktioner, der er udeladt, skal du inkludere fuld . ET runtime, som du er afhængig af, og det betyder at køre dit plugin i `generisk` ASF smag. Du kan ikke køre din plugin i OS-specifikke bygninger, da disse builds simpelthen mangler en runtime funktion, som du har brug for, og. ET runtime fra nu er ude af stand til at "fusionere" indfødte afhængighed, som du kunne have forsynet med vores egen. Måske vil det blive forbedret en dag i fremtiden, men fra nu af er det simpelthen ikke muligt.

ASF's OS-specifikke builds omfatter det minimum af ekstra funktionalitet, der er nødvendigt for at køre vores officielle plugins. Bortset fra dette er muligt, dette også lidt udvider overfladen til ekstra afhængigheder, der kræves for de mest grundlæggende plugins. Derfor behøver ikke alle plugins at bekymre sig om indfødte afhængigheder til at begynde med - kun dem, der går ud over, hvad ASF og vores officielle plugins direkte behov. Dette gøres som en ekstra, for hvis vi har brug for at medtage yderligere indfødte afhængigheder os selv til vores egen brug tilfælde alligevel, Vi kan lige så godt sende dem direkte med ASF, gøre dem tilgængelige, og derfor lettere at dække, også for dig. Desværre, dette er ikke altid nok, og som din plugin bliver større og mere kompleks, sandsynligheden for at løbe ind i trimmet funktionalitet stiger. Derfor anbefaler vi dig normalt at køre dine brugerdefinerede plugins i `generisk` ASF smag eksklusivt. Du kan stadig manuelt bekræfte, at OS-specifik build af ASF har alt, hvad dit plugin kræver for sin funktionalitet - men da der ændres på dine opdateringer samt vores, det kan være svært at vedligeholde.

Nogle gange kan det være muligt at "løsning" manglende funktioner ved enten at bruge alternative muligheder eller genimplementere dem i dit plugin. Dette er dog ikke altid muligt eller levedygtig, især hvis den manglende funktion kommer fra tredjeparts afhængigheder, som du inkluderer som en del af dit plugin. Du kan altid forsøge at køre dit plugin i OS-specifikke bygge og forsøge at gøre det arbejde, men det kan blive for meget besvær i det lange løb, især hvis du ønsker fra din kode til bare at arbejde, i stedet for at kæmpe med ASF overflade.

---

## Automatiske opdateringer

ASF tilbyder dig to grænseflader til implementering af automatiske opdateringer i dit plugin:

- `IGitHubPluginopdateringer` giver dig nem måde at implementere GitHub-baserede opdateringer svarende til generelle ASF opdateringsmekanisme
- `IPluginopdatering` giver dig et lavere niveau funktionalitet, der giver mulighed for brugerdefineret opdateringsmekanisme, hvis du har brug for noget mere kompliceret

---

### **[`IGithubPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs)**

Den mindste tjekliste over ting, der er nødvendige for opdateringer til at fungere:

- Du skal deklarere `RepositoryName`, som definerer, hvor opdateringerne er trukket fra.
- Du skal gøre brug af tags og udgivelser fra GitHub. Tag skal være i format parsable til en plugin version, fx `1.0.0.0`.
- `Version` egenskaben for plugin skal matche tag som det kommer fra. Det betyder, at binært, der er tilgængeligt under mærket »1.2.3.4«, skal fremstå som »1.2.3.4«.
- Hvert tag skal have passende udgivelse tilgængelig på GitHub med zip-fil frigivelse aktiv, der indeholder dine plugin binære filer. De binære filer som indeholder dine IPlugin\` klasser skal være tilgængelige i rodmappen i zip-filen.

Dette vil gøre det muligt for mekanismen i ASF at:

- Løs nuværende `Version` af dit plugin, f.eks. `1.0.1`.
- Brug GitHub API til at hente seneste `tag` tilgængelig i `RepositoryName` repo, f.eks. `1.0.2`.
- Afgør at `1.0.2` > `1.0.1`, tjek udgivelsen af `1.0.2` tag for at finde `.zip` fil med pluginopdateringen.
- Download denne `.zip` fil, uddrag den, og placer dens indhold i den mappe, der omfattede `YourPlugin.dll` før.
- Genstart ASF for at indlæse dit plugin i `1.0.2` version.

Supplerende bemærkninger

- Plugin opdateringer kan kræve passende ASF config værdier, nemlig **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)** og/eller **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)**.
- Vores plugin skabelon indeholder allerede alt, hvad du har brug for, simpelthen **[rename](https://github.com/JustArchiNET/ASF-PluginTemplate?tab=readme-ov-file#renaming-myawesomeplugin)** plugin til rigtige værdier, og det vil arbejde ud af boksen.
- Du kan bruge en kombination af nyeste udgivelse samt pre-releases, de vil blive brugt som pr `UpdateChannel` brugeren har defineret.
- Der er `CanUpdate` boolske ejendom du kan tilsidesætte for deaktivering / aktivering plugins opdatering på din side, for eksempel, hvis du ønsker at springe opdateringer midlertidigt, eller gennem en anden grund.
- Det er muligt at have flere zip-filer i udgivelsen, hvis du ønsker at målrette forskellige ASF-versioner. Se 'GetTargetReleaseAsset()`**[remarks](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs#L79-L106)**. For eksempel kan du have`MyPlugin-V6-0.zip`samt`MyPlugin.zip`, hvilket vil forårsage ASF i version `V6. .x.x\` til at vælge den første, mens alle andre ASF versioner vil bruge den anden.
- Hvis ovenstående ikke er tilstrækkelig til dig, og du har brug for brugerdefineret logik til at plukke den korrekte `. ip` fil, kan du tilsidesætte funktionen 'GetTargetReleaseAsset()' og give artefakten for ASF at bruge.
- Hvis dit plugin skal gøre nogle ekstra arbejde før/efter opdatering, kan du tilsidesætte `OnPluginUpdateProceeding()` og/eller `OnPluginUpdateFinished()` metoder.

---

### **[`IPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IPluginUpdates.cs)**

Denne grænseflade giver dig mulighed for at implementere brugerdefineret logik til opdateringer, hvis af en eller anden grund `IGithubPluginopdateringer` ikke er tilstrækkelig til dig, for eksempel, fordi du har tags, der ikke fortolker til versioner, eller fordi du ikke bruger GitHub platform overhovedet.

Der er en enkelt `GetTargetReleaseURL()` funktion for dig at tilsidesætte, som forventer af dig `Uri?` af målet plugin opdatering placering. ASF giver dig nogle centrale variabler, der relaterer til den kontekst, funktionen blev kaldt med, men andet end det, du er ansvarlig for at implementere alt hvad du behøver i denne funktion og give ASF den URL, der skal bruges, eller \`null', hvis opdateringen ikke er tilgængelig.

Andet end det, det svarer til GitHub opdateringer, hvor webadressen skal pege på et `. ip` fil med de binære filer der er tilgængelige i rodmappen. Du har også `OnPluginUpdateProceeding()` og `OnPluginUpdateFinished()` tilgængelige metoder.