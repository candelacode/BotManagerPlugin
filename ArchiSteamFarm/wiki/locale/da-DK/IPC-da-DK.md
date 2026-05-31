# IPC

ASF indeholder sin egen unikke IPC-grænseflade, der kan bruges til yderligere interaktion med processen. IPC står for **[inter-process communication](https://en.wikipedia.org/wiki/Inter-process_communication)** og i den mest enkle definition er dette "ASF web interface" baseret på **[Kestrel HTTP server](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel)** , der kan bruges til yderligere integration med processen, både som en frontend for slutbruger (ASF-ui) og backend for tredjepartsintegrationer (ASF API).

IPC kan bruges til en masse forskellige ting, afhængigt af dine behov og færdigheder. For eksempel kan du bruge det til at hente status af ASF og alle bots, sende ASF kommandoer, hente og redigere global/bot configs, tilføjelse af nye bots, sletning af eksisterende bots, indsendelse af nøgler til **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** eller adgang til ASF's logfil. Alle disse handlinger er afsløret af vores API, hvilket betyder, at du kan kode dine egne værktøjer og scripts, der vil være i stand til at kommunikere med ASF og påvirke det under kørsel. Ud over det, udvalgte handlinger (såsom at sende kommandoer) er også implementeret af vores ASF-ui, som giver dig mulighed for nemt at få adgang til dem via en venlig webgrænseflade.

---

# Brug

Medmindre du manuelt har deaktiveret IPC via `IPC` **[global konfigurationsejendom](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, er det aktiveret som standard. ASF vil angive IPC lancering i sin log, som du kan bruge til at verificere, hvis IPC interface er startet korrekt:

```text
INFO|ASF|Start() Starting IPC server...
INFO|ASF|Start() IPC server ready!
```

ASF's http server lytter nu på valgte endepunkter. Hvis du ikke har angivet en brugerdefineret konfigurationsfil til IPC, vil det være `localhost`, begge IPv4-baserede **[127. .0.1](http://127.0.0.1:1242)** og IPv6-baseret **[[:1]](http://[::1]:1242)** på standard `1242` port. Du kan få adgang til vores IPC interface gennem ovenstående links, men kun fra den samme maskine som den ene kører ASF proces.

ASF's IPC interface afslører tre forskellige måder at få adgang til det, afhængigt af din planlagte brug.

På det laveste niveau er der **[ASF API](#asf-api)** , der er kernen i vores IPC interface og tillader alt andet at fungere. Dette er, hvad du ønsker at bruge i dine egne værktøjer, værktøjer og projekter for at kommunikere med ASF direkte.

På mellemlang grund er der vores **[Swagger dokumentation](#swagger-documentation)** , der fungerer som en frontend til ASF API. Den er udstyret med en komplet dokumentation af ASF API og giver dig også mulighed for at få adgang til det lettere. Dette er, hvad du ønsker at kontrollere, om du planlægger at skrive et værktøj, nytte eller andre projekter, der formodes at kommunikere med ASF gennem sin API.

På højeste niveau er der **[ASF-ui](#asf-ui)** , som er baseret på vores ASF API og giver brugervenlig måde at udføre forskellige ASF handlinger. Dette er vores standard IPC interface designet til slutbrugere, og et perfekt eksempel på, hvad du kan bygge med ASF API. Hvis du ønsker det, kan du bruge din egen brugerdefinerede web-UI til at bruge med ASF, ved at angive `--path` **[kommandolinjeargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** og ved hjælp af brugerdefineret `www` mappe placeret der.

---

# ASF-ui

ASF-ui er et fællesskabsprojekt, der har til formål at skabe brugervenlig grafisk webgrænseflade for slutbrugere. For at opnå det, fungerer det som en frontend til vores **[ASF API](#asf-api)**, så du kan gøre forskellige handlinger med lethed. Dette er standard UI, som ASF kommer med.

Som nævnt ovenfor er ASF-ui et fællesskabsprojekt, der ikke vedligeholdes af centrale ASF-udviklere. Den følger sit eget flow i **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** , som skal bruges til alle relaterede spørgsmål, spørgsmål, spørgsmål, fejlrapporter og forslag.

Du kan bruge ASF-ui til generel styring af ASF proces. Det gør det muligt for eksempel at administrere bots, ændre indstillinger, sende kommandoer, og opnå udvalgte andre funktioner, der normalt er tilgængelige via ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

Vores ASF API er typisk **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** web API, der er baseret på JSON som sit primære dataformat. Vi gør vores bedste for præcist at beskrive svar, ved hjælp af begge HTTP statuskoder (hvor det er relevant), samt et svar kan du parse dig selv for at vide, om anmodningen lykkedes, og hvis ikke, så hvorfor.

Vores ASF API kan tilgås ved at sende passende anmodninger til passende `/API` endepunkter. Du kan bruge disse API endpoints til at gøre din egen hjælper scripts, værktøjer, GUI'er og ens. Det er præcis, hvad vores ASF-ui opnår under hætten, og ethvert andet værktøj kan opnå det samme. ASF API understøttes og vedligeholdes officielt af core ASF team.

For fuldstændig dokumentation af tilgængelige endpoints, beskrivelser, anmodninger, svar, http status koder og alt andet overvejer ASF API, henvises til vores **[swagger dokumentation](#swagger-documentation)**.

![ASF API](https://github.com/user-attachments/assets/08c3d4ad-ea77-403d-a18a-b75c3d0a3097)


---

# Tilpasset konfiguration

Vores IPC-interface understøtter ekstra konfigurationsfil, `IPC.config` , der skal sættes i standard ASF's `config` -mappe.

Når den er tilgængelig, angiver denne fil avanceret konfiguration af ASF's Kestrel http server, sammen med andre IPC-relaterede tuning. Medmindre du har et særligt behov, er der ingen grund til at bruge denne fil, da ASF allerede bruger fornuftige misligholdelser i dette tilfælde.

Konfigurationsfilen er baseret på følgende JSON struktur:

```json
{
    "Kestrel": {
        "Endepunkter": {
            "eksempel-http4": {
                "Url": "http://127. .0. :1242"
            },
            "eksempel-http6": {
                "Url": "http://[:1]:1242"
            },
            "eksempel-https4": {
                "Url": "https://127. .0.1:1242",
                "Certifikat": {
                    "Sti": "/path/to/certifikat. fx",
                    "Adgangskode": "passwordToPfxFileAbove"
                }
            },
            "eksempel-https6": {
                "Url": "https://[:1]:1242"
                "Certifikat": {
                    "Sti": "/sti/til/certifikat. fx",
                    "Adgangskode": "passwordToPfxFileAbove"
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
}
```

`Endpoints` - Dette er en samling af endpoints, hvert endepunkt med sit eget unikke navn (som `eksempel4`) og `Url` egenskab, der angiver `Protocol://Host:Port` lytter adresse. Som standard lytter ASF på IPv4 og IPv6 http adresser, men vi har tilføjet https eksempler for dig at bruge, hvis nødvendigt. Du bør kun erklære de endepunkter, du har brug for, vi har inkluderet 4 eksempler ovenfor, så du kan redigere dem lettere.

`Host` accepterer enten `localhost`, en fast IP-adresse på den grænseflade, den skal lytte på (IPv4/IPv6), eller `*` -værdi, der binder ASF's http-server til alle tilgængelige grænseflader. Brug af andre værdier såsom `mydomain.com` eller `192.168.0.` fungerer på samme måde som `*`, der er ingen implementeret IP-filtrering Vær derfor yderst forsigtig, når du bruger `Host` værdier, der tillader fjernadgang. Det vil gøre det muligt at få adgang til ASF's IPC-grænseflade fra andre maskiner, hvilket kan udgøre en sikkerhedsrisiko. Vi anbefaler kraftigt at bruge `IPCPassword` (og helst din egen firewall også) **på et minimum** i dette tilfælde.

`KnownNetworks` - Denne **valgfri** -variabel angiver netværksadresser, som vi anser for troværdige. Som standard er ASF konfigureret til at stole loopback interface (`localhost`, samme maskine) **kun**. Denne egenskab bruges på to måder. For det første, hvis du udelader `IPCPassword`, så vil vi tillade kun maskiner fra kendte netværk at få adgang til ASF's API, og nægte alle andre som en sikkerhedsforanstaltning. For det andet er denne ejendom af afgørende betydning for omvendt adgang til ASF da ASF kun vil ære sine overskrifter, hvis reverse-proxy-serveren er indefra kendte netværk. Ære overskrifterne er afgørende i forhold til ASF's anti-bruteforce mekanisme, som i stedet for at forbyde omvendt proxy i tilfælde af et problem, det vil forbyde IP angivet af reverse-proxy som kilden til den oprindelige besked. Vær meget forsigtig med de netværk, du angiver her, da det giver mulighed for en potentiel IP-spoofing angreb og uautoriseret adgang, hvis den betroede maskine er kompromitteret eller forkert konfigureret.

`PathBase` - Dette er **valgfri** base sti, der vil blive brugt af IPC interface. Standard til `/` og bør ikke være forpligtet til at ændre for de fleste tilfælde af brug. Ved at ændre denne egenskab vil du være vært for hele IPC-interface på en brugerdefineret præfiks, for eksempel `http://localhost:1242/MyPrefix` i stedet for `http://localhost:1242` alene. Brug af brugerdefineret `PathBase` kan være ønsket i kombination med specifik opsætning af en omvendt proxy, hvor du kun vil proxy en bestemt URL for eksempel `mydomain. om/ASF` i stedet for hele `mydomain.com` domæne. Normalt ville det kræve fra dig at skrive en omskrivning regel for din webserver, der ville kortlægge `mydomæne. om/ASF/Api/X` -> `localhost:1242/Api/X`, men i stedet kan du definere en brugerdefineret `PathBase` af `/ASF` og opnå lettere opsætning af `mydomain. om/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

Medmindre du virkelig har brug for at angive en brugerdefineret base sti, er det bedst at forlade det som standard.

## Eksempel på konfigurer

### Ændring af standardport

Den følgende konfiguration ændrer simpelthen standard ASF lytter port fra `1242` til `1337`. Du kan vælge hvilken som helst port du kan lide, men vi anbefaler `1024-32767` rækkevidde, da andre porte typisk er **[registreret](https://en.wikipedia.org/wiki/Registered_port)**, og kan for eksempel kræve `root` adgang på Linux.

```json
{
    "Kestrel": {
        "Endepunkter": {
            "HTTP4": {
                "Url": "http://127. .0. :1337"
            },
            "HTTP6": {
                "Url": "http://[::1]:1337"
            }
        }
    }
}
```

---

### Aktiverer adgang fra alle IP'er

Den følgende konfiguration vil tillade fjernadgang fra alle kilder, Derfor bør du **sikre, at du læser og forstår vores sikkerhedsmeddelelse om den**, der er tilgængelig ovenfor.

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

Hvis du ikke har brug for adgang fra alle kilder, men for eksempel kun dit LAN, så er det meget bedre idé at kontrollere den lokale IP-adresse på maskinens hosting ASF, for eksempel `192. 68.0.10` og bruge det i stedet for `*` i eksempel config ovenfor. Desværre er det kun muligt, hvis din LAN-adresse altid er den samme, da ellers vil du sandsynligvis have mere tilfredsstillende resultater med `*` og din egen firewall oven på det, der giver kun lokale undernet adgang til ASF's port.

---

# Godkendelse

ASF IPC interface som standard kræver ikke nogen form for godkendelse, da `IPCPassword` er sat til `null`. Men hvis `IPCPassword` er aktiveret ved at blive sat til enhver ikke-tom værdi, ethvert opkald til ASF's API kræver den adgangskode, der matcher angivet `IPCPassword`. Hvis du udelader godkendelse eller indtaster forkert adgangskode, får du fejl `401 - Uautoriseret`. Efter 5 mislykkede godkendelsesforsøg (forkert adgangskode), vil du få midlertidigt blokeret med `403 - Forbudt` fejl.

Autentificering kan ske på to separate måder.

## `Authentication` header

Generelt bør du bruge **[HTTP anmodning headers](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)**ved at sætte `Authentication` felt med din adgangskode som en værdi. Måden at gøre det afhænger af det faktiske værktøj, du bruger til at få adgang til ASF's IPC interface, for eksempel hvis du bruger `curl` så skal du tilføje `-H 'Authentication: MyPassword'` som parameter. Denne måde autentificering er bestået i overskrifterne i anmodningen, hvor det faktisk bør finde sted.

## `password` parameter i forespørgselsstrengen

Alternativt kan du tilføje parameteren `password` til slutningen af den URL, du er ved at ringe til, for eksempel ved at ringe til `/Api/ASF? assword=MyPassword` i stedet for `/Api/ASF` alene. Denne tilgang er god nok, men det udsætter naturligvis password i det fri, hvilket ikke nødvendigvis altid er passende. Ud over, at det er ekstra argument i forespørgselsstrengen, hvilket komplicerer udseendet af webadressen og får det til at føle, at det er URL-specifik, mens adgangskoden gælder for hele ASF API kommunikation.

---

Begge måder er understøttet og det er helt op til dig, som du ønsker at vælge. Vi anbefaler at bruge HTTP-headers overalt, hvor du kan, da usage-wise det er mere passende end at forespørge streng. Men vi understøtter også forespørgsel streng, primært på grund af forskellige begrænsninger i forbindelse med anmodning headers. Et godt eksempel omfatter mangel på brugerdefinerede overskrifter, mens du indleder en websocket forbindelse i javascript (selv om det er helt gyldig i henhold til RFC). I denne situation er forespørgselsstrengen den eneste måde at autentificere.

---

# Swagger dokumentation

Vores IPC interface, i additon til ASF API og ASF-ui omfatter også swagger dokumentation, som er tilgængelig under `/swagger` **[URL](http://localhost:1242/swagger)**. Swagger dokumentation fungerer som en midtermand mellem vores API implementering og andre værktøjer ved hjælp af det (f.eks. ASF-ui). Det giver en komplet dokumentation og tilgængelighed af alle API-endepunkter i **[OpenAPI](https://swagger.io/resources/open-api)** -specifikationen, der nemt kan forbruges af andre projekter så du kan skrive og teste ASF API med lethed.

Bortset fra at bruge vores swagger dokumentation som en komplet specifikation af ASF API, du kan også bruge det som brugervenlig måde at udføre forskellige API endepunkter, primært dem, der ikke er implementeret af ASF-ui. Da vores swagger dokumentation genereres automatisk fra ASF kode, du har en garanti for, at dokumentationen altid vil være up-to-date med API-endepunkter, som din version af ASF omfatter.

![Swagger dokumentation](https://github.com/user-attachments/assets/ce998e08-f5db-46b0-a9e8-e6b69abd94bb)


---

# OSS

### Er ASF's IPC-grænseflade sikker og sikker at bruge?

ASF som standard kun lytter på `localhost` adresser, hvilket betyder, at adgang til ASF IPC fra enhver anden maskine, men din egen **er umuligt**. Medmindre du ændrer standard endpoints, angriber vil have brug for en direkte adgang til din egen maskine for at få adgang til ASF's IPC, Derfor er det så sikkert, som det kan være, og der er ingen mulighed for, at andre får adgang til det, selv fra dit eget LAN.

Men hvis du beslutter dig for at ændre standard `localhost` binder adresser til noget andet, så er det meningen, at du skal sætte korrekte firewall regler **dig selv** for at tillade kun autoriserede IP'er at få adgang til ASF's IPC interface. Ud over at gøre det, skal du oprette `IPCPassword`, da ASF vil nægte at lade andre maskiner adgang ASF API uden en, som tilføjer et andet lag af ekstra sikkerhed. Du kan også ønsker at køre ASF's IPC interface bag en omvendt proxy i dette tilfælde, som er yderligere forklaret nedenfor.

### Kan jeg få adgang til ASF API via mine egne værktøjer eller brugerscripts?

Ja, det er, hvad ASF API er designet til, og du kan bruge alt, hvad der er i stand til at sende en HTTP anmodning for at få adgang til det. Lokale brugerscripts følger **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** logik, og vi giver adgang fra alle oprindelser for dem (`*`), så længe `IPCPassword` er indstillet, som en ekstra sikkerhedsforanstaltning. Dette giver dig mulighed for at udføre forskellige godkendte ASF API anmodninger, uden at tillade potentielt skadelige scripts til at gøre det automatisk (som de ville have brug for at kende dit `IPCPassword` for at gøre det).

### Kan jeg få fjernadgang til ASF's IPC, f.eks. fra en anden maskine?

Ja, vi anbefaler at bruge en omvendt proxy til det. På denne måde kan du få adgang til din webserver på typisk måde, som derefter vil få adgang til ASF's IPC på samme maskine. Alternativt, hvis du ikke ønsker at køre med en omvendt proxy, kan du bruge **[brugerdefinerede konfiguration](#enabling-access-from-all-ips)** med passende URL til det. For eksempel, hvis din maskine er i en VPN med `10.8.0.1` adresse, så kan du indstille `http://10.8.0. :1242` lytter URL i IPC config, som ville aktivere IPC adgang fra din private VPN, men ikke fra andre steder.

### Kan jeg bruge ASF's IPC bag en omvendt proxy som Apache eller Nginx?

**Ja**, vores IPC er fuldt kompatibel med en sådan opsætning, så du er fri til at være vært for det også foran dine egne værktøjer for ekstra sikkerhed og kompatibilitet, hvis du gerne vil. Generelt er ASF's Kestrel http server meget sikker og besidder ingen risiko, når de er tilsluttet direkte til internettet, men sætte det bag en reverse-proxy såsom Apache eller Nginx kunne give ekstra funktionalitet, der ikke ville være muligt at opnå ellers, såsom sikring af ASF's grænseflade med en **[basic auth](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Eksempel på Nginx-konfiguration kan findes nedenfor. Vi har inkluderet fuld `server` blok, selv om du primært er interesseret i `placering` dem. Se venligst **[nginx documentation](https://nginx.org/en/docs)** , hvis du har brug for yderligere forklaring.

```nginx
server {
    lyt *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /path/to/your/fullchain. em;
    ssl_certificate_key /path/to/din/privkey. em;

    placering ~* /Api/NLog {
        proxy_pass http://127.0.0. :1242

        # Kun hvis du har brug for at tilsidesætte standard vært
# proxy_set_header Host 127. .0. ;

        # X-headers skal altid angives, når proxying anmodninger til ASF
        # De er afgørende for korrekt identifikation af oprindelige IP, at tillade ASF til f.eks. ban de faktiske lovovertrædere i stedet for din nginx server
        # Angivelse af dem gør det muligt for ASF at løse IP-adresser på brugere der fremsætter forespørgsler korrekt - at få nginx til at fungere som en omvendt proxy
        # Ikke at angive dem vil få ASF til at behandle din nginx som klient - nginx vil fungere som en traditionel proxy i dette tilfælde
        # Hvis du ikke kan være vært for nginx service på samme maskine som ASF, du højst sandsynligt ønsker at indstille KnownNetworks hensigtsmæssigt ud over disse
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;

        # Vi tilføjer disse 3 ekstra muligheder for websockets proxying, se https://nginx. rg/da/docs/http/websocket.html
        proxy_http_version 1. ;
        proxy_set_header Forbindelse "Opgrader";
        proxy_set_header opgradering $http_upgrade;
    }

    lokation / {
        proxy_pass http://127. .0. :1242

        # Kun hvis du har brug for at tilsidesætte standard vært
# proxy_set_header Host 127. .0. ;

        # X-headers skal altid specificeres, når proxying anmodninger til ASF
        # De er afgørende for korrekt identifikation af oprindelige IP, at tillade ASF til f.eks. ban de faktiske lovovertrædere i stedet for din nginx server
        # Angivelse af dem gør det muligt for ASF at løse IP-adresser på brugere der fremsætter forespørgsler korrekt - at få nginx til at fungere som en omvendt proxy
        # Ikke at angive dem vil få ASF til at behandle din nginx som klient - nginx vil fungere som en traditionel proxy i dette tilfælde
        # Hvis du ikke kan være vært for nginx service på samme maskine som ASF, du højst sandsynligt ønsker at indstille KnownNetworks hensigtsmæssigt ud over disse
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
    }
}
```

Eksempel på Apache konfiguration kan findes nedenfor. Se venligst **[apache dokumentation](https://httpd.apache.org/docs)** , hvis du har brug for yderligere forklaring.

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerName asf.mydomain. om

        SSLEngine On
        SSLCertificateFile /path/to/din/fullchain. em
        SSLCertificateKeyFile /path/to/din/privkey. em

        # TODO: Apache kan ikke gøre case-ufølsom matchning ordentligt, så vi hardcode to mest almindeligt anvendte sager
        ProxyPass "/api/nlog" "ws://127. .0. :1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0. :1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### Kan jeg få adgang til IPC-grænseflade gennem HTTPS-protokollen?

**Ja**, kan du opnå det på to forskellige måder. En anbefalet måde ville være at bruge en omvendt proxy for at, hvor du kan få adgang til din webserver via https som sædvanlig, og forbinde gennem det med ASF's IPC interface på samme maskine. På denne måde er din trafik fuldt krypteret, og du behøver ikke at ændre IPC på nogen måde for at understøtte en sådan opsætning.

Anden måde omfatter at angive en **[brugerdefineret config](#custom-configuration)** til ASF's IPC interface, hvor du kan aktivere https endpoint og levere passende certifikat direkte til vores Kestrel http server. Denne måde anbefales, hvis du ikke kører nogen anden webserver og ikke ønsker at køre en udelukkende til ASF. Ellers er det meget lettere at opnå en tilfredsstillende opsætning ved hjælp af en omvendt proxy mekanisme.

---

### Ved opstart af IPC får jeg en fejl: `System.IO. Undtagelse: Kunne ikke binde til adressen, Der blev gjort et forsøg på at få adgang til en sokkel på en måde forbudt af dens adgangstilladelser`

Denne fejl indikerer, at noget andet på din maskine enten allerede bruger denne port, eller reserveret det til fremtidig brug. Dette kan være dig, hvis du forsøger at køre anden ASF instans på samme maskine, men oftest er det Windows eksklusive port `1242` fra din brug, derfor er du nødt til at flytte ASF til en anden port. For at gøre det, følg **[eksempel config](#changing-default-port)** ovenfor, og blot forsøge at vælge en anden port, såsom `12420`.

Selvfølgelig kunne du også forsøge at finde ud af, hvad der blokerer port `1242` fra ASF brug, og fjern det, men det er normalt langt mere besværligt end blot at instruere ASF til at bruge en anden port, så vi vil springe mere udførligt på det her.

---

### Hvorfor får jeg `403 Forbudt` -fejl, når jeg ikke bruger `IPCPassword`-?

ASF omfatter yderligere sikkerhedsforanstaltninger, der som standard kun tillader loopback interface (`localhost`, din egen maskine) for at få adgang til ASF API uden `IPCPassword` sat i konfigurationen. Dette skyldes, at brug af `IPCPassword` bør være en **minimum** sikkerhedsforanstaltning fastsat af alle, der beslutter at udsætte ASF interface yderligere.

Ændringen var dikteret af det faktum, at massiv mængde ASF var vært globalt af uvidende brugere blev overtaget for ondsindede hensigter, normalt forlader folk uden konti og uden poster på dem. Nu kan vi sige "de kunne læse denne side, før de åbner ASF til hele verden", men i stedet giver det mere mening at afvise usikre ASF opsætninger som standard, og kræver af brugerne en handling, hvis de udtrykkeligt ønsker at tillade det, som vi uddyber om nedenfor.

Du er især i stand til at tilsidesætte vores beslutning ved at specificere de netværk, som du har tillid til for at nå ASF uden `IPCPassword` specificeret, du kan indstille dem i `KnownNetworks` ejendom i brugerdefineret konfiguration. However, unless you **really** know what you're doing and fully understand the risks, you should instead use `IPCPassword` as declaring `KnownNetworks` will allow everybody from those networks to access ASF API unconditionally. Vi er alvorlige, folk var allerede skyde sig selv i foden tro deres omvendte fuldmagter og iptables regler var sikre, men de var `IPCPassword` er den første og nogle gange den sidste vogter, hvis du beslutter dig for at fravælge denne enkle, men meget effektive og sikre mekanisme, vil du kun have dig selv til at bebrejde.