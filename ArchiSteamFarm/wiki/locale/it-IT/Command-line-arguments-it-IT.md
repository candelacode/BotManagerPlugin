# Argomenti della riga di comando

ASF include supporto per differenti argomenti della linea di comando che può influire sui tempi di esecuzione del programma. Questi possono essere usati da utenti avanzati per poter specificare come dovrebbe essere eseguito il programma. In confronto al modo predefinito del file di configurazione `ASF.json`, gli argomenti della linea di comando sono usati per l'inizializzazione del core (es. `--path`), le impostazioni specifiche della piattaforma (es.: `--systemrequired`) o i dati sensibili (es.: `--cryptkey`).

---

## Uso

L'uso dipende dal tuo sistema operativo e dal flavour di ASF.

Generico:

```shell
dotnet ArchiSteamFarm.dll --argument --otherOne
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --otherOne
```

Gli argomenti della linea di comando sono anche supportati negli script di aiuto generici come `ArchiSteamFarm.cmd` o `ArchiSteamFarm.sh`. Inoltre, è anche possibile utilizzare la proprietà d'ambiente `ASF_ARGS`, come indicato nelle nostre sezioni **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** e **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)**.

Se il tuo argomento include spazi, non dimenticarti di citarlo. Questi due sono sbagliati:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Bad!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Bad!
```

Tuttavia, queste due vanno completamente bene:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Argomenti

`--cryptkey <key>` o `--cryptkey=<key>`, avvieranno ASF con la chiave crittografica personalizzata di valore `<key>`. Quest'opzione influenza la **[sicurezza](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** e causerà ad ASF di usare la tua chiave personalizzata `<key>` fornita invece di quella predefinita codificata nell'eseguibile. Poiché questa proprietà influisce sulla chiave di crittografia predefinita (per scopi di crittografia) e sul salt (per scopi di hash), si tenga a mente che tutto quello che viene cifrato/hashato con questa chiave richiederà che sia trasmessa ad ogni esecuzione di ASF.

La lunghezza o i caratteri `<key>` non sono richiesti, ma per motivi di sicurezza si consiglia di scegliere abbastanza lungo passphrase fatta di e. . a caso 32 caratteri, ad esempio utilizzando `tr -dc A-Za-z0-9 < /dev/urandom <unk> head -c 32; comando echo` su Linux.

È bello ricordare che ci sono anche altri due modi per fornire questo dettaglio: `--cryptkey-file` e `--input-cryptkey`.

A causa della natura di questa proprietà, è anche possibile impostare la chiave crittografica dichiarando la variabile ambientale `ASF_CRYPTKEY`, che potrebbe esser più appropriata per le persone che vorrebbero evitare i dettagli sensibili negli argomenti del processo.

---

`--cryptkey-file <path>` o `--cryptkey-file=<path>` - avvierà ASF con chiave crittografica personalizzata letta dal file `<path>`. Questo serve lo stesso scopo di `--cryptkey <key>` spiegato sopra, solo il meccanismo differisce, poiché questa proprietà leggerà `<key>` dalla `<path>` fornita. Se lo stai usando insieme a `--path`, considerare il fatto che il percorso relativo sarà diverso a seconda dell'ordine degli argomenti, i. . se cambi `--path` prima o dopo `--cryptkey-file`.

A causa della natura di questa proprietà, è anche possibile impostare il file criptkey dichiarando `ASF_CRYPTKEY_FILE` variabile d'ambiente, che può essere più appropriato per le persone che vorrebbero evitare dettagli sensibili nelle discussioni di processo.

---

`--ignore-unsupported-environment`, causerà l'ignoramento del rilevamento degli ambienti non supportati di ASF, che normalmente è segnalato con un errore e l'uscita forzata. L'ambiente non supportato include ad esempio l'esecuzione di `win-x64` specifica per l'OS-build su `linux-x64`. Mentre questo parametro permetterà a ASF di provare a essere eseguito in tali scenari, avvisiamo che non lo supportiamo ufficialmente e stai costringendo ASF a eseguito interamente **a tuo rischio e pericolo**. È importante sottolineare che **all** degli scenari ambientali **non supportati può essere corretto**. Raccomandiamo vivamente di risolvere i problemi in sospeso invece di usare questo parametro.

---

`--input-cryptkey` - farà chiedere a ASF circa `--cryptkey` durante l'avvio. Questa opzione potrebbe essere utile per te se invece di fornire cryptkey, sia nelle variabili di ambiente o in un file, preferisci non averlo salvato da nessuna parte e invece inserirlo manualmente su ogni esecuzione di ASF.

---

`--minimized` - farà minimizzare la finestra della console ASF poco dopo l'avvio. Utile soprattutto negli scenari di avvio automatico, ma può anche essere utilizzato al di fuori di quelli. Questa opzione richiede un adeguato supporto ambientale - potrebbe non funzionare correttamente in tutti gli scenari possibili.

---

`--network-group <group>` o `--network-group=<group>` - causerà ASF l'inizializzazione dei suoi limitatori con un gruppo di rete personalizzato con valore `<group>`. Questa opzione influisce sull'esecuzione di ASF in **[istanze multiple](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** segnalando che la data istanza dipende solo dalle istanze che condividono lo stesso gruppo di rete, e indipendente dal resto. In genere vuoi usare questa proprietà solo se stai instradando le richieste di ASF attraverso un meccanismo personalizzato (ad es. indirizzi IP diversi) e si desidera impostare gruppi di rete da soli, senza fare affidamento su ASF per farlo automaticamente (che attualmente include prendendo in considerazione `WebProxy` soltanto). Tieni presente che quando si utilizza un gruppo di rete personalizzato, si tratta di un identificatore univoco all'interno della macchina locale, e ASF non terrà conto di altri dettagli, come ad esempio il valore `WebProxy`, che consente di per esempio avviare due istanze con diversi valori `WebProxy` che sono ancora dipendenti l'uno dall'altro.

A causa della natura di questa proprietà, è anche possibile impostare il valore dichiarando `ASF_NETWORK_GROUP` variabile d'ambiente, che può essere più appropriato per le persone che vorrebbero evitare dettagli sensibili nelle discussioni di processo.

---

`--no-config-migrate` - di default ASF migrerà automaticamente i file di configurazione all'ultima sintassi. La migrazione include la conversione di proprietà deprecate in quelle più recenti, rimuovendo proprietà con valori predefiniti (poiché non hanno effetto), così come la pulizia del file in generale (correzione indentazione e allo stesso modo). Questa è quasi sempre una buona idea, ma si potrebbe avere una situazione particolare in cui preferiresti che ASF non sovrascriva mai automaticamente i file di configurazione. Ad esempio, potresti voler `chmod 400` i tuoi file di configurazione (i permessi di lettura solo per il proprietario) o mettere `chattr +i` su di loro, in conseguenza negare l'accesso in scrittura per tutti, per esempio come misura di sicurezza. Di solito si consiglia di mantenere attiva la migrazione di configurazione, ma se hai un motivo particolare per disabilitarlo e preferiresti invece che ASF non lo faccia, è possibile utilizzare questo interruttore per raggiungere questo scopo. Tenete a mente però che fornire impostazioni corrette per ASF diventerà d'ora in poi la vostra nuova responsabilità, in particolare per quanto riguarda deprecazioni e refattori di proprietà nelle versioni future di ASF.

---

`--no-config-watch` - di default ASF imposta un `FileSystemWatcher` sulla tua `cartella di configurazione` per ascoltare gli eventi relativi alle modifiche dei file, in modo che possa adattarsi interattivamente a loro. Ad esempio, questo include l'arresto dei bot durante l'eliminazione della configurazione, il riavvio del bot sulla configurazione in corso di modifica, o caricando i tasti in **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** una volta che li rilasci nella cartella `config`. Questo interruttore consente di disabilitare tale comportamento, che causerà ASF di ignorare completamente tutte le modifiche nella directory `config` , richiedere all'utente di eseguire tali azioni manualmente, se ritenuto appropriato (che di solito significa riavviare il processo). Si consiglia di mantenere attivati gli eventi di configurazione, ma se avete un motivo particolare per disabilitarli e preferirei invece ASF a non farlo, è possibile utilizzare questo interruttore per raggiungere questo scopo.

---

`--no-restart` - di default ASF segue **[`AutoRestart`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#autorestart)** proprietà di configurazione, che puoi usare per specificare se il riavvio è consentito quando necessario. Alcune soluzioni che forniamo prendono in carico la gestione dei processi e sono esplicitamente incompatibili con la funzione di riavvio automatico di ASF, come ad esempio l'esecuzione di ASF in `docker` o `systemd`, in quanto richiedono il processo di uscita solo, in quanto è loro responsabilità di riavviarlo dopo, se ritenuto appropriato. Dal momento che la modifica arbitraria della configurazione è indesiderata dall'esperienza utente, questo interruttore sovrascrive semplicemente la proprietà di configurazione `AutoRestart` inizializzandola esplicitamente a `false`, anche se hai specificato diversamente nella configurazione. Grazie a ciò, ASF può essere informato in anticipo circa il funzionamento in tale ambiente, senza il requisito di fornire un file di configurazione `AutoRestart compatibile: false`.

In aggiunta a quanto sopra, `--no-restart`, in contrasto con `AutoRestart: false`, ti impedirà inoltre di utilizzare il comando `di riavvio` o di rilasciare altrimenti il processo ASF per il riavvio, poiché l'interruttore dichiara esplicitamente che non è compatibile con tale configurazione, mentre la proprietà `AutoRestart` specifica solo il comportamento predefinito.

Normalmente è possibile (e dovrebbe) controllare il comportamento spiegato qui nel file di configurazione, anche se stai eseguendo ASF all'interno di uno script personalizzato o di un altro ambiente simile, potresti anche voler fare uso di questo interruttore, che impedirà a ASF di riavviare se stesso.

---

`--no-steam-parental-generation` - di default ASF tenterà automaticamente di generare i PIN parentali di Steam, come descritto nella proprietà di configurazione **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)**. Tuttavia, poiché ciò potrebbe richiedere una quantità eccessiva di risorse del sistema operativo, questo interruttore consente di disabilitare tale comportamento, che si tradurrà in ASF saltare la generazione automatica e andare direttamente a chiedere l'utente per il PIN invece, che è ciò che normalmente accadrebbe solo se la generazione automatica non è riuscita. Di solito consigliamo di mantenere abilitata la generazione, ma se avete un motivo particolare per disabilitarlo e preferirei invece ASF a non farlo, è possibile utilizzare questo interruttore per raggiungere questo scopo.

---

`--path <path>` o `--path=<path>` - ASF naviga sempre alla propria directory all'avvio. Specificando questo argomento, ASF si sposterà alla directory data dopo l'inizializzazione, che ti permette di utilizzare un percorso personalizzato per varie parti delle applicazioni (tra cui `config`, `log`, `plugin` e `directory www` , così come `NLog. file onfig` ), senza bisogno di duplicare binario nello stesso posto. Potrebbe venire particolarmente utile se si desidera separare binario dalla configurazione attuale, come è fatto nel packaging simile a Linux: in questo modo è possibile utilizzare un binario (aggiornato) con diverse configurazioni. Il percorso può essere relativo in base al luogo corrente di ASF binario, o assoluto. Tieni presente che questo comando punta alla nuova "casa di ASF" - la directory che ha la stessa struttura di ASF originale, con la directory `config` all'interno, vedi l'esempio sottostante per spiegazioni.

A causa della natura di questa proprietà, è anche possibile impostare il percorso atteso dichiarando la variabile di ambiente `ASF_PATH` , che può essere più appropriato per le persone che vorrebbero evitare dettagli sensibili nelle discussioni di processo.

Se stai valutando di utilizzare questo argomento a riga di comando per eseguire più istanze di ASF, in questo modo consigliamo di leggere la nostra pagina di gestione **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)**.

Esempi:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Absolute path
dotnet /opt/ASF/ArchiSteamFarm.dll --path ../TargetDirectory # Relative path works as well
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # Same as env variable
```

