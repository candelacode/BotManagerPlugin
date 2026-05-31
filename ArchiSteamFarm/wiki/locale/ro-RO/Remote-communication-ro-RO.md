# Comunicații la distanță

Această secțiune detaliază comunicarea la distanță pe care ASF o include, inclusiv explicații suplimentare privind modul în care o poate influența. Deși nu considerăm nimic de mai jos ca fiind răuvoitor sau altfel nedorit, și nici ca suntem obligați din punct de vedere legal să îl divulgăm, vrem să înțelegi mai bine funcționalitatea programului, în special în ceea ce privește confidențialitatea și schimbul de date.

## Steam

ASF comunică cu rețeaua Steam (**[servere CM](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), precum şi **[Steam API](https://steamcommunity.com/dev)**, **[Steam store](https://store.steampowered.com)** and **[Steam](https://steamcommunity.com)**.

Nu este posibil să dezactivezi niciuna dintre comunicările de mai sus, pentru că este fundația de bază a ASF se bazează pe aceasta pentru a oferi funcționalitatea sa de bază. Va trebui să te abții de la utilizarea ASF dacă nu ești confortabil cu cele de mai sus.

## Grupul Steam

ASF comunică cu grupul nostru **[Steam](https://steamcommunity.com/groups/archiasf)**. Grupul vă oferă anunţuri, în special noi versiuni, probleme critice, probleme cu Steam şi alte lucruri importante pentru actualizarea comunităţii. De asemenea, vă permite să utilizaţi sprijinul nostru tehnic, punând întrebări, rezolvând probleme, raportând probleme sau sugerând îmbunătăţiri. În mod implicit, conturile utilizate în ASF se vor alătura automat grupului la autentificare.

Puteți decide să renunțați la aderarea la grup prin dezactivarea setărilor `SteamGroup` în secțiunea **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)**.

## GitHub

ASF communicates with **[GitHub's API](https://api.github.com)** in order to fetch **[ASF releases](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** for the update functionality. Acest lucru se face ca parte din actualizările automate (dacă ați păstrat **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** activat), precum şi `actualizează` **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Puteți influența comunicarea ASF cu GitHub prin **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** proprietate - setarea lui `Nunu` va duce la dezactivarea întregii funcționalități de actualizare, includerea comunicării GitHub în acest sens.

## Server ASF

ASF comunică cu **[propriul nostru server](https://asf.justarchi.net)** pentru o funcționalitate mai avansată. În special, acestea includ:
- Verificarea sumelor de control ASF descărcate de pe GitHub împotriva propriei noastre baze de date independente pentru a ne asigura că toate construcțiile descărcate sunt legitime (fără malware, Atacuri MITM sau alte manipulări)
- Fetching list of bad bots for filtering if you've kept `FilterBadBots` global config setting enabled.
- Anunțarea botului în **[lista noastră](https://asf.justarchi.net/STM)** dacă ai activat `SteamTradeMatcher` în **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** și îndeplinesc alte criterii
- Descărcarea boților disponibili în prezent pentru a tranzacționa de la **[lista noastră](https://asf.justarchi.net/STM)** dacă ai activat `MatchActively` în **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** și îndeplinesc alte criterii

Ca măsură de securitate, nu este posibil să dezactivezi verificarea sumei de control pentru clădirile ASF. Cu toate acestea, puteți dezactiva complet actualizările dacă doriți să evitați acest lucru, așa cum este descris mai sus în secțiunea GitHub.

Puteți dezactiva setarea `FilterBadBots` dacă doriți să evitați preluarea listei de pe server.

Puteți decide să renunțați la a fi anunțat în listă prin dezactivarea setărilor `PublicListing` în secțiunea **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** Acest lucru ar putea fi util dacă doriți să rulați botul `SteamTradeMatcher` fără a fi anunțat în același timp.

Descărcarea boților din lista noastră este obligatorie pentru setarea `Potrivire` , va trebui să dezactivați setarea dacă nu doriți să acceptați acest lucru.