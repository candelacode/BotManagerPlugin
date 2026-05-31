# Opdrachtregelparameters

ASF ondersteunt diverse opdrachtregelparameters die de uitvoering van het programma beïnvloeden. Deze kunnen door gevorderde gebruikers worden gebruikt om aan te geven hoe het programma moet worden uitgevoerd. Vergeleken met de standaardmanier om het configuratiebestand `ASF.json` te gebruiken, worden opdrachtregelparameters gebruikt voor de kerninitialisatie (bijv.`--path`), platform-specifieke instellingen (bijv. `--system-required`), of gevoelige data (bijv. `--cryptkey`).

---

## Gebruik

Het gebruik hangt af van je besturingssysteem en de ASF-variant.

Algemeen (OS-onafhankelijk):

```shell
dotnet ArchiSteamFarm.dll --parameter --andereParameter
```

Windows:

```powershell
.\ArchiSteamFarm.exe --parameter --andereParameter
```

Linux/macOS:

```shell
./ArchiSteamFarm --parameter --andereParameter
```

Parameters worden ook ondersteund in generische helper-scripts zoals `ArchiSteamFarm.cmd` of `ArchiSteamFarm.sh`. Daarnaast kunt u ook `ASF_ARGS` omgeving eigenschap gebruiken, zoals vermeld in onze **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** en **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** secties.

Als uw argument spaties bevat, vergeet dan niet het te citeren. Die twee zijn verkeerd:

```shell
./ArchiSteamFarm --path /home/archief/My Downloads/ASF # Bad!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Bad!
```

Deze twee zijn echter volledig in orde:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Parameters

`--cryptkey <key>` of `--cryptkey=<key>` - start ASF met aangepaste cryptografische sleutel van `<key>` waarde. Deze optie beïnvloedt **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** en zorgt ervoor dat ASF de aangepaste `<key>` sleutel gebruikt in plaats van een standaard hardcoded in het uitvoerbaar. Aangezien deze eigenschap van invloed is op de standaard encryptiesleutel (voor codering doeleinden) evenals op zout (voor hashing doeleinden), houd er rekening mee dat alles gecodeerd/hasht met deze sleutel vereist dat het op elke ASF uitgevoerd wordt.

Er is geen vereiste op `<key>` lengte of tekens, maar om veiligheidsredenen raden we aan om lang genoeg uit één wachtwoord te kiezen. . Willekeurige 32 tekens, bijvoorbeeld door `tr -dc A-Za-z0-9 < /dev/urandom ★head -c 32; echo` commando op Linux.

Het is leuk om te vermelden dat er ook twee andere manieren zijn om deze details te verstrekken: `--cryptkey-file` en `-input-cryptkey`.

Vanwege de aard van deze eigenschap is het ook mogelijk om cryptokey in te stellen door `ASF_CRYPTKEY` omgevingsvariabele aan te geven die wellicht geschikter zijn voor mensen die gevoelige details in de procesargumenten willen vermijden.

---

`--cryptkey-file <path>` of `--cryptkey-file=<path>` - start ASF met aangepaste cryptografische sleutel lezen uit `<path>` bestand. Dit dient hetzelfde doel als `--cryptkey <key>` hierboven uitgelegd, alleen het mechanisme verschilt, als deze eigenschap lees `<key>` van meegeleverde `<path>` in plaats daarvan. Als je dit samen met `--path`gebruikt, Overweeg het feit dat relatieve pad verschillend zal zijn, afhankelijk van de volgorde van de argumenten, i. . of u `--path` voor of na `--cryptkey-file` wisselt.

Vanwege de aard van deze eigenschap is het ook mogelijk om een cryptkey bestand in te stellen door `ASF_CRYPTKEY_FILE` omgevingsvariabele aan te geven die wellicht geschikter zijn voor mensen die gevoelige details in de procesargumenten willen vermijden.

---

`--negeer e-unsupported-environment` - zal ervoor zorgen dat ASF problemen met betrekking tot niet-ondersteunde omgeving negeert die normaal gesproken wordt ondertekend met een fout en een geforceerde afsluiting. Niet-ondersteunde omgeving omvat bijvoorbeeld het draaien van `win-x64` OS-specifieke build op `linux-x64`. Hoewel deze vlag ASF in staat stelt te proberen in dergelijke scenario's te functioneren, we raden aan dat we deze niet officieel ondersteunen en dat je ASF dwingt om het volledig te doen **op eigen risico**. Het is belangrijk om erop te wijzen dat **alle** van de niet-ondersteunde omgevingsscenario's **gecorrigeerd kunnen worden**. Wij bevelen met klem aan de bestaande problemen op te lossen in plaats van dit argument te noemen.

---

`--input-cryptkey` - zal ASF vragen stellen over de `--cryptkey` tijdens het opstarten. Deze optie kan handig zijn voor u als u in plaats van cryptkey te geven, of het nu gaat om omgevingsvariabelen of een bestand, je zou het liefst nergens opgeslagen willen hebben en in plaats daarvan handmatig invoeren bij elke ASF-uitvoering.

---

