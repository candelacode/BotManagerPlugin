# Plugins

ASF biedt ondersteuning voor aangepaste plug-ins die tijdens het starten geladen kunnen worden. Met plugins kunt u ASF-gedrag aanpassen, bijvoorbeeld door het toevoegen van aangepaste commando's, aangepaste handelsideologie of hele integratie met diensten van derden en API's.

Deze pagina beschrijft ASF plugins vanuit het perspectief van gebruikers - uitleg, gebruik en wat dies meer zij. Als je het perspectief van de ontwikkelaar wilt bekijken, plaats dan in plaats daarvan **[hier](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)**.

---

## Gebruik

ASF laadt plug-ins van `plugins` map in je ASF map. Het is een aanbevolen praktijk (die verplicht wordt met automatische plugin updates) om een specifieke map te behouden voor elke plugin die je wilt gebruiken welke gebaseerd kan zijn op zijn naam, zoals `MyPlugin`. Dit resulteert in de definitieve boom structuur van `plugins/MyPlugin`. Tot slot moeten alle binaire bestanden van de plugin in de toegewijde map worden geplaatst, en ASF zal de plugin correct ontdekken en gebruiken na het opnieuw opstarten.

Meestal plugin ontwikkelaars publiceren hun plugins in de vorm van een `zip` bestand met binaries dit betekent dat je dat zip-bestand moet uitpakken in zijn eigen specifieke submap in `plugins` map.

Als de plugin met succes is geladen, ziet u de naam en versie in uw log. Raadpleeg de plugin ontwikkelaars in geval van vragen, problemen of gebruik in verband met de plugins die je hebt gekozen.

Je kunt enkele featured plugins vinden in onze **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** sectie.

**Houd er rekening mee dat ASF plugins kwaadaardig kunnen zijn**. Je moet er altijd voor zorgen dat je plugins gebruikt die je kunt vertrouwen, zelfs die van bovenstaande derde partij. ASF ontwikkelaars kunnen niet langer garanderen dat je gebruikelijke ASF voordelen hebt (zoals het gebrek aan malware of VAC-gratis) als je besluit om aangepaste plug-ins te gebruiken. Je moet begrijpen dat plugins de volledige controle hebben over het ASF-proces zodra het is geladen, Hierdoor kunnen we ook geen instellingen ondersteunen die aangepaste plugins gebruiken, omdat je geen vanilla ASF code meer gebruikt.

---

## Compatibiliteit

Afhankelijk van de complexiteit, omvang en een heleboel andere factoren, het is helemaal mogelijk dat het van je vereist om **[generieke](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** ASF-variant te gebruiken, in plaats van meestal **[OS-specifiek](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)** te aanbevelen. Dit komt doordat de OS-specifieke variant alleen wordt geleverd met de kernfunctionaliteit die nodig is voor ASF zelf. en de plugin kan onderdelen vereisen die buiten het hoofdbereik van ASF vallen, wat leidt tot incompatibel zijn met trimmed OS-specifieke versies.

In het algemeen raden we bij het gebruik van plug-ins van derden aan om algemene ASF varianten te gebruiken voor maximale compatibiliteit. Maar niet alle plugins vereisen het - raadpleeg de informatie van je plugin om te weten te komen of je generieke ASF-variant nodig hebt of niet.

---


## Automatische updates

ASF heeft een ingebouwd mechanisme voor automatische updates van plug-ins. Om die functie te laten werken, moet in de eerste plaats uw plugin van keuze **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)** dat mechanisme ondersteunen. Als je een plugin hebt geladen die automatische updates ondersteunt, zal ASF dit melden in het logboek tijdens de initialisatie van de plugin zoals "plugin is uitgeschakeld voor automatische updates" of "plugin is geregistreerd en geactiveerd voor automatische updates".

Standaard zijn automatische updates voor aangepaste plug-ins **uitgeschakeld**, vanwege veiligheidsredenen. U kunt automatische updates in de configuratie configureren met behulp van **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** en/of **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)**, We raden aan om een beschrijving te lezen van deze configuratie-eigenschappen voor meer info. Het is ook leuk om op te merken dat, net als bij ASF-updates, je kunt besluiten automatische updates uit te schakelen en vervolgens bij te werken op de gewenste updates. handmatige basis, door `updateplugins` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** uit te geven.

Beide benaderingen maken het mogelijk om geen plug-ins bij te werken die je in het proces hebt geladen.