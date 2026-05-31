# OSS

Vores grundlæggende OSS dækker standard spørgsmål og svar, som du måtte have. For en mindre almindelig sag, besøg i stedet vores **[udvidede FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ)**.

# Tabel med indhold

* [Generelt](#general)
* [Sammenligning med lignende værktøjer](#comparison-with-similar-tools)
* [Sikkerhed / Privatliv / VAC / Bans / ToS](#security--privacy--vac--bans--tos)
* [Diverse](#misc)
* [Problemer](#issues)

---

## Generelt

### Hvad er ASF?
### Hvorfor hævder programmet, at der ikke er noget at drive på min konto?
### Hvorfor registrerer ASF ikke alle mine spil?
### Hvorfor er min konto begrænset?

Før du forsøger at forstå, hvad ASF er, bør du sørge for, at du forstår, hvad Steam-kort er, og hvordan man får dem, som er pænt beskrevet i officielle FAQ **[her](https://steamcommunity.com/tradingcards/faq)**.

Kort sagt er Steam-kort samlerobjekter, som du er berettiget til, når du ejer et bestemt spil og kan bruges til at fremstille badges, sælge på Steam-markedet eller ethvert andet formål efter eget valg.

Her er der endnu en gang nævnt kernepunkter. fordi folk generelt ikke ønsker at være enige med dem og foretrækker at foregive, at de ikke eksisterer:

- **Du skal eje spillet på din Steam-konto for at være berettiget til eventuelle kortfald fra den. Familiedeling er ikke ejerskab og tæller ikke.**
- **Dit spil kan ikke markeres som [privat](https://help.steampowered.com/faqs/view/1150-C06F-4D62-4966), ASF vil automatisk springe sådanne spil over under opdræt.**
- **Du kan ikke drive spillet uendeligt, hvert spil har fast antal kort dråber. Når du droppe dem alle (omkring en halv af det fulde sæt), spillet er ikke en kandidat til landbrug længere. Det er ligegyldigt, om du har solgt, handlet, udformet eller glemt, hvad der skete med de kort, du har opnået, når du løber tør for kort dråber, er spillet færdig.**
- **Du kan ikke droppe kort fra F2P-spil uden at bruge penge på dem. Dette betyder permanent F2P spil som Team Fortress 2 eller Dota 2. Ejeren af F2P-spil giver dig ikke kortdråber.**
- **Du kan ikke droppe kort på [begrænsede konti](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)uanset ejede spil og deres metode til aktivering.**
- **Betalt spil, som du har opnået gratis under en kampagne kan ikke opdrættes for kort drops, uanset hvad der vises på butikken side.**

Så som du kan se, bliver Steam-kort tildelt dig for at spille et spil, du købte, eller F2P spil, som du har lagt penge i. Hvis du spiller sådan spil længe nok, vil alle kort til dette spil i sidste ende falde til din beholdning, gør det muligt for dig at fuldføre et badge (efter at have fået den resterende halvdel af sættet), sælge dem, eller gøre hvad som helst du vil.

Nu hvor vi har forklaret det grundlæggende i Steam, kan vi forklare ASF. Selve programmet er ret kompliceret at forstå fuldt ud, så i stedet for at grave ind i alle de tekniske detaljer, vil vi give en meget forenklet forklaring nedenfor.

ASF logger ind på din Steam-konto via vores indbyggede og tilpassede Steam-klientimplementering ved hjælp af dine angivne legitimationsoplysninger. Efter at have logget ind, det analyserer dine **[badges](https://steamcommunity.com/my/badges)** for at finde spil, der er tilgængelige for landbrug (`X` kort dråber tilbage). Efter parsing alle sider og konstruere endelige liste over spil, der er tilgængelige, vælger ASF mest effektive landbrug algoritme og starter processen. Processen afhænger af valgte **[kort opdræt algoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** , men normalt består det af at spille støtteberettigede spil og periodisk (plus på hvert element drop) kontrollere, om spillet er fuldt opdrættet allerede - hvis ja, ASF kan fortsætte med den næste titel, ved hjælp af samme procedure, indtil alle spil er fuldt opdrættet.

Husk på, at forklaringen ovenfor er forenklet og beskriver ikke dusin af ekstra funktioner og funktioner, som ASF tilbyder. Besøg resten af **[vores wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki)** , hvis du vil vide alle ASF detaljer. Jeg forsøgte at gøre det enkelt nok til at forstå for alle, uden at bringe i tekniske detaljer - avancerede brugere opfordres til at grave dybere.

Nu som et program - ASF tilbyder nogle magi. For det første behøver det ikke at downloade nogen af dine spilfiler, det kan spille spil med det samme. For det andet er det helt uafhængigt af din normale Steam-klient - du behøver ikke at have Steam-klienten kørende eller endda installeret overhovedet. For det tredje er det automatiseret løsning - hvilket betyder, at ASF automatisk gør alt bag ryggen, uden behov for at fortælle det, hvad du skal gøre - hvilket sparer dig besvær og tid. Endelig behøver det ikke at narre Steam-netværk ved procesemulering (som f.eks. Idle Master bruger), da det kan kommunikere med det direkte. Det er også super hurtig og let, at være en fantastisk løsning for alle, der ønsker at få kort nemt uden meget besvær - det kommer især nyttigt ved at lade det køre i baggrunden, mens du gør noget andet, eller endda spille i offline tilstand.

Alt det ovenstående er rart, men ASF har også nogle tekniske begrænsninger, der håndhæves af Steam - vi kan ikke drive spil, som du ikke ejer, vi kan ikke drive spil for evigt for at få ekstra dråber forbi den håndhævede grænse, og vi kan ikke drive spil, mens du spiller. Alt dette bør være "logisk", i betragtning af den måde, ASF fungerer, men det er rart at bemærke, at ASF ikke har super-beføjelser og vil ikke gøre noget, der er fysisk umuligt så husk det i tankerne - det er dybest set det samme, som hvis du fortalte nogen at logge ind på din konto fra en anden pc og gård disse spil for dig.

Så for at opsummere - ASF er et program, der hjælper dig med at slippe de kort, du er berettiget til, uden meget besvær. Det tilbyder også flere andre funktioner, men lad os holde fast i denne ene for nu.

---

### Skal jeg sætte mine kontooplysninger?

**Ja**. ASF kræver dine kontooplysninger på samme måde som den officielle Steam-klient gør, da den bruger den samme metode til Steam-netværksinteraktion. Dette betyder dog ikke, at du er nødt til at sætte din konto legitimationsoplysninger i ASF configs, du kan fortsætte med at bruge ASF med tom `SteamLogin` og/eller `SteamPassword`, og indtast disse data på hver ASF kørsel, når det er påkrævet (samt flere andre loginoplysninger, henvise til konfiguration). På denne måde bliver dine oplysninger ikke gemt nogen steder, men selvfølgelig kan ASF ikke autostart uden din hjælp. ASF tilbyder også flere andre måder at øge din **[sikkerhed](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**på, så er du velkommen til at læse den del af wikien, hvis du er avanceret bruger. Hvis du ikke er det, og du ikke ønsker at sætte dine kontooplysninger i ASF configs, så bare ikke gøre det, og i stedet indtaste dem efter behov, når ASF beder om dem.

Husk, at ASF værktøj er til din personlige brug og dine legitimationsoplysninger aldrig forlader din computer. Du deler dem heller ikke med nogen, som opfylder **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** - en meget vigtig ting, som mange mennesker glemmer om. Du sender ikke dine oplysninger til vores servere eller til en tredjepart, kun direkte til Steam-servere, der drives af Valve. Vi kender ikke dine legitimationsoplysninger, og vi er også i stand til at inddrive dem for dig, uanset om du sætter dem i dine konfigurationer eller ej.

---

### Hvor længe skal jeg vente på, at kortene slippes?

**Så længe det tager** - alvorligt. Hvert spil har forskellige landbrugsproblemer sat af udvikler/udgiver, og det er helt op til dem, hvor hurtige kort bliver droppet. Flertal af spillene følger 1 dråbe pr 30 minutter af spillet, men der er også spil, der kræver fra dig at spille selv flere timer, før du slipper et kort. Derudover kan din konto være begrænset til at modtage kortdråber fra spil, du ikke har spillet i tilstrækkelig tid endnu, som angivet i afsnittet **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Forsøg ikke at gætte, hvor længe ASF skal have en titel - det er ikke op til dig, hverken ASF at afgøre. Der er ikke noget, du kan gøre for at gøre det hurtigere, og der er ingen "fejl" relateret til kort ikke at blive droppet rettidigt - du kontrollerer ikke kort droppe proces, heller ikke ASF. I bedste fald får du i gennemsnit 1 dråbe pr. 30 minutter. I værste fald vil du ikke modtage noget kort selv i 4 timer siden du starter ASF. Begge disse situationer er normale og dækket af vores **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** sektion.

---

### Landbrug tager for lang tid, kan jeg på en eller anden måde fremskynde det?

Det eneste, der påvirker landbrugets hastighed voldsomt, er valgt **[kort opdræt algoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** for din bot instans. Alt andet har en ubetydelig virkning og vil ikke gøre landbruget hurtigere mens nogle handlinger såsom at starte ASF proces flere gange vil endda **gøre det værre**. Hvis De virkelig har en trang til at gøre hvert eneste sekund fra landbrugsprocessen så ASF giver dig mulighed for at finjustere nogle centrale landbrugsvariabler såsom `FarmingDelay` - alle af dem er forklaret i **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Men som sagt er virkningen ubetydelig, og vælge ordentlig kort landbrug algoritme for given konto er én og det eneste afgørende valg, der kan stærkt påvirke hastigheden af landbruget, alt andet er rent kosmetisk. I stedet for at bekymre sig om landbrugets hurtighed bare lancere ASF og lade det gøre sit arbejde - jeg kan forsikre dig om, at det gør det på den mest effektive måde, jeg kunne komme op med. Jo mindre du plejer, jo mere vil du være tilfreds.

---

### Men ASF sagde, at landbruget vil tage omkring X tid!

ASF giver dig grov tilnærmelse baseret på antallet af kort, du har brug for at tabe, og din valgte algoritme - dette er ingen steder tæt på den faktiske tid, som du vil bruge på landbrug, som normalt er længere end dette, da ASF kun antager bedste tilfælde og ignorerer alle Steam-netværks quirks, internetafbrydelser, overbelastning af Steam-servere og lign. Det skal kun ses som en generel indikator, hvor længe man kan forvente, at ASF er landbrug, meget ofte i bedste tilfælde, da den faktiske tid vil variere, selv betydeligt i nogle tilfælde. Som påpeget ovenfor, skal du ikke forsøge at gætte, hvor længe givet spil vil blive opdrættet, det er ikke op til dig, hverken ASF til at beslutte.

---

### Kan ASF arbejde på min Android/smartphone?

ASF er et C# program, der kræver arbejde implementering af .NET. Android blev en gyldig platform startende med .NET 6. , Men der er i øjeblikket en stor blokering i at gøre ASF ske på Android på grund af **[mangel på ASP. ET runtime tilgængelig på det](https://github.com/dotnet/aspnetcore/issues/35077)**. Selvom der ikke er en indbygget mulighed til rådighed, er der ordentlige og arbejder bygger til GNU/Linux på ARM-arkitektur, så det er helt muligt at bruge noget i retning af **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** til installation af Linux, derefter bruge ASF i sådan Linux chroot som sædvanligt.

Hvornår/Hvis alle ASF-krav er opfyldt, vil vi overveje at frigive en officiel Android build.

---

### Kan ASF farm elementer fra Steam-spil, såsom CS:GO eller Unturned?

**Nr.**Dette er imod **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** og Valve klart erklærede, at med sidste bølge af samfund forbud mod landbrug TF2 elementer. ASF er et Steam-kort landbrugsprogram, ikke spilelementer landmand - det har ikke nogen evne til landbrugsspil elementer, og det er ikke planlagt at tilføje en sådan funktion i fremtiden, nogensinde, primært på grund af overtrædelse af Steam-vilkår for brug. Spørg venligst ikke om dette - det bedste, du kan få, er en rapport fra nogle salte bruger og du har problemer. Det samme gælder for alle andre former for landbrug, såsom landbrug falder fra CS:GMO-udsendelser. ASF fokuserer udelukkende på Steam-handelskort.

---

### Kan jeg vælge, hvilke spil der skal opdrættes?

**Ja**på flere forskellige måder. Hvis du ønsker at ændre standard rækkefølgen af landbrug kø, så er det hvad `FarmingOrders` **[bot konfiguration ejendom](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** kan bruges til. Hvis du ønsker at manuelt sortliste givne spil fra at blive opdrættet automatisk, du kan bruge idle blacklist som er tilgængelig med `fb` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Hvis du gerne vil dyrke alt, men give nogle apps prioritet i forhold til alt andet, det er hvad idle prioriteret kø tilgængelig med `fq` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** kan bruges til. Og endelig, hvis du ønsker at drive specifikke spil af dit valg kun, derefter kan du erklære `FarmPriorityQueueOnly` i bot's **[`FarmingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)** for at opnå dette, sammen med tilføjelse af dine udvalgte apps til at gøre køen inaktiv i prioritet.

Ud over at styre automatisk kortopdræt modul, som blev beskrevet ovenfor, du kan også skifte ASF til manuel landbrugstilstand med `afspil` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, eller brug andre eksterne indstillinger som `GamesPlayedWhileIdle` **[bot konfigurationsejendom](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

---

### Jeg er ikke interesseret i kort-dråber, jeg vil gerne gård timer spilles i stedet, er det muligt?

Ja, ASF giver dig mulighed for at gøre det på mindst flere måder.

Den bedste måde at opnå det på er at gøre brug af **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** konfigurationsegenskab, som vil spille dine valgte appIDs, når ASF ikke har nogen kort til at gårde. Hvis du gerne vil spille dine spil hele tiden, selv hvis du har kort dråber fra andre spil, så kan du kombinere det med **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, så ASF vil kun drive de spil for kort drops, som du udtrykkeligt har angivet, eller alternativt, **[`FarmingPausedByDefault`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, hvilket vil få kortene til at blive sat på pause indtil du afbrød det selv.

Du kan også gøre brug af kommandoen **[`afspil`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#commands-1)** , hvilket vil få ASF til at spille dine valgte spil. Husk dog på, at `spil` kun bør bruges til spil, du ønsker at spille midlertidigt, da det ikke er en vedvarende tilstand, forårsager ASF til at vende tilbage til standardtilstand e. . ved frakobling fra Steam-netværket. Derfor anbefaler vi, at du bruger `GamesPlayedWhileIdle`, medmindre du rent faktisk ønsker at starte dine valgte spil bare for en kort periode, og derefter vende tilbage til generelle flow.

---

### Jeg er Linux / macOS bruger, vil ASF farm spil, der ikke er tilgængelige for mit OS? Vil ASF farm 64-bit spil, når jeg kører det på 32-bit OS?

Ja, ASF er ikke engang gider med at downloade faktiske spilfiler, så det vil fungere med alle dine licenser bundet til din Steam-konto, uanset platforme eller tekniske krav. Det bør også arbejde for spil bundet til bestemte region (regionslåste spil), selv når du ikke er i det matchende område, selvom vi ikke garanterer, at (det virkede sidste gang, vi forsøgte).

---

## Sammenligning med lignende værktøjer

---

### Ligner ASF Idle Master?

Den eneste lighed er det generelle formål med begge programmer, som er landbrug Steam-spil for at modtage kort dråber. Alt andet, herunder den faktiske landbrugsmetode, program struktur, funktionalitet, kompatibilitet, brugte algoritmer, især kildekoden selv, er helt anderledes, og disse to programmer har intet fælles med hinanden, selv kernen fundamentet - IM kører på . ET Framework, ASF on .NET (kerne). ASF blev oprettet for at løse IM-problemer, der ikke var muligt at løse med en simpel kode redigere - det er derfor, ASF blev skrevet fra bunden, uden at bruge en enkelt kode linje eller endda generel idé fra IM, fordi denne kode og disse ideer var helt fejlbehæftet til at begynde med. IM og ASF er ligesom Windows og Linux - begge er operativsystemer og begge kan installeres på din PC, men de deler næsten intet med hinanden, bortset fra at tjene det lignende formål.

Det er også grunden til, at du ikke bør sammenligne ASF med IM baseret på IM forventninger. Du bør behandle ASF og IM som helt uafhængige programmer med deres egne eksklusive sæt af funktioner. Nogle af dem faktisk overlapper hinanden, og du kan finde et særligt træk i dem begge, men meget sjældent, da ASF tjener sit formål med en helt anden tilgang end IM.

---

### Er det værd at bruge ASF, hvis jeg i øjeblikket bruger Idle Master og det virker fint for mig?

**Ja**. ASF er meget mere pålidelig og indeholder mange indbyggede funktioner, der er **afgørende** uanset hvordan du gård, at IM simpelthen ikke tilbyder.

ASF har en passende logik for **ikke-frigivne spil** - IM vil forsøge at drive spil, der har tilføjet allerede kort selv om de ikke blev frigivet endnu. Selvfølgelig er det ikke muligt at drive disse spil indtil frigive dato, så din landbrugsproces vil være fast. Dette kræver, at du enten føjer den til sortlisten, venter på udgivelse, eller springe over manuelt. Ingen af disse løsninger er gode, og alle af dem kræver din opmærksomhed - ASF automatisk springer landbrug af ufrigivne spil (midlertidigt) og vender tilbage til dem senere, når de er, helt undgå problemet og håndtere det effektivt.

ASF har også en passende logik i **serie** videoer. Der er mange videoer på Steam, der har kort, men som er annonceret med forkert `appID` på badges siden, såsom **[Double Fine Adventure](https://store.steampowered.com/app/402590)** - IM vil fejlagtigt opdrætte forkerte `appID`som ikke vil give nogen dråber og proces bliver stukket. Endnu en gang skal du enten sortliste den eller springe manuelt, begge kræver din opmærksomhed. ASF opdager automatisk korrekt `appID` for landbrug, hvilket resulterer i kort dråber.

Ud over det, ASF er **meget mere stabil og pålidelig** når det kommer til netværksproblemer og Steam quirks - det virker det meste af tiden og kræver slet ikke din opmærksomhed på én gang konfigureret, mens IM ofte pauser for mange mennesker, kræver ekstra rettelser eller simpelthen ikke virker uanset. Den er også helt afhængig af din Steam-klient, hvilket betyder, at den ikke kan fungere, når din Steam-klient oplever alvorlige problemer. ASF fungerer korrekt, så længe det kan oprette forbindelse til Steam-netværket, og kræver ikke Steam-klienten kører eller endda bliver installeret.

Disse er 3 **meget vigtige** punkter, hvorfor du bør overveje at bruge ASF da de direkte påvirker alle landbrug Steam-kort, og der er ingen måde at sige "dette ikke overveje mig", da Steam-vedligehold og quirker sker for alle. Der er dusin af ekstra mindre og vigtigere grunde, som du kan lære om i resten af FAQ. Så om kort tid, **ja**, du skal bruge ASF, selv når du ikke har brug for nogen ekstra ASF-funktion, der er tilgængelig i forhold til IM.

Derudover afbrydes infrastrukturforvalteren officielt og kan bryde helt i fremtiden uden nogen gider at ordne det, overvejer eksistensen af meget mere kraftfulde løsninger (ikke kun ASF). IM virker allerede ikke for mange mennesker, og det tal går kun op, ikke ned. Du bør undgå at bruge forældet software i første omgang, ikke kun IM men alle andre forældede programmer samt. Ingen aktiv vedligeholder betyder, at ingen bekymrer sig om, hvorvidt det virker eller ej, og **ingen er ansvarlig for dets funktionalitet**, som er et afgørende spørgsmål med hensyn til sikkerhed. Det er nok, at der vil være en kritisk fejl, der forårsager faktiske problemer til Steam-infrastruktur - med ingen fastsættelse det, Steam kan udstede en anden bandlysningsbølge, hvor du vil blive ramt uden selv at være klar over, at dette er et problem, som det allerede er sket for folk, der bruger, gæt hvad, forældet version af ASF.

---

### Hvilke interessante funktioner tilbyder ASF, at Idle Master ikke?

Det afhænger af, hvad du anser for at være "interessant" for dig. Hvis du planlægger at drive flere konti end en så svaret er allerede indlysende, da ASF giver dig mulighed for at drive dem alle med en overlegen løsning, spare ressourcer, besvær og kompatibilitetsproblemer. Men hvis du stiller det spørgsmål, så sandsynligvis du ikke har dette særlige behov, så lad os evaluere andre fordele, der gælder for en enkelt konto, der anvendes i ASF.

Først og fremmest du har nogle indbyggede funktioner nævnt **[over](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** , der er kernen i landbruget uanset dit mål og meget ofte er det alene allerede nok til at overveje at bruge ASF. Men du ved allerede, at, så lad os flytte ind på nogle mere interessante funktioner:

- **Du kan farm offline** (`OnlineStatus` i `Offline` indstilling). Farming offline gør det muligt for dig at springe din Steam-in-game status helt over som giver dig mulighed for at gårde med ASF, mens du viser "Online" på Steam på samme tid, uden dine venner selv bemærke, at ASF spiller et spil på dine vegne. Dette er overlegen funktion, da det giver dig mulighed for at forblive online i din Steam-klient, mens du ikke irriterer dine venner med konstante ændringer i spillet, eller vildlede dem til at tro, at du spiller et spil, mens i virkeligheden er du ikke. Dette punkt alene gør det umagen værd at bruge ASF, hvis du respekterer dine egne venner, men det er kun begyndelsen. Det er også rart at bemærke, at denne funktion ikke har noget at gøre med Steam privatlivsindstillinger - hvis du starter spillet selv, så vil du vise dig som in-game til dine venner, hvilket kun gør ASF del usynlig og ikke påvirker din konto overhovedet.

- **Du kan springe refunderbare spil** (`SkipRefundableGames` i bot's `FarmingPreferences` funktion). ASF har ordentlig indbygget logik for refunderbare spil, og du kan konfigurere ASF til ikke at drive refunderbare spil automatisk. Dette giver dig mulighed for at evaluere dig selv, hvis dit nyligt købte spil fra Steam-butikken var dine penge værd. uden ASF forsøger at slippe kort fra det så hurtigt som muligt. Hvis du spiller det i 2 + timer, eller 2 uger pass siden dit køb, ASF vil fortsætte med dette spil, da det ikke kan refunderes længere. Indtil da har du fuld kontrol over, om du nyder det eller ej, og du kan nemt refundere det, hvis det er nødvendigt. uden at skulle manuelt sortliste det spil eller ikke bruge ASF for hele varigheden.

- **Du kan springe uspillede spil** (`SkipUnplayedGames` i bot's `FarmingPreferences` -funktion). ASF har korrekt indbygget logik i timevis i spil, og du kan konfigurere ASF til ikke at farm uspillede spil automatisk. Dette giver dig mulighed for at styre dig selv de spil, du spiller og gård, uden at skulle manuelt sortliste dem alle eller springe ved hjælp af ASF helt.

- **Du kan automatisk markere nye elementer som modtaget** (`BotBehaviour` af `DismissInventoryNotifications` funktion). Landbrug med ASF vil resultere i, at din konto modtager nye kortdråber. Du ved allerede, at dette vil ske, så lad ASF klart, at ubrugelig meddelelse til dig, at sikre, at kun vigtige ting vil øge Deres opmærksomhed. Selvfølgelig kun hvis du vil.

- **Du kan tilpasse foretrukne landbrugsordre med flere tilgængelige muligheder** (`FarmingOrders` funktion). Måske du ønsker at gårde dine nykøbte spil først? Eller dine ældste? Ifølge antallet af kort dråber? Badge niveauer du allerede har fremstillet? Spillede timer? Alfabetisk? I henhold til AppIDs? Eller måske helt tilfældigt? Det er helt op til jer at beslutte.

- **ASF kan hjælpe dig med at fuldføre dine sæt** (`TradingPreferences` med `SteamTradeMatcher` -funktion). Med lidt mere avanceret tinkering du kan konvertere din ASF til fuldt udstyret bruger-bot, der automatisk accepterer **[STM](https://www.steamtradematcher.com)** tilbud, hjælpe dig hver dag til at matche dine sæt uden nogen brugerinteraktion. ASF indeholder endda sin helt egen ASF 2FA-modul, så du kan importere din Steam-mobil autentificering og lade dig fuldt ud automatisere hele processen med at acceptere bekræftelser så godt. Eller måske vil du acceptere manuelt og lade ASF kun forberede disse handler for dig? Det er igen helt op til jer at beslutte.

- **ASF kan indløse nøgler i baggrunden for dig** (**[baggrundsspil indløsning](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** funktion). Måske har du hundrede nøgler fra forskellige pakker, som du er for doven til at indløse dig selv, gå gennem en masse vinduer og acceptere Steam-vilkår og betingelser igen og igen. Hvorfor ikke kopiere indsætte din liste over nøgler i ASF og lade det gøre sit job? ASF vil automatisk indløse alle disse nøgler i baggrunden, giver dig passende output til at lade dig vide, hvordan hvert indløse forsøg viste sig. Desuden, hvis du har hundredvis af nøgler, er du garanteret at få rate-begrænset af Steam før eller senere og ASF ved også om det, det vil tålmodigt vente på, at hastighedsgrænsen går væk, og genoptage hvor det går.

Vi kunne nu fortsætte med hele **[ASF wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**, påpege hver enkelt funktion af programmet, men vi er nødt til at tegne en linje et eller andet sted. Dette er det, dette er en liste over funktioner, som du kan nyde som ASF bruger, hvor bare en af dem let kunne betragtes som en væsentlig grund til aldrig at se tilbage, og vi har faktisk opført **en masse** af dem, med endnu mere kan du lære om på resten af vores wiki. Ah ja, og vi gik ikke engang i detaljer med ting som ASF's API giver dig mulighed for at script dine egne kommandoer, eller awesome bots ledelse, da vi ønskede at holde det enkelt.

---

### Er ASF hurtigere end Idle Master?

**Ja**, selvom forklaringen er temmelig kompliceret.

På hver ny proces opfostrede og afsluttet på dit system, dampklienten sender automatisk en anmodning, der indeholder alle dine spil, som du spiller i øjeblikket - på denne måde kan dampnetværket beregne timer og få kortene til at falde. Dampnetværk tæller dog din tid spillet med 1 sekunders intervaller, og afsendelse af ny anmodning nulstiller den aktuelle status. Med andre ord, hvis du gjorde spawn/kill ny proces hvert 0,5 sekund, ville du aldrig slippe noget kort, fordi hver 0. anden damp klient ville sende en ny anmodning og damp netværk ville aldrig tælle selv 1 sekund spilletid. Desuden, på grund af hvordan operativsystemet fungerer, er det faktisk ret almindeligt at se nye processer blive spawned/afsluttet uden at du selv gør noget, så selvom du ikke gør noget på din pc - der er mange processer, der stadig arbejder i baggrunden, gyde/afslutter andre processer hele tiden. Idle master er baseret på damp klient, så denne mekanisme påvirker dig, hvis du bruger det.

ASF er ikke baseret på damp klient, det har sin egen damp klient implementering. Takket være det, hvad ASF gør, er ikke gyde nogen proces, men faktisk sende en, reel anmodning til damp netværk, som vi begyndte at spille et spil. Dette er den samme anmodning, der ville blive sendt af damp klient, men fordi vi har faktisk kontrol over ASF damp klient, behøver vi ikke at gyde nye processer, og vi efterligner ikke damp klient med hensyn til at sende anmodning om hver proces ændring, så mekanismen forklaret ovenfor påvirker os ikke. Takket være det, afbryder vi aldrig det 1 sekund interval på steam, og det øger vores landbrugs hastighed.

---

### Men er forskellen virkelig mærkbar?

Nej. De afbrydelser, der sker med normal damp klient og tomgang master har ubetydelig effekt på kortet dråber, så det ikke er nogen mærkbar forskel, der ville gøre ASF overlegen.

Men der **er** en forskel, og du kan tydeligt bemærke, at, afhængigt af hvor travlt dit operativsystem er, kort **vil** falde hurtigere, fra et par sekunder til endda et par minutter, hvis du er meget uheldig. Selv om jeg ikke ville overveje at bruge ASF kun fordi det falder kort hurtigere, da både ASF og Idle Master er påvirket af, hvordan damp web fungerer, ASF bare interagerer med damp web mere effektivt, mens Idle Master ikke kan styre, hvad damp klient rent faktisk gør (så det er ikke Idle Master's skyld, men damp klientens selv).

---

### Kan ASF drive flere spil på én gang?

**Ja**, selvom ASF ved bedre hvornår denne funktion skal anvendes, baseret på den valgte **[kort farming algoritme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Kort falder sats, når landbrug flere spil er tæt på nul, Det er derfor, ASF bruger flere spil landbrug udelukkende i timevis for at overvinde `HoursUntilCardDrops` hurtigere, for op til `32` spil på én gang. Det er også derfor, du bør fokusere på konfigurationen del af ASF og lad algoritmer beslutte, hvad der er den bedste måde at nå målet - hvad du synes er rigtigt, er ikke nødvendigvis ret i virkeligheden, landbrug flere spil på én gang vil ikke give dig nogen kortdråber.

---

### Kan ASF springe igennem spil hurtigt?

**Nej**, ASF understøtter ikke og opfordrer heller ikke til brug af **[Steam glitches](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance#steam-glitches)**.

---

### Kan ASF automatisk spille hvert spil i X timer, før kortene tilføjes?

**Nej**, hele punktet af Steam-kort system ændring var at kæmpe med falske statistikker og spøgelse spillere. ASF vil ikke bidrage til, at mere end nødvendigt, tilføje en sådan funktion er ikke planlagt og vil ikke ske. Hvis dit spil får kort-dråber på sædvanlig måde, vil ASF opdrætte dem så hurtigt som muligt.

---

### Kan jeg spille et spil, mens ASF landbruger?

**Nr.**. ASF har i modsætning til nogle andre værktøjer, der integreres med din Steam-klient, sin uafhængige implementering af denne klient inkluderet. og Steam-netværket tillader kun **én Steam-klient ad gangen** at spille et spil. Du kan dog afbryde forbindelsen til ASF, når som helst du vil, ved at starte et spil (og klikke på "OK", når du bliver spurgt om Steam-netværket skal afbryde forbindelsen til en anden klient) - ASF vil derefter tålmodigt vente til du er færdig med at spille, og genoptage processen bagefter. Alternativt kan du stadig spille i offline tilstand når som helst du vil, hvis det er tilfredsstillende for dig.

Husk på, at kortene falder sats, når du spiller flere spil er tæt på nul alligevel, der er derfor ingen direkte fordele ved at kunne gøre det med andre værktøjer — mens der er stærke fordele ved ikke at blande sig med andre spil lanceret med ASF, som er afgørende e. VAC-klogt.

---

## Sikkerhed / Privatliv / VAC / Bans / ToS

---

### Kan jeg få VAC forbud for at bruge dette?

Nej, det er ikke muligt, fordi ASF (i modsætning til nogle andre værktøjer, såsom Idle Master, SGI eller SAM) blander sig ikke på nogen måde i dampklienten eller dets processer. Det er fysisk umuligt at få VAC forbud for at bruge ASF, Selv under afspilning på sikrede servere, mens ASF kører - dette skyldes, at **ASF ikke engang kræver, at Steam-klienten er installeret på alle** for at fungere korrekt. ASF er et af de eneste få landbrugsprogrammer, der i øjeblikket kan garantere at være VAC-fri.

---

### Kan ASF forhindre mig i at spille på VAC-sikrede servere, som angivet **[her](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**?

ASF kræver ikke, at Steam-klienten kører eller endda er installeret overhovedet. Ifølge dette begreb, bør **ikke** forårsage VAC-relaterede problemer, fordi ASF garanterer manglende indblanding i Steam-klienten og alle dens processer - dette er det vigtigste punkt, når der tales om VAC-fri garanti for, at ASF tilbyder.

Ifølge brugerne og bedst af min viden, dette er tilfældet lige nu, da ingen rapporterede nogen problemer som angivet i linket ovenfor, mens du bruger ASF. Vi kunne ikke reproducere spørgsmålet ovenfor med ASF så godt, mens klart gengive det med Idle Master.

Men husk på, at ventilen stadig kunne tilføje ASF til sortlisten på et tidspunkt, men det er en komplet nonsens, som selv om de gør det, du kan stadig spille VAC-sikrede spil fra din pc, og bruge ASF på samme tid e. På din server, så jeg er temmelig sikker på, at de ved meget godt, at ASF ikke bør være en mistænkt VAC-wise, og de vil ikke gøre vores liv sværere ved at sortliste ASF uden grund. Stadig, i værste fald vil du ikke være i stand til at spille, som nævnt ovenfor, fordi VAC-fri garanti for ASF stadig er her, uanset om Steam sortlister ASF binær eller ikke (og du kan stadig starte ASF på en anden maskine, uden at Steam-klienten overhovedet er installeret). Lige nu er der ingen grund til at gøre noget af det, og lad os håbe, at det forbliver sådan.

---

### Er det sikkert?

Hvis du spørger, om ASF er sikker som en software, hvilket betyder, at det ikke vil forårsage nogen skade på din computer, vil ikke stjæle dine private data, installere virus eller andre ting som det - det er sikkert. ASF er fri for malware, data stjæle, cryptocurrency minearbejdere og enhver (og alle) anden tvivlsom adfærd, der kan betragtes som skadelig eller uønsket af brugeren. Ud over at vi har en dedikeret **[fjernkommunikation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** -sektion, der dækker vores privatlivspolitik og ASF-adfærd, der går ud over, hvad du konfigurerede programmet til at gøre dig selv.

Vores kode er open source, og distribuerede binære filer er altid udarbejdet af **[offentligt tilgængelige kilder](https://en.wikipedia.org/wiki/Open-source_software)** af **[automatiserede og betroede kontinuerlige integrationssystemer](https://en.wikipedia.org/wiki/Build_automation)**, og ikke engang udviklere selv. Hver bygning er reproducerbar ved at følge vores build script og vil resultere i nøjagtig den samme, **[deterministic](https://en.wikipedia.org/wiki/Deterministic_system)** IL (binære) kode. Hvis du af en eller anden grund ikke stoler på vores bygninger, kan du altid kompilere og bruge ASF fra kilden, herunder alle biblioteker, ASF bruger (såsom SteamKit2), som også er open source.

I sidste ende er det dog altid et spørgsmål om tillid til udviklerne af din ansøgning, så du bør selv beslutte, om du anser ASF for sikker eller ej, hvilket potentielt understøtter din beslutning med de tekniske argumenter, der er angivet ovenfor. Tro ikke blindt kun på noget, fordi vi sagde det - tjek dig selv, da det er den eneste måde at sikre dig på.

---

### Kan jeg få forbudt for dette?

For at besvare dette spørgsmål, bør vi tage et nærmere kig på **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Steam forbyder ikke brug af flere konti, faktisk, **[det tillader det](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)** antyder, at du kan bruge samme mobil autentificering på mere end én konto. Hvad det dog ikke tillader er at dele konti med andre mennesker, men vi gør det ikke her.

Det eneste reelle punkt, der betragter ASF, er følgende:
> Du må ikke bruge Snyd, automatisering software (bots), mods, hacks, eller nogen anden uautoriseret tredjeparts software, til at ændre eller automatisere nogen Abonnement Marketplace proces.

Spørgsmålet er, hvad der i virkeligheden er Abonnementsmarkedspladsprocessen. Som vi kan læse:

> Et eksempel på et abonnementsmarked er Steam-fællesskabsmarkedet

Vi ændrer ikke eller automatiserer ikke abonnement marketplace proces, hvis ved abonnement marketplace vi forstår damp community marked eller damp butik. Men ...

> Ventilen kan til enhver tid annullere din konto eller et bestemt abonnement i tilfælde af, at (a) Ventilen ophører med at give sådanne abonnementer til lignende beliggende Abonnenter generelt, eller (b) du bryder alle vilkår i denne aftale (herunder eventuelle Abonnementsvilkår eller regler for brug).

Derfor, som for alle Steam-software, ASF er ikke godkendt af Valve, og jeg kan ikke garantere, at du ikke vil blive suspenderet, hvis Valve pludselig beslutter, at de vil forbyde konti ved hjælp af ASF nu. Dette er ekstremt usandsynligt i betragtning af det faktum, at ASF bliver brugt på mere end et par millioner af Steam-konti, siden sin første udgivelse, der skete for over 10 år siden - men stadig en mulighed, uanset den faktiske sandsynlighed.

Fordi:
> For så vidt angår alle abonnementer, indhold og tjenester, der ikke er forfattet af ventil Ventilen viser ikke sådant tredjepartsindhold tilgængeligt på Steam eller via andre kilder. Ventilen påtager sig intet ansvar for tredjepartsindholdet. Nogle tredjeparts applikationssoftware er i stand til at blive brugt af virksomheder til forretningsformål - dog, du må kun erhverve sådan software via Steam til privat brug.

Ventilen anerkender imidlertid tydeligt "Steam-midler", der eksisterer, som anført **[her](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**, så hvis du spurgte mig, Jeg er temmelig sikker på, at hvis de ikke var fint med dem, ville de allerede gøre noget i stedet for at påpege, at de kunne forårsage problemer VAC-wise. Nøgleordet her er **Steam** pers, for eksempel ASF, og ikke **spil** pers.

Bemærk venligst, at ovenstående kun er vores fortolkning af **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** og forskellige punkter - ASF er licenseret under Apache 2. Licenser, der tydeligt angiver:

```
Medmindre det kræves i henhold til gældende lov eller er indvilliget i skriftligt at distribuere software
, der distribueres under licensen, på et "AS IS" BASIS,
UDEN SÆRLIGE ANTIER ELLER BETINGELSER FOR EN KIND, enten udtrykkelig eller underforstået.
```

Du bruger denne software på egen risiko. Det er ekstremt usandsynligt, at du kan få forbudt for det, men hvis du gør, kan du kun bebrejde dig selv for det.

---

### Har nogen fået forbudt for det?

**Ja**, vi havde mindst et par hændelser indtil videre, der resulterede i en form for Steam suspension. Uanset om ASF selv var hovedårsagen eller ej, er helt anderledes historie, som vi sandsynligvis aldrig vil få at vide.

Første sag involveret en fyr med over 1000+ bots få handel forbudt (sammen med alle bots), sandsynligvis på grund af overdreven brug af `loot ASF` udført på alle bots på én gang, eller andre mistænkelige ensidige mængder af handler på meget kort tid.

> Hej XXX, Tak fordi du kontaktede Steam Support. Det ser ud til, at denne konto blev brugt til at administrere et netværk af bot-konti. Botting er en overtrædelse af Steam-abonnentaftalen.

Brug venligst nogle sunde fornuft og antager ikke, at du kan gøre sådanne skøre ting, kun fordi ASF giver dig mulighed for at gøre det. Gør `loot ASF` på over 1k af bots kan nemt betragtes som et **[DDoS](https://en.wikipedia.org/wiki/DDoS)** angreb, og personligt er jeg ikke chokeret, at nogen fik forbudt for sådan en ting. Hold minimum af fair brug i forhold til Steam-tjenesten, og **sandsynligvis** vil du være fin.

Anden sag involveret en fyr med 170 + bots bliver forbudt under Steam's 2017 Winter Sale.

> Din konto blev spærret for overtrædelse af aftalen med abonnenten Steam. At dømme efter børserne og andre faktorer, denne konto blev brugt til ulovligt at indsamle samlekort på Steam, samt beslægtede og ikke kun kommercielle aktiviteter. Kontoen er blevet permanent spærret, og Steam Support kan ikke yde yderligere support i dette spørgsmål.

Denne sag er igen meget svært at analysere, på grund af vage svar fra Steam-support, der knap giver nogen detaljer. Baseret på mine personlige tanker, denne bruger sandsynligvis udvekslet Steam-kort for en slags penge (niveau op bot? eller på anden måde forsøgt at udbetale på Steam. Hvis du var uklar, er dette også ulovligt i henhold til **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Vi er ikke i stand til at fortælle dig, hvad du kan gøre med de visitkort opnået gennem ASF - men den pågældende bruger absolut ikke bare håndværk badges med dem.

Tredje sag involverede bruger med 120+ bots bliver forbudt for overtrædelse af **[Steam online adfærd](https://store.steampowered.com/online_conduct?l=english)**.

> Hej XXX, Tak fordi du kontaktede Steam Support. Dette og andre konti blev brugt til at oversvømme vores netværksinfrastruktur, hvilket er en overtrædelse af Steam-online-adfærd. Kontoen er blevet permanent spærret, og Steam Support kan ikke yde yderligere support i dette spørgsmål.

Denne sag er lidt lettere at analysere på grund af ekstra detaljer fra brugeren. Tilsyneladende brugte brugeren **en meget forældet ASF-version** , der omfattede en fejl, der forårsagede ASF til at sende for mange anmodninger til Steam-servere. Selve fejlen eksisterede ikke i første omgang, men blev aktiveret på grund af Steam-skift som blev rettet i den fremtidige version. **ASF understøttes kun i [seneste stabile version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) udgivet på GitHub**.

Du kan ikke antage, at en forældet ASF version vil fungere den samme som den bruges til at arbejde for evigt, især fordi Steam konstant ændrer sig, uanset om du kan lide det eller ej. Hvis sådan noget sker globalt, er det hurtigt at blive lappet op og udgivet til alle brugere som en fejlrettelse. Ventilen vil ikke pludselig forbyde over en million ASF-brugere på grund af vores eller deres fejl, af indlysende årsager. Men hvis du forsætligt fratræder dig fra at bruge opdateret ASF derefter pr. definition er du i et meget lille mindretal af brugere, der er **udsat for hændelser som disse** på grund af **ingen support**, da der ikke er nogen, der overvåger din forældede version af ASF ingen fastsættelse af det, og ingen sikrer, at du ikke får direkte forbudt ved blot at lancere det. **Brug venligst up-to-date software**, ikke kun ASF, men også alle andre programmer.

Det seneste tilfælde skete omkring juni 2021, ifølge brugeren:

> Ved hjælp af dit program, har jeg lavet booster pakker med 28 konti i 3 år og med 128 konti for de sidste 6 måneder. Jeg var online med maksimalt 15 konti samtidigt for at lave booster pakker og sende dem til hovedkontoen. I sidste måned øgede jeg antallet af online-konti til 20 og 1 uge efter at alle mine konti blev forbudt. Denne e-mail er ikke at bebrejde dig, tværtimod, jeg var altid klar over konsekvenserne. Jeg ville have jer til at vide, hvilke typer af adfærd resulterer i et permanent forbud.

Det er svært at sige, om stigningen i samtidige konti online var den direkte årsag til forbuddet, Jeg ville ikke regne med det, i stedet mener jeg, at antallet af konti alene var den største synder, øget concurrency af online-konti sandsynligvis bare gjort opmærksom på den pågældende bruger, da han tydeligvis havde langt flere robotter end vores anbefaling.

---

Alle ovenstående hændelser har én ting til fælles - ASF er blot et værktøj, og det er **din** beslutning om, hvordan du vil gøre brug af det. Du får ikke forbudt for at bruge ASF direkte, men for **hvordan** du bruger det. Det kan kun være en enkelt konto eller et massivt landbrugsnetværk fremstillet af tusindvis af bots. Under alle omstændigheder tilbyder jeg ikke juridisk rådgivning, og du bør beslutte dig selv om din ASF brug i første omgang. Jeg gemmer ikke nogen oplysninger, der kan hjælpe dig, f.eks. det forhold, at ASF fik nogle mennesker forbudt (og i hvilken sammenhæng) da jeg ikke har nogen grund til - det er dit valg, hvad du ønsker at gøre med disse oplysninger.

Hvis du spørger mig - brug nogen sund fornuft, undgå at eje flere robotter end vores anbefaling, sende ikke hundredvis af handler på samme tid, altid bruge up-to-date ASF version og du _bør_ være fint. Hver eneste hændelse af denne art for **en eller anden grund** altid skete for folk, der har ignoreret vores anbefalinger, bedste praksis og forslag, tro, at de ved bedre end os e. . hvor mange bots de kan køre. Uanset om det bare er en tilfældighed eller en reel faktor, er det op til dig at beslutte. Vi tilbyder ikke nogen juridisk rådgivning, kun give dig vores tanker, som du kan finde nyttige, eller se bort fra dem helt og kun fungere på grundlag af ovennævnte kendsgerninger.

---

### Hvilke oplysninger om privatlivets fred giver ASF?

Du kan finde detaljeret forklaring i afsnittet **[fjernkommunikation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. Du bør gennemgå det, hvis du bekymrer dig om dine personlige oplysninger, f.eks. hvis du spekulerer på, hvorfor konti bruges i ASF, deltager i vores Steam-gruppe. ASF indsamler ikke følsomme oplysninger, og deler ikke det med nogen tredjeparter.

---

## Diverse

---

### Jeg bruger ikke understøttet OS såsom 32-bit Windows, kan jeg stadig bruge den nyeste version af ASF?

Ja, og denne version er ikke uunderstøttet på nogen måde, bare ikke officielt bygget. Tjek **[kompatibilitet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** sektion for generiske varianter. ASF har ingen stærk afhængighed af OS, og det kan arbejde hvor som helst du kan få et arbejde. ET runtime, som omfatter 32-bit Windows, selv om der ikke er nogen `win-x86` OS-specifik pakke fra os.

---

### ASF er stor! Kan jeg donere?

Ja, og vi er meget glade for at høre, at du nyder vores projekt! Du kan finde forskellige donationsmuligheder under alle **[udgivelse](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** og **[på forsiden](https://github.com/JustArchiNET/ArchiSteamFarm)**. Det er rart at bemærke, at ud over generiske penge donationer accepterer vi også Steam-genstande, så intet forhindrer dig i at donere skind, nøgler eller en lille del af de kort, du har opdrættet med ASF, hvis du gerne vil. Tak på forhånd for din generøsitet!

---

### Jeg bruger Steam-forældres pinkode for at beskytte min konto, skal jeg indtaste den et eller andet sted?

Ja, du skal indstille det i `SteamParentalCode` bot config ejendom. Dette skyldes hovedsagelig, at ASF har adgang til mange beskyttede dele af din Steam-konto, og det er umuligt for ASF at operere uden det.

---

### Jeg ønsker ikke ASF til at drive nogen spil som standard, men jeg ønsker at bruge ekstra ASF funktioner. Er det muligt?

Ja, hvis du bare ønsker at starte ASF med pause kort landbrugsmodul, du kan indstille `FarmingPausedByDefault` i `FarmingPreferences` bot config ejendom for at opnå det. Dette vil tillade dig at `genoptage` den under kørsel.

Hvis du ønsker helt at deaktivere kort landbrugsmodul og sikre, at det aldrig vil køre uden at du udtrykkeligt fortæller det anderledes, så anbefaler vi at indstille `FarmPriorityQueueOnly` i bot's `FarmingPreferences`, som i stedet for bare at holde på det, vil deaktivere landbruget helt, indtil du tilføjer spillene til at idle prioriteret kø dig selv.

Med kortopdrætsmodul sat på pause / deaktiveret, kan du gøre brug af ekstra ASF-funktioner, såsom `GamesPlayedWhileIdle`.

---

### Kan ASF minimere til bakken?

ASF er en konsol-app, der er intet vindue der skal minimeres, fordi vinduet er oprettet for dig af dit operativsystem. Du kan dog bruge ethvert tredjepartsværktøj, der er i stand til at gøre det, såsom **[RBTray](https://github.com/benbuck/rbtray)** til Windows, eller **[skærm](https://linux.die.net/man/1/screen)** til Linux/macOS. Det er kun eksempler, der er mange andre apps med lignende funktionalitet.

---

### Bevarer anvendelsen af ASF berettigelse til at modtage booster pakker?

**Ja**. ASF bruger den samme metode til at logge ind på Steam-netværket som den officielle klient Det bevarer derfor også evnen til at modtage boosterpakker til konti, der anvendes i ASF. Desuden er det ikke engang nødvendigt at logge ind på Steam-fællesskabet ved at bevare denne evne, så du trygt kan bruge `OnlineStatus` i `Offline` indstilling, hvis du gerne vil.

---

### Er der nogen måde at kommunikere med ASF?

Ja, på flere forskellige måder. Tjek **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** sektion for mere info.

---

### Jeg vil gerne hjælpe med ASF oversættelse, hvad skal jeg gøre?

Tak for din interesse! Du kan finde alle detaljer i vores **[lokalisering](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** sektion.

---

### Jeg har kun en (main) konto tilføjet til ASF, kan jeg stadig udstede kommandoer gennem damp chat?

**Ja**, det er forklaret i **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#notes)** sektion. Du kan gøre det via Steam-gruppechat, men det kan være lettere for dig at bruge **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**.

---

### ASF ser ud til at fungere, men jeg modtager ikke nogen kort dråber!

Kortdriftsraten er forskellig fra spil til spil, som du kan læse i **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Det tager et stykke tid, normalt **flere timer per spil**, og du bør ikke forvente kort til at falde i et par minutter siden lanceringen af et program. Hvis du kan se, at ASF aktivt kontrollerer kort status, og skifter spillet efter den aktuelle er fuldt opdrættet, så alt fungerer fint. Det er muligt, at du har aktiveret en mulighed såsom `DismissInventoryNotifications` af `BotBehaviour` , som automatisk afviser lagerbeholdning notifikationer. Tjek **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** for detaljer.

---

### Hvordan kan du helt stoppe ASF proces for min konto?

Du skal blot lukke ASF-processen, for eksempel ved at klikke på [X] på Windows. Hvis du i stedet ønsker at stoppe en bestemt bot af dit valg, men holde andre dem kørende, derefter tage et kig på `aktiveret` **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**, eller `stop` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Hvis du i stedet ønsker at stoppe automatisk landbrugsproces, men holde ASF kører for din konto, så er det det, `FarmingPausedByDefault` mulighed for `FarmingPreferences` i **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** og `pause` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** er for.

---

### Hvor mange bots kan jeg køre med ASF?

ASF som et program ikke har nogen hård øvre grænse for bot tilfælde, så du kan køre så meget som du har hukommelse på din maskine, Men du bliver stadig begrænset af Steam-netværket og andre Steam-tjenester. I øjeblikket kan du køre op til 100-200 bots med en enkelt IP og en enkelt ASF instans. Det er muligt at køre flere bots med flere IP'er og flere ASF forekomster, ved at arbejde omkring IP-begrænsninger. Husk, at hvis du bruger den store mængde af bots, bør du styre deres nummer selv, såsom at sikre, at alle dem faktisk logger ind og arbejder på samme tid. ASF blev ikke tilpasset for dette enorme antal bots, og den generelle regel gælder, at **jo flere bots du har, jo flere problemer vil du støde på**. Bemærk også, at grænsen ovenfor i almindelighed afhænger af mange interne faktorer, det tilnærmelse snarere end en streng grænse - du vil højst sandsynligt være i stand til at køre mere/mindre bots end angivet ovenfor.

ASF team foreslår **owning** op til **10 Steam-konti i alt**, og derfor også køre op til **10 bots i alt**. Alt ovenstående er ikke støttet og gjort på egen risiko, mod vores forslag her. Denne anbefaling er baseret på interne ventil retningslinjer samt vores egne forslag. Uanset om du vil overholde denne regel eller ej, er dit valg, ASF som et værktøj vil ikke gå imod din egen vilje, selv om det vil resultere i, at dine Steam-konti bliver suspenderet for at gøre det. Derfor vil ASF vise dig en advarsel, hvis du går over det, vi anbefaler, men stadig tillade dig at køre noget, du ønsker på egen risiko og mangel på vores støtte.

---

### Kan jeg så køre flere ASF-tilfælde?

Du kan køre så mange ASF tilfælde på en maskine, som du vil, forudsat at hver instans har sin egen mappe og sine egne konfigurationer, og konto brugt i én instans er ikke brugt i en anden. Men spørg dig selv, hvorfor du ønsker at gøre det. ASF er optimeret til at håndtere mere end hundrede konti på samme tid, og lancere hundrede af bots i deres egne ASF tilfælde nedbryder ydeevnen, tager flere OS-ressourcer (såsom CPU og hukommelse), og forårsager en potentiel synkronisering problemer mellem standalone ASF tilfælde, som ASF er tvunget til at dele sine limiters med andre tilfælde.

Derfor er mit **stærke forslag** altid maksimalt én ASF instans pr. IP/interface. Hvis du har flere IP'er / grænseflader, kan du på alle måder køre flere ASF tilfælde, med hver instans ved hjælp af sin egen IP/interface eller unikke `WebProxy` -indstilling. Hvis du ikke gør det, er lanceringen af flere ASF tilfælde helt meningsløs, da du ikke vil få noget fra lanceringen mere end 1 instans pr. en enkelt IP/interface. Steam vil ikke magisk give dig mulighed for at køre flere bots, bare fordi du har lanceret dem i en anden ASF instans, og ASF begrænser dig ikke til at begynde med.

Selvfølgelig er der stadig gyldige brug sager for flere ASF tilfælde på den samme netværksgrænseflade, såsom hosting ASF service til dine venner med hver ven har sin egen unikke ASF instans for at garantere isolation mellem bots og selv ASF processer selv, Men du er ikke omgå nogen Steam-begrænsninger på denne måde, det er helt anderledes formål.

---

### Hvad er meningen med status ved indløsning af en nøgle?

Status angiver, hvordan given indløsning forsøg viste sig. Der er mange forskellige statusser muligt, mest almindelige omfatter:

| Status                  | Beskriveslse                                                                                                                                                                                                        |
| ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| NoDetail                | "OK" status indikerer succes - nøglen blev indløst.                                                                                                                                                                 |
| Timeout                 | Steam-netværket reagerede ikke på given tid, vi ved ikke, om nøglen blev indløst eller ej (sandsynligvis var, men du kan prøve igen).                                                                               |
| BadActivationCode       | Den angivne nøgle er ugyldig (ikke genkendt som en gyldig nøgle af Steam-netværket).                                                                                                                                |
| DuplicateActivationCode | Den angivne nøgle blev allerede indløst af en anden konto, eller tilbagekaldt af udvikler/udgiver.                                                                                                                  |
| AlreadyPurchased        | Din konto ejer allerede `packageID` , der er forbundet med denne nøgle. Husk, at dette ikke angiver, om nøglen er `DuplicateActivationCode` eller ej - kun at den er gyldig, og den blev ikke brugt i dette forsøg. |
| RestrictedCountry       | Dette er region-låst nøgle, og din konto er ikke i den gyldige region, der har tilladelse til at indløse den.                                                                                                       |
| DoesNotOwnRequiredApp   | Du kan ikke indløse denne nøgle, da du mangler en anden app - primært grundspil, når du forsøger at indløse DLC-pakken.                                                                                             |
| RateLimited             | Du har lavet for mange indløse forsøg og din konto blev midlertidigt blokeret. Prøv igen om en time.                                                                                                                |

---

### Er du tilknyttet nogen kort landbrug/idling service?

**Nr.**. ASF er ikke tilknyttet nogen service, og alle sådanne krav er falske. Din Steam-konto er din ejendom, og du kan bruge din konto på den måde, du ønsker men Valve klart angivet i **[officielle ToS](https://store.steampowered.com/subscriber_agreement)** , at:

> You are responsible for the confidentiality of your login and password and for the security of your computer system. Ventilen er ikke ansvarlig for brugen af din adgangskode og konto eller for al kommunikation og aktivitet på Steam, der er resultatet af din brug af dit loginnavn og din adgangskode eller af enhver person, til hvem du forsætligt eller ved uagtsomhed har afsløret dit login og/eller din adgangskode i strid med denne fortrolighedsbestemmelse.

ASF er licenseret på liberal Apache 2.0 License, som giver andre udviklere mulighed for yderligere at integrere ASF med deres egne projekter og tjenester lovligt. Sådanne tredjepartsprojekter, der anvender ASF, er dog ikke garanteret at være sikker, gennemgået, passende eller lovligt i henhold til **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Hvis du ønsker at kende vores mening, **vi kraftigt opfordre dig til ikke at dele nogen af dine kontooplysninger med tredjeparts-tjenester**. Hvis en sådan tjeneste viser sig at være en **typisk fidus**, vil du blive efterladt alene med problemet, højst sandsynligt uden din Steam-konto og ASF vil ikke tage noget ansvar for tredjepartstjenester, der hævder at være sikre og sikre fordi ASF-holdet ikke gav tilladelse til hverken at gennemgå nogen af disse. Med andre ord, **du bruger dem på egen risiko, mod vores forslag fremsat over**.

Hertil kommer, at officielle **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** klart angiver, at:

> You may not reveal, share or otherwise allow others to use your password or Account except as otherwise specifically authorized by Valve.

Det er din konto og dit valg. Bare lad være med at sige, at ingen advarede dig. ASF som et program opfylder alle de regler, der er nævnt ovenfor, da du ikke deler dine kontooplysninger med nogen, og du bruger programmet til din egen personlige brug, men alle andre "kort farming service" kræver fra dig din konto legitimationsoplysninger, så det også overtræder reglen ovenfor (faktisk flere af dem). Ligesom med **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** evaluering, vi tilbyder ikke juridisk rådgivning, og du bør selv beslutte, om du ønsker at bruge disse tjenester, eller ikke - ifølge os **overtræder det direkte [Steam ToS](https://store.steampowered.com/subscriber_agreement)** og kan resultere i suspension, hvis ventilen finder ud af. Som påpeget ovenfor, **anbefaler vi kraftigt at IKKE bruge nogen af disse tjenester**.

---

## Problemer

---

### Et af mine spil bliver opdrættet i mere end 10 timer nu, men jeg fik stadig ingen kort fra det!

Årsagen til det kunne være relateret til kendt spørgsmålet om damp, hvilket sker, når du har to licenser til det samme spil, hvoraf den ene har kort dråber begrænset. Dette sker normalt, når du aktiverer spil gratis under en masse giveaway på Steam, og derefter aktivere en nøgle til det samme spil (men uden begrænsninger), e. . fra en betalt pakke. Hvis en sådan situation sker, rapporterer Steam på badge-siden, at spillet stadig har kort til at tabe, men uanset hvor meget du spiller spillet - kort vil aldrig falde på grund af gratis licens på din konto. Da det ikke er et ASF-problem, men et Steam-problem, kan vi ikke på en eller anden måde omgå det på ASF's side, og du skal løse det selv.

Der er to måder at løse problemet på. For det første kan du sortliste dette spil i ASF enten med `fbadd` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** eller med `Blacklist` **[konfigurationsejendom](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Dette vil forhindre ASF i at forsøge at drive kort fra dette spil, men vil ikke løse det underliggende problem, som forhindrer dig i at få kort dråber fra det berørte spil. For det andet kan du bruge Steam-support-selvbetjeningsværktøj til at fjerne gratis licens fra din konto, hvilket giver kun fuld licens, der indeholder kortfaldene. For at gøre det for det første besøge din **[licenser og produktnøgle aktiveringer](https://store.steampowered.com/account/licenses)** side og finde både gratis og betalt licens til det berørte spil. Normalt er det forholdsvis nemt - begge har lignende navn, men gratis én har "begrænset gratis salgsfremmende pakke" eller anden "promo" i licensens navn, plus "gratis" i feltet "overtagelsesmetode". Nogle gange kan det være mere tricky, for eksempel hvis gratis pakke var i nogle bundt og har et andet navn. Hvis du har fundet to licenser som det - så er det faktisk det problem, der er beskrevet her, og du kan trygt fjerne gratis licens uden at miste spillet.

For at fjerne den gratis licens fra din konto, besøg **[Steam supportside](https://help.steampowered.com/wizard/HelpWithGame)** og placer det berørte spilnavn i søgefeltet, spillet skal være tilgængeligt i sektionen "produkter", klik på det. Alternativt kan du bare bruge `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` linke og erstatte `<appID>` med appID for det spil, der forårsager problemer. Bagefter, klik på "Jeg vil permanent fjerne dette spil fra min konto" og vælg derefter den defekte gratis licens, som du har fundet ovenfor, normalt den med "begrænset gratis salgsfremmende pakke" i navnet (eller lignende). Efter fjernelse af den gratis licens, skal ASF være i stand til at slippe kort fra det berørte spil uden problemer, du bør genstarte landbrugsdriften efter fjernelsen bare for at være sikker på, at Steam denne gang opfanger den rigtige licens.

---

### ASF registrerer ikke spil `X` som tilgængelig til landbrug, men jeg ved, at det omfatter Steam-handelskort!

Der er to hovedårsager hertil. Første og mest indlysende årsag er det faktum, at du henviser til **Steam-butik** , hvor givne spil er annonceret som kort drops aktiveret spil. Dette er **forkert** antagelse, da det simpelthen hedder, at spillet **har** kort dråber inkluderet, men ikke nødvendigvis denne funktion for dette spil er **aktiveret** med det samme. Du kan læse mere om dette i **[officielle meddelelse](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**.

Kort sagt, kort drops ikon i Steam-butikken betyder ikke noget, check your **[badge pages](https://steamcommunity.com/my/badges)** for confirmation whether a game has card drops enabled or not - this is also what ASF do. (Automatic Copy) Hvis dit spil ikke vises på listen som et spil med kort muligt at tabe, så er dette spil **ikke** muligt at opdrætte, uanset årsag.

Det andet spørgsmål er mindre indlysende. og det er situationen, når du kan se, at dit spil faktisk er tilgængeligt med kort dråber på din badge side, alligevel er det ikke bliver opdrættet af ASF med det samme. Medmindre du rammer nogle andre fejl, såsom ASF er ude af stand til at kontrollere badge sider (beskrevet nedenfor), det er simpelthen en cache effekt og på ASF side Steam er stadig rapportering forældede badges side. Dette problem bør løse sig selv før eller senere, når cache bliver ugyldig. Der er heller ingen måde at ordne dette på vores side.

Selvfølgelig, alt dette antager, at du kører ASF med standard uberørte indstillinger, da du også kunne tilføje dette spil til landbrug blacklist, brug valgte `FarmingPreferences` såsom `FarmPriorityQueueOnly` eller `SkipRefundableGames`og så videre.

---

### Hvorfor spilletid af spil opdrættet gennem ASF øges ikke?

Det gør, men **ikke i realtid**. Steam registrerer din spilletid i faste intervaller og tidsplaner opdatering for det, men du er ikke garanteret at have det opdateret med det samme i det øjeblik, du afslutter sessionen, endsige under sådanne. Bare fordi spilletiden ikke er opdateret i realtid betyder ikke, at det ikke er registreret, det er normalt opdateret hver 30 minutter eller deromkring.

---

### Hvad er forskellen mellem en advarsel og en fejl i loggen?

ASF skriver til sin log en masse oplysninger om forskellige logning niveauer. Vores mål er at forklare **præcist** hvad ASF gør, herunder hvad Steam-problemer det skal håndtere eller andre problemer, der skal løses. Det meste af tiden er ikke alt relevant, Det er grunden til, at vi har to store niveauer i ASF med hensyn til problemer - et advarselsniveau og fejlniveau.

Generel ASF regel er, at advarsler er **ikke** fejl, derfor bør de **ikke** rapporteres. En advarsel er en indikator for dig, at noget potentielt uønsket sker. Uanset om det var Steam ikke reagerer, API smide fejl eller din netværksforbindelse er nede - det er en advarsel, og det betyder, at vi forventede, at det skete, så gider ikke ASF udvikling med det. Selvfølgelig er du fri til at spørge om dem eller få hjælp ved hjælp af vores support, men du bør ikke antage, at disse er ASF fejl værd at rapportere (medmindre vi bekræfter noget andet).

Fejl på den anden side indikerer en situation, der ikke bør ske, derfor er de værd at rapportere, så længe I sørgede for, at det ikke er jer, der forårsager dem. Hvis det er en fælles situation, som vi forventer at ske, så vil det i stedet blive konverteret til en advarsel. Ellers, det er muligvis en fejl, der bør rettes, ikke lydløst ignoreret, forudsat at det ikke er et resultat af dit eget tekniske problem. For eksempel at sætte ugyldigt indhold i `ASF. Sson` -filen vil kaste en fejl, da ASF ikke vil være i stand til at parse den, men det var dig, der satte den der, så du bør ikke rapportere denne fejl til os (medmindre du har bekræftet, at ASF er forkert, og din struktur er faktisk helt korrekt).

I en TL;DR sætning - rapporter fejl, rapporter ikke advarsler. Du kan stadig spørge om advarsler og modtage hjælp i vores supportsektioner.

---

### ASF starter ikke, programvinduet lukker straks!

Under normale forhold vil enhver ASF nedbrud eller frakørsel generere en `log. xt` i programmets bibliotek som du kan se, hvilket kan bruges til at finde årsagen til det. Derudover arkiveres et par sidste logfiler også i mappen `logs` , siden `hovedloggen. xt` -filen overskrives med hver ASF-kørsel.

Men hvis selv .NET runtime ikke er i stand til at starte på din maskine, så vil `log.txt` ikke blive genereret. Hvis det sker for dig, så har du sandsynligvis glemt at installere .NET forudsætninger, som angivet i **[opsætning](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)** guide. Andre almindelige problemer omfatter forsøger at starte forkert ASF variant til dit OS, eller på anden måde mangler indfødte .NET runtime afhængigheder. Hvis konsolvinduet lukker for tidligt til, at du kan læse beskeden, skal du åbne en uafhængig konsol og starte ASF binær derfra. For eksempel på Windows, åben ASF mappe, hold `Shift`, højreklik inde i mappen og vælg "*åbne kommandovindue her*" (eller *powershell*), indtast derefter i konsollen `. ArchiSteamFarm.exe` og bekræft med enter. På denne måde får du præcis besked om, hvorfor ASF ikke starter korrekt.

Hvis der ikke er nogen output, og du er på Windows, den sædvanlige årsag til, at der ikke er installeret alle tilgængelige Windows-opdateringer - sikre, at du bruger up-to-date OS, da vi ikke understøtter at køre ASF på Windows uden at opfylde denne betingelse enten måde.

---

### ASF sparker i min Steam-klientsession, mens jeg spiller! / *Denne konto er logget på en anden PC*

Dette viser sig som en besked i Steam-overlejringen om, at kontoen bruges et andet sted, mens du spiller. Dette spørgsmål kan have to forskellige grunde.

En grund er forårsaget af brudte pakker (spil), der specifikt ikke holder en afspilningslås korrekt, men forventer, at låsen skal besiddes af kunden. Et eksempel på en sådan pakke ville være Skyrim SE. Din Steam-klient starter spillet ordentligt, men det spil registrerer sig ikke selv som brugt. Derfor ser ASF, at det er frit at genoptage processen, hvilket den gør, og det sparker dig ud af Steam-netværket, da Steam pludselig opdager, at kontoen bruges et andet sted.

Anden årsag kunne komme op, hvis du spiller på din pc, mens ASF venter (især på en anden maskine), og du mister din netværksforbindelse. I dette tilfælde markerer Steam-netværk dig som offline og udgiver at spille lås (som ovenfor), hvilket udløser ASF (f.eks. på en anden maskine) til at genoptage landbruget. Når din pc kommer tilbage online, kan Steam ikke erhverve spille lås længere (det er nu holdt af ASF, også ligner ovenstående) og viser det samme budskab.

Begge årsager på ASF-siden er faktisk meget svære at løse, da ASF blot genoptager landbruget, når Steam-netværket informerer det om, at konto er gratis at blive brugt igen. Dette er, hvad der sker normalt, når du lukker spillet, men med ødelagte pakker kan dette ske straks, selvom dit spil stadig kører. ASF har ingen måde at vide, om du er blevet afbrudt, stoppede med at spille et spil, eller at du stadig spiller et spil, der ikke holder spille lås korrekt.

Den eneste rigtige løsning på dette problem er at sætte din bot på pause med `pause` , før du begynder at spille, og genoptage det med `genoptage` når du er færdig. Alternativt kan du bare ignorere problemet og handle det samme, som hvis du spillede med offline Steam-klient.

---

### `Afbrudt fra Steam!` - Jeg kan ikke oprette forbindelse til Steam-servere.

ASF kan kun **prøve** for at oprette forbindelse til Steam-servere, og det kan mislykkes på grund af mange grunde, herunder manglende internetforbindelse, Steam er nede, din firewall blokering forbindelse, tredjeparts værktøjer, forkert konfigurerede ruter eller midlertidige fiaskoer. Du kan aktivere `fejlfinding` tilstand for at tjekke mere verbose log med angivelse af nøjagtige fejlårsager selvom det normalt er simpelthen forårsaget af dine egne handlinger, såsom at bruge "CS:GO MM Server Picker", der sortlister en masse Steam IP'er, hvilket gør det meget svært for dig at rent faktisk nå Steam-netværk.

ASF vil gøre sit bedste for at etablere forbindelse. som omfatter ikke kun at spørge om opdateret liste over servere, men også at prøve en anden IP når den sidste fejl så hvis det virkelig er et midlertidigt problem med en bestemt server eller rute, vil ASF forbinde før eller senere. Men hvis du er bag firewall eller på anden måde ude af stand til at nå Steam-servere, så selvfølgelig skal du ordne det selv, med potentiel hjælp fra `Fejlsøg` tilstand.

Det er også muligt, at din maskine ikke er i stand til at etablere forbindelse med Steam-servere ved hjælp af standardprotokol i ASF. Du kan ændre protokoller, som ASF har tilladelse til at bruge ved at ændre `SteamProtocols` global konfigurationsegenskab. Hvis du for eksempel har problemer med at nå Steam med `UDP` -protokollen (f.eks. grundet firewalls), måske vil du have mere held med `TCP` eller `WebSocket`.

I en meget usandsynlig situation for at have forkerte servere bliver cached, for eksempel på grund af flytning ASF `config` mappe fra en maskine til en anden maskine beliggende i helt forskellige land, slette `ASF. b` for at genopfriske Steam-servere ved næste opstart kan hjælpe. Meget ofte er det ikke nødvendigt og behøver ikke at blive gjort, da listen automatisk opdateres ved første lancering, såvel som når forbindelsen er etableret - vi nævner det bare som en måde at rense alt relateret til listen over Steam-servere cached af ASF.

---

### `Kan ikke logge ind på Steam: TryAnotherCM/Ugyldig`, `ServiceUtilgængelig/Ugyldig`

Som pr ovenfor, men denne gang den server, du har forbundet med, er eksplicit utilgængelig. Normalt sker i Steam-vedligeholdelsesvinduet, er der intet du kan gøre ved dette, ASF vil automatisk prøve igen med en anden server, indtil man tilfældigvis accepterer sin anmodning. Den må ikke vare længere end højst en time.

---

### `Kunne ikke hente badges information, vil prøve igen senere!`

Normalt betyder det, at du bruger Steam-forældrepinkode til at få adgang til din konto, men du har glemt at sætte den i ASF-konfiguration. Du skal sætte gyldig pinkode i `SteamParentalCode` bot config egenskab, ellers vil ASF ikke være i stand til at få adgang til det meste af webindhold, vil derfor ikke være i stand til at fungere korrekt. Gå over til **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** for at lære mere om `SteamParentalCode`.

Andre årsager omfatter midlertidigt Steam-problem, netværksproblem eller lignende. Hvis problemet ikke vil løse sig selv efter flere timer, og du er sikker på, at du konfigureret ASF korrekt, velkommen til at lade os vide om det.

---

### ASF mislykkedes med `Forespørgsel mislykkedes efter 5 forsøg` fejl!

Normalt betyder det, at du bruger Steam-forældrepinkode til at få adgang til din konto, men du har glemt at sætte den i ASF-konfiguration. Du skal sætte gyldig pinkode i `SteamParentalCode` bot config egenskab, ellers vil ASF ikke være i stand til at få adgang til det meste af webindhold, vil derfor ikke være i stand til at fungere korrekt. Gå over til **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** for at lære mere om `SteamParentalCode`.

Hvis forældrenes pinkode ikke er årsagen, så er dette en mest almindelig fejl, og du bør vænne dig til det, det betyder blot, at ASF sendte en anmodning til Steam-netværket, og ikke fik et gyldigt svar, 5 gange i træk. Normalt betyder det, at Steam enten er nede eller har nogle vanskeligheder eller vedligeholdelse - ASF er opmærksom på sådanne problemer, og du bør ikke bekymre dig om dem, medmindre de sker konstant i længere tid end flere timer, og andre brugere ikke har sådanne problemer.

Hvordan tjekker man, om Steam er ved at blive ned? **[Steam Status](https://steamstat.us)** er en fremragende kilde til at kontrollere, om Steam **skal være** op, hvis du bemærker fejl, især relateret til Community eller Web API, så Steam har problemer. Du kan ønske at forlade ASF alene og lade det gøre sit arbejde efter en kort periode af nedetid, eller afslutte det og vente dig selv.

Det er dog ikke altid tilfældet, da Steam-problemer i nogle situationer muligvis ikke detekteres af Steam-status for eksempel skete en sådan sag, da Valve brød HTTPS-understøttelse af Steam-fællesskabet 7. juni 2016 - adgang til **[SteamCommunity](https://steamcommunity.com)** gennem HTTPS kastede en fejl. Stol derfor ikke blindt på Steam-status enten, det er bedst at tjekke dig selv, om alt fungerer som menet.

Hertil kommer, at Steam indeholder forskellige hastighedsbegrænsende foranstaltninger, som midlertidigt vil forbyde din IP hvis du foretager for mange anmodninger på én gang. ASF er klar over, at og tilbyder dig flere forskellige limiters i config, som du bør gøre brug af. Standardindstillingerne blev tweaked baseret på **sane** antal bots, hvis du bruger så stort beløb, at selv Steam fortæller dig at gå væk, så du enten justere dem, indtil det ikke længere fortæller dig, eller du gør, som du har fortalt. Jeg går ud fra, at den anden vej ikke er en mulighed for Dem. så gå læse om dette emne og være særlig opmærksom på `WebLimiterDelay` , som er en generel limiter, der gælder for alle webanmodninger.

Der er ingen "gylden regel", der virker for alle, fordi blokke er stærkt påvirket af tredjepartsfaktorer, Derfor er du nødt til at eksperimentere dig selv og finde en værdi, der virker for dig. Du kan også ignorere hvad jeg siger og bruge noget i retning af `10000` , som er garanteret til at fungere korrekt, men klager ikke over, hvordan din ASF reagerer på alt på 10 sekunder, og hvordan badge parsing tager 5 minutter. Ud over det, det er helt muligt, at ingen limiter vil gøre noget, fordi du har så enorme mængder af bots, at du rammer **[hard limit](#how-many-bots-can-i-run-with-asf)** , der blev nævnt ovenfor. Ja, det er helt muligt, at du kan logge ind uden problemer på Steam-netværket (klient), men Steam web (hjemmeside) vil nægte at lytte til dig, hvis du har 100 sessioner etableret på én gang. ASF kræver, at både Steam-netværket og Steam-nettet er samarbejdsvillige, det tager kun én ned for at gøre dig problemer, du ikke vil gendanne fra.

Hvis intet hjælper og du har ingen anelse om, hvad der er brudt, du kan altid aktivere `Fejlsøg` tilstand og se dig selv i ASF log hvorfor præcis anmodninger mislykkes. For eksempel:

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Forbidden <- HEAD https://steamcommunity.com/my/edit/settings
```

Se, at `Forbudt` kode? Det betyder, at du fik midlertidigt forbudt for store mængder af anmodninger, fordi du ikke tweak `WebLimiterDelay` korrekt endnu (forudsat at du får den samme fejlkode for alle andre anmodninger). Der kan være andre årsager anført der, såsom `InternalServerError`, `ServiceUtilgængelig` og timeouts der indikerer Steam vedligeholdelse/spørgsmål. Du kan altid forsøge at besøge linket nævnt af ASF selv og kontrollere, om det virker - hvis det ikke gør det, så ved du, hvorfor ASF heller ikke kan få adgang til det. Hvis det gør, og den samme fejl ikke gå væk efter en dag eller to, kan det være værd at undersøge og rapportere.

Før du gør det, skal du **sørge for, at fejlen er værd at rapportere i første omgang**. Hvis det er nævnt i denne FAQ, såsom handelsrelaterede spørgsmål, så er det ude. Hvis det er midlertidigt problem, der skete en gang eller to gange, især når dit netværk var ustabilt, eller Steam var nede - det er ude. Men hvis du var i stand til at reproducere dit problem flere gange i træk, på tværs af 2 dage, genstartet ASF samt din maskine i processen og sørg for, at der ikke er nogen FAQ post her for at hjælpe med at løse det, så kan det være værd at spørge om.

---

### ASF synes at fryse og udskrive ikke noget på konsollen, før jeg trykker på en nøgle!

Du bruger sandsynligvis Windows og din konsol har QuickEdit tilstand aktiveret. Se **[dette](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** spørgsmål om StackOverflow for teknisk forklaring. Du bør deaktivere QuickEdit-tilstand ved at højreklikke på dit ASF-konsolvindue, åbne egenskaber og afmarkere passende afkrydsningsfelt.

---

### ASF kan ikke acceptere eller sende handler!

Indlysende ting først - nye konti starter som begrænset. Indtil du låser kontoen op ved at indlæse dens tegnebog eller bruge $5 i butikken, kan ASF ikke acceptere hverken at sende handler ved hjælp af denne konto. I dette tilfælde vil ASF angive, at opgørelsen synes tom, fordi hvert kort, der er i det, ikke kan handles.

Dernæst hvis du ikke bruger **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, det er muligt, at ASF faktisk accepteret/sendt handel, men du skal bekræfte det via din e-mail. Ligeledes, hvis du bruger klassisk 2FA, skal du bekræfte handlen via din autentificering. Bekræftelser er **obligatorisk** nu, så hvis du ikke vil acceptere dem af dig selv, så overvej at importere din autentificering til ASF 2FA.

Læg også mærke til, at du kun kan handle med dine venner, og folk med kendt handelslink. Hvis du forsøger at indlede *Bot -> Master* handel, såsom `loot`, så skal du enten have din bot på din venliste, eller din `SteamTradeToken` erklæret i Bot's config. Sørg for, at token er gyldig - ellers vil du ikke være i stand til at sende en handel.

Endelig skal du huske, at nye enheder har 7-dages handelslås, så hvis du lige har tilføjet din konto til ASF, vent mindst 7 dage - alt bør arbejde efter denne periode. Denne begrænsning omfatter **både** , der accepterer **og** afsendende handler. Det udløser ikke altid, og der er mennesker, der kan sende og acceptere handler med det samme. Flertallet af de mennesker er påvirket selv, og lås **vil** ske, selvom du kan sende og acceptere handler gennem din damp klient på samme maskine. Bare vent tålmodigt, der er intet du kan gøre for at gøre det hurtigere. Ligeledes kan du få lignende lås til at fjerne / ændre forskellige Steam-sikkerhedsrelaterede indstillinger, såsom 2FA, SteamGuard, adgangskode, e-mail og lignende. Generelt skal du kontrollere, om du selv kan sende en handel fra denne konto, hvis ja, meget sandsynligt er det klassisk 7-dages lås fra ny enhed.

Og endelig, husk på, at en konto kan have kun 5 ventende handler til en anden, så ASF vil ikke sende handler, hvis du har 5 (eller flere) afventer dem fra den ene bot til at acceptere allerede. Dette er sjældent et problem, men det er også værd at nævne, især hvis du sætter ASF til auto-send handler, endnu du ikke bruger ASF 2FA og glemte at faktisk bekræfte dem.

Hvis intet hjulpet, kan du altid aktivere `fejlsøg` tilstand og tjekke dig selv, hvorfor anmodninger fejler. Bemærk venligst, at Steam-foredrag nonsense det meste af tiden, og den angivne grund måske ikke giver nogen logisk mening, eller kan være helt forkert - hvis du beslutter dig for at fortolke denne grund, så sørg for at have anstændig viden om Steam og dens særheder. Det er også ret almindeligt at se dette problem uden logisk grund, og den eneste foreslåede løsning i dette tilfælde er at re-tilføje konto til ASF (og vente 7 dage igen). Nogle gange løser dette problem også sig selv *magisk*, på samme måde det bryder. Men normalt er det bare enten 7-dages handel lås, midlertidig damp problem, eller begge dele. Det er bedst at give det et par dage før manuelt at kontrollere, hvad der er forkert, medmindre du har noget trang til at debug den virkelige årsag (og som regel vil du blive tvunget til at vente alligevel, fordi fejlmeddelelsen ikke giver nogen mening, hverken hjælpe dig i det mindste).

Under alle omstændigheder kan ASF kun **prøve** for at sende en korrekt anmodning til Steam for at acceptere/sende handel. Hvorvidt Steam accepterer denne anmodning eller ej, er uden for anvendelsesområdet for ASF, og ASF vil ikke magisk få det til at fungere. Der er ingen fejl relateret til denne funktion, og der er også intet at forbedre, fordi logik sker uden for ASF. Derfor skal du ikke bede om fastsættelse ting, der ikke er brudt, og spørg heller ikke, hvorfor ASF ikke kan acceptere eller sende handler - **Jeg ved ikke, og ASF ved heller ikke**. Enten beskæftige sig med det, eller ordne dig selv, hvis du ved bedre.

---

### Hvorfor skal jeg sætte 2FA/SteamGuard kode på hvert login? / *Fjernet udløbet login-nøgle*

ASF bruger login-nøgler (hvis du holdt `UseLoginKeys` aktiveret) til at holde legitimationsoplysninger gyldige, den samme mekanisme, som Steam bruger - 2FA/SteamGuard token er kun påkrævet én gang. Men på grund af Steam-netværksproblemer og quirker er det helt muligt, at login-nøglen ikke gemmes i netværket, vi har allerede set sådanne problemer ikke kun med ASF men med regelmæssig damp klient samt (et behov for at indtaste login + adgangskode på hver kørsel, uanset "husk mig" mulighed).

Du kan fjerne `BotName.db` og `BotName. i` (hvis tilgængelig) for den berørte konto og forsøge at forbinde ASF til din konto igen, men det vil sandsynligvis ikke gøre noget. Nogle brugere har rapporteret, at **[deautoriserer alle enheder](https://store.steampowered.com/twofactor/manage)** på Steam-side bør hjælpe, vil det at ændre adgangskode gøre det samme. Men det er kun arbejdsløse, der ikke engang er garanteret at arbejde Den virkelige ASF-baserede løsning er at importere din autentificering som **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** - på denne måde kan ASF generere tokens automatisk, når de er nødvendige. og du behøver ikke at indtaste dem manuelt. Normalt problemet magisk løser sig selv efter nogen tid, så du kan blot vente på, at det sker. Selvfølgelig kan du også bede ventilen om løsning, fordi jeg ikke kan tvinge Steam-netværket til at acceptere vores login-nøgler.

Som en side note, du kan også slå login-nøgler fra med `UseLoginKeys` config ejendom sat til `false`, men dette vil ikke løse problemet, kun springe den oprindelige login-nøgle fejl. ASF er allerede klar over problemet forklaret her og vil forsøge sit bedste for ikke at bruge login-nøgler, hvis det kan garantere sig selv alle login-oplysninger, så der ikke er behov for at justere `UseLoginKeys` manuelt, hvis du kan angive alle login-detaljer sammen med at bruge ASF 2FA.

---

### Jeg får fejl: *Kan ikke logge ind på Steam: `InvalidPassword` eller `RateLimitExceeded`*

Denne fejl kan betyde en masse ting, nogle af dem omfatter:

- Ugyldigt login / adgangskode kombination (selvfølgelig)
- Udløbet login-nøgle, der bruges af ASF til at logge ind
- For mange mislykkede loginforsøg i kort tid (anti-bruteforce)
- For mange login-forsøg i kort tid (rate-limiting)
- Krav om captcha at logge ind (sandsynligvis forårsaget af to årsager ovenfor)
- Andre grunde Steam-netværket kan have forhindret dig i at logge ind

I tilfælde af anti-bruteforce og hastighedsbegrænsning, problem vil forsvinde efter et stykke tid, så bare vente og ikke forsøge at logge ind i mellemtiden. Hvis du rammer dette problem hyppigt, måske er det klogt at øge `LoginLimiterDelay` config egenskab af ASF. Overdreven program genstarter og andre tilsigtet / ikke-tilsigtet login-anmodninger absolut vil ikke hjælpe med dette problem, så prøv at undgå det, hvis det er muligt.

I tilfælde af udløbet login nøgle - ASF vil fjerne gamle og bede om en ny ved næste login (hvilket vil kræve fra dig at sætte 2FA token, hvis din konto er 2FA-beskyttet. Hvis din konto bruger ASF 2FA, vil token blive genereret og brugt automatisk). Dette kan naturligvis ske over tid, men hvis du får dette problem på hvert login, det er muligt, at Steam af en eller anden grund besluttede at ignorere vores login-nøgle gemme anmodninger, som nævnt i issue **[ovenfor](#why-do-i-have-to-put-2fasteamguard-code-on-each-login--removed-expired-login-key)**. Du kan naturligvis deaktivere `UseLoginKeys` helt, men det vil ikke løse problemet, undgå kun et behov for at fjerne udløbne login-nøgler hver gang. Den virkelige løsning er, som det fremgår af ovenstående, at anvende ASF 2FA.

Og endelig, hvis du brugte forkert login + adgangskode kombination, naturligvis du har brug for at korrigere dette, eller deaktivere bot, der forsøger at forbinde med disse legitimationsoplysninger. ASF kan ikke gætte alene, om `InvalidPassword` betyder ugyldige legitimationsoplysninger, eller en af ovennævnte grunde, vil den derfor blive ved med at prøve, indtil det lykkes.

Husk på, at ASF har sit eget indbyggede system til at reagere i overensstemmelse hermed på damp quirks, i sidste ende vil det forbinde og genoptage sit job, derfor er det ikke nødvendigt at gøre noget, hvis problemet er midlertidigt. Genstart af ASF med henblik på magisk at løse problemer vil kun forværre tingene (da ny ASF ikke kender tidligere ASF tilstand for ikke at være i stand til at logge ind, og prøv at forbinde i stedet for at vente), så undgå at gøre det, medmindre du ved, hvad du laver.

Endelig, som for alle Steam-anmodninger - ASF kan kun **prøve** at logge ind ved hjælp af dine angivne legitimationsoplysninger. Hvorvidt denne anmodning vil lykkes eller ej, er uden for anvendelsesområdet og logikken i ASF - der er ingen fejl, og intet kan ikke ordnes hverken forbedres i denne henseende.

---

### Jeg kan ikke indtaste login-oplysninger, som ASF beder om
### `System.InvalidOperationException: Kan ikke læse nøgler, når enten applikationen ikke har en konsol, eller når konsol-input er blevet omdirigeret`
### `System.IO.IOException: Input/output fejl`
### `RequestInput () input er ugyldigt!`

Hvis denne fejl opstod under ASF input (f.eks. du kan se `GetUserInput()` i stacktrace) så er det forårsaget af dit miljø, som forbyder ASF at læse standard input af din konsol. Det kan forekomme på grund af en masse grunde, men den mest almindelige er du kører ASF i det forkerte miljø (f.eks. i `systemd`, `nohup` eller `&` baggrund i stedet for e. . `skærm` på Linux). Hvis ASF ikke kan få adgang til sin standard input, så vil du se denne fejl logget og ASF's manglende evne til at bruge dine oplysninger under runtime.

Normalt skal du rette op på ovenstående problem, dvs. tillade ASF at få adgang til standard input, så du kan angive detaljerne. Men hvis du **forventer, at** dette sker, så du **agter** at køre ASF i input-less environment så skal du udtrykkeligt fortælle ASF, at det er tilfældet, ved at indstille **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** tilstand passende. Dette vil fortælle ASF aldrig bede om brugerinput under nogen omstændigheder, så du kan køre ASF i input-less miljøer sikkert. Du kan besvare udvalgte inputforespørgsler på andre måder i denne tilstand, f.eks. i ASF-ui.

---

### `System.Net.Http.WinHttpException: A security error occurred`

Denne fejl sker, når ASF ikke kan etablere sikker forbindelse med given server, næsten udelukkende på grund af SSL-certifikat mistillid.

I næsten alle tilfælde skyldes denne fejl **forkert dato/tid på din maskine**. Hvert SSL-certifikat har udstedt dato og udløbsdato. Hvis din dato er ugyldig og uden for disse to grænser, kan du ikke stole på certifikatet på grund af et potentielt **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)** -angreb, og ASF nægter at oprette en forbindelse.

Indlysende løsning er at indstille datoen på din maskine på passende vis. Det anbefales stærkt at bruge automatisk datosynkronisering, såsom indbygget synkronisering tilgængelig på Windows eller `ntpd` på Linux.

Hvis du har sørget for, at datoen på din maskine er passende, og fejlen ikke ønsker at gå væk, SSL-certifikater, som dit system har tillid til, kan være forældede eller ugyldige. I dette tilfælde skal du sikre, at din maskine kan etablere sikre forbindelser, for eksempel ved at kontrollere, om du kan få adgang til `https://github. om` med en browser efter eget valg, eller CLI-værktøj såsom `curl`. Hvis du har bekræftet, at dette fungerer ordentligt, er du velkommen til at bede os om støtte.

---

### `System.Threading.Tasks.TaskCanceledException: A task was canceled`

Denne advarsel betyder, at Steam ikke svarede på ASF anmodning i givet tid. Normalt er det forårsaget af Steam netværk hikke og påvirker ikke ASF på nogen måde. I andre tilfælde er det det samme som anmodning mislykkes efter 5 forsøg. Rapportering af dette problem giver ingen mening det meste af tiden, da vi ikke kan tvinge Steam til at reagere på vores anmodninger.

---

### `Typen initializer for 'System.Security.Cryptography.CngKeyLite' kastede en undtagelse`

Dette problem er næsten udelukkende forårsaget af deaktiveret/stoppet `CNG Key Isolation` Windows-tjeneste, som giver kernen kryptografi funktionalitet til ASF, uden hvilken programmet ikke er i stand til at køre. Du kan løse dette problem ved at starte `tjenester. sc` og sikre, at `CNG Key Isolation` Windows-tjeneste ikke har deaktiveret opstart og kører i øjeblikket.

---

### ASF bliver opdaget som en malware af min AntiVirus! Hvad sker der?

**Sørg for at du har downloadet ASF fra pålidelig kilde**. Den eneste officielle og betroede kilde er **[ASF udgivelser](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** side på GitHub (og dette er også kilden til ASF auto-opdateringer) - **enhver anden kilde er ikke betroet pr. definition og kan indeholde malware tilføjet af andre personer** - du bør ikke stole på nogen anden download-placering, sikre, at din ASF altid kommer fra os.

Hvis du har bekræftet, at ASF downloades fra pålidelige kilder, så meget sandsynligt er det simpelthen en falsk positiv. Dette **skete i fortiden**, **sker lige nu**, og **vil ske i fremtiden**. Hvis du er bekymret for den faktiske sikkerhed, når du bruger ASF, så foreslår jeg scanning ASF med mange forskellige AVs for faktiske detektionsforhold, for eksempel via **[VirusTotal](https://www.virustotal.com)** (eller enhver anden webservice efter eget valg).

Hvis AV, som du bruger fejlagtigt registrerer ASF som en malware, derefter **er det en god ide at sende denne fil prøve tilbage til udviklere af din AV, så de kan analysere det og forbedre deres detektionsmotor**, da det klart er ikke fungerer så godt, som du synes det gør. Der er intet problem i ASF kode, og der er også intet at løse for os, da vi ikke distribuerer malware i første omgang, derfor giver det ikke mening at anmelde disse falske-positive til os. Vi anbefaler stærkt at sende ASF prøve for yderligere analyse som nævnt ovenfor, men hvis du ikke ønsker at genere det, så kan du altid tilføje ASF til en slags AV undtagelser, deaktivere din AV eller blot bruge en anden. Desværre, vi er vant til AVs bliver dumme, som hver gang i et stykke tid nogle AV registrerer ASF som en virus, som normalt varer meget kort og bliver lappet hurtigt af devs, men som vi påpegede ovenfor - **det skete**, **sker** og **vil ske** hele tiden. ASF indeholder ikke nogen ondsindet kode, du kan gennemgå ASF kode og endda kompilere fra kilden selv. Vi er ikke hackere til at sløre ASF kode for at skjule fra AV-heuristik og falske positive, så forventer ikke fra os at ordne, hvad der ikke er brudt - der er ingen "virus" for os at ordne.