# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` er offisiell ASF **[programtillegg](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** utviklet av oss, som lar deg bidra til **[SteamDB](https://steamdb.info)** prosjektet ved å dele pakktokene, app tokens og depotnøkler som din Steam konto har tilgang til. Den utvidede informasjonen om innsamlet data og hvorfor SteamDB trenger den kan bli funnet på SteamDBs **[Token Dumper](https://steamdb.info/tokendumper)** siden. De innsendte dataene inneholder ikke noen mulig sensitiv informasjon, og besitter ingen sikkerhets-/personvernrisiko, som angitt i ovennevnte beskrivelse.

---

## Aktiverer utvidelsen

ASF kommer med `SteamTokenDumperPlugin` sammen med utgivelsen, men utvidelsen selv er deaktivert som standard. Du kan aktivere utvidelsen ved å sette `SteamTokenDumperPluginAktivert` ASF global konfigurasjonsegenskap `sann`, i JSON syntaks:

```json
{
  "SteamTokenDumperPluginaktivert": true
}
```

Ved lansering av ASF-programmet vil plugin fortelle deg om den ble aktivert vellykket gjennom standard ASF loggemekanisme. Du kan også aktivere programtillegget gjennom vår nettbaserte konfigurasjonsgenerator.

---

## Tekniske detaljer

Når du aktiverer, vil tillegget bruke botene som du kjører i ASF for datainnsamling i form av pakkenokener, app tokens og deponinøkler som dine botter har tilgang til. Modulen for innsamling av data omfatter passive og aktive rutiner som skal minimere tilleggsløft forårsaket av innsamling av data.

For å oppfylle det planlagte brukstilfellet er det i tillegg til datainnsamling av rutine som er forklart over. innsendingsrutine er initialisert som er ansvarlig for å bestemme hvilke data som må sendes til SteamDB regelmessig. Denne rutinen vil skyte i opptil `1` time etter ASF-start, og vil gjenta seg hver med `24.` time. Utvidelsen vil gjøre sitt beste for å minimere mengden data som må sendes, Derfor er det mulig at en del data som plugin vil samle blir bestemt som ubrukelig å sende, hoppet derfor (for eksempel app-oppdatering som ikke endrer tilgangstoken).

Programtillegget bruker en vedvarende cache-database lagret i `config/SteamTokenDumper.cache` plassering, som tjener et lignende formål som `config/ASF.db` for ASF. Filen benyttes for å kunne registrere innsamlede og innsendte data og minimere det arbeidet som må gjøres mellom ulike ASF-runer. Fjerning av filen fører til at prosessen startes på nytt etter bunnen hvis mulig, og dette bør unngås hvis mulig.

---

## Data

ASF inkluderer bidragsyteren `steamID` i forespørselen, som bestemmes som `SteamOwnerID` som du innstilte i ASF, eller i tilfelle du ikke stemte på, Steam-ID-en til boten som eier flest lisenser. Den annonserte bidragsyteren kan motta noen ekstra fordeler fra SteamDB for kontinuerlig hjelp (e. . donator rang på nettsiden), men det er helt opp til SteamDBs skjønn.

Uansett vil SteamDB ansatte gjerne takke deg på forhånd for hjelp. De innsendte dataene lar SteamDB operere, spesielt spore info om pakker, Programmer og depoter som ikke lenger er mulig uten hjelp.

---

## Kommando

STD plugin kommer med en ekstra ASF kommando, `std [Bots]`slik at du kan starte oppdateringen og sende inn valgte bots på etterspørselen. Bruk av kommandoen krever ikke aktivert konfigurasjon som lar deg hoppe over automatisk innsamling og submisjon, og kontroller prosessen selv manuelt. Naturlig sett kan det også utføres med aktivert konfigurasjon, som bare vil utløse den vanlige innhentingen og innlevering tidligere enn forventet.

We recommend `!std ASF` in order to trigger refresh for all available bots. Du kan imidlertid også utløse den for utvalgte om du ønsker det.

---

## Avansert konfigurasjon

Vårt programtillegg støtter avanserte konfigurasjonsfiler som kan komme nyttige for folk som ønsker å tilpasse Internett, til deres preferanser.

Den avanserte konfigurasjonen har følgende struktur plassert i `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Enabled": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretPackageIDs": [],
    "SkipAutoGrantPackages": true


```

Alle alternativer er forklart nedenfor:

### `Aktivert`

`bool` type with default value of `false`. Denne egenskapen fungerer som den samme som `SteamTokenDumperPluginAktivert` root-nivå egenskapen beskrevet over, og kan brukes i stedet dedikert til personer som foretrekker å ha hele plugin-related config i sin egen struktur (så mest sannsynlig de som allerede bruker andre avanserte egenskaper forklart nedenfor).

---

### `Sekretær AppIDs`

`ImmutableHashSet<uint>` typen med standardverdien for å være tom. Denne egenskapen spesifiserer `appIDs` som utvidelsen ikke blir løst, og hvis de allerede er løst, ikke sende inn tokenet for. Denne egenskapen kan være nyttig for mennesker med tilgang til potensielt sensitiv informasjon om upubliserte elementer, spesielt utviklere, utgivere eller lukkede betatestere.

---

### `SecretDepotIDs`

