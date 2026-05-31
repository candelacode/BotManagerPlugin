# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` est le plugin officiel ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** développé par nous, qui vous permet de contribuer au projet **[SteamDB](https://steamdb.info)** en partageant les jetons du paquet, jetons d'application et clés de dépôt auxquels votre compte Steam a accès. Les informations étendues sur les données collectées et pourquoi SteamDB en a besoin peuvent être trouvées sur la page de SteamDB **[Token Dumper](https://steamdb.info/tokendumper)**. Les données soumises n'incluent aucune information potentiellement sensible, et ne présentent aucun risque de sécurité ou de confidentialité, comme indiqué dans la description ci-dessus.

---

## Activer le plugin

ASF est livré avec `SteamTokenDumperPlugin` livré avec la version, mais le plugin lui-même est désactivé par défaut. Vous pouvez activer le plugin en définissant `SteamTokenDumperPluginEnabled` la propriété de configuration globale ASF à `true`, en syntaxe JSON:

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

Lors du lancement du programme ASF, le plugin vous informera s'il a été activé avec succès par le mécanisme d'enregistrement standard d'ASF. Vous pouvez également activer le plugin via notre générateur de configuration basé sur le Web.

---

## Détails techniques

Lors de l'activation, le plugin utilisera les bots que vous exécutez dans ASF pour la collecte de données sous forme de jetons de paquet, jetons d'application et clés de dépôt auxquels vos bots ont accès. Le module de collecte de données comprend des routines passives et actives qui sont censées minimiser les frais supplémentaires occasionnés par la collecte de données.

Afin de remplir le cas d'utilisation prévu, en plus de la routine de collecte de données expliquée ci-dessus, la routine de soumission est initialisée comme étant responsable de déterminer quelles données doivent être soumises à SteamDB sur une base périodique. Cette routine va déclencher jusqu'à `1` heure depuis le démarrage de votre ASF, et se répétera toutes les `24` heures. Le plugin fera de son mieux pour minimiser la quantité de données à envoyer, donc il est possible que certaines données que le plugin va collecter soient déterminées comme inutiles à soumettre, et donc ignoré (par exemple mise à jour de l'application qui ne modifie pas le jeton d'accès).

Le plugin utilise une base de données de cache persistante enregistrée dans un emplacement `config/SteamTokenDumper.cache` qui sert un but similaire à `config/ASF.db` pour ASF. Le fichier est utilisé pour enregistrer les données collectées et soumises et minimiser la quantité de travail qui doit être faite sur différentes exécutions ASF. La suppression du fichier provoque le redémarrage du processus à partir de zéro, ce qui devrait être évité si possible.

---

## Données

ASF inclut le contributeur `steamID` dans la requête, qui est déterminé comme `SteamOwnerID` que vous avez défini dans ASF, ou au cas où vous ne l'auriez pas fait, l'ID Steam du bot qui possède le plus de licences. Le contributeur annoncé pourrait recevoir quelques avantages supplémentaires de la part de SteamDB pour une aide continue (e. . rang de donateur sur le site Web), mais cela dépend entièrement de la discrétion de SteamDB.

Dans tous les cas, le personnel de SteamDB aimerait vous remercier à l'avance pour votre aide. Les données envoyées permettent à SteamDB de fonctionner, en particulier pour suivre les informations sur les paquets, applications et dépôts, ce qui ne serait plus possible sans votre aide.

---

## Commande

Le plugin STD est fourni avec une commande ASF, `std [Bots]`, qui vous permet de déclencher l'actualisation et la soumission des bots sélectionnés à la demande. L'utilisation de la commande ne nécessite pas la configuration activée, ce qui vous permet de passer la collecte et la soumission automatiques, et de contrôler le processus vous-même manuellement. Naturellement, il peut également être exécuté avec la configuration activée, ce qui déclenchera simplement les procédures habituelles de collecte et de soumission plus tôt que prévu.

Nous recommandons `!std ASF` afin de déclencher la mise à jour de tous les robots disponibles. Cependant, vous pouvez également le déclencher pour les sélectionnés si vous le souhaitez.

---

## Configuration avancée

Notre plugin prend en charge la configuration avancée qui pourrait s'avérer utile pour les personnes qui voudraient modifier les internes à leur préférence.

