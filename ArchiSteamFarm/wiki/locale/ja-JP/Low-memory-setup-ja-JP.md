# 低メモリ初期設定

これは、 **[高性能セットアップ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup)** の正反対です。ASFのメモリ使用量を減らしたい場合は、通常これらのヒントに従ってください。 全体的なパフォーマンスを低下させるコストです

---

ASFは、Linuxを搭載した128メガバイトのVPSでさえも実行可能であるため、定義上、リソース上で非常に軽量です。 その低さは推奨されず様々な問題につながる可能性がありますが ASFは軽いが、OSに多くのメモリを要求することを恐れず、ASFが最適な速度で動作するためにそのようなメモリが必要な場合。

アプリケーションとしてのASFは、可能な限り最適化され、効率的であり、実行中に使用されるリソースも念頭に置いています。 メモリに関しては、ASFは一時的なメモリ「スパイク」につながる可能性のあるメモリ消費量よりもパフォーマンスを好みます。例えば、 3つ以上のバッジページを持つアカウントで、ASFは最初のページを取得して解析し、合計ページ数から読み取ります。 次に、追加のページごとにfetch タスクを起動し、残りのページのフェッチと解析が同時に行われます。 余分なメモリ使用量(動作の最小限と比較して)は、実行を劇的に高速化し、全体的なパフォーマンスを向上させることができます。 これらすべてを並行して行うのに必要なメモリ使用量を増やすことができます 同様のことは、並列に実行できる他のすべての一般的なASFタスクにも起こっています。例えば、 アクティブなトレードオファーを解析することで、ASFはすべて独立しているため、すべてを一度に解析できます。 On top of that, ASF (C# runtime) will **not** return unused memory back to OS immediately afterwards, which you can quickly notice in form of ASF process only taking more and more memory, but (almost) never giving that memory back to the OS. 何人かの人々はすでにそれが疑わしい見つけるかもしれません, 多分メモリーリークが疑わしいです, しかし、心配しないでください, これのすべてが期待されています.

ASFは極めて最適化されており、可能な限り利用可能なリソースを利用しています。 ASFのメモリ使用量が多いということは、ASFが積極的に **を使用し、** が **が**を必要とするということではありません。 ASFは、将来のアクションのために割り当てられたメモリを「ルーム」として保持します。 使用しようとしている全てのメモリチャンクをOSに問い合わせる必要がなければパフォーマンスが大幅に向上するからです The runtime should automatically release unused ASF memory back to OS when OS will **truly** need it. **[未使用のメモリは](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)** メモリを無駄にします。 You run into issues when the memory you **need** is higher than the memory that is available for you, not when ASF keeps some extra allocated with purpose of speeding up functions that will execute in a moment. LinuxカーネルがOOM(メモリ不足)のためにASFプロセスを停止しているときに問題が発生します。 `htop` でASFプロセスがトップメモリコンシューマとして表示された場合はそうではありません。

**[ガベージコレクション](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** は、ASFで使用される非常に複雑なメカニズムです。 ASF自体だけでなく、OSやその他のプロセスも考慮できるほどスマートです。 多くの空きメモリがある場合、ASFはパフォーマンスを向上させるために必要なものは何でも要求します。 これは、最大1GB(サーバーGC)を使用することができます。 お使いのOSメモリがいっぱいに近い場合、ASFはその一部をOSに自動的に解放し、解決に役立ちます。 これにより、ASF全体のメモリ使用量は50MBと低くなります。 50 MB と 1 GB の違いは巨大です。 しかし、小型512 MBのVPSと32 GBの巨大な専用サーバーの違いもあります。 ASFがこのメモリが役に立つことを保証でき、同時に今すぐ必要としない場合。 過去に実行されたルーチンに基づいて自動的に最適化する ASFで使用されているGCはセルフチューニングであり、プロセスの実行時間が長くなります。

This is also why ASF process memory varies from setup to setup, as ASF will do its best to use available resources in **as efficient way as possible**, and not in a fixed way like it was done during Windows XP times. The actual (real) memory usage that ASF is using can be verified with `stats` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, and is usually around 4 MB for just a few bots, up to 30 MB if you use stuff like **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** and other advanced features. `stats` コマンドによって返されるメモリには、ガベージコレクタによってまだ回収されていない空きメモリも含まれていることに注意してください。 それ以外のものは、ランタイムメモリ(約40〜50MB)と実行の余地(異なります)を共有しています。 同じASFが低メモリVPS環境でわずか50MBを使用できる理由でもあります。 デスクトップでも1GBを使用しています。 ASFはあなたの環境に積極的に適応しており、OSを圧迫しないように最適なバランスを見つけようとします。 使用される可能性のある未使用のメモリをたくさん持っている場合は、独自のパフォーマンスを制限することもありません。

---

もちろんです ASFを正しい方向に向けて使用することが期待されるメモリに関して、どのようにして役立つのかがたくさんあります。 一般的に、あなたがそれを行う必要がない場合は、ごみ収集者が安心して動作し、それが最善であると考えていることを行うことが最善です。 しかし、たとえば、Linuxサーバーが複数のWebサイト、MySQLデータベース、PHPワーカーをホストしている場合など、これは常に可能ではありません。 OOMに近づくと、通常は遅すぎてパフォーマンスの低下が早くなるため、ASFが縮小する余裕はありません。 これは通常、さらにチューニングに興味がある場合であり、したがって、このページを読んでください。

以下の提案はいくつかのカテゴリに分かれており、難易度はさまざまです。

---

## ASFセットアップ（簡単）

Below tricks **do not affect performance negatively** and can be safely applied to all setups.

- 可能であれば、ASFの **[ジェネリックバージョン](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** を実行します。 ASFの一般的なバージョンは、ランタイムが内部に含まれていないため、単一のファイルとして来ないので、より少ないメモリを使用しています。 実行中に自分自身を解凍する必要はありませんしたがって、より小さく、メモリの足跡が少なくなります。 OS固有のパッケージは便利で便利ですが、ASFを起動するために必要なすべてのパッケージも同梱されています。 これは自分の世話をし、代わりに汎用ASFバリアントを使用することができます。
- 複数のASFインスタンスを実行しないでください。 ASFは、一度に無制限のボット数を処理することを意図しており、すべてのASFインスタンスを異なるインターフェース/IPアドレスにバインドしていない限り。 必要に応じて複数のボットを使用して、 **** ASFプロセスを正確に行う必要があります。
- Make use of `ShutdownOnFarmingFinished` in bot's `FarmingPreferences`. アクティブなボットは、無効化されたボットよりも多くのリソースを消費します。 Botの状態を保持する必要があるため、それは重要な保存ではありません。 しかし、あなたはいくらかの量のリソースを節約しています、特にTCPソケットのようなネットワークに関連するすべてのリソースです。 必要に応じて、いつでも他のボットを呼び出すことができます。
- あなたのボット番号を低くしてください。 `有効ではない` ボットインスタンスは、ASFが起動することを気にしないので、リソースが少なくなります。 Also keep in mind that ASF has to create a bot for each of your configs, therefore if you don't need to `start` given bot and you want to save some extra memory, you can temporarily rename `Bot.json` to e.g. `Bot.json.bak` in order to avoid creating state for your disabled bot instance in ASF. This way you won't be able to `start` it without renaming it back, but ASF also won't bother keeping state of this bot in memory, leaving room for other things (very small save, in 99.9% cases you shouldn't bother with it, just keep your bots with `Enabled` of `false`).
- 設定を微調整します。 特にグローバル ASF 設定には、調整する多くの変数があります。例えば、 `LoginLimiterDelay` を増やすと、ボットが遅くなります。 すでに起動済みのインスタンスにバッジを取得させることができます。ボットを素早く呼び出すのではなく より多くのボットが同時に主要な作業(バッジの解析など)を行うため、より多くのリソースを必要とします。 同時に行う必要がある作業が少ないほど、メモリが少なくなります。

これらは、メモリ使用量を扱うときに覚えておくことができるいくつかのことです。 しかし、これらのことは、メモリ使用量に関して「重要な」問題を持っていません。 メモリ使用量は主にASFが扱うべきものであり、カードの農業に使用される内部構造ではないためです。

最もリソース重い関数は次のとおりです。
- バッジページの解析
- 在庫解析中

つまり、ASFが読書バッジページを扱っているときや、そのインベントリを扱っているときに、メモリが最も多く消費されることになります(e. をクリックします。 これは、ASFが本当に膨大なデータを処理しなければならないためです。これらの2ページを起動するお気に入りのブラウザのメモリ使用量はそれよりも低くなりません。 申し訳ありませんが、それはそれがどのように動作します - バッジページの数を減らし、確実に助けることができるあなたのインベントリアイテムの数を低く保ちます。

---

## ランタイムチューニング（高度）

以下のトリック **は性能劣化** を伴い、注意して使用する必要があります。

これらの設定を適用する推奨方法は、 `DOTNET_` 環境プロパティです。 Of course, you could also use other methods, e.g. `runtimeconfig.json`, but some settings are impossible to be set this way, and on top of that ASF will replace your custom `runtimeconfig.json` with its own on the next update, therefore we recommend environment properties that you can set easily prior to launching the process.

.NET ランタイムでは、さまざまな方法で **[ガベージコレクタ](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** を微調整できます。 GCプロセスを効果的に微調整します。 私たちは、私たちの意見では特に重要な特性以下を記録しました。

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> GCヒープ使用量を合計物理メモリのパーセンテージで指定します。

ASFプロセスの「ハード」メモリ制限。この設定では、GCを合計メモリのサブセットのみ使用し、すべてではありません。 これは、ASF用のサーバーメモリの固定パーセントを捧げることができる、さまざまなサーバーのような状況で特に有用になるかもしれません。 でもそれ以上のことはない ASFが使用するためにメモリを制限することは、魔法のように必要なメモリ割り当てをすべて解消するわけではないことに注意してください。 したがって、この値を低く設定すると、ASFプロセスが強制終了されるメモリシナリオが不足する可能性があります。

一方、 この値を十分に高く設定することは、ASFが現実的に可能な限り多くのメモリを使用しないようにする完璧な方法です。 重い負荷の下でもマシンに呼吸を与える一方で プログラムを可能な限り効率的に行うことができます

### [`GCConserveMemory`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> ガベージコレクタを設定して、より頻繁なガベージコレクションとおそらく長いポーズ時間を犠牲にしてメモリを節約します。

0-9の間の値を使用できます。 値が大きいほど、GCが増えるほどパフォーマンスよりもメモリを最適化します。

### [`GCHIGMemPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> GCがより攻撃的になるまでのメモリ使用量を指定します。

この設定は、一度経過したOS全体のメモリ閾値を設定します。 GCはより積極的になり、より集中的なGCプロセスを実行し、より多くの空きメモリをOSに解放することで、OSのメモリ負荷を低減させる試みを行います。 このプロパティを、OS全体のパフォーマンスに対して「クリティカル」とみなす最大メモリ量(パーセンテージ)に設定することをお勧めします。 デフォルトは90%で、通常は80-97%の範囲に保持します。 値が低すぎると、GCからの不必要な侵略や性能劣化を理由なしに引き起こすからです 値が高すぎるとOSに不要な負荷がかかりますが、ASFはそのメモリの一部を解放して助けになる可能性があります。

### **[`GCLatencyLevel`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> 最適化するGCレイテンシレベルを指定します。

これはASFにとって非常にうまく機能することが判明した文書化されていないプロパティです。 GC世代のサイズを制限し、結果としてGCパージをより頻繁に、より積極的に行います。 デフォルト(バランスの取れた)レイテンシレベルは `1`ですが、 `0 0`を使用してメモリ使用量を調整できます。

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> 設定すると、コミットされた空間をより積極的に一時的な縫い目のためにトリミングします。 これは、できるだけ少ないメモリを保持したいサーバプロセスの多くのインスタンスを実行するために使用されます。

これはほとんど改善を提供しませんが、システムがメモリ上で低くなったときにGCをさらに攻撃的にする可能性があります。 特に、スレッドプールのタスクを大きく利用するASFの場合。

---

適切な環境変数を設定することで、選択したプロパティを有効にできます。 例えば、Linux (shell):

```shell
# Don't forget to tune those if you're planning to make use of them
export DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
export DOTNET_GCHighMemPercent=0x50 # 80% as hex

export DOTNET_GCConserveMemory=9
export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

または、Windows (powershell)上で:

```powershell
# Don't forget to tune those if you're planning to make use of them
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80% as hex

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

特に、 `GCLatencyLevel` は、ランタイムが実際にメモリ用のコードを最適化し、メモリ使用量を大幅に削減することを検証したため、非常に便利になります。 サーバーGCでさえも `OptimizationMode` でパフォーマンスを低下させずにASFメモリ使用量を大幅に削減したい場合に適用できる最良のトリックの1つです。

---

## ASFチューニング（中間）

以下のトリック **は、深刻な性能劣化** を伴い、注意して使用する必要があります。

- 最後の手段として、 `MinMemoryUsage` を `OptimizationMode` **[global config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)** で調整できます。 これはほとんどメモリの利益のために深刻な性能劣化であるため、その目的を注意深く読んでください。 This is typically **the last thing you want to do**, long after you go through **[runtime tuning](#runtime-tuning-advanced)** to ensure that you're forced to do this. セットアップに絶対的な重要性がない限り、 `MinMemoryUsage`を使用することをお勧めしません。

---

## 推奨最適化

- 簡単なASFセットアップのトリックから開始 **[汎用ASFバリアント](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** を使用し、すべてのボットでプロセスを数回開始するなど、間違った方法でASFを使用しているかどうかを確認します。 自動起動に必要な場合は全てを有効にしておくこともできます
- それでも十分でない場合は、適切な `DOTNET_` 環境変数を設定することで、上記のすべての設定プロパティを有効にします。 特に、 `GCLatencyLevel` は、パフォーマンスにかかるコストが少ない大幅なランタイム改善を提供します。
- それでも役に立たなかった場合、最後の手段として `MinMemoryUsage` `OptimizationMode` を有効にします。 これにより、ASFは同期事項のほぼすべてを実行しなければなりません。 並列実行で物事のバランスを取るためにスレッドプールに頼らないようにしています

さらにメモリを減らすことは物理的に不可能です。 ASFはすでにパフォーマンスの面で大幅に低下しており、コード単位とランタイム単位の両方で、あらゆる可能性を失いました。 ASFを使用するために余分なメモリを追加することを検討してください。128メガバイトでも大きな違いがあります。