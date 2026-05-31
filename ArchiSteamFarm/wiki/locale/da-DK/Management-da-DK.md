# Behandling

Dette afsnit dækker emner i forbindelse med optimal styring af ASF-processen. Mens det ikke er strengt obligatorisk for brug, det omfatter flok tips, tricks og god praksis, som vi gerne vil dele, især for systemadministratorer, folk emballerer ASF til brug i tredjeparts repositories, samt avancerede brugere og ens.

---

## `systemd` service til Linux

I `generisk` og `linux` varianter, ASF kommer med `ArchiSteamFarm@. ervice` -fil som er en konfigurationsfil af tjenesten for **[`systemd`](https://systemd.io)**. Hvis du gerne vil køre ASF som en tjeneste, for eksempel for at starte det automatisk efter opstart af din maskine, så en korrekt `systemd` service er nok den bedste måde at gøre det, Derfor anbefaler vi det i stedet for at styre det på egen hånd gennem `nohup`, `skærm` eller ens.

Først skal du oprette kontoen for den bruger, du ønsker at køre ASF under, forudsat at det ikke eksisterer endnu. Vi vil bruge `asf` bruger for dette eksempel, hvis du har besluttet at bruge en anden, du skal erstatte `asf` bruger i alle vores eksempler nedenfor med din valgte. Vores service tillader dig ikke at køre ASF som `root`, da det betragtes som en **[dårlig praksis](#never-run-asf-as-administrator)**.

```sh
su # Eller sudo -i, for at komme ind root shell
useradd -m asf # Opret konto, du har til hensigt at køre ASF under
```

Udpak derefter ASF til mappen `/home/asf/ArchiSteamFarm`. Mappen struktur er vigtig for vores service enhed, det skal være `ArchiSteamFarm` mappe i din `$HOME`, so `/home/<user>`. Hvis du gjorde alt korrekt, vil der være `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service` fil eksisterer. Hvis du bruger `linux` -variant og ikke pakker filen ud på Linux, men for eksempel brugt filoverførsel fra Windows, så skal du også `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

Vi vil gøre alle nedenstående handlinger som `root`, så komme til sin shell med `su` eller `sudo -i`.

For det første er det en god idé at sikre, at vores mappe stadig tilhører vores `asf` bruger, `chown -hR asf:asf /home/asf/ArchiSteamFarm` udført når vil gøre det. Tilladelserne kan være forkerte, f.eks. hvis du har downloadet og/eller udpakkede zip-filen som `root`.

For det andet, hvis du bruger generisk variant af ASF du skal sikre at `dotnet` -kommandoen er genkendt og inden for et af standardstederne: `/usr/local/bin`, `/usr/bin` eller `/bin`. Dette er nødvendigt for vores systemd-tjeneste, som udfører kommandoen `dotnet /path/to/ArchiSteamFarm.dll`. Vælg om `dotnet --info` virker for dig, hvis ja, skriv `kommandoen -v dotnet` for at finde ud af, hvor den er placeret. Hvis du har brugt officiel installatør, skal det være i `/usr/bin/dotnet` eller et af de to andre steder, som er i orden. Hvis det er i brugerdefineret placering, såsom `/usr/share/dotnet/dotnet`, opret et **[symlink](https://wikipedia.org/wiki/Symbolic_link)** for det ved hjælp af `ln -s "$(command -v dotnet)" /usr/bin/dotnet`. Nu skal `kommando -v dotnet` rapportere `/usr/bin/dotnet`, som også vil få vores systemd enhed til at fungere. Hvis du bruger OS-specifik variant, behøver du ikke at gøre noget i denne henseende.

Dernæst eksekverer `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/systemd/system/ArchiSteamFarm\@. ervice`, vil dette skabe et symbolsk link til vores service erklæring og registrere det i `systemd`. Symbollink vil tillade ASF at opdatere din `systemd` enhed automatisk som en del af ASF opdatering - afhængigt af din situation kan du bruge denne tilgang, eller blot `cp` filen og administrere den selv, som du selv gerne vil.

Bagefter skal du sikre, at `systemd` genkender vores service:

```
systemctl status ArchiSteamFarm@asf

¤ ArchiSteamFarm@asf.service - ArchiSteamFarm Service (på asf)
     Loaded: loaded (/etc/systemd/system/ArchiSteamFarm@. ervice; deaktiveret; Forudindstilling: aktiveret)
     Aktiv: inaktiv (dead)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Vær særlig opmærksom på den bruger, vi erklærer efter `@`, det er `asf` i vores tilfælde. Vores systemd service enhed forventer af dig til at erklære brugeren, da det påvirker det nøjagtige sted for den binære `/home/<user>/ArchiSteamFarm`, såvel som den faktiske bruger systemd vil gyde processen som.

Hvis systemd returnerede output ligner ovenstående, alt er i orden, og vi er næsten færdig. Nu er alt hvad der er tilbage faktisk starter vores service som vores valgte bruger: `systemctl start ArchiSteamFarm@asf`. Vent et sekund eller to, og du kan tjekke status igen:

```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (på asf)
     Loaded: loaded (/etc/systemd/ArchiSteamFarm@.service; disabled; vendor preset: aktiveret)
     Aktiv: aktiv (kørende) siden (...)
       Dokumenter: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   Main PID: (...)
(...)
```

Hvis `systemd` angiver `aktiv (running)`, det betyder, at alt gik godt, og du kan kontrollere, at ASF-processen skal være oppe og køre, for eksempel med `journalctl -r`, som ASF som standard også skriver til sin konsol-output, som registreres af `systemd`. Hvis du er tilfreds med den opsætning, du har lige nu, kan du bede `systemd` automatisk starte din tjeneste under opstart, ved at udføre `systemctl aktivere ArchiSteamFarm@ asf` kommando. Det er alt.

Hvis du på nogen måde ønsker at stoppe processen, skal du blot udføre `systemctl stop ArchiSteamFarm@asf`. Ligeledes, hvis du ønsker at deaktivere ASF fra at blive startet automatisk ved boot, `systemctl deaktivere ArchiSteamFarm@asf` vil gøre det for dig, det er meget simpelt.

Bemærk venligst, at da der ikke er nogen standard input aktiveret for vores `systemd` service, du vil ikke være i stand til at indtaste dine oplysninger via konsollen på sædvanlig måde. Kører gennem `systemd` svarer til at angive **[`Fordele: sand`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** indstilling og kommer med alle dens konsekvenser. Heldigvis for dig er det meget nemt at administrere din ASF via **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, som vi anbefaler, hvis du har brug for yderligere oplysninger under login eller på anden måde administrere din ASF proces yderligere.

### Miljøvariabler

Det er muligt at levere yderligere miljøvariabler til vores `systemd` service, hvilket du vil være interesseret i at gøre, hvis du ønsker for eksempel at bruge et brugerdefineret `--cryptkey` **[kommandolinje argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**, derfor med angivelse af `ASF_CRYPTKEY` miljøvariabel.

For at kunne levere brugerdefinerede miljøvariabler, opret mappen `/etc/asf` (i tilfælde af at den ikke eksisterer), `mkdir -p /etc/asf`. Vi anbefaler `chown -hR root:root /etc/asf && chmod 700 /etc/asf` for at sikre, at kun `root` bruger har adgang til at læse disse filer, fordi de kan indeholde følsomme egenskaber såsom `ASF_CRYPTKEY`. Skriv derefter til filen `/etc/asf/<user>` hvor `<user>` er den bruger, du kører tjenesten under (`asf` i vores eksempel ovenfor, så `/etc/asf/asf`).

Filen skal indeholde alle miljøvariabler, som du gerne vil give til processen. De, der ikke har en dedikeret miljøvariabel, kan angives i `ASF_ARGS`:

```sh
# Erklære kun dem, du rent faktisk har brug for
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# Og alle andre du er interesseret i
```

### Tilsidesættende del af tjenesteenheden

Takket være fleksibiliteten i `systemd`, det er muligt at overskrive en del af ASF enhed, mens stadig bevare den oprindelige enhed fil og tillade ASF at opdatere det for eksempel som en del af auto-opdateringer.

I dette eksempel vil vi gerne ændre standard ASF `systemd` enhed adfærd fra at genstarte kun på succes, til at genstarte også ved fatale nedbrud. For at gøre det vil tilsidesætte `Genstart` ejendom under `[Service]` fra standard `on-success` til `altid`. Du skal blot udføre `systemctl edit ArchiSteamFarm@asf`, naturligt erstatte `asf` med målbrugeren af din tjeneste. Tilføj derefter dine ændringer som angivet af `systemd` i korrekt afsnit:

```sh
### Redigering /etc/systemd/system/ArchiSteamFarm@asf.service.d/override. onf
### Anything between here and the comment below will become the new content of the file

[Service]
Restart=always

### Lines below this comment will be discarded

### /etc/systemd/system/ArchiSteamFarm@asf. ervice
# [Install]
# WantedBy=multi-user. arget
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm. ll --no-genstart --service --system-required
# Genstart=on-success
# GenstartSec=1s
# SyslogIdentifier=asf-%i
# Bruger=%i
# (...)
```

Og det er det, nu virker din enhed det samme, som hvis den kun havde `Genstart=altid` under `[Service]`.

Selvfølgelig er alternativ til `cp` filen og administrere den selv, men dette giver dig mulighed for fleksible ændringer, selv hvis du besluttede at holde oprindelige ASF enhed, for eksempel med et **[symlink](https://wikipedia.org/wiki/Symbolic_link)**.

---

## Kør aldrig ASF som administrator!

ASF omfatter sin egen validering, om processen køres som administrator (`root`) eller ej. Kører som `root` er **ikke** påkrævet for nogen form for operation udført af ASF proces, forudsat at det er konfigureret korrekt, at det opererer i, og derfor bør betragtes som en **dårlig praksis**. Det betyder, at på Windows, ASF bør **aldrig** blive udført med "køre som administrator" indstilling, og på Unix ASF skal have en **dedikeret brugerkonto** for sig selv, eller genbrug din egen i tilfælde af et skrivebordssystem.

For yderligere uddybning af *hvorfor* vi modvirker at køre ASF som `root`, henvise til **[superbruger](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** og andre ressourcer. Hvis du stadig ikke er overbevist, spørg dig selv, hvad der ville ske med din maskine, hvis ASF proces udført `rm -rf /*` kommando lige efter lanceringen.

### Jeg kører som `root` , fordi ASF ikke kan skrive til sine filer

Det betyder, at du har forkert konfigureret tilladelser til filerne ASF forsøger at få adgang. Du skal logge ind som `root` konto (enten med `su` eller `sudo -i`) og derefter **rette** tilladelserne ved at udstede `chown -hR asf:asf /path/to/ASF` kommando, erstatte `asf:asf` med brugeren, som du vil køre ASF under, og `/path/to/ASF` i overensstemmelse hermed. Hvis du tilfældigvis bruger brugerdefineret `--path` , der fortæller ASF brugeren at bruge den forskellige mappe, du bør udføre den samme kommando igen for den sti så godt.

Efter at gøre det, bør du ikke længere få nogen form for spørgsmål i forbindelse med ASF ikke være i stand til at skrive over sine egne filer, som du lige har ændret ejeren af alt ASF er interesseret i at brugeren ASF processen rent faktisk vil køre under.

### Jeg kører som `root` , fordi jeg ikke ved, hvordan man gør det ellers

```sh
su # Or sudo -i, for at komme ind i root shell
useradd -m asf # Opret konto, du har til hensigt at køre ASF under
chown -hR asf:asf /path/to/ASF # Sørg for, at din nye bruger har adgang til ASF-mappen
su asf -c /path/to/ASF/ArchiSteamFarm # Eller sudo -u asf /path/to/ASF/ArchiSteamFarm, til faktisk at starte programmet under din bruger
```

Det ville gøre det manuelt, det er meget nemmere at bruge vores **[`systemd` service](#systemd-service-for-linux)** forklaret ovenfor.

### Jeg ved bedre, og jeg ønsker stadig at køre som `root`

ASF stopper dig ikke kraftigt fra at gøre det, kun viser en advarsel med en kort varsel. Bare ikke blive chokeret, hvis en dag på grund af en fejl i programmet det vil sprænge hele dit operativsystem med komplet tab af data - du er blevet advaret.

---

## Flere instanser

ASF er kompatibel med at køre flere forekomster af processen på samme maskine. De tilfælde kan være helt standalone eller stammer fra den samme binære placering (i hvilket tilfælde, du ønsker at køre dem med forskellige `--path` **[kommandolinje argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**).

Når du kører flere forekomster fra samme binær, skal du huske på, at du typisk skal deaktivere auto-opdateringer i alle deres configs, da der ikke er nogen synkronisering mellem dem med hensyn til auto-opdateringer. Hvis du gerne vil fortsætte med at have auto-opdateringer aktiveret, anbefaler vi enkeltstående tilfælde, men du kan stadig få opdateringer til at virke, så længe du kan sikre, at alle andre ASF tilfælde er lukket.

ASF vil gøre sit bedste for at opretholde et minimum af OS-dækkende tværgående kommunikation med andre ASF-instanser. Dette omfatter ASF kontrollere dens konfigurationsmappe mod andre tilfælde, samt deling af centrale process-dækkende limiters konfigureret med `*LimiterDelay` **[globale konfigurationsegenskaber](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, at sikre, at kørsel af flere forekomster af ASF ikke vil give mulighed for at løbe ind i et spørgsmål om hastighedsbegrænsning. Hvad angår tekniske aspekter, bruger alle platforme vores dedikerede mekanisme af brugerdefinerede ASF fil-baserede låse oprettet i midlertidig mappe, som er `C:\Users\<YourUser>\AppData\Local\Temp\ASF` på Windows og `/tmp/ASF` på Unix.

Det er ikke nødvendigt for at køre ASF instanser til at dele de samme `*LimiterDelay` egenskaber, de kan bruge forskellige værdier, da hver ASF vil tilføje sin egen konfigurerede forsinkelse til udgivelsestiden efter at have erhvervet låsen. Hvis den konfigurerede `*LimiterDelay` er indstillet til `0`, ASF instans vil helt springe venter på låsen af en given ressource, der deles med andre forekomster (som potentielt stadig kunne opretholde en delt lås med hinanden). Når sat til en anden værdi, vil ASF korrekt synkronisere med andre ASF tilfælde og vente på sin tur, slip derefter låsen efter konfigureret forsinkelse, så andre tilfælde kan fortsætte.

ASF tager hensyn til `WebProxy` indstilling, når der træffes beslutning om delt rækkevidde, hvilket betyder, at to ASF tilfælde ved hjælp af forskellige `WebProxy` konfigurationer ikke vil dele deres limiters med hinanden. Dette er implementeret for at tillade `WebProxy` opsætninger at fungere uden overdreven forsinkelse, som forventet fra forskellige netværksgrænseflader. Dette bør være godt nok til de fleste brugssager, men hvis du har en specifik brugerdefineret opsætning, hvor du f.eks. routing anmoder dig selv på en anden måde, du kan selv angive netværksgruppe gennem `--network-group` **[kommandolinje argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**, som vil give dig mulighed for at erklære ASF gruppe, der vil blive synkroniseret med denne instans. Husk, at brugerdefinerede netværksgrupper bruges udelukkende, hvilket betyder, at ASF ikke længere vil bruge `WebProxy` til at bestemme den rigtige gruppe som du er ansvarlig for gruppering i dette tilfælde.

Hvis du gerne vil benytte vores **[`systemd` tjeneste](#systemd-service-for-linux)** forklaret ovenfor for flere ASF tilfælde, Det er meget enkelt, bare brug en anden bruger til vores `ArchiSteamFarm@` service erklæring og følg med resten af trinene. Dette vil svare til at køre flere ASF tilfælde med forskellige binære enheder, så de også kan auto-opdatere og fungere uafhængigt af hinanden.