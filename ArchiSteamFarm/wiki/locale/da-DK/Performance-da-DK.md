# Ydeevne

Hovedformålet med ASF er at drive så effektivt som muligt baseret på to typer data, den kan operere på - små brugerleverede data, der er umulige for ASF at gætte/kontrollere på egen hånd, og større datasæt, som automatisk kan kontrolleres af ASF.

I automatisk tilstand giver ASF ikke dig mulighed for at vælge de spil, der skal opdrættes, eller giver dig mulighed for at ændre kort opdræt algoritme. **ASF ved bedre end dig, hvad den skal gøre, og hvilke beslutninger den skal træffe for at drive så hurtigt som muligt**. Dit mål er at sætte config egenskaber ordentligt, som ASF ikke kan gætte dem på egen hånd, alt andet er dækket.

---

For nogen tid siden ændrede ventilen algoritmen for kortdråber. Fra dette punkt og fremefter kan vi kategorisere dampkonti efter to kategorier: dem **med** -kort dråber begrænset, og dem **uden**. Den eneste forskel mellem disse to typer er, at konti med begrænsede kort dråber ikke kan få noget kort fra et givet spil, før de spiller givet spil i mindst `X` timer. Det ser ud til, at ældre konti, der aldrig har bedt om tilbagebetaling, har **ubegrænset kort dråber**, mens nye konti og dem, der bad om tilbagebetaling, har **begrænsede kort dråber**. Dette er dog kun teori, og bør ikke tages som hovedregel. Derfor er der **ikke noget indlysende svar**, og ASF er afhængig af **du** fortæller det, hvilken sag der er passende for din konto.

---

ASF omfatter på nuværende tidspunkt to landbrugsalgoritmer:

**`Simple`** algoritme fungerer bedst for konti, der har ubegrænsede kort dråber. Dette er primær algoritme, der anvendes af ASF. Bot finder spil til gård, og gårde dem én efter én, indtil alle kort er droppet. Dette skyldes, at kortfaldet falder, når landbruget mere end ét spil er tæt på nul og helt ineffektiv.

**`Complex`** er ny algoritme, der er blevet implementeret for at hjælpe begrænsede konti til at maksimere deres overskud. ASF vil først bruge standard **`Simple`** algoritme på alle spil, der passerede `HoursUntilCardDrops` timers spilletid derefter, hvis ingen spil med >= `TimerUntilCardDrops` timer er tilbage, den vil drive alle spil (op til `32` grænse) med < `TimerUntilCardDrops` timer tilbage samtidigt, indtil nogen af dem rammer `TimerUntilCardDrops` timer mærke, så ASF vil fortsætte løkken fra begyndelsen (brug **`Simple`** på det spil vende tilbage til samtidig på < `TimerUntilCardDrops` og så videre). Vi kan bruge flere spil landbrug i dette tilfælde til at bumpe timer af de spil, vi har brug for at drive til passende værdi først. Husk på, at ASF **i løbet af landbrugstider ikke** gårdkort, så det heller ikke vil tjekke for nogen kort dråber i denne periode (for årsager anført ovenfor).

I øjeblikket vælger ASF kort opdræt algoritme baseret udelukkende på `HoursUntilCardDrops` config ejendom (som er fastsat af **you**). Hvis `HoursUntilCardDrops` er indstillet til `0`, **`Simple`** algoritme vil blive brugt, ellers **`Kompleks`** algoritme vil blive brugt i stedet - konfigureret til at bump spilletid i alle spil til et givet antal timer, før de opdrættes for kortdråber.

---

### **Der er ingen indlysende svar, hvilken algoritme er bedre for dig**.

Dette er en af grundene til, at du ikke vælger kort landbrug algoritme, i stedet, du fortæller ASF, hvis konto har begrænsede dråber eller ej. Hvis kontoen har ikke-begrænsede drops, vil **`Simple`** -algoritmen **fungere bedre** på denne konto, da vi ikke spilder tid på at bringe alle spil til `X` timer - kortreduktion er tæt på 0% når du dyrker flere spil. På den anden side, hvis din konto har kort dråber begrænset, **`Complex`** algoritme vil være bedre for dig, da der ikke er nogen mening i landbrugets solo, hvis spillet ikke nåede `HoursUntilCardDrops` timer endnu - så vi vil farm **spilletid** først, **derefter** kort i solo tilstand.

