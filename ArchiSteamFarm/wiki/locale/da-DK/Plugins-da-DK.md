# Plugins

ASF inkluderer understøttelse af brugerdefinerede plugins, der kan indlæses under runtime. Plugins giver dig mulighed for at tilpasse ASF adfærd, for eksempel ved at tilføje brugerdefinerede kommandoer, brugerdefineret handel logik eller hele integration med tredjeparts tjenester og API'er.

Denne side beskriver ASF plugins fra brugerne - forklaring, brug og ligeledes. Hvis du ønsker at se udviklerens perspektiv, flyt **[her](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)** i stedet.

---

## Brug

ASF indlæser plugins fra `plugins` mappe placeret i din ASF mappe. Det er en anbefalet praksis (som bliver obligatorisk med plugin auto-opdateringer) for at opretholde en dedikeret mappe for hvert plugin, du ønsker at bruge, som kan baseres på sit navn, såsom `MyPlugin`. Dette vil resultere i den endelige træstruktur af `plugins/MyPlugin`. Endelig bør alle binære filer i plugin sættes inde at dedikeret mappe, og ASF vil korrekt opdage og bruge dit plugin efter genstart.

Normalt plugin udviklere vil offentliggøre deres plugins i form af en `zip` fil med binære filer indeni, hvilket betyder, at du skal pakke denne zip-fil ud til sin egen dedikerede undermappe inde `plugins` mappe.

Hvis plugin blev indlæst med succes, vil du se dens navn og version i din log. Du bør konsultere dine plugin udviklere i tilfælde af spørgsmål, problemer eller brug relateret til de plugins, du har besluttet at bruge.

Du kan finde nogle fremhævede plugins i vores **[tredjepart](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** sektion.

**Bemærk venligst, at ASF plugins kan være ondsindet**. Du bør altid sikre, at du bruger plugins lavet af udviklere, som du kan stole på, selv dem fra tredjepartssektionen ovenfor. ASF udviklere kan ikke længere garantere dig sædvanlige ASF fordele (såsom mangel på malware eller VAC-fri) hvis du beslutter dig for at bruge brugerdefinerede plugins. Du skal forstå, at plugins har fuld kontrol over ASF-processen, når de er indlæst, på grund af at vi heller ikke kan støtte opsætninger, der udnytter brugerdefinerede plugins, da du ikke længere kører vanilla ASF-kode.

---

## Kompabilitet

Afhængigt af plugin's kompleksitet, omfang og en masse andre faktorer, det er helt muligt, at det vil kræve fra dig at bruge **[generisk](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** ASF variant, i stedet for normalt anbefales **[OS-specifik](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. Dette skyldes, at OS-specifik variant kun kommer med core funktionalitet, der kræves for ASF selv, og dit plugin kan kræve dele, der falder uden for de vigtigste ASF anvendelsesområde, hvilket resulterer i at være uforenelig med afpudset OS-specifikke bygninger.

Generelt, når du bruger tredjeparts-plugins, anbefaler vi at bruge ASF generisk variant for maksimal kompatibilitet. Men ikke alle plugins kan kræve det - henvises til din plugin information for at finde ud af, om du har brug for at bruge generiske ASF variant eller ej.

---


## Automatiske opdateringer

ASF har indbygget mekanisme til plugins auto-opdateringer. For at denne funktion skal fungere, først og fremmest skal dit foretrukne plugin til **[support](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)** denne mekanisme. Hvis du har indlæst et plugin, der understøtter auto-opdateringer, vil ASF angive det i loggen korrekt under plugin initialisering, såsom "plugin er blevet deaktiveret fra automatiske opdateringer" eller "plugin er blevet registreret og aktiveret for automatiske opdateringer".

Som standard er automatiske opdateringer for tilpassede plugins **deaktiveret**af sikkerhedsmæssige årsager. Du kan konfigurere automatiske opdateringer i konfigurationen ved at bruge **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** og/eller **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)**, vi anbefaler at læse beskrivelse af disse config egenskaber for mere info. Det er også rart at bemærke, at, ligesom med ASF opdateringer, kan du beslutte at holde automatiske opdateringer deaktiveret, og derefter opdatere på efter behov. manuelt grundlag, ved at udstede `updateplugins` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

Begge tilgange giver dig mulighed for at opdatere ingen, nogle eller alle brugerdefinerede plugins, som du har indlæst i processen.