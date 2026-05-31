# Kommandolinjeargumenter

ASF har støtte for flere kommandolinjeargumenter som kan påvirke programkjøretiden. Disse kan brukes av avanserte brukere for å spesifisere hvordan programmet skal kjøre. I sammenligning med standardmåten for `ASF.json` sin konfigurasjonsfil er kommandolinjeargumenter brukt til kjerneinitialisering (f.eks. `--path`), plattformspesifikke innstillinger (f.eks. `--system-påkrevd`) eller sensitive data (f.eks. `--cryptkey`).

---

## Bruk

Bruk av OS- og ASF-smaken din.

Generisk:

```shell
dotnet ArkiSteamFarm.dll --argument --otherOne
```

Vinduer:

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArkiSteamFarm --argument --otherOne
```

Kommandoargumenter er også støttet i generisk helper skripter som `ArchiSteamFarm.cmd` eller `ArchiSteamFarm.sh`. I tillegg til det, kan du også bruke `ASF_ARGS` -miljøegenskapen, Som nevnt i vår **[styring](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** og **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** avsnitt.

Hvis argumentet ditt inkluderer mellomrom, ikke glem å sitere det. Disse to er feil:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Bad!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Bad!
```

De to er imidlertid helt fine:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Argumenter

`--cryptkey <key>` eller `--cryptkey=<key>` - vil starte ASF med egendefinert kryptografisk nøkkel til `<key>` . verdi. Dette alternativet påvirker **[sikkerhet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** og vil føre til at ASF bruker din egendefinerte gitt `<key>` nøkkel i stedet for som standard er en hardkodet inn i kjørbare. Siden denne egenskapen påvirker standard krypteringsnøkkel (for kryptering av formål) så vel som salt (for hashing formål), husk i tankene at alt kryptert/hashed med denne nøkkelen vil kreve at den videreføres på hvert ASF renner.

Det er ikke noe krav til `<key>` lengde eller tegn, men av sikkerhetsgrunner anbefaler vi å velge lang nok passord ut av tid. . tilfeldige 32 tegn, for eksempel ved å bruke `tr -dc A-Za-z0-9 < /dev/urandom so-head -c 32; echo` kommando i Linux.

Det er fint å nevne at det også er to andre måter å tilby denne detaljene: `--cryptkey-fil` og `--input-cryptkey`.

Grunnet typen av denne egenskapen er det også mulig å sette kryptnøkkel ved å deklarere `ASF_CRYPTKEY` miljøvariabel. noe som kan være mer hensiktsmessig for personer som ønsker å unngå sensitive detaljer i prosessen argumenter.

---

`--cryptkey-fil <path>` eller `--cryptkey-file=<path>` - vil starte ASF med egendefinert kryptografisk nøkkel lest fra `<path>`. Dette tjener samme formål som `--cryptkey <key>` forklart over, bare maskineriet annerledes, siden denne egenskapen vil lese `<key>` fra oppgitt `<path>` i stedet. Hvis du bruker dette sammen med `--path`, vurdere det faktum at den relative banen vil være forskjellig avhengig av argumentenes rekkefølge i.. . enten du bytter `--path` før eller etter `--cryptkey-fil`.

Grunnet typen til denne egenskapen er det også mulig å sette kryptnøkkelfil ved å erklære `ASF_CRYPTKEY_FILE` miljøvariabel. noe som kan være mer hensiktsmessig for personer som ønsker å unngå sensitive detaljer i prosessen argumenter.

---

`- ignorert miljø som ikke støttes,` - vil føre til at ASF ignorerer problemer som oppstår i miljøet som ikke støttes, som vanligvis er signalert med en feil og en tvungen utgang. Ikke støttet miljø inkluderer for eksempel å kjøre `win-x64` OS-spesifikk versjon på `linux-x64`. Mens dette flagget vil tillate ASF å forsøke å kjøre i slike scenarier, anbefales at vi ikke støtter de offisielt og at du tvinger ASF for å gjøre det helt **på eget risiko**. It's important to point out that **all** of the unsupported environment scenarios **can be corrected**. Vi anbefaler på det sterkeste å løse de utestående problemene i stedet for å erklære argumentet.

---

`--input-cryptkey` - vil gjøre ASF om `--cryptkey` under oppstart. Dette alternativet kan være nyttig for deg dersom du i stedet for å tilby cryptkey, enten du har miljøvariabler eller en fil, du foretrekker å ikke ha den lagret noe sted og heller ikke sette den inn manuelt på hver ASF kjører.

---

`- minimert` - vil gjøre ASF-konsollvinduet minimert kort tid etter start. Nyttig hovedsaklig i scenarioer med auto-start men kan også brukes utenfor dette. Dette alternativet krever riktig støtte av miljøet - det fungerer kanskje ikke riktig i alle mulige scenarier.

---

`--network-group <group>` eller `--network-group=<group>` - vil føre til at ASF inni sine grenser med en egendefinert nettverksgruppe `<group>` verdi. Dette alternativet påvirker å kjøre ASF i **[flere forekomster](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** ved å signalisere som gitt eksempel er kun avhengig av forekomster som deler samme nettverksgruppe. og uavhengig av de andre. Vanligvis vil du bare bruke denne egenskapen hvis du router ASF-forespørsler via egendefinerte mekanismer (f.eks. forskjellige IP-adresser) og du vil sette nettverksgrupper selv, selv uten å basere seg på ASF for å gjøre det automatisk (som for øyeblikket tar hensyn til `WebProxy`. Husk at når du bruker en egendefinert nettverksgruppe, er dette unik identifikator i den lokale maskinen, og ASF vil ikke ta hensyn til andre detaljer, slik som `WebProxy` -verdi, slik at du kan det. . Start to tilfeller med ulike `WebProxy` -verdier som fremdeles er avhengige av hverandre.

Grunnet typen av denne egenskapen er det også mulig å sette verdien ved å deklarere `ASF_NETWORK_GROUP` miljøvariabel. noe som kan være mer hensiktsmessig for personer som ønsker å unngå sensitive detaljer i prosessen argumenter.

---

`--no-config-migrate` - som standard ASF vil automatisk migrere konfigurasjonsfilene til siste syntaks. Migrasjon inkluderer konvertering av avskrevne egenskaper til de nyeste, fjerning av egenskaper med standardverdier (som de ikke har noen effekt), i tillegg til å rydde opp i filen generelt (rette innrykk og lignende). Dette er nesten alltid en god idé, men du vil kanskje ha en bestemt situasjon der du aldri foretrekker ASF å overskrive konfigurasjonsfilene automatisk. For eksempel, du vil kanskje `chmod 400` dine konfigurasjonsfiler (lese tillatelse for eieren) eller sette `chattr +i` over dem, resultere i å nekte skrivetilgang for alle, e. . som et sikkerhetstiltak. Vi anbefaler vanligvis å beholde konfigurasjonsoverføringen aktivert, men hvis du har en spesiell grunn til å deaktivere dette og vil i stedet foretrekke at ASF ikke gjør det, du kan bruke denne bryteren for å oppnå den formålet. Husk imidlertid at å sørge for korrekte innstillinger til ASF blir fra nå av et nytt ansvar, særlig når det gjelder avskrivninger og refaktorer av egenskaper i framtidige ASF-versjoner.

---

`--no-config-watch` - som standard ASF setter opp en `FileSystemWatcher` over mappen `config` for å lytte etter hendelser knyttet til filendringer, Den kan interaktivt tilpasse seg dem. For eksempel omfatter dette å stoppe bots på config sletting, omstart av bot på config som endres, eller laste nøkler i **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** så snart du har rundet dem i `config` -mappen. Med denne bryteren kan du deaktivere slik atferd, noe som vil føre til at ASF fullstendig ignorerer alle endringene i `config` -mappen. å kreve fra deg å gjøre slike tiltak manuelt, hvis det anses som hensiktsmessig (som vanligvis betyr omstart av prosessen). Vi anbefaler at du beholder konfigurasjonshendelsene aktivert, men hvis du har en spesiell grunn til å deaktivere dem og heller foretrekker at ASF ikke gjør det, du kan bruke denne bryteren for å oppnå den formålet.

---

`--no-restart` - følger **[`AutoRestart`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#autorestart)** konfigurasjons eiendom, som du kan bruke til å angi om omstart er tillatt ved behov. Noen løsninger som vi leverer pålydende prosessstyring og er eksplisitt uforenlige med funksjonen automatisk omstart av ASF, så som å kjøre ASF i `docker` eller `systemd`, ettersom de krever bare prosess for å avslutte dette ettersom det er deres ansvar å gjenoppta det etterpå, hvis det anses som hensiktsmessig. Siden vilkårlig konfigurasjonsredigering er uønsket fra brukererfaring. denne bryteren overstyrer bare `AutoRestart` konfigurasjonsegenskapen ved å initialisere den eksplisitt for `falsk`, selv om du har angitt ellers i konfigurasjonen. Takket være at ASF på forhånd kan informeres om kjøring i et slikt miljø, uten krav om å gi en kompatibel `AutoRestart: false` konfigurasjonsfil.

I tillegg til det over, `--no-restart`, i motsetning til `AutoRestart: falsk`, vil også forby deg fra å bruke `kommandoen restart` eller på annen måte å utstede ASF-prosess til å starte på nytt, siden bryteren er eksplisitt tilstander, er den ikke kompatibel med slike oppsett, mens `AutoRestart` -egenskapen angir bare standardoppførsel.

Normalt kan du (og bør) kontrollere oppførselen forklares her i konfigurasjonsfilen, selv om du kjører ASF inni et tilpasset skript eller andre lignende miljøer, du kan også ønske å benytte denne bryteren, det vil hindre ASF fra å starte seg på nytt.

---

`--ingen -steam-foreldregenerering` - som standard ASF vil automatisk forsøke å generere Steam-foreldrepenger, som beskrevet i **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** sin konfigurasjonseiendom. Siden dette kan kreve for mye OS-ressurser. Denne bryteren tillater deg å deaktivere handlingen, Resultatet av ASF som hopper over auto-generering og går rett til å spørre brukeren om PIN i stedet, som normalt ville skje bare hvis autogenereringen har mislyktes. Vanligvis anbefaler vi å beholde generering aktivert, men hvis du har en spesiell grunn til å deaktivere dette og vil i stedet foretrekke at ASF ikke gjør det, du kan bruke denne bryteren for å oppnå den formålet.

---

`--path <path>` eller `--path=<path>` - ASF navigerer alltid til sin egen katalog ved oppstart. Ved å angi dette argumentet vil ASF navigere til katalogen etter initialisering, som lar deg bruke egendefinert bane for de ulike programdelene (inkludert `config`, `logger`, `tillegg` og `www` samt `NLog. Konfigurasjon` fil), uten behov for duplisering av binærfilen på samme sted. Det kan være spesielt nyttig hvis du vil skille fra den aktuelle konfigurasjonen. siden den er ferdig i Linux-like emballasje - slik at du kan bruke en (oppdatert) binær med flere forskjellige oppsett. Stien kan være enten relativ i henhold til nåværende sted for ASF-binær eller absolutt. Husk at denne kommandoen peker på nytt "ASF hjem" - mappen med samme struktur som original ASF, med `config` -katalogen, se eksemplet under for forklaring.

På grunn av typen til denne egenskapen er det også mulig å angi en forventet bane ved å erklære `ASF_PATH` miljøvariabel. noe som kan være mer hensiktsmessig for personer som ønsker å unngå sensitive detaljer i prosessen argumenter.

Hvis du vurderer å bruke dette kommandolinjeargumentet for å kjøre flere forekomster av ASF, vi anbefaler å lese **[administrasjonsside](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** på denne måten.

Eksempler:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Absolute path
dotnet /opt/ASF/ArchiSteamFarm.dll --path .. TargetDirectory # Relativ bane fungerer som også
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # Same som env variabel
```

```text
∙∙📁 /opt
githubgithub-📁 ASF
ephalephalεεε″⚙️ ArchiSteamFarm.dll
Ilar
 IlarAbraham, Hmm.....
➜ 📁 TargetDirectory
÷ ÷ 📁 config
＋ 📁 Logger (generert)
Conoco› › › 📁 plugins (valgfritt)
Ä″: 📁 www (valgfritt)
kB xt (genererte)
########################📄 NLog.config (valgal)
ε″...
```

---

`--service` – denne bryteren brukes hovedsakelig av vår `-systemd` -tjeneste og -krefter `Headless` av `sann`. Med mindre du har et bestemt behov, bør du i stedet konfigurere `Headless` egenskapen direkte i konfigurasjonen. This switch is here so our `systemd` service won't need to touch your global config in order to adapt it to its own environment. Selvsagt kan du også benytte deg av denne bryteren (ellers er du bedre med den globale konfigurasjonsegenskapen).

---

`- system-nødvendig` - ved å erklære denne bryteren vil ASF prøve å signalisere systemet som prosessen krever at systemet er oppe og i drift over hele levetiden. Dette kan bevises spesielt nyttig når du dyrker på PCen eller bæreren om natten. siden ASF vil være i stand til å holde systemet våken mens det kjører. Denne funksjonen støttes for øyeblikket i Linux og Windows.

På Linux trenger du å arbeide ordentlig med **[dbus](https://en.wikipedia.org/wiki/D-Bus)** med innlogging daemon som støtter **[`Inhibit()`](https://systemd.io/INHIBITOR_LOCKS/)** funksjonen. To mest populære demonstrasjoner, `systemd` samt `elogind`, er bekreftet å støtte det. Majoritet av skrivebordsmiljøer (for eksempel Gnome og KDE) burde fungere ut av boksen. De er allerede avhengige av denne funksjonaliteten for sitt eget behov.

Ingen spesielle krav på Windows, så skal det gå ut av boksen.