`--geminimaliseerd` - zal het ASF-console venster kort na het starten minimaliseren. Nuttig in auto-start-scenario's, maar ook daarbuiten, kunnen worden gebruikt. Deze optie vereist gepaste ondersteuning van het milieu - het werkt mogelijk niet in alle mogelijke scenario's.

---

`--netwerkgroep <group>` of `--netwerkgroep =<group>` - zal ervoor zorgen dat ASF zijn limieten instelt met een aangepaste netwerkgroep van `<group>` waarde. Deze optie heeft invloed op het uitvoeren van ASF in **[meerdere instanties](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** door het tekenen dat de instantie alleen afhankelijk is van instanties die dezelfde netwerkgroep delen. en onafhankelijk van de rest. Meestal wilt u deze eigenschap alleen gebruiken als u de ASF-aanvragen via een aangepast mechanisme routeert (bijv. verschillende IP-adressen) en u wilt de netwerkgroepen zelf instellen zonder te vertrouwen op ASF om het automatisch te doen (wat momenteel het rekening rekening houden met `alleen met WebProxy` opneemt). Houd er rekening mee dat bij het gebruik van een aangepaste netwerkgroep dit een unieke identificatie is binnen de lokale machine, en ASF zal geen rekening houden met andere details, zoals `WebProxy` waarde, waardoor je dit kan doen. . start twee instanties met verschillende `WebProxy` waardes die nog steeds afhankelijk zijn van elkaar.

Vanwege de aard van deze eigenschap is het ook mogelijk om de waarde in te stellen door `ASF_NETWORK_GROUP` omgevingsvariabele te verklaren, die wellicht geschikter zijn voor mensen die gevoelige details in de procesargumenten willen vermijden.

---

`--no-config-migrate` - standaard ASF zal uw configuratiebestanden automatisch overzetten naar de laatste syntax. Migratie omvat conversie van verouderde eigenschappen naar nieuwste eigenschappen, waarbij eigenschappen met standaardwaarden worden verwijderd (omdat ze geen effect hebben), naast het opruimen van het bestand in het algemeen (inspringen corrigeren) en zoals). Dit is bijna altijd een goed idee, maar je zou een bepaalde situatie kunnen hebben waarbij je ASF liever nooit de configuratiebestanden automatisch overschrijven. Bijvoorbeeld je wilt misschien `chmod 400` je configuratiebestanden (lees alleen toestemming voor de eigenaar) of plaats `chattr +i` erover, dat leidt ertoe dat iedereen schrijftoegang ontzegt. . - als veiligheidsmaatregel. Normaal gesproken raden we aan om migratie van configuraties ingeschakeld te houden maar als je een specifieke reden hebt om het uit te schakelen en liever dat ASF dit niet doet. je kunt deze schakelaar gebruiken om dat doel te bereiken. Houd er echter rekening mee dat het verstrekken van de juiste instellingen voor ASF vanaf nu op je nieuwe verantwoordelijkheid komt vooral met betrekking tot afschrijvingen en refactoren van eigendommen in toekomstige versies van ASF.

---

`--no-config-watch` - by default ASF sets up a `FileSystemWatcher` over your `config` directory in order to listen for events related to file changes, so it can interactively adapt to them. Bijvoorbeeld het stoppen van bots bij het verwijderen van configuratie, het herstarten van bot bij het wijzigen van configuratie of laad sleutels in **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** nadat je ze in de `config` map hebt geplaatst. Deze schakelaar staat je toe om dergelijk gedrag uit te schakelen, waardoor ASF alle wijzigingen in de `config` map volledig negeert, vereisen dat je dergelijke acties handmatig uitvoert, indien gewenst (wat meestal betekent dat je het proces herstart). We raden aan om de configuratie-events ingeschakeld te houden maar als je een specifieke reden hebt om ze uit te schakelen en liever dat ASF dat niet doet. je kunt deze schakelaar gebruiken om dat doel te bereiken.

---

