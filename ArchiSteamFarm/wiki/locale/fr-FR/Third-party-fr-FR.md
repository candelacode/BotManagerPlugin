# Services tiers

Cette section comprend divers ajouts de tierces-parties écrits exclusivement (ou principalement) pour une utilisation avec ASF. Ils vont des plugins ASF, en passant par des applications Web simples et des bibliothèques internes pour l’intégration, jusqu'à des bots complets pour d’autres plates-formes. Si vous souhaitez ajouter un élément à la liste, faites-nous le savoir sur le discord ou sur notre groupe Steam.

Veuillez noter que les programmes ci-dessous sont **pas** maintenus par les développeurs ASF et donc **nous ne donnons aucune garantie à leur sujet**, en particulier en termes de sécurité, de sécurité ou de conformité Steam ToS. Cette liste est est à titre de référence uniquement. Vous devriez toujours vous assurer que l'utilitaire tiers que vous êtes sur le point d'utiliser est sûr et qu'il est suffisamment légitime pour vous, car vous les utilisez tous à vos propres risques.

---

## ASF plugins

### **[CatPoweredPlugins](https://github.com/CatPoweredPlugins)** (**[Rudokhvist](https://github.com/Rudokhvist)**)

- **[ASFAchievementManager](https://github.com/CatPoweredPlugins/ASFAchievementManager)**, plugin pour ASF qui vous permet de gérer les réalisations Steam.
- **[BirthdayPlugin](https://github.com/CatPoweredPlugins/BirthdayPlugin)**, plugin pour que ASF reçoive des félicitations pour son anniversaire.
- **[CaseInsensitiveASF](https://github.com/CatPoweredPlugins/CaseInsensitiveASF)**, plugin permettant à ASF de rendre les noms de bot insensibles à la casse.
- **[CommandAliasPlugin](https://github.com/CatPoweredPlugins/CommandAliasPlugin)**, plugin pour ASF pour configurer des alias de commandes personnalisées pour les commandes ASF.
- **[CommandlessRedeem](https://github.com/CatPoweredPlugins/CommandlessRedeem)**, plugin pour qu'ASF réimplémente le rachat de clés sans commande.
- **[ItemDispenser](https://github.com/CatPoweredPlugins/ItemDispenser)**, plugin pour qu'ASF accepte automatiquement la demande d'échange pour certains types d'éléments.
- **[SelectiveLootAndTransferPlugin](https://github.com/CatPoweredPlugins/SelectiveLootAndTransferPlugin)**, plugin for ASF providing advanced `transfer` command for transferring Steam items.

### **[Citriner](https://github.com/Citrinate)**

- **[BoosterManager](https://github.com/Citrinate/BoosterManager)**, pour ASF fournissant une interface facile à utiliser pour transformer des gemmes en packs de booster ainsi que diverses fonctionnalités pour gérer les inventaires et les listes de marché.
- **[CS2Interface](https://github.com/Citrinate/CS2Interface)**, plugin pour ASF qui vous permet d'interagir avec Counter-Strike 2 en utilisant **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**.
- **[FreePackages](https://github.com/Citrinate/FreePackages)**, plugin pour ASF qui trouve des packages gratuits sur Steam et les ajoute à votre compte.

### **[Vita](https://github.com/ezhevita)**

- **[FriendAccepter](https://github.com/ezhevita/FriendAccepter)**, plugin pour qu'ASF accepte automatiquement toutes les invitations d'ami.
- **[GameRemover](https://github.com/ezhevita/GameRemover)**, plugin pour ASF implémentant une commande pour supprimer les licences Steam pour les instances de bot sélectionnées.
- **[GetEmail](https://github.com/ezhevita/GetEmail)**, plugin pour ASF implémentant une commande pour récupérer l'adresse e-mail de certaines instances de bot directement à partir de Steam.
- **[ResetAPIKey](https://github.com/ezhevita/ResetAPIKey)**, plugin pour ASF implémentant une commande pour réinitialiser la clé API pour les instances de bot sélectionnées.

### Autres

- **[ASFEnhance](https://github.com/chr233/ASFEnhance)**, plugin pour ASF l'améliorant avec de nouvelles fonctionnalités, en particulier des commandes.
- **[ASFFreeGames](https://github.com/maxisoft/ASFFreeGames)**, plugin pour ASF permettant de collecter automatiquement les jeux Steam gratuits postés sur reddit.

---

## Intégrations

- **[ASFBot](https://github.com/dmcallejo/ASFBot)**, bot télégramme écrit en python avec l’intégration de ASF.
- **[Script utilisateur ASF STM](https://greasyfork.org/en/scripts/404754-asf-stm)**, pour ceux qui veulent envoyer des offres d'échange automatisées aux bots sur notre liste **[ASF STM](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** via le navigateur Web, sans utiliser la fonction `MatchActively` fournie par ASF.
- **[un simple bot](https://github.com/deluxghost/simple-asf-bot)**, un autre bot télégramme (minimal) écrit en python avec intégration ASF.

---

## Bibliothèques

- **[ASF-IPC](https://github.com/deluxghost/ASF_IPC)**, bibliothèque python pour une meilleure intégration avec l'interface IPC d’ASF.

---

## Packaging

- **[>AUR repo #1](https://aur.archlinux.org/packages/asf)**, vous permet d’installer facilement ASF sur Arch Linux.
- **[>AUR repo #2](https://aur.archlinux.org/packages/archisteamfarm-bin)**, vous permet d’installer facilement ASF sur Arch Linux.
- **[Homebrew](https://formulae.brew.sh/formula/archi-steam-farm)**, vous permettant d'installer facilement ASF sur macOS.
- **[Nix](https://search.nixos.org/packages?channel=unstable&show=ArchiSteamFarm&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, vous permettant d'installer facilement ASF sur les distributions avec Nix.
- **[NixOS](https://search.nixos.org/options?channel=unstable&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, vous permettant de configurer et d'installer ASF avec NixOS.
- **[Scoop](https://scoop.sh/#/apps?q=ArchiSteamFarm)**, vous permettant d'installer facilement ASF sur fenêtres.
- **[Winget](https://github.com/microsoft/winget-pkgs/tree/master/manifests/j/JustArchiNET/ArchiSteamFarm)**, vous permettant d'installer facilement ASF sur les fenêtres.

---

## Outils

- **[CS2Script](https://github.com/Citrinate/CS2Script)**, vous permet de gérer vos unités de stockage Counter-Strike 2 à l'aide de **[CS2Interface](https://github.com/Citrinate/CS2Interface)** plugin.
- **[Keys extractor](https://umaim.github.io/SKE)**, permet de copier-coller les clés dans divers formats et créer la commande de `redeem` pour ASF. Vérifiez sur le **[GitHub repo](https://github.com/PixvIO/SKE)** pour plus de détails.
- **[ASF Mass Config Editor](https://github.com/genesix-eu/ASF_MCE)**, permet de gérer plusieurs configs ASF plus facilement.

---

## Vous voulez en savoir plus ?

Nous recommandons le thème **[ArchiSteamFarm](https://github.com/topics/archisteamfarm)** sur GitHub pour tous les projets qui s'intègrent à ASF. Gardez toutefois à l'esprit que sans lien avec les projets ASF peuvent également essayer d'utiliser le tag, Habituellement pour l'auto-promotion, il est donc toujours une bonne idée de vérifier à nouveau.