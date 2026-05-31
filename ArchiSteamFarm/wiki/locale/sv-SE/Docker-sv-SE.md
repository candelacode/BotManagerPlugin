# Docker

ASF finns som **[dockningsbehållare](https://www.docker.com/what-container)**. Våra paket finns för närvarande tillgängliga på **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** och **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

Det är viktigt att notera att köra ASF i Docker behållare anses **avancerad installation**, vilket är **inte behövs** för de allra flesta användare, och ger vanligtvis **inga fördelar** jämfört med container-less setup. Om du funderar på att Docker som en lösning för att köra ASF som en tjänst, till exempel göra det börjar automatiskt med ditt OS, då bör du överväga att läsa **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** sektionen istället och ställa in en ordentlig `systemd` tjänst som kommer att vara **nästan alltid** en bättre idé än att köra ASF i en Docker behållare.

Att köra ASF i Docker behållare innebär vanligtvis **flera nya problem och problem** som du måste möta och lösa själv. Det är därför vi **starkt** rekommenderar dig att undvika det om du inte redan har Docker kunskap och inte behöver hjälpa till att förstå dess inre, om vilka vi inte kommer att utveckla här på ASF wiki. Detta avsnitt är främst för giltig användning fall av mycket komplexa inställningar, till exempel när det gäller avancerade nätverk eller säkerhet utöver standard sandboxning som ASF kommer med i tjänsten `systemd` (som redan säkerställer överlägsen processisolering genom mycket avancerad säkerhetsmekanik). För dessa handfull människor förklarar vi här bättre ASF koncept när det gäller dess Docker kompatibilitet, och bara det, du antas ha tillräcklig Docker kunskap själv om du bestämmer dig för att använda det tillsammans med ASF.

---

## Taggar

ASF är tillgänglig genom flera typer av **[taggar](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `huvud`

Generisk byggnation av ASF som är byggd från den allra senaste åtagandet i `main` branch, som fungerar på samma sätt som att ta tag i senaste artefakt direkt från vår **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pipeline. Det är den högsta nivån av buggad programvara tillägnad utvecklare och avancerade användare för utvecklingsändamål. Bilden uppdateras med varje commit i `main` GitHub branch, därför kan du förvänta dig mycket ofta förändringar (och saker som bryts). Det är här för att markera nuvarande tillstånd för ASF-projektet, som inte nödvändigtvis är garanterad att vara stabil eller testad, precis som påpekas i vår release cykel. **Denna tagg bör inte användas i någon produktionsmiljö**. Användbart för verifiering om särskilda begå rättat problem du stöter på, utan att vänta ens på en förhandsutgåva med detta åtagande.


### `släppt`

Generisk version av ASF som alltid pekar på den senaste **[släppt](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF-versionen, inklusive förhandsutgåvor. Jämfört med `huvudtaggen` uppdateras bilden här varje gång en ny GitHub-tagg trycks. Dedikerad till avancerade / power-användare som älskar att leva på kanten av vad som kan anses vara stabil och fräsch på samma gång. I praktiken fungerar det samma som rullande tagg som pekar på den senaste `A.B.C.D` releasen vid tidpunkten för dragning. Observera att det är lika med att använda vår **[förutgåvor](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `stabil`

Generisk version av ASF som alltid pekar på den senaste **[stabila](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF-versionen. Jämfört med `släppt` tagg uppdateras bilden här när ny stabil version av ASF är tillgänglig. Rekommenderas för personer som letar efter en stabil variant av `släppt` -tagg som nämns ovan.

### `senaste`

OS-specifik version av ASF som alltid pekar på den senaste **[stabila](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF-versionen. I jämförelse med andra, detta är **bara taggen** som innehåller ASF auto-uppdateringar. Syftet med denna tagg är att ge en sane standard Docker behållare som kan köra självuppdatering, OS-specifik bygga av ASF. På grund av det behöver bilden inte uppdateras så ofta som möjligt, som ingår ASF-version kommer alltid att kunna uppdatera sig själv om det behövs.

Självklart kan `Uppdateringsperiod` stängas av på ett säkert sätt (sätt till `0`), men i detta fall bör du antagligen använda `stabila` utgåva istället. På samma sätt kan du ändra standard `UpdateChannel` för att spåra förhandsutgåvor istället om du vill.

På grund av det faktum att `senaste` bilden kommer med möjlighet till auto-uppdateringar, den innehåller naken OS med OS-specifik `linux` ASF-version, i motsats till alla andra taggar som inkluderar OS med . ET runtime och `generisk` ASF-version. Detta beror på att nyare (uppdaterad) ASF-version också kan kräva nyare körtid än den som bilden möjligen kunde byggas med, som annars skulle kräva bild att byggas om från grunden, nullifying den planerade användningsfall.

### `A.B.C.D`

Generisk version av ASF som pekar på den fasta ASF-versionen som matchar taggen. I jämförelse med ovanstående taggar är denna tagg helt frusen, vilket innebär att bilden här inte kommer att uppdateras en gång publicerat. Detta fungerar liknande till våra GitHub releaser som aldrig berörs efter den första utgåvan, vilket garanterar dig stabil och frusen miljö. Vanligtvis bör du använda denna tagg när du vill använda någon specifik ASF-utgåva och förvänta dig deterministiska resultat av bygget (e. . hantera ASF versioner själv istället).

---

## Vilken tagg är bäst för mig?

Det beror på vad du letar efter. För de flesta användare bör `senaste` taggen vara den bästa eftersom den erbjuder exakt vad skrivbordet ASF gör, bara i speciella Docker behållare som en tjänst. Detta är dock inte nödvändigtvis hur hamnarbetare ska användas - normalt förväntas du bygga om dina containrar och inte köra dem för alltid, och i detta fall bör du överväga `stable` eller `släppt` -tagg, som följer riktlinjer för dockning. Slutligen, om du vill köra några fasta ASF version istället, då naturligtvis `A.B.C.D` releaser är vad du letar efter.

Vi avråder generellt från att försöka `main` bygger, eftersom de är här för oss att markera nuvarande tillstånd för ASF-projekt. Ingenting garanterar att en sådan stat kommer att fungera korrekt, men naturligtvis är du mer än välkommen att prova dem om du är intresserad av ASF-utveckling.

---

## Arkitekturer

ASF-dockeravbildningen är för närvarande byggd på `linux` plattform med inriktning på 3 arkitekturer - `x64`, `arm` och `arm64`. Du kan läsa mer om dem i **[kompatibilitet](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** sektionen.

Våra taggar använder multi-platform manifest, vilket innebär att Docker installeras på din maskin kommer automatiskt att välja rätt bild för din plattform när du drar bilden. Om du av någon chans vill dra en specifik plattformsbild som inte matchar den du just nu kör, du kan göra det via `--platform` växla i lämpliga dockerkommandon, såsom `docker kör`. Se dokumentationen på **[bildmanifest](https://docs.docker.com/registry/spec/manifest-v2-2)** för mer information.

---

## Användning

För fullständig referens bör du använda **[officiell dockningsdokumentation](https://docs.docker.com/engine/reference/commandline/docker)**, Vi täcker endast grundläggande användning i den här guiden, du är mer än välkommen att gräva djupare.

### Hello ASF!

För det första bör vi kontrollera om vår hamnarbetare fungerar även korrekt, detta kommer att fungera som vår ASF "hej världen":

```shell
dockare kör -it --namn asf --pull alltid --rm justarchi/archisteamfarm
```

`docker run` skapar en ny ASF docker container åt dig och kör den i förgrunden (`-it`). `--pull alltid` ser till att aktuell bild dras först, och `--rm` ser till att vår behållare kommer att rensas en gång stoppas, eftersom vi bara testar om allt fungerar bra för nu.

Om allt slutade framgångsrikt, efter att dra alla lager och starta behållaren, Du bör märka att ASF startat och informerat oss om att det inte finns några definierade botar, vilket är bra - vi verifierade att ASF i hamnarbetare fungerar korrekt. Hit `CTRL+C` för att avsluta ASF-processen och därmed även behållaren.

Om du tittar närmare på kommandot kommer du att märka att vi inte deklarerade någon tagg, som automatiskt standard för `senaste` en. Om du vill använda andra taggar än `senaste`, till exempel `släppt`, då bör du deklarera det uttryckligt:

```shell
dockare kör -it --namn asf --pull alltid --rm justarchi/archisteamfarm:släppt
```

---

## Använda en volym

Om du använder ASF i docker container då naturligtvis måste du konfigurera programmet själv. Du kan göra det på olika sätt, men den rekommenderade skulle vara att skapa ASF `config` katalog på lokal maskin, sedan montera den som en delad volym i ASF dockerbehållare.

Till exempel antar vi att din ASF-konfigurationsmapp finns i `/home/archi/ASF/config` -katalogen. Denna katalog innehåller kärnan `ASF.json` samt robotar som vi vill köra. Nu behöver vi bara ansluta denna katalog som delad volym i vår dockerbehållare, där ASF förväntar sig sin konfigurationskatalog (`/app/config`).

```shell
docker kör -it -v /home/archi/ASF/config:/app/config --name asf --pull alltid justarchi/archisteamfarm
```

Och det är det, nu din ASF docker container kommer att använda delad katalog med din lokala maskin i läs-skriv-läge, vilket är allt du behöver för att konfigurera ASF. På liknande sätt kan du montera andra volymer som du vill dela med ASF, till exempel `/app/logs` eller `/app/plugins`.

Naturligtvis är detta bara ett specifikt sätt att uppnå vad vi vill, ingenting hindrar dig från t.ex. skapa din egen `Dockerfile` som kopierar dina konfigurationsfiler till `/app/config` -katalogen i ASF docker container. Vi täcker bara grundläggande användning i den här guiden.

### Volymrättigheter

ASF behållare som standard initieras med standard `root` användare, vilket gör det möjligt att hantera interna behörigheter grejer och sedan så småningom byta till `asf` (UID `1000`) användare för den återstående delen av huvudprocessen. Även om detta bör vara tillfredsställande för den stora majoriteten av användare, det påverkar den delade volymen eftersom nyskapade filer normalt kommer att ägas av `asf` användare, vilket kanske inte önskas om du vill ha någon annan användare för din delade volym.

Det finns två sätt du kan ändra användaren ASF körs under. Den första, rekommenderas, är att deklarera miljövariabeln `ASF_UID` med målet UID som du vill köra under. För det andra, alternativ ett, är att passera `--user` **[flaggan](https://docs.docker.com/engine/reference/run/#user)**, som stöds direkt av hamnaren.

Du kan kontrollera ditt `uid` till exempel med `id -u` kommandot och sedan deklarera det enligt ovan. Till exempel, om din målanvändare har `uid` av 1001:

```shell
docker run -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm

# Alternativt, om du förstår begränsningarna under
docker run -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Skillnaden mellan `ASF_UID` och `--user` flaggan är subtil, men viktig. `ASF_UID` är anpassad mekanism som stöds av ASF, i detta scenario dockare behållare fortfarande startar som `root`, och sedan ASF startskript startar huvudbinär under `ASF_UID`. När du använder flaggan `--user` startar du hela processen, inklusive ASF startskript som given användare. Första alternativet gör att ASF startskript för att hantera behörigheter och andra saker automatiskt för dig, lösa några vanliga problem som du kanske har orsakat, till exempel ser den till att dina `/app` och `/asf` kataloger faktiskt ägs av `ASF_UID`. I andra scenariot, eftersom vi inte kör som `root`, vi kan inte göra det, och du förväntas hantera allt detta själv i förväg.

Om du har bestämt dig för att använda `--user` flagga, du måste byta ägande av alla ASF-filer från standard `1000` till din nya anpassade användare. Du kan göra det genom att utföra kommandot nedan:

```shell
# Kör endast om du inte använder ASF_UID
docker exec -u root asf_container_name chown -hR 1001 /app /asf
```

Detta måste göras först en gång efter att du skapat din behållare med `docker kör`, och endast om du bestämde dig för att använda anpassad användare via `--user` dockningsflaggan. Glöm inte heller att ändra argumentet `1001` i kommandot ovan till `UID` som du faktiskt vill köra ASF under.

### Volym med SELinux

Om du använder SELinux i påtvingat tillstånd på ditt operativsystem, vilket är standard för exempelvis RHEL-baserade störningar, sedan bör du montera volymen som lägger till `:Z` alternativ, som kommer att ställa in rätt SELinux sammanhang för det.

```
docker kör -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull always justarchi/archisteamfarm
```

Detta kommer att tillåta ASF att skapa filer som riktar volymen medan inuti dockerbehållaren.

---

## Flera instanser synkronisering

ASF inkluderar stöd för flera instanser synkronisering, som anges i **[hantering](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** avsnitt. När du kör ASF i dockningsbehållaren kan du välja "opt-in" i processen, Om du kör flera behållare med ASF och du vill att de ska synkronisera med varandra.

Som standard är varje ASF som körs inuti en dockerbehållare fristående, vilket innebär att ingen synkronisering sker. För att aktivera synkronisering mellan dem måste du binda `/tmp/ASF` sökväg i varje ASF-behållare som du vill synkronisera, till en, delad sökväg på din dockervärd, i läsläge. Detta uppnås exakt samma som att binda en volym som beskrevs ovan, bara med olika vägar:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull always justarchi/archisteamfarm
# Och så vidare, alla ASF-behållare är nu synkroniserade med varandra
```

Vi rekommenderar att binda ASF:s `/tmp/ASF` -katalog även till en temporär `/tmp` -katalog på din maskin, men naturligtvis är du fri att välja någon annan som uppfyller din användning. Varje ASF-behållare som förväntas synkroniseras bör ha sin `/tmp/ASF` -katalog delad med andra behållare som deltar i samma synkroniseringsprocess.

Som du förmodligen gissade från exempel ovan, är det också möjligt att skapa två eller flera "synkroniseringsgrupper", genom att binda olika bryggvägar till ASFs `/tmp/ASF`.

Montering `/tmp/ASF` är helt valfritt och rekommenderas faktiskt inte, om du inte uttryckligen vill synkronisera två eller fler ASF-behållare. Vi rekommenderar inte att montera `/tmp/ASF` för användning med en behållare, eftersom det ger absolut inga fördelar om du förväntar dig att köra bara en ASF-behållare, och det kan faktiskt orsaka problem som annars skulle kunna undvikas.

---

## Kommandoradsargument

ASF låter dig passera **[kommandoradsargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** i dockerbehållare genom miljövariabler. Du bör använda specifika miljövariabler för stödda switchar och `ASF_ARGS` för resten. Detta kan uppnås med `-e` switch tillagd till `docker kör`, till exempel:

```shell
köra -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrera" --namn asf --pull alltid justarchi/archisteamfarm
```

Detta kommer korrekt att skicka argumentet `--cryptkey` till ASF-processen som körs inuti dockerbehållaren, liksom andra args. Självklart, om du är avancerad användare, då kan du också ändra `ENTRYPOINT` eller lägga till `CMD` och skicka dina anpassade argument själv.

Om du inte vill tillhandahålla anpassad krypteringsnyckel eller andra avancerade alternativ, behöver du vanligtvis inte inkludera några speciella miljövariabler, eftersom våra hamncontainrar redan är konfigurerade att köras med ett förnuftigt förväntat standardalternativ för `--no-restart`, så att flaggan inte behöver anges uttryckligen i `ASF_ARGS`.

---

## IPC

Förutsatt att du inte ändrade standardvärdet för `IPC` **[globala konfigurationsegenskapen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, det är redan aktiverat. Men du måste göra två ytterligare saker för IPC att arbeta i Docker behållare. För det första måste du använda `IPCPassword` eller ändra standard `KnownNetworks` i anpassad `IPC. onfig` så att du kan ansluta från utsidan utan att använda en. Om du inte riktigt vet vad du gör, använd bara `IPCPassword`. För det andra måste du ändra standard lyssningsadressen för `localhost`, eftersom hamnare inte kan dirigera utanför trafiken till loopback gränssnitt. Ett exempel på en inställning som lyssnar på alla gränssnitt skulle vara `http://*:1242`. Naturligtvis kan du också använda mer restriktiva bindningar, såsom lokalt LAN eller VPN-nätverk bara, men det måste vara en väg som är tillgänglig från utsidan - `localhost` kommer inte att göra, som rutten är helt inom gästmaskinen.

För att göra det ovan bör du använda **[anpassade IPC-konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** såsom den nedan:

```json
{
    "Kestrel": {
        "Endpoint": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

När vi har satt upp IPC på icke-loopback gränssnitt, vi måste berätta för hamnare att kartlägga ASFs `1242/tcp` port antingen med `-P` eller `-p` switch.

Till exempel skulle detta kommando utsätta ASF IPC-gränssnitt för värd maskin (endast):

```shell
dockare kör -it -p 127.0.1:1242:1242 -p [::1]:1242:1242 --namn asf --pull always justarchi/archisteamfarm
```

Om du ställer in allt ordentligt, `docker kör` -kommandot ovan gör att **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** -gränssnittet fungerar från din värdmaskin, på standard `localhost:1242` rutt som nu korrekt omdirigeras till din gästmaskin. Det är också trevligt att notera att vi inte exponerar denna rutt ytterligare, så anslutning kan endast göras inom hamnvärden, och därför hålla den säker. Naturligtvis kan du exponera vägen vidare om du vet vad du gör och säkerställa lämpliga säkerhetsåtgärder.

---

### Slutför exempel

Att kombinera hela kunskapen ovan, ett exempel på en komplett konfiguration skulle se ut så här:

```shell
kör -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull always --restart unless-stopped justarchi/archisteamfarm
```

Detta förutsätter att du använder en enda ASF-behållare, med alla ASF-konfigurationsfiler i `/home/archi/ASF/config`. Du bör ändra konfigurationssökvägen till den som matchar din maskin. Det är också möjligt att tillhandahålla anpassade plugins för ASF, som du kan lägga i `/home/archi/ASF/plugins`. Den här installationen är också redo för valfri IPC-användning om du har bestämt dig för att inkludera `IPC. onfig` i din konfigurationskatalog med ett innehåll som nedan:

```json
{
    "Kestrel": {
        "Endpoint": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Du kan uppnå samma effekt av `docker kör` kommandot ovan genom att använda följande `docker komponera` konfiguration:

```yaml
version: "3. "
tjänster:
  asf:
    image: justarchi/archisteamfarm
    container_name: asf
    omstart: onekligen stoppade
    portar:
      - "127. .0.1:1242:1242"
      - "[::1]:1242:1242"
    volymer:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

Från andra saker än vi redan diskuterat ovan, Vi har lagt till `--restart unless-stopped` till båda exemplen ovan för att starta denna behållare automatiskt efter omstart av din maskin. Ta gärna bort/ändra den för att passa dina behov.

---

## Pro tips

När du redan har din ASF docker container redo, behöver du inte använda `docker kör` varje gång. Du kan enkelt stoppa/starta ASF dockerbehållare med `dockerstopp asf` och `dockerstart asf`. Tänk på att om du inte använder `senaste` -taggen så kommer du fortfarande att behöva använda aktuell ASF från dig till `docker stop`, `hamnarbetare rm` och `hamnarbetare kör` igen. Detta beror på att du måste bygga om din behållare från färsk ASF docker bild varje gång du vill använda ASF version som ingår i den bilden. I `senaste` -taggen har ASF inkluderat möjlighet att uppdatera sig själv automatiskt. så att bygga om bilden är inte nödvändigt för att använda up-to-date ASF (men det är fortfarande en bra idé att göra det då och då för att använda färska . ET-körtidsberoenden och det underliggande operativsystemet, som kan behövas när man hoppar över större ASF-versionsuppdateringar).

Som antyds av ovan, ASF i taggen annan än `senaste` kommer inte automatiskt uppdatera sig själv, vilket innebär att **du** är ansvarig för att använda uppdaterad `justarchi/archisteamfarm` repo. Detta har många fördelar eftersom appen vanligtvis inte ska röra sin egen kod när den körs, men vi förstår också bekvämlighet som kommer från att inte behöva oroa ASF version i din docker container. Om du bryr dig om god praxis och god hamnanvändning, `släppte` -taggen är vad vi skulle föreslå istället för `senaste`, men om du inte kan besväras av det och du bara vill göra ASF både arbete och automatisk uppdatering själv, sedan `senaste` kommer att göra.

Du bör vanligtvis köra ASF i dockningsbehållare med `Headless: true` global inställning. Detta kommer tydligt att berätta ASF att du inte är här för att ge saknade detaljer och det bör inte be om dem. Självklart, för första installationen bör du överväga att lämna det alternativet på `false` så att du enkelt kan ställa in saker, men på lång sikt är du vanligtvis inte ansluten till ASF-konsolen, Därför är det vettigt att informera ASF om det och använda `inmatning` **[kommandot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** vid behov. Detta sätt ASF kommer inte behöva vänta oändligt på användarens indata som inte kommer att hända (och slösa resurser när du gör det). Det kommer också att tillåta ASF att köra i icke-interaktivt läge inuti behållaren, vilket är avgörande t.ex. vad gäller vidarebefordran signaler, vilket gör det möjligt för ASF att graciöst stänga på `docker stop asf` begäran.