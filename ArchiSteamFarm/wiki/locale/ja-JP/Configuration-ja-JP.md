# 設定

このページはArchiSteamFarm（ASF）の設定に関する完全なドキュメントです。 `config`ディレクトリの構造と設定オプションについて説明します。

* **[はじめに](#introduction)**
* **[Web Config Generator](#web-based-configgenerator)**
* **[ASF-ui設定](#asf-ui-configuration)**
* **[手動設定](#manual-configuration)**
* **[グローバル設定](#global-config)**
* **[ボット設定](#bot-config)**
* **[ファイル構造](#file-structure)**
* **[JSONマッピング](#json-mapping)**
* **[互換性マッピング](#compatibility-mapping)**
* **[設定互換性](#configs-compatibility)**
* **[自動再読み込み](#auto-reload)**

---

## はじめに

ASFの設定は大きく2つに分かれます ― グローバル（プロセス）設定と、各ボットの設定です。 各ボットには`BotName.json`（`BotName`はボット名）の設定ファイルが必要で、グローバルASF（プロセス）設定は`ASF.json`という1つのファイルです。

ボットとは、ASFプロセスに参加する1つのSteamアカウントです。 ASFを正しく動作させるには**少なくとも1つ**のボットインスタンスが必要です。 ボット数に制限はなく、好きなだけ（Steamアカウント数分）利用できます。

ASFは**[JSON](https://en.wikipedia.org/wiki/JSON)**形式で設定ファイルを保存します。 人間にとっても読みやすく、普遍的な形式です。 JSONの知識がなくてもASFの設定は可能です。 しかしながら、スクリプトで大量生成したい場合などは知っておくと便利です。

設定方法はいくつかあります。 当社の **[WebベースのConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)**を使用できます。これはASFとは独立したローカルアプリです。 **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC フロントエンドを使用して、ASFで直接設定を行うことができます。 最後に、以下で指定した固定された JSON 構造に従って設定ファイルを手動で生成することができます。 利用可能なオプションについてはまもなく説明します。

---

## Web Config Generator

**[WebベースのConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** の目的は、ASF構成ファイルの生成に使用されるフレンドリーなフロントエンドを提供することです。 WebベースのConfigGeneratorは100%クライアントベースで、入力した詳細はどこにも送信されず、ローカルでのみ処理されることを意味します。 This guarantees security and reliability, as it can even work **[offline](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** if you'd like to download all the files and run `index.html` in your favourite browser.

WebベースのConfigGeneratorはChromeとFirefoxで正常に動作することが確認されていますが、一般的なすべてのJavaScript対応ブラウザで正常に動作するはずです。

使い方は非常に簡単です - 適切なタブに切り替えて、 `ASF` または `Bot` 設定を生成するかどうかを選択します。 設定ファイルのバージョンがASFリリースと一致していることを確認し、すべての詳細を入力し、「ダウンロード」ボタンを押します。 このファイルをASF `config` ディレクトリに移動し、必要に応じて既存のファイルを上書きします。 すべての最終的なさらなる変更について繰り返し、設定するためのすべての利用可能なオプションの説明については、このセクションの残りの部分を参照してください。

---

## ASF-ui設定

私たちの **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC インターフェイスでは、ASFを設定することもできます。 そして、場所内で設定を編集できるため、初期設定を生成した後にASFを再構成する優れたソリューションです。 静的に生成する Web ベースの ConfigGenerator とは対照的に。

ASF-uiを使用するには、 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** インターフェイスを有効にする必要があります。 `IPC` はデフォルトで有効になっているため、自分で無効にしていなければすぐにアクセスできます。

プログラムを起動したら、ASFの **[IPC アドレス](http://localhost:1242)** に移動します。 すべてが正常に動作した場合は、ASF構成をそこから変更することもできます。

---

## 手動設定

一般に、ConfigGenerator または ASF-ui のいずれかを使用することを強くお勧めします。 JSON 構造で間違いを犯さないようにするので、より簡単になります。 でも何らかの理由で手動で適切な設定を作成することもできます 適切な構造で良いスタートを切るには、以下の JSON の例を確認してください。 コンテンツをファイルにコピーして、設定のベースとして使用できます。 フロントエンドを使用していないので、設定が **[有効な](https://jsonlint.com)**であることを確認してください。 ASFは解析できない場合はロードを拒否します。 有効な JSON であっても、すべてのプロパティに ASF が要求する適切な型があることを確認する必要があります。 使用可能なすべてのフィールドの JSON 構造については、 **[JSON マッピング](#json-mapping)** セクションと下のドキュメントを参照してください。

---

## グローバル設定

グローバル設定は `ASF.json` ファイル内にあり、以下の構造を持っています。

```json
{
    "AutoRestart": true,
    "Blacklist": [],
    "CommandPrefix": "!",
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "CurrentCulture": null,
    "Debug": false,
    "DefaultBot": null,
    "FarmingDelay": 15,
    "FilterBadBots": true,
    "GiftsLimiterDelay": 1,
    "Headless": false,
    "IdleFarmingPeriod": 8,
    "InventoryLimiterDelay": 4,
    "IPC": true,
    "IPCPassword": null,
    "IPCPasswordFormat": 0,
    "LicenseID": null,
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldDuration": 15,
    "MinFarmingDelayAfterBlock": 60,
    "OptimizationMode": 0,
    "PluginsUpdateList": [],
    "PluginsUpdateMode": 0,
    "ShutdownIfPossible": false,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

すべてのオプションについて以下に説明します。

### `自動再起動`

`bool` type, デフォルト値 `true`. このプロパティは、必要に応じてASFが自己再起動を実行できるかどうかを定義します。 There are a few events that will require from ASF a self-restart, such as ASF update (done with `UpdatePeriod` or `update` command), as well as `ASF.json` config edit, `restart` command and likewise. 通常、再起動には、新しいプロセスの作成と現在のプロセスの終了の 2 つの部分が含まれます。 Most users should be fine with it and keep this property with default value of `true`, however - if you're running ASF through your own script and/or with `dotnet`, you may want to have full control over starting the process, and avoid a situation such as having new (restarted) ASF process running somewhere silently in the background, and not in the foreground of the script, that exited together with old ASF process. これは、新しいプロセスがもはやあなたの直接の子供ではないという事実を考慮すると、特に重要です, これはあなたを作ることができません e. をクリックします。

この場合、このプロパティはあなたのために特別に、そしてあなたのためにそれを `false` に設定することができます。 ただし、 **の場合は、** がプロセスを再起動する責任を負うことに留意してください。 これは、ASFが新しいプロセスをスポーンさせる代わりに終了するだけであるため、何らかの点で重要です。 更新後)、ロジックが追加されていない場合は、再起動するまで動作を停止します。 ASF always exits with proper error code indicating success (zero) or non-success (non-zero), this way you're able to add proper logic in your script which should avoid auto-restarting ASF in case of failure, or at least make a local copy of `log.txt` for further analysis. Also keep in mind that `restart` command will always restart ASF regardless of how this property is set, as this property defines default behaviour, while `restart` command always restarts the process. この機能を無効にする理由がない限り、有効にしておく必要があります。

---

### `ブラック リスト`

`ImmutableHashSet<uint>` 型はデフォルト値が空です。 名前が示すように、このグローバルconfigプロパティは、自動ASF農業プロセスで完全に無視されるappID(ゲーム)を定義します。 残念ながらSteamは「カードドロップ可能」として夏/冬の販売バッジにフラグを立てるのが大好きです ASFプロセスを混乱させることによって、それは農業をするべきである有効なゲームであると信じさせます。 ブラックリストのいずれかの種類がなかった場合、ASFは実際にはゲームではないゲームを農業で最終的に「ハング」するでしょう。 そして無限にカードドロップが起こらないのを待つのです ASFブラックリストは、これらのバッジを農業用に利用できないとマークする目的を果たしています 農場を決める時は黙って無視して 罠にはまらないのです

ASF includes two blacklists by default - `SalesBlacklist`, which is hardcoded into the ASF code and not possible to edit, and normal `Blacklist`, which is defined here. `SalesBlacklist` is updated together with ASF version and typically includes all "bad" appIDs at the time of release, so if you're using up-to-date ASF then you do not need to maintain your own `Blacklist` defined here. このプロパティの主な目的は、ASFリリースappIDの時点で知られていない新しいものをブラックリストに載せることです。 Hardcoded `SalesBlacklist` is being updated as fast as possible, therefore you're not required to update your own `Blacklist` if you're using latest ASF version, but without `Blacklist` you'd be forced to update ASF in order to "keep running" when Valve releases new sale badge - I don't want to force you to use latest ASF code, therefore this property is here to allow you "fixing" ASF yourself if you for some reason don't want to, or can't, update to new hardcoded `SalesBlacklist` in new ASF release, yet you want to keep your old ASF running. このプロパティを編集する **強力な** 理由がない限り、デフォルトのままにしておく必要があります。

If you're looking for bot-based blacklist instead, take a look at `fb`, `fbadd` and `fbrm` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `コマンドプレフィックス`

`文字列` type、デフォルト値は `!`。 このプロパティでは、AF **** **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** に使用される

 プレフィックスを指定します。 言い換えれば、ASFがあなたに耳を傾けるためには、それぞれのASFコマンドの先頭にあるものです。 この値を `null` または空に設定することで、ASFにコマンドプレフィックスを使用しないようにすることができます。 コマンドを単純な識別子で入力します。 ただし、 ASFが `CommandPrefix` で始まらない場合、メッセージをさらにパースしないように最適化されているため、ASFのパフォーマンスは低下する可能性があります。 ASFは、ASFコマンドでない場合でも、すべてのメッセージを読み取り、応答することを余儀なくされます。 Therefore it's recommended to keep using some `CommandPrefix`, such as `/` if you don't like default value of `!`. 一貫性を保つために、 `CommandPrefix` はASFプロセス全体に影響を与えます。 このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。</p> 



---



### `ConfirmationsLimiterDelay`

`バイト` 型のデフォルト値は `10` です。 ASF will ensure that there will be at least `ConfirmationsLimiterDelay` seconds in between of two consecutive 2FA confirmations fetching requests to avoid triggering rate-limit - those are being used by **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** during e.g. `2faok` command, as well as on as-needed basis when performing various trading-related operations. デフォルト値はテストに基づいて設定されており、問題に遭遇したくない場合は下げるべきではありません。 このプロパティを編集する **強力な** 理由がない限り、デフォルトのままにしておく必要があります。



---



### `接続タイムアウト`

`バイト` 型のデフォルト値は `90` です。 このプロパティは、ASFによって行われたさまざまなネットワークアクションのタイムアウトを秒単位で定義します。 In particular, `ConnectionTimeout` defines timeout in seconds for HTTP and IPC requests, `ConnectionTimeout / 10` defines maximum number of failed heartbeats, while `ConnectionTimeout / 30` defines number of minutes we allow for initial Steam network connection request. Default value of `90` should be fine for majority of people, however, if you have rather slow network connection or PC, you may want to increase this number to something higher (like `120`). 大きな値は、魔法のように遅い、またはアクセスできないSteamサーバーを修正しないことに注意してください。 だからいつまでも待つべきではありません 後でもう一度試してみましょう この値を大きすぎると、ネットワークの問題を引き起こし、全体的なパフォーマンスが低下することになります。 この値を小さすぎると全体的な安定性とパフォーマンスも低下します。ASFは有効なリクエストの解析を中止します。 そのため、この値をデフォルトより低く設定すると、一般的に利点はありません。 Steamサーバーは時々超遅くなり、ASFリクエストの解析にさらに時間がかかることがあります。 デフォルト値は、ネットワーク接続が安定していることと、指定したタイムアウト時にリクエストを処理するためにSteamネットワークで疑わしいこととのバランスです。 問題を早期に検出してASFの再接続/応答を速くしたい場合。 デフォルト値は行う必要があります(または、 `60`のように、ASFの患者を減らします)。 If you instead notice that ASF is running into network issues, such as failing requests, heartbeats being lost or connection to Steam interrupted, it probably makes sense to increase this value if you're sure that it's **not** caused by your network, but by Steam itself, as increasing timeouts makes ASF more "patient" and not deciding to reconnect right away.

このプロパティの増加を必要とする例として、ASFがSteamによって完全に受け入れられ、処理されるのに2分以上かかる非常に大きな貿易オファーに対処することができます。 デフォルトのタイムアウトを増加させることで ASFはより忍耐強く、貿易が通過しないと判断し、最初の要求を放棄する前に、より長く待つでしょう。

別の状況は、送信されるデータを処理するために多くの時間を必要とする非常に低速のマシンまたはインターネット接続によって引き起こされる可能性があります。 これは、CPU/ネットワーク帯域幅がボトルネックになることはほとんどありませんが、まだ言及する価値がある可能性があります。

要するに、ほとんどの場合、デフォルト値はまともでなければなりませんが、必要に応じて増加させたい場合があります。 しかし、大きなタイムアウトは魔法のようにアクセスできないSteamサーバーを修正しませんので、デフォルト値をはるかに上回ると、あまり意味がありません。 このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



### `CurrentCulture`

`文字列` 型のデフォルト値は `null` です。 デフォルトでは、ASFはオペレーティングシステムの言語を使用しようと試みます。可能な場合は、その言語で翻訳された文字列を使用することを好みます。 これは、すべての最も一般的な言語で **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** ASFをローカライズしようとするコミュニティのおかげで可能です。 何らかの理由でOSのネイティブ言語を使用したくない場合 このconfigプロパティを使用して、代わりに有効な言語を選択できます。 利用可能なすべての文化のリストについては、 **[MSVN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** にアクセスし、 `言語タグ` を探します。 It's nice to note that ASF accepts both specific cultures, such as `"en-GB"`, but also neutral ones, such as `"en"`. 現在のカルチャーを指定することは、通貨/日付フォーマットや同様な他のカルチャー固有の動作にも影響します。 言語固有の文字を適切に表示するためにフォントや言語パックが必要になる場合がありますのでご注意ください。 通常、ASFを母国語ではなく英語で使用する場合は、このconfigプロパティを使用します。



---



### `Debug`

`bool` type, デフォルト値 `false`. このプロパティは、プロセスをデバッグモードで実行するかどうかを定義します。 デバッグモードでは、ASFは `config` の隣に特別な `デバッグ`ディレクトリを作成します。 ASFとSteamサーバー間の通信全体を追跡します。 デバッグ情報はネットワークや一般的なASFワークフローに関連する厄介な問題を発見するのに役立ちます。 それに加えて、いくつかのプログラムルーチンははるかに冗長になります。 例えば、 `WebBrowser` いくつかのリクエストが失敗している正確な理由を示しています - これらのエントリは通常の ASF ログに書き込まれます。 **You should not run ASF in Debug mode, unless asked by developer**. Running ASF in debug mode **decreases performance**, **affects stability negatively** and is **far more verbose in various places**, so it should be used **only** intentionally, in short-run, for debugging particular issue, reproducing the problem or getting more info about a failing request, and alike, but **not** for normal program execution. 新しいエラーの **多くの** が表示されます。 例外について - ASFについて十分な知識があることを確認してください。 蒸気とその癖は、すべてが適切ではないとして、自分自身でそのすべてを分析することを決定した場合。

**警告:** このモードを有効にすると、Steamへのログインに使用しているログインやパスワードなど、 **潜在的に機密性の高い** 情報のロギングが含まれます (ネットワークログインのため)。 That data is written to both `debug` directory, as well as standard `log.txt` (that is now intentionally much more verbose to log this info). ASFによって生成されたデバッグコンテンツをパブリックな場所に投稿しないでください。 ASFの開発者は、常にメールやその他の安全な場所に送信することをあなたに思い出させる必要があります。 我々は保管しているのではなく、機密情報を利用しているのでもありません。 彼らはデバッグルーチンの一環として書かれています 彼らの存在はあなたに影響を与えている問題に関連する可能性があります ASFロギングを変更しない場合は、ご心配の場合は、機密情報の適切な編集を自由に行ってください。



> たとえば星のように微妙な詳細を置き換えます。 純粋な存在が関連する可能性があり、保存されるべきであるので、あなたは、敏感なラインを完全に削除することを控える必要があります。



---



### `DefaultBot`

`文字列` 型のデフォルト値は `null` です。 いくつかのシナリオでは、ターゲットボットを指定しない場合のIPCコマンドやインタラクティブコンソールなど、何かを処理するためのデフォルトボットの概念を備えたASF関数があります。 このプロパティでは、 `BotName` をここに置くことで、このようなシナリオの処理を担当するデフォルトのボットを選択できます。 指定されたボットが存在しない場合、またはデフォルト値の `null`を使用する場合、ASFは最初に登録されたボットをアルファベット順に並べ替えます。 通常、IPCと対話型コンソールコマンドで `[Bots]` 引数を省略したい場合は、このconfigプロパティを使用します。 そして、そのような呼び出しのデフォルトと同じボットを常に選択します。



---



### `FarmingDelay`

`バイト` 型のデフォルト値は `15` です。 ASFが動作するようにするには、おそらくすでにすべてのカードをドロップした場合、 `FarmingDelay` 分ごとに現在の農業ゲームをチェックします。 このプロパティを低すぎると、蒸気リクエストの送信量が多すぎる可能性があります。 高い値に設定すると、ASFが完全に農業を行った後、 `FarmingDelay` までのタイトルを「農業」として与えることになります。 デフォルト値は、ほとんどのユーザーに優れている必要がありますが、多くのボットが実行されている場合。 蒸気リクエストを送信するのを制限するために、 `30` のようなものに増やすことを検討してください。 It's nice to note that ASF uses event-based mechanism and checks game badge page on each Steam item dropped, so in general **we don't even need to check it in fixed time intervals**, but as we don't fully trust Steam network - we check game badge page anyway, if we didn't check it through card being dropped event in last `FarmingDelay` minutes (in case Steam network didn't inform us about item dropped or stuff like that). Assuming that Steam network is working properly, decreasing this value **will not improve farming efficiency in any way**, while **increasing network overhead significantly** - it's recommended only to increase it (if needed) from default of `15` minutes. このプロパティを編集する **強力な** 理由がない限り、デフォルトのままにしておく必要があります。



---



### `FilterBadBots`

`bool` type, デフォルト値 `true`. このプロパティは、ASFが既知のアクターから受け取った取引オファーを自動的に拒否するかどうかを定義します。 これを行うために、ASFはブラックリストに登録されたSteam識別子のリストを取得するために必要に応じてサーバーと通信します。 The bots listed are operated by people that are classified as harmful towards ASF initiative by us, such as those that violate our **[code of conduct](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, use provided functionality and resources by us such as **[`PublicListing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** in order to abuse and exploit other people, or are doing outright criminal activity such as launching DDoS attacks on the server. ASFは、コミュニティ全体を繁栄させるために、ユーザー間の全体的な公平性、誠実さ、協力に対して強いスタンスを持っています。 このプロパティはデフォルトで有効になっているため、提供されているサービスから有害として分類された ASF フィルタボットがあります。 このプロパティを編集する **強力な** 理由がない限り。 私たちの声明に同意せず、意図的にそれらのボットを操作することを許可する(あなたのアカウントを悪用することを含む)など、あなたはデフォルトでそれを維持する必要があります。



---



### `GiftsLimiterDelay`

`バイト` 型のデフォルト値は `1` です。 ASFは、少なくとも `GiftsLimiterDelay` レート制限を回避するために、2つの連続したgift/key/licenseの処理(償還)リクエストの間に、少なくともAformat@@2 GiftsLimiterDelay Aformat@@3 秒があることを保証します。 それに加えて、ゲームリストリクエストのグローバルリミッターとしても使用されます。 例えば、 `が発行した` **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** を所有しています。 このプロパティを編集する **強力な** 理由がない限り、デフォルトのままにしておく必要があります。



---



### `ヘッドレス`

`bool` type, デフォルト値 `false`. このプロパティは、プロセスがヘッドレスモードで実行されるかどうかを定義します。 ヘッドレスモードの場合、ASFはサーバまたは他の非対話環境で動作していると仮定します。 コンソール入力で情報を読むことはできません。 これには、オンデマンドの詳細(2FAコード、SteamGuardコードなどのアカウント資格情報)が含まれます。 パスワードまたはASFの操作に必要なその他の変数、およびその他のコンソール入力 (インタラクティブなコマンドコンソールなど) 。 言い換えれば、 `ヘッドレス` モードは、ASF コンソールを読み取り専用にするのと同じです。 この設定は、主にサーバ上でASFを実行している場合に便利です。 をクリックします。2FAコードの場合、アカウントを停止することで、ASFは黙って操作を中止します。 サーバーでASFを実行していて、以前にASFがヘッドレスモードで動作できることを確認した場合を除きます。 この物件は無効にしておくべきだ Any user interaction will be denied when in headless mode, and your accounts will not run if they require **any** console input during starting. これは、ASFがアカウントにログインしようとする際に中止することができるため、サーバにとって便利です。 ユーザーがそれらを提供するのを待つ代わりに(無限に)。

このモードを有効にすると、他の方法で必要なコンソール入力を提供することができます。 ASF-ui (ASF API), or through **[`input`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#input-command)** command このプロパティの設定方法がわからない場合は、デフォルト値の `false` を指定してください。



---



### `IdleFarming Period`

`バイト` 型のデフォルト値は `8` です。 ASFにファームするものが何もない場合は、アカウントに新しいゲームがある場合は、定期的に `IdleFarmingPeriod` 時間をチェックします。 ASFはこの場合バッジページを自動的に確認するのに十分スマートであるため、この機能は新しいゲームについて話しているときに必要ありません。 `IdleFarmingPeriod` は主に、トレーディングカードが既に追加されている古いゲームなどの状況を対象としています。 この場合、イベントは発生しないため、ASFは定期的にバッジページを確認する必要があります。 値 `0 0` はこの機能を無効にします。 また、チェック: `ShutdownOnFarmingFinished` 環境設定 `FarmingPreferences`.



---



### `InventoryLimiterDelay`

`バイト` 型のデフォルト値は `4` です。 ASFは、起動レート制限を避けるために、少なくとも `InventoryLimiterDelay` 連続した2つのウェブインベントリ要求の間で、少なくともAformat@@2秒があることを確認します。 他のユーザーのインベントリを取得するサードパーティ製のプラグインでも使用されるかもしれません。 このプロパティは、ASFがはるかに効率的な内部ネットワーク呼び出しを使用しているため、私たち自身のインベントリを取得するために使用されません。 `略奪` や `転送` のようなコマンドには影響しません。 `4` のデフォルト値は、100 以上の連続ボットインスタンスのインベントリのマーキングに基づいて設定されています。 そしてユーザーの大部分(すべてではない場合)を満足させるべきです。 しかし、ボット数が非常に少ない場合は、それを減らしたり、 `0 0` に変更することもできます。 ASFは遅延を無視し、スチームの在庫をはるかに速くマークします。 Be warned though, as setting it too low **will** result in Steam temporarily banning your IP, and that will prevent you from making any calls at all. 在庫リクエストが多いボットを多数実行している場合は、この値を増やす必要がある場合もあります。 でもこの場合はそのリクエストの数を制限するべきです このプロパティを編集する **強力な** 理由がない限り、デフォルトのままにしておく必要があります。



---



### `プロセス間通信`

`bool` type, デフォルト値 `true`. このプロパティは、ASFの **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** サーバーがプロセスと一緒に開始するかどうかを定義します。 IPCは、ローカルHTTPサーバーを起動することにより、 **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**の使用を含むプロセス間通信を可能にします。 ASF-uiを含むASFとのサードパーティIPC統合を使用しない場合は、このオプションを安全に無効にすることができます。 そうでなければ、それを有効にしておくことをお勧めします(デフォルトのオプション)。



---



### `IPCPassword`

`文字列` 型のデフォルト値は `null` です。 このプロパティは、IPC経由で行われるすべてのAPI呼び出しに必須のパスワードを定義し、追加のセキュリティ対策として機能します。 空でない値に設定されている場合、IPCリクエストはここで指定されたパスワードに追加の `パスワード` プロパティが必要になります。 デフォルト値の `null` はパスワードの必要性をスキップし、ASFはすべてのクエリを尊重します。 それに加えて このオプションを有効にすると、非常に短時間であまりにも多くの許可されていないリクエストを送信した後に、 `IPAddress` を一時的に禁止する組み込みのIPCアンチブルフォースメカニズムも有効になります。 このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



### `IPCPasswordフォーマット`

`バイト` 型のデフォルト値は `0` です。 このプロパティは、 `IPCPassword` プロパティの形式を定義し、元の型として `EHashingMethod` を使用します。 Please refer to **[Security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section if you want to learn more, as you'll need to ensure that `IPCPassword` property indeed includes password in matching `IPCPasswordFormat`. つまり、 `IPCPasswordFormat` を変更した場合、 `IPCPassword` は既に **** 形式でなければなりません。 目指すだけではなく 何をしているのかわからない限り、デフォルト値は `0 0`です。



---



### `LicenseID`

`Guid?` 型のデフォルト値は `null` です。 このプロパティは、 **[が](https://github.com/sponsors/JustArchi)** スポンサーを務めるために有料のリソースを必要とするオプションの機能でASFを強化することができます。 これにより、 **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** 機能を `ItemsMatcher` プラグインで使用することができます。

私たちはGitHubを利用することをお勧めしますが、それは毎月および1回限りの階層を提供するだけでなく、完全な自動化を可能にし、即座にアクセスできます。 **また、** は他のすべての **[寄付オプション](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)** をサポートしています。 一定期間有効なマニュアルライセンスを取得するために、他の方法を使用して寄付する方法については、この記事 **[](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** を参照してください。

使用されている方法に関係なく、ASFスポンサーであれば、ここ **[](https://asf.justarchi.net/User/Status)** ライセンスを取得できます。 あなたの身元を確認するには、GitHubでサインインする必要があります。私たちは、あなたのユーザー名である読み取り専用の公開情報のみを求めます。 `LicenseID` は `f6a0529813f74d119982eb4fe43a9a24`.

**Ensure that you do not share your `LicenseID` with other people**. 個人的に発行されているので、漏洩すると取り消される可能性があります。 偶然にも同じ場所から新しいものを生成することができます。

ASFの追加機能を有効にしない限り、ライセンスを取得/提供する必要はありません。



---



### `LoginLimiterDelay`

`バイト` 型のデフォルト値は `10` です。 ASFは、少なくとも `LoginLimiterDelay` 2つの連続した接続試行の間に、レート制限のトリガを回避するための秒があることを保証します。 デフォルト値の `10` は、100以上のボットインスタンスを接続することに基づいて設定されており、ユーザーのほとんど(すべてではない場合)を満たす必要があります。 しかし、ボット数が非常に少ない場合は、 `0 0` に変更することもできます。 ASFは遅延を無視してSteamに接続するのがずっと速くなります。 Be warned though, as setting it too low while having too many bots **will** result in Steam temporarily banning your IP, and that will prevent you from logging in **at all**, with `InvalidPassword/RateLimitExceeded` error - and that also includes your normal Steam client, not only ASF. 同様に、ボット数が多すぎる場合、特に同じIPアドレスを使用して他のSteamクライアント/ツールと一緒に実行している場合 より長い期間にわたってログインを広げるためにはこの値を増やす必要があります

サイドノートとして、この値は、 `SendTradePeriod` の取引など、ASFスケジュールされたすべてのアクションにおけるロードバランシングバッファとしても使用されます。 このプロパティを編集する **強力な** 理由がない限り、デフォルトのままにしておく必要があります。



---



### `MaxFarmingTime`

`バイト` 型のデフォルト値は `10` です。 知っておくべきですが、スチームが常に正しく動作しているとは限りません。 時々奇妙な状況が起こることがあります我々のプレイタイムが記録されていないような ゲームをしているにもかかわらず。 ASFは、 `MaxFarmingTime` 時間のソロモードで1つのゲームを農業できるようにし、その後完全に養殖されたと考えます。 これは、奇妙な状況が発生した場合に農業プロセスを凍結しないようにする必要があります。 しかし、何らかの理由でSteamが新しいバッジをリリースした場合、ASFがさらに進行するのを止めることになります( `ブラックリスト`を参照)。 `10` 時間のデフォルト値は、一回のゲームからすべてのスチームカードをドロップするのに十分である必要があります。 このプロパティを低すぎると、有効なゲームがスキップされる可能性があります (そして、はい)。 農場には最大9時間もかかる有効なゲームがありますが、高すぎると農業プロセスが凍結される可能性があります。 このプロパティは、1つの農業セッションで1つのゲームにのみ影響することに注意してください（したがって、キュー全体を通過すると、ASFはそのタイトルに戻ります） また、総プレイ時間に基づくものではなく、内部ASF農業時間に基づくものであるため、ASFも再スタート後にそのタイトルに戻ります。 このプロパティを編集する **強力な** 理由がない限り、デフォルトのままにしておく必要があります。



---



### `MaxTradeHoldDuration`

`バイト` 型のデフォルト値は `15` です。 This property defines maximum duration of trade hold in days that we're willing to accept - ASF will reject trades that are being held for more than `MaxTradeHoldDuration` days, as defined in **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** section. This option makes sense only for bots with `TradingPreferences` of `SteamTradeMatcher`, as it doesn't affect `Master`/`SteamOwnerID` trades, neither donations. トレードホールドは誰にとっても迷惑で、誰も本当にそれらに対処したいと思っていません。 ASFは、リベラルなルールに取り組んで、誰もが助けることになっています。 トレードホールドの有無に関わらず、このオプションはデフォルトで `15` に設定されています。 ただし、代わりにトレードホールディングの影響を受けるすべての取引を拒否する場合は、ここで `0 0` を指定できます。 Please consider the fact that cards with short lifespan are not affected by this option and automatically rejected for people with trade holds, as described in **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** section, so there is no need to globally reject everybody only because of that. このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。




---



### `MinFarmingDelayAfterBlock`

`バイト` 型のデフォルト値は `60` です。 このプロパティは、最小時間を秒単位で定義します。 以前に `LoggedInElsewhere`で切断された場合、カードの農業を再開する前にASFが待機します これは、ゲームを開始することによって、現在の農業ASFを強制的に切断することにした場合に発生します。 この遅延は主に利便性とオーバーヘッドの理由から存在します。 たとえば、ASFがアカウントを占拠している場合、1秒間の再生ロックが可能であったために、再度アカウントと戦うことなくゲームを再開することができます。 セッションを再開すると、 `LoggedInElsewhere` が切断されるため、ASFは再接続手順全体を通過する必要があります。 マシンとSteamネットワークに追加の圧力をかけるため、可能であれば追加の切断を避けることが望ましい。 デフォルトでは、これは `60` 秒で設定されており、ゲームを簡単に再起動できるようにするのに十分です。 しかし、あなたがそれを増やすことに興味がある可能性があるシナリオがあります。 たとえば、ネットワークが切断され、ASFがあまりにも早く乗っ取られている場合は、再接続プロセスを行うことを余儀なくされます。 このプロパティには、 `255` の最大値を許可します。これは、すべての一般的なシナリオに十分な値でなければなりません。 上記に加えて、遅延を減らすことも可能です。 または、 `0 0`の値で完全に削除することもできます。 上記の理由では通常は推奨されませんが。 このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



### `最適化モード`

`バイト` 型のデフォルト値は `0` です。 このプロパティは、実行時にASFが好む最適化モードを定義します。 Currently ASF supports two modes - `0` which is called `MaxPerformance`, and `1` which is called `MinMemoryUsage`. デフォルトでは、ASFは可能な限り多くのものを並列(同時に)で実行することを好みます。 これは、すべてのCPUコア、複数のCPUスレッド、複数のソケット、複数のスレッドプールタスクにまたがる負荷分散によってパフォーマンスを向上させます。 たとえば、ASFはゲームのファームへのチェック時に最初のバッジページを要求し、その後リクエストが到着するとします。 ASFはあなたが実際に持っているバッジページの数をそこから読み取り、お互いに同時にリクエストします。 これは **ほぼ常に**が欲しいものです。 ほとんどの場合、オーバーヘッドは最小限であり、非同期ASFコードの利点は、単一CPUコアと大きく制限された電力を備えた最古のハードウェアでも見ることができます。 ただし、多くのタスクが並列処理されると、ASFランタイムはそのメンテナンスを担当します。 ソケットを開いたままスレッドを生きたままにし、タスクを処理します。 時々メモリ使用量が増加し利用可能なメモリに非常に制約されている場合 ASFをできるだけ少ないタスクに強制的に使用するために、このプロパティを `1` (`MinMemoryUsage`) に切り替えることができます。 並列非同期コードを同期的に実行します **[低メモリセットアップ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** を以前に読んで意図的に巨大なパフォーマンス向上を犠牲にしたい場合にのみ、このプロパティを切り替えることを検討する必要があります。 記憶の負荷が小さくなってしまいます Usually this option is **much worse** than what you can achieve with other possible ways, such as by limiting your ASF usage or tuning runtime's garbage collector, as explained in **[low-memory setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. したがって、 `MinMemoryUsage` を **最後の手段**として使用する必要があります。 ランタイム再コンパイルの直前に、他のオプションで満足のいく結果が得られなかった場合(はるかに良い)。 このプロパティを編集する **強力な** 理由がない限り、デフォルトのままにしておく必要があります。



---



### `PluginsUpdateList`

`ImmutableHashSet<string>` 型はデフォルト値が空です。 このプロパティは、自動更新を考慮するためにブラックリストまたはホワイトリストに登録されているプラグインアセンブリ名のリストを定義します。 as per `PluginsUpdateMode` defined below.

このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



### `PluginsUpdateMode`

`バイト` 型のデフォルト値は `0` です。 このプロパティは、上記で定義した `PluginsUpdateList` に意味を与えるプラグインの更新モードを定義します。 このプロパティを指定することで、宣言されたプラグイン以外のすべてのプラグインの自動更新を簡単に有効/無効にすることができます。

- Value of `0`, called `Whitelist`, **disables** automatic update of all plugins, except those defined in `PluginsUpdateList`.
- Value of `1`, called `Blacklist`, **enables** automatic update of all plugins, except those defined in `PluginsUpdateList`.

**ASF team would like to remind you that, for your own safety, you should enable automatic updates only from trusted parties**. Keep in mind that malicious plugins can decide to update themselves or execute remote commands **regardless** of this setting, this is why this setting applies to ASF-provided plugins update functionality exclusively, and you should still ensure that you've appropriately verified every plugin that you've decided to use.

Updates of plugins are performed by default along with ASF update routine - **[`UpdateChannel`](#updatechannel)** and **[`UpdatePeriod`](#updateperiod)**. `update` コマンドのような標準の ASF 更新メカニズムも、オプションのプラグインの更新をトリガーします。 代わりに、同時にASFバージョンを更新せずに手動でプラグインを更新したい場合は、 `updateplugins` コマンドがそのような可能性を提供します。

このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



### `ShutdownIfPossible`

`bool` type, デフォルト値 `false`. 有効にすると、ASFはプロセスをシャットダウンしようとします。つまり、登録済みのボットがすべて停止した場合です。 これは、すべてのボットインスタンスで `シャットダウンOnFarmingFinished` と組み合わせると特に便利です。 この方法により、最後の1つのボットが農業を終了すると、ASFは自動的にシャットダウンされます。

ユーザーの大多数の期待は、常にプロセスを実行することですので、 e. を選択します。 `IPC` の場合、このオプションはデフォルトで無効になります。



---



### `SteamMessagePrefix`

`文字列` type, デフォルト値は `"/me "`. このプロパティは、ASFによって送信されるすべてのSteamメッセージの前に付加されるプレフィックスを定義します。 デフォルトでASFは、ボットメッセージをSteamチャットに別の色で表示することでより簡単に区別するために、 `"/me "` プレフィックスを使用します。 もう一つの価値のある言及は、 `"/pre "` プレフィックスであり、同様の結果を達成しますが、異なる書式設定を使用します。 また、このプロパティを空の文字列または `null` に設定することで、プレフィックスを完全に無効にし、従来の方法ですべての ASF メッセージを出力することもできます。 このプロパティはSteamメッセージにのみ影響します。他のチャネル(IPCなど)を通じて返される応答は影響を受けません。 標準のASFの動作をカスタマイズする場合を除き、デフォルトのままにすることをお勧めします。



---



### `SteamOwnerID`

`ulong` type with default value of `0 0`. このプロパティは、ASFプロセスオーナーの64ビット形式のSteam IDを定義します そして、指定されたボットインスタンスの `マスター` 権限に非常によく似ています(代わりにグローバル)。 ほとんどの場合、自分のSteamアカウントのIDにこのプロパティを設定します。 `Master` permission includes full control over his bot instance, but global commands such as `exit`, `restart` or `update` are reserved for `SteamOwnerID` only. あなたの友人のためにボットを実行したいと思うかもしれないので、これは便利です。 `exit` コマンドで終了するなど、ASFプロセスを制御することはできません。 デフォルト値 `0` は、ASF プロセスの所有者がないことを指定します。 つまり、誰もグローバルASFコマンドを発行できないということです。 このプロパティはSteamチャットにのみ適用されることに留意してください。 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, as well as interactive console, will still allow you to execute `Owner` commands even if this property is not set.



---



### `SteamProtocols`

`バイトフラグ` type with default value of `7`. このプロパティは、Steamサーバーへの接続時にASFが使用するSteamプロトコルを定義します。これは以下のように定義されています。

| 値 | 名前        | 説明                                                                           |
| - | --------- | ---------------------------------------------------------------------------- |
| 0 | 無し        | No protocol                                                                  |
| 1 | TCP       | **[伝送制御プロトコル](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2 | UDP       | **[ユーザーデータグラムプロトコル](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**  |
| 4 | WebSocket | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                     |


このプロパティは `フラグ` フィールドであることに注意してください。したがって、使用可能な値の任意の組み合わせを選択することができます。 詳細については、 **[json mapping](#json-mapping)** をご覧ください。 `None` オプションを有効にしないと、そのオプション自体が無効になります。

デフォルトでは、ASFは利用可能なすべてのSteamプロトコルをダウンタイムや他の同様のSteam問題との戦いの手段として使用します。 通常、ASFを特定のプロトコル1つまたは2つだけに制限したい場合は、このプロパティを変更する必要があります。 Such measures could be needed in various situations, for example if you've blocked UDP traffic on your firewall and you want to ensure only TCP traffic goes through, or if you're using `WebProxy` and want to use it also for Steam client connection, as only `WebSocket` protocol supports that.

このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



### `UpdateChannel`

`バイト` 型のデフォルト値は `1` です。 このプロパティは使用されている更新チャンネルを定義します。 自動更新（ `更新期間` が `0`より大きい場合）、または通知の更新 (そうでなければ) のいずれかです。 Currently ASF supports three update channels - `0` which is called `None`, `1`, which is called `Stable`, and `2`, which is called `PreRelease`. `安定版` チャンネルはデフォルトのリリースチャンネルで、大多数のユーザーが使用する必要があります。 `PreRelease` channel in addition to `Stable` releases, also includes **pre-releases** dedicated for advanced users and other developers in order to test new features, confirm bugfixes or give feedback about planned enhancements. **PreRelease versions often contain unpatched bugs, work-in-progress features or rewritten implementations**. 自分自身を上級者とみなさない場合は、デフォルトの `1` (`Stable`) チャンネルを更新してください。 `プレリリース` チャンネルは、バグを報告する方法を知っているユーザーに専用されています。 問題に対処し、フィードバックを与える - 技術サポートは与えられません。 詳細については、ASF **[リリースサイクル](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** をご覧ください。 すべてのバージョンチェックを完全に削除する場合は、 `UpdateChannel` を `0` (`None`) に設定することもできます。 `UpdateChannel` を `0 に設定する` は、 `update` コマンドを含む、アップデートに関連する全機能を完全に無効にします。 `なし` チャンネルを使用すると、あらゆる種類の問題に自分自身をさらすことができなくなります（以下の **UpdatePeriod** 記述で述べられています）。 `` チャンネルは強く推奨されません。

**Unless you know what you're doing**, we **strongly** recommend to keep it at default.



---



### `更新期間`

`バイト` 型のデフォルト値は `24` です。 このプロパティは、ASFが自動更新をチェックする頻度を定義します。 新機能や重要なセキュリティパッチを受け取るだけでなく、バグ修正、パフォーマンスの向上、安定性の向上などを受け取るためにもアップデートは重要です。 When a value greater than `0` is set, ASF will automatically download, replace, and restart itself (if `AutoRestart` permits) when new update is available. これを達成するために、GitHubリポジトリで新しいアップデートが利用可能である場合、ASFはすべての `UpdatePeriod` 時間をチェックします。 `0 0` の値は自動更新を無効にしますが、 `update` コマンドは手動で実行できます。 `UpdateChannel` の適切な `UpdatePeriod` の設定にも関心があるかもしれません。

ASFの更新プロセスには、ASFが使用しているフォルダ構造全体の更新が含まれます。 しかし、 `config` ディレクトリにある独自の設定やデータベースに触れることなく、そのディレクトリ内の ASF に関係のない追加ファイルは更新中に失われる可能性があります。 `24` のデフォルト値は、不要な小切手と、十分に新鮮なASFのバランスが良いです。

Unless you have a **strong** reason to disable this feature, you should keep auto-updates enabled within reasonable `UpdatePeriod` **for your own good**. これは、最新の安定版ASFリリースをサポートしていないためだけではありません。 しかし、 **は最新バージョン**のみのセキュリティ保証を提供しています。 If you're using outdated ASF version then you're intentionally exposing yourself to all kind of issues, from small bugs, through broken functionality, ending with **[permanent Steam account suspensions](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**, so we **strongly recommend**, for your own good, to always ensure that your ASF version is up to date. 自動アップデートを使用すると、問題のあるコードをエスカレートする前に無効化またはパッチ適用することで、あらゆる種類の問題に迅速に対応できます。オプトアウトした場合。 危険にさらされる可能性のあるコードを実行することで我々のセキュリティ保証とリスクの結果をすべて失うのです Steamネットワークだけでなく、(定義によって)Steamアカウントにも。



---



### `WebLimiterDelay`

`ushort` タイプで、デフォルト値は `300` です。 このプロパティは、同じ Steam Web-service に 2 つの連続したリクエストを送信する間の最小の遅延時間をミリ秒単位で定義します。 このような遅延は、Steamが内部で使用する **[Akamai JP](https://www.akamai.com)** サービスとして要求されます。特定の期間を通じて送信されるリクエストのグローバルな数に基づいてレート制限が含まれます。 通常の状況では、akamaiブロックはかなり達成するのは難しいですが、非常に重いワークロードの下で、リクエストの巨大な進行中のキューを持っています。 あまりに短期間に大量のリクエストを送信し続けるとトリガーすることができます

Default value was set based on assumption that ASF is the only tool accessing Steam web-services, in particular `steamcommunity.com`, `api.steampowered.com` and `store.steampowered.com`. If you're using other tools sending requests to the same web-services then you should make sure that your tool includes similar functionality of `WebLimiterDelay` and set both to double of default value, which would be `600`. これにより、 `300` ミリ秒あたり1回以上リクエストを送信することを超えることがないことが保証されます。

一般的に `WebLimiterDelay` をデフォルト値で下げると、 **強く推奨しない** は、さまざまな IP 関連ブロックにつながる可能性があります。 その中には永続的なものもあります デフォルト値は、サーバー上で単一のASFインスタンスを実行するのに十分です。 オリジナルのSteamクライアントと一緒に通常のシナリオでASFを使用するだけでなく。 それは大部分の使用のために正しいべきであり、あなたはそれを増やすだけでなければなりません (それを下げないでください)。 要するに、 単一のIPから単一のSteamドメインに送信されるすべてのリクエストのグローバル数は、 `300` msあたり1回以上のリクエストを超えてはなりません。

このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



### `WebProxy`

`文字列` 型のデフォルト値は `null` です。 This property defines a web proxy address that will be used for internal http-related communication, especially to services such as `github.com`, `api.steampowered.com`, `steamcommunity.com` and `store.steampowered.com`. 同等の `WebProxy` 設定プロパティが設定されていない場合は、一般的な(ボットに固有の)通信と、ボット固有の通信に適用されます。 ASFリクエストをプロキシすることは、さまざまな種類のファイアウォール、特に中国のグレートファイアウォールをバイパスするのに非常に有用です。

このプロパティは uri 文字列として定義されています:



> URI の文字列は、(サポートされている: http/https/socks4/socks4a/socks5)、ホスト、およびオプションのポートで構成されています。 完全な uri 文字列の例は `"http://contoso.com:8080"` です。

プロキシがユーザー認証を必要とする場合は、 `WebProxyUsername` または `WebProxyPassword` も設定する必要があります。 そのような必要がない場合は、このプロパティだけを設定するだけで十分です。

If you require proxying internal Steam network communication (CMs) as well, then you should ensure to configure **[`SteamProtocols`](#steamprotocols)** bot's property to a value that allows only websocket transport, i.e. a value of `4`, as only websockets are supported for proxying.

このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



### `WebProxyPassword`

`文字列` 型のデフォルト値は `null` です。 このプロパティは、基本、ダイジェスト、NTLMで使用されるパスワードフィールドを定義します。 そして、プロキシ機能を提供するターゲット `WebProxy` マシンによってサポートされているKerberos 認証。 プロキシがユーザーの資格情報を必要としない場合は、ここに何も入力する必要はありません。 このオプションを使用すると、 `WebProxy` も同様に使用されている場合にのみ意味があります。

このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



### `WebProxyUsername`

`文字列` 型のデフォルト値は `null` です。 このプロパティは、基本、ダイジェスト、NTLMで使用されるユーザー名フィールドを定義します。 そして、プロキシ機能を提供するターゲット `WebProxy` マシンによってサポートされているKerberos 認証。 プロキシがユーザーの資格情報を必要としない場合は、ここに何も入力する必要はありません。 このオプションを使用すると、 `WebProxy` も同様に使用されている場合にのみ意味があります。

このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



## ボット設定

既に知っているはずですが、下記の例に基づいて、すべてのボットが独自の設定を持っているはずです。 Start from deciding how you want to name your bot (e.g. `1.json`, `main.json`, `primary.json` or `AnythingElse.json`) and head over to configuration.

**お知らせ：** Botは `ASF` (そのキーワードはグローバル設定用に予約されています) ASFは、ドットで始まるすべての設定ファイルも無視します。

Botの設定は以下の構造を持っています:



```json
{
    "AcceptGifts": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Enabled": false,
    "FarmingOrders": [],
    "FarmingPreferences": 0,
    "GamesPlayedWhileIdle": [],
    "GamingDeviceType": 1,
    "HoursUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "MachineName": null,
    "MatchableTypes": [5],
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "RedeemingPreferences": 0,
    "RemoteCommunication": 3,
    "SendTradePeriod": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "TransferableTypes": [1, 3, 5],
    "UseLoginKeys": true,
    "UserInterfaceMode": 0,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```




---

すべてのオプションについて以下に説明します。



### `ギフトを受け取ってください`

`bool` type, デフォルト値 `false`. 有効にすると、ASFは自動的にボットに送られたすべてのスチームギフト(ウォレットギフトカードを含む)を受け入れ、引き換えます。 これには、 `SteamUserPermissions` で定義されている以外のユーザーから送られたギフトも含まれます。 電子メールアドレスに送信された贈り物はクライアントに直接転送されることはありませんので、ASFはあなたの助けなしにそれらを受け入れません。

このオプションは代替アカウントにのみ推奨されます プライマリアカウントに送られたギフトを自動的に引き換えたくない可能性があります。 この機能を有効にするかどうかが不明な場合は、デフォルト値の `false` を維持します。



---



### `BotBehaviour`

`バイトフラグ` type, デフォルト値 `0`. このプロパティは、さまざまなイベントでのASFボットのような振る舞いを定義し、以下のように定義されています。

| 値  | 名前                            | 説明                                     |
| -- | ----------------------------- | -------------------------------------- |
| 0  | 無し                            | 特別なBotの動作はありません。デフォルト設定は正常です。          |
| 1  | RejectInvalidFriendInvites    | ASFが無効な友達招待を拒否する（無視する代わりに）原因となります      |
| 2  | RejectInvalidTrades           | ASFが無効な取引オファーを拒否する原因となります（無視する代わりに）    |
| 4  | RejectInvalidGroupInvites     | ASFが無効なグループ招待を拒否する（無視する代わりに）原因となります    |
| 8  | DismissInventoryNotifications | ASFはインベントリ通知を自動的に削除します                 |
| 16 | MarkReceivedMessagesAsread    | ASFは受信したすべてのメッセージを既読として自動的にマークします      |
| 32 | MarkBotMessagesAsread         | ASFが他のASFボットからのメッセージを読み取りとして自動的にマークします |
| 64 | DisableIncomingTradesParsing  | ASFが入ってくるトレードオファーを処理しない原因となります         |


このプロパティは `フラグ` フィールドであることに注意してください。したがって、使用可能な値の任意の組み合わせを選択することができます。 詳細については、 **[json mapping](#json-mapping)** をご覧ください。 `None` オプションでフラグを有効にしません。

一般的に、ボットのアクティビティに関連するさまざまなオートメーション設定を変更する場合は、このプロパティを変更します。 デフォルトの設定では、非侵襲モードでASFが実行されるため、ユーザーの意志に反しない有益な自動化のみが可能です。

無効な友達招待は、 `FamilySharing` パーミッション（ `SteamUserPermissions`で定義）以上のユーザーからの招待ではありません。 通常モードのASFは、あなたが期待するように招待を無視し、受け入れるかどうかを自由に選択できます。 `RejectInvalidFriendInvites` will cause those invites to be automatically rejected, which will practically disable option for other people to add you to their friend list (as ASF will deny all such requests, apart from people defined in `SteamUserPermissions`). すべての友人招待を拒否したい場合を除き、このオプションを有効にするべきではありません。

無効なトレードオファーは、組み込みASFモジュールを通じて受け入れられないオファーです。 この問題についての詳細は、 **[Trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** セクションで見つけることができます。このセクションでは、ASFが自動的に受け入れる取引の種類を明示的に定義します。 Valid trades are also defined by other settings, especially `TradingPreferences`. `RejectInvalidTrades` はすべての無効なトレードオファーを無視する代わりに拒否されます。 ASFによって自動的に受け入れられていないすべてのトレードオファーを完全に拒否したい場合を除き、このオプションを有効にするべきではありません。

無効なグループ招待は、 `SteamMasterClanID` グループからの招待ではありません。 通常モードのASFは、予想通りグループ招待を無視します。 あなたが特定のスチームグループに参加するかどうかを自分で決めることを許可します。 `RejectInvalidGroupInvites` will cause all those group invites to be automatically rejected, effectively making it impossible to invite you to any other group than `SteamMasterClanID`. すべてのグループ招待を完全に拒否したい場合を除き、このオプションを有効にするべきではありません。

`DismissInventoryNotifications` は、新しいアイテムの受信に関する常にSteamの通知に悩まされ始めたときに非常に便利です。 ASFはSteamクライアントに組み込まれているため、通知自体を取り除くことはできません。 通知を受け取った後に自動的に消去することができます。通知はもはや「在庫の新しいアイテム」の通知を残すことはありません。 あなたが自分自身を評価することを期待した場合 すべての受信されたアイテム (特にASFで養殖カード)、その後、当然、このオプションを有効にするべきではありません。 あなたが狂ったことを始めるとき、これはオプションとして提供される覚えておいてください。

`MarkReceivedMessagesAsRead` は、ASFが実行中のアカウントで受信したすべての **すべての** メッセージを自動的にマークします プライベートでもグループでも読まれています これは通常、ASFコマンドの実行中にあなたからの「新しいメッセージ」通知をクリアするためにのみaltアカウントで使用する必要があります。 We do not recommend this option for primary accounts, unless you want to cut yourself from any kind of new messages notifications, **including** those that happened while you were offline, assuming that ASF was still left open dismissing it.

`MarkBotMessagesAsRead` は、ボットメッセージのみを既読にすることで同様の方法で動作します。 However, keep in mind that when using that option on group chats with your bots and other people, Steam implementation of acknowledging chat message **also** acknowledges all messages that happened **before** the one you decided to mark, so if by any chance you don't want to miss unrelated message that happened in-between, you typically want to avoid using this feature. 明らかに、複数のプライマリアカウントを持っている場合にもリスクがあります(例: 同じASFインスタンスで実行されている場合、通常のASFメッセージを見逃すこともできます。

`DisableIncomingTradesParsing` は、ASFが入ってくる取引オファーを解析するのを止めます。つまり、それに関連する取引機能全体が非オペレーショナルであることを意味します。 ASFはデフォルトで最小侵襲モードで動作するため、 `Master` 以上のユーザーからのトレードオファーのみ受け付けます。 他の取引オファーに触れることはありません - 受信取引の解析はデフォルトで有効になります。 この設定は、取引のパースに関連する追加のリクエスト/オーバーヘッドを確実にしないようにしたい人にとって最も理にかなっており、処理中のロジック全体を無効にします。 例えば彼らはロボットがマスタートレード要求を受け取れないことを知っているからです したがって、ASFが取引活動に参加する必要はありません。 このオプションを指定すると、受信取引に依存する他のすべてのオプションも無効になることに注意してください。 例えば、 `AcceptDonations` または `SteamTradeMatcher` - カスタムプラグインも通常の方法で受信取引オファーを処理することができません。

このオプションを設定する方法がわからない場合は、デフォルトのままにすることをお勧めします。



---



### `CompleteTypesToSend`

`ImmutableHashSet<byte>` 型はデフォルト値が空です。 ASFがここで指定されたアイテムタイプのセットを完了させることで完了すると、 `マスター` 権限を持つユーザーに、完成したすべてのセットとの蒸気取引を自動的に送信できます。 特定のボットアカウントをeに利用したい場合はとても便利です をクリックします。 This option works the same as `loot` command, therefore keep in mind that it requires user with `Master` permission set, you may also need a valid `SteamTradeToken`, as well as using an account that is eligible for trading in the first place.

この設定では、現在以下のアイテムタイプがサポートされています。

| 値 | 名前              | 説明                                         |
| - | --------------- | ------------------------------------------ |
| 3 | FoilTradingCard | `TradingCard`                              |
| 5 | TradingCard     | スチームトレーディングカード。バッジをクラフトするために使用されます（フォイル以外） |


Please note that regardless of the settings above, ASF will only ask for **[Steam community items](https://steamcommunity.com/my/inventory/#753_6)** (`appID` of 753, `contextID` of 6), so all game items, gifts and likewise, are excluded from the trade offer by definition.

Due to additional overhead of using this option, it's recommended to use it only on bot accounts that have a realistic chance of finishing sets on their own - for example, it makes no sense to activate if you're already using `SendOnFarmingFinished` preference in `FarmingPreferences`, `SendTradePeriod` or `loot` command on usual basis. 

このオプションを設定する方法がわからない場合は、デフォルトのままにすることをお勧めします。



---



### `CustomGamePlayedWhileFarming`

`文字列` 型のデフォルト値は `null` です。 ASFが農業をしている場合、現在農業を営んでいるゲームではなく、「非スチームゲームをプレイする: `CustomGamePlayedWhileFarming`」と表示することができます。 これは、あなたが農業をしていることを友達に知らせたい場合に便利です。 しかし、 `オフライン` の `OnlineStatus`を使用したくありません。 ASFはSteamネットワークの実際の表示順序を保証できませんのでご注意ください。 したがって、これは適切に表示されるかもしれない、またはそうでないかもしれない提案に過ぎません。 特に、 ASFがすべての `` `32` スロットをバンプされるまでに時間がかかるゲームで埋めた場合、カスタム名はAformat@@4複雑なAformat@@5ファーミングアルゴリズムには表示されません。 デフォルト値の `null` はこの機能を無効にします。

ASFには、テキストでオプションで使用できる特殊変数がいくつか用意されています。 `{0}` will be replaced by ASF with `AppID` of currently farmed game(s), while `{1}` will be replaced by ASF with `GameName` of currently farmed game(s). 



---



### `CustomGamePlayedWhileIdle`

`文字列` 型のデフォルト値は `null` です。 `CustomGamePlayedWhileFarming`と同様ですが、ASFには何もしていない状況(アカウントは完全に遠いです)。 ASFはSteamネットワークの実際の表示順序を保証できませんのでご注意ください。 したがって、これは適切に表示されるかもしれない、またはそうでないかもしれない提案に過ぎません。 If you're using `GamesPlayedWhileIdle` together with this option, then keep in mind that `GamesPlayedWhileIdle` get priority, therefore you can't declare more than `31` of them, as otherwise `CustomGamePlayedWhileIdle` will not be able to occupy the slot for custom name. デフォルト値の `null` はこの機能を無効にします。



---



### `有効`

`bool` type, デフォルト値 `false`. このプロパティは、ボットが有効になっているかどうかを定義します。 Enabled bot instance (`true`) will automatically start on ASF run, while disabled bot instance (`false`) will need to be started manually. デフォルトでは、すべてのボットは無効化されています したがって、自動的に開始されるすべてのボットに対して、このプロパティを `true` に切り替えることをお勧めします。



---



### `農業注文`

`ImmutableList<byte>` 型はデフォルト値が空です。 このプロパティは、特定のボットアカウントにASFが使用する **優先的な** 農業注文を定義します。 現在、以下の農業受注があります。

| 値  | 名前                       | 説明                                                  |
| -- | ------------------------ | --------------------------------------------------- |
| 0  | 注文なし                     | ソートなし、CPUパフォーマンスが少し向上します                            |
| 1  | AppIDsAscending          | Try to farm games with lowest `appIDs` first        |
| 2  | AppIDの降順                 | 最も高い `アプリID` でゲームをファームしてみてください                      |
| 3  | CardDrops昇順              | カードドロップ数が最も少ないゲームを最初にファームしてみてください                   |
| 4  | CardDrops降順              | カードドロップ数が最も高いゲームを最初にファームしてみてください                    |
| 5  | 時間の昇順                    | 最初に再生時間の最小数のゲームをファームしてみてください                        |
| 6  | HoursDescending          | 最も多くの時間が最初に再生されたゲームをファームしてみてください                    |
| 7  | 名前昇順                     | Aから始まるアルファベット順にゲームをファームしてみてください                     |
| 8  | 名前の降順                    | 逆アルファベット順のゲームをZから始めてファームします。                        |
| 9  | Random                   | 完全にランダムな順序でゲームをファームしてみてください（プログラムの実行ごとに異なります）       |
| 10 | バッジレベル昇順                 | バッジレベルが最も低いゲームを最初にファームしてみてください                      |
| 11 | バッジレベルの降順                | 最高のバッジレベルで最初にゲームをファームしてみてください                       |
| 12 | RedeemDateTimesAscending | 最初にアカウントで最も古いゲームをファームしてみてください                       |
| 13 | 交換日時の降順                  | 最初にアカウントで最新のゲームをファームしてみてください                        |
| 14 | マーケットテーブル昇順              | 市場性のないカードが最初にドロップされているゲームをファームしてみてください（警告：計算には高価です） |
| 15 | マーケットの降順                 | 市場性の高いカードが最初にドロップされているゲームをファームしてみてください（警告：計算には高価です） |


このプロパティは配列であるため、固定された順序で複数の異なる設定を使用できます。 For example, you can include values of `15`, `11` and `7` in order to sort by marketable games first, then by those with highest badge level, and finally alphabetically. As you can guess, the order actually matters, as reverse one (`7`, `11` and `15`) achieves something entirely different (sorts games alphabetically first, and due to game names being unique, the other two are effectively useless). 大多数の人々は、おそらくそれらのすべてのうち1つの注文を使用するでしょう。 しかし、必要に応じて、追加のパラメータでさらに並べ替えることもできます。

また、上記のすべての説明で「try」という単語に注目してください。実際のASF注文は、選択された **[カードファーミングアルゴリズム](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** によって大きく影響されます。そして、ソートは、ASFが同じパフォーマンスを賢明と考える結果にのみ影響します。 For example, in `Simple` algorithm, selected `FarmingOrders` should be entirely respected in current farming session (as every game has the same performance value), while in `Complex` algorithm actual order is affected by hours first, and then sorted according to chosen `FarmingOrders`. This will lead to different results, as games with existing playtime will have a priority over others, so effectively ASF will prefer games that already passed required `HoursUntilCardDrops` firstly, and only then sorting those games further by your chosen `FarmingOrders`. 同様に、ASFはすでにバンプされたゲームがなくなったら。 残りのキューを最初に並べ替えます(残りのタイトルを `HoursUntilCardDrops` にバンプするのに必要な時間が短縮されます)。 Therefore, this config property is only a **suggestion** that ASF will try to respect, as long as it doesn't affect performance negatively (in this case, ASF will always prefer farming performance over `FarmingOrders`).

`fq` **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** からアクセス可能な農業優先列もあります。 それが使用されている場合は、実際の農業順序は、パフォーマンスによって、次に農業列、そして最後にあなたの `農業注文`によってソートされます。



---



### `農業環境設定`

`バイトフラグ` type, デフォルト値 `0`. このプロパティは、農業に関連するASFの動作を定義し、以下のように定義されます。

| 値   | 名前                        |
| --- | ------------------------- |
| 0   | 無し                        |
| 1   | FarmingPausedByDefault    |
| 2   | ShutdownOnFaringFinished  |
| 4   | SendOnFarmingFinished     |
| 8   | FarmPriorityQueueOnly     |
| 16  | SkipRefundableGames       |
| 32  | SkipUnplayedGames         |
| 64  | EnableRiskyCardsDiscovery |
| 256 | AutoUnpackBoosterPacks    |


このプロパティは `フラグ` フィールドであることに注意してください。したがって、使用可能な値の任意の組み合わせを選択することができます。 詳細については、 **[json mapping](#json-mapping)** をご覧ください。 `None` オプションでフラグを有効にしません。

すべてのオプションについて以下に説明します。

`FarmingPausedByDefault` は、 `CardsFarmer` モジュールの初期状態を定義します。 通常、ボットは、 `有効` または `開始` コマンドのいずれかのために、開始時に自動的に農業を開始します。 Using `FarmingPausedByDefault` can be used if you want to manually `resume` automatic farming process, for example because you want to use `play` all the time and never use automatic `CardsFarmer` module - this works exactly the same as `pause` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

`ShutdownOnFarmingFinished` は、農業が終わったらボットをシャットダウンすることができます。 通常、ASFはプロセスがアクティブである全体の間、アカウントを「占有」しています。 指定されたアカウントが農業で終了すると、ASFは定期的にそのアカウントをチェックします( `IdleFarmingPeriod` 時間ごとに)。 スチームカードの新しいゲームが追加されたら 再起動することなく口座の農業を再開することができます これは、ASFが必要に応じて自動的に農業を再開することができるため、大多数の人に役立ちます。 しかし、あなたは実際には、特定のアカウントが完全に養殖されている場合には、プロセスを停止したい場合があります, あなたは、このフラグを使用してそれを達成することができます. 有効にすると、アカウントが完全に養殖されているときにASFはログオフを続行します。これは定期的にチェックされたり占有されたりしないことを意味します。 ASFを使用する場合は、特定のボットインスタンスでずっと作業することをお勧めします。 または、農業プロセスが完了するとASFがそれを停止する必要がある場合。

このオプションは、 `ShutdownIfPossible`と組み合わせることが最も理にかなっています。 すべてのアカウントが停止されると、ASFもシャットダウンします マシンを安静にして他の動作をスケジュールすることができます スリープやシャットダウンなど 最後のカードが落ちた瞬間と同じです

`SendOnFarmingFinished` を使用すると、 `マスター` 権限を持つユーザーに、この時点まで養殖されたすべての蒸気取引を自動的に送信できます。 自分で取引をしたくないならとても便利だ This option works the same as `loot` command, therefore keep in mind that it requires user with `Master` permission set, you may also need a valid `SteamTradeToken`, as well as using an account that is eligible for trading in the first place. In addition to initiating `loot` after finishing farming, ASF will also initiate `loot` on each new items notification (when not farming), and after completing each trade that results in new items (always) when this option is active. これは、他の人から受け取ったアイテムを私たちのアカウントに「転送」する場合に特に便利です。 通常、この機能と一緒に、 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** を使用します。 2FA確認をタイムリーに手動で処理する場合は要件ではありませんが。

`FarmPriorityQueueOnly` は、 `fq` **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** で利用可能な優先農業キューにあなた自身を追加したアプリのみをASFが考慮すべきかどうかを定義します。 このオプションを有効にすると、ASFはリストに欠けているすべての `appID` をスキップします。 効果的に自動ASF農業のためのチェリーピックゲームを可能にします。 キューにゲームを追加しなかった場合、ASFはアカウントにファームするものがないように動作することに注意してください。

`SkipRefundableGames` は、ASFが自動農業から払い戻し可能なゲームをスキップするかどうかを定義しています。 返金可能なゲームは、Steamストアで過去2週間購入し、まだ2時間以上プレイしていないゲームです。 **[Steam refunds](https://store.steampowered.com/steam_refunds)** page. デフォルトでは、ほとんどの人が期待するように、ASFはSteamの払い戻しポリシーを完全に無視し、すべてを耕作します。 ただし、ASFが払い戻し可能なゲームをすぐにファームしすぎないようにしたい場合は、このフラグを使用できます。 ASFがプレイタイムに悪影響を及ぼすことを心配することなく、必要に応じて自分でゲームを評価し、返金することができます。 このオプションを有効にすると、Steamストアから購入したゲームはASFの日付から最大14日間は発生しませんのでご注意ください。 あなたのアカウントが他に何も持っていない場合は農場には何も表示されません

`SkipUnplayedGames` は、ASFがまだ起動していないゲームをスキップすべきかどうかを定義しています。 この文脈で再生されていないゲームは、Steamで再生時間を記録していないことを意味します。 このフラグを使用する場合、Steamがプレイタイムを登録するまで、そのようなゲームはスキップされます。 これにより、ASFがどのゲームをファームする資格があるかをコントロールし、まだ試すことができなかったゲームをスキップできます。 選択したSteam機能をより便利に保つこと - 再生されていないゲームを提案するなど。

`EnableRiskyCardsDiscovery` は、ASFが1つまたは複数のバッジページを読み込むことができない場合に、追加のフォールバックを可能にし、したがって、農業で利用可能なゲームを見つけることができません。 特に、膨大な数のカードドロップがあるアカウントでは、バッジページの読み込みが不可能になった場合があります(オーバーヘッドが原因)。 その口座は農業では不可能ですプロセスを始められる情報を読み込むことができないからです これらの一握りの場合、このオプションは代替アルゴリズムを使用することを可能にします。 ブースターを組み合わせて作成しブースターパックを使ってアカウントの対象となります アイドルできるかもしれないゲームを見つけるために 必要な情報を検証・取得するために多額のリソースを費やし 限られた量のデータと情報で農業のプロセスを開始しようとするとバッジページが読み込まれる状況に到達し 通常のアプローチを利用できるようになります このフォールバックを使用すると、ASFは限られたデータでのみ動作することに注意してください。 したがって、ASFが実際よりもはるかに少ない落下を見つけるのは完全に普通です - 他の落下は、農業プロセスの後の段階で発見されます。

This option is called "risky" for a very good reason - it's extremely slow and requires significant amount of resources (including network requests) for operation, therefore it's **not recommended** to be enabled, and especially in long-term. このオプションは、アカウントがバッジページを読み込むことができず、ASFが操作できないと以前に判断した場合にのみ使用してください。 プロセスを開始するために必要な情報を常に読み込むことができません たとえできるだけプロセスを最適化するために最善を尽くしたとしても、 この選択肢はまだ不必要な結果を引き起こす可能性があります 一時的なものや、リクエストが多すぎたり、Steamサーバーのオーバーヘッドを引き起こしたりするためにSteam側からの永久的なBANなどです。 したがって、我々は事前に警告し、我々は絶対に保証なしでこのオプションを提供しています, あなたはあなた自身のリスクでそれを使用しています.

`AutoUnpackBoosterPack` は、新しいアイテムの通知を受信すると、自動的にすべてのブースターパックをアンパックします。 これにより、すぐに追加のカードドロップを取得することができます。 これは、特に他のオプションと組み合わせて望まれるシナリオかもしれません (e. `SteamTradeMatcher` または `CompleteTypesToSend`).



---



### `GamesPlayedWhileIdle`

`ImmutableHashSet<uint>` 型はデフォルト値が空です。 ASFにファームするものが何もない場合は、指定したスチームゲーム(`appID`)を代わりにプレイできます。 このような方法でゲームをプレイすると、それらのゲームのあなたの「時間」を増加させますが、それ以外の何ものでもありません。 In order for this feature to work properly, your Steam account **must** own a valid license to all the `appIDs` that you specify here, this includes F2P games as well. This feature can be enabled at the same time with `CustomGamePlayedWhileIdle` in order to play your selected games while showing custom status in Steam network, but in this case, like in `CustomGamePlayedWhileFarming` case, the actual display order is not guaranteed. Steamでは、 `32` `appID` 合計でのみASFを再生できます。 したがって、このプロパティでは、多くのゲームを置くことができます。



---



### `GamingDeviceType`

`ushort` タイプで、デフォルト値は `1` です。 このプロパティは、Steamプラットフォームでいくつかの追加のオンライン機能を有効にすることができ、以下のように定義されています。

| 値   | 名前         | 説明                 |
| --- | ---------- | ------------------ |
| 1   | StandardPC | 特殊モードなし、デフォルト      |
| 544 | SteamDeck  | Steamデッキとしてプレゼントする |


このプロパティに基づいている `EGamingDeviceType` 型には、使用可能な値が多く含まれています。 しかし我々の知る限り彼らは今日まで全く効果がありません

このプロパティの設定方法がわからない場合は、デフォルト値は `1`のままにしておいてください。



---



### `HoursUntililCarddrops`

`バイト` 型のデフォルト値は `3` です。 このプロパティは、アカウントにカードのドロップが制限されているかどうかを定義します。 制限されたカードドロップは、ゲームが少なくとも `時間UntilCarddrops` 時間プレイされるまで、特定のゲームからカードドロップを受け取ることができないことを意味します。 残念ながらそれを検出する魔法の方法はありませんので、ASFはあなたを頼りにしています。 このプロパティは、使用される **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** アルゴリズムを養殖するカードに影響を与えます。 このプロパティを適切に設定すると、利益を最大化し、カードの生産に必要な時間を最小限に抑えることができます。 あなたのアカウントに完全に依存するので、あなたが1つまたは別の値を使用するべきかどうかは明らかに答えがないことを覚えておいてください。 It seems that older accounts which never asked for refund have unrestricted card drops, so they should use a value of `0`, while new accounts and those who did ask for refund have restricted card drops with a value of `3`. ただし、これはあくまで理論であり、原則とすべきではない。 このプロパティのデフォルト値は、「小さい悪」に基づいて設定されており、大部分のユースケースが使用されています。



---



### `LootableTypes`

`ImmutableHashSet<byte>` type, default value of `1, 3, 5` steam item types. **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**を使用して、略奪時のASFの動作を定義します。 1つ以上の設定プロパティで自動化されています ASFは、 `LootableTypes` のアイテムのみがトレードオファーに含まれるようにします。 したがって、このプロパティは、あなたがあなたに送信されている取引オファーで受けたいものを選択することができます。

| 値  | 名前              | 説明                                         |
| -- | --------------- | ------------------------------------------ |
| 0  | 不明              | 以下のいずれかに適合しないすべてのタイプ                       |
| 1  | ブースターパック        | ゲーム中のランダムなカードが3枚入ったブースターパック                |
| 2  | 絵文字             | Steamチャットで使用する絵文字                          |
| 3  | FoilTradingCard | `TradingCard`                              |
| 4  | プロフィール背景        | あなたのSteamプロフィールで使用するプロフィールの背景              |
| 5  | TradingCard     | スチームトレーディングカード。バッジをクラフトするために使用されます（フォイル以外） |
| 6  | SteamGems       | ブースターのクラフトに使用されているスチームジェム、袋が含まれています        |
| 7  | SaleItem        | Steam販売中に獲得した特別アイテム                        |
| 8  | 消耗品数            | 使用後に消える消耗品。                                |
| 9  | ProfileModifier | Steamプロフィールの外観を変更できる特別なアイテム                |
| 10 | ステッカー           | Steamチャットで使用できる特別なアイテム                     |
| 11 | ChatEffect      | Steamチャットで使用できる特別なアイテム                     |
| 12 | ミニプロファイル背景      | Steamプロフィールの特別な背景                          |
| 13 | アバタープロフィールフレーム  | Steamプロフィール用の特別なアバターフレーム                   |
| 14 | AnimatedAvatar  | Steamプロフィール用の特別なアニメーションアバター                |
| 15 | キーボードスキン        | Steamデッキ用の特別なキーボードスキン                      |
| 16 | StartupVideo    | Steamデッキ用の特別なスタートアップビデオ                    |


Please note that regardless of the settings above, ASF will only ask for **[Steam community items](https://steamcommunity.com/my/inventory/#753_6)** (`appID` of 753, `contextID` of 6), so all game items, gifts and likewise, are excluded from the trade offer by definition.

デフォルトのASF設定は、ボットの最も一般的な使用法に基づいており、ブースターパックのみを略奪し、トレーディングカード(フォイルを含む)を使用しています。 ここで定義されたプロパティでは、満足する方法でその振る舞いを変更できます。 Please keep in mind that all types not defined above will show as `Unknown` type, which is especially important when Valve releases some new Steam item, that will be marked as `Unknown` by ASF as well, until it's added here (in the future release). That's why in general it's not recommended to include `Unknown` type in your `LootableTypes`, unless you know what you're doing, and you also understand that ASF will send your entire inventory in a trade offer if Steam Network gets broken again and reports all your items as `Unknown`. `Unknown` 型を `LootableTypes`に含めないことが私の強い提案です。たとえすべてを略奪することを期待している場合でも (そうでなければ) 。



---



### `マシン名`

`文字列` 型のデフォルト値は `null` です。 ASFはSteamネットワークにログインするときにこのプロパティを使用します スチームがASFマシンとセッションをどのように正確に表示するかに関して、カスタマイズに使用することができます。 をクリックします。 **[](https://store.steampowered.com/account/authorizeddevices)** にログインしているデバイスを表示するとき。

ASFには、テキストでオプションで使用できる特殊変数がいくつか用意されています。 `{0}` will be replaced by machine name as provided by your OS, `{1}` will be replaced by ASF's public identifier, while `{2}` will be replaced by ASF's version.

何をしているのかわからない限り、デフォルト値の `null` に保持する必要があります。 この場合、ASFは内部的に適切な値を決定します。これは、今日の `{0} ({1}/{2})` です。 これはSteamネットワークが完全に尊重する可能性がある、またはそうでない可能性がある提案のみであることに留意してください。



---



### `マッチ可能なタイプ`

`ImmutableHashSet<byte>` 型のデフォルト値は `5` Steamアイテム型です。 このプロパティは、 `TradingPreferences` の `SteamTradeMatcher` オプションが有効な場合に、どのSteamアイテムタイプをマッチさせることが許可されるかを定義します。 型は以下のように定義されている。

| 値  | 名前              | 説明                                         |
| -- | --------------- | ------------------------------------------ |
| 0  | 不明              | 以下のいずれかに適合しないすべてのタイプ                       |
| 1  | ブースターパック        | ゲーム中のランダムなカードが3枚入ったブースターパック                |
| 2  | 絵文字             | Steamチャットで使用する絵文字                          |
| 3  | FoilTradingCard | `TradingCard`                              |
| 4  | プロフィール背景        | あなたのSteamプロフィールで使用するプロフィールの背景              |
| 5  | TradingCard     | スチームトレーディングカード。バッジをクラフトするために使用されます（フォイル以外） |
| 6  | SteamGems       | ブースターのクラフトに使用されているスチームジェム、袋が含まれています        |
| 7  | SaleItem        | Steam販売中に獲得した特別アイテム                        |
| 8  | 消耗品数            | 使用後に消える消耗品。                                |
| 9  | ProfileModifier | Steamプロフィールの外観を変更できる特別なアイテム                |
| 10 | ステッカー           | Steamチャットで使用できる特別なアイテム                     |
| 11 | ChatEffect      | Steamチャットで使用できる特別なアイテム                     |
| 12 | ミニプロファイル背景      | Steamプロフィールの特別な背景                          |
| 13 | アバタープロフィールフレーム  | Steamプロフィール用の特別なアバターフレーム                   |
| 14 | AnimatedAvatar  | Steamプロフィール用の特別なアニメーションアバター                |
| 15 | キーボードスキン        | Steamデッキ用の特別なキーボードスキン                      |
| 16 | StartupVideo    | Steamデッキ用の特別なスタートアップビデオ                    |


Of course, types that you should use for this property typically include only `2`, `3`, `4` and `5`, as only those types are supported by STM. ASFにはアイテムの希少性を発見するための適切なロジックが含まれているため、顔文字や背景を合わせることも安全です。 ASFは、同じ希少性を持つ同じゲームとタイプのアイテムのみがフェアと見なされます。

**ASFはトレーディングボット** ではなく、 **は市場価格**を気にしないことに注意してください。 同じセットからの同じ希少性のアイテムを同じ価格帯であると考えない場合、このオプションはあなたのためではありません。 この設定を変更する前に、このステートメントを理解し、同意した場合は、再度評価してください。

何をしているのかわからない限り、デフォルト値は `5`です。



---



### `オンラインフラグ`

`` タイプのデフォルト値は `0` です。 このプロパティは、 **[`OnlineStatus`](#onlinestatus)** のサプリメントとして機能し、Steamネットワークに発表された追加のオンラインプレゼンス機能を指定します。 **[`OnlineStatus`](#onlinestatus)** `Offline`以外のformat@@6 </code> が必要で、以下のように定義されています:

| 値    | 名前                | 説明                             |
| ---- | ----------------- | ------------------------------ |
| 0    | 無し                | 特別なオンラインプレゼンスフラグなし、デフォルト       |
| 2    | InJoinableGame    | クライアントは参加可能なゲーム中です             |
| 8    | RemotePlayTotal   | クライアントは一緒にリモートプレイセッションを使用しています |
| 256  | ClientTypeWeb     | クライアントはWebインターフェイスを使用しています     |
| 512  | ClientTypeMobile  | クライアントはモバイルアプリを使用しています         |
| 1024 | ClientTypeTenfoot | クライアントは大きな画像を使用しています           |
| 2048 | ClientTypeVR      | クライアントは VR ヘッドセットを使用しています      |


このプロパティは `フラグ` フィールドであることに注意してください。したがって、使用可能な値の任意の組み合わせを選択することができます。 詳細については、 **[json mapping](#json-mapping)** をご覧ください。 `None` オプションでフラグを有効にしません。

このプロパティがベースになっている `EPersonaStateFlag` 型には、利用可能なフラグがより多く含まれています。 しかし我々の知る限り彼らは今日まで全く効果がありません

このプロパティの設定方法がわからない場合は、デフォルト値は `0 0`のままにしておいてください。



---



### `オンラインステータス`

`バイト` 型のデフォルト値は `1` です。 このプロパティは、Steamネットワークにログインした後にBotが発表されるSteamコミュニティのステータスを指定します。 現在、以下のステータスのいずれかを選択できます：

| 値 | 名前             |
| - | -------------- |
| 0 | オフライン          |
| 1 | オンライン          |
| 2 | 取り込み中          |
| 3 | 離席中            |
| 4 | スヌーズ           |
| 5 | LookingToTrade |
| 6 | LookingToPlay  |
| 7 | 非表示            |


`オフライン` ステータスはプライマリアカウントにとって非常に便利です。 知っておくべきであるように、ゲームを農業することは実際にあなたの蒸気の状態を示しています "ゲームをする:XXX" それは友人に誤解をもたらす可能性がありますゲームをしている間、実際に農業をしている間、それらを混乱させる可能性があります `オフライン` の状態で問題を解決します。ASFを使って蒸気カードを養殖している場合、アカウントは「ゲーム内」として表示されることはありません。 ASFがSteam コミュニティにサインインする必要がないので、これは可能です。 実際にはSteamネットワークに接続されていますが 私たちのオンラインプレゼンスを 発表することはありません オフライン状態を使用してプレイしたゲームはプレイ時間にカウントされ、プロフィールに「最近プレイした」と表示されることに注意してください。

それに加えて、ASFの実行中に通知や未読のメッセージを受信したい場合にもこの機能が重要です。 Steamクライアントを同時に開かせないようにしています これは、ASFがSteamクライアントとして機能し、ASFがそれを望むかどうかを判断するためです。 Steam はこれらのメッセージやその他のイベントをすべて配信します。 両方のクライアントがまったく同じイベントを受信しているため、ASFと独自のSteamクライアントの両方が実行されている場合は、これは問題ではありません。 ただし、ASFが実行されている場合、Steamネットワークは特定のイベントやメッセージを「配信済み」とマークする可能性があります。 あなたの従来のSteamクライアントにもかかわらず、存在しないためにそれを受け取っていません。 この場合、ASFはコミュニティイベントとみなされないため、オフラインステータスもこの問題を解決します。 未読のメッセージやその他のイベントはすべて、あなたが戻ってきたときに正しく未読とマークされます。

It's important to note that ASF running on `Offline` mode will **not** be able to receive commands in usual Steam chat way, as the chat, as well as entire community presence is in fact, entirely offline. この問題を解決するには、 `Invisible` モードを代わりに使用します。このモードでは同様の方法で動作します (ステータスを公開しません)。 しかし、メッセージを受信し、応答する機能を保持します (つまり、前述の通知や未読のメッセージを破棄する可能性もあります)。 `Invisible` モードは、公開したくない alt アカウントで (status-wise) が最も理にかなっています。 命令を送れるようになっています

しかし、 `Invisible` モードで 1 つのキャッチがあります。 **** 現在オンラインの **Steamセッションでは、ASF自体ではない場合でも、** ステータスが公開されるためです。 これは、ASF側で修正できないSteamネットワークの現在の制限/バグによって引き起こされます。 `Invisible` モードを使用する場合は、 **すべての** 他のセッションを `Invisible` モードも同様に使用することを確認する必要があります。 This will be the case on alt accounts where ASF is hopefully the only active session, but on primary accounts you'll almost always prefer to show as `Online` to your friends, hiding only ASF activity, and in this case `Invisible` mode will be entirely useless for you (we recommend to use `Offline` mode instead). うまくいけば、この制限/バグは最終的にValveによって解決されるでしょうが、すぐにそれが起こるとは思いません...

If you're unsure how to set up this property, it's recommended to use a value of `0` (`Offline`) for primary accounts, and default `1` (`Online`) otherwise.



---



### `パスワードフォーマット`

`バイト` 型のデフォルト値は `0` (`プレーンテキスト` ) です。 このプロパティは `SteamPassword` プロパティの形式を定義し、現在は **[セキュリティ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** セクションで指定された値をサポートしています。 指定された指示に従ってください `SteamPassword` プロパティに、 `PasswordFormat` に一致するパスワードが含まれていることを確認する必要があります。 つまり、 `PasswordFormat` を変更した場合、 `SteamPassword` は既に **** になるはずです。 目指すだけではなく 何をしているのかわからない限り、デフォルト値は `0 0`です。

If you decide to change `PasswordFormat` of a bot that has already logged in to Steam network at least once, it's possible that you'll get one-time decrypt error on the next bot's start - this is caused by the fact that `PasswordFormat` is also used in regards to automatic encryption/decryption of sensitive properties in `Bot.db` database file. ASFがこの状況から復旧できるため、このエラーは安全に無視できます。 ただし、それが一定の基準で起こっている場合、例えば各再起動は、それを調査する必要があります。



---



### `Redeeming環境設定`

`バイトフラグ` type, デフォルト値 `0`. このプロパティは、cd-keyを使用するときのASFの挙動を定義し、以下のように定義されています。

| 値 | 名前                                 | 説明                                                                                  |
| - | ---------------------------------- | ----------------------------------------------------------------------------------- |
| 0 | 無し                                 | 特別な引き換え設定なし、デフォルト                                                                   |
| 1 | 転送                                 | 他のボットと引き換えることができない転送キー                                                              |
| 2 | 配布                                 | それ自身と他のボットの間ですべてのキーを配布する                                                            |
| 4 | KeepMissingGames                   | 転送時に不足しているゲームのキーを保持し、未使用のままにする                                                      |
| 8 | AssumeWalletKeyOnBadActivationCode | `BadActivationCode` キーが `CannotRedeemCodeFromClient`と等しいと仮定して、ウォレットキーとして使用してみてください。 |


このプロパティは `フラグ` フィールドであることに注意してください。したがって、使用可能な値の任意の組み合わせを選択することができます。 詳細については、 **[json mapping](#json-mapping)** をご覧ください。 `None` オプションでフラグを有効にしません。

`転送` は、引き換えることができないキーを転送します。 接続されている別のボットにログインして、その特定のゲームが見つからない場合(可能であれば)です。 The most common situation is forwarding `AlreadyPurchased` game to another bot that is missing that particular game, but this option also covers other scenarios, such as `DoesNotOwnRequiredApp`, `RateLimited` or `RestrictedCountry`.

`` を配布すると、受信したすべての鍵がそれ自体と他のボット間で配布されます。 これは、すべてのボットがバッチから単一のキーを取得することを意味します。 通常、これは同じゲームで多くのキーを引き換える場合にのみ使用されます。 あなたはそれらをボット間で均等に配布したいと思っています。 それとは対照的に、様々なゲームのための鍵を交換する。 この機能は、 `` と引き換える1つのアクションで1つのキーのみを使うと意味がありません（配布する追加のキーはありません）。

`KeepMissingGames` は、キーが実際に私たちのボットによって所有されているかどうかを確認できない場合、 `転送` を飛ばします。 そうでなくても This basically means that `Forwarding` will apply **only** to `AlreadyPurchased` keys, instead of covering also other cases such as `DoesNotOwnRequiredApp`, `RateLimited` or `RestrictedCountry`. 通常、プライマリアカウントでこのオプションを使用します。 例えば、ボットが一時的に `RateLimited`になった場合、引き換えられるキーがさらに転送されないようにします。 説明からわかるように、 `転送` が有効になっていない場合、このフィールドは全く効果がありません。

`AssumeWalletKeyOnBadActivationCode` は `BadActivationCode` キーを `CannotRedeemCodeFromClient`として扱われます。 したがって、ASFはウォレットキーとしてそれらを引き換えようとします。 これはSteamが `BadActivationCode` （使用済みの `CannotRedeemCodeFromClient` ではない）としてウォレットキーを発表するために必要です。 その結果、ASFはそれらを償還しようとしませんでした。 However, we recommend **against** using this preference, as it'll result in ASF trying to redeem every invalid key as a wallet code, resulting in excessive amount of (potentially invalid) requests sent to the Steam service, with all the potential consequences. 代わりに、 `ForceAssumeWalletKey` **[`redeem^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** モードで、意図的にウォレットキーを引き換えることをお勧めします。 必要とされる回避策は必要とされる場合にのみ有効になります

Enabling both `Forwarding` and `Distributing` will add distributing feature on top of forwarding one, which makes ASF trying to redeem one key on all bots firstly (forwarding) before moving to the next one (distributing). Typically you want to use this option only when you want `Forwarding`, but with altered behaviour of switching the bot on key being used, instead of always going in-order with every key (which would be `Forwarding` alone). This behaviour can be beneficial if you know that majority or even all of your keys are tied to the same game, because in this situation `Forwarding` alone would try to redeem everything on one bot firstly (which makes sense if your keys are for unique games), and `Forwarding` + `Distributing` will switch the bot on the next key, "distributing" the task of redeeming new key onto another bot than the initial one (which makes sense if keys are for the same game, skipping one pointless attempt per key).

利用可能なすべてのシナリオの実際のボット順序はアルファベット順で、利用できないボット(接続されていない、停止されているなど)は除外されています。 IPアドレス毎とアカウントごとの一時間あたりの償還の制限があることに注意してください。 そして、 `OK` で終わらなかったすべての救援試行は、失敗した試行に寄与します。 ASFは、 `AlreadyPurchased` 失敗を最小限に抑えるために最善を尽くします。例えば、 すでにそのゲームを所有している別のボットへの鍵の転送を避けることで しかし、Steamがライセンスを扱っているため、必ずしも機能するとは限りません。 `転送` や `配布` のような引き換えフラグを使用すると、常に `RateLimited` に達する可能性が高くなります。

また、アクセスできないボットに鍵を転送したり配布したりすることはできません。 This should be obvious, but ensure that you're at least `Operator` of all the bots you want to include in your redeeming process, for example with `status ASF` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.



---



### `リモートコミュニケーション`

`byte flags` type with default value of `3`. このプロパティは、リモート、サードパーティのサービスとの通信に関して、ボットごとのASFの動作を定義し、以下のように定義されています。

| 値 | 名前         | 説明                                                                                                                                                                                                                                                                |
| - | ---------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0 | 無し         | サードパーティの通信が許可されていません。選択したASF機能は使用できません。                                                                                                                                                                                                                           |
| 1 | SteamGroup | **[ASFのSteamグループ](https://steamcommunity.com/groups/archiasf)** との通信を許可                                                                                                                                                                                           |
| 2 | 公開リスト      | Allows communication with **[ASF's STM listing](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** in order to being listed, if user has also enabled `SteamTradeMatcher` in **[`TradingPreferences`](#tradingpreferences)** |


このプロパティは `フラグ` フィールドであることに注意してください。したがって、使用可能な値の任意の組み合わせを選択することができます。 詳細については、 **[json mapping](#json-mapping)** をご覧ください。 `None` オプションでフラグを有効にしません。

このオプションには、ASFが提供するすべてのサードパーティの通信が含まれるわけではなく、他の設定によって暗示されていないもののみが含まれます。 たとえば、ASFの自動更新を有効にしている場合、ASFは構成に従ってGitHub(ダウンロード用)と当社のサーバー(チェックサム検証用)の両方と通信します。 同様に `` **[`TradingPreferences`](#tradingpreferences)** は、リストされたボットをフェッチするためのサーバーとの通信を意味します。 必要とされています

この件名についての詳細な説明は、 **[リモート通信](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** セクションにあります。 このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



### `送付期間`

`バイト` 型のデフォルト値は `0` です。 This property works very similar to `SendOnFarmingFinished` preference in `FarmingPreferences`, with one difference - instead of sending trade when farming is done, we can also send it every `SendTradePeriod` hours, regardless of how much we have to farm left. This is useful if you want to `loot` your alt accounts on usual basis instead of waiting for it to finish farming. Default value of `0` disables this feature, if you want your bot to send you trade e.g. every day, you should put `24` here.

通常、この機能と一緒に、 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** を使用します。 2FA確認をタイムリーに手動で処理する場合は要件ではありませんが。 このプロパティの設定方法がわからない場合は、デフォルト値は `0 0`のままにしておいてください。



---



### `SteamLogin`

`文字列` 型のデフォルト値は `null` です。 steamログインに使用するsteamログインプロパティを定義します。 steamログインの定義に加えて、 また、ASFの各スタートアップにSteamログインを入力したい場合は、設定に入れずに、 `null` のデフォルト値を維持することもできます。 機密データを設定ファイルに保存したくない場合に便利です。



---



### `SteamMasterClanID`

`ulong` type with default value of `0 0`. このプロパティは、ボットがグループチャットを含めて自動的に結合するスチームグループの steamID を定義します。 You can check steamID of your group by navigating to its **[page](https://steamcommunity.com/groups/archiasf)**, then adding `/memberslistxml?xml=1` to the end of the link, so the link will look like **[this](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. 結果からグループのSteamIDを取得できます。 `<groupID64>` タグにあります。 上記の例では、 `103582791440160998` になります。 起動時に指定されたグループに参加しようとするだけでなく、ボットはこのグループへのグループ招待も自動的に受け入れます。 グループにプライベートメンバーがある場合は、手動でBotを招待できます。 ボット専用のグループがない場合は、このプロパティはデフォルト値 `0`にしておく必要があります。



---



### `SteamParentalCode`

`文字列` 型のデフォルト値は `null` です。 このプロパティは、スチームペアレンタルPINを定義します。 ASFは蒸気の親によって保護されたリソースへのアクセスを必要とします。したがって、その機能を使用する場合。 ASFには、正常に動作するように、ペアレンタルロック解除PINを提供する必要があります。 `null` のデフォルト値は、このアカウントのロック解除に必要なスチームペアレンタルPINがないことを意味します。 スチームペアレンタルの機能を使わない方がいいでしょう

限られた状況では、ASFは有効なSteamペアレンタルコード自体を生成することもできます。 それはOSリソースの過剰な量と追加の時間が必要ですが、 言うまでもなく成功は保証されていません したがって、その機能に依存しないことをお勧めし、代わりに有効な `SteamParentalCode` をASFが使用する設定に入れることをお勧めします。 ASFがPINが必要と判断し、それ自体でPINを生成することができない場合は、入力を求められます。



---



### `SteamPassword`

`文字列` 型のデフォルト値は `null` です。 steamのパスワードを定義します。steamのログインに使用するパスワードです。 ここでスチームパスワードを定義することに加えて、 ASFの各スタートアップにスチームパスワードを設定する代わりに入力したい場合は、 `null` のデフォルト値を維持することもできます。 機密データを設定ファイルに保存したくない場合に便利です。



---



### `SteamTradeToken`

`文字列` 型のデフォルト値は `null` です。 フレンドリストにボットがある場合、Botはトレードトークンを心配することなくすぐに取引を送信できます。 したがって、このプロパティはデフォルト値の `null` で残すことができます。 しかし、あなたのボットをフレンドリストに登録していない場合。 その後、このボットが取引を送信するユーザーとして取引トークンを生成して埋める必要があります。 つまり、 このプロパティは、 `` この `` ボットインスタンスの **SteamUserPermissions** パーミッションで定義されているアカウントのトレードトークンで記入する必要があります。

In order to find your token, as logged in user with `Master` permission, navigate **[here](https://steamcommunity.com/my/tradeoffers/privacy)** and take a look at your trade URL. 私たちが探しているトークンは、トレードURLの `&token=` パートの後に8文字から作られています。 `SteamTradeToken` として、これらの8文字をコピーし、ここに置く必要があります。 `&token=` 部分、トークン自体のみを含めないでください (8 文字)。



---



### `Steamユーザー権限`

`ImmutableDictionary<ulong, byte>` 型はデフォルト値が空です。 このプロパティは、与えられたSteamユーザーが64ビットのSteamIDによって識別された地図を表示する辞書プロパティです。 ASFインスタンスでの権限を指定する `バイトの` 番号に。 ASFで現在利用可能なボット権限は次のように定義されています:

| 値 | 名前      | 説明                                                                                |
| - | ------- | --------------------------------------------------------------------------------- |
| 0 | 無し      | 特別な権限がありません これは主に、この辞書にないSteam IDに割り当てられた参照値です。この権限を持つユーザーを定義する必要はありません。          |
| 1 | ファミリー共有 | 家族共有ユーザーに最小限のアクセスを提供します。 ASFはライブラリを使用するために許可されているSteam IDを自動的に検出できるため、これは主に参照値です。 |
| 2 | 演算子     | 与えられたボットインスタンスへの基本的なアクセスを提供します。主にライセンスを追加し、キーを引き換えます。                             |
| 3 | マスター    | 与えられたBotインスタンスへのフルアクセスを提供します                                                      |


要するに、このプロパティを使用すると、特定のユーザーの権限を扱うことができます。 Permissions are important mainly for access to ASF **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, but also for enabling many ASF features, such as accepting trades. For example you may want to set your own account as `Master`, and give `Operator` access to 2-3 of your friends so they can easily redeem keys for your bot with ASF, while **not** being eligible e.g. for stopping it. そのおかげで、与えられたユーザーに簡単に権限を割り当てることができ、学位によって指定されたボットを使用させることができます。

`マスター`、および `演算子` 以下に任意の金額を設定することをお勧めします。 While it's technically possible to set multiple `Masters` and ASF will work correctly with them, for example by accepting all of their trades sent to the bot, ASF will use only one of them (with lowest steam ID) for every action that requires a single target, for example a `loot` request, so also properties like `SendOnFarmingFinished` preference in `FarmingPreferences` or `SendTradePeriod`. If you perfectly understand those limitations, especially the fact that `loot` request will always send items to the `Master` with lowest steam ID, regardless of the `Master` that actually executed the command, then you can define multiple users with `Master` permission here, but we still recommend a single master scheme.

`所有者` 権限が `SteamOwnerID` グローバル設定プロパティとして宣言されているので、もう1つ追加のAformat@@4 権限があります。 You can't assign `Owner` permission to anybody here, as `SteamUserPermissions` property defines only permissions that are related to the bot instance, and not ASF as a process. ボット関連のタスクでは、 `SteamOwnerID` は `マスター`と同じ扱いを受けるため、ここで `SteamOwnerID` を定義する必要はありません。



---



### `トレードチェック期間`

`バイト` 型のデフォルト値は `60` です。 通常、ASFは約1件の通知を受け取った直後に受信取引を処理しますが、スチームが故にその時点でそれを行うことができない場合があります。 そして、このようなトレードオファーは、次のトレード通知またはボットの再起動が行われるまで無視されたままです。 取引がキャンセルされたり、後で利用できなくなる可能性があります。 このパラメータがゼロ以外の値に設定されている場合、ASFは `TradeCheckPeriod` 分ごとにそのような未払い取引を追加で確認します。 デフォルト値はsteamサーバーへの追加リクエストのバランスと、念頭に置いて受信取引を失って選択されます。 ただし、ASFを使用してカードをファームし、受信取引を自動的に処理する予定がない場合。 この機能を完全に無効にするには、 `0 0` に設定してください。 On the other hand, if your bot participates in public [ASF's STM listing](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) or provides other automated services as a trade bot, you may want to decrease this parameter to `15` minutes or so, to process all trades in a timely manner.



---



### `TradingPreferences`

`バイトフラグ` type, デフォルト値 `0`. このプロパティは取引時のASF行動を定義し、以下のように定義されます。

| 値  | 名前                  | 説明                                                                                                                                                                                    |
| -- | ------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0  | 無し                  | 特別な取引設定なし、既定値                                                                                                                                                                         |
| 1  | AcceptDonations     | 私たちが何も失っていない取引を受け入れます                                                                                                                                                                 |
| 2  | SteamTradeMatcher   | **[STM](https://www.steamtradematcher.com)**のような取引に受動的に参加します。 Visit **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** for more info        |
| 4  | MatchEverything     | `SteamTradeMatcher` を設定し、それと組み合わせて設定する必要があります。良好で中立なものに加えて、悪い取引も受け入れます                                                                                                                |
| 8  | DontAcceptBotTrades | Doesn't automatically accept `loot` trades from other bot instances                                                                                                                   |
| 16 | 一致するアクティブな          | **[STM](https://www.steamtradematcher.com)**のような取引に積極的に参加します。 **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** をご覧ください。 |


このプロパティは `フラグ` フィールドであることに注意してください。したがって、使用可能な値の任意の組み合わせを選択することができます。 詳細については、 **[json mapping](#json-mapping)** をご覧ください。 `None` オプションでフラグを有効にしません。

ASF取引ロジックのさらなる説明、利用可能なフラグの説明については、 **[Trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** セクションをご覧ください。



---



### `TransferableTypes`

`ImmutableHashSet<byte>` type, default value of `1, 3, 5` steam item types. このプロパティは、 `transfer` **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** の間、ボット間で転送するために考慮されるSteamアイテムの型を定義します。 ASFは、 `TransferableTypes` のアイテムのみがトレードオファーに含まれるようにします。 したがって、このプロパティは、あなたのボットのいずれかに送信されている取引オファーで受信したいものを選択することができます。

| 値  | 名前              | 説明                                         |
| -- | --------------- | ------------------------------------------ |
| 0  | 不明              | 以下のいずれかに適合しないすべてのタイプ                       |
| 1  | ブースターパック        | ゲーム中のランダムなカードが3枚入ったブースターパック                |
| 2  | 絵文字             | Steamチャットで使用する絵文字                          |
| 3  | FoilTradingCard | `TradingCard`                              |
| 4  | プロフィール背景        | あなたのSteamプロフィールで使用するプロフィールの背景              |
| 5  | TradingCard     | スチームトレーディングカード。バッジをクラフトするために使用されます（フォイル以外） |
| 6  | SteamGems       | ブースターのクラフトに使用されているスチームジェム、袋が含まれています        |
| 7  | SaleItem        | Steam販売中に獲得した特別アイテム                        |
| 8  | 消耗品数            | 使用後に消える消耗品。                                |
| 9  | ProfileModifier | Steamプロフィールの外観を変更できる特別なアイテム                |
| 10 | ステッカー           | Steamチャットで使用できる特別なアイテム                     |
| 11 | ChatEffect      | Steamチャットで使用できる特別なアイテム                     |
| 12 | ミニプロファイル背景      | Steamプロフィールの特別な背景                          |
| 13 | アバタープロフィールフレーム  | Steamプロフィール用の特別なアバターフレーム                   |
| 14 | AnimatedAvatar  | Steamプロフィール用の特別なアニメーションアバター                |
| 15 | キーボードスキン        | Steamデッキ用の特別なキーボードスキン                      |
| 16 | StartupVideo    | Steamデッキ用の特別なスタートアップビデオ                    |


Please note that regardless of the settings above, ASF will only ask for **[Steam community items](https://steamcommunity.com/my/inventory/#753_6)** (`appID` of 753, `contextID` of 6), so all game items, gifts and likewise, are excluded from the trade offer by definition.

デフォルトのASF設定は、最も一般的なボットの使用方法に基づいており、ブースターパックのみ転送し、トレーディングカード(フォイルを含む)を使用しています。 ここで定義されたプロパティでは、満足する方法でその振る舞いを変更できます。 Please keep in mind that all types not defined above will show as `Unknown` type, which is especially important when Valve releases some new Steam item, that will be marked as `Unknown` by ASF as well, until it's added here (in the future release). That's why in general it's not recommended to include `Unknown` type in your `TransferableTypes`, unless you know what you're doing, and you also understand that ASF will send your entire inventory in a trade offer if Steam Network gets broken again and reports all your items as `Unknown`. 私の強い提案は、 `Unknown` 型を `TransferableTypes`に含めないことです, あなたがすべてを転送することを期待しても.



---



### `ログインキー`

`bool` type, デフォルト値 `true`. このプロパティは、ASFがこの Steamアカウントのログインキーメカニズムを使用するかどうかを定義します。 ログインキーメカニズムは公式のSteamクライアントの「Remember me」オプションと非常によく似ています。 これにより、ASFは次のログイン試行に一時的なワンタイム使用ログインキーを保存して使用することができます。 ログインキーが有効である限り、効果的にパスワード、Steamガード、または2FAコードを提供する必要をスキップします。 ログインキーは `BotName.db` ファイルに保存され、自動的に更新されます。 このため、ASFで正常にログインした後にパスワード/SteamGuard/2FAコードを入力する必要はありません。

Login keys are used by default for your convenience, so you don't need to input `SteamPassword`, SteamGuard or 2FA code (when not using **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**) on each login. ログインキーは1回しか使用できず、元のパスワードを明らかにしないので、優れた代替手段でもあります。 全く同じ方法が元のSteamクライアントで使用されているため、次回ログオンを試行するためのアカウント名とログインキーが保存されます。 `SteamLogin` と `UseLoginKeys` を使用し、ASFで `SteamPassword` を空にするのと同じです。

しかし、この細部まで気になる人もいるかもしれません。 したがって、このオプションは、閉じた後に以前のセッションを再開できるようにするためにASFがいかなる種類のトークンも保存しないようにしたい場合に使用できます。 ログイン試行ごとに完全な認証が必須になります このオプションを無効にすると、公式のSteamクライアントで「Remember me」をチェックしないのとまったく同じように動作します。 何をしているのかわからない限り、デフォルト値の `true` を維持する必要があります。



---



### `UserInterfaceMode`

`バイト` 型のデフォルト値は `0` です。 このプロパティは、Steamネットワークにログインした後にBotが発表されるユーザーインターフェースモードを指定します。 例えば、 `OnlineStatus` を介してあなたの存在が許可されている場合、Steamチャットでアカウントがどのように表示されるかに影響を与える可能性があります。 現在、以下のいずれかのモードを選択できます:

| 値   | 名前         | 説明                   |
| --- | ---------- | -------------------- |
| `0` | VGUI       | デフォルトのSteamクライアントモード |
| `1` | Tenfoot    | 大きな画像モード             |
| `2` | モバイル       | Steamモバイルアプリ         |
| `3` | ウェブ        | Web ブラウザー セッション      |
| `5` | MobileChat | Steamモバイルチャットアプリ     |


このプロパティがベースになっている `EUIMode` 型には、利用可能な値が多く含まれています。 我々の知る限り彼らは今日まで全く影響を及ぼさない だから彼らは視認性のために切断された また、いくつかの追加機能が有効になっているため、 `GamingDeviceType`にも興味があるかもしれません。

このプロパティの設定方法がわからない場合は、デフォルト値は `0 0`のままにしておいてください。



---



### `WebProxy`

`文字列` 型のデフォルト値は `null` です。 このプロパティは、特に `apiなどのサービスに対して、ボット固有の内部http関連の通信に使用されるWebプロキシアドレスを定義します。 teampowered.com <code> ,`store.steampowered.com `steamcommunity.com` と `store.steampowered.com`. 設定されていない場合、ASFは代わりに上記のグローバル `WebProxy` 設定を使用します。 ASFリクエストをプロキシすることは、さまざまな種類のファイアウォール、特に中国のグレートファイアウォールをバイパスするのに非常に有用です。

このプロパティは uri 文字列として定義されています:



> URI の文字列は、(サポートされている: http/https/socks4/socks4a/socks5)、ホスト、およびオプションのポートで構成されています。 完全な uri 文字列の例は `"http://contoso.com:8080"` です。

プロキシがユーザー認証を必要とする場合は、 `WebProxyUsername` または `WebProxyPassword` も設定する必要があります。 そのような必要がない場合は、このプロパティだけを設定するだけで十分です。

If you require proxying internal Steam network communication (CMs) as well, then you should ensure to configure **[`SteamProtocols`](#steamprotocols)** bot's property to a value that allows only websocket transport, i.e. a value of `4`, as only websockets are supported for proxying.

このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



### `WebProxyPassword`

`文字列` 型のデフォルト値は `null` です。 このプロパティは、基本、ダイジェスト、NTLMで使用されるパスワードフィールドを定義します。 そして、プロキシ機能を提供するターゲット `WebProxy` マシンによってサポートされているKerberos 認証。 プロキシがユーザーの資格情報を必要としない場合は、ここに何も入力する必要はありません。 このオプションを使用すると、 `WebProxy` も同様に使用されている場合にのみ意味があります。

このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



### `WebProxyUsername`

`文字列` 型のデフォルト値は `null` です。 このプロパティは、基本、ダイジェスト、NTLMで使用されるユーザー名フィールドを定義します。 そして、プロキシ機能を提供するターゲット `WebProxy` マシンによってサポートされているKerberos 認証。 プロキシがユーザーの資格情報を必要としない場合は、ここに何も入力する必要はありません。 このオプションを使用すると、 `WebProxy` も同様に使用されている場合にのみ意味があります。

このプロパティを編集する理由がない限り、デフォルトのままにしておく必要があります。



---



## ファイル構造

ASFは非常に単純なファイル構造を使用しています。



```text
├── 📁 config
│     ├── ASF.json
│     ├── ASF.db
│     ├── Bot1.json
│     ├── Bot1.db
│     ├── Bot2.json
│     ├── Bot2.db
│     └── ...
├── ArchiSteamFarm.dll
├── log.txt
├── ...
```


ASFを別のPCなどに移動させるには、 `config` ディレクトリを単独で移動/コピーするだけで十分です。 これが、「ASFバックアップ」の任意の形式を行う推奨方法です。 内部ASFファイルを破損する危険性がない一方で、GitHubから残りの部分(プログラム)をいつでもダウンロードできるので、e. 欠陥のあるバックアップをとおして

`log.txt` ファイルは最後のASF実行によって生成されたログを保持します。 このファイルには機密情報が含まれておらず、問題に関しては非常に便利です。 クラッシュしたり、前回のASFで何が起こったかの情報として。 あなたが問題やバグに遭遇した場合、私たちはこのファイルについて非常に頻繁に尋ねます。 ASF automatically manages this file for you, but you can further tweak ASF **[logging](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging)** module if you're advanced user.

`config` ディレクトリは、すべてのボットを含むASFの設定を保持する場所です。

`ASF.json` はグローバルASF設定ファイルです。 この設定は、ASFがプロセスとしてどのように動作し、すべてのボットとプログラム自体に影響を与えるかを指定するために使用されます。 ASFプロセスオーナー、自動更新、デバッグなどのグローバルプロパティがあります。

`BotName.json` は与えられたボットインスタンスの設定です。 この設定は、指定されたボットインスタンスの動作を指定するために使用されます。 そのため、これらの設定はそのボットに固有のものであり、他のボット間で共有されることはありません。 これにより、さまざまな設定でボットを構成することができ、必ずしもすべてが同じ方法で動作するわけではありません。 すべてのボットは、 `BotName`の代わりにあなたが選んだ一意の識別子を使用して名前を付けられます。

設定ファイルとは別に、ASFはデータベースを格納するために、 `config` ディレクトリも使用します。

`ASF.db` はグローバルASFデータベースファイルです。 グローバル永続ストレージとして機能し、ローカルSteamサーバーのIPなど、ASFプロセスに関連するさまざまな情報を保存するために使用されます。 **このファイル** を編集しないでください。

`BotName.db` は与えられたボットインスタンスのデータベースです。 このファイルは、ログインキーやASF2FAなどの永続的なストレージに与えられたボットインスタンスに関する重要なデータを保存するために使用されます。 **このファイル** を編集しないでください。

`BotName.keys` は、 **[バックグラウンドゲームにキーをインポートするための特別なファイルです。](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. それは必須ではなく、生成されませんが、ASFによって認識されています。 キーが正常にインポートされると、このファイルは自動的に削除されます。

`BotName.maFile` は、 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** のインポートに使用できる特別なファイルです。 必須ではなく、生成されませんが、 `BotName` がまだASF2FAを使用していない場合、ASFによって認識されます。 このファイルはASF2FAのインポートが成功すると自動的に削除されます。



---



## JSONマッピング

すべての構成プロパティにはその型があります。 プロパティのタイプは、その値に対して有効な値を定義します。 指定された型に対してのみ有効な値を使用できます - 無効な値を使用する場合。 ASFはあなたの設定を解析できなくなります。

**configs** の生成には、ConfigGenerator を使用することを強くお勧めします。ほとんどの低レベルなもの (型の検証など) を処理します。 つまり、適切な値を入力するだけで、以下で指定された変数の型を理解する必要はありません。 このセクションは、主に手動でコンフィグを生成/編集する人のためのもので、どのような値を使用できるかを知っています。

ASFで使用されるタイプはネイティブのC#タイプで、以下のように指定されています。



---

`bool` - ブール型は `true` と `false` 値のみ受け付けます。

例: `"有効化": true`



---

`バイト` - 符号なしバイト型、 `0` から `255` (含む) の整数のみ受け付けます。

例: `"ConnectionTimeout": 90`



---

`ushort` - 符号なし短い型, `0 0` から `65535` (包含).

例: `"WebLimiterDelay": 300`



---

`uint` - 符号なしの整数型, `0` から `4294967295` (包含).



---

`ulong` - 符号なしロング整数型, `0` から `18446744073709551615` (包含).

例: `"SteamMasterClanID": 103582791440160998`



---

`string` - String type, accepting any sequence of characters, including empty sequence `""` and `null`. Empty sequence and `null` value are treated the same by ASF, so it's up to your preference which one you want to use (we stick with `null`).

Examples: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MyAccountName"`



---

`Guid?` - Nullable UUID type, in JSON encoded as string. UUID は 32 16 進数文字で作られています。 `0 0` から `9` および `a` から `f` までの範囲です。 ASFは、小文字、大文字、ダッシュの有無など、さまざまな有効なフォーマットに対応しています。 有効な UUID に加えて、このプロパティは nullable であるため。 `null` の特殊な値は、提供する UUID がないことを示すために受け付けられます。

例: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`



---

`ImmutableList<valueType>` - 与えられた `valueType` の値のイミュータブルコレクション（リスト）。 JSON では、指定された `valueType` の要素の配列として定義されています。 ASFは、特定のプロパティが複数の値をサポートしており、その注文が関連性がある可能性があることを示すために、 `List` を使用しています。

`ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`



---

`ImmutableHashSet<valueType>` - 与えられた `valueType` 内の一意の値のイミュータブルコレクション (セット) 。 JSON では、指定された `valueType` の要素の配列として定義されています。 ASFは `HashSet` を使用して、与えられたプロパティが一意の値に対してのみ意味があり、その順序が問題ではないことを示しています。 したがって、パース中に潜在的な重複を意図的に無視します(いずれにせよ、それらを供給する場合)。

`ImmutableHashSet<uint>`: `"Blacklist": [267420, 303700, 335590]`



---

`ImmutableDictionary<keyType, valueType>` - Immutable dictionary (map) that maps a unique key specified in its `keyType`, to value specified in its `valueType`. JSON では、キーと値のペアを持つオブジェクトとして定義されています。 `keyType` は `ulong` のような値の型であっても、この場合は常に引用されます。 マップ全体でキーがユニークであるという厳密な要件もありますが、今回は JSON によっても強制されます。

`ImmutableDictionary<ulong, byte>`: `"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`



---

`flags` - Flags 属性はビット演算を適用することにより、複数の異なるプロパティを 1 つの最終値に結合します。 これにより、さまざまな異なる許可された値の任意の組み合わせを同時に選択することができます。 最終的な値は、有効化されたすべてのオプションの値の合計として構成されます。

例えば、次の定義を指定します。

| 値 | 名前 |
| - | -- |
| 0 | 無し |
| 1 | A  |
| 2 | B  |
| 4 | C  |


There are exactly 3 meaningful, available flags to switch on/off (`A`, `B`, `C`), and therefore `8` possible valid combinations overall:

| 最終値 | 有効なフラグ         |
| --- | -------------- |
| 0   | `無し`           |
| 1   | `A`            |
| 2   | `B`            |
| 3   | `` + `B`       |
| 4   | `C`            |
| 5   | `` + `C`       |
| 6   | `B` + `C`      |
| 7   | `` + `B` + `C` |


定義によれば、上記のことを可能にするためには、各スタンドアロンフラグが2の力でなければなりません。 このため、上記の例では、 `D`の追加フラグは、 `8` 以上の値を格納する必要があります。

通常、グラフィカルツールが計算を行います。 手動で設定を編集している場合 上記の例のように、いつでもcalculatorを使用して、有効にしたいすべてのフラグの基礎となる値を単純に加えることができます。

Example: `"SteamProtocols": 7` (which enables flags with value of `1`, `2` and `4`, as explained above)



---



## 互換性マッピング

Due to JavaScript limitations of being unable to properly serialize simple `ulong` fields in JSON when using web-based ConfigGenerator, `ulong` fields will be rendered as strings with `s_` prefix in the resulting config. これには、例えば、 `"SteamOwnerID": 76561198006963719` が含まれており、ConfigGenerator で `"s_SteamOwnerID": "76561198006963719"`. ASFにはこの文字列マッピングを自動的に処理するための適切なロジックが含まれているため、設定内の `s_` エントリは実際に有効で正しく生成されます。 If you're generating configs yourself, we recommend to stick with original `ulong` fields if possible, but if you're unable to do so, you can also follow this scheme and encode them as strings with `s_` prefix added to their names. 最終的にはこのJavaScriptの制限を解決したいと考えています。



---



## 設定互換性

ASFが古い設定と互換性を保つことは、最優先事項です。 既に知っておくべきですが、不足している設定プロパティは、それらが **デフォルト値** で定義されるのと同じ扱いを受けます。 Therefore, if new config property gets introduced in new version of ASF, all your configs will remain **compatible** with new version, and ASF will treat that new config property as it'd be defined with its **default value**. 必要に応じて設定プロパティを追加、削除、編集することができます。

定義された設定プロパティを変更したいものに限定することをお勧めします。 この方法で自動的に他のすべてのもののデフォルト値を継承します 設定をきれいに保つだけでなく、互換性も向上します。明示的に自分自身を設定したくないプロパティのデフォルト値を変更することにしました(e. `WebLimiterDelay`).

このため、ASFは設定を再フォーマットし、デフォルト値を保持するフィールドを削除することで、自動的に設定を移行/最適化します。 特定の理由がある場合は、 `--no-config-migrate` **[コマンドライン引数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** でこの挙動を無効にできます。 たとえば、読み取り専用の設定ファイルを提供しており、ASFに変更させたくない場合などです。



---



## 自動再読み込み

ASFは「オンザフライ」で変更されていることを認識しています - そのおかげで、ASFは自動的に次のようになります：

- 設定を作成するときに、新しいボットインスタンスを作成（必要に応じて開始）します。
- 設定を削除すると、古いボットインスタンスを停止して削除します
- ボットの設定を編集するときは、ボットインスタンスを停止（必要に応じて開始）してください
- 設定の名前を変更すると、新しい名前でBotを再起動します（必要な場合）。

上記のすべてが透過的で、プログラムを再起動したり、他の(影響を受けない)ボットインスタンスを消去したりすることなく、自動的に行われます。

それに加えて、ASFはコア ASF `ASF.json` 設定を変更した場合( `AutoRestart` 許可されている場合)も再起動します。 同様に、プログラムを削除または名前を変更すると終了します。

You can disable this behaviour with `--no-config-watch` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** if you have a specific reason, for example you don't want from ASF to react to file changes in `config` folder.