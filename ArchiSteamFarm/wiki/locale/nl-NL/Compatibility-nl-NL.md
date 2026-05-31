# Compatibiliteit

ASF is een C# toepassing die loopt op .NET platform. Dit betekent dat ASF niet direct in **[machinecode](https://en.wikipedia.org/wiki/Machine_code)** is gecompileerd die wordt uitgevoerd op je CPU, maar in **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)** vereist een CIL-compatibele runtime om het uit te voeren.

Deze aanpak heeft gigantische hoeveelheden voordelen, omdat CIL platformonafhankelijk is, dit is de reden waarom ASF zelfstandig kan draaien op veel beschikbare besturen, met name Windows, Linux en macOS. Er is niet alleen geen emulatie nodig, maar ook ondersteuning voor alle platformgerelateerde en hardware-gerelateerde optimalisaties, zoals CPU SSE instructies. Hierdoor kan ASF betere prestaties en optimalisatie bereiken, terwijl het nog steeds een perfecte compatibiliteit en betrouwbaarheid biedt.

Dit betekent ook dat ASF **geen specifieke OS-vereisten**heeft, omdat het werkende **runtime** vereist op dat OS en niet op OS zelf. Zolang die runtime de ASF-code correct uitvoert, maakt het niet uit of onderliggende OS Windows is, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii of je toaster - zolang er **[is. ET daarvoor](https://dotnet.microsoft.com/download/dotnet)**, **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** is er voor (in `generieke` variant).

Ongeacht waar je ASF draait, moet je er echter voor zorgen dat er op het doelplatform **[.NET voorwaarden](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** geïnstalleerd is. Dit zijn bibliotheken die nodig zijn voor de juiste runtime functionaliteit en absoluut kern voor ASF om überhaupt te werken. Zeer waarschijnlijk kunt u sommige ervan (of zelfs alle) al geïnstalleerd hebben.

---

## ASF verpakking

ASF komt in twee grote aroma's - generieke pakket en OS-specific. Functionaliteit-wijze beide pakketten zijn precies hetzelfde, ze zijn ook in staat zichzelf automatisch te updaten. Het enige verschil tussen hen is of ASF **generiek** pakket ook komt met **OS-specifieke** runtime om het te voeden.

---

### Generic

Generiek pakket is platform-agnostische build die geen machine-specifieke code bevat. Deze instelling vereist van je dat je .NET runtime al op je OS **hebt geïnstalleerd in de juiste versie**. We weten allemaal hoe moeilijk het is om afhankelijkheden up-to-date te houden. Daarom is dit pakket er vooral voor mensen die **al** gebruiken. ET en wil hun runtime niet alleen voor ASF dupliceren als ze kunnen gebruiken wat ze al hebben geïnstalleerd. Generic package stelt je ook in staat ASF **overal uit te voeren, zolang je maar werkimplementatie van . ET runtime**, ongeacht of er een OS-specifieke ASF versie voor bestaat of niet.

Het is niet aanbevolen om algemene aroma's te gebruiken als je tijdelijk of zelfs geavanceerde gebruiker bent die ASF wil laten werken en niet graven in . ET technische details. Met andere woorden, - als je weet wat dit is, kun je het gebruiken, anders is het veel beter om OS-specifieke pakket hieronder te gebruiken.

---

### OS-specifiek

Het OS-specifieke pakket, afgezien van het beheer van de code die is opgenomen in het algemene pakket, omvat ook de innative code voor een bepaald platform. Met andere woorden, OS-specifieke **bevat al een juist pakket. ET runtime in**, waarmee je de hele installatieroutes volledig kunt overslaan en ASF direct kunt starten. OS-specifiek pakket, zoals je kunt raden uit de naam, is OS-specifiek en elke OS heeft een eigen versie nodig - bijvoorbeeld Windows heeft PE32+ `ArchiSteamFarm nodig. xe` binary terwijl Linux werkt met Unix ELF `ArchiSteamFarm` binary. Zoals u wellicht weet, zijn deze twee typen niet met elkaar te rijmen.

ASF is momenteel beschikbaar in de volgende OS-specifieke varianten:

- `linux-arm` werkt op 32-bit ARMv7+) GNU/Linux OSes met glibc 2.35/musl 1.2.3 en nieuwer. Deze variant dekt platformen zoals Raspberry Pi 2 (en nieuwer), het zal **niet** werken met oudere ARM architecturen, zoals ARMv6 gevonden in de Raspberry Pi 0 & 1, het zal ook niet werken met besturen, die de vereiste GNU/Linux omgeving (zoals Android) niet implementeren.
- `linux-arm64` werkt op 64-bit ARMv8+) GNU/Linux OSes met glibc 2.27/musl 1.2.3 en nieuwer. Deze variant dekt platformen zoals Raspberry Pi 3 (en nieuwer), het zal **niet** werken met 32-bit besturingssystemen die geen 64-bit bibliotheken beschikbaar hebben (zoals 32-bit Raspberry Pi OS), het zal ook niet werken met besturen, die de vereiste GNU/Linux omgeving (zoals Android) niet implementeren.
- `linux-x64` werkt op 64-bit GNU/Linux OSes met glibc 2.27/musl 1.2.3 en nieuwer.
- `osx-arm64` werkt op 64-bit ARM-based (Apple silicon) macOS OS in versie 13 en nieuwer.
- `osx-x64` werkt op 64-bit macOS OS in versie 15 en nieuwer.
- `win-arm64` werkt op **up-to-date** 64-bit ARMv8+) Windows OSes in versie 10, 11 en nieuwer.
- `win-x64` werkt op **up-to-date** 64-bit Windows besturingssystemen in versie 10, 11, Server 2016+ en nieuwer.

