# Performance

L'objectif principal d'ASF est d'exploiter de la manière la plus efficace possible, en se basant sur deux types de données sur lesquelles elle peut opérer: un petit ensemble de données fournies par l'utilisateur qu'il est impossible pour ASF de deviner / vérifier par lui-même, et un ensemble plus grand de données qui peut être vérifié automatiquement par ASF.

En mode automatique, ASF ne vous permet pas de choisir les jeux à exploiter ni de modifier l’algorithme de farming des cartes. **ASF sait mieux que vous ce qu’il devrait faire et quelles décisions elle devrait prendre afin de farmer le plus vite possible**. Votre objectif est de définir correctement les fonctions de configuration, car ASF ne peut les deviner, tout le reste est couvert.

---

Il y a quelque temps, Valve a modifié l'algorithme pour l'obtention de cartes. À partir de ce moment, nous pouvons classer les comptes Steam en deux catégories: les **avec** obtention de carte restreintes et les **sans**. La seule différence entre ces deux types est le fait que les comptes avec des cartes restreintes ne peuvent pas obtenir de carte à partir du jeu donné avant qu'ils ne jouent à un jeu donné pendant au moins `X` heures. Il semble que les anciens comptes qui n'ont jamais demandé de remboursement ont **des cartes sans restriction**, alors que les nouveaux comptes et ceux qui ont demandé le remboursement ont **des cartes restreintes**. Il ne s'agit toutefois que d'une théorie, et elle ne doit pas être considérée comme une règle. That's why there is **no obvious answer**, and ASF relies on **you** telling it which case is appropriate for your account.

---

ASF comprend actuellement deux algorithmes de farming :

L'algorithme **`Simple`** fonctionne mieux pour les comptes qui ont des cartes sans restriction. Il s'agit de l'algorithme primaire utilisé par ASF. Bot trouve des jeux à la ferme, et les ferme un par un jusqu'à ce que toutes les cartes soient abandonnées. Cela est dû au fait que le taux de baisse des cartes est proche de zéro et totalement inefficace lorsque plusieurs jeux sont cultivés.

