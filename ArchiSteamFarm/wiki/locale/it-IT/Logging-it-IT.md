# Registrazione

ASF ti permette di configurare il tuo modulo di registrazione personalizzato che verrà utilizzato durante l'esecuzione. Puoi farlo inserendo un file speciale chiamato `NLog.config` nella directory dell'applicazione. È possibile leggere l'intera documentazione di NLog on **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**, ma in aggiunta a questo troverete alcuni esempi utili anche qui.

---

## Registrazione predefinita

Per impostazione predefinita, ASF sta registrando `ColoredConsole` (output standard) e `File`. La registrazione del file `` include il file `log.txt` nella directory del programma e la directory `logs` per scopi di archivio.

Utilizzando la configurazione personalizzata di NLog disabilita automaticamente la configurazione predefinita di ASF, la tua configurazione sovrascrive **completamente** la registrazione predefinita di ASF, il che significa che se vuoi mantenere e. . il nostro obiettivo `ColoredConsole` , quindi è necessario definirlo **te stesso**. Questo consente non solo di aggiungere **extra** obiettivi di registrazione, ma anche disabilitare o modificare **quelli predefiniti**.

Se si desidera utilizzare la registrazione predefinita di ASF senza alcuna modifica, non è necessario fare nulla - non è necessario definirlo in personalizzato `NLog. onfig`. Tuttavia, per riferimento l'equivalente della registrazione predefinita di ASF codificata in formato rigido sarebbe:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir:cached=true}/logs/log.txt" archiveOldFileOnStartup="true" archiveSuffixFormat=".{1:yyyyMMdd-HHmmss}" fileName="${currentdir:cached=true}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- Below becomes active when ASF's IPC interface is started -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="File" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- Below becomes active when ASF's IPC interface is enabled -->
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="History" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## Integrazione con ASF

ASF include alcuni bei trucchi di codice che migliorano la sua integrazione con NLog, consentendo di catturare messaggi specifici più facilmente.

La variabile `${logger}` specifica NLog distinguerà sempre la fonte del messaggio - sarà `BotName` di uno dei tuoi bot, o `ASF` se il messaggio proviene direttamente dal processo ASF. In questo modo è possibile catturare facilmente i messaggi considerando bot specifici, o processo ASF (solo), invece di tutti loro, in base al nome del logger.

ASF cerca di contrassegnare i messaggi in modo appropriato in base ai livelli di registrazione forniti da NLog, che consente di catturare solo messaggi specifici da specifici livelli di log invece di tutti. Naturalmente, il livello di registrazione per messaggi specifici non può essere personalizzato, in quanto è la decisione hardcoded di ASF quanto sia serio il messaggio dato, ma è sicuramente possibile rendere ASF meno / più silenzioso, come si vede in forma.

ASF registra informazioni extra, come i messaggi utente/chat sul livello di registrazione `Trace`. Registri di registrazione ASF predefiniti solo livello `Debug` e superiore, che nasconde tali informazioni aggiuntive, in quanto non è necessario per la maggior parte degli utenti, più l'uscita clutters contenente messaggi potenzialmente più importanti. È tuttavia possibile utilizzare tali informazioni riabilitando il livello di registrazione `Trace` , soprattutto in combinazione con la registrazione di un solo bot specifico a tua scelta, con particolare evento che ti interessa.

In generale, ASF cerca di rendere il più facile e conveniente per voi possibile, per registrare solo i messaggi che vuoi invece di forzarti a filtrarli manualmente attraverso strumenti di terze parti come `grep` e simili. Semplicemente configura NLog correttamente come scritto di seguito, e si dovrebbe essere in grado di specificare anche regole di registrazione molto complesse con obiettivi personalizzati come interi database.

