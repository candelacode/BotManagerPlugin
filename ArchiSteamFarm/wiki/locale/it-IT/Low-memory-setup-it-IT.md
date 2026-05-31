# Setup a bassa memoria

Questo è esattamente l'opposto della configurazione **[ad alte prestazioni](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup)** e in genere si desidera seguire questi suggerimenti se si desidera diminuire l'utilizzo di memoria di ASF, per il costo della riduzione delle prestazioni globali.

---

ASF è estremamente leggero sulle risorse per definizione, a seconda del tuo utilizzo anche 128 MB VPS con Linux è in grado di eseguirlo, anche se andare che basso non è raccomandato e può portare a vari problemi. Pur essendo leggero, ASF non ha paura di chiedere OS per più memoria, se tale memoria è necessaria per ASF per funzionare con velocità ottimale.

ASF come un'applicazione cerca di essere ottimizzata ed efficiente il più possibile, il che tiene conto anche delle risorse utilizzate durante l'esecuzione. Quando si tratta di memoria, ASF preferisce prestazioni rispetto al consumo di memoria, che può portare a "punti" di memoria temporanea, che si possono notare, ad es. con account con 3+ pagine distintivo, come ASF recupererà e analizzerà la prima pagina, leggere da esso il numero totale di pagine, quindi avviare attività di recupero per ogni pagina extra, che si traduce in recupero simultaneo e l'analisi delle pagine rimanenti. Quel "extra" utilizzo della memoria (rispetto al minimo nudo per il funzionamento) può velocizzare notevolmente l'esecuzione e le prestazioni complessive, per il costo di un maggiore utilizzo della memoria che è necessario per fare tutte queste cose in parallelo. La cosa simile sta accadendo a tutte le altre attività generali di ASF che possono essere eseguite in parallelo, ad es. con l'analisi delle offerte di trading attive, ASF può analizzarle tutti contemporaneamente, in quanto sono tutti indipendenti l'uno dall'altro. In cima a quello, ASF (C# runtime) **non** restituirà la memoria inutilizzata al sistema operativo immediatamente dopo, che si può notare rapidamente in forma di processo di ASF solo prendendo sempre più memoria, ma (quasi) non restituire mai quella memoria al sistema operativo. Alcune persone potrebbero già trovare discutibile, forse anche sospettare una perdita di memoria, ma non preoccupatevi, tutto questo è da aspettarsi.