`--no-herstart` - standaard volgt ASF **[`AutoRestart`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#autorestart)** config property, welke je kan gebruiken om aan te geven of herstart is toegestaan wanneer dit vereist is. Sommige oplossingen die we aanreiken voor procesbeheer en zijn expliciet niet compatibel met de automatische herstartfunctie van ASF. zoals het uitvoeren van ASF in `docker` of `systemd`, omdat ze alleen een proces vereisen om af te sluiten, aangezien het hun verantwoordelijkheid is om het nadien opnieuw op te starten, indien gewenst. Omdat willekeurige configuratie bewerken ongewenst is vanuit de gebruikerservaring deze schakelaar overschrijft simpelweg uw `AutoRestart` configuratie-eigenschap door deze expliciet te initialiseren naar `false`, zelfs als u anders hebt opgegeven in de config. Dankzij dat kan ASF op voorhand worden geïnformeerd over zijn functioneren in een dergelijke omgeving. zonder een vereiste voor een compatibele `AutoRestart: false` configuratie bestand.

Naast bovenstaande `--no-herstart`, in tegenstelling tot `AutoRestart: false`, zal je ook verbieden om `herstart` commando te gebruiken of ASF opnieuw te starten omdat de schakelaar expliciet vermeldt dat het niet compatibel is met deze installatie, terwijl `AutoRestart` eigenschap alleen het standaardgedrag specificeert.

Normaal gesproken kun je het gedrag dat hier uitgelegd wordt in het configuratiebestand, beheren (en moeten) alhoewel als je ASF gebruikt in een aangepast script of een vergelijkbare omgeving, je wilt misschien ook gebruik maken van deze schakel, die ASF verbiedt om zichzelf te herstarten.

---

`--no-steam-parental-generatie` - standaard zal ASF proberen om de Steam ouderlijkheidspinnen te genereren, zoals beschreven in **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** configuratie eigenschap. Omdat dat echter een overmatige hoeveelheid OS bronnen kan vereisen, kunt u met deze schakelaar dat gedrag uitschakelen, wat resulteert in het overslaan van auto-generatie en ga direct naar de gebruiker om PIN te vragen wat normaal gesproken alleen zou gebeuren als de auto-generatie heeft gefaald. Normaal gesproken raden we aan om de generatie ingeschakeld te houden maar als je een specifieke reden hebt om het uit te schakelen en liever dat ASF dit niet doet. je kunt deze schakelaar gebruiken om dat doel te bereiken.

---

`--path <path>` of `--path=<path>` - ASF navigeert altijd naar zijn eigen map bij het opstarten. Door dit argument te specificeren, navigeert ASF na initialisatie naar de opgegeven map, waarmee je een aangepast pad kunt gebruiken voor verschillende delen van de applicatie (inclusief `config`, `logs`, `plugins` en `www` directories, evenals `NLog. fig` bestand), zonder de noodzaak binary te dupliceren op dezelfde plaats. Het kan vooral handig zijn als je binair wil scheiden van de werkelijke configuratie, zoals het gebeurt in Linux-achtige verpakking - op deze manier kan je een (up-to-date) binary gebruiken met verschillende setups. Het pad kan relatief zijn volgens de huidige plaats van ASF-binary, of absolute. Houd er rekening mee dat deze opdracht verwijst naar een nieuwe "ASF home" - de map die dezelfde structuur heeft als de originele ASF met `config` map erin, zie hieronder het voorbeeld voor uitleg.

Vanwege de aard van deze eigenschap is het ook mogelijk om het verwachte pad in te stellen door `ASF_PATH` omgevingsvariabele te verklaren, die wellicht geschikter zijn voor mensen die gevoelige details in de procesargumenten willen vermijden.

Als je overweegt om deze command-line argument te gebruiken voor het uitvoeren van meerdere instanties ASF, we raden aan op deze manier onze **[beheerspagina](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** te lezen.

Voorbeelden

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Absolute path
dotnet /opt/ASSteamFarm.dll --path .. TargetDirectory # Relatieve pad werkt goed
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # Hetzelfde als env variabele
```

```text
・・📁 /opt
y-to-y-to-its, at at at hell_folder: ASF
ρρρ⚙️ gear: ArchiSteamFarm.dll
➜ credentials ...
CAPS /LA A - 📁 TargetDirectory
ximal) 
 ximude 📁 config
→## 📁 logs (gegenereerd)
CONTROL__CONTROL__CONTROL__fting 6.file_folder: plugins (optional)
(optional) 
 wwwww (optional)
DohaDoha:page_up: log. xt (gegenereerd)
½ ½ 📄 NLog.config (optional)
~~-...
```

---

`--service` - deze schakelaar wordt voornamelijk gebruikt door onze `systemd` dienst en forceert `Headless` of `true`. Tenzij je een bijzondere behoefte hebt, moet je in plaats daarvan `Headless` eigenschap direct in de configuratie configureren. Deze schakelaar is hier zodat onze `systemd` service niet meer je globale configuratie hoeft aan te raken om deze aan te passen aan de eigen omgeving. Natuurlijk, als je een vergelijkbare behoefte hebt, kan je ook gebruik maken van deze schakelaar (anders ben je beter met de globale configuratie eigenschap).

---

`--systeem-vereiste` - het opgeven van deze schakelaar zal ASF proberen het OS te ondertekenen dat het systeem gedurende zijn hele levensduur open en actief moet zijn. Dit kan vooral handig blijken als je 's nachts op je pc of laptop kweekt omdat ASF je systeem wakker kan houden terwijl het draait. Deze functie is momenteel ondersteund voor Linux en Windows.

Op Linux moet je goed werken **[dbus](https://en.wikipedia.org/wiki/D-Bus)** met login daemon die **[`Inhibit()`](https://systemd.io/INHIBITOR_LOCKS/)** functie ondersteunt. Twee populairste daemons, `systemd` en `elogind`, zijn bevestigd om dat te ondersteunen. De meerderheid van de bureaublad (zoals Gnome of KDE) moet uit de kast komen, omdat ze voor hun eigen behoeften al van deze functionaliteit afhankelijk zijn.

Geen speciale vereisten voor Windows, het zou buiten het kader moeten werken.