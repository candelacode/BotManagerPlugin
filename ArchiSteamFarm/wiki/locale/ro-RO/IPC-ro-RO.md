# IPC

ASF include propria sa interfață IPC care poate fi utilizată pentru interacțiunea suplimentară cu procesul. IPC înseamnă **[comunicație între procese](https://en.wikipedia.org/wiki/Inter-process_communication)** și, în cea mai simplă definiție, aceasta este "interfața web ASF" bazată pe **[serverul HTTP Kestrel](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel)** care poate fi utilizată pentru integrarea ulterioară cu procesul, atât ca frontend pentru utilizatorul final (ASF-ui), cât și ca backend pentru integrări de terță parte (API-ul ASF).

IPC poate fi folosit pentru o mulțime de lucruri diferite, în funcție de nevoile și abilitățile tale. De exemplu, o poți folosi pentru preluarea statusului ASF și al tuturor roboților, trimițând comenzi ASF, preluarea și editarea configurațiilor globale/bot, adăugarea de boți noi, ștergerea boților existenți, trimiterea de chei pentru **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** sau accesarea fișierului jurnal al ASF. Toate aceste acţiuni sunt expuse de API-ul nostru, ceea ce înseamnă că poți programa propriile unelte și scripturi care vor putea comunica cu ASF și să îl influențeze în timpul rulării. În plus, acțiunile selectate (cum ar fi comenzile de trimitere) sunt, de asemenea, implementate de ASF-ui care vă permite să le accesați cu ușurință printr-o interfață web prietenoasă.

---

# Utilizare

Cu excepția cazului în care ai dezactivat manual IPC prin `IPC` **[proprietatea de configurare globală](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, aceasta este activată implicit. ASF va afișa lansarea IPC în jurnalul său, pe care îl puteți utiliza pentru a verifica dacă interfața IPC a pornit corect:

```text
NFO|ASF|Start() Starting IPC server...
INFO|ASF|Start() IPC server ready!
```

Serverul web ASF ascultă acum pe interfețele selectate. Dacă nu ați furnizat un fișier de configurare personalizat pentru IPC, va fi `localhost`, ambele bazate pe IPv4 **[127. .0.1](http://127.0.0.1:1242)** şi IPv6 **[[:1]](http://[::1]:1242)** pe portul `1242`. Poți accesa interfața noastră IPC prin link-uri de mai sus, dar numai de la aceeași mașinărie ca și cea care rulează ASF.

Interfața IPC a ASF expune trei moduri diferite de a o accesa, în funcție de utilizarea planificată.

La cel mai scăzut nivel există **[ASF API](#asf-api)** care este nucleul interfeței noastre IPC și permite tuturor celorlalte să funcționeze. Asta este ceea ce vrei să folosești în uneltele tale, utilitățile și proiectele tale pentru a comunica direct cu ASF.

Pe teren mediu există **[Documentația noastră de Swagger](#swagger-documentation)** care acționează ca un frontend la ASF API. Include o documentație completă pentru ASF API și, de asemenea, vă permite să o accesați mai ușor. Acesta este lucrul pe care vrei să-l verifici dacă plănuiești să scrii un instrument, utilitar sau alte proiecte care urmează să comunice cu ASF prin API-ul său.

La cel mai înalt nivel se află **[ASF-ui](#asf-ui)**, care se bazează pe API-ul nostru ASF și oferă o modalitate prietenoasă cu utilizatorul de a executa diverse acțiuni ASF. Aceasta este interfața noastră IPC implicită, concepută pentru utilizatori finali, și un exemplu perfect de ce poți construi cu API-ul ASF. Dacă dorești, poți folosi propria ta interfață web personalizată pentru a o utiliza cu ASF, specificând `--path` **[argumentul de linie de comandă](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** și folosind directorul personalizat `www` situat acolo.

---

# ASF-ui

ASF-ui este un proiect comunitar care urmărește să creeze o interfață web grafică ușor de utilizat pentru utilizatorii finali. Pentru a realiza acest lucru, acționează ca un frontend pentru **[API-ul ASF](#asf-api)**, permițându-ți să efectuezi diverse acțiuni cu ușurință. Aceasta este interfața implicită cu care vine ASF.

Așa cum s-a menționat mai sus, ASF-ui este un proiect al comunității care nu este întreținut de dezvoltatorii principali ai ASF. Urmărește propriul său flux în **[repo-ul ASF-ui](https://github.com/JustArchiNET/ASF-ui)**, care ar trebui folosit pentru toate întrebările, problemele, rapoartele de erori și sugestiile legate de acesta.

Poți folosi ASF-ui pentru gestionarea generală a procesului ASF. Permite, de exemplu, gestionarea boților, modificarea setărilor, trimiterea de comenzi și realizarea altor funcționalități selectate, disponibile în mod normal prin ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

API-ul nostru ASF este un API web tipic **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)**, care se bazează pe JSON ca format principal de date. Facem tot posibilul să descriem precis răspunsul, folosind atât coduri de stare HTTP (acolo unde este cazul), cât și un răspuns pe care îl poți analiza pentru a ști dacă cererea a avut succes și, dacă nu, de ce.

API-ul nostru ASF poate fi accesat trimițând cereri corespunzătoare către punctele de acces `/Api` adecvate. Poți utiliza aceste puncte de acces API pentru a-ți crea propriile scripturi de ajutor, unelte, interfețe grafice și altele similare. Exact acest lucru realizează ASF-ui în spatele scenei, iar orice alt instrument poate realiza același lucru. API-ul ASF este oficial susținut și întreținut de echipa principală ASF.

Pentru documentația completă a punctelor de acces disponibile, descrierilor, cererilor, răspunsurilor, codurilor de stare HTTP și a tuturor celorlalte informații referitoare la API-ul ASF, te rugăm să consulți **[documentația noastră Swagger](#swagger-documentation)**.

![ASF API](https://github.com/user-attachments/assets/08c3d4ad-ea77-403d-a18a-b75c3d0a3097)


---

# Configurație personalizată

Our IPC interface supports extra config file, `IPC.config` that should be put in standard ASF's `config` directory.

Atunci când este disponibil, acest fișier specifică configurația avansată a serverului http Kestrel al ASF, împreună cu alte ajustări legate de IPC. Dacă nu ai o anumită nevoie, nu există niciun motiv să folosești acest fișier, ca ASF deja utilizează valori implicite rezonabile în acest caz.

Fișierul de configurare se bazează pe următoarea structură JSON:

```json
{
    "Kestrel": {
        "Endpoints": {
            "example-http4": {
                "Url": "http://127. .0. :1242"
            },
            "example-http6": {
                "Url": "http://[:1]:1242"
            },
            "exemplu" 4": {
                "Url": "https://127. .0.1:1242",
                "Certificate": {
                    "Cale": "/path/to/certificate. fx",
                    "Parolă": "passwordToPfxFileAbove"
                }
            },
            "exemplu" 6": {
                "Url": "https://[:1]:1242",
                "Certificate": {
                    "Cale": "/path/to/certificate. fx",
                    "Parolă": "passwordToPfxFileAbove"
                }
            }
        },
        "Reţele de ştiinţă": [
            "10. .0.0/8",
            "172.16.0. /12",
            "192.168.0. /16"
        ],
        "PathBase": "/"
    }
}
```

`Puncte finale` - Aceasta este o colecție de puncte finale, fiecare obiectiv având propriul său nume unic (cum ar fi `exemplu-http4`) și proprietatea `Url` care specifică adresa de ascultare `Protocol://Host:Port`. În mod implicit, ASF ascultă adrese de http IPv4 şi IPv6, dar am adăugat exemple https pentru a le folosi, dacă este necesar. Ar trebui să declarați doar acele criterii finale de care aveți nevoie, am inclus 4 exemple de mai sus pentru a le putea edita mai ușor.

`Gazda` acceptă fie `localhost`, o adresă IP fixă a interfeței pe care ar trebui să o asculte (IPv4/IPv6), sau `* Valoarea` care se leagă de serverul http al ASF la toate interfețele disponibile. Folosind alte valori precum `mydomain.com` sau `192.168.0.` acționează la fel ca `*`, nu este implementată nicio filtrare IP, de aceea fiți extrem de atenți când utilizați valori `Găzduiește` care permit accesul la distanță. Acest lucru va permite accesul la interfața IPC a ASF de la alte mașini, ceea ce poate prezenta un risc de securitate. Vă recomandăm insistent să utilizați `IPCPassword` (și, de preferință, propriul firewall) **minim** în acest caz.

`Cunoştinţele` - Aceasta variabila **opţională** specifică adresele de reţea pe care le considerăm demne de încredere. În mod implicit, ASF este configurat să aibă încredere în interfața loopback (`localhost`, aceeași mașină) **doar**. Această proprietate este utilizată în două moduri. În primul rând, dacă omiți `IPCPassword`, apoi vom permite doar maşinilor de la reţelele cunoscute să acceseze API-ul ASF şi să nege tuturor celorlalţi ca măsură de securitate. În al doilea rând, această proprietate este esențială în ceea ce privește accesarea invers a ASF, ca ASF își va onora antetele numai dacă serverul proxy-reverse-proxy este din rețelele cunoscute. Respectarea capetelor este esențială în ceea ce privește mecanismul anti-brutal al ASF, în loc să interzicem inversarea voturilor în cazul unei probleme; va interzice IP-ul specificat de proxy ca sursă a mesajului original. Fiți extrem de atenți cu rețelele pe care le specificați aici, deoarece permite un potențial atac care lovește un IP și acces neautorizat în cazul în care aparatul de încredere este compromis sau configurat în mod eronat.

`PathBase` - Aceasta este calea **opţională** care va fi folosită de interfaţa IPC. Modul implicit este `/` și nu ar trebui să fie necesar să se modifice pentru majoritatea cazurilor de utilizare. Prin schimbarea acestei proprietăți veți găzdui întreaga interfață IPC pe un prefix personalizat, de exemplu `http://localhost:1242/MyPrefix` în loc de `http://localhost:1242` în mod individual. Folosind particularizarea `PathBase` poate fi căutată în combinație cu configurarea specifică a unui proxy invers, unde doriți să proxy-ul doar pentru un anumit URL, de exemplu `mydomain. om/ASF` în loc de domeniul `` în total. În mod normal acest lucru ar necesita din partea ta să scrii o regulă de rescriere pentru serverul tău web care ar harta `mydomain. om/ASF/Api/X` -> `localhost:1242/Api/X`, dar în schimb puteţi defini un custom `PathBase` din `/ASF` şi obţineţi o configurare mai uşoară a numelui `. om/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

Dacă nu ai cu adevărat nevoie să specifici o bază personalizată, este cel mai bine să o lași în mod implicit.

## Exemplu configurări

### Schimbarea portului implicit

Următoarea configurație pur și simplu schimbă portul ASF de ascultare de la `1242` la `1337`. Poți alege orice port dorești, dar îți recomandăm clasa `1024-32767` , ca și cum alte porturi sunt de obicei **[înregistrate](https://en.wikipedia.org/wiki/Registered_port)**, și poate necesita, de exemplu, accesul `root` pe Linux.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP4": {
                "Url": "http://127. .0. :1337"
            },
            "HTTP6": {
                "Url": "http://[:1]:1337"
            }
        }
    }
}
```

---

### Activarea accesului de la toate IP-urile

The following config will allow remote access from all sources, therefore you should **ensure that you read and understood our security notice about that**, available above.

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

Dacă nu aveți nevoie de acces din toate sursele, dar de exemplu doar pentru LAN-ul dvs., apoi este o idee mult mai bună să verifici adresa IP locală a aparatului care găzduiește ASF, de exemplu `192. 68.0.10` şi folosiţi-l în loc de `*` în exemplu de configurare de mai sus. Din păcate, acest lucru este posibil doar dacă adresa ta de LAN este întotdeauna aceeași, cu alte cuvinte, probabil vei avea mai multe rezultate satisfăcătoare cu `*` și propriul tău firewall peste care permite doar subsetelor locale să acceseze portul ASF.

---

# Autentificare

Interfața IPC ASF în mod implicit nu necesită niciun fel de autentificare, deoarece `IPCPassword` este setat la `null`. Cu toate acestea, dacă `IPCPassword` este activat prin setarea la orice valoare non-goală, fiecare apel la API-ul ASF necesită parola care corespunde setării `IPCPassword`. Dacă omiteți autentificarea sau introduceți o parolă greșită, veți obține o eroare de tip `401 - neautorizată`. După 5 încercări eșuate de autentificare (parolă greșită), veți fi blocat temporar cu `403 - Eroare Forbidden`.

Autentificarea se poate face în două moduri separate.

## `Antet autentificare`

În general, ar trebui să utilizați câmpul **[HTTP solicitare headers](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)**, prin setarea `Authentication` cu parola ca valoare. Modul de a face asta depinde de instrumentul pe care îl folosești pentru accesarea interfeței IPC a ASF, de exemplu, dacă folosești `curl` , atunci ar trebui să adaugi `-H 'Autentificare: MyPassword'` ca parametru. În acest mod, autentificarea este transmisă în antetul cererii, în cazul în care aceasta ar trebui să aibă loc de fapt.

## `parola` parametrul în şir de interogare

Alternativ, puteți adăuga parametrul `parola` la sfârșitul adresei URL pe care o veți apela, De exemplu, apelând `/Api/ASF? assword=MyPassword` în loc de `/Api/ASF` singur. Această abordare este destul de bună, dar în mod evident expune parola deschisă, ceea ce nu este neapărat întotdeauna adecvat. În plus, este un argument suplimentar în șirul de interogări, care complică aspectul URL-ului și îl face să simtă că este specific URL-ului, în timp ce parola se aplică întregii comunicări ASF API.

---

Ambele moduri sunt sprijinite şi depinde în totalitate de tine pe care vrei să le alegi. Vă recomandăm să utilizaţi antetele HTTP oriunde puteţi, deoarece este mai potrivit decât şirul de interogare. Cu toate acestea, susținem, de asemenea, seria de interogări, în principal din cauza diferitelor limitări legate de antetul cererii. Un bun exemplu include lipsa unor antete personalizate în timpul inițierii unei conexiuni websocket în javascript (chiar dacă este complet valabilă conform RFC). În această situaţie, şirul de interogare este singura cale de autentificare.

---

# Documentație Swagger

Interfața noastră IPC, additon to ASF API și ASF-ui include, de asemenea, documentația swaggerului, care este disponibil sub `/swagger` **[URL-ul](http://localhost:1242/swagger)**. Documentația Swagger servește ca intermediar între implementarea API-ului nostru și alte instrumente care o folosesc (de ex. ASF-ui). Oferă o documentație completă și disponibilitatea tuturor criteriilor API finale în **[specificație OpenAPI](https://swagger.io/resources/open-api)** care poate fi ușor consumată în alte proiecte, permite scrierea și testarea ASF API cu ușurință.

În afară de utilizarea documentației noastre referitoare la swagger ca specificație completă a ASF API, o poți folosi, de asemenea, ca un mod ușor de utilizat pentru a executa diverse obiective API, în principal acelea care nu sunt implementate de ASF-ui. Deoarece documentația noastră de balon este generată automat din codul ASF, aveți o garanție că documentația va fi întotdeauna actualizată cu criteriile API incluse în versiunea dumneavoastră de ASF.

![Documentație Swagger](https://github.com/user-attachments/assets/ce998e08-f5db-46b0-a9e8-e6b69abd94bb)


---

# Întrebări frecvente

### Este interfața IPC a ASF sigură și sigură de utilizat?

ASF în mod implicit ascultă doar pe adresele `localhost` , ceea ce înseamnă că accesarea ASF IPC de pe orice altă mașină, dar **dumneavoastră propriu este imposibil**. Dacă nu modificați criteriile de evaluare standard, atacatorul are nevoie de acces direct la propria mașină pentru a accesa IPC a ASF, de aceea este cât se poate de sigur şi nu există posibilitatea ca altcineva să-l acceseze, nici măcar din propria ta LAN.

However, if you decide to change default `localhost` bind addresses to something else, then you're supposed to set proper firewall rules **yourself** in order to allow only authorized IPs to access ASF's IPC interface. În plus față de asta, va trebui să configurați `IPCPassword`, ca ASF va refuza accesul altor mașini la ASF API fără unul, ceea ce adaugă un alt strat de securitate suplimentară. S-ar putea să doriți să rulați interfața IPC a ASF în spatele unui proxy invers în acest caz, ceea ce este explicat mai jos.

### Pot accesa ASF API prin propriile instrumente sau utilizatori?

Da, pentru aceasta a fost creat API-ul ASF și puteți folosi orice capabil să trimită o cerere HTTP pentru a o accesa. Utilizatorii locali urmăresc **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** logic, și permitem accesul de la toate originile pentru ele (`*`), atâta timp cât `IPCPassword` este stabilit, ca măsură suplimentară de securitate. This allows you to execute various authenticated ASF API requests, without allowing potentially malicious scripts to do that automatically (as they'd need to know your `IPCPassword` to do that).

### Pot accesa IPC al ASF de la distanță, de ex. de pe altă mașinărie?

Da, îți recomandăm să folosești un proxy invers. În acest fel îți poți accesa serverul web în mod tipic, care va accesa IPC al ASF pe aceeași mașină. Alternativ, dacă nu vrei să rulezi cu un proxy invers, poți folosi **[configurație personalizată](#enabling-access-from-all-ips)** cu o adresă URL adecvată pentru aceasta. De exemplu, dacă maşinăria ta este într-un VPN cu adresa `10.8.0.1` , atunci poţi seta `http://10.8.0. :1242` ascultarea adresei URL în configurarea IPC, care ar permite accesul IPC din VPN privat, dar nu de nicăieri.

### Pot folosi IPC al ASF în spatele unui proxy invers cum ar fi Apache sau Nginx?

**Da**, IPC nostru este pe deplin compatibil cu o astfel de configurare, așa că sunteți liber să-l găzduiți și în fața propriilor instrumente pentru securitate și compatibilitate în plus, dacă doriți. În general, serverul Http al ASF este foarte sigur și nu prezintă niciun risc atunci când este conectat direct la internet, dar punerea lui în spatele unui proxy cum ar fi Apache sau Nginx ar putea oferi funcţionalitate suplimentară care nu ar fi posibilă pentru a realiza altfel, cum ar fi securizarea interfeței ASF cu un **[bază auth](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Exemplu de configurare Nginx poate fi găsit mai jos. Am inclus blocul `complet` , deşi sunteţi interesat în principal de cele de la `locaţia`. Vă rugăm să consultaţi **[documentaţia nginx](https://nginx.org/en/docs)** dacă aveţi nevoie de explicaţii suplimentare.

```nginx
server {
    ascultă *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certific/path/to/your/fullchain. em;
    ssl_certificate_key /path/to/your/privkey. em;

    locația ~* /Api/NLog {
        proxy_pass http://127.0.0. :1242;

        # Numai dacă ai nevoie să suprascrii gazda implicită
# proxy_set_header Host 127. .0. ;

        # X-headers ar trebui să fie specificat întotdeauna când cererile proxing pentru ASF
        # Sunt cruciale pentru identificarea corectă a IP-ului original, permiterea ASF de ex. interzice contravenienții reali în locul serverului tău nginx
        # Specificarea lor permite ASF să rezolve corect adresele IP ale utilizatorilor care solicită cereri - făcând nginx ca un proxy invers
        # Nu specificarea lor va determina ASF să trateze nginxul ca client - nginx va acționa ca un proxy tradițional în acest caz
        # Dacă nu poți găzdui serviciul nginx pe aceeași mașină ca ASF, cel mai probabil doriți să setați Științe în mod corespunzător, în plus față de cele
        proxy_set_header X-Forwarded-Pentru $proxy_add_x_forwarded_for
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;

        # Adăugăm cele 3 opţiuni suplimentare pentru proxying-ul websockes, a se vedea https://nginx. rg/ro/documente/http/websocket.html
        proxy_http_versiunea 1. ;
        proxy_set_header Conexiune "Actualizare";
        proxy_set_header Upgradează $http_upgrade
    } Locație

    / {
        proxy_pass http://127. .0. :1242;

        # Doar dacă aveţi nevoie pentru a suprascrie gazda implicită
# proxy_set_header Host 127. .0. ;

        # X-headers ar trebui să fie specificat întotdeauna când cererile proxing pentru ASF
        # sunt cruciale pentru identificarea corectă a IP-ului original, permiterea ASF de ex. interzice contravenienții reali în loc de serverul tău nginx
        # specificarea lor permite ASF să rezolve corect adresele IP ale utilizatorilor care fac cereri - făcând nginx să funcționeze ca un proxy invers
        # Nu specificarea lor va determina ASF să trateze nginxul ca client - nginx va acționa ca un proxy tradițional în acest caz
        # Dacă nu poți găzdui serviciul nginx pe aceeași mașină ca ASF, cel mai probabil vrei să setezi în mod corespunzător KnownNetworks în plus față de cele
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme
        proxy_set_header X-Forwarded-Server $host;
    }
}
```

Exemplu de configurare Apache poate fi găsit mai jos. Vă rugăm să consultaţi **[documentaţia apache](https://httpd.apache.org/docs)** dacă aveţi nevoie de explicaţii suplimentare.

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerName asf.mydomain. om

        SSLEngine On
        SSLCertificateFile /path/to/your/fullchain. eme
        SSLCertificateKeyFile /path/to/your/privkey. em

        # TODO: Apache nu poate face potriviri insensibile la majuscule, aşa că hardcode două dintre cazurile cel mai frecvent folosite de
        ProxyPass "/api/nlog" "ws://127. .0. :1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0. :1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### Pot accesa interfața IPC prin protocolul HTTPS?

**Da**, îl poți realiza prin două moduri diferite. O metodă recomandată ar fi să folosești un proxy invers pentru asta, unde îți poți accesa serverul web prin https like usual, și conectați-vă cu interfața IPC a ASF pe aceeași mașinărie. În acest fel traficul dvs. este complet criptat și nu trebuie să modificați IPC în niciun fel pentru a sprijini o astfel de configurare.

A doua cale include specificarea unei configurări personalizate **[](#custom-configuration)** pentru interfața IPC a ASF unde puteți activa https endpoint și furniza certificatul corespunzător direct serverului nostru Kestrel http. În acest fel este recomandat dacă nu rulați niciun alt server web și nu doriți să rulați unul exclusiv pentru ASF. În caz contrar, este mult mai ușor să se obțină o configurație satisfăcătoare prin utilizarea unui mecanism de invers.

---

### În timpul pornirii IPC primesc o eroare: `System.IO. OExcepție: Nu s-a reușit legarea la adresă, s-a făcut o încercare de a accesa un socket într-un mod interzis de permisiunile sale de acces`

Această eroare indică faptul că altceva de pe aparatul dvs. fie folosește deja acel port, fie îl rezervă pentru uzul viitor. Asta poate fi dacă încerci să rulezi a doua instanță ASF pe aceeași mașinărie, dar cel mai adesea acesta este Windows excluzând portul `1242` din utilizarea dvs., prin urmare va trebui să mutați ASF într-un alt port. Pentru a face acest lucru, urmați **[exemplu config](#changing-default-port)** de mai sus, şi încercaţi pur şi simplu să alegeţi un alt port, cum ar fi `12420`.

Bineînțeles că ai putea încerca să afli ce blochează portul `1242` din utilizarea ASF și să ștergi asta, dar de obicei e mult mai supărător decât să instruim ASF-ul să folosească un alt port, așa că vom trece la detalii.

---

### De ce primesc eroarea `403 Forbidden` atunci când nu folosesc `IPCPassword`?

ASF include o măsură de securitate suplimentară care, în mod implicit, permite doar interfața buclei (`localhost`, propriul calculator) pentru a accesa ASF API fără `IPCPassword` setat în configurare. Acest lucru se datorează faptului că utilizarea `IPCPassword` ar trebui să fie o măsură **minimum** de securitate setată de toți cei care decid să expună mai departe interfața ASF.

Această schimbare a fost dictată de faptul că un număr masiv de ASF-uri găzduite la nivel mondial de utilizatori care nu erau conștienți de acest lucru erau preluate pentru intenții răuvoitoare, de obicei lăsând oamenii fără conturi și fără articole pe ele. Acum am putea spune „ar putea citi această pagină înainte de a deschide ASF întregii lumi”; dar în schimb are mai mult sens să nu permitem implicit configurări ASF nesigure, și să solicite utilizatorilor o acțiune dacă doresc în mod explicit să o permită, despre care noi elaborăm mai jos.

În special, puteți să suprascrieți decizia noastră specificând rețelele de care aveți încredere pentru a ajunge la ASF fără `IPCPassword` specificat, le puteți seta în proprietatea `KnownNetworks` în configurare personalizată. However, unless you **really** know what you're doing and fully understand the risks, you should instead use `IPCPassword` as declaring `KnownNetworks` will allow everybody from those networks to access ASF API unconditionally. Suntem serioși, oamenii se împușcau deja în picior, crezând că regulile lor inverse și iptables erau sigure, dar nu erau, `IPCPassword` este primul şi câteodată ultimul tutore, dacă decizi să renunți la acest mecanism simplu, dar foarte eficient și sigur, nu vei avea decât de vină.