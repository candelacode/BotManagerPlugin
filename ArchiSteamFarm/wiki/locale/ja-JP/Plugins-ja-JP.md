# プラグイン

ASFには、ランタイム中にロードできるカスタムプラグインのサポートが含まれています。 プラグインを使用すると、カスタムコマンド、カスタム取引ロジック、サードパーティのサービスやAPIとの統合などでASFの動作をカスタマイズできます。

このページでは、ASFプラグインについて、ユーザーの視点から解説、利用状況などについて説明します。 If you want to view developer's perspective, move **[here](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)** instead.

---

## 使用法

ASFは、ASFフォルダにある `プラグイン` ディレクトリからプラグインを読み込みます。 それはあなたが使用したい各プラグインの専用ディレクトリを維持するために推奨される練習(プラグインの自動更新で必須になります)です。 これは、 `MyPlugin` のような名前に基づくことができます。 これを行うと、 `プラグイン/MyPlugin` の最終ツリー構造になります。 最後に、プラグインのすべてのバイナリファイルを専用フォルダ内に配置し、ASFは再起動後にプラグインを適切に検出して使用します。

Usually plugin developers will publish their plugins in form of a `zip` file with binaries inside, which means that you should unpack that zip file to its own dedicated subdirectory inside `plugins` directory.

プラグインが正常にロードされた場合、ログにその名前とバージョンが表示されます。 質問、問題、使用を決定したプラグインに関連する使用方法については、プラグイン開発者に相談してください。

いくつかの注目プラグインは **[サード パーティ製](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** セクションにあります。

**Please note that ASF plugins could be malicious**. 上記のサードパーティーセクションからのプラグインでも、信頼できる開発者が作ったプラグインを常に使用していることを確認する必要があります。 ASF開発者は、カスタムプラグインを使用する場合、通常のASFのメリット(マルウェア不足やVACフリーなど)を保証することはできません。 プラグインがロードされると、ASFプロセスを完全に制御できることを理解する必要があります。 そのため、カスタムプラグインを使用するセットアップもサポートできません。vanilla ASFコードを実行していないので。

---

## 互換性

Depending on plugin's complexity, scope and a lot of other factors, it's entirely possible that it'll require from you to use **[generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** ASF variant, instead of usually recommended **[OS-specific](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. これは、OS 固有のバリアントは、ASF自体に必要なコア機能のみを備えているためです。 プラグインにはメインの ASF スコープ外のパーツが必要な場合があります。そのため、トリミングされた OS 固有のビルドと互換性がありません。

一般に、サードパーティのプラグインを使用する場合は、互換性を最大限に発揮するためにASFジェネリックバリアントを使用することをお勧めします。 ただし、 すべてのプラグインがそれを必要とするわけではありません - 一般的なASFバリアントを使用する必要があるかどうかを確認するために、プラグインの情報を参照してください。

---


## 自動アップデート

ASFにはプラグインの自動アップデートのための組み込みメカニズムがあります。 その機能を動作させるには、まず、選択したプラグインは **[そのメカニズムの](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)** をサポートする必要があります。 自動更新をサポートするプラグインをロードした場合、ASFはプラグインの初期化中に適切にログに記録されます。 例えば、「プラグインは自動更新から無効になっています」や「プラグインは登録され、自動更新で有効になっています」など。

By default, automatic updates for custom plugins are **disabled**, due to security reasons. You can configure automatic updates in the config by using **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** and/or **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)**, we recommend to read description of those config properties for more info. また、ASFアップデートと同様に、自動アップデートを無効にしてから、必要に応じてアップデートすることもできます。 手動ベースで、 `updateplugins` **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** を発行することで。

どちらのアプローチでも、プロセスに読み込んだカスタムプラグインを none、some 、またはすべてアップデートできます。