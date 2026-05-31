# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` este ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** dezvoltat de noi, care vă permite să contribuiți la proiectul **[SteamDB](https://steamdb.info)** prin partajarea token-urilor, chei pentru aplicații și depanare la care are acces contul de Steam. Informațiile extinse despre datele colectate și de ce SteamDB are nevoie de ele pot fi găsite pe pagina SteamDB **[Token Dumper](https://steamdb.info/tokendumper)**. Datele transmise nu includ nicio informație potențial sensibilă și nu prezintă niciun risc de securitate/confidențialitate, așa cum se menționează mai sus.

---

## Activarea plugin-ului

ASF vine cu `SteamTokenDumperPlugin` grupat împreună cu lansarea, dar plugin-ul în sine este dezactivat în mod implicit. Puteți activa plugin-ul setând `SteamTokenDumperPluginEnabled` proprietatea de configurare globală ASF la `true`, în sintaxa JSON:

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

La lansarea programului ASF, plugin-ul vă va anunța dacă a fost activat cu succes prin mecanismul standard de logare ASF. De asemenea, puteți activa plugin-ul prin intermediul generatorului nostru de configurări web.

---

## Detalii tehnice

După activare, plugin-ul va utiliza roboții pe care îi rulați în ASF pentru colectarea de date sub formă de token-uri, token-urile aplicației și cheile de depozit la care roboții tăi au acces. Modulul de colectare a datelor include rutine pasive și active care ar trebui să minimizeze cheltuielile suplimentare cauzate de colectarea datelor.

Pentru a îndeplini criteriile de utilizare prevăzute, pe lângă rutina de colectare a datelor explicată mai sus, rutina de transmitere este inițializată ca fiind responsabilă pentru determinarea datelor care trebuie prezentate periodic la SteamDB. Această rutină se va activa până la `1` oră de la începutul ASF și se va repeta la fiecare `24` ore. Plugin-ul va face tot posibilul pentru a minimiza cantitatea de date care trebuie trimisă, prin urmare este posibil ca unele date pe care plugin-ul le va colecta să fie determinate ca inutile de trimis, și, prin urmare, omis (de exemplu actualizare a aplicației care nu modifică token-ul de acces).

Plugin-ul folosește o bază de date persistentă salvată în locația `config/SteamTokenDumper.cache` , care servește un scop similar cu `config/ASF.db` pentru ASF. Fișierul este utilizat pentru a înregistra datele colectate și trimise și pentru a reduce la minimum volumul de muncă care trebuie să fie efectuată pentru diferite rulări ASF. Eliminarea fișierului face ca procesul să fie repornit de la zero, ceea ce ar trebui evitat dacă este posibil.

---

## Date

ASF include contributorul `steamID` în cerere, care este determinat ca `SteamOwnerID` pe care l-ați setat în ASF, sau în cazul în care nu ați făcut, ID-ul de Steam al bot-ului care deține cele mai multe licențe. Colaboratorul anunțat ar putea primi câteva avantaje suplimentare de la SteamDB pentru ajutor continuu (e. . se clasează pe site-ul web), dar acest lucru depinde în totalitate de puterea de apreciere a SteamDB.

În orice caz, personalul SteamDB ar dori să vă mulţumească anticipat pentru ajutor. Datele transmise permit SteamDB să funcționeze, în special pentru a urmări informațiile despre pachete, aplicații și depozite, care nu ar mai fi posibile fără ajutorul dvs.

---

## Comanda

Plugin-ul STD vine cu o comandă ASF suplimentară, `std [Bots]`, care vă permite să activați reîmprospătarea și depunerea pentru boții selectați la cerere. Folosirea comenzii nu necesită configurare activată, care vă permite să săriți peste colectarea și depunerea automată și să controlați procesul manual. Firește, poate fi executat și cu configurare activată, care va declanșa pur și simplu procedurile obișnuite de colectare și depunere mai devreme decât se aștepta.

Îți recomandăm `!std ASF` pentru a declanșa refresh pentru toți boții disponibili. Cu toate acestea, îl poți declanșa și pentru cele selectate, dacă dorești.

---

## Configurare avansată

Plugin-ul nostru suportă configurarea avansată care ar putea fi utilă pentru persoanele care ar dori să adapteze internalii la preferințele lor.

