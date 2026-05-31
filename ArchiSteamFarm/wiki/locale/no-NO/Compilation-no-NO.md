# Kompilering

Beregning er prosessen med å opprette kjørbar fil. Dette er hva du vil gjøre hvis du vil legge til dine egne endringer i ASF, eller hvis du av hvilken som helst grunn ikke stoler på kjørbare filer gitt i **[utgivelser](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**. Hvis du er bruker og ikke en utvikler, vil du mest sannsynlig bruke allerede komprimerte binærer, men hvis du ønsker å bruke dine egne eller lære noe nytt, kan du fortsette å lese.

ASF kan bygges opp på en hvilken som helst plattform som er støttet så lenge dere har alle nødvendige verktøy for å gjøre det.

---

## .NET SDK

Uavhengig av plattform trenger du full .NET SDK (ikke bare kjøretid) for å kompilere ASF. Installasjonsinstruksjoner finnes på **[.NET nedlastingsside](https://dotnet.microsoft.com/download)**. Du må installere passende .NET SDK versjon for ditt OS. Etter en vellykket installasjon bør `dotnet` -kommandoen være fungerende og operativ. Du kan verifisere om det fungerer med `dotnet --info`. Sørg også for at din .NET SDK samsvarer med ASF **[kjøretidskravene](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## Kompilering

Forutsatt at du har .NET SDK operative og i egnet versjon, bare naviger til kildekenda ASF-mappe (klonet eller lastet ned og pakket ut ASF-repo) og kjører:

```shell
dotnet publisere ArchiSteamFarm -c "Release" -o "ut/generisk"
```

Hvis du bruker Linux/macOS, kan du istedet bruke `cc.sh` skript, som vil gjøre det samme, på en litt mer kompleks måte.

Hvis kompileringen var vellykket, kan du finne din ASF i `kilde` -smak i `ut/generisk` -mappen. Dette er det samme som det offisielle `generiske` ASF-bygget, men den har tvunget `UpdateChannel` og `UpdatePeriod` av `0`, som egner seg for selvbygninger.

### OS-spesifikk

Du kan også generere OS-spesifikk .NET pakke hvis du har et spesifikt behov. Generelt bør du ikke gjøre det fordi du nettopp har kompilert `generisk` -smak som du kan kjøre med allerede installerte din . ET kjøretid som du har brukt for kompileringen i første plass, men bare i tilfelle du ønsker å:

```shell
dotnet publisere ArchiSteamFarm -c "Release" -o "out/linux-x64" -r "linux-x64" --self-contained
```

Erstatter selvsagt `linux-x64` med OS-arkitektur som du ønsker å måle, for eksempel `win-x64`. Denne versjonen vil også bli deaktivert oppdateringer. Når du bygger `selv inneholdt` kan du også eventuelt deklarere to flere brytere: `-p:PublishTrimmed=true` vil produsere trimmet bygning, mens `-p:PublishSingleFile=true` produserer en enkelt fil. Å legge til begge disse resultatene vil resultere i de samme innstillingene som vi bruker for våre egne bygg.

### ASF-ui

While the above steps are everything that is required to have a fully working build of ASF, you may *also* be interested in building **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, our graphical web interface. Fra ASF-side vil alt du trenger å gjøre er å slippe ASF-ui build output i standard `ASF-ui/dist` plassering, så bygg ASF med den (igjen, om nødvendig).

ASF-ui er del av ASFs kildetre som en **[git undermodul](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, sikre at du har klonet repo med `git clone --rekursiv`, da du ellers ikke har de nødvendige filene. Du trenger også en fungerende NPM, **[Node.js](https://nodejs.org)** kommer med den. Hvis du bruker Linux/macOS, anbefaler vi at du anbefaler `cc. h` skript, som automatisk vil dekke bygging og frakt ASF-ui (hvis mulig, det er, dersom du oppfyller kravene vi nettopp har nevnt).

I tillegg til `cc. h` skript, vi legger også frem forenklede byggeinstruksjoner under. referer til **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** for ytterligere dokumentasjon. Fra ASFs kildetre plassering, slik som ovenfor, kan du utføre følgende kommandoer:

```shell
rm -rf "ASF-ui/dist" # ASF-ui er ikke ren selv etter gammel versjon

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # Bare sikker på at vår utdata er ren av de gamle filene
dotnet publiserer ArchiSteamFarm -c "Release" -o "ut/generic" # Eller det du trenger som du trenger av de ovennevnte filene ovenfor
```

Du burde nå kunne finne ASF-ui-filene i `ut/generic/www` mappen. ASF vil kunne ha disse filene til nettleseren din.

Alternativt kan du bare bygge ASF-ui, enten det er manuelt eller ved hjelp av våre repo, kopier deretter utdataen over til `${OUT}/www` mappen manuelt, der `${OUT}` er utgangsmappen i ASF som du har angitt med `-o` -parameteren. Det er akkurat hva ASF gjør som en del av byggeprosessen, den kopierer `ASF-ui/dist` (hvis den finnes) over til `${OUT}/www`, ingenting spesielt, og kan også utføres etter bygging, da du kan se, hvis nødvendig.

---

## Utvikling

Hvis du ønsker å redigere ASF-kode, kan du bruke hvilken som helst. ET-tabel IDE for dette formålet, selv om det er valgfritt, siden du også kan redigere med en notepad og kompilere med `dotnet` kommandoen beskrevet ovenfor.

Hvis du ikke har en bedre velge, vi kan anbefale **[JetBrains Rider](https://www.jetbrains.com/rider)** og **[Visual Studio Code](https://code.visualstudio.com/download)**der man først er foretrukket IDE at ASF-teamet benytter seg personlig og det andre er levedyktig alternativ. Begge programmene er plattformer og tilgjengelig på Linux, macOS og Windows.

---

## Tagger

`main` grenen er ikke garantert å være i en tilstand som tillater vellykket kompilering eller feilfri ASF-utførelse på førsteplassen. siden det er utviklingsgrenen akkurat som det er oppgitt i vår **[utløsersyklus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. Hvis du ønsker å sette sammen eller referere ASF fra kilden, så bør du bruke passende **[tag](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** for det formålet, hvilken garanterer at kompileringen er minst vellykket, og som med stor sannsynlighet også feilfri utførelse (hvis bygningen er markert som stabil løsning). For å sjekke dagens "helse" av treet kan du bruke vår CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Offisielle utslipp

Offisielle ASF-utgivelser kompileres av **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, med siste . ET SDK som samsvarer med ASF **[kjøretidskrav](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. Etter passering settes alle pakker ut som frigivelse, også på GitHub. Dette sikrer også gjennomsiktighet, siden GitHub alltid bruker offisiell offentlig kilde for alle bygg, og du kan sammenligne kontrollgrupper på GitHub artifakter med GitHub utsendingseiendeler. ASF-utviklere kompilerer eller publiserer ikke selv, bortsett fra privat utviklingsprosess og feilsøking.

I tillegg til det overstående vedlikeholder ASF manuelt validere og publiserer byggekontroll på uavhengig av GitHub, ekstern ASF-tjener, som ekstra sikkerhetstiltak. Dette trinnet er obligatorisk for eksisterende ASF-er å vurdere utgivelsen som en gyldig kandidat for automatisk oppdatering av funksjonalitet.