# Argumenty příkazového řádku

ASF obsahuje podporu pro několik argumentů příkazové řádky, které mohou ovlivnit běh programu. Ty mohou být použity pokročilými uživateli pro upřesnění způsobu běhu programu. Ve srovnání s výchozím způsobem konfigurace `ASF.json` se argumenty příkazové řádky používají pro inicializaci jádra (např. `--path`), nastavení specifické na platformě (např. `--system-required`) nebo citlivá data (např. `--cryptkey`).

---

## Použití

Použití závisí na vaší preferenci OS a ASF.

Obecné:

```shell
dotnet ArchiSteamFarm.dll --argument --otherOne
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --otherOne
```

Argumenty příkazového řádku jsou také podporovány v generických pomocných skriptech, jako je `ArchiSteamFarm.cmd` nebo `ArchiSteamFarm.sh`. Kromě toho můžete, při použití pomocných skriptů, také použít `ASF_ARGS` vlastnost prostředí, jak je uvedeno v našich **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** a **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** sekcích.

Pokud váš argument obsahuje mezery, nezapomeňte jej ocitovat. Tyto dvě věci jsou špatně:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Špatně!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Špatně!
```

Nicméně, dvě jsou zcela v pořádku:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Parametry

`--cryptkey <key>` nebo `--cryptkey=<key>` - spustí ASF s vlastním kryptografickým klíčem s hodnotou `<key>`. Tato volba ovlivní **[bezpečnost](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** a způsobí, že ASF bude používat vlastní zadaný klíč `<key>`, namísto výchozího klíče, který je pevně nakódováný v programu. Protože tato vlastnost ovlivňuje výchozí šifrovací klíč (pro účely šifrování) i "sůl" (pro účely hashování), mějte na paměti, že vše, co je šifrováno/hashováno tímto klíčem, bude vyžadovat jeho předání při každém spuštění ASF.

Na délku nebo počet znaků `<key>` nejsou kladeny žádné požadavky, ale z bezpečnostních důvodů doporučujeme zvolit dostatečně dlouhou heslovou frázi složenou např. z náhodných 32 znaků, např. pomocí příkazu `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` v systému Linux.

Je dobré zmínit, že existují také dva další způsoby, jak tento detail poskytnout: `--cryptkey-file` a `--input-cryptkey`.

Vzhledem k povaze této vlastnosti je také možné nastavit cryptkey deklarací proměnné prostředí `ASF_CRYPTKEY`, což může být vhodnější pro ty, kteří se chtějí vyhnout citlivým údajům v argumentech procesu.

---

`--cryptkey-file <path>` nebo `--cryptkey-file=<path>` - spustí ASF s vlastním kryptografickým klíčem načteným ze souboru `<path>`. Slouží ke stejnému účelu jako `--cryptkey <key>` vysvětlený výše, liší se pouze mechanismem, protože tato vlastnost bude místo toho číst `<key>` z poskytnutého `<path>`. Použiváte-li toto společně s `--path`, zvažte skutečnost, že relativní cesta bude různá v závislosti na pořadí argumentů, například pokud vložíte `--path` před nebo až za `--cryptkey-file`.

Vzhledem k povaze této vlastnosti je také možné nastavit soubor šifrovacího klíče deklarací proměnné prostředí `ASF_CRYPTKEY_FILE`, což může být vhodnější pro ty, kteří se chtějí vyhnout citlivým údajům v argumentech procesu.

---

`--ignore-unsupported-environment` - způsobí, že ASF bude ignorovat problémy spojené se spuštěním v nepodporovaném prostředí, což je obvykle signalizováno chybou a vynuceným ukončením. Mezi nepodporovaná prostředí patří například spuštění `win-x64` buildu na `linux-x64`. Tento příznak sice umožní, aby se ASF pokusil o spuštění v takových situacích, ale upozorňujeme, že tyto případy oficiálně nepodporujeme a nutíte k tomu ASF zcela **na vlastní riziko**. Je důležité zdůraznit, že **všechny** z nepodporovaných scénářů prostředí **lze opravit**. Rozhodně doporučujeme raději opravit nevyřešené problémy namísto nastavování tohoto argumentu.

---

`--input-cryptkey` - způsobí, že se ASF při spuštění zeptá na `--cryptkey`. Tato možnost by pro vás mohla být užitečná, pokud byste místo zadávání šifrovacího klíče, ať už v proměnných prostředí nebo v souboru, raději neměli šifrovací klíč nikde uložený a místo toho jej zadávali ručně při každém spuštění ASF.

---

`--minimized` - způsobí, že se okno konzole ASF krátce po spuštění minimalizuje. Toto chování je užitečné hlavně v případě automatického spuštění, ale lze je použít i mimo ně. Tento příznak vyžaduje adekvátní prostředí - nemusí správně fungovat ve všech možných případech.

---

`--network-group <group>` nebo `--network-group=<group>` - způsobí, že ASF inicializuje své omezovače s vlastní síťovou skupinou o hodnotě `<group>`. Tato možnost ovlivňuje běh ASF ve **[více instancích](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** tím, že signalizuje, že daná instance je závislá pouze na sdílené síťové skupině, a nezávislá na ostatních. Obvykle chcete tuto vlastnost použít pouze v případě, že směrujete požadavky ASF prostřednictvím vlastního mechanismu (např. různé IP adresy) a chcete sami nastavit síťové skupiny, aniž byste se spoléhali na to, že to ASF udělá automaticky (což v současné době zahrnuje pouze zohlednění `WebProxy`). Mějte na paměti, že při použití vlastní síťové skupiny se jedná o jedinečný identifikátor v rámci místního počítače a ASF nebude brát v úvahu žádné další údaje, jako je hodnota `WebProxy`, což vám umožní např. spustit dvě instance s různými hodnotami `WebProxy`, které jsou na sobě stále závislé.

Vzhledem k povaze této vlastnosti je možné hodnotu nastavit také deklarací proměnné prostředí `ASF_NETWORK_GROUP`, což může být vhodnější pro ty, kteří se chtějí vyhnout citlivým údajům v argumentech procesu.

---

`--no-config-migrate` - ve výchozím nastavení ASF automaticky převede konfigurační soubory na nejnovější syntaxi. Migrace zahrnuje převod zastaralých vlastností na poslední, odstranění vlastností s výchozími hodnotami (protože nemají žádný účinek), stejně jako obecné čištění souboru (opravování odsazení a podobně). Toto je téměř vždy dobrý nápad, ale možná máte konkrétní situaci, kdy byste raději ASF nikdy nepřepsat konfigurační soubory automaticky. Například možná budete chtít `chmod 400` vaše konfigurační soubory (pouze pro čtení) nebo je vložte `chattr +i` nad nimi, v důsledku odepření přístupu k zápisu pro všechny, e. . jako bezpečnostní opatření. Obvykle doporučujeme zachovat migraci konfigurace, ale máte-li zvláštní důvod pro jeho vypnutí a raději byste dávali přednost tomu, aby to ASF neudělala, můžete použít tento přepínač k dosažení tohoto cíle. Mějte však na paměti, že poskytnutí správného nastavení ASF se od nynějška stane na vaši novou odpovědnost. zejména pokud jde o deprese a změny vlastností v budoucích verzích ASF.

---

`--no-config-watch` - ve výchozím nastavení ASF nastaví `FileSystemWatcher` ve vašem `konfiguračním adresáři` , abyste mohli poslouchat události související se změnami souborů, aby se jim mohl interaktivně přizpůsobit. To například zahrnuje zastavení botů při mazání konfigurace, restartování bota při změně konfigurace, nebo načítám klíče do **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** , jakmile je přetáhnete do `adresáře s konfigurací`. Tento přepínač vám umožňuje zakázat takové chování, které způsobí, že ASF zcela ignoruje všechny změny v adresáři `config` , od vás vyžadují, aby tato opatření byla prováděna ručně, pokud je to považováno za vhodné (což obvykle znamená restartování procesu). Doporučujeme zachovat povolenou konfigurační událost, ale máte-li zvláštní důvod k jejich vypnutí a místo toho byste dávali přednost tomu, aby to ASF neudělala, můžete použít tento přepínač k dosažení tohoto cíle.

---

`--no-restart` - ve výchozím nastavení ASF následuje **[`Automatický restart`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#autorestart)** který můžete použít pro určení, zda je v případě potřeby povolen restart. Některá řešení, která zajišťujeme řízení procesu a která jsou explicitně neslučitelná s funkcí automatického restartování ASF, jako je běh ASF v `docker` nebo `systemd`, pokud je to považováno za vhodné, vyžaduje pouze proces ukončit, protože je jejich povinností jej znovu spustit. Protože svévolná úprava konfigurace je z uživatelského zážitku nechtěná, tento přepínač jednoduše přepne vaši `AutoRestart` konfigurační vlastnost tím, že ji explicitně inicializuje na `false`, i když jste v konfiguraci zadali jinak. Díky tomu může být ASF předem informována o provozu v takovém prostředí, bez požadavku poskytovat kompatibilní `AutoRestart: false` config soubor.

Kromě výše uvedeného `--no-restart`v rozporu s `AutoRestart: false`, také vám zakáže používat `restart` nebo jinak spustit proces ASF pro restartování, protože přepínač výslovně uvádí, že není kompatibilní s takovým nastavením, zatímco vlastnost `AutoRestart` určuje pouze výchozí chování.

Normálně můžete (a měli) ovládat chování popsané v konfiguračním souboru, i když používáte ASF uvnitř vlastního skriptu nebo jiného podobného prostředí, můžete také využít tento přepínač, který zakáže aplikaci ASF po restartu sám.

---

`--no-steam-rodičovská generace` - ve výchozím nastavení se ASF automaticky pokusí vygenerovat PINy rodičů Steam, jak je popsáno v konfiguraci **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)**. Avšak protože to může vyžadovat nadměrné množství zdrojů OS umožňuje tento přepínač vypnout toto chování, což povede k přeskočení automatického generování ASF a přejít přímo na požadavek uživatele na PIN, které by se normálně stalo, pouze pokud by automatická generace selhala. Obvykle doporučujeme ponechat generaci povolenou, ale máte-li zvláštní důvod pro jeho vypnutí a raději byste dávali přednost tomu, aby to ASF neudělala, můžete použít tento přepínač k dosažení tohoto cíle.

---

`--path <path>` nebo `--path=<path>` - ASF při spuštění vždy naviguje do svého vlastního adresáře. Určením tohoto argumentu se ASF po inicializaci naviguje do zadaného adresáře, který vám umožňuje použít vlastní cestu pro různé části aplikace (včetně `konfigurace`, `logy`, `pluginy` a `www` adresáře a `NLog. onfig` soubor), aniž by bylo nutné duplikovat binární soubor na stejném místě. Může to být užitečné, pokud chcete oddělit binární soubor od aktuální konfigurace, jak se to děje v baleních podobných Linuxu - tímto způsobem můžete použít jeden (aktuální) binární soubor s několika různými nastaveními. Cesta může být buď relativní podle aktuálního místa binární aplikace ASF, nebo absolutní. Mějte na paměti, že tento příkaz ukazuje na nové "ASF domů" - adresář, který má stejnou strukturu jako původní ASF, s `konfiguračním adresářem` , viz příklad vysvětlení.

Vzhledem k povaze této vlastnosti je také možné nastavit očekávanou cestu vyhlášením proměnné prostředí `ASF_PATH` , které může být vhodnější pro lidi, kteří by se chtěli vyhnout citlivým podrobnostem v procesních argumentech.

Pokud uvažujete o použití tohoto argumentu příkazové řádky pro spuštění více instancí ASF, Doporučujeme si tímto způsobem přečíst stránku **[managementu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)**.

Příklady:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Absolute path
dotnet /opt/ASF/ArchiSteamFarm.dll --path .. Cílový adresář # Relativní cesta funguje stejně jako
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # Stejné jako env proměnná
```

