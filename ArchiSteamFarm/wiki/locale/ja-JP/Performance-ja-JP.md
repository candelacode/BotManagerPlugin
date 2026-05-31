# パフォーマンス

ASFの主な目的は、可能な限り効果的に栽培することです。 ASFが独自に推測/確認することは不可能である、2種類のデータに基づいて操作することができます。 そしてASFによって自動的にチェックされるデータの大きいセット。

自動モードでは、ASFはあなたが養殖すべきゲームを選択することはできません、どちらもあなたはカード農業アルゴリズムを変更することができません。 **ASFはあなたよりも良いことを知っており、** をできるだけ早く養殖するためにどのような決断をすべきかを知っています。 あなたの目的は、ASFがそれらを推測することができないため、設定プロパティを適切に設定することです。

---

しばらく前に、Valveはカードドロップのアルゴリズムを変更しました。 From that point onwards, we can categorize steam accounts by two categories: those **with** card drops restricted, and those **without**. 唯一の違いは、カードドロップが制限されているアカウントでは、少なくとも `X` 時間ゲームをプレイするまで、特定のゲームからカードを取得できないという事実です。 It seems that older accounts that never asked for refund have **unrestricted card drops**, while new accounts and those who did ask for refund have **restricted card drops**. ただし、これはあくまで理論であり、原則とすべきではない。 That's why there is **no obvious answer**, and ASF relies on **you** telling it which case is appropriate for your account.

---

ASFには現在、2つの農業アルゴリズムが含まれています:

**`Simple`** アルゴリズムは、無制限のカードドロップのアカウントに最適です。 これは、ASFが使用する主要なアルゴリズムです。 Botは農場にゲームを見つけて、すべてのカードがドロップされるまで1つずつ農場を耕します。 これは、1つ以上のゲームを作るときにカードがゼロに近く、完全に効果がないためです。

**`Complex`** は、制限された口座が利益を最大化できるようにするために実装された新しいアルゴリズムです。 ASF will firstly use standard **`Simple`** algorithm on all games that passed `HoursUntilCardDrops` hours of playtime, then, if no games with >= `HoursUntilCardDrops` hours are left, it will farm all games (up to `32` limit) with < `HoursUntilCardDrops` hours left simultaneously, until any of them hits `HoursUntilCardDrops` hours mark, then ASF will continue the loop from beginning (use **`Simple`** on that game, return to simultaneous on < `HoursUntilCardDrops` and so on). 私たちは、この場合、私たちが最初に適切な値にファームする必要があるゲームの時間をバンプに複数のゲーム農業を使用することができます. Keep in mind that during farming hours, ASF **does not** farm cards, so it also won't check for any card drops during that period (for reasons stated above).

現在、ASFは純粋に `HoursUntilCarddrops` config property (これは **you** に基づいて養殖カードアルゴリズムを選択しています)。 If `HoursUntilCardDrops` is set to `0`, **`Simple`** algorithm will be used, otherwise, **`Complex`** algorithm will be used instead - configured to bump playtime in all games to given amount of hours before farming them for card drops.

---

### **** の方が良いアルゴリズムは明らかではありません。

これが、カード養殖アルゴリズムを選択しない理由の1つです。代わりに、アカウントがドロップを制限しているかどうかをASFに伝えます。 If account has non-restricted drops, **`Simple`** algorithm will **work better** on that account, as we won't be wasting time on bringing all games to `X` hours - cards drop ratio is close to 0% when farming multiple games. On the other hand, if your account has card drops restricted, **`Complex`** algorithm will be better for you, as there's no point in farming solo if game didn't reach `HoursUntilCardDrops` hours yet - so we'll farm **playtime** first, **then** cards in solo mode.

