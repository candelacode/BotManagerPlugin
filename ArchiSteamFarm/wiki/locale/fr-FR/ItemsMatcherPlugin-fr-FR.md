# format@@0 ItemsMatcherPlugin

`ItemsMatcherPlugin` est le plugin officiel ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** qui étend ASF avec les fonctionnalités de liste ASF. En particulier, ceci inclut `PublicListing` en **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** et `MatchActively` en **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. ASF comes with `ItemsMatcherPlugin` bundled together with the release, therefore it's ready for usage right away.

---

## `Liste publique`

La liste publique, comme le nom l'indique, est la liste des robots ASF STM actuellement disponibles. Il se trouve sur **[notre site](https://asf.justarchi.net/STM)**, gérée automatiquement et utilisée comme service public pour les deux utilisateurs ASF qui utilisent `MatchActively`, ainsi que les utilisateurs ASF et non-ASF pour une recherche manuelle.

Pour être listé, vous avez un ensemble de conditions à remplir. Au minimum, vous devez avoir autorisé `PublicListing` dans `RemoteCommunication` (paramètre par défaut), `SteamTradeMatcher` activé dans `TradingPreferences`, **[inventaire public](https://steamcommunity.com/my/edit/settings)** paramètres de confidentialité, un **[compte](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** et **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** actif. Les exigences supplémentaires incluent 2FA actif depuis au moins 15 jours, dernier changement de mot de passe il y a plus de 5 jours, l'absence de restrictions de compte telles que les blocages, les interdictions économiques et les interdictions commerciales. Naturellement, vous devez également avoir au moins un élément (échangeable) dans votre inventaire à partir de `MatchableTypes`spécifié, comme les cartes de trading. En plus de cela, les robots avec plus de `500000` éléments ne sont pas acceptés en raison de frais excessifs Nous vous recommandons de diviser votre inventaire sur plusieurs comptes dans ce cas.

While `PublicListing` is enabled by default, please note that you will **not** be displayed on the website if you do not meet all of the requirements, especially `SteamTradeMatcher`, which isn't enabled by default. For people that do not meet the criteria, even if they kept `PublicListing` enabled, ASF doesn't communicate with the server in any way. La liste publique est également compatible uniquement avec la dernière version stable d'ASF et peut refuser d'afficher les robots obsolètes, surtout s'il manque des fonctionnalités de base qui ne peuvent être trouvées que dans les versions plus récentes.

### Comment ça marche exactement

ASF envoie les données initiales une fois après la connexion, contenant toutes les propriétés que la liste publique utilise. Ensuite, toutes les 10 minutes, ASF envoie une très petite requête de type "pulsation" qui informe notre serveur que le bot est toujours opérationnel. Si, pour une raison quelconque, la pulsation n’arrivait pas, par exemple à cause de problèmes de réseau, ASF tentera de l’envoyer à chaque minute, jusqu’à ce que le serveur l’enregistre. De cette façon, notre serveur sait précisément quels robots sont toujours en cours d'exécution et prêts à accepter les offres commerciales. ASF enverra également une annonce initiale au besoin, par exemple si elle détecte que notre inventaire a changé depuis la précédente.

Nous affichons tous les comptes ASF éligibles qui ont été actifs dans la **pendant 15 minutes**. Les utilisateurs sont triés selon leur utilité relative - `MatchEverything` bots qui sont affichés avec `n'importe quelle bannière` qui acceptent toutes les transactions 1:1, puis les jeux uniques comptent, et enfin les objets comptent.

### API

ASF STM accepte seulement les bots ASF pour l’instant. Il n'y a aucun moyen de lister les bots tiers sur notre liste pour le moment, car nous ne pouvons pas revoir leur code facilement et nous assurer qu'ils répondent à toute notre logique de trading. La participation à la liste nécessite donc la dernière version stable ASF, bien qu'elle puisse s'exécuter avec les plugins **[personnalisés](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

Pour les consommateurs de la liste, nous avons un point de terminaison **[très simple`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** que vous pouvez utiliser. Il inclut toutes les données que nous possédons, en dehors des inventaires des utilisateurs qui font partie de la fonctionnalité exclusive de `MatchActively`.

### Politique de confidentialité

Si vous acceptez d'être listé dans notre liste, en activant `SteamTradeMatcher` et en ne refusant pas `PublicListing`, comme spécifié ci-dessus, nous stockerons temporairement certaines des informations de votre compte Steam sur notre serveur afin de fournir les fonctionnalités attendues.

L'info publique (exposée par Steam à chaque partie intéressée) comprend :
- Votre identificateur Steam (sous forme 64 bits, pour générer des liens)
- Votre pseudo (pour l'affichage)
- Votre avatar (hash, pour l'affichage)

Les informations publiques conditionnellement (exposées par Steam à toutes les parties intéressées si vous remplissez les exigences de liste) incluent:
- Votre inventaire **[](https://steamcommunity.com/my/inventory/#753_6)** (pour que les gens puissent utiliser `MatchActively` contre vos objets).

Les informations privées (données sélectionnées requises pour fournir la fonctionnalité) comprend:
- Votre **

 jeton de d'échange </ 0> (afin que des personnes ne faisant pas partie de votre liste d'amis puissent vous envoyer des échanges)</li> 
  
  - Votre paramètre `MatchableTypes` (pour l'affichage et la correspondance)
- Votre paramètre `MatchEverything` (pour l'affichage et la correspondance)
- Votre paramètre `MaxTradeHoldDuration` (pour que les autres personnes sachent si vous êtes prêt à accepter leurs transactions)</ul> 

Depuis le moment où vous cessez d'utiliser (annoncez) notre liste, vos données deviennent indisponibles pour le grand public dans un délai de 15 minutes maximum, et est autrement conservé sur notre serveur pour un maximum de deux semaines - tout est automatiquement supprimé après cette période. Aucune action n'est requise de votre part pour que cela se produise.



---



## `MatchActively`

Le paramètre `MatchActively` est une version active de **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** incluant la correspondance interactive dans laquelle le bot enverra des transactions à d'autres personnes. Il peut fonctionner en mode autonome, ou avec le paramètre `SteamTradeMatcher`. Cette fonctionnalité nécessite la définition de `LicenseID` car elle utilise un serveur tiers et des ressources payantes pour fonctionner.

Afin de pouvoir utiliser cette option, vous avez un ensemble de conditions à remplir. Au minimum, vous devez avoir un compte **[sans restriction](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** actif et au moins un type valide dans `MatchableTypes`, comme le commerce des cartes. Les exigences supplémentaires incluent 2FA actif depuis au moins 15 jours, dernier changement de mot de passe il y a plus de 5 jours, l'absence de restrictions de compte telles que les blocages, les interdictions économiques et les interdictions commerciales.

Si vous remplissez toutes les conditions ci-dessus, ASF communiquera périodiquement avec notre liste **[publique ASF STM](#publiclisting)** afin de faire correspondre activement les bots actuellement disponibles.

Pendant la correspondance, le bot ASF va récupérer son propre inventaire, alors communiquez avec notre serveur avec lui pour trouver toutes les correspondances possibles `MatchableTypes` d'autres bots actuellement disponibles. Merci de communiquer directement avec notre serveur, ce processus nécessite une requête unique et nous avons des informations immédiates si un bot disponible nous propose quelque chose d'intéressant - si la correspondance est trouvée, ASF enverra et confirmera automatiquement l’offre d’échange.

Ce module est censé être transparent. La correspondance commencera dans environ `1` heure depuis le démarrage d'ASF, et se répétera chaque `6` heures (si nécessaire). `MatchActively` feature is aimed to be used as a long-run, periodical measure to ensure that we're actively heading towards sets completion, however, people that are not running ASF 24/7 may also consider using a `match` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Les utilisateurs cibles de ce module sont les comptes primaires et "cacher" les comptes alt, bien qu'il puisse être utilisé par n'importe quel bot qui n'est pas réglé sur `MatchEverything`. En plus de cela, les bots avec plus de `500000` éléments ne sont pas acceptés pour correspondre en raison de frais excessifs Nous vous recommandons de diviser votre inventaire sur plusieurs comptes dans ce cas.

ASF fait de son mieux pour minimiser le nombre de requêtes et de pressions générées en utilisant cette option, tout en maximisant l'efficacité de l'adaptation à la limite supérieure. L'algorithme exact de sélection des bots pour correspondre et organiser par ailleurs l'ensemble du processus, est le détail de la mise en œuvre d'ASF et peut changer en ce qui concerne les retours, la situation et les éventuelles idées futures.

The current version of the algorithm makes ASF prioritize `Any` bots first, especially those with better diversity of games that their items are from. When running out of `Any` bots, ASF will move on to the `Fair` ones upon same diversity rule. ASF essaiera de faire correspondre chaque bot disponible au moins une fois, pour s'assurer que nous ne sommes pas manquants sur une éventuelle progression définie.

`MatchActively` prend en compte les bots que vous avez mis en liste noire de la négociation via `tbadd` **[commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** et n'essayera pas de les faire correspondre activement. Cela peut être utilisé pour indiquer à ASF quels bots il ne doit jamais correspondre, même s'ils auraient des dupes potentielles à utiliser pour nous.

ASF fera également de son mieux pour s'assurer que les offres commerciales sont en cours. Lors de la prochaine exécution, ce qui se produit normalement dans 6 heures, ASF annulera toutes les offres d'échange en attente qui n'ont pas encore été acceptées, et déprioriser les steamIDs qui y participent pour préférer d'abord plus de bots actifs. Néanmoins, si les bots dépriorisés sont les derniers à avoir le match dont nous avons besoin, nous allons quand même essayer de les faire correspondre (encore).



---



### Why do I need a `LicenseID` to use `MatchActively`? « N'était-ce pas gratuit avant? »

ASF est, et reste, libre et open-source, tel qu’il a été établi au début du projet en octobre 2015. Le code source du plugin `ItemsMatcher` et donc la fonctionnalité `MatchActively` est disponible dans notre dépôt, alors que le programme ASF est entièrement non commercial, nous ne gagnons rien en y contribuant, en y construisant ou en publiant. Au cours de ces 7 dernières années, ASF a reçu un énorme volume de développement, et il est toujours en cours d'amélioration et d'amélioration à chaque version stable mensuelle principalement par une seule personne, **[JustArchi](https://github.com/JustArchi)** - sans chaînes attachées. Le seul financement que nous recevons provient de dons non obligatoires provenant de nos utilisateurs.

Pendant très longtemps, jusqu'en octobre 2022, la fonctionnalité `MatchActively` faisait partie du cœur d'ASF et était disponible pour tout le monde. En octobre 2022, Valve, la société derrière Steam, a mis des limites de débit très sévères sur la récupération des inventaires d'autres bots - qui ont rendu la fonctionnalité précédente entièrement cassée, sans possibilité de solution pour résoudre ce problème. Par conséquent, en raison du fait que la fonctionnalité est devenue complètement obsolète sans aucune chance d'être corrigée, il devait être retiré du noyau ASF comme obsolète.

`MatchActively` a été ressuscité dans le cadre du plugin officiel `ItemsMatcher` qui améliore davantage ASF avec la fonctionnalité correspondante des cartes actives, sur la base d'un concept entièrement retravaillé. Resurrecting `MatchActively` feature required from us **extraordinary amount of work** to create ASF backend, entirely new service hosted on a server, with more than a hundred of paid proxies attached for resolving inventories, all exclusively to allow ASF clients to make use of `MatchActively` like before. En raison de la quantité de travail impliquée, ainsi que les ressources qui ne sont pas gratuites et qui ont besoin d'être payées mensuellement par nous (domaine, serveur, proxies), nous avons décidé d'offrir cette fonctionnalité à nos sponsors, c'est-à-dire des personnes qui soutiennent déjà le projet ASF sur une base mensuelle, grâce à qui nous pouvons mettre à disposition ces ressources payantes.

Our goal isn't to profit from it, but rather, cover the **monthly costs** that are exclusively linked with offering this option - that's why we offer it basically for nothing, but we do have to charge a little for it as we can't pay hundreds of dollars from our own pockets each month, just to make it available for you. Nous ne sommes pas non plus en mesure de discuter du prix, c'est la Vanne qui nous a contraints à payer ces coûts, et l'alternative est de ne pas avoir une telle fonctionnalité du tout, qui bien sûr s'applique si vous décidez, pour quelque raison que ce soit, que vous ne pouvez pas justifier l'utilisation de notre plugin sur ces termes.

En tout cas, nous comprenons que `MatchActively` n'est pas pour tout le monde, et nous espérons que vous comprenez aussi pourquoi nous ne pouvons pas l'offrir gratuitement. Si personne ne souhaitait aider à couvrir les coûts de cette fonctionnalité, elle n'existerait tout simplement pas. car nous serions contraints de réduire les dépenses mensuelles que personne n'est prêt à maintenir. Heureusement, nous sommes en meilleure position que cela, et vous pouvez décider vous-même si vous êtes prêt à utiliser `MatchActively` sur ces termes, ou non.



---



### Comment puis-je obtenir un accès?

`ItemsMatcher` est proposé dans le cadre du palier mensuel de 5 $ + sponsor sur **[GitHub](https://github.com/sponsors/JustArchi)** de JustArchi. Il est également possible de devenir un sponsor ponctuel, bien que dans ce cas, la licence ne sera valide que pour un mois (avec possibilité d'extension de la même manière). Une fois que vous êtes devenu sponsor de 5 $ de niveau (ou supérieur), lisez la section **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** pour obtenir et remplir `LicenseID`. Ensuite, vous avez seulement besoin d'activer `MatchActively` dans `TradingPreferences` du bot choisi.

La licence vous permet d'envoyer un nombre limité de requêtes au serveur. $5 tier vous permet d'utiliser `MatchActively` pour un compte bot (4 requêtes par jour), et chaque $5 additionnel ajoute deux comptes bot supplémentaires (8 requêtes par jour). Par exemple, si vous voulez l'exécuter sur trois comptes, cela sera couvert par 10 niveaux et plus.