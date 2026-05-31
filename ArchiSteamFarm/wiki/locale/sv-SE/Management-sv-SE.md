# Hantering

Detta avsnitt behandlar ämnen som rör hantering av ASF-processen på bästa sätt. Även om det inte är strikt obligatoriskt för användning, innehåller det massor av tips, trick och god praxis som vi skulle vilja dela, speciellt för systemadministratörer, personer som paketerar ASF för användning i tredjepartsarkiv, såväl som avancerade användare och liknande.

---

## Tjänsten `systemd` för Linux

I `generiska` och `linux` varianter kommer ASF med `ArchiSteamFarm@. ervice` fil, vilket är en konfigurationsfil för tjänsten **[`systemd`](https://systemd.io)**. Om du vill köra ASF som en tjänst, till exempel för att starta den automatiskt efter start av din maskin, sedan en ordentlig `systemd` tjänst är utan tvekan det bästa sättet att göra det, därför rekommenderar vi det starkt istället för att hantera det på egen hand genom `nohup`, `skärm` eller lika.

För det första, skapa kontot för användaren du vill köra ASF under, förutsatt att det inte finns ännu. Vi kommer att använda `asf` användare för detta exempel, om du bestämde dig för att använda en annan, du måste ersätta `asf` användare i alla våra exempel nedan med din valda. Vår tjänst tillåter dig inte att köra ASF som `root`eftersom det anses vara en **[dålig praxis](#never-run-asf-as-administrator)**.

```sh
su # Eller sudo -i, för att komma in i rotskalet
useradd -m asf # Skapa konto som du avser att köra ASF under
```

Därefter packa upp ASF till `/home/asf/ArchiSteamFarm` mapp. Mappstrukturen är viktig för vår serviceenhet, det ska vara `ArchiSteamFarm` mapp i din `$HOME`, så `/home/<user>`. Om du gjorde allt på rätt sätt, kommer det att finnas `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service` fil finns. Om du använder variant `linux` och inte packa upp filen på Linux, men till exempel använd filöverföring från Windows, då måste du också `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

Vi kommer att göra alla nedanstående åtgärder som `root`, så kom till sitt skal med `su` eller `sudo -i`.

För det första är det en bra idé att se till att vår mapp fortfarande tillhör vår `asf` användare, `chown -hR asf:asf /home/asf/ArchiSteamFarm` körs en gång kommer att göra det. Behörigheterna kan vara fel, t.ex. om du har hämtat och/eller packat upp zip-filen som `root`.

För det andra, om du använder generisk variant av ASF, du måste se till att kommandot `dotnet` känns igen och inom en av standardplatserna: `/usr/local/bin`, `/usr/bin` eller `/bin`. Detta krävs för vår systemd-tjänst som kör `dotnet /path/to/ArchiSteamFarm.dll` kommando. Markera om `dotnet --info` fungerar för dig, om ja, skriv kommandot `-v dotnet` för att ta reda på var det finns. Om du har använt officiellt installationsprogram bör det vara i `/usr/bin/dotnet` eller en av de två andra platserna, vilket är okej. Om det är på anpassad plats som `/usr/share/dotnet/dotnet`, skapa en **[symlänk](https://wikipedia.org/wiki/Symbolic_link)** för den med `ln -s "$(command -v dotnet)" /usr/bin/dotnet`. Nu `kommando -v dotnet` bör rapportera `/usr/bin/dotnet`, vilket också kommer att få vår systemenhet att fungera. Om du använder OS-specifik variant behöver du inte göra något i detta avseende.

Därefter kör `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/system/system/ArchiSteamFarm\@. ervice`, detta kommer att skapa en symbolisk länk till vår tjänstedeklaration och registrera den i `systemd`. Symbolisk länk kommer att tillåta ASF att uppdatera din `systemd` enhet automatiskt som en del av ASF uppdatering - beroende på din situation, du kanske vill använda den metoden, eller helt enkelt `cp` filen och hantera den själv hur du vill.

Efteråt, se till att `systemd` känner igen vår tjänst:

```
systemctl-status ArchiSteamFarm@asf

<unk> ArchiSteamFarm@asf.service - ArchiSteamFarm Service (på asf)
     Laddad: laddad (/etc/systemd/system/ArchiSteamFarm@. ervice; inaktiverad; vendor preset: aktiverad)
     Active: inactive (dead)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Var särskilt uppmärksam på användaren vi deklarerar efter `@`, det är `asf` i vårt fall. Vår systemtjänstenhet förväntar sig av dig att deklarera användaren, eftersom det påverkar den exakta platsen för den binära `/home/<user>/ArchiSteamFarm`, såväl som den faktiska användarsystemet kommer att skapa processen som.

Om systemd returnerade utdata som liknar ovan, allt är i ordning, och vi är nästan klara. Nu är allt som finns kvar faktiskt startar vår tjänst som vår valda användare: `systemctl start ArchiSteamFarm@asf`. Vänta en sekund eller två, och du kan kontrollera statusen igen:

```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (på asf)
     Laddad: laddad (/etc/systemd/system/ArchiSteamFarm@.service; inaktiverad; leverantörsförinställning: aktiverad)
     Aktiv: aktiv (kör) sedan (...)
       Dokument: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   Main PID: (...)
(...)
```

Om `systemd` anger `aktiv (kör)`, det innebär att allt gick bra, och du kan kontrollera att ASF-processen bör vara igång, till exempel med `journalctl -r`, som ASF som standard skriver också till sin konsolutgång, som är inspelad av `systemd`. Om du är nöjd med installationen du har just nu, kan du säga till `systemd` att automatiskt starta din tjänst under uppstart, genom att köra `systemctl aktivera ArchiSteamFarm@asf` kommandot. Det är allt.

Om du av någon chans vill stoppa processen, kör helt enkelt `systemctl stop ArchiSteamFarm@asf`. Likaså, om du vill inaktivera ASF från att startas automatiskt vid uppstart, `systemctl inaktivera ArchiSteamFarm@asf` kommer att göra det åt dig, det är mycket enkelt.

Observera att eftersom det inte finns någon standardinmatning aktiverad för vår `systemd` tjänst, du kommer inte att kunna mata in dina uppgifter genom konsolen på vanligt sätt. Att köra genom `systemd` motsvarar att ange **[`Headless: true`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** inställning och kommer med alla dess konsekvenser. Lyckligtvis för dig, det är mycket lätt att hantera din ASF genom **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, som vi rekommenderar om du behöver lämna ytterligare information under inloggningen eller på annat sätt hantera din ASF-process ytterligare.

### Miljö variabler

Det är möjligt att tillhandahålla ytterligare miljövariabler till tjänsten `systemd` vilket du är intresserad av om du till exempel vill använda en anpassad `--cryptkey` **[kommandoradsargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**, specificerar därför `ASF_CRYPTKEY` miljövariabel.

För att tillhandahålla anpassade miljövariabler, skapa `/etc/asf` mapp (ifall den inte finns), `mkdir -p /etc/asf`. Vi rekommenderar att `chown -hR root:root /etc/asf && chmod 700 /etc/asf` för att säkerställa att endast `root` användare har tillgång till att läsa dessa filer, eftersom de kan innehålla känsliga egenskaper som `ASF_CRYPTKEY`. Skriv därefter till en `/etc/asf/<user>` -fil, där `<user>` är användaren du kör tjänsten under (`asf` i vårt exempel ovan, så `/etc/asf/asf`).

Filen ska innehålla alla miljövariabler som du vill ge till processen. De som inte har en särskild miljövariabel, kan deklareras i `ASF_ARGS`:

```sh
# Förklara endast de som du faktiskt behöver
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# Och andra som du är intresserad av
```

### Åsidosättande del av serviceenheten

Tack vare flexibiliteten i `systemd`, Det är möjligt att skriva över en del av ASF-enheten samtidigt som den fortfarande bevarar den ursprungliga enhetsfilen och tillåter ASF att uppdatera den till exempel som en del av auto-uppdateringar.

I det här exemplet vill vi ändra standard ASF `systemd` enhetsbeteende från att bara starta om på framgång, till att starta om även vid dödliga krascher. För att göra det, Vi åsidosätter `Starta om` -egenskapen under `[Service]` från standard `succé` till `alltid`. Helt enkelt köra `systemctl redigera ArchiSteamFarm@asf`, naturligt ersätta `asf` med målanvändaren av din tjänst. Lägg sedan till dina ändringar som indikeras av `systemd` i rätt avsnitt:

```sh
### Redigering /etc/systemd/system/ArchiSteamFarm@asf.service.d/override. onf
### Någonting mellan här och kommentaren nedan kommer att bli det nya innehållet i filen

[Service]
Restart=always

### Linjer under denna kommentar kommer att kasseras

### /etc/systemd/ArchiSteamFarm@asf. ervice
# [Install]
# WantedBy=multi-användare. arget
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm. ll --no-restart --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# User=%i
# (...)
```

Och det är det, nu din enhet agerar samma som om den bara hade `Restart=always` under `[Service]`.

Naturligtvis är alternativ till `cp` filen och hantera den själv, men detta ger dig möjlighet till flexibla ändringar även om du valt att behålla original ASF-enhet, till exempel med en **[symlänk](https://wikipedia.org/wiki/Symbolic_link)**.

---

## Kör aldrig ASF som administratör!

ASF innehåller en egen validering om processen körs som administratör (`root`) eller inte. Körs som `root` är **inte** krävs för någon typ av operation som utförs av ASF-processen, förutsatt att korrekt konfigurerad miljö den fungerar i, och därför bör betraktas som en **dålig praxis**. Detta innebär att i Windows, ASF bör **aldrig** köras med "run as administrator" inställning, och på Unix ASF bör ha ett **dedikerat användarkonto** för sig själv, eller återanvända din egen i händelse av ett skrivbordssystem.

För vidare utarbetande av *varför* avråder vi från att köra ASF som `rot`, referera till **[superanvändare](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** och andra resurser. Om du fortfarande inte är övertygad, Fråga dig själv vad som skulle hända med din maskin om ASF-processen utförs `rm -rf /*` kommandot direkt efter dess lansering.

### Jag kör som `root` eftersom ASF inte kan skriva till sina filer

Detta innebär att du har felaktigt konfigurerade behörigheter för filerna ASF försöker komma åt. Du bör logga in som `root` -konto (antingen med `su` eller `sudo -i`) och sedan **rätta** behörigheterna genom att utfärda `chown -hR asf:asf /path/to/ASF` kommando, Ersätta `asf:asf` med användaren som du kör ASF under, och `/path/to/ASF` därefter. Om du av någon chans använder anpassade `--path` som talar om för ASF-användaren att använda den andra katalogen, du bör köra samma kommando igen för den sökvägen också.

Efter att ha gjort det, bör du inte längre få någon form av problem relaterade till ASF inte kunna skriva över sina egna filer, som du har precis bytt ägare av allt ASF är intresserad av att användaren ASF-processen faktiskt kommer att köras under.

### Jag kör som `rot` eftersom jag inte vet hur man gör det annars

```sh
# Eller sudo -i, för att komma in i rotskalet
useradd -m asf # Skapa konto som du tänker köra ASF under
chown -hR asf:asf /path/to/ASF # Se till att din nya användare har tillgång till ASF-katalogen
su asf -c /path/to/ASF/ArchiSteamFarm # Eller sudo -u asf /path/to/ASF/ArchiSteamFarm, att faktiskt starta programmet under din användare
```

Det skulle göra det manuellt, det är mycket lättare att använda vår **[`systemd` service](#systemd-service-for-linux)** förklaras ovan.

### Jag vet bättre och jag vill fortfarande köra som `rot`

ASF hindrar dig inte från att göra det, bara visar en varning med en kort varning. Bara inte bli chockad om en dag på grund av en bugg i programmet det kommer att spränga hela ditt operativsystem med fullständig dataförlust - du har blivit varnad.

---

## Flera instanser

ASF är kompatibel med att köra flera instanser av processen på samma maskin. instanserna kan vara helt fristående eller härledda från samma binära plats (i vilket fall), du vill köra dem med olika `--path` **[kommandoradsargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**).

När du kör flera instanser från samma binär, tänk på att du normalt bör inaktivera automatiska uppdateringar i alla sina konfigurationer, eftersom det inte finns någon synkronisering mellan dem när det gäller auto-uppdateringar. Om du vill fortsätta att ha automatiska uppdateringar aktiverade, rekommenderar vi fristående instanser, men du kan fortfarande få uppdateringar att fungera, så länge du kan se till att alla andra ASF instanser är stängda.

ASF kommer att göra sitt bästa för att upprätthålla ett minimum av OS-bred, korsprocesskommunikation med andra ASF-instanser. Detta inkluderar ASF kontrollera dess konfigurationskatalog mot andra instanser, samt dela kärna process-wide limiters konfigurerade med `*LimiterDelay` **[globala konfigurationsegenskaper](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, att se till att köra flera ASF-instanser inte kommer att orsaka en möjlighet att stöta på en hastighetsbegränsande problem. När det gäller tekniska aspekter använder alla plattformar vår dedikerade mekanism för anpassade ASF-filbaserade lås som skapats i temporär katalog, vilket är `C:\Users\<YourUser>\AppData\Local\Temp\ASF` i Windows och `/tmp/ASF` på Unix.

Det krävs inte för att köra ASF-instanser för att dela samma `*LimiterDelay` egenskaper, de kan använda olika värden, eftersom varje ASF kommer att lägga till sin egen konfigurerade fördröjning till release tid efter att förvärva låset. Om den konfigurerade `*LimiterDelay` är inställd till `0`, ASF-instansen kommer helt att hoppa över väntan på låset av given resurs som delas med andra instanser (som potentiellt fortfarande kan upprätthålla ett delat lås med varandra). När satt till något annat värde, ASF kommer att synkronisera korrekt med andra ASF instanser och vänta på sin tur, släpp sedan låset efter konfigurerad fördröjning, vilket tillåter andra instanser att fortsätta.

ASF tar hänsyn till `WebProxy` inställningen när man beslutar om delad omfattning, vilket innebär att två ASF-instanser med olika `WebProxy` -konfigurationer inte kommer att dela sina begränsare med varandra. Detta är implementerat för att tillåta `WebProxy` att fungera utan överdrivna förseningar, som förväntats från olika nätverksgränssnitt. Detta bör vara tillräckligt bra för de flesta användningsfall, men om du har en specifik anpassad inställning där du t.ex. routing begär dig själv på ett annat sätt, du kan ange nätverksgrupp själv genom `--network-group` **[kommandoradsargumentet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**, som gör att du kan deklarera ASF grupp som kommer att synkroniseras med denna instans. Tänk på att anpassade nätverksgrupper används exklusivt, vilket innebär att ASF inte längre kommer att använda `WebProxy` för att bestämma rätt grupp, som du är ansvarig för gruppering i detta fall.

Om du vill använda vår **[`-systemd` -tjänst](#systemd-service-for-linux)** förklaras ovan för flera ASF-instanser, det är mycket enkelt, bara använda en annan användare för vår `ArchiSteamFarm@` tjänst deklaration och följa med resten av stegen. Detta kommer att motsvara att köra flera ASF-instanser med distinkta binärer, så de kan också auto-uppdatera och fungera oberoende av varandra.