# Condivisione familiare di Steam

ASF supporta Steam Family Sharing - il vecchio e il nuovo sistema. Al fine di capire come ASF funziona con questo, dovresti prima leggere come **[Steam Family Sharing funziona](https://store.steampowered.com/promotion/familysharing)**, che è disponibile su Steam store. Oltre a ciò, controlla **[la notizia](https://store.steampowered.com/news/app/593110/view/4149575031735702628)** per il nuovo sistema di condivisione della famiglia di Steam, con cui ASF è anche compatibile.

---

## ASF

Il supporto per Steam Family Sharing presente in ASF è trasparente, il che significa che non introduce alcuna nuova proprietà di configurazione dei bot/processi; funziona fuori dalle righe come una funzionalità integrata extra.

ASF include una logica appropriata per esser consapevoli del fatto che la libreria viene bloccata dagli utenti della condivisione familiare, dunque non li "caccerà" dalla sessione di gioco per il lancio di un gioco. ASF agirà esattamente come con il profilo primario che tiene il blocco, dunque se questo blocco è tenuto insieme dal tuo client di Steam, o da uno dei tuoi utenti della condivisione familiare, ASF non proverà a fermare, invece, attenderà il rilascio del blocco. Questo è per lo più legato al vecchio sistema - il nuovo sistema consente agli utenti di condivisione familiare di giocare a giochi diversi da quelli che ASF sta attualmente coltivando.

Oltre a quanto sopra, dopo l'accesso, ASF accederà ai vostri sistemi di condivisione familiare (vecchi e nuovi), da cui estrarrà gli utenti (ID Steam) autorizzati ad usare la tua libreria. A questi utenti viene dato il permesso `FamilySharing` di utilizzare i comandi **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, in particolare permettendo loro di utilizzare il comando `pausa~` sull'account bot che sta condividendo i giochi con loro, che permette di mettere in pausa il modulo di allevamento automatico delle carte al fine di lanciare un gioco che può essere condiviso - questo vale soprattutto per il vecchio sistema, ma potrebbe ancora essere utilizzato con il nuovo sistema nel caso in cui ASF è attualmente gioco di agricoltura che gli utenti vogliono giocare.

Collegare entrambe le funzionalità sopra descritte permette ai tuoi amici di `pausa~` processo di allevamento delle carte, inizia una partita, gioca fino a quando lo desiderano, e poi dopo aver giocato, il processo di allevamento delle carte sarà automaticamente ripreso da ASF. Certo, l'emissione di `pause~` non è necessaria se ASF correntemente non sta farmando nulla in modo attivo, perché i tuoi amici possono lanciare il gioco direttamente e la logica descritta sopra assicura che non saranno cacciati dalla sessione.

---

## Limitazioni

La rete di Steam adora fuorviare ASF trasmettendo aggiornamenti di stato falsi, che potrebbero condurre ASF a credere che vada bene riprendere il processo, cacciando troppo presto i tuoi amici. Questo è esattamente lo stesso problema di quello già spiegato da noi in **[questa voce della FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. Consigliamo esattamente le stesse soluzioni, promuovendo principalmente i tuoi amici al permesso `Operatore` (o superiore) e dicendo loro di fare uso dei comandi `pause` e `resume`.