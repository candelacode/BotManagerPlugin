# Sikkerhet

## Kryptering

ASF støtter for tiden følgende krypteringsmetoder som definisjon av `ECryptoMethod`:

| Verdi | Navn                          |
| ----- | ----------------------------- |
| 0     | Smertetekst                   |
| 1     | AES                           |
| 2     | ProtectedDataForCurrentBruker |
| 3     | Miljøvariabel                 |
| 4     | Fil                           |

Nedenfor finner du en nøyaktig beskrivelse og sammenligning.

### Oppsett

For å generere kryptert passord f.eks for `Bruk av SteamPassword` du bør kjøre `krypter` **[kommandoen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** med riktig kryptering som du valgte og ditt opprinnelige passord for ren tekst. Etterpå plasserer du den krypterte strengen du har fått som `SteamPassword` bot config property, og til slutt endre `passordformat` til den som samsvarer med den valgte krypteringsmetoden din. Noen formater krever ikke `encrypt` kommando, for eksempel `Miljøvariabel` eller `Fil`, bare angi passende sti til dem.

---

### `Smertetekst`

Dette er den mest enkle og usikre måten å lagre et passord på, definert som `ECryptoMethod` of `0`. ASF forventer at strengen er en ren tekst - et passord i direkte skjemaet. Det er den enkleste å bruke, og 100% kompatible med alle oppsettene, Derfor er det en standard måte å lagre hemmeligheter, helt usikker på sikker lagring.

---

### `AES`

Anses sikret i dag standarder **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** lagringsmåte er definert som `ECryptoMethod` i `1`. ASF forventer at strengen er en **[base64-kodet](https://en.wikipedia.org/wiki/Base64)** sekvens av tegn som resulterer i en AES-kryptert byte array etter oversettelse, som så skal dekrypteres ved bruk av inkluderte **[initialiseringsvektor](https://en.wikipedia.org/wiki/Initialization_vector)** og ASF krypteringsnøkkel.

Metoden ovenfor garanterer sikkerhet så lenge en angriper ikke vet ASF-krypteringsnøkkel som brukes til dekryptering samt kryptering av passord. ASF lar deg spesifisere nøkkel via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, som du skal bruke for maksimal sikkerhet. Hvis du bestemmer deg for å utelate det, vil ASF bruke sin egen nøkkel som er **kjent** og hardkodet i applikasjonen, Det betyr at hvem som helst kan omgjøre ASF-krypteringen og bli dekryptert passord. Det krever fortsatt innsats og er ikke så lett å gjøre, men mulig. Det er derfor bør du nesten alltid bruke `AES` -kryptering med din egen `--cryptkey` som beholdes i hemmelig. AES metode brukt i ASF sikrer sikkerhet som bør være tilfredsstillende, og det er en balanse mellom `PlainText` og kompleksiteten til `ProtectedDataForCurrentUser`, men det er sterkt anbefalt å bruke det med egendefinert `--cryptkey`.

Dersom den brukes riktig (lang, tilpasset `--cryptkey`), garanterer veldig høy sikkerhet for sikker lagring.

---

### `ProtectedDataForCurrentBruker`

Anses sikret i dag standarder **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** lagringsmåte er definert som `ECryptoMethod` i `2`. Den største fordelen med denne metoden er samtidig den store ulempen - i stedet for å bruke krypteringsnøkkel (som i `AES`), data krypteres ved hjelp av påloggingsinformasjon for pålogget bruker, som betyr at det er mulig å dekryptere dataene **bare** på maskinen den ble kryptert på, og i tillegg til det, **bare** av brukeren som har sendt ut krypteringen.

Dette sikrer at selv om du sender hele `flasken. sønn` med kryptert `SteamPassword` ved å bruke denne metoden til noen, de vil ikke kunne dekryptere passordet uten direkte tilgang til PC-en din. Dette er et utmerket sikkerhetstiltak, men har samtidig en stor ulempe ved å være minst kompatibel, siden passordet kryptert med denne metoden blir inkompatibel med andre brukere samt med maskinen - inkludert **din egen** hvis du bestemmer det. . Installer operativsystemet på nytt. Dette er den anbefalte metoden hvis du ikke har tilgang til konfigurasjonene dine fra noen annen maskin enn din egen, og at du heller ikke krever kompatibilitet med kryssmaskiner.

**Vær oppmerksom på at dette alternativet er kun tilgjengelig for maskiner som kjører Windows OS nå.**

---

### `Miljøvariabel`

Minnebasert lagring definert som `ECryptoMethod` of `3`. ASF vil lese passordet fra miljøvariabelen med angitt navn i passordfeltet (f.eks `SteamPassword`). For eksempel, Angi `SteamPassword` til `ASF_PASSWORD_MYACCOUNT` og `PasswordFormat` til `3` vil føre til at ASF vil evaluere `${ASF_PASSWORD_MYACCOUNT}` variabelen og bruke det som måtte være tilordnet det som kontopassord.

Husk å sikre at miljøvariablene i ASF-prosessen ikke er tilgjengelige for uautoriserte brukere, som viser hele formålet med bruken av denne metoden.

---

### `Fil`

Fil-basert lagring (muligens utenfor ASF konfigurasjonsmappen) definert som `ECryptoMethod` of `4`. ASF vil lese passordet fra filbanen angitt i passordfeltet (feks. `SteamPassword`). Den angitte banen kan være enten absolutt, eller relativ til ASFs "hjem" plassering (mappen med `config` mappens inni, å ta hensyn til `--path` **[kommandolinjeargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). Denne metoden kan brukes for eksempel ved bruk av **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**, som lager slike filer til bruk, men kan også brukes utenfor Docker hvis du lager en passende fil selv. For eksempel kan du sette `SteamPassword` til `/etc/secrets/MyAccount. ass` og `PasswordFormat` til `4` vil føre til at ASF leser `/etc/secrets/MyAccount. ass` og bruk det som skrives til filen som kontopassord.

Husk å forsikre deg om at filen som inneholder passordet, ikke er lesbar av uautoriserte brukere, da dette besvarer hele formålet med bruken av denne metoden.

---

## Kryptering anbefalinger

Hvis kompatibilitet ikke er et problem for deg, og du er greit med måten `ProtectedDataForCurrentUser` på, virker det er alternativet **anbefalt** for å lagre passordet i ASF, slik det gir best sikkerhet og trivsel. `AES` er et godt valg for personer som fremdeles ønsker å gjøre bruk av sine konfigurasjoner på enhver maskin de ønsker, mens `Planlagt tekst` er den mest enkle måten å lagre passordet på, hvis du ikke tenker på at noen kan se på JSON-konfigurasjonsfilen for den.

Vær oppmerksom på at alle krypteringsmetoder anses som **usikre** hvis angriper har tilgang til PCen din. ASF må kunne dekryptere de krypterte passordene, og hvis programmet som kjører på maskinen din er i stand til å gjøre det, deretter vil et annet program som kjører på den samme maskinen, kunne gjøre det også. `ProtectedDataForCurrentUser` er den sikreste varianten som **en annen bruker som bruker den samme PC-en vil ikke kunne dekryptere den**, men det er fortsatt mulig å dekryptere dataene om noen kan stjele påloggingslegitimasjoner og maskininformasjon i tillegg til ASF konfigurasjonsfilen.

For avanserte oppsett, kan du bruke `Miljøvariabelen` og `fil`. De har begrenset anvendelighet, `Miljøvariabelen` vil være en god idé hvis du skulle foretrekke å skaffe deg passord gjennom en slags tilpasset løsning og lagre det i minnet ekskludert. mens `Fil` er god for eksempel med **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. Begge er ukrypterte og i utgangspunktet ukrypterte, slik at du flytter risikoen fra ASF konfigurasjonsfilen til hva du måtte velge blant de to.

I tillegg til krypteringsmetodene spesifisert over, er det mulig også å unngå å angi passord fullstendig, for eksempel som `SteamPassword` ved å bruke en tom streng eller `null` verdi. ASF vil be deg om ditt passord når det er nødvendig. og lagrer ikke det hvor som helst, men har minnet om aktiv prosess, før du lukker det. Mens de er den sikreste metoden for å håndtere passord (de er ikke lagret noe sted), Det er også det mest problematisk når du må skrive inn passordet manuelt ved hver ASF-kjøring. (når det trenges). Hvis det ikke er et problem for deg, er dette den beste vedleiesikkerheten, for du kan ikke lekke noe som ikke eksisterer.

---

## Dekryptering

ASF støtter ikke noen måte å dekryptere krypterte passord på, siden dekrypteringsmetoder bare brukes internt for å få tilgang til dataene inni prosessen. Hvis du ønsker å tilbakestille krypteringsprosedyren, f.eks. for å flytte ASF til annen maskin når du bruker `BeskyttedDataForCurrentUser`, og bare gjenta prosedyren fra begynnelsen av i det nye miljøet.

---

## Hashing

ASF støtter for tiden følgende hashingmetoder som en definisjon av `EHashingMethod`:

| Verdi | Navn        |
| ----- | ----------- |
| 0     | Smertetekst |
| 1     | Skarpt      |
| 2     | Pbkdf2      |

Nedenfor finner du en nøyaktig beskrivelse og sammenligning.

### Oppsett

For å generere en hash, f.eks. for `IPCPassword` bruk, du bør kjøre `hash` **[kommandoen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** med den aktuelle hashing-metoden som du valgte og det opprinnelige passordet for ren tekst. Etterpå plasserer du den heftede strengen du har fått som `IPCPassword` ASF konfigurasjonsegenskapen, og til slutt endrer du `IPCPasswordFormat` til den som samsvarer med den valgte hashingmetoden.

---

### `Smertetekst`

Dette er den mest enkle og usikre måten å hashing et passord på, definert som `EHashingMethod` av `0`. ASF vil generere hash som matcher den opprinnelige inngangen. Det er den enkleste å bruke, og 100% kompatible med alle oppsettene, Derfor er det en standard måte å lagre hemmeligheter, helt usikker på sikker lagring.

---

### `Skarpt`

Anses sikret i dag standarder **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** måte å hashing passordet er definert som `EHashingMethod` av `1`. ASF vil bruke `SCrypt` implementeringen ved å bruke `8` blokker, `8192` iterasjoner, `32` hash-lengde og krypteringsnøkkel som et salt for å generere listen med bytes. De resulterende bytene vil så bli kodet som **[base64](https://en.wikipedia.org/wiki/Base64)** streng.

ASF lar deg spesifisere salt for denne metoden via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, som du bør bruke for maksimal sikkerhet. Hvis du bestemmer deg for å utelate det, vil ASF bruke sin egen nøkkel som er **kjent** og hardkodet i applikasjonen, betydningen av hashing vil være mindre sikker.

Dersom det blir brukt riktig (tilpasset salt, langt passord), garanterer veldig høy sikkerhet for sikker lagring.

---

### `Pbkdf2`

Anses for å være svak i dag. **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** hashing passordet er definert som `EHashingMethod` av `2`. ASF vil bruke `Pbkdf2` implementeringen ved hjelp av `10000` iterasjoner, `32` hash-lengde og krypteringsnøkkel som et salt, med `SHA-256` som en hma-algoritme. De resulterende bytene vil så bli kodet som **[base64](https://en.wikipedia.org/wiki/Base64)** streng.

ASF lar deg spesifisere salt for denne metoden via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, som du bør bruke for maksimal sikkerhet. Hvis du bestemmer deg for å utelate det, vil ASF bruke sin egen nøkkel som er **kjent** og hardkodet i applikasjonen, betydningen av hashing vil være mindre sikker.

---

## Hashing anbefaling

Hvis du ønsker å bruke en hashing metode for å lagre noen hemmeligheter, for eksempel `IPCPassword`, Vi anbefaler å bruke `SCrypt` med egendefinert salt, siden det gir en svært anstendig sikkerhet mot brute-tvangsforsøk.

`Pbkdf2` tilbys bare av kompabilitetsårsaker, hovedsaklig fordi vi allerede har et arbeid (og trengte) implementering av det for andre saker på tvers av Steam-plattformen (e. . foreldreløse pinner). Det anses fremdeles som sikker, men svakt i forhold til alternativene (f.eks. `SCrypt`).