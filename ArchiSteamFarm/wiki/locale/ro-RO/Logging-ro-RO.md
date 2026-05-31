# Logare

ASF vă permite să configurați propriul modul de logare personalizată, care va fi utilizat în timpul rulării. Puteți face acest lucru punând fișierul special numit `NLog.config` în directorul aplicației. Puteţi citi întreaga documentaţie NLog pe **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**, dar pe lângă asta veţi găsi şi câteva exemple utile aici.

---

## Autentificare implicită

În mod implicit, ASF se conectează la `ColoredConsole` (ieșire standard) și `Fișier`. `Fişierul` de logare include fişierul `log.txt` în directorul programului şi `log-uri` în scopuri de arhivare.

Folosind configurarea NLog personalizată, dezactivează automat configurarea ASF implicită, configurarea dvs. suprascrie **complet** logare ASF implicită, ceea ce înseamnă că dacă doriți să păstrați. . ținta noastră `ColoredConsole` , apoi trebuie să o definiți cu ****. Acest lucru vă permite nu numai să adăugați **extra** ținte logging, ci și să dezactivați sau să modificați cele din **implicite**.

Dacă doriți să utilizați logarea ASF implicită fără modificări, nu trebuie să faci nimic - nici nu este nevoie să îl definești în NLog-ul personalizat `onfig`. Cu toate acestea, pentru referință, echivalentul înregistrării implicite ASF hardcoded ar fi:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir:cached=true}/logs/log.txt" archiveOldFileOnStartup="true" archiveSuffixFormat=".{1:yyyyMMdd-HHmmss}" fileName="${currentdir:cached=true}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- Below becomes active when ASF's IPC interface is started -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="File" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- Below becomes active when ASF's IPC interface is enabled -->
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="History" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## Integrare ASF

ASF include unele trucuri de cod frumoase care îmbunătățesc integrarea sa cu NLog, permițându-ți să primești mesaje specifice mai ușor.

NLogspecific `${logger}` va distinge întotdeauna sursa mesajului - fie `BotName` al unuia dintre roboții tăi, sau `ASF` dacă mesajul vine de la ASF proces direct. În acest fel puteți să primiți cu ușurință mesaje luând în considerare anumite bot(uri), sau proces ASF (doar), în loc de toate, bazat pe numele loggerului.

ASF încearcă să marcheze mesajele în mod corespunzător pe baza nivelurilor de logare furnizate de NLog, care vă permite să prindeți doar mesaje specifice de la nivele de jurnal specifice în loc de toate acestea. Desigur, nivelul de logare pentru un anumit mesaj nu poate fi personalizat, deoarece este o decizie hardcoded ASF cât de serios este mesajul, dar cu siguranță poți face ASF mai puțin/mai silențios, așa cum se potrivește.

ASF înregistrează informații suplimentare, cum ar fi mesaje de utilizator/chat pe `Urmăriți` nivel de logare. Jurnalele ASF implicite sunt doar `Nivelul Debug` și superioare, care ascunde aceste informații suplimentare, pentru că nu este necesar pentru majoritatea utilizatorilor, la care se adaugă rezultate care conţin mesaje potenţial mai importante. Cu toate acestea, puteți folosi această informație reactivând nivelul de logare `Urmăriți` , în special în combinație cu logarea unui singur anumit bot la alegere, cu un anumit eveniment de care sunteți interesat.

În general, ASF încearcă să o facă cât mai ușoară și mai convenabilă pentru dvs., pentru a înregistra doar mesajele pe care le doriți în loc să vă forțați să le filtrați manual prin instrumente terțe cum ar fi `grep` și deopotrivă. Configurați NLog în mod corespunzător așa cum este scris mai jos, și ar trebui să puteți specifica chiar și reguli de logare foarte complexe cu ținte personalizate, cum ar fi întregi baze de date.