Natuurlijk, zelfs als je geen OS-specifieke pakket beschikbaar hebt voor jouw OS-architectuur-combinatie, kun je altijd de juiste installeren. ET maakt zelf gebruik van de smaak, generieke ASF-smaak, wat ook de belangrijkste reden is waarom het bestaat. Generieke ASF-build is platform-agnostisch en wordt uitgevoerd op elk platform dat een werkende .NET runtime heeft. Dit is belangrijk om op te merken dat ASF .NET runtime nodig heeft, niet sommige specifieke OS of architectuur. Bijvoorbeeld, als u 32-bit Windows gebruikt, dan kan u ondanks geen toegewijde `win-x86` ASF versie installeren . ET SDK in `win-x86` versie en voer de algemene ASF gewoon goed uit. We kunnen ons eenvoudigweg niet op elke OS-architectuur-combinatie richten die door iemand wordt gebruikt, dus we moeten ergens een grens trekken. x86 is een goed voorbeeld van die lijn, omdat het ten minste sinds 2004 verouderde architectuur is.

Voor een volledige lijst van alle ondersteunde platforms en besturingssystemen door .NET 10.0, bezoek **[release notes](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md)**.

---

## Vereisten voor Runtime

Als je OS-specifieke pakket gebruikt, hoef je je geen zorgen te maken over runtime vereisten. omdat ASF altijd met vereiste en up-to-date runtime die goed werkt zolang je **[hebt. ET voorwaarden](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** geïnstalleerd en bijgewerkt. Met andere woorden, **hoeft u niet te installeren. ET runtime of SDK**, omdat OS-specifieke builds alleen native OS afhankelijkheden vereisen (voorwaarden) en niets anders.

Echter, als je **generieke** ASF pakket probeert uit te voeren, dan moet je ervoor zorgen dat het .NET runtime platform vereist is door ASF.

ASF als een programma richt zich op **.NET 10.0** (`net10.`) op dit moment, maar het kan in de toekomst gericht zijn op een nieuwer platform. `net10.0` wordt ondersteund sinds 10.0.100 SDK (10.0. runtime), hoewel ASF de voorkeur kan geven aan de laatste runtime **op het moment van compilatie**, dus moet je ervoor zorgen dat je **[nieuwste SDK](https://dotnet.microsoft.com/download)** (of ten minste runtime) beschikbaar hebt voor je machine. Generieke ASF-variant kan weigeren om te starten als je runtime ouder is dan het gespecificeerde minimum ondersteund tijdens compilatie.

Als je twijfelt, controleer wat onze continue **[integratie gebruikt als](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** voor het compileren en implementeren van ASF releases op GitHub. Je vindt `dotnet --info` uitvoer in elke build als onderdeel van .NET verificatie stap.