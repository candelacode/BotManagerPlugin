# Localizzazione

ASF è alimentato dal servizio Crowdin, che consente a tutti di aiutare a tradurre ASF in tutte le lingue parlate in tutto il mondo. Per spiegazioni più dettagliate su come funziona Crowdin, controlla **[Introduzione Crowdin](https://support.crowdin.com/crowdin-intro)**.

Se sei interessato a ciò che sta succedendo, puoi controllare le attività **[di ASF Crowdin](https://crowdin.com/project/archisteamfarm/activity_stream)**.

---

## Ambito

La nostra piattaforma supporta la localizzazione del nostro programma ASF principale, così come l'intero contenuto localizzabile che offriamo insieme ad esso. Questo include in particolare il nostro ASF-WebConfigGenerator, ASF-ui, così come il nostro wiki. Tutto ciò è possibile tradurre attraverso una comoda interfaccia crowdin.

---

## Registrazione in corso

Se si desidera aiutare con ASF, traducendo, rivedere o approvare le traduzioni, per favore iscriviti alla nostra pagina **[del progetto Crowdin](https://crowdin.com/project/archisteamfarm)**. La registrazione è facile e assolutamente gratuita! Dopo aver effettuato l'accesso è possibile scegliere le lingue a cui si desidera assegnare poi procedere con le stringhe ASF e aiutare il resto della comunità con la traduzione di ASF in tutte le lingue più popolari!

---

### Traducendo

Se la lingua di vostra scelta manca ancora alcune stringhe, potete afferrarle e iniziare a lavorare sulla traduzione. Abbiamo cercato di fare del nostro meglio in termini di flessibilità delle traduzioni, quindi molte stringhe includono variabili extra che ASF fornirà durante il runtime - quelle sono racchiuse tra parentesi con un numero, come `{0}`. Questo ti permette di modificare il formato ASF predefinito della stringa, ad es. spostando la variabile ASF in un luogo che soddisfa la tua lingua e la tua traduzione, invece di essere costretto a un contesto e un formato rigorosi. Questo è particolarmente importante nelle lingue RTL, come l'ebraico.

Ad esempio, potresti avere una stringa come:

> Abbiamo giochi {0} da coltivare.

Ma in base alla tua lingua, la seguente frase potrebbe avere più senso:

> Il numero di partite da fattoria è uguale a {0}.

Oppure:

> {0} è il numero di partite da coltivare.

La flessibilità è fornita appositamente per voi, così puoi riformulare leggermente la frase ASF per adattarla meglio alla tua lingua e spostare il numero fornito da ASF o altre informazioni in un luogo adatto alla tua traduzione (invece di tradurre ogni parte in modo indipendente). Questo migliora la qualità generale della traduzione.

---

### Revisione

Se la tua stringa è già stata tradotta da qualcun altro, puoi votare a favore. Il voto consente di scegliere la migliore variante della traduzione, invece di attaccare con il suggerimento iniziale - questo migliora la qualità di traduzione generale ancora di più. È possibile votare i suggerimenti già disponibili, o suggerire la propria traduzione, che passerà attraverso lo stesso processo. Alla fine, verrà scelta la stringa finale in base alla maggior parte dei suggerimenti votati, o come revisore selezionato per quella lingua che approva personalmente la traduzione (sulla base anche dei vostri voti).

**Non hai bisogno di approvazione per vedere le tue stringhe tradotte in ASF**. Approvazione significa semplicemente che qualcuno di fiducia da noi ha rivisto il contenuto, come in - scelto la versione finale della traduzione. Va benissimo avere traduzioni non approvate guidate dalla comunità, dove si vota per il migliore. Fintanto che è tradotto, tutto va bene! E se pensi che la traduzione corrente sia male, puoi sempre votare per quella migliore, o suggerirne uno tu.

---

### Proof-reading

È una buona idea avere una traduzione coerente, anche se potrebbe potenzialmente prendere la libertà dal processo di revisione / voto della comunità spiegato sopra. Questo è principalmente perché traduzioni errate che non sono necessariamente male possono ottenere così tanti upvotes che non è più possibile suggerire qualsiasi traduzione migliore, anche se qualcuno ha tale.

Se hai passato la cronologia dei contributi su Crowdin o su qualsiasi altra piattaforma di localizzazione/servizio che possiamo verificare e assumere affidabile, siamo felici di darti un accesso per un lettore di prova a una data lingua a cui stai contribuendo così sarete in grado di approvare la traduzione data e renderla coerente. La verifica della lettura non è un compito facile, soprattutto perché ASF può essere molto "tecnico" di tanto in tanto e molto difficile da tradurre, ma capiamo che è spesso necessario per una traduzione perfetta. Pertanto, se puoi aiutare con la proof-reading del linguaggio dato, **[fateci sapere](https://crowdin.com/messages/create/13177432/240376)**, ma tieni presente che dovrai eseguire il backup della tua richiesta con precedenti contributi di localizzazione che possiamo verificare (es. . lavorare con la localizzazione di ASF su Crowdin, o con qualsiasi altro progetto). Potremmo anche consentire agli utenti più avanzati di raccogliere la proof-reading iniziale, se li conosciamo personalmente e sono in grado di cooperare con il resto della comunità al fine di localizzare ASF in quel linguaggio migliore.

Regole generali si applicano per la proof-reading - non fretta, ascoltare i tuoi utenti, lavorare come project manager, risolvere i problemi, assicurarsi che state rendendo le cose migliori e non peggio.

---

### Problemi

Se hai un problema con una particolare traduzione, ad es. non sai come tradurlo, la traduzione approvata non è corretta, hai bisogno di un contesto più specifico, o anche, si prega di inviare un commento in una stringa specifica, e contrassegnarlo con [X] Problema.

**Si prega di evitare di utilizzare il marchio di errore se non hai bisogno di una spiegazione tecnica/di sviluppo o di un'azione di amministrazione**. Sei libero di utilizzare i commenti per la discussione relativa alla traduzione di una determinata stringa, ma il problema dovrebbe essere utilizzato solo quando avete bisogno di ulteriori spiegazioni tecniche o correzione amministrativa, e in genere coinvolgerà qualcuno che non parla nemmeno la lingua che stai traducendo, quindi si prega di bastone con l'inglese quando si scrive il commento del problema (così possiamo capire che cos'è il problema).

Attualmente ci sono 4 tipi supportati di problemi:
- Domanda generale - per tutto il resto che non si adatta a nessun problema qui sotto. In generale questo tipo **dovrebbe essere evitato**, come se il tuo problema non fosse adatto, allora è molto probabile che **non** un problema di traduzione. Tuttavia, questa opzione è disponibile qui per tutti gli altri casi.
- La traduzione corrente è sbagliata - questo dovrebbe essere usato **solo** se la traduzione è già stata approvata dal proof-reader e credi che sia sbagliato, per esempio ha un errore di battitura o hai un valido suggerimento su come migliorarlo. Questo tipo non dovrebbe mai essere utilizzato in traduzioni alimentate dalla comunità (votazione), come in questo caso si dovrebbe contattare con l'utente di una data traduzione e chiedergli la correzione, o semplicemente votare per una migliore traduzione, come indicato nella revisione della sezione. Rimuoveremo l'approvazione della traduzione e notificheremo il proof-reader appropriato responsabile della lingua per tenere conto del tuo commento e verificare di nuovo.
- Mancanza di informazioni contestuali - questo è ciò che dovresti usare se non sei sicuro di quale parte di ASF stai traducendo, qual è il contesto di una determinata stringa, o il suo scopo. Questo tipo dovrebbe essere utilizzato solo per lo sviluppo di ASF, significa che hai bisogno di assistenza tecnica in quanto non sei sicuro di come si dovrebbe tradurre la stringa data.
- Errori nella stringa di origine - questo dovrebbe essere usato solo se credi che la stringa originale (inglese) non sia corretta. Molto raro, ma non tutti noi parlano nativamente inglese, quindi sentitevi liberi di usarlo se avete un'idea generale come potrebbe essere migliorato. In alternativa, essendo ciò strettamente correlato allo sviluppo, potresti usare i nostri **[problemi di GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** per tale scopo, se vuoi.

---

### Avanzamento della traduzione

Ogni lingua ha due stati di completamento - traduzione, e prova di lettura.

La lingua è considerata **tradotta** quando il suo progresso di traduzione raggiunge il 100%. A questo punto ogni stringa localizzabile utilizzata da ASF ha un significato corretto, che è grande. Tuttavia, che non significa che non c'è spazio per il miglioramento - il voto della comunità è abilitato tutto il tempo e si può ancora suggerire una migliore traduzione per parti già tradotte, oltre a votare per quelli esistenti. Si prega di notare che le lingue completamente tradotte possono ancora scendere al di sotto del 100% quando modifichiamo le stringhe esistenti o aggiungerne di nuove durante lo sviluppo. È possibile impostare le notifiche di crowdin appropriate se si desidera ricevere e-mail quando ciò accade.

Le lingue selezionate possono avere lettori di prova appropriati che convalidano le traduzioni e approvano le versioni finali. Questo è il passaggio finale dopo che la traduzione ha luogo e permette di migliorare ulteriormente la localizzazione.

ASF includerà una data lingua **il più presto possibile**, il che significa che non deve essere approvata, o addirittura tradotta al 100%. Le stringhe che verranno utilizzate sono sempre le più popolari in termini di voti, a meno che il revisore scelto decida diversamente (raramente). Pertanto, puoi vedere i tuoi sforzi inclusi nella prossima versione di ASF - i nostri sistemi di automazione uniscono traduzioni da Crowdin di nuovo a ASF repo su base giornaliera.

---

## Lingue mancanti

Per impostazione predefinita, il progetto ASF ha una traduzione aperta solo per le prime 30 lingue parlate in tutto il mondo. Se vuoi aggiungere un altro (o un dialetto locale a quello già disponibile), per favore **[fateci sapere](https://crowdin.com/messages/create/13177432/240376)** e lo aggiungeremo al più presto. Non vogliamo aprire diverse centinaia di lingue diverse se nessuno le tradurrà, è per questo che l'abbiamo limitata ad un certo numero equo. Non esitate a contattarci se volete tradurre qualche lingua non elencata, è molto facile per noi aggiungerne un'altra. Basta assicurarsi di avere la volontà reale e la determinazione di tradurre ASF nella vostra lingua, prima di decidere di contattare con noi.

Per un elenco completo di tutte le lingue disponibili in cui ASF può essere tradotto in **[clicca qui](https://developer.crowdin.com/language-codes)**.

---

## Plurizzazione

Ogni lingua ha le proprie regole in materia di pluralizzazione. Queste regole possono essere trovate su **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** che ne specifica il numero e le condizioni linguistiche esatte.

Stiamo facendo del nostro meglio per offrirvi una localizzazione flessibile, e il più a lungo possibile, questo includerà anche le regole plurali. Ad esempio, oggi tradurremo la seguente stringa in polacco:

> Rilasciato {PLURAL:n<unk>{n} mese{n} mesi} fa

La parola chiave `PLURAL` qui è trattata in modo speciale in quanto consente di includere tutte le forme plurali che il tuo linguaggio supporta. Se date un'occhiata a CLDR, vedrete che in inglese ci sono solo 2 forme cardinali - "uno ", e "l'altro". E come si può vedere sopra, abbiamo entrambi quelli definiti - `{n} mese` e `{n} mesi`.

Tuttavia, la nostra lingua polacca in realtà include 4 di loro - "uno", "pochi", "molti" e "altro". Ciò significa che dovremmo definirne tutti per completamento. I nostri strumenti di localizzazione sono già abbastanza intelligenti per scegliere la forma plurale appropriata basata su regole linguistiche, quindi dovete solo definirli tutti nella traduzione:

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

In questo modo abbiamo definito tutte e 4 le forme plurali per la nostra lingua polacca, e poiché la nostra libreria di localizzazione conosce già le regole esatte, utilizzerà correttamente il modulo corretto per il numero `{n}`.

Non è obbligatorio definire tutte le forme plurali utilizzate dalla tua lingua. Se mancante, la nostra libreria di localizzazione userà l'ultimo modulo definito al suo posto. È una buona idea definire tutte le forme plurali utilizzate dalla tua lingua, ma in alcuni casi le forme plurali rimanenti potrebbero essere le stesse dell'ultima, nel qual caso non è necessario ripeterle. Nel nostro esempio sopra è stato obbligatorio, come "altro" forma in polacco per mesi è "miesia<unk> ca", e non "miesie<unk> cy" come in "molti".

---

## Wiki

La nostra piattaforma crowdin permette anche di localizzare anche la wiki stessa. Questo è uno strumento molto potente, poiché consente di creare un'intera documentazione di ASF nella tua lingua madre, risolvere efficacemente l'ultimo problema quando si tratta di localizzazione di ASF. Insieme alla traduzione del programma e di tutte le sue parti, questo rende la localizzazione completa.

Wiki è un po 'speciale a questo proposito, dal momento che è aiuto online dove non è necessario attenersi con la frase originale troppo. Questo significa che si vuole essere il più naturale possibile con il vostro linguaggio, e consegnare il significato originale e l'aiuto - non necessariamente bastone con stringhe originali, parole usate e punteggiatura effettiva. Non abbiate paura di riscrivere la corda in qualcosa di molto più naturale per la vostra lingua, fino a quando si mantiene la direzione generale e l'aiuto incluso nella frase.

---

### Link globali

La nostra piattaforma crowdin ti permette anche di adattare il testo originale per farla puntare a nuove posizioni (localizzate).

ASF include collegamenti su quasi tutte le pagine per una navigazione più semplice, così come la barra laterale sulla destra. Il fatto impressionante è che è possibile modificare tutto questo, "fissare" link per puntare a appropriate pagine localizzate per la vostra lingua. Richiede di essere un po 'attento a farlo, ma è possibile.

Ad esempio, ASF **[home page](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)** include un testo come:

> Se sei un nuovo utente, ti suggeriamo di iniziare dalla guida per la **[configurazione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)**.

Che è originariamente scritto come:

```markdown
Se sei un nuovo utente, ti consigliamo di iniziare con la guida **[installazione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)**.
```

Sul crowdin, la prima cosa che dovresti fare è andare alle impostazioni dell'editor e garantire che i tag HTML siano impostati su "Mostra" per te. Questo è molto importante se si decide di localizzare la wiki.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Ora, durante la traduzione sul crowdin, a seconda della formattazione, vedrete i collegamenti ASF nel testo come:

* Stringa da tradurre con i tag HTML (gran parte delle stringhe, dove solo una parte della frase è un collegamento)
* Da una sola stringa da tradurre, con link incluso in `Testi Nascosti` -> `Indirizzi di collegamento` (raro, dove tutta la stringa è un collegamento, più comune nella barra laterale - quelli richiedono l'accesso del revisore per tradurre, tristemente)

Nel nostro esempio sopra, è il primo caso (poiché solo "l'installazione" è un link), così in crowdin lo vedremo come:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Indipendentemente dal caso, in primo luogo si dovrebbe copiare la stringa sorgente e tradurla come al solito, lasciando intatto l'intero HTML (se presente). Questo sarebbe un esempio di traduzione per la lingua polacca:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Ora, se il link è un link generico che punta al di fuori della wiki (ad es. all'ultima versione di ASF), puoi lasciarla come è perché non vuoi modificarla. Puoi salvarlo e andare avanti.

Tuttavia, se il link **fa** punta più lontano all'interno della wiki, come quello sopra, si può effettivamente correggere per puntare alla nuova posizione (localizzato). Lo fai aggiungendo attentamente `-locale` all'URL di destinazione nel tag `<a>` , come di seguito:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Sii estremamente attento a questo, e assicurati che il tuo URL esista davvero, poiché se commetti un errore, quel link smetterà di funzionare. Se sei riuscito, ora hai una traduzione completamente funzionale con link che indica la traduzione (nel nostro caso `Setting-up-pl-PL`) pagina.

Facendo i passi precedenti tradurrà correttamente il nostro HTML di nuovo in markdown:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

E infine nel testo wiki:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

Quando non è presente HTML (secondo caso), questo è ancora più facile dal momento che si può solo andare a `testi nascosti` -> `Indirizzi di collegamento`.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

Da lì si può facilmente correggere il link per puntare alla nuova posizione, senza nemmeno preoccuparsi con HTML a tutti:

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Collegamenti locali

Attraverso la wiki troverete anche link locali che puntano a una particolare sezione del documento. Tali link includono il carattere `#` , indicando il browser web che dovrebbe muoversi verso quella sezione del documento.

Ora si tratta di casi particolari, poiché tali collegamenti si basano sui nomi delle sezioni del documento corrente. Mentre per gli URL abbiamo la convenzione generale di aggiungere `-locale` all'URL, e funziona ovunque, i nomi delle sezioni saranno tradotti da te e da altre persone, quindi è necessario assicurarsi che puntino alla posizione appropriata.

Ad esempio puoi trovare il link `#introduction` nella nostra sezione **[di configurazione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#introduction)**:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Dal momento che stiamo per tradurre la parola "Introduzione" in "Wprowadzenie" per la nostra lingua polacca, avremo bisogno di correggere questo link dal momento che smetterà di funzionare nel momento in cui lo facciamo.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

In questo modo il nostro link locale continuerà a funzionare, poiché ora punterà a nome della sezione che stiamo usando. Puoi correggere i link all'interno dei tag HTML esattamente nello stesso modo.

---

### Blocchi di codice

Fai molta attenzione quando traduci frasi con blocchi `<code></code>` all'interno. Il blocco di codice indica nomi di codice ASF fissi o termini che non dovrebbero essere tradotti. Per esempio:

> Questo è particolarmente utile se hai un sacco di chiavi da riscattare e sei garantito di colpire lo stato <code>RateLimited</code> prima di aver finito con il tuo intero lotto.

Come puoi vedere, la parola `RateLimited` qui è all'interno di un blocco di codice e indica lo stato interno del codice ASF che non dovrebbe essere tradotto. Allo stesso modo, non dovresti tradurre altri blocchi di codice, come i nomi delle proprietà di configurazione (es. `TradingPreferences`), i membri enum (e. . `Stabile` e `PreRelease` opzioni di `UpdateChannel`e simili.

Tuttavia, solo perché queste parole non dovrebbero essere tradotte, non significa che non è possibile aggiungere una traduzione appropriata accanto a loro, per esempio tra parentesi.

> Ta funkcja jest wyjątkowo użyteczna w przypadku aktywacji dużej ilości kluczy i gwarancji napotkania statusu <code>RateLimited</code> (zbyt częstej aktywacji) przed ukończeniem całej partii.

Come potete vedere sopra, abbiamo aggiunto "zbyt cze<unk> stej aktywacji", letteralmente "troppo spesso attivazione" accanto a `RateLimited` per tradurre questo stato in modo amichevole, mantenendo allo stesso tempo l'ASF originale significa che l'utente può vedere durante l'utilizzo del programma. Allo stesso modo è possibile tradurre/spiegare altri, casi simili di varie parole e frasi.

Se credi che qualcosa di inappropriato sia incluso in un blocco di codice, o che c'è un testo che non è in un blocco di codice, ma dovrebbe essere al suo interno, sentitevi liberi di chiedere sul nostro crowdin creando il problema **[appropriato](#issues)**. Questo è anche un esempio pratico di utilizzo di un collegamento locale.

---

## Sala di fama

Vorremmo mostrare la nostra eterna gratitudine alle persone che hanno speso una quantità significativa del loro tempo e la volontà di rendere migliore la localizzazione di ASF. Il loro sforzo è incredibile, e si può godere di traduzioni complete, compresa la wiki, soprattutto grazie a loro. Come segno di apprezzamento, a tutte le persone elencate qui viene offerto l'accesso gratuito alla funzionalità **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** su richiesta **[](https://crowdin.com/messages/create/13177432/240376)**.

| Collaboratore                                              | Lingue           |
| ---------------------------------------------------------- | ---------------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, Spagnolo |
| **[Dead_Sam](https://crowdin.com/profile/Dead_Sam)**       | Portoghese (BR)  |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | Cinese (CN)      |
| **[DragonTaki](https://crowdin.com/profile/dragontaki)**   | Cinese (TW)      |
| **[LittleFreak](https://crowdin.com/profile/littlefreak)** | Tedesco          |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | Russo, Ucraino   |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT, Tedesco  |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | Cinese (HK)      |

Grazie a tutti per aver migliorato la nostra qualità di localizzazione di ASF!