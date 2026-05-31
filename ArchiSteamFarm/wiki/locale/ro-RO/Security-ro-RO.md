# Securitate

## Criptare

ASF acceptă în prezent următoarele metode de criptare ca definiție a `ECryptoMethod`:

| Valoare | Nume                        |
| ------- | --------------------------- |
| 0       | PlainText                   |
| 1       | AES                         |
| 2       | ProtectedDataForCurrentUser |
| 3       | MediuVariabilă              |
| 4       | Fișier                      |

Descrierea exactă și compararea acestora sunt disponibile mai jos.

### Configurare

Pentru a genera parola criptată, de ex. pentru utilizarea `SteamPassword`, ar trebui să executați **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** `encrypt` cu criptarea corespunzătoare pe care ați ales-o și parola originală. După aceea, puneți textul criptat pe care l-ati obținut ca proprietate de configurare bot `SteamPassword` și în cele din urmă schimbați `PasswordFormat` cu cea care se potrivește cu metoda de criptare aleasă. Unele formate nu necesită comanda `criptare` , de exemplu `EnvironmentVariable` sau `File`, doar pune calea potrivită pentru ele.

---

### `PlainText`

Acesta este cel mai simplu și nesigur mod de a stoca o parolă, definită ca `ECryptoMethod` de `0`. ASF se așteaptă ca șirul să fie un text simplu - o parolă în formă directă. Este cel mai ușor de utilizat, 100% compatibil cu toate configurațiile, deci este un mod implicit de a stoca secrete, complet nesigur pentru stocare în siguranță.

---

### `AES`

