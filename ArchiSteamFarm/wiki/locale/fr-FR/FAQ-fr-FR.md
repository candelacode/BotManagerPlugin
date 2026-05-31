# FAQ (Questions fréquemment posées)

La FAQ basique couvre les questions classiques et y répond. Pour une question plus spécifique, veuillez consulter notre **[FAQ avancée](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ)** au lieu de celle ci.

# Tables des matières

* [Général](#general)
* [Comparaison avec d’autres outils similaires](#comparison-with-similar-tools)
* [Sécurité / Vie Privée / VAC / Bans / ToS](#security--privacy--vac--bans--tos)
* [Divers](#misc)
* [Problèmes](#issues)

---

## Général

### Qu'est-ce qu'ASF ?
### Pourquoi le programme affirme t-il qu'il n'y a rien à récolter sur mon compte?
### Pourquoi ASF ne détecte pas tous mes jeux?
### Pourquoi mon compte est-il bloqué ?

Avant d'essayer de comprendre ce qu'est ASF, vous devez vous assurer de bien comprendre ce que sont les cartes Steam et comment les obtenir, ce qui est décrit dans la FAQ officielle **[ici](https://steamcommunity.com/tradingcards/faq)**.

En bref, les cartes Steam sont des objets de collection auxquels vous êtes admissible lorsque vous possédez un jeu en particulier. Vous pouvez les utiliser pour confectionner des badges, vendre sur le marché Steam ou à toute autre chose de votre choix.

Les points de base sont à nouveau déclarés ici, parce que les gens en général ne veulent pas être d'accord avec eux et préfèrent faire semblant qu'ils n'existent pas:

- **Vous devez posséder le jeu sur votre compte Steam afin d'être éligible pour tous les gouttes de cartes. Le partage familial n'est pas la propriété et ne compte pas.**
- **Votre jeu ne peut pas être marqué comme [privé](https://help.steampowered.com/faqs/view/1150-C06F-4D62-4966). ASF ignorera automatiquement de tels jeux pendant la fermeture.**
- **Vous ne pouvez pas terminer le jeu à l'infini, chaque jeu a un nombre fixe de cartes. Une fois que vous les avez tous lâchés (environ la moitié de l'ensemble complet), le jeu n'est plus un candidat à l'agriculture. Peu importe que vous ayez vendu, échangé, fabriqué ou oublié ce qui est arrivé à ces cartes que vous avez obtenues, une fois que vous avez épuisé les gouttes de cartes, le jeu est terminé.**
- **Vous ne pouvez pas déposer de cartes dans les jeux F2P sans dépenser de l'argent dedans. Cela signifie des jeux F2P en permanence comme Team Fortress 2 ou Dota 2. Posséder des jeux F2P ne vous accorde pas de cartes en goutte.**
- **Vous ne pouvez pas déposer de cartes sur un compte [limité](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A), indépendamment des jeux possédés et de leur méthode d'activation.**
- **Les jeux payants que vous avez obtenus gratuitement pendant une promotion ne peuvent pas être cultivés pour des gouttes de cartes, peu importe ce qui est affiché sur la page du magasin.**

Comme vous pouvez le voir, les cartes Steam vous sont attribuées pour avoir joué à un jeu que vous avez acheté, ou jeu F2P dans lequel vous avez mis de l'argent. Si vous jouez suffisamment longtemps à ce jeu, toutes les cartes de ce jeu finiront par tomber dans votre inventaire, vous permettant de compléter un badge (après avoir obtenu la moitié restante de l'ensemble), de les vendre ou de faire ce que vous voulez.

Maintenant que nous avons expliqué les bases de Steam, nous pouvons expliquer ASF. Le programme lui-même est assez complexe à comprendre complètement, donc au lieu de fouiller dans tous les détails techniques, nous vous proposons une explication très simplifiée ci-dessous.

ASF se connecte à votre compte Steam via notre implémentation client Steam intégrée et personnalisée en utilisant les informations d'identification fournies. Après connexion réussie, il analyse vos badges **[](https://steamcommunity.com/my/badges)** afin de trouver des jeux disponibles pour le farming (gouttes de cartes`X` restantes). Après avoir analysé toutes les pages et construit la liste finale des jeux disponibles, ASF choisit l'algorithme de farming le plus efficace et lance le processus. Le processus dépend du choix de l'algorithme **[de farming des cartes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** mais généralement il consiste à jouer au jeu éligible et périodiquement (plus de chaque dépôt d'objets) en vérifiant si le jeu est déjà entièrement cultivé - si oui, ASF peut continuer avec le titre suivant, en utilisant la même procédure, jusqu'à ce que tous les jeux soient entièrement fermés.

Gardez à l'esprit que l'explication ci-dessus est simplifiée et ne décrit pas une douzaine de fonctionnalités supplémentaires offertes par ASF. Visitez le reste de **[notre wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki)** si vous souhaitez connaître tous les détails de ASF. J'ai essayé de le rendre assez simple à comprendre pour tout le monde, sans apporter de détails techniques - les utilisateurs avancés sont encouragés à aller plus loin.

En tant que programme, ASF offre de la magie. Tout d'abord, il n'est pas nécessaire de télécharger l'un de vos fichiers de jeu, il peut jouer à des jeux immédiatement.    Deuxièmement, il est totalement indépendant de votre client Steam habituel - vous n'avez pas besoin d'avoir le client Steam en cours d'exécution ni même de l'avoir installé.   . Troisièmement, c'est une solution automatisée - ce qui signifie qu'ASF fait automatiquement tout ce qui est derrière votre dos, sans qu'il soit nécessaire de lui dire quoi faire - ce qui vous permet de gagner du temps. Enfin, il n’a pas à tromper le réseau Steam en émulant un processus (utilisé par exemple par Idle Master), car il peut communiquer directement avec lui. Super rapide et léger, il est également une solution étonnante pour tous ceux qui souhaitent obtenir des cartes facilement et sans tracas. Cela s'avère particulièrement utile si vous le laissez en arrière-plan tout en faisant autre chose, ou même en mode hors connexion.

Tout ce qui précède est agréable, mais ASF a également certaines limitations techniques qui sont appliquées par Steam - nous ne pouvons pas faire de l'exploitation de jeux que vous ne possédez pas. Nous ne pouvons pas continuer à cultiver des jeux pour toujours afin d'obtenir des gouttes supplémentaires au-delà de la limite imposée, et nous ne pouvons pas faire de la ferme pendant que vous jouez. Tout cela devrait être "logique", compte tenu du fonctionnement d'ASF, mais il est agréable de noter qu'ASF n'a pas de super-pouvoirs et ne fera pas quelque chose qui soit physiquement impossible, Donc gardez cela à l'esprit - en gros, c'est la même chose que si vous avez dit à quelqu'un de se connecter sur votre compte depuis un autre PC et de faire la ferme pour vous.

Donc, pour résumer, ASF est un programme qui vous aide à retirer les cartes auxquelles vous êtes éligible, sans tracas. Il offre également plusieurs autres fonctions, mais ignorons pour le moment.

---

### Dois-je mettre les informations d'identification de mon compte?

**Oui**. ASF requiert les informations d'identification de votre compte de la même manière que le client officiel Steam, car il utilise la même méthode pour les interactions avec le réseau Steam. This however doesn't mean that you have to put your account credentials in ASF configs, you can keep using ASF with empty `SteamLogin` and/or `SteamPassword`, and input that data on each ASF run, when required (as well as several other login credentials, refer to configuration). De cette manière, vos données ne sont enregistrées nulle part, mais ASF ne peut bien entendu pas démarrer automatiquement sans votre aide. ASF propose également plusieurs autres moyens d’augmenter votre **[sécurité](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**, alors n'hésitez pas à lire cette partie du wiki si vous êtes un utilisateur expérimenté. Si ce n'est pas le cas, et que vous ne voulez pas mettre vos identifiants de compte dans les configurations ASF, alors ne faites tout simplement pas cela, et au lieu de les saisir au besoin lorsque ASF les demande.

Gardez à l'esprit que l'outil ASF est pour votre usage personnel et que vos informations d'identification ne quittent jamais votre ordinateur. Vous ne les partagez pas avec qui que ce soit, qui remplit **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** - une chose très importante que beaucoup de gens oublient. Vous n'envoyez pas vos coordonnées à nos serveurs ou à des tiers, mais directement aux serveurs Steam de Valve. Nous ne connaissons pas vos identifiants et nous sommes également incapables de les récupérer pour vous, que vous les mettiez ou non dans vos configs.

---

### Combien de temps dois-je attendre que les cartes tombent?

**Autant de temps que necéssaire</ 0> - sérieusement. Chaque développeur a ses propres difficultés de farming définies par les développeurs et les éditeurs, et c’est à eux de décider à quelle vitesse lâcher les cartes. La majorité des jeux donnent une car par phase de 30 minutes de jeu, mais il existe également des jeux qui vous obligent à jouer plusieurs heures avant d'obtenir une carte. En plus de cela, votre compte pourrait être restreint de recevoir des cartes de jeux que vous n'avez pas encore jouées pendant assez de temps. comme indiqué dans la section **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. N'essayez pas de deviner combien de temps ASF devrait prendre pour farmer un jeu - ce n'est pas à vous, ni à ASF de décider. Il n'y a rien que vous puissiez faire pour accélérer les choses, et il n'y a pas de "bug" lié au fait que les cartes ne sont pas fournis à temps - vous ne contrôlez pas le processus d'obtention des cartes, pas plus que ASF. Dans le meilleur des cas, vous recevrez en moyenne  une carte par phase de 30 minutes. Dans le pire des cas, vous ne recevrez aucune carte, même pendant 4 heures depuis le démarrage d'ASF. Ces deux situations sont normales et sont décrites dans notre section **[Performances](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**.</p>

---

### Le farming prend trop de temps, puis-je l'accélérer?

La seule chose qui affecte la vitesse du farming est l’option **[Algorithme de farming des cartes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** sélectionnée pour votre instance de bot. Tout le reste a un effet négligeable et ne rendra pas le farming plus rapide, alors que certaines actions telles que le lancement du processus ASF à plusieurs reprises vont même **l’aggraver**. Si vous souhaitez réellement exploiter chaque seconde du processus d’agriculture, ASF vous permet d’affiner certaines variables  telles que `FarmingDelay` - elles sont toutes expliquées dans **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Cependant, comme je l'ai dit, l'effet est négligeable, et choisir l'algorithme de farming des cartes approprié pour un compte est l'un et le seul choix crucial qui puisse influer fortement sur la vitesse de farming. Tout le reste est purement cosmétique. Au lieu de vous préoccuper de la rapidité de votre exploitation, lancez simplement ASF et laissez-la faire son travail. Je peux vous assurer qu'il le fait de la manière le plus efficace possible. Moins vous vous en souciez, plus vous serez satisfait.

---

### Mais ASF a déclaré que le farming prendrait environ X temps!

ASF vous donne une idée approximative basée sur le nombre de cartes que vous devez obtenir, ainsi que sur l'algorithme choisi. Ce délai est très proche du temps que vous passerez réellement à farmer, ce qui est généralement plus long que cela, ASF ne prenant que le meilleur des cas, ignorant toutes les bizarreries du réseau Steam, les déconnexions Internet, la surcharge des serveurs Steam, etc. Cela devrait être considéré uniquement comme un indicateur général de la durée pendant laquelle vous pouvez vous attendre à ce que ASF farme, très souvent dans le meilleur des cas, car le temps réel diffère, même de manière significative dans certains cas. Comme indiqué ci-dessus, n'essayez pas de deviner combien de temps un jeu sera farmer, ce n'est pas à vous, ni à ASF de décider.

---

### ASF peut-il fonctionner sur mon Android / smartphone?

ASF est un programme C# qui nécessite une implémentation fonctionnelle du .NET. Android est devenu une plateforme valide à partir de .NET 6. , cependant, il y a actuellement un bloqueur majeur pour faire qu'ASF se produise sur Android en raison du manque d'ASP **[. ET runtime disponible sur elle](https://github.com/dotnet/aspnetcore/issues/35077)**. Même s'il n'y a pas d'option native disponible, il y a des versions correctes et fonctionnelles pour GNU/Linux sur l'architecture ARM il est donc totalement possible d'utiliser quelque chose comme **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** pour installer Linux, puis en utilisant ASF dans un chroot Linux comme d'habitude.

Quand/Si toutes les exigences d'ASF sont satisfaites, nous envisageons de publier une version officielle d'Android.

---

### ASF peut-il exploiter des éléments provenant de jeux Steam, tels que CS:GO ou Unturned ?

**No**, this is against **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** and Valve clearly stated that with last wave of community bans for farming TF2 items. ASF est un programme de farming de cartes Steam, et non un élément de jeu. Il ne dispose d'aucune fonctionnalité pour créer des éléments de jeu. Il n'est pas prévu d'ajouter une telle fonctionnalité à l'avenir, en raison notamment d'une violation des conditions d'utilisation de Steam. S'il vous plaît ne demandez pas à ce sujet - le mieux que vous puissiez obtenir est un rapport d'un utilisateur mauvais et vous aurez des problèmes. Il en va de même pour tous les autres types d'agriculture, tels que les gouttes d'agriculture provenant des émissions de CS:GO. ASF se concentre exclusivement sur les cartes à échanger Steam.

---

### Puis-je choisir quels jeux doivent être montés ?

**Oui**, de différentes manières. Si vous voulez modifier l'ordre par défaut de la file d'attente, alors c'est pour cela que la propriété `FarmingOrders` **[de configuration du bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** peut être utilisée. Si vous voulez bloquer manuellement certains jeux en cours d'élevage automatiquement, vous pouvez utiliser la liste noire inactive qui est disponible avec la commande `fb` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Si vous souhaitez tout fermer, mais donner la priorité à certaines applications par rapport à tout le reste, c'est la file d'attente de priorité inactive disponible avec `fq` **[la commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** peut être utilisée. Et enfin, si vous voulez faire des jeux spécifiques de votre choix uniquement, alors vous pouvez déclarer `FarmPriorityQueueOnly` dans les **[`FarmingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)** pour y arriver, avec l'ajout de vos applications sélectionnées à la file d'attente de priorité inactive.

En plus de la gestion du module de farming automatique des cartes décrit ci-dessus, vous pouvez également basculer ASF en mode de farming manuelle à l’aide de la **[commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** `play </ 0> ou utiliser certains autres paramètres externes divers, tels que <code> GamesPlayedWhileIdle` **[dans le fichier de configuration du bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

---

### Je ne suis pas intéressé par les gouttes de cartes, je voudrais élever les heures de jeu à la place, est-ce possible?

Oui, ASF vous permet de le faire de plusieurs manières au moins.

La meilleure façon d'y parvenir est d'utiliser la propriété de configuration **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** qui jouera les identifiants d'application que vous avez choisis lorsque ASF n'a pas de cartes à exploiter. Si vous souhaitez jouer à vos jeux tout le temps, même si vous avez des cartes en provenance d'autres parties, alors vous pouvez le combiner avec **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, ASF ne fermera donc que les jeux pour les gouttes de cartes que vous avez explicitement définies ou, alternativement, **[`FarmingPausedByDefault`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, qui mettra le module de farming des cartes en pause jusqu'à ce que vous le réinstanciez vous-même.

Vous pouvez également utiliser la commande **[`jouer`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#commands-1)** qui fera qu'ASF jouera à vos jeux sélectionnés. Cependant, gardez à l'esprit que `play` ne devrait être utilisé que pour les jeux que vous voulez jouer temporairement, car il ne s'agit pas d'un état persistant, ce qui fait qu'ASF revient à l'état par défaut. . lors de la déconnexion du réseau Steam. Therefore, we recommend you to use `GamesPlayedWhileIdle`, unless you indeed want to start your selected games just for a short time period, and then revert back to general flow.

---

### Je suis un utilisateur de Linux / macOS, les jeux de ferme ASF qui ne sont pas disponibles pour mon OS? ASF fermera-t-il des jeux 64 bits lorsque je l'exécute sur un système d'exploitation 32 bits?

Oui, ASF ne se soucie même pas de télécharger des fichiers de jeu réels. Il fonctionnera donc avec toutes vos licences liées à votre compte Steam, quelles que soient les exigences techniques de la plate-forme. Cela devrait également fonctionner pour les jeux liés à une région spécifique (jeux verrouillés par une région) même si vous n'êtes pas dans la région correspondante, même si nous ne garantissons pas cela (cela a fonctionné la dernière fois que nous avons essayé).

---

## Comparaison avec des outils similaires

---

### ASF est-il similaire à Idle Master?

La seule similitude est le but général des deux programmes, qui est de cultiver des jeux Steam afin de recevoir des jeux de cartes. Tout le reste, y compris la méthode d'agriculture réelle, la structure du programme, la fonctionnalité, la compatibilité, les algorithmes utilisés, en particulier le code source lui-même, est complètement différent et ces deux programmes n'ont rien de commun les uns avec les autres, même la fondation principale - IM est en cours d'exécution . ET Framework, ASF sur .NET (Core). ASF a été créé pour résoudre des problèmes de IM qu'il n'était pas possible de résoudre avec une simple modification de code. C’est pourquoi ASF a été écrit à partir de rien, sans utiliser une seule ligne de code ni une idée générale de la part de IM, car ce code et ces idées étaient totalement erronés. pour commencer. IM et ASF sont comme Windows et Linux - les deux sont des systèmes d'exploitation et peuvent être installés sur votre PC, mais ils ne partagent presque rien les uns avec les autres, mis à part le même objectif.

C'est aussi pourquoi vous ne devriez pas comparer ASS à IM en fonction des attentes de IM. Vous devez traiter ASF et IM comme des programmes entièrement indépendants dotés de leurs propres ensembles exclusifs de fonctionnalités. Certaines d’entre elles se chevauchent en fait et vous pouvez trouver une caractéristique particulière dans les deux, mais très rarement, car ASF remplit son objectif avec une approche totalement différente de celle de IM.

---

### Est t-il nécessaire d’utiliser ASF, si j’utilise actuellement Idle Master et que cela fonctionne bien pour moi?

**Oui**. ASF est beaucoup plus fiable et inclut de nombreuses fonctions intégrées qui sont **cruciales** quelle que soit la façon dont vous fermez, cette IM n'offre tout simplement pas.

ASF has proper logic for **unreleased games** - IM will attempt to farm games that have cards added already, even if they weren't released yet. Bien sûr, il n'est pas possible de cultiver ces jeux avant la date de sortie, donc votre processus agricole sera bloqué. Cela nécessitera soit de l'ajouter à la liste noire, d'attendre sa publication ou de l'ignorer manuellement. Aucune de ces solutions n’est bonne, et toutes requièrent votre attention - ASF ignore automatiquement le farming des jeux non publiés (temporairement), et revient vers eux plus tard quand ils le sont, en évitant complètement le problème et en le traitant efficacement.

ASF dispose également d’une logique appropriée pour les vidéos de la **série**. Il y a beaucoup de vidéos sur Steam qui ont des cartes, mais qui sont annoncées avec une mauvaise `appID` sur la page des badges, comme **[Double Aventure](https://store.steampowered.com/app/402590)** - La messagerie instantanée fermera faussement `appID`, qui ne produira pas de gouttes et le processus est coincé. Encore une fois, vous devrez le mettre sur liste noire ou l'ignorer manuellement, les deux nécessitant votre attention. ASF découvre automatiquement les bons appID `appID` pour le farming qui se traduit par des gouttes de cartes.

En outre, ASF est **beaucoup plus stable et fiable** en ce qui concerne les problèmes de réseau et les problèmes liés à Steam. Il fonctionne la plupart du temps et ne nécessite aucune attention de votre part une fois configuré, alors que IM  pour beaucoup de gens, nécessite des corrections supplémentaires ou ne fonctionne tout simplement pas malgré tout. Cela dépend également entièrement de votre client Steam, ce qui signifie que cela ne peut pas fonctionner lorsque votre client Steam rencontre des problèmes graves. ASF fonctionne correctement tant qu'il peut se connecter au réseau Steam et ne nécessite pas l'exécution du client Steam, ni même son installation.

Voici 3 **points** très importants pourquoi vous devriez envisager d'utiliser ASF, car ils affectent directement tout le monde cultivant des cartes Steam et il n'y a aucun moyen de dire "cela ne me considère pas", depuis que les entretiens de Steam et les bizarreries sont en train de se produire à tout le monde. Il y a une douzaine de raisons supplémentaires de moins en moins importantes que vous pouvez apprendre dans le reste de la FAQ. En bref, **oui**, vous devez utiliser ASF même lorsque vous n’avez besoin d’aucune fonctionnalité ASF supplémentaire par rapport à IM.

En plus de cela, IM est officiellement interrompu et peut se casser complètement à l'avenir, sans que personne ne se soucie de le corriger, compte tenu de l'existence de solutions beaucoup plus puissantes (pas seulement ASF). IM ne fonctionne déjà pas pour beaucoup de gens, et ce nombre ne fait qu'augmenter, pas diminuer. Évitez d’abord d’utiliser des logiciels obsolètes, pas seulement IM, mais également tous les autres programmes obsolètes. No active maintainer means that nobody cares whether it works or not and **nobody is responsible for its functionality**, which is a crucial matter in terms of security. Il suffit qu'il y ait un bogue critique causant des problèmes réels à l'infrastructure de Steam - personne ne les répare, Steam peut émettre une nouvelle vague de bannissement dans laquelle vous serez touché sans même être conscient que ce problème est un problème, comme il est déjà arrivé aux gens qui utilisent, devinez quoi, version obsolète de ASF.

---

### Quelles sont les fonctionnalités intéressantes proposées par ASF et que Idle Master n’a pas?

Cela dépend de ce que vous considérez comme "intéressant" pour vous. Si vous prévoyez d’exploiter plus d’un compte, la réponse est déjà évidente, car ASF vous permet de les exploiter toutes avec une solution supérieure, la sauvegarde des ressources, les tracas et les problèmes de compatibilité. Toutefois, si vous vous posez cette question, il est fort probable que vous ne répondez pas à ce besoin particulier. Évaluons donc les autres avantages applicables à un seul compte utilisé dans ASF.

Avant tout, vous avez des fonctionnalités intégrées mentionnées **[au-dessus de](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** qui sont essentielles pour le farming quel que soit votre objectif final, et très souvent cela suffit déjà pour envisager l'utilisation d'ASF. Mais vous le savez déjà, passons donc à des fonctionnalités plus intéressantes:

- **You can farm offline** (`OnlineStatus` in `Offline` setting). L'agriculture hors ligne vous permet de sauter entièrement votre statut en jeu Steam, qui vous permet de fermer avec ASF tout en affichant "En ligne" sur Steam en même temps, sans que vos amis remarquent même qu'ASF joue à un jeu en votre nom. Cette fonctionnalité est supérieure, car elle vous permet de rester en ligne sur votre client Steam, sans gêner vos amis avec des modifications constantes du jeu, ni les induire en erreur en leur faisant croire que vous jouez à un jeu alors qu'en réalité vous ne le faite pas. Ce seul point justifie l'utilisation d'ASF si vous respectez vos propres amis, mais ce n'est qu'un début. Il est également agréable de noter que cette fonctionnalité n'a rien à voir avec les paramètres de confidentialité de Steam. Si vous lancez le jeu vous-même, vous vous présenterez correctement dans le jeu à vos amis, rendant uniquement la partie ASF invisible et n'affectant en rien votre compte. .

- **You can skip refundable games** (`SkipRefundableGames` in bot's `FarmingPreferences` feature). ASF a une logique intégrée appropriée pour les jeux remboursables et vous pouvez configurer ASF pour ne pas exploiter automatiquement les jeux remboursables. Cela vous permet d’évaluer vous-même si votre jeu nouvellement acheté dans le magasin Steam valait votre argent, sans qu'ASF ne tente de lui retirer des cartes dès que possible. Si vous y jouez plus de 2 heures ou 2 semaines après votre achat, ASF procédera au farming ce jeu car il ne sera plus remboursable. Jusque-là, vous avez le plein contrôle, que vous en appréciez ou non, et vous pouvez facilement vous le faire rembourser si nécessaire, sans avoir à mettre manuellement ce jeu en liste noire ou à ne pas utiliser ASF pendant toute sa durée.

- **You can skip unplayed games** (`SkipUnplayedGames` in bot's `FarmingPreferences` feature). ASF a une logique intégrée appropriée pendant des heures dans les jeux et vous pouvez configurer ASF pour ne pas exploiter automatiquement les jeux non joués. Cela vous permet de contrôler vous-même les jeux que vous jouez et fermez, sans avoir à les mettre en liste noire manuellement toutes ou à sauter entièrement en utilisant ASF.

- **Vous pouvez automatiquement marquer les nouveaux éléments comme étant reçus** (`BotBehaviour` avec la fonctionnalité `DismissInventoryNotifications`). Farmant avec ASF, votre compte recevra de nouvelles cartes en baisse. Vous savez déjà que cela va se produire. Informez donc ASF de cette notification inutile, en veillant à ce que seules les informations importantes attirent votre attention. Bien sûr, seulement si vous le souhaitez.

- **Vous pouvez personnaliser l’ordre de farming préféré avec d'avantage d’options disponibles** (fonctionnalité `FarmingOrders`). Peut-être que vous voulez d'abord cultiver vos jeux nouvellement achetés ? Ou vos plus vieux? Selon le nombre de de cartes? Les niveaux de badge que vous avez déjà créés? Heures jouées? Ordre alphabétique? Selon AppID? Ou peut-être totalement aléatoire? C’est à vous de décider.

- **ASF peut vous aider à compléter vos ensemble** ( `TradingPreferences` avec la fonction `SteamTradeMatcher`). Avec un bricolage un peu plus avancé, vous pouvez convertir votre ASF en un bot utilisateur complet qui acceptera automatiquement les offres **[STM](https://www.steamtradematcher.com)**, vous aidant chaque jour à faire correspondre vos ensembles sans aucune interaction de l'utilisateur. ASF inclut même son propre module ASF 2FA vous permettant d’importer votre authentificateur mobile Steam et de vous permettre d’automatiser entièrement le processus en acceptant également les confirmations. Ou peut-être souhaitez-vous accepter manuellement et laisser ASF uniquement préparer ces transactions pour vous? C’est à vous de décider.

- **ASF peut activer des clés en arrière-plan pour vous** (fonction **[activation de jeux en arrière-plan](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**). Peut-être avez-vous une centaine de clés de divers ensembles que vous êtes trop paresseux pour vous racheter, en passant par plusieurs fenêtres et en acceptant les conditions d'utilisation de Steam encore et encore. Pourquoi ne pas copier-coller votre liste de clés dans ASF et le laisser faire son travail? ASF activera automatiquement toutes ces clés en arrière-plan, vous fournissant ainsi le résultat approprié pour vous informer du résultat de chaque tentative d'activation. De plus, si vous avez des centaines de clés, Steam sera tôt ou tard sûr de limiter les taux, et ASF le sait aussi. Il attend patiemment que la limite de taux disparaisse et reprenne sa position d'origine.

Nous pourrions maintenant continuer avec l'ensemble du **[wiki ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**, en soulignant chaque fonctionnalité du programme, mais nous devons tracer une ligne quelque part. Voilà une liste de fonctionnalités dont vous pouvez bénéficier en tant qu'utilisateur d'ASF. Une seule de celles-ci pourrait facilement être considérée comme une raison majeure pour ne jamais  reveniren arrière, et nous en avons même répertorié **beaucoup **, avec encore plus, vous pouvez en apprendre d'avantage sur le reste de notre wiki. Ah oui, et nous ne sommes même pas entrés dans les détails avec des choses comme l'API ASF vous permettant de script vos propres commandes, ou une gestion géniale des bots, puisque nous voulions le garder simple.

---

### ASF est-il plus rapide que Idle Master?

**Oui**, bien que l'explication soit plutôt compliquée.

À chaque nouveau processus créé et terminé sur votre système, le client Steam envoie automatiquement une requête contenant tous les jeux auxquels vous êtes en train de jouer. Ainsi, le réseau Steam peut calculer le nombre d'heures et  fournir les cartes. Cependant, le réseau Steam compte votre temps joué par intervalles d'une seconde et l'envoi d'une nouvelle requête afin de réinitialiser le statut actuel. En d'autres termes, si vous créiez / supprimiez un nouveau processus toutes les 0,5 seconde, vous n'aurez jamais de carte, car chaque client Steam de 0,5 seconde envoyait une nouvelle requête et le réseau Steam ne comptera jamais même une seconde de temps de jeu. De plus, en raison du fonctionnement du système d’exploitation, il est assez courant de voir de nouveaux processus en train d’être créés / arrêtés sans même que vous ne fassiez rien. Même si vous ne faites rien sur votre PC, de nombreux processus fonctionnent toujours en arrière-plan, ce qui génère / mettre fin à d’autres processus tout le temps. IM est basé sur le client Steam, donc ce mécanisme vous concerne si vous l'utilisez.

ASF n'est pas basé sur le client Steam, il dispose de sa propre implantation. Grâce à cela, ce que ASF est en train de faire ne génère aucun processus, mais envoie en fait une demande réelle au réseau Steam pour que nous commencions à jouer à un jeu. C'est la même demande qui serait envoyée par le client steam, mais comme nous avons le contrôle effectif du client steam d'ASF, nous n'avons pas besoin de générer de nouveaux processus et nous ne sommes pas en train d'imiter le client steam concernant la demande d'envoi à chaque changement de processus. , donc le mécanisme expliqué ci-dessus ne nous affecte pas. Grâce à cela, nous n'interrompons jamais cet intervalle d'une seconde côté Steam, ce qui améliore notre vitesse de culture.

---

### Mais la différence est-elle vraiment perceptible?

Non. Les interruptions qui se produisent avec le client Steam normal et IM ont un effet négligeable sur les obtentions de carte. Ce n'est donc pas une différence notable qui améliorerait la qualité de ASF.

Cependant, **il y a** une différence, et vous pouvez clairement remarquer que, selon l'affluence de votre système d'exploitation, les cartes **tomberont** plus rapidement, de quelques secondes à quelques secondes. minutes, si vous êtes extrêmement malchanceux. Bien que je n’envisage pas d’utiliser ASF uniquement parce qu’il forunis les cartes plus rapidement, ASF et Idle Master étant tous deux affectés par le fonctionnement de Steam Web, ASF interagit plus efficacement avec Steam Web, tandis que Idle Master ne peut pas contrôler le client Steam. (de sorte que ce n’est pas la faute de Idle Master, mais bien du client Steam lui-même).

---

### ASF peut-il exploiter plusieurs jeux à la fois?

**Oui**, même si ASF sait mieux utiliser cette fonctionnalité, en fonction de l’algorithme de farming **[sélectionné](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Taux d'abandon de carte lorsque le farming de plusieurs jeux est proche de zéro, c'est pourquoi ASF utilise le farming de jeux multiples exclusivement pendant des heures afin de dépasser `HoursUntilCardDrops` plus vite, pour des jeux jusqu'à `32` à la fois. C'est aussi la raison pour laquelle vous devriez vous concentrer sur la partie configuration de l'ASF, et laissez les algorithmes décider quel est le meilleur moyen d'atteindre l'objectif - ce que vous pensez être juste, n'est pas nécessairement juste en réalité, l'agriculture de jeux multiples à la fois ne vous fournira pas de gouttes de cartes.

---

### Est-ce que ASF peut parcourir les jeux rapidement?

**Non**, ASF ne prend pas en charge ni encourage l'utilisation de **[gliches Steam](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance#steam-glitches)**.

---

### ASF peut-il automatiquement jouer à chaque jeu pendant X heures avant l'ajout de cartes?

**Non**, le changement de système de cartes de Steam visait essentiellement à lutter contre de fausses statistiques et des joueurs fantômes. ASF ne contribuera pas à cela plus que nécessaire, l'ajout d'une telle fonctionnalité n'est pas planifié et ne se produira pas. Si votre jeu reçoit des gouttes de cartes de la manière habituelle, ASF les fermera dès que possible.

---

### Puis-je jouer à un jeu pendant qu'ASF est en train de farmer ?

**Non** ASF, unlike some other tools that integrate with your Steam client, has its independent implementation of that client included, and Steam network allows only **one Steam client at a time** to play a game. Vous pouvez cependant déconnecter ASF à tout moment en démarrant une partie (et en cliquant sur "OK" lorsqu'on lui demande si le réseau Steam doit déconnecter un autre client). ASF attendra alors patiemment jusqu'à ce que vous ayez fini de jouer, puis reprendra le processus. Alternativement, vous pouvez toujours jouer en mode hors connexion à tout moment, si cela vous convient.

Gardez à l'esprit que la vitesse d'apparition des cartes lorsque vous jouez à plusieurs parties est proche de zéro de toute façon, donc il n'y a aucun avantage direct à pouvoir le faire avec d'autres outils, alors qu'il ya de grands avantages de ne pas interférer avec d'autres jeux lancés avec ASF, ce qui est crucial e. . - Sens du VAC.

---

## Sécurité / Vie Privée / VAC / Bans / ToS

---

### Puis-je obtenir une interdiction VAC en utilsant ASF ?

Non, ce n'est pas possible car ASF (contrairement à d'autres outils, tels que Idle Master, SGI ou SAM) n'interfère en aucune manière avec le client Steam ni avec ses processus. Il est physiquement impossible d’obtenir une interdiction VAC pour utiliser ASF, même lorsque vous jouez sur des serveurs sécurisés lorsque ASF est en cours d’exécution, car **ASF ne nécessite même pas l’installation de Steam Client** pour fonctionner correctement. ASF est l’un des rares programmes d’agriculture qui peut actuellement garantir l’absence de VAC.

---

### Est-ce que l’utilisation d’ASF peut m’empêcher de jouer sur des serveurs sécurisés par VAC, comme indiqué **[ici](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**?

ASF ne nécessite pas l'exécution du client Steam, ni même son installation. Selon ce concept, **cela** ne devrait pas causer de problèmes liés à VAC, car ASF garantit l'absence d'interférences avec le client Steam et tous ses processus. C'est le point principal en parlant de la garantie sans ban VAC qu'ASF offre.

Selon les utilisateurs et autant que je sache, c'est le cas à l'heure actuelle, car personne n'a signalé de problème comme indiqué dans le lien ci-dessus lors de l'utilisation de ASF. Nous ne pouvions pas reproduire le problème ci-dessus avec ASF, tout en le reproduisant clairement avec Idle Master.

Cependant, gardez à l'esprit que Valve pourrait toujours ajouter ASF à la liste noire à un certain moment, mais c'est une absurdité complète comme même s'ils font cela, vous pouvez toujours jouer à des jeux sécurisés par VAC depuis votre PC et utiliser ASF en même temps. . sur votre serveur, donc je suis presque sûr qu'ils savent très bien qu'ASF ne devrait pas être un suspect dans le sens du VAC. et ils ne rendront pas nos vies plus difficiles en mettant ASF sur liste noire sans raison. Néanmoins, dans le pire des cas, vous ne pourrez pas jouer, comme indiqué ci-dessus, car la garantie ASF sans ban VAC est toujours présente, que la liste noire  de ASF soit binaire ou non (et que vous puissiez toujours lancer ASF sur toute autre machine sans Steam client en cours d'installation). À l'heure actuelle, il n'est pas nécessaire de faire quoi que ce soit et espérons que cela reste comme ça.

---

### Est-ce sûr ?

Si vous vous demandez si ASF est un logiciel sûr, cela signifie qu'il ne causera aucun dommage à votre ordinateur, ne volera pas vos données personnelles, n'installera pas de virus ou autre chose du genre - c'est sûr. ASF est exempt de logiciels malveillants, le vol de données, les mineurs de cryptomonnaies et tous les autres comportements douteux qui peuvent être considérés comme malveillants ou indésirables par l'utilisateur. En plus de cela, nous avons une section dédiée à la communication à distance **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** qui couvre notre politique de confidentialité et le comportement d'ASF qui va au-delà de ce que vous avez configuré pour que le programme se fasse.

Le code est open-source et les fichiers binaires distribués sont toujours compilés à partir de **[sources accessibles au public](https://en.wikipedia.org/wiki/Open-source_software)** par **[systèmes d'intégration continue automatisés et sécurisés](https://en.wikipedia.org/wiki/Build_automation)**, et même par les développeurs eux-mêmes. Chaque génération est reproductible en suivant notre script de génération et donnera exactement le même code **[deterministic](https://en.wikipedia.org/wiki/Deterministic_system)** IL (binaire). Si, pour une raison quelconque, vous ne faites pas confiance à nos versions, vous pouvez toujours compiler et utiliser ASF depuis la source, y compris toutes les bibliothèques utilisées par ASF (telles que SteamKit2), qui sont également à code source ouvert.

En fin de compte, cependant, c'est toujours une question de confiance pour le(s) développeur(s) de votre application, donc vous devriez décider vous-même si vous considérez ASF comme sûr ou non, pouvant soutenir votre décision avec des arguments techniques spécifiés ci-dessus. Ne croyez pas aveuglément quelque chose seulement parce que nous l'avons dit - vérifiez vous-même, car c'est la seule façon de vous assurer.

---

### Puis-je être banni pour cela?

Pour répondre à cette question, examinons de plus près **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Steam n’interdit pas l’utilisation de plusieurs comptes. En fait, **[elle le permet](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)**, ce qui implique que vous pouvez utiliser le même authentificateur de mobile sur plusieurs comptes. Cependant, cela ne permet pas de partager des comptes avec d'autres personnes, mais nous ne le faisons pas ici.

Le seul véritable point qui tient compte d’ASF est le suivant :
> Vous n'êtes pas autorisé à utiliser des astuces, des logiciels d'automatisation (bots), des mods, des hacks ou tout autre logiciel tiers non autorisé pour modifier ou automatiser un processus du marché des abonnements.

La question est de savoir en quoi consiste le processus du marché des abonnements. Comme on peut le lire:

> Un exemple de marché d'abonnement est le marché communautaire Steam

Nous ne modifions ni n'automatisons pas le processus du marché des abonnements si, par marché des abonnements, nous comprenons le marché communautaire de Steam ou le magasin Steam. Toutefois...

> Valve peut annuler votre compte ou tout abonnement particulier à tout moment dans le cas où (a) Valve cesserait de fournir ces abonnements à des abonnés se trouvant dans la même situation, ou (b) vous enfreignez l'une des conditions du présent contrat (y compris les conditions d'abonnement ou les conditions d'utilisation et Règles d'utilisation).

Par conséquent, comme avec tous les logiciels Steam, ASF n’est pas autorisé par Valve et je ne peux pas garantir que vous ne serez pas suspendu si Valve décidait soudainement qu’ils interdisaient désormais les comptes utilisant ASF. Ceci est extrêmement improbable, compte tenu du fait qu'ASF est utilisé sur plus de quelques millions de comptes Steam, depuis sa première publication qui s'est produite il y a plus de 10 ans - mais toujours une possibilité, indépendamment de la probabilité réelle.

Spécialement parce que:
> En ce qui concerne tous les abonnements, contenus et services qui ne sont pas rédigés par Valve, Valve ne surveille pas ce contenu tiers disponible sur Steam ou via d'autres sources. Valve n'assume aucune responsabilité pour ce contenu tiers. Certains logiciels d'application tiers peuvent être utilisés par les entreprises à des fins commerciales - cependant, vous ne pouvez acquérir de tels logiciels que via Steam pour un usage personnel privé.

Cependant, Valve reconnaît clairement que "Steam idlers" existe, comme indiqué **[ici](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**, donc si vous me le demandez, Je suis presque sûr que s'ils n'étaient pas bien avec eux, ils feraient déjà quelque chose au lieu de faire remarquer qu'ils pourraient causer des problèmes au niveau de la VAC. Le mot clé ici est **utilisateurs de Steam**, par exemple  de ASF, et non **utilisateurs de jeu**.

Veuillez noter que ce qui précède n'est que notre interprétation de **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** et de divers points - ASF est licencié sous Apache 2. Licence, qui dit clairement :

```
Sauf si requis par la loi applicable ou accepté par écrit, le logiciel
distribué sous la Licence est distribué sur une BASE « TEL QUEL »,
SANS GARANTIE OU CONDITIONS D'AUCUNE SORTE, explicite ou implicite.
```

Vous utilisez ce logiciel à vos risques et périls. Il est extrêmement peu probable que vous puissiez être banni pour cela, mais si vous le faites, vous ne pouvez vous en blâmer que vous-même.

---

### Quelqu'un a-t-il été banni pour cela ?

**Oui**, nous avons eu au moins quelques incidents jusqu'à présent qui ont entraîné une sorte de suspension Steam. Que ASF en soit ou non la cause fondamentale est une tout autre histoire que nous ne connaîtrons probablement jamais.

Le premier cas impliquait un gars avec plus de 1000+ bots faisant l'objet d'un bannissement (ainsi que tous les bots), plus que probablement en raison d'une utilisation excessive de `récupère ASF` exécuté sur tous les bots en même temps, ou tout autre montant de transactions douteuses en très peu de temps.

> Bonjour XXX, Merci d'avoir contacté le support Steam. Il semble que ce compte ait été utilisé pour gérer un réseau de comptes bot. L'utilisation de bots est une violation du contrat Steam.

S'il vous plaît, faites preuve de bon sens et ne présumez pas que vous pouvez faire de telles choses folles uniquement parce qu'ASF vous permet de le faire. Faire `loot ASF` sur plus de 1 000 bots peut facilement être considéré comme une attaque **[DDoS](https://en.wikipedia.org/wiki/DDoS)**, et personnellement, je ne suis pas choqué que quelqu'un ait été banni pour une telle chose. Keep minimum of fair use in regards to Steam service, and **most likely** you'll be fine.

Le deuxième cas impliquait un gars avec plus de 170 robots interdits lors de la vente d'hiver 2017 de Steam.

> Votre compte a été bloqué pour violation de l'accord de l'utilisateur Steam. À en juger par les échanges et d’autres facteurs, ce compte a été utilisé pour collecter illégalement des cartes à collectionner sur Steam, ainsi que des activités connexes et non seulement commerciales. Le compte a été bloqué de manière permanente et le support Steam ne peut pas fournir de support supplémentaire sur ce problème.

Cette affaire est encore une fois très difficile à analyser, en raison de la réponse du support de Steam qui offre à peine des détails. D'après mes réflexions personnelles, cet utilisateur a probablement échangé des cartes Steam contre une sorte d'argent (mise à niveau?) Ou d'une autre manière tenté de retirer de l'argent de Steam. Au cas où vous n'étiez pas au courant, c'est également illégal selon **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Nous ne sommes pas en mesure de vous dire ce que vous pouvez faire avec les cartes de trading obtenues via ASF - mais l'utilisateur en question ne s'est pas contenté de fabriquer des badges avec eux.

Le troisième cas concernait un utilisateur avec plus de 120 robots bannis pour violation de **[Steam conduisent](https://store.steampowered.com/online_conduct?l=english)**.

> Bonjour XXX, Merci d'avoir contacté le support Steam. Ce compte et d'autres ont été utilisés pour flooder notre infrastructure réseau, ce qui constitue une violation de la conduite à tenir en ligne de Steam. Le compte a été bloqué de manière permanente et le support Steam ne peut pas fournir de support supplémentaire sur ce problème.

Cette affaire est un peu plus facile à analyser en raison des détails supplémentaires fournis par l'utilisateur. Apparemment, l’utilisateur utilisait **une version ASF très obsolète** qui incluait un bug obligeant ASF à envoyer un nombre excessif de demandes aux serveurs Steam. Le bug lui-même n’existait pas au début, mais a été activé en raison de la modification radicale de Steam qui a été corrigée dans une version ultérieure. **ASF is supported only in [latest stable version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) released on GitHub**.

Vous ne pouvez pas supposer qu'une version obsolète d'ASF fonctionnera de la même manière que celle utilisée pour toujours, surtout parce que Steam change constamment que vous l'aimiez ou non. Si une telle chose se produit dans le monde entier, elle est rapidement corrigée et distribuée à tous les utilisateurs en tant que correction de bogue. Valve ne bannira pas soudainement plus d'un million d'utilisateurs ASF à cause de notre erreur ou de leur erreur, pour des raisons évidentes. Toutefois, si vous renoncez délibérément à utiliser une version ASF à jour, vous êtes par définition une très petite minorité d'utilisateurs **exposés à des incidents comme ceux-ci** en raison de **pas de prise en charge**, personne ne surveille votre version obsolète d'ASF, personne ne la répare et personne ne s'assure que vous ne serez pas totalement banni du simple fait de le lancer. **Veuillez utiliser un logiciel à jour**, pas seulement ASF, mais également toutes les autres applications.

Le cas le plus récent s'est produit vers juin 2021, selon l'utilisateur :

> En utilisant votre programme, je fais des forfaits de booster avec 28 comptes depuis 3 ans et 128 comptes depuis 6 mois. J'étais en ligne avec 15 comptes maximum simultanément pour faire des boosters et les envoyer sur le compte principal. Le mois dernier, j'ai augmenté le nombre de comptes en ligne simultanément à 20 et une semaine après cela, tous mes comptes ont été interdits. Ce courriel n'est pas à vous blâmer, au contraire, j'ai toujours été conscient des conséquences. Je voulais que vous sachiez quels types de comportements entraînent une interdiction permanente.

Il est difficile de dire si l'augmentation des comptes simultanés en ligne est la raison directe du bannissement, Je ne compterais pas sur cela, au lieu de cela, je crois que le nombre de comptes à lui seul était le principal coupable, la concurrence accrue des comptes en ligne vient probablement juste d'attirer l'attention sur l'utilisateur en question, car il avait clairement beaucoup plus de robots que notre recommandation.

---

Tous les incidents ci-dessus ont une chose en commun: ASF n’est qu’un outil et **votre décision** de décider de l’utilisation qui en est faite. Vous n'êtes pas banni pour utiliser ASF directement, mais pour **comment** vous l'utilisez. Il peut s'agir d'une agriculture d'outil d'aide à un seul compte, ou d'un réseau agricole massif à partir de milliers de bots. Quoi qu'il en soit, je ne propose pas de conseils juridiques, et vous devriez vous décider vous-même de votre utilisation d'ASF. Je ne cache aucune information qui pourrait vous aider, par ex. le fait qu'ASF ait été banni (et dans quel contexte), Comme je n'ai aucune raison de le faire, c'est à vous de choisir ce que vous voulez faire avec cette information.

If you ask me - use some common sense, avoid owning more bots than our recommendation, do not send hundreds of trades at the same time, always use up-to-date ASF version and you _should_ be fine. Chaque incident de cette nature pour **une raison** est arrivé à des personnes qui ont ignoré nos recommandations, les meilleures pratiques et les suggestions, croyant qu'ils savent mieux que nous. . Combien de bots ils peuvent courir. Que ce soit juste une coïncidence ou un facteur réel, c'est à vous de décider. Nous n'offrons pas de conseils juridiques, nous vous donnons seulement nos pensées que vous pouvez trouver utiles, ou les ignorer entièrement et n'opérer que sur les faits liés ci-dessus.

---

### Quelles sont les informations de confidentialité divulguées par ASF?

Vous pouvez trouver une explication détaillée dans la section **[communication distante](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. Vous devriez l'examiner si vous tenez à votre vie privée, par exemple. si vous vous demandez pourquoi les comptes utilisés dans ASF rejoignent notre groupe Steam. ASF ne collecte aucune information sensible et ne le partage avec aucun tiers.

---

## Divers

---

### J'utilise un système d'exploitation non pris en charge tel que Windows 32 bits. Puis-je quand même utiliser la dernière version d'ASF ?

Oui, et cette version n’est en aucun cas prise en charge, mais n’est pas officiellement construite. Consultez la section Compatibilité **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** pour la variante générique. ASF n'a aucune dépendance forte à l'égard du système d'exploitation, et il peut fonctionner n'importe où où vous pouvez faire travailler . ET runtime, qui inclut Windows 32 bits, même s'il n'y a pas de package `win-x86` spécifique à notre système d'exploitation.

---

### C'est super ! Puis-je faire un don?

Oui, et nous sommes ravis d'apprendre que vous appréciez notre projet! Vous pouvez trouver diverses possibilités de don sous chaque **[libère](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** et **[sur la page principale](https://github.com/JustArchiNET/ArchiSteamFarm)**. Il est agréable de noter qu'en plus des dons d'argent génériques, nous acceptons également les objets Steam, donc rien ne vous empêche de faire un don de skins, de clés ou d'une petite partie des cartes que vous avez cultivées avec ASF si vous le souhaitez. Je vous remercie pour votre générosité!

---

### J'utilise le code PIN parental de Steam pour protéger mon compte. Dois-je le saisir quelque part?

Oui, vous devez le définir dans la fonctionnalité de configuration du bot `SteamParentalCode`. En effet, ASF accède à de nombreuses parties protégées de votre compte Steam et il est impossible pour ASF de fonctionner sans ce dernier.

---

### Je ne veux pas qu'ASF  farm des jeux par défaut, mais je veux utiliser des fonctionnalités supplémentaires d'ASF. Est-ce possible?

Oui, si vous voulez juste démarrer ASF avec le module de farming des cartes en pause, vous pouvez définir la propriété de configuration de `FarmingPausedByDefault` dans `FarmingPreferences` bot pour atteindre cela. This will allow you to `resume` it during runtime.

Si vous voulez désactiver complètement le module de farming des cartes et vous assurer qu'il ne fonctionnera jamais sans que vous ne l'indiquiez explicitement autrement, alors nous vous recommandons de définir `FarmPriorityQueueOnly` dans les `FarmingPreferences`, qui, au lieu de simplement l'interdire, désactivera complètement le farming jusqu'à ce que vous ajoutiez les jeux à la file d'attente de priorité inactive vous-même.

Avec le module de farming des cartes mis en pause/désactivé, vous pouvez utiliser des fonctionnalités ASF supplémentaires, telles que `GamesPlayedWhileIdle`.

---

### ASF peut-il se réduire au minimum?

ASF est une application console, il n'y a pas de fenêtre à minimiser, car celle-ci est créée pour vous par votre système d'exploitation. Vous pouvez cependant utiliser n'importe quel outil tiers capable de le faire, comme **[RBTray](https://github.com/benbuck/rbtray)** pour Windows, ou **[écran](https://linux.die.net/man/1/screen)** pour Linux/macOS. Ce ne sont que des exemples, il y a beaucoup d'autres applications avec des fonctionnalités similaires.

---

### Est-ce que le fait d’utiliser ASF préserve l’éligibilité pour recevoir des boosters?

**Yes**. ASF utilise la même méthode pour se connecter au réseau Steam que le client officiel, par conséquent, il préserve également la possibilité de recevoir des packs de booster pour les comptes qui sont utilisés dans ASF. De plus, préserver cette capacité ne nécessite même pas de se connecter à la communauté Steam, pour que vous puissiez utiliser en toute sécurité `OnlineStatus` dans les paramètres `Offline` si vous le souhaitez.

---

### Y a-t-il un moyen de communiquer avec ASF?

Oui, par plusieurs moyens. Consultez la section **[commandes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** pour plus d'informations.

---

### J'aimerais aider à la traduction d'ASF, que dois-je faire?

Merci de votre intérêt! Vous trouverez tous les détails dans notre section **[localisation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)**.

---

### Un seul compte (principal) a été ajouté à ASF. Puis-je quand même émettre des commandes via le chat Steam?

**Oui**, c'est expliqué dans la section **[commandes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#notes)**. Vous pouvez le faire via le chat de groupe Steam, bien que l'utilisation de **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** pourrait être plus facile pour vous.

---

### ASF semble fonctionner, mais je ne reçois aucune carte!

Le taux de farming des cartes diffère d'un jeu à l'autre, comme vous pouvez le lire en **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Cela prend un certain temps, généralement **plusieurs heures par jeux**, et vous ne devez pas vous attendre à ce que les cartes tombent quelques minutes après le lancement du programme. Si vous pouvez voir qu’ASF vérifie activement le statut des cartes et change le jeu après que la carte actuelle soit entièrement exploitée, alors tout fonctionne correctement. Il est possible que vous ayez activé une option telle que `DismissInventoryNotifications` de `BotBehaviour` qui rejette automatiquement les notifications d'inventaire. Consultez la configuration **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** pour plus de détails.

---

### Comment arrêter complètement le processus ASF pour mon compte?

Arrêtez simplement le processus ASF, par exemple en cliquant sur [X] sur la fenêtre du programme. Si au lieu de cela, vous voulez arrêter un bot particulier de votre choix mais garder les autres en cours d'exécution, alors jetez un coup d'œil à `Activé` **[propriété de configuration du bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**, ou `arrêter` **[commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Si vous voulez plutôt arrêter le processus de farming automatique, tout en gardant ASF en cours d'exécution pour votre compte, alors c'est à `FarmingPausedByDefault` option de `FarmingPreferences` dans **[propriété de configuration de bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** et `pause` **[commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** est pour.

---

### Combien de bots puis-je utiliser avec ASF?

ASF en tant que programme n'a pas de limite maximale d'instances de bot, pour que vous puissiez exécuter autant que vous avez de la mémoire sur votre machine, cependant, vous êtes toujours limité par le réseau Steam et d'autres services Steam. Actuellement, vous pouvez exécuter jusqu'à 100-200 bots avec une seule adresse IP et une seule instance ASF. Il est possible d'exécuter plus de bots avec plus d'adresses IP et plus d'instances ASF, en contournant les limitations IP. Gardez à l'esprit que si vous utilisez ce grand nombre de bots, vous devriez contrôler leur nombre vous-même, comme s'assurer que tous sont en fait en train de se connecter et travailler en même temps. ASF n'a pas été modifié pour cet énorme nombre de bots, et la règle générale applique que **plus de bots vous avez, plus de problèmes vous rencontrerez de**. Notez également que la limite ci-dessus dépend en général de nombreux facteurs internes, c'est approximatif plutôt qu'une limite stricte - vous serez probablement en mesure d'exécuter plus ou moins de bots que ce qui est spécifié ci-dessus.

ASF team suggests **owning** up to **10 Steam accounts in total**, and therefore also running up to **10 bots in total**. Tout ce qui précède n'est pas soutenu et fait à vos propres risques, contre notre suggestion faite ici. Cette recommandation est basée sur des lignes directrices internes de Valve ainsi que sur nos propres suggestions. Que vous alliez ou non respecter cette règle est votre choix, ASF en tant qu'outil ne va pas à l'encontre de votre propre volonté, même si cela entraînera la suspension de vos comptes Steam. Par conséquent, ASF vous affichera un avertissement si vous allez au-delà de ce que nous recommandons, mais vous permettez quand même d'exécuter tout ce que vous voulez à vos propres risques et à notre manque de soutien.

---

### Puis-je exécuter plus d'instances ASF alors?

Vous pouvez exécuter autant d'instances ASF que vous le souhaitez sur une machine, en supposant que chaque instance a son propre répertoire et ses propres configurations, et qu'un compte utilisé dans une instance n'est pas utilisé dans une autre. Cependant, demandez-vous pourquoi vous voulez faire cela. ASF est optimisé pour gérer plus d'une centaine de comptes en même temps, et le lancement de cette centaine de bots dans leurs propres instances ASF dégrade les performances, prend plus de ressources du système d'exploitation (comme le CPU et la mémoire), et provoque des problèmes de synchronisation potentiels entre les instances ASF autonomes, car ASF est forcé de partager ses limiteurs avec d'autres instances.

Par conséquent, ma **suggestion forte** consiste à toujours exécuter au maximum une instance ASF par adresse IP / interface. Si vous avez plus d'IPs/interfaces, par tous les moyens, vous pouvez exécuter plus d'instances ASF, avec chaque instance en utilisant sa propre IP/interface ou un paramètre unique `WebProxy`. Si vous ne le faites pas, lancer plus d'instances ASF est totalement inutile, car vous ne gagnerez rien en lançant plus d'une instance par IP/interface unique. Steam ne vous permettra pas par magie de lancer plus de robots simplement parce que vous les avez lancés dans une autre instance ASF, et ASF ne vous limite pas à commencer.

Bien sûr, il existe encore des cas d'utilisation valides pour plusieurs instances ASF sur la même interface réseau, comme l'hébergement du service ASF pour vos amis avec chaque ami ayant sa propre instance ASF unique afin de garantir l'isolement entre les bots et même les processus ASF eux-mêmes, cependant, vous ne contournez pas les limitations de Steam de cette façon, c'est un but tout à fait différent.

---

### Quel est la signification du statut lors de l'utilisation d'une clé?

Le statut indique comment la tentative d'activation a été effectué. Il existe de nombreux statuts différents. Les plus courants incluent:

| Statut                  | Description                                                                                                                                                                                                                               |
| ----------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| NoDetail                | Etat "OK" indiquant le succès - la clé a été utilisée avec succès.                                                                                                                                                                        |
| Timeout                 | Le réseau Steam n'a pas répondu dans le délai imparti, nous ne savons pas si la clé a été utilisée, ou pas (probablement, mais vous pouvez réessayer).                                                                                    |
| BadActivationCode       | La clé fournie n'est pas valide (n'est reconnue comme aucune clé valide par le réseau Steam).                                                                                                                                             |
| DuplicateActivationCode | La clé fournie a déjà été utilisée par un autre compte ou révoquée par le développeur/éditeur.                                                                                                                                            |
| AlreadyPurchased        | Votre compte possède déjà `packageID` connecté à cette clé. Gardez à l'esprit que cela n'indique pas si la clé est `DuplicateActivationCode ` ou pas - seulement qu'elle est valide et qu'elle n'a pas été utilisée dans cette tentative. |
| RestrictedCountry       | Cette clé est verrouillée par région et votre compte n'est pas dans la région valide qui est autorisée.                                                                                                                                   |
| DoesNotOwnRequiredApp   | Vous ne pouvez pas échanger cette clé car il vous manque une autre application, principalement un jeu de base, lorsque vous essayez d'utiliser un package DLC.                                                                            |
| RateLimited             | Vous avez effectué trop de tentatives et votre compte a été temporairement bloqué. Réessayez dans une heure.                                                                                                                              |

---

### Êtes-vous affilié à un service cards farming/idling service?

**No**. ASF n'est affiliée à aucun service et toutes ces réclamations sont fausses. Votre compte Steam est votre propriété et vous pouvez utiliser votre compte comme vous le souhaitez, mais Valve a clairement indiqué dans **[les ToS](https://store.steampowered.com/subscriber_agreement)** que :

> Vous êtes responsable de la confidentialité de votre identifiant et de votre mot de passe, ainsi que de la sécurité de votre système informatique. Valve n'est pas responsable de l'utilisation de votre mot de passe et de votre compte ou de toute la communication et l'activité sur Steam qui résultent de l'utilisation de votre nom d'utilisateur et de votre mot de passe par vous, ou par toute personne à qui vous pourriez avoir volontairement ou par négligence divulgué votre identifiant et/ou votre mot de passe en violation de cette disposition de confidentialité.

ASF est sous licence Apache 2.0, une licence libérale qui permet aux autres développeurs d’intégrer  ASF dans leurs propres projets et services de manière légale. Cependant, ces projets tiers utilisant ASF ne sont pas garantis d'être sécurisés, revus, appropriés ou légaux selon **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Si vous souhaitez connaître notre opinion, **nous vous encourageons vivement à ne PAS partager les informations de votre compte avec des services tiers**. Si un tel service s'avère être une **arnaque typique**, le problème vous échappera, sans le compte Steam et le plus souvent, ASF n'assumera aucune responsabilité pour les services tiers prétendant être sûr et sécurisé, car l'équipe d'ASF n'a pas autorisé ni examiné aucun de ceux-ci. En d'autres termes, **vous les utilisez à vos risques et périls, contrairement à notre suggestion ci-dessus**.

In addition to that, official **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** clearly states that:

> Vous n'êtes pas autorisé à révéler, partager ou autoriser des tiers à utiliser votre mot de passe ou votre compte, sauf autorisation exceptionnelle de Valve.

C'est votre compte et votre choix. Juste ne dites pas que personne ne vous a prévenu. ASF en tant que programme respecte toutes les règles mentionnées ci-dessus, car vous ne partagez pas les informations de votre compte avec qui que ce soit, et vous utilisez le programme pour votre usage personnel, mais tout autre "service de gestion de cartes" requiert vos identifiants de compte. , donc il viole également la règle ci-dessus (en fait plusieurs d'entre eux). J'aime avec l'évaluation **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** , nous n'offrons aucun conseil juridique, et vous devriez décider vous-même si vous souhaitez utiliser ces services, ou non - selon nous **cela viole directement [Steam ToS](https://store.steampowered.com/subscriber_agreement)** et peut entraîner une suspension si Valve le découvre. Comme indiqué ci-dessus, **nous vous recommandons vivement de NE PAS utiliser ces services**.

---

## Problèmes

---

### Un de mes jeux est en cours d'élevage depuis plus de 10 heures maintenant, mais je n'ai toujours pas reçu de cartes!

La raison de cela pourrait être liée à un problème connu de Steam, qui se produit lorsque vous avez deux licences pour le même jeu, dont l'une a des drops de cartes limitées. Cela se produit généralement lorsque vous activez le jeu gratuitement pendant un don de masse sur Steam, puis activez une clé pour le même jeu (mais sans limitations), e. . - à partir d’un lot payant. Si une telle situation se produit, Steam signale sur la page de badge que le jeu a toujours des cartes à lâcher, mais peu importe le montant que vous jouez au jeu - les cartes ne tomberont jamais en raison d'une licence gratuite sur votre compte. Puisqu'il ne s'agit pas d'un problème ASF, mais d'un problème Steam, nous ne pouvons pas le contourner du côté d'ASF, et vous devez le résoudre vous-même.

Il y a deux façons de résoudre le problème. Tout d'abord, vous pouvez mettre en liste noire ce jeu en ASF, soit avec `fbadd` **[commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** ou avec `Liste noire` **[propriété de configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Cela empêchera ASF d'essayer de fermer des cartes de ce jeu, mais ne résoudra pas le problème sous-jacent qui vous empêche d'obtenir des cartes dans le jeu affecté. Deuxièmement, vous pouvez utiliser le support de Steam en libre-service pour supprimer la licence gratuite de votre compte, ne laissant que la licence complète qui inclut les drops de carte. Pour cela, premièrement visitez votre page de licences **[et d'activation de la clé de produit](https://store.steampowered.com/account/licenses)** et localisez la licence gratuite et payante pour le jeu affecté. Habituellement, c'est assez facile - tous deux ont un nom similaire, mais gratuit a "un paquet promotionnel gratuit limité" ou un autre "promo" dans le nom de la licence, plus "complémentaire" dans le champ "méthode d'acquisition". Parfois, cela peut être plus délicat, par exemple si le paquet libre est dans un paquet et a un nom différent. Si vous avez trouvé deux licences comme ça - alors c'est bien le problème décrit ici, et vous pouvez supprimer en toute sécurité la licence gratuite sans perdre le jeu.

Afin de supprimer la licence gratuite de votre compte, visitez la page **[de support Steam](https://help.steampowered.com/wizard/HelpWithGame)** et mettez le nom du jeu affecté dans le champ de recherche, le jeu doit être disponible dans la section "produits", cliquez dessus. Alternativement, vous pouvez juste utiliser `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` lien et remplacer `<appID>` avec appID du jeu qui cause des problèmes. Ensuite, cliquez sur "Je veux supprimer définitivement ce jeu de mon compte" puis sélectionnez la licence sans défaut que vous avez trouvée ci-dessus, généralement celui qui a « un forfait promotionnel gratuit limité » dans le nom (ou similaire). Après la suppression de la licence gratuite, ASF devrait être en mesure de déposer des cartes du jeu affecté sans problème, vous devriez redémarrer l'opération de farming après la suppression, juste pour vous assurer que Steam récupère la bonne licence cette fois.

---

### ASF ne détecte pas le jeu `X` disponible pour le farming, mais je sais qu’il comprend des cartes à échanger Steam!

Il y a deux raisons principales ici. La première et la plus évidente raison est le fait que vous vous référez au **magasin Steam**, dans lequel un jeu donné est annoncé comme un jeu activé pour l'obtention de cartes. Cette hypothèse est **fausse**, car elle indique simplement que le jeu **contient des** des cartes inclus, mais que cette fonction n'est pas nécessairement **activée immédiatement** pour ce jeu.  Vous pouvez en savoir plus à ce sujet dans l'annonce officielle **[](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**.

En bref, l'icône de dépôt de cartes dans le magasin Steam ne veut rien dire, vérifiez vos pages de badge **[](https://steamcommunity.com/my/badges)** pour obtenir une confirmation si un jeu a des cartes activées ou non - c'est aussi ce qu'ASF fait. Si votre jeu n'apparaît pas dans la liste comme un jeu avec des cartes possibles, alors ce jeu est **pas** possible à fermer, quelle que soit la raison.

La deuxième question est moins évidente, et c'est la situation où vous pouvez voir que votre jeu est en effet disponible avec des cartes sur votre page de badge, mais ce n'est pas tout de suite un élevage par ASF. À moins que vous ne rencontriez un autre bug, tel qu'ASF ne pouvant pas vérifier les pages de badge (décrit ci-dessous), il s'agit simplement d'un effet de cache et du côté ASF, Steam continue de signaler des page de badges obsolètes. Ce problème devrait se résoudre tôt ou tard, lorsque le cache sera invalidé. Il n'y a également aucun moyen de régler ce problème de notre côté.

Bien sûr, tout cela suppose que vous utilisez ASF avec des paramètres non modifiés par défaut, puisque vous pouvez également ajouter ce jeu à la liste noire de farming utiliser la sélection `FarmingPreferences` comme `FarmPriorityQueueOnly` ou `SkipRefundableGames`, et ainsi de suite.

---

### Pourquoi le temps de jeu des jeux élevés via ASF n'augmente pas?

Oui, mais **pas en temps réel**. Steam enregistre votre temps de lecture à intervalles fixes et planifie sa mise à jour, mais vous n'êtes pas sûr de l'avoir immédiatement mis à jour dès que vous quittez la session, et encore moins pendant une telle heure. Ce n'est pas parce que le temps de jeu n'est pas mis à jour en temps réel qu'il n'est pas enregistré, il est généralement mis à jour toutes les 30 minutes environ.

---

### Quelle est la différence entre un avertissement et une erreur dans le journal?

ASF écrit dans son journal une multitude d'informations sur différents niveaux de journalisation. Notre objectif est d'expliquer **précisément** ce que fait ASF, y compris les problèmes auxquels il doit faire face, ainsi que d'autres problèmes à résoudre. La plupart du temps, tout n’est pas pertinent, c’est la raison pour laquelle nous utilisons deux principaux niveaux dans ASF en termes de problèmes: un niveau d’avertissement et un niveau d’erreur.

La règle générale ASF est que les avertissements ne sont **pas**, ils doivent donc **pas** être signalés. Un avertissement vous indique que quelque chose de potentiellement indésirable se produit. Que ce soit Steam qui ne réagit pas, les erreurs de lancement d'API ou votre connexion réseau en panne - il s'agit d'un avertissement, et cela signifie que nous nous attendions à ce que cela se produise. Ne gênez donc pas le développement d'ASF. Bien sûr, vous êtes libre de poser des questions à leur sujet ou d'obtenir de l'aide en utilisant notre support, mais vous ne devez pas supposer qu'il s'agit d'erreurs ASF qui méritent d'être signalées (sauf confirmation contraire de notre part).

Les erreurs, par contre, indiquent une situation qui ne devrait pas se produire. Elles méritent donc d'être signalées si vous vous assurez que ce n'est pas vous qui les causez. Si nous nous attendons à ce qu'une situation courante se produise, elle sera convertie en un avertissement. Sinon, il s'agit probablement d'un bogue qui devrait être corrigé et non ignoré silencieusement, en supposant que cela ne soit pas le résultat de votre propre problème technique. Par exemple, la suppression du fichier principal `ASF.json` génère une erreur, car ASF ne peut fonctionner sans ce fichier. C’est vous qui l’avez supprimé. Vous ne devez donc pas nous signaler cette erreur (sauf si vous avez confirmé qu'ASF est erroné et que le fichier est là).

Dans une phrase TL;DR - signaler les erreurs, ne signalez pas les avertissements. Vous pouvez toujours poser des questions sur les avertissements et recevoir de l'aide dans nos sections d'assistance.

---

### ASF ne démarre pas, la fenêtre du programme se ferme immédiatement!

Dans des conditions normales, tout plantage ou sortie d'ASF générera un log `. xt` dans le répertoire du programme que vous pouvez consulter, qui peut être utilisé pour trouver la cause de cela. En plus de cela, quelques derniers fichiers journaux sont également archivés dans le répertoire `logs` depuis le journal `principal. Le fichier xt` est écrasé à chaque exécution ASF.

Cependant, si même .NET runtime n'est pas en mesure de démarrer sur votre machine, alors `log.txt` ne sera pas généré. Si cela vous arrive, vous avez probablement oublié d'installer les prérequis .NET, comme indiqué dans le guide **[de configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. D'autres problèmes courants incluent la tentative de lancer une mauvaise variante ASF pour votre OS, ou d'une autre façon les dépendances natives .NET runtime manquantes. Si la fenêtre de la console se ferme trop tôt pour que vous puissiez lire le message, ouvrez une console indépendante et lancez le fichier binaire ASF à partir de cet emplacement. Par exemple sous Windows, ouvrez le répertoire ASF, maintenez `Shift`, Faites un clic droit dans le dossier et choisissez "*ouvrir la fenêtre de commande ici*" (ou *powershell*), puis tapez dans la console `. ArchiSteamFarm.exe` et confirmez avec entrée. De cette façon, vous obtiendrez un message précis indiquant pourquoi ASF ne démarre pas correctement.

S'il n'y a pas de sortie, et que vous êtes sous Windows, la cause habituelle est que toutes les mises à jour de Windows ne sont pas installées - assurez-vous que vous utilisez un système d'exploitation à jour, car nous ne prenons pas en charge l'exécution d'ASF sur Windows sans satisfaire à cette condition dans les deux sens.

---

### ASF lance ma session client Steam pendant que je joue! / *Ce compte est connecté sur un autre PC*

Cela s’affiche sous forme de message dans l’incrustation Steam indiquant que le compte est utilisé ailleurs pendant que vous jouez. Ce problème peut avoir deux raisons différentes.

Une des raisons est due à des paquets cassés (jeux) qui, en particulier, ne tiennent pas un verrou de jeu correctement, mais s'attendent à ce que ce verrou soit possédé par le client. Skyrim SE est un exemple de ce type de paquet. Votre client Steam lance le jeu correctement, mais ce jeu ne s’enregistre pas comme étant utilisé. A cause de cela, ASF voit qu'il est libre de reprendre le processus, ce qui est le cas, et cela vous éloigne du réseau Steam, car Steam détecte soudainement que le compte est utilisé à un autre endroit.

La deuxième raison pourrait apparaître si vous jouez sur votre PC alors qu'ASF attend (en particulier sur une autre machine) et que vous perdez votre connexion réseau. Dans ce cas, le réseau Steam vous marque comme étant hors ligne et libère le verrou de lecture (comme ci-dessus), ce qui déclenche la reprise du farming par ASF (sur une autre machine, par exemple). Lorsque votre ordinateur revient en ligne, Steam ne peut plus acquérir le verrou de lecture (qui est maintenant détenu par ASF, similaire au précédent) et affiche le même message.

Les deux causes du côté d’ASF sont en réalité très difficiles à contourner, car ASF reprend simplement l’agriculture une fois que le réseau Steam l’a informé que le compte était libre d’être utilisé à nouveau. C’est ce qui se passe normalement lorsque vous fermez le jeu, mais avec les paquets cassés, cela peut se produire immédiatement, même si votre jeu est toujours en cours d’exécution. ASF n'a aucun moyen de savoir si vous êtes déconnecté, si vous avez arrêté de jouer ou si vous continuez de jouer à un jeu qui ne tient pas le jeu de manière appropriée.

La seule solution appropriée à ce problème consiste à suspendre manuellement votre bot avec `pause` avant de commencer à jouer et à le reprendre avec `resume` une fois que vous avez terminé. Sinon, vous pouvez simplement ignorer le problème et agir comme si vous jouiez avec un client Steam hors ligne.

---

### `Déconnecté de Steam!` - Je ne parviens pas à établir la connexion avec les serveurs Steam.

ASF peut uniquement **essayer** d’établir une connexion avec des serveurs Steam. Cette défaillance peut échouer pour de nombreuses raisons, notamment l’absence de connexion Internet, la désactivation de Steam, la connexion bloqué par votre pare-feu, des outils tiers et des fichiers configurés de manière incorrecte. ou des échecs temporaires. Vous pouvez activer le mode `Debug` pour extraire un journal plus détaillé exposant les raisons exactes des échecs, bien que cela soit généralement dû à vos propres actions, telles que l'utilisation de "CS: GO MM Server Picker" qui met beaucoup de listes noires dans Steam IP, rendant très difficile l’accès au réseau Steam.

ASF fera de son mieux pour établir la connexion, ce qui implique non seulement de demander une liste de mise à jour des serveurs, mais également d'essayer une autre adresse IP en cas d'échec de la dernière. Par conséquent, s'il s'agit vraiment d'un problème temporaire avec un serveur ou une route spécifique, ASF se connectera tôt ou tard. Cependant, si vous êtes derrière un pare-feu ou si, d’une autre manière, vous ne parvenez pas à atteindre les serveurs Steam, vous devez évidemment le réparer vous-même, avec l’aide éventuelle du mode `Debug`.

Il est également possible que votre machine ne puisse pas établir de connexion avec les serveurs Steam en utilisant le protocole par défaut dans ASF. Vous pouvez modifier les protocoles qu'ASF est autorisé à utiliser en modifiant le fichier de configuration globale `SteamProtocols`. Par exemple, si vous avez des problèmes pour atteindre Steam avec le protocole `UDP` (par ex. à cause des pare-feus), vous aurez peut-être plus de chance avec `TCP` ou `WebSocket`.

Dans une situation très improbable d'avoir des serveurs incorrects en cache, par exemple en raison du déplacement du dossier ASF `config` d'une machine vers une autre machine située dans un pays totalement différent, suppression de `ASF. b` afin d'actualiser les serveurs Steam au prochain lancement peut aider. Très souvent, ce n'est pas nécessaire et ne doit pas être fait, car cette liste est automatiquement actualisée au premier lancement, ainsi que lorsque la connexion est établie - nous la mentionnons simplement comme un moyen de purger tout ce qui concerne la liste des serveurs Steam mis en cache par ASF.

---

### `Impossible de se connecter à Steam: TryAnotherCM/Invalid`, `ServiceUnavailable/Invalid`

Comme indiqué ci-dessus, mais cette fois le serveur avec lequel vous vous êtes connecté est explicitement indisponible. Habituellement se produit pendant la fenêtre de maintenance de Steam, il n'y a rien que vous pouvez faire à ce sujet, ASF réessaiera automatiquement avec un autre serveur jusqu'à ce que l'on accepte sa demande. Elle ne devrait pas durer plus d'une heure maximum.

---

### `Impossible d'obtenir des informations sur les badges, j'essaierai plus tard!`

Généralement, cela signifie que vous utilisez le code PIN parent Steam pour accéder à votre compte, mais vous avez oublié de le mettre dans la configuration ASF. Vous devez mettre un code PIN valide dans la propriété de configuration de bot `SteamParentalCode` Dans le cas contraire, ASF ne pourra pas accéder à la plupart du contenu web, donc ne pourra pas fonctionner correctement. Rendez-vous vers la configuration **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** pour en savoir plus sur `SteamParentalCode`.

D'autres raisons incluent le problème temporaire de Steam, un problème de réseau ou autres. Si le problème ne se résout pas après plusieurs heures et que vous êtes certain d'avoir configuré ASF correctement, n'hésitez pas à nous le faire savoir.

---

### ASF échoue avec la requête `échouée après 5 essais` erreurs!

Généralement, cela signifie que vous utilisez le code PIN parent Steam pour accéder à votre compte, mais vous avez oublié de le mettre dans la configuration ASF. Vous devez mettre un code PIN valide dans la propriété de configuration de bot `SteamParentalCode` Dans le cas contraire, ASF ne pourra pas accéder à la plupart du contenu web, donc ne pourra pas fonctionner correctement. Rendez-vous vers la configuration **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** pour en savoir plus sur `SteamParentalCode`.

Si le code PIN du parent n'est pas la raison, alors c'est une erreur la plus fréquente, et vous devriez vous y habituer, cela signifie simplement qu'ASF a envoyé une demande à Steam Network et n'a pas obtenu de réponse valide, 5 fois de suite. Cela signifie généralement que Steam est en panne, ou en maintenance. ASF en est conscient et vous ne devez pas vous en inquiéter, à moins que cela ne se produise plusieurs heures à la fois et que les autres utilisateurs ne rencontrent pas de tels problèmes.

Comment vérifier si Steam est en panne? **[Steam Status](https://steamstat.us)** is an excellent source of checking if Steam **should be** up, if you notice errors, especially related to Community or Web API, then Steam is having difficulties. Vous voudrez peut-être laisser ASF seul et le laisser faire son travail après un court laps de temps d’arrêt, ou quittez et attendez vous-même.

Ce n'est cependant pas toujours le cas, car dans certaines situations, les problèmes Steam peuvent ne pas être détectés par le statut Steam, par exemple, ce cas s'est produit lorsque Valve a cassé le support HTTPS pour la communauté Steam le 7 juin 2016 - l'accès à **[SteamCommunity](https://steamcommunity.com)** via HTTPS a lancé une erreur. Par conséquent, ne faites pas aveuglément confiance à Steam Status, il est préférable de vérifier vous-même si tout fonctionne comme prévu.

En plus de cela, Steam inclut diverses mesures de limitation de taux qui banniront temporairement votre IP si vous faites un nombre excessif de requêtes à la fois. ASF en est conscient et vous propose plusieurs limiteurs différents dans la configuration, que vous devriez utiliser. Les paramètres par défaut ont été ajustés en fonction du nombre de bots **sane** , si vous utilisez une quantité tellement énorme que même Steam vous dit de partir, alors vous les modifiez jusqu'à ce que cela ne vous le dise plus, ou vous faites comme on vous le dit. Je suppose que la deuxième voie n'est pas une option pour vous, allez donc lire sur ce sujet et prêtez une attention particulière à `WebLimiterDelay` qui est un limiteur général qui s'applique à toutes les requêtes web.

Il n'y a pas de "règle d'or" qui fonctionne pour tout le monde, parce que les blocs sont fortement influencés par des facteurs tiers, c'est pourquoi vous devez vous expérimenter et trouver une valeur qui fonctionne pour vous. Vous pouvez également ignorer ce que je dis et utiliser quelque chose comme `10000` qui fonctionne correctement, mais ne vous plaignez pas alors comment ASF réagit à tout en 10 secondes et comment l'analyse des badges prend 5 minutes. En plus de cela, Il est tout à fait possible qu'aucun limiteur ne fasse quoi que ce soit parce que vous avez tellement de bots que vous atteignez la limite dure **[](#how-many-bots-can-i-run-with-asf)** qui a été mentionnée ci-dessus. Oui, il est tout à fait possible que vous puissiez vous connecter sans problème sur le réseau Steam (client), mais Steam web (site web) refusera de vous écouter si vous avez 100 sessions établies à la fois. ASF exige que le réseau Steam et le Web Steam soient coopératifs, il ne faut qu'un seul élément pour vous permettre de résoudre des problèmes dont vous ne récupérerez pas.

Si rien n'aide et que vous n'avez aucune idée de ce qui est cassé, vous pouvez toujours activer le mode `Debug` et voir dans le journal ASF pourquoi exactement les requêtes échouent. Par exemple :

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() <- HEAD https://steamcommunity.com/my/edit/settings
```

Voir ce code `interdit`? Cela signifie que vous avez été temporairement banni pour un nombre excessif de requêtes, parce que vous n'avez pas encore modifié `WebLimiterDelay` correctement (en supposant que vous obtenez le même code d'erreur pour toutes les autres requêtes). Il peut y avoir d'autres raisons listées là-bas, telles que `InternalServerError`, `ServiceUnavailable` et des timeouts qui indiquent la maintenance/les problèmes de Steam . Vous pouvez toujours essayer de visiter vous-même le lien mentionné par ASF et vérifier si cela fonctionne. Sinon, vous saurez pourquoi ASF ne peut pas y accéder. Si c'est le cas, et que la même erreur ne disparaît pas après un jour ou deux, il peut être utile d'enquêter et de signaler.

Avant de le faire, vous devez **vous assurer que l’erreur vaut la peine d’être signalée**. Si cela est mentionné dans cette FAQ, comme un problème lié au trading, alors c'est fini. S'il s'agit d'un problème temporaire qui s'est produit une ou deux fois, en particulier lorsque votre réseau était instable ou que Steam était en panne, le problème est résolu. Toutefois, si vous pouviez reproduire votre problème plusieurs fois de suite, pendant 2 jours, redémarrez ASF et votre machine au cours du processus et assurez-vous qu'il n'y a aucune entrée de FAQ dans cette section pour aider à le résoudre. Demander à propos de ce problème.

---

### ASF semble se figer et n'imprime rien sur la console tant que je n'ai pas appuyé sur une touche!

Vous utilisez probablement Windows et le mode QuickEdit de votre console est activé. Reportez-vous à **[cette question](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** sur StackOverflow pour une explication technique. Vous devez désactiver le mode QuickEdit en cliquant avec le bouton droit de la souris sur la fenêtre de la console ASF, en ouvrant les propriétés et en décochant la case appropriée.

---

### ASF ne peut accepter ou envoyer de trades!

Ce qui est évident en premier - les nouveaux comptes commencent de manière limitée. Tant que vous n'avez pas déverrouillé le compte en chargeant son portefeuille ou en dépensant $5 dans le magasin, ASF ne peut accepter ni envoyer de transactions via ce compte. Dans ce cas, ASF indiquera que l'inventaire semble vide, car chaque carte qu'il contient est non échangeable.

Ensuite, si vous n'utilisez pas **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, il est possible qu'ASF accepte ou envoie des échanges, mais vous devez le confirmer par e-mail. De même, si vous utilisez 2FA classique, vous devez confirmer le commerce via votre authentificateur. Les confirmations sont **obligatoires** maintenant. Si vous ne souhaitez pas les accepter par vous-même, envisagez d'importer votre authentificateur dans ASF 2FA.

Notez également que vous ne pouvez échanger qu'avec vos amis et les personnes ayant un lien commercial connu. Si vous essayez d'initier un échange *Bot -> Master* comme `butin`, alors vous devez avoir soit votre bot sur votre liste d'amis, soit votre `SteamTradeToken` déclaré dans la configuration du Bot. Assurez-vous que le jeton est valide - sinon, vous ne serez pas en mesure d'envoyer une transaction.

Enfin, rappelez-vous que les verrous commerciaux des nouveaux appareils sont verrouillés pendant 7 jours. Si vous venez d'ajouter votre compte à ASF, attendez au moins 7 jours. Tout devrait fonctionner après cette période. That limitation includes **both** accepting **and** sending trades. Cela ne déclenche pas toujours, et il y a des gens qui peuvent envoyer et accepter des transactions instantanément. La majorité des personnes sont toutefois affectées et le verrouillage ** se produira **, même si vous pouvez envoyer et accepter des transactions via votre client Steam sur le même ordinateur. Attendez patiemment, vous ne pouvez rien faire pour accélérer les choses. De même, vous pouvez obtenir des verrous similaires pour supprimer/modifier divers paramètres liés à la sécurité Steam, tels que 2FA, SteamGuard, mot de passe, e-mail et autres. En général, vérifiez si vous pouvez envoyer une transaction depuis ce compte vous-même, si oui, il est très probable que c'est un verrou classique de 7 jours à partir du nouvel appareil.

Enfin, n'oubliez pas qu'un compte ne peut avoir que 5 transactions en attente sur un autre. ASF ne pourra donc pas envoyer de transactions si vous en avez déjà 5 (ou plus) en attente. C’est rarement un problème, mais il convient également de le mentionner, en particulier si vous définissez ASF pour l’envoi automatique d’opérations, alors que vous n’utilisez pas ASF 2FA et que vous avez oublié de les confirmer.

Si rien ne vous aide, vous pouvez toujours activer le mode `Débogage` et vérifier vous-même pourquoi les demandes échouent. Veuillez noter que Steam parle de non-sens la plupart du temps, et que la raison fournie peut ne pas avoir de sens logique. ou peut être tout à fait incorrecte - si vous décidez d'interpréter cette raison, assurez-vous d'avoir une bonne connaissance de Steam et de ses bizarreries. Il est également assez courant de voir ce problème sans raison logique, et la seule solution suggérée dans ce cas consiste à rajouter un compte à ASF (et à attendre 7 jours de plus). Parfois, ce problème se corrige également * comme par magie *, de la même manière qu'il se brise. Cependant, il s’agit généralement d’un blocage des échanges de 7 jours, d’un problème temporaire de steam ou des deux. Il est préférable de lui donner quelques jours avant de vérifier manuellement ce qui ne va pas, à moins que vous ne souhaitiez déboguer la cause réelle (et vous serez généralement obligé d'attendre de toute façon, car le message d'erreur n'aura aucun sens, ni ne vous aidera au moindre).

Dans tous les cas, ASF peut uniquement **essayer** d'envoyer une demande appropriée à Steam afin d'accepter / d'envoyer une transaction. Que Steam accepte ou non cette requête est hors de portée d'ASF, et ASF ne la fera pas fonctionner comme par magie. Il n'y a pas de bogue lié à cette fonctionnalité, et il n'y a rien à améliorer, car la logique se passe en dehors d'ASF. Par conséquent, ne demandez pas de matériel de réparation qui ne soit pas cassé, et ne demandez pas non plus pourquoi ASF ne peut accepter ou envoyer de transactions - ** je ne sais pas et ASF ne le sait pas non plus **. Soit faites-le traiter, soit faites-vous réparer, si vous savez mieux.

---

### Pourquoi dois-je mettre le code 2FA / Steam Guard à chaque connexion? / *Removed expired login key*

ASF utilise des clés de connexion (si vous maintenez `UseLoginKeys` activé) pour maintenir les informations d'identification valides, le même mécanisme que celui utilisé par Steam -  2FA / SteamGuard n'est requis qu'une seule fois. Cependant, en raison de problèmes de réseau Steam et de bizarreries, il est tout à fait possible que la clé de connexion ne soit pas enregistrée dans le réseau, nous avons déjà vu de tels problèmes non seulement avec ASF, mais aussi avec le client Steam régulier (un besoin d'entrer login + mot de passe à chaque exécution, indépendamment de l'option "se souvenir de moi").

You could remove `BotName.db` and `BotName.bin` (if available) of affected account and try to link ASF to your account once again, but that likely won't do anything. Certains utilisateurs ont signalé que **[dé-autorisant tous les appareils](https://store.steampowered.com/twofactor/manage)** du côté Steam devrait aider, changer le mot de passe fera de même. Cependant, ce ne sont que des contournements qui ne sont même pas garantis de travailler, la vraie solution basée sur ASF est d'importer votre authentificateur en tant que **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** - de cette façon ASF peut générer des jetons automatiquement quand ils sont nécessaires, et vous n'avez pas à les saisir manuellement. Habituellement, le problème se résout comme par magie après un certain temps, vous pouvez donc simplement attendre que cela se produise. Bien sûr, vous pouvez également demander une solution à Valve, car je ne peux pas forcer le réseau Steam à accepter nos clés de connexion.

Comme note latérale, vous pouvez également désactiver les clés de connexion avec la propriété de configuration `UseLoginKeys` définie à `false`, mais cela ne résoudra pas le problème, seulement sauter l'échec de la clé de connexion initiale. ASF est déjà conscient du problème expliqué ici et fera de son mieux pour ne pas utiliser de clés de connexion si elle peut se garantir tous les identifiants de connexion, donc il n’est pas nécessaire de modifier manuellement `UseLoginKeys` si vous pouvez fournir toutes les informations de connexion avec ASF 2FA.

---

### Je reçois une erreur: *Impossible de se connecter à Steam: `InvalidPassword` ou `RateLimitExceeded`*

Cette erreur peut signifier beaucoup de choses, parmi lesquelles:

- Combinaison login/mot de passe invalide (évidemment)
- Clé de connexion expirée utilisée par ASF pour se connecter
- Trop de tentatives de connexion infructueuses sur une courte période (anti-bruteforce)
- Trop de tentatives de connexion sur une courte période (limitation du débit)
- Obligation de captcha pour se connecter (très probablement pour deux raisons ci-dessus)
- Toute autre raison pour laquelle le réseau Steam peut vous empêcher de vous connecter

En cas d'anti-bruteforce et de limitation de débit, le problème disparaîtra au bout d'un certain temps, alors attendez et ne tentez pas de vous connecter entre-temps. Si vous rencontrez souvent ce problème, il est peut-être sage d'augmenter la propriété de configuration `LoginLimiterDelay` de ASF. Les redémarrages de programme excessifs et les autres demandes de connexion intentionnelles / non intentionnelles ne vous aideront certainement pas à résoudre ce problème, essayez donc de l'éviter si possible.

En cas d'expiration de la clé de connexion, ASF supprimera l'ancienne clé et en demandera une nouvelle lors de la prochaine connexion (ce qui vous demandera de mettre un jeton 2FA si votre compte est protégé par 2FA. Si votre compte utilise ASF 2FA, le jeton sera généré et utilisé automatiquement). Cela peut naturellement se produire avec le temps, mais si vous obtenez ce problème à chaque connexion, il est possible que Steam ait décidé pour une raison quelconque d'ignorer nos demandes de sauvegarde de clé de connexion, comme mentionné dans le numéro **[au-dessus de](#why-do-i-have-to-put-2fasteamguard-code-on-each-login--removed-expired-login-key)**. You can of course disable `UseLoginKeys` entirely, but that won't solve the issue, only avoid a need of removing expired login keys each time. La vraie solution, conformément au problème ci-dessus, est d'utiliser ASF 2FA.

Et enfin, si vous avez utilisé une mauvaise combinaison login / mot de passe, vous devez évidemment le corriger ou désactiver le bot qui tente de se connecter à l'aide de ces informations d'identification. ASF ne peut pas déterminer par elle-même si `InvalidPassword` signifie des informations d'identification non valides ou l'une des raisons répertoriées ci-dessus. Par conséquent, il continuera d'essayer jusqu'à ce qu'il réussisse.

N'oubliez pas qu'ASF dispose de son propre système intégré pour réagir en conséquence aux aléas de steam. Elle finira par se connecter et reprendre son travail. Par conséquent, il n'est pas nécessaire de faire quoi que ce soit si le problème est temporaire. Redémarrer ASF afin de résoudre les problèmes comme par magie ne fera qu'aggraver les choses (comme les nouveaux ASF ne sauront pas l'état précédent d'ASF, à savoir ne pas pouvoir se connecter et essayer de se connecter au lieu d'attendre), évitez de le faire à moins que vous savez ce que vous faites.

Enfin, comme pour toute demande Steam - ASF ne peut que **essayer** de se connecter, en utilisant les informations d'identification fournies. Que cette demande aboutisse ou non est hors du champ d'application et de la logique d'ASF - il n'y a pas de bogue, et rien ne peut être corrigé ni amélioré à cet égard.

---

### Je ne peux pas saisir les informations de connexion que ASF demande
### `System.InvalidOperationException: Impossible de lire les clés quand l'application n'a pas de console ou quand l'entrée de la console a été redirigée`
### `System.IO.IOException: Erreur d'entrée/sortie`
### `L'entrée RequestInput() est invalide !`

Si cette erreur s'est produite pendant l'entrée ASF (par ex. vous pouvez voir `GetUserInput()` dans la stacktrace) alors elle est causée par votre environnement qui interdit à ASF de lire l'entrée standard de votre console. Cela peut se produire pour de nombreuses raisons, mais la plus courante est que vous exécutiez ASF dans le mauvais environnement (e.g. en `systčme`, `nohup` ou `&` arrière-plan au lieu d'e. . `écran` sur Linux). Si ASF ne peut pas accéder à son entrée standard, vous verrez alors cette erreur enregistrée et l'incapacité d'ASF à utiliser vos informations pendant l'exécution.

Normalement, vous devriez corriger le problème ci-dessus, c'est-à-dire autoriser ASF à accéder à l'entrée standard afin que vous puissiez fournir les détails. However, if you **expect** this to happen, so you **intend** to run ASF in input-less environment, then you should explicitly tell ASF that it's the case, by setting **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** mode appropriately. Cela dira à ASF de ne jamais demander la saisie de l’utilisateur en aucune circonstance, vous permettant d’exécuter ASF en toute sécurité dans des environnements sans entrée. Vous pouvez répondre aux demandes d'entrées sélectionnées par d'autres moyens dans ce mode, par exemple dans ASF-ui.

---

### `System.Net.Http.WinHttpException: A security error occurred`

Cette erreur se produit lorsque ASF ne peut pas établir de connexion sécurisée avec un serveur , presque exclusivement à cause de la méfiance du certificat SSL.

Dans presque tous les cas, cette erreur est provoquée par **une date/heure erronée sur votre ordinateur**. Chaque certificat SSL a une date d'émission et une date d'expiration. Si votre date n'est pas valide et si vous avez dépassé ces deux limites, alors le certificat ne peut pas être approuvé en raison d'une attaque potentielle du MITM **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)** et ASF refuse de se connecter.

La solution évidente consiste à régler correctement la date sur votre machine. Il est vivement recommandé d'utiliser la synchronisation automatique des dates, telle que la synchronisation native disponible sous Windows, ou `ntpd` sous Linux.

Si vous vous êtes assuré que la date sur votre machine est appropriée et que l'erreur ne veut pas disparaître, Les certificats SSL dont votre système de confiance pourrait être obsolète ou non valide. Dans ce cas, vous devez vous assurer que votre ordinateur peut établir des connexions sécurisées, par exemple en vérifiant si vous pouvez accéder à `https://github.com` avec le navigateur de votre choix ou à un outil CLI tel que `curl`. Si vous confirmez que cela fonctionne correctement, n'hésitez pas à nous demander de l'aide.

---

### `System.Threading.Tasks.TaskCanceledException: A task was canceled`

Cet avertissement signifie que Steam n'a pas répondu à la demande ASF dans le temps imparti. Généralement, cela est causé par le hoquet de réseau Steam et n'affecte en rien ASF. Dans d'autres cas, c'est la même chose que la requête échoue après 5 tentatives. Signaler ce problème n'a aucun sens la plupart du temps, car nous ne pouvons pas forcer Steam à répondre à nos demandes.

---

### `Le type initialiseur pour 'System.Security.Cryptography.CngKeyLite' a lancé une exception`

Ce problème est presque exclusivement causé par le service Windows désactivé/arrêté `CNG Key Isolation` service Windows, qui fournit des fonctionnalités de cryptographie de base pour ASF, sans lesquelles le programme ne peut pas être exécuté. You can fix this issue by launching `services.msc` and ensuring that `CNG Key Isolation` Windows service doesn't have disabled startup and is currently running.

---

### ASF est détecté comme un malware par mon antivirus! Que se passe-t-il ?

** Assurez-vous d'avoir téléchargé ASF à partir d'une source approuvée**. La seule source officielle et fiable est **[ASF publie](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** page sur GitHub (et c'est également la source des mises à jour automatiques ASF). **toute autre source n'est pas approuvée par définition et peut contenir des logiciels malveillants ajoutés par d'autres personnes** - vous ne devriez pas faire confiance à un autre emplacement de téléchargement, assurez-vous que votre ASF vient toujours de nous.

Si vous confirmez qu'ASF est téléchargé à partir d'une source approuvée, il s'agit très probablement d'un faux positif. Ce **s'est produit dans le passé**, **se passe maintenant**, et **se produira dans le futur**. Si vous êtes préoccupé par la sécurité lors de l'utilisation d'ASF, je vous suggère d'analyser ce dernier avec différents outils de détection, par exemple via **[VirusTotal](https://www.virustotal.com)** (ou tout autre service Web de votre choix).

Si le AV que vous utilisez détecte faussement ASF en tant que programme malveillant, alors ** il est judicieux de renvoyer cet exemple de fichier aux développeurs de votre système audiovisuel afin qu'ils puissent l'analyser et améliorer leur moteur de détection **, aussi clairement que cela ne fonctionne pas aussi bien que vous le pensez. Il n’ya pas de problème dans le code ASF, et il n’y a rien non plus à résoudre pour nous, puisque nous ne distribuons pas de logiciels malveillants au départ, il n’a donc aucun sens de nous signaler ces faux positifs. Nous vous recommandons vivement d’envoyer un échantillon ASF pour une analyse plus approfondie, comme indiqué ci-dessus, mais si vous ne voulez pas vous en soucier, vous pouvez toujours ajouter ASF à une sorte d’exception AV, désactivez votre AV ou utilisez-en simplement un autre. Malheureusement, nous sommes habitués à ce que les antivirus soient stupides, car certains détectent de temps à autre ASF comme un virus, qui dure généralement très peu de temps et qui est rapidement corrigé par les développeurs, mais comme nous l’avons souligné plus haut - ** il est arrivé **, ** arrive ** et ** se produira ** tout le temps. ASF n'inclut pas de code malveillant, vous pouvez le réviser et même le compiler vous-même à la source. Nous ne sommes pas des hackers pour obscurcir le code ASF afin de cacher les heuristiques AV et les faux positifs, alors n'attendez pas de nous pour réparer ce qui n'est pas cassé - il n'y a pas de "virus" à réparer.