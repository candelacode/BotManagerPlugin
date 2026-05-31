# Často kladené otázky

Toto FAQ obsahuje odpovědi na obyklé otázky. Pro méně obvyklé dotazy navštivte **[rozšířené FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ)**.

# Obsah

* [Obecné](#general)
* [Srovnání s podobnými nástroji](#comparison-with-similar-tools)
* [Bezpečnost / Soukromí / VAC / Bany / Podmínky užití](#security--privacy--vac--bans--tos)
* [Různé](#misc)
* [Problémy](#issues)

---

## Obecné

### Co je ASF?
### Proč program tvrdí, že na mém účtu není nic k farmení?
### Proč ASF nedetekuje všechny mé hry?
### Proč je můj účet omezený?

Dříve než se pokusíte pochopit, co je ASF, měli byste se ujistit, že rozumíte tomu, co jsou Steam karty a jak je získat, což je dobře popsáno v oficiálním FAQ **[zde](https://steamcommunity.com/tradingcards/faq)**.

Ve zkratce, Steam karty jsou sbíratelné položky, které můžete získat při vlastnictví konkrétní hry a mohou být použity pro výrobu odznaků, prodej na komunitním trhu služby Steam, nebo jakýkoliv jiný účel.

Zde jsou opět uvedeny hlavní body, protože lidé obecně s nimi nechtějí souhlasit a raději předstírají, že tito lidé neexistují:

- **Musíte být vlastníkem hry, abyste byl způsobilý pro získání karet. Rodinné sdílení není vlastnictví a nepočítá.**
- **Vaše hra nemůže být označena jako [soukromý](https://help.steampowered.com/faqs/view/1150-C06F-4D62-4966), ASF bude během farmování automaticky přeskočit.**
- **Nemůžete farmit hru donekonečna, každá hra má pevně stanovený počet karet, který lze získat. Jakmile opustíte všechny (přibližně polovina celé sady), hra již není kandidátem na zemědělství. Nezáleží na tom, zda jste prodali, obchodovali, vyrobili nebo zapomněli, co se stalo s kartami, které jste obdrželi, jakmile dojdete z karet, hra je dokončena.**
- **Z F2P her nelze stahovat karty bez utrácení peněz. To znamená trvale F2P hry jako Team Fortress 2 nebo Dota 2. Vlastnictví F2P her vám neumožňuje karetní kapky.**
- **Na [omezených účtech](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)nemůžete ukládat karty bez ohledu na vlastněné hry a způsob jejich aktivace.**
- **Placené hry, které jste získali zdarma během akce nemůže být farmové pro karetní kapky, bez ohledu na to, co se zobrazí na stránce obchodu.**

Jak vidíte, Steam karty jsou vám udělovány za hraní hry, kterou jste si koupili, nebo F2P hra, do které jste vložili peníze. Pokud hrajete takovou hru dostatečně dlouho, všechny karty pro tuto hru se nakonec propadnou do tvého inventáře, můžete vyplnit odznak (po získání zbývající poloviny sady), prodat je, nebo dělat cokoliv jiného chcete.

Teď, když jsme vysvětlili základy Steamu, můžeme vysvětlit ASF. Samotný program je docela složitý pochopit úplně, takže místo kopání do všech technických detailů, budeme nabízet velmi zjednodušené vysvětlení níže.

ASF se přihlašují do vašeho Steam účtu prostřednictvím naší vestavěné a vlastní implementace Steam klienta pomocí zadaných údajů. Po úspěšném přihlášení analyzuje vaše **[odznaky](https://steamcommunity.com/my/badges)** k nalezení her, které jsou dostupné pro farmení (`X` zbývá). Po analýze všech stránek a sestavení konečného seznamu dostupných her si ASF zvolí nejúčinnější zemědělský algoritmus a zahájí proces. Tento proces závisí na zvoleném zemědělském algoritmu **[karet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** , ale obvykle spočívá v hraní způsobilé hry a periodicky (plus při každém propadu) kontrole, zda je již plně farmová zvěř - pokud ano, Systém ASF může pokračovat s dalším názvem, a to stejným postupem, dokud nebudou všechny hry plně obhospodařovány.

Mějte na paměti, že výše uvedené vysvětlení je zjednodušené a nepopisuje desítky dalších funkcí a funkcí, které ASF nabízí. Navštivte zbytek **[naší wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki)** , pokud chcete znát všechny detaily ASF. Snažil jsem se dostatečně snadno pochopit pro všechny, aniž bych přinesl technické detaily - pokročilí uživatelé jsou povzbuzováni k hlubšímu kopání.

Nyní jako program - ASF nabízí kouzelné kouzlo. Za prvé, nemusí stahovat žádný z vašich herních souborů, může okamžitě hrát hry. Zadruhé je zcela nezávislý na vašem normálním Steam klientovi - nemusíte mít klienta Steam běh nebo dokonce ani nainstalován. Za třetí, je to automatizované řešení - což znamená, že ASF dělá automaticky vše za zády, aniž by bylo třeba říkat, co dělat - což vás ušetří a čas. Konečně nemusí trick Steam síť pomocí emulace procesu (např. Idle Master používá), protože s ní může komunikovat přímo. Je také super rychlá a lehká, je úžasným řešením pro každého, kdo chce snadno získat karty bez mnoha problémů - je to zvláště užitečné tím, že se nechá na pozadí a dělá něco jiného, nebo dokonce hraje v offline režimu.

Všechno výše uvedené je hezké, ale ASF má také určitá technická omezení, která jsou prosazována společností Steam - nemůžeme farmařit hry, které nevlastníte, nemůžeme hru farmit navždy, abychom dostali další kapky přes vynucený limit, a když hrajete, nemůžeme farmovat hry. To vše by mělo být "logické", uvážíme-li, jak funguje ASF. ale je hezké si uvědomit, že ASF nemá supervelmoc a nebude dělat něco, co je fyzicky nemožné, abyste to měli na paměti - je to v podstatě totéž, jako kdybyste někomu řekli, aby se přihlásil na svůj účet z jiného PC a z těchto her pro vás.

Takže shrnout - ASF je program, který vám pomůže vyhodit karty, na které máte nárok, bez mnoha potíží. Nabízí také několik dalších funkcí, ale pojďme se držet této funkce.

---

### Musím dát přihlašovací údaje k účtu?

**ano**. ASF vyžaduje vaše přihlašovací údaje k účtu stejně jako oficiální Steam klient, protože používá stejnou metodu pro interakci se sítí Steam. To však neznamená, že musíte vložit přihlašovací údaje k účtu do ASF konfigurací, můžete nadále používat ASF s prázdným `SteamLogin` a/nebo `SteamPassword`, a vložte údaje o každém systému ASF, pokud je to požadováno (stejně jako několik dalších přihlašovacích údajů, odkazují na konfiguraci). Tímto způsobem nejsou vaše údaje nikde uloženy, ale ASF samozřejmě nemůže automaticky spustit bez vaší pomoci. ASF také nabízí několik dalších způsobů, jak zvýšit vaši **[bezpečnost](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**, takže neváhejte přečíst si tu část wiki, pokud jste pokročilý uživatel. Pokud ne, nechcete vkládat přihlašovací údaje k účtu do ASF konfigurací, pak to prostě neudělat, a místo toho je vložte jako potřebné, když o ně požádá ASF.

Mějte na paměti, že nástroj ASF je pro vaše osobní použití a vaše přihlašovací údaje nikdy neopouštějí váš počítač. Nesdílíte je také s nikým, který naplňuje **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** - velmi důležitou věc, na kterou mnoho lidí zapomíná. Neposíláš své údaje na naše servery nebo na některé třetí strany, pouze přímo na servery Steam provozované společností Valve. Vaše přihlašovací údaje neznáme a také je nemůžeme obnovit, bez ohledu na to, zda je vložíte do vašich konfigurací, či nikoli.

---

### Jak dlouho musím čekat na to, až budou karty obdrženy?

**Pokud to bude trvat** - vážně. Každá hra má různé potíže se zemědělstvím, které nastavil vývojář/vydavatel, a je zcela na nich, jak rychle jsou karty shazovány. Většina her následuje po 1 kapce za 30 minut hraní, ale existují také hry, které od vás vyžadují hrát ještě několik hodin před vypuštěním karty. Kromě toho by váš účet mohl být omezen na příjem karet z her, které jste ještě nehráli na dost času, jak je uvedeno v oddíle **[výkon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Nepokoušejte se hádat, jak dlouho by měl ASF zemědělsky udělený název - není na vás, ani na ASF rozhodovat. Není nic, co byste mohli udělat pro to, aby to bylo rychlejší, a neexistuje žádný "bug" související s kartami, které nejsou vypuštěny včas - nekontrolujete proces stahování karet, ani ASF. V nejlepším případě dostanete v průměru 1 kapku za 30 minut. V nejhorším případě nebudete dostávat žádnou kartu ani po dobu 4 hodin od zahájení aplikace ASF. Obě tyto situace jsou běžné a jsou zahrnuty v naší sekci **[výkon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**.

---

### Farmení trvá příliš dlouho, mohu ho nějakým způsobem urychlit?

Jediná věc, která silně ovlivňuje rychlost zemědělství, je zvolena **[karetní algoritmus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** pro instanci vašeho bota. Všechno ostatní má zanedbatelný vliv a neurychlí zemědělství, zatímco některé akce, jako je několikanásobné spuštění procesu ASF, dokonce **zhorší**. Máte-li skutečně nátlak na každou vteřinu ze zemědělského procesu, pak ASF umožňuje jemně doladit některé základní proměnné jako `FarmingDelay` - všechny jsou vysvětleny v **[konfiguraci](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Jak jsem však řekl, dopad je zanedbatelný, a výběr vhodného algoritmu pro chov karet pro daný účet je jednou a jedinou klíčovou volbou, která může výrazně ovlivnit rychlost chovu, Všechno ostatní je čistě kosmetické. Namísto obav z rychlosti zemědělství, Stačí spustit ASF a nechat to dělat svou práci - mohu vás ujistit, že to dělá tím nejúčinnějším způsobem, s nímž bych mohl přijít. Čím méně vám záleží, tím více budete spokojeni.

---

### Ale ASF řekl, že farmin si vyžádá asi X čas!

ASF vám dává hrubou aproximaci na základě počtu karet, které potřebujete odstranit, a zvolený algoritmus - toto není ani zdaleka nejblíže skutečnému času, který budete trávit na farmách, která je obvykle delší, protože ASF předpokládá pouze nejlepší případ a ignoruje všechny dotazy sítě Steam, připojení k internetu, přetížení Steam serverů a podobně. Mělo by se na ně pohlížet pouze jako na obecný ukazatel, jak dlouho můžete očekávat, že bude zemědělský systém ASF prováděn, velmi často v nejlepším případě, neboť skutečný čas se bude lišit, a to i v některých případech výrazně. Jak je uvedeno výše, nesnažte se odhadnout, jak dlouho bude hra farmařena, není na vás, ani na ASF rozhodnout.

---

### Může ASF fungovat na mém androidu/chytrém telefonu?

ASF je program C# který vyžaduje funkční implementaci .NET. Android se stal platnou platformou počínaje .NET 6. , ale v současné době existuje velký blokátor v aplikaci ASF kvůli absenci ASP **[. ET runtime je k dispozici na](https://github.com/dotnet/aspnetcore/issues/35077)**. I když nativní možnost není k dispozici, existují vhodné a funkční verze pro GNU/Linux na architektuře ARM, takže je naprosto možné použít něco jako **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** pro instalaci Linuxu, poté v linuxovém chrootu jako obvykle používáte ASF.

When/If all ASF requirements are goed, we will consider releasing a official Android build.

---

### Může ASF farmit předměty ze Steamových her, jako je CS:GO nebo Unturned?

**č.**, je proti **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** a Valve jasně prohlásily, že s poslední vlnou komunitních zákazů pro chov TF2 položek. ASF je program pařížské karty, ne farmář herních předmětů - nemá žádnou schopnost položky farmové zvěře, a není plánováno přidávat tuto funkci do budoucna, zejména kvůli porušování podmínek používání Steamu. Prosím, neptejte se na toto - to nejlepší je nahlášení od nějakého slaného uživatele a máte problémy. Totéž platí pro všechny ostatní druhy zemědělské činnosti, jako je například pokles produkce z oblasti CS:GO vysílání. ASF se zaměřuje výhradně na karty pro obchodování se Steamem.

---

### Mohu si vybrat, které hry by měly být prozíravé?

**Ano**, několika různými způsoby. Pokud chcete změnit výchozí pořadí ve frontě, pak na to lze použít `FarmingOrders` **[konfigurační vlastnost bota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**. Pokud chcete ručně psané hry před automatickým farmařením, můžete použít nečinnou černou listinu, která je k dispozici s `fb` **[příkazem](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Pokud chcete farmit všechno, ale dát některým aplikacím přednost před vším ostatním, na to lze použít frontu nečinných priorit s `fq` **[příkazem](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. A konečně, pokud chcete pouze farmit specifické hry dle vašeho výběru, pak můžete vyhlásit `FarmityQueueOnly` v **[`FarmingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)** aby toho bylo dosaženo, společně s přidáním vybraných aplikací do fronty priorit.

Kromě řízení modulu automatického chovu karet, který byl popsán výše, můžete také přepnout ASF na ruční zemědělský režim s `play` **[příkazem](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, nebo použijte některá další různá externí nastavení jako `GamesPlayedWhileIdle` **[konfigurační vlastnost bota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

---

### Nemám zájem o kapky karet, chtěl bych místo toho farmářský čas hrát, je to možné?

Ano, ASF vám to umožňuje alespoň několika způsoby.

Nejlepší způsob, jak toho dosáhnout, je využít **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** konfigurační vlastnosti, která bude hrát vaše vybrané aplikace ID, když ASF nemá žádné karty pro farmě. Pokud chcete hrát své hry neustále, i když máte karty z jiných her, pak ji můžete kombinovat s **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**aby aplikace ASF zachovala pouze ty hry pro kapky karet, které výslovně zadáte, nebo **[`FarmingPausedByDefault`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**což způsobí, že modul zemědělské karty bude pozastaven, dokud jej nepozastavíte sami.

You can also make use of the **[`play`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#commands-1)** command, which will cause ASF to play your selected games. Ale mějte na paměti, že `play` by měl být použit pouze pro hry, které chcete hrát dočasně, protože se nejedná o trvalý stav, což způsobuje návrat ASF zpět do výchozího stavu. . při odpojení od sítě Steam. Proto vám doporučujeme použít `GamesPlayedWhileIdle`, pokud opravdu nechcete spustit vybrané hry jen na krátkou dobu, a pak se vrátit zpět k obecnému toku.

---

### Jsem uživatel Linux / macOS a bude mít ASF farmové hry, které nejsou dostupné pro můj OS? Bude ASF farma 64-bitové hry, když ji spustím na 32-bitovém OS?

Ano, ASF se ani neobtěžuje stahováním vlastních herních souborů, takže bude fungovat se všemi vašimi licencemi vázanými na váš Steam účet, bez ohledu na platformu nebo technické požadavky. Mělo by také fungovat pro hry vázané na konkrétní region (hry uzamčené regionem), i když nejste v odpovídající oblasti, I když to nezaručujeme (naposledy jsme se pokusili).

---

## Srovnání s podobnými nástroji

---

### Je ASF podobný jako Idle Master?

Jediná podobnost je obecný účel obou programů, kterými je farmení her na Steamu, aby bylo možné přijímat karetní kapky. Všechno ostatní, včetně skutečné zemědělské metody, struktury programu, funkčnosti, kompatibility, použitých algoritmů, zejména samotného zdrojového kódu, je zcela odlišný a tyto dva programy nemají nic společného mezi sebou, dokonce i základní základy - PI běží na . ET Framework, ASF on .NET (Core). ASF byl vytvořen k řešení problémů IM, které nebyly možné vyřešit jednoduchou editací kódu - proto byl ASF napsán od nuly, bez použití jediného kódu nebo dokonce obecné myšlenky od PI, protože tento kodex a tyto myšlenky byly zcela chybné. IM a ASF jsou jako Windows a Linux - obojí jsou operační systémy a obě mohou být nainstalovány ve vašem PC, ale spolu s sebou téměř nic nesdílí, kromě toho, že slouží podobnému účelu.

To je také důvod, proč byste neměli porovnávat ASF s PI na základě očekávání PI. ASF a IM byste měli považovat za zcela nezávislé programy s jejich výhradními sadami funkcí. Některá z nich se opravdu překrývají a můžete najít konkrétní rys v obou z nich, ale velmi zřídka, neboť ASF slouží svému účelu s naprosto odlišným přístupem ve srovnání s MM.

---

### Je vhodné použít ASF, pokud v současné době používám Idle Master a funguje to v pořádku?

**ano**. ASF is much more reliable and includes many built-in functions that are **crucial** regardless of the way how you farm, that IM simply doesn't offer.

ASF má správnou logiku pro **neuvolněné hry** - IM se pokusí farmit hry, které mají karty již přidány, i když ještě nebyly vydány. Samozřejmě není možné tyto hry farmit až do data vydání, takže váš zemědělský proces bude zaseknut. To vyžaduje, abyste ji buď přidali na černou listinu, počkali na vydání nebo přeskočili ručně. Ani jedno z těchto řešení není dobré a všechny vyžadují vaši pozornost - ASF automaticky přeskočí farmování neuvolněných her (dočasně), a vrací se zpět později, když jsou, zcela se vyhýbají problému a řeší jej efektivně.

ASF má také správnou logiku **sérií** videí. Na Steamu je mnoho videí, které mají karty, ale přesto jsou oznámeny s nesprávným `appID` na stránce s odznaky, jako **[Double Fine Dobrodružný](https://store.steampowered.com/app/402590)** - IM bude falešně farmařit špatné `appID`které nezpůsobí žádné kapky a proces se zasekne. Znovu budeš potřebovat buď tuto černou listinu, nebo přeskočit ručně, obojí vyžaduje vaši pozornost. ASF automaticky objevuje správné `appID` pro zemědělství, což má za následek kapky karty.

Kromě toho ASF je **mnohem stabilnější a spolehlivější** pokud jde o problémy se sítí a dotazy Steamu - funguje většinou a vůbec nevyžaduje vaši pozornost, jakmile je nastavena, I když se PI často rozbije pro mnoho lidí, vyžaduje další opravy, nebo prostě nefunguje bezohledně. Je také plně závislý na Vašem Steam klientovi, což znamená, že nemůže fungovat, když váš Steam klient zažívá vážné problémy. ASF funguje správně, pokud se může připojit k síti Steam a nevyžaduje ani instalaci klienta.

To jsou 3 **velmi důležité** body, proč byste měli zvážit použití ASF, protože mají přímý vliv na všechny farmářské karty Steam a neexistuje způsob, jak říct "to se nebere v úvahu", od té doby, co se údržba a dotazy na Steamu dějí všem. Existují desítky dalších méně a důležitější důvodů, o kterých se můžete dozvědět ve zbytku FAQ. Takže krátce řečeno, **ano**, byste měli použít ASF i v případě, že nepotřebujete žádnou další funkci ASF, která je dostupná ve srovnání s IM.

Kromě toho je PI oficiálně ukončen a v budoucnu se může zcela rozpadnout, aniž by se někdo obtěžoval ji opravit, zvažuje existenci mnohem výkonnějších řešení (nejen ASF). PI již nefunguje pro mnoho lidí a toto číslo pouze stoupá, ne klesá. V první řadě byste se měli vyhnout používání zastaralého softwaru, a to nejen PI, ale i všech ostatních zastaralých programů. Žádný aktivní správce znamená, že nikoho nezajímá, zda funguje, nebo ne, a **Nikdo není odpovědný za jeho funkčnost**která je klíčovou otázkou z hlediska bezpečnosti. Stačí, že dojde ke kritické chybě, která způsobí skutečné problémy infrastruktury Steam - aniž by ji nikdo neopravil, Steam může vydat další zakázanou vlnu, ve které budete zasaženi, aniž byste si byli vědomi toho, že se jedná o problém, jak se již stalo lidem, kteří používají, odhadují, co zastaralá verze ASF.

---

### Jaké zajímavé funkce ASF nabízí Idle Master ne?

To záleží na tom, co pro vás považujete za "zajímavé". Pokud plánujete hospodařit s více účty, pak je odpověď zřejmá, protože ASF vám umožňuje všechny obhospodařovat s jedním nadřazeným řešením, úspora zdrojů, potíží a problematiky kompatibility. Pokud se však na tuto otázku ptáte, s největší pravděpodobností nemáte tuto konkrétní potřebu, Pojďme tedy vyhodnotit další požitky, které se vztahují na jediný účet používaný v ASF.

V první řadě máte některé vestavěné funkce uvedené **[nad](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** , které jsou jádrem pro zemědělství bez ohledu na váš konečný cíl, a velmi často to samo o sobě stačí k tomu, aby bylo možné uvažovat o použití ASF. Ale už víš, takže pojďme se přiblížit zajímavějším funkcím:

- **Můžete farmit offline** (`OnlineStatus` v `Offline` nastavení). Farmení offline umožňuje zcela přeskočit váš herní status Steamu, který vám umožňuje hospodařit s ASF a současně zobrazovat "Online" na Steamu, aniž by si vaši přátelé ani nevšimli, že ASF hraje hru vaším jménem. Toto je vynikající funkce, protože vám umožňuje zůstat online ve vašem Steam klientovi, aniž byste otravovali vaše přátele neustálými změnami hry, nebo je zavádějící, aby si mysleli, že hrajete hru, zatímco ve skutečnosti nejsou. Tento bod sám o sobě stojí za to používat ASF, pokud respektujete své vlastní přátele, ale je to jen začátek. Je také pěkné si uvědomit, že tato funkce nemá nic společného s nastavením ochrany osobních údajů na Steamu - pokud spustíte hru sami, pak se budete správně zobrazovat jako ve hře pro své přátele, takže pouze ASF část je neviditelná a vůbec neovlivní váš účet.

- **Můžete přeskočit vratitelné hry** (`Přeskočit Vratky` v `FarmingPreferences` ) funkci). ASF má vlastní vestavěnou logiku pro vratitelné hry a můžete konfigurovat ASF tak, aby se nedařilo platit hry automaticky. To vám umožní vyhodnotit sami sebe, pokud vaše nově zakoupená hra ze Steam obchodu stála za Vaše peníze. aniž by se ASF snažila zrušit karty co nejdříve. Pokud ho hrajete po dobu 2 hodin nebo 2 týdny od svého nákupu, pak ASF bude pokračovat v této hře, protože již není vratná. Do té doby máte plnou kontrolu, zda se vám to líbí nebo ne, a můžete je v případě potřeby snadno vrátit, aniž by musela ručně zakázat tuto hru nebo nepoužívat ASF po celou dobu trvání.

- **Můžete přeskočit nehrané hry** (`Přeskočit UnplayedGames` v `FarmingPreferences` ) funkci). ASF má správnou vestavěnou logiku pro hodiny her a můžete nastavit ASF tak, aby nevytvářel nehrané hry automaticky. Díky tomu si můžete ovládat hry, které hrajete a farma, aniž byste museli všechny hry, které hrajete, ručně černou listinu nebo zcela přeskočit pomocí aplikace ASF.

- **Můžete automaticky označit nové položky jako přijaté** (`BotBehaviour` z `DismissInventoryNotifications` ) funkce). Farmení s ASF povede k tomu, že váš účet dostane nové karty. Již víte, že k tomu dojde, tak dejte ASF jasně najevo zbytečné oznámení pro vás, zajistit, aby vás upozornily jen důležité věci. Samozřejmě, jen pokud chcete.

- **Preferovaný zemědělský pokyn si můžete přizpůsobit s více možnostmi** (`FarmingOrders`). Možná že chcete nejdříve farmit nově zakoupené hry? Nebo ty nejstarší? Podle počtu karet? Úrovně odznaků, které jste již vyrobili? Přehráli jste si hodiny? Abecedně? Podle AppID? Nebo možná úplně náhodně? Je zcela na vás, abyste rozhodli.

- **ASF vám může pomoci dokončit vaše sady** (`TradingPreferences` s funkcí `SteamTradeMatcher`). s trochu pokročilejším tónováním, můžete převést váš ASF na plně funkční uživatelský bot, který automaticky přijme **[STM](https://www.steamtradematcher.com)** nabídky, pomáhá vám každý den ve shodě se sadami bez jakéhokoliv zásahu uživatele. ASF dokonce obsahuje svůj vlastní ASF 2FA modul, který vám umožňuje importovat váš Steam mobilní autentifikátor a umožňuje plně automatizovat celý proces přijetím potvrzení. Nebo, možná chcete přijmout ručně a nechat aplikace ASF připravovat tyto obchody pouze pro vás? To je opět zcela na vás, abyste rozhodli.

- **ASF může použít klíče na pozadí pro** (**[na pozadí hry pro](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** funkce). Možná máte stovku klíčů z různých balíčků, které jste příliš líný na to, abyste se mohli vyplatit, prochází spoustou oken a souhlasí s podmínkami Steamu. Proč nekopírovat váš seznam klíčů do aplikace ASF a nechat tak dělat svou práci? ASF automaticky převede všechny tyto klíče na pozadí, což vám poskytne odpovídající výstup, který vám dá vědět, jak se každý pokus o vyplacení vyvinul. Navíc, pokud máte stovky klíčů, máte zaručeno, že Steam bude dříve či později omezen, a ASF také ví, že bude trpělivě čekat, až limit rychlosti zmizí, a pokračovat tam, kde to zůstalo.

Nyní bychom mohli pokračovat s celým **[ASF wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**, poukazuji na každou jednotlivou vlastnost programu, ale musíme někde nakreslit čáru. Toto je seznam funkcí, které si můžete užít jako uživatel ASF, kde jen jeden z nich by mohl být snadno považován za hlavní důvod, proč se nikdy neohlédnout zpět, a my jsme do seznamu zapsali **hodně** z nich, s ještě více se můžete dozvědět o zbytku naší wiki. Ah ano, a my jsme ani nešli do detailů s věcmi, jako je API ASF, které vám umožňují skriptovat vlastní příkazy, nebo úžasné řízení botů, protože jsme to chtěli ponechat jednoduché.

---

### Je ASF rychlejší než volnoběžné mistrovství?

**Ano**, i když vysvětlení je poměrně složité.

Při každém novém procesu byl spuštěn a ukončen ve vašem systému, Steam klient automaticky odešle požadavek obsahující všechny vaše hry, které právě hrajete - tak může Steam síť počítat hodiny a karty. Steam však počítá váš čas hraný v intervalech 1 sekundy a odeslání nového požadavku obnoví aktuální stav. Jinými slovy, pokud jste spawn/zabil nový proces každých 0,5 vteřiny, nikdy byste neupustili žádnou kartu, protože každých 0. druhý parní klient by odeslal nový požadavek a parní síť by nikdy nepočítala ani 1 sekundu herního času. Navíc vzhledem k tomu, jak operační systém funguje, je ve skutečnosti zcela běžné, že nové procesy jsou vytvářeny/ukončeny bez toho, abyste vůbec dělali cokoliv, takže i když neděláte nic na vašem PC - existuje mnoho procesů stále pracuje na pozadí, tření/ukončení dalších procesů po celou dobu. Idle master je založen na Steam klientovi, takže tento mechanismus vás ovlivní, pokud ho používáte.

ASF není založena na Steam kliente, má vlastní Steam klientovu implementaci. Díky tomu to, co ASF dělá, nevytváří žádný proces, ale ve skutečnosti posílat jednoho, skutečný požadavek na síť par, že jsme začali hrát hru. Toto je stejný požadavek, který by byl odeslán Steam klientem, ale protože máme skutečnou kontrolu nad ASF parním klientem, nepotřebujeme vytvářet nové procesy, a nenapodobujeme Steam klienta, pokud jde o odesílání požadavku na každou změnu procesu, takže výše uvedený mechanismus nás neovlivňuje. Díky tomu jsme nikdy nepřerušovali tento jeden sekundový interval na páře a zvyšovali naši zemědělskou rychlost.

---

### Je však tento rozdíl skutečně patrný?

Ne. Přerušení, která se odehrávají s normálním parním klientem a nečinným mistrem mají zanedbatelný vliv na kapky karty, takže to není žádný patrný rozdíl, který by ASF nadřazil.

However, there **is** a difference, and you can clearly notice that, as depending on how busy your OS is, cards **will** drop faster, from a few seconds to even a few minutes, if you're extremely unlucky. I když bych neuvažoval o používání ASF pouze proto, že to píše karty rychleji, protože ASF i Idle Master jsou ovlivněny tím, jak funguje parní web, ASF pouze účinněji interaguje s steam webem, zatímco Idle Master nedokáže kontrolovat, co dělá Steam klient (není to chyba Idle Mastera, ale samotný klient).

---

### Může ASF farmit více her najednou?

**Ano**, i když ASF ví lépe, kdy tuto funkci používat, na základě vybraného **[karetní algoritmu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Rychlost propadu karet, když se farmení více her blíží nule, proto ASF používá více herních farmářů výhradně po dobu hodin, aby překonala `HoursUntilCardDrops` rychleji, pro hry `32` najednou. To je také důvod, proč byste se měli zaměřit na konfigurační část ASF, a ať algoritmy rozhodnou, co je nejlepší způsob, jak dosáhnout cíle - co si myslíte, že je správné, nemá nutně pravdu ve skutečnosti, zemědělství více her najednou vám neposkytne žádné karetní kapky.

---

### Může ASF rychle přeskočit skrze hry?

**No**, ASF nepodporuje, ani nepodporuje použití **[Steam glitches](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance#steam-glitches)**.

---

### Může ASF automaticky hrát každou hru po dobu X hodin před přidáním karet?

**No**, celý bod změny systému karet Steam bylo bojovat s falešnými statistikami a duchovými hráči. ASF k tomu nebude přispívat více, než je nezbytné, přidávání této funkce není naplánováno a nebude se provádět. Pokud vaše hra obdrží karetní kapky obvyklým způsobem, ASF je obdělá co nejdříve.

---

### Mohu hrát hru, když ASF funguje v zemědělství?

**No**. ASF, unlike some other tools that integrate with your Steam client, has its independent implementation of that client included, and Steam network allows only **one Steam client at a time** to play a game. ASF však můžete kdykoli odpojit tím, že spustíte hru (a po dotazu, zda by se měla síť Steam odpojit od jiného klienta) - ASF bude trpělivě čekat, až budete hrát, a poté pokračujte v procesu. Případně můžete stále hrát v offline režimu, kdykoliv se vám to líbí, pokud je to pro vás uspokojivé.

Nezapomeňte, že pokles rychlosti karet při přehrávání více her je i tak blízko nule, Proto neexistuje žádný přímý prospěch z toho, že by to bylo možné s některými jinými nástroji, Ačkoli existují silné výhody z toho, že nedochází k zásahu do jiných her zahájených s ASF, což je klíčové. . VAC.

---

## Bezpečnost / Soukromí / VAC / Bany / Podmínky užití

---

### Mohu pro toto použití získat zákaz VAC?

Ne, není to možné, protože ASF (na rozdíl od některých jiných nástrojů, jako například Idle Master, SGI nebo SAM) nijak nezasahuje do parního klienta ani do jeho procesů. Je fyzicky nemožné získat VAC zákaz používání ASF, i během přehrávání na zabezpečených serverech během běhu ASF - je to proto, že **ASF nevyžaduje instalaci Steam Clienta na všech** , aby fungoval správně. ASF je jedním z mála zemědělských programů, které v současné době mohou zaručit, že se jedná o VAC.

---

### Může mi používání ASF zabránit v přehrávání na serverech zabezpečených VAC, jak je uvedeno **[zde](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**?

ASF nevyžaduje, aby byl Steam klient spuštěn nebo dokonce vůbec nainstalován. According to this concept, it should **not** cause any VAC-related issues, because ASF guarantees lack of interfering with Steam client and all its processes - this is the main point when talking about VAC-free guarantee that ASF offers.

Podle uživatelů a podle mého nejlepšího vědomí je tomu tak právě teď, protože nikdo při používání ASF nehlásil žádné problémy jako uvedené ve výše uvedeném odkazu. Nepodařilo se nám zopakovat výše uvedený problém s ASF a jasně jej reprodukovat s Idle Master.

Nicméně, mějte na paměti, že ventil by ještě mohl přidat ASF na černou listinu v určitém okamžiku, ale je to naprostý nesmysl, i když to dělají, stále můžete hrát hry zabezpečené VAC ve vašem PC a zároveň používat ASF. . na vašem serveru, takže jsem si docela jistý, že vědí, že ASF by neměl být podezřelý VAC, a nezkomplikují náš život černou listinou ASF z jakéhokoli důvodu. Přesto v nejhorším případě nebudete moci hrát, jak je uvedeno výše, protože ručení ASF bez VAC je stále přítomno bez ohledu na to, zda binární seznam ASF obsahuje Steam blacklisty. nebo ne (a stále můžete spustit ASF na jiném počítači, aniž by byl Steam klient vůbec nainstalován). Právě teď není třeba nic z toho dělat a doufejme, že zůstane takto.

---

### Je to bezpečné?

Pokud se ptáte, zda je ASF bezpečný jako software, což znamená, že váš počítač nezpůsobí žádné poškození, neukrást vaše soukromá data, nainstalovat viry nebo jiné podobné věci - je to bezpečné. ASF je prostý malware, krádeže údajů, těžaři kryptoměn a jakékoli (a všechny) další pochybné chování, které může uživatel považovat za škodlivé nebo nechtěné. Kromě toho máme vyhrazenou sekci **[dálková komunikace](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** , která se týká našich zásad ochrany osobních údajů a ASF chování, které přesahuje to, co jste nakonfigurovali tak, aby jste udělali sami.

Náš kód je open-source, a distribuované binární soubory jsou vždy kompilovány z **[veřejně dostupných zdrojů](https://en.wikipedia.org/wiki/Open-source_software)** **[automatizovanými a důvěryhodnými kontinuálními integračními systémy](https://en.wikipedia.org/wiki/Build_automation)**, a ne ani samotní vývojáři. Každé sestavení je reprodukovatelné sledováním našeho sestavovacího skriptu a výsledkem bude přesně totéž, **[deterministic](https://en.wikipedia.org/wiki/Deterministic_system)** IL (binární) kód. Pokud z jakéhokoli důvodu nedůvěřujete našim budovám, můžete vždy kompilovat a používat ASF ze zdroje, včetně všech knihoven, které ASF používá (např. SteamKit2), které jsou také open-source

Nakonec je to však vždy otázka důvěry pro vývojáře vaší aplikace, takže byste se měli sami rozhodnout, zda považujete program ASF za bezpečný či nikoli, případně podpoříte své rozhodnutí výše uvedenými technickými argumenty. Neuvěřujte něco jen proto, že jsme to řekli - zkontroluj se, protože je to jediný způsob, jak si to zajistit.

---

### Mohu být na to zakázán?

Abychom odpověděli na tuto otázku, měli bychom se blíže podívat na **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Steam ve skutečnosti nezakazuje používání více účtů, **[umožňuje](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)** z toho vyplývá, že můžete použít stejný mobilní autentifikátor na více než jednom účtu. To, co však neumožňuje, je sdílení účtů s ostatními lidmi, ale my to zde neděláme.

Jediným reálným bodem, který považuje ASF za tento:
> Nemůžete používat Cheats, automatický software (bots), mody, hacky nebo žádný jiný neautorizovaný software třetích stran k úpravě nebo automatizaci jakéhokoliv procesu prodeje předplatného.

Otázka zní, co je ve skutečnosti procesem Marketplace v rámci předplatného. Jak můžeme číst:

> Příkladem trhu předplatného je trh komunity Steam

Neupravujeme ani neautomatizujeme předplatné tržiště, pokud prostřednictvím předplatného tržiště rozumíme trhu s párou nebo parním obchodem. Nicméně, ...

> ventil může kdykoli zrušit svůj účet nebo jakékoli konkrétní předplatné, pokud a) ventil přestane poskytovat podobné předplatitele obecně, nebo b) porušujete podmínky této dohody (včetně podmínek pro předplatné nebo pravidel použití).

Proto jako u každého Steam softwaru, ASF není společností Valve autorizován a nemohu zaručit, že nebudete pozastaveni, pokud Valve náhle rozhodne, že zakazují účty pomocí ASF. To je velmi nepravděpodobné vzhledem ke skutečnosti, že ASF se používá na více než několika milionech Steam účtů, od svého prvního vydání, které se stalo před více než 10 lety - ale stále existuje možnost, bez ohledu na skutečnou pravděpodobnost.

Zejména protože:
> Pokud jde o všechny předplatné, obsah a služby, které Valva neautorizuje, Ventil nezobrazuje obsah třetích stran dostupný na Steamu ani z jiných zdrojů. Ventil nepřevezme odpovědnost za tento obsah třetí strany. Některé aplikační software třetích stran může být používán podniky pro obchodní účely - nicméně Tento software můžete získat pouze přes Steam pro soukromé účely.

Hlava však jasně uznává existující "Steam idlers", jak je uvedeno **[zde](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**, takže pokud jste se mě ptal/a Jsem si docela jistý, že pokud by s nimi nebyly v pořádku, udělali by už něco místo toho, aby poukázali na to, že by mohli způsobit problémy VAC. The key word here is **Steam** idlers, for example ASF, and not **game** idlers.

Vezměte prosím na vědomí, že výše je pouze naše interpretace **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** a různé body - ASF jsou licencovány pod Apache 2. Licence, v níž se jasně uvádí:

```
Není-li to vyžadováno platnými právními předpisy nebo dohodnuto písemně, software
distribuovaný na základě licence je distribuován na „BAS“ BASIS,
BEZ ZÁRUKY NEBO PODMÍNKY JAKÉHOKOLI KIND, buď vyjádřené, nebo implicitní.
```

Tento software používáte na vlastní riziko. Je velmi nepravděpodobné, že se vám to podaří zakázat, ale pokud to uděláte, můžete z toho vinit pouze sami sebe.

---

### Byli na to kdokoliv zabanováni?

**Ano**jsme prozatím měli alespoň několik incidentů, které vedly k nějakému druhu Steamova pozastavení. Zda samotná ASF byla hlavní příčinou nebo ne, je zcela jiný příběh, který se pravděpodobně nikdy nedostaneme.

První případ se týkal chlapce s více než 1000+ botů, kteří mají zakázáno obchodování (společně se všemi boty), s největší pravděpodobností v důsledku nadměrného používání `lootu ASF` provedeného na všech botech najednou, nebo jiné podezřelé jednostranné množství obchodů za velmi krátkou dobu.

> Dobrý den, XXX, Děkujeme, že jste kontaktovali podporu Steamu. Vypadá to, že tento účet byl použit ke správě sítě účtů botů. Lití je porušením dohody Steam Subscriber.

Použijte prosím zdravý rozum a nepředpokládejte, že můžete dělat takové bláznivé věci jen proto, že to ASF umožňuje. `loot ASF` na více než 1 k robotům lze snadno považovat za útok **[DDoS](https://en.wikipedia.org/wiki/DDoS)** , Osobně nejsem šokován, že někdo byl na takovou věc zakázán. Udržujte minimální využití služeb Steam a **s největší pravděpodobností** budete v pořádku.

Druhý případ se týkal chlapce se 170+ boty, kteří byli během zimního prodeje v Steamu 2017 zakázáni.

> Váš účet byl zablokován kvůli porušení souhlasu předplatitele Steamu. Soudě podle výměn a dalších faktorů byl tento účet použit k nezákonnému shromažďování sběrných karet na Steamu. stejně jako související a nejen obchodní činnosti. Účet byl trvale zablokován a podpora Steam nemůže v této záležitosti poskytnout další podporu.

Tento případ je opět velmi těžké analyzovat, kvůli mlhavé odpovědi od podpory Steamu, která sotva nabízí žádné podrobnosti. Na základě mých osobních myšlenek si tento uživatel pravděpodobně vyměnil Steam karty za nějaký druh peněz (úroveň nahoru? nebo jiným způsobem se pokusil vyplatit na Steamu. Pokud jste si neuvědomili, je to také nezákonné podle **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Nejsme schopni vám říci, co můžete dělat s obchodními kartami získanými prostřednictvím ASF - ale dotyčný uživatel s nimi rozhodně jen nevyráběl odznaky.

Třetí případ uživatele s 120+ boty je zakázán kvůli porušení **[Steam online chování](https://store.steampowered.com/online_conduct?l=english)**.

> Dobrý den, XXX, Děkujeme, že jste kontaktovali podporu Steamu. Toto a další účty byly použity k zaplavení naší síťové infrastruktury, což je porušení internetového chování Steamu. Účet byl trvale zablokován a podpora Steam nemůže v této záležitosti poskytnout další podporu.

Tento případ je o něco snazší analyzovat kvůli dalším podrobnostem poskytnutým uživatelem. Zdá se, že uživatel používal **velmi zastaralou ASF verzi** , která obsahovala chybu způsobující odesílání nadměrného počtu požadavků na Steam servery. Samotná chyba nejprve neexistovala, ale byla aktivována kvůli rozbité změně Steamu, která byla opravena v budoucí verzi. **ASF je podporován pouze v [nejnovější stabilní verzi](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) na GitHub**.

Nemůžete předpokládat, že některá zastaralá verze ASF bude fungovat stejně, jako kdysi fungovala navždy, zejména proto, že se Steam neustále mění bez ohledu na to, zda se vám to líbí, nebo ne. Pokud se něco stane globálně, je rychle upraveno a uvolněno pro všechny uživatele jako oprava chyby. Z našich nebo jejich omylů nebude Valve náhle zabanovat více než milion uživatelů ASF, a to ze zřejmých důvodů. Pokud se však úmyslně vzdáte používání aktuálního ASF, pak podle definice jste ve velmi malé menšině uživatelů, kteří jsou **vystaveni incidentům, jako je tato** , protože **není podporována**protože nikdo nesleduje vaši zastaralou verzi aplikace ASF, Nikdo to neopraví a nikdo nezajistí, že nebudete mít přímý zákaz tím, že ho spustíte. **Prosím použijte aktuální software**, nejen ASF, ale i všechny ostatní aplikace.

Nejnovější případ se podle uživatele stal přibližně v červnu 2021

> Pomocí vašeho programu jsem vytvořil balíčky pro booster s 28 účty po dobu 3 let a se 128 účty za posledních 6 měsíců. Byl jsem online s maximálně 15 účty současně, abych vytvořil booster balíčky a poslal je na hlavní účet. Minulý měsíc jsem současně zvýšil počet internetových účtů na 20 a jeden týden poté, co byly všechny mé účty zakázány. Tento e-mail vám naopak nepřičítá vinu a byl jsem si vždy vědom důsledků. Chtěl jsem, abyste věděli, jaké chování má za následek trvalý zákaz.

Je těžké říci, zda zvýšení souběžných účtů online bylo přímým důvodem zákazu, Nepočítal bych s tím místo toho se domnívám, že hlavním viníkem byl pouze počet účtů, zvýšená konměna online účtů pravděpodobně jen upozornila na daného uživatele, protože měl zjevně mnohem více botů než naše doporučení.

---

Všechny výše uvedené incidenty mají jednu společnou věc - ASF je jen nástroj a je to **vaše** rozhodnutí, jak ho využijete. Nemáte zakázáno používat ASF přímo, ale pro **jak** jej používáte. Může se jednat o pomocný nástroj pro zemědělství pouze jednoho účtu, nebo o rozsáhlou zemědělskou síť z tisíců botů. V každém případě nenabízím právní poradenství a měli byste se nejprve rozhodnout o využití ASF. Neskrývám žádné informace, které by vám mohly pomoct, např. skutečnost, že ASF dostal zákaz některých lidí (a v jakém kontextu), protože nemám žádný důvod - je to vaše volba, co chcete s těmito informacemi dělat.

If you ask me - use some common sense, avoid owning more bots than our recommendation, do not send hundreds of trades at the same time, always use up-to-date ASF version and you _should_ be fine. Každý jednotlivý incident tohoto druhu pro **důvod** se vždy stal lidem, kteří naše doporučení ignorovali, osvědčené postupy a návrhy, které jsou přesvědčeny, že vědí lépe než my. . kolik robotů může běžet. Zda je to jen náhoda, nebo nějaký skutečný faktor, je na vás, abyste rozhodli. Nenabízíme žádné právní rady, pouze vám poskytujeme naše myšlenky, které můžete považovat za užitečné, nebo je neberou v úvahu zcela a působí pouze na základě výše uvedených skutečností.

---

### Jaké informace o soukromí ASF zveřejní?

Podrobné vysvětlení najdete v sekci **[pro vzdálenou komunikaci](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. Měli byste to zkontrolovat, pokud máte zájem o vaše soukromí, například pokud se zajímáte, proč se účty používané v ASF připojují k naší skupině Steam. ASF neshromažďuje žádné citlivé informace a nesdílí je s žádnými třetími stranami.

---

## Různé

---

### Používám nepodporované OS jako 32-bit Windows, mohu stále používat nejnovější verzi ASF?

Ano, a tato verze není v žádném případě nepodporována, prostě ne oficiálně sestavena. Podívejte se na **[kompatibilitu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** pro generickou variantu. ASF nemá žádnou silnou závislost na OS, a může fungovat kdekoli, kde můžete pracovat . ET runtime, což zahrnuje 32bitové Windows, i když od nás neexistuje žádný balíček `pro win-x86`.

---

### ASF je skvělé! Mohu poskytnout příspěvek?

Ano, a jsme velmi rádi, že se vám náš projekt líbí! Různé možnosti daru naleznete v každé verzi **[](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** a také **[na hlavní stránce](https://github.com/JustArchiNET/ArchiSteamFarm)**. Je hezké si uvědomit, že kromě obecných peněz přijímáme i položky Steamu, takže vám nic nebrání darovat kůže, klíče nebo malou část karet, které jste farmovali s ASF, pokud chcete. Předem děkujeme za vaši štědrost!

---

### Používám PIN rodičů Steamu, abych chránil svůj účet, potřebuji ho někde vložit?

Ano, musíte nastavit `SteamParentalCode` konfiguraci bota. Je to hlavně proto, že ASF má přístup k mnoha chráněným částem vašeho Steam účtu a bez něj není možné, aby ASF fungovala.

---

### Nechci, aby ASF ve výchozím nastavení spravovala žádné hry, přesto chci použít další funkce ASF. Je to možné?

Ano, pokud chcete pouze začít ASF s modulem paused card farming, `FarmingPausedByDefault` můžete nastavit v `FarmingPpředvolby` bota s cílem toho dosáhnout. To vám umožní `pokračovat v` během běhu.

Pokud chcete úplně zakázat modul zemědělské výroby karet a ujistit se, že nikdy nebude, aniž byste to výslovně řekli jinak, pak doporučujeme nastavit `FarmPriorityQueueOnly` v `FarmingPreferences`která místo pouhého pozastavení deaktivuje farmaření kompletně dokud nepřidáte hry do fronty priorit.

V případě pozastavených/zakázaných karet můžete využít další funkce ASF, jako je `GamesPlayedWhileIdle`.

---

### Může ASF minimalizovat do plochy?

ASF je konzolová aplikace, není zde žádné okno, které by bylo možné minimalizovat, protože pro vás je okno vytvořeno vaším OS. Můžete však použít jakýkoli nástroj třetí strany schopný tak učinit, jako je **[RBTray](https://github.com/benbuck/rbtray)** pro Windows, nebo **[screen](https://linux.die.net/man/1/screen)** pro Linux/macOS. To jsou pouze příklady, existuje mnoho dalších aplikací s podobnou funkcí.

---

### Zachovává využití ASF způsobilost pro příjem přídavných balíčků?

**ano**. ASF používá stejnou metodu pro přihlášení do sítě Steam jako oficiální klient, Proto také zachovává schopnost přijímat přídavné balíčky pro účty, které se používají v ASF. Navíc zachování této schopnosti nevyžaduje ani přihlášení do komunity Steamu, abyste mohli bezpečně použít `OnlineStatus` v `Offline` , pokud chcete.

---

### Existuje nějaký způsob, jak komunikovat s přidruženým systémem?

Ano, několika různými způsoby. Podívejte se na **[příkazy](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** pro více informací.

---

### Rád bych pomohl s překladem aplikace ASF, co je třeba udělat?

Děkujeme za váš zájem! Všechny detaily naleznete v sekci **[lokalizace](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)**.

---

### Mám pouze jeden (hlavní) účet přidán do ASF, mohu stále vydávat příkazy přes Steam chat?

**Ano**, je vysvětleno v **[příkazech](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#notes)**. Můžete tak učinit prostřednictvím Steam skupinového chatu, i když použití **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** pro vás může být jednodušší.

---

### Zdá se, že ASF funguje, ale nepřijímám žádné karetní kapky!

Karty se liší od hry ke hře, jak si můžete přečíst v **[výkonu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Trvá to chvilku, obvykle **několik hodin na hru**, a nemůžete očekávat, že se karty od spuštění programu za několik minut propadnou. Pokud vidíte, že ASF aktivně kontroluje stav karet, a přepíná hru po té současné, pak vše funguje v pořádku. Je možné, že jste povolili možnost jako `DismissInventoryNotifications` of `BotBehaviour` , která automaticky zamítá oznámení inventáře. Podrobnosti naleznete v **[konfiguraci](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.

---

### Jak úplně zastavit proces ASF pro můj účet?

Jednoduše vypněte proces ASF, například klepnutím na tlačítko [X] v systému Windows. Pokud místo toho chcete zastavit konkrétní bota dle vašeho výběru, ale ostatní nechte běžet poté se podívejte na `Povolený` **[konfiguraci bota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**, nebo `stop` **[příkaz](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Pokud namísto toho chcete zastavit automatický zemědělský proces, ale stále nechejte ASF běžet pro váš účet, pak to je to, co `FarmingPausedByDefault` volba `FarmingPreferences` v **[vlastnosti bota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** a `pause` **[příkaz](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** je.

---

### Kolik botů mohu spustit s ASF?

ASF protože program nemá žádnou tvrdou horní hranici instancí bota, abyste mohli spustit tolik jako paměť na svém počítači, jste však stále omezováni sítí Steam a dalšími službami Steamu. V současné době můžete spustit až 100-200 botů s jednou IP a jedinou instancí ASF. Je možné spustit více botů s více IP adresami a více ASF pomocí omezení IP. Mějte na paměti, že pokud používáte velké množství robotů, měli byste sami ovládat jejich číslo. jako je zajištění toho, aby se všichni skutečně přihlásili a pracovali zároveň. ASF was not tweaked for that huge number of bots, and the general rule applies that **the more bots you have, the more issues you'll encounter**. Všimněte si rovněž, že výše uvedený limit obecně závisí na mnoha interních faktorech, je to spíše aproximace než přísný limit - s největší pravděpodobností budete moci spustit více botů nebo méně než je uvedeno výše.

ASF tým navrhuje **vlastnit** až **10 Steam účtů celkem**, a proto také běží do **10 botů celkem**. Nic výše není podporováno a prováděno na vlastní riziko, proti našemu návrhu zde předloženému. Toto doporučení je založeno na vnitřních pokynech Valve, stejně jako na našich vlastních návrzích. Zda budete dodržovat toto pravidlo nebo ne, ASF jako nástroj nebude proti vaší vůli, i když to bude mít za následek pozastavení Vašich Steam účtů. Aplikace ASF vám proto zobrazí varování, pokud budete nad tím, co doporučujeme, ale stále vám dovolte spustit cokoliv, co chcete, na vlastní riziko a nedostatek naší podpory.

---

### Mohu tedy spustit více instancí ASF?

Můžete spustit tolik instancí ASF na jednom počítači, pokud každá instance má svůj vlastní adresář a vlastní konfigurace, a účet používaný v jedné instanci se nepoužívá v jiné. Ale ptát se sám sebe, proč to chcete udělat. ASF je optimalizován tak, aby zároveň spravoval více než sto účtů, a vypuštěním těchto stovek botů ve svém vlastním ASF dochází ke zhoršení výkonnosti, odebere více zdrojů OS (např. CPU a paměti) a způsobí možné problémy s synchronizací mezi jednotlivými instancemi ASF, vzhledem k tomu, že ASF je nucena sdílet své omezovače s jinými případy.

Proto můj **silný návrh** je vždy maximálně jedna instance ASF na jedno IP/rozhraní. Pokud máte více IP/rozhraní, můžete všemi prostředky spustit více instancí ASF, s každou instancí pomocí vlastního nastavení IP/rozhraní nebo unikátní `WebProxy`. Pokud to neuděláte, spouštění více instancí ASF je zcela zbytečné, protože nic nezískáte ze spuštění více než 1 instance na jedno IP/rozhraní. Steam vám magicky neumožní spustit více robotů jen proto, že jste je spustili v jiné instanci aplikace ASF, a ASF vás neomezuje na začátek.

Samozřejmě stále existují platné případy použití pro více instancí ASF na stejném síťovém rozhraní, jako hostování služeb ASF pro vaše přátele s každým přítelem, který má vlastní jedinečnou instanci ASF, aby byla zaručena izolace mezi boty a dokonce i samotnými procesy ASF, ale neobcházíte žádná omezení ze Steamu, to je zcela jiný účel.

---

### Jaký je význam statusu při splacení klíče?

Stav udává, jak se daný pokus o vrácení vyvinul. Existuje mnoho různých možných stavů, z nichž většina je nejčastější:

| Stav                           | L 343, 22.12.2009, s. 1).                                                                                                                                                                                    |
| ------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Bez podrobností                | Stav "OK" naznačující úspěch - klíč byl úspěšně splacen.                                                                                                                                                     |
| Časový limit                   | Steam síť v daném čase nereagovala, nevíme, zda byl klíč vyčerpán, nebo ne (s největší pravděpodobností byl, ale můžete to zkusit znovu).                                                                    |
| BadActivationCode              | Zadaný klíč je neplatný (nerozpoznán jako platný klíč sítí Steam).                                                                                                                                           |
| DuplicateActivationCode        | Poskytnutý klíč byl již vyplacen jiným účtem nebo byl zrušen vývojářem/vydavatelem.                                                                                                                          |
| Již zakoupeno                  | Váš účet již vlastní `packageID` , který je propojen s tímto klíčem. Mějte na paměti, že toto neznamená, zda je klíč `DuplicateActivationCode` nebo ne - pouze že je platný a nebyl použit při tomto pokusu. |
| Omezená země                   | Toto je klíč uzamčený regionem a váš účet není v platném regionu, který je oprávněn jej použít.                                                                                                              |
| Aplikace DoesNotOwnRequiredApp | Nemůžete tento klíč použít, protože vám chybí nějaká jiná aplikace - hlavně základní hra při pokusu o převedení DLC balíčku.                                                                                 |
| Omezená sazba                  | Udělali jste příliš mnoho pokusů o vrácení a tvůj účet byl dočasně zablokován. Zkuste to znovu za hodinu.                                                                                                    |

---

### Jste přidruženi k jakékoli kartě farmářské/farmářské službě?

**No**. ASF není přidružena k žádné službě a všechny tyto pohledávky jsou nepravdivé. Váš Steam účet je Váš majetek a váš účet můžete používat libovolným způsobem, jak chcete. ale ventil jasně v **[oficiálním ToS](https://store.steampowered.com/subscriber_agreement)** uvedl, že:

> Jste zodpovědní za důvěrnost přihlášení a hesla a za bezpečnost počítačového systému. Valve není zodpovědný za používání vašeho hesla a účtu nebo za veškerou komunikaci a aktivitu na Steamu, která je výsledkem používání vašeho přihlašovacího jména a hesla, nebo jakoukoli osobou, které můžete úmyslně nebo z nedbalosti zveřejnit své přihlašovací jméno a/nebo heslo v rozporu s tímto ustanovením o zachování důvěrnosti.

ASF má licenci na liberální Apache 2.0 License, která umožňuje ostatním vývojářům dále integrovat ASF do svých vlastních projektů a služeb legálně. Takové projekty třetích stran využívající ASF však nejsou zaručeny bezpečnými, přezkoumatelnými, vhodnými nebo zákonnými podle **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Pokud chcete znát náš názor, **důrazně vás doporučujeme, abyste NEsdíleli ANY údajů o Vašem účtu se službami třetích stran**. Pokud se ukáže, že tato služba je **typický podvod**, budete s tímto problémem ponecháni sami, bez vašeho účtu Steam a ASF s největší pravděpodobností nepřevezme žádnou odpovědnost za služby třetích stran, které tvrdí, že jsou bezpečné a bezpečné, protože tým ASF žádný z nich nepřezkoumal a neschválil. Jinými slovy, **je používáte na vlastní riziko, proti našemu návrhu provedenému nad**.

Kromě toho oficiální **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** jasně uvádí, že:

> Nemůžete odhalit, sdílet ani jinak povolit ostatním používat své heslo nebo účet, pokud Valve výslovně nepovolí.

Je to váš účet a váš výběr. Jen neříkejte, že vás nikdo nevaroval. ASF jako program splňuje všechna výše uvedená pravidla, protože s nikým nesdílíte údaje o vašem účtu, a používáte program pro vlastní osobní použití, ale jakákoliv jiná "služba chovu karet" vyžaduje od vás údaje o vašem účtu, takže také porušuje výše uvedené pravidlo (vlastně několik z nich). Jako hodnocení **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** , nenabízíme žádné právní poradenství a měli byste se sami rozhodnout, zda chcete tyto služby využívat, nebo ne - podle nás **přímo porušuje [Steam ToS](https://store.steampowered.com/subscriber_agreement)** a může mít za následek pozastavení, pokud Valve zjistí. Jak bylo uvedeno výše, **důrazně doporučujeme NEpoužívat žádnou z takových služeb**.

---

## Problémy

---

### Jedna z mých her je farmová více než 10 hodin teď, ale stále jsem od ní nedostal žádné karty!

Důvod, který by mohl souviset se známým vydáním Steamu, k čemu dochází, když máte dvě licence pro stejnou hru, z nichž jedna má omezené kapky karet. To se obvykle stane, když aktivujete hru zdarma při hromadném darování na Steamu, a pak aktivujte klíč pro stejnou hru (ale bez omezení), e. . z placeného balíčku. Pokud se taková situace stane, Steam nahlásí na stránce s odznaky, že hra má stále karty ke stažení, ale bez ohledu na to, kolik hrajete hru - karty se nikdy nepropadnou kvůli bezplatné licenci na vašem účtu. Protože se nejedná o problém ASF, ale o problém Steamu, nemůžeme ho nějak obejít na straně ASF a musíte ho vyřešit sami.

Existují dva způsoby, jak tento problém vyřešit. Zaprvé můžete tuto hru zapsat do seznamu ASF, buď s `fbadd` **[příkazem](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** nebo s `Blacklist` **[konfigurační vlastností](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. To zabrání ASF pokusit se o karty z této hry, ale nevyřeší základní problém, který vám brání v získání karetních kapek z ovlivněné hry. Zadruhé můžete použít nástroj pro samoobslužnou podporu Steamu k odebrání bezplatné licence z vašeho účtu, který ponechá pouze plnou licenci, která obsahuje karetní kapky. Za tímto účelem za prvé, navštivte vaši **[licenci a aktivaci produktů](https://store.steampowered.com/account/licenses)** a najděte zdarma a placenou licenci pro ovlivněnou hru. Obvykle je to docela snadné - oba mají podobné jméno, ale svobodný balík "omezený propagační balíček" nebo jiný "promo" v názvu licence, plus "complimentary" v poli "metody pořízení". Někdy to může být složitější, například pokud byl svobodný balíček v nějakém balíku a má jiný název. Pokud jste našli dvě podobné licence - pak je to skutečně problém popsaný zde, a můžete bezpečně odebrat bezplatnou licenci bez ztráty hry.

Pro odstranění bezplatné licence z vašeho účtu, navštivte **[na stránce podpory Steam](https://help.steampowered.com/wizard/HelpWithGame)** a vložte dotčené jméno hry do vyhledávacího pole, hra by měla být k dispozici v sekci "produkty", klikněte na ni. Případně můžete použít odkaz `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` a nahradit `<appID>` aplikací ID hry, která způsobuje problémy. Poté klikněte na "Chci trvale odstranit tuto hru ze svého účtu" a poté vyberte chybnou bezplatnou licenci, kterou jste našli výše, obvykle s "omezeným propagačním balíčkem" v názvu (nebo podobně). Po odebrání volné licence by měla být ASF schopna bez problémů vypustit karty z postižené hry, po odstranění by jste měli restartovat farmaření a ujistit se, že Steam tentokrát získá správnou licenci.

---

### ASF nezjistil hru `X` jako dostupnou pro farmování, ale vím, že obsahuje Steam obchodní karty!

Existují dva hlavní důvody. Nejzřetelnějším důvodem je skutečnost, že odkazujete na **Steam store** , kde je daná hra oznámena jako povolená karetní hra. This is **wrong** assumption, as it simply states that the game **has** card drops included, but not necessarily this function for that game is **enabled** right away. Více o tom si můžete přečíst v **[oficiálním oznámení](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**.

Stručně řečeno, ikona kapek karty v Steam obchodě neznamená nic, zkontrolujte **[stránky s odznakem](https://steamcommunity.com/my/badges)** pro potvrzení, zda je hra povolena nebo ne - to je také to, co dělá ASF. Pokud se vaše hra nezobrazuje v seznamu jako hra s kartami možnými shozy, pak je tato hra **není** možná, bez ohledu na důvod.

Druhá otázka je méně zřejmá, a je to situace, kdy vidíte, že vaše hra je skutečně k dispozici s karetními kapkami na stránce s odznaky, ještě není okamžitě vychováván ze strany ASF. Pokud nenarazíte na nějakou jinou chybu, například ASF nemůže zkontrolovat stránky s odznaky (popsané níže), je to prostě efekt keše a na straně aplikace ASF Steam stále hlásí zastaralé odznaky. Tento problém by se měl vyřešit dříve nebo později, jakmile bude vyrovnávací paměť zrušena. Neexistuje ani způsob, jak to napravit na naší straně.

Samozřejmě, všechny tyto předpoklady předpokládají, že používáte ASF s výchozími nedotčenými nastaveními, protože můžete přidat tuto hru do černé listiny, použít vybrané `FarmingPreferences` jako `FarmPriorityQueueOnly` nebo `SkipRefundableGames`a tak dále.

---

### Proč se nezvyšuje hra farmovaná pomocí ASF?

Funguje, ale **ne v reálném čase**. Steam zaznamenává vaši hrací plochu v pevně stanovených intervalech a plánuje její aktualizaci, ale nemáte zaručeno, že jste ji aktualizovali ihned, jakmile opustíte relaci, natož během ní. Jen proto, že skladba není aktualizována v reálném čase, neznamená, že není zaznamenána, je obvykle aktualizována každých 30 minut.

---

### Jaký je rozdíl mezi varováním a chybou v logu?

ASF zapisuje do svého logu spoustu informací na různých úrovních logování. Naším cílem je vysvětlit **přesně** , co ASF dělá, včetně toho, s jakými problémy se Steam musí vypořádat, nebo jiných problémů, které je třeba překonat. Většinu času není všechno relevantní, Proto se v ASF používají dvě hlavní úrovně, pokud jde o problémy - varovná úroveň a míra chyb.

General ASF rule is that warnings are **not** errors, therefore they should **not** be reported. Varování je pro vás indikátorem, že se stane něco potenciálně nechtěného. Zda Steam nereagoval, vyhazuje chyby API nebo je odpojeno síťové připojení - je to varování, a to znamená, že jsme očekávali, že se to stane, takže s ní neobtěžujte vývoj ASF. Samozřejmě se můžete zeptat na ně nebo získat pomoc pomocí naší podpory, ale neměli byste předpokládat, že se jedná o chyby ASF, které stojí za hlášení (pokud nepotvrdíme jinak).

Chyby naproti tomu naznačují situaci, která by se neměla stát, proto stojí za to nahlásit, pokud jste se ujistili, že to není vy, kdo je způsobí. Pokud je to společná situace, kterou očekáváme, pak bude místo toho převedeno na varování. Jinak je to možná chyba, která by měla být opravena, ne tiše ignorována, za předpokladu, že to není výsledek vašeho technického problému. Například vložení neplatného obsahu do `ASF. son` soubor vyhodí chybu, protože ASF ji nebude schopen analyzovat, ale byl to vy, kdo ji tam vložil. takže byste nám neměli nahlásit tuto chybu (pokud nepotvrdíte, že ASF je špatný a vaše struktura je ve skutečnosti naprosto správná).

V jedné větě TL;DR - nahlásit chyby, nehlásit varování. Můžete se stále zeptat na varování a získat pomoc v našich sekcích podpory.

---

### ASF se nespustí, okno programu se okamžitě zavře!

Za normálních podmínek každá chyba nebo ukončení ASF vygeneruje protokol `. xt` v adresáři programu pro zobrazení, které lze použít pro nalezení příčiny. Kromě toho je několik posledních souborů logů také archivováno v `logs` , protože hlavní `log. Soubor xt` je přepsán každým spuštěním aplikace ASF.

Pokud však ani běh .NET není schopen zavést systém na vašem počítači, `log.txt` nebude vygenerován. Pokud se tak stane, pak jste pravděpodobně zapomněli nainstalovat .NET předpoklady, jak je uvedeno v **[nastavení](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)** průvodce. K dalším běžným problémům patří pokusit se spustit špatnou variantu ASF pro váš OS, nebo jiným způsobem chybí nativní závislosti .NET na běhu. Pokud se okno konzole zavře příliš brzy, abyste mohli přečíst zprávu, pak otevřete nezávislou konzoli a spusťte binární soubor ASF. Například v systému Windows, otevřete adresář ASF, podržte `Shift`, klikněte pravým tlačítkem myši uvnitř složky a zvolte "*otevřít příkaz zde*" (nebo *powershell*), poté zadejte do konzole `. ArchiSteamFarm.exe` a potvrďte s enter. Tímto způsobem získáte přesnou zprávu, proč aplikace ASF nezačíná správně.

Pokud neexistuje žádný výstup a jste v systému Windows, obvyklým důvodem pro to, aby nebyly nainstalovány všechny dostupné aktualizace systému Windows - ujistěte se, že používáte aktuální OS, protože nepodporujeme používání ASF na Windows bez splnění této podmínky ani tak dále.

---

### ASF si při hraní vybírá relaci mého klienta Steam! / *Tento účet je přihlášen na jiném PC*

Toto se zobrazí jako zpráva ve Steam překryvu, že účet se používá někde jinde při hraní. Tato otázka může mít dva odlišné důvody.

Jeden z důvodů je způsoben rozbitými balíky (partie), které nedrží správně přehrávaný zámek očekávat, že tento zámek bude mít zákazník. Příkladem takových balíčků je Skyrim SE. Váš Steam klient spustí hru správně, ale tato hra se neregistruje jako používá. Z toho důvodu ASF vidí, že je svobodný proces obnovit, což dělá, a to vás vykopne ze sítě Steam, protože Steam náhle zjistí, že účet je využíván na jiném místě.

Druhý důvod by mohl přijít, pokud hrajete na vašem počítači, zatímco ASF čeká (zejména na jiném počítači) a ztratíte připojení k síti. V tomto případě vás síť Steam označí jako offline a uvolní přehrávaný zámek (jako výše), který spustí ASF (např. na jiném stroji) k obnovení farmování. Když se váš PC vrátí zpět online, Steam již nemůže získat herní zámek (který nyní drží ASF, podobný také výše uvedenému, a ukazuje stejnou zprávu.

Obě příčiny na straně ASF jsou ve skutečnosti velmi těžko řešeny, Jelikož ASF jednoduše obnoví zemědělství, jakmile ji síť Steam informuje, že účet může být znovu použit. To se obvykle děje při uzavření hry, ale s rozbitými balíčky se to může stát okamžitě, i když hra stále běží. ASF nemá žádný způsob, jak zjistit, zda jste odpojeni, přestal hrát hru nebo stále hrajete hru, která nedrží patřičný zámek.

Jediným vhodným řešením tohoto problému je ruční pozastavení vašeho bota `pause` před tím, než začnete hrát, a pokračujte s `pokračujte na` , jakmile budete hotovi. Případně můžete problém ignorovat a jednat stejně, jako kdyby jste hráli s offline klientem Steamu.

---

### `Odpojen od Steamu!` - Nemohu navázat spojení se Steam servery.

ASF může pouze **zkusit** pro navázání spojení se servery Steam, a může selhat z mnoha důvodů, včetně nedostatečného připojení k internetu, Steam je vypnutý, vaše blokování firewallu, nástroje třetích stran, nesprávně konfigurované trasy nebo dočasné selhání. `Debug` mód můžete zapnout a podívat se na více podrobných protokolů uvádějících přesné důvody selhání. i když je to obvykle způsobeno vlastními akcemi, jako je používání "CS:GO MM Server Picker", které používá spoustu Steam IP adres, takže je pro vás velmi obtížné dosáhnout sítě Steam.

ASF udělá vše, co je v jejích silách, pro navázání připojení, která zahrnuje nejen dotazy na aktualizovaný seznam serverů, ale také vyzkoušejí jinou IP adresu při selhání poslední adresy, takže pokud se jedná o skutečný dočasný problém s nějakým konkrétním serverem nebo trasou, ASF se dříve nebo později připojí. Pokud se však za firewallem nebo jiným způsobem nemůžete dostat na Steam servery, pak ji samozřejmě potřebujete opravit sami, s možnou pomocí režimu `Debug`.

Je také možné, že váš počítač není schopen navázat spojení se servery Steam pomocí výchozího protokolu v ASF. Protokoly, které ASF může používat, můžete změnit změnou `SteamProtocols` vlastnosti globální konfigurace. Například, pokud máte problémy se Steamem s `UDP` protokolem (např. z důvodu firewall), možná budete mít více štěstí s `TCP` nebo `WebSocket`.

Ve velmi nepravděpodobném případě uložení nesprávných serverů do mezipaměti, například z důvodu přesunutí složky ASF `config` z jednoho stroje do jiného zařízení umístěného v úplně jiné zemi, vymazání `ASF. b` k aktualizaci Steam serverů při příštím spuštění může pomoci. Velmi často to není potřeba a nemusí se dělat, protože tento seznam je automaticky aktualizován při prvním spuštění, stejně jako při navázání spojení - jen to zmiňujeme jako způsob, jak odstranit cokoliv, co souvisí se seznamem serverů Steam uloženým ASF.

---

### `Nelze se přihlásit do Steamu: TryAnotherCM/Neplatný`, `ServiceUnavailable/Invalid`

Podle výše uvedeného, ale tentokrát je připojený server explicitně nedostupný. Obvykle se děje během režimu údržby Steamu, s tím nemůžete nic dělat, ASF se automaticky pokusí znovu s jiným serverem, dokud nepřijme jeho žádost. Nemělo by trvat déle než jednu hodinu.

---

### `Nelze získat informace o odznakech, zkuste to později!`

Obvykle to znamená, že používáte PIN pro přístup k vašemu účtu, ale zapomněli jste ho vložit do ASF konfigurace. Musíte vložit platný PIN do vlastnosti `SteamParentalCode` , jinak ASF nebude mít přístup k většině webového obsahu, proto nebude moci správně fungovat. Přejděte na **[konfiguraci](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** , abyste se dozvěděli více o `SteamParentalCode`.

K dalším důvodům patří dočasný problém se Steamem, problém sítě nebo podobně. Pokud se problém po několika hodinách nevyřeší a jste si jisti, že jste správně nastavili ASF, neváhejte nám o tom vědět.

---

### ASF selhal s `Požadavek selhal po 5 pokusech` chybách!

Obvykle to znamená, že používáte PIN pro přístup k vašemu účtu, ale zapomněli jste ho vložit do ASF konfigurace. Musíte vložit platný PIN do vlastnosti `SteamParentalCode` , jinak ASF nebude mít přístup k většině webového obsahu, proto nebude moci správně fungovat. Přejděte na **[konfiguraci](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** , abyste se dozvěděli více o `SteamParentalCode`.

Pokud není důvodem kód PIN rodiče, je to nejčastější chyba, na kterou byste se měli zvyknout, jednoduše to znamená, že ASF poslal žádost do Steam Network, a nedostal platnou odpověď, 5krát za sebou. Obvykle to znamená, že Steam je buď na nízké úrovni, nebo má určité potíže nebo údržbu - ASF si je takových problémů vědom, a vy byste se o ně neměli obávat, pokud se neděje nepřetržitě déle než několik hodin a ostatní uživatelé takové problémy nemají.

Jak zkontrolovat, zda Steam klesá? **[Steam Status](https://steamstat.us)** je vynikajícím zdrojem kontroly, zda by Steam **měl být** nahoru, pokud si všimnete chyb, zejména pokud se týká komunity nebo webové API, pak Steam má potíže. Možná budete chtít ponechat ASF samotnou a nechat ji vykonat po krátkém čase výpadku, nebo ji opustit a počkat sami.

To však není vždy pravda, protože v některých situacích nemusí Steam Status detekovat problémy se Steamem, Například k takovému případu došlo, když Valve prostřednictvím HTTPS rozbil podporu HTTPS pro Steam Community 7. června 2016 - přístup **[SteamCommunity](https://steamcommunity.com)** prostřednictvím HTTPS házel chybu. Proto nedůvěřujte ani Steam Status a je nejlepší se podívat sebe, jestli vše funguje tak, jak by mělo fungovat.

Kromě toho Steam obsahuje různá omezení sazeb, která dočasně zabrání vaší IP v případě, že podáte příliš velký počet žádostí najednou. ASF si to uvědomuje a nabízí v konfiguraci několik různých omezovačů, které byste měli využít. Výchozí nastavení bylo vyladěno na základě množství robotů **sane** , pokud používáte tak obrovské množství, že vám i Steam říká odejít dál, pak je buďto vyladěte, dokud vám to již neřekne, nebo uděláte to, co jste řekl. Předpokládám, že druhá cesta není pro vás volbou. tak si přečtěte toto téma a věnujte zvláštní pozornost `WebLimiterDelay` , což je obecný limiter, který se vztahuje na všechny webové požadavky.

Neexistuje žádné "zlaté pravidlo", které by fungovalo pro všechny, protože bloky jsou silně ovlivněny faktory třetích stran, To je důvod, proč musíte experimentovat sami sebe a najít hodnotu, která pro vás funguje. Můžete také ignorovat to, co říkám a používám něco jako `10000` , které má zaručeno správné fungování, ale pak si nestěžujte, jak vaše ASF reaguje na vše za 10 sekund a jak odznak trvá 5 minut. Kromě toho Je zcela možné, že žádný omezovač nic neudělá, protože máte tak velké množství robotů, že jste na **[tvrdý limit](#how-many-bots-can-i-run-with-asf)** zmíněný výše. Ano, je zcela možné, že se budete moci přihlásit bez problémů do Steam sítě (klient), ale Steam web (webové stránky) vám odmítne naslouchat, pokud máte 100 zasedání najednou. ASF vyžaduje jak síť Steam, tak Steam web, aby byly kooperativní, stačí jen jednou, aby se vaše problémy nezotavily.

Pokud nic nepomůže, a nemáte žádný přehled o tom, co je rozbito, vždy můžete povolit režim `ladění` a vidět se v logu ASF, proč přesně požadavky chybí. Například:

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Zakázáno <- HEAD https://steamcommunity.com/my/edit/settings
```

Vidíte, že `zakázáno` kód? To znamená, že jste dočasně zakázali na nadměrné množství žádostí, protože jste nevyladili `WebLimiterDelay` správně (za předpokladu, že dostanete stejný chybový kód i pro všechny ostatní požadavky). Zde mohou být uvedeny další důvody, jako je `InternalServerError`, `ServiceUnavailable` a časový limit, který naznačuje údržbu Steamu/problémy. Můžete se vždy pokusit navštívit odkaz zmíněný aplikací ASF a zkontrolovat, zda to funguje - pokud ne, pak víte, proč k tomu nemá přístup ani ASF. Pokud se tak stane a stejná chyba neodejde po dni nebo dva, může to být za to prošetřit a hlásit.

Před tím byste měli **ujistit se, že chyba stojí za hlášení na prvním místě**. Pokud je to zmíněno v tomto FAQ, například problém související s obchodováním, pak je to ven. Pokud se jedná o dočasný problém, který se stal jednou nebo dvakrát, zejména když vaše síť byla nestabilní nebo Steam byl nestabilní - to je ven. Pokud jste však dokázali svůj problém během 2 dnů několikrát zopakovat, restartoval ASF i váš počítač v procesu a ujistěte se, že zde není žádný záznam FAQ, který by jej pomohl vyřešit, pak to může stát za to se ptát.

---

### Zdá se, že aplikace ASF zmrazí a nevytiskne nic na konzoli, dokud nestisknu klávesu!

Pravděpodobně používáte Windows a vaše konzole má režim QuickEdit povolen. Viz **[tuto](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** otázku na StackOverflow pro technické vysvětlení. Režim QuickEdit byste měli zakázat pravým kliknutím na okno konzole aplikace ASF, otevíráním vlastností a zrušením zaškrtávacího políčka.

---

### ASF nemůže přijímat ani odesílat obchody!

Zjevná věc nejprve - nové účty začínají být omezené. Dokud neodemknete účet načtením jeho peněženky nebo utrácením $5 v obchodě, ASF nemůže přijímat ani posílat obchody pomocí tohoto účtu. V tomto případě ASF prohlásí, že inventář se zdá prázdný, protože každá karta, která je v něm obsažena, je neobchodovatelná.

Dále pokud nepoužíváte **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**je možné, že ASF ve skutečnosti přijala/odeslal obchod, ale musíte jej potvrdit prostřednictvím svého e-mailu. Podobně pokud používáte klasické 2FA, musíte potvrdit obchod prostřednictvím svého autentifikátoru. Potvrzení jsou nyní **povinná** , takže pokud je nechcete přijmout, zvažte import svého autentizátoru do ASF 2FA.

Všimněte si také, že můžete obchodovat pouze se svými přáteli a lidmi se známým obchodním stykem. Pokud se pokoušíte iniciovat *Bot -> Master* obchod, jako je `loot`pak musíte mít bot buď na Vašem přátelském seznamu, nebo `SteamTradeToken` deklarován v konfiguraci Bota. Ujistěte se, že je token platný - jinak nebudete moci odeslat obchod.

A konečně, nezapomeňte, že nová zařízení mají 7denní obchodní zámek, takže pokud jste právě přidali svůj účet do ASF, počkejte nejméně 7 dní - vše by mělo fungovat po tomto období. Toto omezení zahrnuje **** přijímání **a** odesílání obchodů. Ne vždy se to spustí a existují lidé, kteří mohou odeslat a přijímat obchody okamžitě. Většina lidí je však zasažena a zámek **se stane** , i když můžete posílat a přijímat obchody prostřednictvím Steam klienta na stejném počítači. Stačí trpělivě počkat, není nic, co byste mohli udělat pro rychleji. Stejně tak můžete získat podobné zámek pro odstranění/změnu různých nastavení souvisejících se Steam bezpečností, jako je 2FA, SteamGuard, heslo, e-mail a podobně. Obecně platí, zkontrolujte, zda můžete z tohoto účtu odeslat obchod sami, pokud ano, je to s velkou pravděpodobností klasický 7denní zámek z nového zařízení.

A konečně, mějte na paměti, že jeden účet může mít pouze 5 čekajících obchodů k druhému, takže ASF nebude posílat obchody, pokud máte 5 (nebo více) čekajících od tohoto jednoho bota, který již přijme. Toto je jen zřídka problém, ale je také třeba se zmínit, zejména pokud nastavíte ASF na automatické odesílání obchodů, zatím nepoužíváte ASF 2FA a zapomněli jste je skutečně potvrdit.

Pokud nic nepomůže, můžete vždy povolit režim `ladění` a zkontrolovat si, proč požadavky selhávají. Vezměte prosím na vědomí, že Steam mluví většinou nesmyslně a z důvodu nemusí mít žádný logický smysl, nebo může být dokonce zcela nesprávná - pokud se rozhodnete tento důvod interpretovat, ujistěte se, že máte slušné znalosti o Steamu a jeho dotazech. Je také zcela běžné, že tato otázka nemá žádný logický důvod, a jediným navrhovaným řešením je v tomto případě znovu přidat účet do ASF (a počkat 7 dní). Někdy se tento problém také opraví sám *magically*, stejně jako se rozbije. Obvykle je to však jen 7denní obchodní zámek, dočasný párový problém, nebo obojí. Nejlepší je dát ji pár dní před ručním ověřením chyb, pokud nemáte nějakou výzvu k ladění skutečné příčiny (a obvykle budete nuceni stejně čekat, protože chybová zpráva nemá žádný smysl, ani vám v nejmenším nepomůže).

V každém případě může ASF pouze **zkusit** poslat Steamu správnou žádost, aby mohl akceptovat/posílat obchod. Ať už Steam přijme tuto žádost, nebo ne, je mimo rozsah ASF a ASF to magicky neudělá. V souvislosti s touto funkcí není žádná chyba a také se nic nezlepšuje, protože logika se děje mimo ASF. Proto nepožadujte opravu věcí, které nejsou zlomené, a také se neptají, proč ASF nemůže přijímat ani odesílat obchody - **Nevím a ASF neví ani**. Buď se s tím vypořádejte, nebo opravte sami sebe, pokud víte lépe.

---

### Proč musím dát 2FA/SteamGuard kód na každé přihlášení? / *Odstraněno prošlé přihlašovací klíč*

ASF používá přihlašovací klíče (pokud jste si ponechali `UseLoginKeys` povoleno) pro zachování platnosti přihlašovacích údajů, stejný mechanismus, jaký používá Steam - token 2FA/SteamGuard je vyžadován pouze jednou. Nicméně kvůli problémům a dotazům na síti Steam je zcela možné, že přihlašovací klíč není uložen v síti. Takové problémy jsme již viděli nejen s ASF, ale také s běžným Steam klientem (je třeba při každém běhu zadat přihlašovací jméno + heslo, bez ohledu na možnost "Zapamatovat si mě").

Můžete odstranit `BotName.db` a `BotName. v` (je-li k dispozici) ovlivněného účtu a zkuste znovu propojit ASF s vaším účtem, ale to pravděpodobně nic neudělá. Někteří uživatelé oznámili, že **[deautorizace všech zařízení](https://store.steampowered.com/twofactor/manage)** na Steam by měla pomoci a změna hesla bude dělat totéž. Jsou to však pouze práce, které nejsou ani zaručeny pro práci, skutečným řešením založeným na ASF je importovat autentifikátor jako **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** - tímto způsobem může ASF generovat tokeny automaticky, když jsou potřebné, a nemusíte je zadávat ručně. Obvykle se tento problém kouzelně po nějaké době vyřeší, takže můžete jednoduše počkat, až se to stane. Samozřejmě, že můžete požádat hlavu o řešení, protože nemůžu síť Steam nutit, aby přijala naše přihlašovací klíče.

Jako postranní poznámku můžete také vypnout přihlašovací klíče s `UseLoginKeys` konfigurační vlastností nastavenou na `false`, ale tento problém nevyřeší, pouze přeskočit první selhání přihlašovacího klíče. ASF je již obeznámen s problémem, který je zde vysvětlen, a pokusí se co nejlépe nepoužívat přihlašovací klíče, pokud si sama může zaručit všechny přihlašovací údaje, takže není nutné vyladit `UseLoginKeys` ručně, pokud můžete poskytnout všechny přihlašovací údaje spolu s ASF 2FA.

---

### Dostávám chybu: *Nelze se přihlásit do Steam: `Zrušené heslo` nebo `RateLimitExceeded`*

Tato chyba může znamenat spoustu věcí, některé z nich zahrnují:

- Neplatná kombinace přihlašovacího jména/hesla (samozřejmě)
- Přihlašovací klíč pro vypršení platnosti použitý ASF pro přihlášení
- Příliš mnoho neúspěšných pokusů o přihlášení v krátké době (anti-bruteforce)
- Příliš mnoho pokusů o přihlášení v krátké době (omezená rychlost)
- Požadavek na přihlášení kaptiny (velmi pravděpodobně způsobí dva důvody)
- Jakýkoli jiný důvod, proč vám Steam Network možná zabránil v přihlášení

V případě antikartérní síly a omezení rychlosti zmizí problém po určité době, takže stačí počkat a nepokoušet se mezitím přihlásit. Pokud jste na tento problém narazili často, je možná moudré zvýšit `LoginLimiterDelay` konfigurační vlastnost ASF. Nadměrné restartování programu a další úmyslné/neúmyslné přihlašovací požadavky s tímto problémem rozhodně nepomohou, takže se tomu snažte pokud možno vyhnout.

V případě vypršení platnosti přihlašovacího klíče - ASF odstraní staré přihlašovací klíče a požádá o nové přihlašovací jméno (které bude vyžadovat, aby byl 2FA token, pokud je váš účet chráněn 2FA. Pokud váš účet používá ASF 2FA, token bude generován a používán automaticky. To se samozřejmě může stát v průběhu času, ale pokud dostanete tento problém na každé přihlašovací jméno, je možné, že se Steam z nějakého důvodu rozhodl ignorovat naše žádosti o uložení přihlašovacího klíče, jak je uvedeno v emisi **[nad](#why-do-i-have-to-put-2fasteamguard-code-on-each-login--removed-expired-login-key)**. Můžete samozřejmě úplně zakázat `UseLoginKeys` , ale to problém nevyřeší, jen se vyhnete nutnosti odstranit vypršející přihlašovací klíče. Skutečným řešením podle výše uvedené otázky je použít ASF 2FA.

A konečně, pokud jste použili nesprávnou kombinaci přihlašovacích údajů + hesel, samozřejmě je třeba opravit, nebo zakázat bota, který se pokouší připojit pomocí těchto přihlašovacích údajů. ASF nemůže sám o sobě odhadnout, zda `Neplatné heslo` znamená neplatné přihlašovací údaje, nebo některý z výše uvedených důvodů se bude snažit pokračovat, dokud neuspěje.

Mějte na paměti, že ASF má svůj vlastní vestavěný systém, který odpovídajícím způsobem reaguje na parní škály nakonec se připojí a obnoví svou práci, proto není nutné nic dělat, pokud je problém dočasný. Restartování aplikace ASF za účelem magického řešení problémů situaci jen zhorší (nové ASF nebude znát předchozí stav aplikace ASF, že se nebude moci přihlásit, a pokuste se připojit místo čekání), tak se vyhnout tomu, pokud nevíte, co děláte.

A konečně, stejně jako u každého Steam požadavku - ASF může pouze **zkusit** se přihlásit pomocí zadaných údajů. Zda bude tato žádost úspěšná, nebo ne, je mimo rozsah a logiku ASF - není zde žádná chyba, a nic nelze v tomto ohledu ani vylepšit.

---

### Nemůžu vložit přihlašovací údaje, které ASF žádá
### `System.InvalidOperationException: Nelze číst klíče, pokud aplikace nemá konzoli nebo pokud byl vstup konzole přesměrován`
### `Systém.IOVýjimka: Chyba vložení/výstupu`
### `Zadání RequestInput() je neplatné!`

Pokud k této chybě došlo během ASF vstupu (např. můžete vidět `GetUserInput()` ve stacktrace, pak je to způsobeno vaším prostředím, které zakazuje ASF číst standardní vstup do konzoly. K tomu může dojít z mnoha důvodů, ale nejčastěji používáte ASF ve špatném prostředí (např. v `systemd`, `nohup` nebo `&` místo e. . `obrazovka` na Linuxu. Pokud ASF nemá přístup ke svému standardnímu vstupu, uvidíte tuto chybu a neschopnost ASF použít vaše údaje během běhu.

Za normálních okolností byste měli opravit výše uvedený problém, tj. umožnit aplikaci ASF přístup ke standardnímu vstupu, abyste mohli poskytnout podrobnosti. However, if you **expect** this to happen, so you **intend** to run ASF in input-less environment, then you should explicitly tell ASF that it's the case, by setting **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** mode appropriately. To aplikaci ASF řekne, že nikdy nepožádá o vstup uživatele za žádných okolností, což vám umožní bezpečný běh aplikace ASF v prostředí bez vstupů. Vybrané dotazy na vstup můžete odpovědět jinými prostředky v tomto režimu, např. v ASF-ui.

---

### `System.Net.Http.WinHttpException: Došlo k bezpečnostní chybě`

K této chybě dochází, když ASF nedokáže navázat bezpečné spojení s daným serverem, téměř výhradně kvůli nedůvěře SSL certifikátu.

Téměř ve všech případech je tato chyba způsobena **špatným datem/časem na vašem počítači**. Každý SSL certifikát vydal datum a datum expirace. Pokud je vaše datum neplatné a z těchto dvou hranic nelze certifikát důvěryhodný kvůli možnému útoku **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)** a ASF odmítne připojení provést.

Zřetelným řešením je vhodně nastavit datum na vašem počítači. Je velmi doporučeno používat automatickou synchronizaci dat, jako je například nativní synchronizace dostupná na systému Windows, nebo `ntpd` na Linuxu.

Pokud jste se ujistili, že datum na vašem počítači je vhodné a chyba nechce zmizet, SSL certifikáty, u kterých může být vaše systémová důvěryhodnost zastaralá nebo neplatná. V tomto případě byste se měli ujistit, že váš počítač může navázat bezpečná spojení, například tím, že zkontrolujete, zda máte přístup `https://github. om` s libovolným prohlížečem dle vašeho výběru, nebo s CLI nástrojem jako `curl`. Pokud jste potvrdili, že to funguje správně, neváhejte nás požádat o podporu.

---

### `System.Threading.Tasks.TaskCanledException: Úkol byl zrušen`

Toto varování znamená, že Steam neodpověděl na žádost ASF v daném čase. Obvykle je to způsobeno závadami sítě Steam a nijak neovlivňuje ASF. V ostatních případech je to stejné jako požadavek selhal po 5 pokusech. Hlášení tohoto problému nemá žádný smysl, protože Steam nemůže přinutit reagovat na naše požadavky.

---

### `Typ inicializátoru pro 'System.Security.Cryptography.CngKeyLite' hodil výjimku`

Tento problém je téměř výhradně způsoben vypnutými/zastavenými `Isolací CNG Key` službou Windows, která poskytuje funkci základního šifrování pro ASF, bez níž není program schopen běžet. Tento problém můžete vyřešit spuštěním `služeb. sc` a zajištění, že `CNG Key Isolation` Služba Windows nemá vypnutý start a právě běží.

---

### ASF je detekován jako malware v mém AntiVirusu! Co se děje?

**Ujistěte se, že jste si stáhli ASF z důvěryhodného zdroje**. Jediným oficiálním a důvěryhodným zdrojem je **[ASF verze](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** na GitHub (a to je také zdroj automatických aktualizací) - **jiný zdroj není podle definice důvěryhodný a může obsahovat malware přidaný jinými lidmi** - neměli byste důvěřovat žádnému jinému umístění ke stažení, zajistí, aby vaše aplikace ASF vždy pocházela od nás.

Pokud jste potvrdili, že aplikace ASF je stažena z důvěryhodného zdroje, je velmi pravděpodobné, že je to jednoduše falešná pozitivní. Toto **se stalo v minulosti**, **se děje právě teď**a **se stane v budoucnu**. Pokud máte obavy o aktuální bezpečnost při používání ASF, pak navrhuji naskenovat ASF s mnoha různými AVL pro aktuální detekční poměr, například přes **[VirusTotal](https://www.virustotal.com)** (nebo jakoukoliv jinou webovou službu dle vašeho výběru).

Pokud AV, které používáte falešně, detekuje ASF jako malware, pak **je dobrý nápad poslat tento soubor zpět vývojářům vaší AV, aby ji mohli analyzovat a vylepšit svůj detekční engine**. Je jasné, že nefunguje tak dobře, jak si myslíte. V ASF kódu není žádný problém a také pro nás není nic k opravě, protože vůbec nedistribuujeme malware, Proto nedává smysl, aby nám tyto falešně pozitivní zprávy podávaly. Důrazně doporučujeme odeslat vzorek ASF pro další analýzu, jak je uvedeno výše, ale pokud s tím nechcete souhlasit, pak můžete vždy přidávat ASF do nějakých AV výjimek, zakázat AV nebo jednoduše použít jiné. Bohužel jsme zvyklí na hloupé AVs, jako každý za okamžik detekuje ASF jako virus, která obvykle trvá velmi krátce a je rychle upravována vývoji, ale stejně jako jsme zmínili výše - **se to stalo**, **se stane** a **se stane vždy**. ASF neobsahuje žádný škodlivý kód, můžete si prohlédnout ASF kód a dokonce zkompilovat ze zdroje sami. Nejsme hackeři pro zastírání ASF kódu pro skrytí před AV heuristikou a falešnými pozitivními nálezy, takže neočekávejte od nás opravit, co není porušeno - není žádný "virus" pro nás opravit.