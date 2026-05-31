# Nastavení pro vysoký výkon

Toto je přesný opak **[nastavení](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** s nízkou pamětí, a pokud chcete dále zvýšit výkon ASF (pokud jde o rychlost CPU), obvykle chcete tyto tipy sledovat. Tyto prostředky jsou určeny na pokrytí výdajů na zaměstnance a správních výdajů agentury (hlavy 1 a 2) a provozních výdajů na pracovní program (hlava 3).

---

ASF se již snaží preferovat výkon, pokud jde o obecně vyvážené doladění, Proto není mnoho co můžete udělat pro další zvýšení jeho výkonnosti, i když nejste zcela mimo možnosti. Nicméně mějte na paměti, že tyto možnosti nejsou ve výchozím nastavení povoleny, což znamená, že nejsou dostatečně dobré, aby je považovaly za vyvážené pro většinu použití, Proto byste se měli sami rozhodnout, zda je pro vás přijatelné zvýšení paměti.

---

## Ladění běhu (pokročilé)

Pod triky **zahrnuje seriózní zvýšení paměti** , a proto by měly být používány s opatrností.

Doporučený způsob použití těchto nastavení je přes vlastnosti prostředí `DOTNET_`. Samozřejmě můžete použít i jiné metody, např. `runtimeconfig. syn`, ale některé nastavení nelze nastavit tímto způsobem, a navíc ASF nahradí váš vlastní `runtimeconfig. syn` vlastní při příští aktualizaci, proto doporučujeme vlastnosti prostředí, které můžete snadno nastavit před spuštěním procesu.

.NET runtime umožňuje **[vyladit garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** mnoha způsoby, efektivně dolaďovat proces GC podle vašich potřeb. Následující vlastnosti jsme zdokumentovali, které jsou podle našeho názoru obzvláště důležité.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Konfiguruje, zda aplikace používá garbage collection nebo garbage collection.

Přesnou specifičnost GC serveru si můžete přečíst na **[základech garbage collection](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF standardně používá garbage collection z pracovní stanice. To je způsobeno především dobrou rovnováhou mezi využitím paměti a výkonem, což je více než dost jen pro několik robotů, jako obvykle jediné současně aktuální vlákno GC je dostatečně rychlé na to, aby bylo možné zpracovat celou paměť přidělenou ASF.

Dnes však máme mnoho jader CPU, z nichž ASF může mít velký prospěch. mít vyhrazené GC vlákno pro každý CPU vCore, které je k dispozici. To může výrazně zlepšit výkon při těžkých úlohách ASF, jako je parsování stránek s odznaky nebo inventář, protože každý CPU vCore může pomoci, na rozdíl od pouhých 2 (hlavní a GC). Server GC je doporučen pro stroje se 3 vCores a více, pracovní stanice GC je automaticky vynucena, pokud má váš počítač pouze 1 vCore a pokud máte přesně 2, pak můžete uvažovat o pokusu obojí (výsledky se mohou lišit.

Server GC sám nemá za následek velké zvýšení paměti tím, že je právě aktivní, má ale mnohem větší velikost generace, a proto je mnohem línější, pokud jde o vracení paměti OS. Můžete se nacházet ve sladkém místě, kde se server GC výrazně zvyšuje výkon a chcete ho nadále používat, ale zároveň si nemůžete dovolit toto obrovské zvýšení paměti, které je způsobeno jeho používáním. Naštěstí pro vás je nastavení "nejlepšího z obou světa", pomocí GC serveru s **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** nastavena na `0`, které stále umožní server GC, ale omezí velikost generací a více se zaměří na paměť. Případně můžete také experimentovat s jinou nemovitostí, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**nebo i s oběma z nich.

Pokud však paměť není pro vás problém (GC stále bere v úvahu vaši dostupnou paměť a vylepšení samotné), je mnohem lepší nápad, že tyto vlastnosti vůbec nemění, výsledkem je dosažení lepšího výkonu.

---

Vybrané vlastnosti můžete povolit nastavením vhodných proměnných prostředí. Např. na Linuxu (shell):

```shell
exportovat DOTNET_gcServer=1

./ArchiSteamFarm # pro OS-specifické sestavení
./ArchiSteamFarm.sh # pro obecné sestavení
```

Nebo na Windows (powershell):

```powershell
$Env:DOTNET_gcServer=1

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

---

## Doporučená optimalizace

- Ujistěte se, že používáte výchozí hodnotu `OptimizationMode` , což je `MaxPerformance`. Toto je zdaleka nejdůležitější nastavení, protože používání `MinMemoryUsage` má dramatické dopady na výkon.
- Povolit GC serveru. GC serveru lze okamžitě považovat za aktivní díky významnému zvýšení paměti v porovnání s GC stanicí. Toto vytvoří GC vlákno pro každé CPU vlákno, které má váš počítač za účelem provádění GC operací paralelně s maximální rychlostí.
- Pokud si nemůžete dovolit zvýšení paměti kvůli serverové GC, zvažte úpravu **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** a/nebo **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** pro dosažení "nejlepšího z obou světa". Pokud si však vaše paměť může dovolit, pak je lepší ho ve výchozím nastavení ponechat - server GC již vyladí sám během běhu a je dostatečně chytrý na to, aby používal méně paměti, když jej váš OS skutečně potřebuje.

Použití výše uvedených doporučení vám umožňuje mít vyšší výkon ASF, který by měl být rychlý i se stovkami nebo tisíci povolených botů. CPU by již neměl být problémem, protože ASF může v případě potřeby využít celou energii procesoru, což je nezbytné pro minimalizaci potřebného času. Dalším krokem by byly aktualizace CPU a RAM nebo rozdělení pracovní zátěže na několik serverů a instancí ASF.