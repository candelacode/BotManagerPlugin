# Sicurezza

## Cifratura

ASF attualmente supporta i seguenti metodi di crittografia come una definizione di `ECryptoMethod`:

| Valore | Nome                        |
| ------ | --------------------------- |
| 0      | PlainText                   |
| 1      | AES                         |
| 2      | ProtectedDataForCurrentUser |
| 3      | Variabile Ambientale        |
| 4      | File                        |

La descrizione esatta e il confronto di loro è disponibile di seguito.

### Configurazione

Al fine di generare password crittografata, ad es. per l'uso di `SteamPassword` , dovresti eseguire il comando `crittografato` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** con la crittografia appropriata che hai scelto e la tua password originale di testo semplice. In seguito, inserisci la stringa cifrata che hai come `SteamPassword` configurazione del bot, e infine modificare `PasswordFormat` in quello che corrisponde al metodo di crittografia scelto. Alcuni formati non richiedono il comando `crittografato` , per esempio `EnvironmentVariable` or `File`, basta inserire un percorso appropriato per loro.

---

### `PlainText`

Questo è il modo più semplice e insicuro di memorizzare una password, definita come `ECryptoMethod` di `0`. ASF prevede che la stringa sia un testo semplice - una password nella sua forma diretta. È il più facile da usare, e 100% compatibile con tutte le configurazioni, quindi è un modo predefinito di memorizzare segreti, totalmente insicuro per lo stoccaggio sicuro.

---

### `AES`

