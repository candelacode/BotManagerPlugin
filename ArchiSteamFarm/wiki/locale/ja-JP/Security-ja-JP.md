# セキュリティ

## 暗号化

ASF currently supports the following encryption methods as a definition of `ECryptoMethod`:

| 値 | 名前                           |
| - | ---------------------------- |
| 0 | プレーンテキスト                     |
| 1 | AES                          |
| 2 | ProtectedDataFortCurrentUser |
| 3 | EnvironmentVariable          |
| 4 | ファイル                         |

それらの正確な説明と比較は以下で入手できます。

### セットアップ

暗号化されたパスワードを生成するため、例えば、 `SteamPassword` 使用時。 ` 暗号化format@@1 <code>` **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** を、選択した適切な暗号化と元のプレーンテキストパスワードで実行する必要があります。 Afterwards, put the encrypted string that you've got as `SteamPassword` bot config property, and finally change `PasswordFormat` to the one that matches your chosen encryption method. `encrypt` コマンドを必要としないフォーマットがあります。例えば、 `EnvironmentVariable` または `File`のように、適切なパスを指定します。

---

### `プレーンテキスト`

これは、 `0` の `ECryptoMethod` として定義されたパスワードを格納する最もシンプルで安全でない方法です。 ASFは、文字列がプレーンテキストであることを期待しています - パスワードは直接形式です。 これは最も使いやすく、すべてのセットアップと100%互換性があります。 秘密を保管する標準的な方法です安全に保管するには まったく安全ではありません

---

### `AES`

