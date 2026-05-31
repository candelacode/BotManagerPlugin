# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` je oficiální ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** vyvinutý námi, který vám umožňuje přispět do projektu **[SteamDB](https://steamdb.info)** sdílením balíčků tokenů, tokeny aplikace a depot klíče, ke kterým má váš Steam účet přístup. Rozšířené informace o shromážděných údajích a proč SteamDB potřebuje, jsou dostupné na stránce SteamDB **[Token Dumper](https://steamdb.info/tokendumper)**. Předložené údaje neobsahují žádné potenciálně citlivé informace a nepředstavují žádné riziko pro bezpečnost nebo ochranu soukromí, jak je uvedeno výše.

---

## Povolení pluginu

ASF přichází s `SteamTokenDumperPlugin` spojený s vydáním, ale samotný plugin je ve výchozím nastavení zakázán. Plugin můžete povolit nastavením `SteamTokenDumperPluginEnabled` ASF globální vlastnosti konfigurace na `true`, v JSON syntaxi:

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

Při spuštění ASF programu vám plugin dá vědět, zda byl úspěšně povolen pomocí standardního ASF logovacího mechanismu. Můžete také povolit plugin prostřednictvím našeho webového konfiguračního generátoru.

---

## Technické podrobnosti

Po zapnutí bude plugin používat boty, které používáte v ASF pro sběr dat ve formě tokenů balíčků, tokeny aplikací a depot klíče, k nimž mají vaši boti přístup. Modul Shromažďování dat obsahuje pasivní a aktivní rutiny, které mají minimalizovat dodatečné režijní náklady způsobené shromažďováním dat.

Aby byl splněn plánovaný případ použití, kromě toho, že se shromažďují rutinní údaje vysvětlené výše, je inicializována rutina zodpovědná za určení toho, jaká data je třeba pravidelně zasílat SteamDB. This routine will fire in up to `1` hour since your ASF start, and will repeat itself every `24` hours. Plugin udělá vše pro minimalizaci množství dat, která je třeba odeslat, je proto možné, že některé údaje, které bude plugin shromažďovat, budou určeny jako zbytečné k odeslání, a proto přeskočeno (například aktualizace aplikace, která nemění přístupový token).

Plugin používá trvalou databázi cache uloženou v `config/SteamTokenDumper.cache` , která slouží k podobnému účelu jako `config/ASF.db` pro ASF. Soubor se používá k zaznamenávání shromážděných a odeslaných dat a minimalizaci množství práce, kterou je třeba vykonat v rámci různých běhů aplikace ASF. Odstranění souboru způsobí, že se proces restartuje od nuly, což by se mělo pokud možno vyhnout.

---

## Údaje

ASF zahrnuje do žádosti přispěvatele `steamID` , která je určena jako `SteamOwnerID` , kterou jste nastavili v ASF, nebo v případě, že jste neudělali, Steam ID bota, který vlastní nejvíce licencí. Oznámený přispěvatel by mohl obdržet další výhody od SteamDB pro trvalou pomoc (např. . darovací hodnost na webových stránkách), ale to je zcela podle uvážení SteamDB.

V každém případě by vám zaměstnanci SteamDB rádi předem poděkovali za vaši pomoc. Předložená data umožňují fungování SteamDB, zejména sledovat informace o balíčcích, aplikace a sklady, které by již nebyly možné bez vaší pomoci.

---

## Příkaz

STD plugin přichází s dalším příkazem ASF, `std [Bots]`, který vám umožní spustit aktualizaci a odeslání pro vybrané boty na vyžádání. Použití příkazu nevyžaduje povolenou konfiguraci, která umožňuje přeskočit automatické shromažďování a odesílání a ovládat proces ručně. Přirozeně může být také spuštěn s povolenou konfigurací, která jednoduše spustí obvyklé postupy shromažďování a odesílání dříve, než se očekávalo.

Doporučujeme `!std ASF` , abychom spustili aktualizaci pro všechny dostupné boty. Nicméně, pokud chcete, můžete ji spustit i pro vybrané.

---

## Rozšířené nastavení

Náš plugin podporuje pokročilé konfigurace, které by mohly být užitečné pro lidi, kteří by chtěli vylepšit interály na jejich preference.

