# Etäviestintä

Tässä osiossa käsitellään etäviestintää, jota ASF sisältää, mukaan lukien lisäselvitys siitä, miten se voi vaikuttaa. Vaikka emme pidä mitään alla pahansuopia tai muuten ei-toivottu, emmekä ole lain velvollisia paljastamaan sitä, haluamme sinun ymmärtävän paremmin ohjelman toiminnallisuutta, erityisesti mitä tulee yksityisyytesi ja tietojesi jakamiseen.

## Steam

ASF kommunikoi Steam-verkon kanssa (**[CM-palvelimet](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), sekä **[Steam API](https://steamcommunity.com/dev)**, **[Steam Store](https://store.steampowered.com)** ja **[Steam yhteisö](https://steamcommunity.com)**.

Ei ole mahdollista poistaa mitään edellä mainituista viesteistä, koska se on ydin perusta ASF perustuu voidakseen tarjota sen perustoiminnallisuutta. Sinun on pidättäydyttävä käyttämästä ASF:ää, jos et ole tyytyväinen yllämainittuihin.

## Steam-ryhmä

ASF kommunikoi meidän **[Steam-ryhmän](https://steamcommunity.com/groups/archiasf)** kanssa. Ryhmä tarjoaa sinulle ilmoituksia, erityisesti uusia versioita, kriittisiä ongelmia, Steam ongelmia ja muita asioita, jotka ovat tärkeitä pitää yhteisön ajan tasalla. Sen avulla voit myös käyttää teknistä tukeamme kysymällä kysymyksiä, ratkaisemalla ongelmia, raportoimalla ongelmista tai ehdottamalla parannuksia. Oletuksena ASF:issä käytetyt tilit liittyvät ryhmään automaattisesti sisäänkirjautumisen yhteydessä.

Voit päättää olla osallistumatta ryhmään poistamalla käytöstä `SteamGroup` -lipun **[`etäviestintä`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** asetukset.

## GitHub

ASF kommunikoi **[GitHubin API](https://api.github.com)** -sovelluksen kanssa, jotta **[ASF julkaisee](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** päivitystoiminnallisuuden. Tämä tehdään osana automaattisia päivityksiä (jos olet pitänyt **[`päivitysjakson`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** käytössä), sekä `päivitys` **[komento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Voit vaikuttaa ASF:n ja GitHubin väliseen viestintään **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** ominaisuuden - asetus `Mikään` ei johda koko päivitystoiminnon poistamiseen, mukaan lukien GitHub -viestintä tältä osin.

## ASF: n palvelin

ASF kommunikoi **[oman palvelimen](https://asf.justarchi.net)** kanssa saadaksesi edistyneempiä toimintoja. Tähän sisältyvät erityisesti seuraavat:
- Tarkistetaan GitHubista ladattujen ASF-versioiden tarkistussummat omaa riippumatonta tietokantaamme vastaan, jotta kaikki ladatut versiot ovat laillisia (ilman haittaohjelmia, MITM-hyökkäykset tai muu kajoaminen)
- Haetaan luetteloa huonoista boteista suodatusta varten, jos olet pitänyt `suodatinBadbots` yleisen asetusasetuksen käytössä.
- Ilmoittaminen bottistasi **[listauksessamme](https://asf.justarchi.net/STM)** jos olet ottanut käyttöön `SteamTradeMatcher` **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** ja täytä muita kriteerejä
- Ladataan tällä hetkellä saatavilla olevia botteja kaupalle **[meidän listalle](https://asf.justarchi.net/STM)** jos olet ottanut käyttöön `MatchActively` **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** ja täyttävät muut kriteerit

Turvallisuustoimenpiteenä ei ole mahdollista poistaa tarkistussumman varmennusta käytöstä ASF rakennuksissa. Voit kuitenkin poistaa automaattisen päivityksen käytöstä kokonaan, jos haluat välttää tämän, kuten edellä on kuvattu GitHub-osiossa.

Voit poistaa `suodatinBadbots` asetuksen käytöstä, jos haluat välttää hakemasta listaa palvelimelta.

Voit päättää jättäytyä ilmoittamatta luetteloon poistamalla käytöstä `Julkistamalla` lipun **[`etäviestintä`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** asetukset. Tämä saattaa olla hyödyllistä, jos haluat ajaa `SteamTradeMatcher` botti ilmoittamatta siitä samanaikaisesti.

Bottien lataaminen listaltamme on pakollista `MatchActively` -asetukselle, sinun täytyy poistaa tämä asetus käytöstä, jos et halua hyväksyä sitä.