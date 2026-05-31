# Zabezpečení

## Šifrování

ASF v současné době podporuje následující šifrovací metody jako definici `ECryptoMethod`:

| Hodnota | Jméno                       |
| ------- | --------------------------- |
| 0       | Text                        |
| 1       | AES                         |
| 2       | ProtectedDataForCurrentUser |
| 3       | Proměnná pro prostředí      |
| 4       | Soubor                      |

Přesný popis a jejich srovnání je k dispozici níže.

### Instalace

Pro generování šifrovaného hesla, např. pro použití `SteamPassword` , byste měli provést `šifrování` **[příkaz](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** s odpovídajícím šifrováním, které jste zvolili, a s původním heslem v prostém textu. Poté vložte šifrovaný řetězec, který máte jako `vlastnosti bota SteamPassword` , a konečně změňte `formát hesel` na ten, který odpovídá zvolené šifrovací metodě. Některé formáty nevyžadují `šifrování` příkazu, například `EnvironmentVariable` nebo `File`, stačí pro ně vložit vhodnou cestu.

---

### `Text`

Toto je nejjednodušší a nejbezpečnější způsob ukládání hesla, definovaný jako `ECryptoMethod` `0`. ASF očekává, že řetězec bude prostý text - heslo v jeho přímé podobě. Je to nejjednodušší a 100% kompatibilní se všemi nastaveními, je tedy výchozím způsobem ukládání tajných klíčů, naprosto nejistým pro bezpečné úložiště.

---

### `AES`

Považujeme dnes za bezpečné, **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** způsob ukládání hesla je definován jako `ECryptoMethod` z `1`. ASF očekává, že řetězec bude **[base64-encoded](https://en.wikipedia.org/wiki/Base64)** posloupnost znaků vedoucí k AES šifrované bajtové pole po překladu, která by pak měla být dešifrována za použití zahrnutého **[inicializačního vektoru](https://en.wikipedia.org/wiki/Initialization_vector)** a ASF šifrovacího klíče.

Výše uvedená metoda zaručuje bezpečnost, pokud útočník nezná ASF šifrovací klíč, který se používá pro dešifrování a šifrování hesel. ASF umožňuje zadat klíč přes `--cryptkey` **[příkaz](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, který byste měli použít pro maximální zabezpečení. Pokud se rozhodnete vynechat, aplikace ASF použije vlastní klíč, který je **známý** a pevně nakódová do aplikace, znamená, že kdokoliv může vrátit ASF šifrování a dešifrovat heslo. Stále to vyžaduje určité úsilí a není to tak snadné, ale možné, to je důvod, proč byste měli téměř vždy používat `AES` šifrování s vlastním `--cryptkey` , které je uchováváno v tajnosti. Metoda AES použitá v ASF zajišťuje zabezpečení, které by mělo být uspokojivé a je to rovnováha mezi jednoduchostí `PlainText` a složitostí `ProtectedDataForCurrentUser`ale je velmi doporučeno jej použít s vlastním `--cryptkey`.

Pokud je správně použito (dlouhé, vlastní `--cryptkey`), zaručuje vysokou bezpečnost pro bezpečné úložiště.

---

### `ProtectedDataForCurrentUser`

Považujeme dnes za bezpečné, **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** způsob ukládání hesla je definován jako `ECryptoMethod` of `2`. Hlavní výhodou této metody je zároveň hlavní nevýhoda, místo používání šifrovacího klíče (jako v `AES`), data jsou šifrována pomocí přihlašovacích údajů aktuálně přihlášeného uživatele, což znamená, že je možné dešifrovat data **pouze** na počítači, kde byla šifrována, a kromě toho **pouze** uživatelem, který šifrování vydal.

Tím se zajistí, že i když pošlete celý svůj `Bot. syn` se šifrovaným `SteamPassword` pomocí této metody pro někoho jiného, nebudou moci dešifrovat heslo bez přímého přístupu k vašemu PC. Jedná se o vynikající bezpečnostní opatření, ale zároveň má velkou nevýhodu, že je nejméně kompatibilní, protože heslo šifrované pomocí této metody bude nekompatibilní s jakýmkoli jiným uživatelem a počítačem - včetně **vaší vlastní** , pokud se rozhodnete e. . přeinstalujte svůj operační systém. Toto je doporučená metoda, pokud nemáte přístup ke svým konfiguracím z jiného počítače, než je váš vlastní počítač, a že také nevyžadujete kompatibilitu mezi stroji.

**Vezměte prosím na vědomí, že tato možnost je nyní dostupná pouze pro stroje s Windows OS.**

---

### `Proměnná pro prostředí`

paměťové úložiště definované jako `ECryptoMethod` of `3`. ASF si přečte heslo z proměnné prostředí s zadaným jménem v poli heslo (např. `SteamPassword`). Například nastavení `SteamPassword` na `ASF_PASSWORD_MYACCOUNT` a `PasswordFormat` až `3` způsobí, že ASF vyhodnotí proměnnou prostředí `${ASF_PASSWORD_MYACCOUNT}` a použije, co je mu přiděleno jako heslo účtu.

Nezapomeňte zajistit, aby proměnné prostředí procesu ASF nebyly přístupné neoprávněným uživatelům, protože to maří celý účel použití této metody.

---

### `Soubory`

Úložiště založené na souboru (možná mimo adresář s konfigurací ASF) definované jako `ECryptoMethod` of `4`. ASF bude číst heslo ze cesty souboru zadané v poli s heslem (např. `SteamPassword`). Zvolená cesta může být buď absolutní, nebo relativní k umístění ASF (složka s `konfigurací` ve složce, zohledníme `--path` **[argument příkazové řádky](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). Tuto metodu lze použít například s **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**které vytvářejí takové soubory pro použití, ale mohou být také použity mimo Docker, pokud vytvoříte vhodný soubor sami. Například nastavte `SteamPassword` na `/etc/secrets/MyAccount. ass` a `PasswordFormat` to `4` způsobí přečtení ASF `/etc/secrets/MyAccount. Napsat` a použít cokoliv je zapsáno do tohoto souboru jako heslo k účtu.

Nezapomeňte se ujistit, že soubor obsahující heslo není čitelný neautorizovanými uživateli, protože to maří celý účel použití této metody.

---

## Doporučení šifrování

If compatibility is not an issue for you, and you're fine with the way how `ProtectedDataForCurrentUser` method works, it is the **recommended** option of storing the password in ASF, as it provides the best security and convenience. `AES` metoda je dobrá volba pro lidi, kteří stále chtějí využít svých konfigurací na jakémkoliv zařízení, které chtějí, zatímco `PlainText` je nejjednodušší způsob ukládání hesla, pokud vám nevadí, že se někdo může podívat na konfigurační soubor JSON.

Mějte prosím na paměti, že všechny šifrovací metody jsou považovány za **nezabezpečené** , pokud má útočník přístup k vašemu PC. ASF musí být schopen dešifrovaná hesla dešifrovat, a pokud je to program spuštěný na vašem počítači schopný, pak každý další program běžící na stejném počítači bude schopen také. `ProtectedDataForCurrentUser` je nejbezpečnější varianta, protože **ani jiný uživatel používající stejný PC nebude schopen dešifrovat**ale je stále možné data dešifrovat, pokud je někdo schopen ukrást vaše přihlašovací údaje a informace o počítači kromě ASF konfiguračního souboru.

Pro pokročilé nastavení můžete využít `EnvironmentVariable` a `File`. Mají omezenou použitelnost, `EnvironmentVariable` bude dobrý nápad, pokud chcete získat heslo pomocí nějakého vlastního řešení a uložit ho výhradně do paměti, `File` je dobrý například pro **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. Obě jsou však nešifrované, takže v podstatě přesouváte riziko z ASF konfiguračního souboru na cokoli z těchto dvou souborů.

Kromě výše uvedených šifrovacích metod je také možné vyhnout se specifikování hesel, například jako `SteamPassword` pomocí prázdného řetězce nebo `null`. ASF vás požádá, až bude vyžadováno heslo, a nebude to nikde ukládat, ale uchovat si v paměti právě probíhající proces, dokud ho nezavříte. I když je nejbezpečnějším způsobem nakládání s hesly (nejsou nikde uloženy), je to také nejproblematičtější, protože je potřeba zadat heslo ručně při každém spuštění aplikace ASF (když je vyžadováno). Pokud to není problém pro vás, je to vaše nejlepší sázka na bezpečnost, protože nemůžete uniknout něco, co neexistuje.

---

## Dešifrování

ASF nepodporuje žádný způsob dešifrování již šifrovaných hesel, protože metody dešifrování jsou používány pouze interně pro přístup k datům uvnitř procesu. Pokud chcete vrátit zpět postup šifrování, např. pro přesunutí ASF do jiného zařízení při použití `ProtectedDataForCurrentUser`, pak jednoduše opakujte postup od začátku nového prostředí.

---

## Hashing

ASF v současné době podporuje následující hashovací metody jako definici `EHashingMethod`:

| Hodnota | Jméno  |
| ------- | ------ |
| 0       | Text   |
| 1       | SCrypt |
| 2       | Pbkdf2 |

Přesný popis a jejich srovnání je k dispozici níže.

### Instalace

Pro generování hash, např. pro použití `IPCPassword` , byste měli provést `hash` **[příkaz](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** s vhodnou metodou hashování, kterou jste zvolili, a s původním heslem ve formátu prostého textu. Poté vložte hashed řetězec, který máte jako `IPCPassword` ASF konfigurační vlastnost, a konečně změňte `IPCPasswordFormat` na ten, který odpovídá zvolené hashovací metodě.

---

### `Text`

Toto je nejjednodušší a nejbezpečnější způsob hashování hesla, definovaný jako `EHashingMethod` of `0`. ASF vygeneruje hash odpovídající původnímu vstupu. Je to nejjednodušší a 100% kompatibilní se všemi nastaveními, je tedy výchozím způsobem ukládání tajných klíčů, naprosto nejistým pro bezpečné úložiště.

---

### `SCrypt`

Považujeme dnes za bezpečné, **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** způsob hashování hesla je definován jako `EHashingMethod` of `1`. ASF použije implementaci `SCrypt` pomocí bloků `8` , `8192` iterace, `32` délka hash a šifrovací klíč jako sůl pro generování pole bytů. Výsledná bajty pak budou kódovány jako **[base64](https://en.wikipedia.org/wiki/Base64)**.

ASF umožňuje specifikovat sůl pro tuto metodu pomocí `--cryptkey` **[příkazového řádku](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**které byste měli použít pro maximální zabezpečení. Pokud se rozhodnete vynechat, aplikace ASF použije vlastní klíč, který je **známý** a pevně nakódová do aplikace, Význam hashing bude méně bezpečný.

Pokud je používáno správně (custom sůl, dlouhé heslo), zaručuje vysokou bezpečnost bezpečného skladování.

---

### `Pbkdf2`

Dnešní standardy, které jsou považovány za slabé, **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** způsob hashování hesla je definován jako `EHashingMethod` of `2`. ASF použije implementaci `Pbkdf2` pomocí `10000` iterací, `32` délka hash a šifrovací klíč jako sůl, s `SHA-256` jako hmac algoritmus. Výsledná bajty pak budou kódovány jako **[base64](https://en.wikipedia.org/wiki/Base64)**.

ASF umožňuje specifikovat sůl pro tuto metodu pomocí `--cryptkey` **[příkazového řádku](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**které byste měli použít pro maximální zabezpečení. Pokud se rozhodnete vynechat, aplikace ASF použije vlastní klíč, který je **známý** a pevně nakódová do aplikace, Význam hashing bude méně bezpečný.

---

## Hashing doporučení

Pokud chcete použít metodu hashování pro ukládání některých tajných klíčů, jako je `IPCPassword`, doporučujeme použít `SCrypt` s vlastní solí, protože poskytuje velmi slušné zabezpečení proti pokusům o vynucení bruteů.

`Pbkdf2` je nabízen pouze z důvodů slučitelnosti, především proto, že již máme fungující (a potřebné) implementaci pro jiné případy na platformě Steam (např. rodičovské piny). Je stále považován za bezpečný, ale ve srovnání s alternativami (např. `SCrypt`).