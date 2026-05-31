# Продуктивність

Основна мета ASF це якомога ефективніше для фермерства, базуючись на двох типах даних, з якими він може працювати - невеликих наборах наданих користувачем які не можуть ASF здогадатися/перевірити самостійно, і великий набір даних, які можуть автоматично перевірятися ASF.

У автоматичному режимі ASF не дозволяє обрати ігри з якими слід фармити, ані це не можна змінити алгоритм фармінгу карт. **ASF knows better than you what it should do and what decisions it should make in order to farm as fast as possible**. Ваша мета - установити властивості конфігурації належним чином, оскільки ASF не може його самостійно здогадатися, що це зробили для нього.

---

Деякий час назад Valve змінив алгоритм для випадаючих карток. From that point onwards, we can categorize steam accounts by two categories: those **with** card drops restricted, and those **without**. Єдина відмінність між цими двома типами полягає в тому, що облікові записи з обмеженими картами не можуть отримати жодної карти від даної гри, доки вони не зібрали гру принаймні `X` годин. It seems that older accounts that never asked for refund have **unrestricted card drops**, while new accounts and those who did ask for refund have **restricted card drops**. Однак це лише теорія, і не повинна приймати як правило. That's why there is **no obvious answer**, and ASF relies on **you** telling it which case is appropriate for your account.

---

ASF наразі має два алгоритми для фермерства:

**`Simple`** algorithm works best for accounts that have unrestricted card drops. Це основний алгоритм, який використовує ASF. Бот знаходить ігри на фермі, і бродить їх один за одним до тих пір, поки всі карти не будуть зняті. Це тому, що швидкість відображення карт при землеробстві більш, ніж одна гра близька до нуля і повністю неефективна.

**`Complex`** is new algorithm that has been implemented to help restricted accounts to maximize their profits as well. ASF спочатку використає стандартний **</code>Простого** алгоритму для всіх ігор, які пройшли `HoursUntilCardDrops` годин ігрового часу, потім якщо немає ігор з >= `HoursUntilCardDrops` годин залишилися він буде обробляти усі ігри (до `32` обмеження) з < `Годинних карт випадає` години, залишилися одночасно, поки хтось із них не вдаряє `HoursUntilcardps` годинної позначки, потім ASF продовжить цикл з початку (використовуйте **`Простого`** на цій грі, повернутися до одночасно з < `HoursUntilps` і т.д.). В цьому випадку ми можемо використовувати багаторазове землеробство ігор для перекачування годин ігор, які потрібні для фермерства, щоб бути в першу чергу. Keep in mind that during farming hours, ASF **does not** farm cards, so it also won't check for any card drops during that period (for reasons stated above).

В даний час ASF вибирає картки, які обробляють алгоритм, засновані на `HoursUntilCardDrops` параметр (який встановлюється параметром **ви**). If `HoursUntilCardDrops` is set to `0`, **`Simple`** algorithm will be used, otherwise, **`Complex`** algorithm will be used instead - configured to bump playtime in all games to given amount of hours before farming them for card drops.

---

### **Немає очевидної відповіді, який алгоритм краще для вас**.

Це одна з причин, чому ви не обираєте алгоритм фармування, натомість ви кажете що ASF має обмежені краплі чи ні. If account has non-restricted drops, **`Simple`** algorithm will **work better** on that account, as we won't be wasting time on bringing all games to `X` hours - cards drop ratio is close to 0% when farming multiple games. On the other hand, if your account has card drops restricted, **`Complex`** algorithm will be better for you, as there's no point in farming solo if game didn't reach `HoursUntilCardDrops` hours yet - so we'll farm **playtime** first, **then** cards in solo mode.

Don't blindly set `HoursUntilCardDrops` only because somebody told you to - do tests, compare results, and based on data you get, decide which option should be better for you. Якщо ви докладете мінімальних зусиль, ви впевнені, що ASF працює з максимальною ефективністю для вашого облікового запису, і це ймовірно те, що ви хочете, беручи до уваги, що ви читаєте цю сторінку вікі прямо зараз. Якщо було вирішено, яке працюватиме для всіх, вам не знадобиться вибір. Тому ASF вирішить себе.

---

### Який найкращий спосіб з'ясувати, якщо ваш обліковий запис обмежений?

Переконайтесь, що у вас є деякі ігри з **з ігровим часом запису** на ферму, бажано 5 + , і запустіть ASF з `HoursUntilCardDrops` з `0`. Це було б гарною ідеєю, якби ви нічого не грали в період фарму для більш точних результатів (краще було б запустити ASF протягом вечі). Нехай ASF обробить ці 5 ігор, а після цього подивіться журнал для результатів.

ASF чітко вказує, коли у гри була відкинута картка. Вас цікавить падіння якнайшвидша картка, досягнута ASF. Наприклад, якщо ваш обліковий запис необмежений, то падіння перших карток повинно відбуватися приблизно через 30 хвилин після початку ведення фермерства. If you notice **at least one** game that did drop card in those initial 30 minutes, then this is an indicator that your account is **not** restricted and should use `HoursUntilCardDrops` of `0`.

On the other hand, if you notice that **every** game is taking at least `X` amount of hours before it drops its first card, then this is an indicator to you what you should set `HoursUntilCardDrops` to. Majority (if not all) of restricted users require at least `3` hours of playtime for cards to drop, and this is also the default value for `HoursUntilCardDrops` setting.

Remember that games can have different drop rate, this is why you should test if your theory is right with **at least** 3 games, preferably 5+ to ensure that you're not running into false results by a coincidence. A card drop of one game in less than an hour is a confirmation that your account **is not** restricted and can use `HoursUntilCardDrops` of `0`, but for confirming that your account **is** restricted, you need at least several games that are not dropping cards until you hit a fixed mark.

