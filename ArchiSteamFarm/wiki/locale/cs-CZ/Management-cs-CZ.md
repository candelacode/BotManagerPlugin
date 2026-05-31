# Správa

Tento oddíl se vztahuje na témata týkající se optimálního řízení procesu ASF. I když to není přísně povinné pro používání, zahrnuje spoustu špiček, triků a osvědčených postupů, které bychom rádi sdíleli, Zejména v případě správců systémů, osob balících ASF pro použití v úložištích třetích stran i pokročilých a stejně tak pokročilých uživatelů.

---

## Služba `systemd` pro Linux

V variantách `generických` a `linux` přichází ASF s `ArchiSteamFarm@. soubor ervice` který je konfiguračním souborem služby pro **[`systemd`](https://systemd.io)**. Pokud chcete spustit ASF jako službu, například aby byla spuštěna automaticky po spuštění počítače, pak je vhodná služba `systemd` pravděpodobně nejlepším způsobem, jak to udělat, proto velmi doporučujeme místo toho, abyste jej spravovali sám prostřednictvím `nohup`, `screen` nebo podobně.

Nejprve vytvořte účet pro uživatele, se kterým chcete spustit aplikaci ASF za předpokladu, že ještě neexistuje Pro tento příklad použijeme `asf` , pokud jste se rozhodli použít jiný, budete muset nahradit `jako` ve všech našich příkladech vybraným uživatelem. Naše služba vám neumožňuje spustit ASF jako `root`, protože je to považováno za **[špatný postup](#never-run-asf-as-administrator)**.

```sh
su # Nebo sudo -i, pro vstup do root shell
useradd -m asf # Vytvořit účet, pod kterým hodláte spustit ASF
```

Dále rozbalit ASF do `/home/asf/ArchiSteamFarm`. Struktura složek je důležitá pro naši servisní jednotku, měla by to být `ArchiSteamFarm` ve vašem `$HOME`, tak `/home/<user>`. Pokud jste vše udělali správně, bude existovat soubor `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service`. Pokud používáte variantu `linux` a nerozbalili soubor na Linuxu, ale například použitý přenos souborů z Windows, pak budete muset také `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

Budeme provádět všechny níže uvedené akce jako `root`, tak se dostanete k jeho skořápce s `su` nebo `sudo -i`.

Firstly it's a good idea to ensure that our folder still belongs to our `asf` user, `chown -hR asf:asf /home/asf/ArchiSteamFarm` executed once will do it. Oprávnění mohou být chybná, např. pokud jste si stáhli a/nebo odbalili zip soubor jako `root`.

Zadruhé, pokud používáte generickou variantu ASF, musíte zajistit, aby byl příkaz `dotnet` rozpoznán a v rámci jednoho ze standardních umístění: `/usr/local/bin`, `/usr/bin` nebo `/bin`. Toto je vyžadováno pro náš systémový servis, který spustí `dotnet /path/to/ArchiSteamFarm.dll`. Zkontrolujte, zda `dotnet --info` pro vás funguje, pokud ano, napište `příkaz -v dotnet` a zjistěte, kde se nachází. Pokud jste použili oficiální instalaci, mělo by to být v `/usr/bin/dotnet` nebo v jednom z dalších dvou lokalit, což je v pořádku. Pokud je na vlastní poloze, jako je `/usr/share/dotnet/dotnet`, vytvořit symbolický odkaz **[](https://wikipedia.org/wiki/Symbolic_link)** pro něj pomocí `ln -s "$(command -v dotnet)" /usr/bin/dotnet`. Nyní `příkaz -v dotnet` by měl nahlásit `/usr/bin/dotnet`, což také zajistí, aby naše systémová jednotka fungovala. Používáte-li variantu specifickou pro OS, nemusíte v tomto ohledu nic dělat.

Dále spusťte `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/systemd/system/ArchiSteamFarm\@. ervice`vytvoří symbolický odkaz na naše servisní prohlášení a zaregistruje se do `systemd`. Symbolický odkaz umožní ASF automaticky aktualizovat vaši `systemd` jednotku jako součást aktualizace ASF - v závislosti na vaší situaci, možná budete chtít použít tento přístup, nebo jednoduše `cp` soubor a sami jej spravovat jakkoliv byste si přáli.

Poté se ujistěte, že `systemd` rozpozná naši službu:

```
statut systemctl ArchiSteamFarm@asf

<unk> ArchiSteamFarm@asf.service - ArchiSteamFarm Service (na asf)
     Načteno: načteno (/etc/systemd/system/ArchiSteamFarm@. ervice; zakázáno; předvolba vendor: povoleno)
     Aktivní: neaktivní (uhynulý)
       Dokumenty: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Věnujte zvláštní pozornost uživateli, který prohlašujeme po `@`, je to `asf` v našem případě. Naše systémová servisní jednotka od vás očekává vyhlášení uživatele, jak ovlivňuje přesné místo binární `/home/<user>/ArchiSteamFarm`, stejně jako skutečný uživatelský systém spustí proces jako.

Pokud systém vrátil výstup podobný výšce, vše je v pořádku a jsme téměř hotovi. Nyní zbývá pouze spustit naši službu jako zvolený uživatel: `systemctl start ArchiSteamFarm@asf`. Počkejte vteřinu nebo dvě a můžete zkontrolovat stav znovu:

```
statut systemctl ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (na asf)
     Načteno: načteno (/etc/systemd/system/ArchiSteamFarm@.service; vypnuto; předvolba vendor: povoleno)
     Aktivní: aktivní (spuštění) od (...)
       Dokumenty: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   Hlavní PID: (...)
(...)
```

If `systemd` states `active (running)`, it means everything went well, and you can verify that ASF process should be up and running, for example with `journalctl -r`, as ASF by default also writes to its console output, which is recorded by `systemd`. Pokud jste spokojeni s nastavením, které právě máte, můžete říct `systemd` , aby během startu automaticky spustil vaši službu. provedením příkazu `systemctl povolit příkaz ArchiSteamFarm@asf`. To je vše.

Pokud chcete proces zastavit, jednoduše spusťte `systemctl stop ArchiSteamFarm@asf`. Stejně tak pokud chcete vypnout automatické spuštění aplikace ASF při spuštění, `systemctl vypnutí ArchiSteamFarm@asf` to pro vás udělá, je to velmi jednoduché.

Vezměte prosím na vědomí, že pro naši službu `systemd` není povolen standardní vstup, nebudete moci vkládat své údaje obvyklým způsobem. Běh přes `systemd` je ekvivalentní zadáním **[`Bezhlavice: nastavení true`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** a přichází se všemi jeho důsledky. Naštěstí pro vás je velmi snadné spravovat vaše ASF prostřednictvím **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, který doporučujeme v případě, že budete muset během přihlášení poskytnout další údaje nebo jinak spravovat váš proces ASF.

### Proměnné prostředí

It's possible to supply additional environment variables to our `systemd` service, which you'll be interested in doing in case you want to for example use a custom `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**, therefore specifying `ASF_CRYPTKEY` environment variable.

`/etc/asf` složka (v případě, že neexistuje), `mkdir -p /etc/asf`. Doporučujeme `chown -hR root:root /etc/asf && chmod 700 /etc/asf` , aby se zajistilo, že k přečtení těchto souborů má přístup pouze `root` , protože mohou obsahovat citlivé vlastnosti, jako je `ASF_CRYPTKEY` Poté napište do `/etc/asf/<user>` souboru kde `<user>` je uživatel, který službu provozuješ (`asf` v našem příkladu výše, a `/etc/asf/asf`).

Soubor by měl obsahovat všechny proměnné prostředí, které chcete v procesu poskytnout. Ty, které nemají specifickou proměnnou prostředí, lze uvést v `ASF_ARGS`:

```sh
# Declare only ty, které skutečně potřebujete
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_crypt"
ASF_NETWORK_GROUP="my_network_group"

# A všechny ostatní, které máte zájem
```

### Přepínání části výkonové jednotky

Díky pružnosti `systemd`, je možné přepsat část ASF jednotky při zachování původního souboru jednotky a umožnit ASF aktualizaci například jako součást automatických aktualizací.

V tomto příkladu bychom rádi upravili výchozí chování jednotek ASF `systemd` z restartu pouze při úspěchu, abychom restartovali i při smrtelných haváriích. Za tímto účelem Přepíšeme `Restartovat` vlastnost pod `[Service]` od výchozího `úspěchu` do `vždy`. Jednoduše spustit `systemctl upravit ArchiSteamFarm@asf`, přirozeně nahradit `asf` cílovým uživatelem vaší služby. Poté přidejte své změny, jak ukazuje `systemd` ve správné sekci:

```sh
### Úprava /etc/systemd/system/ArchiSteamFarm@asf.service.d/override. onf
### Cokoli mezi sem a komentářem níže se stane novým obsahem souboru

[Service]
Restart=vždy

### Řádky pod tímto komentářem budou vypuštěny

### /etc/systemd/system/ArchiSteamFarm@asf. ervice
# [Install]
# WantedBy=multi-user. arget
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm. ll --no-restart --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# User=%i
# (...)
```

A to je to, nyní tvá jednotka jedná stejně, jako kdyby měla pouze `Restart=vždy` pod `[Service]`.

Alternativou je samozřejmě `cp` soubor a sám ho spravuj, ale umožňuje vám flexibilní změny, i když jste se rozhodli zachovat původní jednotku ASF, například s **[symlink](https://wikipedia.org/wiki/Symbolic_link)**.

---

## Nikdy nespusťte ASF jako správce!

ASF obsahuje vlastní ověření, zda je proces spuštěn jako administrátor (`root`) nebo ne. Running as `root` is **not** required for any kind of operation done by the ASF process, assuming properly configured environment it's operating in, and therefore should be regarded as a **bad practice**. This means that on Windows, ASF should **never** be executed with "run as administrator" setting, and on Unix ASF should have a **dedicated user account** for itself, or re-use your own in case of a desktop system.

Pro další rozpracování *proč* odradíme od používání ASF jako `root`. odkazujte na **[superuživatele](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** a další zdroje. Pokud stále nejste přesvědčeni, Ptejte se sami sebe, co by se stalo s vaším zařízením, když proces ASF provedl příkaz `rm -rf /*` ihned po jeho spuštění.

### Spustil jsem `root` , protože ASF nemůže zapisovat do svých souborů

To znamená, že máte nesprávně nakonfigurovaná oprávnění souborů ASF se snaží přistupovat. Měli byste se přihlásit jako `root` účet (buď s `su` nebo `sudo -i`) a pak **opravit** oprávnění vydáním příkazu `chown -hR asf:asf /path/to/ASF` nahrazuji `asf:asf` uživatelem, se kterým budete pracovat s ASF, a `/path/to/ASF`. Pokud libovolnou šancí použijete vlastní `--path` řekni uživateli ASF použít jiný adresář, měli byste znovu provést stejný příkaz i pro tuto cestu.

Poté byste již neměli dostávat žádný druh problému ohledně ASF, který by nebyl schopen psát přes své vlastní soubory, protože jste právě změnili vlastníka všeho, co se aplikace ASF zajímá o uživatele, proces ASF ve skutečnosti běží.

### Spusím jako `root` , protože nevím, jak to udělat jinak

```sh
su # Nebo sudo -i, pro vstup do root shell
useradd -m asf # Vytvořit účet, který hodláte spustit ASF pod
chown -hR asf:asf /path/to/ASF # Ujistěte se, že váš nový uživatel má přístup do adresáře ASF
su asf -c /path/to/ASF/ArchiSteamFarm # Or sudo -u asf /path/to/ASF/ArchiSteamFarm, pro spuštění programu pod vaším uživatelem
```

To by dělalo ručně, je mnohem snazší používat naši službu **[`systemd`](#systemd-service-for-linux)** vysvětlenou výše.

### Vím lépe a stále chci běžet jako `root`

ASF vás v tom důrazně nezabrání, pouze zobrazuje varování s krátkým upozorněním. Nebuďte šokováni, když jeden den kvůli chybě v programu vyhodí celý operační systém s úplnou ztrátou dat - byl jste varován.

---

## Více instancí

ASF je kompatibilní s provozem více instancí procesu na stejném stroji. Příklady mohou být zcela samostatné nebo odvozeny ze stejného binárního umístění (v tom případě) chcete je spustit s jiným `--path` **[argumentem](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**).

Při běhu více instancí ze stejného binárního souboru, mějte na paměti, že byste obvykle měli vypnout automatické aktualizace ve všech konfiguracích, protože mezi nimi neexistuje žádná synchronizace, pokud jde o automatické aktualizace. Pokud chcete mít zapnutou automatickou aktualizaci, doporučujeme samostatné instance. ale aktualizace můžete fungovat, pokud zajistíte, že všechny ostatní instance ASF budou uzavřeny.

ASF udělá vše pro to, aby udržela minimální míru komunikace přes OS, a to mezi procesy s ostatními případy ASF. To zahrnuje kontrolu konfiguračního adresáře ASF proti jiným instancím, stejně jako sdílení omezovačů jádra celého procesu nakonfigurovaných s `*LimiterDelay` **[vlastnostmi globálního nastavení](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, zajištění, že provoz více případů ASF nezpůsobí možnost proniknout do problému omezujícího míru rychlosti. Pokud jde o technické aspekty, všechny platformy používají náš vyhrazený mechanismus zámků souborů s vlastním ASF vytvořených v dočasném adresáři, což je `C:\Users\<YourUser>\AppData\Local\Temp\ASF` na Windows, a `/tmp/ASF` na Unix.

Není vyžadováno pro spuštění instancí ASF sdílet stejné `*LimiterDelay` , mohou použít různé hodnoty, neboť každý ASF přidá vlastní nastavené zpoždění do doby vydání po získání zámku. Je-li nakonfigurovaný `*LimiterDelay` nastaven na `0`instance ASF zcela přeskočí čekání na daný zdroj, který je sdílen s jinými instancemi (které by potenciálně stále mohly udržovat sdílený zámek mezi sebou). Pokud je nastaveno na jinou hodnotu, ASF bude řádně synchronizovat s ostatními instancemi ASF a počkat na jejich směr, poté uvolněte zámek po nakonfigurovaném zpoždění, což umožní pokračování dalších instancí.

ASF bere při rozhodování o sdíleném rozsahu v úvahu nastavení `WebProxy` , což znamená, že dvě ASF instance používající různé konfigurace `WebProxy` nebudou sdílet své omezovače mezi sebou. Toto je implementováno, aby `WebProxy` nastavení mohla fungovat bez nadměrných zpoždění, jak se očekává z různých síťových rozhraní. Toto by mělo být dostatečně dobré pro většinu případů používání, ale pokud máte konkrétní vlastní nastavení, ve kterém jste např. požadavky na směrování se sami jiným způsobem, můžete specifikovat síťovou skupinu pomocí `--network-group` **[parametru](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**, která vám umožní vyhlásit skupinu ASF, která bude synchronizována s touto instancí. Mějte na paměti, že vlastní síťové skupiny jsou využívány výhradně což znamená, že ASF již nebude používat `WebProxy` pro určení správné skupiny, jak jste v tomto případě zodpovědní za seskupování.

Pokud chcete použít naši službu **[`systemd`](#systemd-service-for-linux)** pro více instancí ASF, je to velmi jednoduché, stačí použít jiného uživatele pro naše servisní deklarace `ArchiSteamFarm@` a sledovat zbývající kroky. Bude to ekvivalent používání více instancí ASF s odlišnými binárními soubory, takže mohou také automaticky aktualizovat a fungovat nezávisle na sobě.