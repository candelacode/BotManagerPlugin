# 管理

このセクションでは、ASFプロセスの最適な管理に関連する科目について説明します。 使用には厳密に必須ではありませんが、私たちが共有したいヒント、トリック、グッドプラクティスがたくさん含まれています。 特にシステム管理者の場合は、サードパーティのリポジトリや上級ユーザーなどで使用するためにASFをパッケージ化しています。

---

## `systemd` サービス for Linux

In `generic` and `linux` variants, ASF comes with `ArchiSteamFarm@.service` file, which is a configuration file of the service for **[`systemd`](https://systemd.io)**. If you'd like to run ASF as a service, for example in order to launch it automatically after startup of your machine, then a proper `systemd` service is arguably the best way to do it, therefore we highly recommend it instead of managing it on your own through `nohup`, `screen` or alike.

まず、ASFを実行したいユーザーのアカウントを作成します。 We'll use `asf` user for this example, if you decided to use a different one, you'll need to substitute `asf` user in all of our examples below with your selected one. 当社のサービスでは、 `` **[悪い練習](#never-run-asf-as-administrator)** と見なされるため、ASFをルート

 として実行することはできません。</p> 



```sh
su # または sudo -i, root shell
useradd -m asf # ASFを実行するアカウントを作成する
```


次に、ASFを `/home/asf/ArchiSteamFarm` フォルダに解凍します。 The folder structure is important for our service unit, it should be `ArchiSteamFarm` folder in your `$HOME`, so `/home/<user>`. すべてを正しく行った場合、 `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service` ファイルが存在します。 If you're using `linux` variant and didn't unpack the file on Linux, but for example used file transfer from Windows, then you'll also need to `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

`ルート`として以下のすべてのアクションを行いますので、 `su` または `sudo -i` を使用してシェルに移動します。

Firstly it's a good idea to ensure that our folder still belongs to our `asf` user, `chown -hR asf:asf /home/asf/ArchiSteamFarm` executed once will do it. パーミッションが間違っている可能性があります。例えば、zipファイルを `ルート`としてダウンロードおよび/または解凍している場合。

Secondly, if you're using generic variant of ASF, you need to ensure `dotnet` command is recognized and within one of the standard locations: `/usr/local/bin`, `/usr/bin` or `/bin`. これは、 `dotnet /path/to/ArchiSteamFarm.dll` コマンドを実行する systemd サービスに必要です。 `dotnet --info` があなたのために動作するかどうかを確認します。はいの場合は、 `コマンド -v dotnet` と入力して、その場所を確認します。 公式インストーラを使用している場合は、 `/usr/bin/dotnet` か、他の2つの場所のいずれかにある必要があります。 If it's in custom location such as `/usr/share/dotnet/dotnet`, create a **[symlink](https://wikipedia.org/wiki/Symbolic_link)** for it using `ln -s "$(command -v dotnet)" /usr/bin/dotnet`. `コマンド -v dotnet` は `/usr/bin/dotnet`を報告する必要があります。これにより、systemd ユニットも動作します。 OS 固有のバリアントを使用している場合は、この点に関して何もしる必要はありません。

Next, execute `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/systemd/system/ArchiSteamFarm\@.service`, this will create a symbolic link to our service declaration and register it in `systemd`. Symbolic link will allow ASF to update your `systemd` unit automatically as part of ASF update - depending on your situation, you may want to use that approach, or simply `cp` the file and manage it yourself however you'd like.

その後、 `systemd` が当社のサービスを認識していることを確認します。



```
systemctl status ArchiSteamFarm@asf

○ ArchiSteamFarm@asf.service - ArchiSteamFarm Service (on asf)
     Loaded: loaded (/etc/systemd/system/ArchiSteamFarm@.service; disabled; vendor preset: enabled)
     Active: inactive (dead)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```


`@`の後に宣言するユーザーには特別な注意を払ってください。この場合は `asf` です。 当社の systemd サービスユニットは、ユーザーがユーザーを宣言することを期待しています。 バイナリ `/home/<user>/ArchiSteamFarm`の正確な場所に影響を与えます。 実際のユーザシステムと同様にプロセスが生成されます。

systemd が上記のように出力を返した場合、すべてが順番になっており、ほぼ完了しています。 今、残っているすべては、実際に私たちの選択したユーザーとして私たちのサービスを開始しています: `systemctl start ArchiSteamFarm@asf`. 2、3秒待ってから、もう一度ステータスを確認できます。



```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarmサービス(現時点で)
     Loaded: loaded (/etc/system/system/ArchiSteamFarm@.service; disabled; ベンダープリセット: enabled)
     Active: active (running) since (...)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   Main PID: (...)
(...)
```


If `systemd` states `active (running)`, it means everything went well, and you can verify that ASF process should be up and running, for example with `journalctl -r`, as ASF by default also writes to its console output, which is recorded by `systemd`. If you're satisfied with the setup you have right now, you can tell `systemd` to automatically start your service during boot, by executing `systemctl enable ArchiSteamFarm@asf` command. それだけです

プロセスを停止したい場合は、 `systemctl stop ArchiSteamFarm@asf` を実行してください。 同様に、起動時にASFが自動的に起動されることを無効にしたい場合も同様です。 `systemctl disable ArchiSteamFarm@asf` はあなたのためにそれを行います, それは非常に簡単です.

`systemd` サービスの標準入力が有効になっていないため、ご注意ください。 通常の方法でコンソールから詳細を入力することはできません `systemd` を実行することは、 **[`ヘッドレス: true`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** の設定を指定することと同等であり、そのすべての意味が含まれます。 幸いなことに、 **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**を介してASFを管理することは非常に簡単です。 ログイン中に追加の情報を提供する必要がある場合や、ASFプロセスをさらに管理する必要がある場合には、お勧めします。



### 環境変数

It's possible to supply additional environment variables to our `systemd` service, which you'll be interested in doing in case you want to for example use a custom `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**, therefore specifying `ASF_CRYPTKEY` environment variable.

カスタム環境変数を提供するには、 `/etc/asf` フォルダを作成します (存在しない場合)、 `mkdir -p /etc/asf`。 We recommend to `chown -hR root:root /etc/asf && chmod 700 /etc/asf` to ensure that only `root` user has access to read those files, because they might contain sensitive properties such as `ASF_CRYPTKEY`. Afterwards, write to a `/etc/asf/<user>` file, where `<user>` is the user you're running the service under (`asf` in our example above, so `/etc/asf/asf`).

ファイルには、プロセスに提供したいすべての環境変数を含める必要があります。 専用の環境変数を持たないものは、 `ASF_ARGS` で宣言できます:



```sh
# 実際に
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# そしてあなたが興味を持っている他のどんなもの
```




### サービスユニットの一部を上書きする

`systemd`の柔軟性により、 元のユニットファイルを保持しながら、ASFユニットの一部を上書きし、自動更新の一部としてASFを更新することができます。

この例では、デフォルトの ASF `systemd` ユニットの動作を成功時のみ再起動しないように修正し、致命的なクラッシュ時にも再起動したいと考えています。 そのために `` プロパティの `[Service]` を、既定の `on-success` から `常に` に上書きします。 `systemctl edit ArchiSteamFarm@asf`を実行するだけで、 `asf` をサービスの対象ユーザーに置き換えることができます。 次に、適切なセクションで `systemd` によって示されるように変更を追加します。



```sh
### Editing /etc/systemd/system/ArchiSteamFarm@asf.service.d/override.conf
### Anything between here and the comment below will become the new contents of the file

[Service]
Restart=always

### Lines below this comment will be discarded

### /etc/systemd/system/ArchiSteamFarm@asf.service
# [Install]
# WantedBy=multi-user.target
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm.dll --no-restart --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# User=%i
# (...)
```


`` `[Service]` の下で、Aformat@@5 Restart=always [Service] を持っているかのように、ユニットは同じ動作をします。

Of course, alternative is to `cp` the file and manage it yourself, but this allows you for flexible changes even if you decided to keep original ASF unit, for example with a **[symlink](https://wikipedia.org/wiki/Symbolic_link)**.



---



## 管理者としてASFを実行しないでください！

ASFには、プロセスが管理者 (`ルート`) として実行されているかどうか独自の検証が含まれています。 Running as `root` is **not** required for any kind of operation done by the ASF process, assuming properly configured environment it's operating in, and therefore should be regarded as a **bad practice**. This means that on Windows, ASF should **never** be executed with "run as administrator" setting, and on Unix ASF should have a **dedicated user account** for itself, or re-use your own in case of a desktop system.

For further elaboration on *why* we discourage running ASF as `root`, refer to **[superuser](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** and other resources. まだ納得していないなら ASFプロセスが起動直後に `rm -rf /*` コマンドを実行した場合、マシンに何が起こるかを自問してください。



### ASFがファイルに書き込むことができないため、 `root` として実行します

これは、ASFがアクセスしようとしているファイルの権限が誤って設定されていることを意味します。 You should login as `root` account (either with `su` or `sudo -i`) and then **correct** the permissions by issuing `chown -hR asf:asf /path/to/ASF` command, substituting `asf:asf` with the user that you'll run ASF under, and `/path/to/ASF` accordingly. カスタム `--path` を使用している場合は、ASF ユーザーに別のディレクトリを使用するように指示します。 同じコマンドをもう一度実行するべきです

その後、独自のファイルを書き込むことができないASFに関連するいかなる問題も発生しないはずです。 ASFがユーザーに興味を持っているすべての所有者を変更したばかりの場合、ASFプロセスは実際に実行されます。



### `ルート` として実行します。それ以外の場合はそれを行う方法がわからないので。



```sh
su # or sudo -i root シェルに入るには
useradd -m asf #
chown -hR asf:asf /path/to/ASF # 新しいユーザーがASFディレクトリにアクセスできることを確認する
su asf -c /path/to/ASF/ArchiSteamファーム # sudo -u asf /path/to/ASF/ArchiSteamFarm, 実際にあなたのユーザーの下でプログラムを始めることができます
```


それは手動で行うことになりますが、上記で説明した **[`systemd` サービス](#systemd-service-for-linux)** を使用する方がはるかに簡単です。



### `ルート` として実行したいです。

ASFは強制的にあなたがそうすることを止めるわけではありません、短い通知で警告が表示されるだけです。 プログラムのバグが原因である場合にショックを受けないでください。完全なデータ損失でOS全体が爆発します。あなたは警告されました。



---



## 複数のインスタンス

ASFは、同じマシン上で複数のプロセスインスタンスを実行することと互換性があります。 インスタンスは完全にスタンドアロンであるか、同じバイナリの場所から派生することができます (その場合は、この場合)。 異なる `--path` **[コマンドライン引数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** で実行します。

同じバイナリから複数のインスタンスを実行する場合、通常はすべての設定で自動更新を無効にする必要があることに注意してください。 自動更新に関しては同期が行われていないからです 自動更新を有効にしたい場合は、スタンドアロンインスタンスをお勧めします。 しかし、他のすべてのASFインスタンスが閉じられていることを確認できる限り、更新は機能します。

ASFは、OS全体で他のASFインスタンスとのクロスプロセス通信を最小限に抑えるために最善を尽くします。 これには、ASFの設定ディレクトリを他のインスタンスに対してチェックすることが含まれます。 `*LimiterDelay` **[グローバル設定プロパティ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**で設定されたコアプロセス全体のリミッターを共有する 複数のASFインスタンスを実行してもレート制限の問題が発生しないことを保証します。 技術的側面に関しては、すべてのプラットフォームが一時ディレクトリに作成されたカスタムASFファイルベースのロックの専用メカニズムを使用します。 は、Windowsでは `C:\Users\<YourUser>\AppData\Local\Temp\ASF` 、Unix では `/tmp/ASF` です。

同じ `*LimiterDelay` プロパティを共有するために ASF インスタンスを実行する必要はありません。 各ASFはロックを取得した後にリリース時間に独自に設定された遅延を追加するため、異なる値を使用できます。 設定された `*LimiterDelay` が `0`に設定されている場合 ASFインスタンスは、他のインスタンスと共有される特定のリソースのロックを完全にスキップします(つまり、お互いに共有されたロックを維持する可能性があります)。 他の値に設定すると、ASFは他のASFインスタンスと正しく同期し、順番を待機します 次に、他のインスタンスを継続できるように、遅延設定後にロックを解除します。

ASF takes into account `WebProxy` setting when deciding about shared scope, which means that two ASF instances using different `WebProxy` configurations will not share their limiters with each other. これは、異なるネットワークインターフェイスから期待されるように、 `WebProxy` の過度の遅延なしに動作するようにするために実装されています。 これは、大部分のユースケースで十分に良いはずですが、例えば、特定のカスタムセットアップがある場合など。 ルーティングは自分自身を別の方法で要求します `--network-group` **[コマンドライン引数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**を使用してネットワークグループを指定できます。 このインスタンスと同期するASFグループを宣言することができます。 カスタムネットワークグループは排他的に使用されていることに注意してください。 つまり、ASFは `WebProxy` を使用して正しいグループを決定することはできなくなります。 この場合のグループ化を担当しています

If you'd like to utilize our **[`systemd` service](#systemd-service-for-linux)** explained above for multiple ASF instances, it's very simple, just use another user for our `ArchiSteamFarm@` service declaration and follow with the rest of the steps. これは、複数の ASF インスタンスを別々のバイナリで実行するのと同等なので、自動的に更新して動作させることもできます。