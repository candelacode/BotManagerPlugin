# Rozwój wtyczek

ASF zawiera obsługę niestandardowych wtyczek, które mogą być załadowane podczas pracy. Wtyczki pozwalają dostosować zachowanie ASF, na przykład dodając własne komendy, niestandardową logikę handlu lub całą integrację z usługami innych firm i API.

Ta strona opisuje wtyczki ASF z perspektywy deweloperów - tworzenie, zachowywanie, publikowanie i podobne. If you want to view user's perspective, move **[here](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** instead.

---

## Główne

Wtyczki są standardowymi bibliotekami .NET, które definiują klasę odziedziczającą ze wspólnego interfejsu `IPlugin` zadeklarowaną w ASF. Możesz tworzyć wtyczki całkowicie niezależnie od głównego ASF i ponownie używać ich w aktualnych i przyszłych wersjach ASF, tak długo, jak wewnętrzne API ASF pozostaje kompatybilne. System wtyczek używany w ASF opiera się na `Systemie. omposition`, znana wcześniej jako **[Zarządzany Extensibility Framework](https://docs.microsoft.com/dotnet/framework/mef)**, który pozwala ASF odkrywać i ładować biblioteki podczas pracy.

---

### Pierwsze kroki

Przygotowaliśmy **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate)** dla Ciebie, którą możesz (i powinieneś) wykorzystać jako podstawę dla projektu pluginu. Używanie szablonu **nie jest wymaganiem** (ponieważ możesz robić wszystko od zera), ale zdecydowanie zalecamy jego odebranie, ponieważ może on drastycznie uruchomić Twój rozwój i skrócić czas potrzebny do poprawnego działania. Po prostu sprawdź **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** szablonu i poprowadzi Cię dalej. Bez względu na to, zajmiemy się poniższymi podstawami, gdybyś chciał zacząć od zera, lub lepiej zrozumieć pojęcia użyte w szablonie pluginów - zazwyczaj nie musisz robić żadnego z nich, jeśli zdecydujesz się użyć naszego szablonu pluginów.

Twój projekt powinien być standardowy. Biblioteka ET ukierunkowana na odpowiednie ramy docelowej wersji ASF, jak określono w sekcji **[compilation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation)**.

Projekt musi odnosić się do głównego zespołu `ArchiSteamFarm`, albo jego wstępnie zbudowany `ArchiSteamFarm. ll` biblioteka, którą pobrałeś jako część wydania, lub projekt źródłowy (np. jeśli zdecydowałeś się dodać drzewo ASF jako submoduł). Pozwoli to na dostęp i odkrycie struktur, metod i właściwości ASF, szczególnie rdzeń interfejs `IPlugin`, z którego będziesz musiał odziedziczyć w następnym kroku. Projekt musi również odnosić się do `System.Composition.AttributedModel` co pozwala na `[Export]` twojego `IPlugin` dla ASF do użycia. Dodatkowo, możesz chcieć/potrzebować odwoływania się do innych wspólnych bibliotek w celu zinterpretowania struktur danych, które są udzielane w niektórych interfejsach, ale jeśli ich nie potrzebujecie wyraźnie, to na razie wystarczy.

Jeśli zrobiłeś wszystko poprawnie, twój plik `csproj` będzie podobny do poniżej:

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

Po stronie kodu, klasa wtyczki musi dziedziczyć z interfejsu `IPlugin` (albo bezpośrednio, albo pośrednio, dziedzicząc z bardziej wyspecjalizowanego interfejsu, takie jak `IASF`) i `[Export(typeof(IPlugin)]` w celu rozpoznania przez ASF podczas pracy. Najbardziej oczywistym przykładem jest to, co można osiągnąć:

```csharp
za pomocą System;
za pomocą System.Composition;
za pomocą System.Threading.Tasks;
za pomocą ArchiSteamFarm;
za pomocą ArchiSteamFarm.Plugins;

pace YourNamespace. ourPluginName;

[Export(typeof(IPlugin))]
public sealed class YourPluginName : IPlugin {
	public string name = > nameof(YourPluginName);
	public version = > typeof(YourPluginName). ssembly.GetName().Wersja;

	public Task OnLoaded() {
		ASF.ArchiLogger.LogGenericInfo("Hello World!");

		return Task.CompletedTask;
	}
}
```

