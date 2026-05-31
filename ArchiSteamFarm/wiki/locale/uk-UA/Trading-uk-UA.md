# Обміни

ASF включає підтримку неінтерактивних (офлайн) обмінів Steam. Як отримання (прийняття/відхилення) так і відправлення обмінів працюють не вимагаючи додаткового налаштування, проте, вочевидь, вимагають обліковий запис Steam без обмежень (такий, на якому витрачено більше ніж 5$ в еквіваленті). Тільки обмежена функціональність торгів доступна для обмежених облікових записів.

---

## Логіка

First of all, it's possible to disable **all** incoming trade offers, by using `DisableIncomingTradesParsing` flag in `BotBehaviour`. Використання цього, якщо мається назву відключить усі функціональні можливості, пов'язані з обробкою торгів, яка включає в себе нижче типову логіку, а також всі додаткові функції, які можуть залежати від реагування на вхідну торгову пропозицію. Оскільки настройки за замовчуванням вже не є внутрішніми вам варто розглянути можливість використання цієї опції лише у випадку, якщо у вас немає абсолютно ніякого наміру робити що-небудь пов'язані з вхідними угодами.

Пояснює логіку, коли ввімкнено розбір вхідних пропозицій, що є опцією за замовчуванням.

ASF завжди буде приймати всі пропозиції обмінів, незалежно від предметів, відправлених від користувача з доступом `Master` (або вище) до бота. Це дозволяє не тільки легко збирати карти steam, створені екземпляром бота, але і дозволяє легко керувати предметами Steam, які бот зберігає в інвентарі, в тому числі з інших ігор (таких як CS:GO).

ASF відхилить пропозицію обміну, незалежно від вмісту, від будь-якого користувача (non-master), який знаходиться в чорному списку торгового модуля. Чорний список зберігається в стандартній `BotName.db` базі даних, і ним можна керувати через `tb`, `tbadd` і `tbrm` **[команди](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Це повинно працювати як альтернатива стандартному користувацькому блоку, який пропонує Steam - використовуйте з обережністю.

ASF буде приймати усі `loot`-like trades, які надсилаються по ботам, якщо `DontAcceptBotTrades` не вказано в `TradingPreferences`. Одним словом, за замовчуванням `TradingPreferences` `None` не призведе до того, що ASF автоматично прийме угоди від користувача з `майстром` доступ до бота (пояснюється вище), як і усі пожертвування трейдеру від інших ботів, які беруть участь у процесі ASF.

When you enable `AcceptDonations` in your `TradingPreferences`, ASF will also accept any donation trade - a trade in which bot account is not losing any items. Цей параметр впливає тільки на облікові записи не бота, тому що на боти впливають `DontAcceptBotTrades`. `Прийнятні пожертвування` дозволяють вам легко приймати пожертвування від інших людей, а також ботів, які не беруть участь у процесі ASF.

It's nice to note that `AcceptDonations` doesn't require **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, as there is no confirmation needed if we're not losing any items.

Ви також можете налаштувати можливості торгівлі ASF шляхом модифікації `TradingPreferences` відповідно. Одна з основних функцій `TradingPreferences` це `SteamTradeMatcher` опція, яка змушує ASF використовувати вбудовану логіку для прийняття угод, що допоможе вам завершити відсутні значки, особливо корисно у співпраці з публічним списком **[SteamTradeMatcher](https://www.steamtradematcher.com)**, але також може працювати без нього. Він далі описаний нижче.

---

## `SteamTradeМатчер`

When `SteamTradeMatcher` is active, ASF will use quite complex algorithm of checking if trade passes STM rules and is at least neutral towards us. Справжня логіка:

- Відхилити угоду, якщо ми втрачаємо не лише типи предметів, зазначені в нашій `Матеріальні типи`.
- Відхилити угоду, якщо ми не отримуємо принаймні однакову кількість предметів на основі для кожної гри, основи для кожного типу і для відсоткової точки.
- Відхилити торгівлю, якщо користувач просить спеціальні парові картки літнього / зимової продажу, і у неї є торгова картка.
- Reject the trade if trade hold duration exceeds `MaxTradeHoldDuration` global config property.
- Reject the trade if we don't have `MatchEverything` set, and it's worse than neutral for us.
- Приймайте торгівлю, якщо ми не відкидаємо її через жодні з точок вище.

Приємно зазначити, що ASF також підтримує переплату - логіка працюватиме належним чином при додаванні чогось додаткового в торгівлю, поки дотримуються всі вищезгадані умови.

Перші 4 прогнози відхилення повинні бути очевидними для всіх. Остаточне положення включає в себе логіку, яка перевіряє поточний стан нашого інвентарю і вирішує, яким є статус торгівлі.

- Trade is **good** if our progress towards set completion advances. Приклад: A (раніше) -> B (після)
- Trade is **neutral** if our progress towards set completion stays in-tact. Приклад: A (раніше) -> C (після)
- Trade is **bad** if our progress towards set completion declines. Приклад: A (раніше) -> A (після)

STM працює лише на хороших угодах, а це означає, що користувач використовує STM для харчових оновлень, завжди повинен запропонувати лише хороші угоди для нас. Але ASF ліберальний, і він також приймає нейтральні торги, тому що в цих торгах ми нічого не втрачаємо, тому немає причин їх зниження. Це особливо корисно для ваших друзів, оскільки вони можуть змінювати ваші надмірні картки взагалі без використання STM, Поки ви не втрачаєте жодного встановленого прогресу.

За замовчанням ASF буде відхиляти погані обміни - це майже завжди те, що ви хочете, як користувач. However, you can optionally enable `MatchEverything` in your `TradingPreferences` in order to make ASF accept all dupe trades, including **bad ones**. This is useful only if you want to run a 1:1 trade bot under your account, as you understand that **ASF will no longer help you progress towards badge completion, and make you prone to losing entire finished set for N dupes of the same card**. If you want to intentionally run a trade bot that is **never** supposed to finish any set, and should offer its whole inventory to every interested user, then you can enable that option.

Незалежно від ваших обраних `TradingPreferences`, торгівля відхилена ASF не означає що ви не можете прийняти це самостійно. Якщо ви зберегли значення `BotBehaviour`, в якому не включено `RejectInvalidTrades`ASF просто ігнорує ці угоди - що дозволить вам вирішити себе чи вам це зацікавиться ними, чи ні. Same goes for trades with items outside of `MatchableTypes`, as well as everything else - the module is supposed to help you automate STM trades, not decide what is a good trade and what is not. Тільки виключення з цього правила полягає в тому, що при розмові про користувачів, які ви в чорному списку з модуля торгівлі на основі команди `tbadd` - угоди від цих користувачів відразу ж відхиляються, незалежно від налаштувань `BotBehaviour`.

It's highly recommended to use **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** when you enable this option, as this function loses its whole potential if you decide to manually confirm every trade. `SteamTradeMatcher` will work properly even without ability to confirm trades, but it can generate backlog of confirmations if you're not accepting them in time.