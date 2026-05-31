# 拡張FAQ

私たちの拡張されたFAQは、あなたが持つかもしれない少し一般的な質問と回答をカバーしています。 より一般的な問題については、代わりに **[基本的なFAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)** をご覧ください。

---

### 誰がASFを作成しましたか?

ASFは、2015年10月に **[](https://github.com/JustArchi)** によって作成されました。 疑問に思うかもしれませんが、私は **[Steamユーザー](https://steamcommunity.com/profiles/76561198006963719)** あなたのようなものです。 ゲームをプレイすることとは別に、私はあなたが今すぐ探索することができる私のスキルと決意を置くことが大好きです。 ここには大企業はありません。 開発者のチームはなく、そのすべてをカバーするための$ 1Mの予算もありません - 私だけで、壊れていないものを修正します。

しかし、ASFはオープンソースのプロジェクトであり、ここで見ることのできるすべての背後にないことを十分に表現することはできません。 **[他の](https://github.com/JustArchiNET?q=ASF-)** ASFプロジェクトは、ほぼ他の開発者によって開発されています。 コアASFプロジェクトでさえ、 **[貢献者の多くを持っています。](https://github.com/JustArchiNET/ArchiSteamFarm/graphs/contributors)** これらすべてを実現するのに役立ちました。 On top of that, there are several third-party services supporting ASF development, especially **[GitHub](https://github.com)**, **[JetBrains](https://www.jetbrains.com)** and **[Crowdin](https://crowdin.com)**. You also can't forget about all the awesome libraries and tools that made ASF happen, such as **[Rider](https://www.jetbrains.com/rider)** that we use as IDE (we love **[ReSharper](https://www.jetbrains.com/resharper)** additions) and especially **[SteamKit2](https://github.com/SteamRE/SteamKit)** without which ASF would not exist in the first place. ASFは、 **[が](https://github.com/sponsors/JustArchi)** をスポンサーし、様々なドナーがなければ、今日のような場所にはありません。 私がここで行っていることの全てを支えてくれるのです

ASF開発にご協力いただき、ありがとうございます! あなたは素晴らしい :heart:です。

---

### そもそもASFが作られた理由は?

ASFは、Linux向けの完全自動化蒸気農業ツールとして主な目的で作成されました。 外部の依存関係(Steamクライアントなど)は必要ありません。 実際、これは依然としてその主な目的と焦点であり続けています。 ASFのコンセプトはそれ以来変わらず、2015年に使用したのとまったく同じ方法で使っています。 もちろん、それ以来、変化の多くは **** ありました。 ASFがどの程度進展しているのか、とても嬉しく思います。 ほとんどの場合、そのユーザーのおかげで、私自身だけであれば、私は半分の機能をコーディングすることはありません。

ASFが他の同様のプログラムと競合するように作られたことはなかったことに注意してください。 特に **[アイドルマスター](https://www.steamidlemaster.com)**, ASFはデスクトップ/ユーザーアプリになるようには設計されていなかったので、今日でもそうではありません。 上記のASFの主要な目的を分析すると、Idle Masterが **その全ての正反対の** であることがわかります。 今日のASFプログラムに似ていることは間違いありませんが、 当時は何も(そして今日ではない)私のために十分な良いものだったので、私はそれを望んでいた方法自分のソフトウェアを作成しました。 時間が経つにつれて、ユーザーは主に堅牢性、安定性、およびセキュリティのためにASFに移行しました。 私がこれまで培ってきた全ての機能にも関わらずです 今日、ASFは今まで以上に良いです。

---

### さて、キャッチはどこですか? ASFを共有することで何が得られますか?

There is no catch, I created ASF **for myself** and shared it with the rest of the community in hope that it'll come useful. 1991年にも同じことが起こりました Linus Torvalds **[が最初の Linux カーネルである](https://groups.google.com/forum/#!msg/comp.os.Minix/dlNtH7RRrGA/SwRavCzVE7gJ)** を世界中と共有したとき。 隠されたマルウェア、データマイニング、暗号マイニング、または私にとって金銭的利益を生み出す他の活動はありません。 ASFプロジェクトは、あなたのような幸せなユーザーから送られた非義務的な寄付によって完全に支援されています。 私が使っているのとまったく同じ方法でASFを使うことができますし、気に入っていただけたら いつでもコーヒーを買ってくれて感謝の気持ちを伝えてくれます

私はまた、完全性とベストプラクティスのために常に打つ現代のC#プロジェクトの完璧な例としてASFを使用しています。 テクノロジーやプロジェクト管理やコードそのものを使うことができます それは私の定義である「正しく行われた」。 もし君が私のプロジェクトで何か役に立つことを学ぶことができれば それは私をより幸せにする

---

### ASFを起動した直後、すべてのアカウント/アイテム/友達/(...)を失いました!

統計的に言えば、それがどれほど悲しいかに関係なく。 ASFを起動した直後に、少なくとも1人の男が自動車事故で死亡することが保証されています。 違いは、誰もがそれを引き起こすことをASFを非難するということです でも何らかの理由で、代わりにSteamアカウントに起こっただけでASFを非難する人もいます。 もちろん、その理由は理解できます。すべてのASFはSteamプラットフォーム内で運用されています。 したがって、当然、人々は、自分が実行したソフトウェアがそれとリモート接続されていることを何らかの証拠がないにもかかわらず、Steam関連のプロパティに起こったすべてのことについて、ASFを非難します。

ASF, as stated in **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#is-it-safe)** as well as **[question above](#ok-where-is-the-catch-what-do-you-gain-from-sharing-asf)**, is free of malware, spyware, data mining and any other potentially unwanted activity, **especially** submission of your sensitive Steam details or taking over your digital property. このようなことがあなたに起こった場合。 ご不便をおかけして申し訳ございませんが、 **[スチームサポート](https://help.steampowered.com)** にご連絡いただくことをお勧めします。Aformat@@4 スチームサポート</strong> は、回復プロセスにおいてお役に立てることを願っております。私たちは何らかの形であなたに何が起こったのかについて責任を負わず、私たちの良心がはっきりしています。 そうでないと信じるならそれはあなたの決断です さらに詳しく述べることは無意味です 我々の声明を確認するための客観的かつ検証可能な方法を提供する上記のリソースが あなたを納得させなかったなら どうせここで書くのは 別に。

しかし、上記は、ASFの常識なしに **あなたのアクション** がセキュリティ問題に貢献できないことを意味するものではありません。 For example, you could disregard our security guidelines, expose ASF's **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface to the whole internet, and then be surprised that somebody got in and robbed you out of all items. 人々は常にそれを行います ドメインやIPアドレスとの接続がない場合、誰もASFインスタンスを見つけることはできないと考えています。 読んでみると、ウェブ上を完全に自動化されたボットがクロールしていない場合、 **千** が存在します。 ランダムなIPアドレスを含め、発見された脆弱性を探索し、非常に人気のあるプログラムとしてのASFもその対象となっています。 私たちはすでに、彼ら自身の愚かさによって「ハッキングされた」人々を十分に持っていました。 だから間違いから学んでもっと賢くなって

あなたのPCのセキュリティのためにも同じことが行われます。 はい、あなたのPCにマルウェアがあることはASFのすべての単一のセキュリティの側面を台無しにします ASFの設定ファイルから機密情報を読み取ったり、メモリを処理したり、プログラムに影響を与えたりして、そうでないことをすることさえできるので。 いいえ、あなたが疑わしい情報源から得た最後の亀裂は、誰かがあなたに言ったように、"間違った肯定的"ではありませんでした。 誰かのPCをコントロールする最も効果的な方法の1つです 人々は自分自身を感染させるだろうし、魅力的な指示に従うだろう。

ASFを完全に安全で、すべてのリスクから解放されていますか? **すべての** ソフトウェアにはセキュリティー指向の問題があるので、私たちは偽善者の束であると述べています。 多くの企業が行っていることとは対照的です **[セキュリティアドバイザリー](https://github.com/JustArchiNET/ArchiSteamFarm/security/advisories)** そして、ASFがセキュリティの観点から潜在的に望まれない可能性を秘めている *仮説的な* 状況を見つけたらすぐに、私たちはできるだけ透明にしようとしています すぐに発表します 例えば、 **[CVE-2021-32794](https://github.com/JustArchiNET/ArchiSteamFarm/security/advisories/GHSA-wxx4-66c2-vj2v)** で起こったことです ASFにはセキュリティ上の欠陥がありませんでしたが、ユーザーが誤って作成する可能性のあるバグがあります。

現在、ASFにパッチを当てていないセキュリティ上の欠陥は不明です。 そして、プログラムはより多くの人々によって使用されているため、 **[](https://en.wikipedia.org/wiki/White_hat_(computer_security))** と **[黒帽子](https://en.wikipedia.org/wiki/Black_hat_(computer_security))** ソースコードを解析します。 全体的な信頼要因は時間とともに増えるだけです そしてASFは、まずセキュリティに焦点を当てたプログラムとして、確実にそれを見つけることが容易ではありません。 私たちの最善の意図に関係なく、我々はまだ冷静に滞在し、常に潜在的なセキュリティ脅威に警戒することをお勧めします. ASFの利用もあります

---

### ダウンロードしたファイルが本物であることを確認するにはどうすればよいですか?

GitHub のリリースの一環として、 **[Debian](https://www.debian.org/CD/verify)** で使用されているものと非常に似た検証プロセスを使用しています。 すべての公式リリースでは、 `zip` ビルドアセットに加えて、 `SHA512SUMS` および `SHA512SUMS.sign` ファイルが見つかります。 ご希望の `zip` ファイルと一緒に、検証目的でダウンロードしてください。

まず、 選択された `zip` ファイルの `SHA-512` チェックサムが私たち自身が計算したものと一致することを確認するには、 `SHA512SUMS` ファイルを使用する必要があります。 Linuxでは、その目的に `sha512sum` ユーティリティを使用できます。


```
$ sha512sum -c --ignore-missing SHA512SUMS
ASF-linux-x64.zip: OK
```

On Windows, we can do that from powershell, although you have to manually verify with `SHA512SUMS`:

```
PS > Get-Content SHA512SUMS | Select-String -Pattern ASF-linux-x64.zip

f605e573cc5e044dd6fadbc44f6643829d11360a2c6e4915b0c0b8f5227bc2a257568a014d3a2c0612fa73907641d0cea455138d2e5a97186a0b417abad45ed9  ASF-linux-x64.zip


PS > Get-FileHash -Algorithm SHA512 -Path ASF-linux-x64.zip

Algorithm       Hash                                                                   Path
---------       ----                                                                   ----
SHA512          F605E573CC5E044DD6FADBC44F6643829D11360A2C6E4915B0C0B8F5227BC2A2575... ASF-linux-x64.zip
```

これにより、 `SHA512SUMS` に書かれたものが、結果のファイルと一致し、改ざんされていないことを保証しました。 しかし、あなたがチェックした `SHA512SUMS` ファイルが本当に私たちから来ていることはまだ証明されていません。 それを確認する方法は二つあります。

The first way, and also the one that ASF uses for auto-update process, is making a call to our backend server by visiting `https://asf.JustArchi.net/Api/Checksum/{Version}/{Variant}` URL, replacing `{Version}` with ASF version number, such as `6.1.4.3`, and `{Variant}` with your selected ASF variant, such as `generic` or `linux-x64`. JSONレスポンスでチェックサムを見つけることができます。これは、 `SHA512SUMS` や ASF zipファイルのアーティファクトと比較する必要があります。 私たちのサーバーは現在の **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** と **[プレリリース](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASFのバージョンに対してのみチェックサムを提供します。 既存のASFのみがアップデートを検討することになります。

```json
{
  "Result": "f605e573cc5e044dd6fadbc44f6643829d11360a2c6e4915b0c0b8f5227bc2a257568a014d3a2c0612fa73907641d0cea455138d2e5a97186a0b417abad45ed9",
  "Message": "OK",
  "Success": true
}
```

二つ目の方法は、バンドルされた `SHA512SUMS.sign` ファイルを利用することです。このファイルは `SHA512SUMS` の真正性を証明するデジタル PGP 署名を保持します。 ビルドアーティファクトと署名はビルドプロセスの一部として生成されるため、 GitHub が侵害された場合の完全性を保証するものではありません(これが検証目的で独自の独立したサーバーを使用する理由です)。 しかし、未知のソースからASFをダウンロードし、GitHubのリリースプロセスによって生成された有効なアーティファクトであることを確認したい場合は十分です。 GitHubが完全に妥協していないことを確認するのではなく

We can use `gpg` utility for that purpose, both on **[Linux](https://gnupg.org/download/index.html)** and **[Windows](https://gpg4win.org)** (change `gpg` command into `gpg.exe` on Windows).

```
$ gpg --verify SHA512SUMS. Sign SHA512SUMS
gpg: Signature made Mon 02 Aug 2021 00:34:18 CEST
gpg: using EDDSA key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: cannot check signature: no public key
```

あなたが見ることができるように、ファイルは確かに有効な署名を保持していますが、原因は不明です。 You'll need to import ArchiBot's **[public key](https://raw.githubusercontent.com/JustArchi-ArchiBot/JustArchi-ArchiBot/main/ArchiBot_public.asc)** that we sign the `SHA-512` sums with for full validation.

```
$ curl https://raw.githubusercontent.com/JustArchi-ArchiBot/JustArchi-ArchiBot/main/ArchiBot_public.asc -o ArchiBot_public.asc
$ gpg --import ArchiBot_public.asc
gpg: /home/archi/.gnupg/trustdb.gpg: trustdb created
gpg: key A3D181DF2D554CCF: public key "ArchiBot <ArchiBot@JustArchi.net>" imported
gpg: Total number processed: 1
gpg:               imported: 1

```

最後に、 `SHA512SUMS` ファイルを再度確認できます。

```
$ gpg --verify SHA512SUMS. Sign SHA512SUMS
gpg: Signature made Mon 02 Aug 2021 00:34:18 CEST
gpg: using EDDSA key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Good signature from "Archibot <ArchiBot@JustArchi.net>" [unknown]
gpg: 警告: This key is not certificated with a trusted signature!
gpg: 署名が所有者のものであることを示すものはありません。
主キー指紋: 224D A6DB 47A3 935B DCC3 BE17 A3D1 81DF 2D55 4CCF
```

This has verified that the `SHA512SUMS.sign` holds a valid signature of our `224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF` key for `SHA512SUMS` file that you've verified against.

最後の警告はどこから来るのか疑問に思うかもしれません。 私たちの鍵を正常にインポートしましたが、まだ信頼できませんでした。 これは必須ではありませんが、私たちもそれをカバーすることができます。 通常、これには異なるチャネルを通じて検証することが含まれます (例: 鍵が有効であることを電話、SMS) 、それからそれを信頼するためにあなた自身のキーと署名する。 この例では、この Wiki エントリを異なるチャンネル(非常に弱い)と考えることができます。 元のキーは **[ArchiBotのプロフィール](https://github.com/JustArchi-ArchiBot)** からのものです。 いずれにせよ、私たちはあなたがそれがあるように自信を持っていると仮定します。

まず、 **[はあなた自身のための秘密鍵](https://help.ubuntu.com/community/GnuPrivacyGuardHowto#Generating_an_OpenPGP_Key)**を生成します。 簡単な例として、 `--quick-gen-key` を使用します。

```
$ gpg --batch --passphrase '' --quick-gen-key "$(whoami)"
gpg: /home/archi/.gnupg/trustdb.gpg: trustdb created
gpg: key E4E763905FAD148B marked as ultimately trusted
gpg: directory '/home/archi/.gnupg/openpgp-revocs.d' created
gpg: revocation certificate stored as '/home/archi/.gnupg/openpgp-revocs.d/8E5D685F423A584569686675E4E763905FAD148B.rev'
```

信頼するために鍵に署名することができます。

```
$ gpg --sign-key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF

pub ed25519/A3D181DF2D554CCF
     created: 2021-05-22 express: neknown use: SC
     trust: unknown validity: unknown
sub cv25519/E527A892E05B2F38
     created: never usage: E
[ unknown] (1). ArchiBot <ArchiBot@JustArchi.net>


pub  ed25519/A3D181DF2D554CCF
     created: 2021-05-22  expires: never       usage: SC
     trust: unknown       validity: unknown
 Primary key fingerprint: 224D A6DB 47A3 935B DCC3  BE17 A3D1 81DF 2D55 4CCF

     ArchiBot <ArchiBot@JustArchi.net>

Are you sure that you want to sign this key with your
key "archi" (E4E763905FAD148B)

Really sign? (y/N) y
```

そして、鍵を信頼した後、 `gpg` は検証時に警告を表示しなくなりました。

```
$ gpg --verify SHA512SUMS. Sign SHA512SUMS
gpg: Signature made Mon 02 Aug 2021 00:34:18 CEST
gpg: using EDDSA key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Good signature from "ArchiBot <ArchiBot@JustArchi.net>" [full]
```

`[unknown]` トラストインジケーターが `[full]` に変更されていることを確認してください。

おめでとうございます。あなたがダウンロードしたリリースに改ざんされていないことを確認しました！ 👍

---

### 4月1日にASFの言語が変化し、何が起きているのか?

エイプリルフーズEASTR Eggを発見しておめでとう！ カスタム `CurrentCulture` オプションを設定していない場合。 その後、4月1日にASFは実際にシステム言語の代わりに` ` LOLcat **[](https://en.wikipedia.org/wiki/Lolcat)** 言語を使用します。 万が一その行動を無効にしたい場合は、 代わりに使用したいロケールに `CurrentCulture` を設定するだけです。 また、 `CurrentCulture` を `qps-Ploc` に設定することで、イースターエッグを無条件に有効にすることができます。