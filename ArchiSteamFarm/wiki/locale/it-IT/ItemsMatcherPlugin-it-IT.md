# ItemsMatcherPlugin

`ItemsMatcherPlugin` è il plugin **[ufficiale di ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** che estende ASF con ASF STM che elenca le caratteristiche. In particolare, questo include `PublicListing` in **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** e `MatchActively` in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. ASF viene fornito con `ItemsMatcherPlugin` in bundle con la release, quindi è pronto per l'uso subito.

---

## `PublicListing`

L'elenco pubblico, come suggerisce il nome, è l'elenco dei bot ASF STM attualmente disponibili. Si trova su **[il nostro sito](https://asf.justarchi.net/STM)**, managed automatically and used as a public service for both ASF users that make use of `MatchActively`, così come gli utenti ASF e non ASF per l'abbinamento manuale.

Per essere elencati, si dispone di una serie di requisiti da soddisfare. Al minimo, devi avere permesso `PublicListing` in `RemoteCommunication` (impostazione predefinita), `SteamTradeMatcher` abilitato in `Preferenze`, **[inventario pubblico](https://steamcommunity.com/my/edit/settings)** impostazioni sulla privacy, un account **[senza restrizioni](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** e **[attivo ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)**. Ulteriori requisiti includono 2FA attivo da almeno 15 giorni, ultimo cambio password più di 5 giorni fa, mancanza di limiti di conto come blocchi, divieti economici e divieti commerciali. Naturalmente, devi anche avere almeno un oggetto (tradable) nel tuo inventario da `MatchableTypes`specificato, come le carte commerciali. Oltre a ciò, i bot con più di `500000` articoli non sono accettati a causa di sovraccarico eccessivo, in questo caso raccomandiamo di dividere il tuo inventario in diversi conti.

Mentre `PublicListing` è abilitato per impostazione predefinita, si prega di notare che **non** essere visualizzato sul sito web se non si soddisfano tutti i requisiti, specialmente `SteamTradeMatcher`, che non è abilitato per impostazione predefinita. Per le persone che non soddisfano i criteri, anche se hanno mantenuto attivata la `PublicListing` , ASF non comunica con il server in alcun modo. La quotazione pubblica è anche compatibile solo con l'ultima versione stabile di ASF e può rifiutare di visualizzare bot obsoleti, soprattutto se mancano funzionalità di base che possono essere trovate solo nelle versioni più recenti.

### Come funziona esattamente

ASF invia i dati iniziali una volta dopo l'accesso, che contiene tutte le proprietà pubbliche inserendo fa uso di. Poi, ogni 10 minuti ASF invia una richiesta molto piccola "battuta cardiaca" che notifica al nostro server che il bot è ancora in funzione. Se per qualche motivo il battito cardiaco non è arrivato, per esempio a causa di problemi di rete, quindi ASF riproverà inviandolo ogni minuto, fino a quando il server non lo registrerà. In questo modo il nostro server sa esattamente quali bot sono ancora in esecuzione e pronti ad accettare offerte commerciali. ASF invierà anche un annuncio iniziale su base necessaria, ad esempio se rileva che il nostro inventario è cambiato rispetto a quello precedente.

Mostriamo tutti gli account ASF idonei attivi negli ultimi 15 minuti ****. Gli utenti sono ordinati in base alla loro relativa utilità - `MatchEverything` bot che vengono mostrati con `Any` banner che accettano tutte le operazioni 1:1, poi contano giochi unici, e infine gli oggetti contano.

### API

L'elenco ASF STM accetta solo i bot ASF per il tempo. Non c'è modo di elencare i bot di terze parti nella nostra lista per ora, in quanto non possiamo rivedere il loro codice facilmente e assicurarsi che soddisfino la nostra intera logica di trading. La partecipazione all'elenco richiede quindi l'ultima versione stabile di ASF, anche se può essere eseguita con plugin **[personalizzati](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

Per i consumatori dell'inserzione, abbiamo un endpoint **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** molto semplice che puoi usare. Include tutti i dati che abbiamo, a parte gli inventari degli utenti che fanno parte della funzionalità `MatchActively` esclusivamente.

### Informativa sulla privacy

Se accetti di essere elencato nella nostra lista, abilitando `SteamTradeMatcher` e non rifiutando `PublicListing`, come specificato sopra, memorizzeremo temporaneamente alcuni dettagli del tuo account Steam sul nostro server al fine di fornire le funzionalità previste.

Informazioni pubbliche (esposte da Steam a ogni parte interessata) includono:
- Il tuo identificatore Steam (in forma a 64 bit, per generare collegamenti)
- Il tuo soprannome (per scopi di visualizzazione)
- Il tuo avatar (hash, per scopi di visualizzazione)

Condizionalmente informazioni pubbliche (esposte da Steam a ogni parte interessata se si soddisfano i requisiti di inserzione) includono:
- Il tuo inventario **[](https://steamcommunity.com/my/inventory/#753_6)** (così le persone possono usare `MatchActively` contro i tuoi oggetti).

Informazioni private (dati selezionati necessari per fornire la funzionalità) includono:
- Il tuo token di trading **[](https://steamcommunity.com/my/tradeoffers/privacy)** (così le persone al di fuori della tua lista di amici possono inviarti trading)
- L'impostazione `MatchableTypes` (per scopi di visualizzazione e corrispondenza)
- La tua impostazione `MatchEverything` (per scopi di visualizzazione e corrispondenza)
- La tua impostazione `MaxTradeHoldDuration` (così altre persone sanno se sei disposto ad accettare le loro operazioni)

Dal momento in cui smettete di utilizzare (annunciare) il nostro elenco, i vostri dati diventano inaccessibili al pubblico entro un massimo di 15 minuti, ed è tenuto sul nostro server per un massimo di due settimane - tutto viene automaticamente cancellato dopo quel periodo. Non è richiesta alcuna azione da parte tua perché ciò accada.

---

## `MatchActively`

L'impostazione `MatchActively` è la versione attiva di **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** , inclusa la corrispondenza interattiva in cui il bot invierà scambi ad altre persone. Può funzionare in standalone, o insieme con l'impostazione `SteamTradeMatcher`. Questa funzione richiede che `LicenseID` sia impostata, in quanto utilizza server di terze parti e risorse pagate per operare.

Al fine di fare uso di questa opzione, si dispone di una serie di requisiti da soddisfare. Al minimo, devi avere un account **[senza restrizioni](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** , **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** attivo e almeno un tipo valido in `MatchableTypes`, come le carte commerciali. Ulteriori requisiti includono 2FA attivo da almeno 15 giorni, ultimo cambio password più di 5 giorni fa, mancanza di limiti di conto come blocchi, divieti economici e divieti commerciali.

Se si soddisfano tutti i requisiti di cui sopra, ASF comunicherà periodicamente con il nostro **[pubblico ASF STM che elenca](#publiclisting)** al fine di abbinare attivamente i bot attualmente disponibili.

Durante l'abbinamento, il bot ASF recupererà il proprio inventario, quindi comunicare con il nostro server per trovare tutte le possibili corrispondenze `MatchableTypes` da altri bot attualmente disponibili. Grazie alla comunicazione diretta con il nostro server, questo processo richiede una singola richiesta e abbiamo informazioni immediate se qualsiasi bot disponibile offre qualcosa di interessante per noi - se la corrispondenza è trovata, ASF invierà e confermerà automaticamente l'offerta commerciale.

Questo modulo dovrebbe essere trasparente. La corrispondenza inizierà in circa `1` ora dall'inizio di ASF e si ripeterà ogni `6` ore (se necessario). La funzione `MatchActively` è finalizzata ad essere utilizzata come misura periodica a lungo termine per garantire che ci stiamo attivamente dirigendo verso il completamento dei set, tuttavia, le persone che non eseguono ASF 24/7 possono anche considerare di utilizzare un comando `match` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Gli utenti di destinazione di questo modulo sono account primari e account alt "stash", anche se può essere utilizzato da qualsiasi bot che non è impostato su `MatchEverything`. Oltre a ciò, i bot con più di `500000` elementi non sono accettati per la corrispondenza a causa di sovraccarico eccessivo, in questo caso raccomandiamo di dividere il tuo inventario in diversi conti.

ASF fa del suo meglio per ridurre al minimo la quantità di richieste e pressioni generate utilizzando questa opzione, mentre allo stesso tempo massimizzare l'efficienza di abbinamento al limite superiore. L'algoritmo esatto di scegliere i bot da abbinare e altrimenti organizzare l'intero processo, è il dettaglio dell'implementazione di ASF e può cambiare in termini di feedback, situazione e possibili idee future.

La versione corrente dell'algoritmo rende ASF prioritize `Any` bot prima, soprattutto quelli con una migliore diversità di giochi da cui provengono i loro oggetti. Quando si esauriscono i bot `Qualsiasi` , ASF passerà a quelli `Fair` sulla stessa regola della diversità. ASF cercherà di abbinare ogni bot disponibile almeno una volta, per assicurarsi che non ci manchi su un possibile progresso impostato.

`MatchActively` prende in considerazione i bot che hai blacklist dal trading attraverso il comando `tbadd` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** e non tenteranno di abbinarli attivamente. Questo può essere usato per dire a ASF quali bot non dovrebbe mai corrispondere, anche se avrebbero potenziali dupes per noi da usare.

ASF farà inoltre del suo meglio per garantire che le offerte commerciali siano in corso. Alla prossima gara, che normalmente accade in 6 ore, ASF annullerà le offerte di trading pendenti che non erano ancora accettate, e deprioritize SteamID che prendono parte a loro per preferire i bot più attivi prima. Tuttavia, se i bot deprioritizzati sono gli ultimi che hanno la partita di cui abbiamo bisogno, cercheremo ancora di abbinarli (ancora).

---

### Perché ho bisogno di un `LicenseID` per utilizzare `MatchActively`? Non era già libero?

ASF è, e rimane, libera e open-source, come è stato istituito all'inizio del progetto nel mese di ottobre 2015. Codice sorgente del plugin `ItemsMatcher` e quindi la funzionalità `MatchActively` è disponibile nel nostro repository, mentre il programma ASF è interamente non commerciale, non guadagniamo nulla dai contributi ad esso, costruzione o pubblicazione. Negli ultimi 7+ anni ASF ha ricevuto una notevole quantità di sviluppo, ed è ancora in fase di miglioramento e miglioramento con ogni rilascio mensile stabile principalmente da una sola persona, **[JustArchi](https://github.com/JustArchi)** - senza stringhe. L'unico finanziamento che riceviamo è da donazioni non obbligatorie che provengono dai nostri utenti.

Per molto tempo, fino a ottobre 2022, la funzione `MatchActively` faceva parte del nucleo di ASF e era disponibile per tutti da usare. Nell'ottobre 2022, Valve, l'azienda dietro Steam, ha messo limiti di tasso molto severi sul recupero di inventari di altri bot - che ha reso funzionalità precedenti completamente rotte, senza possibilità di una soluzione per risolvere questo problema. Pertanto, a causa del fatto che la funzione è diventata completamente defunta senza alcuna possibilità di essere fissata, doveva essere rimosso dal nucleo di ASF come obsoleto.

`MatchActively` was resurrected as part of official `ItemsMatcher` plugin that further enhances ASF with active cards matching functionality, basandosi su un concetto completamente rielaborato. Resurrecting `MatchActively` feature required from us **extraordinary amount of work** to create ASF backend, servizio completamente nuovo ospitato su un server, con più di un centinaio di proxy retribuiti per la risoluzione degli inventari, tutti esclusivamente per consentire ai client ASF di fare uso di `MatchActively` come prima. A causa della quantità di lavoro coinvolto, oltre alle risorse che non sono gratuite e che richiedono di essere pagate mensilmente da noi (dominio, server, proxies), abbiamo deciso di offrire questa funzionalità ai nostri sponsor, cioè, persone che già supportano il progetto ASF su base mensile, grazie a chi possiamo rendere disponibili quelle risorse pagate.

Il nostro obiettivo non è quello di trarne vantaggio, ma piuttosto, coprire i costi mensili **** che sono esclusivamente collegati con l'offerta di questa opzione - ecco perché lo offriamo fondamentalmente per niente, ma dobbiamo addebitare un po 'per esso come non possiamo pagare centinaia di dollari dalle nostre tasche ogni mese, solo per renderlo disponibile per voi. Non siamo davvero in grado di discutere il prezzo, è Valve che ha costretto quei costi, e l'alternativa è quella di non avere tale funzionalità disponibile a tutti, che naturalmente si applica se si decide, per qualsiasi motivo, che non è possibile giustificare l'utilizzo del nostro plugin a questi termini.

In ogni caso, comprendiamo che `MatchActively` non è per tutti, e speriamo che capiate anche perché non possiamo offrirlo gratuitamente. Se nessuno fosse interessato a contribuire a coprire i costi di questa funzione, semplicemente non esisteva per cominciare, come saremmo stati costretti a tagliare le spese mensili che nessuno è disposto a mantenere. Per fortuna, siamo in una posizione migliore di quella e puoi decidere te stesso se sei disposto a usare `MatchActively` a quei termini, o no.

---

### Come posso ottenere un accesso?

`ItemsMatcher` è offerto come parte del mensile $5+ sponsor tier su **[JustArchi's GitHub](https://github.com/sponsors/JustArchi)**. È anche possibile diventare sponsor una tantum, anche se in questo caso la licenza sarà valida solo per un mese (con possibilità di estensione allo stesso modo). Una volta che diventate uno sponsor di $5 tier (o superiore), leggete la sezione di configurazione **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** per ottenere e riempire `Licenza`. In seguito, devi solo abilitare `MatchActively` in `TradingPreferences` del tuo bot scelto.

La licenza consente di inviare una quantità limitata di richieste al server. $5 tier ti permette di utilizzare `MatchActively` per un account bot (4 richieste al giorno), e ogni ulteriore $5 aggiunge altri due account bot (8 richieste al giorno). Per esempio, se si desidera eseguire su tre account, questo sarà coperto da $10 livello e più alto.