**`Complexe`** est un nouvel algorithme qui a été mis en œuvre pour aider les comptes restreints à maximiser leurs profits également. ASF utilisera d'abord l'algorithme standard **`Simple`** sur tous les jeux qui ont passé `HoursUntilCardDrops` heures de jeu, alors, si aucune partie avec >= `HoursUntilCardDrops` heures sont restantes, elle fermera tous les jeux (jusqu'à `limite de 32` ) avec < `HoursUntilCardDrops` heures restantes simultanément, jusqu'à ce que l'un d'entre eux touche `HoursUntilCardDrops` heures, alors ASF poursuivra la boucle depuis le début (utilisez **``** Simple sur ce jeu, retour simultané sur < `HoursUntilCardDrops` et ainsi de suite). Nous pouvons utiliser l'agriculture de jeux multiples dans ce cas pour des heures de bump des jeux que nous avons besoin de cultiver à la valeur appropriée d'abord. Keep in mind that during farming hours, ASF **does not** farm cards, so it also won't check for any card drops during that period (for reasons stated above).

Actuellement, ASF choisit un algorithme de farming de cartes basé uniquement sur la propriété de configuration `HoursUntilCardDrops` (qui est défini par **vous**). Si `HoursUntilCardDrops` est défini à `0`, **`algorithme simple`** sera utilisé, sinon, **`Algorithme`** sera utilisé à la place - configuré pour augmenter le temps de jeu dans tous les jeux pour un nombre d'heures donné avant de les gérer pour les gouttes de cartes.

---

### **There is no obvious answer which algorithm is better for you**.

C'est l'une des raisons pour lesquelles vous ne choisissez pas l'algorithme de farming des cartes, au lieu de cela, vous dites à ASF si le compte a des drops restreints ou non. If account has non-restricted drops, **`Simple`** algorithm will **work better** on that account, as we won't be wasting time on bringing all games to `X` hours - cards drop ratio is close to 0% when farming multiple games. Par contre, si votre compte a des pertes de carte, il est restreint, **`algorithme complexe`** sera meilleur pour vous, comme il est inutile de cultiver en solo si le jeu n'a pas atteint `HoursUntilCardDrops` heures - donc nous fermerons **temps de jeu** en premier, **puis** cartes en mode solo.

Ne définissez pas aveuglément `HoursUntilCardDrops` uniquement parce que quelqu'un vous a dit de - faire des tests, comparez les résultats, et en fonction des données que vous obtenez, décidez quelle option devrait être la meilleure pour vous. Si vous déployez un effort minimal dans ce sens, vous vous assurerez qu'ASF fonctionne avec une efficacité maximale pour votre compte, qui est probablement ce que vous voulez, étant donné que vous lisez cette page wiki en ce moment. S'il y avait une solution qui fonctionne pour tout le monde, on ne vous donnerait pas le choix: ASF se déciderait.

---

### Quelle est la meilleure façon de savoir si votre compte est restreint?

Assurez-vous d'avoir quelques parties avec **sans temps de jeu enregistré** pour fermer, de préférence 5+, et exécutez ASF avec `HoursUntilCardDrops` de `0`. Ce serait une bonne idée si vous ne jouiez rien pendant la période de farming pour des résultats plus précis (mieux vaut exécuter ASF pendant la nuit). Laissez ASF exploiter ces 5 jeux, et après cela, consultez le journal pour obtenir des résultats.

ASF indique clairement quand une carte pour un jeu donné a été abandonnée. Vous êtes intéressé par la baisse de la carte la plus rapide atteinte par ASF. Par exemple, si votre compte est illimité, une première baisse de carte devrait avoir lieu après environ 30 minutes depuis le début de la ferme. If you notice **at least one** game that did drop card in those initial 30 minutes, then this is an indicator that your account is **not** restricted and should use `HoursUntilCardDrops` of `0`.

Par contre, si vous remarquez que **chaque partie** prend au moins `X` nombre d'heures avant de lâcher sa première carte, alors c'est un indicateur pour vous ce que vous devez définir `HoursUntilCardDrops`. La majorité des utilisateurs restreints requièrent au moins `3` heures de temps de jeu pour les cartes, et c'est aussi la valeur par défaut pour `HoursUntilCardDrops`.

Rappelez-vous que les jeux peuvent avoir un taux de drop différent c'est pourquoi vous devriez tester si votre théorie est correcte avec **au moins** 3 parties, de préférence 5+ pour vous assurer que vous ne rencontrez pas de faux résultats par une coïncidence. A card drop of one game in less than an hour is a confirmation that your account **is not** restricted and can use `HoursUntilCardDrops` of `0`, but for confirming that your account **is** restricted, you need at least several games that are not dropping cards until you hit a fixed mark.

Il est important de noter que dans le passé `HoursUntilCardDrops` était seulement `0` ou `2`, et c'est pourquoi ASF avait une seule propriété `CardDropsRestricted` qui permettait de basculer entre ces deux valeurs. Avec les changements récents, nous avons remarqué que la majorité des utilisateurs ont non seulement besoin de `3` heures à la place des `2` précédents maintenant, mais aussi que `HoursUntilCardDrops` est maintenant dynamique et peut toucher n'importe quelle valeur par compte.

En fin de compte, bien sûr, la décision vous appartient.

Et pour le rendre encore pire - j'ai vécu des cas où des gens sont passés d'un état restreint à un état sans restriction et vice versa - soit à cause d'un bug Steam (oh oui, oui, nous en avons plusieurs), ou à cause de quelques ajustements logiques par Valve. Donc, même si vous avez confirmé que votre compte est restreint (ou pas), ne croyez pas qu'il restera comme ça - afin de passer de sans restriction à restreint, il suffit de demander un remboursement. Si vous avez l'impression que la valeur précédemment définie n'est plus appropriée, vous pouvez toujours effectuer un re-test et la mettre à jour en conséquence.

---

Par défaut, ASF suppose que `HoursUntilCardDrops` est `3`, comme l'effet négatif de la mise à `3` quand elle devrait être moins petite que celle qui a été faite. C'est parce que, dans le pire des cas, nous allons gaspiller `3` heures de farming par partie `32` par rapport à la perte de `3` heures de farming pour chaque jeu si `HoursUntilCardDrops` a été réglé sur `0` par défaut. Cependant, vous devriez toujours affiner cette variable pour qu'elle corresponde à votre compte pour une efficacité maximale, car il ne s'agit que d'une hypothèse aveugle basée sur les inconvénients potentiels et la majorité des utilisateurs (donc nous essayons de choisir "moindre mal" par défaut).

Pour le moment, deux algorithmes ci-dessus sont suffisants pour tous les scénarios de compte actuellement possibles, afin d'exploiter le plus efficacement possible, il n'est donc pas prévu d'en ajouter d'autres.

Il est agréable de noter qu'ASF inclut également un mode de farming manuel qui peut être activé par la commande `play`. Vous pouvez en savoir plus à ce sujet dans les commandes **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

## Problèmes de vapeur

L'algorithme d'abandon de cartes ne fonctionne pas toujours comme il le devrait, et il est tout à fait possible que divers bugs de Steam se produisent, comme les cartes sont supprimées sur les comptes restreints, les cartes sont abandonnées lors de la fermeture/changement de jeu, les cartes ne tombent pas du tout lorsque la partie est jouée, et de même.

Cette section s'adresse principalement aux personnes qui se demandent pourquoi ASF ne fait pas **X**, comme passer rapidement aux cartes de ferme plus rapidement.

Qu'est-ce qu'un bug **Steam** - une action spécifique déclenchant un comportement **indéfini** , qui est **non intentionné, non documenté, et considéré comme une faille logique**. It's **unreliable by definition**, which means that it can't be reproduced reliably with clean testing environment, and therefore, coded without resorting to hacks that are supposed to guess when glitch is happening and how to fight with it / abuse it. Généralement, il est temporaire jusqu'à ce que les développeurs corrigent les défauts de la logique, bien que certains bugs divers puissent passer inaperçus pendant une très longue période.

Un bon exemple de ce qui est considéré comme un bug **Steam** n'est pas si rare que de lâcher une carte lorsque le jeu est fermé, qui peut être abusé dans une certaine mesure avec la fonction de saut de jeu du maître inactif.

- **Undefined behaviour** - you can't say if there will be 0 or 1 cards being dropped when you trigger the glitch.
- **Non prévu** - basé sur l'expérience passée et le comportement du réseau Steam qui ne donne pas le même comportement lors de l'envoi d'une seule requête.
- **Non documenté** - il est clairement documenté sur le site Web Steam comment les cartes sont obtenues, et **à chaque endroit** il est clairement indiqué qu'il est obtenu par **jouant à**, PAS de fermeture des jeux, d'obtenir des accomplissements, de changer ou de lancer 32 jeux simultanément.
- **Considered as a logic flaw** - closing game(s) or switching them should have no outcome on cards being dropped which are clearly stated to be obtained through **gaining playtime**.
- **Non fiable par définition, ne peut pas être reproduit de manière fiable** - cela ne fonctionne pas pour tout le monde, et même s'il fonctionnait pour vous une fois, il ne pouvait plus fonctionner pour la deuxième fois.

Maintenant une fois que nous avons réalisé quel est le problème de Steam, et le fait que les cartes soient abandonnées lorsque le jeu est fermé, **est** un, nous pouvons passer au deuxième point - **ASF n'abuse pas du réseau Steam par définition, et il fait de son mieux pour se conformer à Steam ToS, à ses protocoles et à ce qui est généralement accepté**. Spammer le réseau Steam avec des requêtes constantes d'ouverture et de fermeture de jeu peut être considéré comme une attaque **[DoS](https://en.wikipedia.org/wiki/Denial-of-service_attack)** et **viole directement [Steam Online Conduct](https://store.steampowered.com/online_conduct/?l=english)**.

> En tant qu'abonné à Steam, vous acceptez de respecter les règles de conduite suivantes.
> 
> Vous ne le ferez pas:
> 
> Instituer des attaques sur un serveur Steam ou perturber par ailleurs Steam.

Peu importe si vous êtes capable de déclencher un bug de Steam avec d'autres programmes (comme IM), et peu importe que vous soyez d'accord avec nous et que vous considériez un comportement comme une attaque DoS, ou non - Il revient à Valve de juger ceci, mais si nous le considérons comme un comportement explosif ou abusif par le biais de demandes excessives de réseau Steam, alors vous pouvez être assez sûr que Valve aura un point de vue similaire à ce sujet.

ASF is **never** going to take advantage of Steam exploits, abuses, hacks or any other activity that we see as **illegal or unwanted** according to Steam ToS, Steam Online Conduct or any other trusted source that could indicate that ASF activity is unwanted by Steam network, as stated in **[contributing](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)** section.

Si vous voulez à tout prix risquer votre compte Steam pour cultiver quelques cartes de quelques centimes plus rapidement que d'habitude, alors malheureusement, ASF ne proposera jamais quelque chose comme ça en mode automatique, bien que vous ayez toujours `jouer à la commande` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** qui peut être utilisée comme outil pour faire ce que vous voulez en termes d'interaction avec le réseau Steam. Nous ne recommandons pas de profiter des bugs de Steam et de les exploiter pour votre propre gain - pas seulement avec ASF, mais aussi avec tout autre outil. En fin de compte, c'est votre compte, et votre choix de ce que vous voulez en faire - gardez à l'esprit que nous vous avons averti.