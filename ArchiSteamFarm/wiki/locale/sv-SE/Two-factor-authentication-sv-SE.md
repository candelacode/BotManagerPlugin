# Tvåfaktorsautentisering

Steam innehåller tvåfaktorsautentiseringssystem som kräver extra detaljer för olika kontorelaterade aktiviteter. Du kan läsa mer om det **[här](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** och **[här](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. Denna sida anser att 2FA systemet samt vår lösning som integrerar med det, kallas ASF 2FA.

---

# ASF logik

Oavsett om du använder ASF 2FA eller inte, ASF innehåller korrekt logik och är fullt medveten om konton som skyddas av 2FA på Steam. Det kommer att be dig om nödvändiga uppgifter när de behövs (såsom under inloggning). Medan du kan manuellt tillhandahålla den informationen, vissa ASF-funktioner (såsom `MatchActively`) kräver att ASF 2FA är operativ på ditt bot konto, som automatiskt kan svara på 2FA uppmaningar, automatiskt, när det krävs av ASF.

---

# ASF 2FA

ASF 2FA är en inbyggd modul som ansvarar för att tillhandahålla 2FA funktioner till ASF-processen, såsom att generera tokens och acceptera bekräftelser. Det kan fungera antingen i fristående läge, eller genom att duplicera dina befintliga autentiseringsdetaljer (så att du kan använda din nuvarande autentiserare och ASF 2FA samtidigt).

Du kan kontrollera om ditt bot konto använder ASF 2FA redan genom att köra `2fa` **[kommandon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Utan att sätta upp ASF 2FA, kommer alla standard `2fa` kommandon vara icke-operativa, vilket innebär att din bot är otillgänglig för avancerade ASF-funktioner som kräver att modulen är operativ.

---

# Rekommendationer

Det finns många sätt att göra ASF 2FA operativ, här inkluderar vi våra rekommendationer baserat på din nuvarande situation:

- Om du redan använder inofficiell tredjepartsapp som låter dig extrahera 2FA detaljer med lätthet, bara **[importera](#import)** dem till ASF.
- Om du använder officiell app och du inte har något emot att återställa dina 2FA-uppgifter, är det bästa sättet att inaktivera 2FA, sedan **[skapa](#creation)** nya 2FA autentiseringsuppgifter genom att använda **[gemensam autentiseringsenhet](#joint-authenticator)**, som gör att du kan använda officiell app och ASF 2FA. Denna metod **kräver inte root**, jailbreaking eller någon avancerad kunskap, knappt följa instruktioner skrivna här, och är utan tvekan överlägsen för detta scenario.
- Om du använder den officiella appen och inte vill återskapa dina 2FA-uppgifter är dina alternativ mycket begränsade, typiskt behöver du root och extra fiffla runt till **[importera](#import)** dessa detaljer, och även med att det kan vara omöjligt.
- Om du inte använder 2FA ännu och inte bryr dig, vi rekommenderar att du använder ASF 2FA med **[fristående autentiserare](#standalone-authenticator)** eller **[gemensam autentiserare](#joint-authenticator)** med officiell app (samma som ovan).

Nedan diskuterar vi alla möjliga alternativ och kända för oss metoder.

---

## Skapande

ASF levereras med en officiell `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** som ytterligare utökar ASF 2FA, låter dig länka en helt ny 2FA-autentiserare. Detta kan vara användbart om du inte kan eller inte vill använda andra verktyg och inte har något emot att ASF 2FA blir din huvudsakliga (och kanske bara) autentiserare. Skapandeprocessen används också i joint-authenticator-metoden, Naturligtvis i detta scenario kan din autentiserare samexistera på två platser samtidigt - båda kommer att generera samma koder och båda kommer att kunna bekräfta samma bekräftelser.

### Gemensamma steg för båda scenarierna

Oavsett om du planerar att använda ASF som fristående eller gemensam autentiserare, måste du göra dessa initieringssteg:

1. Skapa en ASF-bot för målkontot, starta den och logga in, vilket du förmodligen redan gjorde.
2. Tilldela ett fungerande och operationellt telefonnummer till kontot **[här](https://store.steampowered.com/phone/manage)** som ska användas av boten. Detta gör att du kan ta emot SMS-kod och tillåta återställning om det behövs. Detta steg är inte obligatoriskt i alla scenarier, men vi rekommenderar det om du inte vet vad du gör.
3. Se till att du inte använder 2FA ännu för ditt konto, om du gör det, inaktivera det först. Detta **kommer** lägga ditt konto på tillfälligt byte, det finns ingen väg runt det, bara **[import](#import)** process kan hoppa över den.
4. Kör kommandot `2fainit [Bot]` och ersätter `[Bot]` med din bots namn.

Förutsatt att ni fick ett lyckat svar så har följande två saker hänt:

- En ny `<Bot>.maFile.PENDING` fil skapades av ASF i din `config` katalog.
- SMS skickades från Steam till det telefonnummer du har tilldelat för kontot ovan. Om du inte angav ett telefonnummer så skickades istället ett e-postmeddelande till kontots e-postadress.

Autentiseringsdetaljerna är inte operativa ännu, men du kan granska den genererade filen om du vill. Om du vill vara dubbelsäker kan du till exempel redan skriva ner återkallelsekoden. Nästa steg beror på ditt valda scenario.

### Fristående autentisering

Om du vill använda ASF som din huvudsakliga (eller rentav endast) autentiserare, nu måste du göra det slutliga slutgiltiga steget

5. Kör kommandot `2fafinalize [Bot] <ActivationCode>` ersätta `[Bot]` med din bots namn och `<ActivationCode>` med koden du fått via SMS eller e-post i föregående steg.

### Gemensam autentiserare

Om du vill ha samma autentiserare i både ASF och den officiella Steam-mobilappen, nu måste du göra nästa, mer knepiga steg:

5. **Ignorera** den SMS eller e-postkod som du har fått i föregående steg.
6. Installera Steam-mobilappen om den inte är installerad ännu, och öppna den. Navigera till fliken Steam Guard och lägg till en ny autentiserare genom att följa appens instruktioner.
7. Efter att din autentiserare i mobilappen har lagts till och fungerar, återgå till ASF. Nu behöver vi bara informera ASF om att mobilappen redan aktiverat våra tidigare genererade detaljer:
 - Vänta tills nästa 2FA-kod visas i Steams mobilapp, och använd kommandot `2fafinalized [Bot] <2FACodeFromApp>` som ersätter `[Bot]` med din bots namn och `<2FACodeFromApp>` med koden som du för närvarande ser i Steams mobilapp - samma som du skulle använda för att logga in på Steam (**INTE** den du redan använt för aktivering). Om koden genereras av ASF och koden du angav är lika, ASF antar att en autentiserare har lagts till korrekt och fortsätter med att importera din nyligen skapade autentiserare.
 - Vi rekommenderar starkt att göra ovanstående för att säkerställa att dina uppgifter är giltiga. Men om du inte vill (eller inte kan) kontrollera om koder är desamma och du vet vad du gör, du kan istället använda kommandot `2fafinalizedforce [Bot]`, ersätta `[Bot]` med din bots namn. ASF antar att autentiseraren har lagts till korrekt och fortsätter med att importera din nyligen skapade autentiserare. Var uppmärksam på att ASF i detta läge inte kan verifiera om koderna matchar, vilket innebär att du kan importera ogiltiga (ej aktiverade) uppgifter.

### Efter färdigställande

Om allt fungerade som det ska, bytte den tidigare genererade filen `<Bot>.maFile.PENDING` namn till `<Bot>.maFile.NEW`. Detta indikerar att dina 2FA-uppgifter nu är giltiga och aktiva. Vi rekommenderar att du flyttar den filen utanför `config` -katalogen och **lagra den på en säker plats**. Dessutom, om du har bestämt dig för att använda fristående autentiserare, sedan rekommenderar vi att du öppnar filen i din redigerare av valet och skriver ner `revocation_code`, vilket gör att du, som namnet antyder, kan återkalla autentiseraren om du skulle förlora den. I joint-authenticator-metoden borde du redan ha gjort det i Steam-mobilappen, men gör gärna samma sak om du skulle behöva.

När det gäller tekniska detaljer, den genererade `maFile` innehåller alla detaljer som vi har fått från Steam-servern under länkning av autentiseraren, och förutom det, `device_id` fältet, som kan behövas för andra (tredje part) autentiserare, om du någonsin bestämmer dig för att importera `maFile` till dem.

ASF importerar automatiskt din autentiserare när proceduren är klar och därför `2fa` och andra relaterade kommandon bör nu vara i drift för det bot konto du länkade autentiseraren till. Vi rekommenderar dig att kontrollera det.

---

## Importera

Importprocessen kräver redan länkad och operativ autentisering som stöds av ASF. Vi har instruktioner för några olika officiella och inofficiella källor till 2FA, ovanpå manuell metod som gör att du kan ge nödvändiga uppgifter själv. Observera att dessa instruktioner bör användas **endast** om du redan använder en given lösning - eftersom processen här omfattar appar och verktyg från tredje part, **rekommenderar vi inte att använda dem**, och vi nämner det uteslutande för personer som redan beslutat att använda dem och vill importera genererade detaljer till ASF 2FA.

I allmänhet innebär importprocessen att släppa `maFile` i lämpligt format till ASF: s `config` katalog, på vilken ASF kommer att plocka upp den filen och automatiskt ta bort den av säkerhetsskäl.

Alla följande guider kräver att du redan har **fungerande och operativ** autentiserare som används med givna verktyg/applikation. ASF 2FA kommer inte att fungera korrekt om du importerar ogiltiga data, se därför till att din autentiserare fungerar korrekt innan du försöker importera den. Detta inkluderar testning och verifiering av att följande autentiseringsfunktioner fungerar korrekt:
- Du kan generera tokens och dessa tokens accepteras av Steam-nätverket (du kan logga in med dem)
- Du kan hämta bekräftelser, och de anländer på din mobila autentiserare
- Du kan reagera på dessa bekräftelser, och de känns igen av Steam-nätverket som bekräftat/avvisats

Se till att din autentiserare fungerar genom att kontrollera om ovanstående åtgärder fungerar - om de inte, då fungerar de inte heller i ASF.

### Android-telefon

I allmänhet för att importera autentiserare från din Android-telefon behöver du **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))** åtkomst. Nedanstående instruktioner kräver från dig ganska anständig kunskap i Android modding värld, vi kommer definitivt inte att förklara varje steg här, besök **[XDA](https://xdaforums.com)** och andra resurser för ytterligare information/hjälp med nedan.

**Från och med i dag, det finns ingen känd, bekräftad utvinningsmetod som fortsätter att fungera. Du kan försöka följa nedanstående steg ändå, t.ex. med föråldrad appversion, men vi garanterar inte att det kommer att fungera korrekt. Överväg att använda joint-authenticator-metoden istället.**

<details>
  <summary>Instruktioner för arkivet</summary>

Förutsatt att du har officiella **[Steam-appen](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** fungerar och fungerar (nedan kräver att du startar din enhet):

- Installera **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** och aktivera Zygisk i inställningarna.
- Installera **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (för Zygisk) och se till att det fungerar.
- Installera **[SteamGuardDump](https://github.com/YifePlayte/SteamGuardDump/releases/latest)** eller **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** LSPosed modul och aktivera den i LSPosed inställningar.
- Tvinga döda Steam-appen, sedan öppna den, ångvaktsdetaljer bör nu finnas tillgängliga för kopiering till urklipp.

Nu när du har extraherat nödvändiga detaljer, inaktivera modulen för att förhindra automatisk kopiering varje gång, sedan kopiera värdet av `shared_secret` och `identitethemliga` av kontot som du har för avsikt att lägga till ASF 2FA, till en ny textfil med nedanstående struktur:

```json
{
  "shared_secret": "STRING",
  "identitet_secret": "STRING"
}
```

Ersätt varje `STRING` värde med lämplig privat nyckel från extraherade detaljer. När du gör det, byt namn på filen till `BotName. aFile`, där `BotName` är namnet på din bot du lägger till ASF 2FA till, och lägg det i ASFs `config` katalog om du inte har än.

Starta ASF, som bör märka din fil och importera den. Förutsatt att du har importerat rätt fil med giltiga hemligheter, allt bör fungera korrekt, som du kan verifiera genom att använda `2fa` kommandon. Om du gjorde ett misstag, kan du alltid ta bort `Bot.db` och börja om om det behövs.

</details>

### SteamDesktopAuthenticator

Om du redan har din autentiserare i SDA bör du märka att det finns `steamID.maFile` fil tillgänglig i `maFiles` mapp. Kontrollera att `maFile` är i okrypterat formulär, ASF kan inte dekryptera SDA-filer - okrypterat filinnehåll bör börja med `{` och sluta med `}` tecken. Om det behövs kan du först ta bort krypteringen från SDA-inställningarna och aktivera den igen när du är klar. När filen är i okrypterad form, kopiera den till `config` katalog ASF.

Du kan nu byta namn på `steamID.maFile` till `BotName. aFile` i ASF-konfigurationskatalogen, där `BotName` är namnet på din bot du lägger till ASF 2FA till. Alternativt kan du lämna den som den är, ASF kommer då att plocka den automatiskt efter inloggning. Byta namn på filen hjälper ASF genom att göra det möjligt att använda ASF 2FA innan du loggar in, om du inte gör det, sedan kan filen väljas först efter att ASF loggat in (som ASF inte känner till `steamID` på ditt konto innan du faktiskt loggar in).

Starta ASF, som bör märka din fil och importera den. Förutsatt att du har importerat rätt fil med giltiga hemligheter, allt bör fungera korrekt, som du kan verifiera genom att använda `2fa` kommandon. Om du gjorde ett misstag, kan du alltid ta bort `Bot.db` och börja om om det behövs.

### WinAuth

Skapa först nytt tomt `BotName. aFile` i ASF-konfigurationskatalogen, där `BotName` är namnet på din bot du lägger till ASF 2FA till. Om du anger felaktigt namn, kommer det inte att väljas av ASF.

Nu lanserar WinAuth som vanligt. Högerklicka på Steam-ikonen och välj "Visa SteamGuard och Recovery Code". Markera sedan "Tillåt kopiera". Du bör märka bekant för dig JSON struktur längst ner i fönstret, med början med `{`. Kopiera hela texten till en `BotName.maFile` fil skapad av dig i föregående steg.

Starta ASF, som bör märka din fil och importera den. Förutsatt att du har importerat rätt fil med giltiga hemligheter, allt bör fungera korrekt, som du kan verifiera genom att använda `2fa` kommandon. Om du gjorde ett misstag, kan du alltid ta bort `Bot.db` och börja om om det behövs.

### Manuell

Om du är avancerad användare kan du också generera maFile manuellt. Detta kan användas om du vill importera autentiserare från andra källor än de vi har beskrivit ovan. Det bör ha en **[giltig JSON struktur](https://jsonlint.com)** av:

```json
{
  "shared_secret": "STRING",
  "identitet_secret": "STRING"
}
```

Standard autentiseringsdata har fler fält - de ignoreras helt av ASF under import, eftersom de inte behövs. Du behöver inte ta bort dem - ASF kräver endast giltiga JSON med 2 obligatoriska fält som beskrivs ovan, och kommer att ignorera ytterligare fält (om någon). Självklart måste du ersätta `STRING` platshållare i exemplet ovan med giltiga värden för ditt konto. Varje `STRING` bör vara base64-kodad representation av bytes den lämpliga privata nyckeln är gjord av.

---

## Vanliga frågor

### Hur använder ASF 2FA modulen?

Om ASF 2FA är tillgängligt, kommer ASF att använda det för automatisk bekräftelse av affärer som skickas/accepteras av ASF. Det kommer också att kunna automatiskt generera 2FA tokens på efterlängtad basis, till exempel för att logga in. Dessutom, att ha ASF 2FA också möjliggör `2fa` kommandon som du kan använda.

### Hur kan jag få 2FA token?

Du behöver 2FA token för att få tillgång till 2FA-skyddat konto, som inkluderar varje konto med ASF 2FA också. Om du har bestämt dig för att använda fristående autentiserare, bör du använda kommandot `2fa <BotNames>` för att generera temporär token för givna bot-instanser. I alla andra scenarier rekommenderar vi att använda originalautentiseraren som du har använt, även om du kan använda kommandot också om det är mer praktiskt för dig.

### Kan jag använda min ursprungliga autentiserare efter att ha importerat den som ASF 2FA?

Ja, din autentiserare förblir funktionell och du kan använda den tillsammans med ASF 2FA. Tänk dock på att om du ogiltigförklarar det med någon metod så kommer länkade ASF 2FA-referenser inte längre att vara giltiga.

### Hur tar man bort ASF 2FA?

Stoppa helt enkelt ASF och ta bort associerad `BotName.db` av botten med länkad ASF 2FA du vill ta bort. Det här alternativet kommer att ta bort associerad importerad 2FA med ASF, men kommer INTE att ogiltigförklara (ta bort) din autentiserare. Om du istället vill ogiltigförklara din autentiserare, bortsett från att ta bort den från ASF (först), bör du avlänka den i den ursprungliga autentiseraren som du väljer. Om du inte kan göra det av någon anledning, till exempel för att du använder ASF 2FA i fristående läge, använd sedan återkallelsekod som du har fått under installationen, på Steams webbplats. Det är inte möjligt att ogiltigförklara din autentisering via ASF.

### Jag länkade autentiseraren i tredjepartsappen och importerades sedan till ASF. Kan jag nu länka den igen på min telefon?

**Nej**. Att göra så kommer att ogiltigförklara de tidigare importerade autentiseringsuppgifterna och din ASF 2FA kommer att sluta fungera (genom att generera koder som inte längre accepteras av Steam). Först bestämmer var du vill ha din ursprungliga eller tredje part autentiserare lokal, sedan importera den som ASF 2FA.

### Jag använder gemensam autentiserare, kan jag flytta min app till en annan telefon?

**Nej**. Vad ångan säger som "flytta" eller "överföring" autentiserare, är faktiskt lika med att ogiltigförklara den gamla och tilldela en ny, i ett steg. Detta gör att du kan hoppa över t.ex. någon överdriven nedkylning jämfört med att göra dessa två steg oberoende, dock, vad gäller ASF, är detta ogiltigförklarar faktiskt de uppgifter du tidigare genererat i ASF, vilket gör hela ASF 2FA modulen icke-operativ.

Det rekommenderade sättet är att ta bort autentiseraren helt på den gamla telefonen och använda den gemensamma autentiseringsmetoden igen på den nya telefonen. Om du redan har flyttat din autentiserare, då gamla ASF 2FA autentiseringsuppgifter är redan ogiltiga, så det enda som återstår nu är att ta bort din "flyttade" autentiserare, och länka en ny med hjälp av den gemensamma autentiseringsmetoden igen.

### Är det bättre att använda ASF 2FA än tredjepartsautentiserare inställd på att acceptera alla bekräftelser?

**Ja**, på flera sätt. Första och viktigaste en - att använda ASF 2FA **avsevärt** ökar din säkerhet, ASF 2FA modul ser till att ASF endast accepterar sina egna bekräftelser, så även om angriparen begär en handel som är skadlig, ASF 2FA kommer **inte** acceptera sådan handel, eftersom det inte genererades av ASF. Förutom säkerhetsdelen ger ASF 2FA också prestanda/optimering fördelar, som ASF 2FA hämtar och accepterar bekräftelser omedelbart efter de genereras, och först då, i motsats till ineffektiv vallokal för bekräftelser varje X minuter som uppnås genom andra lösningar. Det finns ingen anledning att använda tredjepartsautentisering över ASF 2FA, om du planerar att automatisera bekräftelser som genereras av ASF - det är precis vad ASF 2FA är för, och att använda det strider inte mot dig som bekräftar allt annat i autentiseraren som du väljer. Vi rekommenderar starkt att använda ASF 2FA för hela ASF-aktivitet.