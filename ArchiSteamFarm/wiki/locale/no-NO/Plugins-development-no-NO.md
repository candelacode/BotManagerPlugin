# Utvikling av programtillegg

ASF inkluderer støtte for egendefinerte plugins som kan lastes inn under kjøretiden. Programtillegg lar deg tilpasse ASF-atferd, for eksempel ved å legge til egendefinerte kommandoer, egendefinert handelslogikk eller hele integrasjon med tredjepartstjenester og APIer.

Denne siden beskriver ASF-tillegg fra utviklerperspektiv - skaper, vedlikeholde, publiserer og på samme måte. Hvis du vil vise brukerens perspektiv, flytt \*\*[here](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins) \*\* i stedet.

---

## Kjerne

Plugins er standard .NET biblioteker som definerer en klasse arving fra felles `IPlugin` grensesnitt deklarert i ASF. Du kan utvikle plugins helt uavhengig av mainline ASF og bruke dem på nytt i nåværende og fremtidige ASF-versjoner, Så lenge intern ASF API forblir kompatibel. Utvidelsessystemet som brukes i ASF er basert på `System. omposisjon`, tidligere kjent som **[Managed Extensibility Framework](https://docs.microsoft.com/dotnet/framework/mef)** slik at ASF kan oppdage og laste dine biblioteker under kjøretid.

---

### Komme i gang

Vi har forberedt **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate) \*\* for deg, som du kan (og bør) bruke som en base for ditt plugin-prosjekt. Bruk av malen er **ikke et krav** (som du kan gjøre alt fra bunnen av), men vi anbefaler sterkt å hente den ettersom den kan starte utviklingen drastisk og skjære på tid det kreves for å få alle ting riktig. Bare sjekk ut malen**[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)\*\* av malen og så vil den veilede deg videre. Uansett vil vi dekke det grunnleggende nedenfor i tilfelle du ønsker å starte fra grunnen, eller bli bedre kjent med konseptene som brukes i plugin-malen – du trenger vanligvis ikke gjøre noe av det dersom du har bestemt deg for å bruke plugin-malen.

Prosjektet ditt må være en standard . ET-bibliotek som minner om hensiktsmessig rammeverk for ditt mål ASF-versjon, som angitt i **[compilation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation)** avsnittet.

Prosjektet må referere til hovedsamlingen "ArchiSteamFarm", enten den har bygget "ArchiSteamFarm. ll`-biblioteket du har lastet ned som en del av frigivelsen, eller kildekodeprosjektet (f.eks. hvis du bestemte deg for å legge til ASF-tre som en undermodul). Dette vil gi deg tilgang til og oppdag ASF-strukturer, metoder og egenskaper, spesielt kjerne `IPlugin`-grensesnittet som du må arve fra i neste trinn. Prosjektet må også referere til `System.Composition.AttributedModel`til et minimum, som lar deg`[Export]`din`IPlugin\` for ASF å bruke. I tillegg til det, du kan ønske/være nødt til å referere til andre vanlige biblioteker for å tolke datastrukturene som er gitt deg i enkelte grensesnitt; men med mindre du trenger dem eksplisitt, vil det være nok for nå.

Hvis du gjorde alt ordentlig, vil din `csproj` være lik nedenfor:

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <! - Siden du laster inn plugin i ASF-prosessen, som allerede omfatter disse avhengighetene, IncludeAssets="kompilere" lar deg utelate dem fra den endelige utgangen -->
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" IncludeAssets="compile" Version="10.0.0" />
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="10.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="C:\\Path\To\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" />

    <! -Hvis en bygning med nedlastet DLL-binær, bruk dette istedet for <ProjectReference> over -->
    <! - <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" /> -->
  </ItemGroup>
