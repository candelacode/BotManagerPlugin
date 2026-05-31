# Komunikacja zdalna

W niniejszej części omówiono kwestię komunikacji na odległość, którą ASF obejmuje, w tym wyjaśnienie, w jaki sposób może mieć na nią wpływ. Chociaż nic poniżej nie uważamy za złośliwe lub w inny sposób niechętne i ani nie jesteśmy prawnie zobowiązani do jego ujawniania, ani chcemy, abyś lepiej zrozumiał funkcjonalność programu, zwłaszcza w odniesieniu do Twojej prywatności i udostępnianych danych.

## Steam

ASF komunikuje się z siecią Steam (**[serwery CM](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), oraz **[Steam API](https://steamcommunity.com/dev)**, **[Sklep Steam](https://store.steampowered.com)** i **[Społeczność Steam](https://steamcommunity.com)**

Nie można wyłączyć żadnej z powyższych komunikacji. ponieważ fundament ASF opiera się na celu zapewnienia jego podstawowej funkcjonalności. Musisz powstrzymać się od używania ASF, jeśli nie jesteś wygodny z powyższym.

## Grupa Steam

ASF komunikuje się z naszym **[grupą Steam](https://steamcommunity.com/groups/archiasf)**. Grupa dostarcza Ci ogłoszenia, zwłaszcza nowe wersje, krytyczne problemy, problemy Steam i inne rzeczy, które są ważne dla aktualizowania społeczności. Pozwala również na wykorzystanie naszego wsparcia technicznego poprzez zadawanie pytań, rozwiązywanie problemów, zgłaszanie problemów lub proponowanie ulepszeń. Domyślnie konta używane w ASF automatycznie dołączą do grupy po zalogowaniu.

You can decide to opt-out of joining the group by disabling `SteamGroup` flag in bot's **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** settings.

## GitHub

ASF komunikuje się z **[GitHub API](https://api.github.com)** w celu pobrania **[ASF wydanie](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** dla funkcji aktualizacji. This is done as part of auto-updates (if you've kept **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** enabled), as well as `update` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. You can influence ASF's communication with GitHub through **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** property - setting it to `None` will result in disabling entire update functionality, including GitHub communication in this regard.

## Serwer ASF

ASF komunikuje się z **[naszym własnym serwerem](https://asf.justarchi.net)** dla bardziej zaawansowanej funkcjonalności. Obejmuje to w szczególności:
- Weryfikowanie sum kontrolnych wersji ASF pobranych z GitHub w oparciu o naszą niezależną bazę danych, aby upewnić się, że wszystkie pobrane wersje są zgodne z prawem (wolne od złośliwego oprogramowania, Ataki MITM lub inne manipulacje)
- Pobieranie listy złych botów do filtrowania jeśli masz włączone globalne ustawienie `FilterBadBots`.
- Ogłaszanie bota w **[naszej liście](https://asf.justarchi.net/STM)** jeśli włączyłeś `SteamTradeMatcher` w **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** i spełnij inne kryteria
- Pobieranie obecnie dostępnych botów do wymiany z **[naszej listy](https://asf.justarchi.net/STM)** jeśli włączyłeś `Dopasowanie` w **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** i spełniasz inne kryteria

Jako środek bezpieczeństwa nie jest możliwe wyłączenie weryfikacji sumy kontrolnej dla wersji ASF. Jednakże, możesz wyłączyć auto-aktualizacje całkowicie jeśli chcesz tego uniknąć, jak opisano powyżej w sekcji GitHub.

Możesz wyłączyć `FilterBadBots` jeśli chcesz uniknąć pobierania listy z serwera.

You can decide to opt-out of being announced in the listing by disabling `PublicListing` flag in bot's **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** settings. This might be useful if you'd like to run `SteamTradeMatcher` bot without being announced at the same time.

Pobieranie botów z naszej listy jest obowiązkowe dla ustawień `Dopasowanie` , musisz wyłączyć to ustawienie, jeśli nie chcesz tego zaakceptować.