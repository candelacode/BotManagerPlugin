# Compatibilitate

ASF este o aplicație C# care rulează pe platforma NET. Asta înseamnă că ASF nu este compilat direct în **[cod mașină](https://en.wikipedia.org/wiki/Machine_code)** care rulează pe procesorul tău, dar în **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)** care necesită o rulare compatibilă cu CIL pentru executare.

Această abordare prezintă o cantitate considerabilă de avantaje, căci de fapt este independentă de platformă. De aceea, ASF poate rula nativ pe multe sisteme de operare disponibile, în special Windows, Linux și macOS. Nu este nevoie doar de emulație, ci și de suport pentru toate optimizările legate de platformă și cele legate de hardware, cum ar fi instrucțiunile CPU SSE. Datorită acestui fapt, ASF poate obține o performanță și optimizare superioare, oferind în același timp compatibilitate și fiabilitate.

Acest lucru înseamnă că ASF nu are **nicio cerință specifică pentru OS**, pentru că necesită doar să rulați **runtime** pe acel OS și nu necesită modificări de OS directe. Atâta timp cât acea execuție execută codul ASF corect, nu contează dacă sistemul de operare de bază este Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii sau prăjitorul dumneavoastră - atâta timp cât există **[. ET pentru aceasta](https://dotnet.microsoft.com/download/dotnet)**există **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** pentru el (în varianta `generic`).

Cu toate acestea, indiferent unde rulați ASF, trebuie să vă asigurați că platforma țintă are **[.NET premise](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** instalate. Acestea sunt biblioteci de nivel scăzut necesare pentru funcționalitatea corespunzătoare a runtime și absolut esențiale pentru ca ASF să funcționeze în primul rând. Este foarte probabil ca unele dintre ele (sau chiar toate) să fie deja instalate.

---

## Ambalaj ASF

ASF este furnizat în 2 arome principale – ambalaj generic și specific sistemului de operare (SO). Ambele pachete din punct de vedere funcţional sunt exact la fel, ambele pot să se actualizeze automat. Singura diferență dintre ele este dacă pachetul ASF **generic** vine cu **OSspecific** rulează pentru a-l alimenta.

---

### Generic

Pachetul generic este o construcţie de platform-agnostic care nu include nici un cod specific maşinii. Această configurare necesită de la dvs. ca .NET să fie deja instalat pe OS **în versiunea corespunzătoare**. Știm cu toții cât de îngrijorător este să ținem dependențele la zi, prin urmare acest pachet este aici în principal pentru persoanele care folosesc **deja** . ET și nu doresc să își duplice rularea doar pentru ASF dacă pot folosi ceea ce au instalat deja. Pachetul generic îți permite, de asemenea, să rulezi ASF **oriunde, atâta timp cât poți obține implementarea operațională a . ET runtime**, indiferent dacă există ASF specific OS, sau nu.

Nu este recomandat să folosești aromă generică dacă ești un utilizator ocazional sau chiar avansat care vrea doar să facă ASF să funcționeze și să nu sape. Detalii tehnice privind ET. Cu alte cuvinte - dacă ştiţi ce este acest lucru, îl puteţi utiliza, altfel este mult mai bine să utilizaţi pachetul specific OS, explicat mai jos.

---

### OZspecific

Pachetul specific OS, în afară de codul gestionat inclus în pachetul generic, include, de asemenea, codul nativ pentru platforma dată. In other words, OS-specific package **already includes proper .NET runtime inside**, which allows you to entirely skip the whole installation mess and just launch ASF directly. Pachetul specific OS, deoarece puteți ghici din nume, este specific sistemului de operare și fiecare OS necesită propria versiune - de exemplu, Windows necesită PE32+ `ArchiSteamFarm. xe` binar în timp ce Linux funcţionează cu binar Unix ELF `ArchiSteamFarm`. După cum este posibil să știți, aceste două tipuri nu sunt compatibile între ele.

ASF este disponibil în prezent în următoarele variante specifice OS:

- `linux-arm` funcționează pe 32-bit ARM (ARMv7+) GNU/Linux OSes cu glibc 2.35/musl 1.2.3 și mai nou. This variant covers platforms such as Raspberry Pi 2 (and newer), it will **not** work with older ARM architectures, such as ARMv6 found in Raspberry Pi 0 & 1, it will also not work with OSes that do not implement required GNU/Linux environment (such as Android).
- `linux-arm64` funcţionează pe 64-bit ARM (ARMv8+) GNU/Linux OSes cu glibc 2.27/musl 1.2.3 şi mai nou. This variant covers platforms such as Raspberry Pi 3 (and newer), it will **not** work with 32-bit OSes that do not have required 64-bit libraries available (such as 32-bit Raspberry Pi OS), it will also not work with OSes that do not implement required GNU/Linux environment (such as Android).
- `linux-x64` funcţionează pe 64-bit GNU/Linux OSes cu glibc 2.27/musl 1.2.3 şi mai nou.
- `osx-arm64` funcționează pe sisteme macOS bazate pe 64-bit (silicon Apple) în versiunea 13 și mai noi.
- `osx-x64` funcționează pe macOS 64-bit în versiunea 15 și mai nouă.
- `win-arm64` funcționează pe **up-to-date** 64-bit ARM (ARMv8+) Windows OSes în versiunea 10, 11 și mai nouă.
- `win-x64` funcționează pe **modern** 64-bit Windows OSes în versiunea 10, 11, Server 2016+ și mai nou.

Bineînțeles, chiar dacă nu ai un pachet specific OS-ului disponibil pentru combinația de arhitectură OS, poți instala întotdeauna corespunzător. ET vă desfăşoară în timp util şi are aromă ASF generică, acesta fiind şi principalul motiv pentru care există în primul rând. Construirea Generică ASF este de tip platform-agnostic și va rula pe orice platformă care are un .NET runtime funcțional. Acest lucru este important de menționat - ASF necesită .NET runtime, nu un anumit OS sau arhitectură. De exemplu, dacă rulezi Windows cu 32 biți în ciuda faptului că nu ai o versiune `win-x86` dedicată, încă poți instala . ET SDK în versiunea `win-x86` și rulează ASF generic doar bine. Pur şi simplu nu putem ţinti fiecare combinaţie de arhitectură de sistem care există şi este folosită de cineva, aşa că trebuie să desenăm undeva o linie. x86 este un bun exemplu pentru acea linie, deoarece arhitectura este învechită cel puțin din 2004.

Pentru o listă completă a tuturor platformelor suportate și a OS-urilor de către .NET 10.0, vizitează **[notele de lansare](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md)**.

---

## Cerințe privind timpul de lucru

Dacă utilizați un pachet specific OS, nu trebuie să vă faceți griji cu privire la cerințele runtime, pentru că ASF întotdeauna livrează cu timpul de execuție necesar și actualizat, care va funcționa corect atât timp cât aveți **[. Condiţii preliminare ET](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** instalate şi actualizate. Cu alte cuvinte, **nu trebuie să instalezi . ET runtime sau SDK**, deoarece modulele specifice OS-ului necesită doar dependențe native ale OS (condiții prealabile) și nimic altceva.

Cu toate acestea, dacă încercați să executați pachetul **generic** ASF, atunci trebuie să vă asigurați că platforma dvs. .NET runtime acceptă platforma de suport ASF.

ASF ca program țintește **.NET 10.0** (`net10.`) în prezent, dar poate viza o platformă mai nouă în viitor. `net10.0` este suportat de 10.0.100 SDK (10.0. alergat), deși ASF ar putea prefera **ultimul termen din momentul compilării**, astfel încât să vă asiguraţi că aveţi **[cea mai recentă SDK](https://dotnet.microsoft.com/download)** (sau cel puţin runtime) disponibilă pentru maşina dumneavoastră. Varianta generică ASF poate refuza lansarea dacă timpul tău de execuție este mai mare decât cel minim acceptat în timpul compilării.

Dacă aveți dubii, verificați ce **[integrare continuă folosește](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pentru compilarea și implementarea versiunilor ASF pe GitHub. Poți găsi `dotnet --info` în fiecare construcție ca parte a pasului de verificare .NET.