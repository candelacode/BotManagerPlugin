# ItemsMatcherPlugin

`ItemsMatcherPlugin` este plugin-ul oficial ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** care extinde ASF cu caracteristici ASF STM listare. În special, aceasta include `PublicListing` în **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** şi `Potrivire` în **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. ASF vine cu `ItemsMatcherPlugin` grupat împreună cu lansarea, deci este gata pentru utilizare imediat.

---

## `Publicare`

Listarea publică, după cum implică numele, este listarea roboților ASF STM disponibili în prezent. Este situat pe **[site-ul nostru](https://asf.justarchi.net/STM)**, gestionat automat și utilizat ca serviciu public atât pentru utilizatorii ASF care utilizează `Potrivire`, precum și utilizatori ASF și non-ASF pentru potrivire manuală.

Pentru a fi enumerat, aveți un set de cerințe de îndeplinit. Cel puțin, trebuie să aveți permis `PublicListing` în `RemoteCommunication` (setare implicită), `SteamTradeMatcher` activat în `TradingPreferences`, **[inventarul public](https://steamcommunity.com/my/edit/settings)** setările de confidenţialitate un cont **[nerestricționat](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** și **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** activ. Cerințele suplimentare includ 2FA active de cel puțin 15 zile, ultima modificare a parolei mai mult de 5 zile în urmă, lipsa unor limitări ale contului, cum ar fi blocajele, interdicțiile economice și interdicțiile de tranzacționare. Bineînțeles, trebuie să ai și cel puțin un obiect (tranzacționabil) în inventarul tău de la adresa `Meciuri`specificate, cum ar fi cardurile de tranzacționare. În plus, boții cu mai mult de `500000` elemente nu sunt acceptate din cauza cheltuielilor de regie excesive, Îți recomandăm să împarți inventarul tău în mai multe conturi în acest caz.

În timp ce `PublicListing` este activat în mod implicit, vă rugăm să reţineţi că **nu** va fi afişat pe site dacă nu îndepliniţi toate cerinţele, în special `SteamTradeMatcher`, care nu este activat în mod implicit. Pentru persoanele care nu îndeplinesc criteriile, chiar dacă au păstrat `PublicListing` activat, ASF nu comunică cu serverul în niciun fel. Listarea publică este, de asemenea, compatibilă numai cu ultima versiune stabilă a ASF și poate refuza afișarea boților învechiți, mai ales dacă lipsesc funcţionalităţi de bază care se găsesc doar în versiunile mai noi.

### Cum funcţionează exact

ASF trimite datele inițiale o dată după autentificare, care conține toate proprietățile listării publice utilizează. Apoi, la fiecare 10 minute ASF trimite unul, o cerere foarte mică de "bătăi ale inimii" care notifică serverului nostru că bot-ul este încă în funcțiune. Dacă dintr-un anumit motiv bătăile inimii nu au ajuns, de exemplu din cauza problemelor de relaţionare, apoi ASF va reîncerca să o trimită în fiecare minut, până când serverul o înregistrează. În acest fel, serverul nostru știe cu precizie ce roboți rulează încă și care sunt gata să accepte ofertele de tranzacționare. ASF va trimite, de asemenea, anunțul inițial la nevoie, de exemplu dacă detectează că inventarul nostru s-a schimbat de la cel anterior.

Afișăm toate conturile ASF eligibile care au fost active în **ultimele 15 minute**. Utilizatorii sunt sortați în funcție de utilitatea lor relativă - `Potriviți boții` care sunt afișați cu `Orice` banner care acceptă toate tranzacțiile de 1:1, apoi jocurile unice contează şi, în final, obiectele contează.

### API

ASF listare STM acceptă doar boți ASF pentru moment. Pentru moment, nu există nicio modalitate de a lista roboții terți pe lista noastră, pentru că nu le putem revizui cu ușurință codul și pentru a ne asigura că îndeplinesc întreaga noastră logică de tranzacționare. Prin urmare, participarea la listă necesită cea mai recentă versiune ASF stabilă, deși poate rula cu custom **[plugin-uri](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

Pentru consumatorii listării, avem un punct **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** final pe care îl poți folosi. Acesta include toate datele pe care le avem, în afară de inventarele utilizatorilor care fac parte exclusiv din caracteristica `Potrivire`.

### Politica de confidenţialitate

Dacă sunteți de acord să fiți listat în lista noastră, activând `SteamMatcher` și nerefuzând `PublicListing`, după cum se specifică mai sus, vom stoca temporar unele dintre detaliile contului tău de Steam pe serverul nostru pentru a oferi funcționalitatea așteptată.

Informaţiile publice (expuse de Steam fiecărei părţi interesate) includ:
- Identificatorul tău de Steam (în forma 64-biți, pentru generarea link-urilor)
- Porecla ta (pentru scopuri de afișare)
- Avatarul tău (hash, folosit pentru afișare)

În mod condiţionat, informaţiile publice (expuse de Steam oricărei părţi interesate dacă îndeplineşti cerinţele de listare) includ:
- Inventarul tău **[](https://steamcommunity.com/my/inventory/#753_6)** (astfel încât oamenii să poată folosi `` în mod activ împotriva articolelor tale).

Informațiile private (sunt necesare pentru furnizarea funcționalității) includ:
- **[simbolul tău de tranzacționare](https://steamcommunity.com/my/tradeoffers/privacy)** (astfel încât oamenii din afara listei tale de prieteni îți pot trimite tranzacții)
- Setarea `Potrivire de tip` (pentru scopuri de afișare și potrivire)
- Setarea `Potrivire` (pentru scopuri de afișare și potrivire)
- Setarea `MaxTradeHoldDuration` a dvs. (astfel încât alte persoane să știe dacă sunt dispuse să își accepte tranzacțiile)

Din momentul în care încetezi să mai folosești lista noastră (anunț), datele tale devin indisponibile publicului larg în maximum 15 minute, și altfel este păstrat pe serverul nostru timp de maximum două săptămâni - totul este șters automat după acea perioadă. Pentru ca acest lucru să se întâmple nu este necesară nicio acţiune.

---

## `Potrivire`

`Setarea` corespunde versiunii active **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** inclusiv potrivirea interactivă în care botul va trimite tranzacțiile către alte persoane. Poate funcționa în mod independent, sau împreună cu setarea `SteamTradeMatcher`. Această caracteristică are nevoie de `LicenseID` pentru a fi setată, deoarece folosește server terț și resurse plătite pentru a opera.

Pentru a utiliza această opțiune, aveți un set de cerințe de îndeplinit. Cel puţin, trebuie să ai un cont **[nerestricţionat](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** , **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** activ și cel puțin un tip valid în Meciul `Potrivire`, cum ar fi cardurile de tranzacționare. Cerințele suplimentare includ 2FA active de cel puțin 15 zile, ultima modificare a parolei mai mult de 5 zile în urmă, lipsa unor limitări ale contului, cum ar fi blocajele, interdicțiile economice și interdicțiile de tranzacționare.

Dacă îndepliniți toate cerințele de mai sus, ASF va comunica periodic cu **[listarea publică STM ASF](#publiclisting)** pentru a se potrivi activ boților disponibili în prezent.

În timpul potrivirii, bot-ul ASF își va prelua propriul inventar, apoi să comunice cu serverul nostru pentru a găsi toate meciurile posibile cu `MatchableTypes` de la alții, momentan disponibili boți. Mulțumită comunicării directe cu serverul nostru, acest proces necesită o singură solicitare și avem informații imediate dacă un bot disponibil ne oferă ceva interesant - dacă se găsește o potrivire, ASF va trimite și confirma oferta de tranzacționare automat.

Acest modul ar trebui sa fie transparent. Potrivirea va începe în aproximativ `1` oră de la începerea ASF și se va repeta singur `6` ore (dacă este necesar). `Caracteristica` se doreşte a fi folosită ca o măsură periodică, pe termen lung, pentru a ne asigura că ne îndreptăm în mod activ spre finalizarea seturilor, cu toate acestea, persoanele care nu rulează ASF 24/7 pot de asemenea lua în considerare folosirea unui `meci` **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Utilizatorii țintă ai acestui modul sunt conturi primare și conturi de alt alt stash, deși poate fi folosit de orice bot care nu este setat la `Potrivire`. În plus, boții cu mai mult de `500000` elemente nu sunt acceptați pentru potrivire din cauza suprasolicitării excesive, Îți recomandăm să împarți inventarul tău în mai multe conturi în acest caz.

ASF face tot posibilul pentru a minimiza cantitatea de cereri și presiunea generate de utilizarea acestei opțiuni, în același timp, maximizarea eficienței corelării cu limita superioară. Algoritmul exact de a alege boții să se potrivească și altfel să organizeze întregul proces, este detaliile de implementare ale ASF și se pot schimba în ceea ce privește feedbackul, situația și posibilele idei viitoare.

Versiunea curentă a algoritmului face ASF să prioritizeze `Orice` mai întâi, în special în cele care se confruntă cu o mai mare diversitate a jocurilor de noroc. Atunci când rămâne fără boți de la `Orice` , ASF se va muta la cei din `Târgul` cu aceeași regulă de diversitate. ASF va încerca să se potrivească cu fiecare bot disponibil cel puțin o dată, pentru a se asigura că nu lipsesc pe un posibil set de progres.

`Potrivire` ia în considerare boţii pe care i-ai blocat de la tranzacţionare prin `tbadd` **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** şi nu va încerca să îi potrivească în mod activ. Acest lucru poate fi folosit pentru a spune ASF ce boți nu ar trebui să se potrivească niciodată, chiar dacă ar avea potențiale avantaje pe care să le folosim.

De asemenea, ASF va depune toate eforturile pentru a se asigura că ofertele de tranzacționare sunt puse în aplicare. În următoarea cursă, care se întâmplă de obicei în 6 ore, ASF va anula orice oferte de tranzacționare în așteptare care nu au fost încă acceptate, și deprioritizați steamID-urile care iau parte la ele pentru a prefera, sperăm, mai întâi boții mai activi. Totuși, dacă boții deprioritizați sunt ultimii care au nevoie de meci, vom încerca să le potrivim (din nou).

---

### De ce am nevoie de un `LicenseID` pentru a folosi `Potrivire`? Nu a fost gratuit înainte?

ASF este și rămâne gratuit și open-source, așa cum a fost înființat la începutul proiectului, în octombrie 2015. Codul sursă al plugin-ului `ItemsMatcher` și, prin urmare, `Potrivire` este disponibil în depozitul nostru, în timp ce programul ASF este în întregime non-comercial, nu câștigăm nimic din contribuțiile la acesta, construind sau publicând. În ultimii 7 ani, ASF a beneficiat de o dezvoltare semnificativă, și încă se îmbunătățește și se îmbunătățește cu fiecare lansare lunară stabilă de către o singură persoană; **[JustArchi](https://github.com/JustArchi)** - fără șiruri atașate. Singura finanțare pe care o primim este din donații neobligatorii care provin de la utilizatorii noștri.

Pentru o perioadă foarte lungă de timp, până în octombrie 2022, caracteristica `Potrivire` a făcut parte din nucleul ASF și a fost disponibilă pentru toată lumea pentru a-l folosi. În octombrie 2022, Valve, compania din spatele Steam, a stabilit limite de rată foarte severe pentru inventarele altor boți - care au făcut funcționalitatea anterioară complet ruptă, fără posibilitatea unei soluţii pentru rezolvarea acestei probleme. Prin urmare, din cauza faptului că această caracteristică a devenit complet desfiinţată fără nicio şansă de a fi fixă, a trebuit să fie eliminat din nucleul ASF ca fiind învechit.

`Potrivire` a fost reînviat ca parte a plugin-ului oficial `ItemsMatcher` care îmbunătățește ASF cu funcționalitatea cardurilor active de potrivire, bazându-se pe un concept complet reprelucrat. Resurrecting `Caracteristica` necesară de la noi **extraordinar de multă muncă** pentru a crea ASF backend, serviciu complet nou găzduit pe un server, cu mai mult de o sută de proxy-uri plătite atașate pentru a rezolva inventarele, toate acestea pentru a permite clienților ASF să utilizeze `Potrivire` ca înainte. Având în vedere volumul de muncă implicat, precum și resursele care nu sunt gratuite și necesită plata lunară de către noi (domeniu, server, proxy-uri), Am decis să oferim această funcționalitate sponsorilor noștri, adică, persoane care sprijină deja lunar proiectul ASF, datorită cărora putem pune la dispoziție resursele plătite respective.

Scopul nostru nu este să profităm de ea, ci mai degrabă, acoperiți **costurile lunare** care sunt legate exclusiv de oferirea acestei opțiuni - de aceea le oferim de fapt pentru nimic, dar trebuie să taxăm puțin pentru asta deoarece nu putem plăti sute de dolari din buzunarele noastre lunare, doar pentru a o face disponibilă. Nici nu suntem în poziţia de a discuta despre preţ, este Valve care ne-a forţat aceste costuri, iar alternativa este de a nu avea o astfel de caracteristică disponibilă; care este desigur aplicabil în cazul în care decideți, indiferent de motiv, că nu puteți justifica utilizarea plugin-ului nostru în acești termeni.

În orice caz, înțelegem că `Potrivire` nu este pentru toată lumea, şi sperăm că veţi înţelege de asemenea de ce nu o putem oferi gratis. Dacă nimeni nu ar fi interesat să contribuie la acoperirea costurilor acestei funcţii, pur şi simplu nu ar exista pentru început, cum am fi forţat să reducem cheltuielile lunare pe care nimeni nu este dispus să le întreţină. Din fericire, suntem într-o poziţie mai bună decât aceasta şi vă puteţi hotărî dacă doriţi să utilizaţi `MatchActively` în termenii respectivi sau nu.

---

### Cum pot obține acces?

`ItemsMatcher` este oferit ca parte a nivelului lunar de sponsor de 5+ USD pe **[GitHub](https://github.com/sponsors/JustArchi)** al JustArchiului. Este posibil de asemenea să devii sponsor unic; deși în acest caz licența va fi valabilă numai pentru o lună (cu posibilitatea prelungirii în același mod). Odată ce devii sponsor de $5 nivel (sau mai mare), citește secțiunea **[configurația](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** pentru a obține și completa `LicenseID`. După aceea, trebuie doar să activați `Potrivire` în `TradingPreferences` botului dvs. ales.

Licența vă permite să trimiteți un număr limitat de cereri către server. $5 nivel vă permite să utilizați `Potrivire` pentru un cont de bot (4 cereri zilnice), și încă 5 $5 adaugă încă două conturi de roboți (8 cereri zilnice). De exemplu, dacă vrei să rulezi în trei conturi, va fi acoperit de un nivel de 10 dolari și mai mare.