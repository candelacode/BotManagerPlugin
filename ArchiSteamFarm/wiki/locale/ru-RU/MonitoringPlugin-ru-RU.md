# Плагин мониторинга

`MonitoringPlugin` является официальным ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, который позволяет отслеживать процесс ASF через **[Prometheus](https://prometheus.io)** базу данных временных рядов.

---

## Скриншоты

<details>
  <summary>Раскрыть</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Требования

Из-за **[технических ограничений](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)** для этого плагина требуется `generic` вариант ASF.

---

## Активация плагина

ASF **не** поставляется в комплекте `MonitoringPlugin` по умолчанию, однако он включен в качестве дополнения в каждом релизе ASF. Загрузите плагин с официального **[релиза](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**, который соответствует вашей версии ASF, а затем создайте выделеннyю папку`plugins/ArchiSteamFarm.OfficialPlugins.Monitoring` для плагина, и, наконец, распакуйте архив там.

При следующем запуске ASF логи указывают, что плагин был успешно загружен через стандартный механизм ASF регистрации. Вы также можете проверить это, перейдя по ссылке `/Api/metrics` в интерфейсе IPC. Если вы используете пароль IPC, вам понадобится соответствующая авторизация, например добавить `?password=<YourIPCPassword>` к адресу`/Api/metrics`. Контент, который вы видите должен выглядеть примерно так:

```text
# TYPE asf_build_info gauge
# HELP asf_build_info Информация о сборке ASF в виде значений меток
asf_build_info{variant="source",version="6.0.2. "} 1 1713715703686

# TYPE asf_runtime_info gauge
# HELP asf_runtime_info Информация о работе ASF в виде значений меток
asf_runtime_info{фреймворк=". ET 8.0.4",operating_system="Debian GNU/Linux trixie/sid",runtime="linux-x64"} 1 1713715703686
(...)
```

Метрики, касающиеся ASF и ботов, в их имени выделены префикс `asf_`. Другие метрики, например, относительно .NET runtime или `HttpClient` ASF автоматически генерируются на основе универсальных правил .NET процесса и не содержат такого префикса.

---

## Настройка Prometheus

Как только вы подтвердите правильность работы плагина, вы можете добавить конфигурацию scrape к вашему **[Prometheus](https://prometheus.io)** как таковую:

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

Естественно, вам нужно убедиться, что ваш хостинг **[Prometheus](https://prometheus.io)** способен достичь IPC интерфейса ASF, соответственно адаптируйте `password` и `targets`. Если у вас нет пароля IPC (который не рекомендуется), вы можете пропустить добавление раздела `params`. В случае, если вы запускаете несколько ASF экземпляров с различными IPC паролями, вы можете добавить дополнительные конфигурации обломков, по одному на один случай, так как параметры запроса не могут быть заданы на каждую целевую основу. Иначе вы можете объявить несколько `targets`, если они разделяют один и тот же пароль.

---

## Панель Grafana

Как только ваши метрики собраны Prometheus, можно использовать **[Grafana](https://grafana.com)** для визуализации. Плагин поставляется с `/grafana-dashboard. файл son`, обслуживаемый стандартными механизмами IPC, поэтому при условии, что вы запустили ваш экземпляр ASF с настройками по умолчанию, вы можете скачать его **[here](http://127.0.0.1:1242/grafana-dashboard.json)**. Кроме того, вы также можете захватить файл JSON из нашего **[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)**.