# Mise en place

Si vous arrivez ici pour la première fois, bienvenue! We're very happy to see yet another traveler that is interested in our project, although bear in mind that with great power comes great responsibility - ASF is capable of doing a lot of different Steam-related tasks, but only as long as you **care enough to learn how to use it**. En effet, lecture du wiki, suivre nos directives et en apprendre plus sur divers concepts ASF vous récompensera éventuellement avec une compétence unique en utilisant l'un des outils Steam les plus puissants disponibles dès aujourd'hui.

We recommend you to do **one thing at a time**. ASF touche beaucoup d’aspects différents, dont certains sont plutôt insignifiants, d’autres peuvent être trop complexes. Vous n'avez pas besoin de tout comprendre ou de tout lire en même temps, et nous vous recommandons de le prendre facilement. Détendez-vous, choisissez une boisson de choix, consacrez une heure de votre temps et plongez dans notre conférence - nous pouvons vous promettre que ça vaudra bien votre temps.

Commençons par les bases - ASF est une application console dans son principe, ce qui signifie qu'il n'apparaîtra pas automatiquement une interface graphique à laquelle vous êtes généralement habitué. ASF est une application universelle qui agit principalement comme un service (démon), et non comme une application de bureau. L'un de ses principaux cas d'utilisation considère que l'exécution sur les machines du serveur, pour lesquelles les applications de bureau sont totalement inadaptées. Cela ne tient compte que du cœur absolu du programme cependant, parce qu'ASF en fait **fait** inclut sa propre interface graphique - sous la forme de son interface ASF-ui intégrée, mais nous nous remettrons à cette partie en temps voulu - nous en parlons tout de suite pour que vous ne paniquiez pas quand vous voyez l'écran de la console noire ou quelque chose.

Une fois que vous aurez obtenu des fichiers binaires ASF, le programme nécessitera une configuration de votre part, ce qui spécifie exactement ce que vous attendez d'ASF. Vous pouvez démarrer le programme sans configuration, dans ce cas, ASF se lancera dans les paramètres par défaut, vous permettant d'utiliser e. . ASF-ui pour la configuration initiale, mais sinon cela ne fera pas grand chose sans votre action préalable.

Cela va se faire pour l'instant, commençons!

---

## Installation spécifique à l'OS

