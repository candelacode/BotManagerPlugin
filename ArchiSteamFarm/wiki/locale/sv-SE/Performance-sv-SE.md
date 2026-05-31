# Prestanda

ASF:s främsta mål är att bedriva jordbruk så effektivt som möjligt. baserat på två typer av data som kan fungera på - liten uppsättning användardata som är omöjligt för ASF att gissa/kontrollera på egen hand, och större uppsättning data som automatiskt kan kontrolleras av ASF.

I automatiskt läge tillåter ASF inte dig att välja de spel som ska odlas, inte heller tillåter du att byta kort odling algoritm. **ASF vet bättre än du vad den ska göra och vilka beslut den ska fatta för att kunna odla så snabbt som möjligt**. Ditt mål är att ställa in konfigurationsegenskaper ordentligt, eftersom ASF inte kan gissa dem på egen hand, allt annat omfattas.

---

För en tid sedan Valve ändrade algoritmen för kort droppar. Från och med den punkten kan vi kategorisera ångkontona med två kategorier: de **med** kort droppar begränsade, och de **utan**. Den enda skillnaden mellan dessa två typer är det faktum att konton med begränsade kort droppar inte kan få något kort från givet spel förrän de spelar givet spel i minst `X` timmar. Det verkar som om äldre konton som aldrig begärt återbetalning har **obegränsade kort droppar**, medan nya konton och de som bad om återbetalning har **begränsade kort droppar**. Detta är dock bara teori, och bör inte tas som en regel. Det är därför det finns **inget självklart svar**, och ASF förlitar sig på **som du** berättar vilket fall som är lämpligt för ditt konto.

---

ASF innehåller för närvarande två jordbruksalgoritmer:

**`Enkel`** -algoritm fungerar bäst för konton som har obegränsade kortfall. Detta är primär algoritm som används av ASF. Bot hittar spel till gården, och gårdar dem en efter en tills alla kort släpps. Detta beror på att kortet sjunker takt när jordbruket mer än ett spel är nära noll och helt ineffektiv.

**`Complex`** är en ny algoritm som har implementerats för att hjälpa begränsade konton att maximera sina vinster. ASF kommer först att använda standard **`enkel`** algoritm på alla spel som passerade `timmarUntilCardDrops` timmars speltid, då, om inga spel med >= `timmarUntilCardDrops` timmar är kvar, det kommer att odla alla spel (upp till `32` gräns) med < `timmarUntilCardDrops` timmar kvar samtidigt, tills någon av dem träffar `timmarUntilCardDrops` timmar märke, då ASF kommer att fortsätta loopen från början (använd **`Simple`** på det spelet, återgå till samtidig på < `timmarUntilCardDrops` och så vidare). Vi kan använda flera spel jordbruk i detta fall för att stöta timmar av de spel vi behöver för att odla till lämpligt värde först. Tänk på att ASF **under jordbrukstid, inte** bondgårdskort, så att det inte heller kommer att kontrollera några kort droppar under den perioden (av skäl som anges ovan).

För närvarande väljer ASF kortodlingsalgoritm baserad enbart på `HoursUntilCardDrops` config egenskap (som är satt av **du**). Om `timmarUntilCardDrops` är satt till `0`, **`Enkel`** algoritm kommer att användas, annars, **`Complex`** -algoritmen kommer istället att användas - konfigurerad för att stöta på speltid i alla spel till given mängd timmar innan de odlas för kortdroppar.

---

### **Det finns inget självklart svar på vilken algoritm som är bättre för dig**.

Detta är en av anledningarna till varför du inte väljer kort odling algoritm, istället, du berätta ASF om kontot har begränsade droppar eller inte. Om kontot har obegränsade droppar, kommer **`Enkel`** -algoritm **att fungera bättre** på det kontot, eftersom vi inte kommer att slösa tid på att föra alla spel till `X` timmar - kort droppe förhållandet är nära 0% när du odlar flera spel. Å andra sidan, om ditt konto har kort droppar begränsade, **`Complex`** algoritm kommer att vara bättre för dig, eftersom det inte är någon mening med att odla solo om spelet inte nådde `HoursUntilCardDrops` timmar ännu - så vi odlar **lektid** först, **sedan** kort i sololäge.

