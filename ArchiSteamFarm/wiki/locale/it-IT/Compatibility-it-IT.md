# Compatibilità

ASF è un'applicazione C# in esecuzione sulla piattaforma .NET. Ciò significa che ASF non è compilato direttamente nel codice **[](https://en.wikipedia.org/wiki/Machine_code)** che è in esecuzione sulla tua CPU, ma in **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)** che richiede un runtime compatibile CIL-per eseguirlo.

Questo approccio ha una grande quantità di vantaggi, in quanto CIL è indipendente dalla piattaforma, che è il motivo per cui ASF può funzionare nativamente su molti sistemi operativi disponibili, in particolare Windows, Linux e macOS. Non c'è solo bisogno di emulazione, ma anche supporto per tutte le ottimizzazioni relative alla piattaforma e all'hardware, come le istruzioni per CPU SSE. Grazie a ciò, ASF può ottenere prestazioni e ottimizzazione superiori, pur offrendo una perfetta compatibilità e affidabilità.

Ciò significa anche che ASF ha **nessun requisito specifico del sistema operativo**, perché richiede di lavorare **runtime** su quel sistema operativo e non il sistema operativo stesso. Fino a quando quel runtime esegue il codice ASF correttamente, non importa se il sistema operativo sottostante è Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii o il tuo tostapane - finché c'è **[. ET for it](https://dotnet.microsoft.com/download/dotnet)**, c'è **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** per esso (in `generico` variante).

