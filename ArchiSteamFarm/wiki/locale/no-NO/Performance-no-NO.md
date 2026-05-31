# Ytelse

Hovedmålet for ASF er å drive anlegget så effektivt som mulig. basert på to typer data den kan operere på - lite sett av brukergitte data som er umulig for ASF å gjette/sjekke alene, større sett med data som kan kontrolleres automatisk av ASF.

I automatisk modus lar ikke ASF deg velge spill som skal være farlig, og lar deg heller ikke skifte algoritme for oppdrett. **ASF vet bedre enn deg hva det bør gjøre, og hvilke beslutninger det bør ta for å drive med så fort som mulig**. Målet er å sette config egenskaper skikkelig, siden ASF ikke kan gjette dem alene, så er alt annet dekket.

---

For en gang siden endret Radiatortermostat algoritmen for kortdråper. Fra det punktet og fremover, kan vi kategorisere dampkontoer ved hjelp av to kategorier: disse **med** kort dråper restriksjoner, og de **uten**. Den eneste forskjellen mellom disse to typene er den faktum at konto med begrensede kortdråper ikke får noe kort fra de spiller før de spiller noe spill i minst `X` timer. Det virker som eldre kontoer som aldri har bedt om refusjon har **ubegrenset kort dråper**, mens nye kontoer og de som ba om tilbakebetaling har **begrensede kortdråper**. Dette er imidlertid bare teorien, og skal ikke tas som regel. That's why there is **no obvious answer**, and ASF relies on **you** telling it which case is appropriate for your account.

---

ASF har i dag to algoritmer om oppdretter:

**`Simple`** algoritme fungerer best for kontoer som har ubegrenset kortfall. Dette er den primære algoritmen som brukes av ASF. Bot finner spill fra gården, og slo dem en-til alle kortene er sluppet. Det er fordi kortet synker ut når man vil dyrke mer enn ett spill er nær null og helt ueffektivt.

**`Complex`** er ny algoritme som har blitt implementert for å bidra med begrenset brukerkonto for å maksimere fortjenesten også. ASF vil først bruke standard **`Simple`** algoritme på alle spill som har bestått `HoursUntilCardDrops` timer spilltid, så, hvis ingen spill med >= `HoursUntilCardDrops` timer er venstre, det vil dyrke alle spill (opptil `32` ) med grensen < `HoursUntilCardDrops` timer igjen samtidig, frem til en av dem treffer `HoursUntilCardDrops` timers-merke, så ASF vil fortsette løkken fra begynnelsen (bruk **`Enkel`** på det spillet, returner til simultan på < `HoursUntilCardDrops` og så videre). Vi kan bruke flere spilllandskap i denne saken for å kaste ut timer på spillene vi trenger for å skape riktig verdi først. Husk på at det i brukstiden, ASF **ikke er** gårdskort, så det skal heller ikke sjekke for eventuelle kortfall i denne perioden (for grunner over).

For tiden velger ASF oppgavelappens algoritme basert på `HoursUntilCardDrops` konfigurasjonseiendom (som er satt av **du**). Hvis `HoursUntilCardDrops` er satt til `0`, **`Simple`** -algoritme vil bli brukt, ellers, **`Komplett`** algoritme vil bli brukt i stedet – konfigurert til å hoppe spilltid i alle partier og få tid før de bruker kortfaller.

---

### **Det finnes ingen åpenbare svar som algoritmen er bedre for deg**.

Dette er en av grunnene til at du ikke velger algoritmen for kortoppdrett, forteller du i stedet ASF hvis kontoen har begrenset deg eller ikke. Hvis kontoen har ikke-begrensede slippslipp, **`Simple`** algoritme vil **fungere bedre** på den kontoen, siden vi ikke vil kaste bort tid på å hente alle spill til `X` timer - forholdstall er 0 % når oppdrett har flere spill. På den andre hånden hvis kontoen har begrenset konto, **`Kompleks`** -algoritmen vil bli bedre for deg, som det ikke er noe poeng å drive solo hvis spillet ikke har nådd `HoursUntilCardDrops` timer ennå - så vi bruker **spilltid** første. **så** kort i solo modus.