Aby korzystać z wtyczki, musisz najpierw ją skompilować. Możesz to zrobić albo ze swojego IDE, albo z katalogu głównego projektu za pomocą polecenia:

```shell
# Jeśli twój projekt jest samodzielny (nie trzeba definiować jego nazwy, ponieważ jest jedynym)
dotnet publikuje -c "Wydaj -o "out"

# Jeśli twój projekt jest częścią drzewa źródłowego ASF (aby uniknąć kompilacji niepotrzebnych części)
dotnet publikuje YourPluginName -c "Wydaj -o "out"
```

Następnie wtyczka jest gotowa do wdrożenia. Od Ciebie zależy jak dokładnie chcesz rozpowszechniać i publikować swoją wtyczkę, ale zalecamy utworzenie archiwum zip, w którym umieścisz skompilowaną wtyczkę razem z jej **[dependencies](#plugin-dependencies)**. W ten sposób użytkownik będzie musiał po prostu rozpakować archiwum zip do samodzielnego podkatalogu wewnątrz ich katalogu `plugins` i zrobić nic innego.

To tylko najbardziej podstawowy scenariusz na początek. Mamy projekt **[`Przykładowa Plugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)**, który pokazuje przykładowe interfejsy i działania, które możesz wykonać w ramach własnej wtyczki, w tym pomocne komentarze. Nie zapomnij spojrzeć czy chcesz uczyć się z działającego kodu lub odkryć `ArchiSteamFarm. lugins` sam w sobie i odwołaj się do dołączonej dokumentacji dla wszystkich dostępnych opcji. Będziemy również dalej pracować nad niektórymi podstawowymi pojęciami, aby lepiej je wyjaśnić.

Jeśli zamiast przykładowej wtyczki chcesz uczyć się od prawdziwych projektów, istnieje kilka oficjalnych pluginów stworzonych przez nas, np. **[`ItemsMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.ItemsMatcher)**, **[`MobileAuthenticator`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.MobileAuthenticator)** lub **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)**. Ponadto istnieją również wtyczki opracowane przez innych deweloperów w naszej sekcji **[third-party](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)**.

---

### Dostępność API

ASF, oprócz tego, do czego masz dostęp w samych interfejsach, naraża Cię na wiele wewnętrznych interfejsów API, z których możesz korzystać, aby rozszerzyć funkcjonalność. Na przykład, jeśli chcesz wysłać jakieś nowe żądanie do Steam web, nie musisz wdrażać wszystkiego od zera, w szczególności zajmują się wszystkimi problemami, z którymi musieliśmy się poradzić. Po prostu użyj naszego `Bota. rchiWebHandler`, który już wystawia wiele metod `UrlWithSession()` do użycia, obsługa wszystkich przedmiotów niższego poziomu, takich jak uwierzytelnianie, odświeżenie sesji lub ograniczenie zawartości stron internetowych dla Ciebie. Podobnie, aby wysyłać żądania stron internetowych poza platformą Steam, możesz użyć standardowej klasy .NET `HttpClient`, ale o wiele lepiej jest używać `Bot. rchiWebHandler.WebBrowser`, który jest dla Ciebie dostępny, który po raz kolejny oferuje Ci pomocną rękę, na przykład w odniesieniu do powtórzenia nieudanych żądań.

