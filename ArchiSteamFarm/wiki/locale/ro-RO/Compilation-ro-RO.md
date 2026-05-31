# Compilare

Compilarea este procesul de creare a fișierului executabil. Asta este ceea ce vreți să faceți pentru a adăuga propriile modificări la ASF, sau dacă din orice motiv nu aveți încredere în fișierele executabile furnizate în **[versiuni](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** oficiale. Dacă sunteți utilizator și nu dezvoltator, cel mai probabil vreți să folosiți binare precompilate, dar dacă doriți să vă folosiți pe cele proprii sau să invățați ceva nou, continuați să citiți.

ASF poate fi compilat pe orice platformă suportată în prezent, atâta timp cât aveți toate instrumentele necesare.

---

## .NET SDK

Indiferent de platformă, ai nevoie de versiunea completă. NET SDK (nu doar runtime) pentru a compila ASF. Instrucţiunile de instalare pot fi găsite pe **[.NET pagina](https://dotnet.microsoft.com/download)**. Trebuie să instalați versiunea corespunzătoare .NET SDK pentru sistemul dumneavoastră de operare. După o instalare reușită, comanda `dotnet` trebuie să fie disponibilă și să funcționeze. Puteţi verifica dacă funcţionează cu `dotnet --info`. Asigurați-vă că .NET SDK potrivește ASF **[cerințe de execuție](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## Compilare

Presupunând că aveți .NET SDK operativ și într-o versiune adecvată, navigați pur și simplu la sursa directorului ASF (repo-ul ASF clonat sau descărcat și despachetat) și executați:

```shell
dotnet publică ArchiSteamFarm -c "Release" -o "out/generic"
```

Dacă folosiți Linux/macOS, puteți folosi scriptul `cc.sh` care va face același lucru, într-un mod puțin mai complex.

Dacă compilarea s-a încheiat cu succes, puteți găsi ASF în directorul `source` aromă în `out/generic`. Acesta este același lucru cu versiunea oficială `generică` construită ASF, dar a forțat `UpdateChannel` și `UpdatePeriod` din `0`, care este adecvat pentru autoconstrucții.

### OZspecific

De asemenea, puteţi genera pachet OSspecific .NET dacă aveţi o anumită nevoie. În general, nu ar trebui să faci asta pentru că tocmai ai compilat aroma `generic` pe care o poți executa cu instalația ta deja instalată. Executarea ET pe care aţi folosit-o pentru compilare în primul rând, dar în cazul în care vreţi:

```shell
dotnet publică ArchiSteamFarm -c "Release" la "out/linux-x64" -r "linux-x64" --auto-conținut
```

Desigur, înlocuiți `linux-x64` cu arhitectura OS pe care doriți să o ținteți, cum ar fi `win-x64`. Această versiune va avea și actualizări dezactivate. Când construiești `--auto-conținut` poți declara de asemenea două comutatoare suplimentare: `-p:PublishTrimmed=true` va produce șterse din nou; în timp ce `-p:PublishSingleFile=true` va produce un singur fișier. Adăugarea amândurora va duce la aceleași setări pe care le folosim pentru propriile noastre clădiri.

### ASF-ui

While the above steps are everything that is required to have a fully working build of ASF, you may *also* be interested in building **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, our graphical web interface. Din partea ASF, tot ce trebuie să faceți este să plasați ASF-ui build build output în locația standard `ASF-ui/dist` , apoi construirea ASF cu el (din nou, dacă este necesar).

ASF-ui face parte din arborele sursă al ASF ca **[submodul](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, asigură-te că ai clonat repo-ul cu `clona de git --recursive`, pentru că altfel nu vei avea fișierele necesare. Vei avea nevoie de asemenea de un NPM funcțional, **[Node.js](https://nodejs.org)** vine cu el. Dacă utilizaţi Linux/macOS, vă recomandăm `cc. h` script, care va acoperi automat construcția și livrarea ASF-ui (dacă este posibil, adică, dacă îndeplinești cerințele pe care tocmai le-am menționat).

În plus față de `cc. h` script, de asemenea, atașăm instrucțiunile de construcție simplificate de mai jos, a se vedea **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** pentru documente suplimentare. Din locația arborelui sursă a ASF, ca mai sus, execută următoarele comenzi:

```shell
rm -rf "ASF-ui/dist" # ASF-ui nu se curăță după construcția veche

npm ci --prefix ASF-ui
npm run-script oy --prefix ASF-ui

rm -rf "out/generic/www" # Asigurați-vă că rezultatul construcției noastre este curat din vechile fișiere
dotnet publică ArchiSteamFarm -c "Release" și "out/generic" # Sau în concordanță cu ceea ce aveți nevoie ca per fișierele de mai sus
```

Acum ar trebui să poți găsi fișierele ASF-ui în dosarul `out/generic/www`. ASF va putea servi aceste fișiere în browser-ul tău.

Alternativ, poți pur și simplu construi ASF-ui, fie manual, fie cu ajutorul repo-ului nostru, apoi copiază manual rezultatul construcției la `${OUT}/www` , unde `${OUT}` este dosarul de ieșire al ASF specificat cu parametrul `și`. Exact asta face ASF ca parte a procesului de construcție. copia `ASF-ui/dist` (dacă există) la `${OUT}/www`, Nu este nimic special şi se poate face după construire, după cum puteţi vedea, dacă este necesar.

---

## Dezvoltare

Dacă doriţi să editaţi codul ASF, puteţi folosi orice . IDE compatibile cu ET în acest scop, deşi acest lucru este chiar opţional, pentru că poți să editezi cu un notepad și să compilezi comanda `dotnet` descrisă mai sus.

Dacă nu ai o alegere mai bună, putem recomanda **[JetBrains Rider](https://www.jetbrains.com/rider)** şi **[Visual Studio Code](https://code.visualstudio.com/download)**, Primul este IDDE-ul preferat de echipa ASF care foloseşte personal şi al doilea este alternativa viabilă. Ambele programe sunt multi-platformă și sunt disponibile pe Linux, macOS și Windows.

---

## Etichete

`main` sucursala nu este garantată a fi într-o stare care permite compilarea cu succes sau execuția defectuoasă a ASF în primul rând, pentru că este ramură de dezvoltare la fel ca în ciclul nostru de lansare **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. Dacă doriți să compilați sau să referiți ASF de la sursă, apoi ar trebui să folosiți eticheta **[](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** în acest scop, care garantează cel puțin o compilare reușită și, foarte probabil, execuția defectuoasă (dacă construcția a fost marcată ca o versiune stabilă). Pentru a verifica "sănătatea" curentă a copacului, puteți folosi CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Partajări oficiale

Versiunile oficiale ASF sunt compilate de **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, cu ultimele . ETD SDK care corespunde ASF **[cerințe privind timpul de funcționare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. După trecerea testelor, toate pachetele sunt implementate ca versiune, de asemenea pe GitHub. Acest lucru garantează și transparența, deoarece GitHub utilizează întotdeauna surse publice oficiale pentru toate clădirile, și puteți compara sumele de artefacte GitHub cu activele de lansare GitHub. Dezvoltatorii ASF nu compilează sau publică completări în sine, cu excepția procesului privat de dezvoltare și a depanării.

În plus față de cele de mai sus, întreținătorii ASF validează și publică manual sumele de verificare independent de GitHub, server ASF de la distanță, ca măsură de securitate suplimentară. Acest pas este obligatoriu pentru ASF-urile existente să considere versiunea ca un candidat valid pentru funcționalitatea actualizării automate.