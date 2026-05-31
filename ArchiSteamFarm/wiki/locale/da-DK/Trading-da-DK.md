# Bytning

ASF understøtter ikke-interaktive (offline) Steam-handler. Både modtagelse (accepter/afvisende) samt afsendelse handler er tilgængelig med det samme og kræver ikke særlig konfiguration, men naturligvis kræver ubegrænset Steam-konto (det der brugte 5$ i butikken allerede). Kun begrænset handelsfunktionalitet er tilgængelig for begrænsede konti.

---

## Logik

Først og fremmest er det muligt at deaktivere **alle** indgående handel tilbud ved hjælp af `DisableIncomingTradesParsing` flag i `BotBehaviour`. Ved hjælp af det, som navnet antyder, vil deaktivere alle funktioner relateret til indgående handler parsing, som omfatter nedenstående standard logik, samt alle ekstra funktioner til rådighed, som afhænger af at reagere på den indgående handel tilbud. Da standardindstillinger allerede er ikke-påtrængende, du bør kun overveje at bruge denne mulighed, hvis du har absolut ingen hensigt fra ASF til at gøre noget i forbindelse med de indgående handler overhovedet.

Nedenstående forklarer logik, når indgående handel tilbyder parsing er aktiveret, hvilket er standardindstillingen.

ASF vil altid acceptere alle handler, uanset genstande, sendt fra brugeren med `Master` (eller højere) adgang til boten. Dette tillader ikke kun let plyndring damp kort opdrættet af bot instansen, men også giver mulighed for nemt at administrere Steam-genstande, som bot stashes i beholdningen - herunder dem fra andre spil (såsom CS:GO).

ASF vil afvise handelstilbud uanset indhold, fra enhver (ikke-master) bruger, der er sortlistet fra handelsmodul. Sortliste er gemt i standard `BotName. b` -database, og kan administreres via `tb`, `tbadd` og `tbrm` **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Dette bør fungere som et alternativ til standard brugerblok, der tilbydes af Steam - brug med forsigtighed.

ASF vil acceptere alle `loot`-lignende handler sendes på tværs af bots, medmindre `DontAcceptBotTrades` er specificeret i `TradingPreferences`. Kort sagt, standard `TradingPreferences` af `Ingen` vil få ASF til automatisk at acceptere handler fra brugeren med `Master` adgang til botten (forklaret ovenfor) samt alle donation handler fra andre robotter, der deltager i ASF proces.

Når du aktiverer `AcceptDonations` i dine `TradingPreferences`, ASF vil også acceptere enhver donation handel - en handel, hvor bot konto ikke mister nogen genstande. Denne egenskab påvirker kun ikke-bot-konti, da bot-konti påvirkes af `DontAcceptBotTrades`. `AcceptDonations` giver dig mulighed for nemt at acceptere donationer fra andre personer, og også bots, der ikke deltager i ASF-processen.

Det er rart at bemærke, at `AcceptDonations` ikke kræver **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, da der ikke er behov for bekræftelse, hvis vi ikke mister nogen elementer.

