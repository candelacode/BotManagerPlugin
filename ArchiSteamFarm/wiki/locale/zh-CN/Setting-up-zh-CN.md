# 安装指南

如果您是第一次访问这里，欢迎！ 我们很高兴看到又一名旅客对我们的项目感兴趣，但能力越大，责任越大——只要您**愿意学习如何使用**，ASF 就有能力做很多与 Steam 有关的任务。 实际上，通过阅读 Wiki、跟随我们的指南并了解各种 ASF 的概念，最终您会获得一项独特的技能——使用当今最强大的 Steam 工具之一。

我们建议您**一次只做一件事**。 ASF 涉及许多不同的方面，其中一些非常简单，另一些则可能过于复杂。 您不需要立即理解或阅读一切，我们实际上建议您慢慢来。 放松下来，拿一杯饮料，然后花一小时的时间深入我们的文档——我们可以保证它不会浪费您的时间。

让我们从基础知识开始——ASF 基本上是一个控制台应用，这意味着它不会自动显示您平时使用的图形界面。 ASF 是一个通用应用程序，主要作为服务运行（守护进程），而不是桌面应用。 它最主要的使用场景之一就是在服务器设备上运行，而桌面应用完全不适合这种用法。 但这指的其实只是程序的核心，因为 ASF 实际上**确实有**图形界面——以内置的 ASF-ui 前端形式存在，但我们会稍后再详细讨论这部分——我们现在提到这一点，是为了避免您被黑色控制台屏幕之类的东西吓到。

您获取 ASF 可执行文件之后，程序将需要您进行配置，也就是具体说明您期望 ASF 做什么事。 您可以在没有配置的情况下启动程序，在这种情况下，ASF 将以默认设置启动，此时您可以进行有限的操作，例如通过 ASF-ui 进行初始配置，但除此之外，ASF 无法在未经配置的情况下做太多实际的事。

情况大概就是这样，我们开始吧！

---

## 安装操作系统包

