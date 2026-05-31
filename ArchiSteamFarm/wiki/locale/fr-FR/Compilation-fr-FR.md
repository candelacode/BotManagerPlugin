# Compilation

La compilation est le processus de création d'un fichier exécutable. C’est ce que vous devez faire si vous souhaitez apporter vos propres modifications à ASF, ou si, pour une raison quelconque, vous ne faites pas confiance aux fichiers exécutables fournis dans les **[releases](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** officielles. Si vous êtes un utilisateur et non un développeur, vous souhaiterez très probablement utiliser des binaires déjà compilés. Mais si vous souhaitez utiliser les vôtres ou apprendre quelque chose de nouveau, continuez à lire.

ASF peut être compilé sur n’importe quelle plateforme actuellement supportée, tant que vous disposez de tous les outils nécessaires.

---

## SDK .NET

Quelle que soit la plate-forme, vous avez besoin du SDK .NET complet (pas seulement l'exécution) pour compiler ASF. Les instructions d'installation peuvent être trouvées sur la page de téléchargement **[.NET](https://dotnet.microsoft.com/download)**. Vous devez installer la version .NET SDK appropriée pour votre système d'exploitation. Une fois l'installation réussie, la commande ` dotnet </ 0> devrait fonctionner et être opérationnelle. Vous pouvez vérifier si cela fonctionne avec <code> dotnet --info </ 0>. Assurez-vous également que votre .NET SDK correspond aux exigences d'exécution ASF <strong x-id="1"><a href="https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements"></a></strong>.</p>

<hr />

<h2 spaces-before="0">Compilation</h2>

<p spaces-before="0">Si vous avez un SDK .NET opérationnel et dans la version appropriée, naviguez simplement vers le répertoire ASF source (cloné ou téléchargé et décompressé) et exécutez :</p>

<pre><code class="shell">dotnet publie ArchiSteamFarm -c "Release" -o "out/generic"
`</pre>

Si vous utilisez Linux/macOS, vous pouvez utiliser le script `cc.sh` qui fera la même chose, de manière un peu plus complexe.

Si la compilation s'est terminée avec succès, vous pouvez trouver votre ASF dans la saveur `source` dans le répertoire `out/generic`. Ceci est le même que la version officielle `générique` ASF, mais il a forcé `UpdateChannel` et `UpdatePeriod` de `0`, qui est approprié pour les auto-compilations.

### OS-spécifique

Vous pouvez également générer un package .NET spécifique à votre système d'exploitation si vous avez un besoin spécifique. En général, vous ne devriez pas le faire parce que vous venez de compiler la saveur `générique` que vous pouvez exécuter avec votre déjà installé. ET runtime que vous avez utilisé pour la compilation en premier lieu, mais juste au cas où vous vouliez :

```shell
dotnet publie ArchiSteamFarm -c "Release" -o "out/linux-x64" -r "linux-x64" --self-contained
```

Bien sûr, remplacez ` linux-x64 ` par l'architecture du système d'exploitation que vous souhaitez cibler, tel que ` win-x64 `. Cette mise à jour aura également des mises à jour désactivées. Lors de la construction de `--self-contained` vous pouvez aussi éventuellement déclarer deux commutateurs supplémentaires : `-p:PublishTrimmed=true` produira une compilation coupée, alors que `-p:PublishSingleFile=true` produira un seul fichier. L'ajout des deux résultera dans les mêmes paramètres que nous utilisons pour nos propres compilations.

### ASF-ui

Alors que les étapes ci-dessus sont tout ce qui est nécessaire pour avoir une version entièrement fonctionnelle d'ASF, vous pouvez *également* être intéressé par la construction de **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, notre interface web graphique. Du côté ASF, tout ce que vous avez à faire est de supprimer la sortie de compilation ASF-ui à l'emplacement standard `ASF-ui/dist` puis construisant ASF avec lui (encore, si nécessaire).

ASF-ui fait partie de l'arborescence des sources d'ASF en tant que sous-module **[git](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, assurez-vous que vous avez cloné le dépôt avec `git clone --recursive`, sinon vous n'aurez pas les fichiers requis. Vous aurez également besoin d'un NPM, **[Node.js](https://nodejs.org)** fonctionnel. Si vous utilisez Linux/macOS, nous recommandons notre script `cc.sh`, qui s’occupera automatiquement de la compilation et du déploiement d’ASF-ui (si possible, c’est-à-dire si vous respectez les exigences que nous venons de mentionner).

En plus du script `cc.sh`, nous fournissons ci-dessous des instructions de compilation simplifiées. Pour plus de documentation, référez-vous au **[dépôt ASF-ui](https://github.com/JustArchiNET/ASF-ui)**. À partir de l'emplacement de l'arborescence source d'ASF, donc comme ci-dessus, exécutez les commandes suivantes :

```shell
rm -rf "ASF-ui/dist" # ASF-ui ne se nettoie pas après l'ancienne version

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # Assurez-vous que notre sortie de build est propre des anciens fichiers
dotnet publier ArchiSteamFarm -c "Release" -o "out/generic" # Ou en conséquence à ce que vous avez besoin conformément à ce qui précède
```

Vous devriez maintenant pouvoir trouver les fichiers ASF-ui dans votre dossier `out/generic/www`. ASF sera en mesure de servir ces fichiers à votre navigateur.

Alternativement, vous pouvez simplement construire ASF-ui, que ce soit manuellement ou avec l'aide de notre dépôt, puis copiez manuellement la sortie de build dans le dossier `${OUT}/www` où `${OUT}` est le dossier de sortie d'ASF que vous avez spécifié avec le paramètre `-o`. This is exactly what ASF is doing as part of the build process, it copies `ASF-ui/dist` (if exists) over to `${OUT}/www`, nothing special, and can also be done post-build as you can see, if needed.

---

## Développement

Si vous souhaitez modifier le code ASF, vous pouvez utiliser n'importe quel . ET compatible IDE à cet effet, même si c'est optionnel, car vous pouvez également éditer avec un bloc-notes et compiler avec la commande `dotnet` décrite ci-dessus.

Si vous n'avez pas une meilleure pioche, nous pouvons recommander **[JetBrains Rider](https://www.jetbrains.com/rider)** et **[Visual Studio Code](https://code.visualstudio.com/download)**, le premier étant l’IDE préféré que l’équipe ASF utilise personnellement, et le second étant une alternative viable. Les deux programmes sont multi-plates-formes et disponibles sous Linux, macOS et Windows.

---

## Tags

La branche `principale` n'est pas garantie d'être dans un état qui permet une compilation réussie ou une exécution ASF impeccable en premier lieu, puisque c'est une branche de développement comme indiqué dans notre cycle de publication **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. Si vous voulez compiler ou référencer ASF à partir de la source, alors vous devriez utiliser le tag **[approprié](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** à cet effet, qui garantit au moins une compilation réussie, et très probablement aussi une exécution sans faille (si la compilation a été marquée comme version stable). Afin de vérifier la "santé" actuelle de l'arborescence, vous pouvez utiliser notre CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Versions Officielles

Les versions officielles d'ASF sont compilées par **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, avec la dernière version . ET SDK qui correspond à ASF **[exigences d'exécution](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. Après avoir passé des tests, tous les paquets sont déployés en tant que version, également sur GitHub. Cela garantit également la transparence, car GitHub utilise toujours la source publique officielle pour toutes les compilations, et vous pouvez comparer les sommes de contrôle des artefacts GitHub avec les ressources de publication GitHub. Les développeurs ASF ne compilent, ni ne publient les versions manuellement, sauf pour les processus de développement privés, y compris le débogage.

En plus de ce qui précède, les mainteneurs d'ASF valident et publient manuellement les sommes de contrôle de construction sur des serveurs indépendants de GitHub, serveur ASF distant, comme mesure de sécurité supplémentaire. Cette étape est obligatoire pour que les ASF existants considèrent la version comme un candidat valide pour la fonctionnalité de mise à jour automatique.