Ikke blindt sett `HoursUntilCardDrops` kun fordi noen fortalte deg at du - gjør tester, sammenligne resultatene, og basert på data du får. Velg hvilket alternativ som vil være bedre for deg. Hvis du setter noe minimalt i dette, vil du sørge for at ASF jobber med maksimal mulig effektivitet for kontoen din. som er sannsynligvis det du vil, med tanke på at du leser denne wiki-siden akkurat nå. Hvis det finnes en løsning som fungerer for alle, kunne du ikke få et valg - ASF bestemte seg i seg selv.

---

### Hva er den beste måten å finne ut om kontoen din er begrenset?

Sørg for at du har noen partier med **ingen spilletid tatt opp** å dyrke, helst 5+, og kjør ASF med `HoursUntilCardDrops` av `0`. Det ville være en god idé hvis du ikke spilte noe under driftsperioden for mer nøyaktige resultater (best å kjøre ASF om natten). La ASF drive de fem spillene og deretter sjekke ut dagboken for resultatene.

ASF står klart når det ble sluppet en oppgavelapp for spillet. Du er interessert i raskeste oppgavelapp oppnådd av ASF. For eksempel, hvis kontoen din er ubegrenset bør det skje et første kortfall etter ca. 30 minutter siden du begynte å parre. If you notice **at least one** game that did drop card in those initial 30 minutes, then this is an indicator that your account is **not** restricted and should use `HoursUntilCardDrops` of `0`.

På den andre hånden hvis du merker at **hvert** spill tar minst `X` antall timer før det slipper det første kortet, så er dette en indikator for deg hva du skal sette `HoursUntilCardDrops` til. Majoritet (om ikke alle) av begrensede brukere krever minst `` timer spilltid for kort å slippe, og dette er også standardverdien for `HoursUntilCardDrops` -innstillingen.

Husk at spill kan ha andre slipp-sats, dette er grunnen til at du bør teste om teorien din er riktig med **minst** 3 spill, fortrinnsvis 5+ for å sikre at du ikke er falsk i resultat, av en tilfeldighet. Et kort fall i et spill på mindre enn en time er en bekreftelse på at kontoen **ikke er** begrenset og kan bruke `HoursUntilCardDrops` av `0`, men for å bekrefte at kontoen **er** begrenset, du trenger minst flere spill som ikke dropper kort før du treffer et fastmerke.

Det er viktig å merke seg at i tidligere `HoursUntilCardDrops` var bare `0` og `2`, og dette er grunnen til at ASF hadde en enkelt `CardDropsRestricted` -egenskap som fikk bytte mellom disse to verdiene. Med nylige endringer har vi oppdaget at ikke bare de fleste brukere krever `3` timer i stedet for tidligere `2` nå, men også at `HoursUntilCardDrops` nå er dynamisk og kan treffe en hvilken som helst verdi på hver kontopeng.

Så er det selvsagt opp til deg.

Og for å gjøre den enda verre - jeg opplevde saker når folk byttet fra begrenset til fri tilstand og omvendt, enten grunnet Steam-feil (eige yea, vi har mange av disse), eller på grunn av noen logiske justeringer av ventiler. Så selv om du har bekreftet at kontoen din er begrenset (eller ikke), ikke tror det kommer til å være som det - for å kunne bytte fra ubegrenset til begrenset tid er det nok til å be om tilbakebetaling. Hvis du føler at tidligere innstilt verdi ikke lenger er passende, kan du alltid gjøre en ny test og oppdatere den deretter.

---

Som standard antar ASF at `HoursUntilCardDrops` er `3`som den negative virkningen av å sette dette på `3` når det bør være mindre enn gjort på annen måte. Dette er fordi vi i verste fall kaster bort `3` timer med oppdrett per `32` , sammenliknet med å kaste bort `3` driftstimer per enkelt spill hvis `HoursUntilCardDrops` ble satt til `0` som standard. Du bør likevel finjustere denne variabelen slik at den samsvarer med din konto for maksimal effektivitet, siden dette bare er en blind gjetning basert på potensielle ulemper, og flertallet av brukerne (slik at vi prøver å velge "mindre ond" som standard).

På nåværende tidspunkt er to over algoritmer nok for alle mulige scenarier for kontoen, For å drive anlegget så effektivt som mulig, derfor er det ikke planlagt å legge til andre.

Det er hyggelig å merke seg at ASF også inneholder manuell oppdrettsmodus som kan aktiveres av `spill` kommandand. Du kan lese mer om den i **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

## Steam glitches

Å slippe algoritmen fungerer ikke alltid slik den skal og det er helt mulig for ulike Steam-glitches å skje, for eksempel kort slippes på begrensede kontoer, oppgavelapper slippes når de avsluttes/bytter spillet, kort som ikke faller i det hele tatt når spillet spilles, og på samme måte.

