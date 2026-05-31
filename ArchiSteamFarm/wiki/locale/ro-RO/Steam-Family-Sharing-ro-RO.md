# Partajarea familiei Steam

ASF suportă Partajarea Familiei Steam - sistemul vechi și noul sistem. Pentru a înțelege cum funcționează ASF cu aceasta, ar trebui să citiţi mai întâi cum **[Familia Steam funcţionează](https://store.steampowered.com/promotion/familysharing)**, care este disponibil în magazinul Steam. În plus, verificați **[știrile](https://store.steampowered.com/news/app/593110/view/4149575031735702628)** pentru noul sistem de partajare a familiei Steam pe care ASF este compatibil și cu acesta.

---

## ASF

Suport pentru funcția de partajare a familiei Steam în ASF este transparentă, ceea ce înseamnă că nu introduce nici un bot/procesează proprietăți noi de configurare - funcționează din căsuță ca o funcționalitate extra încorporată.

ASF include logica adecvată pentru a fi conștient de blocarea bibliotecii de către utilizatorii de partajare a familiei, prin urmare nu îi va da afară din sesiune din cauza lansării unui joc. ASF va acționa exact la fel ca în cazul contului principal care ține blocajul, prin urmare dacă blocarea respectivă este deținută fie de clientul tău cu aburi, sau de către unul dintre utilizatorii de partajare familială, ASF nu va încerca să crescă, în schimb, va aștepta ca blocarea să fie eliberată. Acest lucru este în mare parte legat de vechiul sistem - noul sistem permite utilizatorilor care partajează în familie să joace alte jocuri decât cele pe care ASF le practică în prezent.

În plus față de cele de mai sus, după autentificare, ASF va accesa sistemele tale de partajare a familiei (vechi și nou), din care va extrage utilizatorii (Steam ID-uri) permiși să îți folosească biblioteca. Acestor utilizatori li se acordă permisiunea `FamilySharing` pentru a utiliza comenzile **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, în special să li se permită să folosească comanda `pause~` în contul botului care partajează jocuri cu acesta; care permite întreruperea modului de cultivare automată a cardurilor pentru a lansa un joc care poate fi partajat - acest lucru se aplică mai ales sistemului vechi, dar ar putea fi folosit în continuare cu noul sistem în cazul în care ASF este în prezent în agricultură jocul pe care utilizatorii vor să îl joace.

Connecting both functionalities described above allows your friends to `pause~` your cards farming process, start a game, play as long as they wish, and then after they're done playing, cards farming process will be automatically resumed by ASF. Desigur, emiterea de `pause~` nu este necesară dacă ASF nu este momentan o agricultură activă, pentru că prietenii tăi pot lansa jocul imediat, și logica descrisă mai sus asigură că nu vor fi eliminați din sesiune.

---

## Limitări

Reţeaua de Steam iubeşte să inducă în eroare ASF prin transmiterea de actualizări false de stare, ceea ce ar putea duce la ASF crezând că este în regulă să reia procesul, și ca urmare ai dat afară prietenul tău prea curând. Aceasta este exact aceeași problemă ca cea deja explicată de noi în **[această intrare FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. Recomandăm exact aceleaşi soluţii, în principal promovându-ți prietenii la permisiunea `Operatorul` (sau mai sus) și spunându-le să folosească comenzile `pauză` și `să reia comenzile`.