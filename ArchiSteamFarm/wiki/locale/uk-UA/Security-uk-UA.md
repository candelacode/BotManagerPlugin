# Безпека

## Шифрування

ASF наразі підтримує такі методи шифрування, як визначення `ECryptoMethod`:

| Цінність | Ім'я                           |
| -------- | ------------------------------ |
| 0        | Звичайний текст                |
| 1        | AES                            |
| 2        | Захистити дані для користувача |
| 3        | Змінна середовища              |
| 4        | Файл                           |

Точні описи і порівняння них доступні нижче.

### Налаштувати

Для того, щоб згенерувати зашифрований пароль, напр.. для `SteamPassword` використання, ви повинні виконати `шифрувати` **[команду](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** з відповідним шифруванням і вихідним текстовим паролем. Afterwards, put the encrypted string that you've got as `SteamPassword` bot config property, and finally change `PasswordFormat` to the one that matches your chosen encryption method. Деякі формати не потребують `шифрування` , наприклад `EnvironmentVariable` or `File`, просто встановіть відповідний шлях для них.

---

### `Звичайний текст`

This is the most simple and insecure way of storing a password, defined as `ECryptoMethod` of `0`. ASF очікує що рядок як звичайний текст - пароль у його прямій формі. Це найпростіше використовувати, і 100% сумісне з усіма налаштуваннями, Таким чином, це типовий спосіб зберігання таємниць, повністю небезпечний для безпечного сховища.

---

### `AES`

Considered secure by today standards, **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** way of storing the password is defined as `ECryptoMethod` of `1`. ASF expects the string to be a **[base64-encoded](https://en.wikipedia.org/wiki/Base64)** sequence of characters resulting in AES-encrypted byte array after translation, which then should be decrypted using included **[initialization vector](https://en.wikipedia.org/wiki/Initialization_vector)** and ASF encryption key.

Метод вище гарантує безпеку, доки атакуючий не знає ключ шифрування ASF, який використовується для дешифрування, а також для шифрування паролів. ASF дозволяє вказати ключ за допомогою `--cryptkey` **[параметру command-line](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, який ви повинні використовувати для максимальної безпеки. If you decide to omit it, ASF will use its own key which is **known** and hardcoded into the application, meaning anybody can reverse the ASF encryption and get decrypted password. It still requires some effort and is not that easy to do, but possible, that's why you should almost always use `AES` encryption with your own `--cryptkey` which is kept in secret. AES method used in ASF provides security that should be satisfying and it's a balance between simplicity of `PlainText` and complexity of `ProtectedDataForCurrentUser`, but it's highly recommended to use it with custom `--cryptkey`.

Якщо використовується належним чином (long, custom `--cryptkey`), гарантує дуже високий рівень безпеки для безпечного сховища.

---

### `Захистити дані для користувача`

Considered secure by today standards, **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** way of storing the password is defined as `ECryptoMethod` of `2`. The major advantage of this method is at the same time the major disadvantage - instead of using encryption key (like in `AES`), data is encrypted using login credentials of currently logged in user, which means that it's possible to decrypt the data **only** on the machine it was encrypted on, and in addition to that, **only** by the user who issued the encryption.

This ensures that even if you send your entire `Bot.json` with encrypted `SteamPassword` using this method to somebody else, they will not be able to decrypt the password without direct access to your PC. This is excellent security measure, but at the same time has a major disadvantage of being least compatible, as the password encrypted using this method will be incompatible with any other user as well as machine - including **your own** if you decide to e.g. reinstall your operating system. Це рекомендований метод, якщо вам не потрібно отримати доступ до конфігурацій з будь-якого іншого комп'ютера, ніж Ваш власний метод, і що вам також не потрібна перехресна сумісність.

**Зверніть увагу, що ця опція доступна тільки для машин, що працюють Windows OS як тепер.**

---

### `Змінна середовища`

Memory-based storage defined as `ECryptoMethod` of `3`. ASF буде читати пароль зі змінної середовища з заданим іменем у полі пароля (наприклад `SteamPassword`). For example, setting `SteamPassword` to `ASF_PASSWORD_MYACCOUNT` and `PasswordFormat` to `3` will cause ASF to evaluate `${ASF_PASSWORD_MYACCOUNT}` environment variable and use whatever is assigned to it as the account password.

Не забудьте забезпечити несанкціоновані змінні процесу ASF недоступні через неавторизованих користувачів, оскільки це перемагає цілком мету з цим методом.

---

### `Файл`

File-based storage (possibly outside of the ASF config directory) defined as `ECryptoMethod` of `4`. ASF буде читати пароль зі шляху до файлу, вказаний у полі пароля (напр. `SteamPassword`). The specified path can be either absolute, or relative to ASF's "home" location (the folder with `config` directory inside, taking into account `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). This method can be used for example with **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**, which create such files for usage, but can also be used outside of Docker if you create appropriate file yourself. For example, setting `SteamPassword` to `/etc/secrets/MyAccount.pass` and `PasswordFormat` to `4` will cause ASF to read `/etc/secrets/MyAccount.pass` and use whatever is written to that file as the account password.

Не забудьте переконатися, що файл, що містить пароль, не читається несанкціонованими користувачами, оскільки він перемагає повністю призначення цього методу.

---

## Рекомендації щодо шифрування

If compatibility is not an issue for you, and you're fine with the way how `ProtectedDataForCurrentUser` method works, it is the **recommended** option of storing the password in ASF, as it provides the best security and convenience. `Метод AES` - це хороший вибір для людей, які все ще хочуть використовувати свої конфігурації на будь-якій машині, яку вони хочуть, а `PlainText` - це найпростіший спосіб зберігання пароля, якщо ви не заперечуєте, що будь-хто може знайти у файлі конфігурації JSON.

Будь ласка, майте на увазі, що всі методи шифрування вважаються **небезпечними** , якщо атакуючий має доступ до вашого ПК. ASF має вміти розшифрувати зашифровані паролі, і якщо програма працює на вашому комп’ютері здатна це зробити, потім будь-яка інша програма, що працює на тій же машині, також зможе це зробити. `ProtectedDataForCurrentUser` is the most secure variant as **even other user using the same PC will not be able to decrypt it**, but it's still possible to decrypt the data if somebody is able to steal your login credentials and machine info in addition to ASF config file.

For advanced setups, you can utilize `EnvironmentVariable` and `File`. They have limited usability, the `EnvironmentVariable` will be a good idea if you'd prefer to obtain password through some kind of custom solution and store it in memory exclusively, while `File` is good for example with **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. Однак, обидва вони не зашифровані, щоб ви просто перемістили ризик у конфігураційний файл ASF до того, що обрали з цих двох.

На додачу до методів шифрування, перелічених вище, можна уникнути повного вказування паролів, наприклад, `SteamPassword` використовуючи порожній рядок або `null` значення. ASF попросить вас ввести ваш пароль по вимогу, і не збереже його де завгодно, не залишайтеся в пам'яті запущеного процесу, доки не закриєте його. Будучи найбільш безпечним методом боротьби з паролями (вони не зберігаються в будь-якому місці), це також найбільш проблемно, оскільки вам потрібно ввести пароль вручну під час кожного запуску ASF (коли це необхідно). Якщо це не є проблемою для вас, то це ваша найкраща безпека, так як ви не можете витокувати те, що не існує.

---

## Дешифрування

ASF не підтримує жодного способу дешифрування вже зашифрованих паролів, оскільки методи розшифрування використовуються лише внутрішньо для доступу до даних усередині процесу. Якщо ви хочете, щоб повернути процедуру шифрування, напр. для переміщення ASF на інший комп'ютер при використанні `ProtectedDataForCurrentUser`а потім просто повторити процедуру з початку в новому середовищі.

---

## Хеш

ASF наразі підтримує такі методи хешування, як визначення `EHashingMethod`:

| Цінність | Ім'я            |
| -------- | --------------- |
| 0        | Звичайний текст |
| 1        | Скрипт          |
| 2        | Пбкдф2          |

Точні описи і порівняння них доступні нижче.

### Налаштувати

In order to generate a hash, e.g. for `IPCPassword` usage, you should execute `hash` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** with the appropriate hashing method that you chose and your original plain-text password. Afterwards, put the hashed string that you've got as `IPCPassword` ASF config property, and finally change `IPCPasswordFormat` to the one that matches your chosen hashing method.

---

### `Звичайний текст`

This is the most simple and insecure way of hashing a password, defined as `EHashingMethod` of `0`. ASF буде генерувати хеш, який відповідає вихідному вводу. Це найпростіше використовувати, і 100% сумісне з усіма налаштуваннями, Таким чином, це типовий спосіб зберігання таємниць, повністю небезпечний для безпечного сховища.

---

### `Скрипт`

Considered secure by today standards, **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** way of hashing the password is defined as `EHashingMethod` of `1`. ASF will use the `SCrypt` implementation using `8` blocks, `8192` iterations, `32` hash length and encryption key as a salt to generate the array of bytes. The resulting bytes will then be encoded as **[base64](https://en.wikipedia.org/wiki/Base64)** string.

ASF дозволяє вказати сіль для цього методу через `--cryptkey` **[аргумент-рядок](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**який ви повинні використовувати для максимальної безпеки. If you decide to omit it, ASF will use its own key which is **known** and hardcoded into the application, meaning hashing will be less secure.

При правильному використанні (користувацька сіль, довгий пароль), гарантує дуже високий рівень безпеки для безпечного сховища.

---

### `Пбкдф2`

Considered weak by today standards, **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** way of hashing the password is defined as `EHashingMethod` of `2`. ASF will use the `Pbkdf2` implementation using `10000` iterations, `32` hash length and encryption key as a salt, with `SHA-256` as a hmac algorithm. The resulting bytes will then be encoded as **[base64](https://en.wikipedia.org/wiki/Base64)** string.

ASF дозволяє вказати сіль для цього методу через `--cryptkey` **[аргумент-рядок](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**який ви повинні використовувати для максимальної безпеки. If you decide to omit it, ASF will use its own key which is **known** and hardcoded into the application, meaning hashing will be less secure.

---

## Хешування рекомендацій

Якщо ви хочете використовувати метод хешування для зберігання деяких таємниць, наприклад `IPCPassword`, ми рекомендуємо використовувати `SCrypt` з користувальницькою сіллю, оскільки вона забезпечує дуже пристойний захист від спроб жорстокого примусу.

`Pbkdf2` пропонується лише з причин сумісності, головним чином тому, що у нас вже є робоча (і потребує додаткової) реалізація для інших застосунків з платформою Steam. . батьківський контакт). Він досі вважається безпечним, але слабким в порівнянні з альтернативами (наприклад, `SCrypt`).