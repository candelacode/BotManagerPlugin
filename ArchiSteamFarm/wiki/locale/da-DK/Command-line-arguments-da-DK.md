# Kommandolinje argumenter

ASF omfatter støtte til flere kommandolinjeargumenter, der kan påvirke programmets runtime. Disse kan bruges af avancerede brugere for at angive, hvordan programmet skal køre. Sammenlignet med standard måde `ASF.json` konfigurationsfil bruges kommandolinjeargumenter til kernens initialisering (f.eks. `--path`), platform-specifikke indstillinger (f.eks. `--system-required`) eller følsomme data (f.eks. `--cryptkey`).

---

## Brug

Brug afhænger af din OS og ASF smag.

Generisk

```shell
dotnet ArchiSteamFarm.dll --argument --otherOne
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --otherOne
```

Kommandolinje argumenter understøttes også i generiske hjælper scripts såsom `ArchiSteamFarm.cmd` eller `ArchiSteamFarm.sh`. Derudover kan du også bruge `ASF_ARGS` miljøegenskaber, like stated in our **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** and **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** sections.

Hvis dit argument indeholder mellemrum, glem ikke at citere det. Disse to tager fejl:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Bad!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Bad!
```

Disse to er dog helt fine:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Argumenter

`--cryptkey <key>` eller `--cryptkey=<key>` - vil starte ASF med brugerdefineret kryptografisk nøgle af `<key>` værdi. Denne indstilling påvirker **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** og vil få ASF til at bruge din brugerdefinerede angivne `<key>` nøgle i stedet for standard en hardcoded i den eksekverbare. Da denne egenskab påvirker standard krypteringsnøgle (til kryptering formål) samt salt (til hashing formål), huske på, at alt krypteret / hashed med denne nøgle vil kræve, at det skal videregives på hver ASF kørsel.

Der er ingen krav til `<key>` længde eller tegn, men af sikkerhedsmæssige årsager anbefaler vi at vælge længe nok adgangssætning lavet af e. . random 32 characters, for eksempel ved brug af `tr -dc A-Za-z0-9 < /dev/urandom - head -c 32 echo` -kommando på Linux.

Det er rart at nævne, at der også er to andre måder at give denne detalje: `--cryptkey-file` og `--input-cryptkey`.

På grund af karakteren af denne egenskab, er det også muligt at indstille cryptkey ved at erklære `ASF_CRYPTKEY` miljøvariabel, som kan være mere passende for folk, der ønsker at undgå følsomme detaljer i processen argumenter.

---

`--cryptkey-file <path>` eller `--cryptkey-file=<path>` - vil starte ASF med brugerdefineret kryptografisk nøgle læst fra `<path>` fil. Dette tjener samme formål som `--cryptkey <key>` forklarede ovenfor, kun mekanismen forskellige, da denne egenskab vil læse `<key>` fra den angivne `<path>` i stedet. Hvis du bruger dette sammen med `--path`, overveje det faktum, at relative vej vil være forskellig, afhængigt af rækkefølgen af argumenter, dvs.. . om du skifter `-- path` før eller efter `-- cryptkey-file`.

På grund af karakteren af denne egenskab, er det også muligt at indstille cryptkey fil ved at erklære `ASF_CRYPTKEY_FILE` miljøvariabel, som kan være mere passende for folk, der ønsker at undgå følsomme detaljer i processen argumenter.

---

`--ignore-unsupported-environment` - vil få ASF til at ignorere problemer relateret til at køre i ikke-understøttet miljø som normalt er signaliseret med en fejl og en tvungen exit. Ikke-understøttet miljø omfatter for eksempel kørsel `win-x64` OS-specifik build on `linux-x64`. Mens dette flag vil tillade ASF at forsøge at køre i sådanne scenarier, tilrådes at vi ikke støtter dem officielt, og du tvinger ASF til at gøre det helt **på din egen risiko**. Det er vigtigt at påpege, at **alle** af de ikke-understøttede miljøscenarier **kan korrigeres**. Vi anbefaler på det kraftigste at løse de udestående problemer i stedet for at fremsætte dette argument.

---

`--input-cryptkey` - vil få ASF til at spørge om `--cryptkey` ved opstart. Denne indstilling kan være nyttig for dig, hvis i stedet for at give cryptkey, enten i miljøvariabler eller en fil, du foretrækker ikke at have det gemt hvor som helst, og i stedet indtaste det manuelt på hver ASF kørsel.

---

`-- minimized` - vil få ASF konsolvinduet til at minimere kort tid efter start. Nyttige hovedsageligt i auto-start scenarier, men kan også bruges uden for dem. Denne indstilling kræver passende miljøunderstøttelse - den fungerer muligvis ikke korrekt i alle mulige scenarier.

---

`--network-group <group>` eller `--network-group=<group>` - vil forårsage ASF at init sine limiters med en brugerdefineret netværksgruppe på `<group>` værdi. Denne indstilling påvirker kørende ASF i **[multiple instances](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** ved at signalisere, at given instans kun er afhængig af instanser, der deler den samme netværksgruppe og uafhængig af resten. Typisk vil du kun bruge denne egenskab, hvis du dirigerer ASF-anmodninger gennem brugerdefineret mekanisme (f.eks. forskellige IP-adresser) og du vil selv indstille netværksgrupper uden at forlade sig på ASF til at gøre det automatisk (som i øjeblikket omfatter under hensyntagen til `WebProxy` kun). Husk, at når du bruger en brugerdefineret netværksgruppe, dette er entydig identifikator i den lokale maskine, og ASF vil ikke tage hensyn til andre detaljer, såsom `WebProxy` værdi, så du kan e. . starte to tilfælde med forskellige `WebProxy` værdier, som stadig er afhængige af hinanden.

På grund af karakteren af denne egenskab, er det også muligt at indstille værdien ved at deklarere `ASF_NETWORK_GROUP` miljøvariabel, som kan være mere passende for folk, der ønsker at undgå følsomme detaljer i processen argumenter.

---

`--no-config-migrere` - som standard vil ASF automatisk overføre dine config filer til seneste syntaks. Migration omfatter konvertering af forældede egenskaber til nyeste, fjernelse af egenskaber med standardværdier (som de ikke har nogen effekt) samt oprydning af filen i almindelighed (korrigering af indrykning og ligeledes). Dette er næsten altid en god idé, men du kan have en bestemt situation, hvor du foretrækker ASF til aldrig overskrive config filer automatisk. For eksempel du måske ønsker at `chmod 400` dine konfigurationsfiler (kun læsetilladelse for ejerne) eller lægge `chattr +i` over dem, som følge heraf nægtes skriveadgang for alle, e. Som en sikkerhedsforanstaltning. Normalt anbefaler vi at holde config migration aktiveret, men hvis du har en særlig grund til at deaktivere det og i stedet foretrækker ASF ikke at gøre det, du kan bruge denne kontakt til at opnå dette formål. Husk dog, at give korrekte indstillinger til ASF vil fra nu af blive dit nye ansvar, især med hensyn til deprecations og refactors af ejendomme i fremtidige ASF-versioner.

---

`--no-config-watch` - som standard opsætter ASF en `FileSystemWatcher` over din `config` mappe for at lytte til begivenheder relateret til filændringer, så det kan interaktivt tilpasse sig dem. For eksempel omfatter dette stop bots på config sletning, genstart bot på config bliver ændret, eller indlæsning af nøgler i **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** , når du dropper dem i mappen `config`. Denne switch tillader dig at deaktivere en sådan adfærd, hvilket vil få ASF til helt at ignorere alle ændringer i `config` mappen, kræver fra dig at gøre sådanne handlinger manuelt, hvis det skønnes hensigtsmæssigt (hvilket normalt betyder genstart af processen). Vi anbefaler at holde config begivenheder aktiveret, men hvis du har en bestemt grund til at deaktivere dem og i stedet foretrækker ASF ikke at gøre det, du kan bruge denne kontakt til at opnå dette formål.

---

`--no-restart` - som standard følger ASF **[`AutoGenstart`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#autorestart)** config egenskab, som du kan bruge til at angive, om genstart er tilladt, når det kræves. Nogle løsninger, som vi leverer tager ansvar for processtyring og er udtrykkeligt uforenelige med auto-genstart funktion af ASF, såsom kørende ASF i `docker` eller `systemd`, som de kræver proces til at forlade kun, da det er deres ansvar at genstarte det bagefter, hvis det skønnes hensigtsmæssigt. Da vilkårlig config redigering er uønsket fra brugeroplevelse, denne kontakt tilsidesætter blot din `AutoGenstart` config ejendom ved udtrykkeligt at initialisere den til `false`, selvom du har angivet andet i konfigurationen. Takket være dette kan ASF på forhånd informeres om at køre i sådanne miljøer uden krav om at levere en kompatibel `AutoGenstart: false` config fil.

Ud over ovenstående, `--no-genstart`, i modsætning til `AutoGenstart: false`, vil også forbyde dig at bruge `genstarte` kommando eller på anden måde udstede ASF proces for at genstarte, da kontakten udtrykkeligt angiver, at den ikke er kompatibel med en sådan opsætning, mens `Egenskab AutoGenstart` kun angiver standard opførsel.

Normalt kan du (og bør) styre den adfærd, der er forklaret her i config fil, selvom hvis du kører ASF inde i en brugerdefineret script eller andre lignende miljø, du måske også ønsker at gøre brug af denne switch, der vil forbyde ASF fra at genstarte sig selv.

---

`--no-steam-parental-generation` - som standard vil ASF automatisk forsøge at generere Steam forældre PIN-koder, som beskrevet i **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** konfigurationsejendom. Men da det kan kræve for mange OS-ressourcer, giver denne switch dig mulighed for at deaktivere denne adfærd, hvilket vil resultere i ASF springe auto-generation og gå direkte til at spørge brugeren om PIN i stedet, hvilket er hvad der normalt kun ville ske, hvis auto-generationen er mislykkedes. Normalt anbefaler vi at holde generationen aktiveret, men hvis du har en særlig grund til at deaktivere det og i stedet foretrækker ASF ikke at gøre det, du kan bruge denne kontakt til at opnå dette formål.

---

`--path <path>` eller `--path=<path>` - ASF navigerer altid til sin egen mappe ved opstart. Ved at angive dette argument, vil ASF navigere til en given mappe efter initialisering, som giver dig mulighed for at bruge brugerdefineret sti til forskellige programdele (herunder `config`, `logs`, `plugins` og `www` mapper samt `NLog. onfig` -fil), uden behov for at duplikere binær på samme sted. Det kan komme især nyttigt, hvis du gerne vil adskille binær fra faktiske config, som det gøres i Linux-lignende emballage - på denne måde kan du bruge en (up-to-date) binær med flere forskellige opsætninger. Stien kan enten være relativ i henhold til det aktuelle sted for ASF binær, eller absolut. Husk, at denne kommando peger på nyt "ASF home" - den mappe, der har den samme struktur som oprindelige ASF, med mappen `config` indeni, se nedenstående eksempel for forklaring.

På grund af karakteren af denne egenskab, er det også muligt at indstille forventede sti ved at erklære `ASF_PATH` miljøvariabel, som kan være mere passende for folk, der ønsker at undgå følsomme detaljer i processen argumenter.

Hvis du overvejer at bruge denne kommandolinje argument for at køre flere forekomster af ASF, Vi anbefaler at læse vores **[management side](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** på denne måde.

Eksempler:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Absolute path
dotnet /opt/ASF/ArchiSteamFarm.dll --path .. TargetDirectory # Relative path works as well
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # Samme som env variabel
```

