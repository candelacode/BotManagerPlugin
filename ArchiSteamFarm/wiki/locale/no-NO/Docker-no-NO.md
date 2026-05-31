# Docker

ASF finnes som **[docker-beholder](https://www.docker.com/what-container)**. Våre dockerpakker er for øyeblikket tilgjengelige på **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** samt **[Docker hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

Det er viktig å være oppmerksom på at å kjøre ASF i Docker container er ansett som **avansert oppsett**, som er **ikke trengs** til et stort flertall av brukerne, og gir vanligvis **ingen fordeler ved** over container-mindre oppsett. Hvis du vurderer Docker som løsning for å drive ASF som en tjeneste, for eksempel kan du få det til å starte automatisk med ditt OS, da bør du vurdere å lese **[Management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** i stedet og sette opp en riktig `systemd` tjeneste som vil være **nesten alltid** en bedre ide enn å drive ASF i en Docker-beholder.

Å ha ASF i Docker container involverer vanligvis **flere nye problemer og problemer** som du må møte og løse deg selv. This is why we **strongly** recommend you to avoid it unless you already have Docker knowledge and don't need help understanding its internals, about which we won't elaborate here on ASF wiki. Denne delen er for det meste til gyldige brukstilfeller av svært komplekse oppsett, for eksempel når det gjelder avansert nettverks- eller sikkerhet utover standard sandkassen som ASF følger med i `systemd` tjenesten (som allerede sikrer bedre isolasjon gjennom svært avanserte sikkerhetsmekanismer). For de håndfaste menneskemengdene forklarer vi her bedre ASF-konsepter med hensyn til Docker compatibility, og at du bare forutsettes å ha tilstrekkelig kunnskap om legen selv hvis du bestemmer deg for å bruke det sammen med ASF.

---

## Tagger

ASF er tilgjengelig på flere typer **[tagger](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `hoveddel`

Generisk bygg av ASF som er bygget av siste commit i `hovedgrenen,` som fungerer som grabbbing av siste forekomst direkte fra **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** rørledning. Det er det høyeste nivået av programmer med feilsøking som jobber med utviklere og avanserte brukere for utviklingsformål. Bildet oppdateres med hver utførelse i `hoved` GitHub grenen, derfor kan du forvente at svært ofte endrer seg (og at ting er ødelagt). Det er her å markere gjeldende status for ASF-prosjektet, som ikke nødvendigvis garanteres å være stabil eller målt, akkurat som påpekt i frigjøringssyklusen. **This tag should not be used in any production environment**. Nyttig for verifisering av om det du møter en bestemt oppgave, har utfylt problemet, uten å vente selv på en forhåndslansering med det utførte.


### `frigjort`

Generisk bygg av ASF som alltid peker til det nyeste **[utgitt](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF versjon, inkludert forhåndsutgivelser. Sammenlignet med `hoved` -tagg, blir en ny GitHub-tag oppdatert hver gang. Dedikert til fremskredne/strømbrukere som elsker å leve på kanten av det som kan anses som stabil og fersk samtidig. I praksis fungerer det som som rullende stikkord som peker til nyeste `A.B.C.D` slippes på tidspunktet for trekking. Vær oppmerksom på at bruk av denne taggen er lik ved hjelp av vår **[forhåndslansering](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `stabil`

Generisk bygg av ASF som alltid peker til den nyeste **[stabile](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF versjonen. Compared to `released` tag, image here is being updated once new stable version of ASF is made available. Anbefalt for personer som leter etter stabil variant av `utgitt` som er nevnt ovenfor.

### `siste`

OS-spesifikt bygg av ASF som alltid peker til siste **[stabil](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF-versjon. Sammenlignet med andre, er dette **eneste tagg** som inkluderer ASF auto-oppdateringer. Målet med denne taggen er å gi en sane standard Docker-beholder som er i stand til å kjøre selvoppdatering, OS-spesifikk versjon av ASF. På grunn av det må ikke bildet oppdateres så ofte som mulig. Som inkludert ASF-versjon vil alltid være i stand til å oppdatere seg selv hvis nødvendig.

Selvsagt kan `UpdatePeriod` være slått av (satt til `0`), men i dette tilfellet bør du antakelig bruke `stabil` utgivelse i stedet. På samme måte kan du endre standard `UpdateChannel` for å spore forhåndsliseringer i stedet hvis du ønsker det.

På grunn av det faktum at det `nyeste` bildet gir mulighet for auto-oppdateringer, det inkluderer bare OS med OS-spesifikk `linux` ASF-versjon, i motsetning til alle andre tagger som inkluderer OS med . ET kjøretid og `generisk` ASF versjon. Dette fordi nyere (oppdatert) ASF-versjon kanskje også krever nyere kjøretid enn den som bildet muligens kan bygges med, Ellers ville det være nødvendig å bygge om bildet fra bunnen av, og lukke det planlagte brukstilfellet.

### `A.B.C.D`

Generisk bygg av ASF som peker mot den faste ASF-versjonen som samsvarer med taggen. Sammenlignet med ovenstående emneord er denne taggen frosset, noe som betyr at bildet her ikke vil bli oppdatert når det er publisert. Dette fungerer som ligner på våre GitHub-utgivelser som aldri blir berørt etter den første utgivelsen, og som garanterer deg stabilt og frosset miljø. Du bør vanligvis bruke denne taggen når du ønsker å bruke en bestemt ASF-utgivelse og forvente bestemte resultater av byggverket (e. . administrere ASF-versjoner selv i stedet).

---

## Hvilken tagg er best for meg?

Det kommer an på det du leter etter. For flertallet av brukere, `nyeste` bør være det beste fordi det tilbyr nøyaktig hva desktop ASF gjør, bare i spesiell Docker-beholder som en tjeneste. Dette er imidlertid ikke nødvendigvis hvordan en dokker skal brukes – som regel er du forventet å gjenoppbygge beholderene og ikke kjøre dem til evig tid, og i dette tilfellet bør du vurdere `stabil` eller `utgitt` -tag, som følger retningslinjene for docker Hvis du vil kjøre noen faste ASF-versjoner i stedet, så naturlig `A.B.C.D` utgivelser er det du leter etter.

Vi ønsker generelt å unngå å prøve `hovedbygg` , som det er her for å markere gjeldende tilstand i ASF-prosjektet. Ingenting garanterer for at slik stat vil fungere ordentlig, men du er selvfølgelig mer enn velkommen til å gi dem et forsøk hvis du er interessert i ASF-utvikling.

---

## Arkitekter

ASF dockerbilde er bygget på `linux` plattform som sikter mot 3 arkitekter - `x64`, `arm` og `arm64`. Du kan lese mer om dem i **[kompatibilitet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** seksjonen.

Våre tagger bruker manifestet for flerplattformer, hvilket betyr at Docker som er installert på maskinen din vil automatisk velge riktig bilde for plattformen din når du trekker bildet. Hvis du på en sjanse vil du trekke et bestemt plattformbilde som ikke samsvarer med den du kjører akkurat nå, du kan gjøre det gjennom `--platform` -bryteren i egnede docker-kommandoer, slik som `docker kjører`. Se dokumentasjonen for docker på **[bilde-manifest](https://docs.docker.com/registry/spec/manifest-v2-2)** for mer informasjon.

---

## Bruk

For fullstendig referanse skal du bruke **[offisiell dokumentasjon](https://docs.docker.com/engine/reference/commandline/docker)**Vi dekker bare grunnleggende bruk i denne veiledningen, du er mer velkommen til å grave dypere.

### Hello ASF!

Først bør vi kontrollere om vår dokker fungerer riktig, dette vil tjene som vår ASF "hallo verden":

```shell
dokker kjører -it --name asf --pull alltid --rm justarchi/archisteamfarm
```

`docker run` oppretter en ny ASF docker-beholder for deg og kjører den i forgrunnen (`- it`). `- trekk alltid` sikrer at det oppdaterte bildet vil bli trukket først, og `--rm` sikrer at beholderen vår blir renset når den har stoppet, siden vi bare tester om alt fungerer bra nå.

Hvis alt gikk suksessfullt, etter å ha trukket alle lag og startbeholder, du bør merke deg at ASF startet riktig og informerer oss om at det ikke finnes noen definert botter, Det som er godt, vi bekreftet at ASF på dokker fungerer riktig. Hit `CTRL+C` for å avslutte ASF-prosessen og derfor også beholderen.

If you take a closer look at the command then you'll notice that we didn't declare any tag, which automatically defaulted to `latest` one. Hvis du vil bruke en annen tagg enn `nyeste`, for eksempel `utgitt`, skal du deklarere den eksplisitt:

```shell
dokker kjører -det --name asf --pull alltid --rm justarchi/archisteamfarm:released
```

---

## Bruk et volum

Dersom du bruker ASF i forankringsbeholderen, må du åpenbart konfigurere programmet selv. Du kan gjøre det på ulike måter. men den anbefalte ville være å opprette ASF `config` mappen på lokal maskin, Demonter det som et delt volum i ASF-docerbeholder.

For eksempel, vi antar at mappen med ASF config er i `/home/archi/ASF/config` mappen. Denne mappen inneholder kjernen `ASF.json` samt bots som vi vil kjøre. Nå trenger vi bare å gjøre ved å feste denne mappen som delt volum i vår docker-beholder, der ASF forventer sin konfigurasjonsmappe (`/app/config`).

```shell
docker kjører -det -v /home/archi/ASF/config:/app/config --name asf --pull alltid justarchi/archisteamfarm
```

Og det er det, nå vil ASF-forankringsbeholderen bruke delt mappe med den lokale maskinen i lesemodus, som er alt du trenger for å konfigurere ASF. På samme måte kan du montere andre volumer som du ønsker å dele med ASF, som `/app/logs` eller `/app/plugins`.

Selvsagt er dette bare én spesifikk måte å oppnå det vi ønsker, ingenting stopper deg ved f.eks. oppretter din egen `Dockerfile` som skal kopiere konfigurasjonsfilene til `/app/config` mappen, i ASF docker beholderen. Vi dekker bare grunnleggende bruk i denne veiledningen.

### Volum tillatelser

ASF-beholder som standard er initialisert med standard `rot` -bruker, som tillater den å håndtere interne tillatelsesting og deretter til slutt bytte til `asf` (UID `1000`) brukeren i den gjenværende delen av hovedprosessen. Selv om dette skal tilfredsstilles for de aller fleste brukerne, det påvirker delt volum som nygenererte filer vil normalt eies av `asf` brukeren, kanskje ikke er ønsket situasjon hvis du vil like en annen bruker for ditt felles volum.

Det er to måter du kan endre bruker ASF på på. Den første, anbefalt, er å erklære `ASF_UID` miljøvariabelen med mål UID som du vil kjøre under. For det andre: alternativet, er å sende `--user` **[flagg](https://docs.docker.com/engine/reference/run/#user)**, som støttes direkte av docker.

Du kan sjekke `uid` for eksempel med `id -u` -kommandoen, og erklære den som angitt ovenfor. For eksempel, hvis din målbruker har `uid` av 1001:

```shell
docker kjører -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull alltid justarchi/archisteamfarm

# Alternativt Hvis du forstår begrensningene under
docker kjører -den -u 1001 -v /home/archi/ASF/config:/app/config --name asf --always justarchi/archisteamfarm
```

Differansen mellom `ASF_UID` og `--user` flagg er delt, men viktig. `ASF_UID` er egendefinert mekanisme støttet av ASF, i dette scenarioforankringsbeholderen starter fremdeles som `root`, og så ASF startet oppstartsskriptet hovedbinær under `ASF_UID`. Ved bruk av `- bruker` -flagg, starter du hele prosessen, inkludert ASF oppstartsskriptet som gitt bruker. Først valg tillater ASF oppstartsskriptet å håndtere tillatelser og andre ting automatisk for deg, å løse noen vanlige problemer som du kan ha medført for eksempel sikrer den at din `/app` og `/asf` kataloger eies av `ASF_UID`. I andre scenario, siden vi ikke kjører som `root`, Det kan vi ikke gjøre, og det er forventet du å håndtere deg selv på forhånd.

Hvis du har bestemt deg for å bruke `--user` flagg, du må endre eierskapet til alle ASF-filer fra standard `1000` til din nye egendefinerte bruker. Du kan gjøre dette ved å utføre kommandoen nedenfor:

```shell
# Kjøre bare hvis du ikke bruker ASF_UID
docker exec -u root asf_container_name chown -hR 1001 /app /asf
```

Dette må gjøres bare én gang etter at du har laget beholderen din med `docker kjørt`, og bare hvis du bestemte deg for å bruke egendefinert bruker gjennom `--user` docker flagg. Ikke glem å endre `1001` argument i kommandoen ovenfor til `UID` du faktisk ønsker å kjøre ASF under.

### Volum med SELinux

Dersom du bruker SELinux i tvungen tilstand på OS'en, som er misligholdt for eksempel på RHEL-baserte distroer, deretter bør du montere volumet som legges til `:Z` -valget, som vil angi riktig SELinux-kontekst for den.

```
docker kjør -det -v /home/archi/ASF/config:/app/config:Z --name asf --pull alltid justarchi/archisteamfarm
```

Dette gjør det mulig med ASF å opprette filmål på volumet mens du befinner deg i beholderen for dockere.

---

## Flere forekomster synkronisering

ASF inkluderer støtte for flere forekomster synkronisering, som angitt i **[håndtering](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** avsnitt. Når du bruker ASF i dokkerbeholderen, kan du eventuelt «opt-in» i prosessen, Hvis du kjører flere beholdere med ASF, og du vil gjerne at de skal synkroniseres med hverandre.

Som standard er hver ASF som kjører inne i en docker-beholder frittstående, noe som betyr at det ikke skjer noen synkronisering. For å aktivere synkronisering mellom dem, må du binde `/tmp/ASF` banen i hver ASF-beholder som du vil synkronisere, til en, delte stier på din docker-vert, i lese-skrivemodus. Dette oppnås nøyaktig det samme som å binde et volum som er beskrevet ovenfor, bare med forskjellige baner:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull alltid justarchi/archisteamfarm
docker kjører -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config app/name asf2 --pull alltid justarchi/archeamfarm
Og så på alle ASF-beholdere er nå synkronisert med hverandre
```

Vi anbefaler å binde ASF's `/tmp/ASF` katalog også til en midlertidig `/tmp` mappe på maskinen, men du er selvfølgelig klar til å velge en annen som har oppfylt bruksområdet ditt. Hver ASF-beholder som forventes å synkroniseres, bør ha mappene `/tmp/ASF` delt med andre beholdere som tar del i samme synkroniseringsprosess.

Som du sannsynligvis har gjettet over eksempelet er det også mulig å opprette to eller flere "synkroniseringsgrupper", ved å binde en annen forankringsstasjon til ASFs `/tmp/ASF`.

Montering `/tmp/ASF` er helt valgfritt og anbefales faktisk ikke med mindre du eksplisitt ønsker å synkronisere to eller flere ASF-beholdere. Vi anbefaler ikke montering `/tmp/ASF` til engangsbruk siden det absolutt ingen fordeler hvis du forventer å kjøre bare én ASF-beholder, – og det kan faktisk forårsake problemer som ellers kunne unngås.

---

## Kommandolinjeargumenter

ASF lar deg sende **[kommandolinjeargumenter](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** i dokumentasjonsbeholderen gjennom miljøvariabler. Du bør bruke spesifikke miljøvariabler for støttede brytere, og `ASF_ARGS` for resten. Dette kan oppnås med `-e` bryteren ble lagt til `docker kjøring`, for eksempel:

```shell
docker kjør -den -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull alltid justarchi/archisteamfarm
```

Dette vil sørge for at `--cryptkey` -argumentet for at ASF-prosessen skal kjøres i beholderen for dokker i tillegg til andre mål. Hvis du er avansert bruker, kan du selvfølgelig også endre `ENTRYPOINT` eller legge til `CMD` og sende dine egendefinerte argumenter selv.

Med mindre du ønsker å legge inn egendefinert krypteringsnøkkel eller andre avanserte alternativer, vanligvis ikke du trenger å inkludere noen spesielle miljøvariabler, siden løsningsbeholderne våre allerede er konfigurert til å kjøre med et san forventet standardalternativ for `--ingen omstart`, slik at flagget ikke må angis eksplisitt i `ASF_ARGS`.

---

## IPC

Forutsatt at du ikke endret standardverdien for `IPC` **[globale konfigurasjonsegenskapen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, er den allerede aktivert. Du må imidlertid gjøre to ting ekstra for at klimapanelen skal virke i Docker-beholderen. Først må du bruke `IPCPassword` eller endre standard `KnownNetworks` i egendefinert `IPC. onfig` slik at du kan koble deg fra utsiden uten å bruke en. Med mindre du virkelig vet hva du gjør, bruk bare `IPCPassword`. For det andre, du må endre standard lyttingsadresse av `localhost`siden docker ikke kan rute utenfor trafikk til loopback-grensesnitt. Et eksempel på en innstilling som vil lytte på alle grensesnitt vil være `http://*:1242`. Selvsagt kan du også bruke mer restriktive bindinger, for eksempel kun lokalt nettverk for LAN eller VPN men det må være en rute som er tilgjengelig fra utsiden - `localhost` vil ikke fungere. siden ruten er helt på gjestemaskinen.

For å gjøre det ovennevnte bør du bruke **[egendefinert IPC config](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** , som for eksempel følgende:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"

        }
    }

```

Når vi setter opp IPC på «non-loopback»-grensesnitt, vi må fortelle docker for å kartlegge ASF's `1242/tcp` port enten med `-P` eller `-p` bryter.

For eksempel vil denne kommandoen utsette ASF IPC sitt grensesnitt til vertsmaskin (bare):

```shell
docker kjør -it -p 127.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull alltid justarchi/archisteamfarm
```

Legger du på alt ordentlig, `docker kjøre` kommandoen ovenfor vil gjøre **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** grensesnittet fungerer fra vertsmaskinen, på standard `localhost:1242` rute, som nå blir omdirigert til din gjestemaskin. Det er også fint å merke seg at vi ikke utsetter denne veien ytterligere. Det kan derfor gjøres forbindelse bare hos legens vert, og derfor holde den sikker. Du kan selvsagt utsette ruten videre hvis du vet hva du gjør og sørge for egnede sikkerhetstiltak.

---

### Fullfør eksempel

Ved å kombinere hele kunngjøringen ovenfor vil et eksempel på et fullstendig oppsett kunne se slik ut:

```shell
docker run -p 127.0.0.1:1242:1242 -p [:1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull alltid --restart unless-stopped justarchi/archisteamfarm
```

Dette forutsetter at du bruker en enkel ASF-beholder, med alle ASF-konfigurasjonsfiler i `/home/archi/ASF/config`. Du bør endre konfigurasjonstien til den som matcher maskinen. Det er også mulig å skrive inn egendefinerte plugins for ASF, som du kan skrive i `/home/archi/ASF/plugins`. Dette oppsettet er også klart for valgfri bruk av IPC hvis du har besluttet å inkludere `IPC. onfig` i konfigurasjonsmappen med et innhold som nedenfor:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"

        }
    }

```

Du kan oppnå samme effekt av `docker run` kommando ovenfor ved å bruke følgende `docker komponerer` config:

```yaml
versjon: "3. "
tjenester:
  asf:
    -bilde: justarchi/archisteamfarm
    container_name: asf
    restart: unless-stopped
    ports:
      - "127. .0.1:1242:1242"
      - "[::1]:1242:1242"
    enheter:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

Fra andre ting enn vi allerede har diskutert ovenfor, vi har lagt til `--restart unless-stopped` på begge eksemplene over for å starte denne beholderen automatisk etter omstart av maskinen. Ta deg fri til å fjerne/endre det slik at du passer dine behov.

---

## Pro tips

Når du allerede har ASF-forankringsbeholderen klar, trenger du ikke bruke `docker run` hver gang. Du kan enkelt stoppe/starte ASF docker-beholderen med `docker stop asf` og `docker starter asf`. Husk at hvis du ikke bruker `nyeste` tagg, vil det fortsatt kreves up-to-date ASF fra deg til `docker stopp`, `docker rm` og `docker kjører` igjen. Dette er fordi du må gjenoppbygge beholderen fra et friskt ASF-docerbilde hver gang du ønsker å bruke ASF-versjon inkludert i det bildet. I `siste` tag, har ASF inkludert mulighet til å automatisk oppdatere seg selv. Det er ikke nødvendig å gjenoppbygge bildet for å bruke oppdaterte ASF-er (men det er likevel lurt å gjøre det fra tid til annen for å bruke ny versjon. ET kjøretidsavhengigheter og det underliggende OS, som kan være nødvendig ved hopping over store ASF-versjoner).

Som ventet ovenfor vil ASF i andre tag enn `siste` ikke automatisk oppdatere seg selv. som betyr at **du** tar ansvaret for å bruke moderne `justarchi/archisteamfarm` opppo. Det er mange fordeler, slik at appen vanligvis ikke bør røre sin egen kode når den kjøres, men vi forstår også bekvemmeligheter som ikke kommer fra å være bekymret for ASF-versjon i dockerbeholderen. If you care about good practices and proper docker usage, `released` tag is what we'd suggest instead of `latest`, but if you can't be bothered with it and you just want to make ASF both work and auto-update itself, then `latest` will do.

Du bør vanligvis kjøre ASF i en docker-beholder med `Hodemin: sann` global innstilling. Dette vil tydelig fortelle ASF at du ikke er her for å oppgi manglende opplysninger og bør ikke spørre om disse. Selvfølgelig, for første oppsett bør du vurdere å forlate dette alternativet på `false` slik at du enkelt kan sette opp ting, men på lenge er du typisk ikke knyttet til ASF-konsoll, derfor vil det gi mening å informere ASF om at og bruke `input` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** hvis det oppstår problemer. På denne måten vil ASF ikke trenge å vente uendelig på brukerinndata som ikke vil skje (og ikke sparingsressurser når du gjør det). Det vil også gjøre det mulig for ASF å kjøre i ikke-interaktiv form inne i beholderen, noe som er viktig, f.eks. når det gjelder å videresende signaler, noe som gjør det mulig for ASF å forsikre seg om at `docker stopper asf` forespørselen.