Referitor la versionare - ASF încearcă să livreze întotdeauna cu cea mai actualizată versiune de NLog disponibilă pe **[NuGet](https://www.nuget.org/packages/NLog)** la momentul lansării ASF. Nu ar trebui să fie o problemă să folosești orice funcție pe care o poți găsi pe NLog wiki în ASF - doar asigură-te că folosești și ASF actualizat.

Ca parte a integrării ASF, ASF include, de asemenea, sprijin pentru obiective suplimentare privind jurnalul de exploatare al ASF, care vor fi explicate mai jos.

---

## Exemple

Exemplele de mai jos vă arată cum puteți personaliza logarea după placul dvs.

Pentru început, vom folosi doar ținta **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)**. `NLog.config` va arăta în felul următor:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Explicația configurării de mai sus este destul de simplă - definim un **logging target**, care este `ColoredConsole`, apoi redirecționăm **toți loggerii** (`*`) de nivelul `Depanare` și mai mare la `ColoredConsole` pe care l-am definit mai devreme.

Dacă începeți ASF cu `NLog. onfig` acum, doar `ColoredConsole` va fi activ, și ASF nu va scrie în `Fișierul`, indiferent de configurarea ASF NLog cu hardcod.

Since we didn't define a lot of properties, such as `layout`, it was initialized to a default built-in value, in this case `${longdate}|${level:uppercase=true}|${logger}|${message}`. Îl putem personaliza, de exemplu, doar prin logarea mesajelor:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Dacă lansați ASF acum, veți observa acea dată, nivelul și numele de logger au dispărut - lăsând doar cu mesaje ASF în format `Function() Mesaj`.

