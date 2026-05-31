# 2ファクタ認証

Steamには、さまざまなアカウント関連のアクティビティの詳細を必要とする2要素認証システムが含まれています。 You can read more about it **[here](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** and **[here](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. このページでは、2FAシステムとASF 2FAと呼ばれる統合ソリューションを考慮しています。

---

# ASFロジック：

ASFの2FAを使用しているかどうかにかかわらず、ASFには適切なロジックが含まれており、Steam上の2FAによって保護されているアカウントを完全に認識しています。 必要なとき(ログイン時など)に必要な詳細を要求します。 その情報を手動で提供することができますが、 特定のASF機能（例えば、 `MatchActively`）では、あなたのボットアカウントでASFの2FAが動作する必要があります。 ASFが必要とする場合はいつでも自動的に2FAプロンプトに応答することができます。

---

# ASF 2FA

ASF 2FAは、トークンの生成や承認の承認など、ASFプロセスに2FA機能を提供する組み込みモジュールです。 スタンドアロンモードでも動作します。 または既存の認証器の詳細を複製することによって(同時に現在の認証器とASFの2FAを使用することができます)。

`2fa` **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** を実行することで、あなたのボットアカウントがASF 2FAを使用しているかどうかを確認できます。 ASF 2FAを設定しない場合、すべての標準 `2fa` コマンドは非オペラティブになります。 つまり、モジュールを動作させる必要がある高度なASF機能ではボットが利用できないということです。

---

# Recommendations

ASF2FAを動作させる方法はたくさんあります。ここでは、現在の状況に基づいて推奨されています。

- If you're already using unofficial third-party app that allows you to extract 2FA details with ease, just **[import](#import)** those to ASF.
- 公式アプリを使用していて、2FA資格情報をリセットする必要がない場合は、2FAを無効にすることが最善の方法です。 そして **[](#creation)** 新しい2FA認証情報を **[ジョイント認証器](#joint-authenticator)**を使用して作成します。 公式アプリとASF2FAを使用することができます。 この方法 **はルート**、刑務所侵入、または任意の高度な知識を必要としません。ここで書かれた指示に従うだけで、このシナリオでは間違いなく優れています。
- 公式アプリを使用していて、2FA認証情報を再作成したくない場合は、オプションは非常に限られています。 通常は、それらの詳細を **[インポート](#import)** にルートと余分なフィドリングが必要です。 それでも不可能かもしれません。
- まだ2FAを使用しておらず、気にしないでください。 **[スタンドアロン認証システム](#standalone-authenticator)** または **[ジョイント認証システム](#joint-authenticator)** を公式アプリで使用することをお勧めします(上記と同じ)。

以下では、すべての可能なオプションについて議論し、私たちに知られています。

---

## 作成

ASFには、ASF2FAをさらに拡張する `MobileAuthenticator` **[プラグイン](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** が付属しています。 完全に新しい2FA認証システムをリンクすることができます。 これは、他のツールを使用できない場合や、他のツールを使用したくない場合に便利であり、ASF2FAがメイン(およびおそらくのみ)認証器になることを気にしないでください。 作成プロセスはジョイント認証方式でも使用されます このシナリオでは、認証器が一度に2つの場所に共存することができます - 両方が同じコードを生成し、両方が同じ確認を確認することができます。

### 両方のシナリオの一般的な手順

ASFをスタンドアロンまたはジョイント認証器として使用する予定の場合は、これらの初期化手順を実行する必要があります。

1. ターゲットアカウント用にASFボットを作成し、起動してログインしてください。
2. ここのアカウント **[](https://store.steampowered.com/phone/manage)** に作業中の電話番号と操作中の電話番号を割り当て、ボットが使用します。 これにより、SMSコードを受信し、必要に応じて回復することができます。 この手順は、すべてのシナリオで必須ではありませんが、何をしているのか分からない限り、お勧めします。
3. アカウントにまだ2FAを使用していないことを確認し、最初に無効にしてください。 This **will** put your account on temporary trade-hold, there is no way around it, only **[import](#import)** process can skip it.
4. `2diffit [Bot]` コマンドを実行し、 `[Bot]` をあなたのボット名に置き換えます。

返信が成功したとすると、次の2つのことが起こりました:

- 新しい `<Bot>.maFile.PENDING` ファイルが `config` ディレクトリに ASF によって生成されました。
- SMSはSteamから上記のアカウントに割り当てられた電話番号に送信されました。 電話番号を設定していない場合は、代わりにアカウントのメールアドレスに電子メールが送信されました。

認証器の詳細はまだ動作していませんが、生成されたファイルを確認することができます。 二重に安全にしたい場合は、たとえば、すでに取り消しコードを書き留めることができます。 次のステップは、選択したシナリオに依存します。

### スタンドアロン認証器

ASFをメイン認証子として使用したい場合は、最終確定手順を実行する必要があります。

5. Execute the `2fafinalize [Bot] <ActivationCode>` command, replacing `[Bot]` with your bot's name and `<ActivationCode>` with the code you've received through SMS or e-mail in the previous step.

### ジョイント認証器

ASFと公式のSteamモバイルアプリの両方で同じ認証システムを使用したい場合 次にもっとトリッキーなステップが必要です

5. **Ignore** the SMS or e-mail code that you've received in the previous step.
6. Steamモバイルアプリがまだインストールされていない場合はインストールして開きます。 Steam ガードタブに移動し、アプリの指示に従って新しい認証システムを追加します。
7. モバイルアプリで認証器が追加されたら、ASFに戻ります。 これで、確定する代わりに、モバイルアプリが既に以前に生成された詳細を有効にしていることをASFに通知するだけです。
 - Wait until the next 2FA code is shown in the Steam mobile app, and use the command `2fafinalized [Bot] <2FACodeFromApp>` replacing `[Bot]` with your bot's name and `<2FACodeFromApp>` with the code you currently see in the Steam mobile app - the same one you'd use for logging in to Steam (**NOT** the one you've already used for activation). ASFによって生成されたコードと提供されたコードが等しい場合。 ASFは、認証器が正しく追加されたと仮定し、新しく作成した認証器のインポートを続行します。
 - お客様の資格情報が有効であることを確認するために、上記の手順を行うことを強くお勧めします。 However, if you don't want to (or can't) check if codes are the same and you know what you're doing, you can instead use the command `2fafinalizedforce [Bot]`, replacing `[Bot]` with your bot's name. ASFは、認証器が正しく追加されたと仮定し、新しく作成した認証器のインポートを続行します。 このモードでは、ASFはコードが一致するかどうかを検証できないことに注意してください。 つまり、無効な(アクティブではない)資格情報をインポートできる可能性があります。

### 確定後

すべてが正常に動作したと仮定すると、以前に生成された `<Bot>.maFile.PENDING` ファイルは `<Bot>.maFile.NEW` に改名されました。 これは、2FA 資格情報が有効でアクティブになったことを示します。 そのファイルを `config` ディレクトリの外に移動し、 **安全な場所に** 保存することをお勧めします。 それに加えて、スタンドアロン認証を使用することにした場合。 その後、選択したエディタでファイルを開き、 `revocation_code`を書き留めることをお勧めします。 名前が示すように認証を取り消すことができます joint-authenticatorメソッドでは、すでにSteamモバイルアプリで行う必要がありますが、必要に応じて自由に行うことができます。

In regards to technical details, the generated `maFile` includes all details that we've received from the Steam server during linking the authenticator, and in addition to that, the `device_id` field, which may be needed for other (third-party) authenticators, if you ever decide to import that `maFile` into them.

ASFは、手順が完了すると認証器を自動的にインポートします。 そのため、 `2fa` やその他の関連コマンドは、認証器に接続したボットアカウントで動作するようになりました。 それを確認することをお勧めします。

---

## インポート

インポートプロセスには、ASFでサポートされているすでにリンクされた動作認証器が必要です。 私たちは2FAのいくつかの異なる公式および非公式のソースのための指示を持っています 手動で必要な資格情報を自分で入力することができます Please note that those instructions should be used **only** if you're already using given solution - since process here involves third-party apps and tools, **we do not recommend using them**, and we're mentioning it exclusively for people that already decided to use them and would like to import generated details into ASF 2FA.

一般的に、import プロセスでは適切なフォーマットの `maFile` を ASF の `config` ディレクトリにドロップします。 セキュリティ上の理由から、ASFがそのファイルをピックアップし、自動的に削除します。

以下のガイドはすべて、指定されたツール/アプリケーションで使用される **動作および動作** 認証子をすでに持っている必要があります。 ASF 2FAは、無効なデータをインポートすると正しく動作しません。したがって、インポートする前に認証器が正しく動作することを確認してください。 これには、次の認証機能が正常に動作することをテストおよび検証することが含まれます。
- トークンを生成することができ、それらのトークンはSteamネットワークで承認されます（ログインすることができます）
- 確認を取得することができ、モバイル認証に到着しています
- これらの確認に反応することができ、Steamネットワークによって承認/却下されました。

上記のアクションが動作するかどうかを確認することで認証子が動作することを確認します。そうしない場合は、ASFでは動作しません。

### アンドロイド電話

一般的に、Android 端末から認証器をインポートするには、 **[ルート](https://en.wikipedia.org/wiki/Rooting_(Android_OS))** アクセスが必要です。 以下の手順は、AndroidのModdingの世界ではかなりまともな知識を必要とします。ここではすべてのステップを説明するつもりはありません。 以下の追加情報/ヘルプについては、 **[XDA](https://xdaforums.com)** およびその他のリソースを参照してください。

**今日までに、機能し続ける確認された抽出方法は不明です。 いずれにせよ、以下の手順に従うことができます。例えば、古いバージョンのアプリでは、正常に動作することは保証されません。 代わりにjoint-authenticatorメソッドを使用することを検討してください。**

<details>
  <summary>アーカイブの説明</summary>

公式の **[Steamアプリ](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** の動作と動作を想定しています (以下にあなたのデバイスを応援する必要があります):

- **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** をインストールし、設定で Zygisk を有効にします。
- **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (Zygisk用) をインストールし、動作を確認します。
- **[SteamGuardDump](https://github.com/YifePlayte/SteamGuardDump/releases/latest)** または **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** LSPosed module and enable it in LSPosed settings.
- Steamアプリを強制終了し、それを開き、Steamガードの詳細をクリップボードにコピーするために利用できるようになりました。

必要な詳細の抽出に成功したので、毎回自動コピーを防ぐためにモジュールを無効にしてください 次に、ASF2FAに追加するアカウントの `shared_secret` と `identity_secret` の値をコピーします 以下の構造を持つ新しいテキストファイルに変換します。

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

抽出された詳細から適切な秘密鍵に各 `STRING` 値を置き換えます。 Once you do that, rename the file to `BotName.maFile`, where `BotName` is the name of your bot you're adding ASF 2FA to, and put it in ASF's `config` directory if you haven't yet.

ASFを起動し、ファイルに気づき、インポートします。 有効なシークレットを持つ正しいファイルをインポートしたと仮定すると、すべてが正常に動作し、 `2fa` コマンドを使用して確認できます。 間違いを犯した場合は、 `Bot.db` をいつでも削除して、必要に応じてやり直すことができます。

</details>

### SteamDesktopAuthenticator

すでにSDAで認証器を実行している場合は、 `maFiles` フォルダに `steamID.maFile` ファイルが存在することに気づくでしょう。 Make sure that `maFile` is in unencrypted form, as ASF can't decrypt SDA files - unencrypted file content should start with `{` and end with `}` character. 必要に応じて、SDA設定から暗号化を最初に削除し、完了したら再び有効にできます。 ファイルが暗号化されていない形式になったら、ASFの `config` ディレクトリにコピーします。

You can now rename `steamID.maFile` to `BotName.maFile` in ASF config directory, where `BotName` is the name of your bot you're adding ASF 2FA to. あるいはそのままにしておくこともできますが、ASFはログイン後に自動的に選択します。 ファイルの名前を変更すると、ログイン前にASFの2FAを使用できるようになり、ASFに役立ちます。 その後、ASFが正常にログインした後にのみファイルを選択することができます(ASFは実際にログインする前にアカウントの `steamID` を知らないので)。

ASFを起動し、ファイルに気づき、インポートします。 有効なシークレットを持つ正しいファイルをインポートしたと仮定すると、すべてが正常に動作し、 `2fa` コマンドを使用して確認できます。 間違いを犯した場合は、 `Bot.db` をいつでも削除して、必要に応じてやり直すことができます。

### WinAuth

Firstly create new empty `BotName.maFile` in ASF config directory, where `BotName` is the name of your bot you're adding ASF 2FA to. 間違った名前を指定した場合、ASFによって選択されることはありません。

通常通りWinAuthを起動します。 Steamアイコンを右クリックし、「SteamGuardとリカバリコードを表示」を選択します。 次に、「コピーを許可する」にチェックを入れます。 `{` から始まるウィンドウの下部にある JSON 構造に慣れていることがわかります。 前のステップで作成した `BotName.maFile` ファイルにテキスト全体をコピーします。

ASFを起動し、ファイルに気づき、インポートします。 有効なシークレットを持つ正しいファイルをインポートしたと仮定すると、すべてが正常に動作し、 `2fa` コマンドを使用して確認できます。 間違いを犯した場合は、 `Bot.db` をいつでも削除して、必要に応じてやり直すことができます。

### マニュアル

上級ユーザーの場合は、maFileを手動で生成することもできます。 これは、上記で説明したもの以外のソースから認証子をインポートする場合に使用できます。 **[有効な JSON 構造](https://jsonlint.com)** を持つ必要があります。

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

標準認証子データにはより多くのフィールドがあります。必要なため、インポート時にASFによって完全に無視されます。 それらを削除する必要はありません - ASFは上記の2つの必須フィールドを持つ有効なJSONのみを必要とし、追加のフィールドがあれば無視されます(もしあれば)。 もちろん、上記の例の `ストリング` プレースホルダをアカウントの有効な値に置き換える必要があります。 各 `STRING` は適切な秘密鍵で構成されるバイトの base64 エンコードされた表現でなければなりません。

---

## よくある質問

### ASFは2FAモジュールをどのように利用していますか?

ASFの2FAが利用可能である場合、ASFはASFによって送受理されている注文の自動確認のためにそれを使用します。 また、ログインするなど、必要に応じて2FAトークンを自動的に生成することもできます。 それに加えて、ASF2FAを使用すると、 `2fa` コマンドを使用することもできます。

### 2FAトークンを取得するにはどうしたらいいですか？

2FAで保護されたアカウントにアクセスするには、2FAトークンが必要です。2FAのすべてのアカウントも含まれています。 スタンドアロン認証を使用する場合は、 `2fa <BotNames>` コマンドを使用して、指定されたボットインスタンスに対して一時的なトークンを生成する必要があります。 他のすべてのシナリオでは、使用したオリジナルの認証子を使用することをお勧めします。 もっと便利ならコマンドも使えるけど。

### ASF 2FAとしてインポートした後、元の認証器を使用できますか?

はい、元の認証器は機能を維持し、ASF 2FAを使用して一緒に使用することができます。 ただし、いずれかの方法で無効にすると、リンクされた ASF 2FA 資格情報も無効になります。

### ASF 2FAを削除する方法は?

ASFを停止し、削除したいASF2FAと関連付けられた `BotName.db` を削除してください。 このオプションは、ASFと関連付けられたインポートされた2FAを削除しますが、認証システムの無効化は行われません。 ASF(最初に)からの削除を除去することを除いて、代わりに認証器を無効にしたい場合は、選択したオリジナルの認証器へのリンクを解除する必要があります。 何らかの理由でそれを行うことができない場合は、たとえばスタンドアロンモードでASFの2FAを使用しているためです。 セットアップ中に受け取った取消コードをSteamのウェブサイトで使用してください。 ASF経由での認証を無効にすることはできません。

### サードパーティのアプリで認証器をリンクし、ASFにインポートしました。 携帯電話で再度リンクできますか。

****. これを行うと、以前にインポートされた資格情報が無効になり、ASFの2FAは機能を停止します(コードを生成することによってSteamによって受け入れられなくなります)。 まず、元の認証器またはサードパーティの認証器をどこに配置するかを決定し、ASF2FAとしてインポートします。

### ジョイント認証を使用しています。アプリを別の携帯電話に移動できますか？

****. "移動"または"転送"認証器として記述されるスチームは、実際には、古いものを無効にし、新しいものを1ステップで割り当てるのと同じです。 例えばスキップすることができます。 それらの2つのステップを独立して行うことに比べて過度なクールダウンもありますが、ASFに関してはそうです。 これにより、ASFで生成した認証情報が無効になり、ASFの2FAモジュール全体が動作しないようになります。

推奨される方法は、古い携帯電話で完全にあなたの認証器を削除し、新しい携帯電話で再びジョイント認証方法を使用することです。 すでに認証システムを移動している場合、古いASF2FA認証情報はすでに無効化されています。 残されたのは"移動された"認証器を取り除いて もう一度ジョイント認証器を使って 新しい認証器をリンクさせることです

### すべての確認を受け入れるためにASFの2FAを使用することはサードパーティーの認証システムよりも優れていますか?

**はい**, いくつかの方法で. First and most important one - using ASF 2FA **significantly** increases your security, as ASF 2FA module ensures that ASF will only accept automatically its own confirmations, so even if attacker does request a trade that is harmful, ASF 2FA will **not** accept such trade, as it was not generated by ASF. セキュリティ部分に加えて、ASF2FAを使用すると、パフォーマンス/最適化の利点ももたらします。ASF2FAは生成された直後に確認を取得して受け入れます。 それからのみ、他の解決策によって達成されるX分ごとの確認のための非効率なポーリングとは対照的に。 ASF2FA経由でサードパーティー認証を使用する理由はありません。 ASFによって生成された確認を自動化することを計画している場合は、まさにASFの2FAと同じです。 それを使用することは、あなたと矛盾することはありません他のすべてを確認します。 ASFアクティビティ全体には、ASFの2FAを使用することを強くお勧めします。