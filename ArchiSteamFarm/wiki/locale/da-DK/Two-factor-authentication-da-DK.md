# To-faktor autentificering

Steam indeholder to-faktor autentificeringssystem, der kræver ekstra detaljer til forskellige kontorelaterede aktiviteter. Du kan læse mere om det **[her](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** og **[her](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. Denne side mener, at 2FA-system samt vores løsning, der integrerer med det, kaldet ASF 2FA.

---

# ASF logik

Uanset om du bruger ASF 2FA eller ej, ASF indeholder korrekt logik og er fuldt ud klar over konti, der er beskyttet af 2FA på Steam. Det vil bede dig om nødvendige detaljer, når de er nødvendige (såsom under logning ind). Mens du manuelt kan give disse oplysninger, visse ASF funktioner (såsom `MatchActively`) kræver, at ASF 2FA skal være operativ på din bot konto, som automatisk kan reagere på 2FA-prompter, automatisk, når det kræves af ASF.

---

# ASF 2FA

ASF 2FA er et indbygget modul, der er ansvarlig for at levere 2FA-funktioner til ASF-processen, såsom at generere tokens og acceptere bekræftelser. Det kan fungere enten i standalone tilstand, eller ved at duplikere dine eksisterende autentificeringsoplysninger (så du kan bruge din nuværende autentificering og ASF 2FA på samme tid).

Du kan kontrollere, om din bot konto bruger ASF 2FA allerede ved at udføre `2fa` **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Uden opsætning af ASF 2FA, vil alle standard `2fa` kommandoer være ikke-operative, hvilket betyder, at din bot er utilgængelig for avancerede ASF funktioner, der kræver, at modulet skal være operativt.

---

# Anbefalinger

Der er mange måder at gøre ASF 2FA operativ, her inkluderer vi vores anbefalinger baseret på din aktuelle situation:

- Hvis du allerede bruger uofficielle tredjeparts-app, der giver dig mulighed for at udtrække 2FA detaljer med lethed, bare **[importere](#import)** dem til ASF.
- Hvis du bruger officiel app, og du ikke har noget imod at nulstille dine 2FA-legitimationsoplysninger, er den bedste måde at deaktivere 2FA, derefter **[oprette](#creation)** nye 2FA legitimationsoplysninger ved hjælp af **[joint authenticator](#joint-authenticator)**, som giver dig mulighed for at bruge den officielle app og ASF 2FA. Denne metode **kræver ikke root**, jailbreaking eller nogen avanceret viden, næppe følgende instruktioner, der er skrevet her, og er uden tvivl overlegen i dette scenarie.
- Hvis du bruger den officielle app og ikke ønsker at genskabe dine 2FA-legitimationsoplysninger, er dine muligheder meget begrænsede, typisk skal du bruge rod og ekstra fiddling rundt til **[importere](#import)** disse detaljer, og endda med, at det kunne være umuligt.
- Hvis du ikke bruger 2FA endnu og pas på, Vi anbefaler, at du bruger ASF 2FA med **[standalone authenticator](#standalone-authenticator)** eller **[joint authenticator](#joint-authenticator)** med officiel app (samme som ovenfor).

Nedenfor diskuterer vi alle mulige muligheder og kendt af os metoder.

---

## Oprettelse

ASF leveres med et officielt `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** , der yderligere udvider ASF 2FA, giver dig mulighed for at linke en helt ny 2FA autentificering. Dette kan være nyttigt, hvis du ikke er i stand til eller uvillig til at bruge andre værktøjer og ikke noget imod ASF 2FA bliver din vigtigste (og måske kun) autentificering. Oprettelse proces bruges også i joint-authenticator metode, I dette scenario kan din autentificering naturligt eksistere to steder på én gang - begge vil generere de samme koder og begge vil være i stand til at bekræfte de samme bekræftelser.

### Fælles trin for begge scenarier

Uanset om du planlægger at bruge ASF som standalone eller joint authenticator, skal du gøre disse initialisering trin:

1. Opret en ASF bot til målkontoen, starte den og logge ind, hvilket du sandsynligvis allerede har gjort.
2. Tildel et fungerende og operationelt telefonnummer til kontoen **[her](https://store.steampowered.com/phone/manage)** , der skal bruges af boten. Dette vil give dig mulighed for at modtage SMS kode og tillade inddrivelse hvis nødvendigt. Dette trin er ikke obligatorisk i alle scenarier, men vi anbefaler det, medmindre du ved, hvad du laver.
3. Sørg for, at du endnu ikke bruger 2FA til din konto, hvis du gør det, deaktivere den først. Dette **vil** sætte din konto på midlertidig handels-hold, der er ingen vej rundt det, kun **[import](#import)** -processen kan springe den over.
4. Udfør kommandoen `2fainit [Bot]` og erstatte `[Bot]` med din bots navn.

Forudsat at du fik et vellykket svar, er følgende to ting sket:

- En ny `<Bot>.maFile.PENDING` fil blev genereret af ASF i din `config` mappe.
- SMS blev sendt fra Steam til det telefonnummer, du har tildelt til kontoen ovenfor. Hvis du ikke har angivet et telefonnummer, blev der i stedet sendt en e-mail til kontoens e-mailadresse.

Autorisationsoplysningerne er endnu ikke operationelle endnu, men du kan gennemgå den genererede fil, hvis du vil. Hvis du ønsker at være dobbelt sikker, kan du for eksempel allerede skrive tilbagekaldelseskoden ned. De næste trin vil afhænge af dit valgte scenario.

### Standalone autentificering

Hvis du ønsker at bruge ASF som din vigtigste (eller sågar kun) autentificering, nu skal du gøre det endelige afslutningstrin:

5. Udfør kommandoen `2fafinalize [Bot] <ActivationCode>` erstatte `[Bot]` med din bot's navn og `<ActivationCode>` med den kode, du har modtaget via SMS eller e-mail i det foregående trin.

### Fælles autentificering

Hvis du vil have den samme autentificering i både ASF og den officielle Steam-mobil-app, nu skal du gøre de næste, mere vanskelige trin:

5. **Ignorer** den SMS eller e-mail-kode, du har modtaget i det forrige trin.
6. Installer Steam-mobilappen, hvis den ikke er installeret endnu, og åbn den. Naviger til fanen Steam Guard og tilføj en ny autentificering ved at følge appens instruktioner.
7. Når din autentificering i mobilappen er tilføjet og fungerer, skal du vende tilbage til ASF. Nu, i stedet for afslutning, behøver vi kun at informere ASF om, at mobil app allerede aktiveret vores tidligere genererede detaljer:
 - Vent til den næste 2FA-kode vises i Steam-mobil-appen, og brug kommandoen `2fafinalized [Bot] <2FACodeFromApp>` erstatter `[Bot]` med din bots navn og `<2FACodeFromApp>` med den kode, du i øjeblikket ser i Steam-mobilappen - den samme du ville bruge til at logge ind på Steam (**IKKE** den, du allerede har brugt til aktivering). Hvis koden genereret af ASF og den kode, du har angivet, er lige, ASF vil antage, at en autentifikator blev tilføjet korrekt og fortsætte med at importere din nyoprettede autentifikator.
 - Vi anbefaler kraftigt at gøre ovenstående for at sikre, at dine legitimationsoplysninger er gyldige. Men hvis du ikke ønsker at (eller ikke kan) kontrollere, om koderne er de samme, og du ved, hvad du gør, du kan i stedet bruge kommandoen `2fafinalizedforce [Bot]`, erstatter `[Bot]` med din bots navn. ASF vil antage, at autentifikatoren blev tilføjet korrekt og fortsætte med at importere din nyoprettede autentifikator. Vær opmærksom på, at ASF i denne tilstand ikke er i stand til at kontrollere, om koderne stemmer overens hvilket betyder, at du potentielt kan importere ugyldige (ikke aktiveret) legitimationsoplysninger.

### Efter færdiggørelse

Under forudsætning af at alt fungerede korrekt, blev filen tidligere genereret `<Bot>.maFile.PENDING` omdøbt til `<Bot>.maFile.NEW`. Dette indikerer, at dine 2FA-legitimationsoplysninger nu er gyldige og aktive. Vi anbefaler, at du flytter filen uden for mappen `config` og **gemmer den på en sikker placering**. Ud over det, hvis du har besluttet at bruge standalone authenticator, så anbefaler vi, at du åbner filen i din foretrukne editor og skriver `revocation_code`ned, som giver dig mulighed for, som navnet antyder, tilbagekalde autentifikatoren i tilfælde af, at du mister den. I metoden med fælles autentificering bør du allerede have gjort det i Steam-mobilappen, men du er velkommen til at gøre det samme, hvis du har brug for det.

Med hensyn til tekniske detaljer den genererede `maFile` indeholder alle detaljer, som vi har modtaget fra Steam-serveren under sammenkædning af autentificeringen, og i tillæg hertil, feltet `device_id` , som kan være nødvendigt for andre (tredjepart) autentifikatorer hvis du nogensinde beslutter dig for at importere `maFile` til dem.

ASF importerer automatisk din autentifikator, når proceduren er færdig, og derfor `2fa` og andre relaterede kommandoer bør nu være operationelle for den bot konto, du har knyttet autentificering til. Vi anbefaler dig at bekræfte det.

---

## Importer

Import proces kræver allerede linket og operationel autentificering, der understøttes af ASF. Vi har instruktioner til et par forskellige officielle og uofficielle kilder til 2FA, oven i den manuelle metode, som giver dig mulighed for selv at give de nødvendige legitimationsoplysninger. Bemærk, at disse instruktioner kun skal bruges **** , hvis du allerede bruger given løsning - da processen her involverer tredjeparts-apps og -værktøjer, **vi anbefaler ikke at bruge dem**, og vi nævner det udelukkende for folk, der allerede besluttede at bruge dem, og vil gerne importere genererede detaljer i ASF 2FA.

Generelt indebærer importprocessen at droppe `maFile` i passende format til ASF's `config` mappe, på hvilken ASF vil afhente den pågældende fil og automatisk fjerne den af sikkerhedsmæssige årsager.

Alle følgende guider kræver fra dig, at **allerede har** -autentificering som bruges med et givet værktøj/program. ASF 2FA fungerer ikke korrekt, hvis du importerer ugyldige data, og sørg derfor for, at din autentificering fungerer korrekt, før du forsøger at importere den. Dette omfatter afprøvning og verifikation af, at følgende autentificeringsfunktioner fungerer korrekt:
- Du kan generere tokens og disse tokens accepteres af Steam-netværket (du kan logge ind med dem)
- Du kan hente bekræftelser, og de ankommer på din mobil autentificering
- Du kan reagere på disse bekræftelser, og de er korrekt genkendt af Steam-netværket som bekræftet/afvist

Sørg for, at din autentificering virker ved at tjekke, om ovenstående handlinger virker - hvis de ikke virker, så virker de heller ikke i ASF.

### Android telefon

Generelt for at importere autentificering fra din Android-telefon, skal du bruge **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))** adgang. Nedenstående instruktioner kræver fra dig temmelig anstændig viden i Android modding verden, vi er bestemt ikke kommer til at forklare hvert skridt her, besøg **[XDA](https://xdaforums.com)** og andre ressourcer til yderligere information/hjælp med nedenfor.

**Fra i dag er der ingen kendt, bekræftet ekstraktionsmetode, der fortsat virker. Du kan alligevel forsøge at følge nedenstående trin, f.eks. med forældet app-version, men vi garanterer ikke, at det vil fungere korrekt. Overvej i stedet at bruge joint-authenticator-metoden.**

<details>
  <summary>Arkivinstruktioner</summary>

Antages det, at du har officiel **[Steam app](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** arbejder og fungerer (nedenfor kræver rode din enhed):

- Installer **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** og aktivér Zygisk i indstillingerne.
- Installer **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (for Zygisk) og sørg for at det virker.
- Installer **[SteamGuardDump](https://github.com/YifePlayte/SteamGuardDump/releases/latest)** eller **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** LSPosed modul og aktivér det i LSPosed indstillinger.
- Gennemtving dræbe Steam-appen, og åbn den, bør detaljer om damp nu være tilgængelige for kopiering til udklipsholderen.

Nu, hvor du med succes har udtrukket krævede detaljer, skal du deaktivere modulet for at forhindre automatisk kopiering hver gang kopier derefter værdien af `shared_secret` og `identity_secret` af den konto, du har til hensigt at tilføje til ASF 2FA ind i en ny tekstfil med nedenstående struktur:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Erstat hver `STRING` værdi med passende privat nøgle fra udtrukne detaljer. Når du gør det, omdøbe filen til `BotName. aFile`, hvor `BotName` er navnet på din bot du tilføjer ASF 2FA til, og placer den i ASF's `config` mappe, hvis du ikke har endnu.

Start ASF, som skal bemærke din fil og importere den. Antages det, at du har importeret den korrekte fil med gyldige hemmeligheder, bør alt fungere korrekt, som du kan verificere ved hjælp af kommandoer `2fa`. Hvis du har lavet en fejl, kan du altid fjerne `Bot.db` og starte forfra, hvis det er nødvendigt.

</details>

### SteamDesktopAuthenticator

Hvis du allerede har din autentificering kører i SDA, skal du bemærke, at der er `steamID.maFile` fil tilgængelig i `maFiles` mappe. Sørg for, at `maFile` er i ukrypteret form, da ASF ikke kan dekryptere SDA filer - ukrypteret fil indhold skal starte med `{` og slutte med `}` tegn. Hvis det er nødvendigt, kan du fjerne krypteringen fra SDA indstillinger først, og aktivere det igen, når du er færdig. Når filen er i ukrypteret form, kopier den til `config` bibliotek af ASF.

Du kan nu omdøbe `steamID.maFile` til `BotName. aFile` i ASF config mappe, hvor `BotName` er navnet på din bot du tilføjer ASF 2FA til. Alternativt kan du lade det være, ASF vil derefter vælge det automatisk efter logning ind. Omdøbning af filen hjælper ASF ved at gøre det muligt at bruge ASF 2FA, før du logger ind, hvis du ikke gør det, så kan filen kun vælges, når ASF med succes logger ind (da ASF ikke kender `dampID` på din konto, før du rent faktisk logger ind).

Start ASF, som skal bemærke din fil og importere den. Antages det, at du har importeret den korrekte fil med gyldige hemmeligheder, bør alt fungere korrekt, som du kan verificere ved hjælp af kommandoer `2fa`. Hvis du har lavet en fejl, kan du altid fjerne `Bot.db` og starte forfra, hvis det er nødvendigt.

### WinAuth

Først skal du oprette nyt tomt `BotName. aFile` i ASF config mappe, hvor `BotName` er navnet på din bot, du tilføjer ASF 2FA til. Hvis du angiver forkert navn, vil det ikke blive plukket af ASF.

Nu starter WinAuth som sædvanlig. Højreklik på Steam-ikonet og vælg "Vis SteamGuard og Recovery Code". Tjek derefter "Tillad kopi". Du bør bemærke velkendte for dig JSON struktur i bunden af vinduet, startende med `{`. Kopier hele teksten til en `BotName.maFile` fil oprettet af dig i forrige trin.

Start ASF, som skal bemærke din fil og importere den. Antages det, at du har importeret den korrekte fil med gyldige hemmeligheder, bør alt fungere korrekt, som du kan verificere ved hjælp af kommandoer `2fa`. Hvis du har lavet en fejl, kan du altid fjerne `Bot.db` og starte forfra, hvis det er nødvendigt.

### Manuelt

Hvis du er avanceret bruger, kan du også generere maFile manuelt. Dette kan bruges, hvis du ønsker at importere autentificering fra andre kilder end dem, vi har beskrevet ovenfor. Det bør have en **[gyldig JSON struktur](https://jsonlint.com)** af:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Standard authenticator data har flere felter - de er helt ignoreret af ASF under import, da de ikke er nødvendige. Du behøver ikke at fjerne dem - ASF kræver kun gyldig JSON med 2 obligatoriske felter beskrevet ovenfor, og vil ignorere yderligere felter (hvis nogen). Selvfølgelig skal du erstatte `STRING` pladsholder i eksemplet ovenfor med gyldige værdier for din konto. Hver `STRING` skal være base64-kodet repræsentation af bytes den passende private nøgle er lavet af.

---

## OSS

### Hvordan gør ASF brug af 2FA-modul?

Hvis ASF 2FA er tilgængelig, vil ASF bruge den til automatisk bekræftelse af handler, der bliver sendt/accepteret af ASF. Det vil også være i stand til automatisk at generere 2FA tokens på det nødvendige grundlag, for eksempel for at logge ind. Derudover gør det med ASF 2FA også muligt for `2fa` kommandoer for dig at bruge.

### Hvordan får jeg 2FA-token?

Du skal bruge 2FA-token for at få adgang til 2FA-beskyttet konto, der omfatter alle konti med ASF 2FA. Hvis du har besluttet at bruge standalone authenticator, så skal du bruge `2fa <BotNames>` kommando til at generere midlertidig token for givne bot forekomster. I alle andre scenarier anbefaler vi at bruge den originale autentificering, som du har brugt, selvom du kan bruge kommandoen så godt, hvis det er mere bekvemt for dig.

### Kan jeg bruge min oprindelige autentificering efter at have importeret den som ASF 2FA?

Ja, din oprindelige autentificering forbliver funktionel, og du kan bruge den sammen med ASF 2FA. Husk dog, at hvis du ugyldiggør det via enhver metode, derefter linkede ASF 2FA legitimationsoplysninger vil også ikke længere være gyldige.

### Sådan fjernes ASF 2FA?

Stop ASF og fjern tilknyttede `BotName.db` af botten med linket ASF 2FA, du vil fjerne. Denne indstilling vil fjerne tilknyttet importeret 2FA med ASF, men vil IKKE ugyldiggøre (aflink) din autentificering. Hvis du i stedet ønsker at ugyldiggøre din autentifikator, bortset fra at fjerne den fra ASF (først), bør du fjerne linket i original autentificering efter eget valg. Hvis du ikke kan gøre det af en eller anden grund, for eksempel fordi du bruger ASF 2FA i standalone tilstand, derefter bruge tilbagekaldelseskode, som du har modtaget under opsætningen, på Steam-webstedet. Det er ikke muligt at ugyldiggøre din autentificering via ASF.

### Jeg linkede autentificering i tredjeparts-app, derefter importeret til ASF. Kan jeg nu linke det igen på min telefon?

**Nr.**. Gør dette vil ugyldiggøre de tidligere importerede legitimationsoplysninger, og din ASF 2FA vil stoppe med at fungere (ved at generere koder ikke længere bliver accepteret af Steam). Først beslutte, hvor du vil have din oprindelige eller tredjeparts autentificering placeret, og derefter importere det som ASF 2FA.

### Jeg bruger fælles autentificering, kan jeg flytte min app til en anden telefon?

**Nr.**. Hvad damp hedder som "flytning" eller "overførsel" autentificering, er faktisk lig med at ugyldiggøre den gamle og tildele en ny, i et trin. Dette giver dig mulighed for at springe f.eks. en vis overdreven nedkøling i forhold til at gøre disse to trin uafhængigt, for så vidt angår ASF dette ugyldiggør faktisk de legitimationsoplysninger, du tidligere har genereret i ASF, hvilket gør hele ASF 2FA-modulet ikke-operativt.

Den anbefalede måde er at fjerne din autentificering helt på den gamle telefon og bruge den fælles autentificeringsmetode igen på den nye telefon. Hvis du allerede har flyttet din autentificering, så er gamle ASF 2FA-legitimationsoplysninger allerede ugyldige, så det eneste tilbage nu fjerner din "flyttede" autentificering, og forbinder en ny med den fælles autentificeringsmetode igen.

### Bruger du ASF 2FA bedre end tredjeparts autentificering indstillet til at acceptere alle bekræftelser?

**Ja**på flere måder. Første og vigtigste - ved hjælp af ASF 2FA **væsentligt** øger din sikkerhed, da ASF 2FA-modul sikrer, at ASF kun automatisk accepterer sine egne bekræftelser så selv hvis angriber anmoder om en handel, der er skadelig, ASF 2FA vil **ikke** acceptere en sådan handel, da den ikke blev genereret af ASF. Ud over sikkerhed del, ved hjælp af ASF 2FA også bringer ydeevne / optimering fordele, som ASF 2FA henter og accepterer bekræftelser umiddelbart efter de er genereret, og kun derefter, i modsætning til ineffektiv meningsmåling for bekræftelser hver X minutter, som opnås ved andre løsninger. Der er ingen grund til at bruge tredjeparts autentificering over ASF 2FA, hvis du planlægger at automatisere bekræftelser genereret af ASF - det er præcis, hvad ASF 2FA er for, og at bruge det ikke er i strid med dig bekræfter alt andet i autentificering efter eget valg. Vi anbefaler kraftigt at bruge ASF 2FA til hele ASF aktivitet.