# Rodinné sdílení na Steamu

ASF podporuje sdílení Steam Family - starý i nový systém. Aby bylo možné pochopit, jak s tím ASF funguje, Nejprve byste si měli přečíst jak **[Steam Family Sharing funguje](https://store.steampowered.com/promotion/familysharing)**, což je k dispozici v Steam store. Kromě toho se podívejte na **[novinky](https://store.steampowered.com/news/app/593110/view/4149575031735702628)** pro nadcházející nový systém sdílení rodin Steam, se kterým je ASF také kompatibilní.

---

## ASF

Podpora funkce sdílení rodin Steam v ASF je transparentní, což znamená, že nezavádí žádné nové vlastnosti bot/proces - funguje mimo krabici jako extra vestavěná funkce.

Tyto prostředky jsou určeny na pokrytí výdajů na zaměstnance a správních výdajů agentury (hlavy 1 a 2) a provozních výdajů na pracovní program (hlava 3). proto je nebude "vykopnout" z přehrávání relace kvůli spuštění hry. ASF bude jednat úplně stejně jako s primárním účtem držícím zámek, a proto pokud je tento zámek držen vaším Steam klientem, nebo jedním z vašich uživatelů, kteří sdílejí rodiny, ASF se místo toho nebude pokoušet farma, bude čekat na uvolnění zámku. To souvisí především se starým systémem - nový systém umožňuje vašim rodinám, aby hráli jiné hry, než jsou hry, které v současné době farmuje ASF.

Kromě výše uvedeného bude ASF po přihlášení přistupovat k vašim systémům sdílení rodiny (staré a nové), ze kterého bude moci extrahovat uživatele (Steam ID), kteří mohou používat vaši knihovnu. Tito uživatelé mají `FamilySharing` oprávnění používat **[příkazy](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, zejména jim umožňuje používat příkaz `pozastave~` na účtu bota, který s nimi sdílí hry, který umožňuje pozastavit modul pro automatický chov karet, aby spustil hru, která může být sdílena - to platí především pro starý systém, ale stále by mohl být použit s novým systémem v případě, že ASF je v současné době farmářská hra, kterou chtějí hrát vaši uživatelé.

Připojení obou výše popsaných funkcí umožňuje vašim přátelům `pozastavit~` proces obdělávání karet, spustit hru, hrát tak dlouho, jak si to přejí, a poté po dokončení hraní, proces chovu karet bude automaticky obnoven ASF. Vydávání `pause~` samozřejmě není nutné, pokud ASF v současné době nic neprovozuje, protože tví přátelé mohou hru okamžitě spustit a logika popsaná výše zajišťuje, že nebudou vyhozeni ze relace.

---

## Omezení

Síť Steam miluje zavádějící ASF tím, že vysílá falešné aktualizace stavu, což může vést k tomu, že ASF věří, že je dobré pokračovat v procesu a v důsledku toho vyhodit svého přítele příliš brzy. Toto je přesně stejný problém, jak jsme již vysvětlili v **[tento FAQ záznam](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. Doporučujeme přesně stejná řešení, hlavně propagovat vaše přátele na `Operátor` (nebo výše) a říkat jim, aby používali `pause` a `pokračovat v` příkazech.