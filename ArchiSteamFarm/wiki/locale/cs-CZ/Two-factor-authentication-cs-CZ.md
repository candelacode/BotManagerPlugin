# Dvoufaktorové ověření

Steam obsahuje systém dvoufaktorového ověřování, který vyžaduje další podrobnosti pro různé aktivity související s účtem. Více se dozvíte **[zde](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** a **[zde](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. Tato stránka se domnívá, že systém 2FA i naše řešení, které se s ním spojuje, nazývané ASF 2FA.

---

# ASF logika

Pokud používáte ASF 2FA nebo ne, ASF obsahuje řádnou logiku a je si plně vědom účtů chráněných 2FA na Steamu. Bude se vás ptát na požadované podrobnosti, pokud jsou potřebné (např. během přihlášení). Tyto informace můžete poskytnout ručně. některé funkce ASF (např. `MatchActively`) vyžadují, aby ASF 2FA byla operativní na vašem účtu bota, která může automaticky reagovat na 2FA výzvy automaticky, kdykoli to vyžaduje ASF.

---

# ASF 2FA

ASF 2FA je vestavěný modul odpovědný za poskytování funkcí 2FA v procesu ASF, jako je generování tokenů a přijímání potvrzení. Může fungovat buď v samostatném režimu, nebo duplikací vašich stávajících ověřovacích údajů (abyste mohli současně používat svůj aktuální autentifikátor a ASF 2FA).

Můžete ověřit, zda váš bot účet používá ASF 2FA tím, že provedete `2fa` **[příkazy](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Bez nastavení ASF 2FA budou všechny standardní `2fa` příkazy nefunkční, což znamená, že váš bot není k dispozici pro pokročilé funkce ASF, které vyžadují, aby byl modul funkční.

---

# Doporučení

Existuje mnoho způsobů, jak udělat ASF 2FA operativní, zde přidáme naše doporučení na základě vaší aktuální situace:

- Pokud již používáte neoficiální aplikaci třetích stran, která vám umožňuje snadno extrahovat 2FA detaily, stačí **[importovat](#import)** do ASF.
- Pokud používáte oficiální aplikaci a nevadí vám resetovat vaše 2FA přihlašovací údaje, je nejlepší způsob, jak 2FA zakázat, pak **[vytvořit](#creation)** nové 2FA přihlašovací údaje pomocí **[společného autentizátoru](#joint-authenticator)**které vám umožní používat oficiální aplikaci a ASF 2FA. Tato metoda **nevyžaduje root**, vězení ani žádné pokročilé znalosti, sotva podle instrukcí napsaných zde a je pravděpodobně lepší pro tento scénář.
- Pokud používáte oficiální aplikaci a nechcete znovu vytvořit své 2FA přihlašovací údaje, vaše možnosti jsou velmi omezené, Obvykle budete potřebovat root a další fiddling na **[import](#import)** tyto detaily, a dokonce i s tím by to mohlo být nemožné.
- Pokud ještě nepoužíváte 2FA a nezajímáte se doporučujeme použít ASF 2FA s **[standalone authenticator](#standalone-authenticator)** nebo **[spoluautentizátor](#joint-authenticator)** s oficiální aplikací (stejnou jako výše).

Níže diskutujeme o všech možných možnostech a známých metodách.

---

## Vytváření

ASF má oficiální `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** , který dále rozšiřuje ASF 2FA, umožňuje propojit zcela nového 2FA autentifikátora. To může být užitečné v případě, že nemůžete nebo nechcete používat jiné nástroje a nevadí, že se ASF 2FA stane vaším hlavním (a možná pouze) autentizátorem. Proces tvorby se používá také v metodě spoluautentizace, Váš autentizátor může přirozeně existovat na dvou místech najednou - oba budou generovat stejné kódy a oba budou moci potvrdit stejná potvrzení.

### Společné kroky pro oba scénáře

Bez ohledu na to, zda plánujete použít ASF jako samostatný nebo společný autentizátor, musíte provést tyto inicializační kroky:

1. Vytvořte ASF bota pro cílový účet, založte ho a přihlaste se, což jste pravděpodobně již učinili.
2. Přiřaďte pracovní a operační telefonní číslo k účtu **[zde](https://store.steampowered.com/phone/manage)** , který bude použit botem. To vám umožní přijímat SMS kód a v případě potřeby povolit obnovení. Tento krok není povinný ve všech scénářích, ale doporučujeme ho, pokud nevíte, co děláte.
3. Ujistěte se, že pro svůj účet ještě nepoužíváte 2FA, pokud to uděláte, nejdříve jej vypněte. Toto **** vloží váš účet do dočasného obchodu, neexistuje žádný způsob, jak ho obejít, pouze **[import](#import)** proces může přeskočit.
4. Proveďte `2fainit [Bot]` příkaz nahrazující `[Bot]` jménem bota.

Předpokládejme, že dostanete úspěšnou odpověď, došlo k těmto dvěma věcem:

- Nový `<Bot>.maFile.PENDING` soubor byl generován ASF ve vašem `konfiguračním adresáři`.
- Ze Steamu byla odeslána SMS na telefonní číslo, které jste přidělili pro výše uvedený účet. Pokud jste nenastavili telefonní číslo, byl místo toho odeslán e-mail na e-mailovou adresu účtu.

Detaily autentifikátoru ještě nejsou funkční, můžete však zkontrolovat vygenerovaný soubor, pokud chcete. Pokud chcete být bezpeční, můžete například již zapsat kód odvolání. Další kroky budou záviset na zvoleném scénáři.

### Samostatný autentifikátor

Pokud chcete použít ASF jako hlavní (nebo i pouze) autentizátor, nyní musíte udělat konečný finalizační krok:

5. provést příkaz `2fafinalize [Bot] <ActivationCode>` , nahradit `[Bot]` jménem vašeho bota a `<ActivationCode>` kódem, který jste obdrželi prostřednictvím SMS nebo e-mailu v předchozím kroku.

### Společný autor

Pokud chcete mít stejný autentifikátor jak v ASF, tak v oficiální mobilní aplikaci Steam, teď budeš muset udělat další, složitější kroky:

5. **Ignorovat** SMS nebo e-mail kód, který jste obdrželi v předchozím kroku.
6. Nainstalujte si mobilní aplikaci Steam, pokud ještě není nainstalována, a otevřete ji. Přejděte na kartu Steam Guard a přidejte nový autentifikátor podle instrukcí aplikace.
7. Po přidání a funkčnosti autentizátoru v mobilní aplikaci se vraťte do aplikace ASF. Namísto finalizace stačí pouze informovat ASF, že mobilní aplikace již aktivovala naše dříve vytvořené detaily:
 - Počkejte, dokud nebude v mobilní aplikaci Steam zobrazen další 2FA kód, a použijte příkaz `2fafinalized [Bot] <2FACodeFromApp>` nahrazující `[Bot]` jménem vašeho bota a `<2FACodeFromApp>` kódem, který právě vidíte v mobilní aplikaci Steam - stejný, jaký byste mohli použít pro přihlášení do Steamu (**NE** ten, který jste již použili pro aktivaci). Pokud je kód vygenerovaný ASF a kód, který jste zadali, stejný, ASF předpokládá, že autentizátor byl správně přidán a pokračuje v importu nově vytvořeného autentifikátoru.
 - Důrazně doporučujeme vykonat výše uvedené, abychom zajistili, že vaše přihlašovací údaje budou platné. Pokud však nechcete (nebo nemůžete) zkontrolovat, zda jsou kódy stejné a víte, co děláte, místo toho můžete použít příkaz `2fafinalizedforce [Bot]`, kterým se nahrazuje `[Bot]` jménem vašeho bota. ASF předpokládá, že autentizátor byl správně přidán a pokračuje v importu nově vytvořeného autentifikátoru. Uvědomte si, že v tomto režimu ASF nemůže ověřit, zda se kódy shodují, což znamená, že můžete potenciálně importovat neplatné (neaktivované) pověření.

### Po dokončení

Za předpokladu, že vše funguje správně, dříve generovaný soubor `<Bot>.maFile.PENDING` byl přejmenován na `<Bot>.maFile.NEW`. To znamená, že vaše 2FA přihlašovací údaje jsou nyní platné a aktivní. Doporučujeme přesunout tento soubor mimo adresář `config` a **jej uložit na bezpečné místo**. Kromě toho, pokud jste se rozhodli použít samostatný autentizátor, pak doporučujeme otevřít soubor v editoru a zapsat `revocation_code`, které vám umožní odebrat autentifikátor, jak se nazývá název, pokud ho ztratíte. V metodě spoluautentizace byste to již měli udělat ve Steam mobilní aplikaci, ale neváhejte to udělat v případě, že potřebujete.

Pokud jde o technické podrobnosti, vygenerovaný `maFile` obsahuje všechny podrobnosti, které jsme obdrželi ze serveru Steam při propojení autentizátoru; a kromě toho `device_id` pole, které může být potřeba pro jiné (třetí strany) autentifikátory, pokud se někdy rozhodnete importovat tento `maFile` do nich.

ASF automaticky importuje autentifikátor, jakmile je postup dokončen, a proto `2fa` a další související příkazy by měly být nyní funkční pro účet bota, se kterým jste autentifikátor propojili. Doporučujeme vám to ověřit.

---

## Import

Proces importu vyžaduje již propojený a operační autentifikátor, který je podporován ASF. Máme pokyny pro několik různých oficiálních a neoficiálních zdrojů 2FA, navíc k ruční metodě, která vám umožní poskytnout požadované přihlašovací údaje. Vezměte prosím na vědomí, že tyto pokyny by měly být použity **pouze** , pokud již používáte dané řešení - protože proces zde zahrnuje aplikace a nástroje třetích stran, **nedoporučujeme jejich použití**, a zmiňujeme to výhradně pro lidi, kteří se již rozhodli je použít a chtěli bychom importovat vygenerované detaily do ASF 2FA.

Všeobecně proces importu zahrnuje vynechání `maFile` ve vhodném formátu do adresáře `config` ASF, na které ASF uloží tento soubor a z bezpečnostních důvodů jej automaticky odstraní.

Všechny následující návody od vás vyžadují, abyste již měli **funkční a operační** autentifikátor, který je používán s daným nástrojem/aplikací. ASF 2FA nebude správně fungovat, pokud importujete neplatná data, a proto se ujistěte, že vaše autentifikátor pracuje správně, než se ho pokusí importovat. To zahrnuje testování a ověření, zda funkce autentizace fungují správně:
- Můžete vygenerovat tokeny a tyto tokeny jsou přijaty sítí Steam (můžete se u nich přihlásit)
- Můžete načíst potvrzení a přijíždějí na váš mobilní autentifikátor
- Na tato potvrzení můžete reagovat, a jsou správně rozpoznána sítí Steam jako potvrzené/odmítnuté

Ujistěte se, že vaše autentifikátor funguje kontrolou, zda výše uvedené akce fungují - pokud nefungují, pak také nebudou fungovat v ASF.

### Android telefon

Obecně pro import autentifikátoru z vašeho Android telefonu budete potřebovat **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))**. Níže uvedené instrukce vyžadují od vás docela slušné znalosti ve světě modding Android, určitě nechceme vysvětlit každý krok zde. navštivte **[XDA](https://xdaforums.com)** a další zdroje pro další informace/pomoc níže.

**K dnešnímu dni neexistuje žádná známá metoda těžby, která by nadále fungovala. Můžete se přesto pokusit sledovat níže uvedené kroky, např. se zastaralou verzí aplikace, ale nezaručujeme, že bude fungovat správně. Zvažte použití metody spoluautentizátoru.**

<details>
  <summary>Pokyny k archivaci</summary>

Předpokládejme, že máte oficiální **[Steam aplikaci](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** funkční a funkční (níže vyžaduje rootnutí vašeho zařízení):

- Nainstalujte **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** a povolte Zygisk v nastavení.
- Nainstalujte **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (pro Zygisk) a ujistěte se, že funguje.
- Nainstalujte **[SteamGuardDump](https://github.com/YifePlayte/SteamGuardDump/releases/latest)** nebo **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** LSPosed modul a povolte jej v nastavení LSPosed.
- Vynutit ukončení Steam aplikace a poté ji otevřít, Steam ochranný systém by nyní měl být k dispozici detaily pro kopírování do schránky.

Nyní, když jste úspěšně extrahovali požadované podrobnosti, zakažte modul tak, aby se zabránilo automatickému kopírování, poté zkopírujte hodnotu `shared_secret` a `identity_secret` účtu, který chcete přidat do ASF 2FA, do nového textového souboru s níže uvedenou strukturou:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Nahradit každou hodnotu `STRING` vhodným soukromým klíčem z extrahovaných podrobností. Once you do that, rename the file to `BotName.maFile`, where `BotName` is the name of your bot you're adding ASF 2FA to, and put it in ASF's `config` directory if you haven't yet.

Spusťte ASF, která by měla zaznamenat váš soubor a importovat jej. Předpokládejme, že jste importovali správný soubor s platnými tajnými klíči, vše by mělo fungovat správně, což můžete ověřit pomocí příkazů `2fa`. Pokud jste udělali chybu, můžete vždy odstranit `Bot.db` a v případě potřeby začít znovu.

</details>

### SteamDesktopAuthenticator

Pokud váš autentifikátor již běží v SDA, měli byste si všimnout, že ve složce `maFiles` je dostupný soubor `steamID.maFile`. Ujistěte se, že `maFile` je v nešifrované podobě, ASF nemůže dešifrovat soubory SDA - nešifrovaný obsah souboru by měl začínat znakem `{` a končit znakem `}`. V případě potřeby můžete nejdříve odstranit šifrování z nastavení SDA a znovu jej povolit, až budete hotovi. Jakmile je soubor v nešifrované podobě, zkopírujte jej do složky `config` ASF.

Nyní můžete přejmenovat `steamID.maFile` na `BotName. aFile` v adresáři s konfigurací ASF, kde `BotName` je název vašeho bota, do kterého přidáváte ASF 2FA Alternativně ji můžete ponechat tak, jak je, ASF ji poté automaticky vybere po přihlášení. Přejmenování souboru pomáhá ASF tím, že umožňuje použít ASF 2FA před přihlášením, pokud to neuděláte, pak může být soubor vybrán pouze po úspěšném přihlášení ASF (protože ASF nezná `steamID` vašeho účtu před tím, než se ve skutečnosti přihlásíte).

Spusťte ASF, která by měla zaznamenat váš soubor a importovat jej. Předpokládejme, že jste importovali správný soubor s platnými tajnými klíči, vše by mělo fungovat správně, což můžete ověřit pomocí příkazů `2fa`. Pokud jste udělali chybu, můžete vždy odstranit `Bot.db` a v případě potřeby začít znovu.

### WinAuth

Nejprve vytvořte nové prázdné `BotName. aFile` v adresáři s konfigurací ASF, kde `BotName` je název vašeho bota, do kterého přidáváte ASF 2FA. Pokud zadáte nesprávný název, nebude vybrán ASF.

Nyní jako obvykle spusťte WinAuth. Klikněte pravým tlačítkem myši na Steam ikonu a vyberte "Zobrazit SteamGuard a obnovovací kód". Pak zaškrtněte "Povolit kopírování". Měli byste si všimnout JSON struktury v dolní části okna, počínaje `{`. Zkopírujte celý text do `BotName.maFile` , který jste vytvořili v předchozím kroku.

Spusťte ASF, která by měla zaznamenat váš soubor a importovat jej. Předpokládejme, že jste importovali správný soubor s platnými tajnými klíči, vše by mělo fungovat správně, což můžete ověřit pomocí příkazů `2fa`. Pokud jste udělali chybu, můžete vždy odstranit `Bot.db` a v případě potřeby začít znovu.

### Ruční

Pokud jste pokročilý uživatel, můžete také generovat maFile ručně. Toto lze použít v případě, že chcete importovat autentifikátor z jiných zdrojů, než které jsme popsali výše. Měla by mít **[platnou JSON strukturu](https://jsonlint.com)**:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Standardní ověřovací data mají více polí - ASF je během importu zcela ignoruje, protože nejsou potřeba. Není třeba je odstraňovat - ASF vyžaduje pouze platný JSON se 2 povinnými poli popsanými výše a ignoruje další pole (pokud existují). Samozřejmě je třeba nahradit zástupný znak `STRING` v příkladu výše s platnými hodnotami pro váš účet. Každý `STRING` by měl být základní 64-kódované zastoupení bytů, z nichž je vytvořen vhodný soukromý klíč.

---

## Často kladené otázky

### Jak ASF používá 2FA modul?

Pokud je k dispozici ASF 2FA, ASF jej použije k automatickému potvrzení obchodů, které jsou zasílány/přijaty ASF. Bude také schopen automaticky generovat tokeny 2FA podle potřeby, například pro přihlášení. Kromě toho díky ASF 2FA můžete také povolit `2fa` příkazy, které můžete použít.

### Jak mohu získat 2FA token?

Pro přístup k účtu chráněnému 2FA budete potřebovat 2FA token, který zahrnuje každý účet s ASF 2FA. Pokud jste se rozhodli použít samostatný autentifikátor, pak byste měli použít příkaz `2fa <BotNames>` pro generování dočasného tokenu pro dané instance botů. Ve všech ostatních scénářích doporučujeme použít původní autentizátor, který jste použili i když tento příkaz můžeš použít, pokud je pro tebe pohodlnější.

### Mohu použít svého původního autentifikátoru po import jako ASF 2FA?

Ano, váš původní autentizátor zůstává funkční a můžete jej použít společně s ASF 2FA. Mějte však na paměti, že pokud jej zneplatníte pomocí libovolné metody, pak již nebudou platné také připojené přihlašovací údaje ASF 2FA.

### Jak odstranit ASF 2FA?

Jednoduše ukončete ASF a odstraňte související `BotName.db` bota s propojeným ASF 2FA, který chcete odstranit. Tato volba odstraní související importované 2FA s ASF, ale nezruší platnost vašeho autentifikátoru. Pokud namísto toho chcete zneplatnit autentifikátor, kromě jeho odstranění z aplikace ASF (především), měli byste jej zrušit v původním autentifikátoru dle vašeho výběru. Pokud to z nějakého důvodu nemůžete udělat, například protože používáte ASF 2FA v samostatném režimu, poté použijte odvolací kód, který jste obdrželi během nastavení, na Steam webu. Není možné zneplatnit autentifikátor pomocí ASF.

### Připojil jsem autentifikátor v aplikaci třetích stran, poté importován do aplikace ASF. Mohu ho nyní znovu propojit na svém telefonu?

**No**. Tím zneplatníte dříve importované přihlašovací údaje a vaše ASF 2FA přestane fungovat (vytvořením kódů již Steam nepřijímá). Nejprve se rozhodněte, kde chcete, aby byl nalezen původní autentifikátor nebo autentizátor třetí strany, poté jej importujte jako ASF 2FA.

### Používám spoluautentizátor, mohu přesunout svou aplikaci na jiný telefon?

**No**. Co parní stát jako "přesouvá" nebo "transferní" autentizátor, se ve skutečnosti rovná zneplatnění starého a přiřazení nového, a to v jednom kroku. To vám umožní přeskočit např. v porovnání s těmito dvěma nezávislými kroky je však v případě ASF nadměrný pokles, toto ve skutečnosti zneplatňuje přihlašovací údaje, které jste dříve vygenerovali v ASF, což činí celý ASF 2FA modul nefunkčním.

Doporučeným způsobem je zcela odstranit autentifikátor na starém telefonu a znovu použít metodu spoluautentizace na novém telefonu. Pokud jste již přesunuli autentifikátor, staré ASF 2FA přihlašovací údaje jsou již neplatné, takže zbývá jediná věc je odstranění vašeho "přesunutého" autentizátoru a propojení nového autentizátoru pomocí metody autentizace znovu.

### Je používání ASF 2FA lepší než autentizační sada třetích stran pro přijetí všech potvrzení?

**Ano**několika způsoby. First and most important one - using ASF 2FA **significantly** increases your security, as ASF 2FA module ensures that ASF will only accept automatically its own confirmations, so even if attacker does request a trade that is harmful, ASF 2FA will **not** accept such trade, as it was not generated by ASF. Kromě bezpečnostní části přináší používání ASF 2FA také výhody spojené s plněním/optimalizací, protože ASF 2FA načítá a přijímá potvrzení bezprostředně po jejich vytvoření, a pouze tehdy, na rozdíl od neefektivního hlasování pro potvrzení každých X minut, kterého se dosáhne jinými řešeními. Není důvod používat autentifikátor třetí strany přes ASF 2FA, pokud plánujete automatizaci potvrzení generovaných ASF - přesně to ASF 2FA je, a jeho použití není v rozporu s Vámi potvrzením všeho ostatního v autentizátoru dle vašeho výběru. Důrazně doporučujeme používat ASF 2FA pro celou aktivitu ASF.