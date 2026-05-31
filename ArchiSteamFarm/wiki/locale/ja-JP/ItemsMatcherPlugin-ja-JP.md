# ItemsMatcherPlugin

`ItemsMatcherPlugin` is official ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** that extends ASF STM listing features. In particular, this includes `PublicListing` in **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** and `MatchActively` in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. ASFには、リリースにバンドルされた `ItemsMatcherPlugin` が付属しているため、すぐに使用できます。

---

## `公開リスト`

名前が示すように、公開リストは現在利用可能な ASF STM ボットのリストです。 It's located on **[our website](https://asf.justarchi.net/STM)**, managed automatically and used as a public service for both ASF users that make use of `MatchActively`, as well as ASF and non-ASF users for manual matching.

表示されるためには、満たすための要件のセットがあります。 At the minimum, you must have allowed `PublicListing` in `RemoteCommunication` (default setting), `SteamTradeMatcher` enabled in `TradingPreferences`, **[public inventory](https://steamcommunity.com/my/edit/settings)** privacy settings, an **[unrestricted](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** account and **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** active. 追加の要件には、少なくとも15日以降にアクティブな2FAが含まれます。 最後のパスワードは5日以上前に変更されます。 ロックダウンや経済的な禁止、取引禁止などの口座制限はありません 当然のことながら、トレーディングカードなど、指定された `MatchableTypes`から在庫に少なくとも1つ(取引可能な)アイテムを持っている必要があります。 それに加えて、 `500000` 以上のアイテムを持つボットは、過度のオーバーヘッドのため受け入れられません。 この場合いくつかの口座で在庫を分割することをお勧めします

While `PublicListing` is enabled by default, please note that you will **not** be displayed on the website if you do not meet all of the requirements, especially `SteamTradeMatcher`, which isn't enabled by default. 基準を満たしていない人は、たとえ彼らが `PublicListing` を有効にしていても、ASFはいかなる方法でもサーバーと通信しません。 公開リストは、最新の安定版ASFとのみ互換性があり、古いボットの表示を拒否することがあります。 特に新しいバージョンでしか見つからないコア機能が欠けている場合は

### 正確にどのように動作するか

ASFはログイン後、公開リストが使用するすべてのプロパティを含む初期データを一度送信します。 次に、ASFは10分ごとに、ボットがまだ起動していることをサーバーに通知する、非常に小さな「ハートビート」リクエストを送信します。 何らかの理由でハートビートが到着しなかった場合、例えばネットワークの問題のために。 ASFは、サーバーがそれを登録するまで、毎分送信を再試行します。 この方法で、サーバーはどのボットがまだ稼働しているかを正確に把握し、トレードオファーを受け入れる準備ができています。 ASFはまた、前回の発表から在庫が変更されたことを検出した場合など、必要に応じて初期発表を送信します。

**過去15分**で有効なすべてのASFアカウントが表示されます。 Users are sorted according to their relative usefulness - `MatchEverything` bots which are shown with `Any` banner that accept all 1:1 trades, then unique games count, and finally items count.

### API

ASF STMリストは当面ASFボットのみを受け付けています。 今のところ、私たちのリストにサードパーティのボットをリストする方法はありません。 彼らのコードを簡単に見直すことができないため、彼らが我々の取引ロジック全体を満たしていることを確認できません。 したがって、リストへの参加には最新の安定したASFバージョンが必要ですが、カスタム **[プラグイン](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** で実行できます。

リスティングの消費者には、非常にシンプルな **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** エンドポイントがあります。 `MatchActively` 機能の一部であるユーザーの在庫を除いて、私たちが持っているすべてのデータが含まれます。

### プライバシーポリシー

`SteamTradeMatcher` を有効にし、 `PublicListing`を拒否しないことによって、当社のリストに掲載されることに同意した場合。 上記に指定された通り、予期される機能を提供するために、Steamアカウントの詳細情報をサーバーに一時的に保存します。

公開情報 (Steamによって興味のあるすべてのパーティーに公開されます) には以下のものが含まれます:
- あなたのSteam識別子（リンクを生成するための64ビット形式）
- ニックネーム（表示用）
- あなたのアバター（表示用にハッシュ）

条件付き公開情報 (上場要件を満たしている場合は、すべての利害関係者に Steam で公開されます) 以下の内容が含まれます:
- あなたの **[インベントリ](https://steamcommunity.com/my/inventory/#753_6)** (人々があなたのアイテムに対して `MatchActively` を使用できるようにします)。

プライベート情報 (機能を提供するために必要な選択したデータ) には以下のものが含まれます:
- あなたの **[取引トークン](https://steamcommunity.com/my/tradeoffers/privacy)** (フレンドリスト外のユーザーが取引を送信できるようにします)
- あなたの `マッチタイプ` の設定 (表示目的とマッチングのため)
- あなたの `マッチEverything` の設定（表示目的とマッチングのため）
- `MaxTradeHoldDuration` の設定 (他の人が取引を受け入れるかどうかを知るため)

私たちのリスティングの使用を停止(発表)した瞬間に、あなたのデータは最大15分以内に一般公開されなくなります。 そして、サーバーに最大2週間保存されます - その期間の後にすべてが自動的に削除されます。 それが起こるためにあなたに行動は必要ありません。

---

## `一致するアクティブな`

`MatchActively` の設定は、 **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** には、ボットが他の人に取引を送信するインタラクティブマッチングを含みます。 スタンドアロンでも、 `SteamTradeMatcher` の設定でも動作します。 この機能は、サードパーティのサーバーと有料リソースを使用して動作するため、 `LicenseID` を設定する必要があります。

そのオプションを使用するには、満たすための要件のセットがあります。 At the minimum, you must have an **[unrestricted](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** account, **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** active and at least one valid type in `MatchableTypes`, such as trading cards. 追加の要件には、少なくとも15日以降にアクティブな2FAが含まれます。 最後のパスワードは5日以上前に変更されます。 ロックダウンや経済的な禁止、取引禁止などの口座制限はありません

上記のすべての要件を満たす場合。 ASFは、現在利用可能なボットを積極的にマッチさせるために、定期的に弊社の **[公開ASF STMリスティング](#publiclisting)** と通信します。

マッチング中、ASFボットは自身のインベントリを取得します 次に、私たちのサーバーと通信して、 `MatchableTypes` が他の現在利用可能なボットから一致しているすべてを見つけます。 私たちのサーバーと直接通信してくれたおかげで、 このプロセスは単一のリクエストを必要とし、利用可能なボットが私たちのために何か興味深いものを提供してくれるかどうかを直ちに情報を持っています - 一致が見つかった場合。 ASFは自動的にトレードオファーを送信し、確認します。

このモジュールは透明になっています。 ASF開始から約 `1` 時間でマッチングが開始され、必要に応じて各 `6` 時間を繰り返します。 `MatchActively` feature is aimed to be used as a long-run, periodical measure to ensure that we're actively heading towards sets completion, however, people that are not running ASF 24/7 may also consider using a `match` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. このモジュールのターゲットユーザーはプライマリアカウントと「stash」代替アカウントです `MatchEverything` に設定されていないボットでも使用できます。 それに加えて、 `500000` を超えるアイテムを持つボットはオーバーヘッドが多いためマッチングできません。 この場合いくつかの口座で在庫を分割することをお勧めします

ASFは、このオプションを使用して発生する要求と圧力を最小限に抑えるために最善を尽くします。 同時に上限とのマッチング効率を最大限に高めることができます 一致させ、プロセス全体を整理するためにボットを選択する正確なアルゴリズム はASFの実装の詳細であり、フィードバック、状況、および可能性のある将来のアイデアに関して変更することができます。

現在のバージョンのアルゴリズムにより、ASFは `Any` ボットを最初に優先します。 ゲームの多様性を高めることができます `任意の` ボットを使い果たした場合、ASFは同じダイバーシティルールの下で `フェア` に移動します。 ASFは、設定された進行状況で欠落していないことを確認するために、少なくとも1回はすべての利用可能なボットを一度に一致させようとします。

`MatchActively` takes into account bots that you blacklisted from trading through `tbadd` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** and will not attempt to actively match them. これは、私たちが使用する可能性のあるダップがあっても、ASFには一致しないボットを伝えるために使用できます。

ASFはまた、貿易の申し出が通過するように最善を尽くします。 次の実行では、通常6時間以内に発生しますが、ASFはまだ受け入れられていなかった未定の取引オファーをキャンセルします。 積極的なボットを最初に好むよりも しかし、もしボットの優先順位を下げることが、私たちが必要とするマッチが最後にある場合でも、それらを再びマッチさせようとします(再び)。

---

### `MatchActively` を使用するには、なぜ `LicenseID` が必要なのですか? それは前に自由ではなかったか。

ASFは、2015年10月のプロジェクトの開始時に設立されたオープンソースであり、残っています。 `ItemsMatcher` プラグインのソースコードと、 `MatchActively` 機能がリポジトリで利用可能です。 ASFプログラムは完全に非商業的ですが、私たちはそれに対する貢献、構築または出版から何も得ることはありません。 過去7年以上にわたり、ASFは膨大な量の開発を受けてきました。 毎月の安定版のリリースでは主に1人で改善されています **[JustArchi](https://github.com/JustArchi)** - 紐が付いていない。 私たちが受け取る唯一の資金は、ユーザーからの非義務的な寄付からです。

非常に長い間、 `MatchActively` 機能はASFコアの一部であり、誰でも使用できるようになっていました。 2022年10月、Steamの背後にあるValve社。 他のボットの在庫を取得することに非常に厳しいレート制限があります - これは以前の機能が完全に壊れています この問題を解決する可能性はありません そのため、機能が完全に消滅し、固定される可能性もなくなったことから。 時代遅れとしてASFコアから取り除かなければなりませんでした

`マッチアクティブ` は、アクティブなカードマッチング機能でASFをさらに強化する公式の `ItemsMatcher` プラグインの一部として復活させました 完全に改良されたコンセプトに基づいています Resurrecting `MatchActively` feature required from us **extraordinary amount of work** to create ASF backend, entirely new service hosted on a server, with more than a hundred of paid proxies attached for resolving inventories, all exclusively to allow ASF clients to make use of `MatchActively` like before. 仕事の量のために、 私たち(ドメイン、サーバー、プロキシ)が毎月支払う必要がある無料のリソースだけでなく、 スポンサーにこの機能を提供することにしました 月単位でASFプロジェクトを支援している人々は、そのおかげで有料のリソースを利用できるようになりました。

私たちの目標はそれから利益を得ることではなく、むしろそれから利益を得ることです。 このオプションを提供することで独占的にリンクされている **月額費用** をカバーします - そのため、基本的には何も提供していません。 1ヶ月に数百ドルは自分のポケットから払えないから少し請求しなければなりません 利用できるようにするためです 私たちは価格について議論する立場にあるわけではありませんが、それらのコストを私たちに押し付けたバルブです。 そしてそのような機能は全く利用できません もちろん理由を問わず我々のプラグインを使うのは正当化できない

いずれにせよ、我々は `マッチアクティブ` が全員のためではないことを理解している。 無料で提供できない理由を理解していただければ幸いです 誰もこの機能のコストをカバーすることに興味がなかった場合、それは簡単には存在しません。 誰も維持したくない月額費用の削減を余儀なくされます ありがたいことに、私たちはそれよりも良い位置にあり、あなたがそれらの条件で `マッチアクティブ` を使用するかどうかをあなた自身で決定することができます。

---

### アクセスを取得するにはどうすればよいですか?

`ItemsMatcher` は、 **[JustArchの GitHub](https://github.com/sponsors/JustArchi)** の月額$5+スポンサー層の一部として提供されます。 一度限りのスポンサーになることも可能です ただし、この場合、ライセンスは 1 か月間のみ有効になります (同じように拡張機能の可能性があります)。 $5 Tier (またはそれ以上)のスポンサーになったら、 **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** セクションを読んで、 `LicenseID` を取得して入力してください。 その後、選択したボットの `取引環境設定` で `マッチアクティブ` を有効にするだけです。

ライセンスを使用すると、限られた量のリクエストをサーバーに送信できます。 $5の階層では、 `マッチング` を1つのボットアカウントに使用できます（毎日4リクエスト） さらに5ドル追加するごとに、さらに2つのボットアカウントが追加されます(毎日8リクエスト)。 たとえば、3つのアカウントで実行したい場合は、10ドル以上のレベルが適用されます。