```text
<unk> <unk> <unk> <unk> 📁 /opt
<unk> <unk> : file_folder: ASF
<unk> <unk> <unk> ý: : ArchiSteamFarm.dll
<unk> <unk> <unk> (<unk> <unk> <unk> ) ý...
<unk> <unk> (📁 TargetDirectory
<unk> (<unk> <unk> ) : file_folder: config
<unk> <unk> (<unk> ) : 📁 logy (generované)
<unk> <unk> (<unk> : 📁 pluginy (pluginy (volitelné)
<unk> : file_folder: www (volitelné)
<unk> (volitelné) 📄 log. xt (vygenerováno)
<unk> <unk> (<unk> ) : page_facing_up: NLog.config (volitelný)
<unk> <unk> (<unk> <unk> <unk> (<unk> ) ...
```

---

`--service` - this switch is mainly used by our `systemd` service and forces `Headless` of `true`. Unless you have a particular need, you should instead configure `Headless` property directly in your config. Tento přepínač je zde, takže naše služba `systemd` nebude muset kontaktovat vaši globální konfiguraci, aby byla přizpůsobena svému vlastnímu prostředí. Samozřejmě, pokud máte podobnou potřebu, můžete také použít tento přepínač (jinak jste lepší s globálním nastavením).

---

`--system-required` - vyhlášení tohoto přepínače způsobí, že ASF zkusí signalizovat operační systém, že proces vyžaduje spuštění systému po celou dobu jeho životnosti. To se může ukázat jako zvláště užitečné při farmení na vašem počítači nebo notebooku v noci, protože ASF bude schopen udržet váš systém v režimu spánku. Tato funkce je v současné době podporována na Linuxu a Windows.

Na Linuxu budete muset správně pracovat na funkci **[dbus](https://en.wikipedia.org/wiki/D-Bus)** , která podporuje funkci **[`Inhibit()`](https://systemd.io/INHIBITOR_LOCKS/)**. Dvě nejpopulárnější daemony, `systemd` a `elogind`jsou potvrzeny pro podporu. Většina desktopových prostředí (jako například Gnome nebo KDE) by měla fungovat mimo krabici, vzhledem k tomu, že již tyto funkce závisejí na jejich vlastních potřebách.

Žádné zvláštní požadavky na systém Windows, měl by se rozpracovat z rámečku.