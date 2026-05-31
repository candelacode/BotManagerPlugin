# Développement de plugins

ASF inclut le support des plugins personnalisés qui peuvent être chargés pendant l'exécution. Les plugins vous permettent de personnaliser le comportement ASF, par exemple en ajoutant des commandes personnalisées, une logique de trading personnalisée ou une intégration entière avec des services et des API tiers.

Cette page décrit les plugins ASF du point de vue des développeurs - créer, maintenir, publier et similaire. If you want to view user's perspective, move **[here](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** instead.

---

## Configuration minimale

Les plugins sont des bibliothèques .NET standard qui définissent une classe héritant de l'interface commune `IPlugin` déclarée dans ASF. Vous pouvez développer des plugins entièrement indépendamment d'ASF principal et les réutiliser dans les versions ASF actuelles et futures, tant que l'API interne ASF reste compatible. Le système de plugins utilisé dans ASF est basé sur le `Système. omposition`, anciennement connu sous le nom de **[Managed Extensibility Framework](https://docs.microsoft.com/dotnet/framework/mef)** qui permet à ASF de découvrir et de charger vos bibliothèques pendant l'exécution.

---

### Mise en route

Nous avons préparé **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate)** pour vous, que vous pouvez (et devriez) utiliser comme base pour votre projet de plugin. L'utilisation du modèle n'est **pas obligatoire** (comme vous pouvez tout faire à partir de zéro), mais nous vous recommandons fortement de le ramasser car il peut radicalement démarrer votre développement et réduire le temps nécessaire pour que tout se passe bien. Consultez simplement le **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** du modèle et il vous guidera plus loin. Quoi qu'il en soit, nous couvrirons les bases ci-dessous au cas où vous vouliez partir de zéro, ou apprenez à mieux comprendre les concepts utilisés dans le modèle de plugin - vous n'avez généralement pas besoin de faire tout cela si vous avez décidé d'utiliser notre modèle de plugin.

Votre projet devrait être une norme . La bibliothèque de ET ciblant le cadre approprié de votre version ASF cible, comme indiqué dans la section **[compilation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation)**.

Le projet doit référencer l'assemblage principal `ArchiSteamFarm`, soit son précompilé `ArchiSteamFarm. ll` bibliothèque que vous avez téléchargée dans le cadre de la version, ou le projet source (par exemple, si vous avez décidé d'ajouter une arborescence ASF en tant que sous-module). Cela vous permettra d'accéder et de découvrir les structures, méthodes et propriétés ASF, en particulier l'interface principale `IPlugin` dont vous aurez besoin d'hériter à l'étape suivante. Le projet doit également faire référence à `System.Composition.AttributedModel` au minimum, ce qui vous permet de `[Export]` votre `IPlugin` pour qu'ASF puisse utiliser. En plus de cela, vous pouvez vouloir/avoir besoin de référencer d'autres bibliothèques communes pour interpréter les structures de données qui vous sont données dans certaines interfaces, mais à moins que vous n'en ayez besoin explicitement, cela suffira pour l'instant.

Si vous avez tout fait correctement, votre `csproj` sera similaire à ce qui suit :

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <! - Puisque vous chargez le plugin dans le processus ASF, qui inclut déjà ces dépendances, IncludeAssets="compile" vous permet de les omettre de la sortie finale -->
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" IncludeAssets="compile" Version="10.0.0" /><PackageReference Include="Microsoft.AspNetCore.OpenApi" IncludeAssets="compile" Version="10.0.0" />
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="10.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="C:\\Path\To\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" />

    <! - Si vous construisez avec le binaire DLL téléchargé, utilisez ceci au lieu de <ProjectReference> ci-dessus -->
    <! - <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" /> -->
  </ItemGroup>
</Project>
```

Du côté du code, votre classe de plugin doit hériter de l'interface `IPlugin` (soit explicitement, soit implicitement en héritant d'une interface plus spécialisée, comme `IASF`) et `[Export(typeof(IPlugin))]` afin d'être reconnu par ASF pendant l'exécution. L'exemple le plus simple qui puisse être atteint serait le suivant:

```csharp
en utilisant Système;
en utilisant System.Composition;
en utilisant System.Threading.Tasks;
en utilisant ArchiSteamFarm;
en utilisant ArchiSteamFarm.Plugins;

