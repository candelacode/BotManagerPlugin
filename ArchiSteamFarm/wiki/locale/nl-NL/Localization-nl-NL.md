# Localisatie

ASF wordt aangedreven door de Crowdin-service, wat het voor iedereen mogelijk maakt om te helpen met het vertalen van ASF in alle wereldwijd gesproken talen. Kijk voor meer gedetailleerde uitleg hoe Crowdin werkt, **[Crowdin introductie](https://support.crowdin.com/crowdin-intro)**.

Als u geïnteresseerd bent in wat er momenteel gaande is, kunt u **[ASF Crowdin activiteit](https://crowdin.com/project/archisteamfarm/activity_stream)** bekijken.

---

## Bereik

Ons platform ondersteunt de lokalisatie van ons belangrijkste ASF-programma en de lokaliseerbare inhoud die we er samen mee aanbieden. Dit geldt in het bijzonder voor onze ASF-WebConfigGenerator, ASF-ui en onze wiki. Dit alles is mogelijk te vertalen via handige crowdin-interface.

---

## Bezig met registreren

Als u wilt helpen met ASF, door vertalingen te vertalen, te beoordelen of goed te keuren Meld u aan op onze **[Crowdin projectpagina](https://crowdin.com/project/archisteamfarm)**. Registratie is eenvoudig en absoluut gratis! Na het inloggen kunt u talen kiezen die u toegewezen wilt krijgen, ga dan naar ASF tekenreeksen en help de rest van de gemeenschap met het vertalen van ASF in alle meest populaire talen!

---

### Vertalen

Als de taal van jouw keuze nog enkele tekenreeksen ontbreekt, kun je ze pakken en beginnen met het werken aan de vertaling. We hebben geprobeerd ons best te doen wat betreft flexibiliteit van de vertalingen, Daarom bevatten veel tekenreeksen extra variabelen die ASF zal bieden tijdens de runtime - deze zijn tussen haakjes en een nummer, zoals `{0}`. Dit stelt je in staat om het standaard ASF formaat van de tekenreeks te wijzigen, b.v. door de ASF-meegeleverde variabele te verplaatsen op een plaats die voldoet aan je taal en je vertaling, in plaats van te worden gedwongen tot strikte context en formaat. Dit is vooral belangrijk in RTL-talen, zoals het Hebreeuws.

Je zou bijvoorbeeld een tekenreeks kunnen hebben:

> We hebben {0} spellen te boerderen.

Maar op basis van je taal kan het volgende zin meer zin hebben:

> Het aantal landbouwpartijen is gelijk aan {0}.

Of:

> {0} is het aantal partijen op boerderij.

De flexibiliteit wordt speciaal voor u ingevuld, zodat je een beetje ASF zin kunt hernoemen om beter in je taal te passen en ASF-verstrekte nummer of andere informatie te verplaatsen op een plek die bij je vertaling past (in plaats van elk onderdeel onafhankelijk te vertalen). Dit verbetert de algehele vertaalkwaliteit.

---

### Beoordeling

Als je tekenreeks al door iemand anders is vertaald, kun je ervoor stemmen. Stemmen maakt het mogelijk om de beste variant van de vertaling te kiezen, in plaats van bij een eerste suggestie te blijven - hierdoor wordt de algehele kwaliteit van de vertalingen nog verder verbeterd. Je kunt stemmen op reeds beschikbare suggesties, of je eigen vertaling voorstellen, die hetzelfde proces zal doorlopen. Uiteindelijk zal de definitieve tekenreeks worden gekozen op basis van de meeste gestemde suggestie, of als een keuze uit proeflezer die voor die taal is geselecteerd en die persoonlijk de gegeven vertaling goedkeurt (op basis van uw stemmen).

**Je hebt geen goedkeuring nodig om de vertaalde tekenreeksen in ASF** te zien. Goedkeuring betekent simpelweg dat iemand die van ons vertrouwt, de inhoud heeft gecontroleerd, zoals in - de definitieve versie van de vertaling heeft gekozen. Het is helemaal prima om niet goedgekeurde door de gemeenschap gedreven vertalingen te hebben, waar je op de beste stemt. Zolang het vertaald is, is alles in orde! En als je vindt dat de huidige vertaling slecht is, kun je altijd op de betere stemmen, of er zelf een voorstellen.

---

### Proof-lezen

Het is een goed idee om een consistente vertaling te hebben, zelfs als het mogelijk vrijheid zou kunnen nemen van het door de gemeenschap beoordeel/stemproces hierboven uitgelegd. Dit is voornamelijk omdat onjuiste vertalingen die niet per se slecht zijn, zo veel upvotes kunnen krijgen dat het niet meer mogelijk is om een betere vertaling te suggereren, Zelfs als iemand zo is.

Als u eerdere bijdragen op Crowdin of een andere lokalisatieplatform/dienst hebt die we kunnen verifiëren en ervan kunnen uitgaan dat we betrouwbaar zijn. We geven je graag toegang tot de taal waaraan je bijdraagt dus je kunt de gegeven vertaling goedkeuren en consistent maken. Proof-reading is geen gemakkelijke taak, vooral omdat ASF van tijd tot tijd zeer "technisch" kan zijn en echt moeilijk te vertalen is. maar we begrijpen dat het vaak nodig is voor een perfecte vertaling. Daarom als u kunt helpen door de gegeven taal te lezen, **[laat ons weten](https://crowdin.com/messages/create/13177432/240376)**, maar houd er rekening mee dat u uw verzoek moet back-uppen met bijdragen uit het verleden aan lokalisatie, die we kunnen verifiëren (bv. . werken met ASF-lokalisatie op Crowdin, of met elk ander project). We kunnen ook meer geavanceerde gebruikers toestaan om eerste proof-of-read op te halen. als we ze persoonlijk kennen en ze in staat zijn samen te werken met de rest van de gemeenschap om ASF het best in die taal te lokaliseren.

Algemene regels gelden voor proeflezen - maak geen haast, luister naar uw gebruikers werken als projectmanager, problemen oplossen, ervoor zorgen dat je dingen beter en niet slechter maakt.

---

### Problemen

Als u een probleem heeft met een specifieke vertaling, bijvoorbeeld u weet niet hoe u het moet vertalen, goedgekeurde vertaling is niet juist, u heeft meer specifieke context nodig, of liever: plaats een opmerking in een specifieke tekenreeks en markeer deze met [X] Issue.

**Gelieve te voorkomen dat u problemen gebruikt als u geen technische/development uitleg of admin actie** nodig heeft. Je bent vrij om reacties te gebruiken voor de discussie over de vertaling van de gegeven tekenreeks, maar issue mag alleen worden gebruikt wanneer u verdere technische uitleg of admin correctie nodig hebt, en het zal meestal iemand betreffen die niet eens de taal spreekt waar je naar vertaalt, dus blijf bij Engels bij het schrijven van issue commentaar (zodat we begrijpen wat het probleem is).

Er zijn momenteel 4 ondersteunde problemen:
- Algemene vraag - voor alle andere vragen die niet passen bij onderstaand probleem. In het algemeen moet dit type **worden vermeden**, alsof uw probleem niet past, dan is het zeer waarschijnlijk een vertaalprobleem **niet** Toch is deze optie hier voor alle andere gevallen beschikbaar.
- Huidige vertaling is verkeerd - dit moet worden gebruikt **alleen** als de vertaling is vooraf goedgekeurd door de proof-reader, en je vindt dat het verkeerd is, bijvoorbeeld het heeft een typefout of je hebt een geldige suggestie om het te verbeteren. Dit type mag nooit worden gebruikt in vertalingen die mogelijk zijn door de gemeenschap (stemmen), zoals in dit geval moet u contact opnemen met de gebruiker van de vertaling en hem om correctie vragen, of stem gewoon voor een betere vertaling, zoals aangegeven in het gedeelte met de beoordeling. We zullen de goedkeuring van de vertaling verwijderen en de juiste proof-reader in opdracht van de taal op de hoogte stellen om rekening te houden met uw reactie en deze te verifiëren.
- Gebrek aan contextuele informatie - dit is wat je moet gebruiken als je niet zeker weet welk deel van ASF je vertaalt, wat is de context van bepaalde tekenreeks, of het doel ervan. Dit type moet alleen worden gebruikt voor ASF ontwikkelingen, dit betekent dat je technische ondersteuning nodig hebt omdat je niet zeker weet hoe je de aangegeven tekenreeks moet vertalen.
- Fout in de brontekenreeks - dit mag alleen worden gebruikt als u denkt dat de originele (Engels) tekenreeks onjuist is. Heel zeldzaam, maar ook niet iedereen spreekt Engels. Voel u zo vrij om het te gebruiken als u een algemeen idee hebt hoe het kan worden verbeterd. Of omdat dit strikt verband houdt met de ontwikkeling. je kan onze **[GitHub issues](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** voor dat doel gebruiken, als je wilt.

---

### Voortgang van vertaling

In elke taal zijn er twee voltallige statussen: vertaling en proof-of-reading .

Taal wordt beschouwd als **vertaald** wanneer de vertaalvoortgang 100% bereikt. Op dit moment heeft elke vertaalbare tekenreeks die ASF gebruikt een goede betekenis, wat geweldig is. Maar dat betekent niet dat er geen ruimte voor verbetering is - gemeenschapsstemming is voortdurend ingeschakeld en u kunt nog steeds betere vertalingen voor reeds vertaalde onderdelen voorstellen. en niet alleen voor bestaande stemmen. Houd er rekening mee dat volledig vertaalde talen nog steeds onder 100% kunnen vallen wanneer we bestaande tekenreeksen wijzigen of tijdens de ontwikkeling nieuwe toevoegen. U kunt passende crowdin meldingen instellen als u e-mail wilt ontvangen wanneer dit gebeurt.

Geselecteerde talen kunnen passende proeflezers hebben die vertalingen valideren en definitieve versies goedkeuren. Dit is de laatste doorgang nadat de vertaling heeft plaatsgevonden en maakt het mogelijk om de lokalisatie verder te verbeteren.

ASF will include given language **as soon as possible**, which means that it doesn't need to be approved, or even 100% translated. De echte tekenreeksen die zullen worden gebruikt zijn altijd de meest populaire in termen van stemmen, tenzij de gekozen proeflezer anders heeft besloten (zelden). Daarom je kan zien dat je inspanningen worden opgenomen in de allereerste ASF-versie - onze automatiseringssystemen combineren vertalingen van Crowdin terug naar ASF-repo op dagelijkse basis.

---

## Ontbrekende talen

Standaard heeft het ASF-project een open vertaling alleen voor de top 30 talen die wereldwijd worden gesproken. If you'd like to add another one (or a local dialect to already available one), please **[let us know](https://crowdin.com/messages/create/13177432/240376)** and we'll add it ASAP. We willen geen honderden verschillende talen openen als niemand ze gaat vertalen, daarom beperken we het tot een redelijk aantal. Aarzel niet om contact met ons op te nemen als je een taal wil vertalen die niet is vermeld, het is heel eenvoudig voor ons om er nog een toe te voegen. Zorg ervoor dat je de wil en vastberadenheid hebt om ASF te vertalen in jouw taal, voordat je besluit contact met ons op te nemen.

Voor een volledige lijst van alle beschikbare talen waarnaar ASF vertaald kan worden **[klik hier](https://developer.crowdin.com/language-codes)**.

---

## Pluralisatie

Elke taal heeft zijn eigen regels met betrekking tot pluralisatie. Deze regels kunnen worden gevonden op **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** waarin hun aantal en precieze taalvoorwaarden worden gespecificeerd.

We doen ons best om je flexibele lokalisatie aan te bieden, en dit omvat zo lang mogelijk ook meervoudige regels. We vertalen vandaag bijvoorbeeld de volgende tekenreeks naar het Pools:

> {PLURAL:n+unnamed@@0{n} maanddad{n} months} geleden uitgebracht

`PLURAL` sleutelwoord hier wordt op een speciale manier behandeld, omdat het je in staat stelt om alle meervoudsvormen die jouw taal ondersteunt toe te voegen. Als je een kijkje neemt bij CLDR, zie je dat er in het Engels slechts 2 kardinale vormen - "één" en "andere" zijn. En zoals je hierboven kunt zien, hebben we beide gedefinieerd - `{n} maand` en `{n} maanden`.

In onze Poolse taal zijn er echter vier - "één", "minder", "veel" en "andere" talen - in feite ook vier talen in het Pools. Dat betekent dat we ze allemaal moeten definiëren om af te ronden. Onze lokalisatietools zijn al slim genoeg om de juiste meervoudsvorm te kiezen gebaseerd op taalregels. Daarom hoef je alleen maar alle in de vertaling te definiëren:

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

Op deze manier hebben we alle 4 meervoudsvormen voor onze Poolse taal gedefinieerd en sinds onze lokalisatie bibliotheek de exacte regels al kent het zal correct het juiste formulier gebruiken voor opgegeven `{n}` nummer.

Het is niet verplicht om alle meervoudsvormen die door uw taal worden gebruikt te definiëren. Als het ontbreekt, zal onze lokalisatiebibliotheek het laatst gedefinieerde formulier op zijn plaats gebruiken. Het is een goed idee om alle meervoudsvormen die jouw taal gebruikt te definiëren. maar in sommige gevallen kunnen de resterende meervoudsvormen hetzelfde zijn als de laatste, in welk geval het niet nodig is om ze te herhalen. In ons bovenstaande voorbeeld was het verplicht, omdat "ander" in het Pools maandenlang "miesiazuelca" is, en niet "miesiëzië" , zoals in "veel".

---

## Wiki

Ons crowdin-platform stelt u ook in staat om zelfs de wiki zelf te lokaliseren. Dit is een zeer krachtige tool, omdat het je in staat stelt om een hele documentatie van ASF te maken in je moedertaal. Het allerlaatste probleem oplossen als het gaat om lokalisatie van ASF. Samen met de vertaling van het programma en al zijn onderdelen maakt dit de vertaling compleet.

Wiki is in dit opzicht een beetje speciaal, omdat het online hulp is waar je niet te veel aan de originele zin hoeft te voldoen. Dit betekent dat u zo natuurlijk mogelijk wilt zijn met uw taal en bezorg originele betekenis en help - niet per definitie originele tekenreeks, gebruikte woorden en daadwerkelijke leesteken. Wees niet bang om de string te herschrijven naar iets dat veel natuurlijker is voor jouw taal, zolang je de algemene richting en hulp in de zin houdt.

---

### Globale links

Ons crowdin-platform stelt u ook in staat om de originele tekst aan te passen zodat deze wijst op nieuwe (lokaliseerde) locaties.

ASF bevat links op bijna elke pagina om makkelijker te navigeren, evenals links aan de rechterkant. Het geweldige feit is dat u dat allemaal kunt bewerken, "repareren", koppelingen naar juiste gelokaliseerde pagina's voor uw taal. Het moet een beetje voorzichtig zijn om dat te doen, maar het is mogelijk.

Bijvoorbeeld, ASF **[homepage](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)** bevat een tekst zoals:

> Als je een nieuwe gebruiker bent, raden we aan om te beginnen met **[het instellen van](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** handleiding.

Wat oorspronkelijk geschreven is als:

```markdown
Als je een nieuwe gebruiker bent, raden we aan om te beginnen met **[setup up](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** handleiding.
```

Op de crowdin ga je eerst naar je editor instellingen en zorg ervoor dat HTML-tags voor jou zijn ingesteld op "Toon". Dit is erg belangrijk als je besluit om de wiki te lokaliseren.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Nu, tijdens het vertalen op crowdin, afhankelijk van de opmaak, ziet u de ASF-koppelingen in de tekst als:

* Tekenreeks te vertalen met HTML tags (meerderheid van tekenreeksen, waar alleen een deel van de zin een link is)
* Alleen te vertalen tekenreeks, met link in `Verborgen teksten` -> `Link adressen` (rare, waar hele tekenreeks een link is, de meest voorkomende in de sidebar - deze vereisen helaas toegang tot proeflezer om te vertalen)

In ons bovenstaande voorbeeld is dit het eerste geval (omdat alleen "instellen" een link is), dus in crowdin zien we het als:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Ongeacht het geval, eerst moet u de brontekenreeks kopiëren en deze zoals gebruikelijk vertalen, waarbij hele HTML-tekst (indien aanwezig) intact blijft. Dit zou een voorbeeld zijn van vertaling voor de Poolse taal:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Nu, als de link een algemene link is die verwijst buiten de wiki (bijvoorbeeld naar de laatste ASF release), je kan het laten zoals het is omdat je het niet meer wilt bewerken. Je kunt het opslaan en vooruit bewegen.

Echter, als de link **** verder wijst in de wiki, Net als de bovenstaande kunt u het corrigeren om te wijzen naar een nieuwe (lokaliseerde) locatie. Je doet dit door voorzichtig `-locale` toe te voegen aan de doel-URL in `<a>` tag, zoals hieronder:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Wees heel voorzichtig hierover, en zorg ervoor dat uw URL inderdaad bestaat, want als u zich vergist zal die link stoppen met functioneren. Als het je gelukt is, heb je nu een volledig functionele vertaling met een link die wijst naar vertaald (in ons geval `Instellingen-pl-PL`) pagina.

Door de bovenstaande stappen te doen, wordt onze HTML terug naar markdown goed vertaald:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

En tot slot de wiki-tekst:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

When no HTML is present (second case), this is even easier since you can just go to `Hidden texts` -> `Link addresses`.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

Vanaf daar kunt u eenvoudig de link corrigeren naar een nieuwe locatie, zonder zelfs de moeite te nemen met HTML

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Lokale koppelingen

Over de wiki vindt u ook links die naar een bepaald gedeelte van het document wijzen. Deze links bevatten een `#` karakter, wat aangeeft dat de webbrowser naar dat gedeelte van het document moet gaan.

Nu gaat het om bijzondere gevallen, aangezien die links gebaseerd zijn op de namen van de delen van het huidige document. Terwijl we voor URL's een algemene overeenkomst hebben om `-locale` toe te voegen aan de URL, werkt het overal, sectie namen zullen worden vertaald door jou en andere mensen, dus je moet ervoor zorgen dat ze naar de juiste locatie wijzen.

Bijvoorbeeld, je kunt `#introductie` link vinden in onze **[configuratie](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#introduction)** sectie:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Omdat we het woord "Inleiding" gaan vertalen in "Wprowadzenie" voor onze Poolse taal. We moeten deze koppeling corrigeren, omdat hij stopt met werken op het moment dat we dit doen.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

Op deze manier zal onze lokale link blijven werken, omdat hij nu verwijst naar de naam van de sectie die we gebruiken. Je kunt links in HTML-tags op precies dezelfde manier corrigeren.

---

### Code blokken

Wees uiterst voorzichtig wanneer je zinnen vertaalt met `<code></code>` blokken erin. Codeblok geeft vaste ASF-codenamen of termen aan die niet vertaald moeten worden. Bijvoorbeeld:

> Dit is vooral handig als je veel sleutels te verzilveren hebt en je gegarandeerd de status <code>RateLimited</code> te raken voordat je klaar bent met je hele batch.

Zoals je kunt zien, staat hier het woord `RateLimited` in een code blok en geeft de interne ASF code status aan die niet moet worden vertaald. Op dezelfde manier zou u geen andere codeblokken moeten vertalen, zoals namen van configuratie-eigenschappen (bv. `TradingPreferences`), leden (bijvoorbeeld ). . `Stal` en `PreRelease` opties van `Update Channel`) en evenmin.

Echter, alleen omdat deze woorden niet vertaald moeten worden, betekent dit niet dat je niet de juiste vertaling naast ze kunt toevoegen, bijvoorbeeld tussen haakjes.

> Ta funkcja jest wyjątkowo użyteczna w przypadku aktywacji dużej ilości kluczy i gwarancji napotkania statusu <code>RateLimited</code> (zbyt częstej aktywacji) przed ukończeniem całej partii.

Zoals je hierboven kunt zien, hebben we "zbyt czeplorstej aktywacji" toegevoegd." letterlijk "te vaak activeren" naast `RateLimited` om die status op een vriendelijke manier te vertalen. terwijl originele ASF hetzelfde blijft, wat betekent dat de gebruiker kan zien tijdens het gebruik van het programma. Op dezelfde manier kunt u andere, vergelijkbare gevallen van verschillende woorden en zinnen vertalen/uitleggen.

Als je denkt dat er iets ongepast in een codeblok staat, of dat er een tekst is die niet in een codeblok zit maar er wel in moet zitten, voel je vrij om te vragen op onze crowdin door de juiste **[issue](#issues)** te maken. Dit is ook een praktisch voorbeeld van het gebruik van een lokale schakel.

---

## Hal van roem

We willen graag onze eeuwige dankbaarheid betuigen aan mensen die een aanzienlijk deel van hun tijd en wil hebben doorgebracht om de lokalisatie van ASF te verbeteren. Hun inspanningen zijn ongelooflijk en u kunt genieten van volledige vertalingen, met inbegrip van de wiki, grotendeels dankzij hen. Als teken van waardering, alle mensen die hier worden vermeld, krijgen gratis toegang tot **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)</a>** functie op een **[aanvraag](https://crowdin.com/messages/create/13177432/240376)**.

| Medewerker                                                 | Leren               |
| ---------------------------------------------------------- | ------------------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, Spaans      |
| **[Dood_Zam](https://crowdin.com/profile/Dead_Sam)**       | Portugees (BR)      |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | Chinees (CN)        |
| **[DrakenTaki](https://crowdin.com/profile/dragontaki)**   | Chinees (TW)        |
| **[LittleFreak](https://crowdin.com/profile/littlefreak)** | Duits               |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | Russisch, Oekraïens |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT, Duits       |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | Chinees (HK)        |

Bedankt voor het verbeteren van onze ASF lokalisatiekwaliteit!