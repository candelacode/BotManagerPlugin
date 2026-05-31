# Docker

ASF este disponibil ca **[recipient docker](https://www.docker.com/what-container)**. Pachetele noastre de andocare sunt disponibile în prezent pe **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** precum şi **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

Este important să rețineți că rularea ASF în containerul Docker este considerată **configurare avansată**, care este **nu are nevoie de** pentru marea majoritate a utilizatorilor și de obicei oferă **niciun avantaj** față de configurarea fără containere. Dacă considerați Docker o soluție pentru rularea ASF ca pe un serviciu, de exemplu făcând ca Docker să înceapă automat cu sistemul de operare, apoi ar trebui să iei în considerare citirea secțiunii **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** în schimb și să setezi un serviciu `corespunzător` care va fi **aproape întotdeauna** o idee mai bună decât rularea ASF într-un container Docker.

Rularea ASF în containerul Docker implică de obicei **mai multe probleme noi și probleme** cu care va trebui să te confrunți și să te rezolvi. This is why we **strongly** recommend you to avoid it unless you already have Docker knowledge and don't need help understanding its internals, about which we won't elaborate here on ASF wiki. Această secțiune se referă în principal la cazuri valide de utilizare a unor structuri foarte complexe. de exemplu în ceea ce privește rețelele avansate sau securitatea dincolo de sandbox-ul standard cu care ASF vine în serviciul `systemd` (care asigură deja izolarea superioară a proceselor prin intermediul mecanicilor de securitate foarte avansate). Pentru acele câteva persoane, aici explicăm concepte ASF mai bune în ceea ce privește compatibilitatea cu Docker, Și doar asta, se presupune că ai cunoștințe adecvate despre Docker dacă decizi să le folosești împreună cu ASF.

---

## Etichete

ASF este disponibil prin mai multe tipuri de **[tag-uri](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `principal`

Construirea generică de ASF care este construită din cea mai recentă comitere în `main` ramură, care funcționează la fel ca și captarea ultimului artefact direct din conducta **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)**. Este cel mai înalt nivel de software bugged dedicat dezvoltatorilor si utilizatorilor avansati in scopuri de dezvoltare. The image is being updated with each commit in the `main` GitHub branch, therefore you can expect very often changes (and stuff being broken). Este aici pentru a marca starea actuală a proiectului ASF, care nu este neapărat garantată a fi stabilă sau testată, aşa cum s-a subliniat în ciclul nostru de eliberare. **Această etichetă nu trebuie folosită în niciun mediu de producție**. Util pentru a verifica dacă anumite comiteri au rezolvat problema cu care te loghezi, fără a aștepta nici măcar o pre-lansare cu acel comitet.


### `lansat`

Construirea generică de ASF care indică întotdeauna cea mai recentă versiune **[lansat](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF, inclusiv pre-releases. Comparativ cu eticheta `principală` , imaginea de aici este actualizată de fiecare dată când un nou tag GitHub este apăsat. Dedicat utilizatorilor avansați/de putere cărora le place să trăiască la marginea a ceea ce poate fi considerat stabil și proaspăt în același timp. În practică, funcționează la fel ca eticheta rulantă care indică cea mai recentă versiune `A.B.C.D` la momentul tragerii. Vă rugăm să reţineţi că utilizarea acestei etichete este egală cu folosirea **[pre-releases](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `stabil`

Construirea generică de ASF care indică întotdeauna cea mai recentă versiune **[stabil](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF. Comparativ cu eticheta `lansat` , imaginea este actualizată de îndată ce o nouă versiune stabilă de ASF este pusă la dispoziție. Recomandat pentru persoanele care caută o variantă stabilă a etichetei `lansat` menționată mai sus.

### `ultima`

Construirea ASF specifică OS, care indică întotdeauna cea mai recentă versiune **[stabil](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF. In comparison with others, this is the **only tag** that includes ASF auto-updates. Obiectivul acestei etichete este de a furniza un container standard pentru Docker care este capabil să ruleze auto-actualizare, un build ASF specific OS. Din această cauză, imaginea nu trebuie actualizată cât mai des posibil, versiunea ASF inclusă va putea întotdeauna să se actualizeze, dacă este necesar.

Desigur, `UpdatePeriod` poate fi oprit în siguranță (setat la `0`), dar în acest caz ar trebui probabil să utilizați o versiune `stabilă`. La fel, puteți modifica `UpdateChannel` implicit pentru a urmări pre-lansările dacă doriți.

Datorită faptului că imaginea `ultimul` vine cu capacitatea de actualizări automate, include bare OS cu `linux` versiunea ASF, contrar tuturor celorlalte tag-uri care includ OS cu . ET rulează și `versiunea generic` ASF. Acest lucru se datorează faptului că o versiune mai nouă (actualizată) ASF ar putea avea nevoie de o execuție mai nouă decât cea cu care ar putea fi construită imaginea, care, în caz contrar, ar necesita reconstruirea unei imagini de la zero, anulând dosarul de utilizare planificat.

### `A.B.C.D`

Construirea generică de ASF care arată către versiunea fixă ASF care corespunde etichetei. În comparație cu etichetele de mai sus, această etichetă este complet înghețată, ceea ce înseamnă că imaginea de aici nu va fi actualizată odată publicată. Asta funcționează similar cu versiunile noastre GitHub care nu sunt niciodată atinse după versiunea inițială, care vă garantează stabilitatea și mediul înghețat. De obicei ar trebui să utilizați acest tag atunci când doriți să utilizați o versiune ASF specifică și să așteptați la rezultatul deterministic al construcției (e. . gestionând versiuni ASF în schimb).

---

## Care etichetă este cea mai bună pentru mine?

Asta depinde de ceea ce cauţi. Pentru majoritatea utilizatorilor, tag-ul `cel mai recent` ar trebui să fie cel mai bun pentru că oferă exact ce face desktop ASF, doar într-un container special pentru Docker ca serviciu. Totuşi, acesta nu este neapărat modul în care să fie folosit dockerul - în mod normal te aştepţi să reconstruieşti containerele şi nu să le rulezi pentru totdeauna, și în acest caz ar trebui să luați în considerare eticheta `stable` sau `lansat` , care urmează ghidul docker. În cele din urmă, dacă vrei să rulezi niște versiuni ASF fixe, atunci în mod natural `A.B.C.D` versiunile sunt ceea ce cauți.

În general, descurajăm încercarea `principal` construieşte, deoarece acestea sunt aici pentru noi pentru a marca stadiul actual al proiectului ASF. Nimic nu garantează că un astfel de stat va funcţiona în mod corespunzător, dar bineînțeles că ești mai mult decât binevenit să le dai o încercare dacă ești interesat de dezvoltarea ASF.

---

## Arhitecturi

Imaginea andocatorului ASF este în prezent construită pe `linux` platformă țintind 3 arhitecturi - `x64`, `brațul` și `arm64`. Poți citi mai multe despre ele în secțiunea **[compatibilitate](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**.

Tag-urile noastre folosesc manifestul multi-platformă, ceea ce înseamnă că Docker instalat pe mașina ta va selecta automat imaginea corectă pentru platforma ta atunci când tragi imaginea. Dacă cu orice șansă doriți să trageți o imagine de platformă specifică, care nu se potrivește cu cea pe care o rulați în prezent, poți face asta prin comutatorul `--platform` în comenzile docker adecvate, cum ar fi `docker run`. Vezi documentația docker pe **[imagine manifest](https://docs.docker.com/registry/spec/manifest-v2-2)** pentru mai multe informații.

---

## Utilizare

Pentru referințe complete ar trebui să utilizați **[documentația oficială de docker](https://docs.docker.com/engine/reference/commandline/docker)**, Vom acoperi doar utilizarea de bază în acest ghid, eşti mai mult decât binevenit să sapi mai adânc.

### Hello ASF!

În primul rând ar trebui să verificăm dacă dockerul nostru funcționează chiar și corect, acesta va servi ca ASF "hello world":

```shell
docker rulează -it --name asf --pull always --rm justarchi/archisteamfarm
```

`docker run` creează un nou container de andocare ASF pentru tine și rulează în prim plan (`-it`). `--pull always` asigură că imaginea actualizată va fi trasă mai întâi, iar `--rm` se asigură că containerul nostru va fi șters odată oprit, pentru că noi doar testăm dacă totul funcționează bine până acum.

Dacă totul s-a terminat cu succes, după ce am tras toate straturile şi am pornit containerul, ar trebui să observați că ASF a început în mod corespunzător și ne-a informat că nu există boți definiți; ceea ce este bun - am verificat că ASF în docker funcţionează corect. Apăsați `CTRL+C` pentru a încheia procesul ASF și, prin urmare, și containerul.

Dacă vă uitaţi mai atent la comandă, atunci veţi observa că nu am declarat nici o etichetă, care s-a implicit automat la `cel mai recent`. Dacă doriţi să utilizaţi o altă etichetă decât `ultimul`, de exemplu `lansat`, atunci ar trebui să o declaraţi explicit:

```shell
docker rulează -it --name asf --pull always --rm justarchi/aristeamfarm:lansat
```

---

## Utilizarea unui volum

Dacă folosești ASF în containerul de andocare, atunci evident trebuie să configurezi programul în sine. O poți face în diferite moduri, dar cel recomandat ar fi să se creeze directorul ASF `config` pe o mașină locală, apoi montați-o ca volum partajat în containerul de andocare ASF.

De exemplu, vom presupune că folderul de configurare ASF este în directorul `/home/archi/ASF/config`. Acest director conține nucleul `ASF.json` precum și boții pe care vrem să îi rulăm. Acum, tot ce trebuie să facem este să atașăm acel director ca volum comun în containerul nostru de andocare, unde ASF așteaptă directorul de configurare (`/app/config`).

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Şi asta e tot, acum containerul pentru andocare ASF va folosi folderul partajat cu maşina locală în modul de citire-scriere. care este tot ce ai nevoie pentru configurarea ASF. În mod similar, puteți canta alte volume pe care doriți să le partajați cu ASF, cum ar fi `/app/logs` sau `/app/plugins`.

Desigur, acesta este doar un mod specific de a obţine ceea ce ne dorim, nimic nu vă opreşte, de exemplu, crearea propriului dvs. `Dockerfile` care va copia fişierele de configurare în directorul `/app/config` în interiorul containerului de docker ASF. Acoperim doar utilizarea de bază în acest ghid.

### Permisiuni volum

Containerul ASF în mod implicit este inițializat cu utilizatorul implicit `root` , care îi permite să se ocupe de chestii de permisiuni interne și apoi să comute la `asf` (UID `1000`) pentru partea rămasă din procesul principal. Deși acest lucru ar trebui să fie satisfăcător pentru marea majoritate a utilizatorilor, afectează volumul partajat deoarece fișierele nou generate vor fi în mod normal deținute de utilizatorul `asf` , care ar putea să nu fie situația dorită dacă ați dori un alt utilizator pentru volumul dvs. partajat.

Există două modalități prin care puteți schimba utilizatorul ASF rulează în desfășurare. Primul, recomandat, este să declare `ASF_UID` variabilă de mediu cu UID țintă la care doriți să executați la . În al doilea rând, alternativa este de a trece `--user` **[steag](https://docs.docker.com/engine/reference/run/#user)**, care este direct suportat de docker.

Puteți verifica comanda `uid` de exemplu cu comanda `id -u` , apoi declarați-o conform specificațiilor de mai sus. De exemplu, dacă utilizatorul țintă are `uid` de 1001:

```shell
docker rulează -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm

# Alternativ, dacă înțelegi limitările de mai jos
docker rulează -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Diferența dintre `ASF_UID` și `--user` steag este subtle, dar important. `ASF_UID` este un mecanism personalizat suportat de ASF, în acest recipient de andocare încă începe ca `root`, și apoi scriptul de pornire ASF începe binarul principal sub `ASF_UID`. Când utilizați stegulețul `--user` , porniți întregul proces, inclusiv scriptul de pornire ASF ca utilizator dat. Prima opțiune permite scriptului de pornire ASF să gestioneze automat permisiunile și alte lucruri pentru dvs., rezolvând unele probleme comune pe care le-ați cauzat, de exemplu, se asigură că directoarele tale `/app` şi `/asf` sunt deţinute de `ASF_UID`. În al doilea scenariu, pentru că nu funcționăm ca `root`, Nu putem face asta, și te aștepți să te ocupi de toate astea în avans.

Dacă ai decis să folosești steagul `--user` , trebuie să schimbați proprietatea tuturor fișierelor ASF de la `1000` implicit la noul utilizator personalizat. Poți face acest lucru executând comanda mai jos:

```shell
# Execută numai dacă nu utilizați ASF_UID
docker exec -u root asf_container_name chown -hR 1001 /app /asf
```

Acest lucru trebuie făcut o singură dată după ce ai creat containerul cu `docker run`, şi numai dacă aţi decis să utilizaţi un utilizator personalizat prin steagul de andocare `--user`. De asemenea, nu uita să schimbi argumentul `1001` din comanda de mai sus cu `UID` pe care vrei să rulezi ASF la .

### Volum SELinux

Dacă folosiți SELinux în starea impusă pe sistemul dvs. de operare, care este implicit de exemplu la distanțele bazate pe RHEL, apoi ar trebui să cuantificați opțiunea de volum `:Z` , care va seta contextul SELinux corect pentru acesta.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull always justarchi/archisteamfarm
```

Acest lucru va permite ASF să creeze fișiere țintind volumul în timpul containerului docker.

---

## Sincronizare mai multe instanțe

ASF include suport pentru sincronizarea mai multor instanțe, după cum se menționează în secțiunea **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)**. Când rulezi ASF în containerul docker, poți opțional, "opt-in" în proces, în cazul în care rulați mai multe containere cu ASF și doriți ca acestea să se sincronizeze unul cu celălalt.

În mod implicit, fiecare ASF care rulează în interiorul unui container de andocare este în sine, ceea ce înseamnă că nu are loc sincronizarea. Pentru a permite sincronizarea între ele, trebuie să legați calea `/tmp/ASF` în fiecare container ASF pe care doriți să îl sincronizați, la una, cale partajată pe gazda dvs. de andocare, în modul citire-scriere. Aceasta se realizează exact la fel ca legarea unui volum care a fost descris mai sus, doar cu căi diferite:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull always justarchi/archisteamfarm
# și așa mai târziu, toate containerele ASF sunt acum sincronizate unele cu altele
```

Vă recomandăm să legați directorul ASF `/tmp/ASF` și de directorul temporar `/tmp` de pe mașina dvs., dar desigur ești liber să îl alegi pe oricare altul care îți satisface utilizarea. Fiecare container ASF care se așteaptă să fie sincronizat ar trebui să aibă directorul `/tmp/ASF` partajat cu alte containere care iau parte la același proces de sincronizare.

După cum probabil aţi ghicit din exemplul de mai sus, este posibil de asemenea să creaţi două sau mai multe "grupuri de sincronizare", prin legarea căilor diferite de gazdă de andocare de ASF's `/tmp/ASF`.

Montarea `/tmp/ASF` este complet opțională și de fapt nu este recomandată, cu excepția cazului în care doriți în mod explicit să sincronizați două sau mai multe containere ASF. Nu recomandăm calcularea `/tmp/ASF` pentru utilizarea unui singur container, întrucât nu aduce absolut niciun beneficiu dacă vă așteptați să rulați doar un singur container ASF, ar putea cauza probleme care ar putea fi evitate în caz contrar.

---

## Argumente din linie comandă

ASF allows you to pass **[command-line arguments](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** in docker container through environment variables. Ar trebui să folosești variabile de mediu specifice pentru comutatoare suportate și `ASF_ARGS` pentru restul. Acest lucru poate fi realizat cu comutatorul `-e` adăugat la `docker run`, de exemplu:

```shell
docker rulează -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull always justarchi/archisteamfarm
```

Acest lucru va trece în mod corespunzător argumentul `--cryptkey` pentru ca procesul ASF să fie rulat în containerul docker, precum și alte args. Desigur, dacă ești utilizator avansat, poți să modifici și `ENTRYPOINT` sau să adaugi `CMD` și să pasezi argumentele tale personale.

Dacă nu doriți să furnizați cheia de criptare personalizată sau alte opțiuni avansate, de obicei nu trebuie să includeți nici o variabilă specială de mediu, ca și cum containerele noastre de andocare sunt deja configurate pentru a rula cu o opțiune implicită veche de `--no-restart`, astfel încât să nu fie necesar să fie specificat explicit în `ASF_ARGS`.

---

## IPC

Presupunând că nu ați modificat valoarea implicită pentru `IPC` **[configurația globală](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, este deja activată. Cu toate acestea, trebuie să faceți două lucruri suplimentare pentru ca IPC să funcționeze în containerul Docker. În primul rând, trebuie să utilizați `IPCPassword` sau să modificați `KnownNetworks` implicit `IPC. onfig` pentru a vă permite să vă conectați din exterior fără a utiliza unul. Dacă nu știi cu adevărat ce faci, pur și simplu folosește `IPCPassword`. În al doilea rând, trebuie să modificați adresa implicită de ascultare a `localhost`, deoarece docker nu poate direcționa în afara traficului către interfața de tip buclă. Un exemplu de setare care va asculta pe toate interfețele ar fi `http://*:1242`. Desigur, poți folosi și legături mai restrictive, cum ar fi doar rețeaua locală LAN sau VPN, dar trebuie să fie un traseu accesibil din exterior - `localhost` nu va face, deoarece ruta este în întregime în cadrul aparatului vizitator.

Pentru a face cele de mai sus, ar trebui să utilizați **[configurare IPC personalizată](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** cum ar fi cea de mai jos:

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

Odată ce am configurat IPC pe interfața non-buclă, trebuie să îi spunem docker-ului să hartă comutatorul `1242/tcp` al ASF, fie cu un întrerupător `-P` sau `-p`.

De exemplu, această comandă ar expune interfața IPC ASF la mașina gazdă (numai):

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull always justarchi/archisteamfarm
```

Dacă setați totul corect, Comanda `docker run` de mai sus va face ca **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** să funcționeze de la mașina gazdă, pe ruta standard `localhost:1242` care este acum redirectionata corect catre masinaria dumneavoastra de oaspete. De asemenea, este frumos să observăm că nu expunem mai departe această cale, astfel încât conexiunea să poată fi făcută numai în interiorul gazdei de andocare, păstrând-o astfel în siguranţă. Desigur, poți expune ruta mai departe dacă știi ce faci și asiguri măsuri de securitate adecvate.

---

### Exemplu complet

Combinând toate cunoștințele de mai sus, un exemplu de configurare completă ar arăta așa:

```shell
docker run -p 127.0.0.1:1242:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugin-uri --name asf --pull always --restart unless stopped justarchie/archisteamfarm
```

Aceasta presupune că vei folosi un singur container ASF, cu toate fișierele de configurare ASF în `/home/archi/ASF/config`. Ar trebui să modifici calea configurării celei care se potrivește cu mașinăria ta. De asemenea, este posibil să furnizezi plugin-uri personalizate pentru ASF, pe care le poți pune în `/home/archi/ASF/plugins`. Această configurare este de asemenea pregătită pentru utilizarea IPC opțională dacă ați decis să includeți `IPC. onfig` în folderul de configurare cu un conținut ca mai jos:

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

Poți obține același efect al comenzii `docker run` folosind următoarea configurație `docker compose`:

```yaml
version: "3.8"
services:
  asf:
    image: justarchi/archisteamfarm
    container_name: asf
    restart: unless-stopped
    ports:
      - "127.0.0.1:1242:1242"
      - "[::1]:1242:1242"
    volumes:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

De la alte lucruri decât cele discutate mai sus, Am adăugat `--restartează fără oprire` la ambele exemple de mai sus pentru a porni automat acest container după repornirea mașinăriei tale. Simte-te liber să-l elimini sau schimbi pentru a răspunde nevoilor tale.

---

## Pro tips

Când ai deja containerul de andocare ASF pregătit, nu trebuie să folosești `docker run` de fiecare dată. Poți opri/porni ușor containerul de andocare ASF cu `docker stop asf` și `pornește docker asf`. Țineți cont că dacă nu utilizați eticheta `ultimul` atunci folosind ASF actualizat va avea nevoie de la dvs. la `docker stop`, `docker rm` și `docker rulează` din nou. Acest lucru se datorează faptului că trebuie să reconstruiți containerul din imagini proaspete de andocare ASF de fiecare dată când doriți să folosiți versiunea ASF inclusă în acea imagine. În eticheta `ultimul` , ASF a inclus capacitatea de a se auto-actualiza. astfel reconstruirea imaginii nu este necesară pentru utilizarea ASF actualizat (dar este încă o idee bună să o faci din când în când pentru a folosi noi . ET dependențe rulante și sistemul de operare subiacent, care ar putea fi necesar atunci când săriți peste actualizările majore ale versiunii ASF).

După cum s-a sugerat mai sus, ASF în alte etichete decât `ultimul` nu se va actualiza automat. ceea ce înseamnă că **you** este responsabil de utilizarea repo-ului `justarchi/archisteamfarm`. Aceasta are multe avantaje ca de obicei aplicația nu ar trebui să atingă propriul cod atunci când rulează, dar înțelegem, de asemenea, confortul care vine din faptul că nu trebuie să îți faci griji cu privire la versiunea ASF în containerul tău docker. Dacă vă pasă de bunele practici și de utilizarea corectă a docker-ului, Tag-ul `lansat` este ceea ce am sugera în loc de `ultimul`, dar dacă nu poți fi deranjat de el și vrei doar să faci ASF atât să funcționeze cât și să se actualizeze automat, apoi `ultimul` va face.

De obicei, ar trebui să rulați ASF în containerul de andocare cu `Headless: true` setare globală. Acest lucru va spune clar ASF că nu sunteți aici pentru a oferi detalii lipsă și nu ar trebui să le solicite. Desigur, pentru configurarea inițială ar trebui să iei în considerare să lași această opțiune de la `false` pentru a putea seta cu ușurință lucruri, dar pe termen lung nu ești atașat de obicei la consola ASF, Prin urmare, ar fi logic să se informeze ASF cu privire la acest lucru și să se utilizeze `input` **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** dacă este nevoie. În acest fel, ASF nu va trebui să aștepte infinit pentru ca utilizatorul să primească informații care nu se vor întâmpla (și să piardă resurse în timp ce face asta). De asemenea, va permite ASF să ruleze în mod non-interactiv în interiorul containerului, ceea ce este esențial, de exemplu, în ceea ce privește transmiterea de semnale, făcând posibilă închiderea grațioasă a ASF la cererea `docker stop asf`.