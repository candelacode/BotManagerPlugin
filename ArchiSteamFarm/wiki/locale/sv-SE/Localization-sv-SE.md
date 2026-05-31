# Lokalisering

ASF drivs av Crowdin tjänst, vilket gör det möjligt för alla att hjälpa till att översätta ASF till alla språk som talas över hela världen. För mer detaljerad förklaring av hur Crowdin fungerar, kolla in **[Crowdin introduktion](https://support.crowdin.com/crowdin-intro)**.

Om du är intresserad av vad som pågår just nu kan du kontrollera **[ASF Crowdin aktivitet](https://crowdin.com/project/archisteamfarm/activity_stream)**.

---

## Omfattning

Vår plattform stöder lokalisering av vårt huvudsakliga ASF-program, liksom hela lokaliserbart innehåll som vi erbjuder tillsammans med det. Detta inkluderar särskilt vår ASF-WebConfigGenerator, ASF-ui, liksom vår wiki. Allt detta är möjligt att översätta genom bekvämt crowdin-gränssnitt.

---

## Registrerar sig

Om du vill hjälpa till med ASF, antingen genom att översätta, granska eller godkänna översättningar, vänligen registrera dig på vår **[Crowdin projektsida](https://crowdin.com/project/archisteamfarm)**. Registreringen är enkel och helt gratis! Efter inloggning kan du välja språk som du vill tilldelas till, fortsätt sedan till ASF-strängar och hjälp resten av gemenskapen med att översätta ASF till alla mest populära språk!

---

### Översätter

Om språket du väljer fortfarande saknar några strängar, kan du ta dem och börja arbeta på översättningen. Vi försökte göra vårt bästa när det gäller översättningarnas flexibilitet, därför många strängar inkluderar extra variabler som ASF kommer att ge under körtid - de är inneslutna i parenteser med ett tal, såsom `{0}`. Detta gör att du kan ändra standard ASF-format för strängen, t.ex. genom att flytta ASF-försedd variabel på en plats som uppfyller ditt språk och din översättning, istället för att tvingas till strikt sammanhang och format. Detta är särskilt viktigt i RTL-språk, såsom hebreiska.

Du kan till exempel ha en sträng som:

> Vi har {0} spel att odla.

Men baserat på ditt språk, följande mening kan vara mer vettigt:

> Antalet spel till gården är lika med {0}.

Eller:

> {0} är antalet spel till gården.

Flexibiliteten är speciellt anpassad för dig, så du kan något omord ASF mening för att passa ditt språk bättre och flytta ASF-tillhandahållna nummer eller annan information på en plats som passar din översättning (i stället för att översätta varje del oberoende). Detta förbättrar den övergripande översättningskvaliteten.

---

### Granskar

Om din sträng redan har översatts av någon annan, kan du rösta på den. Röstning gör det möjligt att välja den bästa varianten av översättningen, istället för att hålla fast vid det ursprungliga förslaget - detta förbättrar den övergripande översättningskvaliteten ytterligare. Du kan rösta på redan tillgängliga förslag, eller föreslå din egen översättning, som kommer att gå igenom samma process. Till slut kommer den sista strängen att väljas antingen baserat på de flesta röstade förslagen, eller som ett val av korrekturläsare valt för det språk som personligen godkänner given översättning (baserat på dina röster också).

**Du behöver inte godkännande för att se dina översatta strängar i ASF**. Godkännande innebär helt enkelt att någon litade på från oss har granskat innehållet, som i - plockade den slutliga versionen av översättningen. Det är helt okej att ha icke godkända samhällsdrivna översättningar, där man röstar på den bästa. Så länge det är översatt är allt bra! Och om du tycker att den nuvarande översättningen är dålig, kan du alltid rösta på den bättre, eller föreslå en själv.

---

### Proof-reading

Det är en bra idé att ha en konsekvent översättning, även om det potentiellt skulle kunna ta frihet från gemenskapens granskning / röstning processen förklaras ovan. Detta beror främst på att felaktiga översättningar som inte nödvändigtvis är dåliga kan få så många röster att det inte längre är möjligt att föreslå någon bättre översättning, även om någon har det.

Om du har tidigare historik över bidrag på Crowdin eller någon annan lokaliseringsplattform/tjänst som vi kan verifiera och anta tillförlitliga, Vi är glada att ge dig en korrekturläsare tillgång till visst språk du bidrar till, så du kommer att kunna godkänna given översättning och göra det konsekvent. Proof-reading är inte en lätt uppgift, särskilt eftersom ASF kan vara mycket "teknisk" från tid till annan och verkligen svårt att översätta, men vi förstår att det ofta behövs för en perfekt översättning. Därför, om du kan hjälpa till genom korrekturläsning ges språk, **[låt oss veta](https://crowdin.com/messages/create/13177432/240376)**, men kom ihåg att du måste säkerhetskopiera din begäran med tidigare lokaliseringsbidrag som vi kan verifiera (e. . arbetar med ASF lokalisering på Crowdin, eller med något annat projekt). Vi kan också tillåta mer avancerade användare att plocka upp första korrekturläsning, om vi känner dem personligen och de är kapabla att samarbeta med resten av samhället för att lokalisera ASF i det språket bäst.

Allmänna regler gäller för korrekturläsning - rusa inte, lyssna på dina användare, arbeta som projektledare, lösa problem, se till att du gör saker bättre och inte värre.

---

### Problem

Om du har problem med en viss översättning, t.ex. du vet inte hur man översätter det, godkänd översättning är felaktig, du behöver mer specifika sammanhang, eller likaså skriv en kommentar under specifik sträng, och markera den med [X] Ärende.

**Undvik att använda ärendemarkering om du inte behöver en teknisk förklaring eller en administrativ åtgärd**. Du är fri att använda kommentarer för diskussion relaterade till översättning av given sträng, men problem bör endast användas när du behöver ytterligare teknisk förklaring eller administratörsrättelse, och det kommer vanligtvis att innebära någon som inte ens talar språket du översätter till, så håll dig till engelska när du skriver kommentar (så att vi kan förstå vad problemet är).

Det finns för närvarande 4 typer av problem som stöds:
- Allmän fråga - för allt annat som inte passar något problem nedan. I allmänhet denna typ **bör undvikas**, som om ditt problem inte passar, då är det mycket troligt **inte** ett översättningsproblem. Ändå är detta alternativ tillgängligt här för alla andra fall.
- Nuvarande översättning är fel - detta bör användas **endast** om översättningen redan har godkänts av korrekturläsaren, och du tror att det är fel, till exempel har det en typo eller så har du ett giltigt förslag hur man kan förbättra det. Denna typ bör aldrig användas i översättningar som drivs av gemenskapen (röstning), som i detta fall bör du kontakta användaren av given översättning och be honom om korrigering, eller helt enkelt rösta för bättre översättning, som anges i granskningsavsnittet. Vi kommer att ta bort godkännandet av översättningen och meddela lämplig korrekturläsare som ansvarar för språket att ta hänsyn till din kommentar och verifiera igen.
- Brist på kontextuell information - detta är vad du bör använda om du inte är säker på vilken del av ASF du översätter, vad är kontexten av given sträng, eller dess syfte. Denna typ bör endast användas för ASF-utveckling, det innebär att du behöver teknisk assistans eftersom du inte är säker på hur du ska översätta given sträng.
- Misstag i källsträngen - detta bör endast användas om du anser att den ursprungliga (engelska) strängen är felaktig. Ganska sällsynt, men inte alla av oss talar engelska antingen direkt, så känn dig fri att använda den om du har en allmän uppfattning om hur den kan förbättras. Alternativt, eftersom detta är strikt relaterat till utvecklingen, du kan använda vårt **[GitHub problem](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** för det ändamålet, om du vill.

---

### Översättningen framsteg

Varje språk har två tillstånd av fullbordan - översättning och korrekturläsning.

Språket anses vara **översatt** när dess översättning framsteg når 100%. Vid denna punkt varje lokaliserbar sträng som används av ASF har rätt betydelse, vilket är bra. Men som inte betyder att det inte finns något utrymme för förbättring - community-röstning är aktiverat hela tiden och du kan fortfarande föreslå bättre översättning för redan översatta delar, samt rösta för befintliga. Observera att fullt översatta språk fortfarande kan sjunka under 100% när vi ändrar befintliga strängar eller lägga till nya under utveckling. Du kan ställa in lämpliga crowdin-meddelanden om du vill få e-post när detta händer.

Valda språk kan ha lämpliga korrekturläsare som validerar översättningar och godkänner slutversioner. Detta är slutgiltigt passera efter översättning äger rum och låter för att ytterligare förbättra localization.

ASF kommer att inkludera givet språk **så snart som möjligt**, vilket innebär att det inte behöver godkännas, eller ens 100% översatt. De egentliga strängar som kommer att användas är alltid de mest populära när det gäller röster, såvida inte valt korrekturläsare beslutat annat (sällan). Därför, du kan se dina ansträngningar som ingår i den allra nästa ASF release - våra automationssystem sammanfoga översättningar från Crowdin tillbaka till ASF repo på daglig basis.

---

## Språken saknas

Som standard ASF-projekt har öppen översättning endast för topp 30 språk som talas över hela världen. Om du vill lägga till en annan (eller en lokal dialekt till redan tillgänglig) vänligen **[meddela oss](https://crowdin.com/messages/create/13177432/240376)** så lägger vi till den ASAP. Vi vill inte öppna flera hundra olika språk om ingen kommer att översätta dem, det är därför vi begränsade det till något rättvist antal. Tveka inte att kontakta oss om du vill översätta något icke-listat språk, det är mycket lätt för oss att lägga till en till. Se bara till att du har faktiska villighet och beslutsamhet att översätta ASF till ditt språk, innan du bestämmer dig för att kontakta oss.

För en komplett lista över alla tillgängliga språk som ASF kan översättas till, **[klicka här](https://developer.crowdin.com/language-codes)**.

---

## Pluralisering

Varje språk har sina egna regler när det gäller pluralisering. Dessa regler finns på **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** som anger deras antal och exakta språkvillkor.

Vi gör vårt bästa för att erbjuda dig flexibel lokalisering, och så länge som möjligt, kommer detta också att innehålla pluralregler. Till exempel översätter vi följande sträng till polska idag:

> Släppt {PLURAL:n<unk>{n} month<unk>{n} months} sedan

`PLURAL` sökord här behandlas på ett speciellt sätt eftersom det gör att du kan inkludera alla pluralformer som ditt språk stöder. Om du tar en titt på CLDR, ser du att det på engelska bara finns 2 kardinalformer - "ett" och "andra". Och som du kan se ovan, har vi båda de definierade - `{n} månad` och `{n} månader`.

Men vårt polska språk innehåller faktiskt 4 av dem - "ett", "få", "många" och "andra". Det innebär att vi bör definiera dem alla för slutförande. Våra lokaliseringsverktyg är redan smarta nog att välja lämplig pluralform baserad på språkregler, därför behöver du bara definiera alla av dem i översättningen:

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

På så sätt har vi definierat alla 4 pluralformer för vårt polska språk, och eftersom vårt lokaliseringsbibliotek redan känner till de exakta reglerna, kommer korrekt att använda rätt formulär för angiven `{n}` nummer.

Det är inte obligatoriskt att definiera alla pluralformer som används av ditt språk. Om det saknas, kommer vårt lokaliseringsbibliotek att använda senast definierade formulär i dess ställe. Det är en bra idé att definiera alla pluralformer som används av ditt språk, men i vissa fall kan kvarvarande pluralformer vara samma som sist, i vilket fall det inte behövs för att upprepa dem. I vårt exempel ovan var det obligatoriskt, eftersom "annat" form på polska i månader är "miesia<unk> ca", och inte "miesie<unk> cy" som i "många".

---

## Wiki

Vår crowdin-plattform låter dig också lokalisera även wikin själv. Detta är ett mycket kraftfullt verktyg, eftersom det låter dig skapa en hel ASF-dokumentation på ditt modersmål, effektivt lösa det allra sista problemet när det gäller ASF lokalisering. Tillsammans med översättning av programet och alla dess delar, detta gör localizationen fullständig.

Wiki är lite speciell i detta avseende, eftersom det är online hjälp där du inte behöver hålla fast vid ursprungliga meningen för mycket. Detta innebär att du vill vara så naturlig med ditt språk som möjligt, och leverera original mening och hjälp - inte nödvändigtvis hålla sig till ursprungliga sträng, använda ord och faktisk skiljeteckning. Var inte rädd för att skriva om strängen till något mycket mer naturligt för ditt språk, så länge du håller den allmänna riktningen och hjälp ingår i meningen.

---

### Globala länkar

Vår crowdin plattform kan du också anpassa den ursprungliga texten för att få det att peka på nya (lokaliserade) platser.

ASF innehåller länkar på nästan alla sidor för enklare navigering, samt sidofältet till höger. Det fantastiska faktum är att du kan redigera allt detta, "fixa" länkar för att peka på rätt lokaliserade sidor för ditt språk. Det krävs för att vara lite försiktig med att göra det, men det är möjligt.

Till exempel ASF **[hemsida](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)** innehåller en text som:

> Om du är en ny användare rekommenderar vi att du börjar med **[att du sätter upp](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** guide.

Som ursprungligen skrivs som:

```markdown
Om du är en ny användare rekommenderar vi att du börjar med **[inställning](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** guide.
```

På crowdin, första sak du bör göra är att gå till dina inställningar redaktör och se till att HTML-taggar är inställda på "Visa" för dig. Detta är mycket viktigt om du väljer att lokalisera wiki.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Nu, under översättning på crowdin, beroende på formatering, ser du ASF länkar i texten antingen som:

* String att översätta tillsammans med HTML-taggar (majoriteten av strängar, där endast en del av meningen är en länk)
* Ensam sträng att översätta, med länk som ingår i `Dolda texter` -> `Länkadresser` (sällsynt, där hela strängen är en länk, vanligast i sidofältet - de kräver korrekturläsare tillgång att översätta, tyvärr)

I vårt exempel ovan, är det första fallet (eftersom bara "sätta upp" är en länk), så i crowdin vi ser det som:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Oavsett fall, först bör du kopiera källsträngen och översätta den som vanligt, lämnar hela HTML (om nu) intakt. Detta skulle vara exempel på översättning för polska språk:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Nu, om länken är en generisk länk som pekar utanför wikin (t.ex. till senaste ASF-utgåvan), du kan lämna det som det är eftersom du inte vill redigera det. Du kan spara den och gå framåt.

Men om länken **gör** pekar längre in i wiki, som den ovan, kan du faktiskt korrigera det för att peka på ny (lokaliserad) plats. Du gör detta genom att noggrant lägga till `-locale` för att rikta URL i `<a>` taggen, som nedan:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Var extremt försiktig med detta, och se till att din URL verkligen existerar, eftersom om du gör ett misstag, den länken kommer att sluta fungera. Om du lyckades, har du nu en fullt fungerande översättning med länk som pekar på översatt (i vårt fall `Setting-up-pl-PL`) sida.

Att göra stegen ovan kommer att korrekt översätta vår HTML tillbaka till markdown:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

Och slutligen in i wikitext:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

När ingen HTML finns (andra fallet), Detta är ännu enklare eftersom du bara kan gå till `Dolda texter` -> `Länkadresser`.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

Därifrån kan du enkelt korrigera länken för att peka på ny plats, utan att ens störa med HTML alls:

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Lokala länkar

Tvärs över wikin hittar du också lokala länkar som pekar till viss del av dokumentet. Dessa länkar inkluderar `#` tecken, som anger webbläsaren att den bör gå mot den delen av dokumentet.

Nu är det särskilda fall, eftersom dessa länkar är baserade på namnen på avsnitten i det aktuella dokumentet. Även för webbadresser har vi en allmän konvention om att lägga till `-locale` till webbadressen, och det fungerar överallt, avsnittens namn kommer att översättas av dig och andra människor, så du måste se till att de pekar på rätt plats.

Till exempel kan du hitta `#introduction` länk i vår **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#introduction)** sektion:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Eftersom vi kommer att översätta "Inledning" ord till "Wprowadzenie" för vårt polska språk, Vi måste korrigera den här länken eftersom den kommer att sluta fungera när vi gör detta.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

På så sätt kommer vår lokala länk att fortsätta fungera, eftersom det nu kommer att peka på namnet på det avsnitt som vi använder. Du kan korrigera länkar i HTML-taggar på exakt samma sätt.

---

### Kod block

Var extremt försiktig när du översätter meningar med `<code></code>` block. Kodblock anger fasta ASF-kodnamn eller termer som inte bör översättas. Till exempel:

> Detta är särskilt användbart om du har en massa nycklar att lösa in och du är garanterad att träffa <code>RateLimited</code> status innan du är klar med hela ditt parti.

Som du kan se, är `RateLimited` ord här inne i ett kodblock och indikerar intern ASF-kodstatus som inte bör översättas. Likaså bör du inte översätta andra kodblock, såsom namn på konfigurationsegenskaper (t.ex. `TradingPreferences`), enumsmedlemmar (e. . `Stabil` och `PreRelease` alternativ för `UpdateChannel`) och likaså.

Men bara för att dessa ord inte ska översättas, betyder det inte att du inte kan lägga till lämplig översättning bredvid dem, till exempel inom parentes.

> Ta funkcja jest wyjątkowo użyteczna w przypadku aktywacji dużej ilości kluczy i gwarancji napotkania statusu <code>RateLimited</code> (zbyt częstej aktywacji) przed ukończeniem całej partii.

Som ni kan se ovan, har vi lagt till "zbyt cze<unk> stej aktywacji", bokstavligen "alltför ofta aktivering" bredvid `RateLimited` för att översätta den statusen på ett vänligt sätt, samtidigt hålla original ASF vilket innebär att användaren kan se under användning av programmet. På samma sätt kan du översätta/förklara andra, liknande fall av olika ord och meningar.

Om du tror att något olämpligt ingår i ett kodblock, eller att det finns en text som inte finns i ett kodblock utan bör vara inne i det, tveka inte att fråga på vår crowdin genom att skapa lämplig **[utgåva](#issues)**. Detta fungerar också som ett praktiskt exempel på att använda en lokal länk.

---

## Hall of fame

Vi skulle vilja visa vår eviga tacksamhet till folk som har spenderat en betydande mängd av deras tid och villighet att göra ASF lokalisering bättre. Deras ansträngningar är otroligt, och du kan njuta av fullständiga översättningar, inklusive wiki, främst tack vare dem. Som ett tecken på uppskattning, alla personer som listas här erbjuds fri tillgång till **[``](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** funktion på en **[begäran](https://crowdin.com/messages/create/13177432/240376)**.

| Bidragsgivare                                              | Språk             |
| ---------------------------------------------------------- | ----------------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, spanska   |
| **[Sam](https://crowdin.com/profile/Dead_Sam)**            | Portugisiska (BR) |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | Kinesiska (CN)    |
| **[DragonTaki](https://crowdin.com/profile/dragontaki)**   | Kinesiska (TW)    |
| **[LittleFreak](https://crowdin.com/profile/littlefreak)** | Tyska             |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | Ryska, ukrainska  |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT, tyska     |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | Kinesiska (HK)    |

Tack alla för att förbättra vår ASF lokaliseringskvalitet!