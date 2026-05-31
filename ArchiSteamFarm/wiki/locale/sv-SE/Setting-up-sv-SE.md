# Ställa in

Om du kom hit för första gången, välkommen! Vi är mycket glada över att se ännu en resenär som är intresserad av vårt projekt, även tänka på att med stor kraft kommer stort ansvar - ASF är kapabel att göra en hel del olika Steam-relaterade uppgifter, men bara så länge du **bryr dig tillräckligt för att lära dig att använda det**. Ja, läser wiki, följa våra riktlinjer och lära sig mer om olika ASF-koncept kommer så småningom belöna dig med unik skicklighet att använda en av de mest kraftfulla Steam-verktyg som finns tillgängliga idag.

Vi rekommenderar dig att göra **en sak åt gången**. ASF berör en hel del olika aspekter, av vilka några är ganska triviala, andra kan vara alltför komplexa. Du behöver inte förstå eller läsa om allt på en gång, och vi rekommenderar dig faktiskt att ta det lugnt. Koppla av, plocka dig själv en dryck av val, ägna en timme av din tid och dyka in i vår föreläsning - vi kan lova att det kommer att vara väl värt din tid.

Låt oss börja från grunderna - ASF är en konsolapp i sin princip, vilket innebär att det inte automatiskt kommer att skapa ett grafiskt gränssnitt som du i allmänhet är van vid. ASF är universell app som huvudsakligen fungerar som en tjänst (daemon), och inte som en skrivbordsapp. En av dess huvudsakliga användningsfall anser att köra på server-maskiner, som stationära appar är helt olämpliga för. Det anser bara den absoluta kärnan i programmet men, eftersom ASF faktiskt **gör** innehåller sitt eget grafiska gränssnitt - i form av sin inbyggda ASF-ui skal, men vi kommer ner till den delen i rätt tid - vi bara nämna detta direkt så att du inte kommer att få panik när du ser svart konsolskärm eller något.

När du får ASF binära filer, programmet kommer att kräva konfiguration från dig, vilket anger exakt vad du förväntar dig för ASF att uppnå. Du kan starta programmet utan konfiguration, i detta fall ASF kommer att starta i standardinställningar, så att du kan använda e. . ASF-ui för den första konfigurationen, men annat än att det inte kommer att göra mycket utan din tidigare åtgärd.

Det kommer att göra för tillfället, låt oss börja!

---

## OS-specifik konfiguration

