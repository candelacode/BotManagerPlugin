# Tillägg

ASF innehåller stöd för anpassade plugins som kan laddas under körtid. Plugins låter dig anpassa ASF-beteende, till exempel genom att lägga till anpassade kommandon, anpassad handelslogik eller hela integrationen med tredjepartstjänster och API:er.

Denna sida beskriver ASF plugins från användare perspektiv - förklaring, användning och likaså. Om du vill visa utvecklarens perspektiv, flytta **[här](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)** istället.

---

## Användning

ASF laddar plugins från `plugins` katalog som finns i din ASF-mapp. Det är en rekommenderad praxis (som blir obligatorisk med plugin auto-uppdateringar) för att upprätthålla en dedikerad katalog för varje plugin som du vill använda, som kan baseras på dess namn, såsom `MyPlugin`. Att göra det kommer att resultera i den slutliga trädstrukturen av `plugins/MyPlugin`. Slutligen, alla binära filer i plugin bör läggas inuti den dedikerade mappen, och ASF kommer att upptäcka och använda din plugin ordentligt efter omstart.

Vanligtvis kommer plugin utvecklare publicera sina plugins i form av en `zip` fil med binärer inuti, vilket innebär att du bör packa upp den zip-filen till sin egen dedikerade underkatalog inuti `plugins` katalog.

Om insticksprogrammet lästes in, kommer du att se dess namn och version i din logg. Du bör konsultera dina plugin utvecklare vid frågor, frågor eller användning i samband med de plugins som du har beslutat att använda.

Du kan hitta några utvalda plugins i vår **[tredje part](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** avsnitt.

**Observera att ASF plugins kan vara skadliga**. Du bör alltid se till att du använder plugins som gjorts av utvecklare som du kan lita på, även de från tredje part avsnittet ovan. ASF-utvecklare kan inte längre garantera dig vanliga ASF fördelar (såsom brist på skadlig kod eller vara VAC-fri) om du väljer att använda några anpassade plugins. Du måste förstå att plugins har full kontroll över ASF-processen när laddad, På grund av detta kan vi inte heller stödja inställningar som använder anpassade plugins, eftersom du inte längre kör vanilj ASF-kod.

---

## Kompatibilitet

Beroende på plugins komplexitet, omfattning och en hel del andra faktorer, det är helt möjligt att det kommer att kräva av dig att använda **[generisk](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** ASF variant, istället för att rekommendera **[OS-specifika](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. Detta beror på att OS-specifik variant endast levereras med kärnfunktionalitet som krävs för ASF själv, och din plugin kan kräva delar som faller utanför huvudsakliga ASF omfattning, vilket resulterar i att inkompatibel med trimmade OS-specifika byggnader.

I allmänhet, när du använder tredjepartsplugins, rekommenderar vi att du använder ASF generisk variant för maximal kompatibilitet. Men inte alla plugins kan kräva det - hänvisas till din plugins information för att ta reda på om du behöver använda generisk ASF-variant eller inte.

---


## Automatiska uppdateringar

ASF har inbyggd mekanism för plugins automatiska uppdateringar. För att funktionen ska fungera, först och främst, din plugin val måste **[stöd](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)** den mekanismen. Om du har laddat en plugin som stöder automatiska uppdateringar, ASF kommer att ange det i loggen på lämpligt sätt under plugin initiering, till exempel "plugin har inaktiverats från automatiska uppdateringar" eller "plugin har registrerats och aktiverats för automatiska uppdateringar".

Som standard är automatiska uppdateringar för anpassade plugins **inaktiverade**, på grund av säkerhetsskäl. Du kan konfigurera automatiska uppdateringar i konfigurationen genom att använda **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** och/eller **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)**, vi rekommenderar att läsa beskrivning av dessa konfigurationsegenskaper för mer info. Det är också trevligt att notera att, som med ASF-uppdateringar, du kan välja att hålla automatiska uppdateringar inaktiverade, och sedan uppdatera om vid behov, manuell bas, genom att utfärda `updateplugins` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

Båda tillvägagångssätten tillåter dig att uppdatera ingen, några eller alla anpassade plugins som du har laddat in i processen.