espace de noms YourNamespace. ourPluginName;

[Export(typeof(IPlugin))]
classe publique scellée VotrePluginName : IPlugin {
	chaîne publique Name => nameof(VotrePluginName);
	version publique Version => typeof(VotrePluginName). ssembly.GetName().Version;

	tâche publique OnLoaded() {
		ASF.ArchiLogger.LogGenericInfo("Hello World!");

		retour Task.CompletedTask;
	}
}
```

Pour pouvoir utiliser votre plugin, vous devez d'abord le compiler. Vous pouvez le faire soit à partir de votre IDE, soit à partir du répertoire racine de votre projet via une commande :

```shell
# Si votre projet est autonome (pas besoin de définir son nom car c'est le seul)
dotnet publish -c "Release" -o "out"

# Si votre projet fait partie de la source ASF (pour éviter de compiler des parties inutiles)
dotnet publish NomDeTonPlugin -c "Release" -o "out"
```

Ensuite, votre plugin est prêt pour le déploiement. C'est à vous de savoir comment exactement vous voulez distribuer et publier votre plugin, mais nous vous recommandons de créer une archive zip où vous mettrez votre plugin compilé avec son **[dependencies](#plugin-dependencies)**. De cette façon, l'utilisateur devra simplement décompresser votre archive zip dans un sous-répertoire autonome dans son répertoire `plugins` et ne rien faire d'autre.

Ce n'est que le scénario le plus basique pour commencer. Nous avons un projet **[`ExamplePlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** qui vous montre des exemples d'interfaces et d'actions que vous pouvez faire dans votre propre plugin, y compris des commentaires utiles. N'hésitez pas à jeter un coup d'oeil si vous souhaitez apprendre à partir d'un code de travail, ou découvrir `ArchiSteamFarm. lugins` espace de noms vous-même et reportez-vous à la documentation incluse pour toutes les options disponibles. Nous allons également nous pencher sur certains concepts fondamentaux ci-dessous pour mieux les expliquer.

Si au lieu d'exemples de plugin que vous vouliez apprendre à partir de projets réels, il y a plusieurs plugins officiels développés par nous, par ex. **[`ItemsMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.ItemsMatcher)**, **[`MobileAuthenticator`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.MobileAuthenticator)** ou **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)**. En plus de cela, il y a aussi des plugins développés par d'autres développeurs, dans notre section **[third-party](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)**.

---

### Disponibilité de l'API

ASF, en dehors de ce à quoi vous avez accès dans les interfaces elles-mêmes, vous expose beaucoup de ses API internes que vous pouvez utiliser, afin d'étendre la fonctionnalité. Par exemple, si vous souhaitez envoyer une sorte de nouvelle requête sur le web Steam, vous n'avez pas besoin d'implémenter tout à partir de zéro, en particulier en ce qui concerne tous les problèmes que nous avons dû traiter avant vous. Utilisez simplement notre `Bot. rchiWebHandler` qui expose déjà beaucoup de méthodes `UrlWithSession()` que vous pouvez utiliser, gérer toutes les choses de niveau inférieur telles que l'authentification, l'actualisation de session ou la limitation du web pour vous. De même, pour envoyer des requêtes web en dehors de la plate-forme Steam, vous pouvez utiliser la classe standard .NET `HttpClient`, mais c'est bien mieux l'idée d'utiliser `Bot. rchiWebHandler.WebBrowser` qui est disponible pour vous, ce qui vous offre une fois de plus une main utile, par exemple en ce qui concerne la répétition des requêtes échouées.

