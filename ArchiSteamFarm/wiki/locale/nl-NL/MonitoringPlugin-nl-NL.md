# MonitoringPlugin

`MonitoringPlugin` is een officiële ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, waarmee u ASF kunt monitoren via **[Prometheus](https://prometheus.io)** tijdseizoendatabase.

---

## Schermafbeeldingen

<details>
  <summary>Toon</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Vereisten

Vanwege **[technische beperkingen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)**, heeft deze plugin `generic` variant van ASF nodig.

---

## De plugin inschakelen

ASF komt **niet** met `MonitoringPlugin` gebundeld, maar het is standaard opgenomen als optionele toevoeging in elke ASF release. Download de plugin van de officiële **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** die overeenkomt met uw ASF-versie, en maak daarna een speciaal `plugins/ArchiSteamFarm. De map fficialPlugins.Monitoring` voor de plugin en pak het archief daar eindelijk uit.

Bij de volgende lancering van ASF zullen de logs aangeven dat de plugin met succes is geladen via het standaard ASF-logmechanisme. Je kunt dit ook verifiëren door te navigeren naar de `/Api/metrics` URL in je IPC interface. Als u een IPC-wachtwoord gebruikt, moet u de juiste autorisatie gebruiken, bijvoorbeeld '?password=<YourIPCPassword>' toevoegen aan de `/Api/metrics` URL. De inhoud die je ziet zou er net zo uit moeten zien als hieronder:

```text
# TYPE asf_build_info gauge
# HELP asf_build_info Build informatie over ASF in de vorm van label waarden
asf_build_info{variant="source",version="6.0.2. "} 1 1713715703686

# TYPE asf_runtime_info gauge
# HELP asf_runtime_info Runtime informatie over ASF in de vorm van label waarden
asf_runtime_info{framework=". ET 8.0.4",operating_system="Debian GNU/Linux trixie/sid",runtime="linux-x64"} 1 1713715703686
(...)
```

Metrieken met betrekking tot ASF en de bots hebben een speciale prefix `asf_` in hun naam. Andere statistieken, bijvoorbeeld met betrekking tot de .NET runtime of ASF's 'HttpClient' worden automatisch gegenereerd op basis van universele .NET procesregels en dragen geen prefix.

---

## Prometheus configuratie

Zodra u heeft geverifieerd dat de plugin correct werkt, kunt u een scrape configuratie toevoegen aan uw **[Prometheus](https://prometheus.io)** instantie als dus:

```yaml
scrape_configs:
  - job_name: ArchiSteamFarm
    metrics_path: /Api/metrics
    params:
      password:
        - YourIPCPassword
    static_configs:
      - targets:
          - 127.0.1:1242
```

Natuurlijk moet u ervoor zorgen dat uw gehoste **[Prometheus](https://prometheus.io)** instantie de ASF's IPC interface kan bereiken pas `password` en `targets` dus aan op jouw gebruik. Als u geen IPC wachtwoord hebt ingesteld (wat niet wordt aanbevolen), kunt u de toevoeging van de `params` sectie overslaan. In het geval je meerdere ASF-instanties met verschillende IPC-wachtwoorden gebruikt, kun je extra schraapconfiguraties toevoegen, één per voorbeeld, omdat de queryparameters niet per doel kunnen worden ingesteld. Anders kan je meerdere `targets` opgeven als ze hetzelfde wachtwoord delen.

---

## Grafana dashboard

Zodra je statistieken verzameld zijn door Prometheus, is het mogelijk om **[Grafana](https://grafana.com)** te gebruiken voor visualisatie. De plugin komt met `/grafana-dashboard. son` bestand geserveerd met standaard IPC mechanismen, dus ga ervan uit dat je jouw ASF instantie draait met standaard instellingen, je kan het downloaden[here](http://127.0.0.1:1242/grafana-dashboard.json)**. Als alternatief kun je ook het JSON-bestand van onze[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)** pakken.