# Lokalizace

ASF je napájen službou Crowdin, která všem umožňuje pomáhat s překladem ASF do všech jazyků mluvených po celém světě. Pro podrobnější vysvětlení, jak funguje Crowdin, prosím navštivte **[Crowdin úvod](https://support.crowdin.com/crowdin-intro)**.

Pokud máte zájem o to, co právě probíhá, můžete zkontrolovat **[ASF Crowdin aktivitu](https://crowdin.com/project/archisteamfarm/activity_stream)**.

---

## Rozsah

Naše platforma podporuje lokalizaci našeho hlavního programu ASF a také celý lokalizovatelný obsah, který nabízíme společně s ním. To zahrnuje zejména naše ASF-WebConfigGenerator, ASF-ui, stejně jako naši wiki. To vše je možné přeložit pomocí pohodlného rozhraní crowdin.

---

## Registrace

Pokud chcete pomoci s ASF, buď překladem, kontrolou nebo schválením překladů, prosím, zaregistrujte se na naší **[Crowdin project page](https://crowdin.com/project/archisteamfarm)**. Registrace je jednoduchá a naprosto zdarma! Po přihlášení můžete vybrat jazyky, do kterých chcete být přiřazeni, pak přejděte na ASF řetězce a pomozte zbytku komunity s překladem ASF do všech nejpopulárnějších jazyků!

---

### Překlady

Pokud jazyku dle vaší volby stále chybí některé řetězce, můžete je sebrat a začít pracovat na překladu. Pokusili jsme se udělat vše, co je v našich silách, pokud jde o pružnost překladů, Proto mnoho řetězců obsahuje další proměnné, které ASF bude poskytovat během provozu - které jsou obsaženy v závorkách s číslem, jako `{0}`. To vám umožní změnit výchozí formát ASF řetězce, např. přesunutím proměnné poskytované ASF na místo, které vyhovuje vašemu jazyku a vašemu překladu, místo toho, aby byla nucena k přísnému kontextu a formátu. To je důležité zejména v jazycích RTL, jako je například hebrejsk.

Například můžete mít řetězec:

> Máme hry {0} k farmě.

Na základě vašeho jazyka by však tato věta mohla dávat větší smysl:

> Počet partií na farmě je roven {0}.

Nebo:

> {0} je počet her v zemědělství.

Tato flexibilita je poskytována speciálně pro vás, abyste mohli mírně přeformulovat větu ASF tak, aby se vaše jazyky lépe přizpůsobily a přesouvali číslo poskytnuté ASF nebo jiné informace na místě, které se vejde do vašeho překladu (místo toho, aby každá část byla přeložena samostatně). To zlepšuje celkovou kvalitu překladu.

---

### Přezkum

Pokud již byl váš řetězec přeložen někým jiným, můžete pro něj hlasovat. Hlasování umožňuje vybrat si nejlepší variantu překladu, místo toho, aby se držel původního návrhu, zvyšuje to celkovou kvalitu překladu ještě dále. Můžete hlasovat o již dostupných návrzích, nebo navrhnout svůj vlastní překlad, který projde stejným procesem. Nakonec bude vybrán konečný řetězec buď na základě nejhlasovanějšího návrhu, nebo jako výběr korektora vybraného pro tento jazyk, který osobně schvaluje daný překlad (na základě vašich hlasů).

**Nepotřebujete schválení, abyste viděli přeložené řetězce v ASF**. Schválení jednoduše znamená, že někdo, kdo je nám důvěřován, přezkoumal obsah, jako v: vybral si konečnou verzi překladu. Je naprosto hezké mít neschválené překlady založené na komunitě, kde hlasujete pro ty nejlepší. Dokud bude přeloženo, vše je v pořádku! A pokud se domníváte, že současný překlad je špatný, můžete vždy hlasovat pro ten lepší, nebo navrhnout sám sebe.

---

### Potvrzení o čtení

Je dobrý nápad mít konzistentní překlad, i když by potenciálně mohl být osvobozen od komunitní revize/hlasování, jak je vysvětleno výše. Je to hlavně proto, že nesprávné překlady, které nejsou nutně špatné, mohou získat tolik hlasů, že již není možné navrhovat lepší překlad, i když to někdo má.

Pokud máte minulou historii příspěvků na Crowdinu nebo jiné lokalizační platformě/službě, kterou můžeme ověřit a předpokládat důvěryhodnosti, Jsme rádi, že vám umožníme přístup čtečky k danému jazyku, do kterého přispíváte, abyste mohli schválit daný překlad a zajistit jeho konzistenci. Důkaz čtení není snadný úkol, zejména proto, že ASF může být velmi "technický" čas od času a opravdu obtížné přeložit, ale chápeme, že je to často potřebné pro dokonalý překlad. Pokud tedy můžete pomoci při čtení daného jazyka, **[nám dejte vědět](https://crowdin.com/messages/create/13177432/240376)**ale mějte na paměti, že budete muset zálohovat svůj požadavek s minulými lokalizačními příspěvky, které můžeme ověřit (např. . pracuje s ASF lokalizací na Crowdin, nebo s jiným projektem). Můžeme také umožnit pokročilejším uživatelům, aby si vybrali počáteční korekturu, pokud je známe osobně a jsou schopni spolupracovat se zbytkem komunity s cílem lokalizovat ASF v tomto jazyce nejlépe.

Obecná pravidla platí pro potvrzení čtení - nespěchejte, naslouchejte vašim uživatelům, pracovat jako správce projektu, řešit problémy, zajistit, aby jste věci zlepšovali a ne zhoršovali.

---

### Problémy

Pokud máte problém s konkrétním překladem, např. nevíte, jak jej přeložit, schválený překlad je nesprávný, potřebujete konkrétnější kontext, nebo podobně napište komentář pod určitým řetězcem a označte jej [X] Issue.

**Nepoužívejte prosím označení problému, pokud nepotřebujete technické vysvětlení / vysvětlení vývoje nebo správcovskou akci**. Můžete použít komentáře pro diskusi týkající se překladu daného řetězce, ale úkol by měl být použit pouze v případě, že potřebujete další technické vysvětlení nebo správcovskou opravu, a obvykle se to bude týkat někoho, kdo nemluví ani jazykem, do kterého překládáte, takže prosím dodržte angličtinu při psaní komentáře k vydání (abychom pochopili, co je problém).

V současné době existuje 4 podporovaných problémů:
- Obecná otázka - pro všechno, co neodpovídá žádnému problému níže. Obecně by se tomuto typu **nemělo vyhýbat**, jako by váš problém neodpovídal, pak je velmi pravděpodobné, že **není** problém s překladem. Přesto je tato možnost k dispozici pro všechny ostatní případy.
- Aktuální překlad je špatný - toto by mělo být použito **pouze** pokud byl překlad již předem schválen čtečkou, a věříte, že je to špatně, například má typo, nebo máte platný návrh, jak jej zlepšit. Tento typ by nikdy neměl být používán v překladech, které jsou poháněny komunitou (hlasování), jako v tomto případě byste se měli obrátit na uživatele daného překladu a požádat ho o opravu, nebo prostě hlasujte pro lepší překlad, jak je uvedeno v revizi sekce. Odstraníme schválení překladu a upozorníme příslušný čtečku potvrzení jazyka, abychom vzali v úvahu váš komentář a znovu ověřili.
- Nedostatek kontextových informací - toto byste měli použít, pokud si nejste jisti, jakou část aplikace ASF překládáte, jaký je kontext daného řetězce nebo jeho účel. Tento typ by měl být použit pouze pro vývoj aplikace ASF, což znamená, že potřebujete technickou pomoc, protože si nejste jisti, jak byste měli přeložit daný řetězec.
- Chyba ve zdrojovém řetězci - toto by mělo být použito pouze v případě, že se domníváte, že původní (anglický) řetězec je nesprávný. Velmi zřídka, ale ne všichni mluví také v angličtině, takže neváhejte ho použít, pokud máte obecnou představu, jak by to mohlo být vylepšeno. Alternativně platí, že jelikož se to týká výhradně vývoje, můžete pro tento účel použít náš **[GitHub issues](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** , pokud byste chtěli.

---

### Stav překladů

Každý jazyk má dva stupně dokončení - překlad a potvrzení čtení.

Jazyk je považován za **přeložený** , když jeho překlad dosáhne 100%. V tomto bodě má každý lokalizovatelný řetězec používaný ASF správný význam, což je skvělé. Ovšem to neznamená, že zde není žádný prostor pro zlepšení - komunitní hlasování je vždy povoleno a stále můžete navrhnout lepší překlad pro již přeložené části, a také hlasovat pro stávající. Vezměte prosím na vědomí, že plně přeložené jazyky mohou stále klesnout pod 100 %, pokud změníme existující řetězce nebo přidáme nové během vývoje. Pokud chcete dostávat e-mail, můžete nastavit příslušná oznámení crowdinu.

Vybrané jazyky mohou mít vhodné korektory, které potvrzují překlady a schvalují konečné verze. Toto je závěrečná verze po provedení překladu a umožňuje další vylepšení lokalizace.

ASF bude obsahovat jazyk **co nejdříve**, což znamená, že nemusí být schválen, nebo dokonce 100% přeložen. Skutečné řetězce, které budou použity, jsou vždy nejpopulárnější z hlediska hlasování, pokud vybraný korektor nerozhodne jinak (zřídka). Z toho důvodu můžete vidět vaše úsilí v další verzi ASF - naše automatizační systémy spojují překlady z Crowdin zpět do repozitáře ASF.

---

## Chybějící jazyky

Ve výchozím nastavení má projekt ASF otevřený překlad pouze pro 30 nejlepších jazyků, které se mluví po celém světě. Pokud chcete přidat další (nebo lokální vytáčení již k dispozici), prosím **[dejte nám vědět](https://crowdin.com/messages/create/13177432/240376)** a my ji přidáme ASAP. Nechceme otevírat několik stovek různých jazyků, pokud je nikdo nechce přeložit, a to je důvod, proč jsme je omezili na nějaké spravedlivé číslo. Prosím, neváhejte nás kontaktovat, pokud chcete přeložit jiný jazyk, je pro nás velmi snadné přidat jiný. Než se rozhodnete s námi kontaktovat, ujistěte se, že máte skutečné odhodlání a odhodlání přeložit ASF do svého jazyka.

For a complete list of all available languages that ASF can be translated to, **[click here](https://developer.crowdin.com/language-codes)**.

---

## Pluralizace

Každý jazyk má svá vlastní pravidla, pokud jde o pluralizaci. Tato pravidla lze nalézt v **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** , která upřesňuje jejich počet a přesné jazykové podmínky.

Děláme vše, co je v našich silách, abychom vám nabídli flexibilní lokalizaci, a co nejdéle to bude zahrnovat také pluralitní pravidla. Například dnes přeložíme následující řetězec do polského:

> Vydáno před {PLURAL:n|{n} měsícem|{n} měsíci}

`PLURAL` klíčové slovo je zde zpracováno zvláštním způsobem, protože umožňuje zahrnout všechny formy plurálu, které váš jazyk podporuje. Pokud se podíváte na CLDR, uvidíte, že v angličtině jsou pouze 2 kardinální formuláře - "jedna" a "jiné". A jak vidíte výše, máme obě definované - `{n} měsíc` a `{n} měsíce`.

Náš polský jazyk však ve skutečnosti zahrnuje čtyři z nich - "jeden", "několika", "mnoho" a "druhé". To znamená, že bychom je měli definovat pro dokončení. Naše lokalizační nástroje jsou již dostatečně chytré na to, aby si vybraly vhodný pluralitní formulář na základě jazykových pravidel, Proto je v překladu musíte definovat pouze všechny z nich:

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

Tímto způsobem jsme definovali všechny 4 pluralitní formuláře pro náš polský jazyk a protože naše lokalizační knihovna již zná přesná pravidla, bude správně používat správný formulář pro zadané `{n}` číslo.

Není povinné definovat všechny formy plurálu používané vaším jazykem. Pokud chybí, naše lokalizační knihovna bude používat poslední definovaný formulář na jejím místě. Je dobrý nápad definovat všechny formy plurálu používané vaším jazykem, ale v některých případech by zbývající formy plurálu mohly být stejné jako poslední, a v takovém případě není nutné je opakovat. V našem příkladu to bylo povinné, protože "jiné" forma v polštině je "miesia<unk> ca", a ne "miesie<unk> cy" jako v "mnoho".

---

## Wiki

Naše platforma crowdin vám také umožňuje lokalizovat i samotnou wiki. Jedná se o velmi mocný nástroj, protože vám umožňuje vytvořit celou dokumentaci ASF ve vašem rodném jazyce, účinně vyřešit poslední problém, pokud jde o lokalizaci aplikace ASF. Spolu s překladem programu a všech jeho částí je lokalizace kompletní.

Wiki je v tomto ohledu trochu zvláštní, protože je to online pomoc, kde nepotřebujete příliš dlouho držet původní větu. To znamená, že chcete být co nejpřirozenější s vaším jazykem, a dodat původní význam a pomoc - nemusí nutně držet originální řetězec, použitá slova a skutečné interpunkce. Nebojte se přepsat řetězec do něčeho mnohem přirozenějšího pro váš jazyk, pokud budete mít obecný směr a pomoc zahrnutou do věty.

---

### Globální odkazy

Naše platforma crowdin vám také umožňuje přizpůsobit původní text tak, aby odkazoval na nová (lokalizovaná) místa.

ASF obsahuje odkazy na téměř každé stránce pro snazší navigaci a také postranní panel vpravo. Úžasným faktem je, že můžete upravit všechny tyto prvky, "opravit" odkazy, které ukazují na správné lokalizované stránky pro váš jazyk. Je třeba, aby to bylo trochu opatrné, ale je to možné.

Například ASF **[domovská stránka](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)** obsahuje text jako:

> Pokud jste nový uživatel, doporučujeme začít s **[nastavením](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** průvodce.

Který je původně napsán jako:

```markdown
Pokud jste nový uživatel, doporučujeme začít průvodcem **[setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)**.
```

Na davu byste nejprve měli udělat nastavení editoru a zajistit, aby HTML tagy byly nastaveny na "Zobrazit" pro vás. To je velmi důležité, pokud se rozhodnete lokalizovat wiki.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Nyní, během překladu na crowdin, v závislosti na formátování, uvidíte v textu odkazy ASF buď jako:

* Řetězec k přeložení společně s HTML tagy (většina řetězců, kde pouze část věty je odkaz)
* Samostatný řetězec pro překlad, s odkazem obsaženým v `Skryté texty` -> `Odkaz` (vzácný) kde celý řetězec je odkaz, nejčastější v postranním panelu - ty vyžadují přístup korektoru k překladu, smutně)

V našem příkladu je to první případ (protože pouze "nastavení" je odkaz), takže v crowdin uvidíme jako:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Bez ohledu na případ, nejprve byste měli zkopírovat zdrojový řetězec a přeložit jej jako obvykle, ponecháte celý HTML (pokud je přítomen) nedotčený. To by byl příklad překladu pro polský jazyk:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Nyní, pokud je odkaz obecným odkazem, který odkazuje mimo wiki (např. na nejnovější verzi aplikace ASF), můžete ji opustit, protože ji nechcete upravovat. Můžete ji uložit a posunout se kupředu.

However, if the link **does** point further inside the wiki, like the one above, you can actually correct it to point to new (localized) location. Děláte to opatrným přidáním `-locale` na cílovou adresu URL v `<a>` tagu jako níže:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Buďte velmi opatrní a zajistěte, že vaše URL skutečně existuje, protože pokud uděláte chybu, tento odkaz přestane fungovat. Pokud jste uspěli, máte nyní plně funkční překlad s odkazem, který ukazuje na přeloženou stránku `Setting-up-pl-PL`.

Výše uvedené kroky správně přeloží HTML zpět do markdown:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

A konečně do wiki textu:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

Když není přítomen žádný HTML (druhý případ), je to ještě jednodušší, protože můžete jednoduše přejít do `Skryté texty` -> `Odkaz na adresy`.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

Odtud můžete snadno opravit odkaz na novou polohu, aniž byste se vůbec obtěžovali HTML:

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Místní odkazy

Po celé Wiki najdete také lokální odkazy, které odkazují na konkrétní část dokumentu. Tyto odkazy zahrnují znak `#` a označují webový prohlížeč, že by se měl přesunout k této části dokumentu.

Nyní se jedná o zvláštní případy, protože tyto odkazy jsou založeny na názvech oddílů aktuálního dokumentu. Zatímco pro URL máme obecnou úmluvu o přidání `-locale` do URL, a to funguje všude, jména sekcí budou přeložena vámi a dalšími lidmi, takže je třeba zajistit, aby odpovídala na správné umístění.

Například najdete odkaz `#introduction` v naší **[konfiguraci](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#introduction)**:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Protože se chystáme přeložit slovo "Úvod" do "Wprowadzenie" pro náš polský jazyk, budeme muset tento odkaz opravit, protože to přestane fungovat v okamžiku, kdy to uděláme.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

Tímto způsobem bude místní odkaz i nadále fungovat, protože nyní bude odkazovat na název sekce, kterou používáme. Můžete opravovat odkazy uvnitř HTML tagů přesně stejným způsobem.

---

### Bloky kódu

Buďte velmi opatrní, když přeložíte věty s `<code></code>` blokuje uvnitř. Blok kódů označuje pevné ASF názvy nebo výrazy, které by neměly být přeloženy. Například:

> To je užitečné zejména v případě, že máte spoustu klíčů k vyplacení a máte zaručeno, že před tím, než budete hotovi s celou dávkou, dosáhnete stavu <code>RateLimited</code>.

Jak vidíte, slovo `RateLimited` je zde uvnitř kódu a označuje interní ASF kód, který by neměl být přeložen. Stejně tak byste neměli překládat jiné bloky kódu, například názvy vlastností konfigurace (např. `TradingPreferences`), enum členové (např. . `Stabilní` a `PreRelease` možnosti `UpdateChannel`) a podobně.

Avšak jen proto, že by tato slova neměla být přeložena, neznamená, že nemůžete přidat vhodný překlad vedle nich, například v závorkách.

> Ta funkcja jest wyjątkowo użyteczna w przypadku aktywacji dużej ilości kluczy i gwarancji napotkania statusu <code>RateLimited</code> (zbyt częstej aktywacji) przed ukończeniem całej partii.

Jak vidíte výše, přidali jsme "zbyt cze<unk> stej aktywacji", doslova "příliš často aktivace" vedle `RateLimited` , aby bylo možné tento status přeložit přátelským způsobem, zatímco současně zachovává původní ASF, což znamená, že uživatel může vidět během používání programu. Stejně tak můžete přeložit/vysvětlit jiné, podobné případy různých slov a vět.

Pokud se domníváte, že do bloku kódu je zahrnuto něco nevhodného, nebo že existuje text, který není v bloku kódu, ale měl by být uvnitř bloku, Neváhejte se zeptat na náš crowdin vytvořením vhodného **[úkolu](#issues)**. To také slouží jako praktický příklad použití lokálního odkazu.

---

## Síň slávy

Rádi bychom ukázali naši věčnou vděčnost lidem, kteří strávili značnou část svého času a ochoty zlepšit lokalizaci ASF. Jejich úsilí je neuvěřitelné a můžete si vychutnat kompletní překlady, včetně wiki, většinou díky nim. jako žeton ocenění, všem zde uvedeným lidem je nabízen volný přístup do funkce **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** na požadavku **[](https://crowdin.com/messages/create/13177432/240376)**.

| Přispěvatel                                                | Jazyky              |
| ---------------------------------------------------------- | ------------------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, Španělština |
| **[Mrtvá_Sam](https://crowdin.com/profile/Dead_Sam)**      | Portugalština (BR)  |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | Čínština (CN)       |
| **[DragonTaki](https://crowdin.com/profile/dragontaki)**   | Čínština (TW)       |
| **[Maltleak](https://crowdin.com/profile/littlefreak)**    | Němčina             |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | Ruský, ukrajinský   |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT, němčina     |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | Čínština (HK)       |

Děkujeme vám všem za zlepšení naší kvality lokalizace ASF!