Tuttavia, indipendentemente da dove si esegue ASF, è necessario assicurarsi che la piattaforma di destinazione ha **[.NET prerequisiti](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installati. Queste sono librerie di basso livello necessarie per una corretta funzionalità runtime e assolutamente core per ASF per funzionare in primo luogo. Molto probabilmente si possono avere alcuni di loro (o anche tutti) già installati.

---

## Imballaggio di ASF

ASF è disponibile in 2 principali sapori - pacchetto generico e OS-specific. In senso funzionale, entrambi i pacchetti sono esattamente gli stessi, entrambi sono in grado di aggiornare automaticamente se stessi. L'unica differenza tra loro è se ASF **generico** pacchetto viene fornito anche con **OS-specific** runtime per alimentarlo.

---

### Generico

Il pacchetto generico è build platform-agnostic che non include alcun codice specifico della macchina. Questa configurazione richiede che tu abbia .NET runtime già installato sul tuo OS **nella versione** appropriata. Sappiamo tutti quanto sia difficile mantenere aggiornate le dipendenze, quindi questo pacchetto è qui principalmente per le persone che **già usano** . ET e non vogliono duplicare il loro runtime solo per ASF se possono utilizzare quello che hanno già installato. Pacchetto generico consente anche di eseguire ASF **ovunque, a condizione che sia possibile ottenere l'implementazione funzionante di . ET runtime**, indipendentemente dal fatto che esista una versione ASF specifica per il sistema operativo, oppure no.

Non è consigliabile utilizzare il sapore generico se sei utente casual o anche avanzato che vuole solo fare il lavoro di ASF e non scavare dentro . Dettagli tecnici ET. In altre parole - se sai cosa questo è, puoi usarlo, altrimenti è molto meglio utilizzare un pacchetto specifico per il sistema operativo spiegato di seguito.

---

### Specifico all'OS

Il pacchetto specifico per OS, oltre al codice gestito incluso nel pacchetto generico, include anche il codice nativo per una data piattaforma. In altre parole, il pacchetto **specifico per il sistema operativo include già un pacchetto corretto. ET runtime dentro**, che consente di saltare completamente l'intero pasticcio di installazione e lanciare ASF direttamente. Pacchetto specifico OS, come si può intuire dal nome, è specifico per il sistema operativo e ogni sistema operativo richiede la propria versione - per esempio Windows richiede PE32+ `ArchiSteamFarm. xe` binario mentre Linux funziona con il binario Unix ELF `ArchiSteamFarm`. Come forse sapete, questi due tipi non sono compatibili tra loro.

ASF è attualmente disponibile nelle seguenti varianti specifiche per OS:

- `linux-arm` funziona su sistemi operativi a 32 bit basati su ARM (ARMv7+) GNU/Linux con glibc 2.35/musl 1.2.3 e successivi. Questa variante copre piattaforme come Raspberry Pi 2 (e più recente), **non** funziona con vecchie architetture ARM, come ARMv6 trovato in Raspberry Pi 0 & 1, inoltre non funzionerà con i sistemi operativi che non implementano l'ambiente GNU/Linux richiesto (come Android).
- `linux-arm64` funziona su sistemi operativi GNU/Linux basati su 64 bit ARM (ARMv8+) con glibc 2.27/musl 1.2.3 e successivi. Questa variante copre piattaforme come Raspberry Pi 3 (e più recenti), **non** funziona con sistemi operativi a 32 bit che non hanno richiesto librerie a 64 bit disponibili (come il Raspberry Pi OS a 32 bit), inoltre non funzionerà con i sistemi operativi che non implementano l'ambiente GNU/Linux richiesto (come Android).
- `linux-x64` funziona su sistemi operativi GNU/Linux a 64 bit con glibc 2.27/musl 1.2.3 e successivi.
- `osx-arm64` funziona su OS macOS a 64 bit basati su ARM (silicone Apple) nella versione 13 e versioni successive.
- `osx-x64` funziona su Mac OS a 64 bit nella versione 15 e versioni successive.
- `win-arm64` funziona su **up-to-date** 64-bit ARM basato (ARMv8+) sistemi operativi Windows nella versione 10, 11 e versioni successive.
- `win-x64` funziona su **up-to-date** 64-bit Windows OS nella versione 10, 11, Server 2016+ e versioni successive.

Naturalmente, anche se non si dispone di un pacchetto specifico per il sistema operativo disponibile per la combinazione di architettura OS, è sempre possibile installare appropriato. ET runtime te stesso ed eseguire il sapore generico di ASF, che è anche il motivo principale per cui esiste in primo luogo. Generico ASF build è platform-agnostic e funzionerà su qualsiasi piattaforma che ha un funzionamento .NET runtime. Questo è importante da notare - ASF richiede .NET runtime, non alcuni specifici OS o architettura. Ad esempio, se stai eseguendo Windows a 32 bit, nonostante nessuna versione di ASF dedicata `win-x86` , puoi ancora installare. ET SDK in `versione win-x86` ed esegui ASF generico appena bene. Semplicemente non possiamo mirare ad ogni combinazione OS-architettura che esiste ed è usata da qualcuno, quindi dobbiamo tracciare una linea da qualche parte. x86 è un buon esempio di quella linea, poiché è un'architettura obsoleta almeno dal 2004.

Per un elenco completo di tutte le piattaforme e i sistemi operativi supportati da .NET 10.0, visita le note di rilascio **[](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md)**.

---

## Requisiti di runtime

Se stai usando un pacchetto specifico per il sistema operativo, non devi preoccuparti dei requisiti di runtime, perché ASF navi sempre con tempi di esecuzione richiesti e aggiornati che funzioneranno correttamente finché hai **[. ET prerequisiti](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installati e aggiornati. In altre parole, **non è necessario installare . ET runtime o SDK**, poiché le build specifiche per il sistema operativo richiedono solo dipendenze native del sistema operativo (prerequisiti) e nient'altro.

Tuttavia, se stai cercando di eseguire il pacchetto **generico** ASF, devi assicurarti che il runtime .NET supporti la piattaforma richiesta da ASF.

ASF come programma è targeting **.NET 10.0** (`net10.`) in questo momento, ma potrebbe mirare alla nuova piattaforma in futuro. `net10.0` è supportato dal 10.0.100 SDK (10.0. runtime), anche se ASF potrebbe preferire **ultima esecuzione al momento della compilazione**, quindi dovresti assicurarti di avere **[SDK](https://dotnet.microsoft.com/download)** (o almeno il tempo di esecuzione) disponibile per la tua macchina. La variante generica di ASF può rifiutarsi di avviare se il runtime è più vecchio del minimo specificato supportato durante la compilazione.

In caso di dubbio, controlla cosa la nostra integrazione continua **[utilizza](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** per compilare e distribuire le versioni di ASF su GitHub. Puoi trovare l'output `dotnet --info` in ogni build come parte della fase di verifica .NET.