# 安全性

## 加密

ASF目前支援以下加密方式，作為&#8203;`ECryptoMethod`&#8203;的定義：

| 值 | 名稱                          |
| - | --------------------------- |
| 0 | PlainText（純文字）              |
| 1 | AES（進階加密標準）                 |
| 2 | ProtectedDataForCurrentUser |
| 3 | EnvironmentVariable（環境變數）   |
| 4 | File（文字檔）                   |

以下提供了它們的詳細說明及比較。

### 設定

要生成加密的密碼，例如在&#8203;`SteamPassword`&#8203;中使用，您可以執行&#8203;`encrypt`&#8203;**[指令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-TW)**&#8203;，並加上您所選的適當的加密方式及您密碼的原始純文字。 然後，將您獲得的加密字串輸入&#8203;`SteamPassword`&#8203; Bot設定屬性，並修改&#8203;`PasswordFormat`&#8203;對應至您所選的加密方法。 某些格式不需要&#8203;`encrypt`指令，例如&#8203;`EnvironmentVariable`&#8203;或&#8203;`File`&#8203;，只需給予適合的路徑。

---

### `PlainText（純文字）`

這是最簡單也最不安全的密碼儲存方式，指定&#8203;`ECryptoMethod`&#8203;為&#8203;`0`&#8203;。 ASF字串應為純文字⸺即原始形式的密碼。 它是最容易使用的，且與所有設定100%相容，因此它是儲存私密資料的預設方式，但對於安全儲存來說毫無安全性可言。

---

### `AES（進階加密標準）`

依照現今的標準，可以將&#8203;**[AES](https://zh.wikipedia.org/zh-tw/高级加密标准)**&#8203;儲存密碼的方式視為安全的，指定&#8203;`ECryptoMethod`&#8203;為&#8203;`1`&#8203;。 ASF字串應為AES加密的位元組陣列轉換成&#8203;**[Base64編碼](https://zh.wikipedia.org/zh-tw/Base64)**&#8203;的字元序列，需含有&#8203;**[初始向量](https://zh.wikipedia.org/zh-tw/初始向量)**&#8203;及ASF加密鍵來解密。

上述方法保證了安全性，只要攻擊者不知道用於加密及解密的ASF加密鍵。 ASF使您能夠透過&#8203;`--cryptkey`&#8203;**[命令列引數](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-zh-TW)**&#8203;來獲得最大的安全性。 若您決定省略它，ASF將會使用自己&#8203;**已知**&#8203;硬編碼至應用程式中的金鑰，這代表任何人都可以逆轉ASF的加密，並獲得解密的密碼。 雖然這需要一些時間且不容易做到，但它還是有可能的。這就是為什麼您總應一起使用&#8203;`AES`&#8203;及您自己的&#8203;`--cryptkey`&#8203;來加密。 ASF使用的AES方法提供了令人滿意的安全性，它在簡單的&#8203;`PlainText`&#8203;及複雜的&#8203;`ProtectedDataForCurrentUser`&#8203;間取得了平衡，並強烈建議您與自訂的&#8203;`--cryptkey`&#8203;一起使用。

If used properly (long, custom `--cryptkey`), guarantees very high security for safe storage.

---

### `ProtectedDataForCurrentUser`

Considered secure by today standards, **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** way of storing the password is defined as `ECryptoMethod` of `2`. The major advantage of this method is at the same time the major disadvantage - instead of using encryption key (like in `AES`), data is encrypted using login credentials of currently logged in user, which means that it's possible to decrypt the data **only** on the machine it was encrypted on, and in addition to that, **only** by the user who issued the encryption.

This ensures that even if you send your entire `Bot.json` with encrypted `SteamPassword` using this method to somebody else, they will not be able to decrypt the password without direct access to your PC. 這是一種非常優秀的安全措施，但同時也有一個巨大的缺點，那就是幾乎沒有相容性可言，因為使用這種方法加密的密碼會與其他使用者或設備不相容：假設您打算重新安裝作業系統，這也將包含&#8203;**您自己的**&#8203;設備。 This is the recommended method if you don't have to access your configs from any other machine than your own, and that you also don't require cross-machine compatibility.

**請注意，這個選項目前只適用於執行Windows作業系統的設備。**

---

### `EnvironmentVariable（環境變數）`

基於記憶體的儲存方法，&#8203;`ECryptoMethod`&#8203;為&#8203;`3`&#8203;。 ASF會從環境變數中讀取密碼，且名稱需指定於密碼欄位中（例如&#8203;`SteamPassword`&#8203;）。 舉例來說，把&#8203;`SteamPassword`&#8203;設定成&#8203;`ASF_PASSWORD_MYACCOUNT`&#8203;、&#8203;`PasswordFormat`&#8203;設定成&#8203;`3`&#8203;，就能讓ASF讀取環境變數&#8203;`${ASF_PASSWORD_MYACCOUNT}`&#8203;作為帳號的密碼。

請注意，需要確保ASF程序的環境變數不會被未授權的使用者存取，因為那樣會完全破壞使用這種方式的目的。

---

### `File（文字檔）`

基於檔案的儲存方法（可在ASF設定資料夾外），&#8203;`ECryptoMethod`&#8203;為&#8203;`4`&#8203;。 ASF會從密碼欄位（例如&#8203;`SteamPassword`&#8203;）指定的路徑中讀取密碼。 The specified path can be either absolute, or relative to ASF's "home" location (the folder with `config` directory inside, taking into account `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). This method can be used for example with **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**, which create such files for usage, but can also be used outside of Docker if you create appropriate file yourself. 舉例來說，把&#8203;`SteamPassword`&#8203;設定成&#8203;`/etc/secrets/MyAccount.pass`&#8203;、&#8203;`PasswordFormat`&#8203;設定成&#8203;`4`&#8203;，就能讓ASF讀取&#8203;`/etc/secrets/MyAccount.pass`&#8203;檔案內容作為帳號的密碼。

