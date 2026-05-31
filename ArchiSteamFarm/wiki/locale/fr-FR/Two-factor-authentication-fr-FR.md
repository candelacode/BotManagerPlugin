# Authentification à deux facteurs

Steam inclut un système d'authentification à deux facteurs qui nécessite des détails supplémentaires pour diverses activités liées au compte. Vous pouvez en apprendre plus par rapport à ce système **[ici](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** et **[ici](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. Cette page considère que le système 2FA ainsi que notre solution qui s’intègre avec elle, appelée ASF 2FA.

---

# Logique de ASF

Peu importe si vous utilisez ASF 2FA ou non, ASF inclut une logique appropriée et est pleinement conscient des comptes protégés par 2FA sur Steam. Il vous demandera les détails requis quand ils sont nécessaires (comme lors de la connexion). Bien que vous puissiez fournir manuellement ces informations, certaines fonctionnalités ASF (comme `MatchActively`) exigent qu'ASF 2FA soit opérationnel sur votre compte de bot. qui peut répondre automatiquement aux invites 2FA, automatiquement, lorsque requis par ASF.

---

# ASF 2FA

ASF 2FA est un module intégré chargé de fournir des fonctionnalités 2FA au processus ASF, telles que la génération de jetons et l’acceptation de confirmations. Il peut fonctionner soit en mode autonome, ou en dupliquant les détails de votre authentificateur actuel (afin que vous puissiez utiliser votre authentificateur actuel et ASF 2FA en même temps).

Vous pouvez vérifier si votre compte de bot utilise déjà ASF 2FA en exécutant les commandes `2fa` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Sans configurer ASF 2FA, toutes les commandes standard `2fa` ne seront pas opérationnelles, ce qui signifie que votre bot n'est pas disponible pour les fonctionnalités ASF avancées qui nécessitent que le module soit opérationnel.

---

# Recommandations

Il y a beaucoup de façons de rendre ASF 2FA opérationnel, nous incluons ici nos recommandations en fonction de votre situation actuelle:

- If you're already using unofficial third-party app that allows you to extract 2FA details with ease, just **[import](#import)** those to ASF.
- Si vous utilisez l'application officielle et que vous n'avez pas de problème à réinitialiser vos identifiants 2FA, la meilleure façon est de désactiver le 2FA, puis **[créer](#creation)** nouveaux identifiants 2FA en utilisant **[joint authentificateur](#joint-authenticator)**, qui vous permettra d'utiliser l'application officielle et ASF 2FA. Cette méthode **ne nécessite pas la racine**, le jailbreakage ou aucune connaissance avancée, suivant à peine les instructions écrites ici, et est sans doute supérieure pour ce scénario.
- Si vous utilisez l'application officielle et que vous ne voulez pas recréer vos identifiants 2FA, vos options sont très limitées, typiquement vous aurez besoin de root et de manipulations supplémentaires pour **[importer](#import)** ces détails, et même avec cela, cela pourrait être impossible.
- Si vous n'utilisez pas encore 2FA et que vous ne vous en souciez pas, nous vous recommandons d'utiliser ASF 2FA avec l'authentificateur autonome **[](#standalone-authenticator)** ou **[joint authenticator](#joint-authenticator)** avec l'application officielle (identique à ci-dessus).

Ci-dessous, nous discutons de toutes les options possibles et des méthodes connues.

---

## Création

ASF est livré avec un plugin officiel `MobileAuthenticator` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** qui étend davantage ASF 2FA, vous permettant de relier un nouvel authentificateur 2FA. Cela peut être utile dans le cas où vous ne pouvez pas ou ne souhaitez pas utiliser d’autres outils et n’oubliez pas qu’ASF 2FA devienne votre authentificateur principal (et peut-être seulement). Le processus de création est également utilisé dans la méthode joint-authenticator, naturellement dans ce scénario, votre authentificateur peut coexister en deux endroits à la fois - les deux généreront les mêmes codes et les mêmes confirmations.

### Étapes communes pour les deux scénarios

Peu importe si vous prévoyez d’utiliser ASF comme authentificateur autonome ou conjoint, vous devez faire ces étapes d’initialisation:

1. Créez un bot ASF pour le compte cible, démarrez-le et connectez-vous, ce que vous avez probablement déjà fait.
2. Assignez un numéro de téléphone fonctionnel et opérationnel au compte **[ici](https://store.steampowered.com/phone/manage)** pour être utilisé par le bot. Cela vous permettra de recevoir le code SMS et de permettre la récupération si nécessaire. Cette étape n'est pas obligatoire dans tous les scénarios, cependant, nous la recommandons à moins que vous ne sachiez ce que vous faites.
3. Assurez-vous que vous n'utilisez pas encore 2FA pour votre compte, si vous le faites, désactivez-le d'abord. Ce **va** mettre votre compte en réserve temporaire, il n'y a aucun moyen de le contourner, seul le processus **[d'import](#import)** peut sauter.
4. Exécutez la commande `2fainit [Bot]` en remplaçant `[Bot]` par le nom de votre bot.

En supposant que vous ayez obtenu une réponse réussie, les deux choses suivantes se sont produites:

- Un nouveau fichier `<Bot>.maFile.PENDING` a été généré par ASF dans votre répertoire `config`.
- Un SMS a été envoyé de Steam au numéro de téléphone que vous avez attribué pour le compte ci-dessus. Si vous n'avez pas défini de numéro de téléphone, un courriel a été envoyé à l'adresse e-mail du compte.

Les détails de l'authentificateur ne sont pas encore opérationnels, cependant, vous pouvez consulter le fichier généré si vous le souhaitez. Si vous voulez être double-sûr, vous pouvez, par exemple, déjà écrire le code de révocation. Les étapes suivantes dépendront de votre scénario sélectionné.

### Authentificateur autonome

Si vous souhaitez utiliser ASF comme authentificateur principal (ou même seulement), vous devez maintenant faire l'étape finale de finalisation :

5. Exécutez la commande `2fafinalize [Bot] <ActivationCode>` en remplaçant `[Bot]` par le nom de votre bot et `<ActivationCode>` par le code que vous avez reçu par SMS ou par e-mail à l'étape précédente.

### Authentificateur articulaire

Si vous voulez avoir le même authentificateur dans ASF et l'application mobile officielle Steam, maintenant vous devez faire les étapes suivantes, plus compliquées :

5. **Ignore** the SMS or e-mail code that you've received in the previous step.
6. Installez l'application mobile Steam si elle n'est pas encore installée et ouvrez-la. Naviguez dans l'onglet Steam Guard et ajoutez un nouvel authentificateur en suivant les instructions de l'application.
7. Une fois votre authentificateur ajouté dans l'application mobile et fonctionnel, retournez à ASF. Maintenant, au lieu de finaliser, nous devons simplement informer ASF que l'application mobile a déjà activé nos détails précédemment générés:
 - Attendez que le prochain code 2FA soit affiché dans l'application mobile Steam, et utilisez la commande `2fafinalized [Bot] <2FACodeFromApp>` remplaçant `[Bot]` par le nom de votre bot et `<2FACodeFromApp>` avec le code que vous voyez actuellement dans l'application mobile Steam - le même que vous utilisez pour vous connecter à Steam (**NOT** celui que vous avez déjà utilisé pour l'activation). Si le code généré par ASF et le code que vous avez fourni sont égaux, ASF supposera qu’un authentificateur a été ajouté correctement et procédera à l’importation de votre nouvel authentificateur.
 - Nous vous recommandons fortement de faire ce qui précède afin de vous assurer que vos identifiants sont valides. Cependant, si vous ne voulez pas (ou ne pouvez pas) vérifier si les codes sont les mêmes et que vous savez ce que vous faites, vous pouvez à la place utiliser la commande `2fafinalizedforce [Bot]`, remplaçant `[Bot]` par le nom de votre bot. ASF supposera que l’authentificateur a été ajouté correctement et procédera à l’importation de votre nouvel authentificateur créé. Sachez que dans ce mode, ASF ne peut pas vérifier si les codes correspondent, ce qui signifie que vous pouvez potentiellement importer des identifiants non valides (non activés).

### Après la finalisation

En supposant que tout fonctionne correctement, le fichier `<Bot>.maFile.PENDING` précédemment généré a été renommé en `<Bot>.maFile.NEW`. Ceci indique que vos identifiants 2FA sont maintenant valides et actifs. Nous vous recommandons de déplacer ce fichier en dehors du répertoire `config` et **le stocker dans un emplacement sécurisé**. En plus de cela, si vous avez décidé d'utiliser un authentificateur autonome, alors nous vous recommandons d'ouvrir le fichier dans votre éditeur de choix et d'écrire le `revocation_code`, qui vous permettra, comme le nom l'indique, de révoquer l'authentificateur en cas de perte. Avec la méthode joint-authenticator, vous devriez déjà le faire dans l'application mobile Steam, mais n'hésitez pas à faire la même chose au cas où vous en auriez besoin.

En ce qui concerne les détails techniques, la génération de `maFile` inclut tous les détails que nous avons reçus du serveur Steam lors de la liaison de l'authentificateur, et en plus de cela, le champ `device_id` qui peut être nécessaire pour d'autres authentificateurs (tiers) si vous décidez jamais d'importer dans ces fichiers ce `maFile`.

ASF importe automatiquement votre authentificateur une fois la procédure terminée, et donc `2fa` et d'autres commandes connexes devraient maintenant être opérationnelles pour le compte de bot auquel vous avez lié l'authentificateur. Nous vous recommandons de vérifier cela.

---

## Import

Le processus d'importation nécessite déjà un authentificateur lié et opérationnel pris en charge par ASF. Nous avons des instructions pour quelques sources officielles et non officielles de 2FA, en plus de la méthode manuelle qui vous permet de fournir vous-même les informations d'identification requises. Please note that those instructions should be used **only** if you're already using given solution - since process here involves third-party apps and tools, **we do not recommend using them**, and we're mentioning it exclusively for people that already decided to use them and would like to import generated details into ASF 2FA.

En général, le processus d'importation implique la suppression de `maFile` au format approprié dans le répertoire de configuration `` d'ASF, sur lequel ASF ramassera ce fichier et le supprimera automatiquement pour des raisons de sécurité.

Tous les guides suivants exigent que vous ayez déjà un authentificateur ** fonctionnel et opérationnel </ 0> utilisé avec un outil / ou une application tiers. ASF 2FA ne fonctionnera pas correctement si vous importez des données non valides. Assurez-vous donc que votre authentificateur fonctionne correctement avant de tenter de l'importer. Cela inclut de tester et de vérifier que les fonctions suivantes de l'authentificateur fonctionnent correctement:</p>
- Vous pouvez générer des jetons et ces jetons sont acceptés par le réseau Steam (vous pouvez vous connecter avec eux)
- Vous pouvez récupérer les confirmations et elles arrivent sur votre authentificateur mobile
- Vous pouvez réagir à ces confirmations, et elles sont correctement reconnues par le réseau Steam comme confirmées/rejetées

Assurez-vous que votre authentificateur fonctionne en vérifiant si les actions ci-dessus fonctionnent - si elles ne fonctionnent pas, elles ne fonctionneront pas non plus dans ASF.

### Téléphone Android

En général pour importer l'authentificateur depuis votre téléphone Android, vous aurez besoin d'un accès **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))**. Les instructions ci-dessous requièrent de votre part des connaissances relativement décentes dans le monde du modding Android, nous ne allons certainement pas expliquer chaque étape ici, visitez **[XDA](https://xdaforums.com)** et d'autres ressources pour plus d'informations ou d'aide ci-dessous.

**À partir d’aujourd’hui, il n’existe aucune méthode d’extraction reconnue et confirmée qui continue de fonctionner. Vous pouvez quand même essayer de suivre les étapes ci-dessous, par exemple avec une version obsolète de l'application, mais nous ne garantissons pas que cela fonctionnera correctement. Envisagez d'utiliser la méthode joint-authenticator à la place.**

<details>
  <summary>Instructions d'archivage</summary>

En supposant que vous ayez fonctionné et opérationnel sur l'application Steam **[officielle](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** (nécessite le rootage de votre appareil) :

- Installez **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** et activez Zygisk dans les paramètres.
- Installez **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (pour Zygisk) et assurez-vous que cela fonctionne.
- Install **[SteamGuardDump](https://github.com/YifePlayte/SteamGuardDump/releases/latest)** or **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** LSPosed module and enable it in LSPosed settings.
- Forcer la fermeture de l'application Steam, puis l'ouvrir, les détails du garde de vapeur devraient maintenant être disponibles pour la copie dans le presse-papiers.

Maintenant que vous avez extrait avec succès les détails requis, désactivez le module pour éviter la copie automatique à chaque fois, puis copiez la valeur de `shared_secret` et `identity_secret` du compte que vous comptez ajouter à ASF 2FA, dans un nouveau fichier texte avec la structure ci-dessous :

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Remplacez chaque valeur `STRING` par une clé privée appropriée à partir des détails extraits. Once you do that, rename the file to `BotName.maFile`, where `BotName` is the name of your bot you're adding ASF 2FA to, and put it in ASF's `config` directory if you haven't yet.

Lancez ASF, qui devrait remarquer votre fichier et l'importer. En supposant que vous avez importé le fichier correct avec des secrets valides, tout devrait fonctionner correctement, que vous pouvez vérifier en utilisant les commandes `2fa`. Si vous avez fait une erreur, vous pouvez toujours supprimer `Bot.db` et recommencer si nécessaire.

</details>

### SteamDesktopAuthenticator

Si vous avez votre authentificateur  SDA déjà en fonctionnement, vous devriez remarquer que le fichier `steamID.maFile`  est disponible dans le dossier `maFiles`. Assurez-vous que `maFile` est sous une forme non chiffrée, car ASF ne peut pas déchiffrer les fichiers SDA - le contenu du fichier non chiffré devrait commencer par `{` et se terminer par un caractère `}`. Si nécessaire, vous pouvez d'abord supprimer le chiffrement des paramètres SDA et l'activer à nouveau lorsque vous avez terminé. Une fois que le fichier est sous une forme non chiffrée, copiez-le dans le répertoire `config` d'ASF.

Vous pouvez maintenant renommer `steamID.maFile` en `BotName. aFile` dans le répertoire de configuration ASF, où `BotName` est le nom de votre bot auquel vous ajoutez ASF 2FA. Sinon, vous pouvez le laisser tel quel, ASF le sélectionnera automatiquement après vous être connecté. Le renommage du fichier aide ASF en rendant possible l'utilisation d'ASF 2FA avant de se connecter, si vous ne le faites pas, alors le fichier ne peut être sélectionné qu'après que ASF se connecte avec succès (car ASF ne connaît pas `steamID` de votre compte avant de se connecter).

Lancez ASF, qui devrait remarquer votre fichier et l'importer. En supposant que vous avez importé le fichier correct avec des secrets valides, tout devrait fonctionner correctement, que vous pouvez vérifier en utilisant les commandes `2fa`. Si vous avez fait une erreur, vous pouvez toujours supprimer `Bot.db` et recommencer si nécessaire.

### WinAuth

Une fois que votre fichier est sur votre PC, saisissez-le sous la forme `BotName.maFile</ 0> dans le répertoire de configuration ASF, où <code>BotName</ 0> correspond au nom de votre bot auquel vous ajoutez ASF 2FA. Si vous indiquez un nom incorrect, il ne sera pas sélectionné par ASF.</p>

<p spaces-before="0">Maintenant, lancez WinAuth comme d’habitude. Faites un clic droit sur l'icône Steam et sélectionnez "Afficher le code SteamGuard et le code de récupération". Puis cochez "Autoriser la copie". Vous devez connaître la structure JSON que vous connaissez bien en bas de la fenêtre, en commençant par <code> {</ 0>. Copiez le texte entier dans un fichier <code> BotName.maFile </ 0> créé par vous même à l'étape précédente.</p>

<p spaces-before="0">Lancez ASF, qui devrait remarquer votre fichier et l'importer. En supposant que vous avez importé le fichier correct avec des secrets valides, tout devrait fonctionner correctement, que vous pouvez vérifier en utilisant les commandes <code>2fa`. Si vous avez fait une erreur, vous pouvez toujours supprimer `Bot.db` et recommencer si nécessaire.

### Manuelle

Si vous êtes un utilisateur expérimenté, vous pouvez également générer manuellement le fichier maFile. Cela peut être utilisé dans le cas où vous vouliez importer un authentificateur depuis d'autres sources que celles que nous avons décrites ci-dessus. Il devrait avoir une **[structure JSON valide](https://jsonlint.com)** de ce type :

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Les données d'authentificateur standard comportent plus de champs. ASF les ignore totalement lors de l'importation, car elles ne sont pas nécessaires. Vous n'avez pas besoin de les supprimer - ASF ne nécessite que du JSON valide avec 2 champs obligatoires décrits ci-dessus, et ignorera les champs supplémentaires (le cas échéant). Bien sûr, vous devez remplacer un placeholder `STRING` dans l'exemple ci-dessus par des valeurs valides pour votre compte. Chaque `STRING` doit être une représentation encodée en base64 d'octets dont la clé privée appropriée est composée.

---

## FAQ

### Comment ASF utilise-t-il le module 2FA?

Si ASF 2FA est disponible, ASF l'utilisera pour la confirmation automatique des transactions en cours d'envoi / acceptées par ASF. Il sera également capable de générer automatiquement des jetons 2FA au besoin, par exemple pour se connecter. De plus, ASF 2FA active également les commandes ` 2fa </ 0> que vous pouvez utiliser.</p>

<h3 spaces-before="0">Comment puis-je obtenir un jeton 2FA ?</h3>

<p spaces-before="0">Vous aurez besoin du jeton 2FA pour accéder à un compte protégé par 2FA, qui comprend également chaque compte ASF 2FA. Si vous avez décidé d'utiliser un authentificateur autonome, alors vous devriez utiliser la commande <code>2fa <BotNames>` pour générer un jeton temporaire pour des instances de bot données. Dans tous les autres scénarios, nous recommandons d'utiliser l'authentificateur original que vous avez utilisé, bien que vous puissiez aussi utiliser la commande si elle vous convient.

### Puis-je utiliser mon authentificateur d'origine après l'avoir importé au format ASF 2FA?

Oui, votre authentificateur d'origine reste fonctionnel et vous pouvez l'utiliser avec ASF 2FA. Gardez toutefois à l’esprit que si vous l’invalidez par n’importe quelle méthode, les identifiants ASF 2FA liés ne seront pas non plus valides.

### Comment supprimer ASF 2FA?

Arrêtez simplement ASF et supprimez le fichier BotName.db</ 0>  du bot associé à ASF 2FA que vous souhaitez supprimer. Cette option supprimera les 2FA importés associés avec ASF, mais NE PAS invalider (délier) votre authentificateur. Si vous souhaitez à la place invalider votre authentificateur, en plus de le retirer d'ASF (tout d'abord), vous devez le dissocier dans l'authentificateur original de votre choix. Si vous ne pouvez pas le faire pour une raison quelconque, par exemple parce que vous utilisez ASF 2FA en mode autonome, utilisez ensuite le code de révocation que vous avez reçu pendant l'installation, sur le site Web Steam. Il n'est pas possible d'invalider votre authentificateur via ASF.</p>

<h3 spaces-before="0">J'ai lié l'authentificateur dans une application tierce, puis importé dans ASF. Puis-je maintenant le relier à nouveau sur mon téléphone?</h3>

<p spaces-before="0"><strong x-id="1">No</strong>. Cela invalidera les identifiants précédemment importés et votre 2FA ASF cessera de fonctionner (en générant des codes qui ne sont plus acceptés par Steam). Déterminez d'abord où vous voulez que votre authentificateur original ou tiers soit localisé, puis importez-le en tant qu'ASF 2FA.</p>

<h3 spaces-before="0">J'utilise l'authentificateur conjoint, puis-je déplacer mon application sur un autre téléphone ?</h3>

<p spaces-before="0"><strong x-id="1">Non</strong> Ce que la vapeur indique comme authentificateur « déplacement » ou « transfert », équivaut en fait à invalider l'ancien et à en assigner un nouveau, en une étape. Cela vous permet de sauter par ex. un temps de recharge excessif par rapport à la réalisation de ces deux étapes indépendamment, cependant, en ce qui concerne ASF, ceci invalide en fait les identifiants que vous avez précédemment générés dans ASF, rendant l'ensemble du module ASF 2FA non opérationnel.</p>

<p spaces-before="0">La façon recommandée est de retirer entièrement votre authentificateur sur l'ancien téléphone et d'utiliser à nouveau la méthode d'authentificateur commun sur le nouveau téléphone. Si vous avez déjà déplacé votre authentificateur, les anciens identifiants ASF 2FA sont déjà invalidés, la seule chose qui reste maintenant est de supprimer votre authentificateur « déplacé » et de relier un nouveau authentificateur en utilisant la méthode d'authentification commune.</p>

<h3 spaces-before="0">L’utilisation d’ASF 2FA est-elle meilleure que celle de l’authentificateur tiers configurée pour accepter toutes les confirmations?</h3>

<p spaces-before="0"><strong x-id="1"> Oui </ 0>, à plusieurs niveaux. Le premier et le plus important - utiliser ASF 2FA <strong x-id="1"> de manière significative </ 0> augmente votre sécurité, car le module ASF 2FA garantit qu'ASF n'acceptera automatiquement que ses propres confirmations. Ainsi, même si l'attaquant demande une transaction, ASF 2FA <strong x-id="1"> n'acceptera pas un tel échange, car il n'a pas été généré par ASF. En plus de la partie sécurité, l'utilisation d'ASF 2FA apporte également des avantages en termes de performance/optimisation, car ASF 2FA récupère et accepte les confirmations immédiatement après leur génération, et seulement alors, par opposition à un sondage inefficace pour les confirmations chaque X minutes qui est réalisé par d'autres solutions. Il n'y a aucune raison d'utiliser un authentificateur tiers sur ASF 2FA, si vous prévoyez d'automatiser les confirmations générées par ASF - c'est exactement ce qu'ASF 2FA pour, et l'utiliser ne contrevient pas avec vous en confirmant tout le reste dans l'authentificateur de votre choix. Nous recommandons fortement d’utiliser ASF 2FA pour toute l’activité ASF.</p>