Putem modifica, de asemenea, configurația pentru a se loga la mai mult de o țintă. Hai să ne conectăm la `ColoredConsole` şi **[`Fişier`](https://github.com/nlog/nlog/wiki/File-target)** în acelaşi timp.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Debug" writeTo="File" />
  </rules>
</nlog>
```

Şi am făcut acest lucru, acum vom loga totul la `ColoredConsole` şi `Fişier`. Ați observat că puteți specifica și opțiunile personalizate `fileName` și suplimentare?

În cele din urmă, ASF folosește diferite niveluri de jurnale pentru a vă ajuta să înțelegeți ce se întâmplă. Putem folosi acea informaţie pentru a modifica jurnalul de gravitate. Să spunem că vrem să înregistrăm totul (`Urmărire`) la `Fișierul`, dar numai `Avertizare` și peste nivelul **[](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** la `ColoredConsole`. Putem realiza acest lucru prin modificarea regulilor noastre ``:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Warn" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Trace" writeTo="File" />
  </rules>
</nlog>
```

Asta e tot, acum `ColoredConsole` va afișa doar avertismente și mai sus, în timp ce tot logați totul la `Fișierul`. Îl poți ajusta și mai mult pentru a loga, de ex. doar `Info` și mai jos, și așa mai departe.

În cele din urmă, hai să facem ceva puțin mai avansat și să înregistrăm toate mesajele în fișier, dar numai de la botul numit `LogBot`.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="LogBotFile" fileName="${currentdir:cached=true}/LogBot.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="LogBot" minlevel="Trace" writeTo="LogBotFile" />
  </rules>
</nlog>
```

Puteți vedea cum am folosit integrarea ASF deasupra și cum putem distinge sursa mesajului bazat pe proprietatea `${logger}`.

---

## Utilizare avansată

Exemplele de mai sus sunt destul de simple și făcute pentru a vă arăta cât de ușor este să vă definiți propriile reguli de logare care pot fi utilizate cu ASF. Puteţi utiliza NLog pentru diferite lucruri, inclusiv obiective complexe (cum ar fi păstrarea jurnalelor în `Baza de date`), rotaţia jurnalelor (cum ar fi ştergerea jurnalelor vechi `fişiere` ), folosind aspectul ``personalizat, declarați filtrele de logare `<when>` și multe altele. Te încurajez să citești în întregime **[Documentația NLog](https://github.com/nlog/nlog/wiki/Configuration-file)** pentru a afla despre fiecare opțiune care îți este disponibilă, vă permite să reglați modulul de logare ASF în modul dorit. Este o unealtă foarte puternică și personalizarea jurnalului ASF nu a fost niciodată mai ușoară.

---

## Limitări

ASF va dezactiva temporar **toate regulile** care includ `ColoredConsole` sau `Console` la așteptarea introducerii utilizatorului. Prin urmare, dacă doriți să continuați să vă logați pentru alte obiective, chiar și atunci când ASF așteaptă intrarea utilizatorului, ar trebui să definiți aceste obiective cu propriile lor reguli, după cum se arată în exemplele de mai sus, în loc să pui mai multe ținte în `writeTo` de aceeași regulă (cu excepția cazului în care acesta este comportamentul dorit). Dezactivarea temporară a țintelor de consolă se face pentru a menține consola curată atunci când se așteaptă intrarea utilizatorului.

---

## Chat logging

ASF include suport extins pentru jurnalizarea chaturilor prin nu doar înregistrarea tuturor mesajelor primite/trimise pe nivelul de logare `Urmărire` , dar, de asemenea, expunând informații suplimentare legate de ele în **[proprietățile evenimentului](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Asta pentru că oricum trebuie să ne ocupăm de mesaje de chat ca comenzi, astfel încât să nu ne coste nimic să înregistrăm aceste evenimente pentru a vă permite să adăugați loguri suplimentare (cum ar fi crearea ASF arhivei tale personale de chat Steam).

### Proprietăți eveniment

| Nume        | Descriere                                                                                                                                                                                                                                            |
| ----------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Ecou        | `bool` type. Acest lucru este setat pe `true` atunci când mesajul este trimis de noi destinatarului, iar în caz contrar `false`.                                                                                                                     |
| Mesaj       | Tip `șir`. Acesta este mesajul trimis/primit efectiv.                                                                                                                                                                                                |
| ChatGroupID | `ulong` type. Acesta este ID-ul chat-ului de grup pentru mesaje trimise/primite. Va fi `0` când nici o discuție de grup nu este folosită pentru transmiterea acestui mesaj.                                                                          |
| ChatID      | `ulong` type. Acesta este ID-ul canalului `ChatGroupID` pentru mesajele trimise/primite. Va fi `0` când nici o discuție de grup nu este folosită pentru transmiterea acestui mesaj.                                                                  |
| SteamID     | `ulong` type. Acesta este ID-ul utilizatorului Steam pentru mesajele trimise/primite. Poate fi `0` când niciun utilizator nu este implicat în transmiterea mesajului (e. . când este vorba despre trimiterea unui mesaj către o conversație de grup. |

### Exemplu

Acest exemplu se bazează pe exemplul de bază `ColoredConsole` de mai sus. Înainte de a încerca să o înțelegem, Vă recomand insistent să aruncați o privire **[de mai sus](#examples)** pentru a afla mai întâi despre elementele de bază ale NLog loging.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="ChatLogFile" fileName="${currentdir:cached=true}/logs/chat/${event-properties:item=ChatGroupID}-${event-properties:item=ChatID}${when:when='${event-properties:item=ChatGroupID}' == 0:inner=-${event-properties:item=SteamID}}.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss} ${event-properties:item=Message} ${when:when='${event-properties:item=Echo}' == true:inner=-&gt;:else=&lt;-} ${event-properties:item=SteamID}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="MainAccount" level="Trace" writeTo="ChatLogFile">
      <filters defaultAction="Log">
        <when condition="not starts-with('${message}','OnIncoming') and not starts-with('${message}','SendMessage')" action="Ignore" />
      </filters>
    </logger>
  </rules>
</nlog>
```

Am început de la exemplul nostru de bază `ColoredConsole` şi l-am extins mai departe. În primul rând, Am pregătit un fișier jurnal de chat permanent pentru fiecare canal de grup și utilizator de Steam - acest lucru este posibil datorită proprietăților suplimentare pe care ASF ni le prezintă într-un mod extravagant. Am decis de asemenea să avem un aspect personalizat care scrie doar data curentă, mesajul, informațiile trimise/primite și utilizatorul Steam însuși. În cele din urmă, am activat regula noastră de logare a chat-ului doar pentru nivelul `Urmărire` , numai pentru botul nostru `MainAccount` și doar pentru funcțiile legate de jurnalizarea chaturilor (`OnIncoming*` care este folosit pentru primirea de mesaje și ecouri, și `Mesaj trimis*` pentru trimiterea mesajelor ASF).

Exemplul de mai sus va genera fişierul `logs/chat/0-76561198069026042.txt` atunci când vorbiți cu **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**

```text
2018-07-26 01:38:38 ce faci? -> 76561198069026042
2018-07-26 01:38:38 Mă descurc grozav, ce ziceți de tine? <- 76561198069026042
```

Bineînţeles că acesta este doar un exemplu care oferă câteva trucuri practice arătate în mod practic. Puteți extinde această idee la propriile nevoi, cum ar fi filtre suplimentare, ordine personalizată, aspect personal, înregistrare doar a mesajelor primite și așa mai departe.

### Alt exemplu

Acesta folosește `SteamTarget` pentru a trimite un mesaj către steamID-ul botului principal (`76561198006963719`) când botul numit `archi` primește un comerț cu donații. Necesită un alt bot în proces (deoarece nu îți poți trimite mesaje).

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" />
  </targets>

  <rules>
    <logger name="archi" level="Trace" writeTo="Steam">
      <filters defaultAction="Ignore">
        <when condition="starts-with('${message}','ParseTrade() Accepted donation trade: ')" action="Log" />
      </filters>
    </logger>
  </rules>
</nlog>
```

---

## Obiective ASF

În plus față de țintele standard NLog logging (cum ar fi `ColoredConsole` și `Fișier` explicate mai sus), poți folosi, de asemenea, ținte de logare ASF personalizate.

Pentru o finalitate maximă, definirea țintelor ASF va urma convenția privind documentația NLog documentation.

---

### Țintă SteamTel

După cum puteți ghici, această țintă folosește mesaje de chat Steam pentru logarea mesajelor ASF. Îl poți configura pentru a utiliza fie o conversație de grup, fie o conversație privată. Pe lângă specificarea unei ținte de Steam pentru mesajele dumneavoastră, de asemenea, puteți specifica `botName` botului care ar trebui să le trimită.

Susținut în toate mediile utilizate de ASF.

---

#### Sintaxa configuratiei
```xml
<targets>
  <target type="Steam"
          name="String"
          layout="Layout"
          chatGroupID="Ulong"
          steamID="Ulong"
          botName="Layout" />
</targets>
```

Citește mai multe despre utilizarea fișierului de configurare [](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametri

##### Opţiuni generale
_numele_ - Numele țintei.

---

##### Opțiuni aspect
_layout_ - Textul trebuie redat. [Aspect](https://github.com/NLog/NLog/wiki/Layouts) Necesar. Implicit: `${nivel:uppercase=true}•${logger}•${message}`

---

##### Opțiuni țintă SteamTel

_chatGroupID_ - ID-ul chat-ului de grup declarat ca număr întreg nesemnat de 64 de biți. Nu este obligatoriu. Implicit `0` care va dezactiva funcționalitatea conversațiilor de grup și va utiliza chat-ul privat în schimb. Când este activat (setat la o valoare non-zero), `Proprietatea steamID` de mai jos acționează ca `chatID` și specifică ID-ul canalului în acest `chatGroupID` la care bot-ul trebuie să trimită mesaje.

_steamID_ - SteamID declarat ca un număr întreg nesemnat de 64 de biți al utilizatorului țintă Steam (ca `SteamOwnerID`), sau țintă `chatID` (când `chatGroupID` este setat). Necesar. Implicit `0` care dezactivează complet logging-ul țintă.

_botName_ - Numele botului (recunoscut de ASF, caz-sensibil) care va trimite mesaje la `steamID` declarat mai sus. Nu este obligatoriu. Implicit `null` care va selecta automat **orice** bot conectat în prezent. Este recomandat să setați această valoare în mod corespunzător, deoarece `SteamTarget` nu ia în considerare multe limitări ale Steam, cum ar fi faptul că trebuie să ai `steamID` al țintei de pe lista ta de prieteni. Această variabilă este definită ca [layout](https://github.com/NLog/NLog/wiki/Layouts) , deci poți folosi sintaxa specială în ea, cum ar fi `${logger}` pentru a utiliza botul care a generat mesajul.

---

#### Exemple Target SteamTarget

Pentru a scrie toate mesajele de `Depanare` nivel și mai mare, de la bot numit `MyBot` la steamID `76561198006963719`, ar trebui să folosiți `NLog. onfig` similar cu mai jos:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**Nota:** `SteamTarget` este un obiectiv personalizat, astfel încât să vă asigurați că declarați ca `type="Steam"`NU `xsi:type="Steam"`, ca xsi este rezervat pentru obiectivele oficiale suportate de NLog.

Când lansezi ASF cu `NLog. onfig` similar cu cele de mai sus, `MyBot` va începe mesageria `76561198006963719` Utilizator Steam cu toate mesajele obișnuite din jurnalul ASF. Rețineți că `MyBot` trebuie să fie conectat pentru a trimite mesaje, astfel încât toate mesajele ASF inițiale care s-au întâmplat înainte ca bot-ul nostru să se poată conecta la rețeaua Steam, nu vor fi redirecționate.

Bineînțeles, `SteamTarget` are toate funcțiile tipice la care te poți aștepta de la generic `TargetWithLayout`, astfel încât să îl puteţi utiliza împreună cu e. . machete personalizate, nume sau reguli avansate de logare. Exemplul de mai sus este doar cel mai elementar.

---

#### Capturi ecran

![Captură](https://i.imgur.com/5juKHMt.png)

---

#### Cavalerie

Ai grijă atunci când decizi să combini nivelul de logare `Debug` sau mai mic în `SteamTarget` cu `steamID` care ia parte la procesul ASF. Acest lucru poate duce la potențialul `StackOverflowException` pentru că vei crea o buclă infinită de ASF pentru primirea mesajului dat, apoi autentificându-l prin Steam, rezultând un alt mesaj care trebuie logat. În prezent, singura posibilitate pentru ca aceasta să se întâmple este să înregistreze nivelul `Urmărire` (unde ASF înregistrează propriile mesaje de chat), sau `Depanare` în timp ce rulează, de asemenea, ASF în modul `Depanare` (unde ASF înregistrează toate pachetele Steam).

In short, if your `steamID` is taking part in the same ASF process, then the `minlevel` logging level of your `SteamTarget` should be `Info` (or `Debug` if you're also not running ASF in `Debug` mode) and above. Alternativ, îți poți defini propriile filtre de logare `<when>` pentru a evita o buclă infinită de logare, dacă modificarea nivelului nu este adecvată în cazul dumneavoastră. Această măsură se aplică și în cazul discuțiilor de grup.

---

### HistoryTarget

Această țintă este utilizată intern de ASF pentru furnizarea istoricului logging în format fix în `/Api/NLog` final **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** care poate fi consumat ulterior de ASF-ui și de alte unelte. În general, ar trebui să definiți această țintă numai dacă utilizați deja configurare NLog personalizată pentru alte personalizări și doriți ca jurnalul să fie expus în API ASF, . pentru ASF-ui. De asemenea, poate fi declarat atunci când doriţi să modificaţi aspectul implicit sau `maxCount` mesajelor salvate.

Susținut în toate mediile utilizate de ASF.

---

#### Sintaxa configuratiei
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Citește mai multe despre utilizarea fișierului de configurare [](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parametri

##### Opţiuni generale
_numele_ - Numele țintei.

---

##### Opțiuni aspect
_layout_ - Textul trebuie redat. [Aspect](https://github.com/NLog/NLog/wiki/Layouts) Necesar. Implicit: `${date:format=yyyy-MM-dd H\:mm\:ss}<unk>${processname}-${processid}<unk> ${nivel:uppercase=true}•${logger}•${message}${onexception:inner= ${exception:format=toString,data}}`

---

##### Istoricul Opțiunile Țintei

_maxCount_ - Numărul maxim de jurnale stocate pentru istoricul la cerere. Nu este obligatoriu. Implicit `20` care este un echilibru bun pentru furnizarea istoricului inițial, fără a pierde din vedere utilizarea memoriei care rezultă din cerinţele de stocare. Trebuie să fie mai mare decât `0`.