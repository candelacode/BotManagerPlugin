# MonitoringPlugin

`MonitoringPlugin` é um ASF oficial **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, o que permite monitorar o processo do ASF através de **[Prometheus](https://prometheus.io)** banco de dados de séries de tempo.

---

## Screenshots

<details>
  <summary>Mostrar</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Requisitos

Devido a **[restrições técnicas](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)**, este plugin requer a variante `genérica` do ASF.

---

## Ativando o plugin

O ASF **não** vem com o `MonitoringPlugin` agrupado por padrão, no entanto, ele está incluso como adição opcional toda vez que ele for lançado pelo ASF. Baixe o plugin do **oficial**[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)\*\* que corresponde à sua versão do ASF, então crie um `plugins/ArchiSteamFarm dedicado. Diretório fficialPlugins.Monitorando` para o plugin e finalmente extrair o arquivo lá.

Na próxima inicialização do ASF, os logs indicarão que o plugin foi carregado com sucesso através do mecanismo padrão de registro do ASF. Você também pode verificar isso navegando até a URL `/Api/metrics` na sua interface IPC. Se você está usando a senha IPC, você precisará de autorização adequada, acrescentando `?password=<YourIPCPassword>` à URL `/Api/metrics`. O conteúdo que você vê deve se parecer com o mesmo conteúdo abaixo:

```text
# TYPE asf_build_info gauge
# HELP asf_build_info Build informações sobre o ASF em forma de rótulo valores
asf_build_info{variant="source",version="6.0.2. "} 1 1713715703686

# TYPE asf_runtime_info gauge
# HELP asf_runtime_info Runtime sobre o ASF no formato dos valores de rótulo
asf_runtime_info{framework=". ET 8.0.4",operating_system="Trixame do GNU/Linux",runtime="linux-x64"} 1 1713715703686
(...)
```

Métricas do ASF e os bots dedicaram o prefixo `asf_` em seus nomes. Outras métricas, por exemplo, sobre o tempo de execução .NET ou o `HttpClient` do ASF são geradas automaticamente com base nas regras de processo .NET universais e não carregam esse prefixo.

---

## Configuração do Prometheus

Uma vez que você verificou que o plugin está funcionando corretamente, você pode adicionar uma configuração scrape para sua **[Prometheus](https://prometheus.io)** como tal:

```yaml
scrape_configs:
  - job_name: ArchiSteamFarm
    metrics_path: /Api/metrics
    params:
      senha:
        - YourIPCPassword
    static_configs:
      - alvos:
          - 127.0.1:1242
```

Naturalmente, você precisa garantir que sua instância hospedada **[Prometheus](https://prometheus.io)** seja capaz de acessar a interface IPC do ASF, adaptar `password` e `alvo` de acordo com sua utilização. Se você não tem a definição de senha IPC (o que não é recomendado), você pode pular a adição da seção `params`. Caso você esteja executando várias instâncias do ASF com diferentes senhas IPC, você pode adicionar configurações adicionais de scrape um por exemplo, já que os parâmetros de consulta não podem ser definidos para uma base por destino. Caso contrário, você pode declarar vários `alvos` se eles compartilharem a mesma senha.

---

## Painel do Grafana

Uma vez que suas métricas são coletadas por Prometheus, é possível usar **[Grafana](https://grafana.com)** para visualização. A extensão vem com `/grafana-dashboard. arquivo son` servido pelos mecanismos padrão do IPC, então assumindo que você está executando sua instância ASF com as configurações padrão você pode baixá-lo **[here](http://127.0.0.1:1242/grafana-dashboard.json)**. Como alternativa, você também pode pegar o arquivo JSON do nosso **[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)** também.