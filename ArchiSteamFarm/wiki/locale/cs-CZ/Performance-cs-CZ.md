# Výkon

Prvořadým cílem ASF je co nejefektivnější zemědělský podnik, na základě dvou typů dat, na kterých může fungovat - malý soubor uživatelsky poskytovaných dat, který ASF nemůže odhadnout/ověřit sama, a větší soubor údajů, které může ASF automaticky zkontrolovat.

V automatickém režimu vám ASF neumožňuje vybrat si hry, které by měly být farmařeny, ani neumožňuje měnit algoritmus pro chov kart. **ASF ví lépe než vy, co by měl dělat a jaká rozhodnutí by měla učinit, aby zemědělské podniky co nejrychleji**. Vaším cílem je správně nastavit vlastnosti konfigurace, protože ASF je nemůže uhodnout sama, vše ostatní je pokryto.

---

Před časem Valve změnil algoritmus pro zrušení karty. Od tohoto bodu můžeme rozdělit Steam účty do dvou kategorií: tyto **s** kapkami karty omezeny, a **bez**. The only difference between those two types is the fact that accounts with restricted card drops can't get any card from given game until they play given game for at least `X` hours. Zdá se, že starší účty, které nikdy nepožádaly o vrácení platby, mají **neomezené karetní kapky**, zatímco nové účty a ti, kteří požádali o vrácení daně, mají **omezené karty**. To je však jen teorie a nemělo by se považovat za pravidlo. To je důvod, proč **není žádná zřejmá odpověď**, a ASF se spoléhá na **jste** a oznamujete, který případ je vhodný pro váš účet.

---

ASF v současné době zahrnuje dva zemědělské algoritmy:

**`Jednoduchý`** algoritmus funguje nejlépe pro účty, které mají neomezené kapky karty. Toto je primární algoritmus používaný ASF. Bot najde partie na farmě a farmí je jeden po druhém, dokud se neupustí všechny karty. Je to proto, že počet karet klesá, když se farmení více než jedna hra blíží nule a je naprosto neúčinná.

