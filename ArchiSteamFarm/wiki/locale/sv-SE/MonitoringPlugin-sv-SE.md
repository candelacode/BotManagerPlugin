# ÖvervakningPlugin

`MonitoringPlugin` är en officiell ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, som låter dig övervaka ASF-processen via **[Prometheus](https://prometheus.io)** tidsseriedatabas.

---

## Skärmdumpar

<details>
  <summary>Visa</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Krav

På grund av **[tekniska begränsningar](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)**, kräver denna plugin `generic` variant av ASF.

---

## Aktiverar plugin

ASF innehåller **inte** `MonitoringPlugin` som standard men ingår som tillägg i varje ASF-utgåva. Ladda ner insticksprogrammet från den officiella **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** som matchar din ASF-version och skapa sedan en dedikerad `plugins/ArchiSteamFarm. fficialPlugins.Monitoring`-katalogen för plugin, och slutligen extrahera arkivet där.

Vid nästa lansering av ASF, loggarna kommer att indikera att plugin har laddats framgångsrikt genom standard ASF loggningsmekanism. Du kan också verifiera detta genom att navigera till `/Api/metrics`-URL i ditt IPC-gränssnitt. Om du använder IPC-lösenordet behöver du korrekt behörighet, t.ex. lägga till `?password=<YourIPCPassword>` till `/Api/metrics` URL. Innehållet du ser ska se ut som nedan:

```text
# TYPE asf_build_info gauge
# HELP asf_build_info Bygg information om ASF i form av etikettvärden
asf_build_info{variant="source",version="6.0.2. "} 1 1713715703686

# TYPE asf_runtime_info gauge
# HELP asf_runtime_info Runtime information om ASF i form av etikettvärden
asf_runtime_info{framework=". ET 8.0.4",operating_system="Debian GNU/Linux trixie/sid",runtime="linux-x64"} 1 1713715703686
(...)
```

Mätningar gällande ASF och robotarna har dedikerat prefixet `asf_` i deras namn. Andra mätvärden t.ex. avseende .NET runtime eller ASF's `HttpClient` genereras automatiskt baserat på universella .NET-processregler och har inte ett sådant prefix.

---

## Prometheus konfiguration

När du har verifierat att insticksprogrammet fungerar korrekt, kan du lägga till en skrapkonfiguration till din **[Prometheus](https://prometheus.io)** instans som sådan:

```yaml
scrape_configs:
  - job_name: ArchiSteamFarm
    metrics_path: /Api/metrics
    params:
      lösenord:
        - YourIPCPassword
    static_configs:
      - targets:
          - 127.0.0.1:1242
```

Naturligtvis måste du se till att din värd **[Prometheus](https://prometheus.io)** instans kan nå ASFs IPC-gränssnitt, anpassa `password` och `targets` i enlighet med din användning. Om du inte har IPC-lösenord (vilket inte rekommenderas) kan du hoppa över tillägget av `params`-sektionen. Om du kör flera ASF-instanser med olika IPC-lösenord kan du lägga till ytterligare skrapkonfigurationer, en per exempel, eftersom frågeparametrar inte kan ställas in per mål-basis. Annars kan du deklarera flera `mål` om de delar samma lösenord.

---

## Grafana instrumentpanel

När dina mätvärden är samlade av Prometheus är det möjligt att använda **[Grafana](https://grafana.com)** för visualisering. Pluginen levereras med `/grafana-instrumentbrädan. son`-fil som betjänas av standard IPC-mekanismer, så förutsatt att du kör din ASF-instans med standardinställningar, du kan ladda ner den **[here](http://127.0.0.1:1242/grafana-dashboard.json)**. Alternativt kan du också ta JSON-filen från vår **[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)** också.