# リリースサイクル

ASFは、 `A.B.C.D` として記述された4つの数字を持つ一般的なC#バージョン管理を使用します。 それぞれのバージョンは常に凍結されており、そこからビルドされた固定ソースコードを指します(リリースとバンドルされています)。 当社のホスティングプロバイダ(GitHub)が無期限に保存されている限り、以前に公開されたバージョンを削除するつもりはありません。 自動コピーを作らなくても安全に転がせます

In general in terms of ASF versioning, we're doing our best to follow **[semver](https://semver.org)** versioning of `MAJOR.MINOR.PATCH` on the 3 least significant numbers - `B.C.D`. これらの3つの数字はASFのコードに直接関係しています。 最も重要な `` 数字は、通常ASFコードベース自体を超えるスコープでの変更を示します。 非常に頻繁にプログラムの基礎に影響を与えます

ASF as a project is aiming to have more or less **one feature release per month**, indicated by a bump of `C` number. In order to make such release possible, we have smaller **pre-releases** dedicated to advanced users, which serve as smaller milestones of changes that are released on as-needed basis when there will be enough of changes since the last pre-release to focus on. 最終的に 最終的なプレリリースが安定して成熟していると判断された場合、 既知の重大な回帰がなく、 以前の安定したリリースと比較して修正されるべきです。 新安定版に昇格すると同時に次の月次の月次サイクルを開放する

プレリリースが比較的安定していることを確認するために最善を尽くしています。 **プレリリースは、本番環境**で実行する場合は慎重に評価する必要があることに注意してください。 Pre-releases might have **critical bugs** and otherwise broken functionality, which is exactly why we're releasing them to begin with - so we can avoid all of that mess in our stable builds and offer reliable software.

潜在的に不安定なソフトウェアを使用することから生じるリスク増加を受け入れたくない場合。 **プレリリースビルド** の使用を避け、代わりに **[最新安定](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ビルドを使用してください。 大多数のユーザーには適しています

一方、 あなた自身を上級者と見なし、誰にとっても新しいリリースをテストするのを手伝いたいと思うなら - あなたはそれを試してフィードバックを提供することを歓迎しています 特に現在の安定版には存在しないバグや問題に関してはね

Depending on amount of changes in the cycle, usually there will be a single `C` version bump (from previous stable), and `D` bumps for every pre-release on as-needed basis. しかし、はるかに大きなスコープで変更を導入する場合、特に変更を破ります。 サイクルは `B` または `` バンプから始まる可能性があります。このようなスイッチは、現在のリリースサイクルが通常よりも不安定になる可能性があることを示します。 慎重にテストするべきです

Keep in mind that semver changes we're making relate only to previously released stable version, we do not track versioning across pre-releases in a cycle themselves, which means that version `1.0.1.2` might have a new feature that `1.0.1.1` didn't have, as long as the previously marked stable release is from `1.0.0.X` family. 同様に、同じサイクルからの2つのプレリリースでも大きな変更が発生する可能性があります。 新しく導入された機能などの最終的な形状を決めているときは特にそうです

| バージョンバンプ | Semver | 変更の例                                                                       |
| -------- | ------ | -------------------------------------------------------------------------- |
| A        |        | 主要な.NETランタイムの変更、基盤の変更、ASFのコードベースを超えた変更、あなたの猫を食べるかもしれないもの                   |
| B        | Major  | 小規模な.NETランタイムの変更、ASFコードベースの変更、マイナーな分類を超えるメジャーなコードの編集                       |
| C        | Minor  | 新しい月次サイクル、通常、既存の設定を壊さない新しい機能、コマンド、設定プロパティ、その他の変更を導入します                     |
| D        | パッチ    | 既存のサイクルの一部である新しいプレリリース（より重要な数字で示されます） 必要以上のコード変更を導入しない既存の安定版のリリースへの重要なバグ修正 |

新しく導入された機能や変更は文書化されていない場合がありますのでご注意ください。 (wikiで)しばらくすると 文書は通常、与えられた機能の最終コードが準備できていると書かれています(現在作業中の機能を変更するたびにドキュメントを書き換える時間を節約するため)。 プレリリースには、まだ最終フォームを持たない進行中のコードが含まれている可能性があるため、 ドキュメントは開発の後半に到着するかもしれません。 同じことがプレリリースで使用できない可能性がある一般的な changelog にも適用されます。 したがって、プレリリースを使用することにした場合は、ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/commits/main)** を時々コミットするように準備してください。 もちろんです ドキュメントの不足はプレリリースにのみ適用されます。 **** - それぞれの安定版では、リリースされた瞬間に完全な更新履歴とドキュメントがwikiに常に記載されていなければなりません。

あるバージョンを別のバージョンと比較する正確なchangelogは、コミットとコードの変更を通じて、GitHubでいつでも利用できます。 リリースでは、最後の安定版と現在のリリースの間で重要と考えられる変更のみを記録する傾向があります。 このような簡単な変更履歴は完全なものではありません。 ですから、あるバージョンと別のバージョン(依存関係のアップグレードなど)で起こったすべての変更を見たい場合は、 **[GitHub比較](https://github.com/JustArchiNET/ArchiSteamFarm/compare)** を使用してください。

ASFプロジェクトは、 **[継続的インテグレーションプロセス](https://github.com/JustArchiNET/ArchiSteamFarm/actions)** によって供給されます。 すべてのビルドは再現性があるはずです。 ですから、与えられたバージョンのソース(リリースに含まれる)をつかんで、プリコンパイルされたバイナリを通して入手可能なものと同じ結果を自分でコンパイルするのは問題ではありません。 通常、システムが動作している限り、リリースされたバイナリはCIプロセスから直接リリースされます。