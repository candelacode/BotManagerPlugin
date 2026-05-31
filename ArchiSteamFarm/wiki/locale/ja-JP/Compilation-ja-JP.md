# コンパイル

コンパイルは、実行ファイルを作成するプロセスです。 ASFに独自の変更を追加したい場合は、これを行います。 何らかの理由で公式の **[で提供されている実行可能ファイルを信頼しない場合は、](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** をリリースします。 開発者でなくユーザーの場合は、事前にコンパイルされたバイナリを使用したいと思うでしょう。 でも自分のものを使ったり新しいことを学んだりしたら読んでみてください

ASFは、現在サポートされているプラットフォーム上でコンパイルすることができます。

---

## .NET SDK

プラットフォームに関係なく、ASFをコンパイルするには、完全な.NET SDK(実行時だけでなく)が必要です。 インストール手順は、 **[.NET ダウンロードページ](https://dotnet.microsoft.com/download)** にあります。 OS に適切な .NET SDK バージョンをインストールする必要があります。 インストールに成功した後、 `dotnet` コマンドは動作し、動作する必要があります。 `dotnet --info` で動作するか確認できます。 .NET SDKがASF **[ランタイム要件](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** と一致することも確認してください。

---

## コンパイル

.NET SDKが動作し、適切なバージョンである場合、ソースのASFディレクトリ(ASFリポジトリのクローンまたはダウンロードおよび解凍)に移動して実行するだけです。

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic"
```

Linux/macOSを使用している場合は、代わりに `cc.sh` スクリプトを使用することができます。

コンパイルが正常に終了した場合は、 `ソースの` フレーバーの `out/generic` ディレクトリにASFがあります。 これは公式の `ジェネリック` ASFビルドと同じです。 しかし、` UpdateChannel ` と `UpdateChannel` と `UpdatePeriod` の `0`を強制しました 自己構築に適しています

### OS 専用

特定の必要性がある場合は、OS 固有の .NET パッケージを生成することもできます。 一般的には、インストール済みの `ジェネリック` フレーバーをコンパイルしたばかりなので、これを行うべきではありません。 最初の場所でコンパイルに使用したETランタイムですが、念のため次のようにします:

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/linux-x64" -r "linux-x64" --self-contained
```

もちろん、 `linux-x64` を、 `win-x64` のように、対象とするOSアーキテクチャに置き換えます。 このビルドではアップデートも無効になります。 When building `--self-contained` you can also optionally declare two more switches: `-p:PublishTrimmed=true` will produce trimmed build, while `-p:PublishSingleFile=true` will produce a single file. 両方を追加すると、独自のビルドで使用する同じ設定になります。

### ASF-ui

上記のステップは、ASFの完全に動作するビルドを持つために必要なすべてです。 *また、* は、 **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**の構築に興味がある可能性があります。 From ASF side, all you need to do is dropping ASF-ui build output in standard `ASF-ui/dist` location, then building ASF with it (again, if needed).

ASF-ui is part of ASF's source tree as a **[git submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, ensure that you've cloned the repo with `git clone --recursive`, as otherwise you'll not have the required files. また、作業中の NPM、 **[Node.js](https://nodejs.org)** が付属しています。 If you're using Linux/macOS, we recommend our `cc.sh` script, which will automatically cover building and shipping ASF-ui (if possible, that is, if you're meeting the requirements we've just mentioned).

In addition to the `cc.sh` script, we also attach the simplified build instructions below, refer to **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** for additional documentation. ASFのソースツリーの場所から、上記のように以下のコマンドを実行します。

```shell
rm -rf "ASF-ui/dist" # ASF-uiは古いビルド

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # ビルド出力が古いファイルのクリーンであることを確認する
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic" # または上記のように必要なものに応じて。
```

これで、 `out/generic/www` フォルダにASF-uiファイルが見つかるはずです。 ASFはそれらのファイルをブラウザに提供することができます。

Alternatively, you can simply build ASF-ui, whether manually or with the help of our repo, then copy the build output over to `${OUT}/www` folder manually, where `${OUT}` is the output folder of ASF that you've specified with `-o` parameter. これはまさにASFがビルドプロセスの一環として行っていることです。 `ASF-ui/dist` (存在する場合) を `${OUT}/www`にコピーします。 何も特別なものではなく、必要に応じてポストビルドも行えます。

---

## 開発

ASFコードを編集したい場合は、任意のものを使用できます。 その目的のためのET互換のIDEは、それでもオプションですが。 メモ帳を使って編集し、上記で説明した `dotnet` コマンドでコンパイルすることもできます。

あなたがより良い選択を持っていない場合。 **[JetBrains Rider](https://www.jetbrains.com/rider)** と **[Visual Studio Code](https://code.visualstudio.com/download)**をお勧めします。 1つ目はASFチームが個人的に使用しているIDE、2つ目は実行可能な代替手段です。 両方のプログラムはクロスプラットフォームであり、Linux、macOSおよびWindowsで利用できます。

---

## タグ

`メイン` ブランチがコンパイルに成功したり、最初の場所で完璧なASF実行を可能にする状態にあることは保証されません。 ` ` リリースサイクル **[に記載されているように開発ブランチなので、](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. ソースからASFをコンパイルまたは参照したい場合。 そのためには、適切な **[タグ](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** を使用する必要があります。 これは少なくともコンパイルが成功することを保証し、(ビルドが安定版リリースとしてマークされている場合)非常にも完璧な実行を保証します。 ツリーの現在の「健全性」を確認するには、CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)** を使用します。

---

## 公式リリース

Official ASF releases are compiled by **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, with latest .NET SDK that matches ASF **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. テストを渡した後、すべてのパッケージはリリースとして、またGitHub上でデプロイされます。 GitHubは常にすべてのビルドに公式のパブリックソースを使用しているため、これは透明性も保証します。 GitHubのアーティファクトのチェックサムとGitHubのリリースアセットを比較できます。 ASFの開発者は、プライベートな開発プロセスとデバッグを除いて、自分自身でビルドをコンパイルまたは公開しません。

上記に加えて、ASFメンテナは、追加のセキュリティ対策として、GitHubのリモートASFサーバーから独立してビルドチェックサムを手動で検証し、公開します。 この手順は、既存のASFがリリースを自動更新機能の有効な候補とみなすために必須です。