# Scambi

ASF include il supporto per le operazioni non interattive (offline) di Steam. Sia la ricezione (accettazione/declino) che l'invio di scambi sono immediatamente disponibili e non richiedono una configurazione speciale, ma ovviamente richiede un account Steam senza restrizioni (quello che ha speso 5$ nel negozio già). È disponibile solo una funzionalità di trading limitata per i conti limitati.

---

## Logica

Prima di tutto, è possibile disabilitare le offerte di trading **all** in entrata, utilizzando il flag `DisableIncomingTradesParsing` in `BotBehaviour`. Utilizzando quello, come suggerisce il nome, disabiliterà tutte le funzionalità relative all'analisi delle operazioni in entrata, che include di seguito la logica di default, così come tutte le funzioni extra disponibili che dipendono dalla reazione all'offerta di trading in entrata. Poiché le impostazioni predefinite sono già non intrusive, si dovrebbe prendere in considerazione di utilizzare tale opzione solo se non si ha assolutamente alcun intento da ASF per fare qualcosa di correlato al commercio in entrata a tutti.

Il sottostante spiega la logica quando è abilitata l'analisi delle offerte di trading in entrata, che è l'opzione predefinita.

ASF accetterà sempre tutte le operazioni, indipendentemente dagli elementi, inviate dall'utente con accesso `Master` (o superiore) al bot. Questo permette non solo di saccheggiare facilmente schede a vapore coltivate dall'istanza del bot, ma permette anche di gestire facilmente gli oggetti Steam che il bot recita nell'inventario - compresi quelli provenienti da altri giochi (come CS:GO).

ASF rifiuterà l'offerta commerciale, indipendentemente dal contenuto, da qualsiasi utente (non master) che è blacklist dal modulo di trading. Blacklist è memorizzata nello standard `BotName. b` database e può essere gestito tramite `tb`, `tbadd` and `tbrm` **[comandi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Questo dovrebbe funzionare come alternativa al blocco utente standard offerto da Steam - utilizzare con cautela.

ASF accetterà tutti i loot ``-come le operazioni che vengono inviate attraverso i bot, a meno che `DontAcceptBotTrades` non sia specificato in `TradingPreferences`. Insomma, default `TradingPreferences` of `None` farà sì che ASF accetti automaticamente le transazioni dall'utente con accesso `Master` al bot (spiegato sopra), così come tutte le operazioni di donazione da altri bot che partecipano al processo di ASF.

Quando abiliti `AcceptDonations` nella tua `TradingPreferences`, ASF accetterà anche qualsiasi commercio di donazioni - un commercio in cui conto bot non sta perdendo alcun oggetto. Questa proprietà influisce solo su account non-bot, poiché gli account bot sono influenzati da `DontAcceptBotTrades`. `AcceptDonations` consente di accettare facilmente donazioni da altre persone, e anche bot che non partecipano al processo di ASF.

È bello notare che `AcceptDonations` non richiede **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, poiché non è necessaria alcuna conferma se non stiamo perdendo alcun oggetto.

È inoltre possibile personalizzare ulteriormente le funzionalità di trading di ASF modificando di conseguenza `TradingPreferences`. Una delle principali funzionalità `TradingPreferences` è l'opzione `SteamTradeMatcher` che farà sì che ASF utilizzi la logica integrata per accettare le operazioni che ti aiutano a completare i badge mancanti, che è particolarmente utile in collaborazione con la lista pubblica di **[SteamTradeMatcher](https://www.steamtradematcher.com)**, ma può anche funzionare senza di essa. È ulteriormente descritto di seguito.

---

## `SteamTradeMatcher`

Quando `SteamTradeMatcher` è attivo, ASF userà un algoritmo abbastanza complesso di controllo se lo scambio supera le regole STM ed è almeno neutrale verso di noi. La logica reale è la seguente:

