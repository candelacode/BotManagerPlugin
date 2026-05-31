# リモート通信

このセクションでは、ASFがどのように影響を与えることができるかについての詳細な説明を含む、リモート通信について説明します。 私たちは以下のものを悪意のあるものでも、望ましくないものでもないと考えていますが、どちらも法的にそれを開示する義務がありません。 特にあなたのプライバシーとデータが共有されることに関しては、プログラム機能をもっとよく理解してほしい。

## Steam

ASF communicates with Steam network (**[CM servers](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), as well as **[Steam API](https://steamcommunity.com/dev)**, **[Steam store](https://store.steampowered.com)** and **[Steam community](https://steamcommunity.com)**.

上記の通信を無効にすることはできません。 ASFは基本的な機能を提供するための基盤となっています。 上記の操作に慣れていない場合は、ASFの使用を控える必要があります。

## Steam グループ

ASFは私たちの **[Steamグループ](https://steamcommunity.com/groups/archiasf)** と通信します。 グループでは、アナウンス、特に新しいバージョン、重大な問題、Steamの問題など、コミュニティを更新し続けるために重要なことを提供します。 また、質問、問題の解決、問題の報告、改善の提案など、当社のテクニカルサポートを利用することができます。 デフォルトでは、ASFで使用されているアカウントはログイン時に自動的にグループに参加します。

ボットの `` **[`Remoteコミュニケーション`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** 設定で </strong> SteamGroup </a> フラグを無効にすることで、グループに参加することを拒否することができます。

## GitHub

ASF communicates with **[GitHub's API](https://api.github.com)** in order to fetch **[ASF releases](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** for the update functionality. This is done as part of auto-updates (if you've kept **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** enabled), as well as `update` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** プロパティ - それを `None` に設定すると、アップデート機能全体が無効になります この点に関してGitHub通信を含む。

## ASFのサーバー

ASFは、より高度な機能のために、私たち自身のサーバー **[](https://asf.justarchi.net)** と通信します。 特に、以下が含まれます。
- すべてのダウンロードされたビルドが正当であることを確認するために、GitHubからダウンロードされたASFビルドのチェックサムを私たち自身の独立したデータベースに対して検証する (マルウェアのない) MITM 攻撃またはその他の改ざん)
- `FilterBadBots` グローバル設定を有効にしている場合は、フィルタリング用の不正なボットのリストを取得しています。
- Announcing your bot in **[our listing](https://asf.justarchi.net/STM)** if you've enabled `SteamTradeMatcher` in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** and meet other criteria
- Downloading currently available bots to trade from **[our listing](https://asf.justarchi.net/STM)** if you've enabled `MatchActively` in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** and meet other criteria

セキュリティ対策として、ASFビルドのチェックサム検証を無効にすることはできません。 ただし、上記のGitHubセクションで説明されているように、これを避けたい場合は、自動更新を完全に無効にすることができます。

サーバーからリストを取得しないようにしたい場合は、 `FilterBadBots` 設定を無効にできます。

ボットの `` **[`Remoteコミュニケーション`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** の設定で ` PublicListing ` フラグを無効にすることで、リスティングに表示されないようにすることができます。 これは、 `SteamTradeMatcher` ボットを同時にアナウンスされずに実行したい場合に便利です。

`MatchActively` の設定では、リストからボットをダウンロードすることは必須です。それを受け入れたくない場合は、その設定を無効にする必要があります。