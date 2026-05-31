# Suuren suorituskyvyn asetelma

Tämä on täysin päinvastainen kuin **[matalan muistin asetukset](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** ja yleensä haluat seurata näitä vinkkejä, jos haluat edelleen lisätä ASF suorituskykyä (suorittimen nopeutta), muistin käytön lisäämisestä mahdollisesti aiheutuvat kustannukset.

---

ASF pyrkii jo suosimaan suorituskykyä yleisen tasapainoisen virityksen osalta, siksi ei ole paljon voit tehdä edelleen lisätä sen suorituskykyä, vaikka et ole täysin pois vaihtoehdoista joko. Pidä kuitenkin mielessä, että nämä vaihtoehdot eivät ole oletusarvoisesti käytössä, mikä tarkoittaa, että he eivät ole tarpeeksi hyviä pitämään niitä tasapainoinen enemmistön käytöstä, siksi sinun pitäisi itse päättää, jos muistin kasvu tuonut on hyväksyttävää sinulle.

---

## Runtime tuning (advanced)

Alla olevia temppuja **liittyy vakava muistin lisäys** ja siksi käyttää varoen.

Suositeltu tapa soveltaa näitä asetuksia on `DOTNET_` ympäristöominaisuuksien kautta. Tietenkin voit käyttää myös muita menetelmiä, esim. `runtimeconfig. poika`, mutta joitakin asetuksia on mahdotonta asettaa tällä tavalla, ja tämän päälle ASF korvaa mukautetun `runtimeconfig. poika` yksinään seuraavassa päivityksessä, joten suosittelemme ympäristöominaisuuksia, jotka voit asettaa helposti ennen prosessin käynnistämistä.

.NET ajon avulla voit **[nipistää roskat kerääjä](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** monin tavoin, hienosäätämällä GC-prosessia tehokkaasti sinun tarpeidesi mukaan. Olemme dokumentoineet alla ominaisuuksia, jotka ovat meille erityisen tärkeitä.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Määrittelee käyttävätkö sovellus työasemien roskakokoelmaa vai palvelimen roskakokoelmaa.

Voit lukea tarkan spesifisen palvelimen GC at **[fundamentals of roskat kokoelma](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF käyttää oletusarvoisesti työasemien roskikokoelmaa. Tämä johtuu pääasiassa hyvän tasapainon välillä muistin käyttö ja suorituskyky, joka on enemmän kuin tarpeeksi vain muutamia botteja, kuten yleensä yksi samanaikainen taustan GC lanka on tarpeeksi nopea käsitellä koko muistia jaetun ASF.

Tänään meillä on kuitenkin paljon CPU ydin, että ASF voi suuresti hyötyä, Ottaa oma GC lanka kutakin CPU vCore, joka on saatavilla. Tämä voi merkittävästi parantaa suorituskykyä raskaiden ASF tehtävien, kuten jäsennys merkit sivuja tai tavaraluettelo, koska jokainen CPU vCore voi auttaa, toisin kuin vain 2 (pää-ja GC). Server GC on suositeltavaa koneille 3 CPU vCores ja enemmän, työasema GC pakotetaan automaattisesti, jos koneessa on vain 1 CPU vCore, ja jos sinulla on täsmälleen 2 niin voit harkita yrittää molempia (tulokset voivat vaihdella).

Server GC itsessään ei johda kovin valtava muistin kasvu vain aktiivisena, mutta se on paljon suurempi sukupolvi koot, ja siksi on paljon laiska, kun se tulee antaa muisti takaisin OS. Saatat löytää itsesi makea paikka, jossa palvelin GC lisää suorituskykyä merkittävästi ja haluat jatkaa sen käyttöä, mutta samaan aikaan sinulla ei ole varaa että valtava muistin kasvu, joka tulee ulos käyttää sitä. Onneksi teille on olemassa "paras molemmista maailmoista" -asetus, Käyttämällä palvelinta GC kanssa **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** asetukset asetettu `0`, joka edelleen mahdollistaa palvelimen GC, mutta rajoittaa sukupolven koot ja keskittyä enemmän muistiin. Vaihtoehtoisesti voit myös kokeilla toista ominaisuutta, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**tai jopa molemmat samaan aikaan.

Kuitenkin, jos muisti ei ole ongelma sinulle (kuten GC vielä ottaa huomioon käytettävissä oleva muisti ja parantaa itse), se on paljon parempi idea olla muuttamatta näitä ominaisuuksia ollenkaan, saavuttaa ylivoimainen suorituskyky tulos.

---

Voit ottaa valitut ominaisuudet käyttöön asettamalla sopivia ympäristömuuttujia. Esimerkiksi Linuxissa (kuori):

```shell
vie DOTNET_gcServer=1

./ArchiSteamFarm # OS-spesifiselle rakentamiselle
./ArchiSteamFarm.sh # Yleiselle rakentamiselle
```

Tai Windowsissa (powershell):

```powershell
$Env:DOTNET_gcServer=1

.\ArchiSteamFarm.exe # OS-spesifiselle rakennukselle
.\ArchiSteamFarm.cmd # Yleiseen rakennukseen
```

---

## Suositeltu optimointi

- Varmista, että käytät oletusarvoa `optimointitila` , joka on `MaxPerformance`. Tämä on ylivoimaisesti tärkein asetus, sillä `MinMemoryUsage` -arvon käytöllä on dramaattinen vaikutus suorituskykyyn.
- Ota palvelin GC. käyttöön. Server GC voidaan heti nähdä aktiivisena merkittävä muistin kasvu verrattuna työasemien GC. Tämä luo GC-langan jokaiselle suorittimen lankalle koneellasi on jotta voit suorittaa GC-toimintoja samalla tavoin kuin suurin sallittu nopeus.
- Jos sinulla ei ole varaa lisätä muistia palvelimen GC, harkitse **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** ja/tai **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** saavuttaakseen "molempien maailman parhaat". Kuitenkin, jos muistisi on varaa, sitten se on parempi pitää se oletuksena - palvelin GC jo nipistää itsensä aikana ja on älykäs käyttää vähemmän muistia, kun OS todella tarvitsevat sitä.

Edellä esitettyjen suositusten soveltaminen avulla voit olla ylivoimainen ASF suorituskykyä, joka pitäisi olla kirkastaa nopeasti jopa satoja tai tuhansia käytössä robotteja. Suorittimen ei pitäisi olla enää pullonkaula, koska ASF pystyy käyttämään koko suorittimen virtaa tarvittaessa, katkaisemaan vaaditun ajan palaamaan minimiin. Seuraava vaihe olisi CPU- ja RAM-päivitykset tai jakamalla työtaakka useisiin palvelimiin ja ASF-kohteisiin.