盲目的に `HoursUntilCarddrops` を設定しないでください。 結果を比較して得られたデータに基づいて どちらの方がいいか決めてください 最小限の労力を費やした場合、ASFがあなたのアカウントの可能な限り最大限の効率で動作していることを確認します。 今あなたがこのwikiページを読んでいることを考えると 皆のために働く解決策があれば、あなたは選択肢を与えられない- ASFはそれ自身を決定する。

---

### アカウントが制限されているかどうかを確認するための最善の方法は何ですか?

Make sure you have some games with **no playtime recorded** to farm, preferably 5+, and run ASF with `HoursUntilCardDrops` of `0`. あなたがより正確な結果を得るために農業期間中に何も再生しなかった場合、それは良いアイデアです(夜の間にASFを実行するのが最善です)。 ASFはこれらの5つのゲームをファームし、その後、結果をチェックアウトしてください。

ASFは、特定のゲームのカードがドロップされたときに明確に述べています。 あなたはASFによって達成された最速のカードドロップに興味があります。 たとえば、アカウントが制限されていない場合、農業を始めてから約30分後に最初のカードドロップが発生するはずです。 If you notice **at least one** game that did drop card in those initial 30 minutes, then this is an indicator that your account is **not** restricted and should use `HoursUntilCardDrops` of `0`.

On the other hand, if you notice that **every** game is taking at least `X` amount of hours before it drops its first card, then this is an indicator to you what you should set `HoursUntilCardDrops` to. Majority (if not all) of restricted users require at least `3` hours of playtime for cards to drop, and this is also the default value for `HoursUntilCardDrops` setting.

ゲームは異なるドロップレートを持つことができることを覚えておいてください これがあなたの理論が **少なくとも** 3ゲームで正しいかどうかをテストする理由です。 好ましくは、偶然の一致によって誤った結果に遭遇していないことを確認するために5+。 A card drop of one game in less than an hour is a confirmation that your account **is not** restricted and can use `HoursUntilCardDrops` of `0`, but for confirming that your account **is** restricted, you need at least several games that are not dropping cards until you hit a fixed mark.

It's important to note that in the past `HoursUntilCardDrops` was only `0` or `2`, and this is why ASF had a single `CardDropsRestricted` property that allowed to switch between those two values. With recent changes we noticed that not only majority of users require `3` hours in place of previous `2` now, but also that `HoursUntilCardDrops` is now dynamic and can hit any value on per-account basis.

最終的には、もちろん、決定はあなた次第です。

そしてさらに悪化させるために - 人々が制限されていない状態とその逆に切り替えたときに私はケースを経験しました - スチームバグのいずれか (ああ、はい、そうです。 我々はそれらの多くを持っている)、またはバルブによるいくつかの論理調整のために。 そのため、アカウントが制限されている(または制限されていない)ことを確認した場合でも、 それはそのように滞在することを信じてはいけません - 無制限から制限に切り替えるためには払い戻しを求めるのに十分です。 以前に設定した値がもはや適切ではないと感じる場合は、いつでも再テストを行い、それに応じて更新することができます。

---

By default, ASF assumes that `HoursUntilCardDrops` is `3`, as the negative effect of setting this to `3` when it should be less is smaller than done the other way. This is because, in the worst possible case, we'll waste `3` hours of farming per `32` games, compared to wasting `3` hours of farming per every single game if `HoursUntilCardDrops` was set to `0` by default. ただし、最大限の効率のためにアカウントと一致するようにこの変数を調整する必要があります。 これは潜在的な欠点と大多数のユーザーに基づいた盲目の推測にすぎないため(デフォルトでは「より悪」を選択しようとしています)。

現時点では、上記の2つのアルゴリズムは、現在考えられるすべてのアカウントシナリオに十分です。 できるだけ効果的に養殖するために他の養殖を追加する予定はありません

ASFには、 `play` コマンドで有効にできる手動農業モードも含まれていることに注意してください。 詳細については、 **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** をご覧ください。

---

## スチームグリッチ

