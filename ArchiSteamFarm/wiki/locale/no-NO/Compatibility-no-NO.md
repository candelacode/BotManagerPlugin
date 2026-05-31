# Kompatibilitet

ASF er en C# applikasjon som kjører på .NET plattform. Dette betyr at ASF ikke er sammensatt direkte i **[maskinkode](https://en.wikipedia.org/wiki/Machine_code)** som kjører på CPU, men i **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)** som krever en CIL-kompatibel runtime for å kjøre den.

Denne tilnærmingen har gigantisk mengde fordeler, siden CIL er plattformuavhengig Og derfor kan ASF kjøre totalt på mange tilgjengelige OS, spesielt Windows, Linux og macOS. Det er ikke bare nødvendig å få noen emulering, men også støtte for alle plattformrelaterte og maskinvarerelaterte optimaliseringer, slik som CPU SSE instruksjoner. Takket være det kan ASF oppnå overlegent ytelse og optimalisering, samtidig som det likevel gis perfekt tilbøyelighet og pålitelighet.

Dette betyr også at ASF har **intet spesifikt krav til OS**, fordi det krever arbeid **kjøretid** på det OS og ikke selve systemet. Så lenge den kjøretiden utfører ASF-kode riktig, har det ingen betydning om underliggende OS er Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii eller din pÃ¥ske - så lenge det er **[. ET for det](https://dotnet.microsoft.com/download/dotnet)**, finnes det **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** for den (i `generisk` variant).

Men uansett hvor du kjører ASF, må du sikre at målplattformen har **[.NET forutsetningene](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installert. Dette er biblioteker på lavt nivå som kreves for korrekt kjøretidsfunksjonalitet og helt kjerneområde for ASF skal fungere på førsteplass. Svært sannsynlig kan du ha noen av dem (eller til og med alle) allerede installert.

---

## ASF emballasje

ASF leveres i to hovedsmaker - generisk pakke og OS-spesifikke. Både funksjons-kloke pakker er nøyaktig de samme, de er også i stand til å automatisk oppdatere seg selv. Forskjellen mellom dem er hvorvidt ASF **generisk** pakke også følger med **OS-spesifikk** kjøretid for å drive den.

---

### Generic

Generisk pakke er plattform-agnostisk bygg som ikke inneholder noen maskinspesifikk kode. Dette oppsettet krever at du har .NET kjøretid allerede er installert på ditt OS **i riktig versjon**. Vi vet alle hvor problematisk det er å holde avhengighetene oppdatert Derfor er denne pakken her hovedsakelig for personer som **allerede bruker** . ET og ikke ønsker å duplisere runtiden kun for ASF hvis de kan bruke det de har installert allerede. Generisk pakke lar deg også kjøre ASF **hvor som helst, så lenge du kan få arbeidsgjennomføring av . ET kjøretid**, uavhengig om det finnes OS-spesifikk ASF-bygg for det, eller ikke.

Det anbefales ikke å bruke generisk smak hvis du er uforpliktende eller til og med avansert bruker som bare ønsker å arbeide ASF og ikke grave i . ET teknisk informasjon. Med andre ord – hvis du vet hva dette er, kan du bruke den, ellers er det mye bedre å bruke OS-spesifikk pakke forklart nedenfor.

---

### OS-spesifikk

OS-spesifikk pakning, med unntak av forvaltet kode i generell pakke, inneholder også vanlige koder for den enkelte plattform. OS-spesifikk pakke **inneholder allerede ordentlig . ET kjøretid inni**, slik at du kan helt hoppe over hele installeringsmåten, og bare starte ASF direkte. OS-spesifikk pakning, som du kan gjette fra navnet, er OS-spesifikk og hvert OS krever sin egen versjon - for eksempel Windows krever PE32+ `ArchiSteamFarm. xe` binær mens Linux fungerer med Unix ELF `binær SteamFarm`. De to typene er som ikke kompatible med hverandre.

ASF er for tiden tilgjengelig i følgende OS-spesifikke varianter:

- `linux-arm` virker på 32-bit ARM-basert (ARMv7+) GNU/Linux OSes med glibc 2.35/musl 1.2.3 og nyere. This variant covers platforms such as Raspberry Pi 2 (and newer), it will **not** work with older ARM architectures, such as ARMv6 found in Raspberry Pi 0 & 1, it will also not work with OSes that do not implement required GNU/Linux environment (such as Android).
- `linux-arm64` virker på 64-bit ARM-basert (ARMv8+) GNU/Linux OSes med glibc 2.27/musl 1.2.3 og nyere. Denne varianten dekker plattformer som Raspberry Pi 3 (og nyere) det vil **ikke** arbeide med 32-bit OSes som ikke har krevd tilgjengelige 64-biters biblioteker (som 32-bit Raspberry Pi OS), det vil heller ikke fungere med OSes som ikke har nødvendige GNU/Linux miljø (slik som Android).
- `linux-x64` virker på 64-bit GNU/Linux OSes med glibc 2.27/musl 1.2.3 og nyere.
- `osx-arm64` virker på 64-bit ARM-basert (Apple silicon) macOS OSer i versjon 13 og nyere.
- `osx-x64` fungerer på 64-biters macOS OSer i versjon 15 og nyere.
- `win-arm64` fungerer på **oppdatert** 64-bit ARM-basert (ARMv8+) Windows OSer i versjon 10, 11 og nyere.
- `win-x64` fungerer på **oppdatert** 64-bit Windows OSer i versjon 10, 11, Server 2016+ og nyere.

Selvsagt selv om du ikke har OS-spesifikk pakke tilgjengelig for din OS-arkitektur kombinasjon, kan du alltid installere riktig. ET løpe selv og kjør generisk ASF-smak, som også er hovedårsaken til at det finnes på første plass. Generisk ASF-bygg er plattform-agnostisk og skal gå på alle plattformer som har en arbeidstid. Dette er viktig for å notere - ASF krever .NET kjøretid, ikke noen bestemt OS eller arkitektur. For eksempel, hvis du kjører 32-bit Windows, til tross for ingen dedikert `win-x86` ASF-versjon, kan du fortsatt installere . ET SDK i `win-x86` versjon og kjøre generisk ASF helt fint. Vi kan rett og slett ikke mål noen OS-arkitektur kombinasjon som finnes og brukes av noen andre, så vi må avgrense et sted. x86 er et godt eksempel på den linjen, siden den er foreldet arkitektur siden minst 2004.

For en fullstendig liste over alle støttede plattformer og OSer ved hjelp av .NET 10.0, besøk **[release notes](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md)**.

---

## Krav til kjøretid

Hvis du bruker OS-spesifikk pakke, er det ikke nødvendig å bekymre deg for gjeldende kjøretidskrav. fordi ASF alltid fører med nødvendig og oppdatert rulletid som fungerer riktig så lenge du har **[. ET-forutsetninger](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** er installert og oppdatert. Med andre ord, **trenger du ikke installere . ET kjøretid eller SDK**, som OS-spesifikke bygninger krever bare vanlige OS-avhengigheter (forutsetninger) og ingenting annet.

Hvis du derimot prøver å kjøre **generisk** ASF-pakke, må du forsikre deg om at din .NET kjøretid støtter plattformen som kreves av ASF.

ASF som program retter seg mot **.NET 10.0** (`net10.`) akkurat nå, men det kan i fremtiden bli rettet mot nyere plattform. `net10.0` støttes siden 10.0.100 SDK (10.0. kjøringstid), selv om ASF kan foretrekke **siste løpetid ved kompilering**, så du bør sikre at du har **[siste SDK](https://dotnet.microsoft.com/download)** (eller i det minste kjøretid) som er tilgjengelig for maskinen. Generisk ASF-variant kan nekte å starte hvis runtiden din er eldre enn det angitte minstestøtten som er støttet under kompilering.

Hvis i tvil, sjekk hva vår **[kontinuerlig integrasjon bruker](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** for kompilering og distribusjon av ASF-utgivelser på GitHub. Du kan finne `dotnet --info` utgang i alle versjoner som en del av .NET verifiseringstrinn.