Configurarea avansată are următoarea structură localizată în `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Activat": false,
    "StockAppIDs": [],
    "ΠDepotIDs": [],
    "StockPackageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Toate opțiunile sunt explicate mai jos:

### `Activat`

`bool` tip cu valoarea implicită de `false`. Această proprietate acționează la fel ca `SteamTokenDumperPluginEnabled` proprietatea de nivel root's explicată mai sus și poate fi utilizată în loc, dedicate persoanelor care ar prefera să aibă configurație completă legată de plugin-uri în propria sa structură (cel mai probabil cele care folosesc deja alte proprietăți avansate explicate mai jos).

---

### `AppID-uri`

`ImmutableHashSet<uint>` tip cu valoarea implicită a fi goală. Această proprietate specifică `appID-urile` că plugin-ul nu va rezolva, iar dacă sunt deja rezolvate, nu va trimite tokenul. Această proprietate poate fi utilă pentru persoanele cu acces la informații potențial sensibile despre articole nepublicate, în special dezvoltatori, editori sau teste beta închise.

---

### `DepotID-uri`

`ImmutableHashSet<uint>` tip cu valoarea implicită a fi goală. Această proprietate specifică `depotID-urile` că plugin-ul nu va rezolva, iar dacă sunt deja rezolvate, nu va trimite cheia pentru el. Această proprietate poate fi utilă pentru persoanele cu acces la informații potențial sensibile despre articole nepublicate, în special dezvoltatori, editori sau teste beta închise.

---

### `PackageID-uri`

`ImmutableHashSet<uint>` tip cu valoarea implicită a fi goală. Această proprietate specifică `packageIDs` (cunoscută și ca `subID-uri`) că plugin-ul nu va rezolva, și dacă sunt deja rezolvate, nu va trimite jetonul. Această proprietate poate fi utilă pentru persoanele cu acces la informații potențial sensibile despre articole nepublicate, în special dezvoltatori, editori sau teste beta închise.

---

### `Pachete de sărituri`

`bool` tip cu valoarea implicită `true`. Această proprietate funcționează foarte asemănător cu `glaPackageID-uri` și când este activată, va provoca omiterea pachetelor cu `Metoda de Plată` din `AutoGrant` în timpul rezolvării rutinei explicate mai jos. `AutoGrant` metoda de plată este folosită de **[Steamworks](https://partner.steamgames.com)** pentru a acorda automat pachete în conturile de dezvoltatori. Deși aceasta nu este la fel de explicită ca alte opțiuni `Secret` , și, prin urmare, nu garantează nimic (deoarece este posibil să aveți alte pachete în afară de `AutoGrant` pe care încă nu doriți să le trimiteți), ar trebui să fie suficient de bun pentru a scăpa de majoritate, dacă nu de toate pachetele secrete. Această opțiune este activată în mod implicit, ca persoane care au efectiv acces la pachetele `AutoGrant` nu vor vrea aproape niciodată să le dezvăluie pe cele către publicul larg, și, prin urmare, utilizarea valorii de `false` este foarte situațională.

---

## Explicații suplimentare

La nivelul rădăcinii, fiecare cont Steam deţine un set de pachete (licenţe, abonamente), care sunt clasificate de pachetul `packageID` (cunoscut și ca `subID`). Fiecare pachet poate conține mai multe aplicații clasificate de `appID`. Fiecare aplicație poate include apoi mai multe depozite clasificate de `depotID`.

```text
├── sub/124923
│     ├── app/292030
│     │     ├── depot/292031
│     │     ├── depot/378648
│     │     └── ...
Ταθειστική app/378649
Της ─ ...
└── ...
```

Plugin-ul nostru include două rutine care iau în considerare elemente omise - rutina de rezolvare și rutina de trimitere.

Rutina de rezolvare este responsabilă pentru rezolvarea arborelui pe care îl puteți vedea mai sus. Prin includerea pe lista neagră a pachetelor/aplicațiilor/depoturilor în avans, vei tăia efectiv copacul în locul ramurii/frunze de pe lista neagră fără a fi nevoie să specifici părțile rămase din ea. În exemplul nostru de mai sus, dacă pachetul `124923` a fost ignorat, fie prin `StockPackageIDs` sau `SkipAutoGrantPackages`, și a fost singurul pachet pe care îl dețineți care a fost legat de aplicația `292030` , apoi appID `292030` nu s-ar rezolva nici și, prin definiție, dacă nu au existat alte aplicații rezolvate care sunt legate de depozitele `292031` și `378648` , atunci nici ei nu vor fi rezolvaţi. Cu toate acestea, țineți cont că dacă plugin-ul a rezolvat deja arborele, atunci efectiv acesta va opri actualizarea elementului dat doar (de ex. noi aplicații adăugate), acesta nu va face plugin-ul "uitați" despre elementele existente care au fost deja rezolvate (e. . aplicații găsite în acel pachet înainte de a decide să îl listați pe lista neagră). Dacă tocmai ați activat câteva opțiuni de sărit și ați dori să vă asigurați că ASF nu traversează arborele deja rezolvat, puteți lua în considerare ștergerea unică a lui `config/SteamTokenDumper. ache` fişier unde plugin-ul îşi păstrează geocutia.

Rutina de depunere este responsabilă pentru trimiterea token-urilor, a tokenurilor aplicațiilor și a cheilor de depozit pentru elemente deja rezolvate (prin rutina de mai sus). Aici lista neagră are efect imediat, ca şi cum plugin-ul a rezolvat deja informaţiile, rutina de trimitere nu o va trimite de fapt la SteamDB dacă o ai pe lista neagră, indiferent dacă a fost rezolvată sau nu. Ţineţi cont de faptul că nu mai vorbim despre copaci în acest punct. rutina de transmitere nu știe dacă informațiile despre aplicație provin de la unul sau de la acel pachet, astfel încât să sară doar informații despre articole de pe lista neagră, indiferent de relația pe care o au cu altele.

Pentru majoritatea dezvoltatorilor și editorilor, ar trebui să fie suficient pentru a menține `SkipAutoGrantPackages` activat, potențial împuternicit numai cu `PackageID-uri` , întrucât reduce efectiv copacul de la ramura de început și garantează că aplicațiile și depozitele incluse și mai mult nu vor fi depuse atâta timp cât nu există niciun alt pachet care să facă legătura cu aceeași aplicație. Dacă vrei să fii dublu sigur, în plus față de faptul că poți folosi și `amazepAppID-uri`, care va omite rezolvarea aplicației chiar dacă există alte licențe pe care nu le-ați conectat la lista neagră. Utilizarea `DepotIDs` nu ar trebui să fie necesară, cu excepția cazului în care aveți un anumit lucru, nevoi specifice (cum ar fi sărirea doar a unui anumit depozit în timp ce încă se trimit informații despre pachete și aplicații), sau dacă doriţi să adăugaţi încă un strat pentru a fi securizat triplu.