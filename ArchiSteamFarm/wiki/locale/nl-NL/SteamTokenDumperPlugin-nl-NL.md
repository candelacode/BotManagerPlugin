# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` is officieel ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** ontwikkeld door ons, waarmee je kunt bijdragen aan het project **[SteamDB](https://steamdb.info)** door pakkettokens te delen, App tokens en depot keys waartoe je Steam account toegang heeft. De uitgebreide informatie over verzamelde gegevens en waarom SteamDB nodig heeft kan worden gevonden op SteamDB's **[Token Dumper](https://steamdb.info/tokendumper)** pagina. De verstrekte gegevens bevatten geen potentieel gevoelige informatie en bevatten geen beveiligings- en privacyrisico, zoals vermeld in de bovenstaande beschrijving.

---

## De plugin inschakelen

ASF komt met `SteamTokenDumperPlugin` gebundeld met de release, maar de plugin zelf is standaard uitgeschakeld. U kunt de plugin inschakelen door `SteamTokenDumperPluginEnabled` ASF algemene configuratie eigenschap op `true`te zetten, in JSON syntaxis:

```json
{
  "SteamTokenDumperPluginEnabled": waar
}
```

Bij het opstarten van het ASF-programma zal de plugin je laten weten of het succesvol is ingeschakeld via het standaard ASF-logmechanisme. U kunt de plugin ook inschakelen via onze web-gebaseerde configuratiegenerator.

---

## Technische details

Na het inschakelen zal de plugin de bots gebruiken die je in ASF gebruikt voor het verzamelen van gegevens in de vorm van package tokens, App tokens en depot keys waar je bots toegang toe hebben. De dataverzamelingsmodule omvat passieve en actieve routines die geacht worden de extra overhead veroorzaakt door het verzamelen van gegevens te minimaliseren.

Om te voldoen aan de geplande gebruikskiste, bovenop bovenstaande routine voor het verzamelen van gegevens, indieningroutine wordt geïnitialiseerd als verantwoordelijk voor het bepalen van de gegevens die periodiek naar SteamDB moeten worden verzonden. Deze routine vuurt tot `1` uur sinds je ASF start, en zal zichzelf elke `24` uur herhalen. De plugin zal zijn best doen om het aantal gegevens dat verzonden moet worden te minimaliseren, Het is dus mogelijk dat sommige gegevens die de plugin zal verzamelen zullen worden bepaald als nutteloos om te verzenden, en daarom overgeslagen (bijvoorbeeld app update, die de toegangstoken niet verandert).

De plugin gebruikt een persistente cache database opgeslagen in `config/SteamTokenDumper.cache` locatie, die vergelijkbaar is met `config/ASF.db` voor ASF. Het bestand wordt gebruikt om de verzamelde en ingediende gegevens te registreren en de hoeveelheid werk die moet worden gedaan met verschillende ASF te minimaliseren. Het verwijderen van het bestand zorgt ervoor dat het proces weer vanaf nul wordt opgestart, wat indien mogelijk moet worden vermeden.

---

## Gegevens

ASF bevat de bijdrager `steamID` in het verzoek. welke is bepaald als `SteamOwnerID` dat je in ASF hebt ingesteld of in het geval dat je dit niet hebt gedaan, de Steam ID van de bot die de meeste licenties bezit. De aangekondigde bijdrager kan enkele extra voordelen ontvangen van SteamDB voor continue hulp (bv. . donator staat op de website), maar dat is volledig aan SteamDB's discretie.

In elk geval wil de staf van SteamDB u bij voorbaat bedanken voor uw hulp. De ingediende data laat SteamDB werken, met name om informatie over pakketten bij te houden, apps en depots, die niet langer mogelijk zouden zijn zonder uw hulp.

---

## Commando

