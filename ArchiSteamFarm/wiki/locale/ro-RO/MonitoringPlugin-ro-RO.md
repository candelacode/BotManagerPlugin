# MonitorizPlugin

`MonitoringPlugin` este un ASF oficial **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, care vă permite să monitorizați procesul ASF prin **[Prometheus](https://prometheus.io)** baza de date cu serii orare.

---

## Capturi ecran

<details>
  <summary>Arata</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Cerințe

Din cauza **[constrângerilor tehnice](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)**, acest plugin necesită varianta `generic` a ASF.

---

## Activarea plugin-ului

ASF **nu** vine cu `MonitoringPlugin` pachetat în mod implicit, totuși, este inclus ca adaos opțional în fiecare lansare ASF. Descarcă plugin-ul din **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** care corespunde versiunii tale ASF, apoi creează un "plugins/ArchiSteamFarm" dedicat. folderul fficialPlugins.Monitoring' pentru plugin și în cele din urmă extrageți arhiva acolo.

La următoarea lansare a ASF, jurnalele vor indica faptul că plugin-ul a fost încărcat cu succes prin mecanismul standard de logare ASF. De asemenea, puteţi verifica acest lucru navigând la URL-ul `/Api/metrics` din interfaţa IPC. Dacă folosiți parola IPC, veți avea nevoie de o autorizație corectă, de ex. adăugare `?password=<YourIPCPassword>` la URL-ul `/Api/metrics`. Conţinutul pe care îl vedeţi trebuie să fie similar cu cel de mai jos:

```text
# TYPE asf_build_info gauge
# HELP asf_build_info Build informații despre ASF sub forma valorilor etichetei
asf_build_info{variant="source",version="6.0.2. "} 1 1713715703686

# TYPE asf_runtime_info gauge
# HELP asf_runtime_info Runtime informații despre ASF sub forma valorilor etichetei
asf_runtime_info{framework=". ET 8.0.4",operating_system="Debian GNU/Linux trixie/sid",runtime="linux-x64"} 1 1713715703686
(...)
```

Metrici cu privire la ASF și boți au dedicat prefixul `asf_` în numele lor. Alți indicatori referitori la .NET runtime sau la `HttpClient` de la ASF sunt generați automat pe baza regulilor universale de proces NET și nu poartă astfel de prefix.

---

## Configurare Prometheus

Odată ce ați verificat plugin-ul funcționează corect, puteți adăuga o configurație de răzuire la instanța **[Prometheus](https://prometheus.io)** ca atare:

```yaml
scrape_configs:
  - job_name: ArchiSteamFarm
    metrics_path: /Api/metrics
    params:
      parola:
        - YourIPCPassword
    static_configs:
      - ținte:
          - 127.0.1:1242
```

Bineînțeles, trebuie să te asiguri că instanța ta găzduită **[Prometheus](https://prometheus.io)** poate ajunge la interfața IPC a ASF. adaptați `password` și `targets` corespunzător la utilizarea dumneavoastră. Dacă nu aveţi o parolă IPC setată (care nu este recomandată), puteţi sări peste adăugarea secţiunii `params`. În cazul în care rulați mai multe instanțe ASF cu parole IPC diferite, puteți adăuga configurații suplimentare pentru resturi, 1 per exemplu, deoarece parametrii interogării nu pot fi setați pentru fiecare țintă. În caz contrar, puteți declara mai multe `ținte` dacă acestea au aceeași parolă.

---

## Panou de control

Odată ce măsurătorile sunt colectate de Prometheus, este posibil să utilizaţi **[Grafana](https://grafana.com)** pentru vizualizare. Plugin-ul vine cu `/grafana-dashboard. fișierul son` servit de mecanismele standard IPC, deci presupunând că rulați instanța ASF cu setările implicite, îl puteţi descărca **[here](http://127.0.0.1:1242/grafana-dashboard.json)**. Alternativ, poți deasemenea să iei fișierul JSON din **[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)** de asemenea.