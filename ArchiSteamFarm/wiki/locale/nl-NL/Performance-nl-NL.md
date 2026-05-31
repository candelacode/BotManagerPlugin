# Uitvoering

De primaire doelstelling van ASF is het zo effectief mogelijk boerenbedrijf op basis van twee soorten gegevens kan deze werken - kleine set aan gegevens die door de gebruiker zijn verstrekt en die onmogelijk alleen te raden of controleren. en een groter aantal gegevens dat automatisch kan worden gecontroleerd door ASF.

In automatische modus staat ASF je niet toe om de spellen te kiezen die gekweekt moeten worden, en je kunt ook geen kaartjes landbouwalgoritme wijzigen. **ASF weet beter dan jij wat het moet doen en welke beslissingen het moet nemen om zo snel mogelijk** te boeren. Uw doel is om de configuratie-eigenschappen correct in te stellen, omdat ASF ze niet alleen kan raden, al het andere is gedekt.

---

Enige tijd geleden heeft Radiatorkraan het algoritme van de kaart gewijzigd. From that point onwards, we can categorize steam accounts by two categories: those **with** card drops restricted, and those **without**. Het enige verschil tussen deze twee typen is het feit dat accounts met beperkte kaartdruppels geen kaart kunnen krijgen van het gegeven spel totdat ze ten minste `X` uren spelen. It seems that older accounts that never asked for refund have **unrestricted card drops**, while new accounts and those who did ask for refund have **restricted card drops**. Dit is echter slechts een theorie, en mag niet als regel worden beschouwd. Daarom is er **geen duidelijk antwoord**, en ASF is afhankelijk van **je** vertelt welk geval geschikt is voor je account.

---

ASF bevat momenteel twee landbouwalgoritmen:

**`Eenvoudig`** algoritme werkt het beste voor accounts met onbeperkte kaartdalingen. Dit is het primaire algoritme dat ASF gebruikt. Bot vindt spellen om te boerderijen, en boerderijen ze één voor één totdat alle kaarten worden verwijderd. Dit komt doordat het percentage van een kaartje daalt wanneer meer dan één spel bijna nul is en volledig ineffectief is.

**`Complex`** is een nieuw algoritme dat is geïmplementeerd om ook accounts te beperken om hun winsten te maximaliseren. ASF zal eerst het standaard **`Simple`** algoritme gebruiken voor alle spellen die `HoursUntilCardDrops` uren speeltijd hebben doorstaan. dan, als er geen spellen met >= `UsUntilCardDrops` uren over zijn, het zal alle spellen (tot `32` limit) vernietigen met < `Uur UntilCardDrops` uur tegelijk, links totdat elk van hen een `UsUntilCardDrops` uur markering raakt, dan zal ASF vanaf het begin doorgaan met de lus (gebruik **`Eenvoudige`** op dat spel, keer terug naar gelijktijdig op < `HoursUntilCardDrops` etc). We kunnen in dit geval meervoudige kweekmethoden gebruiken om de spelperioden die we nodig hebben op te waarderen waarde toe te passen. Houd er rekening mee dat ASF **tijdens landbouwuren geen** boerderijkaarten heeft, dus het zal ook geen enkele kaart controleren tijdens die periode (om bovenstaande redenen).

Op dit moment kiest ASF kaarten farming algoritme puur gebaseerd op `HoursUntilCardDrops` config eigenschap (welke is ingesteld door **you**). Als `HoursUntilCardDrops` is ingesteld op `0`, **`Eenvoudige`** algoritme wordt gebruikt, anders **`Complex`** algoritme wordt in plaats daarvan gebruikt - geconfigureerd voor bump speeltijd in alle spellen om uren te geven voordat je ze kweekt voor kaart daalt.

---

### **Er is geen voor de hand liggend antwoord welk algoritme beter is voor jou**.

Dit is een van de redenen waarom je geen kaartenfokkerij kiest, in plaats daarvan vertel je ASF of je account beperkte dalingen heeft of niet. Als account onbeperkte drops heeft, **`Simple`** algoritme werkt **beter** op die rekening. aangezien we geen tijd zullen verspillen door alle spellen mee te nemen naar `X` uur - verhouding van kaarten is bijna 0% bij het bewerken van meerdere spellen. Aan de andere kant, als je account een beperking heeft van kaarten, **`Complex`** algoritme is beter voor jou, omdat het geen zin heeft solo te bewerken als het spel `HoursUntilCardDrops` uur niet heeft bereikt - dus we voeren een boerderij **speeltijd** eerst. **dan** kaarten in solo modus.

Stel niet blindelings `HoursUntilCardDrops` alleen in omdat iemand je heeft verteld - doe tests, vergelijk de resultaten, en op basis van gegevens die u krijgt, welke optie beter voor u is. Als je daar minimale inspanningen voor doet, zorg je er dan voor dat ASF werkt met zo veel mogelijk efficiëntie voor je account, wat waarschijnlijk is wat je wilt, overwegende dat je deze wikipagina nu leest. Als er een oplossing was die voor iedereen werkt, zou je geen keuze hebben - ASF zou zelf beslissen.

