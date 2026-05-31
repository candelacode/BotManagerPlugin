# IPC

ASF comprend sa propre interface IPC unique qui peut être utilisée pour une interaction ultérieure avec le processus. IPC signifie **[communication inter-processus](https://en.wikipedia.org/wiki/Inter-process_communication)** et dans la définition la plus simple il s'agit de "interface web ASF" basée sur **[serveur HTTP Kestrel](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel)** qui peut être utilisé pour une intégration ultérieure avec le processus, en tant que frontend pour l'utilisateur final (ASF-ui), et backend pour les intégrations de tiers (ASF API).

La CIP peut être utilisée pour beaucoup de choses différentes, en fonction de vos besoins et de vos compétences. Par exemple, vous pouvez l'utiliser pour récupérer le statut d'ASF et de tous les bots, envoyer des commandes ASF, récupérer et éditer les configurations globales/bot, ajout de nouveaux bots, suppression des bots existants, soumission de clés pour **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** ou accès au fichier journal d'ASF. Toutes ces actions sont exposées par notre API, ce qui signifie que vous pouvez coder vos propres outils et scripts qui seront en mesure de communiquer avec ASF et de l'influencer pendant l'exécution. En plus de cela, les actions sélectionnées (comme l'envoi de commandes) sont également implémentées par notre ASF-ui qui vous permet d'y accéder facilement via une interface web conviviale.

---

# Utilisation