```text
Øjeblikkelig 📁 /opt
- Øjeblikkelig 📁 ASF
- Øjeblikkelig - Øjeblikke: ArchiSteamFarm.dll
- Øjeblikkelig ...
Øjeblikkelig 📁 TargetDirectory
- Øjeblikkelig 📁 config
- Øjeblikkelig 📁 logs (genereret)
- Øjeblikkelig 📁 plugins (valgfri)
- Øjeblikkelig 📁 www (valgfri)
- Øjeblikkelig 📄 log. xt (genereret)
- opdatering📄 NLog.config (valgfri)
- ...
```

---

`--service` - denne kontakt bruges hovedsageligt af vores `systemd` service og styrker `Headless` af `true`. Medmindre du har et særligt behov, bør du i stedet konfigurere `Headless` ejendom direkte i din konfiguration. Denne kontakt er her, så vores `systemd` service ikke behøver at røre din globale config for at tilpasse den til sit eget miljø. Selvfølgelig, hvis du har et lignende behov, så kan du også gøre brug af denne switch (ellers er du bedre med global config egenskab).

---

`--system-required` - Hvis du erklærer denne switch, vil ASF forsøge at signalere operativsystemet om, at processen kræver, at systemet er i gang i hele sin levetid. Dette kan bevises især nyttigt, når landbrug på din pc eller laptop i løbet af natten, som ASF vil være i stand til at holde dit system vågen, mens det kører. Denne funktion er i øjeblikket understøttet på Linux og Windows.

På Linux skal du bruge **[dbus](https://en.wikipedia.org/wiki/D-Bus)** med login-dæmon, der understøtter **[`Inhibit()`](https://systemd.io/INHIBITOR_LOCKS/)** funktion. To mest populære dæmoner, `systemd` samt `elogind`bekræftes at støtte det. Størstedelen af skrivebordsmiljøer (såsom Gnome eller KDE) bør arbejde ud af boksen, da de allerede er afhængige af denne funktionalitet til deres egne behov.

Ingen særlige krav til Windows, det bør arbejde ud af boksen.