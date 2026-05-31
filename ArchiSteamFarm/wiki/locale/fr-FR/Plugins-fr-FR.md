# Extensions

ASF inclut le support des plugins personnalisés qui peuvent être chargés pendant l'exécution. Les plugins vous permettent de personnaliser le comportement ASF, par exemple en ajoutant des commandes personnalisées, une logique de trading personnalisée ou une intégration entière avec des services et des API tiers.

Cette page décrit les plugins ASF du point de vue des utilisateurs - explication, utilisation et similaire. Si vous voulez voir la perspective du développeur, déplacez **[ici](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)** à la place.

---

## Utilisation

ASF charge les plugins depuis le répertoire `plugins` situé dans votre dossier ASF. C'est une pratique recommandée (qui devient obligatoire avec les mises à jour automatiques du plugin) pour maintenir un répertoire dédié pour chaque plugin que vous voulez utiliser, qui peut être basé sur son nom, comme `MyPlugin`. Faire cela donnera comme résultat une structure type `plugins/MyPlugin`. Enfin, tous les fichiers binaires du plugin devraient être placés dans ce dossier dédié, et ASF découvrira et utilisera correctement votre plugin après le redémarrage.

Habituellement, les développeurs de plugins publieront leurs plugins sous la forme d'un fichier `zip` avec des binaires à l'intérieur, ce qui signifie que vous devriez décompresser ce fichier zip dans son propre sous-répertoire dédié à l'intérieur du répertoire `plugins`.

Si le plugin a été chargé avec succès, vous verrez son nom et sa version dans votre journal. Vous devriez consulter les développeurs de votre plugin en cas de questions, de problèmes ou d'utilisation liés aux plugins que vous avez décidé d'utiliser.

Vous pouvez trouver des plugins en vedette dans notre section **[contenu tiers](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)**.

**Faites attention les plugins ASF peuvent-être malveillants**. Vous devriez toujours vous assurer que vous utilisez des plugins créés par des développeurs en qui vous pouvez faire confiance, même ceux de la section tierce ci-dessus. Les développeurs d'ASF ne peuvent plus vous garantir les avantages habituels d'ASF (tels que l'absence de logiciels malveillants ou l'absence de bans VAC) si vous décidez d'utiliser des plugins personnalisés. Vous devez comprendre que les plugins ont un contrôle total sur le processus ASF une fois chargé, à cause de cela, nous sommes également incapables de prendre en charge les configurations qui utilisent des plugins personnalisés, puisque vous n'utilisez plus de code ASF d'origine.

---

## Compatibilité

Selon la complexité du plugin, la portée et beaucoup d'autres facteurs, il est tout à fait possible que vous ayez besoin d'utiliser la variante **[générique](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** ASF, au lieu d'habitude recommandé **[spécifique au système d'exploitation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. Ceci est dû au fait que la variante spécifique au système d'exploitation est fournie uniquement avec les fonctionnalités de base requises pour ASF lui-même, et votre plugin peut nécessiter des parties qui sortent de la portée principale d'ASF, ce qui entraîne une incompatibilité avec les compilations spécifiques au système d'exploitation.

En général, lorsque nous utilisons des plugins tiers, nous recommandons d’utiliser une variante générique ASF pour une compatibilité maximale. Cependant, tous les plugins ne peuvent pas l'exiger - veuillez vous référer aux informations de votre plugin afin de savoir si vous devez utiliser ou non la variante ASF générique.

---


## Mises à jour automatiques

ASF a un mécanisme intégré pour les mises à jour automatiques des plugins. Pour que cette fonctionnalité fonctionne, tout d'abord, votre plugin de choix a besoin pour **[de prendre en charge](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)** ce mécanisme. Si vous avez chargé un plugin qui prend en charge les mises à jour automatiques, ASF l'indiquera dans le journal lors de l'initialisation du plugin, comme "plugin a été désactivé à partir des mises à jour automatiques" ou "plugin a été enregistré et activé pour les mises à jour automatiques".

Par défaut, les mises à jour automatiques pour les plugins personnalisés sont **désactivées**, pour des raisons de sécurité. Vous pouvez configurer les mises à jour automatiques de la configuration en utilisant **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** et/ou **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)**, Nous vous recommandons de lire la description de ces propriétés de configuration pour plus d'informations. Il est également agréable de noter que, comme avec les mises à jour ASF, vous pouvez décider de garder les mises à jour automatiques désactivées, puis de mettre à jour au besoin, au besoin. base manuelle, en publiant la commande `updateplugins` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

Les deux approches vous permettent de mettre à jour aucun, certains ou tous les plugins personnalisés que vous avez chargés dans le processus.