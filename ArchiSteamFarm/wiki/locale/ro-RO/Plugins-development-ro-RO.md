# Dezvoltarea de plugin-uri

ASF include suport pentru plugin-uri personalizate care pot fi încărcate în timpul rulării. Plugin-urile vă permit să personalizați comportamentul ASF, de exemplu prin adăugarea de comenzi personalizate, logică de tranzacționare personalizată sau integrare completă cu servicii terțe și API-uri.

Această pagină descrie plugin-urile ASF din perspectiva dezvoltatorilor - crearea, întreținerea, publicarea și la fel. Dacă doriţi să vizualizaţi perspectiva utilizatorului, mutaţi **[here](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** în schimb.

---

## Setări de bază

Plugin-urile sunt biblioteci standard. NET care definesc o clasă moştenind de la interfaţa comună `IPlugin` declarată în ASF. Poți dezvolta plugin-uri complet independent de ASF principal și să le reutilizezi în versiunile actuale și viitoare ale ASF, atât timp cât API-ul intern ASF rămâne compatibil. Sistemul de plugin folosit în ASF este bazat pe `Sistem. omposition`, cunoscut anterior ca **[Managed Extensibility Framework](https://docs.microsoft.com/dotnet/framework/mef)** care permite ASF să descopere și să încarce bibliotecile tale în timpul runtime.

---

### Noțiuni de bază

Am pregătit **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate)** pentru tine, pe care o poți folosi (și trebuie) ca bază pentru proiectul tău de plugin-uri. Folosirea șablonului nu este **o cerință** (puteți face totul de la zero), dar vă recomandăm să îl ridicați deoarece vă poate da un impuls drastic dezvoltării și să întrerupeți timpul necesar pentru a corecta toate lucrurile. Pur şi simplu verificaţi **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** al şablonului şi vă va ghida mai departe. Indiferent de situaţie, vom prezenta elementele de bază de mai jos în cazul în care doriţi să începeţi de la zero, sau obțineți pentru a înțelege mai bine conceptele utilizate în șablonul plugin-ului - de obicei nu trebuie să faceți niciuna dintre acestea dacă ați decis să utilizați șablonul plugin-ului nostru.

Proiectul tău ar trebui să fie un standard. Biblioteca ET targeting appropriate framework of your target ASF version, as specified in the **[compilation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation)** section.

Proiectul trebuie să facă referință la asamblarea principală `ArchiSteamFarm`, fie preconstruită `ArchiSteamFarm. biblioteca ll` pe care ai descărcat-o ca parte a versiunii sau proiectul sursă (de ex. dacă ai decis să adaugi un arbore ASF ca submodul). Acest lucru vă va permite să accesați și să descoperiți structuri, metode și proprietăți ASF, în special interfața de bază `IPlugin`, de care va trebui să moștenești de la pasul următor. Proiectul trebuie de asemenea să facă referire la `System.Composition.AttributedModel` cel puţin, care vă permite să ' '[Export]` `IPlugin\` pentru ca ASF să o folosească. În plus, ați putea vrea/trebuie să trimiteți la alte biblioteci comune pentru a interpreta structurile de date care vă sunt oferite în unele interfețe; dar dacă nu aveţi nevoie de ele în mod explicit, acest lucru va fi suficient deocamdată.

Dacă aţi făcut totul corect, `csproj` va fi similar cu mai jos:

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <!-- Since you're loading plugin into the ASF process, which already includes those dependencies, IncludeAssets="compile" allows you to omit them from the final output -->
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" IncludeAssets="compile" Version="10.0.0" />
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="10.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="C:\\Path\To\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" />

    <!-- If building with downloaded DLL binary, use this instead of <ProjectReference> above -->
    <!-- <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" /> -->
  </ItemGroup>
</Project>
```

Din partea de cod, clasa de plugin-uri trebuie să moștenească din interfața `IPlugin` (fie explicit, fie implicit prin moștenirea dintr-o interfață mai specializată, precum `IASF`) și `[Export(typeof(IPlugin)]` pentru a fi recunoscute de ASF în timpul runtimpului. Exemplul cel mai acut este următorul:

```csharp
utilizează sistem;
folosind System.Composition;
folosind System.Threading.Tasks;
folosind ArchiSteamFarm;
folosind ArchiSteamFarm.Plugins;

namespace YourNamespace. ourPluginName;

[Export(typeof(IPlugin))]
Public sealed class YourPluginName : IPlugin {
	<unk> public string Name => nameof(YourPluginName);
	ćpublic Version Version => typeof(YourPluginName). ssembly.GetName().versiune;

	<unk> public Task OnLoaded() {
		<unk> ASF.ArchiLogger.LogGenericInfo("Hello World!");

		<unk> return Task.CompletedTask;
	<unk> }
}
```

Pentru a utiliza pluginul, trebuie să îl compilați mai întâi. Poți face asta fie din ID-ul tău, fie din directorul rădăcină al proiectului tău prin comandă:

```shell
# Dacă proiectul tău este standalone (nu este nevoie să îi definești numele deoarece este singur)
dotnet publică -c "Release" -o "out"

# Dacă proiectul tău face parte din arborele sursă ASF (pentru a evita compilarea pieselor inutile)
dotnet publică YourPluginName -c "Release" -o "out"
```

Ulterior, plugin-ul dumneavoastră este pregătit pentru implementare. Depinde de tine cum exact vrei să distribui și să publici pluginul, dar recomandăm crearea unei arhive zip unde vei pune plugin-ul compilat împreună cu **[dependencies](#plugin-dependencies)**. În acest fel, utilizatorul va avea nevoie doar să dezpacheteze arhiva zip într-un subdirector de sine stătător în directorul lor `plugin-uri` şi să nu facă nimic altceva.

Acesta este doar cel mai de bază scenariu pentru a începe. Avem un proiect **[`ExamplePlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** care vă arată exemple de interfețe și acțiuni pe care le puteți face în cadrul plugin-ului dvs., inclusiv comentarii utile. Simte-te liber să arunci o privire dacă vrei să înveți dintr-un cod de lucru sau să descoperi \`ArchiSteamFarm. spațiu de nume pentru lugin-uri și se referă la documentația inclusă pentru toate opțiunile disponibile. Vom dezvolta în continuare câteva concepte de bază de mai jos pentru a le explica mai bine.

Dacă în loc de plugin-ul exemplu doriți să învățați din proiecte reale, există mai multe plugin-uri oficiale dezvoltate de noi, de ex. **[`ItemsMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.ItemsMatcher)**, **[`mobilileAuthenticator`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.MobileAuthenticator)** sau **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)**. În plus, există și plugin-uri dezvoltate de alți dezvoltatori, în secțiunea **[third-party](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)**.

---

### Disponibilitatea API

ASF, pe lângă ceea ce ai acces în interfețe însele, expune la tine o mulțime din API-urile sale interne pe care le poți folosi, pentru a extinde funcționalitatea. De exemplu, dacă dorești să trimiți un nou tip de cerere către Steam web, nu trebuie să implementezi totul de la zero, în special să ne ocupăm de toate problemele cu care a trebuit să ne confruntăm înaintea voastră. Folosiți doar `Bot-ul nostru. rchiWebHandler` care expune deja o mulţime de metode `UrlWithSession()` pentru a le folosi, manipulează toate lucrurile de nivel inferior, cum ar fi autentificarea, reîmprospătarea sesiunii sau limitarea web-ului pentru tine. De asemenea, pentru trimiterea de cereri web în afara platformei Steam, ai putea folosi clasa standard. NET `HttpClient`, dar este o idee mult mai bună să folosești `Bot. rchiWebHandler.WebBrowser` care vă este disponibil, care vă oferă încă o dată o mână utilă, de exemplu în ceea ce priveşte reîncercările de cereri eşuate.

Avem o politică foarte deschisă în ceea ce privește disponibilitatea API, așa că dacă doriți să folosiți ceva ce codul ASF include deja, pur și simplu **[deschide o problemă](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** și explicați în ea cazul utilizării planificate a API intern al ASF. Cel mai probabil nu vom avea nimic împotrivă, atâta timp cât cazul tău are sens. Aceasta include de asemenea toate sugestiile referitoare la noile interfeţe `IPlugin` care ar putea fi adăugate pentru a extinde funcţionalitatea existentă.

Indiferent de disponibilitatea ASF API oricum, nimic nu te oprește să incluzi `Discord. et` librărie în aplicația ta și creează o punte de legătură între comenzile robotului tău Discord și comenzile ASF, deoarece plugin-ul dumneavoastră poate avea și dependențe pe cont propriu. Posibilitățile sunt nesfârșite și am făcut tot posibilul să vă oferim cât mai multă libertate și flexibilitate posibil în cadrul plugin-ului dvs., astfel încât nu există limite artificiale pe nimic - plugin-ul dvs. este încărcat în procesul principal ASF și poate face orice este realist posibil din codul C#

---

### API compatibility

Este important de subliniat faptul că ASF este o aplicație de consum și nu o bibliotecă tipică cu o suprafață API fixă de care puteți depinde necondiționat. Acest lucru înseamnă că nu puteți presupune că plugin-ul dvs. odată compilat va continua să lucreze cu toate versiunile viitoare ale ASF, oricum, este pur şi simplu imposibil dacă vrem să continuăm să dezvoltăm programul în continuare, şi a nu putea să se adapteze la modificările constante ale Steam din motive de compatibilitate inversă este pur şi simplu neadecvată pentru cazul nostru. Acest lucru ar trebui să fie logic pentru voi, dar este important să subliniați acest lucru.

Vom face tot ce ne stă în putință pentru a menține părțile publice ale ASF active și stabile, dar nu ne vom teme să întrerupem compatibilitatea dacă apar suficiente motive; urmând politica noastră **[deprecation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation)** în acest proces. Acest lucru este deosebit de important în ceea ce privește structurile interne ASF care sunt expuse la dumneavoastră ca parte a infrastructurii ASF (de exemplu, `ArchiWebHandler`) care ar putea fi îmbunătățit (și, prin urmare, rescris) ca parte a îmbunătățirilor ASF în una dintre versiunile viitoare. Vom face tot posibilul să te informăm în mod corespunzător în schimbări, și vom include avertismente adecvate în timpul runtime despre funcțiile învechite. Nu intenţionăm să rescriem totul de dragul rescrierii sale, astfel încât să poți fi destul de sigur că următoarea versiune secundară ASF nu va distruge pur și simplu plugin-ul în întregime doar pentru că are o versiune mai mare, dar supravegherea schimbătorilor şi verificarea ocazională dacă totul funcţionează bine este o idee foarte bună.

---

### Dependențe plugin

Plugin-ul dumneavoastră va include cel puțin două dependențe în mod implicit, referința `ArchiSteamFarm` pentru API intern (minim `IPlugin`) și `PackageReference` din `System. omposition.AttributedModel` care este necesar pentru a fi recunoscut ca plugin ASF pentru a începe cu (clauza `[Export]). În plus, ar putea include mai multe dependențe în ceea ce ai decis să faci în plugin-ul tău (e. . Librărie `Discord.Net\` dacă ai decis să te integrezi cu Discord).

Ieșirea versiunii tale va include biblioteca de bază `YourPluginName.dll`, precum și toate dependențele pe care le-ai menționat. Din moment ce dezvolţi un plugin pentru programul de lucru deja, nu trebuie să; şi chiar **nu ar trebui** să includă dependenţe pe care ASF le include deja, de exemplu `ArchiSteamFarm`, `SteamKit2` sau \`AngleSharp". Eliminarea dependențelor partajate cu ASF nu este o cerință absolută pentru ca plugin-ul să funcționeze, dar făcând acest lucru va tăia dramatic memoria și dimensiunea plugin-ului tău, împreună cu creșterea performanței, datorită faptului că ASF vă va împărți propriile dependențe, şi va încărca doar acele biblioteci despre care nu ştie despre sine.

În general, este o practică recomandată să includem numai acele biblioteci pe care ASF fie nu le include, fie include în versiunea greșită incompatibilă. Exemple de astfel de exemple ar fi în mod evident `YourPluginName.dll`, dar de exemplu `Discord.Net.dll` dacă ai decis să depinzi de el, deoarece ASF nu îl include în sine. Bundling libraries care sunt partajate cu ASF pot avea sens dacă doriți să asigurați compatibilitatea API (de ex. fiind sigur că `AngleSharp` de care depindeți în plugin-ul dumneavoastră va fi întotdeauna în versiunea `X` și nu în versiunea cu care ASF este aprovizionată cu), dar, în mod evident, acest lucru presupune un preţ al memoriei/mărimii mărite şi al performanţelor mai slabe şi, prin urmare, trebuie evaluat cu atenţie.

Dacă ştiţi că dependenţa de care aveţi nevoie este inclusă în ASF, îl puteți marca cu `IncludeAssets="compile"` așa cum v-am arătat în exemplul `csproj` de mai sus. Acest lucru îi va spune compilatorului să evite publicarea bibliotecii la care se face referire, deoarece ASF deja o include pe aceasta. De asemenea, observați că trimitem la proiectul ASF cu `ExcludeAssets="all" Private="false"` care funcționează într-un mod foarte similar - spunând compilatorului să nu producă fișiere ASF (deoarece utilizatorul le are deja). Acest lucru se aplică numai când se face referire la proiectul ASF, deoarece dacă faci referire la o bibliotecă `dll`, atunci nu produci fișiere ASF ca parte a plugin-ului.

Dacă sunteți confuz despre afirmația de mai sus și nu știți mai bine, verificați care biblioteci `dll` sunt incluse în `ASF-generic. ip` pachet si asigura-te ca plugin-ul tau include doar cele care nu fac parte din el inca. Acesta va fi doar `YourPluginName.dll` pentru cele mai simple plugin-uri. Dacă întâmpinați probleme în timpul runtime în ceea ce privește unele biblioteci, includeți și bibliotecile afectate. Dacă toate celelalte eșuează, întotdeauna puteți decide să grupați totul.

---

### Dependențe native

Dependențele native sunt generate ca parte a unor clădiri specifice OS, deoarece nu există . Timpul de lucru al ET disponibil pe gazdă și ASF rulează prin propriul său program .NET care este grupat ca parte a proiectului specific OS. Pentru a minimiza dimensiunea de construcție, ASF decupează dependențele sale native pentru a include doar codul care poate fi atins în cadrul programului, care reduce efectiv părţile neutilizate ale pistei. Acest lucru vă poate crea o potențială problemă în ceea ce privește pluginul, dacă dintr-o dată vă aflați într-o situație în care plugin-ul dumneavoastră depinde de ceva. Funcția ET care nu este folosită în ASF, și, prin urmare, constructorii specifici ai OS-ului nu o pot executa corect, de obicei aruncând `System.MissingMethodException` sau `System.Reflection.ReflectionTypeLoadException` în acest proces. Pe măsură ce plugin-ul dvs. crește în mărime și devine din ce în ce mai complex, Mai devreme sau mai târziu, vei ajunge la suprafața care nu este acoperită de construcția noastră specifică OS.

Aceasta nu este niciodată o problemă cu construcțiile generice, pentru că aceste persoane nu se confruntă niciodată cu dependențe native (deoarece au terminat de lucru în gazdă, execută ASF). De aceea este o practică recomandată să **folosești plugin-ul în construcții generice exclusiv**, dar evident acest lucru are propria sa inclinare de a taia plugin-ul de la utilizatorii care ruleaza compilari ASF specifice OS. Dacă te întrebi dacă problema ta este legată de dependențele native, poți folosi, de asemenea, această metodă pentru verificare, încarcă plugin-ul în ASF un build generic și vezi dacă funcționează. În caz afirmativ, aveți dependențe de plugin acoperite, și este vorba de dependențele native care cauzează probleme.

Din păcate, a trebuit să alegem foarte greu între publicarea întregii perioade de execuție ca parte a clădirilor specifice OS, şi decizia de a o elimina din caracteristicile neutilizate, făcând construcţia de peste 80 MB mai mică decât cea completă. Am ales a doua opţiune şi, din păcate, este imposibil să incluzi caracteristicile runtime lipsă împreună cu plugin-ul tău. Dacă proiectul tău necesită acces la funcții de execuție care sunt lăsate în afară, trebuie să incluzi și complet. Durata de funcţionare a ET de care depindeţi, şi aceasta înseamnă să rulaţi plugin-ul în aroma ASF `generic`. Nu puteți rula plugin-ul în construcții specifice OS, deoarece acelor construcții le lipsește o caracteristică de execuție de care aveți nevoie, și . Începând de acum înainte, ET nu poate fuziona dependenţa nativă pe care aţi fi putut să o oferiţi de noi. Poate că se va îmbunătăţi într-o zi în viitor, dar ca şi acum pur şi simplu nu este posibil.

Elementele specifice sistemului ASF includ minimul de funcționalitate suplimentară care este necesară pentru a rula plugin-urile noastre oficiale. Pe lângă faptul că este posibil, acest lucru extinde ușor și suprafața până la dependențele suplimentare necesare pentru cele mai elementare plugin-uri. Prin urmare, nu toate plugin-urile vor trebui să se îngrijoreze de dependențele native cu care să înceapă - doar cele care depășesc ceea ce ASF și plugin-urile noastre oficiale au nevoie în mod direct. Acest lucru se face ca o plasă suplimentară, deoarece, dacă trebuie să includem noi înșine dependențele native pentru cazurile noastre de utilizare personală, oricum, le putem livra direct cu ASF, făcându-le disponibile şi, prin urmare, mai uşor de acoperit, şi pentru dumneavoastră. Din păcate, acest lucru nu este întotdeauna suficient, și deoarece plugin-ul dvs. devine mai mare și mai complex, probabilitatea de a trece la funcționalitate redusă crește. Prin urmare, vă recomandăm de obicei să rulaţi exclusiv plugin-urile personalizate în aroma de ASF `generic`. Încă puteți verifica manual dacă o versiune ASF specifică OS-ului are tot ceea ce plugin-ul are nevoie pentru funcționalitatea sa - dar din moment ce se modifică atât la actualizările cât și la ale noastre, s-ar putea să fie complicat de menținut.

Uneori poate fi posibil să se lucreze la funcțiile care lipsesc fie folosind opțiuni alternative, fie reimplementându-le în plugin-ul dvs. Totuşi, acest lucru nu este întotdeauna posibil sau viabil, mai ales dacă caracteristica lipsă vine de la terţi dependenţe pe care le incluzi ca parte a plugin-ului. Puteți încerca întotdeauna să rulați plugin-ul în construcții specifice sistemului de operare și să încercați să îl faceți să funcționeze. dar ar putea deveni prea complicat pe termen lung, în special dacă vrei din codul tău să lucreze, în loc să lupte cu suprafața ASF.

---

## Actualizări automate

ASF vă oferă două interfețe pentru implementarea actualizărilor automate în pluginul:

- `IGitHubPluginUpdates` vă oferă o modalitate ușoară de a implementa actualizări pe bază de GitHub, similare cu mecanismul general de actualizare ASF
- `IPluginUpdates` care vă oferă funcţionalitate de nivel mai scăzut care permite un mecanism personalizat de actualizare, dacă aveţi nevoie de ceva mai complex

---

### **[`IGithubPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs)**

Lista minimă de verificare a obiectelor necesare pentru ca actualizările să funcţioneze:

- Trebuie să declarați `RepositoryName`, care definește de unde sunt extrase actualizările.
- Trebuie să utilizați etichete și versiuni furnizate de GitHub. Eticheta trebuie să fie în format parsable la o versiune de plugin, ex. `1.0.0.0`.
- Proprietatea `Version` a plugin-ului trebuie să se potrivească cu tag-ul din care vine. Aceasta înseamnă că binarul disponibil sub eticheta `1.2.3.4` trebuie să se prezinte ca `1.2.3.4`.
- Fiecare etichetă ar trebui să aibă o versiune adecvată disponibilă pe GitHub cu active de lansare a fișierului zip care include fișierele binare ale plugin-ului. Fișierele binare care includ clasele `IPlugin` ar trebui să fie disponibile în directorul rădăcină din fișierul zip.

Acest lucru va permite mecanismului ASF să:

- Rezolvați `Version` curent al plugin-ului, de exemplu `1.0.1`.
- Folosiți API-ul GitHub pentru a prelua cele mai recente `tag` disponibile în repo-ul `RepositoryName`, de ex. `1.0.2`.
- Determinați că `1.0.2` > `1.0.1`, verificați eliberarea tag-ului `1.0.2` pentru a găsi fișierul `.zip` cu actualizarea plugin-ului.
- Descarcă fișierul `.zip`, extrage și pune conținutul său în directorul care a inclus `YourPlugin.dll` înainte.
- Reporniți ASF pentru a încărca plugin-ul în versiunea `1.0.2`.

Note suplimentare:

- Actualizările plugin-ului pot necesita valori de configurare ASF corespunzătoare, și anume **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)** și/sau **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)**.
- Şablonul nostru de plugin include deja tot ceea ce aveţi nevoie, pur şi simplu **[rename](https://github.com/JustArchiNET/ASF-PluginTemplate?tab=readme-ov-file#renaming-myawesomeplugin)** plugin-ul pentru valori corecte, şi va da rezultate din casetă.
- Puteți folosi combinația celor mai recente versiuni precum și pre-lansări, ele vor fi folosite ca și pe `UpdateChannel` pe care utilizatorul l-a definit.
- Proprietatea booleană `CanUpdate` poate fi suprascrisă pentru dezactivare/activarea actualizărilor de plugin-uri pe partea ta, de exemplu, dacă doriţi să săriţi temporar actualizările sau prin orice alt motiv.
- Este posibil să ai mai multe fișiere zip în versiune dacă vrei să țintești diferite versiuni ASF. Vezi `GetTargetReleaseAsset()` **[remarks](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs#L79-L106)**. De exemplu, puteţi avea `MyPlugin-V6-0.zip` precum şi `MyPlugin.zip`, care va cauza ASF în versiunea `V6. .x.x` pentru a-l alege pe primul, în timp ce toate celelalte versiuni ASF o vor folosi pe al doilea.
- Dacă cele de mai sus nu sunt suficiente pentru tine şi ai nevoie de logică personalizată pentru a alege "corect". ip`fișier, puteți suprascrie funcția`GetTargetReleaseAsset()\` și să furnizați artefactul pentru ASF utilizat.
- Dacă plugin-ul dumneavoastră trebuie să lucreze în plus înainte/după actualizare, puteţi suprascrie metodele `OnPluginUpdateProceeding()` şi/sau `OnPluginUpdateFinished()`.

---

### **[`IPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IPluginUpdates.cs)**

Aceasta interfata iti permite sa implementezi logica personalizata pentru actualizari daca din orice motiv `IGiStockPluginUpdates` nu este suficient pentru tine, de exemplu, pentru că ai etichete care nu analizează versiunile sau pentru că nu folosești deloc platforma GitHub.

Există o singură funcţie `GetTargetReleaseURL()` pentru a suprascrie, care se aşteaptă de la `Uri?` din locaţia de actualizare a plugin-ului ţintă. ASF vă oferă câteva variabile de bază care se referă la contextul cu care a fost apelată funcția, dar altele decât acestea, ești responsabil pentru implementarea tot ce ai nevoie în acea funcție și pentru furnizarea ASF URL-ul care ar trebui să fie folosit, sau `null` dacă actualizarea nu este disponibilă.

În afară de asta, este similar cu actualizările GitHub, unde URL-ul ar trebui să indice către o ". ip`fişier cu fişierele binare disponibile în directorul rădăcină. Aveți, de asemenea, disponibile metode`OnPluginUpdateProceeding()`și`OnPluginUpdateFinished()\`.