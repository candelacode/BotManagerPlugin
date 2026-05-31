# Bakgrunn-spillinnløser

Bakgrunnsspill innlaster er en spesiell innebygd ASF-funksjon som lar deg importere et gitt sett av Steam cd-nøkler (sammen med navnet) å bli innløst i bakgrunnen. Dette er spesielt nyttig hvis du har mange nøkler å innløse og du er garantert å treffe `RateLimited` **[status](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)** før hele batch.

Bakgrunnsspill til innløseren er laget for å ha en enkelt bot-omfang, noe som betyr at den ikke bruker `RedeemingPreferences`. Denne funksjonen kan brukes sammen med (eller i stedet for) `redeem` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, hvis nødvendig.

---

## Importer

Importprosessen kan gjøres på to måter – enten ved hjelp av en fil eller IPC.

### Fil

ASF vil gjenkjenne i sin `config` katalog en fil med navn `BotName.keys` hvor `BotName` er navnet på din bot. Filen har forventet og fast struktur for navn på spillet med cd-nøkkel, skilt fra hverandre med et tabulatortegn og som slutter med en ny linje for å indikere neste oppføring. Dersom flere faner er brukt, regnes første oppføring som spillets navn, siste oppføring betraktes som en cd-nøkkel, og alt mellom ignoreres. For eksempel:

```text
POSTAL 2 ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria ThisIgnorert ThisIsIgnoredToo ZXCVB-ASDFG-QWERT
```

