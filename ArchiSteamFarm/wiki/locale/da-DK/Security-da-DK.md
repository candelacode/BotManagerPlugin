# Sikkerhed

## Kryptering

ASF understøtter i øjeblikket følgende krypteringsmetoder som en definition af `ECryptoMethod`:

| Værdi | Navn                        |
| ----- | --------------------------- |
| 0     | PlainText                   |
| 1     | AES                         |
| 2     | ProtectedDataForCurrentUser |
| 3     | EnvironmentVariable         |
| 4     | Fil                         |

Den nøjagtige beskrivelse og sammenligning af dem er tilgængelig nedenfor.

### Opsætning

For at generere krypteret adgangskode, f.eks. for brug af `SteamPassword` , du bør udføre `kryptere` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** med den passende kryptering, du valgte, og din oprindelige almindelig tekst adgangskode. Bagefter, læg den krypterede streng, som du har fået som `SteamPassword` bot config egenskab, og endelig ændre `PasswordFormat` til den, der matcher din valgte krypteringsmetode. Nogle formater kræver ikke `kryptere` -kommando, for eksempel `EnvironmentVariable` eller `File`, bare sætte passende sti til dem.

---

### `PlainText`

Dette er den mest enkle og usikre måde at gemme en adgangskode, defineret som `ECryptoMethod` af `0`. ASF forventer, at strengen er en almindelig tekst - en adgangskode i sin direkte form. Det er den nemmeste at bruge, og 100% kompatibel med alle opsætninger, derfor er det en standard måde at gemme hemmeligheder, helt usikker for sikker opbevaring.

---

### `AES`

