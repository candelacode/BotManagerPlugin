# Configurazione

Questa pagina è dedicata alla configurazione di ASF. Serve da documentazione completa della cartella `config`, consentendoti di sintonizzare ASF alle tue esigenze.

* **[Introduzione](#introduction)**
* **[ConfigGenerator basato sul web](#web-based-configgenerator)**
* **[Configurazione di ASF-ui](#asf-ui-configuration)**
* **[Configurazione manuale](#manual-configuration)**
* **[Configurazione globale](#global-config)**
* **[Configurazione bot](#bot-config)**
* **[Struttura dei file](#file-structure)**
* **[Mappatura JSON](#json-mapping)**
* **[Mappatura di compatibilità](#compatibility-mapping)**
* **[Compatibilità delle configurazioni](#configs-compatibility)**
* **[Ricarica automatica](#auto-reload)**

---

## Introduzione

La configurazione di ASF è divisa in due parti principali: configurazione globale (processo) e configurazione di ogni bot. Ogni bot ha il proprio file di configurazione denominato `BotName.json` (dove `BotName` è il nome del bot), mentre la configurazione globale di ASF (processo) è un file singolo denominato `ASF.json`.

Un bot è un singolo profilo di steam che prende parte al processo di ASF. Per funzionare propriamente, ASF necessita di almeno **una** istanza di bot definita. Non esiste alcun limite imposto di istanze dei bot del processo, quindi puoi usare tanti bot (profili di Steam) quanto desideri.

ASF usa il formato **[JSON](https://en.wikipedia.org/wiki/JSON)** per memorizzare i suoi file di configurazione. È un formato comprensibile, leggibile e molto universale in cui puoi configurare il programma. Non preoccuparti però, non devi conoscere JSON per configurare ASF. L'ho solo menzionato nel caso volessi già creare configurazioni in massa di ASF con qualche sorta di script di bash.

La configurazione si può fare in diversi modi. Puoi usare il nostro **[ConfigGenerator basato sul web](https://justarchinet.github.io/ASF-WebConfigGenerator)**, ovvero un'app locale indipendente di ASF. Puoi usare il nostro frontend di IPC di **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** per la configurazione fatta direttamente in ASF. Infine, puoi sempre generare manualmente file di configurazione, seguendo la struttura fissa di JSON sotto specificata. Spiegheremo brevemente le opzioni disponibili.

---

## ConfigGenerator basato sul web

Lo scopo del nostro **[ConfigGenerator basato sul web](https://justarchinet.github.io/ASF-WebConfigGenerator)** è di fornirvi un frontend semplice usato per generare i file di configurazioned i ASF. Il ConfigGenerator basato sul web è basato al 100% sul client, a significare che i dettagli che inserisci non sono inviati da alcuna parte, ma solo elaborati localmente. Questo garantisce sicurezza e affidabilità, potendo funzionare anche **[offline](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** se volessi scaricare tutti i file ed eseguire `index.html` nel tuo browser preferito.

Il ConfigGenerator basato sul web è verificato per funzionare propriamente su Chrome e Firefox, ma dovrebbe funzionare propriamente in tutti i più popolari browser aventi javascript abilitato.

L'uso è abbastanza semplice: seleziona se vuoi generare la configurazione di `ASF` o del `Bot` passando alla scheda adatta, assicurati di aver scelto la versione del file di configurazione corrispondente alla tua versione di ASF, poi inserisci tutti i dettagli e clicca il pulsante "scarica". Sposta questo file alla cartella `config` di ASF, sovrascrivendo i file esistenti se necessario. Ripeti per tutte le eventuali modifiche e riferisci al resto di questa sezione per spiegazioni di tutte le opzioni disponibili da configurare.

---

## Configurazione di ASF-ui

La nostra interfaccia IPC di **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** ti consente di configurare anche ASF, ed è la soluzione superiore per riconfigurare ASF dopo aver generato le configurazioni iniziali a causa del fatto che può modificare le configurazioni sul posto, a differenza del ConfigGenerator basato sul web che le genera staticamente.

Per usare ASF-ui, devi aver abilitato la nostra stessa interfaccia **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**. `IPC` è abilitato per impostazione predefinita, quindi è possibile accedervi subito, purché non sia stato disabilitato da solo.

Dopo aver lanciato il programma, naviga semplicemente all'**[indirizzo IPC](http://localhost:1242)** di ASF. Se tutto ha funzionato propriamente, da lì puoi anche modificare la configurazione di ASF.

---

## Configurazione manuale

In generale consigliamo fortemente di usare il nostro ConfigGenerator o ASF-ui, essendo molto più facile ed assicurandovi di non fare errori nella struttura JSON, ma se per qualche motivo non volete, allora potete anche creare configurazioni corrette manualmente. Controlla gli esempi di JSON qui sotto per un buon inizio nella struttura corretta, è possibile copiare il contenuto in un file e utilizzarlo come base per la configurazione. Dato che non stai utilizzando nessuno dei nostri frontend, assicurati che la tua configurazione sia **[valida](https://jsonlint.com)**, poiché ASF si rifiuterà di caricarlo se non può essere analizzato. Anche se è un JSON valido, dovete anche assicurarvi che tutte le proprietà siano di tipo adatto, come richiesto da ASF. Per una struttura idonea di JSON di tutti i campi disponibili, riferitevi alla sezione di **[mappatura di JSON](#json-mapping)** e la nostra documentazione sotto.

---

## Configurazione globale

La configurazione globale si trova nel file `ASF.json` e ha la seguente struttura:

```json
{
    "AutoRestart": true,
    "Blacklist": [],
    "CommandPrefix": "! ,
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "CurrentCulture": null,
    "Debug": falso,
    "DefaultBot": null,
    "FarmingDelay": 15,
    "FilterBadBots": true,
    "GiftsLimiterDelay": 1,
    "Headless": falso,
    "IdleFarmingPeriodo": 8,
    "InventarioLimiterDelay": 4,
    "IPC": true,
    "IPCPassword": null,
    "IPCPasswordFormat": 0,
    "LicenseID": null,
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldDuration": 15,
    "MinFarmingDelayAfterBlock": 60,
    "OptimizationMode": 0,
    "PluginsUpdateList": [],
    "PluginsUpdateMode": 0,
    "ShutdownIfPossibile": false,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Tutte le opzioni sono spiegate sotto:

### `AutoRestart`

Tipo `booleano` con valore predefinito di `true`. Questa proprietà definisce se ASF può eseguire un riavvio automatico quando necessario. Ci sono pochi eventi che lo richiederanno, come un aggiornamento di ASF (eseguito con il comando `UpdatePeriod` o `update`), nonché la modifica di configurazione `ASF.json`, il comando `restart` e simili. Tipicamente, il riavvio include due parti: la creazione del nuovo processo e la conclusione di quello corrente. Gran parte degli utenti dovrebbero non avere problemi per esso e mantenere tale proprietà con il valore predefinito di `true`, tuttavia, se state eseguendo ASF tramite il vostro script e/o con `dotnet`, potreste voler avere il controllo completo sull'avvio del processo ed evitare una situazione come avere l'esecuzione silenziosa in background di un nuovo processo ASF (riavviato) da qualche parte, e non in primo piano nello script, in uscita con il vecchio processo di ASF. Questo è specialmente importante considerando il fatto che il nuovo processo non sarà più il tuo figlio diretto, rendendoti incapace, per esempio, di usare l'input standard della console per esso.

Se questo è il caso, questa proprietà è specialmente per voi e potete impostarla a `false`. Tuttavia, tieni a mente che in tal caso **tu** sei responsabile del riavvio del processo. Questo è in qualche modo importante poiché ASF non sarà chiuso invece di generare il nuovo processo (es. dopo l'aggiornamento), quindi se non esiste logica da te aggiunta, semplicemente smetterà di funzionare finché non lo riavvierete. ASF esce sempre con il codice d'errore corretto che indica il successo (zero) o l'insuccesso (non zero), così puoi aggiungere logica adatta nel tuo script, evitando il riavvio automatico di ASF in caso di fallimento, o almeno creando una copia locale di `log.txt` per ulteriori analisi. Tieni anche a mente che il comando `restart` riavvierà sempre ASF indipendentemente da come questa proprietà è impostata, definendo il comportamento predefinito, mentre il comando `restart` riavvia sempre il processo. A meno che non abbiate motivo di disabilitare questa funzionalità, la dovreste tenere abilitata.

---

### `Blacklist`

Tipo `ImmutableHashSet<uint>` con valore predefinito vuoto. Come suggerisce il nome, questa proprietà globale di configurazione definisce gli appID (giochi) che saranno completamente ignorati dal processo automatico di agricoltura ASF. Purtroppo Steam ama bandiera estate / inverno vendita badge come "disponibile per le carte gocce", che confonde il processo di ASF facendo credere che si tratta di una selvaggina valida che dovrebbe essere coltivata. Se non ci fosse alcun tipo di lista nera, ASF alla fine "appesi" a coltivare un gioco che in realtà non è un gioco, e attendere infinitamente le carte cadono che non accadrà. La lista nera ASF ha lo scopo di contrassegnare quei distintivi come non disponibili per l'agricoltura, così possiamo silenziosamente ignorarli quando decidiamo cosa coltivare, e non cadere nella trappola.

ASF include due blacklist per impostazione predefinita - `SalesBlacklist`, che è codificato a chiave nel codice ASF e non è possibile modificare, e normale `Blacklist`, che è definito qui. `SalesBlacklist` is updated together with ASF version and typically includes all "bad" appIDs at the time of release, so if you're using up-to-date ASF then you do not need to maintain your own `Blacklist` defined here. Lo scopo principale di questa proprietà è quello di consentire la blacklisting nuovo, non noto al momento di ASF release appIDs, che non dovrebbe essere coltivato. Hardcoded `SalesBlacklist` è in fase di aggiornamento il più veloce possibile, quindi non è necessario aggiornare la tua `Blacklist` se stai utilizzando l'ultima versione di ASF, ma senza `Blacklist` saresti costretto ad aggiornare ASF per "continuare a funzionare" quando Valve rilascia un nuovo badge di vendita - Non voglio costringerti a utilizzare l'ultimo codice ASF, quindi questa proprietà è qui per permetterti di "fissare" ASF se per qualche motivo non vuoi, o non puoi, aggiornamento al nuovo hardcoded `SalesBlacklist` nella nuova versione di ASF, ma si desidera mantenere il vostro vecchio ASF in esecuzione. A meno che non si abbia un motivo **forte** per modificare questa proprietà, si dovrebbe mantenere come predefinito.

Se invece stai cercando una blacklist basata su bot, dai un'occhiata a `fb`, `fbadd` e `fbrm` **[comandi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `ComandoPrefisso`

Tipo `stringa` con valore predefinito di `!`. Questa proprietà specifica il prefisso **sensibile alle maiuscole e minuscole** utilizzato per i comandi **[di ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. In altre parole, questo è ciò che è necessario per precedere ogni comando ASF al fine di farti ascoltare ASF. È possibile impostare questo valore su `null` o vuoto per rendere ASF non utilizzare alcun prefisso di comando, in questo caso si immettono comandi con i loro identificatori semplici. Tuttavia, in questo modo diminuirà potenzialmente le prestazioni di ASF poiché ASF è ottimizzato per non analizzare ulteriormente il messaggio se non inizia con `CommandPrefix` - se intenzionalmente decidi di non usarlo, ASF sarà costretto a leggere tutti i messaggi e a rispondere a loro, anche se non sono comandi ASF. Pertanto è consigliabile continuare ad utilizzare un po 'di `CommandPrefix`, come `/` se non ti piace il valore predefinito di `!`. Per coerenza, `CommandPrefix` influisce sull'intero processo ASF. A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.

---

### `ConfermeLimiterDelay`

Tipo `byte` con valore predefinito di `10`. ASF assicurerà che ci saranno almeno i secondi `ConfermeLimiterDelay` tra due conferme 2FA consecutive recuperando le richieste per evitare di innescare il limite di velocità - quelle sono utilizzate da **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** durante e. . `2faok` comando, così come su base necessaria durante l'esecuzione di varie operazioni di trading. Il valore predefinito è stato impostato in base ai nostri test e non dovrebbe essere abbassato se non si desidera eseguire problemi. A meno che non si abbia un motivo **forte** per modificare questa proprietà, si dovrebbe mantenere come predefinito.

---

### `ConnessionTimeout`

Tipo `byte` con valore predefinito di `90`. Questa proprietà definisce timeout per varie azioni di rete effettuate da ASF, in secondi. In particolare, `ConnectionTimeout` definisce il timeout in secondi per le richieste HTTP e IPC, `ConnectionTimeout / 10` definisce il numero massimo di battiti cardiaci falliti, mentre `ConnectionTimeout / 30` definisce il numero di minuti che consentiamo per la richiesta iniziale di connessione di rete di Steam. Il valore predefinito di `90` dovrebbe andare bene per la maggior parte delle persone, tuttavia, se hai una connessione di rete piuttosto lenta o PC, potresti voler aumentare questo numero a qualcosa di più alto (come `120`). Tieni presente che valori più grandi non risolveranno magicamente i server Steam lenti o addirittura inaccessibili, quindi non dovremmo aspettare infinitamente qualcosa che non succederà e semplicemente riprovare più tardi. La fissazione di questo valore troppo elevato comporterà un ritardo eccessivo nella cattura di problemi di rete, nonché una diminuzione delle prestazioni complessive. Impostando questo valore troppo basso diminuirà la stabilità e le prestazioni complessive, in quanto ASF annullerà la richiesta valida ancora in fase di elaborazione. Pertanto la fissazione di questo valore inferiore al valore predefinito non ha alcun vantaggio in generale, siccome i server Steam tendono ad essere super lenti di tanto in tanto, e potrebbe richiedere più tempo per analizzare le richieste di ASF. Il valore predefinito è un equilibrio tra credere che la nostra connessione di rete sia stabile, e dubitare della rete di Steam per gestire la nostra richiesta in un determinato timeout. Se si desidera rilevare i problemi prima e rendere ASF riconnettersi/rispondere più velocemente, il valore predefinito dovrebbe fare (o leggermente sotto, come `60`, rendendo ASF meno paziente). Se invece si nota che ASF sta funzionando in problemi di rete, come richieste fallite, battiti cardiaci persi o connessione a Steam interrotto, probabilmente ha senso aumentare questo valore se sei sicuro che è **non** causata dalla tua rete, ma da Steam stesso, come aumentare i timeout rende ASF più "paziente" e non decidere di ricollegarsi subito.

Una situazione di esempio che può richiedere un aumento di questa proprietà sta lasciando ASF per affrontare un enorme commercio offerte che possono richiedere buoni 2+ minuti per essere pienamente accettati e gestiti da Steam. Aumentando il timeout predefinito, ASF sarà più paziente e attendere più a lungo prima di decidere che il commercio non sta andando attraverso e abbandonare la richiesta iniziale.

Un'altra situazione potrebbe essere causata da una macchina molto lenta o connessione internet che richiede più tempo per gestire i dati che vengono trasmessi. Questa è una condizione piuttosto rara, in quanto la larghezza di banda della CPU/rete non è quasi mai una strozzatura, ma comunque una possibilità degna di essere menzionata.

In breve, il valore predefinito dovrebbe essere decente per la maggior parte dei casi, ma si può desiderare di aumentarlo se necessario. Ancora, andando molto al di sopra del valore predefinito non ha molto senso, dal momento che i timeout più grandi non risolveranno magicamente i server Steam inaccessibili. A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.

---

### `CurrentCulture`

Tipo `stringa` con valore predefinito `null`. Per impostazione predefinita, ASF tenta di utilizzare la lingua del sistema operativo e preferirà usare stringhe tradotte in quella lingua se disponibile. Questo è possibile grazie alla nostra comunità che cerca di **[localizzare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** ASF in tutte le lingue più popolari. Se per qualche motivo non vuoi usare la tua lingua madre del sistema operativo, è possibile utilizzare questa proprietà di configurazione per scegliere qualsiasi lingua valida che si desidera utilizzare. Per un elenco di tutte le culture disponibili, visitare **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** e cercare `Language tag`. È bello notare che ASF accetta entrambe le culture specifiche, come `"en-GB"`, ma anche neutrali, come `"en"`. La specificazione della coltura attuale influirà anche su altri comportamenti specifici per la coltura, come il formato valuta/data e simili. Si prega di notare che potrebbe essere necessario aggiungere pacchetti di font/lingua per visualizzare correttamente i caratteri specifici della lingua, se hai scelto cultura non nativa che ne fa uso. In genere si desidera utilizzare questa proprietà di configurazione se si preferisce ASF in inglese invece della lingua madre.

---

### `Eseguire il debug`

`bool` type with default value of `false`. Questa proprietà definisce se il processo deve essere eseguito in modalità debug. In modalità debug, ASF crea una directory speciale `debug` accanto alla configurazione ``, che tiene traccia di tutta la comunicazione tra i server ASF e Steam. Le informazioni di debug possono aiutare a individuare problemi brutti relativi alla rete e al flusso di lavoro generale di ASF. Oltre a questo, alcune routine di programma saranno molto più verbose, come `WebBrowser` che indica il motivo esatto per cui alcune richieste sono fallite - quelle voci sono scritte nel normale registro di ASF. **Non dovresti eseguire ASF in modalità Debug, a meno che non sia richiesto dallo sviluppatore**. L'esecuzione di ASF in modalità debug **riduce le prestazioni**, **influisce negativamente sulla stabilità** ed è **molto più prolisso in vari luoghi**, quindi dovrebbe essere utilizzato intenzionalmente **solo** , a breve termine, per il debug di un particolare problema, riprodurre il problema o ottenere maggiori informazioni su una richiesta fallita, e allo stesso modo, **non** per l'esecuzione normale del programma. Vedrai **molto** di nuovi errori, problemi, e eccezioni - assicurati di avere una conoscenza decente di ASF, Vapore e le sue stranezze se si decide di analizzare tutto ciò che voi stessi, come non tutto è rilevante.

**ATTENZIONE:** abilitando questa modalità include la registrazione delle informazioni **potenzialmente sensibili** come login e password che stai utilizzando per accedere a Steam (a causa della registrazione di rete). Questi dati sono scritti sia nella directory `debug` , sia nella directory standard `log. xt` (che ora è intenzionalmente molto più prolisso per registrare queste informazioni). Non dovresti pubblicare contenuti di debug generati da ASF in qualsiasi posizione pubblica, Lo sviluppatore di ASF dovrebbe sempre ricordarti di inviarlo alla sua e-mail, o ad altre posizioni sicure. Non stiamo memorizzando, né facendo uso di quei dettagli sensibili, sono scritti come parte delle routine di debug poiché la loro presenza potrebbe essere rilevante per il problema che ti sta interessando. Preferiremmo se non modificassi la registrazione di ASF in alcun modo, ma se sei preoccupato, sei libero di modificare questi dettagli sensibili in modo appropriato.

> La riduzione comporta la sostituzione dei dettagli sensibili, ad esempio con le stelle. Si dovrebbe evitare di rimuovere completamente le linee sensibili, in quanto la loro esistenza pura potrebbe essere rilevante e dovrebbe essere preservata.

---

### `DefaultBot`

Tipo `stringa` con valore predefinito `null`. In alcuni scenari ASF funziona con un concetto di bot predefinito responsabile per la gestione di qualcosa - ad esempio comandi IPC o console interattiva quando non si specifica il bot di destinazione. Questa proprietà consente di scegliere il bot predefinito responsabile per la gestione di tali scenari, mettendo il suo `BotName` qui. Se il bot dato non esiste, o si utilizza un valore predefinito di `null`, ASF sceglierà il primo bot registrato ordinato alfabeticamente invece. In genere si desidera utilizzare questa proprietà di configurazione se si desidera omettere l'argomento `[Bots]` nei comandi IPC e console interattiva, e scegli sempre lo stesso bot di quello predefinito per tali chiamate.

---

### `FarmingDelay`

Tipo `byte` con valore predefinito di `15`. Affinché ASF funzioni, controllerà la partita attualmente coltivata ogni `FarmingDelay` minuti, se forse ha già rilasciato tutte le carte. Impostare questa proprietà troppo bassa può causare l'invio di una quantità eccessiva di richieste di vapore, mentre l'impostazione troppo alta può portare a ASF ancora "agricoltura" titolo dato fino a `FarmingDelay` minuti dopo che è completamente coltivato. Il valore predefinito dovrebbe essere eccellente per la maggior parte degli utenti, ma se hai molti bot in esecuzione, potresti considerare di aumentarlo a qualcosa come `30` minuti per limitare le richieste di vapore inviate. È bello notare che ASF utilizza il meccanismo basato su eventi e controlla la pagina del badge di gioco su ogni elemento Steam caduto, quindi in generale **non abbiamo nemmeno bisogno di controllarlo in intervalli di tempo fissi**, ma poiché non ci fidiamo completamente della rete di Steam - controlliamo la pagina del badge del gioco comunque, se non lo abbiamo controllato attraverso la carta che viene lasciato cadere l'evento negli ultimi minuti `FarmingDelay` (nel caso in cui la rete Steam non ci informasse di elementi caduti o cose del genere). Supponendo che la rete di Steam funzioni correttamente, la diminuzione di questo valore **non migliorerà in alcun modo l'efficienza agricola**, mentre **aumenta significativamente l'overhead della rete** - si consiglia solo di aumentarlo (se necessario) da default di `15` minuti. A meno che non si abbia un motivo **forte** per modificare questa proprietà, si dovrebbe mantenere come predefinito.

---

### `FilterBadBots`

`bool` tipo con valore predefinito `true`. Questa proprietà definisce se ASF rifiuterà automaticamente le offerte commerciali ricevute da attori difettosi noti e contrassegnati. Per farlo, ASF comunicherà con il nostro server in base alla necessità di recuperare una lista di identificatori Steam nella lista nera. I bot elencati sono gestiti da persone che sono classificati dannosi per l'iniziativa ASF da noi, come quelli che violano il nostro **[codice di condotta](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, utilizzare funzionalità e risorse fornite da noi come **[`PublicListing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** per abusare e sfruttare altre persone, o stanno facendo attività criminali assolute, come il lancio di attacchi DDoS sul server. Dal momento che ASF ha una posizione forte sulla correttezza generale, l'onestà e la cooperazione tra i suoi utenti al fine di far prosperare l'intera comunità, questa proprietà è abilitata per impostazione predefinita, e quindi ASF filtra i bot che abbiamo classificato come dannoso dai servizi offerti. A meno che tu non abbia un motivo **forte** per modificare questa proprietà, ad esempio in disaccordo con la nostra dichiarazione e intenzionalmente permettere a quei bot di operare (compreso lo sfruttamento dei tuoi account), dovresti tenerlo in modo predefinito.

---

### `GiftsLimiterDelay`

Tipo `byte` con valore predefinito di `1`. ASF garantirà che ci saranno almeno `GiftsLimiterDelay` secondi tra due richieste consecutive di gift/key/license handling (riscatto) per evitare di innescare il limite di tasso. In aggiunta a questo sarà utilizzato anche come limitatore globale per le richieste di lista di gioco, come quello emesso da `possiede il comando` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. A meno che non si abbia un motivo **forte** per modificare questa proprietà, si dovrebbe mantenere come predefinito.

---

### `Intestazione`

`bool` type with default value of `false`. Questa proprietà definisce se il processo deve essere eseguito in modalità headless. In modalità headless, ASF presuppone che sia in esecuzione su un server o in un altro ambiente non interattivo, quindi non tenterà di leggere alcuna informazione tramite input di console. Questo include dettagli su richiesta (credenziali account come codice 2FA, codice SteamGuard, password o qualsiasi altra variabile necessaria per il funzionamento di ASF), così come tutti gli altri input della console (come la console di comando interattiva). In altre parole, la modalità `Headless` è uguale alla sola lettura della console ASF. Questa impostazione è utile principalmente per gli utenti che eseguono ASF sui loro server, come invece di chiedere e. . per il codice 2FA, ASF interromperà silenziosamente l'operazione bloccando un account. A meno che non si esegue ASF su un server, e in precedenza si è confermato che ASF è in grado di operare in modalità non-headless, dovresti mantenere questa proprietà disabilitata. Qualsiasi interazione utente verrà negata quando in modalità headless, e i tuoi account non verranno eseguiti se richiedono **qualsiasi input di console** durante l'avvio. Questo è utile per i server, poiché ASF può interrompere il tentativo di accedere all'account quando richiesto per le credenziali, invece di aspettare (infinitamente) che l'utente fornisca quelli.

Abilitare questa modalità ti permetterà di fornire l'input di console richiesto con altri mezzi, ad es. ASF-ui (ASF API), o tramite il comando **[`in ingresso`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#input-command)**. Se non sei sicuro di come impostare questa proprietà, lasciala con il valore predefinito di `false`.

---

### `IdleFarmingPeriod`

Tipo `byte` con valore predefinito di `8`. Quando ASF non ha nulla da coltivare, controllerà periodicamente ogni `IdleFarmingPeriod` ore se forse l'account ha alcuni nuovi giochi da coltivare. Questa funzione non è necessaria quando si parla di nuovi giochi che stiamo ricevendo, in quanto ASF è abbastanza intelligente per controllare automaticamente le pagine del badge in questo caso. `IdleFarmingPeriod` è principalmente per situazioni come i vecchi giochi che abbiamo già aggiunto carte di trading. In questo caso non c'è evento, quindi ASF deve controllare periodicamente le pagine del distintivo se vogliamo avere questo coperto. Il valore di `0` disabilita questa funzione. Controlla anche: Preferenza `ShutdownOnFarmingFinished` in `FarmingPreferences`.

---

### `InventarioLimiterDelay`

Tipo `byte` con valore predefinito di `4`. ASF garantirà che ci saranno almeno `InventarioLimiterDelay` secondi tra due richieste di inventario web consecutive per evitare di innescare il limite di velocità - quelli sono utilizzati, ad esempio, durante la marcatura delle notifiche di inventario come letto, potrebbe anche essere utilizzato da plugin di terze parti che recuperano l'inventario di altri utenti. Questa proprietà non è utilizzata per recuperare il nostro inventario, in quanto ASF sta utilizzando molto più efficiente chiamata di rete interna per quello, quindi non influenzerà in alcun modo i comandi come il bottino `` o il trasferimento ``. Il valore predefinito di `4` è stato impostato in base all'inventario di oltre 100 istanze consecutive del bot, e devono soddisfare la maggior parte (se non tutti) degli utilizzatori. Potresti comunque voler diminuire, o anche cambiare in `0` se hai una quantità molto bassa di bot, così ASF ignorerà il ritardo e marcherà gli inventari di Steam molto più velocemente. Sii avvertito però, poiché impostando **troppo basso,** risulterà in Steam temporaneamente bannare il tuo IP, e questo vi impedirà di effettuare qualsiasi chiamata. Potrebbe anche essere necessario aumentare questo valore se stai eseguendo un sacco di bot con un sacco di richieste di inventario, anche se in questo caso si dovrebbe probabilmente cercare di limitare il numero di tali richieste. A meno che non si abbia un motivo **forte** per modificare questa proprietà, si dovrebbe mantenere come predefinito.

---

### `IPC`

`bool` tipo con valore predefinito `true`. Questa proprietà definisce se il server **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** di ASF dovrebbe iniziare insieme al processo. IPC consente la comunicazione tra processi, compreso l'utilizzo di **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, avviando un server HTTP locale. Se non intendi utilizzare alcuna integrazione IPC di terze parti con ASF, compreso il nostro ASF-ui, puoi disabilitare questa opzione. Altrimenti, è una buona idea mantenerlo abilitato (opzione predefinita).

---

### `IPCPassword`

Tipo `stringa` con valore predefinito `null`. Questa proprietà definisce la password obbligatoria per ogni chiamata API effettuata tramite IPC e serve come misura di sicurezza extra. Se impostato a valore non vuoto, tutte le richieste IPC richiederanno una proprietà `password` aggiuntiva impostata alla password specificata qui. Il valore predefinito di `null` salterà la necessità della password, rendendo ASF rispettare tutte le interrogazioni. Oltre a ciò, abilitando questa opzione abilita anche il meccanismo integrato IPC anti-bruteforce che vieterà temporaneamente `IPAddress` dopo aver inviato troppe richieste non autorizzate in brevissimo tempo. A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.

---

### `IPCPasswordFormat`

Tipo `byte` con valore predefinito di `0`. Questa proprietà definisce il formato della proprietà `IPCPassword` e utilizza `EHashingMethod` come tipo sottostante. Se vuoi saperne di più, fai riferimento alla sezione **[Security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** , in quanto avrai bisogno di assicurarsi che la proprietà `IPCPassword` includa effettivamente la password in corrispondenza `IPCPasswordFormat`. In altre parole, quando cambi `IPCPasswordFormat` allora la tua `IPCPassword` dovrebbe essere **già** in quel formato, non puntando solo ad essere. A meno che tu non sappia cosa stai facendo, dovresti mantenerlo con il valore predefinito di `0`.

---

### `LicenseID`

`Guid?` type with default value of `null`. Questa proprietà consente ai nostri sponsor **[](https://github.com/sponsors/JustArchi)** di migliorare ASF con funzionalità opzionali che richiedono risorse pagate per funzionare. Per ora, questo ti permette di utilizzare la funzione **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** nel plugin `ItemsMatcher`.

Mentre ti consigliamo di utilizzare GitHub in quanto offre livelli mensili e una tantum, oltre a consentire la completa automazione e ti dà accesso immediato, noi **anche** supportiamo tutte le altre opzioni di donazione **[attualmente disponibili](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. Vedi **[questo post](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** per le istruzioni su come donare utilizzando altri metodi al fine di ottenere una licenza manuale valida per un determinato periodo.

Indipendentemente dal metodo utilizzato, se sei sponsor di ASF, puoi ottenere la licenza **[qui](https://asf.justarchi.net/User/Status)**. Dovrai accedere con GitHub per confermare la tua identità, chiediamo solo informazioni pubbliche di sola lettura, che sono il tuo nome utente. `LicenseID` è composto da 32 caratteri esadecimali, come `f6a0529813f74d119982eb4fe43a9a24`.

**Assicurati di non condividere il tuo `LicenseID` con altre persone**. Dal momento che è rilasciato su base personale, potrebbe essere revocato se è fuoriuscito. Se per caso questo è accaduto a voi accidentalmente, è possibile generarne uno nuovo dallo stesso posto.

A meno che tu non voglia abilitare funzionalità ASF extra, non c'è bisogno di ottenere/fornire la licenza.

---

### `LoginLimiterDelay`

Tipo `byte` con valore predefinito di `10`. ASF assicurerà che ci saranno almeno `LoginLimiterDelay` secondi tra due tentativi di connessione consecutivi per evitare l'attivazione di rate-limite. Il valore predefinito di `10` è stato impostato in base alla connessione di oltre 100 istanze bot e dovrebbe soddisfare la maggior parte (se non tutti) degli utenti. Potresti comunque voler aumentare/diminuirlo, o anche passare a `0` se hai una quantità molto bassa di bot, così ASF ignorerà il ritardo e si connetterà a Steam molto più velocemente. Sii avvertito comunque, come impostarlo troppo basso mentre avendo troppi bot **** porterà a Steam a bannare temporaneamente il tuo IP, e questo ti impedirà di accedere a **a tutti**, con l'errore `InvalidPassword/RateLimitExceeded` - e che include anche il normale client Steam, non solo ASF. Allo stesso modo, se stai eseguendo un numero eccessivo di bot, specialmente insieme ad altri client / strumenti Steam utilizzando lo stesso indirizzo IP, molto probabilmente avrai bisogno di aumentare questo valore al fine di diffondere i login in un periodo di tempo più lungo.

Come nota laterale, questo valore viene utilizzato anche come buffer di bilanciamento del carico in tutte le azioni programmate ASF, come le operazioni in `SendTradePeriod`. A meno che non si abbia un motivo **forte** per modificare questa proprietà, si dovrebbe mantenere come predefinito.

---

### `MaxFarmingTime`

Tipo `byte` con valore predefinito di `10`. Come dovreste sapere, Steam non funziona sempre correttamente, a volte situazioni strane possono accadere come il nostro tempo di gioco non essere registrati, nonostante di, infatti, giocare un gioco. ASF permetterà di coltivare una singola partita in modalità solista per un massimo di `MaxFarmingTime` ore, e considerarla completamente coltivata dopo quel periodo. Ciò è necessario per non congelare il processo agricolo in caso di situazioni strane, ma anche se per qualche motivo Steam ha rilasciato un nuovo badge che impedirebbe a ASF di progredire ulteriormente (vedi: `Blacklist`). Il valore predefinito di `10` ore dovrebbe essere sufficiente per rilasciare tutte le carte a vapore da una partita. Impostare questa proprietà troppo bassa può portare a saltare i giochi validi (e sì, ci sono giochi validi che impiegano fino a 9 ore per la fattoria), mentre la sua impostazione troppo elevata può portare al congelamento del processo agricolo. Si prega di notare che questa proprietà riguarda solo una singola partita in una singola sessione di allevamento (quindi dopo aver attraversato l'intera coda ASF tornerà a quel titolo), inoltre non si basa sul tempo di gioco totale ma sul tempo di allevamento interno di ASF, quindi ASF tornerà anche a quel titolo dopo un riavvio. A meno che non si abbia un motivo **forte** per modificare questa proprietà, si dovrebbe mantenere come predefinito.

---

### `MaxTradeHoldDuration`

Tipo `byte` con valore predefinito di `15`. Questa proprietà definisce la durata massima del trading hold in giorni che siamo disposti ad accettare - ASF rifiuterà le operazioni che sono in corso di detenzione per più di `MaxTradeDuration` giorni, come definito nella sezione **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**. Questa opzione ha senso solo per i bot con `TradingPreferences` of `SteamTradeMatcher`, poiché non influisce su `Master`/`SteamOwnerID` , nessuna donazione. Gli scambi commerciali sono fastidiosi per tutti, e nessuno vuole davvero affrontarli. ASF dovrebbe lavorare su regole liberali e aiutare tutti, indipendentemente dal fatto che sia in possesso o meno - ecco perché questa opzione è impostata su `15` per impostazione predefinita. Tuttavia, se preferisci invece respingere tutte le transazioni interessate da trade holds, puoi specificare qui `0`. Si prega di considerare il fatto che le carte con breve durata di vita non sono influenzate da questa opzione e automaticamente respinte per le persone con aziende commerciali, come descritto nella sezione **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** , quindi non c'è bisogno di respingere tutti a livello globale solo per questo. A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.


---

### `MinFarmingDelayAfterBlock`

Tipo `byte` con valore predefinito di `60`. Questa proprietà definisce la quantità minima di tempo, in secondi, quale ASF attenderà prima di riprendere l'allevamento delle carte se è stato disconnesso in precedenza con `LoggedInElsewhere`, che accade quando si decide di disconnettere con forza ASF corrente agricoltura lanciando un gioco. Questo ritardo esiste principalmente per motivi di comodità e di sicurezza, ad esempio ti permette di riavviare il gioco senza dover combattere con ASF occupando di nuovo il tuo account solo perché il blocco di gioco era disponibile per un secondo divisione. A causa del fatto che il recupero della sessione causa la disconnessione `LoggedInElsewhere` , ASF deve passare attraverso l'intera procedura di ricollegamento, che esercita una pressione supplementare sulla macchina e sulla rete di vapore, evitando quindi ulteriori disconnessioni, se possibile, è preferibile. Per impostazione predefinita, questo è configurato in `60` secondi, che dovrebbe essere sufficiente per consentire di riavviare il gioco senza molto fastidio. Tuttavia, ci sono scenari in cui si potrebbe essere interessati ad aumentarlo, ad esempio se la rete si disconnette spesso e ASF sta prendendo il sopravvento troppo presto, il che fa sì che sia costretto a passare attraverso il processo di riconnessione. Permettiamo un valore massimo di `255` per questa proprietà, che dovrebbe essere sufficiente per tutti gli scenari comuni. Oltre a quanto sopra, è anche possibile ridurre il ritardo, o anche rimuoverlo interamente con un valore di `0`, anche se di solito ciò non è raccomandato per le ragioni sopra indicate. A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.

---

### `Modalità Ottimizzazione`

Tipo `byte` con valore predefinito di `0`. Questa proprietà definisce la modalità di ottimizzazione che ASF preferirà durante il runtime. Attualmente ASF supporta due modalità - `0` che si chiama `MaxPerformance`, e `1` chiamato `MinMemoryUsage`. Per impostazione predefinita, ASF preferisce eseguire il maggior numero possibile di cose in parallelo (contemporaneamente), che migliora le prestazioni attraverso il lavoro di bilanciamento del carico su tutti i core della CPU, più thread della CPU, più socket e più attività del threadpool. Per esempio, ASF chiederà la tua prima pagina di badge quando controlli per i giochi in fattoria, e poi una volta che la richiesta è arrivata, ASF leggerà da esso quante pagine distintivo hai effettivamente avuto, quindi richiederne uno a vicenda contemporaneamente. Questo è ciò che si dovrebbe desiderare **quasi sempre**, in quanto il sovraccarico nella maggior parte dei casi è minimo e i benefici del codice ASF asincrono possono essere visti anche sul più vecchio hardware con un singolo nucleo di CPU e una potenza pesantemente limitata. Tuttavia, con molte attività in fase di elaborazione in parallelo, ASF runtime è responsabile della loro manutenzione, ad es. mantenere le prese aperte, i fili vivi e i compiti in fase di elaborazione, che può causare un maggiore utilizzo della memoria di tanto in tanto, e se sei estremamente vincolato dalla memoria disponibile, potresti voler cambiare questa proprietà in `1` (`MinMemoryUsage`) per forzare ASF a utilizzare il minor numero di attività possibile, e tipicamente con codice asincrono possibile-parallelo in modo sincrono. Dovresti considerare la possibilità di cambiare questa proprietà solo se in precedenza hai letto la configurazione **[a bassa memoria](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** e intenzionalmente vuoi sacrificare il gigantesco aumento delle prestazioni, per una piccolissima diminuzione della memoria aerea. Di solito questa opzione è **molto peggio** di quello che puoi ottenere con altri modi possibili, ad esempio limitando l'utilizzo di ASF o sintonizzando il collezionista di spazzatura, come spiegato in **[setup a bassa memoria](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Pertanto, è necessario utilizzare `MinMemoryUsage` come un **ultima risorsa**, prima della ricompilazione del runtime, se non riuscite a ottenere risultati soddisfacenti con altre opzioni (molto meglio). A meno che non si abbia un motivo **forte** per modificare questa proprietà, si dovrebbe mantenere come predefinito.

---

### `PluginsUpdateList`

Tipo `ImmutableHashSet<string>` con valore predefinito vuoto. Questa proprietà definisce l'elenco dei nomi dei plugin assemblati che sono in blacklist o in whitelist per essere considerati per gli aggiornamenti automatici, come da `PluginsUpdateMode` definito sotto.

A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.

---

### `PluginsUpdateMode`

Tipo `byte` con valore predefinito di `0`. Questa proprietà definisce la modalità di aggiornamento dei plugin che dà significato a `PluginsUpdateList` definito sopra. Specificando questa proprietà è possibile abilitare/disabilitare facilmente gli aggiornamenti automatici per tutti i plugin, ad eccezione di quelli dichiarati.

- Valore di `0`, chiamato `Whitelist`, **disabilita l'aggiornamento automatico** di tutti i plugin, ad eccezione di quelli definiti in `PluginsUpdateList`.
- Valore di `1`, chiamato `Blacklist`, **abilita l'aggiornamento automatico** di tutti i plugin, ad eccezione di quelli definiti in `PluginsUpdateList`.

Il team **di ASF ti ricorda che, per la tua sicurezza, dovresti abilitare gli aggiornamenti automatici solo da parte di parti di fiducia**. Tieni presente che i plugin dannosi possono decidere di aggiornare se stessi o eseguire comandi remoti **indipendentemente da** di questa impostazione, questo è il motivo per cui questa impostazione si applica esclusivamente alla funzionalità di aggiornamento dei plugin forniti da ASF, e dovresti ancora assicurarti di aver verificato in modo appropriato ogni plugin che hai deciso di usare.

Gli aggiornamenti dei plugin sono eseguiti per impostazione predefinita insieme alla routine di aggiornamento di ASF - **[`UpdateChannel`](#updatechannel)** e **[`UpdatePeriod`](#updateperiod)**. I meccanismi di aggiornamento standard di ASF come il comando `update` attiveranno anche l'aggiornamento dei plugin opzionali. Se invece vuoi aggiornare manualmente i plugin senza aggiornare contemporaneamente la versione di ASF, il comando `updateplugins` offre tale possibilità.

A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.

---

### `ShutdownIfPossibile`

`bool` type with default value of `false`. Se abilitato, ASF proverà ad arrestare il processo se possibile, cioè quando tutti i tuoi bot registrati vengono fermati. Questo può essere particolarmente utile quando combinato con `ShutdownOnFarmingFinished` su tutte le istanze del tuo bot, dal momento che in questo modo ASF sarà permesso di spegnere automaticamente quando l'ultimo dei tuoi bot finisce l'agricoltura.

Dal momento che l'aspettativa della maggior parte degli utenti è di avere il processo in esecuzione in ogni momento, e. . per l'utilizzo di `IPC` , questa opzione è disabilitata per impostazione predefinita.

---

### `SteamMessagePrefix`

Tipo `stringa` con valore predefinito di `"/me "`. Questa proprietà definisce un prefisso che sarà preceduto da tutti i messaggi di Steam inviati da ASF. Per impostazione predefinita, ASF utilizza il prefisso `"/me "` per distinguere più facilmente i messaggi del bot mostrandoli in diversi colori nella chat di Steam. Un'altra menzione degna è il prefisso `"/pre "` che raggiunge risultati simili, ma utilizza una formattazione diversa. È anche possibile impostare questa proprietà su stringa vuota o `null` al fine di disabilitare utilizzando il prefisso interamente ed emettere tutti i messaggi ASF in modo tradizionale. È bello notare che questa proprietà influenza solo i messaggi di Steam - le risposte restituite attraverso altri canali (come IPC) non sono influenzate. A meno che non si voglia personalizzare il comportamento standard di ASF, è una buona idea lasciarlo in modo predefinito.

---

### `SteamOwnerID`

`ulong` type with default value of `0`. Questa proprietà definisce Steam ID in forma a 64 bit di proprietario di processo ASF, ed è molto simile al permesso `Master` di una data istanza bot (ma globale invece). Vuoi quasi sempre impostare questa proprietà su ID del tuo account principale di Steam. Il permesso `Master` include il pieno controllo sull'istanza del suo bot, ma comandi globali come `exit`, `riavvio` o `aggiornamento` sono riservati solo per `SteamOwnerID`. Questo è conveniente, come si potrebbe voler eseguire bot per i tuoi amici, mentre non consente loro di controllare il processo di ASF, ad esempio uscirlo tramite il comando `exit`. Il valore predefinito di `0` specifica che non c'è nessun proprietario del processo ASF, il che significa che nessuno sarà in grado di emettere comandi globali di ASF. Tieni presente che questa proprietà si applica esclusivamente alla chat di Steam. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, così come console interattiva, ti permetterà comunque di eseguire i comandi `Owner` anche se questa proprietà non è impostata.

---

### `SteamProtocols`

`byte flags` tipo con valore predefinito di `7`. Questa proprietà definisce i protocolli di Steam che ASF utilizzerà durante la connessione ai server di Steam, definiti come di seguito:

| Valore | Nome         | Descrizione                                                                                             |
| ------ | ------------ | ------------------------------------------------------------------------------------------------------- |
| 0      | Nessuna data | No protocol                                                                                             |
| 1      | TCP          | **[Protocollo Di Controllo Trasmissione](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2      | UDP          | **[Protocollo Del Datagramma Utente](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**            |
| 4      | WebSocket    | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                                                |

Si prega di notare che questa proprietà è `flags` campo, quindi è possibile scegliere qualsiasi combinazione di valori disponibili. Scopri **[json mapping](#json-mapping)** se vuoi saperne di più. Non abilitare nessuno dei flag comporta l'opzione `Nessuno` e questa opzione non è valida da sola.

Per impostazione predefinita, ASF utilizzerà tutti i protocolli di Steam disponibili come misura per combattere con i tempi di inattività e altri problemi simili di Steam. In genere si desidera modificare questa proprietà se si desidera limitare ASF utilizzando solo uno o due protocolli specifici. Tali misure potrebbero essere necessarie in diverse situazioni, ad esempio se hai bloccato il traffico UDP sul tuo firewall e vuoi assicurarti che solo il traffico TCP passi, o se stai usando `WebProxy` e vuoi usarlo anche per la connessione client Steam, come solo il protocollo `WebSocket` lo supporta.

A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.

---

### `UpdateChannel`

Tipo `byte` con valore predefinito di `1`. Questa proprietà definisce il canale di aggiornamento in uso, per gli aggiornamenti automatici (se `UpdatePeriod` è maggiore di `0`), o aggiornare le notifiche (altrimenti). Attualmente ASF supporta tre canali di aggiornamento - `0` che si chiama `Nessuno`, `1`, which is called `Stable`, and `2`, which is called `PreRelease`. Il canale `Stabile` è il canale di rilascio predefinito, che dovrebbe essere utilizzato dalla maggior parte degli utenti. Canale `PreRelease` oltre alle versioni `Stable` , include anche **pre-release** dedicate agli utenti avanzati e ad altri sviluppatori al fine di testare nuove funzionalità, confermare correzioni di bug o dare un feedback sui miglioramenti pianificati. Le versioni di **PreRelease contengono spesso bug non patchati, funzionalità di work-in-progress o implementazioni riscritte**. Se non ti consideri un utente avanzato, ti preghiamo di rimanere con il canale di aggiornamento predefinito `1` (`Stabile`). Il canale `PreRelease` è dedicato agli utenti che sanno segnalare bug, affrontare i problemi e fornire un feedback - non sarà fornito alcun supporto tecnico. Scopri ASF **[release cycle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** se vuoi saperne di più. Puoi anche impostare `UpdateChannel` a `0` (`None`), se vuoi rimuovere completamente tutti i controlli di versione. Impostazione di `UpdateChannel` a `0` disabiliterà completamente intere funzionalità relative agli aggiornamenti, compreso il comando `aggiornamento`. L'utilizzo del canale `Nessuno` è **fortemente scoraggiato** a causa dell'esposizione a tutti i tipi di problemi (menzionato nella descrizione `UpdatePeriod` di seguito).

**A meno che tu non sai cosa stai facendo**, noi **fortemente** consigliamo di mantenerlo come predefinito.

---

### `AggiornamentoPeriodo`

Tipo `byte` con valore predefinito di `24`. Questa proprietà definisce la frequenza con cui ASF dovrebbe controllare gli aggiornamenti automatici. Gli aggiornamenti sono cruciali non solo per ricevere nuove funzionalità e patch di sicurezza critiche, ma anche per ricevere correzioni di bug, miglioramenti delle prestazioni, miglioramenti della stabilità e altro ancora. Quando un valore maggiore di `0` è impostato, ASF scaricherà automaticamente, sostituirà e riavvia se stesso (se `AutoRiavvia` permessi) quando è disponibile un nuovo aggiornamento. Per raggiungere questo obiettivo, ASF controllerà ogni `UpdatePeriod` ore se il nuovo aggiornamento è disponibile sul nostro repo GitHub. Un valore di `0` disabilita gli aggiornamenti automatici, ma consente comunque di eseguire manualmente il comando `update`. Potresti anche essere interessato a impostare un appropriato `UpdateChannel` che `UpdatePeriod` dovrebbe seguire.

Il processo di aggiornamento di ASF comporta l'aggiornamento di tutta la struttura della cartella che ASF sta utilizzando, ma senza toccare i propri configurazioni o database situati nella directory `config` - questo significa che qualsiasi file extra non correlati a ASF nella sua directory può essere perso durante l'aggiornamento. Valore predefinito di `24` è un buon equilibrio tra controlli non necessari, e ASF che è abbastanza fresco.

A meno che tu non abbia un motivo **forte** per disabilitare questa funzione, si dovrebbe mantenere gli aggiornamenti automatici abilitati entro ragionevole `UpdatePeriod` **per il vostro bene**. Questo non solo perché non supportiamo nulla, ma l'ultima versione stabile di ASF, ma anche perché **diamo la nostra garanzia di sicurezza solo per l'ultima versione**. Se stai usando una versione obsoleta di ASF allora stai intenzionalmente esponendo te stessi a tutti i tipi di problemi, da piccoli bug, attraverso funzionalità rotte, ending with **[permanent Steam account suspensions](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**, quindi **consigliamo vivamente**, per il tuo bene, di garantire sempre che la tua versione di ASF sia aggiornata. Gli aggiornamenti automatici ci permettono di reagire rapidamente a tutti i tipi di problemi disabilitando o patching codice problematico prima che possa aumentare - se si sceglie di non farlo, si perde tutte le nostre garanzie di sicurezza e le conseguenze di rischio dall'esecuzione di codice che potrebbe essere potenzialmente dannoso, non solo alla rete Steam, ma anche (per definizione) al proprio account Steam.

---

### `WebLimiterDelay`

Tipo `ushort` con valore predefinito di `300`. Questa proprietà definisce, in milisecondi, la quantità minima di ritardo tra l'invio di due richieste consecutive allo stesso servizio web di Steam. Tale ritardo è richiesto come il servizio **[AkamaiGhost](https://www.akamai.com)** che Steam utilizza internamente include limiti di velocità in base al numero globale di richieste inviate in un dato periodo di tempo. In circostanze normali il blocco akamai è piuttosto difficile da raggiungere, ma sotto carichi di lavoro molto pesanti con una grande coda di richieste in corso, è possibile attivarlo se continuiamo a inviare troppe richieste in un periodo di tempo troppo breve.

Il valore predefinito è stato impostato in base all'ipotesi che ASF sia l'unico strumento che accede ai servizi web di Steam, in particolare la comunità di vapore `. om`, `api.steampowered.com` and `store.steampowered.com`. Se stai utilizzando altri strumenti per inviare richieste agli stessi servizi web, allora dovresti assicurarti che il tuo strumento includa funzionalità simili di `WebLimiterDelay` e impostare sia il doppio del valore predefinito, che sarebbe `600`. Questo garantisce che in nessuna circostanza supererai l'invio di più di 1 richiesta per `300` ms.

In generale, abbassare `WebLimiterDelay` sotto valore predefinito è **fortemente scoraggiato** in quanto potrebbe portare a vari blocchi relativi all'IP, alcuni dei quali possono essere permanenti. Il valore predefinito è abbastanza buono per eseguire una singola istanza di ASF sul server, oltre a utilizzare ASF in uno scenario normale insieme al client Steam originale. Deve essere corretto per la maggior parte degli usi, e dovresti solo aumentarlo (non abbassarlo mai). Insomma, il numero globale di tutte le richieste inviate da un unico IP a un singolo dominio Steam non dovrebbe mai superare più di 1 richiesta per `300` ms.

A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.

---

### `WebProxy`

Tipo `stringa` con valore predefinito `null`. Questa proprietà definisce un indirizzo proxy web che verrà utilizzato per la comunicazione interna relativa a http, in particolare per servizi come `github. om`, `api.steampowered.com`, `steamcommunity.com` and `store.steampowered.com`. Si applica alla comunicazione generale (non specifica del robot), così come alla comunicazione specifica del bot se la loro proprietà di configurazione `WebProxy` equivalente non è impostata. Proxying richieste di ASF potrebbe essere eccezionalmente utile per aggirare vari tipi di firewall, in particolare il grande firewall in Cina.

Questa proprietà è definita come una stringa uri:

> Una stringa URI è composta da uno schema (supportato: http/https/socks4/socks4a/socks5), un host e una porta opzionale. Un esempio di una stringa uri completa è `"http://contoso.com:8080"`.

Se il tuo proxy richiede l'autenticazione dell'utente, dovrai anche impostare `WebProxyUsername` e/o `WebProxyPassword`. Se non c'è tale necessità, la creazione di questa proprietà da sola è sufficiente.

Se hai bisogno di proxy anche di comunicazione di rete di Steam (CMs) interna, allora dovresti assicurarti di configurare la proprietà del bot **[`SteamProtocols`](#steamprotocols)** ad un valore che consenta solo il trasporto Websocket, i. . a value of `4`, as only websockets are supported for proxying.

A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.

---

### `WebProxyPassword`

Tipo `stringa` con valore predefinito `null`. Questa proprietà definisce il campo password utilizzato in base, digest, NTLM, e autenticazione Kerberos supportata da una macchina `WebProxy` di destinazione che fornisce funzionalità proxy. Se il tuo proxy non richiede credenziali utente, non c'è bisogno che tu inserisca qualcosa qui. L'utilizzo di questa opzione ha senso solo se viene utilizzato `WebProxy` anche perché altrimenti non ha effetto.

A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.

---

### `WebProxyUsername`

Tipo `stringa` con valore predefinito `null`. Questa proprietà definisce il campo nome utente usato in base, digest, NTLM, e autenticazione Kerberos supportata da una macchina `WebProxy` di destinazione che fornisce funzionalità proxy. Se il tuo proxy non richiede credenziali utente, non c'è bisogno che tu inserisca qualcosa qui. L'utilizzo di questa opzione ha senso solo se viene utilizzato `WebProxy` anche perché altrimenti non ha effetto.

A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.

---

## Configurazione bot

Come dovreste sapere già, ogni bot dovrebbe avere una propria configurazione basata sull'esempio della struttura JSON qui sotto. Inizia dal decidere come vuoi nominare il tuo bot (ad es. `1.json`, `main. son`, `primary.json` o `AnythingElse.json`e vai alla configurazione.

**Avviso:** Il bot non può essere chiamato `ASF` (come questa parola chiave è riservata per la configurazione globale), ASF ignorerà anche tutti i file di configurazione che iniziano con un punto.

La configurazione del bot ha la seguente struttura:

```json
{
    "AcceptGifts": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Enabled": falso,
    "FarmingOrders": [],
    "FarmingPreferences": 0,
    "GiochiPlayedWhileIdle": [],
    "GamingDeviceType": 1,
    "OrarioUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "MachineName": null,
    "MatchableTypes": [5],
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "RedeemingPreferences": 0,
    "RemoteCommunication": 3,
    "SendTradePeriodo": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "TransferableTypes": [1, 3, 5],
    "UseLoginKeys": true,
    "UserInterfaceMode": 0,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Tutte le opzioni sono spiegate sotto:

### `Regali Di Accettazione`

`bool` type with default value of `false`. Se abilitato, ASF accetterà e riscatterà automaticamente tutti i regali di vapore (incluse le carte regalo del portafoglio) inviati al bot. Questo include anche i regali inviati da utenti diversi da quelli definiti in `SteamUserPermissions`. Tieni presente che i regali inviati all'indirizzo e-mail non vengono direttamente inoltrati al cliente, quindi ASF non accetta quelli senza il tuo aiuto.

Questa opzione è consigliata solo per gli account alt, siccome è molto probabile che non si desidera riscattare automaticamente tutti i regali inviati al tuo account principale. Se non sei sicuro di voler abilitare o meno questa funzionalità, mantenerla con il valore predefinito di `false`.

---

### `BotBehaviour`

`byte flag` tipo con valore predefinito di `0`. Questa proprietà definisce il comportamento simile al bot-ASF durante vari eventi ed è definita come di seguito:

| Valore | Nome                         | Descrizione                                                                                                                |
| ------ | ---------------------------- | -------------------------------------------------------------------------------------------------------------------------- |
| 0      | Nessuna data                 | Nessun comportamento speciale del bot, impostazioni predefinite sane                                                       |
| 1      | RejectInvalidFriendInvites   | Proporrà a ASF di rifiutare (invece di ignorare) inviti amici non validi                                                   |
| 2      | RejectInvalidTrades          | Produrrà ASF a rifiutare (invece di ignorare) offerte commerciali non valide                                               |
| 4      | RejectInvalidGroupInvites    | Proporrà a ASF di rifiutare (invece di ignorare) inviti di gruppo non validi                                               |
| 8      | DismissInventarioNotifiche   | Far sì che ASF elimini automaticamente tutte le notifiche di inventario                                                    |
| 16     | MarkReceivedMessagesAsRead   | Far segnare automaticamente tutti i messaggi ricevuti come letti da ASF                                                    |
| 32     | MarkBotMessagesAsRead        | Far sì che ASF contrassegna automaticamente i messaggi da altri bot di ASF (in esecuzione nella stessa istanza) come letti |
| 64     | DisableIncomingTradesParsing | Far sì che ASF non elabori mai le offerte commerciali in entrata                                                           |

Si prega di notare che questa proprietà è `flags` campo, quindi è possibile scegliere qualsiasi combinazione di valori disponibili. Scopri **[json mapping](#json-mapping)** se vuoi saperne di più. Non abilitare nessuno dei flag comporta l'opzione `Nessuno`.

In generale si desidera modificare questa proprietà se si prevede di modificare varie impostazioni di automazione relative all'attività del bot. Le impostazioni predefinite coinvolgono ASF in esecuzione in modalità non invasiva, che consente solo un'automazione vantaggiosa che non va contro la volontà dell'utente.

Invito amico non valido è un invito che non viene dall'utente con il permesso `FamilySharing` (definito in `SteamUserPermissions`) o superiore. ASF in modalità normale ignora questi inviti, come ci si aspetterebbe, dandoti la libera scelta se accettarli o meno. `RejectInvalidFriendInvites` causerà il rifiuto automatico di questi inviti, che praticamente disabiliterà l'opzione per altre persone di aggiungerti alla loro lista di amici (come ASF negherà tutte queste richieste, oltre alle persone definite in `SteamUserPermissions`). A meno che tu non voglia negare completamente tutti gli inviti ad amici, non dovresti abilitare questa opzione.

Offerta di scambio non valida è un'offerta che non è accettata attraverso il modulo ASF integrato. Ulteriori informazioni su questo tema sono disponibili nella sezione **[di trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** che definisce esplicitamente quali tipi di trading ASF sono disposti ad accettare automaticamente. Le transazioni valide sono definite anche da altre impostazioni, in particolare `TradingPreferences`. `RejectInvalidTrades` causerà il rifiuto di tutte le offerte commerciali non valide, invece di essere ignorate. A meno che tu non voglia negare completamente tutte le offerte di trading che non sono accettate automaticamente da ASF, non dovresti abilitare questa opzione.

Invito di gruppo non valido è un invito che non viene dal gruppo `SteamMasterClanID`. ASF in modalità normale ignora quegli inviti di gruppo, come ci si aspetterebbe, ti permette di decidere te stesso se vuoi unirti a un particolare gruppo di Steam oppure no. `RejectInvalidGroupInvites` farà sì che tutti questi inviti di gruppo vengano automaticamente rifiutati, di fatto rendendo impossibile invitarti a qualsiasi altro gruppo diverso da `SteamMasterClanID`. A meno che non si voglia negare completamente tutti gli inviti di gruppo, non si dovrebbe abilitare questa opzione.

`DismissInventarioNotifiche` è estremamente utile quando inizi ad essere infastidito dalla costante notifica Steam sulla ricezione di nuovi elementi. ASF non può sbarazzarsi della notifica stessa, poiché è incorporato nel tuo client Steam, ma è in grado di cancellare automaticamente la notifica dopo averla ricevuta, che non lascerà più "nuovi elementi nell'inventario" notifica appeso intorno. Se ti aspetti di valutare tutti gli oggetti ricevuti (soprattutto le carte coltivate con ASF), naturalmente non dovresti abilitare questa opzione. Quando si inizia a impazzire, ricordare che questo è offerto come opzione.

`MarkReceivedMessagesAsRead` contrassegnerà automaticamente **tutti** i messaggi ricevuti dal profilo su cui ASF è in esecuzione, sia privati che da gruppi, come letti. Questo tipicamente dovrebbe essere usato dagli account alt solo per cancellare la notifica "nuovo messaggio" proveniente ad esempio da te durante l'esecuzione dei comandi ASF. Non consigliamo questa opzione per gli account primari, a meno che non si desidera tagliare da qualsiasi tipo di nuove notifiche di messaggi, **incluso** quelli che sono accaduti mentre eri offline, supponendo che ASF fosse ancora lasciato aperto eliminarlo.

`MarkBotMessagesAsRead` funziona in modo simile contrassegnando solo i messaggi del bot come letti. Tuttavia, tieni a mente che quando usi quell'opzione sulle chat di gruppo con i tuoi bot e le altre persone, l'implementazione di riconoscimento dei messaggi di chat di Steam riconosce **anche** tutti i messaggi avvenuti **prima** che tu avessi deciso di contrassegnare, quindi se tu non volessi perdere messaggi non correlati avvenuti nel mentre, di solito vorrai evitare di usare questa funzione. Ovviamente, è anche rischioso quando si dispone di più account primari (ad es. da utenti diversi) in esecuzione nella stessa istanza di ASF, come si può anche perdere i loro normali messaggi fuori di ASF.

`DisableIncomingTradesParsing` impedirà a ASF di analizzare le offerte di trading in entrata, ciò significa che l'intera funzionalità di trading relativa a quella sarà non operativa. Dal momento che ASF funziona in modalità meno invasiva per impostazione predefinita, accettando solo offerte commerciali da utenti `Master` e oltre, non toccare mai altre offerte commerciali: l'analisi delle transazioni in entrata è abilitata per impostazione predefinita. Questa impostazione ha il più senso per le persone che vorrebbero garantire non ulteriori richieste/spese aggiuntive relative al trading di parsing, disabilitando l'intera logica in processo, ad esempio perché sanno che i loro bot non riceveranno mai richieste di commercio maestro, e pertanto non richiedono la partecipazione di ASF alla loro attività di negoziazione. Tieni presente che avere questa opzione specificata disabiliterà tutte le altre opzioni che dipendono anche dalle operazioni in arrivo, come `AcceptDonations` o `SteamTradeMatcher` - anche i plugin personalizzati non saranno in grado di elaborare le offerte di trading in entrata in modo abituale.

Se non sei sicuro di come configurare questa opzione, è meglio lasciarla come predefinita.

---

### `CompleteTypesToSend`

Tipo `ImmutableHashSet<byte>` con valore predefinito vuoto. Quando ASF viene fatto completando un dato insieme di tipi di elementi specificati qui, può inviare automaticamente il commercio di vapore con tutti i set finiti all'utente con il permesso `Master` , che è molto conveniente se si desidera utilizzare un determinato account bot per e. . Corrispondenza STM, mentre si spostano i set finiti su qualche altro account. Questa opzione funziona come il comando `loot` , quindi tieni presente che richiede l'utente con `Master` set di autorizzazioni, you may also need a valid `SteamTradeToken`, oltre a utilizzare un conto che è ammissibile per la negoziazione in primo luogo.

A partire da oggi, i seguenti tipi di elementi sono supportati in questa impostazione:

| Valore | Nome            | Descrizione                                                                      |
| ------ | --------------- | -------------------------------------------------------------------------------- |
| 3      | FoilTradingCard | Variante della stagnola di `TradingCard`                                         |
| 5      | TradingCard     | Carta commerciale a vapore, utilizzata per la creazione di distintivi (non-foil) |

Si prega di notare che indipendentemente dalle impostazioni sopra riportate, ASF chiederà solo gli elementi **[della comunità di Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` di 753, `contextID` di 6), quindi tutti gli articoli di gioco, i regali e allo stesso modo, sono esclusi dall'offerta di commercio per definizione.

A causa del sovraccarico aggiuntivo di utilizzare questa opzione, si consiglia di utilizzarlo solo su account bot che hanno una probabilità realistica di finitura set da soli - per esempio, non ha senso attivare se stai già usando la preferenza `SendOnFarmingFinished` in `FarmingPreferences`, `comando SendTradePeriod` o `loot` su base abituale.

Se non sei sicuro di come configurare questa opzione, è meglio lasciarla come predefinita.

---

### `CustomGamePlayedWhileFarming`

Tipo `stringa` con valore predefinito `null`. Quando ASF sta coltivando, può mostrarsi come "Giocare a gioco non a vapore: `CustomGamePlayedWhileFarming`" invece di gioco attualmente allevato. Questo può essere utile se vuoi far sapere ai tuoi amici che stai coltivando, tuttavia non vuoi utilizzare `OnlineStatus` di `Offline`. Si prega di notare che ASF non può garantire l'ordine di visualizzazione effettivo della rete Steam, quindi questo è solo un suggerimento che può o non può essere visualizzato correttamente. In particolare, il nome personalizzato non verrà visualizzato nell'algoritmo di allevamento `Complesso` se ASF riempie tutti gli slot `32` con giochi che richiedono ore per essere urtati. Il valore predefinito di `null` disabilita questa funzione.

ASF fornisce alcune variabili speciali che è possibile utilizzare opzionalmente nel testo. `{0}` sarà sostituito da ASF con `AppID` di giochi attualmente allevati, mentre `{1}` sarà sostituito da ASF con `GameName` di giochi attualmente allevati.

---

### `CustomGamePlayedWhileIdle`

Tipo `stringa` con valore predefinito `null`. Simile a `CustomGamePlayedWhileFarming`, ma per la situazione in cui ASF non ha nulla da fare (come account è completamente finito). Si prega di notare che ASF non può garantire l'ordine di visualizzazione effettivo della rete Steam, quindi questo è solo un suggerimento che può o non può essere visualizzato correttamente. Se stai usando `GamesPlayedWhileIdle` insieme a questa opzione, tieni presente che `GamesPlayedWhileIdle` ottengono la priorità, quindi non è possibile dichiarare più di `31` di loro, come altrimenti `CustomGamePlayedWhileIdle` non sarà in grado di occupare lo slot per il nome personalizzato. Il valore predefinito di `null` disabilita questa funzione.

---

### `Abilitato`

`bool` type with default value of `false`. Questa proprietà definisce se il bot è abilitato. L'istanza del bot abilitata (`true`) inizierà automaticamente con l'esecuzione di ASF, mentre l'istanza del bot disabilitato (`false`) dovrà essere avviata manualmente. Per impostazione predefinita ogni bot è disabilitato, quindi probabilmente vuoi passare questa proprietà a `true` per tutti i tuoi bot che dovrebbero essere avviati automaticamente.

---

### `Ordini Agricoli`

Tipo `ImmutableList<byte>` con valore predefinito di essere vuoto. Questa proprietà definisce l'ordine di allevamento **preferito** utilizzato da ASF per un determinato account bot. Attualmente sono disponibili i seguenti ordini di allevamento:

| Valore | Nome                       | Descrizione                                                                                      |
| ------ | -------------------------- | ------------------------------------------------------------------------------------------------ |
| 0      | Non Ordinato               | Nessun smistamento, migliorando leggermente le prestazioni della CPU                             |
| 1      | AppIDsAscendente           | Cerca prima di coltivare i giochi con `più bassi appID`                                          |
| 2      | AppIDsDecrescente          | Prova ad abbinare i giochi con `più alti appID` prima                                            |
| 3      | CardDropsAscendente        | Prova a giocare con il numero più basso di gocce di carta rimanenti prima                        |
| 4      | CardDropsDecrescente       | Prova a giocare con il maggior numero di gocce di carta rimanenti prima                          |
| 5      | OrariaAscendente           | Prova a giocare con il numero più basso di ore giocate prima                                     |
| 6      | Ore Decrescenti            | Prova a giocare con il più alto numero di ore giocate prima                                      |
| 7      | NomiAscendente             | Prova a giocare in ordine alfabetico, a partire da A                                             |
| 8      | NomiDecrescente            | Prova a coltivare i giochi in ordine alfabetico inverso, a partire da Z                          |
| 9      | Casuale                    | Prova a giocare in ordine totalmente casuale (diverso per ogni esecuzione del programma)         |
| 10     | BadgeLevelsAscendente      | Prova prima a giocare con i livelli di distintivo più bassi                                      |
| 11     | BadgeLevelsDecrescente     | Prova a giocare con i livelli di distintivo più alti prima                                       |
| 12     | RedeemDateTimesAscendente  | Prova a coltivare i giochi più vecchi sul nostro account prima                                   |
| 13     | RedeemDateTimesDecrescente | Prova a coltivare i giochi più recenti sul nostro account prima                                  |
| 14     | MarketableAscending        | Prova a giocare con le gocce di carta non commerciabili prima (attenzione: costoso da calcolare) |
| 15     | MarketableDeccending       | Prova a giocare con le gocce di carte commerciabili prima (attenzione: costoso da calcolare)     |

Poiché questa proprietà è un array, ti permette di utilizzare diverse impostazioni nel tuo ordine fisso. Ad esempio, puoi includere i valori di `15`, `11` e `7` al fine di ordinare prima le partite commercializzabili, poi da quelli con il livello di distintivo più alto, e infine alfabeticamente. Come puoi indovinare, l'ordine in realtà conta, come inverso uno (`7`, `11` e `15`) realizza qualcosa di completamente diverso (ordina prima i giochi alfabeticamente, e a causa del fatto che i nomi di gioco sono unici, gli altri due sono effettivamente inutili). La maggioranza delle persone probabilmente userà solo un ordine fuori di tutti, ma nel caso in cui si desideri, è anche possibile ordinare ulteriormente per ulteriori parametri.

Notare anche la parola "prova" in tutte le descrizioni di cui sopra - l'ordine reale di ASF è pesantemente influenzato dall'algoritmo **[di allevamento delle carte](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** selezionato e l'ordinamento influenzerà solo i risultati che ASF considera lo stesso senso delle prestazioni. Ad esempio, nell'algoritmo `Simple` , selezionato `FarmingOrders` dovrebbe essere interamente rispettato nella sessione di agricoltura corrente (poiché ogni partita ha lo stesso valore di prestazione), mentre l'ordine effettivo dell'algoritmo `Complesso` è influenzato dalle ore prima, e poi ordinati in base alla `FarmingOrders`. Questo porterà a risultati diversi, in quanto i giochi con il tempo di gioco esistente avranno una priorità rispetto agli altri, in modo efficace ASF preferirà i giochi che già passati richiesti `HoursUntilCardDrops` in primo luogo, e solo allora l'ordinamento di questi giochi più lontano secondo la `FarmingOrders` scelto. Allo stesso modo, una volta che ASF corre fuori di già-urtato giochi, si ordinerà prima la coda rimanente per ore (come questo diminuirà il tempo necessario per urtare uno dei titoli rimanenti su `Ore UntilCardDrops`). Pertanto, questa proprietà di configurazione è solo un suggerimento **** che ASF cercherà di rispettare, fintanto che non influisce negativamente sulle prestazioni (in questo caso, ASF preferirà sempre le prestazioni agricole rispetto a `FarmingOrders`).

C'è anche la coda prioritaria di allevamento che è accessibile tramite i comandi `fq` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Se è usato, l'ordine di allevamento reale viene ordinato prima per prestazione, poi per allevamento coda e infine per il tuo `FarmingOrders`.

---

### `Preferenze`

`byte flag` tipo con valore predefinito di `0`. Questa proprietà definisce il comportamento di ASF relativo all'agricoltura ed è definita come di seguito:

| Valore | Nome                       |
| ------ | -------------------------- |
| 0      | Nessuna data               |
| 1      | FarmingPausedByDefault     |
| 2      | ShutdownOnFarmingFinished  |
| 4      | SendOnFarmingFinished      |
| 8      | FarmPriorityQueueOnly      |
| 16     | SkipRefundableGames        |
| 32     | SkipUnplayedGames          |
| 64     | AbilitaRiskyCardsDiscovery |
| 256    | AutoUnpackBoosterPacks     |

Si prega di notare che questa proprietà è `flags` campo, quindi è possibile scegliere qualsiasi combinazione di valori disponibili. Scopri **[json mapping](#json-mapping)** se vuoi saperne di più. Non abilitare nessuno dei flag comporta l'opzione `Nessuno`.

Tutte le opzioni sono descritte di seguito.

`FarmingPausedByDefault` definisce lo stato iniziale del modulo `CardsFarmer`. Normalmente il bot avvierà automaticamente l'agricoltura quando viene avviato, a causa del comando `Abilitato` o `avvia`. Utilizzando `FarmingPausedByDefault` può essere utilizzato se si desidera manualmente `riprendere` processo di allevamento automatico, ad esempio perché si desidera utilizzare sempre `play` e non utilizzare mai il modulo automatico `CardsFarmer` - questo funziona esattamente come `pausa` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

`ShutdownOnFarmingFinished` ti permette di spegnere il bot una volta fatto l'agricoltura. Normalmente ASF è "occupante" un account per tutto il tempo del processo di essere attivo. Quando il conto dato è fatto con l'agricoltura, ASF lo controlla periodicamente (ogni `IdleFarmingPeriod` ore), se forse alcuni nuovi giochi con carte vapore sono stati aggiunti nel frattempo, in modo da poter riprendere l'agricoltura di quel conto senza bisogno di riavviare il processo. Questo è utile per la maggior parte delle persone, in quanto ASF può riprendere automaticamente l'agricoltura quando necessario. Tuttavia, si può effettivamente voler interrompere il processo quando l'account dato è completamente allevato, è possibile raggiungere questo obiettivo utilizzando questo flag. Se abilitato, ASF procederà con la disconnessione quando l'account è completamente allevato, il che significa che non sarà più controllato periodicamente o occupato. Dovresti decidere te stesso se preferisci ASF per lavorare su una data istanza del bot per tutto il tempo, o se forse ASF dovrebbe fermarlo quando si fa il processo agricolo.

Questa opzione ha il più senso da combinare con `ShutdownIfPossible`, quindi quando tutti gli account sono fermati, ASF si spegnerà pure, mettere la macchina a riposo e permettere di programmare altre azioni, come il sonno o l'arresto nello stesso momento dell'ultimo rilascio della carta.

`SendOnFarmingFinished` ti permette di inviare automaticamente il commercio di vapore contenente tutto ciò che è coltivato fino a questo punto all'utente con il permesso `Master` , che è molto conveniente se non si vuole preoccuparsi con i mestieri da soli. Questa opzione funziona come il comando `loot` , quindi tieni presente che richiede l'utente con `Master` set di autorizzazioni, you may also need a valid `SteamTradeToken`, oltre a utilizzare un conto che è ammissibile per la negoziazione in primo luogo. Oltre ad avviare il bottino `` dopo aver terminato l'agricoltura, ASF avvierà anche il bottino `` su ogni nuova notifica di elementi (quando non si coltiva), e dopo aver completato ogni operazione che si traduce in nuovi elementi (sempre) quando questa opzione è attiva. Questo è particolarmente utile per "inoltrare" gli elementi ricevuti da altre persone al nostro account. In genere si desidera utilizzare **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** insieme a questa funzione, anche se non è un requisito se si intende gestire manualmente le conferme 2FA in modo tempestivo.

`FarmPriorityQueueOnly` definisce se ASF dovrebbe considerare per l'agricoltura automatica solo le applicazioni che ti hai aggiunto alla coda di agricoltura prioritaria disponibile con i comandi `fq` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Quando questa opzione è abilitata, ASF salterà tutti gli `appID` che mancano nella lista, in modo efficace permettendo di cherry-pick giochi per l'agricoltura automatica di ASF. Tieni presente che se non hai aggiunto alcun gioco alla coda, ASF agirà come se non c'è nulla da coltivare sul tuo account.

`SkipRefundableGames` definisce se ASF dovrebbe saltare i giochi che sono ancora rimborsabili da agricoltura automatica. Un gioco rimborsabile è un gioco che hai acquistato nelle ultime 2 settimane attraverso Steam Store e non hai ancora giocato per più di 2 ore, come indicato nella pagina **[rimborsi Steam](https://store.steampowered.com/steam_refunds)**. Per impostazione predefinita, ASF ignora completamente la politica di rimborso di Steam e fattoria tutto, come la maggior parte delle persone si aspetta. Tuttavia, è possibile utilizzare questa bandiera se si desidera assicurarsi che ASF non si allevia nessuno dei vostri giochi rimborsabili troppo presto, permettendo di valutare quei giochi da soli e rimborsare se necessario senza preoccuparsi di ASF che influenzano negativamente il tempo di gioco. Si prega di notare che se si abilita questa opzione, i giochi acquistati da Steam Store non saranno coltivati da ASF per un massimo di 14 giorni dalla data di riscatto, che mostrerà come niente per allevare se il tuo account non possiede nient'altro.

`SkipUnplayedGames` definisce se ASF dovrebbe saltare i giochi che non hai ancora lanciato. Gioco non giocato in questo contesto significa che non hai esattamente nessun tempo di gioco registrato su Steam. Se si utilizza questa bandiera, tali giochi saranno saltati fino a quando Steam registra qualsiasi tempo di gioco per loro. Questo ti permette di controllare meglio quali giochi ASF è idoneo a coltivare, saltando quelli che non hai avuto la possibilità di provare ancora, mantenere le funzioni di Steam selezionate più utili - come suggerire giochi non giocati per giocare.

`AbilitaRiskyCardsDiscovery` abilita un ripiego aggiuntivo che attiva quando ASF non è in grado di caricare una o più pagine di badge e quindi non è in grado di trovare giochi disponibili per l'agricoltura. In particolare, alcuni account con enormi quantità di gocce di carta potrebbero causare una situazione in cui il caricamento di pagine distintivo non è più possibile (a causa di spese generali), e questi conti sono impossibili per l'agricoltura solo perché non possiamo caricare le informazioni in base alle quali possiamo avviare il processo. Per quei casi manciati, questa opzione consente di utilizzare un algoritmo alternativo, che utilizza una combinazione di booster possibili per creare e booster pack il conto è idoneo per, al fine di trovare giochi potenzialmente disponibili da inattivare, spendere quantità eccessive di risorse per verificare e recuperare le informazioni richieste, e cercando di avviare il processo di allevamento su quantità limitata di dati e informazioni al fine di raggiungere finalmente una situazione in cui il distintivo carica pagina e saremo in grado di utilizzare l'approccio normale. Si prega di notare che quando viene utilizzato questo fallback, ASF funziona solo con dati limitati, quindi è del tutto normale per ASF trovare meno gocce che in realtà - altre gocce saranno trovate in fase successiva del processo agricolo.

Questa opzione è chiamata "rischiosa" per una buona ragione - è estremamente lenta e richiede una notevole quantità di risorse (comprese le richieste di rete) per il funzionamento, quindi è **non consigliato** per essere abilitato, e soprattutto a lungo termine. Dovresti usare questa opzione solo se hai precedentemente stabilito che il tuo account soffre di non essere in grado di caricare le pagine del badge e ASF non può operare su di esso, sempre non caricando le informazioni necessarie per avviare il processo. Anche se abbiamo fatto del nostro meglio per ottimizzare il processo il più possibile, è ancora possibile per questa opzione a backfire, e potrebbe causare risultati indesiderati, come i divieti temporanei e forse permanenti da parte di Steam per l'invio di troppe richieste e altrimenti causando sovraccarico sui server di Steam. Pertanto, ti avvisiamo in anticipo e offriamo questa opzione senza alcuna garanzia, la stai usando a tuo rischio.

`AutoUnpackBoosterPack` scompatterà automaticamente tutti i pacchetti di richiamo dopo aver ricevuto la notifica dei nuovi elementi. Questo vi permetterà di acquisire immediatamente ulteriori gocce di carta, che potrebbe essere desiderato scenario soprattutto in combinazione con altre opzioni (e. . `SteamTradeMatcher` o `CompleteTypesToSend`).

---

### `GiochiPlayedWhileIdle`

Tipo `ImmutableHashSet<uint>` con valore predefinito vuoto. Se ASF non ha nulla da coltivare può giocare i tuoi giochi di vapore specificati (`appIDs`) invece. Giocare ai giochi in questo modo aumenta le vostre "ore giocate" di quei giochi, ma nient'altro a parte di esso. In order for this feature to work properly, your Steam account **must** own a valid license to all the `appIDs` that you specify here, this includes F2P games as well. Questa funzione può essere abilitata contemporaneamente con `CustomGamePlayedWhileIdle` per giocare ai giochi selezionati mentre si mostra lo stato personalizzato nella rete di Steam, ma in questo caso, come nel caso `CustomGamePlayedWhileFarming` , l'ordine di visualizzazione effettivo non è garantito. Si prega di notare che Steam consente a ASF di giocare solo fino a `32` `appIDs` totale, quindi è possibile mettere solo tanti giochi in questa proprietà.

---

### `GamingDeviceType`

Tipo `ushort` con valore predefinito di `1`. Questa proprietà può abilitare alcune funzionalità online aggiuntive sulla piattaforma di Steam, ed è definita come di seguito:

| Valore | Nome       | Descrizione                             |
| ------ | ---------- | --------------------------------------- |
| 1      | StandardPC | Nessuna modalità speciale, predefinita  |
| 544    | SteamDeck  | Presenta se stesso come mazzo di vapore |

Il tipo sottostante `EGamingDeviceType` che questa proprietà si basa su include più valori disponibili, tuttavia, al meglio delle nostre conoscenze non hanno assolutamente alcun effetto a partire da oggi, quindi sono stati tagliati per la visibilità.

Se non sei sicuro di come impostare questa proprietà, lasciala con valore predefinito di `1`.

---

### `OreUntilCardDrops`

Tipo `byte` con valore predefinito di `3`. Questa proprietà definisce se l'account ha gocce di carta limitate, e se sì, per quante ore iniziali. Limitato gocce di carte significa che l'account non sta ricevendo alcuna goccia di carte da un determinato gioco fino a quando il gioco è giocato per almeno `OreUntilCardDrops` ore. Purtroppo non c'è modo magico per rilevare che, in modo da ASF si basa su di voi. Questa proprietà influisce sull'algoritmo **[di allevamento delle carte](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** che verrà utilizzato. Impostare correttamente questa proprietà massimizzerà i profitti e minimizzerà il tempo necessario per le carte da coltivare. Ricorda che non c'è una risposta ovvia se dovresti usare uno o un altro valore, poiché dipende completamente dal tuo account. Sembra che gli account più vecchi che non hanno mai chiesto il rimborso abbiano gocce di carta senza restrizioni, così dovrebbero utilizzare un valore di `0`, mentre i nuovi account e quelli che hanno chiesto il rimborso hanno limitato le gocce di carta con un valore di `3`. Questa è però solo teoria, e non dovrebbe essere considerata come una regola. Il valore predefinito per questa proprietà è stato impostato in base a "male minore" e la maggior parte dei casi di utilizzo.

---

### `Tipi Di Lootable`

Tipo `ImmutableHashSet<byte>` con valore predefinito di tipi di oggetti `1, 3, 5`. Questa proprietà definisce il comportamento di ASF quando si saccheggia - entrambi manuali, utilizzando un comando **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, così come uno automatico, attraverso una o più proprietà di configurazione. ASF garantirà che solo gli oggetti provenienti da `LootableTypes` saranno inclusi in un'offerta commerciale, quindi questa proprietà ti permette di scegliere quello che vuoi ricevere in un'offerta commerciale che ti viene inviata.

| Valore | Nome               | Descrizione                                                                      |
| ------ | ------------------ | -------------------------------------------------------------------------------- |
| 0      | Sconosciuto        | Ogni tipo che non si adatta in nessuno dei sotto                                 |
| 1      | BoosterPack        | Pacchetto potenziatore contenente 3 carte casuali da una partita                 |
| 2      | Emoticon           | Emoticon da usare nella chat di Steam                                            |
| 3      | FoilTradingCard    | Variante della stagnola di `TradingCard`                                         |
| 4      | ProfileSfondo      | Sfondo del profilo da usare sul tuo profilo Steam                                |
| 5      | TradingCard        | Carta commerciale a vapore, utilizzata per la creazione di distintivi (non-foil) |
| 6      | Gemme A Vapore     | Gemme a vapore utilizzate per la creazione di booster, sacchi inclusi            |
| 7      | SaleItem           | Articoli speciali assegnati durante le vendite di Steam                          |
| 8      | Consumabile        | Oggetti speciali consumabili che scompaiono dopo essere stati utilizzati         |
| 9      | ProfileModifier    | Elementi speciali che possono modificare l'aspetto del profilo di Steam          |
| 10     | Adesivo            | Oggetti speciali che possono essere utilizzati nella chat di Steam               |
| 11     | ChatEffect         | Oggetti speciali che possono essere utilizzati nella chat di Steam               |
| 12     | MiniProfileSfondo  | Sfondo speciale per il profilo Steam                                             |
| 13     | AvatarProfileFrame | Cornice avatar speciale per il profilo Steam                                     |
| 14     | AnimatedAvatar     | Avatar animato speciale per il profilo Steam                                     |
| 15     | TastieraSkin       | Skin speciale della tastiera per il mazzo Steam                                  |
| 16     | StartupVideo       | Video di avvio speciale per il mazzo Steam                                       |

Si prega di notare che indipendentemente dalle impostazioni sopra riportate, ASF chiederà solo gli elementi **[della comunità di Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` di 753, `contextID` di 6), quindi tutti gli articoli di gioco, i regali e allo stesso modo, sono esclusi dall'offerta di commercio per definizione.

L'impostazione predefinita di ASF è basata sull'uso più comune del bot, con il saccheggio solo pacchetti di booster e carte di trading (comprese le lampade). La proprietà qui definita consente di modificare quel comportamento in qualsiasi modo che ti soddisfi. Tieni presente che tutti i tipi non definiti sopra mostreranno come tipo `Sconosciuto` , che è particolarmente importante quando Valve rilascia qualche nuovo elemento Steam, che sarà contrassegnato come `Sconosciuto` anche da ASF, fino a quando non viene aggiunto qui (nella versione futura). Ecco perché in generale non è consigliabile includere il tipo `Sconosciuto` nel tuo `LootableTypes`, a meno che tu non sappia cosa stai facendo, e capisci anche che ASF invierà l'intero inventario in un'offerta commerciale se Steam Network viene rotto di nuovo e segnala tutti i tuoi articoli come `Sconosciuto`. Il mio forte suggerimento è di non includere il tipo `Sconosciuto` nel tipo `LootableTypes`, anche se ci si aspetta di bottinare tutto (altro).

---

### `MachineName`

Tipo `stringa` con valore predefinito `null`. ASF userà questa proprietà quando si accede alla rete di Steam, che può essere utilizzato per la personalizzazione per quanto riguarda come esattamente Steam visualizzerà macchina ASF e sessione, e. . quando si visualizzano dispositivi che sono attualmente connessi in **[qui](https://store.steampowered.com/account/authorizeddevices)**.

ASF fornisce alcune variabili speciali che è possibile utilizzare opzionalmente nel testo. `{0}` sarà sostituito dal nome della macchina fornito dal tuo sistema operativo, `{1}` sarà sostituito dall'identificatore pubblico di ASF, mentre `{2}` sarà sostituita dalla versione di ASF.

A meno che tu non sappia cosa stai facendo, dovresti tenerlo con il valore predefinito di `null`. In questo caso, ASF deciderà internamente circa il valore corretto, che è `{0} ({1}/{2})` a partire da oggi. Tenete a mente che questo è solo un suggerimento che la rete di Steam può, o non può rispettare, in pieno.

---

### `MatchableTypes`

`ImmutableHashSet<byte>` type with default value of `5` Steam types Questa proprietà definisce quali tipi di elementi Steam possono essere abbinati quando l'opzione `SteamTradeMatcher` in `TradingPreferenze` è abilitata. I tipi sono definiti come di seguito:

| Valore | Nome               | Descrizione                                                                      |
| ------ | ------------------ | -------------------------------------------------------------------------------- |
| 0      | Sconosciuto        | Ogni tipo che non si adatta in nessuno dei sotto                                 |
| 1      | BoosterPack        | Pacchetto potenziatore contenente 3 carte casuali da una partita                 |
| 2      | Emoticon           | Emoticon da usare nella chat di Steam                                            |
| 3      | FoilTradingCard    | Variante della stagnola di `TradingCard`                                         |
| 4      | ProfileSfondo      | Sfondo del profilo da usare sul tuo profilo Steam                                |
| 5      | TradingCard        | Carta commerciale a vapore, utilizzata per la creazione di distintivi (non-foil) |
| 6      | Gemme A Vapore     | Gemme a vapore utilizzate per la creazione di booster, sacchi inclusi            |
| 7      | SaleItem           | Articoli speciali assegnati durante le vendite di Steam                          |
| 8      | Consumabile        | Oggetti speciali consumabili che scompaiono dopo essere stati utilizzati         |
| 9      | ProfileModifier    | Elementi speciali che possono modificare l'aspetto del profilo di Steam          |
| 10     | Adesivo            | Oggetti speciali che possono essere utilizzati nella chat di Steam               |
| 11     | ChatEffect         | Oggetti speciali che possono essere utilizzati nella chat di Steam               |
| 12     | MiniProfileSfondo  | Sfondo speciale per il profilo Steam                                             |
| 13     | AvatarProfileFrame | Cornice avatar speciale per il profilo Steam                                     |
| 14     | AnimatedAvatar     | Avatar animato speciale per il profilo Steam                                     |
| 15     | TastieraSkin       | Skin speciale della tastiera per il mazzo Steam                                  |
| 16     | StartupVideo       | Video di avvio speciale per il mazzo Steam                                       |

Naturalmente, i tipi che dovresti usare per questa proprietà in genere includono solo `2`, `3`, `4` e `5`, poiché solo questi tipi sono supportati da STM. ASF include una logica adeguata per scoprire la rarità degli oggetti, quindi è anche sicuro abbinare emoticon o sfondi, poiché ASF prenderà in considerazione correttamente solo quegli elementi dello stesso gioco e tipo, che condividono anche la stessa rarità.

Si prega di notare che **ASF non è un bot di trading** e **NON si occuperà del prezzo di mercato**. Se non consideri gli oggetti della stessa rarità dello stesso set come lo stesso prezzo, allora questa opzione NON è per te. Si prega di valutare due volte se si capisce e si accetta questa dichiarazione prima di decidere di modificare questa impostazione.

A meno che tu non sappia cosa stai facendo, dovresti mantenerlo con il valore predefinito di `5`.

---

### `Bandiere Online`

`ushort flags` type with default value of `0`. Questa proprietà funziona come supplemento ad **[`OnlineStatus`](#onlinestatus)** e specifica ulteriori funzionalità di presenza online annunciate alla rete di Steam. Richiede **[`OnlineStatus`](#onlinestatus)** diverso da `Offline`ed è definito come di seguito:

| Valore | Nome               | Descrizione                                                     |
| ------ | ------------------ | --------------------------------------------------------------- |
| 0      | Nessuna data       | Nessuna speciale bandiera di presenza online, predefinita       |
| 2      | InJoinableGame     | Il client è in gioco unibile                                    |
| 8      | RemotePlayTogether | Il client sta usando la sessione di riproduzione remota insieme |
| 256    | ClientTypeWeb      | Il client sta utilizzando l'interfaccia web                     |
| 512    | ClientTypeMobile   | Il client sta utilizzando l'app mobile                          |
| 1024   | ClientTypeTenfoot  | Il client sta usando immagine grande                            |
| 2048   | ClientTypeVR       | Il client sta usando l'auricolare VR                            |

Si prega di notare che questa proprietà è `flags` campo, quindi è possibile scegliere qualsiasi combinazione di valori disponibili. Scopri **[json mapping](#json-mapping)** se vuoi saperne di più. Non abilitare nessuno dei flag comporta l'opzione `Nessuno`.

Il tipo sottostante `EPersonaStateFlag` che questa proprietà si basa su include più bandiere disponibili, tuttavia, al meglio delle nostre conoscenze non hanno assolutamente alcun effetto a partire da oggi, quindi sono stati tagliati per la visibilità.

Se non sei sicuro di come impostare questa proprietà, lasciala con valore predefinito di `0`.

---

### `Stato Online`

Tipo `byte` con valore predefinito di `1`. Questa proprietà specifica lo stato della comunità di Steam con cui il bot sarà annunciato dopo l'accesso alla rete di Steam. Attualmente è possibile scegliere uno degli stati seguenti:

| Valore | Nome           |
| ------ | -------------- |
| 0      | Offline        |
| 1      | Online         |
| 2      | Occupato       |
| 3      | Assente        |
| 4      | Posticipa      |
| 5      | LookingToTrade |
| 6      | LookingToPlay  |
| 7      | Invisibile     |

Lo stato `Offline` è estremamente utile per gli account primari. Come dovreste sapere, l'agricoltura di un gioco in realtà mostra il vostro stato di vapore come "Giocare gioco: XXX", che può essere fuorviante per i tuoi amici, confondendoli che stai giocando un gioco mentre in realtà sei solo coltivare esso. Utilizzando lo stato `Offline` risolve questo problema - il tuo account non verrà mai mostrato come "in-game" quando stai coltivando schede a vapore con ASF. Ciò è possibile grazie al fatto che la ASF non deve entrare nella Comunità di vapore per funzionare correttamente, quindi stiamo giocando a quei giochi, collegati alla rete Steam, ma senza annunciare la nostra presenza online. Tenete a mente che le partite giocate usando lo stato offline contano ancora per il vostro tempo di gioco, e si mostrano come "recentemente" sul vostro profilo.

In aggiunta a ciò, questa funzione è anche importante se si desidera ricevere notifiche e messaggi non letti quando ASF è in esecuzione, mentre non tiene il client Steam aperto allo stesso tempo. Questo perché ASF agisce come un client Steam stesso e se ASF lo vorrebbe o meno, Steam trasmette tutti quei messaggi e altri eventi ad esso. Questo non è un problema se hai sia ASF che il tuo client Steam in esecuzione, in quanto entrambi i clienti ricevono esattamente gli stessi eventi. Tuttavia, se solo ASF è in esecuzione, la rete Steam potrebbe contrassegnare determinati eventi e messaggi come "consegnati", nonostante il vostro cliente tradizionale Steam non riceverlo a causa del non essere presente. Lo stato offline risolve anche questo problema, in quanto ASF non è mai considerato per nessun evento della comunità in questo caso, quindi tutti i messaggi non letti e gli altri eventi saranno correttamente contrassegnati come non letti quando torni.

È importante notare che ASF in esecuzione in modalità `Offline` sarà **non** in grado di ricevere comandi nella solita chat di Steam, come la chat, così come tutta la presenza comunitaria è in realtà, interamente offline. Una soluzione a questo problema sta usando la modalità `Invisibile` che funziona in modo simile (non esponendo lo status), ma mantiene la capacità di ricevere e rispondere ai messaggi (quindi anche un potenziale per respingere le notifiche e i messaggi non letti come indicato sopra). La modalità `invisibile` ha il senso maggiore sugli account alt che non si desidera esporre (status-wise), ma essere ancora in grado di inviare comandi a.

Tuttavia, c'è una cattura con la modalità `Invisibile` - non va bene con gli account primari. Questo perché **qualsiasi sessione** Steam che è attualmente online **espone** lo stato, anche se ASF stesso non lo fa. Questo è causato dalla limitazione/bug corrente della rete Steam che non è possibile fissare sul lato di ASF, quindi se vuoi utilizzare la modalità `Invisibile` dovrai anche assicurarti che **tutte le altre sessioni** allo stesso account utilizzino anche la modalità `Invisibile`. Questo sarà il caso su account alt dove ASF è speriamo l'unica sessione attiva, ma sugli account primari preferisci quasi sempre mostrare come `Online` ai tuoi amici, nascondere solo attività di ASF, e in questo caso la modalità `Invisibile` sarà completamente inutile per te (si consiglia di utilizzare la modalità `Offline` invece). Speriamo che questa limitazione / bug sarà finalmente risolta in futuro da Valve, ma non mi aspetterei che succeda in qualsiasi momento presto...

Se non sei sicuro di come configurare questa proprietà, si raccomanda di utilizzare un valore di `0` (`Offline`) per gli account primari, e di default `1` (`Online`) altrimenti.

---

### `PasswordFormat`

Tipo `byte` con valore predefinito di `0` (`PlainText`). Questa proprietà definisce il formato della proprietà `SteamPassword` , e attualmente supporta i valori specificati nella sezione **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**. Dovresti seguire le istruzioni qui specificate, in quanto avrai bisogno di assicurarsi che la proprietà `SteamPassword` includa effettivamente la password nella corrispondenza `PasswordFormat`. In altre parole, quando cambi `PasswordFormat` allora il tuo `SteamPassword` dovrebbe essere **già** in quel formato, non puntando solo ad essere. A meno che tu non sappia cosa stai facendo, dovresti mantenerlo con il valore predefinito di `0`.

Se decidi di cambiare `PasswordFormat` di un bot che ha già effettuato l'accesso alla rete di Steam almeno una volta, è possibile che si ottiene un errore di decrittografia una volta al prossimo avvio del bot - questo è causato dal fatto che `PasswordFormat` è utilizzato anche per quanto riguarda la crittografia automatica/decrittografia delle proprietà sensibili nel bot `. b file del database`. Si può tranquillamente ignorare tale errore, come ASF sarà in grado di recuperare da questa situazione da solo. Se sta accadendo su base costante, però, ad esempio ogni riavvio, dovrebbe essere indagato.

---

### `Preferenze`

`byte flag` tipo con valore predefinito di `0`. Questa proprietà definisce il comportamento di ASF quando si riscattano cd-keys, ed è definita come di seguito:

| Valore | Nome                               | Descrizione                                                                                                                                    |
| ------ | ---------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| 0      | Nessuna data                       | Nessuna preferenza speciale di riscatto, predefinita                                                                                           |
| 1      | Inoltro                            | Chiavi di inoltro non disponibili per riscattare altri bot                                                                                     |
| 2      | Distribuzione                      | Distribuisci tutte le chiavi tra sé e gli altri bot                                                                                            |
| 4      | KeepMissingGames                   | Mantieni le chiavi per (potenzialmente) partite mancanti durante l'inoltro lasciandole inutilizzate                                            |
| 8      | AssumeWalletKeyOnBadActivationCode | Assumi che le chiavi `BadActivationCode` siano uguali a `CannotRedeemCodeFromClient`, e quindi prova a riscattarle come chiavi del portafoglio |

Si prega di notare che questa proprietà è `flags` campo, quindi è possibile scegliere qualsiasi combinazione di valori disponibili. Scopri **[json mapping](#json-mapping)** se vuoi saperne di più. Non abilitare nessuno dei flag comporta l'opzione `Nessuno`.

`Inoltro` farà sì che il bot inoltra una chiave che non è possibile riscattare, ad un altro bot connesso e loggato che manca quel particolare gioco (se possibile per controllare). La situazione più comune è l'inoltro di `giàAcquistato` gioco a un altro bot che manca quel particolare gioco, ma questa opzione comprende anche altri scenari, come `DoesNotOwnRequiredApp`, `RateLimited` o `RestrictedCountry`.

La distribuzione `` farà sì che il bot distribuisca tutte le chiavi ricevute tra di sé e gli altri bot. Ciò significa che ogni bot otterrà una singola chiave dal lotto. In genere questo viene utilizzato solo quando si sta riscattando molte chiavi per lo stesso gioco, e si desidera distribuirli uniformemente tra i vostri bot, al contrario di riscattare chiavi per vari giochi diversi. Questa funzione non ha senso se stai riscattando solo una chiave in una singola azione `riscattare` (come non ci sono chiavi extra da distribuire).

`KeepMissingGames` farà saltare il bot `Inoltro` quando non possiamo essere sicuri che la chiave riscattata sia di proprietà del nostro bot, oppure no. Questo significa fondamentalmente che `Inoltro` applicherà **solo** a `chiavi già acquistate` , invece di coprire anche altri casi come `DoesNotOwnRequiredApp`, `RateLimited` o `RestrictedCountry`. In genere si desidera utilizzare questa opzione sull'account primario, per assicurarsi che le chiavi che vengono riscattate su di esso non saranno inoltrate ulteriormente se il tuo bot ad esempio diventa temporaneamente `RateLimited`. Come puoi indovinare dalla descrizione, questo campo non ha assolutamente effetto se `Inoltro` non è abilitato.

`AssumeWalletKeyOnBadActivationCode` farà sì che le chiavi `BadActivationCode` siano trattate come `CannotRedeemCodeFromClient`, e quindi risultato in ASF cercando di riscattarli come chiavi del portafoglio. Ciò è necessario perché Steam potrebbe annunciare le chiavi del portafoglio come `BadActivationCode` (e non `CannotRedeemCodeFromClient` come usava), con conseguente ASF non tentare mai di riscattarli. Tuttavia, raccomandiamo **contro** utilizzando questa preferenza, come risulterà in ASF cercando di riscattare ogni chiave non valida come codice del portafoglio, con conseguente quantità eccessiva di richieste (potenzialmente non valide) inviate al servizio Steam, con tutte le possibili conseguenze. Invece, consigliamo di utilizzare la modalità `ForceAssumeWalletKey` **[`redeem^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** mentre intenzionalmente riscattare le chiavi del portafoglio, che permetterà il workaround necessario solo quando è richiesto, su base come necessario.

Abilitando sia `Forwarding` che `Distributing` si aggiungerà la funzione di distribuzione in aggiunta a quella di inoltro, che fa ASF cercando di riscattare una chiave su tutti i bot prima (inoltro) prima di passare a quella successiva (distribuzione). In genere si desidera utilizzare questa opzione solo quando si desidera `Inoltro`, ma con il comportamento alterato di commutare il bot sulla chiave in uso, invece di andare sempre in ordine con ogni chiave (che sarebbe `Inoltro` solo). Questo comportamento può essere vantaggioso se si sa che la maggior parte o anche tutte le chiavi sono legate allo stesso gioco, perché in questa situazione `Inoltro` da solo cercherebbe di riscattare tutto su un solo bot (in primo luogo (che ha senso se le chiavi sono per giochi unici), e `Inoltro` + `Distribuzione` cambierà il bot sulla prossima chiave, "distribuire" il compito di riscattare una nuova chiave su un altro bot rispetto a quello iniziale (che ha senso se le chiavi sono per lo stesso gioco, saltando un tentativo inutile per chiave).

L'ordine reale dei bot per tutti gli scenari di riscatto è alfabetico, esclusi i bot che non sono disponibili (non collegati, fermati o similari). Si prega di tenere a mente che esiste un limite orario per IP e per account di tentativi di riscatto, e ogni tentativo di riscattare che non è terminato con `OK` contribuisce a tentativi falliti. ASF farà del suo meglio per ridurre al minimo il numero di fallimenti `già acquistati` , ad es. cercando di evitare di inoltrare una chiave ad un altro bot che possiede già quel particolare gioco, ma non è sempre garantito di funzionare a causa di come Steam sta gestendo le licenze. Utilizzando bandiere di riscatto, come `Inoltro` o `Distribuzione` aumenterà sempre la tua probabilità per colpire `RateLimited`.

Tenete inoltre a mente che non è possibile inoltrare o distribuire le chiavi ai bot a cui non si ha accesso. Questo dovrebbe essere ovvio, ma assicurati di essere almeno `Operator` di tutti i bot che desideri includere nel tuo processo di riscatto, ad esempio con `stato ASF` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `RemoteCommunication`

`byte flags` tipo con valore predefinito di `3`. Questa proprietà definisce il comportamento ASF per bot quando si tratta di comunicazione con servizi remoti di terze parti ed è definita come di seguito:

| Valore | Nome          | Descrizione                                                                                                                                                                                                                                                     |
| ------ | ------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0      | Nessuna data  | Nessuna comunicazione di terze parti consentita, rendering di funzioni ASF selezionate inutilizzabili                                                                                                                                                           |
| 1      | SteamGroup    | Consente la comunicazione con il gruppo **[di ASF Steam](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                          |
| 2      | PublicListing | Consente la comunicazione con **[ASF STM che elenca](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** per essere elencato, se l'utente ha anche abilitato `SteamTradeMatcher` in **[`Preferenze`](#tradingpreferences)** |

Si prega di notare che questa proprietà è `flags` campo, quindi è possibile scegliere qualsiasi combinazione di valori disponibili. Scopri **[json mapping](#json-mapping)** se vuoi saperne di più. Non abilitare nessuno dei flag comporta l'opzione `Nessuno`.

Questa opzione non include tutte le comunicazioni di terze parti offerte da ASF, solo quelle che non sono implicite da altre impostazioni. Ad esempio, se hai abilitato gli aggiornamenti automatici di ASF, ASF comunicherà sia con GitHub (per i download) che con il nostro server (per la verifica del checksum), secondo la tua configurazione. Allo stesso modo, abilitando `MatchActively` in **[`TradingPreferences`](#tradingpreferences)** implica una comunicazione con il nostro server per recuperare i bot elencati, che è necessario per tale funzionalità.

Ulteriori spiegazioni su questo argomento sono disponibili nella sezione **[comunicazione remota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.

---

### `SendTradePeriod`

Tipo `byte` con valore predefinito di `0`. Questa proprietà funziona molto simile alla preferenza `SendOnFarmingFinished` in `FarmingPreferences`, con una differenza - invece di inviare il commercio quando si fa l'agricoltura, possiamo anche inviarlo ogni `SendTradePeriod` ore, indipendentemente da quanto abbiamo lasciato in azienda. Questo è utile se si desidera `bottino` il tuo account alt su base abituale invece di aspettare che finisca l'agricoltura. Il valore predefinito di `0` disabilita questa funzionalità, se vuoi che il tuo bot ti invii scambii. . ogni giorno, dovresti mettere `24` qui.

In genere si desidera utilizzare **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** insieme a questa funzione, anche se non è un requisito se si intende gestire manualmente le conferme 2FA in modo tempestivo. Se non sei sicuro di come impostare questa proprietà, lasciala con valore predefinito di `0`.

---

### `SteamLogin`

Tipo `stringa` con valore predefinito `null`. Questa proprietà definisce il tuo login di vapore - quello che usi per accedere a vapore. Oltre a definire il login di vapore qui, puoi anche mantenere il valore predefinito di `null` se vuoi inserire il tuo login di vapore su ogni avvio di ASF invece di inserirlo nella configurazione. Questo potrebbe essere utile per voi se non si desidera salvare i dati sensibili nel file di configurazione.

---

### `SteamMasterClanID`

`ulong` type with default value of `0`. Questa proprietà definisce l'ID steamdel gruppo di vapore al quale il bot dovrebbe automaticamente aderire, inclusa la chat di gruppo. Puoi controllare l'ID steamdel tuo gruppo navigando alla sua pagina **[](https://steamcommunity.com/groups/archiasf)**e quindi aggiungendo `/memberslistxml? ml=1` alla fine del link, quindi il link apparirà come **[questo](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. Quindi puoi ottenere ID vapore del tuo gruppo dal risultato, è nel tag `<groupID64>`. In questo esempio sarebbe `103582791440160998`. Oltre a cercare di unirsi al gruppo dato all'avvio, il bot accetterà automaticamente anche gli inviti di gruppo a questo gruppo, che ti permette di invitare manualmente il tuo bot se il tuo gruppo ha un abbonamento privato. Se non si dispone di alcun gruppo dedicato al bot, si dovrebbe mantenere questa proprietà con valore predefinito di `0`.

---

### `SteamParentalCode`

Tipo `stringa` con valore predefinito `null`. Questa proprietà definisce il tuo PIN parentale a vapore. ASF richiede un accesso alle risorse protette dai genitori di vapore, quindi se si utilizza quella funzione, si dovrebbe fornire ASF con PIN di sblocco parentale, in modo che possa funzionare normalmente. Valore predefinito di `null` significa che non è richiesto alcun PIN parentale di vapore per sbloccare questo account, e questo è probabilmente quello che si desidera se non si utilizza la funzionalità dei genitori a vapore.

In circostanze limitate, ASF è anche in grado di generare un valido codice parentale di Steam, anche se ciò richiede una quantità eccessiva di risorse OS e un tempo supplementare per completare, per non parlare del fatto che non è garantito il successo, quindi si consiglia di non fare affidamento su quella funzione e invece mettere valido `SteamParentalCode` nella configurazione per ASF da usare. Se ASF determina che il PIN è necessario, e non sarà in grado di generarne uno da solo, ti chiederà l'input.

---

### `SteamPassword`

Tipo `stringa` con valore predefinito `null`. Questa proprietà definisce la tua password di vapore - quella che usi per accedere a vapore. Oltre a definire la password di vapore qui, puoi anche mantenere il valore predefinito di `null` se vuoi inserire la password di vapore su ogni avvio di ASF invece di inserirla nella configurazione. Questo potrebbe essere utile per voi se non si desidera salvare i dati sensibili nel file di configurazione.

---

### `SteamTradeToken`

Tipo `stringa` con valore predefinito `null`. Quando hai il tuo bot nella tua lista di amici, allora il bot può inviarti subito un commercio senza preoccuparti del token commerciale, quindi puoi lasciare questa proprietà al valore predefinito di `null`. Se decidi comunque di non avere il tuo bot nella tua lista di amici, allora sarà necessario generare e riempire un token di scambio come l'utente che questo bot si aspetta di inviare scambi a. In altre parole, questa proprietà dovrebbe essere riempita con il token di trading dell'account definito con il permesso `Master` in `SteamUserPermissions` di **questa istanza di bot**.

Per trovare il tuo token, come utente connesso con il permesso `Master` , naviga **[qui](https://steamcommunity.com/my/tradeoffers/privacy)** e dai un'occhiata alla tua URL di trading. Il token che stiamo cercando è composto da 8 caratteri dopo la parte `&token=` nel tuo trade URL. Dovresti copiare e mettere questi 8 caratteri qui, come `SteamTradeToken`. Non includere l'URL di trading intero, né la parte `&& token=` , solo il token stesso (8 caratteri).

---

### `SteamUserPermissions`

Tipo `ImmutableDictionary<ulong, byte>` con valore predefinito di essere vuoto. Questa proprietà è una proprietà del dizionario che mappa l'utente di Steam identificato dal suo ID vapore a 64 bit, ad `byte` numero che specifica il suo permesso nell'istanza di ASF. I permessi del bot attualmente disponibili in ASF sono definiti come:

| Valore | Nome                  | Descrizione                                                                                                                                                                                                                                                            |
| ------ | --------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0      | Nessuna data          | Nessun permesso speciale, questo è principalmente un valore di riferimento che viene assegnato agli ID di vapore mancanti in questo dizionario - non c'è bisogno di definire nessuno con questo permesso                                                               |
| 1      | Condivisione Famiglia | Fornisce un accesso minimo per gli utenti della condivisione familiare. Ancora una volta, questo è principalmente un valore di riferimento in quanto ASF è in grado di scoprire automaticamente gli ID di vapore che abbiamo permesso di utilizzare la nostra libreria |
| 2      | Operatore             | Fornisce accesso di base a determinate istanze del bot, principalmente aggiungendo licenze e chiavi di riscatto                                                                                                                                                        |
| 3      | Maestro               | Fornisce accesso completo a una data istanza del bot                                                                                                                                                                                                                   |

In breve, questa proprietà consente di gestire i permessi per determinati utenti. Le autorizzazioni sono importanti soprattutto per l'accesso ai comandi</a></strong>di ASF **

, ma anche per abilitare molte funzionalità di ASF, come l'accettazione di operazioni. Ad esempio, potresti voler impostare il tuo account come `Master`, e dare a `Operatore` l'accesso a 2-3 dei tuoi amici in modo che possano facilmente riscattare le chiavi per il tuo bot con ASF, mentre **non** è ammissibile e. . per fermarlo. Grazie a ciò è possibile assegnare facilmente le autorizzazioni agli utenti dati e consentire loro di utilizzare il bot ad alcuni specificati dal vostro grado.</p> 

Si consiglia di impostare esattamente un utente come `Master`e qualsiasi importo che si desidera come `Operatori` e sotto. Mentre è tecnicamente possibile impostare più master `` e ASF funzionerà correttamente con loro, ad esempio accettando tutti i loro scambi inviati al bot, ASF userà solo uno di loro (con l'ID vapore più basso) per ogni azione che richiede un singolo bersaglio, ad esempio una richiesta `loot` , così anche proprietà come `SendOnFarmingFinished` preference in `FarmingPreferences` or `SendTradePeriod`. Se comprendete perfettamente tali limitazioni, in particolare il fatto che la richiesta di `bottino` invierà sempre oggetti alla `Master` con ID vapore più basso, indipendentemente dal Master `` che ha effettivamente eseguito il comando, allora è possibile definire più utenti con `Master` autorizzazione qui, ma si consiglia ancora un singolo schema master.

È bello notare che c'è un ulteriore permesso `Owner` aggiuntivo, che viene dichiarato come `SteamOwnerID` proprietà globale di configurazione. Non puoi assegnare il permesso `Proprietario` a nessuno qui, come la proprietà `SteamUserPermissions` definisce solo le autorizzazioni correlate all'istanza del bot e non ASF come un processo. Per i compiti relativi al bot, `SteamOwnerID` viene trattato come `Master`, quindi definire il tuo `SteamOwnerID` qui non è necessario.



---



### `TradeCheckPeriod`

Tipo `byte` con valore predefinito di `60`. Normalmente ASF gestisce le offerte commerciali in entrata subito dopo aver ricevuto una notifica su uno, ma a volte a causa di problemi Steam non può farlo in quel momento, e tali offerte di scambio rimangono ignorate fino alla successiva notifica di scambio o al riavvio del bot, che possono comportare la cancellazione di operazioni o articoli non disponibili in quel momento. Se questo parametro è impostato a un valore diverso da zero, ASF controllerà inoltre per tali operazioni in sospeso ogni minuto `TradeCheckPeriod`. Il valore predefinito è selezionato con il bilanciamento tra le richieste aggiuntive ai server di vapore e la perdita di operazioni in entrata in mente. Tuttavia, se si utilizza solo ASF per fattoria, e non pianificare di elaborare automaticamente qualsiasi commercio in entrata, puoi impostarlo su `0` per disabilitare completamente questa funzionalità. D'altra parte, se il tuo bot partecipa all'annuncio pubblico [di ASF di STM](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) o fornisce altri servizi automatizzati come bot di scambio, si consiglia di diminuire questo parametro in `15` minuti o giù di lì, per elaborare tutte le operazioni in modo tempestivo.



---



### `TradingPreferences`

`byte flag` tipo con valore predefinito di `0`. Questa proprietà definisce il comportamento di ASF durante il trading ed è definita come di seguito:

| Valore | Nome                | Descrizione                                                                                                                                                                                                                                     |
| ------ | ------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0      | Nessuna data        | Nessuna preferenza di trading speciale, predefinita                                                                                                                                                                                             |
| 1      | AcceptDonations     | Accetta i mestieri in cui non stiamo perdendo nulla                                                                                                                                                                                             |
| 2      | SteamTradeMatcher   | Passivamente partecipa a **[STM](https://www.steamtradematcher.com)**- come le operazioni. Visita **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** per maggiori informazioni                        |
| 4      | AbbinamentiTutto    | Richiede `SteamTradeMatcher` per essere impostato, e in combinazione con esso - accetta anche cattivi scambi in aggiunta a quelli buoni e neutri                                                                                                |
| 8      | DontAcceptBotTrades | Non accetta automaticamente `loot` scambi da altre istanze del bot                                                                                                                                                                              |
| 16     | MatchActively       | Partecipa attivamente alle operazioni **[STM](https://www.steamtradematcher.com)**-like trades. Visita **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** per maggiori informazioni |


Si prega di notare che questa proprietà è `flags` campo, quindi è possibile scegliere qualsiasi combinazione di valori disponibili. Scopri **[json mapping](#json-mapping)** se vuoi saperne di più. Non abilitare nessuno dei flag comporta l'opzione `Nessuno`.

Per ulteriori spiegazioni sulla logica di trading di ASF e descrizione di ogni flag disponibile, visita la sezione **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**.



---



### `Tipi Trasferibili`

Tipo `ImmutableHashSet<byte>` con valore predefinito di tipi di oggetti `1, 3, 5`. Questa proprietà definisce quali tipi di elementi Steam saranno considerati per il trasferimento tra bot, durante il trasferimento `` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. ASF garantirà che solo gli elementi provenienti da `TransferableTypes` saranno inclusi in un'offerta commerciale, quindi questa proprietà ti permette di scegliere quello che vuoi ricevere in un'offerta commerciale che viene inviata a uno dei tuoi bot.

| Valore | Nome               | Descrizione                                                                      |
| ------ | ------------------ | -------------------------------------------------------------------------------- |
| 0      | Sconosciuto        | Ogni tipo che non si adatta in nessuno dei sotto                                 |
| 1      | BoosterPack        | Pacchetto potenziatore contenente 3 carte casuali da una partita                 |
| 2      | Emoticon           | Emoticon da usare nella chat di Steam                                            |
| 3      | FoilTradingCard    | Variante della stagnola di `TradingCard`                                         |
| 4      | ProfileSfondo      | Sfondo del profilo da usare sul tuo profilo Steam                                |
| 5      | TradingCard        | Carta commerciale a vapore, utilizzata per la creazione di distintivi (non-foil) |
| 6      | Gemme A Vapore     | Gemme a vapore utilizzate per la creazione di booster, sacchi inclusi            |
| 7      | SaleItem           | Articoli speciali assegnati durante le vendite di Steam                          |
| 8      | Consumabile        | Oggetti speciali consumabili che scompaiono dopo essere stati utilizzati         |
| 9      | ProfileModifier    | Elementi speciali che possono modificare l'aspetto del profilo di Steam          |
| 10     | Adesivo            | Oggetti speciali che possono essere utilizzati nella chat di Steam               |
| 11     | ChatEffect         | Oggetti speciali che possono essere utilizzati nella chat di Steam               |
| 12     | MiniProfileSfondo  | Sfondo speciale per il profilo Steam                                             |
| 13     | AvatarProfileFrame | Cornice avatar speciale per il profilo Steam                                     |
| 14     | AnimatedAvatar     | Avatar animato speciale per il profilo Steam                                     |
| 15     | TastieraSkin       | Skin speciale della tastiera per il mazzo Steam                                  |
| 16     | StartupVideo       | Video di avvio speciale per il mazzo Steam                                       |


Si prega di notare che indipendentemente dalle impostazioni sopra riportate, ASF chiederà solo gli elementi **[della comunità di Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` di 753, `contextID` di 6), quindi tutti gli articoli di gioco, i regali e allo stesso modo, sono esclusi dall'offerta di commercio per definizione.

L'impostazione predefinita di ASF è basata sull'uso più comune del bot, con il trasferimento solo dei pacchetti di booster e delle carte di trading (comprese le foglie). La proprietà qui definita consente di modificare quel comportamento in qualsiasi modo che ti soddisfi. Tieni presente che tutti i tipi non definiti sopra mostreranno come tipo `Sconosciuto` , che è particolarmente importante quando Valve rilascia qualche nuovo elemento Steam, che sarà contrassegnato come `Sconosciuto` anche da ASF, fino a quando non viene aggiunto qui (nella versione futura). Ecco perché in generale non è consigliabile includere il tipo `Sconosciuto` nel tuo `TransferableTypes`, a meno che tu non sappia cosa stai facendo, e capisci anche che ASF invierà l'intero inventario in un'offerta commerciale se Steam Network viene rotto di nuovo e segnala tutti i tuoi articoli come `Sconosciuto`. Il mio forte suggerimento è di non includere il tipo `Sconosciuto` nel tipo `TransferableTypes`, anche se ci si aspetta di trasferire tutto.



---



### `UseLoginKeys`

`bool` tipo con valore predefinito `true`. Questa proprietà definisce se ASF deve usare il meccanismo dei tasti di accesso per questo account Steam. Il meccanismo delle chiavi di accesso funziona molto simile all'opzione "remember me" del cliente ufficiale di Steam, che rende possibile per ASF di memorizzare e utilizzare la chiave di accesso temporanea una volta per il prossimo tentativo di accesso, di fatto saltando la necessità di fornire password, Steam Guard o codice 2FA finché la nostra chiave di accesso è valida. La chiave di accesso viene memorizzata nel file `BotName.db` e aggiornata automaticamente. Questo è il motivo per cui non è necessario fornire password/SteamGuard/2FA codice dopo aver effettuato il login con ASF una sola volta.

Le chiavi di accesso sono usate di default per la tua convenienza, quindi non è necessario inserire `SteamPassword`, SteamGuard o codice 2FA (quando non si utilizza **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**) su ogni accesso. È anche un'alternativa superiore poiché la chiave di accesso può essere utilizzata solo per una sola volta e non rivela in alcun modo la password originale. Esattamente lo stesso metodo viene utilizzato dal client Steam originale, che salva il nome dell'account e la chiave di accesso per il prossimo tentativo di accesso, effettivamente identico all'utilizzo di `SteamLogin` con `UseLoginKeys` e vuoto `SteamPassword` in ASF.

Tuttavia, alcuni potrebbero essere preoccupati anche per questo piccolo dettaglio, quindi questa opzione è disponibile qui per te se vuoi assicurarti che ASF non memorizzi alcun tipo di token che permetterebbe di riprendere la sessione precedente dopo essere stato chiuso, che comporterà l'autenticazione completa obbligatoria per ogni tentativo di login. Disabilitare questa opzione funzionerà esattamente come non controllare "ricordami" nel client ufficiale di Steam. A meno che tu non sappia cosa stai facendo, dovresti tenerlo con il valore predefinito di `true`.



---



### `UserInterfaceMode`

Tipo `byte` con valore predefinito di `0`. Questa proprietà specifica la modalità interfaccia utente con cui il bot verrà annunciato dopo il login alla rete Steam. Potrebbe influenzare il modo in cui l'account è visibile, ad esempio sulla chat di Steam, se la tua presenza lo permette attraverso `OnlineStatus`. Attualmente è possibile scegliere una delle seguenti modalità:

| Valore | Nome       | Descrizione                          |
| ------ | ---------- | ------------------------------------ |
| `0`    | VGUI       | Modalità client di Steam predefinita |
| `1`    | Tenfoot    | Modalità immagine grande             |
| `2`    | Cellulare  | App mobile di Steam                  |
| `3`    | Web        | Sessione browser web                 |
| `5`    | MobileChat | App chat mobile di Steam             |


Il sottostante tipo `EUIMode` che questa proprietà si basa su include tuttavia più valori disponibili, al meglio delle nostre conoscenze non hanno assolutamente alcun effetto a partire da oggi, quindi sono stati tagliati per la visibilità. Inoltre, potresti essere interessato a controllare `GamingDeviceType`, dato che alcune funzioni aggiuntive sono abilitate lì.

Se non sei sicuro di come impostare questa proprietà, lasciala con valore predefinito di `0`.



---



### `WebProxy`

Tipo `stringa` con valore predefinito `null`. Questa proprietà definisce un indirizzo proxy web che verrà utilizzato per la comunicazione interna relativa a http, in particolare per servizi come `api. teampowered.com`, `steamcommunity.com` e `store.steampowered.com`. Se non impostato, ASF userà l'impostazione globale `WebProxy` specificata sopra. Proxying richieste di ASF potrebbe essere eccezionalmente utile per aggirare vari tipi di firewall, in particolare il grande firewall in Cina.

Questa proprietà è definita come una stringa uri:



> Una stringa URI è composta da uno schema (supportato: http/https/socks4/socks4a/socks5), un host e una porta opzionale. Un esempio di una stringa uri completa è `"http://contoso.com:8080"`.

Se il tuo proxy richiede l'autenticazione dell'utente, dovrai anche impostare `WebProxyUsername` e/o `WebProxyPassword`. Se non c'è tale necessità, la creazione di questa proprietà da sola è sufficiente.

Se hai bisogno di proxy anche di comunicazione di rete di Steam (CMs) interna, allora dovresti assicurarti di configurare la proprietà del bot **[`SteamProtocols`](#steamprotocols)** ad un valore che consenta solo il trasporto Websocket, i. . a value of `4`, as only websockets are supported for proxying.

A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.



---



### `WebProxyPassword`

Tipo `stringa` con valore predefinito `null`. Questa proprietà definisce il campo password utilizzato in base, digest, NTLM, e autenticazione Kerberos supportata da una macchina `WebProxy` di destinazione che fornisce funzionalità proxy. Se il tuo proxy non richiede credenziali utente, non c'è bisogno che tu inserisca qualcosa qui. L'utilizzo di questa opzione ha senso solo se viene utilizzato `WebProxy` anche perché altrimenti non ha effetto.

A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.



---



### `WebProxyUsername`

Tipo `stringa` con valore predefinito `null`. Questa proprietà definisce il campo nome utente usato in base, digest, NTLM, e autenticazione Kerberos supportata da una macchina `WebProxy` di destinazione che fornisce funzionalità proxy. Se il tuo proxy non richiede credenziali utente, non c'è bisogno che tu inserisca qualcosa qui. L'utilizzo di questa opzione ha senso solo se viene utilizzato `WebProxy` anche perché altrimenti non ha effetto.

A meno che tu non abbia un motivo per modificare questa proprietà, dovresti mantenerla come predefinita.



---



## Struttura dei file

ASF usa una struttura dei file molto semplice.



```text
├── 📁 config
│     ├── ASF.json
│     ├── ASF.db
│     ├── Bot1.json
│     ├── Bot1.db
│     ├── Bot2.json
│     ├── Bot2.db
│     └── ...
├<unk> <unk> <unk> ArchiSteamFarm.dll
├<unk> <unk> <unk> log.txt
<unk> <unk> <unk> ...
```


Per spostare ASF in una nuova posizione, ad esempio un altro PC, basta spostare/copiare la directory `config` da solo, e questo è il modo consigliato di fare qualsiasi forma di "backup di ASF", dal momento che è sempre possibile scaricare la parte rimanente (programma) dal GitHub, senza rischiare di danneggiare i file interni di ASF, e. . attraverso un backup difettoso.

Il file `log.txt` contiene il log generato dalla tua ultima esecuzione di ASF. Questo file non contiene informazioni sensibili ed è estremamente utile quando si tratta di problemi, si blocca o semplicemente come informazioni per voi quello che è successo nell'ultima corsa di ASF. Molto spesso chiederemo di questo file se si verificano problemi o bug. ASF gestisce automaticamente questo file per te, ma puoi modificare ulteriormente il modulo ASF **[di registrazione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging)** se sei utente avanzato.

La directory `config` è il luogo che contiene la configurazione per ASF, inclusi tutti i suoi bot.

`ASF.json` è un file di configurazione globale di ASF. Questa configurazione viene utilizzata per specificare come ASF si comporta come un processo, che interessa tutti i bot e il programma stesso. È possibile trovare proprietà globali lì, come proprietario di processo ASF, aggiornamenti automatici o debug.

`BotName.json` è una configurazione di una data istanza del bot. Questa configurazione è usata per specificare come si comporta l'istanza del bot, quindi queste impostazioni sono specifiche per quel bot solo e non sono condivise tra gli altri. Questo permette di configurare i bot con diverse impostazioni e non necessariamente tutti lavorano esattamente nello stesso modo. Ogni bot viene nominato utilizzando un identificatore univoco, scelto da te al posto di `BotName`.

Oltre ai file di configurazione, ASF utilizza anche la directory `config` per memorizzare i database.

`ASF.db` è un file di database ASF globale. Agisce come un archivio persistente globale e viene utilizzato per salvare varie informazioni relative al processo ASF, come gli IP dei server Steam locali. **Non dovresti modificare questo file**.

`BotName.db` è un database di una data istanza del bot. Questo file viene utilizzato per memorizzare dati cruciali su una data istanza del bot nell'archiviazione persistente, come le chiavi di accesso o ASF 2FA. **Non dovresti modificare questo file**.

`BotName.keys` è un file speciale che può essere utilizzato per importare chiavi in **[giochi in background redentore](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. Non è obbligatorio e non generato, ma riconosciuto da ASF. Questo file viene eliminato automaticamente dopo che le chiavi sono state importate correttamente.

`BotName.maFile` è un file speciale che può essere utilizzato per importare **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**. Non è obbligatorio e non generato, ma riconosciuto da ASF se il tuo `BotName` non utilizza ancora ASF 2FA. Questo file viene eliminato automaticamente dopo che ASF 2FA è stato importato correttamente.



---



## Mappatura JSON

Ogni proprietà di configurazione ha il suo tipo. Il tipo di proprietà definisce valori che sono validi per esso. È possibile utilizzare solo valori validi per il tipo dato - se si utilizza un valore non valido, quindi ASF non sarà in grado di analizzare la configurazione.

**Si consiglia vivamente di utilizzare ConfigGenerator per generare configurazioni** - gestisce la maggior parte delle cose di basso livello (come la convalida dei tipi), quindi è necessario solo inserire valori corretti, e inoltre non è necessario capire i tipi di variabili specificati di seguito. Questa sezione è principalmente per le persone che generano/modifica configurazioni manualmente, in modo da sapere quali valori possono usare.

I tipi usati da ASF sono tipi nativi di C# che sono specificati di seguito:



---

`bool` - Tipo booleano che accetta solo valori `true` e `false`.

Esempio: `"Abilitato": true`



---

`byte` - Tipo di byte non firmato, accettando solo interi da `0` a `255` (incluso).

Esempio: `"ConnectionTimeout": 90`



---

`ushort` - Tipo breve senza firma, accettando solo interi da `0` a `65535` (incluso).

Esempio: `"WebLimiterDelay": 300`



---

`uint` - Tipo intero non firmato, accettando solo interi da `0` a `4294967295` (incluso).



---

`ulong` - Tipo intero lungo senza firma, accettando solo interi da `0` ad `18446744073709551615` (incluso).

Esempio: `"SteamMasterClanID": 103582791440160998`



---

`stringa` - Tipo di stringa, accettando qualsiasi sequenza di caratteri, inclusa la sequenza vuota `""` e `null`. Sequenza vuota e valore `null` sono trattati allo stesso modo da ASF, quindi tocca alla tua preferenza quella che vuoi usare (attacchiamo con `null`).

Esempi: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MyAccountName"`



---

`Guid?` - Tipo UUID nullabile, in JSON codificato come stringa. UUID è composto da 32 caratteri esadecimali, nell'intervallo da `0` a `9` e `a` a `f`. ASF accetta varietà di formati validi - minuscolo, maiuscolo, con e senza trattini. Oltre a UUID valido, poiché questa proprietà è nulla, un valore speciale di `null` è accettato per indicare la mancanza di UUID da fornire.

Esempi: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`



---

`ImmutableList<valueType>` - Raccolta immutabile (lista) di valori in un dato `valueType`. In JSON, è definito come array di elementi in un dato valore `Type`. ASF utilizza `List` per indicare che una data proprietà supporta più valori e che il loro ordine potrebbe essere rilevante.

Esempio per `ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`



---

`ImmutableHashSet<valueType>` - Immutable collection (set) of unique values in given `valueType`. In JSON, è definito come array di elementi in un dato valore `Type`. ASF utilizza `HashSet` per indicare che la proprietà data ha senso solo per valori univoci e che il loro ordine non importa, quindi ignorerà intenzionalmente qualsiasi potenziale duplicato durante l'analisi (se vi è capitato di fornirli comunque).

Esempio per `ImmutableHashSet<uint>`: `"Blacklist": [267420, 303700, 335590]`



---

`ImmutableDictionary<keyType, valueType>` - Dizionario immutabile (mappa) che mappa una chiave univoca specificata nella sua `keyType`, al valore specificato nel suo `valueType`. In JSON, è definito come un oggetto con coppie chiave-valore. Tieni presente che `keyType` è sempre citato in questo caso, anche se è tipo di valore come `ulong`. C'è anche un severo requisito che la chiave sia unica sulla mappa, questa volta applicata anche da JSON.

Esempio per `ImmutableDictionary<ulong, byte>`: `"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`



---

`flags` - L'attributo Flags combina diverse proprietà in un unico valore finale applicando operazioni bitwise. Questo consente di scegliere qualsiasi possibile combinazione di diversi valori consentiti allo stesso tempo. Il valore finale è costruito come una somma di valori di tutte le opzioni abilitate.

Per esempio, data la seguente definizione:

| Valore | Nome         |
| ------ | ------------ |
| 0      | Nessuna data |
| 1      | A            |
| 2      | B            |
| 4      | C            |


Ci sono esattamente 3 bandiere significative disponibili per attivare/disattivare (`A`, `B`, `C`), e quindi `8` possibili combinazioni valide complessivamente:

| Valore finale | Opzioni abilitate |
| ------------- | ----------------- |
| 0             | `Nessuna data`    |
| 1             | `A`               |
| 2             | `B`               |
| 3             | `A` + `B`         |
| 4             | `C`               |
| 5             | `A` + `C`         |
| 6             | `B` + `C`         |
| 7             | `A` + `B` + `C`   |


Per definizione, al fine di rendere possibile quanto sopra, ogni bandiera autonoma deve quindi essere la potenza di due. Questo è il motivo per cui un flag aggiuntivo nell'esempio sopra, `D`, avrebbe bisogno di portare il valore `8` o superiore.

Di solito, gli strumenti grafici faranno il calcolo per voi. Se stai modificando le configurazioni manualmente, è sempre possibile utilizzare la calcolatrice e semplicemente aggiungere insieme i valori sottostanti di tutti i flag che si desidera abilitare - come nell'esempio sopra.

Esempio: `"SteamProtocols": 7` (che abilita i flag con valore `1`, `2` e `4`, come spiegato sopra)



---



## Mappatura di compatibilità

A causa delle limitazioni JavaScript di non essere in grado di serializzare correttamente i campi `ulong` semplici in JSON quando si utilizza ConfigGenerator web-based, I campi `ulong` saranno resi come stringhe con prefisso `s_` nella configurazione risultante. Questo include per esempio `"SteamOwnerID": 76561198006963719` che sarà scritto dal nostro ConfigGenerator come `"s_SteamOwnerID": "76561198006963719"`. ASF include una logica adeguata per gestire questa stringa mapping automaticamente, quindi le voci `s_` nelle tue configurazioni sono effettivamente valide e correttamente generate. Se stai generando configurazioni ti raccomandiamo di attenersi ai campi `ulong` originali se possibile, ma se non sei in grado di farlo, puoi anche seguire questo schema e codificarli come stringhe con prefisso `s_` aggiunto ai loro nomi. Speriamo di risolvere questa limitazione JavaScript alla fine.



---



## Compatibilità delle configurazioni

È la massima priorità per ASF per rimanere compatibile con le vecchie configurazioni. Come dovresti già sapere, le proprietà di configurazione mancanti sono trattate come sarebbero state definite con i loro valori **predefiniti**. Pertanto, se la nuova proprietà di configurazione viene introdotta nella nuova versione di ASF, tutte le configurazioni rimarranno **compatibili** con la nuova versione, e ASF tratterà quella nuova proprietà di configurazione come è stata definita con il suo valore **predefinito**. Puoi sempre aggiungere, rimuovere o modificare le proprietà di configurazione in base alle tue esigenze.

Si consiglia di limitare le proprietà di configurazione definite solo a quelle che si desidera modificare, poiché in questo modo erediti automaticamente i valori predefiniti per tutti gli altri, non solo mantenere la tua configurazione pulita, ma anche aumentare la compatibilità nel caso in cui decidiamo di cambiare un valore predefinito per le proprietà che non si desidera impostare esplicitamente (e. . `WebLimiterDelay`).

A causa di quanto sopra, ASF migra automaticamente/ottimizza le configurazioni riformattandole e rimuovendo i campi che mantengono il valore predefinito. Puoi disabilitare questo comportamento con `--no-config-migrate` **[argomento a riga di comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** se hai una ragione specifica, ad esempio stai fornendo file di configurazione di sola lettura e non vuoi che ASF li modifichi.



---



## Ricarica automatica

ASF è consapevole che le configurazioni vengono modificate "in volo" - grazie a questo, ASF automaticamente:

- Crea (e avvia, se necessario) una nuova istanza del bot, quando ne crei la configurazione
- Interrompere (se necessario) e rimuovere l'istanza del vecchio bot, quando si elimina la configurazione
- Interrompi (e avvia, se necessario) qualsiasi istanza del bot, quando ne modifichi la configurazione
- Riavvia (se necessario) il bot con un nuovo nome, quando rinomini la sua configurazione

Tutto quanto sopra è trasparente e verrà fatto automaticamente senza la necessità di riavviare il programma, o uccidere altre istanze (non influenzate).

In aggiunta a ciò, ASF si riavvierà anche (se `AutoRestart` lo permette) se modifichi il core ASF `ASF.json` config. Allo stesso modo, il programma uscirà se si elimina o rinomina.

Puoi disabilitare questo comportamento con l'argomento `--no-config-watch` **[da riga di comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** se hai una ragione specifica, ad esempio non si desidera da ASF di reagire alle modifiche dei file nella cartella `configurazione`.