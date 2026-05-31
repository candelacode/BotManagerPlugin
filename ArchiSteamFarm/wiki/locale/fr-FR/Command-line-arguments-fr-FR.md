# Arguments de ligne de commande

ASF prend en charge plusieurs arguments de ligne de commande qui peuvent affecter l'exécution du programme. Ils peuvent être utilisés par des utilisateurs avancés pour spécifier au programme son mode de fonctionnement. Par rapport au fichier de configuration `ASF.json` par défaut, les arguments de ligne de commande sont utilisés pour l'initialisation principale (e.g. `--path`). paramètres spécifiques à la plate-forme (e.g. `--system-required`) ou données sensibles (e.g. `--cryptkey`).

---

## Utilisation

Son utilisation dépend de votre OS et ASF.

Générique :

```shell
dotnet ArchiSteamFarm.dll --argument --otherOne
```

Windows :

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --otherOne
```

Les arguments de ligne de commande sont également pris en charge dans les scripts d'assistance génériques tels que ` ArchiSteamFarm.cmd </ 0> ou <code> ArchiSteamFarm.sh </ 0>. De plus, vous pouvez aussi utiliser la propriété d'environnement <code>ASF_ARGS` comme indiqué dans nos sections **[gestion](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** et **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)**.

Si votre argument contient des espaces, n'oubliez pas de le mettre entre guillemets. Ces deux exemples ne fonctionnent pas :

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Ne fonctionne pas !
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Ne fonctionne pas !
```

Mais ces deux exemples suivants sont parfaitement valides :

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Arguments

`--cryptkey <key>` ou `--cryptkey=<key>` - démarrera ASF avec une clé cryptographique personnalisée de la valeur `<key>`. Cette option affecte la **

 sécurité </ 0> et obligera ASF à utiliser votre clé `<key>` fournie à la place de la clé par défaut codée dans l'exécutable. Puisque cette propriété affecte la clé de chiffrement par défaut (pour le chiffrement) ainsi que son salt (pour le hachage), Gardez à l'esprit que tout ce qui est chiffré/haché avec cette clé nécessitera qu'elle soit transmise à chaque exécution d'ASF.</p> 

Il n'y a aucune exigence sur la longueur ou les caractères `<key>` mais pour des raisons de sécurité, nous vous recommandons de choisir un mot de passe suffisamment long à partir de e. . - 32 caractères aléatoires, par exemple en utilisant `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; commande echo` sur Linux.

Il est agréable de mentionner qu'il y a aussi deux autres façons de fournir ce détail : `--cryptkey-file` et `--input-cryptkey`.

En raison de la nature de cette propriété, il est également possible de définir la clé de chiffrement en déclarant la variable d'environnement `ASF_CRYPTKEY`, qui peut être plus appropriée pour les personnes qui voudraient éviter de divulguer des informations privées dans les arguments du processus.



---

`--cryptkey-file <path>` ou `--cryptkey-file=<path>` - démarrera ASF avec une clé cryptographique personnalisée lue à partir du fichier `<path>`. Cela sert le même but que `--cryptkey <key>` expliqué ci-dessus, seul le mécanisme diffère, comme cette propriété va lire `<key>` depuis `<path>` à la place. Si vous utilisez ceci avec `--path`, considère que le chemin relatif sera différent selon l'ordre des arguments, i. . que vous changiez `--path` avant ou après `--cryptkey-file`.

En raison de la nature de cette propriété, il est également possible de définir un fichier cryptkey en déclarant `ASF_CRYPTKEY_FILE` variable d'environnement, qui peut être plus approprié pour les personnes qui voudraient éviter des détails sensibles dans les arguments du processus.



---

`--ignore-unsupported-environment` - fera ignorer à ASF les problèmes liés à l'exécution dans un environnement non pris en charge, ce qui est normalement signalisé avec une erreur et une sortie forcée. L'environnement non pris en charge inclut par exemple l'exécution de la version `win-x64` propre à un système d'exploitation sur `linux-x64`. Même si ce flag laissera ASF s'exécuter dans de tels scénarios, soyez avertis; Nous ne prenons pas en charge ces éléments officiellement et vous forcez ASF à le faire entièrement **à vos risques et périls**. Il est important de souligner que **tous les** des scénarios d'environnement non pris en charge **peuvent être corrigés**. Nous recommandons fortement de résoudre les problèmes précédents plutôt que d'utiliser cet argument.



---

`--input-cryptkey` - demandera à ASF de se renseigner sur l' `--cryptkey` au démarrage. Cette option peut vous être utile si vous ne fournissez pas de cryptkey, que ce soit dans des variables d'environnement ou dans un fichier, vous préférez ne pas l'avoir enregistré où que ce soit et au lieu de le saisir manuellement à chaque exécution d'ASF.



---

`--minimized` - fera que la fenêtre de la console ASF sera réduite peu après le démarrage. Utile principalement dans les scénarios de démarrage automatique, mais peut également être utilisé en dehors de ceux-ci. Cette option nécessite une prise en charge appropriée de l'environnement - elle peut ne pas fonctionner correctement dans tous les scénarios possibles.



---

`--network-group <group>` ou `--network-group=<group>` - fera qu'ASF initera ses limiteurs avec une valeur réseau personnalisée de `<group>`. Cette option affecte l'exécution d'ASF dans **[plusieurs instances](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** en signalisant que l'instance donnée dépend uniquement des instances partageant le même groupe réseau, et indépendant du reste. Généralement, vous ne souhaitez utiliser cette propriété que si vous routez des requêtes ASF via un mécanisme personnalisé (par ex. différentes adresses IP) et vous voulez définir vous-même des groupes de réseaux, sans compter sur ASF pour le faire automatiquement (ce qui inclut actuellement la prise en compte de `WebProxy` seulement). Gardez à l'esprit que lorsque vous utilisez un groupe de réseau personnalisé, il s'agit d'un identifiant unique dans la machine locale, et ASF ne prendra pas en compte d'autres détails, tels que la valeur `WebProxy` , vous permettant d'e. . Démarre deux instances avec des valeurs `WebProxy` différentes qui sont toujours dépendantes l'une de l'autre.

En raison de la nature de cette propriété, il est également possible de définir la valeur en déclarant `ASF_NETWORK_GROUP` variable d'environnement, qui peut être plus approprié pour les personnes qui voudraient éviter des détails sensibles dans les arguments du processus.



---

`--no-config-migrate` - par défaut, ASF migrera automatiquement vos fichiers de configuration vers la dernière syntaxe. La migration inclut la conversion des propriétés obsolètes en dernières propriétés, supprimant les propriétés avec des valeurs par défaut (comme elles n'ont pas d'effet), ainsi que le nettoyage du fichier en général (correction de l'indentation et autres). C'est presque toujours une bonne idée, mais vous pourriez avoir une situation particulière où vous préféreriez qu'ASF n'écrase jamais automatiquement les fichiers de configuration. Par exemple, vous pouvez vouloir `chmod 400` vos fichiers de configuration (permission de lecture uniquement pour le propriétaire) ou mettre `chattr +i` sur eux, dans le résultat en refusant l'accès en écriture pour tout le monde, par exemple en tant que mesure de sécurité. Habituellement, nous recommandons de garder la migration de configuration activée, mais si vous avez une raison particulière de le désactiver et préférerait plutôt qu'ASF ne le fasse pas, vous pouvez utiliser cette option. Gardez toutefois à l’esprit que fournir des paramètres corrects à ASF deviendra désormais votre nouvelle responsabilité, en particulier en ce qui concerne les dépréciations et changements de propriétés dans les futures versions d'ASF.



---

`--no-config-watch` - ASF configure par défaut un `FileSystemWatcher` sur votre répertoire `config` afin d'écouter les événements liés aux changements de fichiers, pour qu'il puisse s'adapter interactivement à eux. Par exemple, cela inclut l'arrêt des bots lors de la suppression de la configuration, le redémarrage du bot à la modification de la configuration, ou chargement des clés dans `<1>BGR</1>` une fois que vous les retirez du répertoire <2>config</2>. Cette option vous permet de désactiver ce comportement, ce qui fera qu'ASF ignorera complètement tous les changements dans le répertoire `config`, exigeant de votre part de faire ces actions manuellement, si elles sont jugées appropriées (ce qui signifie généralement redémarrer le processus). Nous recommandons de garder les événements de configuration activés, mais si vous avez une raison particulière de les désactiver et préférerait plutôt qu'ASF ne le fasse pas, vous pouvez utiliser cette option pour atteindre cet objectif.



---

`--no-restart` - ASF suit par défaut **[`AutoRestart`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#autorestart)** propriété de configuration, que vous pouvez utiliser pour spécifier si le redémarrage est autorisé lorsque nécessaire. Certaines solutions que nous fournissons prennent en charge la gestion des processus et sont explicitement incompatibles avec la fonction de redémarrage automatique d'ASF, comme exécuter ASF dans `docker` ou `systemd`, car ils exigent que le processus se termine uniquement, car il est de leur responsabilité de le redémarrer par la suite, s'il est jugé approprié. Étant donné que l'édition de la configuration arbitraire n'est pas souhaitée de l'expérience de l'utilisateur, ce commutateur remplace simplement votre propriété de configuration `AutoRestart` en l'initialisant explicitement à `false`, même si vous avez spécifié autrement dans la configuration. Grâce à cela, ASF peut être informé à l'avance de son utilisation dans un tel environnement, sans obligation de fournir un fichier de configuration compatible `AutoRestart: false`.

En plus de ce qui précède, `--no-restart`, contrairement à `AutoRedémarrage : false`, vous interdira également d'utiliser la commande `redémarrer` ou de publier le processus ASF pour redémarrer, puisque le commutateur indique explicitement qu'il n'est pas compatible avec une telle configuration, alors que la propriété `AutoRestart` ne spécifie que le comportement par défaut.

Normalement, vous pouvez (et devriez) contrôler le comportement expliqué ici dans le fichier de configuration, bien que si vous exécutez ASF dans un script personnalisé ou un autre environnement similaire, vous pouvez également utiliser ce commutateur, qui empêchera ASF de redémarrer lui-même.



---

`--no-steam-parental-generation` - par défaut ASF essaiera automatiquement de générer des codes PIN parentaux Steam, comme décrit dans **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)**. Cependant, comme cela peut nécessiter une quantité excessive de ressources d'OS, cette option vous permet de désactiver ce comportement. ASF ignorera la génération automatique et demandera le PIN à l'utilisateur, ce qui ne se produirait normalement que si la génération automatique a échoué. Habituellement, nous recommandons de garder la génération activée, mais si vous avez une raison particulière de le désactiver et préférerait plutôt qu'ASF ne le fasse pas, vous pouvez utiliser cette option.



---

`--path <path>` ou `--path=<path>` - ASF navigue toujours vers son propre répertoire au démarrage. En spécifiant cet argument, ASF naviguera vers un répertoire donné après l’initialisation, ce qui vous permet d’utiliser un chemin personnalisé pour plusieurs parties de l'application (dont les répertoires `config`, <0>plugins</0>, et <0>www</0>, mais aussi le ficher <0>NLog.config</0>), sans avoir besoin de dupliquer le binaire au même endroit. Cela peut s'avérer particulièrement utile si vous souhaitez séparer le binaire de la configuration réelle, comme cela est fait dans un paquet de type Linux - de cette façon, vous pouvez utiliser un binaire (à jour) avec plusieurs configurations différentes. Le chemin peut être relatif en fonction de l'emplacement actuel du binaire ASF ou en absolu. N'oubliez pas que cette commande pointe vers le nouveau "ASF home" - le répertoire qui a la même structure que l'ASF d'origine, avec le répertoire `config` à l'intérieur.

En raison de la nature de cet propriété, il est aussi possible de définir le chemin attendu en déclarant la variable d'environnement `ASF_PATH`, ce qui peut être plus approprié pour les personnes voulant éviter des données sensibles dans les arguments du processus.

Si vous comptez utiliser cette commande pour exécuter plusieurs instances d'ASF, il est recommandé de lire la page traitant de la <0><1>Compatibilité</1></0>.

Exemples:



```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/DossierVoulu # Chemin absolu
dotnet /opt/ASF/ArchiSteamFarm.dll --path ../DossierVoulu # Les chemins relatifs fonctionnent aussi
ASF_PATH=/opt/DossierVoulu dotnet /opt/ASF/ArchiSteamFarm.dll # Pareil qu'avec les variables environnementales
```




```text
── 📁 /opt
── 📁 ASF
文─ ⚙️ ArchiSteamFarm.dll
文<unk> ─ ...
│     └── 📁 TargetDirectory
│           ├── 📁 config
│           ├── 📁 logs (généré)
│           ├── 📁 plugins (optionnel)
│           ├── 📁 www (optionnel)
│           ├── 📄 log.txt (généré)
│           └── 📄 NLog.config (optionnel)
└── ...
```




---

`--service` - ce commutateur est principalement utilisé par notre service `systemd` et force `Headless` à `true`. À moins que vous n'ayez un besoin particulier, il vaut mieux configurer la propriété `Headless` directement dans votre configuration. Ce commutateur est là pour que notre service `systemd` n'ait pas besoin de toucher à votre configuration globale pour l'adapter à son propre environnement. Bien sûr, si vous avez un besoin similaire, vous pouvez aussi utiliser cette option (sinon vous êtes mieux avec la configuration globale).



---

`--system-required</ 0> - la déclaration de ce commutateur incitera ASF à signaler au système d'exploitation que le processus nécessite que le système soit opérationnel pendant toute sa durée de vie. Cela peut être prouvé particulièrement utile lorsque vous fermez sur votre PC ou votre ordinateur portable pendant la nuit, car ASF sera en mesure de garder votre système éveillé pendant son exécution. Cette fonctionnalité est actuellement prise en charge sous Linux et Windows.</p>

<p spaces-before="0">Sous Linux, vous aurez besoin de fonctionner correctement avec la fonction <strong x-id="1"><a href="https://en.wikipedia.org/wiki/D-Bus">dbus</a></strong> avec le démon de connexion qui supporte <strong x-id="1"><a href="https://systemd.io/INHIBITOR_LOCKS/"><a href="https://systemd.io/INHIBITOR_LOCKS/"><code>Inhibit()`</a></strong>. Deux démons les plus populaires, `systemd` ainsi que `elogind`, sont confirmés pour le supporter. La majorité des environnements de bureau (comme Gnome ou KDE) devraient fonctionner sans problème car ils dépendent déjà de cette fonctionnalité pour leurs propres besoins.

Pas de conditions spéciales sur Windows, il devrait fonctionner par la suite.