# Beveiliging

## Versleuteling

ASF ondersteunt momenteel de volgende versleutelingsmethoden als een definitie van `ECryptoMethod`:

| Waarde | Naam                        |
| ------ | --------------------------- |
| 0      | Onopgemaakte tekst          |
| 1      | AES                         |
| 2      | BeschermdDataForCurrentUser |
| 3      | Omgevingsvariabele          |
| 4      | Bestand                     |

De exacte beschrijving en vergelijking hiervan is hieronder beschikbaar.

### Installatie

Om een versleuteld wachtwoord te genereren, bijvoorbeeld voor `SteamPassword` gebruik, u moet `coderen` **[commando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** uitvoeren met de juiste versleuteling die u heeft gekozen en uw oorspronkelijke platte-tekst wachtwoord. Zet daarna de versleutelde tekenreeks die u heeft als `SteamPassword` bot configuratie eigenschap, en ten slotte verander `WachtwoordFormat` naar het wachtwoord dat overeenkomt met de door jou gekozen encryptiemethode. Sommige formaten hebben geen `encrypt` commando nodig, bijvoorbeeld `EnvironmentVariable` or `File`, gewoon het juiste pad voor ze in.

---

### `Onopgemaakte tekst`

Dit is de meest eenvoudige en onveilige manier om een wachtwoord op te slaan, gedefinieerd als `ECryptoMethod` of `0`. ASF verwacht dat de string een platte tekst is - een wachtwoord in het persoonlijk formulier. Het is de gemakkelijkste te gebruiken en 100% compatibel met alle setups, Daarom is het een standaardmanier om geheimen en volledig onveilig op te slaan voor een veilige opslag.

---

### `AES`

Vandaag de dag is veilig ingevat, **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** manier van opslaan van het wachtwoord wordt gedefinieerd als `ECryptoMethod` of `1`. ASF verwacht dat de tekenreeks een **[base64-gecodeerde](https://en.wikipedia.org/wiki/Base64)** reeks tekens die resulteert in AES-gecodeerde byte array na de vertaling, welke vervolgens moet worden gedecodeerd met behulp van de meegeleverde **[initialisatie vector](https://en.wikipedia.org/wiki/Initialization_vector)** en de ASF encryptiesleutel.

De bovenstaande methode garandeert beveiliging zolang de aanvaller niet weet dat de ASF-encryptiesleutel wordt gebruikt voor de decodering en de versleuteling van wachtwoorden. Met ASF kunt u sleutel specificeren via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, die u moet gebruiken voor maximale beveiliging. Als je besluit om het te weglaten zal ASF zijn eigen sleutel gebruiken, die **bekend is** en die hard gecodeerd is in de applicatie, betekent dat iedereen de ASF-versleuteling ongedaan kan maken en gedecodeerd wachtwoord kan krijgen. Het vergt nog wat inspanning en het is niet zo makkelijk om te doen, maar mogelijk Daarom zou u bijna altijd `AES` encryptie moeten gebruiken met uw eigen `--cryptkey` die in het geheim wordt gehouden. AES methode gebruikt in ASF biedt veiligheid die bevredigend moet zijn en het is een balans tussen eenvoud van `PlainText` en de complexiteit van `ProtectedDataForCurrentUser`, maar het is sterk aanbevolen om het te gebruiken met een eigen `--cryptkey`.

Wanneer goed gebruikt (lang, custom `--cryptkey`), garandeert zeer hoge beveiliging voor een veilige opslag.

---

### `BeschermdDataForCurrentUser`

Vandaag de dag is veilig ingevat, **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** manier van opslaan van het wachtwoord wordt gedefinieerd als `ECryptoMethod` of `2`. Het grootste voordeel van deze methode is tegelijkertijd het grote nadeel - in plaats van het gebruik van encryptiesleutel (zoals in `AES`), data is versleuteld met inloggegevens van de ingelogde gebruiker, dit betekent dat het mogelijk is om de gegevens alleen **te decoderen op de machine waarop het was versleuteld,** en daarnaast ook **alleen** door de gebruiker die de encryptie heeft uitgegeven.

Dit zorgt ervoor dat, zelfs als je je hele `Bot stuurt. son` met versleutelde `SteamPassword` gebruik van deze methode voor iemand anders, ze kunnen het wachtwoord niet ontsleutelen zonder directe toegang tot uw PC. Dit is een uitstekende veiligheidsmaatregel, maar tegelijkertijd heeft het een groot nadeel dat het niet compatibel is. als wachtwoord dat versleuteld is met deze methode zal niet compatibel zijn met elke andere gebruiker en machine - inclusief **uw eigen** als u besluit te gaan. . installeer uw besturingssysteem opnieuw. Dit is de aanbevolen methode als je geen toegang hebt tot je configuraties van een andere machine dan je eigen machine en dat je ook geen cross-machine compatibiliteit nodig hebt.

**Houd er rekening mee dat deze optie momenteel alleen beschikbaar is voor machines die Windows OS gebruiken.**

---

### `Omgevingsvariabele`

Geheugengebaseerde opslag gedefinieerd als `ECryptoMethod` of `3`. ASF zal het wachtwoord van de omgevingsvariabele lezen met de opgegeven naam in het wachtwoordveld (bijv. `SteamPassword`). Bijvoorbeeld `SteamPassword` zetten op `ASF_PASSWORD_MYACCOUNT` en `WachtwoordFormat` op `3` zorgt ervoor dat ASF `${ASF_PASSWORD_MYACCOUNT}` omgevingsvariabele gebruikt en gebruikt wat er aan wordt toegewezen als het accountwachtwoord.

Vergeet niet te zorgen dat omgevingsvariabelen van het ASF-proces niet toegankelijk zijn voor ongeautoriseerde gebruikers. als dat het einde betekent van het gebruik van deze methode.

---

### `Bestand`

Bestandsgebaseerde opslag (mogelijk buiten de ASF config directory) gedefinieerd als `ECryptoMethod` of `4`. ASF zal het wachtwoord lezen van het bestandspad dat is opgegeven in het wachtwoordveld (bijv. `SteamPassword`). Het opgegeven pad kan absoluut of relatief zijn ten opzichte van de ASF's "thuis" locatie (de map met `config` map binnen, rekening houden met `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). Deze methode kan bijvoorbeeld gebruikt worden met **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**, welke dergelijke bestanden maken voor gebruik, maar deze kunnen ook buiten Docker worden gebruikt als u zelf een geschikt bestand maakt. Bijvoorbeeld het instellen van `SteamPassword` op `/etc/secrets/MyAccount. pas` en `WachtwoordFormat` naar `4` zal ASF dwingen `/etc/secrets/MyAccount te lezen. pas` en gebruik wat er naar dat bestand wordt geschreven als account wachtwoord.

Vergeet niet om ervoor te zorgen dat het bestand met het wachtwoord niet leesbaar is voor ongeautoriseerde gebruikers, omdat dat het hele doel van het gebruik van deze methode ondermijnt.

---

## Versleuteling aanbevelingen

Als compatibiliteit geen probleem voor u is, en u bent prima met de manier waarop `ProtectedDataForCurrentUser` methode werkt het is de **aanbevolen** optie om het wachtwoord in ASF op te slaan, omdat het de beste zekerheid en gemak biedt. `AES` methode is een goede keuze voor mensen die nog steeds gebruik willen maken van hun configuraties op elke machine die ze willen, terwijl `PlainText` de meest eenvoudige manier is om het wachtwoord op te slaan, als u het niet erg vindt dat iemand een JSON configuratiebestand kan bekijken.

Houd er rekening mee dat alle encryptiemethoden worden beschouwd als **onveilige** als de aanvaller toegang heeft tot uw PC. ASF moet in staat zijn gecodeerde wachtwoorden te decoderen, en als het programma dat op uw machine wordt uitgevoerd daartoe in staat is. dan zal elk ander programma dat op dezelfde machine draait dat ook kunnen. `ProtectedDataForCurrentUser` is de veiligste variant als **Zelfs een andere gebruiker met dezelfde PC zal het niet kunnen decoderen**, maar het is nog steeds mogelijk om de gegevens te decoderen als iemand uw inloggegevens en machine-info kan stelen naast het ASF-configuratiebestand.

Voor geavanceerde installaties, kan je `omgevingsvariabelen` en `bestanden ` gebruiken. Ze hebben beperkte bruikbaarheid, de `EnvironmentVariable` is een goed idee als je liever een wachtwoord ontvangt via een aangepaste oplossing en het alleen in het geheugen opslaat. terwijl `File` goed is voor bijvoorbeeld **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. Beide zijn niet versleuteld, dus verplaats je in principe het risico van een ASF configuratiebestand naar wat je uit die twee kiest.

Naast de hierboven gespecificeerde versleutelingsmethoden is het ook mogelijk om het opgeven van wachtwoorden volledig te vermijden, bijvoorbeeld als `SteamPassword` door een lege tekenreeks of een `null` waarde te gebruiken. ASF zal je om je wachtwoord vragen wanneer dit vereist is. en zal het nergens opslaan, behalve dan in het geheugen houden van het lopende proces, totdat je het afsluit. Hoewel het de meest veilige methode is om met wachtwoorden om te gaan (ze zijn nergens opgeslagen), het is ook de meest problematische om je wachtwoord handmatig in te voeren bij elke ASF-uitvoering (indien nodig). Als dat geen probleem voor jou is, is dit je beste weddenschap veiligheid - want je kan iets niet lekken dat niet bestaat.

---

## Ontsleutelen

ASF ondersteunt geen enkele manier om reeds versleutelde wachtwoorden te decoderen, omdat de versleutelingsmethoden alleen intern worden gebruikt voor toegang tot de data binnen het proces. Als u de versleutelingsprocedure wilt terugzetten b.v. voor het verplaatsen van ASF naar een andere machine bij het gebruik van `ProtectedDataForCurrentUser`, en voor het herhalen van de procedure vanaf het begin in de nieuwe omgeving.

---

## Hashing

ASF ondersteunt momenteel de volgende hashing methoden als een definitie van `EHashingMethod`:

| Waarde | Naam               |
| ------ | ------------------ |
| 0      | Onopgemaakte tekst |
| 1      | SCrypt             |
| 2      | Pbkdf2             |

De exacte beschrijving en vergelijking hiervan is hieronder beschikbaar.

### Installatie

Om een hash te genereren, vb. voor `IPCPassword` gebruik, u moet `hash` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** uitvoeren met de juiste hashing methode die u gekozen heeft en uw oorspronkelijke platin-text wachtwoord. Zet daarna de hash-string die u hebt als `IPCPassword` ASF configuratie eigenschap, en tenslotte verander `IPCPasswordFormat` naar degene die overeenkomt met de gekozen hashing-methode.

---

### `Onopgemaakte tekst`

Dit is de meest eenvoudige en onveilige manier om een wachtwoord te hashen, gedefinieerd als `EHashingMethod` of `0`. ASF zal hash genereren die overeenkomt met de originele invoer. Het is de gemakkelijkste te gebruiken en 100% compatibel met alle setups, Daarom is het een standaardmanier om geheimen en volledig onveilig op te slaan voor een veilige opslag.

---

### `SCrypt`

Vandaag de dag is veilig ingevat, **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** manier om het wachtwoord te hashen wordt gedefinieerd als `EHashingMethod` of `1`. ASF zal de `SCrypt` implementatie gebruiken met `8` blokken, `8192` iteraties, `32` hash-lengte en encryptiesleutel als zout om een reeks bytes te genereren. De resulterende bytes zullen dan gecodeerd worden als **[base64](https://en.wikipedia.org/wiki/Base64)** string.

Met ASF kunt u salt voor deze methode specificeren via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, welke u moet gebruiken voor maximale beveiliging. Als je besluit om het te weglaten zal ASF zijn eigen sleutel gebruiken, die **bekend is** en die hard gecodeerd is in de applicatie, betekent dat hashing minder veilig zal zijn.

Indien correct gebruikt (aangepaste zout, lang wachtwoord) garandeert zeer hoge beveiliging voor een veilige opslag.

---

### `Pbkdf2`

Vandaag de dag zijn de normen zwak. **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** manier om het wachtwoord te hashen wordt gedefinieerd als `EHashingMethod` of `2`. ASF will use the `Pbkdf2` implementation using `10000` iterations, `32` hash length and encryption key as a salt, with `SHA-256` as a hmac algorithm. De resulterende bytes zullen dan gecodeerd worden als **[base64](https://en.wikipedia.org/wiki/Base64)** string.

Met ASF kunt u salt voor deze methode specificeren via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, welke u moet gebruiken voor maximale beveiliging. Als je besluit om het te weglaten zal ASF zijn eigen sleutel gebruiken, die **bekend is** en die hard gecodeerd is in de applicatie, betekent dat hashing minder veilig zal zijn.

---

## Aanbevelingen voor Hashing

Als u een hashing-methode wilt gebruiken om enkele geheimen op te slaan, zoals `IPCPassword`, we raden aan om `SCrypt` te gebruiken met aangepast zout, omdat het een zeer fatsoenlijke beveiliging biedt tegen brute-forcerende pogingen.

`Pbkdf2` is alleen aangeboden om compatibiliteitsredenen. voornamelijk omdat we al een werk (en nodig) implementatie ervan hebben voor andere gebruik van zaken via het Steam-platform (bv. . oud-pinnen. Het wordt nog steeds als veilig beschouwd, maar zwak in vergelijking met alternatieven (bijvoorbeeld `SCrypt`).