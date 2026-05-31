# よくある質問

私たちの基本的なFAQはあなたが持つかもしれない標準的な質問と回答をカバーしています。 あまり一般的でない問題については、代わりに **[拡張FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ)** をご覧ください。

# 目次

* [一般](#general)
* [類似ツールとの比較](#comparison-with-similar-tools)
* [セキュリティ/プライバシー/VAC/BAN/ToS](#security--privacy--vac--bans--tos)
* [その他](#misc)
* [課題](#issues)

---

## 一般

### ASFとは？
### なぜプログラムは私のアカウントで養殖するものがないと主張するのですか?
### ASFが私のすべてのゲームを検出できないのはなぜですか?
### アカウントが制限されているのはなぜですか?

ASFが何であるかを理解しようとする前に、スチームカードが何であるかを理解しておく必要があります。 そして、公式のFAQ **[ここの](https://steamcommunity.com/tradingcards/faq)** でうまく説明されています。

要するに、スチームカードは、特定のゲームを所有するときにあなたが対象となるコレクションアイテムです。 そして、バッジの作成、Steamマーケットでの販売、またはあなたの選択の他の目的に使用できます。

ここでもう一度コアポイントが述べられています なぜなら一般的な人々は彼らに同意したくないし、それらが存在しないふりをすることを好まないからです

- **Steamアカウントでゲームを所有している必要があります。 家族の共有は所有権ではなく、カウントされません。**
- **あなたのゲームは [プライベート](https://help.steampowered.com/faqs/view/1150-C06F-4D62-4966)としてマークすることはできません。農業中に、ASFは自動的にそのようなゲームをスキップします。**
- **ゲームを無限に農夫することはできません、すべてのゲームはカードドロップの数が固定されています。 あなたがそれらのすべてを(完全なセットの約半分)落とすと、ゲームはもはや農業の候補者ではありません。 それはあなたが得たそれらのカードに何が起こったかを販売、取引、細工または忘れても問題ではありません。 カードがなくなったらゲームは終了です。**
- **F2Pゲームからカードをドロップするには、お金を費やす必要があります。 これは、チーム要塞2やDota 2のような恒久的なF2Pゲームを意味します。 F2Pゲームを所有していると、カードドロップは許可されません。**
- **所有しているゲームやアクティベーション方法に関係なく、 [限定アカウント](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)にカードをドロップすることはできません。**
- **プロモーション中に無料で獲得した有料ゲームは、店舗ページに表示されているものにかかわらず、カードドロップで養殖することはできません。**

見ることができるように、Steamカードはあなたが購入したゲームをプレイするためにあなたに授与されます。 またはあなたがお金を入れているF2Pゲーム。 このようなゲームを十分に長くプレイした場合、そのゲームのすべてのカードは最終的にインベントリにドロップされます。 バッジを(セットの残りの半分を取得した後)完成させるか、それらを販売するか、またはあなたが望むことを何でも行うことができます。

Steamの基本について説明しましたので、ASFを説明します。 プログラム自体は完全に理解するには非常に複雑なので、技術的な詳細をすべて調べる代わりに、以下で非常に簡単な説明を提供します。

ASFは、提供された資格情報を使用して、カスタムSteamクライアントの実装を通じてSteamアカウントにログインします。 ログインに成功した後 **[バッジは](https://steamcommunity.com/my/badges)** を解析し、農業で利用可能なゲームを見つけます（残り`X` カードのドロップ）。 すべてのページを解析し、利用可能なゲームの最終リストを構築した後、ASFは最も効率的な農業アルゴリズムを選択し、プロセスを開始します。 プロセスは、選択された **[カード養殖アルゴリズム](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** に依存しますが、通常は適格なゲームをプレイし、ゲームがすでに完全に養殖されているかどうかを定期的に(アイテムドロップに加えて)チェックすることで構成されています - はいの場合。 ASFは、すべてのゲームが完全に養殖されるまで、同じ手順で次のタイトルに進むことができます。

上記の説明は簡素化されており、ASFが提供する多数の追加機能や機能は説明されていないことに注意してください。 ASFの詳細を知りたい場合は、残りのWiki **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki)** をご覧ください。 私は技術的な詳細を持って来ることなく、誰にとっても理解するのに十分なシンプルにしようとしました - 上級ユーザーは深く掘り下げることを奨励されます。

今、プログラムとして - ASFはいくつかの魔法を提供します。 まず、あなたのゲームファイルをダウンロードする必要はありません。すぐにゲームをプレイできます。 第二に、それはあなたの通常のSteamクライアントから完全に独立しています - あなたはSteamクライアントを実行しているか、あるいはまったくインストールする必要はありません。 第三に、それは自動化されたソリューション - ASFはあなたの背後にあるすべてを自動的に行うことを意味します 何をすべきかを伝えることなく、手間と時間を節約できます。 最後に、直接通信できるため、プロセスエミュレーション(例えば、Idle Masterが使用しているなど)によってSteamネットワークを騙す必要はありません。 それはまた超高速で軽量です 多くの手間をかけずに簡単にカードを取得したいすべての人のための素晴らしい解決策であること - それは他の何かをしながら、バックグラウンドで実行して残すことによって特に便利です。 オフラインモードで遊ぶこともできます

上記のすべてが素晴らしいです しかし、ASFにはSteamによって強制される技術的な制限もあります - 私たちはあなたが所有していないゲームをファームすることはできません。 強制された限界を超えるために永遠にゲームを育てることはできない そして、あなたがプレイしている間にゲームを育てることはできない ASFの仕組みを考慮すると、それらはすべて「論理的」である必要があります。 しかし、ASFには超能力がなく、物理的に不可能ではないことに注意してください。 だから、心に留めておいてください - それは基本的に別のPCからあなたのアカウントにログインし、あなたのためにこれらのゲームをファームするように誰かに言った場合と同じです。

だから要約する - ASFはあなたがのために資格があるそれらのカードをドロップするのに役立つプログラムです。 それはまたいくつかの他の機能を提供しますが、とりあえずこの機能に固執しましょう。

---

### アカウント情報を入力する必要がありますか？

**はい**. ASFはSteamネットワークの相互作用に同じ方法を使用しているため、公式のSteamクライアントと同じ方法でアカウントの認証情報を必要とします。 ただし、アカウントの資格情報をASF設定に入れる必要はありません。 空の `SteamLogin` または `SteamPassword`を使用して、ASFを使い続けることができます。 そして、各ASF実行時にそのデータを入力します(他のログイン資格情報は、設定を参照してください)。 この方法であなたの詳細はどこにも保存されませんが、もちろんASFはあなたの助けなしで自動起動することはできません。 ASFには、 **[セキュリティ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**を増やす方法もいくつか用意されています。 上級ユーザーの方は自由にwikiの一部を読んでください アカウントの認証情報をASF設定に入れたくない場合は、 そして、単にそれをしないで、代わりにASFがそれらを要求するときに必要に応じて入力します。

ASFツールはあなたの個人的な使用のためのものであり、あなたの資格情報はあなたのコンピュータから離れることはありません。 **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** - 多くの人が忘れてしまう非常に重要なことです。 お客様の情報を当社のサーバーまたは第三者に送信することはありません。バルブが運営するSteamサーバーにのみ直接送信することができます。 私たちはあなたの資格情報を知らないため、それらを設定に入れるかどうかに関わらず、あなたのためにそれらを回復することができません。

---

### カードがドロップするまでにはどのくらいの時間がかかりますか？

**** - 真剣にかかる限り。 すべてのゲームは、開発者/パブリッシャーによって設定された異なる農業の困難を持っています, そして、それは完全にそれらのカードがどのくらいの速さでドロップされています. ゲームの大部分は、プレイの30分ごとに1ドロップに従ってください。 カードを落とす数時間前までにプレイするゲームもあります それに加えて、アカウントはまだ十分な時間プレイしていないゲームからのカードドロップの受信を制限することができます。 **[パフォーマンス](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** セクションで述べたように。 ASFが与えられたタイトルを与えられた時間を推測しようとしてはいけません - それはあなた次第ではなく、ASFも決定します。 あなたがより速くするためにできることは何もありません。 そして、タイムリーな方法でドロップされていないカードに関連する「バグ」はありません - あなたはカードのドロッププロセスを制御しない、どちらもASFはありません。 最良の場合、30分あたり平均1滴を受け取ることができます。 最悪の場合は、ASFを開始してから4時間もカードを受け取ることはありません。 両方の状況は正常であり、私たちの **[パフォーマンス](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** セクションでカバーされています。

---

### 農業に時間がかかりすぎて、何とかスピードを上げることができますか。

農業の速度に大きく影響を与える唯一のものは、ボットインスタンスのために **[カード農業アルゴリズム](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** を選択されます。 他のすべては無視できる効果を有し、より速く農業を作ることはありません。 ASFプロセスを数回起動するなどのいくつかのアクションは、 **さらに悪い**になります。 農業プロセスから毎秒を作るという衝動が本当にあれば ASFを使用すると、 `FarmingDelay` のようないくつかのコア農業変数を微調整することができます。それらはすべて **[構成](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** で説明されます。 しかし、私が言ったように、効果は無視できます。 そして特定の口座に適切なカード養殖アルゴリズムを選ぶことは一つであり 農業の速度に大きな影響を与える唯一の重要な選択です 他のものは全て純粋な化粧品です 農業の速度を気にする代わりに ASFを起動し、その仕事をさせてください - 私が思いつく最も効果的な方法でそれをやっていることを保証できます。 あなたが気にしないほど、あなたは満足するでしょう。

---

### しかし、農業には約X時間がかかるとASFは言った!

ASFは、ドロップする必要があるカードの数に基づいてラフな近似を提供します。 そして、あなたが選んだアルゴリズム-これは、あなたが農業に費やす実際の時間とはどこにも近くありません。 これは通常これよりも長くなりますが、ASFが最良のケースを想定しており、Steam Networkのすべての気まぐれを無視しています。 インターネット接続の切断、Steamサーバーの過負荷など。 ASFがどのくらいの期間農業を行うことができるかを一般的な指標としてだけ見る必要があります。 多くの場合実際の時間が異なりますが 場合によっては大幅に異なります 上記のように指摘されたように、与えられたゲームがどのくらい養殖されるかを推測しようとしないでください、それはあなた次第ではありません、ASFも決定します。

---

### ASFは私のアンドロイド/スマートフォンで動作できますか?

ASFは.NETの実装を必要とするC#プログラムです。 Android became a valid platform starting with .NET 6.0, however, there is currently a major blocker in making ASF happen on Android due to **[lack of ASP.NET runtime available on it](https://github.com/dotnet/aspnetcore/issues/35077)**. 利用可能なネイティブオプションはありませんが、ARMアーキテクチャ上でGNU/Linux用の適切で動作しているビルドがあります。 したがって、Linuxのインストールに **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** のようなものを使用することは完全に可能です。 そんなLinuxのクロートでASFを使います。

すべてのASF要件が満たされた場合は、公式のAndroidビルドをリリースすることを検討します。

---

### ASFは、CS:GOやUnturnedなどのスチームゲームからファームアイテムを取得できますか?

**No**, this is against **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** and Valve clearly stated that with last wave of community bans for farming TF2 items. ASFは、ゲームアイテム農家ではなく、Steamカード農業プログラムです。ゲームアイテムを農業する能力はありません。 今後はそのような機能を追加する予定はありませんが、主にSteam利用規約に違反したためです。 これについて質問しないでください - あなたが得ることができる最善は、いくつかの塩辛いユーザーからのレポートであり、あなたが問題を抱えています。 同じことは、CS:GOの放送からの農業ドロップなど、他のすべての種類の農業のために行く。 ASFはスチームトレーディングカードだけに注力しています。

---

### どのゲームを遠ざけるべきか選択できますか?

**はい**, いくつかの異なる方法で. あなたが農業隊列のデフォルトの順序を変更する場合、 そして、 `FarmingOrders` **[ボット構成プロパティ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** を使用することができます。 自動的にファームされないように、指定されたゲームを手動でブラックリストに登録したい場合 アイドル状態のブラックリストは、 `fb` **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** で使用できます。 すべてをファームしますが、他のすべてよりもいくつかのアプリを優先させたい場合。 これは、 `fq` **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** で使用できるアイドル優先キューです。 そして最後に、あなただけのあなたの選択の特定のゲームをファームしたい場合。 その後、ボットの `` **[`FarmingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)** でこれを達成するために宣言できます。 選択したアプリをアイドル優先順位キューに追加します。

In addition to managing automatic cards farming module which was described above, you can also switch ASF to manual farming mode with `play` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, or use some other misc external settings such as `GamesPlayedWhileIdle` **[bot configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

---

### 私はカードドロップに興味がないので、代わりに再生時間を農場にしたいのですが、それは可能ですか?

はい、ASFは少なくともいくつかの方法でそれを行うことができます。

そのための最良の方法は、 **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** 設定プロパティを使用することです。 ASFにファームへのカードがない場合、選択したアプリIDを再生します。 If you'd like to play your games all the time, even if you do have card drops from other games, then you can combine it with **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, so ASF will farm only those games for card drops that you explicitly set, or, alternatively, **[`FarmingPausedByDefault`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, which will cause cards farming module to be paused until you unpause it yourself.

**[`play`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#commands-1)** コマンドを使用することもできます。これにより、ASFが選択したゲームをプレイします。 ただし、 `` は一時的にプレイしたいゲームにのみ使用することに注意してください。 永続的な状態ではないため、ASFはデフォルトの状態に戻ります。 Steamネットワークから切断された際。 そのため、 `GamesPlayedWhileIdle`を使用することをお勧めします。 選択したゲームを短期間だけ開始し、一般的なフローに戻す必要がない限り。

---

### 私はLinux/macOSユーザーですが、ASFファームゲームはOSで利用できませんか? ASFは32ビットOSで実行しているときに64ビットゲームをファームすることができますか?

はい、ASFは実際のゲームファイルをダウンロードするのにさえ悩んでいません プラットフォームや技術的な要件に関係なく、Steamアカウントに関連付けられているすべてのライセンスで動作します。 マッチング領域にいない場合でも、特定の領域(リージョンロックされたゲーム)に関連付けられたゲームでも動作するはずです。 それは保証できませんが(前回試した時には効果がありました)

---

## 類似ツールとの比較

---

### ASFはIdle Masterに似ていますか?

唯一の類似点は、カードドロップを受け取るためにスチームゲームを農業している両方のプログラムの一般的な目的です。 実際の農業方法、プログラム構造、機能性、互換性、使用されたアルゴリズム、特にソースコード自体を含む他のすべて。 全く異なり、IMが実行されている中核基盤でさえ、これら2つのプログラムはお互いに共通するものではありません。 ETフレームワーク、.NET (Core)でASF。 簡単なコード編集では解決できなかったIM問題を解決するためにASFが作成されました。これがASFがゼロから書かれた理由です。 IMの一般的なアイデアを使わなくても良いのです そもそもコードとアイデアは完全に欠陥があったからです IMとASFはWindowsとLinuxのようなものです - どちらもオペレーティングシステムであり、両方ともPCにインストールできます。 だが同じ目的を果たす以外は ほとんど何も共有していない

このため、ASFとIMをIMの予想に基づいて比較してはいけません。 ASFとIMは、独自の特別な機能を備えた完全に独立したプログラムとして扱うべきです。 それらのいくつかは確かに重複し、あなたはそれらの両方に特定の機能を見つけることができます しかし、ASFがIMとは全く異なるアプローチで目的を果たしていることはまれです。

---

### 現在Idle Masterを使っていて、うまく動作しているのであれば、ASFを使う価値はありますか?

**はい**. ASFはより信頼性が高く、農作方法に関係なく **重要な** の多くの組み込み関数が含まれています。 IMは提供していないということです

ASFは **未発表のゲーム** に適切なロジックを持っています。IMはすでにカードを追加したゲームをファームしようとします。 たとえ釈放されなくても もちろん、それらのゲームはリリース日までファームできませんので、農業プロセスは行き詰まります。 これにより、ブラックリストに追加するか、リリースを待つか、手動でスキップする必要があります。 それらのどちらのソリューションも良いことではなく、それらのすべてがあなたの注意を必要とします - ASFは自動的に未発表のゲームの農業をスキップします (一時的に) 後で戻ってきます問題を完全に回避し 効率よく対処するのです

ASFには、 **シリーズ** ビデオの適切なロジックもあります。 There are many videos on Steam that have cards, yet are announced with wrong `appID` on the badges page, such as **[Double Fine Adventure](https://store.steampowered.com/app/402590)** - IM will falsely farm wrong `appID`, which will yield no drops and process being stuck. もう一度、あなたはそれをブラックリストに載せるか、手動でスキップする必要があります。 ASFは、カードドロップを引き起こす農業のための適切な `appID` を自動的に発見します。

In addition to that, ASF is **much more stable and reliable** when it comes to network problems and Steam quirks - it works most of the time and doesn't require your attention at all once configured, while IM often breaks for many people, requires extra fixes or simply doesn't work regardless. また、Steamクライアントに完全に依存しているため、Steamクライアントに深刻な問題が発生しても動作しません。 ASFはSteamネットワークに接続できる限り正常に動作しており、Steamクライアントの実行やインストールさえ必要ありません。

これらは、ASFの使用を検討すべき3つの **非常に重要な** ポイントです。 彼らは直接皆に影響を与えます スチームカード そして「これは私を考慮していません」と言う方法はありません スチームメンテナンスと癖が皆に起こっているので。 あなたがFAQの残りの部分で学ぶかもしれない余分なより少なく、より重要な理由のダースがある。 そのため、まもなく、 **はい**, IMと比較して利用可能な追加のASF機能が必要ない場合でも、ASFを使用する必要があります。

それに加えて、IMは正式に廃止され、将来完全に破損する可能性があります。 より強力な解決策(ASFだけでなく)が存在することを考えると、誰もそれを解決することができません。 IMはすでに多くの人には機能しませんその数は上がっています 下がっていません IMだけでなく、他のすべての非推奨プログラムも同様に、そもそも時代遅れのソフトウェアを使用することは避けるべきです。 No active maintainer means that nobody cares whether it works or not and **nobody is responsible for its functionality**, which is a crucial matter in terms of security. Steamインフラストラクチャに実際の問題を引き起こす重大なバグが発生するだけで十分です - 誰もそれを修正していません。 Steamは、これが問題であることに気づかずにヒットする別のBAN波を発行することができます。 ASFの時代遅れのバージョンを使っている人もいるでしょう

---

### ASFはIdle Masterがしない興味深い機能を提供していますか?

それはあなたのために"興味深い" 考慮するものによって異なります。 複数のアカウントをファームする予定がある場合、ASFは1つの優れたソリューションですべてのアカウントをファームすることができますので、答えはすでに明白です。 資源の節約、面倒、互換性の問題。 しかし、あなたがその質問をしているならば、おそらくあなたはこの特定の必要性を持っていないでしょう。 ASFで使用されている1つのアカウントに適用される他の利点を評価しましょう。

何よりも **[](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** の上にいくつかの組み込み機能があり、最終目標に関係なく農業の中核となります。 それだけですでにASFの使用を検討するのに十分な場合があります しかし、あなたはすでにそれを知っているので、いくつかのもっと興味深い機能に移りましょう。

- **オフライン** (`OnlineStatus` を `Offline` の設定でファームできます)。 オフラインで農業を行うと、ゲーム内のSteamステータスを完全にスキップすることができます。 同時にスチームに「オンライン」を表示しながらASFでファームすることができます。 ASFがあなたに代わってゲームをプレイしていることに友達がいなくても気づくことはありません。 これは優れた機能です, それはあなたがあなたのSteamクライアントにオンラインのままにすることができますので、, 一定のゲームの変更であなたの友人を迷惑ではない間、. 現実ではない間にゲームをしていると誤解させることもあります この点だけで、自分の友人を尊重するならばASFを使う価値がありますが、それは始まりに過ぎません。 また、この機能はSteamプライバシー設定とは何の関係もないことに注意してください - あなたが自分でゲームを起動した場合。 その後、友達にゲーム内のように表示され、ASF部分だけが見えなくなり、アカウントに全く影響を与えないようにします。

- **払い戻し可能なゲーム** (`SkipRefundableGames` はボットの `農業環境設定` 機能でスキップできます)。 ASFには返金可能なゲームに対する適切なロジックが組み込まれており、ASFには返金可能なゲームを自動的に提供しないように設定できます。 これにより、Steamストアから新しく購入したゲームがあなたのお金の価値があったかどうかを評価することができます。 できるだけ早くカードをドロップしようとすることなく。 購入後2時間以上プレイする場合、または2週間のパスが発生します。 それからASFは払い戻しできないので、そのゲームを続行します。 それまでは、あなたがそれを楽しむかどうかを完全にコントロールしており、必要に応じて簡単に払い戻すことができます。 そのゲームを手動でブラックリストに登録したり、期間全体にASFを使用しないことがありません。

- **未プレイのゲーム** (`SkipUnplayedGames` は、ボットの `農業環境設定` 機能でスキップできます)。 ASFにはゲーム内の時間に適切なロジックが組み込まれており、未プレイのゲームを自動的にファームしないようにASFを設定できます。 これにより、すべてのゲームを手動でブラックリストに登録したり、ASFを使用してスキップしたりすることなく、プレイするゲームやファームを自分でコントロールすることができます。

- **You can automatically mark new items as received** (`BotBehaviour` of `DismissInventoryNotifications` feature). ASFで農業を行うと、アカウントに新しいカードが届きます。 あなたはすでにこれが起こることを知っているので、ASFがあなたに役に立たない通知をクリアさせてください。 重要なことだけが注目されるようにするのです もちろん、あなたがしたい場合にのみ。

- **より多くの利用可能なオプション** (`FarmingOrders` 機能)で好みの農業オーダーをカスタマイズできます。 おそらく、あなたは最初にあなたの新しく買ったゲームを養殖したいですか? それとも最も古いのか？ カードドロップの数によると? バッジレベルは既に作成されていますか？ プレイした時間は？ アルファベット順? AppIDによると？ それとも完全にランダム？ それはあなた次第です。

- **ASFはセット** (`TradingPreferences` と `SteamTradeMatcher` 機能を完了するのに役立ちます) もう少し高度なティンカリングで ASFをフル機能のユーザーボットに変換して、 **[STM](https://www.steamtradematcher.com)** オファーを自動的に受け入れます。 ユーザーの操作なしで毎日セットに合わせるのに役立ちます ASFには独自のASF2FAモジュールも含まれており、Steamモバイル認証システムをインポートすることができ、承認を受け付けることでプロセス全体を完全に自動化することができます。 あるいは、手動で受け入れてASFにこれらの取引のみを準備させたいと思うかもしれません。 それは再び、完全に決めるためにあなた次第です。

- **ASF can redeem keys in background for you** (**[background games redeemer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** feature). 多分あなた自身を引き換えるのに遅すぎる様々なバンドルからの百のキーを持っているかもしれません 何度も何度も蒸気の条件に同意しました ASFにキーのリストをコピーして貼り付けて、その作業をさせてみませんか? ASFはバックグラウンドのすべてのキーを自動的に引き換え、各リデムの試行がどのようになったかをお知らせするための適切な出力を提供します。 さらに、何百ものキーを持っている場合は、遅かれ早かれSteamによって料金制限を受けることが保証されています。 ASFはそれについても知っていますが、レート制限がなくなるのを辛抱強く待って、残った場所を再開します。

**[ASFウィキ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**の全てを続けることができました。 プログラムの全ての特徴を指摘していますが どこかに線を引かなければなりません これがASFユーザーとして楽しめる機能の一覧です 振り返らない大きな理由と考えることができます そして実際に **をたくさん** リストに載せました。さらに多くのことを私たちのwikiで知ることができます。 そうですね。ASFのAPIなどでは、独自のコマンドをスクリプト化することさえできませんでした。 簡単にしておきたかったからです

---

### ASFはアイドルマスターよりも速いですか？

**Yes**, although the explanation is rather complicated.

新しいプロセスがあなたのシステムに生成され、終了します。 steamクライアントは自動的にあなたが現在プレイしているすべてのゲームを含む要求を送信します - このようにsteamネットワークは時間を計算し、カードのドロップを行うことができます。 ただし、steamネットワークは1秒間隔で再生された時間をカウントし、新しい要求を送信すると現在の状態がリセットされます。 言い換えれば、新しいプロセスを0.5秒ごとにスポーン/キルした場合、0ごとにカードをドロップすることはありません。 2番目のスチーム・クライアントは新しい要求を送信し steamネットワークは 再生時間の1秒もカウントされません さらに、オペレーティングシステムの仕組みにより、実際には何もせずに新しいプロセスが生成/終了されるのを見ることが非常に一般的です。 だから、あなたのPC上で何もしていない場合でも - バックグラウンドでまだ多くのプロセスが動作しています、他のプロセスを常に生成/終了します。 アイドルマスターはスチームクライアントに基づいているため、このメカニズムは使用している場合に影響します。

ASFはスチームクライアントに基づいていない、それは独自の蒸気クライアントの実装を持っています。 そのおかげで、ASFがやっていることは、プロセスを生成することではありません。 ゲームを始めた蒸気ネットワークへの要求を実際に送っています これはsteamクライアントから送信されるリクエストと同じです。 しかし、ASFの蒸気クライアントを実際にコントロールしているため、新しいプロセスを生成する必要はありません。 steamクライアントを模倣しているわけではありません プロセスが変更されるたびに送信要求があるので 上記のメカニズムは 我々には影響しません そのおかげで、蒸気ウェブ側では1秒間隔を遮ることはなく、農業のスピードを上げることができました。

---

### しかし、違いは本当に顕著ですか?

いいえ。 通常のスチームクライアントとアイドルマスターで起こっている割込みは、カードのドロップに無視できる効果があります。 ASFが優れるのは目立った違いではありません

However, there **is** a difference, and you can clearly notice that, as depending on how busy your OS is, cards **will** drop faster, from a few seconds to even a few minutes, if you're extremely unlucky. ASFとIdle Masterの両方がsteamウェブの仕組みの影響を受けているため、カードを落とすためだけにASFを使用することは考えられませんでした。 ASFは蒸気ウェブとより効果的に相互作用するだけです Idle Masterは、実際にどのスチームクライアントが行っているかを制御できませんが(Idle Masterの障害ではなく、スチームクライアント自体)。

---

### ASFは複数のゲームを同時にファームできますか?

**はい**, しかし、ASFは、選択された **[カード養殖アルゴリズム](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** に基づいて、その機能をいつ使用するかをよりよく知っています。 Card drops rate when farming multiple games is close to zero, this is why ASF is using multiple games farming exclusively for hours in order to overcome `HoursUntilCardDrops` faster, for up to `32` games at once. これもASFの構成部分に焦点を当てるべき理由です。 そしてアルゴリズムに目標を達成するための最善の方法を決めさせてください - あなたが正しいと思うこと 実際には必ずしも正しいとは限りません複数のゲームを同時に農業することは、どんなカードドロップを提供しません。

---

### ASFはゲームを素早くスキップできますか？

****, ASFはサポートしていません, **[スチームグリッチ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance#steam-glitches)** の使用を推奨しません.

---

### ASFはカードが追加されるまでに各ゲームをX時間自動的にプレイできますか?

****, スチームカードシステムの変更の全体のポイントは、偽の統計とゴーストプレーヤーと戦うことでした. ASFは必要以上にそのような機能を追加することは計画されておらず、発生することはありません。 ゲームが通常の方法でカードドロップを受け取った場合、ASFはできるだけ早くファームします。

---

### ASFが農業をしている間にゲームをすることはできますか?

****. ASF, unlike some other tools that integrate with your Steam client, has its independent implementation of that client included, and Steam network allows only **one Steam client at a time** to play a game. しかし、ゲームを開始すると、好きなときにいつでもASFを切断することができます(Steamネットワークが他のクライアントを切断する必要があるかどうかを尋ねられたら「OK」をクリックします) - ASFはプレイが終わるまで辛抱強く待ってくれます。 その後プロセスを再開します。 または、あなたはまだあなたが好きなときにオフラインモードで再生することができます, それはあなたのために満足している場合.

いずれにせよ、複数のゲームをプレイする際のカードドロップ率はゼロに近いことに留意してください。 従って他のツールを使うことで 直接的な利益は得られません 重要なeであるASFで起動された他のゲームに干渉しないことの強い利点があります。 を選択します。

---

## セキュリティ/プライバシー/VAC/BAN/ToS

---

### これを使用するVAC禁止にすることはできますか?

いいえ、ASF（Idle Masterのような他のツールと違って）のため可能ではありません。 SGIまたはSAM)は、蒸気クライアントやそのプロセスに一切干渉しません。 It's physically impossible to get VAC ban for using ASF, even during playing on secured servers while ASF is running - this is because **ASF doesn't even require Steam Client being installed at all** in order to work properly. ASFは、現在VACフリーであることを保証できる数少ない農業プログラムの1つです。

---

### ASFを使用すると、ここで述べられている **[](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)** のように、VACで保護されたサーバーでの再生を防ぐことができますか?

ASFはSteamクライアントが実行されたり、インストールされたりする必要はありません。 According to this concept, it should **not** cause any VAC-related issues, because ASF guarantees lack of interfering with Steam client and all its processes - this is the main point when talking about VAC-free guarantee that ASF offers.

ユーザーと私の知る限りでは、これは今のところそうです。 ASFの使用中に上記のリンクに記載されているような問題は誰も報告していないので。 上記の問題もASFで再現することはできませんでしたが、Idle Masterではっきりと再現することができました。

ただし、バルブはいつかブラックリストにASFを追加できることに留意してください。 でもまるでナンセンスです PCからVACで保護されたゲームをプレイし、同時にASFを使用することもできます。 あなたのサーバーで、ASFが容疑者であるべきではないことを非常によく知っていることを確信しています。 ASFをブラックリストに載せることによって、彼らは私たちの生活を困難にしません。 それでも、最悪の場合には、上記のように遊ぶことができません。 SteamがASFバイナリをブラックリストに登録しているかどうかに関わらず、ASFのVACフリー保証がまだここにあるためです。 (Steamクライアントがインストールされていない他のマシンでも、ASFを起動できます)。 今、それを行う必要はありません, そして、それがこのようなままでいることを願ってみましょう.

---

### 安全ですか？

ASFがソフトウェアとして安全であるかどうかを尋ねると、コンピュータに損害を与えることはありません。 あなたの個人データを盗むことはありません、ウイルスやそのような他のものをインストールします - それは安全です。 ASFにはマルウェアがありません, データの盗難, 暗号通貨マイナーおよびその他の疑わしい行動は、ユーザーによって悪意のある行為または望ましくない行為と見なされます。 それに加えて、専用の **[リモートコミュニケーション](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** セクションがあります。このセクションは、当社のプライバシーポリシーと、あなたがプログラムを設定したものを超えたASFの動作をカバーしています。

私たちのコードはオープンソースです そして分散バイナリは常に **[公開ソース](https://en.wikipedia.org/wiki/Open-source_software)** によって **[自動化され信頼された連続統合システム](https://en.wikipedia.org/wiki/Build_automation)**からコンパイルされます。 開発者自身ではありません それぞれのビルドは、ビルドスクリプトに従うことで再現でき、 **[決定論的な](https://en.wikipedia.org/wiki/Deterministic_system)** IL(バイナリ)コードとまったく同じになります。 何らかの理由でビルドを信頼しない場合は、ソースから ASF をコンパイルして使用できます。 ASFが使用しているすべてのライブラリ(SteamKit2など)も含まれています。

しかし、最終的には、アプリケーションの開発者に対する信頼関係の問題です。 したがって、ASFを安全かどうかを自分で判断する必要があります。上記の技術的な引数であなたの決定をサポートする可能性があります。 私達がそう言ったので盲目的に何かを信じてはいけない- 確かめる唯一の方法としてあなた自身を点検しなさい。

---

### 禁止されることはできますか?

その質問に答えるには、 **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** を詳しく見てください。 Steamは複数のアカウントの使用を禁止していません **[は、](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)** は、複数のアカウントで同じモバイル認証を使用できることを暗示しています。 しかし、アカウントを他の人と共有することはできませんが、ここではアカウントを共有することはできません。

ASFを考慮する唯一の実際の点は以下のとおりです。
> お客様は、サブスクリプションマーケットプレイスのプロセスを変更または自動化するために、チート、自動化ソフトウェア(ボット)、Mod、ハックまたはその他の不正な第三者ソフトウェアを使用することはできません。

問題は、実際にはサブスクリプションマーケットプレイスプロセスであるかです。 読むことができるように:

> サブスクリプションマーケットプレイスの例としてSteamコミュニティマーケットがあります。

サブスクリプションマーケットプレイスプロセスを変更または自動化することはありません。サブスクリプションマーケットプレイスによって、スチーム・コミュニティ・マーケットやスチームストアを理解することができます。 ただし...

> バルブは、いつでも、お客様のアカウントまたは特定のサブスクリプションをキャンセルすることができます。(a) バルブは、これらのサブスクリプションを同様の場所のお客様に提供しなくなります。 または(b)お客様は、本契約のいかなる条項(サブスクリプション利用規約または利用規則を含む)にも違反します。

したがって、すべてのSteamソフトウェアと同様に ASFはバルブによって認可されておらず、バルブが現在ASFを使用してアカウントを禁止していると突然判断した場合、一時停止されないことは保証できません。 ASFが数百万以上のSteamアカウントで使用されていることを考えると、これは非常に考えられません。 10年以上前に起こった最初のリリース以来 - しかし、それでも可能性は、実際の確率に関係なく。

特に理由:
> Valveによって作成されていないすべてのサブスクリプション、コンテンツおよびサービスに関して。 バルブは、Steamまたはその他のソースを通じて利用可能な第三者のコンテンツを表示しません。 バルブは、かかる第三者のコンテンツについて一切の責任を負いません。 一部のサードパーティ製アプリケーションソフトウェアは、ビジネス目的でビジネスで使用することができます - しかしながら。 個人的に使用するためにSteam経由でこのようなソフトウェアを取得することができます。

しかし、バルブは、ここ **[](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**と述べたように、「チームアイドル」が存在することを明確に認めているので、あなたが私に尋ねた場合。 彼らが彼らにうまくいかなかった場合、彼らは彼らが問題をVAC単位で引き起こす可能性があることを指摘する代わりに、すでに何かを行っていると私は確信しています。 ここでのキーワードは、 **Steam** idlers (例えばASF) で、 **ゲーム** ではありません。

上記は **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** の解釈のみであり、さまざまなポイント - ASF は Apache 2 の下でライセンスされていることに注意してください。 明確に述べているライセンス:

```
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
```

自己責任でこのソフトウェアを使用しています。 それを禁じられる可能性は非常に低いのですが、そうすれば自分自身だけを責めることができます。

---

### 誰もがそれを禁止されましたか?

**はい**, 我々はこれまで少なくともいくつかの事件を持っていました, それは何らかの蒸気サスペンションの結果となりました. ASF自体が根本的な原因であったかどうかは、おそらく私たちが知ることができないまったく別の話です。

最初のケースでは、1000以上のボットを持つ男が(すべてのボットと一緒に)取引を禁止されました。 おそらく `戦利品` が一度にすべてのボットで実行されるためです。 他の疑わしい片面取引を短期間で行うことができます

> HelloXXX, Steam サポートへのご連絡ありがとうございます。 このアカウントはボットアカウントのネットワークを管理するために使用されたようです。 BottingはSteam加入者契約に違反します。

ASFがそうすることを可能にしているので、あなたがそんな狂ったことができると仮定しないでください。 1k以上のボットで `戦利品ASF` を行うことは、簡単に **[DDoS](https://en.wikipedia.org/wiki/DDoS)** 攻撃と見なすことができます。 個人的には誰かがそんなことを禁止されたことには驚いていません Steamサービスに関しては、公正な使用を最小限に抑えてください。 **おそらく** は問題ありません。

2番目のケースでは、Steamの2017ウィンターセール中に170以上のボットを持つ男が禁止されていました。

> あなたのアカウントは、加入者スチームの契約違反によりブロックされました。 取引所やその他の要因から判断すると、このアカウントはSteam上で収集可能なカードを不正に収集するために使用されました。 商業活動だけでなく関連しています アカウントは完全にブロックされており、Steam サポートはこの問題について追加のサポートを提供できません。

このケースは、ほとんどの詳細を提供していないスチームのサポートから漠然とした応答のため、再び非常に難しいです。 私の個人的な考えに基づいて、このユーザーはおそらく何らかのお金のためにスチームカードを交換しました (ボットをレベルアップ? または何らかの方法でスチームで出金しようとしました。 **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** によると、これは違法です。 ASFを通じて取得したトレーディングカードで何ができるかをお伝えする立場にはありませんが、問題のユーザーはバッジを作成するだけではありませんでした。

3番目のケースは、 **[Steamオンラインで](https://store.steampowered.com/online_conduct?l=english)** の違反で120以上のボットが禁止されているユーザーに関与しています。

> HelloXXX, Steam サポートへのご連絡ありがとうございます。 このアカウントおよびその他のアカウントは、Steamオンライン行為の違反であるネットワークインフラストラクチャの洪水に使用されました。 アカウントは完全にブロックされており、Steam サポートはこの問題について追加のサポートを提供できません。

このケースは、ユーザーが提供する追加の詳細のため、分析が少し簡単になります。 Apparently the user was using **a very outdated ASF version** that included a bug causing ASF to send excessive number of requests to Steam servers. バグ自体は最初は存在しませんでしたが、今後のバージョンで修正された Steam 破壊の変更により有効化されました。 **ASF is supported only in [latest stable version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) released on GitHub**.

古いASFバージョンの一部が永久に動作すると仮定することはできません。 特に蒸気は好きかどうかに関わらず絶えず変化しているからです 世界中でこのようなことが起きると、すぐにパッチアップされ、バグフィックスとしてすべてのユーザーにリリースされます。 バルブは明白な理由から、当社またはその間違いのために、突然100万人以上のASFユーザーを禁止しません。 しかし、意図的に最新のASFを使用しない場合。 その定義によれば、 **** がサポートされていないため、 **このような**のようなインシデントにさらされているごく少数のユーザーです。 古いバージョンのASFを誰も監視していないので 誰も修理をしないし、誰もあなたがそれを起動するだけで完全に禁止されないことを保証しない。 **ASFだけでなく、他のすべてのアプリケーションも最新のソフトウェア**を使用してください。

最新のケースは2021年6月頃に発生しました。

> あなたのプログラムを使用して、私は3年間28のアカウントと過去6ヶ月間128のアカウントを持つブースターパッケージを作っています。 ブースターパックを作ってメインアカウントに送るために、最大15のアカウントを同時にオンラインにしました。 先月、同時にオンラインアカウントの数を20に増やし、その1週間後にはすべてのアカウントが禁止されました。 この電子メールはあなたを非難することではありません、それどころか、私はいつもその結果に気づいていました。 私はあなたに永久的な禁止になる行動の種類を知ってもらいたかった。

同時アカウントのオンライン増加が禁止の直接の理由であったかどうかを判断するのは難しいです。 私はそれを期待しません, 代わりに、私は単独でアカウントの数が主な犯人だったと思います. オンラインアカウントの並行性が高まったことはおそらく単に問題のユーザーに注目を集めました 彼は私たちの推奨よりもはるかに多くのボットを持っていたからです

---

上記のすべてのインシデントには共通点が1つあります。ASFは単なるツールであり、どのように使用するかは **あなたの** 意思決定です。 You do not get banned for using ASF directly, but for **how** you're using it. たった１つのアカウントでのヘルパーツール農業や 何千ものボットから作られた 大規模な農業ネットワークです いずれにせよ、私は法的なアドバイスを提供していません。そして、あなたは最初にASFの使用について自分で決めるべきです。 役に立つ情報を隠していません。例えば、 ASFが何人かの人々を禁止したという事実(そしてどのような文脈で) 私がする理由がないので- それはあなたがその情報をしたいと思うものである。

If you ask me - use some common sense, avoid owning more bots than our recommendation, do not send hundreds of trades at the same time, always use up-to-date ASF version and you _should_ be fine. **何らかの理由でこの性質のすべての単一の事件** 常に私たちの勧告を無視している人々に起こりました。 ベストプラクティスや提案は我々よりもよく知っていると信じています を選択します。 偶然であろうと実際の要因であろうと、決めるのはあなた次第です。 私たちは法的なアドバイスを提供していません。あなたが役に立つと思うことをあなたに伝えるだけです。 それらを完全に無視して上記にリンクされた事実のみで運営されています

---

### ASFはどのようなプライバシー情報を開示しますか?

**[リモート通信](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** セクションに詳細な説明があります。 プライバシーに関心がある場合、例えばASFで使用されているアカウントが私たちのSteamグループに参加している理由がわからない場合は、それを確認する必要があります。 ASFは機密情報を収集せず、第三者と共有しません。

---

## その他

---

### 32ビットWindowsのようなサポートされていないOSを使用していますが、最新バージョンのASFを使用することはできますか?

はい、そしてそのバージョンはどのような方法でもサポートされていません、ただ正式に構築されていません。 Check out **[compatibility](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** section for generic variant. ASFはOSに強い依存性を持っておらず、作業できる場所であればどこでも作業できます。 `win-x86` OS固有のパッケージがない場合でも、32ビットWindowsを含むETランタイム。

---

### ASFは素晴らしいです! 寄付はできますか。

はい、そして私たちのプロジェクトを楽しんでいることを聞いて非常に嬉しく思います! **[リリース](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** のメインページ **[の下で、さまざまな寄付の可能性があります。また、](https://github.com/JustArchiNET/ArchiSteamFarm)** にもあります。 一般的なお金の寄付に加えてスチームアイテムも受け付けていることに注意してください。 したがって、スキン、キー、またはASFで養殖したカードの一部を寄付することを妨げるものは何もありません。 あなたの寛大さを事前にありがとうございます!

---

### アカウントを保護するためにSteamペアレンタルPINを使用していますが、どこかで入力する必要がありますか?

はい、 `SteamParentalCode` botの設定プロパティに設定する必要があります。 これは主に、ASFがあなたのSteamアカウントの多くの保護された部分にアクセスし、ASFがそれなしで動作することは不可能であるためです。

---

### ASFがデフォルトでゲームをファームするのは望んでいませんが、追加のASF機能を使用したいと思っています。 これは可能ですか?

Yes, if you just want to start ASF with paused cards farming module, you can set `FarmingPausedByDefault` in `FarmingPreferences` bot config property in order to achieve that. This will allow you to `resume` it during runtime.

If you want to completely disable cards farming module and ensure that it'll never run without you explicitly telling it otherwise, then we recommend to set `FarmPriorityQueueOnly` in bot's `FarmingPreferences`, which instead of just pausing it, will disable the farming completely until you add the games to idle priority queue yourself.

カードファーミングモジュールを一時停止/無効にすると、 `GamesPlayedWhileIdle` などの追加の ASF 機能を使用できます。

---

### ASFはトレイに最小化できますか?

ASFはコンソールアプリであり、OSによってウィンドウが作成されるため、最小化するウィンドウはありません。 You can however use any third-party tool capable of doing so, such as **[RBTray](https://github.com/benbuck/rbtray)** for Windows, or **[screen](https://linux.die.net/man/1/screen)** for Linux/macOS. これらは唯一の例であり、同様の機能を持つ他の多くのアプリがあります。

---

### ASFを使用すると、ブースターパックを受け取ることができますか?

**はい**. ASFは公式クライアントと同じ方法でSteamネットワークにログインしています。 したがって、ASFで使用されているアカウントのブースターパックを受け取ることもできます。 さらに、その能力を維持するためには、Steamコミュニティにログインする必要はありません。 必要に応じて、 `OnlineStatus` を `Offline` 設定で安全に使用できます。

---

### ASFと通信する方法はありますか?

はい、いくつかの異なる方法を通して。 詳細については、 **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** セクションを参照してください。

---

### ASFの翻訳を手伝いたいのですが、どうしたらいいですか?

ご興味をお持ちいただきありがとうございます! 詳細は、 **[ローカライズ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** セクションをご覧ください。

---

### ASFに追加されたアカウントは1つだけです。スチームチャットでコマンドを発行できますか？

**はい**, これは、 **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#notes)** セクションで説明されています。 Steamグループチャットでもできますが、 **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** を使う方が簡単です。

---

### ASFは動作しているようですが、私はカードドロップを受け取っていません!

**[パフォーマンス](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** で読むことができるので、農業カードはゲームによって異なります。 It takes a while, usually **several hours per game**, and you shouldn't expect cards to drop in a few minutes since launching a program. ASFがカードの状態を積極的にチェックし、現在のものが完全に農業化された後にゲームを切り替えることができる場合は、すべてうまく動作します。 It's possible that you've enabled an option such as `DismissInventoryNotifications` of `BotBehaviour` which automatically dismisses inventory notifications. 詳細については、 **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** 設定を確認してください。

---

### アカウントのASFプロセスを完全に停止するには?

たとえば、Windowsの [X] をクリックするなどして、ASFプロセスをシャットダウンするだけです。 If instead you want to stop a particular bot of your choice but keep other ones running, then take a look at `Enabled` **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**, or `stop` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. If you instead want to stop automatic farming process, yet keep ASF running for your account, then that's what `FarmingPausedByDefault` option of `FarmingPreferences` in **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** and `pause` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** is for.

---

### ASFでは何台のボットが走れますか？

プログラムとしてのASFにはボットインスタンスの上限がありません。 マシン上にあるメモリと同じくらい走ることができます しかし、あなたはまだSteamネットワークや他のSteamサービスによって制限されています。 現在、単一のIPと単一のASFインスタンスで最大100-200ボットを実行できます。 IP 制限を回避することで、より多くの IP や ASF インスタンスでより多くのボットを実行することができます。 その大量のボットを使用している場合は、自分自身で自分の番号を制御する必要があることを覚えておいてください。 例えば全員が同時にログインして働いているか確認することです ASFはその膨大な数のボットのために調整されていませんでした。 そして、一般的なルールは、 **ボットが多いほど、**問題が多く発生します。 また、上記の制限は、多くの内部要因に依存することに注意してください。 厳密な制限ではなく近似です。上記で指定したよりも多く/少ないボットを実行できる可能性が最も高いでしょう。

ASF team suggests **owning** up to **10 Steam accounts in total**, and therefore also running up to **10 bots in total**. 上記のものは、ここで行われた私たちの提案に対して、あなた自身のリスクでサポートされ、行われていません。 この推奨は、バルブ内部ガイドラインと私たち自身の提案に基づいています。 このルールを遵守するかどうかはあなたの選択であり、ツールとしてのASFはあなた自身の意志に反しません。 たとえSteamアカウントが停止されたとしても したがって、私たちが推奨するものを上回る場合は、ASFに警告が表示されます。 しかしそれでもあなた自身の責任で あなたが望むことを実行することを許可する そして私たちの支援の欠如。

---

### ASFインスタンスをさらに実行することはできますか?

すべてのインスタンスに独自のディレクトリと独自の設定があると仮定して、1台のマシンで数だけASFインスタンスを実行できます。 あるインスタンスで使われているアカウントは別のインスタンスで使われていません しかし、あなたがそれをしたい理由を自分自身に尋ねてください。 ASFは、同時に100以上のアカウントを処理するように最適化されています。 自身のASFインスタンスで100個のボットを起動するとパフォーマンスが低下します より多くのOSリソース(CPUやメモリなど)を取得し、スタンドアロンASFインスタンス間の同期の問題を引き起こす可能性があります。 ASFはリミッターを他のインスタンスと共有することを余儀なくされています。

したがって、私の **強い提案** は、常に1つのIP/インターフェイスにつき1つのASFインスタンスを最大で実行します。 より多くのIP/インターフェイスを持っている場合、より多くのASFインスタンスを実行することができます。 すべてのインスタンスが独自のIP/インターフェイスまたはユニークな `WebProxy` 設定を使用します。 そうしないと、1つのIP/インターフェイスにつき1つ以上のインスタンスを起動しても何も得られないため、より多くのASFインスタンスを起動することは完全に無意味です。 Steamは魔法のように、別のASFインスタンスで起動したからといって、より多くのボットを実行することはできません。 そしてASFは最初からあなたを制限していません。

もちろん、同じネットワークインターフェース上に複数のASFインスタンスに対して有効な使用例があります。 たとえば、ボット間やASFプロセス自体の分離を保証するために、それぞれの友達が独自のASFインスタンスを持つ友達のためにASFサービスをホスティングするなど。 しかし、あなたはこのようにSteamの制限を回避していない、それは全く異なる目的です。

---

### 鍵を交換するときのステータスの意味は何ですか?

ステータスは、与えられた償還の試みがどのようになったかを示します。 可能な多くの異なるステータスがありますが、最も一般的なステータスは次のとおりです:

| ステータス                   | 説明                                                                                                                                                 |
| ----------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| NoDetail                | 成功を示す "OK" ステータス。キーの返済に成功しました。                                                                                                                     |
| タイムアウト                  | Steamネットワークは与えられた時間内に応答しませんでした。鍵が使われているかどうかはわかりません(おそらくそうですが、もう一度試すことができます)。                                                                       |
| BadActivationCode       | 指定されたキーが無効です (Steamネットワークで有効なキーとして認識されません)。                                                                                                        |
| DuplicateActivationCode | 提供されたキーは、すでに他のアカウントによって引き換えられているか、開発者/パブリッシャーによって取り消されています。                                                                                        |
| AlreadyPurchased        | あなたのアカウントはこのキーに接続されている `packageID` をすでに所有しています。 これは、鍵が `DuplicateActivationCode` であるかどうかを示すものではないことに留意してください - それが有効で、この試みでは使用されていないことだけに注意してください。 |
| 制限された国                  | これはリージョンロックされたキーであり、あなたのアカウントは有効な地域にありません。                                                                                                         |
| DoesNotOwnRequiredApp   | DLCパッケージを引き換えようとしているときは、主にベースゲームを使用している他のアプリが見つからないので、そのキーを引き換えることはできません。                                                                          |
| RateLimited             | 引き換え回数が多すぎるため、アカウントが一時的にブロックされました。 1時間後にもう一度お試しください。                                                                                               |

---

### カードファーム/アイドリングサービスと提携していますか?

****. ASFはいかなるサービスとも提携しておらず、そのような請求はすべて偽です。 あなたのSteamアカウントはあなたの所有物であり、あなたが望む方法であなたのアカウントを使用することができます。 しかし、バルブは **[公式ToS](https://store.steampowered.com/subscriber_agreement)** に明記されています。

> お客様は、ログインとパスワードの機密性およびお客様のコンピュータシステムのセキュリティについて責任を負います。 Valveは、お客様によるログイン名とパスワードの使用に起因する、お客様のパスワードとアカウントの使用、またはSteam上のすべての通信およびアクティビティについて責任を負いません。 お客様が意図的または過失によって、この機密保持規定に違反してログインおよび/またはパスワードを開示された人物によって。

ASFはリベラルApache 2.0ライセンスでライセンスされており、他の開発者はASFを自分のプロジェクトやサービスとさらに統合することができます。 しかし、ASFを利用するサードパーティープロジェクトは、 **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** に従って、安全性、レビュー、適切性、または合法性を保証するものではありません。 私たちの意見を知りたい場合は、 **第三者サービスとアカウントの詳細を共有しないことを強くお勧めします。**. そのようなサービスが **典型的な詐欺**であることが判明した場合、問題は放置されます。 あなたのSteamアカウントがなければ、ASFは安全で安全であると主張するサードパーティのサービスに対して責任を負いません。 ASFチームはそれらのいずれもレビューしなかったためです。 言い換えれば、 **は、**以上の提案に対して、あなた自身のリスクでそれらを使用しています。

それに加えて、公式 **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** は明確に次のように述べています：

> お客様は、バルブが特別に許可する場合を除き、お客様のパスワードまたはアカウントを明示、共有、または他のユーザーが使用することを許可することはできません。

それはあなたのアカウントとあなたの選択です。 誰もあなたに警告しなかったと言わないでください。 プログラムとしてのASFは、アカウントの詳細を誰とも共有していないため、上記のすべてのルールを満たしています。 あなたは自分の個人的な用途にプログラムを使っています しかし、他の「カード養殖サービス」は、アカウントの資格情報を必要とするため、上記の規則(実際にはいくつか)に違反します。 Like with **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** evaluation, we're not offering any legal advice, and you should decide yourself if you want to use those services, or not - according to us **it directly violates [Steam ToS](https://store.steampowered.com/subscriber_agreement)** and may result in suspension if Valve finds out. Like pointed out above, **we strongly recommend to NOT use any of such services**.

---

## 課題

---

### 私のゲームの1つは、今10時間以上養殖されていますが、私はまだそれからカードを手に入れることができませんでした!

その理由は、スチームの既知の問題に関連している可能性があります。 同じゲームに2つのライセンスがある場合に発生しますそのうちの1つはカードのドロップが限られています これは通常、Steamの大量プレゼント中に無料でゲームをアクティベートした場合に発生します。 そして、同じゲームのキーを有効にします(制限なし)。 をクリックします。 このような状況が発生した場合、Steamはバッジページにカードをドロップすることを報告します。 しかし、どのくらいゲームをプレイしても、カードはあなたのアカウント上の無料ライセンスのためにドロップすることはありません。 ASFの問題ではなくSteamの問題なので、ASF側では何らかの方法で回避することはできず、自分で解決する必要があります。

問題を解決するには二つの方法があります。 Firstly, you can blacklist this game in ASF, either with `fbadd` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** or with `Blacklist` **[configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. これにより、ASFがこのゲームからカードをファームしようとしないようになります。 しかし、影響を受けたゲームからカードドロップを得ることを妨げる根本的な問題は解決しません。 第二に、Steamサポートセルフサービスツールを使用して、カードドロップを含む完全なライセンスのみを残して、アカウントから無料のライセンスを削除することができます。 そのために まず、 **[ライセンスとプロダクトキーアクティベーション](https://store.steampowered.com/account/licenses)** ページにアクセスし、影響を受けるゲームの無料ライセンスと有料ライセンスの両方を見つけます。 通常、それはかなり簡単です - どちらも同様の名前を持っていますが、無料のものは、ライセンス名に「限定無料プロモーションパッケージ」または他の「プロモーション」を持っています 加えて、"獲得方法"フィールドの"補完"です。 場合によっては、例えば、無料のパッケージがいくつかのバンドルにあり、別の名前を持っている場合、それはより厄介かもしれません。 そのような2つのライセンスを発見した場合 - それは確かにここで説明されている問題です。 ゲームを失うことなく無事にライセンスを取り除くことができます

無料ライセンスをアカウントから削除するために。 **[Steamサポートページ](https://help.steampowered.com/wizard/HelpWithGame)** にアクセスし、影響を受けるゲーム名を検索フィールドに入力してください。 ゲームは「商品」セクションで利用可能になるはずです。クリックしてください。 あるいは、 `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` リンクを使用し、 `<appID>` 問題を引き起こすゲームの appID に置き換えることもできます。 その後、「アカウントからこのゲームを永久に削除したい」をクリックし、上記で見つけた欠陥のある無料ライセンスを選択してください。 通常、名前の「限定された無料プロモーションパッケージ」を持つもの(または類似したもの)。 フリーライセンスを削除した後、ASFは問題なく影響を受けるゲームからカードをドロップすることができます。 今度は蒸気が適切なライセンスを取っていることを確認するために、撤去後、農業事業を再開すべきです。

---

### ASFは農業用のゲーム `X` を検出しませんが、スチームトレーディングカードが含まれていることはわかります!

ここには主に二つの理由があります。 まず最初に最も明白な理由は、あなたが **Steamストア** を参照しているという事実であり、与えられたゲームはカードドロップ対応ゲームとして発表されます。 This is **wrong** assumption, as it simply states that the game **has** card drops included, but not necessarily this function for that game is **enabled** right away. 詳細については、 **[公式アナウンス](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)** をご覧ください。

簡単に言うと、Steamストアのカードドロップアイコンは意味がありません。 **[バッジページ](https://steamcommunity.com/my/badges)** を確認して、ゲームがカードドロップを有効にしているかどうかを確認してください - これもASFが行っていることです。 If your game doesn't appear on the list as a game with cards possible to drop, then this game is **not** possible to farm, regardless of reason.

第二の問題は明白ではありません あなたのゲームがバッジのページにカードがドロップされていることがわかる状況です でも今はASFに養殖されていません ASFがバッジページを確認できない(以下で説明する)など、他のバグにぶつかっていない場合。 これは単なるキャッシュ効果であり、ASF側ではSteamが古いバッジページを報告しています。 この問題は、キャッシュが無効になったときに遅かれ早かれ解決するはずです。 私たちの側でこれを修正する方法もありません。

Of course, all of that assumes that you're running ASF with default untouched settings, since you could also add this game to farming blacklist, use selected `FarmingPreferences` such as `FarmPriorityQueueOnly` or `SkipRefundableGames`, and so on.

---

### ASFを通じて養殖されたゲームのプレイ時間が増えないのはなぜですか?

**はリアルタイムの** ではありません。 Steamは再生時間を一定の間隔で記録し、スケジュールが更新されます。 だが君がセッションを辞めた直後に更新される保証はない その間は言うまでもない 再生時間がリアルタイムで更新されないからといって、録画されていないというわけではなく、通常は30分おきに更新されます。

---

### 警告とログのエラーの違いは何ですか?

ASFは、ログにさまざまなログレベルに関する多くの情報を書き込みます。 Our objective is to explain **precisely** what ASF is doing, including what Steam issues it has to deal with, or other problems to overcome. ほとんどの場合、すべてが適切ではありません。 このため、ASFでは警告レベルとエラーレベルの2つの大きなレベルが使用されています。

General ASF rule is that warnings are **not** errors, therefore they should **not** be reported. 警告とは、不要なことが起こる可能性があることを示すものです。 Steamが反応しない、APIスローエラー、ネットワーク接続がダウンしているかどうかにかかわらず、警告です。 実現すると予想されていたことになりますのでASFの開発を気にしないでください もちろん、それらについて質問したり、当社のサポートを使用して助けを得ることができます。 しかし、それらは報告に値するASFエラーであると仮定するべきではありません(別途確認しない限り)。

一方、エラーは起こるべきでない状況を示しています 従って彼らは報告する価値があります あなたが彼らを引き起こしているのは あなたではないことを確認した限りね それが起こると予想される一般的な状況であれば、代わりに警告に変換されます。 そうでなければ、それはおそらく修正されるべきバグであり、黙って無視されることはありません。それはあなた自身の技術的な問題の結果ではないと仮定します。 For example, putting invalid content in `ASF.json` file will throw an error, as ASF won't be able to parse it, but it was you who put it there, so you should not report that error to us (unless you confirmed that ASF is wrong and your structure is in fact absolutely correct).

1 つの TL; DR 文では、エラーを報告します。警告を報告しないでください。 警告について質問したり、サポートセクションでヘルプを受けることができます。

---

### ASFが起動しません。プログラムウィンドウはすぐに閉じます！

In normal conditions, any ASF crash or exit will generate a `log.txt` in the program's directory for you to view, which can be used for finding the cause of that. In addition to that, a few last log files are also archived in `logs` directory, since the main `log.txt` file is overwritten with each ASF run.

ただし、.NET ランタイムでもマシンで起動できない場合は、 `log.txt` は生成されません。 それが起こった場合、 **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)** ガイドに記載されているように、.NET の前提条件をインストールするのを忘れてしまう可能性があります。 その他の一般的な問題としては、お使いのOSで間違ったASFバリアントを起動しようとしたり、ネイティブの.NETランタイム依存性を欠落させたりするなどがあります。 メッセージを読むためにコンソールウィンドウがあまりにも早く閉じた場合は、独立したコンソールを開き、そこからASFバイナリを起動します。 For example on Windows, open ASF directory, hold `Shift`, right click inside the folder and choose "*open command window here*" (or *powershell*), then type into the console `.\ArchiSteamFarm.exe` and confirm with enter. この方法で、ASFが適切に開始されていない理由を正確にメッセージが表示されます。

出力がなく、Windows にいる場合。 通常の原因は、利用可能なすべてのWindowsアップデートがインストールされていないことです - 最新のOSを使用していることを確認してください Windows上でASFを実行することはどちらの方法でもサポートしていないため。

---

### ASFは私がプレイしている間、私のSteamクライアントセッションをキックしています！ / *This account is logged on another PC*

これはSteamオーバーレイに表示され、再生中にアカウントが別の場所で使用されているメッセージとして表示されます。 この問題には二つの異なる理由があります。

1つの理由は、特に再生ロックを正しく保持しないパッケージ(ゲーム)が壊れていることによるものです。 それでも鍵はクライアントに所有されることを期待してください そのようなパッケージの例として、Skyrim SE があります。 Steamクライアントが正しくゲームを起動しますが、そのゲームは使用されているものとして登録されません。 そのため、ASFはプロセスを自由に再開することができます。 Steamネットワークから抜け出すとアカウントが他の場所で使用されていることをSteamが突然検知しました

ASFが待機中(特に別のマシンで)にネットワーク接続が失われている場合、2つ目の理由が発生する可能性があります。 この場合、Steamネットワークはオフラインとしてマークし、再生ロック(上記のような)を解放します。これにより、ASFが再開される農業が開始されます。 PCがオンラインに戻っても、Steamは再生ロックを取得できなくなります(ASFが保持しています)。 同じメッセージが表示されています

ASF側の両方の原因は、実際には非常に回避しにくいです。 ASFは、Steamネットワークが再び無料で使用することを知らせるだけで農業を再開します。 これは、ゲームを閉じるときに通常起こっていることです。 しかし、壊れたパッケージがあれば、すぐに起こることがありますあなたのゲームがまだ実行されていても。 ASFはあなたが切断されたかどうかを知る方法がありません ゲームをやめたりロックを適切に保持しないゲームを続けていたりします

The only proper solution to this problem is manually pausing your bot with `pause` before you start playing, and resuming it with `resume` once you're done. あるいは、問題を無視し、オフラインのSteamクライアントでプレイした場合と同じように動作するだけです。

---

### `Steamから切断！` - Steamサーバーとの接続が確立できません。

ASF can only **try** to establish connection with Steam servers, and it can fail due to many reasons, including lack of internet connection, Steam being down, your firewall blocking connection, third-party tools, incorrectly configured routes or temporary failures. `デバッグ` モードを有効にして、正確な失敗の理由を記載した詳細なログをチェックすることができます。 通常は単純に自分の行動によって 例えば、「CS:GO MM Server Picker」を使用すると、Steam IPの多くをブラックリストに載せるなど、Steamネットワークに到達するのは非常に難しいです。

ASFは接続を確立するために最善を尽くします 更新されたサーバーのリストについて尋ねるだけでなく、最後に失敗したときに別のIPを試してみることも含まれます。 特定のサーバーやルートに本当に一時的な問題が発生した場合、ASFは遅かれ早かれ接続されます。 ただし、ファイアウォールの背後にいる場合や、Steamサーバーにアクセスできない場合があります。 `` モードの潜在的な助けを借りて、明らかに自分で修正する必要があります。

ASFでデフォルトプロトコルを使用してSteamサーバーとの接続を確立できない場合もあります。 `SteamProtocols` グローバル設定プロパティを変更することで、ASFが使用できるプロトコルを変更できます。 For example, if you have problems reaching Steam with `UDP` protocol (e.g. due to firewalls), perhaps you'll have more luck with `TCP` or `WebSocket`.

In a very unlikely situation of having incorrect servers being cached, for example because of moving ASF `config` folder from one machine to another machine located in entirely different country, deleting `ASF.db` in order to refresh Steam servers on the next launch may help. そのリストは最初の起動時に自動的に更新されるため、頻繁には不要で、行う必要はありません。 接続が確立されたときだけでなく、ASFによってキャッシュされたSteamサーバーのリストに関連するものを削除する方法として言及しています。

---

### `Steamにログインできません: TryAnotherCM/Invalid`, `ServiceUnavailable/Invalid`

上記のように、しかし、今回あなたが接続したサーバーは明示的に利用できません。 通常、スチームのメンテナンス中に発生します。これについてできることは何もありません。 ASFは、リクエストを受け入れるまで、別のサーバーで自動的に再試行します。 それは最大時間より長く持続するべきではない。

---

### `バッジ情報を取得できませんでした。後でもう一度お試しください！`

通常、SteamペアレンタルPINを使用してアカウントにアクセスしていることを意味しますが、ASFの設定に入れるのを忘れています。 有効なPINを `SteamParentalCode` botの設定プロパティに入力してください。 そうでなければ、ASFはほとんどのWebコンテンツにアクセスできないため、正常に動作することはできません。 **[設定](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** に進み、 `SteamParentalCode` の詳細を確認してください。

その他の理由としては、一時的なスチームの問題、ネットワークの問題などがあります。 問題が数時間後に解決されず、ASFを適切に設定したことを確認している場合は、お気軽にお知らせください。

---

### ASF is failing with `Request failed after 5 tries` errors!

通常、SteamペアレンタルPINを使用してアカウントにアクセスしていることを意味しますが、ASFの設定に入れるのを忘れています。 有効なPINを `SteamParentalCode` botの設定プロパティに入力してください。 そうでなければ、ASFはほとんどのWebコンテンツにアクセスできないため、正常に動作することはできません。 **[設定](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** に進み、 `SteamParentalCode` の詳細を確認してください。

ペアレンタルPINが理由でない場合は、これは最も一般的なエラーであり、それに慣れる必要があります。 これは、ASFがSteam Networkにリクエストを送り、有効な応答を5回連続で取得しなかったことを意味します。 通常、スチームがダウンしているか、またはいくつかの問題やメンテナンスがあることを意味します - ASFはそのような問題を認識しており、あなたはそれらを心配する必要はありません。 彼らが常に数時間以上続けている場合を除き、他のユーザーはこのような問題を抱えていません。

Steamがダウンしているかどうかを確認する方法は? **[Steam Status](https://steamstat.us)** is an excellent source of checking if Steam **should be** up, if you notice errors, especially related to Community or Web API, then Steam is having difficulties. ASFを離れて、短時間のダウンタイムの後に仕事をさせるか、または辞めて自分自身を待つことができます。

ただし、いくつかの状況ではSteamの問題がSteam ステータスによって検出されない可能性がありますので、必ずしもそうではありません。 たとえば、バルブが Steam Community のHTTPSサポートを破った場合などが発生しました。2016 年 6 月 7 日 - **[SteamCommunity](https://steamcommunity.com)** にHTTPSを介してアクセスするとエラーが発生しました。 したがって、Steamステータスを盲目的に信頼しないでください。すべてが想定どおりに動作するかどうかを自分で確認するのが最善です。

それに加えて、Steamにはさまざまなレート制限対策が含まれており、一度に過度のリクエストを行った場合、IPを一時的に禁止します。 ASFはそれを認識しており、あなたが利用すべき設定のいくつかの異なるリミッターを提供します。 デフォルトの設定は、 **sane** のボット数に基づいて調整されました。 蒸気でさえ逃げろと言ってる量を使ってるなら 指示がなくなるまで微調整するか言われた通りにするか 私は第二の方法は、あなたに選択肢ではないと思います。 そのトピックを読んで、すべてのWebリクエストに適用される一般的なリミッターである `WebLimiterDelay` に特別な注意を払ってください。

ブロックは、サードパーティの要因によって大きく影響されているため、誰のために動作する「黄金のルール」はありません。 だから自分で実験して自分に合った価値を見つけるんだ 私の言うことを無視して、正しく動作することが保証されている `10000` のようなものを使用することもできます。 しかし、あなたのASFが10秒ですべてに反応する方法とバッジの解析に5分かかる方法を不満にしないでください。 それに加えて 上記の **[ハードリミッター](#how-many-bots-can-i-run-with-asf)** を打つほど大量のボットを持っているため、リミッターが何もできない可能性は全くあります。 はい、問題なくSteamネットワーク（クライアント）にログインできます。 しかし、Steam ウェブサイト(ウェブサイト)では、一度に100のセッションが開かれている場合は、聞くことを拒否します。 ASFはSteamネットワークとSteamウェブの両方が協力的であることを要求します。それはあなたが回復しない問題を引き起こすために1つだけダウンします。

何も役に立たないし、何が壊れているか分からない場合。 `デバッグ` モードをいつでも有効にして、リクエストが失敗する理由をASFログで確認できます。 例：

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Forbidden <- HEAD https://steamcommunity.com/my/edit/settings
```

`禁止された` コードを見ますか？ これは、リクエストの過剰な量のために一時的に禁止されたことを意味します。 なぜならあなたは `WebLimiterDelay` を適切に調整していないからです (他のすべてのリクエストでも同じエラーコードを取得していると仮定します)。 `InternalServerError`、 `ServiceUnavailable` 、Steam のメンテナンス/問題を示すタイムアウトなど、他の理由がリストされている可能性があります。 あなたはいつでも自分でASFに記載されているリンクにアクセスし、それが動作するかどうかを確認することができます - そうでない場合。 ASFがそれにアクセスできない理由も分かるでしょう もしそうであって、同じエラーが1日か2日後に終わらない場合は、調査と報告の価値があるかもしれません。

その前に **エラーが最初の** で報告する価値があることを確認してください。 トレーディング関連の問題など、このFAQに記載されている場合は、それは終わりです。 ネットワークが不安定だったり、Steamがダウンしていた場合は特に、一度か二度起きた一時的な問題です。 ただし、問題を2日間連続で何回か再現することができた場合。 プロセス中にASFとマシンを再起動し、解決に役立つFAQエントリがないことを確認しました。 それなら聞く価値があるかもしれない

---

### ASFはフリーズして、キーを押すまでコンソールに何も出力しないようです!

Windows を使用している可能性が高く、コンソールで QuickEdit モードが有効になっています。 技術的な説明については、StackOverflow で **[この](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** 質問を参照してください。 ASFコンソールウィンドウを右クリックし、プロパティを開き、適切なチェックボックスをオフにしてください。

---

### ASFは取引を受け入れたり送信したりできません！

明らかに最初のもの - 新しいアカウントは限られています。 ウォレットを読み込んでアカウントをロック解除するか、ストアで$ 5を費やすまで、ASFはこのアカウントを使用して取引を受け付けることができません。 この場合、ASFはその中にあるすべてのカードがトレード不可であるため、在庫が空のように見えると述べます。

次に、 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**を使用しない場合。 ASFは実際に貿易を受け入れたり、送られたりする可能性がありますが、電子メールで確認する必要があります。 同様に、クラシック2FAを使用する場合は、認証器を介して取引を確認する必要があります。 確認は **必須の** なので、自分で受け入れたくない場合は、認証器をASF2FAにインポートすることを検討してください。

また、あなたの友人、および既知の貿易リンクを持つ人々とのみ取引することができることに気づく。 If you're trying to initiate *Bot -> Master* trade, such as `loot`, then you need to either have your bot on your friendlist, or your `SteamTradeToken` declared in Bot's config. トークンが有効であることを確認してください - そうでなければ、注文を送信することはできません。

最後に、新しいデバイスは7日間のトレードロックを持っていることを覚えておいてください。 少なくとも7日間待ってください - すべてがその期間の後に動作するはずです。 That limitation includes **both** accepting **and** sending trades. それは必ずしも引き金となるわけではなく、即座に取引を送受理できる人もいます。 Majority of the people are affected though, and the lock **will** happen, even if you can send and accept trades through your steam client on the same machine. 辛抱強く待ってください。速くするためにできることは何もありません。 同様に、2FA、SteamGuard、パスワード、電子メールなど、さまざまなSteamセキュリティ関連の設定を削除/変更するための同様のロックを取得することができます。 一般的に、その口座から自分で取引を送ることができるかどうかを確認してください、はいの場合、おそらくそれは新しいデバイスからの古典的な7日間のロックです。

そして最後に、1つの口座が別の口座に5保留中の取引しか持つことができないことに注意してください。 したがって、ASFは、その1つのボットからすでに受け入れられる5つ以上の保留中のものがある場合、取引を送信できません。 これはめったに問題ではありませんが、特にASFを自動送信に設定している場合は特に言及する価値があります。 しかし、あなたはASFの2FAを使用しておらず、実際にそれらを確認するのを忘れています。

何の役にも立たない場合は、 `デバッグ` モードを常に有効にして、リクエストが失敗する理由を自分で確認できます。 Steamはほとんどの場合ナンセンスを話し、提供された理由は論理的には意味がないことに注意してください。 または完全に間違っている場合もあります - あなたがその理由を解釈することにした場合は、Steamとその癖についてまともな知識を持っていることを確認してください。 また、論理的な理由もなく、その問題を見ることは非常に一般的です。 そして、この場合の唯一の解決策は、ASFにアカウントを再追加することです(そして、再び7日間待つ)。 時々、この問題はまたそれ自身を修正する *魔法のように*、それが壊れるのと同じ方法。 しかし、通常は7日間のトレードロック、一時的なスチーム問題、またはその両方です。 何が間違っているかを手動で確認する前に数日間それを与えることをお勧めします 本当の原因を解明しようとする衝動がない限りは エラーメッセージは意味をなさないため、どちらも少しでも役に立ちません)。

In any case, ASF can only **try** to send a proper request to Steam in order to accept/send trade. Steamがその要求を受け入れるかどうかに関わらず、ASFの範囲外であり、ASFは魔法のように動作しません。 その機能に関連するバグはなく、改善するものもありません。なぜなら、ロジックはASF以外で行われているからです。 Therefore, do not ask for fixing stuff that is not broken, and also do not ask why ASF can't accept or send trades - **I don't know, and ASF doesn't know either**. あなたがよく知っていれば、それに対処するか、自分で修理してください。

---

### ログインごとに2FA/SteamGuardコードを入力する必要があるのはなぜですか? / *Removed expired login key*

ASF uses login keys (if you kept `UseLoginKeys` enabled) for keeping credentials valid, the same mechanism that Steam uses - 2FA/SteamGuard token is required only once. ただし、Steamネットワークの問題や癖のため、ログインキーがネットワークに保存されていない可能性があります。 我々は既にASFだけでなくこのような問題を見てきました しかし、通常のsteamクライアントでも(「覚えておく」オプションに関係なく、各実行時にログイン+パスワードを入力する必要があります)。

You could remove `BotName.db` and `BotName.bin` (if available) of affected account and try to link ASF to your account once again, but that likely won't do anything. 一部のユーザーは、Steam側の **[全てのデバイス](https://store.steampowered.com/twofactor/manage)** の承認を解除すると、パスワードの変更も同様に行われることを報告しています。 しかし、それらは動作することさえ保証されていない回避策だけです。 実際のASFベースのソリューションは、認証器を **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** としてインポートすることです。これにより、ASFは必要に応じてトークンを自動的に生成できます。 手動で入力する必要はありません 通常、この問題はしばらくすると魔法のように解決されるので、単にそれが起こるのを待つことができます。 もちろん、私はSteamネットワークにログインキーを受け入れるよう強制することはできませんので、バルブにソリューションを求めることもできます。

サイドノートとして。 また、 `UseLoginKeys` config プロパティで `false`のログインキーをオフにすることもできます。 しかし、これは問題を解決することはできません。最初のログインキーの失敗をスキップするだけです。 ASF is already aware of the issue explained here and will try its best to not use login keys if it can guarantee itself all login credentials, so there is no need to tweak `UseLoginKeys` manually if you can provide all login details together with using ASF 2FA.

---

### エラーが発生しました: *Steamにログインできません: `InvalidPassword` または `RateLimiteded`*

このエラーは多くのことを意味しますが、その中には以下のものがあります:

- 無効なログイン/パスワードの組み合わせ（明らかに）
- ASFがログインに使用する期限切れのログインキー
- 短期間でログイン試行に失敗しました(アンチブルートフォース)
- 短期間のログイン試行回数が多すぎます（レート制限）
- ログインに必要なCAPTCHA（上記2つの理由により発生する可能性が高い）
- Steam Networkがログインを妨げているその他の理由があります

アンチ・ブルートフォースとレート制限の場合、問題はしばらくすると消えるので、しばらく待ってログインしようとしないでください。 この問題が頻繁に発生した場合は、ASFの `LoginLimiterDelay` 設定プロパティを増やすことが賢明でしょう。 過度のプログラムの再起動やその他の意図的/意図的でないログイン要求は間違いなくその問題に役立たないので、可能であればそれを避けてみてください。

期限切れのログインキーの場合 - ASFは古いキーを削除し、次回ログイン時に新しいキーを要求します(アカウントが2FA保護されている場合は2FAトークンを入れる必要があります)。 アカウントでASF 2FAを使用している場合は、トークンが自動的に生成され、使用されます)。 これは時間の経過とともに自然に発生することがありますが、ログインごとにこの問題が発生した場合に発生します。 Steamが何らかの理由でログインキーのセーブリクエストを無視した可能性があります。 上記の **[の問題](#why-do-i-have-to-put-2fasteamguard-code-on-each-login--removed-expired-login-key)** で述べたように。 もちろん、 `UseLoginKeys` を完全に無効にできます。 しかし、それは問題を解決しません、毎回期限切れのログインキーを削除する必要を避けるだけです。 上記の問題に従って実際の解決策は、ASF 2FAを使用することです。

そして最後に、間違ったログインとパスワードの組み合わせを使用した場合、明らかにこれを修正する必要があります。 または、認証情報を使用して接続しようとしているボットを無効にします。 ASFは、 `InvalidPassword` が無効な資格情報を意味するかどうかをそれ自身で推測できません。 上記のいずれかの理由で成功するまで続けます

ASFには独自のシステムが組み込まれており、蒸気の速度に応じて反応することに注意してください。 結局は繋がって仕事を再開するから 問題が一時的だったら 何もしなくていい 魔法のように問題を解決するためにASFを再起動すると、事態が悪化するだけです(新しいASFは以前のASF状態がログインできないことがわからないので)。 待つ代わりに接続しようとするので、自分が何をしているのか分からない限りは避けてください。

Finally, as with every Steam request - ASF can only **try** to log in, using your provided credentials. その要求が成功するかどうかはASFの範囲とロジックから外れています - バグはありません。 この点で改善されることはありません

---

### ASFが要求しているログイン情報を入力できません
### `System.InvalidOperationException: いずれかのアプリケーションがコンソールを持っていないか、コンソール入力がリダイレクトされたときにキーを読み取ることができません`
### `System.IO.IOException: 入出力エラー`
### `RequestInput()入力が無効です！`

このエラーがASF入力中に発生した場合 (例: スタックトレースで `GetUserInput()` を見ることができます。それは、ASFがコンソールの標準入力を読み取ることを禁止している環境によって引き起こされます。 That can occur due to a lot of reasons, but the most common one is you running ASF in the wrong environment (e.g. in `systemd`, `nohup` or `&` background instead of e.g. `screen` on Linux). ASFが標準入力にアクセスできない場合、このエラーが記録され、実行中にASFの詳細を使用できないことがわかります。

通常、上記の問題を修正する必要があります。すなわち、ASFが標準入力にアクセスできるようにしてください。 However, if you **expect** this to happen, so you **intend** to run ASF in input-less environment, then you should explicitly tell ASF that it's the case, by setting **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** mode appropriately. これにより、ASFはいかなる状況下でもユーザーの入力を求めることはなく、入力レス環境で安全にASFを実行することができます。 ASF-uiのように、このモードでは他の方法で選択した入力プロンプトに答えることができます。

---

### `System.Net.Http.WinHttpException: セキュリティエラーが発生しました`

このエラーは、ほぼSSL証明書の不信が原因で、ASFが指定されたサーバーとのセキュアな接続を確立できない場合に発生します。

In almost all cases this error is caused by **wrong date/time on your machine**. すべての SSL 証明書は、日付と有効期限を発行しています。 あなたの日付が無効で、その2つの境界から外れた場合、証明書は潜在的な **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)** 攻撃を受け、ASF は接続を拒否します。

明らかに、マシンの日付を適切に設定することです。 Windowsで利用可能なネイティブ同期、Linuxでは `ntpd` などの自動同期を使用することを強くお勧めします。

マシン上の日付が適切で、エラーが消えたくないことを確認した場合 システムが信頼している SSL 証明書は、古いものか無効なものかもしれません。 In this case you should ensure that your machine can establish secure connections, for example by checking if you can access `https://github.com` with any browser of your choice, or CLI tool such as `curl`. これが正しく動作することを確認された場合は、お気軽にお問い合わせください。

---

### `System.Threading.Tasks.TaskCanceledException: タスクがキャンセルされました`

この警告は、Steamが与えられた時間内にASFリクエストに応答しなかったことを意味します。 通常、Steamネットワーキングのしゃっくりによって引き起こされ、ASFにはいかなる影響もありません。 他のケースでは、5回試した後にリクエストが失敗するのと同じです。 この問題を報告することは、Steamにリクエストに応答させることができないため、ほとんどの場合意味がありません。

---

### `'System.Security.Cryptography.CngKeyLite' の型イニシャライザが例外を投げました`

この問題は、ほぼ独占的に無効/停止された `CNGキー分離` Windowsサービスによって引き起こされます。 これはASFのコア暗号機能を提供しますが、プログラムは実行できません。 You can fix this issue by launching `services.msc` and ensuring that `CNG Key Isolation` Windows service doesn't have disabled startup and is currently running.

---

### ASFがAntiVirusによってマルウェアとして検出されました! 何が起きているのか？

**信頼できるソース** からASFをダウンロードしたことを確認してください。 The only official and trusted source is **[ASF releases](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** page on GitHub (and this is also the source for ASF auto-updates) - **any other source is untrusted by definition and can contain malware added by other people** - you should not trust any other download location, ensure that your ASF always comes from us.

ASFが信頼できるソースからダウンロードされていることを確認した場合、単に誤検出である可能性が非常に高いです。 この **は過去**、 **は現在**、そして **は未来**に起こります。 ASFを使用する際に実際の安全性が心配な場合は、実際の検出比率のために多くの異なるAVでASFをスキャンすることをお勧めします。 例えば、 **[VirusTotal](https://www.virustotal.com)** (または、このようにあなたの選択した他のWebサービス) を介して。

If the AV that you're using falsely detects ASF as a malware, then **it's a good idea to send this file sample back to developers of your AV, so they can analyze it and improve their detection engine**, as clearly it's not working as good as you think it does. ASFコードに問題はありません。そもそもマルウェアを配布していないため、修正するものは何もありません。 したがって偽陽性を我々に報告するのは意味がありません 上記のような詳細な分析のためにASFサンプルを送信することを強くお勧めしますが、気にしたくない場合は、このサンプルを送信することをお勧めします。 その後、いつでも何らかのAV例外にASFを追加したり、AVを無効にしたり、別のAVを使用したりすることができます。 Sadly, we're used to AVs being stupid, as every once in a while some AV detects ASF as a virus, which usually lasts very short and is being patched up quickly by the devs, but like we pointed out above - **it happened**, **happens** and **will happen** all the time. ASFには悪意のあるコードは含まれていません。ASFコードを確認し、ソースから自分でコンパイルすることもできます。 AVヒューリスティックと誤検出から隠すためにASFコードを難読化するハッカーではありません。 だから、私たちが壊れていないものを修正することを期待しないでください - 私たちが修正するための「ウイルス」はありません。