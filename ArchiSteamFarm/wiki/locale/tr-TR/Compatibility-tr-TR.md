# Uyumluluk

ASF, .NET platformunda çalışan bir C# uygulamasıdır. Bu, ASF'nin doğrudan işlemcinizde (CPU) çalışan **[makine koduna](https://tr.wikipedia.org/wiki/Makine_kodu)** değil, çalıştırılması için CIL uyumlu bir çalışma zamanı (runtime) gerektiren **[CIL](https://tr.wikipedia.org/wiki/Common_Intermediate_Language)** (Ortak Ara Dil) koduna derlendiği anlamına gelir.

CIL platformdan bağımsız olduğu için bu yaklaşımın devasa avantajları vardır. Bu sayede ASF, başta Windows, Linux ve macOS olmak üzere birçok işletim sisteminde yerel olarak çalışabilir. Bu sayede yalnızca emülasyona gerek kalmaz, aynı zamanda CPU SSE talimatları gibi platform ve donanım ile ilgili tüm optimizasyonlar da desteklenir. Bunun sayesinde ASF, mükemmel uyumluluk ve güvenilirlik sunarken üstün performans ve optimizasyon sağlayabilir.

Bu aynı zamanda ASF'nin **belirli bir işletim sistemi gereksinimi olmadığı** anlamına da gelir, çünkü programın kendisi işletim sistemine değil, o işletim sisteminde çalışan bir **çalışma zamanına (runtime)** ihtiyaç duyar. Bu çalışma zamanı ASF kodunu düzgün bir şekilde çalıştırdığı sürece, altta yatan işletim sisteminin Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii veya tost makineniz olması fark etmez. Bir platform için **[.NET](https://dotnet.microsoft.com/download/dotnet)** mevcutsa, o platform için (`generic` türünde) bir **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** de mevcuttur.

Ancak, ASF'yi nerede çalıştırırsanız çalıştırın, hedef platformunuzda **[.NET önkoşullarının](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** yüklü olduğundan emin olmalısınız. Bunlar, çalışma zamanının düzgün işlevselliği için gerekli olan düşük seviyeli kütüphanelerdir ve ASF'nin çalışabilmesi için kesinlikle temel bir öneme sahiptir. Büyük olasılıkla bunlardan bazıları (veya hepsi) sisteminizde zaten yüklü olabilir.

---

## ASF Paketlemesi

ASF'nin iki ana türü vardır: genel (generic) paket ve işletim sistemine özgü (OS-specific) paket. İşlevsellik açısından her iki paket de tamamen aynıdır ve her ikisi de kendini otomatik olarak güncelleyebilir. Aralarındaki tek fark, **genel** paketin aksine **işletim sistemine özgü** paketin, çalışması için gereken çalışma zamanını (runtime) kendi içinde barındırıp barındırmamasıdır.

---

### Genel (Generic)

Genel paket, herhangi bir makineye özgü kod içermeyen, platformdan bağımsız bir sürümdür. Bu kurulum, işletim sisteminizde **uygun sürümde** bir .NET çalışma zamanının önceden yüklenmiş olmasını gerektirir. Bağımlılıkları güncel tutmanın ne kadar zahmetli olduğunu biliyoruz. Bu nedenle bu paket, temel olarak .NET'i **zaten kullanan** ve mevcut çalışma zamanlarından yararlanabilecekken yalnızca ASF için ikinci bir tane kurmak istemeyen kişiler içindir. Ayrıca genel paket, işletim sistemine özgü bir ASF sürümü olup olmadığına bakılmaksızın, **çalışan bir .NET çalışma zamanı edinebildiğiniz sürece ASF'yi her yerde çalıştırmanıza** olanak tanır.

Eğer sadece ASF'yi çalıştırmak isteyen ve .NET'in teknik detaylarıyla uğraşmak istemeyen sıradan veya hatta ileri düzey bir kullanıcıysanız, genel türü kullanmanız önerilmez. Başka bir deyişle, ne yaptığınızı biliyorsanız bunu kullanabilirsiniz, aksi takdirde aşağıda açıklanan işletim sistemine özgü paketi kullanmak çok daha iyidir.

---

### İşletim Sistemine Özgü (OS-specific)

İşletim sistemine özgü paket, genel pakette bulunan yönetilen koda ek olarak, ilgili platform için yerel kodu da içerir. Başka bir deyişle, işletim sistemine özgü paket **gerekli .NET çalışma zamanını zaten içinde barındırır**, bu da tüm kurulum karmaşasını atlayıp ASF'yi doğrudan başlatmanıza olanak tanır. İşletim sistemine özgü paket, adından da anlaşılacağı gibi, belirli bir işletim sistemine özeldir ve her işletim sistemi kendi sürümünü gerektirir. Örneğin, Windows PE32+ `ArchiSteamFarm.exe` dosyasını gerektirirken, Linux Unix ELF `ArchiSteamFarm` dosyasıyla çalışır. Bildiğiniz gibi, bu iki tür birbiriyle uyumlu değildir.

ASF şu anda aşağıdaki işletim sistemine özgü türlerde mevcuttur:

- `linux-arm`, glibc 2.35/musl 1.2.3 ve daha yeni sürümlerine sahip 32 bit ARM tabanlı (ARMv7+) GNU/Linux işletim sistemlerinde çalışır. Bu tür, Raspberry Pi 2 (ve daha yenisi) gibi platformları kapsar. Raspberry Pi 0 ve 1'de bulunan ARMv6 gibi daha eski ARM mimarileriyle **çalışmaz**. Ayrıca, gerekli GNU/Linux ortamını sağlamayan işletim sistemleriyle de (Android gibi) çalışmaz.
- `linux-arm64`, glibc 2.27/musl 1.2.3 ve daha yeni sürümlerine sahip 64 bit ARM tabanlı (ARMv8+) GNU/Linux işletim sistemlerinde çalışır. Bu tür, Raspberry Pi 3 (ve daha yenisi) gibi platformları kapsar. Gerekli 64-bit kütüphanelerine sahip olmayan 32-bit işletim sistemleriyle (örneğin 32-bit Raspberry Pi OS) **çalışmaz**. Ayrıca, gerekli GNU/Linux ortamını sağlamayan işletim sistemleriyle de (Android gibi) çalışmaz.
- `linux-x64`, glibc 2.27/musl 1.2.3 ve daha yeni sürümlerine sahip 64 bit GNU/Linux işletim sistemlerinde çalışır.
- `osx-arm64`, 13 ve daha yeni sürümlerdeki 64-bit ARM tabanlı (Apple Silicon) macOS işletim sistemlerinde çalışır.
- `osx-x64`, 15 ve daha yeni sürümlerdeki 64-bit macOS işletim sistemlerinde çalışır.
- `win-arm64` works on **up-to-date** 64-bit ARM-based (ARMv8+) Windows OSes in version 10, 11 and newer.
- `win-x64` works on **up-to-date** 64-bit Windows OSes in version 10, 11, Server 2016+ and newer.

Elbette, işletim sistemi-mimari kombinasyonunuz için işletim sistemine özgü bir paket mevcut olmasa bile, her zaman uygun .NET çalışma zamanını kendiniz yükleyebilir ve genel ASF türünü çalıştırabilirsiniz. Zaten genel türün var olmasının ana nedeni de budur. Genel ASF sürümü platformdan bağımsızdır ve çalışan bir .NET çalışma zamanına sahip herhangi bir platformda çalışır. Şunu belirtmek önemlidir: ASF, belirli bir işletim sistemi veya mimari değil, bir .NET çalışma zamanı gerektirir. Örneğin, 32-bit Windows kullanıyorsanız, özel bir `win-x86` ASF sürümü olmamasına rağmen, .NET SDK'nın `win-x86` sürümünü yükleyebilir ve genel ASF türünü sorunsuzca çalıştırabilirsiniz. Mevcut olan ve birileri tarafından kullanılan her işletim sistemi-mimari kombinasyonunu hedeflememiz mümkün değil, bu yüzden bir yerde bir sınır çizmek zorundayız. En az 2004'ten beri modası geçmiş bir mimari olan x86, bu sınıra iyi bir örnektir.

.NET 10.0 tarafından desteklenen tüm platformların ve işletim sistemlerinin tam listesi için **[sürüm notlarını](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md)** ziyaret edebilirsiniz.

---

## Çalışma Zamanı Gereksinimleri

Eğer işletim sistemine özgü bir paket kullanıyorsanız, çalışma zamanı gereksinimleri hakkında endişelenmenize gerek yoktur. Çünkü ASF, **[.NET önkoşulları](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** yüklü ve güncel olduğu sürece düzgün çalışacak olan, gerekli ve güncel çalışma zamanını her zaman içinde barındırır. Başka bir deyişle, **.NET çalışma zamanını veya SDK'yı yüklemeniz gerekmez**, çünkü işletim sistemine özgü sürümler yalnızca yerel işletim sistemi bağımlılıklarını (önkoşulları) gerektirir, başka bir şeye ihtiyaç duymaz.

Ancak, **genel** ASF paketini çalıştırmaya çalışıyorsanız, .NET çalışma zamanınızın ASF'nin gerektirdiği platformu desteklediğinden emin olmalısınız.

ASF programı şu anda **.NET 10.0** (`net10.0`) platformunu hedefliyor, ancak gelecekte daha yeni platformları da hedefleyebilir. `net10.0`, 10.0.100 SDK (10.0.0 runtime) sürümünden itibaren desteklenmektedir. Ancak ASF, **derleme sırasında en güncel runtime**’ı tercih edebilir. Bu nedenle, sisteminizde **[en güncel SDK](https://dotnet.microsoft.com/download)**’nın (ya da en azından runtime’ın) kurulu olduğundan emin olmalısınız. Eğer çalışma zamanınız, derleme sırasında belirtilen minimum desteklenen sürümden daha eskiyse, genel ASF türü başlamayı reddedebilir.

Şüpheye düşerseniz, GitHub'daki ASF sürümlerini derlemek ve dağıtmak için **[sürekli entegrasyon (CI) sistemimizin](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** ne kullandığını kontrol edin. Her derlemenin .NET doğrulama adımının bir parçası olarak `dotnet --info` çıktısını bulabilirsiniz.