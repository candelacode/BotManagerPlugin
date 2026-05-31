# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` è il plugin ufficiale ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** sviluppato da noi, che ti permette di contribuire al progetto **[SteamDB](https://steamdb.info)** condividendo i token dei pacchetti, app token e tasti depot a cui il tuo account Steam ha accesso. Le informazioni estese sui dati raccolti e perché SteamDB li necessita si possono trovare sulla pagina di SteamDB **[Token Dumper](https://steamdb.info/tokendumper)**. I dati inoltrati non includono alcuna informazione potenzialmente sensibile e non possiedono rischi di sicurezza/privacy, come dichiarato nella descrizione sopra.

---

## Abilitare il plugin

ASF viene rilasciato con il plugin `SteamTokenDumper` incluso nel rilascio, ma tale plugin è disabilitato per impostazione predefinita. È possibile abilitare il plugin impostando la proprietà `SteamTokenDumperPluginEnabled` nella configurazione globale di ASF a `true`, in sintassi JSON:

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

All'avvio dell'applicazione ASF, il plugin comunicherà se è stato abilitato con successo attraverso il meccanismo di logging standard. È inoltre possibile abilitare il plugin attraverso il generatore di configurazione web.

---

## Dettagli tecnici

All'abilitazione, il plugin userà i bot che esegui in ASF per la raccolta dei dati in forma di token del pacchetto, token dell'app e chiavi di depot cui i tuoi bot hanno accesso. Il modulo di raccolta dei dati include le routine passive e attive che dovrebbero minimizzare il sovraccarico aggiuntivo causato dalla raccolta di dati.

Per soddisfare il caso d'uso pianificato, oltre alla routine di raccolta dati sopra menzionata, la routine di invio è inizializzata come responsabile per la determinazione di quali dati vanno inviati a SteamDB su base periodica. Questa routine sarà eseguita fino a `1` ora dal tuo avvio di ASF, e si ripeterà ogni `24` ore. Il plugin farà del suo meglio per ridurre la quantità di dati che devono esser inviati, dunque è possibile che alcuni dati che il plugin raccoglie saranno determinati come inutili da inviare, e dunque saltati (per esempio l'aggiornamento dell'app che non cambia il token d'accesso).

Il plugin usa un database della cache persistente salvato nella posizione `config/SteamTokenDumper.cache`, che serve come scopo simile a `config/ASF.db` per ASF. Il file è usato per registrare i dati raccolti e inviati e minimizza la quantità di lavoro da eseguire per le diverse esecuzioni di ASF. Rimuovere il file causa il riavvio da zero del processo, cosa da evitare se possibile.

---

## Dati

ASF include il contributore `steamID` nella richiesta, determinato come `SteamOwnerID`, che imposti in ASF, o nel caso non lo avessi fatto, l'ID di Steam del bot che possiede gran parte delle licenze. Il contributore annunciato potrebbe ricevere vantaggi aggiuntivi da SteamDB per aiuto continuo (es. rango di donatore sul sito web), ma è totalmente a tua discrezione.

In ogni caso, lo staff di SteamDB vorrebbe ringraziarti in anticipo per il tuo aiuto. I dati inoltrati consentono a SteamDB di operare, in particolare per monitorare le informazioni sui pacchetti, le app e i depot, cosa che non sarà più possibile senza il tuo aiuto.

---

## Comando

Il plugin STD viene fornito con un comando ASF extra, `std [Bots]`, che consente di attivare l'aggiornamento e l'invio per i bot selezionati su richiesta. L'utilizzo del comando non richiede la configurazione abilitata, che consente di saltare la raccolta e l'invio automatici e controllare manualmente il processo. Naturalmente può anche essere eseguito con configurazione abilitata, che semplicemente attiverà le consuete procedure di raccolta e presentazione prima del previsto.

Consigliamo `!std ASF` per attivare l'aggiornamento per tutti i bot disponibili. Tuttavia, è anche possibile attivarlo per quelli selezionati, se si desidera.

---

## Configurazione avanzata

Il nostro plugin supporta la configurazione avanzata che potrebbe venire utile per le persone che vorrebbero modificare gli interni alla loro preferenza.

La configurazione avanzata ha la seguente struttura situata all'interno di `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Enabled": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretPackageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Tutte le opzioni sono spiegate sotto:

### `Abilitato`

`bool` type with default value of `false`. Questa proprietà agisce come la proprietà `SteamTokenDumperPluginEnabled` spiegata sopra, e può essere utilizzata al suo posto, dedicato a persone che preferirebbero avere intere configurazioni relative al plugin nella propria struttura (quindi molto probabilmente quelli che utilizzano già altre proprietà avanzate spiegate di seguito).

---

### `SecretAppIDs`

Tipo `ImmutableHashSet<uint>` con valore predefinito vuoto. Questa proprietà specifica `appID` che il plugin non si risolverà, e se sono già risolti, non invierà il token per. Questa proprietà può essere utile per le persone con accesso a informazioni potenzialmente sensibili su elementi non pubblicati, in particolare gli sviluppatori, gli editori o i beta tester chiusi.

---

### `SecretDepotID`

Tipo `ImmutableHashSet<uint>` con valore predefinito vuoto. Questa proprietà specifica `depotIDs` che il plugin non risolve, e se sono già risolti, non invierà la chiave per. Questa proprietà può essere utile per le persone con accesso a informazioni potenzialmente sensibili su elementi non pubblicati, in particolare gli sviluppatori, gli editori o i beta tester chiusi.