---

### Wat is de beste manier om te weten te komen of uw account is beperkt?

Zorg ervoor dat je wat spellen hebt met **geen speeltijd opgenomen** om een boerderij te starten, bij voorkeur 5+, en gebruik ASF met `HoursUntilCardDrops` of `0`. Het zou een goed idee zijn als je tijdens de landbouwperiode niets hebt afgespeeld voor nauwkeuriger resultaten (het beste om ASF tijdens de nacht uit te voeren). Laat ASF die 5 spellen boerderijen, en daarna bekijk je het logboek voor resultaten.

ASF geeft duidelijk aan wanneer een kaart voor een bepaald spel is gevallen. Je bent geïnteresseerd in het snelste vallen van kaarten behaald door ASF. Als uw account bijvoorbeeld onbeperkt is, moet er na ongeveer 30 minuten van start gaan met de eerste betaalkaart. Als je **ten minste één** spel merkt dat de kaart in de eerste 30 minuten liet vallen dan is dit een indicator dat uw account **niet** beperkt is en moet gebruiken `HoursUntilCardDrops` of `0`.

Anderzijds als je ziet dat **elk** spel minstens `X` aantal uren duurt voordat het zijn eerste kaart laat vallen dan is dit een indicator voor wat je `HoursUntilCardDrops` moet instellen. De meerderheid (indien niet alle) van beperkte gebruikers vereist ten minste `3` uur speeltijd om de kaarten te laten vallen. en dit is ook de standaard waarde voor `HoursUntilCardDrops` instelling.

Vergeet niet dat spellen verschillende drop tarieven kunnen hebben Daarom moet je testen of je theorie juist is met **minstens** 3 spellen, Bij voorkeur 5+ om ervoor te zorgen dat je niet toevallig met valse resultaten bezig bent. Een kaart-drop van een spel in minder dan een uur is een bevestiging dat uw account **niet** beperkt is en `HoursUntilCardDrops` van `0`kan gebruiken, maar voor het bevestigen dat je account **** is beperkt, je hebt ten minste meerdere partijen nodig die geen kaarten laten vallen totdat je een vast punt raakt.

Het is belangrijk om op te merken dat in het verleden `HoursUntilCardDrops` slechts `0` of `2`was, , en dit is de reden waarom ASF een enkele `CardDropsRestricted` eigenschap had die kon schakelen tussen deze twee waarden. Bij recente wijzigingen hebben we gemerkt dat niet alleen de meerderheid van gebruikers `3` uur nodig heeft in plaats van de vorige `2` nu, maar ook dat `HoursUntilCardDrops` nu dynamisch is en elke waarde kan raken per account.

Uiteindelijk is het natuurlijk aan u om een beslissing te nemen.

