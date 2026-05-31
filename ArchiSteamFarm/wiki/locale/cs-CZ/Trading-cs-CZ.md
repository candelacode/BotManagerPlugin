# Obchodování

ASF zahrnuje podporu neinteraktivních (offlinových) obchodů na Steamu. Oba příjem (přijetí/odmítnutí) i odesílání obchodů je k dispozici ihned a nevyžaduje speciální konfiguraci, ale samozřejmě vyžaduje neomezený Steam účet (ten, který již utratil 5$ v obchodě). Pro omezené účty je dostupná pouze omezená funkce obchodování.

---

## Logika

Nejprve je možné zakázat **všechny** příchozí obchodní nabídky pomocí `příznaku DisableIncomingTradesParsing` v `BotBehaviour`. Použitím zakáže všechny funkce související s příchozími obchody, jak je uvedeno v názvu, která obsahuje méně než výchozí logiku a všechny dostupné funkce závisející na reakci na příchozí obchodní nabídku. Vzhledem k tomu, že výchozí nastavení již není rušivé, byste měli zvážit použití této možnosti pouze v případě, že nemáte absolutně žádný úmysl udělat cokoliv v souvislosti s příchozími obchody.

Níže uvedená vysvětluje logiku, když je povolena parsování příchozích obchodních nabídek, což je výchozí možnost.

ASF bude vždy přijímat všechny obchody, bez ohledu na položky, odeslané od uživatele s `Master` (nebo vyšší) přístupem k botu. To umožňuje nejen snadno lootovat parní karty farmované instancí bota, ale také umožňuje snadnou správu Steam předmětů, které bota sklízejí v inventáři - včetně předmětů z jiných her (např. CS:GO).

