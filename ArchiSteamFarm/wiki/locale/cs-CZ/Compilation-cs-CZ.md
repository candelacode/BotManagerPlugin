# Kompilace

Kompilace je proces vytváření spustitelného souboru. To je to, co chcete udělat, pokud chcete přidat vlastní změny do aplikace ASF, nebo pokud z nějakého důvodu nedůvěřujete spustitelným souborům uvedeným v oficiální **[verzi](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**. Pokud jste uživatel, a ne vývojář, s největší pravděpodobností chcete použít již předkompilované binárky, ale pokud chcete použít vlastní nebo se naučit něco nového, pokračujte ve čtení.

ASF lze zkompilovat na libovolné aktuálně podporované platformě, pokud k tomu máte všechny potřebné nástroje.

---

## .NET SDK

Bez ohledu na platformu potřebujete plnou verzi .NET SDK (ne jen běžný), abyste mohli kompilovat ASF. Návod k instalaci naleznete na stránce **[.NET download](https://dotnet.microsoft.com/download)**. Musíte nainstalovat příslušnou verzi .NET SDK pro váš OS. Po úspěšné instalaci by příkaz `dotnet` měl být funkční a funkční. Můžete ověřit, zda to funguje s `dotnet --info`. Také se ujistěte, že váš .NET SDK odpovídá ASF **[požadavkům](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## Kompilace

Předpokládejme, že máte .NET SDK operační a v příslušné verzi, jednoduše přejděte do zdrojového adresáře ASF (klonované nebo stažené a nebalené ASF repo) a proveďte:

```shell
dotnet publikovat ArchiSteamFarm -c "Release" -o "out/generic"
```

Pokud používáte Linux/macOS, můžete místo toho použít skript `cc.sh` , který udělá totéž, trochu složitěji.

Pokud kompilace úspěšně skončila, můžete najít váš ASF v `zdrojovém` flavour v `out/generickém` adresáři. Toto je stejné jako oficiální `generický` ASF sestavený ale přinutil `UpdateChannel` a `UpdatePeriod` `0`což je vhodné pro vlastní budovy.

### Specifický pro OSS

Pokud máte konkrétní potřebu, můžete také vygenerovat balíček .NET specifický pro operační systém. Obecně byste to neměli, protože jste právě zkompilovali `generický` chuť, který můžete spustit s již nainstalovaným . ET runtime který jste použili pro kompilaci, ale jen v případě, že chcete:

```shell
dotnet publikovat ArchiSteamFarm -c "Release" -o "out/linux-x64" -r "linux-x64" --self-contained
```

Samozřejmě, nahraďte `linux-x64` OS-architekturou, kterou chcete cílit, jako je `win-x64`. Toto sestavení bude mít také zakázané aktualizace. Při stavbě `--self-contained` můžete volitelně vyhlásit další dva přepínače: `-p:PublishTrimmed=true` vytvoří upravené sestavení, zatímco `-p:PublishSingleFile=true` vytvoří jeden soubor. Přidáním obou nastavení dosáhneme stejného nastavení, jaké používáme pro naše vlastní sestavení.

### ASF-ui

Zatímco výše uvedené kroky jsou všechno, co musí mít plně funkční sestavení ASF, můžete *také* mít zájem o vybudování **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, našeho grafického webového rozhraní. Z ASF strany stačí pouze vyprázdnit ASF-ui sestavení ve standardní `ASF-ui/dist` poloze, poté s ní budovat ASF (v případě potřeby).

ASF-ui je součástí zdrojového stromu ASF jako **[git podmodul](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**ujistěte se, že jste klonovali repozitář pomocí `git klonování --reursive`, protože jinak nebudete mít požadované soubory. Budete také potřebovat funkční NPM, **[Node.js](https://nodejs.org)** s ním přijde. Pokud používáte Linux/macOS, doporučujeme náš `cc. h` skript, který bude automaticky pokrývat stavbu a dopravu ASF-ui (pokud je to možné, tedy pokud splňujete požadavky, které jsme právě zmínili).

Kromě `cc. h` skript, připojujeme také zjednodušené návody pro stavbu níže, pro další dokumentaci viz **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)**. Z umístění stromu ve zdrojovém kódu ASF, tak jak bylo uvedeno výše, proveďte následující příkazy:

```shell
rm -rf "ASF-ui/dist" # ASF-ui neočistí se po starém sestavení

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # Ujistěte se, že náš stavební výstup je čistý z starých souborů
dotnet publikovat ArchiSteamFarm -c "Release" -o "out/generic" # nebo podle toho, co potřebujete podle výše uvedeného
```

Nyní byste měli být schopni najít soubory ASF-ui ve vaší složce `out/generic/www`. ASF bude moci tyto soubory obsluhovat vašemu prohlížeči.

Alternativně můžete jednoduše vytvořit ASF-ui, ať už ručně nebo s pomocí našeho repou, pak ručně zkopírujte stavební výstup do složky `${OUT}/www` , kde `${OUT}` je výstupní složka ASF, kterou jste zadali s parametrem `-o`. To je přesně to, co ASF dělá v rámci stavebního procesu, zkopíruje `ASF-ui/dist` (pokud existuje) na `${OUT}/www`, nic speciálního a může být provedeno i po sestavení, jak vidíte, v případě potřeby.

---

## Rozvoj

Pokud chcete upravit ASF kód, můžete použít libovolný . IDE kompatibilní s ET za tímto účelem, i když je to nepovinné, protože můžete také upravovat pomocí notepadu a kompilovat pomocí příkazu `dotnet` popsaného výše.

Pokud nemáte lepší výběr, můžeme doporučit **[JetBrains Rider](https://www.jetbrains.com/rider)** a **[kód Visual Studio](https://code.visualstudio.com/download)**s prvním je preferovaný IDE, který tým ASF osobně používá, a druhým je životaschopná alternativa. Oba programy jsou na různých platformách a jsou dostupné na Linuxu, macOS a Windows.

---

## Tagy

`hlavní` pobočka není zaručena ve stavu umožňujícím úspěšné kompilaci nebo bezchybné provedení ASF, protože je to vývojová větev stejně jako je uvedeno v našem vývojovém cyklu **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. Pokud chcete zkompilovat nebo referenční ASF ze zdroje, pak byste pro tento účel měli použít odpovídající **[značku](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** , která zaručuje alespoň úspěšné kompilace a velmi pravděpodobně i bezchybnou exekuci (pokud byla postavena označena jako stabilní vydání). Chcete-li zkontrolovat aktuální "zdraví" stromu, můžete použít naši CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Oficiální vydání

Oficiální verze ASF jsou sestaveny **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, s nejnovějším . ET SDK, která odpovídá ASF **[požadavkům](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. Po úspěšných zkouškách jsou všechny balíky nasazeny jako vydání, také na GitHub. To také zaručuje transparentnost, protože GitHub vždy používá oficiální veřejný zdroj pro všechny budovy, a můžete porovnat kontrolní součty GitHub artefaktů s aktivy uvolnění GitHub. Vývojáři ASF nesestavují ani nepublikují vlastní sestavení, s výjimkou soukromých vývojářských procesů a ladění.

Kromě výše uvedeného správci ASF ručně validují a zveřejňují kontrolní součty na nezávislém serveru GitHub, vzdáleném ASF serveru, jako dodatečné bezpečnostní opatření. Tento krok je povinný, aby stávající přidružené systémy považovaly vydání za platného kandidáta na funkci automatické aktualizace.