# Communication à distance

Cette section détaille la communication à distance incluse dans ASF, y compris des explications sur la façon dont on peut l’influencer. Bien que nous ne considérions rien ci-dessous comme malveillant ou autrement indésirable, et ni l'un ni l'autre ne sont légalement obligés de le divulguer, Nous voulons que vous compreniez mieux les fonctionnalités du programme, en particulier en ce qui concerne votre vie privée et vos données partagées.

## Steam

ASF communique avec le réseau Steam (serveurs**[CM](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), ainsi que **[API Steam](https://steamcommunity.com/dev)**, **[Boutique Steam](https://store.steampowered.com)** et **[Communauté Steam](https://steamcommunity.com)**.

Il n'est pas possible de désactiver l'une des communications ci-dessus, car il s'agit de la base de base sur laquelle ASF est basé afin de fournir ses fonctionnalités de base. Vous devrez vous abstenir d’utiliser ASF si vous n’êtes pas à l’aise avec ce qui précède.

## Groupe Steam

ASF communique avec notre groupe Steam **[](https://steamcommunity.com/groups/archiasf)**. Le groupe vous fournit des annonces, en particulier de nouvelles versions, des problèmes critiques, des problèmes Steam et d'autres choses qui sont importantes pour garder la communauté à jour. Il vous permet également d’utiliser notre support technique en posant des questions, en résolvant des problèmes, en signalant des problèmes ou en suggérant des améliorations. Par défaut, les comptes utilisés dans ASF rejoindront automatiquement le groupe lors de la connexion.

Vous pouvez décider de ne pas rejoindre le groupe en désactivant le drapeau `SteamGroup` dans les paramètres **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** du bot.

## GitHub

ASF communique avec l'API **[de GitHub](https://api.github.com)** afin de récupérer **[ASF libère](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** pour la fonctionnalité de mise à jour. This is done as part of auto-updates (if you've kept **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** enabled), as well as `update` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Vous pouvez influencer la communication d'ASF avec GitHub via la propriété **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** - le paramétrage sur `Aucun` entraînera la désactivation de la fonctionnalité de mise à jour entière, y compris la communication GitHub à cet égard.

## Serveur ASF

ASF communique avec **[notre propre serveur](https://asf.justarchi.net)** pour des fonctionnalités plus avancées. En particulier, cela comprend :
- Vérification des sommes de contrôle des versions ASF téléchargées à partir de GitHub par rapport à notre propre base de données indépendante pour s'assurer que toutes les versions téléchargées sont légitimes (sans logiciels malveillants, Attaques MITM ou autres altérations)
- Récupération de la liste des mauvais bots pour le filtrage si vous avez gardé le paramètre global de configuration `FilterBadBots` activé.
- Annonce de votre bot dans **[notre liste](https://asf.justarchi.net/STM)** si vous avez activé `SteamTradeMatcher` dans **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** et que vous remplissez d'autres critères
- Télécharger les bots actuellement disponibles pour négocier à partir de **[notre liste](https://asf.justarchi.net/STM)** si vous avez activé `MatchActively` dans **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** et répondre à d'autres critères

À titre de mesure de sécurité, il n'est pas possible de désactiver la vérification de somme de contrôle pour les versions ASF. Cependant, vous pouvez désactiver entièrement les mises à jour automatiques si vous souhaitez éviter cela, comme décrit ci-dessus dans la section GitHub.

Vous pouvez désactiver le paramètre `FilterBadBots` si vous voulez éviter de récupérer la liste du serveur.

Vous pouvez décider de ne plus être annoncé dans la liste en désactivant le drapeau `PublicListing` dans les paramètres **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** du bot. This might be useful if you'd like to run `SteamTradeMatcher` bot without being announced at the same time.

Le téléchargement des bots de notre liste est obligatoire pour les paramètres `MatchActively` . Vous devrez désactiver ce paramètre si vous n'êtes pas disposé à accepter cela.