# Vývoj pluginů

ASF obsahuje podporu pro vlastní pluginy, které mohou být načteny během běhu. Pluginy vám umožňují přizpůsobit chování ASF, například přidáním vlastních příkazů, vlastní obchodní logiky nebo celou integraci se službami třetích stran a API.

Tato stránka popisuje ASF pluginy z pohledu vývojářů - vytváření, udržování, publikování a podobně. Pokud chcete zobrazit uživatelskou perspektivu, přesuňte **[here](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

---

## Hlavní nastavení

Pluginy jsou standardní knihovny .NET, které definují třídu dědickou od běžného rozhraní `IPlugin` uvedeného v ASF. Můžete vyvinout pluginy zcela nezávisle na hlavní aplikaci ASF a znovu je použít v současných a budoucích verzích aplikace ASF. dokud interní ASF API zůstane kompatibilní. Systém pluginů používaný v ASF je založen na `System. omposition`, dříve známý jako **[Managed Extensibility Framework](https://docs.microsoft.com/dotnet/framework/mef)**, který umožňuje ASF objevovat a nahrávat vaše knihovny během běhu systému.

---

### Úvod

Připravili jsme **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate)** pro vás, které můžete (a měli) použít jako základ pro váš projekt pluginu. Použití šablony **není požadavek** (protože můžete dělat vše od začátku), ale velmi doporučujeme ji zvednout, protože to může drasticky nastartovat vývoj a zkrátit čas potřebný k tomu, aby vše bylo správné. Stačí se podívat na **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** šablony a to vás provede dále. Bez ohledu na to, zda chcete začít od začátku, zakrníme níže uvedené základy. nebo lépe pochopit koncepty používané v šabloně pluginu - obvykle nemusíte dělat nic, pokud jste se rozhodli použít naši šablonu pluginu.

Váš projekt by měl být standardní . ET knihovna zaměřující se na vhodný rámec vaší cílové verze ASF, jak je uvedeno v sekci **[compilation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation)**.

Projekt musí odkazovat na hlavní soubor `ArchiSteamFarm`, a to buď na jeho předpostavený `ArchiSteamFarm. ll` knihovna, kterou jste si stáhli jako součást vydání nebo zdrojového projektu (např. pokud jste se rozhodli přidat ASF strom jako podmodul). To vám umožní získat přístup k strukturám, metodám a vlastnostem ASF, zejména jádro rozhraní `IPlugin`, které budete muset zdědit v dalším kroku. Projekt musí také minimálně odkazovat na `System.Composition.AttributedModel` , což vám umožní `[Export]` váš `IPlugin` pro použití ASF. Kromě toho možná budete chtít / potřebujete odkazovat na jiné společné knihovny, abyste mohli interpretovat datové struktury, které jsou vám poskytnuty v některých rozhraních, ale pokud je výslovně nepotřebujete, bude to stačit nyní.

Pokud jste udělali vše správně, vaše `csproj` bude podobná jako níže:

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <! - Protože načítáte plugin do procesu ASF, který již obsahuje tyto závislosti, IncludeAssets="compile" umožňuje vynechat je z konečného výstupu -->
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" IncludeAssets="compile" Version="10.0.0" />
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="10.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="C:\\Path\To\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" />

    <! - Pokud budujete stažený DLL binární soubor, použijte místo <ProjectReference> výše -->
    <! - <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" /> -->
  </ItemGroup>
</Project>
```

Z hlediska kódu musí vaše třída pluginu dědit z rozhraní `IPlugin` (explicitně nebo implicitně dědit od specializovanějšího rozhraní, např. `IASF`) a `[Export(typeof(IPlugin)]` aby byl ASF rozpoznán během běhu. Nejvíce holý příklad, který by dosahoval následujícího:

```csharp
pomocí System;
using System.Composition;
using System.Threading.Tasks;
using ArchiSteamFarm;
using ArchiSteamFarm.Plugins;

namespace YourNamespace. ourPluginName;

[Export(typeof(IPlugin))]
veřejná zaplombovaná třída YourPluginName : IPlugin {
	veřejný řetězec Jméno => nameof(YourPluginName);
	veřejná verze => typeof(YourPluginName). ssembly.GetName().Verzee;

	veřejný úkol OnLoaded() {
		ASF.ArchiLogger.LogGenericInfo("Hello World!");

		vrátí Task.CompletedTask;
	}
}
```

Abyste mohli využít svůj plugin, musíte jej nejprve zkompilovat. Můžete to udělat buď z ID, nebo z kořenového adresáře vašeho projektu příkazem:

```shell
# Pokud je váš projekt samostatný (není třeba definovat jeho jméno, protože je to jediné)
dotnet publikovat -c "Release" -o "out"

# Pokud je váš projekt součástí ASF zdrojového stromu (aby se zabránilo kompilaci zbytečných částí)
dotnet publikuje YourPluginName -c "Release" -o "out"
```

Poté je váš plugin připraven k nasazení. Je na vás, jak přesně chcete distribuovat a publikovat váš zásuvný modul, ale doporučujeme vytvořit zip archiv, kde vložíte svůj kompilovaný plugin spolu s **[dependencies](#plugin-dependencies)**. Tímto způsobem bude muset uživatel jednoduše rozbalit váš zip archiv do samostatného podadresáře ve svém adresáři "pluginy" a nedělat nic jiného.

Toto je pouze ten nejzákladnější scénář, který vám umožní začít. Máme **[`Příklad Plugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** projekt, který vám ukáže příklady rozhraní a akcí, které můžete provést ve svém vlastním pluginu, včetně užitečných komentářů. Neváhejte se podívat, jestli se chcete učit z pracovního kódu, nebo objevit `ArchiSteamFarm. zavazadla` jmenný prostor sám sebe a viz přiloženou dokumentaci pro všechny dostupné možnosti. Také dále rozpracujeme některé základní koncepty níže, abychom je lépe vysvětlili.

Pokud namísto příkladu pluginu se chcete naučit ze skutečných projektů, existuje několik oficiálních pluginů vyvinutých námi, např. **[`ItemsMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.ItemsMatcher)**, **[`MobileAuthenticator`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.MobileAuthenticator)** nebo **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)**. Kromě toho existují pluginy vyvinuté jinými vývojáři v sekci **[third-party](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)**.

---

### Dostupnost API

ASF, kromě toho, k čemu máte přístup samotná rozhraní, vystavuje vám spoustu svých interních API, které můžete použít, abyste rozšířili funkčnost. Například, pokud chcete poslat nějaký nový požadavek na Steam, pak nemusíte implementovat vše od nuly, zejména se zabývají všemi problémy, se kterými jsme se museli vypořádat před vámi. Jednoduše použijte náš `Bot. rchiWebHandler`, který již odhaluje mnoho metod `UrlWithSession()` k použití, vyřizování všech věcí na nižší úrovni, jako je autentizace, obnovení relace nebo web, které jsou pro vás omezené. Stejně tak pro odesílání webových požadavků mimo platformu Steam můžete použít standardní .NET třídu HttpClient`, ale je mnohem lepší použít `Bot. rchiWebHandler.WebBrowser\` který je vám k dispozici, který vám opět nabízí užitečnou ruku, například pokud jde o opětovné vyzkoušení neúspěšných požadavků.

Máme velmi otevřenou politiku, pokud jde o dostupnost API, takže pokud chcete použít něco, co ASF kód již obsahuje, jednoduše **[otevřete problém](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** a vysvětlete v něm plánovaný případ použití našeho interního rozhraní API. S největší pravděpodobností nebudeme mít nic proti, pokud vaše použití bude mít smysl. To také zahrnuje všechny návrhy týkající se nových rozhraní `IPlugin`, které by mohly být přidány s cílem rozšířit stávající funkčnost.

Bez ohledu na ASF API však vás nic nezastaví např. před `Discord. et` knihovna ve tvé aplikaci a vytváření mostu mezi tvým Discord botem a příkazy ASF, protože váš zásuvný modul může mít také vlastní závislosti. Možnosti jsou nekonečné a my jsme se snažili poskytnout vám ve vašem pluginu co nejvíce svobody a flexibility, takže neexistují žádné umělé limity na cokoliv - váš plugin je načten do hlavního procesu ASF a může udělat cokoliv, co je realisticky možné udělat z kódu C#

---

### API kompatibilita

Je důležité zdůraznit, že ASF je spotřebitelská aplikace, a nikoli typická knihovna s pevným rozhraním API, na které můžete bezpodmínečně záviset. To znamená, že nemůžete předpokládat, že váš zásuvný modul bude po kompilaci pracovat se všemi budoucími verzemi aplikace ASF, je jednoduše nemožné, pokud chceme pokračovat v dalším vývoji programu, a neschopnost přizpůsobit se neustálým změnám ve Steamu kvůli zpětné kompatibilitě prostě není vhodná pro náš případ. To by pro vás mělo být logické, ale je důležité tuto skutečnost zdůraznit.

Uděláme vše pro to, abychom veřejné části ASF fungovaly a stabilní, ale nebudeme se bát porušit kompatibilitu, pokud vzniknou dostatečné důvody, sledujeme naše zásady **[deprecation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation)** v procesu. To je obzvláště důležité, pokud jde o vnitřní struktury ASF, které jsou vystaveny vám jako součást infrastruktury ASF (např. `ArchiWebHandler`), který by mohl být vylepšen (a proto přepsán) jako součást ASF vylepšení v jedné z budoucích verzí. Uděláme vše, co je v našich silách, abychom vás informovali v seznamech změn a v průběhu běhu přidali vhodná upozornění o zastaralých funkcích. Nechceme všechno přepsat kvůli jeho přepsání, takže si můžete být docela jisti, že další menší verze ASF nebude jen jednoduše zničit váš plugin pouze proto, že má vyšší číslo verze, ale sledovat seznamy změn a příležitostné ověřování, pokud vše funguje dobře, je velmi dobrý nápad.

---

### Závislosti pluginu

Váš zásuvný modul bude obsahovat alespoň dvě závislosti, `ArchiSteamFarm` reference pro interní API (minimálně `IPlugin`), a `PackageReference` pro `System. omposition.AttributedModel` který je vyžadován k tomu, aby byl rozpoznán jako ASF plugin začínající s (`[Export]` klauzulem). Kromě toho může obsahovat více závislostí, pokud jde o to, co jste se rozhodli udělat ve vašem pluginu (e. . knihovna `Discord.Net` pokud jste se rozhodli integrovat s Discordem).

Výstup tvého sestavení bude obsahovat jádro knihovny `YourPluginName.dl` a také všechny závislosti, na které jsi odkazoval. Vzhledem k tomu, že vytváříte plugin pro již fungující program, nemusíte: a dokonce i **by měl** obsahují závislosti, které ASF již obsahuje, například `ArchiSteamFarm`, `SteamKit2` nebo `AngleSharp`. Odříznutí závislostí na stavbě sdílených s ASF není absolutním požadavkem, aby váš plugin fungoval, ale to bude dramaticky snížit paměťovou stopu a velikost vašeho pluginu, společně se zvyšováním výkonnosti, vzhledem ke skutečnosti, že ASF s vámi bude sdílet své vlastní závislosti, a načítá pouze ty knihovny, o kterých sama neví.

Obecně je doporučeno zahrnout pouze ty knihovny, které ASF buď neobsahuje nebo obsahuje v nesprávné/nekompatibilní verzi. Příklady by samozřejmě byly `YourPluginName.dll`, ale například `Discord.Net.dl` pokud jste se rozhodli na něm záviset, protože ASF ho sama neobsahuje. Bundling knihovny, které jsou sdíleny s ASF, mohou mít stále smysl, pokud chcete zajistit kompatibilitu API (např. se ujistěte, že `AngleSharp` na kterém jste závislí ve vašem pluginu, bude vždy ve verzi `X` a ne ve verzi, se kterou ASF lodě plujete), ale samozřejmě se jedná o cenu zvýšené paměti/velikosti a horšího výkonu, a proto by měly být pečlivě vyhodnoceny.

Pokud víte, že závislost, kterou potřebujete, je zahrnuta do ASF, můžete ho označit pomocí `IncludeAssets="compile"` tak, jak jsme Vám ukázali v příkladu `csproj` výše. Toto řekne kompilátorovi, aby se vyhnul publikování odkazované knihovny, protože ASF již tuto knihovnu obsahuje. Obdobně Všimněte si, že odkazujeme na ASF projekt s `ExcludeAssets="all" Private="false", který funguje velmi podobným způsobem - řekneme kompilátorovi, aby nevytvářel žádné ASF soubory (jak je již uživatel má). To platí pouze pro odkazování na ASF projekt, protože pokud odkazujete na knihovnu `dl\`, nevyrábíte soubory ASF jako součást vašeho pluginu.

Pokud jste zmateni s výše uvedeným příkazem a nevíte lépe, zkontrolujte, které knihovny `dl` jsou součástí `ASF-generic. ip` balíček a ujistěte se, že váš plugin obsahuje pouze ty, které ještě nejsou jeho součástí. Toto bude pouze `YourPluginName.dll` pro nejjednodušší pluginy. Pokud během běhu dostanete nějaké problémy s některými knihovnami, přidejte i tyto dotčené knihovny. Pokud všechny ostatní selžou, můžete se vždy rozhodnout vše spojit.

---

### Nativní závislosti

Nativní závislosti jsou generovány jako součást budov specifických pro OS, protože neexistuje . ET runtime k dispozici na hostiteli a ASF prochází vlastním runtimem .NET, který je propojen v rámci sestavení specifického pro OS. Aby se minimalizovala velikost sestavení, ASF ořízne své původní závislosti, aby zahrnula pouze kód, který může být v rámci programu dosažen, které se fakticky zbavují nevyužitých částí dráhy. To může pro vás vytvořit potenciální problém, pokud jde o váš zásuvný modul, pokud náhle zjistíte sami sebe v situaci, kdy váš plugin závisí na někomu . ET funkce, která není použita v ASF, a proto nemůže být specifické sestavení specifické pro OS, obvykle v procesu házet `System.MissingMethodException` nebo `System.Reflection.ReflectionTypeLoadException`. Jak váš plugin roste svou velikostí a stává se stále složitějším, Dříve nebo později narazíte na povrch, který není zakrytý naší stavbou specifické pro OS.

Nikdy to není problém s generickými budovami, protože tito lidé se nikdy v první řadě nezabývají rodilými závislostmi (protože mají úplnou dobu trvání pracovní doby na hostiteli a provádějí ASF). Proto je doporučeno **používat plugin v generických kompozitářích výhradně**, ale je jasné, že má svou vlastní nevýhodu, protože snižuje váš plugin od uživatelů, kteří používají verze ASF specifické pro operační systém. Pokud se zajímáte, zda váš problém souvisí s nativními závislostmi, můžete také použít tuto metodu pro ověření, načíst plugin v ASF generickém sestavení a zjistit, zda funguje. Pokud se tak stane, máte kryté závislosti pluginu a jsou to původní závislosti, které způsobují problémy.

Naneštěstí jsme museli učinit obtížnou volbu mezi vydáním celého běhu v rámci našich budov specifických pro OS, a rozhodnout se o vyříznutí z nevyužitých funkcí, takže stavba více než 80 MB bude v porovnání s celou verzí menší. Vybrali jsme druhou možnost a bohužel je nemožné zahrnout chybějící funkce běhu spolu s pluginem. Pokud váš projekt vyžaduje přístup k běžným funkcím, které jsou ponechány, musíte zahrnout celý . ET runtime na které jste závislí, a to znamená spuštění pluginu v `generické` ASF chuti. Zásuvný modul nelze spustit v sestaveních specifických pro operační systém, protože těmto stavbám chybí pouze funkce běhu, kterou potřebujete a . ET runtime od nynějška není schopen "sloučit" původní závislosti, kterou jste mohli poskytnout s naší vlastní. Možná se jednou v budoucnu zlepší, ale od nynějška to prostě není možné.

Konstrukce specifické pro ASF obsahují holé minimum dalších funkcí, které jsou potřebné pro spuštění našich oficiálních pluginů. Kromě toho, že je to možné, to také mírně rozšiřuje povrch na další závislosti potřebné pro nejzákladnější zásuvky. Proto ne všechny pluginy se budou muset obávat o původní závislosti začít - pouze ty, které jdou nad to, co ASF a naše oficiální pluginy přímo potřebují. To se děje jako doplněk, protože pokud potřebujeme zahrnout i další vlastní závislosti pro naše vlastní použití, můžeme je dopravit přímo s ASF a zpřístupnit je, a tedy i pro vás. Bohužel to není vždy dost a protože váš plugin je větší a složitější, pravděpodobnost běhu do upravené funkčnosti roste. Proto obvykle doporučujeme spustit vlastní pluginy v `generické` ASF chuti exkluzivně. Stále můžete ručně ověřit, že verze ASF specifická pro operační systém obsahuje vše, co váš plugin vyžaduje pro jeho funkčnost - ale od té doby, co se mění ve vašich aktualizacích i naších, může být ošemetné.

Někdy může být možné "zpracovat" chybějící funkce buď použitím alternativních možností nebo jejich opětovným implementací ve vašem pluginu. To však není vždy možné nebo životaschopné, zejména pokud chybějící funkce pochází ze závislostí třetích stran, které vkládáte jako součást vašeho pluginu. Vždy se můžete pokusit spustit zásuvný modul ve specifické verzi pro operační systém a pokusit se o jeho fungování. ale v dlouhodobém horizontu se může stát příliš těžkostí, zejména pokud chcete od svého kódu jen pracovat, spíše než bojovat s povrchem ASF.

---

## Automatické aktualizace

ASF nabízí dvě rozhraní pro automatickou aktualizaci ve vašem pluginu:

- `IGitHubPluginUpdates` poskytuje snadný způsob, jak implementovat aktualizace založené na GitHubu podobné obecnému mechanismu ASF aktualizace
- `IPluginUpdates` poskytuje nižší funkci, která umožňuje vlastní aktualizaci mechanismu, pokud potřebujete něco složitějšího

---

### **[`IGithubPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs)**

Minimální kontrolní seznam věcí, které jsou potřebné pro fungování aktualizací:

- Musíte zadat `RepositoryName`, který určuje, odkud jsou aktualizace staženy.
- Musíte použít tagy a vydání, které poskytuje GitHub. Tag musí být ve formátu parsovatelný s verzí pluginu, např. `1.0.0.0`.
- Vlastnost `Version` pluginu musí odpovídat značce, ze které pochází. To znamená, že binární soubor dostupný pod značkou `1.2.3.4` se musí prezentovat jako `1.2.3.4`.
- Každá značka by měla mít k dispozici odpovídající verzi na GitHubu s aktivací zip souborů, která obsahuje binární soubory pluginu. Binární soubory, které obsahují třídy `IPlugin`, by měly být k dispozici v kořenovém adresáři v souboru zip.

Tento mechanismus v ASF tak umožní:

- Vyřešte aktuální `Verze` vašeho pluginu, např. `1.0.1`.
- Použijte GitHub API k načtení posledního `tag` dostupného v `RepositoryName` repo, např. `1.0.2`.
- Určete, že `1.0.2` > `1.0.1`, zkontrolujte vydání `1.0.2` tagu pro nalezení `.zip` souboru s aktualizací pluginu.
- Stáhněte si soubor `.zip`, extrahujte jej a vložte jej do adresáře, který obsahoval `YourPlugin.dl` předtím.
- Restartujte ASF pro načtení pluginu ve verzi `1.0.2`.

Doplňkové poznámky:

- Aktualizace pluginu mohou vyžadovat odpovídající ASF konfigurační hodnoty, konkrétně **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)** a/nebo **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)**.
- Naše šablona pluginu již obsahuje vše, co potřebujete, jednoduše **[rename](https://github.com/JustArchiNET/ASF-PluginTemplate?tab=readme-ov-file#renaming-myawesomeplugin)** zásuvný modul k správným hodnotám, a to bude fungovat mimo krabici.
- Můžete použít kombinaci nejnovější verze i předverzí, budou použity podle `UpdateChannel` definovaného uživatelem.
- Je zde `CanUpdate` boolean vlastnost, kterou můžete přepsat pro zakázání/povolení aktualizace pluginů na vaší straně, například pokud chcete přeskočit aktualizace dočasně nebo z jiného důvodu.
- Pokud chcete použít různé verze ASF, můžete mít v této verzi více zip souborů. Viz `GetTargetReleaseAsset()` **[remarks](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs#L79-L106)**. Například můžete mít `MyPlugin-V6-0.zip` i `MyPlugin.zip`, což způsobí ASF ve verzi `V6. .x.x` vybrat první verzi, zatímco všechny ostatní verze ASF budou používat druhou verzi.
- Pokud pro vás výše uvedené není dostačující a pro výběr správného `, je zapotřebí vlastní logiky. ip` soubor, můžete přepsat funkci `GetTargetReleaseAsset()` a poskytnout artefakt pro použití ASF.
- Pokud váš zásuvný modul potřebuje vykonat ještě nějakou práci před/po aktualizaci, můžete přepsat metody `OnPluginUpdateProceeding()` a/nebo `OnPluginUpdateFinished()`.

---

### **[`IPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IPluginUpdates.cs)**

Toto rozhraní umožňuje implementovat vlastní logiku pro aktualizace, pokud z nějakého důvodu není `IGithubPluginUpdates` dostačující pro vás, například proto, že máte značky, které neodpovídají verzím, nebo že vůbec nepoužíváte platformu GitHub.

Existuje jediná funkce `GetTargetReleaseURL()` pro přepsání, která od vás očekává `Uri?` umístění aktualizace cílového pluginu. ASF vám poskytuje některé základní proměnné, které se týkají kontextu, se kterým byla funkce volána, ale s výjimkou toho, jste zodpovědní za implementaci všeho, co v této funkci potřebujete, a za poskytnutí ASF URL, která by měla být použita, nebo `null` pokud není aktualizace dostupná.

Jinak je to podobné jako GitHub aktualizace, kde by URL měla odkazovat na `. ip` soubor s binárními soubory dostupnými v kořenovém adresáři. Máte také dostupné metody `OnPluginUpdateProceeding()` a `OnPluginUpdateFinished()`.