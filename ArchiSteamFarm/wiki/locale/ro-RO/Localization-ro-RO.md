# Traducere

ASF este alimentată de serviciul Crowdin, ceea ce permite tuturor să contribuie la traducerea ASF în toate limbile vorbite în întreaga lume. Pentru explicatii mai detaliate despre cum functioneaza Crowdin, te rugam sa verifici **[Introducere Crowdin](https://support.crowdin.com/crowdin-intro)**.

Dacă sunteți interesat de ceea ce se întâmplă în prezent, puteți verifica **[activitatea Crowdin](https://crowdin.com/project/archisteamfarm/activity_stream)**.

---

## Domeniul de aplicare

Platforma noastră suportă localizarea programului principal ASF, precum și întregul conținut localizat pe care îl oferim împreună cu acesta. Aceasta include în special ASF-WebConfigGeneratorul nostru, ASF-ui, precum şi wiki-ul nostru. Toate acestea sunt posibile pentru a fi traduse prin interfața convenabilă crowdin.

---

## Înregistrare

Dacă doriţi să ajutaţi cu ASF, fie prin traducerea, revizuirea sau aprobarea traducerilor, vă rugăm să vă înscrieți pe **[pagina proiectului Crowdin](https://crowdin.com/project/archisteamfarm)**. Înregistrarea este ușoară și absolut gratuită! După ce te conectezi poți alege limbi la care dorești să fii asociat, apoi treceți la șiruri ASF și ajutați restul comunității să traducă ASF în cele mai populare limbi!

---

### Traducere

În cazul în care limba aleasă de tine încă nu are câteva șiruri, le poți prinde și începe să lucrezi la traducere. Am încercat să facem tot ce ne stă în putință în ceea ce privește flexibilitatea traducerilor, prin urmare, multe șiruri de caractere includ variabile suplimentare pe care ASF le va furniza în timpul runtime – acestea sunt închise în paranteze cu un număr; precum `{0}`. Acest lucru vă permite să modificați formatul ASF implicit al șirului, de ex. mutând variabila furnizată de ASF într-un loc care vă satisface limba și traducerea în loc să fie forțat să fie strict contextual și format. Acest lucru este deosebit de important în limbile RTL, cum ar fi ebraica.

De exemplu, ai putea avea un şir de caractere precum:

> Avem jocuri {0} la fermă.

Dar pe baza limbii dumneavoastră, următoarea frază ar putea avea mai mult sens:

> Numărul de jocuri pentru fermă este egal cu {0}.

Sau:

> {0} este numărul de jocuri de farmat.

Flexibilitatea este oferită în mod special pentru dumneavoastră, pentru a putea redenumi ușor teza ASF pentru a se potrivi mai bine limbii tale și muta numărul furnizat de ASF sau alte informații într-un loc care se potrivește traducerii tale (în loc să traduci fiecare parte în mod independent). Acest lucru îmbunătățește calitatea globală a traducerilor.

---

### Recenzie

Dacă șirul tău a fost deja tradus de altcineva, poți vota în favoarea lui. Votul face posibilă alegerea celei mai bune variante a traducerii, în loc să rămână cu sugestia inițială - aceasta îmbunătățește și mai mult calitatea globală a traducerilor. Puteţi vota pentru sugestii deja disponibile sau sugera propria dumneavoastră traducere, care va trece prin acelaşi proces. În cele din urmă, șirul final va fi ales în funcție de sugestia votată, sau ca alegere a probei selectate pentru acea limbă care aprobă personal o traducere (pe baza voturilor tale).

**Nu ai nevoie de aprobare pentru a vedea șirurile traduse în ASF**. Aprobarea înseamnă pur şi simplu că cineva de încredere din partea noastră a examinat conţinutul, ca în - a ales versiunea finală a traducerii. Este foarte bine să ai traduceri care nu sunt aprobate de comunitate, unde votezi pentru cea mai bună. Atâta timp cât este tradus, totul este în regulă! Şi dacă crezi că traducerea curentă este proastă, poţi oricând să o votezi pe cea mai bună sau să o sugerezi pe tine însuţi.

---

### Dovada citirii

Este o idee bună să avem o traducere consecventă, chiar dacă ar putea să ne elibereze de procesul de revizuire/votare a comunităţii, explicat mai sus. Acest lucru se datorează în principal faptului că traducerile incorecte care nu sunt neapărat rele pot primi atât de multe voturi încât nu mai este posibil să sugerezi o traducere mai bună, chiar dacă cineva are aşa ceva.

Dacă aveți în trecut istoricul contribuțiilor pe Crowdin sau orice altă platformă de localizare/serviciu pe care îl putem verifica și asuma încredere, suntem bucuroşi să vă oferim o dovadă de cititor acces la o limbă la care contribui; pentru a putea aproba o anumită traducere și pentru a o face coerentă. Dovada citirii nu este o sarcină ușoară, în special deoarece ASF poate fi foarte „tehnică” din când în când și cu adevărat dificil de tradus, dar înţelegem că este adesea nevoie de o traducere perfectă. Prin urmare, dacă poți să ajuți prin proof-reading dat language, **[anunță-ne](https://crowdin.com/messages/create/13177432/240376)**, dar rețineți că va trebui să vă salvați cererea cu contribuții de localizare anterioare pe care le putem verifica (e. . lucrând cu localizarea ASF pe Crowdin, sau cu orice alt proiect). Putem de asemenea să permitem utilizatorilor mai avansați să preia proba inițială de citire, dacă îi cunoaștem personal și sunt capabili să coopereze cu restul comunității pentru a localiza ASF cel mai bine în acea limbă.

Reguli generale se aplică pentru proof-reading - nu te grăbiți, ascultă utilizatorii tăi, lucrează ca manager de proiect, rezolvă problemele, asiguraţi-vă că faceţi lucrurile mai bune şi nu mai rele.

---

### Probleme

Dacă aveţi o problemă cu o traducere specială, de exemplu nu știi cum să îl traduci, traducerea aprobată este incorectă, ai nevoie de un context mai specific, sau la fel, vă rugăm să postați un comentariu sub un anumit șir de caractere și să-l marcați cu [X] Problemă.

**Vă rugăm să evitați utilizarea marcajului de problemă dacă nu aveți nevoie de explicații tehnice/de dezvoltare sau acțiune de administrator**. Sunteți liber să utilizați comentarii pentru discuții legate de traducerea unui anumit șir, dar problema ar trebui utilizată numai atunci când aveţi nevoie de explicaţii tehnice suplimentare sau corecţii de administrator, şi va implica de obicei cineva care nici măcar nu vorbeşte limba în care traduci, așa că vă rugăm să rămâneți cu limba engleză când scrieți comentariul despre probleme (astfel încât să putem înțelege care este problema).

În prezent, există 4 tipuri de aspecte acceptate:
- Întrebare generală - pentru orice altă problemă care nu se potrivește mai jos. In general this type **should be avoided**, as if your problem does not fit, then it's very likely **not** a translation issue. Totuși, această opțiune este disponibilă aici pentru toate celelalte cazuri.
- Traducerea curentă este greșită - acest lucru ar trebui folosit **doar** dacă traducerea a fost deja aprobată de către proof-reader deja, și crezi că este greșit, de exemplu are o tipografie sau ai o sugestie valabilă despre cum să o îmbunătățești. Acest tip de traducere nu ar trebui să fie niciodată utilizat în traduceri alimentate de comunitate (vot), ca în acest caz trebuie să contactați utilizatorul cu o traducere dată și să îi cereți o corecție, fie să voteze pur şi simplu pentru o mai bună traducere, aşa cum se menţionează în secţiunea revizuită. Vom elimina aprobarea traducerii și vom notifica probele de cititor adecvate responsabile cu limba pentru a lua în considerare comentariul dvs. și a verifica din nou.
- Lipsa informațiilor contextuale - aceasta este ceea ce ar trebui să folosiți dacă nu sunteți sigur ce parte a ASF traduceți, care este contextul unui anumit şir de caractere sau scopul său. Acest tip ar trebui să fie folosit doar pentru dezvoltarea ASF, înseamnă că ai nevoie de asistență tehnică, deoarece nu ești sigur cum să traduci un anumit șir.
- Greșeală în șirul sursă - acest lucru ar trebui folosit doar dacă crezi că șirul original (engleza) este incorect. Foarte rar, dar nu toţi nici vorbim, engleză nu ezitați să o folosiți dacă aveți o idee generală despre cum ar putea fi îmbunătățită. Ca alternativă, aceasta este strâns legată de dezvoltare, puteți utiliza **[GitHub probleme](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** în acest scop, dacă doriți.

---

### Progresul traducerii

Fiecare limbă are două stări de finalizare - traducerea și dovada citirii.

Limba este considerată ca **tradus** atunci când progresul traducerii atinge 100%. În acest moment, fiecare șir localizabil folosit de ASF are o semnificație corectă, ceea ce este grozav. Cu toate acestea, asta nu înseamnă că nu poate fi îmbunătăţit - votul comunitar este activat tot timpul şi încă puteţi sugera o traducere mai bună pentru părţile deja traduse, precum şi votul pentru cele existente. Vă rugăm să reţineţi că limbile traduse în întregime pot scădea sub 100% atunci când schimbăm şirurile existente sau adăugăm altele noi în timpul dezvoltării. Puteți configura notificări de crowdin adecvate dacă doriți să primiți e-mail atunci când se întâmplă acest lucru.

Limbile selectate pot avea o dovadă de cititoare corespunzătoare care validează traducerile și aprobă versiunile finale. Acesta este ultimul pasaj după ce a avut loc traducerea și permite îmbunătățirea în continuare a localizării.

ASF va include un limbaj dat **cât mai curând posibil**, ceea ce înseamnă că nu trebuie aprobat sau chiar tradus 100%. Șirurile reale care vor fi utilizate sunt întotdeauna cele mai populare în ceea ce privește voturile, cu excepția cazului în care probofrecititorul ales a decis altfel (rar). Prin urmare, poți vedea că eforturile tale sunt incluse chiar în următoarea lansare ASF - sistemele noastre automatizate îmbină traducerile din Crowdin înapoi în repo ASF zilnic.

---

## Limbi lipsă

În mod implicit, proiectul ASF are o traducere deschisă doar pentru primele 30 de limbi vorbite în întreaga lume. If you'd like to add another one (or a local dialect to already available one), please **[let us know](https://crowdin.com/messages/create/13177432/240376)** and we'll add it ASAP. Nu vrem să deschidem câteva sute de limbi diferite dacă nimeni nu le va traduce, de aceea o vom limita la un număr corect. Vă rugăm să nu ezitați să ne contactați dacă doriți să traduceți o limbă nelistată, este foarte ușor să adăugați alta. Doar asigură-te că ai bunăvoința și hotărârea de a traduce ASF în limba ta, înainte de a decide să contactezi cu noi.

For a complete list of all available languages that ASF can be translated to, **[click here](https://developer.crowdin.com/language-codes)**.

---

## Pluralizare

Fiecare limbă are propriile sale norme în ceea ce privește pluralizarea. Aceste reguli pot fi găsite pe **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** care specifică numărul lor și condițiile lingvistice exacte.

Facem tot ce ne stă în putință pentru a vă oferi localizare flexibilă, și cât mai mult timp posibil, aceasta va include și reguli de plural. De exemplu, astăzi vom traduce următorul şir în poloneză:

> Lansat {PLURAL:n<unk>{n} luni{n} luni} în urmă

`Cuvântul cheie PLURAL` este tratat într-un mod special, deoarece vă permite să includeți toate formele de plural pe care limba dvs. le sprijină. Dacă vă uitaţi la CLDR, veţi vedea că în engleză există doar 2 formulare cardinale - "unul" şi "altele". Și după cum puteți vedea mai sus, avem ambele definite - `{n} lună` și `{n} luni`.

Cu toate acestea, limba noastră poloneză include de fapt 4 dintre acestea – „unul”, „câteva”, „multe” și „alții”. Aceasta înseamnă că ar trebui să le definim pe toate pentru finalizare. Instrumentele noastre de localizare sunt deja suficient de inteligente pentru a alege formularul de plural adecvat bazat pe regulile limbii, Prin urmare, trebuie doar să le definiţi pe toate la traducere.

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

În acest fel am definit toate cele 4 forme de plural pentru limba poloneză şi deoarece biblioteca noastră de localizare cunoaşte deja regulile exacte, va utiliza în mod corespunzător formularul corect furnizat `{n}` număr.

Nu este obligatoriu să definiți toate formele de plural folosite de limba dvs. Dacă lipsește, biblioteca noastră de localizare va utiliza ultima formă definită în locul său. Este o idee bună să definiți toate formele de plural folosite de limba dumneavoastră, dar în unele cazuri formele de pluralitate rămase ar putea fi aceleaşi ca şi ultima, caz în care nu este nevoie să fie repetate. În exemplul nostru de mai sus a fost obligatoriu, deoarece "altele" forme în limba poloneză de luni de zile este "miesia<unk> ca" şi nu "miesime" ca în "multe".

---

## Wiki

Platforma noastră de crowdin vă permite, de asemenea, să localizați chiar și wiki-ul în sine. Aceasta este o unealtă foarte puternică, pentru că îți permite să creezi o întreagă documentație ASF în limba ta nativă, soluționarea efectivă a ultimei probleme în ceea ce privește localizarea ASF. Împreună cu traducerea programului şi a tuturor componentelor acestuia, localizarea devine completă.

Wiki este un pic special în această privinţă, deoarece este ajutor online unde nu trebuie să rămâi prea mult cu fraza originală. Asta înseamnă că vrei să fii cât mai natural posibil cu limba ta, și să livreze sensul original și ajutorul - să nu rămână neapărat cu corzile originale, cuvintele folosite și punctuația reală. Nu-ți fie teamă să rescrii șirul în ceva mult mai natural pentru limba ta, atâta timp cât păstrați direcția generală și ajutorul incluse în frază.

---

### Link-uri globale

Platforma noastră crowdin îți permite, de asemenea, să adaptezi textul original pentru a-l face să arate spre noi locații (localizate).

ASF include link-uri pe aproape fiecare pagină pentru o navigare mai ușoară, precum și bara laterală din dreapta. Cel mai minunat fapt este că poți edita toate astea "fixează" link-uri către pagini localizate adecvate pentru limba ta. E nevoie să fie un pic mai atent făcând asta, dar e posibil.

De exemplu, ASF **[pagina principală](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)** include un text cum ar fi:

> Dacă sunteți un utilizator nou, vă recomandăm să începeți cu **[ghidul de configurare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)**.

Care este inițial scris ca:

```markdown
Dacă sunteți un utilizator nou, vă recomandăm să începeți cu **[configurare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** ghid.
```

Pe crowdin, primul lucru pe care ar trebui să îl faci este să mergi la setările editorului tău și să te asiguri că etichetele HTML sunt setate pe "Arată" pentru tine. Acest lucru este foarte important dacă decizi să localizezi wiki-ul.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Acum, în timpul traducerii pe mulțime, în funcție de formatare, veți vedea link-uri ASF în text ca:

* Șirul pentru a traduce împreună cu tag-uri HTML (majoritatea șirurilor, unde doar o parte din propoziție este un link)
* Doar un șir de caractere pentru traducere, cu link-ul inclus în `Texte ascunse` -> `` (rare, unde întregul şir de caractere este un link, cel mai frecvent în bara laterală - acestea necesită acces promotor pentru traducere, trist)

În exemplul nostru de mai sus, este primul caz (din moment ce doar "configurarea" este un link), deci în crowdin îl vom vedea ca:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Indiferent de caz, în primul rând ar trebui să copiați șirul sursă și să-l traduceți ca de obicei, lăsând intact HTML complet (dacă este prezent). Acesta ar fi un exemplu de traducere pentru limba poloneză:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Acum, dacă link-ul este un link generic care indică în afara wiki-ului (de ex. la ultima versiune ASF), o poți lăsa așa cum este pentru că nu vrei să o editezi. Îl puteți salva și puteți merge înainte.

Cu toate acestea, în cazul în care link-ul **face** indică mai departe în wiki, ca cel de mai sus, îl puteți corecta pentru a indica către o locație nouă (localizată). Faceți acest lucru prin adăugarea cu atenție `-local` pentru a ținti URL-ul în `<a>` tag, cum ar fi mai jos:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Fiți extrem de atenți la acest lucru și asigurați-vă că URL-ul dvs. există, deoarece dacă faceți o greșeală, acel link va înceta să funcționeze. Dacă ai reușit, ai acum o traducere complet funcțională cu link care arată spre traducere (în cazul nostru `Setting-up-pl-PL`) pagină.

Făcând pașii de mai sus va traduce corect HTML înapoi în markdown:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

Şi în final în text Wiki:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

Când nu este prezent HTML (al doilea caz), este și mai ușor pentru că poți merge la `Texte ascunse` -> ``.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

De acolo puteți corecta cu ușurință link-ul către un punct nou de locație, fără a vă deranja măcar cu HTML:

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Link-uri locale

Pe wiki veţi găsi, de asemenea, link-uri locale care indică o anumită secţiune a documentului. Aceste link-uri includ caracterul `#` , indicând browserul web că ar trebui să se mute spre acea secțiune a documentului.

Acum acestea sunt cazuri speciale, deoarece aceste legături se bazează pe numele secțiunilor din documentul actual. În timp ce pentru URL-uri avem convenția generală de a adăuga `-locale` la URL, și funcționează pretutindeni, numele secțiunilor vor fi traduse de dvs. și de alte persoane, prin urmare trebuie să vă asigurați că acestea indică o locație adecvată.

De exemplu, puteți găsi linkul `#introduction` în secțiunea **[configurația](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#introduction)**:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Din moment ce vom traduce cuvântul "Introducere" în "Wprowadzenie" pentru limba noastră poloneză, Va trebui să corectăm acest link deoarece va înceta să mai funcționeze momentul în care facem asta.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

În acest fel, link-ul nostru local va continua să funcţioneze, deoarece va indica acum secţiunea pe care o folosim. Poți corecta link-urile din interiorul tag-urilor HTML în exact același mod.

---

### Blocuri de cod

Fiți extrem de atenți când traduceți propoziții cu `<code></code>` blocuri în interior. Blocul de cod indică nume de coduri ASF sau termeni care nu ar trebui să fie traduși. De exemplu:

> Acest lucru este util în special dacă ai o mulțime de chei pe care să le revendici și îți garantăm că vei atinge statutul <code>RateLimited</code> înainte de a termina cu tot lotul tău.

După cum puteți vedea, cuvântul `RateLimited` este aici în interiorul unui bloc de cod și indică starea internă a codului ASF care nu ar trebui tradusă. La fel, nu ar trebui să traduceți alte blocuri de cod, cum ar fi numele proprietăților de configurare (de ex. `TradingPreferences`), membrii enum (e. . `Stable` și `Prerelease` opțiunile `UpdateChannel`) și similar.

Cu toate acestea, doar pentru că acele cuvinte nu ar trebui traduse, nu înseamnă că nu poți adăuga traducerea corespunzătoare lângă ele, de exemplu în paranteze.

> Ta funkcja jest wyjątkowo użyteczna w przypadku aktywacji dużej ilości kluczy i gwarancji napotkania statusu <code>RateLimited</code> (zbyt częstej aktywacji) przed ukończeniem całej partii.

După cum puteţi vedea mai sus, am adăugat "zbyt cze<unk> stej aktywacji", literalmente "prea des activare" lângă `RateLimited` pentru a traduce acel status într-un mod prietenos, păstrând în același timp ASF original, ceea ce înseamnă că utilizatorul poate vedea în timpul utilizării programului. În acelaşi mod puteţi traduce/explica alte cazuri similare de diferite cuvinte şi propoziţii.

Dacă crezi că ceva nepotrivit este inclus într-un bloc de cod, sau că există un text care nu este într-un bloc de cod, dar ar trebui să fie în interiorul lui, Nu ezitaţi să cereţi mulţimii noastre prin crearea unui **[problemă](#issues)**. Acest lucru servește și ca exemplu practic de utilizare a unei legături locale.

---

## Sala de faimă

Am dori să ne arătăm eterna recunoștință față de oamenii care și-au petrecut o parte semnificativă din timpul și voința de a îmbunătăți localizarea ASF. Efortul lor este incredibil şi vă puteţi bucura de traduceri complete, inclusiv wiki, mai ales mulţumită acestora. Ca simbol al aprecierii, tuturor persoanelor listate aici li se oferă acces gratuit la **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** la o solicitare **[](https://crowdin.com/messages/create/13177432/240376)**.

| Contribuitor                                               | Limbi            |
| ---------------------------------------------------------- | ---------------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, spaniol  |
| **[Dead_Sam](https://crowdin.com/profile/Dead_Sam)**       | Portugheză (BR)  |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | Chineză (CN)     |
| **[Taki Dragoni](https://crowdin.com/profile/dragontaki)** | Chineză (TW)     |
| **[LittleFreak](https://crowdin.com/profile/littlefreak)** | Germană          |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | Rusă, ucraineană |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT, german   |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | Chineză (HK)     |

Vă mulţumim tuturor pentru îmbunătăţirea calităţii localizării noastre ASF!