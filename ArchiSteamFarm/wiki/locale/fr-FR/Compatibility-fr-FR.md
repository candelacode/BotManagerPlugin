# Compatibilité

ASF est une application C# qui fonctionne sur la plateforme .NET. Cela signifie que ASF n’est pas compilé directement en **[code machine](https://en.wikipedia.org/wiki/Machine_code)** qui s’exécute sur votre CPU, mais en **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)** qui nécessite un runtime compatible CIL pour l’exécuter.

Cette approche présente des avantages gigantesques, car CIL est indépendant de la plate-forme, c'est pourquoi ASF peut fonctionner nativement sur de nombreux systèmes d'exploitation disponibles, en particulier Windows, Linux et macOS. Il n'y a pas seulement d'émulation nécessaire, mais aussi de support pour toutes les optimisations liées à la plate-forme et au matériel, telles que les instructions du CPU SSE. Grâce à cela, ASF peut atteindre des performances et une optimisation supérieures, tout en offrant une compatibilité et une fiabilité parfaite.

Cela signifie également qu'ASF n'a ** aucune exigence spécifique du système d'exploitation </ 0>, car il nécessite de travailler sur ** runtime </ 0> sur ce système d'exploitation et non sur le système d'exploitation lui-même. Tant que ce runtime exécute correctement le code ASF, peu importe que le système d'exploitation sous-jacent soit Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii ou votre grille-pain - tant qu'il y a **[. ET pour ça](https://dotnet.microsoft.com/download/dotnet)**, il y a **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** pour elle (dans la variante `générique`).</p>

Cependant, quel que soit l'endroit où vous exécutez ASF, vous devez vous assurer que votre plateforme cible a les prérequis **[.NET](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installés. Ce sont des bibliothèques de bas niveau requises pour une fonctionnalité d’exécution correcte et absolument essentielles au bon fonctionnement d’ASF. Très probablement, vous pouvez en avoir certains (ou même tous) déjà installés.

---

## ASF packaging

ASF est disponible en 2 versions principales: package générique et système d'exploitation spécifique. En termes de fonctionnalité, les deux packages sont exactement les mêmes, ils sont également capables de se mettre à jour automatiquement. La seule différence entre eux est de savoir si le package ASF **generic** est également fourni avec un environnement d’exécution **spécifique au système d’exploitation**.

---

### Générique 

Le paquet générique est une construction indépendante de la plate-forme qui n'inclut aucun code spécifique à la machine. Cette installation nécessite que vous ayez .NET runtime déjà installé sur votre OS **dans la version** appropriée. Nous savons tous à quel point il est difficile de maintenir les dépendances à jour, donc ce paquet est ici principalement pour les personnes que **utilise déjà** . ET et ne souhaite pas dupliquer leur runtime uniquement pour ASF s'ils peuvent utiliser ce qu'ils ont déjà installé. Le package générique vous permet également d'exécuter ASF **n'importe où, à condition que vous puissiez obtenir une implémentation fonctionnelle de . ET runtime**, indépendamment du fait qu'il existe une version ASF spécifique à l'OS, ou non.

Il n'est pas recommandé d'utiliser une saveur générique si vous êtes un utilisateur occasionnel ou même avancé qui veut simplement faire fonctionner ASF et ne pas creuser dans . Détails techniques. En d'autres termes - si vous savez ce que c'est, vous pouvez l'utiliser, sinon il est préférable d'utiliser le paquet spécifique au système d'exploitation comme expliqué ci-dessous.

---

### OS-spécifique

