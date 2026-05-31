# Configuration à hautes performances

C’est exactement le contraire de  **[low-memory setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** et vous souhaitez généralement suivre ces conseils si vous souhaitez augmenter d'avantage les performances ASF (en termes de vitesse du processeur), pour un coût potentiel d’utilisation accrue de la mémoire.

---

ASF essaie déjà de privilégier les performances en matière de réglage équilibré général. Par conséquent, vous ne pouvez rien faire pour augmenter ses performances, même si vous n’êtes pas non plus complètement à court d’options. Cependant, gardez à l'esprit que ces options ne sont pas activées par défaut, ce qui signifie qu'elles ne sont pas suffisantes pour être considérées comme équilibrées pour la majorité des utilisations. Vous devez donc décider vous-même si l'augmentation de mémoire apportée par ses options est acceptable pour vous.

---

## Runtime tuning (avancé)

Les astuces **impliquent une augmentation importante de la mémoire** et doivent donc être utilisées avec prudence.

La façon recommandée d'appliquer ces paramètres est par le biais des propriétés d'environnement `DOTNET_`. Bien sûr, vous pouvez également utiliser d'autres méthodes, par exemple `runtimeconfig. fils`, mais certains paramètres sont impossible à définir de cette façon, et en plus de cela, ASF remplacera votre configuration d'exécution personnalisée `. fils` avec sa propre mise à jour lors de la prochaine mise à jour, nous vous recommandons donc de définir facilement les propriétés d'environnement avant de lancer le processus.

.NET runtime vous permet de régler **[le ramasse-miettes](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** de beaucoup de manières. affiner efficacement le processus GC en fonction de vos besoins. Nous avons documenté ci-dessous des propriétés qui sont particulièrement importantes à notre avis.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Configure si l'application utilise la collecte des déchets des stations de travail ou le ramassage des déchets du serveur.

Vous pouvez lire la spécificité exacte du serveur GC à **[fondamentaux de la collecte des déchets](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF utilise le garbage collection du poste de travail par défaut. Ceci est principalement dû au bon équilibre entre l'utilisation de la mémoire et les performances, ce qui est amplement suffisant pour seulement quelques robots, puisqu'un seul thread GC simultané en arrière-plan est suffisamment rapide pour gérer toute la mémoire allouée par ASF.

Cependant, nous disposons aujourd'hui de nombreux cœurs de processeur dont ASF peut grandement tirer parti, en disposant d'un thread GC dédié pour chaque vCore de processeur disponible. Cela peut considérablement améliorer les performances lors de tâches ASF lourdes telles que l'analyse des pages de badges ou de l'inventaire, car chaque processeur vCore peut aider, par opposition à 2 (principal et GC). Serveur GC est recommandé pour les machines avec 3 vCores de processeur et plus, workstation GC est automatiquement forcé si votre ordinateur ne dispose que d'un processeur vCore et si vous en avez exactement 2, vous pouvez envisager d'essayer les deux (les résultats peuvent varier).

Le serveur GC lui-même n'entraîne pas une très forte augmentation de la mémoire en étant simplement actif, mais il a des tailles de génération beaucoup plus grandes et est donc beaucoup plus paresseux lorsqu'il s'agit de restituer de la mémoire à un système d'exploitation. Vous pouvez vous trouver dans un endroit agréable où le serveur GC augmente les performances de manière significative et vous souhaitez continuer à l'utiliser, mais en même temps vous ne pouvez pas vous permettre cette énorme augmentation de mémoire qui sort de son utilisation. Heureusement pour vous, il y a un cadre "meilleur des deux mondes", en utilisant le GC du serveur avec **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** propriété de configuration définie à `0`, qui permettra toujours d'activer le GC du serveur, mais limitera les tailles de génération et concentrera davantage sur la mémoire. Alternativement, vous pouvez également expérimenter avec une autre propriété, **[`GCHeapHardLimitPourcent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**, ou même les deux en même temps.

Cependant, si la mémoire n'est pas un problème pour vous (car GC tient toujours compte de votre mémoire disponible et s'adapte lui-même), C'est une bien meilleure idée de ne pas changer ces propriétés du tout, en obtenant des performances supérieures dans le résultat.

---

Vous pouvez activer les propriétés sélectionnées en définissant les variables d'environnement appropriées. Par exemple, sur Linux (shell):

```shell
export DOTNET_gcServer=1

./ArchiSteamFarm # Pour la compilation spécifique à l'OS
./ArchiSteamFarm.sh # Pour la compilation générique
```

Ou sous Windows (powershell):

```powershell
$Env:DOTNET_gcServer=1

.\ArchiSteamFarm.exe # Pour une version spécifique à un système d'exploitation
.\ArchiSteamFarm.cmd # Pour une version générique
```

---

## Optimisation recommandée

- Assurez-vous que vous utilisez la valeur par défaut `OptimizationMode`, qui correspond à `MaxPerformance`. Il s'agit de loin du paramètre le plus important, car l'utilisation de la valeur `MinMemoryUsage` a des effets considérables sur les performances.
- Activer le serveur GC. Le serveur GC peut être immédiatement considéré comme étant actif par une augmentation significative de la mémoire par rapport au poste de travail GC. Cela fera apparaître un thread GC pour chaque thread CPU de votre machine afin d'effectuer des opérations GC en parallèle à la vitesse maximale.
- Si vous ne pouvez pas vous permettre d'augmenter la mémoire à cause du serveur GC, envisagez de modifier **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** et/ou **[`GCHeapHardLimitPourcent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** pour atteindre "le meilleur des deux mondes". Toutefois, si votre mémoire le permet, il est préférable de la conserver par défaut. Le serveur GC se peaufine déjà pendant l'exécution et est suffisamment intelligent pour utiliser moins de mémoire lorsque votre système d'exploitation en a réellement besoin.

L'application des recommandations ci-dessus vous permet d'avoir des performances ASF supérieures qui devraient être très rapides, même avec des centaines ou des milliers de robots activés. Le processeur ne devrait plus être un goulet d'étranglement, car ASF est en mesure d'utiliser toute la puissance de son processeur en cas de besoin, réduisant ainsi le temps requis au strict minimum. La prochaine étape serait la mise à jour du processeur et de la RAM, ou la répartition de la charge de travail entre plusieurs serveurs et des instances ASF.