Sæt ikke `HoursUntilCardDrops` blindt kun fordi nogen fortalte dig - gør tests, sammenligne resultater, og baseret på data, du får, beslutte, hvilken mulighed der skal være bedre for dig. Hvis du lægger nogle minimale indsats i det, du vil sikre, at ASF arbejder med maksimal mulig effektivitet for din konto, hvilket sandsynligvis er hvad du ønsker, i betragtning af at du læser denne wikiside lige nu. Hvis der var en løsning, der virker for alle, ville du ikke få et valg - ASF ville beslutte sig selv.

---

### Hvad er den bedste måde at finde ud af, hvis din konto er begrænset?

Sørg for at du har nogle spil med **ingen spilletid optaget** til gård, helst 5+, og kør ASF med `HoursUntilCardDrops` af `0`. Det ville være en god idé, hvis du ikke spillede noget i løbet af landbrugsperioden for mere præcise resultater (bedst at køre ASF om natten). Lad ASF farm disse 5 spil, og efter at tjekke loggen for resultater.

ASF klart angiver, hvornår et kort for et givet spil blev droppet. Du er interesseret i hurtigste kortfald opnået af ASF. For eksempel, hvis din konto er ubegrænset, så skal en første kort drop ske efter omkring 30 minutter siden du startede landbrug. Hvis du bemærker **mindst et** spil, der gjorde droppe kortet i de første 30 minutter, så er dette en indikator for, at din konto er **ikke** begrænset og bør bruge `HoursUntilCardDrops` af `0`.

På den anden side, hvis du bemærker, at **hvert** spil tager mindst `X` antal timer, før det falder sit første kort, så er dette en indikator til dig, hvad du skal indstille `TimerUntilCardDrops` til. Flertal (hvis ikke alle) for begrænsede brugere kræver mindst `3` timers spilletid for kort for at slippe og dette er også standardværdien for `HoursUntilCardDrops` -indstillingen.

Husk, at spil kan have forskellige drop rate, Dette er grunden til, at du skal teste, hvis din teori er rigtigt med **mindst** 3 spil, helst 5+ for at sikre, at du ikke løber ind i falske resultater ved en tilfældighed. En kortdråbe på et spil på mindre end en time er en bekræftelse på, at din konto **ikke er** begrænset og kan bruge `HoursUntilCardDrops` af `0`, men for at bekræfte, at din konto **er** begrænset, du har brug for mindst flere spil, der ikke slipper kort, indtil du rammer et fast mærke.

Det er vigtigt at bemærke, at i tidligere `HoursUntilCardDrops` var kun `0` eller `2`, og det er derfor, ASF havde en enkelt `CardDropsRestricted` ejendom, der tillod at skifte mellem disse to værdier. Med de seneste ændringer har vi bemærket, at ikke kun de fleste brugere kræver `3` timer i stedet for tidligere `2` nu, men også at `HoursUntilCardDrops` er nu dynamisk og kan ramme enhver værdi på per-konto basis.

I sidste ende er det naturligvis op til Dem.

Og for at gøre det endnu værre - jeg oplevede tilfælde, når folk skiftede fra begrænset til ubegrænset tilstand og vice versa - enten på grund af Steam bug (Åh ja, Vi har mange af disse), eller på grund af nogle logik justeringer af Valve. Så selvom du har bekræftet, at din konto er begrænset (eller ikke), tro ikke, at det vil forblive sådan - for at skifte fra ubegrænset til begrænset er det nok til at bede om tilbagebetaling. Hvis du føler, at tidligere indstillede værdi ikke længere er passende, kan du altid udføre en re-test og opdatere den i overensstemmelse hermed.

---

Som standard antager ASF, at `HoursUntilCardDrops` er `3`, som den negative effekt af at sætte dette til `3` , når det skal være mindre end gjort den anden måde. Dette skyldes, at vi i det værst tænkelige tilfælde spilder `3` timers landbrug per `32` spil sammenlignet med at spilde `3` timers landbrug pr. hvert eneste spil, hvis `HoursUntilCardDrops` blev sat til `0` som standard. Du bør dog stadig indstille denne variabel til at matche din konto for maksimal effektivitet, da dette kun er et blindt gæt baseret på potentielle ulemper og de fleste brugere (så vi forsøger at vælge "mindre ondt" som standard).

I øjeblikket er to ovenstående algoritmer nok til alle nuværende mulige kontoscenarier, for at drive landbrug så effektivt som muligt, er det derfor ikke planlagt at tilføje andre.

Det er rart at bemærke, at ASF også indeholder manuel landbrugstilstand, der kan aktiveres af kommandoen `play`. Du kan læse mere om det i **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

## Damp fejl

