# ObjektMatcherPlugin

`ItemsMatcherPlugin` är officiell ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** som utökar ASF med ASF STM listningsfunktioner. I synnerhet detta inkluderar `Publicera` i **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** och `MatchActively` i **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. ASF levereras med `ItemsMatcherPlugin` tillsammans med releasen, därför är den redo för användning direkt.

---

## `Publikationslista`

Offentlig listning, som namnet antyder, listar för närvarande tillgängliga ASF STM bots. Den ligger på **[vår hemsida](https://asf.justarchi.net/STM)**, hanteras automatiskt och används som en offentlig tjänst för både ASF-användare som använder `MatchActively`, såväl som ASF och icke-ASF användare för manuell matchning.

För att listas har du en uppsättning krav att uppfylla. Åtminstone måste du ha tillåtit `Publicering` i `RemoteCommunication` (standardinställning), `SteamTradeMatcher` aktiverat i `TradingPreferences`, **[offentlig inventering](https://steamcommunity.com/my/edit/settings)** sekretessinställningar, ett **[obegränsat](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** -konto och **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** aktivt. Ytterligare krav inkluderar 2FA aktiv sedan minst 15 dagar, senaste lösenordsändring mer än 5 dagar sedan, avsaknad av några kontobegränsningar som låsningar, ekonomiska förbud och handelsförbud. Naturligtvis måste du också ha minst ett (bytbart) objekt i ditt förråd från angivna `MatchableTypes`, till exempel handelskort. Utöver det accepteras inte robotar med mer än `500000` objekt på grund av överdriven overhead, Vi rekommenderar att du delar upp ditt lager på flera konton i det här fallet.

While `PublicListing` is enabled by default, please note that you will **not** be displayed on the website if you do not meet all of the requirements, especially `SteamTradeMatcher`, which isn't enabled by default. För personer som inte uppfyller kriterierna, även om de höll `Publicering` aktiverad, kommunicerar ASF inte med servern på något sätt. Publik listning är också endast kompatibel med senaste stabila versionen av ASF och kan vägra att visa föråldrade botar, speciellt om de saknar kärnfunktionalitet som bara kan hittas i nyare versioner.

### Hur det fungerar exakt

ASF skickar initiala data en gång efter inloggning, som innehåller alla fastigheter offentliga notering använder sig av. Sedan, varje 10 minuter ASF skickar en, mycket liten "hjärtslag" begäran som meddelar vår server att boten fortfarande är igång. Om av någon anledning hjärtslag inte anländer, till exempel på grund av nätverksproblem, sedan ASF kommer att försöka skicka det igen varje minut, tills servern registrerar det. På så sätt vet vår server exakt vilka robotar som fortfarande körs och är redo att acceptera byteserbjudanden. ASF kommer också att skicka inledande tillkännagivande efter behov, till exempel om det upptäcker att vår inventering har ändrats sedan den föregående.

Vi visar alla berättigade ASF-konton som var aktiva i **senaste 15 minuter**. Användare sorteras efter deras relativa användbarhet - `MatchEverything` robotar som visas med `Alla` banner som accepterar alla 1:1 byten, sedan unika spel räknas, och slutligen objekt räknas.

### API

ASF STM listning accepterar endast ASF botar för tillfället. Det finns inget sätt att lista tredje part robotar på vår lista för nu, eftersom vi inte enkelt kan granska deras kod och se till att de uppfyller hela vår handelslogik. Deltagande i listningen kräver därför den senaste stabila ASF-versionen, även om den kan köras med anpassade **[plugins](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

För konsumenter av listningen har vi en mycket enkel **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** slutpunkt som du kan använda. Det innehåller all data vi har, förutom lager av användare som är en del av `MatchActively` funktionen exklusivt.

### Integritetspolicy

Om du samtycker till att listas i vår listning, genom att aktivera `SteamTradeMatcher` och inte vägra `Publicering`, enligt ovan, kommer vi tillfälligt att lagra några av dina Steam-kontouppgifter på vår server för att tillhandahålla den förväntade funktionaliteten.

Offentlig information (Ställd av Steam till alla berörda parter) inkluderar:
- Din Steam-identifierare (i 64-bitars formulär, för att generera länkar)
- Ditt smeknamn (för visningsändamål)
- Din avatar (hash, för visningsändamål)

Villkorligt offentlig information (Ställd av Steam till alla berörda parter om du uppfyller kraven på listning) inkluderar:
- Ditt **[lager](https://steamcommunity.com/my/inventory/#753_6)** (så att folk kan använda `MatchActively` mot dina artiklar).

Privat information (valda data som krävs för att tillhandahålla funktionalitet) inkluderar:
- Din **[bytessymbol](https://steamcommunity.com/my/tradeoffers/privacy)** (så att personer utanför din vänlista kan skicka byten)
- Din `Matchbara typer` inställning (för visningsändamål och matchning)
- Din `MatchEverything` inställning (för visningsändamål och matchning)
- Din `MaxTradeHoldVaraktighet` inställning (så att andra människor vet om du är villig att acceptera deras affärer)

Sedan det ögonblick du slutar använda (tillkännage på) vår listning, din data blir otillgänglig för allmänheten inom högst 15 minuter, och hålls annars på vår server i max två veckor - allt raderas automatiskt efter den perioden. Inga åtgärder krävs från er för att det ska ske.

---

## `Aktivt`

`MatchActively` inställningen är aktiv version av **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** inklusive interaktiv matchning där boten kommer att skicka byten till andra personer. Det kan fungera fristående, eller tillsammans med `SteamTradeMatcher` inställning. Denna funktion kräver att `LicenseID` är inställd, eftersom den använder tredjepartsserver och betalda resurser för att fungera.

För att utnyttja det alternativet, har du en uppsättning krav att uppfylla. Du måste ha ett **[obegränsat](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** -konto, **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** aktiv och minst en giltig typ i `Matchbara typer`, såsom handelskort. Ytterligare krav inkluderar 2FA aktiv sedan minst 15 dagar, senaste lösenordsändring mer än 5 dagar sedan, avsaknad av några kontobegränsningar som låsningar, ekonomiska förbud och handelsförbud.

Om du uppfyller alla krav ovan, ASF kommer regelbundet att kommunicera med våra **[offentliga ASF STM listning](#publiclisting)** för att aktivt matcha robotar som för närvarande är tillgängliga.

Under matchning hämtar ASF bot sitt eget förråd, kommunicera sedan med vår server med den för att hitta alla möjliga `MatchableTypes` matcher från andra, för närvarande tillgängliga bots. Tack vare att kommunicera direkt med vår server, denna process kräver en enda begäran och vi har omedelbar information om någon tillgänglig bot erbjuder något intressant för oss - om matchen hittas, ASF kommer att skicka och bekräfta handelserbjudande automatiskt.

Denna modul är tänkt att vara transparent. Matchning startar om ungefär `1` timme sedan ASF startar, och kommer att upprepa sig varje `6` timmar (om det behövs). `MatchActively` -funktionen är avsedd att användas som en långsiktig, periodisk åtgärd för att säkerställa att vi aktivt är på väg mot slutförande, dock, personer som inte kör ASF 24/7 kan också överväga att använda en `match` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Målanvändare i denna modul är primära konton och "stash" alt konton, även om det kan användas av någon bot som inte är inställd på `MatchEverything`. Utöver det accepteras inte bots med mer än `500000` objekt för matchning på grund av överdriven overhead, Vi rekommenderar att du delar upp ditt lager på flera konton i det här fallet.

ASF gör sitt bästa för att minimera mängden förfrågningar och tryck som genereras genom att använda detta alternativ, samtidigt maximera effektiviteten för att matcha till den övre gränsen. Den exakta algoritmen för att välja robotar att matcha och annars organisera hela processen, är ASF:s genomförandedetalj och kan förändras när det gäller feedback, situation och eventuella framtida idéer.

Den aktuella versionen av algoritmen gör ASF prioritera `Alla` robotar först, särskilt de med bättre mångfald av spel som deras objekt är från. När `är slut på` bots, ASF kommer att gå vidare till `Fair` sådana på samma mångfald regel. ASF kommer att försöka matcha varje tillgänglig bot minst en gång, för att se till att vi inte missar en möjlig uppsättning framsteg.

`MatchActively` tar hänsyn till robotar som du svartlistade från att handla via `tbadd` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** och kommer inte att försöka att aktivt matcha dem. Detta kan användas för att tala om för ASF vilka robotar det aldrig ska matcha, även om de skulle ha potentiella dupes för oss att använda.

ASF kommer också att göra sitt bästa för att se till att handelserbjudandena går igenom. På nästa körning, som normalt sker inom 6 timmar, ASF kommer att avbryta alla väntande handelserbjudanden som fortfarande inte accepterats, och deprioritera ångkoderna som deltar i dem för att förhoppningsvis föredra mer aktiva robotar först. Fortfarande, om deprioritized bottar är de sista som har den match vi behöver, vi försöker fortfarande att matcha dem (igen).

---

### Varför behöver jag en `LicenseID` för att använda `MatchActively`? Var det inte gratis tidigare?

ASF är och förblir fri och öppen källkod, eftersom det grundades i början av projektet i oktober 2015. Källkod för `ItemsMatcher` plugin och därför `MatchActively` funktionen finns i vårt förråd, medan ASF-programmet är helt icke-kommersiellt tjänar vi inte något på bidrag till det, bygga eller publicera. Under de senaste 7+ åren ASF har fått en enorm mängd utveckling, och det förbättras fortfarande och förbättras med varje månatlig stabil utgåva mestadels av en enda person, **[JustArchi](https://github.com/JustArchi)** - utan några strängar. Den enda finansiering vi får är från icke-obligatoriska donationer som kommer från våra användare.

Under en mycket lång tid, fram till oktober 2022, `MatchActively` funktionen var en del av ASF kärna och tillgänglig för alla att använda. I oktober 2022, Valve, företaget bakom Steam, har satt mycket stränga hastighetsgränser för att hämta lager av andra robotar - vilket gjorde tidigare funktionalitet helt bruten, utan möjlighet att lösa detta problem. Därför, på grund av det faktum att funktionen har blivit helt nedlagd utan chans att bli fast, den måste tas bort från ASF kärna som föråldrad.

`MatchActively` återupplivades som en del av officiella `ItemsMatcher` plugin som ytterligare förbättrar ASF med aktiva kort matchande funktionalitet, baserat på ett helt omarbetat koncept. Att återupprätta `MatchActively` funktionen krävs från oss **extra mycket arbete** för att skapa ASF backend, helt ny tjänst som finns på en server, med mer än hundra betalda ombud knutna för att lösa inventarier, allt uteslutande för att tillåta ASF-kunder att använda `MatchActively` som tidigare. På grund av den mängd arbete som berörs, samt resurser som inte är fria och som kräver att betalas på månadsbasis av oss (domän, server, proxies), Vi har beslutat att erbjuda denna funktionalitet till våra sponsorer, det vill säga personer som redan stöder ASF-projektet månatligen tack vare vilka vi kan ställa dessa betalda resurser till förfogande.

Vårt mål är inte att dra nytta av det, utan snarare täcka **månadskostnader** som uteslutande är kopplade till att erbjuda detta alternativ - det är därför vi erbjuder det i princip för ingenting, men vi måste ta ut lite för det eftersom vi inte kan betala hundratals dollar från våra egna fickor varje månad, bara för att göra det tillgängligt för dig. Vi är inte riktigt i stånd att diskutera priset heller, det är Valve som tvingade dessa kostnader på oss, och alternativet är att inte ha en sådan funktion tillgänglig alls, vilket naturligtvis gäller om du bestämmer, av någon anledning, att du inte kan motivera att använda vår plugin på dessa villkor.

I vilket fall som helst förstår vi att `MatchActively` inte är för alla, och vi hoppas att du också förstår varför vi inte kan erbjuda det gratis. Om ingen var intresserad av att hjälpa till att täcka kostnaderna för denna funktion, skulle det helt enkelt inte existera till att börja med, som vi skulle tvingas att skära på månatliga utgifter som ingen är villig att behålla. Tack och lov, vi är i bättre läge än så, och du kan bestämma dig själv om du är villig att använda `MatchActively` på dessa villkor, eller inte.

---

### Hur får jag en åtkomst?

`ItemsMatcher` erbjuds som en del av månatlig $5+ sponsornivå på **[JustArchi's GitHub](https://github.com/sponsors/JustArchi)**. Det är också möjligt att bli engångssponsor, även om i detta fall licensen kommer att gälla endast i en månad (med möjlighet till förlängning på samma sätt). När du har blivit sponsor av $5 nivå (eller högre), läs **[konfigurationen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** sektionen för att erhålla och fylla `LicenseID`. Efteråt behöver du bara aktivera `MatchActively` i `TradingPreferences` för din valda bot.

Licensen tillåter dig att skicka begränsade antal förfrågningar till servern. $5 nivå kan du använda `MatchActively` för ett bot konto (4 förfrågningar dagligen), och varje ytterligare $ 5 lägger till ytterligare två bot konton (8 förfrågningar dagligen). Till exempel, om du vill köra det på tre konton, som kommer att omfattas av $ 10 nivå och högre.