Nous avons une politique très ouverte en termes de disponibilité de notre API, si vous souhaitez utiliser quelque chose que le code ASF contient déjà, il vous suffit de **[ouvrir un problème](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** et de lui expliquer votre cas d'utilisation prévu de l'API interne de notre ASF. Nous n'aurons probablement rien contre tant que votre cas d'utilisation aura un sens. Cela inclut également toutes les suggestions concernant les nouvelles interfaces `IPlugin` qui pourraient avoir un sens à ajouter afin d'étendre les fonctionnalités existantes.

Indépendamment de la disponibilité de l’API ASF, rien ne vous empêche par exemple, y compris `Discord. et` bibliothèque dans votre application et création d'un pont entre vos commandes Discord bot et ASF, car votre plugin peut aussi avoir des dépendances par lui-même. Les possibilités sont infinies, et nous avons fait de notre mieux pour vous donner autant de liberté et de flexibilité que possible dans votre plugin, donc il n'y a pas de limites artificielles sur quoi que ce soit - votre plugin est chargé dans le processus ASF principal et peut faire tout ce qui est réalistement possible à partir du code C#.

---

### Compatibilité de l'API

Il est important de souligner qu'ASF est une application consommateur et non une bibliothèque typique avec une surface d'API fixe dont vous pouvez dépendre sans condition. Cela signifie que vous ne pouvez pas supposer que votre plugin une fois compilé continuera à fonctionner avec toutes les versions futures d'ASF, quoi qu'il en soit, c'est tout simplement impossible si nous voulons continuer à développer le programme, et ne pas être en mesure de s'adapter aux changements de Steam toujours en cours pour des raisons de compatibilité ascendante n'est tout simplement pas approprié pour notre cas. Cela devrait être logique pour vous, mais il est important de le souligner.

Nous ferons de notre mieux pour que les parties publiques d'ASF fonctionnent et soient stables, mais nous n'aurons pas peur de rompre la compatibilité si de bonnes raisons surviennent, en suivant notre politique de **[deprecation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation)** dans le processus. Ceci est particulièrement important en ce qui concerne les structures internes ASF qui vous sont exposées dans le cadre de l'infrastructure ASF (par ex. `ArchiWebHandler`) qui pourrait être amélioré (et donc réécrit) dans le cadre des améliorations d'ASF dans l'une des versions futures. Nous ferons de notre mieux pour vous informer de façon appropriée dans les changelogs, et inclure les avertissements appropriés pendant l'exécution sur les fonctionnalités obsolètes. Nous n'avons pas l'intention de tout réécrire pour le réécrire, donc vous pouvez être assez sûr que la prochaine version mineure d'ASF ne se contentera pas de détruire votre plugin uniquement parce qu'elle a un numéro de version plus élevé, mais garder un œil sur les changelogs et la vérification occasionnelle si tout fonctionne bien est une très bonne idée.

---

### Dépendances de votre plugin

Votre plugin inclura au moins deux dépendances par défaut, la référence `ArchiSteamFarm` pour l'API interne (`IPlugin` au minimum), et `PackageReference` de `System. omposition.AttributedModel` qui est nécessaire pour être reconnu comme plugin ASF pour commencer par (clause `[Export]`). En plus de cela, il peut inclure plus de dépendances par rapport à ce que vous avez décidé de faire dans votre plugin (e. . La bibliothèque `Discord.Net` si vous avez décidé d'intégrer avec Discord).

La sortie de votre build inclura votre bibliothèque principale `YourPluginName.dll` ainsi que toutes les dépendances que vous avez référencées. Puisque vous développez un plugin vers un programme déjà fonctionnel, vous n'avez pas à le faire, et même **ne devrait pas** inclure les dépendances qu'ASF inclut déjà, par exemple `ArchiSteamFarm`, `SteamKit2` ou `AngleSharp`. Retirer vos dépendances de compilation partagées avec ASF n'est pas la condition absolue pour que votre plugin fonctionne, mais cela réduira considérablement l'empreinte mémoire et la taille de votre plugin, ainsi que l'augmentation des performances, car ASF partagera ses propres dépendances avec vous, et ne chargera que les bibliothèques qu'il ne connaît pas.

