# セットアップ

はじめての方、ようこそ！ 私たちのプロジェクトに興味を持っているもう一人の旅行者に会えてとても嬉しいです。 大きな力で大きな責任が生じることを念頭に置いてください - ASFはさまざまなスチーム関連のタスクをたくさん行うことができます。 しかし、あなたが ****の使い方を学ぶのに十分なケアをしている限り。 確かにウィキを読んでいます 当社のガイドラインに従い、ASFのさまざまなコンセプトについて詳しく学ぶことで、今日現在利用可能な最も強力なSteamツールの1つを使用するというユニークなスキルが報酬となります。

**一度に** を行うことをお勧めします。 ASFは多くの異なる側面に触れ、そのうちのいくつかはかなり些細なものであり、他の部分は過度に複雑になる可能性があります。 一度にすべてを理解したり読んだりする必要はありませんし、実際にはそれを簡単にすることをお勧めします。 リラックスして、自分で選択の飲み物を選んでください。 あなたの時間を1時間かけて講義に飛び込んでください - 私たちはあなたの時間の価値があることを約束することができます。

基本から始めましょう - ASFは原則としてコンソールアプリです。 一般的に使われているようなグラフィカルインターフェイスが自動的に生成されるわけではありません ASFは、主にサービス(デーモン)として機能し、デスクトップアプリではありません。 その主なユースケースの1つは、デスクトップアプリがまったく不適切なサーバーマシン上で動作することを考慮しています。 That considers only the absolute core of the program though, because ASF actually **does** include its own graphical interface - in form of its built-in ASF-ui frontend, but we'll get down to that part in due time - we're just mentioning this right away so you won't panic when seeing black console screen or something.

ASFバイナリファイルを取得すると、プログラムの設定が必要になります。これにより、ASFが達成するために何を正確に指定することができます。 この場合、ASFはデフォルト設定で起動し、eを使用することができます。 を選択します。 初期設定用の ASF-ui ですが、それ以外は事前の操作なしではあまり動作しません。

それは今のところやるでしょう、始めましょう!

---

## OS 固有の設定

