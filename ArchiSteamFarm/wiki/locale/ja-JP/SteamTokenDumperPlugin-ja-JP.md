# Steam Token出力プラグイン

`SteamTokenDumperPlugin` is official ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** developed by us, which allows you to contribute to **[SteamDB](https://steamdb.info)** project by sharing package tokens, app tokens and depot keys that your Steam account has access to. The extended info on collected data and why SteamDB needs it can be found on SteamDB's **[Token Dumper](https://steamdb.info/tokendumper)** page. 送信されたデータには潜在的に機密情報は含まれず、上記の説明に記載されているように、セキュリティ/プライバシーリスクはありません。

---

## プラグインを有効にする

ASFには、リリースにバンドルされた `SteamTokenDumperPlugin` が付属していますが、プラグイン自体はデフォルトで無効になっています。 JSON構文で、 `SteamTokenDumperPluginEnabled` ASFグローバル設定プロパティを `true`に設定することで、プラグインを有効にできます。

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

ASFプログラムの起動時に、プラグインは標準のASFロギングメカニズムを通じて正常に有効化されたかどうかをお知らせします。 ウェブベースの設定ジェネレータを使用してプラグインを有効にすることもできます。

---

## 技術的な詳細

有効にすると、プラグインはASFで実行しているボットをパッケージトークンの形でデータを収集するために使用します。 あなたのボットがアクセスできるアプリトークンとデポキー。 データ収集モジュールには、データ収集によって生じる追加のオーバーヘッドを最小限に抑えることになっているパッシブルーチンとアクティブルーチンが含まれます。

計画された使用事例を満たすために、上記のデータ収集ルーチンに加えて。 送信ルーチンは、定期的にSteamDBに送信する必要があるデータを決定する責任があるとして初期化されます。 このルーチンは、ASF開始から最大 `1` 時間で発火し、 `24` 時間ごとに繰り返されます。 このプラグインは送信する必要があるデータ量を最小限に抑えるために最善を尽くします したがって、プラグインが収集するいくつかのデータは、提出するために役に立たないと判断される可能性があります したがってスキップされます (例えば、アクセストークンを変更しないアプリの更新)。

プラグインは、 `config/SteamTokenDumper.cache` の場所に保存された永続キャッシュデータベースを使用します。これは、ASFの `config/ASF.db` と同様の目的を提供します。 このファイルは、収集および送信されたデータを記録し、異なるASF実行に渡って行う必要がある作業量を最小限に抑えるために使用されます。 ファイルを削除すると、プロセスは最初から再起動され、可能であれば避けるべきです。

---

## データ

ASF includes the contributor `steamID` in the request, which is determined as `SteamOwnerID` that you set in ASF, or in case you didn't, the Steam ID of the bot which owns the most licenses. 発表された貢献者は、継続的なヘルプのためにSteamDBからいくつかの追加の特典を受け取る可能性があります(e. をクリックします。寄付者はウェブサイト上でランク付けされていますが、それは完全にSteamDBの裁量次第です。

いずれにせよ、SteamDBのスタッフはあなたの助けを事前に感謝したいと思います。 送信されたデータにより、SteamDBを操作し、特にパッケージに関する情報を追跡することができます。 アプリやデポがあれば助けが必要になります

---

## コマンド

STDプラグインには、 `std [Bots]`が追加されています。 これにより、オンデマンドで選択したボットのリフレッシュと送信をトリガーできます。 コマンドを使用するには、自動収集と提出をスキップし、手動でプロセスを制御することができます設定を有効にする必要はありません。 もちろん、有効な設定で実行することもできます。これは、予想よりも早く通常の収集や提出手続きを実行するだけです。

利用可能なすべてのボットの更新をトリガーするには、 `!std ASF` をお勧めします。 ただし、必要に応じて選択したものに対してトリガーすることもできます。

---

## 高度な設定

私たちのプラグインは、内部を自分の好みに合わせて調整したい人に役立つかもしれない高度な設定をサポートしています。

高度な設定は `ASF.json` 内に配置されます:

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

すべてのオプションについて以下に説明します。

### `有効`

`bool` type, デフォルト値 `false`. このプロパティは、上記で説明した `SteamTokenDumperPluginEnabled` rootレベルプロパティと同じ動作をし、代わりに使用できます。 プラグイン関連の設定全体を独自の構造にしたいと思う人々に捧げられています (おそらく、以下で説明する他の高度なプロパティをすでに使用している人々がほとんどです)。

---

### `シークレットアプリID`

`ImmutableHashSet<uint>` 型はデフォルト値が空です。 このプロパティはプラグインが解決しない `appID` を指定し、すでに解決済みの場合はトークンを送信しません。 このプロパティは、未公開アイテム、特に開発者、パブリッシャー、またはクローズドベータテスターに関する潜在的な機密情報にアクセスできる人に役立ちます。

---

### `SecretDepotID`

`ImmutableHashSet<uint>` 型はデフォルト値が空です。 このプロパティは、プラグインが解決しない `depotID` を指定し、すでに解決されている場合は、キーを送信しません。 このプロパティは、未公開アイテム、特に開発者、パブリッシャー、またはクローズドベータテスターに関する潜在的な機密情報にアクセスできる人に役立ちます。

---

### `シークレットパッケージID`

`ImmutableHashSet<uint>` 型はデフォルト値が空です。 このプロパティは、プラグインが解決しない `packageID` ( `subID`とも呼ばれます) を指定します。 既に解決済みの場合はトークンを提出しないでください このプロパティは、未公開アイテム、特に開発者、パブリッシャー、またはクローズドベータテスターに関する潜在的な機密情報にアクセスできる人に役立ちます。

---

### `SkipAutoGrantPackages`

`bool` type, デフォルト値 `true`. This property acts very similar to `SecretPackageIDs` and when enabled, will cause packages with `EPaymentMethod` of `AutoGrant` to be skipped during resolve routine explained below. `AutoGrant` の支払い方法は、 **[Steamworks](https://partner.steamgames.com)** が開発者アカウントにパッケージを自動的に付与するために使用します。 While this is not as explicit as other `Secret` options, and therefore doesn't guarantee anything (since you might have other packages than `AutoGrant` that you still don't want to submit), it should be good enough for skipping majority, if not all, of the secret packages. This option is enabled by default, as people that actually have access to `AutoGrant` packages will almost never want to leak those to general public, and therefore using value of `false` is very situational.

---

## 詳細な説明

ルートレベルでは、すべてのSteamアカウントがパッケージ(ライセンス、サブスクリプション)のセットを所有しています。 `packageID` ( `subID` とも呼ばれます) によって分類されます。 すべてのパッケージには、 `appID` によって分類されたいくつかのアプリが含まれています。 すべてのアプリは、 `デポID`によって分類されたいくつかのデポを含めることができます。

```text
├── sub/124923
web+graphie://292030
web+graphie://ka-perseus-graphie.s3.amazonaws.com/web+graphie://ja-perseus-graphie.s3.amazonaws.com/web+graphie://ja-perseus-graphie.s3.amazonaws.com/ja-perseus-graphie.s3.amazonaws.com/ja-perseus-graphie.s3.amazonaws.com/124923
web+graphie:/ka-perseus-graphie.s3.amazonaws.com/ja-perseus-graphie.s3.amazonaws.com/2030

├── app/378649
├── ...
└── ...
```

私たちのプラグインには、スキップされた項目を考慮する 2 つのルーチンが含まれています - 解決ルーチンと提出ルーチン。

resolve ルーチンは上記のツリーを解決する責任があります。 事前にパッケージ/アプリ/デポをブラックリストに載せることで、 ブラックリストに登録されているブランチ/リーフの代わりに、残りの部分を指定することなく、効果的にツリーをカットします。 In our example above, if `124923` package was ignored, whether by `SecretPackageIDs` or `SkipAutoGrantPackages`, and it was the only package you own which linked to the `292030` appID, then appID `292030` wouldn't get resolved either, and by definition, if there were no other resolved apps which linked to the `292031` and `378648` depots, then they wouldn't get resolved either. ただし、プラグインがすでにツリーを解決している場合、効果的には与えられた項目が更新されないようにすることに注意してください。 新しいアプリが追加されました)、既に解決された既存のアイテムについてプラグインを「忘れる」ことはありません(e. を選択します。 If you've just enabled some skipping options, and would like to ensure that ASF doesn't traverse the already-resolved tree, you may consider one-time removing `config/SteamTokenDumper.cache` file where the plugin keeps its cache.

提出ルーチンは、(上記の resolve ルーチンによって)すでに解決されたアイテムのパッケージトークン、アプリトークン、デポキーを送信する責任があります。 ここでは、ブラックリストは、プラグインがすでに情報を解決している場合でも、即時の効果があります。 ブラックリストに登録されている場合、解決されているかどうかに関わらず、提出ルーチンはSteamDBに送信しません。 しかし、私たちはもうこの時点で木について話していないことを覚えておいてください。 このアプリの情報がこのパッケージから来ているかどうかは分かりませんが ブラックリストに載っているアイテムの情報は他との関係を問わず省略されます

For majority of the developers and publishers, it should be enough to keep `SkipAutoGrantPackages` enabled, potentially empowered with `SecretPackageIDs` only, as it effectively cuts the tree at the beginning branch and guarantees that the apps and depots included further will not get submitted as long as there is no other package linking to the same app. 確認したい場合は、それに加えて、 `SecretAppID`を使用することもできます。 ブラックリストに登録していないライセンスがあっても、アプリの解決を飛ばします。 特定の値がない限り、 `SecretDepotID` を使用する必要はありません。 特定の必要性 (パッケージやアプリに関する情報を送信中に特定のデポのみをスキップするなど) さらに別の層を追加してトリプルセーフにしたい場合にも。