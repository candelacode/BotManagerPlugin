# Verouderde functies

We doen ons best om een consequent deprecancatiebeleid te volgen om zowel de ontwikkeling als het gebruik veel consequenter te maken.

---

## Wat is deprecation?

Aflossing is het proces van kleinere of grotere brekende veranderingen die eerder gebruikte opties, argumenten, functionaliteiten of gevallen van gebruik verouderd maken. Afhalen betekent meestal dat iets anders simpelweg in een andere (gelijkaardig) vorm is herschreven en je moet er tijdig voor zorgen dat je de juiste omschakeling maakt. In dit geval verplaats je simpelweg de functionaliteit naar een geschiktere plaats.

ASF verandert snel en maakt zich altijd sterk om beter te worden. Dit betekent helaas dat we bestaande functionaliteit kunnen veranderen of verplaatsen naar een ander segment van het programma zodat het kan profiteren van nieuwe functies, compatibiliteit of stabiliteit. Daardoor hoeven we niet te blijven vasthouden aan achterhaalde of simpelweg pijnlijke verkeerde beslissingen over ontwikkeling, zoals we jaren geleden hebben genomen. We proberen altijd om een redelijke vervanging te bieden die past bij het verwachte gebruik van de eerder beschikbare functionaliteit, Daarom is deprecation meestal onschadelijk en vereist het kleine aanpassingen aan het vorige gebruik.

---

## Afhaalfasen

ASF volgt 2 stappen van afremming en maakt de overgang veel gemakkelijker en minder lastig.

### Niveau 1

Fase 1 gebeurt wanneer een bepaalde functie niet meer wordt ondersteund, met de onmiddellijke beschikbaarheid van een andere oplossing (of geen plan als er geen plannen zijn om deze opnieuw in te voeren).

In deze fase zal ASF de juiste waarschuwing afdrukken wanneer verouderde functie wordt gebruikt. Zo lang mogelijk zal ASF proberen het oude gedrag te imiteren en er compatibel mee te blijven. ASF zal ten minste tot de volgende stabiele versie in fase 1 blijven. Dit is het moment waarop u, hopelijk zonder de compatibiliteit te verstoren, passende schakelaar in al uw gereedschappen en patronen kunt maken om te voldoen aan nieuw gedrag. U kunt bevestigen of u alle relevante wijzigingen hebt doorgevoerd door de waarschuwing voor afbraak niet meer te zien.

### Niveau 2

Fase 2 staat gepland nadat fase 1 is uitgelegd, vindt plaats en wordt vrijgegeven in een stabiele release. Deze fase introduceert volledige verwijdering van verouderde functie, wat betekent dat ASF niet eens zal erkennen dat je een verouderde functie probeert te gebruiken, laat het respecteren, omdat het gewoon niet bestaat in de huidige code. ASF zal geen waarschuwing meer afdrukken, omdat het niet meer herkent wat je probeert te doen.

---

## Summary

Je hebt min of meer een **volledige maand** om op de juiste manier om te wisselen, wat meer dan genoeg zou moeten zijn, zelfs als je een tijdelijke ASF-gebruiker bent. Na die periode garandeert ASF niet meer dat oude instellingen effect hebben (fase 2), Het effectief maken van bepaalde functies om te stoppen met functioneren zonder dat u dit opmerkt. Als je ASF opstart na meer dan een maand van inactiviteit, Het wordt aanbevolen om **[opnieuw te starten vanaf het begin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** of lees alle changelogs die je hebt gemist en pas deze handmatig aan op de huidige.

In de meeste gevallen zal het niet gebruiken van de algemene ASF-functionaliteit niet onbruikbaar worden als je geen voorafgaande waarschuwing geeft maar liever terug vallen op het standaardgedrag (wat al dan niet overeenkomt met uw persoonlijke voorkeuren).

---

## Voorbeeld

We hebben het pre-V3.1.2.2 `--server` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** verplaatst naar `IPC` **[algemene configuratie eigenschap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**.

### Niveau 1

Fase 1 gebeurde in versie V3.1.2.2 waar we de juiste waarschuwing hebben toegevoegd voor het gebruik van `--server`. Het argument `--server` werd automatisch toegewezen aan `IPC: true` global config property, werkt precies hetzelfde als de oude `--server` wissel. Dit stelt iedereen in staat om de juiste schakelaar te doen voordat ASF stopt met het accepteren van oude argumenten.

### Niveau 2

Fase 2 gebeurde in versie V3.1.3.0, direct na V3.1.2.9 stal met fase 1 hierboven uitgelegd. Fase 2 heeft ervoor gezorgd dat ASF het argument `--server` niet meer herkende, Het wordt behandeld als alle andere ongeldige argumenten die worden aangevoerd, wat geen enkel effect meer heeft op het programma. Voor mensen die hun gebruik van `--server` niet hebben veranderd naar `IPC: true`, het zorgde ervoor dat IPC helemaal niet meer functioneerde, omdat ASF niet langer de juiste kaarten in kaart bracht.