Per quanto riguarda il versioning - ASF cerca di spedire sempre con la versione più aggiornata di NLog disponibile su **[NuGet](https://www.nuget.org/packages/NLog)** al momento del rilascio di ASF. Non dovrebbe essere un problema usare qualsiasi funzionalità che puoi trovare su NLog wiki in ASF - assicurati di usare anche ASF aggiornato.

Come parte dell'integrazione di ASF, ASF include anche il supporto per ulteriori obiettivi di registrazione NLog di ASF, che verranno spiegati di seguito.

---

## Esempi

Esempi qui sotto ti mostrano come puoi personalizzare la registrazione a tuo piacimento.

Come antipasto useremo solo il target **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)**. Il nostro `iniziale NLog.config` sarà così:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

La spiegazione della configurazione precedente è piuttosto semplice - definiamo un obiettivo di registrazione ****, che è `ColoredConsole`, poi reindirizziamo **tutti i logger** (`*`) del livello `Debug` e superiore al target `ColoredConsole` che abbiamo definito prima.

Se si avvia ASF con sopra `NLog. onfig` ora, solo il target `ColoredConsole` sarà attivo, e ASF non scriverà su `File`, indipendentemente dalla configurazione di ASF NLog codificata.

Dal momento che non abbiamo definito molte proprietà, come il layout ``, è stato inizializzato ad un valore predefinito incorporato, in questo caso `${longdate}<unk> ${level:uppercase=true}<unk>${logger}<unk>${message}`. Possiamo personalizzarlo, ad esempio registrando il solo messaggio:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Se avvii ASF ora, noterai quella data, il livello e il nome del logger sono scomparsi - lasciandoti solo con i messaggi ASF in formato `Function() Message`.

