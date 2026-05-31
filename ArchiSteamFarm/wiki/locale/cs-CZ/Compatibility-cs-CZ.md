# Kompatibilita

ASF je aplikace C# spuštěná na platformě .NET. To znamená, že ASF není kompilován přímo do kódu **[počítače](https://en.wikipedia.org/wiki/Machine_code)** , který běží na vašem CPU, ale do **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)** , která vyžaduje pro její provedení runtime kompatibilní s CIL.

Tento přístup má obrovské výhody, neboť CIL je nezávislá na platformě, a proto může ASF nativně běžet na mnoha dostupných OS, zejména Windows, Linux a macOS. Neexistuje jen žádná emulace, ale také podpora pro všechny optimalizace související s platformou a hardwarem, jako jsou pokyny k CPU SSE. Díky tomu může ASF dosáhnout lepšího výkonu a optimalizace a zároveň nabízet dokonalou kompatibilitu a spolehlivost.

To také znamená, že ASF nemá **žádný specifický požadavek OS**, protože vyžaduje práci **runtime** na tomto OS a ne samotný OS. Dokud tento běh správně provádí ASF kód, nezáleží na tom, zda je základní OS Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii nebo vaše touaster - dokud je **[. ET pro](https://dotnet.microsoft.com/download/dotnet)**pro něj existuje **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** (v variantě `generická`).

Avšak bez ohledu na to, kde používáte ASF, musíte zajistit, aby vaše cílová platforma měla **[.NET předpoklady](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** nainstalované. Jedná se o nízkoúrovňové knihovny, které jsou potřebné pro správnou funkci běhu provozu a v první řadě absolutně klíčové pro fungování ASF. Je velmi pravděpodobné, že některé z nich (nebo dokonce všechny) jsou již nainstalovány.

---

## Balení ASF

ASF se nachází ve dvou hlavních chutích - generickém balení a v speciálním případě pro OS. Obě balíčky jsou naprosto stejné, obě jsou také schopny se automaticky aktualizovat. Jediný rozdíl mezi nimi je, zda balíček ASF **generický** také přichází s **specifickou** pro jeho napájení.

---

### Obecné

Obecný balíček je platforma-agnostická sestavení, která neobsahuje žádný specifický kód pro daný stroj. Toto nastavení vyžaduje, abyste měli .NET runtime již nainstalovaný na vašem OS **v příslušné verzi**. Všichni víme, jak obtížné je udržovat závislosti aktuální, proto je tento balíček především pro lidi, kteří **již používají** . ET a nechtějí duplikovat jejich běh pouze pro ASF, pokud mohou využít toho, co již nainstalovali. Obecný balíček vám také umožňuje spustit ASF **kdekoliv, dokud budete moci získat funkční implementaci . ET runtime**bez ohledu na to, zda pro něj existuje OS-specifická ASF verze, nebo ne.

Není doporučeno používat generickou chuť, pokud jste neformální nebo dokonce pokročilý uživatel, který chce jen vytvořit ASF funkčnost a ne se vykopat . ET technické podrobnosti. Jinými slovy - pokud víte, co to je, můžete ho použít, jinak je mnohem lepší použít balíček specifický pro OS, který je vysvětlený níže.

---

### Specifický pro OSS

Balíček specifický pro OS, kromě kódu spravovaného v obecném balíčku, obsahuje také nativní kód pro danou platformu. Jinými slovy, balíček **specifický pro operační program již obsahuje řádný . ET runtime uvnitř**, který umožňuje zcela přeskočit celou instalační šlamastyku a jednoduše spustit ASF přímo. Balíček specifický pro OS, jak můžete odhadnout podle názvu, je specifický pro OS, každý OS vyžaduje jeho vlastní verzi - například Windows vyžaduje PE32+ `ArchiSteamFarm. binární xe` , zatímco Linux pracuje s Unix ELF `ArchiSteamFarm`. Jak možná víte, tyto dva typy nejsou vzájemně kompatibilní.

ASF je v současné době k dispozici v následujících variantách specifických pro OS:

- `linux-arm` pracuje na 32bitovém ARM (ARMv7+) GNU/Linux OSes s glibc 2.35/musl 1.2.3 a novější. Tato varianta zahrnuje platformy, jako je Raspberry Pi 2 (a novější), **nebude** pracovat se staršími architekturami ARM, jako ARMv6 nalezeno v Raspberry Pi 0 & 1, nebude také fungovat s OS, které neimplementují požadované prostředí GNU/Linuxu (např. Android).
- `linux-arm64` funguje na 64bitových ARM (ARMv8+) GNU/Linux OSes s glibc 2.27/musl 1.2.3 a novější. Tato varianta zahrnuje platformy jako Raspberry Pi 3 (a novější), **nebude** pracovat s 32bitovými OSes, které nemají k dispozici 64-bitové knihovny (např. 32bitové Raspberry Pi OS), nebude také fungovat s OS, které neimplementují požadované prostředí GNU/Linuxu (např. Android).
- `linux-x64` funguje na 64bitovém GNU/Linuxu s glibc 2.27/musl 1.2.3 a novějším.
- `osx-arm64` funguje na 64bitových ARM (Apple silicon) macOS ve verzi 13 a novější.
- `osx-x64` funguje na 64bitových macOS ve verzi 15 a novější.
- `win-arm64` funguje na **aktuálním** 64bitovém ARM (ARMv8+) Windows OSes ve verzi 10, 11 a novější.
- `win-x64` funguje na **aktuálním** 64bitovém Windows OSes ve verzi 10, 11, Server 2016+ a novější.

Samozřejmě, i když nemáte k dispozici balíky specifické pro operační architekturu, můžete vždy nainstalovat odpovídající . ET runtime sám sebe a spustit generickou chuť ASF, což je také hlavní důvod, proč existuje. Obecné ASF sestavení je platforma agnostická a běží na všech platformách, které mají fungující běh .NET. To je důležité vzít na vědomí - ASF vyžaduje běh .NET, ne nějaký konkrétní operační systém nebo architektura. Například pokud používáte 32bitové Windows, tak i přes žádnou speciální verzi `win-x86` , můžete stále nainstalovat . ET SDK ve verzi `win-x86` a spustit generické ASF jen v pořádku. Jednoduše se nemůžeme zaměřovat na každou kombinaci OS-architektury, která existuje a je používána někým člověkem, takže musíme někde nakreslit čáru. x86 je dobrým příkladem této linie, protože je zastaralá architektura alespoň od roku 2004.

Pro kompletní seznam všech podporovaných platforem a OSS od .NET 10.0 navštivte **[release notes](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md)**.

---

## Požadavky na běh

Pokud používáte balíček specifický pro OS, nemusíte se obávat požadavků na běh provozu, protože ASF vždy lodí s požadovaným a aktuálním běžným časem, který bude fungovat správně tak dlouho, dokud budete mít **[. ET prerequisites](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** nainstalováno a aktuální. Jinými slovy, **nemusíte instalovat . ET runtime nebo SDK**, protože verze specifické pro OS, vyžadují pouze původní závislosti OS (předpoklady) a nic jiného.

Pokud se však pokoušíte spustit **generický** ASF, musíte se ujistit, že váš .NET runtime podporuje platformu vyžadovanou aplikací ASF.

ASF jako program se zaměřuje na **.NET 10.0** (`net10.`) právě teď, ale může se zaměřit na novější platformu v budoucnosti. `net10.0` je podporována od 10.0.100 SDK (10.0. runtime), ačkoliv ASF by mohl preferovat **poslední běh v okamžiku kompilace**, abyste se ujistili, že máte poslední SDK **[](https://dotnet.microsoft.com/download)** (nebo alespoň běh času) k dispozici pro váš počítač. Obecná varianta ASF může odmítnout spustit, pokud je vaše běh starší než stanovená minimální podporovaná varianta během kompilace.

Pokud máte pochybnosti, podívejte se, co naše **[nepřetržitá integrace používá](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pro kompilaci a nasazení ASF verze na GitHub. Můžete najít `dotnet --info` výstup v každém sestavení jako součást ověřovacího kroku .NET.