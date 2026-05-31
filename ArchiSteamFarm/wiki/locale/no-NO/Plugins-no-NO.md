# Utvidelser

ASF inkluderer støtte for egendefinerte plugins som kan lastes inn under kjøretiden. Programtillegg lar deg tilpasse ASF-atferd, for eksempel ved å legge til egendefinerte kommandoer, egendefinert handelslogikk eller hele integrasjon med tredjepartstjenester og APIer.

Denne siden beskriver ASF-programtillegg fra bruker- forklaring, bruk og lignende. Hvis du vil vise utviklerens perspektiv kan du flytte **[her](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)** i stedet.

---

## Bruk

ASF laster plugins fra `tillegg` mappe, som ligger i ASF-mappen. Det er en anbefalt praksis (som blir obligatorisk med plugin auto-oppdateringer) for å vedlikeholde en egen mappe for hver plugin som du ønsker å bruke, som kan baseres på dets navn, så som `MyPlugin`. Dette vil resultere i den siste trestrukturen til `plugins/MyPlugin`. Til slutt bør alle binære filer i utvidelsen legges inn i den dedikerte mappen, og ASF vil oppdage og bruke utvidelsen etter å ha startet på nytt.

Vanligvis vil pluginutviklere publisere sine plugins som en `zip` -fil med binærfiler inni, hvilket betyr at du skal pakke ut zip-filen til sin egen egen undermappe inne i `programtillegg` mappen.

Hvis utvidelsen ble lastet inn, vil du se dens navn og versjon i loggen. Du bør kontakte pluginutviklerne ved spørsmål, problemer eller bruk relatert til programtilleggene som du har bestemt å bruke.

Du kan finne noen utvalgte plugins i vår **[tredjeparts](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** del.

**Vær oppmerksom på at ASF plugins kan være skadelig**. Du bør alltid forsikre deg om at du bruker plugins laget av utviklere at du kan stole på, selv de fra tredjeparts delen over. ASF-utviklere kan ikke lenger garantere deg vanlige ASF-fordeler (for eksempel mangel på ødeleggende programvare eller være VAC-gratis) hvis du bestemmer deg for å bruke egendefinerte tillegg. Du må forstå at plugins har full kontroll over ASF-prosessen når de er lastet, på grunn av at vi heller ikke kan støtte oppsett som bruker egendefinerte plugins, siden du ikke lenger kjører standard ASF kode.

---

## Kompatibilitet

Avhengig av plugins kompleksitet, omfang og mange andre faktorer, det er helt mulig at det krever fra deg for å bruke **[generisk](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** ASF-variant, i stedet for vanligvis anbefalt **[OS-specific](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. Det er fordi OS-spesifikk variant bare kommer med kjernefunksjonalitet som er nødvendig for selve ASF, og utvidelsen din krever kanskje deler som faller utenfor hovedomfanget av ASF, noe som kan resultere i at trimmet OS-spesifikke bygninger ikke er kompatibel.

Ved bruk av pluginer fra tredjepart anbefaler vi å bruke ASF-generisk variant for maksimal kompatibilitet. Men ikke alle plugins kan kreve den - vennligst referer til din plugins informasjon for å finne ut om du trenger generisk ASF-variant eller ikke.

---


## Automatiske oppdateringer

ASF har innebygd mekanisme for auto-oppdateringer. For at den funksjonen skal fungere, først og fremst må utvidelsen din velge **[støtte](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)** mekanismen. Hvis du har lastet en plugin som støtter auto-oppdateringer, vil ASF statusere den i loggen på egnet måte under plugin initialisering, som "plugin er deaktivert fra automatiske oppdateringer" eller "plugin har blitt registrert og aktivert for automatiske oppdateringer".

Som standard er automatisk oppdatering av egendefinerte programtillegg **deaktivert**, av sikkerhetsgrunner. Du kan konfigurere automatiske oppdateringer i konfigurasjonen ved å bruke **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** og/eller **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)**, vi anbefaler å lese beskrivelse av disse konfigurasjonsegenskapene for mer info. Det er også fint å merke seg at du, som ved hjelp av ASF-oppdateringer, kan du velge å holde automatiske oppdateringer deaktivert, og deretter oppdatere når du trenger, manuell basis med utstedelse av `updateplugins` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

Begge framgangsmåtene lar deg oppdatere ingen, noen eller alle egendefinerte plugins som du har lastet inn i prosessen.