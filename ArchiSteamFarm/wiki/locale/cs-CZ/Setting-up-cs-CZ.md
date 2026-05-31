# Nastavení

Pokud jste tu poprvé, vítejte! We're very happy to see yet another traveler that is interested in our project, although bear in mind that with great power comes great responsibility - ASF is capable of doing a lot of different Steam-related tasks, but only as long as you **care enough to learn how to use it**. čtení wiki, podle našich pokynů a více se naučí o různých konceptech ASF vás nakonec odmění jedinečnou dovedností používat jeden z nejúčinnějších Steam nástrojů, které jsou v současné době k dispozici.

Doporučujeme vám udělat **jednu věc v čase**. ASF se dotýká mnoha různých aspektů, z nichž některé jsou spíše triviální, jiné mohou být příliš složité. Nemusíte pochopit ani číst všechno najednou, a my vám opravdu doporučujeme, abyste to pochopili. Relax, vyberte si nápoj volby, věnujte hodinu vašeho času a ponořte se do naší přednášky - můžeme slíbit, že to bude mít dobrou cenu vašeho času.

Začněme od základů - aplikace ASF je konzole v principu, což znamená, že nebude automaticky vytvářet grafické rozhraní, na které jste obecně zvyklí. ASF je univerzální aplikace, která funguje hlavně jako služba (daemon), a ne jako desktopová aplikace. Jeden z jeho hlavních případů používání zvažuje běh na serverech, pro které jsou stolní aplikace zcela nevhodné. To však považuje pouze absolutní jádro programu, protože ASF ve skutečnosti **obsahuje** své vlastní grafické rozhraní - ve formě vestavěné frontendu ASF-ui, ale na tuto část se dostaneme včas - jen to zmiňujeme hned od sebe, takže nebudete panikařit, když uvidíte obrazovku černé konzole nebo něco jiného.

Jakmile získáte binární soubory aplikace ASF, program od vás bude vyžadovat konfiguraci, která specifikuje, co přesně očekáváte od aplikace ASF. Program můžete spustit bez konfigurace, v tomto případě se ASF spustí ve výchozím nastavení, což vám umožní použít. . ASF-ui pro počáteční konfiguraci, ale bez vaší předchozí akce to moc neudělá.

To se prozatím udělá, začněme!

---

## Nastavení specifické pro operační systém

