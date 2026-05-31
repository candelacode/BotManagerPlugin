# Beheer

Dit gedeelte heeft betrekking op onderwerpen die te maken hebben met een optimaal beheer van het ASF-proces. Hoewel niet strikt verplicht voor gebruik, omvat het een aantal tips, trucs en goede praktijken die we graag willen delen, speciaal voor systeembeheerders, verpakkingen mensen ASF voor gebruik in repositories van derden, maar ook geavanceerde gebruikers en geavanceerde gebruikers.

---

## `systemd` service voor Linux

In `generieke` en `linux` varianten komt ASF met `ArchiSteamFarm@. wispelturig` bestand, wat een configuratiebestand is van de dienst voor **[`systemd`](https://systemd.io)**. Als je ASF wilt uitvoeren als een service, bijvoorbeeld om het automatisch te starten na het opstarten van je machine, dan is een goede `systemd` service aantoonbaar de beste manier om het te doen. Daarom raden we het aan in plaats van het zelf te beheren met `nohup`, `screen` of hetzelfde.

Ten eerste, maak de account aan voor de gebruiker waarvan je ASF wilt gebruiken, ervan uitgaande dat deze nog niet bestaat. We gebruiken `asf` gebruiker voor dit voorbeeld, als je hebt besloten een andere te gebruiken. Je moet een `asf` gebruiker vervangen in al onze voorbeelden hieronder met de geselecteerde gebruiker. Onze dienst staat je niet toe ASF te draaien als `root`, omdat het beschouwd wordt als een **[slechte praktijk](#never-run-asf-as-administrator)**.

```sh
su # Of sudo -i, om naar root-shell
useradd -m asf # Creëer account dat je van plan bent te draaien onder ASF
```

Vervolgens moet ASF uitpakken naar `/home/asf/ArchiSteamFarm` map. De mappenstructuur is belangrijk voor onze service-eenheid, het moet `ArchiSteamFarm` map zijn in uw `$HOME`, dus `/home/<user>`. Als je alles correct hebt gedaan, zal er een `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service` bestand bestaan. Als je `linux` variant gebruikt en het bestand op Linux niet uitpakt, bijvoorbeeld de gebruikte bestandsoverdracht van Windows, dan moet je ook `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

We zullen alle onderstaande acties doen als `root`, dus ga naar de shell met `su` of `sudo -i`.

Ten eerste is het een goed idee om ervoor te zorgen dat onze map nog steeds toebehoort aan onze `asf` gebruiker, `chown -hR asf:asf /home/asf/ArchiSteamFarm` uitgevoerd zal het eenmaal doen. De machtigingen kunnen verkeerd zijn, bijv. als u het zip-bestand hebt gedownload en/of uitgepakt als `root`.

Ten tweede, als je generieke variant van ASF gebruikt moet je ervoor zorgen dat `dotnet` commando herkend wordt en binnen een van de standaard locaties: `/usr/local/bin`, `/usr/bin` of `/bin`. Dit is vereist voor onze systeemservice die `dotnet /path/to/ArchiSteamFarm.dll` commando uitvoert. Controleer of `dotnet --info` voor u werkt als ja, typ `commando -v dotnet` om erachter te komen waar het zich bevindt. Als u het officiële installatieprogramma heeft gebruikt, moet het in `/usr/bin/dotnet` of een van de twee andere locaties zijn. Als het in een aangepaste locatie is zoals `/usr/share/dotnet/dotnet`, maak een **[symlink](https://wikipedia.org/wiki/Symbolic_link)** met behulp van `ln -s "$(command -v dotnet)" /usr/bin/dotnet`. Nu moet `command -v dotnet` rapporteren `/usr/bin/dotnet`, wat ook onze systeemeenheid zal laten werken. Als je OS-specifieke variant gebruikt, hoef je niets in dit opzicht te doen.

Voer vervolgens `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/system/ArchiSteamFarm\@ uit. ervice`, dit zal een symbolische link maken naar onze service declaratie en deze registreren in `systemd`. Met een Symbolische link kan ASF je `systemd` eenheid automatisch bijwerken als onderdeel van ASF update - afhankelijk van je situatie. je kunt die benadering gebruiken of gewoon `cp` het bestand zelf beheren hoe je wilt.

Daarna moet je ervoor zorgen dat `systemd` onze dienst herkent.

```
systemctl status ArchiSteamFarm@asf

Ó ArchiSteamFarm@asf.service - ArchiSteamFarm Service (in asf)
     Geladen: geladen (/etc/system/system/ArchiSteamFarm@. ervice; uitgeschakeld; vendor preset: enabled)
     Actief: inactief (dood)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Let vooral op de gebruiker die we na `@`declareren, het is `asf` in ons geval. Onze systeem-service unit verwacht van u om de gebruiker te verklaren, omdat het de exacte plaats beïnvloedt van de binaire `/home/<user>/ArchiSteamFarm`, evenals het eigenlijke gebruikerssysteem zal het proces laten spawnen.

Als het systeem de uitvoer naar boven heeft teruggegeven, is alles in orde, en we zijn bijna klaar. Nu begint alles wat over is eigenlijk onze service als onze gekozen gebruiker: `systemctl start ArchiSteamFarm@asf`. Wacht even en je kunt de status opnieuw controleren:

```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (in asf)
     Geladen: geladen (/etc/systemd/ArchiSteamFarm@.service; uitgeschakeld; vendor preset: enabled)
     Actief: actief (running) sinds (...)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   Main PID: (...)
(...)
```

Als `systemd` staat `actief (actief)`, het betekent dat alles goed is gegaan en je kunt controleren of het ASF-proces op gang moet komen, bijvoorbeeld met `journactl -r`, zoals ASF standaard ook naar de console output schrijft, welke wordt opgenomen door `systemd`. Als u tevreden bent met de instellingen die u nu heeft, kunt u `systemd` vertellen om uw service automatisch te starten tijdens het opstarten, door het uitvoeren van `systemctl ArchiSteamFarm@asf` commando mogelijk te maken. Dat is alles.

Als je het proces wilt stoppen, voer dan gewoon `systemctl stop ArchiSteamFarm@asf`. Dezelfde, als je ASF bij het opstarten wilt uitschakelen, `systemctl uitschakelen ArchiSteamFarm@asf` zal dat voor jou doen, het is heel eenvoudig.

Houd er rekening mee dat, aangezien er geen standaard invoer ingeschakeld is voor onze `systemd` service, U zult niet op gebruikelijke wijze uw gegevens kunnen invoeren via de console Systeem- `` staat gelijk aan het specificeren van **[`Headless: true`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** en komt met alle implicaties ervan. Gelukkig voor jou is het heel makkelijk om je ASF te beheren via **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, die we aanbevelen voor het geval dat je aanvullende gegevens moet invullen tijdens het inloggen of je ASF-proces verder moet beheren.

### Omgeving variabelen

Het is mogelijk om extra omgevingsvariabelen te leveren aan onze `systeem-` service, wat je wil doen in het geval dat je bijvoorbeeld een eigen `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**wilt gebruiken, daarom `ASF_CRYPTKEY` omgevingsvariabele.

Om aangepaste omgevingsvariabelen te bieden, maak `/etc/asf` map (in het geval het niet bestaat) `mkdir -p /etc/asf`. We raden `chown -hR root:root /etc/asf && chmod 700 /etc/asf` aan om ervoor te zorgen dat alleen `root` gebruiker toegang heeft tot het lezen van deze bestanden, omdat ze gevoelige eigenschappen kunnen bevatten zoals `ASF_CRYPTKEY`. Daarna schrijf je naar een `/etc/asf/<user>` bestand, waar `<user>` de gebruiker is die je de service onder (`asf` in ons voorbeeld hierboven draagt, dus `/etc/asf/asf`).

Het bestand moet alle omgevingsvariabelen bevatten die u aan het proces wilt aanbieden. De landen die geen speciale omgevingsvariabele hebben, kunnen in `ASF_ARGS` worden verklaard:

```sh
# Schrijf alleen die welke u eigenlijk nodig hebt
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network _group"

# En alle andere waarin u geïnteresseerd bent
```

### Een deel van de service-eenheid overschrijven

Dankzij de flexibiliteit van `systemd`, het is mogelijk om een deel van ASF-eenheid te overschrijven, terwijl het oorspronkelijke eenheidsbestand behouden blijft en ASF bijvoorbeeld in staat stelt deze bij te werken als onderdeel van automatische updates.

In dit voorbeeld willen we het standaard ASF `systemd` gedrag aanpassen vanaf het opnieuw opstarten alleen bij succes; ook het herstarten bij fatale crashes. Om dit te doen we overschrijven `Herstart` eigenschap onder `[Service]` van standaard `on-success` naar `altijd`. Voer gewoon uit `systemctl edit ArchiSteamFarm@asf`, vervang natuurlijk `asf` door de doelgebruiker van uw service. Voeg vervolgens de wijzigingen toe zoals aangegeven door `systemd` in de juiste sectie:

```sh
### Bewerken/etc/systemd/ArchiSteamFarm@asf.service.d/override. onf
### Alles tussen hier en de opmerking hieronder wordt de nieuwe inhoud van het bestand

[Service]
Restart=always

### Lijnen onder deze reactie worden weggegooid

### /etc/systemd/system/ArchiSteamFarm@asf. ervice
# [Install]
# Gezochtby=multi-gebruiker. arget
# 
 [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm. ll --no-restart --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# User=%i
# (...)
```

En dat is het, nu doet je eenheid hetzelfde alsof het alleen `Restart=Altijd` onder `[Service]` zou hebben.

Natuurlijk is een alternatief voor `cp` het bestand en beheer het zelf maar dit laat je flexibele wijzigingen toe, zelfs als je besloten hebt de originele ASF-eenheid te behouden, bijvoorbeeld met een **[symlink](https://wikipedia.org/wiki/Symbolic_link)**.

---

## Voer ASF nooit uit als administrator!

ASF bevat zijn eigen validatie of het proces wordt uitgevoerd als beheerder (`root`) of niet. Uitvoeren als `root` is **niet** nodig voor elke vorm van operatie uitgevoerd door het ASF-proces. aannemen van een goed geconfigureerde omgeving waarin hij werkt, en moet daarom gezien worden als een **slechte praktijk**. Dit betekent dat ASF op Windows **nooit** moet worden uitgevoerd met "als administrator" instelling, en op Unix ASF moet een **toegewijde gebruikersaccount** zelf hebben. of hergebruik je eigen in het geval van een desktopsysteem.

Voor verdere uitleg over *waarom* we ASF als `root`ontmoedigen, verwijzen naar **[superuser](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** en andere bronnen. Als je nog steeds niet overtuigd bent, vraag uzelf wat er met je machine zou gebeuren als ASF-proces `rm -rf /*` commando direct na de lancering wordt uitgevoerd.

### Ik voer uit als `root` omdat ASF zijn bestanden niet kan schrijven

Dit betekent dat je de rechten van de ASF verkeerd hebt geconfigureerd voor toegang tot de bestanden. Je moet inloggen als `root` account (met `su` of `sudo -i`) en vervolgens **de rechten van** correct maken door `zelf -hR asf:asf /path/to/ASF` commando uit te geven, het vervangen van `asf:asf` door de gebruiker waarvan je ASF onder uitvoert en `/path/to/ASF` overeenkomend. Als je toevallig een aangepaste `--path` gebruikt om de ASF gebruiker te vertellen de verschillende map te gebruiken, je zou hetzelfde commando opnieuw moeten uitvoeren voor dat pad.

Hierna zul je geen problemen meer moeten krijgen met betrekking tot ASF die niet over zijn eigen bestanden kunnen schrijven, omdat je zojuist de eigenaar van alles wat ASF interesseert voor de gebruiker waar het ASF-proces eigenlijk onder zal lopen.

### Ik word uitgevoerd als `root` omdat ik niet weet hoe ik het anders moet doen

```sh
su # Of sudo -i, om in root shell
useradd -m asf # Create account uit te voeren wil je ASF onder
chown -hR asf:asf /path/to/ASF # Zorg ervoor dat je nieuwe gebruiker toegang heeft tot de ASF directory
su as-c /path/to/ASF/ArchiamFarm # Of sudo -u asf /path/to/ASF/ArchiamFarm, om het programma onder je gebruiker te starten
```

Dat zou handmatig doen, het is veel makkelijker om onze **[`systemd` Service](#systemd-service-for-linux)** te gebruiken.

### Ik weet het beter en ik wil nog steeds uitvoeren als `root`

ASF stopt dit niet geforceerd aan, geeft alleen een waarschuwing weer met een korte waarschuwing. Wees niet geschrokken als het op een dag als gevolg van een bug in het programma uw hele OS opblazen met volledig gegevensverlies - u bent gewaarschuwd.

---

## Meerdere instanties

ASF is compatibel met het uitvoeren van meerdere processen op dezelfde machine. De instanties kunnen volledig onafhankelijk zijn of afgeleid worden van dezelfde binaire locatie (in wanneer het geval je wilt ze uitvoeren met verschillende `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**).

Bij het uitvoeren van meerdere instanties van dezelfde binary, houd er rekening mee dat je meestal automatisch bijwerken in al hun configuraties moet uitschakelen, omdat er geen synchronisatie tussen hen is met betrekking tot automatische updates. Als u automatische updates wilt blijven inschakelen, raden we zelfstandige instanties, maar je kan nog steeds werken met updates, zolang je er maar voor kan zorgen dat alle andere ASF-servers gesloten zijn.

ASF zal zijn best doen om een minimale hoeveelheid OS-breed te behouden, cross-process communicatie met andere ASF-instanties. Dit geldt ook voor het controleren van de configuratiemap met andere instanties, ASF evenals het delen van de core process-wide limiters geconfigureerd met `*LimiterDelay` **[globale configuratie eigenschappen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, zorg ervoor dat het gebruik van meerdere ASF-instanties geen mogelijkheid geeft om te lopen tot een tariefbeperkende kwestie. Met betrekking tot de technische aspecten gebruiken alle platforms ons specifieke mechanisme van aangepaste ASF-bestanden vergrendelingen die zijn gemaakt in tijdelijke directory, dit is `C:\Users\<YourUser>\AppData\Local\Temp\ASF` op Windows, en `/tmp/ASF` op Unix.

Het is niet vereist voor het uitvoeren van ASF instanties om dezelfde `*LimiterDelay` eigenschappen te delen, ze kunnen verschillende waarden gebruiken, omdat elke ASF de eigen ingestelde vertraging toevoegt aan de releasetijd na het verkrijgen van de vergrendeling. Als de geconfigureerde `*LimiterDelay` is ingesteld op `0`, ASF-instance slaat volledig het wachten op de vergrendeling van een resource die wordt gedeeld met andere instanties (die mogelijk nog steeds een gedeeld slot met elkaar kunnen houden). Indien ingesteld op een andere waarde, dan zal ASF correct synchroniseren met andere ASF-instanties en wachten op de beurt vervolgens de vergrendeling vrijgeven na de geconfigureerde vertraging, waardoor andere instanties door kunnen gaan.

ASF houdt rekening met `WebProxy` instelling bij het beslissen over gedeelde scope, dit betekent dat twee ASF-instanties die verschillende `WebProxy` configuraties niet met elkaar delen. Dit wordt geïmplementeerd om instellingen van `WebProxy` toe te staan om te werken zonder buitensporige vertragingen, zoals verwacht wordt in verschillende netwerkinterfaces. Dit zou goed genoeg moeten zijn voor de meeste van de gebruiksgevallen, echter als u een specifieke aangepaste setup heeft waarin u bijv. bent zelf-routeren van verzoeken op een andere manier, u kunt de netwerkgroep zelf specificeren via `--netwerkgroep` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**, waarmee je ASF-groep kunt declareren die wordt gesynchroniseerd met deze instantie. Houd er rekening mee dat aangepaste netwerkgroepen exclusief worden gebruikt dit betekent dat ASF niet langer `WebProxy` gebruikt om de juiste groep te bepalen. omdat je de leiding hebt over het groeperen in dit geval.

Als je gebruik wilt maken van onze **[`systemd` service](#systemd-service-for-linux)** uitgelegd hierboven voor meerdere ASF-instanties. Het is heel eenvoudig, gebruik gewoon een andere gebruiker voor onze `ArchiSteamFarm@` service declaratie en volg de rest van de stappen. Dit is gelijk aan het draaien van meerdere ASF-instanties met verschillende binairs, zodat ze ook automatisch kunnen updaten en onafhankelijk van elkaar kunnen werken.