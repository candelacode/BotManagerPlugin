# プロセス間通信

ASFには、プロセスとのさらなる相互作用に使用できる独自のIPCインターフェイスが含まれています。 IPC は、 **[プロセス間通信](https://en.wikipedia.org/wiki/Inter-process_communication)** を表し、最もシンプルな定義では、これは、 **[Kestrel HTTP サーバ](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel)** に基づいて、プロセスとさらに統合するために使用することができます。 エンドユーザー(ASF-ui)のフロントエンドとサードパーティ統合(ASF API)のバックエンドの両方。

IPCはあなたのニーズやスキルに応じて、多くの異なるものに使用することができます。 たとえば、ASFとすべてのボットのステータスの取得、ASFコマンドの送信、グローバル/ボットの設定の取得と編集などに使用できます。 新しいボットを追加したり、既存のボットを削除したり、 **[BFR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** キーを送信したり、ASFのログファイルにアクセスしたりします。 これらのアクションはすべてAPIによって公開されます。 つまり、実行時にASFと通信し、影響を与える独自のツールやスクリプトをコーディングすることができます。 それに加えて 選択されたアクション(コマンド送信など)は、フレンドリーなWebインターフェイスを介して簡単にアクセスすることができます当社のASF-uiによっても実装されています。

---

# 使用法

`IPC` **[グローバル設定プロパティ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**を使用して手動でIPCを無効にしない限り、デフォルトで有効になります。 ASFはIPCの起動をログに記録し、IPCインターフェイスが正しく起動したかどうかを確認するために使用できます。

```text
INFO|ASF|Start() IPCサーバーを起動...
INFO|ASF|Start() IPCサーバーの準備ができました!
```

ASFのhttpサーバーが選択されたエンドポイントでリッスンしています。 If you didn't provide a custom configuration file for IPC, it'll be `localhost`, both IPv4-based **[127.0.0.1](http://127.0.0.1:1242)** and IPv6-based **[[::1]](http://[::1]:1242)** on default `1242` port. 上記のリンクからIPCインターフェースにアクセスできますが、ASFプロセスを実行しているものと同じマシンからのみアクセスできます。

ASFのIPCインターフェイスは、予定されている使用方法に応じて、3つの異なる方法でアクセスできます。

最低レベルには、当社のIPCインターフェイスの中核である **[ASF API](#asf-api)** があり、他のすべての機能を可能にします。 ASFと直接コミュニケーションを取るために、独自のツール、ユーティリティ、プロジェクトで使用したいものです。

媒体には、ASF APIのフロントエンドとして機能する **[Swagger documentation](#swagger-documentation)** があります。 ASF APIの完全なドキュメントを備えており、より簡単にアクセスできます。 これは、ツールを作成することを計画しているかどうかを確認するものです。 APIを通じてASFと通信するはずのユーティリティまたはその他のプロジェクト。

最高レベルには、当社のASFAPIに基づいており、さまざまなASFアクションを実行するためのユーザーフレンドリーな方法を提供する **[ASF-ui](#asf-ui)** があります。 これはエンドユーザー向けに設計された当社のデフォルトのIPCインターフェースであり、ASF APIを使用して構築できるものの完璧な例です。 ご希望の場合は、独自のカスタム Web UI を使用してASFで使用できます。 `--path` **[コマンドライン引数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** を指定し、そこにあるカスタム `www` ディレクトリを使用します。

---

# ASF-ui

ASF-uiは、エンドユーザーのためのユーザーフレンドリーなグラフィカルWebインターフェースを作成することを目的としたコミュニティプロジェクトです。 そのために、 **[ASF API](#asf-api)**のフロントエンドとして機能します。 様々な行動を容易にすることができます これはASFに付属するデフォルトのUIです。

前述のように、ASF-uiはコアASF開発者によって維持されていないコミュニティプロジェクトです。 **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** の独自のフローに従い、すべての関連する質問、問題、バグレポート、提案に使用します。

ASF-uiはASFプロセスの一般的な管理に使用できます。 例えば、ボットを管理したり、設定を変更したり、コマンドを送信したり、ASFで通常利用可能な他の機能を選択したりすることができます。

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

当社のASFAPIは典型的な **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** ウェブAPIで、JSONを主要データ形式として使用します。 HTTPステータスコード(適切な場合)を使用して、レスポンスを正確に記述するために最善を尽くしています。 答えと同様に自分自身を解析することができます 要求が成功したかどうかを知るために そしてそうでなかった場合 その理由を。

当社のASF APIは、適切な `/Api` エンドポイントに適切なリクエストを送信することでアクセスできます。 これらのAPIエンドポイントを使用して、独自のヘルパースクリプト、ツール、GUIなどを作成できます。 これはまさに、当社のASF-UIが実現したものであり、他のすべてのツールも同じことができます。 ASF APIは、コアASFチームによって公式にサポートされ、維持されています。

利用可能なエンドポイント、説明、要求、応答、httpステータスコード、およびASF APIを考慮したその他すべてのドキュメントについて。 **[威張ったドキュメント](#swagger-documentation)** を参照してください。

![ASF API](https://github.com/user-attachments/assets/08c3d4ad-ea77-403d-a18a-b75c3d0a3097)


---

# カスタム構成

私たちのIPCインターフェイスは、追加の設定ファイル、 `IPC.config` をサポートしており、標準のASFの `config` ディレクトリに配置する必要があります。

利用可能な場合、このファイルは、ASFの Kestrel http サーバの高度な設定と、その他の IPC 関連のチューニングを指定します。 特定の必要性がない限り、このファイルを使用する理由はありません。 ASFはすでに賢明なデフォルトを使用しているため。

構成ファイルは以下の JSON 構造に基づいています:

```json
{
    "Kestrel": {
        "Endpoints": {
            "example-http4": {
                "Url": "http://127.0.0.1:1242"
            },
            "example-http6": {
                "Url": "http://[::1]:1242"
            },
            "example-https4": {
                "Url": "https://127.0.0.1:1242",
                "Certificate": {
                    "Path": "/path/to/certificate.pfx",
                    "Password": "passwordToPfxFileAbove"
                }
            },
            "example-https6": {
                "Url": "https://[::1]:1242",
                "Certificate": {
                    "Path": "/path/to/certificate.pfx",
                    "Password": "passwordToPfxFileAbove"
                }
            }
        },
        "KnownNetworks": [
            "10.0.0.0/8",
            "172.16.0.0/12",
            "192.168.0.0/16"
        ],
        "PathBase": "/"
    }
}
```

`Endpoints` - This is a collection of endpoints, each endpoint having its own unique name (like `example-http4`) and `Url` property that specifies `Protocol://Host:Port` listening address. デフォルトでは、ASFはIPv4とIPv6のhttpアドレスをリッスンしますが、必要に応じてhttpsの例を追加しています。 必要なエンドポイントのみを宣言する必要があります。上記に4つの例を含めることで、より簡単に編集できます。

`Host` accepts either `localhost`, a fixed IP address of the interface it should listen on (IPv4/IPv6), or `*` value that binds ASF's http server to all available interfaces. Using other values like `mydomain.com` or `192.168.0.*` acts the same as `*`, there is no IP filtering implemented, therefore be extremely careful when you use `Host` values that allow remote access. そうすることで、ASFのIPCインターフェイスに他のマシンからアクセスできるようになり、セキュリティ上のリスクが生じる可能性があります。 この場合は、 `IPCPassword` (および好ましくは独自のファイアウォールも) **を最低でも** で使用することを強くお勧めします。

`KnownNetworks` - This **optional** variable specifies network addresses which we consider trustworthy. デフォルトでは、ASFはループバックインターフェイス(`localhost`、同じマシン) **のみ** を信頼するように設定されています。 このプロパティは二つの方法で使用されています。 まず、 `IPCPassword`を省略した場合 次に、既知のネットワークからのマシンのみASFのAPIにアクセスし、セキュリティ対策として他のすべてのマシンを拒否することを許可します。 第二に、このプロパティは、ASFにアクセスする逆プロキシに関して重要です。 ASFは、リバースプロキシサーバーが既知のネットワーク内からの場合にのみ、そのヘッダを尊重します。 問題が発生した場合にリバースプロキシを禁止するのではなく、ASFのアンチブルートフォースメカニズムに関してヘッダを尊重することは非常に重要です。 リバースプロキシで指定されたIPが元のメッセージのソースとして禁止されます。 ここで指定したネットワークには非常に注意してください 信頼されたマシンが侵害されたり誤って設定された場合に備えて、潜在的なIPスプーフィング攻撃と不正アクセスを可能にします。

`PathBase` - IPCインターフェイスで使用される **オプションの** ベースパスです。 デフォルトは `/` であり、大部分のユースケースを変更する必要はありません。 このプロパティを変更すると、 `http://localhost:1242/MyPrefix` の代わりに `http://localhost:1242` のように、IPCインターフェイス全体をカスタムプレフィックスでホストできます。 Using custom `PathBase` may be wanted in combination with specific setup of a reverse proxy where you'd like to proxy a specific URL only, for example `mydomain.com/ASF` instead of entire `mydomain.com` domain. Normally that would require from you to write a rewrite rule for your web server that would map `mydomain.com/ASF/Api/X` -> `localhost:1242/Api/X`, but instead you can define a custom `PathBase` of `/ASF` and achieve easier setup of `mydomain.com/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

本当にカスタムベースパスを指定する必要がない限り、デフォルトのままにするのが最善です。

## 設定の例

### 既定のポートを変更する

以下の設定は、デフォルトのASFリスニングポートを `1242` から `1337` に変更するだけです。 You can pick any port you like, but we recommend `1024-32767` range, as other ports are typically **[registered](https://en.wikipedia.org/wiki/Registered_port)**, and may for example require `root` access on Linux.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP4": {
                "Url": "http://127.0.0.1:1337"
            },
            "HTTP6": {
                "Url": "http://[::1]:1337"
            }
        }
    }
}
```

---

### すべてのIPからのアクセスを有効にする

以下の設定はすべてのソースからリモートアクセスを許可します したがって、上記利用可能な **についての当社のセキュリティ通知を読んで理解していただくことを**確認してください。

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

If you do not require access from all sources, but for example your LAN only, then it's much better idea to check local IP address of the machine hosting ASF, for example `192.168.0.10` and use it instead of `*` in example config above. 残念ながら、LAN アドレスが常に同じ場合にのみ可能です。 そうでなければ、おそらく `*` と、ローカルサブネットのみがASFのポートにアクセスできるようにする上に独自のファイアウォールでより満足のいく結果が得られるでしょう。

---

# 認証

`IPCPassword` が `null` に設定されているため、デフォルトでは、ASF IPCインターフェイスは一切の種類の認証を必要としません。 However, if `IPCPassword` is enabled by being set to any non-empty value, every call to ASF's API requires the password that matches set `IPCPassword`. 認証または間違ったパスワードを省略すると、 `401 - Unauthorized` エラーが発生します。 5回の認証に失敗した後(パスワードが間違っています)、 `403 - 禁止された` エラーで一時的にブロックされます。

認証は二つの方法で行うことができます。

## `認証` ヘッダー

一般的には、 **[HTTPリクエストヘッダ](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)**を使用する必要があります。 `認証` フィールドを値として設定します。 その方法は、ASFのIPCインターフェイスにアクセスするために使用している実際のツールによって異なります。 例えば、 `curl` を使用している場合は、パラメータとして `-H 'Authentication: MyPassword'` を追加する必要があります。 このようにして認証はリクエストのヘッダで渡されます。ここでは実際に行われるべきです。

## クエリ文字列の `パスワード` パラメータ

Alternatively you can append `password` parameter to the end of the URL you're about to call, for example by calling `/Api/ASF?password=MyPassword` instead of `/Api/ASF` alone. このアプローチは十分に良いですが、明らかにオープンでパスワードを公開します。これは必ずしも適切ではありません。 それに加えて、クエリ文字列の余分な引数です。 これはURLの外観を複雑にし、URL固有のように感じさせますが、パスワードはASF API通信全体に適用されます。

---

どちらの方法でもサポートされており、どちらを選ぶかはあなた次第です。 どこでもHTTPヘッダーを使用することをお勧めします。使用方法はクエリ文字列よりも適切です。 ただし、リクエストヘッダに関連するさまざまな制限により、クエリ文字列もサポートしています。 良い例として、javascript でウェブソケット接続を開始する際に、カスタムヘッダーの不足が挙げられます (RFC によると完全に有効ですが)。 この状況では、クエリ文字列が認証する唯一の方法です。

---

# Swagger ドキュメント

当社のIPCインターフェイスには、ASF-APIとASF-uiに加えて、威張った文書も含まれています。 これは、 `/swagger` **[URL](http://localhost:1242/swagger)** の下で利用できます。 Swaggerドキュメントは、API実装と他のツール(ASF-uiなど)の中間者として機能します。 **[OpenAPI](https://swagger.io/resources/open-api)** 仕様におけるすべての API エンドポイントの完全なドキュメントと可用性を提供し、他のプロジェクトで簡単に使用できます。 ASF APIの書き込みとテストを簡単に行えます。

ASF APIの完全な仕様として当社のSwaggerドキュメントを使用することとは別に。 ASF-uiで実装されていないものを中心に、さまざまなAPIエンドポイントを実行するユーザーフレンドリーな方法としても使用できます。 SwaggerのドキュメントはASFコードから自動的に生成されます。 ASFのバージョンが含まれているAPIエンドポイントでドキュメントが常に最新の状態になることを保証します。

![Swagger ドキュメント](https://github.com/user-attachments/assets/ce998e08-f5db-46b0-a9e8-e6b69abd94bb)


---

# よくある質問

### ASFのIPCインターフェイスは安全で安全ですか?

ASF by default listens only on `localhost` addresses, which means that accessing ASF IPC from any other machine but your own **is impossible**. デフォルトのエンドポイントを変更しない限り、ASFのIPCにアクセスするには、攻撃者は自分のマシンに直接アクセスする必要があります。 だから安全で他に誰もアクセスできない 自分のLANからでも

However, if you decide to change default `localhost` bind addresses to something else, then you're supposed to set proper firewall rules **yourself** in order to allow only authorized IPs to access ASF's IPC interface. それに加えて、 `IPCPassword`を設定する必要があります。 ASFは、他のマシンがASF APIにアクセスしないようにすることを拒否するため、別のセキュリティ層が追加されます。 この場合、ASFのIPCインターフェースをリバースプロキシの後ろで実行することもできます。

### 自分のツールやユーザースクリプトを使ってASF APIにアクセスできますか?

これは、ASF APIが設計されたものであり、アクセスするためにHTTPリクエストを送信できるものは何でも使用できます。 Local userscripts follow **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** logic, and we allow access from all origins for them (`*`), as long as `IPCPassword` is set, as an extra security measure. これにより、さまざまな認証済みの ASF API リクエストを実行できます。 潜在的に悪意のあるスクリプトを自動的に実行させることはありません( `IPCPassword` を知る必要があります)。

### ASFのIPCにリモートでアクセスすることはできますか?

はい、リバースプロキシを使用することをお勧めします。 これにより、典型的な方法でWebサーバーにアクセスし、同じマシン上のASFのIPCにアクセスします。 あるいは、リバースプロキシで実行したくない場合は、適切な URL を指定して **[カスタム設定](#enabling-access-from-all-ips)** を使用できます。 For example, if your machine is in a VPN with `10.8.0.1` address, then you can set `http://10.8.0.1:1242` listening URL in IPC config, which would enable IPC access from within your private VPN, but not from anywhere else.

### Apache や Nginx などのリバースプロキシの背後に ASF の IPC を使用できますか?

**はい**, 当社のIPCは、このような設定と完全に互換性があります. セキュリティと互換性を確保するために自分のツールの前でも自由にホストできる 一般的に、ASFのKestrel httpサーバーは非常に安全であり、インターネットに直接接続されてもリスクはありません。 しかし、Apache や Nginx などのリバースプロキシの背後に置くと、それ以外の場合は不可能な追加機能を提供することができます。 例えば、ASFのインターフェイスを **[ベーシック認証](https://en.wikipedia.org/wiki/Basic_access_authentication)** で保護するなど。

例 Nginx 構成は以下にあります。 主に `ロケーション` の `ロケーション` ブロックに興味がありますが、完全なAformat@@4サーバーAformat@@5ブロックが含まれています。 詳細については、 **[nginx ドキュメント](https://nginx.org/en/docs)** を参照してください。

```nginx
server {
    listen *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /path/to/your/fullchain.pem;
    ssl_certificate_key /path/to/your/privkey.pem;

    location ~* /Api/NLog {
        proxy_pass http://127.0.0.1:1242;

        # Only if you need to override default host
#       proxy_set_header Host 127.0.0.1;

        # X-headers should always be specified when proxying requests to ASF
        # They're crucial for proper identification of original IP, allowing ASF to e.g. ban the actual offenders instead of your nginx server
        # Specifying them allows ASF to properly resolve IP addresses of users making requests - making nginx work as a reverse proxy
        # Not specifying them will cause ASF to treat your nginx as the client - nginx will act as a traditional proxy in this case
        # If you're unable to host nginx service on the same machine as ASF, you most likely want to set KnownNetworks appropriately in addition to those
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;

        # We add those 3 extra options for websockets proxying, see https://nginx.org/en/docs/http/websocket.html
        proxy_http_version 1.1;
        proxy_set_header Connection "Upgrade";
        proxy_set_header Upgrade $http_upgrade;
    }

    location / {
        proxy_pass http://127.0.0.1:1242;

        # Only if you need to override default host
#       proxy_set_header Host 127.0.0.1;

        # X-headers should always be specified when proxying requests to ASF
        # They're crucial for proper identification of original IP, allowing ASF to e.g. ban the actual offenders instead of your nginx server
        # Specifying them allows ASF to properly resolve IP addresses of users making requests - making nginx work as a reverse proxy
        # Not specifying them will cause ASF to treat your nginx as the client - nginx will act as a traditional proxy in this case
        # If you're unable to host nginx service on the same machine as ASF, you most likely want to set KnownNetworks appropriately in addition to those
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
    }
}
```

Apache の設定例 以下に示します。 詳細については、 **[apache ドキュメント](https://httpd.apache.org/docs)** を参照してください。

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerName asf.mydomain.com

        SSLEngine On
        SSLCertificateFile /path/to/your/fullchain.pem
        SSLCertificateKeyFile /path/to/your/privkey.pem

        # TODO: Apache can't do case-insensitive matching properly, so we hardcode two most commonly used cases
        ProxyPass "/api/nlog" "ws://127.0.0.1:1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0.1:1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### HTTPS プロトコル経由で IPC インターフェイスにアクセスできますか?

**はい**, あなたは二つの異なる方法でそれを達成することができます. 推奨される方法は、通常のような https を介してあなたのウェブサーバーにアクセスできるそのためのリバースプロキシを使用することです。 同じマシンのASFのIPCインターフェースで接続します。 この方法でトラフィックは完全に暗号化され、IPCをそのような設定をサポートするために変更する必要はありません。

2つ目の方法は、ASFのIPCインターフェイスに **[カスタムconfig](#custom-configuration)** を指定することです。ここでは、httpsエンドポイントを有効にし、Kestrelのhttpサーバーに直接適切な証明書を提供することができます。 この方法は、他のWebサーバーを実行しておらず、ASF専用に実行したくない場合に推奨されます。 そうでなければ、リバースプロキシメカニズムを使用して満足のいくセットアップを達成する方がはるかに簡単です。

---

### During startup of IPC I'm getting an error: `System.IO.IOException: Failed to bind to address, An attempt was made to access a socket in a way forbidden by its access permissions`

このエラーは、マシン上の何かが既にそのポートを使用しているか、将来の使用のために予約されていることを示します。 これは、同じマシン上で2番目のASFインスタンスを実行しようとしている場合に使用できます。 しかし、ほとんどの場合、それは使用状況からポート `1242` を除くWindowsであるため、ASFを別のポートに移動する必要があります。 In order to do that, follow **[example config](#changing-default-port)** above, and simply try to pick another port, such as `12420`.

もちろん、ASFの使用からポート `1242` をブロックしているものを調べて、それを削除することもできます。 しかし、それは通常、ASFに別のポートを使うように指示するよりもはるかに厄介ですので、ここでは詳しく説明します。

---

### Why am I getting `403 Forbidden` error when not using `IPCPassword`?

ASF includes additional security measure that, by default, allows only loopback interface (`localhost`, your own machine) to access ASF API without `IPCPassword` set in the config. これは、 `IPCPassword` を使用する場合、ASFインターフェイスをさらに公開することを決定したすべての人によって設定された **最小** セキュリティ対策にする必要があるためです。

この変更は、無意識のユーザーによって世界中でホストされている大量のASFが悪意のある意図に引き継がれているという事実によって決定されました。 普通は口座もアイテムもないまま放置されるんだ 今、私たちは「世界にASFを開く前に、彼らはこのページを読むことができます」と言うことができます。 しかし、代わりに、デフォルトで安全でないASF設定を禁止する方が理にかなっています。 ユーザーが明示的に許可したい場合は、以下で説明します。

In particular, you're able to override our decision by specifying the networks which you trust to reach ASF without `IPCPassword` specified, you can set those in `KnownNetworks` property in custom config. However, unless you **really** know what you're doing and fully understand the risks, you should instead use `IPCPassword` as declaring `KnownNetworks` will allow everybody from those networks to access ASF API unconditionally. 私たちは真面目で、人々はすでに自分の逆プロキシと iptables ルールは安全であると信じて足元で自分自身を撃っていました, しかし、彼らはそうではありませんでした. `IPCPassword` が最初で、時には最後の守護者です。 このシンプルでしかも非常に効果的で安全なメカニズムを拒否するなら 自分のせいにするしかない