---

### `SecretPackageID`

Tipo `ImmutableHashSet<uint>` con valore predefinito vuoto. Questa proprietà specifica gli ID di pacchetto `` (noti anche come `sottoID`) che il plugin non risolverà, e se sono già risolti, non invierà il token per. Questa proprietà può essere utile per le persone con accesso a informazioni potenzialmente sensibili su elementi non pubblicati, in particolare gli sviluppatori, gli editori o i beta tester chiusi.

---

### `SkipAutoGrantPackages`

`bool` tipo con valore predefinito `true`. Questa proprietà agisce molto simile a `SecretPackageIDs` e quando abilitato, farà saltare i pacchetti con `EPaymentMethod` di `AutoGrant` durante la risoluzione di routine spiegata di seguito. Il metodo di pagamento `AutoGrant` è utilizzato da **[Steamworks](https://partner.steamgames.com)** per concedere automaticamente pacchetti sugli account sviluppatore. Anche se questo non è esplicito come altre opzioni `Secret` , e quindi non garantisce nulla (poiché potresti avere pacchetti diversi da `AutoGrant` che non vuoi ancora inviare), dovrebbe essere abbastanza buono per saltare la maggioranza, se non tutti, dei pacchetti segreti. Questa opzione è abilitata per impostazione predefinita, come le persone che hanno effettivamente accesso ai pacchetti `AutoGrant` non vorranno quasi mai perdere quelli al pubblico in generale, e quindi utilizzare il valore di `falso` è molto situazionale.

---

## Ulteriori spiegazioni

Al livello root, ogni account Steam possiede una serie di pacchetti (licenze, abbonamenti), che sono classificati dal loro pacchetto `` (noto anche come `sottoID`). Ogni pacchetto può contenere diverse applicazioni classificate dal loro `appID`. Ogni app può quindi includere diversi depositi classificati dal loro depotID ``.

```text
├l’articolo 44923
<unk> <unk> <unk> <unk> app/292030
<unk> <unk> <unk> <unk> <unk> <unk> <unk> <unk> depot/292031
<unk> <unk> <unk> <unk> <unk> <unk> depot/378648
<unk> <unk> <unk> <unk> <unk> ...
ж├<unk> <unk> app/378649
<unk> <unk> <unk> ...
└── ...
```

Il nostro plugin include due routine che prendono in considerazione gli elementi saltati - la routine di risoluzione e la routine di presentazione.

La routine di risoluzione è responsabile della risoluzione dell'albero che puoi vedere sopra. In blacklist i pacchetti/app/depositi in anticipo, taglierai efficacemente l'albero al posto di ramo/foglia della lista nera senza bisogno di specificare le parti rimanenti di esso. Nel nostro esempio sopra, se il pacchetto `124923` è stato ignorato, se da `SecretPackageIDs` o `SkipAutoGrantPackages`, ed è stato l'unico pacchetto che possiedi collegato all'appID `292030` , poi appID `292030` non si risolverebbe e per definizione, se non ci sono altre applicazioni risolte collegate ai depositi `292031` e `378648` , allora non si risolverebbero neanche. Tuttavia, tieni presente che se il plugin ha già risolto l'albero, in modo efficace questo impedirà solo l'aggiornamento dell'elemento dato (ad es. nuove applicazioni aggiunte), non renderà il plugin "dimentica" degli elementi esistenti che erano già risolti (e. . applicazioni trovate in quel pacchetto prima di decidere di blacklist). Se hai appena abilitato alcune opzioni di salto, e vorrei assicurarsi che ASF non attraversare l'albero già risolto, si può prendere in considerazione la rimozione una tantum di `config/SteamTokenDumper. ache` file dove il plugin mantiene la sua cache.

La routine di presentazione è responsabile per l'invio di pacchetti di gettoni, token di app e chiavi di deposito di elementi già risolti (dalla routine di risoluzione sopra). Qui la blacklist ha effetto immediato, come anche se il plugin ha già risolto le informazioni, la routine di presentazione non lo invierà a SteamDB se lo hai inserito nella lista nera, indipendentemente dal fatto che sia stato risolto o meno. Tenete a mente però che non stiamo più parlando dell'albero a questo punto, la routine di invio non sa se le informazioni sull'app provengono da questo o quel pacchetto, quindi salta solo le informazioni su particolari articoli in blacklist, indipendentemente dalla relazione che sono in con gli altri.

Per la maggior parte degli sviluppatori ed editori, dovrebbe essere sufficiente mantenere `SkipAutoGrantPackages` abilitato, potenzialmente abilitati solo con `SecretPackageIDs` , poichè taglia efficacemente l'albero al ramo iniziale e garantisce che le applicazioni e i depositi inclusi ulteriormente non verranno inviati fintanto che non c'è nessun altro pacchetto che collega alla stessa app. Se vuoi essere doppio sicuro, oltre a questo puoi anche utilizzare `SecretAppIDs`, che salterà la risoluzione dell'app anche se ci sono alcune altre licenze che non hai inserito nella blacklist. L'utilizzo di `SecretDepotIDs` non dovrebbe essere necessario, a meno che tu non abbia un particolare, esigenze specifiche (come saltare solo un deposito particolare durante l'invio di informazioni su pacchetti e app), o se vuoi aggiungere un altro livello per essere triplo sicuro.