# Sviluppo plugin

ASF include il supporto per plugin personalizzati che possono essere caricati durante l'esecuzione. I plugin consentono di personalizzare il comportamento di ASF, ad esempio aggiungendo comandi personalizzati, una logica di trading personalizzata o una completa integrazione con servizi e API di terze parti.

Questa pagina descrive i plugin ASF dal punto di vista degli sviluppatori - creare, mantenere, pubblicare e allo stesso modo. Se vuoi vedere la prospettiva dell'utente, muovi **[here](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** invece.

---

## Nucleo

I plugin sono librerie .NET standard che definiscono una classe ereditaria dall'interfaccia `IPlugin` comune dichiarata in ASF. È possibile sviluppare plugin completamente indipendentemente dalla linea principale ASF e riutilizzarli nelle versioni attuali e future di ASF, finché l'API interna di ASF rimane compatibile. Il sistema plugin utilizzato in ASF è basato su `System. omposition`, precedentemente noto come **[Managed Extensibility Framework](https://docs.microsoft.com/dotnet/framework/mef)** che permette a ASF di scoprire e caricare le tue librerie durante il runtime.

---

### Come iniziare

Abbiamo preparato **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate)** per te, che puoi (e dovresti usare) come base per il tuo progetto di plugin. L'utilizzo del template è **non un requisito** (poiché puoi fare tutto da zero), ma raccomandiamo fortemente di prenderlo in quanto può dare un impulso drastico al vostro sviluppo e tagliare il tempo necessario per ottenere tutte le cose bene. Basta controllare il **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** del modello e ti guiderà ulteriormente. Indipendentemente da ciò, copriremo le basi sottostanti nel caso in cui volessi partire da zero, o capire meglio i concetti utilizzati nel modello di plugin - in genere non è necessario fare uno di questi se hai deciso di utilizzare il nostro modello di plugin.

Il tuo progetto dovrebbe essere uno standard . La libreria ET che mira ad un framework appropriato della versione di ASF di destinazione, come specificato nella sezione **[compilation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation)**.

Il progetto deve fare riferimento all'assemblaggio principale `ArchiSteamFarm`, o al suo `ArchiSteamFarm. la libreria ll` che hai scaricato come parte del rilascio, o il progetto sorgente (ad esempio, se hai deciso di aggiungere l'albero ASF come sottomodulo). Questo vi permetterà di accedere e scoprire le strutture, i metodi e le proprietà di ASF, specialmente l'interfaccia `IPlugin` core da cui dovrai ereditare nel passo successivo. Il progetto deve anche fare riferimento a `System.Composition.AttributedModel` al minimo, che ti permette di `[Export]` il tuo `IPlugin` per ASF da usare. Oltre a ciò, potresti volere/avere bisogno di fare riferimento ad altre librerie comuni per interpretare le strutture di dati che ti sono date in alcune interfacce, ma a meno che non ne abbiate bisogno esplicitamente, sarà sufficiente per ora.

Se hai fatto tutto correttamente, il tuo `csproj` sarà simile a sotto:

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <! - Dal momento che stai caricando il plugin nel processo ASF, che include già queste dipendenze, IncludeAssets="compile" ti permette di ometterli dall'output finale -->
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" IncludeAssets="compile" Version="10.0.0" />
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="10.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="C:\\Path\To\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" />

    <! - Se si costruisce con DLL scaricato binario, utilizzare questo invece di <ProjectReference> sopra -->
    <! - <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" /> -->
  </ItemGroup>