記住，請確保未授權的使用者無法讀取含有密碼的檔案，因為這樣就違背了使用本方法的目的。

---

## 加密建議

If compatibility is not an issue for you, and you're fine with the way how `ProtectedDataForCurrentUser` method works, it is the **recommended** option of storing the password in ASF, as it provides the best security and convenience. `AES`&#8203;方法對於那些想要在其他設備上使用設定的使用者來說是個不錯的選擇，而若您不介意其他人都可以查閱JSON設定檔，那&#8203;`PlainText`是最簡單儲存密碼的方法。

Please keep in mind that all encryption methods are considered **insecure** if attacker has access to your PC. ASF必須能解密被加密的密碼，但若您設備上執行的程式能解密，那麼在相同設備上執行的其他程式亦能解密您的密碼。 `ProtectedDataForCurrentUser`&#8203;是最安全的方式，因為&#8203;**即使使用同一台PC的其他使用者，也無法解密密碼**&#8203;，但若有人能夠竊取您的登入憑證、設備資訊及ASF設定檔，則仍能解密這些資料。

對於進階的設定，您可以使用&#8203;`EnvironmentVariable`&#8203;與&#8203;`File`。 They have limited usability, the `EnvironmentVariable` will be a good idea if you'd prefer to obtain password through some kind of custom solution and store it in memory exclusively, while `File` is good for example with **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. 不過，它們都並未加密，因此基本上是將風險從ASF設定檔轉移到您選擇的這兩個方法的位置上。

除了上述指定的加密方法外，也可以完全不指定密碼，例如在&#8203;`SteamPassword`&#8203;設定成空字串，或&#8203;`null`&#8203;值。 ASF會在需要時向您詢問密碼，且不會儲存於任何地方，而是儲存於當前執行程序的記憶體中，直到您關閉它。 雖然這是儲存密碼最安全的方式（密碼並未儲存於任何地方），但也是最麻煩的，因為您需要在每次執行ASF時手動輸入密碼（若需要）。 If that's not a problem for you, this is your best bet security-wise, as you can't leak something that does not exist.

---

## 解密

ASF不支援解密已加密密碼的任何方式，因為解密方式只在內部使用，用於存取程序裡的資料。 若您需要反轉加密過程，例如使用了&#8203;`ProtectedDataForCurrentUser`&#8203;後將ASF移動至另一台設備上，只需在新環境中重新開始上述流程即可。

---

## 雜湊

ASF目前支援的雜湊方法&#8203;`EHashingMethod`&#8203;定義如下：

| 值 | 名稱             |
| - | -------------- |
| 0 | PlainText（純文字） |
| 1 | SCrypt         |
| 2 | Pbkdf2         |

以下提供了它們的詳細說明及比較。

### 設定

In order to generate a hash, e.g. for `IPCPassword` usage, you should execute `hash` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** with the appropriate hashing method that you chose and your original plain-text password. 之後將雜湊字串放入&#8203;`IPCPassword`&#8203; ASF設定屬性，最後修改&#8203;`IPCPasswordFormat`&#8203;對應至您選擇的雜湊方法。

---

### `PlainText（純文字）`

這是最簡單也最不安全的密碼雜湊方式，指定&#8203;`EHashingMethod`&#8203;為&#8203;`0`&#8203;。 ASF會生成與原始輸入相同的雜湊值。 它是最容易使用的，且與所有設定100%相容，因此它是儲存私密資料的預設方式，但對於安全儲存來說毫無安全性可言。

---

### `SCrypt`

Considered secure by today standards, **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** way of hashing the password is defined as `EHashingMethod` of `1`. ASF以&#8203;`8`&#8203;個區塊、&#8203;`8192`&#8203;次迭代、&#8203;`32`&#8203;位雜湊長度，並使用加密鍵作為鹽的&#8203;`SCrypt`&#8203;，來生成字元組陣列。 生成的位元組字串以&#8203;**[Base64](https://zh.wikipedia.org/zh-tw/Base64)**&#8203;編碼。

ASF使您能夠透過&#8203;`--cryptkey`&#8203;**[命令列引數](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-zh-TW)**&#8203;指定鹽來增加此方法的安全性。 若您決定省略它，ASF將會使用自己&#8203;**已知**&#8203;硬編碼至應用程式中的金鑰，這代表雜湊將會較不安全。

If used properly (custom salt, long password), guarantees very high security for safe storage.

---

### `Pbkdf2`

Considered weak by today standards, **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** way of hashing the password is defined as `EHashingMethod` of `2`. ASF will use the `Pbkdf2` implementation using `10000` iterations, `32` hash length and encryption key as a salt, with `SHA-256` as a hmac algorithm. The resulting bytes will then be encoded as **[base64](https://en.wikipedia.org/wiki/Base64)** string.

ASF allows you to specify salt for this method via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, which you should use for maximum security. 若您決定省略它，ASF將會使用自己&#8203;**已知**&#8203;硬編碼至應用程式中的金鑰，這代表雜湊將會較不安全。

---

## 雜湊建議

若您想要以雜湊方法來儲存私密資料，例如&#8203;`IPCPassword`&#8203;，我們建議您加鹽使用&#8203;`SCrypt`&#8203;，因為它提供了非常好的安全性來防止暴力破解。

`Pbkdf2`&#8203;是因為相容性問題才提供的，主要是因為我們已經為Steam平台上的其他功能（例如家庭監護PIN碼）提供了一個有效的（且需要的）實作功能。 它仍被認為是安全的，但與其他替代方案相比沒那麼安全（例如&#8203;`SCrypt`&#8203;）。