- Rifiuta il trade se stiamo perdendo qualsiasi cosa tranne i tipi di oggetti specificati nei nostri tipi di abbinabilità ``.
- Rifiutare il commercio se non riceviamo almeno lo stesso numero di oggetti per partita, per tipo e per rarità.
- Rifiutare il commercio se l'utente chiede speciali schede di vendita estive / invernali Steam, e ha una tenuta commerciale.
- Rifiuta il trade se la durata del trade hold supera la proprietà di configurazione globale `MaxTradeHoldDuration`.
- Rifiuta il trade se non abbiamo impostato `MatchEverything` ed è peggio che neutrale per noi.
- Accetta il commercio se non lo respingiamo attraverso nessuno dei punti di cui sopra.

È bello notare che ASF supporta anche il pagamento eccessivo - la logica funzionerà correttamente quando l'utente sta aggiungendo qualcosa in più al commercio, purché siano soddisfatte tutte le condizioni di cui sopra.

I primi 4 predicati di rigetto dovrebbero essere ovvi per tutti. L'ultimo include la logica dei dupes che controlla lo stato attuale del nostro inventario e decide qual è lo stato del commercio.

- Il commercio è **buono** se i nostri progressi verso il completamento impostato avanzano. Esempio: A (prima) -> A B (dopo)
- Il commercio è **neutrale** se i nostri progressi verso il completamento impostato rimangono in tensione. Esempio: A B (prima) -> A C (dopo)
- Il commercio è **cattivo** se i nostri progressi verso il completamento impostato diminuiscono. Esempio: A C (prima) -> A A (dopo)

STM opera solo su buoni scambi, il che significa che l'utente che utilizza STM per dupes matching dovrebbe sempre suggerire solo buoni scambi per noi. Tuttavia, ASF è liberale, e accetta anche mestieri neutrali, perché in quei mestieri non stiamo realmente perdendo nulla, quindi non c'è alcun motivo reale di declinarli. Questo è particolarmente utile per i tuoi amici, poiché possono scambiare le tue carte eccessive senza usare STM affatto, finché non stai perdendo alcun progresso impostato.

Per impostazione predefinita, ASF rifiuterà i cattivi scambi - questo è quasi sempre quello che si desidera come utente. Tuttavia, puoi abilitare opzionalmente `MatchEverything` nella tua `TradingPreferences` al fine di far accettare a ASF tutte le operazioni di dupe, incluso **cattivi**. Questo è utile solo se si desidera eseguire un bot di trading 1:1 sul tuo account, come si capisce che **ASF non ti aiuterà più a progredire verso il completamento del badge, e ti rendono incline a perdere l'intero set finito per N dupes della stessa carta**. Se si desidera eseguire intenzionalmente un bot di trading che è **mai** dovrebbe finire qualsiasi set, e dovrebbe offrire tutto il suo inventario a ogni utente interessato, quindi è possibile abilitare tale opzione.

Indipendentemente dalla tua `TradingPreferences`scelta, un trade che viene rifiutato da ASF non significa che non puoi accettarlo da solo. Se hai mantenuto il valore predefinito di `BotBehaviour`, che non include `RejectInvalidTrades`, ASF ignorerà solo quei mestieri - che consente di decidere te stesso se sei interessato a loro o no. Lo stesso vale per le transazioni con oggetti al di fuori di `MatchableTypes`, così come tutto il resto - il modulo dovrebbe aiutarvi ad automatizzare le transazioni STM, non decidere che cosa sia un buon commercio e cosa no. L'unica eccezione da questa regola è quando si parla di utenti che hai blacklist dal modulo di trading utilizzando il comando `tbadd` - le transazioni da questi utenti vengono immediatamente rifiutate indipendentemente dalle impostazioni `BotBehaviour`.

È altamente raccomandato utilizzare **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** quando abiliti questa opzione, poiché questa funzione perde tutto il suo potenziale se si decide di confermare manualmente ogni operazione. `SteamTradeMatcher` funzionerà correttamente anche senza la possibilità di confermare le operazioni, ma può generare backlog di conferme se non li stai accettando in tempo.