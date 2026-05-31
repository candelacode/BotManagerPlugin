# Configuration

Cette page est dédiée à la configuration ASF. Cette documentation complète est pour le répertoire `config`. Vous pouvez ainsi adapter ASF à vos besoins.

* **[Introduction](#introduction)**
* **[Panel Web de configuration](#web-based-configgenerator)**
* **[Configuration ASF-ui](#asf-ui-configuration)**
* **[Configuration Manuelle](#manual-configuration)**
* **[Configuration globale](#global-config)**
* **[Configuration Bot](#bot-config)**
* **[Structures des répertoires](#file-structure)**
* **[JSON mapping](#json-mapping)**
* **[Mode de compatibilité](#compatibility-mapping)**
* **[Compatibilité des configurations](#configs-compatibility)**
* **[Auto-reload](#auto-reload)**

---

## Introduction

La configuration ASF est séparé en deux parties principales : la configuration globale (processus) et la configuration de chaque bot. Chaque bot dispose de son propre fichier de configuration nommé  `BotName.json ` ( `BotName ` est le nom du bot). La que la configuration globale ASF (processus) est un fichier unique nommé  `ASF.json `.

Un bot est un compte unique qui participe au processus ASF. Pour fonctionner correctement, ASF a besoin d’au moins **une** instance de bot définie. Il n'y a pas de limite d'instances de bot imposée par le processus, vous pouvez donc utiliser autant de bots (comptes steam) que vous le souhaitez.

ASF utilise le format **[JSON](https://en.wikipedia.org/wiki/JSON)** pour stocker ses fichiers de configuration. C'est un format convivial, lisible et très universel dans lequel vous pouvez configurer le programme. Ne vous inquiétez pas, vous n'avez pas besoin de connaître JSON pour configurer ASF. Je viens de le mentionner au cas où vous voudriez déjà créer en masse des configurations ASF avec une sorte de script bash.

La configuration peut être faite de plusieurs façons. Vous pouvez utiliser notre ConfigGenerator **[Web ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)**, qui est une application locale indépendante d'ASF. Vous pouvez utiliser notre frontend IPC **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** pour la configuration effectuée directement dans ASF. Enfin, vous pouvez toujours générer des fichiers de configuration manuellement, car ils suivent la structure JSON corrigée spécifiée ci-dessous. Nous vous expliquerons sous peu les options disponibles.

---

## Panel Web de configuration

Le but de notre ConfigGenerator **[basé sur le Web](https://justarchinet.github.io/ASF-WebConfigGenerator)** est de vous fournir une interface conviviale qui est utilisée pour générer des fichiers de configuration ASF. Le Panel Web de configuration est 100% basé sur le client, ce qui signifie que les détails que vous saisissez ne sont envoyés nulle part, mais traités localement uniquement. Cela garantit la sécurité et la fiabilité, car cela peut même fonctionner **[hors connexion](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** si vous souhaitez télécharger tous les fichiers et exécuter `index.html` dans votre navigateur préféré.

Le Panel Web de configuration est vérifié pour fonctionner correctement sur Chrome et Firefox, mais il devrait fonctionner correctement avec la plupart des navigateurs les plus populaires comptabile avec javascript.

L’utilisation est assez simple - indiquez si vous souhaitez générer la configuration `ASF` ou `Bot` en basculant sur l’onglet approprié, assurez-vous que la version choisie du fichier de configuration correspond à votre version ASF, puis saisissez tous les détails et cliquez sur le bouton "télécharger". Déplacez ce fichier dans le répertoire ASF `config`, en écrasant les fichiers existants si nécessaire. Répétez cette procédure pour toutes les modifications ultérieures éventuelles et reportez-vous au reste de cette section pour obtenir une explication de toutes les options disponibles pour la configuration.

---

## Configuration ASF-ui

Notre interface IPC **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** vous permet également de configurer ASF, et est une solution supérieure pour reconfigurer ASF après avoir généré les configurations initiales en raison du fait qu'il peut modifier les configurations en place, par opposition au ConfigGenerator basé sur le Web qui les génère statiquement.

Afin d'utiliser ASF-ui, vous devez avoir activé notre interface **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**. `IPC` est activé par défaut, vous pouvez donc y accéder immédiatement, tant que vous ne l'avez pas désactivé vous-même.

Après avoir lancé le programme, accédez simplement à l'adresse IPC **[d'ASF](http://localhost:1242)**. Si tout a fonctionné correctement, vous pouvez également modifier la configuration ASF.

---

## Configuration Manuelle

En général, nous vous recommandons fortement d'utiliser notre ConfigGenerator ou ASF-ui, car c'est beaucoup plus facile et vous assure que vous ne commettrez pas d'erreur dans la structure JSON, mais si pour une raison quelconque, vous ne le voulez pas, vous pouvez aussi créer des configurations manuellement. Vérifiez les exemples JSON ci-dessous pour un bon départ dans une bonne structure, vous pouvez copier le contenu dans un fichier et l'utiliser comme base pour votre configuration. Puisque vous n’utilisez aucune de nos interfaces, assurez-vous que votre configuration est **[valide](https://jsonlint.com)**, car ASF refusera de la charger si elle ne peut pas être interprétée. Même si c'est un JSON valide, vous devez également vous assurer que toutes les propriétés ont le type approprié, tel que requis par ASF. Pour une bonne structure JSON de tous les champs disponibles, reportez-vous à la section **[JSON mapping](#json-mapping)** et à notre documentation ci-dessous.

---

## Configuration globale

La configuration globale se trouve dans le fichier ASF.json et se présente dans la structure suivante:

```json
{
    "AutoRestart": true,
    "Liste noire": [],
    "CommandPrefix": "! ,
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "CurrentCulture": null,
    "Debug": false,
    "DefaultBot": null,
    "FarmingDelay": 15,
    "FilterBadBots": true,
    "GiftsLimiterDelay": 1,
    "Sans tête": faux,
    "IdleFarmingPeriod": 8,
    "InventoryLimiterDelay": 4,
    "IPC": true,
    "IPCPassword": null,
    "Format IPCPassword: 0,
    "LicenseID": null,
    "Délai de connexion : 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldDuration": 15,
    "MinFarmingDelayAfterBlock": 60,
    "OptimisationMode": 0,
    "PluginsUpdateList": [],
    "PluginsUpdateMode": 0,
    "ShutdownIfPossible": false,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "Canal de mise à jour": 1,
    "Période de mise à jour": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Toutes les options sont expliquées ci-dessous :

### `AutoRestart`

`bool` avec la valeur par défaut `true</ 0>. Cette fonctionnalité définit si ASF est autorisé à effectuer un redémarrage automatique en cas de besoin. Quelques événements nécessiteront un redémarrage automatique de la part d'ASF, tels que la mise à jour d'ASF (effectuée avec la commande <code>UpdatePeriod` ou `update`), ainsi que la `ASF. json` config edit, `restart` et de même. En règle générale, le redémarrage comprend deux parties: créer un nouveau processus et terminer le processus en cours. La plupart des utilisateurs devraient accepter cette option et conserver cette fonction avec la valeur par défaut `true`. Toutefois, si vous exécutez ASF avec votre propre script et / ou avec `dotnet`, vous voudrez peut-être avoir le contrôle total sur le démarrage du processus et éviter une situation telle que l'exécution d'un nouveau processus ASF (redémarré) quelque part en silence en arrière-plan et non au premier plan du script, qui s'est terminé avec l'ancien processus ASF. Ceci est particulièrement important compte tenu du fait que le nouveau processus ne sera plus votre fonction direct, ce qui vous rendrait incapable, par exemple d'utiliser une entrée de console standard pour cela.

Si tel est le cas, cette fonction est spécialement conçue pour vous et vous pouvez la définir sur `false</ 0>. Cependant, gardez à l'esprit que dans ce cas, <strong x-id="1">vous</strong> êtes responsable du redémarrage du processus. C’est important car ASF se ferme uniquement au lieu de créer un nouveau processus (par exemple, après la mise à jour). Ainsi, si aucune logique n’est ajoutée par vous, il cessera tout simplement de fonctionner jusqu’à ce que vous le redémarriez. ASF se ferme toujours avec le code d'erreur correct indiquant succès (zéro) ou non succès (différent de zéro). Vous pouvez ainsi ajouter une logique appropriée dans votre script, ce qui devrait éviter le redémarrage automatique d'ASF en cas d'échec, ou du moins créez une copie locale de <code>log.txt` pour une analyse plus approfondie. Notez également que la commande `restart` redémarre toujours ASF, quel que soit le mode de définition de cette fonction, car cette  fonction définit le comportement par défaut, tandis que la commande `restart` redémarre toujours le processus. Sauf si vous avez une raison de désactiver cette fonctionnalité, vous devez la laisser activée.

---

### `Liste noire`

`ImmutableHashSet<uint>` avec la valeur par défaut étant vide. Comme le nom le suggère, cette propriété de configuration globale définit les appIDs (jeux) qui seront entièrement ignorés par le processus de farming automatique ASF. Malheureusement, Steam adore désigner les badges de soldes d’été / hiver comme étant "disponibles pour des cartes à obtenir", ce qui induit en erreur le processus ASF en lui faisant croire que c’est un jeu valable qui mérite d’être cultivé. S'il n'y avait aucune sorte de liste noire, ASF finirait par "bloquer" le farming d'un jeu qui n'est en fait pas un jeu, et attendrait infiniment que les cartes tombent. La liste noire ASF a pour but de marquer ces badges comme étant non disponibles pour le farming. Nous pouvons donc les ignorer en silence lorsque nous décidons d’agir, et ne pas tomber dans le piège.

ASF inclut deux listes noires par défaut - `Liste noire`, qui est codé en dur dans le code ASF et qui n'est pas possible à modifier, et la liste noire normale ``, qui est définie ici. `La liste noire` est mise à jour avec la version ASF et inclut généralement tous les « mauvais» identifiants d'applications au moment de la publication, donc si vous utilisez ASF à jour, vous n'avez pas besoin de maintenir votre propre `liste noire` définie ici. Le but principal de cette propriété est de vous permettre de mettre en liste noire de nouveaux identificateurs d’application non connus au moment de la publication d'une nouvelle version ASF, qui ne doivent pas être mis en farming. La `SalesBlacklist` codée en dur est mise à jour aussi rapidement que possible. Vous n’êtes donc pas obligé de mettre à jour votre propre `Blacklist` si vous utilisez la dernière version d’ASF. Cependant, sans `Blacklist`, vous seriez obligé de mettre à jour ASF pour continuer à fonctionner lorsque Valve publiera un nouveau badge de vente. Je ne souhaite pas vous forcer à utiliser le dernier code d’ASF ; cette propriété existe donc pour vous permettre de « corriger » ASF vous-même si, pour une raison quelconque, vous ne voulez pas ou ne pouvez pas mettre à jour la `SalesBlacklist` codée en dur dans une nouvelle version d’ASF, tout en continuant à utiliser votre ancienne version d’ASF. À moins que vous n'ayez une raison **forte** de modifier cette fonction, vous devez la conserver par défaut.

Si vous recherchez plutôt une liste noire basée sur le bot, jetez un coup d'œil à `fb`, `fbadd` et `fbrm` **[commandes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `CommandPrefix`

`chaîne` avec la valeur par défaut `!`. Cette fonction spécifie **le préfixe** sensible à la case utilisé pour les **[commandes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** ASF. En d’autres termes, c’est ce que vous devez ajouter à chaque commande ASF pour que ASF vous écoute. Il est possible de définir cette valeur sur `null` ou sur une valeur vide pour que ASF n’utilise aucun préfixe de commande. Dans ce cas, vous devez entrer des commandes avec leurs identificateurs simples. Cela risque toutefois de réduire les performances d'ASF, car ASF est optimisé pour ne plus analyser le message s'il ne commence pas par `CommandPrefix` - si vous décidez intentionnellement de ne pas l'utiliser, ASF sera forcé de tout lire. messages et y répondre, même s’ils ne sont pas des commandes ASF. Par conséquent, il est recommandé de continuer à utiliser des `CommandPrefix`, tels que `/` si vous n'aimez pas la valeur par défaut de `!`. Par souci de cohérence, `CommandPrefix` affecte l’ensemble du processus ASF. Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

### `ConfirmationsLimiterDelay`

`byte` avec la valeur par défaut `10`. ASF s'assurera qu'il y aura au moins `ConfirmationsLimiterDelay` secondes entre deux confirmations 2FA consécutives pour extraire les requêtes afin d'éviter de déclencher une limite de débit - celles-ci sont utilisées par **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** pendant l'événement. `commande 2faok` ainsi que sur la base des besoins lors de l'exécution de diverses opérations liées au trading. La valeur par défaut a été définie en fonction de nos tests et ne doit pas être réduite si vous ne voulez pas rencontrer de problèmes. À moins que vous n'ayez une raison **forte** de modifier cette fonction, vous devez la conserver par défaut.

---

### `ConnectionTimeout`

`byte` avec la valeur par défaut `90`. Cette propriété définit les délais d'attente pour diverses actions réseau effectuées par ASF, en secondes. En particulier, `ConnectionTimeout` définit le délai d'expiration en secondes pour les demandes HTTP et IPC, `ConnectionTimeout / 10 ` définit le nombre maximal de pulsations manquées, tandis que `ConnectionTimeout / 30 ` définit le nombre de minutes que nous autorisons pour la demande initiale de connexion au réseau Steam. La valeur par défaut de `90` devrait convenir à la majorité des gens. Toutefois, si vous avez une connexion réseau ou un PC plutôt lent, vous souhaiterez peut-être augmenter ce nombre (par exemple, `120</0 >). Gardez à l'esprit que de plus grandes valeurs ne résoudront pas comme par magie des serveurs Steam lents ou même inaccessibles. Nous ne devrions donc pas attendre indéfiniment quelque chose qui ne se produira pas et simplement réessayer ultérieurement. Si vous définissez cette valeur sur une valeur trop élevée, cela entraînera un retard excessif dans la résolution des problèmes de réseau, ainsi que dans une diminution des performances globales. Si vous définissez cette valeur sur une valeur trop basse, la stabilité et les performances globales seront également réduites, car ASF abandonnera les requêtes valides en cours d'analyse. Par conséquent, définir cette valeur sur une valeur inférieure à celle par défaut ne présente généralement aucun avantage, car les serveurs Steam ont tendance à être lents de temps en temps et peuvent nécessiter plus de temps pour l'analyse des demandes ASF. La valeur par défaut est un équilibre entre croire que notre connexion réseau est stable et douter du réseau Steam pour traiter notre demande dans un délai indiqué. Si vous souhaitez détecter les problèmes plus rapidement et permettre à ASF de se reconnecter / répondre plus rapidement, la valeur par défaut convient (ou très légèrement en dessous, par exemple <code>60`, rendant ASF moins patient). Si vous remarquez au contraire qu'ASF a des problèmes de réseau, tels que des requêtes en échec, la perte de pulsations ou la connexion à Steam interrompue, il peut être judicieux d'augmenter cette valeur si vous êtes sûr que cela n'est **pas** via votre réseau, mais par Steam lui-même, à mesure que les délais dépassent, ASF devient plus "patient" et ne décide pas de se reconnecter immédiatement.

Un exemple de situation qui pourrait nécessiter une augmentation de cette propriété est de laisser ASF gérer une très grande offre commerciale qui peut prendre plus de 2 minutes pour être totalement acceptée et gérée par Steam. En augmentant le délai par défaut, ASF sera plus patient et attendra plus longtemps avant de décider que la transaction n’est pas en cours et abandonnera la demande initiale.

Une autre situation pourrait être causée par une machine très lente ou une connexion Internet qui nécessite plus de temps pour traiter les données transmises. C'est assez rare, car la bande passante CPU/réseau n'est presque jamais un goulot d'étranglement, mais il est toujours possible de le mentionner.

En bref, la valeur par défaut devrait être convenable dans la plupart des cas, mais vous pouvez l’augmenter si nécessaire. Néanmoins, aller au-delà de la valeur par défaut n’a pas de sens, car des délais plus longs ne résoudront pas comme par magie des serveurs Steam inaccessibles. Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

### `CurrentCulture`

`chaîne` avec la valeur par défaut `null`. Par défaut, ASF tente d'utiliser la langue de votre système d'exploitation et préférera utiliser les chaînes traduites dans cette langue si elles sont disponibles. Ceci est possible grâce à notre communauté qui tente de **[traduire](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** ASF dans toutes les langues les plus populaires. Si, pour une raison quelconque, vous ne souhaitez pas utiliser la langue native de votre système d'exploitation, vous pouvez utiliser cette propriété de configuration pour sélectionner une langue valide que vous souhaitez utiliser. Pour obtenir une liste de toutes les langues disponibles, visitez **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** et recherchez `Langage tag`. Il est agréable de noter qu'ASF accepte les deux cultures spécifiques, telles que `"en-GB"`, mais aussi les neutres, comme `"en"`. La spécification de la langue actuelle peut également affecter d'autres comportements spécifiques à la langues, tels que le format de date/heure et autres. Notez que vous aurez peut-être besoin de packs de polices / langues supplémentaires pour afficher correctement les caractères spécifiques à une langue, si vous avez sélectionné une langue non native qui les utilise. Généralement, vous souhaitez utiliser cette fonction de configuration si vous préférez ASF en anglais plutôt que dans votre langue maternelle.

---

### `Debug`

`bool` avec la valeur par défaut `false`. Cette propriété définit si le processus doit être exécuté en mode debug. En mode débogage, ASF crée un répertoire spécial `debug` à côté de la `config`, qui assure le suivi de l'ensemble de la communication entre les serveurs ASF et Steam. Les informations de debug peuvent aider à détecter des problèmes épineux liés à la mise en réseau et au flux de travail ASF général. En outre, certaines routines de programme seront beaucoup plus détaillées, telles que `WebBrowser` indiquant la raison exacte pour laquelle certaines demandes échouent: ces entrées sont écrites dans le journal ASF normal. **Vous ne devez pas exécuter ASF en mode debug, à moins que le développeur ne vous le demande**. L'exécution d'ASF en mode debug **diminue les performances**, **affecte négativement la stabilité** et est **beaucoup plus détaillé à divers endroits**. Il doit donc être utilisé **uniquement** intentionnellement, à court terme, pour debug un problème particulier, reproduire le problème ou obtenir plus d’informations sur une demande en échec, mais de la même manière, mais **pas** pour l’exécution normale du programme. Vous verrez **beaucoup** de nouvelles erreurs, problèmes et exceptions - assurez-vous d'avoir une bonne connaissance d'ASF, de Steam et de ses bizarreries si vous décidez d'analyser tout cela vous-même.

**AVERTISSEMENT:** l'activation de ce mode inclut la journalisation d'informations **potentiellement sensibles** telles que les identifiants de connexion et les mots de passe que vous utilisez pour vous connecter à Steam (en raison de la journalisation réseau). Ces données sont écrites dans le répertoire `debug`, ainsi que dans le fichier standard `log.txt` (qui est maintenant beaucoup plus détaillé pour consigner ces informations). Vous ne devez pas publier de contenu de debug  généré par ASF dans un emplacement public, le développeur ASF doit toujours vous rappeler de l'envoyer à son adresse e-mail ou à un autre emplacement sécurisé. Nous ne stockons pas, ni n'utilisons ces détails sensibles, ils sont écrits dans le cadre de routines de debug, car leur présence peut être pertinente pour le problème qui vous concerne. Nous préférerions ne pas modifier la journalisation ASF de quelque manière que ce soit, mais si vous êtes inquiet, vous êtes libre de rédiger ces informations sensibles de manière appropriée.

> La rédaction implique le remplacement de détails sensibles, par exemple par des étoiles. Vous devez vous abstenir de supprimer entièrement les lignes sensibles, car leur existence pure pourrait être pertinente et devrait être préservée.

---

### `Bot par défaut`

`chaîne` avec la valeur par défaut `null`. Dans certains scénarios, ASF fonctionne avec un concept de bot par défaut responsable de la gestion de quelque chose - par exemple des commandes IPC ou une console interactive lorsque vous ne spécifiez pas le bot cible. Cette propriété vous permet de choisir le bot par défaut chargé de gérer ce type de situation, en indiquant son `BotName` ici. Si le bot donné n'existe pas, ou si vous utilisez une valeur par défaut de `null`, ASF choisira le premier bot enregistré trié par ordre alphabétique. Généralement, vous voulez utiliser cette propriété de configuration si vous voulez omettre l'argument `[Bots]` dans IPC et les commandes interactives de console, et toujours choisir le même bot que celui par défaut pour de tels appels.

---

### `FarmingDelay`

`byte` avec la valeur par défaut `15`. Pour que ASF fonctionne, il vérifiera la partie actuellement exploitée toutes les `FarmingDelay`, s'il a peut-être déjà obtenus toutes les cartes. Si vous définissez cette fonction sur une valeur trop basse, le nombre de demandes de Steam envoyées sera excessif. Si vous la définissez trop haut, ASF continuera à "farmer" le titre en cours jusqu'à `FarmingDelay` minutes après la fin de son exploitation. La valeur par défaut devrait être excellente pour la plupart des utilisateurs, mais si vous avez beaucoup de bots en cours d'exécution, vous pouvez envisager de l'augmenter à quelque chose comme ` 30 ` minutes afin de limiter les demandes d'envoi envoyées. Il est agréable de noter que ASF utilise un mécanisme basé sur les événements et vérifie la page de badge du jeu sur chaque objet Steam obtenu. Par conséquent, en général **nous n’avons même pas besoin de le vérifier à des intervalles de temps fixes**. Ne faites pas entièrement confiance au réseau Steam - de toute façon, nous vérifions la page des badges de jeu. Si nous ne l’avons pas vérifiée au cours du dernier `FarmingDelay` (dans le cas où le réseau Steam ne nous informerait pas de l’élément obtenu ou des trucs comme ça). En supposant que le réseau Steam fonctionne correctement, diminuer cette valeur **n'améliorera en aucun cas l'efficacité du farming**, tandis que **augmentera considérablement la surcharge du réseau** - il est recommandé de l'augmenter uniquement (si nécessaire). par défaut de `15` minutes. À moins que vous n'ayez une raison **forte** de modifier cette fonction, vous devez la conserver par défaut.

---

### `FiltreBadBots`

`bool` avec la valeur par défaut `true</ 0>. Cette fonction définit si ASF refusera automatiquement les offres commerciales reçues de mauvais acteurs connus et marqués. Pour ce faire, ASF communiquera avec notre serveur au besoin pour récupérer une liste des identificateurs Steam sur la liste noire. Les robots répertoriés sont exploités par des personnes qui sont classées comme nuisibles à l’initiative ASF par nous, tels que ceux qui violent notre code de conduite <strong x-id="1"><a href="https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md"></a></strong>, utiliser les fonctionnalités et les ressources fournies par nous telles que <strong x-id="1"><a href="https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting"><code>PublicListing`</a></strong> afin d'abuser et d'exploiter d'autres personnes. ou se livrent à des activités criminelles telles que lancer des attaques DDoS sur le serveur. Étant donné qu'ASF a une position ferme sur l'équité, l'honnêteté et la coopération globale entre ses utilisateurs afin de faire prospérer toute la communauté, cette propriété est activée par défaut, et donc les robots de filtrage ASF que nous avons classés comme nuisibles par rapport aux services offerts. Sauf si vous avez une raison **forte** pour modifier cette propriété, comme être en désaccord avec notre déclaration et permettre intentionnellement à ces bots de fonctionner (y compris l'exploitation de vos comptes), vous devriez le garder par défaut.

---

### `GiftsLimiterDelay`

`byte` avec la valeur par défaut `1`. ASF veillera à ce qu'il y ait au moins `GiftsLimiterDelay` deux secondes entre deux demandes consécutives de traitement cadeau / clé / licence (utilisation) afin d'éviter de déclencher une limite de débit. En plus de cela, il sera également utilisé comme limiteur global pour les requêtes de listes de jeux, telle que celle émise par `possède la commande` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Sauf si vous avez une raison **forte** pour modifier cette propriété, vous devez la conserver par défaut.

---

### `Headless`

`bool` avec la valeur par défaut `true</ 0>. Cette propriété définit si le processus doit être exécuté en mode headless. En mode sans tête, ASF suppose qu'il fonctionne sur un serveur ou dans un autre environnement non interactif, , il n'essaiera donc pas de lire des informations à travers l'entrée de la console. Cela inclut les détails à la demande (identifiants de compte tels que le code 2FA, le code SteamGuard, mot de passe ou toute autre variable requise pour que ASF fonctionne) ainsi que toutes les autres entrées de console (comme la console de commande interactive). En d'autres termes, le mode <code>Headless` équivaut à rendre la console ASF en lecture seule. Ce paramètre est principalement utile pour les utilisateurs qui utilisent ASF sur leurs serveurs, au lieu de le demander. . - Pour le code 2FA, ASF annulera silencieusement l’opération en arrêtant un compte. À moins que vous n'exécutiez ASF sur un serveur, et que vous ayez précédemment confirmé qu'ASF est en mesure de fonctionner en mode non-headless vous devriez garder cette propriété désactivée. Toute interaction avec l’utilisateur sera refusée en mode sans interface, et vos comptes ne fonctionneront pas s’ils nécessitent **une** saisie au démarrage. Ceci est utile pour les serveurs, car ASF peut interrompre la tentative de connexion au compte quand il est demandé des identifiants, au lieu d'attendre (infiniment) que l'utilisateur les fournisse.

Activer ce mode vous permettra de fournir la saisie de la console par d'autres moyens, c.-à-d. ASF-ui (API ASF), ou via la commande **[`entrée`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#input-command)**. Si vous n'êtes pas sur du réglage de cette propriété, laissez-la à la valeur par défaut de `false`.

---

### `IdleFarmingPeriod`

`byte` avec la valeur par défaut `8`. Quand ASF n'a rien à exploiter, il vérifiera périodiquement toutes les heures `IdleFarmingPeriod` si peut-être un compte a mis de nouveaux jeux à la ferme. Cette fonctionnalité n'est pas nécessaire lorsque nous parlons de nouveaux jeux que nous recevons, car ASF est suffisamment intelligent pour vérifier automatiquement les pages de badge dans ce cas. `IdleFarmingPeriod` est principalement pour des situations telles que les vieux jeux que nous avons déjà des cartes de trading ajoutées. Dans ce cas, il n’y a aucun événement. ASF doit donc vérifier périodiquement les pages de badges si nous voulons que cela soit couvert. La valeur de `0` désactive cette fonctionnalité. Vérifiez également : `ShutdownOnFarmingFinished` préférence dans `FarmingPreferences`.

---

### `InventoryLimiterDelay`

`octet` type avec la valeur par défaut de `4`. ASF s'assurera qu'il y aura au moins `InventoryLimiterDelay` secondes entre deux requêtes consécutives d'inventaire web pour éviter de déclencher une limite de débit - celles-ci sont utilisées par exemple lors du marquage des notifications d'inventaire comme lues, peut également être utilisé par des plugins tiers qui récupèrent l'inventaire d'autres utilisateurs. Cette propriété n'est pas utilisée pour récupérer notre propre inventaire, car ASF utilise un appel interne beaucoup plus efficace pour cela, donc cela n'affectera pas les commandes comme `loot` ou `transfer` de quelque manière que ce soit. La valeur par défaut de `4` a été définie en fonction des inventaires de plus de 100 instances de bot consécutives, et devrait satisfaire la plupart (si pas tous) des utilisateurs. Vous pouvez cependant vouloir le diminuer, ou même passer à `0` si vous avez une très faible quantité de bots, ASF ignorera donc le délai et marquera les inventaires Steam beaucoup plus rapidement. Attention toutefois: si vous le réglez trop bas, **cela** entraînera une suspension temporaire de votre IP par Steam, ce qui vous empêchera d’effectuer la moindre requête. Vous pourriez également avoir besoin d'augmenter cette valeur si vous exécutez beaucoup de bots avec beaucoup de requêtes d'inventaire, bien que dans ce cas, vous devriez probablement essayer de limiter le nombre de ces requêtes. À moins que vous n'ayez une raison **forte** de modifier cette fonction, vous devez la conserver par défaut.

---

### `IPC`

`bool` avec la valeur par défaut `true</ 0>. Cette fonction définit si le serveur <strong x-id="1"><a href="https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC">IPC</a></strong> d'ASF doit démarrer en même temps que le processus. IPC permet la communication inter-processus, y compris l'utilisation de <strong x-id="1"><a href="https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui">ASF-ui</a></strong>, en amorçant un serveur HTTP local. Si vous n'avez pas l'intention d'utiliser une intégration IPC tierce avec ASF, y compris notre ASF-ui, vous pouvez désactiver cette option en toute sécurité. Sinon, c'est une bonne idée de le garder activé (option par défaut).</p>

<hr />

<h3 spaces-before="0"><code>IPCPassword`</h3>

`chaîne` avec la valeur par défaut `null`. Cette propriété définit le mot de passe obligatoire pour chaque appel API effectué via IPC et sert de mesure de sécurité supplémentaire. Lorsqu'elle est définie à une valeur non vide, toutes les requêtes IPC nécessiteront la propriété `mot de passe` supplémentaire définie sur le mot de passe spécifié ici. La valeur par défaut de `null` ignorera la nécessité du mot de passe, ce qui fera qu'ASF respecte toutes les requêtes. De plus, activer cette option active également le mécanisme anti-bruteforce intégré d’IPC, qui bannira temporairement l’`IPAddress` concernée après l’envoi d’un trop grand nombre de requêtes non autorisées en très peu de temps. Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

### `Format du mot de passe IPC`

`byte` avec la valeur par défaut `0`. Cette propriété définit le format de la propriété `IPCPassword` et utilise `EHashingMethod` comme type sous-jacent. Veuillez vous référer à la section **[Sécurité](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** si vous voulez en savoir plus, car vous devrez vous assurer que la propriété `IPCPassword` inclut effectivement le mot de passe dans la correspondance `IPCPasswordFormat`. En d'autres termes, lorsque vous changez `IPCPasswordFormat` alors votre `IPCPassword` devrait être **déjà** dans ce format, pas seulement visé à être. À moins que vous ne sachiez ce que vous faites, vous devriez le conserver avec la valeur par défaut de `0`.

---

### `ID de licence`

`Guide ?` type avec valeur par défaut de `null`. Cette propriété permet à nos sponsors **[](https://github.com/sponsors/JustArchi)** d'améliorer ASF avec des fonctionnalités facultatives qui nécessitent des ressources payantes pour fonctionner. Pour l'instant, cela vous permet d'utiliser la fonctionnalité **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** dans le plugin `ItemsMatcher`.

Bien que nous vous recommandons d'utiliser GitHub car il offre des niveaux mensuels et uniques, tout en permettant une automatisation complète et un accès immédiat, nous **aussi** supportons toutes les autres options de don **[actuellement disponibles.](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. Voir **[ce post](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** pour des instructions sur la façon de faire un don en utilisant d'autres méthodes afin d'obtenir une licence manuelle valide pour une période donnée.

Quelle que soit la méthode utilisée, si vous êtes sponsor ASF, vous pouvez obtenir votre licence **[ici](https://asf.justarchi.net/User/Status)**. Vous devrez vous connecter avec GitHub pour confirmer votre identité, nous vous demandons uniquement des informations publiques en lecture seule, qui sont votre nom d'utilisateur. `Le LicenseID` est composé de 32 caractères hexadécimaux, tels que `f6a0529813f74d119982eb4fe43a9a24`.

**Assurez-vous de ne pas partager votre `LicenseID` avec d’autres personnes**. Comme il est émis sur une base personnelle, il peut être révoqué s'il est divulgué. Si, par hasard, cela vous arrive accidentellement, vous pouvez en générer un nouveau à partir du même endroit.

À moins que vous ne vouliez activer des fonctionnalités ASF supplémentaires, il n'est pas nécessaire d'obtenir/de fournir la licence.

---

### `LoginLimiterDelay`

`byte` avec la valeur par défaut `10`. ASF veillera à ce qu'il y ait au moins `LoginLimiterDelay` deux secondes entre deux demandes successives de tentatives de connexion, afin d'éviter de déclencher une limite de débit. La valeur par défaut de `10` a été définie en fonction de la connexion de plus de 100 instances de bot, et devrait satisfaire la plupart (si pas tous) des utilisateurs. Vous pouvez cependant vouloir l'augmenter/diminuer, ou même passer à `0` si vous avez un très faible nombre de bots, ASF ignorera donc le délai et se connectera à Steam beaucoup plus rapidement. Attention toutefois: si vous le réglez trop bas tout en ayant trop de bots, **cela** entraînera une suspension temporaire de votre IP par Steam, ce qui vous empêchera de vous connecter **complètement**, avec l’erreur `InvalidPassword/RateLimitExceeded` — et cela concerne également votre client Steam habituel, pas seulement ASF. De même, si vous utilisez un nombre excessif de bots, en particulier avec d'autres clients/outils Steam en utilisant la même adresse IP, vous devrez probablement augmenter cette valeur afin de répartir les connexions sur une période plus longue.

Comme note secondaire, cette valeur est également utilisée comme tampon d'équilibrage de charge dans toutes les actions planifiées ASF, telles que les transactions dans `SendTradePeriod`. À moins que vous n'ayez une raison **forte** de modifier cette fonction, vous devez la conserver par défaut.

---

### `MaxFarmingTime`

`byte` avec la valeur par défaut `10`. Comme vous devriez le savoir, Steam ne fonctionne pas toujours correctement, parfois, des situations bizarres peuvent se produire comme notre temps de jeu ne pas être enregistrés, malgré le fait de jouer à un jeu. ASF autorisera le farming d'une seule partie en mode solo pour un maximum de `MaxFarmingTime` heures, et le considérera comme entièrement cultivé après cette période. Ceci est nécessaire pour ne pas geler le processus agricole en cas de situations bizarres, mais aussi si, pour une raison quelconque, Steam a publié un nouveau badge qui empêcherait ASF de progresser plus loin (voir : `Liste noire`). La valeur par défaut de `10` heures devrait suffire pour supprimer toutes les cartes Steam d'une partie. Définir cette propriété trop basse peut entraîner un saut des jeux valides (et oui, Il y a des jeux valides qui prennent même jusqu'à 9 heures à la ferme), tandis que le mettre trop élevé peut entraîner le gel du processus agricole. Veuillez noter que cette fonction n'affecte qu'un seul jeu dans une seule session de farming (donc, après avoir parcouru toute la file d'attente, ASF retournera à ce titre), non plus il ne repose pas sur le temps de jeu total, mais sur le temps de farming interne ASF, donc ASF retournera également à ce titre après un redémarrage. À moins que vous n'ayez une raison **forte** de modifier cette fonction, vous devez la conserver par défaut.

---

### `MaxTradeHoldDuration`

`byte` avec la valeur par défaut `15`. Cette propriété définit la durée maximale de la détention commerciale en jours que nous sommes prêts à accepter - ASF rejettera les transactions qui sont en cours pendant plus de `MaxTradeHoldDuration` jours, tel que défini dans la section **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**. Cette option n'a de sens que pour les bots avec `TradingPreferences` de `SteamTradeMatcher`, car cela n'affecte pas les transactions `Master`/`SteamOwnerID` , ni les dons. Les poches commerciales sont ennuyeuses pour tout le monde, et personne ne veut vraiment les traiter. ASF est censé travailler sur des règles libérales et aider tout le monde, indépendamment du fait que sur trade hold ou non - c'est pourquoi cette option est réglée à `15` par défaut. Cependant, si vous préférez plutôt rejeter toutes les transactions affectées par les opérations détenues, vous pouvez spécifier `0` ici. Veuillez prendre en considération le fait que les cartes avec une durée de vie courte ne sont pas affectées par cette option et automatiquement rejetées pour les personnes avec des détentions commerciales, comme décrit dans la section **[de trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** donc il n'est pas nécessaire de rejeter globalement tout le monde uniquement à cause de cela. Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.


---

### `format@@0 MinFarmingDelayAfterBlock`

`byte` avec la valeur par défaut `60`. Cette propriété définit le temps minimum, en secondes, que ASF attendra avant de reprendre le farming des cartes si elle a été précédemment déconnectée avec `LoggedInElse`, qui se produit lorsque vous décidez de déconnecter avec force ASF en lançant un jeu. Ce retard existe principalement pour des raisons de commodité et de frais généraux, par exemple, il vous permet de redémarrer le jeu sans avoir à vous battre avec ASF occupant votre compte à nouveau parce que le verrou de jeu était disponible pendant une fraction de seconde. En raison du fait que la récupération de la session cause `LoggedInElsewhere` se déconnecte, ASF doit passer par toute la procédure de reconnexion qui exerce une pression supplémentaire sur la machine et le réseau Steam, évitant donc les déconnexions supplémentaires, si possible, est préférable. Par défaut, ceci est configuré en `60` secondes, ce qui devrait suffire pour vous permettre de redémarrer le jeu sans trop de tracas. Cependant, il y a des scénarios quand vous pourriez être intéressé à l'augmenter, par exemple, si votre réseau se déconnecte souvent et qu'ASF prend le relais trop tôt, ce qui entraîne le passage obligé du processus de reconnexion vous-même. Nous autorisons une valeur maximale de `255` pour cette propriété, qui devrait être suffisante pour tous les scénarios courants. En plus de ce qui précède, il est également possible de diminuer le délai, ou même le supprimer entièrement avec une valeur de `0`, Bien que cela ne soit généralement pas recommandé pour des raisons énoncées ci-dessus. Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

### `OptimizationMode`

`byte` avec la valeur par défaut `0`. Cette fonction définit le mode d'optimisation que ASF préfèrera pendant l'exécution. Actuellement, ASF prend en charge deux modes - `0` qui s'appelle `MaxPerformance`, et `1` qui est appelé `MinMemoryUsage`. Par défaut, ASF préfère exécuter autant de choses en parallèle (simultanément) que possible. qui améliore les performances par le travail d'équilibrage de charge sur tous les cœurs de processeur, sur plusieurs fils de processeur, sur plusieurs sockets et sur plusieurs tâches de threadpool. Par exemple, ASF demandera votre première page de badge lors de la vérification des jeux à fermer, puis une fois que la demande est arrivée, ASF lira à partir de lui combien de pages de badge vous possédez réellement, puis vous demandera l’une l’autre en même temps. C'est ce que vous devriez vouloir **presque toujours**, étant donné que les frais généraux sont minimes dans la plupart des cas et que le code ASF asynchrone peut être vu même sur le matériel le plus ancien avec un seul cœur CPU et une puissance fortement limitée. Cependant, avec de nombreuses tâches traitées en parallèle, le runtime ASF est responsable de leur maintenance, p. ex. garder les sockets ouvertes, les threads en vie et les tâches en cours de traitement, qui peut entraîner une augmentation de l'utilisation de la mémoire de temps en temps, et si vous êtes extrêmement limité par la mémoire disponible, vous pouvez basculer cette propriété en `1` (`MinMemoryUsage`) afin de forcer ASF à utiliser le moins de tâches possible. et exécutant généralement du code asynchrone possible à parallèle de manière synchrone. Vous devriez envisager de changer cette propriété uniquement si vous avez précédemment lu **[faible mémoire dans la configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** et que vous voulez intentionnellement sacrifier une augmentation gigantesque des performances, pour une très petite perte de mémoire. Habituellement cette option est **bien pire** que ce que vous pouvez obtenir avec d'autres moyens possibles. comme par exemple en limitant votre utilisation d'ASF ou en réglant le collecteur de déchets de l'exécution, comme expliqué dans **[configuration à faible mémoire](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Vous devriez donc utiliser `MinMemoryUsage` en **dernier recours**, juste avant la recompilation à l’exécution, si vous n’avez pas pu obtenir des résultats satisfaisants avec d’autres options (bien meilleures). Sauf si vous avez une raison **forte** pour modifier cette propriété, vous devez la conserver par défaut.

---

### `PluginsUpdateList`

`ImmutableHashSet<string>` avec la valeur par défaut étant vide. Cette propriété définit la liste des noms d'assemblages de plugins qui sont sur liste noire ou sur liste blanche pour être considérés pour les mises à jour automatiques, conformément à `PluginsUpdateMode` défini ci-dessous.

Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

### `PluginsUpdateMode`

`byte` avec la valeur par défaut `0`. Cette propriété définit le mode de mise à jour des plugins qui donne un sens à `PluginsUpdateList` défini ci-dessus. En spécifiant cette propriété, vous pouvez facilement activer/désactiver les mises à jour automatiques pour tous les plugins sauf ceux déclarés.

- La valeur `0`, appelée `Whitelist`, **désactive** la mise à jour automatique de tous les plugins, sauf ceux définis dans `PluginsUpdateList`.
- Valeur de `1`, appelée `Liste noire`, **active** mise à jour automatique de tous les plugins, sauf ceux définis dans `PluginsUpdateList`.

**L'équipe ASF voudrait vous rappeler que, pour votre propre sécurité, vous ne devriez activer les mises à jour automatiques que des parties de confiance**. Gardez à l'esprit que les plugins malveillants peuvent décider de se mettre à jour ou d'exécuter des commandes distantes **indépendamment de** de ce paramètre, c'est pourquoi ce paramètre s'applique exclusivement aux fonctionnalités de mise à jour des plugins fournies par ASF, et vous devriez toujours vous assurer que vous avez vérifié correctement chaque plugin que vous avez décidé d'utiliser.

Les mises à jour des plugins sont effectuées par défaut avec la routine de mise à jour ASF - **[`UpdateChannel`](#updatechannel)** et **[`UpdatePeriod`](#updateperiod)**. Les mécanismes de mise à jour standard ASF tels que la commande `update` déclencheront également la mise à jour facultative des plugins. Si vous souhaitez mettre à jour les plugins manuellement sans mettre à jour la version ASF en même temps, la commande `updateplugins` offre une telle possibilité.

Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

### `Arrêt possible`

`bool` avec la valeur par défaut `false`. Lorsque cette option est activée, ASF essaiera d’arrêter le processus si possible, c’est-à-dire lorsque tous vos robots enregistrés seront arrêtés. Cela peut être particulièrement utile lorsque combiné avec `ShutdownOnFarmingFinished` sur toutes vos instances de bot, car ainsi ASF sera autorisé à s'éteindre automatiquement lorsque le dernier de vos bots terminera le farming.

Puisque l'attente de la majorité des utilisateurs est de faire fonctionner le processus en tout temps, e. . pour une utilisation `IPC` , cette option est désactivée par défaut.

---

### `Préfixe du message vapeur`

`chaîne` avec la valeur par défaut `/me`. Cette propriété définit un préfixe qui sera ajouté à tous les messages Steam envoyés par ASF. Par défaut, ASF utilise le préfixe `"/me "` afin de distinguer plus facilement les messages de bot en les montrant dans une couleur différente sur le chat Steam. Une autre mention louable est le préfixe `"/pre "` qui obtient des résultats similaires, mais utilise un formatage différent. Vous pouvez également définir cette propriété sur une chaîne vide ou `null` afin de désactiver entièrement l'utilisation du préfixe et d'afficher tous les messages ASF de manière traditionnelle. Il est agréable de noter que cette propriété affecte uniquement les messages Steam - les réponses retournées par d'autres canaux (comme IPC) ne sont pas affectées. À moins que vous ne souhaitiez personnaliser le comportement standard ASF, il est conseillé de le laisser par défaut.

---

### `SteamOwnerID
`

`ulong` avec la valeur par défaut `0`. Cette propriété définit Steam ID sous forme 64 bits du propriétaire du processus ASF, et est très similaire à la permission `Master` d'une instance de bot donnée (mais globale à la place). Vous voulez presque toujours définir cette propriété sur l'ID de votre propre compte Steam principal. La permission `Master` inclut un contrôle total sur son instance de bot, mais des commandes globales telles que `exit`, `redémarrer` ou `mise à jour` sont réservés uniquement à `SteamOwnerID`. C'est pratique, car vous pouvez exécuter des bots pour vos amis, tout en ne leur permettant pas de contrôler le processus ASF, comme la quitter via la commande `exit`. La valeur par défaut de `0` spécifie qu'il n'y a pas de propriétaire du processus ASF, ce qui signifie que personne ne sera en mesure de publier des commandes ASF globales. Gardez à l'esprit que cette propriété s'applique exclusivement au chat Steam. **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, ainsi que la console interactive, vous permettra toujours d'exécuter des commandes `Propriétaire` même si cette propriété n'est pas définie.

---

### `SteamProtocols`

`byte flags` avec la valeur par défaut `7`. Cette fonction définit les protocoles Steam utilisés par ASF lors de la connexion aux serveurs Steam, définis comme suit:

| Valeur  | Nom        | Description                                                                                              |
| ------- | ---------- | -------------------------------------------------------------------------------------------------------- |
| 0       | None       | Pas de protocole                                                                                         |
| 1       | TCP        | **[Protocole de contrôle de transmission](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2       | UDP        | **[Protocole utilisateur Datagram ](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**              |
| 4       | WebSockets | **[WebSockets](https://en.wikipedia.org/wiki/WebSocket)**                                                |

Veuillez noter que cette  fonction est le champ `flags`, il est donc possible de choisir n’importe quelle combinaison de valeurs disponibles. Consultez le mapping Json **[](#json-mapping)** si vous souhaitez en savoir plus. Si aucun indicateur n’est activé, l’option `None` est validée et cette option n’est pas valide par elle-même.

Par défaut, ASF utilisera tous les protocoles Steam disponibles comme une mesure pour lutter contre les temps d'arrêt et d'autres problèmes Steam similaires. Généralement, vous voulez modifier cette propriété si vous voulez limiter ASF à l'utilisation d'un ou deux protocoles spécifiques. De telles mesures pourraient être nécessaires dans différentes situations, par exemple si vous avez bloqué le trafic UDP sur votre pare-feu et que vous voulez vous assurer que seul le trafic TCP passe par , ou si vous utilisez `WebProxy` et que vous souhaitez l'utiliser aussi pour la connexion client Steam, comme seul le protocole `WebSocket` le supporte.

Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

### `UpdateChannel`

`byte` avec la valeur par défaut `1`. Cette propriété définit le canal de mise à jour qui est utilisé, soit pour les mises à jour automatiques (si la période de mise à jour `` est supérieure à `0`), soit pour les notifications de mise à jour (sinon). ASF prend actuellement en charge trois canaux de mise à jour - `0` qui s'appelle `None`, `1`, qui est appelé `Stable`, et `2`, qui est appelé `PreRelease`. Le canal `Stable` est le canal de publication par défaut, qui devrait être utilisé par la majorité des utilisateurs. Le canal `PreRelease` en plus des versions `Stable` , inclut également **pré-versions** dédiées aux utilisateurs avancés et autres développeurs afin de tester de nouvelles fonctionnalités. confirmez les corrections de bogues ou donnez des commentaires sur les améliorations prévues. **Les versions préliminaires contiennent souvent des bogues non corrigés, des fonctionnalités en cours de développement ou des implémentations réécrites**. Si vous ne vous considérez pas comme un utilisateur avancé, veuillez rester avec le canal de mise à jour `1` (`Stable`. Le canal `PreRelease` est dédié aux utilisateurs qui savent rapporter des bugs, traiter les problèmes et donner des commentaires - aucun support technique ne sera fourni. Consultez le cycle de publication ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** si vous souhaitez en savoir plus. Vous pouvez également définir `UpdateChannel` à `0` (`None`), si vous voulez supprimer complètement toutes les vérifications de version. Régler `UpdateChannel` à `0` désactivera entièrement toute la fonctionnalité liée aux mises à jour, y compris la commande `mise à jour`. L'utilisation du canal `None` est **fortement déconseillée** en raison de vous exposer à toutes sortes de problèmes (mentionnés dans la description de `UpdatePeriod` ci-dessous).

**Sauf si vous savez ce que vous faites**, nous recommandons **fortement** de laisser cette valeur par défaut.

---

### `UpdatePeriod`

`byte` avec la valeur par défaut `24`. Cette fonction définit la fréquence à laquelle ASF doit vérifier les mises à jour automatiques. Les mises à jour sont cruciales non seulement pour recevoir de nouvelles fonctionnalités et des correctifs de sécurité critiques, mais aussi pour recevoir des corrections de bugs, des améliorations des performances, des améliorations de la stabilité et plus encore. Lorsqu'une valeur supérieure à `0` est définie, ASF téléchargera, remplacera automatiquement et redémarrer lui-même (si `AutoRedémarrer` le permet) quand une nouvelle mise à jour est disponible. Pour ce faire, ASF vérifiera toutes les `UpdatePeriod` heures si une nouvelle mise à jour est disponible sur notre dépôt GitHub. Une valeur de `0` désactive les mises à jour automatiques, mais vous permet quand même d'exécuter la commande `update` manuellement. Vous pourriez également être intéressé par la configuration appropriée de `UpdateChannel` que `UpdatePeriod` devrait suivre.

Le processus de mise à jour d'ASF implique la mise à jour de toute la structure de dossier qu'ASF utilise, mais sans toucher à vos propres configurations ou bases de données situées dans le répertoire `config` - cela signifie que tous les fichiers supplémentaires non liés à ASF dans son répertoire peuvent être perdus pendant la mise à jour. La valeur par défaut de `24` est un bon équilibre entre des vérifications inutiles et ASF qui est suffisamment frais.

Sauf si vous avez une raison **forte** pour désactiver cette fonctionnalité, vous devriez garder les mises à jour automatiques activées dans le cadre de la raisonnable `Mise à jour` **pour votre propre**. Non seulement parce que nous ne prenons pas en charge quoi que ce soit, mais aussi parce que la dernière version stable d'ASF, mais aussi parce que **nous donnons notre garantie de sécurité uniquement pour la dernière version**. Si vous utilisez une version obsolète d’ASF, vous vous exposez volontairement à toutes sortes de problèmes, allant de petits bugs à des fonctionnalités défectueuses, et pouvant aller jusqu’à des **[suspensions permanentes de compte Steam](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**. Nous vous **recommandons fortement**, pour votre propre sécurité, de toujours vous assurer que votre version d’ASF est à jour. Les mises à jour automatiques nous permettent de réagir rapidement à tous les types de problèmes en désactivant ou en corrigeant le code problématique avant qu'il ne puisse s'escalader - si vous refusez de le faire, vous perdez toutes nos garanties de sécurité et les conséquences de l'exécution du code qui pourrait être dangereux, non seulement sur le réseau Steam, mais aussi (par définition) sur votre propre compte Steam.

---

### `WebLimiterDelay`

`string` avec la valeur par défaut `300`. Cette propriété définit, en milisecondes, la quantité minimale de délai entre l'envoi de deux requêtes consécutives vers le même service Web Steam. Un tel délai est requis comme le service **[AkamaiGhost](https://www.akamai.com)** que Steam utilise en interne inclut une limitation de débit basée sur le nombre global de requêtes envoyées à travers une période donnée. Dans des circonstances normales, le bloc akamai est assez difficile à réaliser, mais sous de très lourdes charges de travail avec une énorme file d'attente de requêtes, il est possible de le déclencher si nous continuons d'envoyer trop de requêtes sur une période trop courte.

La valeur par défaut a été définie en supposant qu’ASF est le seul outil accédant aux services web de Steam, en particulier `steamcommunity.com`, `api.steampowered.com` et `store.steampowered.com`. Si vous utilisez d'autres outils pour envoyer des requêtes vers les mêmes services web, vous devez vous assurer que votre outil inclut des fonctionnalités similaires de `WebLimiterDelay` et définir les deux à double de la valeur par défaut, qui serait `600`. Cela garantit qu'en aucune circonstance vous dépasserez l'envoi de plus d'une requête par `300` ms.

En général, abaissement de `WebLimiterDelay` sous la valeur par défaut est **fortement découragé** car cela pourrait conduire à divers blocs liés à IP, dont certains sont possibles pour être permanents. La valeur par défaut est suffisante pour exécuter une seule instance ASF sur le serveur, ainsi que l'utilisation d'ASF dans un scénario normal avec le client Steam original. Il devrait être correct pour la majorité des utilisations, et vous ne devriez l'augmenter que (jamais le réduire). En bref, le nombre global de toutes les requêtes envoyées à partir d'une seule adresse IP à un seul domaine Steam ne doit jamais excéder plus d'une requête par `300` ms.

Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

### `WebProxy`

`chaîne` avec la valeur par défaut `null`. Cette propriété définit une adresse de proxy web qui sera utilisée pour les communications internes, en particulier pour les services tels que `github. om`, `api.steampowered.com`, `steamcommunity.com` et `store.steampowered.com`. Il s'applique à la communication générale (spécifique à un autre robot) ainsi qu'à la communication spécifique au bot si leur propriété de configuration équivalente `WebProxy` n'est pas définie. Proxter des requêtes ASF pourrait être exceptionnellement utile pour contourner divers types de pare-feu, en particulier le grand pare-feu en Chine.

Cette propriété est définie comme une chaîne uri :

> Une chaîne URI est composée d'un schéma (supporté : http/https/socks4/socks4a/socks5), d'un hôte et d'un port optionnel. Un exemple de chaîne complète uri est `"http://contoso.com:8080"`.

Si votre proxy nécessite une authentification de l'utilisateur, vous devrez également configurer `WebProxyUsername` et/ou `WebProxyPassword`. S'il n'y a pas ce besoin, la création de cette propriété seule suffira.

Si vous avez également besoin d'un proxy interne de communication sur le réseau Steam (CMs) alors vous devriez vous assurer de configurer la propriété du bot **[`SteamProtocols`](#steamprotocols)** à une valeur qui ne permet que le transport de websocket, i. . une valeur de `4`, car seuls les websockets sont supportés pour le proxying.

Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

### `WebProxyPassword`

`chaîne` avec la valeur par défaut `null`. Cette propriété définit le champ mot de passe utilisé dans la base, la digeste, NTLM, et l'authentification Kerberos qui est prise en charge par une machine cible `WebProxy` fournissant des fonctionnalités de proxy. Si votre proxy ne nécessite pas les identifiants de l'utilisateur, vous n'avez pas besoin de saisir quoi que ce soit ici. L'utilisation de cette option n'a de sens que si `WebProxy` est également utilisée, car elle n'a aucun effet contraire.

Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

### `WebProxyUsername`

`chaîne` avec la valeur par défaut `null`. Cette propriété définit le champ nom d'utilisateur utilisé en base, digestif, NTLM, et l'authentification Kerberos qui est prise en charge par une machine cible `WebProxy` fournissant des fonctionnalités de proxy. Si votre proxy ne nécessite pas les identifiants de l'utilisateur, vous n'avez pas besoin de saisir quoi que ce soit ici. L'utilisation de cette option n'a de sens que si `WebProxy` est également utilisée, car elle n'a aucun effet contraire.

Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

## Configuration Bot

Comme vous le savez déjà, chaque bot devrait avoir sa propre configuration basée sur l'exemple de structure JSON ci-dessous. Commencez à décider comment vous voulez nommer votre bot (par exemple `1.json`, `main. son`, `primary.json` ou `AnythingElse.json`) et allez à la configuration.

**Remarque:** Le bot ne peut pas être nommé `ASF` (comme ce mot clé est réservé à la configuration globale), ASF ignorera également tous les fichiers de configuration commençant par un point.

La configuration du bot a la structure suivante :

```json
{
    "AcceptGifts": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Activé": false,
    "Ordres agricoles": [],
    "Préférences": 0,
    "GamesPlayedWhileIdle": [],
    "GamingDeviceType": 1,
    "HeuresUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "NomMachine": null,
    "Types Matchable": [5],
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "Format du mot de passe": 0,
    "Préférences": 0,
    "Télécommunication": 3,
    "SendTradePeriod": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "Période de vérification du commerce": 60,
    "Préférences de trading": 0,
    "Types transférables": [1, 3, 5],
    "UseLoginKeys": true,
    "UserInterfaceMode": 0,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Toutes les options sont expliquées ci-dessous :

### `AcceptGifts`

`bool` avec la valeur par défaut `false`. Lorsque cette option est activée, ASF acceptera automatiquement et utilisera tous les cadeaux Steam (y compris les cartes-cadeaux du portefeuille) envoyés au bot. Cela inclut également les cadeaux envoyés par des utilisateurs autres que ceux définis dans `SteamUserPermissions`. Gardez à l'esprit que les cadeaux envoyés à l'adresse e-mail ne sont pas directement transmis au client, ASF n'acceptera donc pas ceux sans votre aide.

Cette option est recommandée uniquement pour les comptes alt, car il est très probable que vous ne vouliez pas utiliser automatiquement tous les cadeaux envoyés sur votre compte principal. Si vous ne savez pas si cette fonctionnalité doit être activée ou non, conservez-la avec la valeur par défaut `false`.

---

### `BotBehaviour`

`chaîne` avec la valeur par défaut `0`. Cette fonction définit le comportement de type bot ASF lors de divers événements. Elle est définie comme suit:

| Valeur  | Nom                                  | Description                                                                                                              |
| ------- | ------------------------------------ | ------------------------------------------------------------------------------------------------------------------------ |
| 0       | None                                 | Aucun comportement spécial du bot, paramètres par défaut sane                                                            |
| 1       | RejectInvalidFriendInvites           | Forcera ASF à rejeter (au lieu d'ignorer) des offres d'amitié non valides                                                |
| 2       | RejectInvalidTrades                  | Forcera ASF à rejeter (au lieu d'ignorer) des offres d'échange non valides                                               |
| 4       | RejectInvalidGroupInvites            | Forcera ASF à rejeter (au lieu d'ignorer) des offres d'inclusion à un groupe non valides                                 |
| 8       | DismissInventoryNotifications        | Fait qu'ASF rejette automatiquement toutes les notifications d'inventaire                                                |
| 16      | Marquer les messages reçus comme lus | Fait qu'ASF marque automatiquement tous les messages reçus comme lus                                                     |
| 32      | Marquer les messages comme lus       | Fait qu'ASF marque automatiquement les messages d'autres bots ASF (en cours d'exécution dans la même instance) comme lus |
| 64      | Désactiver l'analyse des métiers     | Fait qu'ASF ne traite jamais les offres commerciales entrantes                                                           |

Veuillez noter que cette  fonction est le champ `flags`, il est donc possible de choisir n’importe quelle combinaison de valeurs disponibles. Consultez le mapping Json **[](#json-mapping)** si vous souhaitez en savoir plus. Si aucun indicateur n’est activé, l’option `None` est activée.

En général, vous voulez modifier cette propriété si vous vous attendez à modifier divers paramètres d'automatisation liés à l'activité du bot. Les paramètres par défaut impliquent ASF en mode non-invasif, ce qui n'active que l'automatisation bénéfique qui ne va pas à l'encontre de la volonté de l'utilisateur.

Une invitation d'amis non valide est une invitation qui ne provient pas d'un utilisateur disposant de l'autorisation `FamilySharing` (défini dans `SteamUserPermissions`) ou supérieure. ASF en mode normal ignore ces invitations, comme vous vous en doutez, vous laissant le choix de les accepter ou non. `RejectInvalidFriendInvites` entraînera le rejet automatique de ces invitations, ce qui désactivera pratiquement l'option permettant à d'autres personnes de vous ajouter à leur liste d'amis (ASF refusant toutes ces demandes, à l'exception des personnes définies dans `SteamUserPermissions`). Si vous ne souhaitez pas refuser toutes les invitations d'amis, vous ne devez pas activer cette option.

Une offre commerciale non valide est une offre qui n'est pas acceptée via le module ASF intégré. Pour plus d'informations à ce sujet, reportez-vous à la section **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**, qui définit explicitement les types de commerce que ASF est disposé à accepter automatiquement. Les transactions valides sont également définies par d'autres paramètres, notamment `TradingPreferences`. `RejectInvalidTrades` entraînera le rejet de toutes les offres commerciales non valides, au lieu de les ignorer. Si vous ne souhaitez pas refuser toutes les offres commerciales qui ne sont pas automatiquement acceptées par ASF, vous ne devez pas activer cette option.

Une invitation de groupe non valide est une invitation qui ne provient pas du groupe `SteamMasterClanID`. ASF en mode normal ignore ces invitations à un groupe, comme vous le souhaitez, vous permettant de décider vous-même si vous souhaitez rejoindre un groupe Steam particulier ou non. `RejectInvalidGroupInvites` entraînera le rejet automatique de toutes les invitations à un groupe, ce qui rendra impossible toute invitation à un autre groupe que `SteamMasterClanID`. Si vous ne souhaitez pas refuser toutes les invitations à un groupe, vous ne devez pas activer cette option.

`DismissInventoryNotifications` est extrêmement utile lorsque vous commencez à être ennuyé par la constante notification Steam à propos de la réception de nouveaux éléments. ASF ne peut pas se débarrasser de la notification elle-même, car elle est intégrée dans votre client Steam, mais il est en mesure d'effacer automatiquement la notification après l'avoir reçue, ce qui ne laissera plus la notification "nouveaux éléments dans l'inventaire" suspendue. Si vous vous attendez à vous évaluer vous-même tous les articles reçus (en particulier les cartes cultivées avec ASF), vous ne devriez évidemment pas activer cette option. Lorsque vous commencez à devenir fou, rappelez-vous que cette option est offerte.

`MarkReceivedMessagesAsRead` marquera automatiquement **tous les messages** reçus par le compte sur lequel ASF fonctionne, à la fois privé et groupe, comme lu. Ceci devrait généralement être utilisé par les comptes alt uniquement afin d'effacer la notification "nouveau message" venant par exemple de vous lors de l'exécution des commandes ASF. Nous ne recommandons pas cette option pour les comptes principaux, à moins que vous ne vouliez vous couper de toute sorte de nouvelles notifications de messages, **y compris** ceux qui se sont produits pendant que vous étiez hors ligne, en supposant qu'ASF restait ouvert le rejetant.

`MarkBotMessagesAsRead` fonctionne de manière similaire en ne marquant que les messages du bot comme lus. Cependant, gardez à l'esprit que lorsque vous utilisez cette option sur les discussions de groupe avec vos bots et d'autres personnes, Implémentation Steam de la reconnaissance du message de chat **aussi** reconnaît tous les messages qui se sont produits **avant** celui que vous avez décidé de marquer. donc si par hasard vous ne voulez pas manquer un message non lié qui s'est produit entre les deux, vous voulez généralement éviter d'utiliser cette fonctionnalité. Évidemment, il est également risqué lorsque vous avez plusieurs comptes primaires (par ex. de différents utilisateurs) fonctionnant dans la même instance ASF, car vous pouvez également manquer leurs messages normaux hors ASF.

`Désactiver IncomingTradesParsing` empêchera ASF d’analyser les offres commerciales entrantes, ce qui signifie que toute la fonctionnalité de trading liée à cette fonctionnalité sera non opérationnelle. Puisque ASF fonctionne dans le mode le moins invasif par défaut, n'acceptant que les offres commerciales des utilisateurs `Master` et plus, sans jamais toucher aux autres offres de négociation - l'analyse des transactions entrantes est activée par défaut. Ce paramètre rend le plus logique pour les personnes qui voudraient s'assurer qu'aucune requête supplémentaire ou surcharge liée à l'analyse des métiers, désactivant toute logique dans le processus, par exemple parce qu'ils savent que leurs bots ne recevront jamais de requêtes de trading principales, et donc n’exigent pas d’ASF de participer à leur activité de trading. Gardez à l'esprit que si cette option est spécifiée, toutes les autres options qui dépendent également des transactions entrantes seront désactivées comme `AcceptDonations` ou `SteamTradeMatcher` - les plugins personnalisés seront également incapables de traiter les offres de trading entrantes de la manière habituelle.

Si vous ne savez pas comment configurer cette option, il est préférable de la laisser par défaut.

---

### `CompleteTypesToSend`

`ImmutableHashSet<byte>` avec la valeur par défaut étant vide. Lorsque ASF est terminé en complétant un ensemble de types d’éléments spécifiés ici, il peut automatiquement envoyer un échange Steam avec tous les ensembles terminés à l'utilisateur avec la permission `Master` , qui est très pratique si vous souhaitez utiliser un compte de bot donné pour e. . Correspondance STM, lors du déplacement des ensembles terminés vers un autre compte. Cette option fonctionne de la même manière que la commande `loot` , gardez donc à l'esprit que cela nécessite un utilisateur avec la permission `Master` configurée vous pouvez également avoir besoin d'un jeton `SteamTradeToken`valide, ainsi que l'utilisation d'un compte qui est admissible à la négociation en premier lieu.

À partir d’aujourd’hui, les types d’éléments suivants sont pris en charge dans ce paramètre:

| Valeur  | Nom              | Description                                                                    |
| ------- | ---------------- | ------------------------------------------------------------------------------ |
| 3       | FoilTradingCard  | Variante brillante de `TradingCard`                                            |
| 5       | Carte à échanger | Carte Steam à échanger, utilisée dans la fabrication de badges (non-brillants) |

Veuillez noter que quels que soient les paramètres ci-dessus, ASF ne demandera que les éléments **[de la communauté Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` de 753, `contextID` de 6), donc tous les objets du jeu, les cadeaux et les autres sont exclus de l'offre commerciale par définition.

En raison de frais supplémentaires liés à l'utilisation de cette option, il est recommandé de ne l'utiliser que sur les comptes de bot qui ont une chance réaliste de terminer les jeux seuls - par exemple, activer si vous utilisez déjà `SendOnFarmingFinished` préférence dans `FarmingPreferences`, `commande SendTradePeriod` ou `ramasser` sur la base habituelle.

Si vous ne savez pas comment configurer cette option, il est préférable de la laisser par défaut.

---

### `CustomGamePlayedWhileFarming`

`chaîne` avec la valeur par défaut `null`. Quand ASF est en train de fermer, il peut s'afficher comme "Jouer au jeu non-vapeur: `CustomGamePlayedWhileFarming`" au lieu du jeu actuellement fermé. Cela peut être utile si vous souhaitez faire savoir à vos amis que vous êtes en train de fermer, encore vous ne voulez pas utiliser `OnlineStatus` de `hors ligne`. Veuillez noter qu'ASF ne peut pas garantir l'ordre d'affichage actuel du réseau Steam, donc il ne s'agit que d'une suggestion qui peut ou ne peut pas s'afficher correctement. En particulier, un nom personnalisé ne s'affichera pas dans l'algorithme de farming `Complex` si ASF remplit tous les emplacements `32` avec des jeux nécessitant des heures pour être bumpé. La valeur par défaut de `null` désactive cette fonctionnalité.

ASF fournit quelques variables spéciales que vous pouvez éventuellement utiliser dans votre texte. `{0}` sera remplacé par ASF par `AppID` de jeu(s), actuellement fermé(s), tandis que `{1}` sera remplacé par ASF par `GameName` de jeu(s) actuellement cultivés.

---

### `format@@0 CustomGamePlayedWhileIdle`

`chaîne` avec la valeur par défaut `null`. Similaire à `CustomGamePlayedWhileFarming`, mais pour la situation où ASF n'a rien à faire (car le compte est entièrement farmed). Veuillez noter qu'ASF ne peut pas garantir l'ordre d'affichage actuel du réseau Steam, donc il ne s'agit que d'une suggestion qui peut ou ne peut pas s'afficher correctement. Si vous utilisez `GamesPlayedWhileIdle` conjointement avec cette option, gardez à l’esprit que `GamesPlayedWhileIdle` a la priorité. Vous ne pouvez donc pas en déclarer plus de `31`, sinon `CustomGamePlayedWhileIdle` ne pourra pas occuper la place réservée au nom personnalisé. La valeur par défaut de `null` désactive cette fonctionnalité.

---

### `Enabled`

`bool` avec la valeur par défaut `false`. Cette propriété définit si le bot est activé. Une instance de bot activée (`true`) démarrera automatiquement au lancement d’ASF, tandis qu’une instance de bot désactivée (`false`) devra être démarrée manuellement. Par défaut, chaque bot est désactivé, donc vous voulez probablement basculer cette propriété en `true` pour tous vos bots qui devraient être démarrés automatiquement.

---

### `FarmingOrders`

`Immutable Liste<byte>` type avec la valeur par défaut d'être vide. Cette propriété définit l'ordre de farming **préféré** utilisé par ASF pour un compte de bot donné. Il y a actuellement des commandes d'agriculture disponibles :

| Valeur  | Nom                       | Description                                                                                                           |
| ------- | ------------------------- | --------------------------------------------------------------------------------------------------------------------- |
| 0       | Unordered                 | Pas de tri, améliorant légèrement les performances du CPU                                                             |
| 1       | AppIDsAscending           | Essaye de farmer d'abord les jeux ayant les `appIDs` les plus bas.                                                    |
| 2       | AppIDsDescending          | Essaye de farmer d’abord les jeux ayant les `appIDs` les plus élevés.                                                 |
| 3       | CardDropsAscending        | Essayez de cultiver des jeux avec le plus faible nombre de cartes restantes en premier                                |
| 4       | CardDropsDescending       | Essayez de cultiver des parties avec le plus grand nombre de cartes restantes en premier                              |
| 5       | HoursAscending            | Essayez de jouer à la ferme avec le moins d'heures jouées en premier                                                  |
| 6       | HoursDescending           | Essayez de jouer à la ferme avec le plus grand nombre d'heures jouées en premier                                      |
| 7       | NamesAscending            | Essayez de cultiver des jeux par ordre alphabétique, à partir de A                                                    |
| 8       | NamesDescending           | Essayer de cultiver des jeux en ordre alphabétique inverse, à partir de Z                                             |
| 9       | Random                    | Essaie de cultiver des jeux dans un ordre totalement aléatoire (différent à chaque exécution du programme)            |
| 10      | BadgeLevelsAscending      | Essayez d'abord de faire des jeux de ferme avec les niveaux de badge les plus bas                                     |
| 11      | BadgeLevelsDescending     | Essayez d'abord de faire des jeux de ferme avec les plus hauts niveaux de badge                                       |
| 12      | RedeemDateTimesAscending  | Essayez d'abord de cultiver les jeux les plus anciens sur notre compte                                                |
| 13      | RedeemDateTimesDescending | Essayer de commencer par les nouveaux jeux sur notre compte                                                           |
| 14      | MarketableAscending       | Essayez de faire des jeux avec des gouttes de cartes inéchangeables en premier (avertissement: coûteux à calculer)    |
| 15      | MarketableDescending      | Essayez de faire des jeux avec des gouttes de cartes commercialisables en premier (avertissement: coûteux à calculer) |

Puisque cette propriété est un tableau, elle vous permet d'utiliser plusieurs paramètres différents dans votre ordre fixe. Par exemple, vous pouvez inclure des valeurs de `15`, `11` et `7` pour trier par jeux commercialisables en premier lieu, puis par ceux avec le niveau de badge le plus élevé, et enfin par ordre alphabétique. Comme vous pouvez le deviner, l'ordre est vraiment important, comme inversé (`7`, `11` et `15`) obtient quelque chose de complètement différent (trie les jeux par ordre alphabétique d'abord, et en raison du fait que les noms de jeu sont uniques, les deux autres sont en fait inutiles). La majorité des gens n'utiliseront probablement qu'un seul ordre de tous, mais dans le cas où vous le souhaitez, vous pouvez également trier plus loin par des paramètres supplémentaires.

Notez également le mot "essayer" dans toutes les descriptions ci-dessus - l'ordre ASF actuel est fortement affecté par l'algorithme de farming de cartes **[sélectionné](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** et le tri n'affectera que les résultats qu'ASF considère comme les mêmes performances. Par exemple, dans l’algorithme `Simple`, les `FarmingOrders` sélectionnés doivent être entièrement respectés lors de la session de farming en cours (puisque chaque jeu a la même valeur de performance), tandis que dans l’algorithme `Complex`, l’ordre réel est d’abord influencé par les heures, puis trié selon les `FarmingOrders` choisis. Cela conduira à des résultats différents, car les jeux avec le temps de jeu existant auront une priorité sur les autres, ASF préfèrera si efficacement les jeux qui ont déjà passé requis `HoursUntilCardDrops` tout d'abord, et seulement en triant ces jeux plus loin par votre `FarmingOrders`. De même, une fois qu'ASF est à court de jeux déjà bumpés, il triera la file d'attente restante par heures d'abord (ce qui réduira le temps nécessaire pour remonter les titres restants à `HoursUntilCardDrops`). Par conséquent, cette propriété de configuration est seulement une **suggestion** que ASF tentera de respecter. tant que cela n'affecte pas les performances négativement (dans ce cas, ASF préférera toujours les performances de farming plutôt que `FarmingOrders`).

Il y a également une file d'attente de priorité de farming qui est accessible via les commandes `` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Si elle est utilisée, l’ordre réel de farming est trié d’abord par performance, puis par la file de farming, et enfin selon vos `FarmingOrders`.

---

### `Préférences agricoles`

`chaîne` avec la valeur par défaut `0`. Cette fonction définit le comportement ASF lié au farming, et est définie comme suit:

| Valeur  | Nom                                       |
| ------- | ----------------------------------------- |
| 0       | None                                      |
| 1       | FarmingPausedpar défaut                   |
| 2       | ShutdownOnFarmingFinished                 |
| 4       | SendOnFarmingFinished                     |
| 8       | QueueOnly FarmPriorityOnly                |
| 16      | format@@0 SkipRefundableGames             |
| 32      | Ignorer les parties non jouées            |
| 64      | Activer la découverte de cartes de risque |
| 256     | AutoUnpackBoosterPacks                    |

Veuillez noter que cette  fonction est le champ `flags`, il est donc possible de choisir n’importe quelle combinaison de valeurs disponibles. Consultez le mapping Json **[](#json-mapping)** si vous souhaitez en savoir plus. Si aucun indicateur n’est activé, l’option `None` est activée.

Toutes les options sont décrites ci-dessous.

`FarmingPausedByDefault` définit l'état initial du module `CardsFarmer`. Normalement, le bot commencera automatiquement le farming lorsqu'il démarrera, soit en raison de la commande `Activé` ou `start`. L'utilisation de `FarmingPausedByDefault` peut être utilisée si vous voulez reprendre manuellement `le processus de farming automatiqueformat@@3` par exemple parce que vous voulez utiliser `jouer à` tout le temps et ne jamais utiliser le module automatique `CardsFarmer` - cela fonctionne exactement comme `pause` **[commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

`ShutdownOnFarmingFinished` vous permet d'arrêter le bot une fois qu'il est terminé de le fermer. Normalement, ASF "occupe" un compte pendant toute la durée du processus en cours d'activation. Lorsque le compte concerné a terminé son farming, ASF le vérifie périodiquement (toutes les `IdleFarmingPeriod` heures) pour détecter si de nouveaux jeux avec cartes Steam ont été ajoutés entre-temps, afin de pouvoir reprendre le farming de ce compte sans avoir besoin de relancer le processus. Ceci est utile pour la majorité des personnes, car ASF peut automatiquement reprendre le farming lorsque nécessaire. Cependant, vous voudrez peut-être arrêter le processus lorsque le compte est entièrement exploité, vous pouvez y parvenir en utilisant ce drapeau. Lorsque cette option est activée, ASF procédera à la déconnexion lorsque le compte est entièrement exploité, ce qui signifie qu'il ne sera plus vérifié périodiquement ou occupé. Vous devriez décider vous-même si vous préférez qu'ASF travaille sur une instance de bot donnée pour tout le temps, ou si ASF devrait peut-être l’arrêter lorsque le processus de farming est terminé.

Cette option rend le plus logique à combiner avec `ShutdownIfPossible`, donc lorsque tous les comptes sont arrêtés, ASF s'éteindra également, mettre votre machine au repos et vous permettre de programmer d'autres actions, telles que le sommeil ou l'arrêt au même moment de la dernière dépose de la carte.

`SendOnFarmingFinished` vous permet d'envoyer automatiquement un échange Steam contenant tout ce qui est cultivé jusqu'à ce point à un utilisateur avec la permission `Master` . ce qui est très pratique si vous ne voulez pas vous ennuyer dans les transactions vous-même. Cette option fonctionne de la même manière que la commande `loot` , gardez donc à l'esprit que cela nécessite un utilisateur avec la permission `Master` configurée vous pouvez également avoir besoin d'un jeton `SteamTradeToken`valide, ainsi que l'utilisation d'un compte qui est admissible à la négociation en premier lieu. En plus de lancer le `loot` après avoir terminé le farming, ASF lancera également le `loot` à chaque notification de nouvel objet (lorsqu’il n’y a pas de farming en cours), et après avoir complété chaque échange qui génère de nouveaux objets (toujours) lorsque cette option est activée. Ceci est particulièrement utile pour "transmettre" les articles reçus par d'autres personnes à notre compte. Généralement, vous voudrez utiliser **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** avec cette fonctionnalité, Bien que ce ne soit pas une exigence si vous avez l'intention de traiter manuellement les confirmations 2FA dans les meilleurs délais.

`FarmPriorityQueueOnly` définit si ASF doit considérer pour le farming automatique uniquement les applications que vous avez ajoutées vous-même à la file de farming prioritaire disponible avec `fq` **[commandes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Lorsque cette option est activée, ASF ignorera tous les `appIDs` qui sont manquants dans la liste, vous permettant ainsi de choisir des jeux pour l'élevage automatique ASF. Gardez à l'esprit que si vous n'avez ajouté aucun jeu à la file d'attente, ASF agira comme s'il n'y avait rien à exploiter sur votre compte.

`SkipRefundableGames` définit si ASF doit ignorer les jeux qui sont encore remboursables du farming automatique. Un jeu remboursable est un jeu que vous avez acheté au cours des 2 dernières semaines dans le Steam Store et que vous n'avez pas encore joué pendant plus de 2 heures. comme indiqué sur la page **[Steam rembourse](https://store.steampowered.com/steam_refunds)**. Par défaut, ASF ignore entièrement la politique de remboursement Steam et tout ferme, comme la plupart des gens s'y attendent. Cependant, vous pouvez utiliser ce drapeau si vous voulez vous assurer qu'ASF ne fermera pas trop de vos jeux remboursables, vous permettant d'évaluer vous-même ces jeux et de vous rembourser si nécessaire sans vous soucier d'ASF affectant négativement le temps de jeu. Veuillez noter que si vous activez cette option, les jeux que vous avez achetés sur le Steam Store ne seront pas fermés par ASF pendant 14 jours maximum depuis la date de réutilisation, qui ne montrera rien à la ferme si votre compte ne possède rien d'autre.

`SkipUnplayedGames` définit si ASF doit ignorer les jeux que vous n'avez pas encore lancés. Le jeu non joué dans ce contexte signifie que vous n'avez pas de temps de jeu enregistré sur Steam. Si vous utilisez ce drapeau, de telles parties seront ignorées jusqu'à ce que Steam enregistre tout temps de jeu pour elles. Cela vous permet de mieux contrôler quels jeux ASF sont éligibles à la ferme, en ignorant ceux que vous n'avez pas encore eu de chance d'essayer garder les fonctionnalités sélectionnées de Steam plus utiles - comme suggérer des parties non jouées à jouer.

`EnableRiskyCardsDiscovery` active un repli supplémentaire qui se déclenche lorsque ASF est incapable de charger une ou plusieurs pages de badge et est donc incapable de trouver des jeux disponibles pour le farming. En particulier, certains comptes avec une quantité massive de gouttes de cartes peuvent causer une situation où le chargement des pages de badge n'est plus possible (en raison de surcoût), et ces comptes sont impossibles pour l'agriculture uniquement parce que nous ne pouvons pas charger l'information basée sur laquelle nous pouvons démarrer le processus. Pour ces quelques cas, cette option permet d'utiliser un algorithme alternatif qui utilise une combinaison de boosters possibles pour fabriquer et booster les packs auxquels le compte est admissible, afin de trouver des jeux potentiellement disponibles à activer, dépenser ensuite une quantité excessive de ressources pour vérifier et récupérer les informations requises, et en essayant de démarrer le processus de farming sur une quantité limitée de données et d'informations afin d'atteindre une situation lorsque la page de badge se charge et nous serons en mesure d'utiliser une approche normale. Veuillez noter que lorsque ce repli est utilisé, ASF fonctionne uniquement avec des données limitées, Il est donc tout à fait normal qu'ASF trouve beaucoup moins de gouttes qu'en réalité - d'autres gouttes seront trouvées à un stade ultérieur du processus de farming .

Cette option est qualifiée de « risquée » pour une très bonne raison : elle est extrêmement lente et nécessite une quantité importante de ressources (y compris des requêtes réseau) pour fonctionner. Il est donc **fortement déconseillé** de l’activer, surtout sur le long terme. Vous ne devriez utiliser cette option que si vous avez précédemment déterminé que votre compte souffre d'être incapable de charger les pages de badge et qu'ASF ne peut pas fonctionner dessus, omet toujours de charger les informations nécessaires pour démarrer le processus. Même si nous avons fait de notre mieux pour optimiser le processus autant que possible, il est toujours possible pour cette option de faire marche arrière, et cela pourrait causer des conséquences indésirables, comme des interdictions temporaires et peut-être même permanentes de Steam pour avoir envoyé trop de requêtes et avoir occasionné des surcharges sur les serveurs Steam. Par conséquent, nous vous avertissons à l'avance et nous offrons cette option sans aucune garantie, vous l'utilisez à vos propres risques.

`AutoUnpackBoosterPacks` décompressera automatiquement tous les packs de booster en recevant la notification des nouveaux objets. Cela vous permettra d'acquérir immédiatement des gouttes de cartes supplémentaires, ce qui peut être voulu, en particulier en combinaison avec d'autres options (e. . `SteamTradeMatcher` ou `CompleteTypesToSend`.

---

### `GamesPlayedWhileIdle`

`ImmutableHashSet<uint>` avec la valeur par défaut étant vide. Si ASF n'a rien à exploiter, il peut jouer à vos jeux Steam spécifiés (`appIDs`) à la place. Jouer de cette manière augmente vos « heures de jeu » de ces jeux, mais rien d'autre que ça. Pour que cette fonctionnalité fonctionne correctement, votre compte Steam **doit** posséder une licence valide pour tous les `appIDs` que vous spécifiez ici, Cela inclut également les jeux F2P. Cette fonctionnalité peut être activée en même temps que `CustomGamePlayedWhileIdle` afin de jouer à vos jeux sélectionnés tout en affichant un statut personnalisé sur le réseau Steam. Cependant, dans ce cas, comme pour `CustomGamePlayedWhileFarming`, l’ordre réel d’affichage n’est pas garanti. Veuillez noter que Steam permet à ASF de jouer jusqu'à `32` `appIDs` au total, vous ne pouvez donc mettre que autant de jeux dans cette propriété.

---

### `Type de périphérique de jeu`

`ushort` type avec valeur par défaut de `1`. Cette propriété peut activer certaines fonctionnalités supplémentaires en ligne sur la plateforme Steam, et est définie comme suit:

| Valeur  | Nom                  | Description                         |
| ------- | -------------------- | ----------------------------------- |
| 1       | format@@0 StandardPC | Aucun mode spécial, par défaut      |
| 544     | Deck à vapeur        | Se présenter en tant que deck Steam |

Le type `EGamingDeviceType` sous-jacent sur lequel cette propriété est basée inclut plus de valeurs disponibles, Mais, au mieux de notre connaissance, ils n'ont absolument aucun effet à partir d'aujourd'hui, donc ils ont été réduits pour la visibilité.

Si vous n'êtes pas sur du réglage de cette propriété, laissez-la à la valeur par défaut de `1`.

---

### `HoursUntilCardDrops`

`byte` avec la valeur par défaut `3`. Cette propriété définit si le compte a des pertes de carte restreinte, et si oui, pour combien d'heures initiales. Les cartes restreintes signifient que le compte ne reçoit aucun dépôt de carte de la partie donnée tant que la partie n'est pas jouée pendant au moins `HoursUntilCardDrops` heures. Malheureusement, il n’y a pas de moyen magique de le détecter, ASF repose donc sur vous. Cette propriété affecte **[l’algorithme de farming des cartes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** qui sera utilisé. Définir correctement cette propriété maximisera les profits et minimisera le temps nécessaire pour que les cartes soient exploitées. Rappelez-vous qu'il n'y a pas de réponse évidente si vous devez utiliser une ou une autre valeur, car cela dépend entièrement de votre compte. Il semble que les anciens comptes qui n'ont jamais demandé de remboursement aient des pertes de cartes, donc ils devraient utiliser une valeur de `0`, alors que les nouveaux comptes et ceux qui ont demandé le remboursement ont des cartes restreintes d'une valeur de `3`. Il ne s'agit toutefois que d'une théorie, et elle ne doit pas être considérée comme une règle. La valeur par défaut de cette propriété a été définie en fonction du "moindre mal" et de la majorité des cas d'utilisation.

---

### `LootableTypes`

`ImmutableHashSet<byte>` type avec une valeur par défaut de `1, 3, 5` type d'élément vapeur. Cette fonction définit le comportement ASF lors du pillage - les deux manuels, en utilisant une commande **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, ainsi que les propriétés automatiques, à travers une ou plusieurs propriétés de configuration. ASF s'assurera que seuls les éléments de `LootableTypes` seront inclus dans une offre commerciale, par conséquent, cette propriété vous permet de choisir ce que vous voulez recevoir dans une offre commerciale qui vous est envoyée.

| Valeur  | Nom                     | Description                                                                            |
| ------- | ----------------------- | -------------------------------------------------------------------------------------- |
| 0       | Unknown                 | Tous les types qui ne correspondent à aucun des éléments ci-dessous                    |
| 1       | BoosterPack             | Paquet de cartes contenant 3 cartes aléatoires d'un jeu                                |
| 2       | Emoticon                | Emoji à utiliser dans le chat Steam                                                    |
| 3       | FoilTradingCard         | Variante brillante de `TradingCard`                                                    |
| 4       | ProfileBackground       | Fond d'écran à utiliser sur votre profil Steam                                         |
| 5       | Carte à échanger        | Carte Steam à échanger, utilisée dans la fabrication de badges (non-brillants)         |
| 6       | SteamGems               | Gemmes Steam utilisés dans la fabrication des paquets de cartes, sacs de gemmes inclus |
| 7       | SaleItem                | Articles spéciaux attribués lors des soldes Steam                                      |
| 8       | Consumable              | Articles consommables spéciaux qui disparaissent après avoir été utilisés              |
| 9       | ProfileModifier         | Articles spéciaux qui peuvent modifier l'apparence du profil Steam                     |
| 10      | Autocollant             | Objets spéciaux pouvant être utilisés dans le chat Steam                               |
| 11      | ChatEffect              | Objets spéciaux pouvant être utilisés dans le chat Steam                               |
| 12      | MiniProfileArrière-plan | Arrière-plan spécial pour le profil Steam                                              |
| 13      | Cadre de profil avatar  | Cadre d'avatar spécial pour le profil Steam                                            |
| 14      | AnimatedAvatar          | Avatar animé spécial pour le profil Steam                                              |
| 15      | Thème de clavier        | Thème de clavier spécial pour le deck Steam                                            |
| 16      | Vidéo de démarrage      | Vidéo de démarrage spéciale pour le deck Steam                                         |

Veuillez noter que quels que soient les paramètres ci-dessus, ASF ne demandera que les éléments **[de la communauté Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` de 753, `contextID` de 6), donc tous les objets du jeu, les cadeaux et les autres sont exclus de l'offre commerciale par définition.

Le paramètre ASF par défaut est basé sur l'utilisation la plus courante du bot, avec des packs de booster de pillage et des cartes de trading (y compris les foils). La propriété définie ici vous permet de modifier ce comportement d'une manière qui vous convient. Veuillez garder à l’esprit que tous les types non définis ci-dessus apparaîtront comme type `Unknown`, ce qui est particulièrement important lorsque Valve publie un nouvel objet Steam, qui sera également marqué comme `Unknown` par ASF, jusqu’à ce qu’il soit ajouté ici (dans une future version). C'est pourquoi, en général, il n'est pas recommandé d'inclure le type `inconnu` dans votre `LootableTypes`, sauf si vous savez ce que vous faites, et vous comprenez également qu'ASF enverra votre inventaire entier dans une offre commerciale si le réseau Steam est cassé à nouveau et signale tous vos éléments comme `Inconnu`. Ma forte suggestion est de ne pas inclure le type `inconnu` dans le `LootableTypes`, même si vous vous attendez à tout ramasser (sinon).

---

### `Nom de la machine`

`chaîne` avec la valeur par défaut `null`. ASF utilisera cette propriété lors de la connexion au réseau Steam, qui peut être utilisé pour la personnalisation en ce qui concerne la façon dont Steam affichera exactement la machine et la session ASF. . lors de l'affichage des appareils qui sont actuellement connectés à **[ici](https://store.steampowered.com/account/authorizeddevices)**.

ASF fournit quelques variables spéciales que vous pouvez éventuellement utiliser dans votre texte. `{0}` sera remplacé par le nom de la machine fournie par votre OS, `{1}` sera remplacé par l'identifiant public de ASF, tandis que `{2}` sera remplacé par la version d'ASF.

À moins que vous ne sachiez ce que vous faites, vous devriez le conserver avec la valeur par défaut de `null`. Dans ce cas, ASF décidera en interne de la valeur appropriée, qui est `{0} ({1}/{2})` à partir d'aujourd'hui. Gardez à l'esprit qu'il ne s'agit là que d'une suggestion que le réseau Steam peut, ou ne peut pas, respecter intégralement.

---

### `MatchableTypes`

`ImmutableHashSet<byte>` type avec une valeur par défaut de `5` types d'élément Steam. Cette propriété définit quels types d'élément Steam sont autorisés à correspondre lorsque l'option `SteamTradeMatcher` dans `TradingPreferences` est activée. Les types sont définis comme ci-dessous:

| Valeur  | Nom                     | Description                                                                            |
| ------- | ----------------------- | -------------------------------------------------------------------------------------- |
| 0       | Unknown                 | Tous les types qui ne correspondent à aucun des éléments ci-dessous                    |
| 1       | BoosterPack             | Paquet de cartes contenant 3 cartes aléatoires d'un jeu                                |
| 2       | Emoticon                | Emoji à utiliser dans le chat Steam                                                    |
| 3       | FoilTradingCard         | Variante brillante de `TradingCard`                                                    |
| 4       | ProfileBackground       | Fond d'écran à utiliser sur votre profil Steam                                         |
| 5       | Carte à échanger        | Carte Steam à échanger, utilisée dans la fabrication de badges (non-brillants)         |
| 6       | SteamGems               | Gemmes Steam utilisés dans la fabrication des paquets de cartes, sacs de gemmes inclus |
| 7       | SaleItem                | Articles spéciaux attribués lors des soldes Steam                                      |
| 8       | Consumable              | Articles consommables spéciaux qui disparaissent après avoir été utilisés              |
| 9       | ProfileModifier         | Articles spéciaux qui peuvent modifier l'apparence du profil Steam                     |
| 10      | Autocollant             | Objets spéciaux pouvant être utilisés dans le chat Steam                               |
| 11      | ChatEffect              | Objets spéciaux pouvant être utilisés dans le chat Steam                               |
| 12      | MiniProfileArrière-plan | Arrière-plan spécial pour le profil Steam                                              |
| 13      | Cadre de profil avatar  | Cadre d'avatar spécial pour le profil Steam                                            |
| 14      | AnimatedAvatar          | Avatar animé spécial pour le profil Steam                                              |
| 15      | Thème de clavier        | Thème de clavier spécial pour le deck Steam                                            |
| 16      | Vidéo de démarrage      | Vidéo de démarrage spéciale pour le deck Steam                                         |

Bien sûr, les types que vous devez utiliser pour cette propriété n'incluent généralement que `2`, `3`, `4` et `5`, car seuls ces types sont supportés par STM. ASF inclut une logique appropriée pour découvrir la rareté des éléments, il est donc également sûr de faire correspondre les émoticônes ou les arrière-plans, car ASF ne considérera comme juste que les éléments du même jeu et du même type, qui partagent également la même rareté.

Veuillez noter que **ASF n'est pas un bot de négociation** et **ne se souciera pas du prix du marché**. Si vous ne considérez pas que les objets de la même rareté du même ensemble sont dans le même sens des prix, alors cette option n'est PAS pour vous. Veuillez évaluer deux fois si vous comprenez et acceptez cette déclaration avant de décider de modifier ce paramètre.

À moins que vous ne sachiez ce que vous faites, vous devriez le conserver avec la valeur par défaut de `5`.

---

### `Drapeaux en ligne`

`ushort flags` type avec valeur par défaut de `0`. Cette propriété fonctionne en supplément à **[`OnlineStatus`](#onlinestatus)** et spécifie des fonctionnalités supplémentaires de présence en ligne annoncées sur le réseau Steam. Nécessite **[`OnlineStatus`](#onlinestatus)** autre que `Offline`, et est défini comme suit :

| Valeur  | Nom                          | Description                                                 |
| ------- | ---------------------------- | ----------------------------------------------------------- |
| 0       | None                         | Aucun indicateur spécial de présence en ligne, par défaut   |
| 2       | InJoinableGame               | Le client est en jeu joignable                              |
| 8       | format@@0 RemotePlayTogether | Le client utilise la session de lecture à distance ensemble |
| 256     | ClientTypeWeb                | Le client utilise l'interface web                           |
| 512     | ClientTypeMobile             | Le client utilise l'application mobile                      |
| 1024    | ClientTypeTenfoot            | Le client utilise une grande image                          |
| 2048    | ClientTypeVR                 | Le client utilise un casque VR                              |

Veuillez noter que cette  fonction est le champ `flags`, il est donc possible de choisir n’importe quelle combinaison de valeurs disponibles. Consultez le mapping Json **[](#json-mapping)** si vous souhaitez en savoir plus. Si aucun indicateur n’est activé, l’option `None` est activée.

Le type `EPersonaStateFlag` sous-jacent sur lequel cette propriété est basée inclut plus de drapeaux disponibles, Mais, au mieux de notre connaissance, ils n'ont absolument aucun effet à partir d'aujourd'hui, donc ils ont été réduits pour la visibilité.

Si vous n'êtes pas sur du réglage de cette propriété, laissez-la à la valeur par défaut de `0`.

---

### `OnlineStatus`

`byte` avec la valeur par défaut `1`. Cette propriété spécifie le statut de la communauté Steam avec laquelle le bot sera annoncé après la connexion au réseau Steam. Vous pouvez actuellement choisir un des statuts ci-dessous:

| Valeur  | Nom            |
| ------- | -------------- |
| 0       | Hors ligne     |
| 1       | En ligne       |
| 2       | Busy           |
| 3       | Away           |
| 4       | Snooze         |
| 5       | LookingToTrade |
| 6       | LookingToPlay  |
| 7       | Invisible      |

Le statut `Offline` est extrêmement utile pour les comptes principaux. Comme vous le savez, le farming d'un jeu montre en fait votre statut de Steam comme "Jouer au jeu: XXX", qui peut être trompeuse pour vos amis, les trompant que vous jouez à un jeu alors que vous êtes seulement en train de le fermer. L’utilisation du statut `Offline` résout ce problème: votre compte ne sera jamais affiché comme « en jeu » lorsque vous farmerez des cartes Steam avec ASF. Ceci est possible grâce au fait qu'ASF n'a pas à se connecter à la communauté Steam pour fonctionner correctement, donc nous jouons en fait à ces jeux, connectés au réseau Steam, mais sans annoncer notre présence en ligne du tout. Gardez à l'esprit que les jeux joués en utilisant le statut hors ligne compteront toujours pour votre temps de jeu, et qu'ils apparaîtront comme "récemment joués" sur votre profil.

En outre, cette fonctionnalité est également importante si vous souhaitez recevoir des notifications et des messages non lus lorsque ASF est en cours d’exécution, sans garder le client Steam ouvert en même temps. Ceci est dû au fait qu'ASF agit en tant que client Steam lui-même, et que ASF le veuille ou non, Steam diffuse tous ces messages et autres événements. Ce n'est pas un problème si vous avez à la fois ASF et votre propre client Steam en cours d'exécution, car les deux clients reçoivent exactement les mêmes événements. Cependant, si seulement ASF est en cours d'exécution, le réseau Steam pourrait marquer certains événements et messages comme étant "distribués", malgré votre client Steam traditionnel qui ne le reçoit pas en raison de son absence. Le statut hors ligne résout également ce problème, car ASF n'est jamais pris en compte pour aucun événement de la communauté dans ce cas, ainsi tous les messages non lus et autres événements seront correctement marqués comme non lus lorsque vous reviendrez.

Il est important de noter qu’ASF fonctionnant en mode `Offline` **ne** pourra pas recevoir de commandes via le chat Steam habituel, car le chat, ainsi que toute présence sur la communauté, sont en fait entièrement hors ligne. Une solution à ce problème est d'utiliser le mode `Invisible` à la place qui fonctionne de manière similaire (ne pas exposer l'état), mais conserve la possibilité de recevoir et de répondre aux messages (ainsi que le risque de rejeter les notifications et les messages non lus comme indiqué ci-dessus). `Le mode Invisible` a le plus de sens sur les comptes alt que vous ne voulez pas exposer (sagesse du statut), mais être toujours en mesure d'envoyer des commandes à.

Cependant, il y a une capture avec le mode `Invisible` - il ne va pas bien avec les comptes principaux. En effet, **toute session Steam** qui est actuellement en ligne **expose** le statut, même si ASF lui-même ne le fait pas. Ceci est causé par la limitation/bug actuel du réseau Steam qui ne peut pas être résolu du côté ASF, donc si vous voulez utiliser le mode `Invisible` vous devrez également vous assurer que **toutes les autres sessions** au même compte utilisent également le mode `Invisible`. Ce sera le cas pour les comptes alt où ASF est, espérons-le, la seule session active, mais sur les comptes principaux, vous préférerez presque toujours montrer à vos amis comme `en ligne` masquage uniquement de l'activité ASF, et dans ce cas, le mode `Invisible` sera entièrement inutile pour vous (nous vous recommandons d'utiliser le mode `hors ligne` à la place). Espérons que cette limitation/bug sera finalement résolue par Valve dans le futur, mais je ne m'attendrais pas à ce que cela se produise prochainement...

Si vous n'êtes pas sûr de la façon de configurer cette propriété, il est recommandé d'utiliser une valeur de `0` (`hors ligne`) pour les comptes principaux, et par défaut `1` (``) sinon.

---

### `PasswordFormat`

`octet` type avec la valeur par défaut de `0` (`PlainText`). Cette propriété définit le format de la propriété `SteamPassword` et supporte actuellement les valeurs spécifiées dans la section **[sécurité](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**. Vous devriez suivre les instructions spécifiées là-bas, car vous devrez vous assurer que la propriété `SteamPassword` inclut effectivement le mot de passe dans `PasswordFormat`. En d'autres termes, lorsque vous changez `PasswordFormat` alors votre `SteamPassword` devrait être **déjà** dans ce format, pas seulement visé à être. À moins que vous ne sachiez ce que vous faites, vous devriez le conserver avec la valeur par défaut de `0`.

Si vous décidez de changer `PasswordFormat` d'un bot qui s'est déjà connecté au réseau Steam au moins une fois, Il est possible que vous receviez une erreur de décryptage unique au démarrage du bot suivant - cela est dû au fait que `PasswordFormat` est également utilisé en ce qui concerne le chiffrement/décryptage automatique des propriétés sensibles dans `Bot. b` fichier de base de données. Vous pouvez ignorer cette erreur en toute sécurité, car ASF sera en mesure de se remettre de cette situation par lui-même. Si cela se produit sur une base constante, par exemple chaque redémarrage, il devrait être étudié.

---

### `RedeemingPreferences`

`chaîne` avec la valeur par défaut `0`. Cette fonction définit le comportement ASF lors de l'utilisation des clés cd, et est définie comme suit:

| Valeur  | Nom                                           | Description                                                                                                                                       |
| ------- | --------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0       | None                                          | Pas de préférences d'échange spéciales, par défaut                                                                                                |
| 1       | Forwarding                                    | Clés de transfert indisponibles pour être échangées avec d'autres robots                                                                          |
| 2       | Distributing                                  | Distribuer toutes les clés entre elles et les autres robots                                                                                       |
| 4       | KeepMissingGames                              | Garder les clés pour (potentiellement) les parties manquantes lors de leur transfert, les laissant inutilisées                                    |
| 8       | Assumer PortefeuilleKeyOnBadCode d'activation | Supposons que les clés `BadActivationCode` sont égales à `CannotRedeemCodeFromClient`, et essayez donc de les utiliser comme clés de portefeuille |

Veuillez noter que cette  fonction est le champ `flags`, il est donc possible de choisir n’importe quelle combinaison de valeurs disponibles. Consultez le mapping Json **[](#json-mapping)** si vous souhaitez en savoir plus. Si aucun indicateur n’est activé, l’option `None` est activée.

`Transférer` fera transférer au bot une clé qui n'est pas possible à utiliser, à un autre bot connecté et connecté qui manque ce jeu particulier (si possible à vérifier). La situation la plus commune est de transférer le jeu `déjà acheté` à un autre bot qui manque ce jeu particulier, mais cette option couvre également d'autres scénarios, comme `DoesNotOwnRequiredApp`, `RateLimited` ou `RestrictedCountry`.

`Distribuer` fera que le bot distribuera toutes les clés reçues entre lui-même et les autres bots. Cela signifie que chaque bot recevra une seule clé depuis le lot. Généralement, ceci n'est utilisé que lorsque vous utilisez plusieurs clés pour le même jeu, et vous voulez les distribuer uniformément entre vos bots, au lieu de les échanger pour différents jeux. Cette fonctionnalité n'a aucun sens si vous n'utilisez qu'une seule clé dans une seule action `pour échanger` (comme il n'y a pas de clés supplémentaires à distribuer).

`KeepMissingGames` fera passer le bot `Transférer` quand nous ne sommes pas sûrs que la clé échangée soit en fait la propriété de notre bot, ou non. Cela signifie que `Transférer` appliquera **seulement** aux clés `déjà achetées` , au lieu de couvrir d'autres cas comme `DoesNotOwnRequiredApp`, `RateLimited` ou `RestrictedCountry`. Généralement vous voulez utiliser cette option sur le compte principal, pour s'assurer que les clés qui y sont échangées ne seront pas transférées plus loin si votre bot par exemple devient temporairement `RateLimited`. Comme vous pouvez le deviner à partir de la description, ce champ n'a absolument aucun effet si `Forwarding` n'est pas activé.

`AssumeWalletKeyOnBadActivationCode` fera traiter les clés `BadActivationCode` comme `CannotRedeemCodeFromClient`, et, par conséquent, ASF essaye de les utiliser comme clés de portefeuille. Ceci est nécessaire parce que Steam pourrait annoncer les clés du portefeuille comme `BadActivationCode` (et non pas `CannotRedeemCodeFromClient` comme il était utilisé), ASF n'essaye jamais de les racheter. Cependant, nous recommandons **contre** en utilisant cette préférence, car cela conduira ASF à essayer d'utiliser toutes les clés non valides en tant que code de portefeuille, ce qui entraîne une quantité excessive de requêtes (potentiellement invalides) envoyées au service Steam, avec toutes les conséquences potentielles. Au lieu de cela, nous vous recommandons d'utiliser le mode `ForceAssumeWalletKey` **[`redeem^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** en utilisant sciemment les clés du portefeuille, qui permettra de contourner le besoin uniquement lorsque cela est nécessaire, au besoin.

Activer à la fois `Forwarding` et `Distributing` ajoutera la fonctionnalité de distribution en plus de la redirection un, qui permet à ASF d’essayer d’utiliser une clé sur tous les bots d’abord (rediriger) avant de passer à la suivante (distribution). Généralement, vous ne souhaitez utiliser cette option que lorsque vous voulez `Transférer`, mais avec un comportement modifié de basculer le bot sur la touche utilisée, au lieu de toujours passer en ordre avec chaque clé (qui serait `Transférer` seule). Ce comportement peut être bénéfique si vous savez que la majorité ou même toutes vos clés sont liées au même jeu, parce que dans cette situation, `Transférer` à lui seul essaierait de tout échanger sur un bot d'abord (ce qui a un sens si vos clés sont pour des jeux uniques), et `Transférer` + `Distribuer` changera le bot à la touche suivante, "distribution" la tâche d'échanger une nouvelle clé sur un autre bot que la première (ce qui a un sens si les clés sont pour le même jeu, ignore une tentative inutile par clé).

L’ordre actuel des bots pour tous les scénarios d’échange est alphabétique, excluant les bots qui ne sont pas disponibles (non connectés, arrêtés ou similaires). Veuillez garder à l'esprit qu'il y a une limite horaire par IP et par compte pour les tentatives d'échange, et chaque tentative de rachat qui ne s'est pas terminée avec `OK` contribue à des tentatives infructueuses. ASF fera de son mieux pour minimiser le nombre d'échecs `déjà achetés` , p. ex. en essayant d'éviter de transférer une clé vers un autre bot qui possède déjà ce jeu particulier, mais ce n'est pas toujours garanti de fonctionner en raison de la façon dont Steam gère les licences. Utiliser des drapeaux échangeables comme `Forwarding` ou `Distributing` augmentera toujours votre probabilité de toucher `RateLimited`.

Gardez également à l'esprit que vous ne pouvez pas transférer ou distribuer des clés aux bots auxquels vous n'avez pas accès. Cela devrait être évident, mais assurez-vous d’être au moins `Operator` de tous les bots que vous souhaitez inclure dans votre processus de récupération, par exemple avec la `commande` **[status ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `Communication à distance`

`byte flags` avec la valeur par défaut `3`. Cette fonction définit le comportement ASF par bot en matière de communication avec les services distants et tiers et est définie comme suit:

| Valeur  | Nom              | Description                                                                                                                                                                                                                                                              |
| ------- | ---------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| 0       | Aucune           | Aucune communication tierce autorisée, rendant les fonctionnalités ASF sélectionnées inutilisables                                                                                                                                                                       |
| 1       | Groupe de vapeur | Permet la communication avec le groupe Steam **[ASF](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                       |
| 2       | Liste publique   | Permet la communication avec la liste **[ASF STM](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** pour être listée, si l'utilisateur a également activé `SteamTradeMatcher` dans **[`TradingPreferences`](#tradingpreferences)** |

Veuillez noter que cette  fonction est le champ `flags`, il est donc possible de choisir n’importe quelle combinaison de valeurs disponibles. Consultez le mapping Json **[](#json-mapping)** si vous souhaitez en savoir plus. Si aucun indicateur n’est activé, l’option `None` est activée.

Cette option n'inclut pas toutes les communications tierces offertes par ASF, seulement celles qui ne sont pas implicites par d'autres paramètres. Par exemple, si vous avez activé les mises à jour automatiques d'ASF, ASF communiquera avec GitHub (pour les téléchargements) et notre serveur (pour la vérification de la somme de contrôle), conformément à votre configuration. De même, l'activation de `MatchActively` en **[`TradingPreferences`](#tradingpreferences)** implique la communication avec notre serveur pour récupérer les bots listés, qui est nécessaire pour cette fonctionnalité.

Des explications supplémentaires sur ce sujet sont disponibles dans la section **[communication distante](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

### `SendTradePeriod`

`byte` avec la valeur par défaut `0`. Cette propriété fonctionne très similaire à `SendOnFarmingFinished` préférence dans `FarmingPreferences`, avec une différence - au lieu d'envoyer le commerce lorsque l'agriculture est faite, nous pouvons également l'envoyer toutes les `SendTradePeriod` heures, quel que soit le montant de la ferme restante. C’est utile si vous souhaitez `loot` vos comptes secondaires de manière régulière, plutôt que d’attendre qu’ils terminent leur session de farming. La valeur par défaut de `0` désactive cette fonctionnalité, si vous voulez que votre bot vous envoie un échange. . tous les jours, vous devriez mettre `24` ici.

Généralement, vous voudrez utiliser **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** avec cette fonctionnalité, Bien que ce ne soit pas une exigence si vous avez l'intention de traiter manuellement les confirmations 2FA dans les meilleurs délais. Si vous n'êtes pas sur du réglage de cette propriété, laissez-la à la valeur par défaut de `0`.

---

### `SteamLogin`

`chaîne` avec la valeur par défaut `null`. Cette propriété définit votre login Steam - celui que vous utilisez pour vous connecter à la vapeur. En plus de définir la connexion Steam ici, vous pouvez également conserver la valeur par défaut de `null` si vous voulez entrer votre login Steam à chaque démarrage d'ASF au lieu de le mettre dans la configuration. Cela peut être utile pour vous si vous ne voulez pas enregistrer de données sensibles dans le fichier de configuration.

---

### `SteamMasterClanID`

`ulong` avec la valeur par défaut `0`. Cette propriété définit le steamID du groupe Steam que le bot devrait rejoindre automatiquement, y compris son chat de groupe. Vous pouvez vérifier le steamID de votre groupe en naviguant sur sa page **[](https://steamcommunity.com/groups/archiasf)**, puis en ajoutant `/memberslistxml? ml=1` à la fin du lien, donc le lien ressemblera à **[à](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. Ensuite, vous pouvez obtenir le steamID de votre groupe à partir du résultat, il est en balise `<groupID64>`. Dans l'exemple ci-dessus, ce serait `103582791440160998`. En plus d'essayer de rejoindre un groupe donné au démarrage, le bot acceptera également automatiquement les invitations de groupe à ce groupe, qui vous permet d'inviter votre bot manuellement si votre groupe a une adhésion privée. Si vous n'avez aucun groupe dédié à vos bots, vous devriez conserver cette propriété avec la valeur par défaut de `0`.

---

### `SteamParentalCode`

`chaîne` avec la valeur par défaut `null`. Cette propriété définit votre NIP parental. ASF nécessite un accès aux ressources protégées par Steam parental, donc si vous utilisez cette fonctionnalité, vous devez fournir à ASF un code PIN de déverrouillage parental, afin qu'il puisse fonctionner normalement. La valeur par défaut de `null` signifie qu'il n'y a pas de code PIN du parent Steam requis pour débloquer ce compte, et c'est probablement ce que vous voulez si vous n'utilisez pas les fonctionnalités parentales de Steam.

Dans des circonstances limitées, ASF est également en mesure de générer un code parent Steam valide lui-même, bien que cela nécessite un nombre excessif de ressources du système d'exploitation et un temps supplémentaire pour compléter, sans compter que ce n'est pas garanti de réussir, donc nous vous recommandons de ne pas vous fier à cette fonctionnalité et de mettre à la place `SteamParentalCode` valide dans la configuration pour qu'ASF puisse utiliser. Si ASF détermine que le code PIN est requis et qu'il ne pourra pas en générer un seul, il vous demandera de le saisir.

---

### `SteamPassword`

`chaîne` avec la valeur par défaut `null`. Cette propriété définit votre mot de passe Steam - celui que vous utilisez pour vous connecter à Steam. En plus de définir le mot de passe Steam ici, vous pouvez également conserver la valeur par défaut de `null` si vous souhaitez entrer votre mot de passe Steam à chaque démarrage d'ASF au lieu de le mettre dans la configuration. Cela peut être utile pour vous si vous ne voulez pas enregistrer de données sensibles dans le fichier de configuration.

---

### `SteamTradeToken`

`chaîne` avec la valeur par défaut `null`. Quand vous avez votre bot sur votre liste d'amis, alors le bot peut vous envoyer un échange sans vous soucier du jeton d'échange, donc vous pouvez laisser cette propriété à la valeur par défaut de `null`. Si vous décidez cependant de NE PAS avoir votre bot sur votre liste d'amis, vous devrez alors générer et remplir un jeton d'échange en tant qu'utilisateur auquel ce bot s'attend à envoyer des échanges. En d'autres termes, cette propriété doit être remplie avec le jeton d'échange du compte qui est défini avec la permission `Master` dans `SteamUserPermissions` de **cette instance de bot**.

Afin de trouver votre jeton, en tant qu'utilisateur connecté avec la permission `Master` , naviguez sur **[ici](https://steamcommunity.com/my/tradeoffers/privacy)** et jetez un coup d'œil à votre URL de trading. Le jeton que nous recherchons est fait de 8 caractères après la partie `&jeton =` dans votre URL d'échange. Vous devriez copier et mettre ces 8 caractères ici, comme `SteamTradeToken`. N'incluez pas l'URL de trading entière, ni la partie `&token=` , seulement le jeton lui-même (8 caractères).

---

### `SteamUserPermissions`

`ImmutableDictionary<ulong, byte>` type avec la valeur par défaut d'être vide. Cette propriété est un dictionnaire qui associe chaque utilisateur Steam, identifié par son ID Steam 64 bits, à un nombre `byte` spécifiant ses permissions dans l’instance ASF. Les permissions de bot actuellement disponibles dans ASF sont définies comme :

| Valeur  | Nom             | Description                                                                                                                                                                                                                                                            |
| ------- | --------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0       | None            | Aucune permission spéciale, il s'agit principalement d'une valeur de référence qui est assignée aux IDs Steam manquants dans ce dictionnaire - il n'y a pas besoin de définir quelqu'un avec cette permission                                                          |
| 1       | PartageFamilial | Fournit un accès minimum aux utilisateurs de partage de la famille. Encore une fois, il s'agit principalement d'une valeur de référence car ASF est capable de découvrir automatiquement les identifiants Steam que nous avons autorisés à utiliser notre bibliothèque |
| 2       | Opérateur       | Fournit un accès de base à des instances de bot données, ajoutant principalement des licences et échangeant des clés                                                                                                                                                   |
| 3       | Maître          | Fournit un accès complet à une instance de bot donnée                                                                                                                                                                                                                  |

En bref, cette propriété vous permet de gérer les permissions pour un utilisateur donné. Les autorisations sont importantes principalement pour l'accès aux commandes ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, mais aussi pour l'activation de nombreuses fonctionnalités ASF, telles que l'acceptation de trades. Par exemple, vous pourriez vouloir définir votre propre compte comme `Master`, et donner à l'opérateur `` accès à 2-3 de vos amis afin qu'ils puissent facilement échanger des clés pour votre bot avec ASF, alors que **et non** sont éligibles. . - pour l’arrêter. Grâce à cela, vous pouvez facilement assigner des permissions à des utilisateurs donnés et les laisser utiliser votre bot à certains spécifiés par votre degré.

Nous vous recommandons de définir exactement un utilisateur en tant que `Master`et tout montant que vous souhaitez, en tant qu'Opérateurs `` et ci-dessous. Bien qu'il soit techniquement possible de définir plusieurs `Masters` et ASF fonctionnera correctement avec eux, par exemple en acceptant toutes leurs transactions envoyées au bot, ASF n'utilisera qu'un seul d'entre eux (avec l'ID Steam le plus bas) pour chaque action qui nécessite une cible unique, par exemple une requête `de butin` donc aussi des propriétés comme `SendOnFarmingFinished` préférence dans `FarmingPreferences` ou `SendTradePeriod`. Si vous comprenez parfaitement ces limitations, en particulier le fait que la requête `loot` enverra toujours les objets au `Master` ayant le plus petit ID Steam, indépendamment du `Master` qui a réellement exécuté la commande, vous pouvez définir plusieurs utilisateurs avec la permission `Master` ici. Cependant, nous recommandons toujours de privilégier un schéma avec un seul master.

Il est agréable de noter qu'il y a une autre permission `Propriétaire` supplémentaire, qui est déclarée en tant que propriété de configuration globale `SteamOwnerID`. Vous ne pouvez pas assigner la permission `Propriétaire` à qui que ce soit ici, comme la propriété `SteamUserPermissions` ne définit que les autorisations qui sont liées à l'instance du bot, et non ASF en tant que processus. Pour les tâches liées au bot, `SteamOwnerID` est traité de la même manière que `Master`, donc définir votre `SteamOwnerID` ici n'est pas nécessaire.

---

### `Période de vérification de l'échange`

`byte` avec la valeur par défaut `60`. Normalement, ASF gère les offres de trading entrantes juste après avoir reçu une notification sur une, mais parfois à cause des bugs de Steam, il ne peut pas le faire à ce moment-là, et ces offres d'échange restent ignorées jusqu'à ce que la prochaine notification de négociation ou le prochain redémarrage du bot, qui peuvent conduire à l'annulation de transactions ou à l'indisponibilité d'articles à ce moment-là. Si ce paramètre est réglé sur une valeur non nulle, ASF vérifiera également pour ces transactions en suspens toutes lesformat@@0 `Période TradeCheckPeriod` minutes. La valeur par défaut est sélectionnée avec le solde entre les requêtes supplémentaires aux serveurs Steam et la perte des transactions entrantes. Cependant, si vous utilisez uniquement ASF pour exploiter des cartes et que vous ne prévoyez pas de traiter automatiquement les transactions entrantes, vous pouvez le régler à `0` pour désactiver complètement cette fonctionnalité. En revanche, si votre bot participe au [STM listing d’ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) public ou fournit d’autres services automatisés en tant que bot de trading, vous pouvez vouloir réduire ce paramètre à environ `15` minutes, afin de traiter tous les échanges en temps voulu.

---

### `TradingPreferences`

`chaîne` avec la valeur par défaut `0`. Cette fonction définit le comportement ASF lors du trading, et est définie comme suit:

| Valeur  | Nom                 | Description                                                                                                                                                                                                                                      |
| ------- | ------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| 0       | None                | Pas de préférences de trading spéciales, défaut                                                                                                                                                                                                  |
| 1       | AcceptDonations     | Accepte les transactions dans lesquelles nous ne perdons rien                                                                                                                                                                                    |
| 2       | SteamTradeMatcher   | Participe passivement à des transactions analogues à **[STM](https://www.steamtradematcher.com)**. Consultez **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** pour plus de détails                   |
| 4       | MatchEverything     | Nécessite que `SteamTradeMatcher` soit défini et, en combinaison avec celui-ci, accepte également les échanges négatifs en plus des échanges positifs et neutres.                                                                                |
| 8       | DontAcceptBotTrades | N'accepte pas automatiquement les transactions `de butin` depuis d'autres instances de bot                                                                                                                                                       |
| 16      | MatchActively       | Participe activement aux transactions similaires à **[STM](https://www.steamtradematcher.com)**. Visitez **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** pour plus d'informations |

Veuillez noter que cette  fonction est le champ `flags`, il est donc possible de choisir n’importe quelle combinaison de valeurs disponibles. Consultez le mapping Json **[](#json-mapping)** si vous souhaitez en savoir plus. Si aucun indicateur n’est activé, l’option `None` est activée.

Pour plus d'explications sur la logique de trading ASF, et la description de chaque drapeau disponible, veuillez visiter la section **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**.

---

### `TransferableTypes`

`ImmutableHashSet<byte>` type avec une valeur par défaut de `1, 3, 5` type d'élément vapeur. Cette propriété définit quels types d'élément Steam seront considérés pour le transfert entre les bots, pendant la commande `transfert` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. ASF s'assurera que seuls les éléments de `Types transférables` seront inclus dans une offre commerciale, donc cette propriété vous permet de choisir ce que vous voulez recevoir dans une offre commerciale qui est envoyée à l'un de vos bots.

| Valeur  | Nom                     | Description                                                                            |
| ------- | ----------------------- | -------------------------------------------------------------------------------------- |
| 0       | Unknown                 | Tous les types qui ne correspondent à aucun des éléments ci-dessous                    |
| 1       | BoosterPack             | Paquet de cartes contenant 3 cartes aléatoires d'un jeu                                |
| 2       | Emoticon                | Emoji à utiliser dans le chat Steam                                                    |
| 3       | FoilTradingCard         | Variante brillante de `TradingCard`                                                    |
| 4       | ProfileBackground       | Fond d'écran à utiliser sur votre profil Steam                                         |
| 5       | Carte à échanger        | Carte Steam à échanger, utilisée dans la fabrication de badges (non-brillants)         |
| 6       | SteamGems               | Gemmes Steam utilisés dans la fabrication des paquets de cartes, sacs de gemmes inclus |
| 7       | SaleItem                | Articles spéciaux attribués lors des soldes Steam                                      |
| 8       | Consumable              | Articles consommables spéciaux qui disparaissent après avoir été utilisés              |
| 9       | ProfileModifier         | Articles spéciaux qui peuvent modifier l'apparence du profil Steam                     |
| 10      | Autocollant             | Objets spéciaux pouvant être utilisés dans le chat Steam                               |
| 11      | ChatEffect              | Objets spéciaux pouvant être utilisés dans le chat Steam                               |
| 12      | MiniProfileArrière-plan | Arrière-plan spécial pour le profil Steam                                              |
| 13      | Cadre de profil avatar  | Cadre d'avatar spécial pour le profil Steam                                            |
| 14      | AnimatedAvatar          | Avatar animé spécial pour le profil Steam                                              |
| 15      | Thème de clavier        | Thème de clavier spécial pour le deck Steam                                            |
| 16      | Vidéo de démarrage      | Vidéo de démarrage spéciale pour le deck Steam                                         |

Veuillez noter que quels que soient les paramètres ci-dessus, ASF ne demandera que les éléments **[de la communauté Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` de 753, `contextID` de 6), donc tous les objets du jeu, les cadeaux et les autres sont exclus de l'offre commerciale par définition.

Le paramètre ASF par défaut est basé sur l'utilisation la plus courante du bot, avec uniquement le transfert de booster packs, et les cartes de trading (y compris les foils). La propriété définie ici vous permet de modifier ce comportement d'une manière qui vous convient. Veuillez garder à l’esprit que tous les types non définis ci-dessus apparaîtront comme de type `Unknown`. Cela est particulièrement important lorsque Valve publie un nouvel objet Steam, qui sera également marqué comme `Unknown` par ASF, jusqu’à ce qu’il soit ajouté ici (dans une future version). C'est pourquoi, en général, il n'est pas recommandé d'inclure un type `inconnu` dans votre `Types transférables`, sauf si vous savez ce que vous faites, et vous comprenez également qu'ASF enverra votre inventaire entier dans une offre commerciale si le réseau Steam est cassé à nouveau et signale tous vos éléments comme `Inconnu`. Ma forte suggestion est de ne pas inclure le type `inconnu` dans le `TransferableTypes`, même si vous vous attendez à tout transférer.

---

### `UseLoginKeys`

`bool` avec la valeur par défaut `true</ 0>. Cette fonction définit si ASF doit utiliser le mécanisme des clés de connexion pour ce compte Steam. Le mécanisme des clés de connexion fonctionne très similaire à l'option officielle « mémorisez moi» du client Steam qui permet à ASF de stocker et d'utiliser temporairement une clé de connexion à usage unique pour la prochaine tentative de connexion, ignorer efficacement le besoin de fournir un mot de passe, Steam Guard ou un code 2FA tant que notre clé de connexion est valide. La clé de connexion est stockée dans le fichier <code>BotName.db` et mise à jour automatiquement. C'est pourquoi vous n'avez pas besoin de fournir un mot de passe/SteamGuard/code 2FA après vous être connecté avec succès avec ASF une seule fois.

Les clés de connexion sont utilisées par défaut pour votre commodité, donc vous n'avez pas besoin de saisir `SteamPassword`, SteamGuard ou code 2FA (lorsque vous n'utilisez pas **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**) à chaque connexion. C'est également une alternative supérieure, car la clé de connexion ne peut être utilisée que pour une seule fois et ne révèle pas votre mot de passe original. Exactement la même méthode est utilisée par votre client Steam d'origine, qui enregistre votre nom de compte et votre clé de connexion pour votre prochaine tentative de connexion, être effectivement le même que l'utilisation de `SteamLogin` avec `UseLoginKeys` et vide `SteamPassword` dans ASF.

Cependant, certains pourraient être inquiets, même à propos de ce petit détail, par conséquent, cette option est disponible ici pour vous si vous souhaitez vous assurer qu'ASF ne conservera aucun type de jeton qui permettrait de reprendre la session précédente après avoir été fermé, qui se traduira par une authentification complète obligatoire à chaque tentative de connexion. Désactiver cette option fonctionnera exactement de la même façon que si vous ne cochez pas « se souvenir de moi» dans le client officiel Steam. À moins que vous ne sachiez ce que vous faites, vous devriez le conserver avec la valeur par défaut de `true`.

---

### `Mode interface utilisateur`

`byte` avec la valeur par défaut `0`. Cette propriété spécifie le mode d'interface utilisateur avec lequel le bot sera annoncé après la connexion au réseau Steam. Cela pourrait influer sur la façon dont le compte est visible, par exemple sur le chat Steam, si votre présence le permet, via `OnlineStatus`. Actuellement, vous pouvez choisir un des modes ci-dessous :

| Valeur  | Nom              | Description                      |
| ------- | ---------------- | -------------------------------- |
| `0`     | VGUI             | Mode client Steam par défaut     |
| `1`     | Tenfoot          | Mode grande image                |
| `2`     | Téléphone mobile | Application mobile Steam         |
| `3`     | Web              | Session du navigateur Web        |
| `5`     | MobileChat       | Application de chat mobile Steam |

Le type `EUIMode` sous-jacent sur lequel cette propriété est basée inclut cependant plus de valeurs disponibles, au mieux de nos connaissances, ils n'ont absolument aucun effet à partir d'aujourd'hui, donc ils ont été réduits pour la visibilité. De plus, vous pourriez être intéressé par la vérification de `GamingDeviceType`, car certaines fonctionnalités supplémentaires y sont activées.

Si vous n'êtes pas sur du réglage de cette propriété, laissez-la à la valeur par défaut de `0`.

---

### `WebProxy`

`chaîne` avec la valeur par défaut `null`. Cette propriété définit une adresse de proxy web qui sera utilisée pour la communication interne liée au bot spécifique, en particulier pour les services tels que l'api `. teampowered.com`, `steamcommunity.com` et `store.steampowered.com`. Si non défini, ASF utilisera le paramètre global `WebProxy` spécifié ci-dessus à la place. Proxter des requêtes ASF pourrait être exceptionnellement utile pour contourner divers types de pare-feu, en particulier le grand pare-feu en Chine.

Cette propriété est définie comme une chaîne uri :

> Une chaîne URI est composée d'un schéma (supporté : http/https/socks4/socks4a/socks5), d'un hôte et d'un port optionnel. Un exemple de chaîne complète uri est `"http://contoso.com:8080"`.

Si votre proxy nécessite une authentification de l'utilisateur, vous devrez également configurer `WebProxyUsername` et/ou `WebProxyPassword`. S'il n'y a pas ce besoin, la création de cette propriété seule suffira.

Si vous avez également besoin d'un proxy interne de communication sur le réseau Steam (CMs) alors vous devriez vous assurer de configurer la propriété du bot **[`SteamProtocols`](#steamprotocols)** à une valeur qui ne permet que le transport de websocket, i. . une valeur de `4`, car seuls les websockets sont supportés pour le proxying.

Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

### `WebProxyPassword`

`chaîne` avec la valeur par défaut `null`. Cette propriété définit le champ mot de passe utilisé dans la base, la digeste, NTLM, et l'authentification Kerberos qui est prise en charge par une machine cible `WebProxy` fournissant des fonctionnalités de proxy. Si votre proxy ne nécessite pas les identifiants de l'utilisateur, vous n'avez pas besoin de saisir quoi que ce soit ici. L'utilisation de cette option n'a de sens que si `WebProxy` est également utilisée, car elle n'a aucun effet contraire.

Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

### `WebProxyUsername`

`chaîne` avec la valeur par défaut `null`. Cette propriété définit le champ nom d'utilisateur utilisé en base, digestif, NTLM, et l'authentification Kerberos qui est prise en charge par une machine cible `WebProxy` fournissant des fonctionnalités de proxy. Si votre proxy ne nécessite pas les identifiants de l'utilisateur, vous n'avez pas besoin de saisir quoi que ce soit ici. L'utilisation de cette option n'a de sens que si `WebProxy` est également utilisée, car elle n'a aucun effet contraire.

Sauf si vous avez une raison de modifier cette fonction, vous devez la conserver par défaut.

---

## Structures des répertoires

ASF utilise une structure de fichier assez simple.

```text
── 📁 config
文─ ─ ASF. fils
文── ASF.db
── Bot1. fils
── Bot1.db
Ω─ ─ Bot2. fils
── Bot2.db
文<unk> ─ ...
├── ArchiSteamFarm.dll
├── log.txt
└── ...
```

Pour déplacer ASF vers un nouvel emplacement, par exemple sur un autre PC, il suffit de déplacer/copier uniquement le répertoire `config`. C’est également la méthode recommandée pour effectuer toute forme de « sauvegarde ASF », car vous pouvez toujours télécharger le reste du programme depuis GitHub, sans risquer de corrompre les fichiers internes d’ASF, par exemple à cause d’une sauvegarde défectueuse.

Le fichier ` log.txt </ 0> contient le journal généré par votre dernière exécution ASF. Ce fichier ne contient aucune information sensible et est extrêmement utile lorsqu'il s'agit de problèmes, de plantages ou simplement en tant qu'informations sur ce qui s'est passé lors de la dernière exécution d'ASF. Nous vous demanderons très souvent si vous rencontrez des problèmes ou des bogues. ASF gère automatiquement ce fichier pour vous, mais vous pouvez encore modifier le module ASF <strong x-id="1"><a href="https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging">de journalisation</a></strong> si vous êtes un utilisateur avancé.</p>

<p spaces-before="0">Le répertoire <code>config` est l'emplacement où se trouve la configuration pour ASF, y compris tous ses bots.

`ASF.json` est un fichier de configuration ASF global. Cette configuration est utilisée pour spécifier comment ASF se comporte comme un processus qui affecte tous les bots et le programme lui-même. Vous pouvez y trouver des fonctions globales, telles que le propriétaire du processus ASF, les mises à jour automatiques ou le debug.

`BotName.json` est une configuration d'instance de bot. Cette configuration est utilisée pour spécifier le comportement d'une instance de bot. Par conséquent, ces paramètres sont spécifiques à ce bot uniquement et ne sont pas partagés entre eux. Cela vous permet de configurer des bots avec différents paramètres et ne fonctionnant pas nécessairement tous de la même manière. Chaque bot est nommé en utilisant un identifiant unique, choisi par vous à la place de `BotName`.

Outre les fichiers de configuration, ASF utilise également le répertoire `config` pour stocker les bases de données.

`ASF.json` est un fichier de configuration ASF global. Il agit comme un stockage persistant global et est utilisé pour enregistrer diverses informations liées au processus ASF, telles que les adresses IP des serveurs Steam locaux. **Vous ne devez pas éditer ce fichier**.

`BotName.db` est une base de données d'instance de bot. Ce fichier est utilisé pour stocker des données cruciales relatives à une instance de bot  dans un stockage persistant, telles que des clés de connexion ou ASF 2FA. **Vous ne devez pas éditer ce fichier**.

`BotName.keys` est un fichier spécial qui peut être utilisé pour importer des clés dans **[jeux d'arrière-plan échangeant](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. Ce n'est pas obligatoire ni généré, mais reconnu par ASF. Ce fichier est automatiquement supprimé une fois les clés importées.

`BotName.maFile` est un fichier spécial qui peut être utilisé pour importer **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**. Ce n'est pas obligatoire ni généré, mais reconnu par ASF si votre `BotName` n'utilise pas encore ASF 2FA. Ce fichier est automatiquement supprimé une fois ASF 2FA importé avec succès.

---

## JSON mapping

Chaque fonction de configuration a son type. Le type de la fonction définit les valeurs qui lui sont valables. Vous ne pouvez utiliser que des valeurs valides pour un type donné. Si vous utilisez une valeur non valide, ASF ne pourra pas analyser votre configuration.

**Nous vous recommandons vivement d’utiliser ConfigGenerator pour générer des configs** - il gère la plupart des tâches de bas niveau (telles que la validation des types), il vous suffit donc de saisir les valeurs appropriées, et vous n'avez pas besoin de comprendre les types de variable spécifiés ci-dessous. Cette section est principalement destinée aux personnes générant / modifiant des configurations manuellement afin qu’elles sachent quelles valeurs elles peuvent utiliser.

Les types utilisés par ASF sont des types C # natifs, spécifiés ci-dessous:

---

`bool` - type Boolean accepte uniquement les valeurs `true` et `false`.

Exemple : `"Enabled": true`

---

`byte` - type d'octet non signé, n'acceptant que des entiers de `0` à `255` (inclus).

Exemple: `"ConnectionTimeout": 90`

---

`ushort` - type court non signé, n'acceptant que des entiers de `0` à `65535` (inclus).

Exemple: `"WebLimiterDelay": 300`

---

`uint` - type entier non signé, n'acceptant que des entiers de `0` à `4294967295` (inclus).

---

`ulong` - type entier long non signé, n'acceptant que des entiers de `0` à `18446744073709551615` (inclus).

Exemple: `"SteamMasterClanID": 103582791440160998`

---

`chaîne` - Type de chaîne, acceptant toute séquence de caractères, y compris la séquence vide `""` et `null`. Les séquences vides et les valeurs `null` sont traitées de la même manière par ASF, donc c'est à votre préférence que vous voulez utiliser (nous restons avec `null`).

Exemples: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MyAccountName"`

---

`Guide ?` - Type UUID Nullable, en JSON encodé en tant que chaîne. L'UUID est fait de 32 caractères hexadécimaux, entre `0` et `9` et `un` à `f`. ASF accepte une variété de formats valides - minuscules, majuscules, avec et sans tirets. En plus de l'UUID valide, puisque cette propriété est nullable, une valeur spéciale de `null` est acceptée pour indiquer le manque d'UUID à fournir.

Exemples: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`Immutable List<valueType>` - Collection immuable (liste) de valeurs dans donnée `type`. En JSON, il est défini comme tableau d'éléments dans la donnée `valueType`. ASF utilise `Liste` pour indiquer que la propriété donnée prend en charge plusieurs valeurs et que leur ordre peut être pertinent.

Exemple pour `Immutable List<byte>`: `"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` - Collection immuable (ensemble) de valeurs uniques en donnée `valueType`. En JSON, il est défini comme tableau d'éléments dans la donnée `valueType`. ASF utilise `HashSet` pour indiquer que la propriété donnée n'a de sens que pour des valeurs uniques et que leur ordre n'a pas d'importance. donc il ignorera intentionnellement tous les doublons potentiels lors de l'analyse (si vous êtes arrivé à les fournir quand même).

Exemple pour `ImmutableHashSet<uint>`: `"Liste noire": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>` - Dictionnaire immuable (carte) qui mappe une clé unique spécifiée dans son `keyType`, à la valeur spécifiée dans son `valueType`. En JSON, il est défini comme un objet avec des paires clé-valeur. Gardez à l'esprit que `keyType` est toujours entre guillemets dans ce cas, même si c'est un type de valeur comme `ulong`. Il y a également une exigence stricte que la clé soit unique sur la carte, cette fois aussi appliquée par JSON.

Exemple pour `ImmutableDictionary<ulong, byte>`: `"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`

---

`flags` - L'attribut Flags combine plusieurs propriétés différentes en une valeur finale en appliquant des opérations au niveau du bit. Cela vous permet de choisir toute combinaison possible de différentes valeurs autorisées en même temps. La valeur finale est construite comme la somme des valeurs de toutes les options activées.

Par exemple, la définition suivante est donnée :

| Valeur  | Nom  |
| ------- | ---- |
| 0       | None |
| 1       | A    |
| 2       | B    |
| 4       | C    |

Il y a exactement 3 options significatives, disponibles pour allumer/éteindre (`A`, `B`, `C`), et donc `8` combinaisons valides globales :

| Valeur finale | Drapeaux activés |
| ------------- | ---------------- |
| 0             | `None`           |
| 1             | `A`              |
| 2             | `B`              |
| 3             | `A` + `B`        |
| 4             | `C`              |
| 5             | `A` + `C`        |
| 6             | `B` + `C`        |
| 7             | `A` + `B` + `C`  |

Par définition, pour permettre ce qui précède, chaque drapeau autonome doit donc être la puissance de deux. C'est pourquoi un indicateur supplémentaire dans l'exemple ci-dessus, `D`devrait porter une valeur de `8` ou plus.

Habituellement, les outils graphiques font le calcul pour vous. Si vous modifiez les configurations manuellement, vous pouvez toujours utiliser la calculatrice et simplement ajouter des valeurs sous-jacentes de tous les drapeaux que vous voulez activer - comme dans l'exemple ci-dessus.

Exemple: `"SteamProtocols": 7` (qui active les drapeaux avec une valeur de `1`, `2` et `4`, comme expliqué ci-dessus)

---

## Mode de compatibilité

En raison des limitations JavaScript de ne pas pouvoir sérialiser correctement les champs simples `ulong` en JSON lors de l'utilisation du ConfigGenerator basé sur le Web, Les champs `ulong` seront rendus en tant que chaînes avec le préfixe `s_` dans la configuration résultante. Cela inclut par exemple `"SteamOwnerID": 76561198006963719` qui sera écrit par notre ConfigGenerator comme `"s_SteamOwnerID": "76561198006963719"`. ASF inclut une logique appropriée pour la gestion automatique de ce mappage de chaîne. Les entrées `s _` de vos configurations sont donc valides et correctement générées. Si vous générez vous-même des configurations, nous vous recommandons, si possible, de vous en tenir aux champs d'origine `ulong`, mais en cas d'impossibilité, vous pouvez également suivre ce schéma et les encoder sous forme de chaînes avec <0 >s_ </code> ajouté à leurs noms. Nous espérons résoudre cette limitation de JavaScript éventuellement.

---

## Compatibilité des configurations

La première priorité est que ASF reste compatible avec les anciennes configurations. Comme vous le savez déjà, les propriétés de configuration manquantes sont traitées de la même manière qu'elles seraient définies avec leurs valeurs **par défaut**. Par conséquent, si une nouvelle propriété de configuration est introduite dans la nouvelle version d’ASF, toutes vos configurations resteront **compatibles** avec la nouvelle version, et ASF traitera cette nouvelle propriété de configuration telle qu’elle serait définie avec sa valeur **valeur par défaut**. Vous pouvez toujours ajouter, supprimer ou modifier les propriétés de configuration en fonction de vos besoins.

Nous vous recommandons de limiter les propriétés de configuration définies à celles que vous voulez modifier, car ainsi vous hériterez automatiquement des valeurs par défaut pour toutes les autres valeurs, non seulement en conservant votre configuration propre, mais aussi en augmentant la compatibilité au cas où nous déciderions de modifier une valeur par défaut pour la propriété que vous ne voulez pas explicitement définir vous-même. . `WebLimiterDelay`).

En raison de ce qui précède, ASF migrera / optimisera automatiquement vos configurations en les formatant et en supprimant les champs qui contiennent la valeur par défaut. Vous pouvez désactiver ce comportement avec `--no-config-migrate` **[argument en ligne de commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** si vous avez une raison spécifique, par exemple, vous fournissez des fichiers de configuration en lecture seule et vous ne voulez pas qu'ASF les modifie.

---

## Auto-reload

ASF est conscient des configurations en cours de modification à la volée - grâce à cela, ASF va automatiquement:
- Créez (et démarrez, si nécessaire) une nouvelle instance de bot lorsque vous créez sa configuration
- Arrêtez (si nécessaire) et supprimez l'ancienne instance de bot lorsque vous supprimez sa configuration
- Arrêtez (et démarrez, si nécessaire) toute instance de bot lorsque vous modifiez sa configuration
- Redémarrez (si nécessaire) le bot sous un nouveau nom lorsque vous renommez sa configuration

Tout ce qui précède est transparent et se fera automatiquement sans qu'il soit nécessaire de redémarrer le programme ou de tuer d'autres instances de bot (non affectées).

En plus de cela, ASF redémarrera également lui-même (si `AutoRestart` le permet) si vous modifiez la configuration de base ASF `ASF.json`. De même, le programme quittera si vous le supprimez ou le renommez.

Vous pouvez désactiver ce comportement avec `--no-config-watch` **[argument en ligne de commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** si vous avez une raison spécifique, par exemple, vous ne voulez pas qu'ASF réagisse aux changements de fichiers dans le dossier `config`.