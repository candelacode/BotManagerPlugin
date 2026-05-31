# モニタリングプラグイン

`MonitoringPlugin`は公式ASF\*\*[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**で、**[Prometheus](https://prometheus.io)\*\*時系列データベースを介してASFプロセスを監視することができます。

---

## スクリーンショット

<details>
  <summary>Show</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## 要件

\*\*[技術的制約](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)\*\*のため、このプラグインには `generic` variant of ASFが必要です。

---

## プラグインを有効にする

ASFにはデフォルトでバンドルされている`MonitoringPlugin`は付属していませんが、すべてのASFリリースでオプションの追加として含まれています。 あなたのASFバージョンに一致する公式\*\*[release]（https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest）\*\*からプラグインをダウンロードし、専用の\`plugins/ArchiSteamFarmを作成します。 プラグインの fficialPlugins.Monitoring\` ディレクトリを作成し、最後にアーカイブを抽出します。

次回のASF起動時に、ログはプラグインが標準のASFロギングメカニズムを介して正常にロードされたことを示します。 IPCインターフェースで`/Api/metrics` URLに移動して確認することもできます。 IPCパスワードを使用している場合は、`/Api/metrics`のURLに`?password=<YourIPCPassword>`を追加するなど、適切な認証が必要です。 表示されるコンテンツは以下のようになります:

```text
# TYPE asf_build_info gauge
# HELP asf_build_info Build information about ASF in form of label values
asf_build_info{variant="source",version="6.0.2.5"} 1 1713715703686

# TYPE asf_runtime_info gauge
# HELP asf_runtime_info Runtime information about ASF in form of label values
asf_runtime_info{framework=".NET 8.0.4",operating_system="Debian GNU/Linux trixie/sid",runtime="linux-x64"} 1 1713715703686
(...)
```

ASFとボットに関するメトリックには専用のプレフィックス「asf_」があります。 .NETランタイムやASFの`HttpClient`に関するその他のメトリックは、ユニバーサル.NETプロセスのルールに基づいて自動的に生成され、そのようなプレフィックスはありません。

---

## プロメテウスの設定

プラグインが正しく動作していることを確認したら、以下のように **[Prometheus](https://prometheus.io)** インスタンスにスクラップ設定を追加できます。

```yaml
scripe_configs:
  - job_name: ArchiSteamFarm
    metrics_path: /Api/metrics
    params:
      password:
        - YourIPCPassword
    static_configs:
      - targets:
          - 127.0.0.1:1242
```

もちろん、ホストされている\*\*[Prometheus](https://prometheus.io)\*\*インスタンスがASFのIPCインターフェースに到達できるようにする必要があります。 あなたの使用に応じて、`password` と `targets` を適応させます。 IPCパスワードが設定されていない場合 (これは推奨されません)、`params` セクションの追加は省略できます。 異なるIPCパスワードを持つ複数のASFインスタンスを実行している場合は、追加のスクレイプ構成を追加できます。 クエリパラメータをターゲットごとに設定することはできません。 そうでなければ、同じパスワードを共有している場合は、複数の `targets` を宣言できます。

---

## Grafana ダッシュボード

プロメテウスによってメトリックが収集されると、**[Grafana](https://grafana.com)** を視覚化することができます。 プラグインには `/grafana-ダッシュボードが付属しています。 標準的なIPCメカニズムによって提供されるson`ファイルなので、デフォルト設定でASFインスタンスを実行していると仮定します。 **[here](http://127.0.0.1:1242/grafana-dashboard.json)** をダウンロードできます。 あるいは、**[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)** から JSON ファイルを取得することもできます。