# サードパーティー

このセクションには、ASFと一緒に使用するために排他的に(または主に)書かれたさまざまなサードパーティーの追加が含まれます。 ASFプラグインから、シンプルなWebアプリケーション、統合用の内部ライブラリまで、他のプラットフォーム向けの完全な機能を備えたボットで終了します。 リストに何かを追加したい場合は、DiscordまたはSteamグループでお知らせください。

Please note that below programs are **not** maintained by ASF developers and therefore **we give no guarantee about any of them**, especially in terms of security, safety or Steam ToS compliance. このリストは参照のみでメンテナンスされます。 あなたが使用しようとしているサードパーティのユーティリティが安全で合法であることを常に確認する必要があります。 全てを自分の責任で使っているのです

---

## ASF plugins

### **[CatPoweredPlugins](https://github.com/CatPoweredPlugins)** (**[Rudokhvist](https://github.com/Rudokhvist)**)

- **[ASFAchievementManager](https://github.com/CatPoweredPlugins/ASFAchievementManager)**, Steam の実績を管理できるASF用プラグイン.
- **[BirthdayPlugin](https://github.com/CatPoweredPlugins/BirthdayPlugin)**, asfの誕生日おめでとうございます。
- **[CaseInsensitiveASF](https://github.com/CatPoweredPlugins/CaseInsensitiveASF)**, ボット名を大文字小文字を区別しないようにするためのASF用プラグイン.
- **[CommandAliasPlugin](https://github.com/CatPoweredPlugins/CommandAliasPlugin)**, ASFコマンドのカスタムコマンドエイリアスをセットアップするためのASFプラグイン.
- **[コマンド交換](https://github.com/CatPoweredPlugins/CommandlessRedeem)**, コマンドなしで使用するキーを再実装するためのASFプラグイン.
- **[ItemDispenser](https://github.com/CatPoweredPlugins/ItemDispenser)**, 特定の種類のアイテムに対する取引要求を自動的に受け入れるためのASF用プラグイン.
- **[SelectiveLootAndTransferPlugin](https://github.com/CatPoweredPlugins/SelectiveLootAndTransferPlugin)**, Steamアイテムを転送するための高度な `transfer` コマンドを提供するASFプラグイン.

### **[Citrinate](https://github.com/Citrinate)**

- **[BoosterManager](https://github.com/Citrinate/BoosterManager)**, 宝石をブースターパックに変えるための使いやすいインターフェースを提供するASF用のプラグインや、在庫や市場上場を管理するためのさまざまな機能。
- **[CS2Interface](https://github.com/Citrinate/CS2Interface)**, **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** を使用してカウンターストライク2と対話できるASF用プラグイン.
- **[FreePackages](https://github.com/Citrinate/FreePackages)**, Steamで無料パッケージを見つけてアカウントに追加するASF用のプラグイン.

### **[Vita](https://github.com/ezhevita)**

- **[FriendAccepter](https://github.com/ezhevita/FriendAccepter)**, ASF用のプラグインがすべての友達招待を自動的に受け入れます。
- **[GameRemover](https://github.com/ezhevita/GameRemover)**, 選択したボットインスタンスのSteamライセンスを削除するコマンドを実装するASF用プラグイン.
- **[GetEmail](https://github.com/ezhevita/GetEmail)**, 与えられたボットインスタンスのメールアドレスをSteamから直接取得するコマンドを実装するASF用プラグイン.
- **[ResetAPIKey](https://github.com/ezhevita/ResetAPIKey)**, 選択したボットインスタンスのAPIキーをリセットするコマンドを実装するASF用プラグイン.

### その他

- **[ASFEnhance](https://github.com/chr233/ASFEnhance)**, ASF向けのプラグイン, 特にコマンド.
- **[ASFFreeGames](https://github.com/maxisoft/ASFFreeGames)**, redditに投稿された無料の蒸気ゲームを自動的に収集できるASF用プラグイン.

---

## 統合

- **[ASFBot](https://github.com/dmcallejo/ASFBot)**, asF統合でPythonで書かれたテレグラムボット.
- **[ASF STM userscript](https://greasyfork.org/en/scripts/404754-asf-stm)**, for those who want to send automated trade offers to bots on our **[ASF STM listing](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** through web browser, without using `MatchActively` feature provided by ASF.
- **[simple-asf-bot](https://github.com/deluxghost/simple-asf-bot)**, asf-integrationを搭載したPythonで書かれた別の(最小)テレグラムボット.

---

## ライブラリ

- **[ASF-IPC](https://github.com/deluxghost/ASF_IPC)**, ASFのIPCインターフェイスとのさらなる統合のためのPythonライブラリ.

---

## パッケージ

- **[AUR repo #1](https://aur.archlinux.org/packages/asf)**, arch linux に簡単にASFをインストールできます。
- **[AUR repo #2](https://aur.archlinux.org/packages/archisteamfarm-bin)**, arch linux に簡単にASFをインストールできます。
- **[Homebrew](https://formulae.brew.sh/formula/archi-steam-farm)**, macOSに簡単にASFをインストールできます。
- **[Nix](https://search.nixos.org/packages?channel=unstable&show=ArchiSteamFarm&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**を使用すると、Nixのdistrosに簡単にASFをインストールできます。
- **[NixOS](https://search.nixos.org/options?channel=unstable&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, NixOS でASFを設定してインストールすることができます。
- **[Scoop](https://scoop.sh/#/apps?q=ArchiSteamFarm)**を使用すると、Windowsに簡単にASFをインストールできます。
- **[Winget](https://github.com/microsoft/winget-pkgs/tree/master/manifests/j/JustArchiNET/ArchiSteamFarm)**, Windows に ASF を簡単にインストールできます。

---

## ツール

- **[CS2Script](https://github.com/Citrinate/CS2Script)**を使用すると、 **[CS2Interface](https://github.com/Citrinate/CS2Interface)** プラグインを使用してカウンターストライク2ストレージユニットを管理できます。
- **[キー抽出器](https://umaim.github.io/SKE)**を使用すると、さまざまな形式のキーをコピー&ペーストし、ASF用の `` コマンドを作成できます。 詳細については、 **[GitHubリポジトリ](https://github.com/PixvIO/SKE)** を確認してください。
- **[ASF Mass Config Editor](https://github.com/genesix-eu/ASF_MCE)**, 複数のASF設定をより簡単に管理できます.

---

## もっと知りたいですか？

We recommend **[ArchiSteamFarm](https://github.com/topics/archisteamfarm)** topic on GitHub for all projects that integrate with ASF. ただし、ASFプロジェクトとは無関係にタグを使用しようとすることもあることに留意してください。 通常は自己宣伝をするのでダブルチェックするのは良いアイデアです