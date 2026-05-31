# Wtyczki

ASF zawiera obsługę niestandardowych wtyczek, które mogą być załadowane podczas pracy. Wtyczki pozwalają dostosować zachowanie ASF, na przykład dodając własne komendy, niestandardową logikę handlu lub całą integrację z usługami innych firm i API.

Ta strona opisuje wtyczki ASF z perspektywy użytkowników - wyjaśnienie, użycie i podobne. Jeśli chcesz zobaczyć perspektywę programisty, przesuń **[tutaj](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)**.

---

## Stosowanie

ASF ładuje wtyczki z katalogu `plugins` znajdującego się w folderze ASF. Jest to zalecane ćwiczenie (które staje się obowiązkowe z automatyczną aktualizacją pluginów) do utrzymywania dedykowanego katalogu dla każdej wtyczki, którą chcesz użyć, które mogą być oparte na jego nazwie, np. `MyPlugin`. W ten sposób powstanie ostateczna struktura drzewa `plugins/MyPlugin`. Wreszcie, wszystkie pliki binarne wtyczki powinny być umieszczone wewnątrz dedykowanego folderu, a ASF poprawnie odkryje i użyje wtyczki po ponownym uruchomieniu.

Zwykle deweloperzy pluginów opublikują swoje wtyczki w formie pliku `zip` z binarnymi wewnątrz aplikacji, co oznacza, że powinieneś rozpakować plik zip do własnego dedykowanego podkatalogu wewnątrz katalogu `plugins`.

Jeśli wtyczka została pomyślnie załadowana, zobaczysz jej nazwę i wersję w dzienniku. Powinieneś skonsultować się z twórcami wtyczek w przypadku pytań, problemów lub użycia związanych z wtyczkami, które zdecydowałeś się użyć.

Możesz znaleźć kilka polecanych wtyczek w sekcji **[strona trzecia](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)**.

**Pamiętaj, że wtyczki ASF mogą być złośliwe**. Powinieneś zawsze upewnić się, że używasz pluginów stworzonych przez programistów, których możesz zaufać, nawet z sekcji zewnętrznej powyżej. Deweloperzy ASF nie mogą już gwarantować normalnych korzyści ASF (takich jak brak złośliwego oprogramowania lub brak VAC), jeśli zdecydujesz się korzystać z niestandardowych wtyczek. Musisz zrozumieć, że wtyczki mają pełną kontrolę nad procesem ASF po załadowaniu, ze względu na to, że nie jesteśmy w stanie obsługiwać konfiguracji, które wykorzystują niestandardowe wtyczki, ponieważ nie masz już kodu Vanilla ASF.

---

## Kompatybilność

Depending on plugin's complexity, scope and a lot of other factors, it's entirely possible that it'll require from you to use **[generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** ASF variant, instead of usually recommended **[OS-specific](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. Dzieje się tak, ponieważ wariant specyficzny dla systemu operacyjnego posiada tylko podstawowe funkcje wymagane dla ASF, i twoja wtyczka może wymagać części, które wykraczają poza główny zakres ASF, w wyniku czego są niezgodne z przyciętymi budowlami OS.

Ogólnie rzecz biorąc, podczas korzystania z wtyczek firm trzecich, zalecamy użycie wariantu ogólnego ASF dla maksymalnej kompatybilności. Jednakże nie wszystkie wtyczki mogą wymagać tego - zapoznaj się z informacjami o wtyczce, aby dowiedzieć się, czy musisz używać ogólnego wariantu ASF, czy nie.

---


## Automatyczne aktualizacje

ASF posiada wbudowany mechanizm automatycznej aktualizacji wtyczek. Aby ta funkcja działała przede wszystkim twoja wybrana wtyczka musi **[wspierać](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)** tego mechanizmu. Jeśli załadowałeś wtyczkę obsługującą auto-aktualizacje, ASF poda ją w dzienniku poprawnie podczas inicjalizacji wtyczki, np. "wtyczka została wyłączona z automatycznych aktualizacji" lub "wtyczka została zarejestrowana i włączona dla automatycznych aktualizacji".

Domyślnie automatyczne aktualizacje dla niestandardowych wtyczek są **wyłączone**ze względów bezpieczeństwa. You can configure automatic updates in the config by using **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** and/or **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)**, we recommend to read description of those config properties for more info. It's also nice to note that, like with ASF updates, you can decide to keep automatic updates disabled, and then update on as-needed, manual basis, by issuing `updateplugins` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

Oba podejścia pozwalają na aktualizację żadnych, niektórych lub wszystkich niestandardowych pluginów, które załadowałeś do procesu.