</Project>
```

Dal lato del codice, la classe plugin deve ereditare dall'interfaccia `IPlugin` (esplicitamente, o implicitamente ereditando da un'interfaccia più specializzata, come `IASF`) e `[Export(typeof(IPlugin)]` per essere riconosciuti da ASF durante il runtime. L'esempio più nudo che ottiene sarebbe il seguente:

```csharp
usando System;
usando System.Composition;
usando System.Threading.Tasks;
usando ArchiSteamFarm;
usando ArchiSteamFarm.Plugins;

namespace YourNamespace. ourPluginName;

[Export(typeof(IPlugin))]
public sealed class YourPluginName : IPlugin {
	<unk> public string Name => nameof(YourPluginName);
	<unk> public Version Version => typeof(YourPluginName). ssembly.GetName().Version;

	<unk> public Task OnLoaded() {
		<unk> <unk> ASF.ArchiLogger.LogGenericInfo("Ciao Mondo!");

		<unk> <unk> return Task.CompletedTask;
	<unk> }
}
```

Al fine di utilizzare il plugin, è necessario in primo luogo compilarlo. Puoi farlo dal tuo IDE, o dalla directory radice del tuo progetto tramite un comando:

```shell
# Se il tuo progetto è autonomo (non è necessario definire il suo nome poiché è l'unico) dotnet
pubblica -c "Rilascio" -o "out"

# Se il tuo progetto fa parte dell'albero sorgente di ASF (per evitare di compilare parti non necessarie)
dotnet pubblica YourPluginName -c "Rilascio" -o "out"
```

In seguito, il plugin è pronto per l'implementazione. Sta a te come esattamente vuoi distribuire e pubblicare il tuo plugin, ma raccomandiamo di creare un archivio zip dove metterai il plugin compilato insieme alla sua **[dependencies](#plugin-dependencies)**. In questo modo l'utente avrà semplicemente bisogno di scompattare il tuo archivio zip in una sottodirectory standalone all'interno della loro directory `plugins` e non fare altro.

Questo è solo lo scenario più basilare per iniziare. Abbiamo un progetto **[`EsempioPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** che mostra interfacce e azioni di esempio che puoi fare all'interno del tuo plugin, inclusi commenti utili. Sentitevi liberi di dare un'occhiata se si desidera imparare da un codice di lavoro, o scoprire `ArchiSteamFarm. namespace di lugins` e fai riferimento alla documentazione inclusa per tutte le opzioni disponibili. Inoltre approfondiremo ulteriormente alcuni concetti fondamentali qui sotto per spiegarli meglio.

Se invece del plugin di esempio si desidera imparare dai progetti reali, ci sono diversi plugin ufficiali sviluppati da noi, ad es. **[`ItemsMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.ItemsMatcher)**, **[`MobileAuthenticator`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.MobileAuthenticator)** o **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)**. Oltre a ciò, ci sono anche plugin sviluppati da altri sviluppatori, nella nostra sezione **[third-party](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)**.

---

### Disponibilità API

ASF, a parte quello a cui si ha accesso nelle interfacce stesse, espone a Lei un sacco di sue API interne che Lei può fare uso di, al fine di estendere la funzionalità. Ad esempio, se si desidera inviare una sorta di nuova richiesta a Steam web, allora non è necessario implementare tutto da zero, in particolare affrontando tutti i problemi che abbiamo dovuto affrontare prima di te. Basta usare il nostro `Bot. rchiWebHandler` che già espone molti metodi `UrlWithSession()` da usare, gestire tutte le cose di livello inferiore come l'autenticazione, l'aggiornamento della sessione o la limitazione web per voi. Allo stesso modo, per l'invio di richieste web al di fuori della piattaforma Steam, è possibile utilizzare la classe standard .NET `HttpClient`, ma è molto meglio utilizzare `Bot. rchiWebHandler.WebBrowser` che è disponibile per voi, che ancora una volta vi offre una mano utile, per esempio per quanto riguarda la riprovazione delle richieste fallite.

Abbiamo una politica molto aperta in termini di disponibilità delle API, quindi se vuoi fare uso di qualcosa che il codice ASF già include, semplicemente **[apri un problema](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** e spieghi in esso il tuo caso di utilizzo previsto dell'API interna del nostro ASF. Molto probabilmente non avremo nulla contro, finché il tuo caso di utilizzo ha senso. Questo include anche tutti i suggerimenti per quanto riguarda le nuove interfacce `IPlugin` che potrebbero avere senso da aggiungere al fine di estendere le funzionalità esistenti.

Indipendentemente dalla disponibilità di ASF API, tuttavia, nulla ti impedisce di includere, ad esempio, `Discord. et` libreria nella tua applicazione e creazione di un ponte tra il tuo bot Discord e i comandi ASF, dal momento che il plugin può anche avere dipendenze da solo. Le possibilità sono infinite e abbiamo fatto del nostro meglio per darvi la massima libertà e flessibilità possibile all'interno del vostro plugin, quindi non ci sono limiti artificiali su nulla - il vostro plugin è caricato nel processo principale di ASF e può fare tutto ciò che è realisticamente possibile da fare all'interno del codice C# .

---

### API compatibility

È importante sottolineare che ASF è un'applicazione di consumo e non una tipica libreria con superficie API fissa che si può dipendere incondizionatamente. Ciò significa che non si può presumere che il plugin una volta compilato continuerà a lavorare con tutte le versioni future di ASF indipendentemente da ciò, è semplicemente impossibile se vogliamo continuare a sviluppare ulteriormente il programma, e non essere in grado di adattarsi alle continue modifiche di Steam per motivi di retrocompatibilità non è proprio appropriato per il nostro caso. Questo dovrebbe essere logico per voi, ma è importante evidenziare questo fatto.

Faremo del nostro meglio per mantenere le parti pubbliche di ASF funzionanti e stabili, ma non avremo paura di rompere la compatibilità se ci sono ragioni sufficienti, seguendo la nostra politica **[deprecation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation)** nel processo. Ciò è particolarmente importante per quanto riguarda le strutture interne di ASF che sono esposte a voi come parte dell'infrastruttura di ASF (ad es. `ArchiWebHandler`) che potrebbe essere migliorato (e quindi riscritto) come parte di miglioramenti di ASF in una delle versioni future. Faremo del nostro meglio per informarti in modo appropriato nei changelog, e includeremo avvisi appropriati durante il runtime sulle funzionalità obsolete. Non intendiamo riscrivere tutto per riscriverlo, così si può essere abbastanza sicuri che la prossima versione minore di ASF non solo distruggere il plugin interamente perché ha un numero di versione superiore, ma tenere d'occhio i cambi e la verifica occasionale se tutto funziona bene è una buona idea.

---

### Dipendenze plugin

Il tuo plugin includerà almeno due dipendenze per impostazione predefinita, il riferimento `ArchiSteamFarm` per le API interne (`IPlugin` al minimo) e `PackageReference` di `System. omposition.AttributedModel` che è necessario per essere riconosciuto come plugin ASF per iniziare con (`[Export]` clause). In aggiunta a questo, può includere più dipendenze per quanto riguarda ciò che avete deciso di fare nel vostro plugin (e. . Libreria `Discord.Net` se hai deciso di integrarti con Discord).

L'output della tua build includerà la tua libreria `YourPluginName.dll`, così come tutte le dipendenze che hai menzionato. Dal momento che stai sviluppando un plugin per il programma già funzionante, non è necessario, e anche **dovrebbe** includere dipendenze che ASF già include, per esempio `ArchiSteamFarm`, `SteamKit2` o `AngleSharp`. Eliminare le dipendenze di build off condivise con ASF non è il requisito assoluto per il vostro plugin di lavorare, ma così facendo taglierà drasticamente l'impronta di memoria e la dimensione del plugin, insieme all'aumento delle prestazioni, a causa del fatto che ASF condividerà con te le proprie dipendenze, e caricherà solo quelle librerie che non sa di sé.

In generale, è una pratica consigliata per includere solo quelle librerie che ASF non include, o include nella versione sbagliata/incompatibile. Esempi di questi sarebbero ovviamente `YourPluginName.dll`, ma per esempio anche `Discord.Net.dll` se hai deciso di dipendere da esso, poiché ASF non lo include da solo. Le librerie di raggruppamento che sono condivise con ASF possono comunque avere senso se si desidera garantire la compatibilità API (ad es. essere sicuri che `AngleSharp` da cui dipende nel tuo plugin sarà sempre nella versione `X` e non quella con cui ASF viene spedita), ma ovviamente ciò avviene a un prezzo di maggiore memoria/dimensione e prestazioni peggiori, e quindi dovrebbe essere attentamente valutato.

Se sai che la dipendenza di cui hai bisogno è inclusa in ASF, puoi contrassegnarlo con `IncludeAssets="compile"` come ti abbiamo mostrato nell'esempio `csproj` sopra. Questo dirà al compilatore di evitare di pubblicare la libreria di riferimento stessa, come ASF già include quella. Allo stesso modo, nota che facciamo riferimento al progetto ASF con `ExcludeAssets="all" Private="false"` che funziona in modo molto simile - dicendo al compilatore di non produrre alcun file ASF (come l'utente li ha già). Questo si applica solo quando si fa riferimento al progetto ASF, poiché se si fa riferimento a una libreria `dll`, allora non si producono file ASF come parte del plugin.

Se sei confuso con la dichiarazione di cui sopra e non sai meglio, controlla quali librerie `dll` sono incluse in `ASF-generic. pacchetto ip` e assicurati che il tuo plugin includa solo quelli che ancora non ne fanno parte. Questo sarà solo `YourPluginName.dll` per i plugin più semplici. Se si ottengono problemi durante il runtime per quanto riguarda alcune librerie, includere quelle colpite librerie pure. Se tutto il resto fallisce, si può sempre decidere di raggruppare tutto.

---

### Dipendenze native

Le dipendenze native sono generate come parte di build specifiche per OS, in quanto non c'è . ET runtime disponibile sull'host e ASF è in esecuzione attraverso il proprio .NET runtime che viene raggruppato come parte di OS specifica costruzione. Al fine di ridurre al minimo la dimensione di generazione, ASF trims le sue dipendenze native per includere solo il codice che può essere raggiunto all'interno del programma, che taglia effettivamente le parti inutilizzate del runtime. Questo può creare un potenziale problema per voi per quanto riguarda il plugin, se improvvisamente scoprite voi stessi in una situazione in cui il vostro plugin dipende da alcuni. La funzione ET che non è utilizzata in ASF, e quindi le build specifiche per il sistema operativo non possono eseguire correttamente, di solito lanciando `System.MissingMethodException` o `System.Reflection.ReflectionTypeLoadException` nel processo. Man mano che il vostro plugin cresce di dimensioni e diventa sempre più complesso, prima o poi colpirai la superficie che non è coperta dal nostro sistema operativo specifico.

Questo non è mai un problema con le build generiche, perché non hanno mai a che fare con dipendenze native in primo luogo (come hanno tempo di lavoro completo sull'host, eseguendo ASF). Questo è il motivo per cui è una pratica consigliabile **utilizzare il plugin in generici build esclusivamente**, ma ovviamente che ha il proprio lato negativo di tagliare il plugin da utenti che stanno eseguendo build OS-specific di ASF. Se ti stai chiedendo se il tuo problema è correlato alle dipendenze native, è anche possibile utilizzare questo metodo per la verifica, caricare il plugin in ASF generico build e vedere se funziona. Se lo fa, hai coperto le dipendenze dei plugin, ed è la dipendenza nativa che causa problemi.

Purtroppo, abbiamo dovuto fare una scelta difficile tra la pubblicazione intera come parte delle nostre costruzioni specifiche del sistema operativo, e decidere di tagliarlo fuori dalle funzioni inutilizzate, rendendo la costruzione di oltre 80 MB più piccolo rispetto a quella piena. Abbiamo scelto la seconda opzione, ed è purtroppo impossibile per voi includere le funzioni di runtime mancanti insieme al vostro plugin. Se il progetto richiede l'accesso alle funzionalità di runtime che vengono lasciate, è necessario includere completo. ET runtime su cui si dipende e questo significa eseguire il plugin in `generic` ASF flavour. Non è possibile eseguire il plugin nelle build specifiche del sistema operativo, in quanto quelle build sono semplicemente mancanti una funzione di runtime di cui hai bisogno, e . Il runtime ET a partire da ora non è in grado di "unire" la dipendenza nativa che si poteva fornire con la nostra. Forse migliorerà un giorno in futuro, ma a partire da ora semplicemente non è possibile.

Le build specifiche per il sistema operativo di ASF includono il minimo nudo di funzionalità aggiuntive necessarie per eseguire i nostri plugin ufficiali. A parte quello che è possibile, questo anche leggermente estende la superficie alle dipendenze extra richieste per i plugin più di base. Pertanto non tutti i plugin dovranno preoccuparsi di dipendenze native per cominciare - solo quelli che vanno oltre ciò che ASF e i nostri plugin ufficiali hanno bisogno direttamente. Questo è fatto come un extra, poiché se abbiamo bisogno di includere ulteriori dipendenze native noi stessi per i nostri casi di uso proprio, possiamo anche spedirli direttamente con ASF, rendendoli disponibili, e quindi più facile da coprire, anche per voi. Purtroppo, questo non è sempre sufficiente, e come il plugin diventa più grande e più complesso, la probabilità di correre in rifilato funzionalità aumenta. Pertanto, di solito ti consigliamo di eseguire esclusivamente i tuoi plugin personalizzati nel sapore ASF `generic`. È ancora possibile verificare manualmente che la compilazione specifica del sistema operativo di ASF ha tutto ciò che il plugin richiede per la sua funzionalità - ma dal momento che tali modifiche sui vostri aggiornamenti così come il nostro, potrebbe essere difficile da mantenere.

A volte potrebbe essere possibile "funzionare" funzioni mancanti utilizzando opzioni alternative o reimplementarle nel plugin. Questo però non è sempre possibile o praticabile, soprattutto se la funzione mancante proviene da dipendenze di terze parti che si includono come parte del plugin. Si può sempre provare a eseguire il plugin in OS specifico build e tentare di farlo funzionare, ma potrebbe diventare troppo fastidio nel lungo periodo, soprattutto se si desidera dal codice per il solo lavoro, piuttosto che combattere con la superficie di ASF.

---

## Aggiornamenti automatici

ASF offre due interfacce per l'implementazione di aggiornamenti automatici nel plugin:

- `IGitHubPluginUpdates` fornisce un modo semplice per implementare aggiornamenti basati su GitHub simili al meccanismo generale di aggiornamento di ASF
- `IPluginUpdates` fornisce funzionalità di livello inferiore che consentono un meccanismo di aggiornamento personalizzato, se hai bisogno di qualcosa di più complesso

---

### **[`IGithubPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs)**

La lista di controllo minima delle cose che sono necessarie per gli aggiornamenti per funzionare:

- È necessario dichiarare `RepositoryName`, che definisce da dove vengono prelevati gli aggiornamenti.
- È necessario fare uso di tag e rilasci forniti da GitHub. Il tag deve essere in formato analizzabile a una versione del plugin, ad esempio `1.0.0.0`.
- La proprietà `Version` del plugin deve corrispondere al tag da cui proviene. Ciò significa che il binario disponibile sotto il tag `1.2.3.4` deve presentarsi come `1.2.3.4`.
- Ogni tag dovrebbe avere un rilascio appropriato disponibile su GitHub con asset di rilascio file zip che include i file binari del plugin. I file binari che includono le classi `IPlugin` dovrebbero essere disponibili nella directory radice all'interno del file zip.

Ciò consentirà al meccanismo di ASF di:

- Risolvi l'attuale `Version` del tuo plugin, ad esempio `1.0.1`.
- Usa l'API GitHub per recuperare gli ultimi `tag` disponibili nel repo `RepositoryName`, ad esempio `1.0.2`.
- Determina che `1.0.2` > `1.0.1`, controlla il rilascio del tag `1.0.2` per trovare il file `.zip` con l'aggiornamento del plugin.
- Scaricare il file `.zip`, estrarlo e mettere il suo contenuto nella directory che includeva `YourPlugin.dll` prima.
- Riavvia ASF per caricare il tuo plugin nella versione `1.0.2`.

Note complementari:

- Gli aggiornamenti dei plugin potrebbero richiedere valori di configurazione ASF appropriati, vale a dire **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)** e/o **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)**.
- Il nostro modello di plugin include già tutto ciò che ti serve, semplicemente **[rename](https://github.com/JustArchiNET/ASF-PluginTemplate?tab=readme-ov-file#renaming-myawesomeplugin)** il plugin per i valori corretti, e funzionerà fuori dalla scatola.
- È possibile utilizzare la combinazione di ultima release e pre-release, che saranno utilizzati come `UpdateChannel` che l'utente ha definito.
- C'è una proprietà booleana `CanUpdate` che puoi sovrascrivere per disabilitare/abilitare l'aggiornamento dei plugin dal tuo lato, per esempio se si desidera saltare temporaneamente gli aggiornamenti, o per qualsiasi altra ragione.
- È possibile avere più file zip nel rilascio se si desidera destinare diverse versioni di ASF. Vedi `GetTargetReleaseAsset()` **[remarks](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs#L79-L106)**. Ad esempio, puoi avere `MyPlugin-V6-0.zip` e `MyPlugin.zip`, che causerà ASF nella versione `V6. .x.x` per scegliere la prima, mentre tutte le altre versioni di ASF useranno la seconda.
- Se quanto sopra non è sufficiente per te e hai bisogno di una logica personalizzata per scegliere il corretto `. file ip`, puoi sovrascrivere la funzione `GetTargetReleaseAsset()` e fornire l'artefatto per ASF da usare.
- Se il tuo plugin ha bisogno di fare qualche lavoro extra prima/dopo l'aggiornamento, puoi sovrascrivere i metodi `OnPluginUpdateProceeding()` e/o `OnPluginUpdateFinished()`.

---

### **[`IPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IPluginUpdates.cs)**

Questa interfaccia ti permette di implementare una logica personalizzata per gli aggiornamenti se per qualsiasi motivo `IGithubPluginUpdates` non è sufficiente per te, per esempio perché hai tag che non analizzano le versioni, o perché non stai usando la piattaforma GitHub affatto.

C'è una singola funzione `GetTargetReleaseURL()` da sovrascrivere, che si aspetta da te `Uri?` della posizione di aggiornamento del plugin di destinazione. ASF fornisce alcune variabili di base che si riferiscono al contesto con cui è stata chiamata la funzione, ma diverse da quello, sei responsabile per implementare tutto ciò che ti serve in quella funzione e fornire ASF l'URL che dovrebbe essere utilizzato, o `null` se l'aggiornamento non è disponibile.

A parte questo, è simile agli aggiornamenti di GitHub, dove l'URL dovrebbe puntare a un `. file ip` con i file binari disponibili nella directory radice. Hai anche i metodi `OnPluginUpdateProceeding()` e `OnPluginUpdateFinished()` disponibili.