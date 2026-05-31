# Konfiguration

Denna sida är dedikerad för ASF-konfiguration. Den fungerar som en komplett dokumentation av `config` -katalogen, så att du kan ställa in ASF efter dina behov.

* **[Introduktion](#introduction)**
* **[Webbaserad konfigureringsgenerator](#web-based-configgenerator)**
* **[ASF-ui konfiguration](#asf-ui-configuration)**
* **[Manuell konfiguration](#manual-configuration)**
* **[Global konfiguration](#global-config)**
* **[Bot config](#bot-config)**
* **[Fil struktur](#file-structure)**
* **[JSON mappning](#json-mapping)**
* **[Kompatibilitetsmappning](#compatibility-mapping)**
* **[Kompatibilitet för konfigurering](#configs-compatibility)**
* **[Automatisk omladdning](#auto-reload)**

---

## Introduktion

ASF konfiguration är uppdelad i två huvuddelar - global (process) konfiguration och konfiguration av varje bot. Varje bot har sin egen bot konfigurationsfil som heter `BotName. son` (där `BotName` är namnet på boten), medan global ASF (process) konfiguration är en enda fil som heter `ASF. son`.

En bot är ett enda steam konto som deltar i ASF-processen. För att fungera korrekt behöver ASF minst **en** definierad bot instans. Det finns ingen process-framtvingad gräns för bot instanser, så du kan använda så många robotar (ångkonton) som du vill.

ASF använder **[JSON](https://en.wikipedia.org/wiki/JSON)** -format för att lagra dess konfigurationsfiler. Det är människovänligt, läsbart och mycket universellt format där du kan konfigurera programmet. Oroa dig inte, du behöver inte veta JSON för att konfigurera ASF. Jag nämnde det bara om du redan vill mass-skapa ASF konfigurerar med någon form av bash skript.

Konfiguration kan göras på flera sätt. Du kan använda vår **[webbaserade ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)**, som är en lokal app oberoende av ASF. Du kan använda vårt **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC-skal för konfiguration som gjorts direkt i ASF. Slutligen kan du alltid generera konfigurationsfiler manuellt, eftersom de följer fast JSON-struktur som anges nedan. Vi förklarar inom kort de tillgängliga alternativen.

---

## Webbaserad konfigureringsgenerator

Syftet med vår **[webbaserade ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** är att förse dig med ett vänligt skal som används för att generera ASF-konfigurationsfiler. Webbaserad ConfigGenerator är 100% klientbaserad, vilket innebär att de uppgifter du matar in inte skickas någonstans, men behandlas lokalt endast. Detta garanterar säkerhet och tillförlitlighet, eftersom det även kan fungera **[offline](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** om du vill ladda ner alla filer och köra `index. tml` i din favoritwebbläsare.

Webbaserad ConfigGenerator är verifierad för att köras ordentligt på Chrome och Firefox, men det bör fungera korrekt i alla mest populära javascript-aktiverade webbläsare.

Användningen är ganska enkel - välj om du vill generera `ASF` eller `Bot` konfiguration genom att byta till rätt flik, se till att den valda versionen av konfigurationsfilen matchar din ASF-utgåva och mata in alla detaljer och tryck på knappen "download". Flytta denna fil till ASF `config` katalog, skriva över befintliga filer om det behövs. Upprepa för alla eventuella ytterligare ändringar och se resten av detta avsnitt för förklaring av alla tillgängliga alternativ att konfigurera.

---

## ASF-ui konfiguration

Vårt **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC-gränssnitt låter dig konfigurera ASF också, och är överlägsen lösning för att konfigurera om ASF efter att ha genererat de initiala konfigurationerna på grund av det faktum att den kan redigera konfigurationerna på plats, i motsats till Web-baserade ConfigGenerator som genererar dem statiskt.

För att använda ASF-ui måste du ha vårt **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** -gränssnitt aktiverat. `IPC` är aktiverat som standard, därför kan du komma åt det direkt, så länge du inte själv har inaktiverat det.

Efter lanseringen av programmet, helt enkelt navigera till ASFs **[IPC-adress](http://localhost:1242)**. Om allt fungerade som det ska, kan du ändra ASF konfigurationen därifrån.

---

## Manuell konfiguration

Generellt rekommenderar vi starkt att använda antingen vår ConfigGenerator eller ASF-ui, eftersom det är mycket lättare och ser till att du inte gör ett misstag i JSON-strukturen, men om du av någon anledning inte vill, då kan du också skapa korrekta konfigurationer manuellt. Kolla JSON exempel nedan för en bra start i rätt struktur, du kan kopiera innehållet till en fil och använda det som bas för din konfiguration. Eftersom du inte använder någon av våra frontends, se till att din konfiguration är **[giltig](https://jsonlint.com)**, som ASF kommer att vägra att ladda den om den inte kan tolkas. Även om det är en giltig JSON, måste du också se till att alla egenskaper har rätt typ, som krävs av ASF. För korrekt JSON struktur för alla tillgängliga fält, se **[JSON kartläggning](#json-mapping)** avsnitt och vår dokumentation nedan.

---

## Global konfiguration

Global konfiguration finns i filen `ASF.json` och har följande struktur:

```json
{
    "AutoRestart": true,
    "Svartlista": [],
    "CommandPrefix": "! ,
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "CurrentCulture": null,
    "Debug": false,
    "DefaultBot": null,
    "Farmingfördröjning": 15,
    "FilterBadBots": sant,
    "GiftsLimiterDelay": 1,
    "Headless": false,
    "IdleFarmingPeriod": 8,
    "InventoryLimiterDelay": 4,
    "IPC": sant,
    "IPCPassword": noll,
    "IPCPasswordFormat": 0,
    "LicenseID": null,
    "Logga inLimiterfördröjning": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldVaraktighet": 15,
    "MinFarmingFörseningAfterBlock": 60,
    "Optimeringsläge": 0,
    "PluginsUpdateList": [],
    "PluginsUpdateMode": 0,
    "AvstängningIfMöjligt": false,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": noll,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Alla alternativ förklaras nedan:

### `Starta om`

`Bool` typ med standardvärdet `true`. Denna egenskap definierar om ASF tillåts utföra en självomstart när det behövs. Det finns några händelser som kommer att kräva av ASF en självrestart, till exempel ASF-uppdatering (klar med `UpdatePeriod` eller `uppdatera` -kommandot), samt `ASF. son` konfigurationsredigering, `starta om` kommandot och likaså. Vanligtvis inkluderar omstart två delar - skapa ny process och avsluta nuvarande en. De flesta användare bör vara bra med det och hålla den här egenskapen med standardvärdet `true`, dock - om du kör ASF genom ditt eget skript och/eller med `dotnet`, kanske du vill ha full kontroll över att starta processen, och undvika en situation som att ha ny (omstartad) ASF-process körs någonstans tyst i bakgrunden, och inte i förgrunden av manuset, som avslutades tillsammans med gamla ASF-processen. Detta är särskilt viktigt med tanke på att den nya processen inte längre kommer att vara ditt direkta barn, vilket skulle göra att du inte kan det. . för att använda standard konsolingång för den.

Om så är fallet, denna egenskap om speciellt för dig och du kan ställa in den till `false`. Kom dock ihåg att i sådana fall är **du** ansvariga för att starta om processen. Detta är på något sätt viktigt eftersom ASF endast kommer att avsluta i stället för att leka ny process (t.ex. efter uppdatering), så om det inte finns någon logik tillagd av dig, kommer det helt enkelt sluta arbeta tills du startar det igen. ASF slutar alltid med korrekt felkod som indikerar framgång (noll) eller icke-framgång (icke-noll), detta sätt du kan lägga till korrekt logik i ditt skript som bör undvika automatisk omstart ASF vid misslyckande, eller åtminstone göra en lokal kopia av `logg. xt` för vidare analys. Kom också ihåg att kommandot `startar om` alltid startar om ASF oavsett hur denna egenskap är inställd, eftersom den här egenskapen definierar standardbeteende, medan kommandot `startar om` startar alltid om processen. Om du inte har en anledning att inaktivera denna funktion, bör du hålla den aktiverad.

---

### `Svartlista`

`ImmutableHashSet<uint>` -typ med standardvärdet för att vara tomt. Som namnet antyder, denna globala config egenskap definierar appID (spel) som kommer att helt ignoreras av automatisk ASF odlingsprocess. Tyvärr älskar Steam att flagga sommar-/vintersäljmärken som "tillgängliga för kortsläpp", som förvirrar ASF processen genom att göra det tror att det är ett giltigt spel som bör odlas. Om det inte fanns någon form av svartlista, ASF skulle så småningom "hänga" på jordbruk ett spel som i själva verket inte är ett spel, och vänta oändligt på kort släppa som inte kommer att hända. ASF svartlista tjänar ett syfte att markera dessa märken som inte tillgängliga för jordbruk, så att vi i tysthet kan ignorera dem när vi beslutar vad vi ska odla och inte falla i fällan.

ASF innehåller två svarta listor som standard - `SalesBlacklist`, som är hårdkodad i ASF-koden och inte möjligt att redigera, och normal `svartlista`, som definieras här. `SalesBlacklist` uppdateras tillsammans med ASF-versionen och innehåller vanligtvis alla "dåliga" app-ID vid tidpunkten för utgåvan, så om du använder uppdaterad ASF då behöver du inte behålla din egen `svartlista` definierad här. Det huvudsakliga syftet med denna egendom är att låta dig svartlista nya, okända vid tidpunkten för ASF release appIDs, som inte bör odlas. Hardcoded `SalesBlacklist` uppdateras så snabbt som möjligt, Därför behöver du inte uppdatera din egen `svartlista` om du använder senaste ASF-version, men utan `svartlista` skulle du bli tvungen att uppdatera ASF för att "hålla igång" när Valve släpper nytt säljmärke - jag vill inte tvinga dig att använda senaste ASF-kod, därför denna fastighet är här för att tillåta dig "fixa" ASF själv om du av någon anledning inte vill, eller inte kan, uppdatera till ny hårdkodad `försäljningSvartlista` i ny ASF-utgåva, men ändå vill du hålla din gamla ASF igång. Om du inte har en **stark** anledning att redigera denna egenskap, bör du behålla den som standard.

Om du letar efter bot-baserad svartlista istället, ta en titt på `fb`, `fbadd` och `fbrm` **[kommandon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `Kommandoprefix`

`sträng` typ med standardvärdet `!`. Denna egenskap anger **skiftlägeskänsliga** prefix som används för ASF **[kommandon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Med andra ord, detta är vad du behöver för att föregripa varje ASF-kommando för att få ASF att lyssna på dig. Det är möjligt att ställa in detta värde till `null` eller tomt för att få ASF att inte använda något kommandoprefix, i vilket fall du matar in kommandon med deras oformaterade identifierare. Men Detta kommer potentiellt att minska ASF:s prestanda eftersom ASF är optimerad för att inte tolka meddelandet ytterligare om det inte börjar med `CommandPrefix` - om du avsiktligt väljer att inte använda det, ASF kommer att tvingas läsa alla meddelanden och svara på dem, även om de inte är ASF-kommandon. Därför rekommenderas det att fortsätta använda några `CommandPrefix`, till exempel `/` om du inte gillar standardvärdet på `!`. För konsistens påverkar `CommandPrefix` hela ASF-processen. Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

### `BekräftelserBegränsareFördröjning`

`byte` typ med standardvärdet `10`. ASF kommer att se till att det kommer att finnas minst `BekräftelserBegränsningsfördröjning` sekunder mellan två på varandra följande 2FA bekräftelser hämtar förfrågningar för att undvika utlösande hastighetsbegränsning - de används av **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** under e. . `2faok` kommando, liksom på nödvändig grund när du utför olika handelsrelaterade operationer. Standardvärdet sattes baserat på våra tester och bör inte sänkas om du inte vill stöta på problem. Om du inte har en **stark** anledning att redigera denna egenskap, bör du behålla den som standard.

---

### `Anslutningstimme`

`byte` typ med standardvärdet `90`. Denna egenskap definierar tidsgränser för olika nätverksåtgärder gjorda av ASF, på några sekunder. I synnerhet definierar `ConnectionTimeout` timeout på några sekunder för HTTP- och IPC-förfrågningar, `ConnectionTimeout / 10` definierar maximalt antal misslyckade hjärtslag, medan `ConnectionTimeout / 30` definierar antal minuter som vi tillåter för första Steam-nätverksanslutningsbegäran. Standardvärdet för `90` bör vara bra för de flesta människor, men om du har ganska långsam nätverksanslutning eller PC, kanske du vill öka detta tal till något högre (som `120`). Tänk på att större värden inte kommer att magiskt fixa långsam eller ens otillgänglig Steam-servrar, så vi ska inte oändligt vänta på något som inte kommer att hända och helt enkelt försöka igen senare. Att sätta detta värde för högt kommer att resultera i alltför stora förseningar när det gäller att fånga upp nätverksfrågor, samt en minskning av den totala prestandan. Att sätta detta värde för lågt kommer att minska den totala stabiliteten och prestandan också, eftersom ASF kommer att avbryta giltig begäran som fortfarande är tolkad. Därför har detta värde lägre än standard ingen fördel i allmänhet, eftersom Steam-servrar tenderar att vara super långsam från tid till annan, och kan kräva mer tid för att tolka ASF-förfrågningar. Standardvärdet är en balans mellan att tro att vår nätverksanslutning är stabil, och tvivlar i Steam-nätverket för att hantera vår förfrågan i given tid. Om du vill upptäcka problem tidigare och få ASF att återansluta/svara snabbare, standardvärdet bör göra (eller mycket något nedan, som `60`, vilket gör ASF mindre patient). Om du istället märker att ASF stöter på nätverksproblem, såsom misslyckade förfrågningar, hjärtslag förloras eller anslutning till Steam avbryts, Det är förmodligen meningsfullt att öka detta värde om du är säker på att det är **inte** som orsakas av ditt nätverk, men av Steam själv, som ökande timeouts gör ASF mer "patient" och inte beslutar att återansluta direkt.

En exempelsituation som kan kräva en ökning av fastigheten är att hyra ASF för att hantera ett mycket stort handelserbjudande som kan ta bra 2 + minuter att fullt ut accepteras och hanteras av Steam. Genom att öka standard timeout, ASF kommer att ha mer tålamod och vänta längre innan man beslutar att handeln inte går igenom och överger den ursprungliga begäran.

En annan situation kan orsakas av mycket långsam maskin eller internetanslutning som kräver mer tid för att hantera de data som överförs. Detta är ganska sällsynt skick, eftersom CPU/nätverksbandbredd nästan aldrig är en flaskhals, men ändå en möjlighet värd att nämna.

Kort sagt, standardvärdet bör vara anständigt för de flesta fall, men du kanske vill öka det om det behövs. Fortfarande, att gå långt över standardvärdet är inte mycket vettigt heller, eftersom större timeouts inte magiskt fixa otillgängliga Steam-servrar. Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

### `NuvarandeKultur`

`sträng` typ med standardvärdet `null`. Som standard försöker ASF använda ditt operativsystems språk, och kommer att föredra att använda översatta strängar på det språket om det är tillgängligt. Detta är möjligt tack vare vår gemenskap som försöker **[lokalisera](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** ASF på alla mest populära språk. Om du av någon anledning inte vill använda ditt operativsystem modersmål, du kan använda den här konfigurationsegenskapen för att välja vilket giltigt språk du vill använda istället. För en lista över alla tillgängliga kulturer, besök **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** och sök efter `Språktagg`. Det är trevligt att notera att ASF accepterar båda specifika kulturer, såsom `"en-GB"`, men också neutrala sådana, såsom `"en"`. Att ange aktuell kultur kommer också att påverka andra kulturspecifika beteenden, såsom valuta/datumformat och liknande. Observera att du kan behöva ytterligare teckensnitt/språkpaket för att visa språkspecifika tecken korrekt, om du väljer en kultur som inte är infödda och som använder dem. Vanligtvis vill du använda denna config egendom om du föredrar ASF på engelska istället för ditt modersmål.

---

### `Debug`

`Bool` skriv med standardvärdet `false`. Denna egenskap definierar om processen ska köras i felsökningsläge. När i felsökningsläge skapar ASF en speciell `debug` -katalog bredvid `-konfigurationen`, som håller reda på hela kommunikationen mellan ASF och Steam-servrar. Felsökningsinformation kan hjälpa till att upptäcka otäcka problem relaterade till nätverk och allmänt ASF-arbetsflöde. Förutom att vissa program rutiner kommer att vara långt mer verbos, såsom `WebBrowser` ange exakt anledning till varför vissa förfrågningar misslyckas - dessa poster är skrivna till normal ASF-logg. **Du bör inte köra ASF i Debug läge, om inte utvecklaren** frågat . Kör ASF i felsökningsläge **minskar prestanda**, **påverkar stabiliteten negativt** och är **mycket mer verbose på olika platser**, så det bör användas **endast** avsiktligt, på kort sikt, för felsökning av särskilda problem, reproducera problemet eller få mer information om en misslyckad begäran, och lika, men **inte** för normal program utförande. Du kommer att se **mycket** av nya fel, problem, och undantag - se till att du har en anständig kunskap om ASF, Steam och dess egenheter om du bestämmer dig för att analysera allt detta själv, eftersom inte allt är relevant.

**VARNING:** som aktiverar detta läge inkluderar loggning av **potentiellt känslig** information såsom inloggningar och lösenord som du använder för att logga in på Steam (på grund av nätverksloggning). Dessa data skrivs till både `debug` -katalogen, samt standard `-logg. xt` (det är nu avsiktligt mycket mer verbose för att logga denna information). Du bör inte lägga upp felsökningsinnehåll som genereras av ASF på någon offentlig plats, ASF utvecklare bör alltid påminna dig om att skicka den till sin e-post, eller annan säker plats. Vi lagrar inte, varken utnyttjar dessa känsliga detaljer, de är skrivna som en del av debug rutiner eftersom deras närvaro kan vara relevant för problemet som påverkar dig. Vi skulle föredra om du inte ändrade ASF-inloggning på något sätt, men om du är orolig kan du ändra dessa känsliga detaljer på lämpligt sätt.

> Redacting innebär att man ersätter känsliga detaljer, till exempel med stjärnor. Du bör avstå från att ta bort känsliga linjer helt, eftersom deras rena existens kan vara relevant och bör bevaras.

---

### `Standardbot`

`sträng` typ med standardvärdet `null`. I vissa scenarier fungerar ASF med ett koncept av en standardbot som ansvarar för att hantera något - till exempel IPC-kommandon eller interaktiv konsol när du inte anger målrobot. Denna egenskap låter dig välja standard bot som ansvarar för att hantera sådana scenarier, genom att sätta sin `BotName` här. Om given bot inte finns, eller du använder ett standardvärde på `null`, ASF kommer att välja först registrerade bot sorteras alfabetiskt istället. Vanligtvis vill du använda den här konfigurationsegenskapen om du vill utelämna `[Bots]` argument i IPC och interaktiva konsolkommandon, och alltid välja samma bot som standard för sådana samtal.

---

### `JordbruksfördröjningFördröjning`

`byte` typ med standardvärdet `15`. För att ASF ska fungera, det kommer att kontrollera för närvarande odlade spel varje `FarmingDelay` minuter, om det kanske tappade alla kort redan. Att ställa in den här fastigheten för lågt kan resultera i att alltför många ångförfrågningar skickas, medan inställningen är för hög kan resultera i ASF fortfarande "farming" given titel för upp till `FarmingDelay` minuter efter det är fullvuxet. Standardvärdet bör vara utmärkt för de flesta användare, men om du har många robotar igång, du kan överväga att öka den till något som `30` minuter för att begränsa ångbegäran skickas. Det är trevligt att notera att ASF använder händelsebaserad mekanism och kontrollerar spel badge sida på varje Steam-objekt släppt, så i allmänhet **behöver vi inte ens kontrollera det i fasta tidsintervall**, men eftersom vi inte helt litar på Steam-nätverket - vi kontrollerar sidan för spelbrickor ändå, om vi inte kontrollerade det genom att kortet släpptes händelsen under senaste `FarmingDelay` minuter (ifall Steam-nätverket inte informerade oss om objekt som tappats eller sånt där). Förutsatt att Steam-nätverket fungerar korrekt, minskar detta värde **kommer inte att förbättra jordbrukseffektiviteten på något sätt**, medan **ökar nätverksuppkopplingen avsevärt** - det rekommenderas bara att öka den (om det behövs) från `15` minuter som standard. Om du inte har en **stark** anledning att redigera denna egenskap, bör du behålla den som standard.

---

### `FilterBadBots`

`Bool` typ med standardvärdet `true`. Denna egenskap definierar om ASF automatiskt kommer att avböja handelserbjudanden som tas emot från kända och markerade dåliga aktörer. För att göra det kommer ASF att kommunicera med vår server efter behov för att hämta en lista över svartlistade Steam-identifierare. De robotar som anges drivs av personer som klassificeras som skadliga för ASF initiativ av oss, såsom de som bryter mot vår **[uppförandekod](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, använda funktioner och resurser från oss som **[`Publicera`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** för att missbruka och utnyttja andra människor, eller gör direkt brottslig verksamhet som att lansera DDoS-attacker på servern. Eftersom ASF har en stark inställning till allmän rättvisa, ärlighet och samarbete mellan sina användare för att få hela samhället att blomstra, denna egenskap är aktiverad som standard, och därför ASF filtrerar robotar som vi har klassificerat som skadliga från tjänster som erbjuds. Om du inte har en **stark** anledning att redigera denna egenskap, såsom att inte hålla med om vårt uttalande och avsiktligt tillåta dessa robotar att fungera (inklusive utnyttja dina konton), bör du hålla det som standard.

---

### `GiftsLimiterDelay`

`byte` typ med standardvärdet `1`. ASF kommer att se till att det kommer att finnas minst `GiftsLimiterDelay` sekunder i mellan två på varandra följande gåva/nyckel/licenshantering (inlösande) förfrågningar för att undvika att utlösa hastighetsbegränsning. Dessutom kommer det också att användas som global limiter för förfrågningar om spellistor, till exempel den som utfärdats av `äger` **[-kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Om du inte har en **stark** anledning att redigera denna egenskap, bör du behålla den som standard.

---

### `Huvudlös`

`Bool` skriv med standardvärdet `false`. Denna egenskap definierar om processen ska köras i huvudlöst läge. När i huvudlöst läge förutsätter ASF att det körs på en server eller i annan icke-interaktiv miljö, därför kommer det inte att försöka läsa någon information via konsolinmatning. Detta inkluderar information på begäran (kontouppgifter som 2FA-kod, SteamGuard-kod, lösenord eller någon annan variabel som krävs för att ASF ska fungera) samt alla andra konsolingångar (t.ex. interaktiv kommandokonsol). Med andra ord är `Headless` -läge lika med att göra ASF-konsolen skrivskyddad. Denna inställning är användbar främst för användare som kör ASF på sina servrar, som istället för att fråga e. . för 2FA kod, ASF kommer tyst avbryta operationen genom att stoppa ett konto. Om du inte kör ASF på en server, och du tidigare bekräftat att ASF kan fungera i icke-headless läge, du bör hålla den här egenskapen inaktiverad. Alla användarinteraktioner kommer att nekas när i huvudlöst läge, och dina konton kommer inte att köras om de behöver **någon** konsolinmatning under starten. Detta är användbart för servrar, eftersom ASF kan avbryta försök att logga in på kontot när de ombeds att ange uppgifter, istället för att vänta (oändligt) på att användaren ska ge dem.

Aktivering av det här läget gör att du kan leverera nödvändig konsolinmatning på annat sätt, dvs. ASF-ui (ASF API), eller genom **[``](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#input-command)** kommando. Om du inte är säker på hur du ställer in denna egenskap, lämna den med standardvärdet `false`.

---

### `IdleJordbrukPeriod`

`byte` typ med standardvärdet `8`. När ASF inte har något att odla, kommer den regelbundet kontrollera varje `IdleFarmingPeriod` timmar om kanske konto fick några nya spel till gården. Den här funktionen behövs inte när vi pratar om nya spel vi får, eftersom ASF är smart nog att automatiskt kontrollera märkessidor i det här fallet. `IdleFarmingPeriod` är främst för situationer som gamla spel som vi redan har handelskort tillagda. I det här fallet finns det ingen händelse, så ASF måste regelbundet kontrollera märkessidor om vi vill ha detta täckt. Värdet av `0` inaktiverar den här funktionen. Kontroll: `ShutdownOnFarmingFinished` preferens i `FarmingPreferences`.

---

### `FörrådLimiterFördröjning`

`byte` typ med standardvärdet `4`. ASF kommer att se till att det kommer att finnas minst `InventoryLimiterDelay` sekunder i mellan två på varandra följande webb inventering förfrågningar för att undvika utlösande rate-limit - de används till exempel vid markering av inventering som läst, kan också användas av tredje part plugins hämta inventering av andra användare. Denna fastighet används inte för att hämta vår egen inventering, eftersom ASF använder mycket effektivare intern nätverksanrop för det, så det påverkar inte kommandon som `loot` eller `överföra` på något sätt. Standardvärdet för `4` sattes baserat på märkning av lager av över 100 på varandra följande bot instanser, och bör tillfredsställa de flesta (om inte alla) av användarna. Du kanske vill minska den eller till och med ändra till `0` om du har mycket låg mängd botar, så ASF kommer att ignorera förseningen och markera Steam-lager mycket snabbare. Be warned though, as setting it too low **will** result in Steam temporarily banning your IP, and that will prevent you from making any calls at all. Du kan också behöva öka detta värde om du kör en hel del robotar med en hel del inventering förfrågningar, även i detta fall bör du förmodligen försöka begränsa antalet dessa förfrågningar istället. Om du inte har en **stark** anledning att redigera denna egenskap, bör du behålla den som standard.

---

### `IPC`

`Bool` typ med standardvärdet `true`. Denna egenskap definierar om ASF's **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** -servern ska börja tillsammans med processen. IPC möjliggör inter-process kommunikation, inklusive användning av **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, genom att starta upp en lokal HTTP-server. Om du inte har för avsikt att använda någon tredje parts IPC-integration med ASF, inklusive vår ASF-ui, kan du säkert inaktivera detta alternativ. Annars är det en bra idé att hålla den aktiverad (standardalternativ).

---

### `IPCPassword`

`sträng` typ med standardvärdet `null`. Denna egenskap definierar obligatoriskt lösenord för varje API-samtal som görs via IPC och fungerar som en extra säkerhetsåtgärd. När satt till icke-tomt värde kommer alla IPC-förfrågningar kräva extra `lösenord` egenskap satt till det lösenord som anges här. Standardvärdet för `null` kommer att hoppa över ett behov av lösenordet, vilket gör ASF respektera alla frågor. Förutom det, aktivera detta alternativ aktiverar också inbyggd IPC-anti-bruteforce mekanism som tillfälligt kommer att förbjuda given `IPAdress` efter att ha skickat för många obehöriga förfrågningar på mycket kort tid. Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

### `IPCPasswordFormat`

`byte` typ med standardvärdet `0`. Denna egenskap definierar formatet för `IPCPassword` egenskap och använder `EHashingMethod` som underliggande typ. Se avsnittet **[Security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** om du vill veta mer, som du måste se till att `IPCPassword` egenskap faktiskt innehåller lösenord i matchande `IPCPasswordFormat`. Med andra ord när du ändrar `IPCPasswordFormat` så bör ditt `IPCPassword` vara **redan** i det formatet inte bara syftar till att vara. Om du inte vet vad du gör, bör du behålla det med standardvärdet `0`.

---

### `Licens-ID`

`Vägledning?` typ med standardvärdet `null`. Denna egenskap tillåter våra **[sponsorer](https://github.com/sponsors/JustArchi)** att förbättra ASF med valfria funktioner som kräver betalda resurser för att fungera. För nu kan du använda **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** funktionen i `ItemsMatcher` plugin.

Medan vi rekommenderar att du använder GitHub eftersom det erbjuder månatliga och engångs nivåer, samt tillåter full automatisering och ger dig omedelbar åtkomst, we **also** support all other currently available **[donationsalternativ](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. Se **[detta inlägg](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** för instruktioner om hur man donerar med andra metoder för att få en manuell licens giltig under angiven period.

Oavsett vilken metod som används, om du är ASF-sponsor, kan du få din licens **[här](https://asf.justarchi.net/User/Status)**. Du måste logga in med GitHub för att bekräfta din identitet, vi ber bara om läsbar offentlig information, vilket är ditt användarnamn. `LicenseID` är gjord av 32 hexadecimala tecken, såsom `f6a0529813f74d119982eb4fe43a9a24`.

**Se till att du inte delar ditt `LicenseID` med andra personer**. Eftersom det utfärdas på personlig basis, kan det bli återkallat om det läcker. Om av någon chans detta hände dig av misstag, kan du generera en ny från samma plats.

Om du inte vill aktivera extra ASF-funktioner, det finns inget behov av att erhålla / tillhandahålla licensen.

---

### `Inloggningsbegränsarefördröjning`

`byte` typ med standardvärdet `10`. ASF kommer att se till att det kommer att finnas minst `LoginLimiterDelay` sekunder i mellan två på varandra följande anslutningsförsök för att undvika utlösande hastighetsbegränsning. Standardvärdet för `10` sattes baserat på att ansluta över 100 bot instanser, och bör tillfredsställa de flesta (om inte alla) av användarna. Du kanske vill öka/minska den, eller till och med ändra till `0` om du har mycket låg mängd botar, så ASF kommer att ignorera förseningen och ansluta till Steam mycket snabbare. Varnas dock eftersom inställningen är för låg samtidigt som för många robotar **kommer** resultera i att Steam tillfälligt bannlyser din IP, och det kommer att hindra dig från att logga in **alls**, med `InvalidPassword/RateLimitExceeded` fel - och det inkluderar även din vanliga Steam-klient, inte bara ASF. Likaså, om du kör för många robotar, särskilt tillsammans med andra Steam-klienter/verktyg med samma IP-adress, mest troligt att du behöver öka detta värde för att sprida inloggningar under längre tid.

Som en sidoanteckning används detta värde även som lastbalanseringsbuffert i alla ASF-schemalagda åtgärder, såsom avslut i `SendTradePeriod`. Om du inte har en **stark** anledning att redigera denna egenskap, bör du behålla den som standard.

---

### `MaxFarmingTime`

`byte` typ med standardvärdet `10`. Som du bör veta, Steam fungerar inte alltid korrekt, ibland konstiga situationer kan hända som vår speltid inte registreras, trots att, faktiskt, spela ett spel. ASF kommer att göra det möjligt att odla ett enda spel i solo-läge för maximalt `MaxFarmingTime` timmar, och anser det fullt odlad efter den perioden. Detta krävs för att inte frysa jordbruksprocessen i händelse av konstiga situationer inträffar, men också om Steam av någon anledning släppte ett nytt märke som skulle hindra ASF från att gå vidare (se: `Svartlista`). Standardvärdet för `10` timmar bör vara tillräckligt för att släppa alla ångkort från ett spel. Ställa in den här egenskapen för lågt kan resultera i att giltiga spel hoppas över (och ja, Det finns giltiga spel som tar upp till 9 timmar till gården), samtidigt som det är för högt kan leda till att jordbruksprocessen frysas. Observera att denna egenskap påverkar endast ett enda spel i en enda jordbrukssession (så efter att ha gått igenom hela kön ASF kommer tillbaka till den titeln), Det är också inte baserat på total speltid utan intern ASF jordbrukstid, så ASF kommer också att återgå till den titeln efter en omstart. Om du inte har en **stark** anledning att redigera denna egenskap, bör du behålla den som standard.

---

### `MaxTradeHoldDuration`

`byte` typ med standardvärdet `15`. Den här egenskapen definierar maximal varaktighet i dagar som vi är villiga att acceptera - ASF kommer att avvisa affärer som hålls i mer än `MaxTradeHoldVaraktighet` dagar, enligt definitionen i **[handel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** avsnitt. Det här alternativet är vettigt endast för bottar med `TradingPreferences` för `SteamTradeMatcher`, eftersom det inte påverkar `Master`/`SteamOwnerID` handlar, inga donationer. Handel är irriterande för alla, och ingen vill verkligen ta itu med dem. ASF ska arbeta med liberala regler och hjälpa alla, oavsett om bytet hålls kvar eller inte - det är därför detta alternativ är satt till `15` som standard. Men om du istället föredrar att avvisa alla affärer som påverkas av bytesinnehav kan du ange `0` här. Tänk på att kort med kort livslängd inte påverkas av detta alternativ och automatiskt avvisas för personer med fackinnehav, som beskrivs i **[handel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** avsnitt, Så det finns ingen anledning att globalt förkasta alla bara på grund av det. Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.


---

### `MinFarmingFördröjningAfterBlock`

`byte` typ med standardvärdet `60`. Denna egenskap definierar minsta möjliga tid, på några sekunder. vilken ASF kommer att vänta innan återuppta kortodling om den tidigare kopplats från `LoggedInElsewhere`, vilket händer när du väljer att kraftfullt koppla bort nuvarande jordbruk ASF genom att lansera ett spel. Denna fördröjning existerar främst av bekvämlighetsskäl och omliggande skäl, till exempel kan du starta om spelet utan att behöva slåss med ASF ockuperar ditt konto igen bara för att spela lås var tillgänglig för en split sekund. På grund av det faktum att återta sessionen orsakar `LoggedInElsewhere` koppling, ASF måste gå igenom hela återanslutning, vilket sätter extra tryck på maskinen och Steam-nätverket, därför att undvika ytterligare frånkopplingar, om möjligt, är att föredra. Som standard är detta konfigurerat på `60` sekunder, vilket borde vara tillräckligt för att du ska kunna starta om spelet utan mycket krångel. Det finns dock scenarier när du kan vara intresserad av att öka det, till exempel om ditt nätverk kopplas bort ofta och ASF tar över för tidigt, vilket orsakar att tvingas gå igenom återkopplingsförloppet själv. Vi tillåter ett maximalt värde av `255` för denna fastighet, vilket bör vara tillräckligt för alla gemensamma scenarier. Förutom det ovannämnda är det också möjligt att minska förseningen, eller till och med ta bort den helt med ett värde av `0`, även om det vanligtvis inte rekommenderas på grund av skäl som anges ovan. Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

### `Optimeringsläge`

`byte` typ med standardvärdet `0`. Denna egenskap definierar optimeringsläge som ASF kommer att föredra under körtid. ASF stöder för närvarande två lägen - `0` som kallas `MaxPerformance`, och `1` som heter `MinMemoryUsage`. Som standard föredrar ASF att köra så många saker parallellt (samtidigt) som möjligt, vilket förbättrar prestandan genom belastningsbalanserande arbete över alla processorkärnor, flera processortrådar, flera uttag och flera trådpooluppgifter. Till exempel, ASF kommer att be om din första badge sida när du söker efter spel till gården, och sedan en gång begäran anlände, ASF kommer att läsa från det hur många märken sidor du faktiskt har, sedan begära varandra samtidigt. Detta är vad du ska ha **nästan alltid**, som overhead i de flesta fall är minimal och fördelarna med asynkron ASF-kod kan ses även på den äldsta hårdvaran med en enda CPU-kärna och kraftigt begränsad effekt. Men med många uppgifter som behandlas parallellt, ASF runtime ansvarar för deras underhåll, t.ex. hålla uttag öppna, trådar levande och uppgifter bearbetas, vilket kan resultera i ökad minnesanvändning från tid till annan, och om du är extremt begränsad av tillgängligt minne, du kanske vill byta denna egenskap till `1` (`MinMemoryUsage`) för att tvinga ASF att använda så lite uppgifter som möjligt, och vanligtvis kör möjlig-till-parallell asynkron kod på ett synkront sätt. Du bör överväga att byta denna egenskap endast om du tidigare läst **[låg-minnesinställningar](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** och du medvetet vill offra gigantisk prestandaökning, för en mycket liten minne overhead minska. Vanligtvis är detta alternativ **mycket värre** än vad du kan uppnå med andra möjliga sätt, t.ex. genom att begränsa din ASF-användning eller trimma runtime sophämtare, som förklaras i **[låg-minnesinstallation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Därför bör du använda `MinMemoryUsage` som en **sista utväg**, precis innan runtime omkompilering, om du inte kunde uppnå tillfredsställande resultat med andra (mycket bättre) alternativ. Om du inte har en **stark** anledning att redigera denna egenskap, bör du behålla den som standard.

---

### `PluginsUpdateList`

`ImmutableHashSet<string>` -typ med standardvärdet för att vara tomt. Denna egenskap definierar en lista över namn på plugin-montering som antingen är svartlistade eller vitlistade för att övervägas för automatiska uppdateringar, enligt `PluginsUpdateMode` definierat nedan.

Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

### `PluginsUpdateMode`

`byte` typ med standardvärdet `0`. Denna egenskap definierar plugins uppdateringsläge som ger mening till `PluginsUpdateList` definierad ovan. Genom att ange denna egenskap kan du enkelt aktivera / inaktivera automatiska uppdateringar för alla plugins utom de som deklareras.

- Värdet av `0`, kallad `vitlista`, **inaktiverar** automatisk uppdatering av alla plugins, förutom de som definieras i `PluginsUpdateList`.
- Värdet av `1`, kallad `Svartlista`, **aktiverar** automatisk uppdatering av alla plugins, förutom de som definieras i `PluginsUpdateList`.

**ASF-teamet vill påminna dig om att för din egen säkerhet bör du aktivera automatiska uppdateringar endast från betrodda parter**. Tänk på att skadliga plugins kan bestämma sig för att uppdatera sig själva eller köra fjärrkommandon **oavsett** av denna inställning, Det är därför denna inställning gäller ASF-tillhandahållna plugins uppdatera funktionalitet exklusivt, och du bör fortfarande se till att du har på lämpligt sätt verifierat varje plugin som du har beslutat att använda.

Uppdateringar av plugins utförs som standard tillsammans med ASF uppdateringsrutin - **[`UpdateChannel`](#updatechannel)** och **[`UpdatePeriod`](#updateperiod)**. Standard ASF uppdateringsmekanismer såsom `update` kommandot kommer också att utlösa valfria plugins uppdatering. Om du istället vill uppdatera plugins manuellt utan att uppdatera ASF-versionen samtidigt, erbjuder `updateplugins` kommandot en sådan möjlighet.

Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

### `AvstängningMöjlig`

`Bool` skriv med standardvärdet `false`. När det är aktiverat, ASF kommer att försöka stänga processen om möjligt, det vill säga när alla dina registrerade robotar stoppas. Detta kan vara särskilt användbart när den kombineras med `ShutdownOnFarmingFinished` på alla dina bot-instanser, eftersom detta sätt ASF kommer att tillåtas att automatiskt stänga när den sista av dina robotar avslutar jordbruk.

Eftersom förväntningarna hos majoriteten av användarna är att ha processen igång hela tiden, e. . för `IPC` -användning, detta alternativ är inaktiverat som standard.

---

### `SteamMessagePrefix`

`sträng` typ med standardvärdet `"/me "`. Denna egenskap definierar ett prefix som kommer att vara beroende av alla Steam-meddelanden som skickas av ASF. ASF använder som standard `"/me "` prefix för att lättare kunna särskilja botmeddelanden genom att visa dem i annan färg på Steam-chatten. Ett annat värt att nämna är `"/pre "` prefix som uppnår liknande resultat, men använder olika formateringar. Du kan också ställa in den här egenskapen till att tömma strängen eller `null` för att inaktivera prefixet helt och skriva ut alla ASF-meddelanden på ett traditionellt sätt. Det är trevligt att notera att denna egenskap påverkar endast Steam-meddelanden - svar som returneras via andra kanaler (såsom IPC) påverkas inte. Om du inte vill anpassa standard ASF beteende är det en bra idé att lämna det som standard.

---

### `SteamOwnerID`

`ulong` typ med standardvärdet `0`. Denna egenskap definierar Steam-ID i 64-bitars form av ASF-processägare, och är mycket lik `Master` tillstånd av given bot instans (men global istället). Du vill nästan alltid ställa in den här egenskapen till ID för ditt eget huvudsakliga Steam-konto. `Master` tillstånd inkluderar full kontroll över sin bot instans, men globala kommandon som `exit`, `starta om` eller `uppdatering` är reserverade för `SteamOwnerID` bara. Detta är bekvämt, som du kanske vill köra botar för dina vänner, samtidigt som de inte tillåter dem att kontrollera ASF-processen, såsom avsluta det via `avsluta` -kommandot. Standardvärdet för `0` anger att det inte finns någon ägare av ASF-processen, vilket innebär att ingen kommer att kunna utfärda globala ASF-kommandon. Tänk på att den här egenskapen endast gäller Steam-chatt. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, liksom interaktiv konsol, kommer fortfarande att tillåta dig att köra `Owner` kommandon även om denna egenskap inte är inställd.

---

### `Ångprotokoll`

`byte flaggor` typ med standardvärdet `7`. Denna egenskap definierar Steam-protokoll som ASF kommer att använda vid anslutning till Steam-servrar, vilka definieras som nedan:

| Värde | Namn      | Beskrivning                                                                                     |
| ----- | --------- | ----------------------------------------------------------------------------------------------- |
| 0     | Ingen     | No protocol                                                                                     |
| 1     | TCP       | **[Överföring kontrollprotokoll](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2     | UDP       | **[Användardatagram-protokoll](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**          |
| 4     | WebSocket | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                                        |

Observera att denna egenskap är `flaggor` fält, därför är det möjligt att välja valfri kombination av tillgängliga värden. Kolla in **[json mapping](#json-mapping)** om du vill veta mer. Att inte aktivera någon av flaggorna resulterar i `Inget` -alternativ, och det alternativet är ogiltigt av sig själv.

Som standard kommer ASF att använda alla tillgängliga Steam-protokoll som en åtgärd för att slåss med stilleståndstider och andra liknande Steam-problem. Vanligtvis vill du ändra den här egenskapen om du vill begränsa ASF till att endast använda en eller två specifika protokoll. Sådana åtgärder kan behövas i olika situationer, till exempel om du har blockerat UDP trafik på brandväggen och du vill se till att endast TCP trafik går igenom, eller om du använder `WebProxy` och vill använda den även för Steam-klientanslutning, som endast `WebSocket` protokoll stöder det.

Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

### `Uppdateringskanal`

`byte` typ med standardvärdet `1`. Denna egenskap definierar uppdateringskanal som används, antingen för automatiska uppdateringar (om `UpdatePeriod` är större än `0`), eller uppdatera meddelanden (annars). ASF stöder för närvarande tre uppdateringskanaler - `0` som heter `Ingen`, `1`, som heter `Stable`och `2`, som heter `PreRelease`. `Stabil` -kanal är den förvalda release-kanalen, som bör användas av de flesta användare. `PreRelease` -kanal förutom `stabila` -utgåvor, innehåller även **förutgåvor** avsedda för avancerade användare och andra utvecklare för att testa nya funktioner, bekräfta buggfixar eller ge feedback om planerade förbättringar. **PreRelease versioner innehåller ofta opåverkade buggar, work-in-progress funktioner eller omskrivna implementationer**. Om du inte anser dig vara avancerad användare, vänligen stanna med standard `1` (`Stable`) uppdateringskanal. `PreRelease` -kanal är dedikerad till användare som vet hur man rapporterar buggar, hantera frågor och ge feedback - ingen teknisk support kommer att ges. Kolla in ASF **[release cycle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** om du vill veta mer. Du kan också ställa in `UpdateChannel` till `0` (`Ingen`), om du vill ta bort alla versionskontroller. Ställa in `UpdateChannel` till `0` kommer helt att inaktivera hela funktionaliteten i samband med uppdateringar, inklusive `update` -kommandot. Använda `Ingen` kanal är **starkt avskräckt** på grund av att utsätta dig för alla typer av problem (nämns i `UpdatePeriod` beskrivning nedan).

**Om du inte vet vad du gör**, Vi **starkt** rekommenderar att hålla det som standard.

---

### `Uppdateringsperiod`

`byte` typ med standardvärdet `24`. Denna egenskap definierar hur ofta ASF bör söka efter auto-uppdateringar. Uppdateringar är avgörande inte bara för att få nya funktioner och kritiska säkerhetsuppdateringar, utan också för att få buggfixar, prestandaförbättringar, stabilitetsförbättringar med mera. När ett värde större än `0` är inställt, ASF kommer automatiskt att ladda ner, ersätta, och starta om sig själv (om `AutoStarta om` tillåter) när ny uppdatering är tillgänglig. För att uppnå detta, ASF kommer att kontrollera varje `UpdatePeriod` timmar om ny uppdatering finns tillgänglig på vår GitHub repo. Ett värde av `0` inaktiverar automatiska uppdateringar, men låter dig ändå köra kommandot `uppdatera` manuellt. Du kan också vara intresserad av att ställa in lämpliga `UpdateChannel` som `UpdatePeriod` ska följa.

Uppdateringsprocessen för ASF innebär uppdatering av hela mappstrukturen som ASF använder, men utan att röra dina egna konfigurationer eller databaser som finns i `config` -katalogen - detta innebär att eventuella extra filer som inte är relaterade till ASF i dess katalog kan gå förlorade under uppdateringen. Standardvärdet för `24` är en bra balans mellan onödiga kontroller och ASF som är tillräckligt färska.

Om du inte har en **stark** anledning att inaktivera den här funktionen, du bör hålla automatiska uppdateringar aktiverade inom rimlig `uppdateringsperiod` **för ditt eget bästa**. Detta beror inte bara på att vi inte stöder något annat än den senaste stabila ASF-utgåvan, men också för att **vi ger vår säkerhetsgaranti endast för senaste versionen**. Om du använder gammal ASF-version då du avsiktligt utsätter dig för alla typer av problem, från små buggar, genom trasiga funktionalitet, slutar med **[permanenta Steam-kontoavstängningar](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**, så vi **rekommenderar starkt**för ditt eget bästa, att alltid se till att din ASF-version är uppdaterad. Auto-uppdateringar gör att vi kan reagera snabbt på alla typer av problem genom att inaktivera eller lappa problemkod innan den kan eskalera - om du väljer bort den, du förlorar alla våra säkerhetsgarantier och riskkonsekvenser från att köra kod som kan vara potentiellt skadlig, inte bara till Steam-nätverket, utan också (per definition) till ditt eget Steam-konto.

---

### `WebLimiterfördröjning`

`ushort` typ med standardvärdet `300`. Denna egenskap definierar, i milisekunder, det minsta antalet förseningar mellan att skicka två efterföljande förfrågningar till samma Steams webbtjänst. Sådan fördröjning krävs som **[AkamaiGhost](https://www.akamai.com)** -tjänst som Steam använder internt inkluderar hastighetsbegränsning baserat på det globala antalet förfrågningar som skickas under given tidsperiod. Under normala omständigheter akamai block är ganska svårt att uppnå, men under mycket tung arbetsbelastning med en enorm pågående kö av förfrågningar, Det är möjligt att utlösa det om vi fortsätter att skicka för många förfrågningar under för kort tid.

Standardvärdet sattes baserat på antagandet att ASF är det enda verktyget som använder Steam webb-tjänster, i synnerhet `steamcommunity. Om`, `api.steampowered.com` och `store.steampowered.com`. Om du använder andra verktyg som skickar förfrågningar till samma webbtjänster bör du se till att ditt verktyg innehåller liknande funktionalitet för `WebLimiterDelay` och ställa in båda till dubbelt standardvärde, vilket skulle vara `600`. Detta garanterar att du under inga omständigheter överskrider att skicka mer än 1 begäran per `300` ms.

I allmänhet att sänka `WebLimiterDelay` under standardvärde är **starkt avskräckt** eftersom det kan leda till olika IP-relaterade block, några av dessa är möjliga att vara permanent. Standardvärdet är tillräckligt bra för att köra en enda ASF-instans på servern, såväl som att använda ASF i normalt scenario tillsammans med original Steam-klient. Det bör vara korrekt för de flesta användningsområden, och du bör bara öka det (aldrig sänka det). Kort sagt, globalt antal alla förfrågningar som skickas från en enda IP till en enda Steam-domän får aldrig överstiga mer än 1 begäran per `300` ms.

Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

### `WebProxy`

`sträng` typ med standardvärdet `null`. Denna egenskap definierar en webbproxyadress som kommer att användas för intern http-relaterad kommunikation, särskilt till tjänster som `github. Om`, `api.steampowered.com`, `steamcommunity.com` och `store.steampowered.com`. Det gäller allmän (icke-bot specifikt) kommunikation, liksom bot-specifik kommunikation om deras motsvarande `WebProxy` konfigurationsegenskap inte är inställd. Proxying ASF förfrågningar kan vara exceptionellt användbart för att kringgå olika typer av brandväggar, särskilt den stora brandväggen i Kina.

Den här egenskapen definieras som URI-sträng:

> En URI-sträng består av ett system (stöds: http/https/socks4/socks4a/socks5), en värd och en valfri port. Ett exempel på en komplett uri sträng är `"http://contoso.com:8080"`.

Om din proxy kräver användarautentisering måste du även konfigurera `WebProxyUsername` och/eller `WebProxyPassword`. Om det inte finns något sådant behov räcker det att bara inrätta denna egendom.

Om du behöver proxying intern Steam-nätverkskommunikation (CM) också, då bör du se till att konfigurera **[`SteamProtocols`](#steamprotocols)** botens egendom till ett värde som endast tillåter websocket transport, i. . ett värde av `4`, eftersom endast websockets stöds för proxying.

Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

### `WebProxyPassword`

`sträng` typ med standardvärdet `null`. Den här egenskapen definierar lösenordsfältet som används i grundläggande, digest, NTLM, och Kerberos autentisering som stöds av ett mål `WebProxy` maskin som ger proxy-funktionalitet. Om din proxy inte kräver användaruppgifter, finns det inget behov av att mata in något här. Använda detta alternativ är vettigt endast om `WebProxy` används också, eftersom det inte har någon effekt annars.

Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

### `WebProxyUsername`

`sträng` typ med standardvärdet `null`. Denna egenskap definierar användarnamn fält som används i grundläggande, digest, NTLM, och Kerberos autentisering som stöds av ett mål `WebProxy` maskin som ger proxy-funktionalitet. Om din proxy inte kräver användaruppgifter, finns det inget behov av att mata in något här. Använda detta alternativ är vettigt endast om `WebProxy` används också, eftersom det inte har någon effekt annars.

Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

## Bot config

Som du bör veta redan, varje bot bör ha sin egen konfiguration baserad på exempel JSON struktur nedan. Börja med att bestämma hur du vill namnge din bot (t.ex. `1.json`, `main. son`, `primäter.json` eller `AnythingElse.json`) och gå över till konfiguration.

**Observera:** Bot kan inte heta `ASF` (som det nyckelordet är reserverat för global konfiguration), ASF kommer också att ignorera alla konfigurationsfiler som börjar med en prick.

bot konfigurationen har följande struktur:

```json
{
    "AcceptGåvor": false,
    "BotBeteende": 0,
    "SlutfördaTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Aktiverad": false,
    "FarmingOrders": [],
    "FarmingPreferences": 0,
    "GamesPlayedWhileIdle": [],
    "GamingDeviceType": 1,
    "TimmarUntilCardDrops": 3,
    "LootableTyper": [1, 3, 5],
    "MachineName": noll,
    "Matchbara typer": [5],
    "OnlineFlaggor": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "LösningPreferences": 0,
    "RemoteCommunication": 3,
    "SendTradePeriod": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "Överförbara typer": [1, 3, 5],
    "UseLoginKeys": sant,
    "UserInterfaceMode": 0,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Alla alternativ förklaras nedan:

### `AccepteraGåvor`

`Bool` skriv med standardvärdet `false`. När detta är aktiverat kommer ASF automatiskt att acceptera och lösa in alla ånggåvor (inklusive plånboks-presentkort) som skickas till boten. Detta inkluderar även gåvor som skickas från andra användare än de som definieras i `SteamUserPermissions`. Tänk på att gåvor som skickas till e-postadress inte direkt vidarebefordras till kunden, så ASF kommer inte att acceptera dem utan din hjälp.

Detta alternativ rekommenderas endast för alt konton, eftersom det är mycket troligt att du inte vill automatiskt lösa in alla gåvor som skickas till ditt primära konto. Om du är osäker på om du vill ha den här funktionen aktiverad eller inte, behåll den med standardvärdet `false`.

---

### `BotBeteende`

`byte flaggor` typ med standardvärdet `0`. Denna egenskap definierar ASF bot-liknande beteende under olika händelser, och definieras som nedan:

| Värde | Namn                               | Beskrivning                                                                                                    |
| ----- | ---------------------------------- | -------------------------------------------------------------------------------------------------------------- |
| 0     | Ingen                              | Inget speciellt botbeteende, sunda standardinställningar                                                       |
| 1     | Avvisa ogiltiga väninbjudningar    | Kommer att orsaka ASF att avvisa (istället för att ignorera) ogiltiga väninbjudningar                          |
| 2     | Avvisa ogiltiga Handel             | Kommer att få ASF att avvisa (istället för att ignorera) ogiltiga handelserbjudanden                           |
| 4     | Avvisa InvalidGroupInbjudningar    | Kommer att orsaka ASF att avvisa (istället för att ignorera) ogiltiga gruppinbjudningar                        |
| 8     | DismissInventoryNotifieringar      | Kommer att orsaka ASF att automatiskt avfärda alla lageraviseringar                                            |
| 16    | Märkt mottagna meddelandenLäs      | Kommer att orsaka ASF att automatiskt markera alla mottagna meddelanden som lästa                              |
| 32    | MarkBotMeddelandensom läses        | Kommer att orsaka ASF att automatiskt markera meddelanden från andra ASF-robotar (körs i samma fall) som lästa |
| 64    | Inaktivera InkommandeTradesParsing | Kommer att orsaka ASF att aldrig behandla inkommande handelserbjudanden                                        |

Observera att denna egenskap är `flaggor` fält, därför är det möjligt att välja valfri kombination av tillgängliga värden. Kolla in **[json mapping](#json-mapping)** om du vill veta mer. Not enabling any of flags results in `None` option.

I allmänhet vill du ändra den här egenskapen om du förväntar dig att ändra olika automatiseringsinställningar relaterade till botens aktivitet. Standardinställningarna gäller ASF som körs i icke-invasivt läge, vilket möjliggör endast fördelaktig automatisering som inte går mot användarens vilja.

Ogiltig väninbjudan är en inbjudan som inte kommer från användare med `FamilySharing` behörighet (definierad i `SteamUserbehörigheter`) eller senare. ASF i normalt läge ignorerar dessa inbjudningar, som du förväntar dig, vilket ger dig fritt val om att acceptera dem, eller inte. `RejectInvalidFriendInvites` kommer att göra att dessa inbjudningar automatiskt avvisas, som praktiskt taget kommer att inaktivera alternativet för andra personer att lägga till dig till sin vänlista (som ASF kommer att neka alla sådana förfrågningar, förutom personer som definieras i `SteamUserbehörigheter`). Om du inte helt vill förneka alla vänner inbjudningar, bör du inte aktivera detta alternativ.

Ogiltigt handelserbjudande är ett erbjudande som inte accepteras genom inbyggd ASF-modul. Mer om detta kan hittas i **[handel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** avsnitt som uttryckligen definierar vilka typer av handel ASF är villig att acceptera automatiskt. Giltiga avslut definieras också av andra inställningar, särskilt `TradingPreferences`. `RejectInvalidTrades` kommer att göra att alla ogiltiga handelserbjudanden avvisas, istället för att ignoreras. Såvida du inte vill direkt neka alla handelserbjudanden som inte automatiskt accepteras av ASF, bör du inte aktivera detta alternativ.

Ogiltig gruppinbjudan är en inbjudan som inte kommer från `SteamMasterClanID` grupp. ASF i normalt läge ignorerar dessa grupper inbjudningar, som du förväntar dig, så att du själv kan bestämma dig om du vill gå med i en specifik Steam-grupp eller inte. `RejectInvalidGroupInvites` kommer att göra att alla dessa gruppinbjudningar automatiskt avvisas, effektivt gör det omöjligt att bjuda in dig till någon annan grupp än `SteamMasterClanID`. Om du inte vill direkt förneka alla gruppinbjudningar, bör du inte aktivera detta alternativ.

`DismissInventoryNotifications` är extremt användbart när du börjar bli irriterad av konstant Steam-avisering om att ta emot nya objekt. ASF kan inte bli av med själva meddelandet eftersom det är inbyggt i din Steam-klient, men det är möjligt att automatiskt rensa meddelandet efter att ha fått det, vilket inte längre kommer att lämna "nya artiklar i inventarier" anmälan hängande runt. Om du förväntar dig att utvärdera dig själv alla mottagna objekt (särskilt kort som odlas med ASF), då naturligtvis bör du inte aktivera detta alternativ. När du börjar gå galen, kom ihåg detta erbjuds som ett alternativ.

`MarkReceivedMessagesAsRead` markerar automatiskt **alla** meddelanden som tas emot av kontot som ASF körs på, både privat och grupp, som läst. Detta bör normalt användas av alt konton endast för att rensa "nytt meddelande" meddelande kommer t.ex. från dig under körning av ASF-kommandon. Vi rekommenderar inte det här alternativet för primära konton, om du inte vill avbryta dig själv från någon form av nya meddelanden meddelanden, **inklusive** de som hände medan du var offline, förutsatt att ASF fortfarande lämnades öppen avfärda det.

`MarkBotMessagesAsRead` fungerar på ett liknande sätt genom att bara markera bot meddelanden som lästa. Men tänk på att när du använder det alternativet på gruppchattar med dina robotar och andra människor, Steam-implementering av att bekräfta chattmeddelandet **också** bekräftar alla meddelanden som hände **innan** den du bestämde dig för att markera, så om du av någon chans inte vill missa orelaterade meddelande som hände däremellan, du vanligtvis vill undvika att använda denna funktion. Självklart är det också riskabelt när du har flera primära konton (t.ex. från olika användare) som körs i samma ASF instans, som du kan också missa deras normala out-of-ASF meddelanden.

`DisableIncomingTradesParsing` kommer att stoppa ASF från att parsa inkommande handelserbjudanden, detta innebär att hela handel funktionalitet relaterade till det kommer att vara icke-operativ. Eftersom ASF fungerar i det minst invasiva läget som standard, accepterar endast byteserbjudanden från `Master` användare och ovan, aldrig röra vid andra handelserbjudanden - inkommande affärer parsning är aktiverat som standard. Denna inställning gör det mest meningsfullt för människor som vill säkerställa inga ytterligare förfrågningar / overhead relaterade till handel parsing, inaktivera hela logiken i processen, till exempel eftersom de vet att deras robotar aldrig kommer att få master handel förfrågningar, och kräver därför inte att ASF deltar i sin handelsverksamhet alls. Tänk på att med detta alternativ som anges kommer att inaktivera alla andra alternativ som beror på inkommande handel också, såsom `AcceptDonationer` eller `SteamTradeMatcher` - anpassade plugins kommer inte heller att kunna behandla inkommande handelserbjudanden på vanligt sätt.

Om du är osäker på hur du konfigurerar det här alternativet är det bäst att lämna det som standard.

---

### `CompleteTypesToSend`

`ImmutableHashSet<byte>` -typ med standardvärdet för att vara tomt. När ASF är klar med att slutföra en given uppsättning av objekttyper som anges här, det kan automatiskt skicka ångbyte med alla färdiga set till användaren med `Master` behörighet, vilket är mycket praktiskt om du vill använda given bot konto för e. . STM matchning, när du flyttar färdiga set till något annat konto. Det här alternativet fungerar som kommandot `loot` , tänk därför på att det kräver användare med `Master` behörighet, du kan också behöva en giltig `SteamTradeToken`, samt att använda ett konto som är berättigat till handel i första hand.

Från och med idag stöds följande artikeltyper i denna inställning:

| Värde | Namn            | Beskrivning                                                          |
| ----- | --------------- | -------------------------------------------------------------------- |
| 3     | FoilTradingCard | Foil variant av `TradingCard`                                        |
| 5     | TradingCard     | Steam-handelskort, som används för att tillverka märken (icke-folie) |

Observera att oavsett inställningarna ovan, ASF kommer endast be om **[Steam-community-objekt](https://steamcommunity.com/my/inventory/#753_6)** (`appID` av 753, `contextID` av 6), så alla spelföremål, gåvor och likaså utesluts från handelserbjudandet per definition.

På grund av ytterligare overhead för att använda detta alternativ, det rekommenderas att använda det endast på bot konton som har en realistisk chans att avsluta uppsättningar på egen hand - till exempel Det är ingen mening med att aktivera om du redan använder `SendOnFarmingFinished` preferens i `FarmingPreferences`, `SendTradePeriod` eller `loot` kommando på vanlig basis.

Om du är osäker på hur du konfigurerar det här alternativet är det bäst att lämna det som standard.

---

### `SkräddarSpelatUnder spelningJordbruk`

`sträng` typ med standardvärdet `null`. När ASF är jordbruk, kan det visa sig som "Spela icke-ånga spel: `CustomGamePlayedWhileFarming`" istället för för för närvarande odlade spel. Detta kan vara användbart om du vill låta dina vänner veta att du odlar, men du vill inte använda `OnlineStatus` för `Offline`. Observera att ASF inte kan garantera den faktiska visningsordningen för Steam-nätverket, därför är detta bara ett förslag som kan, eller inte kan, visa ordentligt. I synnerhet anpassat namn kommer inte att visas i `Complex` odlingsalgoritm om ASF fyller alla `32` slots med spel som kräver timmar att stöta på. Standardvärdet för `null` inaktiverar denna funktion.

ASF innehåller några speciella variabler som du kan använda i din text. `{0}` kommer att ersättas av ASF med `AppID` för närvarande odlade spel(er), medan `{1}` kommer att ersättas av ASF med `spelnamn` för närvarande odlade spel.

---

### `CustomGamePlayedWhileIdle`

`sträng` typ med standardvärdet `null`. Liknande `CustomGamePlayedWhileFarming`, men för situationen när ASF inte har något att göra (som kontot är fullfart). Observera att ASF inte kan garantera den faktiska visningsordningen för Steam-nätverket, därför är detta bara ett förslag som kan, eller inte kan, visa ordentligt. Om du använder `spelSpelatMedan du Idle` tillsammans med detta alternativ, tänk då på att `spelatSpelatMedan Idle` får prioritet, därför kan du inte deklarera mer än `31` av dem, som annars `CustomGamePlayedWhileIdle` kommer inte att kunna ockupera facket för anpassat namn. Standardvärdet för `null` inaktiverar denna funktion.

---

### `Aktiverad`

`Bool` skriv med standardvärdet `false`. Denna egenskap definierar om bot är aktiverad. Aktiverad bot instans (`true`) startar automatiskt när ASF körs, medan inaktiverad bot instans (`false`) måste startas manuellt. Som standard är varje bot inaktiverad, så du förmodligen vill byta den här egenskapen till `true` för alla dina robotar som bör startas automatiskt.

---

### `Jordbruksorder`

`Omutabellista<byte>` typ med standardvärdet för att vara tomt. Denna egenskap definierar den **föredragna** jordbruksorder som används av ASF för givet bot konto. För närvarande finns det följande jordbruksorder tillgängliga:

| Värde | Namn                     | Beskrivning                                                                              |
| ----- | ------------------------ | ---------------------------------------------------------------------------------------- |
| 0     | Oordnad                  | Ingen sortering, något bättre CPU-prestanda                                              |
| 1     | AppIDsStigande           | Försök att odla spel med lägsta `appID` först                                            |
| 2     | Fallande apparFallande   | Försök att odla spel med högsta `appID` först                                            |
| 3     | KortdropparStigande      | Försök att bondgård spel med lägsta antalet kort droppar kvar först                      |
| 4     | KortdropparFallande      | Försök att bondgård spel med högsta antalet kort droppar kvar först                      |
| 5     | TimmarStigande           | Försök att gård spel med lägsta antal spelade timmar först                               |
| 6     | TimmarFallande           | Försök att gård spel med högsta antalet spelade timmar först                             |
| 7     | Namnstigande             | Försök att gård spel i alfabetisk ordning, med start från A                              |
| 8     | NamnFallande             | Försök att gård spel i omvänd alfabetisk ordning, med start från Z                       |
| 9     | Slumpmässig              | Försök att gård spel i helt slumpmässig ordning (olika på varje körning av programmet)   |
| 10    | Nivåer stigande          | Försök att gård spel med lägsta märkesnivåer först                                       |
| 11    | BadgeLevelsFallande      | Försök att gård spel med högsta märkesnivå först                                         |
| 12    | Lös inDateTimesStigande  | Försök att gård äldsta spel på vårt konto först                                          |
| 13    | Lös in DateTimesFallande | Försök att odla nyaste spel på vårt konto först                                          |
| 14    | Stigande                 | Försök att gården spel med oåterkalleliga kort droppar först (varning: dyrt att beräkna) |
| 15    | MarketableFallande       | Försök att gården spel med säljbara kort droppar först (varning: dyrt att beräkna)       |

Eftersom denna egenskap är en array, kan du använda flera olika inställningar i din fasta ordning. Till exempel kan du inkludera värden av `15`, `11` och `7` för att sortera efter säljbara spel först, sedan av dem med högsta märkesnivå, och slutligen alfabetiskt. Som ni kan gissa spelar ordern faktiskt roll, som omvänd en (`7`, `11` och `15`) uppnår något helt annat (sorterar spel alfabetiskt först, och på grund av att spelnamn är unika, de andra två är effektivt värdelösa). Majoriteten av människor kommer förmodligen att använda bara en order av dem alla, men om du vill, kan du också sortera vidare efter extra parametrar.

Lägg också märke till ordet "försök" i alla ovanstående beskrivningar - den faktiska ASF-ordern påverkas kraftigt av utvalda **[kort odlingsalgoritm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** och sortering kommer att påverka endast resultat som ASF anser samma prestanda-wise. Till exempel i `Simple` algoritm, valda `Jordbruksorder` bör respekteras helt i nuvarande jordbrukssession (eftersom varje spel har samma prestandavärde), medan i `komplexa` algoritm faktiska ordningen påverkas av timmar först, och sedan sorteras enligt valda `Jordbruksorder`. Detta kommer att leda till olika resultat, eftersom spel med befintlig speltid kommer att ha företräde framför andra, så effektivt ASF kommer att föredra spel som redan passerat krävs `timmarUntilCardDrops` för det första, och bara sedan sortera dessa spel vidare genom din valda `Jordbruksorder`. Likaså när ASF tar slut av redan stöta på spel, det kommer att sortera kvarvarande kö efter timmar först (eftersom det kommer att minska tiden som krävs för att stöta på någon av återstående titlar till `TimmarUntilCardDrops`). Därför är denna konfigurationsegenskap bara ett **förslag** som ASF kommer att försöka respektera, så länge det inte påverkar prestanda negativt (i detta fall, ASF kommer alltid att föredra jordbruks prestanda framför `Jordbruks order`).

Det finns också jordbruks prioriterad kö som är tillgänglig via `fq` **[kommandon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Om den används sorteras den faktiska jordbruksordningen först efter resultat, sedan efter jordbrukskö och slutligen efter din `Jordbruksorder`.

---

### `JordbruksinställningarInställningar`

`byte flaggor` typ med standardvärdet `0`. Denna egenskap definierar ASF beteende relaterat till jordbruk, och definieras som nedan:

| Värde | Namn                                 |
| ----- | ------------------------------------ |
| 0     | Ingen                                |
| 1     | JordbrukPausedByDefault              |
| 2     | AvstängningJordbruksavslutningFärdig |
| 4     | SendOnFarmingAvslutad                |
| 8     | JordbrukPrioriteringKöbara           |
| 16    | SkipÅterbetalningsbara spel          |
| 32    | SkipUnplayedGames                    |
| 64    | AktiveraRiskyCardsDiscovery          |
| 256   | AutoUnpackBoosterPacks               |

Observera att denna egenskap är `flaggor` fält, därför är det möjligt att välja valfri kombination av tillgängliga värden. Kolla in **[json mapping](#json-mapping)** om du vill veta mer. Not enabling any of flags results in `None` option.

Alla alternativ beskrivs nedan.

`JordbrukPausedByDefault` definierar ursprungligt tillstånd för `kortFarmer` modulen. Normalt kommer bot att starta jordbruk automatiskt när den startas, antingen på grund av `Aktiverat` eller `starta` -kommandot. Använda `JordbrukPausedByDefault` kan användas om du vill manuellt `återuppta` automatisk odlingsprocess, till exempel eftersom du vill använda `spela` hela tiden och aldrig använda automatiska `kortFarmer` modul - detta fungerar exakt samma som `paus` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

`ShutdownOnFarmingFinished` låter dig stänga bot när den är klar med jordbruk. Normalt ASF är "ockupera" ett konto för hela tiden av processen är aktiv. När kontot är gjort med jordbruk, ASF regelbundet kontrollerar det (varje `IdleFarmingPeriod` timmar), om kanske några nya spel med ångkort lades under tiden, så att den kan återuppta denna redovisning utan att behöva starta om processen. Detta är användbart för de flesta människor, eftersom ASF automatiskt kan återuppta jordbruket när det behövs. Men du kanske faktiskt vill stoppa processen när det ges konto är fullt odlad, kan du uppnå det genom att använda denna flagga. När detta är aktiverat fortsätter ASF med att logga ut när kontot är fullt, vilket innebär att det inte kommer att kontrolleras eller ockuperas med jämna mellanrum. Du bör själv bestämma om du föredrar ASF att arbeta på given bot instans för hela tiden, eller om ASF kanske borde stoppa det när jordbruksprocessen är klar.

Detta alternativ gör det mest vettigt att kombineras med `avstängningMöjlig`, så när alla konton stoppas, ASF kommer att stänga också, sätta din maskin i vila och låta dig schemalägga andra åtgärder, såsom sömn eller avstängning i samma ögonblick som sista kortet droppar.

`SendOnFarmingFinished` låter dig automatiskt skicka ånghandel som innehåller allt som odlats upp till denna punkt till användaren med `Master` -behörighet, vilket är mycket bekvämt om du inte vill bry dig om affärer själv. Det här alternativet fungerar som kommandot `loot` , tänk därför på att det kräver användare med `Master` behörighet, du kan också behöva en giltig `SteamTradeToken`, samt att använda ett konto som är berättigat till handel i första hand. Förutom att initiera `loot` efter avslutad jordbruk, ASF kommer också att initiera `loot` på varje ny objekt anmälan (när det inte gården), och efter att ha avslutat varje handel som resulterar i nya objekt (alltid) när detta alternativ är aktivt. Detta är särskilt användbart för att "vidarebefordra" objekt som mottagits från andra personer till vårt konto. Vanligtvis vill du använda **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** tillsammans med denna funktion, även om det inte är ett krav om du har för avsikt att hantera 2FA bekräftelser manuellt i rätt tid.

`FarmPriorityQueueOnly` definierar om ASF ska överväga för automatisk odling endast appar som du själv lagt till prioriterade jordbrukskö tillgänglig med `fq` **[kommandon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. När det här alternativet är aktiverat, kommer ASF att hoppa över alla `appID` som saknas i listan, effektivt så att du kan körsbär-plocka spel för automatisk ASF jordbruk. Tänk på att om du inte lade till några spel till kön då ASF kommer att agera som om det finns något att odla på ditt konto.

`SkipÅterbetalbara spel` definierar om ASF ska hoppa över spel som fortfarande återbetalas från automatisk odling. Ett återbetalningsbart spel är ett spel som du köpt under de senaste 2 veckorna genom Steams butik och som du inte har spelat längre än 2 timmar än, som angivits på **[Steam återbetalar](https://store.steampowered.com/steam_refunds)** sidan. Som standard, ASF ignorerar Steam återbetalningspolicy helt och gårdar allt, som de flesta människor skulle förvänta sig. Du kan dock använda denna flagga om du vill se till att ASF inte kommer att odla något av dina återbetalningsbara spel för tidigt, så att du kan utvärdera dessa spel själv och återbetala om det behövs utan att oroa ASF påverkar speltiden negativt. Observera att om du aktiverar detta alternativ så kommer spel som du köpt från Steams butik inte att odlas av ASF i upp till 14 dagar sedan datumet har lösts in, som kommer att visa som ingenting att odla om ditt konto inte äger något annat.

`SkipUnplayedGames` definierar om ASF skulle hoppa över spel som du inte startade ännu. Ospelat spel i detta sammanhang innebär att du har exakt ingen speltid inspelad för det på Steam. Om du använder den här flaggan, kommer sådana spel att hoppa över tills Steam registrerar någon speltid för dem. Detta gör att du kan kontrollera bättre vilka spel ASF är berättigade till gård, hoppa över de som du inte har en chans att prova ännu, hålla utvalda Steam-funktioner mer användbara - som att föreslå ospelade spel att spela.

`EnableRiskyCardsDiscovery` möjliggör ytterligare reservationer som utlöser när ASF inte kan ladda en eller flera av märkessidor och därför inte kan hitta spel tillgängliga för jordbruk. I synnerhet kan vissa konton med massiva mängder kortdroppar orsaka en situation där laddning av märkessidor inte längre är möjlig (på grund av overhead), och dessa konton är omöjliga för jordbruket enbart för att vi inte kan ladda den information som bygger på vilken vi kan starta processen. För dessa handfulla fall, detta alternativ tillåter alternativ algoritm som ska användas, som använder en kombination av boosters möjligt att tillverka och booster paket kontot är berättigat till, För att hitta potentiellt tillgängliga spel att vila, sedan spendera alltför mycket resurser för att verifiera och hämta nödvändig information, och försöker starta processen för jordbruk på begränsad mängd data och information för att så småningom nå en situation när badge sida laddar och vi kommer att kunna använda normala tillvägagångssätt. Observera att när denna reserv används, ASF fungerar endast med begränsad data, Därför är det helt normalt för ASF att hitta mycket mindre droppar än i verkligheten - andra droppar kommer att finnas i senare skede av jordbruksprocessen.

Detta alternativ kallas "riskabelt" av en mycket god anledning - det är extremt långsam och kräver betydande resurser (inklusive nätverksförfrågningar) för drift, därför är det **rekommenderas inte** att vara aktiverad, och särskilt på lång sikt. Du bör endast använda det här alternativet om du tidigare fastställt att ditt konto lider av att inte kunna ladda märkessidor och ASF inte kan hantera det, alltid misslyckas med att ladda nödvändig information för att starta processen. Även om vi gjorde vårt bästa för att optimera processen så mycket som möjligt, det är fortfarande möjligt för detta alternativ att slå tillbaka, och det kan orsaka oönskade resultat, såsom tillfälliga och kanske till och med permanenta förbud från Steam-sidan för att skicka för många förfrågningar och annars orsaka overhead på Steam-servrar. Därför varnar vi dig i förväg och vi erbjuder detta alternativ med absolut inga garantier, du använder det på egen risk.

`AutoUnpackBoosterPacks` kommer automatiskt att packa upp alla boosterpaket när du får avisering om nya artiklar. Detta gör att du kan omedelbart förvärva ytterligare kort droppar, vilket kan vara önskvärt scenario särskilt i kombination med andra alternativ (e. . `SteamTradeMatcher` eller `klara typerToSend`).

---

### `SpelasSpelasmedanIdle`

`ImmutableHashSet<uint>` -typ med standardvärdet för att vara tomt. Om ASF inte har något att odla det kan spela dina angivna ångspel (`appIDs`) istället. Att spela spel på ett sådant sätt ökar dina "timmar spelade" av dessa spel, men inget annat än det. För att denna funktion ska fungera korrekt, ditt Steam-konto **måste** äga en giltig licens för alla `appIDs` som du specificerar här, detta inkluderar F2P spel också. Den här funktionen kan aktiveras samtidigt med `CustomGamePlayedWhileIdle` för att spela dina valda spel medan du visar anpassad status i Steam-nätverket, men i detta fall, som i `CustomGamePlayedWhileFarming` fall, är den faktiska visningsordern inte garanterad. Observera att Steam tillåter ASF att endast spela upp till `32` `appIDs` totalt, därför kan du bara lägga så många spel i denna fastighet.

---

### `Spelenhetstyp`

`ushort` typ med standardvärdet `1`. Denna egenskap kan aktivera ytterligare funktioner online på Steam-plattformen, och definieras som nedan:

| Värde | Namn          | Beskrivning                   |
| ----- | ------------- | ----------------------------- |
| 1     | Standarddator | Inget specialläge, standard   |
| 544   | SteamDeck     | Presentera sig som Steam Deck |

Den underliggande `EGamingDeviceType` typen som denna egenskap är baserad på innehåller fler tillgängliga värden, Men så vitt vi vet har de ingen som helst effekt från och med i dag, därför har de skurits för synlighet.

Om du inte är säker på hur du ställer in denna egenskap, lämna den med standardvärdet `1`.

---

### `TimmarUntilCardDrops`

`byte` typ med standardvärdet `3`. Denna egenskap definierar om kontot har kort droppar begränsade, och om ja, för hur många inledande timmar. Begränsade kortdroppar innebär att kontot inte får några kortdroppar från givet spel förrän spelet spelas i minst `timmarUntilCardDrops` timmar. Tyvärr finns det inget magiskt sätt att upptäcka det, så ASF förlitar sig på dig. Denna egenskap påverkar **[kortodlingsalgoritm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** som kommer att användas. Ställa in denna fastighet korrekt kommer att maximera vinsten och minimera tiden som krävs för kort som ska odlas. Kom ihåg att det inte finns något självklart svar om du ska använda ett eller annat värde, eftersom det helt beror på ditt konto. Det verkar som om äldre konton som aldrig har begärt återbetalning har obegränsat kort droppar, så att de ska använda ett värde av `0`, medan nya konton och de som bad om återbetalning har begränsat kort droppar med ett värde av `3`. Detta är dock bara teori, och bör inte tas som en regel. Standardvärdet för den här egenskapen fastställdes baserat på "mindre ont" och majoriteten av användningsfall.

---

### `Lootable-typer`

`ImmutableHashSet<byte>` typ med standardvärdet `1, 3, 5` ångobjekttyper. Denna egenskap definierar ASF beteende vid plundring - båda manuellt, med ett **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, samt automatisk en, genom en eller flera konfigurationsegenskaper. ASF kommer att säkerställa att endast objekt från `LootableTypes` kommer att inkluderas i ett handelserbjudande. därför kan du välja vad du vill ta emot i ett handelserbjudande som skickas till dig.

| Värde | Namn               | Beskrivning                                                          |
| ----- | ------------------ | -------------------------------------------------------------------- |
| 0     | Okänd              | Varje typ som inte passar in i något av nedanstående                 |
| 1     | BoosterPack        | Boosterpaket som innehåller 3 slumpmässiga kort från ett spel        |
| 2     | Emoticon           | Emoticon att använda i Steam Chat                                    |
| 3     | FoilTradingCard    | Foil variant av `TradingCard`                                        |
| 4     | Profilbakgrund     | Profilbakgrund att använda på din Steam-profil                       |
| 5     | TradingCard        | Steam-handelskort, som används för att tillverka märken (icke-folie) |
| 6     | SteamGems          | Steam-pärlor som används för att tillverka boosters, säckar ingår    |
| 7     | Försäljningsobjekt | Särskilda föremål som delas ut under Steam-försäljningen             |
| 8     | Förbrukningsvaror  | Speciella förbrukningsartiklar som försvinner efter att de använts   |
| 9     | Profilmodifierare  | Specialobjekt som kan ändra utseendet på Steam-profilen              |
| 10    | Klistermärke       | Speciella föremål som kan användas på Steam-chatten                  |
| 11    | ChatEffect         | Speciella föremål som kan användas på Steam-chatten                  |
| 12    | MiniProfilbakgrund | Särskild bakgrund för Steam-profil                                   |
| 13    | AvatarProfilram    | Särskild avatar ram för Steam-profil                                 |
| 14    | AnimatedAvatar     | Speciell animerad avatar för Steam-profil                            |
| 15    | Tangentbordskinn   | Speciellt tangentbordskal för Steam-däck                             |
| 16    | StartupVideo       | Speciell startvideo för Steam-däck                                   |

Observera att oavsett inställningarna ovan, ASF kommer endast be om **[Steam-community-objekt](https://steamcommunity.com/my/inventory/#753_6)** (`appID` av 753, `contextID` av 6), så alla spelföremål, gåvor och likaså utesluts från handelserbjudandet per definition.

Standard ASF inställning är baserad på den vanligaste användningen av botten, med plundring endast booster paket och kort handel (inklusive folier). Egenskapen som definieras här kan du ändra detta beteende på vilket sätt som helst som tillfredsställer dig. Tänk på att alla typer som inte är definierade ovan kommer att visas som `Okänd` -typ, vilket är särskilt viktigt när Valve släpper några nya Steam-objekt, som kommer att markeras som `Unknown` av ASF också, tills den har lagts till här (i den framtida utgåvan). Det är därför det i allmänhet inte rekommenderas att inkludera `Okänt` typ i din `LootableTypes`, om du inte vet vad du gör, och du förstår också att ASF kommer att skicka hela ditt lager i ett byteserbjudande om Steam-nätverket bryts igen och rapporterar alla dina objekt som `Okänt`. Mitt starka förslag är att inte inkludera `Okänt` i `LootableTypes`, även om du förväntar dig att plundra allt (annat).

---

### `Maskinnamn`

`sträng` typ med standardvärdet `null`. ASF kommer att använda den här egenskapen när du loggar in på Steam-nätverket, som kan användas för anpassning när det gäller exakt hur Steam kommer att visa ASF maskin och session, e. . när du visar enheter som är inloggade i **[här](https://store.steampowered.com/account/authorizeddevices)**.

ASF innehåller några speciella variabler som du kan använda i din text. `{0}` kommer att ersättas av maskinnamn som anges av ditt operativsystem, `{1}` kommer att ersättas av ASF:s publika identifierare, medan `{2}` kommer att ersättas av ASF:s version.

Om du inte vet vad du gör, bör du hålla det med standardvärdet `null`. I detta fall kommer ASF att besluta internt om rätt värde, vilket är `{0} ({1}/{2})` från och med idag. Tänk på att detta bara är ett förslag om att Steam-nätverket kan, eller inte, respektera till fullo.

---

### `Matchbara typer`

`ImmutableHashSet<byte>` typ med standardvärdet `5` Steam-objekttyper. Den här egenskapen definierar vilka Steam-objekttyper som tillåts att matchas när `SteamTradeMatcher` -alternativet i `TradingPreferences` är aktiverat. Typer definieras som nedan:

| Värde | Namn               | Beskrivning                                                          |
| ----- | ------------------ | -------------------------------------------------------------------- |
| 0     | Okänd              | Varje typ som inte passar in i något av nedanstående                 |
| 1     | BoosterPack        | Boosterpaket som innehåller 3 slumpmässiga kort från ett spel        |
| 2     | Emoticon           | Emoticon att använda i Steam Chat                                    |
| 3     | FoilTradingCard    | Foil variant av `TradingCard`                                        |
| 4     | Profilbakgrund     | Profilbakgrund att använda på din Steam-profil                       |
| 5     | TradingCard        | Steam-handelskort, som används för att tillverka märken (icke-folie) |
| 6     | SteamGems          | Steam-pärlor som används för att tillverka boosters, säckar ingår    |
| 7     | Försäljningsobjekt | Särskilda föremål som delas ut under Steam-försäljningen             |
| 8     | Förbrukningsvaror  | Speciella förbrukningsartiklar som försvinner efter att de använts   |
| 9     | Profilmodifierare  | Specialobjekt som kan ändra utseendet på Steam-profilen              |
| 10    | Klistermärke       | Speciella föremål som kan användas på Steam-chatten                  |
| 11    | ChatEffect         | Speciella föremål som kan användas på Steam-chatten                  |
| 12    | MiniProfilbakgrund | Särskild bakgrund för Steam-profil                                   |
| 13    | AvatarProfilram    | Särskild avatar ram för Steam-profil                                 |
| 14    | AnimatedAvatar     | Speciell animerad avatar för Steam-profil                            |
| 15    | Tangentbordskinn   | Speciellt tangentbordskal för Steam-däck                             |
| 16    | StartupVideo       | Speciell startvideo för Steam-däck                                   |

Naturligtvis, typer som du bör använda för den här egenskapen inkluderar vanligtvis endast `2`, `3`, `4` och `5`, eftersom endast dessa typer stöds av STM. ASF innehåller rätt logik för att upptäcka raritet objekt, därför är det också säkert att matcha uttryckssymboler eller bakgrunder, som ASF kommer att överväga rättvist endast de objekt från samma spel och typ, som också delar samma sällsynthet.

Observera att **ASF inte är en handelsbot** och **inte kommer att bry sig om marknadspriset**. Om du inte anser att objekt av samma sällsynthet från samma uppsättning är samma pris-klokt, då detta alternativ är INTE för dig. Utvärdera gärna två gånger om du förstår och instämmer i detta uttalande innan du bestämmer dig för att ändra denna inställning.

Om du inte vet vad du gör, bör du hålla det med standardvärdet `5`.

---

### `OnlineFlaggor`

`ushort flaggor` typ med standardvärdet `0`. Den här egenskapen fungerar som tillägg till **[`OnlineStatus`](#onlinestatus)** och anger ytterligare online-närvarofunktioner som meddelas till Steam-nätverket. Kräver **[`OnlineStatus`](#onlinestatus)** annat än `Offline`och definieras som nedan:

| Värde | Namn                  | Beskrivning                                       |
| ----- | --------------------- | ------------------------------------------------- |
| 0     | Ingen                 | Inga speciella online-närvaroflaggor, standard    |
| 2     | InJoinableGame        | Klienten är i joinable spel                       |
| 8     | FjärrspelaTillsammans | Klienten använder fjärrspel tillsammans sessionen |
| 256   | ClientTypeWeb         | Klienten använder webbgränssnittet                |
| 512   | KlienttypMobil        | Kunden använder mobilappen                        |
| 1024  | ClientTypeTenfoot     | Klienten använder stor bild                       |
| 2048  | ClientTypeVR          | Klienten använder VR-headset                      |

Observera att denna egenskap är `flaggor` fält, därför är det möjligt att välja valfri kombination av tillgängliga värden. Kolla in **[json mapping](#json-mapping)** om du vill veta mer. Not enabling any of flags results in `None` option.

Den underliggande `EPersonaStateFlag` typen som denna egendom är baserad på innehåller fler tillgängliga flaggor, Men så vitt vi vet har de ingen som helst effekt från och med i dag, därför har de skurits för synlighet.

Om du inte är säker på hur du ställer in denna egenskap, lämna den med standardvärdet `0`.

---

### `OnlineStatus`

`byte` typ med standardvärdet `1`. Den här egenskapen anger Steam-gemenskapsstatus som boten kommer att meddelas med efter inloggning till Steam-nätverket. För närvarande kan du välja en av nedanstående status:

| Värde | Namn               |
| ----- | ------------------ |
| 0     | Offline            |
| 1     | Online             |
| 2     | Upptagen           |
| 3     | Borta              |
| 4     | Snooza             |
| 5     | Ser utsikt-toTrade |
| 6     | UtseendeToPlay     |
| 7     | Osynlig            |

`Offline` -status är extremt användbar för primära konton. Som du borde veta, jordbruk ett spel faktiskt visar din ångstatus som "Spela spel: XXX", vilket kan vara vilseledande för dina vänner, förvirra dem att du spelar ett spel medan du faktiskt bara odla det. Att använda `Offline` status löser problemet - ditt konto kommer aldrig att visas som "in-game" när du odlar ångkort med ASF. Detta är möjligt tack vare det faktum att ASF inte behöver logga in i Steam-gemenskapen för att fungera korrekt, så vi spelar i själva verket dessa spel, anslutna till Steam-nätverket, men utan att meddela vår online-närvaro alls. Tänk på att spelade spel med offline-status fortfarande kommer att räknas mot din speltid och visa som "nyligen spelade" på din profil.

Dessutom är denna funktion också viktig om du vill ta emot meddelanden och olästa meddelanden när ASF körs, utan att hålla Steam-klienten öppen samtidigt. Detta beror på att ASF fungerar som en Steam-klient själv, och om ASF skulle vilja det eller inte, Steam sänder alla dessa meddelanden och andra händelser till den. Detta är inget problem om du har både ASF och din egen Steam-klient igång, eftersom båda klienterna får exakt samma händelser. Men om bara ASF körs kunde Steam-nätverket markera vissa händelser och meddelanden som "levererade", trots att din traditionella Steam-klient inte får det på grund av att du inte är närvarande. Offline status löser också detta problem, eftersom ASF aldrig anses för några gemenskapshändelser i detta fall, så alla olästa meddelanden och andra händelser kommer att markeras som olästa när du kommer tillbaka.

It's important to note that ASF running on `Offline` mode will **not** be able to receive commands in usual Steam chat way, as the chat, as well as entire community presence is in fact, entirely offline. En lösning på detta problem är att använda `Osynligt` -läge istället som fungerar på ett liknande sätt (inte exponera status), men behåller möjligheten att ta emot och svara på meddelanden (så även en potential att avfärda meddelanden och olästa meddelanden som anges ovan). `Osynligt` -läge är det mest förnuftiga på alt-konton som du inte vill avslöja (status-wise), men ändå kunna skicka kommandon till.

Det finns dock en fångst med `Osynligt` -läge - det går inte bra med primära konton. Detta beror på att **alla** Steam-sessioner som för närvarande är online **exponerar** status, även om ASF själv inte gör det. Detta orsakas av den nuvarande begränsningen/buggen i Steam-nätverket som inte är möjligt att åtgärda på ASF-sidan, så om du vill använda `Osynligt` -läge måste du också se till att **alla** andra sessioner till samma konto använder `Osynligt` -läge också. Detta kommer att vara fallet på alt konton där ASF förhoppningsvis är den enda aktiva sessionen, men på primära konton kommer du nästan alltid föredra att visa som `Online` för dina vänner, döljer endast ASF-aktivitet, och i detta fall `Osynligt` -läge kommer att vara helt värdelöst för dig (vi rekommenderar att använda `Offline` -läge istället). Förhoppningsvis kommer denna begränsning/bugg så småningom att lösas i framtiden av Valve, men jag skulle inte förvänta mig att det händer när som helst snart...

Om du är osäker på hur du ställer in denna egenskap, det rekommenderas att använda ett värde av `0` (`Offline`) för primära konton, och standard `1` (`Online`) annars.

---

### `Lösenordsformat`

`byte` typ med standardvärdet `0` (`Oformaterad`). Den här egenskapen definierar formatet för egenskapen `SteamPassword` och stöder för närvarande värden som anges i säkerhetsavsnittet **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** Du bör följa instruktionerna som anges där, eftersom du måste se till att egenskapen `SteamPassword` verkligen innehåller lösenord i matchande `PasswordFormat`. Med andra ord när du ändrar `PasswordFormat` så ska ditt `SteamPassword` vara **redan** i det formatet, inte bara syftar till att vara. Om du inte vet vad du gör, bör du behålla det med standardvärdet `0`.

Om du bestämmer dig för att ändra `PasswordFormat` på en bot som redan har loggat in i Steam-nätverket minst en gång, Det är möjligt att du får en gång dekryptera fel på nästa botens start - detta orsakas av det faktum att `PasswordFormat` också används när det gäller automatisk kryptering/dekryptering av känsliga egenskaper i `Bot. b` databasfil. Du kan säkert ignorera detta fel, eftersom ASF kommer att kunna återhämta sig från denna situation på egen hand. Om det sker på ständig basis dock, t.ex. varje omstart, bör det undersökas.

---

### `LösningInställningar`

`byte flaggor` typ med standardvärdet `0`. Denna egenskap definierar ASF beteende när du löser in cd-nycklar, och definieras som nedan:

| Värde | Namn                                  | Beskrivning                                                                                                                         |
| ----- | ------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Ingen                                 | Inga speciella inlösande inställningar, standard                                                                                    |
| 1     | Vidarebefordran                       | Vidarebefordra nycklar som inte är tillgängliga att lösa in till andra robotar                                                      |
| 2     | Distribuerar                          | Fördela alla nycklar mellan sig och andra robotar                                                                                   |
| 4     | KeepMissingGames                      | Håll nycklarna till (potentiellt) saknade spel när du vidarebefordrar dem, vilket lämnar dem oanvända                               |
| 8     | AntagningWalletKeyOnBadActivationCode | Anta att `BadActivationCode` -nycklar är lika med `CannotRedeemCodeFromClient`och försök därför att lösa in dem som plånboksnycklar |

Observera att denna egenskap är `flaggor` fält, därför är det möjligt att välja valfri kombination av tillgängliga värden. Kolla in **[json mapping](#json-mapping)** om du vill veta mer. Not enabling any of flags results in `None` option.

`Vidarebefordran` kommer att få bot att vidarebefordra en nyckel som inte går att lösa in, till en annan ansluten och inloggad bot som saknar just det spelet (om möjligt att kontrollera). Den vanligaste situationen är vidarebefordran `redanKöpt` spel till en annan bot som saknas just det spelet, men detta alternativ omfattar också andra scenarier, såsom `görNotOwnRequiredApp`, `RateLimited` eller `Begränsat land`.

`Distribuera` kommer att få bot att distribuera alla mottagna nycklar mellan sig och andra botar. Detta innebär att varje bot kommer att få en enda nyckel från satsen. Vanligtvis används detta endast när du löser in många nycklar för samma spel, och du vill jämnt fördela dem bland dina botar, i motsats till att lösa in nycklar för olika olika spel. Denna funktion är meningslös om du löser in endast en nyckel i en enda `lösa in` åtgärd (eftersom det inte finns några extra nycklar att distribuera).

`KeepMissingGames` kommer att få bot att hoppa över `Vidarebefordra` när vi inte kan vara säkra på om nyckeln som löses in faktiskt ägs av vår bot eller inte. Detta innebär i princip att `Vidarebefordran` endast kommer att tillämpa **** till `redanKöpta` nycklar, istället för att täcka även andra fall som `görNotOwnRequiredApp`, `RateLimited` eller `RestrictedCountry`. Vanligtvis vill du använda det här alternativet på primärt konto, för att säkerställa att nycklar som löses in på den inte vidarebefordras ytterligare om din bot till exempel blir tillfälligt `RateLimited`. Som du kan gissa från beskrivningen, detta fält har absolut ingen effekt om `Vidarebefordran` inte är aktiverad.

`AntagningWalletKeyOnBadActivationCode` kommer att orsaka `BadActivationCode` nycklar att behandlas som `CannotRedeemCodeFromClient`, och därför resultera i ASF försöker lösa in dem som plånboksnycklar. Detta behövs eftersom Steam kan meddela plånboksnycklar som `BadActivationCode` (och inte `CannotRedeemCodeFromClient` som den användes för), vilket resulterar i ASF aldrig försöker lösa in dem. Vi rekommenderar dock **mot** att använda denna inställning, som det kommer att resultera i ASF försöker lösa in varje ogiltig nyckel som en plånbokskod, vilket resulterar i överdriven mängd (potentiellt ogiltiga) förfrågningar som skickats till Steam-tjänsten, med alla potentiella konsekvenser. Istället, vi rekommenderar att använda `ForceAssumeWalletKey` **[`Redeem^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** läge samtidigt medvetet lösa in plånboksnycklar, som kommer att aktivera den nödvändiga workaround endast när det krävs, efter behov.

Aktiverar både `Vidarebefordran` och `Distribuera` kommer att lägga till distribuerande funktion ovanpå vidarebefordran en, vilket gör att ASF försöker lösa in en nyckel på alla robotar först (framåt) innan du går till nästa (fördelning). Vanligtvis vill du endast använda det här alternativet när du vill att `Vidarebefordrar`, men med förändrat beteende att byta bot på nyckel som används, istället för att alltid gå i ordning med varje nyckel (som skulle vara `vidarebefordra` ensam). Detta beteende kan vara fördelaktigt om du vet att majoriteten eller alla dina nycklar är knutna till samma spel, eftersom i denna situation `Vidarebefordra` ensam skulle försöka lösa in allt på en bot först (vilket är vettigt om dina nycklar är för unika spel), och `Vidarebefordran` + `Distribuera` kommer att slå bot på nästa nyckel, "fördela" uppgiften att lösa in ny nyckel på en annan bot än den ursprungliga (vilket är vettigt om nycklar är för samma spel, hoppar över ett meningslöst försök per nyckel).

Den faktiska robotar ordning för alla de inlösande scenarier är alfabetiskt, exklusive robotar som är otillgängliga (inte anslutna, stoppas eller likaså). Tänk på att det finns en timgräns per IP och per konto för att lösa in försök, och varje lösen försök som inte slutade med `OK` bidrar till misslyckade försök. ASF kommer att göra sitt bästa för att minimera antalet `redan köpta` misslyckanden, t.ex. genom att försöka undvika vidarebefordra en nyckel till en annan bot som redan äger just det spelet, men det är inte alltid garanterat att fungera på grund av hur Steam hanterar licenser. Genom att använda inlösande flaggor som `Vidarebefordran` eller `Distribuera` kommer alltid att öka din sannolikhet att träffa `RateLimited`.

Kom också ihåg att du inte kan vidarebefordra eller distribuera nycklar till robotar som du inte har tillgång till. Detta bör vara uppenbart, men se till att du är minst `Operator` av alla robotar du vill inkludera i din inlösningsprocess, till exempel med `status ASF` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `Fjärrkommunikation`

`byte flaggor` typ med standardvärdet `3`. Denna egenskap definierar per bot ASF beteende när det gäller kommunikation med fjärrkontroll, tredje part tjänster, och definieras som nedan:

| Värde | Namn              | Beskrivning                                                                                                                                                                                                                                                    |
| ----- | ----------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Ingen             | Ingen tillåten tredjepartskommunikation, vilket gör valda ASF-funktioner oanvändbara                                                                                                                                                                           |
| 1     | Ånggrupp          | Tillåter kommunikation med **[ASFs Steam-grupp](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                  |
| 2     | Publikationslista | Tillåter kommunikation med **[ASF:s STM-lista](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** för att listas, om användaren också har aktiverat `SteamTradeMatcher` i **[`TradingPreferences`](#tradingpreferences)** |

Observera att denna egenskap är `flaggor` fält, därför är det möjligt att välja valfri kombination av tillgängliga värden. Kolla in **[json mapping](#json-mapping)** om du vill veta mer. Not enabling any of flags results in `None` option.

Detta alternativ innehåller inte alla tredje parts kommunikation som erbjuds av ASF, bara de som inte är underförstådda av andra inställningar. Om du till exempel har aktiverat ASF:s automatiska uppdateringar kommer ASF att kommunicera med både GitHub (för nedladdningar) och vår server (för kontrollsummaverifiering), enligt din konfiguration. Likaså aktivera `MatchActively` i **[`TradingPreferences`](#tradingpreferences)** innebär kommunikation med vår server för att hämta listade botar, vilket krävs för den funktionaliteten.

Ytterligare förklaring på detta ämne finns i **[fjärrkommunikation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** sektionen. Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

### `SkickaTradePeriod`

`byte` typ med standardvärdet `0`. Den här fastigheten fungerar mycket likt `SendOnFarmingFinished` preferenser i `FarmingPreferences`, med en skillnad - i stället för att skicka handel när jordbruket görs, vi kan också skicka det varje `SendTradePeriod` timmar, oavsett hur mycket vi har kvar till gården. Detta är användbart om du vill `loot` dina alt-konton på vanlig basis istället för att vänta på att det ska slutföras. Standardvärdet för `0` inaktiverar den här funktionen, om du vill att din bot ska skicka dig handla e. . varje dag bör du sätta `24` här.

Vanligtvis vill du använda **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** tillsammans med denna funktion, även om det inte är ett krav om du har för avsikt att hantera 2FA bekräftelser manuellt i rätt tid. Om du inte är säker på hur du ställer in denna egenskap, lämna den med standardvärdet `0`.

---

### `SteamLogin`

`sträng` typ med standardvärdet `null`. Denna egenskap definierar din ånga-inloggning - den du använder för att logga in för att ånga. Förutom att definiera ångan inloggning här, du kan också behålla standardvärdet för `null` om du vill ange din ång-inloggning vid varje ASF-start istället för att sätta den i konfigurationen. Detta kan vara användbart för dig om du inte vill spara känslig data i konfigurationsfilen.

---

### `SteamMasterClanID`

`ulong` typ med standardvärdet `0`. Den här egenskapen definierar ånggruppssteamID som bot automatiskt ska gå med, inklusive gruppchatten. Du kan kontrollera steamID i din grupp genom att navigera till dess **[sida](https://steamcommunity.com/groups/archiasf)**, sedan lägga till `/memberslistxml? ml=1` till slutet av länken, så länken kommer att se ut som **[denna](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. Då kan du få steamID av din grupp från resultatet, det är i `<groupID64>` tagg. I ovanstående exempel skulle det vara `103582791440160998`. Förutom att försöka gå med i viss grupp vid start, boten kommer också automatiskt att acceptera gruppinbjudningar till denna grupp, vilket gör det möjligt för dig att bjuda in din bot manuellt om din grupp har ett privat medlemskap. Om du inte har någon grupp tillägnad dina robotar bör du behålla den här egenskapen med standardvärdet `0`.

---

### `SteamParentalkod`

`sträng` typ med standardvärdet `null`. Den här egenskapen definierar din ångföräldra-PIN. ASF kräver tillgång till resurser som skyddas av ångförälder, därför om du använder den funktionen, du bör ge ASF med föräldraupplåsnings PIN, så att den kan fungera normalt. Standardvärdet för `null` innebär att det inte behövs någon ångföräldra-kod för att låsa upp detta konto, och detta är förmodligen vad du vill om du inte använder ånga föräldrars funktionalitet.

Under begränsade omständigheter kan ASF också generera en giltig Steam-föräldrakod själv, även om det kräver överdriven mängd OS-resurser och ytterligare tid att slutföra, för att inte nämna att det inte är garanterat att lyckas, därför rekommenderar vi att inte lita på den funktionen och istället sätta giltig `SteamParentalCode` i konfigurationen för ASF att använda. Om ASF bestämmer att PIN krävs, och det kommer inte att kunna generera en på egen hand, kommer det att be dig om indata.

---

### `SteamPassword`

`sträng` typ med standardvärdet `null`. Denna egenskap definierar ditt ånglösenord - den du använder för att logga in för att ånga. Förutom att definiera ånglösenord här, du kan också behålla standardvärdet för `null` om du vill ange ditt ånglösenord vid varje ASF-start istället för att sätta det i konfigurationen. Detta kan vara användbart för dig om du inte vill spara känslig data i konfigurationsfilen.

---

### `SteamTradeToken`

`sträng` typ med standardvärdet `null`. När du har din bot på din vän lista, då bot kan skicka en handel till dig direkt utan att oroa om handel token, därför kan du lämna denna egenskap till standardvärdet `null`. Om du däremot bestämmer dig för att INTE ha din bot på din vänlista, då måste du generera och fylla en handel token som användaren som denna bot förväntar sig att skicka affärer till. Med andra ord denna egenskap bör fyllas med bytessymbol för kontot som är definierat med `Master` behörighet i `SteamUserPermissions` av **denna** bot instans.

För att hitta din token, som inloggad användare med `Master` behörighet, navigera **[här](https://steamcommunity.com/my/tradeoffers/privacy)** och ta en titt på din handels-URL. Den token vi letar efter är gjord av 8 tecken efter `&token=` del i din handels-URL. Du bör kopiera och sätta dessa 8 tecken här, som `SteamTradeToken`. Inkludera inte hela handels-URL, ingen `&token=` del, bara token själv (8 tecken).

---

### `Behörigheter för SteamUser`

`ImmutableDictionary<ulong, byte>` typ med standardvärdet för att vara tomt. Den här egenskapen är en ordboksegenskap som kartor ger Steam-användare identifierad av hans 64-bitars steam ID, till `byte` nummer som anger hans behörighet i ASF instans. För närvarande tillgängliga bot behörigheter i ASF definieras som:

| Värde | Namn          | Beskrivning                                                                                                                                                                                          |
| ----- | ------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Ingen         | Ingen särskild behörighet, detta är främst ett referensvärde som tilldelas ång-ID saknas i denna ordbok - det finns inget behov av att definiera någon med denna behörighet                          |
| 1     | FamilySharing | Ger minimal åtkomst för familjedelningsanvändare. Än en gång, detta är främst ett referensvärde eftersom ASF är kapabel att automatiskt upptäcka ång-ID som vi tillät för att använda vårt bibliotek |
| 2     | Operatör      | Ger grundläggande tillgång till givna bot instanser, främst lägga till licenser och lösa in nycklar                                                                                                  |
| 3     | Mästare       | Ger full tillgång till given bot instans                                                                                                                                                             |

Kort sagt, den här egenskapen låter dig hantera behörigheter för givna användare. Behörigheter är viktiga främst för att få tillgång till ASF **[kommandon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, men också för att aktivera många ASF-funktioner, till exempel att acceptera byten. Till exempel kanske du vill ange ditt eget konto som `Master`, och ge `Operatör` tillgång till 2-3 av dina vänner så att de enkelt kan lösa in nycklar till din bot med ASF, medan **inte** är berättigad. . för att stoppa det. Tack vare det kan du enkelt tilldela behörigheter till givna användare och låta dem använda din bot till några som anges av dig grad.

Vi rekommenderar att du anger exakt en användare som `Master`och valfritt belopp som `Operatörer` och nedan. Även om det är tekniskt möjligt att ställa in flera `Masters` och ASF kommer att fungera korrekt med dem, till exempel genom att acceptera alla sina affärer som skickas till botten, ASF kommer endast att använda en av dem (med lägsta ång-ID) för varje åtgärd som kräver ett enda mål, till exempel en `loot` begäran, så även fastigheter som `SendOnFarmingFinished` preferens i `FarmingPreferences` eller `SendTradePeriod`. Om du helt förstår dessa begränsningar, särskilt det faktum att `loot` begäran alltid kommer att skicka objekt till `Master` med lägsta ång-ID, oavsett `Master` som faktiskt körde kommandot, sedan kan du definiera flera användare med `Master` tillstånd här, men vi rekommenderar fortfarande ett enda master-system.

Det är trevligt att notera att det finns ytterligare ett tillstånd för `Ägare` som deklareras som `SteamOwnerID` global config egendom. Du kan inte tilldela `Ägare` behörighet till någon här, som `SteamUserPermissions` definierar endast behörigheter som är relaterade till bot instansen, och inte ASF som en process. För bot-relaterade uppgifter behandlas `SteamOwnerID` på samma sätt som `Master`, så att definiera din `SteamOwnerID` här är inte nödvändigt.

---

### `TradeCheckPeriod`

`byte` typ med standardvärdet `60`. Normalt hanterar ASF inkommande byteserbjudanden direkt efter att ha fått meddelande om en, men ibland på grund av Steam buggar det inte kan göra det på den tiden, och sådana handelserbjudanden förblir ignorerade tills nästa handel anmälan eller bot omstart sker, vilket kan leda till att affärer annulleras eller objekt som inte är tillgängliga vid detta senare tillfälle. Om denna parameter är satt till ett värde som inte är noll kommer ASF dessutom att kontrollera sådana utestående affärer varje `TradeCheckPeriod` minuter. Standardvärdet väljs med balans mellan ytterligare förfrågningar till ångservrar och förlora inkommande affärer i åtanke. Men om du bara använder ASF för att odla kort, och inte planerar att automatiskt bearbeta eventuella inkommande affärer, du kan ställa in den till `0` för att inaktivera denna funktion helt. Å andra sidan, om din bot deltar i offentliga [ASFs STM-listning](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) eller tillhandahåller andra automatiserade tjänster som en bytesbot du kanske vill minska denna parameter till `15` minuter eller så, för att bearbeta alla affärer i tid.

---

### `TradingPreferences`

`byte flaggor` typ med standardvärdet `0`. Denna egenskap definierar ASF beteende vid handel, och definieras som nedan:

| Värde | Namn                | Beskrivning                                                                                                                                                                                                      |
| ----- | ------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Ingen               | Inga speciella handelspreferenser, standard                                                                                                                                                                      |
| 1     | AccepteraDonationer | Accepterar affärer där vi inte förlorar något                                                                                                                                                                    |
| 2     | SteamTradeMatcher   | Deltar i **[STM](https://www.steamtradematcher.com)**-liknande affärer. Besök **[handel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** för mer information                    |
| 4     | MatchaAllt          | Kräver `SteamTradeMatcher` att ställas in, och i kombination med det - accepterar även dåliga affärer utöver bra och neutrala sådana                                                                             |
| 8     | DontAcceptBotTrades | Accepterar inte automatiskt `loot` avslut från andra bot instanser                                                                                                                                               |
| 16    | Aktivt              | Deltar aktivt i **[STM](https://www.steamtradematcher.com)**-liknande affärer. Besök **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** för mer info |

Observera att denna egenskap är `flaggor` fält, därför är det möjligt att välja valfri kombination av tillgängliga värden. Kolla in **[json mapping](#json-mapping)** om du vill veta mer. Not enabling any of flags results in `None` option.

För ytterligare förklaring av ASF handelslogik, och beskrivning av varje tillgänglig flagga, besök **[handel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** avsnitt.

---

### `Överföringsbara typer`

`ImmutableHashSet<byte>` typ med standardvärdet `1, 3, 5` ångobjekttyper. Denna egenskap definierar vilka Steam-objekttyper som kommer att anses för överföring mellan botar, under `överföring` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. ASF kommer att se till att endast objekt från `TransferableTypes` kommer att inkluderas i ett byteserbjudande, därför kan du välja vad du vill få i ett handelserbjudande som skickas till en av dina botar.

| Värde | Namn               | Beskrivning                                                          |
| ----- | ------------------ | -------------------------------------------------------------------- |
| 0     | Okänd              | Varje typ som inte passar in i något av nedanstående                 |
| 1     | BoosterPack        | Boosterpaket som innehåller 3 slumpmässiga kort från ett spel        |
| 2     | Emoticon           | Emoticon att använda i Steam Chat                                    |
| 3     | FoilTradingCard    | Foil variant av `TradingCard`                                        |
| 4     | Profilbakgrund     | Profilbakgrund att använda på din Steam-profil                       |
| 5     | TradingCard        | Steam-handelskort, som används för att tillverka märken (icke-folie) |
| 6     | SteamGems          | Steam-pärlor som används för att tillverka boosters, säckar ingår    |
| 7     | Försäljningsobjekt | Särskilda föremål som delas ut under Steam-försäljningen             |
| 8     | Förbrukningsvaror  | Speciella förbrukningsartiklar som försvinner efter att de använts   |
| 9     | Profilmodifierare  | Specialobjekt som kan ändra utseendet på Steam-profilen              |
| 10    | Klistermärke       | Speciella föremål som kan användas på Steam-chatten                  |
| 11    | ChatEffect         | Speciella föremål som kan användas på Steam-chatten                  |
| 12    | MiniProfilbakgrund | Särskild bakgrund för Steam-profil                                   |
| 13    | AvatarProfilram    | Särskild avatar ram för Steam-profil                                 |
| 14    | AnimatedAvatar     | Speciell animerad avatar för Steam-profil                            |
| 15    | Tangentbordskinn   | Speciellt tangentbordskal för Steam-däck                             |
| 16    | StartupVideo       | Speciell startvideo för Steam-däck                                   |

Observera att oavsett inställningarna ovan, ASF kommer endast be om **[Steam-community-objekt](https://steamcommunity.com/my/inventory/#753_6)** (`appID` av 753, `contextID` av 6), så alla spelföremål, gåvor och likaså utesluts från handelserbjudandet per definition.

Standard ASF inställning är baserad på den vanligaste användningen av botten, med överföring endast booster paket och kort handel (inklusive folier). Egenskapen som definieras här kan du ändra detta beteende på vilket sätt som helst som tillfredsställer dig. Tänk på att alla typer som inte är definierade ovan kommer att visas som `Okänd` -typ, vilket är särskilt viktigt när Valve släpper några nya Steam-objekt, som kommer att markeras som `Unknown` av ASF också, tills den har lagts till här (i den framtida utgåvan). Därför är det i allmänhet inte rekommenderat att inkludera `Okänt` -typ i din `TransferableTypes`, om du inte vet vad du gör, och du förstår också att ASF kommer att skicka hela ditt lager i ett byteserbjudande om Steam-nätverket bryts igen och rapporterar alla dina objekt som `Okänt`. Mitt starka förslag är att inte inkludera `Okänt` i `TransferableTypes`, även om du förväntar dig att överföra allt.

---

### `UseLoginKeys`

`Bool` typ med standardvärdet `true`. Den här egenskapen definierar om ASF ska använda inloggningsnycklar mekanism för detta Steam-konto. Inloggningsnycklar mekanism fungerar mycket lik den officiella Steam-klientens "kom ihåg mig" alternativ, vilket gör det möjligt för ASF att lagra och använda tillfälliga engångsnyckel för nästa inloggningsförsök, hoppar över ett behov av att tillhandahålla lösenord, Steam Guard eller 2FA-kod så länge vår inloggningsnyckel är giltig. Inloggningsnyckeln lagras i filen `BotName.db` och uppdateras automatiskt. Det är därför du inte behöver ange lösenord/SteamGuard/2FA kod efter att du loggat in framgångsrikt med ASF bara en gång.

Inloggningsnycklar används som standard för din bekvämlighet, så du behöver inte ange `SteamPassword`, SteamGuard eller 2FA kod (när du inte använder **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**) vid varje inloggning. Det är också överlägset alternativ eftersom inloggningsnyckeln endast kan användas en gång och inte avslöja ditt ursprungliga lösenord på något sätt. Exakt samma metod används av din ursprungliga Steam-klient, vilket sparar ditt kontonamn och inloggningsnyckel för ditt nästa inloggningsförsök, effektivt är samma sak som att använda `SteamLogin` med `UseLoginKeys` och tom `SteamPassword` i ASF.

Vissa människor kan dock vara oroliga även för denna lilla detalj, därför är detta alternativ tillgängligt här för dig om du vill se till att ASF inte kommer att lagra någon form av token som skulle tillåta återuppta föregående session efter stängningen, vilket kommer att resultera i fullständig autentisering är obligatoriskt vid varje inloggningsförsök. Inaktivera detta alternativ kommer att fungera exakt samma som att inte kontrollera "kom ihåg mig" i den officiella Steam-klienten. Om du inte vet vad du gör, bör du hålla det med standardvärdet `true`.

---

### `Användargränssnittsläge`

`byte` typ med standardvärdet `0`. Den här egenskapen anger användargränssnittsläge som roboten kommer att meddelas med efter inloggning till Steam-nätverket. Det kan påverka hur kontot är synligt, t.ex. på Steam-chatten om din närvaro tillåter det via `OnlineStatus`. För närvarande kan du välja ett av nedanstående lägen:

| Värde | Namn       | Beskrivning               |
| ----- | ---------- | ------------------------- |
| `0`   | VGUI       | Standard Steam-klientläge |
| `1`   | Tenfoot    | Stor bild läge            |
| `2`   | Mobil      | Steam mobilapp            |
| `3`   | Webb       | Webbläsarsession          |
| `5`   | MobileChat | Steam mobilchatt-app      |

Den underliggande `EUIMode` typ som denna egendom är baserad på innehåller mer tillgängliga värden, dock, Så vitt vi vet har de absolut ingen effekt från och med i dag, därför har de skurits för synlighet. Du kanske också är intresserad av att kontrollera `GamingDeviceType`, eftersom vissa ytterligare funktioner är aktiverade där.

Om du inte är säker på hur du ställer in denna egenskap, lämna den med standardvärdet `0`.

---

### `WebProxy`

`sträng` typ med standardvärdet `null`. Denna egenskap definierar en webbproxyadress som kommer att användas för bot-specifik intern http-relaterad kommunikation, särskilt till tjänster som `api. teampowered.com`, `steamcommunity.com` och `store.steampowered.com`. Om den inte är inställd, kommer ASF att använda global `WebProxy` inställning som anges ovan istället. Proxying ASF förfrågningar kan vara exceptionellt användbart för att kringgå olika typer av brandväggar, särskilt den stora brandväggen i Kina.

Den här egenskapen definieras som URI-sträng:

> En URI-sträng består av ett system (stöds: http/https/socks4/socks4a/socks5), en värd och en valfri port. Ett exempel på en komplett uri sträng är `"http://contoso.com:8080"`.

Om din proxy kräver användarautentisering måste du även konfigurera `WebProxyUsername` och/eller `WebProxyPassword`. Om det inte finns något sådant behov räcker det att bara inrätta denna egendom.

Om du behöver proxying intern Steam-nätverkskommunikation (CM) också, då bör du se till att konfigurera **[`SteamProtocols`](#steamprotocols)** botens egendom till ett värde som endast tillåter websocket transport, i. . ett värde av `4`, eftersom endast websockets stöds för proxying.

Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

### `WebProxyPassword`

`sträng` typ med standardvärdet `null`. Den här egenskapen definierar lösenordsfältet som används i grundläggande, digest, NTLM, och Kerberos autentisering som stöds av ett mål `WebProxy` maskin som ger proxy-funktionalitet. Om din proxy inte kräver användaruppgifter, finns det inget behov av att mata in något här. Använda detta alternativ är vettigt endast om `WebProxy` används också, eftersom det inte har någon effekt annars.

Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

### `WebProxyUsername`

`sträng` typ med standardvärdet `null`. Denna egenskap definierar användarnamn fält som används i grundläggande, digest, NTLM, och Kerberos autentisering som stöds av ett mål `WebProxy` maskin som ger proxy-funktionalitet. Om din proxy inte kräver användaruppgifter, finns det inget behov av att mata in något här. Använda detta alternativ är vettigt endast om `WebProxy` används också, eftersom det inte har någon effekt annars.

Om du inte har en anledning att redigera denna egenskap, bör du behålla det som standard.

---

## Fil struktur

ASF använder ganska enkel filstruktur.

```text
<unk> ─ 📁 config
<unk> <unk> ─ ASF. son
<unk> <unk> <unk> <unk> <unk> – ASF.db
<unk> <unk> <unk> <unk> – Bot1. son
<unk> <unk> ─ Bot1.db
<unk> <unk> <unk> ─ Bot2. son
˃ ─ Bot2.db
<unk> <unk> <unk> <unk> <unk> ─ ...
├── ArchiSteamFarm.dll
├── log.txt
└── ...
```

För att flytta ASF till en ny plats, till exempel en annan dator, räcker det med att flytta/kopiera `config` -katalogen ensam. och det är det rekommenderade sättet att göra någon form av "ASF-säkerhetskopior", eftersom du alltid kan ladda ner den återstående (program) delen från GitHub, men inte riskera att korrumpera interna ASF-filer, e. . genom en felaktig säkerhetskopia.

`log.txt` filen håller loggen som genereras av din senaste ASF-körning. Den här filen innehåller ingen känslig information och är extremt användbar när det gäller problem, kraschar eller helt enkelt som en information till dig vad som hände i senaste ASF körning. Vi kommer ofta att fråga om denna fil om du stöter på problem eller buggar. ASF hanterar automatiskt denna fil åt dig, men du kan ytterligare justera ASF **[loggning](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging)** -modulen om du är avancerad användare.

`config` -katalogen är den plats som har konfiguration för ASF, inklusive alla dess robotar.

`ASF.json` är en global ASF-konfigurationsfil. Denna konfiguration används för att specificera hur ASF beter sig som en process, som påverkar alla robotar och programmet själv. Du kan hitta globala egenskaper där, såsom ASF processägare, auto-uppdateringar eller felsökning.

`BotName.json` är en konfiguration av given bot instans. Denna konfiguration används för att ange hur given bot instans beter sig, därför är dessa inställningar specifika för att bot endast och inte delas mellan andra. Detta gör att du kan konfigurera robotar med olika inställningar och inte nödvändigtvis alla av dem arbetar på exakt samma sätt. Varje bot namnges med en unik identifierare, vald av dig i stället för `BotName`.

Förutom konfigurationsfiler använder ASF även `config` katalog för lagring av databaser.

`ASF.db` är en global ASF-databasfil. Den fungerar som en global beständig lagring och används för att spara olika uppgifter relaterade till ASF-processen, till exempel IP-adresser för lokala Steam-servrar. **Du bör inte redigera denna fil**.

`BotName.db` är en databas med given bot instans. Denna fil används för att lagra viktiga data om given bot instans i ihållande lagring, såsom inloggningsnycklar eller ASF 2FA. **Du bör inte redigera denna fil**.

`BotName.keys` är en speciell fil som kan användas för att importera nycklar till **[bakgrundsspel inlösare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. Det är inte obligatoriskt och inte genererat, men erkänt av ASF. Denna fil raderas automatiskt efter att nycklarna har importerats.

`BotName.maFile` är en speciell fil som kan användas för att importera **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**. Det är inte obligatoriskt och inte genererat, men erkänt av ASF om ditt `BotName` inte använder ASF 2FA ännu. Denna fil raderas automatiskt efter att ASF 2FA har importerats.

---

## JSON mappning

Varje konfigurationsegenskap har sin typ. Typ av egenskap definierar värden som är giltiga för den. Du kan bara använda värden som är giltiga för given typ - om du använder ogiltigt värde, då ASF kommer inte att kunna tolka din konfiguration.

**Vi rekommenderar starkt att använda ConfigGenerator för att generera konfigurationer** - den hanterar de flesta lågnivågrejer (såsom typvalidering) för dig, så du behöver bara mata in rätt värden, och du behöver inte heller förstå variabla typer som anges nedan. Detta avsnitt är främst för personer som genererar/redigerar konfigurationer manuellt, så att de vet vilka värden de kan använda.

Typer som används av ASF är infödda C# typer, som anges nedan:

---

`Bool` - Boolesk typ som endast accepterar `sanna` och `falska` värden.

Exempel: `"Aktiverad": true`

---

`byte` - Avsignerad byte typ, accepterar endast heltal från `0` till `255` (inklusive).

Exempel: `"ConnectionTimeout": 90`

---

`ushort` - Osignerad kort typ, accepterar endast heltal från `0` till `65535` (inklusive).

Exempel: `"WebLimiterDelay": 300`

---

`uint` - Osignerad heltalstyp, accepterar endast heltal från `0` till `4294967295` (inklusive).

---

`ulong` - Osignerad lång heltalstyp, accepterar endast heltal från `0` till `18446744073709551615` (inklusive).

Exempel: `"SteamMasterClanID": 103582791440160998`

---

`sträng` - Sträng typ, accepterar valfri sekvens av tecken, inklusive tom sekvens `""` och `null`. Töm sekvens och `null` värde behandlas samma av ASF, så det är upp till dina preferenser som du vill använda (vi håller oss till `null`).

Exempel: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MyAccountName"`

---

`Vägledning?` - Nullable UUID-typ, i JSON kodad som sträng. UUID är gjord av 32 hexadecimala tecken, i intervallet från `0` till `9` och `ett` till `f`. ASF accepterar olika giltiga format - gemener, versaler, med och utan bindestreck. Förutom giltiga UUID, eftersom denna fastighet är ogiltig, ett speciellt värde av `null` accepteras för att indikera brist på UUID att tillhandahålla.

Exempel: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`Oföränderlig lista<valueType>` - Oföränderlig samling (lista) av värden i angivet `värde typ`. I JSON definieras den som en samling av element i givet `värdeTyp`. ASF använder `lista` för att indikera att given egenskap stöder flera värden och att deras ordning kan vara relevant.

Exempel på `oföränderlig lista<byte>`: `"Jordbruksorder": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` - Oföränderlig samling (mängd) av unika värden i givet `värde typ`. I JSON definieras den som en samling av element i givet `värdeTyp`. ASF använder `HashSet` för att indikera att given egendom endast är meningsfull för unika värden och att deras ordning inte spelar någon roll, därför kommer det att medvetet ignorera eventuella dubbletter under parsning (om du råkade leverera dem ändå).

Exempel på `ImmutableHashSet<uint>`: `"Svartlista": [267420, 303700, 335590]`

---

`Oföränderlig ordbok<keyType, valueType>` - Oföränderlig ordbok (karta) som kartlägger en unik nyckel som anges i dess `nyckeltyp`, till värde som anges i dess `värdeTyp`. I JSON definieras det som ett objekt med nyckelvärdespar. Tänk på att `keyType` alltid citeras i detta fall, även om det är värdestyp som `ulong`. Det finns också ett strikt krav på att nyckeln ska vara unik över hela kartan, denna gång genomdrivet av JSON också.

Exempel på `oföränderlig ordbok<ulong, byte>`: `"SteamUserPermissions": { "76561198174813138": 3, "765611981748137": 1 }`

---

`flaggor` - Flaggor attribut kombinerar flera olika egenskaper till ett slutligt värde genom att tillämpa bitwise operationer. Detta gör att du kan välja en möjlig kombination av olika tillåtna värden samtidigt. Det slutliga värdet är uppbyggt som en summa av värden för alla möjliga alternativ.

Till exempel, ges följande definition:

| Värde | Namn  |
| ----- | ----- |
| 0     | Ingen |
| 1     | A     |
| 2     | B     |
| 4     | C     |

Det finns exakt 3 meningsfulla flaggor att slå på/av (`A`, `B`, `C`), och därför `8` möjliga giltiga kombinationer totalt:

| Slutligt värde | Aktiverade flaggor |
| -------------- | ------------------ |
| 0              | `Ingen`            |
| 1              | `A`                |
| 2              | `B`                |
| 3              | `A` + `B`          |
| 4              | `C`                |
| 5              | `A` + `C`          |
| 6              | `B` + `C`          |
| 7              | `A` + `B` + `C`    |

För att göra ovanstående möjligt måste därför varje enskild flagga per definition vara två. Det är därför ytterligare flagga i ovanstående exempel, `D`, skulle behöva bära värdet av `8` eller större.

Vanligtvis kommer grafiska verktyg att göra beräkningen för dig. Om du redigerar konfigurationer manuellt, du kan alltid använda kalkylatorn och helt enkelt lägga till underliggande värden för alla flaggor du vill aktivera - som i exempel ovan.

Exempel: `"SteamProtocols": 7` (som möjliggör flaggor med värdet `1`, `2` och `4`, som förklaras ovan)

---

## Kompatibilitetsmappning

På grund av JavaScript-begränsningar av att det inte går att serialisera enkla `ulong` fält i JSON när du använder webbaserade ConfigGenerator, `ulong` fält kommer att renderas som strängar med `s_` prefix i den resulterande konfigurationen. Detta inkluderar till exempel `"SteamOwnerID": 76561198006963719` som kommer att skrivas av vår ConfigGenerator som `"s_SteamOwnerID": "76561198006963719"`. ASF innehåller rätt logik för att hantera denna strängmappning automatiskt, så `s_` poster i dina konfigurationer är faktiskt giltiga och korrekt genererade. Om du genererar konfigurationer själv, rekommenderar vi att du håller dig till de ursprungliga `ulong` fälten om möjligt, men om du inte kan göra det, du kan också följa detta system och koda dem som strängar med `s_` prefix lagt till deras namn. Vi hoppas kunna lösa denna JavaScript-begränsning så småningom.

---

## Kompatibilitet för konfigurering

Det är högsta prioritet för ASF att förbli kompatibel med äldre konfigurationer. Som du redan vet behandlas de saknade konfigurationsegenskaperna samma som de skulle definieras med sina **standardvärden**. Därför, om ny konfigurationsegenskap införs i ny version av ASF, kommer alla dina konfigurationer förbli **kompatibla** med ny version, och ASF kommer att behandla den nya konfigurationsegenskapen som den skulle definieras med dess **standardvärde**. Du kan alltid lägga till, ta bort eller redigera konfigurationsegenskaper enligt dina behov.

Vi rekommenderar att endast begränsa definierade konfigurationsegenskaper till de som du vill ändra, eftersom detta sätt du automatiskt ärver standardvärden för alla andra, inte bara hålla din konfiguration ren utan också öka kompatibiliteten om vi beslutar att ändra ett standardvärde för egendom som du inte vill uttryckligen ställa in dig själv (e. . `WebLimiterDelay`).

På grund av ovan, ASF kommer automatiskt migrera/optimera dina konfigurationer genom att formatera dem och ta bort fält som har standardvärde. Du kan inaktivera detta beteende med `--no-config-migrera` **[-kommandoradsargumentet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** om du har en specifik anledning, till exempel tillhandahåller du skrivskyddade konfigurationsfiler och du vill inte att ASF ska ändra dem.

---

## Automatisk omladdning

ASF är medveten om konfigurationer som modifieras "on-the-fly" - tack vare det, ASF kommer automatiskt:
- Skapa (och starta, om det behövs) ny bot instans, när du skapar dess konfiguration
- Stoppa (om det behövs) och ta bort gamla bot instans, när du tar bort dess konfiguration
- Stoppa (och starta, om det behövs) någon bot instans, när du redigerar dess konfiguration
- Starta om (om det behövs) boten under nytt namn, när du byter namn på dess konfiguration

Allt ovanstående är transparent och kommer att göras automatiskt utan att behöva starta om programmet, eller döda andra (opåverkade) bot instanser.

Utöver det kommer ASF också starta om sig själv (om `AutoStarta om` tillåter) om du ändrar kärnan ASF `ASF.json` konfiguration. Likaså kommer programmet att sluta om du tar bort eller döpa om det.

Du kan inaktivera detta beteende med `--no-config-watch` **[kommandoradsargumentet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** om du har en specifik anledning, till exempel vill du inte att från ASF ska reagera på filändringar i `config` mapp.