En om het nog erger te maken - ik heb gevallen meegemaakt waarin mensen overgestapt van beperkt tot onbeperkte staat en omgekeerd - ofwel vanwege een Steam bug (oh yeah, We hebben er veel van, of vanwege enige logica aanpassingen door Radiatorkraan. Dus zelfs als je hebt bevestigd dat je account beperkt is (of niet), Geloof niet dat het zo blijft - om van onbeperkt naar beperkt te wisselen, is het genoeg om een terugbetaling te vragen. Als u denkt dat de waarde die eerder is ingesteld niet langer passend is, kunt u deze altijd opnieuw testen en bijwerken.

---

ASF gaat er standaard van uit dat `HoursUntilCardDrops` `3`is, omdat het negatieve effect van het instellen op `3` wanneer het minder zou moeten zijn, kleiner is dan andersom. Dit is omdat we in het slechtst mogelijke geval een `3` uur landbouwer per `32` spellen verspillen, vergeleken met het verspillen van `3` uur landbouw per afzonderlijk spel als `HoursUntilCardDrops` standaard was ingesteld op `0` Pas deze variabele echter nog aan zodat hij overeenkomt met de maximale efficiëntie in je account omdat dit slechts een blinde gok is gebaseerd op potentiële nadelen en de meerderheid van gebruikers (dus proberen we standaard "minder kwaad" te kiezen).

Op dit moment zijn twee bovenstaande algoritmen genoeg voor alle huidige mogelijke accountscenario's, Om zo effectief mogelijk te kunnen bedrijven is het dus niet van plan om er nog meer bedrijven aan toe te voegen.

Het is leuk om op te merken dat ASF ook handmatige landbouwmodus bevat die kan worden geactiveerd door `play` commando. Je kunt er meer over lezen in **[commando's](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

## Steam glitches

Het neerzetten van kaarten werkt niet altijd zoals het zou moeten, en het is perfect mogelijk voor verschillende Steam storingen Kaarten worden op beperkte accounts laten vallen, kaarten worden tijdens sluiten/omschakelen, kaarten die helemaal niet vallen wanneer het spel wordt gespeeld en ook niet.

Deze sectie is vooral voor mensen die zich afvragen waarom ASF **X**niet doet, zoals snel spellen overschakelen naar boerderijkaarten.

Wat is een **Steam glitch** - een specifieke actie die **ongedefinieerd** gedrag activeert, die **niet bedoeld, niet ongedocumenteerd is en beschouwd wordt als een logica fout**. Het is **onbetrouwbaar bij definitie**, wat betekent dat het niet op betrouwbare wijze kan worden gereproduceerd met schone testomgeving, en dus gecodeerd zonder gebruik te maken van hacks die geacht worden te raden wanneer er sprake is van storing en hoe ermee te strijden / te misbruiken. Meestal is het tijdelijk totdat ontwikkelaars de logica fout verhelpen, hoewel sommige mistige storingen gedurende een zeer lange periode onopgemerkt kunnen blijven.

Een goed voorbeeld van wat wordt beschouwd als een **Steam glitch** is niet zo ongebruikelijke situatie dat je een kaart achterlaat wanneer het spel wordt gesloten, die tot op zekere hoogte misbruikt kunnen worden met inactieve meester's game skip functie.

- **Ongedefinieerd gedrag** - je kunt niet zeggen of er 0 of 1 kaarten worden verwijderd wanneer je de glitch activeert.
- **niet bedoeld** - gebaseerd op ervaring en gedrag van het Steam netwerk dat niet hetzelfde gedrag veroorzaakt bij het verzenden van een enkele aanvraag.
- **Ongedocumenteerd** - het is duidelijk gedocumenteerd op de Steam website hoe kaarten worden verkregen, en **op elke plaats** wordt duidelijk gezegd dat het is verkregen door **te spelen**, Sluit geen spellen, krijg prestaties, spel wisselen of start 32 spellen gelijktijdig op.
- **beschouwd als een logica fout** - afsluitende spel(s) of wisselen van kaart mag geen resultaat hebben op kaarten die duidelijk aangegeven worden te verkrijgen door **speeltijd** te winnen.
- **Onbetrouwbaar per definitie, kan niet betrouwbaar worden gemaakt** - het werkt niet voor iedereen, en zelfs als het voor u één keer zou werken, zou het voor de tweede keer niet meer kunnen werken.

Nu hebben we eenmaal begrepen wat Steam glitch is, en het feit dat kaarten die worden laten vallen wanneer het spel wordt gesloten **is** één, we kunnen doorgaan naar het tweede punt - **ASF misbruikt het Steam netwerk op geen enkele manier per definitie, en het doet zijn best om te voldoen aan Steam ToS, zijn protocollen en wat algemeen wordt geaccepteerd**. Spamming Steam netwerk met constant spel openen/sluiten verzoeken kan worden beschouwd als een **[DoS attack](https://en.wikipedia.org/wiki/Denial-of-service_attack)** en **is direct geschonden [Steam Online Gedrag](https://store.steampowered.com/online_conduct/?l=english)**.

> Als Steam-abonnee ga je akkoord met de volgende gedragsregels.
> 
> U zult niet zijn:
> 
> Institut valt aan op een Steam-server of op een andere manier Steam verstoren.

Het maakt niet uit of je Steam glitch kan activeren met andere programma's (zoals IM), en het maakt ook niet uit of je het met ons eens bent en gedrag als DoS aanval overweegt, of niet - Het is aan Radiatorkraan om dit te beoordelen, maar als we dit beschouwen als uitbuiting / misbruik van onbedoeld gedrag via buitensporige Steam-netwerkverzoeken, Dan kunt u er vrij zeker van zijn dat Radiatorkraan hier een soortgelijk beeld van zal hebben.

ASF is **nooit** van plan te profiteren van Steam exploits, misbruik, hacks of andere activiteit die we zien als **illegaal of ongewenst** volgens Steam ToS, Steam Online Gedrag of een andere vertrouwde bron die zou kunnen aangeven dat ASF-activiteit ongewenst is door het Steam-netwerk. zoals in **[staat om](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)** bij te dragen.

Als je koste wat het kost je Steam account wilt riskeren om een paar cent kaarten sneller te verzamelen dan normaal, dan zal ASF helaas zoiets nooit aanbieden in automatische modus, hoewel je nog steeds `play` **[commando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** hebt die kan worden gebruikt als een hulpmiddel om te doen wat je maar wilt in termen van Steam netwerk interactie. Het is raadzaam om geen gebruik te maken van Steam-stormen om ze te misbruiken voor eigen gewin - niet alleen met ASF, maar dan wel met elk ander gereedschap. Uiteindelijk is het echter jouw account en jouw keuze wat je ermee wilt doen - houd er rekening mee dat we je gewaarschuwd hebben.