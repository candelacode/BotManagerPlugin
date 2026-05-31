# IPC

ASF obsahuje své vlastní unikátní IPC rozhraní, které lze použít pro další interakci s tímto procesem. IPC značí **[interprocesní komunikaci](https://en.wikipedia.org/wiki/Inter-process_communication)** a v nejjednodušší definici se jedná o "webové rozhraní ASF" založené na **[Kestrel HTTP serveru](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel)** , které lze použít pro další integraci do procesu, jak jako webová stránka pro koncového uživatele (ASF-ui), tak backend pro integraci třetích stran (ASF API).

IPC lze použít pro mnoho různých věcí v závislosti na vašich potřebách a dovednostech. Například ji můžete použít pro načítání stavu ASF a všech botů, odesílání příkazů ASF, načítání a editaci globálních/bot konfigurací, přidáním nových botů, smazáním stávajících botů, odesláním klíčů pro **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** nebo přístupem k logu ASF. Všechny tyto akce jsou vystaveny naší API, což znamená, že můžete programovat vlastní nástroje a skripty, které budou moci komunikovat s ASF a ovlivňovat je během běhu času. Kromě toho Vybrané akce (například odesílání příkazů) jsou také implementovány naším ASF-ui, který vám umožňuje snadný přístup k nim prostřednictvím přátelského webového rozhraní.

---

# Použití

Pokud jste ručně nevypnuli IPC prostřednictvím `IPC` **[vlastnosti globální konfigurace](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, je ve výchozím nastavení povoleno. ASF ve svém protokolu uvede spuštění IPC, které můžete použít pro ověření, zda IPC rozhraní správně začalo:

```text
INFO|ASF|Start() Zapínám IPC server...
INFO|ASF|Start() IPC server je připraven!
```

Server ASF http nyní poslouchá vybrané koncové body. Pokud jste neposkytli vlastní konfigurační soubor pro IPC, bude to `localhost`, oba IPv4 **[127. .0.1](http://127.0.0.1:1242)** a IPv6 **[[::1]](http://[::1]:1242)** na výchozím portu `1242`. K našemu IPC rozhraní můžete přistupovat přes výše uvedené odkazy, ale pouze ze stejného zařízení jako k procesu ASF.

IPC rozhraní ASF odhaluje tři různé způsoby přístupu v závislosti na plánovaném použití.

Na nejnižší úrovni je **[ASF API](#asf-api)** , které je jádrem našeho IPC rozhraní a umožňuje vše ostatní. To je to, co chcete použít ve svých vlastních nástrojích, nástrojích a projektech pro přímou komunikaci s ASF.

Na středním místě je naše dokumentace **[Swagger](#swagger-documentation)** , která funguje jako frontend k ASF API. Obsahuje kompletní dokumentaci ASF API a také vám umožňuje snadnější přístup. To je to, co chcete zkontrolovat, zda plánujete psát nástroj, prospěšnosti nebo jiné projekty, které mají komunikovat s ASF prostřednictvím svého rozhraní API.

Na nejvyšší úrovni je **[ASF-ui](#asf-ui)** , která je založena na našem ASF API a poskytuje uživatelsky přívětivý způsob, jak provést různé akce ASF. Toto je naše výchozí IPC rozhraní navržené pro koncové uživatele a perfektní příklad toho, co můžete vytvořit pomocí ASF API. Pokud chcete, můžete použít své vlastní uživatelské rozhraní s aplikací ASF, zadáním `--path` **[argumentu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** a použitím vlastního adresáře `www`.

---

# ASF-ui

ASF-ui je komunitní projekt, jehož cílem je vytvořit uživatelsky přívětivé grafické webové rozhraní pro koncové uživatele. Aby toho bylo dosaženo, jedná jako frontend k našemu **[ASF API](#asf-api)**umožňuje vám snadno provádět různé akce. Toto je výchozí uživatelské rozhraní, se kterým ASF přichází.

Jak bylo uvedeno výše, ASF-ui je komunitní projekt, který není spravován jádrem ASF vývojářů. Sleduje svůj vlastní tok v **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** , který by měl být použit pro všechny související otázky, problémy, hlášení o chybách a návrhy.

Můžete použít ASF-ui pro obecné řízení procesu ASF. Umožňuje například spravovat boty, upravovat nastavení, odesílat příkazy a dosahovat vybraných dalších funkcí, které jsou normálně dostupné prostřednictvím ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

Naše ASF API je typická **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** webová API, která je založena na JSON jako jeho hlavním datovém formátu. Děláme vše, co je v našich silách, abychom přesně popsali odpověď, a to pomocí obou stavových kódů HTTP (v případě potřeby), stejně jako odpověď, kterou můžete analyzovat, abyste věděli, zda žádost uspěla, a pokud ne, proč tomu tak není.

K našemu ASF API lze přistupovat zasláním příslušných požadavků na příslušné koncovky `/Api`. Můžete použít tyto API koncové body k vytvoření vlastních pomocných skriptů, nástrojů, GUI i podobně. To je přesně to, čeho naše ASF-ui dosahuje pod rouškou a každý jiný nástroj toho může dosáhnout stejně. ASF API je oficiálně podporováno a udržováno jádrem ASF.

pro úplnou dokumentaci dostupných koncových bodů, popisů, požadavků, odpovědí, statusů http a všeho ostatního, co bere v úvahu ASF API, prosím podívejte se na naši dokumentaci **[swagger](#swagger-documentation)**.

![ASF API](https://github.com/user-attachments/assets/08c3d4ad-ea77-403d-a18a-b75c3d0a3097)


---

# Vlastní konfigurace

Naše IPC rozhraní podporuje extra config soubor, `IPC.config` , který by měl být vložen do adresáře `config`.

Pokud je tento soubor k dispozici, specifikuje pokročilé nastavení ASF serveru Kestrel http spolu s dalšími laděními souvisejícími s IPC. Pokud nemáte konkrétní potřebu, není důvod k použití tohoto souboru, protože v tomto případě již ASF používá rozumné výchozí.

Konfigurační soubor je založen na následující struktuře JSON:

```json
{
    "Kestrel": {
        "Endpoints": {
            "example-http4": {
                "Url": "http://127. .0. :1242"
            },
            "example-http6": {
                "Url": "http://[:::1]:1242"
            },
            "example-https4": {
                "Url": "https://127. .0.1:1242“
                "Certifikát": {
                    "Cesta": "/cesta/to/certifikát". fx",
                    "Heslo": "passwordToPfxFileAbove"
                }
            },
            "example-https6": {
                "Url": "https://[:::1]:1242",
                "Certifikát": {
                    "Cesta": "/cesta/to/certifikát". fx",
                    "Heslo": "passwordToPfxFileAbove"
                }
            }
        },
        "KnownNetworks": [
            "10. .0.0/8",
            "172.16.0. /12",
            „192.168.0. /16"
        ],
        "Cestová základna": "/"
    }
}
```

`koncové body` - Toto je sbírka koncových bodů, každý koncový bod s vlastním jedinečným názvem (jako `example-http4`) a `Url` , který specifikuje `Protocol://Host:Port` naslouchací adresu. Ve výchozím nastavení ASF naslouchá na IPv4 a IPv6 http adresách, ale v případě potřeby jsme přidali https příklady. Měli byste deklarovat pouze ty koncové body, které potřebujete, jsme přidali 4 příklady výše, abyste je mohli snadněji upravovat.

`Hostitel` přijímá buď `localhost`, pevnou IP adresu rozhraní, které by měl poslouchat (IPv4/IPv6), nebo `*` hodnota, která spojuje http server ASF se všemi dostupnými rozhraními. Použití jiných hodnot jako `mydomain.com` nebo `192.168.0.` jedná stejně jako `*`, není zavedeno filtrování IP proto buďte velmi opatrní, když používáte hodnoty `Hostitel` , které umožňují vzdálený přístup. To umožní přístup k IPC rozhraní ASF z jiných strojů, což může představovat bezpečnostní riziko. Důrazně doporučujeme použít `IPCPassword` (a pokud možno váš vlastní firewall tako) **minimálně** v tomto případě.

`KnownNetworks` - Tato **volitelná** proměnná specifikuje síťové adresy, které považujeme za důvěryhodné. Ve výchozím nastavení je ASF nakonfigurován tak, aby důvěřoval rozhraní se smyčkou (`localhost`, stejný stroj) **pouze**. Tato vlastnost je používána dvěma způsoby. Za prvé, pokud vynecháte `IPCPassword`, pak umožníme přístup pouze strojům ze známých sítí k API ASF a odepřeme všem ostatním jako bezpečnostní opatření. Za druhé, tato vlastnost má zásadní význam, pokud jde o obrácený přístup k ASF, protože ASF bude ctít hlavičky pouze v případě, že je reverzní proxy server ve známých sítích. Uctívání záhlaví má zásadní význam pro mechanismus ASF proti otřesům, jako je zákaz opačného názoru v případě problému, bude zabanovat IP zadanou obrácenou proxy jako zdroj původní zprávy. Buďte velmi opatrní v sítích, které zde specifikujete. umožňuje potenciální útok na IP spoofing a neoprávněný přístup v případě, že důvěryhodný stroj je ohrožen nebo špatně nakonfigurován.

`Cesta` - Toto je **volitelná** základní cesta, která bude použita v IPC rozhraní. Výchozí nastavení `/` a nemělo by být vyžadováno pro úpravu většiny případů použití. Změnou této vlastnosti budete hostovat celé IPC rozhraní pouze na vlastní prefix, například `http://localhost:1242/MyPrefix` namísto `http://localhost:1242`. Použití vlastní `Cesta` může být požadováno v kombinaci se specifickým nastavením reverzního proxy tam, kde chcete použít pouze specifickou URL adresu, například `mydomain. om/ASF` namísto celé `mydomain.com` domény. Obvykle by od vás vyžadovalo přepsat pravidlo pro váš webový server, které by mapovalo `mydomain. om/ASF/Api/X` -> `localhost:1242/Api/X`, ale místo toho můžete definovat vlastní `základnu` `/ASF` a dosáhnout snazšího nastavení `mydomainu. om/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

Pokud opravdu nepotřebujete zadat vlastní cestu k základu, je nejlepší ponechat ji ve výchozím nastavení.

## Příklad konfigurací

### Změna výchozího portu

Následující konfigurace jednoduše změní výchozí ASF poslouchající port z `1242` na `1337`. Můžete si vybrat jakýkoli port, který se vám líbí, ale doporučujeme `1024-32767` , protože ostatní přístavy jsou obvykle **[registrované](https://en.wikipedia.org/wiki/Registered_port)**, a může například vyžadovat přístup `root` na Linuxu.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP4": {
                "Url": "http://127. .0. :1337"
            },
            "HTTP6": {
                "Url": "http://[:::1]:1337"
            }
        }
    }
}
```

---

### Povolení přístupu ze všech IP

Následující konfigurace umožní vzdálený přístup ze všech zdrojů, Proto byste se měli **ujistit, že jste si přečetli a pochopili naše bezpečnostní oznámení o tom**, které je k dispozici výše.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Pokud nepotřebujete přístup ze všech zdrojů, například z LAN, pak je mnohem lepší zkontrolovat místní IP adresu stroje ASF, například `192. 68.0.10` a použijte místo `*` v příkladu v konfiguraci výše. Bohužel je to jen možné, pokud vaše LAN adresa je vždy stejná, jako jinak budete mít pravděpodobně více vyhovujících výsledků s `*` a vaším vlastním firewallem nahoře, který umožňuje přístup pouze místním podsítím k portu ASF.

---

# Ověření

ASF IPC rozhraní ve výchozím nastavení nevyžaduje žádný druh ověřování, protože `IPCPassword` je nastaveno na `null`. Pokud je však `IPCPassword` povoleno tím, že je nastaveno na libovolnou neprázdnou hodnotu, každý hovor do ASF API vyžaduje heslo, které odpovídá `IPCPassword`. Pokud vynecháte autentizaci nebo zadáte nesprávné heslo, dostanete chybu `401 - Neautorizovaný`. Po 5 neúspěšných pokusech o ověření (špatné heslo), budete dočasně zablokováni s chybou `403 - Přístup odmítnut`.

Ověření lze provést dvěma samostatnými způsoby.

## `ověření` hlavička

Obecně byste měli použít **[HTTP hlavičky požadavku](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)**, nastavením `Authentication` pole s vaším heslem jako hodnotu. Způsob provádění závisí na aktuálním nástroji, který používáte pro přístup k IPC rozhraní ASF, například pokud používáte `curl` , pak byste měli přidat `-H 'Authentication: MyPassword'` jako parametr. Tímto způsobem se ověření provádí v záhlaví žádosti, kde by se mělo skutečně uskutečnit.

## `heslo` parametr v řetězci dotazu

Alternativně můžete připojit parametr `heslo` na konec URL adresy, na kterou se chystáte volat, například voláním `/Api/ASF? assword=MyPassword` místo `/Api/ASF` samotné. Tento přístup je dostatečně dobrý, ale zjevně odhaluje heslo otevřeně, což nemusí být vždy vhodné. Kromě toho je to další argument v řetězci dotazu, která komplikuje vzhled adresy URL a vyvolává pocit, že se jedná o adresu URL, zatímco heslo se vztahuje na celou ASF API komunikaci.

---

Oba způsoby jsou podporovány a je zcela na vás, kdo si přejete vybrat. Doporučujeme používat HTTP hlavičky všude tam, kde je to možné, jako uživatelsky orientované je vhodnější než dotaz řetězce. Podporujeme však také řetězec dotazů, zejména kvůli různým omezením souvisejícím s žádostí o záhlaví. Dobrým příkladem je nedostatek vlastních záhlaví při iniciování připojení k javascriptu websocketu (i když je zcela platný podle RFC). V této situaci je dotazovací řetězec jediným způsobem, jak se autentizovat.

---

# Dokumentace Swaggeru

Naše IPC rozhraní kromě ASF API a ASF-ui také obsahuje dokumentaci swagger, která je k dispozici pod `/swagger` **[URL](http://localhost:1242/swagger)**. Dokumentace Swagger slouží jako prostředník mezi implementací API a jinými nástroji, které ji používají (např. ASF-ui). Poskytuje kompletní dokumentaci a dostupnost všech bodů API ve specifikaci **[OpenAPI](https://swagger.io/resources/open-api)** , které lze snadno spotřebovávat jinými projekty, umožňuje snadno psát a testovat ASF API.

Kromě použití naší dokumentace swagger jako úplné specifikace ASF API, můžete ji také použít jako uživatelsky přívětivý způsob provádění různých API koncových bodů, zejména těch, které ASF-ui neprovádí. Protože je naše dokumentace swagger generována automaticky z ASF kódu, máte záruku, že dokumentace bude vždy aktuální s koncovými body API, které vaše verze ASF obsahuje.

![Dokumentace Swaggeru](https://github.com/user-attachments/assets/ce998e08-f5db-46b0-a9e8-e6b69abd94bb)


---

# Často kladené otázky

### Je IPC rozhraní ASF bezpečné?

ASF ve výchozím nastavení naslouchá pouze na adresách `localhost` , což znamená, že přístup k ASF IPC z jakéhokoliv jiného počítače, ale z vaší vlastní **je nemožné**. Pokud nezměníte výchozí koncové body, útočník by potřeboval přímý přístup k vašemu zařízení pro přístup k IPC ASF, Proto je to tak bezpečné, jak to může být, a neexistuje možnost nikoho jiného, dokonce ani od vašeho LAN.

Pokud se však rozhodnete změnit výchozí `localhost` , naváže adresy na něco jiného, pak máte nastavit správná pravidla firewallu **sám** , aby bylo umožněno pouze autorizovaným IP adresám přístupu k IPC rozhraní ASF. Kromě toho budete muset nastavit `IPCPassword`protože ASF odmítne povolit ostatním strojům přístup k ASF API bez jednoho, což přidává další vrstvu zabezpečení navíc. Možná budete chtít také spustit IPC rozhraní ASF za reverzní proxy v tomto případě, což je dále vysvětleno níže.

### Mohu přistupovat k ASF API pomocí vlastních nástrojů nebo uživatelských příkazů?

Ano, pro toto bylo navrženo ASF API a můžete použít cokoliv, co může poslat HTTP požadavek pro přístup k němu. Místní uživatelé sledují logiku **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** a pro ně povolujeme přístup ze všech původů (`*`), dokud je nastaveno `IPCPassword` jako další bezpečnostní opatření. To vám umožňuje provádět různé ověřené ASF API požadavky, aniž by dovolili potenciálně škodlivé skripty to dělat automaticky (protože k tomu potřebují znát `IPCPassword`).

### Mohu k IPC ASF přistupovat vzdáleně, např. z jiného stroje?

Ano, doporučujeme pro to použít reverzní zástupce. Tímto způsobem můžete typicky přistupovat k vašemu webovému serveru, který pak na stejném počítači přistupuje k IPC ASF. Alternativně pokud nechcete běžet s reverzním proxy, můžete pro to použít **[vlastní konfiguraci](#enabling-access-from-all-ips)**. Například, pokud je váš stroj ve VPN s adresou `10.8.0.1` , můžete nastavit `http://10.8.0. :1242` naslouchání URL v IPC konfiguraci, která by umožnila přístup IPC z vašeho soukromého VPN, ale ne odkudkoliv jinde.

### Mohu použít IPC ASF za reverzní proxy jako Apache nebo Nginx?

**Ano**, náš IPC je s tímto nastavením plně kompatibilní, abyste ho mohli hostit i před vlastními nástroji pro zabezpečení a kompatibilitu, pokud chcete. Obecně platí, že server Kestrel http je velmi bezpečný a při přímém připojení k internetu nepředstavuje žádné riziko. ale jeho umístění za reverzní proxy jako Apache nebo Nginx by mohlo zajistit další funkčnost, které by nebylo možné jinak dosáhnout, jako zabezpečení rozhraní ASF s **[základní auth](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Příklad konfigurace Nginx je uveden níže. Obsahovali jsme celý blok `server` , i když máte zájem hlavně o `lokaci`. Pokud potřebujete další vysvětlení, podívejte se na **[nginx dokumentaci](https://nginx.org/en/docs)**.

```nginx
server {
    poslouchejte *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /path/to/your/fullchain. em;
    ssl_certificate_key /cesta/k/vaše/privátní klíč. em;

    místo ~* /Api/NLog {
        proxy_pass http://127.0.0. :1242;

        # Pouze pokud potřebujete přepsat výchozí hostitele
# proxy_set_header Host 127. .0. ;

        # X-headers by měl být vždy specifikován při proxování požadavků ASF
        # Jsou klíčové pro správnou identifikaci původního IP, umožnění aplikace ASF např. zabanovat skutečné pachatele namísto vašeho nginx serveru
        # zadáním umožňuje ASF správně vyřešit IP adresy uživatelů podávající žádosti - aby nginx fungoval jako reverzní proxy
        # Jejich zadání způsobí, že ASF bude přistupovat k vašemu nginx jako ke klientovi - nginx bude v tomto případě fungovat jako tradiční proxy v
        # Pokud nemůžete hostit nginx službu na stejném počítači jako ASF, pravděpodobně chcete nastavit KnownNetworks odpovídajícím způsobem navíc k
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host

        # Přidáme tyto 3 další možnosti pro proxyování websocketů, viz https://nginx. rg/cs/docs/http/websocket.html
        proxy_http_version 1. ;
        proxy_set_header spojení "Upgrade";
        proxy_set_header Upgrade $http_upgrade
    }

    lokace / {
        proxy_pass http://127. .0. :1242;

        # Pouze pokud potřebujete přepsat výchozí hostitel
# proxy_set_header Host 127. .0. ;

        # X-hlavičky by měly být vždy specifikovány při proxování požadavků ASF
        # Jsou klíčové pro správnou identifikaci původní IP, umožnění aplikace ASF např. zabanovat skutečné pachatele namísto vašeho nginx serveru
        # zadáním umožňuje ASF správně vyřešit IP adresy uživatelů podávající žádosti - aby nginx fungoval jako reverzní proxy
        # jejich zadání způsobí, že ASF bude přistupovat k vašemu nginx jako ke klientovi - nginx bude v tomto případě fungovat jako tradiční proxy v
        # Pokud nemůžete hostit nginx službu na stejném počítači jako ASF, s největší pravděpodobností chcete vedle
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_fornastavit KnownNetworks odpovídajícím způsobem;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
    }
}
```

Příklad konfigurace Apache naleznete níže. Pokud potřebujete další vysvětlení, podívejte se na **[apache dokumentaci](https://httpd.apache.org/docs)**.

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerName asf.mydomain. om

        SSLEngine na
        SSLCertificateFile /path/do/your/fullchain. u
        SSLCertificateKeyFile /path/do/your/privkey.

        # TODO: Apache nemůže správně řešit malá a malá písmena, takže tvrdě kódujeme dva nejčastěji používané případy
        ProxyPass "/api/nlog" "ws://127. .0. :1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0. :1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### Mohu přistupovat k IPC rozhraní prostřednictvím protokolu HTTP?

**Ano**, můžete toho dosáhnout dvěma různými způsoby. Doporučeným způsobem by bylo použití reverzního proxy serveru, kde můžete přistupovat ke svému webovému serveru pomocí https jako obvykle, a připojte se přes něj k IPC rozhraní ASF na stejném počítači. Tímto způsobem je váš provoz plně šifrován a nemusíte měnit IPC žádným způsobem, abyste toto nastavení podpořili.

Druhá cesta zahrnuje zadání **[custom config](#custom-configuration)** pro rozhraní IPC ASF, kde můžete povolit https endpoint a poskytnout vhodný certifikát přímo na našem serveru Kestrel http. Tento způsob se doporučuje, pokud nepoužíváte žádný jiný webový server a nechcete ho spouštět výhradně pro ASF. Jinak je mnohem snazší dosáhnout uspokojivého nastavení pomocí mechanismu reverzního proxy serveru.

---

### Při spouštění IPC dostávám chybu: `System.IO. Výjimka: Nepodařilo se navázat na adresu, byl učiněn pokus o přístup k socketu způsobem, který je zakázán jeho přístupovými oprávněními`

Tato chyba naznačuje, že něco jiného na vašem počítači již tento port používá, nebo jej rezervuje pro budoucí použití. Mohli byste to být vy, pokud se pokoušíte spustit druhou instanci ASF na stejném počítači, ale nejčastěji to je Windows kromě portu `1242` z vašeho používání, proto budete muset přesunout ASF do jiného portu. Chcete-li to provést, následujte **[příklad konfigurace](#changing-default-port)** výše, a prostě se snažte vybrat jiný přístav, jako je `12420`.

Samozřejmě se také můžete pokusit zjistit, co blokuje port `1242` z ASF použití a odstranit jej, ale je to obvykle mnohem problematičtější, než poučit ASF, aby použil jiný přístav, takže budeme přeskočit další rozpracování tohoto dokumentu.

---

### Proč dostávám `403 zakázané` , když nepoužívám `IPCPassword`?

ASF obsahuje další bezpečnostní opatření, které ve výchozím nastavení povoluje pouze rozhraní s smyčkou (`localhost`, váš vlastní stroj) pro přístup k ASF API bez `IPCPassword` nastavené v konfiguraci. Je to proto, že použití `IPCPassword` by mělo být **minimálním** bezpečnostním opatřením nastaveným každým, kdo se rozhodne dále vystavit rozhraní ASF.

Tuto změnu diktovala skutečnost, že obrovské množství pomocných seizmických stanic, které celosvětově hostí neznámí uživatelé, bylo převzato kvůli zlovolným záměrům, obvykle zanechávají lidi bez účtů a bez položek. Nyní bychom mohli říct: "Mohly by si tuto stránku přečíst před otevřením ASF celému světě", ale namísto toho dává větší smysl zakázat ve výchozím nastavení nezabezpečené ASF, a vyžadují od uživatelů akci, pokud ji chtějí výslovně povolit, což dále rozpracujeme.

Zejména můžete přepsat naše rozhodnutí zadáním sítí, u kterých věříte, že dosáhnete ASF bez zadání `IPCPassword` , můžete nastavit vlastnosti `KnownNetworks` ve vlastní konfiguraci. However, unless you **really** know what you're doing and fully understand the risks, you should instead use `IPCPassword` as declaring `KnownNetworks` will allow everybody from those networks to access ASF API unconditionally. Jsme vážní, lidé se již stříleli do nohy a věřili, že jejich obrácená zástupná jména a pravidla iptables jsou bezpečná, ale oni byli, `IPCPassword` je první a někdy poslední strážník, pokud se rozhodnete z tohoto jednoduchého, ale velmi efektivního a bezpečného mechanismu, budete mít na vině pouze sebe.