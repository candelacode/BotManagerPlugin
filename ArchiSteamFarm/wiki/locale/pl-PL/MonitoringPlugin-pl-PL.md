# Wtyczka Monitorująca

`MonitoringPlugin` jest oficjalnym ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, który pozwala na monitorowanie procesu ASF poprzez **[Prometheus](https://prometheus.io)** bazę szeregów czasowych.

---

## Zrzuty ekranu

<details>
  <summary>Pokaż</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Wymagania

Ze względu na **[ograniczenia techniczne](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)**, ta wtyczka wymaga wariantu `generic` ASF.

---

## Włączanie wtyczki

ASF **nie** posiada domyślnie `MonitoringPlugin` dołączony do każdego wydania ASF. Pobierz wtyczkę z oficjalnego **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**, która odpowiada twojej wersji ASF, a następnie utwórz dedykowane `plugins/ArchiSteamFarm. katalog fficialPlugins.Monitoring` dla wtyczki i wreszcie wypakuj tam archiwum.

Po następnym uruchomieniu ASF dzienniki będą wskazywały, że wtyczka została pomyślnie załadowana za pomocą standardowego mechanizmu logowania ASF. Możesz to również zweryfikować, przechodząc do adresu URL `/Api/metrics` w swoim interfejsie IPC. Jeśli używasz hasła IPC, będziesz potrzebować poprawnej autoryzacji, np. dołączenie `?password=<YourIPCPassword>` do adresu URL `/Api/metrics`. Zawartość którą widzisz, powinna wyglądać podobnie, jak poniżej:

```text
# TYPE asf_build_info gauge
# HELP asf_build_info Budowanie informacji o ASF w formie wartości etykiet
asf_build_info{variant="source",version="6.0.2. "} 1 1713715703686

# TYPE asf_runtime_info gauge
# HELP asf_runtime_info Informacje o ASF w formie wartości etykiet
asf_runtime_info{framework=". ET 8.0.4",operating_system="Debian GNU/Linux trixie/sid",runtime="linux-x64"} 1 1713715703686
(...)
```

Metryki dotyczące ASF i botów mają dedykowany prefiks `asf_` w swojej nazwie. Inne wskaźniki np. dotyczące czasu pracy .NET lub `HttpClient` ASF są generowane automatycznie na podstawie uniwersalnych reguł procesu .NET i nie mają takiego prefiksu.

---

## Konfiguracja Prometheus

Po zweryfikowaniu poprawności wtyczki możesz dodać konfigurację złomowania do swojej instancji **[Prometheus](https://prometheus.io)** jako taką:

```yaml
scrape_configs:
  - job_name: ArchiSteamFarm
    metrics_path: /Api/metrics
    parametry:
      hasło:
        - YourIPCPassword
    static_configs:
      - cely:
          - 127.0.0.1:1242
```

Oczywiście musisz upewnić się, że instancja **[Prometheus](https://prometheus.io)** jest w stanie dotrzeć do interfejsu ASF IPC, dostosować odpowiednio `password` i `targets` do swojego użycia. Jeśli nie masz ustawionego hasła IPC (co nie jest zalecane), możesz pominąć dodanie sekcji `params`. Jeśli używasz wielu instancji ASF z różnymi hasłami IPC, możesz dodać dodatkowe konfiguracje złomu, jeden na przykład, ponieważ parametry zapytania nie mogą być ustawione dla każdego celu. W przeciwnym razie możesz zadeklarować kilka `targets` jeśli używają tego samego hasła.

---

## Panel Grafany

Gdy Twoje metryki są zbierane przez Prometheus, możliwe jest użycie **[Grafana](https://grafana.com)** do wizualizacji. Wtyczka zawiera `/grafana-dashboard. plik son` obsługiwany przez standardowe mechanizmy IPC, więc zakładając, że używasz instancji ASF z domyślnymi ustawieniami, możesz pobrać **[here](http://127.0.0.1:1242/grafana-dashboard.json)**. Alternatywnie, możesz również pobrać plik JSON z naszego **[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)**.