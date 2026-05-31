# Kompatibilitet

ASF är ett C# program som körs på .NET plattform. Detta innebär att ASF inte kompileras direkt till **[maskinkod](https://en.wikipedia.org/wiki/Machine_code)** som körs på din CPU, men till **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)** som kräver en CIL-kompatibel runtime för att utföra det.

Detta tillvägagångssätt har gigantiska mängder fördelar, eftersom CIL är plattformsoberoende, Därför kan ASF köras direkt på många tillgängliga operativsystem, särskilt Windows, Linux och macOS. Det finns inte bara ingen emulering som behövs, utan även stöd för alla plattformsrelaterade och hårdvarurelaterade optimeringar, såsom CPU SSE instruktioner. Tack vare detta kan ASF uppnå överlägsen prestanda och optimering, samtidigt som den erbjuder en perfekt kompatibilitet och tillförlitlighet.

Detta innebär också att ASF har **inga specifika OS-krav**, eftersom det kräver att arbeta **runtime** på det operativsystemet och inte själva operativsystemet. Så länge som körtiden körs ASF-kod korrekt, spelar det ingen roll om underliggande OS är Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii eller din brödrost - så länge det finns **[. ET för det](https://dotnet.microsoft.com/download/dotnet)**, det finns **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** för det (i `generisk` variant).

Oavsett var du kör ASF måste du dock se till att din målplattform har **[.NET-förutsättningar](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installerade. De är lågnivåbibliotek som krävs för korrekt körtid funktionalitet och absolut kärna för ASF att arbeta i första hand. Mycket troligt att du kan ha några av dem (eller till och med alla) redan installerade.

---

## ASF förpackning

ASF finns i 2 huvudsmaker - generiska paket och OS-specifika. Funktionsmässigt är båda paketen exakt desamma, de kan också automatiskt uppdatera sig själva. Den enda skillnaden mellan dem är om ASF **generiska** paket också kommer med **OS-specifika** körtid för att driva det.

---

### Generic

Generiskt paket är plattform-agnostic build som inte innehåller någon maskinspecifik kod. Denna inställning kräver att du har .NET runtime redan installerat på ditt OS **i lämplig version**. Vi vet alla hur besvärligt det är att hålla beroenden uppdaterade, därför är detta paket här främst för personer som **redan använder** . ET och vill inte duplicera sin körtid enbart för ASF om de kan använda sig av vad de redan har installerat. Generiska paket låter dig också köra ASF **var som helst, så länge du kan få fungerande implementering av . ET runtime**, oavsett om det finns OS-specifik ASF bygga för det, eller inte.

Det rekommenderas inte att använda generisk smak om du är avslappnad eller ens avancerad användare som bara vill få ASF arbete och inte gräva i . ET tekniska detaljer. Med andra ord - om du vet vad detta är, kan du använda det, annars är det mycket bättre att använda OS-specifika paket som förklaras nedan.

---

### OS-specifik

OS-specifikt paket, förutom hanteringskod som ingår i generiskt paket, innehåller även ursprungskod för given plattform. Med andra ord, OS-specifika paket **innehåller redan rätt . ET runtime inuti**, vilket gör att du helt kan hoppa över hela installationen röran och bara starta ASF direkt. OS-specifika paket, som du kan gissa från namnet, är OS-specifik och varje OS kräver sin egen version - till exempel Windows kräver PE32+ `ArchiSteamFarm. xe` binary medan Linux fungerar med Unix ELF `ArchiSteamFarm` binär. Som ni kanske vet är dessa två typer inte förenliga med varandra.

ASF finns för närvarande i följande OS-specifika varianter:

- `linux-arm` fungerar på 32-bitars ARM-baserad (ARMv7+) GNU/Linux OS med glibc 2.35/musl 1.2.3 och senare. Denna variant omfattar plattformar som Raspberry Pi 2 (och nyare), det kommer **inte** arbeta med äldre ARM arkitekturer, såsom ARMv6 hittades i Raspberry Pi 0 & 1, det kommer inte heller att fungera med operativsystem som inte implementerar krävs GNU/Linux-miljö (såsom Android).
- `linux-arm64` fungerar på 64-bitars ARM-baserad (ARMv8+) GNU/Linux OS med glibc 2.27/musl 1.2.3 och senare. Denna variant omfattar plattformar som Raspberry Pi 3 (och nyare), det kommer **inte** arbeta med 32-bitars operativsystem som inte har krävt 64-bitars bibliotek tillgängliga (såsom 32-bitars Raspberry Pi OS), det kommer inte heller att fungera med operativsystem som inte implementerar krävs GNU/Linux-miljö (såsom Android).
- `linux-x64` fungerar på 64-bitars GNU/Linux-operativsystem med glibc 2.27/musl 1.2.3 och senare.
- `osx-arm64` fungerar på 64-bitars ARM-baserad (Apple silicon) macOS OS i version 13 och senare.
- `osx-x64` fungerar på 64-bitars macOS operativsystem i version 15 och senare.
- `win-arm64` fungerar på **up-to-date** 64-bitars ARM-baserad (ARMv8+) Windows-operativsystem i version 10, 11 och senare.
- `win-x64` fungerar på **uppdaterade** 64-bitars Windows-operativsystem i version 10, 11, Server 2016+ och nyare.

Självklart, även om du inte har OS-specifika paket tillgängliga för din OS-arkitekturkombination, kan du alltid installera lämpligt . ET köra själv och köra generisk ASF smak, vilket är också den främsta anledningen till varför det finns i första hand. Generisk ASF bygga är plattform-agnostic och kommer att köras på alla plattformar som har en fungerande .NET runtime. Detta är viktigt att notera - ASF kräver .NET runtime, inte någon specifik OS eller arkitektur. Till exempel, om du kör 32-bitars Windows sedan trots att ingen dedikerad `win-x86` ASF-version, kan du fortfarande installera . ET SDK i `win-x86` version och kör generisk ASF helt bra. Vi kan helt enkelt inte rikta in oss på varje kombination av OS-arkitektur som existerar och används av någon, så vi måste rita en linje någonstans. x86 är ett bra exempel på den linjen, eftersom den är föråldrad arkitektur sedan åtminstone 2004.

För en komplett lista över alla plattformar och operativsystem som stöds av .NET 10.0, besök versionsfakta **[](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md)**.

---

## Krav för körtid

Om du använder OS-specifika paket behöver du inte oroa dig för körtidskrav, eftersom ASF alltid fartyg med nödvändig och uppdaterad körtid som kommer att fungera korrekt så länge du har **[. ET-förutsättningar](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installerade och uppdaterade. Med andra ord, **behöver du inte installera . ET runtime eller SDK**, som OS-specifika byggen kräver endast inhemska OS-beroenden (förutsättningar) och inget annat.

Men om du försöker köra **generiska** ASF-paket måste du se till att din .NET runtime stöder plattform som krävs av ASF.

ASF som ett program riktar sig mot **.NET 10.0** (`net10.`) just nu, men det kan rikta in sig på nyare plattform i framtiden. `net10.0` stöds sedan 10.0.100 SDK (10.0. runtime), även om ASF kanske föredrar **senaste runtime vid tidpunkten för sammanställningen**, så du bör se till att du har **[senaste SDK](https://dotnet.microsoft.com/download)** (eller åtminstone körtid) tillgänglig för din maskin. Generisk ASF-variant kan vägra att starta om din runtime är äldre än den angivna minimum som stöds under sammanställningen.

Om du är osäker, kontrollera vad vår **[kontinuerlig integration använder](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** för att sammanställa och distribuera ASF-utgåvor på GitHub. Du kan hitta `dotnet --info` utdata i varje version som en del av .NET verifieringssteg.