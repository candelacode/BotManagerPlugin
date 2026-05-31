# Sécurité

## Chiffrement

ASF prend actuellement en charge les méthodes de chiffrement suivantes comme une définition de `ECryptoMethod`:

| Valeur  | Nom                         |
| ------- | --------------------------- |
| 0       | PlainText                   |
| 1       | AES                         |
| 2       | ProtectedDataForCurrentUser |
| 3       | Variable d'environnement    |
| 4       | Fichier                     |

La description et la comparaison exactes sont disponibles ci-dessous.

### Programme d’installation

Afin de générer un mot de passe chiffré, p.ex. pour une utilisation de `SteamPassword` , vous devez exécuter `chiffrer` **[commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** avec le cryptage approprié que vous avez choisi et votre mot de passe original en texte brut. Afterwards, put the encrypted string that you've got as `SteamPassword` bot config property, and finally change `PasswordFormat` to the one that matches your chosen encryption method. Certains formats ne nécessitent pas la commande `chiffrer` , par exemple `EnvironmentVariable` ou `Fichier`, il suffit de mettre le chemin approprié pour eux.

---

### `PlainText`

C'est le moyen le plus simple et le plus peu sûr de stocker un mot de passe, défini comme `ECryptoMethod` de `0`. ASF attend que la chaîne soit un texte brut - un mot de passe dans sa forme directe. C'est le plus simple à utiliser, et 100% compatible avec toutes les configurations, c'est donc une façon par défaut de stocker des secrets, totalement peu sécurisés pour un stockage sécurisé.

---

### `AES`

Considéré comme sécurisé par les normes actuelles, **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** la manière de stocker le mot de passe est définie comme `ECryptoMethod` de `1`. ASF attend que la chaîne soit une séquence de caractères **[encodée en base64](https://en.wikipedia.org/wiki/Base64)** qui aboutira à un tableau d'octets chiffré par AES après la traduction, qui doivent ensuite être déchiffrées en utilisant le vecteur d'initialisation **[](https://en.wikipedia.org/wiki/Initialization_vector)** et la clé de chiffrement ASF.

La méthode ci-dessus garantit la sécurité tant que l'attaquant ne connaît pas la clé de chiffrement ASF qui est utilisée pour le déchiffrement ainsi que pour le chiffrement des mots de passe. ASF vous permet de spécifier la clé via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, que vous devez utiliser pour une sécurité maximale. Si vous décidez de l'omettre, ASF utilisera sa propre clé **connue** et codée en dur dans l'application, ce qui signifie que tout le monde peut inverser le cryptage ASF et obtenir un mot de passe déchiffré. Cela demande toujours quelques efforts et n’est pas si facile à faire, mais c’est possible, c’est pourquoi vous devriez presque toujours utiliser le cryptage `AES` avec votre propre `--cryptkey` qui est gardé secret. La méthode AES utilisée dans ASF fournit une sécurité qui devrait être satisfaisante. C'est un équilibre entre la simplicité de `PlainText`` et la complexité de <code>ProtectedDataForCurrentUser`, mais il est vivement recommandé de l’utiliser avec la <0>--cryptkey</code> personnalisée.

Si utilisé correctement (long, personnalisé `--cryptkey`), garantit une sécurité très élevée pour un stockage sécurisé.

---

### `ProtectedDataForCurrentUser`

Considéré comme sécurisé par les normes actuelles, **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** la manière de stocker le mot de passe est définie comme `ECryptoMethod` de `2`. Le principal avantage de cette méthode est en même temps le principal inconvénient: au lieu d'utiliser une clé de cryptage (comme dans `AES`), les données sont cryptées à l'aide des informations de connexion de l'utilisateur actuellement connecté, ce qui signifie qu'il est possible pour déchiffrer les données **uniquement** sur la machine sur laquelle elles ont été cryptées, et en plus de cela, **uniquement** par l'utilisateur qui a émis le cryptage.

This ensures that even if you send your entire `Bot.json` with encrypted `SteamPassword` using this method to somebody else, they will not be able to decrypt the password without direct access to your PC. Il s'agit d'une excellente mesure de sécurité, mais en même temps présente un inconvénient majeur d'être le moins compatible, car le mot de passe chiffré à l'aide de cette méthode sera incompatible avec n'importe quel autre utilisateur ainsi que la machine - y compris **votre propre** si vous le décidez. , réinstallez votre système d'exploitation. C'est la méthode recommandée si vous n'avez pas à accéder à vos configurations depuis une autre machine que la vôtre, et que vous n'avez pas non plus besoin de compatibilité entre machines.

**Veuillez noter que cette option n'est disponible que pour les machines fonctionnant sous Windows à partir de maintenant.**

---

### `Variable d'environnement`

Stockage basé sur des mémoires défini comme `ECryptoMethod` de `3`. ASF lira le mot de passe à partir de la variable d’environnement avec le nom spécifié dans le champ mot de passe (par exemple `SteamPassword`). For example, setting `SteamPassword` to `ASF_PASSWORD_MYACCOUNT` and `PasswordFormat` to `3` will cause ASF to evaluate `${ASF_PASSWORD_MYACCOUNT}` environment variable and use whatever is assigned to it as the account password.

N'oubliez pas de vous assurer que les variables d'environnement du processus ASF ne sont pas accessibles par des utilisateurs non autorisés. car cela va à l'encontre du but de cette méthode.

---

### `Fichier`

Stockage basé sur des fichiers (éventuellement en dehors du répertoire de configuration ASF) défini comme `ECryptoMethod` de `4`. ASF lira le mot de passe à partir du chemin du fichier spécifié dans le champ mot de passe (par exemple `SteamPassword`). Le chemin spécifié peut être soit absolu, soit relatif à l'emplacement « home » d'ASF (le dossier avec le répertoire `config` à l'intérieur, prenant en compte `--path` **[argument en ligne de commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). Cette méthode peut être utilisée par exemple avec **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**, qui créent de tels fichiers pour utilisation, mais peuvent également être utilisés en dehors de Docker si vous créez vous-même le fichier approprié. Par exemple, définir `SteamPassword` à `/etc/secrets/MyAccount. ass` et `PasswordFormat` à `4` obligeront ASF à lire `/etc/secrets/MyAccount. ass` et utiliser tout ce qui est écrit dans ce fichier comme mot de passe du compte.

N'oubliez pas de vous assurer que le fichier contenant le mot de passe n'est pas lisible par des utilisateurs non autorisés, car cela va à l'encontre de l'objectif d'utiliser cette méthode.

---

## Recommandations de chiffrement

Si la compatibilité n'est pas un problème pour vous et que la méthode `ProtectedDataForCurrentUser` fonctionne bien c'est l'option **recommandée** de stocker le mot de passe dans ASF, car elle offre la meilleure sécurité et la meilleure commodité. La méthode ` AES </ 0> est un bon choix pour les personnes qui souhaitent continuer à utiliser leurs configurations sur la machine de leur choix, tandis que <code> PlainText </ 0> est le moyen le plus simple de stocker le mot de passe, si cela ne vous dérange pas que quelqu'un puisse voir le fichier de configuration JSON.</p>

<p spaces-before="0">Veuillez garder à l'esprit que toutes les méthodes de chiffrement sont considérées comme <strong x-id="1">non sécurisées</strong> si l'attaquant a accès à votre PC. ASF doit être en mesure de déchiffrer les mots de passe chiffrés, et si le programme exécuté sur votre machine est capable de le faire, alors tout autre programme fonctionnant sur la même machine sera capable de le faire aussi. <code> ProtectedDataForCurrentUser </ 0> est la variante la plus sécurisée car <strong x-id="1"> même un autre utilisateur utilisant le même PC ne pourra pas le déchiffrer </ 1>, mais il est toujours possible de déchiffrer les données si quelqu'un est capable de voler. vos identifiants de connexion et vos informations de machine en plus du fichier de configuration ASF.</p>

<p spaces-before="0">Pour des configurations avancées, vous pouvez utiliser <code>EnvironmentVariable` et `Fichier`. Ils ont une utilisation limitée, la `EnvironmentVariable` sera une bonne idée si vous préférez obtenir un mot de passe grâce à une solution personnalisée et le stocker en mémoire exclusivement, alors que `Fichier` est bon par exemple avec **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. Les deux sont cependant non chiffrés, vous déplacez donc fondamentalement le risque du fichier de configuration ASF vers ce que vous choisissez parmi ces deux.

En plus des méthodes de chiffrement spécifiées ci-dessus, il est possible d'éviter de spécifier entièrement les mots de passe, par exemple comme `SteamPassword` en utilisant une chaîne vide ou une valeur `null`. ASF vous demandera votre mot de passe lorsque cela sera nécessaire. et ne le sauvegardera nulle part, mais gardera en mémoire le processus en cours d'exécution, jusqu'à ce que vous le fermiez. Tout en étant la méthode la plus sécurisée pour traiter les mots de passe (ils ne sont enregistrés nulle part), c'est également le plus gênant car vous devez entrer votre mot de passe manuellement à chaque exécution d'ASF (lorsque cela est nécessaire). Si ce n'est pas un problème pour vous, c'est votre meilleur pari en matière de sécurité, car vous ne pouvez pas fuir quelque chose qui n'existe pas.

---

## Déchiffrement

ASF ne prend en charge aucun moyen de déchiffrer des mots de passe déjà chiffrés, car les méthodes de déchiffrement ne sont utilisées qu'en interne pour accéder aux données dans le processus. Si vous voulez annuler la procédure de chiffrement, p. ex. pour déplacer ASF vers une autre machine lorsque vous utilisez `ProtectedDataForCurrentUser`, puis répétez simplement la procédure depuis le début dans le nouvel environnement.

---

## Hachage

ASF prend actuellement en charge les méthodes de hachage suivantes comme une définition de `EHashingMethod`:

| Valeur  | Nom       |
| ------- | --------- |
| 0       | PlainText |
| 1       | Crypte    |
| 2       | Pbkdf2    |

La description et la comparaison exactes sont disponibles ci-dessous.

### Programme d’installation

In order to generate a hash, e.g. for `IPCPassword` usage, you should execute `hash` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** with the appropriate hashing method that you chose and your original plain-text password. Afterwards, put the hashed string that you've got as `IPCPassword` ASF config property, and finally change `IPCPasswordFormat` to the one that matches your chosen hashing method.

---

### `PlainText`

C'est la manière la plus simple et la plus peu sûre de hacher un mot de passe, définie comme `EHashingMethod` de `0`. ASF générera un hachage correspondant à l'entrée originale. C'est le plus simple à utiliser, et 100% compatible avec toutes les configurations, c'est donc une façon par défaut de stocker des secrets, totalement peu sécurisés pour un stockage sécurisé.

---

### `Crypte`

Considéré comme sécurisé par les normes actuelles, **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** la manière de hacher le mot de passe est définie comme `EHashingMethod` de `1`. ASF utilisera l'implémentation `SCrypt` en utilisant les blocs `8` , `8192` itérations, `32` longueur du hachage et clé de cryptage comme un sel pour générer le tableau d'octets. Les octets résultants seront ensuite encodés sous la forme d'une chaîne **[base64](https://en.wikipedia.org/wiki/Base64)**.

ASF vous permet de spécifier le sel pour cette méthode via `--cryptkey` **[argument en ligne de commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, que vous devez utiliser pour une sécurité maximale. Si vous décidez de l'omettre, ASF utilisera sa propre clé qui est **connue** et codée en dur dans l'application. ce qui signifie que le hachage sera moins sécurisé.

S'il est utilisé correctement (sel personnalisé, mot de passe long), garantit une très grande sécurité pour un stockage sécurisé.

---

### `Pbkdf2`

Considéré comme faible par les normes actuelles, **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** la manière de hacher le mot de passe est définie comme `EHashingMethod` de `2`. ASF utilisera l'implémentation `Pbkdf2` en utilisant des itérations `10000` `32` la longueur du hachage et la clé de chiffrement comme un sel, avec `SHA-256` comme algorithme hmac. Les octets résultants seront ensuite encodés sous la forme d'une chaîne **[base64](https://en.wikipedia.org/wiki/Base64)**.

ASF vous permet de spécifier le sel pour cette méthode via `--cryptkey` **[argument en ligne de commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, que vous devez utiliser pour une sécurité maximale. Si vous décidez de l'omettre, ASF utilisera sa propre clé qui est **connue** et codée en dur dans l'application. ce qui signifie que le hachage sera moins sécurisé.

---

## Recommandations de hachage

Si vous souhaitez utiliser une méthode de hachage pour stocker certains secrets, comme `IPCPassword`, nous vous recommandons d'utiliser `SCrypt` avec un sel personnalisé, car il offre une sécurité très décente contre les tentatives de forçage.

`Pbkdf2` est proposé uniquement pour des raisons de compatibilité. principalement parce que nous avons déjà une implémentation fonctionnelle (et nécessaire) de cette implémentation pour d'autres cas d'utilisation à travers la plate-forme Steam (e. . épingles parentales). Il est toujours considéré comme sécurisé, mais faible par rapport aux alternatives (par exemple `SCrypt`).