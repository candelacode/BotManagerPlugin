# MonitoringPlugin

`MonitoringPlugin` je oficiální ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, který vám umožňuje sledovat proces ASF prostřednictvím **[Prometheus](https://prometheus.io)** databáze časových řad.

---

## Snímek obrazovky

<details>
  <summary>Zobrazit</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Požadavky

Kvůli **[technickým omezením](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)**, tento plugin vyžaduje `generic` variantu ASF.

---

## Povolení pluginu

ASF **není** přichází s `MonitoringPlugin` ve výchozím nastavení ve svazku, ale v každém vydání ASF je zahrnut jako volitelný doplněk. Stáhněte si plugin z oficiálního **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**, který odpovídá vaší verzi ASF, pak vytvořte vyhrazený `plugins/ArchiSteamFarm. fficialPlugins.Monitoring` adresář pro zásuvný modul a konečně rozbalte archiv tam.

Při příštím spuštění ASF, logy budou znamenat, že plugin byl úspěšně načten pomocí standardního ASF logovacího mechanismu. Můžete to také ověřit navigací na adresu `/Api/metrics` ve vašem IPC rozhraní. Pokud používáte IPC heslo, budete potřebovat řádné autorizaci, např. appending `?password=<YourIPCPassword>` na `/Api/metrics` URL. Obsah, který vidíte, by měl vypadat podobně jako níže:

```text
# TYPE asf_build_info měřidlo
# HELP asf_build_info Informace o ASF v podobě hodnot označení
asf_build_info{variant="source",version="6.0.2. "} 1 1713715703686

# TYPE asf_runtime_info gauge
# HELP asf_runtime_info Runtime informace o ASF v podobě hodnot štítku
asf_runtime_info{framework=". ET 8.0.4",operating_system="Debian GNU/Linux trixie/sid",runtime="linux-x64"} 1 1713715703686
(...)
```

Metriky týkající se ASF a botů mají ve svém jménu vyhrazenou prefix `asf_`. Další metriky, např. pokud jde o běh .NET nebo ASF `HttpClient` jsou automaticky generovány na základě všeobecných pravidel procesu .NET a neobsahují takovou prefix.

---

## Nastavení Prometheus

Jakmile ověříte, že zásuvný modul funguje správně, můžete přidat konfiguraci skriptů do vaší instance **[Prometheus](https://prometheus.io)**:

```yaml
scrape_configs:
  - job_name: ArchiSteamFarm
    metrics_path: /Api/metrics
    params:
      password:
        - YourIPCPassword
    static_configs:
      - Cíly:
          - 127.0.0.1:1242
```

Přirozeně se musíte ujistit, že vaše hostovaná instance **[Prometheus](https://prometheus.io)** je schopna dosáhnout rozhraní IPC ASF, odpovídajícím způsobem přizpůsobte `heslo` a `cíle` Vašemu používání. Pokud nemáte nastavenou IPC heslo (což není doporučeno), můžete přeskočit přidání sekce `params`. V případě, že používáte více instancí ASF s různými IPC hesly, můžete přidat další nastavení scrape jeden na jednu instanci, protože parametry dotazu nelze nastavit na základě jednotlivých cílů. V opačném případě můžete vyhlásit několik `cílů`, pokud sdílejí stejné heslo.

---

## Nástěnka Grafany

Jakmile jsou vaše metriky shromážděny Prometheusem, je možné použít **[Grafana](https://grafana.com)** pro vizualizaci. Plugin přichází s `/grafana-dashboard. son` soubor obsluhovaný standardními mechanismy IPC, takže za předpokladu, že používáte instanci ASF s výchozím nastavením, můžete si jej stáhnout **[here](http://127.0.0.1:1242/grafana-dashboard.json)**. Případně můžete také uchytit soubor JSON z našich **[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)**.