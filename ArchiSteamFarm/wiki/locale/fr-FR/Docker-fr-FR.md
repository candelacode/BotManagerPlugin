# Docker

ASF est disponible en **[docker container](https://www.docker.com/what-container)**. Nos paquets docker sont actuellement disponibles sur **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** ainsi que **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

It's important to note that running ASF in Docker container is considered **advanced setup**, which is **not needed** for vast majority of users, and typically gives **no advantages** over container-less setup. Si vous considérez Docker comme une solution pour exécuter ASF en tant que service, par exemple le faire démarrer automatiquement avec votre OS, alors vous devriez envisager de lire la section **[de gestion](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** à la place et de configurer un service `systemd` qui sera **presque toujours** une meilleure idée que d'exécuter ASF dans un conteneur Docker.

L'exécution d'ASF dans le conteneur Docker implique généralement **plusieurs nouveaux problèmes et problèmes** que vous devrez affronter et résoudre vous-même. This is why we **strongly** recommend you to avoid it unless you already have Docker knowledge and don't need help understanding its internals, about which we won't elaborate here on ASF wiki. Cette section est principalement destinée à des cas d'utilisation valides de configurations très complexes, par exemple en ce qui concerne le réseau avancé ou la sécurité au-delà du sandboxing standard fourni par ASF dans le service `systemd` (qui assure déjà une isolation supérieure des processus par des mécanismes de sécurité très avancés). Pour cette poignée de personnes, nous expliquons ici de meilleurs concepts ASF en ce qui concerne sa compatibilité Docker, et seulement cela, vous êtes supposé avoir les connaissances adéquates de Docker vous-même si vous décidez de l'utiliser avec ASF.

---

## Tags

ASF est disponible via plusieurs types de balises **[](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `principal`

Version générique d'ASF qui est construite à partir de la toute dernière livraison dans la branche `principale` , qui fonctionne de la même façon que de récupérer le dernier artefact directement de notre pipeline **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)**. Il s'agit du plus haut niveau de logiciels bogués dédiés aux développeurs et aux utilisateurs avancés à des fins de développement. L'image est en cours de mise à jour avec chaque commit dans la branche GitHub `principale` vous pouvez donc vous attendre à des changements très souvent (et des choses cassées). C'est ici pour marquer l'état actuel du projet ASF, qui n'est pas nécessairement garanti d'être stable ou testé, comme indiqué dans notre cycle de publication. **Ce tag ne doit être utilisé dans aucun environnement de production**. Utile pour la vérification si un commit particulier a résolu le problème que vous rencontrez, sans attendre même une pré-version avec cette livraison.


### `released`

Version générique d'ASF qui pointe toujours vers la dernière version **[publiée](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** version ASF, y compris les pré-versions. Comparé au tag `principal` , l'image est mise à jour chaque fois qu'une nouvelle balise GitHub est envoyée. Dédié aux utilisateurs avancés qui aiment vivre au bord de ce qui peut être considéré stable et frais en même temps. En pratique, il fonctionne comme un tag roulant pointant vers la version la plus récente de `A.B.C.D` au moment du tirage. Veuillez noter que l'utilisation de ce tag est égale à l'utilisation de nos pré-versions **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `stable`

Version générique d'ASF qui pointe toujours vers la dernière version **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF. Comparé à la balise `publiée` , l'image est mise à jour ici une fois que la nouvelle version stable d'ASF est disponible. Recommandé pour les personnes qui recherchent une variante stable de la balise `publiée` mentionnée ci-dessus.

### `latest`

La version spécifique à un système d'exploitation d'ASF qui pointe toujours vers la dernière version **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF. Par rapport aux autres, il s'agit de la balise **seulement** qui inclut les mises à jour automatiques ASF. L'objectif de cette balise est de fournir un conteneur Docker par défaut sain qui est capable d'exécuter une mise à jour automatique, une version spécifique à l'OS d'ASF. À cause de cela, l'image n'a pas besoin d'être mise à jour le plus souvent possible, comme version ASF incluse sera toujours capable de se mettre à jour si nécessaire.

Bien sûr, `UpdatePeriod` peut être éteint en toute sécurité (réglé sur `0`), mais dans ce cas, vous devriez probablement utiliser la version `stable` à la place. De même, vous pouvez modifier la valeur par défaut `UpdateChannel` afin de suivre les pré-versions si vous le souhaitez.

En raison du fait que l'image `la plus récente` est fournie avec la capacité de mise à jour automatique, il inclut un système d'exploitation nu avec une version ASF `linux` spécifique à l'OS, contrairement à tous les autres tags qui incluent OS avec . ET runtime et `version générique` ASF. En effet, une version ASF plus récente (mise à jour) pourrait également nécessiter une exécution plus récente que celle avec laquelle l'image pourrait être construite, qui, autrement, nécessiterait que l'image soit reconstruite à partir de zéro, annulant le cas d'utilisation prévu.

### `A.B.C.D`

Version générique d'ASF qui pointe vers la version ASF corrigée correspondant au tag. En comparaison avec les tags ci-dessus, cette balise est complètement gelée, ce qui signifie que l'image ici ne sera pas mise à jour une fois publiée. Cela fonctionne comme nos versions GitHub qui ne sont jamais touchées après la version initiale, ce qui vous garantit un environnement stable et gelé. Généralement, vous devriez utiliser ce tag lorsque vous voulez utiliser une version ASF spécifique et vous attendre à un résultat déterministe de la version (e. . gérant vous-même les versions d'ASF à la place).

---

## Quelle étiquette est la meilleure pour moi ?

Cela dépend de ce que vous recherchez. Pour la majorité des utilisateurs, la balise `dernière balise` devrait être la meilleure, car elle offre exactement ce que fait ASF de bureau, juste dans un conteneur Docker spécial en tant que service. Cependant, ce n'est pas nécessairement la façon dont docker doit être utilisé - normalement, vous êtes censé reconstruire vos conteneurs et ne pas les exécuter pour toujours, et dans ce cas, vous devriez considérer la balise `stable` ou `publiée` qui suit les directives de docker. Enfin, si vous voulez exécuter une version d'ASF corrigée à la place, alors les versions `A.B.C.D` sont naturellement ce que vous cherchez.

Nous décourageons généralement d'essayer les versions `principales` , car elles sont là pour que nous marquions l'état actuel du projet ASF. Rien ne garantit que cet État fonctionnera correctement, mais bien sûr, vous êtes plus que bienvenu pour leur donner un essai si le développement d'ASF vous intéresse.

---

## Architectures

L'image ASF docker est actuellement construite sur une plateforme `linux` ciblant 3 architectures - `x64`, `bras` et `arm64`. Vous pouvez en savoir plus sur eux dans la section Compatibilité **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**.

Nos tags utilisent un manifeste multi-plateforme, ce qui signifie que Docker installé sur votre ordinateur sélectionnera automatiquement l'image appropriée à votre plateforme lors de la récupération de l'image. Si par hasard vous souhaitez tirer une image spécifique de la plateforme qui ne correspond pas à celle que vous utilisez actuellement, vous pouvez faire cela grâce au commutateur `--platform` dans les commandes docker appropriées, telles que `docker exécuter`. Voir la documentation de docker sur **[manifeste d'image](https://docs.docker.com/registry/spec/manifest-v2-2)** pour plus d'informations.

---

## Utilisation

Pour une référence complète, vous devez utiliser la documentation officielle **[](https://docs.docker.com/engine/reference/commandline/docker)**, Nous ne couvrirons que l'utilisation de base de ce guide, vous êtes plus que bienvenu pour creuser plus en profondeur.

### Bonjour ASF!

Premièrement, nous devrions vérifier si notre docker fonctionne même correctement, cela servira de notre "monde de bonjour":

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm
```

`docker run` crée un nouveau conteneur de docker ASF pour vous et l'exécute au premier plan (`-it`). `--pull always` s'assure que l'image mise à jour sera tirée en premier, et `--rm` s'assure que notre conteneur sera purgé une fois arrêté, puisque nous ne faisons que tester si tout fonctionne bien pour le moment.

Si tout s'est terminé avec succès, après avoir tiré toutes les couches et le conteneur de départ, vous devez noter qu'ASF a bien démarré et nous a informé qu'il n'y a pas de bots définis, ce qui est bien - nous avons vérifié que ASF dans docker fonctionne correctement. Appuyez sur `CTRL+C` pour terminer le processus ASF et donc aussi le conteneur.

Si vous regardez la commande de plus près, vous remarquerez que nous ne déclarons aucun tag, par défaut à la version `la plus récente`. If you want to use other tag than `latest`, for example `released`, then you should declare it explicitly:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm:released
```

---

## Utiliser un volume

Si vous utilisez ASF dans le docker container, vous devez évidemment configurer le programme lui-même. Vous pouvez le faire de différentes manières, mais le plus recommandé serait de créer le répertoire ASF `config` sur la machine locale, puis le monter comme un volume partagé dans le conteneur de docker ASF.

Par exemple, nous supposerons que votre dossier de configuration ASF se trouve dans le répertoire `/home/archi/ASF/config`. Ce répertoire contient le noyau `ASF.json` ainsi que les bots que nous voulons exécuter. Maintenant, tout ce que nous avons à faire est simplement d'attacher ce répertoire en tant que volume partagé dans notre conteneur docker, où ASF attend son répertoire de configuration (`/app/config`).

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Et voilà, maintenant votre conteneur ASF docker utilisera le répertoire partagé avec votre machine locale en mode lecture-écriture. qui est tout ce dont vous avez besoin pour configurer ASF. De la même manière, vous pouvez monter d'autres volumes que vous souhaitez partager avec ASF, comme `/app/logs` ou `/app/plugins`.

Bien sûr, il ne s'agit là que d'une façon spécifique de réaliser ce que nous voulons, rien ne vous empêche par ex. créer votre propre fichier `Dockerfile` qui copiera vos fichiers de configuration dans le répertoire `/app/config` dans le conteneur ASF docker. Nous ne couvrons que l'utilisation de base de ce guide.

### Permissions de volume

ASF container by default is initialized with default `root` user, which allows it to handle the internal permissions stuff and then eventually switch to `asf` (UID `1000`) user for the remaining part of the main process. Alors que cela devrait être satisfaisant pour la grande majorité des utilisateurs, cela affecte le volume partagé car les fichiers nouvellement générés seront normalement détenus par l'utilisateur `asf` , qui peuvent ne pas être la situation désirée si vous voulez un autre utilisateur pour votre volume partagé.

Il y a deux façons de modifier l'utilisateur sous lequel ASF est en cours d'exécution. La première, recommandée, est de déclarer une variable d'environnement `ASF_UID` avec l'UID cible que vous voulez exécuter. Deuxièmement, l'alternative est de passer `--user` **[drapeau](https://docs.docker.com/engine/reference/run/#user)**, qui est directement supporté par docker.

Vous pouvez vérifier votre `uid` par exemple avec la commande `id -u` puis la déclarer comme indiqué ci-dessus. Par exemple, si votre utilisateur cible a `uid` de 1001 :

```shell
docker run -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm

# Alternativement, si vous comprenez les limitations ci-dessous
docker run -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

La différence entre le drapeau `ASF_UID` et `--user` est subtile, mais importante. `ASF_UID` est un mécanisme personnalisé pris en charge par ASF, dans ce conteneur de docker de scénario commence toujours comme `racine`, puis le script de démarrage ASF démarre le binaire principal sous `ASF_UID`. Lorsque vous utilisez le drapeau `--user` , vous démarrez tout le processus, y compris le script de démarrage ASF en tant qu'utilisateur donné. La première option permet au script de démarrage d'ASF de gérer automatiquement les autorisations et autres choses pour vous, en résolvant certains problèmes courants que vous pourriez avoir causés, par exemple, il s'assure que vos répertoires `/app` et `/asf` sont en fait la propriété de `ASF_UID`. Dans le deuxième scénario, puisque nous ne sommes pas en train de fonctionner en tant que `root`, Nous ne pouvons pas faire cela, et vous êtes censé gérer tout cela vous-même à l'avance.

Si vous avez décidé d'utiliser le drapeau `--user` , vous devez changer la propriété de tous les fichiers ASF de `1000` par défaut à votre nouvel utilisateur personnalisé. Vous pouvez le faire en exécutant la commande ci-dessous:

```shell
# Exécuter uniquement si vous n'utilisez pas ASF_UID
docker exec -u root asf_container_name chown -hR 1001 /app /asf
```

Cela ne doit être fait qu'une fois que vous avez créé votre conteneur avec `docker run`, et seulement si vous avez décidé d'utiliser un utilisateur personnalisé à travers `--user` docker. N'oubliez pas aussi de changer l'argument `1001` dans la commande ci-dessus pour le `UID` dont vous voulez réellement exécuter ASF.

### Volume avec SELinux

Si vous utilisez SELinux en état forcé sur votre OS, qui est par défaut sur les distributions basées sur RHEL, alors vous devriez monter le volume en ajoutant l'option `:Z` qui définira le contexte SELinux correct pour cela.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull always justarchi/archisteamfarm
```

Cela permettra à ASF de créer des fichiers ciblant le volume à l'intérieur du conteneur de docker.

---

## Synchronisation de plusieurs instances

ASF inclut la prise en charge de la synchronisation de plusieurs instances, comme indiqué dans la section **[de gestion](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)**. Lorsque vous exécutez ASF dans le docker container, vous pouvez optionnellement "opt-in" dans le processus, au cas où vous exécutez plusieurs conteneurs avec ASF et que vous souhaitez les synchroniser entre eux.

Par défaut, chaque ASF exécutant dans un conteneur docker est autonome, ce qui signifie qu’aucune synchronisation n’a lieu. Afin d'activer la synchronisation entre eux, vous devez lier le chemin `/tmp/ASF` dans chaque conteneur ASF que vous souhaitez synchroniser, , chemin partagé sur l'hôte de votre docker, en mode lecture-écriture. Ceci est réalisé exactement de la même manière que la liaison d'un volume qui a été décrit ci-dessus, avec des chemins différents :

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull always justarchi/archisteamfarm
# Et ainsi de suite, tous les conteneurs ASF sont maintenant synchronisés entre eux
```

Nous vous recommandons de lier le répertoire `/tmp/ASF` d'ASF à un répertoire temporaire `/tmp` sur votre machine, mais bien sûr, vous êtes libre de choisir tout autre qui satisfait votre utilisation. Chaque conteneur ASF qui est censé être synchronisé devrait avoir son répertoire `/tmp/ASF` partagé avec d'autres conteneurs qui participent au même processus de synchronisation.

Comme vous l'avez probablement deviné dans l'exemple ci-dessus, il est également possible de créer deux ou plusieurs "groupes de synchronisation", en liant différents chemins d'hôte docker à `/tmp/ASF`.

Le montage de `/tmp/ASF` est complètement facultatif et en fait déconseillé, à moins que vous ne vouliez explicitement synchroniser deux conteneurs ASF ou plus. Nous ne recommandons pas de monter `/tmp/ASF` pour une utilisation à un conteneur, car cela n'apporte absolument aucun avantage si vous vous attendez à n'exécuter qu'un seul conteneur ASF, et cela pourrait en fait causer des problèmes qui pourraient autrement être évités.

---

## Arguments de ligne de commande

ASF allows you to pass **[command-line arguments](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** in docker container through environment variables. Vous devez utiliser des variables d'environnement spécifiques pour les commutateurs pris en charge, et `ASF_ARGS` pour le reste. Ceci peut être réalisé avec le commutateur `-e` ajouté à `docker run`, par exemple :

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull always justarchi/archisteamfarm
```

Cela passera correctement votre argument `--cryptkey` au processus ASF en cours d'exécution dans le conteneur docker, ainsi que d'autres arguments. Bien sûr, si vous êtes un utilisateur avancé, vous pouvez également modifier `ENTRYPOINT` ou ajouter `CMD` et passer vos arguments personnalisés vous-même.

Sauf si vous voulez fournir une clé de chiffrement personnalisée ou d'autres options avancées, vous n'avez généralement pas besoin d'inclure de variables d'environnement spéciales, car nos conteneurs docker sont déjà configurés pour fonctionner avec une option par défaut sensée de `--no-restart`, pour que ce drapeau n'ait pas besoin d'être spécifié explicitement dans `ASF_ARGS`.

---

## IPC

En supposant que vous n'avez pas changé la valeur par défaut pour `IPC` **[propriété de configuration globale](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, elle est déjà activée. Cependant, vous devez faire deux choses supplémentaires pour que la CIP fonctionne dans Docker container. Firstly, you must use `IPCPassword` or modify default `KnownNetworks` in custom `IPC.config` to allow you to connect from the outside without using one. À moins que vous ne sachiez vraiment ce que vous faites, utilisez simplement `IPCPassword`. Deuxièmement, vous devez modifier l'adresse d'écoute par défaut de `localhost`, car docker ne peut pas acheminer hors du trafic vers l'interface de rebouclage. Un exemple de paramètre qui écoutera sur toutes les interfaces serait `http://*:1242`. Bien sûr, vous pouvez également utiliser des liaisons plus restrictives, telles que le réseau local ou le réseau VPN seulement, mais il doit être un itinéraire accessible depuis l'extérieur - `localhost` ne le fera pas, car l'itinéraire est entièrement dans la machine d'accueil.

Pour faire ce qui précède, vous devez utiliser la configuration personnalisée **[IPC personnalisée](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** comme celle ci-dessous:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Une fois que nous avons configuré IPC sur l'interface non-bouclage, nous devons indiquer à docker de cartographier le port `1242/tcp` d'ASF avec `-P` ou `-p`.

Par exemple, cette commande exposerait l'interface IPC d'ASF à la machine hôte (seulement) :

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull always justarchi/archisteamfarm
```

Si vous définissez tout correctement `docker exécuter la commande` ci-dessus rendra l'interface **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** fonctionnera depuis votre machine hôte, sur la norme `localhost:1242` route qui est maintenant correctement redirigée vers votre machine invitée. Il est également agréable de noter que nous n'exposons pas cette route plus loin, pour que la connexion ne puisse se faire que dans l'hôte docker, et donc la garder sécurisée. Bien sûr, vous pouvez exposer la route plus loin si vous savez ce que vous faites et assurer des mesures de sécurité appropriées.

---

### Exemple complet

Combinant toute la connaissance ci-dessus, un exemple de configuration complète ressemblerait à ceci :

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull always --restart unless-stopped justarchi/archisteamfarm
```

Cela suppose que vous utiliserez un seul conteneur ASF, avec tous les fichiers de configuration ASF dans `/home/archi/ASF/config`. Vous devriez modifier le chemin de configuration de celui qui correspond à votre machine. Il est également possible de fournir des plugins personnalisés pour ASF, que vous pouvez mettre dans `/home/archi/ASF/plugins`. Cette configuration est également prête pour l'utilisation optionnelle d'IPC si vous avez décidé d'inclure `IPC. onfig` dans votre répertoire de configuration avec un contenu comme ci-dessous:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Vous pouvez obtenir le même effet de la commande `docker exécuter` ci-dessus en utilisant la configuration `docker compose` suivante :

```yaml
version: "3. "
services :
  asf:
    image: justarchi/archisteamfarm
    container_name: asf
    redémarrage: unless-stopped
    ports:
      - "127. .0.1:1242:1242"
      - "[::1]:1242:1242"
    volumes:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

De choses autres que nous avons déjà discuté ci-dessus, nous avons ajouté `--restart unless-stopped` aux deux exemples ci-dessus afin de démarrer ce conteneur automatiquement après le redémarrage de votre machine. N’hésitez pas à le supprimer/modifier pour répondre à vos besoins.

---

## Conseils

Lorsque vous avez déjà votre conteneur ASF docker prêt, vous n'avez pas à utiliser `docker exécuter` à chaque fois. Vous pouvez facilement arrêter/démarrer ASF docker container avec `docker stop asf` et `docker start asf`. Gardez à l'esprit que si vous n'utilisez pas la balise `la dernière balise` alors utiliser ASF à jour demandera toujours de vous vers `docker stop`, `docker rm` et `docker exécuter` de nouveau. Cela est dû au fait que vous devez reconstruire votre conteneur à partir d'une nouvelle image ASF docker chaque fois que vous souhaitez utiliser la version ASF incluse dans cette image. In `latest` tag, ASF has included capability to auto-update itself, so rebuilding the image is not necessary for using up-to-date ASF (but it's still a good idea to do it from time to time in order to use fresh .NET runtime dependencies and the underlying OS, which might be needed when jumping across major ASF version updates).

Comme indiqué ci-dessus, ASF dans la balise autre que `dernière` ne se mettra pas automatiquement à jour elle-même, ce qui signifie que **vous** êtes en charge d'utiliser le dépôt `justarchi/archisteamfarm`. Cela présente de nombreux avantages, car l'application ne devrait pas toucher son propre code lors de son exécution, mais nous comprenons également la commodité qui vient de ne pas avoir à vous soucier de la version d'ASF dans votre docker container. Si vous vous souciez des bonnes pratiques et de l'utilisation adéquate de docker, Une balise `publiée` est ce que nous suggérons au lieu de la `dernière`, mais si vous ne pouvez pas vous ennuyer et que vous voulez juste que ASF fonctionne et se mette à jour automatiquement puis `dernière` le fera.

Vous devriez généralement exécuter ASF dans le docker conteneur avec `Headless: true` paramètre global. Cela dira clairement à ASF que vous n'êtes pas là pour fournir des détails manquants et qu'il ne devrait pas les demander. Bien sûr, pour la configuration initiale, vous devriez envisager de laisser cette option à `false` afin que vous puissiez facilement configurer les choses, mais à long terme, vous n'êtes généralement pas connecté à la console ASF, Il serait donc logique d'informer ASF de cela et d'utiliser `entrée` **[commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** si besoin est. De cette façon, ASF n’aura pas à attendre infiniment la saisie de l’utilisateur qui n’arrivera pas (et ne gaspillera pas de ressources tout en le faisant). Il permettra également à ASF de s'exécuter en mode non interactif à l'intérieur du conteneur, ce qui est crucial e.g. en ce qui concerne la transmission des signaux, ce qui permet à ASF de fermer gracieusement la requête `docker stop asf`.