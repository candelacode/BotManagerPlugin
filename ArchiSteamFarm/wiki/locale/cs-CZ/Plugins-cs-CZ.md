# Pluginy

ASF obsahuje podporu pro vlastní pluginy, které mohou být načteny během běhu. Pluginy vám umožňují přizpůsobit chování ASF, například přidáním vlastních příkazů, vlastní obchodní logiky nebo celou integraci se službami třetích stran a API.

Tato stránka popisuje ASF pluginy z pohledu uživatelů - vysvětlení, použití a podobně. Pokud chcete zobrazit perspektivu vývojáře, přesuňte **[zde](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)**.

---

## Použití

ASF načítá pluginy z `pluginů` adresáře umístěného ve vaší složce ASF. Je to doporučená praxe (která se stává povinnou s automatickými aktualizacemi pluginu) pro správu adresáře pro každý plugin, který chcete použít, který může být založen na jeho jménu, jako je `MyPlugin`. To vyústí v konečnou strukturu stromu `pluginů/MyPlugin`. Konečně všechny binární soubory pluginu by měly být umístěny uvnitř této vyhrazené složky a ASF bude po restartu správně objevovat a používat váš plugin.

Vývojáři pluginů obvykle zveřejňují své pluginy ve formě `zip` souboru s binárními soubory, což znamená, že byste měli rozbalit tento soubor do svého vlastního podadresáře uvnitř `pluginů`.

Pokud byl zásuvný modul úspěšně načten, uvidíte jeho jméno a verzi v logu. Měli byste konzultovat vývojáře pluginů v případě dotazů, problémů nebo použití pluginů, které jste se rozhodli používat.

Některé doporučené pluginy najdete v sekci **[třetí strany](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)**.

**Vezměte prosím na vědomí, že ASF pluginy mohou být škodlivé**. Vždy byste se měli ujistit, že používáte pluginy vytvořené vývojáři, kterým můžete důvěřovat, a to i v sekci třetí strany výše. Vývojáři ASF vám již nemohou garantovat běžné výhody ASF (jako je nedostatek malware nebo bez VAC), pokud se rozhodnete použít vlastní pluginy. Musíte pochopit, že pluginy mají po načtení plnou kontrolu nad procesem ASF, Z toho důvodu také nejsme schopni podpořit nastavení, která používají vlastní pluginy, protože již nepoužíváte vanilla ASF kód.

---

## Kompatibilita

v závislosti na složitosti zásuvného modulu, rozsahu a mnoha dalších faktorech, je zcela možné, že od vás bude vyžadovat použití **[generické](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** ASF varianty, místo obvykle doporučených **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. Je tomu tak proto, že varianta specifická pro OS, má pouze základní funkci, která je nutná pro samotné ASF, a váš zásuvný modul může vyžadovat části, které nespadají do hlavního rozsahu ASF, což je nekompatibilní s upravenými prvky pro OS.

Obecně doporučujeme při použití pluginů třetích stran pro maximální kompatibilitu použít ASF generickou variantu. Ovšem ne všechny pluginy to mohou vyžadovat - podívejte se prosím na informace vašeho pluginu, abyste zjistili, zda potřebujete použít generickou variantu ASF nebo ne.

---


## Automatické aktualizace

ASF má vestavěný mechanismus pro automatické aktualizace pluginů. Aby tato funkce fungovala, musí váš plugin volby nejprve **[podpořit](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)** tento mechanismus. Pokud jste načetli plugin, který podporuje automatické aktualizace, ASF jej během inicializace pluginu odpovídajícím způsobem uvede v logu. např. "plugin byl zakázán z automatických aktualizací" nebo "plugin byl zaregistrován a povolen pro automatické aktualizace".

Ve výchozím nastavení jsou automatické aktualizace pro vlastní pluginy **zakázány**, z bezpečnostních důvodů. Automatické aktualizace v konfiguraci můžete nastavit pomocí **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** a/nebo **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)**, pro více informací doporučujeme přečíst popis těchto vlastností konfigurace. Je také pěkné upozornit, že podobně jako v případě aktualizace aplikace ASF se můžete rozhodnout ponechat automatické aktualizace zakázány a poté aktualizovat podle potřeby, manuální báze, vydáním `updateplugins` **[příkazu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

Oba přístupy vám umožňují aktualizovat žádné, některé nebo všechny vlastní pluginy, které jste načetli do procesu.