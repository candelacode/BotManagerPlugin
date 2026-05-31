# Tranzacționare

ASF include suport pentru tranzacții Steam non-interactive (offline). Atât primirea (acceptarea/declinul), cât și trimiterea de tranzacții sunt disponibile imediat și nu necesită configurație specială, dar evident necesita un cont Steam nelimitat (cel care a cheltuit deja 5$ în magazin). Doar funcționalitatea limitată de tranzacționare este disponibilă pentru conturi restricționate.

---

## Logica

First of all, it's possible to disable **all** incoming trade offers, by using `DisableIncomingTradesParsing` flag in `BotBehaviour`. Folosind asta, după cum implică numele, va dezactiva toate funcționalitățile legate de parcarea de tranzacții primite, care include sub logica implicită, precum și toate caracteristicile suplimentare disponibile care depind de reacția la oferta comercială primită. Deoarece setările implicite sunt deja neinvazive, ar trebui să luați în considerare utilizarea acestei opțiuni numai dacă nu aveți absolut nicio intenție din partea ASF de a face ceva legat de tranzacțiile primite.

Mai jos explică logica atunci când este activată analiza de intrare a ofertei de tranzacționare, care este opțiunea implicită.

ASF va accepta întotdeauna toate tranzacțiile, indiferent de articole, trimise de la utilizatorul cu acces `Master` (sau mai mare) la bot. Acest lucru permite nu numai jefuirea cu ușurință a cartelelor cu aburi cultivate de roboți, dar de asemenea permite administrarea cu ușurință a obiectelor Steam care bot stash-uri în inventar - inclusiv a celor din alte jocuri (cum ar fi CS:GO).

ASF va respinge oferta de tranzacționare, indiferent de conținut, de la orice utilizator (non-master) care este pe lista neagră din modulul de tranzacționare. Lista neagră este stocată în denumirea standard `BotName. b` bază de date, și poate fi gestionată prin `tb`, Comenzi</a></strong> `tbadd` și `tbrm` **

. Aceasta ar trebui să funcţioneze ca o alternativă la blocarea standard a utilizatorilor oferită de Steam - utilizaţi cu precauţie.</p> 

ASF va accepta toate tranzacțiile de tip `loot` trimise între boți, cu excepția cazului în care `DontAcceptBotTrades` este specificat în `TradingPreferences`. Pe scurt, valoarea implicită pentru `TradingPreferences` de `None` va determina ASF să accepte automat tranzacții de la utilizator cu acces `Master` la bot (explicat mai sus), precum și toate donațiile de la alți roboți care participă la procesul ASF.

Când activezi `AcceptDonations` în `TradingPreferences`, ASF va accepta, de asemenea, orice tranzacție de donație - o tranzacție în care contul de bot nu pierde niciun element. Această proprietate afectează numai conturile non-bot, deoarece conturile de bot sunt afectate de `DontAcceptBotTrades`. `AcceptDonațiile` îți permit să accepți cu ușurință donații de la alte persoane, dar și boți care nu participă la procesul ASF.

Este frumos să reții că `AcceptDonations` nu necesită **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, pentru că nu este necesară confirmarea dacă nu pierdem niciun obiect.