今日の基準で安全とみなされています **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** パスワードを格納する方法は、 `` `1` の ECryptoMethod </code> として定義されている。 ASF expects the string to be a **[base64-encoded](https://en.wikipedia.org/wiki/Base64)** sequence of characters resulting in AES-encrypted byte array after translation, which then should be decrypted using included **[initialization vector](https://en.wikipedia.org/wiki/Initialization_vector)** and ASF encryption key.

上記の方法は、攻撃者が復号とパスワードの暗号化に使用されているASF暗号化キーを知らない限り、セキュリティを保証します。 ASFでは、 `--cryptkey` **[コマンドライン引数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**を介してキーを指定できます。これは最大限のセキュリティのために使用すべきです。 If you decide to omit it, ASF will use its own key which is **known** and hardcoded into the application, meaning anybody can reverse the ASF encryption and get decrypted password. それはまだいくらかの努力を必要とし、それほど簡単ではないが、可能です。 そのため、ほとんどの場合、秘密に保たれている `AES` 暗号化を `--cryptkey` で行う必要があります。 AES method used in ASF provides security that should be satisfying and it's a balance between simplicity of `PlainText` and complexity of `ProtectedDataForCurrentUser`, but it's highly recommended to use it with custom `--cryptkey`.

適切に使用されている場合 (長い、カスタム `--cryptkey`), 安全なストレージのための非常に高いセキュリティを保証します。

---

### `ProtectedDataFortCurrentUser`

今日の基準で安全とみなされています **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** パスワードを格納する方法は、 `ECryptoMethod` `2` として定義されています。 The major advantage of this method is at the same time the major disadvantage - instead of using encryption key (like in `AES`), data is encrypted using login credentials of currently logged in user, which means that it's possible to decrypt the data **only** on the machine it was encrypted on, and in addition to that, **only** by the user who issued the encryption.

This ensures that even if you send your entire `Bot.json` with encrypted `SteamPassword` using this method to somebody else, they will not be able to decrypt the password without direct access to your PC. This is excellent security measure, but at the same time has a major disadvantage of being least compatible, as the password encrypted using this method will be incompatible with any other user as well as machine - including **your own** if you decide to e.g. reinstall your operating system. 自分以外のマシンから設定にアクセスする必要がない場合は、これは推奨される方法です。 クロスマシンの互換性も必要としません

**このオプションは、現時点で Windows OS を実行しているマシンでのみ使用できます。**

---

### `EnvironmentVariable`

`3` の `ECryptoMethod` として定義されたメモリベースのストレージ。 ASFは、パスワードフィールドに指定された名前を持つ環境変数からパスワードを読み込みます(例: `SteamPassword`)。 例えば、 `SteamPassword` を `ASF_PASSWORD_MYACCOUNT` と `PasswordFormat` を `3` に設定すると、ASF は `${ASF_PASSWORD_MYACCOUNT}` 環境変数を評価し、アカウントパスワードとして割り当てられたものを使用します。

ASFプロセスの環境変数に権限のないユーザーがアクセスできないことを確認してください。 この方法を使う目的を全て打ち負かすことになります

---

### `ファイル`

`4` の `ECryptoMethod` として定義されたファイルベースのストレージ (おそらくASF設定ディレクトリの外側)。 ASFは、パスワードフィールドで指定されたファイルパスからパスワードを読み込みます(例: `SteamPassword`)。 The specified path can be either absolute, or relative to ASF's "home" location (the folder with `config` directory inside, taking into account `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). このメソッドは、例えば **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**で使用できます。 このようなファイルを使用するために作成しますが、適切なファイルを作成する場合はDockerの外でも使用できます。 For example, setting `SteamPassword` to `/etc/secrets/MyAccount.pass` and `PasswordFormat` to `4` will cause ASF to read `/etc/secrets/MyAccount.pass` and use whatever is written to that file as the account password.

パスワードを含むファイルが許可されていないユーザーによって読み取れないことを確認してください, この方法の全体の目的を打ち負かすように.

---

## 暗号化のおすすめ項目

If compatibility is not an issue for you, and you're fine with the way how `ProtectedDataForCurrentUser` method works, it is the **recommended** option of storing the password in ASF, as it provides the best security and convenience. `AES` method is a good choice for people who still want to make use of their configs on any machine they want, while `PlainText` is the most simple way of storing the password, if you don't mind that anybody can look into JSON configuration file for it.

攻撃者があなたのPCにアクセスできる場合、すべての暗号化方式は **安全でない** とみなされることに注意してください。 ASFは暗号化されたパスワードを復号できる必要があり、マシン上で実行されているプログラムがそれを行うことができる場合。 同じマシン上で動作する他のプログラムも同様に動作することができます `ProtectedDataForCurrentUser` is the most secure variant as **even other user using the same PC will not be able to decrypt it**, but it's still possible to decrypt the data if somebody is able to steal your login credentials and machine info in addition to ASF config file.

高度な設定では、 `EnvironmentVariable` と `File` を利用できます。 They have limited usability, the `EnvironmentVariable` will be a good idea if you'd prefer to obtain password through some kind of custom solution and store it in memory exclusively, while `File` is good for example with **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. しかし、どちらも暗号化されていないので、基本的にリスクをASFの設定ファイルから選択したものに移動します。

上記で指定した暗号化方式に加えて、パスワードを完全に指定しないようにすることも可能です。 例えば、 `SteamPassword` のように、空文字列または `null` の値を使用します。 ASFが必要なときにパスワードを要求します。 それをどこにも保存しませんが、現在進行中のプロセスを記憶に留めておきましょう パスワードを扱う最も安全な方法である間(どこにも保存されていません)。 ASF実行ごとに手動でパスワードを入力する必要があるので、最も厄介なことです(必要なとき)。 それがあなたにとって問題でない場合は、存在しない何かを漏らすことはできないので、これはあなたの最善の賭けのセキュリティーワイズです。

---

## 復号化

ASFは暗号化されたパスワードを復号する方法をサポートしていません。なぜなら、復号メソッドはプロセス内のデータにアクセスするために内部的にのみ使用されるからです。 暗号化手順を元に戻したい場合、例: `ProtectedDataForCurrentUser`を使用して他のマシンにASFを移動する場合は、新しい環境で最初から手順を繰り返します。

---

## ハッシュ

ASF currently supports the following hashing methods as a definition of `EHashingMethod`:

| 値 | 名前              |
| - | --------------- |
| 0 | プレーンテキスト        |
| 1 | SCryptformat@@0 |
| 2 | Pbkdf2          |

それらの正確な説明と比較は以下で入手できます。

### セットアップ

ハッシュを生成するために `IPCPassword` の使用用 ` ハッシュ ` `` **[コマンド](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** を、適切なハッシュ方法と元のプレーンテキストパスワードで実行する必要があります。 Afterwards, put the hashed string that you've got as `IPCPassword` ASF config property, and finally change `IPCPasswordFormat` to the one that matches your chosen hashing method.

---

### `プレーンテキスト`

これは、 `0` の `EHashingMethod` として定義された、パスワードをハッシュする最もシンプルで安全でない方法です。 ASFは元の入力に一致するハッシュを生成します。 これは最も使いやすく、すべてのセットアップと100%互換性があります。 秘密を保管する標準的な方法です安全に保管するには まったく安全ではありません

---

### `SCryptformat@@0`

今日の基準で安全とみなされています **[](https://en.wikipedia.org/wiki/Scrypt)** パスワードのハッシュ方法は、 `EHashingMethod` `1` として定義されています。 ASF will use the `SCrypt` implementation using `8` blocks, `8192` iterations, `32` hash length and encryption key as a salt to generate the array of bytes. 結果のバイトは **[base64](https://en.wikipedia.org/wiki/Base64)** 文字列としてエンコードされます。

ASFでは、 `--cryptkey` **[コマンドライン引数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**を使用してこのメソッドのsalt を指定できます。 最大限のセキュリティのために使うべきです If you decide to omit it, ASF will use its own key which is **known** and hardcoded into the application, meaning hashing will be less secure.

適切に使用された場合 (カスタムソルト、長いパスワード)、安全なストレージのための非常に高いセキュリティを保証します。

---

### `Pbkdf2`

今日の基準では弱いとされています **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** ハッシュ化の方法は、 `` `2` の EHashingMethod </code> として定義されています。 ASF will use the `Pbkdf2` implementation using `10000` iterations, `32` hash length and encryption key as a salt, with `SHA-256` as a hmac algorithm. 結果のバイトは **[base64](https://en.wikipedia.org/wiki/Base64)** 文字列としてエンコードされます。

ASFでは、 `--cryptkey` **[コマンドライン引数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**を使用してこのメソッドのsalt を指定できます。 最大限のセキュリティのために使うべきです If you decide to omit it, ASF will use its own key which is **known** and hardcoded into the application, meaning hashing will be less secure.

---

## ハッシュの推奨事項

If you'd like to use a hashing method for storing some secrets, such as `IPCPassword`, we recommend to use `SCrypt` with custom salt, as it provides a very decent security against brute-forcing attempts.

`Pbkdf2` は互換性の理由からのみ提供されます。 主な理由は、すでにSteamプラットフォーム全体で他のユースケースのために機能している(そして必要な)実装があるからです。 を選択します。 それはまだ安全と考えられていますが、代替品(例えば `SCrypt`)に比べて弱いです。