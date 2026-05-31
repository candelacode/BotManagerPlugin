# MonitoringPlugin

`MonitoringPlugin` è un ASF ufficiale **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, che consente di monitorare il processo di ASF tramite **[Prometheus](https://prometheus.io)** banca dati serie temporali.

---

## Screenshot

<details>
  <summary>Mostra</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Requisiti

A causa di **[vincoli tecnici](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)**, questo plugin richiede la variante `generic` di ASF.

---

## Abilitare il plugin

ASF **non** viene fornito con `MonitoringPlugin` in bundle per impostazione predefinita, tuttavia, è incluso come aggiunta opzionale in ogni rilascio di ASF. Scarica il plugin dalla versione ufficiale **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** che corrisponde alla tua versione di ASF, quindi crea un `plugins/ArchiSteamFarm. fficialPlugins.Monitoring` directory per il plugin, ed infine estrarre l'archivio lì.

Al prossimo lancio di ASF, i registri indicheranno che il plugin è stato caricato con successo attraverso il meccanismo di registrazione ASF standard. Puoi anche verificarlo navigando all'URL `/Api/metrics` nella tua interfaccia IPC. Se stai usando la password IPC, avrai bisogno di un'autorizzazione adeguata, ad esempio aggiungendo `?password=<YourIPCPassword>` all'URL `/Api/metrics`. Il contenuto che vedi dovrebbe apparire simile a sotto:

```text
# TYPE asf_build_info gauge
# HELP asf_build_info Costruisci informazioni su ASF sotto forma di valori di etichetta
asf_build_info{variant="source",version="6.0.2. "} 1 1713715703686

# TYPE asf_runtime_info gauge
# HELP asf_runtime_info Informazioni sull'esecuzione di ASF in forma di valori di etichetta
asf_runtime_info{framework=". ET 8.0.4",operating_system="Debian GNU/Linux trixie/sid",runtime="linux-x64"} 1 1713715703686
(...)
```

Le metriche riguardanti ASF e i bot hanno dedicato il prefisso `asf_` a loro nome. Altre metriche, ad esempio per quanto riguarda il runtime .NET o il `HttpClient` di ASF, vengono generate automaticamente in base alle regole di processo .NET universali e non portano tale prefisso.

---

## Configurazione di Prometheus

Una volta verificato che il plugin funziona correttamente, è possibile aggiungere una configurazione scrape alla tua istanza **[Prometheus](https://prometheus.io)** come tale:

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

Naturalmente, è necessario assicurarsi che l'istanza **[Prometheus](https://prometheus.io)** ospitata sia in grado di raggiungere l'interfaccia IPC di ASF, adatta di conseguenza `password` e `targets` al tuo utilizzo. Se non si dispone di un set di password IPC (che non è raccomandato), è possibile saltare l'aggiunta della sezione `params`. Nel caso in cui stai eseguendo più istanze di ASF con diverse password IPC, puoi aggiungere ulteriori configurazioni di scrape, uno per esempio, poiché i parametri della query non possono essere impostati per ogni obiettivo. Altrimenti, puoi dichiarare più `targets` se condividono la stessa password.

---

## Cruscotto Grafana

Una volta che le metriche sono raccolte da Prometheus, è possibile utilizzare **[Grafana](https://grafana.com)** per la visualizzazione. Il plugin viene fornito con `/grafana-dashboard. file son` servito da meccanismi IPC standard, quindi supponendo che tu stia eseguendo la tua istanza ASF con impostazioni predefinite, puoi scaricarlo **[here](http://127.0.0.1:1242/grafana-dashboard.json)**. In alternativa, puoi anche prendere il file JSON dalla nostra **[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)**