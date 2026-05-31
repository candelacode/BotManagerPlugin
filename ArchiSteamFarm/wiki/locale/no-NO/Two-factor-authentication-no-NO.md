# To-faktor autentisering

Steam omfatter tofaktor-autentiseringssystem som krever ekstra detaljer for ulik kontorelatert aktivitet. Du kan lese mer om den **[her](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** og **[her](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. Denne siden anser 2FA systemet og vår løsning som integrerer med det, kalt ASF 2FA.

---

# ASF logikk

Uansett om du bruker ASF 2FA eller ikke, inkluderer ASF logikk og er fullt klar over konto beskyttet av 2FA på Steam. Det vil be deg om nødvendige opplysninger når de er nødvendige (f.eks. når de logger seg). Mens du manuelt kan gi denne informasjonen visse ASF-funksjonaliteter (som `MatchActively`) krever at ASF 2FA er operativt på din bot konto. som automatisk kan svare på 2FA-ledninger, automatisk når det kreves av ASF.

---

# ASF 2FA

ASF 2FA er en innebygd modul som er ansvarlig for å gi 2FA-funksjoner til ASF-prosessen, som generering av tokens og aksepterer bekreftelser. Enten kan den fungere i frittstående modus, eller ved å duplisere dine eksisterende autentiseringsopplysninger (slik at du kan bruke din nåværende autentiseringsenhet og ASF 2FA samtidig.

Du kan kontrollere om din bot konto er ved å bruke ASF 2FA allerede ved å kjøre `2fa` **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Uten å sette opp ASF 2RA vil alle standardkommandoene `2fa` være ikke-operative, noe som betyr at boten din ikke er tilgjengelig for avanserte ASF-funksjoner som krever at modulen skal være operativ.

---

# Anbefalinger

Her inkluderer vi våre anbefalinger basert på din nåværende situasjon:

- Hvis du allerede bruker en uoffisiell tredjeparts app som lar deg hente ut 2FA detaljer med enkelt, bare **[importere](#import)** de til ASF.
- Hvis du bruker den offisielle appen og du ikke mener å nullstille dine 2FA legitimasjoner, er den beste måten å deaktivere 2FA, deretter **[opprett](#creation)** nye 2FA legitimasjon ved å bruke **[felles autentisering](#joint-authenticator)**som lar deg benytte offisiell app og ASF 2FA. Denne metoden **krever ikke rot**, jailbreaking or any avansert kunnskap, knapt følgende instruksjoner skrevet her, og er svært bedre for dette scenariet.
- Hvis du bruker den offisielle appen og ikke ønsker å gjenskape 2FA-opplysningene dine, er valgene dine svært begrensede, vil vanligvis trenge rot og ekstra fiddling rundt **[importere](#import)** disse detaljene, – og med det kan det ikke være mulig.
- Hvis du ikke bruker 2FA ennå og ikke bryst, vi anbefaler deg å bruke ASF 2FA med **[standalone authenticator](#standalone-authenticator)** eller **[joint authenticator](#joint-authenticator)** med offisiell app (samme som ovenfor).

Nedenfor diskuterer vi alle mulige alternativer og metoder.

---

## Opprettelse

ASF kommer med en offisiell `MobileAuthenticator` **[tillegg](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** som utvider ASF 2FA, Tillat deg å koble en helt ny 2FA-autentisering. Dette kan være nyttig i tilfelle du ikke kan eller er villig til å benytte andre verktøy og ikke tenker på ASF 2FA som din hoved- (og kundet) autentifikator. Skapingsprosessen brukes også i samautentiseringsmetoden, naturlig i dette scenariet kan autentiseringen sameksisterer to steder på én gang - begge vil generere de samme kodene og begge vil kunne bekrefte de samme bekreftelsene.

### Vanlige trinn for begge scenariene

Uansett om du planlegger å bruke ASF som frittstående eller felles autentisering, må du gjøre disse initialiseringstrinnene:

1. Opprett en ASF-bot for målkontoen, start den og logg inn, som du trolig allerede har gjort.
2. Tildel et fungerende og operativt telefonnummer til kontoen **[her](https://store.steampowered.com/phone/manage)** som skal brukes av boten. Dette lar deg motta SMS-kode og tillate gjenoppretting hvis nødvendig. Dette trinnet er ikke obligatorisk på alle scenarier, men vi anbefaler det med mindre du vet hva du gjør.
3. Sørg for at du ikke bruker 2FA ennå for kontoen din, hvis du gjør det deaktiver først. Denne **vil** sette kontoen din på midlertidig bytteordning, det er ingen vei rundt den, bare **[importere](#import)** -prosessen kan hoppe over det.
4. Utfør `2fainit [Bot]` command, erstatte `[Bot]` med navnet på din bot.

Forutsatt at du fikk et vellykket svar, har de følgende to tingene skjedde:

- En ny `<Bot>.maFile.PENDING` fil ble generert av ASF i `config` mappen.
- SMS er sendt fra Steam til telefonnummeret du har fått tildelt kontoen ovenfor. Hvis du ikke oppga et telefonnummer, så ble en e-post sendt i stedet til kontoens e-postadresse.

Ansvarsinformasjonen er ikke operativ ennå, men du kan gå gjennom den genererte filen hvis du ønsker det. Hvis du ønsker å være dobbeltsikker, kan du for eksempel skrive ned tilbakekallingskoden. De neste trinnene vil være avhengig av ditt valgte scenario.

### Frittstående autentifikator

Hvis du ønsker å bruke ASF som din hovednøkkel (eller eneste) autentisering, må du nå gjøre det endelige ferdighetstrinnet:

5. Kjør `2fafinalize [Bot] <ActivationCode>` kommando, erstatte `[Bot]` med din bots navn og `<ActivationCode>` med koden du har mottatt via SMS eller e-post i det forrige trinnet.

### Joint authenticator

Dersom du ønsker å ha den samme autentiseringsenheten i både ASF og den offisielle Steam mobile appen, nå trenger du å gjøre de neste vanskeligste trinnene:

5. **Ignore** the SMS or e-mail code that you've received in the previous step.
6. Installer Steam mobilappen hvis den ikke er installert ennå, og åpne den. Naviger til Steamvern-fanen og legg til en ny autentiserer ved å følge appens instruksjoner.
7. Etter at autentiseringen i den mobile appen er lagt til og fungerer, gå tilbake til ASF. I stedet for å fullføre, trenger vi bare å informere ASF om at mobilappen allerede aktiverte våre tidligere genererte detaljer:
 - Vent til neste 2FA-kode vises i Steam mobilappen og bruk kommandoen `2fafinalisert [Bot] <2FACodeFromApp>` erstatte `[Bot]` med din bots navn og `<2FACodeFromApp>` med koden du ser i Steam mobil-appen - det samme du vil bruke til å logge inn på Steam (**IKKE** den du allerede har brukt til aktivering). Hvis koden som er generert av ASF og koden du oppgitt, er like, ASF vil anta at en autentifikator ble lagt til riktig og fortsette med import av din nyopprettede autentiserer.
 - Vi anbefaler på det sterkeste å gjøre det ovennevnte for å sikre at legitimasjonen er gyldig. Hvis du imidlertid ikke vil (eller ikke kan 't) kontrollere om koder er de samme, og du vet hva du gjør, du kan i stedet bruke kommandoen `2fafinalizedforce [Bot]`erstatte `[Bot]` med navnet på din bot. ASF vil anta at autentifikatoren ble lagt til riktig og fortsette med å importere din nyopprettede autentiserer. Vær oppmerksom på at det i denne modus ASF ikke er mulig å kontrollere om kodene er like, som betyr at du potensielt kan importere ugyldig (ikke aktivert) legitimasjon.

### Etter ferdigstilling

Forutsatt at alt fungerte ordentlig, har den tidligere genererte `<Bot>.maFile.PENDING` filen ble døpt til `<Bot>.maFile.NEW`. Dette indikerer at 2FA påloggingsinformasjon nå er gyldig og aktiv. Vi anbefaler at du flytter filen utenfor `config` mappen, og **lagrer den på sikker sted**. I tillegg til det, hvis du har valgt å bruke frittstående autentisering, da anbefaler vi deg å åpne filen i ditt eget redigeringsprogram og skrive ned `revocation_code`, som vil tillate at du kan, som navnet tilsier, tilbakekalle autentiseringen i tilfelle du mister den. I felles autentiseringsmetode bør du allerede ha gjort det i Steam mobilapp, men føler deg fri til å gjøre det samme i tilfelle du trenger det.

Når det gjelder tekniske detaljer, den genererte `maFile` inneholder alle detaljer som vi har mottatt fra Steam-serveren under kobling av autentiseringen, og i tillegg til det, feltet `device_id` , som kan være nødvendig for annen (tredjepart) autentiserere, hvis du noen gang bestemmer deg for å importere at `maFile` skal importeres til dem.

ASF importerer automatisk din autentiseringsator når prosedyren er gjort, og derfor `2fa` og andre relaterte kommandoer bør nå være operative for bot-kontoen du har koblet autentiseringen til. Vi anbefaler deg å verifisere det.

---

## Importer

Import process requires already linked and operational authenticator that is supported by ASF. Vi har noen forskjellige offisielle og uoffisielle kilder til 2FA, i tillegg til en manuell metode som lar deg angi påkrevd innloggingsinformasjon selv. Vær oppmerksom på at disse instruksjonene bør brukes **kun** hvis du allerede bruker en løsning – siden det følger en prosess som tredjepartsapper og verktøy, **vi anbefaler ikke å bruke dem**, og vi nevner det utelukkende for personer som allerede har bestemt seg for å bruke dem, og ønsker derfor å importere genererte detaljer i ASF 2FA.

Generelt sett innebærer importprosessen å slippe `maFile` i riktig format til ASF's `config` mappe, hvor ASF vil hente denne filen og automatisk fjerne den av sikkerhetsgrunner.

Alle følgende guider krever fra deg allerede at **arbeider og drifts-** autentiseringsinnretning brukes med gitt tool/applikasjon. ASF 2FA vil ikke fungere riktig hvis du importerer ugyldige data, derfor må du sørge for at autentifikatoren fungerer riktig før du prøver å importere den. Dette omfatter testing og verifisering av at følgende autentiseringsfunksjoner fungerer riktig:
- Du kan generere tokens og tokens godtas av Steam-nettverket (du kan logge inn med dem)
- Du kan hente bekreftelser, og de kommer på din mobile autentifikator
- Du kan reagere på disse bekreftelsene, og de er godt anerkjent av Steam-nettverket som bekreftet/avvist

Kontroller at autentiseringen fungerer ved å sjekke om ovennevnte handlinger fungerer - hvis de ikke gjør det, virker heller ikke de i ASF.

### Android telefon

Vanligvis for import av autentiseringsenhet fra Android-telefonen vil du trenge tilgang **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))** Instruksjonene nedenfor krever fra deg ganske anstendig kunnskap i Android-modningsverdenen, vi vil definitivt ikke forklare alle trinn her, besøk **[XDA](https://xdaforums.com)** og andre ressurser for ytterligere informasjon/hjelp med nedenfor.

**Det er per i dag ikke kjent noen bekreftede utvinningsmetoder som pågår. Du kan prøve å følge nedenfor trinnene uansett, for eksempel med utdatert app-versjon, men vi garanterer ikke at dette fungerer ordentlig. Vurder bruk av felles autentiseringsmetode i stedet.**

<details>
  <summary>Instruksjon i arkivet</summary>

Forutsatt at du har offisiell **[Steam app](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** arbeid og drift (nedenfor krever rooting av enheten):

- Installer **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** og aktiver Zygisk i innstillingene.
- Installer **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (for Zygisk) og sørg for at det fungerer.
- Installer **[SteamGuardDump](https://github.com/YifePlayte/SteamGuardDump/releases/latest)** eller **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** LSPandt modul og aktiver den i LSPed-innstillinger.
- Tving kill Steam app, så åpne den, dampvaktdetaljer kan nå være tilgjengelig for kopiering til utklippstavlen.

Nå som du har lykkes med å hente nødvendige detaljer, deaktiver modulen for å forhindre automatisk kopiering hver gang, så kopier verdien av `shared_secret` og `identity_secret` av kontoen du vil legge til i ASF 2FA, til en ny tekstfil med følgende struktur:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Erstatt hver `STRING` verdi med passende privat nøkkel fra utpakkede detaljer. Når du har gjort det, får du endre navn på filen `BotName. aFil`, hvor `BotName` er navnet på boten du legger til ASF 2FA til, og legg den til i mappen ASF for `config` hvis du ikke har enda.

Start ASF, som skal merke filen og importere den. Forutsatt at du har importert riktig fil med gyldige hemmeligheter, bør alt fungere ordentlig, som du kan bekrefte ved å bruke `2fa` kommandoer. Hvis du gjorde en feil, kan du alltid fjerne `Bot.db` og begynne på nytt om nødvendig.

</details>

### SteamDesktopAutentisering

Dersom du allerede har en autentiseringsfil som kjører i SDA allerede, bør du merke deg at det er `steamID.maFile` som er tilgjengelig i `maFiles` -mappen. Kontroller at `maFile` er i ukryptert skjema, siden ASF ikke kan dekryptere SDA filer - ukryptert filinnhold bør starte med `{` og slutte med `}` tegn. Om nødvendig, kan du fjerne krypteringen fra SDA-innstillinger først, og aktivere den på nytt når du er ferdig. Når filen er i ukryptert form, kopier den til `config` mappe med ASF.

Du kan nå endre navn på `steamID.maFile` til `BotName. aFile` i ASF konfigurasjonsmappen, hvor `BotName` er navnet på botten du legger til ASF 2FA til. Alternativt kan du forlate den slik den er, ASF vil da velge den automatisk etter innlogging. Å endre navn på filen hjelper ASF ved å gjøre det mulig å bruke ASF 2FA før du logger inn, hvis du ikke gjør det, deretter kan filen kun plukkes etter at ASF logger inn (som ASF ikke kjenner til `steamID` av din konto før du faktisk logger inn).

Start ASF, som skal merke filen og importere den. Forutsatt at du har importert riktig fil med gyldige hemmeligheter, bør alt fungere ordentlig, som du kan bekrefte ved å bruke `2fa` kommandoer. Hvis du gjorde en feil, kan du alltid fjerne `Bot.db` og begynne på nytt om nødvendig.

### WinAuth

Opprett først en ny tom `Flaskenavn. aFile` i ASF konfigurasjonsmappen, hvor `BotName` er navnet på botten du legger til ASF 2FA til. Dersom du gir feil navn, vil det ikke bli valgt av ASF.

Nå lanseres WinAuth som vanlig. Høyreklikk på Steam-ikonet og velg "Vis SteamGuard og Recovery kode". Deretter sjekk "Tillat kopi". Du bør kjenne deg JSON-strukturen på bunnen av vinduet, som starter med `{`. Kopier hele teksten til en `BotName.maFile` -fil laget av deg i forrige steg.

Start ASF, som skal merke filen og importere den. Forutsatt at du har importert riktig fil med gyldige hemmeligheter, bør alt fungere ordentlig, som du kan bekrefte ved å bruke `2fa` kommandoer. Hvis du gjorde en feil, kan du alltid fjerne `Bot.db` og begynne på nytt om nødvendig.

### Manuell

Hvis du er avansert kan du også generere maFile manuelt. Dette kan brukes hvis du ønsker å importere autentifikator fra andre kilder enn de vi har beskrevet ovenfor. Det skal ha en **[gyldig JSON-struktur](https://jsonlint.com)** på:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Standard autentiseringsdata har flere felt - de er fullstendig ignorert av ASF under import ettersom de ikke er nødvendig. Du trenger ikke å fjerne dem - ASF krever bare gyldig JSON med 2 obligatoriske felter beskrevet ovenfor, og vil ignorere flere felt (hvis noen). Du må selvsagt erstatte `STRING` plassholderen i eksemplet over med gyldige verdier for kontoen din. Each `STRING` should be base64-encoded representation of bytes the appropriate private key is made of.

---

## OSS

### Hvordan bruker ASF 2FA modulen?

Hvis ASF 2FA er tilgjengelig, vil ASF benyttes for automatisk trade-bekreftelse som blir sendt/akseptert av ASF. I tillegg vil det være i stand til automatisk å generere 2FA tokens på alminnelig basis, for eksempel for å logge inn. I tillegg til det, med ASF 2FA aktiverer du også `2fa` kommandoer for deg å bruke.

### Hvordan kan jeg hente 2FA token?

Du trenger 2FA token for å få tilgang til 2FA-beskyttet konto, som også inkluderer hver konto med ASF 2FA. Hvis du har valgt å bruke frittstående autentisering, bør du bruke `2fa <BotNames>` -kommandoen for å generere midlertidige token for gitte bot forekomster. I alle andre scenarier anbefaler vi å bruke den originale autentiseringen som du har brukt, Selv om du kan bruke kommandoen i tillegg hvis det er enklere for deg.

### Kan jeg bruke min opprinnelige autentiseringsenhet etter import som ASF 2FA?

Ja, den opprinnelige autentiseringsenheten din forblir funksjonell, og du kan bruke den sammen med ASF 2FA. Husk imidlertid at hvis du ugyldiggjør det via en metode, vil heller ikke koblet ASF 2FA påloggingsinformasjon lenger være gyldig.

### Hvordan fjerne ASF 2FA?

Bare stopp ASF og fjern assosiert `BotName.db` av botten med tilknyttet ASF 2FA du vil fjerne. Dette alternativet vil fjerne tilknyttet 2FA med ASF, men IKKE ugyldiggjør (unlink) din autentiserer. Hvis du i stedet ønsker å ugyldiggjøre autentiseringsenheten din, bortsett fra å fjerne den fra ASF (først), bør du fjerne den i originalautentiseringen av valget ditt. Dersom du av en eller annen grunn ikke kan gjøre det, fordi du bruker ASF 2FA i frittstående modus, bruk da tilbakekallingskode som du har mottatt under konfigurering, på Steam nettside. Det er ikke mulig å ugyldiggjøre din autentisering gjennom ASF.

### Jeg koblet autentisering i tredjeparts-app, deretter importert til ASF. Kan jeg nå lenke den igjen på telefonen min?

**No**. Å gjøre det vil ugyldiggjøre tidligere importert legitimasjon og ASF 2FA vil slutte å fungere (ved å generere koder som ikke lenger er akseptert av Steam). Først bestemme seg for hvor du ønsker å ha den originale eller tredjeparts autentiseringsenheten din, og deretter importere den som ASF 2FA.

### Jeg bruker felles autentiseringsenhet, kan jeg flytte appen min til en annen telefon?

**No**. Hvilke dampstater som "flytting" eller "overføring" autentisering, er faktisk lik den gamle og tilordner et nytt steg. Dette lar deg hoppe over f.eks en viss for stor nedkjøling sammenlignet med de to trinnene uavhengig av hverandre, men når det gjelder ASF, dette er faktisk ugyldiggjør opplysningene du tidligere har generert i ASF, noe som gjør hele ASF 2FA-modulen ikke-operativ.

Anbefalt måte er å fjerne din autentiseringsmetode fullstendig på den gamle telefonen og bruke felles autentiseringsmetode igjen på den nye telefonen. Hvis du allerede har flyttet autentiseringen, så er gamle ASF 2FA pålogget, så det eneste venstre nå er å fjerne «moved» autentiseringsenheten din og koble til en ny med ledetekstmetoden igjen.

### Bruker ASF 2FA bedre enn tredjeparts autentisering, set til å godta alle bekreftelser?

**Ja**, på flere måter. First and most important one - using ASF 2FA **significantly** increases your security, as ASF 2FA module ensures that ASF will only accept automatically its own confirmations, so even if attacker does request a trade that is harmful, ASF 2FA will **not** accept such trade, as it was not generated by ASF. I tillegg til sikkerhetsdelen, ved hjelp av ASF 2FA også å gi fordeler til ytelse/optimalisering, som ASF 2FA henter og aksepterer bekreftelser umiddelbart etter at de er generert, og bare i motsetning til ineffektiv polling for bekreftelser hvert X minutter, som oppnås av andre løsninger. Det er ingen grunn til å bruke tredjeparts autentifikator over ASF 2FA, hvis du planlegger en automatisering av bekreftelser generert av ASF - det er nøyaktig hva ASF 2FA er for, å bruke den er ikke i strid med deg og bekrefter alle andre i autentiseringen av ditt valg. Vi anbefaler på det sterkeste å bruke ASF 2FA for hele ASF-aktiviteten.