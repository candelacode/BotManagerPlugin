# Compilatie

Compilatie is het proces van het maken van uitvoerbaar bestand. Dit is wat je wilt doen als je je eigen wijzigingen wilt toevoegen aan ASF, of als je om welke reden dan ook geen uitvoerbare bestanden vertrouwt die geleverd worden in officiële **[releases](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**. Als je een gebruiker bent en geen ontwikkelaar, wil je waarschijnlijk al vooraf gecompileerde binaries gebruiken maar als je zelf iets nieuws wil leren, ga dan verder met lezen.

ASF kan op elk momenteel ondersteund platform gecompileerd worden, zolang je maar alle benodigde gereedschappen hebt.

---

## .NET SDK

Ongeacht platform heb je volledige .NET SDK nodig (niet alleen runtime) om ASF te compileren. Installatie-instructies zijn te vinden op **[.NET downloadpagina](https://dotnet.microsoft.com/download)**. Je moet de juiste .NET SDK versie installeren voor je besturingssysteem. Na een succesvolle installatie moet `dotnet` commando werken en werken. Je kunt controleren of het werkt met `dotnet --info`. Zorg er ook voor dat uw .NET SDK overeenkomt met ASF **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## Compilatie

Ervan uitgaande dat je .NET SDK operationeel en in de juiste versie hebt, navigeer simpelweg naar de bron ASF map (gekloond of gedownload en uitgepakt ASF repo) en voer het volgende uit:

```shell
dotnet publiceren ArchiSteamFarm -c "Release" -o "out/generic"
```

Als u Linux/macOS gebruikt, kunt u in plaats daarvan `cc.sh` script gebruiken dat hetzelfde zal doen, op een iets complexere manier.

Als de compilatie succesvol is beëindigd, kunt u uw ASF vinden in `source` smaak in `out/generic` map. Dit is hetzelfde als officiële `generieke` ASF build, maar het heeft `UpdateChannel` en `UpdatePeriode` van `0`geforceerd, die geschikt is voor zelfconstructies.

### OS-specifiek

Je kan ook een OS-specifiek .NET-pakket genereren als je een specifieke behoefte hebt. In het algemeen moet je dat niet doen omdat je zojuist een algemene `` smaken hebt gecompileerd die je kunt uitvoeren met de al geïnstalleerde versie. ET runtime die je hebt gebruikt voor de compilatie op de eerste plek, maar voor het geval je wilt:

```shell
dotnet publiceren ArchiSteamFarm -c "Release" -o "out/linux-x64" -r "linux-x64" --self-contained
```

Vervang natuurlijk `linux-x64` door OS-architectuur waar je op wil schieten, zoals `win-x64`. Voor deze build zijn updates uitgeschakeld. Bij het bouwen van `--zelf-ingesloten` kunt u optioneel nog twee schakelaars extra declareren: `-p:PublishTrimmed=true` zal een verkleinde versie maken, terwijl `-p:PublishSingle=true` een enkel bestand produceert. Het toevoegen van beide zal resulteren in dezelfde instellingen die we gebruiken voor onze eigen builds.

### ASF-ui

Terwijl de bovenstaande stappen alles zijn wat nodig is om een volledig werkende bouw van ASF te hebben je kunt *ook* interesseren voor het bouwen van **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, onze grafische webinterface. Van ASF kant alles wat je hoeft te doen is ASF-ui build-uitvoer laten vallen in standaard `ASF-ui/dist` locatie, bouw er dan ASF mee (opnieuw, indien nodig).

ASF-ui maakt deel uit van de ASF's bronboom als een **[git submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, zorg ervoor dat je de repo met `git clone --recursief`hebt gekloond omdat je anders niet de vereiste bestanden hebt. Je hebt ook een werkende NPM, **[Node.js](https://nodejs.org)** nodig. Als u Linux/macOS gebruikt, raden we onze `cc. h` script, deze dekt automatisch het bouwen en verzenden van ASF-ui (indien mogelijk, dat wil zeggen, als je voldoet aan de vereisten die we zojuist hebben genoemd).

Naast de `cc. h` script, we voegen ook de onderstaande vereenvoudigde build instructies toe verwijs naar **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** voor aanvullende documentatie. Voer de volgende opdrachten uit van ASF's bronlocatie voor de boomstructuur zoals hierboven:

```shell
rm -rf "ASF-ui/dist" # ASF-ui wordt niet opgeruimd na oude build

npm ci --prefix ASF-ui
npm run-script-deploy --prefix ASF-ui

rm -rf "out/generic/www" # Zorg ervoor dat onze build-output schoon is van de oude bestanden
dotnet publiceren ArchiSteamFarm -c "Release" -o "out/generic" # Of daarnaar wat u nodig heeft in bovenstaande bestanden
```

Je moet nu de ASF-ui bestanden kunnen vinden in je `out/generic/www` map. ASF kan deze bestanden gebruiken voor je browser.

Als alternatief kun je gewoon ASF-ui bouwen, zij het handmatig of met behulp van onze repo, en kopieer de build uitvoer naar `${OUT}/www` map handmatig, waar `${OUT}` de uitvoer map van ASF is die je hebt opgegeven met `-o` parameter. Dit is precies wat ASF doet als onderdeel van het bouwproces, het kopieert `ASF-ui/dist` (indien aanwezig) over naar `${OUT}/www`, niets bijzonders en kan ook worden gedaan na de bouw zoals u kunt zien, als dat nodig is.

---

## Ontwikkeling

Als je de ASF-code wilt bewerken, kun je die gebruiken. ET compatibele IDE voor dat doel, hoewel zelfs dat optioneel, omdat je net zo goed kunt bewerken met een kladblok en compileren met `dotnet` commando hierboven beschreven.

Als je geen betere keuze hebt, we kunnen **[JetBrains Rider](https://www.jetbrains.com/rider)** en **[Visual Studio](https://code.visualstudio.com/download)**aanbevelen, de eerste is de beste IDE die het ASF-team persoonlijk gebruikt, en de tweede is een levensvatbaar alternatief. Beide programma's zijn cross-platform en beschikbaar op Linux, macOS en Windows.

---

## Labels

`main` branch is niet gegarandeerd in een staat die een succesvolle compilatie of een onvolmaakte uitvoering van ASF toestaat, omdat het net als in onze **[releasecyclus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** is. Als je ASF wilt compileren of gebruiken vanaf de bron, dan moet je de juiste **[tag](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** voor dat doel gebruiken. die op zijn minst een succesvolle compilatie garandeert, en waarschijnlijk ook een foutieve uitvoering (als build was gemarkeerd als stabiele release). Om de huidige "gezondheid" van de boom te controleren, kunt u onze CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)** gebruiken.

---

## Officiële releases

Officiële ASF-releases worden gecompileerd door **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, met de nieuwste . ET SDK dat overeenkomt met ASF **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. Na het passeren van de tests worden alle pakketten gebruikt als de release, ook op GitHub. Dit garandeert ook transparantie, omdat GitHub altijd de officiële publieke bron gebruikt voor alle builds en u kunt checksums van GitHub artefacten vergelijken met GitHub release assets. De ASF-ontwikkelaars compileren en publiceren zelf geen versies, behalve voor privé ontwikkeling en foutopsporing.

In aanvulling op het bovenstaande, onderhoudt ASF als extra veiligheidsmaatregel de bouwbedragen handmatig valideren en publiceren op de build checksums op onafhankelijke GitHub, externe ASF-server. Deze stap is verplicht om bestaande ASF's de release te beschouwen als een geldige kandidaat voor de auto-update-functionaliteit.