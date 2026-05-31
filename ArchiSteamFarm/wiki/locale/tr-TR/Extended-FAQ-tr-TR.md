# Kapsamlı SSS

Kapsamlı SSS bölümümüz, aklınıza gelebilecek daha az yaygın olan bazı soru ve cevapları kapsar. Daha genel konular için lütfen bunun yerine **[temel SSS](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-tr-TR)** sayfamızı ziyaret edin.

---

### ASF'yi kim yarattı?

ASF, Ekim 2015'te **[Archi](https://github.com/JustArchi)** tarafından yaratıldı. Merak ettiyseniz söyleyeyim, ben de tıpkı sizin gibi bir **[Steam kullanıcısıyım](https://steamcommunity.com/profiles/76561198006963719)**. Oyun oynamanın yanı sıra, yeteneklerimi ve azmimi kullanmayı da seviyorum; ki bunun sonuçlarını şu an keşfedebilirsiniz. Bu işin arkasında ne büyük bir şirket, ne bir geliştirici ekibi, ne de tüm bunları karşılayacak 1 milyon dolarlık bir bütçe var - sadece ben, bozuk olmayan şeyleri tamir ediyorum.

Ancak ASF açık kaynaklı bir proje ve burada gördüğünüz her şeyin arkasında tek başıma olmadığımı ne kadar söylesem azdır. Neredeyse tamamen diğer geliştiriciler tarafından geliştirilen birkaç **[başka](https://github.com/JustArchiNET?q=ASF-)** ASF projemiz de var. Çekirdek ASF projesinin bile tüm bunların gerçekleşmesine yardımcı olan çok sayıda **[katkıda bulunanı](https://github.com/JustArchiNET/ArchiSteamFarm/graphs/contributors)** var. Bunun da ötesinde, ASF'nin geliştirilmesini destekleyen, özellikle **[GitHub](https://github.com)**, **[JetBrains](https://www.jetbrains.com)** ve **[Crowdin](https://crowdin.com)** gibi birçok üçüncü taraf hizmeti bulunmaktadır. Ayrıca, IDE olarak kullandığımız **[Rider](https://www.jetbrains.com/rider)** (ve onun **[ReSharper](https://www.jetbrains.com/resharper)** eklentilerine bayılıyoruz) ve özellikle onsuz ASF'nin var olamayacağı **[SteamKit2](https://github.com/SteamRE/SteamKit)** gibi ASF'nin ortaya çıkmasını sağlayan tüm harika kütüphaneleri ve araçları da unutmamak gerekir. ASF, burada yaptığım her şeyde beni destekleyen **[sponsorlarım](https://github.com/sponsors/JustArchi)** ve çeşitli bağışçılarım olmasaydı bugün olduğu yerde olamazdı.

ASF'nin geliştirilmesine yardımcı olan herkese teşekkürler! Harikasın :heart:.

---

### ASF en başta neden yaratıldı?

ASF, temel olarak, herhangi bir harici bağımlılığa (Steam istemcisi gibi) ihtiyaç duymadan Linux için tam otomatik bir Steam kart düşürme aracı olma amacıyla oluşturuldu. Aslında bu, hâlâ onun birincil amacı ve odak noktasıdır. Çünkü o zamandan beri ASF konseptim değişmedi ve hâlâ onu 2015'te kullandığım şekilde kullanıyorum. Elbette o zamandan bu yana gerçekten **çok şey** değişti ve çoğunlukla kullanıcıları sayesinde ASF'nin ne kadar ilerlediğini görmekten çok mutluyum. Çünkü eğer sadece kendim için olsaydı, özelliklerin yarısını bile kodlamazdım.

ASF'nin hiçbir zaman diğer benzer programlarla, özellikle de **[Idle Master](https://www.steamidlemaster.com)** ile rekabet etmek için yapılmadığını belirtmekte fayda var. Çünkü ASF hiçbir zaman bir masaüstü/kullanıcı uygulaması olarak tasarlanmadı ve bugün de öyle değil. Yukarıda açıklanan ASF'nin birincil amacını analiz ederseniz, Idle Master'ın tüm bunların **tam tersi** olduğunu görürsünüz. Bugün ASF'ye benzer programlar kesinlikle bulabilirsiniz, ancak o zamanlar (ve bugün hala) hiçbir şey benim için yeterince iyi değildi, bu yüzden kendi yazılımımı, istediğim şekilde yarattım. Zamanla kullanıcılar, temel olarak sağlamlığı, kararlılığı ve güvenliği nedeniyle, ama aynı zamanda bunca yıl boyunca geliştirdiğim tüm özellikler sayesinde ASF'ye geçiş yaptı. Bugün, ASF her zamankinden daha iyi.

---

### Peki, bu işin içinde ne var? ASF'yi paylaşmaktan ne kazanıyorsun?

İşin içinde bir şey yok. ASF'yi **kendim için** yarattım ve faydalı olacağı umuduyla topluluğun geri kalanıyla paylaştım. Tam olarak aynı şey 1991'de, Linus Torvalds'ın **[ilk Linux çekirdeğini](https://groups.google.com/forum/#!msg/comp.os.Minix/dlNtH7RRrGA/SwRavCzVE7gJ)** dünyanın geri kalanıyla paylaştığında da yaşanmıştı. Gizli bir kötü amaçlı yazılım, veri madenciliği, kripto madenciliği veya benim için herhangi bir parasal fayda sağlayacak başka bir faaliyet yok. ASF projesi tamamen sizin gibi mutlu kullanıcılar tarafından gönderilen, zorunlu olmayan bağışlarla desteklenmektedir. ASF'yi tam olarak benim kullandığım şekilde kullanabilirsiniz ve eğer beğenirseniz, yaptığım şey için minnettarlığınızı göstererek bana her zaman bir kahve ısmarlayabilirsiniz.

Ayrıca ASF'yi; teknoloji, proje yönetimi veya kodun kendisi olsun, her zaman mükemmellik ve en iyi uygulamalar için çabalayan modern bir C# projesinin mükemmel bir örneği olarak kullanıyorum. Bu benim "doğru yapılan işler" tanımımdır, bu yüzden eğer bir şans eseri projemden faydalı bir şeyler öğrenmeyi başarırsanız, bu beni daha da mutlu edecektir.

---

### ASF'yi başlattıktan hemen sonra tüm hesaplarımı/eşyalarımı/arkadaşlarımı/(...) kaybettim!

İstatistiksel olarak konuşmak gerekirse, ne kadar üzücü olursa olsun, ASF'yi başlattıktan kısa bir süre sonra en az bir kişinin araba kazasında öleceği garantidir. Aradaki fark şu ki, aklı başında hiç kimse bu kazaya ASF'nin neden olduğunu iddia etmez. Ama nedense, sırf kendi Steam hesaplarının başına geldiği için ASF'yi aynı şeyle suçlayacak insanlar var. Elbette bunun mantığını anlayabiliriz; ne de olsa ASF, Steam platformu içinde çalışıyor. Bu yüzden insanlar doğal olarak, çalıştırdıkları yazılımın olayla uzaktan yakından bir ilgisi olduğuna dair hiçbir kanıt olmamasına rağmen, Steam ile ilgili mülklerinin başına gelen her şey için ASF'yi suçlayacaktır.

**[SSS](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-tr-TR#is-it-safe)** bölümünde ve **[yukarıdaki soruda](#ok-where-is-the-catch-what-do-you-gain-from-sharing-asf)** belirtildiği gibi ASF; kötü amaçlı yazılım, casus yazılım, veri madenciliği ve diğer potansiyel olarak istenmeyen faaliyetlerden, **özellikle de** hassas Steam bilgilerinizi ele geçirme veya dijital mülkünüzü çalma gibi eylemlerden arındırılmıştır. Eğer başınıza böyle bir şey geldiyse, kaybınız için üzgün olduğumuzu belirtebilir ve kurtarma sürecinde size yardımcı olacağını umduğumuz **[Steam Destek](https://help.steampowered.com)** ile iletişime geçmenizi önerebiliriz. Çünkü başınıza gelenlerden hiçbir şekilde sorumlu değiliz ve vicdanımız rahat. Eğer aksini düşünüyorsanız, bu sizin kararınızdır. Daha fazla detaya girmek anlamsız; eğer yukarıda sunduğumuz, ifademizi doğrulamak için objektif ve kanıtlanabilir yollar sunan kaynaklar sizi ikna etmediyse, burada yazacağımız başka hiçbir şeyin de ikna etmesi olası değildir.

Ancak yukarıda söylenenler, ASF ile sağduyulu bir şekilde gerçekleştirilmeyen **eylemlerinizin** bir güvenlik sorununa yol açmayacağı anlamına gelmez. Örneğin, güvenlik yönergelerimizi göz ardı edebilir, ASF'nin **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-tr-TR)** arayüzünü tüm internete açabilir ve sonra birinin girip tüm eşyalarınızı çalmasına şaşırabilirsiniz. İnsanlar bunu sürekli yapıyor; eğer bir alan adları veya IP adreslerine bir bağlantı yoksa, kimsenin onların ASF örneğini kesinlikle bulamayacağını düşünüyorlar. Siz bu satırları okurken bile, web'i tarayan, rastgele IP adresleri de dahil olmak üzere keşfedilecek güvenlik açıkları arayan **binlerce** (belki de daha fazla) tam otomatik bot var ve oldukça popüler bir program olan ASF de bunların hedeflerinden biri. Bu şekilde kendi aptallıkları yüzünden "hacklenen" yeterince insanla karşılaştık. Bu yüzden onlara katılmak yerine, onların hatalarından ders çıkarmaya ve daha akıllı olmaya çalışın.

Aynı şey bilgisayarınızın güvenliği için de geçerli. Evet, PC'nizde kötü amaçlı yazılım bulunması, ASF'nin her bir güvenlik yönünü mahveder. Çünkü bu yazılımlar, ASF yapılandırma dosyalarından veya işlem belleğinden hassas ayrıntıları okuyabilir ve hatta programı normalde yapmayacağı şeyleri yapması için etkileyebilir. No, the last crack you've obtained from doubtful source was not a "false positive" as somebody has told you, it's one of the most effective ways to gain control over somebody's PC, people will infect themselves and they'll even follow the instructions how to, fascinating.

Peki, ASF kullanmak tamamen güvenli ve tüm risklerden arınmış mı demek oluyor? Hayır, böyle bir şey iddia edersek bir avuç ikiyüzlü oluruz, çünkü **her** yazılımın güvenlikle ilgili sorunları vardır. Birçok şirketin yaptığının aksine, biz **[güvenlik duyurularımızda](https://github.com/JustArchiNET/ArchiSteamFarm/security/advisories)** mümkün olduğunca şeffaf olmaya çalışıyoruz. ASF'nin güvenlik açısından potansiyel olarak istenmeyen bir duruma herhangi bir şekilde katkıda bulunabileceği *varsayımsal* bir durumu bile fark ettiğimiz anda bunu derhal duyururuz. Örneğin, **[CVE-2021-32794](https://github.com/JustArchiNET/ArchiSteamFarm/security/advisories/GHSA-wxx4-66c2-vj2v)** olayında olan buydu. ASF'nin kendi içinde bir güvenlik açığı olmamasına rağmen, kullanıcının yanlışlıkla bir açık oluşturmasına neden olabilecek bir hata mevcuttu.

Bugün itibarıyla ASF'de bilinen, yamalanmamış bir güvenlik açığı bulunmamaktadır. Program, hem **[beyaz şapkalıların](https://tr.wikipedia.org/wiki/Beyaz_%C5%9Fapkal%C4%B1_hacker)** hem de **[siyah şapkalıların](https://tr.wikipedia.org/wiki/Siyah_%C5%9Fapkal%C4%B1_hacker)** kaynak kodunu analiz ettiği giderek daha fazla kişi tarafından kullanıldıkça, genel güven faktörü zamanla artmaktadır. Çünkü bulunacak güvenlik açığı sayısı sınırlıdır ve her şeyden önce güvenliğine odaklanan bir program olan ASF, bir açık bulmayı kesinlikle kolaylaştırmamaktadır. Tüm iyi niyetimize rağmen, yine de soğukkanlı olmanızı ve ASF kullanımından kaynaklananlar da dahil olmak üzere potansiyel güvenlik tehditlerine karşı her zaman dikkatli olmanızı tavsiye ederiz.

---

### İndirilen dosyaların orijinal olduğunu nasıl doğrulayabilirim?

GitHub'daki sürümlerimizin bir parçası olarak, **[Debian](https://www.debian.org/CD/verify)** tarafından kullanılana çok benzer bir doğrulama süreci kullanıyoruz. Her resmi sürümde, `zip` derleme dosyalarına ek olarak `SHA512SUMS` ve `SHA512SUMS.sign` dosyalarını bulabilirsiniz. Doğrulama amacıyla bu dosyaları, seçtiğiniz `zip` dosyalarıyla birlikte indirin.

Öncelikle, seçilen `zip` dosyalarının `SHA-512` sağlama toplamının (checksum) bizim hesapladığımızla eşleştiğini doğrulamak için `SHA512SUMS` dosyasını kullanmalısınız. Linux'ta bu amaç için `sha512sum` aracını kullanabilirsiniz.


```
$ sha512sum -c --ignore-missing SHA512SUMS
ASF-linux-x64.zip: OK
```

Windows'ta bunu PowerShell üzerinden yapabiliriz, ancak `SHA512SUMS` ile manuel olarak doğrulama yapmanız gerekir:

```
PS > Get-Content SHA512SUMS | Select-String -Pattern ASF-linux-x64.zip

f605e573cc5e044dd6fadbc44f6643829d11360a2c6e4915b0c0b8f5227bc2a257568a014d3a2c0612fa73907641d0cea455138d2e5a97186a0b417abad45ed9  ASF-linux-x64.zip


PS > Get-FileHash -Algorithm SHA512 -Path ASF-linux-x64.zip

Algorithm       Hash                                                                   Path
---------       ----                                                                   ----
SHA512          F605E573CC5E044DD6FADBC44F6643829D11360A2C6E4915B0C0B8F5227BC2A2575... ASF-linux-x64.zip
```

Bu şekilde, `SHA512SUMS` dosyasına yazılanların sonuç dosyalarıyla eşleştiğinden ve onlara müdahale edilmediğinden emin olduk. Ancak bu, kontrol ettiğiniz `SHA512SUMS` dosyasının gerçekten bizden geldiğini henüz kanıtlamaz. Bunu doğrulamanın iki yolu vardır.

İlk yol ve aynı zamanda ASF'nin otomatik güncelleme işlemi için kullandığı yol, `https://asf.JustArchi.net/Api/Checksum/{Version}/{Variant}` URL'sini ziyaret ederek arka uç sunucumuza bir çağrı yapmaktır. Burada `{Version}` kısmını `6.1.4.3` gibi bir ASF sürüm numarasıyla ve `{Variant}` kısmını da `generic` veya `linux-x64` gibi seçtiğiniz ASF türüyle değiştirirsiniz. Sağlama toplamını (checksum), `SHA512SUMS` dosyası ve/veya ASF zip dosyasıyla karşılaştırmanız gereken JSON yanıtında bulabilirsiniz. Sunucumuz yalnızca mevcut **[kararlı (stable)](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ve **[ön sürüm (pre-release)](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF versiyonları için sağlama toplamı sunar, çünkü yalnızca mevcut ASF'ler bu sürümlere güncellemeyi düşünür.

```json
{
  "Result": "f605e573cc5e044dd6fadbc44f6643829d11360a2c6e4915b0c0b8f5227bc2a257568a014d3a2c0612fa73907641d0cea455138d2e5a97186a0b417abad45ed9",
  "Message": "OK",
  "Success": true
}
```

İkinci yol, `SHA512SUMS` dosyasının orijinalliğini kanıtlayan dijital bir PGP imzası içeren `SHA512SUMS.sign` dosyasını kullanmaktır. Derleme çıktıları ve imza, derleme sürecinin bir parçası olarak oluşturulduğundan, GitHub'ın ele geçirilmesi durumunda bütünlüğü garanti etmez (bu nedenle doğrulama amaçlı kendi bağımsız sunucumuzu kullanıyoruz). Ancak, ASF'yi bilinmeyen bir kaynaktan indirdiyseniz ve bunun tamamen GitHub'ın ele geçirilmediğinden emin olmaktan ziyade, bizim GitHub yayın sürecimiz tarafından üretilen geçerli bir çıktı olduğundan emin olmak istiyorsanız bu yeterlidir.

Bu amaçla hem **[Linux](https://gnupg.org/download/index.html)**'ta hem de **[Windows](https://gpg4win.org)**'ta (Windows'ta `gpg` komutunu `gpg.exe` olarak değiştirin) `gpg` aracını kullanabiliriz.

```
$ gpg --verify SHA512SUMS.sign SHA512SUMS
gpg: Signature made Mon 02 Aug 2021 00:34:18 CEST
gpg:                using EDDSA key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Can't check signature: No public key
```

Gördüğünüz gibi, dosya gerçekten de geçerli bir imza içeriyor, ancak kaynağı bilinmiyor. Tam doğrulama için, `SHA-512` toplamlarını imzaladığımız ArchiBot'un **[genel anahtarını (public key)](https://raw.githubusercontent.com/JustArchi-ArchiBot/JustArchi-ArchiBot/main/ArchiBot_public.asc)** içe aktarmanız gerekecektir.

```
$ curl https://raw.githubusercontent.com/JustArchi-ArchiBot/JustArchi-ArchiBot/main/ArchiBot_public.asc -o ArchiBot_public.asc
$ gpg --import ArchiBot_public.asc
gpg: /home/archi/.gnupg/trustdb.gpg: trustdb created
gpg: key A3D181DF2D554CCF: public key "ArchiBot <ArchiBot@JustArchi.net>" imported
gpg: Total number processed: 1
gpg:               imported: 1

```

Son olarak, `SHA512SUMS` dosyasını tekrar doğrulayabilirsiniz:

```
$ gpg --verify SHA512SUMS.sign SHA512SUMS
gpg: Signature made Mon 02 Aug 2021 00:34:18 CEST
gpg:                using EDDSA key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Good signature from "ArchiBot <ArchiBot@JustArchi.net>" [unknown]
gpg: WARNING: This key is not certified with a trusted signature!
gpg:          There is no indication that the signature belongs to the owner.
Primary key fingerprint: 224D A6DB 47A3 935B DCC3  BE17 A3D1 81DF 2D55 4CCF
```

Bu, `SHA512SUMS.sign` dosyasının, doğruladığınız `SHA512SUMS` dosyası için bizim `224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF` anahtarımızın geçerli bir imzasını içerdiğini doğrulamıştır.

Son uyarının nereden geldiğini merak ediyor olabilirsiniz. Anahtarımızı başarıyla içe aktardınız, ancak henüz ona güvenmeye karar vermediniz. Bu zorunlu olmasa da, bu konuyu da ele alabiliriz. Normalde bu, anahtarın geçerli olduğunu farklı bir kanal aracılığıyla (örneğin telefon görüşmesi, SMS) doğrulamayı ve ardından ona güvenmek için anahtarı kendi anahtarınızla imzalamayı içerir. Bu örnek için, orijinal anahtar **[ArchiBot'un profilinden](https://github.com/JustArchi-ArchiBot)** geldiği için, bu viki girdisini (çok zayıf olsa da) böyle farklı bir kanal olarak düşünebilirsiniz. Her halükarda, şu anki haliyle yeterince güvendiğinizi varsayacağız.

Öncelikle, eğer henüz bir tane yoksa, **[kendiniz için özel bir anahtar oluşturun](https://help.ubuntu.com/community/GnuPrivacyGuardHowto#Generating_an_OpenPGP_Key)**. Hızlı bir örnek olarak `--quick-gen-key` kullanacağız.

```
$ gpg --batch --passphrase '' --quick-gen-key "$(whoami)"
gpg: /home/archi/.gnupg/trustdb.gpg: trustdb created
gpg: key E4E763905FAD148B marked as ultimately trusted
gpg: directory '/home/archi/.gnupg/openpgp-revocs.d' created
gpg: revocation certificate stored as '/home/archi/.gnupg/openpgp-revocs.d/8E5D685F423A584569686675E4E763905FAD148B.rev'
```

Şimdi ona güvenmek için bizim anahtarımızı kendi anahtarınızla imzalayabilirsiniz:

```
$ gpg --sign-key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF

pub  ed25519/A3D181DF2D554CCF
     created: 2021-05-22  expires: never       usage: SC
     trust: unknown       validity: unknown
sub  cv25519/E527A892E05B2F38
     created: 2021-05-22  expires: never       usage: E
[ unknown] (1). ArchiBot <ArchiBot@JustArchi.net>


pub  ed25519/A3D181DF2D554CCF
     created: 2021-05-22  expires: never       usage: SC
     trust: unknown       validity: unknown
 Primary key fingerprint: 224D A6DB 47A3 935B DCC3  BE17 A3D1 81DF 2D55 4CCF

     ArchiBot <ArchiBot@JustArchi.net>

Are you sure that you want to sign this key with your
key "archi" (E4E763905FAD148B)

Really sign? (e/H) e
```

Ve bitti! Anahtarımıza güvendikten sonra, `gpg` doğrulama yaparken artık uyarı göstermemelidir:

```
$ gpg --verify SHA512SUMS.sign SHA512SUMS
gpg: Signature made Mon 02 Aug 2021 00:34:18 CEST
gpg:                using EDDSA key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Good signature from "ArchiBot <ArchiBot@JustArchi.net>" [full]
```

Bizim anahtarımızı kendi anahtarınızla imzaladıktan sonra `[unknown]` (bilinmeyen) güven göstergesinin `[full]` (tam) olarak değiştiğine dikkat edin.

Tebrikler, indirdiğiniz sürüme kimsenin müdahale etmediğini doğruladınız! 👍

---

### Bugün 1 Nisan ve ASF'nin dili tuhaf bir şeye dönüştü, neler oluyor?

TEBRIKLER, 1 NISAN ŞAKAMIZI BULDUNUZ! Eğer özel bir `CurrentCulture` ayarı yapmadıysanız, 1 Nisan'da ASF sistem diliniz yerine **[LOLcat](https://en.wikipedia.org/wiki/Lolcat)** dilini kullanacaktır. Eğer bu davranışı devre dışı bırakmak isterseniz, `CurrentCulture` ayarını kullanmak istediğiniz dile ayarlamanız yeterlidir. Ayrıca, `CurrentCulture` değerini `qps-Ploc` olarak ayarlayarak bu sürpriz yumurtayı koşulsuz olarak etkinleştirebileceğinizi de belirtelim.