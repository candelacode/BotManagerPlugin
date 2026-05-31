# Steamin Lainaamo

ASF tukee Steam Family Sharing - vanhaa ja uutta järjestelmää. Jotta voitaisiin ymmärtää, miten ASF toimii sen kanssa, sinun pitäisi ensin lukea miten **[Steam Family Sharing toimii](https://store.steampowered.com/promotion/familysharing)**, joka on saatavilla Steam-kaupassa. Sen lisäksi tarkista **[uutiset](https://store.steampowered.com/news/app/593110/view/4149575031735702628)** tulevasta uudesta Steam-perheen jakojärjestelmästä, jonka kanssa ASF on yhteensopiva.

---

## ASF

Tuki Steam Family Sharing -ominaisuudelle ASF on läpinäkyvä, mikä tarkoittaa, että se ei esitä mitään uusia botti/prosessi config ominaisuuksia - se toimii ulos laatikosta ylimääräinen sisäänrakennettu toiminto.

ASF sisältää asianmukaisen logiikan, jotta se voi olla tietoinen siitä, että perheen jakamat käyttäjät lukitsevat kirjaston siksi se ei "potkia" ne pois pelattaessa istuntoa käynnistämällä pelin. ASF toimii täsmälleen samalla tavalla kuin ensisijaisella tilillä lukitusta pitämällä, joten jos tämä lukitus on joko höyryasiakkaan hallussa, tai yksi perheen jakamisen käyttäjiä, ASF ei yritä tilalle, vaan se odottaa lukon vapauttamista. Tämä liittyy enimmäkseen vanhaan järjestelmään - uuden järjestelmän avulla perheesi jakamat käyttäjät voivat pelata muita pelejä kuin ASF on tällä hetkellä maataloudessa.

Edellä mainitun lisäksi ASF käyttää perheenjakamisjärjestelmiä (vanhoja ja uusia), kun se on kirjautunut sisään. josta se poimii käyttäjät (Steam IDs) jotka saavat käyttää kirjastoasi. Näille käyttäjille annetaan `FamilySharing` lupa käyttää **[komentoja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, erityisesti jotta he voivat käyttää `tauko~` komentoa bottitilillä, joka jakaa pelejä heidän kanssaan, joka mahdollistaa pysäyttää automaattiset kortit maatalouden moduuli käynnistää peli, joka voidaan jakaa - tämä koskee enimmäkseen myös vanha järjestelmä, mutta voi silti käyttää uuden järjestelmän jos ASF on tällä hetkellä maatalouden peli, että käyttäjät haluavat pelata.

Yhdistämällä edellä kuvattuja toimintoja voit ystäväsi `tauko~` korttisi viljelyprosessiin, aloittaa pelin, pelata niin kauan kuin he haluavat, ja sitten kun he ovat tehneet pelin, korttien maatalouden prosessi jatkuu automaattisesti ASF. Tietenkin `tauko~` ei tarvita, jos ASF ei tällä hetkellä viljele aktiivisesti koska ystäväsi voivat käynnistää pelin heti, ja edellä kuvattu logiikka varmistaa, että he eivät potku pois istunnosta.

---

## Rajoitukset

Steam-verkko rakastaa johtaa ASF:ää harhaan lähettämällä vääriä tilapäivityksiä, mikä voi johtaa ASF uskoa se on hieno jatkaa prosessia, ja tuloksena potkia ystäväsi liian pian. Tämä on täsmälleen sama asia kuin se, jonka olemme jo selittäneet **[tämä FAQ merkintä](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. Suosittelemme täsmälleen samat ratkaisut, Korostamalla ystäviäsi `Operaattorille` -käyttöoikeudelle (tai yläpuolelle) ja kertomalla heille `tauko` ja `jatkavat` komentoja.