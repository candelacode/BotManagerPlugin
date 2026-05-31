# Πρόσθετο Παρακολούθησης

Το `MonitoringPlugin` είναι μια επίσημη ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, η οποία σας επιτρέπει να παρακολουθείτε τη διαδικασία ASF μέσω **[Prometheus](https://prometheus.io)** της βάσης δεδομένων χρονοσειρών.

---

## Στιγμιότυπα οθόνης

<details>
  <summary>Show</summary>

![screenshot](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/46778d0b-1ee6-4dab-8645-eb179f09468e)

</details>

---

## Απαιτήσεις

Λόγω του **[τεχνικών περιορισμών](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#native-dependencies)**, αυτό το πρόσθετο απαιτεί την "γενική" παραλλαγή του ASF.

---

## Ενεργοποίηση της πρόσθετης λειτουργίας

Το ASF **δεν** έρχεται με το `MonitoringPlugin` ομαδοποιημένο από προεπιλογή, ωστόσο, περιλαμβάνεται ως προαιρετική προσθήκη σε κάθε έκδοση ASF. Κατεβάστε το πρόσθετο από το επίσημο **[release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** που ταιριάζει με την έκδοση ASF και στη συνέχεια δημιουργήστε ένα ειδικό `plugins/ArchiSteamFarm. fficialPlugins.Monitoring` directory για το plugin, και τελικά εξαγάγετε την αρχειοθήκη εκεί.

Στην επόμενη εκκίνηση του ASF, τα αρχεία καταγραφής θα υποδηλώνουν ότι το plugin έχει φορτωθεί με επιτυχία μέσω του τυπικού μηχανισμού καταγραφής ASF. Μπορείτε επίσης να το επιβεβαιώσετε αυτό μεταβαίνοντας στο URL `/Api/metrics` στη διεπαφή IPC. Αν χρησιμοποιείτε κωδικό πρόσβασης IPC, θα χρειαστείτε κατάλληλη εξουσιοδότηση, π.χ. προσάρτηση `?password=<YourIPCPassword>` στο URL `/Api/metrics`. Το περιεχόμενο που βλέπετε θα πρέπει να μοιάζει με το παρακάτω:

```text
# TYPE asf_build_info gauge
# HELP asf_build_info Κατασκευάστε πληροφορίες σχετικά με το ASF σε μορφή τιμών ετικετών
asf_build_info{variant="source",version="6.0.2. "} 1 1713715703686

# TYPE asf_ runtime_info gauge
# HELP asf_ runtime_info Πληροφορίες για το ASF σε μορφή ετικετών
asf_runtime_info{framework=". ET 8. 0. 4",operating_system="Debian GNU/ Linux trixie/sid",runtime="linux- x64"} 1 1713715703686
(...)
```

Οι μετρήσεις σχετικά με το ASF και τα bots έχουν αφιερώσει το πρόθεμα `asf_` στο όνομά τους. Άλλες μετρήσεις, π.χ. σχετικά με το χρόνο εκτέλεσης .NET ή το `HttpClient` του ASF δημιουργούνται αυτόματα με βάση καθολικούς κανόνες .NET διεργασιών και δεν φέρουν τέτοιο πρόθεμα.

---

## Prometheus config

Μόλις επαληθεύσετε ότι το πρόσθετο λειτουργεί σωστά, μπορείτε να προσθέσετε μια παραμετροποίηση απόξεσης στην παρουσία **[Prometheus](https://prometheus.io)** ως έχει:

```yaml
scrape_configs:
  - job_name: ArchiSteamFarm
    metrics_path: /Api/metrics
    params:
      password:
        - YourIPCPassword
    static_configs:
      - στόχοι:
          - 127.0.0.1:1242
```

Φυσικά, πρέπει να διασφαλίσετε ότι η παρουσία σας φιλοξενείται **[Prometheus](https://prometheus.io)** είναι σε θέση να φτάσει στη διεπαφή IPC του ASF, προσαρμόζει αναλόγως τους «κωδικούς» και τους «στόχους» στη χρήση σας. Εάν δεν έχετε ορίσει κωδικό πρόσβασης IPC (το οποίο δεν συνιστάται), μπορείτε να παραλείψετε την προσθήκη της ενότητας `params`. Σε περίπτωση που εκτελείτε πολλαπλές παρουσίες ASF με διαφορετικούς κωδικούς πρόσβασης IPC, μπορείτε να προσθέσετε πρόσθετες ρυθμίσεις απόξεσης, ένα ανά παράδειγμα, καθώς οι παράμετροι του ερωτήματος δεν μπορούν να οριστούν ανά στόχο. Διαφορετικά, μπορείτε να δηλώσετε αρκετούς `targets` αν έχουν τον ίδιο κωδικό πρόσβασης.

---

## Πίνακας εργαλείων Grafana

Once your metrics are gathered by Prometheus, it's possible to use **[Grafana](https://grafana.com)** for visualization. Το plugin έρχεται με `/grafana-ταμπλό. son` αρχείο που εξυπηρετείται από τυπικούς μηχανισμούς IPC, οπότε υποθέτοντας ότι εκτελείτε την παρουσία σας ASF με προεπιλεγμένες ρυθμίσεις, μπορείτε να το κατεβάσετε **[here](http://127.0.0.1:1242/grafana-dashboard.json)**. Alternatively, you can also grab the JSON file from our **[repository](https://raw.githubusercontent.com/JustArchiNET/ArchiSteamFarm/main/ArchiSteamFarm.OfficialPlugins.Monitoring/overlay/all/www/grafana-dashboard.json)** as well.