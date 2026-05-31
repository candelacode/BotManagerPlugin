# Kommandoradsargument

ASF innehåller stöd för flera kommandoradsargument som kan påverka programmets körtid. De kan användas av avancerade användare för att ange hur programmet ska köras. I jämförelse med standardkonfigurationsfilen `ASF.json` används kommandoradsargument för kärninitiering (t.ex. `--path`), plattformsspecifika inställningar (t.ex. `--system-krävs`) eller känslig data (t.ex. `--cryptkey`).

---

## Användning

Användning beror på din OS och ASF smak.

Allmänt:

```shell
dotnet ArchiSteamFarm.dll --argument --otherOne
```

Fönster:

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --otherOne
```

Kommandoradsargument stöds också i generiska hjälpskript som `ArchiSteamFarm.cmd` eller `ArchiSteamFarm.sh`. Dessutom kan du även använda miljöfastigheten `ASF_ARGS` som anges i vår **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** och **[hamnare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** avsnitt.

Om ditt argument innehåller mellanslag, glöm inte att citera det. Dessa två har fel:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Dåligt!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Dåligt!
```

Dessa två är dock helt bra:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Argument

`--cryptkey <key>` eller `--cryptkey=<key>` - startar ASF med anpassad kryptografisk nyckel för `<key>` värde. Detta alternativ påverkar **[säkerhet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** och kommer att orsaka ASF att använda din anpassade `<key>` nyckel istället för standard en hårdkodad till den körbara. Eftersom denna egenskap påverkar standard krypteringsnyckel (för krypteringsändamål) samt salt (för hashningsändamål), tänk på att allt krypterat/hashed med denna nyckel kommer att kräva att den skickas på varje ASF-körning.

Det finns inga krav på `<key>` längd eller tecken, men av säkerhetsskäl rekommenderar vi att plocka tillräckligt länge lösenfras gjord av e. . slumpmässiga 32 tecken, till exempel genom att använda `tr -dc A-Za-z0-9 < /dev/urandom <unk> head -c 32; eko` kommando på Linux.

Det är trevligt att nämna att det också finns två andra sätt att ge denna detalj: `--cryptkey-file` och `--input-cryptkey`.

På grund av egenskapens karaktär är det också möjligt att ställa in kryptkey genom att deklarera miljövariabeln `ASF_CRYPTKEY` vilket kan vara lämpligare för personer som vill undvika känsliga detaljer i processargumenten.

---

`--cryptkey-file <path>` eller `--cryptkey-fil=<path>` - startar ASF med anpassad kryptografisk nyckel som läses från `<path>` fil. Detta tjänar samma syfte som `--cryptkey <key>` förklaras ovan, endast mekanismen skiljer sig åt, eftersom denna egenskap kommer att läsa `<key>` från medföljande `<path>` istället. Om du använder detta tillsammans med `--path`, överväga det faktum att relativ väg kommer att vara olika beroende på ordningen av argument, dvs . oavsett om du byter `--path` före eller efter `--cryptkey-file`.

På grund av egenskapens karaktär, är det också möjligt att ställa in kryptkey fil genom att deklarera miljövariabeln `ASF_CRYPTKEY_FILE` vilket kan vara lämpligare för personer som vill undvika känsliga detaljer i processargumenten.

---

`--ignore-unsupported-environment` - kommer att orsaka ASF att ignorera problem relaterade till att köras i miljö som inte stöds, som normalt signaleras med ett fel och en påtvingad utgång. Miljö som inte stöds inkluderar till exempel att köra `win-x64` OS-specifik bygga på `linux-x64`. Medan denna flagga kommer att tillåta ASF att försöka köra i sådana scenarier, bli informerad om att vi inte stöder dem officiellt och du tvingar ASF att göra det helt **på egen risk**. Det är viktigt att påpeka att **alla** av de miljöer som inte stöds **kan korrigeras**. Vi rekommenderar starkt att lösa de olösta problemen i stället för att förklara detta argument.

---

`--input-cryptkey` - kommer få ASF att fråga om `--cryptkey` under start. Det här alternativet kan vara användbart för dig om du istället för att ange kryptnyckel, vare sig det gäller miljövariabler eller en fil, du skulle föredra att inte ha det sparat någonstans och istället mata in det manuellt på varje ASF-körning.

---

`--minimized` - kommer att göra ASF-konsolfönster minimeras kort efter start. Användbart främst i autostart-scenarier, men kan också användas utanför dessa. Detta alternativ kräver lämpligt miljöstöd - det kanske inte fungerar korrekt i alla tänkbara scenarier.

---

`--network-group <group>` eller `--network-group=<group>` - kommer att få ASF att lämna in sina begränsare med en anpassad nätverksgrupp `<group>` värde. Detta alternativ påverkar att köra ASF i **[flera instanser](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** genom att signalera att given instans endast är beroende av instanser som delar samma nätverksgrupp, och oberoende av resten. Vanligtvis vill du endast använda den här egenskapen om du dirigerar ASF-förfrågningar via anpassad mekanism (t.ex. olika IP-adresser) och du vill ställa in nätverksgrupper själv, utan att förlita sig på ASF att göra det automatiskt (som för närvarande inkluderar att ta hänsyn till `WebProxy` endast). Tänk på att när du använder en anpassad nätverksgrupp är detta en unik identifierare inom den lokala maskinen, och ASF kommer inte att ta hänsyn till några andra detaljer, såsom värdet `WebProxy` så att du kan e. . starta två instanser med olika `WebProxy` värden som fortfarande är beroende av varandra.

På grund av egenskapens karaktär är det också möjligt att ange värdet genom att deklarera miljövariabeln `ASF_NETWORK_GROUP` vilket kan vara lämpligare för personer som vill undvika känsliga detaljer i processargumenten.

---

`--no-config-migrera` - som standard kommer ASF automatiskt migrera dina konfigurationsfiler till senaste syntax. Migrering inkluderar konvertering av föråldrade egenskaper till de senaste, ta bort egenskaper med standardvärden (som de inte har någon effekt), samt rensa upp filen i allmänhet (korrigera indrag och likaså). Detta är nästan alltid en bra idé, men du kan ha en viss situation där du föredrar ASF att aldrig skriva över konfigurationsfilerna automatiskt. Till exempel, du kanske vill `chmod 400` dina konfigurationsfiler (läs behörigheten för ägaren endast) eller sätt `chattr +i` över dem, i resultatet förnekar skrivrättigheter för alla, e. . – som en säkerhetsåtgärd. Vanligtvis rekommenderar vi att du håller konfigurationsmigrationen aktiverad, men om du har en särskild anledning att inaktivera det och i stället föredrar ASF att inte göra det, du kan använda den här växeln för att uppnå detta ändamål. Tänk dock på att ge rätt inställningar till ASF kommer att bli från och med nu på ditt nya ansvar, särskilt när det gäller deprecations och refactors av fastigheter i framtida ASF-versioner.

---

`--no-config-watch` - som standard sätter ASF upp en `FileSystemWatcher` över din `config` katalog för att lyssna efter händelser relaterade till filändringar, så att den interaktivt kan anpassa sig till dem. Detta inkluderar till exempel att stoppa bottar på konfigurationsborttagning, starta om bot på konfigurationen som ändras, eller laddar nycklar till **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** när du släpper dem i `config` katalogen. Denna switch låter dig inaktivera sådant beteende, vilket kommer att orsaka ASF att helt ignorera alla ändringar i `config` -katalogen, kräver av dig att göra sådana åtgärder manuellt, om det anses lämpligt (vilket vanligtvis innebär omstart av processen). Vi rekommenderar att du håller konfigurationshändelserna aktiverade, men om du har en särskild anledning att inaktivera dem och i stället föredrar ASF att inte göra det, du kan använda den här växeln för att uppnå detta ändamål.

---

`--no-restart` - som standard följer ASF **[`AutoStarta om`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#autorestart)** config egendom, som du kan använda för att specificera om omstart är tillåten när det behövs. Vissa lösningar som vi tillhandahåller tar hand om processhantering och är uttryckligen inkompatibla med automatisk omstart funktion av ASF, såsom kör ASF i `docker` eller `systemd`, som de behöver process för att avsluta bara, eftersom det är deras ansvar att starta om det efteråt, om det anses lämpligt. Eftersom godtycklig konfigurationsredigering är oönskad från användarupplevelse, den här växeln åsidosätter helt enkelt din `AutoRestart` config egenskap genom att uttryckligen initiera den till `false`, även om du har angett något annat i konfigurationen. Tack vare det, ASF kan informeras i förväg om att köra i en sådan miljö, utan krav på att tillhandahålla en kompatibel `AutoRestart: false` konfigurationsfil.

Utöver ovanstående `--no-restart`, i motsats till `AutoRestart: false`, kommer också att förbjuda dig att använda `omstart` kommandot eller på annat sätt utfärda ASF process för att starta om, eftersom växeln uttryckligen anger att den inte är kompatibel med sådana inställningar, medan egenskapen `AutoStarta om` anger endast standardbeteende.

Normalt kan du (och bör) kontrollera beteendet som förklaras här i konfigurationsfilen, även om du kör ASF inuti ett anpassat skript eller annan liknande miljö, du kanske också vill använda denna switch, som kommer att förbjuda ASF från att starta om sig själv.

---

`--no-steam-parental-generation` - som standard kommer ASF automatiskt försöka generera Steam föräldra-pinkoder, som beskrivs i **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** konfigurationsegenskap. Men eftersom det kan kräva en överdriven mängd OS-resurser, kan du inaktivera detta beteende, vilket kommer att resultera i ASF hoppa över auto-generation och gå direkt till att be användaren om PIN istället, vilket är vad som normalt skulle hända endast om auto-generationen har misslyckats. Vanligtvis rekommenderar vi att hålla generationen aktiverad, men om du har en särskild anledning att inaktivera det och i stället föredrar ASF att inte göra det, du kan använda den här växeln för att uppnå detta ändamål.

---

`--path <path>` eller `--path=<path>` - ASF navigerar alltid till sin egen katalog vid uppstart. Genom att ange detta argument, kommer ASF att navigera till given katalog efter initiering, som låter dig använda anpassad sökväg för olika programdelar (inklusive `config`, `loggar`, `plugins` och `www` kataloger, liksom `NLog. onfig` -fil), utan att behöva duplicera binära på samma ställe. Det kan komma särskilt användbart om du vill skilja binär från faktisk konfiguration, som det är gjort i Linux-liknande förpackningar - på detta sätt kan du använda en (up-to-date) binär med flera olika inställningar. Sökvägen kan vara antingen relativ beroende på nuvarande plats av ASF binär, eller absolut. Tänk på att detta kommando pekar på nya "ASF home" - den katalog som har samma struktur som original ASF, med `config` katalog inuti, se nedan exempel för förklaring.

På grund av egenskapens karaktär är det också möjligt att ställa in förväntad sökväg genom att deklarera miljövariabeln `ASF_PATH` vilket kan vara lämpligare för personer som vill undvika känsliga detaljer i processargumenten.

Om du funderar på att använda detta kommandoradsargument för att köra flera instanser av ASF, Vi rekommenderar att läsa vår **[management sida](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** på detta sätt.

Exempel:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Absolut path
dotnet /opt/ASF/ArchiSteamFarm.dll --path .. TargetDirectory # Relativ sökväg fungerar också
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # Samma som env variabel
```

```text
<unk> ─ 📁 /opt
<unk> <unk> <unk> ─ 📁 ASF
<unk> <unk> <unk> ─ ⚙️ ArchiSteamFarm.dll
<unk> <unk> <unk> ─ ...
● <unk> <unk> <unk> ─ 📁 TargetDirectory
ôôné-📁 config
ôné-📁 loggar (genererade)
ôné-─ 📁 plugins (valfritt)
ôné-📁 www (valfritt)
ôné-📄 log. xt (genererat)
<unk> <unk> <unk> ─ 📄 NLog.config (valfritt)
<unk> ─ ...
```

---

`--service` - denna switch används främst av vår `systemd` service och tvingar `Headless` av `true`. Om du inte har ett särskilt behov, bör du istället konfigurera `Headless` egenskap direkt i din konfiguration. Den här växeln är här så vår tjänst `systemd` behöver inte röra din globala konfiguration för att anpassa den till sin egen miljö. Naturligtvis, om du har ett liknande behov kan du också använda denna switch (annars är du bättre med global konfiguration).

---

`--system-required` - genom att deklarera denna switch kommer ASF att försöka signalera operativsystemet att processen kräver att systemet är igång under hela sin livstid. Detta kan bevisas särskilt användbart när du odlar på din dator eller bärbara dator under natten, som ASF kommer att kunna hålla ditt system vaket medan det är igång. Denna funktion stöds för närvarande på Linux och Windows.

På Linux behöver du arbeta korrekt **[dbus](https://en.wikipedia.org/wiki/D-Bus)** med inloggningsdaemon som stöder **[`Inhibit()`](https://systemd.io/INHIBITOR_LOCKS/)** funktion. Två mest populära demoner, `systemd` samt `elogind`, bekräftas för att stödja det. Majoriteten av skrivbordsmiljöer (såsom Gnome eller KDE) bör fungera ur lådan, eftersom de redan är beroende av denna funktion för sina egna behov.

Inga speciella krav på Windows, det bör fungera ur lådan.