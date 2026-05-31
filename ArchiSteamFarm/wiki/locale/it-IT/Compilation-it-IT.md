# Compilazione

La compilazione è il processo di creazione del file eseguibile. Questo è quanto vuoi fare se vuoi aggiungere le tue modifiche ad ASF, o se per qualche motivo non ti fidi dei file eseguibili forniti nelle **[versioni](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ufficiali. Se sei un utente e non uno sviluppatore, molto probabilmente vorrai usare i binari già precompilati, ma se vuoi usare i tuoi, o vuoi imparare qualcosa di nuovo, continua a leggere.

ASF è compilabile su ogni piattaforma correntemente supportata, finché hai tutti gli strumenti per farlo.

---

## .NET SDK

Indipendentemente dalla piattaforma, è necessario pieno .NET SDK (non solo runtime) per compilare ASF. Le istruzioni di installazione possono essere trovate su **[.NET download page](https://dotnet.microsoft.com/download)**. È necessario installare la versione .NET SDK appropriata per il vostro sistema operativo. Dopo l'installazione riuscita, il comando `dotnet` dovrebbe esser funzionante e operativo. Puoi verificare che funzioni con `dotnet --info`. Assicurati inoltre che il tuo .NET SDK corrisponda ai requisiti di runtime di ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## Compilazione

Supponendo di avere .NET SDK operativo e in versione appropriata, semplicemente navigare alla directory sorgente di ASF (clonato o scaricato e scompattato ASF repo) ed eseguire:

```shell
dotnet pubblicare ArchiSteamFarm -c "Release" -o "out/generic"
```

Se stai usando Linux/macOS, puoi invece usare lo script `cc.sh` che farà lo stesso, in modo un po' più complesso.

Se la compilazione è terminata correttamente, puoi trovare il tuo ASF in forma di `sorgente` nella cartella `out/generic`. Ha pari valore alla build ufficiale `generica` di ASF, ma ha `UpdateChannel` e `UpdatePeriod` di `0` forzati, il che è appropriato per le build personali.

### Specifico all'OS

Puoi anche generare un pacchetto .NET specifico per il sistema operativo se hai una specifica esigenza. In generale non dovresti farlo perché hai appena compilato `generic` flavour che puoi eseguire con la tua già installata. Eruntime ET che hai utilizzato per la compilazione in primo luogo, ma nel caso in cui:

```shell
dotnet pubblica ArchiSteamFarm -c "Rilascio" -o "out/linux-x64" -r "linux-x64" --self-contained
```

Ovviamente, sostituisci `linux-64` con l'architettura OS a cui vuoi destinarlo, come `win-x64`. Questa build avrà inoltre gli aggiornamenti disabilitati. Quando si costruisce `--self-contained` è anche possibile dichiarare opzionalmente altri due interruttori: `-p:PublishTrimmed=true` produrrà build rifilata, mentre `-p:PublishSingleFile=true` produrrà un singolo file. L'aggiunta di entrambi comporterà le stesse impostazioni che usiamo per le nostre costruzioni.

### ASF-ui

Mentre i passaggi di cui sopra sono tutto ciò che è necessario per avere una costruzione pienamente funzionante di ASF, si può *anche* essere interessati a costruire **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, la nostra interfaccia web grafica. Dal lato di ASF, tutto quello che devi fare è eliminare l'output di generazione ASF-ui nello standard `ASF-ui/dist` posizione, poi costruire ASF con esso (ancora, se necessario).

ASF-ui fa parte dell'albero sorgente di ASF come un sottomodulo **[git](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, assicurati di aver clonato il repo con `git clone --recursive`, altrimenti non avrai i file richiesti. Avrai anche bisogno di un NPM funzionante, **[Node.js](https://nodejs.org)** viene fornito. Se stai usando Linux/macOS, ti consigliamo il nostro `cc. h` script, che coprirà automaticamente la costruzione e spedizione ASF-ui (se possibile, cioè, se stai soddisfacendo i requisiti che abbiamo appena menzionato).

In aggiunta alla `cc. h` script, alleghiamo anche le istruzioni di build semplificate qui sotto, fare riferimento a **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** per la documentazione aggiuntiva. Dalla posizione dell'albero sorgente di ASF, così come sopra, esegui i seguenti comandi:

```shell
rm -rf "ASF-ui/dist" # ASF-ui non si pulisce dopo la vecchia generazione

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # Assicurati che il nostro output di build sia pulito dai vecchi file
dotnet pubblica ArchiSteamFarm -c "Release" -o "out/generic" # O di conseguenza a quello che ti serve secondo quanto sopra
```

Ora dovresti essere in grado di trovare i file ASF-ui nella tua cartella `out/generic/www`. ASF sarà in grado di servire questi file al tuo browser.

In alternativa, puoi semplicemente costruire ASF-ui, manualmente o con l'aiuto del nostro repo, quindi copia manualmente l'output di generazione nella cartella `${OUT}/www` , dove `${OUT}` è la cartella di uscita di ASF che hai specificato con il parametro `-o`. Questo è esattamente ciò che ASF sta facendo come parte del processo di costruzione, copia `ASF-ui/dist` (se esiste) su `${OUT}/www`, niente di speciale, e può anche essere fatto dopo la costruzione come si può vedere, se necessario.

---

## Sviluppo

Se si desidera modificare il codice ASF, è possibile utilizzare qualsiasi . IDE compatibile con ET a tale scopo, anche se è opzionale, dal momento che puoi anche modificare con un blocco note e compilare con il comando `dotnet` descritto sopra.

Se non hai una scelta migliore, possiamo raccomandare **[JetBrains Rider](https://www.jetbrains.com/rider)** e **[Visual Studio Code](https://code.visualstudio.com/download)**, con il primo è l'IDE preferito che il team di ASF sta utilizzando personalmente, e il secondo è una valida alternativa. Entrambi i programmi sono multipiattaforma e disponibili su Linux, macOS e Windows.

---

## Tag

Il ramo `main` non è garantito in uno stato che consenta una compilazione di successo o un'esecuzione impeccabile di ASF in primo luogo, poiché è il suo ramo di sviluppo, proprio come dichiarato nel nostro **[ciclo di rilascio](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. Se vuoi compilare o riferirti ad ASF dalla sorgente, allora dovresti usare il **[tag](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** appropriato per tale scopo, garantendo almeno una compilazione di successo, e molto probabilmente anche l'esecuzione impeccabile (se la build era segnata come versione stabile). Per controllare l'attuale "salute" dell'albero, è possibile utilizzare il nostro CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Versioni ufficiali

Le versioni ufficiali di ASF sono compilate da **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, con le ultime . ET SDK che corrisponde ai requisiti di runtime di ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. Dopo aver superato i testi, tutti i pacchetti sono distribuiti come versione, anche su GitHub. Questo garantisce anche la trasparenza, dato che GitHub usa sempre sorgenti pubbliche ufficiali per tutte le build e poiché puoi comparare le somme di controllo degli artefatti di GitHub con le risorse di rilascio di GitHub. Gli sviluppatori di ASF non compilano o pubblicano loro stessi le build, eccetto per il processo di sviluppo privato e il debug.

Oltre a quanto sopra, i manutentori di ASF convalidano e pubblicano manualmente i checksum di build su indipendenti da GitHub, server ASF remoto, come misura di sicurezza aggiuntiva. Questo passaggio è obbligatorio per gli ASF esistenti per considerare la release come un candidato valido per la funzionalità di aggiornamento automatico.