STD plugin wordt geleverd met een extra ASF commando, `std [Bots]`, waarmee u op aanvraag verversen en indienen van geselecteerde bots kunt starten. Het gebruik van de opdracht vereist geen ingeschakelde configuratie, waarmee u automatisch verzamelen en indienen kunt overslaan en zelf het proces handmatig kunt beheren. Natuurlijk kan het ook met ingeschakelde instellingen worden uitgevoerd, waardoor de gebruikelijke verzamel- en indieningsprocedures eerder zullen worden uitgevoerd dan verwacht.

We recommend `!std ASF` in order to trigger refresh for all available bots. Je kunt het echter ook activeren voor de geselecteerde als je wilt.

---

## Geavanceerde configuratie

Onze plugin ondersteunt geavanceerde configuratie die handig kan zijn voor mensen die de internals willen aanpassen naar hun voorkeur.

De geavanceerde configuratie heeft de volgende structuur in `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Ingeschakeld": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretPackageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Alle opties zijn hieronder uitgelegd:

### `Ingeschakeld`

`bool` type met standaard waarde van `false`. Deze eigenschap werkt hetzelfde als `SteamTokenDumperPluginEnabled` root-level eigenschap hierboven uitgelegd en kan in plaats daarvan worden gebruikt die toegewijd zijn aan mensen die de voorkeur geven aan volledige plugin-gerelateerde config in hun eigen structuur (zo waarschijnlijk dat degenen die al andere geavanceerde eigenschappen gebruiken hieronder uitgelegd hebben).

---

### `GeheimApp-ID's`

`ImmutableHashSet<uint>` type met de standaard waarde van leeg zijn. Deze eigenschap specificeert `appIDs` dat de plugin niet oplost, en als ze al zijn opgelost, zal de token niet worden verstuurd. Deze eigenschap kan nuttig zijn voor mensen met potentieel gevoelige informatie over niet-gepubliceerde artikelen, met name ontwikkelaars, uitgevers of gesloten beta-testers.

---

### `GeheimDepotID's`

`ImmutableHashSet<uint>` type met de standaard waarde van leeg zijn. Deze eigenschap specificeert `depotIDs` waar de plugin geen oplossing voor kan vinden en als ze al opgelost zijn, zal de sleutel niet worden verzonden. Deze eigenschap kan nuttig zijn voor mensen met potentieel gevoelige informatie over niet-gepubliceerde artikelen, met name ontwikkelaars, uitgevers of gesloten beta-testers.

---

### `GeheimPakketIDs`

`ImmutableHashSet<uint>` type met de standaard waarde van leeg zijn. Deze eigenschap specificeert `packageIDs` (ook bekend als `subIDs`) dat de plugin niet zal oplossen, en als ze al zijn opgelost, zal de token niet voor worden ingediend. Deze eigenschap kan nuttig zijn voor mensen met potentieel gevoelige informatie over niet-gepubliceerde artikelen, met name ontwikkelaars, uitgevers of gesloten beta-testers.

---

### `OverslaanAutoGegarantiepakketten`

