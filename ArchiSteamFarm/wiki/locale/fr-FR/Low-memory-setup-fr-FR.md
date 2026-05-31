# Configuration avec peu de mémoire

C'est l'exact opposé d'une **[configuration haute performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup)** et typiquement vous allez vouloir suivre ces conseils si vous souhaitez que ASF consomme moins de mémoire dans votre système, en échange de performance.

---

ASF par définition consomme extrêmement peu de resources, dépendamment de votre utilisation, même un VPS de 128 MB avec Linux installé est capable de le faire tourner, bien que de partir aussi bas n'est pas recommandé et peut créer divers problèmes. Bien que léger, ASF n'a pas peur de demander a L'OS plus de mémoire, si cette mémoire est nécessaire pour que ASF fonctionne à une vitesse optimale.

ASF en tant qu’application tente d’être aussi optimisé et efficace que possible, ce qui tient également compte des ressources utilisées pendant l’exécution. En ce qui concerne la mémoire, ASF préfère les performances à la consommation de mémoire, ce qui peut donner lieu à des "pics" de mémoire temporaire, qui peuvent être remarqués par ex. avec des comptes ayant plus de 3 pages de badge, car ASF va récupérer et analyser la première page, lue à partir du nombre total de pages, puis lancez la tâche de récupération pour chaque page supplémentaire, ce qui donne lieu à la récupération et à l'analyse simultanées des pages restantes. Cette utilisation "extra" de la mémoire (par rapport au strict minimum pour l'opération) peut considérablement accélérer l'exécution et les performances globales, pour le coût de l'utilisation de la mémoire qui est nécessaire pour faire toutes ces choses en parallèle. Des choses similaires se passent à toutes les autres tâches générales ASF qui peuvent être exécutées en parallèle, p. ex. en analysant les offres commerciales actives, ASF peut les analyser tous en même temps, car elles sont toutes indépendantes les unes des autres. On top of that, ASF (C# runtime) will **not** return unused memory back to OS immediately afterwards, which you can quickly notice in form of ASF process only taking more and more memory, but (almost) never giving that memory back to the OS. Certaines personnes peuvent déjà le trouver douteux, peut-être même suspecter une fuite de mémoire, mais ne vous inquiétez pas, tout cela est à attendre.

ASF est extrêmement bien optimisé et utilise les ressources disponibles autant que possible. High memory usage of ASF doesn't mean that ASF actively **uses** that memory and **needs it**. Très souvent, ASF conservera la mémoire allouée en tant que "espace" pour les actions futures, parce que nous pouvons améliorer considérablement les performances si nous n'avons pas besoin de demander à OS pour chaque tronçon de mémoire que nous sommes sur le point d'utiliser. The runtime should automatically release unused ASF memory back to OS when OS will **truly** need it. **[La mémoire inutilisée est gaspillée de la mémoire](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. You run into issues when the memory you **need** is higher than the memory that is available for you, not when ASF keeps some extra allocated with purpose of speeding up functions that will execute in a moment. Vous rencontrez des problèmes lorsque votre noyau Linux tue le processus ASF à cause de OOM (mémoire insuffisante), pas lorsque vous voyez le processus ASF comme le meilleur consommateur de mémoire dans `htop`.

**[Le processus de collecte de déchets](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** utilisé dans ASF est un mécanisme très complexe, assez intelligent pour prendre en compte non seulement ASF lui-même, mais aussi votre OS et d'autres processus. Lorsque vous avez beaucoup de mémoire libre, ASF demandera tout ce qui est nécessaire pour améliorer les performances. Cela peut même être de 1 Go (avec le serveur GC). Lorsque la mémoire de votre système d'exploitation est sur le point d'être pleine, ASF relâchera automatiquement une partie de celle-ci vers le système d'exploitation pour aider les choses à s'installer, qui peut donner lieu à une utilisation globale de la mémoire ASF à partir de 50 Mo. La différence entre 50 Mo et 1 Go est énorme, mais c'est aussi la différence entre un petit VPS de 512 Mo et un grand serveur dédié de 32 Go. Si ASF peut garantir que cette mémoire sera utile, et en même temps, rien d’autre ne l’exige pour le moment, il préfèrera le conserver et s'optimisera automatiquement en fonction des routines qui ont été exécutées dans le passé. Le GC utilisé dans ASF est auto-ajusté et obtiendra de meilleurs résultats plus longtemps le processus est en cours d’exécution.

C'est aussi la raison pour laquelle la mémoire du processus ASF varie de la configuration à l'installation, car ASF fera de son mieux pour utiliser les ressources disponibles de la manière **aussi efficace que possible**, et pas d'une manière fixe comme si cela avait été fait pendant Windows XP. L'utilisation réelle de la mémoire qu'ASF utilise peut être vérifiée avec la commande `stats` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, et est généralement d'environ 4 Mo pour seulement quelques bots, jusqu'à 30 Mo si vous utilisez des choses comme **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** et d'autres fonctionnalités avancées. Gardez à l'esprit que la mémoire retournée par la commande `stats` inclut également de la mémoire libre qui n'a pas encore été récupérée par le collecteur de déchets. Tout le reste est de la mémoire d'exécution partagée (environ 40-50 Mo) et de la place pour l'exécution (variable). C’est aussi la raison pour laquelle le même ASF peut utiliser pas moins de 50 Mo dans l’environnement VPS à faible mémoire, tout en utilisant jusqu'à 1 Go sur votre bureau. ASF s’adapte activement à votre environnement et essaiera de trouver un équilibre optimal afin de ne pas mettre votre OS sous pression, ni limiter ses propres performances lorsque vous avez beaucoup de mémoire non utilisée qui pourrait être mise en place.

---

Bien sûr, il y a beaucoup de façons de vous aider à orienter ASF dans la bonne direction en termes de mémoire que vous attendez utiliser. En général, si vous n'avez pas besoin de le faire, il est préférable de laisser le collecteur de déchets travailler en paix et faire tout ce qu'il estime être le mieux. Mais ce n'est pas toujours possible, par exemple si votre serveur Linux héberge également plusieurs sites web, bases de données MySQL et les employés de PHP, alors vous ne pouvez pas vraiment vous permettre qu'ASF se rétrécisse quand vous exécutez près d'OOM, car il est généralement trop tard et la dégradation des performances arrive plus tôt. C'est généralement lorsque vous pourriez être intéressé par d'autres réglages, et donc lire cette page.

Les suggestions ci-dessous sont divisées en quelques catégories, avec des difficultés variées.

---

## Configuration ASF (facile)

Les astuces **ci-dessous n'affectent pas les performances négativement** et peuvent être appliquées en toute sécurité à toutes les installations.

- Run **[generic version](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** of ASF if possible. La version générique d'ASF utilise moins de mémoire car elle n'inclut pas l'exécution à l'intérieur, ne vient pas en tant que fichier unique, n'a pas besoin de se décompresser à l'exécution, et est donc plus petit et a moins d'empreinte mémoire. Les paquets spécifiques au système d'exploitation sont pratiques et pratiques, mais ils sont également fournis avec tout ce qui est nécessaire pour lancer ASF, , vous pouvez prendre soin de vous et utiliser plutôt la variante générique ASF.
- Ne jamais exécuter plus d'une instance ASF. ASF is meant to handle unlimited number of bots all at once, and unless you're binding every ASF instance to different interface/IP address, you should have exactly **one** ASF process, with multiple bots (if needed).
- Make use of `ShutdownOnFarmingFinished` in bot's `FarmingPreferences`. Le bot actif prend plus de ressources qu'il n'en a désactivé. Ce n'est pas une sauvegarde significative, car l'état du bot doit toujours être conservé, mais vous économisez une certaine quantité de ressources, en particulier toutes les ressources liées au réseau, telles que les sockets TCP. Vous pouvez toujours faire apparaître d'autres bots si nécessaire.
- Gardez le nombre de vos bots à un niveau inférieur. Not `Enabled` bot instance takes less resources, as ASF doesn't bother starting it. Gardez également à l'esprit qu'ASF doit créer un bot pour chacune de vos configurations, donc si vous n'avez pas besoin de `démarrer` un bot donné et que vous voulez économiser de la mémoire, vous pouvez temporairement renommer `Bot. son` à ex. `Bot.json.bak` afin d'éviter de créer un état pour votre instance de bot désactivée dans ASF. De cette façon, vous ne serez pas en mesure de `démarrer` sans le renommer en retour, mais ASF ne se souciera pas non plus de garder l'état de ce bot en mémoire, laissant de la place pour d'autres choses (très petite sauvegarde, en 99. % de cas que vous ne devriez pas vous embêter, gardez juste vos bots avec `Activé` de `faux`).
- Ajuster vos configurations. Surtout la configuration globale d'ASF a de nombreuses variables à ajuster, par exemple en augmentant `LoginLimiterDelay` vous afficherez vos bots plus lentement, qui permettra à l'instance déjà commencée de récupérer des badges entre-temps, plutôt que de faire apparaître vos bots plus rapidement, qui prendra plus de ressources car plus de bots feront un travail majeur (comme l'analyse de badges) en même temps. Moins il faut faire de travail en même temps - moins de mémoire utilisée.

Ce sont quelques choses que vous pouvez garder à l'esprit lorsque vous traitez de l'utilisation de la mémoire. Cependant, ces choses n'ont aucune matière "cruciale" en ce qui concerne l'utilisation de la mémoire, parce que l'utilisation de la mémoire provient principalement de choses qu'ASF doit traiter, et non de structures internes utilisées pour le farming des cartes.

Les fonctions les plus lourdes sont :
- Analyse de la page du badge
- Analyse des stocks

Ce qui signifie que la mémoire sera la plus forte lorsque ASF traitera de la lecture des pages de badge, et quand il traitera de son inventaire (e. . envoyer des échanges ou travailler avec la STM). En effet, ASF doit gérer une quantité énorme de données - l'utilisation de la mémoire de votre navigateur favori qui lance ces deux pages ne sera pas inférieure à cela. Désolé, c'est comment ça marche - diminuer le nombre de vos pages de badge, et garder le nombre d'éléments de votre inventaire bas, cela peut vous aider.

---

## Runtime tuning (avancé)

Ci-dessous les astuces **impliquent la dégradation des performances** et doivent être utilisées avec prudence.

La façon recommandée d'appliquer ces paramètres est par le biais des propriétés d'environnement `DOTNET_`. Bien sûr, vous pouvez également utiliser d'autres méthodes, par exemple `runtimeconfig. fils`, mais certains paramètres sont impossible à définir de cette façon, et en plus de cela, ASF remplacera votre configuration d'exécution personnalisée `. fils` avec sa propre mise à jour lors de la prochaine mise à jour, nous vous recommandons donc de définir facilement les propriétés d'environnement avant de lancer le processus.

.NET runtime vous permet de régler **[le ramasse-miettes](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** de beaucoup de manières. affiner efficacement le processus GC en fonction de vos besoins. Nous avons documenté ci-dessous des propriétés qui sont particulièrement importantes à notre avis.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Spécifie l'utilisation autorisée du tas GC en pourcentage de la mémoire physique totale.

La limite de mémoire "dur" pour le processus ASF, ce paramètre permet à GC d'utiliser uniquement un sous-ensemble de mémoire totale et pas toute celle-ci. Il peut devenir particulièrement utile dans diverses situations de type serveur où vous pouvez consacrer un pourcentage fixe de la mémoire de votre serveur à ASF, mais jamais plus que cela. Sachez que limiter la mémoire à utiliser par ASF ne fera pas disparaître toutes les allocations de mémoire requises par magie, Par conséquent, la définition de cette valeur trop basse pourrait entraîner une saturation des scénarios de mémoire, où le processus ASF sera forcé de se terminer.

Par contre, définir cette valeur suffisamment haute est un moyen parfait pour s'assurer qu'ASF n'utilisera jamais plus de mémoire que vous ne pouvez le faire de manière réaliste, Donner à votre machine de la salle de respiration même sous une lourde charge, tout en permettant au programme de faire son travail le plus efficacement possible.

### [`GCConserveMémoire`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Configure le collecteur de déchets pour conserver la mémoire au détriment des collections de déchets plus fréquentes et éventuellement plus longues périodes de pause.

Une valeur comprise entre 0 et 9 peut être utilisée. Plus la valeur est grande, plus le GC optimisera la mémoire par rapport aux performances.

### [`format@@0 GCHighMemPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Spécifie la quantité de mémoire utilisée après laquelle GC devient plus agressif.

Ce paramètre configure le seuil de mémoire de votre système d'exploitation entier, qui une fois passé, fait que GC devient plus agressif et tente d'aider le système à réduire la charge de mémoire en exécutant un processus GC plus intensif, ce qui permet de libérer plus de mémoire libre sur le système d'exploitation. C'est une bonne idée de définir cette propriété sur une quantité maximale de mémoire (en pourcentage) que vous considérez comme « critique » pour toute la performance de votre système d'exploitation. La valeur par défaut est de 90%, et vous voulez généralement la conserver dans une plage de 80-97%, car une valeur trop faible provoquera une agression inutile du GC et une dégradation des performances sans raison, alors que la valeur trop élevée va mettre une charge inutile sur votre OS, étant donné qu'ASF pourrait libérer une partie de sa mémoire pour aider.

### **[`Niveau de GCLAT`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Spécifie le niveau de latence du GC que vous souhaitez optimiser.

Ceci est une propriété non documentée qui s'est avérée fonctionner exceptionnellement bien pour ASF, En limitant la taille des générations de GC, et en conséquence, la purge de GC les rend plus fréquentes et plus agressives. Le niveau de latence par défaut (équilibré) est `1`, mais vous pouvez utiliser `0`, ce qui permettra de régler l'utilisation de la mémoire.

### [`format@@0 gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> Lorsque mis en place, nous découpons l'espace engagé de manière plus agressive pour la tige éphémère. Ceci est utilisé pour exécuter de nombreuses instances de processus serveur où ils veulent garder le moins de mémoire livrée possible.

Cela offre peu d'amélioration, mais peut rendre la GC encore plus agressive quand le système sera faible en mémoire, en particulier pour ASF qui utilise lourdement les tâches de pool de threadpots.

---

Vous pouvez activer les propriétés sélectionnées en définissant les variables d'environnement appropriées. Par exemple, sur Linux (shell):

```shell
# N'oubliez pas de les modifier si vous prévoyez de les utiliser
export DOTNET_GCHeapHardLimitPercent=0x4B # 75% en tant que
export DOTNET_GCHighMemPercent=0x50 # 80% en tant que

export DOTNET_GCConserveMemory=9
export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

. ArchiSteamFarm # Pour la compilation spécifique à un système d'exploitation
./ArchiSteamFarm.sh # Pour la compilation générique
```

Ou sous Windows (powershell):

```powershell
# N'oubliez pas d'ajuster ceux si vous prévoyez de les utiliser
$Env:DOTNET_GCHeapHardLimitPourcent=0x4B # 75% en
$Env:DOTNET_GCHighMemPercent=0x50 # 80% en tant que hexadécimal

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

. ArchiSteamFarm.exe # Pour une compilation spécifique à un système d'exploitation
.\ArchiSteamFarm.cmd # Pour une compilation générique
```

Surtout `GCLatencyLevel` sera très utile car nous avons vérifié que le runtime optimise effectivement le code pour la mémoire et diminue donc significativement l'utilisation de la mémoire moyenne, même avec le serveur GC. C'est l'un des meilleurs trucs que vous pouvez appliquer si vous voulez réduire significativement l'utilisation de la mémoire ASF tout en ne dégradant pas trop les performances avec `OptimizationMode`.

---

## Réglage ASF (intermédiaire)

Ci-dessous les astuces **impliquent une dégradation sérieuse des performances** et doivent être utilisées avec prudence.

- En dernier ressort, vous pouvez régler ASF pour `MinMemoryUsage` via `OptimisationMode` **[propriété de configuration globale](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**. Lisez attentivement son objet, car il s'agit d'une dégradation sérieuse des performances pour presque aucun avantage mémoire. C'est typiquement **la dernière chose que vous voulez faire**, longtemps après avoir passé par **[runtime tuning](#runtime-tuning-advanced)** pour vous assurer que vous êtes obligé de le faire. À moins d'être absolument critique pour votre installation, nous décourageons l'utilisation de `MinMemoryUsage`, même dans des environnements contraints de mémoire.

---

## Optimisation recommandée

- Commencez à partir de simples astuces de configuration ASF, utilisez la variante **[ASF générique](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** et vérifiez si vous utilisez peut-être simplement votre ASF de manière incorrecte, comme démarrer le processus plusieurs fois pour tous vos bots, ou les garder tous actifs si vous avez besoin d'un ou deux pour démarrer automatiquement.
- Si cela ne suffit toujours pas, activez toutes les propriétés de configuration listées ci-dessus en définissant les variables d'environnement `DOTNET_` appropriées. Surtout `GCLatencyLevel` offre des améliorations significatives en temps d'exécution pour peu de coûts sur les performances.
- Si même cela n'a pas aidé, en dernier recours, activez `MinMemoryUsage` `OptimisationMode`. Cela force ASF à exécuter presque tout en matière de synchronisation, faire en sorte que cela fonctionne beaucoup plus lentement, mais aussi ne pas compter sur le pool de thread pour équilibrer les choses quand il s'agit de l'exécution parallèle.

Il est physiquement impossible de réduire davantage la mémoire, votre ASF est déjà fortement dégradé en termes de performances et vous avez épuisé toutes vos possibilités, à la fois au niveau du code et au niveau du temps d'exécution. Pensez à ajouter de la mémoire supplémentaire à ASF à utiliser, même 128 Mo ferait une grande différence.