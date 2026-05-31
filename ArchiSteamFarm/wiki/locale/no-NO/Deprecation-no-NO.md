# Utfasing

Vi gjør vårt beste for å følge en konsistent avskrivningspolitikk slik at både utviklingen og bruken langt mer konsekvent.

---

## Hva er avskrivning?

Deprecation is the process of mindre or bigger breaking changes that render previously used options, arguments, functionalities or usage cases obsolete. Nedskrivning betyr vanligvis at det bare ble omskrevet til en annen (lignende) form, og du bør forsikre deg om at du i tide gjør passende bytte til det. I dette tilfellet flytter den bare funksjonalitet til en mer passende plass.

ASF endrer seg raskt og slår alltid på seg for å bli bedre. Dette innebærer dessverre at vi kan endre eller flytte noen eksisterende funksjonalitet til en annen del av programmet for å få det til å dra nytte av nye funksjoner, kompatibilitet eller stabilitet. Takket være at vi ikke trenger å holde oss til foreldet eller bare smertefulle utviklingsbeslutninger som vi fattet for år siden. Vi forsøker alltid å gi en rimelig utskiftning som passer inn forventet bruk av tidligere tilgjengelig funksjonalitet. Derfor er avskrivningen stort sett ufarlig og krever små bestemmelser til tidligere bruk.

---

## Avvikende stadier

ASF vil følge to avskrekkingsstadier, noe som gjør overgangen mye enklere og mindre problematisk.

### Trinn 1

Trinn 1 skjer etter at den gitte funksjonen er utdatert, med umiddelbar tilgang til en annen løsning (eller ingen dersom det ikke finnes noen planer om å reintrodusere den).

I dette trinnet vil ASF skrive ut passende advarsel når en utdatert funksjon blir brukt. Så lenge det er mulig, vil ASF forsøke å etterligne den gamle oppførselen og fortsette å være kompatibel med den. ASF vil fortsette å være i fase 1 når det gjelder den funksjonaliteten minst til neste stabile versjon. Dette er det øyeblikket når, forhåpentligvis uten å bryte kompatibilitet, kan du gjøre passende bytte i alle verktøy og mønstre for å tilfredsstille ny oppførsel. Du kan bekrefte om du gjorde alle riktige endringer ved å ikke lenger se avskrivningsadvarselen.

### Trinn 2

Trinn 2 er planlagt etter trinn 1 som er forklart over, finner sted og frigjøres i en stabil versjon. Denne fasen introduserer fullstendig fjerning av avskrekket funksjonstilstand, noe som betyr at ASF ikke helt bekrefter at du forsøker å bruke en utdatert funksjon; La det alene respektere, siden det ikke finnes i nåværende kode. ASF skriver ikke lenger ut noen advarsel, siden den ikke lenger forstår hva du prøver å gjøre.

---

## Summary

Du har mer eller mindre en **hele måned** for å foreta en riktig bryter, som bør være mer enn nok selv om du er en uformell ASF-bruker. Etter denne perioden garanterer ASF ikke lenger at gamle innstillinger vil ha effekt (trinn 2), å effektivt gjøre visse funksjoner for å slutte å fungere helt uten at du merker det. Dersom du kaster opp ASF mer enn en måned med inaktivitet, det er anbefalt for deg å starte **[fra begynnelsen av](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** igjen, eller lese alle endringsloggene du har glemt og manuelt tilpasse bruken til nåværende.

I de fleste tilfeller vil avskrivningsadvarsel ikke gjøre generell ASF-funksjonalitet ubrukelig, men heller å falle tilbake til standard atferd (som kan eller ikke samsvare med dine personlige innstillinger).

---

## Eksempel

Vi flyttet pre-V3.1.2.2 `--server` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** inn i `IPC` **[globale konfigurasjonsmuligheter](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**.

### Trinn 1

Trinn 1 skjedde i versjon V3.1.2.2 der vi la passende advarsel til bruk av `- server`. Now-obsolete `--server` argument ble automatisk koblet til `IPC: true` global config property, virker effektivt som det samme som den gamle `-serveren` bryteren for så tid. Dette tillat alle å gjøre en egnet overgang før ASF stopper aksepterer gammelt argument.

### Trinn 2

Trinn 2 skjedde i versjon V3.1.3.0, rett etter V3.1.2.9 stabilt med stadium 1 forklart over. Trinn 2 forårsaket ASF for å stoppe å gjenkjenne `-server` argumentet behandle det som alle andre ugyldige argument som passeres, og som ikke lenger har noen effekt på programmet. For personer som fortsatt ikke endret bruken av `--server` til `IPC: true`, det førte til at IPC slutter å fungere helt, ettersom ASF ikke lenger kunne tilordnes riktig.