En gros, vous aurez besoin de faire ceci dans les prochaines minutes:
- Nous installerons les conditions préalables **[.NET](#net-prerequisites)**.
- Ensuite, nous allons télécharger la dernière version **[d'ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** dans la variante appropriée spécifique au système d'exploitation.
- Ensuite, nous allons extraire l'archive dans un nouvel emplacement.
- Ensuite, nous allons **[configurer ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- Enfin, nous lancerons ASF et verrons sa magie.

Certaines étapes sont explicatives et d'autres nécessitent plus d'attention de votre part. Ne vous inquiétez pas, nous vous avons couvert.

---

### Conditions préalables au .NET

La première étape consiste à vérifier que votre OS peut lancer ASF correctement. Vous n'avez pas besoin de le savoir, mais ASF est écrit en C#, basé sur . La plate-forme ET peut nécessiter des bibliothèques natives qui ne sont pas encore disponibles sur votre plateforme. Pensez-y comme DirectX pour les jeux 3D, ou le moteur pour démarrer votre voiture.

Selon que vous utilisiez Windows, Linux ou macOS, vous aurez des exigences différentes. Le document de référence est **[. ET prérequis](https://docs.microsoft.com/dotnet/core/install)**, mais par souci de simplicité, nous avons aussi détaillé tous les paquets nécessaires ci-dessous, pour que vous n'ayez pas besoin de le lire du tout, sauf si vous rencontrez des problèmes ou si vous avez des questions supplémentaires.

Il est parfaitement normal que quelques (ou mêmes tous) les prérequis soient déjà installés sur votre système, notamment par des programmes tiers qui les nécessitent. Pourtant, cela n'a pas besoin d'être le cas, donc vous devriez exécuter l'installateur approprié pour votre système d'exploitation - sans ces dépendances, ASF ne se lancera pas du tout, et vous obtiendrez à peine des informations utiles pour vous dire ce qui ne va pas.

Gardez à l'esprit que vous n'avez pas besoin de faire autre chose pour les versions spécifiques au système d'exploitation, en particulier pour l'installation . ET SDK ou même runtime, puisque les paquets spécifiques à un système d'exploitation incluent déjà tout cela. Vous n'avez besoin que des prérequis .NET (dépendances) pour exécuter . ET runtime inclus dans ASF - donc seulement les choses que nous spécifions ci-dessous, sans aucun autre ajout.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** pour 64 bits, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** pour 32 bits ou **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** pour ARM 64 bits
- Il est fortement recommandé de s'assurer que toutes les mises à jour de Windows sont déjà installées. Si vous ne les avez pas activés, alors au moins vous avez besoin de **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** et **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, mais d'autres mises à jour peuvent être nécessaires. Vous n'avez pas besoin de vous inquiéter si votre Windows est à jour, ou au moins assez récent.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Les noms de paquets dépendent de la distribution Linux que vous utilisez, nous avons listé les plus courantes. Vous pouvez tous les obtenir avec un gestionnaire de paquets natif pour votre système d'exploitation (comme `apt` pour Debian ou `yum` pour CentOS). Ce sont de jolies bibliothèques standards qui devraient être disponibles quelle que soit la distribution que vous utilisez, il ne s'agit que de savoir comment ils sont appelés dans votre environnement de choix.

- `ca-certificats` (certificats SSL de confiance standard pour établir des connexions HTTPS)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, dernière version pour votre distribution, par exemple `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-libs`, dernière version pour votre distribution, au moins `1.1.X`)
- `libstdc++6` (`libstdc++`, en version `5.0` ou supérieure)
- `zlib1g` (`zlib`)

Au moins une majorité d'entre elles devraient être déjà disponibles nativement sur votre système. Par exemple, l'installation minimale de Debian stable ne nécessite généralement que `libicu76`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- Vous n'avez besoin de rien de spécifique, mais vous devriez avoir la dernière version de macOS installée, au moins 12.0+

---

### Téléchargement

Maintenant que nous avons toutes les dépendances requises, la prochaine étape est de télécharger **[la dernière version d'ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF est disponible dans de nombreuses variantes, mais vous n'aurez qu'à vous soucier du package qui correspond à votre système d'exploitation et son architecture. Par example, si vous utilisez `64`-bit `Win`dows, alors vous devrez télécharger `ASF-win-x64`. Pour plus d'informations sur les variantes disponibles, visitez la section **[compatibilité](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**. ASF est également en mesure de fonctionner dans les environnements pour lesquels nous ne construisons pas de package spécifique au système d'exploitation, comme **Windows**32 bits , mais vous aurez besoin de **[d'installation générique](#generic-setup)** pour cela.

![Actifs](https://i.imgur.com/Ym2xPE5.png)

Après le téléchargement, commencez à extraire le fichier zip dans son propre dossier. Si vous avez besoin d'un outil spécifique pour cela, **[7-zip](https://www.7-zip.org)** le fera, mais tous les utilitaires standards comme l'extraction de Windows intégrée ou `unzip` de Linux/macOS devraient également fonctionner sans problèmes.

Il est conseillé de décompresser ASF vers **son propre répertoire** et non vers un répertoire existant que vous utilisez déjà pour autre chose - c'est important. ASF inclut une fonctionnalité de mise à jour automatique, qui remplace ses propres fichiers, et qui supprimera généralement tous les fichiers anciens et non liés lors de la mise à niveau, qui, à son tour, peut vous faire perdre tout ce que vous avez mis sans lien avec vous dans le répertoire ASF. Si vous avez des scripts ou des fichiers supplémentaires que vous voulez utiliser avec ASF, ce n'est pas un problème, créez un dossier dédié pour ceux-ci, vous pouvez toujours mettre ASF dans un dossier plus profond.

Un exemple de structure pourrait ressembler à ceci :

```text
C:\ASF (où vous mettez vos propres choses)
    ── MyNotes. xt (optionnel)
    ── AsfMakeMeCoffeScript.bat (optionnel)
    ─ (... (tout autre fichier de votre choix, optionnel)
    <unk> ─ Core (dédié uniquement à ASF, où vous extrayez l'archive)
         ─ ArchiSteamFarm(. xe)
         ── config
         ── logs
         ── plugins
         ── www
         <unk> ─ (...)
```

---

### Configuration

Nous sommes maintenant prêts à faire la dernière étape, la configuration. ASF fonctionne avec le concept de "bots", chaque bot est généralement un seul compte Steam que vous souhaitez utiliser dans ASF. Vous pouvez déclarer autant de bots que vous le souhaitez, mais pour le démarrage, nous nous concentrerons sur l'un d'entre eux - généralement votre compte principal. ASF a également des fichiers de configuration non-bots, le plus important est le fichier de configuration global, qui affecte tous les bots dans l'instance.

La règle générale du pouce est que **si vous ne connaissez pas ou ne comprenez pas certains paramètres, vous devriez la laisser avec sa valeur par défaut, sans rien changer**. ASF offre d'innombrables façons de configurer, personnaliser et modifier presque toutes ses fonctionnalités, mais comme mentionné ci-dessus, essayer de le comprendre tout de suite est un trou de lapin qui peut vous entraîner rapidement dans une grande confusion, si pas **[directement dans l'abysse](https://www.youtube.com/watch?v=KK3KXAECte4)**. Au lieu de cela, nous recommandons d'avoir un exemple de travail d'abord, puis de commencer à creuser dans des options supplémentaires, avec l'aide de la page de configuration **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** sur le wiki, en changeant **une chose à la fois**.

La configuration d'ASF peut être effectuée de plusieurs façons - via notre interface ASF-ui intégrée, un générateur de configuration web autonome ou manuellement. Tout cela est expliqué plus précisément dans la section **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, donc référez-y vous si vous avez besoin d'informations plus détaillées. Nous utiliserons le générateur de configuration web autonome comme point de départ, car il fonctionne même si, pour une raison quelconque, ASF-ui ne démarre pas ou ne fonctionne pas correctement.

Accédez à notre page de génération de configuration **[web](https://justarchinet.github.io/ASF-WebConfigGenerator)** avec votre navigateur favori. Nous recommandons Chrome ou Firefox, mais cela ne devrait pas importe aussi longtemps que votre navigateur fonctionne pour tout le reste.

Après avoir ouvert la page, allez sur l'onglet "Bot". Vous devriez maintenant voire une page similaire à celle ci-dessous:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Si par hasard la version d'ASF que vous avez téléchargée est plus vieille que le config generator utilise par défaut, choisissez simplement votre version d'ASF dans le menu déroulant. Cela peut se produire (rarement) car le générateur de configuration peut être utilisé pour générer des configurations vers des versions plus récentes (pré-version) ASF qui n'étaient pas encore marquées comme stables. Vous avez téléchargé la dernière version stable d'ASF qui est vérifiée pour fonctionner de manière fiable, donc il peut être un peu plus ancien que la version absolue à l'avant-garde, ce qui n'est absolument pas adapté pour la première utilisation.

Commencez par **mettant le nom de votre bot** dans le champ en surbrillance comme rouge, appelé `Name`. Cela peut être n'importe quel nom que vous souhaitez utiliser, comme votre pseudo, votre nom de compte, un numéro ou autre chose. Il n'y a qu'un seul mot que vous ne pouvez pas utiliser, `ASF`, car ce mot clé est réservé au fichier de configuration global. En plus de cela, votre nom de bot ne peut pas commencer par un point (ASF ignore intentionnellement ces fichiers). Nous vous recommandons également d'éviter d'utiliser des espaces, vous pouvez utiliser `_` comme séparateur de mots si nécessaire - pas une exigence stricte, mais vous aurez du mal à utiliser les commandes ASF autrement.

Le nom du bot a été choisi ? Génial, dans l'étape suivante, **changer `Activer` pour être allumé**, que vous définissez si votre bot est censé être démarré automatiquement par ASF après le lancement (du programme). Ne pas faire cela entraînera ASF à déclarer que votre bot est désactivé dans le fichier de configuration, et il attendra que votre entrée commence, ce qui n'est pas ce que nous voulons faire dans cet exemple.

Maintenant, il y a deux propriétés sensibles à venir : `SteamLogin` et `SteamPassword`. Vous pouvez prendre une autre décision ici - soit vous pouvez mettre vos identifiants de connexion Steam dans ces deux propriétés, ou vous pouvez décider de ne pas faire cela, en les laissant vides.

ASF a besoin de vos identifiants de connexion, car il inclut sa propre implémentation du client Steam et a besoin des mêmes détails pour se connecter que celui que vous utilisez. Vos identifiants de connexion ne sont enregistrés nulle part, mais sur votre PC dans le répertoire de configuration `` ASF uniquement (lorsque vous téléchargez la configuration générée). Notre générateur de configuration web est une application basée sur le client, ce qui signifie que tout ce que vous faites à l'intérieur de notre site web de générateur de configuration Web autonome s'exécute localement dans votre navigateur pour générer des configurations ASF valides, sans les détails que vous saisissez jamais de quitter votre PC en premier lieu, il n'y a donc pas besoin de s'inquiéter de toute fuite de données sensibles. Néanmoins, si vous pour quelque raison que ce soit ne voulez pas y mettre vos identifiants, nous comprenons cela, et vous pouvez les mettre manuellement plus tard dans les fichiers générés, ou les omettre entièrement et fonctionner sans eux.

Si vous décidez de saisir vos identifiants, ASF sera en mesure de se connecter automatiquement au démarrage, qui, avec l'option 2FA optionnelle, vous permettra effectivement de double-cliquer sur le programme pour tout exécuter. If you decide to omit them, then ASF will **ask you** to input those details when needed - that approach won't save them anywhere, but naturally ASF won't be able to operate without your help. C'est à vous de choisir la façon dont vous préférez plus, et vous pouvez également trouver des informations supplémentaires dans la section **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** , comme d'habitude.

Comme note secondaire, vous pouvez également décider de ne laisser qu'un seul champ vide, comme `SteamPassword`. ASF pourra alors utiliser votre connexion automatiquement, mais demandera quand même un mot de passe (similaire à Steam Client). Si par hasard vous utilisez le code d'accès parental à 4 chiffres pour déverrouiller votre compte, nous vous recommandons également de le mettre dans la boîte `SteamParentalPin` , bien que dans ce cas, vous pouvez simplement laisser ce vide et plutôt observer à quel point cette protection est faible, parce qu'ASF peut également le "craquer" lui-même en quelques secondes après sa connexion. Oups.

Après avoir suivi avec tout ce qui précède, donc une fois de plus, **nom de bot**, **activé le commutateur**, et **identifiants de connexion** , votre page web va maintenant ressembler à celle ci-dessous:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Vous pouvez maintenant cliquer sur le bouton "télécharger" et notre générateur de configuration web générera un nouveau fichier `json` en fonction du nom de votre choix. Enregistrez ce fichier dans le répertoire `config` qui se trouve dans le dossier à l'intérieur duquel vous avez extrait le fichier zip à l'étape précédente.

Félicitations ! Vous venez de terminer la configuration basique du bot ASF. Il y a beaucoup plus à découvrir, mais pour l'instant c'est tout ce dont vous avez besoin.

---

### Exécution d'ASF

Je sais que vous attendiez ce moment, et nous ne pouvons pas vous tenir plus longtemps, car vous êtes maintenant prêt à lancer le programme pour la première fois. Simply double-click `ArchiSteamFarm` binary in ASF directory. Vous pouvez également le démarrer à partir de la console.

Maintenant, il serait bon de revoir notre section **[de communication à distance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** si vous êtes préoccupé par des choses que ASF est programmé à faire, en particulier les actions qu'il prendra en votre nom, comme rejoindre notre groupe Steam par défaut. Vous pouvez toujours désactiver les fonctionnalités sélectionnées plus tard si vous ne les aimez pas, ASF vient simplement avec des valeurs par défaut sensibles, et nous avons dû prendre une décision concernant l'utilisation générale qui s'applique à la majorité de notre base d'utilisateurs, ainsi que notre propre point de vue sur le programme dans son principe.

En supposant que tout s'est bien passé, ce qui prend en considération l'installation de toutes les dépendances requises dans la première étape, et en configurant ASF dans le troisième, ASF devrait se lancer correctement, découvrir votre premier bot et essayer de se connecter:

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF nécessitera probablement encore un détail supplémentaire de votre part - 2FA pour accéder au compte (sauf si vous avez complètement désactivé SteamGuard, puis non). Suivez simplement les instructions à l'écran, vous pouvez fournir du code à partir de l'authentificateur/e-mail ou accepter la confirmation dans l'application mobile.

Quelque chose s'est mal passé ?

#### ASF ne démarre pas du tout, aucune fenêtre de console

Soit il vous manque les pré-requis .NET, soit vous avez téléchargé une variante incorrecte d'ASF pour votre machine. Si vous ne savez pas ce qui ne va pas, consultez notre FAQ **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** pour trouver un moyen de trouver le problème exact, et si vous êtes encore bloqué, rejoignez notre **[support](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### Aucun bot défini

Vous n'avez pas mis la configuration générée dans le répertoire `config`. D'autres erreurs courantes dans cette étape peuvent inclure le changement manuel de l'extension de `.json` par exemple à `. xt`, et certains systèmes d'exploitation (par ex. Windows) aiment cacher les extensions courantes par défaut, donc assurez-vous que votre fichier est au bon endroit et aussi avec le nom approprié.

#### Ne pas démarrer ce bot car il est désactivé dans le fichier de configuration

Vous avez oublié de retourner le commutateur `Activé` qui dit à ASF de démarrer votre bot automatiquement. Unless that was your intention of course, but then you should already know how to execute commands, simply `start` your bot after that message.

#### `Mot de passe incorrect`

Vos identifiants de connexion sont probablement erronés. Vérifiez votre `SteamLogin` et `SteamPassword` dans la configuration générée, si elles sont incorrectes, corrigez-les en revenant à l'étape de configuration. Si vous rencontrez encore des problèmes, essayez d'utiliser les mêmes identifiants de connexion dans votre propre client Steam - vous ne devriez pas non plus vous connecter, et vous obtiendrez peut-être plus d'informations sur ce qui ne va pas de cette façon.

#### « Très bien? »

Après avoir passé par la porte de connexion initiale, en supposant que vos informations sont correctes, vous vous connecterez avec succès et ASF commencera le farming en utilisant les paramètres par défaut que vous n'avez pas touché à partir de maintenant:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Cela prouve qu'ASF fait désormais son travail avec succès sur votre compte, de sorte que vous pouvez maintenant minimiser le programme et faire autre chose. Allez-y, vous le méritez, peut-être remplissez au moins cette boisson de votre choix!

Les cartes de agriculture sont un sujet pour un autre article long comme celui-ci, mais en principe : après assez de temps (selon les performances **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), vous verrez que les cartes de trading Steam sont lentement abandonnées. Bien sûr, pour que cela se produise, vous devez avoir des jeux à la ferme, montrant comme "vous pouvez obtenir X gouttes de cartes supplémentaires en jouant à ce jeu" sur votre page de badges **[](https://steamcommunity.com/my/badges)** - s'il n'y a pas de jeux à fermer, alors ASF indiquera qu'il n'y a rien à faire, comme indiqué dans notre FAQ **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, qui répond aux questions les plus fréquentes des gens à ce stade, se demandant pourquoi malgré la possession de 14 jeux sur leur compte, ASF affirme qu'il n'y a rien à faire - non, ce n'est pas un bug.

Ceci conclut notre guide de mise en place très basique. Comme dans chaque jeu de RPG, vous avez terminé le tutoriel, et nous vous laissons le monde entier d'ASF à explorer maintenant. Par exemple, vous pouvez maintenant décider si vous voulez configurer davantage ASF ou le laisser faire son travail dans les paramètres par défaut. Nous aborderons quelques détails de base si vous souhaitez en lire un peu plus, puis laissez-vous le wiki entier pour le découvrir.

---

### Configuration étendue

#### Fermer plusieurs comptes à la fois

ASF prend en charge le développement de plusieurs comptes à la fois, ce qui est sa fonction principale. Vous pouvez ajouter plus de comptes à ASF en générant plus de fichiers de configuration du bot. exactement de la même manière que vous avez généré votre premier il y a quelques minutes à peine. Vous devez vous assurer seulement deux choses:

- Nom unique du bot, si vous avez déjà votre premier bot nommé `Compte principal`, vous ne pouvez pas en avoir un autre avec le même nom.
- Informations de connexion valides, telles que `SteamLogin`, `SteamPassword` et `SteamParentalCode` (si vous avez décidé de les remplir)

En d'autres termes, sautez simplement à nouveau à la configuration et faites exactement la même chose, juste pour votre deuxième ou troisième compte. N'oubliez pas d'utiliser des noms uniques pour tous vos bots, pour ne pas écraser les configurations existantes.

---

#### Modification des paramètres

Dans notre générateur de configuration web autonome, vous modifiez les paramètres existants exactement de la même manière - en générant un nouveau fichier de configuration. Cliquez sur "activer/désactiver les paramètres avancés" et voyez ce qu'il y a à découvrir. Dans cet exemple, nous allons changer le paramètre `CustomGamePlayedWhileFarming` , qui vous permet de définir un nom personnalisé affiché lorsque ASF est en train de fermer, au lieu de montrer le jeu réel.

Commençons par analyser un peu avant. Si vous exécutez ASF et que vous commencez à le fermer, dans les paramètres par défaut, vous verrez que votre compte Steam est en jeu maintenant :

![Steam](https://i.imgur.com/1VCDrGC.png)

Cela a du sens, après que tout ASF vient de dire à la plateforme Steam que nous jouons au jeu, nous avons besoin de cartes, non ? Mais bon, nous pouvons personnaliser ça ! Activer/désactiver les paramètres avancés si vous n'avez pas encore terminé, puis trouvez `CustomGamePlayedWhileFarming`. Il suffit de mettre tout texte personnalisé que vous voulez y afficher, tel que "Cartes de ralliement":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Téléchargez maintenant le nouveau fichier de configuration exactement de la même manière, puis **écrasez** votre ancien fichier de configuration avec le nouveau. Vous pouvez également supprimer votre ancien fichier de configuration et en mettre le nouveau à sa place bien sûr.

ASF est assez intelligent et devrait remarquer que vous avez modifié la configuration, qui devrait alors être automatiquement ramassée et appliquée, sans redémarrage du programme. Si par hasard cela ne s'est pas produit, vous pouvez simplement redémarrer le programme pour vous assurer que votre nouvelle configuration est récupérée. Après avoir fait cela, vous devriez noter qu'ASF affiche maintenant votre texte personnalisé à la place précédente:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

Ceci confirme que vous avez modifié votre configuration avec succès. De la même manière, vous pouvez modifier les propriétés ASF globales en passant de l'onglet bot à l'onglet "ASF", en téléchargeant les fichiers ASF générés `ASF. son` fichier de configuration et le mettre dans votre dossier `config`.

Modifier vos configurations ASF peut être fait beaucoup plus facilement en utilisant notre interface ASF-ui, qui sera expliquée plus loin ci-dessous.

---

#### Utiliser ASF-ui

Comme nous l'avons mentionné précédemment, ASF est une application console et ne lance pas une interface utilisateur graphique par défaut. Cependant, nous travaillons activement sur le frontend **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** de notre interface IPC, qui peut être un moyen très décent et très convivial d'accéder à diverses fonctionnalités ASF.

Pour utiliser ASF-ui, vous devez avoir `IPC` activé, qui est l'option par défaut, donc si vous ne la désactivez pas manuellement, elle est déjà active. Une fois que vous avez lancé ASF, vous devriez être en mesure de confirmer qu'il a correctement démarré l'interface IPC automatiquement :

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC, en un mot, est le serveur web d'ASF intégré qui démarre localement sur votre machine, vous permettant d'interagir avec elle à l'aide de votre navigateur Web favori. En supposant qu'il ait démarré correctement, vous pouvez accéder à l'interface IPC d'ASF en cliquant sur **[ce lien](http://localhost:1242)** , tant qu'ASF est en cours d'exécution, depuis la même machine. Vous pouvez utiliser ASF-ui à des fins diverses, par exemple éditer les fichiers de configuration en place ou envoyer des commandes **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. N’hésitez pas à jeter un coup d’œil pour découvrir toutes les fonctionnalités d’ASF-ui.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Résumé

Vous avez configuré ASF avec succès pour utiliser vos comptes Steam et vous l'avez déjà personnalisé à votre goût. Si vous avez suivi l'ensemble de notre guide, vous avez également réussi à modifier ASF à travers notre interface ASF-ui et vous avez commencé à découvrir ses fonctionnalités. Ceci conclut notre tutoriel, mais nous vous laissons avec quelques pointeurs supplémentaires vers des choses qui pourraient vous intéresser, "quêtes secondaires", si vous insistez:

- Our **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section will explain to you  what **all** those different settings you've seen actually do, and what else ASF can offer to you. Rappelez-vous juste de vous hydrater correctement en lisant, vous avez été averti.
- Si vous avez rencontré un problème ou si vous avez une question générique, considérez notre FAQ **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**, qui devrait couvrir toutes, ou au moins une grande majorité des questions et des questions que vous pourriez avoir.
- Si vous voulez tout apprendre sur ASF et comment cela peut vous faciliter la vie, aller au reste de **[notre wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. Utilisez la barre latérale à droite pour choisir le sujet qui vous intéresse.
- Et enfin, si vous avez découvert que notre programme était utile pour vous et que vous appréciez le travail énorme qui a été investi, vous pouvez également envisager un petit don **[](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** à notre cause. ASF est un travail d'amour, nous travaillons dur pendant notre temps libre depuis plus de 10 ans pour vous permettre cette expérience et nous en sommes très fiers - même $1 est très apprécié et montre que vous aimez. Quoi qu'il en soit, amusez-vous !

---

## Configuration générique

Cette annexe est destinée aux utilisateurs avancés qui souhaitent configurer ASF pour qu'il s'exécute dans une variante **[générique](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)**. Tout en étant plus gênant en utilisation que les variantes **[spécifiques à un système d'exploitation](#os-specific-setup)**, il présente également des avantages supplémentaires.

Vous voulez utiliser une variante `générique` principalement quand:
- Vous utilisez un système d'exploitation pour lequel nous ne construisons pas de paquet spécifique au système d'exploitation (tel que Windows 32 bits)
- Vous avez déjà .NET Runtime/SDK, ou vous voulez en installer et en utiliser un
- Vous voulez minimiser la taille de la structure ASF et l'empreinte mémoire en gérant les exigences d'exécution vous-même
- Vous souhaitez utiliser un plugin **[personnalisé](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** qui nécessite une configuration `générique` d'ASF pour fonctionner correctement (en raison des dépendances natives manquantes)

Bien sûr, vous pouvez également l'utiliser dans n'importe quel autre scénario que vous voulez, mais ce qui précède est le plus sensé.

Cependant, gardez à l'esprit que la configuration générique est fournie avec une torsion - **vous** sont en charge de .NET runtime dans ce cas. Cela signifie que si votre .NET SDK (runtime) est indisponible, obsolète ou cassé, ASF ne fonctionnera tout simplement pas. C'est pourquoi nous ne recommandons absolument pas cette configuration pour les utilisateurs occasionnels, puisque vous devez maintenant vous assurer que votre . ET SDK (runtime) correspond aux exigences ASF et peut exécuter ASF, par opposition à **nous** en nous assurant que notre . ET le runtime fourni avec ASF peut le faire.

Pour le package `générique` , vous pouvez suivre le guide complet spécifique au système d'exploitation ci-dessus, avec seulement deux petites modifications. In addition to installing .NET prerequisites, you also want to install .NET SDK, and instead of downloading and having OS-specific `ArchiSteamFarm(.exe)` executable file, you'll now download and have a generic `ArchiSteamFarm.dll` binary only. Tout le reste est exactement le même.

Avec des étapes supplémentaires:
- Installez **[.NET pré-requis](#net-prerequisites)**.
- Installez **[.NET SDK](https://www.microsoft.com/net/download)** (ou au moins ASP.NET Core et .NET runtimes) approprié à votre OS. Vous devriez probablement utiliser un installateur. Reportez-vous aux exigences d'exécution **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** si vous n'êtes pas sûr de la version à installer.
- Téléchargez la dernière version **[d'ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** dans la variante `générique`.
- Extraire l'archive dans un nouvel emplacement.
- **[Configurer ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, exactement de la même manière que décrite ci-dessus.
- Lancez ASF en utilisant un script d'aide ou en exécutant manuellement `dotnet /path/to/ArchiSteamFarm.dll` depuis votre shell favori.

La variante générique d'ASF n'a pas de binaire spécifique à la machine, après tout, il s'appelle `générique` pour une raison - c'est une version agnostic de la plate-forme qui peut fonctionner partout, donc ne vous attendez pas à un fichier `exe` là.

C'est pourquoi nous l'avons fourni avec des scripts d'aide (comme `ArchiSteamFarm.cmd` pour Windows et `ArchiSteamFarm. h` pour Linux/macOS), qui sont situés à côté du binaire `ArchiSteamFarm.dll`. Vous pouvez les utiliser si vous ne voulez pas exécuter la commande `dotnet` manuellement.

Évidemment, les scripts d'aide ne fonctionneront pas si vous n'installez pas . ET SDK et vous n'avez pas l'exécutable `dotnet` disponible dans votre `PATH`. Ils sont également entièrement optionnels à utiliser, vous pouvez toujours `dotnet /path/to/ArchiSteamFarm. allez` manuellement si vous le souhaitez, comme sous le capot avec quelques ajustements supplémentaires, c'est exactement ce que font ces scripts de toute façon.