ASF è estremamente ben ottimizzato e fa uso delle risorse disponibili il più possibile. Un elevato utilizzo di memoria di ASF non significa che ASF attivamente **utilizzi** quella memoria e **ne ha bisogno**. Molto spesso ASF manterrà la memoria assegnata come "stanza" per azioni future, perché possiamo migliorare drasticamente le prestazioni se non abbiamo bisogno di chiedere il sistema operativo per ogni pezzo di memoria che stiamo per usare. Il runtime dovrebbe rilasciare automaticamente la memoria ASF non utilizzata di nuovo al sistema operativo quando il sistema operativo **veramente** ne ha bisogno. **[La memoria inutilizzata è sprecata](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. Si verificano problemi quando la memoria di cui hai bisogno **** è superiore alla memoria disponibile per te, non quando ASF mantiene qualche extra assegnato con lo scopo di velocizzare le funzioni che eseguiranno in un momento. Si verificano problemi quando il kernel Linux sta uccidendo il processo di ASF a causa di OOM (memoria esaurita), non quando vedi il processo ASF come consumatore di memoria superiore in `htop`.

Il processo **[Garbage collection](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** utilizzato in ASF è un meccanismo molto complesso, abbastanza intelligente da prendere in considerazione non solo ASF stesso, ma anche il vostro sistema operativo e altri processi. Quando si dispone di un sacco di memoria gratuita, ASF chiederà tutto ciò che è necessario per migliorare le prestazioni. Questo può essere anche fino a 1 GB (con server GC). Quando la memoria del sistema operativo è vicina ad essere piena, ASF rilascerà automaticamente alcuni di essi al sistema operativo per aiutare le cose a stabilizzarsi, che può portare a un utilizzo complessivo di memoria ASF fino a 50 MB. La differenza tra 50 MB e 1 GB è enorme, ma così è la differenza tra il piccolo VPS 512 MB e l'enorme server dedicato con 32 GB. Se ASF è in grado di garantire che questa memoria sarà utile, e allo stesso tempo niente altro richiede in questo momento, preferirà mantenerlo e ottimizzarsi automaticamente in base alle routine che sono state eseguite in passato. Il GC utilizzato in ASF è auto-tuning e otterrà risultati migliori più a lungo il processo è in esecuzione.

Questo è anche il motivo per cui la memoria di processo ASF varia da configurazione a configurazione, as ASF will do its best to use available resources in **as efficient way as possible**, e non in modo fisso come è stato fatto durante i tempi di Windows XP. L'utilizzo effettivo (reale) della memoria che ASF sta utilizzando può essere verificato con il comando `statistiche` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, e di solito è di circa 4 MB per pochi bot, fino a 30 MB se usi cose come **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** e altre funzionalità avanzate. Tieni presente che la memoria restituita dal comando `statistiche` include anche la memoria libera che non è stata ancora recuperata dal raccoglitore di rifiuti. Tutto il resto è condiviso memoria di esecuzione (circa 40-50 MB) e spazio per l'esecuzione (varia). Questo è anche il motivo per cui lo stesso ASF può utilizzare meno di 50 MB in ambiente VPS a bassa memoria, durante l'utilizzo fino a 1 GB sul desktop. ASF si sta attivamente adattando al vostro ambiente e cercherà di trovare un equilibrio ottimale per non mettere il vostro sistema operativo sotto pressione, né limitare le proprie prestazioni quando si dispone di un sacco di memoria inutilizzata che potrebbe essere messo in uso.

---

Naturalmente, ci sono un sacco di modi come si può aiutare a puntare ASF nella giusta direzione in termini di memoria che si prevede di utilizzare. In generale, se non avete bisogno di farlo, è meglio lasciare che il collezionista rifiuti lavori in pace e fare tutto ciò che ritiene sia meglio. Ma questo non è sempre possibile, ad esempio se il tuo server Linux ospita anche diversi siti web, database MySQL e operatori PHP, allora non si può davvero permettersi ASF restringendosi quando si corre vicino a OOM, come di solito è troppo tardi e il degrado delle prestazioni arriva prima. Questo è di solito quando si potrebbe essere interessati ad ulteriore sintonizzazione, e quindi leggere questa pagina.

Di seguito i suggerimenti sono suddivisi in poche categorie, con varie difficoltà.

---

## Installazione ASF (facile)

I trucchi di seguito **non influiscono negativamente sulle prestazioni** e possono essere applicati in modo sicuro a tutte le configurazioni.

- Eseguire **[versione generica](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** di ASF se possibile. La versione generica di ASF utilizza meno memoria poiché non include runtime all'interno, non viene come singolo file, non ha bisogno di scompattarsi in esecuzione, ed è quindi più piccolo e ha meno impronta di memoria. I pacchetti specifici per il sistema operativo sono pratici e convenienti, ma sono anche in bundle con tutto il necessario per lanciare ASF, che è qualcosa che si può prendere cura di te stesso e utilizzare generico variante ASF invece.
- Non eseguire mai più di un'istanza di ASF. ASF è destinato a gestire un numero illimitato di bot tutti in una sola volta, e a meno che tu non leghi ogni istanza di ASF a diverse interfacce / indirizzo IP, si dovrebbe avere esattamente **un processo** di ASF, con più bot (se necessario).
- Fai uso di `ShutdownOnFarmingFinished` nel bot `FarmingPreferences`. Il bot attivo richiede più risorse di quelle disattivate. Non è un risparmio significativo, poiché lo stato del bot deve ancora essere mantenuto, ma stai risparmiando una certa quantità di risorse, in particolare tutte le risorse relative alla rete, come i socket TCP. Se necessario, puoi sempre allevare altri bot.
- Tieni basso il tuo numero di bot. L'istanza del bot `Abilitata da` richiede meno risorse, poiché ASF non disturba l'avvio. Tenete anche a mente che ASF deve creare un bot per ciascuna delle vostre configurazioni, quindi se non hai bisogno di `avviare il bot` dato e vuoi salvare qualche memoria extra, puoi rinominare temporaneamente il bot `. son` ad esempio `Bot.json.bak` per evitare di creare lo stato per l'istanza del bot disabilitato in ASF. In questo modo non sarai in grado di `avviare` senza rinominarlo indietro, ma anche ASF non si preoccupa di mantenere lo stato di questo bot in memoria, lasciando spazio ad altre cose (risparmio molto piccolo, in 99. % casi che non dovresti preoccuparti con esso, basta tenere i tuoi bot con `Abilitato` di `false`).
- Ottimizza le tue configurazioni. Soprattutto la configurazione globale di ASF ha molte variabili da regolare, ad esempio aumentando `LoginLimiterDelay` potrai far apparire i tuoi bot più lentamente, che permetterà all'istanza già avviata di recuperare i badge nel frattempo, al contrario di allevare i tuoi bot più velocemente, che prenderanno più risorse in quanto più bot faranno il lavoro importante (come il badge di analizzazione) allo stesso tempo. Meno lavoro che deve essere fatto allo stesso tempo - meno memoria utilizzata.

Quelle sono alcune cose che si può tenere a mente quando si tratta di utilizzo della memoria. Tuttavia, quelle cose non hanno alcuna questione "cruciale" sull'uso della memoria, perché l'utilizzo della memoria proviene principalmente da cose che ASF ha a che fare con e non da strutture interne utilizzate per l'agricoltura di carte.

Le funzioni più pesantissime sono le seguenti:
- Analisi della pagina distintivo
- Analisi inventario

Il che significa che la memoria punterà di più quando ASF si occupa di leggere pagine distintivo, e quando si tratta del suo inventario (e. . invio di commercio o di lavoro con STM). Questo perché ASF ha a che fare con davvero enorme quantità di dati - l'utilizzo di memoria del browser preferito lanciando queste due pagine non sarà inferiore a quello. Siamo spiacenti, questo è il modo in cui funziona - diminuisce il numero delle tue pagine distintivo e mantiene basso il numero degli oggetti dell'inventario, che può essere di sicuro aiuto.

---

## Runtime tuning (avanzato)

Di seguito i trucchi **comportano il degrado delle prestazioni** e devono essere utilizzati con cautela.

Il modo raccomandato per applicare queste impostazioni è attraverso le proprietà ambientali `DOTNET_`. Naturalmente, è possibile utilizzare anche altri metodi, ad esempio `runtimeconfig. son`, ma alcune impostazioni sono impossibili da impostare in questo modo, e in cima a questo ASF sostituirà il tuo custom `runtimeconfig. son` con la propria sul prossimo aggiornamento, quindi consigliamo le proprietà ambientali che puoi impostare facilmente prima di avviare il processo.

.NET runtime consente di **[tweak spazzbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** in molti modi, perfezionamento efficace del processo GC in base alle vostre esigenze. Abbiamo documentato sotto proprietà che sono particolarmente importanti a nostro parere.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Specifica l'uso consentito di heap GC come percentuale della memoria fisica totale.

Il limite di memoria "duro" per il processo ASF, questa impostazione sintonizza GC per utilizzare solo un sottoinsieme di memoria totale e non tutti. Può diventare particolarmente utile in varie situazioni simili a server in cui è possibile dedicare una percentuale fissa della memoria del server per ASF, ma mai più di quello. Essere avvisato che limitare la memoria per ASF da utilizzare non farà magicamente tutte quelle allocazioni di memoria necessarie andare via, quindi la fissazione di questo valore troppo basso potrebbe portare a esaurire gli scenari di memoria, in cui il processo di ASF sarà costretto a terminare.

D'altra parte, impostare questo valore abbastanza alto è un modo perfetto per garantire che ASF non userà mai più memoria di quanto si possa realisticamente permettere, dando alla vostra macchina un po 'di stanza di respirazione anche sotto carico pesante, pur consentendo al programma di fare il suo lavoro nel modo più efficiente possibile.

### [`GCConserveMemory`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Configura il collezionista della spazzatura per conservare la memoria a scapito delle collezioni di spazzatura più frequenti e possibilmente tempi di pausa più lunghi.

Si può usare un valore compreso tra 0 e 9. Più grande è il valore, più GC ottimizzerà la memoria sulle prestazioni.

### [`GCHighMemPercentuale`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Specifica la quantità di memoria utilizzata dopo la quale GC diventa più aggressivo.

Questa impostazione configura la soglia di memoria di tutto il sistema operativo, che una volta passato, provoca GC a diventare più aggressivo e tentare di aiutare il sistema operativo a ridurre il carico di memoria eseguendo un processo GC più intensivo e nel risultato rilasciando più memoria libera di nuovo al sistema operativo. È una buona idea impostare questa proprietà alla quantità massima di memoria (come percentuale) che si considera "critico" per le prestazioni di tutto il sistema operativo. Il valore predefinito è 90%, e di solito si desidera mantenerlo nell'intervallo 80-97%, poiché un valore troppo basso causerà un'aggressione inutile da parte del GC e il degrado delle prestazioni senza alcun motivo, mentre un valore troppo alto metterà un carico inutile sul tuo sistema operativo, considerando che ASF potrebbe rilasciare parte della sua memoria per aiutare.

### **[`GCLatencyLevel`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Specifica il livello di latenza GC per cui si desidera ottimizzare.

Questa è proprietà non documentata che si è rivelato funzionare eccezionalmente bene per ASF, limitando le dimensioni delle generazioni di GC e facendo in modo che GC li purifichi più frequentemente e più aggressivamente. Il livello di latenza predefinito (bilanciato) è `1`, ma è possibile utilizzare `0`, che si sintonizzerà per l'utilizzo della memoria.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> Quando impostato, tagliamo lo spazio impegnato in modo più aggressivo per il segmento effimero. Questo viene utilizzato per eseguire molte istanze di processi server in cui vogliono mantenere la minima memoria impegnata possibile.

Questo offre pochi miglioramenti, ma può rendere GC ancora più aggressivo quando il sistema sarà basso sulla memoria, soprattutto per ASF che fa uso di attività filettatura pesantemente.

---

È possibile abilitare le proprietà selezionate impostando le variabili di ambiente appropriate. Ad esempio, su Linux (shell):

```shell
# Non dimenticare di sintonizzare quelli se hai intenzione di utilizzarli
export DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
export DOTNET_GCHighMemPercent=0x50 # 80% as hex

export DOTNET_GCConserveMemory=9
export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

. ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

O su Windows (powershell):

```powershell
# Non dimenticate di sintonizzare quelli se avete intenzione di utilizzarli
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% come esadecimale
$Env:DOTNET_GCHighMemPercent=0x50 # 80% come esadecimale

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

. ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

Soprattutto `GCLatencyLevel` sarà molto utile in quanto abbiamo verificato che il runtime effettivamente ottimizza il codice per la memoria e quindi diminuisce in modo significativo l'utilizzo della memoria media, anche con server GC. È uno dei migliori trucchi che puoi applicare se vuoi ridurre significativamente l'utilizzo della memoria ASF senza degradare troppo le prestazioni con `OptimizationMode`.

---

## Regolazione ASF (intermedia)

Di seguito i trucchi **comportano una grave degradazione delle prestazioni** e devono essere utilizzati con cautela.

- Come ultima risorsa, è possibile sintonizzare ASF per `MinMemoryUsage` tramite `OptimizationMode` **[global config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**. Legga attentamente il suo scopo, in quanto questo è un grave degrado delle prestazioni per quasi nessun beneficio di memoria. Questa è tipicamente **l'ultima cosa che vuoi fare**, molto tempo dopo aver attraversato **[runtime tuning](#runtime-tuning-advanced)** per assicurarsi di essere costretti a farlo. A meno che non sia assolutamente critico per la tua configurazione, scoraggiamo l'utilizzo di `MinMemoryUsage`, anche in ambienti con vincoli di memoria.

---

## Ottimizzazione consigliata

- Inizia da semplici trucchi di configurazione di ASF, usa la variante **[generica di ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** e controlla se forse stai solo usando il tuo ASF in modo sbagliato, ad esempio avviando il processo più volte per tutti i tuoi bot, o mantenerli tutti attivi se avete bisogno solo di uno o due per autostart.
- Se non è ancora sufficiente, abilita tutte le proprietà di configurazione elencate sopra impostando le variabili di ambiente appropriate `DOTNET_`. Soprattutto `GCLatencyLevel` offre significativi miglioramenti di runtime per un costo limitato sulle prestazioni.
- Se anche questo non ha aiutato, come ultima risorsa abilita `MinMemoryUsage` `OptimizationMode`. Questo costringe ASF a eseguire quasi tutto in materia sincrona, farlo funzionare molto più lentamente, ma anche non fare affidamento sul pool di thread per bilanciare le cose quando si tratta di esecuzione parallela.

È fisicamente impossibile ridurre ulteriormente la memoria, il tuo ASF è già fortemente degradato in termini di prestazioni e hai esaurito tutte le tue possibilità, sia in termini di codice che in termini di runtime-wise. Considerare l'aggiunta di qualche memoria in più per ASF da usare, anche 128 MB farebbe una grande differenza.