It's important to note that in the past `HoursUntilCardDrops` was only `0` or `2`, and this is why ASF had a single `CardDropsRestricted` property that allowed to switch between those two values. With recent changes we noticed that not only majority of users require `3` hours in place of previous `2` now, but also that `HoursUntilCardDrops` is now dynamic and can hit any value on per-account basis.

Зрештою, до вас вирішить рішення.

І щоб це ще гірше - у мене були справи, коли люди перейшли від обмежень до необмежених стану і навпаки - або через помилки Steam (о, так, у нас є багато таких), або через деякі коригування логіки Valve. Тож навіть якщо ви підтвердили що ваш рахунок обмежено (або ні), не вірять, що так і залишиться - для того, щоб переходити від необмеженого до обмеження, достатньо для того, щоб попросити про повернення. Якщо ви відчуваєте, що встановлена раніше значення більше не підходять, ви завжди можете перевірити це повторно і оновити відповідним чином.

---

By default, ASF assumes that `HoursUntilCardDrops` is `3`, as the negative effect of setting this to `3` when it should be less is smaller than done the other way. This is because, in the worst possible case, we'll waste `3` hours of farming per `32` games, compared to wasting `3` hours of farming per every single game if `HoursUntilCardDrops` was set to `0` by default. Однак, ви маєте все ще налаштовувати цю змінну, щоб відповідати вашому обліковому запису з максимальною ефективністю, оскільки це лише сліпий здогадка, заснована на потенційних списках і більшості користувачів (тому ми намагаємося вибрати "менше" за замовчуванням).

В той момент, на два вище алгоритми достатньо для всіх можливих сценаріїв облікового запису, щоб фермерити якомога ефективніше, тому не заплановано додавати будь-які інші.

It's nice to note that ASF also includes manual farming mode that can be activated by `play` command. You can read more about it in **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

## Парові згори

Алгоритм видалення карток не завжди працює належним чином, і цілком можливо для різних зігріваючих пар наприклад дані карти про обмежені облікові записи, карти потрапляють на закриття/перемикання гри, карток не випадає взагалі, коли грає гра, а також .

Цей розділ головним чином для людей, які запитують себе: чому ASF не робить **X**, такі як швидкі перемикання ігор на фермерські карти швидше.

What is a **Steam glitch** - a specific action triggering **undefined** behaviour, which is **not intended, undocumented, and considered as a logic flaw**. Це **ненадійне визначення**, це означає, що його не можна відтворювати достовірно з допомогою чистого тестового середовища, і, отже, закодовані, не вдаючись до хаків, які повинні здогадуватися, коли відбувається глюка і як боротися з нею / зловживають. Зазвичай він тимчасовий, поки розробникам не вдається виправити логічні недоліки, хоча деякі помилки можуть бути відзначені протягом дуже тривалого періоду часу.

A good example of what is considered as a **Steam glitch** is not that uncommon situation of dropping a card when game is being closed, which can be abused to some degree with idle master's game skip function.

- **Невизначена поведінка** - ви не можете сказати, якщо буде менше 0 або 1 карти, коли ви запускаєте залозу.
- **Не призначено** - на основі минулих вражень та поведінки мережі Steam, що не призводить до такої ж поведінки під час надсилання одного запиту.
- **Undocumented** - it's clearly documented on Steam website how cards are being obtained, and **in every single place** it's clearly stated that it's obtained through **playing**, NOT closing games, getting achievements, games switching or launching 32 games concurrently.
- **Considered as a logic flaw** - closing game(s) or switching them should have no outcome on cards being dropped which are clearly stated to be obtained through **gaining playtime**.
- **Unreliable by definition, can't be reproduced reliably** - it doesn't work for everybody, and even if it did work for you once, it could no longer work for the second time.

Now once we realized what Steam glitch is, and the fact that cards being dropped when game gets closed **is** one, we can move on to the second point - **ASF is not abusing Steam network in any way by definition, and it's doing its best to comply with Steam ToS, its protocols and what is generally accepted**. Spamming Steam network with constant game opening/closing requests can be considered a **[DoS attack](https://en.wikipedia.org/wiki/Denial-of-service_attack)** and **directly violates [Steam Online Conduct](https://store.steampowered.com/online_conduct/?l=english)**.

> Як підписник Steam, ви погоджуєтеся дотримуватися наступних правил поведінки.
> 
> Ви не будете:
> 
> Інститут атак на паровий сервер або порушення Steam.

Не має значення, чи можете ви викликати Steam glitch з іншими програмами (наприклад, IM), і не має значення чи ви з нами погоджуєтеся і вважатимете таку поведінку як нападник DoS, або ні, це залежить від Valve судити про це, але якщо ми вирішимо це як експлуатацію/зловживати непередбачуваною поведінкою через надмірні мережеві запити, тоді ви можете бути досить впевнені, що Valve матимуть подібний погляд на це.

ASF is **never** going to take advantage of Steam exploits, abuses, hacks or any other activity that we see as **illegal or unwanted** according to Steam ToS, Steam Online Conduct or any other trusted source that could indicate that ASF activity is unwanted by Steam network, as stated in **[contributing](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)** section.

If you want at all cost to risk your Steam account for farming a few cent cards faster than usual, then sadly ASF will never offer something like this in automatic mode, although you still have `play` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** that can be used as a tool for doing whatever you want in terms of Steam network interaction. Ми не рекомендуємо скористатись паровими збоями та використовувати їх для вашого власного вигоди — не тільки для ASF, але з будь-яким іншим інструментом також. Однак, зрештою це твій обліковий запис, і ваш вибір що ви хочете з цим робити - майте на увазі, що ми попередили вас.