# Komut Satırı Argümanları

ASF, programın çalışma zamanı davranışlarını etkileyebilecek çeşitli komut satırı argümanlarını destekler. Bu argümanlar, ileri düzey kullanıcılar tarafından programın nasıl çalışacağını belirlemek için kullanılabilir. `ASF.json` yapılandırma dosyasının varsayılan kullanımına kıyasla komut satırı argümanları; çekirdek başlatma işlemleri (ör. `--path`), platforma özgü ayarlar (ör. `--system-required`) veya hassas veriler (ör. `--cryptkey`) için kullanılır.

---

## Kullanım

Kullanım işletim sisteminize ve ASF zevkinize göre değişir.

Generic (Genel):

```shell
dotnet ArchiSteamFarm.dll --argument --otherOne
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --otherOne
```

Komut satırı argümanları, `ArchiSteamFarm.cmd` veya `ArchiSteamFarm.sh` gibi yardımcı betiklerde de desteklenir. Buna ek olarak, **[yönetim](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-tr-TR#environment-variables)** ve **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker-tr-TR#command-line-arguments)** bölümlerimizde belirtildiği gibi `ASF_ARGS` çevre değişkenini de kullanabilirsiniz.

Eğer argümanınız boşluk içeriyorsa, tırnak işaretleri (" ") arasına almayı unutmayın. Şu ikisi hatalıdır:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Hatalı!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Hatalı!
```

Ancak şu ikisi tamamen hatasızdır:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # Tamam
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # Tamam
```

## Argümanlar

`--cryptkey <key>` veya `--cryptkey=<key>` - ASF'yi, belirtilen `<key>` değerini özel bir kriptografik anahtar olarak kullanarak başlatır. Bu seçenek **[güvenliği](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-tr-TR)** etkiler ve ASF'nin, programın içine gömülü olan varsayılan anahtar yerine sizin sağladığınız özel `<key>` anahtarını kullanmasını sağlar. Bu özellik varsayılan şifreleme anahtarını (şifreleme için) ve salt değerini (hashleme için) etkilediğinden, bu anahtarla şifrelenmiş/hashlenmiş her şey için, ASF'nin her çalıştırılışında bu anahtarın da belirtilmesi gerektiğini unutmayın.

`<key>` için bir uzunluk veya karakter zorunluluğu yoktur, ancak güvenlik nedeniyle en az 32 karakter uzunluğunda rastgele bir parola seçmenizi öneririz. Örneğin, Linux'ta `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` komutunu kullanabilirsiniz.

Bu bilgiyi sağlamanın iki farklı yolu daha olduğunu belirtmekte fayda var: `--cryptkey-file` ve `--input-cryptkey`.

Bu özelliğin doğası gereği, komut satırı argümanlarında hassas detaylar bulundurmak istemeyen kullanıcılar için daha uygun bir yöntem olarak, `ASF_CRYPTKEY` çevre değişkenini tanımlayarak da kriptografik anahtarı ayarlamak mümkündür.

---

`--cryptkey-file <path>` veya `--cryptkey-file=<path>` - ASF'yi, belirtilen `<path>` dosyasından okunan özel bir kriptografik anahtarla başlatır. Bu, yukarıda açıklanan `--cryptkey <key>` ile aynı amaca hizmet eder, tek fark mekanizmadır. Bu argüman, `<key>` değerini komut satırından almak yerine belirtilen `<path>` dosyasından okur. Bu argümanı `--path` ile birlikte kullanıyorsanız, göreli dosya yolunun argümanların sırasına göre değişebileceğini unutmayın. Yani, `--path` argümanını `--cryptkey-file` argümanından önce mi yoksa sonra mı kullandığınız önemlidir.

Bu özelliğin doğası gereği, komut satırı argümanlarında hassas detaylar bulundurmak istemeyen kullanıcılar için daha uygun bir yöntem olarak, `ASF_CRYPTKEY_FILE` çevre değişkenini tanımlayarak da kriptografik anahtar dosyasının yolunu belirtmek mümkündür.

---

`--ignore-unsupported-environment` - ASF'nin desteklenmeyen bir ortamda çalışmaktan kaynaklanan sorunları görmezden gelmesini sağlar. Normalde bu tür bir durumda program bir hata vererek kapanır. Desteklenmeyen ortamlara örnek olarak `linux-x64` üzerinde `win-x64` için hazırlanmış bir sürümü çalıştırmak verilebilir. Bu argüman ASF'nin bu gibi senaryolarda çalışmayı denemesine izin verse de, bu tür kullanımları resmi olarak desteklemediğimizi ve bunu tamamen **kendi sorumluluğunuzda** yaptığınızı unutmayın. Desteklenmeyen ortam senaryolarının **tümünün** aslında **düzeltilebilir** olduğunu belirtmek önemlidir. Bu argümanı kullanmak yerine mevcut sorunları düzeltmenizi şiddetle tavsiye ederiz.

---

`--input-cryptkey` - ASF'nin başlangıç sırasında size `--cryptkey` sormasını sağlar. Kriptografik anahtarınızı bir çevre değişkeni veya dosya içinde saklamak yerine, hiçbir yere kaydetmeyip her ASF çalıştırılışında elle girmeyi tercih ediyorsanız bu seçenek sizin için kullanışlı olabilir.

---

`--minimized` - ASF konsol penceresinin başlangıçtan kısa bir süre sonra simge durumuna küçültülmesini sağlar. Genellikle otomatik başlatma senaryolarında kullanışlıdır, ancak bunun dışında da kullanılabilir. Bu seçenek, uygun ortam desteği gerektirir ve her senaryoda düzgün çalışmayabilir.

---

`--network-group <group>` veya `--network-group=<group>` - ASF'nin istek sınırlayıcılarını, belirtilen `<group>` değerini özel bir ağ grubu olarak kullanarak başlatmasını sağlar. Bu seçenek, ASF'yi **[birden fazla örnekte](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-tr-TR#multiple-instances)** çalıştırırken, mevcut örneğin yalnızca aynı ağ grubunu paylaşan diğer örneklere bağlı olduğunu ve geri kalanından bağımsız olduğunu belirtir. Genellikle bu özelliği yalnızca, ASF'nin bunu otomatik olarak yapmasına (ki bu şu anda yalnızca `WebProxy` ayarını dikkate almaktadır) güvenmek yerine, ASF isteklerini özel bir mekanizma (örneğin farklı IP adresleri) üzerinden yönlendiriyorsanız ve ağ gruplarını kendiniz belirlemek istiyorsanız kullanmalısınız. Özel bir ağ grubu kullandığınızda, bunun yerel makine içinde benzersiz bir tanımlayıcı olduğunu ve ASF'nin `WebProxy` değeri gibi başka herhangi bir detayı dikkate almayacağını unutmayın. Bu, örneğin farklı `WebProxy` değerlerine sahip olmalarına rağmen hala birbirine bağımlı olan iki örnek başlatmanıza olanak tanır.

Bu özelliğin doğası gereği, `ASF_NETWORK_GROUP` çevre değişkenini tanımlayarak da bu değeri ayarlamak mümkündür. Bu, komut satırı argümanlarında hassas detaylar bulundurmak istemeyen kullanıcılar için daha uygun olabilir.

---

`--no-config-migrate` - varsayılan olarak ASF, yapılandırma dosyalarınızı otomatik olarak en güncel sözdizimine taşır. Bu taşıma işlemi, kullanımdan kaldırılmış özellikleri yenileriyle değiştirmeyi, varsayılan değerlere sahip özellikleri (etkileri olmadığından) kaldırmayı ve dosyayı genel olarak temizlemeyi (girintilemeyi düzeltmek gibi) içerir. Bu neredeyse her zaman iyi bir özelliktir, ancak ASF'nin yapılandırma dosyalarının üzerine otomatik olarak yazmasını istemediğiniz özel durumlar olabilir. Örneğin, bir güvenlik önlemi olarak yapılandırma dosyalarınıza `chmod 400` (sadece sahip için okuma izni) veya `chattr +i` gibi komutlar uygulayarak herkesin yazma erişimini engellemek isteyebilirsiniz. Genellikle yapılandırma taşıma özelliğini etkin tutmanızı öneririz, ancak bunu devre dışı bırakmak için özel bir nedeniniz varsa, bu argümanı kullanabilirsiniz. Ancak unutmayın ki, bu durumda ASF'ye doğru ayarları sağlamak, özellikle gelecekteki ASF sürümlerinde kullanımdan kaldırılacak veya yeniden düzenlenecek özellikler açısından, sizin sorumluluğunuzda olacaktır.

---

`--no-config-watch` - varsayılan olarak ASF, dosya değişiklikleriyle ilgili olayları dinlemek ve bunlara anlık olarak uyum sağlamak için `config` dizininizi bir `FileSystemWatcher` (Dosya Sistemi İzleyicisi) ile izler. Örneğin bu, bir yapılandırma dosyası silindiğinde botun durdurulmasını, değiştirildiğinde yeniden başlatılmasını veya `config` dizinine bir anahtar dosyası bıraktığınızda **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-tr-TR)** özelliğine anahtarların yüklenmesini içerir. Bu argüman, bu davranışı devre dışı bırakmanızı sağlar. Bu durumda ASF, `config` dizinindeki tüm değişiklikleri tamamen görmezden gelir ve bu tür eylemleri (genellikle süreci yeniden başlatarak) manuel olarak yapmanızı gerektirir. Yapılandırma olaylarını etkin tutmanızı öneririz, ancak bunu devre dışı bırakmak için özel bir nedeniniz varsa, bu argümanı kullanabilirsiniz.

---

`--no-restart` - varsayılan olarak ASF, gerektiğinde yeniden başlatmaya izin verilip verilmeyeceğini belirlemek için kullanabileceğiniz **[`AutoRestart`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-tr-TR#autorestart)** yapılandırma özelliğine uyar. Sunduğumuz bazı çözümler (örneğin ASF'yi `docker` veya `systemd` ile çalıştırmak) süreç yönetimini kendileri üstlenirler ve ASF'nin otomatik yeniden başlatma işleviyle açıkça uyumsuzdurlar. Çünkü bu çözümler sürecin yalnızca kapanmasını bekler; sonrasında gerekirse süreci yeniden başlatmak onların sorumluluğundadır. Yapılandırma dosyasının keyfi olarak düzenlenmesi istenmeyen bir durum olduğundan, bu argüman, yapılandırmada aksini belirtmiş olsanız bile `AutoRestart` özelliğinizi açıkça `false` olarak ayarlayarak geçersiz kılar. Bu sayede ASF, uyumlu bir `AutoRestart: false` yapılandırma dosyası sağlama zorunluluğu olmadan bu tür bir ortamda çalıştığı hakkında önceden bilgilendirilebilir.

Yukarıdakilere ek olarak, `--no-restart` argümanı, `AutoRestart: false` ayarının aksine, `restart` komutunu kullanmanızı veya ASF sürecini başka bir yolla yeniden başlatmanızı da engeller. Çünkü bu argüman, ASF'nin yeniden başlatma ile uyumlu bir kurulumda çalışmadığını kesin olarak belirtirken, `AutoRestart` özelliği yalnızca varsayılan otomatik davranışı belirler.

Normalde burada açıklanan davranışı yapılandırma dosyasından kontrol edebilirsiniz (ve etmelisiniz). Ancak, ASF'yi özel bir betik veya benzeri bir ortamda çalıştırıyorsanız, ASF'nin kendini yeniden başlatmasını yasaklayan bu argümanı kullanmak isteyebilirsiniz.

---

`--no-steam-parental-generation` - varsayılan olarak ASF, **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-tr-TR#steamparentalcode)** yapılandırma özelliğinde açıklandığı gibi, Steam Aile Pini'ni otomatik olarak üretmeye çalışır. Ancak, bu işlem aşırı miktarda sistem kaynağı gerektirebileceğinden, bu argüman bu davranışı devre dışı bırakmanıza olanak tanır. Bu durumda ASF otomatik üretme adımını atlayarak doğrudan kullanıcıdan PIN girmesini ister; normalde bu yalnızca otomatik üretme başarısız olduğunda gerçekleşirdi. Genellikle pin üretme özelliğini etkin tutmanızı öneririz, ancak bunu devre dışı bırakmak için özel bir nedeniniz varsa, bu argümanı kullanabilirsiniz.

---

`--path <path>` veya `--path=<path>` - ASF, başlangıçta her zaman kendi bulunduğu dizine geçer. Bu argümanı belirterek, ASF'nin başlatma sonrası belirtilen dizine geçmesini sağlarsınız. Bu, program dosyalarını kopyalamaya gerek kalmadan çeşitli uygulama bileşenleri (`config`, `logs`, `plugins` ve `www` dizinleri ile `NLog.config` dosyası dahil) için özel bir yol kullanmanıza olanak tanır. Bu, özellikle program dosyalarını asıl yapılandırma dosyalarından ayırmak istediğinizde (Linux benzeri paketleme sistemlerinde olduğu gibi) kullanışlı olabilir. Bu sayede, tek bir güncel program dosyasını birden fazla farklı kurulum için kullanabilirsiniz. Belirtilen yol, ASF program dosyasının mevcut konumuna göre göreceli veya mutlak bir yol olabilir. Bu komutun yeni bir "ASF ana dizini" belirlediğini unutmayın. Bu dizin, içinde `config` klasörünü barındıran ve orijinal ASF ile aynı yapıya sahip bir dizin olmalıdır. Açıklama için aşağıdaki örneğe bakın.

Bu özelliğin doğası gereği, `ASF_PATH` çevre değişkenini tanımlayarak da bu yolu belirtmek mümkündür. Bu, komut satırı argümanlarında hassas detaylar bulundurmak istemeyen kullanıcılar için daha uygun olabilir.

ASF'nin birden fazla örneğini çalıştırmak için bu komut satırı argümanını kullanmayı düşünüyorsanız, konuyla ilgili **[yönetim sayfamızı](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-tr-TR#multiple-instances)** okumanızı öneririz.

Örnekler:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/HedefDizin # Mutlak yol
dotnet /opt/ASF/ArchiSteamFarm.dll --path ../HedefDizin # Göreceli yol da çalışır
ASF_PATH=/opt/HedefDizin dotnet /opt/ASF/ArchiSteamFarm.dll # Çevre değişkeniyle aynı işlev
```

```text
├── 📁 /opt
│     ├── 📁 ASF
│     │     ├── ⚙️ ArchiSteamFarm.dll
│     │     └── ...
│     └── 📁 HedefDizin
│           ├── 📁 config
│           ├── 📁 logs (oluşturulur)
│           ├── 📁 plugins (isteğe bağlı)
│           ├── 📁 www (isteğe bağlı)
│           ├── 📄 log.txt (oluşturulur)
│           └── 📄 NLog.config (isteğe bağlı)
└── ...
```

---

`--service` - bu argüman temel olarak `systemd` servisimiz tarafından kullanılır ve `Headless` ayarını `true` olmaya zorlar. Özel bir ihtiyacınız yoksa, bunun yerine `Headless` özelliğini doğrudan yapılandırma dosyanızdan ayarlamalısınız. Bu argüman, `systemd` servisimizin kendi ortamına uyum sağlamak için genel yapılandırma dosyanıza dokunmasına gerek kalmaması için mevcuttur. Elbette, benzer bir ihtiyacınız varsa siz de bu argümanı kullanabilirsiniz (aksi takdirde genel yapılandırma özelliğini kullanmanız daha iyidir).

---

`--system-required` - bu argümanı belirtmek, ASF'nin işletim sistemine, çalıştığı süre boyunca sistemin de açık ve çalışır durumda kalması gerektiğini bildirmeye çalışmasını sağlar. Bu, özellikle gece boyunca PC'nizde veya dizüstü bilgisayarınızda kart düşürürken kullanışlı olabilir, çünkü ASF çalıştığı sürece sisteminizi uyanık tutabilecektir. Bu özellik şu anda Linux ve Windows işletim sistemlerinde desteklenmektedir.

On Linux, you'll need properly working **[dbus](https://en.wikipedia.org/wiki/D-Bus)** with login daemon that supports **[`Inhibit()`](https://systemd.io/INHIBITOR_LOCKS/)** function. Two most popular daemons, `systemd` as well as `elogind`, are confirmed to support that. Majority of desktop environments (such as Gnome or KDE) should work out of the box, as they already depend on this functionality for their own needs.

Windows işletim sistemiyle ilgili özel bir gereksinim yok, kurulumdan sonra sorunsuz çalışması gerekiyor.