Le package spécifique au système d'exploitation, outre le code géré inclus dans le package générique, inclut également du code natif pour une plate-forme donnée. En d'autres termes, le paquet spécifique à l'OS **inclut déjà correctement. ET runtime dans**, ce qui vous permet de sauter entièrement le désordre de l'installation et de lancer ASF directement. Comme vous pouvez le deviner, le paquet spécifique à un système d’exploitation est spécifique à chaque système d’exploitation. Par exemple, Windows requiert PE32 + pour `ArchiSteamFarm.exe` alors que Linux fonctionne avec Unix ELF</code> binaire pour `ArchiSteamFarm</0>. Comme vous le savez peut-être, ces deux types ne sont pas compatibles.</p>

<p spaces-before="0">ASF est actuellement disponible dans les variantes suivantes spécifiques au système d'exploitation:</p>

<ul>
<li><code>linux-arm` fonctionne sur les systèmes d'exploitation 32 bits basés sur ARM (ARMv7+) GNU/Linux avec glibc 2.35/musl 1.2.3 et plus récents. Cette variante couvre des plateformes telles que Raspberry Pi 2 (et plus récentes), elle ne fonctionnera **pas** avec les anciennes architectures ARM, comme ARMv6 trouvée dans Raspberry Pi 0 & 1, elle ne fonctionnera pas non plus avec les systèmes d’exploitation qui n’implémentent pas l’environnement GNU/Linux requis (comme Android).</li>
- `linux-arm64` fonctionne sur les systèmes GNU/Linux basés sur ARM 64 bits (ARMv8+) avec glibc 2.27/musl 1.2.3 et plus récents. Cette variante couvre des plateformes telles que Raspberry Pi 3 (et plus récentes), elle ne fonctionnera **pas** avec les systèmes d’exploitation 32 bits qui n’ont pas de bibliothèques 64 bits requises disponibles (comme le système d’exploitation Raspberry Pi 32 bits), elle ne fonctionnera pas non plus avec les systèmes d’exploitation qui n’implémentent pas l’environnement GNU/Linux requis (comme Android).
- `linux-x64` fonctionne sur des systèmes GNU/Linux 64 bits avec glibc 2.27/musl 1.2.3 et plus récents.
- `osx-arm64` fonctionne sur les OS macOS 64 bits basés sur ARM (Apple silicon) en version 13 et plus récente.
- `osx-x64` fonctionne sur les OS macOS 64 bits dans la version 15 et plus récente.
- `win-arm64` fonctionne sur les systèmes d'exploitation Windows **à jour** 64 bits basés sur ARMv8+ (ARMv8+) en version 10, 11 et plus récent.
- `win-x64` fonctionne sur **à jour** OS Windows 64 bits dans la version 10, 11, Server 2016+ et plus récente.</ul>

Bien sûr, même si vous n'avez pas de paquet spécifique au système d'exploitation disponible pour votre combinaison d'architecture d'exploitation, vous pouvez toujours installer le paquet approprié . ET exécutez vous-même et exécutez une saveur ASF générique, ce qui est également la principale raison pour laquelle elle existe en premier lieu. La version générique d'ASF est agnostique de la plate-forme et fonctionnera sur toute plate-forme ayant un runtime .NET fonctionnel. Ceci est important à noter - ASF nécessite .NET runtime, pas un OS ou une architecture spécifique. Par exemple, si vous utilisez Windows 32 bits alors malgré aucune version `dédiée` version ASF, vous pouvez quand même l'installer. ET SDK en `version win-x86` et exécutez ASF générique très bien. Nous ne pouvons simplement pas cibler toutes les combinaisons architecture-système existantes qui sont utilisées par quelqu'un, nous devons donc tracer une ligne quelque part. x86 est un bon exemple de cette ligne car son architecture est obsolète depuis au moins 2004.

Pour une liste complète de toutes les plates-formes et systèmes d'exploitation pris en charge par .NET 10.0, visitez **[notes de publication](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md)**.

---

## Exigences Runtime

Si vous utilisez des paquets spécifiques au système d'exploitation, vous n'avez pas besoin de vous soucier des exigences d'exécution car ASF est toujours livré avec l'exécutable requis et à jour qui fonctionnera correctement tant que vous avez **[. Les prérequis de ET](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** sont installés et à jour. En d'autres termes, **vous n'avez pas besoin d'installer. ET runtime ou SDK**, car les versions spécifiques à un système d'exploitation ne nécessitent que des dépendances natives (prérequis) et rien d'autre.

Cependant, si vous essayez d’exécuter un package ASF **générique** alors vous devez vous assurer que votre environnement d’exécution .NET prend en charge la plateforme requise par ASF.

ASF en tant que programme cible **.NET 10.0** (`net10.`) pour l'instant, mais il peut cibler une nouvelle plate-forme dans le futur. `net10.0` is supported since 10.0.100 SDK (10.0.0 runtime), although ASF might prefer **latest runtime at the moment of compilation**, so you should ensure that you have **[latest SDK](https://dotnet.microsoft.com/download)** (or at least runtime) available for your machine. La variante générique ASF peut refuser de se lancer si votre runtime est plus ancien que la version minimale spécifiée prise en charge pendant la compilation.

En cas de doute, vérifiez  ce que notre **[intégration continue utilise](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pour compiler et déployer les versions ASF sur GitHub. Vous pouvez trouver une sortie `dotnet --info` dans chaque build dans le cadre de l'étape de vérification du .NET.