Pokročilá konfigurace má následující strukturu nacházející se v `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Enabled": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretPackageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Všechny možnosti jsou vysvětleny níže:

### `Povoleno`

`bool` type with default value of `false`. Tato vlastnost se chová stejně jako `SteamTokenDumperPluginEnabled` je vysvětlena výše a lze ji použít, věnováno lidem, kteří by raději měli celou konfiguraci související s pluginem ve své vlastní struktuře (takže s největší pravděpodobností již používají jiné pokročilé vlastnosti vysvětlené níže).

---

### `SecretAppIDs`

`ImmutableHashSet<uint>` type with default value of be prázdný. Tato vlastnost specifikuje `appIDs` , že zásuvný modul nebude vyřešen, a pokud již bude vyřešen, nebude k dispozici token. Tato vlastnost může být užitečná pro lidi, kteří mají přístup k potenciálně citlivým informacím o nepublikovaných položkách, zejména vývojáři, vydavatelé nebo uzavřené beta testery.

---

### `Sekretářské ID`

`ImmutableHashSet<uint>` type with default value of be prázdný. Tato vlastnost specifikuje `depotIDs` , že zásuvný modul nevyřeší, a pokud jsou již vyřešeny, klíč pro něj nebude odeslat. Tato vlastnost může být užitečná pro lidi, kteří mají přístup k potenciálně citlivým informacím o nepublikovaných položkách, zejména vývojáři, vydavatelé nebo uzavřené beta testery.

---

### `SecretPackageID`

`ImmutableHashSet<uint>` type with default value of be prázdný. Tato vlastnost specifikuje `packageIDs` (také známý jako `subIDs`), které plugin nevyřeší, a pokud jsou již vyřešeny, nebude k dispozici token. Tato vlastnost může být užitečná pro lidi, kteří mají přístup k potenciálně citlivým informacím o nepublikovaných položkách, zejména vývojáři, vydavatelé nebo uzavřené beta testery.

---

### `Přeskočit AutoGrantPackages`

`bool` type with default value of `true`. Tato vlastnost se velmi podobá `SecretPackageIDs` a pokud je povoleno, způsobí, že balíky s `EPaymentMethod` z `AutoGrant` budou přeskočeny během vyřešení rutinního řešení vysvětleného níže. `AutoGrant` způsob platby používá **[Steamworks](https://partner.steamgames.com)** k automatickému přidělování balíčků na vývojářských účtech. I když to není tak explicitní jako jiné možnosti `Secret` , a proto nic nezaručujete (protože můžete mít jiné balíčky než `AutoGrant` , které stále nechcete odeslat), měla by být dostatečně dobrá pro přeskočení většiny, ne-li všech tajných balíčků. Tato možnost je ve výchozím nastavení povolena, protože lidé, kteří mají přístup k balíčkům `AutoGrant` , téměř nikdy nechtějí tyto balíčky uniknout veřejnosti, a proto použití hodnoty `false` je velmi situační.

---

## Další vysvětlení

Na kořenové úrovni každý Steam účet vlastní sadu balíčků (licence, předplatné), které jsou klasifikovány podle `packageID` (též známého jako `subID`). Každý balíček může obsahovat několik aplikací klasifikovaných jejich `appID`. Každá aplikace pak může obsahovat několik skladů klasifikovaných jejich `depotID`.

```text
├── sub/124923
│     ├── app/292030
│     │     ├── depot/292031
│     │     ├── depot/378648
│     │     └── ...
<unk> <unk> ázázecí app/378649
<unk> <unk> <unk> ázázázáze...
└── ...
```

Náš plugin obsahuje dvě rutiny, které berou v úvahu přeskočené položky - rutinní řešení a odeslání rutiny.

Vyřešení rutiny je zodpovědné za vyřešení stromu, který vidíte výše. Rozepsáním balíčků/aplikací/skladů předem na černé listině, budeš fakticky oříznutý strom na černé listině, aniž budeš muset specifikovat zbývající části listu. V našem příkladu výše, pokud byl balíček `124923` ignorován, může `SecretPackageIDs` nebo `SkipAutoGrantPackages`, a to byl jediný balíček, který jste vlastnili a který souvisí s aplikací `292030` , pak appID `292030` by také nebylo vyřešeno a z podstaty, pokud neexistují žádné vyřešené aplikace, které by souvisely s `292031` a `378648` , pak by se ani nevyřešily. Nicméně mějte na paměti, že pokud zásuvný modul již vyřešil strom, pak ve skutečnosti to pouze zastaví aktualizaci dané položky (např. přidány nové aplikace), nevytvoří plugin "zapomenut" o existujících položkách, které již byly vyřešeny (např. . aplikace nalezeny v tomto balíčku před tím, než jste se rozhodli jej na černé listině). Pokud jste právě povolili některé možnosti přeskočení a chtěli byste se ujistit, že ASF již neprochází stromem s vyřešením, můžete zvážit jednorázové odstranění `config/SteamTokenDumper. cache` soubor, kde zásuvný modul udržuje mezipaměť.

Rutinní odesílání je zodpovědné za odesílání tokenů balíčků, tokenů aplikací a klíčů pro již vyřešené položky (pomocí výše uvedeného řešení rutin). Zde má váš černá listina okamžitý účinek, jako i když plugin již vyřešil informaci, rutinní podání jej ve skutečnosti neposílá SteamDB, pokud ho máte na černé listině, bez ohledu na to, zda byl vyřešen nebo ne. Mějte však na paměti, že v tomto okamžiku již nehovoříme o stromu, rutina odeslání neví, zda informace o aplikaci pocházejí z tohoto nebo balíčku, tak pouze přeskočí informace o konkrétních položkách na černé listině bez ohledu na jejich vztah s jiným.

Pro většinu vývojářů a vydavatelů by mělo stačit ponechat `SkipAutoGrantPackages` povolené, může být zmocněn pouze s `SecretPackageIDs` , pokud účinně zruší strom na začátku větve a zaručí, že aplikace a sklady budou zahrnuty dále, nebudou odeslány, dokud nebude k dispozici žádný jiný balíček připojený ke stejné aplikaci. Pokud chcete mít dvojí jistotu, kromě toho, že můžete také použít `SecretAppIDs`, které přeskočí vyřešení aplikace, i když existují některé další licence, které jste neodkazovali na černou listinu. Použití `SecretDepotIDs` by nemělo být potřeba, pokud nemáte určitý typ specifické potřeby (např. přeskočení pouze konkrétního skladu při stále odesílání informací o balících a aplikacích), nebo pokud chcete přidat další vrstvu, aby byla bezpečná.