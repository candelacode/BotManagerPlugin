# Primi passi

Se sei qui per la prima volta, benvenuto! Siamo molto felici di vedere un altro viaggiatore interessato al nostro progetto, anche se tenere a mente che con grande potere arriva grande responsabilità - ASF è in grado di fare un sacco di compiti diversi di Steam, ma solo fino a quando **ti cura abbastanza per imparare a usarlo**. Infatti, lettura wiki, seguendo le nostre linee guida e imparando di più su vari concetti di ASF alla fine ti ricompenserà con l'abilità unica di utilizzare uno dei più potenti strumenti di Steam disponibili a partire da oggi.

Ti consigliamo di fare una cosa **alla volta**. ASF tocca molti aspetti diversi, alcuni dei quali sono piuttosto banali, altri possono essere eccessivamente complessi. Non è necessario capire o leggere tutto in una sola volta, e in realtà vi consigliamo di prenderlo facile. Rilassati, prendi una bevanda di scelta, dedica un'ora del tuo tempo e tuffa nella nostra lezione - possiamo promettere che vale la pena il tuo tempo.

Partiamo dalle basi - ASF è un'applicazione di console nel suo principio, che significa che non genererà automaticamente un'interfaccia grafica a cui sei abituato in generale. ASF è app universale che agisce principalmente come un servizio (daemon), e non come un'applicazione desktop. Uno dei suoi principali casi di utilizzo considera in esecuzione sulle macchine server, per cui le app desktop sono del tutto inadatte. Che considera solo il nucleo assoluto del programma, però, perché ASF in realtà **fa** include la propria interfaccia grafica - nella forma del suo frontend ASF-ui incorporato, ma arriveremo a quella parte a tempo debito - stiamo solo menzionando questo subito, in modo da non farti prendere dal panico quando si vede la console nera o qualcosa.

Una volta che si ottengono file binari ASF, il programma richiederà la configurazione da voi, che specifica cosa esattamente ci si aspetta per ASF per raggiungere. È possibile avviare il programma senza configurazione, in questo caso ASF avvierà nelle impostazioni predefinite, consentendo di utilizzare e. . ASF-ui per la configurazione iniziale, ma a parte che non farà molto senza la vostra azione precedente.

Questo farà per ora, cominciamo!

---

## Installazione per ogni OS

