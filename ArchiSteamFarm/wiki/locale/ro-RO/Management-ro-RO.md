# Gestionare

Această secțiune se referă în mod optim la subiecții legați de gestionarea procesului ASF. Deşi nu este strict obligatoriu pentru utilizare, acesta include o grămadă de sfaturi, trucuri şi bune practici pe care am dori să le împărtăşim în special pentru administratorii de sistem, persoanele împachetează ASF pentru a fi utilizat în depozite terțe, precum și pentru utilizatorii avansați și deopotrivă.

---

## Serviciul `systemd` pentru Linux

În variantele `generic` și `linux` , ASF vine cu `ArchiSteamFarm@. protejează` fișier, care este un fişier de configurare a serviciului pentru **[`sistem`](https://systemd.io)**. Dacă doriți să rulați ASF ca serviciu, de exemplu pentru a-l lansa automat după pornirea mașinii, apoi un serviciu `systemd` adecvat este probabil cel mai bun mod de a face acest lucru, prin urmare îți recomandăm să îl gestionezi pe cont propriu prin `nohup`, `screen` sau în același timp.

În primul rând, creați contul utilizatorului la care doriți să rulați ASF, presupunând că acesta nu există încă. Vom folosi utilizator `asf` pentru acest exemplu, dacă te decizi să folosești altul, va trebui să înlocuiești `asf` utilizator în toate exemplele noastre de mai jos cu cel selectat. Serviciul nostru nu vă permite să rulați ASF ca `root`, deoarece este considerat un **[antrenament greșit](#never-run-asf-as-administrator)**.

```sh
su # Sau sudo -i, pentru a ajunge în root shell
useradd -m asf # Creare cont pe care intenționați să rulați ASF sub
```

Apoi, dezarhivați ASF în dosarul `/home/asf/ArchiSteamFarm`. Structura folderului este importantă pentru unitatea noastră de servicii, ar trebui să fie dosarul `ArchiSteamFarm` în secțiunea `$HOME`, deci `/home/<user>`. Dacă aţi făcut totul corect, va exista fişierul `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service`. Dacă utilizaţi varianta `linux` şi nu a dezarhivat fişierul de pe Linux, dar de exemplu a folosit transferul de fişiere din Windows, apoi vei avea de asemenea nevoie de `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

Vom face toate acțiunile de mai jos ca `root`, așa că ajungem la raftul său cu `su` sau `sudo -i`.

În primul rând, este o idee bună să te asiguri că dosarul nostru încă aparține utilizatorului nostru `asf` , `executat de o dată -hR asf:asf /home/asf/ArchiSteamFarm`. Permisiunile ar putea fi greșite, de ex. dacă ați descărcat și/sau ați depachetat fișierul zip ca `root`.

În al doilea rând, dacă folosești variantă generică a ASF, trebuie să vă asigurați că comanda `dotnet` este recunoscută și în una dintre locațiile standard: `/usr/local/bin`, `/usr/bin` sau `/bin`. This is required for our systemd service which executes `dotnet /path/to/ArchiSteamFarm.dll` command. Verificați dacă `dotnet --info` funcționează pentru dvs., dacă da, tastați comanda `-v dotnet` pentru a afla unde este localizat. Dacă ați folosit instalatorul oficial, ar trebui să fie în `/usr/bin/dotnet` sau una dintre celelalte două locații, care este în dreapta. Dacă este în locație personalizată, cum ar fi `/usr/share/dotnet/dotnet`, creează un **[symlink](https://wikipedia.org/wiki/Symbolic_link)** pentru el folosind `ln -s "$(comandă-v dotnet)" /usr/bin/dotnet`. Acum `comanda -v dotnet` ar trebui să raporteze `/usr/bin/dotnet`, ceea ce va face ca unitatea noastră de sistem să funcționeze. Dacă folosiți o variantă specifică OS, nu trebuie să faceți nimic în această privință.

Apoi, execută `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/system/ArchiSteamFarm\@. ervați`, aceasta va crea un link simbolic către declarația noastră de serviciu și îl va înregistra în `systemd`. Link-ul simbolic va permite ASF să actualizeze automat unitatea `systemd` ca parte a actualizării ASF - în funcție de situația ta, poate doriţi să utilizaţi această abordare, sau pur şi simplu `cp` fişierul şi să-l gestionaţi chiar dumneavoastră oricât aţi dori.

După aceea, asigură-te că `systemd` recunoaște serviciul nostru:

```
systemctl status ArchiSteamFarm@asf

<unk> ArchiSteamFarm@asf.service - ArchiSteamFarm Service (în asf)
     Încărcat: încărcat (/etc/systemd/system/ArchiSteamFarm@. ervic; dezactivat; preset vendor: activat)
     Activ: inactiv (mort)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Acordați o atenție specială utilizatorului pe care îl declarăm după `@`, este `asf` în cazul nostru. Sistemul nostru de servicii aşteaptă de la tine să declare utilizatorul, în timp ce influențează locul exact al binarului `/home/<user>/ArchiSteamFarm`, precum şi sistemul de utilizator real va declanşa procesul.

Dacă sistemul returnează o producţie similară cu cea de mai sus, totul este în ordine, şi suntem aproape gata. Acum, tot ce mai rămâne este de fapt pornirea serviciului nostru ca utilizator ales: `systemctl start ArchiSteamFarm@asf`. Așteptați o secundă sau două, și puteți verifica starea din nou:

```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (pe asf)
     Încărcat: încărcat (/etc/systemd/system/ArchiSteamFarm@.service; dezactivat; presetare jandor: activat)
     Activ: (rulat) de la (...)
       Documente: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   Principal PID: (...)
(...)
```

Dacă `systemd` states `active (rulează)`, înseamnă că totul a mers bine și poți verifica dacă procesul ASF ar trebui să ruleze, de exemplu cu `journalctl -r`, ca ASF în mod implicit, scrie, de asemenea, pe dispozitivul său de ieșire, care este înregistrat de `systemd`. Dacă sunteți mulțumit de configurarea pe care o aveți acum, puteți spune `systemd` pentru a porni automat serviciul în timpul pornirii, executând comanda `systemctl activează comanda ArchiSteamFarm@asf`. Asta e tot.

Dacă cu orice șansă doriți să opriți procesul, pur și simplu executați `systemctl stop ArchiSteamFarm@asf`. De asemenea, dacă doriți să dezactivați ASF de la pornirea automată la pornire, `systemctl dezactivează ArchiSteamFarm@asf` va face asta pentru tine, e foarte simplu.

Vă rugăm să reţineţi că, deoarece nu există nicio intrare standard activată pentru serviciul `systemd` , nu veți putea introduce detaliile prin consolă în mod obișnuit. Rulând prin `systemd` este echivalent cu **[`Headless: true`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** setarea și are toate implicațiile sale. Din fericire pentru tine, este foarte ușor să gestionezi ASF prin **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, pe care o recomandăm în cazul în care trebuie să furnizați detalii suplimentare în timpul autentificării sau să gestionați mai departe procesul ASF.

### Variabile de mediu

Este posibil să furnizați variabile de mediu suplimentare pentru serviciul nostru `systemd` , care veți fi interesat în cazul în care doriți să folosiți de exemplu un custom `--cryptkey` **[argument de comandă](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**, prin urmare specificând variabila de mediu `ASF_CRYPTKEY`.

Pentru a furniza variabile de mediu personalizate, creați folderul `/etc/asf` (în cazul în care nu există), `mkdir -p /etc/asf`. Recomandăm lui `chown -hR root:root /etc/asf && chmod 700 /etc/asf` pentru a se asigura că doar `root` are acces la citirea acelor fișiere, deoarece ar putea conține proprietăți sensibile, cum ar fi `ASF_CRYPTKEY`. După, scrie la un fișier `/etc/asf/<user>` unde `<user>` este utilizatorul pe care îl executați sub acest serviciu (`asf` în exemplul nostru de mai sus, deci `/etc/asf/asf`).

Fișierul ar trebui să conțină toate variabilele de mediu pe care doriți să le furnizați procesului. Cei care nu au o variabilă de mediu dedicată, pot fi declarați în `ASF_ARGS`:

```sh
# Declare numai cele de care ai nevoie de fapt
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# Și orice alte persoane de care ești interesat
```

### Partea principală a unităţii de serviciu

Datorită flexibilității sistemului ``, este posibil să suprascrii o parte a unității ASF păstrând în același timp fișierul unitar original și permițând ASF să-l actualizeze de exemplu ca parte a actualizărilor automate.

În acest exemplu, am dori să modificăm comportamentul unitar ASF `systemd` de la repornirea doar a succesului, la repornirea și în cazul accidentelor fatale. În acest scop, Vom suprascrie `Repornește` proprietate sub `[Service]` de la `cu succes` la `întotdeauna`. Doar executați editarea de sistem `ArchiSteamFarm@asf`, înlocuind în mod natural `asf` cu utilizatorul țintă al serviciului dvs. Apoi adăugați modificările indicate de `systemd` într-o secțiune corectă:

```sh
### Editare /etc/system/system/ArchiSteamFarm@asf.service.d/override. onf
### Orice între aici și comentariul de mai jos va deveni noul conținut al fișierului

[Service]
Restart=always

### Linii sub acest comentariu vor fi eliminate

### /etc/sistem/ArchiSteamFarm@asf. ervați
# [Install]
# WantedBy=multi-user. arget
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet/home/%i/ArchiSteamFarm/ArchiSteamFarm. ll --no-restart --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# User=%i
# (...)
```

Şi asta e tot, acum unitatea ta acţionează la fel ca şi cum ar avea doar `Repornire =always` sub `[Service]`.

Bineînţeles, alternativa este de a `cp` fişierul şi de a-l gestiona singur, dar acest lucru vă permite modificări flexibile, chiar dacă aţi decis să păstraţi unitatea ASF originală, de exemplu cu un **[symlink](https://wikipedia.org/wiki/Symbolic_link)**.

---

## Nu rula ASF niciodată ca administrator!

ASF include propria sa validare dacă procesul este rulat ca administrator (`root`) sau nu. Rulând ca `root` este **nu** necesar pentru orice fel de operațiune efectuată de procesul ASF, presupunând un mediu bine configurat în care operează şi, prin urmare, trebuie privit ca un **proastă practică**. This means that on Windows, ASF should **never** be executed with "run as administrator" setting, and on Unix ASF should have a **dedicated user account** for itself, or re-use your own in case of a desktop system.

Pentru detalii suplimentare despre *de ce* descurajăm rularea ASF ca `root`, se referă la **[superuser](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** şi la alte resurse. Dacă încă nu ești convins, întreabă ce s-ar întâmpla cu mașina ta dacă ASF ar executa comanda `rm -rf /*` imediat după lansare.

### Eu rulez ca `root` deoarece ASF nu poate scrie în fișierele sale

Asta înseamnă că ai permisiuni configurate greșit pentru fișierele ASF încearcă să acceseze. You should login as `root` account (either with `su` or `sudo -i`) and then **correct** the permissions by issuing `chown -hR asf:asf /path/to/ASF` command, substituting `asf:asf` with the user that you'll run ASF under, and `/path/to/ASF` accordingly. Dacă cu orice șansă folosești personalizat `--path` spunându-i utilizatorului ASF să folosească alt director, ar trebui să executați din nou aceeași comandă și pentru acea cale.

După ce faci asta, nu ar mai trebui să primești niciun fel de problemă legată de ASF care nu poate scrie propriile fișiere, pentru că tocmai ai schimbat proprietarul a tot ce este ASF interesat de utilizator procesul ASF va rula în mod efectiv.

### Eu rulez ca `root` pentru că nu ştiu cum să-l fac altfel

```sh
su # Sau sudo -i, pentru a intra în root-shell
useradd -m asf # Creaţi cont intenţionaţi să rulaţi ASF sub
chown -hR asf:asf /path/to/ASF # Asiguraţi-vă că noul utilizator are acces la directorul ASF
su asf -c /path/to/ASF/ArchiSteamFarm # Sau sudo -u asf /path/to/ASF/ArchiSteamFarm, pentru a porni programul sub utilizatorul tău
```

Acest lucru ar fi făcut manual, este mult mai uşor să utilizaţi serviciul nostru **[`systemd`](#systemd-service-for-linux)** explicat mai sus.

### Știu mai bine și încă mai vreau să rulez ca `root`

ASF nu te oprește forțat să faci asta, afișează doar un avertisment cu o notificare scurtă. Nu trebuie să fii șocat dacă într-o zi din cauza unei erori în program, va exploda întregul sistem de operare cu pierderi complete de date - ai fost avertizat.

---

## Mai multe instanțe

ASF este compatibil cu rularea mai multor instanțe ale procesului pe aceeași mașină. Cazurile pot fi de sine stătătoare sau pot fi derivate din aceeaşi locaţie binară (în acest caz, vrei să le rulezi cu `--path` **[argument de comandă](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**).

Atunci când rulezi mai multe instanțe din același binar, rețineți că ar trebui să dezactivați de obicei actualizările automate în toate configurațiile lor, deoarece nu există sincronizare între ele în ceea ce privește actualizările automate. Dacă doriţi să continuaţi activarea actualizărilor automate, vă recomandăm instanţe independente, dar încă poți face actualizări să lucreze, atâta timp cât poți să te asiguri că toate celelalte instanțe ale ASF sunt închise.

ASF va face tot ce îi stă în putință pentru a menține o cantitate minimă de comunicații încrucișate la nivelul OS, cu alte instanțe ASF. Aceasta include verificarea folderului de configurare a ASF împotriva altor cazuri, precum și a partaja limitere de bază pentru întregul proces configurate cu `*LimiterDelay` **[proprietățile globale de configurare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, asigurarea faptului că funcționarea mai multor instanțe ASF nu va crea posibilitatea de a intra într-o problemă de limitare a ratei. În ceea ce privește aspectele tehnice, toate platformele utilizează mecanismul nostru special de încuietori personalizate bazate pe fișiere ASF create într-un director temporar, care este `C:\Users\<YourUser>\AppData\Local\Temp\ASF` pe Windows, și `/tmp/ASF` pe Unix.

Nu este necesar pentru rularea instanțelor ASF pentru a partaja aceleași proprietăți `*LimiterDelay` , pot utiliza valori diferite, deoarece fiecare ASF va adăuga propria sa întârziere configurată la timpul de lansare după achiziționarea blocării. Dacă este configurat `*LimiterDelay` este setat la `0`, instanța ASF va sări în întregime peste așteptarea blocării unei anumite resurse care este partajată cu alte instanțe (ceea ce ar putea menține un blocaj partajat unul cu celălalt). Când este setat la orice altă valoare, ASF se va sincroniza în mod corespunzător cu alte instanțe ASF și va aștepta întoarcerea, apoi eliberați blocarea după o întârziere configurată, permițând ca alte instanțe să continue.

ASF ia în considerare setarea `WebProxy` atunci când decide despre domeniul partajat, ceea ce înseamnă că două instanțe ASF care utilizează configurații `WebProxy` diferite nu vor partaja limitele între ele. Acest lucru este implementat pentru a permite setărilor `WebProxy` să funcționeze fără întârzieri excesive, conform așteptărilor din interfețele de rețea diferite. Acest lucru ar trebui să fie suficient de bun pentru majoritatea cazurilor de utilizare, cu toate acestea, dacă aveți o configurație personalizată specifică în care aveți, de exemplu, direcţionarea solicitărilor într-un mod diferit, puteți specifica grupul de rețea singur prin intermediul `--rețea grup` **[argument de comandă](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**, care vă va permite să declarați grupul ASF care va fi sincronizat cu această instanță. Țineți cont de faptul că grupurile de rețea personalizate sunt utilizate exclusiv, ceea ce înseamnă că ASF nu va mai utiliza `WebProxy` pentru a determina grupul potrivit, cum sunteți responsabil de grupare în acest caz.

Dacă doriți să utilizați serviciul nostru **[`systemd`](#systemd-service-for-linux)** explicat mai sus pentru mai multe cazuri ASF, este foarte simplu, doar folosiți un alt utilizator pentru declarația de serviciu `ArchiSteamFarm@` și urmați cu restul pașilor. Aceasta va fi echivalentă cu rularea mai multor instanțe ASF cu binare distincte, astfel încât să poată de asemenea să se actualizeze automat și să funcționeze independent una de cealaltă.