`bool` type met standaard waarde `true`. Deze eigenschap heeft veel gelijkenis met `GeheimpakIDs` en wanneer ingeschakeld zal ervoor zorgen dat pakketten met `EPaymentMethod` van `AutoGrant` worden overgeslagen tijdens de resolve routine hieronder uitgelegd. `AutoGrant` betaalmethode wordt gebruikt door **[Steamworks](https://partner.steamgames.com)** om automatisch pakketten te verstrekken op ontwikkelaarsaccounts. Terwijl dit niet zo expliciet is als andere `Secret` opties, en daarom is er geen garantie (omdat je andere pakketten dan `AutoGrant` kunt hebben die je nog steeds niet wilt indienen), het zou goed genoeg moeten zijn om de meerderheid, zo niet alle, van de geheime pakketten over te slaan. Deze optie is standaard ingeschakeld als mensen die toegang hebben tot `AutoGrant` pakketten zullen deze bijna nooit naar het publiek willen lekken en daarom is het gebruik van de waarde van `false` erg situationeel.

---

## Meer uitleg

Op het hoofdniveau, elk Steam account heeft een pakket (licenties, abonnementen), die worden geclassificeerd door hun `packageID` (ook bekend als `subID`). Elk pakket kan verschillende apps bevatten die zijn geclassificeerd door hun `appID`. Elke app kan vervolgens meerdere depots bevatten die geclassificeerd zijn door hun `depotID`.

```text
CAPS in/124923
help. idiote app/292030
help. depot/292031
credentials credentials help. depot/to 
 credentials credentials credentials credentials credentials the depot/378648
it it at zat...
・・・app/378649
ρρρ！ ...
└── ...
```

Onze plugin bevat twee overgeslagen routines - de probleemroutine en indieningsroutine.

De oplossingsroutine is verantwoordelijk voor het oplossen van de boom die u hierboven kunt zien. Door de pakketten/apps/depots van tevoren te blackeren, Je knipt de boom effectief op de plaats van de zwarte lijsten van branch/blad zonder dat je de resterende delen ervan hoeft te specificeren. In ons voorbeeld hierboven, als `124923` pakket werd genegeerd, of `SecretPackageIDs` of `SkipAutoGrantPackages`, en het was het enige pakket dat je bezit welke gelinkt is aan de `292030` appID, vervolgens appID `292030` zou ook niet opgelost worden, en per definitie als er geen andere opgeloste apps zijn gekoppeld aan de `292031` en `378648` depots, dan zouden ze ook niet opgelost worden. Houd er echter rekening mee dat als de plugin de boom al heeft afgehandeld, dit alleen het betreffende item niet meer kan bijwerken (bijvoorbeeld nieuwe apps toegevoegd), het maakt de plugin niet "vergeten" over de bestaande items die al opgelost waren (bijv. . apps gevonden in dat pakket voordat u besloot het te blacklist). Als je net wat overslaan opties hebt ingeschakeld en ervoor wilt zorgen dat ASF de toch al afgehandelde boom niet vervormt, je kan eenmalig verwijderen van `config/SteamTokenDumper. ach` bestand waar de plugin de cache bijhoudt.

De indieningroutine is verantwoordelijk voor het indienen van pakkettokens, app tokens en depot sleutels van reeds afgehandelde items (via bovenstaande oplossing-routine). Hier heeft uw zwarte lijst onmiddellijk effect, zelfs als de plugin de info al heeft opgelost, de inzending routine zal in feite niet worden verzonden naar SteamDB als je hem op de zwarte lijst hebt staan, ongeacht of het is opgelost of niet. Houd er echter rekening mee dat we het op dit moment niet meer over de boom hebben. de inleverroutine weet niet of de informatie over de app van dit of dat pakket afkomstig is. dus overslaat het alleen informatie over specifieke, op de zwarte lijst vermelde items, ongeacht de relatie die ze hebben met de andere.

Voor de meerderheid van de ontwikkelaars en uitgevers, moet het genoeg zijn om `SkipAutoGrantPackages` ingeschakeld te houden potentieel mogelijk ondersteund door `SecretPackageIDs` alleen. omdat het de boom effectief aan het begin van de tak knipt en garandeert dat de apps en despots verder niet worden ingediend zolang er geen ander pakket is dat linkt naar dezelfde app. Als u dubbel zeker wilt zijn, in aanvulling dat u ook `SecretAppIDs`kunt gebruiken, die de oplossing van de app overslaat, zelfs als er andere licenties zijn die je niet aan de zwarte lijst hebt gekoppeld. Het gebruik van `SecretDepotIDs` zou niet nodig moeten zijn, tenzij je een speciaal persoon hebt, specifieke noodzaak (zoals het overslaan van alleen een bepaald depot terwijl het nog steeds informatie over pakketten en apps indient), of als je nog een andere laag wilt toevoegen om veilig drievoudig te zijn.