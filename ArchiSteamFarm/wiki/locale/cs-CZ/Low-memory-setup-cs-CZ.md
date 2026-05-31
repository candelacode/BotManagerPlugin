# Nastavení pro nízký výkon

Toto je pravý opak **[vysoce výkonného nastavení](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup)** a pokud chcete snížit využití paměti ASF, obvykle je chcete sledovat, náklady na snížení celkové výkonnosti.

---

ASF je velmi lehká na zdrojích podle definice, v závislosti na tom, jak používáte dokonce 128 MB VPS s Linuxem, Ačkoliv se toto nízké chování nedoporučuje a může vést k různým problémům. ASF se sice nebojí žádat OS o více paměti, pokud je tato paměť potřebná k tomu, aby ASF fungovala optimální rychlostí.

ASF jako aplikace se snaží být co nejvíce optimalizovaná a efektivní, což také bere v úvahu zdroje, které jsou během provádění využívány. Pokud jde o paměť, ASF dává přednost výkonu před spotřebou paměti, což může mít za následek dočasnou paměť "spiknutí", kterou lze pozorovat např. s účty, které mají 3+ stránek s odznaky, protože ASF bude načítat a analyzovat první stránku, čtěte z ní celkový počet stránek, poté spustit úkol načíst pro každou další stránku, což má za následek souběžné načítání a analyzování zbývajících stránek. Toto "mimořádné" využití paměti (ve srovnání s minimem holého provozu pro operaci) může dramaticky urychlit provádění a celkový výkon, náklady na zvýšené využití paměti, které jsou potřebné k souběžnému provádění všech těchto věcí. Podobná věc se děje se všemi ostatními obecnými úlohami aplikace ASF, které mohou být spuštěny současně, např. se zahrnutím aktivních obchodních nabídek může ASF analyzovat všechny najednou, protože jsou na sobě navzájem nezávislé. Kromě toho ASF (C# runtime) nebude **** ihned poté vrátit nevyužitou paměť zpět na OS, které si můžete rychle všimnout ve formě aplikace ASF a získávat jen stále více paměti, ale (také) nikdy tuto paměť nevrátit. Někteří lidé už to mohou považovat za sporné, možná dokonce mají podezření na únik paměti, ale nebojte se, to vše lze očekávat.

ASF je mimořádně dobře optimalizovaný a co nejvíce využívá dostupné zdroje. Využití vysoké paměti ASF neznamená, že ASF aktivně používá **** , kterou paměť a **potřebuje**. Velmi často bude ASF pro budoucí akce udržovat přidělenou paměť jako "místnost", protože můžeme drasticky zlepšit výkon, pokud nepotřebujeme požádat OS o každý blok paměti, který se chystáme použít. The runtime should automatically release unused ASF memory back to OS when OS will **truly** need it. **[Nevyužitá paměť je promrhaná paměť](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. You run into issues when the memory you **need** is higher than the memory that is available for you, not when ASF keeps some extra allocated with purpose of speeding up functions that will execute in a moment. Probíhají problémy, když vaše linuxové jádro ukončí proces ASF kvůli OOOM (nepaměti), ne když budete vidět proces ASF jako spotřebitele top paměti v `htop`.

**[proces sběru odpadků](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** používaný v ASF je velmi složitý mechanismus, dostatečně chytrý, aby bral v úvahu nejen samotné ASF, ale i vaše OS a další procesy. Když máte spoustu volné paměti, ASF se bude ptát, co je potřeba ke zlepšení výkonu. To může být dokonce až 1 GB (s GC) Když se vaše paměť OS blíží plně, ASF automaticky uvolní některé z nich zpět do operačního systému, aby pomohla situaci nastavit, což může vést k celkovému využití paměti ASF až na hodnotu 50 MB. Rozdíl mezi 50 MB a 1 GB je obrovský, ale tak je rozdíl mezi malými 512 MB VPS a obrovským vyhrazeným serverem s 32 GB. Dokáže-li ASF zaručit, že tato paměť bude užitečná, a zároveň to právě teď nic jiného nevyžaduje, Dá přednost tomu, aby se udržela a automaticky optimalizovala na základě rutinů, které byly provedeny v minulosti. GC používané v ASF je samoladící a dosáhne lepších výsledků, čím déle proces běží.

To je také důvod, proč se procesová paměť ASF liší od nastavení až po nastavení. jelikož ASF udělá vše pro to, aby využívala dostupné zdroje v **co nejúčinnějším způsobem**, a ne fixním způsobem, jak to bylo provedeno během Windows XP časů. Skutečné (skutečné) využití paměti, které ASF používá, lze ověřit pomocí `statistiky` **[příkazu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, a obvykle se pohybuje okolo 4 MB pro jen pár botů, až 30 MB, pokud používáte věci jako **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** a další pokročilé funkce. Mějte na paměti, že příkaz `statistiky` obsahuje také bezplatnou paměť, která ještě nebyla vrácena garbage collector. Všechno ostatní je sdílená runtime paměť (asi 40-50 MB) a místnost pro spuštění (různé). To je také důvod, proč tentýž systém ASF může v prostředí VPS s nízkou pamětí používat jen 50 MB, při používání až 1 GB na vašem počítači. ASF se aktivně přizpůsobuje vašemu prostředí a pokusí se najít optimální bilanci, aby váš operační systém nebyl vystaven tlaku, ani neomezovat jeho vlastní výkon, když máte spoustu nevyužité paměti, která může být použita.

---

Samozřejmě, že existuje mnoho způsobů, jak můžete pomoci ukázat ASF správným směrem, pokud jde o paměť kterou chcete používat. Obecně platí, že pokud to nepotřebujete, je nejlepší nechat sbírku odpadků pracovat v míru a dělat, co považuje za nejlepší. Ale to není vždy možné, například pokud váš linuxový server také hostuje několik webových stránek, MySQL databázi a PHP pracovníky, pak si opravdu nemůžete dovolit ASF se zmenšovat, když běžíte blízko OOM, protože je obvykle příliš pozdě a degradace výkonu přichází dříve. Obvykle to je, když byste mohli mít zájem o další ladění, a proto čtu tuto stránku.

Níže uvedené návrhy jsou rozděleny do několika kategorií s různými obtížemi.

---

## Nastavení ASF (snadné)

Pod triky **nemají negativní vliv na výkon** a mohou být bezpečně použity na všechna nastavení.

- Pokud je to možné, spusťte **[generickou verzi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** ASF. Obecná verze aplikace ASF používá méně paměti, protože neobsahuje běh uvnitř sítě, nepřichází jako jediný soubor, nemusí se rozbalovat při běhu, a proto je menší a má menší paměťovou stopu. OS-specifické balíčky jsou vhodné a pohodlné, ale také jsou spojeny se vším, co je potřeba ke spuštění ASF, To je něco, co se můžete postarat o sebe a místo toho použít generickou variantu ASF.
- Nikdy nespustit více než jednu instanci ASF. ASF má zpracovávat neomezený počet robotů najednou, pokud nezavazujete každou instanci ASF k různým rozhraním/IP adresám, měli byste mít přesně **1** ASF proces s více boty (je-li to nutné).
- Využijte `ShutdownOnFarmingFinished` v `FarmingPreferences`. Aktivní bot bere více surovin než deaktivovaných. Není to významná úspora, protože stav bota musí být stále zachován, ale ukládáte určité množství zdrojů, zejména všechny zdroje související se sítěmi, jako je TCP sockets. V případě potřeby můžete vždy vychovávat další boty.
- Číslo svých botů je nízké. Není `Povolena` instance bota má méně zdrojů, protože ASF se neobtěžuje spustit. Také mějte na paměti, že ASF musí vytvořit bota pro každou z vašich konfigurací, proto pokud nepotřebujete `spustit` zadaného bota a chcete uložit nějakou další paměť, můžete dočasně přejmenovat `bot. syn` např. `Bot.json.bak` , aby se zabránilo vytváření stavu pro vaši zakázanou instanci bota v ASF. Tímto způsobem jej nebudete moci `spustit` bez jeho přejmenování, ale ASF se také nebude obtěžovat udržování stavu tohoto bota v paměti, ponechá prostor pro jiné věci (velmi malá úspora, v 99. % případů, které byste se s tím neměli obtěžovat, stačí nechat své boty s `povolit` z `false`).
- Vyladit své konfigurace. Zejména globální ASF konfigurace má mnoho proměnných, které je třeba upravit, například zvýšením `LoginLimiterDelay` budete své boty zvyšovat pomaleji, které umožní načíst odznaky do té doby na rozdíl od rychlejší výchovu vašich botů, který bude brát více zdrojů, protože více robotů bude zároveň dělat větší práci (jako je parsování odznaků). Čím méně práce je třeba vykonat současně - tím méně paměti.

To je několik věcí, které můžete mít na paměti při nakládání s využíváním paměti. Tyto věci však nemají při používání paměti žádnou "klíčovou" látku, protože využití paměti pochází převážně z věcí, které musí ASF řešit, a nikoli z vnitřních struktur používaných pro chov karet.

Nejvíce náročnějších zdrojů jsou:
- Analýza stránky s odznaky
- Analýza inventáře

To znamená, že paměť nejvíce vystřelí v případě, že aplikace ASF řeší čtení stránek s odznaky, a když se zabývá svým inventářem (např. . posílání obchodu nebo spolupráce se STM). Je to proto, že ASF se musí vypořádat s obrovským množstvím dat - využití paměti vašeho oblíbeného prohlížeče při spouštění těchto dvou stránek nebude o nic menší. Omlouváme se, ale to funguje - snížení počtu vašich odznakových stránek a udržení nízkého počtu položek v inventáři, které mohou pro jistotu pomoci.

---

## Ladění běhu (pokročilé)

Pod triky **zahrnují rozklad výkonu** a měly by být používány s opatrností.

Doporučený způsob použití těchto nastavení je přes vlastnosti prostředí `DOTNET_`. Samozřejmě můžete použít i jiné metody, např. `runtimeconfig. syn`, ale některé nastavení nelze nastavit tímto způsobem, a navíc ASF nahradí váš vlastní `runtimeconfig. syn` vlastní při příští aktualizaci, proto doporučujeme vlastnosti prostředí, které můžete snadno nastavit před spuštěním procesu.

.NET runtime umožňuje **[vyladit garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** mnoha způsoby, efektivně dolaďovat proces GC podle vašich potřeb. Následující vlastnosti jsme zdokumentovali, které jsou podle našeho názoru obzvláště důležité.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Určuje povolené použití GC jako procento celkové fyzické paměti.

"tvrdé" paměťový limit pro proces ASF, toto nastavení nastavuje GC pouze pro podmnožinu celkové paměti a ne pro všechny. Může se stát užitečným zejména v různých situacích podobných serverům, kde můžete vyčlenit fixní procento paměti vašeho serveru pro ASF, ale nikdy víc než to. Upozorňujeme, že omezení paměti aplikace ASF nezpůsobí, že všechny tyto požadované příděly paměti zmizí, Proto by příliš nízká hodnota mohla mít za následek vyčerpání paměťových scénářů, kdy bude proces ASF nucen ukončit.

Na druhé straně, nastavení této hodnoty dostatečně vysoké je perfektní způsob, jak zajistit, aby aplikace ASF nikdy nepoužívala více paměti, než si můžete realisticky dovolit, dát svému počítači dýchací místnost i pod těžkým zatížením, přičemž stále umožňuje programu vykonávat svou práci co nejúčinněji.

### [`GCConservememory`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Konfiguruje garbage collector, aby zachoval paměť na úkor častějších garbage collectionů a možná i delší doby pozastavení.

Lze použít hodnotu mezi 0-9. Čím větší hodnota, tím více GC optimalizuje paměť nad výkonem.

### [`GCHighMemPProcent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Určuje množství použité paměti, po kterém se GC stává agresivnějším.

Toto nastavení nakonfiguruje práh paměti celého OS, který po tomto přechodu projde, způsobí, že se GC stane agresivnější a pokusí se pomoci OS snížit zatížení paměti spuštěním intenzivnějšího GC procesu a uvolněním více volné paměti zpět na OS. Je dobrý nápad nastavit tuto vlastnost na maximální množství paměti (v procentech), které považujete za "kritickou" pro celý váš operační výkon. Výchozí hodnota je 90 % a obvykle ji chcete udržet v 80-97 % rozpětí. vzhledem k tomu, že příliš nízká hodnota nezpůsobí zbytečnou agresi z GC a zhoršení výkonu z jakéhokoli důvodu, zatímco příliš vysoká hodnota bude zbytečně zatěžovat váš OS, zvažujíce se, že ASF by mohla uvolnit část své paměti pro pomoc.

### **[`Úroveň GCLatencyLevel`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Určuje úroveň latence GC, pro kterou chcete optimalizovat.

Jedná se o nezdokumentovaný majetek, který fungoval mimořádně dobře pro ASF, Omezením velikosti GC generací a výsledkem je, že je GC čistí častěji a agresivněji. Výchozí (vyvážená) úroveň latence je `1`, ale můžete použít `0`, což bude ladit pro využití paměti.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> Když nastavíme nastavení, budeme odhodlaný prostor úžeji oříznout agresivněji pro ephemerální sebe. Používá se pro spuštění mnoha serverových procesů, kde chtějí zachovat co nejmenší spáchanou paměť.

To nabízí jen malé zlepšení, ale může to učinit GC ještě agresivnějšími, když bude systém nízký na paměti, zejména pro ASF, který velmi silně využívá úloh v rámci koše.

---

Vybrané vlastnosti můžete povolit nastavením vhodných proměnných prostředí. Např. na Linuxu (shell):

```shell
# Nezapomeňte doladit ty, pokud plánujete jejich použití
exportovat DOTNET_GCHeapHardLimitPercent=0x4B # 75% jako hex
exportovat DOTNET_GCHighMemPercent=0x50 # 80% jako hex

exportovat DOTNET_GCConserveMemory=9
exportovat DOTNET_GCLatencyLevel=0
exportovat DOTNET_gcTrimCommitOnLowMemory=1

. ArchiSteamFarm # Pro OS-specifické sestavení
./ArchiSteamFarm.sh # Pro generické sestavení
```

Nebo na Windows (powershell):

```powershell
# Nezapomeňte je vyladit, pokud je plánujete použít
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% jako hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80% jako hex

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

ArchiSteamFarm.exe # Pro OS-specifické sestavení
.\ArchiSteamFarm.cmd # Pro generické sestavení
```

Zvláště `GCLatencyLevel` bude velmi užitečný, protože jsme ověřili, že runtime skutečně optimalizuje kód pro paměť, a proto výrazně snižuje průměrné využití paměti, i s GC serverem. Je to jeden z nejlepších triků, které můžete použít, pokud chcete výrazně snížit využití paměti ASF, zatímco nedegradujete výkon příliš s `Optimalizací`.

---

## ASF ladění (meziprodukt)

Pod triky **zahrnují vážné zhoršení výkonnosti** a měly by být používány s opatrností.

- Jako poslední možnost si můžete nastavit ASF pro `MinMemoryUsage` prostřednictvím `Optimalizace` **[globální vlastnost konfigurace](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**. Pozorně si přečtěte svůj účel, protože se jedná o závažné zhoršení výkonu téměř bez výhod paměti. Toto je obvykle **poslední věc, kterou chcete udělat**, dlouho poté, co projdete **[běžným laděním](#runtime-tuning-advanced)** , abyste se ujistili, že jste k tomu nuceni. Pokud není pro vaše nastavení absolutně klíčové, odradíme od používání `MinMemoryUsage`, a to i v prostředí s omezenou pamětí.

---

## Doporučená optimalizace

- Začněte z jednoduchých ASF nastavovacích triků, použijte **[generickou variantu ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** a zkontrolujte, zda jste možná jen špatně použili ASF, jako například několikrát spustit proces pro všechny své boty, nebo udržet všechny aktivní, pokud potřebujete jen jednu nebo dvě k automatickému spuštění.
- Pokud to stále nestačí, povolte všechny výše uvedené vlastnosti konfigurace nastavením vhodných proměnných prostředí `DOTNET_`. Zejména `GCLatencyLevel` nabízí významná provozní vylepšení pro malé náklady na výkon.
- Pokud to ani nepomohlo, jako poslední možnost zapněte `MinMemoryUsage` `OptimalizationMode`. To nutí ASF k provedení téměř všeho v synchronně propojené oblasti, zajistit, aby fungovala mnohem pomaleji, ale také nespoléhat se na to, že při paralelním provádění vyvažuje věci.

Ještě více nelze paměť snížit, váš ASF je již značně snížen z hlediska výkonu a vyčerpal jste všechny vaše možnosti, jak kódový, tak i běžných. Zvažte přidání další paměti pro aplikace ASF, což by přineslo velký kus i 128 MB.