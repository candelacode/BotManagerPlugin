# Commandes

ASF prend en charge diverses commandes pouvant être utilisées pour contrôler le comportement du processus et des instances de bot.

Les commandes ci-dessous peuvent être envoyées au bot de plusieurs manières différentes :
- Via la console ASF interactive
- Via le chat Steam (privé/groupe)
- Via notre interface **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**

N'oubliez pas que l'interaction ASF nécessite que vous soyez éligible pour la commande conformément aux autorisations ASF. Consultez les propriétés de configuration `SteamUserPermissions` et `SteamOwnerID` pour plus de détails.

Toutes les commandes ci-dessous sont affectées par `CommandPrefix` **[propriété de configuration globale](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#commandprefix)**, qui est `!` par défaut. Cela signifie que pour exécuter par exemple `status`, vous devez écrire `!Status` (ou un ` préfixe de commande personnalisé` de votre choix que vous avez défini à la place). `CommandPrefix` n'est pas obligatoire lorsque vous utilisez la console ou l'IPC, et peut être omis.

---

### Console interactive

ASF prend en charge la console interactive, tant que vous n’utilisez pas ASF en mode [**`Headless`**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless) mode. Appuyez simplement sur le bouton `c` pour activer le mode commande, tapez votre commande et confirmez avec entrée.

![Capture d"écran](https://i.imgur.com/bH5Gtjq.png)

---

### Steam chat

Vous pouvez aussi faire exécuter la commande par le bot ASF via le chat Steam. Évidemment, vous ne pouvez pas vous parler directement, donc vous aurez besoin d'au moins un autre compte bot si vous voulez exécuter des commandes ciblant votre compte principal.

![Capture d"écran](https://i.imgur.com/IvFRJ5S.png)

De même, vous pouvez également utiliser le chat de groupe d'un groupe Steam. N'oubliez pas que cette option nécessite de définir correctement la propriété `SteamMasterClanID`, auquel cas le bot écoutera les commandes également sur le chat du groupe (et le rejoindra si nécessaire). Cela peut également être utilisé pour "parler à vous-même" puisqu'il ne nécessite pas de compte bot dédié, contrairement au chat privé. Vous pouvez associer `SteamMasterClanID` à un groupe nouvellement créé, puis vous donner vous-même l'accès soit par `SteamOwnerID` ou par ` SteamUserPermissions ` de votre propre bot. De cette façon, ASF bot (vous) rejoindra le groupe et le chat de votre groupe sélectionné, et écoutera les commandes de votre propre compte. Vous pouvez rejoindre le même groupe de discussion afin de vous envoyer des commandes (car vous enverrez des commandes à la salle de discussion, et l'instance ASF siégeant dans la même salle de discussion les recevra, même si cela ne s'affiche que lorsque votre compte est présent).

Veuillez noter que l'envoi d'une commande au chat de groupe agit comme un relais. Notez que l'envoi d'une commande à la discussion de groupe agit comme un relais: si vous dites `redeem X` à 3 de vos robots assis avec vous sur la discussion de groupe, le résultat sera le même. comme vous le dites `redeem X` à chacun d’entre eux en privé. Dans la plupart des cas, ** ce n’est pas ce que vous souhaitez**. Vous devez plutôt utiliser` la commande de bot donnée` qui est envoyée à ** un seul bot dans une fenêtre privée**. . ASF prend en charge les discussions de groupe, car dans de nombreux cas, cela peut être une source de communication utile avec un unique bot, mais vous ne devriez presque jamais exécuter d’aucune commande sur la discussion de groupe s’il y a au moins 2 robots ASF assis, sauf si vous comprenez parfaitement le comportement d’ASF écrit ici. et vous voulez en fait relayer la même commande à tous les robots qui vous écoutent.

*Et même dans ce cas, vous devriez plutôt utiliser le chat privé avec la syntaxe `[Bots]`.*

---

### IPC

La manière la plus avancée et la plus souple d’exécution de commandes, idéale pour les interactions utilisateur (ASF-ui) ainsi que pour les outils tiers ou les scripts (API ASF), requiert que ASF soit exécuté en mode ` IPC `. une commande d'exécution client via l'interface **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**.

![Capture d"écran](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/commands.png)

---

## Commandes

Ajoute les appIDs `donnés` aux applications sur la liste noire à partir du trading automatique dans **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)</strong>.</td> </tr> 

</tbody> </table> 



---



### Remarques

Toutes les commandes sont sensibles à la case, mais leurs arguments (tels que les noms de bot) sont généralement sensibles à la case.

Les arguments suivent la philosophie UNIX, les crochets `[Optional]` indiquent que l'argument donné est optionnel, alors que les crochets `<Mandatory>` indiquent que l'argument donné est obligatoire. Vous devriez remplacer les arguments que vous voulez décliner, comme `[Bots]` ou `<Nickname>` avec des valeurs réelles avec lesquelles vous voulez émettre la commande, omettant les accolades.

L'argument `[Bots]` tel qu'indiqué par les crochets, est facultatif dans toutes les commandes. Lorsque spécifié, la commande est exécutée sur des bots. Lorsqu'il est omis, la commande est exécutée sur le bot actuel qui reçoit la commande (Steam chat), ou selon **[`DefaultBot`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#defaultbot)** propriété configurée (IPC et console interactive).

À titre d'exemple, `le statut A` envoyé au bot `B` est le même que l'envoi du statut `` au bot `A`, bot `B` dans ce cas agit uniquement en tant que proxy. Cela peut également être utilisé pour envoyer des commandes aux bots qui ne sont pas disponibles autrement, par exemple pour démarrer les bots arrêtés, ou exécuter des actions sur votre compte principal (que vous utilisez pour exécuter les commandes).

**Accès** de la commande définit **minimum** `EPermission` de `SteamUserPermissions` qui est nécessaire pour utiliser la commande, à l'exception de `Propriétaire` qui est `SteamOwnerID` défini dans le fichier de configuration global (et la plus haute permission disponible).

Arguments pluriels, tels que `[Bots]`, `<Keys>` ou `<AppIDs>` signifie que la commande prend en charge plusieurs arguments de type donné, séparés par une virgule. Par exemple, le statut ` [Bots]` peut être utilisé comme `statut MyBot, MyOtherBot, Primary`. Ainsi, la commande donnée sera exécutée sur ** tous les bots cibles </ 0> de la même manière que si vous envoyiez ` status </ 1> à chaque bot dans une fenêtre de discussion distincte. Veuillez noter qu'il n'y a pas d'espace après la virgule <code>,`.</p> 

ASF utilise tous les caractères de ponctuation comme délimiteurs possibles pour une commande, tels que les caractères de ponctuation et de nouvelle ligne. Cela signifie que vous ne devez pas utiliser d'espace pour délimiter vos arguments, vous pouvez également utiliser n'importe quel autre caractère de ponctuation (tel que tabulation ou nouvelle ligne).

ASF "joindra" des arguments supplémentaires hors de la plage au type pluriel du dernier argument de la gamme. Cela signifie que `redeem bot key1 key2 key3` pour `redeem [Bots] <Keys>` fonctionnera exactement de la même manière que `redeem bot key1,key2,key3`. En même temps que l’acceptation de newline en tant que délimiteur de commande, cela vous permet d’écrire `redeem bot`, puis de coller une liste de clés séparées par tout caractère séparateur acceptable (tel que newline) ou standard `,` délimiteur ASF. Gardez à l'esprit que cette astuce ne peut être utilisée que pour la variante de commande qui utilise le plus d'arguments (donc spécifier `[Bots]` est obligatoire dans ce cas, sinon votre première clé serait interprétée comme le bot cible sur lequel exécuter la commande).

Comme vous l'avez lu plus haut, un caractère d'espacement est utilisé comme délimiteur pour une commande. Par conséquent, il ne peut pas être utilisé dans les arguments. Toutefois, comme indiqué ci-dessus, ASF peut également joindre des arguments hors de portée, ce qui signifie que vous pouvez réellement utiliser un caractère d'espacement dans un argument défini comme dernier pour une commande donnée. Par exemple, `nickname bob Great Bob` définit correctement le surnom de ` bob` à "Great Bob". De la même manière, vous pouvez vérifier les noms contenant des espaces dans `owns`.

Les commandes attendues à `AppID` ou `SubID` sont également suffisamment intelligentes pour extraire ces informations des liens `store.steampowered.com`.



---

Certaines commandes sont également disponibles avec leurs alias, principalement pour vous sauver en tapant ou en comptant différents dialectes :

| Commande         | Alias              |
| ---------------- | ------------------ |
| `addlicense`     | `al`, `addlicence` |
| `addlicense ASF` | `ala`              |
| `owns ASF`       | `oa`               |
| `status ASF`     | `sa`               |
| `redeem`         | `r`                |
| `redeem^`        | `r^`               |
| `redeempoints`   | `rp`               |
| `rmlicense`      | `rl`, `rmlicence`  |




---



### `[Bots]` argument

`[Bots]` argument est une variante spéciale d'argument pluriel, car en plus d'accepter des valeurs multiples, il offre également des fonctionnalités supplémentaires.

Tout d'abord, l'argument `[Bots]` prend en charge les "groupes de bots", qui sont définis comme suit :

| Nom           | Description                                                     |
| ------------- | --------------------------------------------------------------- |
| `@all`, `ASF` | Tous les bots définis dans l'instance                           |
| `@farming`    | Bots en cours d'élevage                                         |
| `@idle`       | Bots qui ne sont actuellement **pas** en cours de farm          |
| `@hors ligne` | Bots qui ne sont actuellement **pas** connectés au réseau Steam |
| `@en ligne`   | Bots qui sont actuellement connectés au réseau Steam            |


Par exemple, la commande `statut ASF` est égale à `statut, votre, bots, listé, ici`. Cela peut également être utilisé pour identifier facilement les bots auxquels vous avez accès. En tant que mot clé ` ASF `, malgré le ciblage de tous les bots, seuls les bots auxquels vous pouvez envoyer la commande ne répondent. D'autres groupes sont également disponibles afin d'exécuter plus facilement une commande donnée uniquement sur des bots spécifiques remplissant la condition.

`[Bots]` argument supporte également la syntaxe spéciale "range", qui vous permet de choisir une gamme de robots plus facilement. La syntaxe générale pour `[Bots]` dans ce cas est `[FirstBot]..[LastBot]`. Au moins un des arguments doit être défini. Lorsque vous utilisez `<FirstBot>..`, tous les bots commençant par `FirstBot` sont affectés. Lorsque vous utilisez `..<LastBot>`, tous les bots jusqu'à `LastBot` sont affectés. Lorsque vous utilisez `<FirstBot>..<LastBot>`, tous les bots compris entre `FirstBot` et `LastBot` sont affectés. Par exemple, si vous avez des robots nommés ` A, B, C, D, E, F `, vous pouvez exécuter ` le statut B..E`, ce qui correspond à `. statut B, C, D, E ` dans ce cas. En utilisant cette syntaxe, ASF utilisera un tri alphabétique afin de déterminer les bots qui se trouvent dans la plage spécifiée. Les arguments doivent être des noms de bot valides reconnus par ASF, sinon la syntaxe de la plage est entièrement ignorée.

En plus de la syntaxe d'intervalle ci-dessus, l'argument `[Bots]` prend également en charge la correspondance **[regex](https://en.wikipedia.org/wiki/Regular_expression)**. Vous pouvez activer le modèle regex en utilisant `r!<Pattern>` comme nom de bot, où `r!` est l'activateur ASF pour la correspondance avec des expressions régulières, et `<Pattern>` est votre modèle regex. Un exemple de commande bot basée sur une regex serait `status r!^\d{3}`, qui enverra la commande `status` aux bots dont le nom est composé de 3 chiffres (par exemple `123` et `981`). N'hésitez pas à jeter un coup d'œil à la doc **[](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** pour plus d'explications et plus d'exemples de modèles regex disponibles.



---



## ` Paramètres de confidentialité </ 0></h2>

<p spaces-before="0"><code><Settings>`argument accepté **jusqu'à 7**différentes options, séparées comme d'habitude avec le séparateur ASF standard par virgule. Ce sont, dans l'ordre:</p> 

| Argument | Nom            | Dépend de  |
| -------- | -------------- | ---------- |
| 1        | Profile        |            |
| 2        | OwnedGames     | Profile    |
| 3        | Playtime       | OwnedGames |
| 4        | FriendsList    | Profile    |
| 5        | Inventory      | Profile    |
| 6        | InventoryGifts | Inventory  |
| 7        | Comments       | Profile    |


Pour la description des champs ci-dessus, veuillez visiter **[Paramètres de confidentialité Steam](https://steamcommunity.com/my/edit/settings)**.

Tandis que les valeurs valides pour tous sont:

| Valeur  | Nom             |
| ------- | --------------- |
| 1       | `Privé`         |
| 2       | `AmisSeulement` |
| 3       | `Publique`      |


Vous pouvez utiliser un nom ne tenant pas compte de la casse ou une valeur numérique. Les arguments qui ont été omis seront par défaut définis sur ` Privé </ 0>. Il est important de noter les dépendances spécifiées ci-dessus, car la propriété donnée dépend de la permission la plus ouverte que l'entrée puisse avoir.</p>

<p spaces-before="0">Par exemple, votre <strong x-id="1">ne peut pas</strong> avoir un réglage de temps de jeu <code>public` alors que vous avez un paramètre de jeu `privé` , mais vous pouvez totalement avoir un réglage de jeu `Privé` tout en ayant un profil `Public`.



### Exemple

Si vous souhaitez définir ** tous ** les paramètres de confidentialité de votre bot nommé ` Principal ` sur ` Privé `, vous pouvez utiliser l'un des éléments ci-dessous:



```text
privacy Main 1
privacy Main Privat
```


En effet, ASF supposera automatiquement que tous les autres paramètres sont ` Privés `. Il n'est donc pas nécessaire de les saisir. Par contre, si vous souhaitez définir tous les paramètres de confidentialité sur ` Public `, vous devez utiliser l'un des éléments ci-dessous:



```text
privacy Main 3,3,3,3,3,3,3
privacy Main Public,Public,Public,Public,Public,Public,Public
```


De cette façon, vous pouvez également définir des options indépendantes comme bon vous semble:



```text
privacy Main Public,FriendsOnly,Private,Public,Public,Private,Public
```


Ce qui précède définira le profil comme public, les jeux appartenant à seulement des amis, le temps de jeu privé, la liste d'amis public, l'inventaire public, les cadeaux d'inventaire privé et les commentaires de profil public. Vous pouvez obtenir la même chose avec des valeurs numériques si vous le souhaitez.



---



## Licences

Les commandes `addlicense` et `rmlicense` prennent en charge deux types de licence différents, ceux-ci:

| Type          | Alias | Exemple       | Description                                                                  |
| ------------- | ----- | ------------- | ---------------------------------------------------------------------------- |
| `application` | `a`   | `app/292030`  | Jeu déterminé par son `appID` unique.                                        |
| `sub`         | `s`   | `sous-/47807` | Un package contenant un ou plusieurs jeux, identifié par son `subID` unique. |


La distinction est importante, car ASF utilisera la méthode réseau Steam pour les applications, et la méthode Steam store pour les paquets. Ces deux éléments ne sont pas compatibles les uns avec les autres.

Lors de l'activation de nouvelles licences, vous voudrez généralement spécifier l'application pour les week-ends gratuits/jeux F2P en permanence, et le paquet autrement.

Pour la suppression de la licence existante, les deux méthodes fonctionneront, bien que nous recommandons de supprimer des paquets afin d'avoir une requête déterministe et explicite, sinon Steam pourrait supprimer les paquets que vous n'avez pas l'intention d'être supprimés, surtout si votre compte a plus d'un paquet donnant accès à une application donnée. C'est parce que sous le capot, la licence est toujours identifiée par le paquet auquel elle donne accès, donc si vous décidez de supprimer par `appID`, Steam décide quel `sous-ID` il va supprimer.

Nous recommandons de définir explicitement le type de chaque entrée afin d’éviter des résultats ambigus. Toutefois, pour des raisons de compatibilité ascendante, si vous omettez complètement le type, ASF considérera que vous demandez un `sub` dans ce cas. Vous pouvez également interroger une ou plusieurs licences en utilisant le délimiteur standard ASF `,`.

Compléter les exemples de commandes :



```text
addlicense ASF app/292030
addlicense ASF sub/303386
rmlicense ASF app/292030,sub/303386
```




---



## Jeux `possédés`

`possède une commande` qui supporte plusieurs types de jeux différents pour `<games>` argument qui peut être utilisé, ceux-ci:

| Type          | Alias | Exemple          | Description                                                                                                                                                                                                                                                                        |
| ------------- | ----- | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `application` | `a`   | `app/292030`     | Jeu déterminé par son `appID` unique.                                                                                                                                                                                                                                              |
| `sub`         | `s`   | `sous-/47807`    | Un package contenant un ou plusieurs jeux, identifié par son `subID` unique.                                                                                                                                                                                                       |
| `regex`       | `r`   | `regex/^\d{4}:` | **[Regex](https://en.wikipedia.org/wiki/Regular_expression)** s'appliquant au nom du jeu, sensible à la casse. Voir la doc **[](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** pour une syntaxe complète et plus d'exemples. |
| `nom`         | `n`   | `nom/sorcière`   | Une partie du nom du jeu, insensible à la casse.                                                                                                                                                                                                                                   |


Nous vous recommandons de définir explicitement le type de chaque entrée afin d'éviter les résultats ambigus mais pour la compatibilité ascendante, si vous fournissez un type invalide ou si vous l'omettez entièrement, ASF supposera que vous demanderez à l'application `` si votre entrée est un nombre, et `nom` autrement. Vous pouvez également interroger un ou plusieurs jeux en même temps en utilisant le délimiteur standard ASF `,`.

Exemple de commande complète :



```text
est propriétaire de l'application ASF/292030, nom/Witcher
```




---



## Modes `redeem^`

La commande `redeem^</ 0> vous permet d’affiner les modes qui seront utilisés pour un scénario d’échange unique. Cela fonctionne comme remplacement temporaire de <code>RedeemingPreferences` **[propriété de configuration de bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

L'argument `<Modes>` accepte plusieurs valeurs de mode, séparées comme d'habitude par une virgule. Les valeurs de mode disponibles sont spécifiées ci-dessous:

| Valeur  | Nom                           | Description                                                                                  |
| ------- | ----------------------------- | -------------------------------------------------------------------------------------------- |
| FAWK    | Forcer l'Assomption de la clé | Force `AssumeWalletKeyOnBadActivationCode` pour activer les préférences                      |
| FD      | ForceDistributing             | Force l'activation de la distribution `Distributing`                                         |
| FF      | ForceForwarding               | Force l'activation du transfert `Forwarding`                                                 |
| FKMG    | ForceKeepMissingGames         | Force l'activation de `KeepMissingGames`                                                     |
| SAWK    | format@@0 SkipAssumeWalletKey | Force `AssumeWalletKeyOnBadActivationCode` en échangeant les préférences pour être désactivé |
| SD      | SkipDistributing              | Force la désactivation de la préférence ` Distributing `                                     |
| SF      | SkipForwarding                | Force la désactivation de la préférence ` Forwarding`                                        |
| SI      | SkipInitial                   | Ignore l'utilisation des clés sur le bot initial                                             |
| SKMG    | SkipKeepMissingGames          | Force le blocage de la préférence `KeepMissingGames`                                         |
| V       | Validate                      | Valide les clés pour le format approprié et ignore automatiquement les clés non valides      |


Par exemple, nous aimerions échanger 3 clés sur n’importe quel de nos bots ne possédant pas encore de jeux, mais pas sur notre bot ` principal `. Pour y parvenir, nous pouvons utiliser:

`redeem^ primary FF,SI key1,key2,key3`

Il est important de noter que le mode de récupération avancée va passer outre les `RedeemingPreferences` que vous avez **spécifiées dans la commande**. Par exemple, si vous avez activé `Distributing` dans vos `RedeemingPreferences`, il n'y aura pas de différence si vous utilisez le mode `FD` ou non, car le Distributing sera déja activé, du aux `RedeemingPreferences` que vous utilisez. C'est pourquoi chaque fois qu'un paramètre peut être forcé, il y a aussi la possibilité de forcer son arrêt.



---



## Commande `chiffrer`

La commande `chiffrer` vous permet de chiffrer des chaînes arbitraires en utilisant les méthodes de chiffrement d'ASF. `<encryptionMethod>` doit être l'une des méthodes de chiffrement spécifiées et expliquées dans la section **[sécurité](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**. Nous recommandons d'utiliser cette commande par le biais de canaux sécurisés (console ASF ou interface IPC, qui a également un point de terminaison API dédié pour elle), comme autrement, les détails sensibles pourraient être enregistrés par divers tiers (comme les messages de chat qui sont enregistrés par les serveurs Steam).



---



## `commande de hachage`

La commande `hash` vous permet de générer des hachages de chaînes arbitraires en utilisant les méthodes de hachage d'ASF. `<hashingMethod>` doit être l'une des méthodes de hachage spécifiées et expliquées dans la section **[sécurité](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**. Nous recommandons d'utiliser cette commande par le biais de canaux sécurisés (console ASF ou interface IPC, qui a également un point de terminaison API dédié pour elle), comme autrement, les détails sensibles pourraient être enregistrés par divers tiers (comme les messages de chat qui sont enregistrés par les serveurs Steam).



---



## Commande `input`

La commande `entrée` ne peut être utilisée qu'en mode `Headless` pour l'entrée de données données via **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** ou le chat Steam lorsque ASF fonctionne sans prise en charge pour l'interaction de l'utilisateur.

La syntaxe générale est `entrée [Bots] <Type> <Value>`.

`<Type>` est insensible à la casse et définit le type d'entrée reconnu par ASF. Actuellement, ASF reconnaît les types suivants:

| Type                    | Description                                                                                |
| ----------------------- | ------------------------------------------------------------------------------------------ |
| Login                   | `SteamLogin` propriété de config bot, si absente de config.                                |
| Password                | `SteamPassword` propriété de config bot, si absente de config.                             |
| SteamGuard              | Code d'authentification envoyé sur votre courrier électronique si vous n'utilisez pas 2FA. |
| SteamParentalCode       | `SteamParentalCode` propriété de config bot, si absente de config.                         |
| TwoFactorAuthentication | Jeton 2FA généré à partir de votre mobile, si vous utilisez 2FA mais pas ASF 2FA.          |


`<Value>` est une valeur définie pour le type donné. Actuellement, toutes les valeurs sont des chaînes.



### Exemple

Disons que nous avons un bot protégé par SteamGuard en mode non-2FA. Nous voulons lancer ce bot avec `Headless` à la valeur `true`.

Pour ce faire, nous devons exécuter les commandes suivantes:

`start MySteamGuardBot` -> Bot va essayer de se connecter, échoue en raison du besoin d'AuthCode, puis s'arrête en raison de son exécution en mode `Headless`. Nous en avons besoin pour que le réseau Steam nous envoie le code d'autorisation sur notre adresse électronique. Si cela n'était pas nécessaire, nous ignorerions cette étape.

`entrée MySteamGuardBot SteamGuard ABCDE` -> Nous définissons `SteamGuard` entrée de `MySteamGuardBot` bot à `ABCDE`. Bien entendu, ` ABCDE </ 0> est dans ce cas le code d'autorisation que nous avons reçu par courrier électronique.</p>

<p spaces-before="0"><code>start MySteamGuardBot` -> Nous recommençons notre bot (arrêté) cette fois il utilise automatiquement le code d'authentification que nous avons défini dans la commande précédente, correctement se connecter, puis le supprimer.

De la même manière, nous pouvons accéder à des bots protégés par 2FA (s'ils n'utilisent pas ASF 2FA), ainsi que définir d'autres propriétés requises lors de l'exécution.



---



## Rares reconnues

ASF reconnaît les raretés suivantes:

| Rareté       | Alias            |
| ------------ | ---------------- |
| `Unknown`    |                  |
| `Commun`     |                  |
| `Inhabituel` |                  |
| `Rare`       |                  |
| `Mythique`   | `Epique`         |
| `Légendaire` | `Exotique`       |
| `Ancien`     | `Extraordinaire` |
| `Immortel`   | `Contraband`     |
| `Arcanes`    |                  |
| `Inhabituel` |                  |


Non reconnu par les raretés ASF (autres que définies ci-dessus) sera défini comme `A Inconnue`.