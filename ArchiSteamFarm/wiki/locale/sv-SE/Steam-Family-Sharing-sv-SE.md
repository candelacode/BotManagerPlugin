# Steam Familjedelning

ASF stöder Steam Family Sharing - både det gamla och det nya systemet. För att förstå hur ASF arbetar med det, du bör först läsa hur **[Steam Family Sharing fungerar](https://store.steampowered.com/promotion/familysharing)**, som finns i Steam-butiken. Dessutom kan du kolla in **[nyheterna](https://store.steampowered.com/news/app/593110/view/4149575031735702628)** för kommande nya Steam Family Sharing system, som ASF också är kompatibelt med.

---

## ASF

Stöd för Steam Family Sharing funktionen i ASF är transparent, vilket innebär att det inte introducerar någon ny bot/process konfigurationsegenskaper - det fungerar ur lådan som en extra inbyggd funktionalitet.

ASF innehåller lämplig logik för att vara medveten om att bibliotek låses av familjedelande användare, därför kommer det inte att "sparka" dem ur spelsessionen på grund av att starta ett spel. ASF kommer att agera exakt samma som med primärt konto som håller lås, därför om det låset hålls antingen av din ångklient, eller av en av dina familjedelande användare, ASF kommer inte att försöka att farma, istället, det kommer att vänta på att låset ska släppas. Detta är mestadels relaterade till det gamla systemet - nya systemet tillåter dina familjedelning användare att spela andra spel än de som ASF för närvarande odlar.

Utöver ovan, efter inloggning, ASF kommer att få tillgång till dina familjedelningssystem (gamla och nya), från vilken det kommer extrahera användare (Steam-ID) tillåts att använda ditt bibliotek. Dessa användare får `FamilySharing` behörighet att använda **[kommandon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, speciellt tillåter dem att använda `pause~` kommando på bot konto som delar spel med dem, vilket gör det möjligt att pausa automatiska kort odlingsmodul för att starta ett spel som kan delas - detta gäller även det gamla systemet, men kan fortfarande användas med det nya systemet om ASF är för närvarande jordbruk spel som dina användare vill spela.

Genom att ansluta båda funktionerna som beskrivs ovan kan dina vänner till `pause~` ditt kort odlingsprocess, starta ett spel, spela så länge de vill, och sedan efter att de är klara spela, kortodlingsprocessen kommer automatiskt att återupptas av ASF. Naturligtvis är utfärda `pause~` inte behövs om ASF för närvarande inte jordbruk något aktivt, eftersom dina vänner kan starta spelet direkt, och logik som beskrivs ovan ser till att de inte kommer att sparkas ut ur sessionen.

---

## Begränsningar

Steam-nätverket älskar att vilseleda ASF genom att sända falska statusuppdateringar, vilket kan leda till ASF tror att det är bra att återuppta processen, och i resultatet sparka din vän för snart. Detta är exakt samma fråga som den som redan förklarats av oss i **[denna FAQ post](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. Vi rekommenderar exakt samma lösningar, Främst att marknadsföra dina vänner till `Operator` tillstånd (eller högre) och säga till dem att använda `paus` och `återuppta` kommandon.