En général, il est recommandé d’inclure uniquement les bibliothèques qu’ASF n’inclut pas, ou inclut dans la version incorrecte/incompatible. Des exemples seraient évidemment `YourPluginName.dll`, mais par exemple `Discord.Net.dll` si vous décidez d'en dépendre, car ASF ne l'inclut pas lui-même. Les bibliothèques groupées qui sont partagées avec ASF peuvent toujours avoir un sens si vous voulez assurer la compatibilité avec l'API (e.g. étant sûr que `AngleSharp` dont vous dépendez dans votre plugin sera toujours dans la version `X` et non celle avec laquelle ASF est livré), mais faire cela vient évidemment pour un prix de la mémoire/taille accrue et des performances moins élevées, et donc devrait être évalué avec soin.

Si vous savez que la dépendance dont vous avez besoin est incluse dans ASF, vous pouvez le marquer avec `IncludeAssets="compile"` comme nous vous l'avons montré dans l'exemple `csproj` ci-dessus. Cela dira au compilateur d'éviter de publier la bibliothèque référencée elle-même, car ASF inclut déjà celle-ci. De même, Notez que nous référençons le projet ASF avec `ExcludeAssets="all" Private="false"` qui fonctionne de manière très similaire - en disant au compilateur de ne pas produire de fichiers ASF (comme l'utilisateur les a déjà). Cela s'applique uniquement lorsque vous faites référence au projet ASF, car si vous faites référence à une bibliothèque `dll`, vous ne produisez pas de fichiers ASF dans le cadre de votre plugin.

Si vous êtes confus à propos de l'instruction ci-dessus et que vous ne savez pas mieux, vérifiez quelles bibliothèques `dll` sont incluses dans `ASF-generic. ip` paquet et assurez-vous que votre plugin n'inclut que ceux qui n'en font pas encore partie. Ce ne sera que `YourPluginName.dll` pour les plugins les plus simples. Si vous rencontrez des problèmes durant l'exécution de certaines bibliothèques, incluez également les bibliothèques concernées. Si tout le reste échoue, vous pouvez toujours décider de tout regrouper.

---

### Dépendances natives

Les dépendances natives sont générées dans le cadre de versions spécifiques à l'OS, car il n'y a pas de dépendances . ET runtime disponible sur l'hôte et ASF fonctionne sur son propre runtime .NET qui est fourni dans le cadre d'une compilation spécifique au système d'exploitation. Afin de minimiser la taille de la version, ASF coupe ses dépendances natives pour n'inclure que le code qui peut être atteint dans le programme, qui coupe efficacement les parties inutilisées de l'exécution. Cela peut créer un problème potentiel pour vous en ce qui concerne votre plugin, si soudainement vous vous rendez compte dans une situation où votre plugin dépend de certains . La fonctionnalité ET qui n'est pas utilisée dans ASF, et donc les versions spécifiques à l'OS ne peuvent pas l'exécuter correctement, généralement en lançant `System.MissingMethodException` ou `System.Reflection.ReflectionTypeLoadException` dans le processus. Au fur et à mesure que votre plugin prend de la taille et devient de plus en plus complexe, tôt ou tard, vous toucherez la surface qui n'est pas couverte par notre version spécifique à l'OS.

Ce n'est jamais un problème avec les compilations génériques, parce que ces derniers ne traitent jamais avec les dépendances natives en premier lieu (comme ils ont une exécution complète sur l'hôte, en exécutant ASF). C'est pourquoi il est recommandé d'utiliser **votre plugin dans des versions génériques exclusivement**, mais cela a évidemment son propre inconvénient de couper votre plugin aux utilisateurs qui exécutent des versions spécifiques à l'OS d'ASF. Si vous vous demandez si votre problème est lié aux dépendances natives, vous pouvez également utiliser cette méthode pour la vérification, charger votre plugin dans la version générique d'ASF et voir si cela fonctionne. Si c'est le cas, vous avez des dépendances de plugin couvertes et ce sont les dépendances natives qui causent des problèmes.

