# ロギング

ASFでは、ランタイム中に使用する独自のカスタムロギングモジュールを設定できます。 アプリケーションのディレクトリに `NLog.config` という名前の特別なファイルを入れることで行うことができます。 NLog on **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**のドキュメント全体を読むことができます。 しかしそれに加えて有用な例もあります

---

## 既定のログ

デフォルトでは、ASFは `ColoredConsole` (標準出力) と `File` にロギングされています。 `` ロギングには `log.txt` ファイルがプログラムのディレクトリに含まれ、アーカイブの目的で `logs` ディレクトリが含まれます。

Using custom NLog config automatically disables default ASF config, your config overrides **completely** default ASF logging, which means that if you want to keep e.g. our `ColoredConsole` target, then you must define it **yourself**. これにより、 **追加の** ロギングターゲットを追加するだけでなく、 **デフォルトの** ものを無効にしたり変更したりすることができます。

If you want to use default ASF logging without any modifications, you don't need to do anything - you also don't need to define it in custom `NLog.config`. ただし、参照として、ハードコーディングされたASFデフォルトロギングと同等のものは以下のようになります。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir:cached=true}/logs/log.txt" archiveOldFileOnStartup="true" archiveSuffixFormat=".{1:yyyyMMdd-HHmmss}" fileName="${currentdir:cached=true}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- Below becomes active when ASF's IPC interface is started -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="File" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- Below becomes active when ASF's IPC interface is enabled -->
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="History" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## ASF統合

ASFにはNLogとの統合を強化する素晴らしいコードトリックが含まれており、特定のメッセージをより簡単にキャッチできます。

NLog-specific `${logger}` variable will always distinguish the source of the message - it will be either `BotName` of one of your bots, or `ASF` if message comes from ASF process directly. この方法で、特定のボットを考慮したメッセージを簡単にキャッチできます。 または、ロガーの名前に基づいて、すべてのロガーの代わりに、ASFプロセス(のみ)を実行します。

ASFは、NLogが提供するロギングレベルに基づいて適切にメッセージをマークしようとします。 特定のログレベルからのメッセージのみをキャッチすることが可能になります もちろん、特定のメッセージのロギングレベルをカスタマイズすることはできません。ASFハードコードされたメッセージの深刻度を決めるためです。 しかし、あなたが適合しているように、確実にASFを少なく/より静かにすることができます。

ASFは、 `トレース` ロギングレベルのユーザー/チャットメッセージなどの追加情報を記録します。 デフォルトのASFロギングログのみ `` レベル以上をデバッグし、追加情報を非表示にします。 大多数のユーザーには必要ないため、さらに重要なメッセージを含むクラッタ出力も必要としません。 しかし、 `Trace` のロギングレベルを再度有効にすることで、その情報を利用することができます。 特に特定のボットをログに記録するのと組み合わせると あなたが興味を持っている特定のイベントに

一般的に、ASFはできるだけ簡単で便利なものにしようとしています。 `grep` などのサードパーティツールを使用して手動でフィルタリングするのではなく、必要なメッセージのみをログに記録することができます。 以下に書かれているように NLog を適切に設定してください 非常に複雑なロギングルールをデータベース全体などのカスタムターゲットで指定できるはずです

バージョン管理について - ASFは、ASFリリース時に **[NuGet](https://www.nuget.org/packages/NLog)** で利用可能な最新バージョンのNLogを常に出荷しようとしています。 ASFのNLogのwikiで見つけることができる機能を使用するのは問題ではありません - 最新のASFも使用していることを確認してください。

ASF統合の一環として、ASFには追加のASF NLogロギングターゲットのサポートも含まれています。

---

## 例

以下の例では、好みに合わせてログをカスタマイズする方法を示します。

スターターとして、 **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)** ターゲットのみを使用します。 最初の `NLog.config` は次のようになります。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

The explanation of above config is rather simple - we define one **logging target**, which is `ColoredConsole`, then we redirect **all loggers** (`*`) of level `Debug` and higher to `ColoredConsole` target we defined earlier.

If you start ASF with above `NLog.config` now, only `ColoredConsole` target will be active, and ASF won't write to `File`, regardless of hardcoded ASF NLog configuration.

Since we didn't define a lot of properties, such as `layout`, it was initialized to a default built-in value, in this case `${longdate}|${level:uppercase=true}|${logger}|${message}`. 以下のようにカスタマイズできます: メッセージのみをログに記録する:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

