# Autentificare în doi pași

Steam include un sistem de autentificare cu doi factori care necesită detalii suplimentare pentru diferite activități legate de cont. Puteți citi mai multe despre el **[aici](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** și **[aici](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. Această pagină consideră că atât sistemul 2FA cât şi soluţia noastră care se integrează cu el, numită ASF 2FA.

---

# Logica ASF

Indiferent dacă folosești ASF 2FA sau nu, ASF include logica corectă și este pe deplin conștientă de conturile protejate de 2FA pe Steam. Vă va cere detaliile necesare atunci când sunt necesare (cum ar fi în timpul conectării). În timp ce puteți furniza aceste informații manual, anumite funcționalități ASF (cum ar fi `Potrivire`) necesită ASF 2FA pentru a fi operativ pe contul de bot, care poate răspunde automat la solicitările 2FA, în mod automat, ori de câte ori este necesar ASF.

---

# ASF 2FA

ASF 2FA este un modul încorporat responsabil pentru furnizarea de caracteristici 2FA pentru procesul ASF, cum ar fi generarea tokenurilor și acceptarea confirmărilor. Poate funcționa fie în mod independent, sau prin duplicarea detaliilor existente de autentificare (astfel încât să puteți folosi autentificatorul curent și ASF 2FA în același timp).

Poți verifica dacă contul botului tău folosește deja ASF 2FA executând `2fa` **[comenzi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Fără a configura ASF 2FA, toate comenzile standard `2fa` vor fi nefuncționale, ceea ce înseamnă că bot-ul tău nu este disponibil pentru funcții ASF avansate care necesită ca modulul să fie operativ.

---

# Recomandări

Există o mulțime de modalități de a face ASF 2FA funcțional, aici includem recomandările noastre bazate pe situația dvs. actuală:

- Dacă utilizați deja o aplicație terță neoficială care vă permite să extrageți detalii 2FA cu ușurință, doar **[importă](#import)** pe cele la ASF.
- Dacă folosești aplicația oficială și nu te deranjează să resetezi credențialele 2FA, cea mai bună metodă este să dezactivezi 2FA, apoi **[crează](#creation)** noi acreditări 2FA folosind **[autentificator comun](#joint-authenticator)**, care vă va permite să utilizați aplicația oficială și ASF 2FA. Această metodă **nu necesită rădăcină**, jafuri sau cunoştinţe avansate, abia urmând instrucţiunile scrise aici, şi este indiscutabil superioară pentru acest scenariu.
- Dacă folosești aplicația oficială și nu vrei să recreezi credențialele 2FA, opțiunile tale sunt foarte limitate, de obicei vei avea nevoie de rădăcină și de alte detalii în jurul lui **[import](#import)** , şi chiar cu asta ar putea fi imposibil.
- Dacă nu folosești încă 2FA și nu îți pasă, îți recomandăm să folosești ASF 2FA cu **[autentificator autonom](#standalone-authenticator)** sau **[autentificator comun](#joint-authenticator)** cu aplicație oficială (identică cu cea de mai sus).

Mai jos discutăm toate opţiunile posibile şi metodele pe care le cunoaştem noi.

---

## Creare

ASF vine cu un plugin oficial `MobileAuthenticator` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** care extinde ASF 2FA, vă permite să conectați un autentificator 2FA complet nou. Acest lucru poate fi util în cazul în care nu poți sau nu vrei să folosești alte instrumente și nu te deranjează ca ASF 2FA să devină autentificatorul tău principal (și poate numai). Procesul de creare este utilizat, de asemenea, în metoda autentificării în comun, în mod natural în acest scenariu, autentificatorul dvs. poate coexista în două locuri simultan - ambele vor genera aceleași coduri și ambele vor putea confirma aceleași confirmări.

### Măsuri comune pentru ambele scenarii

Indiferent dacă plănuiți să utilizați ASF ca autentificator independent sau comun, trebuie să faceți acești pași de inițializare:

1. Creează un robot ASF pentru contul țintă, începe-o, și conectează-te, ceea ce probabil ai făcut deja.
2. Atribuie un număr de telefon funcțional contului **[aici](https://store.steampowered.com/phone/manage)** pentru a fi folosit de bot. Acest lucru vă va permite să primiți codul SMS și să permiteți recuperarea, dacă este necesar. Acest pas nu este obligatoriu în toate scenariile, dar îl recomandăm dacă nu știi ce faci.
3. Asigură-te că nu folosești încă 2FA pentru contul tău, dacă o faci, dezactivează-l mai întâi. This **will** put your account on temporary trade-hold, there is no way around it, only **[import](#import)** process can skip it.
4. Execută comanda `2fainit [Bot]` înlocuind `[Bot]` cu numele botului tău.

Presupunând că ați primit un răspuns de succes, s-au întâmplat următoarele două lucruri:

- Un nou `<Bot>.maFile.PENDING` a fost generat de ASF în directorul de configurare ``.
- SMS-ul a fost trimis de la Steam la numărul de telefon atribuit pentru contul de mai sus. Dacă nu aţi setat un număr de telefon, atunci a fost trimis un e-mail la adresa de e-mail a contului.

Detaliile de autentificare nu sunt operaţionale încă, dar puteţi revizui fişierul generat dacă doriţi. Dacă vrei să fii dublu în siguranță, de exemplu, poți deja să notezi codul de revocare. Etapele următoare vor depinde de scenariul pe care l-ați selectat.

### Autentificator independent

Dacă doriți să utilizați ASF ca autentificator principal (sau chiar singur), acum trebuie să faceți pasul final de finalizare:

5. Execută comanda `2fafinalize [Bot] <ActivationCode>` înlocuirea lui `[Bot]` cu numele botului tău și `<ActivationCode>` cu codul pe care l-ai primit prin SMS sau e-mail în pasul anterior.

### Autentificator comun

Dacă doriți să aveți același autentificator atât în aplicația mobilă oficială ASF cât și în aplicația mobilă Steam, acum trebuie să faci pașii următori, mai complicați:

5. **Ignorați** codul SMS sau e-mail pe care l-ați primit în pasul anterior.
6. Instalați aplicația pentru mobil Steam dacă nu este încă instalată și deschideți-o. Navigați spre Steam Guard și adăugați un nou autentificator urmărind instrucțiunile aplicației.
7. După ce autentificatorul din aplicația mobilă este adăugat și funcționează, reveniți la ASF. Acum, în loc să finalizăm, trebuie doar să informăm ASF că aplicația mobilă a activat deja detaliile noastre generate anterior:
 - Așteptați până când următorul cod 2FA este afișat în aplicația mobilă Steam, și folosește comanda `2fafinalized [Bot] <2FACodeFromApp>` înlocuind `[Bot]` cu numele botului tău și `<2FACodeFromApp>` cu codul pe care îl vezi în prezent în aplicația mobilă Steam - aceeași pe care ai folosit-o pentru conectarea la Steam (**NU** cea pe care ai folosit-o deja pentru activare). Dacă codul generat de ASF și codul pe care l-ați furnizat sunt egale, ASF va presupune că un autentificator a fost adăugat corect și va continua să importe autentificatorul nou creat.
 - Vă recomandăm să faceți cele de mai sus pentru a vă asigura că acreditările dvs. sunt valide. Cu toate acestea, dacă nu doriţi (sau nu) să verificaţi dacă codurile sunt aceleaşi şi ştiţi ce faceţi, poți folosi comanda `2fafinalizedforce [Bot]`, înlocuirea `[Bot]` cu numele botului tău. ASF va presupune că autentificatorul a fost adăugat corect și va continua să importe autentificatorul nou creat. Ține cont că în acest mod ASF nu poate verifica dacă codurile se potrivesc, ceea ce înseamnă că puteți importa acreditări nevalide (neactivate).

### După finalizare

Presupunând că totul a funcționat corect, fișierul `<Bot>.maFile.PENDING` a fost redenumit la `<Bot>.maFile.NEW`. Acest lucru indică faptul că acreditările dvs. 2FA sunt acum valide și active. Vă recomandăm să mutați acel fișier în afara directorului `config` și **să îl stocați într-o locație securizată**. În plus, dacă ai decis să folosești autentificatorul singur, apoi îți recomandăm să deschizi fișierul în editorul tău de alegere și să notezi `revocation_code`, care vă va permite, după cum implică numele, să revocați autentificatorul în cazul în care îl pierdeți. În metoda autentificării în comun, ar fi trebuit deja să faceți asta în aplicația mobilă Steam, dar nu ezitați să faceți același lucru în cazul în care trebuie.

In regards to technical details, the generated `maFile` includes all details that we've received from the Steam server during linking the authenticator, and in addition to that, the `device_id` field, which may be needed for other (third-party) authenticators, if you ever decide to import that `maFile` into them.

ASF importă automat autentificatorul imediat ce procedura a fost finalizată, și, prin urmare, `2fa` și alte comenzi conexe ar trebui să fie operaționale acum pentru contul botului la care sunteți legat autentificatorul. Îți recomandăm să verifici acest lucru.

---

## Importă

Procesul de import necesită autentificator deja legat și operațional care este suportat de ASF. Avem instrucțiuni pentru câteva surse oficiale și neoficiale de 2FA, pe lângă metoda manuală care vă permite să furnizați datele necesare chiar dvs. Vă rugăm să reţineţi că acele instrucţiuni ar trebui folosite doar **** dacă utilizaţi deja o soluţie dată - deoarece procesul implică aplicaţii şi instrumente terţe, **nu recomandăm utilizarea lor**, și îl menționăm exclusiv pentru oamenii care au decis deja să îl folosească și ar dori să importe detalii generate în ASF 2FA.

În general, procesul de import implică adăugarea lui `maFile` într-un format corespunzător la directorul ASF `config` , în care ASF va prelua acest fișier și îl va șterge automat din motive de securitate.

Toate ghidurile următoare necesită de la dvs. să aveți deja autentificatorul **care funcționează și funcționează** utilizat cu o anumită unealtă/aplicație. ASF 2FA nu va funcționa corect dacă importați date nevalide, prin urmare, asigurați-vă că autentificarea funcționează corect înainte de a încerca să o importați. Aceasta include testarea și verificarea funcționării corecte a următoarelor funcții de autentificare:
- Puteți genera jetoane și aceste jetoane sunt acceptate de rețeaua Steam (vă puteți autentifica)
- Puteți obține confirmări și acestea ajung pe autentificatorul dvs. mobil
- Puteți reacționa la aceste confirmări, și sunt recunoscute corespunzător de rețeaua Steam ca fiind confirmate/respinse

Asigură-te că autentificatorul tău funcționează verificând dacă acțiunile de mai sus funcționează - dacă nu funcționează, atunci nici ele nu vor funcționa în ASF.

### Telefon Android

În general pentru a importa autentificatorul de pe dispozitivul tău Android, vei avea nevoie de accesul **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))**. Instrucțiunile de mai jos necesită cunoștințe destul de decente în lumea care modifică Android, cu siguranță nu vom explica fiecare pas aici, vizitează **[XDA](https://xdaforums.com)** și alte resurse pentru informații suplimentare/ajutor cu cele de mai jos.

**Începând de astăzi, nu se cunoaşte şi nu se confirmă nici o metodă de extracţie care să funcţioneze în continuare. Puteți încerca oricum să urmați pașii de mai jos, de exemplu cu versiunea învechită a aplicației, dar nu garantăm că va funcționa corect. Luați în considerare utilizarea metodei de autentificare în comun.**

<details>
  <summary>Instrucțiuni de arhivare</summary>

Presupunând că aveți o aplicație oficială **[Steam](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** care funcționează și funcționează (sub cere să răstoarnă dispozitivul tău):

- Instalați **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** și activați Zygisk în setări.
- Instalați **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (pentru Zygisk) și asigurați-vă că funcționează.
- Instalați **[SteamGuardDump](https://github.com/YifePlayte/SteamGuardDump/releases/latest)** sau **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** Modul LSPosed și activați-l în setările SPOS.
- Forțați închiderea aplicației Steam, apoi deschideți-o, detaliile dispozitivului de siguranță ar trebui să fie acum disponibile pentru a copia în clipboard.

Acum ca ati extras cu succes detaliile necesare, dezactivati modulul pentru a preveni auto-copierea de fiecare data, apoi copiază valoarea lui `shared_secret` și `identity_secret` al contului pe care intenționezi să îl adaugi la ASF 2FA, într-un fişier text nou cu structura de mai jos:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Înlocuiește valoarea `STRING` cu o cheie privată adecvată din detaliile extrase. Odată ce faci asta, redenumește fișierul la `BotName. aFile`, unde `BotName` este numele botului tău la care adaugi ASF 2FA și pune-l în directorul ASF `config` dacă nu ai fost încă.

Lansează ASF, care ar trebui să observe fișierul tău și să îl importe. Presupunând că ați importat fișierul corect cu secrete valide, totul ar trebui să funcționeze corect, pe care îl puteți verifica folosind comenzile `2fa`. Dacă ați făcut o greșeală, puteți întotdeauna să eliminați `Bot.db` și să începeți din nou dacă este necesar.

</details>

### SteamDesktopAutentificator

Dacă aveţi autentificatorul care rulează deja în SDA, trebuie să observaţi că există fişierul `steamID.maFile` disponibil în folderul `maFiles`. Asigurați-vă că `maFile` este în formă necriptată, întrucât ASF nu poate decripta fişierele SDA - conţinutul fişierului necriptat trebuie să înceapă cu `{` şi să se termine cu `} caracter`. Dacă este necesar, mai întâi puteți elimina criptarea din setările SDA și să o activați din nou când ați terminat. Odată ce fișierul este în formă necriptată, copiați-l în directorul `config` de ASF.

Acum poți redenumi `steamID.maFile` la `BotName. aFile` în directorul de configurare ASF, unde `BotName` este numele botului tău la care adaugi ASF 2FA. Alternativ, îl poți lăsa așa cum este, ASF îl va alege automat după autentificare. Redenumirea fișierului ajută ASF făcând posibilă utilizarea ASF 2FA înainte de autentificare, dacă nu faceți acest lucru, apoi fișierul poate fi ales doar după ce ASF se conectează cu succes (deoarece ASF nu știe `steamID` al contului tău înainte de a te autentifica).

Lansează ASF, care ar trebui să observe fișierul tău și să îl importe. Presupunând că ați importat fișierul corect cu secrete valide, totul ar trebui să funcționeze corect, pe care îl puteți verifica folosind comenzile `2fa`. Dacă ați făcut o greșeală, puteți întotdeauna să eliminați `Bot.db` și să începeți din nou dacă este necesar.

### WinAuth

Mai întâi creaţi noi goale `BotName. aFile` în directorul de configurare ASF, unde `BotName` este numele botului tău pe care îl adaugi ASF 2FA. Dacă furnizați un nume incorect, acesta nu va fi ales de ASF.

Acum lansați WinAuth ca de obicei. Faceți clic dreapta pe pictograma Steam și selectați "Show SteamGuard and Recovery Code". Apoi verifică "Allow copy". Trebuie să vă observaţi familiară structura JSON în partea de jos a ferestrei, începând cu `{`. Copiați întregul text într-un fișier de tip `BotName.maFile` creat de dvs. în pasul anterior.

Lansează ASF, care ar trebui să observe fișierul tău și să îl importe. Presupunând că ați importat fișierul corect cu secrete valide, totul ar trebui să funcționeze corect, pe care îl puteți verifica folosind comenzile `2fa`. Dacă ați făcut o greșeală, puteți întotdeauna să eliminați `Bot.db` și să începeți din nou dacă este necesar.

### Manual

Dacă sunteți utilizator avansat, puteți genera și maFile manual. Acesta poate fi folosit în cazul în care doriți să importați autentificatorul din alte surse decât cele pe care le-am descris mai sus. Ar trebui să aibă **[o structură JSON validă](https://jsonlint.com)** de:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Datele standard de autentificare au mai multe câmpuri - sunt complet ignorate de ASF în timpul importului, pentru că nu sunt necesare. Nu trebuie să le eliminați - ASF necesită doar JSON valabil 2 câmpuri obligatorii descrise mai sus și va ignora câmpuri suplimentare (dacă există). Desigur, trebuie să înlocuiești substituentul `STRING` în exemplul de mai sus cu valori valide pentru contul tău. Fiecare `STRING` ar trebui să fie reprezentarea octeților codificată baze64, din cheia privată adecvată este făcută.

---

## Întrebări frecvente

### Cum utilizează ASF modulul 2FA?

Dacă ASF 2FA este disponibilă, ASF îl va utiliza pentru confirmarea automată a tranzacțiilor trimise/acceptate de ASF. De asemenea, va putea genera automat tokeni 2FA la nevoie, de exemplu pentru a se conecta. În plus, având ASF 2FA permite de asemenea comenzilor `2fa` pentru a le folosi.

### Cum pot obține token 2FA?

Veți avea nevoie de token 2FA pentru a accesa contul protejat cu 2FA, care include și fiecare cont ASF 2FA. Dacă ai decis să folosești autentificatorul independent, atunci ar trebui să folosești comanda `2fa <BotNames>` pentru a genera token temporar pentru anumite cazuri de bot. În toate celelalte scenarii, vă recomandăm să utilizați autentificatorul original pe care l-ați folosit, deși poți folosi și comanda dacă este mai convenabil pentru tine.

### Pot folosi autentificatorul meu original după ce îl importez ca ASF 2FA?

Da, autentificatorul original rămâne funcțional și îl puteți folosi împreună cu ASF 2FA. Cu toate acestea, dacă îl invalidezi prin orice metodă, atunci acreditările ASF 2FA asociate nu vor mai fi valabile.

### Cum se elimină ASF 2FA?

Pur și simplu oprește ASF și elimină asociat `BotName.db` botului cu ASF 2FA atașat pe care doriți să-l eliminați. Această opțiune va elimina fișierul 2FA importat asociat cu ASF, dar NU va invalida (anula) autentificatorul dvs. Dacă dorești în schimb să invalidezi autentificatorul tău, în afară de ștergerea acestuia din ASF (primul), ar trebui să îl deconectezi în autentificatorul original ales de tine. Dacă nu poți face asta dintr-un anumit motiv, de exemplu pentru că folosești ASF 2FA în mod independent, apoi folosește codul de revocare pe care l-ai primit în timpul configurării, pe site-ul Steam. Nu este posibil să invalidezi autentificatorul prin ASF.

### Am legat autentificatorul în aplicație terță, apoi sunt importat în ASF. Pot acum să-l conectez din nou pe telefonul meu?

**Nu**. Acest lucru va invalida acreditările importate anterior, iar ASF 2FA va înceta funcționarea (prin generarea de coduri care nu mai sunt acceptate de Steam). În primul rând decide unde doriți să fie localizat autentificatorul original sau terț, apoi importați-l ca ASF 2FA.

### Folosesc autentificatorul comun, pot muta aplicatia mea pe un alt telefon?

**Nu**. Ceea ce statuează ca autentificator "în mişcare" sau "transfer" este de fapt egal cu invalidarea celui vechi şi atribuirea unuia nou, într-un singur pas. Acest lucru vă permite să omiteți, de ex. o oarecare răcire excesivă în comparație cu cele două etape în mod independent, însă, în ceea ce privește ASF, aceasta invalidează acreditările pe care le-ați generat anterior în ASF, ceea ce face ca întregul modul ASF 2FA să nu fie funcțional.

Modul recomandat este de a elimina autentificatorul complet pe telefonul vechi şi de a utiliza metoda comună de autentificare pe telefonul nou. Dacă ați mutat deja autentificatorul, atunci acreditările ASF 2FA vechi sunt deja invalidate, așa că singurul lucru rămas acum este să ștergi autentificatorul "mutat" și să conectezi unul nou folosind din nou metoda de autentificare comună.

### Utilizarea ASF 2FA este mai bună decât autentificatorul terț pentru a accepta toate confirmările?

**Da**, în mai multe feluri. First and most important one - using ASF 2FA **significantly** increases your security, as ASF 2FA module ensures that ASF will only accept automatically its own confirmations, so even if attacker does request a trade that is harmful, ASF 2FA will **not** accept such trade, as it was not generated by ASF. Pe lângă partea de securitate, utilizarea ASF 2FA aduce și beneficii de performanță/optimizare, deoarece ASF 2FA preia și acceptă confirmările imediat după generare; doar atunci, spre deosebire de sondajele ineficiente în vederea confirmării fiecărui X minut, realizat prin alte soluţii. Nu există niciun motiv pentru a utiliza autentificatorul terț prin ASF 2FA, dacă intenționați să automatizați confirmările generate de ASF - acesta este exact scopul pentru care este ASF 2FA, și utilizarea sa nu intră în conflict cu tine, confirmând orice altceva în autentificarea la alegerea ta. Vă recomandăm insistent să utilizați ASF 2FA pentru întreaga activitate ASF.