# Kompilering

Kompilering er processen med at oprette eksekverbar fil. Dette er, hvad du ønsker at gøre, hvis du ønsker at tilføje dine egne ændringer til ASF eller hvis du af en eller anden grund ikke stoler på eksekverbare filer i officielle **[udgiver](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**. Hvis du er bruger og ikke udvikler, mest sandsynligt du ønsker at bruge allerede prækompilerede binære filer, men hvis du gerne vil bruge dine egne, eller lære noget nyt, fortsæt med at læse.

ASF kan kompileres på enhver aktuelt understøttet platform, så længe du har alle nødvendige værktøjer til at gøre det.

---

## .NET SDK

Uanset platform, du har brug for fuld .NET SDK (ikke bare runtime) for at kompilere ASF. Installationsinstruktioner kan findes på **[.NET download side](https://dotnet.microsoft.com/download)**. Du skal installere passende .NET SDK version til dit operativsystem. Kommandoen `dotnet` skal fungere og fungere efter en vellykket installation. Du kan bekræfte, om det virker med `dotnet --info`. Sørg også for at dine .NET SDK matcher ASF **[runtime krav](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## Kompilering

Forudsat at du har .NET SDK operative og i passende version, blot navigere til kilde ASF mappe (klonet eller downloadet og udpakkede ASF repo) og udføre:

```shell
dotnet publicere ArchiSteamFarm -c "Release" -o "out/generisk"
```

Hvis du bruger Linux/macOS, kan du i stedet bruge `cc.sh` script, som vil gøre det samme, på en lidt mere kompleks måde.

Hvis kompileringen er afsluttet, kan du finde din ASF i `kilde` smag i `out/generic` mappe. Dette er det samme som officielle `generisk` ASF build, men det har tvunget `UpdateChannel` og `UpdatePeriod` af `0`, som er egnet til selvopbygning.

### OS-specifik

Du kan også generere OS-specifik .NET pakke, hvis du har et specifikt behov. Generelt bør du ikke gøre det, fordi du lige har kompileret `generisk` smag, som du kan køre med din allerede installerede . ET runtime, som du har brugt til kompileringen i første omgang, men bare hvis du vil:

```shell
dotnet publicere ArchiSteamFarm -c "Release" -o "out/linux-x64" -r "linux-x64" --self-contained
```

Selvfølgelig erstatte `linux-x64` med OS-arkitektur, som du ønsker at målrette, såsom `win-x64`. Denne build vil også have opdateringer deaktiveret. Når du bygger `--self-contained` kan du også eventuelt erklære yderligere to switches: `-p:PublishTrimmed=true` vil producere trimmet build, mens `-p: PublishSingleFile=true` vil producere en enkelt fil. Tilføjelse af begge vil resultere i de samme indstillinger, som vi bruger for vores egne bygninger.

### ASF-ui

Mens ovenstående trin er alt, hvad der kræves for at have en fuldt fungerende ASF du kan *også* være interesseret i at bygge **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, vores grafiske webgrænseflade. Fra ASF side, alt hvad du behøver at gøre, er at slippe ASF-ui build output i standard `ASF-ui/dist` placering, derefter bygge ASF med det (igen, hvis nødvendigt).

ASF-ui er en del af ASF's kildetræ som **[git undermodul](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, sikre, at du har klonet repo med `git clone --rekursive`, da ellers vil du ikke have de nødvendige filer. Du har også brug for en fungerende NPM, **[Node.js](https://nodejs.org)** kommer med det. Hvis du bruger Linux/macOS, anbefaler vi vores `cc. h` script, som automatisk vil dække bygning og forsendelse ASF-ui (hvis muligt, det vil sige, hvis du opfylder de krav, vi lige har nævnt).

Ud over `cc. h` -script, vi vedhæfter også de forenklede byggeinstruktioner nedenfor, henviser til **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** for yderligere dokumentation. Fra ASF's kilde træ placering, så som ovenfor, eksekvere følgende kommandoer:

```shell
rm -rf "ASF-ui/dist" # ASF-ui ikke rense sig selv efter gamle bygge

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generisk/www" # Sørg for, at vores bygge output er ren af de gamle filer
dotnet udgiver ArchiSteamFarm -c "Release" -o "out/generisk" # Eller i overensstemmelse hermed til hvad du har brug for som pr ovenstående
```

Du bør nu være i stand til at finde ASF-ui filer i din `ud/generisk/www` mappe. ASF vil være i stand til at tjene disse filer til din browser.

Alternativt kan du blot bygge ASF-ui, enten manuelt eller ved hjælp af vores repo, derefter kopiere build output over til `${OUT}/ www` mappe manuelt, Hvor `${OUT}` er outputmappen for ASF, som du har angivet med `-o` parameter. Det er præcis, hvad ASF gør som en del af byggeprocessen kopierer `ASF-ui/dist` (hvis findes) over til `${OUT}/www`intet særligt, og kan også gøres efter bygge som du kan se, om nødvendigt.

---

## Udvikling

Hvis du vil redigere ASF-kode, kan du bruge en hvilken som helst . ET-kompatibel IDE til dette formål, selv om dette er fakultativt da du også kan redigere med en notesblok og kompilere med kommandoen `dotnet` beskrevet ovenfor.

Hvis du ikke har et bedre valg, Vi kan anbefale **[JetBrains Rider](https://www.jetbrains.com/rider)** og **[Visual Studio Code](https://code.visualstudio.com/download)**, med den første er den foretrukne IDE, at ASF team er personligt bruger, og den anden er levedygtige alternativ. Begge programmer er cross-platform og tilgængelige på Linux, macOS og Windows.

---

## Mærker

`hovedafdeling af` er ikke garanteret at være i en tilstand, der tillader vellykket kompilering eller fejlfri udførelse af ASF i første omgang, da det er udviklingsgren ligesom angivet i vores **[release cycle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. Hvis du ønsker at kompilere eller referere ASF fra kilden, så skal du bruge passende **[tag](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** til dette formål. som garanterer i det mindste vellykket kompilering, og meget sandsynligt også fejlfri udførelse (hvis bygge blev markeret som stabil udgivelse). For at tjekke den aktuelle "sundhed" af træet, kan du bruge vores CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Officielle udgivelser

Officielle ASF udgivelser er udarbejdet af **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, med seneste . ET SDK , der matcher ASF **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. Efter at have bestået tests, er alle pakker implementeret som udgivelsen, også på GitHub. Dette garanterer også gennemsigtighed, da GitHub altid bruger officielle offentlige kilder til alle bygninger, og du kan sammenligne checksums af GitHub artefakter med GitHub release aktiver. ASF udviklere ikke kompilere eller udgive bygger sig selv, undtagen for private udviklingsproces og fejlfinding.

Ud over ovenstående validerer ASF-vedligeholdere manuelt og offentliggør kontrolsummer uafhængigt af GitHub, ekstern ASF-server, som yderligere sikkerhedsforanstaltning. Dette trin er obligatorisk for eksisterende ASF'er at betragte udgivelsen som en gyldig kandidat til auto-opdatering funktionalitet.