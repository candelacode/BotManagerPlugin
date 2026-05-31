# ItemsMatcherPlugin

`ItemsMatcherPlugin` je oficiální ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** , který rozšiřuje ASF s funkcemi ASF STM seznamu. Zejména to zahrnuje `PublicListing` v **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** a `MatchActively` v **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. ASF přichází s `ItemsMatcherPlugin` spojený s vydáním, proto je připraven k okamžitému použití.

---

## `PublicListing`

Veřejný seznam, jak název naznačuje, obsahuje seznam aktuálně dostupných ASF STM botů. Je umístěn na **[na naší webové stránce](https://asf.justarchi.net/STM)**, spravováno automaticky a používáno jako veřejná služba pro oba uživatele ASF, kteří využívají `MatchActively`, jakož i uživatelé ASF a mimo ASF pro ruční páření.

Chcete-li být uvedeni, máte sadu požadavků, které je třeba splnit. Minimálně musíte povolit `PublicListing` v `RemoteCommunication` (výchozí nastavení), `SteamTradeMatcher` povolen v `Obchodní nastavení` **[veřejný inventář](https://steamcommunity.com/my/edit/settings)** nastavení ochrany osobních údajů, **[neomezený účet](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** a **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** aktivní. Další požadavky zahrnují 2FA aktivní alespoň od 15 dnů, poslední změnu hesla před více než 5 dny, nedostatek jakýchkoli omezení účtů, jako jsou blokování, ekonomické zákazy a zákazy obchodování. Přirozeně musíte mít v inventáři alespoň jednu (obchodovatelnou) položku z určeného `MatchableTypy`, například obchodní karty. Kromě toho boti s více než `500000` nejsou z důvodu nadměrného režijního zisku přijímáni, v tomto případě doporučujeme rozdělit váš inventář na několik účtů.

`PublicListing` je ve výchozím nastavení povoleno, Vezměte prosím na vědomí, že pokud nesplňujete všechny požadavky, budete **zobrazeni na webových stránkách, nebude** zejména `SteamTradeMatcher`, který není ve výchozím nastavení povolen. Pro lidi, kteří nesplňují kritéria, i když drželi `PublicListing` povolené, ASF žádným způsobem nekomunikuje se serverem. Veřejný seznam je také kompatibilní pouze s nejnovější stabilní verzí ASF a může odmítnout zobrazit zastaralé boty, zejména pokud jim chybí základní funkce, které lze nalézt pouze v novějších verzích.

### Jak přesně to funguje

ASF odesílá počáteční data jednou po přihlášení, která obsahuje všechny vlastnosti veřejné listiny. Potom, každých 10 minut ASF pošle jednu, velmi malý požadavek "srdeční", který oznamuje našemu serveru, že bota je stále spuštěn a běží. Pokud z nějakého důvodu nedorazilo srdce, například kvůli síťovým problémům, pak aplikace ASF bude znovu posílat každou minutu, dokud se server nezaregistruje. Tímto způsobem náš server přesně ví, které boty stále běží, a je připraven přijmout obchodní nabídky. ASF také zašle úvodní oznámení podle potřeby, například pokud zjistí, že se náš inventář od předchozího inventáře změnil.

Všechny způsobilé účty ASF, které byly aktivní v **za posledních 15 minut**. Uživatelé jsou seřazeni podle jejich relativní užitečnosti - `MatchEverything` botů, které jsou zobrazeny s `Jakýkoliv` bannerem, který přijímá všechny 1:1 obchody, pak jedinečné množství her a konečně počet položek.

### API

ASF STM listing only přijímá ASF boty najednou. Pro tuto chvíli neexistuje způsob, jak vyjmenovat boty třetích stran na náš seznam. protože nemůžeme snadno zkontrolovat jejich kód a zajistit, aby splňoval celou naši obchodní logiku. Účast na seznamu proto vyžaduje nejnovější stabilní verzi ASF, i když může běžet s vlastními **[pluginy](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

Pro spotřebitele na seznamu máme velmi jednoduchý **[`/Api/Listing/boty`](https://asf.justarchi.net/Api/Listing/Bots)** koncový bod, který můžete použít. Zahrnuje všechna data, která máme, kromě inventářů uživatelů, kteří jsou součástí `MatchActively` exkluzivně.

### Zásady ochrany soukromí

Pokud souhlasíte s tím, že budete uvedeni v našem seznamu, povolíte `SteamTradeMatcher` a neodmítnete `PublicListing`jak je uvedeno výše, dočasně uložíme některé údaje vašeho Steam účtu na našem serveru, abychom zajistili očekávanou funkčnost.

Veřejné informace (které Steam poskytuje každé zúčastněné straně) zahrnují:
- Váš Steam identifikátor (ve 64 bitové podobě, pro generování odkazů)
- Vaše přezdívka (pro zobrazení)
- Váš avatar (hash, pro účely zobrazení)

Podmíněné veřejné informace (poskytované Steamem každé zúčastněné straně, pokud splňujete požadavky na seznam), zahrnují:
- Váš **[inventář](https://steamcommunity.com/my/inventory/#753_6)** (aby lidé mohli používat `MatchActively` vůči vašim předmětům).

Soukromé informace (vybrané údaje potřebné pro zajištění funkce) zahrnují:
- Váš **[obchodní token](https://steamcommunity.com/my/tradeoffers/privacy)** (takže vám lidé mimo Váš seznam přátel mohou posílat obchody)
- Nastavení `MatchableTypy` (pro zobrazení a porovnání)
- Nastavení `MatchEverything` (pro zobrazení a porovnání)
- Vaše nastavení `MaxTradeHoldDuration` (takže ostatní lidé vědí, zda jste ochotni přijmout jejich obchody)

Vzhledem k tomu, že jakmile přestanete používat (oznamujte) náš seznam, vaše data budou do 15 minut nedostupná široké veřejnosti, a jinak je uchovávána na našem serveru maximálně dva týdny - vše je automaticky smazáno po tomto období. Není od vás vyžadována žádná akce, aby se tak stalo.

---

## `Aktivní zápas`

Nastavení `MatchActively` je aktivní verze **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** včetně interaktivního párování, ve kterém bude bot odesílat obchody ostatním lidem. Může fungovat samostatně, nebo společně s nastavením `SteamTradeMatcher`. Tato funkce vyžaduje nastavení `LicenseID` , protože používá server třetích stran a placené zdroje pro provoz.

Aby bylo možné této možnosti využít, máte soubor požadavků, které musíte splnit. Minimálně musíte mít **[neomezený](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** účet, **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** je aktivní a alespoň jeden platný typ v `MatchableTypy`jako jsou obchodní karty. Další požadavky zahrnují 2FA aktivní alespoň od 15 dnů, poslední změnu hesla před více než 5 dny, nedostatek jakýchkoli omezení účtů, jako jsou blokování, ekonomické zákazy a zákazy obchodování.

Pokud splníte všechny výše uvedené požadavky, ASF bude pravidelně komunikovat s naším **[veřejným ASF STM seznamem](#publiclisting)** , aby se aktivně shodoval s boty, které jsou aktuálně k dispozici.

Během párování se bota ASF načítá svůj vlastní inventář, pak komunikujte s naším serverem, abyste našli všechny možné `MatchableTypes` shoduje s ostatními, aktuálně dostupnými boty. Díky přímé komunikaci s naším serverem, tento proces vyžaduje jednu žádost a my máme okamžité informace o tom, zda některý z dostupných botů pro nás nabízí něco zajímavého - pokud je nalezen zápas ASF automaticky zašle a potvrdí obchodní nabídku.

Tento modul má být transparentní. Shoda začne přibližně v čase `1` od začátku aplikace ASF a bude se opakovat každou hodinu `6` (je-li to nutné). `MatchActively` funkce je určena k dlouhodobému a pravidelnému měření pro zajištění toho, že aktivně směřujeme k dokončení sad, nicméně lidé, kteří nepoužívají ASF 24/7, mohou také zvážit použití `shody` **[příkazu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** Cílovými uživateli tohoto modulu jsou primární účty a účty "stash", i když ji může použít jakýkoliv bot, který není nastaven na `MatchEverything`. Kromě toho boti s více než `500000` nejsou přijímáni k vyrovnání z důvodu nadměrného režijního zisku, v tomto případě doporučujeme rozdělit váš inventář na několik účtů.

ASF dělá vše, co je v jeho silách, aby se minimalizovalo množství požadavků a tlaků vytvořených pomocí této možnosti, zatímco zároveň maximalizuje účinnost shodnosti se s horním limitem. Přesný algoritmus výběru botů, které budou odpovídat a jinak uspořádat celý proces, je podrobností provádění ASF a může se změnit, pokud jde o zpětnou vazbu, situaci a možné budoucí nápady.

Současná verze algoritmu dělá ASF prioritu `Jakékoliv` boty první. zejména ty, z nichž jsou jejich položky oddíly, s větší rozmanitostí. Po vypršení `Jakékoliv` boty se ASF přesune do `Fair` na základě stejného pravidla rozmanitosti. ASF se pokusí porovnat alespoň jednou každého dostupného bota, abychom se ujistili, že nám při možném nastavení postupu chybí.

`MatchActively` bere v úvahu boty, které jste na černé listině při obchodování skrze `tbadd` **[příkaz](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** a nepokusí se je aktivně propojit. To lze použít k výpovědi ASF, které boty by se nikdy neměly shodovat, i když by pro nás měly potenciální dupy.

ASF také učiní vše, co je v jejích silách, aby zajistila, že obchodní nabídky projdou. Při příštím běhu, což se obvykle děje za 6 hodin, ASF zruší všechny dosud nepřijaté obchodní nabídky, a deupřednostňovat steamIDy, které se na nich podílejí, aby snad nejdříve upřednostňovali aktivnější roboty. Jenže pokud jsou starostliví roboti poslední, kteří potřebujeme, stále se pokusíme je vyrovnat (znovu).

---

### Proč potřebuji `LicenseID` , abych mohl používat `MatchActively`? Nebyl předtím zdarma?

Komise proto dospěla k závěru, že opatření č. 1 a 2 představují státní podporu ve smyslu čl. 107 odst. 1 Smlouvy. Zdrojový kód `ItemsMatcher` pluginu, a proto `MatchActively` je k dispozici v našem úložišti, zatímco program ASF je zcela nekomerční, neděláme nic z příspěvků, vytváření nebo publikování. Během posledních 7 let získala ASF obrovské množství vývoje, a stále se zlepšuje a zlepšuje s každou měsíční stabilní verzí, většinou jednou osobou, **[JustArchi](https://github.com/JustArchi)** - nejsou připojeny žádné řetězce. Jediné finanční prostředky, které dostáváme, jsou z nepovinných příspěvků, které pocházejí od našich uživatelů.

Po velmi dlouhou dobu, do října 2022, `MatchActively` byla funkce součástí jádra ASF a k dispozici pro každého k použití. V říjnu 2022, Valve, společnost za Steamem, nastavil velmi přísné limity rychlosti načítání zásob jiných botů - které způsobily zcela zlomení předchozích funkcí, bez možnosti řešení tohoto problému. Proto vzhledem ke skutečnosti, že se prvek stal zcela nefunkční, aniž by šance na jeho opravu, muselo být odstraněno z jádra ASF jako zastaralé.

`MatchActively` byl vzkříšen jako součást oficiálního `ItemsMatcher` , který dále zlepšuje ASF aktivními kartami odpovídajícími funkce, zakládat se na zcela přepracovaném pojetí. Obnovení `MatchActively` vyžadováno od nás **mimořádné množství práce** pro vytvoření ASF backend, zcela nová služba hostovaná na serveru, s více než stovkou placených zástupných pracovníků připojených k řešení zásob, všechny výhradně, aby mohli klienty ASF využívat `MatchActively` jako předtím. Vzhledem k množství vykonané práce, stejně jako zdroje, které nejsou zdarma a vyžadují, abychom je platili na měsíčním základě (doména, server, zástupné znaky), Rozhodli jsme se nabídnout tuto funkci našim sponzorům, tzn. lidem, kteří již každý měsíc podporují projekt ASF, díky čemuž můžeme tyto placené prostředky uvolnit.

Naším cílem není z něj profitovat, ale spíše pokrýt **měsíční náklady** , které jsou výlučně spojeny s nabídkou této možnosti - to je důvod, proč ji v zásadě nabízíme za nic, ale musíme za to trochu účtovat, protože nemůžeme platit stovky dolarů z našich kapes každý měsíc, jen aby vám to bylo k dispozici. Nejsme opravdu v pozici, abychom diskutovali také o ceně, je to Valv, který nás tyto náklady přinutil, a alternativou není tato funkce vůbec k dispozici, který se samozřejmě použije, pokud se rozhodnete, z nějakého důvodu, že nemůžete odůvodnit použití našeho pluginu za těchto podmínek.

V každém případě chápeme, že `MatchActively` není pro všechny, a doufáme, že také pochopíte, proč ho nemůžeme zdarma nabídnout. Pokud by nikdo neměl zájem na tom, aby pomohl pokrýt náklady na tuto funkci, jednoduše by neexistoval, Byli bychom nuceni snižovat měsíční výdaje, které nikdo nechce udržovat. Naštěstí jsme v lepší pozici a můžete se sami rozhodnout, zda jste ochotni použít `MatchActively` za těchto podmínek, nebo ne.

---

### Jak mohu získat přístup?

`ItemsMatcher` je nabízen v rámci měsíční úrovně $5+ sponzorů na **[JustArchi GitHub](https://github.com/sponsors/JustArchi)**. Je také možné stát se jednorázovým sponzorem, i když v tomto případě bude licence platná pouze po jeden měsíc (s možností prodloužení stejným způsobem). Jakmile se stanete sponzorem $5 úrovně (nebo vyšší), přečtěte si **[konfiguraci](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** pro získání a vyplnění `LicenseID`. Poté stačí povolit `MatchActively` v `TradingPreferences` vybraného bota.

Licence umožňuje odesílat na server omezené množství požadavků. $5 tier umožňuje použít `MatchActively` pro jeden účet bota (4 žádosti denně), a každý další $5 přidá další dva účty bota (8 žádostí denně). Například, pokud ho chcete spustit na třech účtech, bude to pokryto úrovní $10 a vyšší.