一般的には、次のようにします。
- **[.NET 前提条件](#net-prerequisites)** をインストールします。
- 次に、適切な OS 固有のバリアントで **[最新の ASF リリース](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** をダウンロードします。
- 次に、アーカイブを新しい場所に抽出します。
- Then we'll **[configure ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- そして最後にASFを立ち上げその魔法を見てみましょう

ステップのいくつかは自明であり、他の人はあなたからより多くの注意を必要とします。 心配しないで、私たちはあなたを援護しています。

---

### .NET prerequisites

まずは、お使いの OS で ASF が正しく起動できるかを確認して下さい。 それを知る必要はありませんが、ASFはC#に基づいて書かれています。 ETプラットフォームで、まだプラットフォーム上で利用できないネイティブライブラリが必要な場合があります。 3Dゲーム、またはあなたの車を開始するためのエンジンのためのDirectXのようなそれについて考えなさい。

Windows、Linux、macOSのいずれを使用するかによって、要件が異なります。 The reference document is **[.NET prerequisites](https://docs.microsoft.com/dotnet/core/install)**, but for the sake of simplicity we've also detailed all needed packages below, so you don't need to read it at all, unless you run into problems or you'll have additional questions.

ASF が依存するソフトが、他のソフトによってすでに一部または全てインストールされていることが普通です。 それでも、そうである必要はありません。 OSに適切なインストーラを実行する必要があります - これらの依存関係がなければASFはまったく起動しません 何が間違っているのかを伝えるための有用な情報はほとんど得られません

OS固有ビルドの場合、.NET SDKやランタイムのインストールなど、他に何もする必要がないことを覚えておいてください。OS固有パッケージにはそれらがすべて含まれているからです。 実行するには .NET 前提条件 (依存関係) のみが必要です。 ASFに含まれるETランタイムは、他の追加なしに、以下で指定したもののみです。

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** for 64-bit, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** for 32-bit or **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** for 64-bit ARM)
- すべてのWindowsアップデートがすでにインストールされていることを確認することを強くお勧めします。 有効にしていない場合は、少なくとも**[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)**と**[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**が必要ですが、さらに多くのアップデートが必要な場合があります。 Windowsが最新の状態であるか、少なくとも最新の状態であるかどうかを心配する必要はありません。

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**
パッケージ名は使用している Linux ディストリビューションに依存しますが、ここでは最も一般的なものをリストアップしました。 あなたの OS のネイティブのパッケージマネージャ（例えば Debian なら `apt`、CentOS なら `yum`）を使っても、これらをインストールすることが可能です。 これらは、どのディストリビューションを使っていても利用できるべきかなり標準的なライブラリです。 彼らがどのように呼ばれているかを知るのはあなたの選択の環境の問題です

- `ca-certificates`（HTTPS接続を行うための標準的な信頼できるSSL証明書）
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, あなたのディストリビューションの最新バージョン, 例えば `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3`（`libssl`、`openssl-libs`、ディストリビューション用の最新バージョン、少なくとも`1.1.X`）
- `libstdc++6`（`libstdc++`、バージョン`5.0`以上）
- `zlib1g` (`zlib`)

これらの大部分は、すでにシステム上でネイティブに利用可能であるはずです。 例えば、Debian stable の最小インストールは通常、 `libicu76` のみを必要とします。

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**
- 具体的には何も必要ありませんが、最新バージョンの macOS がインストールされている必要があります。少なくとも 12.0+

---

### ダウンロード

前の節で必要な依存関係はすべて揃っているはずので、本節では&#8203;**[最新の ASF リリース](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**&#8203;をダウンロードします。 ASF には多くの種類がありますが、ご利用の OS やアーキテクチャに合うパッケージを選んで下さい。 例えば、`64` ビット `Win`dows を使用している場合、`ASF-win-x64` パッケージをダウンロードして下さい。 利用可能なバリアントの詳細については、&#8203;**[互換性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-ja-JP)**&#8203;セクションを参照してください。 ASFは、OS固有のパッケージを構築していない環境でも動作することができます。 例えば、 **32-bit Windows**などですが、 **[汎用セットアップ](#generic-setup)** が必要です。

![アセット](https://i.imgur.com/Ym2xPE5.png)

ダウンロードしたら、まずは zip ファイルをお好きなフォルダに解凍して下さい。 If you require a specific tool for that, **[7-zip](https://www.7-zip.org)** will do, but all standard utilities like built-in Windows extraction or `unzip` from Linux/macOS should work without problems as well.

ASFを **独自のディレクトリ** に展開し、既存のディレクトリではなく、既存のディレクトリAformat@@2に展開することをお勧めします。 ASFには自動更新機能が含まれており、それは自分のファイルを置き換え、アップグレード時に古いファイルと関連しないファイルはすべて削除されます。 それはASFディレクトリに入れた無関係なものを失う可能性があります。 ASFで使用したい追加のスクリプトやファイルがある場合は、問題ありません。 専用のフォルダを作成すると、いつでもASFを1つ深いフォルダに入れることができます。

構造体の例は以下のようになります:

```text
C:\ASF (where you put your own things)
    ├── MyNotes.txt (optional)
    ├── AsfMakeMeCoffeeScript.bat (optional)
    ├── (...) (any other files of your choice, optional)
    └── Core (dedicated to ASF only, where you extract the archive)
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         ├── www
         └── (...)
```

---

### 設定

最後に設定を行います。 ASFは「ボット」の概念で動作し、それぞれのボットは通常、ASF内で使用したい単一のSteamアカウントです。 あなたが望むだけ多くのボットを宣言することができますが、スターターのために、私たちはそれらのうちの1つだけに焦点を当てます - 通常、あなたのメインアカウント。 ASFにはボット以外の設定ファイルもあり、最も重要なものは、インスタンス内のすべてのボットに影響を与えるグローバル設定ファイルです。

The general rule of thumb is that **if you don't know, or don't understand some setting, you should leave it with its default value, without changing anything**. ASFは、上記のように、ほぼすべての機能を設定、カスタマイズ、調整する無数の方法を提供します。 コウモリからすぐに理解しようとするのはウサギの穴で あなたをひどい混乱に陥れるかもしれない **[でなければ、](https://www.youtube.com/watch?v=KK3KXAECte4)** に直接入ります。 Instead, we recommend to have a working example first, and only then start digging into additional options, with the help of **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** page on the wiki, while changing **one thing at a time**.

ASFの設定は、ASF-uiフロントエンド、スタンドアロンのWeb設定ジェネレータ、または手動で行うことができます。 この部分も&#8203;**[設定](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-ja-JP)**&#8203;ページで詳しく書かれている、詳しく知りたい方はそちらを。 何らかの理由でASF-uiの起動や正しく動作しなくても動作するため、スタンドアロンのWeb設定ジェネレータを出発点として使用します。

**[Web config generator](https://justarchinet.github.io/ASF-WebConfigGenerator)** ページに移動し、お気に入りのブラウザを使用します。 ChromeまたはFirefoxをお勧めしますが、お使いのブラウザが他のすべてで動作する限り、それは重要ではありません。

ページを開いたら、「Bot」タブに切り替えて下さい。 下のようなページが表示されているはずです。

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

もしダウンロードした ASF のバージョンがWeb Config Generatorのデフォルトのバージョンよりも古い場合は、ドロップダウンメニューからお使いの ASF のバージョンを選択してください。 configジェネレータはまだ安定していなかった新しい(プレリリース)ASFバージョンにconfigを生成するために使用することができるため、これは(まれに)起こり得ます。 確実に動作することが確認された最新の安定版ASFをダウンロードしました。 絶対最先端より少し古いかもしれませんが初めて使うのには不向きです

Start from **putting name for your bot** into the field highlighted as red, called `Name`. ニックネーム、ユーザー名、数字、何でもよくて、お好きなように名前を付けて下さい。 但し、`ASF` とだけは名付けてはいけません。 その他にも、ASFはこれを無視するので、ボット名を「`.`」（点）で始まる名前にしてはいけません。 スペースの使用を避けることをお勧めします。 必要に応じて単語区切り文字として `_` を使用できます。厳密な要件ではありません。 しかし、それ以外の場合はASFコマンドを使用するのは難しいでしょう。

Botの名前が決まりましたか？ 素晴らしい、次のステップでは、 ** `を有効にする` スイッチを**にする これは、(プログラムの)起動後に自動的にASFがボットを起動することになっているかどうかを定義します。 これを行わないと、ASFは設定ファイルでボットが無効になっていることを示します。 入力が始まるのを待つのですこの例ではやりたくないことです

`SteamLogin` と `SteamPassword` の二つの機密性の高いプロパティがあります。 ここで別の決定を行うことができます - Steamログインの詳細をこれらの2つのプロパティに入れることができます。 それとも空っぽにしておくかどうかを決めることもできます

ASF には Steam クライアントの独自の実装が含まれているため、Steam 公式アプリと同じくログイン認証情報を必要とします。 ログイン資格情報はどこにも保存されませんが、ASF `config` ディレクトリ内の PC にのみ保存されます(生成された設定をダウンロードすると)。 当社のウェブ設定ジェネレータはクライアントベースのアプリケーションです。つまり、スタンドアロンの Web config-generator ウェブサイト内で行っていることはすべて、有効な ASF 設定を生成するために、ブラウザ内でローカルで実行されていることを意味します。 詳細を入力せずに、PCを最初の場所に残しているので、機密データの漏洩を心配する必要はありません。 ただし、何らかの理由で資格情報を入力したくない場合は、私たちはそれを理解しています。 生成されたファイルに手動で入れたり、完全に省略して無しで操作することができます

認証情報を入力すると、ASFは起動時に自動的にログインすることができます。 オプションの2FAと一緒に効果的にプログラムをダブルクリックしてすべてを実行することができます。 If you decide to omit them, then ASF will **ask you** to input those details when needed - that approach won't save them anywhere, but naturally ASF won't be able to operate without your help. **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** セクションでは、通常どちらの方法で追加の情報を見つけることができます。

サイドノートとして、 `SteamPassword` のように、空欄のフィールドを1つだけ残すこともできます。 ASFは自動的にログインを使用することができますが、必要に応じてパスワードを要求します(Steam クライアントと同様)。 万が一、アカウントのロックを解除するために4桁のペアレンタル端子を使用している場合。 また、 `SteamParentalPin` ボックスに入れることをお勧めします。 この場合も空のままにしておくことができます 代わりにその保護がいかに弱いかを観察してください ASFはログイン後わずか数秒で自分自身を「割る」こともできます。 おっと！

After following with everything above, so once again, **bot name**, **enabled switch**, and **login credentials** , your web page will now look similar to the one below:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

「ダウンロード」ボタンを押すと、ボットの名前に基づいて新しい `json` ファイルが生成されます。 そのファイルを、前のステップでzipファイルを抽出したフォルダ内にある `config` ディレクトリに保存します。

ヨシッ！ これで ASF ボットの基本的な設定が完了しました。 まだまだ発見すべきことがたくさんありますが、今のところ、これがすべてです。

---

### ASF の実行

あなたがこの瞬間を待っているのは分かっています。長くお待ちしております。 初めてプログラムを起動する準備ができました ASF ディレクトリ内の `ArchiSteamFarm` バイナリをダブルクリックして下さい。 コンソールから起動してもOKです。

ASFがプログラムされていることが気になる場合は、 **[リモート通信](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** セクションを確認してください。 特にあなたの名前で実行されます。 例えば、デフォルトで Steamグループに参加するなど。 選択された機能を後で無効にすることができます。気に入らない場合は、ASFには賢明なデフォルトが付属しています。 一般的な使い方を決めなければなりませんでした 我々自身の見解を理念に基づいています

最初のステップで必要なすべての依存関係をインストールすることを主に考慮して、すべてがうまくいったと仮定します。 3つ目のASFを設定すると、ASFが正しく起動し、最初のボットを発見し、ログインを試みます：

![ASF](https://i.imgur.com/u5hrSFz.png)

ASFはアカウントにアクセスするために2FAの詳細が必要になる可能性があります(SteamGuardを完全に無効にしない限り、いいえ)。 画面の指示に従うだけで、認証システム/電子メールからコードを入力するか、モバイルアプリで確認を受け入れることができます。

何か問題が発生しましたか？

#### ASFが起動せず、コンソールウィンドウがありません

.NETの前提条件が不足しているか、マシン用に誤ったASFのバリアントをダウンロードしているかのいずれかです。 If you don't know what's wrong, check our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** for a possible way to find out exact problem, and if you're still stuck, reach for our **[support](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### ボットが定義されていません

生成された設定を `config` ディレクトリに入れませんでした。 Some other common mistakes in this step might include manually changing extension from `.json` e.g. to `.txt`, and some operating systems (e.g. Windows) like to hide common extensions by default, so ensure your file is in appropriate place and also with appropriate name.

#### 設定ファイルで無効になっているため、このボットを起動していません

`有効化された` スイッチを反転させるのを忘れています。これにより、ASFが自動的にボットを開始するように指示されます。 Unless that was your intention of course, but then you should already know how to execute commands, simply `start` your bot after that message.

#### `無効なパスワード`

ログイン資格情報が間違っている可能性があります。 生成された設定で `SteamLogin` と `SteamPassword` を確認し、間違っている場合は、設定ステップに戻って修正します。 それでも問題が解決しない場合は、Steamクライアントで同じログイン資格情報を使用してみてください - ログインに失敗することもあります。 この方法で何が間違っているのかもっと多くの情報が得られるかもしれません

#### すべて順調ですか？

最初のログインゲートを通過した後、詳細が正しいと仮定すると、正常にログインできます。 ASFは、今の時点では触れなかったデフォルトの設定で農業を始めます。

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

つまり、ASF はあなたのアカウントを使って、正常に動作していることを意味します。プログラムを最小化にして他のことをしてもいいってわけね。 どうぞ、あなたはそれを当然のこととし、多分あなたの選択の飲み物を少なくとも補充します!

農業カードはこのような別の長い記事の主題です。 しかし、原則として: 十分な時間の後 ( **[パフォーマンス](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**に依存) スチームトレーディングカードがゆっくり落とされているのが分かります。 Of course, for that to happen you must have valid games to farm, showing as "you can get X more card drops from playing this game" on your **[badges page](https://steamcommunity.com/my/badges)** - if there are no games to farm, then ASF will state that there is nothing to do, as stated in our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, which answers the most common question people have at this point, wondering why despite owning whopping 14 games on their account, ASF claims there's nothing to do - no, it's not a bug.

基本的な初期設定はここまでだ。 すべてのRPGゲームと同様に、チュートリアルを終了し、ASFの世界全体を今すぐ探索するために残します。 たとえば、ASFをさらに構成するか、デフォルト設定でジョブを実行させるかを決定できるようになりました。 もう少し詳しく読んで、Wiki全体を残して発見しておきたい場合は、もっと基本的な詳細を取り上げます。

---

### 拡張設定

#### 複数アカウントのファーミング

ASFは複数アカウントの同時ファーミングをサポートしています。これはASFの主機能のひとつです。 ボット設定ファイルを複数作成し、configフォルダに保存してください。 注意点は2つ：

- ユニークなボット名は、 `MainAccount`という名前の最初のボットをすでに持っている場合は、同じ名前のボットを持つことはできません。
- `SteamLogin`, `SteamPassword` および `SteamParentalCode` などの有効なログイン情報（入力を決定した場合）

つまり、設定手順をもう一度繰り返すだけです。 既存の設定を上書きしないように、すべてのボットに一意の名前を使用することを忘れないでください。

---

#### 設定の変更

スタンドアロンの Web config-generator では、新しい設定ファイルを生成することで、既存の設定をまったく同じ方法で変更します。 「高度な設定を切り替える」をクリックして、あなたが見つけるためにそこにあるものを確認してください。 この例では、 `CustomGamePlayedWhileFarming` の設定を変更します。 これは、実際のゲームを表示するのではなく、ASFが農業をしているときに表示されるカスタム名を設定できます。

まずはこれを少し分析してみましょう。 ASFを実行して農業を始めると、デフォルトの設定でSteamアカウントがゲーム内にあることがわかります:

![Steam](https://i.imgur.com/1VCDrGC.png)

ASFがSteamプラットフォームにゲームをプレイしていると言っただけで、それからカードが必要ですよね? しかし、ちょっと、私たちはこれをカスタマイズすることができます! まだ行っていない場合は、高度な設定を切り替えてから、 `CustomGamePlayedWhileFarming` を見つけます。 "Idling cards" など、表示したい任意のカスタムテキストを置くだけです。

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

新しい設定ファイルをダウンロードし、古いファイルを上書きしてください。ASFを再起動すると、カスタムテキストが表示されるようになります。 古い設定ファイルを削除し、新しいファイルをその場所に置くこともできます。

ASFはかなりスマートで、設定を変更したことに気づくはずです。 プログラムの再起動なしに自動的にピックアップされ適用されるはずです それが起こらなかった場合は、プログラムを再起動するだけで、新しい設定が確実に取得されます。 その後、ASFが以前の場所にカスタムテキストを表示するようになりました。

![Steam 2](https://i.imgur.com/vZg0G8P.png)

設定が正常に編集されたことが確認できました。 同じ方法で、グローバルASF設定も変更できます。「Bot」タブから「ASF」タブに切り替え、生成された`ASF.json`を`config`ディレクトリに保存してください。

ASFの設定ファイル編集は、後述するASF-uiフロントエンドを使うとさらに簡単に行えます。

---

#### ASF-uiの利用

前述したように、ASFはコンソールアプリであり、グラフィカルユーザーインターフェイスをデフォルトで起動しません。 ですが、**[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**フロントエンドをIPCインターフェース経由で利用できます。これは非常に使いやすいGUIです。

ASF-uiを使用するには、 `IPC` を有効にする必要があります。 これはデフォルトのオプションです。手動で無効にしない限り、すでにアクティブです。 ASFを起動すると、自動的にIPCインターフェースが開始されます。

![プロセス間通信](https://i.imgur.com/ZmkO8pk.png)

IPCは、一言で言えば、マシン上でローカルに起動するASFのWebサーバーを内蔵しています。 お気に入りのWebブラウザを使用して操作することができます。 正しく起動したと仮定すると、この **[](http://localhost:1242)** リンクをクリックしてASFのIPCインターフェイスにアクセスできます。 ASFが走っている限り、同じマシンから。 ASF-uiでは設定ファイルの編集や**[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**送信などが可能です。 色々試してみてください。

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### まとめ

Steamアカウントを使用するためのASFのセットアップに成功し、すでに少し自分好みにカスタマイズしたことでしょう。 ガイド全体をフォローしている場合は、ASF-uiインターフェースを介してASFを微調整し、その機能を発見し始めました。 これでチュートリアルは終わりますが、あなたが興味を持っているかもしれないものへのいくつかの追加のポインタを残します。「サイドクエスト」を主張する場合:

- **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** セクションでは、実際に見た **** すべての異なる設定について説明します。 ASFがあなたに提供できる他に何か。 ちょうど読書中に適切に水分補給することを覚えなさい、あなたは警告された。
- 問題に遭遇したり、一般的な質問がある場合は、 **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**をご検討ください。 少なくとも大多数の質問や問題をすべてカバーすることができます
- ASFについて、そしてASFがどのようにあなたの生活を楽にするのか、すべてを学びたいのであれば、**[我々のwiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**の残りの部分をご覧ください。 右側のサイドバーを使用して、興味のある主題を選択します。
- And finally, if you found out our program to be useful for you and you appreciate the massive amount of work that was put into it, you can also consider a small **[donation](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** to our cause. ASFは愛の労力です。私たちはこの10年以上、この経験をあなたのためにできるように、自由な時間に努めてきました。 そして私たちはそれを非常に誇りに思っています - 1ドルでも高く評価され、あなたが気にすることを示しています。 いずれにせよ、たくさんの楽しみがあります!

---

## 汎用設定

この付録は、ASFを **[ジェネリック](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)** バリアントで実行するように設定した上級ユーザー向けです。 **[OS 固有の](#os-specific-setup)**よりも使い方が面倒ですが、追加のメリットもあります。

主に `ジェネリック` バリアントを使用する場合:
- OS固有のパッケージ(32ビットWindowsなど)をビルドしないOSを使用しています。
- .NET Runtime/SDKが既にあるか、インストールして使用します。
- ランタイム要件を自分で処理して、ASF構造のサイズとメモリのフットプリントを最小限に抑えたい場合
- カスタム **[プラグイン](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** を使用します。このプラグインでは、(ネイティブの依存関係が不足しているため) 正しく実行するために ASF の `ジェネリック` セットアップが必要です。

もちろん、あなたが望む他のシナリオでもそれを使用することができますが、上記は最も理にかなっています。

ただし、一般的なセットアップには、この場合、 **** が .NET ランタイムを担当していることに留意してください。 つまり、.NET SDK(ランタイム)が使用できない、時代遅れ、または壊れた場合、ASFは単に動作しません。 このため、カジュアルなユーザーにはこのセットアップはお勧めできません。 ETSDK(ランタイム)はASF要件に合致し、 **** ではなくASFを実行することができます。 ASFにバンドルされたETランタイムは、そうすることができます。

`generic` パッケージの場合、上記の OS 固有のガイド全体に従うことができます。 In addition to installing .NET prerequisites, you also want to install .NET SDK, and instead of downloading and having OS-specific `ArchiSteamFarm(.exe)` executable file, you'll now download and have a generic `ArchiSteamFarm.dll` binary only. 他は同じです。

追加手順：
- **[.NET prerequisites](#net-prerequisites)** をインストール。
- **[.NET SDK](https://www.microsoft.com/net/download)**（またはASP.NET Core・.NETランタイム）をOSに合わせてインストール。 ほとんどの場合、インストーラを使用するのが好ましいです。 どのバージョンか不明な場合は**[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**参照。
- **[最新ASFリリース](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**を`generic`バリアントでダウンロード。
- アーカイブを新しい場所に解凍。
- **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**を上記とまったく同じ方法で設定します。
- ヘルパースクリプトまたは`dotnet /path/to/ArchiSteamFarm.dll`コマンドでASFを起動

Generic variant of ASF does not have machine-specific binary, after all it's called `generic` for a reason - it's platform-agnostic build that can work everywhere, so don't expect `exe` file there.

This is why we've bundled it with helper scripts (such as `ArchiSteamFarm.cmd` for Windows and `ArchiSteamFarm.sh` for Linux/macOS), which are located next to `ArchiSteamFarm.dll` binary. 手動で `dotnet` コマンドを実行したくない場合に使用できます。

もちろん、インストールしていない場合、ヘルパースクリプトは動作しません。 ET SDK と、 `dotnet` 実行可能ファイルが `PATH` にはありません。 They're also entirely optional to use, you can always `dotnet /path/to/ArchiSteamFarm.dll` manually if you'd like to, as under the hood with some extra tweaks, that's exactly what those scripts are doing anyway.