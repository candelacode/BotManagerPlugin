# Prestazioni

L’obiettivo primario della ASF è quello di coltivare nel modo più efficace possibile, sulla base di due tipi di dati su cui può operare: una piccola serie di dati forniti dall'utente che è impossibile per ASF indovinare/controllare da sola, e un insieme più ampio di dati che possono essere automaticamente controllati da ASF.

In modalità automatica, ASF non consente di scegliere i giochi che dovrebbero essere coltivati, né consente di cambiare algoritmo di allevamento carte. **ASF sa meglio di voi cosa dovrebbe fare e quali decisioni dovrebbe prendere per coltivare il più velocemente possibile**. Il tuo obiettivo è quello di impostare le proprietà di configurazione correttamente, poiché ASF non può indovinarle da solo, tutto il resto è coperto.

---

Qualche tempo fa Valve ha cambiato l'algoritmo per le gocce di carta. Da quel punto in poi, possiamo categorizzare account vapore per due categorie: quelli **con** gocce di carta limitate, e quelli **senza**. L'unica differenza tra questi due tipi è il fatto che gli account con gocce di carte limitate non possono ottenere alcuna carta da un determinato gioco fino a quando non giocano dato per almeno `X` ore. Sembra che gli account più vecchi che non hanno mai chiesto il rimborso abbiano gocce di carta **senza restrizioni**, mentre i nuovi account e coloro che hanno chiesto il rimborso hanno **carte limitate gocce**. Questa è però solo teoria, e non dovrebbe essere considerata come una regola. Ecco perché non c'è una risposta chiara ****, e ASF si basa su **tu** dicendogli quale caso è appropriato per il tuo account.

---

ASF attualmente comprende due algoritmi di allevamento:

**`Semplice algoritmo`** funziona meglio per gli account che hanno gocce di carte senza restrizioni. Questo è algoritmo primario usato da ASF. Il bot trova giochi in fattoria, e li alleva uno per uno fino a quando tutte le carte sono cadute. Questo perché il tasso di caduta della carta quando l'agricoltura di più di una partita è vicino a zero e totalmente inefficace.

**`Complex`** è un nuovo algoritmo che è stato implementato per aiutare gli account limitati per massimizzare i loro profitti. ASF utilizzerà in primo luogo l'algoritmo **`Simple`** standard su tutti i giochi che hanno superato le ore `HoursUntilCardDrops` del tempo di gioco, poi, se non ci sono partite con >= `OrariUntilCardDrops` ore rimaste, contatterà tutti i giochi (fino a `32` limite) con < `Ore UntilCardDrops` ore lasciate contemporaneamente, fino a quando uno di loro colpisce `Ore UntilCardDrops` ore di marca, poi ASF continuerà il ciclo dall'inizio (usa **`Simple`** in quel gioco, torna simultaneamente su < `Ore di UntilCardDrops` e così via). Possiamo utilizzare più giochi di agricoltura in questo caso per le ore di pompaggio dei giochi che abbiamo bisogno di allevare per valore appropriato in primo luogo. Tenete a mente che durante le ore di allevamento, ASF **non** schede aziendali, in modo che anche non controllare per le gocce di carta durante quel periodo (per i motivi sopra indicati).

