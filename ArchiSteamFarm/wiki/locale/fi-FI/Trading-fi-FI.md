# Vaihtaminen

ASF sisältää tuen Steam-ei-interaktiivisille (offline) kaupaille. Sekä vastaanottaminen (hyväksyminen/väheneminen) että kauppojen lähettäminen on saatavilla heti eikä vaadi erityisiä konfiguraatioita, mutta tietenkin vaatii rajoittamattoman Steam-tilin (tili, joka on jo viettänyt 5$ kaupassa). Vain rajoitettu kaupankäynnin toiminnallisuutta on saatavilla rajoitetuille tileille.

---

## Logiikka

Ensinnäkin, on mahdollista poistaa **kaikki** tulevat kauppatarjoukset, käyttämällä `DisableIncomingTradesParsing` -lippua `BotBehaviour`. Käyttämällä sitä, kuten nimestä käy ilmi, poistaa käytöstä kaikki saapuviin kauppoihin liittyvät toiminnot, joka sisältää alle oletusarvon logiikka, sekä kaikki ylimääräiset ominaisuudet, jotka riippuvat reagoida saapuvaan kauppatarjoukseen. Koska oletusasetukset ovat jo ei-häiritseviä, sinun tulisi harkita tämän vaihtoehdon käyttöä vain, jos sinulla ei ole mitään aikeita ASF tehdä mitään liittyvät saapuviin kauppoihin lainkaan.

Alla selitetään logiikka, kun saapuvan kaupan tarjoaa jäsennys on käytössä, mikä on oletusvaihtoehto.

ASF hyväksyy aina kaikki kaupat kohteista riippumatta, ja ne lähetetään käyttäjiltä, joilla on `Master` (tai uudempi) pääsy bottiin. Tämä mahdollistaa paitsi helposti ryöstää höyry kortteja viljellyt botin esimerkki, mutta voit myös hallita helposti Steam-kohteita, jotka botti stashes tavaraluettelossa - mukaan lukien muut pelit (kuten CS:GO).