I allmänhet är här vad vi ska göra under de närmaste minuterna:
- Vi installerar **[.NET-förutsättningar](#net-prerequisites)**.
- Då kommer vi att ladda ner **[senaste ASF utgåva](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** i lämplig OS-specifik variant.
- Därefter kommer vi att extrahera arkivet till ny plats.
- Då kommer vi att **[konfigurera ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- Och slutligen, kommer vi att lansera ASF och se dess magi.

Några av stegen är självförklarande, andra kommer att kräva mer uppmärksamhet från er. Oroa dig inte, vi har dig täckt.

---

### .NET förutsättningar

Första steget är att se till att ditt OS kan även starta ASF ordentligt. Du behöver inte veta det, men ASF är skriven i C#, baserat på . ET-plattformen och kan kräva att det finns bibliotek som ännu inte är tillgängliga på din plattform. Tänk på det som DirectX för 3D-spel, eller motor för att starta din bil.

Beroende på om du använder Windows, Linux eller macOS, kommer du att ha olika krav. Referensdokumentet är **[. ET-förutsättningar](https://docs.microsoft.com/dotnet/core/install)**, men för enkelhetens skull har vi också detaljerat alla nödvändiga paket nedan, så du behöver inte läsa det överhuvudtaget, om du inte stöter på problem eller om du har ytterligare frågor.

Det är helt normalt att vissa (eller till och med alla) beroenden redan finns på ditt system på grund av att installeras av programvara från tredje part som du använder. Ändå behöver det inte vara så, så du bör köra lämpligt installationsprogram för ditt OS - utan dessa beroenden ASF kommer inte starta alls, och du får knappt någon användbar information för att berätta vad som är fel.

Tänk på att du inte behöver göra något annat för OS-specifika byggen, särskilt att installera . ET SDK eller till och med runtime, eftersom OS-specifika paket redan innehåller allt detta. Du behöver endast .NET-förutsättningar (beroenden) för att köras. ET runtime ingår i ASF - så bara de saker som vi anger nedan, utan några andra tillägg.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** för 64-bit, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** för 32-bit eller **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** för 64-bitars ARM)
- Det rekommenderas starkt att se till att alla Windows-uppdateringar redan är installerade. Om du inte har dem aktiverade, då åtminstone behöver du **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** och **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, men fler uppdateringar kan behövas. Du behöver inte oroa dig för att om ditt Windows är uppdaterat, eller åtminstone nyligen nog.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Paketnamn beror på den Linuxdistribution som du använder, vi har listat de vanligaste. Du kan få alla med pakethanterare för ditt operativsystem (t.ex. `apt` för Debian eller `yum` för CentOS). De är ganska standard bibliotek som bör vara tillgängliga oavsett vilken distribution du använder, Det är bara en fråga om att ta reda på hur de kallas i din miljö av val.

- `ca-certificates` (standard betrodda SSL-certifikat för att göra HTTPS-anslutningar)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, senaste versionen för din distribution, till exempel `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-libs`, senaste versionen för din distribution, åtminstone `1.1.X`)
- `libstdc++6` (`libstdc++`, i version `5.0` eller högre)
- `zlib1g` (`zlib`)

Åtminstone en majoritet av dessa bör redan vara direkt tillgängliga på ditt system. Till exempel kräver den minimala installationen av Debians stabila stabila utgåva endast `libicu76`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- Du behöver inte något specifikt, men du bör ha den senaste versionen av macOS installerad, minst 12.0+

---

### Hämtar

Eftersom vi redan har alla nödvändiga beroenden laddar vi ner **[senaste ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF finns i många varianter, men du är intresserad av paket som matchar ditt operativsystem och arkitektur. Till exempel, om du använder `64`-bit `Win`dows, så vill du ha `ASF-win-x64` paket. För mer information om tillgängliga varianter, besök **[kompatibilitet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** sektionen. ASF kan också köras i de miljöer som vi inte bygger OS-specifika paket för, såsom **32-bitars Windows**, men du behöver **[generiska inställningar](#generic-setup)** för det.

![Tillgångar](https://i.imgur.com/Ym2xPE5.png)

Efter nedladdning, börja från att extrahera zip-filen i sin egen mapp. Om du behöver ett specifikt verktyg för det, kommer **[7-zip](https://www.7-zip.org)** att göra, men alla standardverktyg som inbyggd Windows-extrahering eller `packa upp` från Linux/macOS bör fungera utan problem.

Var klokt att packa upp ASF till **sin egen katalog** och inte till någon befintlig katalog du redan använder för något annat - det är viktigt. ASF innehåller funktionen automatisk uppdateringar, som ersätter sina egna filer, och som vanligtvis kommer att ta bort alla gamla och orelaterade filer vid uppgradering, vilket i sin tur kan leda till att du förlorar något orelaterat du sätta in i ASF-katalogen. Om du har några extra skript eller filer som du vill använda med ASF, det är inte ett problem, skapa en dedikerad mapp för dem, du kan alltid sätta ASF i en mapp djupare.

En exempelstruktur kan se ut så här:

```text
C:\ASF (där du sätter dina egna saker)
    #MyNotes. xt (valfritt)
    A–─ AsfMakeMeCoffeeScript.bat (valfritt)
    A–(... (alla andra filer som du väljer, frivilligt)
    <unk> ─ Core (tillägnad endast ASF, där du extraherar arkivet)
         ─ ArchiSteamFarm(. xe)
         
-config

         -plugins

         -www 
 <unk> ● ─ (...)
```

---

### Konfiguration

Vi är nu redo att göra det allra sista steget, konfigurationen. ASF fungerar med konceptet "botar", varje bot är vanligtvis ett enda Steam-konto som du vill använda inuti ASF. Du kan deklarera så många robotar du vill, men till att börja med fokuserar vi bara på en av dem - oftast ditt huvudkonto. ASF har även konfigurationsfiler som inte är robotar, den viktigaste är den globala konfigurationsfilen, som påverkar alla robotar i exemplet.

Den allmänna tumregeln är att **om du inte vet, eller inte förstår någon inställning, du bör lämna det med dess standardvärde, utan att ändra något**. ASF erbjuder otaliga sätt att konfigurera, anpassa och justera nästan alla sina funktioner, men som nämnts ovan, försöker förstå det direkt utanför fladdermöss är ett kaninhål som snabbt kan dra dig in i svår förvirring, om inte **[rakt in i avgrunden](https://www.youtube.com/watch?v=KK3KXAECte4)**. Istället rekommenderar vi att ha ett fungerande exempel först, och först därefter börja gräva till ytterligare alternativ, med hjälp av **[konfigurationen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** sidan på wiki, medan du ändrar **en sak åt gången**.

ASF-konfiguration kan göras på flera sätt - genom vår inbyggda ASF-ui skal, en fristående webbkonfiguration generator, eller manuellt. Detta förklaras ingående i **[-konfigurationen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** -sektionen, så se till att om du vill ha mer detaljerad information. Vi kommer att använda fristående web config generator som utgångspunkt, eftersom det fungerar även om ASF-ui av någon anledning inte startar eller fungerar korrekt.

Navigera till vår **[web config generator](https://justarchinet.github.io/ASF-WebConfigGenerator)** sida med din favorit webbläsare. Vi rekommenderar Chrome eller Firefox, men det bör inte spela någon roll så länge din webbläsare fungerar för allt annat.

Efter att ha öppnat sidan, byt till "Bot" flik. Du bör nu se en sida som liknar den nedan:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Om av någon chans den version av ASF som du just har hämtat är äldre än vilken config generator är inställd att använda som standard, välj bara din ASF-version från rullgardinsmenyn. Detta kan (sällan) hända, eftersom konfigurationsgeneratorn kan användas för att generera konfigurationer till nyare (pre-release) ASF-versioner som inte har markerats som stabila ännu. Du har hämtat senaste stabila utgåvan av ASF som är verifierad för att fungera tillförlitligt, så det kan vara lite äldre än den absoluta banbrytande versionen, som helt inte är lämplig för första gången användning.

Börja från **att sätta namn på din bot** i fältet markerat som rött, som heter `namn`. Detta kan vara vilket namn du vill använda, till exempel ditt smeknamn, kontonamn, ett nummer eller något annat. Det finns bara ett ord som du inte kan använda, `ASF`, eftersom det nyckelordet är reserverat för global konfigurationsfil. Utöver det kan ditt bot namn inte börja med en punkt (ASF ignorerar avsiktligt dessa filer). Vi rekommenderar också att du undviker att använda utrymmen, du kan använda `_` som en ordseparator om det behövs - inte ett strikt krav, men du har svårt att använda ASF-kommandon annars.

Bots namn avgörs? Bra, i nästa steg, **ändra `Aktiverad` switch för att vara på**, att man definierar om din bot ska startas av ASF automatiskt efter lanseringen (av programmet). Att inte göra det kommer att orsaka ASF att ange att din bot är inaktiverad i konfigurationsfilen, och det kommer att vänta på din insats för att starta det, vilket inte är vad vi vill göra i detta exempel.

Nu finns det två känsliga egenskaper som kommer upp härnäst: `SteamLogin` och `SteamPassword`. Du kan fatta ett annat beslut här - antingen kan du sätta dina Steam-inloggningsuppgifter i dessa två egenskaper, eller så kan du besluta dig för att inte göra det, och lämna dem tomma.

ASF kräver dina inloggningsuppgifter eftersom det innehåller en egen implementering av Steam-klienten och behöver samma uppgifter för att logga in som den du använder dig av. Dina inloggningsuppgifter sparas inte någonstans utan på din dator i ASF `config` katalogen endast (när du laddar ner den genererade konfigurationen). Vår web config generator är klientbaserad applikation vilket innebär att allt du gör inuti vår fristående web config-generator webbplats körs lokalt i din webbläsare för att generera giltiga ASF-konfigurationer, utan detaljer du mata in någonsin lämnar din dator i första hand, så det finns ingen anledning att oroa sig för eventuella känsliga data läcka. Fortfarande, om du av någon anledning inte vill sätta dina referenser där, förstår vi att, och du kan lägga dem manuellt senare i genererade filer, eller utelämna dem helt och driva utan dem.

Om du bestämmer dig för att ange dina inloggningsuppgifter, kommer ASF att kunna logga in automatiskt under uppstart, som tillsammans med valfria 2FA effektivt tillåter dig att bara dubbelklicka på programmet för att köra allt. Om du bestämmer dig för att utelämna dem, då ASF kommer **be dig** att ange dessa detaljer när det behövs - det tillvägagångssättet kommer inte att spara dem någonstans, men naturligtvis ASF inte kommer att kunna fungera utan din hjälp. Det är upp till dig på vilket sätt du föredrar mer, och du kan också hitta ytterligare information i **[konfigurationen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** sektion, som vanligt.

Som en sidoanteckning, kan du också bestämma dig för att lämna bara ett fält tomt, såsom `SteamPassword`. ASF kommer då att kunna använda din inloggning automatiskt, men kommer fortfarande att be om lösenord om det behövs (liknande Steam-klienten). Om du av någon chans använder 4-siffrig föräldrapenna för att låsa upp ditt konto, vi rekommenderar också att lägga den inuti `SteamParentalPin` box, även i detta fall kan du bara lämna detta tomt, och i stället observera hur svagt det skyddet är, eftersom ASF kan också "knäcka" det själv inom några sekunder efter inloggning. Hoppsan.

Efter att ha följt med allt ovan, så återigen, **bot namn**, **aktiverat switch**, och **inloggningsuppgifter** , din webbsida kommer nu att se likadan ut som nedan:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Du kan nu trycka på "download" knappen och vår web config generator kommer att generera en ny `json` fil baserat på ditt valda namn. Spara den filen i `config` katalogen som finns i mappen där du har extraherat zip-filen i föregående steg.

Grattis! Du har precis avslutat den mycket grundläggande ASF bot konfigurationen. Det finns mycket mer att upptäcka, men nu är detta allt du behöver.

---

### Kör ASF

Jag vet att du har väntat på detta ögonblick, och vi kan inte hålla dig längre, som du nu är redo att starta programmet för första gången. Dubbelklicka på `ArchiSteamFarm` binär i ASF-katalogen. Du kan också starta den från konsolen.

Nu skulle vara en bra tid att granska vår **[fjärrkommunikation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** avsnitt om du är bekymrad över saker som ASF är programmerad att göra, särskilt åtgärder som det kommer att ta i ditt namn, såsom att gå med i vår Steam-grupp som standard. Du kan alltid inaktivera valda funktioner senare om du inte gillar dem, ASF kommer helt enkelt med förnuftiga standarder, och vi var tvungna att fatta beslut om allmän användning som gäller för majoriteten av vår användarbas, liksom vår egen syn på programmet i dess princip.

Förutsatt att allt gick bra, vilket oftast överväger att installera alla nödvändiga beroenden i det första steget, och konfigurera ASF i den tredje, ASF bör starta ordentligt, upptäcka din första bot och försöka logga in:

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF kommer sannolikt fortfarande att kräva ytterligare en detalj från dig - 2FA för att komma åt kontot (om du inte inaktiverat SteamGuard helt, sedan nej). Följ helt enkelt instruktionerna på skärmen, du kan ange kod från autentiserare/e-post, eller acceptera bekräftelsen i mobilappen.

Något gick fel?

#### ASF startar inte alls, inget konsolfönster

Antingen saknas .NET förutsättningar, eller så har du hämtat en felaktig variant av ASF för din maskin. Om du inte vet vad som är fel, kolla vår **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** för ett möjligt sätt att ta reda på exakta problem, och om du fortfarande har fastnat kan du nå vår **[support](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### Inga robotar definierade

Du satte inte genererad konfiguration i `config` -katalogen. Några andra vanliga misstag i detta steg kan vara att manuellt byta tillägg från `.json` t.ex. till `. xt`och vissa operativsystem (t.ex. Windows) gillar att dölja vanliga tillägg som standard, så se till att din fil är på lämplig plats och även med lämpligt namn.

#### Startar inte denna bot eftersom den är inaktiverad i konfigurationsfilen

Du glömde att vända `aktiverad` switch som säger till ASF att starta din bot automatiskt. Såvida det inte var din avsikt naturligtvis, men då bör du redan veta hur man utför kommandon, helt enkelt `starta` din bot efter det meddelandet.

#### `Ogiltigt lösenord`

Dina inloggningsuppgifter är sannolikt fel. Kontrollera din `SteamLogin` och `SteamPassword` i den genererade konfigurationen, om de har fel, korrigera dem genom att gå tillbaka till konfigurationssteget. Om du fortfarande har problem, försök att använda samma inloggningsuppgifter i din egen Steam-klient - du bör också misslyckas med att logga in, och kanske får du mer information om vad som är fel på det här sättet.

#### Allt bra?

Efter att ha passerat den första inloggningsgaten, förutsatt att dina uppgifter är korrekta, kommer du att logga in, och ASF kommer att börja odla med standardinställningar som du inte rörde från och med nu:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Detta bevisar att ASF nu framgångsrikt gör sitt jobb på ditt konto, så att du nu kan minimera programmet och göra något annat. Gå vidare, du förtjänade det, kanske fylla på den dryck du vill ha!

Jordbrukskort är ett ämne för en annan lång artikel som denna, men i princip: efter tillräckligt med tid (beroende på **[prestanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), Du kommer att se Steam-handelskort långsamt släppas. Naturligtvis, för att det ska hända måste du ha giltiga spel till gården, visar som "du kan få X fler kort droppar från att spela detta spel" på din **[märken sida](https://steamcommunity.com/my/badges)** - om det inte finns spel på gården, då kommer ASF att uppge att det inte finns något att göra, som anges i vår **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, som svarar på den vanligaste frågan folk har vid denna tidpunkt, undrar varför trots att äga jättestor 14 spel på sitt konto, ASF hävdar att det finns inget att göra - nej, det är inte en bugg.

Detta avslutar vår mycket grundläggande installationsguide. Precis som i alla RPG spel har du avslutat handledningen, och vi lämnar dig hela ASF världen att utforska nu. Till exempel kan du nu bestämma om du vill konfigurera ASF ytterligare, eller låta det göra sitt jobb i standardinställningar. Vi kommer att täcka några mer grundläggande detaljer om du vill läsa lite mer, sedan lämna dig hela wiki för upptäckt.

---

### Utökad konfiguration

#### Jordbruk flera konton samtidigt

ASF stöder jordbruket mer än en hänsyn åt gången, vilket är dess primära funktion. Du kan lägga till fler konton till ASF genom att generera fler bot konfigurationsfiler, på exakt samma sätt som du har genererat din första för bara några minuter sedan. Du behöver bara se till två saker:

- Unikt bot namn, om du redan har din första bot som heter `MainAccount`, kan du inte ha en annan med samma namn.
- Giltiga inloggningsuppgifter som `SteamLogin`, `SteamPassword` och `SteamParentalCode` (om du har bestämt dig för att fylla dem)

Med andra ord, helt enkelt hoppa till konfigurationen igen och göra exakt samma sak, bara för ditt andra eller tredje konto. Kom ihåg att använda unika namn för alla dina robotar, för att inte skriva över befintliga konfigurationer.

---

#### Ändrar inställningar

I vår fristående webbkonfigurationsgenerator ändrar du befintliga inställningar på exakt samma sätt - genom att generera en ny konfigurationsfil. Klicka på "växla avancerade inställningar" och se vad som finns där för dig att upptäcka. I det här exemplet kommer vi att ändra `CustomGamePlayedWhileFarming` inställning, vilket gör att du kan ställa in anpassade namn som visas när ASF är jordbruk, istället för att visa faktiska spelet.

Låt oss analysera detta lite först. Om du kör ASF och börjar odla, ser du i standardinställningarna att ditt Steam-konto är i spel nu:

![Ånga](https://i.imgur.com/1VCDrGC.png)

Det är vettigt, efter allt ASF just berättade Steam-plattformen att vi spelar spelet, vi behöver kort från det, eller hur? Men hey, vi kan anpassa detta! Växla avancerade inställningar om du inte har gjort det ännu, sedan hitta `CustomGamePlayedWhileFarming`. Lägg helt enkelt in en anpassad text som du vill visa där, till exempel "Idlingkort":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Ladda nu ner den nya konfigurationsfilen på exakt samma sätt, sedan skriver **över** din gamla konfigurationsfil med en ny. Du kan också ta bort din gamla konfigurationsfil och sätta den nya i dess ställe förstås.

ASF är ganska smart och det bör noteras att du har ändrat konfigurationen, som det sedan ska automatiskt plocka upp och tillämpa, utan ett program omstart. Om du av någon chans som inte hände, kan du helt enkelt starta om programmet för att se till att din nya konfiguration plockas upp. Efter att ha gjort det, bör du märka att ASF nu visar din anpassade text på föregående plats:

![Ånga 2](https://i.imgur.com/vZg0G8P.png)

Detta bekräftar att du har redigerat din konfiguration. På exakt samma sätt kan du ändra globala ASF-egenskaper, genom att byta från bot flik till "ASF" flik, ladda ner genererade `ASF. son` konfigurationsfil och sätta den i din `config` katalog.

Redigering av dina ASF-konfigurationer kan göras mycket enklare genom att använda vår ASF-ui skal som kommer att förklaras vidare nedan.

---

#### Använder ASF-ui

Som vi nämnde tidigare, ASF är en konsolapp och startar inte ett grafiskt användargränssnitt som standard. Vi arbetar dock aktivt med **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** frontend till vårt IPC-gränssnitt, som kan vara ett mycket anständigt och användarvänligt sätt att komma åt olika ASF-funktioner.

För att använda ASF-ui måste du ha `IPC` aktiverat, vilket är standardalternativet, så om du inte manuellt inaktiverat det, det är redan aktivt. När du startar ASF, bör du kunna bekräfta att det startade korrekt IPC-gränssnittet automatiskt:

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC, i ett nötskal, är inbyggd ASF webbserver som startar lokalt på din maskin, så att du kan interagera med den med hjälp av din favoritwebbläsare. Förutsatt att det startade på rätt sätt kan du komma åt ASF:s IPC-gränssnitt genom att klicka på **[denna](http://localhost:1242)** -länk, så länge ASF körs, från samma maskin. Du kan använda ASF-ui för olika ändamål, t.ex. redigera konfigurationsfilerna på plats eller skicka kommandon **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Ta gärna en titt runt för att ta reda på alla ASF-ui funktioner.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Summary

Du har framgångsrikt konfigurerat ASF för att använda ditt Steam-konto och du har redan anpassat det efter dina önskemål. Om du följde hela vår guide, så lyckades du också justera ASF genom vårt ASF-ui gränssnitt och började upptäcka dess funktioner. Detta avslutar vår tutorial, men vi lämnar dig med några ytterligare pekare till saker som du kan vara intresserad av, "sidouppdrag", om du insisterar:

- Vår **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** förklarar för dig vad **alla** de olika inställningar du har sett faktiskt gör, och vad ASF kan erbjuda dig. Kom bara ihåg att återfukta ordentligt medan du läser, du har blivit varnad.
- Om du har snubblat på något problem eller har någon generisk fråga, tänk på vår **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**, som ska omfatta alla, eller åtminstone en stor majoritet av frågor och frågor som du kan ha.
- Om du vill lära dig allt om ASF och hur det kan göra ditt liv enklare, bege dig till resten av **[vår wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. Använd sidofältet till höger för att välja det ämne som intresserar dig.
- Och slutligen, Om du fick reda på vårt program för att vara användbart för dig och du uppskattar den massiva mängd arbete som lades i det, Du kan också överväga en liten **[donation](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** till vår sak. ASF är arbete av kärlek, vi har arbetat hårt på vår lediga tid under de senaste 10+ åren för att göra denna erfarenhet möjlig för dig, och vi är mycket stolta över det - även $ 1 är mycket uppskattat och visar att du bryr dig. I vilket fall som helst, ha massor av roligt!

---

## Generisk inställning

Denna bilaga är till för avancerade användare som vill ställa in ASF att köras i **[generisk](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)** -variant. Samtidigt som den är mer besvärlig i användning än **[OS-specifika varianter](#os-specific-setup)**kommer den också med ytterligare fördelar.

Du vill använda `generisk` variant huvudsakligen när:
- Du använder OS som vi inte bygger OS-specifika paket för (till exempel 32-bitars Windows)
- Du har redan .NET Runtime/SDK, eller vill installera och använda en
- Du vill minimera ASF struktur storlek och minnesavtryck genom att hantera körtidskrav själv
- Du vill använda en anpassad **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** som kräver en `generisk` inställning av ASF för att köras korrekt (på grund av saknade inhemska beroenden)

Naturligtvis kan du använda det också i alla andra scenarier du vill, men ovanstående är mest meningsfullt.

Kom dock ihåg att generisk installation kommer med en twist - **you** är ansvarig för .NET runtime i detta fall. Detta innebär att om din .NET SDK (körtid) inte är tillgänglig, föråldrad eller trasig, ASF helt enkelt inte fungerar. Det är därför vi rekommenderar helt inte denna inställning för casual användare, eftersom du nu måste se till att din . ET SDK (runtime) matchar ASF krav och kan köra ASF, i motsats till **oss** se till att vår . ET runtime tillsammans med ASF kan göra det.

För `generiska` -paket kan du följa hela OS-specifika guide ovan, med endast två små ändringar. Förutom att installera .NET förutsättningar, du vill också installera .NET SDK, och istället för att ladda ner och ha OS-specifika `ArchiSteamFarm(. xe)` körbar fil, du laddar nu ner och har en generisk `ArchiSteamFarm.dll` binärt format. Allt annat är exakt detsamma.

Med extra steg:
- Installera **[.NET-förutsättningar](#net-prerequisites)**.
- Installera **[.NET SDK](https://www.microsoft.com/net/download)** (eller åtminstone ASP.NET Core och .NET runtimes) som är lämpliga för ditt OS. Du vill troligtvis använda ett installationsprogram. Se **[körtidskrav](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** om du inte är säker på vilken version du ska installera.
- Ladda ner **[senaste ASF utgåva](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** i `generisk` variant.
- Extrahera arkivet till ny plats.
- **[Konfigurera ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, på exakt samma sätt som beskrivits ovan.
- Starta ASF genom att antingen använda ett hjälpskript eller köra `dotnet /path/to/ArchiSteamFarm.dll` manuellt från ditt favoritskal.

Generisk variant av ASF har inte maskinspecifik binär, efter allt det kallas `generisk` av en anledning - det är plattform-agnostic bygga som kan fungera överallt, så förvänta dig inte `exe` -fil där.

Det är därför vi har buntat det med hjälpskript (såsom `ArchiSteamFarm.cmd` för Windows och `ArchiSteamFarm. h` för Linux/macOS), som finns bredvid `ArchiSteamFarm.dll` binär. Du kan använda dem om du inte vill köra kommandot `dotnet` manuellt.

Självklart fungerar inte hjälpskript om du inte installerade. ET SDK och du har inte `dotnet` körbar i din `PATH`. De är också helt valfria att använda, kan du alltid `dotnet /path/to/ArchiSteamFarm. ll` manuellt om du vill, som under huven med några extra tweaks, det är precis vad dessa skript gör ändå.