Malheureusement, nous avons dû faire un choix difficile entre la publication de l'intégralité de l'exécution, dans le cadre de nos versions spécifiques au système d'exploitation, et décidant de le couper à partir de fonctionnalités inutilisées, rendant la compilation de plus de 80 Mo plus petite que la version complète. Nous avons choisi la deuxième option, et il est malheureusement impossible pour vous d'inclure les fonctionnalités d'exécution manquantes avec votre plugin. Si votre projet nécessite un accès aux fonctionnalités d'exécution qui sont exclues, vous devez inclure intégralement . ET runtime sur lequel vous comptez, et cela signifie que vous exécutez votre plugin dans la saveur ASF `generic`. Vous ne pouvez pas exécuter votre plugin dans des versions spécifiques à votre système d'exploitation, car il manque simplement une fonctionnalité d'exécution dont vous avez besoin, et . ET runtime à partir de maintenant est incapable de « fusionner » les dépendances natives que vous pourriez avoir fournies avec la nôtre. Peut-être cela améliorera un jour dans le futur, mais à partir de maintenant, ce n'est tout simplement pas possible.

Les versions spécifiques à l'OS d'ASF incluent le strict minimum de fonctionnalités supplémentaires qui sont nécessaires pour exécuter nos plugins officiels. Outre que cela soit possible, cela étend également légèrement la surface à des dépendances supplémentaires requises pour les plugins les plus basiques. Par conséquent, tous les plugins ne devront pas s'inquiéter des dépendances natives pour commencer par - seulement celles qui vont au-delà de ce dont ASF et nos plugins officiels ont besoin directement. Cela est fait en tant que supplément, car si nous avons besoin d'inclure nous-mêmes des dépendances natives supplémentaires pour nos propres cas d'utilisation de toute façon, Nous pouvons également les expédier directement avec ASF, en les rendant disponibles et donc plus facile à couvrir, aussi pour vous. Malheureusement, ce n'est pas toujours suffisant, et comme votre plugin devient de plus en plus complexe, la probabilité de rencontrer des fonctionnalités réduites augmente. Par conséquent, nous vous recommandons généralement d'exécuter vos plugins personnalisés dans la saveur ASF `generic` exclusivement. Vous pouvez toujours vérifier manuellement que la version d'ASF spécifique à votre système d'exploitation dispose de tout ce dont votre plugin a besoin pour sa fonctionnalité - mais puisque cela change de vos mises à jour ainsi que la nôtre, il peut être difficile de maintenir.

Parfois, il peut être possible de « contourner » les fonctionnalités manquantes en utilisant des options alternatives ou en les réimplémentant dans votre plugin. Ce n'est cependant pas toujours possible ou viable, surtout si la fonctionnalité manquante provient de dépendances tierces que vous incluez dans votre plugin. Vous pouvez toujours essayer d'exécuter votre plugin dans une version spécifique à votre système d'exploitation et essayer de le faire fonctionner mais cela pourrait devenir trop difficile à long terme, surtout si vous voulez que votre code fonctionne correctement, plutôt que de vous battre avec la surface ASF.

---

## Mises à jour automatiques

ASF vous propose deux interfaces pour mettre en œuvre des mises à jour automatiques dans votre plugin:

- `IGitHubPluginUpdates` vous fournissant un moyen facile d'implémenter des mises à jour basées sur GitHub similaires au mécanisme général de mise à jour ASF
- `IPluginUpdates` vous fournissant une fonctionnalité de niveau inférieur qui permet un mécanisme de mise à jour personnalisé, si vous avez besoin de quelque chose de plus complexe

---

### **[`IGithubPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs)**

La liste de contrôle minimale des choses qui sont requises pour les mises à jour de travail :

- Vous devez déclarer `RepositoryName`, qui définit d'où sont tirées les mises à jour.
- Vous devez utiliser les balises et les versions fournies par GitHub. La balise doit être au format parable vers une version du plugin, par exemple `1.0.0.0`.
- La propriété `Version` du plugin doit correspondre à la balise dont il provient. Cela signifie que le binaire disponible sous la balise `1.2.3.4` doit se présenter comme `1.2.3.4`.
- Chaque tag devrait avoir une version appropriée disponible sur GitHub avec une ressource de publication de fichier zip qui inclut les fichiers binaires de votre plugin. Les fichiers binaires qui incluent vos classes `IPlugin` devraient être disponibles dans le répertoire racine du fichier zip.

