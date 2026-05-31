# Steam-gezinsbibliotheek

ASF ondersteunt Steam Family Sharing - zowel het oude als het nieuwe systeem. Om te begrijpen hoe ASF daarmee werkt, lees eerst hoe **[Steam Family Sharing werkt](https://store.steampowered.com/promotion/familysharing)**, dat beschikbaar is in Steam store. Naast dat, raadpleeg **[het nieuws](https://store.steampowered.com/news/app/593110/view/4149575031735702628)** voor aankomende nieuwe Steam Family Sharing systeem, waarmee ASF ook compatibel is.

---

## ASF

Ondersteuning voor Steam Family Sharing functie in ASF is transparant, Dit betekent dat het geen nieuwe bot/process configuratie eigenschappen introduceert - het werkt buiten de box als een extra ingebouwde functionaliteit.

ASF bevat de juiste logica om bewust te zijn van het feit dat bibliotheek wordt vergrendeld door gebruikers met familie. Daarom zal het ze niet "kicken" uit de speelsessie gaan omdat ze een spel starten. ASF zal precies hetzelfde doen als bij het vasthouden van de primaire rekening, dus als die slot wordt vastgehouden door de Steam client, of door een van je gebruikers voor gezin, ASF zal niet proberen om een boerderij te starten, maar het zal wachten tot het slot is vrijgegeven. Dit is voornamelijk gerelateerd aan het oude systeem - met een nieuw systeem kunnen je gebruikers die familie delen andere spellen spelen dan die welke ASF momenteel aan het verbouwen is.

Na het inloggen heeft ASF ook toegang tot je systemen voor delen van familie (oud en nieuwe) waaruit het gebruikers (Steam IDs) kan extraheren die je bibliotheek mogen gebruiken. Deze gebruikers krijgen `FamilySharing` toestemming om **[commando's](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**te gebruiken, laat hen toe `pauze~` commando te gebruiken op bot account die spellen deelt met hen, welke het mogelijk maakt om de automatische kaarten-module te pauzeren om een spel te starten dat kan worden gedeeld - dit geldt meestal ook voor het oude systeem. maar kan nog steeds gebruikt worden met het nieuwe systeem in het geval ASF momenteel een landbouwspel is dat je gebruikers willen spelen.

Door het verbinden van beide functionaliteiten zoals hierboven beschreven kunnen je vrienden `pauze~` je kaarten kopen; start een spel, speel zo lang als ze willen, en daarna nadat ze hebben gespeeld, wordt het kookproces automatisch hervat door ASF. Natuurlijk is het uitzenden van `pauze~` niet nodig als ASF momenteel niets actief is. omdat je vrienden het spel direct kunnen lanceren, en logica beschreef hierboven zorgt ervoor dat ze niet uit de sessie worden gezet.

---

## Beperkingen

Het Steam netwerk houdt van misleiding van ASF door het uitzenden van een onjuiste status updates, dit kan ertoe leiden dat ASF denkt dat het goed is om het proces te hervatten, en het zal je vriend te snel kicken. Dit is precies hetzelfde probleem als degene die al door ons is uitgelegd in **[deze FAQ invoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. Wij bevelen precies dezelfde oplossingen aan. vooral je vrienden promoten naar `Operator` toestemming (of hoger) en ze vertellen gebruik te maken van `pauze` en `ga verder met` commando's.