# Konfigurace

Tato stránka je určena pro konfiguraci ASF. Slouží jako úplná dokumentace adresáře `config` , která vám umožní přizpůsobit ASF vašim potřebám.

* **[Úvod](#introduction)**
* **[Webový konfigurační generátor](#web-based-configgenerator)**
* **[ASF-ui konfigurace](#asf-ui-configuration)**
* **[Ruční konfigurace](#manual-configuration)**
* **[Globální konfigurace](#global-config)**
* **[Konfigurace bota](#bot-config)**
* **[Struktura souboru](#file-structure)**
* **[Mapování JSON](#json-mapping)**
* **[Mapování kompatibility](#compatibility-mapping)**
* **[Konfigurace kompatibility](#configs-compatibility)**
* **[Automatické znovunačtení](#auto-reload)**

---

## Úvod

ASF konfigurace je rozdělena do dvou hlavních částí - globální (procesní) konfigurace a konfigurace každého bota. Každý bot má vlastní konfigurační soubor bota s názvem `BotName. syn` (kde `BotName` je název bota), zatímco globální ASF (proces) konfigurace je jeden soubor s názvem `ASF. syn`.

Bot je jeden párový účel, který se účastní procesu ASF. Aby ASF správně fungoval, potřebuje alespoň **jednu** definovanou instanci. Neexistuje žádný limit položek vynuceného procesem, takže můžete použít tolik botů (Steam účet), kolik chcete.

ASF používá formát **[JSON](https://en.wikipedia.org/wiki/JSON)** pro ukládání svých konfiguračních souborů. Je to lidsky přívětivé, čitelné a velmi univerzální formát, ve kterém můžete konfigurovat program. Nebojte se však, nemusíte znát JSON, abyste mohli konfigurovat ASF. Právě jsem to zmínil v případě, že byste již chtěli mas-vytvořit ASF konfigurace s nějakým bash skriptem.

Konfiguraci lze provést několika způsoby. Můžete použít náš **[Webový ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)**, což je místní aplikace nezávislá na ASF. Můžete použít naši **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC frontend pro konfiguraci provedenou přímo v ASF. Konečně můžete vždy generovat konfigurační soubory ručně, protože postupují podle opravené struktury JSON uvedené níže. Brzy vysvětlíme dostupné možnosti.

---

## Webový konfigurační generátor

Účelem našeho **[Webového konfiguračního generátoru](https://justarchinet.github.io/ASF-WebConfigGenerator)** je poskytnout vám přátelské rozhraní, které se používá pro generování konfiguračních souborů ASF. Webový konfigurační generátor je stoprocentně založen na klientech, což znamená, že detaily, které vkládáte, se nikde neodesílají, ale zpracovávají pouze lokálně. To zaručuje bezpečnost a spolehlivost, protože může fungovat i **[offline](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** , pokud chcete stáhnout všechny soubory a spustit `index. tml` ve vašem oblíbeném prohlížeči.

Webový generátor konfigurací je ověřen správným spuštěním na prohlížečích Chrome a Firefox, ale měl by fungovat správně ve všech nejpopulárnějších prohlížečích javascript.

Použití je poměrně jednoduché - vyberte zda chcete vygenerovat konfiguraci `ASF` nebo `Bot` přepnutím na správnou záložku, ujistěte se, že vybraná verze konfiguračního souboru odpovídá vaší verzi ASF, poté vložte všechny podrobnosti a stiskněte tlačítko "download". Přesuňte tento soubor do adresáře ASF `config` a v případě potřeby přepište existující soubory. Pro všechny další případné změny opakujte a pro vysvětlení všech dostupných možností nastavení se podívejte na zbytek tohoto oddílu.

---

## ASF-ui konfigurace

Naše rozhraní **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC vám umožňuje také konfigurovat ASF. a je nadřazené řešení pro změnu konfigurace ASF po vygenerování počátečních konfigurací vzhledem k tomu, že může upravovat konfigurace na místě, na rozdíl od webového konfiguračního generátoru, který je staticky generuje.

Abyste mohli používat ASF-ui, musíte mít vlastní **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**. `IPC` je ve výchozím nastavení povoleno, proto k němu můžete přistupovat okamžitě, pokud jste jej sami nezakázali.

Po spuštění programu jednoduše přejděte na ASF adresu **[IPC](http://localhost:1242)**. Pokud vše funguje správně, můžete také změnit konfiguraci ASF.

---

## Ruční konfigurace

Obecně důrazně doporučujeme použití našeho generátoru konfigurací nebo ASF-ui, jak je to mnohem snazší a zajistí, že se neuděláte chybu ve struktuře JSON, ale pokud z nějakého důvodu nechcete, můžete také vytvořit správné konfigurace ručně. Podívejte se na příklady JSON níže pro dobrý začátek ve správné struktuře, můžete zkopírovat obsah do souboru a použít jej jako základ pro konfiguraci. Protože nepoužíváte žádnou z našich stránek, ujistěte se, že vaše konfigurace je **[platná](https://jsonlint.com)**protože aplikace ASF ji odmítne načíst, pokud ji nelze analyzovat. I když je to platný JSON, musíte také zajistit, aby všechny vlastnosti měly správný typ, jak vyžaduje ASF. Pro správnou strukturu JSON všech dostupných polí, viz **[JSON mapování](#json-mapping)** a naše dokumentace níže.

---

## Globální konfigurace

Global config se nachází v `ASF.json` souboru a má následující strukturu:

```json
{
    "AutoRestart": true,
    "Blacklist": [],
    "CommandPrefix": "! ,
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "Aktuální kultura": null,
    "Debug": false,
    "DefaultBot": null,
    "FarmingDelay": 15,
    "FilterBadBots": true,
    "GiftsLimiterDelay": 1,
    "Bez hlavy": false,
    "IdleFarmingPeriod": 8,
    "InventoryLimiterDelay": 4,
    "IPC": true,
    "IPCPassword": null,
    "IPCPasswordFormat": 0,
    "LicenseID": null,
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldDuration": 15,
    "MinFarmingDelayAfterBlock": 60,
    "Optimalizace Mode": 0,
    "PluginsUpdateList": [],
    "PluginsUpdateMode": 0,
    "ShutdownIfPossible": false,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Všechny možnosti jsou vysvětleny níže:

### `Automatický restart`

`bool` type with default value of `true`. Tato vlastnost definuje, zda ASF může v případě potřeby provést automatický restart. Existuje několik událostí, které budou od ASF vyžadovat vlastní restart, jako je aktualizace ASF (provedena pomocí `UpdatePeriod` nebo `aktualizovat příkaz` ) a `ASF. syn` konfigurace, `restartujte` příkaz a podobně. Restartovat obvykle obsahuje dvě části - vytvoření nového procesu a dokončení aktuální. Většina uživatelů by měla být v pořádku a zachovat tuto vlastnost s výchozí hodnotou `true`, Nicméně, pokud používáte ASF skrz svůj vlastní skript a/nebo `dotnet`, možná budete chtít mít plnou kontrolu nad zahájením procesu, a vyhýbat se situaci, kdy nový (restarturový) proces ASF probíhá někde v pozadí, a nikoli v popředí skriptu, který prošel spolu se starým procesem ASF. To je obzvláště důležité vzhledem ke skutečnosti, že nový proces již nebude Vaším přímým dítětem, což by vás přimělo k tomu, abyste nemohli. . použít pro něj standardní vstup konzoly.

Pokud je tomu tak, tato vlastnost, pokud je speciálně pro vás a můžete ji nastavit na `false`. Ale mějte na paměti, že v takovém případě **jste** zodpovědní za restartování procesu. To je nějakým způsobem důležité, protože ASF skončí pouze místo toho, aby se vytvořil nový proces (např. Po aktualizaci), takže pokud jste nepřidali žádnou logiku, jednoduše přestane pracovat dokud ji nespustíte. ASF vždy končí řádným chybovým kódem označujícím úspěch (nula) nebo neúspěch (nenulová), tímto způsobem můžete do vašeho skriptu přidat správnou logiku, která by se v případě selhání měla vyhnout automatickému restartování ASF, nebo alespoň vytvořit místní kopii `záznamu. xt` pro další analýzu. Také mějte na paměti, že `restartuj` příkaz vždy restartuje ASF bez ohledu na to, jak je tato vlastnost nastavena, protože tato vlastnost definuje výchozí chování, zatímco `restartuje` příkaz vždy restartuje proces. Pokud nemáte důvod tuto funkci zakázat, měli byste ji ponechat v zapnutí.

---

### `Černá listina`

`ImmutableHashSet<uint>` type with default value of be prázdný. Jak napovídá název, tato globální vlastnost konfigurace definuje aplikace (hery), které budou automaticky ASF farmářským procesem zcela ignorovány. Bohužel, Steam miluje vlajku léta/zimní prodejní odznaky jako "k dispozici pro shození karet", který zmatuje proces ASF tím, že se domnívá, že je to platná hra, která by měla být chována. Pokud by neexistovala nějaká černá listina, ASF by nakonec "visel" na farmě hru, která ve skutečnosti není hrou, a počkejte nekonečně na upuštění karet, k čemuž nedojde. černá listina ASF slouží k označení těchto průkazů za nedostupné pro účely chovu, abychom je mohli při rozhodování o tom, co chovat a nespadnout do pasti, mohli tiše ignorovat.

ASF ve výchozím nastavení obsahuje dvě černé listiny - `SalesBlacklist`, který je pevně kódován do kódu ASF a není možné upravit, a normální `Blacklist`, což je definováno zde. `SalesBlacklist` je aktualizován společně s ASF verzí a v době vydání obvykle obsahuje všechny "špatné" aplikace, takže pokud používáte aktuální ASF, nemusíte udržovat vlastní `Blacklist` definovaný. Hlavním účelem této vlastnosti je umožnit vytvoření nové černé listiny v době vydání aplikace ASF, která by neměla být zachována. Hardcoded `SalesBlacklist` je aktualizován co nejrychleji, proto nemusíte aktualizovat svůj vlastní `Černou listinu` , pokud používáte nejnovější verzi ASF, ale bez `Blacklist` byste byli nuceni aktualizovat ASF pro "pokračovat v běhu", když Valve uvolní nový prodejní odznak - nechci vás nutit používat nejnovější ASF kód, proto je zde tato vlastnost, která vám umožní "opravit" aplikaci ASF sama, pokud z nějakého důvodu nechcete nebo nemůžete, aktualizujte na nový tvrdý kód `SalesBlacklist` v nové verzi ASF, přesto chcete zachovat svůj starý ASF běh. Pokud nemáte **silný** důvod k editaci této vlastnosti, měli byste ji držet ve výchozím nastavení.

Pokud namísto toho hledáte černou listinu založenou na botách, podívejte se na `fb`, `fbadd` a `fbrm` **[příkazy](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `Prefix příkazu`

`string` type with default value of `!`. Tato vlastnost specifikuje **case sensitive** prefix pro ASF **[příkazy](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Jinými slovy, toto je to, co potřebujete k každému příkazu ASF přidat, abyste vám ASF naslouchali. Je možné nastavit tuto hodnotu na `null` nebo prázdnou, aby ASF nepoužívala žádné prefixy příkazu, v tom případě zadáte příkazy s jejich jednoduchými identifikátory. Ovšem tak potenciálně sníží výkon ASF, protože ASF je optimalizován tak, aby dále neanalyzoval zprávu, pokud nezačne s `CommandPrefixem` - pokud se rozhodnete ji nepoužít, ASF bude nucen číst všechny zprávy a reagovat na ně, i když to nejsou příkazy ASF. Proto je doporučeno pokračovat v používání `CommandPrefix`, například `/` pokud se vám nelíbí výchozí hodnota `!`. `CommandPrefix` ovlivňuje celý proces ASF. Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `PotvrzeníLimiterDelay`

`byte` type with default value of `10`. ASF zajistí, že budou existovat alespoň `ConfirmationsLimiterDelay` vteřin mezi dvěma po sobě jdoucími 2FA potvrzenými požadavky, aby se zabránilo spuštění limitu rychlosti - ty jsou používány **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** během e. . `2faok` velení, stejně jako podle potřeby, při provádění různých operací souvisejících s obchodováním. Výchozí hodnota byla nastavena na základě našich testů a neměla by být snížena, pokud nechcete běžet do problémů. Pokud nemáte **silný** důvod k editaci této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `Časový limit připojení`

`byte` type with default value of `90`. Tato vlastnost definuje časové limity pro různé akce sítě provedené ASF v sekundách. `ConnectionTimeout` definuje časový limit v sekundách pro HTTP a IPC požadavky, `ConnectionTimeout / 10` definuje maximální počet selhání služby heartbeats, zatímco `ConnectionTimeout / 30` definuje počet minut, povolujeme počáteční požadavek na připojení k síti Steam. Výchozí hodnota `90` by měla být v pořádku pro většinu lidí, ale pokud máte poměrně pomalé připojení k síti nebo PC, možná budete chtít zvýšit toto číslo na něco vyšší (jako `120`). Mějte na paměti, že větší hodnoty nebudou magicky opravovat pomalé, nebo dokonce nedostupné servery Steamu, takže bychom neměli nekonečně čekat na něco, co se nestane, a prostě to zkuste znovu později. Nastavení této hodnoty bude mít za následek nadměrné zpoždění při chytání síťových problémů a také snížení celkového výkonu. Nastavení této hodnoty příliš nízké sníží celkovou stabilitu a výkon, protože ASF přeruší platný požadavek, který je stále analyzován. Stanovení této hodnoty nižší, než je výchozí hodnota, proto nemá žádnou výhodu obecně. protože Steam servery bývají čas od času super pomalu a mohou vyžadovat více času na zpracování požadavků ASF. Výchozí hodnota je rovnováha mezi přesvědčením, že naše síťové připojení je stabilní, a pochybnostmi v síti Steam při vyřizování našeho požadavku v daném časovém limitu. Pokud chcete rozpoznat problémy dříve a urychlit připojení a reakci aplikace ASF, výchozí hodnota by měla udělat (nebo velmi mírně níže, jako `60`, což ASF sníží pacienta). Pokud si naopak všimnete, že ASF běží v síťových problémech, jako například v případě nevyřešených žádostí, ztráta srsti nebo přerušení připojení ke Steamu, pravděpodobně má smysl zvýšit tuto hodnotu, pokud jste si jisti, že je to **ne** způsobeno vaší sítí, ale samotným Steamem, protože kvůli rostoucímu časovému limitu se ASF stává "pacientovou" a ne se ihned rozhodnout se znovu připojit.

Příkladem situace, která může vyžadovat zvýšení této nemovitosti, je umožnit ASF vypořádat se s velmi velkými obchodními nabídkami, které mohou trvat 2 + minuty, než je Steam plně přijme a bude s nimi nakládat. Zvýšením výchozího časového limitu ASF bude trpělivější a čeká déle, než se rozhodne, že obchod neproběží a původní žádost se vzdá.

Další situaci by mohlo zapříčinit velmi pomalý stroj nebo internetové připojení, které vyžaduje více času na zpracování předávaných údajů. Jedná se o poměrně vzácný stav, protože CPU/síť téměř nikdy není úzkým místem, ale stále stojí za zmínku.

Stručně řečeno, výchozí hodnota by měla být pro většinu případů přiměřená, ale v případě potřeby ji budete chtít zvýšit. Ani zdaleka nad výchozí hodnotou však nedává velký smysl, protože větší časová lhůta nebude magicky opravovat nedostupné Steam servery. Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `Současná kultura`

Typ `string` s výchozí hodnotou `null`. Ve výchozím nastavení se ASF pokouší použít váš operační systémový jazyk a bude raději používat přeložené řetězce v tomto jazyce, pokud jsou k dispozici. To je možné díky naší komunitě, která se snaží **[lokalizovat](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** ASF ve všech nejpopulárnějších jazycích. Pokud z nějakého důvodu nechcete používat svůj rodný jazyk operačního systému, můžete použít tuto vlastnost konfigurace, abyste si vybrali platný jazyk, který chcete použít. Pro seznam všech dostupných kultur navštivte **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** a vyhledejte `Language tag`. Je hezké poznamenat, že ASF přijímá obě specifické kultury, jako je `"en-GB"`. ale také neutrální, jako je `"en"`. Upřesnění současné kultury ovlivní také jiné chování specifické pro kulturu, jako je formát měny/data a podobně. Vezměte prosím na vědomí, že budete potřebovat další balíčky písem a jazyků pro zobrazení znaků specifických pro daný jazyk, pokud jste si vybrali nepůvodní kulturu, která je používá. Typically you want to use of this config property if you prefer ASF in Czech instead of your native language.

---

### `Ladění`

`bool` type with default value of `false`. Tato vlastnost definuje, zda by měl proces běžet v režimu ladění. When in debug mode, ASF creates a special `debug` directory next to the `config`, which keeps track of whole communication between ASF and Steam servers. Ladící informace mohou pomoci odhalit ošklivé problémy týkající se vytváření sítí a obecného postupu ASF. Kromě toho některé programy budou mnohem více verbální jako `WebBrowser` uvádí přesný důvod, proč některé požadavky selhávají - tyto záznamy jsou zapsány do normálního ASF logu. **Neměli byste spouštět ASF v režimu ladění, pokud jste jej nedotázali vývojář**. Spuštění ASF v režimu ladění **snižuje výkon**, **negativně ovlivňuje stabilitu** a je **mnohem více na různých místech**, aby měl být používán pouze **záměrně a v krátkodobém horizontu pouze** pro ladění konkrétního problému, reprodukovat problém nebo získat více informací o selhávajícím požadavku a stejně tak **ne** pro normální spuštění programu. Uvidíte **hodně** nových chyb, úkolů, a výjimky - ujistěte se, že máte slušné znalosti o ASF, Steam a jeho dotazy, pokud se rozhodnete vše analyzovat sám, protože ne všechno je důležité.

**VAROVÁNÍ:** povolení tohoto režimu zahrnuje logování **potenciálně citlivých** informací, jako jsou přihlášení a hesla, která používáte pro přihlášení do Steamu (kvůli protokolování o síti). Tato data jsou zapsána do adresáře `ladění` i do standardního `. xt` (to je nyní záměrně mnohem více podrobností k logování těchto informací). Neměli byste vkládat ladící obsah generovaný aplikací ASF do žádného veřejného umístění, ASF vývojář by vám měl vždy připomínat odeslání e-mailu nebo jiného zabezpečeného místa. Neukládáme, ani nevyužíváme tyto citlivé detaily, jsou napsány jako součást ladících rutinů, protože jejich přítomnost může být relevantní pro problém, který se vás dotýká. Byli bychom raději, kdybyste nezměnili logování ASF jakýmkoliv způsobem, ale pokud máte obavy, můžete tyto citlivé údaje opravit odpovídajícím způsobem.

> Čištění zahrnuje nahrazení citlivých detailů, například hvězdami. Měli byste se zdržet úplného odstranění citlivých linií, protože jejich čistá existence by mohla být relevantní a měla by být zachována.

---

### `Výchozí Bot`

Typ `string` s výchozí hodnotou `null`. V některých scénářích funkce ASF s koncepcí výchozího bota, který je zodpovědný za zvládnutí něčeho - například IPC příkazy nebo interaktivní konzole, když nespecifikujete cílového bota. Tato vlastnost vám umožňuje zvolit výchozího bota zodpovědného za řešení takových scénářů tak, že sem umístíte `BotName`. Pokud daný bota neexistuje, nebo použijete výchozí hodnotu `null`, ASF místo toho vybere první registrovaný bota seřazený abecedně. Typicky chcete použít tuto vlastnost konfigurace, pokud chcete vynechat `[Bots]` argument v příkazech IPC a interaktivní konzole, a vždy vyberte stejného bota jako výchozí pro takové volání.

---

### `Zpoždění chovu`

`byte` type with default value of `15`. Aby ASF fungoval, zkontroluje aktuálně farmovou zvěř každou `FarmingDelay` minuty, pokud možná všechny karty již vynechá. Příliš nízké nastavení této vlastnosti může mít za následek zaslání nadměrného množství požadavků na páru, zatímco je nastavení příliš vysoké, může mít za následek stále "farmaření" název až do `FarmingDelay` minut po kompletním farmě. Výchozí hodnota by měla být skvělá pro většinu uživatelů, ale pokud máte mnoho botů běžících, můžete zvážit zvýšení na něco jako je `30` minut, aby se omezily posílané požadavky na páru. Je hezké poznamenat, že ASF používá mechanismus založený na událostech a kontroluje stránku s odznakem na každé Steam položce, takže obecně **není třeba ji kontrolovat ani v pevně stanovených časových intervalech**, ale protože plně nevěříme síti Steam - přesto kontrolujeme stránku s odznakem hry, Pokud jsme to neověřili skrze odpojenou kartu v poslední `FarmingDelay` minuty (v případě, že by nás síť Steam neinformovala o položce, která byla upuštěna, nebo o věci, jako je tat). Za předpokladu, že síť Steam funguje správně, snížení této hodnoty **nijak nezlepší účinnost zemědělství**, zatímco **výrazně zvyšuje režijní náklady sítě** - je doporučeno je zvýšit pouze v případě potřeby z výchozí hodnoty `15` minut. Pokud nemáte **silný** důvod k editaci této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `FilterBadBots`

`bool` type with default value of `true`. Tato vlastnost definuje, zda ASF automaticky odmítne obchodní nabídky, které obdrží od známých a značných špatných aktérů. Za tímto účelem bude ASF komunikovat s naším serverem podle potřeby, aby mohl získat seznam identifikátorů Steam na černé listině. Vyjmenovaní boti provozují lidé, kteří jsou naší iniciativou označováni za škodlivé, jako ty, které porušují náš **[kodex chování](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, používat poskytovanou funkčnost a zdroje, jako je **[`PublicListing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** , abychom zneužívali a zneužívali jiné lidi, nebo provádějí otevřenou trestnou činnost, jako je zahájení útoků DDoS na serveru. Vzhledem k tomu, že ASF má silný postoj k celkové spravedlnosti, poctivosti a spolupráci mezi svými uživateli, aby se zlepšila prosperita celé komunity, Tato vlastnost je ve výchozím nastavení povolena, a proto ASF filtruje boty, které jsme označili za škodlivé z nabízených služeb. Pokud nemáte **silný** důvod pro editaci této vlastnosti, například nesouhlasí s naším prohlášením a záměrně dovolí těmto botům fungovat (včetně využívání vašich účtů), měli byste ho držet ve výchozím nastavení.

---

### `GiftsLimiterDelay`

`byte` type with default value of `1`. ASF zajistí, že bude existovat alespoň `GiftsLimiterDelay` vteřin mezi dvěma po sobě jdoucími požadavky na dárek/klíč/licenci, aby se zabránilo spuštění limitu rychlosti. Kromě toho bude také použit jako globální limiter pro požadavky na seznam her, jako je příkaz `vlastní` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Pokud nemáte **silný** důvod k editaci této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `Bez hlav`

`bool` type with default value of `false`. Tato vlastnost definuje, zda by měl proces běžet v bezhlavém režimu. ASF předpokládá, že v režimu bez hlav běží na serveru nebo v jiném neinteraktivním prostředí, se proto nebude pokoušet číst žádné informace prostřednictvím vstupu do konzoly. To zahrnuje detaily na vyžádání (údaje o účtu, jako je kód 2FA, kód SteamGuard, heslo nebo jakákoli jiná proměnná potřebná pro fungování ASF) a všechny ostatní vstupy konzole (např. interaktivní konzole). Jinými slovy, režim `bez hlav` je roven tomu, aby se ASF konzole stala pouze pro čtení. Toto nastavení je užitečné zejména pro uživatele, kteří používají ASF na svých serverech, namísto dotazu. . pro 2FA kód aplikace ASF operaci tiše zruší zastavením účtu. Pokud nepoužíváte ASF na serveru, a dříve jste potvrdili, že ASF je schopen fungovat v režimu bez hlasu, Tato vlastnost by měla být zakázána. Jakákoliv uživatelská interakce bude odepřena v bezhlavém režimu, a vaše účty se nespustí, pokud vyžadují **libovolný** vstup při spuštění. To je užitečné pro servery, protože ASF může přerušit přihlášení na účet, když je požádán o pověření, místo čekání (nekonečně) na to, aby je uživatel poskytl.

Povolení tohoto režimu vám umožní dodávat požadovaný vstup do konzole jinými prostředky, tj. ASF-ui (ASF API) nebo prostřednictvím **[`vložte`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#input-command)** příkaz. Pokud si nejste jisti, jak nastavit tuto vlastnost, ponechte ji s výchozí hodnotou `false`.

---

### `IdleFarmingPeriod`

`byte` type with default value of `8`. Pokud ASF nemá co dělat, bude pravidelně kontrolovat všechny `IdleFarmingPeriod` hodiny, pokud si možná vyúčtuje nějaké nové hry pro zemědělství. Tato funkce není nutná, když hovoříme o nových hrách, které dostáváme, protože ASF je dostatečně chytrý na automatické ověření stránek s odznaky v tomto případě. `IdleFarmingPeriod` slouží především k situacím, jako jsou staré hry, které již byly přidány obchodními kartami. V tomto případě není žádná událost, takže pokud chceme, aby to pokrylo, musí ASF pravidelně kontrolovat stránky s odznaky. Hodnota `0` zakáže tuto funkci. Také zaškrtnout: `ShutdownOnFarmingFinished` v `FarmingPreferences`.

---

### `Zpoždění inventáře`

`byte` type with default value of `4`. ASF zajistí, aby mezi dvěma po sobě jdoucími požadavky na webovou inventuru existovaly alespoň `InventoryLimiterDelay` sekundy, aby se zabránilo spuštění limitu sazeb - ty se používají například při označení oznámení inventury jako přečtené, mohou být také použity pluginy třetích stran, které načítají inventář jiných uživatelů. Tato vlastnost se nepoužívá k načítání našeho vlastního seznamu, protože ASF k tomu využívá mnohem účinnější vnitřní síťový požadavek. takže to žádným způsobem neovlivní příkazy jako `loot` nebo `transfer`. Výchozí hodnota `4` byla nastavena na základě označování zásob nad 100 po sobě jdoucích botů, a měla by uspokojit většinu uživatelů (pokud ne všechny). Pokud máte velmi malé množství botů, můžete jej snížit, nebo dokonce změnit na `0` , takže ASF bude ignorovat zpoždění a označit Steam inventáře mnohem rychleji. Buďte však varováni, protože jeho nastavení příliš nízkého **** povede k dočasnému zákazu vaší IP adresy, a to vám zabrání v tom, abyste vůbec mohli volat. Také budete muset zvýšit tuto hodnotu, pokud máte spoustu robotů s mnoha požadavky na inventář, i když v tomto případě byste se raději měli pokusit omezit počet těchto žádostí. Pokud nemáte **silný** důvod k editaci této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `IPC`

`bool` type with default value of `true`. Tato vlastnost definuje, zda by server **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** měl začít společně s procesem. IPC umožňuje komunikaci mezi procesy, včetně využití **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, spuštěním místního HTTP serveru. Pokud nemáte v úmyslu používat žádnou IPC integraci třetích stran s ASF, včetně našeho ASF-ui, můžete tuto možnost bezpečně zakázat. V opačném případě je dobrý nápad, aby byl povolen (výchozí možnost).

---

### `IPCPassword`

Typ `string` s výchozí hodnotou `null`. Tato vlastnost definuje povinné heslo pro každý API hovor uskutečněný prostřednictvím IPC a slouží jako další bezpečnostní opatření. Pokud je nastaveno na neprázdnou hodnotu, všechny IPC požadavky budou vyžadovat navíc `heslo` nastaveno na zadané heslo. Výchozí hodnota `null` přeskočí potřebu hesla, čímž ASF respektuje všechny dotazy. Kromě toho povolení této možnosti také umožňuje vestavěný IPC anti-bruteforce mechanismus, který dočasně zakáže `IPAddress` poté, co za velmi krátkou dobu odešle příliš mnoho nepovolených požadavků. Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `Formát IPCPasswordu`

`byte` type with default value of `0`. Tato vlastnost definuje formát vlastnosti `IPCPassword` a jako základní typ používá `EHashingMethod`. Pokud se chcete dozvědět více, podívejte se na **[Security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** . protože budete muset zajistit, aby vlastnost `IPCPassword` skutečně obsahovala heslo ve shodě s `IPCPasswordFormat`. Jinými slovy, když změníte `IPCPasswordFormat` , pak váš `IPCPassword` by měl být **již** v tomto formátu, nezaměřovat se jen na to. Pokud nevíte, co děláte, měli byste jej zachovat s výchozí hodnotou `0`.

---

### `LicenseID`

`Guide?` type with default value of `null`. Tato vlastnost umožňuje našim **[sponzorům](https://github.com/sponsors/JustArchi)** vylepšit ASF s volitelnými funkcemi, které vyžadují placenou práci. Prozatím můžete využít **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** v pluginu `ItemsMatcher`.

Zatímco doporučujeme používat GitHub, protože nabízí měsíční i jednorázové úrovně, stejně jako umožňuje plnou automatizaci a poskytuje vám okamžitý přístup, **také** podporujeme všechny další aktuálně dostupné možnosti daru **[](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. Podívejte se na **[tento příspěvek](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** pro pokyny, jak darovat pomocí jiných metod, abyste získali manuální licenci platnou pro dané období.

Bez ohledu na použitou metodu, pokud jste sponzor ASF, můžete získat licenci **[zde](https://asf.justarchi.net/User/Status)**. Budete se muset přihlásit pomocí GitHub pro potvrzení Vaší totožnosti. Žádáme pouze o veřejné informace pouze pro čtení, což je vaše uživatelské jméno. `LicenseID` je vyroben z 32 hexadecimálních znaků, jako je `f6a0529813f74d119982eb4fe43a9a24`.

**Zajistěte, že nesdílíte `LicenseID` s ostatními lidmi**. Vzhledem k tomu, že je vydán na osobním základě, může být odvolán, pokud unikne. Pokud se vám to náhodou stane, můžete vytvořit nový z téhož místa.

Pokud nechcete povolit další funkce ASF, není třeba získat/poskytnout licenci.

---

### `LimiterDelay přihlášení`

`byte` type with default value of `10`. ASF zajistí, že bude existovat alespoň `LoginLimiterDelay` vteřin mezi dvěma po sobě jdoucími pokusy o připojení, aby se zabránilo spuštění limitu rychlosti. Výchozí hodnota `10` byla nastavena na základě připojení přes 100 instancí bota a měla by uspokojit většinu uživatelů (pokud ne všechny). Pokud máte velmi malé množství botů, můžete jej zvýšit/snížit, nebo dokonce změnit na `0` , takže ASF bude ignorovat zpoždění a připojit se k Steamu mnohem rychleji. Buďte však varováni, protože nastavení příliš nízké, zatímco budete mít příliš mnoho botů **** způsobí dočasný zákaz vaší IP adresy, a to vám zabrání v přihlášení **ve všech**, s chybou `InvalidPassword/RateLimitExceeded` - a to také zahrnuje vašeho běžného Steam klienta, nejen ASF. Stejně tak pokud používáte příliš velký počet robotů, zejména společně s ostatními klienty/nástroji Steamu, které používají stejnou IP adresu, s největší pravděpodobností budete muset zvýšit tuto hodnotu, aby se mohly přihlásit na delší dobu.

Tato hodnota se také používá jako vyrovnávací paměť zatížení ve všech akcích naplánovaných ASF, jako jsou obchody v `SendTradePeriod`. Pokud nemáte **silný** důvod k editaci této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `MaxFarmingTime`

`byte` type with default value of `10`. Jak byste měli vědět, Steam ne vždy pracuje správně, někdy se mohou stát podivné situace, jako například naše hry, které nejsou zaznamenány, a to navzdory hraní hry. ASF umožní chovu jediné zvěře v samostatném režimu maximálně pro `MaxFarmingTime` hodin a po tomto období ho vezmou v úvahu plně farmy. V případě podivných situací je nutné nezmrazit zemědělský proces, ale také pokud Steam z nějakého důvodu uvolnil nový odznak, který by ASF zabránil v dalším postupu (viz: `Blacklist`). Výchozí hodnota `10` hodin by měla být dostatečná pro vypuštění všech parních karet z jedné hry. Nastavení této vlastnosti může vést k přeskočení platných her (a ano, jsou zde platné hry trvající až 9 hodin, přičemž příliš vysoké nastavení může vést k zmrazení zemědělského procesu. Vezměte prosím na vědomí, že tato vlastnost ovlivňuje pouze jednu hru v jediné zemědělské relaci (takže se po procházení celou frontou ASF vrátí do tohoto názvu), také není založen na celkovém objemu, ale interním čase hospodaření ASF, takže se ASF po restartu vrátí do tohoto titulu. Pokud nemáte **silný** důvod k editaci této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `MaxTradeHoldDuration`

`byte` type with default value of `15`. Tato vlastnost definuje maximální dobu držení obchodu ve dnech, které jsme ochotni přijmout - ASF odmítne obchody, které jsou drženy déle než `MaxTradeHoldDuration` dny, jak je definováno v části **[obchodování](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**. Tato možnost má smysl pouze pro boty s `TradingPreferences` `SteamTradeMatcher`protože nemá vliv na `Master`/`SteamOwnerID` , neobchoduje ani dary. Obchody jsou pro každého obtěžující a nikdo se s nimi opravdu nechce vypořádat. ASF má pracovat na liberálních pravidlech a pomáhat každému, bez ohledu na to, zda je obchod držen nebo ne - proto je tato možnost ve výchozím nastavení nastavena na `15`. Pokud byste však raději odmítli všechny obchody ovlivněné obchodními podíly, můžete zde zadat `0`. Vezměte prosím v úvahu skutečnost, že karty s krátkou životností nejsou touto možností dotčeny a automaticky odmítnuty pro lidi s držbami, jak je popsáno v oddíle **[obchodování](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** , takže není třeba odmítnout všechny na celém světě jen kvůli tomu. Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.


---

### `MinFarmingDelayAfterBlock`

`byte` type with default value of `60`. Tato vlastnost definuje minimální čas v sekundách, které ASF bude čekat před pokračováním v obdělávání karet, pokud bylo dříve odpojeno s `LoggedInElsewhere`, k čemu dochází, když se rozhodnete násilně odpojit současný zemědělský systém ASF spuštěním hry. Toto zpoždění existuje především z důvodů pohodlí a režijních nákladů, například umožňuje restartovat hru, aniž byste museli bojovat s ASF okupací vašeho účtu jen proto, že přehrávání bylo k dispozici po rozdělení sekundy. Vzhledem ke skutečnosti, že vrácení relace způsobí, že `LoggedInElsewhere` odpojí, ASF musí projít celou cestou opětovného připojení, který vyvíjí další tlak na síť strojů a Steamu, a proto je vhodnější vyhnout se dalšímu odpojení, pokud je to možné. Ve výchozím nastavení je nastaveno na `60` vteřin, což by mělo stačit k tomu, abyste mohli restartovat hru bez mnoha potíží. Existují však scénáře, kdy byste se mohli zajímat o jeho zvýšení, například pokud se vaše síť často odpojuje a aplikace ASF přebírá příliš brzy, což způsobí, že bude nuceno procházet procesem opětovného připojení. Pro tuto nemovitost povolujeme maximální hodnotu `255` , což by mělo stačit pro všechny běžné scénáře. Kromě výše uvedeného je také možné snížit zpoždění, nebo jej zcela odeberte s hodnotou `0`, i když se to z výše uvedených důvodů obvykle nedoporučuje. Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `Optimalizační režim`

`byte` type with default value of `0`. Tato vlastnost definuje optimalizační režim, který ASF bude preferován během jízdy. V současné době ASF podporuje dva režimy - `0` , které se nazývá `MaxPerformance`a `1` , které se nazývá `MinMemoryUsage`. ASF ve výchozím nastavení dává přednost používání co největšího počtu věcí paralelně (současně) což zvyšuje výkon vyrovnáváním zatížení ve všech procesorech, více procesorových nití, více zásuvek a více úloh. Například ASF se bude ptát na vaši první stránku s odznakem při kontrole her pro farmy a poté po obdržení žádosti, ASF si z ní přečte, kolik odznakových stránek ve skutečnosti máte, a poté se o sebe požádá souběžně. Toto byste měli chtít **téměř vždy**, protože režijní náklady ve většině případů jsou minimální a výhody asynchronního ASF kódu lze vidět i na nejstarším hardwaru s jedním jádrem procesoru a velmi omezenou spotřebou energie. Avšak vzhledem k tomu, že mnoho úkolů je zpracováno souběžně, za jejich údržbu odpovídá runtime ASF, např. ponechání otevřené zásuvky, naživu vlákna a zpracování úkolů, což může čas od času vést ke zvýšení využití paměti a pokud jste extrémně omezeni dostupnou paměťí, možná budete chtít přepnout tuto vlastnost na `1` (`MinMemoryUsage`) aby aplikace ASF mohla používat co nejmenší úkoly, a obvykle synchronně propojeným způsobem funguje možný asynchronní kód. Přepnutí této vlastnosti byste měli zvážit pouze v případě, že jste dříve četli **[nastavení nízké paměti](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** a záměrně chcete obětovat gigantické výkony, pro velmi malou paměť úbytku. Obvykle je tato možnost **mnohem horší** než to, čeho lze dosáhnout jinými možnými způsoby, jako je omezení využití ASF nebo ladění garbage collector, jak je vysvětleno v **[nastavení](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Proto byste měli použít `MinMemoryUsage` jako **poslední možnost**, pokud jste nemohli dosáhnout uspokojení výsledků s jinými (mnohem lepšími) možnostmi. Pokud nemáte **silný** důvod k editaci této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `PluginsUpdateList`

`ImmutableHashSet<string>` type with default value of be prázdný. Tato vlastnost definuje seznam názvů pluginů, které jsou buď na černé listině nebo na bílé listině pro to, aby byly zváženy pro automatické aktualizace, podle `PluginsUpdateMode` definované níže.

Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `PluginsUpdateMode`

`byte` type with default value of `0`. Tato vlastnost definuje mód aktualizace pluginů, který dává význam `PluginsUpdateList` definovaný výše. Určením této vlastnosti můžete snadno zapnout/vypnout automatické aktualizace pro všechny pluginy s výjimkou těch, které jsou deklarovány.

- Hodnota `0`s názvem `Whitelist` **zakáže** automatickou aktualizaci všech pluginů s výjimkou pluginů definovaných v `PluginsUpdateList`.
- Hodnota `1`s názvem `Blacklist` **umožňuje automatické aktualizace všech pluginů** s výjimkou pluginů definovaných v `PluginsUpdateList`.

**ASF tým by vám rád připomněl, že z důvodu vlastní bezpečnosti byste měli povolit automatické aktualizace pouze od důvěryhodných stran**. Mějte na paměti, že škodlivé pluginy se mohou rozhodnout aktualizovat sami sebe nebo spustit vzdálené příkazy **bez ohledu na** tohoto nastavení. z tohoto důvodu se toto nastavení vztahuje na funkce aktualizace doplňků poskytovaných ASF, a měli byste se ujistit, že jste vhodně ověřili každý plugin, který jste se rozhodli používat.

Aktualizace pluginů jsou prováděny ve výchozím nastavení společně s routinem aktualizace ASF - **[`UpdateChannel`](#updatechannel)** a **[`UpdatePeriod`](#updateperiod)**. Standardní mechanismy aktualizace ASF, jako je `update` , spustí také volitelnou aktualizaci pluginů. Pokud namísto toho chcete ručně aktualizovat pluginy bez aktualizace ASF verze, příkaz `updateplugins` nabízí takovou možnost.

Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `Vypnutí`

`bool` type with default value of `false`. Pokud je povoleno, ASF se pokusí vypnout proces, pokud je to možné, tedy když jsou zastaveni všichni vaši registrovaní roboti. To může být užitečné zejména v kombinaci s `ShutdownOnFarmingFinished` na všech instancích bota, protože tímto způsobem bude možné ASF automaticky vypnout, až poslední z vašich botů dokončí farmování.

Vzhledem k tomu, že většina uživatelů očekává, že proces bude vždy běžet, např. . pro použití `IPC` je tato možnost ve výchozím nastavení zakázána.

---

### `Prefix SteamMessageprefix`

`string` type with default value of `"/me "`. Tato vlastnost definuje prefix, který bude předplacen ke všem Steam zprávám odesílaným ASF. Ve výchozím nastavení ASF používá `"/me "` prefix pro snadnější rozlišení zpráv bota tím, že je zobrazuje jinou barvou na Steam chatu. Další cenná zmínka je `"/pre "` prefix, který dosahuje podobného výsledku, ale používá jiné formátování. Tuto vlastnost můžete také nastavit na prázdný řetězec nebo `null` , abyste zakázali použití prefixu zcela a tradiční výstup všech ASF zpráv. Je hezké poznamenat, že tato vlastnost se týká pouze zpráv Steam - reakce vrácené prostřednictvím jiných kanálů (např. IPC) nejsou dotčeny. Pokud nechcete přizpůsobit standardní ASF chování, je dobré ponechat ji ve výchozím nastavení.

---

### `SteamOwnerID`

`ulong` type with default value of `0`. Tato vlastnost definuje Steam ID v 64bitové formě majitele procesu ASF, a je velmi podobná `Master` oprávnění dané instance bota (ale spíše globální). Téměř vždy chcete nastavit tuto vlastnost na ID vašeho vlastního hlavního Steam účtu. Oprávnění `Master` obsahuje plnou kontrolu nad jeho instancí bota, ale globální příkazy jako `exit` `restartujte` nebo `aktualizaci` jsou vyhrazeny pouze pro `SteamOwnerID`. Je to pohodlné, protože budete chtít spouštět boty pro své přátele, aniž by jim bylo dovoleno kontrolovat proces ASF, jako je jeho opuštění prostřednictvím příkazu `exit`. Výchozí hodnota `0` specifikuje, že není žádný vlastník procesu ASF, což znamená, že nikdo nebude moci vydávat globální příkazy ASF. Mějte na paměti, že tato vlastnost se vztahuje výhradně na Steam chat. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**a také interaktivní konzola, stále vám umožní provést `Owner` příkazy, i když tato vlastnost není nastavena.

---

### `SteamProtocols`

`byte flags` type with default value of `7`. Tato vlastnost definuje Steam protokoly, které ASF použije při připojení k Steam serverům, které jsou definovány níže:

| Hodnota | Jméno     | L 343, 22.12.2009, s. 1).                                                                       |
| ------- | --------- | ----------------------------------------------------------------------------------------------- |
| 0       | Žádný     | No protocol                                                                                     |
| 1       | TCP       | **[Přenosový kontrolní protokol](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2       | UDP       | **[Protokol pro uživatele Datagramu](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**    |
| 4       | WebSocket | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                                        |

Vezměte prosím na vědomí, že tato vlastnost je `příznaků` , proto je možné zvolit jakoukoliv kombinaci dostupných hodnot. Podívejte se na **[json mapování](#json-mapping)** , pokud se chcete dozvědět více. Nepovolením žádného z příznaků vyústí v `Žádná možnost` a tato možnost je sama o sobě neplatná.

Ve výchozím nastavení bude ASF používat všechny dostupné Steam protokoly jako měřítko pro boj s výpadky a dalšími podobnými problémy se Steamem. Typicky chcete změnit tuto vlastnost, pokud chcete omezit ASF na použití pouze jednoho nebo dvou specifických protokolů. Taková opatření by mohla být nezbytná v různých situacích, například pokud jste zablokovali UDP provoz na firewallu a chcete zajistit, aby procházel pouze TCP provozem, nebo pokud používáte `WebProxy` a chcete jej použít také pro připojení klienta Steamu, protože to podporuje pouze `protokol WebSocket`.

Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `Aktualizovat kanál`

`byte` type with default value of `1`. Tato vlastnost definuje kanál aktualizace, který se používá, buď pro automatické aktualizace (pokud `UpdatePeriod` je větší než `0`), nebo aktualizovat oznámení (jiné). V současné době ASF podporuje tři aktualizační kanály - `0` , které se nazývá `Nic`, `1`, který se nazývá `Stabilní`a `2`, nazvané `PreRelease`. `Stabilní` kanál je výchozím uvolňovacím kanálem, který by měl být používán většinou uživatelů. `PreRelease` kanál kromě `stabilních` zahrnuje také **předběžné verze** vyhrazené pro pokročilé uživatele a další vývojáře za účelem testování nových funkcí, potvrdit opravy chyb nebo poskytnout zpětnou vazbu k plánovaným vylepšením. **PreRelease verze často obsahují neupravené chyby, funkce work-in-progress nebo přepsané implementace**. Pokud se nepovažujete za pokročilého uživatele, zůstaňte v aktualizačním kanálu `1` (`Stable`. `PreRelease` kanál je vyhrazen uživatelům, kteří vědí, jak hlásit chyby, řeší otázky a poskytuje zpětnou vazbu - nebude poskytnuta žádná technická podpora. Check out ASF **[release cycle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** if you'd like to learn more. Můžete také nastavit `UpdateChannel` na `0` (`Žádný`), pokud chcete úplně odstranit všechny kontroly verzí. Nastavení `UpdateChannel` na `0` zcela zakáže celou funkčnost související s aktualizacemi, včetně `příkazu Aktualizace`. Pomocí `Žádný` kanál je **silně odraden** kvůli vystavení všem problémům (zmíněným v popisu `UpdatePeriod` ) níže).

**Pokud nevíte, co děláte**, my **důrazně** doporučujeme ponechat ho ve výchozím nastavení.

---

### `Aktualizovat Period`

`byte` type with default value of `24`. Tato vlastnost definuje, jak často by aplikace ASF měla kontrolovat automatické aktualizace. Aktualizace jsou klíčové nejen pro získání nových funkcí a kritických bezpečnostních záplat, ale také pro přijímání oprav, vylepšení výkonu, vylepšení stability a dalších. Když je nastavena hodnota větší než `0` , ASF se automaticky stáhne, nahradí, a restartovat sám (pokud `Automatický restart` dovoluje), pokud je k dispozici nová aktualizace. Abychom toho dosáhli, ASF zkontroluje každou `UpdatePeriod` hodinu, pokud je k dispozici nová aktualizace v našem úložišti GitHub. Hodnota `0` zakáže automatické aktualizace, ale stále umožňuje provést příkaz `update` ručně. Můžete se také zajímat o nastavení vhodné `UpdateChannel` , kterou by `UpdatePeriod` měla sledovat.

Proces aktualizace ASF zahrnuje aktualizaci celé struktury složek, kterou používá ASF, ale bez dotyku s vlastními konfiguracemi nebo databázemi umístěnými v adresáři `config` - to znamená, že všechny další soubory, které nesouvisejí s ASF v jeho adresáři, mohou být ztraceny během aktualizace. Výchozí hodnota `24` je dobrá rovnováha mezi zbytečnými kontrolami a ASF, která je dost čerstvá.

Pokud nemáte **silný** důvod pro vypnutí této funkce, měli byste mít povoleno automatické aktualizace v rozumném `UpdatePeriod` **pro vaše dobré**. Není to jen proto, že nepodporujeme nic jiného než nejnovější stabilní vydání ASF, ale také proto, že **poskytujeme naši bezpečnostní záruku pouze pro nejnovější verzi**. Pokud používáte zastaralou verzi ASF, tak se úmyslně vystavujete všem problémům, od malých chyb přes porušenou funkčnost, končící **[trvalým pozastavením účtu Steam](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**takže my **důrazně doporučujeme**, pro své vlastní dobro, abychom zajistili, že vaše ASF verze je aktuální. Automatické aktualizace nám umožňují rychle reagovat na všechny druhy problémů vypnutím nebo záplatováním problematického kódu dříve, než bude možné jej eskalovat - pokud se z něj nerozhodnete, ze všech našich bezpečnostních záruk a rizikových důsledků ztrácíte díky běžícím kódům, které by mohly být potenciálně škodlivé, nejenom do sítě Steam, ale také (z definice) na váš vlastní Steam účet.

---

### `WebLimiterDelay`

Typ `ushort` s výchozí hodnotou `300`. Tato vlastnost definuje v milisekundách minimální dobu zpoždění mezi odesláním dvou po sobě jdoucích žádostí na stejnou webovou službu Steam. Toto zpoždění je vyžadováno jako služba **[AkamaiGhost](https://www.akamai.com)** , kterou Steam interně používá, zahrnuje omezení sazby na základě celkového počtu žádostí odeslaných v daném časovém období. Za normálních okolností je akamai blok poměrně těžko dosažitelný, ale pod velmi těžkým pracovním zatížením s obrovskou frontou žádostí, je možné spustit, pokud stále posíláme příliš mnoho požadavků po příliš krátkou dobu.

Výchozí hodnota byla nastavena na základě předpokladu, že ASF je jediným nástrojem pro přístup ke Steam webovým službám, zejména `Steamcommunity. om`, `api.steampowered.com` a `store.steampowered.com`. Pokud používáte jiné nástroje posílající požadavky na stejné webové služby, pak byste se měli ujistit, že váš nástroj obsahuje podobnou funkčnost `WebLimiterDelay` a nastaví se na dvojnásobek výchozí hodnoty, což by bylo `600`. To zaručuje, že za žádných okolností nebudete posílat více než 1 požadavek na `300` ms.

Obecně snížení `WebLimiterDelay` pod výchozí hodnotou je **silně odradeno** , protože by mohlo vést k různým blokům souvisejícím s IP, z nichž některé mohou být trvalé. Výchozí hodnota je dostatečně dobrá pro spuštění jediné instance ASF na serveru, stejně jako používání ASF v normálním scénáři společně s originálním Steam klientem. Měla by být správná pro většinu použití a měli byste ji pouze zvýšit (nikdy ji nesnižovat). Stručně řečeno, globální počet všech požadavků odeslaných z jediné IP domény Steam by nikdy neměl přesáhnout 1 požadavek na `300` ms.

Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `WebProxy`

Typ `string` s výchozí hodnotou `null`. Tato vlastnost definuje webovou proxy adresu, která bude použita pro interní komunikaci související s httpem, zejména pro služby jako `github. om`, `api.steampowered.com`, `steamcommunity.com` a `store.steampowered.com`. Platí pro obecnou komunikaci (non-bot specifice), stejně jako pro komunikaci specifickou pro bot, pokud není nastavena jejich ekvivalentní vlastnost konfigurace `WebProxy`. Prošlapávání požadavků ASF by mohlo být mimořádně užitečné pro obcházení různých typů firewallů, zejména velkých firewallů v Číně.

Tato vlastnost je definována jako uri řetězec:

> Řetězec URI se skládá ze systému (podporovaného: http/https/socks4/socks4a/socks5), hostitele a volitelného portu. Příkladem kompletního uri řetězce je `"http://contoso.com:80"`.

Pokud vaše proxy vyžaduje ověření uživatele, musíte také nastavit `WebProxyUsername` a/nebo `WebProxyPassword`. Neexistuje-li žádná taková potřeba, postačuje samotné založení tohoto majetku.

Pokud potřebujete i proxying interní síťovou komunikaci na Steamu (CM), pak byste se měli ujistit, že nakonfigurujete **[`SteamProtocols`](#steamprotocols)** bota na hodnotu, která umožňuje pouze přepravu socketu. . hodnota `4`, protože pro proxying jsou podporovány pouze webové sockety.

Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `WebProxyPassword`

Typ `string` s výchozí hodnotou `null`. Tato vlastnost definuje pole pro heslo používané v základním, digestu, NTLM, a Kerberos ověřování, které je podporováno cílovým počítačem `WebProxy` , poskytuje proxy funkci. Pokud vaše proxy nevyžaduje přihlašovací údaje, není potřeba nic zde zadat. Použití této možnosti má smysl pouze v případě, že `WebProxy` je také použito, protože jinak nemá žádný účinek.

Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `WebProxyUsername`

Typ `string` s výchozí hodnotou `null`. Tato vlastnost definuje pole uživatelského jména používané v základním, digestu, NTLM, a Kerberos ověřování, které je podporováno cílovým počítačem `WebProxy` , poskytuje proxy funkci. Pokud vaše proxy nevyžaduje přihlašovací údaje, není potřeba nic zde zadat. Použití této možnosti má smysl pouze v případě, že `WebProxy` je také použito, protože jinak nemá žádný účinek.

Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

## Konfigurace bota

Jak byste již měli vědět, každý bot by měl mít vlastní konfiguraci založenou na příkladu JSON struktuře níže. Začněte rozhodnout, jak chcete pojmenovat svého bota (např. `1.json`, `main. syn`, `primary.json` nebo `AnythingElse.json`) a přejděte do konfigurace.

**Poznámka:** Bot nemůže být pojmenován `ASF` (protože toto klíčové slovo je vyhrazeno pro globální nastavení), ASF bude také ignorovat všechny konfigurační soubory začínající tečkou.

Konfigurace bota má následující strukturu:

```json
{
    "AcceptGifts": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Enabled": false,
    "FarmingOrders": [],
    "FarmingPreferences": 0,
    "GamesPlayedWhileIdle": [],
    "GamingDeviceType": 1,
    "HoursUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "MachineName": null,
    "MatchableTypes": [5],
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "RedeemingPreferences": 0,
    "RemoteCommunication": 3,
    "SendTradePeriod": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "TransferableTypes": [1, 3, 5],
    "UseLoginKeys": true,
    "UserInterfaceMode": 0,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Všechny možnosti jsou vysvětleny níže:

### `Přijímat dárky`

`bool` type with default value of `false`. Pokud je povoleno, ASF automaticky přijme a vyplatí všechny Steam dárky (včetně dárkových karet) odeslané botu. To zahrnuje také dárky odeslané od jiných uživatelů než těch, které jsou definovány v `SteamUserPermissions`. Nezapomeňte, že dárky zaslané na e-mailovou adresu nejsou přímo předány klientovi, takže ASF je bez vaší pomoci nepřijímá.

Tato možnost je doporučena pouze pro alt účty, protože je velmi pravděpodobné, že nechcete automaticky vyplatit všechny dárky odeslané na váš primární účet. Pokud si nejste jisti, zda chcete tuto funkci povolit, nebo ne, ponechte ji s výchozí hodnotou `false`.

---

### `Chování Bothaviour`

`byte flags` type with default value of `0`. Tato vlastnost definuje chování aplikace ASF při různých událostech a je definována takto:

| Hodnota | Jméno                                | L 343, 22.12.2009, s. 1).                                                                                     |
| ------- | ------------------------------------ | ------------------------------------------------------------------------------------------------------------- |
| 0       | Žádný                                | Žádné speciální chování bota, nastavte výchozí nastavení                                                      |
| 1       | Odmítnout InvalidFriendFriendInvites | Bude způsobit, že ASF odmítne (místo ignorace) neplatné pozvánky přítele                                      |
| 2       | Odmítnout neplatné obchody           | Bude způsobeno, že ASF odmítne (místo ignorace) neplatné obchodní nabídky                                     |
| 4       | Odmítnout Invalidní pozvánky skupiny | Bude způsobeno odmítnutí ASF (místo ignorace) neplatných pozvánek skupiny                                     |
| 8       | Oznámení o odstranění inventáře      | způsobí, že ASF automaticky odmítne všechna oznámení inventáře                                                |
| 16      | MarkPřijaté zprávy                   | způsobí, že ASF automaticky označí všechny přijaté zprávy jako přečtené                                       |
| 32      | MarkBotMessagesAsRead                | způsobí, že aplikace ASF automaticky označí zprávy od jiných ASF botů (běží ve stejné instanci) jako přečtené |
| 64      | DisableIncomingTradesParsing         | způsobí, že ASF nikdy nezpracovává příchozí obchodní nabídky                                                  |

Vezměte prosím na vědomí, že tato vlastnost je `příznaků` , proto je možné zvolit jakoukoliv kombinaci dostupných hodnot. Podívejte se na **[json mapování](#json-mapping)** , pokud se chcete dozvědět více. Není povoleno žádné označení výsledků v `Žádná možnost`.

Obecně chcete změnit tuto vlastnost, pokud chcete změnit různá nastavení automatizace vztahující se k aktivitě bota. Výchozí nastavení zahrnuje ASF běžící v neinvazivním režimu, který umožňuje pouze výhodnou automatizaci, která není proti vůli uživatele.

Neplatná pozvánka přítele je pozvánka, která nepochází od uživatele s oprávněním `Rodina Sdílení` (definováno v `SteamUserPermissions`nebo vyšší. ASF v normálním režimu ignoruje tyto pozvánky, jak byste očekávali, což vám dává volnou volbu, zda je přijmout, či nikoli. `OdmítectInvalidFriendInvites` způsobí, že tyto pozvánky budou automaticky odmítnuty, což prakticky zakáže ostatním lidem možnost přidat vás do jejich seznamu přátel (protože ASF odmítne všechny takové požadavky, kromě lidí definovaných v `SteamUserPermissions`). Pokud nechcete otevřeně odepřít všechny pozvánky kamarádů, neměli byste tuto možnost povolit.

Neplatná obchodní nabídka je nabídka, která není přijata přes vestavěný modul ASF. Více v této záležitosti naleznete v sekci **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** , která výslovně definuje, jaké typy obchodu ASF jsou ochotny přijímat automaticky. Platné obchody jsou také definovány v jiných nastaveních, zejména `TradingPreferences`. `RejectInvalidTrades` způsobí, že všechny neplatné obchodní nabídky budou zamítnuty, místo aby byly ignorovány. Pokud nechcete otevřeně odepřít všechny obchodní nabídky, které nejsou automaticky přijaty ASF, neměli byste tuto možnost povolit.

Neplatná skupinová pozvánka je pozvánka, která nepochází ze skupiny `SteamMasterClanID`. ASF v normálním režimu ignoruje pozvánky skupiny, jak byste očekávali, můžete se sami rozhodnout, jestli se chcete připojit k určité skupině Steam, nebo ne. `RejectInvalidGroupInvites` způsobí, že všechny pozvánky skupiny budou automaticky odmítnuty, efektivně znemožňuje pozvání vás do jiné skupiny než `SteamMasterClanID`. Pokud nechcete otevřeně odepřít všechny pozvánky skupiny, neměli byste tuto možnost povolit.

`Zrušení inventáře` je velmi užitečné, když se začnete obtěžovat neustálým Steam oznámením o přijímání nových položek. ASF se nemůže zbavit samotného oznámení, jak je zabudováno ve vašem Steam klientovi, ale je schopen automaticky vymazat oznámení po jeho přijetí, což již nezanechá oznámení "nové položky v inventáři". Pokud chcete vyhodnotit všechny přijaté položky (zejména karty farmované pomocí ASF), pak byste samozřejmě neměli tuto možnost povolit. Když začnete šíleně, nezapomeňte, že je to nabízeno jako možnost.

`MarkReceivedMessagesAsRead` automaticky označí **všechny** zprávy, které obdrží účet, na kterém ASF běží, jak soukromé, tak skupinové, podle čtení. Toto by obvykle mělo být používáno alt účty pouze pro vymazání příchozího "nové zprávy", např. při provádění příkazů ASF. Nedoporučujeme tuto možnost pro primární účty, pokud se nechcete snížit z jakéhokoliv druhu oznámení o nových zprávách, **včetně** ty, které se staly, když jste byli v režimu offline, za předpokladu, že ASF stále zůstává otevřená a odmítne ji.

`MarkBotMessagesAsRead` funguje podobným způsobem tím, že označuje pouze zprávy bota jako přečtené. Ale mějte na paměti, že při použití této možnosti na skupinových chatech s vašimi boty a jinými lidmi, Steam implementace potvrzení zprávy **také** uznává všechny zprávy, které se staly **před** tím, co jste se rozhodli označit. takže pokud s jakoukoli šancí nechcete uniknout nesouvisející zprávě, která se odehrála mezi nimi, obvykle se chcete vyhnout používání této funkce. Je samozřejmě také riskantní, když máte více primárních účtů (např. od různých uživatelů) běžících ve stejné instanci ASF, protože můžete také uniknout jejich normální zprávy mimo ASF.

`DisableIncomingTradesParsing` zabrání ASF analyzovat příchozí obchodní nabídky, to znamená, že celá funkce obchodování související s tím bude nefunkční. Vzhledem k tomu, že ASF pracuje ve výchozím nastavení v nejméně invazivním režimu, přijímá pouze obchodní nabídky od uživatelů `Master` a výše, se nikdy nedotkne jiných obchodních nabídek - příchozí obchody jsou ve výchozím nastavení povoleny. Toto nastavení má největší smysl pro lidi, kteří by chtěli zajistit žádné další požadavky/režijní náklady spojené s parsováním obchodů, znemožňování celé logiky v procesu, například proto, že vědí, že jejich boti nikdy neobdrží žádosti o mistrovský obchod, a proto nevyžadují vůbec účast ASF na své obchodní činnosti. Mějte na paměti, že tato volba zakáže také všechny další možnosti, které závisejí na příchozích obchodech. jako `Přijímání darů` nebo `SteamTradeMatcher` - vlastní pluginy také nebudou moci běžně zpracovávat příchozí obchodní nabídky.

Pokud si nejste jisti, jak nakonfigurovat tuto možnost, je nejlepší ponechat ji ve výchozím nastavení.

---

### `CompleteTypesToSend`

`ImmutableHashSet<byte>` type with default value of be prázdný. Pokud se ASF provádí s vyplněním zadané sady typů položek, které jsou zde uvedeny, může automaticky odeslat páru se všemi dokončenými nastaveními uživateli s oprávněním `Master` , které je velmi pohodlné, pokud chcete použít daný účet bota pro e. . STM odpovídá, zatímco přesouvá nastavení na jiný účet. Tato volba funguje stejně jako `loot` , proto mějte na paměti, že vyžaduje uživatele s oprávněním `Master` , můžete také potřebovat platnou `SteamTradeToken`, a také používat účet, který je způsobilý k obchodování na prvním místě.

Od dneška jsou v tomto nastavení podporovány následující typy položek:

| Hodnota | Jméno           | L 343, 22.12.2009, s. 1).                                                    |
| ------- | --------------- | ---------------------------------------------------------------------------- |
| 3       | FoilTradingCard | Varianta půdy `TradingCard`                                                  |
| 5       | TradingCard     | Karta pro parní obchodování, která se používá pro výrobu odznaků (bez fólie) |

Vezměte prosím na vědomí, že bez ohledu na výše uvedené nastavení. ASF se zeptá pouze na **[Steam komunitní položky](https://steamcommunity.com/my/inventory/#753_6)** (`appID` z 753, `kontextID` z 6) takže všechny herní předměty, dárky a podobně, jsou z obchodní nabídky vyloučeny podle definice.

Vzhledem k dodatečnému režijnímu riziku použití této možnosti, je doporučeno jej použít pouze na účtech botů, které mají reálnou šanci na vlastní dokončení - například: nemá smysl aktivovat, pokud již používáte předvolbu `SendOnFarmingFinished` v `FarmingPreferences`Příkaz `SendTradePeriod` nebo `loot` obvyklým způsobem.

Pokud si nejste jisti, jak nakonfigurovat tuto možnost, je nejlepší ponechat ji ve výchozím nastavení.

---

### `Vlastní HráčWhileFarmení`

Typ `string` s výchozí hodnotou `null`. Když ASF farmí a může se zobrazovat jako "Hraj neparní hru: `CustomGamePlayedWhileFarming`" namísto současné farmové hry. To může být užitečné, pokud chcete dát svým přátelům vědět, že se chováte, přesto nechcete používat `OnlineStatus` of `Offline`. Vezměte prosím na vědomí, že ASF nemůže zaručit aktuální pořadí zobrazení sítě Steam, je to tedy pouze návrh, který může, nebo nemusí být správně zobrazen. Zejména vlastní jméno se nezobrazí v `Complex` farmářském algoritmu, pokud ASF vyplní všechny sloty `32` hrami, které vyžadují vyčerpání. Výchozí hodnota `null` zakáže tuto funkci.

ASF poskytuje několik speciálních proměnných, které můžete volitelně použít ve svém textu. `{0}` bude nahrazeno ASF pomocí `AppID` současné farmové zvěře (farmových her), zatímco `{1}` bude nahrazeno ASF pomocí `GameName` aktuálně chovaných her.

---

### `Vlastní GamePlayedWhileIdle`

Typ `string` s výchozí hodnotou `null`. Podobně jako `CustomGamePlayedWhileFarming`, ale pro situaci, kdy ASF nemá co dělat (účet je plně propracovaný). Vezměte prosím na vědomí, že ASF nemůže zaručit aktuální pořadí zobrazení sítě Steam, je to tedy pouze návrh, který může, nebo nemusí být správně zobrazen. Pokud používáte `GamesPlayedWhileIdle` spolu s touto možností, pak mějte na paměti, že `GamesPlayedWhileIdle` má prioritu, proto nemůžete deklarovat více než `31` , jako jinak `CustomGamePlayedWhileIdle` nebude moci tento slot obsadit pro vlastní název. Výchozí hodnota `null` zakáže tuto funkci.

---

### `Povoleno`

`bool` type with default value of `false`. Tato vlastnost definuje, zda je bota povolena. Povolená instance bota (`true`) se automaticky spustí při spuštění aplikace ASF, zatímco zakázaná instance bota (`false`) bude muset být spuštěna ručně. Ve výchozím nastavení je každý bot zakázán, takže pravděpodobně chcete přepnout tuto vlastnost na `true` pro všechny své boty, které by měly být spuštěny automaticky.

---

### `Zemědělské objednávky`

`ImmutableList<byte>` type with default value of be empty. Tato vlastnost definuje **preferovanou** objednávku aplikovanou ASF pro daný účet bota. V současné době jsou k dispozici následující zemědělské objednávky:

| Hodnota | Jméno                         | L 343, 22.12.2009, s. 1).                                                          |
| ------- | ----------------------------- | ---------------------------------------------------------------------------------- |
| 0       | Neobjednané                   | Žádné třídění, mírně zlepšující výkon CPU                                          |
| 1       | AppIDsvzestupně               | Zkuste nejdříve farmit hry s nejnižšími `aplikacemi`                               |
| 2       | AppIDssestupně                | Zkuste nejdříve farmit hry s nejvyššími `aplikacemi`                               |
| 3       | CardDropsAscending            | Zkuste farmit hry s nejnižším počtem karet, které zbývají první                    |
| 4       | CardDropsDescending           | Zkuste farmit hry s nejvyšším počtem karet, které zbývají jako první               |
| 5       | HodinaVzestupně               | Zkuste farmové hry s nejnižším počtem hodin jako první                             |
| 6       | Hodiny sestupně               | Zkuste farmit hry s nejvyšším počtem hodin jako první                              |
| 7       | Názvy vzestupně               | Zkus farmit hry v abecedním pořadí od A                                            |
| 8       | Jména sestupně                | Zkuste farmit hry v obráceném abecedním pořadí, počínaje Z                         |
| 9       | Náhodný                       | Snažte se farmovat hry v naprosto náhodném pořadí (různé na každém běhu programu)  |
| 10      | BadgeLevelsAscending          | Zkuste nejdříve farmit hry s nejnižší úrovní odznaku                               |
| 11      | BadgeLevelsDescending         | Pokuste se nejdříve farmovat hry s nejvyšší úrovní odznaku                         |
| 12      | Uplatnit datumTimesAscending  | Zkuste nejdříve farmit nejstarší hry na našem účtu                                 |
| 13      | Uplatnit datumTimesDescending | Zkuste nejdříve farmit nejnovější hry na našem účtu                                |
| 14      | MarketableAscending           | Pokuste se nejdříve farmit hry s neprodejnými kartami (varování: drahé na výpočet) |
| 15      | MarketableSestupně            | Pokuste se nejdříve farmit hry s tržními karet (varování: drahé na výpočet)        |

Vzhledem k tomu, že tato vlastnost je pole, umožňuje použít v pevném pořadí několik různých nastavení. Například můžete zahrnout hodnoty `15`, `11` a `7` nejprve seřadit podle obchodovatelných her, pak těmi s nejvyšší úrovní odznaku a nakonec abecedně. Jak se dá odhadnout, pořadí ve skutečnosti záleží na obráceném pořadí (`7`, `11` a `15`) dosáhne něčeho úplně jiného (seřadí hry nejprve abecedně, a protože jména her jsou jedinečná, ostatní dva jsou fakticky zbytečné). Většina lidí pravděpodobně využije jen jeden pořádek ze všech z nich, ale v případě, že chcete, můžete také seřadit podle dalších parametrů.

Také si všimněte slova "try" ve všech výše uvedených popisech - aktuální pořadí ASF je silně ovlivněno vybraným algoritmem **[karet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** a třídění ovlivní pouze výsledky, které ASF považuje za stejný výkon. Například v `Jednoduchém` algoritmu, vybrané `FarmingOrders` by měly být plně respektovány v aktuální farmové relaci (protože každá hra má stejnou výkonnost) zatímco v `složitém` algoritmu je skutečný pokyn ovlivněn nejprve hodinami, a poté seřazeno podle zvolené `Objednávky chovu`. To povede k různým výsledkům, neboť hry s existujícím časem budou mít přednost před ostatními, tak efektivně ASF preferuje nejdříve hry, které již prošly požadovaným `HoursUntilCardDrops` , a pouze pak tyto hry dále třídíte podle Vámi zvolené `FarmingOrders`. Obdobně platí, že jakmile se ASF vymkne z již vyčerpaných her, se nejprve seřadí zbývající fronta podle hodin (protože to sníží čas potřebný pro vyčerpání všech zbývajících titulků na `HoursUntilCardDrops`). Tato vlastnost konfigurace je proto pouze **návrh** , který se ASF pokusí respektovat, pokud to nemá nepříznivý vliv na výkon (v tomto případě bude ASF vždy upřednostňovat výkon zemědělství před `FarmingOrders`).

Také je k dispozici fronta priorit, která je přístupná pomocí `fq` **[příkazy](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Pokud se používá, skutečná zemědělská objednávka je nejprve seřazena podle výkonu, pak podle farmové fronty a nakonec podle `FarmingOrders`.

---

### `Předvolby chovu`

`byte flags` type with default value of `0`. Tato vlastnost definuje chování ASF v souvislosti s chovem a je definována takto:

| Hodnota | Jméno                     |
| ------- | ------------------------- |
| 0       | Žádný                     |
| 1       | FarmingPausedBydefault    |
| 2       | Vypnutí ukončeno          |
| 4       | SendonFarmingFined        |
| 8       | Pouze pro FarmPrioritu    |
| 16      | Přeskočit vratné hry      |
| 32      | Přeskočit nehrané hry     |
| 64      | EnableRiskyCardsDiscovery |
| 256     | AutoUnpackBoosterPacks    |

Vezměte prosím na vědomí, že tato vlastnost je `příznaků` , proto je možné zvolit jakoukoliv kombinaci dostupných hodnot. Podívejte se na **[json mapování](#json-mapping)** , pokud se chcete dozvědět více. Není povoleno žádné označení výsledků v `Žádná možnost`.

Všechny možnosti jsou popsány níže.

`FarmingPausedBydefault` definuje počáteční stav modulu `CardsFarmer`. Obvykle bot automaticky spustí farmení po jeho spuštění, buď z důvodu `zapnuto` nebo `spustit`. Pomocí `FarmingPausedBydefault` lze použít, pokud chcete ručně `obnovit` automatický zemědělský proces, například proto, že chcete vždy používat `play` a nikdy nepoužívat automatický `modul CardsFarmer` - to funguje přesně stejně jako `pause` **[příkaz](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

`VypínáníOnFarmingFinished` vám umožní vypnout bota, jakmile bude farmář. Aplikace ASF je obvykle "obsazena" účet pro celou dobu činnosti, který je aktivní. Pokud je daný účet veden u chovu, ASF jej pravidelně kontroluje (každý `IdleFarmingPeriod` hodin), pokud byly mezitím přidány některé nové hry s parními kartami, aby mohl pokračovat v zemědělství tohoto účtu, aniž by musel proces restartovat. Je to užitečné pro většinu lidí, protože ASF může v případě potřeby automaticky pokračovat v zemědělství. Možná však budete chtít zastavit proces, pokud je daný účet plně obhospodařován, můžete toho dosáhnout použitím této vlajky. Pokud je povoleno, ASF bude pokračovat s odhlášením při úplném hospodaření, což znamená, že již nebude pravidelně kontrolován nebo obsazen. Měli byste se sami rozhodnout, zda dáváte přednost aplikaci ASF před prací na daném botě po celou dobu, nebo pokud by to možná měla ASF zastavit, když se uskutečňuje zemědělský proces.

Tato volba dává největší smysl kombinovat s `ShutdownIfMožsible`, takže jakmile budou všechny účty zastaveny, ASF se také ukončí, dát stroj do klidu a umožnit vám naplánovat další akce, jako je spánek nebo vypnutí ve stejný okamžik posledního shození karty.

`SendOnFarmingFinished` vám umožňuje automaticky odeslat obchod s párou obsahující vše farmované až na tento bod uživateli s oprávněním `Master` , které je velmi pohodlné, pokud se nechcete obtěžovat se svými obchody. Tato volba funguje stejně jako `loot` , proto mějte na paměti, že vyžaduje uživatele s oprávněním `Master` , můžete také potřebovat platnou `SteamTradeToken`, a také používat účet, který je způsobilý k obchodování na prvním místě. Kromě zahájení činnosti `loot` po dokončení chovu, ASF bude také iniciovat `loot` na každé nové oznámení (když není zemědělství), a po dokončení každého obchodu, který má za následek nové položky (vždy), když je tato možnost aktivní. To je užitečné zejména pro "přeposílání" položek obdržených od ostatních lidí na náš účet. Typicky budete chtít používat **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** spolu s touto funkcí, i když to není požadavek, pokud máte v úmyslu včas zpracovat 2FA potvrzení.

`FarmityQueueOnly` definuje, zda by ASF měla zvážit pouze automatické farmování aplikací, které jste si přidali do prioritní farmové fronty dostupné s `fq` **[příkazy](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Pokud je tato volba povolena, ASF přeskočí všechny `aplikace` , které v seznamu chybí, efektivně vám umožňuje cherry-pick-games pro automatické zemědělství. Mějte na paměti, že pokud jste do fronty nepřidali žádné hry, ASF se bude chovat, jako by na vašem účtu nebylo nic na farmě.

`SkipRefundableGames` definuje, zda by ASF měl přeskočit hry, které jsou stále vratné z automatického zemědělství. Vratná hra je hra, kterou jste zakoupili za poslední 2 týdny přes Steam Store a ještě nehráli déle než 2 hodiny, jak je uvedeno na stránce **[Steam refunds](https://store.steampowered.com/steam_refunds)**. ASF standardně přehlíží politiku vracení Steamu zcela a farmy, jak by většina lidí očekávala. Můžete však použít tuto vlajku, pokud chcete zajistit, že ASF nebude v brzké době obhospodařovat žádné z Vašich vratných her, abyste mohli tyto hry sami vyhodnotit a v případě potřeby vrátit, aniž byste se museli obávat ASF negativně ovlivňovat hry. Vezměte prosím na vědomí, že pokud tuto možnost povolíte, hry, které jste zakoupili ze Steam Store, nebudou od data splatnosti farmovány pomocí ASF až po 14 dní. který se neprojeví jako nic, pokud váš účet nevlastní nic jiného.

`SkipUnplayedGames` definuje, zda by ASF měl přeskočit hry, které jste ještě nespustili. Nehraná hra v tomto kontextu znamená, že nemáte žádné nahrávání na Steamu. Pokud použijete tuto vlajku, pak budou tyto hry přeskočeny, dokud se Steam pro ně nezaregistruje. To vám umožní lépe kontrolovat, které hry má ASF nárok na farmu a přeskočit ty, které jste ještě neměli šanci vyzkoušet, udržuje vybrané Steam funkce užitečnější - například navrhování nehraných her pro hraní.

`EnableRiskyCardsDiscovery` umožňuje další záložní aktivaci, která se spustí, když ASF nemůže načíst jednu nebo více stránek s odznaky, a proto není schopen najít hry pro farmování. Zejména některé účty s obrovským množstvím karet mohou způsobit situaci, kdy již není možné načíst stránky s odznaky (kvůli režijním nákladům), a tyto účty nejsou pro zemědělství možné jen proto, že nemůžeme načíst informace, na jejichž základě můžeme proces zahájit. Pro tyto několik případů tato možnost umožňuje použít alternativní algoritmus. který využívá kombinaci přídavných zařízení pro výrobu a sliznic, pro které je účet způsobilý, za účelem nalezení potenciálně dostupných her k nečinnosti, pak utratí nadměrné množství prostředků na ověřování a získávání požadovaných informací, a pokusy o zahájení výrobního procesu s omezeným množstvím údajů a informací, abychom nakonec dosáhli situace, kdy stránka s odznakem načítá a my budeme moci použít normální přístup. Vezměte prosím na vědomí, že při použití tohoto záložního systému ASF funguje pouze s omezenými daty, Proto je zcela běžné, aby ASF našla mnohem méně kapek než ve skutečnosti - jiné kapky se objeví v pozdější fázi zemědělského procesu.

Tato možnost se nazývá "rizikový" z velmi dobrého důvodu - je velmi pomalá a vyžaduje pro provoz značné množství zdrojů (včetně síťových požadavků), Proto je **nedoporučil** povolit a zejména z dlouhodobého hlediska. Tuto možnost byste měli použít pouze v případě, že jste dříve zjistili, že váš účet není schopen načíst stránky s odznaky, a ASF na tom nemůže fungovat, vždy, když se nenačte potřebné informace, aby mohl být proces zahájen. I kdybychom udělali vše, co je v našich silách, abychom proces co nejvíce optimalizovali, je stále možné, aby se tato možnost nevypala a mohla by způsobit nežádoucí výsledky, jako dočasné a možná i trvalé zákazy ze strany Steamu, které by posílaly příliš mnoho požadavků a jinak způsobily režijní náklady na servery Steamu. Proto vás upozorňujeme předem a nabízíme tuto možnost s naprosto nulovými zárukami, používáte ji na vlastní riziko.

`AutoUnpackBoosterPacks` automaticky rozbalí všechny balíčky booster při obdržení oznámení o nových položkách. To vám umožní okamžitě získat další karetní kapky, které by mohly být požadovány zejména v kombinaci s jinými možnostmi (např. . `SteamTradeMatcher` nebo `CompleteTypesToSend`).

---

### `Herní PlayedWhileIdle`

`ImmutableHashSet<uint>` type with default value of be prázdný. Pokud ASF nemá co farmit, může místo toho hrát zadané parní hry (`appIDs`). Přehrávání her takovým způsobem zvyšuje vaše "hodiny hrané" z těchto her, ale nic jiného kromě toho ne. Aby tato funkce fungovala správně, váš Steam účet **musí vlastnit** platnou licenci pro všechny `appIDs` , které zde specifikujete. To zahrnuje také F2P hry. Tato funkce může být současně povolena s `CustomGamePlayedWhileIdle` pro přehrávání vašich vybraných her při zobrazení vlastního stavu ve Steam síti. ale v tomto případě, jako v případě `CustomGamePlayedWhileFarming` , není aktuální pořadí zobrazení garantováno. Vezměte prosím na vědomí, že Steam umožňuje ASF hrát pouze až do výše `32` `aplikací` celkem, Proto můžete v této nemovitosti vložit pouze tolik her.

---

### `HeringDeviceType`

Typ `ushort` s výchozí hodnotou `1`. Tato vlastnost může povolit další online funkce na platformě Steam a je definována níže:

| Hodnota | Jméno         | Popis                            |
| ------- | ------------- | -------------------------------- |
| 1       | Standardní PC | Žádný zvláštní režim, výchozí    |
| 544     | SteamDeck     | Vytvářejte se jako Steam balíček |

Základní `EGamingDeviceType` typu, že tato vlastnost je založena na více dostupných hodnotách, podle našeho nejlepšího vědomí však od dnešního dne nemají absolutně žádný účinek, a proto se jim podařilo zviditelnit.

Pokud si nejste jisti, jak nastavit tuto vlastnost, nechte ji výchozí hodnotou `1`.

---

### `HodinaUntilCardDrops`

`byte` type with default value of `3`. Tato vlastnost definuje, pokud je účet omezen, a pokud ano, na kolik počátečních hodin. Omezené kapky karet znamenají, že účet nepřijímá žádné kapky z dané hry, dokud se hra nehraje alespoň na `HoursUntilCardDrops` hodiny. Bohužel neexistuje žádný kouzelný způsob, jak to zjistit, takže ASF spoléhá na vás. Tato vlastnost ovlivňuje **[karetní algoritmus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** , který bude použit. Nastavení tohoto majetku maximalizuje zisky a minimalizuje čas potřebný k tomu, aby se karty chovaly. Nezapomeňte, že neexistuje žádná zřejmá odpověď, zda byste měli použít nějakou či jinou hodnotu, protože to plně závisí na vašem účtu. Zdá se, že starší účty, které nikdy nepožádaly o vrácení daně, mají neomezené karty, proto by měli použít hodnotu `0`, zatímco nové účty a ti, kteří požádali o vrácení daně, omezili karetní kapky o hodnotu `3`. To je však jen teorie a nemělo by se považovat za pravidlo. Výchozí hodnota pro tuto vlastnost byla nastavena na základě "menší zla" a většiny případů použití.

---

### `Lootable Typy`

`ImmutableHashSet<byte>` type with default value of `1, 3, 5` steam items. Tato vlastnost definuje chování ASF při lootování - obě ruční, pomocí **[příkazu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**stejně jako automatická, pomocí jedné nebo více vlastností konfigurace. ASF zajistí, že do obchodní nabídky budou zahrnuty pouze položky z `LootableTypy` , Proto vám tato vlastnost umožňuje zvolit si, co chcete dostávat v obchodní nabídce, která je vám zasílána.

| Hodnota | Jméno               | Popis                                                                        |
| ------- | ------------------- | ---------------------------------------------------------------------------- |
| 0       | Neznámý             | Každý typ, který neodpovídá žádnému z níže uvedených                         |
| 1       | BoosterPack         | Booster balíček obsahující 3 náhodné karty ze hry                            |
| 2       | Emotikon            | Emotikon pro použití v Steam Chat                                            |
| 3       | FoilTradingCard     | Varianta půdy `TradingCard`                                                  |
| 4       | Profilové pozadí    | Pozadí profilu, které se má použít na Vašem Steam profilu                    |
| 5       | TradingCard         | Karta pro parní obchodování, která se používá pro výrobu odznaků (bez fólie) |
| 6       | SteamGemy           | Parní kameny používané pro výtvarné nebo stavební účely                      |
| 7       | Prodejní položka    | Speciální předměty oceněné při prodeji na Steamu                             |
| 8       | Spotřební materiál  | Speciální spotřební zboží, které po použití zmizí                            |
| 9       | Modifikátor profilu | Speciální položky, které mohou změnit vzhled profilu Steam                   |
| 10      | Samolepka           | Speciální položky, které lze použít na Steam chatu                           |
| 11      | ChatEffect          | Speciální položky, které lze použít na Steam chatu                           |
| 12      | MiniProfilePozadí   | Speciální pozadí pro profil Steam                                            |
| 13      | AvatarProfileFrame  | Speciální rám avataru pro Steam profil                                       |
| 14      | AnimatedAvatar      | Speciální animovaný avatar pro Steam profil                                  |
| 15      | Skin klávesnice     | Speciální vzhled klávesnice pro parní balíček                                |
| 16      | Spouštěcí video     | Speciální spouštěcí video pro Steam deck                                     |

Vezměte prosím na vědomí, že bez ohledu na výše uvedené nastavení. ASF se zeptá pouze na **[Steam komunitní položky](https://steamcommunity.com/my/inventory/#753_6)** (`appID` z 753, `kontextID` z 6) takže všechny herní předměty, dárky a podobně, jsou z obchodní nabídky vyloučeny podle definice.

Výchozí ASF nastavení je založeno na nejběžnějším používání bota, s lootováním balíčků pouze booster a obchodních karet (včetně fólií). Zde definovaná vlastnost vám umožňuje změnit toto chování jakýmkoli způsobem, který vám vyhovuje. Mějte prosím na paměti, že všechny typy nedefinované výše budou zobrazeny jako `Neznámý` typ. což je zvláště důležité, když Valve uvolní nějakou novou Steam položku, který bude také označen jako `Neznámý` ASF, dokud nebude přidán zde (v budoucí verzi). To je důvod, proč obecně není doporučeno zahrnout `Neznámý` typ do `LootableTypy`, pokud nevíte, co děláte, a také chápete, že ASF odešle celý váš inventář v obchodní nabídce, pokud Steam Network znovu rozbije a nahlásí všechny vaše předměty jako `Neznámý`. Můj silný návrh je nezahrnout `Neznámý` typ do `LootableTypy`, i když očekáváte, že vše (jinak).

---

### `Jméno stroje`

Typ `string` s výchozí hodnotou `null`. ASF použije tuto vlastnost při přihlášení do sítě Steam, které lze použít pro přizpůsobení s ohledem na to, jak přesně bude Steam zobrazovat ASF stroj a relaci. . při zobrazování zařízení, která jsou aktuálně přihlášena v **[zde](https://store.steampowered.com/account/authorizeddevices)**.

ASF poskytuje několik speciálních proměnných, které můžete volitelně použít ve svém textu. `{0}` bude nahrazeno názvem stroje poskytnutým vaším OS, `{1}` bude nahrazeno veřejným identifikátorem ASF, zatímco `{2}` bude nahrazeno verzí ASF.

Pokud nevíte, co děláte, měli byste jej zachovat s výchozí hodnotou `null`. V tomto případě bude ASF interně rozhodovat o správné hodnotě, která je `{0} ({1}/{2})` od dneška. Mějte na paměti, že je to pouze návrh, že síť Steam může nebo nemusí plně respektovat.

---

### `Typy odpovídající`

`ImmutableHashSet<byte>` type with default value `5` Item Tato vlastnost definuje, které typy položek Steam mohou být porovnány, když je povolena možnost `SteamTradeMatcher` v `TradingPreferences`. Typy jsou definovány takto:

| Hodnota | Jméno               | Popis                                                                        |
| ------- | ------------------- | ---------------------------------------------------------------------------- |
| 0       | Neznámý             | Každý typ, který neodpovídá žádnému z níže uvedených                         |
| 1       | BoosterPack         | Booster balíček obsahující 3 náhodné karty ze hry                            |
| 2       | Emotikon            | Emotikon pro použití v Steam Chat                                            |
| 3       | FoilTradingCard     | Varianta půdy `TradingCard`                                                  |
| 4       | Profilové pozadí    | Pozadí profilu, které se má použít na Vašem Steam profilu                    |
| 5       | TradingCard         | Karta pro parní obchodování, která se používá pro výrobu odznaků (bez fólie) |
| 6       | SteamGemy           | Parní kameny používané pro výtvarné nebo stavební účely                      |
| 7       | Prodejní položka    | Speciální předměty oceněné při prodeji na Steamu                             |
| 8       | Spotřební materiál  | Speciální spotřební zboží, které po použití zmizí                            |
| 9       | Modifikátor profilu | Speciální položky, které mohou změnit vzhled profilu Steam                   |
| 10      | Samolepka           | Speciální položky, které lze použít na Steam chatu                           |
| 11      | ChatEffect          | Speciální položky, které lze použít na Steam chatu                           |
| 12      | MiniProfilePozadí   | Speciální pozadí pro profil Steam                                            |
| 13      | AvatarProfileFrame  | Speciální rám avataru pro Steam profil                                       |
| 14      | AnimatedAvatar      | Speciální animovaný avatar pro Steam profil                                  |
| 15      | Skin klávesnice     | Speciální vzhled klávesnice pro parní balíček                                |
| 16      | Spouštěcí video     | Speciální spouštěcí video pro Steam deck                                     |

Samozřejmě, typy, které byste měli použít pro tuto vlastnost, obvykle zahrnují pouze `2`, `3`, `4` a `5`, protože pouze tyto typy jsou podporovány STM. ASF obsahuje řádnou logiku pro objevování rarity předmětů, proto je také bezpečné porovnat emotikony nebo pozadí, protože ASF bude řádně zvažovat férové pouze ty položky ze stejné hry a typu, které také sdílejí stejnou raritu.

Vezměte prosím na vědomí, že **ASF není obchodní bot** a **se nebude zajímat o tržní cenu**. Pokud nepovažujete předměty stejné rarity ze stejné sady za stejný kurz, pak tato možnost není pro vás. Před tím, než se rozhodnete změnit toto nastavení, vyhodnoťte prosím dvakrát a pokud rozumíte tomuto příkazu a souhlasíte s ním.

Pokud nevíte, co děláte, měli byste jej zachovat s výchozí hodnotou `5`.

---

### `OnlineFlags`

`ushort flags` type with default value of `0`. Tato vlastnost funguje jako doplněk **[`OnlineStatus`](#onlinestatus)** a specifikuje další funkce online oznámené síti Steam. Vyžaduje **[`OnlineStatus`](#onlinestatus)** jiný než `Offline`a je definován jako níže:

| Hodnota | Jméno              | Popis                                                 |
| ------- | ------------------ | ----------------------------------------------------- |
| 0       | Žádný              | Žádné zvláštní indikátory přítomnosti online, výchozí |
| 2       | InJoinableGame     | Klient je ve hře                                      |
| 8       | Dálkové přehrávání | Klient používá společně vzdálenou relaci              |
| 256     | ClientTypeWeb      | Klient používá webové rozhraní                        |
| 512     | ClientTypeMobile   | Klient používá mobilní aplikaci                       |
| 1024    | ClientTypeTenfoot  | Klient používá velký obrázek                          |
| 2048    | ClientTypeVR       | Klient používá VR sluchátka                           |

Vezměte prosím na vědomí, že tato vlastnost je `příznaků` , proto je možné zvolit jakoukoliv kombinaci dostupných hodnot. Podívejte se na **[json mapování](#json-mapping)** , pokud se chcete dozvědět více. Není povoleno žádné označení výsledků v `Žádná možnost`.

Základní `EPersonaStateFlag` typu, že tato vlastnost je založena na více dostupných vlajkách, podle našeho nejlepšího vědomí však od dnešního dne nemají absolutně žádný účinek, a proto se jim podařilo zviditelnit.

Pokud si nejste jisti, jak nastavit tuto vlastnost, ponechte ji s výchozí hodnotou `0`.

---

### `OnlineStatus`

`byte` type with default value of `1`. Tato vlastnost specifikuje status komunity Steam, se kterým bude bota po přihlášení do sítě Steam oznámen. V současné době si můžete vybrat jeden z níže uvedených stavů:

| Hodnota | Jméno             |
| ------- | ----------------- |
| 0       | Offline           |
| 1       | Online            |
| 2       | Busy              |
| 3       | Mimo              |
| 4       | Odložit           |
| 5       | Pohled na ToTrade |
| 6       | Vyhledat ToPlay   |
| 7       | Neviditelné       |

`Offline` stav je velmi užitečný pro primární účty. Jak byste měli vědět, farmení hry skutečně ukazuje váš stav páry jako "Hraj hru: XXX", které mohou být pro své přátele zavádějící, matou je, že hrajete hru, zatímco ve skutečnosti jste pouze farmí. Pomocí `Offline` se tento problém řeší - váš účet se nikdy nezobrazí jako "in-her", když se chováte parní karty s ASF. To je možné díky skutečnosti, že se ASF nemusí přihlásit do Steam komunity, aby fungovala správně, tak ve skutečnosti hrajeme tyto hry, napojené na Steam síť, ale bez oznámení naší online přítomnosti vůbec. Mějte na paměti, že hrané hry používající offline status budou stále počítány do vaší skladby a zobrazí se jako "nedávno přehrávané" ve vašem profilu.

Kromě toho je tato funkce také důležitá, pokud chcete dostávat oznámení a nepřečtené zprávy při spuštění aplikace ASF, aniž by byl Steam klient otevřen současně. Je tomu tak proto, že ASF působí jako samotný Steam klient a zda si to ASF přeje nebo ne, Steam vysílá všechny tyto zprávy a další události. Toto není problém, pokud máte spuštěn váš vlastní klient ASF i Steam, protože oba klienti dostávají přesně tytéž události. Pokud však běží jen ASF, síť Steam by mohla označit některé události a zprávy jako „doručené“, navzdory tomu, že ho váš tradiční Steam klient nepřijal, protože není přítomen. Offline status také řeší tento problém, protože ASF není nikdy zvažován pro události komunity v tomto případě, takže všechny nepřečtené zprávy a další události budou po návratu řádně označeny jako nepřečtené.

Je důležité si uvědomit, že ASF běžící v režimu `Offline` nebude **** schopen přijímat příkazy obvyklým Steam chatem, jako chat, stejně jako celá komunita je ve skutečnosti zcela offline. Řešením tohoto problému je použití `Nviditelného` režimu, který funguje podobným způsobem (který nevystavuje stav), ale zachovává schopnost přijímat zprávy a reagovat na ně (tak také možnost zrušit oznámení a nepřečtené zprávy, jak je uvedeno výše). `Režim neviditelné` dává největší smysl na alt účtech, které nechcete odhalit (status -wise), ale stále je možné posílat příkazy.

Existuje však jeden úlovek s režimem `Neviditelný` - nefunguje dobře s primárními účty. Je to proto, že **jakákoliv** Steam relace, která je v současné době online **odhaluje** status, i když ASF sama nikoli. To je způsobeno aktuálním omezením/chybou sítě Steam, kterou nelze opravit na straně aplikace ASF, takže pokud chcete použít režim `Invisible` , musíte také zajistit, aby **všechny** další relace ke stejnému účtu použil režim `Nviditelný`. Tak tomu bude na alt účtech, kde ASF je, doufejme, jedinou aktivní relací, ale na primárních účtech budete téměř vždy dávat přednost před Vašimi přáteli jako `Online` , skrývá pouze aktivitu ASF, a v tomto případě `Neviditelný režim` bude pro vás zcela zbytečný (namísto toho doporučujeme použít `Offline` ) režim). Doufejme, že toto omezení/chyba bude v budoucnu vyřešena Valvem, ale neočekávám, že se to brzy stane...

Pokud si nejste jisti, jak nastavit tuto vlastnost, doporučujeme použít hodnotu `0` (`Offline`) pro primární účty, a výchozí `1` (`Online`).

---

### `Formát hesla`

`byte` typ s výchozí hodnotou `0` (`PlainText`). Tato vlastnost definuje formát vlastnosti `SteamPassword` a v současné době podporuje hodnoty specifikované v sekci **[bezpečnost](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**. Měli byste se řídit zadanými instrukcemi, protože budete muset zajistit, aby vlastnost `SteamPassword` skutečně obsahovala heslo v souladu s `heslem`. Jinými slovy, když změníte `PasswordFormat` , pak váš `SteamPassword` by měl být **již** v tomto formátu, nezaměřovat se jen na to. Pokud nevíte, co děláte, měli byste jej zachovat s výchozí hodnotou `0`.

Pokud se rozhodnete změnit `PasswordFormat` bota, který se již alespoň jednou přihlásil do sítě Steam, je možné, že při dalším spuštění bota dojde k jednorázové dešifrování chyby - to je způsobeno tím, že `PasswordFormat` je také používán pro automatické šifrování/dešifrování citlivých vlastností v `Botě. b` soubor databáze. Tuto chybu můžete bezpečně ignorovat, protože ASF se bude moci z této situace zotavit sama. Pokud se to však děje na neustálém základě, např. každý restart, měl by být prošetřen.

---

### `Uplatnit předvolby`

`byte flags` type with default value of `0`. Tato vlastnost definuje chování ASF při použití cd-klíčů a je definována takto:

| Hodnota | Jméno                              | Popis                                                                                                                                      |
| ------- | ---------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| 0       | Žádný                              | Žádné zvláštní předvolby pro splacení, výchozí                                                                                             |
| 1       | Přeposílání                        | Přeposlat klávesy pro použití jiným botům                                                                                                  |
| 2       | Distribuce                         | Distribuovat všechny klíče mezi sebe a ostatní boty                                                                                        |
| 4       | KeepMissinghry                     | Zachovat klíče pro (potenciálně) chybějící hry při přesměrování a ponechat nepoužité                                                       |
| 8       | AssumeWalletKeyOnBadActivationCode | Předpokládejte, že klávesy `BadActivationCode` jsou stejné jako `CannotRedeemCodeFromClient`, a proto se je snažte vyplatit jako peněženku |

Vezměte prosím na vědomí, že tato vlastnost je `příznaků` , proto je možné zvolit jakoukoliv kombinaci dostupných hodnot. Podívejte se na **[json mapování](#json-mapping)** , pokud se chcete dozvědět více. Není povoleno žádné označení výsledků v `Žádná možnost`.

`Přeposlání` způsobí, že bota přeposílá klíč, který není možné použít, na jiného spojeného a přihlášeného bota, který chybí konkrétní hru (pokud je to možné ke kontrole). Nejběžnější situace je přesměrování hry `Již zakoupené` jinému botovi, kterému chybí tato konkrétní hra, ale tato možnost zahrnuje i jiné scénáře, jako `DoesNotOwnRequiredApp`, `RateLimited` nebo `RestrictedCountry`.

`Distribuce` způsobí, že bota rozdělí všechny přijaté klíče mezi sebe a další boty. To znamená, že každý bot získá z dávky jediný klíč. Obvykle se používá pouze v případě, že používáte mnoho klíčů pro stejnou hru, a chcete je rovnoměrně rozdělit mezi své boty, na rozdíl od vyhrávání klíčů pro různé hry. Tato funkce nedává smysl, pokud sdílíte pouze jeden klíč v jedné akci `redeem` (protože neexistují žádné další klíče, které by měly být distribuovány).

`KeepMissingGames` způsobí, že bota přeskočí `přesměrování` , když si nemůžeme být jisti, zda je klíč vyměněn ve skutečnosti vlastněn naším botem, nebo ne. This basically means that `Forwarding` will apply **only** to `AlreadyPurchased` keys, instead of covering also other cases such as `DoesNotOwnRequiredApp`, `RateLimited` or `RestrictedCountry`. Typicky chcete použít tuto možnost na primárním účtu, pro zajištění, že klíče na ně budou vyměněny, pokud se váš bot stane například dočasně `RateLimited`. Jak můžete odhadnout z popisu, toto pole nemá absolutně žádný účinek, pokud `Přeposlání` není povoleno.

`AssumeWalletKeyOnBadActivationCode` způsobí, že klíče `BadActivationCode` budou považovány za `CannotRedeemCodeFromClient`, a proto vyústí v ASF snahu o jejich vyplacení jako peněženky klíče. To je potřeba, protože Steam může oznámit klíče peněženky jako `BadActivationCode` (a ne `CannotRedeemCodeFromClient` , jak byl použit), v důsledku toho se společnost ASF nikdy nepokouší je vyplatit. However, we recommend **against** using this preference, as it'll result in ASF trying to redeem every invalid key as a wallet code, resulting in excessive amount of (potentially invalid) requests sent to the Steam service, with all the potential consequences. Místo toho doporučujeme použít `ForceAssumeWalletKey` **[`Slevy ^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** režim, zatímco vědomě vyhráváme klíče peněženky, které umožní potřebné zpracování pouze v případě, že je vyžadováno podle potřeby.

Povolení jak `přesměrování` , tak `distribuce` přidá funkci distribuce nad rámec přesměrování, čímž se ASF snaží vyplatit jeden klíč na všech botech nejprve (přesouvá) před přechodem na další (distribuce). Typicky chcete tuto možnost použít pouze v případě, že chcete `přesměrování`, ale se změněným chováním přepínání bota na klíči, místo vždy v pořadí s každým klíčem (který by byl `přesměrování`). Toto chování může být prospěšné, pokud víte, že většina nebo dokonce všechny vaše klíče jsou vázány na stejnou hru, protože v této situaci `Přeposlání` pouze by se pokusilo všechno vyplatit na jednom botovi (což má smysl, pokud jsou vaše klíče pro jedinečné hry), a `přesměrování` + `Distribuce` přepne bota na další klíč, "distribuovat" úkol zaměřit nový klíč na jiného bota než prvotní (což má smysl, pokud jsou klíče pro stejnou hru, přeskakuji jeden bezbodový pokus na klíč).

Aktuální pořadí robotů pro všechny scénáře je abecední, s výjimkou robotů, kteří nejsou k dispozici (nejsou připojeni, zastaveni ani podobně). Mějte prosím na paměti, že existuje limit pro každý IP a každý účet na hodinový výběr, a každé pokusy o opravu, které neskončily s `OK` přispějí k neúspěšným pokusům. ASF udělá vše pro minimalizaci počtu selhání `AlreadyPurchased` , např. pokusem se vyhnout přesměrování klíče k jinému botu, který již vlastní tuto hru, ale není vždy zaručeno pracovat kvůli tomu, jak Steam manipuluje s licencemi. Použití označení jako `Forwarding` nebo `Distributing` vždy zvýší vaši pravděpodobnost, že hit `RateLimited`.

Také mějte na paměti, že klíče k botům, ke kterým nemáte přístup, nemůžete předávat ani distribuovat. To by mělo být zřejmé, ale ujistěte se, že jste alespoň `Operátor` všech botů, které chcete zahrnout do vašeho procesu odměňování, například s `status ASF` **[příkazem](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `Vzdálená komunikace`

`byte flags` type with default value of `3`. Tato vlastnost definuje chování pro každý bot ASF, pokud jde o komunikaci s dálkovými službami třetí strany a je definována takto:

| Hodnota | Jméno              | Popis                                                                                                                                                                                                                                                       |
| ------- | ------------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0       | Žádný              | Žádné povolené komunikace třetích stran, vykreslování vybraných funkcí ASF nepoužitelných                                                                                                                                                                   |
| 1       | Skupina SteamGroup | Umožňuje komunikaci s **[ASF skupinou](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                        |
| 2       | PublicListing      | Umožňuje komunikaci s STM **[ASF seznamem](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** pro uvedení do seznamu, pokud uživatel také povolil `SteamTradeMatcher` v **[`Nastavení obchodu`](#tradingpreferences)** |

Vezměte prosím na vědomí, že tato vlastnost je `příznaků` , proto je možné zvolit jakoukoliv kombinaci dostupných hodnot. Podívejte se na **[json mapování](#json-mapping)** , pokud se chcete dozvědět více. Není povoleno žádné označení výsledků v `Žádná možnost`.

Tato možnost nezahrnuje všechny komunikace třetích stran nabízené ASF, pouze ty, které nejsou implicitní v jiném nastavení. Například, pokud jste povolili automatické aktualizace ASF, ASF bude komunikovat jak s GitHub (pro stažení), tak s naším serverem (pro ověření kontrolního součtu) podle vaší konfigurace. Obdobně povolení `MatchActively` v **[`TradingPreferences`](#tradingpreferences)** znamená komunikaci s naším serverem k načítání uvedených botů, která je nezbytná pro tuto funkci.

Další vysvětlení k tomuto tématu je k dispozici v sekci **[dálková komunikace](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `Období odeslání`

`byte` type with default value of `0`. Tato vlastnost funguje velmi podobně jako `SendOnFarmingFinished` v `FarmingPreferences`s jedním rozdílem - namísto zasílání obchodu při uskutečňování zemědělství, Můžeme ji také poslat každou hodinu `SendTradePeriod` bez ohledu na to, kolik musíme farmit zbývá. To je užitečné, pokud chcete `loot` vaše alt účty obvykle namísto čekání na dokončení farmování. Výchozí hodnota `0` tuto funkci zakáže pokud chcete, aby váš bot odeslal obchodování. . každý den byste měli dát `24` zde.

Typicky budete chtít používat **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** spolu s touto funkcí, i když to není požadavek, pokud máte v úmyslu včas zpracovat 2FA potvrzení. Pokud si nejste jisti, jak nastavit tuto vlastnost, ponechte ji s výchozí hodnotou `0`.

---

### `Přihlášení přes Steamin`

Typ `string` s výchozí hodnotou `null`. Tato vlastnost definuje vaše Steam přihlašovací jméno - které používáte pro přihlášení do páry. Kromě definování přihlášení přes Steam zde, také můžete zachovat výchozí hodnotu `null` , pokud chcete zadat své Steam přihlašovací údaje při každém startu ASF místo vložení do konfigurace. To může být pro vás užitečné, pokud nechcete ukládat citlivá data do konfiguračního souboru.

---

### `SteamMasterClanID`

`ulong` type with default value of `0`. Tato vlastnost definuje páru skupiny pára, ke které by se měl bot automaticky připojit, včetně skupinového chatu. Můžete zkontrolovat steamID vaší skupiny navigací na stránku **[](https://steamcommunity.com/groups/archiasf)**a přidat `/memberslistxml? ml=1` na konec odkazu, takže odkaz bude vypadat jako **[tento](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. Pak můžete získat steamID vaší skupiny z výsledku, je v `<groupID64>` tagu. Například, bylo by to `103582791440160998`. Kromě pokusu připojit se k dané skupině při startu bude bot automaticky přijímat skupinové pozvánky do této skupiny, což vám umožňuje ručně pozvat svého bota, pokud má vaše skupina soukromé členství. Pokud nemáte žádnou skupinu určenou pro své boty, měli byste tuto vlastnost zachovat s výchozí hodnotou `0`.

---

### `SteamParentalCode`

Typ `string` s výchozí hodnotou `null`. Tato vlastnost definuje PIN pro parní rodiče. ASF vyžaduje přístup ke zdrojům chráněným parní párou, proto pokud používáte tuto funkci, byste měli poskytnout ASF rodičovskému odemknutí PIN, aby mohl fungovat normálně. Výchozí hodnota `null` znamená, že pro odemknutí tohoto účtu není vyžadován žádný PIN pro parní rodiče, a to je pravděpodobně to, co chcete, pokud nepoužíváte parní funkčnost.

Za omezených okolností je ASF také schopen vygenerovat platný kód rodičů na Steamu samotném i když to vyžaduje nadměrné množství zdrojů OS a dodatečný čas na jejich dokončení, nemluvě o tom, že není zaručeno, že uspěje, proto doporučujeme nespolehnout se na tuto funkci a místo toho vložit platnou `SteamParentalCode` v konfiguraci ASF. Pokud ASF určí, že PIN je vyžadován a nebude schopen vygenerovat jeden sám o sobě, bude vás žádat o vstup.

---

### `SteamPassword`

Typ `string` s výchozí hodnotou `null`. Tato vlastnost definuje vaše Steam heslo - které používáte pro přihlášení do páry. Kromě definování Steam hesla zde také můžete zachovat výchozí hodnotu `null` , pokud chcete při každém startu aplikace ASF zadat vaše heslo pro Steam heslo. To může být pro vás užitečné, pokud nechcete ukládat citlivá data do konfiguračního souboru.

---

### `SteamTradeToken`

Typ `string` s výchozí hodnotou `null`. Když máte bot na seznamu přátel, pak vám bot může okamžitě poslat obchod, aniž byste se obávali obchodního tokenu, proto můžete ponechat tuto vlastnost ve výchozím nastavení `null`. Pokud se však rozhodnete NENÍ mít svého bota ve vašem seznamu přátel, pak budete muset vygenerovat a vyplnit obchodní token jako uživatele, kterému tento bot očekává odeslání obchodů. Jinými slovy, tato vlastnost by měla být vyplněna obchodním tokenem účtu, který je definován s `Master` oprávněním v `SteamUserPermissions` z **instance tohoto**.

Chcete-li najít váš token jako přihlášený uživatel s oprávněním `Master` , navigujte **[zde](https://steamcommunity.com/my/tradeoffers/privacy)** a podívejte se na vaši obchodní URL. Token, který hledáme, je vyroben z 8 znaků po `&token=` části ve vašem obchodě URL. Tyto 8 znaků byste měli zkopírovat a dát sem jako `SteamTradeToken`. Nezahrnujte celou adresu URL obchodování, ani `&token=` , pouze token samotný (8 znaků).

---

### `SteamUserPermissions (Automatic Copy)`

`ImmutableDictionary<ulong, byte>` type with default value of be empty. Tato vlastnost je slovníková vlastnost, která mapuje daného uživatele Steam identifikovaného jeho 64bitovým ID pary. `byte` číslo, které specifikuje jeho oprávnění v instanci ASF. V současné době dostupná oprávnění bota v ASF jsou definována jako:

| Hodnota | Jméno          | Popis                                                                                                                                                                                                           |
| ------- | -------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0       | Žádný          | žádné zvláštní oprávnění, Toto je především referenční hodnota, která je přiřazena k ID Steam chybí v tomto slovníku - není třeba nikoho definovat s tímto oprávněním                                           |
| 1       | Sdílení rodiny | Poskytuje minimální přístup uživatelům sdílení rodin. Znovu opakuji, jedná se hlavně o referenční hodnotu, protože ASF je schopen automaticky objevit ID Steam, které jsme povolili pro používání naší knihovny |
| 2       | Operátor       | Poskytuje základní přístup k daným instancím bota, hlavně přidávání licencí a vykoupením klíčů                                                                                                                  |
| 3       | Mistr          | Poskytuje plný přístup k dané instanci bota                                                                                                                                                                     |

Stručně řečeno, tato vlastnost umožňuje zpracovat oprávnění pro dané uživatele. Permissions are important mainly for access to ASF **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, but also for enabling many ASF features, such as accepting trades. Například můžete nastavit svůj vlastní účet jako `Master`, a umožněte `Operátorovi` přístup k 2-3 vašim přátelům, aby mohli snadno použít klíče pro váš bota s ASF, zatímco **není** způsobilý. . k jeho zastavení. Díky tomu můžete snadno přiřadit oprávnění k danému uživateli a nechat je použít bota k něčemu určenému Vámi.

Doporučujeme nastavit přesně jednoho uživatele jako `Master`a libovolnou částku, kterou si přejete jako `Operator` a níže. Zatímco je technicky možné nastavit více `Masters` a ASF bude fungovat správně, například přijetím všech obchodů zaslaných botovi, ASF použije pouze jeden z nich (s nejnižším identifikátorem páry) pro každou akci, která vyžaduje jediný cíl, například žádost `o loot` , tak také vlastnosti jako `SendOnFarmingFinished` v `FarmingPreferences` nebo `SendTradePeriod`. Pokud plně rozumíte těmto omezením, zejména skutečnost, že `loot` požadavek vždy odešle položky do `Master` s nejnižším ID pary, bez ohledu na `Master` , který příkaz skutečně provedl, pak zde můžete definovat více uživatelů s oprávněním `Master` , ale přesto doporučujeme jedno hlavní schéma.

Je hezké poznamenat, že existuje ještě jedno další `vlastník` , které je deklarováno jako `SteamOwnerID` globální vlastnictví. Pro nikoho zde nemůžete přiřadit `vlastník` . jako `Vlastnost SteamUserPermissions` definuje pouze oprávnění, která se vztahují k instanci bota, a ne ASF jako proces. `SteamOwnerID` se pro úkoly související s boty zachází stejně jako `Master`, takže definování `SteamOwnerID` zde není nutné.

---

### `Období kontroly obchodu`

`byte` type with default value of `60`. Normálně ASF zpracovává příchozí obchodní nabídky hned po obdržení oznámení o jedné, ale někdy to kvůli Steam závitům v té době nemůže, a tyto obchodní nabídky zůstávají ignorovány, dokud nedojde k dalšímu obchodnímu oznámení nebo k restartu bota, které mohou vést k tomu, že obchody budou zrušeny nebo že nebudou k dispozici v tomto pozdějším čase. Pokud je tento parametr nastaven na nenulovou hodnotu, ASF dodatečně zkontroluje tyto zbývající obchody každou minutu `TradeCheckPeriod`. Výchozí hodnota je vybrána s rovnováhou mezi dodatečnými požadavky na Steam servery a ztrátou příchozích obchodů. Pokud však pouze používáte ASF na farmové karty a neplánujete automatické zpracování žádných příchozích obchodů, můžete nastavit na `0` pro úplné vypnutí této funkce. Na druhé straně, pokud se váš bot účastní veřejného systému [ASF se seznamem](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) nebo poskytuje jiné automatizované služby jako obchodní bot, můžete chtít snížit tento parametr na `15` minut nebo tak včas zpracovat všechny obchody.

---

### `TradingPreferences`

`byte flags` type with default value of `0`. Tato vlastnost definuje chování ASF při obchodování a je definována níže:

| Hodnota | Jméno               | Popis                                                                                                                                                                                                                     |
| ------- | ------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0       | Žádný               | Žádné zvláštní obchodní předvolby, výchozí                                                                                                                                                                                |
| 1       | Přijímání darů      | Přijmout obchody, ve kterých nic neztrácíme                                                                                                                                                                               |
| 2       | SteamTradeMatcher   | Pasivně se účastní obchodů typu **[STM](https://www.steamtradematcher.com)**. Navštivte **[obchodování](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** pro více informací               |
| 4       | Vše shody           | Vyžaduje, aby byl nastaven `SteamTradeMatcher` a v kombinaci s ním - také přijímá špatné obchody vedle těch dobrých a neutrálních                                                                                         |
| 8       | DontAcceptBotTrades | Nepřijímá automaticky `loot` obchody z jiných instancí bota                                                                                                                                                               |
| 16      | Aktivní zápas       | Aktivně se účastní obchodů typu **[STM](https://www.steamtradematcher.com)**. Navštivte **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** pro více informací |

Vezměte prosím na vědomí, že tato vlastnost je `příznaků` , proto je možné zvolit jakoukoliv kombinaci dostupných hodnot. Podívejte se na **[json mapování](#json-mapping)** , pokud se chcete dozvědět více. Není povoleno žádné označení výsledků v `Žádná možnost`.

Pro další vysvětlení obchodní logiky ASF a popisu každé dostupné vlajky navštivte sekci **[obchodování](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**.

---

### `Přenosné typy`

`ImmutableHashSet<byte>` type with default value of `1, 3, 5` steam items. Tato vlastnost definuje, které typy položek Steam budou zváženy pro přenos mezi boty, během `transfer` **[příkazu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. ASF zajistí, aby do obchodní nabídky byly zahrnuty pouze položky z `Přenosných typů` , Proto vám tato vlastnost umožňuje vybrat, co chcete obdržet v obchodní nabídce, která se zasílá jednomu z vašich botů.

| Hodnota | Jméno               | Popis                                                                        |
| ------- | ------------------- | ---------------------------------------------------------------------------- |
| 0       | Neznámý             | Každý typ, který neodpovídá žádnému z níže uvedených                         |
| 1       | BoosterPack         | Booster balíček obsahující 3 náhodné karty ze hry                            |
| 2       | Emotikon            | Emotikon pro použití v Steam Chat                                            |
| 3       | FoilTradingCard     | Varianta půdy `TradingCard`                                                  |
| 4       | Profilové pozadí    | Pozadí profilu, které se má použít na Vašem Steam profilu                    |
| 5       | TradingCard         | Karta pro parní obchodování, která se používá pro výrobu odznaků (bez fólie) |
| 6       | SteamGemy           | Parní kameny používané pro výtvarné nebo stavební účely                      |
| 7       | Prodejní položka    | Speciální předměty oceněné při prodeji na Steamu                             |
| 8       | Spotřební materiál  | Speciální spotřební zboží, které po použití zmizí                            |
| 9       | Modifikátor profilu | Speciální položky, které mohou změnit vzhled profilu Steam                   |
| 10      | Samolepka           | Speciální položky, které lze použít na Steam chatu                           |
| 11      | ChatEffect          | Speciální položky, které lze použít na Steam chatu                           |
| 12      | MiniProfilePozadí   | Speciální pozadí pro profil Steam                                            |
| 13      | AvatarProfileFrame  | Speciální rám avataru pro Steam profil                                       |
| 14      | AnimatedAvatar      | Speciální animovaný avatar pro Steam profil                                  |
| 15      | Skin klávesnice     | Speciální vzhled klávesnice pro parní balíček                                |
| 16      | Spouštěcí video     | Speciální spouštěcí video pro Steam deck                                     |

Vezměte prosím na vědomí, že bez ohledu na výše uvedené nastavení. ASF se zeptá pouze na **[Steam komunitní položky](https://steamcommunity.com/my/inventory/#753_6)** (`appID` z 753, `kontextID` z 6) takže všechny herní předměty, dárky a podobně, jsou z obchodní nabídky vyloučeny podle definice.

Výchozí ASF nastavení je založeno na nejběžnějším používání bota, s převodem pouze přídavných balíčků a obchodních karet (včetně fólií). Zde definovaná vlastnost vám umožňuje změnit toto chování jakýmkoli způsobem, který vám vyhovuje. Mějte prosím na paměti, že všechny typy nedefinované výše budou zobrazeny jako `Neznámý` typ. což je zvláště důležité, když Valve uvolní nějakou novou Steam položku, který bude také označen jako `Neznámý` ASF, dokud nebude přidán zde (v budoucí verzi). To je důvod, proč obecně není doporučeno zahrnout `Neznámý` typ do `přenositelné typy`, pokud nevíte, co děláte, a také chápete, že ASF odešle celý váš inventář v obchodní nabídce, pokud Steam Network znovu rozbije a nahlásí všechny vaše předměty jako `Neznámý`. Můj silný návrh je nezahrnout `Neznámý` typ do `Přenositelné typy`, i když očekáváte přenos všech.

---

### `UseLoginKey`

`bool` type with default value of `true`. Tato vlastnost definuje, zda by ASF měla pro tento Steam účet používat mechanismus přihlašovacích klíčů. Mechanismus klíčů pro přihlášení funguje velmi podobně, jako je oficiální nastavení Steam klienta "remember me", což umožňuje aplikaci ASF ukládat a používat dočasný jednorázový přihlašovací klíč pro další pokus o přihlášení, účinně přeskočit potřebu poskytnout heslo, Steam Guard nebo 2FA kód, pokud je náš přihlašovací klíč platný. Přihlašovací klíč je uložen v souboru `BotName.db` a automaticky aktualizován. Proto není nutné zadávat heslo/SteamGuard/2FA kód po úspěšném přihlášení pomocí ASF jen jednou.

Přihlašovací klíče jsou ve výchozím nastavení použity pro vaše pohodlí, takže nemusíte zadávat `SteamPassword`, SteamGuard nebo 2FA kód (pokud nepoužívejte **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**) na každém přihlášení. Je to také nadřazená alternativa, protože přihlašovací klíč může být použit pouze jednorázově a nijak nezobrazuje vaše původní heslo. Přesně stejnou metodu používá váš originální Steam klient, který ukládá vaše jméno účtu a přihlašovací klíč pro váš další pokus o přihlášení. být stejný jako `SteamLogin` s `UseLoginKeys` a prázdný `SteamPassword` v ASF.

Někteří lidé by se však mohli obávat i tohoto malého detailu, tato možnost je zde k dispozici, pokud chcete zajistit, aby aplikace ASF neukládala žádný token umožňující obnovení předchozí relace po uzavření, což povede k tomu, že při každém pokusu o přihlášení bude úplná autentizace povinná. Vypnutí této možnosti bude fungovat stejně jako nekontrola "pamatujte mě" v oficiálním Steam klientu. Pokud nevíte, co děláte, měli byste jej zachovat s výchozí hodnotou `true`.

---

### `Režim uživatelského rozhraní`

`byte` type with default value of `0`. Tato vlastnost specifikuje režim uživatelského rozhraní, se kterým bude bota po přihlášení do sítě Steam oznámen. Může to ovlivnit, jak je účet viditelný např. na Steam chatu, pokud to vaše přítomnost dovoluje prostřednictvím `OnlineStatus`. Momentálně si můžete vybrat jeden z níže uvedených režimů:

| Hodnota | Jméno      | Popis                          |
| ------- | ---------- | ------------------------------ |
| `0`     | VGUI       | Výchozí režim Steam klienta    |
| `1`     | Tenfoot    | Velký režim obrazu             |
| `2`     | Mobil      | Mobilní aplikace Steam         |
| `3`     | Webová     | Relace webového prohlížeče     |
| `5`     | MobileChat | Steam mobilní chatová aplikace |

Základní `EUIMode` typ, že tato vlastnost je založena na obsahuje více dostupných hodnot. podle našeho nejlepšího vědomí nemají od dnešního dne absolutně žádný účinek, a proto byli seškrtáni pro zviditelnění. Také vás může zajímat kontrola `GamingDeviceType`, protože zde jsou povoleny některé další funkce.

Pokud si nejste jisti, jak nastavit tuto vlastnost, ponechte ji s výchozí hodnotou `0`.

---

### `WebProxy`

Typ `string` s výchozí hodnotou `null`. Tato vlastnost definuje webovou proxy adresu, která bude použita pro interní komunikaci související s httpem, zejména pro služby jako `api. teampowered.com`, `steamcommunity.com` a `store.steampowered.com`. Pokud není nastaveno, ASF použije globální nastavení `WebProxy` uvedené výše. Prošlapávání požadavků ASF by mohlo být mimořádně užitečné pro obcházení různých typů firewallů, zejména velkých firewallů v Číně.

Tato vlastnost je definována jako uri řetězec:

> Řetězec URI se skládá ze systému (podporovaného: http/https/socks4/socks4a/socks5), hostitele a volitelného portu. Příkladem kompletního uri řetězce je `"http://contoso.com:80"`.

Pokud vaše proxy vyžaduje ověření uživatele, musíte také nastavit `WebProxyUsername` a/nebo `WebProxyPassword`. Neexistuje-li žádná taková potřeba, postačuje samotné založení tohoto majetku.

Pokud potřebujete i proxying interní síťovou komunikaci na Steamu (CM), pak byste se měli ujistit, že nakonfigurujete **[`SteamProtocols`](#steamprotocols)** bota na hodnotu, která umožňuje pouze přepravu socketu. . hodnota `4`, protože pro proxying jsou podporovány pouze webové sockety.

Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `WebProxyPassword`

Typ `string` s výchozí hodnotou `null`. Tato vlastnost definuje pole pro heslo používané v základním, digestu, NTLM, a Kerberos ověřování, které je podporováno cílovým počítačem `WebProxy` , poskytuje proxy funkci. Pokud vaše proxy nevyžaduje přihlašovací údaje, není potřeba nic zde zadat. Použití této možnosti má smysl pouze v případě, že `WebProxy` je také použito, protože jinak nemá žádný účinek.

Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

### `WebProxyUsername`

Typ `string` s výchozí hodnotou `null`. Tato vlastnost definuje pole uživatelského jména používané v základním, digestu, NTLM, a Kerberos ověřování, které je podporováno cílovým počítačem `WebProxy` , poskytuje proxy funkci. Pokud vaše proxy nevyžaduje přihlašovací údaje, není potřeba nic zde zadat. Použití této možnosti má smysl pouze v případě, že `WebProxy` je také použito, protože jinak nemá žádný účinek.

Pokud nemáte důvod k úpravě této vlastnosti, měli byste ji držet ve výchozím nastavení.

---

## Struktura souboru

ASF používá poměrně jednoduchou strukturu souborů.

```text
├── 📁 config
│     ├── ASF.json
│     ├── ASF.db
│     ├── Bot1.json
│     ├── Bot1.db
│     ├── Bot2.json
│     ├── Bot2.db
│     └── ...
├── ArchiSteamFarm.dll
├── log.txt
└── ...
```

Chcete-li přesunout ASF do nového umístění, například do jiného PC, stačí přesunout/kopírovat adresář `config` , a to je doporučený způsob provádění jakékoli formy "ASF zálohy", protože můžete vždy stáhnout zbývající část (program) z GitHubu, aniž byste riskovali poškozování interních souborů ASF, např. . pomocí chybné zálohy.

`log.txt` soubor obsahuje protokol generovaný vaším posledním spuštěním ASF. Tento soubor neobsahuje žádné citlivé informace a je velmi užitečný, pokud jde o problémy, selhává nebo jednoduše jako informace pro vás, co se stalo v posledním běhu aplikace ASF. Tento soubor se bude velmi často ptát, pokud narazíte na problémy nebo chyby. ASF automaticky spravuje tento soubor pro vás, ale pokud jste pokročilý uživatel, můžete dále upravovat ASF **[logování](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging)**.

Adresář `config` je místo, které používá konfiguraci ASF, včetně všech jeho robotů.

`ASF.json` je globální ASF konfigurační soubor. Tato konfigurace se používá ke specifikaci, jak se ASF chová jako proces, který ovlivňuje všechny boty a program samotný. Zde můžete najít globální vlastnosti jako vlastník procesu ASF, automatické aktualizace nebo ladění.

`BotName.json` je konfigurace dané instance bota. Tato konfigurace se používá pro definování chování dané instance bota, a proto jsou tato nastavení specifická pouze pro tohoto bota a nejsou sdílena mezi jinými. To vám umožní konfigurovat boty s různými nastaveními a ne nutně všechny fungují přesně stejným způsobem. Každý bot je pojmenován jedinečným identifikátorem místo `BotName`.

Kromě konfiguračních souborů používá ASF také `config` adresář pro ukládání databází.

`ASF.db` je globální soubor databáze ASF. Působí jako globální trvalé úložiště a používá se k ukládání různých informací souvisejících s procesem ASF, jako jsou IP lokální Steam servery. **Neměli byste upravovat tento soubor**.

`BotName.db` je databáze dané instance bota. Tento soubor se používá pro ukládání důležitých dat o dané instanci bota v trvalém úložišti, jako jsou přihlašovací klíče nebo ASF 2FA. **Neměli byste upravovat tento soubor**.

`BotName.keys` je speciální soubor, který může být použit pro import klíčů do **[na pozadí hry](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. Není povinné a nevygenerované, ale uznané ASF. Tento soubor je automaticky odstraněn po úspěšném importu klíčů.

`BotName.maFile` je speciální soubor, který lze použít pro import **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**. Není to povinné a nevygenerované, ale rozpoznáno ASF, pokud vaše `BotName` ještě nepoužívá ASF 2FA. Tento soubor je automaticky smazán po úspěšném importu aplikace ASF 2FA.

---

## Mapování JSON

Každá konfigurace má svůj typ. Typ vlastnosti definuje hodnoty, které jsou pro něj platné. Můžete použít pouze hodnoty, které jsou platné pro daný typ - pokud používáte neplatnou hodnotu, pak ASF nebude schopen zpracovat konfiguraci.

**Důrazně doporučujeme použít ConfigGenerator pro generování konfigurací** - zpracovává většinu nízkoúrovňových věcí (např. validaci typů) pro vás, takže stačí pouze vkládat správné hodnoty a také nemusíte rozumět níže uvedeným typům proměnných. Tato sekce je určena především pro ručně generovající/upravování konfigurací, takže vědí, jaké hodnoty mohou používat.

Typy používané ASF jsou nativní typy C# specifikované níže:

---

`bool` - Booleovský typ přijímá pouze `true` a `false`.

Příklad: `"Povoleno": true`

---

`byte` - Nepodepsaný typ byte, přijímá pouze celá čísla od `0` do `255` (včetně).

Příklad: `"ConnectionTimeout": 90`

---

`ushort` - Nepodepsaný krátký typ, který přijímá pouze celá čísla od `0` do `65535` (včetně).

Příklad: `"WebLimiterDelay": 300`

---

`uint` - Nepodepsané celé číslo, které přijímá pouze celá čísla od `0` do `4294967295` (včetně).

---

`ulong` - Nepodepsané dlouhé celé číslo, které přijímá pouze celá čísla od `0` do `18446744073709551615` (včetně).

Příklad: `"SteamMasterClanID": 103582791440160998`

---

`string` - typ řetězce, přijímá jakoukoli posloupnost znaků, včetně prázdné posloupnosti `""` a `null`. Prázdná sekvence a hodnota `null` je upravena pomocí ASF, takže je až do vašeho nastavení, které chcete použít (držíme se `null`).

Příklady: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MyAccountName"`

---

`Průvodce?` - Neullable UUID type v JSON kódované jako řetězec. UUID je vyrobeno ze 32 hexadecimálních znaků, v rozsahu od `0` do `9` a `` do `f`. ASF přijímá celou škálu platných formátů - malá písmena, velká písmena, s pomlčkami a bez nich. Kromě platného UUID, protože tato vlastnost je nullab, je přijata speciální hodnota `null` pro indikaci nedostatku UID.

Příklady: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableList<valueType>` - Nemutovatelná kolekce (seznam) hodnot v dané `hodnotěTyp`. V JSON, je definováno jako pole prvků v zadané `valueType`. ASF používá `List` k označení toho, že daná vlastnost podporuje více hodnot a že jejich pokyn může být relevantní.

Příklad pro `ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` - Nemutovatelná kolekce (sada) jedinečných hodnot v dané `hodnotěTyp`. V JSON, je definováno jako pole prvků v zadané `valueType`. ASF používá `HashSet` k určení, že daná vlastnost má smysl pouze pro jedinečné hodnoty a že na jejich objednávce nezáleží, Proto bude záměrně ignorovat jakékoliv možné duplikáty během parsování (pokud se vám to tak stalo).

Příklad pro `ImmutableHashSet<uint>`: `"Blacklist": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>` - Immutable dictionary (mapa), který mapuje jedinečný klíč specifikovaný v jeho `keyType`, pro hodnotu uvedenou v jeho `hodnotěTyp`. V JSON, je definován jako objekt s dvojicemi klíčů a hodnot. Mějte na paměti, že `keyType` je vždy citován v tomto případě, i když je hodnota typu jako `ulong`. Existuje také přísný požadavek, aby byl klíč jedinečný na celé mapě, tentokrát prosazován také JSON.

Příklad pro `ImmutableDictionary<ulong, byte>`: `"SteamUserPermissions": { "76561198174813138": 3, "765611981748137": 1 }`

---

`flags` - Atribut vlajky kombinuje několik různých vlastností do jedné konečné hodnoty použitím operací bitwise. To vám umožní vybrat jakoukoliv možnou kombinaci různých povolených hodnot zároveň. Konečná hodnota je sestavena jako součet hodnot všech povolených možností.

Například v této definici:

| Hodnota | Jméno |
| ------- | ----- |
| 0       | Žádný |
| 1       | A     |
| 2       | B     |
| 4       | C     |

Jsou zde přesně 3 smysluplné, dostupné vlajky pro zapnutí/vypnutí (`A`, `B`, `C`), a proto `8` možné platné kombinace celkově:

| Konečná hodnota | Povolené vlajky |
| --------------- | --------------- |
| 0               | `Žádný`         |
| 1               | `A`             |
| 2               | `B`             |
| 3               | `A` + `B`       |
| 4               | `C`             |
| 5               | `A` + `C`       |
| 6               | `B` + `C`       |
| 7               | `A` + `B` + `C` |

Aby bylo možné dosáhnout výše uvedeného stavu, musí být každá samostatná vlajka z definice silou dvou znaků. To je důvod, proč by dodatečná vlajka ve výše uvedeném příkladu `D`musela nést hodnotu `8` nebo vyšší.

Obvykle pro vás provedou grafické nástroje. Pokud ručně upravujete konfigurace, vždy můžete použít kalkulačku a jednoduše sčítat základní hodnoty všech příznaků, které chcete povolit - jako například výše.

Příklad: `"SteamProtocols": 7` (umožňuje vlajky s hodnotou `1` `2` a `4`, jak je vysvětleno výše)

---

## Mapování kompatibility

Kvůli omezením JavaScriptu v případě, že není možné správně serializovat jednoduchá `ulong` pole v JSON při používání webového ConfigGenerator, `ulong` pole budou vykreslena jako řetězce s `s_` prefixem ve výsledné konfiguraci. To zahrnuje například `"SteamOwnerID": 76561198006963719` , který bude napsán naším generátorem konfigurace jako `"s_SteamOwnerID": "76561198006963719"`. ASF obsahuje správnou logiku pro automatické zpracování mapování tohoto řetězce, takže `s_` položky ve vašich konfiguracích jsou ve skutečnosti platné a správně vygenerovány. Pokud generujete konfigurace, doporučujeme pokud možno držet originálních `ulong` , ale pokud se vám to nepodaří, můžete také sledovat toto schéma a kódovat je jako řetězce s `s_` prefixem přidaným k jejich názvům. Doufáme, že toto omezení JavaScriptu nakonec vyřešíme.

---

## Konfigurace kompatibility

Je nejvyšší prioritou, aby aplikace ASF zůstala kompatibilní se staršími konfiguracemi. Jak již víte, chybějící vlastnosti konfigurace jsou považovány za stejné, jako by byly definovány s jejich **výchozími hodnotami**. Pokud se tedy nová konfigurace objeví v nové verzi ASF, zůstanou všechny vaše konfigurace **kompatibilní** s novou verzí, a ASF bude považovat novou vlastnost konfigurace za definovanou s její **výchozí hodnotou**. Můžete vždy přidávat, odebírat nebo upravovat vlastnosti konfigurace podle vašich potřeb.

Doporučujeme omezit definované vlastnosti konfigurace pouze na ty, které chcete změnit, protože tímto způsobem automaticky dědíte výchozí hodnoty pro všechny ostatní, nejen aby vaše konfigurace byla čistá, ale také zvyšovala kompatibilitu v případě, že se rozhodneme změnit výchozí hodnotu pro vlastnost, kterou nechcete výslovně nastavit (např. . `WebLimiterDelay`).

Z výše uvedeného bude ASF automaticky migrovat/optimalizovat vaše konfigurace přeformátováním a odstraněním polí, která drží výchozí hodnotu. Toto chování můžete vypnout pomocí `--no-config-migrate` **[parametru příkazové řádky](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** , pokud máte konkrétní důvod, například poskytujete konfigurační soubory pouze pro čtení a nechcete, aby je ASF upravoval.

---

## Automatické znovunačtení

ASF si je vědom toho, že konfigurace, které se upravují "on-the-fly" - díky tomu ASF automaticky bude:
- Vytvořit (a případně spustit) novou instanci bota, když vytvoříte jeho konfiguraci
- Zastavit (je-li potřeba) a odebrat starý bot, když smažete jeho konfiguraci
- Zastavit (a v případě potřeby spustit) libovolný bot, když upravíte jeho konfiguraci
- Při přejmenování konfigurace restartujte bota pod novým názvem.

Všechna výše uvedená opatření jsou transparentní a budou provedena automaticky bez nutnosti restartovat program nebo zabít jiné (neovlivněné) případy botů.

Kromě toho se ASF také restartuje (pokud to `AutoRestart` umožňuje), pokud změníte základní ASF `ASF.json`. Obdobně program ukončí, pokud jej odstraníte nebo přejmenujete.

Toto chování můžete vypnout pomocí `--no-config-watch` **[parametru příkazové řádky](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** , pokud máte konkrétní důvod, například nechcete, aby aplikace ASF reagovala na změny souborů ve složce `s konfigurací`.