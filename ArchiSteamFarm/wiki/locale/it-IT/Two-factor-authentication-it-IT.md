# Autenticazione due fattori

Steam include il sistema di autenticazione a due fattori che richiede dettagli aggiuntivi per le varie attività relative al conto. Puoi saperne di più **[qui](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** e **[qui](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. Questa pagina ritiene che il sistema 2FA così come la nostra soluzione che si integra con esso, chiamato ASF 2FA.

---

# Logica ASF

Indipendentemente dal fatto che si utilizzi o meno ASF 2FA, ASF include una logica adeguata ed è pienamente consapevole degli account protetti da 2FA su Steam. Ti chiederà i dettagli richiesti quando sono necessari (come durante il login). Mentre è possibile fornire manualmente tali informazioni, alcune funzionalità ASF (come `MatchActively`) richiedono che ASF 2FA sia operativo sul tuo account bot, che può rispondere automaticamente ai suggerimenti 2FA, automaticamente, quando richiesto da ASF.

---

# ASF 2FA

ASF 2FA è un modulo integrato responsabile di fornire funzionalità 2FA al processo ASF, come generare token e accettare conferme. Può funzionare sia in modalità standalone, o duplicando i dettagli dell'autenticatore esistente (in modo da poter utilizzare l'autenticatore corrente e ASF 2FA allo stesso tempo).

Puoi verificare se il tuo account bot utilizza già ASF 2FA eseguendo i comandi `2fa` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Senza impostare ASF 2FA, tutti i comandi standard `2fa` non saranno operativi, il che significa che il tuo bot non è disponibile per le funzioni avanzate di ASF che richiedono che il modulo sia operativo.

---

# Raccomandazioni

Ci sono molti modi per rendere operativo ASF 2FA, qui includiamo le nostre raccomandazioni in base alla tua situazione attuale:

- Se stai già utilizzando un'applicazione non ufficiale di terze parti che ti permette di estrarre i dettagli 2FA con facilità, basta importare **[](#import)** quelli in ASF.
- Se stai usando l'app ufficiale e non ti dispiace reimpostare le tue credenziali 2FA, il modo migliore è disabilitare 2FA, then **[create](#creation)** new 2FA credentials using **[joint authenticator](#joint-authenticator)**, che vi permetterà di utilizzare l'app ufficiale e ASF 2FA. Questo metodo **non richiede root**, jailbreaking o qualsiasi conoscenza avanzata, a malapena seguendo le istruzioni qui scritte, ed è probabilmente superiore per questo scenario.
- Se stai usando l'app ufficiale e non vuoi ricreare le tue credenziali 2FA, le tue opzioni sono molto limitate, tipicamente avrai bisogno di root e di agganciamento extra per importare **[](#import)** quei dettagli, e anche con questo potrebbe essere impossibile.
- Se non stai ancora usando 2FA e non importa, ti consigliamo di utilizzare ASF 2FA con l'autenticatore **[standalone](#standalone-authenticator)** o **[con l'autenticatore congiunto](#joint-authenticator)** con l'app ufficiale (stesso come sopra).

Di seguito discutiamo tutte le opzioni possibili e conosciamo i metodi.

---

## Creazione

ASF viene fornito con un ufficiale `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** che estende ulteriormente ASF 2FA, consente di collegare un autenticatore 2FA completamente nuovo. Questo può essere utile nel caso in cui non sei in grado o non vuoi usare altri strumenti e non ti dispiace che ASF 2FA diventi il tuo principale (e forse solo) autenticatore. Il processo di creazione è utilizzato anche nel metodo joint-authenticator, naturalmente in questo scenario il vostro autenticatore può coesistere in due punti in una sola volta - entrambi genereranno gli stessi codici ed entrambi saranno in grado di confermare le stesse conferme.

### Passi comuni per entrambi gli scenari

Non importa se si prevede di utilizzare ASF come autenticatore autonomo o congiunto, è necessario eseguire questi passaggi di inizializzazione:

1. Crea un bot ASF per l'account di destinazione, avvialo e accedi, che probabilmente hai già fatto.
2. Assegna un numero di telefono funzionante e operativo all'account **[qui](https://store.steampowered.com/phone/manage)** da utilizzare dal bot. Questo vi permetterà di ricevere codice SMS e consentire il recupero, se necessario. Questo passaggio non è obbligatorio in tutti gli scenari, tuttavia, lo consigliamo a meno che non sai cosa stai facendo.
3. Assicurati di non usare ancora 2FA per il tuo account, se lo fai, disabilitalo prima. Questo **sarà** mettere il tuo account in attesa di scambio temporaneo, non c'è modo di aggirarlo, solo il processo **[import](#import)** può saltarlo.
4. Esegui il comando `2fainit [Bot]` , sostituendo `[Bot]` con il nome del tuo bot.

Supponendo di ottenere una risposta di successo, le seguenti due cose sono successe:

- Un nuovo file `<Bot>.maFile.PENDING` è stato generato da ASF nella tua directory `di configurazione`.
- Gli SMS sono stati inviati da Steam al numero di telefono assegnato per l'account qui sopra. Se non hai impostato un numero di telefono, una email è stata inviata invece all'indirizzo e-mail dell'account.

I dettagli dell'autenticatore non sono ancora operativi, tuttavia, è possibile rivedere il file generato se si desidera. Se vuoi essere doppio sicuro, per esempio, puoi già scrivere il codice di revoca. I prossimi passi dipenderanno dallo scenario selezionato.

### Autenticatore indipendente

Se si desidera utilizzare ASF come autenticatore principale (o anche solo) ora è necessario eseguire la fase finale di finalizzazione:

5. Esegui il comando `2fafinalize [Bot] <ActivationCode>` , sostituendo `[Bot]` con il nome del bot e `<ActivationCode>` con il codice ricevuto tramite SMS o e-mail nel passaggio precedente.

### Autenticatore congiunto

Se vuoi avere lo stesso autenticatore sia in ASF che nell'app mobile ufficiale di Steam, ora è necessario fare i passi successivi, più complicati:

5. **Ignora** il codice SMS o e-mail che hai ricevuto nel passaggio precedente.
6. Installare l'applicazione mobile di Steam se non è ancora installata e aprirla. Naviga nella scheda Steam Guard e aggiungi un nuovo autenticatore seguendo le istruzioni dell'app.
7. Dopo che l'autenticatore nell'app mobile è stato aggiunto e funzionante, torna a ASF. Ora, invece di finalizzare, abbiamo solo bisogno di informare ASF che app mobile già attivato i nostri dettagli precedentemente generati:
 - Attendere che il prossimo codice 2FA sia mostrato nell'app mobile di Steam, e utilizza il comando `2fafinalized [Bot] <2FACodeFromApp>` sostituendo `[Bot]` con il nome del bot e `<2FACodeFromApp>` con il codice che vedi attualmente nell'app mobile di Steam - lo stesso che usi per accedere a Steam (**NON** quello che hai già usato per l'attivazione). Se il codice generato da ASF e il codice fornito sono uguali, ASF supporrà che un autenticatore sia stato aggiunto correttamente e procedere con l'importazione del nuovo autenticatore creato.
 - Raccomandiamo vivamente di fare quanto sopra al fine di garantire che le tue credenziali siano valide. Tuttavia, se non vuoi (o non puoi) controllare se i codici sono gli stessi e sai cosa stai facendo, puoi invece usare il comando `2fafinalizedforce [Bot]`, sostituendo `[Bot]` con il nome del tuo bot. ASF supporrà che l'autenticatore sia stato aggiunto correttamente e procedere con l'importazione dell'autenticatore appena creato. Tieni presente che in questa modalità ASF non è in grado di verificare se i codici corrispondono, che significa che è possibile importare credenziali non valide (non attivate).

### Dopo la finalizzazione

Supponendo che tutto funzionasse correttamente, il file `<Bot>.maFile.PENDING` precedentemente generato è stato rinominato `<Bot>.maFile.NEW`. Questo indica che le tue credenziali 2FA sono ora valide e attive. Si consiglia di spostare il file al di fuori della directory `config` e **memorizzarlo in una posizione sicura**. In aggiunta a questo, se hai deciso di utilizzare l'autenticatore standalone, poi vi consigliamo di aprire il file nel vostro editor di scelta e scrivere il `revocation_code`, che ti permetterà, come suggerisce il nome, di revocare l'autenticatore in caso di perdita. Nel metodo joint-authenticator, dovresti già farlo nell'app mobile di Steam, ma sentiti libero di fare lo stesso nel caso in cui fosse necessario.

In regards to technical details, the generated `maFile` includes all details that we've received from the Steam server during linking the authenticator, and in addition to that, the `device_id` field, which may be needed for other (third-party) authenticators, if you ever decide to import that `maFile` into them.

ASF importa automaticamente il tuo autenticatore una volta terminata la procedura, e quindi `2fa` e altri comandi correlati dovrebbero ora essere operativi per l'account bot a cui hai collegato l'autenticatore. Ti consigliamo di verificarlo.

---

## Importa

Il processo di importazione richiede autenticatore già collegato e operativo supportato da ASF. Abbiamo istruzioni per alcune diverse fonti ufficiali e non ufficiali di 2FA, in aggiunta al metodo manuale che consente di fornire le credenziali richieste da soli. Si prega di notare che queste istruzioni dovrebbero essere utilizzate **solo** se si sta già utilizzando una determinata soluzione - poiché il processo qui coinvolge applicazioni e strumenti di terze parti, **non consigliamo di utilizzarli**, e lo stiamo menzionando esclusivamente per le persone che hanno già deciso di usarli e vorremmo importare i dettagli generati in ASF 2FA.

In generale, il processo di importazione comporta il rilascio di `maFile` in un formato appropriato alla directory `di ASF config` , su cui ASF raccoglierà quel file e lo rimuoverà automaticamente per motivi di sicurezza.

Tutte le seguenti guide richiedono che tu abbia già un autenticatore **funzionante e operativo** utilizzato con un dato strumento/applicazione. ASF 2FA non funzionerà correttamente se si importano dati non validi, quindi assicurarsi che l'autenticatore funzioni correttamente prima di tentare di importarli. Ciò include il test e la verifica del corretto funzionamento delle seguenti funzioni di autenticatore:
- È possibile generare token e questi token sono accettati dalla rete di Steam (è possibile accedere con loro)
- È possibile recuperare le conferme, e stanno arrivando sul vostro autenticatore mobile
- Puoi reagire a queste conferme e sono correttamente riconosciute dalla rete Steam come confermate/rifiutate

Assicurati che il tuo autenticatore funzioni controllando se le azioni sopra indicate funzionano - se non funzionano, allora non funzioneranno nemmeno in ASF.

### Telefono Android

In generale per importare l'autenticatore dal tuo telefono Android avrai bisogno di accesso **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))**. Le istruzioni qui sotto richiedono da voi una conoscenza abbastanza decente nel mondo di modding Android, non stiamo sicuramente andando a spiegare ogni passo qui, visita **[XDA](https://xdaforums.com)** e altre risorse per ulteriori informazioni/aiuto con sotto.

**A partire da oggi, non è noto metodo di estrazione confermato che continua a funzionare. Si può provare a seguire i passaggi qui sotto comunque, ad esempio con versione obsoleta dell'app, ma non garantiamo che funzionerà correttamente. Si consideri invece di utilizzare il metodo joint-authenticator.**

<details>
  <summary>Istruzioni per l'archivio</summary>

Supponendo che tu abbia l'app ufficiale **[Steam](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** funzionante e operativa (qui sotto richiede il rooting del tuo dispositivo):

- Installa **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** e abilita Zygisk nelle impostazioni.
- Installa **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (per Zygisk) e assicurati che funzioni.
- Installa il modulo **[SteamGuardDump](https://github.com/YifePlayte/SteamGuardDump/releases/latest)** o **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** LSPosed e attivalo nelle impostazioni LSPosed.
- Forza l'uccisione di Steam app, quindi aprila, i dettagli della guardia di vapore dovrebbero ora essere disponibili per la copia negli appunti.

Ora che hai estratto con successo i dettagli richiesti, disabilita il modulo per impedire la copia automatica ogni volta, quindi copia il valore di `shared_secret` e `identity_secret` dell'account che intendi aggiungere a ASF 2FA, in un nuovo file di testo con la struttura seguente:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Sostituisci ogni valore `STRING` con la chiave privata appropriata dai dettagli estratti. Una volta fatto, rinominare il file in `BotName. aFile`, dove `BotName` è il nome del tuo bot al quale stai aggiungendo ASF 2FA e mettilo nella directory `di ASF di configurazione` se non lo hai ancora fatto.

Avviare ASF, che dovrebbe notare il file e importarlo. Supponendo che tu abbia importato il file corretto con segreti validi, tutto dovrebbe funzionare correttamente, che puoi verificare utilizzando i comandi `2fa`. Se hai commesso un errore, puoi sempre rimuovere `Bot.db` e ricominciare da capo se necessario.

</details>

### SteamDesktopAuthenticator

Se il tuo autenticatore è già in esecuzione in SDA, dovresti notare che c'è un file `steamID.maFile` disponibile nella cartella `maFiles`. Assicurati che `maFile` sia in forma non cifrata, siccome ASF non può decifrare i file SDA - il contenuto del file non cifrato dovrebbe iniziare con `{` e terminare con il carattere `}`. Se necessario, puoi prima rimuovere la crittografia dalle impostazioni SDA e riattivarla quando hai finito. Una volta che il file è in forma non cifrata, copiarlo nella directory `config` di ASF.

Ora puoi rinominare `steamID.maFile` in `BotName. aFile` nella directory di configurazione di ASF, dove `BotName` è il nome del tuo bot che stai aggiungendo ASF 2FA a. In alternativa puoi lasciarlo così com'è, ASF lo sceglierà automaticamente dopo l'accesso. Rinominare il file aiuta ASF rendendo possibile l'uso di ASF 2FA prima di accedere, se non lo fai, quindi il file può essere scelto solo dopo aver effettuato il login di ASF (poiché ASF non conosce `steamID` del tuo account prima di effettuare l'accesso).

Avviare ASF, che dovrebbe notare il file e importarlo. Supponendo che tu abbia importato il file corretto con segreti validi, tutto dovrebbe funzionare correttamente, che puoi verificare utilizzando i comandi `2fa`. Se hai commesso un errore, puoi sempre rimuovere `Bot.db` e ricominciare da capo se necessario.

### WinAuth

Crea in primo luogo un nuovo `BotName. aFile` nella directory di configurazione ASF, dove `BotName` è il nome del tuo bot a cui stai aggiungendo ASF 2FA. Se fornisci un nome errato, non verrà scelto da ASF.

Ora lanciare WinAuth come al solito. Fare clic destro sull'icona di Steam e selezionare "Mostra SteamGuard e codice di recupero". Quindi controlla "Consenti copia". Si dovrebbe notare familiare a voi struttura JSON sul fondo della finestra, a partire da `{`. Copia tutto il testo in un file `BotName.maFile` creato da te nel passaggio precedente.

Avviare ASF, che dovrebbe notare il file e importarlo. Supponendo che tu abbia importato il file corretto con segreti validi, tutto dovrebbe funzionare correttamente, che puoi verificare utilizzando i comandi `2fa`. Se hai commesso un errore, puoi sempre rimuovere `Bot.db` e ricominciare da capo se necessario.

### Manuale

Se sei utente avanzato, puoi anche generare maFile manualmente. Questo può essere usato nel caso in cui si desideri importare l'autenticatore da fonti diverse da quelle che abbiamo descritto sopra. Dovrebbe avere una struttura **[valida JSON](https://jsonlint.com)** di:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

I dati dell'autenticatore standard hanno più campi - sono completamente ignorati da ASF durante l'importazione, in quanto non sono necessari. Non è necessario rimuoverli - ASF richiede solo JSON valido con 2 campi obbligatori descritti sopra, e ignorerà campi aggiuntivi (se ce ne sono). Naturalmente, è necessario sostituire il segnaposto `STRING` nell'esempio di cui sopra con valori validi per il tuo account. Ogni `STRING` dovrebbe essere base64 codificato rappresentazione di byte di cui è fatta la chiave privata appropriata.

---

## Domande frequenti

### In che modo ASF utilizza il modulo 2FA?

Se ASF 2FA è disponibile, ASF lo utilizzerà per la conferma automatica delle operazioni che vengono inviate/accettate da ASF. Sarà anche in grado di generare automaticamente i token 2FA su base come necessario, ad esempio per accedere. In aggiunta a questo, avendo ASF 2FA anche abilitare i comandi `2fa` da usare.

### Come posso ottenere il token 2FA?

Avrai bisogno del token 2FA per accedere all'account protetto da 2FA, che include anche ogni account con ASF 2FA. Se hai deciso di utilizzare l'autenticatore standalone, dovresti usare il comando `2fa <BotNames>` per generare token temporaneo per determinate istanze del bot. In tutti gli altri scenari, si consiglia di utilizzare l'autenticatore originale che hai utilizzato, anche se è possibile utilizzare il comando anche se è più conveniente per voi.

### Posso usare il mio autenticatore originale dopo averlo importato come ASF 2FA?

Sì, il tuo autenticatore originale rimane funzionale e puoi usarlo insieme con ASF 2FA. Tenete a mente tuttavia che se lo invalidate attraverso qualsiasi metodo, le credenziali ASF 2FA collegate non saranno più valide.

### Come rimuovere ASF 2FA?

Basta fermare ASF e rimuovere associati `BotName.db` del bot con ASF 2FA collegato che si desidera rimuovere. Questa opzione rimuoverà le 2FA importate associate con ASF, ma NON invaliderà (scollegare) il tuo autenticatore. Se invece vuoi invalidare il tuo autenticatore, oltre a rimuoverlo da ASF (prima), dovresti scollegarlo nell'autenticatore originale di tua scelta. Se non riesci a farlo per qualche motivo, ad esempio perché stai usando ASF 2FA in modalità standalone, quindi utilizzare il codice di revoca che hai ricevuto durante la configurazione, sul sito web di Steam. Non è possibile invalidare l'autenticatore tramite ASF.

### Ho collegato l'autenticatore in app di terze parti, quindi importato in ASF. Ora posso collegarlo di nuovo al mio telefono?

**No**. In questo modo verranno invalidate le credenziali precedentemente importate e la tua ASF 2FA cesserà di funzionare (generando codici non più accettati da Steam). In primo luogo decidere dove si desidera avere il vostro originale o autenticatore di terze parti trovato, quindi importarlo come ASF 2FA.

### Sto usando l'autenticatore congiunto, posso spostare la mia app su un altro telefono?

**No**. Quello che il vapore afferma come autenticatore "in movimento" o "in trasferimento", è in realtà uguale a invalidare il vecchio e assegnarne uno nuovo, in un solo passo. Questo ti permette di saltare ad es. un eccesso di raffreddamento rispetto a queste due fasi in modo indipendente, tuttavia, per quanto riguarda la ASF, questo in realtà annulla le credenziali che hai precedentemente generato in ASF, rendendo l'intero modulo ASF 2FA non operativo.

Il modo consigliato è quello di rimuovere il vostro autenticatore interamente sul vecchio telefono e utilizzare nuovamente il metodo di autenticazione congiunta sul nuovo telefono. Se hai già spostato l'autenticatore, le vecchie credenziali ASF 2FA sono già invalidate, quindi l'unica cosa rimasta ora è rimuovere l'autenticatore "spostato" e collegarne uno nuovo utilizzando nuovamente il metodo dell'autenticatore congiunto.

### Usare ASF 2FA è meglio di un autenticatore di terze parti impostato per accettare tutte le conferme?

**Sì**, in diversi modi. Il primo e più importante - usando ASF 2FA **significativamente** aumenta la tua sicurezza, poiché il modulo ASF 2FA assicura che ASF accetti automaticamente solo le proprie conferme, quindi anche se l'attaccante richiede un commercio che è dannoso, ASF 2FA **non** accetta tale commercio, in quanto non è stato generato da ASF. Oltre alla parte di sicurezza, l'uso di ASF 2FA porta anche benefici di prestazioni/ottimizzazione, come ASF 2FA recupera e accetta conferme immediatamente dopo la loro generazione, e solo allora, a differenza dei sondaggi inefficienti per le conferme ogni X minuti che si ottengono con altre soluzioni. Non c'è motivo di utilizzare l'autenticatore di terze parti su ASF 2FA, se si prevede di automatizzare le conferme generate da ASF - questo è esattamente ciò che ASF 2FA è, e usarlo non è in conflitto con voi confermando tutto il resto in autenticatore di vostra scelta. Si consiglia vivamente di utilizzare ASF 2FA per l'intera attività di ASF.