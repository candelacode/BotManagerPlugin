# Säkerhet

## Kryptering

ASF stöder för närvarande följande krypteringsmetoder som en definition av `ECryptoMethod`:

| Värde | Namn                      |
| ----- | ------------------------- |
| 0     | Oformaterad text          |
| 1     | AES                       |
| 2     | SkyddadDataForCurrentUser |
| 3     | Miljövariabel             |
| 4     | Fil                       |

Den exakta beskrivningen och jämförelsen av dem finns nedan.

### Inställning

För att generera krypterat lösenord, t.ex. för `SteamPassword` användning, du bör köra `kryptera` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** med lämplig kryptering som du valde och ditt ursprungliga lösenord för ren text. Efteråt, sätta den krypterade strängen som du har som `SteamPassword` bot config egendom, och slutligen ändra `PasswordFormat` till den som matchar din valda krypteringsmetod. Vissa format kräver inte kommandot `kryptera` , till exempel `EnvironmentVariable` eller `File`, bara sätta lämplig sökväg för dem.

---

### `Oformaterad text`

Detta är det enklaste och mest osäkra sättet att lagra ett lösenord, definierat som `ECryptoMethod` av `0`. ASF förväntar sig att strängen är en ren text - ett lösenord i sin direkta form. Det är den enklaste att använda och 100% kompatibel med alla inställningar, därför är det ett standardsätt att lagra hemligheter, helt osäker för säker förvaring.

---

### `AES`

