# Arka Planda Oyun Etkinleştirme

Arka Planda Oyun Etkinleştirme (BGR), belirlediğiniz Steam ürün anahtarlarını (oyun adlarıyla birlikte) arka planda otomatik olarak etkinleştirmek üzere içe aktarmanızı sağlayan, ASF'ye yerleşik özel bir özelliktir. Bu özellikle, çok sayıda anahtarınız varsa ve tüm toplu işleminiz tamamlanmadan önce `RateLimited` **[durumunu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)** ulaşmayı garantilediyseniz kullanışlıdır.

Arkaplan oyunları kurtarıcısı, tek bir bot alanına sahip olacak şekilde yapılır, bu da `RedeemingPreferences`'dan yararlanmadığı anlamına gelir. Bu özellik, gerekirse, `redeem` **[komutu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** ile birlikte (veya bunun yerine) kullanılabilir.

---

## İçe Aktarma

İçe aktarma işlemi iki yolla yapılabilir - bir dosya kullanarak veya IPC kullanarak.

### Dosya

ASF, kendi `yapılandırma` dizininde `BotName.keys` adlı bir dosyayı, `BotName` botunuzun adı olduğunu görecektir. Bu dosya, her bir girdinin yeni bir satırla ayrıldığı ve oyun adı ile ürün anahtarının arasında bir sekme (tab) karakteri bulunan sabit bir yapıya sahiptir. Eğer bir satırda birden fazla sekme kullanılırsa, ilk metin oyun adı, son metin ise ürün anahtarı olarak kabul edilir ve aradaki her şey göz ardı edilir. Örneğin:

```text
POSTAL 2    ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria    ThisIsIgnored   ThisIsIgnoredToo    ZXCVB-ASDFG-QWERT
```

Alternatif olarak, yalnızca ürün anahtarlarını içeren bir format da kullanabilirsiniz (her anahtar yine yeni bir satırda olmalıdır). Bu durumda ASF, doğru ismi doldurmak için Steam'in yanıtını (mümkünse) kullanacaktır. Steam'de etkinleştirilen paketlerin, içerdikleri oyunların adlarıyla mantıksal bir bütünlük taşıması gerekmediğinden, anahtarlarınızı isimlendirmenizi öneririz. Geliştiricinin tanımladığı isme bağlı olarak doğru oyun adları, özel paket adları (ör. Humble Indie Bundle 18) ve hatta tamamen yanlış veya kötü niyetli adlar (ör. Half-Life 4) görebilirsiniz.

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Hangi biçime bağlı kalmaya karar vermiş olursanız olun, ASF, bot başlangıcında veya daha sonra yürütme sırasında `keys` dosyanızı içe aktarır. Dosyanız başarıyla çözümlendikten ve olası geçersiz girişler atlandıktan sonra, doğru şekilde algılanan tüm oyunlar arka plan sırasına eklenecek ve `BotName.keys` dosyası `config` dizininden kaldırılacaktır. If any invalid lines are found, they'll be written into `BotName.keys.invalid` file, in case you'd like to correct them and import again.

### IPC

