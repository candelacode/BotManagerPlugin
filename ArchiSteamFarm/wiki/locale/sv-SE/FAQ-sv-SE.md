# Vanliga frågor

Vår grundläggande FAQ täcker vanliga frågor och svar som du kan ha. För mindre vanliga frågor, besök vår **[utökade FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ)** istället.

# Innehållsförteckning

* [Allmänt](#general)
* [Jämförelse med liknande verktyg](#comparison-with-similar-tools)
* [Säkerhet / Sekretess / VAC / Förbud / ToS](#security--privacy--vac--bans--tos)
* [Övrigt](#misc)
* [Problem](#issues)

---

## Allmänt

### Vad är ASF?
### Varför hävdar programmet att det inte finns något att odla på mitt konto?
### Varför upptäcker ASF inte alla mina spel?
### Varför är mitt konto begränsat?

Innan du försöker förstå vad ASF är, bör du se till att du förstår vilka Steam-kort är, och hur man får dem, vilket är fint beskrivet i officiella FAQ **[här](https://steamcommunity.com/tradingcards/faq)**.

Kort sagt, Steam-kort är samlarobjekt som du är berättigad till när du äger ett visst spel, och kan användas för att tillverka märken, sälja på Steam-marknaden eller något annat syfte som du väljer.

Kärnpunkter anges än en gång här, eftersom människor i allmänhet inte vill hålla med dem och föredrar att låtsas att de inte existerar:

- **Du måste äga spelet på ditt Steam-konto för att vara berättigad till eventuella kort droppar från det. Familjedelning är inte äganderätt och räknas inte.**
- **Ditt spel kan inte markeras som [privat](https://help.steampowered.com/faqs/view/1150-C06F-4D62-4966), ASF kommer automatiskt att hoppa över sådana spel under jordbruket.**
- **Du kan inte odla spelet oändligt, varje spel har fast antal kort droppar. När du släpper dem alla (cirka en halv av hela uppsättningen), spelet är inte en kandidat för jordbruk längre. Det spelar ingen roll om du har sålt, handlat, tillverkat eller glömt vad som hände med de kort du har fått, När du har slut på kort droppar, spelet är klar.**
- **Du kan inte släppa kort från F2P-spel utan att spendera några pengar i dem. Detta innebär permanent F2P-spel som Team Fortress 2 eller Dota 2. Ägandet av F2P-spel ger inte dig kort droppar.**
- **Du kan inte släppa kort på [begränsade konton](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A), oavsett egna spel och deras aktiveringsmetod.**
- **Betalda spel som du har fått gratis under en kampanj kan inte odlas för kortsläpp, oavsett vad som visas på butikssidan.**

Så som du kan se, Steam kort delas ut till dig för att spela ett spel som du köpt, eller F2P spel som du har lagt pengar på. Om du spelar ett sådant spel tillräckligt länge kommer alla kort för det spelet så småningom att falla till ditt förråd, göra det möjligt för dig att slutföra ett märke (efter att ha fått den återstående halvan av uppsättningen), sälja dem, eller göra vad du vill.

Nu när vi har förklarat grunderna i Steam, kan vi förklara ASF. Själva programmet är ganska komplext att förstå fullt ut, så istället för att gräva in alla tekniska detaljer, kommer vi att erbjuda en mycket förenklad förklaring nedan.

ASF loggar in på ditt Steam-konto genom vår inbyggda anpassade Steam-klientimplementation med dina angivna uppgifter. Efter att ha loggat in, det tolkar dina **[märken](https://steamcommunity.com/my/badges)** för att hitta spel som är tillgängliga för jordbruk (`X` kort droppar kvar). Efter att ha tolkat alla sidor och konstruerat den slutliga listan över spel som finns tillgängliga, ASF väljer den mest effektiva jordbruksalgoritmen och startar processen. Processen beror på valda **[kort odlingsalgoritm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** men består oftast av att spela kvalificerat spel och periodiskt (plus på varje artikel drop) kontrollera om spelet redan är fullt odlat - om ja, ASF kan fortsätta med nästa titel, med samma förfarande, tills alla spel är fullt odlade.

Tänk på att förklaringen ovan är förenklad och inte beskriver dussintals extra funktioner och funktioner som ASF erbjuder. Besök resten av **[vår wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki)** om du vill veta varje ASF detalj. Jag försökte göra det tillräckligt enkelt att förstå för alla, utan att föra in tekniska detaljer - avancerade användare uppmuntras att gräva djupare.

Nu som ett program - ASF erbjuder lite magi. För det första, det behöver inte ladda ner någon av dina spelfiler, det kan spela spel direkt. För det andra är det helt oberoende av din vanliga Steam-klient - du behöver inte ha Steam-klienten igång eller ens installerad alls. För det tredje, det är automatiserad lösning - vilket innebär att ASF automatiskt gör allt bakom ryggen, utan att behöva berätta vad du ska göra - vilket sparar du krångel och tid. Slutligen behöver det inte lura Steam-nätverket genom processemulering (som t.ex. Idle Master använder), eftersom det kan kommunicera med det direkt. Det är också super snabb och lätt, vara en fantastisk lösning för alla som vill få kort lätt utan mycket krångel - det kommer särskilt användbart genom att lämna det körs i bakgrunden medan du gör något annat, eller till och med spela i offlineläge.

Allt ovanstående är trevligt, men ASF har också några tekniska begränsningar som genomdrivs av Steam - vi kan inte odla spel som du inte äger, vi kan inte gård spel för alltid för att få extra droppar förbi den påtvingade gränsen, och vi kan inte gård spel medan du spelar. Allt detta bör vara "logiskt", med tanke på hur ASF fungerar, men det är trevligt att notera att ASF inte har superkrafter och inte kommer att göra något som är fysiskt omöjligt, så tänk på det - det är i princip samma sak som om du sa till någon att logga in på ditt konto från en annan dator och gård dessa spel för dig.

Så för att sammanfatta - ASF är ett program som hjälper dig att släppa de kort du är berättigad till, utan mycket krångel. Det erbjuder också flera andra funktioner, men låt oss hålla fast vid detta för nu.

---

### Måste jag ange mina kontouppgifter?

**Ja**. ASF kräver dina kontouppgifter på samma sätt som den officiella Steam-klienten gör, eftersom det använder samma metod för att interagera med Steam-nätverket. Detta betyder dock inte att du måste sätta dina kontouppgifter i ASF-konfigurationer, du kan fortsätta använda ASF med tomma `SteamLogin` och/eller `SteamPassword`, och mata in data på varje ASF kör, när det krävs (liksom flera andra inloggningsuppgifter, hänvisa till konfiguration). På så sätt sparas inte dina uppgifter någonstans, men ASF kan naturligtvis inte autostart utan din hjälp. ASF erbjuder också flera andra sätt att öka din **[säkerhet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**, så tveka inte att läsa den delen av wikin om du är avancerad användare. Om du inte är det, och du inte vill sätta dina kontouppgifter i ASF-konfigurationer, sedan helt enkelt inte göra det, och istället mata in dem vid behov när ASF ber om dem.

Tänk på att ASF-verktyget är för ditt personliga bruk och dina uppgifter lämnar aldrig din dator. Du delar dem inte heller med någon som uppfyller **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** - en mycket viktig sak som många glömmer bort. Du skickar inte dina uppgifter till våra servrar eller någon tredje part, bara direkt till Steam-servrar som drivs av termostat. Vi känner inte till dina uppgifter och vi kan inte heller återställa dem åt dig, oavsett om du sätter dem i dina konfigurationer eller inte.

---

### Hur länge måste jag vänta på att korten ska släppa?

**Så länge det tar** - på allvar. Varje spel har olika jordbruk svårigheter som utvecklare / utgivare, och det är helt upp till dem hur snabba kort släpps. Majoriteten av spelen följer 1 droppe per 30 minuters spelande, men det finns också spel som kräver av dig att spela även flera timmar innan du släpper ett kort. Dessutom kan ditt konto begränsas från att ta emot kort droppar från spel som du inte spelade på tillräckligt med tid ännu, som anges i **[föreställning](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Försök inte att göra gissningar hur länge ASF bör gård ges titel - det är inte upp till dig, varken ASF att bestämma. Det finns inget du kan göra för att göra det snabbare, och det finns ingen "bugg" relaterade till kort som inte släpps i tid - du kontrollerar inte kort droppprocessen, inte heller ASF. I bästa fall får du i genomsnitt 1 droppe per 30 minuter. I värsta fall kommer du inte att få något kort även i 4 timmar sedan starten ASF. Båda dessa situationer är normala och omfattas av vår **[prestanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** sektion.

---

### Jordbruket tar för lång tid, kan jag på något sätt påskynda det?

Det enda som kraftigt påverkar hastigheten på jordbruket väljs **[kort odlingsalgoritm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** för din bot instans. Allt annat har försumbar effekt och kommer inte att göra jordbruket snabbare, medan vissa åtgärder som att starta ASF-processen flera gånger kommer även **göra det värre**. Om ni verkligen har ett behov av att göra varenda sekund från jordbruksprocessen, ASF låter dig finjustera några centrala jordbruksvariabler som `FarmingDelay` - alla förklaras i **[konfigurationen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Som jag sade är effekten dock försumbar, och välja rätt kort odling algoritm för given hänsyn är en och det enda avgörande valet som kan kraftigt påverka hastigheten på jordbruket, allt annat är rent kosmetiskt. I stället för att oroa sig för jordbrukets hastighet, bara lansera ASF och låt det göra sitt jobb - jag kan försäkra er att det gör det på det mest effektiva sätt jag kunde komma på. Ju mindre du bryr dig, desto mer kommer du att bli nöjd.

---

### Men ASF sade att jordbruket kommer att ta ungefär X-tid!

ASF ger dig grov approximation baserat på antal kort du behöver släppa, och din valda algoritm - detta är ingenstans nära den faktiska tid som du kommer att spendera på jordbruk, vilket är vanligtvis längre än detta, som ASF antar bäst fall endast, och ignorerar alla Steam Network quirks, Internet-frånkopplingar, överbelastning av Steam-servrar och likaså. Det bör bara ses som en allmän indikator på hur länge man kan förvänta sig att ASF ska vara jordbruk, mycket ofta i bästa fall, eftersom den faktiska tiden kommer att skilja sig åt, även i vissa fall. Som påpekat ovan, försök inte gissa hur länge givet spel kommer att odlas, det är inte upp till dig, varken ASF att bestämma.

---

### Kan ASF fungera på min android/smartphone?

ASF är ett C# program som kräver fungerande genomförande av .NET. Android blev en giltig plattform som börjar med .NET 6. , dock, Det finns för närvarande en stor blockerare för att få ASF att hända på Android på grund av **[brist på ASP. ET-körtid tillgänglig på den](https://github.com/dotnet/aspnetcore/issues/35077)**. Även om det inte finns ett inbyggt alternativ tillgängligt finns det ordentliga och fungerande kompileringar för GNU/Linux på ARM-arkitektur, så det är helt möjligt att använda något som **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** för att installera Linux, sedan använda ASF i sådana Linux-chroot som vanligt.

När/Om alla ASF-krav är uppfyllda, kommer vi att överväga att släppa en officiell Android build.

---

### Kan ASF odla föremål från Steam-spel, som CS:GO eller Ovänd?

**Nej**, detta är mot **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** och Valve tydligt angav att med sista vågen av gemenskapsförbud för odling av TF2-objekt. ASF är ett Steam-kort odlingsprogram, inte spel objekt bonde - det har ingen förmåga att odla spel objekt, och det är inte planerat att lägga till sådan funktion i framtiden, någonsin, främst på grund av brott mot Steams användarvillkor. Fråga inte om detta - det bästa du kan få är en rapport från några salta användare och du har problem. Samma sak gäller för alla andra typer av jordbruk, såsom jordbruk sjunker från CS:GO-sändningar. ASF fokuserar enbart på Steam-handelskort.

---

### Kan jag välja vilka spel som ska odlas?

**Ja**, på flera olika sätt. Om du vill ändra standardordningen för jordbrukskön, då är det vad `FarmingOrder` **[bot konfigurationsegenskapen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** kan användas för. Om du vill manuellt svartlista givna spel från att odlas automatiskt, du kan använda inaktiv svartlista som finns med kommandot `fb` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Om du vill odla allt men ge vissa appar prioritet framför allt annat, det är vad sysslolös prioritet kö tillgänglig med `fq` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** kan användas för. Och slutligen, om du vill odla specifika spel som du väljer bara, sedan kan du deklarera `FarmPriorityQueueOnly` i botens **[`FarmingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)** för att uppnå detta, tillsammans med att lägga till dina valda appar till viloläge prioriterad kö.

Förutom att hantera automatiska kort odlingsmodul som beskrevs ovan, du kan också växla ASF till manuellt odlingsläge med `play` **[-kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, eller använd någon annan misc externa inställningar som `GamesPlayedWhileIdle` **[bot konfigurationsegenskapen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

---

### Jag är inte intresserad av kortdroppar, jag skulle vilja att lantbrukstimmar spelas istället, är det möjligt?

Ja, ASF tillåter dig att göra det genom åtminstone flera sätt.

Det bästa sättet att uppnå detta är att använda **[`spelPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** konfigurationsegenskaper. som kommer att spela dina valda appID när ASF inte har några kort till gården. Om du vill spela dina spel hela tiden, även om du har kort droppar från andra spel, då kan du kombinera det med **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, så ASF kommer att odla endast de spel för kort droppar som du uttryckligen satt, eller, alternativt, **[`JordbrukPausedByDefault`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, vilket gör att kortodlingsmodulen blir pausad tills du själv tar bort den.

Du kan också använda kommandot **[`spela`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#commands-1)** vilket gör att ASF spelar dina valda spel. Kom dock ihåg att `spela` endast bör användas för spel du vill spela tillfälligt, eftersom det inte är ett ihållande tillstånd, orsakar ASF att återgå till standardtillståndet e. . vid frånkoppling från Steam-nätverket. Därför rekommenderar vi att du använder `GamesPlayedWhileIdle`, Om du inte verkligen vill starta dina valda spel bara för en kort tidsperiod, och sedan återgå till allmänt flöde.

---

### Jag är Linux / macOS användare, kommer ASF gård spel som inte är tillgängliga för mitt OS? Kommer ASF gård 64-bitars spel när jag kör det på 32-bitars OS?

Ja, ASF bryr sig inte ens om att ladda ner faktiska spelfiler, så det fungerar med alla dina licenser knutna till ditt Steam-konto, oavsett vilken plattform eller tekniska krav. Det bör också fungera för spel knutna till specifik region (region-låsta spel) även när du inte är i matchande regionen, även om vi inte garanterar det (det fungerade förra gången vi försökt).

---

## Jämförelse med liknande verktyg

---

### Liknar ASF Idle Master?

Den enda likheten är det allmänna syftet med båda programmen, som är jordbruk Steam-spel för att få kort droppar. Allt annat, inklusive den faktiska jordbruksmetoden, programstruktur, funktionalitet, kompatibilitet, används algoritmer, särskilt källkoden själv, är helt annorlunda och dessa två program har inget gemensamt med varandra, även kärnan stiftelsen - IM körs på . ET Framework, ASF on .NET (Core). ASF skapades för att lösa IM problem som inte var möjligt att lösa med en enkel kodredigering - det är därför ASF skrevs från grunden, utan att använda en enda kodrad eller ens allmän idé från IM, eftersom den koden och dessa idéer var helt bristfällig till att börja med. IM och ASF är som Windows och Linux - båda är operativsystem och båda kan installeras på din PC, men de delar nästan ingenting med varandra, förutom att tjäna liknande syfte.

Det är också därför du inte bör jämföra ASF med IM baserat på IM förväntningar. Du bör behandla ASF och IM som helt oberoende program med sina egna exklusiva uppsättningar av funktioner. En del av dem överlappar verkligen och ni kan hitta en speciell egenskap hos dem båda, men mycket sällan, som ASF tjänar sitt syfte med helt olika tillvägagångssätt jämfört med IM.

---

### Är det värt att använda ASF, om jag för närvarande använder Idle Master och det fungerar bra för mig?

**Ja**. ASF är mycket mer tillförlitlig och innehåller många inbyggda funktioner som är **avgörande** oavsett hur du går, att IM helt enkelt inte erbjuder.

ASF har rätt logik för **outgivna spel** - IM kommer att försöka gården spel som har kort lagt redan, även om de inte släpptes ännu. Naturligtvis är det inte möjligt att odla dessa spel fram till releasedatum, så din jordbruksprocess kommer att fastna. Detta kommer att kräva att du antingen lägga till den i svartlistan, vänta på release, eller hoppa över manuellt. Ingen av dessa lösningar är bra, och alla av dem kräver din uppmärksamhet - ASF hoppar automatiskt jordbruk av outgivna spel (tillfälligtvis), och återvänder tillbaka till dem senare när de är, helt undvika problemet och hantera det effektivt.

ASF har också rätt logik i **serie** videor. Det finns många videor på Steam som har kort, men ändå aviseras med fel `appID` på märkessidan, såsom **[Double Fine Adventure](https://store.steampowered.com/app/402590)** - IM kommer falskeligen att driva fel `appID`, som inte kommer att ge några droppar och processen fastnar. Återigen måste du antingen svartlista det eller hoppa över manuellt, båda kräver din uppmärksamhet. ASF upptäcker automatiskt rätt `appID` för jordbruk som resulterar i kortfall.

Förutom det, ASF är **mycket stabilare och pålitligare** när det gäller nätverksproblem och Steam-problem - det fungerar för det mesta och kräver inte din uppmärksamhet alls konfigurerad. medan IM ofta bryts för många människor, kräver extra korrigeringar eller helt enkelt inte fungerar oavsett. Det är också helt beroende av din Steam-klient, vilket innebär att det inte kan fungera när din Steam-klient upplever några allvarliga problem. ASF fungerar korrekt så länge den kan ansluta till Steam-nätverket, och kräver inte att Steam-klienten körs eller ens är installerad.

Dessa är 3 **mycket viktiga** punkter varför du bör överväga att använda ASF, eftersom de direkt påverkar alla som odlar Steam-kort och det finns inget sätt att säga "detta inte anser mig", eftersom Steam-underhåll och egenheter händer med alla. Det finns dussin extra mindre och viktigare skäl som du kan lära dig om i resten av FAQ. Så inom kort, **ja**, du bör använda ASF även när du inte behöver någon extra ASF-funktion som är tillgänglig jämfört med IM.

Dessutom är IM officiellt avbruten och kan bryta helt i framtiden, utan att någon bryr sig om att fixa det, med tanke på att det finns mycket mer kraftfulla lösningar (inte bara ASF). IM fungerar redan inte för många människor, och det antalet går bara upp, inte ner. Du bör undvika att använda föråldrad programvara i första hand, inte bara IM men alla andra föråldrade program också. Ingen aktiv utvecklare innebär att ingen bryr sig om om det fungerar eller inte, och **ingen är ansvarig för dess funktionalitet**, vilket är en avgörande fråga när det gäller säkerhet. Det räcker med att det kommer att finnas ett kritiskt fel som orsakar faktiska problem för Steam-infrastrukturen - utan att någon rättar det, Steam kan utfärda en annan förbud våg där du kommer att drabbas utan att ens vara medveten om att detta är ett problem, som redan hänt med människor som använder, gissa vad, föråldrad version av ASF.

---

### Vilka intressanta funktioner ASF erbjuder att Idle Master inte?

Det beror på vad du anser vara "intressant" för dig. Om du planerar att odla fler konton än en då svaret är redan uppenbart eftersom ASF tillåter dig att odla dem alla med en överlägsen lösning, spara resurser, krångel och kompatibilitetsproblem. Men om du ställer den frågan då mest troligt att du inte har detta speciella behov, så låt oss utvärdera andra fördelar som gäller för ett enda konto som används i ASF.

Först och främst du har några inbyggda funktioner som nämns **[ovanför](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** som är kärnan för jordbruk oavsett ditt slutmål, och mycket ofta att ensam är redan tillräckligt för att överväga att använda ASF. Men du vet redan det, så låt oss gå vidare till några mer intressanta funktioner:

- **Du kan odla offline** (`OnlineStatus` i `Offline` inställning). Att odla offline gör det möjligt för dig att helt hoppa över din Steam-status i spelet, vilket gör att du kan odla med ASF medan du visar "Online" på Steam samtidigt, utan att dina vänner ens märker att ASF spelar ett spel för din räkning. Detta är överlägsen funktion, eftersom det gör att du kan stanna online i din Steam-klient, utan att irritera dina vänner med ständiga speländringar. eller vilseleda dem till att tro att du spelar ett spel medan i verkligheten är du inte. Bara denna punkt gör det värt att använda ASF om du respekterar dina egna vänner, men det är bara början. Det är också trevligt att notera att denna funktion inte har något att göra med Steam sekretessinställningar - om du startar spelet själv, då kommer du att visa som i spelet för dina vänner, vilket gör endast ASF del osynlig och inte påverkar ditt konto alls.

- **Du kan hoppa över återbetalningsbara spel** (`SkipÅterbetalningsbara spel` i botens `FarmingPreferences` funktion). ASF har rätt inbyggd logik för återbetalningsbara spel och du kan konfigurera ASF att inte gården återbetalningsbara spel automatiskt. Detta gör att du kan utvärdera dig själv om ditt nyköpta spel från Steam-butiken var värt dina pengar, utan att ASF försöker släppa kort från det så snart som möjligt. Om du spelar i 2 + timmar, eller 2 veckor passera sedan ditt köp, då ASF kommer att fortsätta med det spelet eftersom det inte återbetalas längre. Fram till dess har du full kontroll över om du gillar det eller inte och du kan enkelt återbetala det om det behövs, utan att manuellt svartlista det spelet eller inte använda ASF för hela varaktigheten.

- **Du kan hoppa över ospelade partier** (`SkipUnplayedGames` i botens `FarmingPreferences` funktion). ASF har rätt inbyggd logik i timmar i spel och du kan konfigurera ASF att inte odla ospelade spel automatiskt. Detta gör att du kan styra dig själv de spel du spelar och gård, utan att manuellt svartlista dem alla eller hoppa över att använda ASF helt.

- **Du kan automatiskt markera nya objekt som mottagna** (`BotBehaviour` av `DismissInventoryNotifications` funktionen). Jordbruk med ASF kommer att resultera i att ditt konto får nya kort droppar. Du vet redan att detta kommer att hända, så låt ASF klargöra att värdelös anmälan för dig, se till att bara viktiga saker kommer att öka er uppmärksamhet. Naturligtvis bara om du vill.

- **Du kan anpassa önskad jordbruksorder med fler tillgängliga alternativ** (`FarmingOrders` funktion). Kanske vill du odla dina nyköpta spel först? Eller dina äldste? Enligt antalet kort droppar? Märken nivåer du redan tillverkat? Spelade timmar? Alfabetiskt? Enligt AppID? Eller kanske helt slumpmässigt? Det är helt upp till dig att bestämma.

- **ASF kan hjälpa dig att slutföra dina set** (`TradingPreferences` med `SteamTradeMatcher` funktion). Med lite mer avancerad mixtring, du kan konvertera din ASF till fullfjädrad användarbot som automatiskt accepterar **[STM](https://www.steamtradematcher.com)** erbjudanden, hjälper dig varje dag att matcha dina set utan någon användarinteraktion. ASF innehåller även sin alldeles egna ASF 2FA modul som låter dig importera din Steam mobil-autentiserare och låter dig helt automatisera hela processen med att acceptera bekräftelser. Eller kanske du vill acceptera manuellt och låta ASF bara förbereda dessa affärer för dig? Det är återigen helt upp till dig att bestämma.

- **ASF kan lösa in nycklar i bakgrunden för dig** (**[bakgrundsspel återlösare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** funktion). Kanske har du hundra nycklar från olika buntar att du är för lat för att lösa in dig själv, gå igenom massor av fönster och godkänna Steam-villkor om och om igen. Varför inte kopiera-klistra in din lista över nycklar i ASF och låt den göra sitt jobb? ASF kommer automatiskt lösa in alla dessa nycklar i bakgrunden, vilket ger dig lämplig utdata för att låta dig veta hur varje lösa in försök visade sig. Dessutom, om du har hundratals nycklar, du är garanterad att få rate-limited av Steam förr eller senare, och ASF vet också om det, det kommer tålmodigt vänta på räntegränsen att gå bort, och återuppta där den lämnade.

Vi kunde nu fortsätta med hela **[ASF wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**, peka ut varje enskild funktion i programmet, men vi måste dra en linje någonstans. Detta är det, detta är en lista över funktioner som du kan njuta av som ASF användare, där bara en av dem lätt kan anses vara en viktig anledning att aldrig se tillbaka, och vi listade faktiskt **en hel del** av dem, med ännu mer kan du lära dig om på resten av vår wiki. Ah ja, och vi gick inte ens in i detalj med saker som ASF: s API så att du kan skript dina egna kommandon, eller fantastisk bot förvaltning, eftersom vi ville hålla det enkelt.

---

### Är ASF snabbare än Idle Master?

**Ja**, även om förklaringen är ganska komplicerad.

På varje ny process som skapas och avslutas på ditt system, ångklient skickar automatiskt en begäran som innehåller alla dina spel som du spelar just nu - på så sätt kan ångnätet beräkna timmar och göra kort släppa. Men ångnätet räknar din tid som spelas i 1-sekunders intervaller, och skicka ny begäran återställer aktuell status. Med andra ord, om du gjorde spawn/döda ny process var 0.5 sekund, skulle du aldrig släppa något kort på grund av varje 0. andra ångan klienten skulle skicka en ny begäran och ångnätet skulle aldrig räknas ens 1 sekund speltid. Dessutom, på grund av hur operativsystemet fungerar, är det faktiskt ganska vanligt att se nya processer skapas / avslutas utan att du ens gör något, så även om du inte gör något på datorn - det finns många processer som fortfarande arbetar i bakgrunden, leka/avsluta andra processer hela tiden. Idle master är baserad på ångklient, så denna mekanism påverkar dig om du använder den.

ASF är inte baserad på ångklient, det har en egen ångklient genomförande. Tack vare det, vad ASF gör, är inte att leka någon process, men faktiskt skicka en, verklig begäran till ångnätet som vi började spela ett spel. Detta är samma begäran som skulle skickas av ångkunden, men eftersom vi har verklig kontroll över ASF ångklient, behöver vi inte skapa nya processer, och vi imiterar inte ångklient när det gäller att skicka förfrågan om varje processändring, så mekanismen som förklaras ovan påverkar oss inte. Tack vare det avbryter vi aldrig det där intervallet 1 sekund på ångnätssidan, och det ökar vår jordbrukshastighet.

---

### Men är skillnaden verkligen märkbar?

Nej. De avbrott som sker med normal ångklient och tomgång mästare har försumbar effekt på kortets droppar, så det är inte någon märkbar skillnad som skulle göra ASF överlägsen.

Det finns dock **** en skillnad, och du kan tydligt märka att, beroende på hur upptagen ditt OS är, kort **kommer** släppas snabbare, från några sekunder till ännu några minuter, om du har extremt otur. Även om jag inte skulle överväga att använda ASF bara för att det droppar kort snabbare, eftersom både ASF och Idle Master påverkas av hur steam web fungerar, ASF interagerar bara med ångnätet mer effektivt, medan Idle Master inte kan styra vad ångklient faktiskt gör (så är det inte Idle Mästarens fel, utan ångklienten själv).

---

### Kan ASF gård flera spel på en gång?

**Ja**, även om ASF vet bättre när den funktionen ska användas, baserat på valda **[kort odlingsalgoritm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Kortet droppar hastighet när jordbruket flera spel är nära noll, Det är därför ASF använder flera spel jordbruk uteslutande i timmar för att övervinna `TimmarUntilCardDrops` snabbare, för upp till `32` partier samtidigt. Det är också därför du bör fokusera på konfigurationsdelen av ASF, och låt algoritmer bestämma vad som är det bästa sättet att uppnå målet - vad du tycker är rätt, är inte nödvändigtvis rätt i verkligheten, jordbruk flera spel på en gång inte kommer att ge dig några kort droppar.

---

### Kan ASF hoppa igenom spel snabbt?

**Nej**, ASF stöder inte, inte heller uppmuntrar användning av **[Steam buggar](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance#steam-glitches)**.

---

### Kan ASF automatiskt spela varje spel i X timmar innan korten läggs till?

**No**, hela poängen med Steam-kort systemförändring var att kämpa med falsk statistik och spökspelare. ASF kommer inte att bidra till att mer än nödvändigt, lägga till sådan funktion är inte planerat och kommer inte att hända. Om ditt spel får kort droppar på vanligt sätt, ASF kommer att odla dem så snart som möjligt.

---

### Kan jag spela ett spel medan ASF odlas?

**Nej**. ASF, till skillnad från vissa andra verktyg som integrerar med din Steam-klient, har sitt oberoende genomförande av den klienten inkluderat, och Steam-nätverket tillåter endast **en Steam-klient åt gången** att spela ett spel. Du kan dock koppla bort ASF när du vill genom att starta ett spel (och klicka på "OK" på frågan om Steam-nätverket ska koppla från andra klienter) - ASF kommer sedan tålmodigt vänta tills du är klar med att spela, och återuppta processen efteråt. Alternativt kan du fortfarande spela i offline-läge när du vill, om det är tillfredsställande för dig.

Tänk på att kort droppe hastighet när du spelar flera spel är nära noll ändå, därför finns det inga direkta fördelar med att kunna göra det med några andra verktyg, samtidigt som det finns starka fördelar med att inte störa andra spel som lanseras med ASF, vilket är avgörande e. . – VAC-klokt.

---

## Säkerhet / Sekretess / VAC / Förbud / ToS

---

### Kan jag få VAC förbud för att använda detta?

Nej, det är inte möjligt eftersom ASF (till skillnad från vissa andra verktyg, såsom Idle Master, SGI eller SAM) blandar sig inte på något sätt i ångklienten eller dess processer. Det är fysiskt omöjligt att få VAC förbud för att använda ASF, även under uppspelning på säkra servrar medan ASF körs - detta beror på att **ASF inte ens kräver att Steam-klienten installeras alls** för att fungera korrekt. ASF är ett av de enda få jordbruksprogram som för närvarande kan garantera att vara VAC-fri.

---

### Kan använda ASF hindra mig från att spela på VAC-säkrade servrar, som anges **[här](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**?

ASF kräver inte att Steam-klienten körs eller ens installeras alls. Enligt detta koncept, bör det **inte** orsaka några VAC-relaterade frågor, eftersom ASF garanterar brist på att störa Steam-klienten och alla dess processer - detta är huvudpunkten när man talar om VAC-fri garanti som ASF erbjuder.

Enligt användarna och bäst av min vetskap är detta fallet just nu, eftersom ingen rapporterade några problem som anges i länken ovan när du använder ASF. Vi kunde inte reproducera problemet ovan med ASF också, medan tydligt reproducera det med Idle Master.

Men tänk på att termostaten fortfarande kan lägga till ASF till den svarta listan någon gång, men det är ett fullständigt nonsens som även om de gör det, du kan fortfarande spela VAC-säkrade spel från din dator, och använda ASF samtidigt. . på din server, så jag är ganska säker på att de vet mycket väl att ASF inte bör vara en misstänkt VAC-wise, och de kommer inte att göra våra liv svårare genom att svartlista ASF utan anledning. Fortfarande, i värsta fall du inte kan spela, som anges ovan, eftersom VAC-fri garanti för ASF fortfarande är här oavsett om Steam svartlistar ASF binär, eller inte (och du kan fortfarande starta ASF på någon annan maskin utan att Steam-klienten alls är installerad). Just nu finns det inget behov av att göra något av det, och låt oss hoppas att det förblir så här.

---

### Är det säkert?

Om du frågar om ASF är säker som en programvara, vilket innebär att det inte kommer att orsaka någon skada på din dator, kommer inte att stjäla dina privata data, installera virus eller något annat sådant - det är säkert. ASF är fri från skadlig kod, data stjäla, cryptocurrency gruvarbetare och alla (och alla) andra tvivelaktiga beteende som kan anses skadliga eller oönskade av användaren. Utöver detta har vi en dedikerad **[fjärrkommunikation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** sektion som täcker vår sekretesspolicy och ASF beteende som går utöver vad du konfigurerade programmet för att göra dig själv.

Vår kod är öppen källkod, och distribuerade binärer kompileras alltid från **[offentligt tillgängliga källor](https://en.wikipedia.org/wiki/Open-source_software)** av **[automatiserade och betrodda kontinuerliga integrationssystem](https://en.wikipedia.org/wiki/Build_automation)**, och inte ens utvecklarna själva. Varje bygg är reproducerbar genom att följa vårt bygg skript och kommer att resultera i exakt samma, **[deterministisk](https://en.wikipedia.org/wiki/Deterministic_system)** IL (binärt) kod. Om du av någon anledning inte litar på våra byggen kan du alltid kompilera och använda ASF från källan, inklusive alla bibliotek som ASF använder (såsom SteamKit2), som är öppen källkod också.

I slutändan är det dock alltid en fråga om förtroende för utvecklarna av din ansökan, så du bör själv bestämma om du anser ASF säker eller inte, potentiellt stödja ditt beslut med tekniska argument som anges ovan. Tro inte blint på något bara för att vi sa det - kontrollera dig själv, eftersom det är det enda sättet att se till.

---

### Kan jag bli bannlyst för detta?

För att besvara den frågan bör vi titta närmare på **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Steam förbjuder inte användning av flera konton, faktiskt, **[den tillåter det](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)** vilket innebär att du kan använda samma mobilautentisering på fler än ett konto. Vad det däremot inte tillåter är att dela konton med andra människor, men vi gör det inte här.

Den enda verkliga punkten som anser att ASF är följande:
> Du får inte använda fusk, automationsprogram (bots), mods, hacks eller någon annan obehörig tredjepartsprogramvara för att ändra eller automatisera prenumerationsmarknadsprocessen.

Frågan är vad som egentligen är prenumerationsmarknadsprocessen. Som vi kan läsa:

> Ett exempel på en prenumerationsmarknad är Steams gemenskapsmarknad

Vi ändrar inte eller automatiserar prenumerationsmarknadsprocessen, om vi genom prenumerationsmarknadsplats förstår ångmarknaden eller ångbutiken. Men ...

> Ventilen kan när som helst avbryta ditt konto eller någon särskild prenumeration om (a) ventilen upphör att tillhandahålla sådana prenumerationer till prenumeranter på liknande sätt i allmänhet, eller (b) du bryter mot några villkor i detta avtal (inklusive Abonnemangsvillkor eller användningsregler).

Därför, som med alla Steam-program, ASF är inte auktoriserad av Valve och jag kan inte garantera att du inte kommer att stängas av om Valve plötsligt beslutar att de förbjuder konton som använder ASF nu. Detta är extremt osannolikt med tanke på att ASF används på mer än några miljoner Steam-konton, sedan dess första utgåva som hände över 10 år sedan - men fortfarande en möjlighet, oavsett faktisk sannolikhet.

Speciellt eftersom:
> När det gäller alla prenumerationer, innehåll och tjänster som inte är skrivna av Valve, Ventilen visar inte sådant innehåll från tredje part som finns tillgängligt på Steam eller via andra källor. Ventilen tar inget ansvar för sådant innehåll från tredje part. Vissa tredjepartsprogram är kapabla att användas av företag för affärsändamål - dock du får endast förvärva sådan programvara via Steam för privat bruk.

Ventilen bekräftar dock tydligt att "Steam-idlers" existerar, som angivet **[här](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**, så om du frågade mig, Jag är ganska säker på att om de inte vore bra med dem så skulle de redan göra något istället för att påpeka att de kunde orsaka problem VAC-wise. Nyckelordet här är **Steam** idlers, till exempel ASF, och inte **spel** idlers.

Observera att ovan är endast vår tolkning av **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** och olika punkter - ASF är licensierad under Apache 2. Licens, som tydligt lyder:

```
Om det inte krävs enligt tillämplig lag eller skriftligen avtalat om att programvara
distribueras under licensen distribueras på en "AS IS" BASIS,
UTAN GARANTIER ELLER VILLKOR AV NÅGON KIND, antingen uttryckliga eller underförstådda.
```

Du använder denna programvara på egen risk. Det är mycket osannolikt att du kan bli bannlyst för det, men om du gör det, kan du skylla bara dig själv för det.

---

### Har någon blivit bannlyst för det?

**Ja**, Vi hade åtminstone några incidenter hittills som resulterade i någon form av Steam suspension. Huruvida ASF själv var orsaken eller inte är helt annorlunda historia som vi förmodligen aldrig kommer att lära känna.

Första fallet involverade en kille med över 1000+ robotar som fick bytesförbud (tillsammans med alla bots), mest sannolikt på grund av överdriven användning av `loot ASF` körs på alla robotar på en gång, eller andra misstänkta ensidiga mängder av affärer på mycket kort tid.

> Hej XXX, Tack för att du kontaktar Steam Support. Det ser ut som detta konto användes för att hantera ett nätverk av bot konton. Botting är ett brott mot Steam-prenumerantavtalet.

Snälla, använd något sunt förnuft och anta inte att du kan göra sådana galna saker bara eftersom ASF tillåter dig att göra det. Att göra `loot ASF` på över 1k robotar kan lätt betraktas som en **[DDoS](https://en.wikipedia.org/wiki/DDoS)** attack, och personligen är jag inte chockad över att någon blev förbjuden för en sådan sak. Håll minimum av tillåten användning när det gäller Steam-tjänsten, och **troligtvis** kommer du att vara bra.

Andra fallet involverade en kille med 170+ robotar som blev förbjudna under Steams vinterrea 2017.

> Ditt konto blockerades för brott mot avtalet med prenumeranten Steam. Att döma av utbyten och andra faktorer, detta konto användes för att olagligt samla in samlarkort på Steam, såväl som relaterade och inte bara kommersiella aktiviteter. Kontot har blockerats permanent och Steam Support kan inte ge ytterligare support i detta problem.

Detta fall är återigen mycket svårt att analysera, på grund av vaga svar från Steam-stöd som knappt erbjuder några detaljer. Baserat på mina personliga tankar, denna användare bytte förmodligen Steam-kort mot någon form av pengar (nivå upp bot? eller på annat sätt försökte ta ut pengar på Steam. Om du var omedveten, detta är också olagligt enligt **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Vi är inte i stånd att berätta vad du kan göra med handelskort som erhållits via ASF - men användaren i fråga definitivt inte bara hantverk märken med dem.

Tredje fallet involverade användare med 120+ robotar som bannlyses för brott mot **[Steam online conduct](https://store.steampowered.com/online_conduct?l=english)**.

> Hej XXX, Tack för att du kontaktar Steam Support. Detta och andra konton användes för att översvämma vår nätverksinfrastruktur, vilket är ett brott mot Steam online uppförande. Kontot har blockerats permanent och Steam Support kan inte ge ytterligare support i detta problem.

Detta fall är lite lättare att analysera på grund av extra detaljer som tillhandahålls av användaren. Tydligen använde användaren **en mycket föråldrad ASF-version** som inkluderade en bugg som orsakade ASF att skicka ett stort antal förfrågningar till Steam-servrar. Själva felet fanns inte till en början men aktiverades på grund av Steam-brytningsändringen som rättades till i framtida version. **ASF stöds endast i [senaste stabila versionen](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) släpptes på GitHub**.

Du kan inte anta att någon föråldrad ASF-version kommer att fungera på samma sätt som den brukade fungera för alltid, speciellt för att Steam hela tiden förändras oavsett om du gillar det eller inte. Om något sådant händer globalt, det är snabbt att lappas upp och släppas till alla användare som en buggfix. Ventilen kommer inte plötsligt att banna över en miljon ASF-användare på grund av vårt eller deras misstag, av uppenbara skäl. Men om du medvetet avgår från att använda uppdaterad ASF, sedan per definition är du i en mycket liten minoritet av användare som är **utsatta för incidenter som dessa** på grund av **inget stöd**, eftersom det inte finns någon som bevakar din föråldrade version av ASF, ingen fixar det och ingen ser till att du inte blir direkt förbjuden genom att bara lansera det. **Använd uppdaterad programvara**, inte bara ASF, utan även alla andra program.

Det senaste fallet hände runt juni 2021, enligt användaren:

> Med hjälp av ditt program, har jag gjort boosterpaket med 28 konton för 3 år och med 128 konton för de senaste 6 månaderna. Jag var online med maximalt 15 konton samtidigt för att göra booster paket och skicka dem till huvudkontot. Förra månaden ökade jag antalet online-konton samtidigt till 20, och 1 vecka efter det, alla mina konton var förbjudna. Detta e-postmeddelande är inte att skylla på dig, tvärtom, jag var alltid medveten om konsekvenserna. Jag ville att du skulle veta vilka typer av beteende som resulterar i ett permanent förbud.

Det är svårt att säga om ökningen av samtidiga konton på nätet var den direkta orsaken till förbudet, Jag skulle inte räkna med det, i stället tror jag att antalet konton i sig var den största boven Ökad konvaluta av online-konton förmodligen bara uppmärksammade användaren i fråga, eftersom han uppenbarligen hade mycket fler robotar än vår rekommendation.

---

Alla händelser ovan har en sak gemensamt - ASF är bara ett verktyg och det är **ditt** beslut hur du ska använda det. Du blir inte bannad för att använda ASF direkt, men för **hur** du använder det. Det kan vara ett hjälpmedel för jordbruket bara en enda räkning, eller ett massivt jordbruksnätverk som består av tusentals botar. I vilket fall som helst, jag erbjuder inte juridisk rådgivning, och du bör själv bestämma om din ASF användning i första hand. Jag döljer inte någon information som kan hjälpa dig, t.ex. det faktum att ASF fick vissa människor förbjudna (och i vilket sammanhang), eftersom jag inte har någon anledning till - det är ditt val vad du vill göra med den informationen.

Om du frågar mig - använd något sunt förnuft, undvik att äga fler robotar än vår rekommendation, skicka inte hundratals affärer samtidigt, använd alltid aktuell ASF-version och du _borde_ vara bra. Varje enskild händelse av denna typ av **någon anledning** hände alltid med människor som har ignorerat våra rekommendationer, bästa praxis och förslag, tro att de vet bättre än oss e. . hur många robotar de kan köra. Oavsett om det bara är en tillfällighet eller någon faktisk faktor, det är upp till dig att bestämma. Vi erbjuder inte någon juridisk rådgivning, bara ge dig våra tankar som du kan hitta användbara, eller bortse från dem helt och endast från fakta som är kopplade ovan.

---

### Vilken sekretessinformation ASF avslöjar?

Du hittar detaljerad förklaring i **[fjärrkommunikation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** sektionen. Du bör granska det om du bryr dig om din integritet, t.ex. om du undrar varför konton som används i ASF går med i vår Steam-grupp. ASF samlar inte in någon känslig information och delar den inte med någon tredje part.

---

## Övrigt

---

### Jag använder OS som inte stöds som 32-bitars Windows, kan jag fortfarande använda den senaste versionen av ASF?

Ja, och den versionen stöds inte på något sätt, bara inte officiellt byggt. Kolla in **[-kompatibilitet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** -sektionen för generisk variant. ASF har inget starkt beroende av OS, och det kan fungera var som helst där du kan få ett arbete. ET-körtid, som inkluderar 32-bitars Windows, även om det inte finns något `win-x86` OS-specifikt paket från oss.

---

### ASF är bra! Kan jag göra en donation?

Ja, och vi är väldigt glada att höra att du njuter av vårt projekt! Du hittar olika donationsmöjligheter under varje **[utgåva](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** och även **[på huvudsidan](https://github.com/JustArchiNET/ArchiSteamFarm)**. Det är trevligt att notera att förutom generiska pengar donationer accepterar vi även Steam-artiklar, så ingenting hindrar dig från att donera skinn, nycklar eller en liten del av de kort som du har odlat med ASF om du vill. Tack på förhand för din generositet!

---

### Jag använder Steams föräldra-PIN-kod för att skydda mitt konto, behöver jag ange den någonstans?

Ja, du måste ställa in det i `SteamParentalCode` bot config egendom. Detta beror främst på att ASF har tillgång till många skyddade delar av ditt Steam-konto och det är omöjligt för ASF att använda utan det.

---

### Jag vill inte att ASF att odla några spel som standard, men jag vill använda extra ASF funktioner. Är detta möjligt?

Ja, om du bara vill starta ASF med pausade kort odlingsmodul, du kan ställa in `FarmingPausedByDefault` i `FarmingPreferences` bot config egenskap för att uppnå det. Detta gör att du kan `återuppta` det under körtid.

Om du vill helt inaktivera kort odlingsmodul och se till att det aldrig kommer att köras utan att du uttryckligen säga det annars, sedan rekommenderar vi att sätta `FarmPriorityQueueOnly` i botens `FarmingPreferences`, som istället för att bara pausa det, kommer att inaktivera jordbruket helt tills du lägger till spel tomgång prioritet kö själv.

Med kortodlingsmodulen pausad/inaktiverad kan du använda dig av extra ASF-funktioner, till exempel `GamesPlayedWhileIdle`.

---

### Kan ASF minimera att bricka?

ASF är en konsolapp, det finns inget fönster att minimera, eftersom fönstret skapas för dig av ditt OS. Du kan dock använda alla tredjepartsverktyg som kan göra det, såsom **[RBTray](https://github.com/benbuck/rbtray)** för Windows, eller **[skärm](https://linux.die.net/man/1/screen)** för Linux/macOS. Det är bara exempel, det finns många andra appar med liknande funktionalitet.

---

### Har användning ASF bevara stödberättigande för att få boosterpaket?

**Ja**. ASF använder samma metod för att logga in på Steam-nätverket som den officiella klienten, Därför bevarar den också möjligheten att ta emot boosterpaket för konton som används i ASF. Dessutom, att bevara denna förmåga kräver inte ens inloggning i Steam-gemenskapen, så att du säkert kan använda `OnlineStatus` i `Offline` -inställningen om du vill.

---

### Finns det något sätt att kommunicera med ASF?

Ja, på flera olika sätt. Kolla in **[kommandon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** för mer information.

---

### Jag skulle vilja hjälpa till med ASF-översättning, vad behöver jag göra?

Tack för ditt intresse! Du hittar alla detaljer i vår **[lokalisering](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** sektion.

---

### Jag har bara ett (huvud) konto tillagt till ASF, kan jag fortfarande utfärda kommandon via steam chat?

**Ja**, den förklaras i **[kommandon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#notes)** avsnitt. Du kan göra det genom Steam-gruppchatt, även om det kan vara lättare att använda **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** för dig.

---

### ASF verkar fungera, men jag tar inte emot några kortdroppar!

Kortodlingen skiljer sig från spel till spel, som du kan läsa i **[prestanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Det tar ett tag, vanligtvis **flera timmar per match**, och du bör inte förvänta sig kort att släppa i några minuter sedan lanseringen av ett program. Om du kan se att ASF aktivt kontrollerar kortens status, och växlar spelet efter nuvarande en är fullodlad, då allt fungerar bra. Det är möjligt att du har aktiverat ett alternativ som `DismissInventoryNotifications` av `BotBehaviour` som automatiskt avfärdar inventering meddelanden. Kolla in **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** för detaljer.

---

### Hur stoppar jag helt ASF-processen för mitt konto?

Stäng helt enkelt ASF-processen, till exempel genom att klicka på [X] på Windows. Om du istället vill stoppa en viss bot av ditt val men hålla andra körs, ta en titt på `Aktiverad` **[bot config egenskap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**, eller `stoppa` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Om du istället vill stoppa automatisk odling, men ändå hålla ASF igång för ditt konto, då är det vad `FarmingPausedByDefault` alternativet `FarmingPreferences` i **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** och `paus` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** är till.

---

### Hur många robotar kan jag köra med ASF?

ASF som ett program har ingen hård övre gräns för bot instanser, så att du kan köra så mycket som du har minne på din maskin, Du begränsas dock fortfarande av Steam-nätverket och andra Steam-tjänster. För närvarande kan du köra upp till 100-200 robotar med en enda IP och en enda ASF-instans. Det är möjligt att köra fler robotar med fler IP-adresser och fler ASF-instanser, genom att arbeta runt IP-begränsningar. Tänk på att om du använder den stora mängden botar, bör du kontrollera deras antal själv, som att se till att alla faktiskt loggar in och arbetar samtidigt. ASF var inte tweaked för det enorma antalet botar, och den allmänna regeln gäller att **ju fler robotar du har, desto fler problem kommer du att stöta på**. Notera också att gränsen ovan i allmänhet beror på många interna faktorer, det är approximation snarare än en strikt gräns - du kommer sannolikt att kunna köra mer / mindre robotar än vad som anges ovan.

ASF-teamet föreslår att **äger** upp till **10 Steam-konton totalt**, och därför också kör upp till **10 robotar totalt**. Allt ovan stöds inte och görs på egen risk, mot vårt förslag som lagts fram här. Denna rekommendation bygger på interna riktlinjer för termostaten och våra egna förslag. Oavsett om du kommer att följa denna regel eller inte är ditt val, ASF som ett verktyg kommer inte att gå emot din egen vilja, även om det resulterar i att dina Steam-konton stängs av för att göra så. Därför ASF kommer att visa dig en varning om du går över vad vi rekommenderar, men ändå tillåta dig att köra allt du vill på egen risk och brist på vårt stöd.

---

### Kan jag köra fler ASF-instanser då?

Du kan köra så många ASF instanser på en maskin som du vill, förutsatt att varje instans har sin egen katalog och sina egna konfigurationer, och konto som används i en instans används inte i en annan. Men fråga dig själv varför du vill göra det. ASF är optimerad för att hantera mer än hundra konton samtidigt, och lansera de hundra robotar i sina egna ASF fall försämrar prestanda, tar mer OS-resurser (såsom CPU och minne), och orsakar en potentiell synkronisering problem mellan fristående ASF-instanser, som ASF tvingas att dela sina begränsare med andra instanser.

Därför är mitt **starka förslag** att alltid köra maximalt en ASF-instans per ett IP/gränssnitt. Har du fler IP-adresser/gränssnitt kan du med alla medel köra fler ASF-instanser, med varje instans som använder sin egen IP/gränssnitt eller unika `WebProxy` inställning. Om du inte gör det, är lanseringen av fler ASF instanser helt meningslös, eftersom du inte kommer att vinna något på att lansera mer än 1 instans per ett enda IP/gränssnitt. Steam kommer inte magiskt låta dig köra fler robotar bara för att du har lanserat dem i en annan ASF-instans, och ASF begränsar dig inte till att börja med.

Naturligtvis finns det fortfarande giltiga användningsfall för flera ASF-instanser på samma nätverksgränssnitt, till exempel ASF-tjänst för dina vänner med varje vän som har sin egen unika ASF-instans för att garantera isolering mellan robotar och även ASF-processer själva, Men du kringgår inte några Steam-begränsningar på detta sätt, det är helt annorlunda syfte.

---

### Vad betyder status när man löser in en nyckel?

Status anger hur givet försök visade sig. Det finns många olika statusar möjliga, de vanligaste inkluderar:

| Status                  | Beskrivning                                                                                                                                                                                                            |
| ----------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| NoDetail                | "OK" status som indikerar framgång - nyckeln har förverkats.                                                                                                                                                           |
| Timeout                 | Steam-nätverket svarade inte på given tid, vi vet inte om nyckeln var löst, eller inte (troligtvis var, men du kan försöka igen).                                                                                      |
| BadActivationCode       | Den angivna nyckeln är ogiltig (inte erkänd som någon giltig nyckel av Steam-nätverket).                                                                                                                               |
| DuplicateAktiveringskod | Den angivna nyckeln har redan lösts in av något annat konto, eller återkallats av utvecklare/utgivare.                                                                                                                 |
| RedanKöpt               | Ditt konto äger redan `packageID` som är kopplat till denna nyckel. Tänk på att detta inte anger om nyckeln är `DuplicateActivationCode` eller inte - bara att den är giltig och att den inte användes i detta försök. |
| BegränsatLand           | Detta är region-låst nyckel och ditt konto är inte i den giltiga regionen som är tillåten att lösa in den.                                                                                                             |
| NotOwnRequiredApp       | Du kan inte lösa in den nyckeln eftersom du saknar någon annan app - huvudsakligen basspel när du försöker lösa in DLC-paketet.                                                                                        |
| RateLimited             | Du gjorde för många försök att lösa in och ditt konto blockerades tillfälligt. Försök igen om en timme.                                                                                                                |

---

### Är du ansluten till några kort odling/farmningstjänst?

**Nej**. ASF är inte ansluten till någon tjänst och alla sådana påståenden är falska. Ditt Steam-konto är din egendom och du kan använda ditt konto på vilket sätt du vill, men Valve tydligt anges i **[officiella ToS](https://store.steampowered.com/subscriber_agreement)** att:

> Du ansvarar för sekretessen för ditt användarnamn och lösenord och för säkerheten i ditt datorsystem. Ventilen ansvarar inte för användningen av ditt lösenord och konto eller för all kommunikation och aktivitet på Steam som är resultatet av att du använder ditt användarnamn och lösenord, eller av någon person som du avsiktligt eller genom vårdslöshet avslöjat ditt användarnamn och/eller lösenord i strid med denna sekretessbestämmelse.

ASF är licensierad på liberal Apache 2.0 License, vilket gör det möjligt för andra utvecklare att ytterligare integrera ASF med sina egna projekt och tjänster lagligt. Dock är sådana tredjepartsprojekt som använder ASF inte garanterade att vara säkra, granskade, lämpliga eller lagliga enligt **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Om du vill veta vår åsikt, **Vi rekommenderar starkt att du INTE dela några av dina kontouppgifter med tjänster från tredje part**. Om sådan tjänst visar sig vara en **typisk bluff**, kommer du lämnas ensam med problemet, troligtvis utan ditt Steam-konto och ASF tar inget ansvar för tredjepartstjänster som påstår sig vara säkra och säkra, eftersom ASF team inte auktoriserat varken granskat någon av dem. Med andra ord, **du använder dem på egen risk, mot vårt förslag som gjorts ovan**.

Dessutom, officiella **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** anger tydligt att:

> Du får inte avslöja, dela eller på annat sätt tillåta andra att använda ditt lösenord eller konto förutom som på annat sätt godkänts av Valve.

Det är ditt konto och ditt val. Säg bara inte att ingen varnade dig. ASF som ett program uppfyller alla regler som nämns ovan, eftersom du inte delar dina kontouppgifter med någon, och du använder programmet för ditt eget personliga bruk, men någon annan "kort odlingstjänst" kräver av dig dina kontouppgifter, så det bryter också mot regeln ovan (faktiskt flera av dem). Gilla med **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** utvärdering, Vi erbjuder ingen juridisk rådgivning och du bör själv bestämma om du vill använda dessa tjänster, eller inte - enligt oss **bryter det direkt mot [Steam ToS](https://store.steampowered.com/subscriber_agreement)** och kan resultera i avstängning om ventilen får reda på det. Som påpekat ovan, **rekommenderar vi starkt att INTE använda någon av dessa tjänster**.

---

## Problem

---

### Ett av mina spel är att odlas i mer än 10 timmar nu, men jag fick fortfarande inga kort från det!

Anledningen till det kan vara relaterad till kända frågan om Steam, vilket händer när du har två licenser för samma spel, varav en har kort droppar begränsade. Detta händer vanligtvis när du aktiverar spelet gratis under en massa giveaway på Steam, och sedan aktivera en nyckel för samma spel (men utan begränsningar), e. . från en betald bunt. Om en sådan situation inträffar har Steam-rapporter på märkessidan det spelet fortfarande kort att släppa, men oavsett hur mycket du spelar spelet - kort kommer aldrig att falla på grund av fri licens på ditt konto. Eftersom det inte är en ASF-fråga, utan en Steam-sådan, kan vi inte på något sätt kringgå den på ASF:s sida, och du måste själv lösa den.

Det finns två sätt att lösa problemet. För det första, du kan svartlista detta spel i ASF, antingen med `fbadd` **[-kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** eller med `Svartlista` **[konfigurationsegenskapen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Detta kommer att förhindra ASF från att försöka bondgård kort från detta spel, men kommer inte att lösa den underliggande frågan som hindrar dig från att få kort droppar från det drabbade spelet. För det andra kan du använda Steam-supportens självbetjäningsverktyg för att ta bort fri licens från ditt konto och endast lämna full licens som inkluderar kortets droppar. För att göra det, först besöka din **[licenser och produktnyckel aktiveringar](https://store.steampowered.com/account/licenses)** sidan och hitta både gratis och betalkort för det drabbade spelet. Vanligtvis är det ganska enkelt - båda har liknande namn, men gratis ett har "begränsat gratis kampanjpaket" eller annan "promo" i licensnamnet, plus "komplementär" i "förvärvsmetoden" fält. Ibland kan det vara knepigare, till exempel om gratispaketet fanns i något paket och har ett annat namn. Om du har hittat två liknande licenser - då är det verkligen frågan som beskrivs här, och du kan säkert ta bort fri licens utan att förlora spelet.

För att ta bort gratis licens från ditt konto, besök **[Steam-supportsidan](https://help.steampowered.com/wizard/HelpWithGame)** och lägg det påverkade spelnamnet i sökfältet, spelet ska vara tillgängligt i avsnittet "produkter", klicka på det. Alternativt kan du bara använda `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` länk och ersätta `<appID>` med appID för spelet som orsakar problem. Därefter klickar du på "Jag vill permanent ta bort detta spel från mitt konto" och väljer sedan den felaktiga gratislicens som du har hittat ovan, Vanligtvis den med "begränsat gratis kampanjpaket" i namnet (eller liknande). Efter avlägsnande av den fria licensen, ASF bör kunna släppa kort från det drabbade spelet utan problem, du bör starta om jordbruksverksamheten efter borttagningen bara för att vara säker på att Steam plockar upp rätt licens denna gång.

---

### ASF upptäcker inte spelet `X` som tillgängligt för jordbruk, men jag vet att det innehåller Steam-handelskort!

Det finns två huvudsakliga skäl här. Första och mest uppenbara anledningen är det faktum att du hänvisar till **Steam-butik** där givet spel tillkännages som kort droppar aktiverat spel. Detta är **fel** antagande, eftersom det helt enkelt anger att spelet **har** kort droppar ingår, men inte nödvändigtvis denna funktion för det spelet är **aktiverat** direkt. Du kan läsa mer om detta i **[officiella tillkännagivandet](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**.

Kort sagt, kort droppar ikon i Steam-butiken betyder inte något, kontrollera dina **[märkessidor](https://steamcommunity.com/my/badges)** för bekräftelse om ett spel har kortdroppar aktiverade eller inte - detta är också vad ASF gör. Om ditt spel inte visas på listan som ett spel med kort möjligt att släppa, då detta spel är **inte** möjligt att odla, oavsett anledning.

Den andra frågan är mindre uppenbar, och det är situationen när du kan se att ditt spel verkligen finns med kort droppar på din badge sida, men det är inte odlas av ASF direkt. Om du inte slår någon annan bugg, såsom ASF inte kan kontrollera märkessidor (beskrivs nedan), Det är helt enkelt en cache-effekt och på ASF-sidan rapporterar Steam fortfarande om föråldrade badges sida. Detta problem bör lösa sig själv förr eller senare, när cachen blir ogiltig. Det finns inte heller något sätt att fixa detta på vår sida.

Naturligtvis, allt detta förutsätter att du kör ASF med standard orörda inställningar, eftersom du också kan lägga till detta spel till jordbruk svartlista, använd valda `FarmingPreferences` som `FarmPriorityQueueOnly` eller `SkipRefundableGames`och så vidare.

---

### Varför ökar inte speltiden för spel som odlas via ASF?

Det gör det, men **inte i realtid**. Steam registrerar din speltid i fasta intervall och scheman uppdatering för det, men du är inte garanterad att få det uppdaterat omedelbart det ögonblick du avslutar sessionen, än mindre under sådan. Bara för att speltiden inte uppdateras i realtid betyder det inte att den inte spelas in, den uppdateras vanligtvis var 30:e minut eller så.

---

### Vad är skillnaden mellan en varning och ett fel i loggen?

ASF skriver till sin logg en massa information på olika loggningsnivåer. Vårt mål är att förklara **exakt** vad ASF gör, inklusive vilka Steam-problem det har att ta itu med, eller andra problem att övervinna. För det mesta är inte allt relevant, Det är anledningen till att vi har två stora nivåer i ASF när det gäller problem - en varningsnivå och en felnivå.

Allmän ASF-regel är att varningar är **inte** fel, därför bör de **inte** rapporteras. En varning är en indikator för dig att något potentiellt oönskade hända. Oavsett om Steam inte reagerade, API kasta fel eller din nätverksanslutning är ner - det är en varning, och det innebär att vi förväntade oss att det skulle hända, så bry dig inte ASF utveckling med det. Naturligtvis är du fri att fråga om dem eller få hjälp genom att använda vårt stöd, men du bör inte anta att de är ASF fel värt att rapportera (om vi inte bekräftar annars).

Fel tyder å andra sidan på en situation som inte bör hända, Därför är de värda att rapportera så länge du såg till att det inte är du som orsakar dem. Om det är en vanlig situation som vi förväntar oss att hända, då kommer det att omvandlas till en varning istället. Annars är det kanske ett fel som bör rättas till, inte tyst ignoreras, förutsatt att det inte är ett resultat av ditt eget tekniska problem. Till exempel, sätta ogiltigt innehåll i `ASF. filen son` kommer att kasta ett fel, eftersom ASF inte kommer att kunna tolka det, men det var du som satte den där, så bör du inte rapportera detta fel till oss (om du inte bekräftat att ASF är fel och din struktur är faktiskt helt korrekt).

I en TL; DR mening - rapportera fel, rapportera inte varningar. Du kan fortfarande fråga om varningar och få hjälp i våra supportsektioner.

---

### ASF startar inte, programfönstret stängs omedelbart!

Under normala förhållanden kommer en ASF-krasch eller exit generera en `logg. xt` i programmets katalog för dig att visa, som kan användas för att hitta orsaken till det. Dessutom arkiveras även några sista loggfiler i `loggar` -katalogen, eftersom huvudarkivet `loggar. xt` -filen skrivs över med varje ASF-körning.

Men om inte ens .NET runtime kan starta upp på din maskin, då kommer `log.txt` inte att genereras. Om det händer dig så glömde du sannolikt att installera .NET förutsättningar, som anges i **[inrätta](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)** guide. Andra vanliga problem är att försöka starta fel ASF variant för ditt operativsystem, eller på annat sätt saknas infödda .NET runtime beroenden. Om konsolfönstret stängs för tidigt för att du ska kunna läsa meddelandet, öppna sedan oberoende konsol och starta ASF binary därifrån. Till exempel på Windows, öppna ASF katalog, håll `Shift`, högerklicka i mappen och välj "*öppna kommandofönstret här*" (eller *powershell*), skriv sedan in i konsolen `. ArchiSteamFarm.exe` och bekräfta med enter. På så sätt får du ett exakt meddelande varför ASF inte startar ordentligt.

Om det inte finns någon utgång, och du är i Windows, den vanliga orsaken till detta är inte att ha alla tillgängliga Windows-uppdateringar installerade - se till att du använder uppdaterat OS, eftersom vi inte stöder att köra ASF på Windows utan att uppfylla det villkoret i alla fall.

---

### ASF sparkar min Steam-klientsession medan jag spelar! / *Detta konto är inloggad på en annan PC*

Detta visas som ett meddelande i Steam-overlay att kontot används någon annanstans medan du spelar. Denna fråga kan ha två olika orsaker.

En anledning orsakas av trasiga paket (spel) som specifikt inte håller ett uppspelningslås ordentligt, men förvänta dig att låset ska besitta av kunden. Ett exempel på ett sådant paket skulle vara Skyrim SE. Din Steam-klient startar spelet ordentligt, men det spelet registrerar sig inte som används. På grund av det, ASF ser att det är fritt att återuppta processen, som den gör, och det sparkar ut dig från Steam-nätverket, eftersom Steam plötsligt upptäcker att kontot används på ett annat ställe.

Andra anledningen kan komma upp om du spelar på datorn medan ASF väntar (särskilt på en annan maskin) och du förlorar din nätverksanslutning. I det här fallet markerar Steam-nätverket dig som offline och släpper uppspelningslås (som ovan), vilket utlöser ASF (t.ex. på en annan maskin) till att återuppta jordbruket. När din dator kommer tillbaka online kan Steam inte skaffa uppspelningslås längre (det hålls nu av ASF, liknar också ovan) och visar samma budskap.

Båda orsakerna på ASF sidan är faktiskt mycket svårt att arbeta, som ASF helt enkelt återupptar jordbruk när Steam-nätverket informerar det att kontot är gratis att användas igen. Detta är vad som händer normalt när du stänger spelet, men med trasiga paket kan detta ske omedelbart, även om ditt spel fortfarande är igång. ASF har inget sätt att veta om du blev frånkopplad, slutade spela ett spel eller att du fortfarande spelar ett spel som inte håller spela lås på lämpligt sätt.

Den enda riktiga lösningen på detta problem är att manuellt pausa din bot med `pausa` innan du börjar spela, och återuppta det med `återuppta` när du är klar. Alternativt kan du bara ignorera problemet och agera som om du spelade med Steam-klienten offline.

---

### `Frånkopplad från Steam!` - Jag kan inte upprätta anslutning till Steam-servrar.

ASF kan endast **prova** för att upprätta anslutning till Steam-servrar, och det kan misslyckas på grund av många skäl, inklusive brist på internetanslutning, Steam är nere, din brandväggsblockeringsanslutning, tredjepartsverktyg, felaktigt konfigurerade rutter eller tillfälliga fel. Du kan aktivera `Debug` -läge för att kolla in mer verbose logg som anger exakta felorsaker, men oftast är det helt enkelt orsakas av dina egna handlingar, såsom att använda "CS:GO MM Server Picker" som svartlistar en hel del Steam-IP-adresser, vilket gör det mycket svårt för dig att faktiskt nå Steam-nätverket.

ASF kommer att göra sitt bästa för att upprätta anslutning, vilket inkluderar att inte bara fråga om uppdaterad lista över servrar utan även prova en annan IP när senaste misslyckas så om det verkligen är ett tillfälligt problem med någon specifik server eller rutt, ASF kommer att ansluta förr eller senare. Men om du är bakom brandväggen eller på annat sätt inte kan nå Steam-servrar, då måste du självklart fixa det själv, med potentiell hjälp av `Debug` -läge.

Det är också möjligt att din maskin inte kan upprätta anslutning till Steam-servrar med standardprotokoll i ASF. Du kan ändra protokoll som ASF är tillåtet att använda genom att ändra `SteamProtocols` globala konfigurationsegenskaper. Till exempel, om du har problem med att nå Steam med `UDP` protokoll (t.ex. På grund av brandväggar), kanske du har mer tur med `TCP` eller `WebSocket`.

I en mycket osannolik situation av att felaktiga servrar cachas, till exempel på grund av att flytta ASF `config` mapp från en maskin till en annan maskin som finns i helt andra länder, tar bort `ASF. b` för att uppdatera Steam-servrar vid nästa uppstart kan hjälpa. Mycket ofta behövs det inte och behöver inte göras, eftersom den listan uppdateras automatiskt vid första lanseringen, såväl som när anslutningen är etablerad - vi bara nämna det som ett sätt att rensa allt som är relaterat till listan över Steam-servrar som cachas av ASF.

---

### `Kunde inte logga in på Steam: TryAnotherCM/Ogiltig`, `ServiceUnavailable/Ogiltig`

Som enligt ovan, men den här gången servern du har anslutit dig till är uttryckligen inte tillgänglig. Vanligtvis händer under Steam underhållsfönster, det finns inget du kan göra åt detta, ASF kommer automatiskt att försöka igen med en annan server tills man råkar acceptera dess begäran. Den får inte vara längre än en timmes maximum.

---

### `Kunde inte hämta information om märken, kommer försöka igen senare!`

Vanligtvis innebär det att du använder Steam föräldra-pinkod för att komma åt ditt konto, men du glömde att sätta det i ASF-konfigurationen. Du måste sätta giltig PIN-kod i `SteamParentalCode` bot config egendom, annars kommer ASF inte att kunna få tillgång till det mesta av webbinnehållet, därför kommer inte att kunna fungera korrekt. Gå över till **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** för att lära dig mer om `SteamParentalCode`.

Andra skäl inkluderar tillfälliga Steam-problem, nätverksproblem eller likaså. Om problemet inte löser sig själv efter flera timmar och du är säker på att du konfigurerade ASF på lämpligt sätt, tveka inte att meddela oss om det.

---

### ASF misslyckades med `begäran efter att 5 försök` fel!

Vanligtvis innebär det att du använder Steam föräldra-pinkod för att komma åt ditt konto, men du glömde att sätta det i ASF-konfigurationen. Du måste sätta giltig PIN-kod i `SteamParentalCode` bot config egendom, annars kommer ASF inte att kunna få tillgång till det mesta av webbinnehållet, därför kommer inte att kunna fungera korrekt. Gå över till **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** för att lära dig mer om `SteamParentalCode`.

Om föräldrarnas PIN-kod inte är orsaken, då är detta ett vanligast fel, och du bör vänja dig vid det, Det betyder helt enkelt att ASF skickade en begäran till Steam Network, och fick inte ett giltigt svar, 5 gånger i rad. Vanligtvis innebär det att Steam antingen är nere eller har vissa svårigheter eller underhåll - ASF är medveten om sådana problem och du bör inte oroa dig för dem, såvida de inte ständigt händer längre än flera timmar, och andra användare inte har sådana problem.

Hur kontrollerar man om Steam är ner? **[Steam Status](https://steamstat.us)** är en utmärkt källa för att kontrollera om Steam **ska vara** upp, Om du upptäcker fel, särskilt relaterade till Community eller Web API, då Steam har problem. Du kanske vill lämna ASF ensam och låta det göra sitt jobb efter en kort stund av stillestånd, eller avsluta och vänta själv.

Det är dock inte alltid fallet, som i vissa situationer Steam-problem kanske inte upptäcks av Steam-status, till exempel hände när Valve bröt HTTPS-stöd för Steam-gemenskapen 7 juni 2016 - åtkomst till **[SteamCommunity](https://steamcommunity.com)** genom HTTPS kastade ett fel. Därför ska du inte blint lita på Steam Status heller, det är bäst att kontrollera dig själv om allt fungerar som det ska.

Utöver det inkluderar Steam olika hastighetsbegränsande åtgärder som tillfälligt kommer att förbjuda din IP om du gör alltför många förfrågningar på en gång. ASF är medveten om detta och erbjuder dig flera olika begränsare i konfigurationen, som du bör använda dig av. Standardinställningarna var tweaked baserat på **sane** mängd botar, om du använder så mycket att till och med Steam säger till dig att gå bort, då du antingen justera dem tills det inte längre säger till dig, eller du gör som du blir tillsagd. Jag antar att andra sättet inte är ett alternativ för dig, så läs om detta ämne och var särskilt uppmärksam på `WebLimiterDelay` som är en generell begränsare som gäller för alla webbförfrågningar.

Det finns ingen "gyllene regel" som fungerar för alla, eftersom block är starkt påverkade av faktorer från tredje part, Det är därför du måste experimentera själv och hitta ett värde som fungerar för dig. Du kan också ignorera vad jag säger och använda något som `10000` som garanterat fungerar korrekt, men klaga då inte på hur din ASF reagerar på allt på 10 sekunder och hur märkestolkning tar 5 minuter. Förutom det, Det är helt möjligt att ingen begränsare kommer att göra något eftersom du har så stora mängder robotar att du träffar **[hård gräns](#how-many-bots-can-i-run-with-asf)** som nämndes ovan. Ja, det är helt möjligt att du kan logga in utan problem i Steam-nätverket (klient), men Steam web (webbplats) kommer att vägra att lyssna på dig om du har 100 sessioner etablerade på en gång. ASF kräver att både Steam-nätverket och Steam-webben är samarbetsvilliga, det tar bara en ner för att få dig att problem du inte kommer att återhämta dig från.

Om ingenting hjälper och du har ingen aning om vad som är brutet, du kan alltid aktivera `Debug` -läge och se dig själv i ASF-loggen varför exakt förfrågningar misslyckas. Till exempel:

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Förbjudna <- HEAD https://steamcommunity.com/my/edit/settings
```

Se den `förbjudna` -koden? Detta innebär att du tillfälligt har förbjudits för överdriven mängd förfrågningar, eftersom du inte tweak `WebLimiterDelay` korrekt ännu (förutsatt att du får samma felkod för alla andra förfrågningar också). Det kan finnas andra skäl listade där, såsom `InternalServerError`, `ServiceUnavailable` och timeouts som indikerar Steam-underhåll/problem. Du kan alltid försöka besöka länken som nämns av ASF själv och kontrollera om det fungerar - om det inte gör det, då vet du varför ASF inte kan komma åt det heller. Om det gör det, och samma fel försvinner inte efter en dag eller två, kan det vara värt att undersöka och rapportera.

Innan du gör det bör du **se till att felet är värt att rapportera i första hand**. Om det nämns i denna FAQ, såsom handelsrelaterade frågor, då är det ute. Om det är tillfälliga problem som hände en eller två gånger, särskilt när ditt nätverk var instabilt eller Steam var nere - det är det inte. Men om du kunde reproducera ditt problem flera gånger i rad, över 2 dagar, startade om ASF samt din maskin i processen och såg till att det inte finns någon FAQ post här för att hjälpa till att lösa det, då kan detta vara värt att fråga om.

---

### ASF verkar frysa och skriver inte ut något på konsolen förrän jag trycker på en knapp!

Du använder troligen Windows och din konsol har QuickEdit-läge aktiverat. Se **[denna](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** fråga på StackOverflow för teknisk förklaring. Du bör inaktivera QuickEdit-läge genom att högerklicka på ditt ASF-konsolfönster, öppna egenskaper och avmarkera lämplig kryssruta.

---

### ASF kan inte acceptera eller skicka affärer!

Tydliga saker först - nya konton börjar som begränsade. Tills du låser upp kontot genom att ladda sin plånbok eller spendera $5 i butiken, kan ASF inte acceptera att varken skicka affärer med detta konto. I detta fall, ASF kommer att uppge att inventering verkar tom, eftersom varje kort som finns i det är icke-handelsbar.

Nästa, om du inte använder **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, Det är möjligt att ASF faktiskt accepterade/skickade handel, men du måste bekräfta det via din e-post. Likaså, om du använder klassiska 2FA, måste du bekräfta bytet via din autentiserare. Bekräftelser är **obligatoriska** nu, så om du inte vill acceptera dem själv, överväg att importera din autentiserare till ASF 2FA.

Notera också att du bara kan handla med dina vänner och personer med känd handelslänk. Om du försöker initiera *Bot -> Master* handel, såsom `loot`, då måste du antingen ha din bot på din vänlista eller din `SteamTradeToken` deklarerad i Bots konfiguration. Se till att token är giltig - annars kommer du inte att kunna skicka en handel.

Slutligen, kom ihåg att nya enheter har 7-dagars handelslås, så om du bara har lagt till ditt konto till ASF, vänta minst 7 dagar - allt ska fungera efter den perioden. Den begränsningen inkluderar att **både** accepterar **och** skicka byten. Det utlöser inte alltid och det finns människor som kan skicka och acceptera handel omedelbart. Majoriteten av människorna påverkas dock, och låset **kommer** hända, även om du kan skicka och acceptera affärer genom din ångklient på samma maskin. Vänta tålmodigt, det finns inget du kan göra för att göra det snabbare. Likaså kan du få liknande lås för att ta bort/ändra olika Steam säkerhetsrelaterade inställningar, såsom 2FA, SteamGuard, lösenord, e-post och likaså. I allmänhet kontrollera om du kan skicka en handel från det kontot själv, om ja, mycket troligt är det klassiska 7-dagars lås från ny enhet.

Och slutligen, tänk på att ett konto kan ha bara 5 pågående affärer till en annan, så ASF kommer inte att skicka affärer om du har 5 (eller fler) väntande sådana från den där botten att acceptera redan. Detta är sällan ett problem, men det är också värt att nämna, särskilt om du ställer ASF till auto-send affärer, ännu du inte använder ASF 2FA och glömde att faktiskt bekräfta dem.

Om inget hjälpte, kan du alltid aktivera `Debug` läge och kontrollera själv varför förfrågningar misslyckas. Observera att Steam pratar nonsens för det mesta, och förutsatt att skäl kanske inte gör någon logisk mening. eller kan till och med vara helt felaktigt - om du bestämmer dig för att tolka den anledningen, se till att du har anständig kunskap om Steam och dess egenheter. Det är också ganska vanligt att se den frågan utan logisk anledning, och den enda föreslagna lösningen i detta fall är att åter lägga till konto till ASF (och vänta 7 dagar igen). Ibland fixar detta problem också sig själv *magiskt*, på samma sätt som det går sönder. Men oftast är det bara antingen 7-dagars handelslås, tillfälliga ångproblem, eller båda. Det är bäst att ge det några dagar innan manuellt kontrollera vad som är fel, om du inte har lite lust att felsöka den verkliga orsaken (och oftast kommer du att tvingas vänta ändå, eftersom felmeddelandet inte kommer att vara meningsfullt, inte heller hjälpa dig på det minsta).

I vilket fall som helst kan ASF endast **försöka** skicka en korrekt begäran till Steam för att acceptera/skicka byte. Oavsett om Steam accepterar den begäran, eller inte, är utanför omfattningen av ASF, och ASF kommer inte magiskt få det att fungera. Det finns ingen bugg relaterad till den funktionen, och det finns också ingenting att förbättra, eftersom logik händer utanför ASF. Därför be inte om fastställande av saker som inte är trasiga, och fråga inte heller varför ASF inte kan acceptera eller skicka affärer - **Jag vet inte, och ASF vet inte heller**. Antingen ta itu med det, eller fixa dig själv, om du vet bättre.

---

### Varför måste jag sätta 2FA/SteamGuard-koden på varje inloggning? / *Borttagen utgången inloggningsnyckel*

ASF använder inloggningsnycklar (om du behöll `UseLoginKeys` aktiverat) för att hålla inloggningsuppgifter giltiga, samma mekanism som Steam använder - 2FA/SteamGuard-token krävs endast en gång. Men på grund av Steams nätverksproblem och förfrågningar är det helt möjligt att inloggningsnyckeln inte sparas i nätverket, Vi har redan sett sådana problem inte bara med ASF, men med vanlig ångklient samt (ett behov av att mata in inloggning + lösenord på varje körning, oavsett "kom ihåg mig" alternativ).

Du kunde ta bort `BotName.db` och `BotName. i` (om tillgängligt) på påverkat konto och försök att länka ASF till ditt konto igen, men det kommer sannolikt inte att göra något. Vissa användare har rapporterat att **[avauktoriserar alla enheter](https://store.steampowered.com/twofactor/manage)** på Steam-sidan bör hjälpa, att byta lösenord kommer att göra detsamma. Men det är bara lösningar som inte ens garanteras att arbeta, den verkliga ASF-baserade lösningen är att importera din autentiserare som **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** - detta sätt ASF kan generera tokens automatiskt när de behövs, och du behöver inte mata in dem manuellt. Vanligtvis löser sig frågan magiskt efter en tid, så du kan helt enkelt vänta på att det ska ske. Naturligtvis kan du också be Valve om lösning, eftersom jag inte kan tvinga Steam-nätverket att acceptera våra inloggningsnycklar.

Som en sidoanteckning, du kan också stänga av inloggningsnycklar med `UseLoginKeys` config egenskap satt till `false`, men detta kommer inte att lösa problemet, bara hoppa över den ursprungliga inloggningsnyckeln misslyckande. ASF är redan medveten om problemet förklaras här och kommer att göra sitt bästa för att inte använda inloggningsnycklar om det kan garantera sig själv alla inloggningsuppgifter så det finns ingen anledning att justera `UseLoginKeys` manuellt om du kan ange alla inloggningsuppgifter tillsammans med ASF 2FA.

---

### Jag får fel: *Kan inte logga in på Steam: `OgiltigLösenord` eller `RateLimitExceeded`*

Detta fel kan betyda en hel del saker, några av dem inkluderar:

- Ogiltig kombination av inloggning/lösenord (självklart)
- Förfallen inloggningsnyckel som används av ASF för inloggning
- Alltför många misslyckade inloggningsförsök på kort tid (anti-bruteforce)
- För många inloggningsförsök på kort tid (hastighetsbegränsande)
- Krav på captcha för att logga in (mycket sannolikt orsakas av två skäl ovan)
- Alla andra anledningar som Steam-nätverket kan ha hindrar dig från att logga in

Vid anti-bruteforce och hastighetsbegränsande kommer problemet att försvinna efter en tid, så vänta och försök inte att logga in under tiden. Om du träffar på det problemet ofta, kanske det är klokt att öka `LoginLimiterDelay` config egenskap ASF. Överdriven programstart och andra avsiktliga/icke-avsiktliga inloggningsförfrågningar hjälper definitivt inte till med det problemet, så försök att undvika det om möjligt.

Vid utgångna inloggningsnyckel - ASF kommer att ta bort gamla och be om en ny på nästa inloggning (som kommer att kräva av dig att sätta 2FA token om ditt konto är 2FA-skyddat. Om ditt konto använder ASF 2FA kommer token att genereras och användas automatiskt). Detta kan naturligtvis hända med tiden, men om du får detta problem vid varje inloggning, Det är möjligt att Steam av någon anledning beslutat att ignorera vår inloggningsnyckel spara förfrågningar, som nämns i numret **[ovanför](#why-do-i-have-to-put-2fasteamguard-code-on-each-login--removed-expired-login-key)**. Du kan naturligtvis inaktivera `UseLoginKeys` helt, men det löser inte problemet, bara undvika ett behov av att ta bort utgångna inloggningsnycklar varje gång. Den verkliga lösningen, enligt ovan, är att använda ASF 2FA.

Och slutligen, om du använde fel inloggning + lösenord kombination, måste du naturligtvis rätta till detta, eller inaktivera bot som försöker ansluta med hjälp av dessa uppgifter. ASF kan inte gissa på egen hand om `InvalidPassword` betyder ogiltiga autentiseringsuppgifter, eller någon av anledningarna som anges ovan, därför kommer det att fortsätta att försöka tills det lyckas.

Tänk på att ASF har ett eget inbyggt system för att reagera i enlighet med ångpåfrestningar, så småningom kommer det att ansluta och återuppta sitt jobb, därför är det inte nödvändigt att göra något om problemet är tillfälligt. Starta om ASF för att magiskt fixa problem kommer bara att göra saker värre (som nya ASF inte vet tidigare ASF tillstånd att inte kunna logga in, och försök att ansluta istället för att vänta), så undvik att göra det om du inte vet vad du gör.

Slutligen, som vid varje Steam-begäran - ASF kan endast **prova** för att logga in, med hjälp av dina angivna uppgifter. Huruvida denna begäran kommer att lyckas eller inte är utanför ASF:s räckvidd och logik - det finns inga fel, och ingenting kan rättas till eller förbättras i detta avseende.

---

### Jag kan inte ange inloggningsuppgifter som ASF ber om
### `System.InvalidOperationException: Kan inte läsa nycklar när antingen programmet inte har en konsol eller när konsolinmatningen har omdirigerats`
### `System.IO.IOException: Input/output error`
### `RequestInput() inmatningen är ogiltig!`

Om detta fel inträffade under ASF-inmatning (t.ex. du kan se `GetUserInput()` i stacktracet) då det orsakas av din miljö som förbjuder ASF att läsa standardindata på din konsol. Det kan uppstå på grund av många orsaker, men den vanligaste är att du kör ASF i fel miljö (t.ex. i `systemd`, `nohup` eller `&` bakgrund istället för e. . `skärm` på Linux). Om ASF inte kan komma åt sin standardingång ser du detta fel loggat och ASF:s oförmåga att använda dina uppgifter under körtid.

Normalt bör du rätta till ovanstående problem, dvs tillåta ASF att komma åt standardinmatning så att du kan tillhandahålla detaljerna. Men om du **förväntar** detta kommer att hända, så du **har för avsikt** att köra ASF i input-less miljö, då bör du uttryckligen säga till ASF att det är fallet, genom att ställa in **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** -läge på lämpligt sätt. Detta kommer att tala om för ASF att aldrig be om användarindata under några omständigheter, så att du kan köra ASF i inmatningslösa miljöer på ett säkert sätt. Du kan svara på valda inmatningsmeddelanden på andra sätt i det här läget, t.ex. i ASF-ui.

---

### `System.Net.Http.WinHttpUndantag: Ett säkerhetsfel inträffade`

Detta fel inträffar när ASF inte kan upprätta säker anslutning med given server, nästan uteslutande på grund av SSL-certifikatets misstro.

I nästan alla fall orsakas detta fel av **fel datum/tid på din maskin**. Varje SSL-certifikat har utfärdat datum och utgångsdatum. Om ditt datum är ogiltigt och utanför dessa två gränser kan certifikatet inte lita på grund av en potentiell **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)** attack och ASF vägrar att göra en anslutning.

Tydlig lösning är att ställa in datumet på din maskin på lämpligt sätt. Det rekommenderas starkt att använda automatisk datumsynkronisering, såsom inbyggd synkronisering tillgänglig på Windows, eller `ntpd` på Linux.

Om du såg till att datumet på din maskin är lämpligt och felet inte vill försvinna, SSL-certifikat som ditt system litar på kan vara inaktuella eller ogiltiga. I detta fall bör du se till att din maskin kan upprätta säkra anslutningar, till exempel genom att kontrollera om du kan komma åt `https://github. Om` med valfri webbläsare, eller CLI-verktyg som `curl`. Om du bekräftat att detta fungerar korrekt, tveka inte att be oss om stöd.

---

### `System.Threading.Tasks.TaskCanceledException: En uppgift avbröts`

Denna varning innebär att Steam inte besvarade ASF-begäran i angiven tid. Vanligtvis orsakas det av Steam-nätverk hicka och påverkar inte ASF på något sätt. I andra fall är det samma sak som begäran misslyckas efter 5 försök. Att rapportera detta problem gör ingen mening för det mesta, eftersom vi inte kan tvinga Steam att svara på våra förfrågningar.

---

### `Typen initialiserare för 'System.Security.Cryptography.CngKeyLite' kastade ett undantag`

Detta problem orsakas nästan uteslutande av inaktiverade/stoppade `CNG Key Isolation` Windows-tjänst, vilket ger grundläggande kryptografi funktionalitet för ASF, utan vilket programmet inte kan köras. Du kan åtgärda detta problem genom att lansera `tjänster. sc` och se till att `CNG Key Isolation` Windows-tjänsten inte har inaktiverat start och körs för närvarande.

---

### ASF upptäcks som en skadlig kod av mitt AntiVirus! Vad pågår?

**Se till att du laddade ner ASF från betrodd källa**. Den enda officiella och betrodda källan är **[ASF släpper](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** sidan på GitHub (och detta är också källan för ASF auto-uppdateringar) - **någon annan källa är inte betrodd per definition och kan innehålla skadlig kod som lagts till av andra personer** - du bör inte lita på någon annan nedladdningsplats, se till att din ASF alltid kommer från oss.

Om du bekräftat att ASF hämtas från betrodd källa, då mycket troligt att det är helt enkelt en falsk positiv. Detta **hände i det förflutna**, **händer just nu**, och **kommer att hända i framtiden**. Om du är orolig för faktisk säkerhet när du använder ASF, då föreslår jag att du skannar ASF med många olika AVs för faktisk detektion förhållande, till exempel genom **[VirusTotal](https://www.virustotal.com)** (eller någon annan webbtjänst av ditt val såhär).

Om den AV som du använder falskeligen upptäcker ASF som en skadlig kod, sedan **det är en bra idé att skicka tillbaka detta filprov till utvecklare av din AV, så att de kan analysera det och förbättra sin detektionsmotor**, så klart att det inte fungerar så bra som du tror att det gör. Det finns inga problem med ASF-kod, och det finns inte heller något att fixa för oss, eftersom vi inte distribuerar skadlig kod i första hand, Därför är det ingen mening med att rapportera dessa falska positiva till oss. Vi rekommenderar starkt att skicka ASF prov för vidare analys som anges ovan, men om du inte vill besvära med det, då kan du alltid lägga till ASF till någon form av AV-undantag, inaktivera din AV eller helt enkelt använda en annan. Tråkigt nog, vi är vana vid att AVs är dumma, som varje gång på ett tag vissa AV upptäcker ASF som ett virus, som vanligtvis varar mycket kort och lappas upp snabbt av devs, men som vi påpekade ovan - **hände det**, **händer** och **kommer att hända** hela tiden. ASF innehåller inte någon skadlig kod, du kan granska ASF-kod och även kompilera från källan själv. Vi är inte hackare att fördunkla ASF-kod för att dölja från AV-heuristik och falska positiva, så förvänta dig inte från oss att fixa det som inte är trasigt - det finns inget "virus" för oss att fixa.