Considerat securizat de standardele de azi, modul **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** de stocare a parolei este definit ca `ECryptoMethod` de `1`. ASF se așteaptă ca șirul să fie **[codat base64-](https://en.wikipedia.org/wiki/Base64)** secvență de caractere rezultând în array byte criptat AES după traducere, care apoi trebuie decriptate folosind **[vectorul de inițializare](https://en.wikipedia.org/wiki/Initialization_vector)** și cheia de criptare ASF.

Metoda de mai sus garantează securitatea atâta timp cât atacatorul nu cunoaște cheia de criptare ASF care este folosită pentru decriptare și criptare a parolelor. ASF vă permite să specificați cheia prin intermediul `--cryptkey` **[argumentul de virgulă](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, pe care ar trebui să-l utilizați pentru o securitate maximă. Dacă decizi să omiți acest lucru, ASF va utiliza propria cheie care este **cunoscut** și hardcodat în aplicație, însemnând că oricine poate inversa criptarea ASF și poate obține o parolă decriptată. Aceasta necesită încă un efort și nu este atât de ușor de făcut, ci posibil, de aceea ar trebui aproape întotdeauna să folosiți criptarea `AES` cu propriul dvs. `--cryptkey` care este păstrat în secret. Metoda AES folosită în ASF oferă securitate care ar trebui să fie satisfăcătoare și este un echilibru între simplitatea lui `PlainText` și complexitatea lui `ProtectedDataForCurrent`, dar este foarte recomandat să fie folosit cu particularizarea `--cryptkey`.

Dacă este folosit corect (lung, particularizat `--cryptkey`), garantează o securitate foarte ridicată pentru stocarea în siguranță.

---

### `ProtectedDataForCurrentUser`

Considerat securizat de standardele de azi, **[Mod de stocare a parolei DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** este definit ca `ECryptoMethod` din `2`. Avantajul major al acestei metode este în același timp dezavantajul major - în loc de a folosi cheia de criptare (ca în `AES`), datele sunt criptate folosind datele de autentificare ale utilizatorului logat, ceea ce înseamnă că este posibilă decriptarea datelor **doar** pe aparatul pe care a fost criptată, și în plus, doar **doar** de către utilizatorul care a emis criptarea.

Acest lucru asigură că chiar dacă trimiteți întregul dvs. `Bot. fiul` cu criptat `SteamPassword` folosind această metodă pentru altcineva, nu vor putea decripta parola fără acces direct la PC-ul tău. Aceasta este o măsură de securitate excelentă, dar, în același timp, are un dezavantaj major de a fi cel mai puțin compatibilă, deoarece parola criptată folosind această metodă va fi incompatibilă cu orice alt utilizator, precum și cu mașina - inclusiv cu **propriul** dacă decideți să o faceți. . reinstalați sistemul de operare. Aceasta este metoda recomandată dacă nu trebuie să accesezi configurațiile de la nicio altă mașinărie decât a ta, și că nu ai nevoie de compatibilitate între mașini încrucișate.

**Vă rugăm să reţineţi că această opţiune este disponibilă doar pentru maşinile care rulează Windows OS începând de acum.**

---

### `MediuVariabilă`

Stocare bazată pe memorie definită ca `ECryptoMethod` of `3`. ASF va citi parola din variabila mediu cu numele specificat în câmpul parolă (de ex. `SteamPassword`). De exemplu, setarea `SteamPassword` la `ASF_PASSWORD_MYACCOUNT` și `Parola` la `3` va cauza ASF să evalueze `${ASF_PASSWORD_MYACCOUNT}` și să folosească orice este atribuit ca parolă a contului.

Nu uitați să vă asigurați că variabilele de mediu ale procesului ASF nu sunt accesibile utilizatorilor neautorizați, întrucât aceasta contravine întregului scop al utilizării acestei metode.

---

### `Fișier`

Stocare bazată pe fișiere (posibil în afara directorului de configurare ASF) definită ca `ECryptoMethod` of `4`. ASF va citi parola din calea fișierului specificată în câmpul parolă (de ex. `SteamPassword`). Calea specificată poate fi absolută, sau relativă la locația ASF (dosarul cu `config` în interior, luând în considerare `--path` **[argumentul de virgulă](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). Această metodă poate fi utilizată, de exemplu, cu **[Docker secret](https://docs.docker.com/engine/swarm/secrets)**, care creează astfel de fișiere pentru utilizare, dar pot fi folosite și în afara Docker dacă creezi fișierul corespunzător. De exemplu, setarea `SteamPassword` la `/etc/secrets/MyAccount. ass` and `PasswordFormat` la `4` va cauza ASF să citească `/etc/secrets/MyAccount. ass` și folosiți tot ce este scris în acel fișier ca parolă de cont.

Amintiți-vă să vă asigurați că fișierul care conține parola nu poate fi citit de către utilizatorii neautorizați, deoarece acest lucru contravine scopului utilizării acestei metode.

---

## Recomandări de criptare

Dacă compatibilitatea nu este o problemă pentru tine, și sunteți în regulă cu modul în care funcționează metoda `ProtectedDataForCurrent` , este opțiunea **recomandat** de a stoca parola în ASF, deoarece oferă cea mai bună securitate și confort. `Metoda AES` este o alegere bună pentru persoanele care încă doresc să utilizeze configurațiile lor pe orice mașină doresc, în timp ce `PlainText` este cel mai simplu mod de a stoca parola, dacă nu te deranjează că oricine poate căuta fișierul de configurare JSON pentru el.

Te rugăm să reții că toate metodele de criptare sunt considerate **nesigure** dacă atacatorul are acces la PC-ul tău. ASF trebuie să fie capabil să decripteze parolele criptate, și dacă programul care rulează pe mașină este capabil să facă asta, orice alt program care rulează pe aceeaşi maşină va fi capabil să facă şi aşa ceva. `ProtectedDataForCurrent` este cea mai sigură variantă ca **chiar și alt utilizator care utilizează același PC nu va putea să îl decripteze**, dar încă este posibil să decriptezi datele dacă cineva este capabil să îți fure credențialele de autentificare și informațiile automate, în plus față de fișierul de configurare ASF.

Pentru configurări avansate, puteți utiliza `EnvironmentVariable` și `File`. Ele au o capacitate de utilizare limitată, `EnvironmentVariable` va fi o idee bună dacă ai prefera să obții o parolă printr-un fel de soluție personalizată și să o stochezi exclusiv în memorie, în timp ce `Fișierul` este bun de exemplu cu **[Docker secret](https://docs.docker.com/engine/swarm/secrets)**. Ambele sunt totuși necriptate, așa că practic mutați riscul de la fișierul de configurare ASF la orice ați alege dintre cele două.

În plus față de metodele de criptare specificate mai sus, este posibil să se evite complet specificarea parolelor, de exemplu ca `SteamPassword` folosind un șir gol sau `null`. ASF vă va cere parola atunci când este necesar, şi nu o vom salva nicăieri, dar păstraţi în memorie procesul de rulare curent, până când îl închideţi. În timp ce sunt cea mai sigură metodă de a trata parolele (nu sunt salvate nicăieri), este de asemenea cel mai supărător aspect pentru că trebuie să introduci parola manual la fiecare rulare ASF (atunci când este necesar). Dacă asta nu e o problemă pentru voi, ăsta e cel mai bun punct de vedere al securităţii pariului, pentru că nu puteţi să divulgaţi ceva care nu există.

---

## Decriptare

ASF nu acceptă nici o modalitate de decriptare a parolelor deja criptate, deoarece metodele de decriptare sunt folosite doar pe plan intern pentru accesarea datelor în interiorul procesului. Dacă doriţi să reveniţi la procedura de criptare, de ex. pentru mutarea ASF la o altă mașină atunci când utilizați `ProtectedDataForCurrent`, apoi repetați procedura de la început în noul mediu.

---

## Hashing

ASF acceptă în prezent următoarele metode de hashing ca o definiție a lui `Metoda de spălare`:

| Valoare | Nume      |
| ------- | --------- |
| 0       | PlainText |
| 1       | SCriptare |
| 2       | Pbkdf2    |

Descrierea exactă și compararea acestora sunt disponibile mai jos.

### Configurare

Pentru a genera o cauciuc, de ex. pentru utilizarea `IPCPassword` , ar trebui să executați comanda `hash` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** cu metoda adecvată de hashing pe care ați ales-o și parola originală de text simplu. După premii pune șirul hashed pe care îl ai ca `IPCPassword` proprietatea de configurare ASF, și în final schimbați `IPCPasswordFormat` cu cel care se potrivește cu metoda de hashing aleasă.

---

### `PlainText`

Aceasta este cea mai simplă și nesigură modalitate de a hasha o parolă, definită ca `Metoda EHash` de `0`. ASF va genera hash care se potrivește cu intrarea originală. Este cel mai ușor de utilizat, 100% compatibil cu toate configurațiile, deci este un mod implicit de a stoca secrete, complet nesigur pentru stocare în siguranță.

---

### `SCriptare`

Considerat securizat de standardele de azi, **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** mod de a sparge parola este definit ca `EHash Method` din `1`. ASF va utiliza implementarea `SCrypt` folosind blocurile `8` , `8192` iterații, Lungimea hash-ului `32` și cheia de criptare ca sare pentru a genera o serie de bytes. Apoi, octeţii rezultaţi vor fi codificaţi ca şirul **[base64](https://en.wikipedia.org/wiki/Base64)**.

ASF vă permite să specificați sarea pentru această metodă prin `--cryptkey` **[argumentul de virgulă](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, pe care ar trebui să îl utilizați pentru o securitate maximă. Dacă decizi să omiți acest lucru, ASF va utiliza propria cheie care este **cunoscut** și hardcodat în aplicație, ceea ce înseamnă că va fi mai puțin sigur.

Dacă este folosită corect (sare personalizată, parolă lungă), garantează o securitate foarte mare pentru stocarea în siguranță.

---

### `Pbkdf2`

Considerat ca fiind slab de standardele de azi, **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** modul de hash a parolei este definit ca `EHash Method` din `2`. ASF va utiliza implementarea `Pbkdf2` folosind iterațiile `10000` , `32` lungimea hash-ului şi cheia de criptare ca sare, cu `SHA-256` ca algoritm hmac. Apoi, octeţii rezultaţi vor fi codificaţi ca şirul **[base64](https://en.wikipedia.org/wiki/Base64)**.

ASF vă permite să specificați sarea pentru această metodă prin `--cryptkey` **[argumentul de virgulă](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, pe care ar trebui să îl utilizați pentru o securitate maximă. Dacă decizi să omiți acest lucru, ASF va utiliza propria cheie care este **cunoscut** și hardcodat în aplicație, ceea ce înseamnă că va fi mai puțin sigur.

---

## Recomandări privind ancorarea

Dacă doriţi să utilizaţi o metodă de hashing pentru stocarea unor secrete, cum ar fi `IPCPassword`, Îți recomandăm să folosești `SCrypt` cu sare personalizată, deoarece oferă o securitate foarte decentă împotriva tentativelor brutale.

`Pbkdf2` este oferit doar din motive de compatibilitate, în principal pentru că dispunem deja de o punere în aplicare funcțională (și necesară) a acesteia pentru alte cazuri de utilizare pe platforma Steam (e. . pine parentale). Încă este considerată sigură, dar slabă în comparație cu alternative (de ex. `SCrypt`).