Cela permettra au mécanisme dans ASF de :

- Résoudre la `Version` actuelle de votre plugin, par exemple `1.0.1`.
- Utilisez l'API GitHub pour récupérer le dernier `tag` disponible dans le dépôt `RepositoryName`, par exemple `1.0.2`.
- Déterminez que `1.0.2` > `1.0.1`, vérifiez la version de la balise `1.0.2` pour trouver le fichier `.zip` avec la mise à jour du plugin.
- Téléchargez ce fichier `.zip`, extrayez le fichier et mettez son contenu dans le répertoire qui inclut `YourPlugin.dll` avant.
- Redémarrez ASF pour charger votre plugin dans la version `1.0.2`.

Notes supplémentaires :

- Les mises à jour de plugins peuvent nécessiter des valeurs de configuration ASF appropriées, à savoir **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)** et/ou **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)**.
- Notre modèle de plugin inclut déjà tout ce dont vous avez besoin, simplement **[rename](https://github.com/JustArchiNET/ASF-PluginTemplate?tab=readme-ov-file#renaming-myawesomeplugin)** le plugin avec des valeurs correctes, et ça fonctionnera sans problème.
- Vous pouvez utiliser la combinaison de la dernière version ainsi que des pré-versions, elles seront utilisées selon `UpdateChannel` que l'utilisateur a défini.
- Il y a la propriété booléenne `CanUpdate` que vous pouvez remplacer pour désactiver/activer la mise à jour des plugins de votre côté, par exemple si vous voulez sauter temporairement les mises à jour, ou par n'importe quelle autre raison.
- Il est possible d'avoir plusieurs fichiers zip dans la version si vous voulez cibler différentes versions ASF. Voir `GetTargetReleaseAsset()` **[remarks](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs#L79-L106)**. Par exemple, vous pouvez avoir `MyPlugin-V6-0.zip` ainsi que `MyPlugin.zip`, ce qui causera ASF dans la version `V6. .x.x` pour choisir la première, tandis que toutes les autres versions d'ASF utiliseront la deuxième.
- Si ce qui précède n'est pas suffisant pour vous et vous avez besoin d'une logique personnalisée pour choisir le bon `. ip`, vous pouvez surcharger la fonction `GetTargetReleaseAsset()` et fournir l'artefact à utiliser par ASF.
- Si votre plugin a besoin de faire un travail supplémentaire avant/après la mise à jour, vous pouvez remplacer les méthodes `OnPluginUpdateProceeding()` et/ou `OnPluginUpginUpdateFinished()`.

---

### **[`IPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IPluginUpdates.cs)**

Cette interface vous permet d'implémenter une logique personnalisée pour les mises à jour si, par quelque raison que ce soit, `IGithubPluginUpdates` n'est pas suffisant pour vous, par exemple parce que vous avez des balises qui n'analysent pas les versions ou parce que vous n'utilisez pas du tout la plate-forme GitHub.

Il y a une seule fonction `GetTargetReleaseURL()` que vous pouvez remplacer, qui attend de vous `Uri?` de l'emplacement de mise à jour du plugin cible. ASF vous fournit des variables de base qui se rapportent au contexte avec lequel la fonction a été appelée, mais autres que cela, vous êtes responsable de la mise en œuvre de tout ce dont vous avez besoin dans cette fonction et de fournir à ASF l'URL qui doit être utilisée, ou `null` si la mise à jour n'est pas disponible.

À part cela, c'est similaire aux mises à jour de GitHub, où l'URL devrait pointer vers un `. ip` avec les fichiers binaires disponibles dans le répertoire racine. Vous avez également des méthodes `OnPluginUpdateProceeding()` et `OnPluginUpdateFinished()` disponibles.