Ställ inte blint in `timmarUntilCardDrops` bara för att någon berättade för dig att - göra tester, jämföra resultat, och baserat på data du får, bestämma vilket alternativ som ska vara bättre för dig. Om du lägger lite minimal möda på det, kommer du att se till att ASF arbetar med maximal effektivitet för ditt konto, vilket är förmodligen vad du vill, med tanke på att du läser denna wiki-sida just nu. Om det fanns en lösning som fungerar för alla, skulle du inte ges ett val - ASF skulle bestämma sig själv.

---

### Vad är det bästa sättet att ta reda på om ditt konto är begränsat?

Se till att du har några spel med **ingen speltid inspelade** till gården, helst 5+, och kör ASF med `timmarUntilCardDrops` av `0`. Det skulle vara en bra idé om du inte spelade något under jordbruksperioden för mer exakta resultat (bäst att köra ASF under natten). Låt ASF gård dessa 5 spel, och efter det kolla loggen för resultat.

ASF anger tydligt när ett kort för ett visst spel tappades. Du är intresserad av snabbaste kortdroppe som uppnåtts av ASF. Till exempel, om ditt konto är obegränsat bör en första kortdroppe ske efter cirka 30 minuter sedan du började odla. Om du märker **minst ett** spel som släppte kort i dessa inledande 30 minuter, då är detta en indikator på att ditt konto är **inte** begränsat och bör använda `HoursUntilCardDrops` av `0`.

Å andra sidan, om du märker att **varje** spel tar minst `X` antal timmar innan det tappar sitt första kort, då är detta en indikator för dig vad du ska ställa in `timmarUntilCardDrops` till. Majoriteten (om inte alla) av begränsade användare kräver minst `3` timmars speltid för kort att släppa, och detta är också standardvärdet för `TimsUntilCardDrops` inställning.

Kom ihåg att spel kan ha olika fallthastighet, Det är därför du bör testa om din teori är rätt med **minst** 3 spel, helst 5+ för att se till att du inte stöter på falska resultat av en slump. Ett kort droppe av ett spel på mindre än en timme är en bekräftelse på att ditt konto **inte är** begränsat och kan använda `timmarUntilCardDrops` av `0`, men för att bekräfta att ditt konto **är** begränsad, du behöver minst flera spel som inte släpper kort tills du träffar en fast märke.

Det är viktigt att notera att i det förflutna `timmarUntilCardDrops` var bara `0` eller `2`, och det är därför ASF hade en enda `CardDropsBegränsad` egenskap som tillät att växla mellan dessa två värden. Med de senaste ändringarna märkte vi att inte bara majoriteten av användarna kräver `3` timmar i stället för tidigare `2` nu, men också att `HoursUntilCardDrops` är nu dynamisk och kan slå vilket värde som helst på per-konto basis.

I slutändan är det naturligtvis upp till er att fatta beslut.

Och för att göra det ännu värre - jag upplevde fall när människor bytte från begränsat till obegränsat tillstånd och vice versa - antingen på grund av Steam bugg (åh ja, vi har många av dem), eller på grund av vissa logiska justeringar av ventil. Så även om du bekräftat att ditt konto är begränsat (eller inte), tro inte att det kommer att förbli så - för att växla från obegränsad till begränsad är det tillräckligt för att be om återbetalning. Om du känner att tidigare inställt värde inte längre är lämpligt, kan du alltid göra ett nytt test och uppdatera det därefter.

---

Som standard, ASF antar att `TimsUntilCardDrops` är `3`, som den negativa effekten av att sätta detta till `3` när det ska vara mindre är mindre än gjort åt andra hållet. Detta beror på att, i värsta möjliga fall, kommer vi slösa `3` timmar jordbruk per `32` spel, jämfört med att slösa `3` timmar jordbruk per varje enskilt spel om `timmarUntilCardDrops` sattes till `0` som standard. Du bör dock fortfarande justera denna variabel för att matcha ditt konto för maximal effektivitet, eftersom detta bara är en blind gissning baserad på potentiella nackdelar och majoriteten av användarna (så vi försöker att välja "mindre onda" som standard).

För närvarande är två ovanstående algoritmer tillräckligt för alla nuvarande möjliga kontoscenarier, För att odla så effektivt som möjligt, därför är det inte planerat att lägga till några andra.

Det är trevligt att notera att ASF även innehåller manuellt odlingsläge som kan aktiveras av kommandot `play`. Du kan läsa mer om det i kommandona **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

## Ånga buggar