Cards drop algorithm doesn't always work the way it should, and it entreally possible for various Steam griches to happen. 制限されたアカウントにカードがドロップされるなど、ゲームを閉じたり切り替えたりする際にカードがドロップされます ゲームが行われている時には全く落ちないカードも同様です

このセクションは、主にASFが **X**を行わない理由を疑問に思っている人のためのものです。 例えばゲームをより早く農場に切り替えるとか

What is a **Steam glitch** - a specific action triggering **undefined** behaviour, which is **not intended, undocumented, and considered as a logic flaw**. **は定義**によって信頼性が低く、クリーンなテスト環境では確実に再現できないことを意味します。 したがって、故に、グリッチが起こったときに推測されるハックに頼らずにコード化され、それと戦う方法/それを乱用します。 通常は、開発者がロジックの欠陥を修正するまで一時的ですが、いくつかの不具合は非常に長い期間気付かれない可能性があります。

**Steamの不具合** の良い例は、ゲームが閉じられているときにカードをドロップするという珍しい状況ではありません。 マスターのゲームスキップ機能である程度乱用されることがあります

- **未定義の動作** - グリッチをトリガーしたときに 0 または 1 枚のカードがドロップされているかどうかを判断できません。
- **** - 単一のリクエストを送信するときに同じ動作をしない過去の経験とSteamネットワークの動作に基づいて意図されていません。
- **Undocumented** - it's clearly documented on Steam website how cards are being obtained, and **in every single place** it's clearly stated that it's obtained through **playing**, NOT closing games, getting achievements, games switching or launching 32 games concurrently.
- **Considered as a logic flaw** - closing game(s) or switching them should have no outcome on cards being dropped which are clearly stated to be obtained through **gaining playtime**.
- **Unreliable by definition, can't be reproduced reliably** - it doesn't work for everybody, and even if it did work for you once, it could no longer work for the second time.

Now once we realized what Steam glitch is, and the fact that cards being dropped when game gets closed **is** one, we can move on to the second point - **ASF is not abusing Steam network in any way by definition, and it's doing its best to comply with Steam ToS, its protocols and what is generally accepted**. 一定のゲーム開始/終了リクエストでスチームネットワークをスパムすることは、 **[DoS攻撃](https://en.wikipedia.org/wiki/Denial-of-service_attack)** と **が [Steam オンライン行動](https://store.steampowered.com/online_conduct/?l=english)** に直接違反していると見なすことができます。

> Steam加入者として、以下の行動規範に従うことに同意するものとします。
> 
> しません:
> 
> 研究所はスチームサーバーを攻撃したり、スチームを破壊したりします。

他のプログラム(IMなど)でSteamの不具合を引き起こせるかどうかは関係ありません。 また、あなたが私たちに同意し、DoS攻撃などの行動を考慮するかどうかに関係ありません。 あるいはそうではない - これを判断するのはバルブ次第ですが、Steamネットワークリクエストを過剰に行うことで意図しない行為を悪用/悪用すると考える場合。 バルブも同じような見方をしていると確信できます

ASF is **never** going to take advantage of Steam exploits, abuses, hacks or any other activity that we see as **illegal or unwanted** according to Steam ToS, Steam Online Conduct or any other trusted source that could indicate that ASF activity is unwanted by Steam network, as stated in **[contributing](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)** section.

あなたはいつもより速く数セントのカードを農業のためにあなたのスチームアカウントを危険にさらすためにすべてのコストでしたい場合。 悲しいことにASFは自動モードではこのようなものを提供しません `` **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** はまだありますが、Steamネットワークの相互作用の観点から望むことを行うためのツールとして使用できます。 スチームグリッチを利用し、あなた自身の利益のためにそれらを悪用することはお勧めしません - ASFだけでなく。 他のどんな道具でも同様です しかし、最終的にはあなたのアカウントです。 あなたがそれで何をしたいのかを選択してください - 私たちがあなたに警告したことに留意してください。