De asemenea, poți personaliza în continuare capacitățile de tranzacționare ASF prin modificarea `TradingPreferences` în consecință. Una dintre funcțiile principale `TradingPreferences` este opțiunea `SteamMatcher` care va determina ASF să utilizeze logica încorporată pentru acceptarea tranzacțiilor care vă ajută să completați insignele lipsă, care este utilă în special în cooperare cu listarea publică **[SteamMatcher](https://www.steamtradematcher.com)**, dar care poate funcționa și fără aceasta. Este descris în continuare mai jos.



---



## `SteamTradeMatcher`

Când `SteamTradeMatcher` este activ, ASF va utiliza un algoritm destul de complex pentru a verifica dacă tranzacția trece de regulile STM și este cel puțin neutră față de noi. Logica reală este următoarea:

- Respinge tranzacționarea dacă pierdem ceva în afară de tipurile de obiecte specificate în `MatchableTypes`.
- Respinge tranzacția dacă nu primim cel puțin același număr de obiecte pentru fiecare joc, pentru fiecare tip și per raritate.
- Respingeți tranzacționarea dacă utilizatorul cere carduri speciale de vânzare Steam vară/iarnă, și are un card de tranzacționare.
- Respingeți tranzacția în cazul în care durata de păstrare a tranzacției depășește `MaxTradeHoldDuration` proprietatea globală de configurare.
- Respinge tranzacția dacă nu avem `PotrichEverything` setat, și este mai rău decât neutru pentru noi.
- Acceptați comerțul dacă nu l-am respins prin niciunul dintre punctele de mai sus.

Este frumos să rețineți că ASF suportă și plata excesivă - logica va funcționa corect atunci când utilizatorul adaugă ceva în plus la tranzacție, atât timp cât sunt îndeplinite toate condițiile de mai sus.

Primele 4 respingeri trebuie să fie evidente pentru toată lumea. Ultimul include o logică a duzelor care verifică starea actuală a inventarului nostru și care este stadiul comerțului.

- Tranzacționarea este **bun** dacă progresul nostru spre a seta progresul de finalizare. Exemplu: A (înainte) -> B (după)
- Comerțul este **neutru** dacă progresul nostru către finalizarea setării rămâne în joc. Exemplu: A B (înainte de ) -> A (după)
- Tranzacționarea este **rău** dacă progresul nostru către setarea finalizării scade. Exemplu: A C (înainte) -> A (după)

STM operează doar pe tranzacții bune, ceea ce înseamnă că utilizatorul care utilizează STM pentru a potrivi duble ar trebui să sugereze întotdeauna doar tranzacții bune pentru noi. Cu toate acestea, ASF este liberală și acceptă, de asemenea, tranzacții neutre, pentru că în aceste tranzacţii nu pierdem nimic, aşa că nu există niciun motiv real pentru care să le refuzăm. Acest lucru este util în special pentru prietenii tăi, deoarece ei pot schimba cardurile excesive fără a folosi STM deloc, atâta timp cât nu pierzi nici un progres stabilit.

În mod implicit, ASF va respinge tranzacțiile greșite - aceasta este aproape întotdeauna ceea ce doriți ca utilizator. Cu toate acestea, opțional poți activa `MatchEverything` în `TradingPreferences` pentru a face ASF să accepte toate tranzacțiile dupe, inclusiv **cele rele**. Acest lucru este util numai dacă doriți să rulați un bot de tranzacționare 1:1 în contul dvs., după cum înțelegi că **ASF nu te va mai ajuta să avansezi către finalizarea insignei, și te faci predispus să pierzi întreg setul final pentru N dupes de pe același card**. If you want to intentionally run a trade bot that is **never** supposed to finish any set, and should offer its whole inventory to every interested user, then you can enable that option.

Indiferent de `TradingPreferences`pe care l-ai ales, o tranzacție respinsă de ASF nu înseamnă că nu o poți accepta singur. Dacă ați păstrat valoarea implicită a lui `BotBehaviour`, care nu include `RejectInvalidTrades`, ASF va ignora pur și simplu acele tranzacții - permițându-ți să te decizi dacă ești interesat de ele sau nu. Același lucru este valabil și pentru tranzacțiile cu elemente din afara `Potrivire`, la fel ca orice altceva - modulul ar trebui să vă ajute să automatizați tranzacțiile STM, să nu decidă ce este un comerţ bun şi ce nu. Singura excepție de la această regulă este atunci când vorbești despre utilizatori pe lista neagră a modulului de tranzacționare folosind comanda `tbadd` - tranzacții de la acești utilizatori sunt respinse imediat indiferent de setările `BotBehaviour`.

Este foarte recomandat să utilizaţi **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** când activaţi această opţiune. deoarece această funcţie îşi pierde întregul potenţial dacă decideţi să confirmaţi manual fiecare schimbare. `SteamTradeMatcher` va funcționa corect chiar și fără posibilitatea de a confirma tranzacții, dar poate genera restante de confirmări dacă nu le accepți la timp.