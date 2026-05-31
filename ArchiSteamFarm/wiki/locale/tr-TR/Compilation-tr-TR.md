# Derleme

Derleme, yürütülebilir dosya oluşturma işlemidir. ASF'ye kendi değişikliklerinizi eklemek istiyorsanız ya da herhangi bir nedenden ötürü resmi **[ sürümler ](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ile sağlanan yürütülebilir dosyalara güvenmiyorsanız yapmak istediğiniz şey budur. Eğer kullanıcıysanız ve geliştirici değilseniz muhtemelen önceden derlenmiş dosyaları kullanmak istersiniz ama kendinizinkileri kullanmak ya da yeni birşeyler öğrenmek istiyorsanız okumaya devam edin.

ASF, bütün gerekli araçlara sahip olduğunuz sürece şu anda desteklenen herhangi bir platformda derlenebilir.

---

## .NET SDK

Platformdan bağımsız olarak, ASF'yi derlemek için tam .NET SDK'sına (sadece çalışma zamanı değil) ihtiyacınız vardır. Kurulum talimatlarını **[.NET indirme sayfasında](https://dotnet.microsoft.com/download)** bulabilirsiniz. İşletim sisteminiz için uygun .NET SDK sürümünü yüklemeniz gerekir. Başarılı bir kurulumdan sonra `dotnet` komutu çalışır ve kullanılabilir durumda olmalıdır. Çalışıp çalışmadığını `dotnet --info` komutuyla doğrulayabilirsiniz. Ayrıca .NET SDK'nızın, ASF'nin **[çalışma zamanı gereksinimleri](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-tr-TR#runtime-requirements)** ile eşleştiğinden emin olun.

---

## Derleme

.NET SDK'nızın çalışır durumda ve uygun sürümde olduğunu varsayarsak, ASF kaynak dizinine (klonlanmış veya indirilip açılmış ASF deposu) gidin ve şunu çalıştırın:

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic"
```

Eğer Linux/macOS kullanıyorsanız, bunun yerine aynı işi biraz daha karmaşık bir şekilde yapacak olan `cc.sh` betiğini kullanabilirsiniz.

Derleme başarıyla tamamlandıysa, ASF'nizi `out/generic` dizininde `kaynak` türünde bulabilirsiniz. Bu, resmi `generic` ASF sürümüyle aynıdır, ancak kendi derlemeleriniz için uygun olacak şekilde `UpdateChannel` ve `UpdatePeriod` değerleri `0` olarak zorlanır.

### İşletim Sistemine Özgü

Özel bir ihtiyacınız varsa, işletim sistemine özgü bir .NET paketi de oluşturabilirsiniz. Genelde bunu yapmanıza gerek yoktur, çünkü zaten derleme için kullandığınız mevcut .NET çalışma zamanınızla çalıştırabileceğiniz `generic` türünü derlediniz. Ancak yine de isterseniz:

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/linux-x64" -r "linux-x64" --self-contained
```

Elbette, `linux-x64` kısmını, `win-x64` gibi hedeflemek istediğiniz işletim sistemi-mimarisi ile değiştirin. Bu sürümde de güncellemeler devre dışı bırakılacaktır. `--self-contained` derlemesi yaparken isteğe bağlı olarak iki anahtar daha bildirebilirsiniz: `-p:PublishTrimmed=true` kırpılmış bir çıktı üretirken, `-p:PublishSingleFile=true` tek bir dosya çıktısı üretir. Her ikisini de eklemek, bizim kendi sürümlerimiz için kullandığımız ayarlarla aynı sonucu verecektir.

### ASF-ui

Yukarıdaki adımlar tam olarak çalışan bir ASF sürümüne sahip olmak için gereken her şeyi içerse de, *ayrıca* grafiksel web arayüzümüz olan **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-tr-TR#asf-ui)**'yi de derlemek isteyebilirsiniz. ASF tarafında tek yapmanız gereken, ASF-ui derleme çıktısını standart `ASF-ui/dist` konumuna bırakmak ve ardından ASF'yi (gerekirse tekrar) bu çıktıyla birlikte derlemektir.

ASF-ui, ASF'nin kaynak ağacının bir parçası olarak bir **[git alt modülü](https://git-scm.com/book/tr/v2/Git-Ara%C3%A7lar%C4%B1-Alt-Mod%C3%BCller)** şeklinde yer alır. Gerekli dosyalara sahip olmak için depoyu `git clone --recursive` komutuyla klonladığınızdan emin olun. Ayrıca çalışan bir NPM'e ihtiyacınız olacak; **[Node.js](https://nodejs.org)** kurulumu NPM'i de içerir. Eğer Linux/macOS kullanıyorsanız, ASF-ui'nin derlenmesi ve paketlenmesini otomatik olarak halleden `cc.sh` betiğimizi öneririz (tabii ki az önce belirttiğimiz gereksinimleri karşılıyorsanız).

`cc.sh` betiğine ek olarak, aşağıda basitleştirilmiş derleme talimatlarını da bulabilirsiniz. Ek belgeler için **[ASF-ui deposuna](https://github.com/JustArchiNET/ASF-ui)** başvurun. ASF'nin kaynak ağacı konumundan, yani yukarıdaki gibi, aşağıdaki komutları çalıştırın:

```shell
rm -rf "ASF-ui/dist" # ASF-ui eski derlemeden sonra kendini temizlemez

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # Derleme çıktımızın eski dosyalardan temizlendiğinden emin olun
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic" # Veya yukarıda belirtildiği gibi ihtiyacınıza göre
```

Artık ASF-ui dosyalarını `out/generic/www` klasörünüzde bulabilmelisiniz. ASF bu dosyaları tarayıcınıza sunabilecektir.

Alternatif olarak, ASF-ui'yi manuel olarak veya depomuzun yardımıyla derleyebilir, ardından derleme çıktısını manuel olarak `${OUT}/www` klasörüne kopyalayabilirsiniz. Burada `${OUT}`, `-o` parametresiyle belirttiğiniz ASF çıktı klasörüdür. This is exactly what ASF is doing as part of the build process, it copies `ASF-ui/dist` (if exists) over to `${OUT}/www`, nothing special, and can also be done post-build as you can see, if needed.

---

## Geliştirme

Eğer ASF kodunu düzenlemek isterseniz, bu amaçla herhangi bir .NET uyumlu IDE kullanabilirsiniz. Ancak bu bile isteğe bağlıdır, çünkü bir not defteri ile düzenleme yapıp yukarıda açıklanan `dotnet` komutuyla derleyebilirsiniz.

If you don't have a better pick, we can recommend **[JetBrains Rider](https://www.jetbrains.com/rider)** and **[Visual Studio Code](https://code.visualstudio.com/download)**, with first one being the preferred IDE that ASF team is personally using, and second one being viable alternative. Both programs are cross-platform and available on Linux, macOS and Windows.

---

## Etiketler (Tags)

**[Sürüm döngümüzde](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-tr-TR)** belirtildiği gibi, `main` branch'i bir geliştirme branch'i olduğundan, başarılı bir derlemeye veya kusursuz bir ASF çalışmasına izin verecek bir durumda olduğu garanti edilmez. Eğer ASF'yi kaynaktan derlemek veya referans almak istiyorsanız, bu amaçla uygun bir **[etiket (tag)](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** kullanmalısınız. Bu, en azından başarılı bir derlemeyi ve büyük olasılıkla (eğer sürüm kararlı olarak işaretlenmişse) kusursuz çalışmayı garanti eder. Kaynak ağacının mevcut "sağlığını" kontrol etmek için CI sistemimizi kullanabilirsiniz: **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Resmi Sürümler

Resmi ASF sürümleri, ASF'nin **[çalışma zamanı gereksinimleriyle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-tr-TR#runtime-requirements)** eşleşen en son .NET SDK ile **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)** tarafından derlenir. Testleri geçtikten sonra, tüm paketler yine GitHub üzerinde sürüm olarak dağıtılır. Bu aynı zamanda şeffaflığı da garanti eder, çünkü GitHub tüm derlemeler için her zaman resmi ve herkese açık kaynak kodunu kullanır ve siz de GitHub derleme çıktıları (artifacts) ile GitHub sürüm varlıklarının (assets) sağlama toplamlarını (checksums) karşılaştırabilirsiniz. ASF geliştiricileri, özel geliştirme süreçleri ve hata ayıklama dışında, sürümleri kendileri derlemez veya yayınlamazlar.

Yukarıdakilere ek olarak, ASF bakımcıları ek bir güvenlik önlemi olarak, derleme sağlama toplamlarını (checksums) GitHub'dan bağımsız, uzak bir ASF sunucusunda manuel olarak doğrular ve yayınlar. Bu adım, mevcut ASF kurulumlarının bir sürümü otomatik güncelleme işlevi için geçerli bir aday olarak kabul etmesi için zorunludur.