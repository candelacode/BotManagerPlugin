# Performanță

Obiectivul principal al ASF este acela de a crește cât mai eficient posibil, pe baza a două tipuri de date pe care le poate utiliza - un set mic de date furnizate de utilizator care este imposibil de ghicit/verificat de ASF în sine, și seturi mai mari de date care pot fi verificate automat de ASF.

În modul automat, ASF nu îți permite să alegi jocurile care ar trebui să fie cultivate, nici nu îți permite să schimbi algoritmul farmaceutic al cărților. **ASF știe mai bine decât tine ce ar trebui să facă și ce decizii ar trebui să ia pentru a ferma cât mai repede posibil**. Obiectivul tău este să setezi corect proprietățile de configurare, deoarece ASF nu le poate ghici pe cont propriu, totul este acoperit.

---

Acum ceva timp Valve a schimbat algoritmul pentru picăturile de cartele. Din acel punct de vedere, putem clasifica conturile de aburi pe două categorii: acelea **cu** cartela este restricţionată, iar cele **fără**. Singura diferență dintre aceste două tipuri este faptul că conturile cu picături restricționate de carduri nu pot obține nici un card de la un joc dat până când nu joacă un joc dat pentru cel puțin `X` ore. Se pare că vechile conturi care nu au solicitat rambursarea au primit **un card nerestricționat scade**, în timp ce conturile noi și cei care au solicitat rambursarea au **restricționat card scade**. Acest lucru este însă doar teoretic și nu ar trebui să fie considerat în regulă. De aceea nu există **niciun răspuns evident**, și ASF se bazează pe **dvs.** spunându-l ce caz este potrivit pentru contul dvs.

---

În prezent, ASF include doi algoritmi agricoli:

**`Algoritmul Simplu`** funcționează cel mai bine pentru conturile care au picături fără restricții cu cardul. Acesta este algoritmul primar folosit de ASF. Botul găseşte jocurile la fermă şi le exploatează individual până când toate cărţile sunt abandonate. Acest lucru se datorează faptului că numărul cărţilor scade atunci când creşterea mai multor jocuri este aproape de zero şi total ineficientă.

**`Complexul`** este un nou algoritm care a fost implementat pentru a ajuta conturile restricționate să își maximizeze profiturile. ASF va utiliza în primul rând algoritmul standard **`Simplu`** pentru toate jocurile care au trecut pe lângă `HoursUntilCardDrops` ore de joacă, atunci, dacă nu au rămas jocuri cu >= `OrsUntilCardDrops` ore, va ferma toate jocurile (până la `32` limit) cu < `HoursUntilCardDrops` ore rămase simultan, până când oricare dintre ele lovește `HoursUntilCardDrops` ore, apoi ASF va continua bucla de la început (folosește **`Simplul`** pe acel joc, Reveniţi la simultan pe < `HoursUntilCardDrops` şi aşa mai departe). Putem folosi agricultura jocurilor multiple în acest caz pentru orele de întâlnire a jocurilor de care avem nevoie pentru a le cultiva la valoarea potrivită. Rețineți că în timpul orelor de creștere, ASF **nu** carduri de fermă, astfel încât nu va verifica nici o picătură de carte în perioada respectivă (pentru motivele menționate mai sus).

În prezent, ASF alege algoritmul de creștere a cărților bazat doar pe `HoursUntilCardDrops` proprietate de configurare (care este setat de **tu**). Dacă `HoursUntilCardDrops` este setat la `0`, **`Algoritmul`** va fi folosit în caz contrar **`Algoritmul Complexului`** va fi folosit în schimb - configurat să lovească timpul de joacă în toate jocurile la un număr de ore înainte de a le cultiva pentru picăturile cu cardul.

---

### **Nu există niciun răspuns evident care algoritm este mai bun pentru tine**.

Acesta este unul dintre motivele pentru care nu alegeți algoritmul de creștere al cărților, în schimb, spuneți ASF dacă contul a restricționat sau nu. If account has non-restricted drops, **`Simple`** algorithm will **work better** on that account, as we won't be wasting time on bringing all games to `X` hours - cards drop ratio is close to 0% when farming multiple games. Pe de altă parte, în cazul în care contul tău a scăzut restricționat, **`Algoritmul Complex`** va fi mai bun pentru tine, pentru că nu are rost să cultivăm solo dacă jocul nu a ajuns la `HoursUntilCardDrops` ore încă - aşa că vom cultiva mai întâi **timpul de joacă** , **apoi carduri** în modul singur.

Nu setați orbește `HoursUntilCardDrops` numai pentru că cineva v-a spus să faceți teste, comparați rezultatele și pe baza datelor primite, decideți care opțiune ar trebui să fie mai bună pentru dvs. Dacă pui un efort minim în asta, te vei asigura că ASF funcționează cu o eficiență maximă posibilă pentru contul tău, care este probabil ceea ce doriți, având în vedere că citiți această pagină wiki chiar acum. Dacă ar exista o soluție care să funcționeze pentru toată lumea, nu ți-ar fi dat posibilitatea de a alege - ASF ar decide el însuși.