Yukarıda belirtilen anahtar dosyasını kullanmaya ek olarak ASF, ASF-UI da dahil olmak üzere herhangi bir IPC aracı tarafından yürütülebilen `GamesToRedeemInBackground` **[ASF API uç noktasını](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-tr-TR#asf-api)** da sunar. IPC kullanmak daha esnek bir yöntem olabilir, çünkü sekme karakterine bağlı kalmak yerine özel bir ayırıcı kullanmak veya tamamen kendi özelleştirilmiş anahtar yapınızı oluşturmak gibi işlemleri kendiniz yapabilirsiniz.

---

## Kuyruk

Oyunlar başarıyla içe aktarıldığında, sıraya eklenirler. Bot, Steam ağına bağlı olduğu sürece ve kuyruk boş değilse ASF otomatik olarak arka plan kuyruğundan geçer. Etkinleştirme denemesi `RateLimited` ile sonuçlanmayan bir anahtar, durumuna göre ilgili dosyaya yazılarak işlem sırasından kaldırılır. Eğer anahtar işlem sırasında kullanıldıysa (örneğin `NoDetail`, `BadActivationCode` veya `DuplicateActivationCode` gibi durumlarda) `BotName.keys.used` dosyasına, diğer durumlarda ise `BotName.keys.unused` dosyasına kaydedilir. Steam ağından her zaman anlamlı bir oyun adı dönmeyebileceği için ASF, kasıtlı olarak sizin sağladığınız oyun adını kullanır. Bu sayede, gerekirse anahtarlarınızı özel adlarla etiketleyebilirsiniz.

İşlem sırasında hesabınız `RateLimited` durumuna takılırsa, bu bekleme süresinin geçmesi için işlem sırası bir saatliğine askıya alınır. Bu sürenin ardından, tüm sıra boşalana veya tekrar `RateLimited` durumuyla karşılaşılana kadar işlem kaldığı yerden devam eder.

---

## Örnek

100 anahtarlık bir listeniz olduğunu varsayalım. Öncelikle ASF'nin `config` dizininde `BotAdınız.keys.new` adında yeni bir dosya oluşturun. ASF'ye bu dosyayı oluşturulduğu anda almaması gerektiğini bildirmek için `.new` uzantısını ekledik (çünkü yeni boş dosya olduğundan, içe aktarmaya henüz hazır değil).

Şimdi bu yeni dosyayı açıp 100 anahtarlık listenizi içine yapıştırabilir ve gerekirse formatı düzeltebilirsiniz. Düzeltmelerden sonra `BotAdınız.keys.new` dosyanız tam olarak 100 satırdan (veya son satırda da enter varsa 101) oluşacaktır. Her satır `OyunAdı\tÜrünAnahtarı\n` yapısında olmalıdır. Burada `\t` sekme (tab) karakterini, `\n` ise yeni satırı temsil eder.

Artık dosyayı `BotAdınız.keys.new` adından `BotAdınız.keys` olarak yeniden adlandırarak ASF'ye işleme hazır olduğunu bildirebilirsiniz. Bu işlemi yaptığınız anda ASF, yeniden başlatmaya gerek kalmadan dosyayı otomatik olarak içe aktaracak ve ardından silerek tüm oyunların çözümlenip işlem sırasına eklendiğini onaylayacaktır.

`BotAdınız.keys` dosyasını kullanmak yerine IPC API uç noktasını da kullanabilir, hatta isterseniz ikisini birleştirebilirsiniz.

Bir süre sonra `BotAdınız.keys.used` (kullanılmış) ve `BotAdınız.keys.unused` (kullanılmamış) dosyaları oluşturulacaktır. Bu dosyalar, etkinleştirme sürecinin sonuçlarını içerir. Örneğin, `BotAdınız.keys.unused` dosyasını `Bot2Adı.keys` olarak yeniden adlandırabilir ve bu kullanılmamış anahtarları başka bir botunuz için işleme sokabilirsiniz. Veya kullanılmamış anahtarları başka bir dosyaya kopyalayıp daha sonra kullanmak üzere saklayabilirsiniz, tercih sizin. Unutmayın, ASF işlem sırasını yürüttükçe `used` ve `unused` dosyalarına yeni girişler eklenebilir. Bu nedenle, bu dosyaları kullanmadan önce işlem sırasının tamamen boşalmasını beklemeniz önerilir. Eğer işlem sırası tamamen boşalmadan bu dosyalara erişmeniz gerekiyorsa, önce erişmek istediğiniz çıktı dosyasını başka bir dizine **taşımalı**, **ardından** işlemelisiniz. Bunun nedeni, siz dosya üzerinde çalışırken ASF'nin yeni sonuçlar eklemeye devam edebilmesidir. Örneğin, içinde 3 anahtar olan bir dosyayı okuduktan sonra silerseniz, bu sırada ASF'nin sildiğiniz dosyaya 4 yeni anahtar daha eklediğini fark etmeyebilir ve veri kaybına neden olabilirsiniz. Bu dosyalara erişmek istiyorsanız, okumadan önce onları (örneğin yeniden adlandırarak) ASF'nin `config` dizininden taşıdığınızdan emin olun.

İşlem sırasında mevcut bir sıra varken bile yukarıdaki adımları tekrarlayarak içe aktarmak için yeni oyunlar ekleyebilirsiniz. ASF, bu yeni girişleri mevcut işlem sırasına düzgün bir şekilde ekleyecek ve zamanı geldiğinde onları da işleyecektir.

---

## Notlar

Arka Planda Oyun Etkinleştirme özelliği, altyapıda `OrderedDictionary` kullanır. Bu, ürün anahtarlarınızın dosyada (veya IPC API çağrısında) belirttiğiniz sırayla işleneceği anlamına gelir. Bu, bir ürün anahtarının yalnızca kendisinden önce listelenen anahtarlara bağımlı olabileceği (ancak sonrakilere olamayacağı) bir liste sağlamanız gerektiği anlamına gelir. Örneğin, etkinleştirilmesi için `G` oyununa ihtiyaç duyan bir `D` DLC'niz varsa, `G` oyununun ürün anahtarı **her zaman** `D` DLC'sinin ürün anahtarından önce listede yer almalıdır. Benzer şekilde, eğer `D` DLC'si `A`, `B` ve `C` oyunlarına bağımlıysa, bu üç oyunun anahtarı da (kendi aralarında bir bağımlılıkları yoksa herhangi bir sırada) `D` DLC'sinden önce gelmelidir.

Yukarıdaki sıralama şemasına uymazsanız, hesabınız tüm sırayı tamamladıktan sonra DLC'yi etkinleştirmeye uygun hale gelecek olsa bile, DLC'niz `DoesNotOwnRequiredApp` (Gerekli Oyuna Sahip Değil) hatasıyla etkinleştirilemeyecektir. Bu durumu önlemek için, DLC anahtarının her zaman ana oyundan sonra işlem sırasına eklendiğinden emin olmalısınız.