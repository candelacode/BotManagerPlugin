# OvervåkingPlugin

`MonitoringPlugin` er en offisiell ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, slik at du kan overvåke ASF-prosess via **[Prometheus](https://prometheus.io)** tidsseriedatabase.

---

## Skjermbilder

<details>
  <summary>Vis</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Krav

På grunn av **[tekniske begrensninger](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)**, krever denne utvidelsen `generic` variant av ASF.

---

## Aktiverer utvidelsen

ASF kommer **ikke** med `MonitoringPlugin` som standard, men den er inkludert som valgfritt tillegg i hver ASF-utgivelse. Last ned utvidelsen fra de offisielle **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** som samsvarer med din ASF-versjon, og lag deretter en dedikert `plugins/ArchiSteamFarm. fficialPlugins.Monitoring` mappen for utvidelsen og kan endelig pakke ut arkivet der.

Ved neste lansering av ASA vil loggene indikere at utvidelsen har blitt vellykket lastet gjennom standard ASF loggemekanisme. Du kan også bekrefte dette ved å navigere til `/Api/metrics`-adressen i IPC-grensesnittet. Hvis du bruker IPC passord, trenger du riktig godkjenning, f.eks å legge til `?password=<YourIPCPassword>` til `/Api/metrics` URL. Innholdet du ser skal se likt ut:

```text
# TYPE asf_build_info gauge
# HELP asf_build_info Bygge informasjon om ASF i form av etikettverdier
asf_build_info{variant="source",version="6.0.2. "} 1 1713715703686

TYPE asf_runtime_info gauge
# HELP asf_runtime_info Runtime information about ASF in form of label values
asf_runtime_info{framework=". ET 8.0.4",operating_system="Debian GNU/Linux trixie/sid",runtime="linux-x64"} 1 1713715703686
(...)
```

Måltall om ASF og botene har dedikert prefiks `asf_` i navnet. Andre måltall, for eksempel om driftstid eller ASFs `HttpClient` genereres automatisk basert på universelle .NET-prosessregler og er ikke utstyrt med slik prefiks.

---

## Prometheus konfigurasjon

Once you verified the plugin is working correctly, you can add a scrape configuration to your **[Prometheus](https://prometheus.io)** instance as such:

```yaml
scrape_configs:
  - job_name: ArchiSteamFarm
    metrics_path: /Api/metrics
    params:
      passord:
        - YourIPCPassword
    static_configs:
      - mål:
          - 127.0.0.1:1242
```

Du må selvsagt forsikre deg om at vertene dine **[Prometheus](https://prometheus.io)** forekomsten er i stand til å nå ASFs IPC-grensesnitt. tilpasser derfor "passord" og "mål" til bruken din. Hvis du ikke har angitt IPC-passord (som ikke er anbefalt), kan du hoppe over adgangen i `params`-avsnittet. Dersom du kjører flere ASF-forekomster med forskjellige IPC-passord, kan du legge til flere scrape-konfigurasjoner, én for eksempel, siden parameteren for spørring ikke kan settes for hvert mål. Ellers kan du erklære flere `mål` hvis de deler det samme passordet.

---

## Grafana dashboard

Når måltallene er samlet inn av Prometheus, er det mulig å bruke **[Grafana](https://grafana.com)** for visualisering. Plugin kommer med `/grafana-dashboard. son`-filen er servert av standard IPC-mekanismer, så forutsatt at du kjører ASF-forekomsten din med standardinnstillinger, du kan laste den ned **[here](http://127.0.0.1:1242/grafana-dashboard.json)**. Alternativt kan du også velge JSON-filen fra vår **[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)** også.