Du kan også yderligere tilpasse ASF handel kapaciteter ved at ændre `TradingPreferences` i overensstemmelse hermed. En af de vigtigste `TradingPreferences` funktioner er `SteamTradeMatcher` -muligheden, som vil få ASF til at bruge indbygget logik til at acceptere handler, der hjælper dig med at fuldføre manglende badges, som er særligt nyttigt i samarbejde med offentlig liste af **[SteamTradeMatcher](https://www.steamtradematcher.com)**, men kan også arbejde uden det. Det er yderligere beskrevet nedenfor.

---

## `SteamTradeMatcher`

Når `SteamTradeMatcher` er aktiv, ASF vil bruge ganske kompleks algoritme til at kontrollere, om handelen passerer STM regler og er i det mindste neutral over for os. Den faktiske logik er følgende:

- Afvis handlen, hvis vi mister alt andet end varetyper specificeret i vores `MatchableTypes`.
- Afvis handlen, hvis vi ikke modtager mindst det samme antal elementer på per-spil, per-type og per-rarity basis.
- Afvis handlen, hvis brugeren beder om særlige Steam-sommer/vinter-salgskort, og har et handelshold.
- Afvis handlen, hvis handlen holdbarhed varighed overstiger `MaxTradeHoldVarighed` global config egenskab.
- Afvis handlen, hvis vi ikke har `MatchEverything` sat, og det er værre end neutralt for os.
- Accepter handlen, hvis vi ikke afviser det gennem nogen af ovenstående punkter.

Det er rart at bemærke, at ASF også understøtter overbetale - logikken vil fungere korrekt, når brugeren tilføjer noget ekstra til handlen, så længe alle ovennævnte betingelser er opfyldt.

Første 4 afviser forudsigelser bør være indlysende for alle. Den sidste omfatter faktisk dupes logik, der kontrollerer den aktuelle status for vores opgørelse og beslutter, hvad der er handelens status.

- Handel er **god** hvis vores fremskridt mod at sætte færdiggørelsesfremskridt. Eksempel: A (før) -> A B (efter)
- Handel er **neutral** hvis vores fremskridt mod en fastsat færdiggørelse forbliver i takt. Eksempel: A B (før) -> A C (efter)
- Handel er **dårlig** hvis vores fremskridt i retning af at indstille færdiggørelsen falder. Eksempel: A C (før) -> A (efter)

STM opererer kun på gode handler, hvilket betyder, at brugeren bruger STM til dupes matching altid bør foreslå kun gode handler for os. ASF er imidlertid liberal, og det accepterer også neutrale handler, fordi i disse handler vi faktisk ikke mister noget, så der er ingen reel grund til at afvise dem. Dette er især nyttigt for dine venner, da de kan bytte dine overdrevne kort uden at bruge STM overhovedet. så længe du ikke mister nogen sæt fremskridt.

Som standard vil ASF afvise dårlige handler - dette er næsten altid hvad du ønsker som bruger. Men du kan eventuelt aktivere `MatchEverything` i din `TradingPreferences` for at få ASF til at acceptere alle dupe handler, inklusive **dårlige**. Dette er kun nyttigt, hvis du ønsker at køre en 1:1 handel bot under din konto, som du forstår, at **ASF ikke længere vil hjælpe dig med fremskridt mod badge færdiggørelse, og gør dig tilbøjelig til at miste hele færdige sæt til N dupes af samme kort**. Hvis du bevidst ønsker at køre en trade bot, der er **aldrig** formodes at afslutte et sæt, og bør tilbyde hele sin inventar til enhver interesseret bruger, så kan du aktivere denne mulighed.

Uanset om du har valgt `TradingPreferences`, betyder en handel, der afvises af ASF, ikke, at du ikke kan acceptere den selv. Hvis du har bevaret standardværdien af `BotBehaviour`, som ikke indeholder `RejectInvalidTrades`, ASF vil bare ignorere disse handler - så du kan beslutte, om du er interesseret i dem eller ej. Samme gælder for handler med genstande uden for `MatchableTypes`, samt alt andet - modulet formodes at hjælpe dig med at automatisere STM handler, ikke beslutte, hvad der er en god handel, og hvad der ikke er. Den eneste undtagelse fra denne regel er, når du taler om brugere, som du sortlistede fra handelsmodulet ved hjælp af kommandoen `tbadd` - handler fra disse brugere afvises med det samme uanset `BotBehaviour` indstillinger.

Det anbefales stærkt at bruge **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** , når du aktiverer denne indstilling, da denne funktion mister hele sit potentiale, hvis du beslutter dig for manuelt at bekræfte hver handel. `SteamTradeMatcher` vil fungere korrekt, selv uden evne til at bekræfte handler, men det kan generere efterslæb af bekræftelser, hvis du ikke accepterer dem i tide.