# Instelling

Als je hier voor het eerst bent aangekomen, welkom! We zijn erg blij om nog een reiziger te zien die geïnteresseerd is in ons project. Ook al houdt u er rekening mee dat met grote macht grote verantwoordelijkheid ontstaat - ASF is in staat om veel verschillende Steam-gerelateerde taken uit te voeren, maar alleen zolang je **zoveel doet om te leren hoe je het moet gebruiken**. Inderdaad, lezen wiki, Volg onze richtlijnen en leer meer over verschillende ASF-concepten zullen je uiteindelijk belonen met je unieke vaardigheid om een van de krachtigste Steam-tools te gebruiken die beschikbaar zijn vanaf vandaag.

We aanbevelen om maar **één ding tegelijk te doen**. ASF heeft veel verschillende aspecten aangeroerd, waarvan sommige nogal triviaal zijn, andere kunnen te complex zijn. Je hoeft niet alles in één keer te begrijpen of te lezen, en we raden je aan om het makkelijk te nemen. Ontspan, kies voor een drankje van keuze, Een uur van je tijd uitwijden en duiken in onze lezing - we kunnen u beloven dat het uw tijd waard zal zijn.

Laten we beginnen met de basis - ASF is een console-app in zijn principe. dat betekent dat het niet automatisch een grafische interface zal spawnen waar je gewoonlijk aan gewend bent. ASF is universele app die meestal fungeert als service (daemon), en niet als desktop app. Een van de belangrijkste gebruiksgevallen vindt dat het op de servermachines draait, waarvoor desktopapps volledig ongeschikt zijn. That considers only the absolute core of the program though, because ASF actually **does** include its own graphical interface - in form of its built-in ASF-ui frontend, but we'll get down to that part in due time - we're just mentioning this right away so you won't panic when seeing black console screen or something.

Zodra je ASF-binaire bestanden verkrijgt, vereist het programma configuratie van jou, wat aangeeft wat je precies verwacht voor ASF om te zetten. Je kunt het programma starten zonder configuratie, in dit geval zal ASF de standaardinstellingen opstarten, waardoor je eentje kunt gebruiken. . ASF-ui voor de initiële configuratie, maar anders zal het niet veel doen zonder je eerdere actie.

Dat zal nu gebeuren, laten we beginnen!

---

## OS-specifiek instellen

In het algemeen is dit wat we de komende minuten gaan doen:
- We'll install **[.NET prerequisites](#net-prerequisites)**.
- Vervolgens downloaden we **[de nieuwste ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** in de juiste OS-specifieke variant.
- Vervolgens pakken we het archief uit op een nieuwe locatie.
- Vervolgens zullen we **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** configureren.
- En tot slot zullen we ASF lanceren en de magie ervan zien.

Sommige stappen zijn vanzelfsprekend, andere vereisen meer aandacht van u. Maak je geen zorgen, we hebben je bedekt.

---

### .NET Voorwaarden

De eerste stap is ervoor zorgen dat je OS zelfs ASF correct kan starten. Je hoeft dat niet te weten, maar ASF is geschreven in C#, gebaseerd op . ET platform en vereist mogelijk native libraries die nog niet beschikbaar zijn op je platform. Denk eraan als DirectX voor de 3D-spellen, of motor voor het starten van je auto.

Afhankelijk van of u Windows, Linux of macOS gebruikt, hebt u verschillende vereisten. Het referentiedocument is **[. ET voorwaarden](https://docs.microsoft.com/dotnet/core/install)**, maar omwille van de eenvoud hebben we ook alle benodigde pakketten hieronder gedetailleerd uitgewerkt Dus je hoeft het helemaal niet te lezen, tenzij je problemen hebt of extra vragen hebt.

Het is heel normaal dat sommige (of zelfs alle) afhankelijkheden al bestaan op je systeem omdat je geïnstalleerd bent door software van derden die je gebruikt. Toch hoeft dat niet het geval te zijn dus moet je de juiste installatie voor je OS uitvoeren - zonder die afhankelijkheden zal ASF helemaal niet starten. en je krijgt nauwelijks bruikbare informatie om je te vertellen wat er mis is.

Houd er rekening mee dat je niets anders hoeft te doen voor OS-specifieke versies, vooral het installeren . ET SDK of zelfs runtime omdat het OS-specifieke pakket dat alles al bevat. Je hebt alleen .NET voorwaarden (afhankelijkheden) nodig om uit te voeren. ET runtime opgenomen in ASF - dus alleen de dingen die we hieronder specificeren, zonder enige andere toevoeging.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Herdistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** voor 64-bit, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** voor 32-bit of **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** voor 64-bit ARM)
- Het wordt sterk aanbevolen om ervoor te zorgen dat alle Windows updates al geïnstalleerd zijn. Als je ze niet hebt ingeschakeld dan op zijn minst heb je **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** en **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, maar er zijn misschien meer updates nodig. U hoeft zich daar geen zorgen over te maken als uw Windows up-to-date is, of ten minste recent genoeg.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Pakket namen hangen af van de Linux distributie die u gebruikt, we hebben de meest voorkomende vermeld. U kunt ze allemaal verkrijgen met een native pakket manager voor uw OS (zoals `apt` voor Debian of `yum` voor CentOS). Dit zijn vrij standaard bibliotheken die beschikbaar zouden moeten zijn, ongeacht de distributie die je gebruikt, Het is alleen maar een kwestie om uit te zoeken hoe ze worden genoemd in jouw omgeving van keuze.

- `ca-certificaten` (standaard vertrouwde SSL-certificaten om HTTPS-verbindingen te maken)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, nieuwste versie voor je distributie, bijvoorbeeld `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-libs`, laatste versie voor jouw distributie, minstens `1.1.X`)
- `libstdc++6` (`libstdc++`, in versie `5.0` of hoger)
- `zlib1g` (`zlib`)

