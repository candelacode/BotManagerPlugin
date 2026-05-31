# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` er officiel ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** udviklet af os, som giver dig mulighed for at bidrage til **[SteamDB](https://steamdb.info)** projekt ved at dele pakke tokens, app-tokens og depot nøgler, som din Steam-konto har adgang til. Den udvidede info om indsamlede data, og hvorfor SteamDB har brug for det, kan findes på SteamDB's **[Token Dumper](https://steamdb.info/tokendumper)** side. De indsendte data omfatter ikke potentielt følsomme oplysninger, og besidder ingen sikkerheds- og privatlivsrisiko, som angivet i ovenstående beskrivelse.

---

## Aktivering af plugin

ASF kommer med `SteamTokenDumperPlugin` bundtet sammen med udgivelsen, men selve plugin er deaktiveret som standard. Du kan aktivere plugin ved at indstille `SteamTokenDumperPluginEnabled` ASF global config property til `true`i JSON syntaks:

```json
{
  "SteamTokenDumperPluginEnabled": sand
}
```

Ved lanceringen af ASF programmet, plugin vil lade dig vide, om det blev aktiveret med succes gennem standard ASF logning mekanisme. Du kan også aktivere plugin via vores web-baserede config generator.

---

## Tekniske detaljer

Ved aktivering, plugin vil bruge de bots, du kører i ASF til dataindsamling i form af pakke tokens, app tokens og depot nøgler, som dine bots har adgang til. Dataindsamling modul omfatter passive og aktive rutiner, der formodes at minimere de ekstra overhead forårsaget af indsamling af data.

For at opfylde den planlagte brugssag ud over den rutinemæssige dataindsamling forklaret ovenfor indsendelse rutinen initialiseres som ansvarlig for at afgøre, hvilke data der skal indsendes til SteamDB med jævne mellemrum. Denne rutine vil skyde i op til `1` time siden din ASF starter, og vil gentage sig hver `24` timer. Dette plugin vil gøre sit bedste for at minimere mængden af data, der skal sendes, derfor er det muligt, at nogle data, som plugin vil indsamle, vil blive bestemt som ubrugelig at indsende, og derfor sprunget over (for eksempel app-opdatering, som ikke ændrer adgangstegnet).

Dette plugin bruger en vedvarende cache database gemt i `config/SteamTokenDumper.cache` placering, som tjener et lignende formål som `config/ASF.db` til ASF. Filen bruges til at registrere de indsamlede og indsendte data og minimere mængden af arbejde, der skal gøres på tværs af forskellige ASF kører. Fjernelse af filen forårsager processen til at blive genstartet fra bunden, som bør undgås, hvis det er muligt.

---

## Data

ASF inkluderer stilleren `steamID` i anmodningen som er bestemt som `SteamOwnerID` , du har angivet i ASF, eller i tilfælde af at du ikke gjorde det, Steam-ID'et på den bot, der ejer flest licenser. Den annoncerede bidragyder kan få ekstra frynsegoder fra SteamDB til kontinuerlig hjælp (f. eks. . donator rang på hjemmesiden), men det er helt op til SteamDB's skøn.

Under alle omstændigheder vil SteamDB medarbejdere gerne på forhånd takke dig for din hjælp. De indsendte data gør det muligt for SteamDB at fungere, især for at spore info om pakker, apps og depoter, som ikke længere ville være mulige uden din hjælp.

---

## Kommando

STD plugin leveres med en ekstra ASF kommando, `std [Bots]`, som giver dig mulighed for at udløse opdatering og indsendelse for udvalgte bots på efterspørgslen. Brug af kommandoen kræver ikke aktiveret config, som giver dig mulighed for at springe automatisk indsamling og indsendelse, og styre processen selv manuelt. Naturligvis kan det også udføres med aktiveret config, som blot vil udløse den sædvanlige indsamling og indsendelse procedurer tidligere end forventet.

Vi anbefaler `!std ASF` for at udløse opdatering for alle tilgængelige bots. Men du kan også udløse det for udvalgte dem, hvis du gerne vil.

---

## Avanceret konfiguration

Vores plugin understøtter avanceret config, som kan komme nyttigt for folk, der gerne vil justere de interne til deres præference.

Den avancerede config har følgende struktur placeret i `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Aktiveret": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretPackageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Alle muligheder er forklaret nedenfor:

### `Enabled`

`bool` type med standardværdi af `false`. Denne egenskab fungerer på samme måde som `SteamTokenDumperPluginEnabled` root-level property forklaret ovenfor, og kan bruges i stedet dedikeret til folk, der foretrækker at have hele plugin-relaterede config i sin egen struktur (så sandsynligvis dem, der allerede bruger andre avancerede egenskaber forklaret nedenfor).

---

### `SecretAppID'er`

`ImmutableHashSet<uint>` type med standardværdi for at være tom. Denne egenskab angiver `appIDs` som plugin'et ikke vil løse, og hvis de allerede er løst, vil de ikke indsende token for. Denne egenskab kan være nyttig for personer med adgang til potentielt følsomme oplysninger om ikke-offentliggjorte emner, især udviklere, udgivere eller lukkede beta-testere.

---

### `SecretDepotID'er`

