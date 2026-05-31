# Docker

ASF er tilgængelig som **[docker container](https://www.docker.com/what-container)**. Vores docker-pakker er i øjeblikket tilgængelige på **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** samt **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

Det er vigtigt at bemærke, at kørsel af ASF i Docker-beholder betragtes som **avanceret opsætning**, som er **ikke har brug for** for langt de fleste brugere, og giver typisk **ingen fordele** i forhold til opsætning uden beholder. Hvis du overvejer Docker som en løsning til at køre ASF som en tjeneste, for eksempel gør det starter automatisk med dit operativsystem, så bør du overveje at læse **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** sektion i stedet og oprette en korrekt `systemd` service, som vil være **næsten altid** en bedre idé end at køre ASF i en Docker container.

Kører ASF i Docker-containeren involverer normalt **flere nye problemer og problemer** , som du bliver nødt til at stå over for og løse dig selv. Det er derfor, vi **kraftigt** anbefaler dig at undgå det, medmindre du allerede har Docker viden og ikke har brug for hjælp til at forstå sine interne om hvilket vi ikke vil uddybe her på ASF wiki. Dette afsnit er for det meste til gyldig brug tilfælde af meget komplekse opsætninger, for eksempel med hensyn til avanceret netværk eller sikkerhed ud over standard sandboxing, ASF leveres med i tjeneste `systemd` (som allerede sikrer overlegen proces isolation gennem meget avancerede sikkerhedsmekanikker). For disse håndfulde mængder af mennesker, her forklarer vi bedre ASF begreber i forhold til sin Docker kompatibilitet, og kun det, du antages at have tilstrækkelig Docker viden selv, hvis du beslutter dig for at bruge det sammen med ASF.

---

## Mærker

ASF er tilgængelig via flere typer af **[tags](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `vigtigste`

Generisk opbygning af ASF, der er bygget ud fra den seneste forpligtelse i `hovedafdeling` , som virker det samme som at snuppe seneste artefakt direkte fra vores **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pipeline. Det er det højeste niveau af bugged software dedikeret til udviklere og avancerede brugere til udviklingsformål. Billedet opdateres med hver commit i `hovedafdelingen` GitHub du kan derfor meget ofte forvente ændringer (og ting bliver brudt). Det er her for at markere den aktuelle tilstand af ASF projektet, som ikke nødvendigvis garanteres at være stabil eller afprøvet, ligesom det påpeges i vores udgivelsescyklus. **Dette tag må ikke bruges i noget produktionsmiljø**. Nyttigt til at kontrollere, om bestemte begå fast det problem, du støder på, uden at vente på en pre-release med det pågældende tilsagn.


### `released`

Generisk opbygning af ASF, der altid peger på den seneste **[udgivet](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF-version, herunder præ-udgivelser. Sammenlignet med `main` tag, opdateres billedet her, hver gang et nyt GitHub tag trykkes. Dedikeret til avancerede / power brugere, der elsker at leve på kanten af, hvad der kan betragtes som stabil og frisk på samme tid. I praksis virker det på samme måde som rullemærket, der peger på den seneste udgivelse af `A.B.C.D` på tidspunktet for trækkraften. Bemærk, at brug af dette tag er lig med brug af vores **[pre-releases](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `stabil`

Generisk opbygning af ASF, der altid peger på den seneste **[stabile](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF version. Sammenlignet med `udgivet` tag, bliver billedet opdateret, når den nye stabile version af ASF er tilgængelig. Anbefales til personer, der er på udkig efter en stabil variant af `udgivet` tag nævnt ovenfor.

### `latest`

OS-specifik opbygning af ASF, der altid peger på den seneste **[stabile](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF version. I forhold til andre er dette **kun tag** , der indeholder ASF auto-opdateringer. Formålet med dette tag er at give en sund standard Docker beholder, der er i stand til at køre selvopdatering, OS-specifik opbygning af ASF. På grund af det, behøver billedet ikke at blive opdateret så ofte som muligt, som inkluderet ASF-version vil altid være i stand til at opdatere sig selv, hvis det er nødvendigt.

Selvfølgelig kan `UpdatePeriod` sikkert slukkes (indstillet til `0`), men i dette tilfælde skal du sandsynligvis bruge `stabil` udgivelse i stedet. Ligeledes kan du ændre standard `UpdateChannel` for at spore præudgivelser i stedet, hvis du gerne vil.

På grund af det faktum, at `seneste` billede kommer med mulighed for auto-opdateringer, det omfatter bare OS med OS-specifik `linux` ASF-version, i modsætning til alle andre tags , der inkluderer OS med . ET runtime og `generisk` ASF version. Dette skyldes, at nyere (opdateret) ASF version kan også kræve nyere runtime end den, billedet muligvis kunne bygges med, som ellers ville kræve, at billedet skulle genopbygges fra bunden, og at den planlagte brugssag skulle annulleres.

### `A.B.C.D`

Generisk opbygning af ASF, der peger på den faste ASF-version, der matcher tagget. I forhold til ovenstående tags, dette tag er helt frosset, hvilket betyder, at billedet her ikke vil blive opdateret når offentliggjort. Dette virker i lighed med vores GitHub udgivelser, der aldrig berøres efter den oprindelige udgivelse, hvilket garanterer dig stabile og frosne omgivelser. Typisk skal du bruge dette mærke når du vil bruge en bestemt ASF release og forventer deterministisk resultat af byggeriet (f. eks. . administrere ASF versioner selv i stedet).

---

## Hvilket tag er det bedste for mig?

Det afhænger af, hvad du leder efter. For de fleste brugere bør `seneste` tag være den bedste, da det tilbyder præcis, hvad desktop ASF gør, bare i særlige Docker container som en tjeneste. Dette er dog ikke nødvendigvis, hvordan docker skal bruges - normalt forventes du at genopbygge dine containere og ikke køre dem for evigt, og i dette tilfælde bør du overveje `stabile` eller `udgivet` tag, som følger docker retningslinjer. Endelig, hvis du ønsker at køre nogle faste ASF-version i stedet, så naturligvis `A.B.C.D` udgivelser er hvad du leder efter.

Vi afskrækker generelt forsøger `main` bygger, da de er her for os at markere den aktuelle tilstand af ASF projekt. Intet garanterer, at en sådan stat vil fungere ordentligt men selvfølgelig er du mere end velkommen til at give dem en prøve, hvis du er interesseret i ASF udvikling.

---

## Arkitekturer

ASF docker image er i øjeblikket bygget på `linux` platform target 3 arkitekturer - `x64`, `arm` og `arm64`. Du kan læse mere om dem i afsnittet **[kompatibilitet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**.

Vores tags bruger multi-platform manifest, hvilket betyder, at Docker installeret på din maskine vil automatisk vælge det rigtige billede til din platform, når du trækker billedet. Hvis du på nogen måde ønsker at trække et bestemt platformsbillede, som ikke svarer til det, du kører i øjeblikket, du kan gøre det gennem `--platform` skifte i passende docker kommandoer, såsom `docker køre`. Se docker dokumentation på **[image manifest](https://docs.docker.com/registry/spec/manifest-v2-2)** for mere info.

---

## Brug

For komplet reference skal du bruge **[officielle docker dokumentation](https://docs.docker.com/engine/reference/commandline/docker)**, vi dækker kun grundlæggende brug i denne guide, du er mere end velkommen til at grave dybere.

### Hello ASF!

For det første skal vi kontrollere, om vores docker endda fungerer korrekt, vil dette fungere som vores ASF "goddag verden":

```shell
docker run - it -- name asf -- pull always --rm justarchi/archisteamfarm
```

`docker run` skaber en ny ASF docker container til dig og kører den i forgrunden (`-it`). `--pull altid` sikrer, at opdateret billede vil blive trukket først, og `--rm` sikrer, at vores beholder vil blive renset en gang stoppet, da vi bare tester, hvis alt fungerer fint for nu.

Hvis alt sluttede med succes, efter at have trukket alle lag og startbeholder, De bør bemærke, at ASF startede korrekt og informerede os om, at der ikke er nogen definerede robotter som er god - vi kontrollerede, at ASF i docker fungerer korrekt. Hit `CTRL+C` for at afslutte ASF-processen og derfor også containeren.

Hvis du tager et nærmere kig på kommandoen, så vil du bemærke, at vi ikke erklærer nogen tag, som automatisk misligholdt `seneste` én. Hvis du ønsker at bruge andre tag end `seneste`, for eksempel `udgivet`, så skal du erklære det udtrykkeligt:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm:released
```

---

## Brug af lydstyrke

Hvis du bruger ASF i docker container så naturligvis du har brug for at konfigurere selve programmet. Du kan gøre det på forskellige måder, men den anbefalede vil være at oprette ASF `config` mappe på lokal maskine, montere det som en fælles volumen i ASF docker container.

For eksempel vil vi antage, at din ASF config mappe er i `/home/archi/ASF/config` mappe. Denne mappe indeholder kerne `ASF.json` samt bots, som vi ønsker at køre. Nu skal vi blot vedhæfte denne mappe som delt volumen i vores docker container, hvor ASF forventer sin konfigurationsmappe (`/app/config`).

```shell
docker køre -it -v /home/archi/ASF/config:/app/config --name asf --pull altid justarchi/archisteamfarm
```

Og det er det, nu bruger din ASF-dockercontainer delt mappe med din lokale maskine i læse-skrivningstilstand, hvilket er alt hvad du har brug for til at konfigurere ASF. På samme måde kan du montere andre volumener, som du gerne vil dele med ASF, såsom `/app/logs` eller `/app/plugins`.

Selvfølgelig er dette blot én specifik måde at opnå det, vi ønsker, intet er at forhindre dig i f.eks. oprette din egen `Dockerfile` , der vil kopiere dine konfigurationsfiler til `/app/config` mappe i ASF docker container. Vi dækker kun grundlæggende brug i denne guide.

### Tilladelser til lydstyrke

ASF container som standard er initialiseret med standard `root` bruger, som gør det muligt at håndtere de interne tilladelser ting og derefter i sidste ende skifte til `asf` (UID `1000`) bruger for den resterende del af hovedprocessen. Mens dette bør være tilfredsstillende for langt de fleste brugere, det påvirker det delte volumen, da nyligt genererede filer normalt ejes af `som` -bruger som måske ikke er ønsket situation, hvis du gerne vil have en anden bruger til din delte volumen.

Der er to måder, du kan ændre brugeren ASF kører under. Den første, anbefalede, er at deklarere `ASF_UID` miljøvariabel med mål UID du ønsker at køre under. For det andet, alternativ er, at passere `--user` **[flag](https://docs.docker.com/engine/reference/run/#user)**, som er direkte understøttet af docker.

Du kan tjekke din `uid` for eksempel med `id -u` kommando, og derefter erklære den som angivet ovenfor. For eksempel, hvis din målbruger har `uid` 1001:

```shell
docker run -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm

# Alternativt, hvis du forstår begrænsningerne under
docker run -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull altid justarchi/archisteamfarm
```

Forskellen mellem `ASF_UID` og `--user` flag er subtil, men vigtigt. `ASF_UID` er brugerdefineret mekanisme understøttet af ASF, i denne scenarie docker-beholder starter stadig som `root`, og derefter ASF opstart script starter de vigtigste binære under `ASF_UID`. Når du bruger `--user` flag, du starter hele processen, herunder ASF opstart script som given bruger. Første mulighed tillader ASF opstart script til at håndtere tilladelser og andre ting automatisk for dig, at løse nogle almindelige problemer, som du måske har forårsaget, for eksempel sikrer det, at dine `/app` og `/asf` mapper faktisk ejes af `ASF_UID`. I andet scenarie, da vi ikke kører som `root`, vi kan ikke gøre det, og du forventes at håndtere alt det selv på forhånd.

Hvis du har besluttet at bruge `--user` flag, du skal ændre ejerskab af alle ASF-filer fra standard `1000` til din nye brugerdefinerede bruger. Du kan gøre det ved at udføre kommandoen nedenfor:

```shell
# Kør kun, hvis du ikke bruger ASF_UID
docker exec -u root asf_container_name chown -hR 1001 /app /asf
```

Dette skal først gøres én gang efter du har oprettet din beholder med `docker run`, og kun hvis du har besluttet at bruge brugerdefineret bruger via `--user` docker flag. Glem heller ikke at ændre `1001` argument i kommandoen ovenfor til `UID` du rent faktisk ønsker at køre ASF under.

### Lydstyrke med SELinux

Hvis du bruger SELinux i håndhævet tilstand på dit OS, som er standard for eksempel på RHEL-baserede distros, derefter skal du montere lydstyrken som tilføjer `:Z` -indstillingen, som vil indstille korrekt SELinux-kontekst for det.

```
docker køre -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull altid justarchi/archisteamfarm
```

Dette vil tillade ASF at oprette filer, der target lydstyrken, mens inde docker container.

---

## Synkronisering af flere instanser

ASF inkluderer understøttelse af flere forekomster synkronisering, som angivet i afsnittet **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)**. Når du kører ASF i docker container, kan du eventuelt "opt-in" i processen, hvis du kører flere containere med ASF, og du gerne vil have dem til at synkronisere med hinanden.

Som standard er hver ASF, der kører inde i en docker container standalone hvilket betyder, at ingen synkronisering finder sted. For at aktivere synkronisering mellem dem, skal du binde `/tmp/ASF` sti i hver ASF container, som du ønsker at synkronisere, til en, delt sti på din dockervært, i skrivetilstand. Dette opnås præcis det samme som bindende et volumen, der er beskrevet ovenfor, bare med forskellige stier:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull always justarchi/archisteamfarm
# Og så videre, alle ASF beholdere er nu synkroniseret med hinanden
```

Vi anbefaler at binde ASF's `/tmp/ASF` -mappe til en midlertidig `/tmp` -mappe på din maskine. men du er selvfølgelig fri til at vælge en anden, der tilfredsstiller din brug. Hver ASF-beholder, der forventes at blive synkroniseret, skal have sin `/tmp/ASF` mappe delt med andre beholdere, der deltager i den samme synkroniseringsproces.

Som du sikkert har gættet fra eksemplet ovenfor, er det også muligt at oprette to eller flere "synkronisering grupper", ved at binde forskellige docker værtsstier til ASF's `/tmp/ASF`.

Montering `/tmp/ASF` er helt valgfri og anbefales ikke, medmindre du udtrykkeligt ønsker at synkronisere to eller flere ASF containere. Vi anbefaler ikke at montere `/tmp/ASF` til engangsbrug, da det giver absolut ingen fordele, hvis du forventer at køre kun én ASF container, og det kan faktisk forårsage problemer, der ellers kunne undgås.

---

## Kommandolinjeargumenter

ASF giver dig mulighed for at passere **[kommandolinjeargumenter](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** i docker-beholder gennem miljøvariabler. Du bør bruge specifikke miljøvariabler til understøttede kontakter, og `ASF_ARGS` for resten. Dette kan opnås med parameteren `-e` tilføjet til `docker run`, for eksempel:

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull always justarchi/archisteamfarm
```

Dette vil korrekt videregive dit `--cryptkey` argument til ASF proces der køres inde docker container, samt andre args. Selvfølgelig, hvis du er avanceret bruger, så kan du også ændre `ENTRYPOINT` eller tilføje `CMD` og videregive dine brugerdefinerede argumenter selv.

Medmindre du ønsker at give brugerdefineret krypteringsnøgle eller andre avancerede indstillinger, normalt behøver du ikke at omfatte særlige miljøvariabler, da vores docker-containere allerede er konfigureret til at køre med en sund forventet standardmulighed for `--no-genstart`, så flaget ikke behøver udtrykkeligt at være angivet i `ASF_ARGS`.

---

## IPC

Forudsat at du ikke ændrede standardværdien for `IPC` **[global konfigurationsejendom](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, er den allerede aktiveret. Du skal dog gøre to ekstra ting for IPC at arbejde i Docker container. For det første skal du bruge `IPCPassword` eller ændre standard `KnownNetworks` i brugerdefineret `IPC. onfig` for at tillade dig at oprette forbindelse udefra uden at bruge en. Medmindre du virkelig ved, hvad du gør, skal du blot bruge `IPCPassword`. For det andet er du nødt til at ændre standard lytteadresse på `localhost`, da docker ikke kan rute uden trafik til loopback interface. Et eksempel på en indstilling, der vil lytte på alle grænseflader ville være `http://*:1242`. Selvfølgelig kan du også bruge mere restriktive bindinger, såsom lokale LAN eller VPN-netværk kun, men det skal være en rute tilgængelig udefra - `localhost` vil ikke gøre, da ruten er helt inden for gæst maskine.

For at gøre ovenstående bør du bruge **[brugerdefinerede IPC config](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** såsom den nedenfor:

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

Når vi har oprettet IPC på ikke-loopback interface, vi skal fortælle docker at kortlægge ASF's `1242/tcp` port enten med `-P` eller `-p` switch.

For eksempel vil denne kommando udsætte ASF IPC grænseflade for at være vært for maskinen (kun):

```shell
docker køre -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull altid justarchi/archisteamfarm
```

Hvis du sætter alt ordentligt, `docker run` kommando ovenfor vil få **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface til at fungere fra din værtsmaskine. på standard `localhost:1242` rute, der nu korrekt omdirigeret til din gæst maskine. Det er også rart at bemærke, at vi ikke udsætte denne rute yderligere, så forbindelsen kan kun ske inden for dockerværten og derfor holde den sikker. Selvfølgelig kan du afsløre ruten yderligere, hvis du ved, hvad du gør, og sikre passende sikkerhedsforanstaltninger.

---

### Komplet eksempel

Ved at kombinere hele viden ovenfor, ville et eksempel på en komplet opsætning se sådan ud:

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull always --restart unless-stopped justarchi/archisteamfarm
```

Dette forudsætter, at du vil bruge en enkelt ASF container, med alle ASF config filer i `/home/archi/ASF/config`. Du bør ændre config sti til den, der matcher din maskine. Det er også muligt at levere brugerdefinerede plugins til ASF, som du kan sætte i `/home/archi/ASF/plugins`. Denne opsætning er også klar til valgfri IPC-brug, hvis du har besluttet at inkludere `IPC. onfig` i din konfigurationsmappe med et indhold som nedenfor:

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

Du kan opnå den samme effekt af `docker køre` kommando ovenfor ved at bruge følgende `docker komponere` config:

```yaml
version: "3. "
tjenester:
  som:
    billede: justarchi/archisteamfarm
    container_name: asf
    genstart: unless-stopped
    ports:
      - "127. .0.1:1242:1242"
      - "[::1]:1242:1242"
    mængder:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

Ud fra andre end vi allerede diskuteret ovenfor, vi har tilføjet `--genstart unless-stopped` til begge eksempler ovenfor for at starte denne beholder automatisk efter genstart af din maskine. Du er velkommen til at fjerne/ændre det, der passer til dine behov.

---

## Pro tips

Når du allerede har din ASF docker container klar, behøver du ikke at bruge `docker køre` hver gang. Du kan nemt stoppe/starte ASF docker container med `docker stop asf` og `docker start asf`. Husk, at hvis du ikke bruger `seneste` -tag, så brug af opdateret ASF vil stadig kræve fra dig til `docker stop`, `docker rm` og `docker køre` igen. Dette skyldes, at du skal genopbygge din beholder fra frisk ASF docker billede, hver gang du ønsker at bruge ASF version inkluderet i dette billede. I `seneste` tag, har ASF inkluderet kapacitet til at auto-opdatere sig selv, så genopbygning af billedet er ikke nødvendigt for at bruge up-to-date ASF (men det er stadig en god idé at gøre det fra tid til anden for at bruge frisk . ET runtime afhængigheder og det underliggende OS, som kan være nødvendigt, når du hopper på tværs af større ASF version opdateringer).

Som antydet af ovenstående, vil ASF i tag bortset fra `seneste` ikke automatisk opdatere sig selv, hvilket betyder, at **du** er ansvarlig for at bruge up-to-date `justarchi/archisteamfarm` repo. Dette har mange fordele, som typisk app bør ikke røre sin egen kode, når der køres, men vi forstår også bekvemmelighed, der kommer fra ikke at skulle bekymre sig om ASF version i din docker container. Hvis du bekymrer dig om god praksis og korrekt docker brug, `udgivet` tag er hvad vi ville foreslå i stedet for `seneste`, men hvis du ikke kan blive generet med det, og du bare ønsker at gøre ASF både arbejde og auto-opdatering selv, `seneste` vil gøre det.

Du bør typisk køre ASF i docker container med `Headless: true` global indstilling. Dette vil klart fortælle ASF, at du ikke er her for at give manglende detaljer, og det bør ikke bede om dem. Selvfølgelig bør du til indledende opsætning overveje at forlade denne mulighed på `false` , så du nemt kan konfigurere ting, men på lang sigt er du typisk ikke knyttet til ASF konsol, Derfor ville det give mening at informere ASF om dette og bruge `input` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** , hvis det er nødvendigt. På denne måde behøver ASF ikke at vente uendeligt på brugerinput, der ikke vil ske (og spilde ressourcer, mens du gør det). Det vil også give ASF mulighed for at køre i ikke-interaktiv tilstand inde i containeren, hvilket er afgørende f.eks. med hensyn til videresendelse af signaler, hvilket gør det muligt for ASF at yndefuldt lukke `docker stop asf` anmodning.