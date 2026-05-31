# Utökad FAQ

Vår utökade FAQ täcker lite mindre vanliga frågor och svar som du kan ha. För mer vanliga frågor, besök vår **[grundläggande FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)** istället.

---

### Vem har skapat ASF?

ASF skapades av **[Archi](https://github.com/JustArchi)** i oktober 2015. Om du undrar, Jag är en **[Steam-användare](https://steamcommunity.com/profiles/76561198006963719)** precis som du. Bortsett från att spela spel, Jag älskar också att sätta mina färdigheter och beslutsamhet att använda, som du kan utforska just nu. Det finns inget stort företag inblandat här, inget team av utvecklare och ingen $ 1M budget för att täcka allt detta - bara mig, fastställande saker som inte är bruten.

ASF är dock projekt med öppen källkod, och jag kan inte uttrycka tillräckligt att jag inte är bakom allt som du kan se här. Vi har några **[andra](https://github.com/JustArchiNET?q=ASF-)** ASF-projekt som utvecklas nästan uteslutande av andra utvecklare. Även kärnprojektet ASF har en hel del **[bidragsgivare](https://github.com/JustArchiNET/ArchiSteamFarm/graphs/contributors)** som hjälpte mig att få allt detta att hända. Dessutom finns det flera tredjepartstjänster som stöder ASF-utveckling, särskilt **[GitHub](https://github.com)**, **[JetBrains](https://www.jetbrains.com)** och **[Crowdin](https://crowdin.com)**. Du kan också inte glömma alla fantastiska bibliotek och verktyg som gjorde ASF hända, såsom **[Rider](https://www.jetbrains.com/rider)** som vi använder som IDE (vi älskar **[ReSharper](https://www.jetbrains.com/resharper)** tillägg) och särskilt **[SteamKit2](https://github.com/SteamRE/SteamKit)** utan vilken ASF inte skulle existera i första hand. ASF skulle inte heller vara där det är idag utan mina **[sponsorer](https://github.com/sponsors/JustArchi)** och olika donatorer, stödja mig i allt jag gör här.

Tack alla för att hjälpa i ASF utveckling! Du är fantastisk :heart:.

---

### Varför skapades ASF i första hand?

ASF skapades med primärt syfte att vara helt automatiserat Steam-odlingsverktyg för Linux, utan behov av externa beroenden (såsom Steam-klient). Faktum är att detta fortfarande är dess främsta syfte och fokus, eftersom mitt koncept av ASF inte förändrats sedan dess och jag fortfarande använder det på exakt samma sätt som jag använde det redan 2015. Naturligtvis fanns det verkligen **en hel del** av förändringar sedan dess, och jag är mycket glad att se hur långt ASF har framskridit mestadels tack vare sina användare, eftersom jag aldrig skulle koda ens hälften av funktionerna om det var för mig själv.

Det är trevligt att notera att ASF aldrig gjordes för att konkurrera med andra, liknande program, speciellt **[Idle Master](https://www.steamidlemaster.com)**, eftersom ASF aldrig har utformats för att vara en skrivbord/användarapp, och det är fortfarande inte idag. Om du analyserar det primära syftet med ASF som beskrivs ovan, då kommer du att se hur Idle master är **den raka motsatsen** av allt detta. Även om du kan definitivt hitta liknande ASF-program idag, ingenting var bra nog för mig då (och fortfarande inte idag), så jag skapade min egen programvara, som jag ville ha det. Med tiden har användare migrerat till ASF främst på grund av robusthet, stabilitet och säkerhet, men också alla funktioner som jag har utvecklat under alla dessa år. Idag är ASF bättre än någonsin tidigare.

---

### OK, var är fångsten? Vad tjänar du på att dela ASF?

Det finns ingen fångst, Jag skapade ASF **för mig själv** och delade den med resten av samhället i hopp om att den ska komma till nytta. Precis samma sak hände redan 1991, när Linus Torvalds **[delade sin första Linuxkärna](https://groups.google.com/forum/#!msg/comp.os.Minix/dlNtH7RRrGA/SwRavCzVE7gJ)** med resten av världen. Det finns ingen dold skadlig kod, data mining, crypto mining eller någon annan verksamhet som skulle generera någon monetär nytta för mig. ASF-projektet stöds helt av icke-obligatoriska donationer som skickas av nöjda användare, till exempel dig. Du kan använda ASF på exakt samma sätt som jag använder det, och om du gillar det, du kan alltid köpa mig en kaffe, visar din tacksamhet för vad jag gör.

Jag använder också ASF som ett perfekt exempel på ett modernt C# projekt som alltid slår för perfektion och bästa praxis, vare sig det gäller teknik, projektledning eller själva koden. Det är min definition av "saker gjorda rätt", så om du av någon chans lyckas lära dig något nyttigt från mitt projekt, då kommer det att göra mig bara mer glad.

---

### Direkt efter lanseringen av ASF har jag förlorat alla mina konton/objekt/vänner/(...)!

Statistiskt sett, oavsett hur sorgligt det är, det är garanterat att kort efter lanseringen ASF kommer det att finnas minst en kille som kommer att dö i en bilolycka. Skillnaden är att ingen kommer att klandra ASF för att orsaka det, men av någon anledning finns det människor som kommer att anklaga ASF för samma bara för att det hände deras Steam-konton istället. Naturligtvis kan vi förstå resonemanget för det, efter allt ASF fungerar inom Steam-plattformen, så naturligt folk kommer att anklaga ASF för allt som hände med deras Steam-relaterade egendom oavsett brist på några bevis för att programvaran de körde är även avlägset ansluten med det överhuvudtaget.

ASF, som anges i **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#is-it-safe)** samt **[fråga ovan](#ok-where-is-the-catch-what-do-you-gain-from-sharing-asf)**, är fri från skadlig kod, spionprogram, data mining och annan potentiellt oönskade aktivitet, **särskilt** inlämning av dina känsliga Steam detaljer eller ta över din digitala egendom. Om något liknande har hänt dig, vi kan bara säga att vi är ledsna för din förlust och rekommenderar dig att kontakta **[Steam support](https://help.steampowered.com)** som förhoppningsvis kommer att hjälpa dig i återhämtningsprocessen - eftersom vi inte är ansvariga för vad som hände dig på något sätt och vårt samvete är tydligt. Om du tror på annat sätt, det är ditt beslut, det är meningslöst att utveckla ytterligare, om ovanstående resurser tillhandahålla objektiva och verifierbara sätt att bekräfta vårt uttalande inte övertyga dig, då är det inte som något vi skriver här kommer ändå.

Ovanstående betyder dock inte att **dina handlingar** som gjorts utan ett sunt förnuft med ASF kan inte bidra till ett säkerhetsproblem. Till exempel kan du bortse från våra säkerhetsriktlinjer, avslöja ASFs **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** gränssnitt till hela internet, och sedan bli förvånad över att någon kom in och rånade dig av alla objekt. Människor gör det hela tiden, de tror att om det inte finns någon domän eller någon anslutning till deras IP-adress så kommer ingen säkert att ta reda på deras ASF-instans. Precis som du läser det, finns det **tusentals** om inte mer helautomatiserade robotar som kryper genom webben, inklusive slumpmässiga IP-adresser, söka efter sårbarheter att upptäcka, och ASF som ett ganska populärt program är också ett mål för dem. Vi hade redan nog av människor som blev "hackade" genom sin egen dumhet sådär, så försök att lära av sina misstag och vara smartare i stället för att ansluta sig till dem.

Samma sak gäller för säkerheten på din dator. Ja, att ha skadlig kod på datorn ruinerar varje enskild säkerhetsaspekt av ASF, eftersom det kan läsa känsliga detaljer från ASF-konfigurationsfiler eller processminne och även påverka programmet att göra saker som det inte skulle göra annars. Nej, den sista spricka du har fått från tvivelaktig källa var inte en "falsk positiv" som någon har berättat för dig, Det är ett av de mest effektiva sätten att få kontroll över någons PC, människor kommer att smitta sig själva och de kommer även att följa instruktionerna hur att, fascinerande.

Är användningen av ASF helt säker och fri från alla risker då? Nej, vi skulle vara en massa hycklare som säger så, eftersom **varje** programvara har sina säkerhetsorienterade problem. I motsats till vad många företag gör, Vi försöker vara så transparenta som möjligt i våra **[säkerhetsbulletiner](https://github.com/JustArchiNET/ArchiSteamFarm/security/advisories)** och så snart vi får reda på ens en *hypotetisk* -situation där ASF på något sätt kan bidra till ett potentiellt oönskat säkerhetsperspektiv, vi tillkännager det omedelbart. Detta är vad som hände med **[CVE-2021-32794](https://github.com/JustArchiNET/ArchiSteamFarm/security/advisories/GHSA-wxx4-66c2-vj2v)** till exempel, även om ASF inte hade någon säkerhetsbrist per se, utan snarare ett fel som kunde leda till att användaren av misstag kunde skapa en.

Från och med i dag, det finns inga kända, orörda säkerhetsbrister i ASF, och eftersom programmet används av fler och fler människor av vilka både **[vita hattar](https://en.wikipedia.org/wiki/White_hat_(computer_security))** och **[svarta hattar](https://en.wikipedia.org/wiki/Black_hat_(computer_security))** analysera dess källkod, den totala förtroendefaktorn ökar bara med tiden, eftersom antalet säkerhetsbrister att ta reda på är ändligt, och ASF som ett program som fokuserar först och främst på dess säkerhet, definitivt inte gör det lätt att hitta en. Oavsett våra bästa avsikter, rekommenderar vi fortfarande att stanna cool-headed och alltid vara försiktig med potentiella säkerhetshot, de som kommer från ASF användning också.

---

### Hur verifierar jag att de nedladdade filerna är äkta?

Som en del av våra utgåvor på GitHub använder vi en mycket liknande verifieringsprocess som den som används av **[Debian](https://www.debian.org/CD/verify)**. I varje officiell utgåva, förutom `zip` bygga tillgångar, kan du hitta `SHA512SUMS` och `SHA512SUMS.sign` filer. Ladda ner dem för verifieringsändamål tillsammans med de `zip` filer som du väljer.

För det första, du bör använda `SHA512SUMS` filen för att verifiera att `SHA-512` kontrollsumman för de valda `zip` filerna matchar den vi beräknat själva. På Linux kan du använda verktyget `sha512sum` för det ändamålet.


```
$ sha512sum -c --ignore-missing SHA512SUMS
ASF-linux-x64.zip: OK
```

I Windows kan vi göra det från powershell, även om du måste verifiera manuellt med `SHA512SUMS`:

```
PS > Get-Content SHA512SUMS <unk> Select-String -Pattern ASF-linux-x64.zip

f605e573cc5e044dd6fadbc44f6643829d11360a2c6e4915b0c0b8f5227bc2a257568a014d3a2c0612fa73907641d0cea455138d2e5a97186a0b417abad45ed9 ASF-linux-x64.zip


PS > Get-FileHash -Algoritm SHA512 -Path ASF-linux-x64. ip

Algoritm Hash sökväg
--------- ---- ----
SHA512 F605E573CC5E044DD6FADBC44F6643829D11360A2C6E4915B0C0B8F5227BC2A2575... ASF-linux-x64.zip
```

På så sätt såg vi till att det som skrevs till `SHA512SUMS` matchar de resulterande filerna och de blev inte manipulerade. Det visar dock inte ännu att `SHA512SUMS` fil du kontrollerat mot verkligen kommer från oss. Det finns två sätt att verifiera detta.

Det första sättet, och även den som ASF använder för automatisk uppdatering, ringer ett samtal till vår backend-server genom att besöka `https://asf. ustArchi. et/Api/Checksum/{Version}/{Variant}` URL, ersätter `{Version}` med ASF-versionsnummer, t.ex. `6. .4.3`och `{Variant}` med din valda ASF-variant, såsom `generiska` eller `linux-x64`. Du hittar kontrollsumman i JSON-svaret, som du bör jämföra med `SHA512SUMS` och/eller ASF zip-filens artefakt. Vår server tillhandahåller endast kontrollsummor för nuvarande **[stabila](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** och **[pre-release](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** version av ASF, eftersom endast de befintliga ASFs någonsin kommer att överväga att uppdatera till.

```json
{
  "Resultat": "f605e573cc5e044dd6fadbc44f6643829d11360a2c6e4915b0c0b8f5227bc2a257568a014d3a2c0612fa73907641d0cea455138d2e5a97186a0b417abad45ed9",
  "Meddelande": "OK",
  "Framgång": sant
}
```

Det andra sättet inkluderar användning av medföljande `SHA512SUMS.sign` fil, som innehar digital PGP signatur bevisar äktheten hos `SHA512SUMS`. Eftersom bygga artefakter samt signatur genereras som en del av byggprocessen, det garanterar inte integritet i händelse av att GitHub äventyras (vilket är anledningen till att vi använder vår egen oberoende server för verifieringsändamål), men det är tillräckligt om du har hämtat ASF från okänd källa och du vill se till att det är en giltig artefakt producerad av vår GitHub-utgivningsprocess, I stället för att se till att GitHub inte komprometterades helt.

Vi kan använda verktyget `gpg` för det ändamålet, både på **[Linux](https://gnupg.org/download/index.html)** och **[Windows](https://gpg4win.org)** (ändra `gpg` kommandot till `gpg. xe` i Windows).

```
$ gpg --verify SHA512SUMS. ign SHA512SUMS
gpg: Signatur gjord mån 02 aug 2021 00:34:18 CEST
gpg: använda EDDSA nyckel 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Kan inte kontrollera signatur: Ingen offentlig nyckel
```

Som ni kan se har filen en giltig signatur, men av okänt ursprung. Du måste importera ArchiBots **[publika nyckel](https://raw.githubusercontent.com/JustArchi-ArchiBot/JustArchi-ArchiBot/main/ArchiBot_public.asc)** som vi signerar `SHA-512` summor med för full validering.

```
$ curl https://raw.githubusercontent.com/JustArchiBot/JustArchi-ArchiBot/main/ArchiBot_public.asc -o ArchiBot_public.asc
$ gpg --import ArchiBot_public.asc
gpg: /home/archi/. nupg/trustdb. pg: trustdb skapad
gpg: nyckel A3D181DF2D554CCF: publik nyckel "ArchiBot <ArchiBot@JustArchi.net>" importerade
gpg: Totalt antal bearbetade: 1
gpg: importerat: 1

```

Slutligen kan du verifiera filen `SHA512SUMS` igen:

```
$ gpg --verify SHA512SUMS. ign SHA512SUMS
gpg: Signatur gjord mån 02 aug 2021 00:34:18 CEST
gpg: använda EDDSA nyckel 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Bra signatur från "ArchiBot <ArchiBot@JustArchi.net> [unknown]
gpg: VARNING: Denna nyckel är inte certifierad med en betrodd signatur!
gpg: Det finns ingen indikation på att signaturen tillhör ägaren.
Primärt fingeravtryck: 224D A6DB 47A3 935B DCC3 BE17 A3D1 81DF 2D55 4CCF
```

Detta har verifierat att `SHA512SUMS. ign` har en giltig signatur av vår `224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF` nyckel för `SHA512SUMS` fil som du har verifierat mot.

Du kan undra var den sista varningen kommer ifrån. Du har importerat vår nyckel, men bestämde dig inte för att lita på den ännu. Även om detta inte är obligatoriskt, kan vi täcka det också. Normalt innebär detta att verifiera via annan kanal (t.ex. telefonsamtal, SMS) att nyckeln är giltig, sedan signera nyckeln med din egen att lita på den. För detta exempel, kan du överväga denna wiki post som sådan (mycket svag) olika kanal, eftersom den ursprungliga nyckeln kommer från **[ArchiBots profil](https://github.com/JustArchi-ArchiBot)**. I vilket fall som helst antar vi att du har tillräckligt med självförtroende som det är.

För det första genererar **[privat nyckel för dig själv](https://help.ubuntu.com/community/GnuPrivacyGuardHowto#Generating_an_OpenPGP_Key)**, om du inte har en ännu. Vi använder `--quick-gen-key` som ett snabbt exempel.

```
$ gpg --batch --passsphrase '' --quick-gen-key "$(whoami)"
gpg: /home/archi/.gnupg/trustdb. pg: trustdb skapade
gpg: nyckel E4E763905FAD148B markerad som ytterst betrodd
gpg: katalog '/hem/archi/. nupg/openpgp-revocs.d' skapade
gpg: återkallandecertifikat lagrat som '/hem/archi/.gnupg/openpgp-revocs.d/8E5D685F423A584569686675E4E763905FAD148B.rev'
```

Nu kan du signera vår nyckel med din för att lita på den:

```
$ gpg --sign-key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF

pub ed25519/A3D181DF2D554CCF
     skapat: 2021-05-22 expires: never usage: SC
     trust: unknown validity: unknown
sub cv25519/E527A892E05B2F38
     skapade: 2021-05-22 expires: never usage: E
[ okänd] (1). ArchiBot <ArchiBot@JustArchi.net>


pub ed25519/A3D181DF2D554CCF
     skapade: 2021-05-22 upphör att gälla: aldrig använda: SC
     tillit: okänd giltighet: okänd
 Primärt fingeravtryck: 224D A6DB 47A3 935B DCC3 BE17 A3D1 81DF 2D55 4CCF

     ArchiBot <ArchiBot@JustArchi.net>

Är du säker på att du vill signera denna nyckel med din
nyckel "archi" (E4E763905FAD148B)

Really sign? (y/N) y
```

Och klar, efter att ha litat på vår nyckel, bör `gpg` inte längre visa varningen när du kontrollerar:

```
$ gpg --verify SHA512SUMS. ign SHA512SUMS
gpg: Signatur gjord mån 02 aug 2021 00:34:18 CEST
gpg: använda EDDSA nyckel 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Bra signatur från "ArchiBot <ArchiBot@JustArchi.net>" [full]
```

Notera att `[unknown]` indikator ändras till `[full]` när du signerat vår nyckel med din.

Grattis, du har verifierat att ingen har manipulerat den release du laddat ner! 👍

---

### Det är den 1 april och ASF språket förändrades till något konstigt, vad pågår?

Grattis till RABATT på RABATT LIVSMEDEL EASTR EGG! Om du inte angav alternativet `CurrentCulture` ASF den 1 april kommer faktiskt att använda **[LOLcat](https://en.wikipedia.org/wiki/Lolcat)** språket istället för ditt systemspråk. Om du av någon chans vill inaktivera det beteendet, du kan helt enkelt ställa in `CurrentCulture` till det språk som du vill använda istället. Det är också trevligt att notera att du kan aktivera vårt påskägg villkorslöst, genom att ställa in ditt `CurrentCulture` till `qps-Ploc` värde.