Obecně je to, co uděláme v několika příštích minutách:
- Budeme nainstalovat **[.NET prerequisites](#net-prerequisites)**.
- Poté stáhneme **[poslední verzi ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** v příslušné variantě specifické pro OS.
- Dále rozbalíme archiv do nového umístění.
- Pak budeme **[nakonfigurovat ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- A konečně, spustíme ASF a uvidíme jeho kouzlo.

Některé kroky jsou samozřejmé, jiné od vás budou vyžadovat více pozornosti. Nebojte se, my jsme tě pokryli.

---

### Předpoklady

Prvním krokem je zajistit, aby váš OS mohl dokonce správně spustit ASF. Nepotřebujete to vědět, ale ASF je napsán v C#, na základě . ET platforma a může vyžadovat původní knihovny, které zatím nejsou dostupné na vaší platformě. Přemýšlejte o tom jako DirectX pro 3D hry nebo engine pro spouštění auta.

V závislosti na tom, zda používáte Windows, Linux nebo macOS, budete mít různé požadavky. Referenční dokument je **[. ET předpokladů](https://docs.microsoft.com/dotnet/core/install)**, ale z důvodu jednoduchosti jsme také podrobně popsali všechny potřebné balíčky níže, takže si ji nemusíte vůbec přečíst, pokud narazíte na problémy nebo nebudete mít další otázky.

Je naprosto běžné, že některé (nebo dokonce všechny) závislosti na vašem systému již existují kvůli instalaci pomocí softwaru třetích stran, který používáte. K tomu však nemusí docházet. , takže byste měli spustit vhodný instalační program pro váš OS - bez těchto závislostí se ASF vůbec nespustí. a sotva získáte nějaké užitečné informace, abyste vám řekli, co je špatně.

Mějte na paměti, že nemusíte dělat nic jiného pro konkrétní operační systémy, zejména pro instalaci . ET SDK nebo dokonce runtime, protože balíček specifický pro OS, již všechny obsahuje. Potřebujete pouze .NET předpoklady (závislosti) ke spuštění . ET runtime zahrnuto do ASF - takže pouze věci, které specifikujeme níže, bez jakýchkoli dalších dodatků.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** na 64 bitů, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** pro 32 bitové nebo **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** pro 64 bitových ARM)
- Je velmi doporučeno zajistit, aby všechny aktualizace systému Windows byly již nainstalovány. Pokud je nemáte povoleno, pak alespoň potřebujete **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** a **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**ale může být potřeba více aktualizací. Nemusíte se toho obávat, pokud jsou vaše Windows aktuální, nebo alespoň nové.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Názvy balíčků závisí na distribuci Linuxu, kterou používáte, jsme vyjmenovali ty nejčastější. Všechny z nich můžete získat s nativním manažerem balíčků pro váš OS (například `apt` pro Debian nebo `yum` pro CentOS). Jedná se o poměrně standardní knihovny, které by měly být k dispozici bez ohledu na to, jakou distribuci používáte, Je to jen otázka zjištění toho, jak jsou ve vašem prostředí volby.

- `ca-certifikáty` (standardní důvěryhodné SSL certifikáty pro připojení HTTPS)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, nejnovější verze pro vaši distribuci, například `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-libs`, nejnovější verze pro vaši distribuci, alespoň `1.1.X`)
- `libstdc++6` (`libstdc++`, ve verzi `5.0` nebo vyšší)
- `zlib1g` (`zlib`)

Alespoň většina z nich by měla být již ve vašem systému k dispozici. Například minimální instalace Debian stable obvykle vyžaduje pouze `libicu76`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- Nepotřebujete nic konkrétního, ale měli byste mít nainstalovanou nejnovější verzi macOS alespoň 12.0+

---

### Stahování

Protože již máme všechny požadované závislosti, dalším krokem je stahování **[nejnovější verze ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF je k dispozici v mnoha variantách, ale zajímáte se o balíčky, které odpovídají vašemu operačnímu systému a architektuře. Například pokud používáte `64`-bit `Win`dows, pak chcete `ASF-win-x64`. Další informace o dostupných variantách naleznete v sekci **[kompatibilita](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**. ASF je také schopen běžet v prostředí, pro které nevytváříme balíček specifický pro OS. jako **32-bit Windows**, ale k tomu budete potřebovat **[generické nastavení](#generic-setup)**.

![Aktiva](https://i.imgur.com/Ym2xPE5.png)

Po stažení začněte rozbalit zip soubor do vlastní složky. Pokud k tomu potřebujete konkrétní nástroj, **[7-zip](https://www.7-zip.org)** bude ale všechny standardní nástroje, jako je vestavěná extrakce z Windows nebo `unzip` z Linux/macOS by měly fungovat i bez problémů.

Doporučujeme rozbalit ASF do **svého vlastního adresáře** a ne do žádného existujícího adresáře, který již používáte pro něco jiného - to je důležité. ASF obsahuje funkci automatické aktualizace, která nahrazuje vlastní soubory a která obvykle smaže všechny staré i nesouvisející soubory při aktualizaci, což může vést k tomu, že ztratíte cokoliv, co s vámi nesouvisí, vložíte do adresáře ASF. Pokud máte nějaké další skripty nebo soubory, které chcete použít s ASF, není to problém, vytvořit specializovanou složku pro ty, můžete vždy vkládat ASF do jedné složky hlouběji.

Příklad struktury by mohl vypadat takto:

```text
C:\ASF (where you put your own things)
    ├── MyNotes.txt (optional)
    ├── AsfMakeMeCoffeeScript.bat (optional)
    ├── (...) (any other files of your choice, optional)
    └── Core (dedicated to ASF only, where you extract the archive)
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         ├── www
         └── (...)
```

---

### Konfigurace

Nyní jsme připraveni udělat poslední krok, konfiguraci. ASF pracuje s koncepcí "botů", každý bot je obvykle jeden Steam účet, který chcete použít uvnitř ASF. Můžete vyhlásit tolik botů, kolik chcete, ale pro začátek se zaměříme jen na jeden z nich - obvykle na váš hlavní účet. ASF má také nebot konfigurační soubory, nejdůležitější je globální konfigurační soubor, který má vliv na všechny boty v daném případě.

Obecným pravidlem je, že **pokud nevíte, nebo nechápou některá nastavení, byste ji měli ponechat s výchozí hodnotou, aniž byste měnili cokoliv**. ASF nabízí bezpočet způsobů, jak konfigurovat, přizpůsobit a vylepšit téměř všechny jeho funkce, ale jak je uvedeno výše. pokusit se to hned pochopit, je to králičí díra, která vás může rychle přetáhnout do vážného zmatku, pokud ne **[přímo do propasti](https://www.youtube.com/watch?v=KK3KXAECte4)**. Namísto toho doporučujeme mít nejprve pracovní příklad a teprve potom začneme házet do dalších možností, s pomocí **[konfigurace](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** na wiki, při změně **jedna věc v čase**.

Nastavení ASF lze provést několika způsoby - prostřednictvím našeho vestavěného rozhraní ASF-ui, samostatného generátoru webových konfigurací, nebo ručně. To je podrobně vysvětleno v sekci **[konfiguraci](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** , takže pokud chcete podrobnější informace. Jako výchozí bod použijeme samostatný web config generátor, protože to funguje, i když ASF-ui z nějakého důvodu selhal nebo nefunguje správně.

Přejděte na náš **[web config generátor](https://justarchinet.github.io/ASF-WebConfigGenerator)** se svým oblíbeným prohlížečem. Doporučujeme Chrome nebo Firefox, ale nemělo by to záležet tak dlouho, dokud váš prohlížeč funguje pro všechno ostatní.

Po otevření stránky přepnout na záložku "Bot". Nyní byste měli vidět stránku podobnou níže uvedené stránce:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Pokud je náhodou verze aplikace ASF, kterou jste právě stáhli, starší než jaká je nastavena jako výchozí verze konfiguračního generátoru, jednoduše vyberte verzi ASF z rozbalovacího menu. To se může (zřídka) stát, protože konfigurační generátor může být použit pro generování konfigurací na novější (pre-release) verze ASF, které ještě nebyly označeny jako stabilní. Stáhli jste si nejnovější stabilní verzi aplikace ASF, která je ověřena spolehlivým fungováním, takže může být o něco starší než verze absolutních hran, která není zcela vhodná pro první použití.

Začněte od **vkládat jméno svého bota** do pole zvýrazněného jako červené, s názvem `Name`. Toto může být libovolné jméno, které chcete použít, jako je přezdívka, název účtu, číslo nebo cokoli jiného. Existuje pouze jedno slovo, které nemůžete použít, `ASF`, protože toto klíčové slovo je vyhrazeno pro globální konfigurační soubor. Kromě toho jméno bota nemůže začínat tečkou (ASF tyto soubory úmyslně ignoruje). Doporučujeme také, abyste se vyhnuli používání mezer, můžete použít `_` jako oddělovač slov, pokud je to potřeba - ne přísný požadavek, ale jinak budete mít těžký čas používat příkazy ASF.

Rozhodl se název bota? Skvělé, v dalším kroku, **change `Povolit` přepínač aby byl zapnutý**, , který definuje, zda má být váš bot automaticky spuštěn ASF po spuštění programu. Nedělání způsobí, že aplikace ASF prohlásí, že váš bot je v konfiguračním souboru zakázán, a bude čekat na tvůj vstup, což není to, co chceme v tomto příkladu dělat.

Nyní jsou další dvě citlivé vlastnosti: `SteamLogin` a `SteamPassword`. Můžete učinit další rozhodnutí - buď můžete vložit své přihlašovací údaje na Steam do těchto dvou vlastností. nebo se můžete rozhodnout, že to neuděláte, nechejte je prázdné.

ASF vyžaduje vaše přihlašovací údaje, protože obsahuje vlastní implementaci Steam klienta a potřebuje stejné údaje pro přihlášení jako ten, který používáte. Vaše přihlašovací údaje nejsou ukládány nikde kromě vašeho PC v adresáři ASF `config` pouze (jakmile si stáhnete vygenerovanou konfiguraci). Naším webovým konfiguračním generátorem je aplikace založená na klientech, což znamená, že vše, co děláte na našem samostatném web config-generator webu, běží lokálně ve vašem prohlížeči, aby bylo možné generovat platné ASF konfigurace, bez podrobností, které vkládáte z vašeho počítače vůbec někdy, takže není třeba se obávat o případný únik citlivých dat. Přesto pokud nechcete z nějakého důvodu vložit Vaše přihlašovací údaje, chápeme, že a můžete je ručně vložit do generovaných souborů nebo je zcela vynechat a bez nich fungovat.

Pokud se rozhodnete vložit vaše přihlašovací údaje, ASF se bude moci automaticky přihlásit během spuštění, které spolu s volitelnými 2FA umožní pouze dvojkliknout na program a spustit vše. If you decide to omit them, then ASF will **ask you** to input those details when needed - that approach won't save them anywhere, but naturally ASF won't be able to operate without your help. Je na vás, jak dáváte přednost víc, a jako obvykle můžete najít další informace v **[konfiguraci](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.

Jako postranní poznámku můžete také rozhodnout, že ponecháte pouze jedno pole prázdné, například `SteamPassword`. ASF pak bude moci používat vaše přihlašovací údaje automaticky, ale v případě potřeby bude stále požadovat heslo (podobně jako Steam Client). Pokud s jakoukoli šancí používáte čtyřmístný rodičovský pin k odemknutí vašeho účtu, také doporučujeme vložit do `SteamParentalPin` , i když v tomto případě můžete nechat toto prázdné a místo toho si všímat, jak slabá je tato ochrana, protože ASF může také "prasknout" sám během pouhých sekund po přihlášení. Jejda.

Po sledování se vším výše, takže znovu **bota jméno**, **povoleno přepínač**, a **přihlašovací údaje** , vaše webová stránka bude nyní vypadat podobně jako níže:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Nyní můžete stisknout tlačítko "download" a náš web config generátor vygeneruje nový `json` soubor na základě vašeho zvoleného jména. Uložte tento soubor do adresáře `config` , který je umístěn ve složce, ve které jste v předchozím kroku extrahovali zip soubor.

Blahopřejeme! Právě jste dokončili základní konfiguraci bota ASF. K objevování toho je mnohem více, ale prozatím je to vše, co potřebujete.

---

### Spuštění ASF

Vím, že jsi na tuto chvíli čekal a nemůžeme tě držet déle, jak jste nyní připraveni spustit program poprvé. Jednoduše klikněte na `ArchiSteamFarm` v adresáři ASF. Můžete to také spustit z konzoly.

Teď by byl vhodný čas na revizi naší sekce **[vzdálená komunikace](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** , pokud máte obavy o věci, které je ASF naprogramována, zejména akce, které budou provedeny ve Vašem jménu, jako je například ve výchozím nastavení připojení k naší skupině Steam. Vybrané funkce můžete vždy později zakázat, pokud se vám nelíbí, ASF jednoduše přichází s citlivými výchozími hodnotami, a museli jsme učinit určité rozhodnutí o obecném použití, které platí pro většinu naší uživatelské základny, stejně jako náš vlastní pohled na program podle jeho principu.

Předpokládejme, že vše bylo v pořádku, což většinou zvažuje instalaci všech požadovaných závislostí v prvním kroku, a konfiguraci ASF ve třetí aplikaci by měla aplikace ASF spustit správně, objevit svého prvního bota a pokusit se přihlásit:

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF bude s největší pravděpodobností vyžadovat ještě jeden detail od vás - 2FA přístup k účtu (pokud jste zcela nevypnuli SteamGuard, pak ne). Jednoduše postupujte podle instrukcí na obrazovce, můžete zadat kód z autentizátoru/e-mailu nebo přijmout potvrzení v mobilní aplikaci.

Něco se pokazilo.

#### ASF nezačíná vůbec, žádné okno konzole

Buď Vám chybí .NET předpoklady, nebo jste si stáhli nesprávnou variantu ASF pro váš počítač. Pokud nevíte, co je špatné, podívejte se na náš **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** a zjistěte přesný problém, a pokud se stále zaseknete, kontaktujte naši **[podporu](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### Nejsou definováni žádní boti

Nevložili jste vygenerované nastavení do adresáře `configu`. Některé další běžné chyby v tomto kroku mohou zahrnovat manuální změnu rozšíření z `.json` např. na `. xt`a některé operační systémy (např. Windows) chtějí skrýt běžné přípony, takže se ujistěte, že váš soubor je na vhodném místě a také s odpovídajícím názvem.

#### Není spuštěn tento bot, protože je zakázán v konfiguračním souboru

Zapomněl jsi přeskočit `povolil přepínač` , který říká ASF automatickému spuštění bota. Pokud to samozřejmě nebylo vaším záměrem, ale pak byste již měli vědět, jak provádět příkazy, jednoduše `spusťte` svého bota po této zprávě.

#### `Neplatné heslo`

Vaše přihlašovací údaje jsou s největší pravděpodobností nesprávné. Zkontrolujte `SteamLogin` a `SteamPassword` ve vygenerovaném nastavení, pokud se mýlí, opravte je zpětným nastavením. Pokud stále máte problémy, zkuste použít stejné přihlašovací údaje ve svém vlastním Steam klientovi - měli byste se také přihlásit, a možná získáte více informací o tom, co je takto špatné.

#### Všechno dobré?

Po procházení počáteční přihlašovací branou se za předpokladu, že jsou vaše údaje správné, přihlásíte se, a ASF spustí zemědělství pomocí výchozího nastavení, kterého jste se nyní nedotkli:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

To dokazuje, že ASF nyní úspěšně vykonává svou práci na vašem účtu, takže nyní můžete minimalizovat program a udělat něco jiného. Jděte vpřed, zasloužil jste si to, možná doplňte nápoj podle vašeho výběru!

Zemědělské karty jsou předmětem dalšího zdlouhavého článku, jako je tento, ale v principu: po dostatečném čase (v závislosti na **[výkonu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), uvidíte, že jsou postupně upuštěny obchodní karty Steamu. Aby se tak stalo, musíte samozřejmě mít platné hry pro farma, ukazuji jako "můžete získat více karet z hraní této hry" na stránce **[odznaky](https://steamcommunity.com/my/badges)** - pokud neexistují žádné hry k farmě, pak ASF prohlásí, že nic nedělá, jak je uvedeno v naší **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, která odpovídá na nejběžnější otázky lidí v tuto chvíli, diví se, proč navzdory vlastnění čtrnácti her na jejich účtu ASF tvrdí, že není nic dělat - ne, to není chyba.

Tím končí naše základní příručka pro nastavení. Stejně jako v každé RPG hře jste dokončili výuku a my opouštíme celý ASF svět, který můžete prozkoumat. Například se nyní můžete rozhodnout, zda chcete aplikaci ASF dále nakonfigurovat nebo nechat vykonat svou práci ve výchozím nastavení. Pokud si chcete přečíst trochu více, zakrníme několik základních detailů a pak ponechte celou wiki pro objevování.

---

### Rozšířená konfigurace

#### Zemědělství několik účtů najednou

ASF podporuje zemědělství více než jednoho účtu v době, která je jeho hlavní funkcí. Další účty můžete přidat do aplikace ASF vytvořením dalších konfiguračních souborů bot, přesně stejným způsobem, jako jste před několika minutami vygenerovali svůj první. Musíte zajistit pouze dvě věci:

- Jedinečné jméno bota, pokud již máte svého prvního bota jménem `MainAccount`, nemůžete mít jiného se stejným jménem.
- Platné přihlašovací údaje, jako je `SteamLogin`, `SteamPassword` a `SteamParentalCode` (pokud jste se rozhodli je vyplnit)

Jinými slovy, stačí znovu přejít na konfiguraci a udělat přesně totéž, jen pro svůj druhý nebo třetí účet. Nezapomeňte použít jedinečná jména pro všechny své boty, abyste nepřepsali existující konfigurace.

---

#### Změna nastavení

V našem samostatném generátoru konfigurací webu změníte stávající nastavení přesně stejným způsobem - vytvořením nového konfiguračního souboru. Klikněte na "Přepnout pokročilá nastavení" a podívejte se, co tam můžete objevit. V tomto příkladu změníme `CustomGamePlayedWhileFarming` , které umožňuje nastavit vlastní název, který se zobrazuje při aplikaci ASF a místo zobrazení skutečné hry.

Podívejme se nejprve na to. Pokud spouštíte ASF a začnete farmovat, ve výchozím nastavení uvidíte, že váš Steam účet je ve hře:

![Pára](https://i.imgur.com/1VCDrGC.png)

To dává smysl, když aplikace ASF řekla platformě Steam, že hrajeme hru, potřebujeme od ní karty, že? Ale můžeme, to přizpůsobit! Přepněte rozšířené nastavení, pokud jste ještě neudělali, pak najděte `CustomGamePlayedWhileFarming`. Jednoduše vložte libovolný vlastní text, který tam chcete zobrazit, například "Idling cards":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Nyní stáhněte nový konfigurační soubor stejným způsobem, a pak **přepište** váš starý konfigurační soubor novým. Můžete také smazat svůj starý konfigurační soubor a samozřejmě umístit nový do jeho umístění.

ASF je poměrně chytrý a měla by si všimnout, že jste změnili konfiguraci, který by pak měl automaticky spustit a spustit bez restartu programu. Pokud se náhodou nestane, můžete jednoduše restartovat program, abyste zajistili, že bude vaše nová konfigurace vyzvednuta. Poté byste si měli všimnout, že ASF nyní zobrazuje váš vlastní text na předchozím místě:

![Pára 2](https://i.imgur.com/vZg0G8P.png)

Toto potvrzuje, že jste úspěšně upravili konfiguraci. Přesně stejným způsobem můžete změnit globální vlastnosti ASF přepnutím z karty bota na kartu "ASF", stažením generovaného `ASF. son` konfigurační soubor a vložení do vašeho `konfiguračního adresáře`.

Úprava nastavení ASF může být mnohem snazší pomocí našeho rozhraní ASF-ui, což bude dále vysvětleno níže.

---

#### Použití ASF-ui

Jak jsme již zmínili, aplikace ASF je konzole a ve výchozím nastavení nespustí grafické uživatelské rozhraní. Aktivně však pracujeme na **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** frontend k našemu IPC rozhraní, což může být velmi slušný a uživatelsky přívětivý způsob, jak přistupovat k různým funkcím ASF.

Abyste mohli používat ASF-ui, musíte mít zapnutou `IPC` , která je výchozí volbou, takže pokud ji ručně nedeaktivujete, je již aktivní. Po spuštění aplikace ASF byste měli být schopni potvrdit, že toto rozhraní automaticky spustilo:

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC ve skoku, je vestavěný webový server ASF, který začíná lokálně na vašem počítači, umožňuje komunikovat s ním pomocí Vašeho oblíbeného webového prohlížeče. Za předpokladu, že to začalo správně, můžete přistupovat k IPC rozhraní ASF kliknutím na **[tento](http://localhost:1242)** pokud běží ASF, ze stejného stroje. Můžete použít ASF-ui pro různé účely, např. upravování konfiguračních souborů v místě nebo odesílání **[příkazů](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Neváhejte se rozhlédnout kolem sebe a zjistit všechny funkce ASF-ui.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Summary

Úspěšně jste nastavili ASF pro používání svých Steam účtů a již jste ho trochu přizpůsobili. Pokud jste následovali po celém našem průvodci, pak se vám také podařilo vylepšit ASF prostřednictvím našeho rozhraní ASF-ui a začít objevovat jeho funkce. Tímto uzavíráme náš kurz, ale necháváme tě s dalšími ukazateli na věci, které tě mohou zajímat "boční úkoly", pokud trváte:

- Naše sekce **[konfigurace](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** vám vysvětlí, co **všechno** ta různá nastavení, která jste viděli, a co dalšího vám může ASF nabídnout. Jen nezapomeňte při čtení správně hydratovat, byli jste varováni.
- Pokud jste narazili na nějaký problém nebo máte nějakou obecnou otázku, podívejte se na náš **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**které by měly pokrývat všechny nebo alespoň převážnou většinu otázek a otázek, které můžete mít.
- Pokud se chcete dozvědět vše o aplikaci ASF a o tom, jak může usnadnit život, přejděte na zbytek **[naší wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. Použijte postranní panel vpravo k výběru předmětu, který vás zajímá.
- A konečně, pokud jste zjistili, že náš program je pro vás užitečný a oceňujete obrovské množství práce, která do něj byla vložena, můžete také zvážit malý **[dar](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** pro naši věc. ASF je práce lásky, pracujeme tvrdě v našem volném čase posledních 10 let, abychom vám umožnili tuto zkušenost. a jsme na to velmi hrdí - dokonce i $1 je vysoce oceněno a ukazuje, že vám záleží. Každopádně máte spoustu zábavy!

---

## Obecné nastavení

Tento dodatek je pro pokročilé uživatele, kteří chtějí nastavit ASF pro běh v variantě **[generické](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)**. I když se jedná o problematičtější použití než **[varianty](#os-specific-setup)**specifické pro OS, přináší to také další výhody.

Chcete použít `generickou` variantu hlavně když:
- Používáte OS, pro který nevytváříme balíček specifický pro operační systém (např. 32-bit Windows)
- Již máte .NET Runtime/SDK, nebo chcete nainstalovat a použít jeden
- Chcete minimalizovat velikost struktury ASF a stopu paměti pomocí vlastních runtime požadavků
- Chcete použít vlastní **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** , který vyžaduje `generické` nastavení ASF (kvůli chybějícím nativním závislostem)

Samozřejmě ji můžete využít i v jakémkoliv jiném scénáři, který chcete, ale výše uvedené mají co největší smysl.

Ale mějte na paměti, že generické nastavení přichází se twist - **jste** v tomto případě zodpovědný za běh .NET. To znamená, že pokud je vaše .NET SDK (runtime) nedostupná, zastaralá nebo rozbitá, ASF jednoduše nebude fungovat. To je důvod, proč zcela nedoporučujeme toto nastavení pro příležitostné uživatele, protože nyní potřebujete zajistit, aby vaše . ET SDK (runtime) odpovídá ASF požadavkům a může spustit ASF, na rozdíl od **us** a zajišťuje, že naše . ET-runtime spojený s ASF to může udělat.

Pro `generický` balík můžete sledovat celý návod specifický pro OS, pouze se dvěma malými změnami. Kromě instalace .NET předpokladů také chcete nainstalovat .NET SDK, a namísto stahování a `ArchiSteamFarm(. xe)` spustitelný soubor, nyní si stáhnete a máte generický `ArchiSteamFarm.dll`. Všechno ostatní je naprosto stejné.

S dalšími kroky:
- Nainstalujte **[.NET předpoklady](#net-prerequisites)**.
- Nainstalujte **[.NET SDK](https://www.microsoft.com/net/download)** (nebo alespoň ASP.NET Core a .NET runtimes) vhodné pro váš OS. S největší pravděpodobností chcete použít instalační program. Pokud si nejste jisti, jakou verzi chcete nainstalovat, podívejte se na **[požadavky](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.
- Stáhněte si **[nejnovější verzi ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** v `generické variantě`.
- Rozbalit archiv do nového umístění.
- **[Konfigurace ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, přesně stejným způsobem, jak je popsáno výše.
- Spusťte ASF buď pomocí pomocného skriptu nebo proveďte `dotnet /path/to/ArchiSteamFarm.dll` ručně z vaší oblíbené schránky.

Obecná varianta ASF nemá žádný součinitel pro daný stroj, po všem, co se nazývá `generická` z nějakého důvodu - je to platforma-agnostická sestavení, která může fungovat všude, takže tam neočekávejte `exe`.

Proto jsme ho spojili s pomocnými skripty (například `ArchiSteamFarm.cmd` pro Windows a `ArchiSteamFarm. h` pro Linux/macOS), které se nacházejí vedle `ArchiSteamFarm.dll`. Můžete použít ty, pokud nechcete provést `dotnet` manuálně.

Pomocné skripty samozřejmě nebudou fungovat, pokud jste neinstalovali . ET SDK a nemáte `dotnet` k dispozici ve vašem `PATH`. Jsou také zcela volitelné pro používání, vždy můžete `dotnet /path/to/ArchiSteamFarm.` ručně, pokud chcete, stejně jako pod střechou s nějakými vylepšeními, to je přesně to, co tyto skripty dělají.