```text
├l’articolo 4📁 /opt
l’articolo 4📁 ASF
l’articolo 7:00:gear: ArchiSteamFarm.dll
l’articolo 7...
<unk> <unk> <unk> <unk> <unk> 📁 TargetDirectory
<unk> <unk> <unk> <unk> <unk> <unk> 📁 config
<unk> <unk> <unk> <unk> <unk> 📁 logs (generato)
<unk> <unk> <unk> <unk> <unk> <unk> 📁 plugins (opzionali)
<unk> <unk> <unk> <unk> <unk> <unk> <unk> 📁 www (opzionale)
<unk> <unk> <unk> <unk> <unk> <unk> 📄 log. xt (generato)
l’onorevole Afee 📄 NLog.config (facoltativo)
l’allegato A...
```

---

`--service` - questo interruttore viene utilizzato principalmente dal nostro servizio `systemd` e dalle forze `Headless` di `true`. A meno che tu non abbia una particolare necessità, dovresti invece configurare la proprietà `Headless` direttamente nella tua configurazione. Questo interruttore è qui per cui il nostro servizio `systemd` non avrà bisogno di toccare la tua configurazione globale per adattarla al proprio ambiente. Naturalmente, se avete un bisogno simile, allora si può anche fare uso di questo interruttore (altrimenti è meglio con la proprietà di configurazione globale).

---

`--system-required` - dichiarare questo interruttore farà sì che ASF provi a segnalare al sistema operativo che il processo richiede che il sistema sia attivo e funzionante per tutta la sua durata. Questo può essere dimostrato particolarmente utile quando l'agricoltura sul vostro PC o computer portatile durante la notte, come ASF sarà in grado di mantenere il sistema attivo mentre è in esecuzione. Questa funzione è attualmente supportata su Linux e Windows.

Su Linux, avrai bisogno di utilizzare correttamente la funzione **[dbus](https://en.wikipedia.org/wiki/D-Bus)** con il demone di accesso che supporta la funzione **[`Inhibit()`](https://systemd.io/INHIBITOR_LOCKS/)**. Due demoni più popolari, `systemd` e `elogind`sono confermati per supportarlo. La maggior parte degli ambienti desktop (come Gnome o KDE) dovrebbe funzionare fuori dalla casella, in quanto già dipendono da questa funzionalità per le loro proprie esigenze.

Nessun requisito speciale su Windows, dovrebbe lavorare fuori dalla scatola.