Anses vara säker av dagens standarder, **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** sätt att lagra lösenordet definieras som `ECryptoMethod` av `1`. ASF förväntar sig att strängen är en **[base64-kodad](https://en.wikipedia.org/wiki/Base64)** -sekvens av tecken som resulterar i AES-krypterad byte array efter översättning, som sedan bör dekrypteras med inkluderad **[initialiseringsvektor](https://en.wikipedia.org/wiki/Initialization_vector)** och ASF krypteringsnyckel.

Metoden ovan garanterar säkerhet så länge som angripare inte vet ASF-krypteringsnyckel som används för dekryptering samt kryptering av lösenord. ASF låter dig ange nyckel via `--cryptkey` **[kommandoradsargumentet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**som du bör använda för maximal säkerhet. Om du väljer att utelämna det, ASF kommer att använda sin egen nyckel som är **känd** och hårdkodad i programmet, vilket innebär att vem som helst kan vända ASF-kryptering och få dekrypterat lösenord. Det kräver fortfarande en viss ansträngning och är inte så lätt att göra, men möjligt, Det är därför du nästan alltid bör använda `AES` kryptering med din egen `--cryptkey` som hålls i hemlighet. AES-metod som används i ASF ger säkerhet som bör vara tillfredsställande, och det är en balans mellan enkelhet av `PlainText` och komplexitet av `ProtectedDataForCurrentUser`, men det rekommenderas starkt att använda den med anpassad `--cryptkey`.

Om den används korrekt (lång, anpassad `--cryptkey`), garanterar mycket hög säkerhet för säker lagring.

---

### `SkyddadDataForCurrentUser`

Anses vara säker av dagens standarder, **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** sätt att lagra lösenordet definieras som `ECryptoMethod` av `2`. Den stora fördelen med denna metod är samtidigt den stora nackdelen - istället för att använda krypteringsnyckel (som i `AES`), data krypteras med inloggningsuppgifter för närvarande inloggad användare, vilket innebär att det är möjligt att dekryptera data **endast** på maskinen den var krypterad på, och dessutom **endast** av användaren som utfärdade krypteringen.

Detta säkerställer att även om du skickar hela din `Bot. son` med krypterad `SteamPassword` med denna metod till någon annan, de kommer inte att kunna dekryptera lösenordet utan direkt tillgång till din dator. Detta är en utmärkt säkerhetsåtgärd, men samtidigt en stor nackdel med att vara minst kompatibel, som lösenord krypterat med denna metod kommer att vara inkompatibel med alla andra användare samt maskin - inklusive **din egen** om du väljer att e. . installera om ditt operativsystem. Detta är den rekommenderade metoden om du inte behöver komma åt dina konfigurationer från någon annan maskin än din egen, och att du inte heller behöver cross-maskin kompatibilitet.

**Observera att detta alternativ endast är tillgängligt för maskiner som kör Windows OS från och med nu.**

---

### `Miljövariabel`

Minnesbaserad lagring definierad som `ECryptoMethod` av `3`. ASF kommer att läsa lösenordet från miljövariabeln med angivet namn som anges i lösenordsfältet (t.ex. `SteamPassword`). Till exempel, inställning `SteamPassword` till `ASF_PASSWORD_MYACCOUNT` och `PasswordFormat` till `3` kommer att få ASF att utvärdera `${ASF_PASSWORD_MYACCOUNT}` miljövariabel och använda vad som än är tilldelat det som kontolösenord.

Kom ihåg att se till att miljövariabler i ASF-processen inte är tillgängliga för obehöriga användare, som det besegrar hela syftet med att använda denna metod.

---

### `Fil`

Filbaserad lagring (möjligen utanför ASF-konfigurationskatalogen) definierad som `ECryptoMethod` av `4`. ASF kommer att läsa lösenordet från den sökväg som anges i lösenordsfältet (t.ex. `SteamPassword`). Den angivna sökvägen kan vara antingen absolut, eller relativ till ASF:s "hem"-plats (mappen med `config` -katalog inuti, med beaktande av `--path` **[kommandoradsargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). Denna metod kan användas till exempel med **[Docker hemligheter](https://docs.docker.com/engine/swarm/secrets)**, som skapar sådana filer för användning, men kan också användas utanför Docker om du skapar lämplig fil själv. Sätt till exempel `SteamPassword` till `/etc/secrets/MyAccount. ass` och `PasswordFormat` till `4` kommer att få ASF att läsa `/etc/secrets/MyAccount. ass` och använd det som står skrivet till den filen som kontots lösenord.

Kom ihåg att se till att filen som innehåller lösenordet inte är läsbar för obehöriga användare, eftersom det besegrar hela syftet med att använda denna metod.

---

## Rekommendationer för kryptering

Om kompatibilitet inte är ett problem för dig, och du är bra med hur `ProtectedDataForCurrentUser` metod fungerar, det är **rekommenderade** alternativet att lagra lösenordet i ASF, eftersom det ger den bästa säkerheten och bekvämligheten. `AES` metod är ett bra val för människor som fortfarande vill använda sina konfigurationer på alla maskiner de vill, medan `ren text` är det enklaste sättet att lagra lösenordet, om du inte har något emot att någon kan titta in i JSON konfigurationsfil för det.

Kom ihåg att alla krypteringsmetoder anses vara **osäker** om angriparen har tillgång till din dator. ASF måste kunna dekryptera krypterade lösenord, och om programmet körs på din maskin är kapabel att göra det, då något annat program som körs på samma maskin kommer att kunna göra det, också. `ProtectedDataForCurrentUser` är den säkraste varianten som **även andra användare som använder samma PC kommer inte att kunna dekryptera den**, men det är fortfarande möjligt att dekryptera data om någon kan stjäla dina inloggningsuppgifter och maskininformation utöver ASF-konfigurationsfil.

För avancerade konfigurationer kan du använda `EnvironmentVariable` och `File`. De har begränsad användbarhet, `EnvironmentVariable` kommer att vara en bra idé om du föredrar att få lösenord genom någon form av anpassad lösning och lagra det i minnet exklusivt, medan `fil` är bra till exempel med **[Docker hemligheter](https://docs.docker.com/engine/swarm/secrets)**. Båda är okrypterade dock, så du i princip flytta risken från ASF-konfigurationsfilen till vad du väljer från dessa två.

Förutom krypteringsmetoder som anges ovan, är det möjligt att också undvika att ange lösenord helt, till exempel som `SteamPassword` genom att använda en tom sträng eller `null` värde. ASF kommer att be dig om ditt lösenord när det krävs, och kommer inte att spara det någonstans utan hålla i minnet av den pågående processen, tills du stänger den. Medan de är den säkraste metoden att hantera lösenord (de sparas inte någonstans), är också den mest besvärliga eftersom du behöver ange ditt lösenord manuellt på varje ASF kör (när det krävs). Om det inte är ett problem för dig, är detta din bästa insats säkerhetsmässigt, eftersom du inte kan läcka något som inte existerar.

---

## Dekryptering

ASF stöder inte något sätt att dekryptera redan krypterade lösenord, eftersom dekrypteringsmetoder endast används internt för att komma åt data i processen. Om du vill återställa krypteringsproceduren t.ex. för att flytta ASF till annan maskin när du använder `ProtectedDataForCurrentUser`, sedan helt enkelt upprepa proceduren från början i den nya miljön.

---

## Hashning

ASF stöder för närvarande följande hashingmetoder som en definition av `EHashingMethod`:

| Värde | Namn             |
| ----- | ---------------- |
| 0     | Oformaterad text |
| 1     | SCrypt           |
| 2     | Pbkdf2           |

Den exakta beskrivningen och jämförelsen av dem finns nedan.

### Inställning

För att generera en hash, t.ex. för `IPCPassword` användning, du bör köra `hash` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** med lämplig hashmetod som du valde och ditt ursprungliga lösenord i vanlig text. Efteråt, sätta den hashade strängen som du har som `IPCPassword` ASF config egendom, och slutligen ändra `IPCPasswordFormat` till den som matchar din valda hashingmetod.

---

### `Oformaterad text`

Detta är det enklaste och mest osäkra sättet att hasha ett lösenord, definierat som `EHashingMethod` av `0`. ASF kommer generera hash som matchar den ursprungliga inmatningen. Det är den enklaste att använda och 100% kompatibel med alla inställningar, därför är det ett standardsätt att lagra hemligheter, helt osäker för säker förvaring.

---

### `SCrypt`

Anses vara säker av dagens standarder, **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** sätt att hasha lösenordet definieras som `EHashingMethod` av `1`. ASF kommer att använda `SCrypt` implementationen med `8` block, `8192` iterationer, `32` hashlängd och krypteringsnyckel som ett salt för att generera utbudet av bytes. Den resulterande bytes kommer då att kodas som **[base64](https://en.wikipedia.org/wiki/Base64)** sträng.

ASF låter dig ange salt för denna metod via `--cryptkey` **[kommandoradsargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, som du bör använda för maximal säkerhet. Om du väljer att utelämna det, ASF kommer att använda sin egen nyckel som är **känd** och hårdkodad i programmet, betyder hashning kommer att vara mindre säker.

Om den används korrekt (anpassat salt, långt lösenord), garanterar mycket hög säkerhet för säker förvaring.

---

### `Pbkdf2`

Anses vara svag av dagens standarder, **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** sätt att hasha lösenordet definieras som `EHashingMethod` av `2`. ASF kommer att använda `Pbkdf2` implementationen med `10000` iterationer, `32` hashlängd och krypteringsnyckel som salt, med `SHA-256` som en hmacalgoritm. Den resulterande bytes kommer då att kodas som **[base64](https://en.wikipedia.org/wiki/Base64)** sträng.

ASF låter dig ange salt för denna metod via `--cryptkey` **[kommandoradsargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, som du bör använda för maximal säkerhet. Om du väljer att utelämna det, ASF kommer att använda sin egen nyckel som är **känd** och hårdkodad i programmet, betyder hashning kommer att vara mindre säker.

---

## Hashing rekommendationer

Om du vill använda en hashmetod för att lagra vissa hemligheter, såsom `IPCPassword`, vi rekommenderar att använda `SCrypt` med anpassat salt, eftersom det ger en mycket anständig säkerhet mot brutaldrivande försök.

`Pbkdf2` erbjuds endast av kompatibilitetsskäl, främst eftersom vi redan har en fungerande (och behövs) implementering av det för andra användningsfall över Steam-plattformen (e. . Föräldrastift). Den anses fortfarande vara säker, men svag jämfört med alternativ (t.ex. `SCrypt`).