La configuration avancée a la structure suivante située dans `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Enabled": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretPackageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Toutes les options sont expliquées ci-dessous :

### `Enabled`

`bool` avec la valeur par défaut `false`. Cette propriété agit de la même manière que `SteamTokenDumperPluginEnabled` propriété de niveau racine expliquée ci-dessus, et peut être utilisée à la place, dédié aux personnes qui préfèrent avoir une configuration complète liée au plugin dans sa propre structure (probablement celles qui utilisent déjà d'autres propriétés avancées expliquées ci-dessous).

---

### `SecretAppIDs`

`ImmutableHashSet<uint>` avec la valeur par défaut étant vide. Cette propriété spécifie `appIDs` que le plugin ne résoudra pas, et si elles sont déjà résolues, ne soumettra pas le jeton. Cette propriété peut être utile pour les personnes ayant accès à des informations potentiellement sensibles sur les éléments non publiés, en particulier les développeurs, les éditeurs ou les bêta-testeurs fermés.

---

### `SecretDepotIDs`

`ImmutableHashSet<uint>` avec la valeur par défaut étant vide. Cette propriété spécifie `depotIDs` que le plugin ne résoudra pas, et si elles sont déjà résolues, ne soumettra pas la clé. Cette propriété peut être utile pour les personnes ayant accès à des informations potentiellement sensibles sur les éléments non publiés, en particulier les développeurs, les éditeurs ou les bêta-testeurs fermés.

---

### `IDs du paquet secret`

`ImmutableHashSet<uint>` avec la valeur par défaut étant vide. Cette propriété spécifie `packageIDs` (également connu sous le nom de `sous-IDs`) que le plugin ne résoudra pas, et s'ils sont déjà résolus, ne soumettra pas le jeton. Cette propriété peut être utile pour les personnes ayant accès à des informations potentiellement sensibles sur les éléments non publiés, en particulier les développeurs, les éditeurs ou les bêta-testeurs fermés.

---

### `Ignorer AutoGrantPackages`

`bool` avec la valeur par défaut `true</ 0>. Cette propriété agit très similaire à <code>SecretPackageIDs` et lorsqu'elle est activée, provoquera que les paquets avec `EPaymentMethod` de `AutoGrant` soient ignorés pendant la routine de résolution expliquée ci-dessous. La méthode de paiement `AutoGrant` est utilisée par **[Steamworks](https://partner.steamgames.com)** pour accorder automatiquement des packages sur les comptes développeurs. Bien que ce ne soit pas aussi explicite que les autres options `Secret` et donc ne garantit rien (puisque vous pourriez avoir d'autres paquets que `AutoGrant` que vous ne voulez toujours pas soumettre), il devrait être assez bon pour sauter la majorité, sinon la totalité, des paquets secrets. Cette option est activée par défaut, car les personnes qui ont effectivement accès aux paquets `AutoGrant` ne voudront presque jamais les fuir au grand public, et donc utiliser la valeur de `false` est très situationnel.

---

## Explication supplémentaire

At the root level, every Steam account owns a set of packages (licenses, subscriptions), which are classified by their `packageID` (also known as `subID`). Chaque package peut contenir plusieurs applications classées par leur `appID`. Chaque application peut alors inclure plusieurs dépôts classés par leur `depotID`.

```text
├── sub/124923
│     ├── app/292030
│     │     ├── depot/292031
│     │     ├── depot/378648
│     │     └── ...
│     ├── app/378649
│     └── ...
└── ...
```

Notre plugin inclut deux routines qui prennent en compte les éléments ignorés - la routine de résolution et la routine de soumission.

La routine de résolution est responsable de la résolution de l'arborescence que vous pouvez voir ci-dessus. En mettant en liste noire les paquets/apps/depots à l'avance, vous couperez l'arbre à la place de la branche sur liste noire sans avoir besoin de spécifier les parties restantes de l'arbre. In our example above, if `124923` package was ignored, whether by `SecretPackageIDs` or `SkipAutoGrantPackages`, and it was the only package you own which linked to the `292030` appID, then appID `292030` wouldn't get resolved either, and by definition, if there were no other resolved apps which linked to the `292031` and `378648` depots, then they wouldn't get resolved either. Cependant, gardez à l'esprit que si le plugin a déjà résolu l'arborescence, cela empêchera seulement l'élément d'être mis à jour (par ex. nouvelles applications ajoutées), il ne rendra pas le plugin "oublier" des éléments existants qui ont déjà été résolus (e. . applications trouvées dans ce paquet avant de décider de le mettre sur liste noire). If you've just enabled some skipping options, and would like to ensure that ASF doesn't traverse the already-resolved tree, you may consider one-time removing `config/SteamTokenDumper.cache` file where the plugin keeps its cache.

La routine de soumission est responsable de l'envoi des jetons de paquets, des jetons d'application et des clés de dépôt des éléments déjà résolus (par la routine de résolution ci-dessus). Ici, votre liste noire a un effet immédiat, comme si le plugin a déjà résolu les infos, la routine de soumission ne le soumettra pas à la base de données SteamDB si vous l'avez mis sur liste noire, que ce soit ou non résolu. Gardez cependant à l'esprit que nous ne parlons plus de l'arbre à ce stade, la routine d'envoi ne sait pas si les informations sur l'application proviennent de tel ou tel paquet, donc il saute seulement les informations sur des éléments particuliers, sur la liste noire, quelle que soit la relation qu'ils entretiennent avec les autres.

For majority of the developers and publishers, it should be enough to keep `SkipAutoGrantPackages` enabled, potentially empowered with `SecretPackageIDs` only, as it effectively cuts the tree at the beginning branch and guarantees that the apps and depots included further will not get submitted as long as there is no other package linking to the same app. If you want to be double sure, in addition to that you can also use `SecretAppIDs`, which will skip the resolve of the app even if there are some other licenses you didn't blacklist linking to it. Using `SecretDepotIDs` should not be needed, unless you have a particular, specific need (such as skipping only a particular depot while still submitting info about packages and apps), or if you want to add yet another layer to be triple safe.