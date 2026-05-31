# Kompilering

Sammanställning är processen för att skapa körbar fil. Detta är vad du vill göra om du vill lägga till dina egna ändringar till ASF, eller om du av någon anledning inte litar på körbara filer som finns i officiella **[släpper](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**. Om du är användare och inte en utvecklare, troligen vill du använda redan förkompilerade binärer, men om du vill använda dina egna, eller lära dig något nytt, fortsätt läsa.

ASF kan kompileras på vilken plattform som helst, så länge du har alla nödvändiga verktyg för att göra det.

---

## .NET SDK

Oavsett plattform, du behöver full .NET SDK (inte bara runtime) för att sammanställa ASF. Installationsinstruktioner finns på **[.NET download page](https://dotnet.microsoft.com/download)**. Du måste installera lämplig .NET SDK-version för ditt OS. Efter lyckad installation, `dotnet` kommando bör fungera och operativ. Du kan verifiera om det fungerar med `dotnet --info`. Se också till att din .NET SDK matchar ASF **[runtime krav](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## Kompilering

Förutsatt att du har .NET SDK operativ och i lämplig version, helt enkelt navigera till källa ASF katalog (klonade eller hämtade och packade ASF repo) och exekvera:

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic"
```

Om du använder Linux/macOS kan du istället använda `cc.sh` skript som kommer att göra samma sak på ett lite mer komplext sätt.

Om sammanställningen slutade framgångsrikt, kan du hitta din ASF i `källa` smak i `ut/generisk` katalog. Detta är samma som officiella `generiska` ASF bygga, men det har tvingat `UpdateChannel` och `UpdatePeriod` av `0`, vilket är lämpligt för självbyggande.

### OS-specifik

Du kan också generera OS-specifika .NET-paket om du har ett specifikt behov. I allmänhet bör du inte göra det eftersom du just har sammanställt `generiska` smak som du kan köra med din redan installerade . ET runtime som du har använt för sammanställningen i första hand, men ifall du vill:

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/linux-x64" -r "linux-x64" --fristående
```

Självklart, byt ut `linux-x64` mot OS-arkitektur som du vill rikta dig, till exempel `win-x64`. Denna version kommer också att ha uppdateringar inaktiverade. När du bygger `--self-contained` kan du också ange ytterligare två växlar: `-p:PublishTrimmed=true` kommer att producera trimmade bygga, medan `-p:PublishSingleFile=true` kommer att producera en enda fil. Att lägga till båda kommer att resultera i samma inställningar som vi använder för våra egna byggnader.

### ASF-ui

Medan ovanstående steg är allt som krävs för att ha en fullt fungerande bygga av ASF, du kan *också* vara intresserad av att bygga **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, vårt grafiska webbgränssnitt. Från ASF sida, allt du behöver göra är att släppa ASF-ui bygga utdata i standard `ASF-ui/dist` plats, sedan bygga ASF med det (igen, om det behövs).

ASF-ui är en del av ASF:s källkodsträd som en **[git-delmodul](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, se till att du har klonat repo med `git-klon --rekursiv`, annars kommer du inte ha de nödvändiga filerna. Du behöver också en fungerande NPM, **[Node.js](https://nodejs.org)** kommer med den. Om du använder Linux/macOS rekommenderar vi vår `cc. h` skript, som automatiskt kommer att omfatta byggnad och frakt ASF-ui (om möjligt, det vill säga om du uppfyller de krav som vi just nämnt).

Förutom `cc. h` script, vi bifogar också de förenklade bygginstruktionerna nedan, se **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** för ytterligare dokumentation. Från ASF: s källkodsträdets plats, så som ovan, kör följande kommandon:

```shell
rm -rf "ASF-ui/dist" # ASF-ui rengör sig inte efter gamla bygget

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # Se till att vår byggproduktion är ren från de gamla filerna
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic" # Eller följaktligen till vad du behöver enligt ovanstående
```

Du bör nu kunna hitta ASF-ui-filerna i din `out/generic/www` -mapp. ASF kommer att kunna tjäna dessa filer till din webbläsare.

Alternativt kan du helt enkelt bygga ASF-ui, antingen manuellt eller med hjälp av vår repa, kopiera sedan utmatningen över till `${OUT}/www` mappen manuellt, där `${OUT}` är utdatamappen för ASF som du har angett med `-o` parameter. Detta är exakt vad ASF gör som en del av byggprocessen, den kopierar `ASF-ui/dist` (om det finns) över till `${OUT}/www`, inget speciellt, och kan också göras efter bygget som du kan se, om det behövs.

---

## Utveckling

Om du vill redigera ASF-koden kan du använda vilken som helst. ET-kompatibel IDE för det ändamålet, även om det är frivilligt, eftersom du lika gärna kan redigera med ett anteckningsblock och kompilera med kommandot `dotnet` som beskrivs ovan.

Om du inte har ett bättre val, vi kan rekommendera **[JetBrains Rider](https://www.jetbrains.com/rider)** och **[Visual Studio Code](https://code.visualstudio.com/download)**, med första en är den föredragna IDE som ASF laget personligen använder, och andra en är livskraftig alternativ. Båda programmen är plattformsoberoende och tillgängliga på Linux, macOS och Windows.

---

## Taggar

`main` gren är inte garanterad att vara i ett tillstånd som tillåter framgångsrik sammanställning eller felfri ASF utförande i första hand, eftersom det är utvecklingsenhet precis som anges i vår **[release cykel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. Om du vill kompilera eller referera ASF från källa, då bör du använda lämplig **[tagg](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** för det ändamålet, vilket garanterar åtminstone lyckad sammanställning, och mycket sannolikt också felfri körning (om bygget markerades som stabil utgåva). För att kontrollera den nuvarande "hälsa" av trädet, kan du använda vår CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Officiella utgåvor

Officiella ASF-utgåvor kompileras av **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, med senaste . ET SDK som matchar ASF **[körtidskrav](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. Efter godkända tester distribueras alla paket som utgåvan, även på GitHub. Detta garanterar också öppenhet, eftersom GitHub alltid använder officiell offentlig källa för alla byggnader, och du kan jämföra kontrollsummor av GitHub artefakter med GitHub release tillgångar. ASF-utvecklare sammanställer eller publicerar inte byggen själva, med undantag för privat utvecklingsprocess och felsökning.

Utöver ovanstående validerar och publicerar ASF-ansvariga manuellt byggkontrollsummor på oberoende från GitHub, fjärransluten ASF-server, som ytterligare säkerhetsåtgärd. Detta steg är obligatoriskt för befintliga ASFs att betrakta utgåvan som en giltig kandidat för automatisk uppdatering funktionalitet.