`ImmutableHashSet<uint>` typen med standardverdien for å være tom. Denne egenskapen spesifiserer `depotIDs` som utvidelsen ikke blir løst, og hvis de allerede er løst, vil ikke sende inn nøkkelen til. Denne egenskapen kan være nyttig for mennesker med tilgang til potensielt sensitiv informasjon om upubliserte elementer, spesielt utviklere, utgivere eller lukkede betatestere.

---

### `SecretPackageIDs`

`ImmutableHashSet<uint>` typen med standardverdien for å være tom. Denne egenskapen spesifiserer `pakkeIDs` (også kjent som `subIDs`), som ikke løses, og hvis de allerede er løst, ikke send inn tokenet for. Denne egenskapen kan være nyttig for mennesker med tilgang til potensielt sensitiv informasjon om upubliserte elementer, spesielt utviklere, utgivere eller lukkede betatestere.

---

### `SkipAutoGrantPackages`

`bool` type with default value of `true`. Denne egenskapen ligner på `SecretPackageIDs` og når aktivert, vil forårsake pakker med `EPaymentMethod` av `AutoGrant` som blir hoppet over under resolusjon rutine beskrevet nedenfor. `AutoGrant` betalingsmåte benyttes av **[Steamworks](https://partner.steamgames.com)** for automatisk å gi pakker på utviklerkontoer. Mens dette ikke er som eksplisitt som andre `hemmelig` alternativer, og derfor ikke garanterer noe (siden du kanskje har andre pakker enn `AutoGrant` som du fortsatt ikke ønsker å sende), det skal være godt nok til å hoppe over flertall, hvis ikke alle, av de hemmelige pakkene. Dette valget er aktivert som standard, siden personer som faktisk har tilgang til `AutoGrant` -pakker nesten aldri vil lekke dem ut til offentligheten, og derfor bruker du verdien av `false` er svært situasjon.

---

## Ytterligere forklaring

På rotnivå eier hver Steam-konto et sett med pakker (misser, abonnementer), som klassifiseres av `pakkeID` (også kjent som `subID`). Hver pakke kan inneholde flere apper klassifisert av `appID`. Hver app kan deretter inkludere flere depoter klassifisert av `depotID`.

```text
➜ sub/124923
################app, app/292030
εεephalephal″depo/292031
by: ¦ φ φ serotype depo/378648
IlarIlar″unnamed@@1) ...
∙∙ε″app/378649
″εεε″...
└── ...
```

Vårt programtillegg inkluderer to rutiner som tar hensyn til hoppet over poster - rutiner som løser og innsending.

Løsningsrutinen er ansvarlig for å løse treet du kan se over. På forhånd svarteliste pakker/apper/depoter, Du kan faktisk kutte treet på stedet til svartelistede grener/dørblad uten ekstra behov for å spesifisere de gjenværende delene av det. I vårt eksempel ovenfor, hvis `124923` -pakken ble ignorert, enten ved `SecretPackageIDs` eller `SkipAutoGrantPackages`, og det er den eneste pakken du eier, som er knyttet til `292030` appID, then appID `292030` ville ikke løst heller, og pr. definisjon, hvis det ikke var noen andre løst apper som var koblet til `292031` og `378648` depoter, Da ville de ikke bli løst heller. Husk imidlertid at hvis pluginen allerede har løst treet, vil dette bare hindre det gitte elementet fra å bli oppdatert (f.eks. nye apper lagt til), det vil ikke gjøre tillegget "glem" om de eksisterende elementene som allerede er løst (e. . apper funnet i den pakken før du bestemte deg for å svarteliste den). Hvis du akkurat har aktivert noen hoppende alternativer, og ønsker å sikre at ASF ikke beveger seg det allerede løste treet, du kan vurdere engangs fjerning av `config/SteamTokenDumper. ache` -filen hvor tillegget holder sin hurtigbuffer.

Innsendingsrutinen er ansvarlig for innsendelse av token, apptokens og depotnøkler av allerede løste elementer (ved hjelp av avløser rutinen ovenfor). Her har din svarteliste umiddelbar effekt, som selv om utvidelsen allerede har løst opp informasjonen, innsendingsrutinen vil faktisk ikke sende den over til SteamDB hvis du har den svartelistet, uansett om den er løst eller ikke. Husk imidlertid at vi ikke snakker om treet lenger på dette punktet, rutinen for innsending vet ikke om opplysningene om appen kommer fra denne pakken eller pakken, Derfor hopper det kun over informasjon om bestemte og svartelistede elementer, uansett relasjon de er med på.

For de fleste utviklere og utgivere bør det være nok å holde `SkipAutoGrantPackages` aktivert. potensielt emdrives med `SecretPackageIDs` Ettersom det effektivt kutter treet på startgrenen og garanterer at appene og lagrene som er med, ikke vil bli sendt så lenge det ikke er noen annen pakke som kobler til den samme appen. Hvis du vil være dobbeltsikker, i tillegg til at du også kan bruke `SecretAppIDs`, som hopper over løsningen i programmet selv om det er noen andre lisenser som du ikke svartelistet linket til den. Ved å bruke `bør sekretariatet` ikke være nødvendig, med mindre du har et spesielt bestemt behov (for eksempel å hoppe bare over et område hvor man sender inn info om pakker og apper), eller hvis du vil legge til enda et lag som skal være tredoble trygt.