# Docker

ASF is beschikbaar als **[docker container](https://www.docker.com/what-container)**. Onze docker pakketten zijn momenteel beschikbaar op **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** en **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

Het is belangrijk om op te merken dat het uitvoeren van ASF in de Docker container wordt beschouwd als **geavanceerde installatie**, dat **niet nodig is** voor de overgrote meerderheid van gebruikers en meestal **geen voordelen geeft** boven container-less setup. Als u de Docker beschouwt als een oplossing voor het uitvoeren van ASF als een dienst, bijvoorbeeld door het automatisch te starten met uw OS, dan zou je eens moeten overwegen om **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** te lezen en een juiste `systemd` service in te stellen die bijna altijd **** een beter idee is dan ASF te gebruiken in een Docker container.

Het uitvoeren van ASF in de Docker container gaat meestal over **verschillende nieuwe problemen en problemen** die u zelf moet aanpakken en oplossen. This is why we **strongly** recommend you to avoid it unless you already have Docker knowledge and don't need help understanding its internals, about which we won't elaborate here on ASF wiki. Deze sectie is voornamelijk voor geldige gebruiksgevallen van zeer complexe opstellingen, voor wat betreft geavanceerd netwerken of beveiliging buiten standaard sandboxing waarmee ASF wordt geleverd in `systemd` service (die al zorgt voor superieure proces isolatie door middel van zeer geavanceerde beveiligingsmechanismen). Voor die handmatige hoeveelheid mensen leggen we hier betere ASF-concepten uit met betrekking tot de verenigbaarheid van Dockers, en alleen dat, je gaat ervan uit dat je zelf voldoende Docker kennis hebt als je besluit om het samen met ASF te gebruiken.

---

## Labels

ASF is beschikbaar via verschillende soorten **[tags](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `hoofd`

Generieke build van ASF die is gemaakt van de allernieuwste commit in `main` branch, die hetzelfde werkt als het laatste artefact rechtstreeks uit onze **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pijplijn. Het is het hoogste niveau van bugsoftware voor ontwikkelaars en geavanceerde gebruikers voor ontwikkelingsdoeleinden. De afbeelding wordt bijgewerkt met elke commit in de `main` GitHub branch U kunt daarom verwachten dat er heel vaak veranderingen (en dingen worden gebroken). Het is hier om de huidige status van het ASF-project te markeren die niet noodzakelijkerwijs stabiel of getest hoeft te worden, zoals in onze vrijheidscyclus is aangegeven. **Deze tag moet niet worden gebruikt in een productie omgeving**. Handig voor verificatie of specifieke commit het probleem dat je tegenkomt heeft opgelost, zonder zelfs maar te wachten op een pre-release met die commit.


### `vrijgegeven`

Generieke build van ASF dat altijd verwijst naar de nieuwste **[released](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF versie, inclusief pre-releases. Vergeleken met `hoofd` tag, wordt hier de afbeelding bijgewerkt wanneer een nieuwe GitHub tag wordt gebruikt. Toegewijd aan geavanceerde/krachtige gebruikers die graag aan de rand wonen wat tegelijkertijd als stabiel en vers kan worden beschouwd. In de praktijk werkt het hetzelfde als rollend label wijst naar de meest recente versie van `A.B.C.D` op het moment van pullen. Houd er rekening mee dat het gebruik van deze tag gelijk is aan het gebruik van onze **[pre-releases](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `stabiel`

Generieke build van ASF dat altijd naar de laatste **[stabiele](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF versie verwijst. Vergeleken met `released` tag, wordt hier de afbeelding bijgewerkt zodra er een nieuwe stabiele versie van ASF beschikbaar is. Aanbevolen voor mensen die op zoek zijn naar stabiele variant van `released` tag hierboven.

### `nieuwste`

OS-specifieke build van ASF die altijd wijst naar de nieuwste **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF versie. In vergelijking met anderen is dit de enige **tag** die de automatische updates van ASF bevat. Het doel van deze tag is om een sane standaard Docker container te bieden die in staat is zelf-update uit te voeren, OS-specifieke build van ASF. Daarom hoeft de afbeelding niet zo vaak mogelijk te worden bijgewerkt. zoals inbegrepen de ASF-versie altijd in staat zal zijn zichzelf aan te passen indien nodig.

Natuurlijk kan `UpdatePeriode` veilig worden uitgeschakeld (ingesteld op `0`maar in dit geval moet u waarschijnlijk `stable` release gebruiken. Op dezelfde manier kunt u de standaard `UpdateChannel` wijzigen om in plaats daarvan de pre-releases te volgen als u dat wilt.

Vanwege het feit dat de laatste afbeelding `` beschikt over de mogelijkheid om automatisch te updaten, het bevat lege OS met OS-specifieke `linux` ASF versie, in tegenstelling tot alle andere tags die OS bevatten met . ET runtime en `algemene` ASF versie. Dit komt omdat nieuwere (bijgewerkte) ASF-versie mogelijk ook nieuwere runtime nodig heeft dan de versie waarmee de afbeelding mogelijk gemaakt kan worden. waarvoor anders een afbeelding opnieuw gebouwd zou moeten worden, waardoor de geplande gebruiksaanwijzing ongedaan gemaakt zou moeten worden.

### `B.C.D`

Generieke Bouw van ASF die naar de vaste ASF versie verwijst die overeenkomt met de tag. Vergelijkt met bovenstaande tags is deze tag volledig bevroren, wat betekent dat de afbeelding hier niet zal worden bijgewerkt zodra deze gepubliceerd is. Dit werkt vergelijkbaar met onze GitHub releases die nooit worden aangeraakt na de eerste release, wat zorgt voor een stabiele en bevroren omgeving. Meestal moet je deze tag gebruiken wanneer je een aantal specifieke ASF-versie wilt gebruiken en deterministische resultaten van de build verwacht (bijv. . liever zelf beheren van ASF-versies).

---

## Welke tag is het beste voor mij?

Dat hangt af van wat je zoekt. Voor de meerderheid van gebruikers zou `de nieuwste` tag de beste moeten zijn, omdat het precies aanbiedt wat desktops ASF doet, alleen in speciale Docker container als service. Dit is echter niet noodzakelijkerwijs hoe docker moet worden gebruikt - normaal gesproken verwacht u dat u uw containers herbouwt en niet voorgoed uitvoert, en in dit geval moet u `stable` of `released` tag overwegen, welke docker richtlijnen volgt. Tot slot, als je in plaats daarvan wat vaste ASF-versie wilt gebruiken, dan zijn natuurlijk `A.B.C.D` releases wat je zoekt.

Over het algemeen ontmoedigen we het proberen van `belangrijkste` versies, omdat die er zijn voor ons om de huidige status van ASF project te markeren. Niets garandeert dat een dergelijke staat naar behoren zal functioneren. maar natuurlijk ben je meer dan welkom om ze te proberen als je geïnteresseerd bent in ASF-ontwikkeling.

---

## Architecturen

Afbeelding van de ASF docker is momenteel gebouwd op `linux` platform target 3 architecturen - `x64`, `arm` en `arm64`. U kunt meer over ze lezen in **[compatibiliteit](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** sectie.

Onze tags gebruiken meerdere platform manifest, dit betekent dat Docker die op uw machine is geïnstalleerd automatisch de juiste afbeelding voor uw platform zal selecteren bij het pullen van de afbeelding. Als je toevallig een specifieke platformafbeelding wilt trekken die niet overeenkomt met de afbeelding die je momenteel draait, u kunt dat doen via `--platform` switch in de juiste docker commando's, zoals `docker run`. Zie docker documentatie op afbeelding **[](https://docs.docker.com/registry/spec/manifest-v2-2)** voor meer informatie.

---

## Gebruik

Voor volledige referentie moet u **[officiële docker documentatie](https://docs.docker.com/engine/reference/commandline/docker)**gebruiken, We zullen alleen het basisgebruik in deze handleiding dekken, je bent meer dan welkom om dieper te graven.

### Hello ASF!

Ten eerste moeten we controleren of onze docker correct werkt, dit zal dienen als ons ASF "hallo wereld":

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm
```

`docker run` maakt een nieuwe ASF docker container voor jou en voert deze uit in de voorgrond (`-it`). `--pull always` zorgt ervoor dat de actuele afbeelding eerst wordt getoond en `--rm` zorgt ervoor dat onze container zal worden verwijderd zodra hij is gestopt, omdat we alleen maar testen of alles nu goed werkt.

Als alles succesvol eindigde, na het trekken van alle lagen en het starten van de container, ASF is correct gestart en heeft ons verteld dat er geen gedefinieerde bots zijn. wat goed is - we hebben geverifieerd dat ASF in docker goed werkt. Raak `CTRL+C` om het ASF-proces en daarmee ook de container te beëindigen.

Als je de opdracht van nabij bekijkt, zul je merken dat we geen enkele tag hebben uitgegeven, die automatisch standaard is ingesteld op `laatste` een. Als je een andere tag dan `laatste`wilt gebruiken, bijvoorbeeld `released`, dan moet je het expliciet zeggen:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm:released
```

---

## Gebruik een volume

Als je ASF gebruikt in een docker container dan moet je het programma zelf configureren. U kunt het op verschillende manieren doen. maar de aanbevolen map is om ASF `config` te maken op lokale machine, dan als gedeeld volume in ASF-docker container koppelen.

We gaan er bijvoorbeeld van uit dat uw ASF configuratiemap zich in `/home/archi/ASF/config` map bevindt. Deze map bevat de kern `ASF.json` en bots die we willen uitvoeren. Nu hoeven we alleen maar die map aan te hangen als gedeeld volume in onze docker container, waar ASF zijn configuratiemap verwacht (`/app/config`).

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

En dat is het, nu zal je ASF docker container in een gedeelde map met je lokale machine in lees- en schrijfmodus gebruiken; dat is alles wat je nodig hebt om ASF te configureren. Op dezelfde manier kun je andere volumes die je wilt delen met ASF, zoals `/app/logs` of `/app/plugins` koppelen.

Dit is natuurlijk maar een concrete manier om te bereiken wat wij willen, niets weerhoudt u ervan bijv. maak uw eigen `Dockerfile` die uw configuratiebestanden kopieert naar `/app/config` map in ASF docker container. We dekken alleen basisgebruik in deze handleiding.

### Volume permissies

Standaard ASF container wordt geïnitialiseerd met standaard `root` gebruiker, waarmee het de interne machtigingen kan verwerken en vervolgens kan overschakelen naar `asf` (UID `1000`) gebruiker voor het resterende deel van het hoofdproces. Dit zou voor de overgrote meerderheid van de gebruikers bevredigend moeten zijn. het beïnvloedt het gedeelde volume omdat nieuw gegenereerde bestanden normaal eigendom zullen zijn van `asf` gebruiker, welke niet de gewenste situatie is als je een andere gebruiker wilt voor je gedeelde volume.

Er zijn twee manieren waarop je de gebruiker ASF onder kan veranderen. De eerste aanbevolen, is om `ASF_UID` omgevingsvariabele met doel UID waar je onder wilt draaien. Ten tweede, een alternatief, is het slagen van een `--user` **[flag](https://docs.docker.com/engine/reference/run/#user)**, wat direct wordt ondersteund door een docker.

Je kunt je `uid` bekijken met bijvoorbeeld `id -u` commando, en dan opgeven zoals hierboven gespecificeerd. Bijvoorbeeld, als je doelgebruiker `uid` van 1001:

```shell
docker run -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm

# als u de beperkingen onder
docker begrijpt, -it -it 1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Het verschil tussen `ASF_UID` en `--user` vlag is subtiel, maar belangrijk. `ASF_UID` is een aangepast mechanisme ondersteund door ASF, in dit scenario begint de docker container nog steeds als `root`, en daarna start ASF opstart script de hoofdbinary onder `ASF_UID`. Wanneer je `--user` vlag gebruikt, start je het hele proces, inclusief ASF opstart script als een gebruiker. De eerste optie staat ASF het opstartscript toe om voor jou automatisch machtigingen en andere dingen te verwerken, om enkele veelvoorkomende problemen op te lossen die je mogelijk hebt gemaakt. bijvoorbeeld zorgt het ervoor dat je `/app` en `/asf` mappen eigendom zijn van `ASF_UID`. In het tweede scenario, omdat we niet draaien als `root`, we kunnen dat niet doen, en je verwacht dat je dat zelf op voorhand zelf aanpast.

Als je hebt besloten om `--user` vlag te gebruiken, je moet het eigendom van alle ASF-bestanden veranderen van standaard `1000` naar je nieuwe aangepaste gebruiker. U kunt dit doen door de opdracht hieronder uit te voeren:

```shell
# Alleen uitvoeren als u geen ASF_UID
docker exec -u root asf_container_name -hR 1001 /app /asf gebruikt
```

Dit hoeft slechts één keer te worden gedaan nadat u uw container met `docker`hebt gemaakt, en alleen als u heeft besloten een aangepaste gebruiker via `--user` docker vlag te gebruiken. Vergeet ook niet om het argument `1001` in commando hierboven te veranderen naar de `UID` waar je ASF onder wilt uitvoeren.

### Volume met SELinux

Als u SELinux gebruikt in een gedwongen toestand op uw OS, dat is de standaard voor bijvoorbeeld RHEL-based distros, dan moet je het volume koppelen `:Z` optie, welke de juiste SELinux context zal instellen.

```
docker run -it -v /home/archi/ASF/config:/app/Z --name asf --pull always starchi/archisteamfarm
```

Dit stelt ASF in staat om het volume van de docker te vertragen.

---

## Synchronisatie van meerdere instanties

ASF bevat ondersteuning voor meerdere instanties synchronisatie, zoals vermeld in **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** sectie. Bij het uitvoeren van ASF in docker container, kan je optioneel "opt-in" het proces doorlopen, in het geval u meerdere containers met ASF heeft en u wilt dat ze met elkaar synchroniseren.

Standaard is elke ASF die draait in een docker container, standalone wat betekent dat er geen synchronisatie plaatsvindt. Om synchronisatie tussen hen in te schakelen, moet u het pad `/tmp/ASF` in elke ASF-container die u wilt synchroniseren, binden naar één, gedeeld pad in je docker host, in lees- en schrijfmodus. Dit is precies hetzelfde als het koppelen van een volume dat hierboven werd beschreven, met verschillende paden:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull always starchi/archiamfarm
# alle ASF containers zijn nu gesynchroniseerd met elkaar
```

We raden aan om ASF's `/tmp/ASF` map ook te binden aan een tijdelijke `/tmp` map op je machine, maar natuurlijk ben je vrij om een andere te kiezen die tevreden is met je gebruik. Elke ASF-container die naar verwachting zal worden gesynchroniseerd moet de map `/tmp/ASF` gedeeld hebben met andere containers die deelnemen aan hetzelfde synchronisatieproces.

Omdat je waarschijnlijk uit het bovenstaande voorbeeld hebt geraden, is het ook mogelijk om twee of meer "synchronisatiegroepen", te maken door verschillende docker host paden te koppelen in ASF's `/tmp/ASF`.

Het koppelen van `/tmp/ASF` is volledig optioneel en wordt niet aanbevolen, tenzij je twee of meer ASF containers wilt synchroniseren. We raden niet aan om `/tmp/ASF` te monteren voor gebruik van de enkelcontainer want het levert absoluut geen voordelen op als je verwacht slechts één ASF-container te gebruiken, en het zou zelfs tot kwesties kunnen leiden die anders vermeden zouden kunnen worden.

---

## Opdrachtregelparameters

ASF stelt je in staat om **[command-line argumenten](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** in docker container door omgevingsvariabelen te loodsen. Je moet specifieke omgevingsvariabelen gebruiken voor ondersteunde schakelaars en `ASF_ARGS` voor de rest. Dit kan worden bereikt met een `-e` switch toegevoegd aan `docker run`, bijvoorbeeld:

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull always justarchi/archisteamfarm
```

Dit komt goed overeen met uw `--cryptkey` argument om ASF te laten draaien in docker container, evenals andere args. Natuurlijk, als je een geavanceerde gebruiker bent, kun je ook `ENTRYPOINT` of `CMD` toevoegen en zelf je persoonlijke argumenten doorgeven.

Tenzij u aangepaste encryptiesleutel of andere geavanceerde opties wilt geven, hoeft u meestal geen speciale omgevingsvariabelen toe te voegen, omdat onze docker containers al zijn geconfigureerd voor uitvoeren met de verwachte standaard optie `--no-herstart`, zodat de vlag niet expliciet hoeft te worden gespecificeerd in `ASF_ARGS`.

---

## IPC

Ervan uitgaande dat u de standaardwaarde voor `IPC` **[algemene configuratie eigenschap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**niet heeft gewijzigd, het is al ingeschakeld. U moet echter twee extra dingen doen om ervoor te zorgen dat de IPC in de Docker container werkt. Ten eerste moet u `IPCPassword` gebruiken of de standaard `KnownNetworks` aanpassen in aangepast `IPC. Configuratie` om je van de buitenwereld te laten verbinden zonder er een te gebruiken. Tenzij je echt weet wat je aan het doen bent, gebruik `IPCPassword`. Ten tweede moet u het standaard afluisteradres van `localhost`wijzigen, aangezien docker geen buiten het verkeer naar de achterliggende interface kan reizen. Een voorbeeld van een instelling die op alle interfaces zal luisteren is `http://*:1242`. Natuurlijk kunt u ook restrictievere bindingen gebruiken, zoals alleen het lokale LAN of VPN-netwerk. maar het moet een route zijn die toegankelijk is vanaf de buitenkant - `localhost` zal niet doen, omdat de route helemaal in de gast is.

Om het bovenstaande te doen moet u een **[custom IPC config](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** gebruiken, zoals de instelling hieronder:

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

Zodra we IPC hebben ingesteld op niet-loopbackinterface we moeten de docker vertellen om ASF's `1242/tcp` poort te gebruiken met `-P` of `-p` wissel.

Dit commando zou bijvoorbeeld de ASF IPC interface blootstellen aan de host machine (alleen):

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull always justarchi/archisteamfarm
```

Als je alles correct hebt ingesteld. `docker run` opdracht hierboven maakt **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface werk van uw host machine, op standaard `localhost:1242` route die nu goed doorgestuurd is naar je gast machine. Het is ook leuk om op te merken dat we deze route niet verder blootleggen. dus verbinding kan alleen worden gemaakt binnen de doktergastheer, en houdt deze dus beveiligd. Natuurlijk kunt u de route verder uitzetten als u weet wat u aan het doen bent en passende veiligheidsmaatregelen garandeert.

---

### Volledig voorbeeld

Hele kennis hierboven combineren, een voorbeeld van een volledige installatie zou er als volgt uitzien:

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull always --restart unless-stopped justarchi/archiamfarm
```

Dit veronderstelt dat u een enkele ASF container gebruikt, met alle ASF configuratiebestanden in `/home/archi/ASF/config`. Je zou het configuratiepad moeten aanpassen naar het pad dat overeenkomt met je machine. Het is ook mogelijk om aangepaste plug-ins voor ASF te leveren, die je in `/home/archi/ASF/plugins` kunt plaatsen. Deze instelling is ook klaar voor optioneel IPC-gebruik als u heeft besloten om `IPC toe te voegen.` in uw configuratiemap met een inhoud zoals hieronder:

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

Je kunt hetzelfde effect bereiken van `docker run` commando hierboven door de volgende `docker samen te stellen` config:

```yaml
versie: "3. "
services:
  asf:
    image: justarchi/archisteamfarm
    container_name: asf
    restart: unless-stopped
    ports:
      - "127. .0.1:1242:1242"
      - "[::1]:1242:1242"
    volumes:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

Uit andere zaken dan hierboven hebben we het al gehad, we hebben `--start Onless-stop` toegevoegd aan beide voorbeelden hierboven om deze container automatisch te starten na herstart van je machine. Voel je vrij om het te verwijderen/wijzigen naar jouw behoeften.

---

## Pro tips

Als je de ASF-docker container al klaar hebt, hoef je niet elke keer `docker uitvoeren` te gebruiken. Je kunt gemakkelijk ASF docker container stoppen/starten met `docker stop asf` en `docker start asf`. Houd er rekening mee dat als je geen `nieuwste` tag gebruikt, het gebruik van de up-to-date ASF nog steeds nodig heeft voor `docker stop`, `docker rm` en `docker is` weer. Dit komt omdat je je container elke keer opnieuw moet bouwen vanuit de frisse afbeelding van ASF docker als je ASF-versie in die afbeelding wilt gebruiken. In `laatste` tag heeft ASF de mogelijkheid opgenomen om zichzelf automatisch te updaten. het herbouwen van de afbeelding is dus niet nodig voor het gebruik van actuele ASF (maar het is nog steeds een goed idee om het af en toe te doen om vers te gebruiken. ET runtime afhankelijkheden en de onderliggende OS die nodig kunnen zijn bij het springen over de belangrijkste ASF versie updates).

Zoals aangegeven door bovenstaande, zal ASF niet automatisch zichzelf updaten in een andere tag dan `nieuwste` dat betekent dat **u** de leiding heeft over het gebruik van moderne `justarchi/archisteamfarm` repo. Dit heeft veel voordelen omdat de app meestal zijn eigen code niet mag aanraken wanneer deze wordt uitgevoerd, Maar we begrijpen ook het gemak dat komt doordat we ons geen zorgen hoeven te maken over de ASF-versie in uw docker-container. Als u waarde hecht aan goede praktijken en een correct doktergebruik, `released` tag is wat we hadden voorgesteld in plaats van `nieuwste`maar als je er niet omheen kunt en je gewoon ASF wilt laten werken en zichzelf automatisch bijwerken, dan zal `laatste` doen.

ASF kun je gebruiken in de docker container met `Headless: true` global setting. Dit zal ASF duidelijk vertellen dat je hier niet bent om ontbrekende details te verstrekken en het zou er niet om moeten vragen. Natuurlijk moet je voor de initiële installatie overwegen om die optie te verlaten op `false` zodat je gemakkelijk dingen kunt instellen. maar op de lange termijn ben je meestal niet bevestigd aan ASF-console, Daarom zou het zinvol zijn ASF hierover te informeren en `input` **[commando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** te gebruiken indien nodig. Op deze manier hoeft ASF niet oneindig te wachten op gebruikersinvoer wat niet zal gebeuren (en verspillingsbronnen terwijl je dit doet). Het staat ASF ook toe om de niet-interactieve modus in de container uit te voeren, wat cruciaal is, bvb. wat betreft signalen door te sturen, waardoor ASF de aanvraag van `docker stop asf` kan afsluiten.