Mamy bardzo otwartą politykę w zakresie dostępności API, więc jeśli chcesz użyć czegoś, co zawiera już kod ASF, po prostu **[otwórz zgłoszenie](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** i wyjaśnij w nim swój planowany przypadek użycia interfejsu API naszego ASF. Najprawdopodobniej nie będziemy mieli nic przeciwko, o ile Twój przypadek ma sens. Obejmuje to również wszystkie sugestie dotyczące nowych interfejsów `IPlugin`, które mogą być dodawane w celu rozszerzenia istniejącej funkcjonalności.

Jednak bez względu na dostępność ASF API nic nie powstrzymuje Cię od np. włączenia `Discord. et` biblioteka w aplikacji i tworzenie mostu między twoim botem Discorda a poleceniami ASF, ponieważ twoja wtyczka może mieć również same zależności. Możliwości są niekończące się i uczyniliśmy wszystko, co w naszej mocy, aby dać Ci jak najwięcej wolności i elastyczności w ramach twojej wtyczki, więc nie ma sztucznych ograniczeń na cokolwiek - wtyczka jest wczytywana do głównego procesu ASF i może zrobić wszystko, co jest realistycznie możliwe do zrobienia w ramach kodu C# .

---

### API compatibility

Ważne jest, aby podkreślić, że ASF jest aplikacją konsumencką, a nie typową biblioteką o stałej powierzchni API, którą można bezwarunkowo uzależnić. Oznacza to, że nie możesz zakładać, że twoja wtyczka po kompilacji będzie nadal pracować ze wszystkimi przyszłymi wersjami ASF, bez względu na to, jest po prostu niemożliwe, jeśli chcemy dalej rozwijać program, i niemożność dostosowania się do stale trwających zmian Steam w celu zapewnienia wstecznej kompatybilności jest dla nas po prostu niewłaściwa. To powinno być dla Ciebie logiczne, ale ważne jest podkreślenie tego faktu.

Zrobimy wszystko, co w naszej mocy, aby publiczne części ASF działały i były stabilne, ale nie boimy się złamać kompatybilności, jeśli pojawią się wystarczająco dobre przyczyny, śledzenie naszej polityki **[deprecation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation)** w tym procesie. Jest to szczególnie ważne w odniesieniu do wewnętrznych struktur ASF, które są narażone na kontakt z Tobą w ramach infrastruktury ASF (np. `ArchiWebHandler`), które mogą zostać ulepszone (a zatem przeredagowane) jako część ulepszeń ASF w jednej z przyszłych wersji. Zrobimy wszystko, co w naszej mocy, aby poinformować Cię o przestarzałych funkcjach w dziennikach zmian i zamieścić odpowiednie ostrzeżenia podczas pracy. Nie zamierzamy ponownie napisać wszystkiego w celu jego ponownego napisania. więc możesz mieć pewność, że następna dodatkowa wersja ASF nie tylko zniszczy wtyczkę tylko dlatego, że ma ona wyższy numer wersji, ale zwracanie uwagi na listę zmian i okazjonalną weryfikację, jeśli wszystko jest w porządku, to bardzo dobry pomysł.

---

### Zależności wtyczek

Wtyczka będzie zawierać co najmniej dwie zależności domyślnie, odwołanie `ArchiSteamFarm` dla wewnętrznego API (`IPlugin` co najmniej) i `PackageReference` dla `Systemem. omposition.AttributedModel`, który jest wymagany do rozpoznania jako wtyczka ASF do rozpoczęcia od klauzuli (`[Export]`). Ponadto może zawierać więcej zależności w odniesieniu do tego, co zdecydowałeś się zrobić w swojej wtyczce (e. . Biblioteka `Discord.Net` jeśli zdecydowałeś się zintegrować z Discordem).

Wynikiem twojej budowy będzie twoja bazowa biblioteka `YourPluginName.dll`, jak również wszystkie zależności, do których się odnosiłeś. Ponieważ tworzysz wtyczkę do już działającego programu, nie musisz tego robić, a nawet **powinien** uwzględniać zależności, które ASF już zawiera, na przykład `ArchiSteamFarm`, `SteamKit2` lub `AngleSharp`. Usuwanie zależności kompilacji współdzielonych z ASF nie jest bezwzględnym wymogiem dla twojej wtyczki, ale w ten sposób znacznie ograniczy ilość pamięci i rozmiar wtyczki, wraz z zwiększeniem wydajności ze względu na fakt, że ASF podzieli się z Tobą własnymi zależnościami, i załaduje tylko te biblioteki, których nie zna sam.

Ogólnie rzecz biorąc, zalecane jest włączenie tylko tych bibliotek, które ASF albo nie zawarło lub nie zawarło w niewłaściwej lub niezgodnej wersji. Przykładami takich działań będą oczywiście `YourPluginName.dll`, ale na przykład `Discord.Net.dll`, jeśli zdecydowałeś się na to uzależnić, ponieważ ASF nie obejmuje tego samego. Pakowanie bibliotek udostępnianych ASF może nadal mieć sens, jeśli chcesz zapewnić kompatybilność API (np. upewnianie się, że `AngleSharp`, od którego jesteś zależny w twojej wtyczce, będzie zawsze w wersji `X`, a nie w wersji ASF ze statkiem), ale oczywiście oznacza to cenę zwiększonej pamięci/wielkości i gorszej wydajności, dlatego też należy ją uważnie ocenić.

Jeśli wiesz, że zależność, której potrzebujesz, jest zawarta w ASF, możesz oznaczyć je `IncludeAssets="compile"` jak pokazaliśmy w przykładzie `csproj` powyżej. To powiedzi kompilatorowi, aby nie publikować samej biblioteki, ponieważ ASF już zawiera tę bibliotekę. Podobnie, zauważ, że odwołujemy się do projektu ASF za pomocą `ExcludeAssets="all" Private="false"` który działa w bardzo podobny sposób - mówiąc kompilatorowi, że nie produkuje żadnych plików ASF (jak ma to już użytkownik). Dotyczy to tylko odwoływania się do projektu ASF, ponieważ jeśli odwołujesz się do biblioteki `dll`, to nie produkujesz plików ASF jako części wtyczki.

Jeśli mylisz o powyższej instrukcji i nie wiesz lepiej, sprawdź, które biblioteki `dll` są zawarte w `ASF-generic. ip` pakiet i upewnij się, że wtyczka zawiera tylko te, które jeszcze nie są jej częścią. To będzie tylko `YourPluginName.dll` dla najbardziej prostych wtyczek. Jeśli pojawią się jakieś problemy z niektórymi bibliotekami, także te biblioteki, których to dotyczy. Jeśli wszystko inne nie powiedzie się, zawsze możesz postanowić o pakiecie wszystkiego.

---

### Natywne zależności

Natywne zależności są generowane jako część budynków specyficznych dla OS, ponieważ nie ma . Czas użytkowania ET dostępny na serwerze i ASF przechodzi przez własny czas użytkowania .NET, który jest dołączony jako część budowy specyficznej dla OS. Aby zminimalizować rozmiar budowli, ASF przywraca jego rodzime zależności, aby uwzględnić tylko kod, który może zostać osiągnięty w ramach programu, skutecznie przecięto niewykorzystane części czasu pracy. To może stworzyć dla Ciebie potencjalny problem w odniesieniu do wtyczki, jeśli nagle dowiesz się w sytuacji, w której twoja wtyczka jest od jakiegoś zależna. Funkcja ET, która nie jest używana w ASF i dlatego kompilacje specyficzne dla OSS nie mogą wykonać jej poprawnie, zazwyczaj rzucając w ten proces `System.MissingMethodException` lub `System.Reflection.ReflectionTypeLoadException`. W miarę jak twój plugin rośnie i staje się coraz bardziej złożony, prędzej czy później uderzysz w powierzchnię, która nie jest pokryta naszą budową systemu operacyjnego.

Nigdy nie jest to problem z budynkami ogólnymi, ponieważ osoby te nigdy nie radzą sobie z rodzimymi zależnościami w pierwszym miejscu (ponieważ mają pełny czas pracy na gospodarzu, wykonując ASF). Dlatego właśnie zalecaną praktyką jest **używanie wtyczki wyłącznie w ogólnych wersjach oprogramowania**, ale oczywiście to ma swój własny dół cięcia wtyczki od użytkowników, którzy korzystają z specyficznych dla systemu wersji ASF. Jeśli zastanawiasz się, czy problem jest związany z rodzimymi zależnościami, możesz również użyć tej metody do weryfikacji, załadować wtyczkę w ogólnej kompilacji ASF i sprawdzić, czy działa. Jeśli tak się stanie, masz pokryte zależności wtyczki i jest to natywne zależności powodujące problemy.

Niestety musieliśmy dokonać trudnego wyboru między publikowaniem przez cały czas pracy w ramach naszych budynków specyficznych dla OS, i postanawiając odciąć go od niewykorzystanych funkcji, dzięki czemu budowa o przepustowości 80 MB jest mniejsza niż pełna. Wybraliśmy drugą opcję i niestety niemożliwe jest uwzględnienie brakujących funkcji czasu pracy wraz z wtyczką. Jeśli twój projekt wymaga dostępu do funkcji czasu pracy, które są pominięte, musisz dołączyć pełną . ET runtime zależny od Ciebie i to oznacza uruchomienie wtyczki w `generic` Aromacie ASF. Nie możesz uruchomić wtyczki w budynkach specyficznych dla OS, ponieważ te kompilacje po prostu nie posiadają funkcji czasu pracy, której potrzebujesz, i . ET runtime od teraz nie jest w stanie "scalić" rodzimej zależności, którą mógłbyś zapewnić naszym własnym. Być może poprawi się to pewnego dnia w przyszłości, ale od teraz jest to po prostu niemożliwe.

Kompilacje specyficzne dla ASF zawierają niestandardowe minimum dodatkowych funkcji, które są wymagane do uruchomienia naszych oficjalnych pluginów. Oprócz tego, że jest to możliwe, to również nieznacznie rozszerza powierzchnię na dodatkowe zależności wymagane dla najbardziej podstawowych wtyczek. Dlatego nie wszystkie wtyczki będą musiały się martwić o rodzime zależności, aby zacząć od nich - tylko te, które wykraczają poza to, czego bezpośrednio potrzebują ASF i nasze oficjalne wtyczki. Czyni się to dodatkowo, ponieważ jeśli musimy uwzględnić dodatkowe rodzime zależności dla naszych własnych spraw, możemy również dostarczyć je bezpośrednio za pomocą ASF, udostępniając je i w związku z tym łatwiej je obejrzeć. Niestety to nie zawsze wystarczy i w miarę jak wtyczka staje się coraz bardziej złożona, wzrasta prawdopodobieństwo uruchomienia się w przycięte funkcje. Dlatego zazwyczaj zalecamy uruchomienie niestandardowych wtyczek wyłącznie w "generic" smaku ASF. Nadal możesz ręcznie zweryfikować, czy specyficzna dla OSS konstrukcja ASF ma wszystko, czego potrzebujesz dla jego funkcjonalności - ale od tego czasu zmiany w swoich aktualizacjach oraz naszy, może być trudna do utrzymania.

Czasami może być możliwe "działanie" brakujących funkcji poprzez użycie alternatywnych opcji lub ponowne wdrożenie ich w twojej wtyczce. Nie zawsze jest to jednak możliwe lub wykonalne, zwłaszcza jeśli brakująca funkcja pochodzi z zależności innych firm, które włączasz jako część wtyczki. Zawsze możesz spróbować uruchomić wtyczkę w wersji specyficznej dla systemu OS, aby działała, ale w dłuższej perspektywie może to stać się zbyt trudne, zwłaszcza, jeśli chcesz, aby Twój kod działał, zamiast walczyć z powierzchnią ASF.

---

## Automatyczne aktualizacje

ASF oferuje dwa interfejsy do implementacji automatycznych aktualizacji wtyczki:

- `IGitHubPluginUpdates` zapewnia łatwy sposób na wdrożenie aktualizacji GitHub'a podobnych do ogólnego mechanizmu aktualizacji ASF
- `IPluginUpdates` zapewniająca niższą funkcjonalność pozwalającą na niestandardowy mechanizm aktualizacji, jeśli potrzebujesz czegoś bardziej skomplikowanego

---

### **[`IGithubPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs)**

Minimalna lista kontrolna rzeczy, które są wymagane dla aktualizacji do działania:

- Musisz zadeklarować `RepositoryName`, który definiuje skąd są pobierane aktualizacje.
- Musisz użyć tagów i wydań dostarczonych przez GitHub. Tag musi być w formacie umożliwiającym przetworzenie do wersji wtyczki, np. `1.0.0.0`.
- Właściwość `Version` wtyczki musi odpowiadać tagowi, z którego pochodzi. Oznacza to, że binarny dostępny pod tagiem `1.2.3.4` musi się prezentować jako `1.2.3.4`.
- Każdy tag powinien mieć odpowiednią wersję dostępną na GitHub z zasobem wydającym plik zip, który zawiera pliki binarne wtyczki. Pliki binarne zawierające klasy `IPlugin` powinny być dostępne w katalogu głównym w pliku zip.

Pozwoli to mechanizmowi ASF na:

- Rozwiąż bieżącą `Wersję` wtyczki, np. `1.0.1`.
- Użyj GitHub API, aby pobrać najnowsze `tag` dostępne w repozytorium `RepositoryName`, np. `1.0.2`.
- Określ że `1.0.2` > `1.0.1`, sprawdź wydanie tagu `1.0.2` aby znaleźć plik `.zip` z aktualizacją wtyczki.
- Pobierz ten plik `.zip`, rozpakuj go i umieść go w katalogu zawierającym `YourPlugin.dll` wcześniej.
- Uruchom ponownie ASF, aby załadować wtyczkę w wersji `1.0.2`.

Uwagi dodatkowe:

- Aktualizacje wtyczek mogą wymagać odpowiednich wartości konfiguracji ASF, a mianowicie **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)** i/lub **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)**.
- Nasz szablon wtyczki zawiera już wszystko, czego potrzebujesz, po prostu **[rename](https://github.com/JustArchiNET/ASF-PluginTemplate?tab=readme-ov-file#renaming-myawesomeplugin)** wtyczka do poprawnych wartości, a to zadziała.
- Możesz użyć kombinacji najnowszych wersji, jak również wstępnych wersji, będą one używane zgodnie z `UpdateChannel` który użytkownik zdefiniował.
- Istnieje właściwość logiczna `CanUpdate`, którą możesz nadpisać, aby wyłączyć / włączyć aktualizację wtyczek po swojej stronie, na przykład jeśli chcesz tymczasowo pominąć aktualizacje lub z innego powodu.
- Istnieje możliwość posiadania wielu plików zip w wydaniu, jeśli chcesz być adresowany do różnych wersji ASF. Zobacz `GetTargetReleaseAsset()` **[remarks](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs#L79-L106)**. Na przykład, możesz mieć `MyPlugin-V6-0.zip` oraz `MyPlugin.zip`, co spowoduje ASF w wersji `V6. .x.x` do wybrania pierwszej, podczas gdy wszystkie pozostałe wersje ASF użyją drugiej.
- Jeśli powyższe nie są dla Ciebie wystarczające i potrzebujesz niestandardowej logiki do wybrania poprawnego `. ip` plik, możesz nadpisać funkcję `GetTargetReleaseAsset()` i podać artefakt do użycia przez ASF.
- Jeśli twoja wtyczka musi wykonać dodatkową pracę przed/po aktualizacji, możesz nadpisać metody `OnPluginUpdateProceeding()` i/lub `OnPluginUpdateFinished()`.

---

### **[`IPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IPluginUpdates.cs)**

Ten interfejs pozwala na implementację niestandardowej logiki aktualizacji, jeśli z jakiegoś powodu `IGithubPluginUpdates` nie jest dla Ciebie wystarczy, na przykład, ponieważ masz tagi, które nie analizują wersji lub ponieważ w ogóle nie używasz platformy GitHub.

Istnieje pojedyncza funkcja `GetTargetReleaseURL()` do nadpisania, która oczekuje od Ciebie `Uri?` docelowej lokalizacji aktualizacji wtyczki. ASF dostarcza kilka podstawowych zmiennych, które odnoszą się do kontekstu, z którym funkcja została wywołana, ale innych niż to, jesteś odpowiedzialny za implementację wszystkiego, czego potrzebujesz w tej funkcji i dostarczenie ASF adresu URL, który powinien być użyty, lub `null` jeśli aktualizacja nie jest dostępna.

Poza tym, jest on podobny do aktualizacji GitHub, gdzie adres URL powinien wskazywać `. plik ip` z plikami binarnymi dostępnymi w katalogu głównym. Masz również dostępne metody `OnPluginUpdateProceeding()` i `OnPluginUpdateFinished()`.