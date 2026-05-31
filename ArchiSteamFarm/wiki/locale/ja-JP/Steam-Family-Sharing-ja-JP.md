# Steam ファミリーシェアリング

ASFは、古いシステムと新しいシステムであるSteamファミリーシェアリングをサポートしています。 ASFがどのように動作するかを理解するために まずは、 **[Steam ファミリー共有の仕組み](https://store.steampowered.com/promotion/familysharing)**をご覧ください。これはSteamストアでご利用いただけます。 それに加えて、 **[ニュース](https://store.steampowered.com/news/app/593110/view/4149575031735702628)** を確認してください。新しいSteamファミリー共有システムについては、ASFと互換性があります。

---

## ASF

ASFでのSteamファミリー共有機能のサポートは透明です つまり、新しい bot/process config プロパティは導入されていません。追加の組み込み機能として、ボックスから動作します。

ASFは、ファミリー共有ユーザーによってロックされているライブラリを認識するための適切なロジックを備えています。 したがって、ゲームを起動することにより、セッションから「キック」することはありません。 ASFはロックを保持しているプライマリアカウントとまったく同じ動作をします。したがって、そのロックがスチームクライアントによって保持されている場合。 またはあなたの家族共有ユーザーの1人によって、ASFはファームを試みることはなく、ロックが解除されるのを待つことになります。 これは主に古いシステムに関連しています。新しいシステムにより、ASFが現在農業を営んでいる以外のゲームを共有できるようになります。

上記に加えて、ログイン後、ASFはあなたの家族共有システム(旧システムと新システム)にアクセスします。 ユーザーを抽出します(チームID)からライブラリの使用が許可されます。 Those users are given `FamilySharing` permission to use **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, especially allowing them to use `pause~` command on bot account that is sharing games with them, which allows to pause automatic cards farming module in order to launch a game that can be shared - this also mostly applies to the old system, but might still be used with the new system in case ASF is currently farming game that your users want to play.

Connecting both functionalities described above allows your friends to `pause~` your cards farming process, start a game, play as long as they wish, and then after they're done playing, cards farming process will be automatically resumed by ASF. もちろん、ASFが現在積極的に農業を行っていない場合は、 `一時停止〜` を発行する必要はありません。 あなたの友人はすぐにゲームを起動することができますし、上記のロジックは、彼らがセッションから追い出されないことを保証します。

---

## 制限事項

Steamネットワークは誤ったステータスの更新をブロードキャストすることでASFを誤解させるのが大好きです それはASFがプロセスを再開するのは問題ないと信じて、友人を蹴りすぎるかもしれません。 これは、 **[このFAQエントリ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)** で既に説明されている問題とまったく同じ問題です。 全く同じ解決策をお勧めします。 主に友達を `Operator` 権限(またはそれ以上)にプロモーションし、 `pause` and `resume` コマンドを使用するように伝えます。