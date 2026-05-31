# Seuranta Liitännäinen

`MonitoringPlugin` on virallinen ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, jonka avulla voit seurata ASF-prosessia **[Prometheus](https://prometheus.io)** aikasarjatietokannan kautta.

---

## Kuvakaappaukset

<details>
  <summary>Näytä</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Vaatimukset

Koska **[teknisiä rajoitteita](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)**, tämä liitännäinen vaatii ASF `generic`-variantin.

---

## Liitännäisen käyttöönotto

ASF ei **ei** mukana `MonitoringPlugin`-nipussa oletuksena, mutta se sisältyy valinnaisena lisänä jokaisessa ASF-julkaisussa. Lataa lisäosa viralliselta **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** joka vastaa ASF-versiota, ja luo sitten oma `plugins/ArchiSteamFarm. fficialPlugins.Monitoring` hakemisto plugin, ja lopuksi pura arkisto siellä.

Seuraavan käynnistyksen ASF lokit osoittavat, että plugin on onnistuneesti ladattu standardin ASF kirjausmekanismi. Voit myös tarkistaa tämän navigoimalla osoitteeseen `/Api/metrics` URL-osoitteeseen IPC-käyttöliittymässäsi. Jos käytät IPC-salasanaa, tarvitset oikean valtuutuksen, esim. lisäämällä `?password=<YourIPCPassword>` `/Api/metrics` URL. Näyttämäsi sisältö pitäisi näyttää samalta kuin alla:

```text
# TYPE asf_build_info gauge
# HELP asf_build_info Rakenna tietoa ASF:sta tarran arvojen muodossa
asf_build_info{variant="source",version="6.0.2. "} 1 1713715703686

# TYPE asf_runtime_info gauge
# HELP asf_runtime_info Runtime information about ASF in label values
asf_runtime_info{framework=". ET 8.0.4",operating_system="Debian GNU/Linux trixie/sid",runtime="linux-x64"} 1 1713715703686
(...)
```

ASF:ää ja bootteja koskevat mittarit ovat omistaneet nimessään `asf_`-etuliitteen. Muut mittarit, esim. .NET runtime tai ASF `HttpClient`, generoidaan automaattisesti universaalin .NET prosessin sääntöjen perusteella eivätkä ne kanna tällaista etuliitettä.

---

## Prometheus config

Kun olet varmistanut, että liitännäinen toimii oikein, voit lisätä raaputusmäärityksen **[Prometheus](https://prometheus.io)** esimerkiksi näin:

```yaml
scrape_configs:
  - job_name: ArchiSteamFarm
    metrics_path: /Api/metrics
    params:
      salasana:
        - YourIPCPassword
    static_configs:
      - kohteet:
          - 127.0.1:1242
```

Luonnollisesti sinun täytyy varmistaa, että isännöi **[Prometheus](https://prometheus.io)** instanssi pystyy saavuttamaan ASF:n IPC-käyttöliittymän, sovittaa `password` ja `targets` sen mukaisesti käyttöösi. Jos sinulla ei ole IPC-salasanaa (jota ei suositella), voit ohittaa `params`-osion lisäämisen. Jos käytät useita ASF instansseja eri IPC salasanoja, voit lisätä ylimääräisiä kaakaoasetuksia, yksi kutakin esimerkkiä kohden, koska kyselyn parametreja ei voida määrittää tavoitekohtaisesti. Muussa tapauksessa voit ilmoittaa useita `kohteita`, jos niillä on sama salasana.

---

## Grafana kojelauta

Kun mittauksesi on koottu Prometheuksen toimesta, on mahdollista käyttää **[Grafana](https://grafana.com)** visualisointiin. Liitännäisessä on `/grafana-kojelauta. son` tiedosto palvelee standardin IPC mekanismit, joten olettaen, että käytät ASF instanssia oletusasetukset, voit ladata sen **[here](http://127.0.0.1:1242/grafana-dashboard.json)**. Vaihtoehtoisesti voit myös napata JSON tiedoston meidän **[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)** myös.