`ImmutableHashSet<uint>` type med standardværdi for at være tom. Denne egenskab angiver `depotIDs` som plugin'et ikke vil løse, og hvis de allerede er løst, vil de ikke indsende nøglen til. Denne egenskab kan være nyttig for personer med adgang til potentielt følsomme oplysninger om ikke-offentliggjorte emner, især udviklere, udgivere eller lukkede beta-testere.

---

### `SecretPackageID'er`

`ImmutableHashSet<uint>` type med standardværdi for at være tom. Denne egenskab angiver `packageIDs` (også kendt som `subIDs`) at plugin'et ikke vil blive løst og hvis de allerede er løst, vil de ikke indsende token for. Denne egenskab kan være nyttig for personer med adgang til potentielt følsomme oplysninger om ikke-offentliggjorte emner, især udviklere, udgivere eller lukkede beta-testere.

---

### `SkipAutoGrantPackages`

`bool` type med standardværdi af `true`. Denne egenskab minder meget om `SecretPackageIDs` og når aktiveret, vil få pakker med `EPaymentMethod` af `AutoGrant` til at blive sprunget over under løse rutine forklaret nedenfor. `AutoGrant` betalingsmetode anvendes af **[Steamworks](https://partner.steamgames.com)** til automatisk at tildele pakker på udviklerkonti. Mens dette ikke er så eksplicit som andre `Secret` muligheder, og garanterer derfor ikke noget (da du måske har andre pakker end `AutoGrant` , som du stadig ikke ønsker at indsende) det bør være godt nok til at springe flertal, hvis ikke alle, af de hemmelige pakker. Denne indstilling er aktiveret som standard, som folk, der rent faktisk har adgang til `AutoGrant` pakker vil næsten aldrig ønske at lække dem til offentligheden og derfor er brugen af værdien `false` meget situationel.

---

## Yderligere forklaring

På root-niveau ejer hver Steam-konto et sæt pakker (licenser, abonnementer), som er klassificeret ved deres `packageID` (også kendt som `subID`). Hver pakke kan indeholde flere apps, der er klassificeret af deres `appID`. Hver app kan derefter indeholde flere depoter klassificeret af deres `depotID`.

```text
- under/124923
- 
 - _ _ app/292030
- - 
 - och - depot/292031
- - _ _ _ _ 378648
_ _ _ _ ...
- - app/378649
- 
 - _ ...
└── ...
```

Vores plugin omfatter to rutiner, der tager hensyn til oversprungne elementer - løsning rutine og indsendelse rutine.

Løsningen rutine er ansvarlig for at løse det træ, du kan se ovenfor. Ved at sortere pakker/apps/depoter på forhånd vil du effektivt skære træet i stedet for sortlistede grene / blad uden yderligere behov for at specificere de resterende dele af det. I vores eksempel ovenfor, hvis `124923` pakke blev ignoreret, enten af `SecretPackageIDs` eller `SkipAutoGrantPackages`, og det var den eneste pakke, du ejer, som er knyttet til `292030` appID, derefter appID `292030` ville heller ikke blive løst, og pr. definition hvis der ikke var nogen andre afklarede apps, der er knyttet til `292031` og `378648` depoter, så ville de heller ikke blive løst. Men, husk på, at hvis plugin allerede har løst træet, så effektivt dette vil kun stoppe givne element fra at blive opdateret (f.eks. nye apps tilføjet, det vil ikke gøre plugin "glemme" om de eksisterende elementer, der allerede er løst (f. eks. . apps fundet i denne pakke, før du besluttede at sortliste det). Hvis du lige har aktiveret nogle skipping muligheder, og vil gerne sikre, at ASF ikke krydser det allerede løste træ, kan du overveje en gang at fjerne `config/SteamTokenDumper. ache` -fil, hvor plugin'et holder sin cache.

Indsendelse rutine er ansvarlig for at indsende pakke tokens, app tokens og depot nøgler af allerede løste elementer (ved løsning rutine ovenfor). Her har din sortliste øjeblikkelig virkning, som om plugin allerede har løst info, indsendelse rutine vil faktisk ikke sende det til SteamDB, hvis du har det sortlistet, uanset om det er blevet løst eller ej. Husk dog, at vi ikke taler om træet længere på dette tidspunkt, indsendelse rutine ved ikke, om oplysningerne om app kommer fra denne eller den pakke, så det kun springer oplysninger om bestemte sortlistede emner, uanset hvilken relation de er i med andre.

For de fleste udviklere og udgivere bør det være nok til at holde `SkipAutoGrantPackages` aktiveret, potentielt bemyndiget med `SecretPackageIDs` da det effektivt skærer træet i begyndelsen gren og garanterer, at de apps og depoter inkluderet yderligere ikke vil blive indsendt, så længe der ikke er nogen anden pakke, der forbinder til den samme app. Hvis du ønsker at være dobbeltsidig, kan du også bruge `SecretAppIDs`, som vil springe over løsningen af appen, selvom der er nogle andre licenser, du ikke blacklist linker til det. Brug af `SecretDepotIDs` bør ikke være nødvendig, medmindre du har en bestemt specifikt behov (såsom kun at springe over en bestemt depot mens du stadig indsender oplysninger om pakker og apps) eller hvis du ønsker at tilføje endnu et lag, der skal være tredobbelt sikkert.