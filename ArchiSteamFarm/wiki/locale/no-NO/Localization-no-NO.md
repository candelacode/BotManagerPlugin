# Lokalisering

ASF drives av Crowdin-tjenesten, noe som gjør det mulig for alle å bidra til å oversette ASF til alle språk som snakkes verden over. For mer detaljert forklaring på hvordan Crowdin fungerer, vennligst sjekk **[Crowdin introduksjon](https://support.crowdin.com/crowdin-intro)**.

Hvis du er interessert i det som skjer, kan du sjekke **[ASF Crowdinaktivitet](https://crowdin.com/project/archisteamfarm/activity_stream)**.

---

## Omfang

Plattformen vår støtter lokalisering av ASF-programmet vårt, samt hele lokalt innhold som vi tilbyr sammen med det. Dette inkluderer spesielt vår ASF-WebConfigGenerator, ASF-ui, i tillegg til vår wiki. Alt det er mulig å oversette gjennom et praktisk crowdin grensesnitt.

---

## Registrerer deg

Hvis du vil hjelpe til med ASF, enten ved å oversette, gjennomgå eller godkjenne oversettelser, registrer deg på vår **[Crowdin prosjektside](https://crowdin.com/project/archisteamfarm)**. Registrering er lett og helt gratis! Etter at du har logget inn, kan du velge språk du vil bli tildelt til, så gå til ASF-strenger og hjelp resten av samfunnet med å oversette ASF til alle mest populære språk!

---

### Oversette

Hvis språket i ditt valg fortsatt mangler noen strenger, kan du gripe dem og begynne å jobbe med oversettelsen. Vi forsøkte å gjøre vårt beste for fleksibilitet i oversettelsene, Derfor er det mange som angir ekstra variabler som ASF vil sørge for i løpet av rulletiden - disse er vedlagt i parentes med et tall, slik som `{0}`. Dette gjør at du kan endre standard ASF-format for strengen, f.eks ved å flytte ASF-oppgitt variabel i et sted som tilfredsstiller ditt språk og din oversettelse, i stedet for å bli tvunget til streng kontekst og format. Dette er spesielt viktig på RTL-språk, som hebraisk.

For eksempel kan du ha en streng som:

> Vi har {0} partier for å parkere.

Men basert på ditt språk, kan følgende setning bli mer sen:

> Antall spill som skal brukes er lik {0}.

eller:

> {0} er antall spill som skal parkeres.

Fleksibiliteten er gitt spesielt for deg, så du kan litt uttale ASF-setning for å passe til ditt språk bedre og flytte ASF-oppgitte nummer eller annen informasjon på et sted som passer for oversettelsen din (i stedet for å oversette hver del uavhengig av). Dette forbedrer samlet oversettelseskvalitet.

---

### Gjennomgå

Hvis strengen din allerede er oversatt av noen andre, kan du stemme på den. Stemmegivningen gjør det mulig å velge den beste varianten av oversettelsen, i stedet for å klekke med det første forslaget - denne forbedrer samlet oversettelseskvalitet enda mer. Du kan stemme på allerede tilgjengelige forslag, eller foreslå din egen oversettelse, som vil gå gjennom den samme prosessen. Etter hvert vil den endelige strengen bli valgt ut fra de mest stemte forslagene, eller som valg av proofreader valgt ut for det språket som personlig godkjenner oversatt (også basert på stemmene dine).

**Du trenger ikke godkjenning for å se dine oversatte strenger i ASF**. Godkjenning betyr rett og slett at noen har sett på innholdet fra oss, som i - plukket den endelige versjonen av oversettelsen. Det er helt greit å ha ikke godkjent samfunns-drevne oversettelser, der du stemmer på den beste. Så lenge det er oversatt, er alt bra! Hvis du tror at den aktuelle oversettelsen er dårlig, kan du alltid stemme på det bedre, eller foreslå en selv.

---

### Proof-reading

Det er en god idé å ha en konsistent oversettelse, selv om det potensielt kan ta frihet fra samfunnsgjennomgang/stemmegivningsprosessen forklart over. Dette skyldes hovedsakelig at feiloversettelser som ikke nødvendigvis er feilaktige kan få så mange oppstemmer at det ikke lenger er mulig å foreslå bedre oversettelse, selv om noen har slik.

Hvis du har tidligere historie med bidrag på Crowdin eller en annen lokaliseringsplattform/tjeneste som vi kan bekrefte og anta pålitelighet, vi er glade for å gi deg en godt tilgang til et språk som du bidrar til, Slik at du kan godkjenne en gitt oversettelse og gjøre den konsekvent. Det er ingen enkel lesing, særlig fordi ASF fra tid til annen kan være veldig teknisk "og veldig vanskelig å oversette, men vi forstår at det ofte trengs for en perfekt oversettelse. Derfor kan du hjelpe med å lære mer om det angitte språket, **[la oss få vite](https://crowdin.com/messages/create/13177432/240376)**, men ha i betraktning at du må sikkerhetskopiere forespørselen din med tidligere lokaliseringsbidrag som vi kan verifisere (e. . arb. å jobbe med ASF-lokalisering på Crowdin, eller med et annet prosjekt). Vi kan også tillate at mer avanserte brukere tar opp innledende avlesning, hvis vi kjenner dem personlig og de er i stand til å samarbeide med resten av samfunnet, for å lokalisere ASF på det språkets beste.

Generelle regler for lesing - ikke snu, lytt til brukere, Arbeid som prosjektleder og løse problemstillinger og sørge for at du gjør ting bedre og ikke verre.

---

### Problemer

Hvis du har et problem med spesiell oversettelse, f.eks. du vet ikke hvordan du skal oversette den, godkjente oversettelser er feil, du trenger mer spesifikk kontekst, eller lik, legg ut en kommentar under spesifikk streng, og merk det med [X] Issue.

**Unngå å bruke saksmerk hvis du ikke trenger teknisk forklaring/utvikling eller admin handling**. Du kan bruke kommentarer til diskusjon relatert til oversettelse av den gitte strengen, men saken skal bare brukes når du trenger ytterligere teknisk forklaring eller adminkorrigering, det vil typisk involvere noen som ikke engang snakker språket du oversetter til, Så vennligst les med engelsk når du kommenterer saker (slik at vi kan forstå hva problemet er).

Det finnes for tiden 4 støttede saker:
- Generelt spørsmål - for alt annet som ikke passer noen feil nedenfor. Generelt sett bør denne type **unngås**, som om ditt problem ikke passerer, da er det svært sannsynlig at **ikke** er et oversettelsesproblem. Dette valget er likevel tilgjengelig her for alle andre tilfeller.
- Gjeldende oversettelse er feil - dette burde brukes **bare** hvis oversettelsen ikke ble forhåndsgodkjent av tilgjengelig tilgjengelig allerede, og du mener at det er feil, for eksempel at det har en typo, eller at du har et gyldig forslag om hvordan du kan forbedre den. Denne typen bør aldri brukes i oversettelser som er drevet av samfunnet (stemme), som i dette tilfellet bør du kontakte brukeren av gitt oversettelse og be ham om korrigering, eller rett og slett stemme på bedre oversettelse, som angitt i gjennomgangen. Vi vil fjerne godkjenningen av oversettelsen og varsle riktig ansvarlig for språkvalg for å ta hensyn til din kommentar og verifisere igjen.
- Mangel på kontekstuell informasjon - dette er hva du skal bruke hvis du ikke er sikker på hvilken del av ASF du oversetter, hva er konteksten til gitt streng, eller formålet med den. Denne typen skal bare brukes til ASF-utvikling, det betyr at du trenger faglig bistand da du ikke er sikker på hvordan du skal oversette streng.
- Feil i kildestrengen - dette skal bare brukes hvis du mener at originalen (engelsk) er feil. Helt sjelden, men ikke alle oss snakker heller engelsk: engelsk: så la være å bruke den hvis du har en generell idé om hvordan den kan bli bedre. Eventuelt da dette er strengt knyttet til utviklingen. du kan bruke våre **[GitHub problemer](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** til det formålet, hvis du ønsker det.

---

### Oversettelse fremgang

Hvert språk har to stater ferdigstilling - oversettelse og ”proof-reading”.

Språk anses som **oversatt** når oversettelse fremgang når 100%. På dette tidspunktet er enhver lokaliserbar tekst som brukes av ASF, korrekt mening, som er stor. Men som ikke betyr at det ikke er rom for forbedring - hele tiden er samfunnets stemmegivning aktivert, og du kan likevel foreslå en bedre oversettelse til allerede oversatte deler, i tillegg til å stemme på eksisterende. Vær oppmerksom på at fuloversatte språk fremdeles kan falle under 100% når vi endrer eksisterende strenger eller legge til nye under utvikling. Du kan sette opp passende crowdinvarslinger hvis du vil motta e-post når dette skjer.

Utvalgte språk kan ha passende overskrifter som validerer oversettelser og godkjenner siste versjoner. Dette er endelig pass etter oversettelse skjer og gir mulighet for å forbedre lokalisering ytterligere.

ASF vil inkludere språk **så snart som mulig**, noe som betyr at det ikke trenger å bli godkjent, eller til og med 100% oversatt. De faktiske strengene som skal brukes, er alltid de mest populære når det gjelder stemmene, med mindre de valgte proofarader ellers (sjelden). Derfor du kan se at innsatsen din er inkludert i neste ASF-utgivelse – våre automatiseringssystemer slår sammen oversettelser fra Crowdin tilbake til ASF-repoet daglig.

---

## Manglende språk

Som standard har ASF-prosjekt bare åpen oversettelse for topp 30 språk som snakkes verden over. Hvis du ønsker å legge til en annen (eller en lokal oppringing til allerede tilgjengelig en), vennligst **[gi oss beskjed om](https://crowdin.com/messages/create/13177432/240376)** og vi skal legge til det ASAP. Vi ønsker ikke å åpne flere hundre forskjellige språk hvis ingen skal oversette dem, derfor har vi begrenset det til noe rettferdig tall. Vennligst ikke nøl med å kontakte oss hvis du ønsker å oversette noen ikke-oppførte språk, det er veldig enkelt for oss å legge til et annet. Bare sørg for at du har faktisk villighet og beslutter å oversette ASF til språket ditt, før du bestemmer deg for å kontakte oss.

For en fullstendig liste over alle tilgjengelige språk som ASF kan oversettes til, **[klikk her](https://developer.crowdin.com/language-codes)**.

---

## Pluralisering

Alle språk har egne regler for pluralisering. Disse reglene finnes på **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** som angir deres nummer og nøyaktige språkbetingelser.

Vi gjør vårt beste for å tilby fleksibel lokalisering, og så lenge som mulig, vil dette også inneholde flertallsregler. For eksempel vil vi oversette følgende streng til polsk i dag:

> Lansert {PLURAL:nε{n} månedmonthstruction@@{n} måneder} siden

`PLURAL` nøkkelord her blir behandlet på en spesiell måte ettersom det lar deg ta med alle flertallsformer som ditt språk støtter. Hvis du tar en titt på CLDR, vil du se at det på engelsk bare er 2 kortformer - "én" og "andre". Og som du kan se ovenfor har vi begge disse definert - `{n} måned` og `{n} måneder`.

Men vårt polske språk har faktisk 4 av dem - "én", "få, "mange" og "andre". Det betyr at vi bør definere alle disse til fullføring. Lokaliseringsverktøyene våre er allerede smarte nok til å velge passende flertallsskjema basert på språkregler, Derfor skal du bare definere alle disse i oversettelsen:

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

Denne måten vi har definert alle 4 flertallsformer for vårt polske språk, og siden vår lokaliseringsbibliotek allerede kjenner de eksakte reglene, Det vil riktig bruke det riktige skjemaet for gitt `{n}` nummer.

Det er ikke obligatorisk å definere alle flertallsskjemaer som brukes av språket ditt. Hvis vi mangler, vil vårt lokaliseringsbibliotek bruke sist definerte skjema på stedet. Det er en god idé å definere alle flertallsformer som brukes av ditt språk, men i noen tilfeller kan gjenværende flertallsformer være de samme som den siste, da er det ikke nødvendig å gjenta dem. I vårt eksempel ovenfor var det obligatorisk, som "andre" form i Polsk for måneder er "likestrøms", ikke "miesieεcy" som i "mange".

---

## Wiki

Vår crowdinplattform gjør at du også kan lokalisere wikien selv. Dette er et veldig kraftig verktøy, siden det lar deg opprette en hel ASF-dokumentasjon på ditt morsmål, Hvordan løse det siste problemet effektivt når det kommer til ASF-lokalisering. Sammen med oversettelse av programmet og alle dets deler gjør dette lokalisering fullført.

Wiki er litt spesielt spesielt her siden det er online hjelp der du ikke trenger å holde seg med den opprinnelige setningen for mye. Dette betyr at du ønsker å være så naturlig med ditt språk som mulig. og levere opprinnelig mening og hjelp – ikke nødvendigvis påføre opprinnelig streng, brukte ord og faktisk punktlighet. Ikke vær redd for å skrive tråden om til noe langt mer naturlig for språket, så lenge du holder den generelle retningen og hjelper som følger med i setningen.

---

### Globale linker

Vår crowdin-plattform lar deg også tilpasse den originale teksten for å få den til et nytt (lokalisert) sted.

ASF inneholder lenker på nesten alle sider for enklere navigasjon samt sidepanel til høyre. Den fantastiske fakta er at du kan redigere alt, da, "fiksing" lenker for å peke på lokaliserte sider for ditt språk. Det må være litt varsomt å gjøre det, men det er mulig.

For eksempel ASF **[på hjemmesiden](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)** inneholder en tekst som:

> Hvis du er ny bruker, anbefaler vi at du starter med **[å sette opp](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** -veiledningen.

Det som opprinnelig skrives som:

```markdown
Hvis du er en ny bruker anbefaler vi at du begynner med **[setter opp] (https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** guiden.
```

På publikum, først skal du gjøre går til dine tekstbehandlerinnstillinger og å sikre at HTML-koder er satt til "Vis" for deg. Dette er veldig viktig hvis du velger å lokalisere wikien.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Når du oversetter crowdin, avhengig av formatering, vil du se ASF-koblinger i teksten, enten som:

* Streng å oversette sammen med HTML-koder (majoriteten av strenger, der bare en del av setningen er en lenke)
* Alone string å oversette, med koblingen inkludert i `Skjult tekster` -> `Linkadresser` (sjelden, når hele strengen er en lenke, mest vanlig på sidepanelet - de krever korrekturlesertilgang til å oversette, trimlig)

I vårt eksempel ovenfor er det første tilfellet (siden bare "innstilling" er en link), så i crowdin vil vi se det som:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Uavhengig av tilfelle, bør du først kopiere kildestrengen og oversette den som vanlig, og la hele HTML-koden (hvis den finnes) være intakt. Dette vil være eksempel på oversettelse til polsk språk:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Hvis linken er en generisk lenke som peker utenfor wikien (f.eks. til nyeste ASF-utgivelse), kan du forlate den, ettersom det ikke er siden du ikke ønsker å redigere det. Du kan lagre det og flytte fremover.

Hvis koblingen **derimot peker** lenger inne i wikien, Som det ene ovenfor kan du faktisk korrigere det for å peke på en ny (lokalisert) plassering. Du gjør dette ved å nøye legge til `-locale` til mål-URL i `<a>` tag, slik:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Vær veldig forsiktig med dette, og sørg for at URL-adressen faktisk eksisterer, siden om du gjør en feil, vil denne linken slutte å fungere. Hvis du lykkes, har du nå en fullt funksjonell oversettelse med kobling som peker til oversatt (i vår tilfelle `Setting-up-pl-PL`) side.

Gjør trinnene ovenfor vil oversette vår HTML tilbake for å merke:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

Og endelig inn i wiki-tekst:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

Når ingen HTML finnes (andre sak), dette er enda enklere siden du bare kan gå til `Skjulte tekster` -> `Linkadresser`.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

Derfra kan du enkelt korrigere koblingen til å peke på ny plassering, uten å gå i gang med HTML i det hele tatt:

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Lokale linker

På tvers av wikien finner du også lokale lenker som peker til den delen av dokumentet. Disse koblingene inkluderer `#` tegnet, som indikerer at nettleseren som den bør bevege seg mot den delen av dokumentet.

Nå er de spesielle tilfellene, siden disse koblingene er basert på navn på delene av det gjeldende dokumentet. Mens vi for URLer har generell konvensjone om å legge til `-locale` til nettadressen, og det fungerer overalt, seksjonsnavn vil bli oversatt av deg og andre personer, så du må forsikre deg om at de peker på riktig sted.

For eksempel finner du `#introduction` link i vår **[konfigurasjon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#introduction)** avsnitt:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Siden vi skal oversette "Introduction"-ord til "Wprowadzenie" for vårt polske språk, Vi trenger å korrigere denne linken fordi det vil stoppe å fungere øyeblikket vi gjør dette.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

På denne måten vil vår lokale lenke fortsatt fungere, siden det nå vil nevne delen som vi bruker. Du kan korrigere linker inne i HTML-koder på akkurat samme måte.

---

### Koder blokker

Vær ekstremt forsiktig når du oversetter setninger med `<code></code>` blokkerer inni. Kodeklossen indikerer faste ASF-kodenavn eller vilkår som ikke skal oversettes. For eksempel:

> Dette er spesielt nyttig hvis du har mange nøkler å innløse og du er garantert å følge <code>RateLimited</code> status før du er ferdig med hele satsen.

Som du kan se, er `RateLimited` ord her inne i en kodeblokk og viser intern ASF-kode status som ikke skal oversettes. Likeledes bør du ikke oversette andre kodeblokker, slik som navn på konfigurasjons egenskaper (f.eks `TradingPreferences`), enum medlemmer (e. . `Stable` og `PreRelease` alternativer `UpdateChannel`) og likt.

Akkurat det er fordi ordene ikke bør oversettes, betyr ikke at du ikke kan legge til passende oversettelse ved siden av dem, for eksempel i parenteser.

> Ta funkcja jest wyjątkowo użyteczna w przypadku aktywacji dużej ilości kluczy i gwarancji napotkania statusu <code>RateLimited</code> (zbyt częstej aktywacji) przed ukończeniem całej partii.

Som du kan se over, har vi lagt til "zbyt czeεstej aktywacji", "For ofte aktivering" ved siden av `RateLimited` for å oversette den statusen på en vennlig måte, men samtidig holde opprinnelig ASF som betyr at brukeren kan se under bruk av programmet. På samme måte kan du oversetne/forklare andre, lignende saker av ulike ord og setninger.

Hvis du mener at noe upassende er inkludert i en kodeblokk, eller at det er en tekst som ikke ligger i en kodeblokk, men som skal være inni den, føler deg fri til å spørre vår crowdin om å lage passende **[issue](#issues)**. Det skjer også som et praktisk eksempel på bruk av en lokal lenke.

---

## Hall med kam

Vi vil gjerne vise vår evige takknemlighet til mennesker som har brukt mye tid og vilje til å gjøre ASF-lokalisering bedre. Deres innsats er utrolig, og du kan nyte fullstendige oversettelser, inkludert wiki, for det meste takket være dem. Som et symbol på verdsettelse, alle som er oppført her tilbys gratis tilgang til **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** funksjon på en **[be om](https://crowdin.com/messages/create/13177432/240376)**

| Bidragsyter                                                | Språk             |
| ---------------------------------------------------------- | ----------------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, spansk    |
| **[Dead_Sam](https://crowdin.com/profile/Dead_Sam)**       | Portugisisk (BR)  |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | Kinesisk (CN)     |
| **[DragonTaki](https://crowdin.com/profile/dragontaki)**   | Kinesisk (TW)     |
| **[LittleFreak](https://crowdin.com/profile/littlefreak)** | Tysk              |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | Russisk, ukrainsk |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLKAT, tysk      |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | Kinesisk (HK)     |

Takk alle for å forbedre vår ASF-lokaliseringskvalitet!