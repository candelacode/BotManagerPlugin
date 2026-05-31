# IPC

ASF include la propria interfaccia IPC unica che può essere utilizzata per ulteriori interazioni con il processo. IPC sta per **[comunicazione interprocesso](https://en.wikipedia.org/wiki/Inter-process_communication)** e nella definizione più semplice questa è "interfaccia web ASF" basata su **[Kestrel server HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel)** che può essere utilizzato per un'ulteriore integrazione con il processo, sia come frontend per l'utente finale (ASF-ui), sia come backend per integrazioni di terze parti (ASF API).

IPC può essere utilizzato per un sacco di cose diverse, a seconda delle vostre esigenze e abilità. Ad esempio, è possibile utilizzarlo per recuperare lo stato di ASF e tutti i bot, inviare comandi ASF, recuperare e modificare configurazioni globali/bot, aggiungendo nuovi bot, eliminando i bot esistenti, inviando le chiavi per **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** o accedendo al file di registro di ASF. Tutte queste azioni sono esposte dalla nostra API, che significa che è possibile codificare i propri strumenti e script che saranno in grado di comunicare con ASF e influenzarlo durante il runtime. Oltre a ciò, le azioni selezionate (come l'invio di comandi) sono implementate anche dal nostro ASF-ui che consente di accedervi facilmente attraverso un'interfaccia web amichevole.

---

# Uso

A meno che tu non abbia disabilitato manualmente IPC `IPC` **[la proprietà globale di configurazione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, è abilitata per impostazione predefinita. ASF indicherà il lancio di IPC nel suo registro, che puoi usare per verificare se l'interfaccia IPC è stata avviata correttamente:

```text
INFO<unk> ASF<unk> Start() Avvio del server IPC...
Il server IPC INFO<unk> ASF<unk> Start() è pronto!
```

Il server http di ASF sta ora ascoltando gli endpoint selezionati. Se non hai fornito un file di configurazione personalizzato per IPC, sarà `localhost`, entrambi basati su IPv4 **[127. .0.1](http://127.0.0.1:1242)** e basato su IPv6- **[[::1]](http://[::1]:1242)** sulla porta predefinita `1242`. È possibile accedere alla nostra interfaccia IPC tramite link sopra, ma solo dalla stessa macchina di quello che esegue il processo ASF.

L'interfaccia IPC di ASF espone tre diversi modi per accedervi, a seconda dell'utilizzo pianificato.

Al livello più basso c'è **[ASF API](#asf-api)** che è il nucleo della nostra interfaccia IPC e permette a tutto il resto di funzionare. Questo è ciò che si desidera utilizzare nei propri strumenti, utilità e progetti al fine di comunicare direttamente con ASF.

Sul terreno medio c'è la nostra documentazione **[Swagger](#swagger-documentation)** che funge da frontend per ASF API. È dotato di una documentazione completa di ASF API e consente anche di accedervi più facilmente. Questo è ciò che si desidera controllare se si sta pianificando di scrivere uno strumento, utilità o altri progetti che dovrebbero comunicare con ASF attraverso la sua API.

Al livello più alto c'è **[ASF-ui](#asf-ui)** che si basa sulla nostra API ASF e fornisce un modo user-friendly per eseguire varie azioni ASF. Questa è la nostra interfaccia IPC predefinita progettata per gli utenti finali e un perfetto esempio di cosa puoi costruire con ASF API. Se lo desideri, è possibile utilizzare la propria interfaccia web personalizzata per utilizzare con ASF, specificando `--path` **[argomento a riga di comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** e utilizzando la directory `personalizzata www` situata lì.

---

# ASF-ui

ASF-ui è un progetto di community che mira a creare un'interfaccia grafica user-friendly per gli utenti finali. Per raggiungere questo obiettivo, agisce come un frontend alla nostra **[ASF API](#asf-api)**, che consente di fare varie azioni con facilità. Questa è l'interfaccia utente predefinita con cui ASF viene fornita.

Come detto sopra, ASF-ui è un progetto di community che non è mantenuto dagli sviluppatori di ASF di base. Segue il proprio flusso in **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** che dovrebbe essere utilizzato per tutte le domande correlate, problemi, segnalazioni di bug e suggerimenti.

È possibile utilizzare ASF-ui per la gestione generale del processo ASF. Permette ad esempio di gestire bot, modificare le impostazioni, inviare comandi e ottenere altre funzionalità selezionate normalmente disponibili tramite ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

La nostra API ASF è tipica API web **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** che si basa su JSON come formato di dati primario. Stiamo facendo del nostro meglio per descrivere con precisione la risposta, utilizzando entrambi i codici di stato HTTP (se del caso), oltre a una risposta puoi analizzare te stesso per sapere se la richiesta è riuscita, e in caso contrario, allora perché.

È possibile accedere alle nostre API ASF inviando richieste appropriate agli endpoint `/Api` appropriati. È possibile utilizzare questi endpoint API per creare i propri script, strumenti, GUI e simili. Questo è esattamente ciò che il nostro ASF-ui raggiunge sotto il cofano, e ogni altro strumento può ottenere lo stesso. ASF API è ufficialmente supportato e mantenuto dal team di ASF di base.

Per la documentazione completa di endpoint disponibili, descrizioni, richieste, risposte, codici di stato http e tutto il resto considerando ASF API, fare riferimento alla nostra documentazione **[swagger](#swagger-documentation)**.

![ASF API](https://github.com/user-attachments/assets/08c3d4ad-ea77-403d-a18a-b75c3d0a3097)


---

# Configurazione personalizzata

La nostra interfaccia IPC supporta il file di configurazione extra, `IPC.config` che dovrebbe essere inserito nella directory `di ASF standard config`.

Se disponibile, questo file specifica la configurazione avanzata del server http di Kestrel di ASF, insieme ad altri tuning relativi a IPC. A meno che non si ha una particolare necessità, non c'è motivo per utilizzare questo file, poiché ASF sta già utilizzando valori predefiniti ragionevoli in questo caso.

Il file di configurazione si basa sulla seguente struttura JSON:

```json
{
    "Kestrel": {
        "Endpoints": {
            "example-http4": {
                "Url": "http://127. .0. :1242"
            },
            "example-http6": {
                "Url": "http://[::1]:1242"
            },
            "example-ж4": {
                "Url": "https://127. .0.1:1242",
                "Certificate": {
                    "Path": "/path/to/certificate. fx",
                    "Password": "passwordToPfxFileAbove"
                }
            },
            "example-ж6": {
                "Url": "https://[::1]:1242",
                "Certificate": {
                    "Path": "/path/to/certificate. fx",
                    "Password": "passwordToPfxFileAbove"
                }
            }
        },
        "KnownNetworks": [
            "10. .0.0/8",
            "172.16.0. /12",
            "192.168.0. /16"
        ],
        "PathBase": "/"
    }
}
```

`Endpoints` - Questa è una raccolta di endpoint, ogni endpoint con il proprio nome univoco (come `example-http4`) e `proprietà Url` che specifica `Protocol://Host:Port` indirizzo di ascolto. Per impostazione predefinita, ASF ascolta gli indirizzi IPv4 e IPv6 http, ma abbiamo aggiunto esempi https da usare, se necessario. Dovresti dichiarare solo gli endpoint di cui hai bisogno, abbiamo incluso 4 esempi sopra in modo da poterli modificare più facilmente.

`Host` accetta o `localhost`, un indirizzo IP fisso dell'interfaccia su cui dovrebbe ascoltare (IPv4/IPv6), o `*` valore che lega il server http di ASF a tutte le interfacce disponibili. Utilizzando altri valori come `mydomain.com` o `192.168.0.` agisce come `*`, non è stato implementato alcun filtro IP, quindi fai molta attenzione quando usi i valori `Host` che consentono l'accesso remoto. In questo modo sarà possibile accedere all'interfaccia IPC di ASF da altre macchine, il che potrebbe comportare un rischio per la sicurezza. Raccomandiamo vivamente di utilizzare `IPCPassword` (e preferibilmente anche il tuo firewall) **ad un minimo di** in questo caso.

`KnownNetworks` - Questa variabile **opzionale** specifica gli indirizzi di rete che riteniamo affidabili. Per impostazione predefinita, ASF è configurato per fidarsi dell'interfaccia di loopback (`localhost`, stessa macchina) **solo**. Questa proprietà è utilizzata in due modi. In primo luogo, se si omette `IPCPassword`, quindi consentiremo solo alle macchine di reti conosciute di accedere alle API di ASF, e negheremo a tutti gli altri come misura di sicurezza. In secondo luogo, questa proprietà è fondamentale per quanto riguarda il reverse-proxy di accesso a ASF, come ASF onorerà le sue intestazioni solo se il server proxy inverso è da all'interno di reti conosciute. Onorare le intestazioni è fondamentale per quanto riguarda il meccanismo anti-bruteforce di ASF, come invece di vietare il reverse-proxy in caso di problema, vieterà l'IP specificato dal proxy inverso come sorgente del messaggio originale. Fai molta attenzione con le reti che specifichi qui, in quanto consente un potenziale attacco di spoofing IP e accesso non autorizzato nel caso in cui la macchina fidata sia compromessa o configurata in modo errato.

`PathBase` - Questo è il percorso di base **opzionale** che verrà utilizzato dall'interfaccia IPC. Il valore predefinito è `/` e non dovrebbe essere richiesto di modificare per la maggior parte dei casi d'uso. Modificando questa proprietà ospiterai tutta l'interfaccia IPC su un prefisso personalizzato, ad esempio `http://localhost:1242/MyPrefix` invece di `http://localhost:1242` da solo. L'utilizzo di una `PathBase` personalizzata può essere desiderato in combinazione con una specifica configurazione di un proxy inverso dove si desidera eseguire il proxy solo con un URL specifico, per esempio il miodino `. om/ASF` invece dell'intero dominio `mydomain.com`. Normalmente che richiederebbe da voi di scrivere una regola di riscrittura per il vostro server web che avrebbe mappato il miododomino `. om/ASF/Api/X` -> `localhost:1242/Api/X`, ma puoi invece definire una `PathBase` personalizzata di `/ASF` e ottenere una più facile configurazione del mydomain `. om/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

A meno che non sia veramente necessario specificare un percorso di base personalizzato, è meglio lasciarlo come predefinito.

## Esempio di configurazione

### Modifica della porta predefinita

La seguente configurazione cambia semplicemente la porta di ascolto ASF predefinita da `1242` a `1337`. Puoi scegliere qualsiasi porta che ti piace, ma ti consigliamo la gamma `1024-32767` , as other ports are typically **[registered](https://en.wikipedia.org/wiki/Registered_port)**, e può ad esempio richiedere l'accesso `root` su Linux.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP4": {
                "Url": "http://127. .0. :1337"
            },
            "HTTP6": {
                "Url": "http://[::1]:1337"
            }
        }
    }
}
```

---

### Abilitare l'accesso da tutti gli IP

The following config will allow remote access from all sources, therefore you should **ensure that you read and understood our security notice about that**, available above.

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

Se non si richiede l'accesso da tutte le fonti, ma per esempio solo la LAN, allora è molto meglio controllare l'indirizzo IP locale della macchina che ospita ASF, ad esempio `192. 68.0.10` e usalo invece di `*` nell'esempio di configurazione sopra. Purtroppo è possibile solo se il tuo indirizzo LAN è sempre lo stesso, come altrimenti probabilmente avrai risultati più soddisfacenti con `*` e il tuo firewall in aggiunta a quello che consente solo sottoreti locali per accedere alla porta di ASF.

---

# Autenticazione

L'interfaccia ASF IPC per impostazione predefinita non richiede alcun tipo di autenticazione, poiché `IPCPassword` è impostato su `null`. Tuttavia, se `IPCPassword` è abilitato impostando a qualsiasi valore non vuoto, ogni chiamata all'API di ASF richiede la password che corrisponde al set `IPCPassword`. Se ometti l'autenticazione o inserisci una password errata, otterrai un errore `401 -` non autorizzato. After 5 failed authentication attempts (wrong password), you'll get temporarily blocked with `403 - Forbidden` error.

L'autenticazione può essere effettuata in due modi separati.

## `Authentication` header

In generale dovresti usare le intestazioni **[HTTP request](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)**impostando il campo `Authentication` con la tua password come valore. Il modo di farlo dipende dallo strumento che stai usando per accedere all'interfaccia IPC di ASF, per esempio se stai usando `curl` allora dovresti aggiungere `-H 'Authentication: MyPassword'` come parametro. In questo modo l'autenticazione è passata nelle intestazioni della richiesta, dove dovrebbe effettivamente aver luogo.

## Parametro `password` nella stringa di query

In alternativa, puoi aggiungere il parametro `password` alla fine dell'URL che stai per chiamare, ad esempio chiamando `/Api/ASF? assword=MyPassword` invece di `/Api/ASF` da solo. Questo approccio è sufficiente, ma ovviamente espone la parola d'ordine all'aperto, il che non è necessariamente sempre appropriato. In aggiunta a questo è un argomento extra nella stringa di query, che complica l'aspetto dell'URL e lo fa sentire come è specifico per URL, mentre la password si applica a tutta la comunicazione API di ASF.

---

Entrambi i modi sono supportati ed è totalmente a voi che uno che si desidera scegliere. Si consiglia di utilizzare intestazioni HTTP ovunque è possibile, come usage-wise è più appropriato della stringa di interrogazione. Tuttavia, supportiamo anche la stringa di query, principalmente a causa di varie limitazioni relative alle intestazioni di richiesta. Un buon esempio include la mancanza di intestazioni personalizzate durante l'avvio di una connessione websocket in javascript (anche se è completamente valida secondo l'RFC). In questa situazione la stringa di query è l'unico modo per autenticarsi.

---

# Documentazione di Swagger

La nostra interfaccia IPC, in aggiunta ad ASF API e ASF-ui include anche la documentazione swagger, che è disponibile sotto `/swagger` **[URL](http://localhost:1242/swagger)**. La documentazione Swagger funge da medio-uomo tra la nostra implementazione API e altri strumenti che la utilizzano (ad esempio ASF-ui). Fornisce una documentazione completa e la disponibilità di tutti gli endpoint API nelle specifiche **[OpenAPI](https://swagger.io/resources/open-api)** che possono essere facilmente consumati da altri progetti, consente di scrivere e testare ASF API con facilità.

Oltre a utilizzare la nostra documentazione swagger come una specifica completa di ASF API, è anche possibile utilizzarlo come modo user-friendly per eseguire vari endpoint API, principalmente quelli che non sono implementati da ASF-ui. Dal momento che la nostra documentazione swagger viene generata automaticamente dal codice ASF, hai la garanzia che la documentazione sarà sempre aggiornata con gli endpoint API che la tua versione di ASF include.

![Documentazione di Swagger](https://github.com/user-attachments/assets/ce998e08-f5db-46b0-a9e8-e6b69abd94bb)


---

# Domande frequenti

### L'interfaccia IPC di ASF è sicura e sicura da usare?

ASF di default ascolta solo sugli indirizzi `localhost` , il che significa che l'accesso a ASF IPC da qualsiasi altra macchina ma la tua **è impossibile**. A meno che non modifichi gli endpoint predefiniti, l'attaccante avrebbe bisogno di un accesso diretto alla propria macchina per accedere all'IPC di ASF, quindi è sicuro come può essere e non c'è possibilità di chiunque altro accedervi, anche dalla propria LAN.

Tuttavia, se decidi di cambiare gli indirizzi `localhost` predefiniti a qualcosa d'altro, allora dovresti impostare le regole del firewall appropriate **te stesso** per consentire solo agli IP autorizzati di accedere all'interfaccia IPC di ASF. Oltre a farlo, dovrai impostare `IPCPassword`, poiché ASF si rifiuterà di consentire ad altre macchine l'accesso API ASF senza uno, che aggiunge un altro livello di sicurezza extra. Potresti anche voler eseguire l'interfaccia IPC di ASF dietro un proxy inverso in questo caso, che è ulteriormente spiegato di seguito.

### Posso accedere alle API di ASF tramite i miei strumenti o userscript?

Sì, questo è ciò per cui ASF API è stato progettato e puoi usare qualsiasi cosa in grado di inviare una richiesta HTTP per accedervi. Gli userscript locali seguono la logica **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** , e consentiamo loro l'accesso da tutte le origini (`*`), finché `IPCPassword` è impostata, come misura di sicurezza supplementare. Questo ti permette di eseguire varie richieste API di ASF autenticate, senza permettere agli script potenzialmente dannosi di farlo automaticamente (come avrebbero bisogno di conoscere la tua `IPCPassword` per farlo).

### Posso accedere in remoto a IPC di ASF, ad esempio da un'altra macchina?

Sì, si consiglia di utilizzare un proxy inverso. In questo modo è possibile accedere al server web in modo tipico, che quindi accederà IPC di ASF sulla stessa macchina. In alternativa, se non si desidera eseguire con un proxy inverso, è possibile utilizzare la configurazione **[personalizzata](#enabling-access-from-all-ips)** con URL appropriato per questo. Ad esempio, se la tua macchina è in una VPN con un indirizzo `10.8.0.1` , puoi impostare `http://10.8.0. :1242` URL in ascolto nella configurazione IPC, che permetterebbe l'accesso IPC dall'interno della tua VPN privata, ma non da qualsiasi altra parte.

### Posso usare l'IPC di ASF dietro un proxy inverso come Apache o Nginx?

**Yes**, il nostro IPC è pienamente compatibile con tale configurazione, quindi sei libero di ospitarlo anche di fronte ai tuoi strumenti per una maggiore sicurezza e compatibilità, se vuoi. In general ASF's Kestrel http server is very secure and possesses no risk when being connected directly to the internet, but putting it behind a reverse-proxy such as Apache or Nginx could provide extra functionality that wouldn't be possible to achieve otherwise, such as securing ASF's interface with a **[basic auth](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Esempio di configurazione Nginx può essere trovato sotto. Abbiamo incluso il blocco completo `server` , anche se sei interessato principalmente a quello `posizione`. Si prega di fare riferimento alla documentazione **[nginx](https://nginx.org/en/docs)** se avete bisogno di ulteriori spiegazioni.

```nginx
server {
    listen *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /path/to/your/fullchain. em;
    ssl_certificate_key /path/to/your/privkey. em;

    location ~* /Api/NLog {
        proxy_pass http://127.0.0. :1242;

        # Solo se è necessario sostituire l'host predefinito
# proxy_set_header Host 127. .0. ;

        # X-headers dovrebbe essere sempre specificato quando le richieste di proxy di ASF
        # Sono cruciali per la corretta identificazione dell'IP originale, consentendo ad ASF di es. bandisci i trasgressori effettivi invece che il tuo server nginx
        # Specificare che essi permette a ASF di risolvere correttamente gli indirizzi IP degli utenti che fanno richieste - facendo funzionare nginx come proxy inverso
        # Non specificarli farà sì che ASF tratti il tuo nginx come client - nginx agirà come proxy tradizionale in questo caso
        # Se non sei in grado di ospitare il servizio nginx sulla stessa macchina di ASF, è molto probabile che tu voglia impostare KnownNetworks in modo appropriato oltre a quelli
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;

        # Aggiungiamo queste 3 opzioni extra per il proxy dei websockets, vedi https://nginx. rg/en/docs/http/websocket.html
        proxy_http_version 1. ;
        Connessione proxy_set_header "Upgrade";
        Upgrade proxy_set_header $http_upgrade;
    }

    location / {
        proxy_pass http://127. .0. :1242;

        # Solo se è necessario sostituire l'host predefinito
# proxy_set_header Host 127. .0. ;

        # X-headers dovrebbero essere sempre specificati quando le richieste di proxy di ASF
        # Sono fondamentali per una corretta identificazione dell'IP originale, consentendo ad ASF di es. ban the actual offenders instead of your nginx server
        # Specifying them allows ASF to resolve properly IP address of users making requests - making nginx work as a reverse proxy
        # Not specifthem will cause ASF to treat your nginx as the client - nginx will act as a traditional proxy in this case
        # If you unable to host nginx service on the same machine as ASF, è molto probabile che tu voglia impostare KnownNetworks in modo appropriato oltre a quelli
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
    }
}
```

Esempio di configurazione Apache può essere trovato qui sotto. Si prega di fare riferimento alla documentazione **[apache](https://httpd.apache.org/docs)** se avete bisogno di ulteriori spiegazioni.

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerName asf.mydomain. om

        SSLEngine On
        SSLCertificateFile /path/to/your/fullchain. em
        SSLCertificateKeyFile /path/to/your/privkey. em

        # TODO: Apache non può fare la corrispondenza caso-insensibile correttamente, così abbiamo hardcode due casi più comunemente usati
        ProxyPass "/api/nlog" "ws://127. .0. :1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0. :1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### Posso accedere all'interfaccia IPC tramite protocollo HTTPS?

**Sì**, puoi raggiungerlo in due modi diversi. Un modo consigliato sarebbe quello di utilizzare un proxy inverso, dove è possibile accedere al server web tramite https come al solito, e collegarsi attraverso di esso con l'interfaccia IPC di ASF sulla stessa macchina. In questo modo il traffico è completamente crittografato e non è necessario modificare IPC in alcun modo per supportare tale configurazione.

Il secondo modo include specificare una configurazione **[personalizzata](#custom-configuration)** per l'interfaccia IPC di ASF dove è possibile abilitare l'endpoint https e fornire un certificato appropriato direttamente al nostro server http di Kestrel. In questo modo è consigliabile se non si esegue alcun altro web server e non si desidera eseguirne uno esclusivamente per ASF. In caso contrario, è molto più facile ottenere un setup soddisfacente utilizzando un meccanismo di reverse proxy.

---

### Durante l'avvio di IPC sto ricevendo un errore: `System.IO. Eccezione: Impossibile collegarsi all'indirizzo, È stato fatto un tentativo di accedere a un socket in un modo proibito dai suoi permessi di accesso`

Questo errore indica che qualcos'altro sulla tua macchina sta già usando quella porta, o l'ha riservata per un uso futuro. Questo potrebbe essere se si sta tentando di eseguire la seconda istanza di ASF sulla stessa macchina, ma il più delle volte che Windows esclude la porta `1242` dal tuo utilizzo, quindi dovrai spostare ASF in un'altra porta. Per farlo, segui l'esempio di configurazione **[](#changing-default-port)** sopra, e semplicemente cercare di scegliere un altro porto, come `12420`.

Naturalmente si potrebbe anche cercare di scoprire che cosa sta bloccando la porta `1242` dall'uso di ASF, e rimuovere che, ma di solito è molto più fastidioso che semplicemente istruire ASF di utilizzare un'altra porta, quindi salteremo ulteriormente elaborando su questo qui.

---

### Perché sto ottenendo l'errore `403 Proibito` quando non uso `IPCPassword`?

ASF include una misura di sicurezza aggiuntiva che, per impostazione predefinita, consente solo l'interfaccia di loopback (`localhost`, la tua macchina) per accedere a ASF API senza `IPCPassword` impostata nella configurazione. Questo perché l'utilizzo di `IPCPassword` dovrebbe essere una misura di sicurezza **minima** impostata da tutti coloro che decidono di esporre ulteriormente l'interfaccia ASF.

Il cambiamento è stato dettato dal fatto che massiccia quantità di ASF ospitati globalmente da utenti inconsapevoli sono stati presi in consegna per intenzioni maligne, di solito lasciando le persone senza account e senza elementi su di loro. Ora potremmo dire "potrebbero leggere questa pagina prima di aprire ASF a tutto il mondo", ma invece ha più senso non consentire impostazioni ASF non sicure per impostazione predefinita, e richiedono agli utenti un'azione se vogliono esplicitamente consentirlo, che abbiamo elaborato su qui sotto.

In particolare, sei in grado di ignorare la nostra decisione specificando le reti che ti fidi di raggiungere ASF senza che sia specificato `IPCPassword` , è possibile impostare quelli in `KnownNetworks` proprietà in configurazione personalizzata. Tuttavia, a meno che tu **davvero** sappia cosa stai facendo e capisca pienamente i rischi, si dovrebbe invece utilizzare `IPCPassword` come dichiara `KnownNetworks` permetterà a tutti di accedere a ASF API incondizionatamente. Siamo seri, le persone si stavano già sparando al piede credendo che i loro proxy inverso e le regole iptables fossero sicure, ma erano, `IPCPassword` è il primo e talvolta l'ultimo guardiano, se si decide di optare per questo meccanismo semplice, ma molto efficace e sicuro, avrete solo voi stessi da incolpare.