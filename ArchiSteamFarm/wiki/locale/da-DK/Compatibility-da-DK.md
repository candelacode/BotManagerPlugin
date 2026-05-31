# Kompabilitet

ASF er et C# program, der kører på .NET platform. Det betyder, at ASF ikke er kompileret direkte til **[maskinkode](https://en.wikipedia.org/wiki/Machine_code)** , der kører på din CPU, men ind i **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)** , der kræver en CIL-kompatibel driftstid for at udføre den.

Denne tilgang har gigantiske fordele, da CIL er platformsuafhængig hvorfor ASF kan køre indbygget på mange tilgængelige operativsystemer, især Windows, Linux og macOS. Der er ikke kun ingen emulering nødvendig, men også støtte til alle platform-relaterede og hardware-relaterede optimeringer, såsom CPU SSE instruktioner. Takket være det, ASF kan opnå overlegen ydeevne og optimering, mens stadig tilbyder en perfekt kompatibilitet og pålidelighed.

Det betyder også, at ASF har **intet specifikt OS-krav**, fordi det kræver at arbejde **runtime** på denne OS og ikke OS selv. Så længe runtime udfører ASF kode korrekt, er det ligegyldigt, om underliggende OS er Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii eller din brødrister - så længe der er **[. ET for det](https://dotnet.microsoft.com/download/dotnet)**, der er **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** for det (i `generisk` variant).

Uanset hvor du kører ASF, skal du dog sikre, at din målplatform har **[.NET forudsætninger](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installeret. Disse er lav-niveau biblioteker, der kræves for korrekt køretid funktionalitet og absolut kerne for ASF til at arbejde i første omgang. Meget sandsynligt kan du have nogle af dem (eller endda alle) allerede installeret.

---

## ASF emballage

ASF leveres i 2 hovedaromaer - generiske emballage og OS-specifik. Funktionalitet-kloge begge pakker er nøjagtig de samme, de er begge også i stand til automatisk at opdatere sig selv. Den eneste forskel mellem dem er, om ASF **generisk** pakke også kommer med **OS-specifik** driftstid til at drive det.

---

### Generic

Generisk pakke er platform-agnostisk bygning, der ikke omfatter nogen maskin-specifik kode. Denne opsætning kræver fra dig at have .NET runtime allerede installeret på dit OS **i passende version**. Vi ved alle, hvor besværligt det er at holde afhængighederne ajour, Derfor er denne pakke her primært for personer, som **allerede bruger** . ET og ønsker ikke at duplikere deres runtime udelukkende til ASF, hvis de kan gøre brug af det, de allerede har installeret. Generisk pakke giver dig også mulighed for at køre ASF **overalt, så længe du kan få arbejdsdygtig implementering af. ET runtime**, uanset om der findes OS-specifik ASF bygge for det eller ej.

Det anbefales ikke at bruge generisk smag, hvis du er afslappet eller endda avanceret bruger, der bare ønsker at gøre ASF arbejde og ikke grave ind . ET tekniske detaljer. Med andre ord - hvis du ved, hvad dette er, kan du bruge det, ellers er det meget bedre at bruge OS-specifik pakke forklaret nedenfor.

---

### OS-specifik

OS-specifik pakke, bortset fra managed code inkluderet i generisk pakke, omfatter også native kode for given platform. Med andre ord indeholder OS-specifik pakke **allerede ordentligt. ET runtime inde**, som giver dig mulighed for helt at springe hele installationen rod og bare starte ASF direkte. OS-specifik pakke, som du kan gætte fra navnet, er OS-specifik, og hver OS kræver sin egen version - for eksempel Windows kræver PE32+ `ArchiSteamFarm. xe` binær, mens Linux fungerer med Unix ELF `ArchiSteamFarm` binær. Som De måske ved, er disse to typer ikke kompatible med hinanden.

ASF er på nuværende tidspunkt tilgængelig i følgende OS-specifikke varianter:

- `linux-arm` virker på 32-bit ARM-baseret (ARMv7+) GNU/Linux OSes med glibc 2.35/musl 1.2.3 og nyere. Denne variant dækker platforme såsom Raspberry Pi 2 (og nyere), det vil **ikke** arbejde med ældre ARM arkitekturer, såsom ARMv6 fundet i Raspberry Pi 0 & 1, det vil heller ikke arbejde med operativsystemer, der ikke implementerer påkrævet GNU/Linux-miljø (såsom Android).
- `linux-arm64` virker på 64-bit ARM-baserede (ARMv8+) GNU/Linux OSes med glibc 2.27/musl 1.2.3 og nyere. Denne variant dækker platforme såsom Raspberry Pi 3 (og nyere) det vil **ikke** arbejde med 32-bit operativsystemer, der ikke har krævet 64-bit biblioteker til rådighed (såsom 32-bit Raspberry Pi OS), det vil heller ikke arbejde med operativsystemer, der ikke implementerer påkrævet GNU/Linux-miljø (såsom Android).
- `linux-x64` virker på 64-bit GNU/Linux OS'er med glibc 2.27/musl 1.2.3 og nyere.
- `osx-arm64` virker på 64-bit ARM-baserede (Apple silicon) macOS OS'er i version 13 og nyere.
- `osx-x64` virker på 64-bit macOS OS'er i version 15 og nyere.
- `win-arm64` virker på **up-to-date** 64-bit ARM-baseret (ARMv8+) Windows OS'er i version 10, 11 og nyere.
- `win-x64` virker på **up-to-date** 64-bit Windows OS'er i version 10, 11, Server 2016+ og nyere.

Selvfølgelig, selvom du ikke har OS-specifik pakke til rådighed for din OS-arkitektur kombination, kan du altid installere passende. ET-driftstid selv og køre generisk ASF-smag, hvilket også er hovedårsagen til, at den overhovedet eksisterer. Generisk ASF build er platform-agnostisk og vil køre på enhver platform, der har en arbejdsgruppe .NET runtime. Dette er vigtigt at bemærke - ASF kræver .NET runtime, ikke nogle specifikke OS eller arkitektur. For eksempel, hvis du kører 32-bit Windows så på trods af ingen dedikeret `win-x86` ASF version, kan du stadig installere. ET SDK i `win-x86` version og køre generisk ASF fint. Vi kan simpelthen ikke målrette hver OS-arkitektur kombination, der eksisterer og bruges af nogen, så vi er nødt til at tegne en linje et eller andet sted. x86 er et godt eksempel på denne linje, da det er forældet arkitektur siden mindst 2004.

For en komplet liste over alle understøttede platforme og operativsystemer af .NET 10.0, besøg **[release notes](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md)**.

---

## Krav til køretid

Hvis du bruger OS-specifik pakke, så behøver du ikke at bekymre dig om runtime krav, fordi ASF altid skibe med påkrævet og up-to-date runtime, der vil fungere korrekt, så længe du har **[. ET forudsætninger](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installeret og opdateret. Med andre ord, **behøver du ikke at installere. ET runtime eller SDK**, da OS-specifikke builds kun kræver indfødte OS afhængigheder (forudsætninger) og intet andet.

Men hvis du forsøger at køre **generisk** ASF pakke, så skal du sikre, at din .NET runtime understøtter platform kræves af ASF.

ASF som et program er rettet mod **.NET 10.0** (`net10.`) lige nu, men det kan være rettet mod nyere platform i fremtiden. `net10.0` understøttes siden 10.0.100 SDK (10.0. runtime), selv om ASF måske foretrækker **seneste runtime på tidspunktet for compilation**, så du bør sikre, at du har **[seneste SDK](https://dotnet.microsoft.com/download)** (eller i det mindste runtime) tilgængelig for din maskine. Generisk ASF-variant kan nægte at starte, hvis din kørselstid er ældre end det angivne minimum understøttede en under kompilering.

Hvis du er i tvivl, så tjek hvad vores **[kontinuerlige integration bruger](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** til at kompilere og implementere ASF udgivelser på GitHub. Du kan finde `dotnet --info` output i hver build som en del af .NET verifikation trin.