Ten minste een meerderheid daarvan zou al beschikbaar moeten zijn op uw systeem. Bijvoorbeeld, de minimale installatie van Debian stal vereist meestal alleen `libicu76`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- Je hebt niets specifieks nodig, maar je moet de nieuwste versie van macOS geïnstalleerd hebben, ten minste 12.0+

---

### Downloaden

Aangezien we alle vereiste afhankelijkheden al hebben, wordt de volgende stap gedownload **[nieuwste ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF is beschikbaar in veel varianten, maar je bent geïnteresseerd in pakket dat overeenkomt met je besturingssysteem en architectuur. Bijvoorbeeld, als je `64`-bit `Win`dows gebruikt, dan wil je `ASF-win-x64` pakket. Voor meer informatie over beschikbare varianten, bezoek **[compatibiliteit](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** sectie. ASF is ook in staat om uitgevoerd te worden in de omgevingen waar we geen OS-specifiek pakketje voor bouwen zoals **32-bit Windows**, maar je hebt **[algemene installatie](#generic-setup)** daarvoor nodig.

![Activa](https://i.imgur.com/Ym2xPE5.png)

Na het downloaden start het uitpakken van het zip-bestand in zijn eigen map. Als je daarvoor een specifieke tool nodig hebt, **[7-zip](https://www.7-zip.org)** maar alle standaard toepassingen zoals ingebouwde Windows extractie of `unzip` van Linux/macOS moeten ook werken zonder problemen.

Het is aangeraden ASF uit te pakken tot **zijn eigen map** en niet tot een bestaande map die je al gebruikt voor iets anders - dat is belangrijk. ASF bevat de auto-update functie, die zijn eigen bestanden vervangt, en die meestal alle oude en ongerelateerde bestanden zal verwijderen bij het upgraden, wat er op zijn beurt toe kan leiden dat je alles kwijtraakt wat niet gerelateerd is aan de ASF-directory. Als je extra scripts of bestanden hebt die je met ASF wilt gebruiken, is dat geen probleem, maak een speciale map voor deze, je kan ASF altijd in één map dieper zetten.

Een voorbeeldstructuur zou er zo uit kunnen zien:

```text
C:\ASF (waar je je eigen dingen plaatst)
    ・MyNotes. xt (optioneel)
    (INeel) AsfMakeMeCoffeeScript.bat (optioneel)
    Meas︎ (... (alle andere bestanden van jouw keuze, optioneel)
    ½ HD Core (gewijd aan alleen ASF waar u het archief uitpakt)
         ・ArchiSteamFarm(. xe)
         ½ ½ config
         ½ logs
         ½ logs 
 ρplugins-
         ！ www
         wwwwude (...)
```

---

### Configuratie

We zijn nu klaar om de allerlaatste stap te zetten, de configuratie. ASF werkt met concept "bots", elke bot is meestal een Steam-account dat je binnen ASF wilt gebruiken. Je kunt zo veel bots opgeven als je wilt, maar voor de starter zullen we ons concentreren op slechts één van deze bots - meestal je hoofdaccount. ASF heeft ook niet-bot configuratiebestanden, de belangrijkste is het globale configuratiebestand, dat van invloed is op alle bots in het bijvoorbeeld.

De algemene vuistregel is dat **als je een instelling niet weet of niet begrijpt u moet het verlaten met de standaardwaarde, zonder iets** te wijzigen. ASF biedt talloze manieren om te configureren, aanpassen en aanpassen van bijna al zijn functies, maar zoals hierboven vermeld, proberen om het direct buiten de vleermuis te begrijpen is een konijnengat dat je snel in ernstige verwarring kan slepen. indien niet **[recht in de afgrond](https://www.youtube.com/watch?v=KK3KXAECte4)**. In plaats daarvan raden we aan eerst een werkvoorbeeld te hebben en dan pas in extra opties te gaan graven, met behulp van **[configuratie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** pagina op de wiki, bij het wisselen van **één ding**.

ASF configuratie kan op verschillende manieren worden gedaan - via onze ingebouwde ASF-ui frontend, een zelfstandige webconfiguratie generator, of handmatig. Dit is een diepte uitgelegd in **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** sectie, dus verwijs ernaar als u meer gedetailleerde informatie wilt. We zullen standalone webconfiguratiegenerator als startpunt gebruiken, omdat het werkt zelfs als ASF-ui om een of andere reden niet correct begint of werkt.

Navigeer naar onze **[webconfig generator](https://justarchinet.github.io/ASF-WebConfigGenerator)** pagina met je favoriete browser. We raden Chrome of Firefox aan, maar het zou niet zo belangrijk moeten zijn als je browser voor al het andere werkt.

Na het openen van de pagina, schakel naar het "Onder" tabblad. Je zou nu een soortgelijke pagina moeten zien als hieronder:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Als de ASF versie die je zojuist hebt gedownload ouder is dan welke config generator standaard is ingesteld, kies je ASF versie uit het dropdown menu. Dit kan gebeuren (zeldzaam) omdat de config generator kan worden gebruikt voor het genereren van configuraties naar nieuwere (pre-release) versies die nog niet als stabiel zijn gemarkeerd. Je hebt de laatste stabiele versie van ASF gedownload, die geverifieerd wordt om betrouwbaar te werken, Dus het kan een beetje ouder zijn dan de absolute randversie, wat helemaal niet geschikt is voor de eerste keer.

Start van **plaatsen van naam voor je bot** in het veld gemarkeerd als rood, genaamd `Naam`. Dit kan elke naam zijn die je wilt gebruiken, zoals je bijnaam, accountnaam, een nummer of wat dan ook. Er is slechts één woord dat je niet kunt gebruiken, `ASF`, omdat dat sleutelwoord is gereserveerd voor het globale configuratiebestand. De naam van je bot kan niet beginnen met een stip (ASF negeert deze bestanden). We raden u ook aan om geen spaties te gebruiken, u kunt `_` gebruiken als woordscheidingsteken - indien nodig geen strikte vereiste, maar anders heb je moeite met het gebruik van ASF-opdrachten.

Bot naam gekozen? Geweldig, in de volgende stap, verander ** `Ingeschakeld naar` schakelt in**, dat iemand definieert of je bot automatisch moet worden gestart door ASF na opstarten (van het programma). Als je dat niet doet, zal ASF verklaren dat je bot is uitgeschakeld in het configuratiebestand, en het wacht op uw input om ermee te beginnen, wat niet is wat we in dit voorbeeld willen doen.

Nu verschijnen er twee gevoelige eigenschappen: `SteamLogin` en `SteamPassword`. Je kunt hier een andere beslissing nemen - of je je Steam login gegevens in deze twee eigenschappen kunt plaatsen, of je kunt besluiten dat niet te doen en ze leeg te laten.

ASF heeft je inloggegevens nodig omdat het de eigen implementatie van je Steam client bevat en dezelfde gegevens nodig heeft om in te loggen als degene die je gebruikt. Uw inloggegevens worden nergens opgeslagen, maar op uw PC in de ASF `config` map (zodra u de gegenereerde configuratie downloadt). Onze webconfiguratie generator is een client-gebaseerde applicatie, wat betekent dat alles wat je doet in onze zelfstandige web config-generator website lokaal in je browser draait om geldige ASF configuraties te genereren, zonder details dat je ooit je pc op de eerste plaats plaatst, dus je hoeft je geen zorgen te maken over een mogelijk 'gevoelige gegevenslek'. Maar als u om welke reden dan ook uw geloofsbrieven daar niet wilt plaatsen, begrijpen wij dat: en je kunt ze later handmatig in de gegenereerde bestanden zetten, of ze volledig weglaten en zonder ze te werken.

Als u besluit om uw referenties in te voeren, kan ASF automatisch inloggen tijdens het opstarten, die u samen met optionele 2FA effectief in staat stellen om het programma te dubbelklikken om alles uit te voeren. Als je besluit om ze weg te laten dan zal ASF **je** vragen om die details in te voeren als dat nodig is - die aanpak zal ze nergens opslaan. maar natuurlijk kan ASF niet werken zonder jouw hulp. Het is aan u op welke manier u meer wilt, en u kunt zoals gewoonlijk ook aanvullende informatie vinden in **[configuratie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** sectie.

Als nevenopmerking kunt u ook besluiten om slechts één veld leeg te laten, zoals `SteamPassword`. ASF kan je login dan automatisch gebruiken, maar zal indien nodig om een wachtwoord vragen (vergelijkbaar met de Steam Client). Als je toevallig 4-cijferige ouderlijk pin gebruikt om je account te ontgrendelen, we raden ook aan om het in het kader van `SteamParentalPin` te plaatsen, Maar ook in dit geval kun je dat gewoon leeg laten en in plaats daarvan zien hoe zwak die bescherming is. omdat ASF zelf ook kan "kraken" binnen enkele seconden na het inloggen. Oeps.

Na het volgen van alles hierboven, dus nogmaals **bot naam**, **ingeschakeld schakelaar**, en **inloggegevens** , uw webpagina ziet er nu ongeveer hetzelfde uit als hieronder:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

U kunt nu op de "download" knop klikken en onze web-config generator zal een nieuw `json` bestand genereren gebaseerd op de gekozen naam. Sla dat bestand op in `config` map die zich bevindt in de map waarin je het zip-bestand in de vorige stap hebt uitgepakt.

Gefeliciteerd! Je hebt zojuist de zeer elementaire ASF bot configuratie voltooid. Er is nog veel meer te ontdekken, maar voor nu is dit alles wat je nodig hebt.

---

### Voer ASF uit

Ik weet dat je op dit moment hebt gewacht, en we kunnen je niet langer ophouden, omdat je nu klaar bent om het programma voor de eerste keer te starten. Dubbelklik `ArchiSteamFarm` binary in ASF map. Je kunt het ook starten vanaf de console.

Het zou nu een goed moment zijn om onze **[remote communicatie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** sectie te bekijken als je je zorgen maakt over dingen die ASF wil gaan doen. vooral acties die in je naam genomen zullen worden, zoals standaard deelnemen aan Steam-groep. Je kan de geselecteerde functies later altijd uitschakelen als je ze niet leuk vindt, ASF komt met een goede standaard, en we hebben wat besluiten moeten nemen over algemeen gebruik dat van toepassing is op de meerderheid van onze gebruikersbasis, evenals onze eigen visie op het programma in zijn principe.

Alles is goed gegaan, en overweegt om alle vereiste afhankelijkheden in de eerste stap te installeren. en ASF configureren in de derde instelling, ASF moet goed opstarten, je eerste bot ontdekken en proberen in te loggen:

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF zal waarschijnlijk nog één details van u nodig hebben - 2FA om toegang te krijgen tot de account (tenzij je SteamGuard volledig hebt uitgeschakeld, dan nee). Volg de instructies op het scherm, u kunt code van de authenticator/e-mail opgeven of de bevestiging accepteren in de mobiele app.

Er is iets misgegaan?

#### ASF start helemaal niet, geen console venster

Je mist .NET benodigdheden, of je hebt onjuiste ASF-variant voor je machine gedownload. Als je niet weet wat er fout is, bekijk onze **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** voor een mogelijke manier om het exacte probleem te achterhalen. en als je nog steeds vastzit, neem dan contact op met onze **[support](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### Geen bots gedefinieerd

Je hebt geen gegenereerde configuratie in de `config` map geplaatst. Sommige andere veelvoorkomende fouten in deze stap kunnen de extensie handmatig wijzigen van `.json` bijvoorbeeld naar `. xt`, en sommige besturingssystemen (bijv. Windows) zijn geschikt om standaard extensies te verbergen, dus zorg ervoor dat je bestand op de juiste plaats is en ook met de juiste naam.

#### Start deze bot niet omdat het uitgeschakeld is in het configuratiebestand

Je bent vergeten om de `Ingeschakelde` schakelaar om ASF automatisch te laten starten. Tenzij u dat natuurlijk uw bedoeling was, maar dan moet u al weten hoe u opdrachten moet uitvoeren. Start `` je bot na dat bericht.

#### `Ongeldig wachtwoord`

Uw inloggegevens zijn waarschijnlijk verkeerd. Controleer uw `SteamLogin` en `SteamPassword` in de gegenereerde configuratie, als ze verkeerd zijn, corrigeer ze door terug te gaan naar de configuratiestap. Als je nog steeds problemen hebt, probeer dan om dezelfde inloggegevens te gebruiken in je eigen Steam client - je moet ook niet inloggen en misschien krijg je op deze manier meer informatie over wat er mis is.

#### Allemaal goed?

Nadat je de eerste inlogpoort hebt doorlopen, ga je ervan uit dat je gegevens juist zijn, kun je met succes inloggen. en ASF zal starten met het verzamelen van standaardinstellingen waar je nu nog niet op hebt geklikt:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Dit bewijst dat ASF zijn werk nu met succes doet op je account, dus je kunt het programma nu minimaliseren en iets anders doen. Ga uw gang, u had het verdiend, misschien moet u het nog bijvullen wat uw keuze is!

Landbouw is een onderwerp voor een ander lang artikel als dit. maar in beginsel: na genoeg tijd (afhankelijk van **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), Je ziet dat Steam-handelskaarten langzaam worden afgestoten. Om dat te bereiken moet je natuurlijk geldige spelletjes op de boerderij hebben. laat zien als "je kan X meer kaarten krijgen tijdens het spelen van dit spel" op je **[badges pagina](https://steamcommunity.com/my/badges)** - als er geen spellen zijn om te farmen, dan zal ASF verklaren dat er niets te doen is. zoals gezegd in onze **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, die antwoord geeft op de meest voorkomende vragen die mensen op dit moment hebben. Vraag je af waarom ondanks het bezit van 14 spellen op hun account, ASF beweert dat er niets te doen is - nee, het is geen bug.

Hiermee zijn onze zeer basale handleiding beëindigd. Zoals in elk RPG spel, heb je de tutorial voltooid en laten we je nu de hele ASF wereld verkennen. U kunt nu bijvoorbeeld beslissen of u ASF verder wilt configureren, of dat het zijn werk doet in de standaardinstellingen. Als je nog wat meer wilt lezen, geef je nog een paar basisgegevens en laat je de hele wiki achter voor ontdekking.

---

### Uitgebreide configuratie

#### Verschillende accounts tegelijk verbouwen

ASF ondersteunt het verbouwen van meer dan één rekening tegelijk, wat de primaire functie is. Je kunt meer accounts toevoegen aan ASF door meer bot configuratie bestanden te genereren, precies zoals je je eerste nog maar een paar minuten geleden hebt gegenereerd. Je hoeft maar twee dingen te garanderen:

- Unieke bot naam, als je al je eerste bot genaamd `Hoofdaccount`hebt, kun je geen andere hebben met dezelfde naam.
- Geldige inloggegevens, zoals `SteamLogin`, `SteamPassword` en `SteamParentalCode` (als je hebt besloten deze in te vullen)

Met andere woorden, gewoon naar de configuratie gaan en precies hetzelfde doen, alleen voor je tweede of derde account. Vergeet niet om unieke namen voor al uw bots te gebruiken, om bestaande configuraties niet te overschrijven.

---

#### Instellingen wijzigen

In onze standalone web config-generator verander je bestaande instellingen op precies dezelfde manier - door een nieuw configuratiebestand te genereren. Klik op "schakel geavanceerde instellingen uit" en kijk wat u kunt ontdekken. In dit voorbeeld wijzigen we de instelling `CustomGamePlayedWhileFarming` , waarmee je een eigen naam kunt instellen die wordt weergegeven bij ASF in plaats van het werkelijke spel te tonen.

Laten we dit eerst analyseren. Als je ASF gebruikt en begint met keren, dan zal je in de standaard instellingen zien dat je Steam account nu in-game is:

![Steam](https://i.imgur.com/1VCDrGC.png)

Dat is zinvol, nadat ASF zojuist het Steam platform heeft verteld dat we het spel aan het spelen zijn, hebben we kaarten nodig, toch? Maar hij kan dit aanpassen! Schakel geavanceerde instellingen in als je nog niet klaar bent, en zoek dan `CustomGamePlayedWhileFarming`. Plaats gewoon een aangepaste tekst die je hier wilt weergeven, zoals "Idling kaarten":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Download nu het nieuwe configuratiebestand op precies dezelfde manier, dan **overschrijf** je oude configuratiebestand met de nieuwe. U kunt ook uw oude configuratiebestand verwijderen en de nieuwe op zijn plaats plaatsen natuurlijk.

ASF is erg slim en het zal merken dat je de configuratie hebt gewijzigd, die dan automatisch moeten oppakken en toepassen, zonder een programma opnieuw op te starten. Als er een kans is dat het niet is gebeurd, kunt u het programma gewoon opnieuw opstarten om ervoor te zorgen dat uw nieuwe configuratie is opgehaald. Daarna zou je moeten zien dat ASF nu je aangepaste tekst op de vorige plaats weergeeft:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

Dit bevestigt dat u met succes uw configuratie hebt bewerkt. Op precies dezelfde manier kun je de globale ASF-eigenschappen veranderen, door van het tabblad bot naar het tabblad ASF, gegenereerd `ASF te downloaden. son` config file and put it in your `config` directory.

Het bewerken van ASF configuraties kan veel gemakkelijker worden gedaan door gebruik te maken van onze ASF-ui frontend, die hieronder verder zal worden uitgelegd.

---

#### Gebruik ASF-ui

Zoals we eerder hebben gezegd, is ASF een console app en start standaard geen grafische gebruikersinterface. Maar we werken actief aan **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** frontend naar onze IPC interface dit kan een zeer goede en gebruiksvriendelijke manier zijn om toegang te krijgen tot verschillende ASF-functies.

Om ASF-ui, te kunnen gebruiken, moet je `IPC` ingeschakeld hebben dit is de standaardoptie, dus tenzij u deze handmatig uitschakelt, het is al actief. Zodra u ASF opstart, kunt u bevestigen dat de IPC interface automatisch is gestart

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC, in een notendop, is de webserver van ASF die lokaal begint op uw machine, geeft je de mogelijkheid om ermee te communiceren via je favoriete webbrowser. Assuming that it started correctly, you can access ASF's IPC interface by clicking **[this](http://localhost:1242)** link, as long as ASF is running, from the same machine. Je kunt ASF-ui gebruiken voor verschillende doeleinden, zoals het bewerken van de configuratiebestanden op de plaats of het verzenden van **[commando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Kijk gerust om je heen om alle ASF-ui functionaliteiten te ontdekken.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Summary

Je hebt ASF ingesteld om je Steam accounts te gebruiken en je hebt het al een beetje naar je zin aangepast. Als je onze hele handleiding gevolgd hebt, dan ben je er ook in geslaagd om ASF aan te passen via onze ASF-ui interface en begin je de functionaliteiten ervan te ontdekken. Dit concludeert onze tutorial, maar we laten je een aantal extra aanwijzers achter die je misschien interesseren, "kant opdrachten", als je wilt:

- Onze **[configuratie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** sectie zal u uitleggen wat **al die verschillende** instellingen die je gezien hebt ook hebben en wat ASF je nog meer kan bieden. Vergeet niet om tijdens het lezen goed te hydraten, u bent gewaarschuwd.
- Als je een probleem hebt opgelopen of algemene vragen hebt, denk dan aan onze **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**, die iedereen, of in ieder geval een overgrote meerderheid van de vragen en kwesties die u kunt hebben, moet behandelen.
- Als je alles wilt weten over ASF en hoe het je leven gemakkelijker kan maken, Ga naar de rest van **[onze wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. Gebruik de zijbalk aan de rechterkant om het onderwerp te kiezen dat je interesseert.
- En tot slot als je erachter kwam dat ons programma nuttig voor je zou zijn en je waardeert de enorme hoeveelheid werk die erin is gestoken. je kunt ook een kleine **[donatie](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** overwegen voor onze zaak. ASF is een arbeider van liefde, we hebben de afgelopen 10 jaar hard gewerkt in onze vrije tijd om deze ervaring mogelijk te maken voor jou, en we zijn er erg trots op - zelfs $1 is zeer gewaardeerd en laat zien dat het je iets kan schelen. Heb in ieder geval veel plezier!

---

## Algemene instellingen

This appendix is for advanced users that want to set up ASF to run in **[generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)** variant. Hoewel het lastiger is in gebruik dan **[OS-specifieke varianten](#os-specific-setup)**, heeft het ook extra voordelen.

Je wilt `generieke` variant voornamelijk gebruiken wanneer:
- Je gebruikt OS die we geen OS-specifiek pakket bouwen voor (zoals 32-bit Windows)
- Je hebt al .NET Runtime/SDK, of wil er één installeren en gebruiken
- Je wilt zelf de ASF structuur grootte en de geheugenvoetafdruk minimaliseren door de runtime vereisten af te handelen
- Je wilt een aangepaste **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** gebruiken die een `algemene` installatie van ASF nodig heeft om correct te werken (als gevolg van ontbrekende inheemse afhankelijkheden)

Natuurlijk kun je het ook gebruiken in elk ander scenario dat je wilt, maar het bovenstaande heeft het meeste zin.

Houd er echter rekening mee dat generieke instellingen voorzien van een draai - **u** is verantwoordelijk voor .NET runtime in dit geval. Dit betekent dat als je .NET SDK (runtime) niet beschikbaar is, verouderd of kapot is, ASF simpelweg niet zal werken. Daarom raden we deze configuratie helemaal niet aan voor toevallige gebruikers, want je moet er nu voor zorgen dat je . ET SDK (runtime) voldoet aan ASF-vereisten en kan ASF draaien, in tegenstelling tot **ons** ensure our . ET runtime gebundeld met ASF kan dit doen.

Voor `generieke` pakket, kun je hele OS-specifieke handleiding hierboven volgen, met slechts twee kleine wijzigingen. Naast het installeren van .NET vereisten, wil je ook .NET SDK installeren in plaats van OS-specifieke `ArchiSteamFarm(. . . xe)` uitvoerbaar bestand, je zult nu downloaden en een generieke `ArchiSteamFarm.dll` alleen hebben. Al het andere is precies hetzelfde.

Met extra stappen:
- Installeren **[.NET voorwaarden](#net-prerequisites)**.
- Installeer **[.NET SDK](https://www.microsoft.com/net/download)** (of ten minste ASP.NET Core en .NET runtimes) geschikt voor jouw besturingssysteem. Waarschijnlijk wilt u een installatieprogramma gebruiken. Raadpleeg **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** als je niet zeker weet welke versie je wilt installeren.
- Download **[nieuwste ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** in `algemene` variant.
- Verwijder het archief naar een nieuwe locatie.
- **[Configureer ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, op precies dezelfde manier als hierboven beschreven.
- Start ASF door een helper script te gebruiken of `dotnet /path/to/ArchiSteamFarm.dll` handmatig uit te voeren vanuit je favoriete shell.

Algemene variant van ASF heeft geen binaire machines, want het heet `generieke` voor een reden - het is platform-agnostisch bouwwerk dat overal kan werken, verwacht dus geen `exe` bestand daar.

Dit is waarom we het hebben gebundeld met helperscripts (zoals `ArchiSteamFarm.cmd` voor Windows en `ArchiSteamFarm. h` voor Linux/macOS), welke zich naast `ArchiSteamFarm.dll` binary bevinden. Je kan deze gebruiken als je geen `dotnet` commando handmatig wilt uitvoeren.

Helper scripts werken natuurlijk niet als u niet hebt geïnstalleerd. ET SDK en je hebt geen `dotnet` uitvoerbaar uitvoerbaar in je `PATH`. They're also entirely optional to use, you can always `dotnet /path/to/ArchiSteamFarm.dll` manually if you'd like to, as under the hood with some extra tweaks, that's exactly what those scripts are doing anyway.