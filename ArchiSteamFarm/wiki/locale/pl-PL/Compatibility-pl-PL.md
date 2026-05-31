# Kompatybilność

ASF jest aplikacją C# działającą na platformie .NET. Oznacza to, że ASF nie jest skompilowany bezpośrednio do **[kodu maszynowego](https://en.wikipedia.org/wiki/Machine_code)** , który działa na Twoim CPU, ale do **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)** , który wymaga wykonania, kompatybilnego z CIL.

Podejście to ma ogromną zaletę, ponieważ CIL jest niezależna od platform, Dlatego ASF może działać na wielu dostępnych systemach OS, zwłaszcza Windows, Linux i macOS. Nie tylko nie jest potrzebna emulacja, ale także wsparcie dla wszystkich optymalizacji związanych z platformą i sprzętem komputerowym, takich jak instrukcje CPU SSE. Dzięki temu ASF może osiągnąć lepsze wyniki i optymalizację, jednocześnie oferując doskonałą kompatybilność i wiarygodność.

Oznacza to również, że ASF nie ma **konkretnego wymagania systemu operacyjnego**, ponieważ wymaga pracy **runtime** na tym systemie operacyjnym, a nie samym OS. As long as that runtime is executing ASF code properly, it does not matter whether underlying OS is Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii or your toaster - as long as there is **[.NET for it](https://dotnet.microsoft.com/download/dotnet)**, there is **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** for it (in `generic` variant).

Jednakże, niezależnie od miejsca uruchomienia ASF, musisz upewnić się, że docelowa platforma ma zainstalowane **[.NET warunki wstępne](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)**. Są to biblioteki niskiego poziomu niezbędne do zapewnienia odpowiedniej funkcjonalności czasu pracy i absolutnie kluczowe dla działania ASF. Prawdopodobnie niektóre z nich (lub nawet wszystkie) są już zainstalowane.

---

## Wersje ASF

ASF występuje w 2 głównych smakach – w opakowaniach ogólnych i specyficznych dla OS. Funkcjonalnie oba pakiety są dokładnie takie same, obie są również w stanie automatycznie aktualizować. Jedyną różnicą między nimi jest to, czy ASF **generic** jest pakiet również z **OSspecific** czas pracy do zasilenia.

---

### Natywny

Pakiet ogólny to platforma-agnostyczna budowa, która nie zawiera żadnego kodu specyficznego dla maszyny. Ta konfiguracja wymaga od Ciebie posiadania .NET runtime już zainstalowany w systemie operacyjnym **w odpowiedniej wersji**. Wszyscy wiemy, jak kłopotami jest aktualizacja zależności, dlatego ten pakiet jest tutaj głównie dla ludzi, którzy **już używają** . ET i nie chcesz duplikować swojego czasu pracy wyłącznie dla ASF, jeśli mogą wykorzystać to, co już zainstalowały. Pakiet ogólny pozwala również na uruchomienie ASF **gdziekolwiek indziej, tak długo, jak będziesz w stanie uzyskać poprawną implementację . ET runtime**, niezależnie od tego, czy istnieje dla niego specyficzna dla OSF wersja ASF lub nie.

Nie zaleca się używania ogólnego smaku, jeśli jesteś nieumyślny lub nawet zaawansowany użytkownik, który chce po prostu zadziałać ASF, a nie kopać się. szczegóły techniczne ET. Innymi słowy - jeśli wiesz co to jest, możesz z niego korzystać, w przeciwnym razie o wiele lepiej będzie korzystać z pakietu specyficznego dla OS, objaśnionego poniżej.

---

### Specyficzne dla systemu operacyjnego

Pakiet specyficzny dla OS, poza zarządzanym kodem zawartym w pakiecie ogólnym, zawiera również kod natywny dla danej platformy. Innymi słowy, pakiet **specyficzny dla OS-a zawiera już odpowiednie. ET runtime wewnątrz**, co pozwala na całkowite pominięcie całego bałaganu instalacyjnego i bezpośrednie uruchomienie ASF. Pakiet specyficzny dla OS, ponieważ można odgadnąć z nazwy, jest specyficzne dla systemu operacyjnego i każdy system operacyjny wymaga jego własnej wersji - na przykład system Windows wymaga PE32+ `ArchiSteamFarm. xe` w systemie binarnym, podczas gdy Linux współpracuje z Unix ELF `ArchiSteamFarm` w systemie binarnym. Jak Państwo wiedzą, te dwa typy nie są ze sobą zgodne.

ASF jest obecnie dostępny w następujących wariantach specyficznych dla systemów operacyjnych:

- `linux-ramię` działa na 32-bitowej bazie ARM (ARMv7+) GNU/Linux OSes z glibdem 2.35/musl 1.2.3 i nowszym. Ten wariant obejmuje platformy takie jak Raspberry Pi 2 (i nowsze), będzie to **nie** pracować ze starszymi architekturami ARM, takie jak ARMv6 znalezione w Raspberry Pi 0 & 1, nie będzie również działać z systemem OSES, które nie zaimplementują wymaganego środowiska GNU/Linux (np. Android).
- `linux-arm64` działa na 64-bitowej bazie ARM (ARMv8+) GNU/Linux OSes z glibdem 2.27/musl 1.2.3 i nowszym. This variant covers platforms such as Raspberry Pi 3 (and newer), it will **not** work with 32-bit OSes that do not have required 64-bit libraries available (such as 32-bit Raspberry Pi OS), it will also not work with OSes that do not implement required GNU/Linux environment (such as Android).
- `linux-x64` działa na 64-bitowych systemach GNU/Linux z glibdem 2.27/musl 1.2.3 i nowszym.
- `osx-arm64` działa na 64-bitowych systemach ARM (Apple silicon) w wersji 13 i nowszej.
- `osx-x64` działa na 64-bitowych systemach OS w wersji 15 i nowszej.
- `win-arm64` działa na **aktualne** 64-bitowe bazujące na ARM (ARMv8+) Windows OSes w wersji 10, 11 i nowszej.
- `win-x64` działa na **aktualny** 64-bitowy system Windows w wersji 10, 11, Server 2016+ i nowszej.

Oczywiście, nawet jeśli nie masz pakietu specyficznego dla systemu OS, zawsze możesz zainstalować odpowiedni. ET runtime sam i uruchom ogólny aromat ASF, co jest również głównym powodem jego istnienia w pierwszej kolejności. Ogólna konstrukcja ASF jest agnostyczna i będzie działała na każdej platformie o pracującym czasie pracy .NET. Jest to ważne - ASF wymaga czasu pracy, a nie konkretnego systemu operacyjnego lub architektury. Na przykład, jeśli używasz 32-bitowych Windows, to pomimo braku dedykowanej wersji `win-x86` ASF nadal możesz zainstalować. ET SDK w wersji `win-x86` i uruchom generyczne ASF właśnie w porządku. Po prostu nie możemy wycelować każdej kombinacji architektury OS, która istnieje i jest używana przez kogoś, więc musimy gdzieś narysować linię. x86 jest dobrym przykładem tej linii, ponieważ jest ona przestarzała od co najmniej 2004 r.

For a complete list of all supported platforms and OSes by .NET 10.0, visit **[release notes](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md)**.

---

## Wymagania dotyczące czasu pracy

Jeśli używasz pakietu specyficznego dla OS, nie musisz się martwić o wymagania czasu pracy, ponieważ ASF zawsze statki z wymaganym i aktualnym czasem pracy, które będą działać poprawnie tak długo, jak masz **[. Wymagania ET](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** zainstalowane i aktualne. Innymi słowy, **nie musisz instalować. ET runtime lub SDK**, ponieważ kompilacje specyficzne dla systemu operacyjnego wymagają tylko natywnych zależności (warunki wstępne) i nic innego.

Jeśli jednak próbujesz uruchomić **generic** ASF, musisz upewnić się, że twój .NET runtime obsługuje platformę wymaganą przez ASF.

ASF jako program jest ukierunkowany na **.NET 10.0** (`net10.`) teraz, ale w przyszłości może być ukierunkowana na nowszą platformę. `net10.0` jest obsługiwany od 10.0.100 SDK (10.0. czas uruchomienia), chociaż ASF może preferować **najnowszy czas pracy w momencie kompilacji**, więc powinieneś upewnić się, że masz **[najnowsze SDK](https://dotnet.microsoft.com/download)** (lub przynajmniej czas uruchomienia) dostępne dla Twojego komputera. Generalny wariant ASF może odmówić uruchomienia, jeśli czas pracy jest starszy od określonego minimum obsługiwanego podczas kompilacji.

If in doubt, check what our **[continuous integration uses](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** for compiling and deploying ASF releases on GitHub. Możesz znaleźć `dotnet --info` wyjście w każdej kompilacji jako część kroku weryfikacji .NET.