Betragtes sikkert i dag standarder, **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** måde at gemme adgangskoden på er defineret som `ECryptoMethod` af `1`. ASF forventer, at strengen er en **[base64-kodet](https://en.wikipedia.org/wiki/Base64)** sekvens af tegn, der resulterer i AES-krypteret byte array efter oversættelse, som derefter skal dekrypteres ved hjælp af inkluderet **[initialisering vector](https://en.wikipedia.org/wiki/Initialization_vector)** og ASF krypteringsnøgle.

Metoden ovenfor garanterer sikkerhed, så længe angriberen ikke kender ASF krypteringsnøgle, der bruges til dekryptering samt kryptering af adgangskoder. ASF giver dig mulighed for at angive nøgle via `--cryptkey` **[kommandolinje argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, som du skal bruge for maksimal sikkerhed. Hvis du beslutter dig for at udelade det, vil ASF bruge sin egen nøgle, som er **kendt** og hardcoded i applikationen betydning nogen kan vende ASF kryptering og få dekrypteret adgangskode. Det kræver stadig en indsats og er ikke så let at gøre, men muligt Derfor bør du næsten altid bruge `AES` -kryptering med din egen `--cryptkey` , som holdes i hemmelighed. AES metode, der anvendes i ASF giver sikkerhed, der bør være tilfredsstillende, og det er en balance mellem enkelhed af `almindelig tekst` og kompleksiteten af `ProtectedDataForCurrentUser`, men det anbefales stærkt at bruge det med brugerdefineret `--cryptkey`.

Hvis brugt korrekt (lang, brugerdefineret `--cryptkey`), garanterer meget høj sikkerhed for sikker opbevaring.

---

### `ProtectedDataForCurrentUser`

Betragtes sikkert i dag standarder, **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** måde at gemme adgangskoden er defineret som `ECryptoMethod` af `2`. Den største fordel ved denne metode er samtidig den største ulempe - i stedet for at bruge krypteringsnøgle (som i `AES`), data krypteres ved hjælp af loginoplysninger fra bruger, der er logget ind hvilket betyder, at det er muligt at dekryptere data **kun** på den maskine, det blev krypteret på, **kun** af den bruger, der har udstedt krypteringen.

Dette sikrer, at selv hvis du sender hele din `Bot. Søn` med krypteret `SteamPassword` ved hjælp af denne metode til andre de vil ikke være i stand til at dekryptere adgangskoden uden direkte adgang til din PC. Det er en fremragende sikkerhedsforanstaltning, men samtidig en stor ulempe ved at være mindst kompatibel - da adgangskoden krypteret med denne metode vil være inkompatibel med enhver anden bruger samt maskine - herunder **din egen** , hvis du beslutter dig for at e. . geninstaller dit operativsystem. Dette er den anbefalede metode, hvis du ikke behøver at få adgang til dine konfigurationer fra nogen anden maskine end din egen, og at du heller ikke har brug for cross-machine kompatibilitet.

**Bemærk venligst, at denne mulighed kun er tilgængelig for maskiner, der kører Windows OS fra nu.**

---

### `EnvironmentVariable`

Hukommelsesbaseret lagring defineret som `ECryptoMethod` of `3`. ASF vil læse adgangskoden fra miljøvariablen med givet navn angivet i adgangskodefeltet (f.eks. `SteamPassword`). For eksempel indstilling af `SteamPassword` til `ASF_PASSWORD_MYACCOUNT` og `PasswordFormat` til `3` vil få ASF til at evaluere `${ASF_PASSWORD_MYACCOUNT}` miljøvariablen og bruge hvad der er tildelt den som kontoadgangskode.

Husk at sikre, at miljøvariabler i ASF-processen ikke er tilgængelige for uautoriserede brugere da det ødelægger hele formålet med denne metode.

---

### `Fil`

Filbaseret lagring (muligvis uden for ASF config directory) defineret som `ECryptoMethod` af `4`. ASF vil læse adgangskoden fra den filsti, der er angivet i adgangskodefeltet (f.eks. `SteamPassword`). Den angivne sti kan være enten absolute, eller relativt til ASF's "hjem" placering (mappen med `config` mappe inde, under hensyntagen til `--path` **[kommandolinje argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). Denne metode kan bruges for eksempel med **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**, som skaber sådanne filer til brug, men kan også bruges uden for Docker, hvis du opretter passende fil selv. Indstilling af `SteamPassword` til `/etc/secrets/MyAccount. ass` og `PasswordFormat` til `4` vil få ASF til at læse `/etc/secrets/MyAccount. ass` og brug hvad der er skrevet til filen som kontoadgangskode.

Husk at sikre, at filen som indeholder adgangskoden ikke kan læses af uautoriserede brugere, da det ødelægger hele formålet med at bruge denne metode.

---

## Kryptering anbefalinger

Hvis kompatibilitet ikke er et problem for dig, og du er fint med den måde, hvordan `ProtectedDataForCurrentUser` metode virker, det er den **anbefalede** mulighed for at gemme adgangskoden i ASF, da det giver den bedste sikkerhed og bekvemmelighed. `AES` metode er et godt valg for folk, der stadig ønsker at gøre brug af deres configs på enhver maskine, de ønsker, mens `PlainText` er den mest enkle måde at gemme adgangskoden på, hvis du ikke har noget imod, at nogen kan se ind i JSON konfigurationsfil for det.

Husk på, at alle krypteringsmetoder betragtes som **usikre** , hvis angriberen har adgang til din pc. ASF skal være i stand til at dekryptere de krypterede adgangskoder, og hvis programmet kører på din maskine er i stand til at gøre det, så ethvert andet program, der kører på den samme maskine vil være i stand til at gøre det, også. `ProtectedDataForCurrentUser` er den mest sikre variant som **selv anden bruger med den samme pc vil ikke være i stand til at dekryptere det**, men det er stadig muligt at dekryptere data, hvis nogen er i stand til at stjæle dine loginoplysninger og machine info i tillæg til ASF config fil.

For avancerede opsætninger kan du bruge `EnvironmentVariable` og `File`. De har begrænset anvendelighed — `EnvironmentVariable` vil være en god idé, hvis du foretrækker at få adgangskode gennem en eller anden form for brugerdefineret løsning og gemme den udelukkende i hukommelsen. mens `File` er god for eksempel med **[Docker hemmeligheder](https://docs.docker.com/engine/swarm/secrets)**. Begge af dem er ukrypteret dog, så du dybest set flytte risikoen fra ASF config fil til hvad du vælger fra disse to.

Ud over de krypteringsmetoder, der er angivet ovenfor, er det muligt også at undgå at angive adgangskoder helt, for eksempel som `SteamPassword` ved at bruge en tom streng eller `null` værdi. ASF vil bede dig om din adgangskode, når det er påkrævet. og vil ikke gemme det hvor som helst, men holde i hukommelsen af aktuelt kørende proces, indtil du lukker det. Mens de er den mest sikre metode til håndtering af adgangskoder (de er ikke gemt nogen steder), det er også det mest besværlige, da du skal indtaste din adgangskode manuelt på hver ASF kørsel (når det er påkrævet). Hvis det ikke er et problem for dig, er dette din bedste satsning på sikkerhed-klog, da du ikke kan lække noget, der ikke eksisterer.

---

## Dekryptering

ASF understøtter ikke nogen måde at dekryptere allerede krypterede adgangskoder, som dekryptering metoder bruges kun internt til at få adgang til data inde i processen. Hvis du ønsker at vende tilbage krypteringsprocedure f.eks. for at flytte ASF til anden maskine, når du bruger `ProtectedDataForCurrentUser`, og derefter blot gentage proceduren fra begyndelsen i det nye miljø.

---

## Hasket

ASF understøtter i øjeblikket følgende hashingmetoder som en definition af `EHashingMethod`:

| Værdi | Navn      |
| ----- | --------- |
| 0     | PlainText |
| 1     | SCrypter  |
| 2     | Pbkdf2    |

Den nøjagtige beskrivelse og sammenligning af dem er tilgængelig nedenfor.

### Opsætning

For at generere en hash, f.eks. for brug af `IPCPassword` du bør udføre `hash` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** med den passende hashing metode, du valgte, og din oprindelige almindelig tekst adgangskode. Sæt derefter den hashede streng, som du har fået som `IPCPassword` ASF config property, og endelig ændre `IPCPasswordFormat` til den, der matcher din valgte hashingmetode.

---

### `PlainText`

Dette er den mest enkle og usikre måde at hashing en adgangskode, defineret som `EHashingMethod` af `0`. ASF vil generere hash, der matcher det oprindelige input. Det er den nemmeste at bruge, og 100% kompatibel med alle opsætninger, derfor er det en standard måde at gemme hemmeligheder, helt usikker for sikker opbevaring.

---

### `SCrypter`

Betragtes sikkert i dag standarder, **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** måde at hashing adgangskoden er defineret som `EHashingMethod` af `1`. ASF vil bruge `SCrypt` -implementeringen ved hjælp af `8` -blokke, `8192` iterationer, `32` hash længde og krypteringsnøgle som et salt for at generere en række bytes. De resulterende bytes vil derefter blive kodet som **[base64](https://en.wikipedia.org/wiki/Base64)** streng.

ASF giver dig mulighed for at angive salt for denne metode via `--cryptkey` **[kommandolinjeargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, som du skal bruge for maksimal sikkerhed. Hvis du beslutter dig for at udelade det, vil ASF bruge sin egen nøgle, som er **kendt** og hardcoded i applikationen at hashing vil være mindre sikker.

Hvis brugt korrekt (brugerdefineret salt, lang adgangskode), garanterer meget høj sikkerhed for sikker opbevaring.

---

### `Pbkdf2`

Betragtes svag af standarder i dag **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** -måden at hashe adgangskoden er defineret som `EHashingMethod` af `2`. ASF vil bruge `Pbkdf2` implementeringen ved hjælp af `10000` iterationer, `32` hash længde og krypteringsnøgle som salt, med `SHA-256` som en hmac algoritme. De resulterende bytes vil derefter blive kodet som **[base64](https://en.wikipedia.org/wiki/Base64)** streng.

ASF giver dig mulighed for at angive salt for denne metode via `--cryptkey` **[kommandolinjeargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, som du skal bruge for maksimal sikkerhed. Hvis du beslutter dig for at udelade det, vil ASF bruge sin egen nøgle, som er **kendt** og hardcoded i applikationen at hashing vil være mindre sikker.

---

## Hashing anbefalinger

Hvis du vil bruge en hashingmetode til at gemme nogle hemmeligheder, såsom `IPCPassword`, Vi anbefaler at bruge `SCrypt` med brugerdefineret salt, da det giver en meget anstændig sikkerhed mod brute-tvinger forsøg.

`Pbkdf2` tilbydes kun af forenelighedsgrunde primært fordi vi allerede har en fungerende (og nødvendigt) implementering af den til andre brugstilfælde på Steam-platformen (f. eks. . forældrenes pins). Den anses stadig for sikker, men svag i forhold til alternativer (f.eks. `SCrypt`).