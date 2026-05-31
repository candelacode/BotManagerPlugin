# Partage familial Steam

ASF prend en charge le partage de famille Steam - l'ancien et le nouveau système. Afin de comprendre comment ASF fonctionne avec cela, vous devriez d'abord lire comment le partage de famille **[fonctionne](https://store.steampowered.com/promotion/familysharing)**, qui est disponible sur le magasin Steam. En plus de cela, vérifiez **[l'actualité](https://store.steampowered.com/news/app/593110/view/4149575031735702628)** pour le nouveau système de partage de famille Steam, avec lequel ASF est également compatible.

---

## ASF

La prise en charge de la fonctionnalité du partage familial dans ASF est transparente, ce qui signifie qu’elle ne présente aucune nouvelle propriété de configuration bot / process. Elle fonctionne immédiatement en tant que fonctionnalité intégrée supplémentaire.

ASF inclut une logique appropriée afin de s’assurer que la bibliothèque est verrouillée par les utilisateurs du partage familial. Par conséquent, elle ne les "coupera" pas de la session en raison du lancement d’une partie. ASF agira exactement de la même manière que le compte principal qui détient le verrou. Par conséquent, si ce verrou est détenu par votre client Steam ou par l’un de vos utilisateurs du partage familial, ASF ne tentera pas de créer une ferme, mais attendra que le verrou soit libre. Ceci est principalement lié à l'ancien système - le nouveau système permet à votre famille de partager des utilisateurs de jouer à des jeux autres que ceux qu'ASF est actuellement en train de fermer.

En plus de ce qui précède, après la connexion, ASF accèdera à vos systèmes de partage de famille (anciens et nouveaux), à partir de laquelle il extraire les utilisateurs (ID d'équipe) autorisés à utiliser votre bibliothèque. Ces utilisateurs reçoivent la permission `FamilySharing` d'utiliser les commandes **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, surtout leur permettre d'utiliser la commande `pause~` sur le compte de bot qui partage des jeux avec eux, qui permet de mettre en pause le module de farming automatique des cartes afin de lancer un jeu qui peut être partagé - cela s'applique aussi principalement à l'ancien système, mais peut toujours être utilisé avec le nouveau système au cas où ASF est actuellement un jeu de farming que vos utilisateurs veulent jouer.

Connecting both functionalities described above allows your friends to `pause~` your cards farming process, start a game, play as long as they wish, and then after they're done playing, cards farming process will be automatically resumed by ASF. Bien entendu, l'émission de ` pause ~` n'est pas nécessaire si ASF n'effectue actuellement aucune activité de farm active, car vos amis peuvent lancer le jeu immédiatement, et la logique décrite ci-dessus garantit qu'ils ne seront pas expulsés du serveur.

---

## Restriction

Le réseau Steam aime induire en erreur ASF en diffusant de fausses mises à jour de statut, ce qui pourrait conduire ASF à croire qu'il est bon de reprendre le processus et que, par conséquent, expulse votre ami trop tôt. C'est exactement le même problème que celui que nous avons déjà expliqué dans **[cette entrée de la FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. Nous recommandons exactement les mêmes solutions, principalement promouvoir vos amis à la permission `Opérateur` (ou supérieure) et leur disant de faire usage des commandes `pause` et `reprendre`.