今ASFを起動すると、その日付がわかります。 レベルとロガー名が消えました - `Function() Message` の形式でASFメッセージのみを残します。

複数のターゲットにログを記録する設定を変更することもできます。 `ColoredConsole` と **[`ファイル`](https://github.com/nlog/nlog/wiki/File-target)** を同時にログに記録しましょう。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Debug" writeTo="File" />
  </rules>
</nlog>
```

これで、 `ColoredConsole` および `ファイル` にすべてのデータを記録します。 カスタム `fileName` と追加オプションを指定することもできます。

最後に、ASFはさまざまなログレベルを使用して、何が起こっているかを理解しやすくします。 この情報を使用して重大度ログを修正できます。 Let's say that we want to log everything (`Trace`) to `File`, but only `Warning` and above **[log level](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** to the `ColoredConsole`. We can achieve that by modifying our `rules`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Warn" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Trace" writeTo="File" />
  </rules>
</nlog>
```

これで、 `ColoredConsole` は警告のみを表示し、すべてを `ファイル` に記録します。 これをさらに微調整してログを記録することができます。例えば、 `情報` 以下などです。

最後に、もう少し高度なことを行い、すべてのメッセージをファイルにログしましょう。ただし、 `LogBot` という名前のボットからだけです。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="LogBotFile" fileName="${currentdir:cached=true}/LogBot.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="LogBot" minlevel="Trace" writeTo="LogBotFile" />
  </rules>
</nlog>
```

上記のASF統合をどのように使用したか、 `${logger}` プロパティに基づいてメッセージのソースを簡単に区別できます。

---

## 高度な使い方

上記の例は簡単で、ASFで使用できる独自のロギングルールを定義するのがいかに簡単かを示しています。 You can use NLog for various different things, including complex targets (such as keeping logs in `Database`), logs rotation (such as removing old `File` logs), using custom `Layout`s, declaring your own `<when>` logging filters and much more. **[NLog ドキュメント](https://github.com/nlog/nlog/wiki/Configuration-file)** 全体を読んで、利用可能なすべてのオプションについて学ぶことをお勧めします。 あなたが望むようにASFロギングモジュールを微調整することができます。 これは非常に強力なツールであり、ASFロギングのカスタマイズは決して容易ではありませんでした。

---

## 制限事項

ASF will temporarily disable **all** rules that include `ColoredConsole` or `Console` targets when expecting user input. したがって、ASFがユーザー入力を期待している場合でも、他のターゲットのロギングを続けたい場合は、それらのターゲットを独自のルールで定義する必要があります。 上記の例に示すように 同じルールの `writeTo` に多くのターゲットを置く代わりに (これがあなたの指名行動でない限り) 。 ユーザー入力を待っているときにコンソールをきれいに保つため、一時的にコンソールターゲットを無効にします。

---

## チャットログ

ASFには、 `トレース` ロギングレベルですべての受信/送信メッセージを記録するだけでなく、チャットロギングの拡張サポートが含まれています。 しかし、` ` イベントプロパティ **[で、関連する追加情報を公開します。](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**。 これは、チャットメッセージをコマンドとして扱う必要があるためです。 したがって、追加のロジックを追加できるようにするために、これらのイベントを記録するのに費用はかかりません(ASFを個人的なSteamチャットアーカイブにするなど)。

### イベントのプロパティ

| 名前         | 説明                                                                                                      |
| ---------- | ------------------------------------------------------------------------------------------------------- |
| Echo       | `bool` 型. メッセージが受信者に送信されている場合は、これは `true` に設定され、それ以外の場合は `false` に設定されます。                               |
| メッセージ      | `文字列` 型。 これは実際の送信/受信メッセージです。                                                                            |
| チャットグループID | `ulong` type. これは、送信/受信メッセージのグループ チャットの ID です。 このメッセージの送信にグループ チャットが使用されていない場合、 `0 0` になります。            |
| チャットID     | `ulong` type. これは、送信/受信メッセージの `ChatGroupID` チャンネルの ID です。 このメッセージの送信にグループ チャットが使用されていない場合、 `0 0` になります。 |
| SteamID    | `ulong` type. これは、送信/受信メッセージの Steam ユーザーのIDです。 特定のユーザーがメッセージ送信に関与していない場合、 `0 0` にすることができます (e. を選択します。  |

### 例

この例は、上記の `ColoredConsole` の基本的な例に基づいています。 理解しようとする前に 最初にNLogのログ記録の基本について学ぶには、 **[](#examples)** の上を見てみることを強くお勧めします。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="ChatLogFile" fileName="${currentdir:cached=true}/logs/chat/${event-properties:item=ChatGroupID}-${event-properties:item=ChatID}${when:when='${event-properties:item=ChatGroupID}' == 0:inner=-${event-properties:item=SteamID}}.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss} ${event-properties:item=Message} ${when:when='${event-properties:item=Echo}' == true:inner=-&gt;:else=&lt;-} ${event-properties:item=SteamID}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="MainAccount" level="Trace" writeTo="ChatLogFile">
      <filters defaultAction="Log">
        <when condition="not starts-with('${message}','OnIncoming') and not starts-with('${message}','SendMessage')" action="Ignore" />
      </filters>
    </logger>
  </rules>
</nlog>
```

基本的な `ColoredConsole` の例から始め、さらに拡張しました。 何よりも 各グループチャンネルとSteamユーザーごとに恒久的なチャットログファイルを用意しました。ASFが私たちに見せてくれる追加プロパティのおかげで可能になります。 また、現在の日付、メッセージ、sent/received info、Steamユーザー自身を書き込むカスタムレイアウトにも対応することにしました。 Lastly, we've enabled our chat logging rule only for `Trace` level, only for our `MainAccount` bot and only for functions related to chat logging (`OnIncoming*` which is used for receiving messages and echos, and `SendMessage*` for ASF messages sending).

The example above will generate `logs/chat/0-0-76561198069026042.txt` file when talking with **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 元気ですか? -> 76561198069026042
2018-07-26 01:38:38 素晴らしいことをしています。あなたはどうですか？ <- 76561198069026042
```

もちろん、これは実用的な方法で示されたいくつかの素晴らしいレイアウトのトリックを使用した作業例です。 追加のフィルタリング、カスタム注文、個人的なレイアウト、受信したメッセージのみの記録など、このアイデアを自分のニーズにさらに拡張できます。

### 別の例

これは、 `archi` という名前のボットが寄付取引を受けたときにメインボットのsteamID (`76561198006963719`)にメッセージを送信するために、 `SteamTarget` を使用します。 このプロセスには別のボットが必要です(自分自身にメッセージを送信できないため)。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" />
  </targets>

  <rules>
    <logger name="archi" level="Trace" writeTo="Steam">
      <filters defaultAction="Ignore">
        <when condition="starts-with('${message}','ParseTrade() Accepted donation trade: ')" action="Log" />
      </filters>
    </logger>
  </rules>
</nlog>
```

---

## ASFターゲット

標準の NLog ロギングターゲットに加えて、 (上で説明する `ColoredConsole` や `ファイル` など) カスタムASFロギングターゲットを使用することもできます。

最大限の完成度を得るために、ASFターゲットの定義はNLog文書化条約に従います。

---

### SteamTarget

推測できるように、このターゲットはASFメッセージをログに記録するためにSteamチャットメッセージを使用します。 グループ チャットまたはプライベート チャットのいずれかを使用するように設定できます。 メッセージのSteamターゲットを指定することに加えて、 これらを送信するボットの `botName` を指定することもできます。

ASFが使用するすべての環境でサポートされています。

---

#### 設定構文
```xml
<targets>
  <target type="Steam"
          name="String"
          layout="Layout"
          chatGroupID="Ulong"
          steamID="Ulong"
          botName="Layout" />
</targets>
```

[設定ファイル](https://github.com/NLog/NLog/wiki/Configuration-file) の使用方法の詳細をご覧ください。

---

#### パラメータ

##### 全般オプション
_name_ - ターゲットの名前。

---

##### レイアウトオプション
_layout_ - レンダリングされるテキスト。 [](https://github.com/NLog/NLog/wiki/Layouts) レイアウトが必要です。 デフォルト: `${level:uppercase=true}|${logger}|${message}`

---

##### SteamTarget オプション

_chatGroupID_ - 64ビットの符号なし整数として宣言されたグループチャットのID。 必須ではありません。 デフォルトは `0 0` で、グループチャット機能を無効にし、代わりにプライベートチャットを使用します。 有効な場合 (ゼロ以外の値に設定) `steamID` プロパティは `chatID` として機能し、ボットがメッセージを送信する必要がある `chatGroupID` 内のチャンネルの ID を指定します。

_steamID_ - SteamID declared as 64-bit long unsigned integer of target Steam user (like `SteamOwnerID`), or target `chatID` (when `chatGroupID` is set). 必須です。 デフォルトは `0 0` で、ロギングターゲットを完全に無効にします。

_botName_ - 上記で宣言した `steamID` にメッセージを送信する (ASFによって認識されているように、大文字と小文字を区別します)。 必須ではありません。 Defaults to `null` which will automatically select **any** currently connected bot. It's recommended to set this value appropriately, as `SteamTarget` does not take into account many Steam limitations, such as the fact that you must have `steamID` of the target on your friendlist. This variable is defined as [layout](https://github.com/NLog/NLog/wiki/Layouts) type, therefore you can use special syntax in it, such as `${logger}` in order to use the bot that generated the message.

---

#### SteamTarget の例

In order to write all messages of `Debug` level and above, from bot named `MyBot` to steamID of `76561198006963719`, you should use `NLog.config` similar to below:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**Notice:** Our `SteamTarget` is custom target, so you should make sure that you're declaring it as `type="Steam"`, NOT `xsi:type="Steam"`, as xsi is reserved for official targets supported by NLog.

When you launch ASF with `NLog.config` similar to above, `MyBot` will start messaging `76561198006963719` Steam user with all usual ASF log messages. メッセージを送信するには、 `MyBot` が接続されている必要があります。 したがって、ボットがSteamネットワークに接続する前に発生したすべての最初のASFメッセージは転送されません。

もちろん、 `SteamTarget` には、一般的な `TargetWithLayout`から期待できるすべての典型的な関数があります。 eと組み合わせて使うことができます を選択します。 上記の例は、最も基本的な例にすぎません。

---

#### スクリーンショット

![スクリーンショット](https://i.imgur.com/5juKHMt.png)

---

#### 注意

`` ロギングレベルを `SteamTarget` と ASFプロセスに参加している `steamID` を組み合わせるときは注意してください。 これは、潜在的な `StackOverflowException` につながる可能性があります。なぜなら、与えられたメッセージを受け取るASFの無限ループを作成するからです。 Steam経由でログを記録し、別のメッセージを記録する必要があります。 Currently the only possibility for it to happen is to log `Trace` level (where ASF records its own chat messages), or `Debug` level while also running ASF in `Debug` mode (where ASF records all Steam packets).

In short, if your `steamID` is taking part in the same ASF process, then the `minlevel` logging level of your `SteamTarget` should be `Info` (or `Debug` if you're also not running ASF in `Debug` mode) and above. あるいは、無限のロギングループを避けるために、独自の `<when>` ロギングフィルターを定義することもできます。 あなたのケースに適切なレベルを変更する場合 この警告は、グループチャットにも適用されます。

---

### HistoryTarget

このターゲットは、 `/Api/NLog` エンドポイント **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** で固定サイズのロギング履歴を提供するため、ASF-uiやその他のツールで使用できます。 一般的に、他のカスタマイズにカスタムNLog設定を使用している場合にのみ、このターゲットを定義する必要があります。また、ASF APIでログを公開したい場合に限ります。 ASF-ui用 It can also be declared when you'd want to modify default layout or `maxCount` of saved messages.

ASFが使用するすべての環境でサポートされています。

---

#### 設定構文
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

[設定ファイル](https://github.com/NLog/NLog/wiki/Configuration-file) の使用方法の詳細をご覧ください。

---

#### パラメータ

##### 全般オプション
_name_ - ターゲットの名前。

---

##### レイアウトオプション
_layout_ - レンダリングされるテキスト。 [](https://github.com/NLog/NLog/wiki/Layouts) レイアウトが必要です。 デフォルト: `${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${exception:inner= ${exception:format=toString,Data}}`

---

##### HistoryTarget オプション

_maxCount_ - オンデマンド履歴の最大ログ量。 必須ではありません。 デフォルトは `20` で、初期履歴を提供するための良いバランスです。 記憶装置の要件から生じるメモリ使用量を念頭に置いています `0 0` より大きくなければなりません。