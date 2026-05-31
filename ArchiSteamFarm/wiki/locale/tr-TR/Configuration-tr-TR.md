# Yapılandırma

Bu sayfa ASF'nin yapılandırılmasına adanmıştır. `config` dizininin eksiksiz bir belgelendirmesi olarak hizmet eder ve ASF'yi ihtiyaçlarınıza göre ayarlamanıza olanak tanır.

* **[Giriş](#introduction)**
* **[Web Tabanlı Yapılandırma Oluşturucu](#web-based-configgenerator)**
* **[ASF-ui Yapılandırması](#asf-ui-configuration)**
* **[Manuel Yapılandırma](#manual-configuration)**
* **[Genel Yapılandırma](#global-config)**
* **[Bot Yapılandırması](#bot-config)**
* **[Dosya Yapısı](#file-structure)**
* **[JSON Eşlemesi](#json-mapping)**
* **[Uyumluluk Eşlemesi](#compatibility-mapping)**
* **[Yapılandırma Uyumluluğu](#configs-compatibility)**
* **[Otomatik Yeniden Yükleme](#auto-reload)**

---

## Giriş

ASF yapılandırması iki ana bölüme ayrılır: genel (süreç) yapılandırma ve her bir botun kendi yapılandırması. Her botun `BotAdı.json` adında kendi yapılandırma dosyası bulunurken (`BotAdı` sizin bota verdiğiniz addır), genel ASF (süreç) yapılandırması ise `ASF.json` adında tek bir dosyadır.

Bir "bot", ASF sürecinde yer alan tek bir Steam hesabını temsil eder. Düzgün çalışabilmesi için ASF'nin en az **bir adet** tanımlanmış bot örneğine ihtiyacı vardır. Süreç tarafından dayatılan bir bot örneği sınırı yoktur, bu nedenle istediğiniz kadar bot (Steam hesabı) kullanabilirsiniz.

ASF, yapılandırma dosyalarını saklamak için **[JSON](https://tr.wikipedia.org/wiki/JSON)** formatını kullanır. Bu, programı yapılandırabileceğiniz, insan dostu, okunabilir ve çok evrensel bir formattır. Ancak endişelenmeyin, ASF'yi yapılandırmak için JSON bilmenize gerek yok. Bunu, bir tür bash betiği ile toplu ASF yapılandırmaları oluşturmak istemeniz ihtimaline karşı belirttim.

Yapılandırma birkaç şekilde yapılabilir. ASF'den bağımsız yerel bir uygulama olan **[Web Tabanlı Yapılandırma Oluşturucumuzu](https://justarchinet.github.io/ASF-WebConfigGenerator)** kullanabilirsiniz. Doğrudan ASF içinde yapılandırma yapmak için **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-tr-TR#asf-ui)** IPC arayüzümüzü kullanabilirsiniz. Son olarak, aşağıda belirtilen sabit JSON yapısını takip ettikleri için yapılandırma dosyalarını her zaman manuel olarak da oluşturabilirsiniz. Mevcut seçenekleri kısaca açıklayacağız.

---

## Web Tabanlı Yapılandırma Oluşturucu

**[Web Tabanlı Yapılandırma Oluşturucumuzun](https://justarchinet.github.io/ASF-WebConfigGenerator)** amacı, size ASF yapılandırma dosyalarını oluşturmak için kullanılan kullanıcı dostu bir arayüz sağlamaktır. Web Tabanlı Yapılandırma Oluşturucu %100 istemci tabanlıdır, yani girdiğiniz ayrıntılar hiçbir yere gönderilmez, yalnızca yerel olarak işlenir. Bu, güvenlik ve güvenilirliği garanti eder; hatta tüm dosyaları indirip `index.html` dosyasını favori tarayıcınızda çalıştırırsanız **[çevrimdışı](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** bile çalışabilir.

Web Tabanlı Yapılandırma Oluşturucunun Chrome ve Firefox'ta düzgün çalıştığı doğrulanmıştır, ancak JavaScript destekli tüm popüler tarayıcılarda da düzgün çalışması beklenir.

Kullanımı oldukça basittir: Doğru sekmeye geçerek `ASF` veya `Bot` yapılandırması oluşturmayı seçin, seçilen yapılandırma dosyası sürümünün ASF sürümünüzle eşleştiğinden emin olun, ardından tüm ayrıntıları girin ve "indir" düğmesine basın. Bu dosyayı ASF'nin `config` dizinine taşıyın ve gerekirse mevcut dosyaların üzerine yazın. Gelecekteki tüm olası değişiklikler için bu işlemi tekrarlayın ve mevcut tüm yapılandırma seçeneklerinin açıklaması için bu bölümün geri kalanına başvurun.

---

## ASF-ui Yapılandırması

**[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-tr-TR#asf-ui)** IPC arayüzümüz de ASF'yi yapılandırmanıza olanak tanır. Dosyaları statik olarak oluşturan Web Tabanlı Yapılandırma Oluşturucunun aksine, yapılandırmaları doğrudan yerinde düzenleyebildiği için ilk yapılandırmaları oluşturduktan sonra yeniden yapılandırma yapmak için daha üstün bir çözümdür.

ASF-ui'yi kullanmak için **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-tr-TR)** arayüzümüzün etkinleştirilmiş olması gerekir. `IPC` varsayılan olarak etkindir, bu nedenle kendiniz devre dışı bırakmadığınız sürece hemen erişebilirsiniz.

Programı başlattıktan sonra, ASF'nin **[IPC adresine](http://localhost:1242)** gidin. Her şey düzgün çalışıyorsa, ASF yapılandırmasını oradan da değiştirebilirsiniz.

---

## Manuel Yapılandırma

Genel olarak, hem Yapılandırma Oluşturucumuzu hem de ASF-ui'yi kullanmanızı şiddetle tavsiye ederiz, çünkü bu çok daha kolaydır ve JSON yapısında bir hata yapmamanızı sağlar. Ancak herhangi bir nedenle istemiyorsanız, uygun yapılandırmaları manuel olarak da oluşturabilirsiniz. Doğru bir yapı için iyi bir başlangıç olarak aşağıdaki JSON örneklerini inceleyin; içeriği bir dosyaya kopyalayabilir ve yapılandırmanız için bir temel olarak kullanabilirsiniz. Arayüzlerimizden herhangi birini kullanmadığınız için, yapılandırmanızın **[geçerli bir JSON](https://jsonlint.com)** olduğundan emin olun, çünkü ASF ayrıştırılamazsa yüklemeyi reddedecektir. Geçerli bir JSON olsa bile, tüm özelliklerin ASF'nin gerektirdiği doğru türde olduğundan da emin olmalısınız. Mevcut tüm alanların doğru JSON yapısı için, **[JSON Eşlemesi](#json-eslemesi)** bölümüne ve aşağıdaki belgelerimize bakın.

---

## Genel Yapılandırma

Genel yapılandırma, `ASF.json` dosyasında bulunur ve aşağıdaki yapıya sahiptir:

```json
{
    "AutoRestart": true,
    "Blacklist": [],
    "CommandPrefix": "!",
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "CurrentCulture": null,
    "Debug": false,
    "DefaultBot": null,
    "FarmingDelay": 15,
    "FilterBadBots": true,
    "GiftsLimiterDelay": 1,
    "Headless": false,
    "IdleFarmingPeriod": 8,
    "InventoryLimiterDelay": 4,
    "IPC": true,
    "IPCPassword": null,
    "IPCPasswordFormat": 0,
    "LicenseID": null,
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldDuration": 15,
    "MinFarmingDelayAfterBlock": 60,
    "OptimizationMode": 0,
    "PluginsUpdateList": [],
    "PluginsUpdateMode": 0,
    "ShutdownIfPossible": false,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Tüm seçenekler aşağıda açıklanmıştır:

### `AutoRestart`

Varsayılan değeri `true` olan `bool` türü. Bu özellik, ASF'nin gerektiğinde kendi kendini yeniden başlatmasına izin verilip verilmediğini tanımlar. ASF güncellemesi (`UpdatePeriod` veya `update` komutuyla yapılır), `ASF.json` yapılandırma dosyasının düzenlenmesi, `restart` komutu ve benzeri gibi ASF'nin kendi kendini yeniden başlatmasını gerektiren birkaç durum vardır. Yeniden başlatma genellikle iki bölümden oluşur: yeni bir süreç oluşturmak ve mevcut olanı sonlandırmak. Çoğu kullanıcı için varsayılan `true` değeri uygundur. Ancak, ASF'yi kendi betiğinizle ve/veya `dotnet` ile çalıştırıyorsanız, süreci başlatma üzerinde tam kontrole sahip olmak isteyebilir ve eski ASF süreciyle birlikte sonlanan betiğinizin ön planında değil de, arka planda sessizce çalışan yeni (yeniden başlatılmış) bir ASF sürecine sahip olma durumundan kaçınmak isteyebilirsiniz. Bu durum, yeni sürecin artık doğrudan sizin alt süreciniz olmayacağı ve bu nedenle örneğin standart konsol girişini onun için kullanamayacağınız gerçeği göz önüne alındığında özellikle önemlidir.

Eğer durum buysa, bu özellik tam size göredir ve `false` olarak ayarlayabilirsiniz. Ancak, bu durumda süreci yeniden başlatmaktan **sizin** sorumlu olduğunuzu unutmayın. Bu önemlidir, çünkü ASF yeni bir süreç oluşturmak yerine (örneğin bir güncellemeden sonra) yalnızca çıkış yapacaktır. Dolayısıyla, sizin tarafınızdan eklenmiş bir mantık yoksa, siz tekrar başlatana kadar çalışmayı durduracaktır. ASF her zaman başarıyı (sıfır) veya başarısızlığı (sıfır olmayan) belirten uygun bir hata koduyla çıkar. Bu sayede, betiğinize bir hata durumunda ASF'nin otomatik olarak yeniden başlatılmasını önleyecek veya en azından daha sonra analiz etmek için `log.txt` dosyasının yerel bir kopyasını alacak uygun mantığı ekleyebilirsiniz. Ayrıca, `restart` komutunun, bu özelliğin nasıl ayarlandığına bakılmaksızın ASF'yi her zaman yeniden başlatacağını unutmayın. Çünkü bu özellik varsayılan davranışı tanımlarken, `restart` komutu her zaman süreci yeniden başlatır. Bu özelliği devre dışı bırakmak için özel bir nedeniniz yoksa, etkin bırakmalısınız.

---

### `Blacklist`

Varsayılan değeri boş olan `ImmutableHashSet<uint>` türü. Adından da anlaşılacağı gibi, bu genel yapılandırma özelliği, otomatik ASF kart düşürme süreci tarafından tamamen göz ardı edilecek appID'leri (oyunları) tanımlar. Ne yazık ki Steam, yaz/kış indirim rozetlerini "kart düşürmeye uygun" olarak işaretlemeyi seviyor. Bu durum, ASF'nin bunları kart düşürülmesi gereken geçerli bir oyun olduğuna inanmasına neden olarak süreci karıştırıyor. Herhangi bir kara liste olmasaydı, ASF en sonunda aslında bir oyun olmayan bir şeyi düşürmeye çalışırken "takılıp kalır" ve asla gerçekleşmeyecek kart düşüşünü sonsuza kadar beklerdi. ASF kara listesi, bu rozetleri kart düşürmeye uygun değil olarak işaretleme amacına hizmet eder. Bu sayede, neyin düşürüleceğine karar verirken bunları sessizce görmezden gelebilir ve tuzağa düşmeyiz.

ASF, varsayılan olarak iki kara liste içerir: biri ASF koduna sabit olarak eklenmiş ve düzenlenmesi mümkün olmayan `SalesBlacklist`, diğeri ise burada tanımlanan normal `Blacklist`. `SalesBlacklist`, ASF sürümüyle birlikte güncellenir ve genellikle sürüm anındaki tüm "hatalı" appID'leri içerir. Bu nedenle, güncel bir ASF sürümü kullanıyorsanız, burada tanımlanan kendi `Blacklist` listenizi tutmanıza gerek yoktur. Bu özelliğin temel amacı, ASF sürümü yayınlandığı sırada bilinmeyen ve kart düşürülmemesi gereken yeni appID'leri kara listeye almanıza olanak tanımaktır. Sabit kodlanmış `SalesBlacklist` mümkün olan en hızlı şekilde güncellenir. Bu nedenle, en son ASF sürümünü kullanıyorsanız kendi `Blacklist` listenizi güncellemeniz gerekmez. Ancak `Blacklist` özelliği olmasaydı, Valve yeni bir indirim rozeti yayınladığında ASF'yi "çalışır durumda tutmak" için güncellemek zorunda kalırdınız. Sizi en son ASF kodunu kullanmaya zorlamak istemiyoruz, bu nedenle bu özellik, bir nedenle yeni ASF sürümündeki yeni sabit kodlanmış `SalesBlacklist` listesine güncelleme yapmak istemiyorsanız veya yapamıyorsanız, ancak eski ASF'nizi çalıştırmaya devam etmek istiyorsanız, ASF'yi "düzeltmenize" olanak tanır. Bu özelliği düzenlemek için **geçerli** bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

Eğer bota özel bir kara liste arıyorsanız, `fb`, `fbadd` ve `fbrm` **[komutlarına](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-tr-TR)** göz atın.

---

### `CommandPrefix`

Varsayılan değeri `!` olan `string` (metin) türü. Bu özellik, ASF **[komutları](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-tr-TR)** için kullanılan ve **büyük/küçük harfe duyarlı** olan ön eki belirtir. Başka bir deyişle, ASF'nin sizi dinlemesi için her ASF komutunun başına bu ön eki eklemeniz gerekir. ASF'nin komut ön eki kullanmamasını sağlamak için bu değeri `null` veya boş olarak ayarlayabilirsiniz; bu durumda komutları yalın halleriyle girersiniz. Ancak bunu yapmak ASF'nin performansını düşürebilir, çünkü ASF bir mesaj `CommandPrefix` ile başlamıyorsa o mesajı daha fazla ayrıştırmamak üzere optimize edilmiştir. Eğer ön ek kullanmamayı seçerseniz, ASF, ASF komutu olmasalar bile tüm mesajları okumak ve yanıtlamaya çalışmak zorunda kalır. Bu nedenle, varsayılan `!` değerini beğenmiyorsanız bile, `/` gibi bir `CommandPrefix` kullanmaya devam etmeniz önerilir. Tutarlılık açısından, `CommandPrefix` tüm ASF sürecini etkiler. Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `ConfirmationsLimiterDelay`

Varsayılan değeri `10` olan `byte` türü. ASF, istek sınırına takılmamak için iki ardışık 2FA onayı getirme isteği arasında en az `ConfirmationsLimiterDelay` saniye olmasını sağlar. Bu gecikme, `2faok` komutu gibi durumlarda **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-tr-TR)** tarafından ve ayrıca çeşitli takas işlemleri sırasında gerektiğinde kullanılır. Varsayılan değer testlerimize göre ayarlanmıştır ve sorun yaşamak istemiyorsanız düşürülmemelidir. Bu özelliği düzenlemek için **geçerli** bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `ConnectionTimeout`

Varsayılan değeri `90` olan `byte` türü. Bu özellik, ASF tarafından yapılan çeşitli ağ eylemleri için zaman aşımlarını saniye cinsinden tanımlar. Özellikle, `ConnectionTimeout` HTTP ve IPC istekleri için saniye cinsinden zaman aşımını tanımlar; `ConnectionTimeout / 10` başarısız "heartbeat" (sinyal) sayısını tanımlarken, `ConnectionTimeout / 30` ise ilk Steam ağı bağlantı isteği için izin verilen dakika sayısını tanımlar. Varsayılan `90` değeri çoğu kişi için yeterli olacaktır. Ancak, yavaş bir ağ bağlantınız veya bilgisayarınız varsa, bu sayıyı daha yüksek bir değere (örneğin `120`) çıkarmak isteyebilirsiniz. Daha büyük değerlerin yavaş veya erişilemeyen Steam sunucularını sihirli bir şekilde düzeltmeyeceğini unutmayın, bu yüzden olmayacak bir şey için sonsuza kadar beklemek yerine daha sonra tekrar denemek daha mantıklıdır. Bu değeri çok yüksek ayarlamak, ağ sorunlarını yakalamada aşırı gecikmeye ve genel performansta düşüşe neden olur. Bu değeri çok düşük ayarlamak da genel kararlılığı ve performansı düşürür, çünkü ASF hala işlenmekte olan geçerli bir isteği iptal edebilir. Bu nedenle, Steam sunucuları zaman zaman aşırı yavaş olabildiğinden ve ASF isteklerini işlemek için daha fazla zamana ihtiyaç duyabildiğinden, bu değeri varsayılanın altına düşürmenin genellikle bir avantajı yoktur. Varsayılan değer, ağ bağlantımızın kararlı olduğuna inanmak ile Steam ağının isteğimizi belirli bir zaman aşımı içinde işleyebileceğinden şüphe duymak arasındaki bir dengedir. Sorunları daha erken tespit etmek ve ASF'nin daha hızlı yeniden bağlanmasını/yanıt vermesini sağlamak istiyorsanız, varsayılan değer (veya ASF'yi daha az sabırlı hale getirecek şekilde `60` gibi biraz daha düşük bir değer) işinizi görecektir. Bunun yerine, ASF'nin başarısız istekler, kaybolan sinyaller veya Steam bağlantısının kesilmesi gibi ağ sorunları yaşadığını fark ederseniz ve bunun **sizin ağınızdan değil** de bizzat Steam'den kaynaklandığından eminseniz, bu değeri artırmak mantıklı olabilir. Zaman aşımlarını artırmak, ASF'yi daha "sabırlı" yapar ve hemen yeniden bağlanma kararı almasını engeller.

Bu özelliğin artırılmasını gerektirebilecek bir örnek durum, Steam tarafından tam olarak kabul edilip işlenmesi 2 dakikadan fazla sürebilen çok büyük takas teklifleriyle ASF'nin başa çıkmasına izin vermektir. Varsayılan zaman aşımını artırarak, ASF daha sabırlı olacak ve takasın gerçekleşmediğine karar verip ilk isteği iptal etmeden önce daha uzun süre bekleyecektir.

Başka bir durum, iletilen verileri işlemek için daha fazla zamana ihtiyaç duyan çok yavaş bir makine veya internet bağlantısından kaynaklanabilir. İşlemci/ağ bant genişliği neredeyse hiçbir zaman bir darboğaz olmadığından bu oldukça nadir bir durumdur, ancak yine de bahsetmeye değer bir olasılıktır.

Kısacası, varsayılan değer çoğu durum için yeterli olmalıdır, ancak gerekirse artırmak isteyebilirsiniz. Yine de, varsayılan değerin çok üzerine çıkmanın da pek bir anlamı yoktur, çünkü daha uzun zaman aşımları erişilemeyen Steam sunucularını sihirli bir şekilde düzeltmeyecektir. Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `CurrentCulture`

Varsayılan değeri `null` olan `string` (metin) türü. Varsayılan olarak ASF, işletim sisteminizin dilini kullanmaya çalışır ve mevcutsa o dildeki çevrilmiş metinleri kullanmayı tercih eder. Bu, ASF'yi en popüler tüm dillerde **[yerelleştirmeye](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization-tr-TR)** çalışan topluluğumuz sayesinde mümkündür. Herhangi bir nedenle işletim sisteminizin yerel dilini kullanmak istemiyorsanız, bu yapılandırma özelliğini kullanarak bunun yerine kullanmak istediğiniz geçerli bir dili seçebilirsiniz. Mevcut tüm kültürlerin bir listesi için lütfen **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** sayfasını ziyaret edin ve `Language tag` (Dil etiketi) bölümüne bakın. ASF'nin hem `"en-GB"` gibi belirli kültürleri hem de `"en"` gibi nötr olanları kabul ettiğini belirtmekte fayda var. Geçerli kültürü belirtmek, para birimi/tarih formatı ve benzeri gibi diğer kültüre özgü davranışları da etkileyecektir. Eğer yerel diliniz olmayan ve özel karakterler kullanan bir dil seçtiyseniz, bu karakterlerin doğru görüntülenmesi için ek yazı tipi/dil paketleri gerekebileceğini lütfen unutmayın. Genellikle bu yapılandırma özelliğini, ASF'yi ana diliniz yerine İngilizce olarak kullanmayı tercih ediyorsanız kullanmak istersiniz.

---

### `Debug (Hata Ayıklama)`

Varsayılan değeri `false` olan `bool` türü. Bu özellik, sürecin hata ayıklama modunda çalışıp çalışmayacağını tanımlar. Hata ayıklama modundayken ASF, `config` dizininin yanına, ASF ile Steam sunucuları arasındaki tüm iletişimin kaydını tutan özel bir `debug` dizini oluşturur. Hata ayıklama bilgileri, ağ iletişimi ve genel ASF iş akışıyla ilgili can sıkıcı sorunları tespit etmeye yardımcı olabilir. Buna ek olarak, bazı program rutinleri çok daha ayrıntılı olacaktır; örneğin `WebBrowser`, bazı isteklerin neden başarısız olduğunun kesin nedenini belirtir. Bu girişler normal ASF kayıt dosyasına yazılır. **Geliştirici tarafından istenmedikçe ASF'yi Hata Ayıklama modunda çalıştırmamalısınız**. ASF'yi hata ayıklama modunda çalıştırmak **performansı düşürür**, **kararlılığı olumsuz etkiler** ve **çeşitli yerlerde çok daha fazla kayıt üretir**. Bu nedenle, **yalnızca** belirli bir sorunun hatalarını ayıklamak, problemi yeniden oluşturmak veya başarısız bir istek hakkında daha fazla bilgi almak gibi amaçlarla, kasıtlı olarak ve kısa süreliğine kullanılmalıdır; normal program çalışması için **kullanılmamalıdır**. **Çok sayıda** yeni hata, sorun ve istisna göreceksiniz. Her şeyin bir sorun teşkil etmediğini ve tüm bunları kendiniz analiz etmeye karar verirseniz ASF, Steam ve tuhaflıkları hakkında yeterli bilgiye sahip olduğunuzdan emin olun.

**UYARI:** Bu modu etkinleştirmek, Steam'e giriş yapmak için kullandığınız kullanıcı adları ve parolalar gibi **potansiyel olarak hassas** bilgilerin (ağ kaydı nedeniyle) günlüğe kaydedilmesini içerir. Bu veriler hem `debug` dizinine hem de standart `log.txt` dosyasına yazılır (bu dosya artık bu bilgileri kaydetmek için kasıtlı olarak çok daha ayrıntılıdır). ASF tarafından oluşturulan hata ayıklama içeriğini herkese açık bir yerde yayınlamamalısınız. Bir ASF geliştiricisi size her zaman bu dosyayı e-posta adresine veya başka bir güvenli konuma göndermenizi hatırlatacaktır. Bu hassas bilgileri saklamıyoruz veya kullanmıyoruz; sizi etkileyen sorunla ilgili olabileceğinden, hata ayıklama rutinlerinin bir parçası olarak yazılıyorlar. ASF kayıtlarını hiçbir şekilde değiştirmenizi önermesek de, endişeleniyorsanız bu hassas bilgileri uygun şekilde redakte etmekte (karartmakta) özgürsünüz.

> Redakte etmek, hassas bilgileri, örneğin yıldız işaretleri ile değiştirmeyi içerir. Hassas satırları tamamen kaldırmaktan kaçınmalısınız, çünkü salt varlıkları bile konuyla ilgili olabilir ve korunmalıdır.

---

### `DefaultBot`

Varsayılan değeri `null` olan `string` (metin) türü. Bazı senaryolarda ASF, bir şeyi işlemekten sorumlu bir varsayılan bot kavramıyla çalışır - örneğin, hedef botu belirtmediğinizde IPC komutları veya etkileşimli konsol gibi. Bu özellik, bu tür senaryoları işlemekten sorumlu olacak varsayılan botu, `BotAdı`'nı buraya yazarak seçmenize olanak tanır. Eğer belirtilen bot mevcut değilse veya varsayılan `null` değerini kullanırsanız, ASF bunun yerine alfabetik olarak sıralanmış ilk kayıtlı botu seçecektir. Genellikle bu yapılandırma özelliğini, IPC ve etkileşimli konsol komutlarında `[Bots]` argümanını atlamak ve bu tür çağrılar için her zaman aynı botu varsayılan olarak seçmek istiyorsanız kullanırsınız.

---

### `FarmingDelay`

Varsayılan değeri `15` olan `byte` türü. ASF'nin çalışması için, o an düşürülmekte olan oyunun tüm kartlarının düşüp düşmediğini her `FarmingDelay` dakikada bir kontrol eder. Bu özelliği çok düşük ayarlamak aşırı miktarda Steam isteği gönderilmesine neden olabilirken, çok yüksek ayarlamak ise kartları tamamen düşürülmüş bir oyunu ASF'nin `FarmingDelay` dakikaya kadar "düşürmeye" devam etmesine neden olabilir. Varsayılan değer çoğu kullanıcı için mükemmeldir, ancak çok sayıda bot çalıştırıyorsanız, gönderilen Steam isteklerini sınırlamak için bu değeri `30` dakika gibi bir değere yükseltmeyi düşünebilirsiniz. ASF'nin olay tabanlı bir mekanizma kullandığını ve her Steam eşyası düştüğünde oyun rozeti sayfasını kontrol ettiğini belirtmekte fayda var. Bu nedenle genel olarak **sabit zaman aralıklarıyla kontrol etmemize bile gerek yoktur**. Ancak Steam ağına tam olarak güvenmediğimiz için, son `FarmingDelay` dakikası içinde bir kart düşüşü olayıyla kontrol etmediysek (örneğin Steam ağı bize eşya düşüşü hakkında bilgi vermediyse), oyun rozeti sayfasını yine de kontrol ederiz. Steam ağının düzgün çalıştığını varsayarsak, bu değeri düşürmek **kart düşürme verimliliğini hiçbir şekilde artırmazken**, **ağ yükünü önemli ölçüde artıracaktır**. Bu nedenle, yalnızca varsayılan `15` dakikadan (gerekirse) daha yükseğe ayarlanması tavsiye edilir. Bu özelliği düzenlemek için **geçerli** bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `FilterBadBots`

Varsayılan değeri `true` olan `bool` türü. Bu özellik, ASF'nin bilinen ve kötü niyetli olarak işaretlenmiş kullanıcılardan gelen takas tekliflerini otomatik olarak reddedip reddetmeyeceğini tanımlar. Bunu yapmak için ASF, kara listeye alınmış Steam kimliklerinin bir listesini almak üzere gerektiğinde sunucumuzla iletişim kuracaktır. Listelenen botlar, **[davranış kurallarımızı](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)** ihlal eden, **[`PublicListing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-tr-TR#publiclisting)** gibi sağladığımız işlevselliği ve kaynakları diğer insanları kötüye kullanmak ve sömürmek için kullanan veya sunucuya DDoS saldırıları düzenlemek gibi açıkça suç teşkil eden faaliyetlerde bulunanlar gibi, tarafımızca ASF girişimine karşı zararlı olarak sınıflandırılan kişiler tarafından işletilmektedir. ASF, tüm topluluğun gelişmesi için kullanıcıları arasında genel adalet, dürüstlük ve işbirliği konusunda güçlü bir duruşa sahip olduğundan, bu özellik varsayılan olarak etkindir ve bu nedenle ASF, sunduğu hizmetlerden zararlı olarak sınıflandırdığımız botları filtreler. Açıklamamızla aynı fikirde olmamak ve bu botların (hesaplarınızı sömürmek dahil) çalışmasına kasıtlı olarak izin vermek gibi **geçerli** bir nedeniniz olmadıkça, bu özelliği varsayılan ayarında bırakmalısınız.

---

### `GiftsLimiterDelay`

Varsayılan değeri `1` olan `byte` türü. ASF, istek sınırına takılmamak için iki ardışık hediye/anahtar/lisans işleme (etkinleştirme) isteği arasında en az `GiftsLimiterDelay` saniye olmasını sağlar. Buna ek olarak, `owns` **[komutu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-tr-TR)** tarafından yapılanlar gibi oyun listesi istekleri için de genel bir sınırlayıcı olarak kullanılır. Bu özelliği düzenlemek için **geçerli** bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `Headless`

Varsayılan değeri `false` olan `bool` türü. Bu özellik, sürecin arayüzsüz (headless) modda çalışıp çalışmayacağını tanımlar. Arayüzsüz modda ASF, bir sunucuda veya diğer etkileşimli olmayan ortamlarda çalıştığını varsayar, bu nedenle konsol girişi yoluyla herhangi bir bilgi okumaya çalışmaz. Bu, anlık olarak istenen ayrıntıları (2FA kodu, Steam Guard kodu, parola veya ASF'nin çalışması için gereken diğer değişkenler gibi hesap kimlik bilgileri) ve diğer tüm konsol girişlerini (etkileşimli komut konsolu gibi) içerir. Başka bir deyişle, `Headless` modu, ASF konsolunu salt okunur yapmakla eşdeğerdir. Bu ayar, özellikle sunucularda ASF çalıştıran kullanıcılar için kullanışlıdır, çünkü ASF örneğin 2FA kodu istemek yerine, hesabı durdurarak işlemi sessizce iptal eder. ASF'yi bir sunucuda çalıştırmıyorsanız ve daha önce ASF'nin arayüzlü modda çalışabildiğini onayladıysanız, bu özelliği devre dışı bırakmalısınız. Arayüzsüz modda herhangi bir kullanıcı etkileşimi reddedilir ve hesaplarınız başlangıç sırasında **herhangi bir** konsol girdisi gerektiriyorsa çalışmaz. Bu, sunucular için kullanışlıdır, çünkü ASF, kimlik bilgileri istendiğinde kullanıcının bunları (sonsuza kadar) sağlamasını beklemek yerine hesaba giriş yapma denemesini iptal edebilir.

Bu modu etkinleştirmek, gerekli konsol girdisini başka yollarla sağlamanıza olanak tanır, yani: ASF-ui (ASF API) veya **[`input`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-tr-TR#input-komutu)** komutu aracılığıyla. Bu özelliği nasıl ayarlayacağınızdan emin değilseniz, varsayılan `false` değeriyle bırakın.

---

### `IdleFarmingPeriod`

Varsayılan değeri `8` olan `byte` türü. ASF'nin düşürecek bir şeyi olmadığında, hesabın belki de kart düşürülecek yeni oyunlar alıp almadığını her `IdleFarmingPeriod` saatte bir periyodik olarak kontrol eder. Yeni aldığımız oyunlar söz konusu olduğunda bu özelliğe gerek yoktur, çünkü ASF bu durumda rozet sayfalarını otomatik olarak kontrol edecek kadar akıllıdır. `IdleFarmingPeriod` temel olarak, zaten sahip olduğumuz eski oyunlara sonradan koleksiyon kartı eklenmesi gibi durumlar içindir. Bu durumda bir olay tetiklenmediği için, bu durumu kapsamak istiyorsak ASF'nin rozet sayfalarını periyodik olarak kontrol etmesi gerekir. `0` değeri bu özelliği devre dışı bırakır. Ayrıca bakınız: `FarmingPreferences` içindeki `ShutdownOnFarmingFinished` tercihi.

---

### `InventoryLimiterDelay`

Varsayılan değeri `4` olan `byte` türü. ASF, istek sınırına takılmamak için iki ardışık web envanteri isteği arasında en az `InventoryLimiterDelay` saniye olmasını sağlar. Bu istekler örneğin envanter bildirimlerini okundu olarak işaretlerken kullanılır ve ayrıca üçüncü taraf eklentiler tarafından diğer kullanıcıların envanterlerini getirmek için de kullanılabilir. Bu özellik kendi envanterimizi getirmek için kullanılmaz, çünkü ASF bunun için çok daha verimli bir dahili ağ çağrısı kullanır. Dolayısıyla `loot` veya `transfer` gibi komutları hiçbir şekilde etkilemez. Varsayılan `4` değeri, 100'den fazla ardışık bot örneğinin envanterlerini işaretlemeye dayanarak ayarlanmıştır ve çoğu (hepsi olmasa da) kullanıcıyı tatmin etmelidir. Ancak, çok az sayıda botunuz varsa bunu azaltmak, hatta `0` olarak değiştirmek isteyebilirsiniz. Böylece ASF gecikmeyi yok sayar ve Steam envanterlerini çok daha hızlı işaretler. Ancak dikkatli olun, çünkü bu değeri çok düşürmek, Steam'in IP'nizi geçici olarak yasaklamasıyla sonuçlanacaktır ve bu durum herhangi bir çağrı yapmanızı tamamen engeller. Çok sayıda envanter isteği olan çok sayıda bot çalıştırıyorsanız bu değeri artırmanız gerekebilir, ancak bu durumda muhtemelen öncelikle bu isteklerin sayısını sınırlamaya çalışmalısınız. Bu özelliği düzenlemek için **geçerli** bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `IPC`

Varsayılan değeri `true` olan `bool` türü. Bu özellik, ASF'nin **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-tr-TR)** sunucusunun süreçle birlikte başlayıp başlamayacağını tanımlar. IPC, yerel bir HTTP sunucusu başlatarak **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-tr-TR#asf-ui)** kullanımı da dahil olmak üzere süreçler arası iletişime olanak tanır. ASF-ui de dahil olmak üzere ASF ile herhangi bir üçüncü taraf IPC entegrasyonu kullanmayı düşünmüyorsanız, bu seçeneği güvenle devre dışı bırakabilirsiniz. Aksi takdirde, etkin tutmak iyi bir fikirdir (varsayılan seçenek).

---

### `IPCPassword`

Varsayılan değeri `null` olan `string` (metin) türü. Bu özellik, IPC aracılığıyla yapılan her API çağrısı için zorunlu bir parola tanımlar ve ek bir güvenlik önlemi olarak hizmet eder. Boş olmayan bir değere ayarlandığında, tüm IPC istekleri burada belirtilen parolaya ayarlanmış ek bir `password` özelliği gerektirir. Varsayılan `null` değeri parola gerekliliğini atlayarak ASF'nin tüm sorguları dikkate almasını sağlar. Buna ek olarak, bu seçeneği etkinleştirmek, çok kısa sürede çok fazla yetkisiz istek gönderdikten sonra belirli bir `IPAddress` (IP Adresi) adresini geçici olarak yasaklayacak olan yerleşik IPC kaba kuvvet saldırısı (anti-bruteforce) mekanizmasını da etkinleştirir. Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `IPCPasswordFormat`

Varsayılan değeri `0` olan `byte` türü. Bu özellik, `IPCPassword` özelliğinin biçimini tanımlar ve temel tür olarak `EHashingMethod` kullanır. Daha fazla bilgi edinmek isterseniz lütfen **[Güvenlik](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-tr-TR)** bölümüne bakın, çünkü `IPCPassword` özelliğinin, belirlediğiniz `IPCPasswordFormat` ile eşleşen biçimde bir parola içerdiğinden emin olmanız gerekecektir. Başka bir deyişle, `IPCPasswordFormat` değerini değiştirdiğinizde, `IPCPassword` değeriniz de **zaten** o formatta olmalıdır. Ne yaptığınızı bilmiyorsanız, varsayılan `0` değeriyle bırakmalısınız.

---

### `LicenseID`

Varsayılan değeri `null` olan `Guid?` türü. Bu özellik, **[sponsorlarımızın](https://github.com/sponsors/JustArchi)** ASF'yi, çalışması için ücretli kaynaklar gerektiren isteğe bağlı özelliklerle geliştirmesine olanak tanır. Şimdilik bu, `ItemsMatcher` eklentisindeki **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-tr-TR#matchactively)** özelliğini kullanmanıza olanak tanır.

Aylık ve tek seferlik katmanlar sunması, tam otomasyona izin vermesi ve anında erişim sağlaması nedeniyle GitHub'ı kullanmanızı tavsiye etsek de, mevcut diğer tüm **[bağış seçeneklerini](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)** de **destekliyoruz**. Belirli bir süre için geçerli manuel bir lisans almak amacıyla diğer yöntemleri kullanarak nasıl bağış yapılacağına ilişkin talimatlar için **[bu gönderiye](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** bakın.

Kullanılan yöntemden bağımsız olarak, eğer bir ASF sponsoruysanız lisansınızı **[buradan](https://asf.justarchi.net/User/Status)** alabilirsiniz. Kimliğinizi doğrulamak için GitHub ile oturum açmanız gerekecektir. Yalnızca salt okunur herkese açık bilginiz olan kullanıcı adınızı istiyoruz. `LicenseID`, `f6a0529813f74d119982eb4fe43a9a24` gibi 32 onaltılık karakterden oluşur.

**`LicenseID`'nizi başkalarıyla paylaşmadığınızdan emin olun**. Kişisel olarak verildiği için, sızdırılması durumunda iptal edilebilir. Eğer bu durum yanlışlıkla başınıza geldiyse, aynı yerden yeni bir tane oluşturabilirsiniz.

Unless you want to enable extra ASF functionalities, there is no need to obtain/provide the license.

---

### `LoginLimiterDelay`

Varsayılan değeri `10` olan `byte` türü. ASF, istek sınırına takılmamak için iki ardışık bağlantı denemesi arasında en az `LoginLimiterDelay` saniye olmasını sağlar. Varsayılan `10` değeri, 100'den fazla bot örneğinin bağlanmasına dayanarak ayarlanmıştır ve çoğu (hepsi olmasa da) kullanıcıyı tatmin etmelidir. Ancak, çok az sayıda botunuz varsa bunu artırmak/azaltmak, hatta `0` olarak değiştirmek isteyebilirsiniz. Böylece ASF gecikmeyi yok sayar ve Steam'e çok daha hızlı bağlanır. Ancak dikkatli olun, çok fazla botunuz varken bu değeri çok düşürmek, Steam'in IP'nizi geçici olarak yasaklamasıyla sonuçlanacaktır ve bu durum, `InvalidPassword/RateLimitExceeded` hatasıyla birlikte **hiçbir şekilde** oturum açmanızı engeller - bu durum sadece ASF'yi değil, normal Steam istemcinizi de kapsar. Aynı şekilde, aşırı sayıda bot çalıştırıyorsanız (özellikle aynı IP adresini kullanan diğer Steam istemcileri/araçlarıyla birlikte), girişleri daha uzun bir zaman dilimine yaymak için büyük olasılıkla bu değeri artırmanız gerekecektir.

Ek bir not olarak, bu değer aynı zamanda `SendTradePeriod` içindeki takaslar gibi tüm ASF tarafından zamanlanmış eylemlerde bir yük dengeleme tamponu olarak da kullanılır. Bu özelliği düzenlemek için **geçerli** bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `MaxFarmingTime`

Varsayılan değeri `10` olan `byte` türü. Bildiğiniz gibi, Steam her zaman düzgün çalışmaz; bazen bir oyunu oynamamıza rağmen oynama süremizin kaydedilmemesi gibi garip durumlar yaşanabilir. ASF, tek bir oyunun tek başına modda en fazla `MaxFarmingTime` saat boyunca düşürülmesine izin verir ve bu sürenin sonunda o oyunu tamamen düşürülmüş kabul eder. Bu, garip durumlar yaşandığında kart düşürme sürecinin donmasını önlemek için ve ayrıca Steam'in bir nedenle ASF'nin ilerlemesini durduracak yeni bir rozet yayınlaması durumunda (bakınız: `Blacklist`) gereklidir. Varsayılan `10` saatlik değer, bir oyundaki tüm Steam kartlarını düşürmek için yeterli olmalıdır. Bu özelliği çok düşük ayarlamak, geçerli oyunların atlanmasına neden olabilir (ve evet, düşürülmesi 9 saate kadar süren geçerli oyunlar vardır), çok yüksek ayarlamak ise kart düşürme sürecinin donmasına neden olabilir. Lütfen bu özelliğin tek bir kart düşürme oturumunda yalnızca tek bir oyunu etkilediğini (yani tüm sırayı tamamladıktan sonra ASF o oyuna geri dönecektir) ve toplam oynama süresine değil, ASF'nin dahili kart düşürme süresine dayandığını unutmayın. Bu nedenle, ASF bir yeniden başlatmanın ardından da o oyuna geri dönecektir. Bu özelliği düzenlemek için **geçerli** bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `MaxTradeHoldDuration`

Varsayılan değeri `15` olan `byte` türü. Bu özellik, kabul etmeye razı olduğumuz takas bekletme süresinin gün cinsinden maksimum süresini tanımlar. ASF, **[takas](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-tr-TR)** bölümünde tanımlandığı gibi, `MaxTradeHoldDuration` gününden daha uzun süre bekletilen takasları reddedecektir. Bu seçenek yalnızca `TradingPreferences` ayarı `SteamTradeMatcher` olan botlar için anlamlıdır, çünkü `Master`/`SteamOwnerID` takaslarını veya bağışları etkilemez. Takas bekletmeleri herkes için can sıkıcıdır ve kimse onlarla uğraşmak istemez. ASF'nin liberal kurallarla çalışması ve takas bekletmesi olup olmadığına bakılmaksızın herkese yardımcı olması beklenir. Bu yüzden bu seçenek varsayılan olarak `15` olarak ayarlanmıştır. Ancak, takas bekletmelerinden etkilenen tüm takasları reddetmeyi tercih ederseniz, buraya `0` yazabilirsiniz. **[Takas](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-tr-TR)** bölümünde açıklandığı gibi, kısa ömürlü kartların bu seçenekten etkilenmediğini ve takas bekletmesi olan kişiler için otomatik olarak reddedildiğini lütfen göz önünde bulundurun. Bu nedenle, sadece bu yüzden herkesi küresel olarak reddetmenize gerek yoktur. Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.


---

### `MinFarmingDelayAfterBlock`

Varsayılan değeri `60` olan `byte` türü. Bu özellik, bir oyun başlatarak o an kart düşüren ASF'nin bağlantısını zorla kestiğinizde meydana gelen `LoggedInElsewhere` hatasıyla bağlantısı kesilirse, ASF'nin kart düşürmeye devam etmeden önce bekleyeceği minimum süreyi saniye cinsinden tanımlar. Bu gecikme temel olarak kolaylık ve sistem yükünü azaltma nedenleriyle mevcuttur. Örneğin, oynama kilidi sadece bir saniyeliğine serbest kaldığı için ASF'nin tekrar hesabınızı meşgul etmesiyle uğraşmak zorunda kalmadan oyunu yeniden başlatmanıza olanak tanır. Oturumu geri alma işlemi `LoggedInElsewhere` bağlantı kesintisine neden olduğundan, ASF'nin tüm yeniden bağlanma prosedüründen geçmesi gerekir. Bu da makine ve Steam ağı üzerinde ek bir baskı oluşturur. Bu nedenle, mümkünse ek bağlantı kesintilerinden kaçınmak tercih edilir. Varsayılan olarak bu, `60` saniye olarak yapılandırılmıştır ve bu süre, oyunu fazla zahmete girmeden yeniden başlatmanıza olanak tanımalıdır. Ancak, örneğin ağınız sık sık kesiliyorsa ve ASF çok erken devreye giriyorsa, bu da sizi yeniden bağlanma sürecinden geçmeye zorluyorsa, bu değeri artırmak isteyebileceğiniz senaryolar vardır. Bu özellik için, tüm yaygın senaryolar için yeterli olması gereken maksimum `255` değerine izin veriyoruz. Yukarıdakilere ek olarak, gecikmeyi azaltmak, hatta `0` değeriyle tamamen kaldırmak da mümkündür, ancak yukarıda belirtilen nedenlerden dolayı bu genellikle önerilmez. Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `OptimizationMode`

Varsayılan değeri `0` olan `byte` türü. Bu özellik, ASF'nin çalışma zamanı sırasında tercih edeceği optimizasyon modunu tanımlar. Şu anda ASF iki modu desteklemektedir: `0` (`MaxPerformance` - Maksimum Performans) ve `1` (`MinMemoryUsage` - Minimum Bellek Kullanımı). Varsayılan olarak ASF, mümkün olduğu kadar çok şeyi paralel (eşzamanlı) olarak çalıştırmayı tercih eder. Bu, iş yükünü tüm işlemci çekirdekleri, çoklu işlemci iş parçacıkları, çoklu soketler ve çoklu iş parçacığı havuzu görevleri arasında dengeleyerek performansı artırır. Örneğin, ASF kart düşürülecek oyunları kontrol ederken ilk rozet sayfanızı ister ve bu istek ulaştığında, ASF aslında kaç rozet sayfanız olduğunu okur ve ardından geri kalan her bir sayfayı eşzamanlı olarak talep eder. Çoğu durumda ek yük minimum olduğundan ve asenkron ASF kodunun faydaları tek bir işlemci çekirdeğine ve oldukça sınırlı güce sahip en eski donanımlarda bile görülebildiğinden, bu **neredeyse her zaman** isteyeceğiniz bir şeydir. Ancak, birçok görevin paralel olarak işlenmesiyle, ASF çalışma zamanı bu görevlerin bakımından (örneğin soketleri açık tutmak, iş parçacıklarını canlı tutmak ve görevleri işlemek) sorumlu olur. Bu durum, zaman zaman artan bellek kullanımına neden olabilir. Eğer mevcut bellek konusunda aşırı derecede kısıtlıysanız, ASF'yi mümkün olduğunca az görev kullanmaya zorlamak ve tipik olarak paralel çalıştırılabilecek asenkron kodu senkron bir şekilde çalıştırmak için bu özelliği `1` (`MinMemoryUsage`) olarak değiştirmek isteyebilirsiniz. Bu özelliği değiştirmeyi, yalnızca daha önce **[düşük bellekli kurulum](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-tr-TR)** sayfasını okuduysanız ve çok küçük bir bellek kazancı için devasa bir performans artışından kasıtlı olarak vazgeçmek istiyorsanız düşünmelisiniz. Genellikle bu seçenek, **[düşük bellekli kurulum](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-tr-TR)** sayfasında açıklandığı gibi, ASF kullanımınızı sınırlamak veya çalışma zamanının çöp toplayıcısını ayarlamak gibi diğer olası yollarla elde edebileceğinizden **çok daha kötüdür**. Bu nedenle, diğer (çok daha iyi) seçeneklerle tatmin edici sonuçlar elde edemediyseniz, `MinMemoryUsage` modunu **son çare** olarak, çalışma zamanını yeniden derlemeden hemen önce kullanmalısınız. Bu özelliği düzenlemek için **geçerli** bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `PluginsUpdateList`

Varsayılan değeri boş olan `ImmutableHashSet<string>` türü. Bu özellik, aşağıda tanımlanan `PluginsUpdateMode`'a göre otomatik güncellemeler için dikkate alınacak eklenti derleme adlarının kara listesini veya beyaz listesini tanımlar.

Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `PluginsUpdateMode`

Varsayılan değeri `0` olan `byte` türü. Bu özellik, yukarıda tanımlanan `PluginsUpdateList`'e anlam katan eklenti güncelleme modunu tanımlar. Bu özelliği belirterek, belirtilenler dışındaki tüm eklentiler için otomatik güncellemeleri kolayca etkinleştirebilir/devre dışı bırakabilirsiniz.

- `0` değeri (`Whitelist` - Beyaz Liste olarak adlandırılır), `PluginsUpdateList` içinde tanımlananlar hariç tüm eklentilerin otomatik güncellemesini **devre dışı bırakır**.
- `1` değeri (`Blacklist` - Kara Liste olarak adlandırılır), `PluginsUpdateList` içinde tanımlananlar hariç tüm eklentilerin otomatik güncellemesini **etkinleştirir**.

**ASF ekibi, kendi güvenliğiniz için otomatik güncellemeleri yalnızca güvendiğiniz kaynaklardan etkinleştirmeniz gerektiğini hatırlatır**. Kötü niyetli eklentilerin, bu ayardan **bağımsız olarak** kendilerini güncelleyebileceğini veya uzaktan komut çalıştırabileceğini unutmayın. Bu nedenle bu ayar yalnızca ASF tarafından sağlanan eklenti güncelleme işlevselliği için geçerlidir ve kullanmaya karar verdiğiniz her eklentiyi uygun şekilde doğruladığınızdan emin olmalısınız.

Eklenti güncellemeleri, varsayılan olarak ASF güncelleme rutiniyle birlikte gerçekleştirilir: **[`UpdateChannel`](#updatechannel)** ve **[`UpdatePeriod`](#updateperiod)**. `update` komutu gibi standart ASF güncelleme mekanizmaları, isteğe bağlı eklenti güncellemelerini de tetikleyecektir. Eğer ASF sürümünü güncellemeden yalnızca eklentileri manuel olarak güncellemek isterseniz, `updateplugins` komutu bu imkanı sunar.

Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `ShutdownIfPossible`

Varsayılan değeri `false` olan `bool` türü. Etkinleştirildiğinde, ASF mümkünse, yani kayıtlı tüm botlarınız durdurulduğunda, süreci kapatmaya çalışır. Bu, tüm bot örneklerinizde `ShutdownOnFarmingFinished` ile birleştirildiğinde özellikle yararlı olabilir, çünkü bu şekilde ASF, botlarınızdan sonuncusu kart düşürmeyi bitirdiğinde otomatik olarak kapanabilir.

Kullanıcıların çoğunluğunun beklentisi, sürecin (örneğin `IPC` kullanımı için) her zaman çalışır durumda olması olduğundan, bu seçenek varsayılan olarak devre dışıdır.

---

### `SteamMessagePrefix`

Varsayılan değeri `"/me "` olan `string` (metin) türü. Bu özellik, ASF tarafından gönderilen tüm Steam mesajlarının başına eklenecek bir ön ek tanımlar. Varsayılan olarak ASF, bot mesajlarını Steam sohbetinde farklı renkte göstererek daha kolay ayırt etmek için `"/me "` ön ekini kullanır. Bahsetmeye değer bir diğer ön ek ise, benzer bir sonuç elde eden ancak farklı bir biçimlendirme kullanan `"/pre "` ön ekidir. Ön ek kullanımını tamamen devre dışı bırakmak ve tüm ASF mesajlarını geleneksel bir şekilde yazdırmak için bu özelliği boş bir dizeye veya `null` değerine de ayarlayabilirsiniz. Bu özelliğin yalnızca Steam mesajlarını etkilediğini, diğer kanallar (IPC gibi) aracılığıyla döndürülen yanıtların etkilenmediğini belirtmekte fayda var. Standart ASF davranışını özelleştirmek istemiyorsanız, varsayılan ayarında bırakmak iyi bir fikirdir.

---

### `SteamOwnerID`

Varsayılan değeri `0` olan `ulong` türü. Bu özellik, ASF süreç sahibinin 64-bit formatındaki Steam ID'sini tanımlar ve belirli bir bot örneğinin `Master` iznine çok benzer (ancak bu globaldir). Bu özelliği neredeyse her zaman kendi ana Steam hesabınızın ID'sine ayarlamak istersiniz. `Master` izni, bot örneği üzerinde tam kontrol içerir, ancak `exit`, `restart` veya `update` gibi genel komutlar yalnızca `SteamOwnerID` için ayrılmıştır. Bu kullanışlıdır, çünkü arkadaşlarınız için botlar çalıştırırken, onların `exit` komutuyla çıkış yapmak gibi ASF sürecini kontrol etmelerine izin vermek istemeyebilirsiniz. Varsayılan `0` değeri, ASF sürecinin bir sahibinin olmadığını belirtir, bu da hiç kimsenin genel ASF komutlarını çalıştıramayacağı anlamına gelir. Bu özelliğin yalnızca Steam sohbeti için geçerli olduğunu unutmayın. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-tr-TR)** ve etkileşimli konsol, bu özellik ayarlanmamış olsa bile `Owner` komutlarını çalıştırmanıza izin verecektir.

---

### `SteamProtocols`

Varsayılan değeri `7` olan `byte flags` türü. Bu özellik, ASF'nin Steam sunucularına bağlanırken kullanacağı ve aşağıda tanımlanan Steam protokollerini belirtir:

| Değer | Ad        | Açıklama                                                                                             |
| ----- | --------- | ---------------------------------------------------------------------------------------------------- |
| 0     | Hiçbiri   | Protokol yok                                                                                         |
| 1     | TCP       | **[İletim Kontrol Protokolü](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)**          |
| 2     | UDP       | **[Kullanıcı Veri Paketi İletişim Kuralları](https://en.wikipedia.org/wiki/User_Datagram_Protocol)** |
| 4     | WebSocket | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                                             |

Bu özelliğin bir `flags` (bayrak) alanı olduğunu, bu nedenle mevcut değerlerin herhangi bir kombinasyonunu seçmenin mümkün olduğunu lütfen unutmayın. Daha fazla bilgi edinmek isterseniz **[JSON eşlemesi](#json-eslemesi)** bölümüne göz atın. Hiçbir bayrağın etkinleştirilmemesi `None` (Hiçbiri) seçeneğiyle sonuçlanır ve bu seçenek tek başına geçersizdir.

Varsayılan olarak ASF, kesintiler ve diğer benzer Steam sorunlarıyla mücadele etmek için mevcut tüm Steam protokollerini kullanacaktır. Genellikle, ASF'yi yalnızca bir veya iki belirli protokolü kullanacak şekilde sınırlamak istiyorsanız bu özelliği değiştirmek istersiniz. Bu tür önlemler çeşitli durumlarda gerekebilir; örneğin, güvenlik duvarınızda UDP trafiğini engellediyseniz ve yalnızca TCP trafiğinin geçmesini sağlamak istiyorsanız veya bir `WebProxy` kullanıyorsanız ve bunu Steam istemci bağlantısı için de kullanmak istiyorsanız (bunu yalnızca `WebSocket` protokolü destekler).

Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `UpdateChannel`

Varsayılan değeri `1` olan `byte` türü. Bu özellik, otomatik güncellemeler (`UpdatePeriod` değeri `0`'dan büyükse) veya güncelleme bildirimleri (aksi takdirde) için kullanılan güncelleme kanalını tanımlar. Şu anda ASF üç güncelleme kanalını desteklemektedir: `0` (`None` - Hiçbiri), `1` (`Stable` - Kararlı) ve `2` (`PreRelease` - Ön Sürüm). `Stable` (Kararlı) kanalı, kullanıcıların çoğunluğu tarafından kullanılması gereken varsayılan yayın kanalıdır. `PreRelease` (Ön Sürüm) kanalı, `Stable` (Kararlı) sürümlerine ek olarak, ileri düzey kullanıcılar ve diğer geliştiricilerin yeni özellikleri test etmeleri, hata düzeltmelerini onaylamaları veya planlanan geliştirmeler hakkında geri bildirimde bulunmaları için ayrılmış **ön sürümleri** de içerir. **Ön sürüm versiyonları genellikle yamalanmamış hatalar, geliştirilmekte olan özellikler veya yeniden yazılmış uygulamalar içerir**. Kendinizi ileri düzey bir kullanıcı olarak görmüyorsanız, lütfen varsayılan `1` (`Stable`) güncelleme kanalında kalın. `PreRelease` kanalı, hata bildirmeyi, sorunlarla başa çıkmayı ve geri bildirim vermeyi bilen kullanıcılara adanmıştır - bu kanal için teknik destek verilmeyecektir. Daha fazla bilgi edinmek isterseniz ASF **[sürüm döngüsüne](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-tr-TR)** göz atın. Tüm sürüm kontrollerini tamamen kaldırmak istiyorsanız, `UpdateChannel` değerini `0` (`None` - Hiçbiri) olarak da ayarlayabilirsiniz. `UpdateChannel` değerini `0` olarak ayarlamak, `update` komutu da dahil olmak üzere güncellemelerle ilgili tüm işlevleri tamamen devre dışı bırakacaktır. `None` kanalını kullanmak, kendinizi her türlü soruna maruz bırakmanız nedeniyle (aşağıdaki `UpdatePeriod` açıklamasında belirtilmiştir) **kesinlikle önerilmez**.

**Ne yaptığınızı bilmiyorsanız**, bu ayarı varsayılan değerinde bırakmanızı **şiddetle** tavsiye ederiz.

---

### `UpdatePeriod`

Varsayılan değeri `24` olan `byte` türü. Bu özellik, ASF'nin otomatik güncellemeleri ne sıklıkta kontrol etmesi gerektiğini saat cinsinden tanımlar. Güncellemeler yalnızca yeni özellikleri ve kritik güvenlik yamalarını almak için değil, aynı zamanda hata düzeltmeleri, performans geliştirmeleri, kararlılık iyileştirmeleri ve daha fazlasını almak için de hayati önem taşır. `0`'dan büyük bir değer ayarlandığında, yeni bir güncelleme mevcut olduğunda ASF otomatik olarak kendini indirir, değiştirir ve yeniden başlatır (`AutoRestart` izin veriyorsa). Bunu başarmak için ASF, her `UpdatePeriod` saatte bir GitHub depomuzda yeni bir güncelleme olup olmadığını kontrol edecektir. `0` değeri otomatik güncellemeleri devre dışı bırakır, ancak yine de `update` komutunu manuel olarak çalıştırmanıza izin verir. `UpdatePeriod`'in takip etmesi gereken uygun `UpdateChannel` ayarını yapmakla da ilgilenebilirsiniz.

ASF'nin güncelleme süreci, kullandığı tüm klasör yapısının güncellenmesini içerir, ancak `config` dizininde bulunan kendi yapılandırma dosyalarınıza veya veritabanlarınıza dokunmaz. Bu, dizinindeki ASF ile ilgisi olmayan tüm ek dosyaların güncelleme sırasında kaybolabileceği anlamına gelir. Varsayılan `24` değeri, gereksiz kontroller ile yeterince güncel bir ASF arasında iyi bir dengedir.

Bu özelliği devre dışı bırakmak için **geçerli bir nedeniniz** olmadıkça, **kendi iyiliğiniz için** otomatik güncellemeleri makul bir `UpdatePeriod` dahilinde etkin tutmalısınız. Bunun nedeni yalnızca en son kararlı ASF sürümü dışında bir sürümü desteklemememiz değil, aynı zamanda **güvenlik garantimizi yalnızca en son sürüm için vermemizdir**. Eğer güncel olmayan bir ASF sürümü kullanıyorsanız, kendinizi kasıtlı olarak küçük hatalardan bozuk işlevselliğe, hatta **[kalıcı Steam hesabı askıya alınmalarına](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-tr-TR#bunun-yuzunden-ban-yiyen-oldu-mu)** varan her türlü soruna maruz bırakıyorsunuz demektir. Bu nedenle, kendi iyiliğiniz için, ASF sürümünüzün her zaman güncel olduğundan emin olmanızı **şiddetle tavsiye ederiz**. Otomatik güncellemeler, sorunlu kodu büyümeden önce devre dışı bırakarak veya yamayarak her türlü soruna hızla müdahale etmemizi sağlar. Eğer bu özellikten vazgeçerseniz, tüm güvenlik garantilerimizi kaybeder ve yalnızca Steam ağına değil, tanım gereği kendi Steam hesabınıza da potansiyel olarak zararlı olabilecek bir kodu çalıştırmanın sonuçlarını riske atarsınız.

---

### `WebLimiterDelay`

Varsayılan değeri `300` olan `ushort` türü. Bu özellik, aynı Steam web servisine gönderilen iki ardışık istek arasındaki minimum gecikme süresini milisaniye cinsinden tanımlar. Steam'in dahili olarak kullandığı **[AkamaiGhost](https://www.akamai.com)** servisi, belirli bir zaman diliminde gönderilen toplam istek sayısına dayalı bir hız sınırlaması içerdiğinden bu tür bir gecikme gereklidir. Normal şartlarda Akamai tarafından engellenmek oldukça zordur, ancak çok ağır iş yükleri ve büyük bir istek kuyruğu altında, çok kısa sürede çok fazla istek göndermeye devam edersek bu engeli tetiklemek mümkündür.

Varsayılan değer, ASF'nin Steam web servislerine - özellikle `steamcommunity.com`, `api.steampowered.com` ve `store.steampowered.com` adreslerine - erişen tek araç olduğu varsayımına dayanarak ayarlanmıştır. Eğer aynı web servislerine istek gönderen başka araçlar kullanıyorsanız, aracınızın da benzer bir `WebLimiterDelay` işlevselliğine sahip olduğundan emin olmalı ve her ikisini de varsayılan değerin iki katına, yani `600`'e ayarlamalısınız. Bu, hiçbir koşulda `300` ms'de 1'den fazla istek göndermeyeceğinizi garanti eder.

Genel olarak, `WebLimiterDelay` değerini varsayılanın altına düşürmek, bazıları kalıcı olabilen çeşitli IP tabanlı engellemelere yol açabileceğinden **kesinlikle önerilmez**. Varsayılan değer, sunucuda tek bir ASF örneği çalıştırmak ve normal bir senaryoda orijinal Steam istemcisiyle birlikte ASF kullanmak için yeterince iyidir. Çoğu kullanım için doğru olmalıdır ve yalnızca artırmalısınız (asla düşürmeyin). Kısacası, tek bir IP'den tek bir Steam alan adına gönderilen tüm isteklerin toplam sayısı, `300` ms'de 1 isteği asla aşmamalıdır.

Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.

---

### `WebProxy`

Varsayılan değeri `null` olan `string` (metin) türü. Bu özellik, özellikle `github.com`, `api.steampowered.com`, `steamcommunity.com` ve `store.steampowered.com` gibi servislere yönelik dahili http bağlantılı iletişim için kullanılacak bir web proxy adresi tanımlar. Bu ayar, genel (bota özgü olmayan) iletişimin yanı sıra, bota özgü `WebProxy` yapılandırma özelliği ayarlanmamışsa, o botun iletişimi için de geçerlidir. ASF isteklerini bir proxy üzerinden yönlendirmek, çeşitli güvenlik duvarlarını, özellikle de Çin'in Büyük Güvenlik Duvarı'nı aşmak için son derece yararlı olabilir.

Bu özellik bir URI dizesi olarak tanımlanır:

> Bir URI dizesi bir şemadan (desteklenenler: http/https/socks4/socks4a/socks5), bir ana bilgisayardan (host) ve isteğe bağlı bir porttan oluşur. Tam bir URI dizesi örneği: `"http://contoso.com:8080"`.

Eğer proxy'niz kullanıcı kimlik doğrulaması gerektiriyorsa, `WebProxyUsername` ve/veya `WebProxyPassword` ayarlarını da yapmanız gerekecektir. Böyle bir ihtiyaç yoksa, yalnızca bu özelliği ayarlamak yeterlidir.

Eğer dahili Steam ağ iletişimini (CM'ler) de proxy üzerinden yönlendirmek istiyorsanız, **

`SteamProtocols</a></strong> bot özelliğini, yalnızca websocket aktarımına izin veren bir değere, yani <code>4` değerine ayarladığınızdan emin olmalısınız, çünkü proxy yönlendirmesi için yalnızca websocket'ler desteklenir.</p> 

Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.



---



### `WebProxyPassword`

Varsayılan değeri `null` olan `string` (metin) türü. Bu özellik, proxy işlevselliği sağlayan bir hedef `WebProxy` makinesi tarafından desteklenen temel, digest, NTLM ve Kerberos kimlik doğrulaması için kullanılan parola alanını tanımlar. Proxy'niz kullanıcı kimlik bilgileri gerektirmiyorsa, buraya herhangi bir şey girmenize gerek yoktur. Bu seçeneği kullanmak, yalnızca `WebProxy` de kullanılıyorsa anlamlıdır, aksi takdirde bir etkisi olmaz.

Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.



---



### `WebProxyUsername`

Varsayılan değeri `null` olan `string` (metin) türü. Bu özellik, proxy işlevselliği sağlayan bir hedef `WebProxy` makinesi tarafından desteklenen temel, digest, NTLM ve Kerberos kimlik doğrulaması için kullanılan kullanıcı adı alanını tanımlar. Proxy'niz kullanıcı kimlik bilgileri gerektirmiyorsa, buraya herhangi bir şey girmenize gerek yoktur. Bu seçeneği kullanmak, yalnızca `WebProxy` de kullanılıyorsa anlamlıdır, aksi takdirde bir etkisi olmaz.

Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.



---



## Bot Yapılandırması

Bildiğiniz gibi, her botun aşağıdaki örnek JSON yapısına dayalı kendi yapılandırması olmalıdır. İşe botunuza nasıl bir ad vereceğinize karar vererek başlayın (örneğin, `1.json`, `ana.json`, `birincil.json` veya `BaskaBirSey.json`) ve ardından yapılandırmaya geçin.

**Not:** Bir bot `ASF` olarak adlandırılamaz (çünkü bu anahtar kelime genel yapılandırma için ayrılmıştır). ASF ayrıca nokta ile başlayan tüm yapılandırma dosyalarını da yok sayar.

Bot yapılandırması aşağıdaki yapıya sahiptir:



```json
{
    "AcceptGifts": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Enabled": false,
    "FarmingOrders": [],
    "FarmingPreferences": 0,
    "GamesPlayedWhileIdle": [],
    "GamingDeviceType": 1,
    "HoursUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "MachineName": null,
    "MatchableTypes": [5],
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "RedeemingPreferences": 0,
    "RemoteCommunication": 3,
    "SendTradePeriod": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "TransferableTypes": [1, 3, 5],
    "UseLoginKeys": true,
    "UserInterfaceMode": 0,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```




---

Tüm seçenekler aşağıda açıklanmıştır:



### `AcceptGifts`

Varsayılan değeri `false` olan `bool` türü. Etkinleştirildiğinde, ASF bota gönderilen tüm Steam hediyelerini (cüzdan hediye kartları dahil) otomatik olarak kabul eder ve etkinleştirir. Bu, `SteamUserPermissions` içinde tanımlananlar dışındaki kullanıcılardan gönderilen hediyeleri de içerir. E-posta adresine gönderilen hediyelerin doğrudan istemciye iletilmediğini, bu nedenle ASF'nin sizin yardımınız olmadan bunları kabul etmeyeceğini unutmayın.

Bu seçenek yalnızca yan hesaplar için önerilir, çünkü ana hesabınıza gönderilen tüm hediyeleri otomatik olarak etkinleştirmek istemeyeceğiniz kuvvetle muhtemeldir. Bu özelliği etkinleştirmek isteyip istemediğinizden emin değilseniz, varsayılan `false` değeriyle bırakın.



---



### `BotBehaviour`

Varsayılan değeri `0` olan `byte flags` türü. Bu özellik, çeşitli olaylar sırasında ASF'nin bota benzer davranışlarını tanımlar ve aşağıdaki gibi tanımlanmıştır:

| Değer | Ad                            | Açıklama                                                                                                                 |
| ----- | ----------------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| 0     | Hiçbiri                       | Özel bot davranışı yok, varsayılan ayarlar                                                                               |
| 1     | RejectInvalidFriendInvites    | ASF'nin geçersiz arkadaşlık davetlerini (yoksaymak yerine) reddetmesine neden olur                                       |
| 2     | RejectInvalidTrades           | ASF'nin geçersiz takas tekliflerini (yoksaymak yerine) reddetmesine neden olur                                           |
| 4     | RejectInvalidGroupInvites     | ASF'nin geçersiz grup davetlerini (yoksaymak yerine) reddetmesine neden olur                                             |
| 8     | DismissInventoryNotifications | ASF'nin tüm envanter bildirimlerini otomatik olarak kapatmasını sağlar                                                   |
| 16    | MarkReceivedMessagesAsRead    | ASF'nin gelen tüm mesajları otomatik olarak okundu olarak işaretlemesini sağlar                                          |
| 32    | MarkBotMessagesAsRead         | ASF'nin diğer ASF botlarından (aynı örnekte çalışan) gelen mesajları otomatik olarak okundu olarak işaretlemesini sağlar |
| 64    | DisableIncomingTradesParsing  | ASF'nin gelen takas tekliflerini asla işlememesini sağlar                                                                |


Bu özelliğin bir `flags` (bayrak) alanı olduğunu, bu nedenle mevcut değerlerin herhangi bir kombinasyonunu seçmenin mümkün olduğunu lütfen unutmayın. Daha fazla bilgi edinmek isterseniz **[JSON eşlemesi](#json-eslemesi)** bölümüne göz atın. Hiçbir bayrağın etkinleştirilmemesi `None` (Hiçbiri) seçeneğiyle sonuçlanır.

Genel olarak, botun etkinliğiyle ilgili çeşitli otomasyon ayarlarını değiştirmeyi planlıyorsanız bu özelliği düzenlemek istersiniz. Varsayılan ayarlar, ASF'nin müdahaleci olmayan modda çalışmasını içerir; bu mod, yalnızca kullanıcının iradesine aykırı olmayan faydalı otomasyonu etkinleştirir.

Geçersiz arkadaşlık isteği, `SteamUserPermissions` içinde tanımlanan `FamilySharing` veya üzeri bir izne sahip olmayan bir kullanıcıdan gelen davettir. Normal modda ASF, beklediğiniz gibi bu davetleri görmezden gelerek size onları kabul edip etmeme özgürlüğü tanır. `RejectInvalidFriendInvites`, bu davetlerin otomatik olarak reddedilmesine neden olur. Bu da, `SteamUserPermissions` içinde tanımlanan kişiler dışındaki insanların sizi arkadaş listesine ekleme seçeneğini pratikte devre dışı bırakır. Tüm arkadaşlık davetlerini kesin olarak reddetmek istemiyorsanız, bu seçeneği etkinleştirmemelisiniz.

Geçersiz takas teklifi, ASF'nin yerleşik modülü aracılığıyla kabul edilmeyen bir tekliftir. Bu konu hakkında daha fazla bilgi, ASF'nin hangi tür takasları otomatik olarak kabul etmeye istekli olduğunu açıkça tanımlayan **[takas](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-tr-TR)** bölümünde bulunabilir. Geçerli takaslar, diğer ayarlar, özellikle de `TradingPreferences` tarafından da tanımlanır. `RejectInvalidTrades`, tüm geçersiz takas tekliflerinin görmezden gelinmek yerine reddedilmesine neden olur. ASF tarafından otomatik olarak kabul edilmeyen tüm takas tekliflerini kesin olarak reddetmek istemiyorsanız, bu seçeneği etkinleştirmemelisiniz.

Geçersiz grup daveti, `SteamMasterClanID` olarak belirlenen gruptan gelmeyen bir davettir. Normal modda ASF, beklediğiniz gibi bu grup davetlerini görmezden gelerek belirli bir Steam grubuna katılıp katılmama kararını size bırakır. `RejectInvalidGroupInvites`, tüm bu grup davetlerinin otomatik olarak reddedilmesine neden olarak, sizi `SteamMasterClanID` dışındaki herhangi bir gruba davet etmeyi etkili bir şekilde imkansız hale getirir. Tüm grup davetlerini kesin olarak reddetmek istemiyorsanız, bu seçeneği etkinleştirmemelisiniz.

Yeni eşya alındığına dair sürekli gelen Steam bildirimlerinden rahatsız olmaya başladığınızda `DismissInventoryNotifications` son derece kullanışlıdır. ASF, bildirimin kendisinden kurtulamaz çünkü bu, Steam istemcinize yerleşiktir. Ancak, bildirimi aldıktan sonra otomatik olarak temizleyebilir, bu da "envanterde yeni eşyalar var" bildiriminin sürekli görünmesini engeller. Eğer alınan tüm eşyaları (özellikle ASF ile düşürülen kartları) kendiniz değerlendirmek istiyorsanız, doğal olarak bu seçeneği etkinleştirmemelisiniz. Artık çıldırmaya başladığınızda, bunun bir seçenek olarak sunulduğunu unutmayın.

`MarkReceivedMessagesAsRead`, ASF'nin çalıştığı hesap tarafından alınan hem özel hem de grup mesajlarının **tümünü** otomatik olarak okundu olarak işaretler. Bu genellikle, örneğin ASF komutlarını çalıştırırken sizden gelen "yeni mesaj" bildirimini temizlemek için yalnızca yan hesaplar tarafından kullanılmalıdır. Bu seçeneği ana hesaplar için önermiyoruz; meğerki, siz çevrimdışıyken gelenler de **dahil olmak üzere** her türlü yeni mesaj bildiriminden kendinizi soyutlamak istemiyorsanız (ASF'nin açık bırakılıp bunları temizlediği varsayılarak).

`MarkBotMessagesAsRead`, yalnızca bot mesajlarını okundu olarak işaretleyerek benzer bir şekilde çalışır. Ancak, bu seçeneği botlarınız ve diğer insanlarla grup sohbetlerinde kullanırken, bir sohbet mesajını okundu olarak işaretlemenin Steam'deki uygulamasının, işaretlemeye karar verdiğiniz mesajdan **önce** gelen tüm mesajları da okundu saydığını unutmayın. Bu nedenle, arada geçen alakasız bir mesajı kaçırmak istemiyorsanız, genellikle bu özelliği kullanmaktan kaçınmalısınız. Açıkçası, aynı ASF örneğinde birden fazla ana hesabınız (örneğin farklı kullanıcılardan) çalışıyorsa bu da risklidir, çünkü onların normal, ASF dışı mesajlarını da kaçırabilirsiniz.

`DisableIncomingTradesParsing`, ASF'nin gelen takas tekliflerini çözümlemesini durdurur. Bu, bununla ilgili tüm takas işlevlerinin çalışmayacağı anlamına gelir. ASF varsayılan olarak en az müdahaleci modda çalıştığından, yalnızca `Master` ve üzeri yetkiye sahip kullanıcılardan gelen takas tekliflerini kabul edip diğerlerine hiç dokunmadığından, gelen takasları çözümleme varsayılan olarak etkindir. Bu ayar, takas çözümlemesiyle ilgili ek istek veya ek yük olmamasını sağlamak isteyen, örneğin botlarının hiçbir zaman master takas isteği almayacağını bilen ve bu nedenle ASF'nin takas faaliyetlerine hiç katılmasını gerektirmeyen kişiler için en anlamlısıdır. Bu seçeneğin belirtilmesinin, `AcceptDonations` veya `SteamTradeMatcher` gibi gelen takaslara bağlı olan diğer tüm seçenekleri de devre dışı bırakacağını unutmayın. Özel eklentiler de gelen takas tekliflerini alışılmış şekilde işleyemeyecektir.

Bu seçeneği nasıl yapılandıracağınızdan emin değilseniz, varsayılan ayarında bırakmak en iyisidir.



---



### `CompleteTypesToSend`

Varsayılan değeri boş olan bir `ImmutableHashSet<byte>` türüdür. ASF, burada belirtilen belirli eşya türlerinden oluşan bir seti tamamladığında, bitmiş tüm setleri içeren bir Steam takasını otomatik olarak `Master` yetkisine sahip kullanıcıya gönderebilir. Bu, örneğin bir bot hesabını STM eşleştirmesi için kullanırken, tamamlanmış setleri başka bir hesaba taşımak istiyorsanız çok kullanışlıdır. Bu seçenek `loot` komutuyla aynı şekilde çalışır. Bu nedenle, `Master` yetkisine sahip bir kullanıcı gerektirdiğini, ayrıca geçerli bir `SteamTradeToken`'a ve en başından takas yapmaya uygun bir hesaba ihtiyacınız olabileceğini unutmayın.

Bugün itibarıyla, bu ayarda aşağıdaki eşya türleri desteklenmektedir:

| Değer | Ad              | Açıklama                                                              |
| ----- | --------------- | --------------------------------------------------------------------- |
| 3     | FoilTradingCard | `TradingCard`'ın parlak (foil) versiyonu                              |
| 5     | TradingCard     | Rozet işlemek için kullanılan Steam koleksiyon kartı (parlak olmayan) |


Lütfen yukarıdaki ayarlardan bağımsız olarak, ASF'nin yalnızca **[Steam Topluluğu eşyaları](https://steamcommunity.com/my/inventory/#753_6)** (`appID` 753, `contextID` 6) için istek yapacağını unutmayın. Dolayısıyla tüm oyun eşyaları, hediyeler ve benzerleri tanım gereği takas teklifinden hariç tutulur.

Bu seçeneği kullanmanın getirdiği ek yük nedeniyle, yalnızca kendi başlarına setleri tamamlama ihtimali olan bot hesaplarında kullanılması önerilir. Örneğin, zaten düzenli olarak `FarmingPreferences` içindeki `SendOnFarmingFinished` tercihini, `SendTradePeriod`'u veya `loot` komutunu kullanıyorsanız bu özelliği etkinleştirmenin bir anlamı yoktur. 

Bu seçeneği nasıl yapılandıracağınızdan emin değilseniz, en iyisi varsayılan ayarında bırakmaktır.



---



### `CustomGamePlayedWhileFarming`

Varsayılan değeri `null` olan `string` (metin) türü. ASF kart düşürürken, o an düşürdüğü oyun yerine durumunu "Steam dışı oyun oynuyor: `CustomGamePlayedWhileFarming`" olarak gösterebilir. Bu, arkadaşlarınıza kart düşürdüğünüzü bildirmek istediğiniz ancak `OnlineStatus` ayarını `Offline` (Çevrimdışı) olarak kullanmak istemediğiniz durumlarda kullanışlı olabilir. Lütfen ASF'nin Steam ağının gerçek görüntüleme sırasını garanti edemeyeceğini unutmayın; bu nedenle bu, düzgün görüntülenebilecek veya görüntülenmeyebilecek bir öneridir. Özellikle, eğer ASF `Complex` kart düşürme algoritmasında 32 slotun tamamını oynama süresi artırılması gereken oyunlarla doldurursa, özel oyun adı görüntülenmez. Varsayılan `null` değeri bu özelliği devre dışı bırakır.

ASF, metninizde isteğe bağlı olarak kullanabileceğiniz birkaç özel değişken sunar. `{0}`, ASF tarafından o an düşürülmekte olan oyun(lar)ın `AppID`'si ile, `{1}` ise o an düşürülmekte olan oyun(lar)ın `GameName`'i (Oyun Adı) ile değiştirilecektir. 



---



### `CustomGamePlayedWhileIdle`

Varsayılan değeri `null` olan `string` (metin) türü. `CustomGamePlayedWhileFarming` özelliğine benzer, ancak bu, ASF'nin yapacak bir şeyi olmadığında (hesabın kart düşürme işlemi bittiğinde) kullanılır. Lütfen ASF'nin Steam ağının gerçek görüntüleme sırasını garanti edemeyeceğini unutmayın; bu nedenle bu, düzgün görüntülenebilecek veya görüntülenmeyebilecek bir öneridir. Eğer `GamesPlayedWhileIdle` ayarını bu seçenekle birlikte kullanıyorsanız, `GamesPlayedWhileIdle` öncelikli olduğundan bu listede en fazla `31` oyun belirtebileceğinizi unutmayın. Aksi takdirde, `CustomGamePlayedWhileIdle` özel ad için gereken slotu kullanamaz. Varsayılan `null` değeri bu özelliği devre dışı bırakır.



---



### `Etkin`

Varsayılan değeri `false` olan `bool` türü. Bu özellik botun etkin olup olmadığını tanımlar. Etkinleştirilmiş bir bot örneği (`true`) ASF çalıştığında otomatik olarak başlarken, devre dışı bırakılmış bir bot örneğinin (`false`) manuel olarak başlatılması gerekir. Varsayılan olarak her bot devre dışıdır, bu nedenle otomatik olarak başlatılması gereken tüm botlarınız için bu özelliği `true` olarak değiştirmek isteyebilirsiniz.



---



### `FarmingOrders`

Varsayılan değeri boş olan `ImmutableList<byte>` türü. Bu özellik, ASF tarafından belirli bir bot hesabı için kullanılan **tercih edilen** kart düşürme sırasını tanımlar. Şu anda aşağıdaki kart düşürme sıralamaları mevcuttur:

| Değer | Ad                          | Açıklama                                                                                                                      |
| ----- | --------------------------- | ----------------------------------------------------------------------------------------------------------------------------- |
| 0     | Sırasız                     | Sıralama yok, işlemci performansını bir miktar artırır                                                                        |
| 1     | AppID Artan                 | Önce en düşük `appID`'ye sahip oyunları düşürmeyi dener                                                                       |
| 2     | AppID Azalan                | Önce en yüksek `appID`'ye sahip oyunları düşürmeyi dener                                                                      |
| 3     | Kalan Kart Artan            | Önce en az sayıda kartı kalmış oyunları düşürmeyi dener                                                                       |
| 4     | Kalan Kart Azalan           | Önce en çok sayıda kartı kalmış oyunları düşürmeyi dener                                                                      |
| 5     | Oynama Süresi Artan         | Önce en az oynanmış oyunları düşürmeyi dener                                                                                  |
| 6     | Oynama Süresi Azalan        | Önce en çok oynanmış oyunları düşürmeyi dener                                                                                 |
| 7     | Ada Göre Artan              | Oyunları A'dan başlayarak alfabetik sırayla düşürmeyi dener                                                                   |
| 8     | Ada Göre Azalan             | Oyunları Z'den başlayarak ters alfabetik sırayla düşürmeyi dener                                                              |
| 9     | Rastgele                    | Oyunları tamamen rastgele bir sırada (programın her çalıştırılışında farklı) düşürmeyi dener                                  |
| 10    | Rozet Seviyesi Artan        | Önce en düşük rozet seviyesine sahip oyunları düşürmeyi dener                                                                 |
| 11    | Rozet Seviyesi Azalan       | Önce en yüksek rozet seviyesine sahip oyunları düşürmeyi dener                                                                |
| 12    | Etkinleştirme Tarihi Artan  | Önce hesaptaki en eski oyunları düşürmeyi dener                                                                               |
| 13    | Etkinleştirme Tarihi Azalan | Önce hesaptaki en yeni oyunları düşürmeyi dener                                                                               |
| 14    | Pazarlanabilirlik Artan     | Öncelikle satılamayan kart düşüşlerine sahip oyunları oynayarak farm yapmayı deneyin (uyarı: hesaplaması pahalıdır)           |
| 15    | Pazarlanabilirlik Azalan    | Öncelikle pazarlanabilir kart düşürme oranlarına sahip oyunları oynayarak farm yapmayı deneyin (uyarı: hesaplaması pahalıdır) |


Bu özellik bir dizi olduğundan, sabit bir sırada birkaç farklı ayar kullanmanıza olanak tanır. Örneğin, önce pazarlanabilir oyunlara, sonra en yüksek rozet seviyesine sahip olanlara ve son olarak da alfabetik sıraya göre sıralamak için `15`, `11` ve `7` değerlerini ekleyebilirsiniz. Tahmin edebileceğiniz gibi, sıra gerçekten önemlidir, çünkü ters sıra (`7`, `11` ve `15`) tamamen farklı bir sonuç elde eder (önce oyunları alfabetik olarak sıralar ve oyun adları benzersiz olduğu için diğer iki sıralama etkisiz kalır). Çoğu insan muhtemelen hepsi arasından yalnızca bir sıralama türü kullanacaktır, ancak isterseniz ek parametrelerle daha fazla sıralama yapabilirsiniz.

Ayrıca yukarıdaki tüm açıklamalardaki "dener" kelimesine dikkat edin - gerçek ASF sıralaması, seçilen **[kart düşürme algoritmasından](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-tr-TR)** büyük ölçüde etkilenir ve sıralama yalnızca ASF'nin performans açısından aynı kabul ettiği sonuçları etkiler. Örneğin, `Simple` (Basit) algoritmasında, seçilen `FarmingOrders` mevcut kart düşürme oturumunda tamamen uygulanmalıdır (çünkü her oyun aynı performans değerine sahiptir). `Complex` (Karmaşık) algoritmasında ise gerçek sıra önce oynama süresinden etkilenir, ardından seçilen `FarmingOrders`'a göre sıralanır. Bu farklı sonuçlara yol açacaktır, çünkü mevcut oynama süresine sahip oyunlar diğerlerine göre öncelikli olacaktır. Yani ASF, önce gerekli `HoursUntilCardDrops` süresini geçmiş oyunları tercih edecek ve ancak ondan sonra bu oyunları seçtiğiniz `FarmingOrders`'a göre sıralayacaktır. Benzer şekilde, ASF oynama süresi artırılmış oyunları bitirdiğinde, kalan sırayı önce oynama süresine göre sıralayacaktır (çünkü bu, kalan oyunlardan herhangi birinin süresini `HoursUntilCardDrops` değerine ulaştırmak için gereken zamanı azaltacaktır). Bu nedenle, bu yapılandırma özelliği yalnızca bir **öneridir** ve ASF, performansı olumsuz etkilemediği sürece (bu durumda, ASF her zaman `FarmingOrders` yerine kart düşürme performansını tercih edecektir) buna uymaya çalışacaktır.

Ayrıca, `fq` **[komutları](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-tr-TR)** aracılığıyla erişilebilen bir kart düşürme öncelik sırası da vardır. Eğer bu sıra kullanılıyorsa, gerçek kart düşürme sırası önce performansa, sonra öncelik sırasına ve son olarak da sizin `FarmingOrders` ayarınıza göre belirlenir.



---



### `FarmingPreferences`

Varsayılan değeri `0` olan `byte flags` türü. Bu özellik, ASF'nin kart düşürme ile ilgili davranışını tanımlar ve aşağıdaki gibi tanımlanmıştır:

| Değer | Ad                        |
| ----- | ------------------------- |
| 0     | Hiçbiri                   |
| 1     | FarmingPausedByDefault    |
| 2     | ShutdownOnFarmingFinished |
| 4     | SendOnFarmingFinished     |
| 8     | FarmPriorityQueueOnly     |
| 16    | SkipRefundableGames       |
| 32    | SkipUnplayedGames         |
| 64    | EnableRiskyCardsDiscovery |
| 256   | AutoUnpackBoosterPacks    |


Bu özelliğin bir `flags` (bayrak) alanı olduğunu, bu nedenle mevcut değerlerin herhangi bir kombinasyonunu seçmenin mümkün olduğunu lütfen unutmayın. Daha fazla bilgi edinmek isterseniz **[JSON eşlemesi](#json-eslemesi)** bölümüne göz atın. Hiçbir bayrağın etkinleştirilmemesi `None` (Hiçbiri) seçeneğiyle sonuçlanır.

Tüm seçenekler aşağıda açıklanmıştır.

`FarmingPausedByDefault`, `CardsFarmer` modülünün başlangıç durumunu tanımlar. Normalde bot, `Enabled` ayarı veya `start` komutuyla başlatıldığında otomatik olarak kart düşürmeye başlar. Otomatik kart düşürme sürecini manuel olarak `resume` komutuyla başlatmak istiyorsanız `FarmingPausedByDefault` kullanabilirsiniz. Örneğin, sürekli `play` komutunu kullanmak ve otomatik `CardsFarmer` modülünü hiç kullanmamak istiyorsanız bu ayar işinize yarar. Bu, `pause` **[komutuyla](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-tr-TR)** tamamen aynı şekilde çalışır.

`ShutdownOnFarmingFinished`, kart düşürme işlemi bittiğinde botun kapanmasını sağlar. Normalde ASF, süreç aktif olduğu sürece bir hesabı "meşgul eder". Bir hesabın kart düşürme işlemi bittiğinde, ASF periyodik olarak (her `IdleFarmingPeriod` saatte bir) o hesabı kontrol eder ve bu sırada Steam kartlı yeni oyunlar eklenmişse, süreci yeniden başlatmaya gerek kalmadan kart düşürmeye devam edebilir. Bu, çoğu insan için kullanışlıdır, çünkü ASF gerektiğinde kart düşürmeye otomatik olarak devam edebilir. Ancak, belirli bir hesabın kart düşürme işlemi tamamen bittiğinde süreci durdurmak isteyebilirsiniz; bu bayrağı kullanarak bunu başarabilirsiniz. Etkinleştirildiğinde, bir hesabın kart düşürme işlemi tamamen bittiğinde ASF oturumu kapatır. Bu, hesabın artık periyodik olarak kontrol edilmeyeceği veya meşgul edilmeyeceği anlamına gelir. ASF'nin belirli bir bot örneğinde sürekli mi çalışmasını, yoksa kart düşürme süreci bittiğinde mi durmasını istediğinize kendiniz karar vermelisiniz.

Bu seçenek, en mantıklı şekilde `ShutdownIfPossible` ile birlikte kullanılır. Böylece tüm hesaplar durduğunda ASF de kapanır, makinenizi dinlenmeye alır ve son kartın düştüğü anda uyku veya kapatma gibi diğer eylemleri zamanlamanıza olanak tanır.

`SendOnFarmingFinished`, o ana kadar düşürülen her şeyi içeren bir Steam takasını `Master` yetkisine sahip kullanıcıya otomatik olarak göndermenizi sağlar. Bu, takaslarla kendiniz uğraşmak istemiyorsanız çok kullanışlıdır. Bu seçenek `loot` komutuyla aynı şekilde çalışır. Bu nedenle, `Master` yetkisine sahip bir kullanıcı gerektirdiğini, ayrıca geçerli bir `SteamTradeToken`'a ve en başından takas yapmaya uygun bir hesaba ihtiyacınız olabileceğini unutmayın. Kart düşürme bittikten sonra `loot` başlatmaya ek olarak, bu seçenek etkinken ASF, her yeni eşya bildiriminde (kart düşürmüyorken) ve yeni eşyalarla sonuçlanan her takası tamamladıktan sonra (her zaman) `loot` işlemini başlatır. Bu, özellikle diğer insanlardan alınan eşyaları hesabımıza "yönlendirmek" için kullanışlıdır. Genellikle bu özellikle birlikte **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-tr-TR)** kullanmak istersiniz, ancak 2FA onaylarını zamanında manuel olarak halletmeyi planlıyorsanız bu bir zorunluluk değildir.

`FarmPriorityQueueOnly`, ASF'nin otomatik kart düşürme için yalnızca `fq` **[komutları](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-tr-TR)** ile öncelikli düşürme sırasına eklediğiniz uygulamaları dikkate alıp almayacağını tanımlar. Bu seçenek etkinleştirildiğinde, ASF listede olmayan tüm `appID`'leri atlar, bu da otomatik ASF kart düşürme için oyunları özenle seçmenize olanak tanır. Sıraya hiç oyun eklemediyseniz, ASF'nin hesabınızda düşürülecek hiçbir şey yokmuş gibi davranacağını unutmayın.

`SkipRefundableGames`, ASF'nin hala iade edilebilir olan oyunları otomatik kart düşürme işleminden atlayıp atlamayacağını tanımlar. İade edilebilir bir oyun, **[Steam iadeleri](https://store.steampowered.com/steam_refunds?l=turkish)** sayfasında belirtildiği gibi, son 2 hafta içinde Steam Mağazasından satın aldığınız ve henüz 2 saatten fazla oynamadığınız bir oyundur. Varsayılan olarak ASF, çoğu insanın bekleyeceği gibi, Steam iade politikasını tamamen görmezden gelir ve her şeyi düşürür. Ancak, ASF'nin iade edilebilir oyunlarınızdan herhangi birini çok erken düşürmeyeceğinden emin olmak isterseniz bu bayrağı kullanabilirsiniz. Bu, bu oyunları kendiniz değerlendirmenize ve ASF'nin oynama süresini olumsuz etkilemesinden endişe etmeden gerekirse iade etmenize olanak tanır. Bu seçeneği etkinleştirirseniz, Steam Mağazasından satın aldığınız oyunların, satın alma tarihinden itibaren 14 güne kadar ASF tarafından düşürülmeyeceğini lütfen unutmayın. Bu durum, hesabınızda başka bir şey yoksa düşürülecek bir şey yok olarak görünecektir.

`SkipUnplayedGames`, ASF'nin henüz hiç başlatmadığınız oyunları atlayıp atlamayacağını tanımlar. Bu bağlamda oynanmamış oyun, Steam'de o oyun için kaydedilmiş sıfır oynama süreniz olduğu anlamına gelir. Bu bayrağı kullanırsanız, bu tür oyunlar Steam onlar için herhangi bir oynama süresi kaydedene kadar atlanır. Bu, ASF'nin hangi oyunları düşürmeye uygun olduğunu daha iyi kontrol etmenizi sağlar, henüz deneme şansınız olmayanları atlayarak, oynanmamış oyunları oynamayı önermek gibi belirli Steam özelliklerini daha kullanışlı hale getirir.

`EnableRiskyCardsDiscovery`, ASF bir veya daha fazla rozet sayfasını yükleyemediğinde ve bu nedenle kart düşürmek için uygun oyunları bulamadığında tetiklenen ek bir yedek mekanizmayı etkinleştirir. Özellikle, çok büyük miktarda kart düşürme hakkı olan bazı hesaplar, rozet sayfalarının yüklenmesinin artık mümkün olmadığı (aşırı yük nedeniyle) bir duruma neden olabilir ve bu hesaplar, süreci başlatabileceğimiz bilgileri yükleyemediğimiz için kart düşürmeye uygun olmaz. Bu nadir durumlar için bu seçenek, potansiyel olarak boşta bırakılabilecek oyunları bulmak amacıyla, işlenebilecek takviye paketleri ile hesabın uygun olduğu takviye paketlerinin bir kombinasyonunu kullanan alternatif bir algoritmanın kullanılmasını sağlar. Ardından, gerekli bilgileri doğrulamak ve getirmek için aşırı miktarda kaynak harcar ve en sonunda rozet sayfasının yüklendiği ve normal yaklaşımı kullanabileceğimiz bir duruma ulaşmak için sınırlı veri ve bilgiyle kart düşürme sürecini başlatmaya çalışır. Bu yedek mekanizma kullanıldığında ASF'nin yalnızca sınırlı veriyle çalıştığını, bu nedenle ASF'nin gerçekte olduğundan çok daha az kart düşürme hakkı bulmasının tamamen normal olduğunu lütfen unutmayın - diğer düşürme hakları kart düşürme sürecinin ilerleyen aşamalarında bulunacaktır.

Bu seçeneğin "riskli" olarak adlandırılmasının çok iyi bir nedeni var: çalışması son derece yavaştır ve önemli miktarda kaynak (ağ istekleri dahil) gerektirir. Bu nedenle, özellikle uzun vadede etkinleştirilmesi **önerilmez**. Bu seçeneği yalnızca, hesabınızın rozet sayfalarını yükleyememe sorunu yaşadığını ve ASF'nin bu hesapta çalışamadığını, süreci başlatmak için gerekli bilgileri her zaman yükleyemediğini daha önce belirlediyseniz kullanmalısınız. Süreci mümkün olduğunca optimize etmek için elimizden gelenin en iyisini yapmış olsak da, bu seçeneğin geri tepmesi ve çok fazla istek göndererek veya Steam sunucularında aşırı yük oluşturarak Steam tarafından geçici ve hatta kalıcı yasaklamalar gibi istenmeyen sonuçlara yol açması hala mümkündür. Bu nedenle sizi önceden uyarıyoruz ve bu seçeneği kesinlikle hiçbir garanti vermeden sunuyoruz; bunu kendi sorumluluğunuzda kullanırsınız.

`AutoUnpackBoosterPacks`, yeni eşya bildirimi alındığında tüm takviye paketlerini otomatik olarak açar. Bu, anında ek kart düşürme hakları elde etmenizi sağlar; bu, özellikle diğer seçeneklerle (örneğin `SteamTradeMatcher` veya `CompleteTypesToSend`) birleştirildiğinde istenen bir senaryo olabilir.



---



### `GamesPlayedWhileIdle`

Varsayılan değeri boş olan `ImmutableHashSet<uint>` türü. Eğer ASF'nin düşürecek bir kartı yoksa, bunun yerine sizin belirlediğiniz Steam oyunlarını (`appID`'ler) oynayabilir. Oyunları bu şekilde oynamak, o oyunlardaki "oynanan saat" sayınızı artırır, ancak bunun dışında bir işlevi yoktur. Bu özelliğin düzgün çalışması için Steam hesabınızın, burada belirttiğiniz tüm `appID`'ler için geçerli bir lisansa sahip olması **gerekir**; buna oynaması ücretsiz oyunlar da dahildir. Bu özellik, Steam ağında özel bir durum gösterirken seçtiğiniz oyunları oynamak için `CustomGamePlayedWhileIdle` ile aynı anda etkinleştirilebilir. Ancak bu durumda, `CustomGamePlayedWhileFarming` örneğinde olduğu gibi, gerçek görüntüleme sırası garanti edilmez. Lütfen Steam'in ASF'nin toplamda en fazla `32` `appID` oynamasına izin verdiğini, bu nedenle bu özelliğe yalnızca bu kadar oyun ekleyebileceğinizi unutmayın.



---



### `GamingDeviceType`

Varsayılan değeri `1` olan `ushort` türü. Bu özellik, Steam platformunda bazı ek çevrimiçi özellikleri etkinleştirebilir ve aşağıdaki gibi tanımlanmıştır:

| Değer | Ad         | Açıklama                              |
| ----- | ---------- | ------------------------------------- |
| 1     | StandardPC | Özel mod yok, varsayılan              |
| 544   | SteamDeck  | Kendisini Steam Deck olarak tanıtıyor |


Bu özelliğin dayandığı temel `EGamingDeviceType` türü daha fazla kullanılabilir değer içermektedir; ancak bildiğimiz kadarıyla bugün itibariyle bunların hiçbir etkisi yoktur, bu nedenle görünürlük açısından silinmişlerdir.

Bu özelliği nasıl ayarlayacağınızdan emin değilseniz, varsayılan değeri `1` olarak bırakabilirsiniz.



---



### `HoursUntilCardDrops`

Varsayılan değeri `3` olan `byte` türü. Bu özellik, bir hesabın kart düşürme kısıtlaması olup olmadığını ve eğer varsa, bu kısıtlamanın ilk kaç saat için geçerli olduğunu tanımlar. Kısıtlanmış kart düşürme, bir hesabın ilgili oyunu en az `HoursUntilCardDrops` saat oynamadan o oyundan herhangi bir kart düşürme hakkı almayacağı anlamına gelir. Ne yazık ki bunu tespit etmenin sihirli bir yolu yoktur, bu yüzden ASF bu konuda size güvenir. Bu özellik, kullanılacak olan **[kart düşürme algoritmasını](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-tr-TR)** etkiler. Bu özelliği doğru şekilde ayarlamak, kârı en üst düzeye çıkaracak ve kartların düşürülmesi için gereken süreyi en aza indirecektir. Hangi değeri kullanmanız gerektiğine dair kesin bir cevap olmadığını unutmayın, çünkü bu tamamen hesabınıza bağlıdır. Görünüşe göre, hiç iade talebinde bulunmamış eski hesapların kısıtlamasız kart düşürme hakları var, bu yüzden `0` değerini kullanmalılar. Yeni hesaplar ve iade talebinde bulunmuş olanlar ise `3` değerinde bir kısıtlamaya sahip. Ancak bu sadece bir teoridir ve bir kural olarak kabul edilmemelidir. Bu özelliğin varsayılan değeri, "ehvenişer" ilkesine ve çoğunluğun kullanım senaryolarına göre belirlenmiştir.



---



### `LootableTypes`

Varsayılan değeri `1, 3, 5` Steam eşya türlerini içeren `ImmutableHashSet<byte>` türü. Bu özellik, ASF'nin hem bir **[komut](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-tr-TR)** kullanarak manuel olarak, hem de bir veya daha fazla yapılandırma özelliği aracılığıyla otomatik olarak "loot" yaparken (eşya toplarken/gönderirken) davranışını tanımlar. ASF, yalnızca `LootableTypes` içindeki eşyaların bir takas teklifine dahil edilmesini sağlar. Bu nedenle bu özellik, size gönderilen bir takas teklifinde ne almak istediğinizi seçmenize olanak tanır.

| Değer | Ad                       | Açıklama                                                               |
| ----- | ------------------------ | ---------------------------------------------------------------------- |
| 0     | Bilinmeyen               | Aşağıdakilerden herhangi birine uymayan her tür                        |
| 1     | Takviye Paketi           | Bir oyundan 3 rastgele kart içeren takviye paketi                      |
| 2     | İfade                    | Steam Sohbetinde kullanılacak ifade                                    |
| 3     | Parlak Koleksiyon Kartı  | `TradingCard`'ın parlak (foil) versiyonu                               |
| 4     | Profil Arka Planı        | Steam profilinizde kullanmak için profil arka planı                    |
| 5     | Koleksiyon Kartı         | Rozet işlemek için kullanılan Steam koleksiyon kartı (parlak olmayan)  |
| 6     | Steam Cevherleri         | Takviye paketi yapmak için kullanılan Steam cevherleri (keseler dahil) |
| 7     | İndirim Eşyası           | Steam indirimleri sırasında verilen özel eşyalar                       |
| 8     | Tüketilebilir Eşya       | Kullanıldıktan sonra kaybolan özel tüketilebilir eşyalar               |
| 9     | Profil Düzenleyici       | Steam profilinin görünümünü değiştirebilen özel eşyalar                |
| 10    | Çıkartma                 | Steam sohbetinde kullanılabilecek özel eşyalar                         |
| 11    | Sohbet Efekti            | Steam sohbetinde kullanılabilecek özel eşyalar                         |
| 12    | Mini Profil Arka Planı   | Steam profili için özel arka plan                                      |
| 13    | Avatar Profili Çerçevesi | Steam profili için özel avatar çerçevesi                               |
| 14    | Animasyonlu Avatar       | Steam profili için özel animasyonlu avatar                             |
| 15    | Klavye Teması            | Steam Deck için özel klavye teması                                     |
| 16    | Başlangıç Videosu        | Steam Deck için özel başlangıç videosu                                 |


Lütfen yukarıdaki ayarlardan bağımsız olarak, ASF'nin yalnızca **[Steam Topluluğu eşyaları](https://steamcommunity.com/my/inventory/#753_6)** (`appID` 753, `contextID` 6) için istek yapacağını unutmayın. Dolayısıyla tüm oyun eşyaları, hediyeler ve benzerleri tanım gereği takas teklifinden hariç tutulur.

Varsayılan ASF ayarı, botun en yaygın kullanımına dayanır ve yalnızca takviye paketlerini ve koleksiyon kartlarını (parlak olanlar dahil) toplamayı içerir. Burada tanımlanan özellik, bu davranışı sizi memnun edecek şekilde değiştirmenize olanak tanır. Lütfen yukarıda tanımlanmayan tüm türlerin `Bilinmeyen` türü olarak gösterileceğini unutmayın. Bu, Valve yeni bir Steam eşyası yayınladığında özellikle önemlidir, çünkü bu eşya buraya eklenene kadar (gelecekteki bir sürümde) ASF tarafından da `Bilinmeyen` olarak işaretlenecektir. Bu nedenle, ne yaptığınızı bilmiyorsanız ve Steam Ağı tekrar bozulup tüm eşyalarınızı `Bilinmeyen` olarak bildirirse ASF'nin tüm envanterinizi bir takas teklifinde göndereceğini anlamıyorsanız, `LootableTypes` listenize `Bilinmeyen` türünü eklemeniz genellikle önerilmez. Her şeyi (ve diğerlerini) toplamayı bekleseniz bile, `LootableTypes` listenize `Bilinmeyen` türünü dahil etmemenizi şiddetle tavsiye ederim.



---



### `MachineName`

Varsayılan değeri `null` olan `string` türü. ASF, Steam ağına giriş yaparken bu özelliği kullanacak; bu özellik, Steam'in ASF makinesini ve oturumunu tam olarak nasıl görüntüleyeceğine ilişkin özelleştirme için kullanılabilir, örneğin şu anda oturum açmış olan cihazları görüntülerken **[burada](https://store.steampowered.com/account/authorizeddevices)**.

ASF, metninizde isteğe bağlı olarak kullanabileceğiniz birkaç özel değişken sunar. `{0}`, işletim sisteminiz tarafından sağlanan makine adıyla, `{1}`, ASF'nin genel tanımlayıcısıyla ve `{2}` ise ASF'nin sürümüyle değiştirilecektir.

Ne yaptığınızı bilmiyorsanız, varsayılan değer olan `null` değerini kullanmalısınız. Bu durumda, ASF, bugün itibariyle `{0} ({1}/{2})` olan uygun değere dahili olarak karar verecektir. Unutmayın ki bu sadece bir öneridir ve Steam ağı bunu tamamen dikkate alabilir veya almayabilir.



---



### `MatchableTypes`

Varsayılan değeri `5` Steam eşya türünü içeren `ImmutableHashSet<byte>` türü. Bu özellik, `TradingPreferences` içindeki `SteamTradeMatcher` seçeneği etkinleştirildiğinde hangi Steam eşya türlerinin eşleştirilmesine izin verildiğini tanımlar. Türler aşağıda tanımlanmıştır:

| Değer | İsim                     | Açıklama                                                               |
| ----- | ------------------------ | ---------------------------------------------------------------------- |
| 0     | Bilinmeyen               | Aşağıdakilerden herhangi birine uymayan her tür                        |
| 1     | Takviye Paketi           | Bir oyundan 3 rastgele kart içeren takviye paketi                      |
| 2     | İfade                    | Steam Sohbetinde kullanılacak ifade                                    |
| 3     | Parlak Koleksiyon Kartı  | `TradingCard`'ın parlak (foil) versiyonu                               |
| 4     | Profil Arka Planı        | Steam profilinizde kullanmak için profil arka planı                    |
| 5     | Koleksiyon Kartı         | Rozet işlemek için kullanılan Steam koleksiyon kartı (parlak olmayan)  |
| 6     | Steam Cevherleri         | Takviye paketi yapmak için kullanılan Steam cevherleri (keseler dahil) |
| 7     | İndirim Eşyası           | Steam indirimleri sırasında verilen özel eşyalar                       |
| 8     | Tüketilebilir Eşya       | Kullanıldıktan sonra kaybolan özel tüketilebilir eşyalar               |
| 9     | Profil Düzenleyici       | Steam profilinin görünümünü değiştirebilen özel eşyalar                |
| 10    | Çıkartma                 | Steam sohbetinde kullanılabilecek özel eşyalar                         |
| 11    | Sohbet Efekti            | Steam sohbetinde kullanılabilecek özel eşyalar                         |
| 12    | Mini Profil Arka Planı   | Steam profili için özel arka plan                                      |
| 13    | Avatar Profili Çerçevesi | Steam profili için özel avatar çerçevesi                               |
| 14    | Animasyonlu Avatar       | Steam profili için özel animasyonlu avatar                             |
| 15    | Klavye Teması            | Steam Deck için özel klavye teması                                     |
| 16    | Başlangıç Videosu        | Steam Deck için özel başlangıç videosu                                 |


Elbette, bu özellik için kullanmanız gereken türler genellikle yalnızca `2`, `3`, `4` ve `5`'i içerir, çünkü sadece bu türler STM tarafından desteklenmektedir. ASF, öğelerin nadirliğini keşfetmek için uygun bir mantık içerir, bu nedenle ASF aynı oyun ve türden, aynı nadirliği paylaşan öğeleri adil olarak kabul edecektir.

Lütfen **ASF'nin bir takas botu olmadığını** ve **piyasa fiyatıyla ilgilenmeyeceğini** unutmayın. Aynı nadirlikteki öğeleri aynı fiyatta kabul etmiyorsanız, bu seçenek sizin için DEĞİLDİR. Bu ayarı değiştirmeye karar vermeden önce bu ifadeyi anladığınızdan ve kabul ettiğinizden emin olun.

Ne yaptığınızı bilmiyorsanız, varsayılan değeri olan `5` ile bırakmalısınız.



---



### `OnlineFlags`

Varsayılan değeri `0` olan `ushort flags` türü. Bu özellik, **[`OnlineStatus`](#onlinestatus)** için ek bir çevrimiçi varlık özelliği olarak çalışır ve Steam ağına duyurulan ek çevrimiçi varlık özelliklerini belirtir. `Offline` dışındaki **[`OnlineStatus`](#onlinestatus)** gerektirir ve aşağıda tanımlanmıştır:

| Değer | İsim               | Açıklama                                             |
| ----- | ------------------ | ---------------------------------------------------- |
| 0     | Hiçbiri            | Özel çevrimiçi varlık bayrağı yok, varsayılan        |
| 2     | InJoinableGame     | Client is in joinable game                           |
| 8     | RemotePlayTogether | İstemci uzaktan birlikte oynama oturumunu kullanıyor |
| 256   | ClientTypeWeb      | İstemci web arayüzünü kullanıyor                     |
| 512   | ClientTypeMobile   | İstemci mobil uygulamayı kullanıyor                  |
| 1024  | ClientTypeTenfoot  | Client is using big picture                          |
| 2048  | ClientTypeVR       | İstemci VR başlığını kullanıyor                      |


Lütfen bu özelliğin `flags` alanı olduğunu ve bu nedenle mevcut değerlerin herhangi bir kombinasyonunun seçilebileceğini unutmayın. Daha fazla bilgi edinmek isterseniz **[json eşlemesi](#json-mapping)** konusuna göz atın. Bayrakların hiçbirini etkinleştirmemek `None` seçeneğiyle sonuçlanır.

Bu özelliğin temel aldığı `EPersonaStateFlag` türü, daha fazla kullanılabilir bayrak içerir, ancak bildiğimiz kadarıyla bunların hiçbir etkisi yoktur, bu nedenle görünürlük için kesilmişlerdir.

Bu özelliği nasıl ayarlayacağınızdan emin değilseniz, varsayılan değeri `0` olarak bırakabilirsiniz.



---



### `OnlineStatus`

Varsayılan değeri `1` olan `byte` türü. Bu özellik, botun Steam ağına giriş yaptıktan sonra duyurulacağı Steam topluluk durumunu belirtir. Şu anda aşağıdaki durumlardan birini seçebilirsiniz:

| Değer | İsim            |
| ----- | --------------- |
| 0     | Çevrimdışı      |
| 1     | Çevrimiçi       |
| 2     | Busy            |
| 3     | Away            |
| 4     | Snooze          |
| 5     | LookingToTrade  |
| 6     | Oynamak İstiyor |
| 7     | Görünmez        |


`Çevrimdışı` durumu birincil hesaplar için son derece kullanışlıdır. Bildiğiniz gibi, bir oyunu farmlamak aslında Steam durumunuzu "Oyun oynuyor: XXX" olarak gösterir, bu da arkadaşlarınızı yanıltabilir, oyunu oynadığınızı sanmalarına neden olabilir, oysa aslında sadece kart farmlıyorsunuzdur. `Çevrimdışı` durumu bu sorunu çözer - hesabınız ASF ile Steam kartlarını farmlarken asla "oyunda" olarak gösterilmeyecektir. Bu, ASF'nin düzgün çalışması için Steam Topluluğu'na giriş yapmasına gerek olmadığı için mümkündür, yani aslında bu oyunları oynuyoruz, Steam ağına bağlıyız, ancak çevrimiçi varlığımızı hiç duyurmadan. Çevrimdışı durumdayken oynanan oyunların oyun sürenize katkıda bulunacağını ve profilinizde "son zamanlarda oynandı" olarak görüneceğini unutmayın.

Ek olarak, ASF çalışırken bildirimleri ve okunmamış mesajları almak istiyorsanız, ancak aynı zamanda Steam istemcisini açık tutmak istemiyorsanız, bu özellik de önemlidir. Bu, ASF'nin aslında bir Steam istemcisi gibi davrandığı için, ve istemese de, Steam tüm bu mesajları ve diğer olayları ona yayınlar. Hem ASF hem de kendi Steam istemciniz çalışıyorsa bu sorun değildir, çünkü her iki istemci de tam olarak aynı olayları alır. Ancak, sadece ASF çalışıyorsa, Steam ağı belirli olayları ve mesajları "teslim edildi" olarak işaretleyebilir, bu da geleneksel Steam istemcinizin mevcut olmadığından dolayı alamayacağı anlamına gelir. Çevrimdışı durumu bu sorunu da çözer, çünkü ASF bu durumda topluluk olayları için asla dikkate alınmaz, bu nedenle geri döndüğünüzde tüm okunmamış mesajlar ve diğer olaylar düzgün bir şekilde okunmamış olarak işaretlenir.

ASF'nin `Çevrimdışı` modda çalışmasının, genellikle Steam sohbet yoluyla komut alamayacağına dikkat etmek önemlidir, çünkü sohbet ve tüm topluluk varlığı aslında tamamen çevrimdışıdır. Bu soruna bir çözüm, benzer şekilde çalışırken (durumu gizlemek), ancak mesajları alıp yanıtlamaya devam eden (dolayısıyla yukarıda belirtilen bildirimleri ve okunmamış mesajları reddetme potansiyeline sahip) `Görünmez` modunu kullanmaktır. `Görünmez` modu, durumu göstermek istemediğiniz alt hesaplarda, ancak yine de komut gönderebilmek istediğinizde en mantıklısıdır.

Ancak, `Görünmez` modun bir sorunu vardır - birincil hesaplarda iyi çalışmaz. Bunun nedeni, **çevrimiçi olan** herhangi bir Steam oturumunun, ASF'nin kendisi yapmasa bile, durumu **açığa çıkarmasıdır**. Bu, ASF tarafında çözülemeyen mevcut bir Steam ağı sınırlaması/hatası nedeniyle oluşur, bu nedenle `Görünmez` modunu kullanmak istiyorsanız, aynı hesaba yapılan **tüm** diğer oturumların da `Görünmez` modunu kullanmasını sağlamanız gerekecektir. Bu, ASF'nin umarım tek aktif oturum olduğu alt hesaplarda geçerli olacaktır, ancak birincil hesaplarda neredeyse her zaman arkadaşlarınıza `Çevrimiçi` olarak görünmeyi tercih edeceksiniz, yalnızca ASF etkinliğini gizleyeceksiniz ve bu durumda `Görünmez` modunu kullanmak sizin için tamamen işe yaramaz (bu durumda `Çevrimdışı` modunu kullanmanızı öneririz). Valve'in bu sınırlamayı/hatasını gelecekte çözeceğini umuyoruz, ancak bunun yakın zamanda gerçekleşmesini beklemem.

Bu özelliği nasıl yapılandıracağınızdan emin değilseniz, birincil hesaplar için `0` (`Çevrimdışı`) ve diğer durumlarda varsayılan `1` (`Çevrimiçi`) değerini kullanmanız önerilir.



---



### `PasswordFormat`

`byte` type with default value of `0` (`PlainText`). Varsayılan değeri `0` (`Düz Metin`) olan `byte` türündeki bu özellik, `SteamPassword` özelliğinin formatını tanımlar ve şu anda **[güvenlik](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** bölümünde belirtilen değerleri destekler. Bu yönergeleri takip etmelisiniz, çünkü `SteamPassword` özelliğinin gerçekten belirtilen `PasswordFormat` formatında olduğundan emin olmanız gerekecektir. Başka bir deyişle, `PasswordFormat`'ı değiştirdiğinizde `SteamPassword`'ınız **zaten** bu formatta olmalıdır, sadece bu formatta olmaya çalışmak yeterli değildir. Ne yaptığınızı bilmiyorsanız, varsayılan değeri olan `0` ile bırakmalısınız.

Eğer bir botun `PasswordFormat`'ını Steam ağına en az bir kez giriş yapmış bir botta değiştirirseniz, bir sonraki bot başlatmasında bir kezlik bir şifre çözme hatası alabilirsiniz - bu, `PasswordFormat`'ın `Bot.db` veritabanı dosyasında hassas özelliklerin otomatik şifreleme/şifre çözme ile ilgili olarak da kullanılması nedeniyle oluşur. Bu hatayı güvenle göz ardı edebilirsiniz, çünkü ASF bu durumdan kendi başına kurtulabilir. Ancak, eğer bu sürekli bir durumsa, örneğin her yeniden başlatmada meydana geliyorsa, araştırılması gerekir.



---



### `RedeemingPreferences`

`byte flags` type with default value of `0`. This property defines ASF behaviour when redeeming cd-keys, and is defined as below:

| Değer | İsim                               | Açıklama                                                                                                                         |
| ----- | ---------------------------------- | -------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Hiçbiri                            | Özel çevirme tercihleri yok, varsayılan                                                                                          |
| 1     | Forwarding                         | Çevrilmesi mümkün olmayan anahtarları diğer botlara iletme                                                                       |
| 2     | Dağıtma                            | Tüm anahtarları kendisi ve diğer botlar arasında dağıtma                                                                         |
| 4     | Eksik Oyunları Sakla               | Keep keys for (potentially) missing games when forwarding, leaving them unused                                                   |
| 8     | AssumeWalletKeyOnBadActivationCode | `KötüEtkinlikKodu` anahtarlarını `Müşteriden ÇevrilemezKod` olarak varsay ve bu nedenle onları cüzdan anahtarları olarak çevirme |


Lütfen bu özelliğin `flags` alanı olduğuna dikkat edin, bu nedenle mevcut değerlerin herhangi bir kombinasyonunu seçmek mümkündür. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Bayraklardan hiçbirinin etkinleştirilmemesi `None` seçeneğiyle sonuçlanır.

`İletme` seçeneği, çevrilmesi mümkün olmayan bir anahtarı, eksik olan oyunu bulunan başka bir bağlı ve oturum açmış bota iletecektir (kontrol edilebiliyorsa). En yaygın durum, `ZatenSatınAlınmış` oyununu eksik olan başka bir bota iletmektir, ancak bu seçenek ayrıca `GerekliUygulamaSahibiDeğil`, `OranSınırlı` veya `KısıtlıÜlke` gibi diğer senaryoları da kapsar.

`Dağıtma` seçeneği, botun aldığı tüm anahtarları kendisi ve diğer botlar arasında dağıtmasına neden olur. Bu, her botun bir anahtar alacağı anlamına gelir. Genellikle bu, aynı oyun için birçok anahtar çevirdiğinizde ve bunları botlarınız arasında eşit şekilde dağıtmak istediğinizde kullanılır, çeşitli farklı oyunlar için anahtar çevirmektense. Bu özellik, tek bir `redeem` eyleminde sadece bir anahtar çeviriyorsanız (dağıtılacak ekstra anahtarlar olmadığı için) mantıklı değildir.

`Eksik Oyunları Sakla`, anahtarın gerçekten botumuza ait olup olmadığından emin olamadığımızda `İletme`'yi atlamasına neden olur. Bu, `İletme`'nin yalnızca `ZatenSatınAlınmış` anahtarlarına uygulanacağı anlamına gelir, ayrıca `GerekliUygulamaSahibiDeğil`, `OranSınırlı` veya `KısıtlıÜlke` gibi diğer durumları kapsamaz. Genellikle bu seçeneği birincil hesaplarda kullanmak istersiniz, böylece anahtarların çevirildiği hesabın daha sonra geçici olarak `OranSınırlı` hale gelmesi durumunda daha fazla iletilmeyecektir. Açıklamadan da tahmin edebileceğiniz gibi, `İletme` etkinleştirilmemişse bu alanın hiçbir etkisi yoktur.

`Kötü Etkinlik Kodu Üzerine Cüzdan Anahtarı Say` seçeneği, `KötüEtkinlikKodu` anahtarlarını `Müşteriden ÇevrilemezKod` olarak değerlendirilmesini sağlar ve bu nedenle ASF'nin bunları cüzdan anahtarları olarak çevirmeye çalışmasını sağlar. Steam, cüzdan anahtarlarını `KötüEtkinlikKodu` olarak duyurabilir (ve daha önce olduğu gibi `Müşteriden ÇevrilemezKod` olarak değil), bu da ASF'nin bunları çevirmeye asla teşebbüs etmemesine neden olur. Ancak, bu tercihi **karşısında** öneriyoruz, çünkü bu, ASF'nin her geçersiz anahtarı cüzdan kodu olarak çevirmeye çalışmasına neden olur ve bu da Steam hizmetine aşırı miktarda (potansiyel olarak geçersiz) istek gönderir, tüm potansiyel sonuçlarıyla birlikte. Bunun yerine, cüzdan anahtarlarını bilinçli olarak çevirirken `ForceAssumeWalletKey` **[`redeem^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** modunu kullanmanızı öneririz, bu, gerekli olduğunda sadece gerektiği şekilde çalıştırılacak bir geçici çözümü sağlar.

Hem `İletme` hem de `Dağıtma` seçeneğini etkinleştirmek, dağıtım özelliğini iletme özelliğinin üzerine ekler, bu da ASF'nin önce tüm botlarda bir anahtarı çevirmeye çalışacağı (iletme) ve ardından bir sonraki anahtara geçeceği (dağıtma) anlamına gelir. Bu seçeneği, `İletme`'yi kullanmak istediğinizde, ancak her anahtar ile sırayla gitmek yerine anahtarın kullanılması sırasında botu değiştirme davranışını istediğinizde kullanmak istersiniz (bu, yalnızca `İletme` olurdu). Bu davranış, anahtarlarınızın çoğunun hatta tümünün aynı oyuna bağlı olduğunu bildiğinizde faydalı olabilir, çünkü bu durumda `İletme` tek başına her şeyi önce bir botta çevirmeye çalışacaktır (anahtarlarınız benzersiz oyunlar içindir). Ancak `İletme` + `Dağıtma`, yeni anahtar çevirme görevini ilk bot yerine başka bir bota "dağıtarak" bir anahtarın "anlamsız" bir denemesini atlatarak, bu durumda mantıklıdır (anahtarlar aynı oyun içinse).

Tüm çevirme senaryoları için gerçek bot sırası alfabetiktir, kullanılabilir olmayan botlar hariç (bağlı değil, durdurulmuş veya benzeri). Lütfen, her IP ve hesap başına saatlik bir çevirme deneme sınırı olduğunu ve `OK` ile bitmeyen her çevirme denemesinin başarısız denemelere katkıda bulunduğunu unutmayın. ASF, `ZatenSatınAlınmış` hatalarını minimize etmek için elinden geleni yapacaktır, örneğin, anahtarın belirli bir oyuna sahip olduğu bir botta bir anahtarın iletilmesini önlemeye çalışarak, ancak Steam'in lisansları nasıl yönettiği nedeniyle her zaman çalışacağının garantisi yoktur. `İletme` veya `Dağıtma` gibi çevirme bayraklarını kullanmak, `OranSınırlı` olma olasılığınızı her zaman artıracaktır.

Ayrıca, anahtarları erişiminizin olmadığı botlara iletemez veya dağıtamazsınız. Bu açık olmalı, ancak çevirme sürecinize dahil etmek istediğiniz tüm botların en azından `Operatör` olduğundan emin olun, örneğin `status ASF` **[komutu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** ile.



---



### `RemoteCommunication`

Varsayılan değeri `0` olan `byte flags` türü. Bu özellik, cd-anahtarlarını çevirirken ASF'nin davranışını tanımlar ve aşağıda belirtilmiştir:

| Değer | İsim           | Açıklama                                                                                                                                                                                                                                                            |
| ----- | -------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Hiçbiri        | Üçüncü taraf iletişimine izin verilmez, bu da seçilen ASF özelliklerini kullanılamaz hale getirir                                                                                                                                                                   |
| 1     | SteamGrubu     | **[ASF'nin Steam grubuyla](https://steamcommunity.com/groups/archiasf)** iletişime izin verir                                                                                                                                                                       |
| 2     | GenelListeleme | **[ASF'nin STM listelemesiyle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** iletişime izin verir, eğer kullanıcı ayrıca **[`TradingPreferences`](#tradingpreferences)** bölümünde `SteamTradeMatcher`'ı etkinleştirmişse |


Lütfen bu özelliğin `flags` alanı olduğuna dikkat edin, bu nedenle mevcut değerlerin herhangi bir kombinasyonunu seçmek mümkündür. Daha fazla bilgi edinmek istiyorsanız **[json mapping](#json-mapping)** bölümüne göz atın. Bayraklardan hiçbirinin etkinleştirilmemesi `None` seçeneğiyle sonuçlanır.

Bu seçenek, ASF tarafından sunulan her üçüncü taraf iletişimini değil, yalnızca diğer ayarlar tarafından ima edilmeyenleri içerir. Örneğin, ASF'nin otomatik güncellemelerini etkinleştirdiyseniz, ASF, yapılandırmanıza göre hem GitHub (indirmeler için) hem de sunucumuzla (sağlama toplamı doğrulaması için) iletişim kuracaktır. Aynı şekilde, **[`TradingPreferences`](#tradingpreferences)** içinde `MatchActively` öğesini etkinleştirmek, bu işlevsellik için gerekli olan listelenen botları getirmek için sunucumuzla iletişim kurmayı gerektirir.

Bu konu hakkında daha fazla açıklama **[uzak iletişim](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** bölümünde mevcuttur. Bu özelliği düzenlemek için bir nedeniniz yoksa, varsayılan değerde tutmalısınız.



---



### `SendTradePeriod`

Varsayılan değeri `0` olan `byte` türü. Bu özellik, `FarmingPreferences` içindeki `SendOnFarmingFinished` tercihine çok benzer şekilde çalışır, tek bir farkla - çiftçilik bittiğinde ticaret göndermek yerine, ne kadar çiftçilik yapmamız gerektiğine bakılmaksızın, her `SendTradePeriod` saatte bir gönderebiliriz. sol. Çiftçiliği bitirmesini beklemek yerine alt hesaplarınızı normal olarak `loot` yapmak istiyorsanız bu kullanışlıdır. `0` varsayılan değeri bu özelliği devre dışı bırakır, botunuzun size örneğin her gün ticaret göndermesini istiyorsanız buraya `24` koymalısınız.

Genellikle bu özellikle birlikte **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** kullanmak isteyeceksiniz, ancak 2FA onaylarını zamanında manuel olarak işlemek istiyorsanız bu bir gereklilik değildir. Bu özelliği nasıl ayarlayacağınızdan emin değilseniz, varsayılan `0` değeriyle bırakın. If you're not sure how to set this property, leave it with default value of `0`.



---



### `SteamLogin`

Varsayılan değeri `null` olan `string` türü. Bu özellik, Steam girişinizi tanımlar - buhara giriş yapmak için kullandığınız özellik. Steam girişinizi buraya tanımlamanın yanı sıra, her ASF başlangıcında yapılandırmaya koymak yerine Steam girişinizi girmek istiyorsanız varsayılan `null` değerini de koruyabilirsiniz. Hassas verileri yapılandırma dosyasına kaydetmek istemiyorsanız bu sizin için yararlı olabilir.



---



### `SteamMasterClanID`

Varsayılan değeri `0` olan `ulong` türü. Bu özellik, botun grup sohbeti de dahil olmak üzere otomatik olarak katılması gereken buhar grubunun steamID'sini tanımlar. Grubunuzun steamID'sini **[sayfasına](https://steamcommunity.com/groups/archiasf)** gidip ardından bağlantının sonuna `/memberslistxml?xml=1` ekleyerek kontrol edebilirsiniz, böylece bağlantı **[şuna](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)** benzeyecektir. Ardından, grubunuzun steamID'sini sonuçtan alabilirsiniz, `<groupID64>` etiketinde bulunur. Yukarıdaki örnekte bu `103582791440160998` olur. Başlangıçta belirli bir gruba katılmaya çalışmanın yanı sıra, bot bu gruba gelen grup davetlerini de otomatik olarak kabul edecek ve bu da grubunuzun özel üyeliği varsa botunuzu manuel olarak davet etmenizi mümkün kılacaktır. Botlarınız için özel bir grubunuz yoksa, bu özelliği varsayılan `0` değeriyle tutmalısınız.



---



### `SteamParentalCode`

`string` türünde ve varsayılan değeri `null` olan bir özellik. Bu özellik, Steam ebeveyn PIN'inizi tanımlar. ASF, buhar ebeveyninin koruduğu kaynaklara erişim gerektirir, bu nedenle bu özelliği kullanırsanız, normal çalışabilmesi için ASF'ye ebeveyn kilidi açma PIN'i sağlamalısınız. `null` varsayılan değeri, bu hesabın kilidini açmak için gereken bir buhar ebeveyn PIN'i olmadığı anlamına gelir ve buhar ebeveyn işlevini kullanmıyorsanız muhtemelen istediğiniz şey budur.

Sınırlı durumlarda, ASF geçerli bir Steam ebeveyn kodu da oluşturabilir, ancak bu, aşırı miktarda işletim sistemi kaynağı ve tamamlanması için ek süre gerektirir, başarılı olması garanti edilmez, bu nedenle buna güvenmemeyi öneririz. ASF'nin kullanması için konfigürasyonda geçerli bir `SteamParentalCode` yerine koyun. ASF, PIN'in gerekli olduğunu belirlerse ve kendi başına bir PIN oluşturamazsa, sizden girdi ister.



---



### `SteamPassword`

Varsayılan değeri `null` olan `string` (metin) türü. Bu özellik, Steam parolanızı tanımlar - buhara giriş yapmak için kullandığınız parola. Steam parolanızı buraya tanımlamanın yanı sıra, her ASF başlangıcında yapılandırmaya koymak yerine Steam parolanızı girmek istiyorsanız varsayılan `null` değerini de koruyabilirsiniz. Hassas verileri yapılandırma dosyasına kaydetmek istemiyorsanız bu sizin için yararlı olabilir.



---



### `SteamTradeToken`

Varsayılan değeri `null` olan `string` (metin) türü. Botunuz arkadaş listenizde olduğunda, bot ticaret jetonuyla uğraşmadan size hemen bir ticaret gönderebilir, bu nedenle bu özelliği varsayılan `null` değeriyle bırakabilirsiniz. Ancak botunuzu arkadaş listenizde BULUNDURMAMAYA karar verirseniz, bu botun işlem göndermeyi beklediği kullanıcı olarak bir ticaret jetonu oluşturmanız ve doldurmanız gerekecektir. Başka bir deyişle, bu özellik, **bu** bot örneğinin `SteamUserPermissions` içinde `Master` izniyle tanımlanan hesabın ticaret jetonuyla doldurulmalıdır.

Jetonunuzu, `Master` iznine sahip oturum açmış kullanıcı olarak bulmak için **[buraya](https://steamcommunity.com/my/tradeoffers/privacy)** gidin ve ticaret URL'nize bir göz atın. Aradığımız jeton, ticaret URL'nizdeki `&token=` kısmından sonraki 8 karakterden oluşur. Bu 8 karakteri `SteamTradeToken` olarak kopyalayıp buraya koymalısınız. Tüm ticaret URL'sini ve `&token=` kısmını değil, yalnızca jetonun kendisini (8 karakter) ekleyin.



---



### `SteamUserPermissions`

Varsayılan değeri boş olan `ImmutableDictionary<ulong, byte>` türü. Bu özellik, 64 bit buhar kimliğiyle tanımlanan belirli bir Steam kullanıcısını, ASF örneğindeki iznini belirten `byte` numarasına eşleyen bir sözlük özelliğidir. Şu anda ASF'de mevcut olan bot izinleri şu şekilde tanımlanır:

| Değer | İsim           | Açıklama                                                                                                                                                                                                               |
| ----- | -------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Hiçbiri        | Özel izin yok, bu esas olarak bu sözlükte eksik olan buhar kimliklerine atanan bir referans değeridir - bu izinle kimseyi tanımlamaya gerek yoktur                                                                     |
| 1     | Aile Paylaşımı | Aile paylaşımı kullanıcıları için minimum erişim sağlar. Bir kez daha, bu esas olarak bir referans değeridir, çünkü ASF, kitaplığımızı kullanmak için izin verdiğimiz buhar kimliklerini otomatik olarak keşfedebilir. |
| 2     | Operatör       | Verilen bot örneklerine temel erişim sağlar, esas olarak lisans ekleme ve anahtarları kullanma                                                                                                                         |
| 3     | Master         | Belirli bir bot örneğine tam erişim sağlar                                                                                                                                                                             |


Kısacası, bu özellik belirli kullanıcılar için izinleri yönetmenizi sağlar. İzinler, esas olarak ASF **[komutlarına](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** erişim için önemlidir, aynı zamanda ticaretleri kabul etmek gibi birçok ASF özelliğini etkinleştirmek için de önemlidir. Örneğin, kendi hesabınızı `Master` olarak ayarlamak ve 2-3 arkadaşınıza `Operator` erişimi vermek isteyebilirsiniz, böylece ASF ile botunuz için kolayca anahtarları kullanabilirler, ancak örneğin durdurmaya uygun **olmazlar** . Bu sayede belirli kullanıcılara kolayca izin atayabilir ve belirlediğiniz dereceye kadar botunuzu kullanmalarına izin vereler.

We recommend to set exactly one user as `Master`, and any amount you wish as `Operators` and below. While it's technically possible to set multiple `Masters` and ASF will work correctly with them, for example by accepting all of their trades sent to the bot, ASF will use only one of them (with lowest steam ID) for every action that requires a single target, for example a `loot` request, so also properties like `SendOnFarmingFinished` preference in `FarmingPreferences` or `SendTradePeriod`. If you perfectly understand those limitations, especially the fact that `loot` request will always send items to the `Master` with lowest steam ID, regardless of the `Master` that actually executed the command, then you can define multiple users with `Master` permission here, but we still recommend a single master scheme.

It's nice to note that there is one more extra `Owner` permission, which is declared as `SteamOwnerID` global config property. You can't assign `Owner` permission to anybody here, as `SteamUserPermissions` property defines only permissions that are related to the bot instance, and not ASF as a process. For bot-related tasks, `SteamOwnerID` is treated the same as `Master`, so defining your `SteamOwnerID` here is not necessary.



---



### `TradeCheckPeriod`

`byte` type with default value of `60`. Normally ASF handles incoming trade offers right after receiving notification about one, but sometimes because of Steam glitches it can't do it at that time, and such trade offers remain ignored until next trade notification or bot restart occurs, which may lead to trades being cancelled or items not available at that later time. Bu parametre sıfırdan farklı bir değere ayarlanırsa, ASF belirli aralıklarla (`TradeCheckPeriod` dakikada bir) bu bekleyen ticaretleri kontrol eder. Varsayılan değer, Steam sunucularına yapılan ek isteklerle gelen ticaretlerin kaybolma olasılığı arasında bir denge gözetilerek seçilmiştir. Ancak, ASF'yi sadece kartları toplamak için kullanıyorsanız ve gelen ticaretleri otomatik olarak işlemek istemiyorsanız, bu özelliği tamamen devre dışı bırakmak için `0` olarak ayarlayabilirsiniz. Öte yandan, botunuz [ASF'nin STM listelemesi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) gibi halka açık listelemelerde yer alıyorsa veya başka otomatik hizmetler sağlıyorsa, bu parametreyi 15 dakika gibi daha kısa bir süreye düşürmek isteyebilirsiniz.



---



### `TradingPreferences`

`byte flags` type with default value of `0`. This property defines ASF behaviour when in trading, and is defined as below:

| Değer | İsim                | Açıklama                                                                                                                                                                                                                                           |
| ----- | ------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Hiçbiri             | Özel ticaret tercihi yok, varsayılan                                                                                                                                                                                                               |
| 1     | AcceptDonations     | Kaybedeceğimiz hiçbir şeyin olmadığı ticaretleri kabul eder                                                                                                                                                                                        |
| 2     | SteamTradeMatcher   | **[STM](https://www.steamtradematcher.com)** benzeri ticaretlere pasif olarak katılır. Daha fazla bilgi için **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** sayfasını ziyaret edin                   |
| 4     | MatchEverything     | `SteamTradeMatcher`'ın ayarlanmasını gerektirir ve bununla birlikte iyi ve nötr ticaretlerin yanı sıra kötü ticaretleri de kabul eder                                                                                                              |
| 8     | DontAcceptBotTrades | Diğer bot örneklerinden gelen `loot` ticaret tekliflerini otomatik olarak kabul etmez                                                                                                                                                              |
| 16    | MatchActively       | **[STM](https://www.steamtradematcher.com)** benzeri ticaretlere aktif olarak katılır. Daha fazla bilgi için **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** sayfasını ziyaret edin |


Lütfen bu özelliğin `flags` alanı olduğunu unutmayın, bu nedenle mevcut değerlerin herhangi bir kombinasyonunu seçmek mümkündür. Daha fazla bilgi edinmek isterseniz **[json mapping](#json-mapping)** kısmına göz atın. Hiçbir bayrağı etkinleştirmemek `Hiçbiri` seçeneğiyle sonuçlanır.

ASF'nin ticaret mantığı hakkında daha fazla açıklama ve mevcut her bayrağın tanımı için **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** bölümüne göz atabilirsiniz.



---



### `TransferableTypes`

`ImmutableHashSet<byte>` type with default value of `1, 3, 5` steam item types. `ImmutableHashSet<byte>` türünde ve varsayılan değeri `1, 3, 5` olan bu özellik, `transfer` **[komutu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** sırasında botlar arasında hangi Steam öğe türlerinin transfer edileceğini tanımlar. ASF, yalnızca `TransferableTypes` içindeki öğeleri ticaret tekliflerine dahil eder, bu nedenle bu özellik size bir ticaret teklifinde ne alacağınızı seçme imkanı sağlar.

| Değer | İsim                  | Açıklama                                                                             |
| ----- | --------------------- | ------------------------------------------------------------------------------------ |
| 0     | Unknown               | Aşağıdakilerden hiçbiriyle uyumlu olmayan her tür                                    |
| 1     | BoosterPack           | Bir oyundan rastgele 3 kart içeren booster paketi                                    |
| 2     | Emoticon              | Steam Sohbetinde kullanılacak emotikon                                               |
| 3     | FoilTradingCard       | `TradingCard`'ın foil varyantı                                                       |
| 4     | ProfileBackground     | Steam profilinizde kullanılacak profil arka planı                                    |
| 5     | TradingCard           | Steam ticaret kartı, rozetler için kullanılır (foil olmayan)                         |
| 6     | SteamGems             | Boosterlar ve torbalar dahil olmak üzere crafting için kullanılan Steam mücevherleri |
| 7     | SaleItem              | Steam satışları sırasında verilen özel öğeler                                        |
| 8     | Consumable            | Kullanıldıktan sonra kaybolan özel tüketilebilir öğeler                              |
| 9     | ProfileModifier       | Steam profil görünümünü değiştiren özel öğeler                                       |
| 10    | Sticker               | Steam sohbetinde kullanılabilecek özel öğeler                                        |
| 11    | ChatEffect            | Steam sohbetinde kullanılabilecek özel öğeler                                        |
| 12    | MiniProfileBackground | Steam profili için özel arka plan                                                    |
| 13    | AvatarProfileFrame    | Steam profili için özel avatar çerçevesi                                             |
| 14    | AnimatedAvatar        | Steam profili için özel animasyonlu avatar                                           |
| 15    | KeyboardSkin          | Steam deck için özel klavye kaplaması                                                |
| 16    | StartupVideo          | Steam deck için özel başlangıç videosu                                               |


Lütfen yukarıdaki ayarlardan bağımsız olarak, ASF'nin yalnızca **[Steam Topluluğu eşyaları](https://steamcommunity.com/my/inventory/#753_6)** (`appID` 753, `contextID` 6) için istek yapacağını unutmayın. Dolayısıyla tüm oyun eşyaları, hediyeler ve benzerleri tanım gereği takas teklifinden hariç tutulur.

Varsayılan ASF ayarı, botun en yaygın kullanımına dayanır ve yalnızca takviye paketlerini ve koleksiyon kartlarını (parlak olanlar dahil) aktarmayı içerir. Burada tanımlanan özellik, bu davranışı sizi memnun edecek şekilde değiştirmenize olanak tanır. Lütfen yukarıda tanımlanmayan tüm türlerin `Bilinmeyen` türü olarak gösterileceğini unutmayın. Bu, Valve yeni bir Steam eşyası yayınladığında özellikle önemlidir, çünkü bu eşya buraya eklenene kadar (gelecekteki bir sürümde) ASF tarafından da `Bilinmeyen` olarak işaretlenecektir. Bu nedenle, ne yaptığınızı bilmiyorsanız ve Steam Ağı tekrar bozulup tüm eşyalarınızı `Bilinmeyen` olarak bildirirse ASF'nin tüm envanterinizi bir takas teklifinde göndereceğini anlamıyorsanız, `TransferableTypes` listenize `Bilinmeyen` türünü eklemeniz genellikle önerilmez. Her şeyi aktarmayı bekleseniz bile, `TransferableTypes` listenize `Bilinmeyen` türünü dahil etmemenizi şiddetle tavsiye ederim.



---



### `UseLoginKeys`

Varsayılan değeri `true` olan `bool` türü. Bu özellik, ASF'nin bu Steam hesabı için oturum açma anahtarı mekanizmasını kullanıp kullanmayacağını tanımlar. Oturum açma anahtarı mekanizması, resmi Steam istemcisinin "beni hatırla" seçeneğine çok benzer şekilde çalışır. Bu, ASF'nin bir sonraki oturum açma denemesi için geçici, tek kullanımlık bir oturum açma anahtarını saklamasını ve kullanmasını mümkün kılar; böylece oturum açma anahtarımız geçerli olduğu sürece parola, Steam Guard veya 2FA kodu girme zorunluluğunu ortadan kaldırır. Oturum açma anahtarı `BotAdı.db` dosyasında saklanır ve otomatik olarak güncellenir. ASF ile bir kez başarılı bir şekilde giriş yaptıktan sonra parola/SteamGuard/2FA kodu girmenize gerek olmamasının nedeni budur.

Oturum açma anahtarları, size kolaylık sağlamak amacıyla varsayılan olarak kullanılır. Böylece her girişte `SteamPassword`, SteamGuard veya 2FA kodu (**[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-tr-TR)** kullanmıyorsanız) girmeniz gerekmez. Ayrıca, oturum açma anahtarı yalnızca bir kez kullanılabildiği ve orijinal parolanızı hiçbir şekilde ifşa etmediği için daha üstün bir alternatiftir. Tam olarak aynı yöntem, orijinal Steam istemciniz tarafından da kullanılır. İstemci, bir sonraki oturum açma denemeniz için hesap adınızı ve oturum açma anahtarınızı kaydeder; bu, etkili bir şekilde ASF'de `SteamLogin` ve `UseLoginKeys` kullanıp `SteamPassword`'u boş bırakmakla aynıdır.

Ancak bazı insanlar bu küçük ayrıntıdan bile endişe duyabilir. Bu nedenle, ASF'nin kapatıldıktan sonra önceki oturumu devam ettirmeye izin verecek herhangi bir türde bir anahtar saklamayacağından emin olmak isterseniz bu seçenek tam size göre. Bu ayarı kapatmak, her oturum açma denemesinde tam kimlik doğrulamanın zorunlu olmasıyla sonuçlanacaktır. Bu seçeneği devre dışı bırakmak, resmi Steam istemcisinde "beni hatırla" seçeneğini işaretlememekle tamamen aynı şekilde çalışır. Ne yaptığınızı bilmiyorsanız, varsayılan `true` değeriyle bırakmalısınız.



---



### `UserInterfaceMode`

Varsayılan değeri `0` olan `byte` türü. Bu özellik, botun Steam ağına giriş yaptıktan sonra hangi kullanıcı arayüzü moduyla duyurulacağını belirtir. Bu ayar, eğer `OnlineStatus` ayarınız izin veriyorsa, hesabın örneğin Steam sohbetinde nasıl göründüğünü etkileyebilir. Şu anda aşağıdaki modlardan birini seçebilirsiniz:

| Değer | Ad         | Açıklama                      |
| ----- | ---------- | ----------------------------- |
| `0`   | VGUI       | Varsayılan Steam istemci modu |
| `1`   | Tenfoot    | Big Picture modu              |
| `2`   | Mobil      | Steam mobil uygulaması        |
| `3`   | Web        | Web tarayıcısı oturumu        |
| `5`   | MobileChat | Steam mobil sohbet uygulaması |


The underlying `EUIMode` type that this property is based on includes more available values, however, to the best of our knowledge they have absolutely no effect as of today, therefore they were cut for visibility. Also, you might be interested in checking `GamingDeviceType`, since some additional features are enabled there.

Bu özelliği nasıl ayarlayacağınızdan emin değilseniz, varsayılan değeri `0` olarak bırakabilirsiniz.



---



### `WebProxy`

Varsayılan değeri `null` olan `string` (metin) türü. Bu özellik, bota özgü dahili http bağlantılı iletişim için, özellikle `api.steampowered.com`, `steamcommunity.com` ve `store.steampowered.com` gibi servislere yönelik kullanılacak bir web proxy adresi tanımlar. Eğer ayarlanmazsa, ASF bunun yerine yukarıda belirtilen genel `WebProxy` ayarını kullanır. ASF isteklerini bir proxy üzerinden yönlendirmek, çeşitli güvenlik duvarlarını, özellikle de Çin'in Büyük Güvenlik Duvarı'nı aşmak için son derece yararlı olabilir.

Bu özellik bir URI dizesi olarak tanımlanır:



> Bir URI dizesi bir şemadan (desteklenenler: http/https/socks4/socks4a/socks5), bir ana bilgisayardan (host) ve isteğe bağlı bir porttan oluşur. Tam bir URI dizesi örneği: `"http://contoso.com:8080"`.

Eğer proxy'niz kullanıcı kimlik doğrulaması gerektiriyorsa, `WebProxyUsername` ve/veya `WebProxyPassword` ayarlarını da yapmanız gerekecektir. Böyle bir ihtiyaç yoksa, yalnızca bu özelliği ayarlamak yeterlidir.

Eğer dahili Steam ağ iletişimini (CM'ler) de proxy üzerinden yönlendirmek istiyorsanız, **[`SteamProtocols`](#steamprotocols)** bot özelliğini, yalnızca websocket aktarımına izin veren bir değere, yani `4` değerine ayarladığınızdan emin olmalısınız, çünkü proxy yönlendirmesi için yalnızca websocket'ler desteklenir.

Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.



---



### `WebProxyPassword`

Varsayılan değeri `null` olan `string` (metin) türü. Bu özellik, proxy işlevselliği sağlayan bir hedef `WebProxy` makinesi tarafından desteklenen temel, digest, NTLM ve Kerberos kimlik doğrulaması için kullanılan parola alanını tanımlar. Proxy'niz kullanıcı kimlik bilgileri gerektirmiyorsa, buraya herhangi bir şey girmenize gerek yoktur. Bu seçeneği kullanmak, yalnızca `WebProxy` de kullanılıyorsa anlamlıdır, aksi takdirde bir etkisi olmaz.

Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.



---



### `WebProxyUsername`

Varsayılan değeri `null` olan `string` (metin) türü. Bu özellik, proxy işlevselliği sağlayan bir hedef `WebProxy` makinesi tarafından desteklenen temel, digest, NTLM ve Kerberos kimlik doğrulaması için kullanılan kullanıcı adı alanını tanımlar. Proxy'niz kullanıcı kimlik bilgileri gerektirmiyorsa, buraya herhangi bir şey girmenize gerek yoktur. Bu seçeneği kullanmak, yalnızca `WebProxy` de kullanılıyorsa anlamlıdır, aksi takdirde bir etkisi olmaz.

Bu özelliği düzenlemek için özel bir nedeniniz yoksa, varsayılan ayarında bırakmalısınız.



---



## Dosya Yapısı

ASF oldukça basit bir dosya yapısı kullanır.



```text
├── 📁 config
│     ├── ASF.json
│     ├── ASF.db
│     ├── Bot1.json
│     ├── Bot1.db
│     ├── Bot2.json
│     ├── Bot2.db
│     └── ...
├── ArchiSteamFarm.dll
├── log.txt
└── ...
```


ASF'yi yeni bir konuma, örneğin başka bir PC'ye taşımak için, yalnızca `config` dizinini taşımanız/kopyalamanız yeterlidir. Bu, her türlü "ASF yedeği" için önerilen yöntemdir, çünkü geri kalan (program) kısmını her zaman GitHub'dan indirebilir ve hatalı bir yedekleme nedeniyle dahili ASF dosyalarını bozma riskini almazsınız.

`log.txt` dosyası, son ASF çalıştırmanız tarafından oluşturulan günlüğü tutar. Bu dosya herhangi bir hassas bilgi içermez ve sorunlar, çökmeler veya sadece son ASF çalışmasında ne olduğuna dair bir bilgi olarak son derece kullanışlıdır. Sorun veya hatalarla karşılaşırsanız bu dosyayı çok sık isteyeceğiz. ASF bu dosyayı sizin için otomatik olarak yönetir, ancak ileri düzey bir kullanıcıysanız ASF **[kayıt tutma](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging-tr-TR)** modülünü daha da özelleştirebilirsiniz.

`config` dizini, tüm botları da dahil olmak üzere ASF için yapılandırmayı barındıran yerdir.

`ASF.json`, genel ASF yapılandırma dosyasıdır. Bu yapılandırma, ASF'nin bir süreç olarak nasıl davrandığını belirtmek için kullanılır ve bu da tüm botları ve programın kendisini etkiler. Burada ASF süreç sahibi, otomatik güncellemeler veya hata ayıklama gibi genel özellikleri bulabilirsiniz.

`BotAdı.json`, belirli bir bot örneğinin yapılandırma dosyasıdır. Bu yapılandırma, belirli bir bot örneğinin nasıl davrandığını belirtmek için kullanılır, bu nedenle bu ayarlar yalnızca o bota özgüdür ve diğerleriyle paylaşılmaz. Bu, botları çeşitli farklı ayarlarla yapılandırmanıza ve hepsinin tam olarak aynı şekilde çalışmasını zorunlu kılmamanıza olanak tanır. Her bot, `BotAdı` yerine sizin tarafınızdan seçilen benzersiz bir tanımlayıcı kullanılarak adlandırılır.

Yapılandırma dosyalarının yanı sıra, ASF `config` dizinini veritabanlarını saklamak için de kullanır.

`ASF.db`, genel ASF veritabanı dosyasıdır. Genel bir kalıcı depolama görevi görür ve yerel Steam sunucularının IP'leri gibi ASF süreciyle ilgili çeşitli bilgileri kaydetmek için kullanılır. **Bu dosyayı düzenlememelisiniz**.

`BotAdı.db`, belirli bir bot örneğinin veritabanıdır. Bu dosya, oturum açma anahtarları veya ASF 2FA gibi belirli bir bot örneği hakkındaki önemli verileri kalıcı depolamada saklamak için kullanılır. **Bu dosyayı düzenlememelisiniz**.

`BotAdı.keys`, **[arka planda oyun etkinleştirme](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-tr-TR)** özelliğine anahtar aktarmak için kullanılabilecek özel bir dosyadır. Zorunlu değildir ve otomatik olarak oluşturulmaz, ancak ASF tarafından tanınır. Anahtarlar başarıyla içe aktarıldıktan sonra bu dosya otomatik olarak silinir.

`BotAdı.maFile`, **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-tr-TR)** aktarmak için kullanılabilecek özel bir dosyadır. Zorunlu değildir ve otomatik olarak oluşturulmaz, ancak `BotAdı` henüz ASF 2FA kullanmıyorsa ASF tarafından tanınır. ASF 2FA başarıyla içe aktarıldıktan sonra bu dosya otomatik olarak silinir.



---



## JSON Eşlemesi

Her yapılandırma özelliğinin kendi türü vardır. Özelliğin türü, o özellik için geçerli olan değerleri tanımlar. Yalnızca belirtilen tür için geçerli olan değerleri kullanabilirsiniz - geçersiz bir değer kullanırsanız, ASF yapılandırmanızı çözümleyemez.

**Yapılandırma dosyalarını oluşturmak için Yapılandırma Oluşturucuyu kullanmanızı şiddetle tavsiye ederiz** - bu araç, tür doğrulama gibi düşük seviyeli işlerin çoğunu sizin için halleder, böylece yalnızca doğru değerleri girmeniz yeterli olur ve aşağıda belirtilen değişken türlerini anlamanıza gerek kalmaz. Bu bölüm temel olarak, yapılandırmaları manuel olarak oluşturan/düzenleyen kişilerin hangi değerleri kullanabileceklerini bilmeleri içindir.

ASF tarafından kullanılan türler, aşağıda belirtilen yerel C# türleridir:



---

`bool` - Yalnızca `true` ve `false` değerlerini kabul eden boolean türü.

Örnek: `"Enabled": true`



---

`byte` - Yalnızca `0` ile `255` (dahil) arasındaki tam sayıları kabul eden işaretsiz byte türü.

Örnek: `"ConnectionTimeout": 90`



---

`ushort` - Yalnızca `0` ile `65535` (dahil) arasındaki tam sayıları kabul eden işaretsiz short türü.

Örnek: `"WebLimiterDelay": 300`



---

`uint` - Yalnızca `0` ile `4294967295` (dahil) arasındaki tam sayıları kabul eden işaretsiz integer türü.



---

`ulong` - Yalnızca `0` ile `18446744073709551615` (dahil) arasındaki tam sayıları kabul eden işaretsiz long integer türü.

Örnek: `"SteamMasterClanID": 103582791440160998`



---

`string` - Boş dizi `""` ve `null` dahil olmak üzere herhangi bir karakter dizisini kabul eden metin türü. Boş dizi ve `null` değeri ASF tarafından aynı şekilde ele alınır, bu nedenle hangisini kullanmak istediğiniz sizin tercihinize kalmıştır (biz `null` kullanmayı tercih ediyoruz).

Örnekler: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "HesapAdim"`



---

`Guid?` - JSON'da metin olarak kodlanan, null olabilir UUID türü. UUID, `0` ile `9` ve `a` ile `f` aralığında 32 onaltılık karakterden oluşur. ASF, çeşitli geçerli formatları kabul eder - küçük harf, büyük harf, tireli ve tiresiz. Geçerli bir UUID'ye ek olarak, bu özellik null olabilir olduğundan, sağlanacak bir UUID'nin olmadığını belirtmek için özel `null` değeri de kabul edilir.

Örnekler: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`



---

`ImmutableList<valueType>` - Belirtilen `valueType` türündeki değerlerin değiştirilemez koleksiyonu (liste). JSON'da, belirtilen `valueType` türündeki öğelerin bir dizisi olarak tanımlanır. ASF, bir özelliğin birden fazla değeri desteklediğini ve sırasının önemli olabileceğini belirtmek için `List` kullanır.

`ImmutableList<byte>` için örnek: `"FarmingOrders": [15, 11, 7]`



---

`ImmutableHashSet<valueType>` - Belirtilen `valueType` türündeki benzersiz değerlerin değiştirilemez koleksiyonu (küme). JSON'da, belirtilen `valueType` türündeki öğelerin bir dizisi olarak tanımlanır. ASF, bir özelliğin yalnızca benzersiz değerler için anlamlı olduğunu ve sırasının önemli olmadığını belirtmek için `HashSet` kullanır. Bu nedenle, ayrıştırma sırasında olası yinelenenleri (yine de sağladıysanız) kasıtlı olarak yok sayacaktır.

`ImmutableHashSet<uint>` için örnek: `"Blacklist": [267420, 303700, 335590]`



---

`ImmutableDictionary<keyType, valueType>` - `keyType` içinde belirtilen benzersiz bir anahtarı, `valueType` içinde belirtilen bir değere eşleyen değiştirilemez bir sözlük (map). JSON'da, anahtar-değer çiftleri olan bir nesne olarak tanımlanır. `keyType`'ın, `ulong` gibi bir değer türü olsa bile, bu durumda her zaman tırnak içine alındığını unutmayın. Ayrıca, anahtarın harita boyunca benzersiz olması gibi katı bir gereklilik de vardır; bu sefer bu, JSON tarafından da zorunlu kılınmıştır.

`ImmutableDictionary<ulong, byte>` için örnek: `"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`



---

`flags` - Bayrak özniteliği, bit düzeyinde işlemler uygulayarak birkaç farklı özelliği tek bir nihai değerde birleştirir. Bu, aynı anda izin verilen çeşitli farklı değerlerin olası herhangi bir kombinasyonunu seçmenize olanak tanır. Nihai değer, etkinleştirilmiş tüm seçeneklerin değerlerinin toplamı olarak oluşturulur.

For example, given following definition:

| Değer | Ad      |
| ----- | ------- |
| 0     | Hiçbiri |
| 1     | A       |
| 2     | B       |
| 4     | C       |


There are exactly 3 meaningful, available flags to switch on/off (`A`, `B`, `C`), and therefore `8` possible valid combinations overall:

| Final value | Enabled flags   |
| ----------- | --------------- |
| 0           | `Hiçbiri`       |
| 1           | `A`             |
| 2           | `B`             |
| 3           | `A` + `B`       |
| 4           | `C`             |
| 5           | `A` + `C`       |
| 6           | `B` + `C`       |
| 7           | `A` + `B` + `C` |


By definition, in order to make the above possible, each standalone flag must therefore be the power of two. This is why additional flag in above example, `D`, would need to carry value of `8` or greater.

Usually, graphical tools will do the calculation for you. If you're editing configs manually, you can always use calculator and simply add together underlying values of all the flags you want to enable - like in example above.

Example: `"SteamProtocols": 7` (which enables flags with value of `1`, `2` and `4`, as explained above)



---



## Uyumluluk Eşlemesi

Web tabanlı Yapılandırma Oluşturucuyu kullanırken JavaScript'in basit `ulong` alanlarını JSON'da düzgün bir şekilde serileştirememesi nedeniyle, `ulong` alanları sonuç yapılandırmasında `s_` ön ekiyle metin olarak oluşturulacaktır. Bu, örneğin `"SteamOwnerID": 76561198006963719` değerinin Yapılandırma Oluşturucumuz tarafından `"s_SteamOwnerID": "76561198006963719"` olarak yazılmasını içerir. ASF, bu metin eşlemesini otomatik olarak işlemek için uygun mantığı içerir, bu nedenle yapılandırmalarınızdaki `s_` girişleri aslında geçerli ve doğru bir şekilde oluşturulmuştur. Yapılandırmaları kendiniz oluşturuyorsanız, mümkünse orijinal `ulong` alanlarını kullanmanızı öneririz. Ancak bunu yapamıyorsanız, bu şemayı izleyerek adlarına `s_` ön eki eklenmiş metinler olarak da kodlayabilirsiniz. Bu JavaScript sınırlamasını en sonunda çözmeyi umuyoruz.



---



## Yapılandırma Uyumluluğu

ASF için eski yapılandırmalarla uyumlu kalmak en büyük önceliktir. Bildiğiniz gibi, eksik yapılandırma özellikleri, **varsayılan değerleriyle** tanımlanmış gibi ele alınır. Bu nedenle, yeni bir ASF sürümünde yeni bir yapılandırma özelliği tanıtıldığında, tüm yapılandırmalarınız yeni sürümle **uyumlu** kalır ve ASF bu yeni yapılandırma özelliğini **varsayılan değeriyle** tanımlanmış gibi kabul eder. Yapılandırma özelliklerini ihtiyaçlarınıza göre her zaman ekleyebilir, kaldırabilir veya düzenleyebilirsiniz.

Tanımlanan yapılandırma özelliklerini yalnızca değiştirmek istediklerinizle sınırlamanızı öneririz. Bu sayede diğer tüm özellikler için varsayılan değerleri otomatik olarak miras alırsınız; bu, hem yapılandırmanızı temiz tutar hem de açıkça kendiniz ayarlamak istemediğiniz bir özelliğin varsayılan değerini değiştirmeye karar vermemiz durumunda (ör. `WebLimiterDelay`) uyumluluğu artırır.

Yukarıdakiler nedeniyle ASF, yapılandırmalarınızı yeniden biçimlendirerek ve varsayılan değeri tutan alanları kaldırarak otomatik olarak taşıyacak/optimize edecektir. Bu davranışı, belirli bir nedeniniz varsa, örneğin salt okunur yapılandırma dosyaları sağlıyorsanız ve ASF'nin bunları değiştirmesini istemiyorsanız `--no-config-migrate` **[komut satırı argümanı](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-tr-TR#arguments)** ile devre dışı bırakabilirsiniz.



---



## Otomatik Yeniden Yükleme

ASF, yapılandırmaların "anında" değiştirildiğinin farkındadır - bu sayede ASF otomatik olarak şunları yapar:

- Yapılandırmasını oluşturduğunuzda yeni bir bot örneği oluşturur (ve gerekirse başlatır)
- Yapılandırmasını sildiğinizde eski bot örneğini durdurur (gerekirse) ve kaldırır
- Yapılandırmasını düzenlediğinizde herhangi bir bot örneğini durdurur (ve gerekirse başlatır)
- Yapılandırmasını yeniden adlandırdığınızda botu yeni adıyla yeniden başlatır (gerekirse)

Yukarıdakilerin tümü şeffaftır ve programı yeniden başlatmaya veya diğer (etkilenmemiş) bot örneklerini sonlandırmaya gerek kalmadan otomatik olarak yapılır.

Buna ek olarak, eğer çekirdek ASF yapılandırması olan `ASF.json` dosyasını değiştirirseniz, ASF kendini de yeniden başlatacaktır (`AutoRestart` izin veriyorsa). Aynı şekilde, bu dosyayı silerseniz veya yeniden adlandırırsanız program kapanacaktır.

Bu davranışı, belirli bir nedeniniz varsa, örneğin ASF'nin `config` klasöründeki dosya değişikliklerine tepki vermesini istemiyorsanız `--no-config-watch` **[komut satırı argümanı](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-tr-TR#arguments)** ile devre dışı bırakabilirsiniz.