# Docker

ASFは、 **[docker container](https://www.docker.com/what-container)** として利用可能です。 ドッカーパッケージは現在、 **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** および **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)** で入手できます。

It's important to note that running ASF in Docker container is considered **advanced setup**, which is **not needed** for vast majority of users, and typically gives **no advantages** over container-less setup. If you're considering Docker as a solution for running ASF as a service, for example making it start automatically with your OS, then you should consider reading **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** section instead and set up a proper `systemd` service which will be **almost always** a better idea than running ASF in a Docker container.

DockerコンテナでASFを実行するには、通常、 **いくつかの新しい問題と** 問題があります。 このため、 **強く** はDockerの知識があり、内部の理解を助ける必要がない限り、それを避けることをお勧めします。 ASFウィキについては詳しく述べません このセクションは主に非常に複雑なセットアップの有効な使用事例を対象としています。 例えば、ASFが `systemd` サービスに付属する標準サンドボックスを超えた高度なネットワークやセキュリティに関しては(非常に高度なセキュリティメカニックを通じて優れたプロセスの分離をすでに保証します)。 少数の人々のために、ここではDocker互換性に関してより良いASFの概念を説明します。 ASFと一緒に使う場合は、Dockerの知識を十分に持っているとみなされます。

---

## タグ

ASFは、いくつかのタイプの **[タグ](https://hub.docker.com/r/justarchi/archisteamfarm/tags)** で利用できます:


### `メイン`

`メイン` ブランチ内の最新のコミットからビルドされた ASF の一般的なビルド。 ` ` CI **[](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** パイプラインから直接最新のアーティファクトを取得するのと同じです。 これは、開発目的で開発者や上級ユーザー専用の最高レベルのバグのソフトウェアです。 イメージは `メイン` GitHub ブランチ内の各コミットで更新されています。 したがって、あなたは非常に頻繁に変化を期待することができます (そして、物事が壊れている)。 ASFプロジェクトの現在の状態をマークするためにここにあります。 リリースサイクルで指摘されたように、必ずしも安定しているわけではありません。 **このタグは、本番環境** では使用しないでください。 特定のコミットが発生した問題を修正しているかどうかを検証するのに役立ちます。そのコミットのプレリリースを待たずに。


### `リリース`

プレリリースを含む最新の **[](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASFバージョンを常に指すASFの一般的なビルド。 `メインの` タグと比較すると、新しいGitHubタグがプッシュされるたびに画像が更新されています。 安定していると同時に新鮮であると考えることができるものの端に住むことを愛する高度な/パワーユーザーに専念。 実際には、プル時に最新の `A.B.C.D` リリースを指すローリングタグと同じように動作します。 このタグを使用することは、 **[プリリリース](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** を使用することと等しいことに注意してください。

### `安定版`

常に最新の **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASFバージョンを指すASFの一般的なビルド。 `がリリースした` タグと比較して、新しい安定版の ASF が利用可能になると、ここでの画像が更新されています。 安定した `を探している人には、上記の` タグをリリースしました。

### `最新`

常に最新の **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASFバージョンを指すOS固有のビルド。 他の人と比較して、これはASFの自動更新を含む **のみのタグ** です。 このタグの目的は、ASFのOS固有のビルドで自己更新を実行できる正常なデフォルトのDockerコンテナを提供することです。 そのため、画像をできるだけ頻繁に更新する必要はありません。 ASFバージョンは、必要に応じて常にアップデートすることができます。

Of course, `UpdatePeriod` can be safely turned off (set to `0`), but in this case you should probably use `stable` release instead. 同様に、プリリリースを追跡するために、デフォルトの `UpdateChannel` を変更することができます。

Due to the fact that the `latest` image comes with capability of auto-updates, it includes bare OS with OS-specific `linux` ASF version, contrary to all other tags that include OS with .NET runtime and `generic` ASF version. これは、新しい(更新された)ASFバージョンでは、イメージがビルドされる可能性のあるものよりも新しいランタイムが必要になる可能性があるためです。 それ以外の場合は、計画されたユースケースを無効にするために、ゼロから再構築する必要があります。

### `A.B.C.D`

タグに一致する固定ASFバージョンを指し示すASFの一般的なビルド。 上記のタグと比較して、このタグは完全に凍結されているため、公開されると画像は更新されません。 これは最初のリリース後には触れられないGitHubリリースと同様に動作し、安定した環境と凍結した環境を保証します。 通常、特定の ASF リリースを使用し、ビルドの決定論的な結果を期待する場合は、このタグを使用する必要があります。 を選択します。

---

## どのタグが私に最適ですか?

それはあなたが探しているものによって異なります。 大多数のユーザーにとって、 `最新の` タグは、ASF のデスクトップを正確に提供する最高のタグでなければなりません サービスとして特別なDockerコンテナで。 しかし、これは必ずしもdockerがどのように使用されるべきかではありません - 通常はコンテナを再構築し、それらを永久に実行しないことが期待されます。 そしてこの場合、 `stable` または `は docker のガイドラインに従ってリリースされた` タグを考慮する必要があります。 最後に、固定ASFバージョンを代わりに実行したい場合は、当然 `A.B.C.D` リリースが求められています。

`メイン` ビルドを試すことは、通常、これらのビルドはASFプロジェクトの現在の状態をマークするためにここにあります。 そのような状態が正常に動作することを保証するものはありません もちろんASF開発に興味があるなら、ぜひお試しください。

---

## アーキテクチャ

ASF docker image is currently built on `linux` platform targetting 3 architectures - `x64`, `arm` and `arm64`. You can read more about them in **[compatibility](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** section.

私たちのタグはマルチプラットフォームマニフェストを使用しています。 つまり、マシンにインストールされている Docker は、イメージをプルする際にプラットフォームに適したイメージを自動的に選択します。 特定のプラットフォームイメージを引き出したい場合は、現在実行しているものと一致しません。 `--platform` スイッチを介して適切な docker コマンド ( `docker run` など) を切り替えることができます。 詳細については、 **[イメージ manifest](https://docs.docker.com/registry/spec/manifest-v2-2)** の docker documentation を参照してください。

---

## 使用法

完全な参照のためには、 **[公式docker docker](https://docs.docker.com/engine/reference/commandline/docker)**を使用する必要があります。 このガイドでは基本的な使い方だけをカバーしますあなたはもっと深く掘り下げるのを歓迎します。

### Hello ASF!

まず、dockerが正しく動作しているかどうかを確認する必要があります。これはASFの「こんにちは世界」として機能します：

```shell
docker run -it -name asf --pull always --rm justarchi/archisteamfar
```

`docker run` は新しいASFドッカーコンテナを作成し、フォアグラウンド(`-it`)で実行します。 `--pull always` ensures that up-to-date image will be pulled first, and `--rm` ensures that our container will be purged once stopped, since we're just testing if everything works fine for now.

すべてのレイヤーを引っ張ってコンテナを開始した後、すべてが正常に終了した場合。 ASFが適切に起動し、定義されたボットがないことを私たちに知らせる必要があります。 これは良いことです - 私たちはdockerでASFが正しく動作することを確認しました。 `CTRL+C` を押すとASFプロセスが終了し、したがってコンテナも終了します。

コマンドを詳しく見てみると、タグが宣言されていないことがわかります。 これは自動的に `最新の` をデフォルトにしました。 `latest`以外のタグを使用する場合は、例えば `がリリースされた`を使用し、明示的に宣言する必要があります。

```shell
docker run -it -name asf --pull always --rm justarchi/archisteamfarm:released
```

---

## 音量の使用

docker containerでASFを使用している場合は、明らかにプログラム自体を設定する必要があります。 様々な方法で行うことができます しかし、推奨されるのは、ローカル マシン上に ASF `config` ディレクトリを作成することです。 次に、ASFドッカーコンテナに共有ボリュームとしてマウントします。

例えば、ASF config フォルダーが `/home/archi/ASF/config` ディレクトリにあるとします。 このディレクトリには、コア `ASF.json` と実行したいボットが含まれています。 今、私たちがする必要があるのは、単に docker コンテナー内の共有ボリュームとしてそのディレクトリを追加するだけです。 ここでASFはconfigディレクトリを期待します (`/app/config`).

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

これで、ASFドッカーコンテナは読み書きモードでローカルマシンと共有ディレクトリを使用します。 ASFを構成するために必要なものはすべてこれです。 同様に、 `/app/logs` や `/app/plugins` など、ASFと共有したいボリュームをマウントすることができます。

もちろん、これは私たちが望むことを達成するための唯一の特定の方法です。例えば、あなたを停止させるものはありません。 独自の `Dockerfile` を作成すると、ASF docker container内の設定ファイルが `/app/config` ディレクトリにコピーされます。 このガイドでは基本的な使い方について説明しています。

### ボリュームの権限

ASF container by default is initialized with default `root` user, which allows it to handle the internal permissions stuff and then eventually switch to `asf` (UID `1000`) user for the remaining part of the main process. これは大多数のユーザーにとって満足すべきですが。 新しく生成されたファイルは通常、 `asf` ユーザーが所有するため、共有ボリュームに影響します。 共有ボリュームの他のユーザーを望んでいる場合は望ましくないかもしれません。

ASFが実行しているユーザーを変更するには、2つの方法があります。 The first one, recommended, is to declare `ASF_UID` environment variable with target UID you want to run under. 第二に、代替案として、 `--user` **[フラグ](https://docs.docker.com/engine/reference/run/#user)**を渡します。これはdockerが直接サポートしています。

例えば、 `uid` コマンドを `id -u` コマンドでチェックし、上記で指定したように宣言することができます。 例えば、ターゲットユーザーが 1001 の `uid` を持っている場合:

```shell
docker run -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm

# Alternatively, if you understand the limitations below
docker run -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

`ASF_UID` と `--user` フラグの違いは微妙ですが、重要です。 `ASF_UID` is custom mechanism supported by ASF, in this scenario docker container still starts as `root`, and then ASF startup script starts main binary under `ASF_UID`. `--user` フラグを使用する場合は、指定されたユーザーとしてASF起動スクリプトを含むプロセス全体を開始します。 最初のオプションでは、ASFの起動スクリプトが自動的に権限やその他の要素を処理し、発生した一般的な問題を解決することができます。 例えば、 `/app` と `/asf` ディレクトリが実際に `ASF_UID` によって所有されていることを保証します。 2つ目のシナリオでは、 `root`として実行していないので、 我々はそれを行うことはできませんそして、あなたは事前にすべてのことを自分で処理する必要があります。

If you've decided to use `--user` flag, you need to change ownership of all ASF files from default `1000` to your new custom user. 以下のコマンドを実行することで可能です:

```shell
# Execute only if you're not using ASF_UID
docker exec -u root asf_container_name chown -hR 1001 /app /asf
```

This has to be done only once after you created your container with `docker run`, and only if you decided to use custom user through `--user` docker flag. また、上記コマンドの `1001` 引数を実際にASFを実行したい `UID` に変更することを忘れないでください。

### SELinux 付きボリューム

お使いのOSでSELinuxを強制状態で使用している場合、たとえばRHELベースのdistrosのデフォルトです。 次に、 `:Z` オプションを追加するボリュームをマウントします。このオプションは、それに対して正しいSELinuxコンテキストを設定します。

```
docker run -it -v /home/archi/ASF/config:/app/config:Z ---name asf --pull always justarchi/archisteamfarm
```

これにより、ASFはdockerコンテナ内でボリュームを取得している間にファイルを作成できます。

---

## 複数のインスタンスの同期

ASFには、 **[管理](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** セクションに記載されているように、複数のインスタンス同期のサポートが含まれています。 docker containerでASFを実行する場合、プロセスにオプションで「オプトイン」することができます。 ASFを使用して複数のコンテナを実行していて、それらが相互に同期するようにしたい場合。

デフォルトでは、Dockerコンテナ内で実行される各ASFはスタンドアロンであるため、同期は行われません。 同期を有効にするには、同期するすべてのASFコンテナに `/tmp/ASF` パスをバインドする必要があります。 読み書きモードで、docker hostの共有パスを1つに設定します。 これは、異なるパスを使用して、上記のボリュームをバインディングするのとまったく同じです。

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config -name asf1 --pull always justarchi/archisteamfar
docker run -v /tmp/ASF-g1:/tmp/asF -v /home/john/config:/app/config ---name asf2 -pull justamfar
# など。 すべてのASFコンテナが互いに同期されるようになりました
```

ASFの `/tmp/ASF` ディレクトリをあなたのマシンの一時的な `/tmp` ディレクトリにバインドすることをお勧めします。 もちろん自由に使えるものを選べます 同期されると予想される各ASFコンテナは、同期プロセスに参加している他のコンテナと共有される `/tmp/ASF` ディレクトリを持つ必要があります。

上記の例から推測したように、2つ以上の「同期グループ」を作成することも可能です。 異なるdocker hostのパスをASFの `/tmp/ASF` にバインドすることで。

`/tmp/ASF` のマウントは完全に任意であり、2 つ以上の ASF コンテナを同期させる場合を除き、実際には推奨されません。 単一コンテナでの使用には、 `/tmp/ASF` のマウントはお勧めしません。 ASFコンテナを1つだけ動かせば利益はありません そうしなければ避けられる問題を引き起こすかもしれません

---

## コマンドライン引数

ASFでは、環境変数を介してdockerコンテナに **[コマンドライン引数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** を渡すことができます。 サポートされているスイッチには特定の環境変数を、残りのスイッチには `ASF_ARGS` を使用する必要があります。 これは、 `-e` スイッチを `docker run`に追加することで実現できます。例えば、

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" -name asf --pull always justarchi/archisteamfarm
```

これはdocker container内で実行されているASFプロセスに、他の引数と同様に、あなたの `--cryptkey` 引数を適切に渡します。 もちろん、上級ユーザーであれば、 `ENTRYPOINT` を変更したり、 `CMD` を追加して、自分でカスタム引数を渡すこともできます。

Unless you want to provide custom encryption key or other advanced options, usually you don't need to include any special environment variables, as our docker containers are already configured to run with a sane expected default option of `--no-restart`, so that flag does not need to be specified explicitly in `ASF_ARGS`.

---

## プロセス間通信

`IPC` **[グローバル設定プロパティ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**のデフォルト値を変更しなかったと仮定すると、既に有効になっています。 ただし、IPCがDockerコンテナで動作するようにするには、さらに2つのことを行う必要があります。 Firstly, you must use `IPCPassword` or modify default `KnownNetworks` in custom `IPC.config` to allow you to connect from the outside without using one. 実際に何をしているのかわからない限り、 `IPCPassword` を使ってください。 第二に、docker が外部トラフィックを loopback インターフェイスにルーティングできないため、 `localhost`のデフォルトのリスニングアドレスを変更する必要があります。 すべてのインターフェイスでリッスンする設定の例は、 `http://*:1242` です。 もちろん、ローカルLANやVPNネットワークなどの制限付きバインディングを使用することもできます。 しかし、外部からアクセス可能なルートである必要があります - `localhost` は行いません。 ルートは完全にゲストマシンの中にある

上記を行うには、 **[カスタム IPC config](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** を以下のように使用する必要があります。

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

非ループバックインターフェイスにIPCを設定したら、次にIPCを設定します。 ASFの `1242/tcp` ポートを `-P` または `-p` スイッチでマッピングするよう、ドッカーに指示する必要があります。

たとえば、このコマンドはASFのIPCインターフェイスをホストマシンに公開します(以下のように)。

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -name asf --pull always justarchi/archisteamfarm
```

If you set everything properly, `docker run` command above will make **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface work from your host machine, on standard `localhost:1242` route that is now properly redirected to your guest machine. このルートをさらに公開しないことにも注意してください。 接続はドッカーホスト内でのみ行えるので安全に保つことができます もちろん、あなたが何をしているかを知っていて、適切なセキュリティ対策を確保すれば、ルートをさらに公開することができます。

---

### 完全な例

上記の全知識を組み合わせると、完全なセットアップの例は次のようになります。

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull always --restart unless-stoped justarchi/archistamfar
```

これは、すべての ASF 設定ファイルが `/home/archi/ASF/config` に含まれる単一の ASF コンテナを使用することを前提としています。 マシンに一致する設定パスを変更してください。 `/home/archi/ASF/plugins` に入れることができるASF用のカスタムプラグインを提供することもできます。 This setup is also ready for optional IPC usage if you've decided to include `IPC.config` in your config directory with a content like below:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

以下の `docker compose` 設定を使用すると、上記の `docker run` コマンドと同じ効果を得ることができます。

```yaml
version: "3.8"
services:
  asf:
    image: justarchi/archisteamfarm
    container_name: asf
    restart: unless-stopped
    ports:
      - "127.0.0.1:1242:1242"
      - "[::1]:1242:1242"
    volumes:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

我々はすでに上で議論した以外の事柄から。 上記の両方の例に `--restart が停止していない` を追加し、マシンの再起動後にこのコンテナを自動的に起動します。 あなたのニーズに合わせて自由に取り外し/変更してください。

---

## Pro tips

ASFドッカーコンテナの準備ができている場合は、毎回 `dockerを` 使用する必要はありません。 `docker stop asf` と `docker start asf` で、ASF docker container を簡単に停止/起動できます。 Keep in mind that if you're not using `latest` tag then using up-to-date ASF will still require from you to `docker stop`, `docker rm` and `docker run` again. これは、そのイメージに含まれるASFバージョンを使用するたびに、新鮮なASFドッカーイメージからコンテナを再構築する必要があるためです。 `最新の` タグには、ASF に自動更新機能が含まれています。 したがって、最新のASFを使用するためにイメージを再構築する必要はありません(しかし、新鮮なものを使用するためには、時々それを行うことは良い考えです。 ETランタイムの依存関係と基礎となるOSは、主要なASFバージョンアップデートをジャンプする際に必要になる可能性があります。

As hinted by above, ASF in tag other than `latest` won't automatically update itself, which means that **you** are in charge of using up-to-date `justarchi/archisteamfarm` repo. これは通常、アプリケーションが実行されるときに独自のコードに触れるべきではないので、多くの利点があります。 しかし、我々はまた、便利を理解していますあなたのドッカーコンテナ内のASFバージョンを心配する必要がないからです。 If you care about good practices and proper docker usage, `released` tag is what we'd suggest instead of `latest`, but if you can't be bothered with it and you just want to make ASF both work and auto-update itself, then `latest` will do.

通常、 `ヘッドレス: true` グローバル設定で、docker containerでASFを実行する必要があります。 これは明らかにあなたが欠けている詳細を提供するためにここにいるのではなく、それらを求めるべきではないことをASFに伝えます。 Of course, for initial setup you should consider leaving that option at `false` so you can easily set up things, but in long-run you're typically not attached to ASF console, therefore it'd make sense to inform ASF about that and use `input` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** if need arises. このようにしてASFは発生しないユーザー入力を無限に待つ必要はありません(そしてそうすることでリソースを無駄にします)。 また、コンテナ内の非対話モードでASFを実行することもできます。これは例えば重要です。 転送信号に関しては、ASFが `docker asf` リクエストを正常に閉じることが可能になります。