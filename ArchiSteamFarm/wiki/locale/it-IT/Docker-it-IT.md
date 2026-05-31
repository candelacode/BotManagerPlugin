# Docker

ASF è disponibile come **[docker container](https://www.docker.com/what-container)**. I nostri pacchetti docker sono attualmente disponibili su **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** e **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

È importante notare che l'esecuzione di ASF nel contenitore Docker è considerata la configurazione **avanzata**, che è **non necessario** per la stragrande maggioranza degli utenti, e tipicamente dà **nessun vantaggio** rispetto alla configurazione container-less . Se stai considerando Docker come una soluzione per eseguire ASF come servizio, ad esempio facendo iniziare automaticamente con il tuo sistema operativo, allora dovresti considerare la possibilità di leggere la sezione **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** e impostare un adeguato servizio `systemd` che sarà **quasi sempre** un'idea migliore rispetto all'esecuzione di ASF in un contenitore Docker.

L'esecuzione di ASF nel contenitore Docker di solito comporta **diversi nuovi problemi e problemi** che dovrai affrontare e risolvere te stesso. Questo è il motivo per cui **fortemente** ti consigliamo di evitarlo a meno che tu non abbia già conoscenze Docker e non abbia bisogno di aiuto per capire i suoi interni, su cui non elaboreremo qui su ASF wiki. Questa sezione è per lo più per casi di uso valido di configurazioni molto complesse, ad esempio per quanto riguarda la rete avanzata o la sicurezza oltre la sandboxing standard con cui ASF viene fornito nel servizio `systemd` (che già garantisce un isolamento di processo superiore attraverso meccaniche di sicurezza molto avanzate). Per quelle manciate quantità di persone, qui spieghiamo concetti di ASF migliori per quanto riguarda la sua compatibilità Docker, e solo questo, si suppone di avere un'adeguata conoscenza Docker se si decide di usarlo insieme con ASF.

---

## Tag

ASF è disponibile attraverso diversi tipi di tag **[](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `principale`

Generic build of ASF that is built from the very latest commit in `main` branch, che funziona come afferrare l'ultimo artefatto direttamente dalla nostra pipeline **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)**. È il più alto livello di software bugged dedicato a sviluppatori e utenti avanzati per scopi di sviluppo. L'immagine viene aggiornata con ogni commit nel ramo `main` di GitHub, quindi ci si può aspettare molto spesso cambiamenti (e roba rotta). È qui per segnare lo stato attuale del progetto ASF, che non è necessariamente garantito per essere stabile o testato, proprio come sottolineato nel nostro ciclo di rilascio. **Questo tag non dovrebbe essere utilizzato in nessun ambiente di produzione**. Utile per verificare se un particolare commit ha risolto il problema che stai incontrando, senza aspettare nemmeno una pre-release con quel commit.


### `rilasciato`

Generic build of ASF that always points to the latest **[released](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF version, including pre-releases. Rispetto al tag `` principale, l'immagine qui viene aggiornata ogni volta che viene premuto un nuovo tag GitHub. Dedicato agli utenti avanzati/di potenza che amano vivere sul bordo di ciò che può essere considerato stabile e fresco allo stesso tempo. In pratica, funziona come il tag di rotolamento che indica il più recente rilascio `A.B.C.D` al momento della tiratura. Si prega di notare che l'utilizzo di questo tag è uguale all'utilizzo delle nostre pre-release **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `stabile`

Generic build of ASF that always points to the latest **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** version ASF. Rispetto al tag `rilasciato` , l'immagine qui viene aggiornata una volta disponibile la nuova versione stabile di ASF. Consigliato per le persone che sono alla ricerca di una variante stabile del tag `rilasciato` menzionato sopra.

### `più recente`

Compilazione specifica dell'OS-di ASF che punta sempre all'ultima versione di ASF **[stabile](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. Rispetto ad altri, questo è il solo tag **** che include gli aggiornamenti automatici di ASF. L'obiettivo di questo tag è quello di fornire un sane contenitore Docker predefinito che è in grado di eseguire auto-aggiornamento, OS specifico build di ASF. Per questo motivo, l'immagine non deve essere aggiornata il più spesso possibile, la versione ASF inclusa sarà sempre in grado di aggiornarsi se necessario.

Naturalmente, `UpdatePeriod` può essere disattivato in modo sicuro (impostato su `0`), ma in questo caso si dovrebbe probabilmente utilizzare il rilascio `stabile` invece. Allo stesso modo, è possibile modificare il default `UpdateChannel` al fine di tenere traccia delle pre-release se si desidera.

A causa del fatto che l'immagine `ultima` viene fornito con la capacità di aggiornamenti automatici, include il sistema operativo nudo con la versione ASF `linux` specifica per OS, contrariamente a tutti gli altri tag che includono il sistema operativo con. ET runtime e versione `generica` ASF. Questo perché la versione più recente (aggiornata) di ASF potrebbe anche richiedere un runtime più recente di quello con cui l'immagine potrebbe essere costruita, che altrimenti richiederebbe di ricostruire l'immagine da zero, annullando il caso di utilizzo previsto.

### `A.B.C.D`

Generic build of ASF that points to the fixed ASF version matching the tag. Rispetto ai tag di cui sopra, questo tag è completamente congelato, il che significa che l'immagine qui non verrà aggiornata una volta pubblicata. Questo funziona come le nostre versioni GitHub che non vengono mai toccate dopo il rilascio iniziale, che ti garantisce un ambiente stabile e congelato. In genere si dovrebbe utilizzare questo tag quando si desidera utilizzare qualche rilascio specifico di ASF e aspettarsi un risultato deterministico della build (e. . gestire le versioni di ASF da sole).

---

## Quale tag è il migliore per me?

Dipende da quello che stai cercando. Per la maggior parte degli utenti, il tag `più recente` dovrebbe essere il migliore, in quanto offre esattamente ciò che fa il desktop ASF, solo in apposito contenitore Docker come servizio. Tuttavia, questo non è necessariamente come docker dovrebbe essere utilizzato - normalmente si prevede di ricostruire i contenitori e non eseguirli per sempre, e in questo caso dovresti considerare il tag `stable` o `rilasciato` , che seguono le linee guida del docker. Infine, se invece vuoi eseguire qualche versione fissa di ASF, le versioni naturalmente `A.B.C.D` sono quelle che stai cercando.

Generalmente scoraggiamo le build `main` , poiché sono qui per noi per segnare lo stato attuale del progetto ASF. Nulla garantisce che tale Stato funzioni correttamente, ma naturalmente siete più che benvenuti a dare loro una prova se siete interessati allo sviluppo di ASF.

---

## Architetture

ASF docker image è attualmente costruito su `linux` piattaforma target 3 architetture - `x64`, `armamento` e `armamento 64`. Puoi saperne di più su di essi nella sezione **[compatibilità](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**.

I nostri tag stanno utilizzando manifesto multi-piattaforma, il che significa che Docker installato sulla vostra macchina selezionerà automaticamente l'immagine corretta per la vostra piattaforma quando tirano l'immagine. Se per caso vuoi tirare una specifica immagine della piattaforma che non corrisponde a quella che stai correndo, puoi farlo tramite l'interruttore `--platform` nei comandi docker appropriati, come `docker esegui`. Vedi la documentazione docker su **[image manifest](https://docs.docker.com/registry/spec/manifest-v2-2)** per ulteriori informazioni.

---

## Uso

Per un riferimento completo dovresti utilizzare la documentazione **[ufficiale del docker](https://docs.docker.com/engine/reference/commandline/docker)**, copriremo solo l'utilizzo di base in questa guida, sei più che benvenuto a scavare più in profondità.

### Hello ASF!

In primo luogo dovremmo verificare se il nostro docker funziona anche correttamente, questo servirà da nostro ASF "ciao mondo":

```shell
docker run -it --name asf --pull sempre --rm justarchi/archisteamfarm
```

`docker run` crea un nuovo contenitore ASF docker per te e lo esegue in primo piano (`-it`). `--pull sempre` assicura che l'immagine aggiornata venga tirata prima, e `--rm` assicura che il nostro contenitore venga purificato una volta fermato, poiché stiamo solo testando se tutto funziona bene per ora.

Se tutto è terminato con successo, dopo aver tirato tutti i livelli e iniziato il contenitore, si deve notare che ASF correttamente avviato e ci ha informato che non ci sono bot definiti, che è buono - abbiamo verificato che ASF nel docker funziona correttamente. Premi `CTRL+C` per terminare il processo ASF e quindi anche il contenitore.

Se dai un'occhiata più da vicino al comando, noterai che non abbiamo dichiarato alcun tag, che ha automaticamente predefinito `ultimo` uno. Se vuoi usare un tag diverso da quello `più recente`, per esempio `rilasciato`, allora dovresti dichiararlo esplicitamente:

```shell
docker run -it --name asf --pull sempre --rm justarchi/archisteamfarm:released
```

---

## Usare un volume

Se stai usando ASF nel contenitore docker allora ovviamente è necessario configurare il programma stesso. Si può fare in vari modi, ma quella consigliata sarebbe quella di creare la directory di configurazione `di ASF` sulla macchina locale, quindi montarlo come volume condiviso in ASF docker container.

Ad esempio, supponiamo che la cartella di configurazione ASF sia in `/home/archi/ASF/config`. Questa directory contiene il core `ASF.json` e i bot che vogliamo eseguire. Ora tutto quello che dobbiamo fare è semplicemente allegare quella directory come volume condiviso nel nostro contenitore docker, dove ASF si aspetta la sua directory di configurazione (`/app/config`).

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull sempre justarchi/archisteamfarm
```

Ed è questo, ora il vostro contenitore docker ASF utilizzerà la directory condivisa con la macchina locale in modalità lettura-scrittura, che è tutto ciò di cui hai bisogno per configurare ASF. In modo simile, puoi montare altri volumi che desideri condividere con ASF, come `/app/logs` o `/app/plugins`.

Naturalmente, questo è solo un modo specifico per raggiungere ciò che vogliamo, niente vi impedisce ad es. creare il proprio file `Dockerfile` che copierà i file di configurazione nella directory `/app/config` all'interno del contenitore ASF docker. Stiamo solo coprendo l'utilizzo di base in questa guida.

### Autorizzazioni volume

ASF container per impostazione predefinita è inizializzato con utente `root` predefinito, che gli permette di gestire la roba dei permessi interni e poi passare all'utente `asf` (UID `1000`) per la parte rimanente del processo principale. Mentre questo dovrebbe essere soddisfacente per la stragrande maggioranza degli utenti, influisce sul volume condiviso in quanto i file appena generati saranno normalmente di proprietà dell'utente `asf` , che potrebbe non essere desiderato situazione se desideri qualche altro utente per il tuo volume condiviso.

Ci sono due modi per cambiare l'utente ASF è in esecuzione sotto. Il primo, raccomandato, è quello di dichiarare la variabile di ambiente `ASF_UID` con UID di destinazione che si desidera eseguire sotto. In secondo luogo, alternativa, è quello di passare `--user` **[flag](https://docs.docker.com/engine/reference/run/#user)**, che è direttamente supportato dal docker.

Puoi controllare il tuo `uid` ad esempio con il comando `id -u` , quindi dichiararlo come specificato sopra. Ad esempio, se il tuo utente di destinazione ha `uid` di 1001:

```shell
docker run -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull sempre justarchi/archisteamfarm

# In alternativa, se si capiscono le limitazioni sotto
docker run -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull sempre justarchi/archisteamfarm
```

La differenza tra il flag `ASF_UID` e `--user` è sottile, ma importante. `ASF_UID` è un meccanismo personalizzato supportato da ASF, in questo scenario il contenitore docker inizia ancora come `root`, e quindi lo script di avvio di ASF avvia binario principale sotto `ASF_UID`. Quando usi il flag `--user` , stai avviando l'intero processo, incluso lo script di avvio di ASF come utente dato. La prima opzione permette allo script di avvio di ASF di gestire automaticamente i permessi e altre cose per te, risolvendo alcuni problemi comuni che potresti aver causato, ad esempio assicura che le tue directory `/app` e `/asf` siano effettivamente di proprietà di `ASF_UID`. Nel secondo scenario, poiché non siamo in esecuzione come `root`, non possiamo farlo, e ti aspettiamo di gestire tutto ciò in anticipo.

Se hai deciso di utilizzare il flag `--user` , è necessario modificare la proprietà di tutti i file ASF da `1000` predefinito al nuovo utente personalizzato. È possibile farlo eseguendo il comando qui sotto:

```shell
# Esegui solo se non stai usando ASF_UID
docker exec -u root asf_container_name chown -hR 1001 /app /asf
```

Questo deve essere fatto solo una volta che hai creato il tuo contenitore con `docker run`, e solo se hai deciso di utilizzare il flag docker `--user`. Inoltre non dimenticare di cambiare l'argomento `1001` nel comando sopra al `UID` che vuoi eseguire ASF sotto.

### Volume con SELinux

Se stai usando SELinux in stato forzato sul tuo sistema operativo, che è il valore predefinito per esempio nelle distanze basate su RHEL, quindi dovresti montare l'opzione `:Z` che imposterà il corretto contesto SELinux per esso.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull sempre justarchi/archisteamfarm
```

Questo permetterà a ASF di creare file di destinazione mentre il volume è all'interno del contenitore docker.

---

## Sincronizzazione di istanze multiple

ASF include il supporto per la sincronizzazione di istanze multiple, come indicato nella sezione **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)**. Quando si esegue ASF nel contenitore docker, è possibile opzionalmente "opt-in" nel processo, nel caso in cui stai eseguendo più contenitori con ASF e vorresti che si sincronizzassero tra loro.

Per impostazione predefinita, ogni ASF in esecuzione all'interno di un contenitore docker è standalone, il che significa che non ha luogo alcuna sincronizzazione. Per abilitare la sincronizzazione tra di loro, è necessario associare il percorso `/tmp/ASF` in ogni contenitore ASF che si desidera sincronizzare, a uno, percorso condiviso sul tuo host docker, in modalità lettura-scrittura. Questo si ottiene esattamente come legare un volume che è stato descritto sopra, solo con percorsi diversi:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull sempre justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull sempre justarchi/archisteamfarm
# E così via, tutti i contenitori ASF sono ora sincronizzati tra loro
```

Consigliamo di associare la directory `/tmp/ASF` di ASF anche a una directory `/tmp` temporanea sulla tua macchina, ma ovviamente sei libero di scegliere qualsiasi altro che soddisfi il tuo utilizzo. Ogni contenitore ASF che dovrebbe essere sincronizzato dovrebbe avere la sua directory `/tmp/ASF` condivisa con altri contenitori che partecipano allo stesso processo di sincronizzazione.

Come probabilmente avete indovinato dall'esempio sopra, è anche possibile creare due o più "gruppi di sincronizzazione", legando diversi percorsi host docker in ASF `/tmp/ASF`.

Il montaggio `/tmp/ASF` è completamente opzionale e in realtà non è raccomandato, a meno che non si voglia esplicitamente sincronizzare due o più contenitori ASF. Non consigliamo di montare `/tmp/ASF` per un singolo contenitore, in quanto porta assolutamente nessun beneficio se si prevede di eseguire un solo contenitore ASF, e potrebbe effettivamente causare problemi che altrimenti potrebbero essere evitati.

---

## Argomenti della riga di comando

ASF ti permette di passare gli argomenti **[da riga di comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** nel contenitore docker attraverso le variabili d'ambiente. Dovresti usare variabili di ambiente specifiche per gli switch supportati e `ASF_ARGS` per il resto. Questo può essere ottenuto con l'interruttore `-e` aggiunto all'esecuzione `docker`, per esempio:

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull sempre justarchi/archisteamfarm
```

Questo passerà correttamente il tuo argomento `--cryptkey` al processo ASF in esecuzione all'interno del contenitore docker, così come altri args. Naturalmente, se sei utente avanzato, puoi anche modificare `ENTRYPOINT` o aggiungere `CMD` e passare i tuoi argomenti personalizzati da solo.

A meno che non si desidera fornire chiave di crittografia personalizzata o altre opzioni avanzate, di solito non è necessario includere alcuna variabile di ambiente speciale, poiché i nostri contenitori docker sono già configurati per essere eseguiti con una sane opzione predefinita di `--no-restart`, in modo che il contrassegno non debba essere specificato esplicitamente in `ASF_ARGS`.

---

## IPC

Supponendo di non aver modificato il valore predefinito per `IPC` **[proprietà globale di configurazione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, è già abilitato. Tuttavia, è necessario fare altre due cose per IPC per lavorare nel contenitore Docker. In primo luogo, è necessario utilizzare `IPCPassword` o modificare `KnownNetworks` predefinito in IPC `personalizzato. onfig` ti permette di connetterti dall'esterno senza usarne uno. A meno che tu non sappia davvero cosa stai facendo, usa `IPCPassword`. In secondo luogo, è necessario modificare l'indirizzo di ascolto predefinito di `localhost`, poiché docker non può instradare al di fuori del traffico verso l'interfaccia di loopback. Un esempio di un'impostazione che ascolterà su tutte le interfacce sarebbe `http://*:1242`. Naturalmente, è anche possibile utilizzare vincolanti più restrittivi, come LAN locale o rete VPN, ma deve essere un percorso accessibile dall'esterno - `localhost` non lo farà, poiché il percorso è interamente all'interno della macchina per gli ospiti.

Per fare quanto sopra dovresti usare la configurazione **[personalizzata di IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** come quella seguente:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Una volta che abbiamo impostato IPC su interfaccia non-loopback, dobbiamo dire al docker di mappare la porta `1242/tcp` di ASF con `-P` o `-p`.

Ad esempio, questo comando esporrebbe l'interfaccia ASF IPC alla macchina host (solo):

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull sempre justarchi/archisteamfarm
```

Se si imposta tutto correttamente, `docker esegue il comando` sopra farà funzionare l'interfaccia **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** dalla tua macchina ospite, sullo standard `localhost:1242` percorso che è ora correttamente reindirizzato alla tua macchina ospite. E 'anche bello notare che non esponiamo ulteriormente questo percorso, così la connessione può essere fatta solo all'interno del docker host, e quindi mantenerla sicura. Naturalmente, è possibile esporre ulteriormente il percorso se si sa cosa si sta facendo e garantire misure di sicurezza adeguate.

---

### Esempio completo

Combinando tutta la conoscenza sopra, un esempio di una configurazione completa assomiglia a questo:

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull sempre --restart unless-stopped justarchi/archisteamfarm
```

Questo presuppone che si utilizzi un singolo contenitore ASF, con tutti i file di configurazione ASF in `/home/archi/ASF/config`. È necessario modificare il percorso di configurazione di quello che corrisponde alla macchina. È anche possibile fornire plugin personalizzati per ASF, che è possibile inserire in `/home/archi/ASF/plugins`. Questa configurazione è anche pronta per l'uso IPC opzionale se hai deciso di includere `IPC. onfig` nella tua cartella di configurazione con un contenuto come sotto:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

È possibile ottenere lo stesso effetto di `docker eseguire il comando` sopra utilizzando il seguente `docker compose` config:

```yaml
versione: "3. "
services:
  asf:
    image: justarchi/archisteamfarm
    container_name: asf
    restart: unless-stopped
    ports:
      - "127. .0.1:1242:1242"
      - "[::1]:1242:1242"
    volumi:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

Da cose diverse da quelle già discusse sopra, abbiamo aggiunto `--restart senza sosta` ad entrambi gli esempi sopra per avviare automaticamente questo contenitore dopo il riavvio della macchina. Sentitevi liberi di rimuoverlo / cambiarlo secondo le vostre esigenze.

---

## Pro tips

Quando hai già pronto il tuo contenitore ASF docker, non devi usare il docker `esegui` ogni volta. Puoi facilmente fermare/avviare il contenitore ASF docker con `docker stop asf` e `docker start asf`. Tieni presente che se non stai usando il tag `più recente` allora l'utilizzo di ASF aggiornato richiederà ancora da te a `docker stop`, `docker rm` e `docker eseguono nuovamente`. Questo perché è necessario ricostruire il contenitore da una nuova immagine docker ASF ogni volta che si desidera utilizzare la versione ASF inclusa in quella immagine. Nell'ultimo tag `` , ASF ha incluso la capacità di auto-aggiornamento se stesso, così ricostruire l'immagine non è necessario per utilizzare ASF aggiornato (ma è ancora una buona idea farlo di tanto in tanto per poter utilizzare fresco. Dipendenze di runtime ET e il sistema operativo sottostante, che potrebbero essere necessarie quando si salta attraverso i principali aggiornamenti della versione di ASF).

Come accennato sopra, ASF in tag diverso da `ultima` non si aggiornerà automaticamente da solo, il che significa che **tu** sei incaricato di utilizzare l'aggiornamento `justarchi/archisteamfarm` repo. Questo ha molti vantaggi come tipicamente l'app non dovrebbe toccare il proprio codice durante l'esecuzione, ma comprendiamo anche la comodità che viene da non doversi preoccupare della versione di ASF nel vostro contenitore docker. Se ti interessa le buone pratiche e l'uso corretto del docker, Il tag `rilasciato` è quello che suggeriamo invece di `più recente`, ma se non si può essere infastiditi con esso e si vuole solo fare ASF sia lavoro e auto-aggiornamento se stesso, poi `ultima` lo farà.

In genere dovresti eseguire ASF nel contenitore docker con l'impostazione globale `Headless: true`. Questo dirà chiaramente a ASF che non sei qui per fornire i dettagli mancanti e non dovrebbe chiedere per quelli. Of course, for initial setup you should consider leaving that option at `false` so you can easily set up things, but in long-run you're typically not attached to ASF console, therefore it'd make sense to inform ASF about that and use `input` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** if need arises. In questo modo ASF non dovrà aspettare infinitamente l'input dell'utente che non accadrà (e sprecherà risorse mentre lo fanno). Permetterà inoltre a ASF di funzionare in modalità non interattiva all'interno del contenitore, il che è cruciale per es. per quanto riguarda la trasmissione dei segnali, che consente a ASF di chiudere con grazia su `docker stop asf` richiesta.