Il linea generale, ecco cosa faremo nei prossimi minuti:
- Installeremo **[.NET prerequisiti](#net-prerequisites)**.
- Quindi scaricheremo l'ultima versione **[di ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** nella variante specifica del sistema operativo appropriata.
- Successivamente estrarremo l'archivio in una nuova posizione.
- Allora noi **[configura ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- E infine, lanceremo ASF e vedremo la sua magia.

Alcuni dei passi sono auto-esplicativi, altri richiederà più attenzione da voi. Non ti preoccupare, ti abbiamo coperto.

---

### .NET prerequisiti

Il primo passo consiste nell'assicurarsi che il proprio OS possa eseguire ASF correttamente. Non c'è bisogno di saperlo, ma ASF è scritto in C#, basato su . Piattaforma ET e potrebbe richiedere librerie native che non sono ancora disponibili sulla tua piattaforma. Pensateci come DirectX per i giochi 3D, o il motore per avviare la vostra auto.

A seconda che si utilizza Windows, Linux o macOS, si avrà diversi requisiti. Il documento di riferimento è **[. ET prerequisiti](https://docs.microsoft.com/dotnet/core/install)**, ma per semplicità abbiamo anche dettagliato tutti i pacchetti necessari qui sotto, quindi non è necessario leggerlo affatto, a meno che non si incorre in problemi o avrete ulteriori domande.

È perfettamente normale che alcuni, o anche tutti i prerequisiti siano già presenti nel tuo sistema, magari perché installati da applicazioni di terze parti che stai usando. Eppure, questo non deve essere il caso, così si dovrebbe eseguire l'installatore appropriato per il vostro sistema operativo - senza queste dipendenze ASF non si avvierà affatto, e riceverai a malapena tutte le informazioni utili per dirti cosa c'è di sbagliato.

Tenete a mente che non è necessario fare altro per le costruzioni specifiche del sistema operativo, in particolare installazione. ET SDK o anche runtime, poiché il pacchetto specifico per il sistema operativo include già tutto questo. Hai bisogno solo di prerequisiti .NET (dipendenze) per eseguire . ET runtime incluso in ASF - quindi solo le cose che specifichiamo qui sotto, senza altre aggiunte.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** per 64 bit, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** per 32 bit o **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** per ARM a 64 bit
- È fortemente consigliato assicurarsi gli aggiornamenti di Windows siano tutti installati. Se non li hai abilitati, poi per lo meno hai bisogno di **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** e **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, ma potrebbero essere necessari ulteriori aggiornamenti. Non è necessario preoccuparsi di questo se il vostro Windows è aggiornato, o almeno abbastanza recente.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Il nome del pacchetto varia in base alla distribuzione di Linux che stai usando, ma elencheremo quelli che sono i più comuni. Li puoi ottenere dal tuo gestore di pacchetti nativo in base all'OS che usi (come `apt` per Debian, o `yum` per CentOS). Quelle sono librerie piuttosto standard che dovrebbero essere disponibili indipendentemente dalla distribuzione che stai utilizzando, è solo una questione di scoprire come sono chiamati nel vostro ambiente di scelta.

- `ca-certificates` (certificati SSL affidabili standard per creare connessioni HTTPS)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, ultima versione per la tua distribuzione, ad esempio `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-libs`, ultima versione per la tua distribuzione, almeno `1.1.X`)
- `libstdc++6` (`libstdc++`, nella versione `5.0` o superiore)
- `zlib1g` (`zlib`)

Almeno una maggioranza di questi dovrebbe essere già nativamente disponibile sul vostro sistema. Ad esempio, l'installazione minima di Debian stable di solito richiede solo `libicu76`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- Non hai bisogno di nulla in particolare, ma dovresti avere l'ultima versione di macOS installata, almeno 12.0+

---

### Download

Ora che abbiamo i requisiti necessari, il prossimo passo sarà scaricare **[l'ultima versione di ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF è disponibile in molte varianti, ma tu sei interessato al pacchetto corrispondente al tuo sistema sperativo ed architettura. Ad esempio, se stai usando `Win`dows a `64` bit, allora ti servirà il pacchetto `ASF-win-x64`. Per maggiori informazioni sulle versioni disponibili, consulta la sezione **[compatibilità](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**. ASF è anche in grado di funzionare negli ambienti per i quali non stiamo costruendo un pacchetto specifico per OS, come **32-bit Windows**, ma per questo hai bisogno di una configurazione generica **[](#generic-setup)**.

![Asset](https://i.imgur.com/Ym2xPE5.png)

Dopo il download, inizia estraendo i file dell'archivio in cartella dedicata. Se hai bisogno di uno strumento specifico per questo, **[7-zip](https://www.7-zip.org)** lo farà, ma tutte le utility standard come l'estrazione di Windows integrata o `unzip` da Linux/macOS dovrebbero funzionare senza problemi.

Si consiglia di scompattare ASF per **la propria directory** e non per qualsiasi directory esistente che si sta già utilizzando per qualcos'altro - questo è importante. ASF include la funzione di aggiornamenti automatici, che sostituisce i propri file, e che di solito eliminerà tutti i file vecchi e non correlati durante l'aggiornamento, che a sua volta può portare a perdere qualsiasi cosa non correlata che si mette nella directory di ASF. Se si dispone di script o file aggiuntivi che si desidera utilizzare con ASF, questo non è un problema, creare una cartella dedicata per quelli, è sempre possibile mettere ASF in una cartella più profonda.

Una struttura di esempio potrebbe assomigliare a questo:

```text
C:\ASF (dove metti le tue cose)
    ├<unk> 한MyNotes. xt (facoltativo)
    ├<unk> <unk> <unk> AsfMakeMeCoffeeScript.bat (opzionale)
    <unk> <unk> <unk> <unk> (... (qualsiasi altro file di vostra scelta, facoltativo)
    <unk> <unk> Core (dedicato esclusivamente a ASF, dove si estrae l'archivio)
         ├<unk> <unk> <unk> ArchiSteamFarm(. xe)
         Ãš config
         Ãš logs
         Ãš plugins
         Ãš www
         γ<unk> (...)
```

---

### Configurazione

Siamo ora pronti per affrontare l'ultima tappa, la configurazione. ASF funziona con il concetto di "bot", ogni bot è di solito un unico account Steam che si desidera utilizzare all'interno di ASF. Puoi dichiarare il numero di bot che vuoi, ma per l'avviamento ci concentreremo su solo uno di loro - di solito il tuo account principale. ASF ha anche file di configurazione non-bot, quello più importante è il file di configurazione globale, che colpisce tutti i bot nell'istanza.

La regola generale del pollice è che **se non conosci, o non capisci qualche impostazione, si dovrebbe lasciare con il suo valore predefinito, senza cambiare nulla**. ASF offre innumerevoli modi per configurare, personalizzare e modificare quasi tutte le sue funzionalità, ma come menzionato sopra, cercando di capirlo subito fuori dal pipistrello è un foro di coniglio che può trascinare rapidamente in grave confusione, if not **[straight into the abyss](https://www.youtube.com/watch?v=KK3KXAECte4)**. Invece, si consiglia di avere un esempio di lavoro prima, e solo allora iniziare a scavare in opzioni aggiuntive, con l'aiuto della pagina **[di configurazione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** sulla wiki, cambiando **una cosa alla volta**.

La configurazione di ASF può essere effettuata in diversi modi: attraverso il nostro frontend ASF-ui integrato, un generatore di configurazione web standalone o manualmente. Ciò è spiegato nel dettaglio nella sezione **[configurazione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, quindi fai riferimento ad essa se vuoi informazioni più dettagliate. Useremo il generatore di configurazione web standalone come punto di partenza, perché funziona anche se per qualche motivo ASF-ui non riesce ad iniziare o a funzionare correttamente.

Vai alla nostra pagina **[web config generator](https://justarchinet.github.io/ASF-WebConfigGenerator)** con il tuo browser preferito. Raccomandiamo Chrome o Firefox, ma non dovrebbe importa finchè il browser funziona per tutto il resto.

Una volta caricata la pagina, clicca su "Bot". Dovresti avere davanti una pagina simile a questa:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Se per qualche motivo la versione di ASF che hai appena scaricato è più vecchia di quella preselezionata dal generatore di configurazioni, seleziona la versione corretta dal menu a discesa. Questo può (raramente) accadere, poiché il generatore di configurazione può essere utilizzato per generare configurazioni a versioni ASF più recenti (pre-rilascio) che non sono state ancora contrassegnate come stabili. Hai scaricato l'ultima versione stabile di ASF che è verificato per funzionare in modo affidabile, quindi potrebbe essere un po 'più vecchio della versione assoluta all'avanguardia, che non è completamente adatto per il primo uso.

Inizia da **mettendo il nome per il tuo bot** nel campo evidenziato come rosso, chiamato `Nome`. Può essere qualsiasi nome che tu desideri utilizzare, come il tuo nickname, nome dell'account, un numero o altro. C'è solo una parola che non puoi utilizzare, ed è `ASF`, poichè è riservata al file di configurazione generale. Inoltre, il nome del tuo bot non può iniziare con un punto (ASF ignora intenzionalmente questi file). Si consiglia inoltre di evitare di utilizzare spazi, è possibile utilizzare `_` come separatore di parole se necessario - non un requisito rigoroso, ma altrimenti avrai difficoltà a usare i comandi ASF.

Il nome del bot ha deciso? Grande, nel passo successivo, **change `Abilitato` switch to be on**, che si definisce se il bot dovrebbe essere avviato da ASF automaticamente dopo il lancio (del programma). Non farlo farà sì che ASF stabilisca che il tuo bot è disabilitato nel file di configurazione, ed è in attesa che il vostro input per iniziare, che non è quello che vogliamo fare in questo esempio.

Ora, ci sono due proprietà sensibili che stanno per arrivare: `SteamLogin` e `SteamPassword`. Puoi prendere un'altra decisione qui - o puoi inserire i dettagli di accesso di Steam in quelle due proprietà, o puoi decidere di non farlo, lasciandoli vuoti.

ASF richiede le tue credenziali di accesso perchè include la propria implementazione del client di Steam, e per accedere ha bisogno degli stessi dettagli che utilizzi tu. Le tue credenziali di accesso non vengono salvate da nessuna parte, ma sul tuo PC nella directory ASF `config` solo (una volta che scarichi la configurazione generata). Il nostro generatore di configurazione web è un'applicazione basata su client il che significa che tutto ciò che stai facendo all'interno del nostro Web config-generator standalone è in esecuzione localmente nel tuo browser per generare configurazioni ASF valide, senza i dettagli che stai inserendo mai lasciando il tuo PC in primo luogo, quindi non c'è bisogno di preoccuparsi di eventuali perdite di dati sensibili. Ancora, se per qualsiasi motivo non vuoi mettere le tue credenziali lì, capiamo che, e puoi metterli manualmente in seguito nei file generati, o ometterli completamente e operare senza di loro.

Se decidi di inserire le tue credenziali, ASF sarà in grado di accedere automaticamente durante l'avvio, che insieme a 2FA opzionale consente efficacemente di fare doppio clic sul programma per eseguire tutto. Se si decide di ometterli, quindi ASF ti chiederà **** di inserire quei dettagli quando necessario - questo approccio non li salverà da nessuna parte, ma naturalmente ASF non sarà in grado di operare senza il vostro aiuto. Sta a te in quale modo preferisci di più, e puoi anche trovare ulteriori informazioni nella sezione di configurazione **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** , come al solito.

Come nota collaterale, puoi anche decidere di lasciare un solo campo vuoto, come ad esempio `SteamPassword`. ASF sarà quindi in grado di utilizzare il login automaticamente, ma chiederà comunque la password se necessario (simile a Steam Client). Se per caso stai usando il pin parentale a 4 cifre per sbloccare il tuo account, consigliamo anche di inserirlo nella casella `SteamParentalPin` , sebbene anche in questo caso si può solo lasciare questo vuoto, e invece osservare quanto debole sia quella protezione, perché ASF può anche "crepa" se stesso entro pochi secondi dopo l'accesso. Oops.

Dopo aver seguito con tutto quanto sopra, quindi ancora una volta, **nome bot**, **attivato interruttore**, e **credenziali di accesso** , la tua pagina web sarà ora simile a quella seguente:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Ora puoi premere il tasto "download" ed il nostro generatore di configurazioni web genererà un file `json` basato sul nome scelto. Salva quel file nella directory `di configurazione` che si trova nella cartella all'interno della quale hai estratto il file zip nel passaggio precedente.

Congratulazioni! Hai appena completato la configurazione fondamentale del bot ASF. C'è molto di più da scoprire, ma per ora questo è tutto ciò di cui avete bisogno.

---

### Eseguire ASF

So che avete aspettato per questo momento, e non possiamo tenervi più a lungo, come ora siete pronti a lanciare il programma per la prima volta. Basta fare doppio clic sul binario `ArchiSteamFarm` nella directory ASF. Puoi anche avviarlo dalla console.

Ora sarebbe un buon momento per rivedere la nostra sezione **[comunicazione remota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** se sei preoccupato di cose che ASF è programmato per fare, in particolare le azioni che prenderà nel tuo nome, come ad esempio entrare nel nostro gruppo Steam per impostazione predefinita. Puoi sempre disabilitare le funzionalità selezionate in un secondo momento se non ti piacciono, ASF viene fornito con valori predefiniti sensibili, e abbiamo dovuto prendere qualche decisione su un uso generale che si applica alla maggior parte della nostra base utente, così come la nostra opinione sul programma nel suo principio.

Supponendo che tutto sia andato bene, che considera principalmente l'installazione di tutte le dipendenze richieste nel primo passo, e la configurazione di ASF nel terzo, ASF dovrebbe lanciarsi correttamente, scoprire il tuo primo bot e tentare di accedere:

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF molto probabilmente richiederà ancora un ulteriore dettaglio da parte vostra - 2FA per accedere all'account (a meno che non avete disabilitato SteamGuard completamente, poi no). Basta seguire le istruzioni sullo schermo, è possibile fornire il codice da autenticatore/e-mail, o accettare la conferma nell'app mobile.

Qualcosa è andato storto?

#### ASF non si avvia affatto, nessuna finestra della console

O ti manca .NET prerequisiti, o hai scaricato una variante errata di ASF per la macchina. Se non sai cosa è sbagliato, consulta la nostra **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** per un possibile modo per scoprire il problema esatto, e se sei ancora bloccato, raggiungi il nostro supporto **[](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### Nessun bot definito

Non hai inserito la configurazione generata nella directory `config`. Alcuni altri errori comuni in questo passaggio potrebbero includere la modifica manuale dell'estensione da `.json` ad esempio a `. xt`e alcuni sistemi operativi (es. Windows) piace nascondere le estensioni comuni di default, in modo da garantire che il file è in luogo appropriato e anche con il nome appropriato.

#### Non avviare questo bot perché è disabilitato nel file di configurazione

Hai dimenticato di capovolgere l'interruttore `Abilitato` che dice a ASF di avviare automaticamente il tuo bot. A meno che questa fosse la tua intenzione, ovviamente, ma allora dovresti già sapere come eseguire i comandi, semplicemente `avvia` il tuo bot dopo quel messaggio.

#### `Password Invalida`

Le tue credenziali di accesso sono molto probabilmente errate. Controlla il tuo `SteamLogin` e `SteamPassword` nella configurazione generata, se non sono corretti, correggerli tornando alla fase di configurazione. Se hai ancora problemi, prova a usare le stesse credenziali di accesso nel tuo client Steam - dovresti anche non accedere, e forse otterrai maggiori informazioni su ciò che è sbagliato in questo modo.

#### Tutto buono?

Dopo aver passato attraverso il cancello di accesso iniziale, supponendo che i tuoi dati siano corretti, accederai con successo, e ASF inizierà a coltivare usando le impostazioni predefinite che non hai toccato da ora:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Questo prova che ASF sta facendo un ottimo lavoro sul tuo account, ed ora puoi minimizzare il programma e fare qualcos'altro. Andate avanti, lo meritavate, magari ricaricate quella bevanda di vostra scelta almeno!

Le carte di fattoria sono oggetto di un altro lungo articolo come questo, ma in linea di principio: dopo abbastanza tempo (a seconda delle prestazioni **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), vedrai le carte di trading Steam lentamente cadute. Naturalmente, perché ciò accada è necessario avere giochi validi per la fattoria, mostrando come "puoi ottenere altre X gocce di carte da giocare a questo gioco" sulla tua pagina **[badges](https://steamcommunity.com/my/badges)** - se non ci sono giochi da coltivare, poi ASF affermerà che non c'è nulla da fare, come indicato nella nostra **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, che risponde alle domande più comuni persone hanno a questo punto, chiedendosi perché nonostante possedere 14 giochi whopping sul loro account, ASF sostiene che non c'è nulla da fare - no, non è un bug.

Con questo si conclude la nostra guida fondamentale sull'impostare ASF. Come in ogni gioco RPG, hai finito il tutorial, e ti stiamo lasciando tutto il mondo di ASF per esplorare ora. Ad esempio, ora puoi decidere se vuoi configurare ASF ulteriormente, o lasciare che faccia il suo lavoro nelle impostazioni predefinite. Ci occuperemo di alcuni dettagli di base se vuoi leggere un po 'di più, poi lasciarti tutta la wiki per la scoperta.

---

### Configurazione avanzata

#### Allevare più conti in una volta

ASF supporta l'agricoltura più di un conto alla volta, che è la sua funzione primaria. Puoi aggiungere altri account ad ASF generando più file di configurazione dei bot, esattamente come hai generato il primo qualche minuto fa. Devi solo assicurarti di due cose:

- Nome del bot unico, se hai già il tuo primo bot chiamato `MainAccount`, non puoi averne un altro con lo stesso nome.
- Dettagli di accesso validi, come `SteamLogin`, `SteamPassword` e `SteamParentalCode` (se hai deciso di compilarli)

In altre parole, ritorna nuovamente alla configurazione ed esegui esattamente gli stessi passaggi per il tuo secondo o terzo account. Ricordati di usare nomi univoci per tutti i tuoi bot, per non sovrascrivere le configurazioni esistenti.

---

#### Modifica delle impostazioni

Nel nostro generatore di configurazione web standalone, si modificano le impostazioni esistenti esattamente nello stesso modo - generando un nuovo file di configurazione. Clicca su "toggle impostazioni avanzate" e vedere cosa c'è da scoprire. In questo esempio, cambieremo l'impostazione `CustomGamePlayedWhileFarming` , che consente di impostare il nome personalizzato visualizzato quando ASF è allevamento, invece di mostrare la partita reale.

Analizziamo questo un po' prima. Se esegui ASF e inizi a coltivare, nelle impostazioni predefinite vedrai che il tuo account Steam è in gioco ora:

![Vapore](https://i.imgur.com/1VCDrGC.png)

Questo ha senso, dopo che ASF ha appena detto alla piattaforma Steam che stiamo giocando il gioco, abbiamo bisogno di carte da esso, giusto? Ma hey, possiamo personalizzare questo! Attiva/disattiva le impostazioni avanzate se non hai ancora fatto, quindi trova `CustomGamePlayedWhileFarming`. Basta mettere qualsiasi testo personalizzato che si desidera visualizzare lì, come "carte Idling":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Ora scarica il nuovo file di configurazione e **sovrascrivi** quello esistente. È anche possibile eliminare il vecchio file di configurazione e mettere il nuovo al suo posto, naturalmente.

ASF è abbastanza intelligente e dovrebbe notare che hai cambiato la configurazione, che dovrebbe poi automaticamente prendere e applicare, senza un riavvio del programma. Se per caso non è accaduto, puoi semplicemente riavviare il programma per assicurarsi che la tua nuova configurazione venga raccolta. Dopo averlo fatto, dovresti notare che ASF ora visualizza il tuo testo personalizzato nel posto precedente:

![Vapore 2](https://i.imgur.com/vZg0G8P.png)

Questo conferma che hai modificato con successo la tua configurazione. Nello stesso modo è possibile modificare le proprietà globali di ASF, passando dalla scheda bot alla scheda "ASF", scaricando generato `ASF. son` config file e inserirlo nella tua `configurazione`.

Modificare le configurazioni di ASF può essere fatto molto più facile utilizzando il nostro frontend ASF-ui, che verrà spiegato più avanti.

---

#### Utilizzo di ASF-ui

Come abbiamo accennato prima, ASF è un'app per console e non avvia un'interfaccia grafica per impostazione predefinita. Tuttavia, stiamo lavorando attivamente sul frontend **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** alla nostra interfaccia IPC, che può essere un modo molto decente e facile da usare per accedere a varie funzionalità di ASF.

Per poter utilizzare ASF-ui, è necessario abilitare `IPC` , che è l'opzione predefinita, quindi a meno che tu non lo abbia disabilitato manualmente, è già attiva. Una volta avviato ASF, dovresti essere in grado di confermare che ha avviato correttamente l'interfaccia IPC automaticamente:

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC, in poche parole, è integrato il server web di ASF che si avvia localmente sulla vostra macchina, ti permette di interagire con esso utilizzando il tuo browser web preferito. Supponendo che sia iniziato correttamente, puoi accedere all'interfaccia IPC di ASF facendo clic su **[questo link](http://localhost:1242)** , fino a quando ASF è in funzione, dalla stessa macchina. È possibile utilizzare ASF-ui per vari scopi, ad esempio la modifica dei file di configurazione sul posto o l'invio di comandi **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Sentiti libero di dare un'occhiata in giro per scoprire tutte le funzionalità di ASF-ui.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Sommario

Hai impostato con successo ASF per utilizzare i tuoi account Steam e lo hai già personalizzato a tuo piacimento. Se hai seguito tutta la nostra guida, sei riuscito anche a modificare ASF attraverso la nostra interfaccia ASF-ui e hai iniziato a scoprire le sue funzionalità. Questo conclude il nostro tutorial, ma ti stiamo lasciando con alcuni puntatori aggiuntivi a cose che potrebbero interessarti, "missioni laterali", se insisti:

- Our **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section will explain to you  what **all** those different settings you've seen actually do, and what else ASF can offer to you. Ricordati di idratarti correttamente durante la lettura, sei stato avvisato.
- If you've stumbled upon some issue or you have some generic question, consider our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**, which should cover all, or at least a vast majority of questions and issues that you may have.
- Se volete imparare tutto su ASF e come può rendere la vostra vita più facile, dirigiti verso il resto di **[la nostra wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. Usa la barra laterale a destra per scegliere l'oggetto che ti interessa.
- E infine, se avete scoperto il nostro programma per essere utile per voi e apprezzate l'enorme quantità di lavoro che è stato messo in esso, puoi anche considerare una piccola donazione **[](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** per la nostra causa. ASF è lavoro di amore, abbiamo lavorato duramente nel nostro tempo libero per gli ultimi 10 anni per rendere questa esperienza possibile per voi, e siamo molto orgogliosi di esso - anche $1 è molto apprezzato e mostra che ti interessa. In ogni caso, divertiti tantissimo!

---

## Configurazione generica

Questa appendice è per gli utenti avanzati che vogliono impostare ASF da eseguire nella variante **[generica](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)**. Pur essendo più fastidioso nell'uso di varianti **[specifiche per il sistema operativo](#os-specific-setup)**, viene anche fornito con benefici aggiuntivi.

Si desidera utilizzare la variante `generica` principalmente quando:
- Stai usando il sistema operativo per il quale non costruiamo un pacchetto specifico per il sistema operativo (come Windows a 32-bit)
- Hai già .NET Runtime/SDK, o vuoi installare e utilizzare uno
- Si desidera ridurre al minimo le dimensioni della struttura ASF e l'impronta di memoria gestendo da soli i requisiti di runtime
- Si desidera utilizzare un plugin **[personalizzato](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** che richiede una configurazione `generica` di ASF per funzionare correttamente (a causa di dipendenze native mancanti)

Naturalmente, è possibile utilizzarlo anche in qualsiasi altro scenario che si desidera, ma quanto sopra ha il massimo senso.

Tuttavia, tieni presente che la configurazione generica viene fornita con una torsione - **tu** sei responsabile di .NET runtime in questo caso. Ciò significa che se il vostro SDK .NET (runtime) non è disponibile, obsoleto, o rotto, ASF semplicemente non funzionerà. Questo è il motivo per cui non consigliamo totalmente questa configurazione per gli utenti casuali, dal momento che ora è necessario assicurarsi che il vostro . ET SDK (runtime) corrisponde ai requisiti di ASF e può eseguire ASF, invece di **noi** assicurando che il nostro . ET runtime in bundle con ASF può farlo.

Per il pacchetto `generico` è possibile seguire l'intera guida specifica per il sistema operativo sopra, con solo due piccole modifiche. Oltre all'installazione di .NET prerequisiti, si desidera anche installare .NET SDK, e invece di scaricare e avere OS-specific `ArchiSteamFarm(. xe) file eseguibile` , ora scaricherai e avrai solo un binario generico `ArchiSteamFarm.dll`. Tutto il resto è esattamente lo stesso.

Con passaggi aggiuntivi:
- Installa **[.NET prerequisiti](#net-prerequisites)**.
- Installa **[.NET SDK](https://www.microsoft.com/net/download)** (o almeno ASP.NET Core e .NET runtimes) adatti al tuo sistema operativo. È molto probabile che si desidera utilizzare un installer. Fare riferimento ai requisiti di esecuzione **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** se non sei sicuro di quale versione installare.
- Scarica l'ultima versione **[di ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** nella variante `generica`.
- Estrae l'archivio in una nuova posizione.
- **[Configurare ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, esattamente come descritto sopra.
- Launch ASF by either using a helper script or executing `dotnet /path/to/ArchiSteamFarm.dll` manually from your favourite shell.

La variante generica di ASF non ha binario specifico per macchina, dopotutto si chiama `generico` per un motivo - è una costruzione platform-agnostic che può funzionare ovunque, quindi non aspettarti il file `exe`.

Questo è il motivo per cui l'abbiamo messa in bundle con script helper (come `ArchiSteamFarm.cmd` per Windows e `ArchiSteamFarm. h` per Linux/macOS), che si trovano accanto al binario `ArchiSteamFarm.dll`. Puoi usarli se non vuoi eseguire manualmente il comando `dotnet`.

Ovviamente, gli script helper non funzioneranno se non hai installato. ET SDK e non hai un eseguibile `dotnet` disponibile nel tuo `PATH`. Sono anche completamente opzionali da usare, è sempre possibile `dotnet /path/to/ArchiSteamFarm. ll` manualmente se vuoi, come sotto il cofano con alcuni tweaks extra, questo è esattamente quello che quegli script stanno facendo comunque.