Attualmente, ASF sceglie un algoritmo di allevamento delle carte basato esclusivamente sulla proprietà di configurazione `HoursUntilCardDrops` (che è impostata da **you**). Se `HoursUntilCardDrops` è impostato su `0`, **L'algoritmo`Simple`** sarà utilizzato, altrimenti, **`L'algoritmo Complesso`** verrà invece utilizzato - configurato per sbalzare il tempo di gioco in tutte le partite per una data quantità di ore prima di coltivarli per le gocce di carte.

---

### **Non c'è una risposta ovvia quale algoritmo è migliore per te**.

Questo è uno dei motivi per cui non si sceglie l'algoritmo di allevamento delle carte, invece, si dice a ASF se l'account ha gocce limitate o meno. If account has non-restricted drops, **`Simple`** algorithm will **work better** on that account, as we won't be wasting time on bringing all games to `X` hours - cards drop ratio is close to 0% when farming multiple games. D'altra parte, se il tuo account ha gocce di carta limitate, L'algoritmo **`Complesso`** sarà migliore per te, dato che non c'è nessun punto nel solo contadino se la partita non ha ancora raggiunto la `OreUntilCardDrops` ore - così faremo il tempo di gioco **** prima, **poi** carte in modalità solista.

Non impostare ciecamente `HoursUntilCardDrops` solo perché qualcuno ti ha detto - fare test, confrontare i risultati, e in base ai dati ottenuti, decidere quale opzione dovrebbe essere migliore per voi. Se si mette un po 'di sforzo minimo, ti assicurerai che ASF sta lavorando con la massima efficienza possibile per il tuo account, che è probabilmente quello che vuoi, considerando che stai leggendo questa pagina wiki in questo momento. Se ci fosse una soluzione che funziona per tutti, non ti sarebbe stata data una scelta - ASF sarebbe decidere se stesso.

---

### Qual è il modo migliore per scoprire se il tuo account è limitato?

Assicurati di avere alcune partite con **nessun tempo di gioco registrato** per la fattoria, preferibilmente 5+, ed esegui ASF con `HoursUntilCardDrops` di `0`. Sarebbe una buona idea se non si gioca nulla durante il periodo agricolo per risultati più accurati (meglio gestire ASF durante la notte). Lasciate ASF fattoria quei 5 giochi, e dopo che controllare il registro per i risultati.

ASF indica chiaramente quando è stata eliminata una carta per un determinato gioco. Sei interessato al calo più veloce della carta raggiunto da ASF. Ad esempio, se il tuo account è illimitato, una prima goccia di carta dovrebbe accadere dopo circa 30 minuti da quando hai iniziato l'agricoltura. Se noti **almeno un gioco** che ha fatto cadere carta in quei primi 30 minuti, allora questo è un indicatore che il tuo account è **non** limitato e dovrebbe utilizzare `HoursUntilCardDrops` di `0`.

D'altra parte, se noti che **ogni gioco** sta prendendo almeno `X` quantità di ore prima che scenda la sua prima carta, allora questo è un indicatore per voi quello che dovreste impostare `Ore UntilCardDrops` a. La maggioranza (se non tutti) degli utenti con restrizioni richiede almeno `3` ore di tempo di gioco per lasciare le carte, e questo è anche il valore predefinito per l'impostazione `HoursUntilCardDrops`.

Ricorda che i giochi possono avere diverso tasso di caduta, questo è il motivo per cui dovresti verificare se la tua teoria è corretta con **almeno** 3 giochi, preferibilmente 5+ per assicurarsi di non correre in risultati falsi da una coincidenza. Una goccia di carta di un gioco in meno di un'ora è la conferma che il tuo account **non è** limitato e può utilizzare `Ore UntilCardDrops` di `0`, ma per confermare che il tuo account **è** limitato, hai bisogno di almeno parecchi giochi che non stanno rilasciando carte fino a quando non si colpisce un segno fisso.

È importante notare che in passato `HoursUntilCardDrops` era solo `0` o `2`, ed è per questo che ASF aveva una singola proprietà `CardDropsRestricted` che ha permesso di passare da questi due valori. Con i recenti cambiamenti abbiamo notato che non solo la maggior parte degli utenti richiede ora `3` ore al posto del precedente `2` , ma anche che `HoursUntilCardDrops` è ora dinamico e può colpire qualsiasi valore su base per account.

Alla fine, naturalmente, la decisione spetta a voi.

E per renderlo ancora peggiore - ho sperimentato casi in cui la gente è passata da stato limitato a stato illimitato e viceversa - o a causa di Steam bug (oh sì, abbiamo molti di quelli), o a causa di alcune modifiche logiche da parte di Valve. Quindi, anche se hai confermato che il tuo account è limitato (o meno), non credete che rimarrà così - per passare da illimitato a limitato è sufficiente chiedere un rimborso. Se si ritiene che il valore impostato in precedenza non sia più appropriato, è sempre possibile eseguire un nuovo test e aggiornarlo di conseguenza.

---

Per impostazione predefinita, ASF assume che `HoursUntilCardDrops` è `3`, come l'effetto negativo di impostare questo a `3` quando dovrebbe essere minore è più piccolo di quello fatto in altro modo. Questo perché, nel peggiore dei casi, sprecheremo `3` ore di agricoltura per `32` giochi, rispetto allo spreco di `3` ore di allevamento per ogni singola partita se `OraUntilCardDrops` è stato impostato su `0` per impostazione predefinita. Tuttavia, si dovrebbe ancora sintonizzare questa variabile per abbinare il tuo account per la massima efficienza, poiché si tratta solo di un'ipotesi cieca basata su potenziali inconvenienti e la maggior parte degli utenti (quindi stiamo cercando di scegliere "male minore" per impostazione predefinita).

Al momento due algoritmi di cui sopra sono sufficienti per tutti gli attuali scenari di conto, al fine di coltivare nel modo più efficace possibile, quindi non è previsto di aggiungerne altri.

È bello notare che ASF include anche la modalità di allevamento manuale che può essere attivata dal comando `play`. Puoi saperne di più su di esso nei comandi **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

## Guasti al vapore

Algoritmo di goccia di carte non sempre funziona come dovrebbe, ed è completamente possibile per vari problemi di vapore accadere, come le carte che vengono lasciate su account ristretti, le carte che vengono lasciate cadere alla chiusura/commutazione del gioco, carte che non cadono affatto quando il gioco è in fase di gioco, e allo stesso modo.

Questa sezione è principalmente per le persone che si chiedono perché ASF non fa **X**, come il rapido passaggio dei giochi alle carte aziendali più velocemente.

Che cosa è un **Vapore glitch** - un'azione specifica che innesca il comportamento **non definito** , che è **non intenzionato, non documentato, e considerato come un difetto di logica**. È **inaffidabile per definizione**, il che significa che non può essere riprodotto in modo affidabile con un ambiente di test pulito, e quindi, codificato senza ricorrere a hack che si suppone di indovinare quando il problema sta accadendo e come combattere con esso / abusare. In genere è temporaneo fino a quando gli sviluppatori correggono il difetto di logica, anche se alcuni difetti diversi possono passare inosservati per un periodo di tempo molto lungo.

Un buon esempio di ciò che è considerato **Steam glitch** non è la situazione rara di rilasciare una carta quando il gioco viene chiuso, che può essere abusato in qualche misura con la funzione di salto di gioco del maestro inattivo.

- **Comportamento indefinito** - non puoi dire se ci saranno 0 o 1 carte cadute quando si attiva il glitch.
- **Not intended** - basato sull'esperienza e sul comportamento passati della rete Steam che non si traduce nello stesso comportamento quando si invia una singola richiesta.
- **Undocumented** - è chiaramente documentato sul sito web di Steam come si ottengono le carte, e **in ogni singolo posto** è chiaramente dichiarato che è ottenuto attraverso **giocando**, NON chiudendo giochi, ottenendo risultati, giochi di commutazione o lanciando 32 giochi contemporaneamente.
- **Considerato come un difetto di logica** - la chiusura dei giochi o la loro commutazione non dovrebbe avere alcun risultato sulle carte che vengono lasciate cadere che sono chiaramente indicate per essere ottenute attraverso **guadagnando tempo di gioco**.
- **Inaffidabile per definizione, non può essere riprodotto in modo affidabile** - non funziona per tutti, e anche se ha funzionato per voi una volta, non poteva più funzionare per la seconda volta.

Ora una volta che abbiamo capito che cosa è il glitch di Steam, e il fatto che le carte vengono lasciate cadere quando il gioco viene chiuso **è** , possiamo passare al secondo punto - **ASF non è abusare della rete Steam in alcun modo per definizione, e sta facendo del suo meglio per conformarsi a Steam ToS, ai suoi protocolli e a ciò che è generalmente accettato**. Spamming Steam network with constant game opening/closing requests can be considered a **[DoS attack](https://en.wikipedia.org/wiki/Denial-of-service_attack)** and **directly viola [Steam Online Conduct](https://store.steampowered.com/online_conduct/?l=english)**.

> Come abbonato a Steam accetti di rispettare le seguenti regole di condotta.
> 
> Non lo farete:
> 
> L'istituto attacca su un server Steam o altrimenti interrompe Steam.

Non importa se sei in grado di attivare il glitch di Steam con altri programmi (come IM), e non importa se si è d'accordo con noi e considerare un tale comportamento come attacco DoS, o non - spetta a Valve giudicare questo, ma se lo consideriamo come sfruttare/abusare di comportamenti non intenzionati attraverso richieste eccessive di rete di Steam, allora si può essere abbastanza sicuri che Valve avrà una vista simile su questo.

ASF è **mai** che approfitterà degli exploit di Steam, degli abusi, hacks o qualsiasi altra attività che vediamo come **illegale o indesiderato** secondo Steam ToS, Steam Online Conduct o qualsiasi altra fonte di fiducia che potrebbe indicare che l'attività di ASF è indesiderata dalla rete di Steam, come indicato nella sezione **[del contributo](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)**.

Se si desidera a tutti i costi per rischiare il vostro account Steam per l'agricoltura di pochi centesimi carte più velocemente del solito, poi tristemente ASF non offrirà mai qualcosa di simile in modalità automatica, anche se hai ancora il comando `play` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** che può essere utilizzato come strumento per fare quello che vuoi in termini di interazione di rete Steam. Non consigliamo di approfittare di problemi di vapore e sfruttarli per il proprio guadagno - non solo con ASF, ma con qualsiasi altro strumento pure. Alla fine, però, è il tuo account, e la vostra scelta che cosa volete fare con esso - basta tenere a mente che abbiamo avvertito voi.