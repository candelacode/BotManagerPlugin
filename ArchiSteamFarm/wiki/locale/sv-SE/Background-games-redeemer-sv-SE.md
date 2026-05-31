# Bakgrund spel inlösare

Bakgrundsspel inlösare är en speciell inbyggd ASF-funktion som låter dig importera givna uppsättning Steam cd-nycklar (tillsammans med deras namn) som ska lösas in i bakgrunden. Detta är särskilt användbart om du har en massa nycklar att lösa in och du är garanterad att träffa `RateLimited` **[status](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)** innan du är klar med hela ditt parti.

Bakgrundsspel återlösare görs för att ha en enda bot omfattning, vilket innebär att det inte använder `LösningPreferences`. Denna funktion kan användas tillsammans med (eller istället av) `lösa in` **[-kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, om det behövs.

---

## Importera

Importprocessen kan göras på två sätt - antingen genom att använda en fil eller IPC.

### Fil

ASF kommer att känna igen i sin `config` katalog en fil som heter `BotName.keys` där `BotName` är namnet på din bot. Den filen har förväntat och fast struktur av namnet på spelet med cd-nyckel, separeras från varandra med en flikkaraktär och slutar med en ny rad för att indikera nästa post. Om flera flikar används, då första posten anses spelets namn, efterpost anses vara en cd-nyckel, och allt mellan ignoreras. Till exempel:

```text
POSTAL 2 ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
En vecka av cirkus Terror POIUY-KJHGD-QWERT
Terraria ThisIsIgnored ThisIsIgnoredToo ZXCVB-ASDFG-QWERT
```

Alternativt kan du också använda nycklar endast format (fortfarande med en ny linje mellan varje post). ASF kommer i detta fall att använda Steams svar (om möjligt) för att fylla i rätt namn. För alla typer av tangenter märkning, rekommenderar vi att du namnger dina nycklar själv, som paket som löses in på Steam behöver inte följa logik i spel som de aktiverar, så beroende på vad utvecklaren har satt upp, kan du se korrekta spelnamn, anpassade paketnamn (e. . Humble Indie Bundle 18) eller direkt fel och potentiellt även skadliga sådana (t.ex. Half-Life 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Oavsett vilket format du har bestämt dig för att hålla dig med, importerar ASF dina `nycklar` -fil, antingen vid start av bot eller senare under utförande. Efter lyckad analys av din fil och slutligen utelämna ogiltiga poster, alla ordentligt upptäckta spel kommer att läggas till i bakgrundskön, och `BotName. eys` -filen i sig kommer att tas bort från `config` -katalogen. Om ogiltiga rader hittas, kommer de att skrivas in i `BotName.keys.invalid` fil, om du vill korrigera dem och importera igen.

### IPC

Förutom att använda nycklar fil som nämns ovan, ASF exponerar också `spelToRedeemInBakgrund` **[ASF API slutpunkt](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** som kan utföras av alla IPC-verktyg, inklusive vår ASF-ui. Använda IPC kan vara mer kraftfull, eftersom du kan göra lämplig parsning själv, såsom att använda en anpassad avgränsare istället för att tvingas till en flik karaktär, eller ens införa din helt egna anpassade nycklar struktur.

---

## Kö

När spelen har importerats läggs de till i kön. ASF går automatiskt igenom sin bakgrundskö så länge bot är ansluten till Steam-nätverket, och kön är inte tom. En nyckel som försökte lösas in och inte resulterade i `RateLimited` tas bort från kön, med rätt status skriven till en fil i `config` katalogen - antingen `BotName. öga. sed` om nyckeln användes i processen (t.ex. `NoDetail`, `BadActivationCode`, `DuplicateActivationCode`), eller `BotName.keys.unused` annars. ASF använder avsiktligt ditt angivna spelnamn eftersom nyckeln inte är garanterad att få ett meningsfullt namn returnerat av Steam-nätverket - på så sätt kan du tagga dina nycklar med även anpassade namn om det behövs/önskas.

Om vårt konto träffar `RateLimited` status under processen, Kön är tillfälligt avstängd i en hel timme för att vänta på att cooldown ska försvinna. Efteråt fortsätter processen där den lämnade, tills hela kön är tom eller en annan `RateLimited` inträffar.

---

## Exempel

Låt oss anta att du har en lista på 100 nycklar. Först ska du skapa en ny `BotName.keys.new` fil i ASF `config` katalog. Vi bifogade `. ew` tillägg för att låta ASF veta att det inte ska plocka upp denna fil omedelbart det ögonblick det är skapat (eftersom det är ny tom fil, inte redo för import ännu).

Nu kan du öppna vår nya fil och kopiera klistra in listan över våra 100 nycklar där, fixa formatet om det behövs. Efter fixar vår `BotName.keys. ew` -filen kommer att ha exakt 100 (eller 101, med senaste nyraden) rader, varje rad som har en struktur av `spelnamn\tcd-nyckel\n`, där `\t` är tabb tecken och `\n` är newline.

Du är nu redo att byta namn på denna fil från `BotName.keys.new` till `BotName. eys` för att låta ASF veta att den är redo att plockas upp. I det ögonblick du gör detta, ASF automatiskt importera filen (utan behov av omstart) och ta bort den efteråt, bekräftar att alla våra spel tolkades och lades till i kön.

Istället för att använda `BotName.keys` fil, kan du också använda IPC API slutpunkt, eller till och med kombinera båda om du vill.

Efter en tid kommer `BotName.keys.used` och `BotName.keys.unused` -filer att genereras. Dessa filer innehåller resultat av vår inlösande process. Till exempel kan du byta namn på `BotName.keys.unused` till `BotName2. eys` fil och därför skicka in våra oanvända nycklar för någon annan bot, eftersom tidigare bot inte använda dessa nycklar själv. Eller så kan du helt enkelt kopiera-klistra in oanvända nycklar till någon annan fil och behålla det för senare, ditt samtal. Tänk på att när ASF går genom kön, nya poster kommer att läggas till i vår utgång `som används` och `oanvända` -filer, Därför rekommenderas det att vänta på att kön töms fullt ut innan de används. Om du absolut måste komma åt dessa filer innan kön är helt tömd, du bör först **flytta** utdatafil som du vill komma åt till någon annan katalog, **och sedan** tolka den. Detta beror på att ASF kan lägga till några nya resultat medan du gör din sak, och det kan potentiellt leda till förlust av vissa nycklar om du läser en fil med e. . 3 nycklar inuti, sedan ta bort det, helt saknas det faktum att ASF lagt 4 andra nycklar till din borttagna fil under tiden. Om du vill komma åt dessa filer, se till att flytta bort dem från ASF `config` katalogen innan du läser dem, till exempel genom att byta namn.

Det är också möjligt att lägga till extra spel att importera samtidigt som vissa spel redan finns i vår kö, genom att upprepa alla ovanstående steg. ASF kommer att lägga till våra extra poster till redan pågående kö och hantera det så småningom.

---

## Anmärkningar

Bakgrundsnycklar som löser in använder `OrderedDictionary` under huven, vilket innebär att dina cd-nycklar kommer att ha bevarad ordning som de angavs i filen (eller IPC API-samtal). Detta innebär att du kan (och bör) tillhandahålla en lista där given cd-nyckel endast kan ha direkta beroenden på cd-nycklar som anges ovan, men inte nedan. Till exempel, Detta innebär att om du har DLC `D` som kräver att spelet `G` aktiveras först, sedan cd-nyckel för spelet `G` bör **alltid** inkluderas innan cd-nyckel för DLC `D`. Likaså, om DLC `D` skulle ha beroenden på `A`, `B` och `C`, då bör alla 3 inkluderas innan (i vilken ordning, om de inte har egna beroenden).

Att inte följa schemat ovan kommer att resultera i att din DLC inte aktiveras med `DoesNotOwnRequiredApp`, även om ditt konto skulle vara berättigat till att aktivera det efter att ha gått igenom hela dess kön. Om du vill undvika detta måste du se till att din DLC alltid ingår efter basspelet i din kön.