# Configurazione ad alte prestazioni

Questo è esattamente l'opposto di **[installazione a bassa memoria](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** e in genere si desidera seguire questi suggerimenti se si desidera aumentare ulteriormente le prestazioni di ASF (in termini di velocità della CPU), per il costo potenziale di un maggiore utilizzo della memoria.

---

ASF cerca già di preferire le prestazioni quando si tratta di sintonizzazione generale equilibrata, quindi non c'è molto che si può fare per aumentare ulteriormente le sue prestazioni, anche se non sei completamente fuori dalle opzioni. Tuttavia, tieni presente che queste opzioni non sono abilitate per impostazione predefinita, che significa che non sono abbastanza buoni da considerarli equilibrati per la maggior parte degli usi, perciò deve decidere se l'aumento di memoria portato da loro è accettabile per Lei.

---

## Runtime tuning (avanzato)

I trucchi di seguito **comportano un grave aumento della memoria** e dovrebbero quindi essere utilizzati con cautela.

Il modo raccomandato per applicare queste impostazioni è attraverso le proprietà ambientali `DOTNET_`. Naturalmente, è possibile utilizzare anche altri metodi, ad esempio `runtimeconfig. son`, ma alcune impostazioni sono impossibili da impostare in questo modo, e in cima a questo ASF sostituirà il tuo custom `runtimeconfig. son` con la propria sul prossimo aggiornamento, quindi consigliamo le proprietà ambientali che puoi impostare facilmente prima di avviare il processo.

.NET runtime consente di **[tweak spazzbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** in molti modi, perfezionamento efficace del processo GC in base alle vostre esigenze. Abbiamo documentato sotto proprietà che sono particolarmente importanti a nostro parere.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Configura se l'applicazione utilizza workstation spazzatura collezione o server spazzatura raccolta.

È possibile leggere l'esatto specifico del server GC a **[fondamentali della raccolta spazzatura](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF sta utilizzando la raccolta di rifiuti della workstation per impostazione predefinita. Questo è dovuto principalmente ad un buon equilibrio tra l'utilizzo della memoria e le prestazioni, che è più che sufficiente per pochi bot, come di solito un singolo thread di sfondo simultaneo GC è abbastanza veloce per gestire l'intera memoria allocata da ASF.

Tuttavia, oggi abbiamo un sacco di core della CPU di cui ASF può beneficiare molto, avendo un thread GC dedicato per ogni CPU vCore che è disponibile. Questo può migliorare notevolmente le prestazioni durante le attività ASF pesanti, come le pagine distintivo di analisi o l'inventario, poiché ogni CPU vCore può aiutare, al contrario di appena 2 (principale e GC). Server GC è consigliato per macchine con 3 CPU vcore e più, workstation GC è automaticamente forzato se la macchina ha solo 1 CPU vCore, e se avete esattamente 2 allora si può prendere in considerazione di provare entrambi (i risultati possono variare).

Server GC stesso non si traduce in un enorme aumento di memoria semplicemente essendo attivo, ma ha dimensioni di generazione molto più grandi, e quindi è molto più pigro quando si tratta di ridare memoria al sistema operativo. Potresti trovarti in un punto dolce in cui il server GC aumenta significativamente le prestazioni e vorresti continuare a usarle, ma allo stesso tempo non si può permettersi quel enorme aumento di memoria che viene fuori di usarlo. Fortunatamente per te, c'è un "migliore di entrambi i mondi" ambientazione, utilizzando il server GC con la proprietà di configurazione **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** impostata su `0`, che permetterà ancora server GC, ma limitare le dimensioni della generazione e concentrarsi di più sulla memoria. In alternativa, potresti anche sperimentare un'altra proprietà, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**, o anche entrambi allo stesso tempo.

Tuttavia, se la memoria non è un problema per voi (come GC tiene ancora in considerazione la memoria disponibile e tweaks stesso), è un'idea molto migliore per non cambiare quelle proprietà a tutti, raggiungendo prestazioni superiori nel risultato.

---

È possibile abilitare le proprietà selezionate impostando le variabili di ambiente appropriate. Ad esempio, su Linux (shell):

```shell
export DOTNET_gcServer=1

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

O su Windows (powershell):

```powershell
$Env:DOTNET_gcServer=1

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

---

## Ottimizzazione consigliata

- Assicurati di utilizzare il valore predefinito di `OptimizationMode` che è `MaxPerformance`. Questa è di gran lunga l'impostazione più importante, poiché l'utilizzo del valore `MinMemoryUsage` ha effetti drammatici sulle prestazioni.
- Abilita server GC. Server GC può essere immediatamente visto come attivo da un aumento significativo della memoria rispetto alla workstation GC. Questo genererà un filo GC per ogni filettatura CPU che la tua macchina ha per eseguire operazioni GC in parallelo con la massima velocità.
- Se non puoi permetterti di aumentare la memoria a causa del server GC, considera tweaking **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** e/o **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** per ottenere "il meglio di entrambi i mondi". Tuttavia, se la vostra memoria può permetterselo, allora è meglio mantenerlo come predefinito - il server GC si modifica già durante il runtime ed è abbastanza intelligente da usare meno memoria quando il vostro sistema operativo ne avrà veramente bisogno.

L'applicazione delle raccomandazioni di cui sopra consente di avere prestazioni di ASF superiori che dovrebbero essere brillanti velocemente anche con centinaia o migliaia di bot abilitati. La CPU non dovrebbe più essere una strozzatura, in quanto ASF è in grado di utilizzare tutta la potenza della CPU quando necessario, tagliando il tempo necessario al minimo indispensabile. Il passo successivo sarebbe l'aggiornamento della CPU e della RAM o la suddivisione del carico di lavoro su diversi server e istanze di ASF.