ASF odmítne obchodní nabídku bez ohledu na obsah od jakéhokoli (jiného než mistrovského) uživatele, který je na černé listině z obchodního modulu. Černá listina je uložena ve standardním `BotName. b` databáze a může být spravována přes `tb`, `tbadd` a `tbrm` **[příkazy](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Toto by mělo fungovat jako alternativa standardního uživatelského bloku, který nabízí Steam - používat s opatrností.

ASF bude přijímat všechny obchody podobné `loot`posílané napříč boty, pokud `DontAcceptBotTrades` není specifikováno v `TradingPreferences`. Stručně řečeno, výchozí `TradingPreferences` of `No` způsobí, že ASF automaticky přijímá obchody od uživatele s přístupem `Master` k botu (vysvětlením výše), stejně jako všechny dárcovské obchody od jiných botů, kteří se účastní procesu ASF.

Když povolíte `AcceptDonations` ve vašem `TradingPreferences`ASF také přijme jakýkoli obchod s dárci - obchod, ve kterém účet bota neztrácí žádné předměty. Tato vlastnost ovlivňuje pouze účty bez botů, protože účty botů jsou ovlivněny `DontAcceptBotTrades`. `Přijímání darů` umožňuje snadno přijímat dary od jiných lidí a také botů, kteří se neúčastní procesu ASF.

Je hezké poznamenat, že `AcceptDonations` nevyžaduje **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**protože není nutné žádné potvrzení, pokud neztrácíme žádné položky.

Můžete také dále upravovat možnosti obchodování ASF tím, že podle toho upravíte `TradingPreferences`. Jednou z hlavních funkcí `TradingPreferences` je možnost `SteamTradeMatcher` , která způsobí, že ASF bude používat vestavěnou logiku pro přijímání obchodů, které vám pomohou dokončit chybějící odznaky, což je obzvláště užitečné ve spolupráci s veřejným seznamem **[SteamTradeMatcher](https://www.steamtradematcher.com)**, ale také bez něj může fungovat. Je dále popsán níže.

---

## `SteamTradeMatcher`

Když je `SteamTradeMatcher` aktivní, ASF bude používat poměrně složitý algoritmus kontroly toho, zda obchod vyhoví pravidlům STM a je vůči nám přinejmenším neutrální. Skutečná logika je následující:

- Odmítnout obchod, pokud ztrácíme cokoliv jiného než typy položek specifikované v naší `MatchableTypy`.
- Odmítnout obchod, pokud neobdržíme alespoň stejný počet položek na základě hry, jednotlivých typů a vzácnosti.
- Odmítnout obchod, pokud uživatel požádá o speciální letní/zimní prodejní karty Steam a má obchod.
- Odmítnout obchod, pokud doba držení obchodu přesahuje `MaxTradeHoldDuration` globální vlastnost konfigurace.
- Reject the trade if we don't have `MatchEverything` set, and it's worse than neutral for us.
- Přijmout obchod, pokud jsme jej neodmítli prostřednictvím žádného z výše uvedených bodů.

Je pěkné si uvědomit, že ASF také podporuje přeplatky - logika bude správně fungovat, když uživatel přidává do obchodu něco navíc, pokud jsou splněny všechny výše uvedené podmínky.

První 4 odmítnutí by mělo být zřejmé pro každého. Poslední zpráva obsahuje skutečnou duplikační logiku, která kontroluje současný stav našeho inventáře a rozhoduje o tom, jaký je stav obchodu.

- Obchod je **dobrý** , pokud jsme pokročili směrem k dokončení pokročilosti. Příklad: A (před) -> A B (po)
- Obchod je **neutrální** , pokud náš pokrok směrem k dokončení zůstane v taktu. Příklad: A B (před) -> A C (po)
- Obchod je **špatný** , pokud náš pokrok směrem k dokončení klesá. Příklad: A C (před) -> A (po)

STM funguje pouze na dobrých obchodech, což znamená, že uživatel používající STM pro párování dupes by měl vždy navrhnout pouze dobré obchody pro nás. ASF je však liberální a přijímá i neutrální obchody, protože v těchto obchodech ve skutečnosti nic neztrácíme, takže není žádný skutečný důvod je odmítnout. To je zvláště užitečné pro vaše přátele, protože mohou vyměnit vaše nadměrné karty bez použití STM vůbec. dokud neztrácíte žádný postup.

Ve výchozím nastavení ASF odmítne špatné obchody - toto je téměř vždy to, co chcete jako uživatel. Ovšem Volitelně můžete povolit `MatchEverything` ve vašem `TradingPreferences` , aby ASF přijala všechny podváděcí obchody, včetně **špatných**. Toto je užitečné pouze v případě, že chcete spustit obchodní bota 1:1 na Vašem účtu, pokud víte, že **ASF vám již nepomůže pokročit směrem k dokončení odznaku, a buďte náchylní ke ztrátě celého dokončeného nastavení N dupes stejné karty**. Pokud chcete úmyslně spustit obchodní bot, který není **nikdy** má dokončit libovolnou sadu, a měli byste nabídnout celý svůj inventář každému zainteresovanému uživateli, pak můžete tuto možnost povolit.

Bez ohledu na zvolenou `TradingPreferences`neznamená, že obchod odmítl ASF, že jej sami nemůžete přijmout. Pokud jste udrželi výchozí hodnotu `BotBehaviour`, která neobsahuje `RejectInvalidTrades`ASF bude tyto obchody jen ignorovat - můžete se sami rozhodnout, zda se o ně zajímáte, nebo ne. Totéž platí pro obchody s položkami mimo `MatchableTypes`, stejně jako všechno ostatní - modul vám má pomoci automatizovat STM obchody, nerozhoduje o tom, co je dobrý obchod a co ne. Jediná výjimka z tohoto pravidla je, když hovoříte o uživatelích, které jste zakázali z obchodního modulu pomocí příkazu `tbadd` - obchody od těchto uživatelů jsou okamžitě odmítnuty bez ohledu na `nastavení BotBehaviour`.

Je důrazně doporučeno použít **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** , když povolíte tuto možnost, protože tato funkce ztrácí celý svůj potenciál, pokud se rozhodnete ručně potvrdit každý obchod. `SteamTradeMatcher` bude fungovat správně i bez možnosti potvrdit obchody, ale může generovat nevyřízené potvrzení, pokud je nepřijímáte včas.