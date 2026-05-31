# Zastaralé

Děláme vše, co je v našich silách, abychom dodržovali konzistentní politiku deprese a učinili tak rozvoj i používání mnohem důslednější.

---

## Co je zastaralé?

Deprese je proces menších nebo větších průlomových změn, které způsobují, že dříve používané možnosti, argumenty, funkce nebo případy použití jsou zastaralé. Deprese obvykle znamená, že daná věc byla jednoduše přepsána do jiné (podobné) podoby. a měli byste se včas ujistit, že na něj uděláte vhodný přepínač. V tomto případě se jednoduše přesouvá na vhodnější místo.

ASF se mění rychle a vždy stává, že se zlepšuje. To bohužel znamená, že můžeme změnit nebo přesunout některé existující funkce do jiného segmentu programu, abychom mohli využívat nových funkcí, slučitelnost nebo stabilita. Díky tomu se nemusíme držet zastaralých ani bolestně špatných rozvojových rozhodnutí, která jsme učinili před lety. Vždy se snažíme poskytnout přiměřenou náhradu, která odpovídá očekávanému použití dříve dostupné funkce. Proto je deprese většinou neškodná a vyžaduje drobné opravy k předchozímu použití.

---

## Stupně zpomalení

ASF bude následovat 2 fáze deprese a přechod bude mnohem jednodušší a méně obtížný.

### Fáze 1

První fáze se stane, jakmile se daná funkce stane zastaralou, s okamžitou dostupností jiného řešení (nebo žádnou, pokud neexistují plány na její znovuzavedení).

Během této fáze bude ASF při použití zastaralé funkce vytisknout příslušné varování. Dokud to bude možné, ASF se pokusí napodobit staré chování a zůstat s ním kompatibilní. ASF bude nadále ve fázi 1 týkající se této funkčnosti alespoň do další stabilní verze. Toto je okamžik, kdy - doufejme, aniž byste porušili kompatibilitu - můžete ve všech svých nástrojích a vzorech provést vhodný přepínač, abyste uspokojili nové chování. Můžete potvrdit, zda jste udělali všechny příslušné změny, když již nevidíte varování o zastaralosti.

### Fáze 2

Fáze 2 je naplánována po etapě 1, která je vysvětlena výše, a je uvolněna ve stabilním uvolnění. Tato fáze zavádí úplné odstranění zastaralých funkcí, což znamená, že ASF nebude ani uznávat, že se pokoušíte použít zastaralou funkci, natož jej respektovat, protože v aktuálním kódu jednoduše neexistuje. Aplikace ASF již nebude vytisknout žádné varování, protože již nerozpozná, co se snažíte udělat.

---

## Summary

Máte více či méně **celý měsíc** , abyste mohli provést vhodný přepínač, která by měla být více než dostatečná, i když jste náhodný uživatel ASF. Po uplynutí této doby ASF již nezaručuje, že stará nastavení budou mít jakýkoli účinek (etapa 2), efektivně provádět určité funkce tak, aby zcela nefungovaly, aniž byste si toho všimli. Pokud spustíte ASF po více než měsíci nečinnosti, je doporučeno pro **[začít od začátku](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** znovu, nebo si přečtěte všechny seznamy změn, které jste zmeškali a ručně přizpůsobte své použití stávajícímu.

Ve většině případů nezohlednění výstražného upozornění nezpůsobí nepoužitelnost obecné funkce ASF ale spíše se vracet do výchozího chování (které může nebo nemusí odpovídat vašim osobním preferencímům).

---

## Příklad

Přesunuli jsme pre-V3.1.2.2 `--server` **[argument příkazové řádky](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** do `IPC` **[vlastnosti globální konfigurace](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**.

### Fáze 1

1. etapa se stala ve verzi V3.1.2.2, kde jsme přidali odpovídající varování pro použití `--server`. Argument Now-obsolete `--server` byl automaticky namapován do `IPC: true` global config property, efektivně jednat přesně stejně jako starý `--server` přepínat na čas. To všem umožnilo provést vhodný přepínač dříve, než ASF přestane přijímat starý argument.

### Fáze 2

Fáze 2 se stala ve verzi V3.1.3.0, hned po verzi V3.1.2.9 stabilní, s druhou fází vysvětlenou výše. 2. fáze způsobila, že ASF vůbec přestala rozpoznávat argument `--server` , s ním zachází jako se všemi ostatními neplatnými argumenty, které již nemají žádný vliv na program. Pro lidi, kteří stále nezměnili své používání `--server` na `IPC: true`, způsobil, že IPC přestal fungovat úplně, neboť ASF již neprováděla vhodné mapování.