---

### Care este cel mai bun mod de a afla dacă contul tău este restricționat?

Asigură-te că ai niște jocuri cu **nici un joc înregistrat** pentru a ferma, preferabil 5+, și rulează ASF cu `HoursUntilCardDrops` din `0`. Ar fi o idee bună dacă nu ai cânta nimic în timpul perioadei de producție pentru rezultate mai precise (cel mai bun mod de a rula ASF în timpul nopții). Permiteți ASF să exploateze acele 5 jocuri, și după aceea să verificați jurnalul pentru rezultate.

ASF precizează clar când a fost abandonat un card pentru un anumit joc. Ești interesat de cea mai rapidă picătură de card realizată de ASF. De exemplu, în cazul în care contul tău nu este restricționat, o primă picătură de card ar trebui să aibă loc după aproximativ 30 de minute de la începerea activității de cultivare. Dacă observați **cel puțin un joc** care a renunțat la card în cele 30 de minute inițiale, atunci acesta este un indicator că contul tău este **nu** restricționat și ar trebui să folosească `HoursUntilCardDrops` din `0`.

Pe de altă parte, dacă observaţi că **la fiecare** joc ia cel puţin `X` cu cel puţin un interval de ore înainte de a pierde prima carte, apoi acesta este un indicator la care trebuie să setați `HoursUntilCardDrops`. Majoritate (dacă nu toate) a utilizatorilor restricționați necesită cel puțin `3` ore de redare pentru ca cartonașele să poată scădea, și aceasta este, de asemenea, valoarea implicită pentru setarea `HoursUntilCardDrops`.

Amintiţi-vă că jocurile pot avea o rată de scădere diferită, de aceea ar trebui să testezi dacă teoria ta este corectă cu un joc de tip **cel puțin** 3, de preferință 5+ pentru a vă asigura că nu ați ajuns la rezultate false printr-o coincidență. A card drop of one game in less than an hour is a confirmation that your account **is not** restricted and can use `HoursUntilCardDrops` of `0`, but for confirming that your account **is** restricted, you need at least several games that are not dropping cards until you hit a fixed mark.

Este important de notat că în trecut `HoursUntilCardDrops` a fost doar `0` sau `2`, și de aceea ASF a avut o singură proprietate `CardDropsRestricted` care a permis comutarea între aceste două valori. Cu modificările recente am observat că nu numai majoritatea utilizatorilor necesită `3` ore în locul `2` anterior acum, dar și că `HoursUntilCardDrops` este acum dinamic și poate atinge orice valoare pe cont.

În cele din urmă, desigur, decizia depinde de dumneavoastră.

Şi pentru a înrăutăţi şi mai mult - am experimentat cazuri în care oamenii au trecut de la o stare restricţionată la o stare nerestricţionată şi invers - fie din cauza bug-ului Steam (da, da, avem multe dintre acestea) sau din cauza unor ajustări logice ale lui Valve. Așadar, chiar dacă ați confirmat că contul dvs. este restricționat (sau nu), nu credeți că va rămâne așa - pentru a trece de la nerestricționat la restricționat este suficient pentru a solicita o rambursare. Dacă simțiți că valoarea stabilită anterior nu mai este potrivită, puteți să o re-testați și să o actualizați în consecință.

---

În mod implicit, ASF presupune că `HoursUntilCardDrops` este `3`, ca efect negativ al stabilirii acestuia la `3` atunci când acesta ar trebui să fie mai mic decât în sens invers. Asta pentru că, în cel mai rău caz posibil, vom irosi `3` ore de agricultură pe jocuri `32` , în comparație cu irosirea `3` ore de agricultură pentru fiecare joc dacă `HoursUntilCardDrops` a fost setată implicit la `0`. Cu toate acestea, ar trebui să ajustezi această variabilă pentru a se potrivi cu contul tău pentru eficiență maximă, pentru că aceasta este doar o ghicire oarbă bazată pe potențiale inconveniente și majoritatea utilizatorilor (așa că încercăm să alegem "mai puțin rău" în mod implicit).

În prezent, două algoritmi de mai sus sunt suficiente pentru toate scenariile de cont posibile în prezent; Pentru a fi exploatat cât mai eficient posibil, de aceea nu este planificată adăugarea altor unele.

