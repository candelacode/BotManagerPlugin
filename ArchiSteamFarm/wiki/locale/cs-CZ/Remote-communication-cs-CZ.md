# Vzdálená komunikace

Tato část je rozpracována na dálkové komunikaci, která zahrnuje ASF, včetně dalšího vysvětlení, jak ji lze ovlivnit. I když nic níže nepovažujeme za škodlivé nebo jinak nechceme a ani my nejsou ze zákona povinni jej zveřejnit, chceme, abyste lépe pochopili funkčnost programu, zejména pokud jde o vaše soukromí a sdílená data.

## Pára

ASF komunikuje se sítí Steam (**[CM servery](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), a **[Steam API](https://steamcommunity.com/dev)** **[Steam store](https://store.steampowered.com)** a **[komunita Steam](https://steamcommunity.com)**.

Není možné zakázat žádnou z výše uvedených komunikací, protože je to základ ASF, je založen na jeho základní funkčnosti. Budete muset upustit od používání aplikace ASF, pokud se vám nelíbí.

## Steam skupina

ASF komunikuje s naší **[skupinou Steam](https://steamcommunity.com/groups/archiasf)**. Skupina vám poskytuje oznámení, zejména nové verze, kritické problémy, problémy se Steamem a další věci, které jsou důležité pro zachování komunity. Umožňuje vám také využít naši technickou podporu a klást otázky, řešit problémy, oznamovat problémy nebo navrhovat zlepšení. Ve výchozím nastavení se účty používané v ASF automaticky připojí ke skupině při přihlášení.

Můžete se rozhodnout, že se zapojíte do skupiny tím, že zakážete `SteamGroup` v nastavení bota **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)**.

## GitHub

ASF komunikuje s **[GitHubem API](https://api.github.com)** pro načtení **[ASF verze](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** pro funkci aktualizace. To se provádí jako součást automatických aktualizací (pokud jste drželi **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** povolena), kromě `aktualizace` **[příkazu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Můžete ovlivnit komunikaci ASF s GitHub prostřednictvím **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** - nastavení na `Žádný` bude mít za následek vypnutí celé funkce aktualizace, včetně komunikace GitHub v tomto ohledu.

## Server ASF

ASF komunikuje s **[naším vlastním serverem](https://asf.justarchi.net)** pro pokročilejší funkci. To zahrnuje zejména:
- Ověřování kontrolních součtů ASF sestavení stažených z GitHub proti naší vlastní nezávislé databázi, aby bylo zajištěno, že všechny stažené sestavení jsou legitimní (bez malwaru), Útoky MITM nebo jiná nedovolená manipulace
- Načítání seznamu špatných botů pro filtrování, pokud jste si ponechali `FilterBadBots` povoleno nastavení globálního nastavení.
- Oznamování vašeho bota v **[náš seznam](https://asf.justarchi.net/STM)** , pokud jste povolili `SteamTradeMatcher` v **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** a splňují další kritéria
- Stahování aktuálně dostupných botů k obchodování z **[našeho seznamu](https://asf.justarchi.net/STM)** , pokud jste povolili `MatchActively` v **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** a splňují další kritéria

Jako bezpečnostní opatření není možné zakázat ověřování kontrolního součtu pro sestavení aplikace ASF. Pokud se však chcete vyhnout automatickým aktualizacím, jak je popsáno výše v části GitHub, můžete zcela zakázat.

Můžete zakázat nastavení `FilterBadBots` , pokud chcete zabránit načítání seznamu ze serveru.

Můžete se rozhodnout, že se nepřihlásíte do seznamu tím, že zakážete nastavení `PublicListing` v **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** To může být užitečné, pokud chcete spustit `SteamTradeMatcher` , aniž byste byli současně oznámeni.

Stahování botů z našeho seznamu je povinné pro nastavení `MatchActively` , budete muset toto nastavení zakázat, pokud to nechcete přijmout.