Dette avsnittet er hovedsakelig for personer som lurer på hvorfor ASF ikke gjør **X**, for eksempel hurtig bytte spill til banekort raskere.

Hva er en **Steam glitch** - en spesifikk handling som utløser **udefinert** -oppførsel, som er **ikke er tiltenkt og som udokumentert og betraktes som en logisk feil**. Det er **upålitelig ved definisjon**, som betyr at den ikke kan reproduseres pålitelig med rent testmiljø. og derfor kodet uten at det er nødvendig å bruke hacker som skal gjette seg når glitch skjer, og hvordan man kjemper med den / misbruk den. Det er vanligvis midlertidig til utviklere fikser logikkfeilen, selv om noen diverse gitcher kan gå ustanselig over en svært lang periode.

Et godt eksempel på hva som regnes som en **Steam glitch** er ikke den uvanlige situasjonen med å slippe et kort når spillet er lukket, som kan bli misbrukt i noen grad med uvirksom masters spillskipsfunksjon.

- **Udefinert oppførsel** - du kan ikke si hvis det vil være 0 eller 1 kort slippes når du utløser glitten.
- **Ikke ment** - basert på tidligere erfaring og oppførsel i Steam-nettverk som ikke resulterer i samme oppførsel når du sender en enkelt forespørsel.
- **Udokumentert** - det er tydelig dokumentert på Steam nettsted hvordan kortene blir hentet, og **på hvert sted** er det tydelig angitt at det oppnås gjennom **som spiller**, IKKE avslutt spill, få prestasjoner, spill som bytter eller starter 32 spill samtidig.
- **Anses som en logikk flaw** - lukke spillet/spillene eller bytte dem bør ikke ha noe utfall på kortene som klart angis som skal oppnås gjennom **vinning spilltid**.
- **er upålitelig definisjon, kan ikke gjengis pålitelig** - den fungerer ikke for alle, og selv om det fungerte for deg én gang, kunne det ikke lenger fungere for andre gang.

Nå en gang vi innså hva Steam glitch er, og det faktum at kortene slippes når spillet lukkes **er** one, Vi kan gå videre til andre punkt - **ASF misbruker ikke Steam-nettverket på noen måte innen definisjon, og gjør sitt beste for å overholde Steam ToS, sine protokoller og hva som generelt aksepteres**. Spamming Steam-nettverk med konstant åpning / lukkeforespørsler kan betraktes som en **[DoS angrep](https://en.wikipedia.org/wiki/Denial-of-service_attack)** og **direkte bryter med [Steam Online Conduct](https://store.steampowered.com/online_conduct/?l=english)**.

> Som en Steam-abonnent samtykker du i å overholde følgende adferdsregler.
> 
> Du vil ikke:
> 
> Institute angrep på en Steam server eller andre forstyrret Steam.

Det spiller ingen rolle om du er i stand til å utløse Steam glitch med andre programmer (for eksempel IM), og det spiller ingen rolle hvis du er enig med oss og anser slik atferd som DoS-angrep, eller ikke – det er opp til Radiatortermostat å bedømme dette, men hvis vi anser det som utnytting/misbruk av ikke-tilsiktede handlinger gjennom overdreven Steam-nettverksforespørsler, da kan du være ganske sikker på at Radiatortermostaten vil ha tilsvarende syn på dette.

ASF er **vil aldri** dra nytte av Steam exploits, misbrukere, hacker eller annen aktivitet som vi ser som **er ulovlig eller uønsket** ifølge Steam ToS, Steam Online duct eller enhver annen klarert kilde som kan indikere at ASF-aktivitet er uønsket av Steam-nettverk, som nevnt i **[som bidro til](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)**

Hvis du ønsker å risikere Steam-kontoen din for å drive et par prosent kort raskere enn vanlig, så trist ASF vil aldri tilby noe som dette i automatisk modus, selv om du fortsatt har `spill` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** som kan brukes som et verktøy for å gjøre hva som helst ved nettverksinteraksjoner med Steam. Vi anbefaler ikke å dra nytte av Steam glitches og utnytte dem for egen gevinst - ikke bare med ASF, men med andre verktøy også. På slutten av denne, så er det din konto og hva du ønsker å gjøre med det – bare ha det i tankene at vi advarte deg.