Este frumos să reții că ASF include și modul manual de farmare care poate fi activat de comanda `play`. Poți citi mai multe despre asta în **[comenzi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

## Lituri cu abur

Algoritmul de picături al cartonașelor nu funcționează întotdeauna așa cum ar trebui, și este posibil să se întâmple mai multe bagaje de Steam, cum ar fi abandonarea unor carduri în conturi restricționate, renunțarea la închiderea / schimbarea jocului; cărţile nu scapă deloc când se joacă şi la fel.

Această secțiune este în principal pentru persoane care se întreabă de ce ASF nu face **X**, cum ar fi trecerea rapidă de la jocuri la carduri de fermă mai rapid.

Ce este un **Steam glitch** - o acţiune specifică declanşând un comportament **nedefinit** , care este **neintenţionat, fără documentaţie şi considerat o deficienţă logică**. Este **nesigur prin definiția**, ceea ce înseamnă că nu poate fi reprodus în mod fiabil cu un mediu de testare curat, și, prin urmare, codificate fără a recurge la hack-uri care ar trebui să ghicească când are loc o strălucire și cum să lupte cu ea/abuzează de ea. De obicei, este temporar până când dezvoltatorii remediază defectele logice, deși unele erori pot rămâne neobservate pentru o perioadă foarte lungă de timp.

Un bun exemplu pentru ceea ce este considerat a fi **un glitch** nu este acea situație neobișnuită de a renunța la o carte atunci când jocul este închis, care pot fi abuzate la un anumit grad cu funcția de sărire la meci a stăpânului inactiv

- **Comportament nedefinit** - nu poți spune dacă vor fi aruncate 0 sau 1 cartonașe când declanșezi strălucirea.
- **Nu a fost destinat** - bazat pe experiența și comportamentul rețelei Steam care nu are ca rezultat același comportament atunci când se trimite o singură cerere.
- **Fără documentaţie** - este clar documentat pe site-ul Steam cum sunt obţinute cardurile, și **în fiecare loc** este clar că este obținut prin **jucând**, NU închideți jocurile, obțineți realizări, comutați sau lansați 32 de jocuri simultan.
- **considerat ca un flaw logic** - închiderea jocului(elor) sau schimbarea lor nu ar trebui să aibă nici un rezultat pe cardurile aruncate care sunt clar declarate ca fiind obținute prin **câștigând timp de joacă**.
- **Neîncredere prin definiție, nu poate fi reprodusă în mod fiabil** - nu funcționează pentru toată lumea, şi chiar dacă a funcţionat pentru dumneavoastră o dată, nu mai putea funcţiona pentru a doua oară.

Acum, odată ce ne-am dat seama ce este glitch Steam și faptul că cărțile aruncate când jocul se închide **este** unu, putem trece la al doilea punct - **ASF nu abuzează în niciun fel de rețeaua Steam prin definiție, şi face tot posibilul pentru a se conforma cu Steam ToS, protocoalele sale şi ceea ce este general acceptat**. Reţeaua de spamming Steam cu cereri constante de deschidere/închidere a jocului poate fi considerată un **

[](https://en.wikipedia.org/wiki/Denial-of-service_attack)</strong> şi **încalcă direct [Steam Online Conduct](https://store.steampowered.com/online_conduct/?l=english)**.</p> 



> În calitate de abonat la Steam, sunteți de acord să respectați următoarele reguli de conduită.
> 
> Nu veți face:
> 
> Institutul atacă un server Steam sau întrerupe Steam.

Nu contează dacă poți declanșa glitch Steam cu alte programe (cum ar fi IM), și nu contează dacă sunteți de acord cu noi și luați în considerare un astfel de comportament ca un atac DoS, sau nu - este la latitudinea lui Valve să judece acest lucru, dar dacă îl considerăm ca exploatare/abuz de comportament neintenționat prin intermediul unor cereri excesive de rețea Steam, apoi poți fi destul de sigur că Valve va avea o vedere similară asupra acestui lucru.

ASF este **niciodată** să profite de Steam exploits, abuzuri, hack-uri sau orice altă activitate pe care o vedem ca **ilegal sau nedorit** conform Steam ToS, Steam Online Conduct sau orice altă sursă de încredere care ar putea indica faptul că activitatea ASF este nedorită de rețeaua Steam, aşa cum se menţionează la **[contribuind cu secţiunea](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)**.

Dacă vrei cu orice preț să îți riști contul Steam pentru a cultiva câteva cărți mai repede decât de obicei. apoi, din păcate, ASF nu va oferi niciodată ceva de genul acesta în mod automat, cu toate că încă mai ai `play` **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** care poate fi folosit ca un instrument pentru a face tot ce îți dorești în ceea ce privește interacțiunea cu rețeaua Steam. Nu recomandăm să profităm de bagajele Steam și să le exploatăm pentru propriul câștig - nu doar cu ASF, dar cu orice altă unealtă de asemenea. În cele din urmă, totuși, este contul tău, şi alegerea dumneavoastră ce doriţi să faceţi cu ea - ţineţi cont de faptul că v-am avertizat.