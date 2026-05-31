# Pluginuri

ASF include suport pentru plugin-uri personalizate care pot fi încărcate în timpul rulării. Plugin-urile vă permit să personalizați comportamentul ASF, de exemplu prin adăugarea de comenzi personalizate, logică de tranzacționare personalizată sau integrare completă cu servicii terțe și API-uri.

Această pagină descrie plugin-urile ASF din perspectiva utilizatorilor - explicații, utilizare și similare. Dacă doriţi să vizualizaţi perspectiva dezvoltatorului, mutaţi **[aici](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)**.

---

## Utilizare

ASF încarcă plugin-urile din directorul `plugin-uri` aflat în dosarul tău ASF. Este o practică recomandată (care devine obligatorie cu actualizări automate ale plugin-ului) pentru a menține un director dedicat pentru fiecare plugin pe care doriți să îl folosiți, care poate fi bazat pe numele său, cum ar fi `MyPlugin`. Acest lucru va duce la structura finală a arborelui de `plugins/MyPlugin`. În cele din urmă, toate fișierele binare ale plugin-ului ar trebui puse în interiorul acelui dosar dedicat, iar ASF va descoperi în mod corespunzător și va utiliza plugin-ul după repornire.

De obicei, dezvoltatorii de plugin-uri își vor publica plugin-urile sub forma unui fișier `zip` cu binare în interior, ceea ce înseamnă că ar trebui să dezarhivați fișierul zip în propriul subdirector dedicat în directorul `plugin-uri`.

Dacă plugin-ul a fost încărcat cu succes, îi veți vedea numele și versiunea în jurnalul dvs. Ar trebui să consultați dezvoltatorii de plugin-uri în caz de întrebări, probleme sau utilizare legate de plugin-urile pe care ați decis să le folosiți.

Poți găsi câteva plugin-uri recomandate în secțiunea **[terț](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)**.

**Vă rugăm să reţineţi că plugin-urile ASF ar putea fi malițioase**. Ar trebui să vă asigurați întotdeauna că utilizați plugin-uri făcute de dezvoltatori de care puteți avea încredere, chiar și cele din secțiunea terță de mai sus. Dezvoltatorii ASF nu mai pot garanta beneficiile ASF obișnuite (cum ar fi lipsa de programe malware sau lipsa de VAC) dacă decideți să utilizați orice plugin-uri personalizate. Trebuie să înțelegeți că plugin-urile au control deplin asupra procesului ASF odată încărcat, Din cauza faptului că de asemenea nu putem sprijini configurările care folosesc plugin-uri personalizate, deoarece nu mai rulați codul ASF vanilie.

---

## Compatibilitate

În funcție de complexitatea plugin-ului, domeniul de aplicare și mulți alți factori, este complet posibil să ceară de la tine să folosești varianta **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** ASF, În locul recomandării de obicei **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. Acest lucru se datorează faptului că varianta specifică OS-ului vine doar cu funcționalitatea de bază necesară pentru ASF în sine, iar plugin-ul dumneavoastră poate avea nevoie de părți care nu se încadrează în sfera principală ASF, fiind incompatibile cu construcțiile specifice OS.

În general, atunci când utilizezi plugin-uri terțe, recomandăm utilizarea variantei generice ASF pentru compatibilitate maximă. Cu toate acestea, nu toate plugin-urile pot necesita acest lucru - vă rugăm să consultaţi informaţiile plugin-ului dumneavoastră pentru a afla dacă trebuie să utilizaţi sau nu varianta generică ASF.

---


## Actualizări automate

ASF are mecanismul încorporat pentru actualizările automate ale plugin-urilor. Pentru ca această caracteristică să funcționeze, în primul rând, plugin-ul de alegere trebuie să **[suport](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)** acel mecanism. Dacă ați încărcat un plugin care suportă actualizări automate, ASF îl va afișa în jurnal în mod corespunzător în timpul inițializării plugin-ului, cum ar fi "Plugin-ul a fost dezactivat din actualizări automate" sau "plugin-ul a fost înregistrat şi activat pentru actualizări automate".

În mod implicit, actualizările automate pentru plugin-uri personalizate sunt **dezactivate**, din motive de securitate. Puteți configura actualizările automate în configurare folosind **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** și/sau **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)**, Îți recomandăm să citești descrierea acelor proprietăți de configurare pentru mai multe informații. Este frumos să reții că, la fel ca în cazul actualizărilor ASF, poți decide să păstrezi actualizările automate dezactivate și apoi să actualizezi la nevoie. Baza manuală, prin emiterea de actualizări `actualizărilor` **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

Ambele abordări îți permit să actualizezi niciunul, unele sau toate plugin-urile personalizate pe care le-ai încărcat în proces.