# IPC

ASF inkluderer sitt eget unike IPC-grensesnitt som kan benyttes for videre samhandling med prosessen. IPC står for **[interprosess-kommunikasjon](https://en.wikipedia.org/wiki/Inter-process_communication)** og i den mest enkle definisjonen er dette "ASF webgrensesnitt" basert på **[Kestrel HTTP server](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel)** som kan brukes for videre integrasjon med prosessen, både som frontend for sluttbruker (ASF-ui), og som backend for tredjeparts integrasjoner (ASF API).

IPC kan brukes på mange ulike måter, avhengig av dine behov og ferdigheter. Du kan for eksempel bruke det til å hente status som ASF og alle boter, sende ASF-kommandoer, hente og redigere globalt/bot konfigurasjoner, legge til nye bots, slette eksisterende bots, innsendingsnøkler for **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** eller få tilgang til ASFs loggfil. Alle disse handlingene er eksponert av vår API, noe som betyr at du kan kode dine egne verktøy og skript som kan kommunisere med ASF og påvirke det i løpet av kjøretid. I tillegg til det, valgte handlinger (som å sende kommandoer) er også implementert av våre ASF-ui som lar deg enkelt få tilgang til dem gjennom et vennlig webgrensesnitt.

---

# Bruk

Med mindre du manuelt deaktiverte IPC gjennom `IPC` **[globale konfigurasjonsrettigheter](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, er den aktivert som standard. ASF vil melde IPC start i loggen, som du kan bruke til å bekrefte om IPC grensesnittet har startet riktig:

```text
INFOtikasonASF∙Start() som starter IPC-server...
INFO″ASF∙Start() IPC server klar!
```

ASFs http-server lytter nå på utvalgte endepunkter. Hvis du ikke ga en egendefinert konfigurasjonsfil for IPC, vil det være `localhost`, både IPv4-basert **[127. .0.1](http://127.0.0.1:1242)** og IPv6-basert **[[:1]](http://[::1]:1242)** til standard `1242` port. Du får tilgang til vårt IPC grensesnitt gjennom over lenker, men bare fra samme maskin som den som kjører ASF-prosessen.

ASFs IPC grensesnittet utsetter tre ulike måter å få tilgang til denne, avhengig av din planlagte bruk.

På det laveste nivået finnes **[ASF API](#asf-api)** som er kjernen i IPC grensesnittet og lar alt annet fungere. Dette er det du vil bruke i dine egne verktøy, verktøy og prosjekter for å kommunisere med ASF direkte.

På middels bakken er det vår **[Swagger dokumentasjon](#swagger-documentation)** som fungerer som en frontend til ASF-API. Det har en fullstendig dokumentasjon av ASF-API, og det gir dere lettere tilgang til den. Det er dette du vil sjekke om du planlegger å skrive et verktøy, nytte eller andre prosjekter som skal kommunisere med ASF gjennom sin API.

På høyeste nivå er det **[ASF-ui](#asf-ui)** som er basert på vår ASF API og gir brukervennlig måte å utføre ulike ASF-handlinger. Dette er vårt standard IPC grensesnitt designet for sluttbrukere, og et perfekt eksempel på hva du kan bygge med ASF API. Hvis du ønsker kan du bruke ditt eget web-grensesnitt for å bruke ASF, ved å angi `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** og ved å bruke egendefinert `www` mappen, som ligger der.

---

# ASF-ui

ASF-ui er et samfunnsprosjekt som skal lage et brukervennlig grafisk webgrensesnitt for sluttbrukere. For å oppnå det, fungerer det som en frontend til **[ASF API](#asf-api)**, gjør det enkelt å utføre ulike handlinger. Dette er standardgrensesnittet som ASF kommer med.

Som angitt ovenfor er ASF-ui et samfunnsprosjekt som ikke vedlikeholdes av kjerne-ASF-utviklere. Det følger sin egen flyt i **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** , som bør brukes for alle relaterte spørsmål, feilrapporter og forslag.

Du kan bruke ASF-ui for generell behandling av ASF-prosessen. Det tillater eksempel å administrere bots, endre innstillinger, sende kommandoer og oppnå valgt annen funksjonalitet som normalt er tilgjengelig gjennom ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

Our ASF API is typical **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** web API that is based on JSON as the primary data format. Vi gjør vårt beste for å nøyaktig beskrive svar ved å bruke begge HTTP statuskoder (der det er aktuelt). så vel som et svar du kan analysere deg selv for å vite om forespørselen lykkes, og hvis ikke vil det skje.

Vår ASF API kan nås ved å sende riktige forespørsler til hensiktsmessige `/Api` endepunkter. Du kan bruke disse API endepunktene for å lage dine egne hjelperskript, verktøy, GUIs og likt. Det er nettopp hva våre ASF-ui oppnår under komoden, og hvert annet verktøy kan oppnå det samme. ASF API er offisielt støttet og vedlikeholdes av kjernen ASF team.

For fullstendig dokumentasjon av tilgjengelige endepunkter, beskrivelser, forespørsler, svar, https statuskoder og alt annet som behandler ASF-API, se vår **[swagger dokumentasjon](#swagger-documentation)**.

![ASF API](https://github.com/user-attachments/assets/08c3d4ad-ea77-403d-a18a-b75c3d0a3097)


---

# Egendefinert konfigurasjon

Vårt IPC-grensesnitt støtter ekstra konfigurasjonsfil, `IPC.config` som skal plasseres i standard ASF's `config` mappe.

Denne filen spesifiserer nå avansert konfigurasjon av ASFs Kestrel http-server, sammen med annen IPC-relatert tuning. Med mindre du har et spesielt behov, er det ingen grunn til å bruke denne filen, – siden ASF allerede bruker fornuftige mislighold i dette tilfellet.

Konfigurasjonsfilen er basert på følgende JSON-struktur:

```json
{
    "Kestrel": {
        "Endpoints": {
            "example-http4": {
                "Url": "http://127. .0. :1242"
            },
            "example-http6": {
                "Url": "http://[::1]:1242"
            },
            "example-https4": {
                "Url": "https://127. .0,1:1242",
                "Sertifikat": {
                    "Sti": "/path/to/certificat. fx",
                    "Password": "passwordToPfxFileAbove"
                }
            },
            "example-https6": {
                "Url": "https://[:1]:1242",
                "Sertifikat": {
                    "Sti": "/path/to/certificat. fx",
                    "Passord": "passwordToPfxFileAbove"
                }
            }
        },
        "Kjør-nettverk": [
            "10. .0.0/8",
            "172.16.0. /12",
            "192.168.0. /16"
        ],
        "PathBase": "/"
    }
}
```

`Endepunkter` - Dette er en samling av endepunkter, hvert endepunkt har sitt eget unike navn (som `-eksempelle-http4`) og `Url` -eiendom som spesifiserer `Protocol://Host:Port` lyttingsadresse. Som standard lytter ASF på IPv4 og IPv6 http-adresser, men vi har lagt til https eksempler hvis nødvendig. Du bør bare erklære de endepunktene som du trenger, har vi tatt 4 eksempel over, slik at du kan redigere dem lettere.

`Host` aksepterer enten `localhost`, en fast IP-adresse for grensesnittet som det skal lytte på (IPv4/IPv6), eller `*` -verdi som binder ASFs http-server til alle tilgjengelige grensesnitt. Bruker andre verdier som `mydomain.com` eller `192.168.0.` har det samme som `*`, det er ikke implementert noen IP-filtrering, Vær derfor ekstremt forsiktig når du bruker `Host` -verdier som tillater ekstern tilgang. Dette vil gi tilgang til ASFs IPC-grensesnitt fra andre maskiner, som kan utgjøre en sikkerhetsrisiko. Vi anbefaler sterkt å bruke `IPCPassword` (og fortrinnsvis din egen brannmur) **på et minimum** i dette tilfellet.

`KnownNetworks` - This **optional** variable specifies network addresses which we consider trustworthy. Som standard er ASF konfigurert til å stole på loopback-grensesnittet (`localhost`, samme maskin) **bare**. Denne eiendommen brukes på to måter. Først – hvis du utelater `IPCPassword`, Da tillater vi bare maskiner fra kjente nettverk å få tilgang til ASFs API, og avslå alle andre som et sikkerhetstiltak. For det andre er denne eiendommen avgjørende med hensyn til reverserte proxyer som aksesser ASF, siden ASF bare vil ære overskriftene dersom reverse-proxy serveren er fra i kjente nettverk. Å hedre overskriftene er avgjørende i forhold til ASFs anti-brutestyrke, som i stedet for å forby en reverse-proxy ved et problem, it'll ban the IP specified av the reverse-proxy as the source of the original message. Vær ekstremt forsiktig med nettverkene du angir her, siden det tillater en potensiell IP-skremming og uautorisert tilgang i tilfelle maskinen blir kompromittert eller konfigurert ved feil.

`PathBase` - This is **optional** base path that will be used by IPC interface. Standarder til `/` og bør ikke være nødvendig for å endre de fleste brukstilfellene. Ved å endre denne egenskapen vil hele IPC-grensesnittet være på et tilpasset prefix, for eksempel `http://localhost: 1242/MyPrefix` i stedet for `http://localhost:1242` alene. Ved hjelp av egendefinert `PathBase` kan man ønske seg i kombinasjon med spesifikt oppsett av en revers-proxy der du bare ønsker å proxy med en spesifikk URL for eksempel `mindomene. om/ASF` i stedet for hele `mindomene.com` domene. Normalt vil det kreve at du skriver en omskrivingsregel for webserveren som tilordner `mitt domene. om/ASF/Api/X` -> `localhost:1242/Api/X`men i stedet kan du definere en egendefinert `pathBase` av `/ASF` og oppnå enklere oppsett av `fager. om/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

Med mindre du virkelig trenger å spesifisere en egendefinert base bane, er det best å la den være som standard.

## Eksempel konfigurert

### Endrer standard port

Følgende konfigurasjon endrer bare standard ASF lytting fra `1242` til `1337`. Du kan velge hvilken som helst port du vil, men vi anbefaler `1024-32767` som andre porter er vanligvis **[registrert](https://en.wikipedia.org/wiki/Registered_port)**, og kan for eksempel kreve `root` tilgang i Linux.

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
}
```

---

### Aktiverer tilgang fra alle IP-adresser

The following config will allow remote access from all sources, therefore you should **ensure that you read and understood our security notice about that**, available above.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"

        }
    }

```

Hvis du ikke trenger tilgang fra alle kilder, men kun for eksempel ditt LAN så er det mye bedre å sjekke lokal IP-adresse til maskinen som hosting ASF, for eksempel `192. 68.0.10` og bruk den i stedet for `*` på eksempel config over. Dessverre er det bare mulig hvis din LAN-adresse alltid er den samme, ellers vil du sannsynligvis ha mer tilfredsstillende resultater med `*` og din egen brannmur oppå det som bare tillater lokale undertekster for å få tilgang til ASFs port.

---

# Autentisering

ASF IPC som standard krever ingen godkjenning fordi `IPCPassword` er satt til `null`. Hvis `IPCPassword` er aktivert ved å bli satt til en ikke-tom verdi, Hver samtale til ASFs API krever passordet som samsvarer med innstilt `IPCPassword`. Hvis du utelater autentisering eller skriver feil passord, vil du få `401 - Uautorisert` feil. Etter 5 mislykkede autentiseringsforsøk (feil passord), vil du bli midlertidig blokkert med `403 - Forbudt` feil.

Autentisering kan gjøres på to separate måter.

## `Autentisering` header

Generelt bør du bruke **[HTTP request headers](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)**ved å sette `autentisering` feltet med passordet som en verdi. Måten å gjøre det på, avhenger av det faktiske verktøyet du bruker for å få tilgang til ASFs IPC-grensesnitt, for eksempel hvis du bruker `curl` bør du legge til `-H 'Authentication: MyPassword'` som et parameter. Denne måten å godkjenne på er passert i overskriftene på forespørselen, der denne faktisk skal skje.

## `passord` parameter i spørring

Alternativt kan du legge til `passord` parameteren på slutten av nettadressen du skal ringe, for eksempel ved å ringe `/Api/ASF? assword=MyPassword` i stedet for `/Api/ASF` alene. Denne tilnærmingen er god nok, men selvsagt utsetter den passord i den åpne, noe som ikke nødvendigvis er passende. I tillegg til at det er et ekstra argument i spørringsstrengen, hvilke kompliserer utseendet på nettadressen og får det til å føles som det er URL-spesifikt, mens passordet gjelder hele ASF API-kommunikasjonen.

---

Begge veier støttes og det er helt opp til deg hvilken du vil velge. Vi anbefaler å bruke HTTP headere overalt hvor du kan, som bruke-vis, er det mer passende enn å søke i. Men vi støtter også søkestrenger, hovedsakelig på grunn av ulike begrensninger knyttet til forespørselshoder. Et godt eksempel inkluderer mangel på egendefinerte overskrifter samtidig som det initierer en web-socket-tilkobling i javascript (selv om det er helt gyldig i henhold til RFC). I denne situasjonen er teksten med spørring den eneste måten å godkjenne på.

---

# Swagger dokumentasjon

IPC - grensesnittet - i tillegg til ASF API og ASF-ui omfatter også swagger dokumentasjon, som er tilgjengelig under `/swagger` **[URL](http://localhost:1242/swagger)**. Swagger dokumentasjon fungerer som mellommann mellom implementeringen av vårt API og andre verktøy ved hjelp av den (f.eks. ASF-ui). Den gir en fullstendig dokumentasjon og tilgjengelighet av alle API-endepunkter i **[OpenAPI](https://swagger.io/resources/open-api)** -spesifikasjon som enkelt kan forbrukes av andre prosjekter, Gjør det enkelt å skrive og teste ASF API ut.

Bortsett fra å bruke vår swagger dokumentasjon som en fullstendig spesifikasjon av ASF-API, du kan også bruke det som brukervennlig måte å utføre ulike API-endepunkter på, hovedsakelig de som ikke er implementert av ASF-ui. Siden vår swagger dokumentasjon genereres automatisk fra ASF-kode, du har en garanti for at dokumentasjonen alltid vil være oppdatert med API-endepunktene om at din versjon av ASF inkluderer.

![Swagger dokumentasjon](https://github.com/user-attachments/assets/ce998e08-f5db-46b0-a9e8-e6b69abd94bb)


---

# OSS

### Er ASF's IPC interface sikkert og trygt å bruke?

ASF som standard lytter bare på `localhost` adresser, som betyr at det er umulig å bruke ASF IPC fra andre maskiner, men **selv.**. Med mindre du endrer standardendepunkter, vil angriper trenge direkte tilgang til din egen maskin for å få tilgang til ASFs IPC, Derfor er det så trygt som det kan være og det er ingen mulighet for at noen andre får tilgang til det, selv fra din egen LAN.

Hvis du imidlertid bestemmer deg for å endre standard `localhost` binder adresser til noe annet Da skal du angi gode brannmurregler **selv** for å bare tillate autoriserte IP-adresser å få tilgang til ASFs IPC-grensesnitt. I tillegg til å gjøre det, må du sette opp `IPCPassword`, siden ASF vil nekte å la andre maskiner få tilgang til ASF API uten en, noe som gir et nytt lag ekstra sikkerhet. Du kan også ønske å kjøre ASFs IPC-grensesnitt bak en revers proxy i denne saken, noe som blir nærmere forklart under.

### Kan jeg få tilgang til ASF API gjennom mine egne verktøy eller brukerskripter?

Ja, dette er hva ASF API er designet for og du kan bruke alt som er i stand til å sende en HTTP-forespørsel om tilgang til den. Lokale brukerskript følger **[KORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** logikk, og vi tillater tilgang fra alle opprinnelser for dem (`*`), Så lenge `IPCPassword` er angitt, som et ekstra sikkerhetstiltak. Dette gir deg mulighet til å kjøre forskjellige godkjente ASF API-forespørsler, uten å tillate potensielt skadelige skript å gjøre det automatisk (som de trenger å vite om ditt `IPCPassword` for å gjøre det!

### Kan jeg få tilgang til ASFs IPC eksternt, for eksempel fra en annen maskin?

Ja, vi anbefaler å bruke en omvendt proxy for det. På denne måten kan du få tilgang til webserveren din på typisk måte, som deretter får tilgang til ASFs IPC på samme maskin. Hvis du ikke vil kjøre med en omvendt proxy, kan du bruke **[egendefinerte konfigurasjon](#enabling-access-from-all-ips)** med passende URL for det. For eksempel, hvis maskinen din er i en VPN på `10.8.0.1` -adressen, kan du sette `http://10.8.0. :1242` lytter URL i IPC config, som vil gi IPC tilgang fra din private VPN, men ikke fra andre steder.

### Kan jeg bruke ASFs IPC bak en revers proxy som Apache eller Nginx?

**Ja**, vår IPC er fullt kompatibel med slike oppsett, så du er fri til å arrangere det også foran dine egne verktøy for ekstra sikkerhet og kompatibilitet, hvis du ønsker det. Generelt er ASFs Kestrel http server svært sikker, og har ingen risiko når den er koblet direkte til Internett, men sette den bak en reverse-proxy som Apache eller Nginx kan gi ekstra funksjonalitet som ikke vil være mulig for å oppnå en annen for eksempel å sikre ASFs grensesnitt med en **[grunnleggende auth](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Eksempel Nginx konfigurasjon kan bli funnet nedenfor. Vi har inkludert hele `server` blokken, selv om du er interessert i `lokasjon`. Se **[nginx dokumentasjon](https://nginx.org/en/docs)** hvis du trenger ytterligere forklaring.

```nginx
server {
    høre *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /path/to/your/fullchain. em;
    ssl_certificate_key /path/to/your/privkey. em;

    plassering ~* /Api/NLog {
        proxy_pass http://127.0.0. :1242;

        # Bare hvis du må overstyre standard vert
# proxy_set_header Host 127. .0. ;

        # X-overskrifter bør alltid angis når proxy-forespørsler til ASF
        # De er avgjørende for riktig identifikasjon av opprinnelig IP, tillate at ASF f.eks. bannlysning av de aktuelle lovbryterne i stedet for den nginx-serveren
        # Spesifikasjon dem tillater ASF å løse IP-adressene for brukere som foretar forespørsler - gjøre nginx arbeid som en revers proxy
        # Ikke som spesifiserer, vil føre til at ASF behandler din nginx som klienten - nginx vil fungere som en tradisjonell proxy i så fall
        # Hvis du kan være vert for den samme maskinen som ASF, du ønsker sannsynligvis å sette KnownNetworks på riktig måte i tillegg til
        proxy_set_header X-Forwarded-for $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;

        # Vi legger til de 3 ekstra alternativene for websockets proxying, se https://nginx. rg/en/docs/http/websocket.html
        proxy_http_versjon 1. ;
        proxy_set_header tilkobling "Oppgradering";
        proxy_set_header oppgradering $http_upgrade;
    }

    plassering / {
        proxy_pass http://127. .0. :1242;

        # Bare hvis du må overstyre standard vert
# proxy_set_header Host 127. .0. ;

        # X-overskrifter bør alltid angis når proxying forespørsler til ASF
        # De er avgjørende for riktig identifikasjon av opprinnelig IP, tillate at ASF f.eks. bannlyse aktuelle lovbrytere istedenfor din nginx server
        # Spesifiser dem tillater ASF å løse IP-adressene til brukerne som foretar forespørsler - ved å gjøre nginx virker som en revers proxy
        # Ikke spesifisering, dem vil føre til ASF for å behandle din nginx som klienten - nginx vil fungere som en tradisjonell proxy i så fall
        # Om du kan være vert for den samme maskinen som ASF, du ønsker mest sannsynlig å sette KnownNetworks i tillegg til dem
        proxy_set_header X-Forwarded-for $proxy_add_x_forwarded_for
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme
        proxy_set_header X-Forwarded-Server $host;
    }
}
```

Eksempel Apache-konfigurasjon kan finnes nedenfor. Se **[apache-dokumentasjon](https://httpd.apache.org/docs)** hvis du trenger ytterligere forklaring.

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        Servernavn asf.mydomene. om

        SSLEngine på
        SSLCertificateFile /path/to/your/fullchain. em
        SSLCertificateKeyFile /path/your/privkey. em

        # TODO: Apache kan ikke matche case-insensitivt ordentlig, så vi plager to mest brukte tilfeller av
        ProxyPass "/api/nlog" "ws://127. .0. :1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0. :1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### Kan jeg få tilgang til IPC gjennom HTTPS-protokoll?

**Ja**, du kan oppnå det på to ulike måter. En anbefalt måte å bruke en omvendt proxy for det, der du kan få tilgang til webserveren gjennom https som vanlig, og koble den til med ASFs IPC-grensesnitt i samme maskin. På denne måten er trafikken din fullstendig kryptert, og du trenger ikke å endre IPC på noen måte for å støtte dette.

Andre måter inkluderer å angi et **[egendefinert konfigurasjon](#custom-configuration)** for ASFs IPC grensesnitt der du kan aktivere https endepunkt og gi passende sertifikat direkte til vår Kestrel http server. Denne måten anbefales hvis du ikke kjører noen annen web-server og ikke ønsker å kjøre en utelukkende for ASF. Ellers er det mye enklere å oppnå et tilfredsstillende oppsett ved å bruke en revers proxy-mekanisme.

---

### Under oppstart av IPC får jeg en feil: `System.IO. Unntak: Kunne ikke binde seg til adresse, et forsøk ble gjort for å få tilgang til en socket på en måte som ble forbudt av sine tilgangsrettigheter`

Denne feilen viser at noe annet på maskinen din enten allerede bruker denne porten, eller har reservert den for framtidig bruk. Dette kan være deg hvis du prøver å kjøre andre ASF-forekomst på samme maskin, men oftest er det Windows eksklusiv port `1242` fra bruken, derfor må du flytte ASF til en annen port. For å gjøre det, følg **[eksempel, config](#changing-default-port)** ovenfor, og bare prøv å velge en annen port, som `12420`.

Selvsagt kan du også prøve å finne ut hva som blokkerer port `1242` fra ASF-bruk, og fjerne det, men det er vanligvis langt mer problematisk enn det å instruere ASF til å bruke en annen port, så vi kan hoppe over å gå videre på det her.

---

### Hvorfor får jeg `403 forbudt` feilen ved ikke å bruke `IPCPassword`?

ASF inkluderer ytterligere sikkerhetstiltak som standard tillater bare loopback-grensesnitt (`localhost`, din egen maskin) tilgang til ASF API uten `IPCPassword` angitt i konfigurasjonen. Dette fordi det ved hjelp av `IPCPassword` bør være et **minimum** sikkerhetsmål satt av alle som bestemmer seg for å utsette ASF-grensesnittet ytterligere.

Endringen ble dikert av det faktum at massiv mengde ASF-er var vert globalt av ukjente brukere ble overtatt for ondsinnede intensjoner, som vanligvis forlater personer uten kontoer og uten elementer på dem. Nå kan vi si "de kan lese denne siden før de åpner ASF for hele verden", Det er i stedet mer fornuftig å forhindre sikre ASF-oppsett som standard, og krever en handling fra brukerne hvis de eksplisitt vil tillate det, noe vi utdyper nedenfor.

Spesielt kan du overstyre beslutningen vår ved å angi hvilke nettverk du stoler på for å oppnå ASF uten `IPCPassword` som er angitt, du kan sette de i `Kjør-nettverk` -egenskapen med egendefinert konfigurasjon. However, unless you **really** know what you're doing and fully understand the risks, you should instead use `IPCPassword` as declaring `KnownNetworks` will allow everybody from those networks to access ASF API unconditionally. Vi er alvorlige, mennesker drev allerede på seg selv i foten med tro på sine bakhandlinger og iptables-regler som er sikre, men de er ikke sikre, `IPCPassword` er den første og noen ganger den siste personen, Hvis du bestemmer deg for å velge ut av denne enkelte, enda svært effektiv og sikker mekanisme, vil du kun ha deg selv å skylde.