</Project>
```

Fra kodesiden må plugin klassen arve fra grensesnittet `IPlugin` (enten eksplisitt, eller implisitt ved å arve fra mer spesialisert grensesnitt, slik som `IASF`) og `[Export(typeof(IPlugin)]` for å bli gjenkjent av ASF i løpet av løpetiden. Det mest bare eksemplet som gir det følgende:

```csharp
via System;
bruker System.Composition;
ved hjelp av System.Threading.Tasks;
ved bruk av ArchiSteamFarm;
ved bruk av ArchiSteamFarm.Plugins;

navnerom YourNamespace. ourPluginName;

[Export(typeof(IPlugin))]
offentlige forseglede klassen YourPluginName : IPlugin {
	intramufler navn => nameof(YourPluginName);
	VFpublic Version => typeof(YourPluginName). ssembly.GetName().Versjon;

	intramubel offentlig oppgave OnLoaded() {
		τ ASF.ArchiLogger.LogGenericInfo("Hallo World!");

		ART retur T.CompletedaskTask;
	Aer}
}
```

Du må først kompilere den for å kunne bruke utvidelsen. Du kan gjøre det som enten fra din IDE, eller fra rotkatalogen til prosjektet via en kommando:

```shell
# Hvis prosjektet er frittstående (ingen trenger å definere navn siden det er det eneste siden det er )
dotnet publisere -c "Release" -o "out"

# Hvis prosjektet er en del av ASF-kildetreet (for å unngå å kompilere unødvendige deler)
dotnet publisere YourPluginName -c "Release" -o "ut"
```

Etterpå er utvidelsen din klar for distribusjon. Det er opp til deg hvor nøyaktig du ønsker å distribuere og publisere utvidelsen din, men vi anbefaler å lage et zip-arkiv hvor du vil sette din kompilerte plugin sammen med den\*\*[dependencies](#plugin-dependencies)\*\*. Denne måten brukeren vil rett og slett trenge å pakke ut zip-arkivet ditt i en frittstående undermappe inne i sin `plugins` mappe og gjør ingenting annet.

Dette er det eneste grunnleggende scenarioet du kommer i gang. Vi har **[`ExamplePlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** prosjekt som viser deg eksempelgrensesnitt og handlinger som du kan gjøre i din egen plugin, inkludert nyttige kommentarer. Ta gjerne en titt på om du har lyst til å lære av en arbeidskode, eller oppdag `ArchiSteamFarm. Sukker` navneområdet deg selv og henviser til den inkluderte dokumentasjonen for alle tilgjengelige alternativer. Vi vil også videreutvikle hovedbegrepene nedenfor for å forklare dem bedre.

Hvis det i stedet for eksempel vil du lære av virkelige prosjekter, finnes flere offisielle plugins utviklet av oss, for eksempel **[`ItemsMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.ItemsMatcher)**, **[`MobileAuthenticator`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.MobileAuthenticator)** eller **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)**. I tillegg til at det finnes også utvidelser som er utviklet av andre utviklere, i vår **[third-party](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** del.

---

### API tilgjengelighet

ASF, bortsett fra hva du har tilgang til i grensesnittet, selv eksponerer deg for mange av sine interne API-er som du kan bruke av, for å utvide funksjonaliteten. Hvis du for eksempel vil sende en slags ny forespørsel til Steam på nettet, trenger du ikke å implementere alt fra bunnen av, Å håndtere alle problemene vi har måttet gjøre før deg. Bare bruk vår `boks. rchiWebHandler` som allerede utsetter mange metoder som `UrlWithSession()` som du skal bruke håndtere alle ting med lavt nivå, for eksempel autentisering, øktoppdatering eller begrensning for deg. På samme måte kan du sende nettforespørsler utenfor Steam-plattformen, som du kan bruke standard .NET `HttpClient`-klassen, men det er mye bedre idé å bruke `Bot. rchiWebHandler.WebBrowser` som er tilgjengelig for deg, som igjen tilbyr deg en nyttig hånd, for eksempel med tanke på å prøve mislykkede forespørsler.

Vi har en svært åpen policy når det gjelder API-tilgjengelighet, så hvis du vil gjøre bruk av noe som ASF-koden allerede omfatter, **[Åpne et problem](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** og forklare i det planlagte brukstilfellet av vår ASFs interne API. Vi vil sannsynligvis ikke ha noe igjen,så lenge brukssaken er fornuftig. Dette inkluderer også alle forslag i det nye `IPlugin`-grensesnittene som kan gi mening å legges til for å utvide eksisterende funksjonalitet.

Uavhengig av ASF API-tilgjengelighet stopper imidlertid ingenting deg fra f.eks `Discord. et`-biblioteket i programmet ditt og lage en bro mellom Discord bot og ASF-kommandoer, siden utvidelsen din også kan ha avhengigheter på seg selv. Mulighetene er uendelig, og vi gjør vårt beste for å gi deg så mye frihet og fleksibilitet som mulig i din innplugg, så det er ingen kunstige grenser på alt - din plugin er lastet inn i hovedprosessen ASF og kan gjøre alt som er realistisk mulig å gjøre det innenfor C# kode.

---

### API compatibility

Det er viktig å understreke at ASF er en forbrukerapplikasjon og ikke et typisk bibliotek med fast API-overflate som du kan være avhengig av uten unntak. Det betyr at du ikke kan anta at din plugin når du er kompilert, vil fortsette å arbeide med alle fremtidige ASF-utgivelser uansett, det er ganske enkelt umulig hvis vi ønsker å fortsette å utvikle programmet ytterligere. Manglende evne til å tilpasse seg stadig pågående Steam-endringer for kompatibilitet med bakover er bare ikke egnet for vår sak. Dette bør være logisk for deg, men det er viktig å fremheve den fakta.

Vi skal gjøre vårt beste for å holde offentlige deler av ASF-arbeid og stabilitet, men vi vil ikke være redde for å bryte kompatibiliteten hvis gode nok grunner oppstår, Etter vår \*\*[deprecation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation) \*\* policy i prosessen. Dette er spesielt viktig for deg interne ASF-strukturer som er eksponert for deg som en del av ASF-infrastrukturen (f.eks. `ArchiWebHandler`) som kan forbedres (og dermed omskrives) som en del av ASF-forsterkninger i en av fremtidige versjoner. Vi vil gjøre vårt beste for å informere deg på passende måte i endringsloggene og inneholde passende advarsler under kjøring om foreldet funksjoner. Vi har ikke tenkt å skrive om alt for denne skrivingen, så du kan være ganske sikker på at den neste mindre ASF-versjonen ikke bare ødelegger plugin helt og holdent fordi den har et høyere versjonsnummer men å ha øye med endringslogger, og verifikasjon av og til hvis alt fungerer fint er en svært god idé.

---

### Plugin avhengigheter

Programtillegget ditt vil inneholde minst to avhengigheter som standard, referanse `ArchiSteamFarm` for intern API (`IPlugin` som minimum), og `PackageReference` i `System. omposition.AttributedModel` som kreves for å bli gjenkjent som ASF plugin til å begynne med (`[Export]` klausul). I tillegg kan det inkludere flere avhengigheter i forhold til hva du har bestemt deg for i programtillegget (e. . `Discord.Net` bibliotek hvis du har bestemt deg for å integrere med Discord).

Resultatet av byggverket ditt inkluderer din kjerne `YourPluginName.dll` biblioteket, samt alle avhengighetene som du har referert. Siden du utvikler en plugin til et allerede arbeidsprogram, trenger du ikke, og til og med **shouldn't** inkluderer avhengigheter som ASF allerede inkluderer, for eksempel `ArchiSteamFarm`, `SteamKit2` eller `AngleSharp`. Striper ned din avslående avhengigheter som deles med ASF er ikke det absolutte kravet om at din plugin skal fungere, men gjør det på en dramatisk måte vil kutte minnebruken og størrelsen på utvidelsen din, sammen med å øke prestasjonen, på grunn av at ASF vil dele sine egne avhengigheter med deg, og skal kun laste de bibliotekene som de ikke vet om seg selv.

Generelt er det en anbefalt praksis å inkludere bare disse bibliotekene som ASF enten ikke innbefatter eller inkluderer i den feil/inkompatible versjonen. Eksempler på dette er åpenbart `YourPluginName.dll`, men for eksempel også `Discord.Net.dll` hvis du bestemte deg for å avhenge av det, da ASF ikke inkluderer det selv. Bundling av biblioteker som deles med ASF kan fortsatt gi mening hvis du vil sørge for API-kompatibilitet (f.eks. å være sikker på at `AngleSharp` som du er avhengig av i utvidelsen din alltid vil være i versjon `X` og ikke den som ASF leveres med), men gjør åpenbart som kommer med en pris av økt hukommelse/størrelse og dårligere ytelse, og bør derfor vurderes nøye.

Hvis du vet at den avhengigheten du trenger er inkludert i ASF, du kan merke den med `IncludeAssets="compile"` slik vi viste deg i eksempelet `csproj` over. Dette vil gi beskjed om at kompilatoren skal unngå å publisere selve referert biblioteket, da ASF allerede inkluderer det der. Likeledes, merk at vi refererer ASF-prosjektet med `ExcludeAssets="all" Private="false"` som fungerer på en svært lignende måte – og ber komprimereren om å ikke produsere ASF-filer (som brukeren allerede har dem). Dette gjelder bare når du refererer til ASF-prosjekt, siden dersom du refererer til et `dlll`-bibliotek så produserer du ikke ASF-filer som en del av pluginen.

Hvis du er forvirret av ovennevnte utsagn, og du ikke vet bedre, sjekk hvilke `dlll`-biblioteker som er inkludert i `ASF-generiske. ip`-pakken og sørg for at utvidelsen din kun inneholder de som ikke er en del av den ennå. Dette blir bare `YourPluginName.dll` for de mest enkle plugins. Dersom du får problemer under kjøring når det gjelder noen biblioteker, inkluderer du også de berørte bibliotekene. Hvis alt annet mislykkes kan du alltid bestemme deg for å samle alt.

---

### Native avhengigheter

Native avhengigheter genereres som en del av OS-spesifikke bygninger, ettersom det ikke er noen . ET kjøretid tilgjengelig på verten og ASF kjører gjennom sin egen .NET runtime som er samlet som en del av OS-spesifikk bygning. For å minimalisere byggestørrelsen, gjør ASF-trimmene at de innebygde avhengighetene kun kan inneholde koden som muligens kan nås i programmet, som effektivt kutter de ubrukte delene i løpetiden. Dette kan skape et potensielt problem for deg med hensyn til din utvidelse, Hvis du plutselig finner ut selv i en situasjon hvor utvidelsen din er avhengig av noe. ET-funksjon som ikke blir brukt i ASF, og derfor kan ikke OS-spesifikke versjoner kjøre den ordentlig, som vanligvis kaster `System.MissingMethodException` eller `System.Reflection.Reflection.ReflectionTypeLoadException` i prosessen. Etter hvert som utvidelsen vokser i størrelse og blir mer og mer kompleks, før eller senere vil du treffe overflaten som ikke er dekket av vår OS-spesifikke bygning.

Dette er aldri et problem med generiske bygg, fordi de aldri håndterer innebygde avhengigheter på det første stedet (som de har full arbeidstid på verten, utføre ASF). Dette er grunnen til at det er en anbefalt praksis å \*\*bruke utvidelsen din i generiske versjoner eksklusiv men selvsagt har den egen nedsiden av å kutte utvidelsen fra brukere som kjører OS-spesifikke versjoner av ASF. Hvis du lurer på om problemet er relatert til vanlige avhengigheter, du kan også bruke denne metoden for verifisering, last inn utvidelsen i ASF-generiske versjoner og se om den fungerer. Hvis det gjør det, har du plugin avhengigheter som er dekket, og det er de innebygde avhengighetene som forårsaker problemer.

Som en del av våre OS-spesifikke bygg måtte vi dessverre velge hardt mellom publisering av hele rulletiden. og bestemte seg for å klippe den ut av ubrukte funksjoner, slik at den kan bygges over 80 MB mindre enn i den hele. Vi har plukket det andre alternativet, og det er dessverre umulig for deg å inkludere de manglende rundetidsfunksjonene sammen med pluginen. Hvis prosjektet ditt krever tilgang for å kjøre tidsfunksjoner som kan tømmes, må du inkludere fullt . ET kjøretid som du er avhengig av, og som betyr å kjøre din plugin i `generisk` ASF-smak. Du kan ikke kjøre utvidelsen i OS-spesifikke bygg, da disse versjonene mangler bare en runtidsfunksjon som du trenger, og . ET kjøretid da av nå ikke er i stand til å "merge" innebygd avhengighet du kunne ha levert med vår egen. Kanskje forbedres en dag i fremtiden, men vil det pr. nå ikke være mulig.

ASFs OS-spesifikke versjoner inkluderer minimum "Admin" for tilleggsfunksjonalitet som er nødvendig for å kjøre våre offisielle utvidelser. Bortsett fra dette som mulig utvider dette også overflaten til ekstra avhengigheter som kreves for de mest grunnleggende utvidelsene. Ikke alle plugins må derfor bekymre seg for at innebygde avhengigheter skal begynne med - kun de som går utover det ASF og våre offisielle plugins trenger direkte. Dette gjøres som ekstra, siden vi må regne med flere native avhengigheter selv for vår egen brukssak, uansett Vi kan i tillegg sende dem direkte til ASF, slik at de blir tilgjengelige, og dermed lettere å dekke, også for deg. Dessverre er dette ikke alltid nok, og da utvidelsen blir større og mer kompleks, øker sannsynligheten for å komme til trimmet funksjonalitet. Derfor anbefaler vi vanligvis at du kjører dine egendefinerte plugins på `generic` ASF-smak ekskludert. Du kan fremdeles verifisere at OS-spesifikk versjon av ASF har alt som din plugin trenger for dens funksjonalitet – men siden det endres i dine oppdateringer, i tillegg til vår, den kan være vanskelig å holde fast.

Noen ganger er det mulig å «slappe av» funksjoner ved enten å bruke alternative alternativer eller å implementere dem i utvidelsen. Dette er imidlertid ikke alltid mulig eller levedyktig, spesielt hvis den manglende funksjonen kommer fra tredjepartsavhengigheter som du inkluderer som en del av utvidelsen din. Du kan alltid prøve å kjøre din plugin i OS-spesifikk versjon og forsøke å gjøre det til, men det kan bli for mye på lang sikt, spesielt hvis du vil fra koden din til bare å arbeide, i stedet for å kjempe med ASF-overflate.

---

## Automatiske oppdateringer

ASF tilbyr deg to grensesnitt for å implementere automatiske oppdateringer i ditt programtillegg:

- `IGitHubPluginUpdates` gjør det enkelt å implementere GitHub-baserte oppdateringer på lignende generelle ASF-oppdateringsmekanisme
- `IPluginUpdater` som gir deg funksjonalitet på lavere nivå som tillater egendefinerte oppdateringsmekanismer, hvis du trenger noe mer kompleks

---

### **[`IGithubPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs)**

Minste sjekkliste for ting som kreves for at oppdateringer skal virke:

- Du må erklære `RepositoryName`, som definerer hvor oppdateringene trekkes fra.
- Du må bruke tagger og utgivelser levert av GitHub. Tag må være i format som lesbar til en plugin-versjon, f.eks `1.0.0.0`.
- `Versjon`-egenskapen til utvidelsen må matche taggen som den kommer fra. Dette betyr at binær tilgjengelig under taggen `1.2.3.4` må presentere seg som `1.2.3.4`.
- Hver tag skal ha passende utgivelse tilgjengelig på GitHub med zip filrelease ressursen som inkluderer dine binære tilleggsfiler. De binære filene som inkluderer dine `IPlugin`-klasser skal være tilgjengelige i rotmappen i zip-filen.

Det vil tillate ordningen i ASF å

- Løs gjeldende `versjon` av din plugin, for eksempel `1.0.1`.
- Bruk GitHub API for å hente nyeste `tag` som er tilgjengelig i `RepositoryName` repo, f.eks. `1.0.2`.
- Avgjør at `1.0.2` > `1.0.1`, sjekk av `1.0.2` taggen for å finne `.zip` filen med utvidelsen oppdatering.
- Last ned filen `.zip` og legg den ut i mappen som medfølgende `YourPlugin.dl` før.
- Start ASF på nytt for å laste pluginen din i `1.0.2` versjonen.

Flere notater:

- Oppdatering av plugin kan kreve passende ASF konfigurasjonsverdier, nemlig **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)** og/eller **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)**.
- Vår plugin-mal inkluderer alt du trenger, bare **[rename](https://github.com/JustArchiNET/ASF-PluginTemplate?tab=readme-ov-file#renaming-myawesomeplugin)** utvidelsen til riktige verdier, og det vil fungere ut av boksen.
- Du kan bruke en kombinasjon av siste utgivelse samt forhåndslanser, de vil bli brukt som per `UpdateChannel` som brukeren har definert.
- Det finnes `CanUpdate` boolsk egenskap du kan overstyre for deaktivering/aktivering av plugins oppdateringsfunksjoner på siden din. hvis du for eksempel vil hoppe over oppdateringer midlertidig, eller gjennom en annen grunn.
- Det er mulig å ha flere zip-filer i utgivelsen hvis du ønsker å målrette forskjellige ASF-versjoner. Se `GetTargetReleaseAsset()` **[remarks](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs#L79-L106)**. For eksempel kan du ha `MyPlugin-V6-0.zip` i tillegg til `MyPlugin.zip`, som vil forårsake ASF i versjon `V6. .x` for å velge den første, mens alle andre ASF-versjoner vil bruke den andre.
- Hvis ovennevnte er ikke tilstrekkelig for deg og du krever egendefinert logikk for å velge riktig `. ip`-filen, du kan overstyre `GetTargetReleaseAsset()`-funksjonen og gi artifaktet til ASF som skal brukes.
- Hvis utvidelsen din trenger å gjøre litt ekstra arbeid før/etter oppdatering, kan du overstyre `OnPluginUpdateProceeding()` og/eller `OnPluginUpdateFinished()`-metodene.

---

### **[`IPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IPluginUpdates.cs)**

Dette grensesnittet lar deg implementere egendefinert logikk for oppdateringer hvis en hvilken som helst grunn `IGithubPluginUpdates` er ikke nok for deg, for eksempel fordi du har tagger som ikke analyserer til versjoner, eller fordi du ikke bruker GitHub plattform i det hele tatt.

Det er en enkelt `GetTargetReleaseURL()`-funksjonen du kan overstyre, noe som forventer at du `Uri?` vil oppdatere din plugin plassering. ASF gir dere noen kjernevariabler som relaterer seg til konteksten funksjonen ble kalt med, men annet enn det, du er ansvarlig for å implementere alt du trenger i den funksjonen og oppgi ASF nettadressen som skal brukes. eller "null" hvis oppdateringen ikke er tilgjengelig.

Annet enn at det er lik GitHub oppdateringer, hvor URL-adressen skal peke til en `. ip`-filen med de binære filene som finnes i rotmappen. Du har også metodene `OnPluginUpdateProceeding()` og `OnPluginUpdateFinished()`.