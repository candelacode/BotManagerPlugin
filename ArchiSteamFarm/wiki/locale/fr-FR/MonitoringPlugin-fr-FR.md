# Plugin de surveillance

`MonitoringPlugin` est un ASF officiel **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, qui vous permet de surveiller le processus ASF via une base de données de séries temporelles **[Prometheus](https://prometheus.io)** .

---

## Captures d'écran

<details>
  <summary>Afficher</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Exigences

En raison de **[contraintes techniques](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)**, ce plugin nécessite une variante `generic` d'ASF.

---

## Activer le plugin

ASF n'inclut **pas** le `MonitoringPlugin` fourni par défaut, cependant, il est inclus comme ajout facultatif dans chaque version ASF. Téléchargez le plugin à partir de la version officielle **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** qui correspond à votre version ASF, puis créez un `plugins/ArchiSteamFarm dédié. fficialPlugins.Monitoring` répertoire pour le plugin, et enfin extraire l'archive là.

Lors du prochain lancement d'ASF, les journaux indiqueront que le plugin a été chargé avec succès par le mécanisme d'enregistrement ASF standard. Vous pouvez également vérifier cela en accédant à l'URL `/Api/metrics` dans votre interface IPC. Si vous utilisez un mot de passe IPC, vous aurez besoin d'une autorisation appropriée, par exemple en ajoutant `?password=<YourIPCPassword>` à l'URL `/Api/metrics`. Le contenu que vous voyez devrait ressembler à ce qui suit :

```text
# TYPE asf_build_info jauge
# AIDE asf_build_info Build des informations sur ASF sous forme de valeurs d'étiquette
asf_build_info{variant="source",version="6.0.2. "} 1 1713715703686

# TYPE asf_runtime_info jauge
# AIDE asf_runtime_info Informations Runtime sur ASF sous forme de valeurs d'étiquette
asf_runtime_info{framework=". ET 8.0.4",operating_system="Debian GNU/Linux trixie/sid",runtime="linux-x64"} 1 1713715703686
(...)
```

Les indicateurs concernant ASF et les bots ont un préfixe dédié `asf_` en leur nom. Les autres métriques, par exemple en ce qui concerne le runtime .NET ou le `HttpClient` d'ASF, sont générées automatiquement sur la base de règles universelles de processus .NET et ne portent pas ce préfixe.

---

## Configuration de Prometheus

Une fois que vous avez vérifié que le plugin fonctionne correctement, vous pouvez ajouter une configuration de scrape à votre instance **[Prometheus](https://prometheus.io)** en tant que telle :

```yaml
scrape_configs:
  - job_name: ArchiSteamFarm
    metrics_path: /Api/metrics
    params:
      password:
        - YourIPCPassword
    static_configs:
      - targets:
          - 127.0.0.1:1242
```

Naturellement, vous devez vous assurer que votre instance hébergée **[Prometheus](https://prometheus.io)** est en mesure d'accéder à l'interface IPC d'ASF, adaptez `password` et `targets` en conséquence à votre utilisation. Si vous n'avez pas de mot de passe IPC défini (ce qui n'est pas recommandé), vous pouvez sauter l'ajout de la section `params`. Dans le cas où vous exécutez plusieurs instances ASF avec différents mots de passe IPC, vous pouvez ajouter des configurations de scrape supplémentaires, une par instance, car les paramètres de la requête ne peuvent pas être définis sur une base par cible. Sinon, vous pouvez déclarer plusieurs `targets` s'ils partagent le même mot de passe.

---

## Tableau de bord Grafana

Une fois que vos mesures sont collectées par Prometheus, il est possible d'utiliser **[Grafana](https://grafana.com)** pour la visualisation. Le plugin est livré avec `/grafana-dashboard. le fichier son` servi par les mécanismes IPC standard, donc en supposant que vous exécutiez votre instance ASF avec les paramètres par défaut, vous pouvez le télécharger **[here](http://127.0.0.1:1242/grafana-dashboard.json)**. Vous pouvez également récupérer le fichier JSON de notre **[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)** également.