# Kompilacja

Kompilacja to proces tworzenia pliku wykonywalnego. To jest to co chcesz zrobić, jeśli chcesz dodać własne zmiany do ASF, lub jeśli z jakiegokolwiek powodu nie ufasz plikom wykonywalnym dostarczonym w oficjalnym **[wydaniu](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**. Jeśli jesteś zwykłym użytkownikiem a nie programistą, najprawdopodobniej chcesz używać już skompilowanych plików binarnych. Jeśli jednak chcesz skorzystać ze swoich własnych plików lub nauczyć się czegoś nowego, kontynuuj czytanie tego artykułu.

ASF może być skompilowany na każdej aktualnie obsługiwanej platformie, o ile masz do tego potrzebne narzędzia.

---

## SDK .NET

Bez względu na platformę, potrzebujesz pełnego .NET SDK (nie tylko czasu uruchomienia), aby skompilować ASF. Instrukcje instalacji można znaleźć na stronie **[.NET pobierania](https://dotnet.microsoft.com/download)**. Musisz zainstalować odpowiednią wersję .NET SDK dla swojego systemu operacyjnego. Po pomyślnej instalacji polecenie `dotnet` powinno działać i działać. Możesz sprawdzić, czy działa z `dotnet --info`. Upewnij się, że twój .NET SDK pasuje do ASF **[wymagania czasu pracy](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## Kompilacja

Zakładając, że masz .NET SDK działa i w odpowiedniej wersji, po prostu przejdź do źródłowego katalogu ASF (sklonowanego lub pobranego i rozpakowanego repozytorium ASF) i wykonaj:

```shell
dotnet publikuje ArchiSteamFarm -c "Release" -o "out/generic"
```

Jeśli używasz Linux/macOS, zamiast tego możesz użyć skryptu `cc.sh` , który będzie robił to samo w nieco bardziej złożony sposób.

Jeśli kompilacja zakończyła się pomyślnie, możesz znaleźć ASF w `źródłowym` aromat w katalogu `out/generic`. To samo co oficjalne `Ogólne` ASF, ale wymusił `UpdateChannel` i `UpdatePeriod` of `0`, które jest odpowiednie dla budownictwa własnego.

### Specyficzne dla systemu operacyjnego

Możesz również wygenerować pakiet .NET specyficzny dla OS. Ogólnie rzecz biorąc, nie powinieneś tego robić, ponieważ właśnie skompilowałeś `ogólny smak` , który można uruchomić z zainstalowanym już produktem. ET runtime, którego używałeś do kompilacji w pierwszym miejscu, ale na wypadek gdy:

```shell
dotnet publikuje ArchiSteamFarm -c "Wydanie" -o "out/linux-x64" -r "linux-x64" --samodzielne
```

Oczywiście zastąp `linux-x64` architekturą OS, którą chcesz wycelować, taką jak `win-x64`. Ta kompilacja będzie również wyłączona aktualizacja. Podczas budowania `--self-contained` możesz również ewentualnie zadeklarować dwa kolejne przełączniki: `-p:PublishTrimmed=true` będzie produkował skróconą kompilację, while `-p:PublishSingleFile=true` będzie produkować pojedynczy plik. Dodanie obu tych ustawień doprowadzi do tych samych ustawień, które używamy dla naszych własnych kompilacji.

### Interfejs-ASF

Podczas gdy powyższe kroki to wszystko, co jest wymagane do pełnej budowy ASF, możesz *również* być zainteresowany budową **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, naszego graficznego interfejsu internetowego. Po stronie ASF wystarczy tylko usunąć wyjściową wersję ASF-ui w standardowej lokalizacji `ASF-ui/dist` , następnie zbudować ASF z nim (ponownie, w razie potrzeby).

ASF-ui is part of ASF's source tree as a **[git submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, ensure that you've cloned the repo with `git clone --recursive`, as otherwise you'll not have the required files. Będziesz również potrzebować działającej NPM, **[Node.js](https://nodejs.org)** dołącza do niego. Jeśli używasz Linux/macOS, zalecamy nasze `cc. h` skrypt, który automatycznie obejmie budowę i wysyłkę ASF-ui (jeśli to możliwe, to znaczy, jeśli spełniasz wymogi, o których właśnie wspomnialiśmy).

Oprócz `cc. h` skrypt, dołączamy również uproszczoną instrukcję budowy poniżej, Zob. **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** w celu uzyskania dodatkowej dokumentacji. Z lokalizacji drzewa źródłowego ASF, tak jak powyżej, wykonaj następujące polecenia:

```shell
rm -rf "ASF-ui/dist" # ASF-ui nie czyści się po starej budowie

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rf "out/generic/www" # Upewnij się, że nasza budowa jest czysta ze starych plików
dotnet publikuje ArchiSteamFarm -c "Release" -o "out/generic" # Lub odpowiednio do tego, czego potrzebujesz zgodnie z powyższymi danymi
```

Powinieneś teraz znaleźć pliki ASF-ui w folderze `out/generic/www`. ASF będzie mógł obsługiwać te pliki do Twojej przeglądarki.

Alternatywnie, można po prostu zbudować ASF ui, ręcznie lub z pomocą naszego repozytorium, następnie skopiuj wyjście kompilacji do folderu `${OUT}/www` ręcznie, gdzie `${OUT}` to folder wyjściowy ASF, który określiłeś z parametrem `-o`. Właśnie to robi ASF w ramach procesu budowy, kopiuje `ASF-ui/dist` (jeżeli istnieje) do `${OUT}/www`, w razie potrzeby nic innego, jak można zrobić po budowie.

---

## Rozwój

Jeśli chcesz edytować kod ASF, możesz użyć dowolnego. IDE kompatybilne z ETE w tym celu, chociaż jest to opcjonalne, ponieważ możesz również edytować notatnikiem i kompilować z poleceniem `dotnet` opisanym powyżej.

Jeśli nie masz lepszego wybierania, możemy polecić **[JetBrains Rider](https://www.jetbrains.com/rider)** i **[Visual Studio Code](https://code.visualstudio.com/download)**, pierwsza z nich jest preferowaną IDE, z której zespół ASF korzysta osobiście i druga jest realną alternatywą. Oba programy są wieloplatformowe i dostępne na Linux, macOS i Windows.

---

## Znaczniki

Oddział `main` nie ma gwarancji, że będzie w stanie pozwalającym na udaną kompilację lub bezbłędne wykonanie ASF w pierwszej kolejności, ponieważ jest gałęzią rozwojową tak jak to zostało stwierdzone w naszym **[cyklu wydania](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. Jeśli chcesz skompilować lub odwołać się do ASF ze źródła, następnie powinieneś użyć odpowiedniego znacznika **[](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** w tym celu, który gwarantuje co najmniej udaną kompilację i bardzo prawdopodobne jest również bezbłędne wykonanie (jeśli budowa została oznaczona jako stabilne zwolnienie). In order to check the current "health" of the tree, you can use our CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Oficjalne wydania

Oficjalne wydania ASF są kompilowane przez **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, wraz z najnowszymi . ET SDK pasujący do ASF **[wymagania czasu pracy](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. Po przejściu testów, wszystkie pakiety są rozmieszczone jako wydanie, również na GitHub. Gwarantuje to również przejrzystość, ponieważ GitHub zawsze korzysta z oficjalnego źródła publicznego dla wszystkich budynków, i możesz porównać sumy kontrolne artefaktów GitHub z zasobami wydającymi GitHub. Deweloperzy ASF nie kompilują ani nie publikują samych kompilacji, z wyjątkiem prywatnego procesu rozwoju i debugowania.

Oprócz powyższego, opiekunowie ASF ręcznie sprawdzają i publikują sumy kontrolne budowane niezależnie od GitHub, zdalnego serwera ASF, jako dodatkowy środek bezpieczeństwa. Ten krok jest obowiązkowy dla istniejących ASF w celu uznania wydania za ważną osobę uprawnioną do korzystania z funkcji auto-aktualizacji.