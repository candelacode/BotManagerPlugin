# Deprecation

Vi gör vårt bästa för att följa en konsekvent policy för att göra både utveckling och användning mycket mer konsekvent.

---

## Vad är förhastat?

Deprecation är processen för mindre eller större brytningsförändringar som gör tidigare använda alternativ, argument, funktioner eller användningsfall föråldrade. Deprecation innebär vanligtvis att given sak helt enkelt omskrivits till en annan (liknande) form, och du bör se till i tid att du gör lämplig växling till den. I detta fall är det helt enkelt flytta viss funktionalitet till mer lämplig plats.

ASF förändras snabbt och slår alltid till för att bli bättre. Detta innebär tyvärr att vi kan ändra eller flytta vissa befintliga funktioner till ett annat segment av programmet för att det ska kunna dra nytta av nya funktioner, kompatibilitet eller stabilitet. Tack vare det behöver vi inte hålla oss till föråldrade eller helt enkelt smärtsamt felaktiga utvecklingsbeslut som vi fattade för åratal sedan. Vi försöker alltid ge rimlig ersättning som passar förväntad användning av tidigare tillgänglig funktionalitet, Därför är deprecation oftast ofarlig och kräver små fixar vid tidigare användning.

---

## Avskrivningsstadier

ASF kommer att följa 2 faser av föråldring, vilket gör övergången mycket enklare och mindre besvärlig.

### Steg 1

Steg 1 händer när given funktion blir föråldrad, med omedelbar tillgång till en annan lösning (eller ingen om det inte finns några planer på att återinföra det).

Under detta steg kommer ASF att skriva ut lämplig varning när föråldrad funktion används. Så länge det är möjligt, kommer ASF att försöka efterlikna det gamla beteendet och fortsätta att vara kompatibel med det. ASF kommer att fortsätta att vara i steg 1 avseende denna funktionalitet åtminstone fram till nästa stabila version. Detta är det ögonblick då du, förhoppningsvis utan att bryta kompatibilitet, kan göra lämplig växling i alla dina verktyg och mönster för att tillfredsställa nya beteenden. Du kan bekräfta om du gjorde alla lämpliga ändringar genom att inte längre se avgränsningsvarningen.

### Steg 2

Steg 2 är schemalagd efter steg 1 förklaras ovan äger rum och släpps i en stabil utgåva. Detta steg introducerar fullständig borttagning av föråldrad funktionens existens, vilket innebär att ASF inte ens kommer att erkänna att du försöker använda en föråldrad funktion, för att inte tala om att respektera det, eftersom det helt enkelt inte finns i den nuvarande koden. ASF kommer inte längre skriva ut någon varning, eftersom det inte längre erkänner vad du försöker göra.

---

## Summary

Du har mer eller mindre en **hel månad** för att göra lämplig switch, som bör vara mer än tillräckligt även om du är en avslappnad ASF-användare. Efter den perioden, ASF inte längre garanterar att gamla inställningar kommer att ha någon effekt (steg 2), effektivt göra vissa funktioner för att sluta fungera helt utan att du märker. Om du startar ASF efter mer än en månad av inaktivitet, rekommenderas för dig att **[starta från början](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** igen, eller läs alla ändringsloggar som du har missat och manuellt anpassa din användning till den nuvarande.

I de flesta fall, bortsett från avskrivningar varning kommer inte att göra allmän ASF-funktionalitet oanvändbar, utan snarare faller tillbaka till standardbeteende (som kanske eller kanske inte matchar dina personliga preferenser).

---

## Exempel

Vi flyttade pre-V3.1.2.2 `--server` **[kommandoradsargumentet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** till `IPC` **[global konfigurationsegenskap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**.

### Steg 1

Steg 1 hände i version V3.1.2.2 där vi lade till lämplig varning för användning av `--server`. Nu-föråldrade `--server` argument kartlades automatiskt i `IPC: true` global config egendom, effektivt agerar exakt samma som gamla `--server` switch för tillfället. Detta gjorde det möjligt för alla att göra lämplig växling innan ASF slutar acceptera gamla argument.

### Steg 2

Steg 2 hände i version V3.1.3.0, direkt efter V3.1.2.9 stabil med steg 1 förklarad ovan. Steg 2 fick ASF att sluta känna igen argumentet `--server` alls, behandla det som alla andra ogiltiga argument som passeras, som inte längre har någon effekt på programmet. För personer som fortfarande inte ändrade sin användning av `--server` till `IPC: true`, det fick IPC att sluta fungera helt och hållet, eftersom ASF inte längre gjorde lämplig kartläggning.