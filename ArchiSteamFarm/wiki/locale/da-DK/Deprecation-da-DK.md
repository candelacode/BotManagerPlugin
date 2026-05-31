# Udfasning

Vi gør vores bedste for at følge konsekvent udfasningspolitik for at gøre både udvikling og brug langt mere konsekvent.

---

## Hvad er udfasning?

Deprecation er processen med mindre eller større bryde ændringer, der gør tidligere anvendte muligheder, argumenter, funktionaliteter eller brugstilfælde forældet. Deprecation normalt betyder, at given ting blev simpelthen omskrevet til en anden (lignende) form, og du bør sikre rettidigt, at du foretager passende skift til det. I dette tilfælde er det simpelthen flytte givet funktionalitet til mere passende sted.

ASF ændrer sig hurtigt og slår altid til for at blive bedre. Dette betyder desværre, at vi kan ændre eller flytte nogle eksisterende funktioner ind i et andet segment af programmet, for at det kan drage fordel af nye funktioner, kompatibilitet eller stabilitet. Takket være at vi ikke behøver at holde os til forældede eller simpelthen smerteligt forkerte udviklingsbeslutninger, som vi traf for år siden. Vi forsøger altid at levere en rimelig erstatning, der passer til forventet brug af tidligere tilgængelig funktionalitet, hvilket er grunden til deprecation er for det meste harmløs og kræver små rettelser til tidligere brug.

---

## Afskrivningsfaser

ASF vil følge 2 faser af deprecation, hvilket gør overgangen meget lettere og mindre generende.

### Trin 1

Fase 1 sker, når given funktion bliver udfaset, med umiddelbar tilgængelighed af en anden løsning (eller ingen, hvis der ikke er planer om at genindføre det).

I denne fase vil ASF udskrive passende advarsel, når forældet funktion anvendes. Så længe det er muligt, vil ASF forsøge at efterligne den gamle adfærd og blive ved med at være kompatibel med den. ASF vil blive ved med at være i fase 1 vedrørende denne funktionalitet i det mindste indtil næste stabile version. Dette er det øjeblik, hvor du forhåbentlig uden at bryde kompatibilitet, kan gøre passende skifte i alle dine værktøjer og mønstre for at tilfredsstille ny adfærd. Du kan bekræfte, om du gjorde alle passende ændringer ved ikke længere at se forældelsesadvarslen.

### Trin 2

Fase 2 er planlagt efter fase 1 forklaret ovenfor finder sted og bliver frigivet i en stabil udgivelse. Denne fase introducerer fuldstændig fjernelse af forældet funktion eksistens, hvilket betyder, at ASF ikke engang vil anerkende, at du forsøger at bruge en forældet funktion, endsige respektere det, da det simpelthen ikke eksisterer i den aktuelle kode. ASF vil ikke længere udskrive nogen advarsel, da den ikke længere genkender, hvad du forsøger at gøre.

---

## Summary

Du har mere eller mindre en **fuld måned** for at foretage passende kontakt, som bør være mere end nok, selvom du er en afslappet ASF bruger. Efter denne periode garanterer ASF ikke længere, at gamle indstillinger vil have nogen virkning (trin 2) effektivt at gøre visse funktioner til at stoppe med at fungere helt uden du bemærker. Hvis du starter ASF efter mere end en måneds inaktivitet, det anbefales for dig at **[starte fra bunden](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** igen, eller læse alle de changelogs, du har savnet og manuelt tilpasse din brug til den aktuelle.

I de fleste tilfælde vil en tilsidesættelse af forældelsesadvarsel ikke gøre den generelle ASF-funktionalitet ubrugelig. men snarere falder tilbage til standard adfærd (som måske eller måske ikke matcher dine personlige indstillinger).

---

## Eksempel

Vi flyttede pre-V3.1.2.2 `--server` **[kommandolinje argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** til `IPC` **[global konfiguration ejendom](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**.

### Trin 1

Trin 1 skete i version V3.1.2.2, hvor vi tilføjede passende advarsel til brugen af `--server`. Nu-forældet `--server` argument blev automatisk kortlagt til `IPC: true` global config property, effektivt at handle præcis det samme som gamle `--server` switch for tiden bliver. Dette gjorde det muligt for alle at foretage passende kontakt, før ASF ophører med at acceptere gamle argumenter.

### Trin 2

Trin 2 skete i version V3.1.3.0, lige efter V3.1.2.9 stabil med fase 1 forklaret ovenfor. Trin 2 forårsagede, at ASF holdt op med at genkende `--server` argumentet overhovedet. behandle det som alle andre ugyldige argumenter, der passeres, som ikke længere har nogen effekt på programmet. For folk, der stadig ikke har ændret deres brug af `--server` i `IPC: true`, det forårsagede, at IPC holdt op med at fungere helt, da ASF ikke længere gjorde passende kortlægning.