# Tweestapsverificatie

Steam bevat een tweestapsverificatiesysteem dat extra details vereist voor verschillende account-gerelateerde activiteiten. Je kunt er meer over lezen **[hier](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** en **[hier](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. Deze pagina is van mening dat het 2FA-systeem net zo goed als onze oplossing die ermee integreert, ASF 2FA heet.

---

# ASF logica

Ongeacht als je ASF 2FA gebruikt of niet, bevat ASF de juiste logica en is je volledig bewust van accounts die worden beschermd door 2FA op Steam. Het zal je om verplichte informatie vragen wanneer ze nodig zijn (zoals tijdens het inloggen). Deze informatie kunt u handmatig verstrekken bepaalde ASF functionaliteiten (zoals `MatchActively`) vereisen dat ASF 2FA actief is op je bot-account, dit kan automatisch reageren op 2FA vragen, wanneer nodig door ASF.

---

# ASF 2FA

ASF 2FA is een ingebouwde module die verantwoordelijk is voor het verstrekken van 2FA-functies aan het ASF-proces, zoals het genereren van tokens en het accepteren van bevestigingen. Het kan ofwel in zelfstandige modus werken, of door je bestaande authenticator-gegevens te dupliceren (zodat je tegelijkertijd je huidige authenticator en ASF tweestapsverificatie kunt gebruiken).

Je kan verifiëren of je bot-account ASF 2FA al gebruikt door `2fa` **[commando's](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** uit te voeren. Zonder ASF 2FA in te stellen, zullen alle standaard `2fa` opdrachten niet operationeel zijn, dit betekent dat je bot niet beschikbaar is voor geavanceerde ASF-functies die de module nodig hebben om te functioneren.

---

# Aanbevelingen

Er zijn veel manieren om ASF 2FA operationeel te maken, hier voegen we onze aanbevelingen toe op basis van uw huidige situatie:

- Als u al gebruik maakt van een onofficiële app van derden, waarmee u de 2FA-gegevens gemakkelijk kunt extraheren, alleen **[importeer](#import)** die bij ASF.
- Als u de officiële app gebruikt en u hoeft uw 2FA gegevens niet te resetten, is de beste manier om 2FA uit te schakelen, vervolgens **[maak](#creation)** nieuwe 2FA inloggegevens aan door **[joint authenticator](#joint-authenticator)**te gebruiken, waarmee je de officiële app en ASF 2FA kunt gebruiken. Deze methode **vereist geen root**, jailbreaker of enige geavanceerde kennis, nauwelijks instructies volgen die hier geschreven zijn en is aantoonbaar superieur voor dit scenario.
- Als u de officiële app gebruikt en uw 2FA gegevens niet wilt aanmaken, zijn uw opties zeer beperkt, Meestal heb je root en extra fiddling nodig naar **[importeer](#import)** die details, en zelfs daarmee zou het onmogelijk kunnen zijn.
- Als je nog geen 2FA gebruikt en niet zorgt, We raden je aan om ASF 2FA te gebruiken met **[standalone authenticator](#standalone-authenticator)** of **[joint authenticator](#joint-authenticator)** met een officiële app (hetzelfde als hierboven).

Hieronder bespreken we alle mogelijke opties en methoden die bij ons bekend zijn.

---

## Aanmaken

ASF wordt geleverd met een officiële `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** die de 2FA verder uitbreidt, Hiermee kunt u een volledig nieuwe 2FA-authenticator linken. Dit kan handig zijn voor het geval u geen andere hulpmiddelen of niet bereid bent te gebruiken en maakt het niet uit dat ASF uw belangrijkste (en misschien alleen) authenticator is. Aanmaken wordt ook gebruikt in de joint-authenticator methode. In dit scenario kan je authenticator natuurlijk op twee plaatsen tegelijk samenleven - beiden zullen dezelfde codes genereren en beiden kunnen dezelfde bevestigingen bevestigen.

### Gemeenschappelijke stappen voor beide scenario's

Het maakt niet uit of je ASF als zelfstandige of gezamenlijke authenticator wilt gebruiken, je moet deze initialiseringsstappen doen:

1. Maak een ASF bot aan voor het doelaccount, start het en log in, wat je waarschijnlijk al hebt gedaan.
2. Wijs een werk- en operationeel telefoonnummer toe aan het account **[hier](https://store.steampowered.com/phone/manage)** dat door de bot moet worden gebruikt. Hiermee kunt u SMS-code ontvangen en herstel toestaan indien nodig. Deze stap is niet verplicht in alle scenario's, maar we raden hem aan tenzij u weet wat u doet.
3. Zorg ervoor dat u nog geen 2FA gebruikt voor uw account, als u dat wel doet, schakel deze eerst uit. Deze **zal** je account tijdelijk in de handel zetten, er is geen manier omheen alleen **[import](#import)** proces kan het overslaan.
4. Voer het `2fainit [Bot]` commando uit, vervang `[Bot]` met de naam van je bot.

Ervan uitgaande dat u een succesvol antwoord kreeg, zijn de volgende twee dingen gebeurd:

- Een nieuw `<Bot>.maFile.PENDING` bestand is gegenereerd door ASF in uw `config` map.
- De SMS is verstuurd vanaf Steam naar het telefoonnummer dat je hebt toegewezen voor het account hierboven. Als u geen telefoonnummer hebt ingesteld, is er in plaats daarvan een e-mail verzonden naar het e-mailadres van het account.

De authenticatorgegevens zijn nog niet actief, maar u kunt het gegenereerde bestand bekijken als u dat wilt. Als je dubbel veilig wilt zijn, kun je de intrekkingscode bijvoorbeeld al opschrijven. De volgende stappen zullen afhangen van je gekozen scenario.

### Alleenstaande authenticator

Als je ASF wilt gebruiken als je authenticator (of zelfs alleen) authenticator, moet je nu de laatste afsluitingsstap uitvoeren:

5. Voer het commando `2fafinalizatie [Bot] <ActivationCode>` uit, vervang `[Bot]` met de bot's naam en `<ActivationCode>` met de code die je in de vorige stap hebt ontvangen via SMS of e-mail.

### Gezamenlijke authenticator

Als je dezelfde authenticator wilt hebben in zowel ASF als de officiële Steam mobiele app, nu moet je de volgende moeilijkere stappen doen:

5. **Negeer** de SMS of e-mail code die je hebt ontvangen in de vorige stap.
6. Installeer de Steam mobiele app als deze nog niet geïnstalleerd is en open deze. Navigeer naar het Steam Guard tabblad en voeg een nieuwe authenticator toe door de instructies van de app te volgen.
7. Nadat je authenticator in de mobiele app is toegevoegd en werkt, keer terug naar ASF. In plaats van de afronding hoeven we alleen ASF te informeren dat mobiele app al onze eerder gegenereerde details heeft geactiveerd:
 - Wacht tot de volgende 2FA code in de Steam mobiele app is weergegeven. en gebruik de opdracht `2fafinalized [Bot] <2FACodeFromApp>` die `[Bot]` vervangt met de naam van je bot en `<2FACodeFromApp>` met de code die je momenteel ziet in de Steam mobiele app - dezelfde die je zou gebruiken om in te loggen op Steam (**NIET** degene die je al hebt gebruikt voor activering). Als de code die ASF heeft gegenereerd en de code die je hebt opgegeven gelijk zijn, ASF gaat ervan uit dat een authenticator correct is toegevoegd en ga door met het importeren van je nieuw gecreëerde authenticator.
 - Om ervoor te zorgen dat uw referenties geldig zijn, raden wij u ten zeerste aan om dit te doen. Maar als je niet wilt (of kan) controleren of de codes hetzelfde zijn en je weet wat je aan het doen bent je kan in plaats daarvan het commando `2fafinalizedforce [Bot]`gebruiken, vervang `[Bot]` door de naam van je bot. ASF gaat ervan uit dat de authenticator correct is toegevoegd en ga door met het importeren van je nieuw gecreëerde authenticator. Wees ervan bewust dat in deze modus ASF niet kan controleren of de codes overeenkomen. dit betekent dat je potentieel ongeldige (niet geactiveerd) inloggegevens kunt importeren.

### Na afronding

Ervan uitgaande dat alles goed werkte, werd de eerder gegenereerde `<Bot>.maFile.PENDING` bestand hernoemd naar `<Bot>.maFile.NEW`. Dit geeft aan dat uw 2FA-inloggegevens nu geldig en actief zijn. We raden u aan om dat bestand te verplaatsen naar de `config` map en **het op te slaan op een beveiligde locatie**. Daarnaast als je hebt besloten om gebruik te maken van de standalone authenticator dan raden we je aan om het bestand in je keuzerondje te openen en de `revocation_code`op te schrijven, waarmee je de authenticator kunt intrekken in het geval je deze kwijtraakt, zoals de naam impliceert. Bij joint-authenticator methode, had je dat al moeten doen in de Steam mobiele app, maar voel je vrij om hetzelfde te doen voor het geval dat het moet.

Wat de technische details betreft, het gegenereerde `maFile` bevat alle details die we hebben ontvangen van de Steam server tijdens het koppelen van de authenticator, en daarbovenop het `device_id` veld, dat mogelijk nodig is voor andere (derde) authenticatoren, als je ooit besluit om dat `maFile` in ze te importeren.

ASF importeert automatisch je authenticator zodra de procedure is voltooid en daarom moeten `2fa` en andere gerelateerde commando's nu operationeel zijn voor het bot-account waaraan u de authenticator hebt gekoppeld. We raden u aan om dat te verifiëren.

---

## Importeren

Importproces vereist reeds gelinkte en operationele authenticatie die wordt ondersteund door ASF. We hebben instructies voor enkele verschillende officiële en onofficiële bronnen van de 2FA, bovenop de handmatige methode waarmee u de vereiste inloggegevens zelf kunt opgeven. Please note that those instructions should be used **only** if you're already using given solution - since process here involves third-party apps and tools, **we do not recommend using them**, and we're mentioning it exclusively for people that already decided to use them and would like to import generated details into ASF 2FA.

Het importproces omvat het achterlaten van `maFile` in het juiste formaat voor ASF's `config` map, waarop ASF het bestand zal oppakken en het om veiligheidsredenen automatisch zal verwijderen.

Alle volgende handleidingen vereisen van u dat u al een **werkende en operationele** authenticator gebruikt heeft met gegeven tool/applicatie. ASF 2FA werkt niet goed als je ongeldige gegevens importeert. Zorg er daarom voor dat je authenticator goed werkt voordat je probeert deze te importeren. Dit omvat wel het testen en verifiëren van het feit dat de volgende authenticatorfuncties goed werken:
- U kunt tokens genereren en deze tokens worden geaccepteerd door het Steam netwerk (u kunt hiermee inloggen)
- U kunt bevestigingen ophalen en ze komen op uw mobiele authenticator aan
- Je kunt reageren op die bevestigingen, en ze zijn goed herkend door het Steam-netwerk als bevestigd/afgewezen

Zorg ervoor dat je authenticator werkt door te controleren of bovenstaande acties werken - als ze niet werken, dan zullen ze ook niet werken in ASF.

### Android telefoon

Om de authenticator van uw Android-telefoon te importeren heeft u over het algemeen **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))** toegang nodig. De onderstaande instructies vereisen van u behoorlijk behoorlijke kennis in de Android modding wereld, we gaan zeker niet elke stap hier uitleggen, bezoek **[XDA](https://xdaforums.com)** en andere bronnen voor aanvullende informatie/hulp met hieronder.

**Op dit moment is er geen bekende methode voor bevestigde extractie die nog steeds werkt. Je kunt toch proberen onderstaande stappen te volgen, bijvoorbeeld met verouderde app versie, maar we garanderen niet dat het goed werkt. Overweeg om in plaats daarvan de joint-authenticator methode te gebruiken.**

<details>
  <summary>Archivering instructies</summary>

Ervan uitgaande dat je officiële **[Steam app](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** werkt en operationeel (vereist het rooten van je apparaat):

- Installeer **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** en schakel Zygisk in in de instellingen.
- Installeer **[Verlies](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (voor Zygisk) en zorg ervoor dat het werkt.
- Installeer **[SteamGuardDump](https://github.com/YifePlayte/SteamGuardDump/releases/latest)** of **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** LSPosed module en schakel het in in de verliesde instellingen.
- Dwing Steam app geforceerd te openen, vervolgens de steam guard details moeten nu beschikbaar zijn om naar het klembord te kopiëren.

Nu je de vereiste gegevens hebt uitgepakt, schakel de module uit om te voorkomen dat de auto-kopie elke keer wordt gekopieerd Kopieer vervolgens de waarde van `shared_secret` en `identity_secret` van het account dat je van plan bent toe te voegen aan ASF 2FA, in een nieuw tekstbestand met de onderstaande structuur:

```json
{
  "Shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Vervang elke EEN `STRING` waarde door de juiste private key uit uitgepakte details. Zodra je dat doet, hernoem je het bestand naar `BotName. aFile`, waar `BotName` de naam is van je bot waaraan je ASF 2FA toevoegt en stop het in de ASF's `config` map als je nog niet hebt

Start ASF, dat je bestand opmerkt en importeert. Ervan uitgaande dat u het juiste bestand met geldige geheimen hebt geïmporteerd, zou alles goed moeten werken, wat u kunt verifiëren met `2fa` commando's. Als je een fout hebt gemaakt, kun je altijd `Bot.db` verwijderen en zo nodig opnieuw beginnen.

</details>

### SteamDesktopAuthenticator

Als je authenticator al in SDA draait, moet je zien dat er `steamID.maFile` bestand beschikbaar is in de `maFiles` map. Zorg ervoor dat `maFile` in een ongecodeerd formulier is omdat ASF geen SDA-bestanden kan decoderen - ongecodeerde bestandsinhoud moet beginnen met `{` en eindigen met `}` karakter. Indien nodig kunt u de encryptie uit de SDA instellingen eerst verwijderen en opnieuw inschakelen wanneer u klaar bent. Als het bestand niet gecodeerd is, kopieer het dan naar `config` map van ASF.

Je kunt nu `steamID.maFile` hernoemen naar `BotName. aFile` in ASF config directory, waar `BotName` de naam is van jouw bot waaraan je ASF 2FA toevoegt. Je kunt het ook laten zoals het is, ASF zal het dan automatisch kiezen nadat je bent ingelogd. Het hernoemen van het bestand helpt ASF door het mogelijk te maken de ASF 2FA te gebruiken voordat u inlogt, als u dat niet doet. dan kan het bestand alleen worden geselecteerd nadat ASF succesvol heeft ingelogd (omdat ASF niet weet `steamID` van je account om in te loggen).

Start ASF, dat je bestand opmerkt en importeert. Ervan uitgaande dat u het juiste bestand met geldige geheimen hebt geïmporteerd, zou alles goed moeten werken, wat u kunt verifiëren met `2fa` commando's. Als je een fout hebt gemaakt, kun je altijd `Bot.db` verwijderen en zo nodig opnieuw beginnen.

### WinAuth

Maak ten eerste nieuw leeg `BotName. aFile` in ASF config directory, waar `BotName` de naam is van jouw bot waaraan je ASF 2FA toevoegt. Als je onjuiste naam opgeeft, wordt deze niet gekozen door ASF.

Start WinAuth nu zoals gebruikelijk. Klik met de rechtermuisknop op het Steam icoon en selecteer "Toon SteamGuard en Herstel Code". Controleer vervolgens "Kopie toestaan". Je zou bekend moeten zijn met je JSON-structuur onderaan het venster, beginnend met `{`. Kopieer hele tekst naar een `BotName.maFile` bestand gemaakt door u in de vorige stap.

Start ASF, dat je bestand opmerkt en importeert. Ervan uitgaande dat u het juiste bestand met geldige geheimen hebt geïmporteerd, zou alles goed moeten werken, wat u kunt verifiëren met `2fa` commando's. Als je een fout hebt gemaakt, kun je altijd `Bot.db` verwijderen en zo nodig opnieuw beginnen.

### Handleiding

Als u geavanceerde gebruiker bent, kunt u ook handmatig maFile genereren. Dit kan gebruikt worden in het geval je de authenticator wil importeren uit andere bronnen dan de bronnen die we hierboven hebben beschreven. Het moet een **[geldige JSON-structuur hebben](https://jsonlint.com)** van:

```json
{
  "Shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Gegevens van de standaard authenticator hebben meer velden - ze zijn tijdens het importeren volledig genegeerd door ASF, omdat ze niet nodig zijn. Je hoeft ze niet te verwijderen - ASF heeft alleen geldige JSON nodig met 2 verplichte velden hierboven beschreven, en zal extra velden negeren (indien aanwezig). Natuurlijk moet je `STRING` placeholder vervangen in het voorbeeld hierboven door geldige waarden voor je account. Elke `STRING` moet base64-gecodeerde representatie van bytes de juiste private key zijn.

---

## FAQ (veelgestelde vragen)

### Hoe maakt ASF gebruik van de 2FA-module?

Als ASF 2FA beschikbaar is, zal ASF deze gebruiken voor automatische bevestiging van transacties die worden verzonden/geaccepteerd door ASF. Het zal ook in staat zijn om automatisch 2FA-tokens te genereren op basis die nodig is, bijvoorbeeld om in te loggen. Daarnaast kunnen met ASF 2FA ook `2fa` commando's gebruikt worden.

### Hoe kan ik 2FA token krijgen?

U heeft een 2FA-token nodig om toegang te krijgen tot een 2FA-beveiligde rekening, die ook elke account met ASF 2FA omvat. Als je hebt besloten om de standalone authenticator te gebruiken, dan moet je `2fa <BotNames>` commando gebruiken om een tijdelijke token te genereren voor de opgegeven bot-instanties. In alle andere scenario's raden we aan om originele authenticator te gebruiken die je hebt gebruikt. hoewel je het commando net zo goed kunt gebruiken als het makkelijker voor je is.

### Kan ik mijn originele authenticator gebruiken na het importeren als ASF 2FA?

Ja, je originele authenticator blijft functioneel en je kan deze samen met de ASF 2FA gebruiken. Houd er echter rekening mee dat als u deze ongeldigt via welke methode dan ook, de gekoppelde 2FA-referenties van ASF ook niet langer geldig zijn.

### Hoe verwijder ik ASF 2FA?

Stop gewoon ASF en verwijder `BotName.db` van de bot met gekoppelde ASF 2FA die je wilt verwijderen. Deze optie verwijdert de bijbehorende geïmporteerde 2FA met ASF, maar maakt uw authenticator NIET ongeldig (ontkoppelen). Als je in plaats daarvan je authenticator wilt ongeldigen, moet je het loskoppelen van de originele authenticator naar eigen keuze behalve het verwijderen van het authentificator van ASF (eerst). Als je dat om een of andere reden niet kunt doen, bijvoorbeeld omdat je ASF 2FA in standalone modus gebruikt, gebruik dan de intrekkingscode die je hebt ontvangen tijdens het instellen, op de Steam website. Het is niet mogelijk om je authenticator ongeldig te maken via ASF.

### Ik heb authenticator gekoppeld in een app van derden en vervolgens geïmporteerd in ASF. Kan ik deze nu opnieuw koppelen op mijn telefoon?

**Geen**. Dit zal de eerder geïmporteerde inloggegevens ongeldig maken en uw ASF 2FA zal stoppen met functioneren (door het genereren van codes niet langer door Steam) worden geaccepteerd. Kies eerst waar je de originele of externe authenticator wilt hebben en importeer het als ASF 2FA.

### Ik gebruik gezamenlijke authenticator, kan ik mijn app verplaatsen naar een andere telefoon?

**Geen**. Wat stoomstaten zijn als "verplaatsen" of authenticator, is eigenlijk gelijk aan het ongeldig maken van de oude en het toewijzen van een nieuwe in één stap. Dit staat je toe om bijvoorbeeld over te slaan echter een te grote afkoeling in vergelijking met het zelfstandig doen van deze twee stappen wat ASF betreft. dit leidt er eigenlijk toe dat de inloggegevens die je eerder hebt gegenereerd in ASF, waardoor de hele ASF 2FA module niet operationeel is.

De aanbevolen manier is om je authenticator volledig te verwijderen op de oude telefoon en de joint authenticator methode opnieuw te gebruiken op de nieuwe telefoon. Als je je authenticator al hebt verplaatst, dan zijn de oude ASF 2FA-referenties al ongeldigd, dus het enige wat er nu over is is je "verplaatst" authenticator te verwijderen, en een nieuwe te koppelen met behulp van de gezamenlijke authenticator methode.

### Gebruikt ASF 2FA beter dan authenticator van derden om alle bevestigingen te accepteren?

**Ja**, op verschillende manieren. First and most important one - using ASF 2FA **significantly** increases your security, as ASF 2FA module ensures that ASF will only accept automatically its own confirmations, so even if attacker does request a trade that is harmful, ASF 2FA will **not** accept such trade, as it was not generated by ASF. Naast beveiligingsgedeelte, brengt het gebruik van ASF 2FA ook prestatie/optimalisatie voordelen met zich mee, aangezien ASF 2FA ophaalt en bevestigingen accepteert direct nadat ze zijn gegenereerd, en alleen dan, in plaats van inefficiënte verkiezingen voor de bevestiging van elke X-minuut, wat door andere oplossingen wordt bereikt. Er is geen reden om de authenticator van derden te gebruiken via ASF 2FA, als je van plan bent om bevestigingen die gegenereerd zijn door ASF te automatiseren - dat is precies waar ASF 2FA voor staat, en het gebruik ervan is niet in strijd met dat je alles in de authenticator van je keuze bevestigt. We raden ten zeerste aan om ASF 2FA te gebruiken voor hele ASF-activiteiten.