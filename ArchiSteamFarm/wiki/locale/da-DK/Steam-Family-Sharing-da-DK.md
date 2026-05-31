# Steam-familiedeling

ASF understøtter Steam Family Sharing - det gamle såvel som det nye system. For at forstå, hvordan ASF fungerer med det, du bør først læse, hvordan **[Steam Family Sharing fungerer](https://store.steampowered.com/promotion/familysharing)**, som er tilgængelig i Steam-butikken. Derudover skal du tjekke **[nyheder](https://store.steampowered.com/news/app/593110/view/4149575031735702628)** for kommende nye Steam-familie-delingssystem, som ASF også er kompatibel med.

---

## ASF

Støtte til Steam-familie-deling i ASF er gennemsigtig, hvilket betyder, at det ikke introducerer nogen nye bot/proces config egenskaber - det virker ud af boksen som en ekstra indbygget funktionalitet.

ASF indeholder passende logik for at være opmærksom på biblioteket, der låses af brugere til deling af familier. derfor vil det ikke "kick" dem ud af at spille session på grund af lanceringen af et spil. ASF vil handle præcis det samme som med primær konto holder låsen, derfor, hvis denne lås holdes enten af din damp-klient, eller af en af dine familie delingsbrugere, ASF vil ikke forsøge at gårde, i stedet vil den vente på, at låsen bliver frigivet. Dette er for det meste relateret til det gamle system - nyt system giver din familie deling brugere til at spille andre spil end dem, ASF er i øjeblikket landbrug.

Ud over ovenstående, efter at have logget ind, vil ASF få adgang til dine familie delingssystemer (gamle og nye) hvorfra det vil udtrække brugere (Steam IDs) tilladelse til at bruge dit bibliotek. Disse brugere får `FamilySharing` tilladelse til at bruge **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, især tillader dem at bruge `pause~` kommando på bot konto, der deler spil med dem, som gør det muligt at pause automatisk kort landbrug modul for at starte et spil, der kan deles - det gælder også for det gamle system, men kan stadig bruges med det nye system i tilfælde ASF er i øjeblikket landbrug spil, som dine brugere ønsker at spille.

Tilslutning af begge funktioner beskrevet ovenfor giver dine venner til `pause~` dine kort landbrugsproces, starte et spil, så længe de ønsker, og derefter efter at de er færdig med at spille, vil kortene landbrugsprocessen automatisk blive genoptaget af ASF. Selvfølgelig er det ikke nødvendigt at udstede `pause~` hvis ASF i øjeblikket ikke dyrker noget aktivt, fordi dine venner kan starte spillet med det samme, og logik beskrevet ovenfor sikrer, at de ikke vil blive smidt ud af sessionen.

---

## Begrænsninger

Steam-netværket elsker at vildlede ASF ved at sende falske statusopdateringer hvilket kan føre til ASF tro det er fint at genoptage processen, og i resultatet sparke din ven for tidligt. Dette er præcis det samme problem som det, vi allerede har forklaret i **[denne FAQ post](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. Vi anbefaler præcis de samme løsninger, hovedsageligt fremme dine venner til `operatør` tilladelse (eller ovenfor) og fortælle dem at gøre brug af `pause` og `genoptage` kommandoer.