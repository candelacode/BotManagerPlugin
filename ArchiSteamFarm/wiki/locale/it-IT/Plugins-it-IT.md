# Plugin

ASF include il supporto per plugin personalizzati che possono essere caricati durante l'esecuzione. I plugin consentono di personalizzare il comportamento di ASF, ad esempio aggiungendo comandi personalizzati, una logica di trading personalizzata o una completa integrazione con servizi e API di terze parti.

Questa pagina descrive i plugin ASF dal punto di vista degli utenti - spiegazione, utilizzo e allo stesso modo. Se si desidera visualizzare la prospettiva dello sviluppatore, spostare **[qui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)** invece.

---

## Uso

ASF carica plugin dalla directory `plugins` situata nella cartella ASF. È una pratica consigliata (che diventa obbligatoria con gli aggiornamenti automatici dei plugin) per mantenere una directory dedicata per ogni plugin che si desidera utilizzare, che può essere basato sul suo nome, come `MyPlugin`. In questo modo si otterrà la struttura ad albero finale di `plugins/MyPlugin`. Infine, tutti i file binari del plugin dovrebbero essere inseriti all'interno di quella cartella dedicata, e ASF scoprirà e utilizzerà correttamente il plugin dopo il riavvio.

Di solito gli sviluppatori di plugin pubblicheranno i loro plugin in forma di un file `zip` con binari all'interno, il che significa che dovresti scompattare quel file zip nella sua sottodirectory dedicata all'interno della directory `plugins`.

Se il plugin è stato caricato con successo, vedrai il suo nome e la sua versione nel registro. Dovresti consultare gli sviluppatori di plugin in caso di domande, problemi o utilizzo relativi ai plugin che hai deciso di usare.

Puoi trovare alcuni plugin in evidenza nella nostra sezione **[di terze parti](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)**.

**Si prega di notare che i plugin ASF potrebbero essere dannosi**. Dovresti sempre assicurarti di utilizzare i plugin fatti dagli sviluppatori di cui puoi fidarti, anche quelli della sezione di terze parti sopra. Gli sviluppatori di ASF non possono più garantire i normali vantaggi di ASF (come la mancanza di malware o di VAC-free) se si decide di utilizzare qualsiasi plugin personalizzato. È necessario capire che i plugin hanno pieno controllo sul processo ASF una volta caricato, a causa di questo siamo anche in grado di supportare le impostazioni che utilizzano plugin personalizzati, dal momento che non stai più eseguendo il codice ASF vaniglia.

---

## Compatibilità

A seconda della complessità del plugin, della portata e di molti altri fattori, è del tutto possibile che ti richiederà di utilizzare la variante **[generica](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** ASF, invece di solitamente raccomandato **[OS-specific](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. Questo perché la variante specifica per il sistema operativo viene fornita solo con la funzionalità di base richiesta per ASF stessa, e il tuo plugin può richiedere parti che non rientrano nel campo di applicazione principale di ASF, in conseguenza essere incompatibile con le build tagliati OS-specific .

In generale, quando si utilizzano plugin di terze parti, si consiglia di utilizzare variante generica ASF per la massima compatibilità. Tuttavia, non tutti i plugin potrebbero richiederlo - si prega di fare riferimento alle informazioni del plugin per scoprire se è necessario utilizzare la variante generica di ASF o meno.

---


## Aggiornamenti automatici

ASF ha un meccanismo integrato per gli aggiornamenti automatici dei plugin. Perché questa funzione funzioni, prima di tutto, il tuo plugin di scelta deve supportare **[il meccanismo](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)**. Se hai caricato un plugin che supporta gli aggiornamenti automatici, ASF lo indicherà nel registro correttamente durante l'inizializzazione del plugin, come "plugin è stato disabilitato da aggiornamenti automatici" o "plugin è stato registrato e abilitato per aggiornamenti automatici".

Per impostazione predefinita, gli aggiornamenti automatici per i plugin personalizzati sono **disabilitati**, per motivi di sicurezza. È possibile configurare gli aggiornamenti automatici nella configurazione utilizzando **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** e/o **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)**, si consiglia di leggere la descrizione di queste proprietà di configurazione per ulteriori informazioni. E 'anche bello notare che, come con gli aggiornamenti di ASF, è possibile decidere di mantenere gli aggiornamenti automatici disabilitati, e quindi aggiornare su come necessario, base manuale, emettendo il comando `updateplugins` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

Entrambi gli approcci consentono di aggiornare nessuno, alcuni, o tutti i plugin personalizzati che hai caricato nel processo.