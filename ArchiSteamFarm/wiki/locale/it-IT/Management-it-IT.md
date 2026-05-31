# Gestione

Questa sezione riguarda i temi relativi alla gestione ottimale del processo di ASF. Anche se non strettamente obbligatorio per l'uso, include un sacco di suggerimenti, trucchi e buone pratiche che vorremmo condividere, in particolare per gli amministratori di sistema, le persone che imballano l'ASF per l'utilizzo in archivi di terze parti, così come gli utenti avanzati e simili.

---

## Servizio `systemd` per Linux

Nelle varianti `generiche` e `linux` , ASF viene fornito con `ArchiSteamFarm@. ervice` file, che è un file di configurazione del servizio per **[`systemd`](https://systemd.io)**. Se si desidera eseguire ASF come servizio, ad esempio per avviarlo automaticamente dopo l'avvio della macchina, quindi un adeguato servizio `systemd` è probabilmente il modo migliore per farlo, quindi lo consigliamo vivamente invece di gestirlo da solo tramite `nohup`, `screen` o simili.

In primo luogo, creare l'account per l'utente che si desidera eseguire ASF sotto, supponendo che non esista ancora. Utilizzeremo l'utente `asf` per questo esempio, se hai deciso di usarne uno diverso, dovrai sostituire l'utente `asf` in tutti i nostri esempi qui sotto con quello selezionato. Il nostro servizio non consente di eseguire ASF come `root`, dal momento che è considerato un **[cattivo pratica](#never-run-asf-as-administrator)**.

```sh
su # O sudo -i, per entrare nella shell radice
useradd -m asf # Crea un account che intendi eseguire ASF sotto
```

Successivamente, scompattare la cartella `/home/asf/ArchiSteamFarm`. La struttura delle cartelle è importante per la nostra unità di servizio, dovrebbe essere la cartella `ArchiSteamFarm` nella tua `$HOME`, so `/home/<user>`. Se hai fatto tutto correttamente, ci sarà un file esistente `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service`. Se stai usando la variante `linux` e non hai scompattato il file su Linux, ma per esempio hai usato il trasferimento di file da Windows, allora avrai anche bisogno di `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

Faremo tutte le seguenti azioni come `root`, quindi arriveremo alla sua shell con `su` o `sudo -i`.

In primo luogo è una buona idea assicurarsi che la nostra cartella appartenga ancora al nostro utente `asf` , `chown -hR asf:asf /home/asf/ArchiSteamFarm` eseguito una volta lo farà. I permessi potrebbero essere errati, ad esempio se hai scaricato e/o disimballato il file zip come `root`.

In secondo luogo, se stai usando variante generica di ASF, è necessario assicurarsi che il comando `dotnet` sia riconosciuto e all'interno di una delle posizioni standard: `/usr/local/bin`, `/usr/bin` o `/bin`. Questo è richiesto per il nostro servizio systemd che esegue il comando `dotnet /path/to/ArchiSteamFarm.dll`. Controlla se `dotnet --info` funziona per te, se sì, digita `command -v dotnet` per scoprire dove si trova. Se hai usato l'installatore ufficiale, dovrebbe essere in `/usr/bin/dotnet` o in una delle altre due posizioni, il che è giusto. Se è in posizione personalizzata come `/usr/share/dotnet/dotnet`, crea un **[collegamento simbolico](https://wikipedia.org/wiki/Symbolic_link)** per esso utilizzando `ln -s "$(command -v dotnet)" /usr/bin/dotnet`. Ora `command -v dotnet` dovrebbe segnalare `/usr/bin/dotnet`, che farà funzionare anche la nostra unità systemd. Se stai usando una variante specifica per il sistema operativo, non devi fare nulla a questo proposito.

Successivamente, esegui `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/systemd/system/ArchiSteamFarm\@. ervice`, questo creerà un link simbolico alla nostra dichiarazione di servizio e la registrerà nel sistema ``. Il collegamento simbolico permetterà a ASF di aggiornare automaticamente la tua unità `systemd` come parte dell'aggiornamento di ASF - a seconda della tua situazione, potresti voler utilizzare questo approccio, o semplicemente `cp` il file e gestirlo tu stesso come vuoi.

In seguito, assicurati che `systemd` riconosca il nostro servizio:

```
systemctl status ArchiSteamFarm@asf

<unk> ArchiSteamFarm@asf.service - ArchiSteamFarm Service (su asf)
     Caricato: caricato (/etc/systemd/system/ArchiSteamFarm@. ervice; disabled; vendor preset: enabled)
     Active: inactive (dead)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Prestare particolare attenzione all'utente che dichiariamo dopo `@`, è `asf` nel nostro caso. La nostra unità di servizio di sistema si aspetta da voi per dichiarare l'utente, in quanto influenza il luogo esatto del binario `/home/<user>/ArchiSteamFarm`, così come il sistema utente reale genererà il processo come.

Se il sistema ha restituito l'output simile a sopra, tutto è in ordine, e siamo quasi finiti. Ora tutto quello che resta sta iniziando il nostro servizio come nostro utente scelto: `systemctl avvia ArchiSteamFarm@asf`. Aspetta un secondo o due, e puoi controllare di nuovo lo stato:

```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (su asf)
     Caricato: caricato (/etc/systemd/system/ArchiSteamFarm@.service; disabilitato; vendor preset: abilitato)
     Active: active (running) since (...)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   Main PID: (...)
(...)
```

If `systemd` states `active (running)`, significa che tutto è andato bene, e si può verificare che il processo di ASF dovrebbe essere in funzione, per esempio con `journalctl -r`, come ASF di default scrive anche sul suo output di console, which is recorded by `systemd`. Se sei soddisfatto della configurazione che hai in questo momento, puoi dire al sistema `` di avviare automaticamente il servizio durante l'avvio, eseguendo il comando `systemctl abilita il comando ArchiSteamFarm@asf`. È tutto.

Se per caso desideri interrompere il processo, esegui semplicemente il sistema `stop ArchiSteamFarm@asf`. Allo stesso modo, se si desidera disattivare ASF da avviare automaticamente all'avvio, `systemctl disabilita ArchiSteamFarm@asf` lo farà per te, è molto semplice.

Si prega di notare che, poiché non esiste un input standard abilitato per il nostro servizio `systemd` , non sarai in grado di inserire i tuoi dettagli attraverso la console in modo abituale. L'esecuzione attraverso `systemd` equivale a specificare l'impostazione **[`Headless: true`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** e viene fornita con tutte le sue implicazioni. Fortunatamente per te, è molto facile gestire il tuo ASF tramite **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, che consigliamo nel caso in cui sia necessario fornire ulteriori dettagli durante il login o in altro modo gestire ulteriormente il processo di ASF.

### Variabili di ambiente

È possibile fornire ulteriori variabili di ambiente al nostro servizio `systemd` , che ti interessa fare nel caso in cui vuoi per esempio utilizzare un argomento a riga di comando `--cryptkey` **[personalizzato](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**, pertanto specificando la variabile di ambiente `ASF_CRYPTKEY`.

Al fine di fornire variabili di ambiente personalizzate, crea una cartella `/etc/asf` (nel caso in cui non esista), `mkdir -p /etc/asf`. Si consiglia di `chown -hR root:root /etc/asf && chmod 700 /etc/asf` per garantire che solo l'utente `root` abbia accesso a leggere questi file, perché potrebbero contenere proprietà sensibili come `ASF_CRYPTKEY`. In seguito, scrivi su un file `/etc/asf/<user>` , dove `<user>` è l'utente che stai eseguendo il servizio sotto (`asf` nel nostro esempio sopra, so `/etc/asf/asf`).

Il file dovrebbe contenere tutte le variabili di ambiente che si desidera fornire al processo. Quelli che non hanno una variabile di ambiente dedicata, possono essere dichiarati in `ASF_ARGS`:

```sh
# Dichiara solo quelli di cui hai bisogno
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# E tutti gli altri a cui sei interessato
```

### Sovrascrivendo parte dell'unità di servizio

Grazie alla flessibilità di `systemd`, è possibile sovrascrivere parte dell'unità ASF pur conservando il file di unità originale e consentendo ad ASF di aggiornarlo ad esempio come parte degli aggiornamenti automatici.

In questo esempio, vorremmo modificare il comportamento predefinito dell'unità ASF `systemd` dal riavvio solo al successo, al riavvio anche in caso di crash fatali. A tal fine, override `Restart` property under `[Service]` from default of `on-success` to `always`. Basta eseguire `systemctl modificare ArchiSteamFarm@asf`, sostituendo naturalmente `asf` con l'utente di destinazione del servizio. Quindi aggiungi le modifiche come indicato dal sistema `` nella sezione appropriata:

```sh
### Modifica /etc/systemd/system/ArchiSteamFarm@asf.service.d/override. onf
### Qualsiasi cosa tra qui e il commento qui sotto diventerà il nuovo contenuto del file

[Service]
Restart=always

### Linee sotto questo commento sarà scartata

### /etc/systemd/system/ArchiSteamFarm@asf. ervice
# [Install]
# WantedBy=multi-utente. arget
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm. ll --no-restart --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# User=%i
# (...)
```

Ed è così, ora la tua unità agisce come se avesse solo `Restart=always` under `[Service]`.

Naturalmente, l'alternativa è quella di `cp` il file e gestirlo da soli, ma questo ti permette di apportare modifiche flessibili anche se hai deciso di mantenere l'unità originale di ASF, ad esempio con un **[symlink](https://wikipedia.org/wiki/Symbolic_link)**.

---

## Non eseguire mai ASF come amministratore!

ASF include la propria convalida se il processo è in esecuzione come amministratore (`root`) oppure no. L'esecuzione come `root` è **non** richiesta per qualsiasi tipo di operazione eseguita dal processo di ASF, supponendo che l'ambiente correttamente configurato in cui sta operando, e quindi dovrebbe essere considerato come una **cattiva pratica**. Ciò significa che su Windows, ASF dovrebbe **mai** essere eseguito con l'impostazione "run as administrator", e su Unix ASF dovrebbe avere un account utente **dedicato** per sé, o riutilizzare il proprio in caso di un sistema desktop.

Per ulteriori approfondimenti su *perché* scoraggiamo l'esecuzione di ASF come `root`, fare riferimento al superutente **[](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** e ad altre risorse. Se non sei ancora convinto, chiedi cosa succederà alla tua macchina se il comando ASF è stato eseguito subito dopo il suo lancio con il comando `rm -rf /*`.

### Eseguo come `root` perché ASF non può scrivere sui suoi file

Ciò significa che hai erroneamente configurato i permessi dei file ASF sta tentando di accedere. Dovresti effettuare il login come account `root` (sia con `su` o `sudo -i`) e poi **correggere** le autorizzazioni emettendo il comando `chown -hR asf:asf /path/to/ASF` , sostituendo `asf:asf` con l'utente che eseguirai ASF sotto, e `/path/to/ASF` di conseguenza. Se per caso stai usando una `personalizzata --path` che dice all'utente di ASF di usare la diversa directory, si dovrebbe eseguire nuovamente lo stesso comando per quel percorso pure.

Dopo aver fatto, non si dovrebbe più ottenere alcun tipo di problema relativo a ASF non essere in grado di scrivere sui propri file, dato che hai appena cambiato il proprietario di tutto ciò che ASF è interessato all'utente il processo di ASF sarà effettivamente eseguito sotto.

### Corro come `root` perché non so come farlo altrimenti

```sh
su # O sudo -i, per entrare nella shell radice
useradd -m asf # Crea un account che intendi eseguire ASF sotto
chown -hR asf:asf /path/to/ASF # Assicurati che il tuo nuovo utente abbia accesso alla directory ASF
su asf -c /path/to/ASF/ArchiSteamFarm # Oppure sudo -u asf /path/to/ASF/ArchiSteamFarm, per avviare effettivamente il programma sotto il tuo utente
```

Questo lo farebbe manualmente, è molto più facile usare il nostro servizio **[`systemd`](#systemd-service-for-linux)** spiegato sopra.

### So meglio e voglio ancora funzionare come `root`

ASF non ti impedisce di farlo con forza, visualizza solo un avviso con un breve preavviso. Basta non essere scioccato se un giorno a causa di un bug nel programma farà esplodere l'intero sistema operativo con la perdita completa di dati - sei stato avvisato.

---

## Istanze multiple

ASF è compatibile con l'esecuzione di più istanze del processo sulla stessa macchina. Le istanze possono essere completamente indipendenti o derivate dalla stessa posizione binaria (in questo caso, vuoi eseguirli con diversi argomenti `--path` **[da riga di comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**).

Quando si eseguono più istanze dallo stesso binario, tieni presente che in genere dovresti disabilitare gli aggiornamenti automatici in tutte le loro configurazioni, poiché non c'è sincronizzazione tra di loro per quanto riguarda gli aggiornamenti automatici. Se si desidera continuare ad avere gli aggiornamenti automatici abilitati, si consiglia le istanze standalone, ma puoi ancora fare funzionare gli aggiornamenti, purché tu possa assicurarti che tutte le altre istanze di ASF siano chiuse.

ASF farà del suo meglio per mantenere una quantità minima di OS, comunicazione cross-process con altre istanze di ASF. Questo include ASF controllando la sua directory di configurazione contro altre istanze, oltre a condividere i limitatori a livello di processo configurati con `*LimiterDelay` **[global config properties](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, garantire che l'esecuzione di più istanze di ASF non causi la possibilità di incorrere in un problema di limitazione della velocità. Per quanto riguarda gli aspetti tecnici, tutte le piattaforme utilizzano il nostro meccanismo dedicato di serrature personalizzate basate su file ASF create in directory temporanea, che è `C:\Users\<YourUser>\AppData\Local\Temp\ASF` su Windows, e `/tmp/ASF` su Unix.

Non è necessario eseguire istanze ASF per condividere le stesse proprietà `*LimiterDelay` , possono usare valori diversi, in quanto ogni ASF aggiungerà il proprio ritardo configurato al tempo di rilascio dopo l'acquisizione del blocco. Se la configurata `*LimiterDelay` è impostata su `0`, L'istanza di ASF salterà completamente in attesa del blocco di una data risorsa che viene condivisa con altre istanze (che potrebbe potenzialmente mantenere un blocco condiviso l'uno con l'altro). Se impostato su qualsiasi altro valore, ASF si sincronizza correttamente con altre istanze di ASF e attende il suo turno, poi rilasciare il blocco dopo il ritardo configurato, consentendo ad altre istanze di continuare.

ASF tiene conto dell'impostazione `WebProxy` quando si decide su ambito condiviso, il che significa che due istanze di ASF che utilizzano diverse configurazioni di `WebProxy` non condivideranno i loro limitatori l'uno con l'altro. Questo è implementato al fine di consentire alle impostazioni `WebProxy` di funzionare senza ritardi eccessivi, come previsto da diverse interfacce di rete. Questo dovrebbe essere abbastanza buono per la maggior parte dei casi di utilizzo, tuttavia, se si dispone di una specifica configurazione personalizzata in cui siete, ad es. routing richiede te stesso in un modo diverso, puoi specificare tu stesso il gruppo di rete tramite l'argomento `--network-group` **[da riga di comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**, che vi permetterà di dichiarare il gruppo ASF che sarà sincronizzato con questa istanza. Tieni presente che i gruppi di rete personalizzati sono usati esclusivamente, il che significa che ASF non userà più `WebProxy` per determinare il gruppo giusto, siccome sei responsabile del raggruppamento in questo caso.

Se desideri utilizzare il nostro servizio **[`systemd`](#systemd-service-for-linux)** spiegato sopra per più istanze di ASF, è molto semplice, basta usare un altro utente per la nostra `ArchiSteamFarm@` dichiarazione di servizio e seguire con il resto dei passaggi. Questo sarà equivalente all'esecuzione di più istanze ASF con binari distinti, in modo che possano anche auto-aggiornamento e funzionare indipendentemente l'uno dall'altro.