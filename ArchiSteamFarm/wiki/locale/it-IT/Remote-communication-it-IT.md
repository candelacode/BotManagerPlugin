# Comunicazione remota

Questa sezione approfondisce la comunicazione a distanza che ASF comprende, tra cui ulteriori spiegazioni su come si può influenzarla. Mentre non consideriamo nulla sotto come dannoso o altrimenti indesiderato, e non siamo legalmente obbligati a rivelarlo, vogliamo che tu capisca meglio la funzionalità del programma, soprattutto per quanto riguarda la tua privacy e i tuoi dati che vengono condivisi.

## Vapore

ASF comunica con la rete Steam (**[CM server](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), così come **[Steam API](https://steamcommunity.com/dev)**, **[Steam store](https://store.steampowered.com)** e **[Steam community](https://steamcommunity.com)**.

Non è possibile disabilitare nessuna delle comunicazioni di cui sopra, in quanto è il fondamento principale ASF è basato su al fine di fornire la sua funzionalità di base. Dovrai astenerti dall'usare ASF se non sei a tuo agio con quanto sopra.

## Gruppo vapore

ASF comunica con il nostro gruppo **[Steam](https://steamcommunity.com/groups/archiasf)**. Il gruppo ti fornisce annunci, in particolare nuove versioni, problemi critici, problemi di Steam e altre cose che sono importanti per mantenere la comunità aggiornata. Permette inoltre di utilizzare il nostro supporto tecnico, ponendo domande, risolvere problemi, segnalare problemi o suggerire miglioramenti. Per impostazione predefinita, gli account utilizzati in ASF entreranno automaticamente nel gruppo al momento dell'accesso.

Puoi decidere di non aderire al gruppo disabilitando il flag `SteamGroup` del bot **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)**

## GitHub

ASF comunica con l'API **[di GitHub](https://api.github.com)** per recuperare le versioni **[di ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** per la funzionalità di aggiornamento. Questo viene fatto come parte degli aggiornamenti automatici (se hai mantenuto attivata **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** , così come `aggiornamento` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Puoi influenzare la comunicazione di ASF con GitHub tramite la proprietà **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** - impostandola su `Nessuno` comporterà la disabilitazione dell'intera funzionalità di aggiornamento, compresa la comunicazione GitHub al riguardo.

## Server di ASF

ASF comunica con **[il nostro server](https://asf.justarchi.net)** per funzionalità più avanzate. In particolare, ciò comprende:
- Verifica di checksum di ASF build scaricati da GitHub contro il nostro database indipendente per garantire che tutte le build scaricate siano legittime (senza malware, Attacchi MITM o altre manomissioni)
- Recupero lista di bot errati da filtrare se hai mantenuto attivata l'impostazione globale di configurazione `FilterBadBots`.
- Annunciare il tuo bot in **[il nostro annuncio](https://asf.justarchi.net/STM)** se hai abilitato `SteamTradeMatcher` in **[`Preferenze`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** e soddisfa altri criteri
- Scaricando i bot attualmente disponibili per operare da **[il nostro annuncio](https://asf.justarchi.net/STM)** se hai abilitato `MatchActively` in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** e soddisfano altri criteri

Come misura di sicurezza, non è possibile disabilitare la verifica del checksum per le build di ASF. Tuttavia, è possibile disabilitare completamente gli aggiornamenti automatici se si desidera evitare questo, come descritto sopra nella sezione GitHub.

Puoi disabilitare l'impostazione `FilterBadBots` se vuoi evitare di recuperare la lista dal server.

Puoi decidere di non annunciare l'inserimento nell'elenco disabilitando il flag `PublicListing` del bot **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** Questo potrebbe essere utile se si desidera eseguire il bot `SteamTradeMatcher` senza essere annunciato allo stesso tempo.

Il download dei bot dal nostro elenco è obbligatorio per l'impostazione `MatchActively` , è necessario disabilitare tale impostazione se non sei disposto ad accettarla.