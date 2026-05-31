# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` är officiell ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** utvecklat av oss, vilket låter dig bidra till **[SteamDB](https://steamdb.info)** projektet genom att dela pakettokens, app-tokens och depånycklar som ditt Steam-konto har tillgång till. Den utökade informationen om insamlade data och varför SteamDB behöver den finns på SteamDB's **[Token Dumper](https://steamdb.info/tokendumper)** sida. De inlämnade uppgifterna innehåller inte någon potentiellt känslig information och har ingen säkerhets- eller integritetsrisk, som anges i beskrivningen ovan.

---

## Aktiverar plugin

ASF levereras med `SteamTokenDumperPlugin` tillsammans med utgåvan, men själva insticksprogrammet är inaktiverat som standard. Du kan aktivera plugin genom att ställa in `SteamTokenDumperPluginAktiverade` ASF global config egenskap till `true`, i JSON syntax:

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

Vid lanseringen av ASF-programmet, plugin kommer att låta dig veta om det var aktiverat framgångsrikt genom standard ASF loggning mekanism. Du kan också aktivera plugin via vår webbaserade konfigurationsgenerator.

---

## Tekniska detaljer

Vid aktivering, plugin kommer att använda robotar som du kör i ASF för datainsamling i form av pakettokens, app tokens och depånycklar som dina robotar har tillgång till. Modulen för datainsamling innehåller passiva och aktiva rutiner som ska minimera den extra overhead som orsakas av insamling av data.

För att uppfylla det planerade användningsfallet, förutom datainsamling rutin som förklaras ovan, inlämning rutin initieras som ansvarig för att bestämma vilka data som måste lämnas till SteamDB på periodisk basis. Denna rutin kommer att skjuta i upp till `1` timme sedan din ASF startar, och kommer att upprepa sig varje `24` timmar. Pluginen kommer att göra sitt bästa för att minimera mängden data som måste skickas, därför är det möjligt att vissa uppgifter som insticksprogrammet kommer att samla in kommer att bestämmas som värdelös att lämna in, och hoppade därför över (till exempel appuppdatering som inte ändrar åtkomsttoken).

Pluginen använder en ihållande cache-databas sparad i `config/SteamTokenDumper.cache` plats, som tjänar ett liknande syfte till `config/ASF.db` för ASF. Filen används för att registrera insamlade och inlämnade data och minimera den mängd arbete som måste göras över olika ASF-körningar. Att ta bort filen gör att processen startas om från grunden, vilket bör undvikas om möjligt.

---

## Data

ASF inkluderar bidragsgivaren `steamID` i begäran, som bestäms som `SteamOwnerID` som du anger i ASF, eller om du inte gjorde det, Steam-ID för boten som äger flest licenser. Den aviserade bidragsgivaren kan få ytterligare förmåner från SteamDB för kontinuerlig hjälp (e. . donator rankas på webbplatsen), men det är helt upp till SteamDB's diskretion.

I vilket fall som helst, SteamDB personal vill tacka dig i förväg för din hjälp. De inlämnade datamängderna gör det möjligt för SteamDB att fungera, särskilt för att spåra information om paket, appar och depåer, vilket inte längre skulle vara möjligt utan din hjälp.

---

## Kommando

STD plugin levereras med ett extra ASF kommando, `std [Bots]`, vilket gör att du kan utlösa uppdatering och inlämning av valda robotar på begäran. Använda kommandot kräver inte aktiverad konfiguration, vilket gör att du kan hoppa över automatisk insamling och inlämning, och styra processen själv manuellt. Naturligtvis kan det också köras med aktiverad konfiguration, vilket helt enkelt kommer att utlösa de vanliga insamlings- och inlämningsprocedurerna tidigare än väntat.

Vi rekommenderar `!std ASF` för att trigga uppdatering för alla tillgängliga botar. Men du kan också utlösa det för utvalda om du vill.

---

## Avancerad konfiguration

Vår plugin stöder avancerad konfiguration som kan komma till nytta för människor som vill justera de interna till sina önskemål.

