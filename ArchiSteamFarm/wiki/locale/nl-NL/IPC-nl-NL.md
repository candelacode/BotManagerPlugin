# IPC

ASF bevat zijn eigen unieke IPC-interface die kan worden gebruikt voor verdere interactie met het proces. IPC staat voor **[Interprocess communicatie](https://en.wikipedia.org/wiki/Inter-process_communication)** en in de meest eenvoudige definitie is dit "ASF web interface" gebaseerd op **[Kestrel HTTP server](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel)** die kan worden gebruikt voor verdere integratie met het proces. zowel als frontend voor eindgebruiker (ASF-ui), als backend voor derde-partij integraties (ASF API).

IPC kan worden gebruikt voor veel verschillende dingen, afhankelijk van uw behoeften en vaardigheden. Je kunt het bijvoorbeeld gebruiken voor het ophalen van de status van ASF en alle bots, het verzenden van ASF commando's, het ophalen en bewerken van global/bot configuraties, nieuwe bots toevoegen, bestaande bots verwijderen en sleutels indienen voor **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** of toegang krijgen tot ASF's logbestand. Al deze acties worden getoond door onze API, dit betekent dat u uw eigen tools en scripts kunt coderen die kunnen communiceren met ASF en deze tijdens de runtime kunnen beïnvloeden. Daar komt nog bij dat geselecteerde acties (zoals het verzenden van commando's) worden ook geïmplementeerd door onze ASF-ui, waarmee je ze gemakkelijk kunt gebruiken via een vriendelijke webinterface.

---

# Gebruik

Tenzij u handmatig IPC uitschakelt via `IPC` **[algemene configuratie eigenschap](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, wordt dit standaard ingeschakeld. ASF vindt dat IPC start in het log, dat u kunt gebruiken om te controleren of de IPC interface goed is gestart:

```text
INFO・ASFreached. Start() Beginner IPC-server...
INFO・ASF︎ Start() IPC-server klaar!
```

ASF's http server luistert nu naar geselecteerde eindpunten. Als u geen aangepast configuratiebestand voor IPC heeft opgegeven, zal het `localhost`zijn, beide IPv4 gebaseerde **[127. .0.1](http://127.0.0.1:1242)** en IPv6 gebaseerde **[[::1]](http://[::1]:1242)** op standaard `1242` poort. U heeft toegang tot onze IPC interface door middel van bovenstaande linken, maar alleen vanaf dezelfde machine als het ASF proces.

De ASF's IPC interface laat drie verschillende manieren zien om deze te gebruiken, afhankelijk van uw geplande gebruik.

Op het laagste niveau is er **[ASF API](#asf-api)** dat de kern van onze IPC interface is en dat alles laat werken. Dit is wat je wilt gebruiken in je eigen hulpmiddelen, nutsvoorzieningen en projecten om direct met ASF te communiceren.

Op de medium grond is onze **[Swagger documentatie](#swagger-documentation)** die fungeert als een frontend bij ASF API. Het bevat een volledige documentatie van de ASF API en geeft je er ook makkelijker toegang toe. Dit is wat je wilt controleren of je van plan bent een hulpmiddel te schrijven, hulpprogramma of andere projecten die geacht worden te communiceren met ASF via zijn API.

Op het hoogste niveau is er **[ASF-ui](#asf-ui)** gebaseerd op onze ASF API en biedt een gebruiksvriendelijke manier om verschillende ASF acties uit te voeren. Dit is onze standaard IPC interface ontworpen voor eindgebruikers, en een perfect voorbeeld van wat u kunt bouwen met ASF API. Als je wilt, kun je je eigen aangepaste web UI gebruiken met ASF, door `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** te specificeren en aangepaste `www` map daar te vinden.

---

# ASF-ui

ASF-ui is een gemeenschapsproject dat gericht is op het creëren van een gebruikersvriendelijke grafische webinterface voor eindgebruikers. Om dat te bereiken fungeert het als een frontend naar onze **[ASF API](#asf-api)**, stelt u in staat om gemakkelijk verschillende acties te ondernemen. Dit is de standaard UI waar ASF mee te maken heeft.

Zoals hierboven vermeld, is ASF-ui een gemeenschapsproject dat niet wordt onderhouden door de kernontwikkelaars van ASF. Het volgt zijn eigen stroom in **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** die moet worden gebruikt voor alle gerelateerde vragen, problemen, bugrapporten en suggesties.

Je kunt ASF-ui gebruiken voor het algemene beheer van ASF-processen. Hiermee kunnen bijvoorbeeld bots worden beheerd, instellingen worden aangepast, opdrachten worden verzonden en de geselecteerde functionaliteit wordt normaal gesproken beschikbaar via ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

Onze ASF API is typisch **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** web API die gebaseerd is op JSON als haar primaire data-formaat. We doen ons best om een precieze reactie te beschrijven, door gebruik te maken van beide HTTP-statuscodes (indien gewenst), Naast een antwoord kunt u ook zelf parseren om te weten of het verzoek is geslaagd, en zo niet, waarom.

Onze ASF API heeft toegang tot de juiste aanvragen voor eindpunten van `/Api`. Je kunt die API-eindpunten gebruiken om je eigen helper-scripts, tools, GUI's en hetzelfde te maken. Dit is precies wat onze ASF-ui onder dwang bereiken en elk ander instrument kan hetzelfde bereiken. ASF API wordt officieel ondersteund en onderhouden door het core ASF team.

Voor volledige documentatie van beschikbare eindpunten, beschrijvingen, verzoeken, reacties, http status codes en al wat anders overweegt ASF API, raadpleeg onze **[swagger documentatie](#swagger-documentation)**.

![ASF API](https://github.com/user-attachments/assets/08c3d4ad-ea77-403d-a18a-b75c3d0a3097)


---

# Aangepaste configuratie

Onze IPC interface ondersteunt extra config bestand, `IPC.config` die in de standaard ASF's `config` map moet worden geplaatst.

Indien beschikbaar, specificeert dit bestand de geavanceerde configuratie van de Kestrel http server, samen met andere IPC-gerelateerde tuning. Er is geen reden voor u om dit dossier te gebruiken, tenzij u er een bijzondere behoefte aan heeft. omdat ASF in dit geval al verstandige standaardwaarden gebruikt.

Het configuratiebestand is gebaseerd op de volgende JSON-structuur:

```json
{
    "Kestrel": {
        "Eindpoints": {
            "example-http4": {
                "Url": "http://127. .0. :1242"
            },
            "voorbeeld-http6": {
                "Url": "http://[::1]:1242"
            },
            "voorbeeld-https4": {
                "Url": "https://127. .0.1:1242",
                "Certificaat": {
                    "Pad": "/path/to/certificaat. fx",
                    "Wachtwoord: "passwordToPfxFileAbove"
                }
            },
            "voorbeeld-https6": {
                "Url": "https://[::1]:1242",
                "Certificaat": {
                    "Pad": "/path/to/certificaat. fx",
                    "Wachtwoord: "passwordToPfxFileAbove"
                }
            }
        },
        "KnownNetworks": [
            "10. .0.0/8",
            "172.16.0. /12",
            "192.168.0. /16"
        ],
        "PathBase": "/"
    }
 } }
```

`Eindpunten` - Dit is een verzameling van eindpunten, elk eindpunt heeft zijn eigen unieke naam (zoals `example-http4`) en `Url` eigenschap die `Protocol://Host:Port` luisteradres specificeert. ASF luistert standaard op IPv4 en IPv6 http adressen, maar we hebben https voorbeelden voor gebruik toegevoegd, indien nodig. Je moet alleen die eindpunten aangeven die je nodig hebt, we hebben 4 voorbeeld hierboven opgenomen, zodat je ze makkelijker kunt bewerken.

`Host` accepteert ofwel `localhost`, een vast IP-adres van de interface waar het naar zou moeten luisteren (IPv4/IPv6), of `*` waarde die ASF's http server verbindt met alle beschikbare interfaces. Andere waarden zoals `mydomain.com` of `192.168.0 gebruiken.` handelt hetzelfde als `*`, er is geen IP filtering geïmplementeerd. Wees daarom uiterst voorzichtig wanneer je `Host` waarden gebruikt die toegang op afstand mogelijk maken. Hierdoor krijgt toegang tot de ASF's IPC-interface van andere machines, die een veiligheidsrisico kunnen opleveren. We raden ten zeerste aan om `IPCPassword` (en bij voorkeur ook uw eigen firewall te gebruiken) **in een minimum** in dit geval.

`KnownNetworks` - Deze **optionele** variabele specificeert netwerkadressen die wij betrouwbaar vinden. ASF is standaard geconfigureerd om de terugloop interface te vertrouwen (`localhost`, dezelfde machine) **only**. Deze eigenschap wordt op twee manieren gebruikt. Ten eerste, als u `IPCPassword`weglaat, dan geven we alleen machines van bekende netwerken toegang tot de API van ASF en weigeren we alle anderen als veiligheidsmaatregel. Ten tweede is deze eigenschap van cruciaal belang voor het omkeren van proxy's die ASF betreden. omdat ASF alleen de headers respecteert als de reverse-proxy server van bekende netwerken is. Het respecteren van de koppen is van cruciaal belang met betrekking tot het anti-brutebestrijdingsmechanisme van ASF, in plaats van de reverse-proxy te verbieden in geval van een probleem. het door de reverse-proxy opgegeven IP wordt verbannen als bron van het oorspronkelijke bericht. Wees uiterst voorzichtig met de netwerken die u hier opgeeft omdat het een potentiële IP spoofing van aanval en ongeoorloofde toegang mogelijk maakt in het geval de vertrouwde machine wordt gecompromitteerd of verkeerd geconfigureerd.

`PathBase` - This is **optional** base path that will be used by IPC interface. Standaard ingesteld op `/` en zou niet moeten worden aangepast voor de meeste gebruiksgevallen. Door het veranderen van deze eigenschap organiseert u de gehele IPC interface op een aangepaste prefix, bijvoorbeeld `http://localhost:1242/MyPrefix` in plaats van `http://localhost:1242` alleen. Het gebruik van aangepaste `PathBase` kan worden gezocht in combinatie met specifieke instellingen van een reverse-proxy waar u alleen een specifieke URL wilt proxiteren, bijvoorbeeld `mijndomein. om/ASF` in plaats van gehele `mijndomein.com` domein. Normaal gesproken vereist dat je een rewrite regel voor je webserver schrijft die `mijndomein toedient. om/ASF/Api/X` -> `localhost:1242/Api/X`, maar in plaats daarvan kun je een aangepaste `PathBase` van `/ASF` definiëren en zorgen voor een eenvoudigere installatie van `mijndomein. om/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

Tenzij je echt een aangepast basis pad moet specificeren, is het het beste om het standaard te laten.

## Voorbeeld configuratie

### Veranderen van standaard poort

De volgende configuratie verandert de standaard ASF luisterpoort van `1242` naar `1337`. U kunt elke poort kiezen die u wilt, maar wij raden `1024-32767` afstand aan, als andere poorten meestal **[geregistreerd](https://en.wikipedia.org/wiki/Registered_port)**, en kan bijvoorbeeld `root` toegang vereisen op Linux.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP4": {
                "Url": "http://127. .0. :1337"
            },
            "HTTP6": {
                "Url": "http://[::1]:1337"
            }
        }
    }
 } }
```

---

### Toegang van alle IP-adressen inschakelen

De volgende configuratie zorgt voor externe toegang van alle bronnen, Daarom moet je **er zeker van zijn dat je onze veiligheidsnota over die**leest, hierboven beschikbaar.

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

Als u geen toegang van alle bronnen vereist, maar bijvoorbeeld alleen uw LAN. dan is het veel beter om te controleren of het lokale IP-adres van de machine ASF hosting, bijvoorbeeld `192. 68.0.10` en gebruik het in plaats van `*` in voorbeeld configuratie hierboven. Helaas is dat alleen mogelijk als uw LAN-adres altijd hetzelfde is. als anders heb je waarschijnlijk meer bevredigende resultaten met `*` en je eigen firewall bovenop die geven alleen lokale subnetten toegang tot ASF's poort.

---

# Authenticatie

ASF IPC interface vereist standaard geen enkele soort authenticatie, omdat `IPCPassword` is ingesteld op `nul`. Echter, als `IPCPassword` is ingeschakeld door ingesteld te worden op een niet-lege waarde elke oproep naar ASF's API vereist het wachtwoord dat overeenkomt met `IPCPassword`. Als u de authenticatie of het verkeerde wachtwoord weglaat, krijgt u een `401 - Ongeautoriseerd` fout. Nadat 5 mislukte authenticatiepogingen (verkeerd wachtwoord) worden u tijdelijk geblokkeerd met `403 - Verboden` fout.

Verificatie kan op twee verschillende manieren gebeuren.

## `Authenticatie` header

In het algemeen moet u **[HTTP request headers](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)**gebruiken, door het instellen van `Authenticatie` met uw wachtwoord als waarde. De manier om dat te doen hangt af van het werkelijke gereedschap dat je gebruikt voor toegang tot ASF's IPC-interface, bijvoorbeeld als je `curl` gebruikt, dan moet je `-H 'Authentication: MyPassword'` als parameter toevoegen. Op die manier wordt de waarmerking in de hoofden van het verzoek doorgegeven, waar deze feitelijk zou moeten plaatsvinden.

## `wachtwoord` parameter in query string

Als alternatief kunt u `wachtwoord` parameter toevoegen aan het einde van de URL die u gaat bellen, bijvoorbeeld door `/Api/ASF te bellen? assword=MyPassword` in plaats van `/Api/ASF` alleen. Deze aanpak is goed genoeg, maar legt natuurlijk een open wachtwoord bloot, wat niet altijd op zijn plaats is. Naast dat is het extra argument in de querystring, die het uiterlijk van de URL gecompliceerd maakt en het gevoel geeft dat de URL specifiek is, terwijl het wachtwoord van toepassing is op de gehele ASF API-communicatie.

---

Beide manieren worden ondersteund en het is helemaal aan jou om te kiezen welke je wilt kiezen. We raden aan om HTTP-headers overal te gebruiken waar u maar kan, als bruikbaarder dan query string. We steunen echter ook de queryreeks, voornamelijk vanwege verschillende beperkingen in verband met aanvraagheaders. Een goed voorbeeld is het ontbreken van aangepaste headers tijdens het opstarten van een websocket verbinding in javascript (hoewel het volledig geldig is volgens de RFC). In deze situatie is query string de enige manier om te verifiëren.

---

# Swagger documentatie

Onze IPC-interface, in additon aan ASF-API en ASF-ui bevat ook swagger documentatie, welke beschikbaar is onder `/swagger` **[URL](http://localhost:1242/swagger)**. Swagger documentatie dient als tussenman tussen onze API-implementatie en andere tools die het gebruiken (bijv. ASF-u). Het biedt een volledige documentatie en beschikbaarheid van alle API-eindpunten in **[OpenAPI](https://swagger.io/resources/open-api)** specificatie die gemakkelijk kan worden verbruikt door andere projecten. staat je toe om gemakkelijk de ASF API te gebruiken en te testen.

Naast het gebruik van onze swagger documentatie als een volledige specificatie van ASF API, je kan het ook gebruiken als gebruiksvriendelijke manier om verschillende API-eindpunten uit te voeren, voornamelijk die welke niet door ASF-ui zijn geïmplementeerd. Omdat onze swagger documentatie automatisch wordt gegenereerd vanuit de ASF-code, je hebt de garantie dat de documentatie altijd up-to-date is met de API-eindpunten die je versie van ASF bevat.

![Swagger documentatie](https://github.com/user-attachments/assets/ce998e08-f5db-46b0-a9e8-e6b69abd94bb)


---

# FAQ (veelgestelde vragen)

### Is ASF's IPC interface veilig en veilig voor gebruik?

ASF luistert standaard alleen op `localhost` adressen, wat betekent dat toegang tot ASF IPC vanaf een andere machine maar je eigen **onmogelijk is**. Tenzij u de standaard eindpunten wijzigt, heeft de aanvaller directe toegang tot uw eigen machine nodig om toegang te krijgen tot ASF's IPC, Het is dus zo veilig als het kan en er is geen mogelijkheid dat iemand anders er toegang toe heeft, zelfs niet vanuit uw eigen LAN.

Als u echter besluit om de standaard `localhost` aan te passen bindadressen aan iets anders. dan moet je de juiste firewall regels **zelf** instellen om alleen de toegestane IPC-interface van ASF te kunnen gebruiken. Naast dat moet u `IPCPassword`instellen, omdat ASF zal weigeren om andere machines toegang te geven tot de ASF-API zonder een die een extra beveiligingslaag toevoegt. U kunt in dit geval ook de ASF's IPC-interface gebruiken achter een reverse-proxy, die hieronder verder wordt uitgelegd.

### Kan ik via mijn eigen hulpmiddelen of gebruikersnamen toegang krijgen tot ASF-API-documenten?

Ja, dit is waarvoor de ASF API is ontworpen en je kunt alles gebruiken wat in staat is om een HTTP-verzoek te sturen om het te kunnen openen. Lokale gebruikers volgen **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** logica, en we staan toegang van alle oorsprong toe (`*`), zolang `IPCPassword` is ingesteld, als een extra beveiligingsmaatregel. Hiermee kun je verschillende geauthenticeerde ASF API aanvragen uitvoeren, zonder mogelijk kwaadaardige scripts automatisch toe te staan (omdat ze uw `IPCPassword` moeten weten om dat te doen).

### Kan ik ASF's IPC op afstand bezoeken, bijvoorbeeld vanaf een andere machine?

Ja, we raden aan om hiervoor een reverse-proxy te gebruiken. Op deze manier kun je je webserver op typische wijze benaderen, die dan de IPC van ASF op dezelfde machine benadert. Als u niet wilt uitvoeren met een reverse proxy, kunt u **[aangepaste configuratie](#enabling-access-from-all-ips)** gebruiken met de juiste URL daarvoor. Als uw machine bijvoorbeeld in een VPN zit met `10.8.0.1` adres, dan kunt u `http://10.8.0 instellen. :1242` luisterende URL in IPC config, waarmee IPC toegang zou kunnen krijgen vanaf uw privé VPN, maar nergens anders.

### Kan ik de IPC van ASF gebruiken achter een reverse proxy zoals Apache of Nginx?

**Ja**, onze IPC is volledig compatibel met deze installatie, dus je bent vrij om het ook voor je eigen gereedschappen te hosten voor extra beveiliging en compatibiliteit als je dat wilt. Over het algemeen is de ASF's http-server zeer veilig en heeft geen risico wanneer ze direct verbonden zijn met het internet. maar het plaatsen van het achter een reverse-proxy zoals Apache of Nginx kan extra functionaliteit bieden die niet mogelijk is om anders te bereiken. zoals het beveiligen van ASF's interface met een **[basic auth-](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Voorbeeld configuratie kan hieronder worden gevonden. We hebben volledige `server` blok opgenomen, hoewel je vooral geïnteresseerd bent in `locatie` blok. Raadpleeg **[nginx documentatie](https://nginx.org/en/docs)** als je verdere uitleg nodig hebt.

```nginx
server {
    luister *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificaat /path/to/your/fullchain. em;
    ssl_certificate_key /path/naar/jouw/privkey. em;

    locatie ~* /Api/NLog {
        proxy_pass http://127.0.0. :1242;

        # Alleen als u de standaard host
# proxy_set_header host 127 moet overschrijven. .0. ;

        # X-headers moeten altijd worden opgegeven bij proxying verzoeken naar ASF
        # Ze zijn cruciaal voor een goede identificatie van de originele IP, ASF toestaan om te geven verbant de echte overtreders in plaats van je nginx server
        # Specificeren stelt ASF in staat IP-adressen op te lossen van gebruikers die verzoeken doen - nginx werken als een reverse proxy
        # Niet opgeven zal ervoor zorgen dat ASF je nginx als client behandelt - nginx in dit geval als een traditionele proxy werkt
        # Als je geen nginx kunt hosten op dezelfde machine als ASF, u wilt hoogstwaarschijnlijk KnownNetworks correct instellen naast die
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;

        # We voegen deze 3 extra opties toe voor websockets proxy's, zie https://nginx. rg/nl/docs/http/websocket.html
        proxy_http_version 1. ;
        proxy_set_header Connectie "Upgrade";
        proxy_set_header Upgrade $http_upgrade;
    }

    locatie / {
        proxy_pass http://127. .0. :1242;

        # Alleen als u de standaard host
# proxy_set_header host 127 wilt overschrijven. .0. ;

        # X-headers moeten altijd worden opgegeven wanneer proxying verzoeken naar ASF
        # ze cruciaal zijn voor een goede identificatie van de originele IP, ASF toestaan om te geven verbant de echte overtreders in plaats van je nginx server
        # Specificatie ervan stelt ASF in staat IP-adressen op te lossen van gebruikers die verzoeken doen - nginx werken als een reverse-proxy
        # Als je ze niet specificeert zal ASF je nginx als client behandelen - nginx in dit geval als een traditionele proxy handelen in dit geval
        # Als je nginx niet kunt hosten op dezelfde machine als ASF, u wilt hoogstwaarschijnlijk KnownNetworks correct instellen naast die
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
    }
}
```

Voorbeeld Apache configuratie kan hieronder worden gevonden. Raadpleeg **[apache documentatie](https://httpd.apache.org/docs)** als je verdere uitleg nodig hebt.

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerNaam asf.mydomain. om

        SSLEngine On
        SSLCertificateFile /path/to/your/fullchain.
        SSLCertificateKeyFile /path/naar/uw/privkey. Aem

        # TODO: Apache kan hoofdlettergevoelig niet goed overeenkomen. dus hebben we twee meest gebruikte gevallen
        ProxyPass "/api/nlog" "ws://127 hardcoderen. .0. :1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0. :1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule> </IfModule> A
```

### Kan ik via het HTTPS-protocol toegang krijgen tot de IPC-interface?

**Ja**, je kunt het op twee verschillende manieren bereiken. Een aanbevolen manier zou zijn om daarvoor een reverse-proxy te gebruiken, waar u toegang kunt krijgen tot uw webserver via https zoals gebruikelijk, en verbind via de ASF's IPC interface op dezelfde machine. Op deze manier is uw verkeer volledig versleuteld en hoeft u IPC op geen enkele manier te wijzigen om dergelijke instellingen te ondersteunen.

Tweede manier is het specificeren van een **[aangepaste configuratie](#custom-configuration)** voor de ASF's IPC interface waar u https endpoint kunt inschakelen en het juiste certificaat rechtstreeks naar onze Kestrel http server kunt verstrekken. Op deze manier wordt aanbevolen als je geen andere webserver gebruikt en deze niet exclusief voor ASF wilt uitvoeren. Anders is het veel gemakkelijker om een bevredigende setup te bereiken met behulp van een omgekeerd proxymechanisme.

---

### Tijdens het opstarten van IPC krijg ik een fout: `System.IO. OException: Mislukt om aan adres te koppelen, een poging is gedaan om toegang te krijgen tot een socket op een manier verboden door de toegangsrechten`

Deze fout geeft aan dat iets anders op je machine die poort al gebruikt, of deze gereserveerd heeft voor toekomstig gebruik. Dit kan zijn als je een tweede ASF-installatie op dezelfde machine probeert te starten, maar meestal is Windows de poort `1242` van uw gebruik uitgezonderd. Daarom moet u ASF verplaatsen naar een andere poort. Om dat te doen, volg **[voorbeeld config](#changing-default-port)** hierboven, en probeer gewoon een andere haven te kiezen, zoals `12420`.

Natuurlijk kun je ook proberen te weten te komen wat poort `1242` van ASF gebruik blokkeert en dat te verwijderen. maar dat is meestal veel lastiger dan ASF de opdracht geven een andere poort te gebruiken, dus we gaan daar hier verder over uitweiden.

---

### Waarom krijg ik een `403 Verboden` fout wanneer ik `IPCPassword` niet gebruik?

ASF bevat extra beveiligingsmaatregel die standaard alleen loopbackinterface toestaat (`localhost`, je eigen machine) om toegang te krijgen tot ASF API zonder `IPCPassword` in de config. Dit is omdat het gebruik van `IPCPassword` een **minimum** beveiligingsmaatregel moet zijn die is ingesteld door iedereen die besluit om de ASF-interface verder uit te leggen.

De wijziging werd gedicteerd door het feit dat enorme hoeveelheden ASF's die wereldwijd worden gehost door onbekende gebruikers werden overgenomen voor kwaadaardige intenten, laat mensen meestal zonder boekhouding en zonder voorwerpen aan hen over. Nu zouden we kunnen zeggen "ze deze pagina kunnen lezen voordat ze ASF openen naar de hele wereld", maar in plaats daarvan is het logischer om onveilige ASF-instellingen standaard af te wijzen, en eis van gebruikers een actie als ze dit expliciet willen toestaan, waarover we hieronder verder willen gaan.

Met name kunt u onze beslissing overschrijven door de netwerken op te geven waarvan u vertrouwt dat ze ASF bereiken zonder `IPCPassword` gespecificeerd, u kunt deze instellen in `KnownNetworks` eigenschap in aangepaste configuratie. Maar tenzij je **echt** weet wat je doet en de risico's volledig begrijpt gebruik in plaats daarvan `IPCPassword` als verklaring voor `KnownNetworks` geeft iedereen van die netwerken onvoorwaardelijk toegang tot ASF API. We serieus, mensen stapten zichzelf al in de voet omdat ze geloofden dat hun omgekeerde proxy's veilig waren en iptables regels bestonden, maar ze waren'ten. `IPCPassword` is de eerste en soms de laatste bewaker, Als je besluit om af te zien van dit eenvoudige, maar zeer effectieve en veilige mechanisme, dan heb je alleen zelf de schuld.