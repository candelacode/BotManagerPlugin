# FAQ

La nostra FAQ di base copre le domande standard e le risposte che potresti avere. Invece per questioni meno comuni, per favore visita il nosto **[FAQ esteso](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ)**.

# Tabella dei contenuti

* [Generale](#general)
* [Confronto con strumenti simili](#comparison-with-similar-tools)
* [Sicurezza / Privacy / VAC / Ban / TdS](#security--privacy--vac--bans--tos)
* [Varie](#misc)
* [Problemi](#issues)

---

## Generale

### Cos'è ASF?
### Perché il programma sostiene che non c'è nulla da coltivare sul mio conto?
### Perché ASF non rileva tutti i miei giochi?
### Perché il mio profilo è limitato?

Prima di provare a comprendere cosa ASF sia, dovresti assicurarti di aver capito cosa sono le schede di Steam, e come ottenerle, ben descritto nella FAQ ufficiale **[qui](https://steamcommunity.com/tradingcards/faq)**.

In breve, le carte di Steam sono oggetti raccoglibili che sei idoneo a ricevere quando possiedi un particolare gioco, e sono utilizzabili per creare distintivi, vendere sul mercato di Steam od ogni altro scopo di tua scelta.

I punti fondamentali sono ribaditi in questa sede, perché le persone in generale non vogliono essere d'accordo con loro e preferiscono fingere che quelli non esistano:

- **Devi possedere il gioco sul tuo profilo di Steam per essere idoneo a ricevere ogni carta da esso. La condivisione familiare non è proprietà e non conta.**
- **Il tuo gioco non può essere contrassegnato come [privato](https://help.steampowered.com/faqs/view/1150-C06F-4D62-4966), ASF salterà automaticamente tali giochi durante l'agricoltura.**
- **Non puoi farmare infinitamente il gioco, ogni gioco ha un numero fisso di carte ottenibili. Una volta caduti tutti (circa la metà del set completo), il gioco non è più un candidato per l'agricoltura. Non importa che tu abbia venduto, scambiato, creato o dimenticato cosa sia successo a quelle carte che hai ottenuto, una volta finite le carte ottenibili, il gioco è finito.**
- **Non puoi ottenere carte dai giochi F2P senza spendere denaro in essi. Questo significa permanentemente F2P giochi come Team Fortress 2 o Dota 2. Possedere i giochi F2P non ti concede gocce di carte.**
- **Non puoi rilasciare carte su un account [limitato](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A), indipendentemente dai giochi di proprietà e dal loro metodo di attivazione.**
- **I giochi a pagamento che hai ottenuto gratuitamente durante una promozione non possono essere allevati per gocce di carte, indipendentemente da ciò che viene visualizzato nella pagina del negozio.**

Quindi, come puoi vedere, le carte di Steam ti sono assegnate giocando un gioco che hai comprato, o un gioco F2P in cui hai speso soldi. Se giochi abbastanza a lungo a tale gioco, tutte le carte per quel gioco andranno nel tuo inventario, rendendoti possibile di completare un distintivo (dopo aver ottenuto metà del mazzo), venderle o fare qualsiasi altra cosa tu voglia.

Ora che abbiamo spiegato le basi di Steam, possiamo spiegare ASF. Il programma stesso è abbastanza complesso da comprendere a pieno, quindi invece di scavare in tutti i dettagli tecnici, offriremo una spiegazione molto semplificata sotto.

ASF accede al tuo profilo di Steam tramite la nostra implementazione del client di Steam personalizzata usando le credenziali da te fornite. Dopo aver effettuato l'accesso, analizza i tuoi badge **[](https://steamcommunity.com/my/badges)** per trovare i giochi che sono disponibili per l'agricoltura (gocce di carta`X` rimanenti). Dopo aver analizzato tutte le pagine e costruito l'elenco finale di giochi disponibili, ASF sceglie l'algoritmo di farming più efficiente e avvia il processo. Il processo dipende dall'algoritmo **[scelto di agricoltura delle carte](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** ma di solito è costituito da gioco idoneo e periodicamente (più su ogni goccia di oggetto) controllare se la partita è già completamente coltivata - se sì, ASF può procedere con il titolo successivo, utilizzando la stessa procedura, fino a quando tutti i giochi sono completamente coltivati.

Tieni a mente che la spiegazione sotto è semplificata e non descrive dozzine di funzionalità extra e funzioni che ASF offre. Visita il resto della **[nostra wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki)** se vuoi sapere ogni dettaglio di ASF. Ho provato a renderlo abbastanza semplice da esser comprensibile per tutti, senza portare i dettagli tecnici; gli utenti avanzati sono incoraggiati a scavare più in profondità.

Ora come un programma, ASF offre della magia. Prima di tutto, non deve scaricare ogni file di gioco, può giocare da subito ai giochi. Secondo, è interamente indipendente dal tuo client di Steam normale, non devi averlo in esecuzione, né installato. Terzo, è una soluzione automatizzata, a significare che ASF fa automaticamente tutto per conto tuo, senza doverti dire ciò che fa, il che ti risparmia tempo e fastidi. Infine, non deve ingannare la rete di Steam per emulazione del processo (che ad es. Idle Master sta usando), poiché può comunicarvi direttamente. Inoltre è super veloce e leggero, essendo una soluzione fantastica per tutti coloro che vogliono ottenere facilmente le carte senza troppo fastidio; diventa specialmente utile lasciandolo in esecuzione in background mentre si fa altro o persino giocando in modalità offline.

Tutto quanto sopra è bello, ma ASF ha anche alcune limitazioni tecniche che sono applicate da Steam - non possiamo coltivare giochi che non possiedi, non possiamo coltivare i giochi per sempre per ottenere gocce extra oltre il limite imposto e non possiamo coltivare i giochi mentre stai giocando. Tutto questo dovrebbe essere "logico", considerando il modo in cui funziona ASF, ma è bello notare che ASF non ha super-poteri e non farà qualcosa che è fisicamente impossibile, in modo da tenere a mente - è fondamentalmente lo stesso come se hai detto a qualcuno di accedere al tuo account da un altro PC e fattoria quei giochi per voi.

Quindi per riassumere, ASF è un programma che ti aiuta a ottenere queste carte per cui sei idoneo, senza troppi fastidi. Offre anche diverse altre funzioni, ma per ora atteniamoci solo a questa.

---

### Devo inserire le credenziali del mio profilo?

**Sì**. ASF richiede le tue credenziali del profilo così come il client ufficiale di Steam, usando lo stesso metodo per l'interazione di rete di Steam. Questo però non significa che devi inserire le credenziali del tuo account nelle configurazioni di ASF, puoi continuare a utilizzare ASF con SteamLogin `vuoto` e/o `SteamPassword`, e immettere i dati su ogni esecuzione di ASF, quando necessario (così come diverse altre credenziali di accesso, fare riferimento alla configurazione). Così i tuoi dettagli non sono salvati da nessuna parte, ma ovviamente ASF non può avviarsi da solo senza il tuo aiuto. ASF offre anche diversi altri modi per aumentare la tua **[sicurezza](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**, quindi sentiti libero di leggere quella parte della wiki se sei un utente avanzato. Se non lo sei, e non vuoi inserire le credenziali del tuo profilo nelle configurazioni di ASF, allora semplicemente non farlo, inseriscile invece quando necessario, quando ASF le richiede.

Tieni a mente che lo strumento ASF è per il tuo uso personale e che le tue credenziali non abbandonano mai il tuo computer. Inoltre non le condividi con nessuno, soddisfacendo i **[TdS di Steam](https://store.steampowered.com/subscriber_agreement)**, una cosa molto importante di cui le persone si dimenticano. Non invii i tuoi dettagli ai nostri server o altre terze parti, solo direttamente ai server di Steam operati da Valve. Non conosciamo le tue credenziali e non siamo capaci di recuperarle da te, indipendentemente dal fatto che tu le metta o no nelle tue configurazioni.

---

### Quanto devo attendere per ottenere le carte?

**Quanto ci vuole**, sul serio. Ogni gioco ha differenti difficoltà di farming impostate dallo sviluppatore/ediotre, e dipende totalmente da loro quanto velocemente sono ottenibili le carte. Gran parte dei giochi rilascia 1 carta ogni 30 minuti di gioco, ma ci sono anche giochi che ti richiedono di giocare anche diverse ore prima di ottenerne una. Inoltre, il tuo profilo potrebbe esser limitato dal ricevere carte dai giochi che non hai ancora giocato abbastanza, come dichiarato nella sezione **[prestazioni](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Non tentare di indovinare quanto a lungo ASF dovrebbe farmare il dato titolo; la decisione non dipende da te, né da ASF. Non c'è niente che tu possa fare per renderlo più veloce, e non esiste "bug" in relazione alle carte non rilasciate in modo tempestivo; non controlli il processo di ottenimento delle carte, né ASF. Nel migliore dei casi, riceverai la media di 1 carta ogni 30 minuti. Nel peggiore dei casi, non riceverai una carta anche per 4 ore dall'avvio di ASF. Entrambe le situazioni sono normali e coperte nella nostra sezione **[prestazioni](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**.

---

### Il farming richiede troppo tempo, posso velocizzarlo in qualche modo?

L'unica cosa che influenza pesantemente la velocità di farming è l'**[algoritmo di farming delle carte](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** per l'istanza del tuo bot. Ogni altra cosa ha effetti trascurabili e non renderà più veloce il farming, mentre alcune azioni come il lancio del processo di ASF diverse volte lo **peggiorerà**. Se hai davvero urgenza di ottenere da ogni singolo secondo dal processo di farming, allora ASF ti consente di affinare alcune variabili principali di farming come `FarmingDelay`, tutte spiegate in **[configurazione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Tuttavia, come detto, l'effetto è trascurabile e scegliere l'algoritmo di farming delle carte adatto per il dato profilo è l'unica scelta cruciale che può pesantemente influenzare la velocità di farming, tutto il resto è puramente cosmetico. Invece di preoccuparti della velocità di farming, lancia ASF e fagli fare il suo lavoro, posso assicurarti che lo sta facendo nel modo più efficiente che potesse venirmi in mente. Meno ti importa, più sarai soddisfatto.

---

### Ma ASF ha detto che il farming avrebbe impiegato circa X tempo!

ASF approssima in base al numero di carte che devi ottenere, e il tuo algoritmo scelto; questo non è per nulla vicino al tempo reale che passerai farmando, solitamente più lungo, poiché ASF presume solo il miglior caso, e ignora tutte le stranezze della Rete di Steam, le disconnessioni da Internet, i sovraccarichi dei server di Steam e simili. Dovrebbe esser visto solo come un indicatore generale di quanto a lungo aspettarsi che ASF farmi, molto spesso nel caso migliore, poiché il tempo reale differirà, anche significativamente in alcuni casi. Come accennato sopra, non provare a indovinare quanto a lungo il dato gioco sarà farmato, non dipende né da te né da ASF decidere.

---

### ASF può funzionare sul mio android/smartphone?

ASF è un programma C# che richiede un'implementazione funzionante di .NET. Android è diventato una piattaforma valida a partire da .NET 6. , tuttavia, c'è attualmente un bloccante importante nel fare ASF accadere su Android a causa di **[mancanza di ASP. ET runtime disponibile su di esso](https://github.com/dotnet/aspnetcore/issues/35077)**. Anche se non c'è un'opzione nativa disponibile, ci sono build corrette e funzionanti per GNU/Linux su architettura ARM, quindi è possibile utilizzare qualcosa come **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** per l'installazione di Linux, quindi utilizzando ASF in tale Linux chroot come al solito.

Quando/Se tutti i requisiti di ASF sono soddisfatti, considereremo la possibilità di rilasciare una build ufficiale di Android.

---

### Gli oggetti della fattoria di ASF possono essere prodotti da giochi di vapore, come CS:GO o Unturned?

**No**, è contro i **[TeC di Steam](https://store.steampowered.com/subscriber_agreement)** e Valve lo ha chiaramente dichiarato con l'ultima ondata di ban della community per il farming di oggetti di TF2. ASF è un programma di farming di carte di Steam, non di oggetti di gioco, non ha alcuna capacità di farming di oggetti di gioco e non è previsot aggiungere tale funzionalità in futuro, mai, principalmente per la violazione dei termini d'uso di Steam. Sei pregato di non chiedere a proposito, il meglio che potresti ottenere è una segnalazione da qualche utente e avere problemi. Lo stesso vale per tutti gli altri tipi di agricoltura, come le gocce di agricoltura da trasmissioni CS:GO. ASF si concentra esclusivamente sulle carte di scambio di Steam.

---

### Posso scegliere quali giochi dovrebbero essere portati?

**Sì**, in vari diversi modi. Se si desidera modificare l'ordine predefinito della coda di allevamento, allora è quello che `FarmingOrders` **[proprietà di configurazione bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** può essere utilizzato per. Se si desidera manualmente blacklist determinati giochi da essere allevati automaticamente, puoi usare la blacklist inattiva disponibile con il comando `fb` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Se vuoi coltivare tutto ma dare priorità ad alcune app su tutto il resto, che è la coda di priorità inattiva disponibile con il comando `fq` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** può essere utilizzato per. E infine, se si desidera coltivare giochi specifici di vostra scelta soltanto, allora puoi dichiarare `FarmPriorityQueueOnly` nel bot **[`FarmingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)** per ottenere questo, insieme con l'aggiunta delle app selezionate alla coda di priorità inattiva.

Oltre a gestire il modulo di farming di carte automatico descritto sopra, puoi anche passare alla modalità manuale di ASF con il **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** `play`, o usare varie altre impostazioni esterne come `GamesPlayedWhileIdle`, una **[proprietà di configurazione del bnot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

---

### Non sono interessato a gocce di carte, mi piacerebbe coltivare ore giocate invece, è possibile?

Sì, ASF ti consente di farlo in vari modi.

Il modo migliore per raggiungere questo obiettivo è utilizzare **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** proprietà di configurazione, che giocherà gli appID scelti quando ASF non ha carte da coltivare. Se si desidera giocare i vostri giochi per tutto il tempo, anche se avete gocce di carte da altri giochi, allora puoi combinarlo con **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, in modo da ASF fattoria solo quei giochi per gocce di carte che esplicitamente impostato, o, in alternativa, **[`FarmingPausedByDefault`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, che farà sì che il modulo di allevamento delle carte venga messo in pausa fino a quando non lo rimetti in pausa da solo.

Puoi anche fare uso del comando **[`play`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#commands-1)** , che causerà ASF a giocare le partite selezionate. Tuttavia, tieni presente che `play` dovrebbe essere utilizzato solo per i giochi che vuoi giocare temporaneamente, poiché non è uno stato persistente, causando il ritorno di ASF allo stato predefinito e. . al momento della disconnessione dalla rete Steam. Dunque, ti consigliamo di usare `GamesPlayedWhileIdle`, a meno che tu non voglia iniziare i giochi da te selezionati solo per un breve periodo di tempo, e poi tornare al flusso generale.

---

### Sono utente Linux / macOS, ASF fattoria giochi che non sono disponibili per il mio OS? ASF fattoria 64-bit giochi quando lo sto eseguendo su 32-bit OS?

Sì, ASF non si preoccupa nemmeno di scaricare i file di gioco effettivi, quindi funzionerà con tutte le tue licenze collegate al tuo profilo di Steam, indipendentemente dalla piattaforma o i requisiti tecnici. Dovrebbe funzionare anche per i giochi collegati a una regione specifica (giochi bloccati per regione), anche quando non sei nella regione corrispondente, sebbene ciò non sia garantito (funzionava l'ultima volta che ho provato).

---

## Confronto con strumenti simili

---

### ASF è simile a Idle Master?

L'unica somiglianza è lo scopo generale di entrambi i programmi, che è l'agricoltura giochi di vapore per ricevere gocce di carta. Tutto il resto, compreso il metodo di allevamento effettivo, struttura del programma, funzionalità, compatibilità, algoritmi usati, in particolare il codice sorgente stesso, è completamente diverso e quei due programmi non hanno nulla di comune tra loro, anche la fondazione principale - IM è in esecuzione su. ET Framework, ASF su .NET (Core). ASF è stato creato per risolvere i problemi di IM, impossibili da risolvere con una semplice modifica del codice, ecco perché ASF è stato scritto da zero, senza usare una singola linea di codice o persino idea generale da IM, poiché il codice e tali idee erano completamente difettosi. IM e ASF sono come Windows e Linux, sono entrambi sistemi operativi installabili sul tuo PC, ma non condividono quasi niente tra loro, se non il servire uno scopo simile.

Questo è anche il motivo per cui non dovresti comparare ASF a IM basandoti sulle aspettative di IM. Dovresti trattare ASF e IM come programmi interamente indipendenti con le proprie esclusive serie di funzionalità. Senza dubbio, alcune di esse si sovrappongono e puoi trovare in entrambe una funzionalità in particolare, ma molto raramente, poiché ASF serve il suo scopo con un approccio interamente differente se comparato a IM.

---

### Vale la pena usare ASF, se correntemente uso Idle Master e funziona bene per me?

**Sì**. ASF è molto più affidabile e include molte funzioni integrate che sono **cruciali** indipendentemente dal modo in cui si alleva, che IM semplicemente non offre.

ASF ha una logica adeguata per i giochi **inediti** - IM cercherà di coltivare giochi che hanno carte già aggiunte, anche se non sono ancora stati rilasciati. Naturalmente, non è possibile coltivare quei giochi fino alla data di rilascio, quindi il vostro processo di agricoltura sarà bloccato. Questo ti richiederà di aggiungerli alla blacklist, attendere il rilascio o saltarli manualmente. Nessuna di queste soluzioni è buona, e tutti richiedono la vostra attenzione - ASF salta automaticamente l'agricoltura di giochi inediti (temporaneamente), e ritorna a loro più tardi quando lo sono, evitando completamente il problema e affrontandolo in modo efficiente.

ASF ha anche una logica propria delle **serie** di video. Ci sono molti video su Steam che hanno carte, ma sono annunciati con `appID` sbagliato sulla pagina dei badge, come **[Double Fine Adventure](https://store.steampowered.com/app/402590)** - IM erroneamente alleverà sbagliato `appID`che non produrrà gocce e processo di essere bloccato. Ancora una volta, dovrai inserirli nella blacklist o saltarli manualmente, richiedendo in entrambi i casi la tua attenzione. ASF scopre automaticamente il corretto `appID` per l'agricoltura che porta a gocce di carta.

Oltre a ciò, ASF è **molto più stabile e affidabile** quando si tratta di problemi di rete e stranezze di Steam, funziona gran parte del tempo e non richiede la tua attenzione una volta configurato, mentre IM spesso si rompe per molte persone, richiede correzioni extra o semplicemente non funziona. Inoltre è anche totalmente dipendente dal client di Steam, il che significa che questo non funziona se il tuo client di Steam sta riscontrando problemi seri. ASF funziona propriamente finché può connettersi alla rete di Steam e non richiede l'esecuzione o persino l'installazione del client di Steam.

Questi sono 3 **punti** molto importanti perché dovresti prendere in considerazione l'utilizzo di ASF, poiché influenzano direttamente tutti i contendenti le carte Steam e non c'è modo di dire "questo non mi considera", dal momento che le manutenzioni e le stranezze di vapore stanno accadendo a tutti. Ci sono dozzina di motivi extra più o meno importanti che potresti scoprire nel resto della FAQ. In breve, **sì**, dovresti usare ASF anche quando non necessiti di alcuna funzionalità extra di ASF disponibile quando comparato a IM.

Oltre a ciò, IM è ufficialmente interrotto e potrebbe rompersi completamente in futuro, senza nessuno che si preoccupi di correggerlo, considerando l'esistenza di soluzioni molto più potenti (non solo ASF). IM già non funziona per molte persone e quel numero è in aumento, non in discesa. Dovresti evitare di usare software obsoleti in primo luogo, non solo IM ma anche tutti gli altri programmi deprecati. Nessun manutentore attivo significa che nessuno si preoccupa se funziona o meno e **nessuno è responsabile della sua funzionalità**, che è una questione cruciale in termini di sicurezza. Basta dire che se ci dovesse essere un bug critico che causi problemi reali all'infrastruttura di Steam, senza nessuno pronto a risolverlo, Steam potrebbe emettere un'altra ondata di ban da cui saresti colpito senza nemmeno sapere di essere un problema, come già successo a molte persone che usavano, indovinate un po', versioni obsolete di ASF.

---

### Che funzionalità interessanti ha ASF da offrire che Idle Master non ha?

Dipende da cosa consideri "interessante" per te. Se si prevede di coltivare più conti di uno allora la risposta è già evidente dal momento che ASF consente di allevare tutti loro con una soluzione superiore, risparmio di risorse, problemi e compatibilità. Tuttavia, se stai facendo questa domanda probabilmente non hai questa particolare esigenza, quindi valutiamo altri benefici che si applicano a un profilo singolo usato in ASF.

In primo luogo, hai alcune funzionalità integrate citate **[sopra](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** che sono fondamentali per l'agricoltura indipendentemente dal tuo obiettivo finale, e molto spesso che da solo è già sufficiente per prendere in considerazione l'uso di ASF. Ma questo lo sai già, quindi spostiamoci su alcune funzionalità più importanti:

- **Puoi coltivare offline** (`OnlineStatus` nell'impostazione `Offline`). Farming offline ti permette di saltare completamente lo stato di Steam nel gioco, che consente di coltivare con ASF mentre mostra "Online" su Steam allo stesso tempo, senza i tuoi amici anche notando che ASF sta giocando un gioco per vostro conto. Questa è una funzionalità superiore, che ti consente di rimanere online nel tuo client di Steam, senza infastidire i tuoi amici con cambi di gioco costanti, o ingannandoli nel pensare che stai giocando a un gioco mentre in realtà non lo stai facendo. Questo punto da solo rende valido usare ASF se rispetti i tuoi amici, ma è solo l'inizio. Bello notare anche che questa funzionalità non ha nulla a che fare con le impostazioni di privacy di Steam: se lanci da solo il gioco, allora ti mostrerai propriamente come in gioco ai tuoi amici, rendendo ASF la parte invisibile e senza influenzare affatto il tuo profilo.

- **Puoi saltare i giochi rimborsabili** (`SkipRefundableGames` nella funzione `FarmingPreferences` del bot). ASF ha una corretta logica integrata per i giochi rimborsabili e puoi configurare ASF per non coltivare automaticamente i giochi rimborsabili. Questo ti permette di valutare te stesso se il tuo nuovo gioco acquistato dal negozio Steam valeva il tuo denaro, senza che ASF provi a rilasciare carte il prima possibile. Se si gioca per 2 ore o 2 settimane dopo l'acquisto, quindi ASF procederà con quel gioco in quanto non è più rimborsabile. Fino ad allora si dispone di pieno controllo se si gode o meno e si può facilmente rimborsare se necessario, senza dover manualmente blacklist quel gioco o non utilizzare ASF per tutta la durata.

- **Puoi saltare le partite non giocate** (`SkipUnplayedGames` nella funzione `FarmingPreferences` del bot). ASF ha una logica integrata corretta per ore nei giochi e puoi configurare ASF per non coltivare automaticamente i giochi non giocati. Questo ti permette di controllare te stesso i giochi che giochi e fattoria, senza dover manualmente blacklist tutti o saltare completamente ASF.

- **È possibile contrassegnare automaticamente i nuovi elementi come ricevuto** (`BotBehaviour` of `DismissInventarioNotifiche` funzione). Farming with ASF will result in your account receiving new card drops. Sapete già che questo sta per accadere, quindi lasciare che ASF chiaro che inutile notifica per voi, garantire che solo cose importanti solleveranno la vostra attenzione. Certo, solo se vuoi.

- **È possibile personalizzare l'ordine di allevamento preferito con più opzioni disponibili** (funzione`FarmingOrders`). Forse vuoi prima coltivare i tuoi giochi appena acquistati? O i più anziani? Secondo il numero di gocce di carta? Livelli di distintivo che hai già creato? Ore giocate? Alfabeticamente? Secondo AppID? O forse completamente casuale? Sta interamente a voi decidere.

- **ASF può aiutarti a completare i tuoi set** (`TradingPreferences` con la funzione `SteamTradeMatcher`). Con un po 'più avanzato tinkering, puoi convertire il tuo ASF in user-bot completamente funzionante che accetterà automaticamente le offerte **[STM](https://www.steamtradematcher.com)** , aiutandoti ogni giorno ad abbinare i tuoi set senza alcuna interazione con l'utente. ASF include anche il proprio modulo ASF 2FA che consente di importare il vostro autenticatore mobile Steam e consente di automatizzare completamente l'intero processo con l'accettazione di conferme. Oppure, forse vuoi accettare manualmente e lasciare che ASF prepari solo quei mestieri per te? Sta ancora una volta, completamente a voi decidere.

- **ASF può riscattare le chiavi in background per te** (**[giochi in background redentore](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** funzione). Forse avete un centinaio di chiavi da vari pacchetti che siete troppo pigri per riscattare voi stessi, passare attraverso un sacco di finestre e accettare a Steam termini e condizioni più e più volte. Perché non copia-incolla il tuo elenco di chiavi in ASF e lasciare che faccia il suo lavoro? ASF riscatterà automaticamente tutti quei tasti in background, fornendo l'output appropriato per farti sapere come ogni tentativo di riscattare si è presentato. Inoltre, se hai centinaia di chiavi, hai la garanzia di ottenere un tasso limitato da Steam prima o poi, e ASF sa anche questo, aspetterà pazientemente che il limite di tasso per andare via, e riprendere da dove è partito.

Potremmo ora andare avanti con tutta la **[ASF wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**, segnalando ogni singola caratteristica del programma, ma dobbiamo tracciare una linea da qualche parte. Questo è questo, questo è un elenco di funzionalità che si può godere come utente di ASF, dove solo uno di questi potrebbe essere facilmente considerato un motivo importante per non guardare mai indietro, e abbiamo effettivamente elencato **un sacco** di loro, con ancora di più si può imparare sul resto della nostra wiki. Ah sì, e non siamo nemmeno entrati in dettaglio con cose come l'API di ASF che ti permettono di scrivere i tuoi comandi, o gestione fantastica dei bot, dal momento che volevamo mantenerlo semplice.

---

### ASF è più veloce di Idle Master?

**Sì**, anche se la spiegazione è piuttosto complicata.

Su ogni nuovo processo generato e terminato sul vostro sistema, steam client invia automaticamente una richiesta contenente tutti i tuoi giochi che stai giocando - in questo modo la rete di vapore può calcolare le ore e far cadere le carte. Tuttavia, la rete di vapore conta il tempo giocato ad intervalli di 1 secondo e l'invio di una nuova richiesta ripristina lo stato corrente. In altre parole, se avessi generato / uccidere nuovo processo ogni 0,5 secondi, non si sarebbe mai cadere alcuna carta perché ogni 0. il secondo client di vapore invierebbe una nuova richiesta e la rete di vapore non conterebbe mai nemmeno 1 secondo del tempo di gioco. Inoltre, a causa di come funziona il sistema operativo, è in realtà abbastanza comune vedere nuovi processi essere generati / terminati senza nemmeno fare nulla, quindi anche se non stai facendo nulla sul tuo PC - ci sono molti processi che funzionano ancora in background, generazione/terminazione di altri processi per tutto il tempo. Idle master è basato sul client di vapore, quindi questo meccanismo ti influenza se lo stai usando.

ASF non si basa sul client di vapore, ha una propria implementazione client di vapore. Grazie a questo, ciò che ASF sta facendo, non sta generando alcun processo, ma in realtà inviando uno, vera richiesta alla rete di vapore che abbiamo iniziato a giocare un gioco. Questa è la stessa richiesta che verrebbe inviata dal client di vapore, ma perché abbiamo il controllo effettivo sul client vapore ASF, non abbiamo bisogno di generare nuovi processi, e non stiamo imitando il client di vapore per quanto riguarda la richiesta di invio su ogni cambiamento di processo, quindi il meccanismo spiegato sopra non ci riguarda. Grazie a ciò, non interrompiamo mai questo intervallo di 1 secondo sul lato della rete di vapore, e questo migliora la nostra velocità di coltivazione.

---

### Ma la differenza è davvero notevole?

No. Le interruzioni che stanno accadendo con il normale client di vapore e il padrone inattivo hanno un effetto trascurabile sulle gocce della carta, quindi non è alcuna differenza evidente che renderebbe superiore ASF.

Tuttavia, c'è **è** una differenza, e si può chiaramente notare che, a seconda di quanto occupato il tuo sistema operativo, le carte **saranno** più veloci, da pochi secondi a anche pochi minuti, se sei estremamente sfortunato. Anche se non prenderei in considerazione l'utilizzo di ASF solo perché rilascia le carte più velocemente, come sia ASF e Idle Master sono influenzati da come funziona il web di vapore, ASF interagisce solo con la rete di vapore in modo più efficace, mentre Idle Master non può controllare ciò che il client di vapore sta effettivamente facendo (quindi non è colpa di Idle Master, ma il cliente di vapore stesso).

---

### ASF fattoria giochi multipli in una volta?

**Sì**, sebbene ASF sappia meglio quando usare quella funzione, in base all'algoritmo **[selezionato di agricoltura delle carte](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Il tasso di calo della carta quando si coltivano più giochi è vicino a zero, questo è il motivo per cui ASF utilizza più giochi agricoltura esclusivamente per ore al fine di superare `HoursUntilCardDrops` più velocemente, per un massimo di `32` partite contemporaneamente. Questo è anche il motivo per cui si dovrebbe concentrarsi sulla configurazione parte di ASF, e lasciare che gli algoritmi decidano qual è il modo migliore per raggiungere l'obiettivo - quello che pensi sia giusto, non è necessariamente giusto in realtà, coltivare più giochi in una sola volta non vi fornirà alcuna goccia di carte.

---

### ASF può saltare i giochi velocemente?

**No**, ASF non supporta né incoraggia l'uso di **[glitch di Steam](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance#steam-glitches)**.

---

### ASF può giocare automaticamente ogni partita per X ore prima che le carte vengano aggiunte?

**No**, l'intero punto di cambio del sistema delle carte Steam è stato quello di combattere con false statistiche e giocatori fantasma. ASF non contribuirà a questo più del necessario, l'aggiunta di tale funzione non è prevista e non accadrà. Se il gioco riceve gocce di carta in modo solito, ASF li alleverà il più presto possibile.

---

### Posso giocare un gioco mentre ASF è agricolo?

**No**. ASF, a differenza di alcuni altri strumenti che si integrano con il tuo client Steam, ha la sua implementazione indipendente di quel client incluso, e la rete Steam consente a un solo client di Steam **alla volta** di giocare a un gioco. Puoi comunque disconnettere ASF ogni volta che ti piace avviando una partita (e facendo clic su "OK" quando ti viene chiesto se la rete Steam dovrebbe disconnettere un altro client) - ASF aspetterà pazientemente fino a quando non hai finito di giocare, e riprendere il processo in seguito. In alternativa, puoi ancora giocare in modalità offline ogni volta che vuoi, se questo è soddisfacente per te.

Tenete a mente che il tasso di caduta delle carte quando si giocano più partite è comunque vicino a zero, non vi sono quindi vantaggi diretti da poter farlo con altri strumenti, mentre ci sono forti vantaggi di non interferire con altri giochi lanciati con ASF, che è cruciale e. . VAC-wise.

---

## Sicurezza / Privacy / VAC / Ban / TdS

---

### Posso ottenere il divieto VAC per l'utilizzo di questo?

No, non è possibile perché ASF (a differenza di altri strumenti, come Idle Master, SGI o SAM) non interferisce in alcun modo con il client a vapore né con i suoi processi. È fisicamente impossibile ottenere il divieto VAC per l'utilizzo di ASF, anche durante la riproduzione su server protetti mentre ASF è in esecuzione - questo è perché **ASF non richiede nemmeno che Steam Client sia installato a tutti** per funzionare correttamente. ASF è uno dei pochi programmi agricoli che attualmente possono garantire di essere VAC-free.

---

### L'uso di ASF mi impedisce di giocare su server protetti da VAC, come dichiarato **[qui](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**?

ASF non richiede che il client Steam sia in esecuzione o addirittura installato. In base a questo concetto, **non** dovrebbe causare alcun problema relativo al VAC, perché ASF garantisce la mancanza di interferenza con il client Steam e tutti i suoi processi - questo è il punto principale quando si parla di garanzia VAC libero che ASF offre.

Secondo gli utenti e meglio delle mie conoscenze, questo è il caso in questo momento, come nessuno ha segnalato problemi come indicato nel link di cui sopra durante l'utilizzo di ASF. Non siamo riusciti a riprodurre il problema sopra anche con ASF, riproducendolo chiaramente con Idle Master.

Tuttavia, tieni presente che Valve potrebbe ancora aggiungere ASF alla blacklist ad un certo punto, ma è una sciocchezza completa come anche se lo fanno, potresti ancora giocare a giochi protetti da VAC dal tuo PC, e usare ASF allo stesso tempo. . sul tuo server, quindi sono abbastanza sicuro che sanno molto bene che ASF non dovrebbe essere un sospetto VAC saggio, e non renderanno le nostre vite più difficili dalla lista nera di ASF per nessun motivo. Tuttavia, nel peggiore dei casi, non sarai in grado di giocare, come indicato sopra, perché la garanzia senza VAC di ASF è ancora qui indipendentemente dal fatto che Steam blacklist ASF binario, o non (e puoi ancora lanciare ASF su qualsiasi altra macchina senza che il client Steam sia completamente installato). In questo momento non c'è bisogno di fare alcuno di questo, e speriamo che rimanga così.

---

### È sicuro?

Se si chiede se ASF è sicuro come un software, il che significa che non causerà alcun danno al computer, non rubare i dati privati, installare virus o qualsiasi altra roba del genere - è sicuro. ASF è privo di malware, dati rubati, minatori di criptovalute e qualsiasi altro comportamento dubbio che può essere considerato dannoso o indesiderato dall'utente. Oltre a questo abbiamo una sezione dedicata **[di comunicazione remota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** che copre la nostra privacy policy e il comportamento di ASF che va al di là di quello che hai configurato il programma per fare da soli.

Il nostro codice è open-source, e i binari distribuiti sono sempre compilati da fonti **[pubblicamente disponibili](https://en.wikipedia.org/wiki/Open-source_software)** by **[sistemi di integrazione continua automatizzati e affidabili](https://en.wikipedia.org/wiki/Build_automation)**, e nemmeno gli sviluppatori stessi. Ogni build è riproducibile seguendo il nostro script di build e produrrà esattamente lo stesso, codice **[deterministico](https://en.wikipedia.org/wiki/Deterministic_system)** IL (binario). Se per qualsiasi motivo non ti fidi delle nostre costruzioni, puoi sempre compilare e utilizzare ASF dalla sorgente, incluse tutte le librerie che ASF sta usando (come SteamKit2), che sono anche open-source.

Alla fine, tuttavia, è sempre una questione di fiducia per gli sviluppatori della tua applicazione, così si dovrebbe decidere se si considera ASF sicuro o no, potenzialmente supportando la vostra decisione con gli argomenti tecnici sopra specificati. Non credete ciecamente a qualcosa solo perché lo abbiamo detto - controllatevi, perché è l'unico modo per essere sicuri.

---

### Posso essere bandito per questo?

Per rispondere a questa domanda, dovremmo dare un'occhiata più da vicino a **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Steam non vieta l'utilizzo di account multipli, infatti, **[consente](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)** che implica che è possibile utilizzare lo stesso autenticatore mobile su più di un account. Quello che però non consente è la condivisione di account con altre persone, ma non lo stiamo facendo qui.

L’unico punto reale che considera la ASF è il seguente:
> Non è possibile utilizzare Cheats, software di automazione (bot), mods, hack o qualsiasi altro software di terze parti non autorizzati, per modificare o automatizzare qualsiasi processo di Subscription Marketplace.

La domanda è che cosa in realtà è il processo di Subscription Marketplace. Come possiamo leggere:

> Un esempio di mercato delle sottoscrizioni è il mercato della Comunità di Steam

Non stiamo modificando o automatizzando il processo di sottoscrizione marketplace se per abbonamento marketplace capiamo il mercato della comunità di vapore o il negozio di vapore. Tuttavia...

> Valve può annullare l'Account o qualsiasi Abbonamento particolare in qualsiasi momento nel caso in cui (a) Valve cessi di fornire tali Abbonamenti agli Abbonati situati in modo analogo in generale, o (b) tu violi i termini del presente Contratto (inclusi eventuali Termini di Abbonamento o Regole di Utilizzo).

Pertanto, come per ogni software Steam, ASF non è autorizzato da Valve e non posso garantire che non verrai sospeso se Valve decide improvvisamente che stanno bannando account utilizzando ASF ora. Ciò è estremamente improbabile se si considera che ASF viene utilizzato su più di pochi milioni di conti Steam, dal suo primo rilascio che è accaduto oltre 10 anni fa - ma ancora una possibilità, indipendentemente dalla probabilità reale.

Soprattutto perché:
> Per quanto riguarda tutte le Sottoscrizioni, i Contenuti e i Servizi che non sono stati scritti da Valve, Valve non scherma tali contenuti di terze parti disponibili su Steam o attraverso altre fonti. Valve non si assume alcuna responsabilità per tali contenuti di terzi. Alcuni software applicativi di terze parti sono in grado di essere utilizzati dalle imprese per scopi commerciali - tuttavia, si può acquisire tale software solo tramite Steam per uso privato personale.

Tuttavia, Valve riconosce chiaramente "idler di Steam" esistenti, come dichiarato **[qui](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**, quindi se mi hai chiesto, Sono abbastanza sicuro che se non stavano bene con loro, avrebbero già fare qualcosa invece di sottolineare che potrebbero causare problemi VAC-wise. La parola chiave qui è **Steam** idlers, per esempio ASF, e non **gioco** idlers.

Si prega di notare che sopra è solo la nostra interpretazione di **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** e vari punti - ASF è concesso in licenza sotto Apache 2. Licenza, che indica chiaramente:

```
A meno che non sia richiesto dalla legge applicabile o accettato per iscritto, il software
distribuito sotto la licenza è distribuito su un "AS IS" BASIS,
SENZA GARANZIE O CONDIZIONI DI QUALSIASI KIND, espressa o implicita.
```

Stai usando questo software a tuo rischio. È estremamente improbabile che tu possa essere bandito per questo, ma se lo fai, puoi incolpare solo te stesso.

---

### Qualcuno è stato bannato per esso?

**Sì**, abbiamo avuto almeno alcuni incidenti finora che hanno portato ad una sorta di sospensione di vapore. Se ASF stesso era la causa principale o meno è una storia completamente diversa che probabilmente non riusciremo mai a conoscere.

Il primo caso ha coinvolto un ragazzo con oltre 1000+ bot ottenere il commercio vietato (insieme a tutti i bot), molto probabilmente a causa di un uso eccessivo di `bottino ASF` eseguito su tutti i bot contemporaneamente, o altre quantità sospette di operazioni su un lato in un tempo molto breve.

> Ciao XXX, Grazie per aver contattato il supporto Steam. Sembra che questo account sia stato utilizzato per gestire una rete di account bot. Imbottigliamento è una violazione del Contratto di Abbonato di Steam.

Si prega di utilizzare qualche buon senso e non supporre che si può fare tali cose pazzesche solo perché ASF consente di farlo. Fare il bottino `ASF` su oltre 1k di bot può essere facilmente considerato un attacco **[DDoS](https://en.wikipedia.org/wiki/DDoS)** , e personalmente non sono scioccato che qualcuno sia stato bandito per una cosa del genere. Mantenere il minimo di fair use per quanto riguarda il servizio di Steam, e **molto probabilmente** andrà bene.

Secondo caso ha coinvolto un ragazzo con 170 + bot che vengono banditi durante la vendita invernale 2017 di Steam.

> Il tuo account è stato bloccato per violazione dell'accordo dell'abbonato Steam. A giudicare dagli scambi e da altri fattori, questo conto è stato utilizzato per raccogliere illegalmente carte da collezione su Steam, nonché attività commerciali correlate e non solo. L'account è stato permanentemente bloccato e il supporto di Steam non può fornire ulteriore supporto su questo problema.

Questo caso è ancora una volta molto difficile da analizzare, a causa di una risposta vaga da parte del supporto Steam che a malapena offre qualsiasi dettaglio. Sulla base dei miei pensieri personali, questo utente probabilmente ha scambiato le carte Steam con qualche tipo di denaro (livello fino bot? o in qualche altro modo ha provato a incassare su Steam. Nel caso in cui non fossi a conoscenza, questo è anche illegale secondo **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Non siamo in grado di dirti cosa puoi fare con le carte di trading ottenute tramite ASF - ma l'utente in questione sicuramente non ha creato solo badge con loro.

Il terzo caso riguardava l'utente con 120+ bot vietati per violazione del comportamento online **[Steam](https://store.steampowered.com/online_conduct?l=english)**.

> Ciao XXX, Grazie per aver contattato il supporto Steam. Questo e altri account sono stati utilizzati per inondare la nostra infrastruttura di rete, che è una violazione della condotta online di Steam. L'account è stato permanentemente bloccato e il supporto di Steam non può fornire ulteriore supporto su questo problema.

Questo caso è un po 'più facile da analizzare a causa dei dettagli aggiuntivi forniti dall'utente. Apparentemente l'utente stava usando **una versione di ASF** molto obsoleta che includeva un bug che causava ASF all'invio di un numero eccessivo di richieste ai server di Steam. Il bug stesso non esisteva in un primo momento, ma è stato attivato a causa di Steam cambiamento di rottura che è stato risolto nella versione futura. **ASF is supported only in [latest stable version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) released on GitHub**.

Non si può presumere che qualche versione obsoleta di ASF funzionerà come usato per funzionare per sempre, soprattutto perché Steam cambia costantemente indipendentemente dal fatto che ti piaccia o meno. Se tale cosa accade a livello globale, è rapidamente in fase di patch e rilasciato a tutti gli utenti come una correzione di bug. Valve non proibirà improvvisamente più di un milione di utenti di ASF a causa del nostro o del loro errore, per ovvi motivi. Tuttavia, se intenzionalmente ti dimetti dall'utilizzo di ASF aggiornato, quindi per definizione sei in una piccolissima minoranza di utenti che sono **esposti a incidenti come questi** a causa di **nessun supporto**, come non c'è nessuno a guardare la tua versione obsoleta di ASF, nessuno lo ripara e nessuno assicura che non si ottiene completamente vietato semplicemente lanciandolo. **Si prega di utilizzare software aggiornato**, non solo ASF, ma anche tutte le altre applicazioni.

Il caso più recente è avvenuto intorno a giugno del 2021, secondo l'utente:

> Utilizzando il programma, ho fatto pacchetti di booster con 28 account per 3 anni e con 128 account per gli ultimi 6 mesi. Ero online con un massimo di 15 account contemporaneamente per fare pacchetti booster e inviarli al conto principale. Il mese scorso, ho aumentato il numero di account online simultaneamente a 20, e 1 settimana dopo, tutti i miei account sono stati vietati. Questa email non è da biasimare, al contrario, ero sempre consapevole delle conseguenze. Volevo sapere quali tipi di comportamento portano a un divieto permanente.

È difficile dire se l'aumento di account simultanei online fosse la ragione diretta del divieto, Non mi affiderei su questo, invece credo che il numero di conti da solo sia stato il principale colpevole, aumento della convaluta di account online probabilmente ha appena richiamato l'attenzione dell'utente in questione, in quanto chiaramente aveva molto più bot rispetto alla nostra raccomandazione.

---

Tutti gli incidenti di cui sopra hanno una cosa in comune - ASF è solo uno strumento ed è **la tua decisione** come farai uso di esso. Non vieni bannato per l'utilizzo di ASF direttamente, ma per **come** lo stai usando. Può essere uno strumento di aiuto agricoltura solo un singolo conto, o una rete di agricoltura massiccia fatta da migliaia di bot. In ogni caso, non sto offrendo consulenza legale e dovresti decidere in primo luogo del tuo utilizzo di ASF. Non sto nascondendo alcuna informazione che possa aiutarti, ad es. il fatto che ASF ha ottenuto alcune persone vietate (e in quale contesto), come non ho motivo di - è la vostra scelta che cosa si vuole fare con quelle informazioni.

Se mi chiedi - usa un po' di buon senso, evita di possedere più bot rispetto alla nostra raccomandazione, non inviare centinaia di operazioni allo stesso tempo, utilizzare sempre la versione aggiornata di ASF e _dovrebbe_ andare bene. Ogni singolo incidente di questa natura per **qualche motivo** è sempre successo a persone che hanno ignorato le nostre raccomandazioni, migliori pratiche e suggerimenti, credendo di sapere meglio di noi. . quanti bot possono correre. Che si tratti solo di una coincidenza o di un fattore reale, spetta a te decidere. Non offriamo alcuna consulenza legale, solo dando i nostri pensieri che si può trovare utile, o ignorarli interamente e operare solo su fatti sopra collegati.

---

### Quali informazioni sulla privacy ASF comunica?

Puoi trovare una spiegazione dettagliata nella sezione **[comunicazione remota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. Dovresti esaminarlo se ti interessa la tua privacy, ad esempio se ti stai chiedendo perché gli account utilizzati in ASF si uniscono al nostro gruppo Steam. ASF non raccoglie informazioni sensibili e non le condivide con terze parti.

---

## Varie

---

### Sto usando il sistema operativo non supportato come Windows a 32 bit, posso ancora utilizzare l'ultima versione di ASF?

Sì, e quella versione non è non supportata in alcun modo, solo non ufficialmente costruita. Controlla la compatibilità **[sezione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** per la variante generica. ASF non ha alcuna forte dipendenza dal sistema operativo, e può funzionare ovunque dove è possibile ottenere un lavoro. ET runtime, che include Windows a 32 bit, anche se non c'è un pacchetto `win-x86` specifico per il sistema operativo da noi.

---

### ASF è grande! Posso fare una donazione?

Sì, e siamo molto felici di sentire che ti stai godendo il nostro progetto! Puoi trovare varie possibilità di donazione in ogni release **[](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** e **[nella pagina principale](https://github.com/JustArchiNET/ArchiSteamFarm)**. È bello notare che oltre alle donazioni generiche di denaro accettiamo anche articoli di Steam, quindi niente ti impedisce di donare pelli, chiavi o una piccola parte delle carte che hai coltivato con ASF se vuoi. Grazie in anticipo per la vostra generosità!

---

### Sto usando il PIN parentale di Steam per proteggere il mio account, ho bisogno di inserirlo da qualche parte?

Sì, è necessario impostarlo nella proprietà di configurazione bot `SteamParentalCode`. Questo principalmente perché ASF accede a molte parti protette del tuo account Steam ed è impossibile che ASF operi senza di esso.

---

### Non voglio ASF per allevare nessun gioco di default, ma voglio utilizzare funzioni ASF extra. È possibile?

Sì, se vuoi solo avviare ASF con il modulo di coltivazione delle carte in pausa, puoi impostare la proprietà di configurazione del bot `FarmingPausedByDefault` in `FarmingPreferences` per raggiungere questo obiettivo. Questo ti permetterà di riavviare `` durante il runtime.

Se vuoi disabilitare completamente il modulo di allevamento delle carte e assicurati che non funzionerà mai senza che tu lo dica esplicitamente altrimenti, poi consigliamo di impostare `FarmPriorityQueueOnly` nel bot `FarmingPreferences`, che invece di solo mettere in pausa, disabiliterà completamente l'agricoltura fino a quando non si aggiungono i giochi alla coda di priorità inattiva.

Con schede farming modulo in pausa/disabilitato, è possibile utilizzare le funzioni ASF extra, come ad esempio `giochiGiocatoWhileIdle`.

---

### ASF può ridurre al minimo il vassoio?

ASF è una console app, non c'è finestra da minimizzare, perché la finestra viene creata per te dal tuo sistema operativo. È tuttavia possibile utilizzare qualsiasi strumento di terze parti in grado di farlo, come ad esempio **[RBTray](https://github.com/benbuck/rbtray)** per Windows, o **Schermo[](https://linux.die.net/man/1/screen)** per Linux/macOS. Questi sono solo esempi, ci sono molte altre applicazioni con funzionalità simili.

---

### L'uso di ASF preserva l'idoneità per la ricezione dei pacchetti di richiamo?

**Sì**. ASF sta utilizzando lo stesso metodo per accedere alla rete di Steam del client ufficiale, quindi mantiene anche la capacità di ricevere pacchetti di richiamo per i conti che vengono utilizzati in ASF. Inoltre, la conservazione di questa abilità non richiede nemmeno l'accesso nella comunità di Steam, in modo da poter utilizzare in modo sicuro l'impostazione `OnlineStatus` in `Offline` se lo desideri.

---

### C'è un modo per comunicare con ASF?

Sì, attraverso diversi modi. Controlla la sezione **[comandi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** per ulteriori informazioni.

---

### Vorrei aiutare con la traduzione di ASF, che cosa devo fare?

Grazie per il vostro interesse! Puoi trovare tutti i dettagli nella nostra sezione **[di localizzazione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)**.

---

### Ho solo un account (principale) aggiunto ad ASF, posso ancora emettere comandi attraverso la chat di vapore?

**Sì**è spiegato nella sezione **[comandi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#notes)**. Puoi farlo attraverso la chat di gruppo Steam, anche se usare **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** potrebbe essere più facile per te.

---

### ASF sembra funzionare, ma non sto ricevendo gocce di carta!

Carte tasso di allevamento differisce da gioco a gioco, come si può leggere in **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Ci vuole un po', di solito **diverse ore per partita**, e non dovresti aspettarti che le carte cadano in pochi minuti dal lancio di un programma. Se puoi vedere che ASF controlla attivamente lo stato delle carte e cambia la partita dopo che quella corrente è completamente coltivata, allora tutto funziona bene. È possibile che tu abbia abilitato un'opzione come `DismissInventarioNotifiche` di `BotBehaviour` che automaticamente respinge le notifiche d'inventario. Scopri la configurazione **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** per i dettagli.

---

### Come interrompere completamente il processo di ASF per il mio account?

Basta spegnere il processo di ASF, per esempio facendo clic su [X] su Windows. Se invece vuoi fermare un particolare bot a tua scelta, ma tieni in esecuzione altri bot, poi dai un'occhiata alla proprietà di configurazione del bot `Abilitato` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**, o `stop` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Se invece si desidera interrompere il processo di allevamento automatico, ma mantenere ASF in esecuzione per il tuo account, allora è quello che `FarmingPausedByDefault` opzione di `FarmingPreferences` in **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** e `pausa` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** è per.

---

### Quanti bot posso eseguire con ASF?

ASF come programma non ha alcun limite massimo duro di istanza del bot, in modo da poter eseguire quanto avete memoria sulla vostra macchina, tuttavia, sei ancora limitato dalla rete di Steam e da altri servizi di Steam. Attualmente è possibile eseguire fino a 100-200 bot con un unico IP e una singola istanza di ASF. È possibile eseguire più bot con più IP e più casi di ASF, lavorando intorno alle limitazioni IP. Tieni presente che se stai usando quella grande quantità di bot, dovresti controllare tu stesso il loro numero, come fare in modo che tutti loro in realtà si stanno accedendo e lavorare allo stesso tempo. ASF non è stato indebolito per quel numero enorme di bot, e la regola generale applica che **più bot hai, più problemi incontrerai**. Si noti anche che il limite sopra in generale dipende da molti fattori interni, è approssimazione piuttosto che un limite rigoroso - sarà molto probabilmente in grado di eseguire più / meno bot di quanto specificato sopra.

ASF team suggerisce **possedere** fino a **10 account Steam in totale**, e quindi anche in esecuzione fino a **10 bot in totale**. Tutto ciò di cui sopra non è supportato e fatto a proprio rischio, contro il nostro suggerimento qui presentato. Questa raccomandazione si basa sulle linee guida interne di Valve, nonché sui nostri suggerimenti. Se hai intenzione di rispettare questa regola o meno è la vostra scelta, ASF come strumento non andrà contro la vostra volontà, anche se farà sì che i tuoi account Steam siano sospesi per farlo. Pertanto, ASF ti mostrerà un avviso se andrai al di sopra di quello che raccomandiamo, ma permettete comunque di correre tutto quello che volete a vostro rischio e mancanza di nostro sostegno.

---

### Posso eseguire altre istanze ASF allora?

È possibile eseguire tutte le istanze di ASF su una macchina come vuoi, supponendo che ogni istanza abbia una propria directory e le sue configurazioni, e l'account utilizzato in un'istanza non viene utilizzato in un'altra. Tuttavia, chiedi perché vuoi farlo. ASF è ottimizzato per gestire più di cento account allo stesso tempo, e lanciare quel centinaio di bot nelle loro istanze di ASF degrada le prestazioni, richiede più risorse del sistema operativo (come CPU e memoria), e causa potenziali problemi di sincronizzazione tra istanze di ASF standalone, poiché ASF è costretta a condividere i suoi limitatori con altre istanze.

Pertanto, il mio forte suggerimento **** è, sempre eseguito al massimo di un'istanza di ASF per un IP/interfaccia. Se si dispone di più IP/interfacce, è possibile eseguire più istanze ASF, con ogni istanza utilizzando la propria IP/interfaccia o l'impostazione `WebProxy` unica. Se non lo fai, lanciare più istanze di ASF è totalmente inutile, poiché non otterrai nulla dal lancio di più di 1 istanza per una singola IP/interfaccia. Steam non ti permetterà magicamente di eseguire più bot solo perché li hai lanciati in un'altra istanza di ASF, e ASF non ti limita a cominciare.

Naturalmente, ci sono ancora casi di utilizzo validi per più istanze di ASF sulla stessa interfaccia di rete, come ospitare il servizio ASF per i tuoi amici con ogni amico avere una propria istanza unica di ASF al fine di garantire l'isolamento tra i bot e anche i processi ASF stessi, tuttavia, non stai aggirando qualsiasi limitazione di vapore in questo modo, che è uno scopo completamente diverso.

---

### Qual è il significato dello status quando si riscatta una chiave?

Lo stato indica come è stato effettuato il tentativo di riscatto. Ci sono molti stati diversi possibili, i più comuni includono:

| Stato                   | Descrizione                                                                                                                                                                                                                    |
| ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| NoDetail                | "OK" stato che indica il successo - la chiave è stata redimita con successo.                                                                                                                                                   |
| Timeout                 | La rete di Steam non ha risposto in un dato momento, non sappiamo se la chiave è stata riscattata o meno (molto probabilmente era, ma puoi riprovare).                                                                         |
| BadActivationCode       | La chiave fornita non è valida (non riconosciuta come qualsiasi chiave valida dalla rete Steam).                                                                                                                               |
| DuplicateActivationCode | La chiave fornita è stata già riscattata da qualche altro account, o revocata da sviluppatore/editore.                                                                                                                         |
| Già Acquistato          | Il tuo account possiede già `packageID` che è connesso con questa chiave. Tieni presente che questo non indica se la chiave è `DuplicateActivationCode` o no - solo che è valida e non è stata utilizzata in questo tentativo. |
| Paese Limitato          | Questa è la chiave bloccata per regione e il tuo account non è nella regione valida che è autorizzata a riscattarla.                                                                                                           |
| DoesNotOwnRequiredApp   | Non puoi riscattare questa chiave come ti manca qualche altra app - principalmente gioco di base quando stai tentando di riscattare il pacchetto DLC.                                                                          |
| RateLimited             | Hai fatto troppi tentativi di riscattare e il tuo account è stato temporaneamente bloccato. Riprova tra un'ora.                                                                                                                |

---

### Sei affiliato a qualche servizio di fattoria/idling?

**No**. ASF non è affiliato a nessun servizio e tutti questi reclami sono falsi. Il tuo account Steam è la tua proprietà e puoi utilizzare il tuo account in qualsiasi modo desideri, ma Valve chiaramente indicato in **[ufficiale ToS](https://store.steampowered.com/subscriber_agreement)** che:

> Siete responsabili della riservatezza del vostro login e password e della sicurezza del vostro sistema informatico. Valve non è responsabile per l'uso della password e dell'account o per tutte le comunicazioni e attività su Steam che derivano dall'uso del nome di accesso e della password da parte dell'utente, o da qualsiasi persona a cui Lei può avere intenzionalmente o per negligenza rivelato il Suo login e/o password in violazione della presente disposizione di riservatezza.

ASF è concesso in licenza sulla licenza liberale Apache 2.0, che consente ad altri sviluppatori di integrare ulteriormente ASF con i propri progetti e servizi legalmente. Tuttavia, tali progetti di terze parti che utilizzano ASF non sono garantiti per essere sicuri, revisionati, appropriati o legali secondo **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Se vuoi conoscere la nostra opinione, **ti invitiamo vivamente a NON condividere QUALSIASI i dettagli del tuo account con servizi di terze parti**. Se tale servizio si rivela essere una **truffa tipica**, sarete lasciati soli con il problema, molto probabilmente senza il tuo account Steam e ASF non si assumerà alcuna responsabilità per i servizi di terze parti che affermano di essere sicuro e sicuro, perché il team di ASF non ha autorizzato né recensito nessuno di questi. In altre parole, **li stai usando a tuo rischio contro il nostro suggerimento sopra**.

Oltre a ciò, il servizio ufficiale **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** indica chiaramente che:

> Non è possibile rivelare, condividere o consentire in altro modo ad altri di utilizzare la password o l'account tranne se altrimenti autorizzato da Valve.

È il tuo account e la tua scelta. Semplicemente non dica che nessuno ti ha avvisato. ASF come programma soddisfa tutte le regole sopra menzionate, in quanto non condividi i dettagli del tuo account con nessuno, e stai usando il programma per il tuo uso personale, ma qualsiasi altro "servizio di allevamento di carte" richiede da te le credenziali del tuo account, quindi viola anche la regola sopra (in realtà parecchie di loro). Come con la valutazione **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** , non stiamo offrendo alcuna consulenza legale e si dovrebbe decidere se si desidera utilizzare tali servizi, o non - secondo noi **viola direttamente [Steam ToS](https://store.steampowered.com/subscriber_agreement)** e può risultare in sospensione se Valve scoperta. Come accennato sopra, **si consiglia vivamente di NON utilizzare nessuno di tali servizi**.

---

## Problemi

---

### Uno dei miei giochi è stato coltivato per più di 10 ore ora, ma non ho ancora ricevuto alcuna carta da esso!

Il motivo di ciò potrebbe essere correlato a noto problema di Steam, che accade quando si hanno due licenze per lo stesso gioco, una delle quali ha gocce di carta limitate. Questo accade di solito quando si attiva il gioco gratuitamente durante un giveaway di massa su Steam, e poi attivare una chiave per lo stesso gioco (ma senza limitazioni), e. . da un pacchetto a pagamento. Se una tale situazione accade, Steam segnala sulla pagina del distintivo che il gioco ha ancora carte da rilasciare, ma non importa quanto si gioca il gioco - le carte non cadranno mai a causa di licenza gratuita sul tuo account. Dal momento che non è un problema di ASF, ma uno di Steam, non possiamo in qualche modo aggirarlo dal lato di ASF, e devi risolverlo da solo.

Ci sono due modi per risolvere il problema. In primo luogo, è possibile blacklist questo gioco in ASF, o con `fbadd` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** o con `Blacklist` **[proprietà di configurazione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Questo impedirà a ASF di provare a fattoriare le carte da questo gioco, ma non risolverà il problema sottostante che impedisce di ottenere gocce di carta dal gioco interessato. In secondo luogo, è possibile utilizzare lo strumento self-service di supporto di Steam per rimuovere la licenza gratuita dal proprio account, lasciando solo la licenza completa che include le gocce di carta. A tal fine, visita in primo luogo le licenze **[e le attivazioni della chiave del prodotto](https://store.steampowered.com/account/licenses)** pagina e trova sia la licenza gratuita che la licenza a pagamento per il gioco interessato. Di solito è abbastanza facile - entrambi hanno un nome simile, ma libero uno ha "limitato pacchetto promozionale gratuito" o altro "promo" nel nome della licenza, più "gratuito" nel campo "metodo di acquisizione". A volte potrebbe essere più complicato, ad esempio se il pacchetto gratuito era in qualche bundle e ha un nome diverso. Se avete trovato due licenze del genere - allora è davvero il problema descritto qui, e si può tranquillamente rimuovere la licenza gratuita senza perdere il gioco.

Al fine di rimuovere la licenza gratuita dal tuo account, visita **[pagina di supporto Steam](https://help.steampowered.com/wizard/HelpWithGame)** e inserisci il nome del gioco interessato nel campo di ricerca, il gioco dovrebbe essere disponibile nella sezione "prodotti", fare clic su di esso. In alternativa, puoi usare `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` link e sostituire `<appID>` con appID del gioco che causa problemi. In seguito, fare clic su "Voglio rimuovere definitivamente questo gioco dal mio account" e quindi selezionare la licenza gratuita difettosa che hai trovato sopra, di solito quello con "pacchetto promozionale gratuito limitato" nel nome (o simile). Dopo la rimozione della licenza gratuita, ASF dovrebbe essere in grado di rilasciare carte dal gioco interessato senza problemi, si dovrebbe riavviare l'operazione di allevamento dopo la rimozione solo per essere sicuri che Steam prende la licenza giusta questa volta.

---

### ASF non rileva il gioco `X` come disponibile per l'agricoltura, ma so che include le carte di trading Steam!

Ci sono due ragioni principali. Il primo e più ovvio motivo è il fatto che ti stai riferendo ad **Steam store** dove il gioco dato è annunciato come gocce di carta abilitata gioco. Questo è un assunto **sbagliato** , in quanto afferma semplicemente che il gioco **ha gocce di carta** incluse, ma non necessariamente questa funzione per quel gioco è **abilitato** subito. Puoi saperne di più su questo in **[annuncio ufficiale](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**.

In breve, l'icona gocce di carta nel negozio Steam non significa nulla, controlla le tue pagine di distintivo **[](https://steamcommunity.com/my/badges)** per confermare se un gioco ha gocce di carte abilitate o meno - questo è anche quello che ASF sta facendo. Se il tuo gioco non appare nella lista come una partita con le carte possibili da rilasciare, allora questo gioco è **non** possibile da coltivare, indipendentemente dalla ragione.

La seconda questione è meno ovvia, ed è la situazione in cui si può vedere che il vostro gioco è effettivamente disponibile con gocce di carta sulla tua pagina di badge, eppure non viene coltivato da ASF subito. A meno che non stai colpendo qualche altro bug, come ASF non è in grado di controllare le pagine distintivo (descritto di seguito), è semplicemente un effetto cache e sul lato di ASF Steam sta ancora segnalando la pagina dei badge obsoleti. Questo problema dovrebbe risolversi prima o poi, quando la cache viene invalidata. Non c'è nemmeno modo di risolvere questo problema dalla nostra parte.

Naturalmente, tutto ciò presuppone che si sta eseguendo ASF con impostazioni predefinite intatte, dal momento che si potrebbe anche aggiungere questo gioco alla blacklist di allevamento, usa `FarmingPreferences` come `FarmPriorityQueueOnly` o `SkipRefundableGames`, e così via.

---

### Perché il tempo di gioco di giochi coltivati attraverso ASF non aumenta?

Lo fa, ma **non in tempo reale**. Steam registra il tuo tempo di gioco in intervalli fissi e gli orari di aggiornamento per esso, ma non sei sicuro di averlo aggiornato immediatamente nel momento in cui si esce dalla sessione, figuriamoci durante tale. Solo perché il tempo di gioco non è aggiornato in tempo reale non significa che non è registrato, di solito è aggiornato ogni 30 minuti o giù di lì.

---

### Qual è la differenza tra un avviso e un errore nel registro?

ASF scrive sul suo registro un mucchio di informazioni su vari livelli di registrazione. Il nostro obiettivo è quello di spiegare con precisione **** cosa sta facendo ASF, inclusi i problemi di Steam che deve affrontare, o altri problemi da superare. La maggior parte delle volte non tutto è pertinente, questo è il motivo per cui abbiamo due livelli principali utilizzati in ASF in termini di problemi, un livello di allerta e il livello di errore.

La regola generale di ASF è che gli avvisi sono errori **non** , pertanto dovrebbero **non** essere segnalati. Un avvertimento è un indicatore per voi che qualcosa di potenzialmente indesiderato accadere. Che si tratti di Steam non reagire, di errori di lancio API o di una connessione di rete in basso - è un avvertimento, e significa che ci aspettavamo che accadesse, quindi non disturbare lo sviluppo di ASF con esso. Naturalmente sei libero di chiedere loro o ottenere aiuto utilizzando il nostro supporto, ma non dovresti presumere che si tratti di errori ASF che vale la pena segnalare (a meno che non confermiamo diversamente).

Gli errori indicano invece una situazione che non dovrebbe accadere, quindi vale la pena di riferire fintanto che hai fatto in modo che non siete voi che li sta causando. Se è una situazione comune che ci aspettiamo di accadere, allora sarà convertito in un avvertimento. Altrimenti, è forse un bug che dovrebbe essere corretto, non silenziosamente ignorato, supponendo che non sia il risultato del tuo problema tecnico. Ad esempio, mettere contenuti non validi in `ASF. il file son` lancerà un errore, poiché ASF non sarà in grado di analizzarlo, ma è stato tu a metterlo lì, quindi non dovresti segnalare questo errore a noi (a meno che tu non abbia confermato che ASF è sbagliato e la tua struttura è in realtà assolutamente corretta).

In una frase TL;DR - errori di segnalazione, non segnalare avvisi. Puoi ancora chiedere informazioni sugli avvisi e ricevere aiuto nelle nostre sezioni di supporto.

---

### ASF non si avvia, la finestra del programma si chiude immediatamente!

In condizioni normali, qualsiasi crash o uscita di ASF genererà un log `. xt` nella directory del programma da visualizzare, che può essere utilizzato per trovare la causa di questo. Oltre a ciò, alcuni ultimi file di log sono anche archiviati nella directory `logs` , dal registro `principale. xt` file viene sovrascritto con ogni esecuzione di ASF.

Tuttavia, se anche il runtime .NET non è in grado di avviare sulla tua macchina, allora `log.txt` non sarà generato. Se questo accade a te allora molto probabilmente hai dimenticato di installare i prerequisiti .NET, come indicato nella guida **[impostando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. Altri problemi comuni includono il tentativo di lanciare variante ASF sbagliata per il tuo sistema operativo, o in altro modo mancanti dipendenze nativo .NET runtime. Se la finestra della console si chiude troppo presto per leggere il messaggio, aprire la console indipendente e lanciare il binario ASF da lì. Ad esempio su Windows, apri la directory ASF, tieni premuto `Maiusc`, fare clic destro all'interno della cartella e scegliere "*aprire finestra di comando qui*" (o *powershell*), quindi digitare nella console `. ArchiSteamFarm.exe` e confermare con entrata. In questo modo riceverai un messaggio preciso perché ASF non sta iniziando correttamente.

Se non c'è alcun output, e sei su Windows, la causa abituale che non sta avendo tutti gli aggiornamenti di Windows disponibili installati, assicurati di utilizzare il sistema operativo aggiornato, dato che non supportiamo l'esecuzione di ASF su Windows senza soddisfare quella condizione in entrambi i modi.

---

### ASF sta calciando la mia sessione Steam Client mentre sto giocando! / *Questo account è registrato su un altro PC*

Questo appare come un messaggio nella sovrapposizione di Steam che l'account viene utilizzato da qualche altra parte mentre stai giocando. Questo problema può avere due ragioni diverse.

Una ragione è causata da pacchetti interrotti (giochi) che specificamente non tenere un blocco di gioco correttamente, ma aspettatevi che quel blocco sia posseduto dal cliente. Un esempio di tale pacchetto sarebbe Skyrim SE. Il tuo client Steam lancia il gioco correttamente, ma quel gioco non si registra come usato. Per questo motivo, ASF vede che è libero di riprendere il processo, che fa, e che ti esce dalla rete di Steam, poiché Steam rileva improvvisamente che l'account viene utilizzato in un altro luogo.

Secondo motivo potrebbe venire se si sta giocando sul vostro PC mentre ASF è in attesa (soprattutto su un'altra macchina) e si perde la connessione di rete. In questo caso, la rete Steam ti contrassegna come offline e rilascia il blocco di gioco (come sopra), che innesca ASF (ad esempio su un'altra macchina) nella ripresa dell'agricoltura. Quando il PC torna online, Steam non può acquisire più il blocco di gioco (che ora è tenuto da ASF, anche simile a sopra) e mostra lo stesso messaggio.

Entrambe le cause sul lato ASF sono in realtà molto difficile da lavorare, come ASF semplicemente riprende l'agricoltura una volta che la rete Steam lo informa che l'account è libero di essere utilizzato di nuovo. Questo è ciò che sta accadendo normalmente quando si chiude il gioco, ma con pacchetti rotti questo può accadere immediatamente, anche se il gioco è ancora in esecuzione. ASF non ha modo di sapere se si è disconnessi, ha smesso di giocare un gioco o che stai ancora giocando un gioco che non tiene il lucchetto in modo appropriato.

L'unica soluzione corretta a questo problema è mettere manualmente in pausa il tuo bot con `pausa` prima di iniziare a giocare, e riprenderlo con `curriculum` una volta terminato. In alternativa puoi semplicemente ignorare il problema e agire come se hai giocato con il client Steam offline.

---

### `Disconnesso da Steam!` - Non riesco a stabilire la connessione con i server Steam.

ASF può solo **provare** per stabilire la connessione con i server Steam, e può fallire a causa di molte ragioni, tra cui la mancanza di connessione a Internet, Vapore in giù, la connessione firewall, strumenti di terze parti, percorsi configurati in modo errato o guasti temporanei. È possibile abilitare la modalità `Debug` per controllare i log più dettagliati che indicano i motivi esatti di errore, anche se di solito è semplicemente causato dalle tue azioni, ad esempio utilizzando "CS:GO MM Server Picker" che blacklist un sacco di IP di Steam, rendendo molto difficile per voi raggiungere effettivamente la rete di Steam.

ASF farà del suo meglio per stabilire una connessione, che include non solo chiedere su un elenco aggiornato di server, ma anche provare un altro IP quando l'ultimo non funziona, quindi se è veramente un problema temporaneo con un server o un percorso specifico, ASF si connetterà prima o poi. Tuttavia, se sei dietro il firewall o in qualche altro modo non sei in grado di raggiungere i server di Steam, quindi ovviamente devi risolverlo da solo, con il potenziale aiuto della modalità `Debug`.

È anche possibile che la macchina non sia in grado di stabilire una connessione con i server Steam utilizzando il protocollo predefinito in ASF. È possibile modificare i protocolli che ASF è autorizzato a utilizzare modificando la proprietà di configurazione globale `SteamProtocols`. Ad esempio, se hai problemi a raggiungere Steam con il protocollo `UDP` (es. a causa di firewall), forse avrai più fortuna con `TCP` o `WebSocket`.

In una situazione molto improbabile di avere server errati essere memorizzati nella cache, ad esempio a causa dello spostamento della cartella ASF `config` da una macchina all'altra situata in un paese completamente diverso, eliminazione di `ASF. b` al fine di aggiornare i server di Steam al prossimo lancio potrebbe aiutare. Molto spesso non è necessario e non deve essere fatto, in quanto quella lista viene aggiornata automaticamente al primo lancio, così come quando la connessione è stabilita - stiamo solo menzionando come un modo per eliminare tutto ciò che riguarda l'elenco dei server Steam memorizzati in cache da ASF.

---

### `Impossibile accedere a Steam: TryAnotherCM/Invalid`, `ServiceUnavailable/Invalid`

Come da sopra, ma questa volta il server con cui ti sei connesso non è esplicitamente disponibile. Di solito accade durante la finestra di manutenzione di Steam, non c'è nulla che puoi fare a questo proposito, ASF riproverà automaticamente con un server diverso finché non si accetterà la sua richiesta. Non dovrebbe durare più di un'ora massima.

---

### `Impossibile ottenere informazioni sui badge, riprova più tardi!`

Di solito significa che stai usando Steam parental PIN per accedere al tuo account, ma hai dimenticato di metterlo in ASF config. Devi inserire un PIN valido nella proprietà di configurazione del bot `SteamParentalCode` , altrimenti ASF non sarà in grado di accedere alla maggior parte dei contenuti web, quindi non sarà in grado di funzionare correttamente. Vai alla configurazione **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** per saperne di più su `SteamParentalCode`.

Altri motivi includono problemi temporanei di vapore, problema di rete o simili. Se il problema non si risolve dopo diverse ore e sei sicuro di aver configurato ASF in modo appropriato, sentiti libero di farci sapere su questo.

---

### ASF sta fallendo con `Request fallito dopo 5 tentativi di errore`!

Di solito significa che stai usando Steam parental PIN per accedere al tuo account, ma hai dimenticato di metterlo in ASF config. Devi inserire un PIN valido nella proprietà di configurazione del bot `SteamParentalCode` , altrimenti ASF non sarà in grado di accedere alla maggior parte dei contenuti web, quindi non sarà in grado di funzionare correttamente. Vai alla configurazione **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** per saperne di più su `SteamParentalCode`.

Se il PIN parentale non è il motivo, allora questo è un errore più comune, e si dovrebbe abituare a questo, significa semplicemente che ASF ha inviato una richiesta a Steam Network, e non ha ricevuto una risposta valida, 5 volte di fila. Di solito significa che Steam è in basso o sta avendo alcune difficoltà o manutenzione - ASF è consapevole di tali problemi e non si dovrebbe preoccuparsi di loro, a meno che non stiano accadendo costantemente per più di diverse ore, e gli altri utenti non hanno tali problemi.

Come verificare se Steam è in corso? **[Steam Status](https://steamstat.us)** è un'ottima fonte di controllo se Steam **dovrebbe essere** up, se si notano errori, in particolare relativi a Community o Web API, quindi Steam sta avendo difficoltà. Potresti voler lasciare ASF da solo e lasciare che faccia il suo lavoro dopo un breve periodo di tempo di inattività, o smettere e aspettare te stesso.

Questo però non è sempre il caso, come in alcune situazioni i problemi di Steam potrebbero non essere rilevati da Steam Status, ad esempio questo caso è avvenuto quando Valve ha rotto il supporto HTTPS per la Comunità di Steam 7 giugno 2016 - l'accesso a **[SteamCommunity](https://steamcommunity.com)** tramite HTTPS stava lanciando un errore. Pertanto, non fidatevi ciecamente di Steam Status neanche, è meglio controllare se tutto funziona come si suppone.

Oltre a ciò, Steam include varie misure di limitazione della velocità che vietano temporaneamente il tuo IP se fai un numero eccessivo di richieste contemporaneamente. ASF è consapevole di questo e offre diversi limitatori nella configurazione, che si dovrebbe utilizzare. Le impostazioni predefinite sono state modificate in base alla quantità di bot **sane** , se stai usando una quantità così grande che anche Steam ti sta dicendo di andare via, allora o modificarli fino a quando non ti dice più, o fai come ti è stato detto. Presumo che il secondo modo non sia un'opzione per voi, quindi vai a leggere su questo argomento e prestare particolare attenzione a `WebLimiterDelay` che è un limitatore generale che si applica a tutte le richieste web.

Non esiste una "regola d'oro" che funzioni per tutti, perché i blocchi sono fortemente influenzati da fattori di terze parti, ecco perché devi sperimentarti e trovare un valore che funzioni per te. Puoi anche ignorare quello che dico e usare qualcosa come `10000` che è garantito per funzionare correttamente, ma poi non lamentarsi come il vostro ASF reagisce a tutto in 10 secondi e come il distintivo di analisi richiede 5 minuti. Oltre a ciò, è del tutto possibile che nessun limitatore farà qualsiasi cosa perché hai così grande quantità di bot che stai colpendo **[hard limit](#how-many-bots-can-i-run-with-asf)** che è stato menzionato sopra. Sì, è del tutto possibile che sarete in grado di accedere senza problemi alla rete di Steam (client), ma Steam web (sito web) si rifiuterà di ascoltarti se hai 100 sessioni stabilite contemporaneamente. ASF richiede sia la rete di Steam che il web di Steam per essere cooperativo, ci vuole solo uno giù per farti problemi da cui non si recupera.

Se niente aiuta e non hai indizio di ciò che è rotto, è sempre possibile abilitare la modalità `Debug` e vedere se stessi nel registro di ASF perché esattamente le richieste stanno fallendo. Per esempio:

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Proibito <- HEAD https://steamcommunity.com/my/edit/settings
```

Vedi il codice `Proibito`? Ciò significa che è stato temporaneamente vietato per quantità eccessiva di richieste, perché non hai ancora modificato correttamente `WebLimiterDelay` (supponendo di ottenere lo stesso codice di errore anche per tutte le altre richieste). Ci potrebbero essere altri motivi elencati, come ad esempio `InternalServerError`, `ServiceUnavailable` e timeout che indicano manutenzione/problemi di Steam. Si può sempre provare a visitare il link menzionato da ASF e controllare se funziona - se non è, allora sai perché ASF non può accedere a questo. Se lo fa, e lo stesso errore non va via dopo un giorno o due, potrebbe essere utile indagare e riportare.

Prima di farlo dovresti assicurarti che **l'errore valga la pena segnalare in primo luogo**. Se è menzionato in questa FAQ, come il problema relativo al trading, allora è fuori. Se è un problema temporaneo che è accaduto una o due volte, soprattutto quando la rete era instabile o Steam era giù - questo è fuori. Tuttavia, se siete stati in grado di riprodurre il vostro problema più volte di fila, in 2 giorni, riavviato ASF così come la vostra macchina nel processo e fatto in modo che non ci sia alcuna voce FAQ qui per aiutare a risolverlo, allora vale la pena di chiedere.

---

### ASF sembra congelare e non stampare nulla sulla console fino a quando non premere un tasto!

Probabilmente stai usando Windows e la console è abilitata la modalità QuickEdit. Fare riferimento a **[questa domanda](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** su StackOverflow per una spiegazione tecnica. È necessario disabilitare la modalità di modifica rapida facendo clic con il pulsante destro della finestra della console ASF, aprendo le proprietà e deselezionando la casella di controllo appropriata.

---

### ASF non può accettare o inviare commerci!

Evidentemente prima cosa - i nuovi account iniziano come limitati. Fino a quando non sblocchi l'account caricando il suo portafoglio o spendendo $5 nel negozio, ASF non può accettare né inviare scambi utilizzando questo account. In questo caso, ASF dichiarerà che l'inventario sembra vuoto, perché ogni carta che si trova in esso non è negoziabile.

Successivamente, se non si utilizza **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, è possibile che ASF abbia effettivamente accettato/inviato il commercio, ma è necessario confermarlo via e-mail. Allo stesso modo, se si utilizza 2FA classico, è necessario confermare il commercio tramite il vostro autenticatore. Le conferme sono **obbligatorie** ora, quindi se non vuoi accettarle da solo, considera di importare il tuo autenticatore in ASF 2FA.

Notate anche che è possibile commerciare solo con i vostri amici, e persone con noto link commerciale. Se stai cercando di avviare il trading *Bot -> Master* , come `loot`, allora devi avere il tuo bot nella tua lista di amicizia, o la tua `SteamTradeToken` dichiarata nella configurazione di Bot. Assicurati che il token sia valido - altrimenti, non sarai in grado di inviare un'operazione.

Infine, ricordate che i nuovi dispositivi hanno 7 giorni di blocco commerciale, quindi se avete appena aggiunto il vostro account a ASF, attendere almeno 7 giorni - tutto dovrebbe funzionare dopo quel periodo. Tale limitazione include **sia** che accettano **e** l'invio di operazioni. Non sempre si innesca, e ci sono persone che possono inviare e accettare scambi istantaneamente. Majority of the people are affected though, and the lock **will** happen, even if you can send and accept trades through your steam client on the same machine. Basta aspettare pazientemente, non c'è nulla che puoi fare per renderlo più veloce. Allo stesso modo, si può ottenere un blocco simile per la rimozione / modifica di varie impostazioni di sicurezza di Steam, come 2FA, SteamGuard, password, e-mail e simili. In generale, controllare se è possibile inviare un commercio da quel account da soli, se sì, molto probabilmente è classico 7 giorni di blocco dal nuovo dispositivo.

E infine, tenere a mente che un account può avere solo 5 scambi in attesa di un altro, in modo da ASF non sarà possibile inviare scambi se si dispone di 5 (o più) in attesa di quelli da quel bot per accettare già. Questo è raramente un problema, ma vale anche la pena di menzionare, soprattutto se si imposta ASF per inviare automaticamente le operazioni, ma non stai usando ASF 2FA e hai dimenticato di confermarli.

Se non c'è niente di utile, puoi sempre abilitare la modalità di debug `` e verificare tu stesso perché le richieste stanno fallendo. Si prega di notare che Steam parla sciocchezze la maggior parte del tempo, e la ragione fornita non può avere alcun senso logico, o può essere anche del tutto errato - se si decide di interpretare quella ragione, assicurarsi di avere una conoscenza decente di Steam e le sue stranezze. E 'anche abbastanza comune vedere quel problema senza alcuna ragione logica, e l'unica soluzione suggerita in questo caso è quella di ri-aggiungere account a ASF (e attendere 7 giorni di nuovo). A volte questo problema si risolve anche *magicamente*, allo stesso modo in cui si rompe. Tuttavia, di solito è solo 7 giorni serratura di scambio, problema di vapore temporaneo, o entrambi. È meglio dargli qualche giorno prima di controllare manualmente cosa è sbagliato, a meno che non si dispone di un certo bisogno di debug la causa reale (e di solito sarete costretti ad aspettare comunque, perché il messaggio di errore non ha alcun senso, né ti aiuta minimamente).

In ogni caso, ASF può solo **provare** per inviare una richiesta adeguata a Steam al fine di accettare/inviare il commercio. Che Steam accetti o meno tale richiesta, è fuori dal campo di applicazione di ASF, e ASF non lo farà magicamente funzionare. Non c'è nessun bug relativo a quella funzione, e non c'è anche nulla da migliorare, perché la logica sta accadendo al di fuori di ASF. Pertanto, non chiedere di fissare roba che non è rotto, e anche non chiedere perché ASF non può accettare o inviare scambi - **Non lo so, e ASF non conosce né**. O affrontarlo, o ripararsi, se si conosce meglio.

---

### Perché devo inserire il codice 2FA/SteamGuard ad ogni login? / *Rimosso la chiave di accesso scaduta*

ASF utilizza le chiavi di accesso (se hai mantenuto abilitata `UseLoginKeys` per mantenere valide le credenziali, lo stesso meccanismo utilizzato da Steam - token 2FA/SteamGuard è richiesto una sola volta. Tuttavia, a causa di problemi e stranezze di rete di Steam, è del tutto possibile che la chiave di accesso non venga salvata nella rete, abbiamo già visto tali problemi non solo con ASF, ma anche con client di vapore normale (una necessità di inserire login + password per ogni esecuzione, indipendentemente dall'opzione "ricordami").

Puoi rimuovere `BotName.db` e `BotName. in` (se disponibile) dell'account interessato e prova a collegare ASF al tuo account ancora una volta, ma probabilmente non farà nulla. Alcuni utenti hanno segnalato che **[deautorizzazione di tutti i dispositivi](https://store.steampowered.com/twofactor/manage)** sul lato di Steam dovrebbe aiutare, la modifica della password farà lo stesso. Tuttavia, questi sono solo workaround che non sono nemmeno garantiti per lavorare, la vera soluzione basata su ASF è importare il tuo autenticatore come **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** - in questo modo ASF può generare automaticamente i token quando sono necessari, e non è necessario inserirli manualmente. Di solito il problema si risolve magicamente dopo un po 'di tempo, quindi si può semplicemente aspettare che questo accada. Naturalmente è anche possibile chiedere Valve per la soluzione, perché non posso costringere la rete di Steam ad accettare le nostre chiavi di accesso.

Come nota collaterale, puoi anche disattivare le chiavi di accesso con `UseLoginKeys` config property set to `false`, ma questo non risolverà il problema, salta solo il fallimento della chiave di accesso iniziale. ASF è già a conoscenza del problema spiegato qui e farà del suo meglio per non utilizzare le chiavi di accesso se può garantirsi tutte le credenziali di accesso, quindi non c'è bisogno di modificare manualmente `UseLoginKeys` se è possibile fornire tutti i dettagli di accesso insieme con ASF 2FA.

---

### Sto ottenendo errore: *Impossibile effettuare il login su Steam: `InvalidPassword` o `RateLimitExceeded`*

Questo errore può significare molte cose, alcune delle quali includono:

- Combinazione Login/Password non valida (ovviamente)
- Chiave di accesso scaduta utilizzata da ASF per accedere
- Troppi tentativi di accesso falliti in breve periodo di tempo (anti-bruteforce)
- Troppi tentativi di accesso in breve periodo di tempo (limitazione della velocità)
- Obbligo di accesso alla captcha (molto probabilmente causato da due motivi sopra)
- Qualsiasi altra ragione che la rete di Steam potrebbe aver impedito l'accesso

In caso di anti-bruteforce e di limitazione dei tassi, il problema scomparirà dopo un po 'di tempo, quindi basta aspettare e non tentare di accedere nel frattempo. Se si preme questo problema frequentemente, forse è saggio aumentare la proprietà di configurazione `LoginLimiterDelay` di ASF. Un eccessivo riavvio del programma e altre richieste di login intenzionali/non intenzionali sicuramente non aiuteranno con questo problema, quindi cercare di evitarlo, se possibile.

In caso di chiave di accesso scaduta - ASF rimuoverà uno vecchio e ne chiederà uno nuovo al prossimo login (che richiederà di inserire il token 2FA se il tuo account è protetto da 2FA-. Se il tuo account utilizza ASF 2FA, il token verrà generato e utilizzato automaticamente). Questo può naturalmente accadere nel tempo, ma se si ottiene questo problema su ogni accesso, è possibile che Steam per qualche motivo abbia deciso di ignorare le nostre richieste di salvataggio della chiave di accesso, come indicato nel numero **[sopra](#why-do-i-have-to-put-2fasteamguard-code-on-each-login--removed-expired-login-key)**. Ovviamente puoi disabilitare completamente `UseLoginKeys` , ma che non risolverà il problema, solo evitare la necessità di rimuovere le chiavi di accesso scadute ogni volta. La vera soluzione, come per la questione di cui sopra, è quella di utilizzare ASF 2FA.

E infine, se hai usato la combinazione di login + password sbagliata, ovviamente devi correggere questo, o disabilitare il bot che sta tentando di connettersi utilizzando quelle credenziali. ASF non può indovinare da solo se `InvalidPassword` significa credenziali non valide, o uno dei motivi sopra elencati, quindi continuerà a provare fino a quando non ha successo.

Tenete a mente che ASF ha un proprio sistema incorporato per reagire di conseguenza alle stranezze di vapore, alla fine si collegherà e riprenderà il suo lavoro, quindi non è necessario fare nulla se il problema è temporaneo. Riavviare ASF al fine di risolvere magicamente i problemi solo peggiorare le cose (come il nuovo ASF non saprà precedente stato di ASF di non essere in grado di accedere, e cercare di connettersi invece di aspettare), in modo da evitare di farlo a meno che non sai cosa stai facendo.

Infine, come per ogni richiesta di Steam - ASF può solo **provare** per accedere, utilizzando le credenziali fornite. Se tale richiesta avrà successo o meno è fuori dalla portata e dalla logica di ASF - non c'è alcun bug, e nulla può essere risolto né migliorato a questo proposito.

---

### Non posso inserire i dettagli di accesso che ASF sta chiedendo
### `System.InvalidOperationException: Impossibile leggere le chiavi quando entrambe le applicazioni non hanno una console o quando l'input della console è stato reindirizzato`
### `System.IO.IOException: Input/output error`
### `RequestInput() non è valido!`

Se questo errore si è verificato durante l'input di ASF (es. puoi vedere `GetUserInput()` nello stacktrace) quindi è causato dal tuo ambiente che vieta a ASF di leggere input standard della tua console. Questo può accadere a causa di molte ragioni, ma quello più comune è che si esegue ASF nell'ambiente sbagliato (ad es. in `systemd`, `nohup` o `&` in background invece di e. . `schermo` su Linux). Se ASF non può accedere al suo input standard, vedrai questo errore registrato e l'incapacità di ASF di utilizzare i tuoi dati durante il runtime.

Normalmente è necessario correggere il problema di cui sopra, cioè consentire a ASF di accedere a input standard in modo da poter fornire i dettagli. Tuttavia, se **ti aspetti che** accada, così **intendi** eseguire ASF in un ambiente senza input, allora dovresti dire esplicitamente a ASF che è il caso, impostando in modo appropriato la modalità **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)**. Questo dirà a ASF di non chiedere mai l'input dell'utente in nessuna circostanza, consentendo di eseguire ASF in ambienti senza input in modo sicuro. È possibile rispondere alle richieste di input selezionate con altri mezzi in questa modalità, ad esempio in ASF-ui.

---

### `System.Net.Http.WinHttpException: Si è verificato un errore di sicurezza`

Questo errore si verifica quando ASF non riesce a stabilire una connessione sicura con un determinato server, quasi esclusivamente a causa della sfiducia nel certificato SSL.

In quasi tutti i casi questo errore è causato da **data / ora errata sulla tua macchina**. Ogni certificato SSL ha emesso data e data di scadenza. Se la tua data non è valida e fuori da questi due limiti, il certificato non può essere fidato a causa di un potenziale attacco **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)** e ASF rifiuta di effettuare una connessione.

La soluzione ovvia è quella di impostare la data sulla vostra macchina in modo appropriato. Si consiglia vivamente di utilizzare la sincronizzazione automatica della data, come la sincronizzazione nativa disponibile su Windows, o `ntpd` su Linux.

Se avete fatto in modo che la data sulla vostra macchina è appropriata e l'errore non vuole andare via, Certificati SSL che i tuoi trust di sistema potrebbero essere obsoleti o non validi. In questo caso dovresti assicurarti che la tua macchina possa stabilire connessioni sicure, ad esempio controllando se puoi accedere a `https://github. om` con qualsiasi browser a tua scelta, o strumento CLI come `curl`. Se avete confermato che questo funziona correttamente, sentitevi liberi di chiederci il sostegno.

---

### `System.Threading.Tasks.TaskCanceledException: Un'attività è stata annullata`

Questo avvertimento significa che Steam non ha risposto alla richiesta di ASF in un dato momento. Di solito è causato da singhiozzi di rete Steam e non influenza ASF in alcun modo. In altri casi è la stessa richiesta fallendo dopo 5 prove. Segnalare questo problema non ha senso la maggior parte del tempo, in quanto non possiamo costringere Steam a rispondere alle nostre richieste.

---

### `Il tipo inizializzatore per 'System.Security.Cryptography.CngKeyLite' ha lanciato un'eccezione`

Questo problema è quasi esclusivamente causato da disabilitato/interrotto `Isolamento chiavi CNG` servizio Windows, che fornisce funzionalità di crittografia di base per ASF, senza la quale il programma non è in grado di eseguire. Puoi risolvere questo problema avviando i servizi `. sc` e assicurando che il servizio di Windows `CNG Key Isolation` non abbia disabilitato l'avvio ed è attualmente in esecuzione.

---

### ASF viene rilevato come malware dal mio AntiVirus! Cosa sta succedendo?

**Assicurati di aver scaricato ASF dalla fonte affidabile**. L'unica fonte ufficiale e affidabile è **[ASF rilascia la pagina](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** su GitHub (e questa è anche la fonte per gli aggiornamenti automatici di ASF) - **qualsiasi altra fonte non è attendibile per definizione e può contenere malware aggiunti da altre persone** - non dovresti fidarti di qualsiasi altra posizione di download, assicurati che la tua ASF venga sempre da noi.

Se hai confermato che ASF è scaricato da una fonte affidabile, molto probabilmente è semplicemente un falso positivo. Questo **è accaduto in passato**, **sta accadendo in questo momento**e **accadrà in futuro**. Se siete preoccupati per la sicurezza reale quando si utilizza ASF, allora suggerisco di scansionare ASF con molti AVs diversi per il rapporto di rilevamento effettivo, ad esempio attraverso **[VirusTotal](https://www.virustotal.com)** (o qualsiasi altro servizio web di tua scelta come questo).

Se l'AV che stai usando falsa rileva ASF come un malware, poi **è una buona idea inviare questo esempio di file agli sviluppatori del tuo AV, in modo che possano analizzarlo e migliorare il loro motore di rilevamento**, come chiaramente non funziona bene come si crede. Non c'è nessun problema nel codice ASF e non c'è anche nulla da risolvere per noi, dal momento che non stiamo distribuendo malware in primo luogo, quindi non ha senso riferire a noi quei falsi positivi. Si consiglia vivamente di inviare il campione di ASF per ulteriori analisi come indicato sopra, ma se non si desidera preoccuparsi con esso, allora è sempre possibile aggiungere ASF ad alcuni tipi di eccezioni AV, disabilitare il vostro AV o semplicemente utilizzare un altro. Purtroppo, siamo abituati ad AVs essere stupidi, come ogni volta ogni tanto alcuni AV rileva ASF come un virus, che di solito dura molto breve e viene patch in fretta dagli sviluppatori, ma come abbiamo sottolineato sopra - **è successo**, **succede** e **succederà** continuamente. ASF non include alcun codice dannoso, è possibile rivedere il codice ASF e anche compilare dal sorgente da soli. Non siamo hacker per offuscare il codice ASF per nasconderci dalle euristiche AV e dai falsi positivi, quindi non aspettatevi da noi di fissare quello che non è rotto - non c'è alcun "virus" per noi da riparare.