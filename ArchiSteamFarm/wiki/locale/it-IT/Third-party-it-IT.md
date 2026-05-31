# Terze parti

Questa sezione include delle estensioni di terze parti scritte esclusivamente (o principalmente) per ASF. Variano da plugin di ASF a semplici applicazioni web e librerie interne per l'integrazione, per poi finire in bot ricchi di funzionalità per altre piattaforme. Se desideri aggiungere qualcosa alla lista, faccelo sapere su Discord o sul nostro gruppo di Steam.

Sei pregato di notare che i seguenti programmi **non** sono mantenuti da sviluppatori di ASF e dunque **non diamo alcuna garanzia su nessuno di essi**, specialmente in termini di sicurezza o conformità ai Termini di Servizio di Steam. L'elenco è mantenuto solo a titolo di riferimento. Dovresti sempre essere sicuro che il programma che stai per utilizzare sia sicuro, poichè li utilizzi a tuo rischio e pericolo.

---

## Plugins di ASF

### **[CatPoweredPlugins](https://github.com/CatPoweredPlugins)** (**[Rudokhvist](https://github.com/Rudokhvist)**)

- **[ASFAchievementManager](https://github.com/CatPoweredPlugins/ASFAchievementManager)**, plugin per ASF che consente di gestire i risultati di Steam.
- **[BirthdayPlugin](https://github.com/CatPoweredPlugins/BirthdayPlugin)**, plugin per ASF per ricevere congratulazioni di compleanno.
- **[CaseInsensitiveASF](https://github.com/CatPoweredPlugins/CaseInsensitiveASF)**, plugin per ASF per rendere i nomi dei bot insensibili alle maiuscole e minuscole.
- **[CommandAliasPlugin](https://github.com/CatPoweredPlugins/CommandAliasPlugin)**, plugin per ASF per configurare alias di comando personalizzati per i comandi ASF.
- **[CommandlessRedeem](https://github.com/CatPoweredPlugins/CommandlessRedeem)**, plugin per ASF per re-implementare il riscatto della chiave senza un comando.
- **[ItemDispenser](https://github.com/CatPoweredPlugins/ItemDispenser)**, plugin per ASF per accettare automaticamente la richiesta commerciale per determinati tipi di articoli.
- **[SelectiveLootAndTransferPlugin](https://github.com/CatPoweredPlugins/SelectiveLootAndTransferPlugin)**, plugin per ASF che fornisce un comando avanzato di trasferimento `` per trasferire gli elementi di Steam.

### **[Citrinate](https://github.com/Citrinate)**

- **[BoosterManager](https://github.com/Citrinate/BoosterManager)**, plugin per ASF che fornisce un'interfaccia semplice per cambiare le gemme in pacchetti di carte, avendo a disposizione anche funzionalità per la gestione dell'inventario e del mercato.
- **[CS2Interface](https://github.com/Citrinate/CS2Interface)**, plugin per ASF che consente di interagire con Counter-Strike 2 utilizzando **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**.
- **[FreePackages](https://github.com/Citrinate/FreePackages)**, plugin per ASF che trova pacchetti gratuiti su Steam e li aggiunge al tuo account.

### **[Vita](https://github.com/ezhevita)**

- **[FriendAccepter](https://github.com/ezhevita/FriendAccepter)**, plugin per ASF per accettare automaticamente tutti gli inviti degli amici.
- **[GameRemover](https://github.com/ezhevita/GameRemover)**, plugin per ASF che implementa un comando per rimuovere licenze Steam per le istanze dei bot selezionati.
- **[GetEmail](https://github.com/ezhevita/GetEmail)**, plugin per ASF che implementa un comando per recuperare l'indirizzo e-mail di determinate istanze dei bot direttamente da Steam.
- **[ResetAPIKey](https://github.com/ezhevita/ResetAPIKey)**, plugin per ASF che implementa un comando per resettare la chiave API per le istanze dei bot selezionati.

### Altro

- **[ASFEnhance](https://github.com/chr233/ASFEnhance)**, plugin per ASF migliorandolo con varie nuove funzionalità, in particolare i comandi.
- **[ASFFreeGames](https://github.com/maxisoft/ASFFreeGames)**, plugin per ASF che consente di raccogliere automaticamente i giochi di vapore gratuiti pubblicati su reddit.

---

## Integrazioni

- **[ASFBot](https://github.com/dmcallejo/ASFBot)**, bot di telegram con l'integrazione per ASF, scritto in python.
- **[ASF STM userscript](https://greasyfork.org/en/scripts/404754-asf-stm)**, per coloro che vogliono inviare offerte di scambio automatizzate ai bot sul nostro **[listino di ASF STM](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** tramite il browser web, senza usare la funzionalità `MatchActively` fornita da ASF.
- **[simple-asf-bot](https://github.com/deluxghost/simple-asf-bot)**, un altro bot telegramma (minimo) scritto in python con integrazione di ASF.

---

## Librerie

- **[ASF-IPC](https://github.com/deluxghost/ASF_IPC)**, libreria di python per un'ulteriore intregrazione con l'interfaccia IPC di ASF.

---

## Packaging

- **[AUR repo #1](https://aur.archlinux.org/packages/asf)**, permette di installare facilmente ASF su Arch Linux.
- **[AUR repo #2](https://aur.archlinux.org/packages/archisteamfarm-bin)**, permette di installare facilmente ASF su Arch Linux.
- **[Homebrew](https://formulae.brew.sh/formula/archi-steam-farm)**, consentendoti di installare facilmente ASF su macOS.
- **[Nix](https://search.nixos.org/packages?channel=unstable&show=ArchiSteamFarm&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, consentendo di installare facilmente ASF sulle distribuzioni con Nix.
- **[NixOS](https://search.nixos.org/options?channel=unstable&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, che consente di configurare e installare ASF con NixOS.
- **[Scoop](https://scoop.sh/#/apps?q=ArchiSteamFarm)**, consentendo di installare facilmente ASF sulle finestre.
- **[Winget](https://github.com/microsoft/winget-pkgs/tree/master/manifests/j/JustArchiNET/ArchiSteamFarm)**, consentendo di installare facilmente ASF sulle finestre.

---

## Strumenti

- **[CS2Script](https://github.com/Citrinate/CS2Script)**consente di gestire le unità di archiviazione Counter-Strike 2 con l'aiuto del plugin **[CS2Interface](https://github.com/Citrinate/CS2Interface)**.
- **[Estrattore di chiavi](https://umaim.github.io/SKE)**, permette di copiare-incollare le chiavi in vari formati e di creare comandi di `riscatto` per ASF. Controlla la **[repo di GitHub](https://github.com/PixvIO/SKE)** per maggiori dettagli.
- **[ASF Mass Config Editor](https://github.com/genesix-eu/ASF_MCE)**, permette di gestire configurazioni multiple di ASF più facilmente.

---

## Vuoi saperne di più?

Consigliamo **[ArchiSteamFarm](https://github.com/topics/archisteamfarm)** topic su GitHub per tutti i progetti che si integrano con ASF. Tenete a mente tuttavia che i progetti di ASF non correlati possono anche tentare di utilizzare il tag, di solito per la promozione di sé, quindi è sempre una buona idea per il doppio controllo.