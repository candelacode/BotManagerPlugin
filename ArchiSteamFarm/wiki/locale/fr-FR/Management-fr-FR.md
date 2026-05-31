# Gestion

Cette section couvre des sujets relatifs à la gestion optimale du processus ASF. Bien que ce ne soit pas strictement obligatoire pour l'utilisation, il comprend des conseils, des astuces et des bonnes pratiques que nous aimerions partager, en particulier pour les administrateurs système, les gens empaquetent ASF pour une utilisation dans des dépôts tiers, ainsi que pour les utilisateurs avancés comme pour les autres.

---

## Service `systemd` pour Linux

Dans les variantes `génériques` et `linux` , ASF est livré avec `ArchiSteamFarm@. Fichier de ervice` , qui est un fichier de configuration du service pour **[`systemd`](https://systemd.io)**. Si vous souhaitez exécuter ASF en tant que service, par exemple afin de le lancer automatiquement après le démarrage de votre machine, alors un bon service `systemd` est sans doute la meilleure façon de le faire, C'est pourquoi nous le recommandons fortement au lieu de le gérer seul par l'intermédiaire de `nohup`, `screen` ou autre.

Premièrement, créez le compte de l'utilisateur sous lequel vous voulez exécuter ASF, en supposant qu'il n'existe pas encore. We'll use `asf` user for this example, if you decided to use a different one, you'll need to substitute `asf` user in all of our examples below with your selected one. Notre service ne vous permet pas d'exécuter ASF en tant que `root`, car il est considéré comme une pratique **[mauvaise pratique](#never-run-asf-as-administrator)**.

```sh
su # ou sudo -i, pour entrer dans le shell
useradd -m asf # Créer un compte que vous avez l'intention d'exécuter ASF sous
```

Ensuite, décompressez ASF dans le dossier `/home/asf/ArchiSteamFarm`. The folder structure is important for our service unit, it should be `ArchiSteamFarm` folder in your `$HOME`, so `/home/<user>`. If you did everything correctly, there will be `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service` file existing. Si vous utilisez une variante `linux` et que vous n'avez pas décompressé le fichier sous Linux, mais par exemple utilisé le transfert de fichier depuis Windows, vous aurez également besoin de `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

Nous allons faire toutes les actions ci-dessous en tant que `racine`, donc aller à son shell avec `su` ou `sudo -i`.

Tout d'abord, c'est une bonne idée de s'assurer que notre dossier appartient toujours à notre utilisateur `asf` , `chown -hR asf:asf /home/asf/ArchiSteamFarm` exécuté une fois le fera. Les permissions peuvent être erronées, par exemple si vous avez téléchargé et/ou décompressé le fichier zip en tant que `racine`.

Deuxièmement, si vous utilisez une variante générique d'ASF, vous devez vous assurer que la commande `dotnet` est reconnue et dans l'un des emplacements standards : `/usr/local/bin`, `/usr/bin` ou `/bin`. Ceci est nécessaire pour notre service système qui exécute la commande `dotnet /path/to/ArchiSteamFarm.dll`. Vérifiez si `dotnet --info` fonctionne pour vous, si oui, tapez `commande -v dotnet` pour savoir où elle se trouve. Si vous avez utilisé l'installateur officiel, il devrait être dans `/usr/bin/dotnet` ou l'un des deux autres emplacements, qui est parfait. If it's in custom location such as `/usr/share/dotnet/dotnet`, create a **[symlink](https://wikipedia.org/wiki/Symbolic_link)** for it using `ln -s "$(command -v dotnet)" /usr/bin/dotnet`. Now `command -v dotnet` should report `/usr/bin/dotnet`, which will also make our systemd unit work. Si vous utilisez une variante spécifique à l'OS, vous n'avez pas besoin de faire quoi que ce soit à cet égard.

Ensuite, exécutez `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/systemd/system/ArchiSteamFarm\@. ervice`, cela créera un lien symbolique vers notre déclaration de service et l'enregistrera dans `systemd`. Le lien symbolique permettra à ASF de mettre à jour automatiquement votre unité `systemd` dans le cadre de la mise à jour ASF - selon votre situation, vous pouvez utiliser cette approche, ou simplement `cp` le fichier et le gérer vous-même comme vous le souhaitez.

Ensuite, assurez-vous que `systemd` reconnaisse notre service :

```
systemctl status ArchiSteamFarm@asf

<unk> ArchiSteamFarm@asf.service - ArchiSteamFarm Service (sur asf)
     Chargé : chargé (/etc/systemd/system/ArchiSteamFarm@. ervice; désactivé; préréglage du vendeur : activé)
     Active: inactive (mort)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Faites particulièrement attention à l'utilisateur que nous déclarons après `@`, c'est `asf` dans notre cas. Notre unité de service système attend de vous que vous déclariez l'utilisateur, car il influence la place exacte de la binaire `/home/<user>/ArchiSteamFarm`, ainsi que le système utilisateur actuel va faire apparaître le processus comme tel.

Si le système retournait une sortie similaire à ce qui précède, tout est dans l'ordre et nous avons presque terminé. Maintenant, il ne reste plus qu'à commencer notre service en tant qu'utilisateur choisi : `systemctl démarrez ArchiSteamFarm@asf`. Attendez une ou deux secondes, et vous pouvez vérifier à nouveau le statut :

```
Statut systemctl ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (sur asf)
     Chargé : chargé (/etc/systemd/system/ArchiSteamFarm@.service; désactivé; preset de vendeur: activé)
     Actif (actif) depuis (...)
       Docs : https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   PID principal : (...)
(...)
```

Si `systemd` déclare `actif (en cours d'exécution)`, cela signifie que tout s'est bien passé, et vous pouvez vérifier que le processus ASF doit être opérationnel et fonctionnel, par exemple avec `journalctl -r`, car ASF écrit par défaut également sur sa sortie console, qui est enregistré par `systemd`. Si vous êtes satisfait de la configuration que vous avez en ce moment, vous pouvez dire à `systemd` de démarrer automatiquement votre service au démarrage, en exécutant la commande `systemctl active ArchiSteamFarm@asf`. C'est tout.

Si par hasard vous souhaitez arrêter le processus, exécutez simplement `systemctl stop ArchiSteamFarm@asf`. De même, si vous voulez désactiver ASF d'être démarré automatiquement au démarrage, `systemctl désactiver ArchiSteamFarm@asf` le fera pour vous, c'est très simple.

Veuillez noter que, comme il n'y a aucune entrée standard activée pour notre service `systemd` vous ne serez pas en mesure de saisir vos détails à travers la console de manière habituelle. Passer à travers `systemd` équivaut à spécifier **[`Headless : true`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** paramètre et vient avec toutes ses implications. Heureusement pour vous, il est très facile de gérer votre ASF via **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, que nous vous recommandons au cas où vous auriez besoin de fournir des informations supplémentaires lors de la connexion ou de la gestion de votre processus ASF.

### Variables d'environnement

Il est possible de fournir des variables d'environnement supplémentaires à notre service `systemd` , que vous aimeriez faire dans le cas où vous vouliez par exemple utiliser un argument personnalisé `--cryptkey` **[en ligne de commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**, spécifiant donc la variable d'environnement `ASF_CRYPTKEY`.

Afin de fournir des variables d'environnement personnalisées, créez le dossier `/etc/asf` (au cas où il n'existerait pas), `mkdir -p /etc/asf`. Nous recommandons à `chown -hR root:root /etc/asf && chmod 700 /etc/asf` pour s'assurer que seul l'utilisateur `root` a accès à ces fichiers, parce qu'ils peuvent contenir des propriétés sensibles telles que `ASF_CRYPTKEY`. Ensuite, écrivez dans un fichier `/etc/asf/<user>` où `<user>` est l'utilisateur sous lequel vous utilisez le service (`asf` dans notre exemple ci-dessus, `/etc/asf/asf`).

Le fichier doit contenir toutes les variables d'environnement que vous souhaitez fournir au processus. Ceux qui n'ont pas de variable d'environnement dédiée, peuvent être déclarés dans `ASF_ARGS`:

```sh
# Déclarer seulement ceux dont vous avez réellement besoin de
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# Et tous ceux qui vous intéressent
```

### Remplacer une partie de l'unité de service

Grâce à la flexibilité de `systemd`, il est possible d'écraser une partie de l'unité ASF tout en préservant le fichier unitaire d'origine et en permettant à ASF de le mettre à jour par exemple dans le cadre des mises à jour automatiques.

Dans cet exemple, nous aimerions modifier le comportement unitaire ASF `systemd` d'ASF depuis un redémarrage uniquement en cas de succès, jusqu'à un redémarrage également en cas de plantages fataux. Pour cela, Nous remplacerons la propriété `Redémarrer` sous `[Service]` par défaut de `sur succès` à `toujours`. Simply execute `systemctl edit ArchiSteamFarm@asf`, naturally replacing `asf` with the target user of your service. Ensuite, ajoutez vos modifications comme indiqué par `systemd` dans la section appropriée :

```sh
### Édition du fichier /etc/systemd/system/ArchiSteamFarm@asf.service.d/override. onf
### Tout ce qui se trouve entre ici et le commentaire ci-dessous deviendra le nouveau contenu du fichier

[Service]
Restart=always

### Lignes ci-dessous ce commentaire sera supprimé

### /etc/systemd/system/ArchiSteamFarm@asf. ervice
# [Install]
# WantedBy=multi-user. arget
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm. ll --no-restart --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# Utilisateur=%i
# (...)
```

Et c'est ça, maintenant votre unité agit de la même façon que si elle n'avait que `Redémarrer = toujours` sous `[Service]`.

Bien sûr, l'alternative est de `cp` le fichier et de le gérer vous-même, mais cela vous permet de procéder à des modifications flexibles même si vous avez décidé de conserver l'unité ASF d'origine, par exemple avec un lien symbolique **[](https://wikipedia.org/wiki/Symbolic_link)**.

---

## Ne jamais exécuter ASF en tant qu'administrateur!

ASF inclut sa propre validation si le processus est exécuté en tant qu’administrateur (`root`) ou non. Running as `root` is **not** required for any kind of operation done by the ASF process, assuming properly configured environment it's operating in, and therefore should be regarded as a **bad practice**. This means that on Windows, ASF should **never** be executed with "run as administrator" setting, and on Unix ASF should have a **dedicated user account** for itself, or re-use your own in case of a desktop system.

Pour plus d'élaboration sur *pourquoi* nous décourageons l'exécution d'ASF en tant que `racine`, reportez-vous à **[superutilisateur](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** et à d'autres ressources. Si vous n'êtes toujours pas convaincu, vous demander ce qui arriverait à votre machine si le processus ASF exécutait la commande `rm -rf /*` juste après son lancement.

### Je m'exécute en tant que `racine` car ASF ne peut pas écrire dans ses fichiers

Cela signifie que vous avez des permissions mal configurées pour les fichiers auxquels ASF tente d'accès. Vous devez vous connecter en tant que compte `root` (soit avec `su` ou `sudo -i`) puis **corriger** les autorisations en émettant la commande `chown -hR asf:asf /path/to/ASF` , substituer `asf:asf` à l'utilisateur sous lequel vous exécuterez ASF, et `/chemin/vers/ASF` en conséquence. Si, par hasard, vous utilisez la commande personnalisée `--path` en disant à l'utilisateur ASF d'utiliser le répertoire différent, vous devriez exécuter à nouveau la même commande pour ce chemin.

Après avoir fait cela, vous ne devriez plus avoir de problème lié à ASF ne pouvant pas écrire sur ses propres fichiers, étant donné que vous venez de changer le propriétaire de tout ce qu'ASF s'intéresse à l'utilisateur, le processus ASF sera réellement exécuté.

### Je m'exécute en tant que `root` parce que je ne sais pas comment faire autrement

```sh
su # ou sudo -i, pour entrer dans le shell root
useradd -m asf # Créer un compte que vous avez l'intention de lancer ASF sous
chown -hR asf:asf /path/to/ASF # Assurez-vous que votre nouvel utilisateur a accès au répertoire ASF
su asf -c /path/to/ASF/ArchiSteamFarm # Ou sudo -u asf /path/to/ASF/ArchiamFarm, pour réellement démarrer le programme sous votre utilisateur
```

Cela serait le faire manuellement, il est beaucoup plus facile d'utiliser notre service **[`systemd`](#systemd-service-for-linux)** expliqué ci-dessus.

### Je sais mieux et je veux quand même tourner en tant que `root`

ASF ne vous empêche pas de le faire, affiche seulement un avertissement avec un court préavis. Ne soyez pas choqué si un jour à cause d'un bogue dans le programme, il fera exploser tout votre système d'exploitation avec une perte de données complète - vous avez été averti.

---

## Instances multiples

ASF est compatible avec l’exécution de plusieurs instances du processus sur la même machine. Les instances peuvent être complètement autonomes ou dérivées du même emplacement binaire (dans ce cas, dans ce cas, vous voulez les exécuter avec différents arguments `--path` **[en ligne de commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**).

Lorsque vous exécutez plusieurs instances à partir du même binaire, gardez à l'esprit que vous devriez généralement désactiver les mises à jour automatiques dans toutes leurs configurations, car il n'y a pas de synchronisation entre eux en ce qui concerne les mises à jour automatiques. Si vous souhaitez que les mises à jour automatiques soient activées, nous vous recommandons des instances autonomes, mais vous pouvez toujours faire fonctionner les mises à jour, à condition que vous puissiez vous assurer que toutes les autres instances ASF sont fermées.

ASF fera de son mieux pour maintenir un minimum de communication entre les processus et les autres instances ASF. Cela inclut la vérification d'ASF de son répertoire de configuration par rapport à d'autres instances, ainsi que le partage des limiteurs du cœur de l'ensemble du processus configurés avec `*LimiterDelay` **[propriétés de configuration globale](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, s'assurer que l'exécution de plusieurs instances ASF ne causera pas de problème de limitation de débit. En ce qui concerne les aspects techniques, toutes les plateformes utilisent notre mécanisme dédié de verrous personnalisés ASF basés sur des fichiers créés dans le répertoire temporaire, qui est `C:\Users\<YourUser>\AppData\Local\Temp\ASF` sous Windows, et `/tmp/ASF` sous Unix.

Il n'est pas nécessaire pour que les instances ASF exécutées partagent les mêmes propriétés `*LimiterDelay` , ils peuvent utiliser des valeurs différentes, car chaque ASF ajoutera son propre délai configuré au délai de publication après avoir acquis le verrou. Si la configuration `*LimiterDelay` est définie à `0`, L'instance ASF sautera entièrement en attente le verrou d'une ressource donnée qui est partagée avec d'autres instances (qui pourrait encore potentiellement maintenir un verrou partagé). Lorsque défini sur une autre valeur, ASF se synchronisera correctement avec d'autres instances ASF et attendra son tour, puis relâchez le verrou après un délai configuré, permettant à d'autres instances de continuer.

ASF prend en compte les paramètres `WebProxy` lors de la décision sur la portée partagée, ce qui signifie que deux instances ASF utilisant des configurations `WebProxy` différentes ne partageront pas leurs limiteurs. Ceci est implémenté afin de permettre à `WebProxy` de fonctionner sans délai excessif, comme prévu par différentes interfaces réseau. Cela devrait être assez bon pour la majorité des cas d'utilisation, cependant, si vous avez une configuration personnalisée spécifique dans laquelle vous êtes, p. ex. routage vous demande d'une manière différente, vous pouvez spécifier vous-même le groupe réseau via `--network-group` **[argument en ligne de commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**, qui vous permettra de déclarer le groupe ASF qui sera synchronisé avec cette instance. Gardez à l'esprit que les groupes de réseau personnalisés sont utilisés exclusivement, ce qui signifie qu'ASF n'utilisera plus `WebProxy` pour déterminer le bon groupe, comme vous êtes responsable du regroupement dans ce cas.

Si vous souhaitez utiliser notre service **[`système`](#systemd-service-for-linux)** expliqué ci-dessus pour de multiples instances ASF, C'est très simple, il suffit d'utiliser un autre utilisateur pour notre déclaration de service `ArchiSteamFarm@` et de suivre avec le reste des étapes. Cela équivaudra à exécuter plusieurs instances ASF avec des binaires distincts, de sorte qu’elles peuvent également se mettre à jour automatiquement et fonctionner indépendamment l’une de l’autre.