Kortets droppalgoritm fungerar inte alltid som den ska, och det är helt möjligt att olika Steam-buggar inträffar, som att kort tappas på begränsade konton, kort som tappas vid stängning/växling av spelet, kort inte släppa alls när spelet spelas, och likaså.

Detta avsnitt är främst för personer som undrar varför ASF inte gör **X**, såsom snabbt byta spel till bondgårdskort snabbare.

Vad är ett **Steam glitch** - en specifik åtgärd som utlöser **odefinierat** -beteende, vilket är **inte avsett, papperslöst, och betraktas som en logisk brist**. Det är **opålitliga per definition**, vilket innebär att det inte kan reproduceras tillförlitligt med ren testmiljö, och därför, kodas utan att tillgripa hacks som är tänkt att gissa när glitch händer och hur man slåss med det / missbruka det. Vanligtvis är det tillfälligt tills utvecklare åtgärda logiken brist, även om vissa misc buggar kan gå obemärkt förbi under en mycket lång tid.

Ett bra exempel på vad som anses vara ett **Steam-glitch** är inte den ovanliga situationen att släppa ett kort när spelet stängs, som kan missbrukas i viss mån med sysslolös masters spel hoppa funktion.

- **Odefinierat beteende** - du kan inte säga om det kommer att finnas 0 eller 1 kort som tappas när du utlöser buggen.
- **Inte avsedd** - baserat på tidigare erfarenhet och beteende i Steam-nätverket som inte resulterar i samma beteende när du skickar en enda begäran.
- **Odokumenterat** - det är tydligt dokumenterat på Steams webbplats hur kort erhålls, och **på varenda plats** är det tydligt att det erhålls genom att **spelar**, Inte stänga spel, få prestationer, spel växla eller lansera 32 spel samtidigt.
- **Anses som en logisk brist** - stänga spel (er) eller byta dem bör inte ha något resultat på kort som släpps som tydligt anges att erhållas genom **få speltid**.
- **Otillförlitliga per definition, kan inte reproduceras tillförlitligt** - det fungerar inte för alla, och även om det fungerade för dig en gång, kunde det inte längre fungera för andra gången.

Nu när vi insåg vad Steam glitch är, och det faktum att kort som släpps när spelet stängs **är** en, vi kan gå vidare till den andra punkten - **ASF missbrukar inte Steam-nätverket på något sätt per definition, och det gör sitt bästa för att följa Steam ToS, dess protokoll och vad som är allmänt accepterat**. Spamming Steam network with constant game opening/closing requests can be considered a **[DoS-attack](https://en.wikipedia.org/wiki/Denial-of-service_attack)** and **directly violates [Steam Online Conduct](https://store.steampowered.com/online_conduct/?l=english)**.

> Som Steam-prenumerant samtycker du till att följa följande uppföranderegler.
> 
> Du kommer inte:
> 
> Institute attackerar mot en Steam-server eller på annat sätt störa Steam.

Det spelar ingen roll om du kan utlösa Steam-buggar med andra program (t.ex. IM), och det spelar ingen roll om du håller med oss och överväga sådant beteende som DoS attack, eller inte - det är upp till Valve att bedöma detta, men om vi anser att det är utnyttjande/missbrukande av icke-avsedda beteenden genom överdrivna förfrågningar från Steam-nätverk, då kan du vara ganska säker på att ventilen kommer att ha liknande syn på detta.

ASF är **aldrig** kommer att dra nytta av Steam bedrifter, missbruk, hacks eller någon annan aktivitet som vi ser som **olaglig eller oönskad** enligt Steam ToS, Steam Online Conduct eller någon annan betrodd källa som kan tyda på att ASF-aktivitet är oönskad av Steam-nätverket, som anges i **[bidrar](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)** avsnitt.

Om du till varje pris vill riskera ditt Steam-konto för att odla några cent kort snabbare än vanligt, då tyvärr ASF aldrig kommer att erbjuda något liknande detta i automatiskt läge, även om du fortfarande har `play` **[-kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** som kan användas som ett verktyg för att göra vad du vill när det gäller Steam-nätverksinteraktion. Vi rekommenderar inte att dra nytta av Steam-buggar och utnyttja dem för din egen vinning - inte bara med ASF, men med något annat verktyg också. I slutändan är det dock ditt konto, och ditt val vad du vill göra med det - tänk bara på att vi varnade dig.