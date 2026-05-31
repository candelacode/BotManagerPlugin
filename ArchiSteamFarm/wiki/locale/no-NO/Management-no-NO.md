# Håndtering

Dette avsnittet dekker pasienter knyttet til å håndtere ASF-prosessen på optimal måte. Selv om det ikke er strengt obligatorisk for bruk, inkluderer det mange tips, triks og god praksis som vi ønsker å dele, spesielt for systemadministratorer, personer som emballerer ASF til bruk i tredjeparts lagringsområder, samt avanserte brukere og også.

---

## `systemd` service for Linux

In `generic` and `linux` variants, ASF comes with `ArchiSteamFarm@.service` file, which is a configuration file of the service for **[`systemd`](https://systemd.io)**. Hvis du ønsker å kjøre ASF som en tjeneste, for eksempel for å starte den automatisk etter oppstart av maskinen, deretter er en korrekt `systemd` tjeneste den beste måten å gjøre det på, på en antagelig måte. derfor anbefaler vi det sterkt å administrere det istedet for å klare det på egenhånd gjennom `nohup`, `skjerm` eller likt.

Først må du opprette kontoen for brukeren du ønsker å kjøre ASF under, forutsatt at den ikke eksisterer ennå. Vi skal bruke `asf` -brukeren for dette eksemplet, hvis du bestemte deg for å bruke en annen en, Du må erstatte `asf` -brukeren i alle eksemplene våre nedenfor med det valgte. Vår tjeneste tillater deg ikke å kjøre ASF som `root`, ettersom den anses som en **[dårlig praksis](#never-run-asf-as-administrator)**.

```sh
su # or sudo -i, for å komme inn til rotskall
useradd -m asf # Lag konto du har tenkt å kjøre ASF under
```

Next pakke ASF ut til `/home/asf/ArchiSteamFarm` mappe. Mappestrukturen er viktig for vår service enhet. det burde være `ArchiSteamFarm` mappen i `$HOME`, så `/home/<user>`. Hvis du gjorde alt riktig, vil det være `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service` -filen eksisterer. Hvis du bruker `linux` varianten og pakke ikke ut filen på Linux, men for eksempel brukte filoverføring fra Windows, deretter må du også ha `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

Vi vil gjøre alle under handlingene som `root`, så gå til skallet med `su` eller `sudo -i`.

For det første er det en god ide å sikre at mappen vår fortsatt tilhører vår `asf` bruker, `chown -hR asf:asf /home/asf/ArchiSteamFarm` henrettet en gang vil gjøre det. Tillatelsen kan være galt, f.eks hvis du har lastet ned og/eller pakket ut zip-filen som `root`.

For det andre, hvis du bruker en generisk variant av ASF, du må sikre at `dotnet` kommandoen gjenkjennes og på en av standardstedene `/usr/local/bin`, `/usr/bin` eller `/bin`. Dette er påkrevd for vår systemtjeneste som utfører `dotnet /path/to/ArchiSteamFarm.dll` kommando. Sjekk om `dotnet --info` fungerer for deg, hvis ja, skriv `kommando -v dotnet` for å finne ut hvor den befinner seg. Hvis du har benyttet offisiell installasjon, skal det være i `/usr/bin/dotnet` eller et av de to andre stedene som er rett tilbake. Hvis det er egendefinert posisjon som `/usr/share/dotnet/dotnet`, opprett en **[symlink](https://wikipedia.org/wiki/Symbolic_link)** for den ved hjelp av `ln -s "$(kommando -v dotnet)" /usr/bin/dotnet`. Nå bør `kommando -v dotnet` rapportere `/usr/bin/dotnet`, som også vil gjøre systemenheten vår fungerer. Hvis du bruker OS-spesifikk variant, trenger du ikke å gjøre noe i den forbindelsen.

Next, execute `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/systemd/system/ArchiSteamFarm\@.service`, this will create a symbolic link to our service declaration and register it in `systemd`. Symbolsk lenke gir ASF mulighet til å oppdatere `systemet` enheten automatisk som en del av ASF-oppdateringen - avhengig av situasjonen din. du kan ønske å bruke den tilnærmingen, eller bare `cp` filen og administrere den selv enn du vil.

Etterpå må du forsikre deg om at `systemd` anerkjenner vår tjeneste:

```
systemctl status ArchiSteamFarm@asf

Basic ArchiSteamFarm@asf.service - ArchiSteamFarm Service (på asf)
     Lastet: lastet (/etc/systemd/system/ArchiSteamFarm@. ervice; deaktivert, eller forhåndsinnstilling: aktivert)
     Aktiv: inaktiv (dead)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Legg spesielt merke til brukeren vi erklærer etter `@`, det er `asf` i vårt tilfelle. Vår systemtjeneste forventer at du skal erklære brukeren, ettersom det påvirker det eksakte stedet til den binære `/home/<user>/ArchiSteamFarm`I tillegg til det faktiske brukersystemet skal prosessen starte.

Dersom systemet returnerte noe lignende som ovenfor, blir alt ordet, og det er nesten gjort. Nå er alt som blir igjen faktisk å starte vår tjeneste som vår valgte bruker: `systemctl start ArchiSteamFarm@asf`. Vent et sekund eller to, og du kan kontrollere statusen igjen:

```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (på asf)
     Lastet: lastet (/etc/systemd/ArchiSteamFarm@.service; Deaktivert; leverandør: aktivert:
     Aktivert: aktiv (kjøring) siden (...)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   HovedPID: (...)
(...)
```

Hvis `system` fastslår `aktiv (kjørt)`, det betyr at alt gikk bra, og du kan verifisere at ASF-prosessen skal være oppe og kjørende, for eksempel med `journalctl -r`, som ASF som standard også skriver til konsollutdata som er registrert i `systemd`. Hvis du er fornøyd med oppsettet du har akkurat nå, kan du be `systemd` om å automatisk starte tjenesten under oppstarten, ved å utføre `-systemctl aktiver ArchiSteamFarm@asf` kommando. Det er alt.

Hvis du ønsker å stoppe prosessen, bare kjør `systemctl stopp ArchiSteamFarm@asf`. Likeså hvis du vil deaktivere ASF fra å bli startet automatisk ved oppstart, `systemctl deaktiverer ArchiSteamFarm@asf` vil gjøre det for deg, det er veldig enkelt.

Please note that, as there is no standard input enabled for our `systemd` service, you won't be able to input your details through the console in usual way. Running through `systemd` is equivalent to specifying **[`Headless: true`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** setting and comes with all its implications. Heldigvis for deg, det er veldig enkelt å administrere din ASF gjennom **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, som vi anbefaler i tilfelle du må utlevere flere opplysninger under pålogging eller på annen måte administrere ASF-prosessen ytterligere.

### Miljø variabler

Det er mulig å levere flere miljøvariabler til vår `systemd` tjeneste. som du vil være interessert i å gjøre i tilfelle du for eksempel ønsker å bruke en tilpasset `--cryptkey` **[kommandolinjeargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**, Dermed spesifiserer `ASF_CRYPTKEY` miljøvariabel.

For å kunne tilby egendefinerte miljøvariabler, opprett `/etc/asf` mappen (dersom den ikke eksisterer), `mkdir -p /etc/asf`. Vi anbefaler til `chown -hR root:root /etc/asf && chmod 700 /etc/asf` for å sikre at bare `rot` brukeren har tilgang til å lese disse filene, fordi de kan inneholde sensitive egenskaper som `ASF_CRYPTKEY`. Etterpå skrive til en `/etc/asf/<user>` , der `<user>` er brukeren som kjører tjenesten under (`asf` i vårt eksempel ovenfor så `/etc/asf/asf`).

Filen skal inneholde alle miljøvariabler du vil gi til prosessen. De som ikke har en dedikert miljøvariabel, kan deklareres i `ASF_ARGS`:

```sh
# Erklærer bare de du faktisk trenger
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# Og alle andre du er interesserte i
```

### Overstyrende del av serviceenheten

Takket være fleksibiliteten til `systemd`, Det er mulig å overskrive deler av ASF-enhet mens du fremdeles bevarer den opprinnelige enhetsfilen og tillater ASF å oppdatere den for eksempel som en del av auto-oppdateringer.

I dette eksemplet ønsker vi å endre standard ASF `systemd` enhetsoppførsel fra å bare starte på suksess, å restarte også ved fatalt krasj. For å gjøre det, Vi vil overstyre `Restart` egenskapen under `[Service]` fra standard `on-success` til `alltid`. Bare utføre `systemctl rediger ArchiSteamFarm@asf`, naturlig erstatter `asf` med din brukers målbruker. Deretter legg du til endringene slik `system d` i riktig del:

```sh
### Redigering /etc/systemd/system/ArchiSteamFarm@asf.service.d/override. onf
### Alt mellom her og kommentaren nedenfor vil bli det nye innholdet i filen

[Service]
Restart=alltid

### Linjer nedenfor denne kommentaren vil forkastes

### /etc/systemd/system/ArchiSteamFarm@asf. Nummer
# [Install]
# WantedBy=multi-user. arget
# 
# [Service]
# Miljøfile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm. ll --no-restart --service --system-påkrevd
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# Bruker=%i
# (...)
```

Og det er det, nå din enhet fungerer som om den bare hadde `Restart=alltid` under `[Service]`.

Selvsagt er et alternativ til `cp` som inneholder filen og administrerer den selv. men dette gjør det mulig for deg å få fleksible endringer selv om du valgte å beholde den opprinnelige ASF-enheten, for eksempel med en **[symlink](https://wikipedia.org/wiki/Symbolic_link)**.

---

## Aldri kjør ASF som administrator!

ASF inkluderer sin egen validering om prosessen kjøres som administrator (`root`) eller ikke. Kjører som `root` er **ikke** nødvendig for noen form for operasjon som utføres av ASF-prosessen, under forutsetning av riktig konfigurering av miljø det er operativt og bør derfor anses som en **dårlig praksis**. Dette betyr at på Windows, ASF bør **aldri** utføres med "run as administrator" innstilling, og på Unix ASF burde for seg selv ha en **dedikert brukerkonto** eller bruke desktop-systemet på nytt.

For ytterligere utarbeidelse av *hvorfor* fraråder vi å kjøre ASF som `root`, referer til **[superbruker](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** og andre ressurser. Hvis du fortsatt ikke er overbevist spør deg selv hva som ville skje med maskinen din hvis ASF-prosessen kjørte `rm -rf /*` -kommandoen rett etter oppstart.

### Jeg kjører som `root` fordi ASF ikke kan skrive til filene

Dette betyr at du har konfigurert feilaktig tillatelser for filene ASF prøver å få tilgang. Du bør logge inn som `root` konto (enten med `su` eller `sudo -i`) og deretter **riktige** rettighetene ved å gi `chown -hR asf:asf /path/to/ASF` kommandand, Ved å erstatte `asf:asf` med brukeren som du vil kjøre ASF under, og `/path/to/ASF` deretter. Hvis du av en sjanse bruker du egendefinert `--path` forteller ASF-bruker til å bruke den andre mappen, du burde utføre samme kommando på nytt for den stien også.

Etter dette bør du ikke lenger få noen form for problem knyttet til ASF for ikke å kunne skrive via egne filer, siden du nettopp endret eieren av alt ASF er interessert i brukeren ASF-prosessen vil bli kjørt under.

### Jeg kjører som `root` fordi jeg ikke vet hvordan å gjøre det ellers

```sh
su # Eller sudo -i, for å komme inn på rotskall
useradd -m asf # Lag konto du har til å kjøre ASF under
chown -hR asf:asf /path/to/ASF # Sørg for at din nye bruker har tilgang til ASF katalogen
su asf -c /path/to/ASF/ArchiSteamFarm # Or sudo -u asf /path/to/ASF/ArchiSteamFarm, for å faktisk starte programmet under din bruker
```

Det ville gjort det manuelt, det er mye enklere å bruke vår **[`-systemd` -tjeneste](#systemd-service-for-linux)** forklart over.

### Jeg vet bedre og jeg vil fremdeles kjøre som `root`

ASF hindrer ikke at du gjør dette, og viser bare en advarsel med kort varsel. Bare ikke sjokkeres hvis en dag på grunn av en feil i programmet så blåser hele OS med fullstendig datapap - du har blitt advart.

---

## Flere eksempler

ASF er kompatibel med å kjøre flere forekomster av prosessen på samme maskin. Eksemplene kan være fullstendig frittstående eller utledet fra samme binære plassering (i så fall den samme du vil kjøre dem med forskjellig `--path` **[kommandolinjeargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**).

Når du kjører flere forekomster fra samme binære stoff, husk at du vanligvis bør deaktivere automatiske oppdateringer i alle konfigurasjonene sine, ettersom det ikke er noen synkronisering mellom dem med hensyn til automatiske oppdateringer. Hvis du vil fortsette å ha automatiske oppdateringer aktivert, anbefaler vi enkeltstående tilfeller, men du kan fortsatt lage oppdateringer så lenge du kan sørge for at alle andre ASF-instanser er lukket.

ASF vil gjøre sitt beste for å opprettholde en minste mengde OS-bredde, kryssbehandling med andre ASF-forekomster. Dette omfatter ASF som kontrollerer konfigurasjonsmappen i forhold til andre forekomster, i tillegg til å dele kjernestrømbegrensere konfigurert med `*LimiterDelay` **[globale konfigurasjonsegenskaper](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, sørge for at kjøring av flere ASF-tilfeller ikke vil føre til at de kan føres til et frekvensbegrensende problem. Når det gjelder tekniske forhold, bruker alle plattformer vår dedikerte mekanisme av tilpassede ASF-fillåser opprettet som midlertidig katalog, som er `C:\Users\<YourUser>\AppData\Local\Temp\ASF` på Windows, og `/tmp/ASF` på Unix.

Det kreves ikke for å kjøre ASF-forekomster for å dele de samme `*LimiterDelay` -egenskapene, de kan bruke ulike verdier, ettersom hver ASF vil legge til egne konfigurerte forsinkelser i frigjøringstiden etter å ha hentet inn låsen. Hvis den konfigurerte `*LimiterDelay` er satt til `0`, ASF-forekomst vil helt hoppe over venting på den gitte ressursen som er delt med andre eksempler (det kan potensielt fortsatt holde en felles lås med hverandre). Når satt til en annen verdi, vil ASF synkronisere riktig med andre ASF-instanser og vente på tur, frigi deretter låsen etter konfigurert forsinkelse, og tillater andre forekomster å fortsette.

ASF tar hensyn til `WebProxy` når du bestemmer om delt omfang, som betyr at to ASF-forekomster ved å bruke ulike `WebProxy` konfigurasjoner ikke vil dele sine grensebrytere med hverandre. Dette er implementert for å tillate `WebProxy` oppsett for å operere uten overdrevne forsinkelser, som forventet fra forskjellige nettverksgrensesnitt. Dette skal være godt nok for de fleste brukshandlinger, men hvis du har et spesifikt oppsett som du er for eksempel routing forespørsler deg selv på en annen måte, du kan angi nettverksgruppe selv gjennom `--network-group` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**, som vil la deg deklarere ASF-gruppe som vil bli synkronisert med denne forekomsten. Husk at egendefinerte nettverksgrupper brukes utelukket, som betyr at ASF ikke lenger vil bruke `WebProxy` til å bestemme riktig gruppe. som det er du som står for gruppering i denne saken.

Hvis du vil bruke vår **[`systemd` tjeneste](#systemd-service-for-linux)** forklart over for flere ASF-forekomster, Det er svært enkel, bruk bare en annen bruker til vår `ArchiSteamFarm@` serviceerklæring og følg med resten av trinnene. Dette vil være ekvivalent til å kjøre flere ASF-forekomster med tydelige binærer, slik at de også kan automatisere og fungere uavhengig av hverandre.