通常，我们只需要花费几分钟进行下列操作：
- 首先，安装 **[.NET 依赖项](#net-依赖)**。
- 然后，在 [**ASF 发布页面**](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)下载适合您操作系统的包。
- 接下来，将压缩包解压到一个新文件夹。
- 然后，[**配置 ASF**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)。
- 最后，运行并开始使用 ASF。

一些步骤是不言自明的，其他步骤则需要您稍加注意。 别担心，我们会全程帮助您。

---

### .NET 依赖

第一步是确保您的操作系统至少能够正常运行 ASF。 您不需要理解这一点，但 ASF 是以 C# 编写的，基于 .NET 框架，并且可能依赖于一些您的平台尚未支持的本机库。 您可以把这想象成 3D 游戏需要 DirectX 库，或者汽车需要引擎来发动。

取决于您正在使用 Windows、Linux 或 macOS，您需要确保满足不同的要求。 参考文档为 **[.NET 依赖](https://docs.microsoft.com/dotnet/core/install)**，但为了简单起见，我们也在下文列出了所需的一切，这样您就完全不需要去阅读文档，除非您遇到了问题，或者想了解更多细节。

由于您安装的第三方软件，有可能您的操作系统已经满足了一部分（甚至所有）依赖项，这是很正常的。 但情况不一定总是如此，所以您应该在操作系统上运行对应的安装程序——如果没有这些依赖，ASF 就完全无法启动，而且您在这种情况下几乎看不到什么有用的报错信息。

请注意，您不需要为特定操作系统包进行其他准备工作，特别是安装 .NET SDK 或者运行时环境，因为操作系统包中已包含了它们。 您只需要安装 .NET 依赖项，使 ASF 自带的 .NET 运行时环境能够运行——如下文所述，不需要其他任何额外步骤。

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**：
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)**（64 位为 **[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)**，32 位为 **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)**，64 位 ARM 为 **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)**）
- 强烈建议您确保已安装所有 Windows 更新。 如果您未启用自动更新，则至少需要安装 **[KB2533623](https://support.microsoft.com/zh-cn/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** 和 **[KB2999226](https://support.microsoft.com/zh-cn/help/2999226/update-for-universal-c-runtime-in-windows)**，但有可能还需要更多。 如果您的 Windows 已更新到最新，或者至少足够新，则无需关注这一条。

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**：
根据您所使用的 Linux 发行版的不同，包名可能有所区别，我们会列出最常见的包名。 您可以使用系统自带的包管理器（例如 Debian 的 `apt` 或 CentOS 的 `yum`）来安装这些包。 这些是非常标准的库，无论您使用什么发行版，都应该是可用的，您只需要弄清楚它们在您的环境下叫什么名字。

- `ca-certificates`（标准可信 SSL 证书，用于 HTTPS 连接）
- `libc6`（`libc`）
- `libgcc-s1`（`libgcc1`、`libgcc`）
- `libicu`（`icu-libs`，您的发行版上的最新版，例如 `libicu76`）
- `libgssapi-krb5-2`（`libkrb5-3`、`krb5-libs`）
- `libssl3`（`libssl`、`openssl-libs`，您的发行版上的最新版本，并最低为 `1.1.X`）
- `libstdc++6`（`libstdc++`，`5.0` 或更高版本）
- `zlib1g`（`zlib`）

其中的大多数项目应该已经安装在您的系统中了。 例如，Debian 稳定版的最小化安装流程通常仅需要您再手动安装 `libicu76`。

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**：
- 您不需要安装任何东西，但您应该安装最新版本的 macOS，至少应为 12.0+

---

### 下载

我们已经满足了所有需要的依赖项，下一步就是在 **[ASF 发布页面](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**&#8203;下载最新版本。 ASF 提供多种不同版本的包，但您需要找到符合您的操作系统和架构的版本。 例如，假如您正在使用 `64` 位的 `Win`dows，就需要下载 `ASF-win-x64` 包。 请阅读&#8203;**[兼容性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-CN)**&#8203;章节了解关于不同操作系统版本的详情。 ASF 也可以运行在我们尚未提供官方版本的环境上，例如 **32 位 Windows**，但您需要[**安装 Generic 包**](#安装-generic-包)。

![Assets](https://i.imgur.com/Ym2xPE5.png)

下载之后，首先将 zip 文件解压到一个文件夹中。 如果您不知道该用什么工具，可以使用 **[7-zip](https://www.7-zip.org)**，但 Windows 自带的解压功能或者 Linux/macOS 提供的 `unzip` 等标准工具也应该没有任何问题。

请注意将 ASF 解压到**单独的文件夹中**，不要解压到有其他用途的文件夹——这一点非常重要。 ASF 包含自动更新功能，也就是替换自身的文件，这个过程通常也会删除文件夹中任何过时或无关的文件，您在 ASF 文件夹中存放的其他文件就可能会因此丢失。 如果您需要一些与 ASF 相关的额外脚本或文件，这没有问题，您可以专门为此创建一个文件夹，您还可以将 ASF 文件夹放到这个工具文件夹内部。

这是一个文件夹结构的示例：

```text
C:\ASF (放置您自己与 ASF 相关的东西)
    ├── MyNotes.txt (可选)
    ├── AsfMakeMeCoffeeScript.bat (可选)
    ├── (...) (任何您选择放在这里的其他文件，可选)
    └── Core (ASF 自身专用文件夹，也就是您解压压缩包的地方)
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         ├── www
         └── (...)
```

---

### 配置

现在我们只剩下最后一步，也就是配置。 ASF 使用了“机器人”的概念，每个机器人通常都是一个您想要在 ASF 中使用的 Steam 帐户。 您想定义多少个机器人都可以，但对于新手，我们先专注于使用一个——通常是您的主帐户。 ASF 还有非机器人配置文件，最重要的是全局配置文件，它会影响实例中的所有机器人。

一般的经验是**如果您不知道或不理解某些设置，就应该留下它的默认值，而不要作出任何改变**。 ASF 提供了多种方式配置、定制和调整几乎所有功能，但如上文所述，在一开始就尝试理解一切是个陷阱，您很快就会陷入混乱，甚至[**坠入深渊**](https://www.youtube.com/watch?v=KK3KXAECte4)。 相反，我们建议您先让程序正常运行起来，然后再开始深入研究其他选项，此时可以参考 Wiki 上的[**配置**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)页面，并且**一次只改一项**。

您可以通过几种方式配置 ASF——通过自带 ASF-ui 前端、在线配置文件生成器或者手动配置。 这已经在&#8203;**[配置](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)**&#8203;章节中进行了深入解释，所以如果您想了解详情可以前往阅读。 我们将以在线配置生成器开始，因为它在 ASF-ui 启动失败的情况下也仍然可用。

使用您常用的浏览器访问[**在线配置文件生成器**](https://justarchinet.github.io/ASF-WebConfigGenerator)页面。 我们建议您使用 Chrome 或者 Firefox，但一般只要您的浏览器能正常访问其他网站就可以。

打开这个页面后，切换到“机器人”标签。 您应该会看到类似下图的界面：

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

如果您刚刚下载的 ASF 版本早于配置文件生成器的默认版本，只需要在下拉菜单中选择您的 ASF 版本。 发生这种（罕见）情况的原因是，配置文件生成器会支持尚未成为稳定版本的预览版 ASF。 您下载的是最新的稳定版 ASF，已经验证过能够可靠地工作，这个版本可能比最新的预览版本旧一点，但预览版本是完全不适合新手使用的。

第一步是在红色高亮的 `Name` 文本框内**填写机器人的名称**。 您可以随意指定机器人的名字，例如您的昵称、用户名、一个数字或者任何其他内容。 只有一个词是您不能用的，`ASF`，这是为全局配置文件保留的关键字。 除此之外，您的机器人名称不能以一个点号开头（ASF 会忽略这些文件）。 我们还建议您避免使用空格，如果需要，可以使用下划线 `_` 作为单词之间的分隔符——这不是一个强制要求，但如果使用空格，您可能会在使用 ASF 命令时遇到困难。

定好机器人名称了吗？ 好极了，下一步是**启用 `Enabled` 开关**，这个选项定义了您的机器人是否会在 ASF 程序启动之后自动运行。 不这样做将导致 ASF 认为配置文件中的机器人需要被禁用，等您操作才能启动，在本例中，这不是我们想要的效果。

接下来是两个敏感信息：`SteamLogin` 和 `SteamPassword`。 您可以在这里做出另一个决定——要么在这两个属性中填写您的 Steam 登录信息，要么留空。

ASF 需要您的帐户凭据，因为它包含自己的 Steam 客户端实现，需要与官方客户端相同的信息来登录。 您的登录凭据只会存放在 ASF 的 `config` 文件夹下（在您下载生成好的配置文件之后），不会离开您的电脑。 我们的在线配置文件生成器是基于客户端的程序，这意味着您在配置生成器页面上进行的任何操作都在您的浏览器中本地运行，您输入的信息不会被发送到任何其他设备，因此您无需担心会发生敏感数据泄露。 不过，如果您出于任何原因，不希望在此处填写帐户凭据，我们很理解，您可以手动将它们填入生成好的配置文件中，或者完全省略这些属性，在没有它们的情况下操作。

如果您决定输入凭据，ASF 将能够在启动过程中自动登录，结合可选的 2FA 功能，您只需要双击运行程序就能完成一切。 如果您决定省略，则 ASF 将会在需要时请求您输入信息——这些信息完全不会保留，但如果您不手动输入，显然 ASF 将完全无法正常工作。 具体选择哪种方式完全由您自己决定，您还可以和平时一样，在[**配置**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)章节了解更多信息。

另外一提，您也可以只留空其中一个属性，例如 `SteamPassword`。 ASF 仍然会尝试自动登录，但会在需要时向您询问密码（与官方客户端类似）。 如果您还需要 4 位家庭监护 PIN 代码来解锁帐户，我们还建议您将它填入 `SteamParentalPin` 框内，虽然您也可以直接留空，并观察到家庭监护代码的保护效果有多脆弱，因为 ASF 可以在登录后的几秒内直接自行破解。 哎哟。

完成以上所有步骤之后，即**机器人名称**、**启用开关**和**登录凭据**，您的配置页面应该看起来类似这样：

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

现在您可以点击“下载”按钮，配置文件生成器将会根据您输入的名称生成新的 `json` 文件。 将该文件保存到 `config` 文件夹内，该文件夹位于您在上一步中解压 zip 文件得到的文件夹中。

恭喜您！ 您刚刚完成了最基本的 ASF 机器人配置。 还有更多未使用到的功能，但现在这就是您需要的一切。

---

### 运行 ASF

我知道您一直在等待这一刻，也不应该再等下去了，因为您已经准备好第一次启动程序。 只需要双击 ASF 文件夹内的 `ArchiSteamFarm` 可执行文件。 您也可以在控制台中启动。

如果担心 ASF 接下来的行为，特别是它会以您的身份执行哪些操作，例如默认加入我们的 Steam 组，现在您可以审查我们的[**远程通信**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-zh-CN)章节。 如果您不喜欢，可以随时禁用特定的功能，ASF 采用了合理的默认设置，而我们必须根据大多数用户群体的使用场景以及我们对程序的一般原则作出决定。

假如一切顺利，特别是第一步中的安装所有必须的依赖项和第三步中的配置 ASF，此时 ASF 应该正确启动，自动发现您的第一个机器人，并尝试登录：

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF 极有可能仍然需要您输入更多信息——您帐户的两步验证令牌代码（除非您完全禁用了 Steam 令牌）。 您只需遵循屏幕上的指示，提供身份验证器或电子邮件的令牌代码，或在手机客户端中确认登录。

出错了？

#### ASF 根本没有启动，没有控制台窗口

您要么缺少 .NET 依赖项，要么下载了不符合当前设备的 ASF。 如果您不知道哪里有问题，可以试着在[**常见问题**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-无法启动程序窗口立刻就退出了)章节中查找完全相同的情况，如果仍然无法解决，请通过[**支持渠道**](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)请求帮助。

#### 没有配置机器人

您没有将生成的配置文件放入 `config` 文件夹。 这一步中的常见错误可能有手动把 `.json` 扩展名修改为 `.txt` 等，一切操作系统（例如 Windows）默认会隐藏常见扩展名，所以您需要确保配置文件有正确的名称，也在正确的位置。

#### 已在配置文件中禁用此机器人，该实例将不会启动

您忘记了启用 `Enabled` 开关，这个选项的作用是让 ASF 自动启动您的机器人。 当然，如果您本来就希望这样，则您应该已经知道如何执行命令，您可以在看到这条消息后，执行 `start` 命令来启动机器人。

#### `InvalidPassword`

您的登录凭据很可能是错误的。 在生成的配置中检查您的 `SteamLogin` 和 `SteamPassword`，如果有错误，请回到配置步骤来纠正它们。 如果您仍然有问题，请尝试在您自己的 Steam 客户端使用相同的登录凭据——应该也会登录失败，并且您有可能会看到更具体的登录失败原因。

#### 一切正常？

假设填写的信息全部正确无误，您将会成功登录，ASF 将会以默认设置开始挂卡：

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

这意味着 ASF 此时已经在您的帐户上正常运作，您可以将这个窗口最小化去做其他事。 继续吧，您已经成功迈出了第一步，也许现在应该续一杯饮料了！

挂卡是一个很大的话题，值得写一整篇文章来讨论，但一般来说：经过足够的时间之后（取决于[**性能**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-zh-CN)），您将会看到 Steam 卡牌逐渐掉落。 当然，要做到这一点，您必须有可以挂卡的游戏，您可以在您的[**徽章页面**](https://steamcommunity.com/my/badges)上看到这些游戏会标注“X 张剩余卡牌掉落”——如果没有可挂卡的游戏，ASF 就会无事可做，如[**常见问题**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-zh-CN#什么是-asf)中所述，我们回答了大多数人提出过的常见问题，例如为什么他们的帐户中有 14 款游戏，ASF 却提示无事可做——不，这不是一个 Bug。

这就是我们最基本的安装指南。 像每个角色扮演游戏一样，您已经完成了新手教程，我们为您准备了整个 ASF 世界来探索。 例如，现在您可以决定是进一步配置 ASF，还是让它以默认设置运行。 如果您想了解更多信息，我们将会介绍另一些基本配置，但要了解完整的配置选项，您需要继续阅读 Wiki 的其他页面。

---

### 进一步配置

#### 同时挂多个帐户

ASF 支持同时挂多个帐户，这也是它的主要功能之一。 您可以通过生成更多机器人配置文件来向 ASF 添加更多帐户，其方法与您之前生成第一个机器人配置完全相同。 您只需要确保两件事：

- 机器人的名称是唯一的，如果您将第一个机器人命名为 `MainAccount`，其他的机器人就不能再叫这个名字。
- 登录信息正确，包括 `SteamLogin`、 `SteamPassword` 和 `SteamParentalCode`（如果您决定填写）。

换句话说，要添加其他帐户，只需要配置部分从头开始，进行同样的操作。 并且不能忘记每个机器人的名称应该是唯一的，避免覆盖已有的配置。

---

#### 更改设置

在独立的在线配置文件生成器中，更改已有设置的方法是完全一样的——生成一个新的配置文件。 点击“切换高级设置”按钮，查看其他的配置选项。 在本例中，我们会更改 `CustomGamePlayedWhileFarming` 选项，这个选项可以设置 ASF 挂卡时显示的自定义名称，而不是显示实际的游戏名。

让我们先简单分析一下。 如果您运行了 ASF 并且开始挂卡，在默认情况下您将会看到您的 Steam 帐户正在游戏中：

![Steam](https://i.imgur.com/1VCDrGC.png)

这很合理，因为 ASF 仅仅告诉了 Steam 平台“我们正在玩这款游戏”，因为我们需要卡牌，不是吗？ 但我们可以自定义！ 如果您还没有启用高级设置，则启用它，找到 `CustomGamePlayedWhileFarming`。 简单来说，在这里填写您想要显示的任意文本，例如“Idling cards”（挂卡中）。

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

现在，像之前一样下载新的配置文件，然后**覆盖**旧的配置文件。 当然，您也可以先删除旧配置文件，再将新配置文件放到原来的地方。

ASF 非常智能，它应该能注意到您更改了配置，然后自动读取新配置并生效，不需要重启程序。 如果因为任何原因未能自动生效新配置，您也可以简单地重启程序来重载。 完成之后，您应该会看到 ASF 在之前的地方显示您的自定义文本：

![Steam 2](https://i.imgur.com/vZg0G8P.png)

这证明您已经成功更改了配置文件。 您也可以用同样的方式更改全局 ASF 属性，只需要切换到“ASF”标签，下载生成的 `ASF.json` 配置文件，将其放到 `config` 文件夹内。

通过我们的 ASF-ui 前端，编辑 ASF 配置文件会更容易，我们将随后解释。

---

#### 使用 ASF-ui

正如前文所述，ASF 是一个控制台应用程序，不会自动启动图形用户界面。 然而，我们正在积极开发 IPC 接口的前端 **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN#asf-ui)**，它是访问各种 ASF 功能的一种非常简便的、适合用户的方式。

要使用 ASF-ui，您需要启用 `IPC`，这也是 ASF 的默认行为，所以只要您没有手动禁用过，就已经是启用状态。 运行 ASF 后，您应该能看到表明 IPC 接口成功启动的确认消息：

![IPC](https://i.imgur.com/ZmkO8pk.png)

简单来说，IPC 是 ASF 内置的一个本地运行的 Web 服务器，允许您通过常用的浏览器与它进行交互。 假如 IPC 正常启动，您就可以在运行 ASF 的同一台机器上，点击[**这个链接**](http://localhost:1242)访问 ASF 的 IPC 接口。 您可以使用 ASF-ui 进行各种操作，例如直接编辑配置文件或发送&#8203;**[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**。 您可以随意浏览一下，了解 ASF-ui 的所有功能。

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### 总结

您已经成功设置好了 ASF，让它管理您的 Steam 帐户，并且您也根据个人喜好对其进行了一定程度的定制。 如果您完整阅读了我们的指南，就应该已经成功通过 ASF-ui 界面调整 ASF 的设置，并且开始探索更多功能。 本教程到此结束，但我们还留下了一些您可能会感兴趣的额外信息，如果您愿意，也可以称之为“支线任务”：

- 我们的[**配置**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)章节将会为您解释之前所见的**所有**不同选项究竟有何作用，以及 ASF 提供了哪些功能。 别忘了在阅读过程中适当补充水分，我们提醒过您了。
- 如果您遇到了问题，或者有任何疑问，可以阅读[**常见问题**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-zh-CN)，其中涵盖了所有，或至少是绝大多数您想要问的问题。
- 如果您希望了解 ASF 的一切以及 ASF 如何为您提供帮助，请继续阅读我们的 **[Wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-zh-CN)**。 使用右侧的边栏来选择您感兴趣的章节。
- 最后，如果您认为我们的程序很有用，并且感谢我们为此付出的巨大努力，也可以考虑小小[**捐赠一笔**](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)。 ASF 出于热爱而生，我们在过去 10 多年的业余时间里一直在努力开发，为您带来优质的体验，我们对此感到非常自豪——即使是 1 美元的支持也会让我们倍感珍惜，这表明您关心我们的付出。 无论如何，祝您使用愉快！

---

## 安装 Generic 包

这一节附录是为想要使用 ASF **[Generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-CN#generic)** 包的高级用户准备的。 虽然使用起来比[**操作系统包**](#安装操作系统包)更麻烦，但这也有额外的好处。

您可能想在下列情况下使用 `generic` 包：
- 我们没有为您所使用的操作系统（例如 32 位 Windows）提供操作系统包
- 您已经安装了 .NET 运行时环境/SDK，或者打算安装
- 您希望自行管理运行时需求来最小化 ASF 的结构和内存占用
- 您想要使用的自定义[**插件**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-zh-CN)需要 `generic` 版本的 ASF 才能正常工作（因为缺少本机依赖项）

当然，您也可以在任何其他场景中使用它，但以上场景最合理。

但是，请注意，Generic 安装方式是有代价的——此时**您**需要负责安装管理 .NET 运行时环境。 这意味着，如果您的 .NET SDK（运行时环境）不可用、已过期或者已损坏，ASF 就直接无法工作。 这就是我们完全不建议普通用户安装此包的原因，因为现在您需要确保 .NET SDK（运行时环境）符合 ASF 的要求，能够用于运行 ASF，而不是使用**我们**验证过的 ASF 自带的 .NET 运行时环境。

对于 `generic` 包，您需要参考上述的操作系统包的安装指南，但只有两点小小的区别。 除了要安装 .NET 依赖项之外，您还需要安装 .NET SDK，并且不要下载操作系统特定的 `ArchiSteamFarm(.exe)` 可执行文件，而仅下载 `ArchiSteamFarm.dll` 二进制文件。 其他的步骤都是相同的。

额外的步骤有：
- 安装 **[.NET 依赖项](#net-依赖)**。
- 安装适合您操作系统的 **[.NET SDK](https://www.microsoft.com/net/download)**（或至少安装 ASP.NET Core 和 .NET 运行时环境）。 您可能需要使用一个安装器。 如果您不确定应该安装哪个版本，请参考&#8203;**[运行时环境需求](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-CN#运行时环境需求)**。
- 在 **[ASF 发布页面](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**&#8203;下载 `generic` 包。
- 将压缩包解压到一个新文件夹。
- **[配置 ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)**，其方式与上文所述完全相同。
- 使用助手脚本或者在 shell 中执行 `dotnet /path/to/ArchiSteamFarm.dll` 启动 ASF。

ASF 的 Generic 包没有包含任何特定系统的可执行文件，这也是它被称为 `generic` 的原因——它是与平台无关的产物，可以在任何地方运行，所以这里不存在 `exe` 文件。

这也是我们将助手脚本（用于 Windows 的 `ArchiSteamFarm.cmd` 和用于 Linux/macOS 的 `ArchiSteamFarm.sh`）与 `ArchiSteamFarm.dll` 二进制文件打包到同一个位置的原因。 如果您不想手动执行 `dotnet` 命令，就可以使用这些助手脚本。

显然，如果您没有安装 .NET SDK，或者 `dotnet` 可执行文件不在系统的 `PATH` 环境变量中，助手脚本也无法运行。 这些脚本可用可不用，如果愿意，您总是可以手动执行 `dotnet /path/to/ArchiSteamFarm.dll` 命令，这些脚本所做的事情也是调用这个命令，区别仅仅是脚本在底层做了一些额外的优化。