Kort drop algoritme fungerer ikke altid den måde, det skal, og det er helt muligt for forskellige Steam glitches at ske, såsom at kort bliver droppet på begrænsede konti, at kort bliver droppet ved lukning/skift af spillet kort der ikke slipper på alle, når spillet spilles, og ligeledes.

Dette afsnit er primært for folk, der undrer sig over, hvorfor ASF ikke gør **X**, såsom hurtigt skifte spil til gård kort hurtigere.

Hvad er en **Steam glitch** - en specifik handling, der udløser **udefineret** -adfærd, som er **ikke hensigten, udokumenteret og betragtes som en logisk fejl**. Det er **upålideligt pr. definition**, hvilket betyder, at det ikke kan gengives pålideligt med rent testmiljø og derfor, kodet uden at ty til hacks der formodes at gætte, hvornår glitch sker, og hvordan man kæmper med det / misbrug det. Typisk er det midlertidigt, indtil udviklere løse logikken fejl, selv om nogle misc glitches kan gå ubemærket i en meget lang periode.

Et godt eksempel på, hvad der betragtes som en **Steam glitch** er ikke så ualmindelig situation med at droppe et kort, når spillet er ved at blive lukket, som til en vis grad kan misbruges med idle master's spil skip funktion.

- **Udefineret adfærd** - du kan ikke sige, om der vil være 0 eller 1 kort bliver droppet, når du udløser fejl.
- **Ikke tiltænkt** - baseret på tidligere erfaringer og adfærd fra Steam-netværket, der ikke resulterer i samme adfærd, når der sendes en enkelt anmodning.
- **Udokumenteret** - det er klart dokumenteret på Steam-websted, hvordan kort opnås, og **på hvert enkelt sted** er det klart angivet, at det er opnået gennem **spiller**, IKKE lukke spil, få resultater, spil skifte eller lancere 32 spil samtidig.
- **Betragtes som en logik fejl** - lukning af spil eller skift af dem bør ikke have noget resultat på kort bliver droppet, som er klart angivet at blive opnået gennem **vinder spilletid**.
- **Upålidelige pr. definition kan ikke gengives pålideligt** - det virker ikke for alle, og selv om det gjorde arbejde for dig én gang, kunne det ikke længere arbejde for anden gang.

Now once we realized what Steam glitch is, and the fact that cards being dropped when game gets closed **is** one, we can move on to the second point - **ASF is not abusing Steam network in any way by definition, and it's doing its best to comply with Steam ToS, its protocols and what is generally accepted**. Spamming Steam-netværk med konstant åbning af spil/lukning anmodninger kan betragtes som et **[DoS-angreb](https://en.wikipedia.org/wiki/Denial-of-service_attack)** og **overtræder direkte [Steam Online Conduct](https://store.steampowered.com/online_conduct/?l=english)**.

> Som Steam abonnent accepterer du at overholde følgende adfærdsregler.
> 
> Du vil ikke:
> 
> Instituttet angriber på en Steam-server eller på anden måde forstyrrer Steam.

Det er ligegyldigt, om du er i stand til at udløse Steam glitch med andre programmer (såsom IM), og det er også ligegyldigt, om du er enig med os og overveje sådan adfærd som DoS angreb, eller ikke - det er op til Ventilen at bedømme dette, men hvis vi betragter det som at udnytte/misbruge ikke-tilsigtet adfærd gennem overdrevne Steam-netværksforespørgsler så kan du være temmelig sikker på, at ventilen vil have lignende syn på dette.

ASF er **aldrig** kommer til at drage fordel af Steam exploits, misbrug, hacks eller enhver anden aktivitet, som vi ser som **ulovlig eller uønsket** i henhold til Steam ToS, Steam Online Adduct eller enhver anden betroet kilde, der kan indikere, at ASF-aktivitet er uønsket af Steam-netværk, som angivet i afsnit **[, der bidrager](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)**.

Hvis du for enhver pris ønsker at risikere din Steam-konto til landbrug et par cent kort hurtigere end normalt, så desværre vil ASF aldrig tilbyde noget som dette i automatisk tilstand, selvom du stadig har `play` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** , der kan bruges som et værktøj til at gøre hvad du ønsker i form af Steam netværk interaktion. Vi anbefaler ikke, at du udnytter Steam-glitches og udnytter dem til din egen gevinst - ikke kun med ASF men med ethvert andet værktøj så godt. I sidste ende er det dog din konto, og dit valg, hvad du ønsker at gøre med det - bare huske på, at vi advarede dig.