ASF hylkää kauppatarjouksen, riippumatta sisällöstä, mistä tahansa (ei-master) käyttäjästä, joka on mustalla listalla kaupankäynnin moduuli. Mustalista on tallennettu standardiin `BotName. b` tietokanta ja sitä voi hallinnoida `tb`, `tbadd` ja `tbrm` **[komentoja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Tämän pitäisi toimia vaihtoehtona Steamin tarjoamalle tavalliselle käyttäjälohkolle - käytä varoen.

ASF hyväksyy kaikki `loot`-tyyppiset kaupat jotka lähetetään bottien kautta, ellei `DontAcceptBotTrades` ole määritelty `TradingPreferences`. Lyhyesti sanottuna oletus `TradingPreferences` of `Ei mikään` saa ASF automaattisesti hyväksymään kaupat käyttäjiltä, joilla on `Master` pääsy bottiin (selitetty yllä), sekä kaikki luovutuskaupat muista botteista, jotka osallistuvat ASF-prosessiin.

Kun otat käyttöön `AcceptDonations` `TradingPreferences`, ASF hyväksyy myös kaikki luovutuskaupat - kauppa, jossa bot tili ei menetä mitään tuotteita. Tämä ominaisuus vaikuttaa vain muihin kuin bottitileihin, koska botti tileihin vaikuttaa `DontAcceptBotTrades`. `Hyväksymislahjoitukset` sallii sinun helposti hyväksyä lahjoituksia muilta ihmisiltä, ja myös botteja, jotka eivät osallistu ASF-prosessiin.

On mukava huomata, että `Hyväksymislahjoitukset` ei vaadi **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, koska ei ole mitään vahvistusta tarvitaan, jos emme menetä esineitä.

Voit myös muokata ASF kaupankäynnin ominaisuuksia muokkaamalla `TradingPreferences` vastaavasti. Yksi tärkeimmistä `TradingPreferences` ominaisuuksista on `SteamTradeMatcher` -vaihtoehto, joka aiheuttaa ASF käyttää sisäänrakennettua logiikkaa hyväksyäkseen kaupat, jotka auttavat sinua täyttämään puuttuvat merkit, joka on erityisen hyödyllinen yhteistyössä julkisen luettelon **[SteamTradeMatcher](https://www.steamtradematcher.com)**, mutta voi toimia myös ilman sitä. Sitä kuvataan tarkemmin alla.

---

## `SteamTradeMatcher`

Kun `SteamTradeMatcher` on aktiivinen, ASF käyttää melko monimutkainen algoritmi tarkistaa, jos kauppa hyväksyy STM sääntöjä ja on ainakin neutraali meitä kohtaan. Todellinen logiikka on seuraava:

- Hylkää kauppa, jos olemme menettämässä mitään paitsi tuotetyyppejä, jotka on määritelty meidän `MatchableTypes`.
- Hylkää kauppa, jos emme saa vähintään samaa määrää kohteita per peli, per-type ja per-rarity perusteella.
- Hylkää kauppa, jos käyttäjä pyytää erityistä Steam kesä / talvi myynti kortteja, ja on kaupparekisteri.
- Hylkää kauppa, jos kaupan pitämisen kesto ylittää `MaxTradeHoldDuration` globaali config ominaisuus.
- Hylkää kauppa, jos meillä ei ole `MatchEverything` asetettua, ja se on huonompi kuin neutraali meille.
- Hyväksy kauppa, jos emme hylkää sitä millään yllä olevista kohdista.

On mukava huomata, että ASF tukee myös liikaa - logiikka toimii kunnolla, kun käyttäjä lisää jotain ylimääräistä kauppaan, niin kauan kuin kaikki edellä mainitut edellytykset täyttyvät.

Neljän ensimmäisen hylkäämisen pitäisi olla itsestään selvää kaikille. Viimeiseen sisältyy todellinen dupes-logiikka, jossa tarkastetaan varastomme nykyinen tila ja päätetään, mikä on kaupan tilanne.

- Trade is **good** if our progress towards set completion advances. Esimerkki: A (ennen) -> A B (jälkeen)
- Kauppa on **neutraali** jos edistymme kohti sovittua loppuunviemistä. Esimerkki: A B (ennen) -> A C (jälkikäteen)
- Kauppa on **huono** , jos edistyminen kohti määrättyä toteutusta vähenee. Esimerkki: A C (ennen) -> A (jälkeen)

STM toimii vain hyviä kauppoja, mikä tarkoittaa, että käyttäjä käyttää STM dupes matching tulisi aina ehdottaa vain hyviä kauppoja meille. ASF on kuitenkin liberaali, ja se hyväksyy myös neutraalit kaupat, koska näissä kaupoissa emme itse asiassa menetä mitään, joten ei ole mitään todellista syytä hylätä niitä. Tämä on erityisen hyödyllistä ystävillesi, koska he voivat vaihtaa liiallisia kortteja ilman STM ollenkaan, niin kauan kuin et menetä mitään edistystä.

Oletuksena ASF hylkää huonoja kauppoja - tämä on lähes aina mitä haluat käyttäjänä. Kuitenkin voit vaihtoehtoisesti ottaa käyttöön `MatchEverything` `TradingPreferences` -toiminnon, jotta ASF voi hyväksyä kaikki dupe kaupat, sisältäen **huonoja**. Tämä on hyödyllistä vain, jos haluat ajaa 1:1 kaupan botti tililläsi, kuten ymmärrät, että **ASF ei enää auta sinua etenemään kohti kunniamerkin loppuunsaattamista, ja tehdä olet taipuvainen menettää koko valmis asetettu N dupes saman kortin**. If you want to intentionally run a trade bot that is **never** supposed to finish any set, and should offer its whole inventory to every interested user, then you can enable that option.

Riippumatta valitsemastasi `TradingPreferences`, ASF hylkää kaupan ei tarkoita, ettet voi hyväksyä sitä itse. Jos pidit oletusarvon `BotBehaviour`, joka ei sisällä `RejectInvalidTrades`, ASF vain sivuuttaa nämä kaupat - voit päättää itse, jos olet kiinnostunut niistä tai ei. Sama koskee kauppoja esineiden kanssa ulkopuolella `MatchableTypes`, sekä kaiken muun - moduulin on tarkoitus auttaa sinua automatisoida STM kaupat, ei päättää, mikä on hyvä kauppa ja mikä ei. Ainoa poikkeus tästä säännöstä on, kun puhut käyttäjistä, jotka mustat kaupankäyntimoduulista käyttäen `tbadd` komentoa - kaupat noilta käyttäjiltä hylätään välittömästi riippumatta `BotBehaviour` -asetuksista.

On erittäin suositeltavaa käyttää **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** kun otat tämän valinnan käyttöön, koska tämä toiminto menettää koko potentiaalin, jos päätät manuaalisesti vahvistaa jokaisen kaupan. `SteamTradeMatcher` toimii kunnolla jopa ilman kykyä vahvistaa kauppoja, mutta se voi luoda backlog vahvistuksia, jos et hyväksy niitä ajoissa.