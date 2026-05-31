# OvervågningPlugin

`MonitoringPlugin` er en officiel ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, som giver dig mulighed for at overvåge ASF proces via **[Prometheus](https://prometheus.io)** tidsserie database.

---

## Skærmbilleder

<details>
  <summary>Vis</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Krav

På grund af **[tekniske begrænsninger](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)**, kræver dette plugin 'generisk' variant af ASF.

---

## Aktivering af plugin

ASF kommer **ikke** med `MonitoringPlugin` bundtet som standard, men det er inkluderet som valgfri tilføjelse i hver ASF udgivelse. Download plugin fra den officielle **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**, der matcher din ASF-version, og opret derefter en dedikeret `plugins/ArchiSteamFarm. fficialPlugins.Monitoring` mappe til plugin, og endelig udtrække arkivet der.

På den næste lancering af ASF, vil logfilerne indikere, at plugin er blevet indlæst med succes gennem standard ASF logning mekanisme. Du kan også bekræfte dette ved at navigere til URL `/Api/metrics` i din IPC-grænseflade. Hvis du bruger IPC-adgangskode, skal du bruge korrekt godkendelse, f.eks. tilføjelse af `?password=<YourIPCPassword>til URL'en `/Api/metrics\` Det indhold, du ser, skal se ud som nedenfor:

```text
# TYPE asf_build_info gauge
# HELP asf_build_info Byg information om ASF i form af etiketværdier
asf_build_info{variant="source",version="6.0.2. "} 1 1713715703686

# TYPE asf_runtime_info gauge
# HELP asf_runtime_info Runtime information om ASF i form af etiketværdier
asf_runtime_info{framework=". ET 8.0.4",operating_system="Debian GNU/Linux trixie/sid",runtime="linux-x64"} 1 1713715703686
(...)
```

Metrics vedrørende ASF og bots har dedikeret præfiks `asf_` i deres navn. Andre målinger, f.eks. vedrørende .NET runtime eller ASF's 'HttpClient' genereres automatisk på basis af universelle .NET procesregler og bærer ikke sådanne præfiks.

---

## Prometheus config

Når du har verificeret plugin fungerer korrekt, kan du tilføje en scrape konfiguration til din **[Prometheus](https://prometheus.io)** instans som sådan:

```yaml
scrape_configs:
  - job_name: ArchiSteamFarm
    metrics_path: /Api/metrics
    params:
      adgangskode:
        - YourIPCPassword
    static_configs:
      - mål:
          - 127.0.1:1242
```

Naturligvis skal du sikre, at din hosted **[Prometheus](https://prometheus.io)** instans er i stand til at nå ASF's IPC interface, tilpasse `password` og `mål` i overensstemmelse hermed til din brug. Hvis du ikke har IPC kodeord indstillet (som ikke anbefales), kan du springe over tilføjelsen af 'params'-sektionen. Hvis du kører flere ASF forekomster med forskellige IPC adgangskoder, kan du tilføje yderligere scrape konfigurationer, en pr. instans, da forespørgselsparametrene ikke kan indstilles på en per-target-basis. Ellers kan du erklære flere 'mål', hvis de deler den samme adgangskode.

---

## Grafana betjeningspanel

Når dine målinger er indsamlet af Prometheus, er det muligt at bruge \*\*[Grafana](https://grafana.com) \*\* til visualisering. Dette plugin leveres med `/grafana-dashboard. son` fil serveret af standard IPC mekanismer, så forudsat at du kører din ASF instans med standardindstillinger, du kan downloade det **[here](http://127.0.0.1:1242/grafana-dashboard.json)**. Alternativt kan du også få fat i JSON-filen fra vores \*\*[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json) \*\* også.