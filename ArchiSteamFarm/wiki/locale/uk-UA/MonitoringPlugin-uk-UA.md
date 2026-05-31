# Моніторинг та плагін

`MonitoringPlugin` є офіційним ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, який дозволяє відстежувати процес ASF через **[Prometheus](https://prometheus.io)** базу даних часових серій.

---

## Скріншоти

<details>
  <summary>Show</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Вимоги

Через **[технічні обмеження](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)**, цей плагін вимагає `generic` варіант ASF.

---

## Увімкнення плагіна

ASF **не** прийде за замовчуванням з `MonitoringPlugin`, проте він містить необов'язкове доповнення до кожного випуску ASF. Завантажити плагін з офіційного **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**, який відповідає вашій версії ASF, потім створити виділений `plugins/ArchiSteamFarm. каталог fficialPlugins.Monitoring` для плагіна і нарешті витягує архів там.

При наступному запуску ASF журнали вказують на те, що плагін був успішно завантажений за допомогою стандартного механізму логування ASF. Ви також можете перевірити це перемістивши URL-адресу на `/Api/metrics` в вашому IPC інтерфейсі. Якщо ви використовуєте IPC пароль, вам потрібна належна авторизація, наприклад додавання `?password=<YourIPCPassword>` в `/Api/metrics` URL. Зміст, який Ви бачите, повинен виглядати приблизно нижче:

```text
# TYPE asf_build_info gauge
# HELP asf_build_info Build information about ASF in form of label values
asf_build_info{variant="source",version="6.0.2.5"} 1 1713715703686

# TYPE asf_runtime_info gauge
# HELP asf_runtime_info Runtime information about ASF in form of label values
asf_runtime_info{framework=".NET 8.0.4",operating_system="Debian GNU/Linux trixie/sid",runtime="linux-x64"} 1 1713715703686
(...)
```

Метрики щодо ASF та ботів мають спеціальний префікс `asf_` в їх імені. Інші метрики, такі як .NET runtime або `HttpClient` автоматично створюються на основі універсальних правил процесу .NET і не носять такого префіксу.

---

## Конфігурація Prometheus

Once you verified the plugin is working correctly, you can add a scrape configuration to your **[Prometheus](https://prometheus.io)** instance as such:

```yaml
scrape_configs:
  - job_name: ArchiSteamFarm
    metrics_path: /Api/metrics
    params:
      password:
        - YourIPCPassword
    static_configs:
      - ціль:
          - 127.0.1:1242
```

Naturally, you need to ensure that your hosted **[Prometheus](https://prometheus.io)** instance is able to reach ASF's IPC interface, adapt `password` and `targets` accordingly to your usage. Якщо у вас немає пароля IPC (яку не рекомендується), ви можете пропустити розділ "params". Якщо ви запускаєте декілька екземплярів ASF з різними IPC паролями, ви можете додати додаткові конфігурації шкрябання, для певної міри, як параметри запиту не можуть бути встановлені на цільовій основі. В іншому випадку ви можете оголосити кілька `targets`, якщо вони мають той же пароль.

---

## Панель Grafana

Як тільки ваші показники будуть зібрані Prometheus, він має можливість використати **[Grafana](https://grafana.com)** для візуалізації. The plugin comes with `/grafana-dashboard.json` file served by standard IPC mechanisms, so assuming you're running your ASF instance with default settings, you can download it **[here](http://127.0.0.1:1242/grafana-dashboard.json)**. Крім того, ви також можете забрати файл JSON з нашого **[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)**.