Possiamo anche modificare la configurazione per accedere a più di un obiettivo. Registriamo contemporaneamente `ColoredConsole` e **[`File`](https://github.com/nlog/nlog/wiki/File-target)**.

```xml
<?xml version="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Debug" writeTo="File" />
  </rules>
</nlog>
```

E fatto, ora registreremo tutto su `ColoredConsole` e `File`. Did you notice that you can also specify custom `fileName` and extra options?

Infine, ASF utilizza vari livelli di log, per rendere più facile per voi capire cosa sta succedendo. Possiamo utilizzare tali informazioni per modificare la registrazione di gravità. Diciamo che vogliamo registrare tutto (`Trace`) su `File`, ma solo `Avviso` e oltre **[log level](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** alla `ColoredConsole`. Possiamo ottenere questo risultato modificando le nostre regole ``:

```xml
<?xml version="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Warn" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Trace" writeTo="File" />
  </rules>
</nlog>
```

Questo è questo, ora la nostra `ColoredConsole` mostrerà solo gli avvisi e sopra, mentre ancora la registrazione di tutto su `File`. È possibile modificare ulteriormente per accedere ad esempio solo `Info` e sotto, e così via.

Infine, facciamo qualcosa di un po 'più avanzato e registrare tutti i messaggi a file, ma solo dal bot di nome `LogBot`.

```xml
<?xml version="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="LogBotFile" fileName="${currentdir:cached=true}/LogBot.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="LogBot" minlevel="Trace" writeTo="LogBotFile" />
  </rules>
</nlog>
```

Puoi vedere come abbiamo usato l'integrazione di ASF sopra e facilmente distinguibile sorgente del messaggio in base alla proprietà `${logger}`.

---

## Utilizzo avanzato

Gli esempi di cui sopra sono piuttosto semplici e fatti per mostrarti quanto sia facile definire le tue regole di registrazione che possono essere usate con ASF. È possibile utilizzare NLog per varie cose, tra cui obiettivi complessi (come mantenere i log nel database ``), rotazione log (come rimuovere i vecchi log `File` , usando `Layout`personalizzati, dichiarando i tuoi filtri di registrazione `<when>` e molto altro. Ti incoraggio a leggere tutta la documentazione **[di NLog](https://github.com/nlog/nlog/wiki/Configuration-file)** per conoscere ogni opzione disponibile per te, ti permette di affinare il modulo di registrazione ASF nel modo che vuoi. È uno strumento davvero potente e personalizzare la registrazione di ASF non è mai stato più facile.

---

## Limitazioni

ASF disabiliterà temporaneamente **tutte le regole** che includono i target `ColoredConsole` o `Console` quando si prevede di inserire l'utente. Pertanto, se si desidera mantenere la registrazione per altri obiettivi anche quando ASF prevede input utente, è necessario definire tali obiettivi con le proprie regole, come mostrato negli esempi precedenti, invece di mettere molti obiettivi in `writeTo` della stessa regola (a meno che questo non sia il tuo comportamento desiderato). La disattivazione temporanea degli obiettivi della console viene effettuata per mantenere la console pulita durante l'attesa dell'input dell'utente.

---

## Registrazione chat

ASF include il supporto esteso per la registrazione della chat non solo registrando tutti i messaggi ricevuti / inviati sul livello di registrazione `Trace` , ma anche esporre informazioni extra relative a loro in **[proprietà evento](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Questo perché abbiamo bisogno di gestire i messaggi di chat come comandi comunque, quindi non ci costa nulla per registrare questi eventi al fine di rendere possibile per voi di aggiungere una logica extra (come fare ASF il vostro archivio di chat Steam personale).

### Proprietà evento

| Nome        | Descrizione                                                                                                                                                                                                                         |
| ----------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Eco         | Tipo `bool`. Questo è impostato su `true` quando il messaggio viene inviato da noi al destinatario, e `false` altrimenti.                                                                                                           |
| Messaggio   | Tipo della stringa ``. Questo è il messaggio inviato/ricevuto.                                                                                                                                                                      |
| ChatGroupID | `ulong` type. Questo è l'ID della chat di gruppo per i messaggi inviati/ricevuti. Sarà `0` quando non viene utilizzata una chat di gruppo per trasmettere questo messaggio.                                                         |
| ChatID      | `ulong` type. Questo è l'ID del canale `ChatGroupID` per i messaggi inviati/ricevuti. Sarà `0` quando non viene utilizzata una chat di gruppo per trasmettere questo messaggio.                                                     |
| SteamID     | `ulong` type. Questo è l'ID dell'utente Steam per i messaggi inviati/ricevuti. Può essere `0` quando nessun utente particolare è coinvolto nella trasmissione dei messaggi (e. . quando inviamo un messaggio a una chat di gruppo). |

### Esempio

Questo esempio è basato sul nostro esempio di base `ColoredConsole` sopra. Prima di cercare di capirlo, Raccomando vivamente di dare un'occhiata **[sopra](#examples)** per conoscere prima le basi della registrazione di NLog.

```xml
<?xml version="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="ChatLogFile" fileName="${currentdir:cached=true}/logs/chat/${event-properties:item=ChatGroupID}-${event-properties:item=ChatID}${when:when='${event-properties:item=ChatGroupID}' == 0:inner=-${event-properties:item=SteamID}}.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss} ${event-properties:item=Message} ${when:when='${event-properties:item=Echo}' == true:inner=-&gt;:else=&lt;-} ${event-properties:item=SteamID}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="MainAccount" level="Trace" writeTo="ChatLogFile">
      <filters defaultAction="Log">
        <when condition="not starts-with('${message}','OnIncoming') and not starts-with('${message}','SendMessage')" action="Ignore" />
      </filters>
    </logger>
  </rules>
</nlog>
```

Abbiamo iniziato dal nostro esempio di base `ColoredConsole` e lo abbiamo esteso ulteriormente. In primo luogo, abbiamo preparato un file di log di chat permanente per ogni canale di gruppo e utente di Steam - questo è possibile grazie alle proprietà extra che ASF ci espone in modo elegante. Abbiamo anche deciso di andare con un layout personalizzato che scrive solo la data corrente, il messaggio, le informazioni inviate/ricevute e l'utente stesso di Steam. Infine, abbiamo abilitato la nostra regola di registrazione della chat solo per il livello `Trace` , solo per il nostro bot `MainAccount` e solo per le funzioni relative alla registrazione delle chat (`OnIncoming*` che viene utilizzato per ricevere messaggi ed eco, e `SendMessage*` per l'invio di messaggi ASF).

L'esempio sopra genererà il file `logs/chat/0-0-76561198069026042.txt` quando si parla con **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 come state facendo? -> 76561198069026042
2018-07-26 01:38:38 Sto facendo benissimo, che dire di te? <- 76561198069026042
```

Naturalmente questo è solo un esempio di lavoro con alcuni bei trucchi di layout mostrati in modo pratico. È possibile espandere ulteriormente questa idea alle proprie esigenze, come filtraggio extra, ordine personalizzato, layout personale, registrazione solo messaggi ricevuti e così via.

### Un altro esempio

Questo usa `SteamTarget` per inviare un messaggio all'ID steamID del bot principale (`76561198006963719`) quando il bot chiamato `archi` riceve un commercio di donazioni. Richiede un altro bot nel processo (poiché non puoi inviare messaggi a te stesso).

```xml
<?xml version="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" />
  </targets>

  <rules>
    <logger name="archi" level="Trace" writeTo="Steam">
      <filters defaultAction="Ignore">
        <when condition="starts-with('${message}','ParseTrade() Accepted donation trade: ')" action="Log" />
      </filters>
    </logger>
  </rules>
</nlog>
```

---

## Obiettivi di ASF

Oltre agli obiettivi di registrazione NLog standard (come `ColoredConsole` e `File` spiegati sopra), è anche possibile utilizzare obiettivi di registrazione ASF personalizzati.

Per la massima completezza, la definizione degli obiettivi di ASF seguirà la convenzione di documentazione NLog.

---

### SteamTarget

Come puoi indovinare, questo obiettivo utilizza i messaggi di chat di Steam per registrare i messaggi di ASF. È possibile configurarlo per utilizzare una chat di gruppo o una chat privata. Oltre a specificare un obiettivo Steam per i tuoi messaggi, puoi anche specificare il botName `` del bot che dovrebbe inviare quelli.

Supportato in tutti gli ambienti utilizzati da ASF.

---

#### Sintassi Di Configurazione
```xml
<targets>
  <target type="Steam"
          name="String"
          layout="Layout"
          chatGroupID="Ulong"
          steamID="Ulong"
          botName="Layout" />
</targets>
```

Per saperne di più sull'utilizzo del file di configurazione [](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametri

##### Opzioni Generali
_nome_ - Nome del bersaglio.

---

##### Opzioni Di Layout
_layout_ - Testo da renderizzare. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Richiesto. Default: `${level:uppercase=true}<unk>${logger}<unk>${message}`

---

##### Opzioni SteamTarget

_chatGroupID_ - ID della chat di gruppo ha dichiarato un intero senza firma a 64 bit. Non richiesto. Il valore predefinito è `0` che disabiliterà le funzionalità di chat di gruppo e utilizzerà invece la chat privata. Quando abilitato (imposta a valore diverso da zero), La proprietà `steamID` di seguito agisce come `chatID` e specifica l'ID del canale in questo `chatGroupID` a cui il bot dovrebbe inviare messaggi.

_steamID_ - SteamID ha dichiarato un intero non firmato a 64 bit dell'utente Steam di destinazione (come `SteamOwnerID`), o destinazione `chatID` (quando `chatGroupID` è impostato). Obbligatorio. Il valore predefinito è `0` che disabilita completamente la registrazione.

_botName_ - Nome del bot (come riconosciuto da ASF, case-sensitive) che invierà messaggi a `steamID` dichiarato sopra. Non richiesto. Predefiniti a `null` che selezionerà automaticamente **qualsiasi bot** attualmente connesso. Si raccomanda di impostare questo valore in modo appropriato, poiché `SteamTarget` non tiene conto di molte limitazioni di Steam, ad esempio il fatto che devi avere `steamID` del target sulla tua lista di amici. Questa variabile è definita come tipo [layout](https://github.com/NLog/NLog/wiki/Layouts) , quindi puoi usare una sintassi speciale, come `${logger}` per utilizzare il bot che ha generato il messaggio.

---

#### Esempi Di SteamTarget

Per scrivere tutti i messaggi del livello `Debug` e oltre, dal bot chiamato `MyBot` al SteamID di `76561198006963719`, dovresti usare `NLog. onfig` simile a sotto:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**Avviso:** Il nostro `SteamTarget` è un obiettivo personalizzato, quindi dovresti assicurarti di dichiararlo come `type="Steam"`, NON `xsi:type="Steam"`, in quanto xsi è riservato per gli obiettivi ufficiali supportati da NLog.

Quando avvii ASF con `NLog. onfig` simile a sopra, `MyBot` inizierà la messaggistica `76561198006963719` Utente di Steam con tutti i soliti messaggi di registro di ASF. Tieni presente che `MyBot` deve essere connesso per inviare messaggi, quindi tutti i messaggi ASF iniziali che sono avvenuti prima che il nostro bot potesse connettersi alla rete di Steam, non saranno inoltrati.

Naturalmente, `SteamTarget` ha tutte le funzioni tipiche che ci si può aspettare dal generico `TargetWithLayout`, in modo da poter utilizzarlo in combinazione con e. . layout personalizzati, nomi o regole avanzate di registrazione. L'esempio di cui sopra è solo quello più basilare.

---

#### Screenshot

![Screenshot](https://i.imgur.com/5juKHMt.png)

---

#### Caveat

Fai attenzione quando decidi di combinare il livello di registrazione `Debug` o inferiore nel tuo `SteamTarget` con `steamID` che partecipa al processo ASF. Questo può portare a potenziali `StackOverflowException` perché creerai un ciclo infinito di ASF che riceve il messaggio dato, quindi registrarlo tramite Steam, con conseguente un altro messaggio che deve essere registrato. Attualmente l'unica possibilità per accadere è di registrare il livello `Trace` (dove ASF registra i propri messaggi di chat), o livello `Debug` durante l'esecuzione di ASF in modalità `Debug` (dove ASF registra tutti i pacchetti Steam).

In breve, se il tuo `steamID` sta partecipando allo stesso processo di ASF, quindi il livello di registrazione `minlevel` del tuo `SteamTarget` dovrebbe essere `Info` (o `Debug` se non stai anche eseguendo ASF in `Debug` mode) e superiore. In alternativa puoi definire i tuoi filtri di registrazione `<when>` per evitare un ciclo di registrazione infinito, se modificare il livello non è appropriato per il vostro caso. Questa avvertenza si applica anche alle chat di gruppo.

---

### HistoryTarget

Questo obiettivo viene utilizzato internamente da ASF per fornire la cronologia di registrazione a dimensione fissa nell'endpoint `/Api/NLog` di **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** che può essere successivamente consumato da ASF-ui e da altri strumenti. In generale si dovrebbe definire questo obiettivo solo se si sta già utilizzando configurazione NLog personalizzata per altre personalizzazioni e si desidera anche che il registro sia esposto in ASF API, e. . per ASF-ui. Può anche essere dichiarato quando si desidera modificare il layout predefinito o `maxCount` dei messaggi salvati.

Supportato in tutti gli ambienti utilizzati da ASF.

---

#### Sintassi Di Configurazione
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Per saperne di più sull'utilizzo del file di configurazione [](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametri

##### Opzioni Generali
_nome_ - Nome del bersaglio.

---

##### Opzioni Di Layout
_layout_ - Testo da renderizzare. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Richiesto. Default: `${date:format=yyyy-MM-dd HH\:mm\:ss}<unk>${processname}-${processid}<unk> ${level:uppercase=true}<unk>${logger}<unk>${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### Opzioni StoryTarget

_maxCount_ - Quantità massima di log memorizzati per la cronologia su richiesta. Non richiesto. Predefinito a `20` che è un buon equilibrio per fornire la storia iniziale, mantenendo ancora a mente l'utilizzo della memoria che esce dai requisiti di archiviazione. Deve essere maggiore di `0`.