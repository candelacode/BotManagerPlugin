# 高パフォーマンス初期設定

これは、 **[低メモリセットアップ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** の正反対であり、ASF パフォーマンスをさらに向上させたい場合は、通常これらのヒントに従いたいと思います(CPU 速度の点で)。 メモリ使用量が増える可能性があります

---

ASFは、一般的なバランス調整に関しては、すでにパフォーマンスの好みを試みています。 したがって、あなたがさらにそのパフォーマンスを向上させるために行うことができる多くはありません, あなたはどちらかの選択肢の完全ではありませんが、. ただし、これらのオプションはデフォルトでは有効になっていないことに注意してください。 つまり彼らは大多数の使用にバランスが取れていると考えるには不十分です だから自分で決めるべきだ記憶の増加が許されるか?

---

## ランタイムチューニング（高度）

以下のトリック **には深刻なメモリ増加** が含まれているため、注意して使用する必要があります。

これらの設定を適用する推奨方法は、 `DOTNET_` 環境プロパティです。 Of course, you could also use other methods, e.g. `runtimeconfig.json`, but some settings are impossible to be set this way, and on top of that ASF will replace your custom `runtimeconfig.json` with its own on the next update, therefore we recommend environment properties that you can set easily prior to launching the process.

.NET ランタイムでは、さまざまな方法で **[ガベージコレクタ](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** を微調整できます。 GCプロセスを効果的に微調整します。 私たちは、私たちの意見では特に重要な特性以下を記録しました。

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> ワークステーションのガベージコレクションかサーバのガベージコレクションかを設定します。

ガベージコレクション **[の基本的な](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)** では、サーバ GC の具体的な内容を確認することができます。

ASFはデフォルトでワークステーションのガベージコレクションを使用しています。 これは主に、メモリ使用量とパフォーマンスのバランスが良いためです。これは、ほんの数台のボットで十分です。 通常、単一の同時バックグラウンドGCスレッドは、ASFによって割り当てられたメモリ全体を処理するのに十分な速さです。

しかし、今日、ASFの恩恵を受けることができる多くのCPUコアがあります。 利用可能な各 CPU vCore ごとに専用の GC スレッドを持つことによって。 これにより、バッジページの構文解析やインベントリなど、ASFの重いタスク中のパフォーマンスが大幅に向上します。 すべてのCPUのvCoreは2(メインとGC)とは対照的に役立つことができるので。 3 CPU vCores 以上のマシンにはサーバー GC が推奨されます。マシンが 1 CPU vCoreの場合、ワークステーション GC は自動的に強制されます。 そして、正確に2を持っている場合は、両方を試してみることを検討することができます (結果は異なる場合があります)。

サーバーGC自体は、アクティブにするだけで非常に大きなメモリ増加をもたらしません。 しかし、それははるかに大きな世代サイズを持っているので、OSにメモリを戻すことになると、はるかに遅延します。 サーバー GC が大幅にパフォーマンスを向上させるスイートスポットに自分自身を見つけるかもしれませんし、それを使い続けたいと思うでしょう。 でも同時に使うことで 記憶力が大きく増えるわけにはいきません 幸いにも、"両方の世界の最高の"設定があります。 **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** 設定プロパティを `0`に設定することによってサーバー GC を使用します。 これはサーバGCを有効にしますが、生成サイズを制限し、メモリに集中します。 あるいは、別のプロパティ、 **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**、あるいはそれらの両方を同時に試してみることもできます。

しかし、メモリが問題にならない場合(GCはまだ利用可能なメモリと微調整自体を考慮に入れています)。 それらの特性を全く変更せず、結果的に優れた性能を発揮する方がいいと思います。

---

適切な環境変数を設定することで、選択したプロパティを有効にできます。 例えば、Linux (shell):

```shell
export DOT_gcServer=1

./ArchiSteamFarm # For OS specific build
./ArchiSteamFarm.sh # For general build
```

または、Windows (powershell)上で:

```powershell
$Env:DOT_gcServer=1

.\ArchiSteamFarm.exe # OS 固有のビルド
.\ArchiSteamFarm.cmd # 一般的なビルド
```

---

## 推奨最適化

- `OptimizationMode` のデフォルト値が `MaxPerformance` であることを確認してください。 `MinMemoryUsage` を使用すると、パフォーマンスに劇的な影響を与えるため、これははるかに重要な設定です。
- サーバGCを有効にする Server GCは、ワークステーションGCに比べてメモリが大幅に増加することによって即座にアクティブであると見なすことができます。 これにより、マシンが持っているCPUスレッドごとにGCスレッドが生成され、最高速度と並行してGC操作が実行されます。
- サーバーGCのためにメモリを増やす余裕がない場合 **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** または **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)1 "両方の世界の最高"を達成するためにformat@@11</strong> を調整することを検討してください。 しかし、あなたのメモリがそれを買う余裕がある場合。 サーバーGCは実行時にすでに自分自身を微調整し、OSが本当に必要とするときにメモリを少なくするのに十分なスマートさを備えています。</li>
</ul>

<p spaces-before="0">上記の推奨事項を適用すると、数百から数千の有効なボットでも高速に燃えるべき優れたASFパフォーマンスを得ることができます。 ASFが必要に応じてCPUパワー全体を使用できるため、CPUはボトルネックにならなくなり、必要な時間を最小限に抑えることができます。 次のステップは、CPUとRAMのアップグレード、または複数のサーバーとASFインスタンスにワークロードを分割することです。</p>