**`Complex`** je nový algoritmus, který byl implementován s cílem pomoci omezeným účtům maximalizovat jejich zisky. ASF nejprve použije standardní **`Jednoduchý`** algoritmus na všech hrách, které prošly `HoursUntilCardDrops` hodin playtime, pak pokud nezůstanou žádné hry s >= `HoursUntilCardDrops` hodin, bude farmařit všechny hry (až do limitu `32` ) s < `HoursUntilCardDrops` hodin zbývá současně, dokud některý z nich nezasáhne `HoursUntilCardDrops` hodin, pak ASF bude pokračovat ve smyčce od začátku (použijte **`Jednoduchý`** na této hře, vrátit se k současnému na < `HoursUntilCardDrops` a tak dále). V tomto případě můžeme použít více herních farem na dobu her, které potřebujeme, aby bylo nejprve dosaženo odpovídající hodnoty. Mějte na paměti, že během doby chovu není zemědělská karta ASF **** , takže také nebude během tohoto období kontrolovat žádné karetní kapky (z výše uvedených důvodů.

V současné době ASF vybírá algoritmus pro chov karet čistě na základě `HoursUntilCardDrops` vlastnosti konfigurace (kterou nastavíte **jste**). Pokud `HoursUntilCardDrops` je nastaveno na `0`V opačném případě bude použit algoritmus **`Jednoduchý`** , Namísto toho bude použit algoritmus **`složitý`** - nakonfigurován pro výdej ve všech hrách na zadaný počet hodin před obděláváním karet.

---

### **Neexistuje žádná zřejmá odpověď, který algoritmus je pro vás lepší**.

To je jeden z důvodů, proč nevybíráte platební algoritmus, namísto toho řídíte ASF, zda účet má omezení nebo ne. Pokud účet má neomezené kapky, **`Jednoduchý`** algoritmus bude **fungovat lépe** na tomto účtu, protože nebudeme ztrácet čas na přivedení všech her do `X` hodin - poměr propadu karet se blíží 0% při farmení více her. Na druhé straně, pokud je váš účet omezen, **`složitý`** algoritmus bude pro vás lepší, protože není žádný smysl v farmení solo, pokud hra nedosáhla `HoursUntilCardDrops` hodin - takže budeme farmovat **a nejdříve** , **pak** karty v samostatném režimu.

Nenastavovat `HoursUntilCardDrops` pouze proto, že vám někdo řekl - proveď testy, porovnat výsledky a na základě informací, které získáte, rozhodnout, která možnost by měla být pro vás lepší. Pokud na to vynaložíte minimální úsilí, zajistíte, že ASF pracuje s maximální možnou účinností vašeho účtu, což je pravděpodobně to, co chcete, vzhledem k tomu, že právě teď čtete tuto wiki stránku. Pokud by existovalo řešení, které by fungovalo pro všechny, nedostanete možnost volby - ASF by se rozhodl sama.

---

### Jaký je nejlepší způsob, jak zjistit, zda je Váš účet omezen?

Ujistěte se, že máte nějaké hry s **bez nahrávání** pro farmu, pokud možno 5+, a spusťte ASF s `HoursUntilCardDrops` `0`. Bylo by dobré, kdybyste během období zemědělství nic nehráli s přesnějšími výsledky (nejlépe během noci spustit ASF). Nechte ASF chovat těchto 5 her, a poté zkontrolujte log pro výsledky.

ASF jasně uvádí, kdy byla vypuštěna karta pro danou hru. Zajímá vás nejrychlejší kapka karty dosažená aplikací ASF. Například, pokud je váš účet neomezený, mělo by dojít ke zrušení první karty přibližně po 30 minutách od okamžiku, kdy jste začali farmovat. If you notice **at least one** game that did drop card in those initial 30 minutes, then this is an indicator that your account is **not** restricted and should use `HoursUntilCardDrops` of `0`.

Na druhé straně, pokud si všimnete, že **každá** hra trvá alespoň `X` hodiny, než klesne svou první kartu, pak je to indikátor pro vás, na co byste měli nastavit `HoursUntilCardDrops`. Většina (pokud ne všechny) omezených uživatelů vyžaduje alespoň `3` hodiny, po kterých mají být karty staženy, a toto je také výchozí hodnota pro nastavení `HoursUntilCardDrops`.

Nezapomeňte, že hry mohou mít různou míru snížení, proto byste měli vyzkoušet, zda je tvá teorie přímo s **alespoň** 3 hrami, nejlépe 5+, abyste zajistili, že nebudete mít falešné výsledky náhodou. A card drop of one game in less than an hour is a confirmation that your account **is not** restricted and can use `HoursUntilCardDrops` of `0`, but for confirming that your account **is** restricted, you need at least several games that are not dropping cards until you hit a fixed mark.

Je důležité poznamenat, že v minulosti `HoursUntilCardDrops` byl pouze `0` nebo `2`, a proto měla ASF jedinou vlastnost `CardDropsRestricted` , která umožnila přepínat mezi těmito dvěma hodnotami. Při nedávných změnách jsme si všimli, že nejenom většina uživatelů vyžaduje `3` hodiny místo předchozího `2` nyní, ale také, že `HoursUntilCardDrops` je nyní dynamický a může dosáhnout libovolné hodnoty pro každý účet.

Nakonec je samozřejmě na vás.

A aby to bylo ještě horší - zažil jsem případy, kdy lidé přešli z neomezeného stavu a naopak - buď kvůli chybě Steam (oh yeah, máme mnoho z nich, nebo kvůli logickým úpravám ze strany Valve. Takže i když jste potvrdili, že Váš účet je omezen (nebo ne), nevěří, že zůstane jako to - pro přepnutí z neomezeného na omezení stačí požádat o náhradu. Pokud se domníváte, že dříve nastavená hodnota již není vhodná, můžete vždy provést nový test a odpovídajícím způsobem jej aktualizovat.

---

ASF ve výchozím nastavení předpokládá, že `HoursUntilCardDrops` je `3`, jako negativní efekt nastavení na `3` , kdy by mělo být menší než naopak. Je tomu tak proto, že v nejhorším možném případě plýtváme `3` hodinami zemědělství na `32` hry, ve srovnání s plýtváním `3` hodin chovu na každou hru, pokud `HoursUntilCardDrops` byl ve výchozím nastavení nastaven na `0`. Měli byste však tuto proměnnou upravit, aby odpovídala vašemu účtu maximální účinnosti. protože se jedná pouze o slepý odhad, založený na možných nevýhodách a většině uživatelů (proto se ve výchozím nastavení snažíme vybrat "menší zlo").

V současné době jsou dva výše uvedené algoritmy dostatečné pro všechny aktuálně možné scénáře účtu, aby bylo hospodářství co nejúčinnější, není proto plánováno přidat žádné jiné.

Je pěkné si uvědomit, že ASF obsahuje také ruční režim zemědělství, který může být aktivován příkazem `play`. Více o tom si můžete přečíst v **[příkazech](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

## Parní rukavice

Algoritmus přetahování karet ne vždy funguje tak, jak by měl fungovat, a je zcela možné, aby se vyskytly různé závady na Steamu, jako jsou karty shozené z omezených účtů, karty jsou upuštěny při uzavření/přepnutí hry, karty, které se při hraní hry vůbec neshazují, a podobně.

Tato sekce je určena především pro lidi, kteří se zajímají, proč ASF nedělá **X**. například rychlejší přechod her na karty zemědělců.

Co je to **Steam glitch** - specifická akce spuštěná **nedefinovaná** chování, které je **nezamýšlené, nezdokumentované a považované za logickou chybu**. Je **podle definice**nespolehlivý, což znamená, že nelze spolehlivě reprodukovat s čistým testovacím prostředím, a proto kódováno bez použití hacků, které se mají uhodnout, když se děje a jak bojovat s ním / zneužívat. Obvykle je dočasný, dokud vývojáři neopraví logickou chybu, i když některé chybné rukavice mohou zůstat bez povšimnutí na velmi dlouhou dobu.

Dobrým příkladem toho, co se považuje za **Steam glitch** není tak neobvyklá situace, kdy se hra uzavírá, který může být do určité míry zneužit pomocí funkce přeskočení hry v nečinnosti.

- **Nedefinované chování** - nemůžete říct, zda bude vypuštěno 0 nebo 1 karty, když spustíte rukavici.
- **Nezamýšlelo** - na základě zkušeností a chování sítě Steam, která nemá za následek stejné chování při odesílání jediné žádosti.
- **Nezdokumentováno** - je jasně zdokumentováno na stránkách Steamu, jak se získávají karty, a **na každém místě** je jasně uvedeno, že je získáno **hraním**, NENÍ zavřít hry, získat úspěchy, měnit hry nebo spouštět 32 her současně.
- **Považováno za logickou chybu** - uzavírací hra (hry) nebo jejich přepínání by nemělo mít žádný výsledek na vypuštění karet, o kterých se jasně uvádí, že je získáno prostřednictvím **získáním hodnosti**.
- **Nespolehlivá z definice, nemůže být reprodukována spolehlivě** - nefunguje pro všechny, a i kdyby to pro vás jednou fungovalo, nemohl by už podruhé fungovat.

Now once we realized what Steam glitch is, and the fact that cards being dropped when game gets closed **is** one, we can move on to the second point - **ASF is not abusing Steam network in any way by definition, and it's doing its best to comply with Steam ToS, its protocols and what is generally accepted**. Spamingovou síť Steam s konstantními požadavky na otevření/zavření hry lze považovat za **[DoS útok](https://en.wikipedia.org/wiki/Denial-of-service_attack)** a **přímo porušuje [Steam Online Conduct](https://store.steampowered.com/online_conduct/?l=english)**.

> Jako předplatitel Steam souhlasíte s dodržováním následujících pravidel chování.
> 
> Nebudeš:
> 
> Institut útoky na Steam server nebo jinak narušit Steam.

Nezáleží na tom, zda můžete spustit Steam glitch s jinými programy (např. IM), a také nezáleží na tom, zda s námi souhlasíte a zvažujete takové chování, jako je DoS útok, nebo ne - je na Valvu, aby to posoudil, ale pokud to považujeme za vykořisťování/zneužíváním nezamýšleného chování prostřednictvím nadměrných požadavků sítě Steam, pak můžete být docela jistí, že hlavice bude mít podobný pohled na to.

ASF není **nikdy** nebude využívat výhod ze Steamu, zneužívání, hacky nebo jakoukoliv jinou aktivitu, kterou považujeme za **podle Steam ToS nelegální nebo nechtěnou** , Steam Online Conduct nebo jakýkoli jiný důvěryhodný zdroj, který by mohl naznačovat, že aktivita ASF je pro Steam síť nežádoucí, jak je uvedeno v části **[přispívající](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)**.

Pokud chcete za každou cenu riskovat váš Steam účet pro farmení o několik procent karet rychleji než obvykle, bohužel ASF nikdy nenabízí něco podobného v automatickém režimu, i když stále máte `hrát` **[příkaz](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** , který lze použít jako nástroj pro dělání, co chcete, pokud jde o interakci se sítí Steam. Nedoporučujeme využít Steam glitches a využít je k vašemu vlastnímu prospěchu - nejen s ASF, ale také s jakýmkoliv jiným nástrojem. Nakonec je to však váš účet, a vaše rozhodnutí, co s tím chcete dělat - jen mějte na paměti, že jsme vás varovali.