Considerato sicuro dagli standard di oggi, Il modo **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** di memorizzare la password è definito come `ECryptoMethod` di `1`. ASF prevede che la stringa sia una sequenza **[base64 codificata](https://en.wikipedia.org/wiki/Base64)** di caratteri con conseguente array di byte crittografato da AES dopo la traduzione, che poi dovrebbe essere decriptato utilizzando incluso **[vettore di inizializzazione](https://en.wikipedia.org/wiki/Initialization_vector)** e chiave di crittografia ASF.

Il metodo di cui sopra garantisce la sicurezza finché l'attaccante non conosce la chiave di crittografia ASF che viene utilizzata per la decrittazione e la crittografia delle password. ASF ti permette di specificare la chiave tramite `--cryptkey` **[argomento da riga di comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, che dovresti usare per la massima sicurezza. Se decidi di ometterlo, ASF userà la propria chiave che è **conosciuta** e codificata in hardcoded nell'applicazione, significa che chiunque può invertire la crittografia ASF e ottenere la password decifrata. Richiede ancora qualche sforzo e non è così facile da fare, ma possibile, ecco perché dovresti quasi sempre usare la crittografia `AES` con la tua `--cryptkey` che è tenuta in segreto. Il metodo AES utilizzato in ASF fornisce sicurezza che dovrebbe essere soddisfacente ed è un equilibrio tra semplicità di `PlainText` e complessità di `ProtectedDataForCurrentUser`, ma è altamente raccomandato usarlo con `personalizzato --cryptkey`.

Se usato correttamente (lungo, personalizzato `--cryptkey`), garantisce una sicurezza molto elevata per l'archiviazione sicura.

---

### `ProtectedDataForCurrentUser`

Considerato sicuro dagli standard di oggi, Il modo **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** di memorizzare la password è definito come `ECryptoMethod` di `2`. Il vantaggio principale di questo metodo è allo stesso tempo il principale svantaggio - invece di utilizzare la chiave di crittografia (come in `AES`), i dati sono crittografati utilizzando le credenziali di accesso dell'utente attualmente loggato, il che significa che è possibile decifrare i dati **solo** sulla macchina su cui è stato crittografato, e in aggiunta a quello, **solo** da parte dell'utente che ha emesso la crittografia.

Questo assicura che anche se invii il tuo intero bot `. son` con crittografato `SteamPassword` che utilizza questo metodo per qualcun altro, non saranno in grado di decifrare la password senza accesso diretto al tuo PC. Si tratta di una misura di sicurezza eccellente, ma al tempo stesso presenta un grave svantaggio di essere meno compatibile, poichè la password crittografata utilizzando questo metodo sarà incompatibile con qualsiasi altro utente così come la macchina, tra cui **tuo proprio** se decidi di e. . reinstallare il sistema operativo. Questo è il metodo consigliato se non è necessario accedere alle configurazioni da nessuna macchina diversa dalla propria, e che anche voi non avete bisogno di compatibilità cross-macchina.

**Si prega di notare che questa opzione è disponibile solo per le macchine con sistema operativo Windows a partire da ora.**

---

### `Variabile Ambientale`

Memory-based storage definito come `ECryptoMethod` of `3`. ASF leggerà la password dalla variabile di ambiente con il nome specificato nel campo password (ad esempio `SteamPassword`). Ad esempio, impostando `SteamPassword` su `ASF_PASSWORD_MYACCOUNT` e `PasswordFormat` su `3` ASF valuterà la variabile di ambiente `${ASF_PASSWORD_MYACCOUNT}` e utilizzerà qualsiasi variabile assegnata come password dell'account.

Ricorda di assicurarsi che le variabili d'ambiente del processo ASF non siano accessibili agli utenti non autorizzati, come che sconfigge l'intero scopo di utilizzare questo metodo.

---

### `File`

Archiviazione basata su file (forse al di fuori della directory di configurazione ASF) definita come `ECryptoMethod` of `4`. ASF leggerà la password dal percorso del file specificato nel campo password (ad esempio `SteamPassword`). Il percorso specificato può essere assoluto o relativo alla posizione "home" di ASF (la cartella con la directory `config` all'interno, considerando `--path` **[argomento a riga di comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). Questo metodo può essere utilizzato per esempio con **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**, che creano tali file per l'uso, ma può anche essere utilizzato al di fuori di Docker se si crea il file appropriato da soli. Ad esempio, impostando `SteamPassword` su `/etc/secrets/MyAccount. ass` and `PasswordFormat` to `4` farà leggere ASF `/etc/secrets/MyAccount. ass` e utilizzare tutto ciò che è scritto su quel file come password dell'account.

Ricordati di assicurarsi che il file contenente la password non sia leggibile da utenti non autorizzati, in quanto ciò vanifica l'intero scopo di utilizzare questo metodo.

---

## Raccomandazioni di crittografia

Se la compatibilità non è un problema per te, e stai bene con il modo in cui funziona il metodo `ProtectedDataForCurrentUser` , è l'opzione **consigliata** di memorizzare la password in ASF, in quanto fornisce la migliore sicurezza e convenienza. Il metodo `AES` è una buona scelta per le persone che vogliono ancora utilizzare le loro configurazioni su qualsiasi macchina desiderata, mentre `PlainText` è il modo più semplice di memorizzare la password, se non ti dispiace che qualcuno può guardare nel file di configurazione JSON.

Tieni presente che tutti i metodi di crittografia sono considerati **insicuri** se l'attaccante ha accesso al tuo PC. ASF deve essere in grado di decifrare le password crittografate, e se il programma in esecuzione sulla vostra macchina è in grado di farlo, quindi qualsiasi altro programma in esecuzione sulla stessa macchina sarà in grado di farlo, anche. `ProtectedDataForCurrentUser` è la variante più sicura come **anche altri utenti che utilizzano lo stesso PC non saranno in grado di decifrarlo**, ma è ancora possibile decifrare i dati se qualcuno è in grado di rubare le credenziali di accesso e informazioni sulla macchina in aggiunta al file di configurazione ASF.

For advanced setups, you can utilize `EnvironmentVariable` and `File`. Hanno un uso limitato, la `Variabile Ambientale` sarà una buona idea se si preferisce ottenere password attraverso una sorta di soluzione personalizzata e memorizzarla esclusivamente in memoria, mentre `File` è buono per esempio con **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. Entrambi sono non crittografati comunque, in modo da fondamentalmente spostare il rischio dal file di configurazione ASF a qualsiasi cosa si sceglie da quei due.

Oltre ai metodi di cifratura sopra descritti, è possibile anche evitare di specificare completamente le password, ad esempio come `SteamPassword` utilizzando una stringa vuota o `null`. ASF ti chiederà la password quando è richiesta, e non salvarlo da nessuna parte, ma tenere in memoria del processo in esecuzione, fino a quando non lo si chiude. Pur essendo il metodo più sicuro di trattare con le password (non vengono salvate da nessuna parte), è anche il più fastidioso come è necessario inserire la password manualmente su ogni esecuzione di ASF (quando è richiesto). Se questo non è un problema per te, questa è la tua scommessa migliore in termini di sicurezza, in quanto non puoi perdere qualcosa che non esiste.

---

## Decifratura

ASF non supporta alcun modo di decifrare le password già crittografate, poiché i metodi di decifratura sono utilizzati solo internamente per accedere ai dati all'interno del processo. Se si desidera ripristinare la procedura di cifratura, ad es. per spostare ASF su un'altra macchina quando si utilizza `ProtectedDataForCurrentUser`, quindi ripetere semplicemente la procedura dall'inizio nel nuovo ambiente.

---

## Hashing

ASF attualmente supporta i seguenti metodi di hashing come definizione di `EHashingMethod`:

| Valore | Nome      |
| ------ | --------- |
| 0      | PlainText |
| 1      | Cripta    |
| 2      | Pbkdf2    |

La descrizione esatta e il confronto di loro è disponibile di seguito.

### Configurazione

Per generare un hash, ad es. per l'uso di `IPCPassword` , è necessario eseguire il comando `hash` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** con l'appropriato metodo di hashing scelto e la password originale di testo semplice. In seguito, metti la stringa hash che hai ottenuto come proprietà di configurazione `IPCPassword` ASF, e infine cambiare `IPCPasswordFormat` a quello che corrisponde al metodo di hashing scelto.

---

### `PlainText`

Questo è il modo più semplice e insicuro di hashing di una password, definita come `EHashingMethod` of `0`. ASF genererà hash che corrisponde all'input originale. È il più facile da usare, e 100% compatibile con tutte le configurazioni, quindi è un modo predefinito di memorizzare segreti, totalmente insicuro per lo stoccaggio sicuro.

---

### `Cripta`

Considerato sicuro dagli standard di oggi, Il modo **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** di hashing della password è definito come `EHashingMethod` di `1`. ASF utilizzerà l'implementazione `SCrypt` utilizzando i blocchi `8` , `8192` iterazioni, `32` lunghezza hash e chiave di crittografia come un sale per generare la gamma di byte. I byte risultanti saranno poi codificati come stringa **[base64](https://en.wikipedia.org/wiki/Base64)**.

ASF ti permette di specificare il sale per questo metodo tramite `--cryptkey` **[argomento a riga di comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, che si dovrebbe utilizzare per la massima sicurezza. Se decidi di ometterlo, ASF userà la propria chiave che è **conosciuta** e codificata in hardcoded nell'applicazione, il significato di hashing sarà meno sicuro.

Se utilizzato correttamente (sale personalizzato, password lunga), garantisce una sicurezza molto elevata per la conservazione sicura.

---

### `Pbkdf2`

Considerato debole dagli standard attuali, Il modo **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** di hashing della password è definito come `EHashingMethod` di `2`. ASF utilizzerà l'implementazione `Pbkdf2` utilizzando le iterazioni `10000` , `32` lunghezza hash e chiave di crittografia come sale, con `SHA-256` come algoritmo hmac. I byte risultanti saranno poi codificati come stringa **[base64](https://en.wikipedia.org/wiki/Base64)**.

ASF ti permette di specificare il sale per questo metodo tramite `--cryptkey` **[argomento a riga di comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, che si dovrebbe utilizzare per la massima sicurezza. Se decidi di ometterlo, ASF userà la propria chiave che è **conosciuta** e codificata in hardcoded nell'applicazione, il significato di hashing sarà meno sicuro.

---

## Raccomandazioni hashing

Se vuoi usare un metodo di hashing per memorizzare alcuni segreti, come `IPCPassword`, si consiglia di utilizzare `SCrypt` con sale personalizzato, in quanto fornisce una sicurezza molto decente contro tentativi brute-forcing.

`Pbkdf2` è offerto solo per motivi di compatibilità, principalmente perché abbiamo già un lavoro (e necessario) implementazione di esso per altri casi di uso su piattaforma Steam (e. . perni parentali). È ancora considerato sicuro, ma debole rispetto alle alternative (ad esempio `SCrypt`).