Alternativt kan du også bruke kun format på nøklene (fortsatt med en ny linje mellom hver tilgang). ASF i denne saken skal bruke Steams svar (hvis mulig) for å fylle riktig navn. For alle typer nøkler tagging, anbefaler vi at du navngir tastene selv, siden pakker som lastes inn på Steam ikke trenger å følge logikk for spill som de er aktive, Så avhengig av hva utvikleren har putt, kan du se riktige spillnavn, egendefinerte pakkenavn (e. . Fuktig indisk Bundle 18) eller rett feil og potensielt selv ondsinnede (f.eks. Halvliv 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Uansett hvilket format du har bestemt deg for, ASF vil importere din `keys` -fil, enten ved bot oppstart, eller senere under utførelse. Etter vellykket foreldreundersøkelse av filen og til slutt av ugyldige oppføringer, alle valgte spill vil bli lagt til i bakgrunnskøen, og `BotName. eys` -filen vil bli fjernet fra `config` mappen. Hvis noen ugyldige linjer blir funnet, vil de bli skrevet til `BotName.keys.invalid` -file, i tilfelle du ønsker å korrigere dem og importere på nytt.

### IPC

I tillegg til å bruke nøkkelfil nevnt ovenfor ASF eksponerer også `GamesToRedeInBackground` **[ASF API endepunkt](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** som kan utføres av hvilket som helst IPC verktøy, inkludert vår ASF-ui. Å bruke IPC kan være kraftigere fordi du kan gjøre passende tolking selv, som for eksempel å bruke en tilpasset skilletegn i stedet for å bli tvunget til et tabulatortegn eller til og med introdusere dine helt egne tilpassede nøkler struktur.

---

## Kø

Når spill er importert, er de lagt til i køen. ASF går automatisk gjennom sin bakgrunnskø så lenge bot er koblet til Steam-nettverket, og køen ikke er tom. En nøkkel som ble forsøkt innløst og ikke resulterte i `RateLimited` er fjernet fra køen, med statusen riktig skrevet til en fil i `config` mappen, enten `BotName. øyne. sed` hvis nøkkelen ble brukt i prosessen (f.eks. `NoDetail`, `BadationCode`, `DuplicateActivationCode`), eller `BotName.keys.Ubrukt` annet. ASF bruker ditt medfølgende spillnavn bevisst siden nøkkelen ikke er garantert å ha et meningsfullt navn returnert av Steam nettverk - på denne måten kan du merke nøklene dine ved å bruke selv egendefinerte navn hvis du ønsker/ønsker.

Hvis vi under prosessen setter vår konto treff `RateLimited` status, køen er midlertidig suspendert i en hel time for å vente med cooldown til å forsvinne. Etterpå fortsetter prosessen hvor den venstre, inntil hele køen er tom eller en annen `Rangering` forekommer.

---

## Eksempel

La oss anta at du har en liste over 100 nøkler. Først bør du opprette en ny `BotName.keys.new` fil i ASF `config` mappe. Vi endte `. vis` utvidelse for å la ASF vite at den ikke bør plukke opp denne filen umiddelbart øyeblikket den er laget (som ny tom fil, ikke klar for import ennå.

Nå kan du åpne vår nye fil og klippe inn listen over våre 100 nøkler der, og fikse formatet om nødvendig. After fixes our `BotName.keys.new` file will have exactly 100 (or 101, with last newline) lines, each line having a structure of `GameName\tcd-key\n`, where `\t` is tab character and `\n` is newline.

Du er nå klar til å endre navnet på denne filen fra `BotName.keys.new` til `BotName. eys` for å gi ASF beskjed om at det er klart til å bli plukket opp. Dette er øyeblikket, ASF vil automatisk importere filen (uten behov for omstart) og slette den etterpå, å bekrefte at alle våre spill ble analysert og lagt til i køen.

I stedet for å bruke `BotName.keys` -filen, kan du også bruke IPC API endepunkt, eller til og med kombinere begge hvis du vil.

Etter en stund, `BotName.keys.benyttet` og `BotName.keys.ubrukt` filer vil bli generert. Disse filene inneholder resultater av vår innløsningsprosess. For eksempel kan du endre navnet på `BotName.keys.ubrukt` til `BotName2. eys` -fil og send derfor våre ubrukte nøkler for en annen bot, siden tidligere bot ikke brukte disse nøklene selv. Eller du kan bare kopiere og lime inn ubrukte nøkler til en annen fil, og beholde den for senere, ringen. Husk at mens ASF går gjennom køen, går nye oppføringer vil bli lagt til i vår output `benyttet` og `ubrukte` -filer, Det er derfor anbefalt å vente på at køen blir helt tømt før du bruker dem. Hvis du overhodet må du få tilgang til disse filene før køen blir tømt du burde først **flytte** utdatafil du vil ha tilgang til en annen mappe, **så** lese den. Dette er fordi ASF kan legge til nye resultater mens du gjør ditt beste. og som potensielt kan føre til tap av noen nøkler hvis du leser en fil du har det. . 3 nøkler inni, slett den helt, og mangler det faktum at ASF la til 4 andre nøkler til din fjernede fil i mellomtiden. Hvis du vil få tilgang til disse filene, må du flytte dem vekk fra ASF `config` før du leser dem, for eksempel ved å gi dem et nytt navn.

Det er også mulig å legge til ekstra spill for å importere med noen spill allerede i vår kø, ved å repetere alle trinnene ovenfor. ASF vil legge våre ekstra innlegg til allerede i køen og håndtere den etter hvert.

---

## Kommentarer

Bakgrunnstaster innløser bruker `OrderedDictionary` under verten, hvilket betyr at cd-nøklene dine vil ha tatt vare på rekkefølgen slik de ble spesifisert i filen (eller IPC API samtale). Dette betyr at du kan (og bør) inneholde en liste over hvor gitt cd-nøkkel bare kan ha direkte avhengigheter mot nøkler oppført ovenfor, men ikke nedenfor. For eksempel, dette betyr at hvis du har DLC `D` som krever spill `G` aktiveres først deretter cd-nøkkel for spill `G` skal **alltid** være inkludert før cd-nøkkel for DLC `D`. Likeledes vil hvis DLC `D` ha avhengigheter av `A`, `B` og `C`, da skal alle 3 tas med før (i alle ordre, med mindre de har avhengighet av egen hånd).

Følger ikke skjemaet ovenfor vil resultere i at DLC ikke blir aktivert med `DoesNotOwnRequiredApp`, selv om kontoen din ville være kvalifisert for å aktivere den etter å ha gått gjennom hele køen. Hvis du vil unngå det, må du sørge for at DLC alltid er inkludert etter base-spillet i avspillingskøen.