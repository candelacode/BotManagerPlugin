# Handel

ASF inkluderar stöd för Steam icke-interaktiva (offline) affärer. Både ta emot (acceptera/avböja) samt skicka avslut finns tillgänglig direkt och kräver inte speciell konfiguration, men naturligtvis kräver obegränsad Steam-konto (den som redan spenderat 5$ i butiken). Endast begränsad handelsfunktionalitet är tillgänglig för begränsade konton.

---

## Logik

Först och främst är det möjligt att inaktivera **alla** inkommande handelserbjudanden, genom att använda `DisableIncomingTradesParsing` flaggan i `BotBehaviour`. Använda det, som namnet antyder, kommer att inaktivera alla funktioner i samband med inkommande affärer parsing, vilket inkluderar under standard logik, liksom alla extra funktioner som finns tillgängliga som beror på att reagera på inkommande handel erbjudande. Eftersom standardinställningarna redan är icke-störande, du bör överväga att använda det alternativet endast om du har absolut ingen avsikt från ASF att göra något som rör inkommande affärer alls.

Nedanstående förklarar logik när inkommande handel erbjuder parsning är aktiverad, vilket är standardalternativet.

ASF kommer alltid att acceptera alla byten, oavsett föremål, som skickas från användare med `Master` (eller högre) åtkomst till boten. Detta gör det inte bara lätt plundring ångkort som odlas av bot exempel, men också gör det möjligt att enkelt hantera Steam-objekt som bot stashar i inventariet - inklusive de från andra spel (såsom CS:GO).

ASF kommer att avvisa handelserbjudande, oavsett innehåll, från alla (icke-master) användare som är svartlistad från handelsmodulen. Svartlistan lagras i standard `BotName. b` databas och kan hanteras via `tb`, `tbadd` och `tbrm` **[kommandon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Detta bör fungera som ett alternativ till standard användarblock som erbjuds av Steam - använd med försiktighet.

ASF kommer att acceptera alla `loot`-liknande affärer som skickas över botar, om inte `DontAcceptBotTrades` anges i `TradingPreferences`. Kort sagt, standard `TradingPreferences` of `Ingen` kommer att få ASF att automatiskt acceptera byten från användare med `Master` tillgång till bot (förklaras ovan), såväl som alla donationsaffärer från andra bottar som deltar i ASF-processen.

När du aktiverar `AcceptDonations` i din `TradingPreferences`, ASF kommer också att acceptera någon donation handel - en handel där bot konto inte förlorar några objekt. Denna egenskap påverkar endast icke-bot konton, eftersom bot konton påverkas av `DontAcceptBotTrades`. `AcceptDonations` låter dig enkelt ta emot donationer från andra människor, och även botar som inte deltar i ASF-processen.

Det är trevligt att notera att `AcceptDonationer` inte kräver **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, eftersom det inte behövs någon bekräftelse om vi inte förlorar några objekt.

Du kan också ytterligare anpassa ASF handel funktioner genom att ändra `TradingPreferences` därefter. En av de viktigaste `TradingPreferences` funktionerna är `SteamTradeMatcher` alternativ som kommer att orsaka ASF att använda inbyggd logik för att acceptera affärer som hjälper dig att slutföra saknade märken, vilket är särskilt användbart i samarbete med offentlig notering av **[SteamTradeMatcher](https://www.steamtradematcher.com)**, men kan också fungera utan det. Det beskrivs vidare nedan.

---

## `SteamTradeMatcher`

När `SteamTradeMatcher` är aktiv, ASF kommer att använda ganska komplex algoritm för att kontrollera om handeln passerar STM regler och är åtminstone neutral mot oss. Den faktiska logiken är följande:

- Avvisa affären om vi förlorar något annat än objekttyper som anges i våra `MatchableTypes`.
- Avvisa handeln om vi inte får minst samma antal artiklar på per-spel, per-typ och per-raritet basis.
- Avvisa bytet om användaren frågar efter speciella Steam-sommar-/vinterförsäljningskort, och har ett bytesinnehav.
- Avvisa handeln om handelns varaktighet överskrider `MaxTradeHoldDuration` globala konfigurationsegendom.
- Avvisa handeln om vi inte har `MatchEverything` satt, och det är värre än neutral för oss.
- Acceptera handeln om vi inte avvisade den genom någon av punkterna ovan.

Det är trevligt att notera att ASF också stöder överbetalning - logiken kommer att fungera korrekt när användaren lägger till något extra till handeln, så länge alla ovanstående villkor är uppfyllda.

Första 4 förkasta predikat bör vara uppenbart för alla. Det sista inbegriper en faktisk dupeslogik som kontrollerar det aktuella tillståndet i vår inventering och avgör vilken status handeln har.

- Handel är **bra** om våra framsteg mot slutförande framsteg. Exempel: A A (före) -> A B (efter)
- Handel är **neutral** om våra framsteg mot fastställd slutförande förblir i takt. Exempel: A B (före) -> A C (efter)
- Handel är **dåligt** om våra framsteg mot fastställd slutförande minskar. Exempel: A C (före) -> A (efter)

STM fungerar endast vid bra affärer, vilket innebär att användare som använder STM för dupesmatchning alltid ska föreslå endast bra affärer för oss. ASF är dock liberal, och accepterar även neutrala affärer, eftersom i dessa affärer vi faktiskt inte förlora något, så det finns ingen verklig anledning att avböja dem. Detta är särskilt användbart för dina vänner, eftersom de kan byta dina överdrivna kort utan att använda STM alls, så länge du inte förlorar några bestämda framsteg.

Som standard ASF kommer att avvisa dåliga affärer - detta är nästan alltid vad du vill som användare. Men du kan valfritt aktivera `MatchEverything` i din `TradingPreferences` för att få ASF att acceptera alla dupe trades, inklusive **dåliga**. Detta är endast användbart om du vill köra en 1:1 trade bot under ditt konto, som du förstår att **ASF inte längre kommer att hjälpa dig att gå mot färdigställande av märket, och gör dig benägen att förlora hela set för N dupes av samma kort**. Om du avsiktligt vill köra en bytesbot som är **aldrig** tänkt att avsluta någon uppsättning och bör erbjuda hela sitt lager till varje intresserad användare, då kan du aktivera det alternativet.

Oavsett dina valda `TradingPreferences`, en handel som avvisas av ASF betyder inte att du inte kan acceptera det själv. Om du behöll standardvärdet för `BotBehaviour`, som inte inkluderar `RejectInvalidTrades`, ASF kommer bara att ignorera dessa affärer - så att du kan bestämma dig själv om du är intresserad av dem eller inte. Samma sak gäller för affärer med objekt utanför `MatchableTypes`, samt allt annat - modulen är tänkt att hjälpa dig att automatisera STM trades, inte bestämma vad som är en bra handel och vad som inte är det. Det enda undantaget från denna regel är när man talar om användare som du svartlistade från handelsmodulen med kommandot `tbadd` - byten från dessa användare avvisas omedelbart oavsett `BotBehaviour` inställningar.

Det rekommenderas starkt att använda **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** när du aktiverar detta alternativ, eftersom denna funktion förlorar hela sin potential om du väljer att manuellt bekräfta varje handel. `SteamTradeMatcher` kommer att fungera korrekt även utan möjlighet att bekräfta affärer, men det kan generera eftersläpning av bekräftelser om du inte accepterar dem i tid.