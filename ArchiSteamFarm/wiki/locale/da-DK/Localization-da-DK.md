# Lokalisering

ASF er drevet af Crowdin-tjenesten, hvilket gør det muligt for alle at hjælpe med at oversætte ASF til alle sprog, der tales over hele verden. For mere detaljeret forklaring af, hvordan Crowdin fungerer, tjek venligst **[Crowdin-introduktion](https://support.crowdin.com/crowdin-intro)**.

Hvis du er interesseret i, hvad der foregår i øjeblikket, kan du tjekke **[ASF Crowdin-aktivitet](https://crowdin.com/project/archisteamfarm/activity_stream)**.

---

## Anvendelsesområde

Vores platform understøtter lokalisering af vores vigtigste ASF program, samt hele lokaliserbart indhold, som vi tilbyder sammen med det. Dette omfatter især vores ASF-WebConfigGenerator, ASF-ui, samt vores wiki. Alt dette er muligt at oversætte gennem bekvem crowdin interface.

---

## Tilmelding

Hvis du gerne vil hjælpe med ASF, enten ved at oversætte, gennemgå eller godkende oversættelser, Tilmeld dig på vores **[Crowdin-projektside](https://crowdin.com/project/archisteamfarm)**. Registrering er nem og helt gratis! Når du er logget ind, kan du vælge sprog, som du gerne vil blive tildelt til, derefter gå videre til ASF strenge og hjælpe resten af samfundet med at oversætte ASF til alle de mest populære sprog!

---

### Oversætter

Hvis sproget efter eget valg stadig mangler nogle strenge, kan du få fat i dem og begynde at arbejde på oversættelsen. Vi har forsøgt at gøre vores bedste med hensyn til fleksibilitet i oversættelserne, Derfor omfatter mange strenge ekstra variabler, som ASF vil give under kørslen - dem er angivet i parentes med et nummer, såsom `{0}`. Dette giver dig mulighed for at ændre standard ASF format af strengen, f.eks. ved at flytte ASF-forudsat variabel på et sted, der tilfredsstiller dit sprog og din oversættelse, i stedet for at blive tvunget til streng kontekst og format. Dette er især vigtigt på RTL sprog, såsom hebraisk.

For eksempel kunne du have en streng som:

> Vi har {0} spil at opdrætte.

Men baseret på dit sprog, kan følgende sætning give mere mening:

> Antallet af spil til farm er lig med {0}.

Eller:

> {0} er antallet af spil at opdrætte.

Fleksibiliteten er specielt til dig, så du kan omformulere ASF sætning lidt for at passe til dit sprog bedre og flytte ASF nummer eller andre oplysninger på et sted, der passer til din oversættelse (i stedet for at oversætte hver del uafhængigt). Dette forbedrer den samlede oversættelseskvalitet.

---

### Gennemgår

Hvis din streng allerede er oversat af en anden, kan du stemme for den. Afstemning gør det muligt at vælge den bedste variant af oversættelsen, i stedet for at holde sig til oprindelige forslag - dette forbedrer den samlede oversættelse kvalitet yderligere. Du kan stemme om allerede tilgængelige forslag, eller foreslå din egen oversættelse, som vil gå gennem samme proces. Til sidst, den endelige streng vil blive valgt enten baseret på de fleste stemte forslag, eller som et valg af korrekturlæser valgt for det sprog, der personligt godkender en given oversættelse (baseret på dine stemmer).

**Du behøver ikke godkendelse for at se dine oversatte strenge i ASF**. Godkendelse betyder blot, at nogen betroede fra os har gennemgået indholdet, som i - plukket den endelige version af oversættelsen. Det er helt fint at have ikke-godkendte community-drevne oversættelser, hvor du stemmer for den bedste. Så længe det er oversat, alt er fint! Og hvis du mener, at den aktuelle oversættelse er dårlig, kan du altid stemme på det bedste, eller foreslå dig selv.

---

### Læsebevis

Det er en god idé at have en konsekvent oversættelse, selv om det potentielt kunne tage frihed fra community review/afstemning proces forklaret ovenfor. Dette skyldes hovedsagelig, at forkerte oversættelser, der ikke nødvendigvis er dårlige, kan få så mange op-stemmer, at det ikke længere er muligt at foreslå nogen bedre oversættelse, selv om nogen har sådan.

Hvis du har tidligere historik for bidrag på Crowdin eller en anden lokaliseringsplatform/-tjeneste, som vi kan verificere og antage troværdig vi er glade for at give dig en proof-læseradgang til givne sprog, du bidrager til, så du vil være i stand til at godkende given oversættelse og gøre det konsekvent. Læseprofiler er ikke en nem opgave, især fordi ASF kan være meget "teknisk" fra tid til anden og virkelig svært at oversætte, men vi forstår, at det ofte er nødvendigt for en perfekt oversættelse. Derfor, hvis du kan hjælpe ved proof-reading givet sprog, **[lad os vide](https://crowdin.com/messages/create/13177432/240376)**, men husk på, at du skal sikkerhedskopiere din anmodning med tidligere lokaliseringsbidrag, som vi kan bekræfte (f. eks. . arbejde med ASF lokalisering på Crowdin, eller med ethvert andet projekt). Vi kan også tillade mere avancerede brugere at afhente indledende aflæsning, hvis vi kender dem personligt, og de er i stand til at samarbejde med resten af samfundet for at lokalisere ASF på det sprog bedst.

Generelle regler gælder for læseproof-læsning - du skal ikke skynde, lytte til dine brugere, arbejde som projektleder, løse problemer, sikre, at du gør tingene bedre og ikke værre.

---

### Problemer

Hvis du har problemer med en bestemt oversættelse, f.eks. du ved ikke, hvordan du oversætter det, godkendt oversættelse er forkert, du har brug for mere specifik kontekst, eller tilsvarende, skriv venligst en kommentar under en specifik streng og markér den med [X] Issue.

**Undgå venligst at bruge problemmærke, hvis du ikke har brug for teknisk/udviklingsforklaring eller admin handling**. Du kan bruge kommentarer til diskussioner relateret til oversættelse af den givne streng, men problemet bør kun bruges, når du har brug for yderligere teknisk forklaring eller admin korrektion, og det vil typisk involvere nogen, der ikke engang taler det sprog, du oversætter til, så vær venlig at holde dig til engelsk, når du skriver issue kommentar (så vi kan forstå, hvad problemet er).

Der er i øjeblikket 4 understøttede problemer:
- Generelt spørgsmål - for alt andet, der ikke passer til noget problem nedenfor. Generelt bør denne type **undgås**, som om dit problem ikke passer til, så er det meget sandsynligt **ikke** et oversættelsesproblem. Alligevel er denne mulighed tilgængelig her for alle andre sager.
- Nuværende oversættelse er forkert - dette bør kun bruges **** , hvis oversættelse er forhåndsgodkendt af læseren allerede, og du mener, at det er forkert, for eksempel har det en typo eller du har et gyldigt forslag om, hvordan man kan forbedre det. Denne type bør aldrig anvendes i oversættelser, der drives af fællesskabet (afstemning), som i dette tilfælde skal du kontakte brugeren af den givne oversættelse og bede ham om rettelse, eller blot stemme for bedre oversættelse, som angivet i revisionen sektion. Vi vil fjerne godkendelsen af oversættelsen og underrette den relevante læserprofil, der er ansvarlig for sproget, for at tage hensyn til din kommentar og bekræfte igen.
- Manglende kontekstuelle oplysninger - dette er, hvad du skal bruge, hvis du ikke er sikker på, hvilken del af ASF, du oversætter, hvad der er rammerne for den givne streng, eller dens formål. Denne type bør kun bruges til ASF udvikling, det betyder, at du har brug for teknisk bistand, da du ikke er sikker på, hvordan du skal oversætte givne streng.
- Fejl i kildestrengen - dette bør kun bruges, hvis du mener, at den originale (engelsk) streng er forkert. Helt sjældent, men heller ikke alle taler vi engelsk indfødt, så er du velkommen til at bruge det, hvis du har en generel idé om, hvordan det kan forbedres. Alternativt, da dette er strengt relateret til udviklingen kan du bruge vores **[GitHub issues](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** til det formål, hvis du gerne vil.

---

### Oversættelsesfremgang

Hvert sprog har to stater færdiggørelse - oversættelse, og læsebevis.

Sprog betragtes som **oversat** når dets oversættelsesfremskridt når 100%. På dette tidspunkt hver lokaliserbar streng, der anvendes af ASF har ordentlig betydning, som er stor. Men det betyder ikke, at der ikke er plads til forbedringer - fællesskabsafstemning er aktiveret hele tiden, og du kan stadig foreslå bedre oversættelse til allerede oversatte dele, samt stemme på eksisterende. Bemærk, at fuldt oversatte sprog stadig kan falde under 100% når vi ændrer eksisterende strenge eller tilføjer nye under udvikling. Du kan konfigurere passende crowdin-notifikationer, hvis du gerne vil modtage e-mail, når dette sker.

Valgte sprog kan have passende proof-læsere, der validerer oversættelser og godkender endelige versioner. Dette er sidste pass efter oversættelse finder sted og giver mulighed for yderligere at forbedre lokalisering.

ASF vil omfatte givet sprog **så hurtigt som muligt**, hvilket betyder, at det ikke behøver at blive godkendt eller endda 100% oversat. De faktiske strenge der vil blive brugt er altid de mest populære i form af stemmer, medmindre valgt korrekturlæser besluttet andet (sjældent). Derfor du kan se din indsats blive inkluderet i den næste ASF-udgivelse - vores automatiseringssystemer sammenflette oversættelser fra Crowdin tilbage til ASF-repo på daglig basis.

---

## Manglende sprog

Som standard har ASF projekt kun åben oversættelse for top 30 sprog, der tales over hele verden. Hvis du vil tilføje en anden (eller en lokal dialekt til allerede tilgængelig), venligst **[lad os vide](https://crowdin.com/messages/create/13177432/240376)** , og vi tilføjer det ASAP. Vi ønsker ikke at åbne flere hundrede forskellige sprog, hvis ingen kommer til at oversætte dem, det er derfor, vi begrænsede det til nogle fair nummer. Tøv ikke med at kontakte os, hvis du gerne vil oversætte nogle ikke-listede sprog, det er meget nemt for os at tilføje en anden. Bare sørg for, at du har faktiske villighed og beslutsomhed til at oversætte ASF til dit sprog, før du beslutter at kontakte os.

For en komplet liste over alle tilgængelige sprog, som ASF kan oversættes til **[klik her](https://developer.crowdin.com/language-codes)**.

---

## Pluralisering

Hvert sprog har sine egne regler med hensyn til pluralisering. Disse regler kan findes på **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** , som angiver deres antal og nøjagtige sprogbetingelser.

Vi gør vores bedste for at tilbyde dig fleksibel lokalisering, og så længe som muligt, vil dette også omfatte flertalsregler. For eksempel vil vi oversætte følgende streng til polsk i dag:

> Released {PLURAL:n|{n} month|{n} months} ago

`PLURAL` nøgleordet her behandles på en særlig måde, da det giver dig mulighed for at inkludere alle flertalsformer, som dit sprog understøtter. Hvis du tager et kig på CLDR, vil du se, at der på engelsk kun er 2 kardinal former - "én" og "andre". Og som du kan se ovenfor, har vi begge defineret - `{n} måned` og `{n} måneder`.

Men vores polske sprog omfatter faktisk 4 af dem - "én", "få", "mange" og "andet". Det betyder, at vi bør definere dem alle til fuldendelse. Vores lokaliseringsværktøjer er allerede smarte nok til at vælge passende flertalsform baseret på sprogregler du behøver derfor kun at definere dem alle i oversættelsen:

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

På denne måde har vi defineret alle 4 flertalsformer for vores polske sprog, og da vores lokaliseringsbibliotek allerede kender de nøjagtige regler, det vil korrekt bruge den korrekte formular for forudsat `{n}` nummer.

Det er ikke obligatorisk at definere alle flertalsformer, der bruges af dit sprog. Hvis du mangler, vil vores lokaliseringsbibliotek bruge sidst definerede formular på sin plads. Det er en god idé at definere alle flertalsformer, der bruges af dit sprog, men i nogle tilfælde resterende flertalsformer kunne være det samme som den sidste, i hvilket tilfælde det ikke er nødvendigt at gentage dem. I vort eksempel ovenfor var det obligatorisk, som "andre" form på polsk i månedsvis er "miesia¤ ca", og ikke "miesie_ cy" som i "mange".

---

## Wiki

Vores crowdin platform giver dig også mulighed for at lokalisere selv wiki selv. Dette er et meget kraftfuldt værktøj, da det giver dig mulighed for at oprette en hel ASF dokumentation på dit modersmål, effektivt løse det allersidste problem, når det kommer til ASF lokalisering. Sammen med oversættelse af programmet og alle dets dele, gør dette lokalisering komplet.

Wiki er en smule speciel i denne henseende, da det er online hjælp, hvor du ikke behøver at holde med oprindelige sætning for meget. Det betyder, at du ønsker at være så naturlig med dit sprog som muligt. og levere original betydning og hjælp - ikke nødvendigvis holde sig til originale streng, brugte ord og faktiske tegnsætning. Vær ikke bange for at omskrive strengen til noget langt mere naturligt for dit sprog, så længe du holder den generelle retning og hjælp inkluderet i sætningen.

---

### Globale links

Vores crowdin platform giver dig også mulighed for at tilpasse den oprindelige tekst for at gøre det punkt til nye (lokaliserede) steder.

ASF indeholder links på næsten hver side for lettere navigation, samt sidebar til højre. Den awesome faktum er, at du kan redigere alt det, "fastsættelse" links til at pege på ordentlige lokaliserede sider for dit sprog. Det kræver at være en smule omhyggelig at gøre det, men det er muligt.

ASF **[startside](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)** indeholder for eksempel en tekst såsom:

> Hvis du er en ny bruger, anbefaler vi at starte med **[opsætning](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** guide.

Hvilket oprindeligt skrevet som:

```markdown
Hvis du er en ny bruger, anbefaler vi at starte med **[opsætning](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** guide.
```

På crowdin, første ting du skal gøre, er at gå til dine redigeringsindstillinger og sikre, at HTML-tags er indstillet til "Vis" for dig. Dette er meget vigtigt, hvis du beslutter dig for at lokalisere wikien.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Nu, under oversættelse af crowdin, afhængigt af formatering, vil du se ASF links i teksten enten som:

* Streng til at oversætte sammen med HTML-tags (de fleste strenge, hvor kun en del af sætningen er et link)
* Alene streng til oversættelse, med link inkluderet i `skjulte tekster` -> `Link adresser` (sjælden, hvor hele strengen er et link, mest almindeligt i sidebar - dem kræver korrekturlæseren adgang til at oversætte, desværre)

I vores eksempel ovenfor, er det det første tilfælde (da kun "opsætning" er et link), så i crowdin vil vi se det som:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Uanset tilfældet, først skal du kopiere kildestrengen og oversætte den som sædvanlig, efterlader hele HTML (hvis der findes) intakt. Dette ville være et eksempel på oversættelse til polsk sprog:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Nu, hvis linket er et generisk link, der peger uden for wiki (f.eks. til seneste ASF udgivelse), kan du lade det som det er, da du ikke ønsker at redigere det. Du kan gemme det og gå fremad.

Men hvis linket **gør** peger længere inde i wikien, ligesom den ovenstående, kan du faktisk rette det til at pege på en ny (lokaliseret) placering. Du gør dette ved omhyggeligt at tilføje `-locale` for at målrette URL i `<a>` tag, som nedenfor:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Vær meget forsigtig med dette, og sørg for, at din URL faktisk eksisterer, da hvis du laver en fejl, vil linket stoppe med at fungere. Hvis det lykkes for dig, har du nu en fuldt funktionel oversættelse med link der peger på oversat (i vores tilfælde `Setting-up-pl-PL`) side.

Gør ovenstående trin vil korrekt oversætte vores HTML tilbage til markdown:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

Og endelig i wiki tekst:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

Når ingen HTML er til stede (andet tilfælde), Dette er endnu nemmere, da du bare kan gå til `skjulte tekster` -> `Link adresser`.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

Derfra kan du nemt rette linket til punkt til ny placering, uden selv at bekymre sig med HTML overhovedet:

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Lokale links

På tværs af wiki vil du også finde lokale links, der peger på en bestemt del af dokumentet. Disse links omfatter `#` -tegn, der angiver webbrowseren, at den bør bevæge sig i retning af den del af dokumentet.

Det er nu særlige tilfælde, da disse links er baseret på navnene på afsnittene i det aktuelle dokument. Mens for webadresser vi har en generel konvention om at tilføje `-locale` til URL'en, og det virker overalt, sektionsnavne vil blive oversat af dig og andre mennesker, så du skal sikre, at de peger på korrekt placering.

For eksempel kan du finde `#introduction` link i vores **[konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#introduction)** afsnit:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Da vi kommer til at oversætte "Introduktion" ord til "Wprowadzenie" til vores polske sprog, vi er nødt til at rette dette link, da det vil stoppe med at fungere i det øjeblik, vi gør dette.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

På denne måde vil vores lokale link fortsætte med at fungere, da det nu vil pege på navnet på den sektion, vi bruger. Du kan rette links inde HTML-tags på nøjagtig samme måde.

---

### Kode blokke

Vær meget forsigtig, når du oversætter sætninger med `<code></code>` blokke indeni. Kodeblok angiver faste ASF-kodenavne eller -termer, som ikke må oversættes. For eksempel:

> Dette er især nyttigt, hvis du har en masse nøgler til at indløse og du er garanteret at ramme <code>RateLimited</code> status, før du er færdig med hele din batch.

Som du kan se, er `RateLimited` ord her inde i en kodeblok og indikerer intern ASF kode status, der ikke bør oversættes. Ligeledes bør du ikke oversætte andre kodeblokke, såsom navne på config egenskaber (fx `TradingPreferences`), enum medlemmer (f. eks. . `Stabil` og `PreRelease` muligheder for `UpdateChannel`) og ligeledes.

Men bare fordi disse ord ikke skal oversættes, betyder ikke, at du ikke kan tilføje passende oversættelse ved siden af dem, for eksempel i parentes.

> Ta funkcja jest wyjątkowo użyteczna w przypadku aktywacji dużej ilości kluczy i gwarancji napotkania statusu <code>RateLimited</code> (zbyt częstej aktywacji) przed ukończeniem całej partii.

Som du kan se ovenfor, har vi tilføjet "zbyt czeţstej aktywacji", bogstaveligt talt "alt for ofte aktivering" ved siden af `RateLimited` for at oversætte denne status på en venlig måde, mens på samme tid holde oprindelige ASF betyder, at brugeren kan se under brug af programmet. På samme måde kan du oversætte/forklare andre, lignende tilfælde af forskellige ord og sætninger.

Hvis du mener, at noget upassende er inkluderet i en kodeblok, eller at der er en tekst, der ikke er i en kodeblok, men som bør være inde i den, er velkommen til at spørge på vores crowdin ved at oprette passende **[issue](#issues)**. Dette er også et praktisk eksempel på at bruge en lokal forbindelse.

---

## Hall of fame

Vi vil gerne vise vores evige taknemmelighed over for folk, der har brugt en betydelig mængde af deres tid og villighed til at gøre ASF lokalisering bedre. Deres indsats er utrolig, og du kan nyde komplette oversættelser, herunder wikien, for det meste takket være dem. Som et tegn på påskønnelse, Alle personer på listen her tilbydes gratis adgang til **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** funktion på en **[anmodning](https://crowdin.com/messages/create/13177432/240376)**.

| Bidragsyder                                                | Sprog             |
| ---------------------------------------------------------- | ----------------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, Spansk    |
| **[Død_Sam](https://crowdin.com/profile/Dead_Sam)**        | Portugisisk (BR)  |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | Kinesisk (CN)     |
| **[DragonTaki](https://crowdin.com/profile/dragontaki)**   | Kinesisk (TW)     |
| **[LittleFreak](https://crowdin.com/profile/littlefreak)** | Tysk              |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | Russisk, Ukrainsk |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT, Tysk      |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | Kinesisk (HK)     |

Tak alle for at forbedre vores ASF lokalisering kvalitet!