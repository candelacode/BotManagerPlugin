# IPC

ASF har ett eget unikt IPC-gränssnitt som kan användas för vidare interaktion med processen. IPC står för **[inter-process kommunikation](https://en.wikipedia.org/wiki/Inter-process_communication)** och i den enklaste definitionen är detta "ASF web interface" baserat på **[Kestrel HTTP server](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel)** som kan användas för vidare integration med processen, både som skal för slutanvändare (ASF-ui), och backend för tredjepartsintegreringar (ASF API).

IPC kan användas för många olika saker, beroende på dina behov och färdigheter. Du kan till exempel använda den för att hämta status för ASF och alla robotar, skicka ASF-kommandon, hämta och redigera globala/bot konfigurationer, lägger till nya robotar, tar bort befintliga robotar, skickar in nycklar till **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** eller öppnar ASFs loggfil. Alla dessa åtgärder exponeras av vårt API, vilket innebär att du kan koda dina egna verktyg och skript som kommer att kunna kommunicera med ASF och påverka det under körtid. Förutom det, utvalda åtgärder (såsom att skicka kommandon) implementeras också av vår ASF-ui som gör att du enkelt kan komma åt dem via ett vänligt webbgränssnitt.

---

# Användning

Såvida du inte manuellt inaktiverat IPC genom `IPC` **[globala konfigurationsegenskapen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**är den aktiverad som standard. ASF kommer att ange IPC-lanseringen i sin logg, som du kan använda för att verifiera om IPC-gränssnittet har startat ordentligt:

```text
INFO<unk> ASF<unk> Start() Startar IPC-server...
INFO<unk> ASF<unk> Start() IPC-servern klar!
```

ASF:s http-server lyssnar nu på valda slutpunkter. Om du inte tillhandahåller en anpassad konfigurationsfil för IPC, kommer det att vara `localhost`, båda IPv4-baserade **[127. .0.1](http://127.0.0.1:1242)** och IPv6-baserad **[[::1]](http://[::1]:1242)** på standard `1242` port. Du kan komma åt vårt IPC-gränssnitt via ovanstående länkar, men endast från samma maskin som den som kör ASF-processen.

ASF:s IPC-gränssnitt exponerar tre olika sätt att komma åt det, beroende på din planerade användning.

På den lägsta nivån finns **[ASF API](#asf-api)** som är kärnan i vårt IPC-gränssnitt och tillåter allt annat att fungera. Detta är vad du vill använda i dina egna verktyg, verktyg och projekt för att kommunicera med ASF direkt.

På medellång mark finns vår **[Swagger dokumentation](#swagger-documentation)** som fungerar som ett skal till ASF API. Den har en komplett dokumentation av ASF API och ger dig även tillgång till det lättare. Detta är vad du vill kontrollera om du planerar att skriva ett verktyg, utility eller andra projekt som är tänkta att kommunicera med ASF genom dess API.

På högsta nivå finns det **[ASF-ui](#asf-ui)** som är baserad på vårt ASF API och ger användarvänligt sätt att utföra olika ASF-åtgärder. Detta är vårt standard IPC-gränssnitt utformat för slutanvändare, och ett perfekt exempel på vad du kan bygga med ASF API. Om du vill kan du använda din egen anpassade webbgränssnitt för att använda ASF, genom att ange `--path` **[kommandoradsargumentet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** och använda anpassad `www` katalog som finns där.

---

# ASF-ui

ASF-ui är ett gemenskapsprojekt som syftar till att skapa användarvänligt grafiskt webbgränssnitt för slutanvändare. För att uppnå detta fungerar det som ett skal till vår **[ASF API](#asf-api)**, låta dig göra olika åtgärder med lätthet. Detta är standard UI som ASF kommer med.

Som nämnts ovan, ASF-ui är ett gemenskapsprojekt som inte upprätthålls av kärnan ASF-utvecklare. Den följer sitt eget flöde i **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** som bör användas för alla relaterade frågor, problem, felrapporter och förslag.

Du kan använda ASF-ui för allmän hantering av ASF-processen. Det tillåter till exempel att hantera botar, ändra inställningar, skicka kommandon och uppnå valda andra funktioner som normalt är tillgängliga via ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

Vårt ASF API är typiskt **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** web API som är baserat på JSON som dess primära dataformat. Vi gör vårt bästa för att exakt beskriva svaret, med både HTTP-statuskoder (där det är lämpligt), samt ett svar du kan tolka dig själv för att veta om begäran lyckades, och om inte, sedan varför.

Vårt ASF API kan nås genom att skicka lämpliga förfrågningar till lämpliga `/Api` slutpunkter. Du kan använda dessa API-slutpunkter för att göra dina egna hjälpskript, verktyg, GUIs och liknande. Detta är exakt vad vår ASF-ui uppnår under huvan, och alla andra verktyg kan uppnå detsamma. ASF API stöds och underhålls officiellt av ASF-kärnteamet.

För fullständig dokumentation av tillgängliga slutpunkter, beskrivningar, förfrågningar, svar, http statuskoder och allt annat med tanke på ASF API, hänvisas till vår **[swagger dokumentation](#swagger-documentation)**.

![ASF API](https://github.com/user-attachments/assets/08c3d4ad-ea77-403d-a18a-b75c3d0a3097)


---

# Anpassad konfiguration

Vårt IPC-gränssnitt stöder extra konfigurationsfil, `IPC.config` som ska sättas i standard ASFs `config` -katalog.

När denna fil är tillgänglig anger den avancerade konfigurationen av ASF:s Kestrel http-server tillsammans med andra IPC-relaterade inställningar. Om du inte har ett särskilt behov, finns det ingen anledning för dig att använda denna fil, som ASF redan använder förnuftiga standardvärden i detta fall.

Konfigurationsfilen är baserad på följande JSON-struktur:

```json
{
    "Kestrel": {
        "Endpoint": {
            "example-http4": {
                "Url": "http://127. .0. :1242"
            },
            "exempel-http6": {
                "Url": "http://[::1]:1242"
            },
            "exempel-https4": {
                "Url": "https://127. .0.1:1242",
                "Certificate": {
                    "Path": "/path/to/certificate. fx",
                    "Lösenord": "passwordToPfxFileAbove"
                }
            },
            "exempel-https6": {
                "Url": "https://[::1]:1242",
                "Certificate": {
                    "Path": "/path/to/certificate. fx",
                    "Lösenord": "passwordToPfxFileAbove"
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

`Endpoints` - Detta är en samling slutpunkter, varje slutpunkt har sitt eget unika namn (som `exempel-http4`) och `Url` egenskap som anger `Protocol://Host:Port` lyssningsadress. Som standard lyssnar ASF på IPv4 och IPv6 http adresser, men vi har lagt till https exempel som du kan använda om det behövs. Du bör bara deklarera de slutpunkter som du behöver, vi har inkluderat 4 exempel ovan så att du kan redigera dem lättare.

`Host` accepterar antingen `localhost`, en fast IP-adress för gränssnittet som det ska lyssna på (IPv4/IPv6), eller `*` värde som binder ASFs http-server till alla tillgängliga gränssnitt. Använda andra värden som `mydomain.com` eller `192.168.0.` fungerar på samma sätt som `*`, det finns ingen IP-filtrering genomförd, var därför extremt försiktig när du använder `Värd` värden som tillåter fjärråtkomst. Detta kommer att möjliggöra åtkomst till ASF:s IPC-gränssnitt från andra maskiner, vilket kan innebära en säkerhetsrisk. Vi rekommenderar starkt att använda `IPCPassword` (och helst din egen brandvägg också) **till ett minimum** i detta fall.

`KnownNetworks` - Denna **valfria** -variabel anger nätverksadresser som vi anser vara pålitliga. Som standard är ASF konfigurerad att lita på loopback-gränssnitt (`localhost`, samma maskin) **endast**. Denna fastighet används på två sätt. För det första, om du utelämnar `IPCPassword`, då tillåter vi endast maskiner från kända nätverk att komma åt ASFs API, och förneka alla andra som en säkerhetsåtgärd. För det andra är denna egendom avgörande när det gäller att omvända ombud tillgång till ASF, som ASF kommer att hedra sina huvuden endast om reverse-proxy servern är inifrån kända nätverk. Att hedra rubrikerna är avgörande när det gäller ASF:s anti-bruteforce mekanism, eftersom det i stället för att förbjuda omvänd proxy vid ett problem, det kommer att förbjuda IP som anges av omvänd proxy som källan till det ursprungliga meddelandet. Var mycket försiktig med de nätverk du anger här, eftersom det tillåter en potentiell IP-förfalskning attack och obehörig åtkomst om den betrodda maskinen äventyras eller felaktigt konfigureras.

`PathBase` - Detta är **valfri** bassökväg som kommer att användas av IPC-gränssnitt. Standardvärdet för `/` och bör inte krävas för att ändra för de flesta användningsfall. Genom att ändra den här egenskapen kommer du att vara värd för hela IPC-gränssnittet på ett anpassat prefix, till exempel `http://localhost:1242/MyPrefix` istället för `http://localhost:1242` ensam. Använda anpassad `PathBase` kan önskas i kombination med en specifik inställning av en omvänd proxy där du bara vill proxy en specifik URL till exempel `mydomain. om/ASF` istället för hela `mydomain.com` domän. Normalt skulle det kräva av dig att skriva en omskrivningsregel för din webbserver som skulle kartlägga `mydomain. om/ASF/Api/X` -> `localhost:1242/Api/X`, men istället kan du definiera en anpassad `PathBase` av `/ASF` och uppnå enklare installation av `mydomain. om/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

Om du inte verkligen behöver ange en anpassad bas sökväg, är det bäst att lämna det som standard.

## Exempel på konfigurationer

### Ändrar standardport

Följande konfiguration ändrar helt enkelt standard ASF lyssnande port från `1242` till `1337`. Du kan välja vilken port du vill, men vi rekommenderar `1024-32767` sortiment, som andra portar är typiskt **[registrerade](https://en.wikipedia.org/wiki/Registered_port)**, och kan till exempel kräva `root` åtkomst på Linux.

```json
{
    "Kestrel": {
        "Endpoint": {
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

### Aktivera åtkomst från alla IP-adresser

Följande konfiguration ger fjärråtkomst från alla källor, därför bör du **se till att du läser och förstår vårt säkerhetsmeddelande om att**, som finns ovan.

```json
{
    "Kestrel": {
        "Endpoint": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Om du inte behöver åtkomst från alla källor, men till exempel ditt LAN endast, då är det mycket bättre att kontrollera den lokala IP-adressen för maskinvärd ASF, till exempel `192. 68.0.10` och använd den istället för `*` i exempelkonfigurationen ovan. Tyvärr är det bara möjligt om din LAN-adress alltid är densamma, som annars kommer du förmodligen få mer tillfredsställande resultat med `*` och din egen brandvägg ovanpå det som tillåter endast lokala undernät att komma åt ASF:s hamn.

---

# Autentisering

ASF IPC-gränssnitt som standard kräver ingen form av autentisering, eftersom `IPCPassword` är satt till `null`. Men om `IPCPassword` är aktiverat genom att vara satt till något icke-tomt värde, varje samtal till ASFs API kräver lösenordet som matchar set `IPCPassword`. Om du utelämnar autentisering eller inmatar fel lösenord, får du `401 - Obehörigt` fel. Efter 5 misslyckade autentiseringsförsök (fel lösenord) blockeras du tillfälligt med `403 - Förbjudna` fel.

Autentisering kan göras på två separata sätt.

## `Autentisering` header

I allmänhet bör du använda **[HTTP-förfrågningshuvuden](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)**, genom att ställa in `Autentisering` med ditt lösenord som värde. Sättet att göra det beror på vilket verktyg du använder för att komma åt ASF:s IPC-gränssnitt, till exempel om du använder `curl` så bör du lägga till `-H 'Authentication: MyPassword'` som en parameter. Detta sätt autentisering skickas i rubrikerna på begäran, där det i själva verket bör ske.

## `lösenord` parameter i frågesträng

Alternativt kan du lägga till `lösenord` i slutet av URL:en du ska ringa, till exempel genom att ringa `/Api/ASF? assword=MyPassword` istället för `/Api/ASF` ensam. Detta tillvägagångssätt är tillräckligt bra, men uppenbarligen avslöjar det lösenord i det öppna, vilket inte nödvändigtvis är lämpligt. Förutom att det är extra argument i frågesträngen, vilket komplicerar utseendet på URL:en och gör att det känns som om det är URL-specifikt, medan lösenordet gäller för hela ASF API-kommunikation.

---

Båda sätten stöds och det är helt upp till dig vilken du vill välja. Vi rekommenderar att använda HTTP-rubriker överallt där du kan, eftersom användning-klokt är det lämpligare än frågesträngar. Vi stöder dock även frågesträng på grund av olika begränsningar relaterade till förfrågningsrubriker. Ett bra exempel är brist på anpassade rubriker vid initiering av en websocket-anslutning i javascript (även om det är helt giltigt enligt RFC). I denna situation frågesträng är det enda sättet att autentisera.

---

# Swagger dokumentation

Vårt IPC-gränssnitt, i tillägg till ASF API och ASF-ui innehåller också swagger dokumentation, som är tillgänglig under `/swagger` **[URL](http://localhost:1242/swagger)**. Swagger dokumentationen fungerar som en mellanhand mellan vår API-implementering och andra verktyg som använder den (t.ex. ASF-ui). Det ger en fullständig dokumentation och tillgänglighet av alla API-slutpunkter i **[OpenAPI](https://swagger.io/resources/open-api)** specifikation som lätt kan konsumeras av andra projekt, låter dig skriva och testa ASF API med lätthet.

Förutom att använda vår swagger dokumentation som en fullständig specifikation av ASF API, du kan också använda det som användarvänligt sätt att utföra olika API slutpunkter, främst de som inte implementeras av ASF-ui. Eftersom vår swagger dokumentation genereras automatiskt från ASF-kod, du har en garanti för att dokumentationen alltid kommer att vara uppdaterad med API-slutpunkterna som din version av ASF inkluderar.

![Swagger dokumentation](https://github.com/user-attachments/assets/ce998e08-f5db-46b0-a9e8-e6b69abd94bb)


---

# Vanliga frågor

### Är ASF:s IPC-gränssnitt säkert och säkert att använda?

ASF lyssnar som standard endast på `localhost` adresser, vilket innebär att tillgång till ASF IPC från någon annan maskin men din egen **är omöjligt**. Om du inte ändrar standard slutpunkter, skulle angriparen behöva en direkt tillgång till din egen maskin för att komma åt ASFs IPC, därför är det så säkert som det kan vara och det finns ingen möjlighet för någon annan att komma åt det, även från ditt eget LAN.

Men om du väljer att ändra standard `localhost` binder adresser till något annat, då ska du ställa in ordentliga brandväggsregler **själv** för att tillåta endast auktoriserade IP-adresser att komma åt ASF:s IPC-gränssnitt. Förutom att göra det, måste du ställa in `IPCPassword`, som ASF vägrar att låta andra maskiner komma åt ASF API utan en, vilket ger ytterligare ett lager av extra säkerhet. Du kanske också vill köra ASF IPC-gränssnitt bakom en omvänd proxy i detta fall, vilket ytterligare förklaras nedan.

### Kan jag komma åt ASF API via mina egna verktyg eller användarskript?

Ja, detta är vad ASF API har utformats för och du kan använda vad som helst som kan skicka en HTTP-begäran för att komma åt den. Lokala användarskript följer **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** logik, och vi tillåter åtkomst från alla ursprung för dem (`*`), så länge `IPCPassword` är satt, som en extra säkerhetsåtgärd. Detta gör att du kan köra olika autentiserade ASF API-förfrågningar, utan att tillåta potentiellt skadliga skript att göra det automatiskt (som de skulle behöva veta ditt `IPCPassword` för att göra det).

### Kan jag komma åt ASF:s IPC på distans, t.ex. från en annan maskin?

Ja, vi rekommenderar att använda en omvänd proxy för det. På så sätt kan du komma åt din webbserver på ett typiskt sätt, som sedan kommer åt ASF:s IPC på samma maskin. Alternativt, om du inte vill köra med en omvänd proxy, kan du använda **[anpassad konfiguration](#enabling-access-from-all-ips)** med lämplig URL för det. Till exempel, om din maskin är i ett VPN med `10.8.0.1` adress, då kan du ställa in `http://10.8.0. :1242` lyssnings-URL i IPC-konfigurationen, vilket skulle aktivera IPC-åtkomst från ditt privata VPN, men inte från någon annanstans.

### Kan jag använda ASFs IPC bakom en omvänd proxy som Apache eller Nginx?

**Ja**, vår IPC är fullt kompatibel med sådana inställningar, så du är fri att vara värd för det också framför dina egna verktyg för extra säkerhet och kompatibilitet, om du vill. Generellt ASF:s Kestrel http-server är mycket säker och har ingen risk när den är ansluten direkt till internet, men att lägga det bakom en omvänd proxy som Apache eller Nginx kan ge extra funktionalitet som inte skulle vara möjligt att uppnå annars, såsom att säkra ASFs gränssnitt med en **[grundläggande auth](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Exempel Nginx konfiguration kan hittas nedan. Vi har inkluderat hela `server` blocket, även om du är intresserad huvudsakligen av `plats`. Se **[nginx dokumentation](https://nginx.org/en/docs)** om du behöver ytterligare förklaring.

```nginx
server {
    listen *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /path/to/your/fullchain. em;
    ssl_certificate_key /path/to/your/privkey. em;

    plats ~* /Api/NLog {
        proxy_pass http://127.0.0. :1242

        # Endast om du behöver åsidosätta standardvärden
# proxy_set_header Host 127. .0. ;

        # X-headers bör alltid anges när proxying förfrågningar till ASF
        # De är avgörande för korrekt identifiering av original IP, tillåter ASF att t.ex. bannlysa faktiska brottslingar istället för din nginx-server
        # Att ange dem gör det möjligt för ASF att korrekt lösa IP-adresser för användare som gör förfrågningar - vilket gör att nginx fungerar som en omvänd proxy
        # Att inte specificera dem kommer att orsaka ASF att behandla din nginx som klient - nginx kommer att fungera som en traditionell proxy i detta fall
        # Om du inte kan vara värd för nginx-tjänst på samma maskin som ASF, du troligen vill ställa in KnownNetworks på lämpligt sätt utöver de
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;

        # Vi lägger till dessa 3 extra alternativ för websockets proxying, se https://nginx. rg/sv/docs/http/websocket.html
        proxy_http_version 1. ;
        proxy_set_header Connection "Upgrade";
        proxy_set_header Uppgradering $http_upgrade
    }

    plats / {
        proxy_pass http://127. .0. :1242

        # Endast om du behöver åsidosätta standardvärden
# proxy_set_header Host 127. .0. ;

        # X-headers bör alltid anges när proxying förfrågningar till ASF
        # De är avgörande för korrekt identifiering av original IP, tillåter ASF att t.ex. bannlysa faktiska brottslingar istället för din nginx-server
        # Att ange dem gör det möjligt för ASF att korrekt lösa IP-adresser för användare som gör förfrågningar - vilket gör att nginx fungerar som en omvänd proxy
        # Att inte specificera dem kommer att orsaka ASF att behandla din nginx som klient - nginx kommer att fungera som en traditionell proxy i detta fall
        # Om du inte kan vara värd för nginx-tjänst på samma maskin som ASF, du sannolikt vill ställa in KnownNetworks på lämpligt sätt utöver de
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
    }
}
```

Exempel Apache konfiguration kan hittas nedan. Se **[apache dokumentation](https://httpd.apache.org/docs)** om du behöver ytterligare förklaring.

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        Servernamn asf.mydomain. Om

        SSLEngine På
        SSLCertificateFile /path/to/your/fullchain. em
        SSLCertificateKeyFile /path/to/din/privkey. em

        # TODO: Apache kan inte göra skiftlägesokänslig matchning korrekt, så vi hårdkod två vanligaste fallen
        ProxyPass "/api/nlog" "ws://127. .0. :1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0. :1242/Api/NLog"

        ProxyPass "/" "http://127.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### Kan jag komma åt IPC-gränssnitt via HTTPS-protokollet?

**Ja**, du kan uppnå det på två olika sätt. Ett rekommenderat sätt skulle vara att använda en omvänd proxy för det, där du kan komma åt din webbserver via https som vanligt, och ansluta genom den med ASFs IPC-gränssnitt på samma maskin. På så sätt är din trafik helt krypterad och du behöver inte ändra IPC på något sätt för att stödja sådana inställningar.

Andra sättet inkluderar att ange en **[anpassad konfiguration](#custom-configuration)** för ASFs IPC-gränssnitt där du kan aktivera https slutpunkt och tillhandahålla lämpligt certifikat direkt till vår Kestrel http-server. Detta sätt rekommenderas om du inte kör någon annan webbserver och inte vill köra en exklusivt för ASF. Annars är det mycket lättare att uppnå en tillfredsställande installation genom att använda en omvänd proxymekanism.

---

### Under start av IPC Jag får ett fel: `System.IO. OException: Det gick inte att binda till adress, Ett försök gjordes att komma åt en socket på ett sätt som är förbjudet av dess åtkomstbehörigheter`

Detta fel indikerar att något annat på din maskin antingen redan använder den porten eller reserverade den för framtida användning. Detta kan vara du om du försöker köra andra ASF instans på samma maskin, men oftast är det Windows exklusive port `1242` från din användning, därför måste du flytta ASF till en annan port. För att göra det, följ **[exempel config](#changing-default-port)** ovan, och helt enkelt försöka plocka en annan port, som `12420`.

Naturligtvis kan du också försöka ta reda på vad som blockerar port `1242` från ASF användning, och ta bort det, men det är oftast mycket mer besvärligt än att bara instruera ASF att använda en annan port, så vi hoppar över att utveckla vidare på det här.

---

### Varför får jag `403 Förbjudna` fel när jag inte använder `IPCPassword`?

ASF innehåller ytterligare säkerhetsåtgärd som som standard tillåter endast loopback-gränssnitt (`localhost`, din egen maskin) för att komma åt ASF API utan `IPCPassword` inställd i konfigurationen. Detta beror på att användningen av `IPCPassword` bör vara en **minsta** säkerhetsåtgärd som sätts av alla som väljer att exponera ASF-gränssnittet ytterligare.

Förändringen dikterades av det faktum att massiv mängd ASFs värd globalt av omedvetna användare togs över för skadliga avsikter, Vanligtvis lämnar människor utan konton och utan poster på dem. Nu skulle vi kunna säga "de kunde läsa denna sida innan de öppnade ASF för hela världen", men i stället är det mer meningsfullt att inte tillåta osäkra ASF-inställningar som standard, och kräver av användarna en åtgärd om de uttryckligen vill tillåta det, som vi utarbetar om nedan.

I synnerhet kan du åsidosätta vårt beslut genom att ange de nätverk som du litar på att nå ASF utan att `IPCPassword` anges, du kan ställa in egenskapen `KnownNetworks` i anpassad konfiguration. Men om du inte **verkligen** vet vad du gör och till fullo förstår riskerna, du bör istället använda `IPCPassword` som deklarera `KnownNetworks` kommer att tillåta alla från dessa nätverk att få tillgång till ASF API villkorslöst. Vi är allvarliga, människor redan skjuta sig själva i foten tro sina omvända ombud och iptables regler var säkra, men de var inte det, `IPCPassword` är den första och ibland den sista väktaren, Om du väljer att välja bort denna enkla, men ändå mycket effektiva och säkra mekanism, du har bara dig själv att skylla.