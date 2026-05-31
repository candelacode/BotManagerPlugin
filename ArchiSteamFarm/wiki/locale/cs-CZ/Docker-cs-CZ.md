# Docker

ASF je k dispozici jako **[dokovací kontejner](https://www.docker.com/what-container)**. Naše docker balíčky jsou v současné době k dispozici na **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** a **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

Je důležité poznamenat, že běh ASF v kontejneru Docker je považován za **pokročilé nastavení**, který **pro velkou většinu uživatelů nepotřebuje** a obvykle **neposkytuje žádné výhody** před nastavením bez kontejneru. Pokud uvažujete o Dockeru jako o řešení pro spuštění ASF jako služby, například automatickým spuštěním OS, pak byste měli místo toho uvažovat o čtení sekce **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** a nastavit správnou službu `systemd` , která bude **téměř vždy** lepší nápad než běh ASF v kontejneru Docker.

Spuštění ASF v kontejneru Docker obvykle zahrnuje **několik nových problémů a problémů** , kterým budete muset čelit a vyřešit se. Proto vám **důrazně** doporučujeme, abyste se jí vyhnuli, pokud již nemáte znalosti Dockeru a nepotřebujete pomoci porozumět jeho interním, o které zde nebudeme podrobně rozebírat ASF wiki. Tato část je většinou pro platné případy použití velmi složitých nastavení. například pokud jde o pokročilé vytváření sítí nebo zabezpečení nad rámec standardního pískovacího boxu, se kterým ASF přichází ve službě `systemd` (která již zajišťuje lepší izolaci procesu izolace prostřednictvím velmi pokročilých bezpečnostních mechanismů). Pro tyto hrstky lidí zde vysvětlujeme lepší koncepty ASF, pokud jde o její kompatibilitu s Dockerem, a pouze to, předpokládáme, že máte odpovídající dokovací znalosti sami, pokud se rozhodnete použít ho společně s ASF.

---

## Tagy

ASF je k dispozici prostřednictvím několika typů **[tagů](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `hlavní`

Všeobecné sestavení ASF, které je postaveno z nejnovějšího commitu v `hlavní` větvi, která funguje stejně jako uchopení nejnovějšího artefaktu přímo z našeho ropovodu **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)**. Je to nejvyšší úroveň chybového softwaru věnovaného vývojářům a pokročilým uživatelům pro účely vývoje. Obrázek je aktualizován s každým commitem v `hlavní` pobočce GitHub, takže můžete očekávat velmi často změny (a věci jsou rozbité). Je zde k označení aktuálního stavu projektu ASF, která nemusí být nutně stabilní nebo testovaná, jak je uvedeno v našem vývojovém cyklu. **Tato značka by neměla být použita v žádném produkčním prostředí**. Užitečné pro ověření, zda konkrétní commit opravil problém, se kterým se setkáváte, aniž byste čekali i na předběžné vydání s tímto závazkem.


### `uvolněno`

Obecná verze ASF, která vždy ukazuje na nejnovější verzi **[](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF, včetně předverzí. Ve srovnání s `hlavním` se obrázek zde aktualizuje pokaždé, když je nahrán nový GitHub. Specializováno pro pokročilé/výkonné uživatele, kteří milují žít na okraji toho, co lze považovat za stabilní a čerstvé současně. V praxi to funguje stejně jako valivá značka ukazující na poslední vydání `A.B.C.D` v době natažení. Vezměte prosím na vědomí, že používání tohoto tagu je rovno používání našeho **[předrelease](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `stabilní verze`

Obecné sestavení ASF, které vždy ukazuje na nejnovější **[stabilní](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF verzi. Ve srovnání s `uvolněným` tagem se obrázek zde aktualizuje, jakmile bude k dispozici nová stabilní verze ASF. Doporučeno pro lidi, kteří hledají stabilní variantu `uvolněné` značky uvedené výše.

### `poslední`

OS-specifická verze ASF, která vždy ukazuje na nejnovější verzi **[stabilní](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. Ve srovnání s ostatními je to **pouze značka** , která zahrnuje ASF automatické aktualizace. Cílem tohoto tagu je poskytnout zdravý výchozí kontejner Dockeru, který je schopen spustit samoaktualizaci, verzi ASF specifickou pro operační systém. Z tohoto důvodu nemusí být obrázek aktualizován co nejčastěji, verze ASF bude vždy schopna se v případě potřeby aktualizovat.

Samozřejmě `UpdatePeriod` lze bezpečně vypnout (nastaveno na `0`), ale v tomto případě byste pravděpodobně měli místo toho použít `stabilní verzi`. Obdobně můžete změnit výchozí `UpdateChannel` , abyste místo toho mohli sledovat předvydání.

Kvůli skutečnosti, že `poslední` obrázek je schopen automatické aktualizace, obsahuje bare OS s verzí `linux` ASF, na rozdíl od všech ostatních štítků, které obsahují OS s . ET runtime a `generická verze` ASF. Je to proto, že novější (aktualizovaná) verze ASF může také vyžadovat novější běh, než s jakou by mohl být obrázek vytvořen, které by jinak vyžadovaly přestavbu obrazu od nuly, čímž by se zrušil plánovaný případ použití.

### `A.C.C.D.`

Obecné sestavení ASF, které ukazuje na fixní verzi ASF odpovídající značce. Ve srovnání s výše uvedenými štítky je tento štítek zcela zmražený, což znamená, že obrázek zde nebude po zveřejnění aktualizován. To funguje podobně jako naše GitHub verze, které se nikdy nedotknou po prvotním vydání, což vám zaručuje stabilní a zmrazené prostředí. Obvykle byste měli používat tento štítek, když chcete použít konkrétní verzi ASF a očekávat deterministický výsledek sestavení (např. . namísto toho spravujte aplikaci ASF verze.

---

## Která značka je pro mě nejlepší?

To závisí na tom, co hledáte. Pro většinu uživatelů by štítek `nejnovější` měl být ten nejlepší, protože nabízí přesně to, co dělá desktop ASF, pouze ve speciálním kontejneru Docker jako služba. To však nemusí být nutně způsob, jak by měl být používán docker - normálně se očekává, že budete znovu stavět vaše kontejnery a nespustit je navždy, a v tomto případě byste měli zvážit `stabilní` nebo `uvolněné` , které se řídí pokyny dokování. Pokud chcete místo toho spustit nějakou fixní verzi ASF, pak přirozeně `A.B.C.D` jsou to, co hledáte.

Obecně odrazujeme od pokusů o `hlavní` sestavení, protože ty jsou zde, abychom označili aktuální stav ASF projektu. Nic nezaručuje, že takový stát bude fungovat správně, ale samozřejmě jste více než vítáni, abyste je vyzkoumali, jestli máte zájem o vývoj ASF.

---

## Architektura

Obrázek ASF docker je v současné době postaven na platformě `linux` zaměřené na 3 architektury - `x64`. `ruka` a `arm64`. Více o nich si můžete přečíst v sekci **[kompatibilita](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**.

Naše značky používají multiplatformní manifest, což znamená, že Docker nainstalovaný na vašem počítači automaticky vybere správný obrázek pro vaši platformu při natažení obrázku. Pokud chcete libovolnou šancí natáhnout konkrétní obrázek platformy, který neodpovídá tomu, co právě běžíte, to můžete provést pomocí `--platforma` přepnout odpovídající docker příkazy, jako je `docker spustit`. Pro více informací viz dokovací dokumentaci na **[obrazovém manifestu](https://docs.docker.com/registry/spec/manifest-v2-2)**.

---

## Použití

Pro úplný odkaz byste měli použít **[oficiální docker dokumentaci](https://docs.docker.com/engine/reference/commandline/docker)**, pokryjeme pouze základní použití v této příručce, jste více než vítejte na kopání.

### Hello ASF!

Za prvé, měli bychom ověřit, zda náš dok funguje i správně, to bude sloužit jako naše ASF "ahoj světa":

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm
```

`docker běží` vytvoří pro vás novou schránku ASF docker a spustí ji v popředí (`-it`). `--pull vždy` zajistí, že aktuální obrázek bude nejprve tažen, a `--rm` zajistí, že náš kontejner bude po zastavení vyčištěn, protože otestujeme, jestli vše bude v pořádku.

Pokud vše úspěšně skončilo, po vytažení všech vrstev a spuštění kontejneru, byste si měli všimnout, že ASF správně začala a informovala nás, že neexistují definovaní roboti, což je dobré - ověřili jsme, že ASF v docích funguje správně. Stiskněte `CTRL+C` pro ukončení procesu ASF, a tedy i kontejneru.

Pokud se podíváte blíže na příkaz, zjistíte, že jsme nedeklarovali žádný štítek, která automaticky výchozí `poslední` jedna. Pokud chcete použít jiný štítek než `nejnovější`, například `uvolněn`, pak byste to měli výslovně prohlásit:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm:release
```

---

## Použití hlasitosti

Používáte-li ASF v dokovacím kontejneru, pak je samozřejmě třeba konfigurovat samotný program. Můžete to udělat různými způsoby, ale doporučujeme vytvořit adresář ASF `config` na místním počítači, poté je namontována jako sdílený objem v kontejneru pro dokovací stanice ASF.

Například předpokládáme, že vaše složka s konfigurací ASF je v adresáři `/home/archi/ASF/config`. Tento adresář obsahuje jádro `ASF.json` stejně jako boty, které chceme spustit. Nyní stačí pouze připojit tento adresář jako sdílený objem v našem dokovacím kontejneru, kde ASF očekává svůj konfigurační adresář (`/app/config`).

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull vždy justarchi/archisteamfarm
```

A to je to, nyní váš kontejner pro dok ASF bude používat sdílený adresář s místním počítačem v režimu čtení, což je vše, co potřebujete pro konfiguraci ASF. Stejně tak můžete připojit další hlasitosti, které chcete sdílet s ASF, jako je `/app/logs` nebo `/app/plugins`.

To je samozřejmě jen jeden konkrétní způsob, jak dosáhnout toho, co chceme, nic vám nebrání například v tom, abyste vytvářím vlastní `Dockerfile` , který zkopíruje konfigurační soubory do `/app/config` adresáře uvnitř ASF docker kontejneru. V této příručce pokrýváme pouze základní použití.

### Oprávnění hlasitosti

ASF kontejner je ve výchozím nastavení inicializován s výchozím uživatelem `root` , který umožňuje zpracovat vnitřní oprávnění a poté přepnout na `asf` (UID `1000`) uživatele pro zbývající část hlavního procesu. I když by to mělo být uspokojivé pro velkou většinu uživatelů, má vliv na sdílený svazek, protože nově generované soubory budou normálně vlastněny `asf` , který nemusí být žádoucí, pokud chcete jiného uživatele pro svůj sdílený objem.

Existují dva způsoby, které můžete změnit uživatele ASF běží. První doporučeno, je deklarovat `ASF_UID` proměnnou prostředí s cílovým UID, pod kterou chcete běžet. Zadruhé, alternativou je předat `--user` **[vlajku](https://docs.docker.com/engine/reference/run/#user)**, která je přímo podporována dockerem.

Můžete zkontrolovat váš `uid` například příkazem `id -u` a pak jej prohlásit, jak je uvedeno výše. Například, pokud má váš cílový uživatel `uid` 1001:

```shell
docker run -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull vždy justarchi/archisteamfarm

# pokud rozumíte omezením uvedeným pod
spustit - to -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull vždy justarchi/archisteamfarm
```

Rozdíl mezi příznakem `ASF_UID` a `--user` je podřadný, ale důležitý. `ASF_UID` je vlastní mechanismus podporovaný ASF, v tomto scénáři docker kontejner stále začíná jako `root`. a poté ASF startovací skript spustí hlavní binární program pod `ASF_UID`. Používáte-li `--user` vlajku, spouštíte celý proces, včetně ASF spouštěcího skriptu jako daného uživatele. První možnost umožňuje ASF spouštěcí skript automaticky zpracovat oprávnění a další věci pro vás a vyřešit některé běžné problémy, které jste mohli způsobit, například zajišťuje, že vaše adresáře `/app` a `/asf` jsou ve skutečnosti ve vlastnictví `ASF_UID`. Ve druhém scénáři, protože nepoužíváme `root`to nemůžeme udělat a od vás čeká, že to vše zvládnete předem.

Pokud jste se rozhodli použít vlajku `--user` , musíte změnit vlastnictví všech ASF souborů z výchozího `1000` na nového vlastního uživatele. Můžete tak učinit provedením příkazu níže:

```shell
# Proveďte pouze pokud nepoužíváte ASF_UID
docker exec -u root asf_container_name chown -hR 1001 /app /asf
```

Toto musí být provedeno pouze jednou poté, co jste vytvořili kontejner s `docker spustil`, a pouze pokud jste se rozhodli použít vlastní uživatele přes `--user` vlajku docker. Také nezapomeňte změnit `1001` v příkazu výše na `UID` opravdu chcete spustit ASF pod.

### Hlasitost se SELinux

Pokud používáte SELinux ve vynuceném stavu na vašem OS, což je výchozí například na RHEL, pak byste měli připojit nabídku hlasitosti `:Z` , která nastaví správný kontext SELinuxu.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull vždy justarchi/archisteamfarm
```

To umožní ASF vytvářet soubory zaměřené na hlasitost uvnitř docker schránky.

---

## Synchronizace více instancí

ASF obsahuje podporu pro synchronizaci více instancí, jak je uvedeno v sekci **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)**. Pokud používáte ASF v docker kontejneru, můžete volitelně "opt-in" do procesu, v případě, že používáte více kontejnerů s ASF a chtěli byste je synchronizovat mezi sebou.

Ve výchozím nastavení je každá ASF běžící uvnitř dokovacího kontejneru samostatná, což znamená, že nedochází k žádné synchronizaci. Aby bylo možné mezi nimi synchronizovat, musíte navázat cestu `/tmp/ASF` v každém kontejneru ASF, který chcete synchronizovat, na jeden, sdílejte cestu na hostiteli dockeru v režimu čtení. Toho se dosahuje naprosto stejným způsobem jako svazující objem, který byl popsán výše, jen s různými cestami:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull vždy justarchi/archisteamfarm
# A tak dále, všechny kontejnery ASF jsou nyní synchronizovány mezi sebou
```

Doporučujeme navázat adresář `/tmp/ASF` na dočasný adresář `/tmp` ve vašem počítači, ale samozřejmě si můžete vybrat jiné, které vyhovuje vašemu využití. Každý kontejner ASF, u kterého se očekává, že bude synchronizován, by měl mít adresář `/tmp/ASF` sdílený s ostatními kontejnery, které se účastní stejného procesu synchronizace.

Jak jste pravděpodobně odhadli z příkladu výše, je také možné vytvořit dvě nebo více "synchronizačních skupin", spojením různých cest hostitele dockeru do `/tmp/ASF`.

Montáž `/tmp/ASF` je zcela nepovinná a opravdu nedoporučuje, pokud nechcete synchronizovat dva nebo více kontejnerů ASF. Nedoporučujeme montáž `/tmp/ASF` pro použití v jednom kontejneru, protože to nepřináší žádné výhody, pokud chcete spustit pouze jeden kontejner typu ASF, a ve skutečnosti by to mohlo způsobit problémy, kterým by se jinak dalo vyhnout.

---

## Argumenty příkazového řádku

ASF umožňuje procházet **[argumenty příkazové řádky](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** v dokovacím kontejneru pomocí proměnných prostředí. Pro zbytek byste měli použít specifické proměnné prostředí pro podporované přepínače a `ASF_ARGS`. Toho lze dosáhnout pomocí přepínače `-e` přidaného do `spouštění`, například:

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull vždy justarchi/archisteamfarm
```

To správně projde tvůj argument `--cryptkey` pro ASF proces běh uvnitř docker kontejneru a také pro další arge. Samozřejmě, pokud jste pokročilý uživatel, můžete také upravit `ENTRYPOINT` nebo přidat `CMD` a předat vlastní argumenty sami.

Pokud nechcete poskytnout vlastní šifrovací klíč nebo jiné pokročilé možnosti, obvykle nemusíte obsahovat žádné speciální proměnné prostředí, protože naše kontejnery na docích jsou již nakonfigurovány tak, aby běžely s očekávanou volbou `--no-restart`, aby označení nebylo třeba výslovně specifikovat v `ASF_ARGS`.

---

## IPC

Předpokládejme, že jste nezměnili výchozí hodnotu pro `IPC` **[globální konfigurační vlastnost](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, je již povolena. Nicméně musíte udělat dvě další věci, aby IPC fungoval v kontejneru Docker. Nejprve musíte použít `IPCPassword` nebo změnit výchozí `KnownNetworks` ve vlastním `IPC. onfig` pro umožnění připojení z vnějšku bez použití. Pokud opravdu nevíte, co děláte, použijte `IPCPassword`. Zadruhé musíte změnit výchozí adresu naslouchání `localhost`, protože dok nemůže směrovat mimo provoz do rozhraní se smyčkou. Příkladem nastavení, které poslouchá všechna rozhraní, je `http://*:1242`. Samozřejmě můžete také použít restriktivnější vazby, jako je místní síť LAN nebo síť VPN, ale musí to být cesta přístupná zvenku - `localhost` to neudělá, protože trasa je zcela v dosahu ubytovacího zařízení.

Pro výše uvedené byste měli použít **[vlastní IPC konfiguraci](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** , jako je níže uvedený IPC:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Jakmile nastavíme IPC na nesmyčkové rozhraní, musíme povšimnout doku pro mapování `1242/tcp` portu s `-P` nebo `-p`.

Tento příkaz by například vystavil ASF IPC rozhraní hostitelskému počítači (pouze):

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [:::1]:1242:1242 --name asf --pull always justarchi/archisteamfarm
```

Pokud nastavíte vše správně, `docker spustit` příkaz výše zajistí, aby **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** fungoval z vašeho hostitele rozhraní, na lince `localhost:1242` , která je nyní správně přesměrována na váš počítač pro hosty. Je také pěkné si povšimnout, že tuto trasu dále nevystavujeme, aby spojení bylo možné provádět pouze v rámci dokovacího hostitele, a proto je udržováno v bezpečí. Samozřejmě, že trasu můžete dále odhalit, pokud víte, co děláte, a zajistit vhodná bezpečnostní opatření.

---

### Kompletní příklad

Kombinace celých výše uvedených znalostí by vypadala takto:

```shell
docker run -p 127.0.0.1:1242:1242 -p [:::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull vždy --restart --unless-stopped justarchi/archisteamfarm
```

To předpokládá, že budete používat jeden ASF kontejner se všemi konfiguračními soubory ASF v `/home/archi/ASF/config`. Měli byste změnit cestu k konfiguraci tak, aby odpovídala vašemu počítači. Je také možné poskytnout vlastní pluginy pro ASF, které můžete vložit do `/home/archi/ASF/plugins`. Toto nastavení je také připraveno k volitelnému využití IPC, pokud jste se rozhodli zahrnout `IPC. onfig` ve vašem konfiguračním adresáři s obsahem, jako je níže:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Stejného efektu můžeš dosáhnout `docker run` pomocí následujícího `docker compose` config:

```yaml
verze: „3. "
služby:
  asf:
    image: justarchi/archisteamfarm
    container_name: asf
    restart: unless-stopped
    ports:
      - "127. .0.1:1242:1242"
      - "[::1]:1242:1242"
    svazky:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

z jiných věcí, než jsme již projednávali výše, přidali jsme `--restart unless-stop` k oběma příkladům výše, abychom mohli automaticky spustit tento kontejner po restartu vašeho počítače. Neváhejte ji odstranit/změnit tak, aby vyhovovala vašim potřebám.

---

## Pro tips

When you already have your ASF docker container ready, you don't have to use `docker run` every time. Můžete snadno zastavit/spustit kontejnery ASF docker s `docker zastavením` a `docker začne podle`. Mějte na paměti, že pokud nepoužíváte `poslední` značku, bude použití aktualizovaného ASF stále vyžadovat od vás na `docker stop` `docker rm` a `znovu spustí`. Je to proto, že při každém použití ASF verze, která je součástí obrázku, musíte svůj kontejner znovu sestavit z čerstvého obrázku ASF. Do `poslední` tagu zahrnula ASF schopnost automatické aktualizace sama, takže přestavba obrázku není nezbytná pro používání aktuálního ASF (ale je stále dobrý nápad, aby to čas od času udělal, aby mohl používat čerstvý . ET runtime závislosti a související OS, které mohou být potřeba při skákání přes hlavní aktualizace verze ASF).

Jak bylo uvedeno výše, ASF v jiné značce než `nejnovější` se nebude automaticky aktualizovat sám, což znamená, že **vy** máte za úkol používat aktuální `justarchi/archisteamfarm`. Toto má mnoho výhod, jak obvykle by se aplikace při spouštění neměla dotknout vlastního kódu, ale také chápeme pohodlí, které pochází z toho, že se nemusíte starat o verzi ASF ve vašem dokovacím kontejneru. Pokud vám záleží na správných postupech a řádném používání dokování, `uvolněno` je to, co navrhujeme místo `nejnovějšího`, ale pokud se vám to neobtěžuje a chcete, aby aplikace ASF fungovala a automaticky aktualizovala sama, pak `poslední` udělá.

Typicky byste měli spustit ASF v dokovacím kontejneru s `bezhlavé: true` globálním nastavením. To ASF jasně řekne, že zde nejste zde, abyste uvedli chybějící údaje, a nemělo by o ně žádat. Pro počáteční nastavení byste samozřejmě měli zvážit ponechání této volby na `false` , abyste mohli snadno nastavit věci, ale dlouhodobě nejste připojeni k ASF konzoli, má tedy smysl o tom informovat ASF a v případě potřeby použít `vstup` **[příkaz](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Tímto způsobem nebude muset ASF nekonečně čekat na vstup uživatelů, ke kterému nedojde (a při tom plýtvat zdroji). Umožní také aplikaci ASF běžet v neinteraktivním režimu uvnitř kontejneru, což je klíčové, např. pokud jde o předávací signály, umožňuje ASF gracionální uzavření na žádosti `docker zastavit, asf`.