Den avancerade konfigurationen har följande struktur inom `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Aktiverad": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Alla alternativ förklaras nedan:

### `Aktiverad`

`Bool` skriv med standardvärdet `false`. Denna egenskap fungerar samma som `SteamTokenDumperPluginAktiverad` egenskaper på root-nivå som förklaras ovan, och kan användas istället, dedikerad till personer som föredrar att ha hela plugin-relaterade konfiguration i sin egen struktur (så sannolikt de som redan använder andra avancerade egenskaper förklaras nedan).

---

### `SecretAppID`

`ImmutableHashSet<uint>` -typ med standardvärdet för att vara tomt. Denna egenskap anger `appID` att pluginen inte kommer att lösas, och om de redan är lösta, kommer inte att skicka token för. Denna egenskap kan vara användbar för personer med tillgång till potentiellt känslig information om opublicerade objekt, särskilt utvecklare, publicister eller stängda betatestare.

---

### `SecretDepotIDs`

`ImmutableHashSet<uint>` -typ med standardvärdet för att vara tomt. Denna egenskap anger `depåer` att plugin inte kommer att lösas, och om de redan är lösta, kommer inte att skicka nyckeln till. Denna egenskap kan vara användbar för personer med tillgång till potentiellt känslig information om opublicerade objekt, särskilt utvecklare, publicister eller stängda betatestare.

---

### `SecretPackageID`

`ImmutableHashSet<uint>` -typ med standardvärdet för att vara tomt. Denna egenskap anger `packageIDs` (även känd som `subIDs`) att pluginen inte kommer att lösas, och om de redan är lösta, kommer inte att skicka token för. Denna egenskap kan vara användbar för personer med tillgång till potentiellt känslig information om opublicerade objekt, särskilt utvecklare, publicister eller stängda betatestare.

---

### `SkipAutoGrantPaket`

`Bool` typ med standardvärdet `true`. Denna egenskap fungerar mycket likt `SecretPackageIDs` och när aktiverad, kommer att orsaka att paket med `EPaymentMethod` av `AutoGrant` hoppas över under resolut rutin förklaras nedan. `AutoGrant` betalningsmetod används av **[Steamworks](https://partner.steamgames.com)** för att automatiskt bevilja paket på utvecklarkonton. Även om detta inte är lika explicit som andra `Secret` -alternativ, och garanterar därför inget (eftersom du kanske har andra paket än `AutoGrant` som du fortfarande inte vill skicka), Det borde vara tillräckligt bra för att hoppa över majoriteten, om inte alla, av de hemliga paketen. Det här alternativet är aktiverat som standard, som personer som faktiskt har tillgång till `AutoGrant` -paket kommer nästan aldrig att vilja läcka dem för allmänheten. och använder därför värdet av `false` är mycket situationellt.

---

## Ytterligare förklaring

På rotnivå äger varje Steam-konto en uppsättning paket (licenser, prenumerationer), som klassificeras av deras `packageID` (även känd som `subID`). Varje paket kan innehålla flera appar som klassificeras av deras `appID`. Varje app kan sedan innehålla flera depåer som klassificeras av deras `depåID`.

```text
<unk> ─ sub/124923
<unk> ôné ─ app/292030
ôné ─ depå/292031
ôná ─ depå/378648
ôná ─ ...
● ─ app/378649
ôôné ─ ...
└── ...
```

Vår plugin innehåller två rutiner som tar hänsyn till överhoppade objekt - lösa rutin och inlämning rutin.

Lösningen rutin är ansvarig för att lösa trädet du kan se ovan. Genom att svartlista paketen/apparna/depåerna i förväg, du effektivt klippa trädet i stället för svartlistade gren/blad utan ytterligare behov av att ange de återstående delarna av den. I vårt exempel ovan, om `124923` paket ignorerades, antingen av `SecretageIDs` eller `SkipAutoGrantPackages`, och det var det enda paket du äger som kopplat till `292030` appID, sedan appID `292030` skulle inte heller bli löst, och per definition, om det inte fanns några andra lösta appar som länkade till `292031` och `378648` depåer, då skulle de inte bli lösta heller. Men tänk på att om insticksprogrammet redan har löst trädet, då effektivt kommer detta bara att stoppa givet objekt från att uppdateras (t.ex. nya appar läggs till), det kommer inte att göra pluginen "glömmer" om befintliga objekt som redan löstes (e. . apps som finns i det paketet innan du bestämde dig för att svartlista det). Om du bara har aktiverat några hoppar över alternativ och vill se till att ASF inte korsar det redan lösta trädet, du kan överväga en gång ta bort `config/SteamTokenDumper. ache` fil där insticksprogrammet behåller sin cache.

Inlämningsrutinen är ansvarig för att skicka in pakettokens, app-tokens och depånycklar till redan lösta objekt (genom att lösa rutin ovan). Här din svarta lista har omedelbar effekt, som även om plugin redan har löst informationen, inlämningsrutinen kommer faktiskt inte att skicka den över till SteamDB om du har den svartlistad, oavsett om den har lösts eller inte. Tänk dock på att vi inte talar om trädet längre vid denna tidpunkt, inlämningsrutinen vet inte om informationen om appen kommer från det eller det paketet, så det bara hoppa över information om särskilda, svartlistade objekt, oavsett vilken relation de är i med andra.

För de flesta utvecklare och publicister bör det vara tillräckligt för att behålla `SkipAutoGrantPackages` aktiverat, potentiellt utrustad med `SecretPackageID` endast, eftersom det effektivt skär trädet i början grenen och garanterar att de appar och depåer som ingår vidare inte kommer att lämnas in så länge det inte finns någon annan paket som länkar till samma app. Om du vill vara dubbelt säker, förutom att du kan också använda `SecretAppIDs`, som kommer att hoppa över lösningen av appen även om det finns några andra licenser som du inte svartlista länka till den. Användning av `SecretDepotIDs` bör inte behövas, om du inte har en särskild uppgift, specifikt behov (såsom att hoppa över endast en viss depå medan du fortfarande skickar in information om paket och appar), eller om du vill lägga till ytterligare ett lager för att vara trippelsäker.