Unless you manually disabled IPC through `IPC` **[global configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, it's enabled by default. ASF affichera le lancement de l’IPC dans son journal, que vous pouvez utiliser pour vérifier si l’interface IPC a bien démarré:

```text
INFO|ASF|Start() Démarrage du serveur IPC...
Le serveur IPC INFO|ASF|Start() est prêt !
```

Le serveur http d'ASF est maintenant en train d'écouter sur les points de terminaison sélectionnés. Si vous n'avez pas fourni de fichier de configuration personnalisé pour IPC, ce sera `localhost`, tous deux basés sur IPv4 **[127. .0.1](http://127.0.0.1:1242)** et **[[::1]](http://[::1]:1242)** sur le port par défaut `1242`. Vous pouvez accéder à notre interface IPC via les liens ci-dessus, mais uniquement à partir de la même machine que celle qui exécute le processus ASF.

L'interface IPC d'ASF expose trois façons différentes d'y accéder, selon votre utilisation prévue.

Au niveau le plus bas, il y a **[API ASF](#asf-api)** qui est le cœur de notre interface IPC et permet à tout le reste de fonctionner. C'est ce que vous souhaitez utiliser dans vos propres outils, utilitaires et projets afin de communiquer directement avec ASF.

Sur le terrain moyen, il y a notre documentation **[Swagger](#swagger-documentation)** qui agit comme une interface vers l’API ASF. Il contient une documentation complète de l’API ASF et vous permet également d’y accéder plus facilement. C'est ce que vous voulez vérifier si vous prévoyez d'écrire un outil, utilitaire ou d'autres projets censés communiquer avec ASF à travers son API.

Au plus haut niveau, il y a **[ASF-ui](#asf-ui)** qui est basé sur notre API ASF et fournit un moyen convivial d’exécuter diverses actions ASF. C’est notre interface IPC par défaut conçue pour les utilisateurs finaux, et un exemple parfait de ce que vous pouvez construire avec l’API ASF. Si vous le souhaitez, vous pouvez utiliser votre propre interface web personnalisée pour utiliser avec ASF, en spécifiant `--path` **[argument en ligne de commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** et en utilisant le répertoire personnalisé `www` qui s'y trouve.

---

# ASF-ui

ASF-ui est un projet communautaire qui vise à créer une interface web graphique conviviale pour ses utilisateurs. Pour y parvenir, il agit comme une interface vers notre API **[ASF](#asf-api)**, vous permettant de faire différentes actions en toute simplicité. C’est l’interface par défaut fournie par ASF.

Comme indiqué ci-dessus, ASF-ui est un projet communautaire qui n'est pas maintenu par les développeurs ASF de base. Il suit son propre flux dans le repo **[ASF-ui](https://github.com/JustArchiNET/ASF-ui)** qui doit être utilisé pour toutes les questions, problèmes, rapports de bogues et suggestions.

Vous pouvez utiliser ASF-ui pour la gestion générale du processus ASF. Il permet par exemple de gérer les bots, de modifier les paramètres, d'envoyer des commandes, et d'obtenir d'autres fonctionnalités normalement disponibles via ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# API ASF

Notre API ASF est typique **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** API web basée sur JSON comme format de données principal. Nous faisons de notre mieux pour décrire précisément la réponse, en utilisant les deux codes de statut HTTP (s'il y a lieu), ainsi qu'une réponse, vous pouvez analyser vous-même pour savoir si la requête a réussi, et si ce n'est pas le cas, pourquoi.

Notre API ASF est accessible en envoyant des demandes appropriées aux points de terminaison `/Api`. Vous pouvez utiliser ces points de terminaison de l'API pour créer vos propres scripts, outils, interfaces graphiques, etc. C'est exactement ce que notre ASF-ui obtient sous le capot, et tous les autres outils peuvent y arriver. L'API ASF est officiellement prise en charge et maintenue par l'équipe ASF de base.

Pour une documentation complète des points de terminaison disponibles, des descriptions, des requêtes, des réponses, des codes d'état http et tout le reste en tenant compte de l'API ASF, veuillez vous référer à notre documentation **[](#swagger-documentation)**.

![API ASF](https://github.com/user-attachments/assets/08c3d4ad-ea77-403d-a18a-b75c3d0a3097)


---

# Configuration personnalisée

Notre interface IPC prend en charge le fichier de configuration supplémentaire, `IPC.config` qui doit être placé dans le répertoire de configuration `` d'ASF standard.

Lorsqu'il est disponible, ce fichier spécifie une configuration avancée du serveur http Kestrel d'ASF, ainsi que d'autres réglages liés à l'IPC. Sauf si vous avez un besoin particulier, il n'y a aucune raison d'utiliser ce fichier, car ASF utilise déjà des valeurs par défaut raisonnables dans ce cas.

Le fichier de configuration est basé sur la structure JSON suivante :

```json
{
    "Kestrel": {
        "Endpoints": {
            "example-http4": {
                "Url": "http://127. 0.0. :1242"
            },
            "exemple-http6": {
                "Url": "http://[::1]:1242"
            },
            "exemple-https4": {
                "Url": "https://127. .0.1:1242",
                "Certificate": {
                    "Chemine": "/chemin/vers/certificate. fx",
                    "Mot de passe": "passwordToPfxFileAbove"
                }
            },
            "exemple-https6": {
                "Url": "https://[::1]:1242",
                "Certificate": {
                    "Path": "/path/to/certificate. fx",
                    "Mot de passe": "passwordToPfxFileAbove"
                }
            }
        },
        "KnownNetworks": [
            "10. .0.0/8",
            "172.16.0. /12",
            "192.168.0. /16"
        ],
        "Base de chemin": "/"
    }
}
```

`Points de terminaison` - Il s'agit d'une collection de points d'extrémité, chaque point de terminaison ayant son propre nom unique (comme `example-http4`) et `Url` qui spécifie `Protocol://Host:Port` adresse d'écoute. Par défaut, ASF écoute sur les adresses IPv4 et IPv6, mais nous avons ajouté des exemples https à utiliser, si nécessaire. Vous ne devez déclarer que les terminaux dont vous avez besoin, nous avons inclus 4 exemples ci-dessus pour que vous puissiez les modifier plus facilement.

`Hôte` accepte soit `localhost`, une adresse IP fixe de l'interface sur laquelle il doit écouter (IPv4/IPv6), ou `*` valeur qui lie le serveur http d'ASF à toutes les interfaces disponibles. Utilisation d'autres valeurs comme `mondomain.com` ou `192.168.0.` agit de la même manière que `*`, il n'y a pas de filtrage IP implémenté, donc soyez extrêmement prudent lorsque vous utilisez les valeurs `Host` qui permettent l'accès à distance. Cela permettra d'accéder à l'interface IPC d'ASF à partir d'autres machines, ce qui peut poser un risque de sécurité. Nous recommandons fortement d'utiliser `IPCPassword` (et de préférence votre propre pare-feu aussi) **à un minimum** dans ce cas.

`KnownNetworks` - Cette variable **facultative** spécifie les adresses réseau que nous considérons comme fiables. Par défaut, ASF est configuré pour faire confiance à l'interface loopback (`localhost`, même machine) **seulement**. Cette propriété est utilisée de deux façons. Firstly, if you omit `IPCPassword`, then we'll allow only machines from known networks to access ASF's API, and deny everybody else as a security measure. Deuxièmement, ce bien est crucial en ce qui concerne l'accès à ASF aux mandataires inversés car ASF n'honorera ses en-têtes que si le serveur mandataire inversé se trouve dans les réseaux connus. Honorer les en-têtes est crucial en ce qui concerne le mécanisme anti-bruteforce d'ASF, au lieu d'interdire le reverse proxy en cas de problème. il va bannir l'adresse IP spécifiée par le reverse proxy comme source du message original. Soyez extrêmement prudent avec les réseaux que vous spécifiez ici, car il permet une attaque potentielle contre l'usurpation de l'IP et un accès non autorisé au cas où la machine de confiance serait compromise ou mal configurée.

`PathBase` - Ceci est **optionnel** chemin de base qui sera utilisé par l'interface IPC. La valeur par défaut est `/` et ne devrait pas être requise pour modifier pour la majorité des cas d'utilisation. En changeant cette propriété, vous hébergerez l'interface IPC entière sur un préfixe personnalisé, par exemple `http://localhost:1242/MyPrefix` au lieu de `http://localhost:1242` seule. L'utilisation personnalisée de `PathBase` peut être recherchée en combinaison avec la configuration spécifique d'un proxy inverse où vous souhaitez uniquement proproxier une URL spécifique, par exemple `mondomaine. om/ASF` au lieu de tout le domaine `mondomaine.com`. Normally that would require from you to write a rewrite rule for your web server that would map `mydomain.com/ASF/Api/X` -> `localhost:1242/Api/X`, but instead you can define a custom `PathBase` of `/ASF` and achieve easier setup of `mydomain.com/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

À moins que vous n'ayez vraiment besoin de spécifier un chemin de base personnalisé, il est préférable de le laisser par défaut.

## Exemple de configuration

### Modification du port par défaut

La configuration suivante change simplement le port d'écoute ASF par défaut de `1242` à `1337`. Vous pouvez choisir le port que vous voulez, mais nous vous recommandons la plage `1024-32767` , car les autres ports sont typiquement **[enregistré](https://en.wikipedia.org/wiki/Registered_port)**, et peut par exemple nécessiter un accès `root` sur Linux.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP4": {
                "Url": "http://127. 0.0. :1337"
            },
            "HTTP6": {
                "Url": "http://[::1]:1337"
            }
        }
    }

```

---

### Activation de l'accès à partir de toutes les adresses IP

La configuration suivante autorisera l'accès à distance de toutes les sources, Par conséquent, vous devez **vous assurer que vous avez lu et compris notre avis de sécurité à propos de**, disponible ci-dessus.

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

Si vous n'avez pas besoin d'accéder à partir de toutes les sources, mais par exemple votre LAN uniquement, alors il est préférable de vérifier l'adresse IP locale de la machine hébergeant ASF, par exemple `192. 68.0.10` et utilisez-la au lieu de `*` dans l'exemple de configuration ci-dessus. Malheureusement, ce n'est possible que si votre adresse LAN est toujours la même, sinon vous aurez probablement des résultats plus satisfaisants avec `*` et votre propre pare-feu en plus de cela permettant uniquement aux sous-réseaux locaux d'accéder au port ASF.

---

# Authentification

L'interface IPC ASF par défaut ne nécessite aucune sorte d'authentification, car `IPCPassword` est réglé sur `null`. Cependant, si `IPCPassword` est activé en étant défini sur n'importe quelle valeur non vide, chaque appel à l'API ASF nécessite le mot de passe qui correspond au paramètre `IPCPassword`. Si vous omettez l'authentification ou le mauvais mot de passe en entrée, vous obtiendrez une erreur `401 -` non autorisée. Après 5 tentatives d'authentification échouées (mauvais mot de passe), vous serez temporairement bloqué avec `403 - Erreur` interdite.

L'authentification peut se faire de deux manières distinctes.

## En-tête `Authentification`

En général, vous devez utiliser les en-têtes de requête HTTP **[](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)**, en définissant le champ `Authentification` avec votre mot de passe comme valeur. La façon de le faire dépend de l'outil que vous utilisez pour accéder à l'interface IPC d'ASF, par exemple si vous utilisez `curl` alors vous devez ajouter `-H 'Authentification: MyPassword'` comme paramètre. De cette façon, l'authentification est transmise dans les en-têtes de la requête, où elle devrait avoir lieu.

## Paramètre `mot de passe` dans la chaîne de requête

Vous pouvez également ajouter le paramètre `mot de passe` à la fin de l'URL que vous êtes sur le point d'appeler, par exemple en appelant `/Api/ASF ? assword=MyPassword` au lieu de `/Api/ASF` seule. Cette approche est suffisamment bonne, mais elle expose évidemment le mot de passe à l'ouverture, ce qui n'est pas nécessairement toujours approprié. En plus de cela, c'est un argument supplémentaire dans la chaîne de requête, qui complique l’apparence de l’URL et lui donne l’impression que son URL est spécifique, tandis que le mot de passe s’applique à toute la communication de l’API ASF.

---

Les deux moyens sont supportés et c'est à vous de choisir celui que vous voulez choisir. Nous vous recommandons d'utiliser des en-têtes HTTP partout où vous le pouvez, car dans le sens de l'utilisation, c'est plus approprié que la chaîne de requêtes. Cependant, nous supportons également la chaîne de requête, principalement en raison de diverses limitations liées aux en-têtes de requête. Un bon exemple inclut le manque d'en-têtes personnalisés lors du lancement d'une connexion websocket en javascript (même si elle est entièrement valide selon la RFC). Dans ce cas, la chaîne de requête est la seule façon de s'authentifier.

---

# Documentation du Swagger

Notre interface IPC, en additon à l’API ASF et ASF-ui inclut également de la documentation swagger, qui est disponible sous `/swagger` **[URL](http://localhost:1242/swagger)**. La documentation Swagger sert d'intermédiaire entre notre implémentation de l'API et d'autres outils qui l'utilisent (par exemple ASF-ui). Il fournit une documentation complète et une disponibilité de tous les points de terminaison de l'API dans les spécifications **[OpenAPI](https://swagger.io/resources/open-api)** qui peuvent être facilement consommées par d'autres projets, vous permettant d'écrire et de tester l'API ASF en toute simplicité.

Outre l'utilisation de notre documentation swagger comme spécification complète de l'API ASF, vous pouvez également l'utiliser comme une façon conviviale d'exécuter différents points de terminaison de l'API, principalement ceux qui ne sont pas implémentés par ASF-ui. Puisque notre documentation swagger est générée automatiquement à partir du code ASF, vous avez la garantie que la documentation sera toujours à jour avec les terminaux API inclus dans votre version d'ASF.

![Documentation du Swagger](https://github.com/user-attachments/assets/ce998e08-f5db-46b0-a9e8-e6b69abd94bb)


---

# FAQ

### L'interface IPC d'ASF est-elle sécurisée et sécurisée à utiliser ?

ASF par défaut n'écoute que sur les adresses `localhost` , ce qui signifie qu'accéder à ASF IPC depuis n'importe quelle autre machine mais que votre propre **est impossible**. À moins que vous ne modifiiez les points de terminaison par défaut, l'attaquant aurait besoin d'un accès direct à votre propre machine pour accéder à l'IPC d'ASF, est donc aussi sûr qu'il peut être et il n'y a aucune possibilité que quelqu'un d'autre y accède, même à partir de votre propre LAN.

Cependant, si vous décidez de changer les adresses par défaut `localhost` lier à quelque chose d'autre, alors vous êtes censé définir des règles de pare-feu correctes **vous-même** afin d'autoriser uniquement les adresses IP autorisées à accéder à l'interface IPC d'ASF. In addition to doing that, you will need to set up `IPCPassword`, as ASF will refuse to let other machines access ASF API without one, which adds another layer of extra security. Vous pouvez également utiliser l'interface IPC d'ASF derrière un mandataire inversé dans ce cas, ce qui est expliqué ci-dessous.

### Puis-je accéder à l’API ASF via mes propres outils ou scripts d’utilisateur?

Oui, c’est pour cela que l’API ASF a été conçue et vous pouvez utiliser tout ce qui est en mesure d’envoyer une requête HTTP pour y accéder. Les scripts utilisateurs locaux suivent la logique **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** et nous autorisons l'accès à partir de toutes les origines pour eux (`*`), aussi longtemps que `IPCPassword` est défini, comme une mesure de sécurité supplémentaire. Cela vous permet d'exécuter diverses demandes d'API ASF authentifiées, sans permettre aux scripts potentiellement malveillants de le faire automatiquement (comme ils auraient besoin de connaître votre `IPCPassword` pour le faire).

### Puis-je accéder à distance à l'IPC d'ASF, par exemple depuis une autre machine ?

Oui, nous vous recommandons d'utiliser un proxy inverse pour cela. De cette façon, vous pouvez accéder à votre serveur web de manière typique, ce qui vous permettra d'accéder à l'IPC d'ASF sur la même machine. Alternativement, si vous ne voulez pas exécuter avec un proxy inverse, vous pouvez utiliser la configuration personnalisée **[](#enabling-access-from-all-ips)** avec l'URL appropriée pour cela. Par exemple, si votre machine est dans un VPN avec une adresse `10.8.0.1` , vous pouvez définir `http://10.8.0. :1242` URL d'écoute dans la configuration IPC, ce qui permettrait l'accès IPC à partir de votre VPN privé, mais pas de nulle part ailleurs.

### Puis-je utiliser l'IPC d'ASF derrière un proxy inverse comme Apache ou Nginx ?

**Oui**, notre IPC est entièrement compatible avec une telle configuration, afin que vous soyez libre de l'héberger aussi devant vos propres outils pour une sécurité et une compatibilité supplémentaires, si vous le souhaitez. En général, le serveur Kestrel http d'ASF est très sécurisé et ne comporte aucun risque lorsque vous êtes connecté directement à Internet, mais le mettre derrière un mandataire inversé comme Apache ou Nginx pourrait fournir des fonctionnalités supplémentaires qui ne seraient pas possibles à atteindre autrement, comme sécuriser l'interface d'ASF avec une authentification de base **[](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Un exemple de configuration Nginx peut être trouvé ci-dessous. Nous avons inclus le bloc complet `du serveur` , bien que vous soyez principalement intéressé par les blocs `emplacement`. Veuillez vous référer à la documentation **[nginx](https://nginx.org/en/docs)** si vous avez besoin de plus d'explications.

```nginx
serveur {
    écouter *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /path/to/votre/fullchain. em;
    ssl_certificate_key /chemin/vers/votre/clé privée. Em;

    emplacement ~* /Api/NLog {
        proxy_pass http://127.0.0. :1242;

        # Seulement si vous avez besoin de remplacer l'hôte par défaut
# proxy_set_header Host 127. 0.0. ;

        # Les entêtes X doivent toujours être spécifiées lors de la requête de proxy vers ASF
        # Elles sont cruciales pour l'identification correcte de l'IP d'origine, autoriser ASF à p. ex. bannir les contrevenants réels au lieu de votre serveur nginx
        # Les spécifier permet à ASF de résoudre correctement les adresses IP des utilisateurs qui font des demandes - faire fonctionner nginx en tant que mandataire inversé
        # Ne pas les spécifier fera traiter votre nginx comme le client - nginx agira comme un mandataire traditionnel dans ce cas
        # Si vous ne pouvez pas héberger le service nginx sur la même machine que ASF, vous voulez très probablement définir KnownNetworks de manière appropriée en plus de ces
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;

        # Nous ajoutons ces 3 options supplémentaires pour les websockets proxying, voir https://nginx. rg/fr/docs/http/websocket.html
        proxy_http_version 1. ;
        proxy_set_header Connexion "Upgrade";
        proxy_set_header Mise à jour $http_upgrade;
    }

    emplacement / {
        proxy_pass http://127. 0.0. :1242;

        # Seulement si vous avez besoin de remplacer l'hôte par défaut
# proxy_set_header Host 127. 0.0. ;

        # entêtes X devraient toujours être spécifiés lors de la requête de proxy vers ASF
        # Elles sont cruciales pour l'identification correcte de l'IP d'origine, autoriser ASF à p. ex. bannir les contrevenants réels au lieu de votre serveur nginx
        # Les spécifier permet à ASF de résoudre correctement les adresses IP des utilisateurs qui font des demandes - faire fonctionner nginx en tant que mandataire inversé
        # Ne pas les spécifier fera traiter ASF comme le client - nginx agira comme un mandataire traditionnel dans ce cas
        # Si vous ne pouvez pas héberger le service nginx sur la même machine que ASF, vous voulez très probablement définir KnownNetworks de manière appropriée, en plus de ces
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
    }
}
```

Vous trouverez ci-dessous un exemple de configuration d'Apache. Veuillez vous référer à la documentation **[apache](https://httpd.apache.org/docs)** si vous avez besoin de plus d'explications.

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerName asf.mydomain. om

        SSLEngine sur
        SSLCertificateFile /chemin/vers/votre/fullchain. em
        SSLCertificateKeyFile /chemin/vers/votre/clé privée. em

        # TODO : Apache ne peut pas faire de correspondance insensible à la casse, donc nous codons en dur deux cas les plus couramment utilisés
        ProxyPass "/api/nlog" "ws://127. 0.0. :1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0. :1242/Api/NLog"

        ProxyPass "/" "http://127.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### Puis-je accéder à l'interface IPC via le protocole HTTPS ?

**Yes**, you can achieve it through two different ways. Une façon recommandée serait d'utiliser un proxy inversé pour cela, où vous pouvez accéder à votre serveur web via https comme d'habitude, et se connecter à l'aide de l'interface IPC d'ASF sur la même machine. De cette façon, votre trafic est entièrement chiffré et vous n'avez pas besoin de modifier l'IPC de quelque manière que ce soit pour supporter une telle configuration.

Second way includes specifying a **[custom config](#custom-configuration)** for ASF's IPC interface where you can enable https endpoint and provide appropriate certificate directly to our Kestrel http server. Cette méthode est recommandée si vous n'utilisez aucun autre serveur web et que vous ne voulez pas en exécuter un exclusivement pour ASF. Sinon, il est beaucoup plus facile de réaliser une configuration satisfaisante en utilisant un mécanisme de proxy inverse.

---

### Lors du démarrage de l'IPC, je reçois une erreur: `System.IO. OException : Impossible de se lier à l'adresse, une tentative a été faite pour accéder à un socket d'une manière interdite par ses permissions d'accès`

Cette erreur indique que quelque chose d'autre sur votre machine utilise déjà ce port, ou l'a réservé pour une utilisation ultérieure. Cela pourrait être vous si vous essayez d'exécuter une seconde instance ASF sur la même machine, mais le plus souvent c'est Windows qui exclut le port `1242` de votre utilisation, vous devrez donc déplacer ASF vers un autre port. Pour cela, suivez l'exemple **[config](#changing-default-port)** ci-dessus, et essayez simplement de choisir un autre port, comme `12420`.

Bien sûr, vous pouvez également essayer de savoir ce qui bloque le port `1242` de l'utilisation d'ASF, et supprimer cela, mais c'est généralement bien plus difficile que de simplement demander à ASF d'utiliser un autre port, nous allons donc passer à approfondir ce sujet ici.

---

### Pourquoi est-ce que j'obtiens une erreur `403 Interdite` lorsque je n'utilise pas `IPCPassword`?

ASF inclut des mesures de sécurité supplémentaires qui, par défaut, n'autorisent que l'interface de bouclage (`localhost`, votre propre machine) pour accéder à l’API ASF sans `IPCPassword` défini dans la configuration. Ceci est dû au fait que l’utilisation de `IPCPassword` devrait être une mesure de sécurité **minimum** définie par tous ceux qui décident de soumettre l’interface ASF plus avant.

Le changement a été dicté par le fait qu'une quantité massive d'ASF hébergés dans le monde entier par des utilisateurs non conscients ont été repris pour des intentions malveillantes, en laissant généralement des personnes sans compte et sans objet sur elles. Maintenant, nous pourrions dire "ils pourraient lire cette page avant d'ouvrir ASF dans le monde entier", mais au lieu de cela, il est plus logique de ne pas autoriser les configurations ASF non sécurisées par défaut, et demander aux utilisateurs une action s'ils veulent explicitement l'autoriser, ce que nous détaillons ci-dessous.

En particulier, vous pouvez outrepasser notre décision en spécifiant les réseaux auxquels vous avez confiance pour atteindre ASF sans `IPCPassword` spécifié, vous pouvez les définir dans la propriété `KnownNetworks` dans la configuration personnalisée. Cependant, sauf si vous **vraiment** savez ce que vous faites et comprenez pleinement les risques, vous devriez plutôt utiliser `IPCPassword` comme déclarant `KnownNetworks` permettra à tout le monde de ces réseaux d'accéder sans condition à l’API ASF. Nous sommes sérieux, les gens étaient déjà en train de se tirer dans le pied en croyant que leurs mandataires inversés et les règles iptables étaient sécurisés, mais ils l'étaient, `IPCPassword` est le premier et parfois le dernier tuteur, Si vous décidez de vous retirer de ce mécanisme simple, mais très efficace et sécurisé, vous n'aurez que vous-même à blâmer.