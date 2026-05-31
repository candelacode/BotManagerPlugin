# Docker

ASF, bir **[docker konteyneri](https://www.docker.com/what-container)** olarak mevcuttur. Docker paketlerimiz şu anda hem **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** hem de **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)** üzerinde mevcuttur.

ASF'yi bir Docker konteynerinde çalıştırmanın **gelişmiş bir kurulum** olarak kabul edildiğini, kullanıcıların büyük çoğunluğu için **gerekli olmadığını** ve genellikle konteynersiz kuruluma göre **hiçbir avantaj sağlamadığını** belirtmek önemlidir. Eğer ASF'yi bir servis olarak çalıştırmak için (örneğin işletim sisteminizle otomatik olarak başlatmak) Docker'ı bir çözüm olarak düşünüyorsanız, bunun yerine **[yönetim](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-tr-TR#systemd-service-for-linux)** bölümünü okumayı ve uygun bir `systemd` servisi kurmayı düşünmelisiniz. Bu, ASF'yi bir Docker konteynerinde çalıştırmaktan **neredeyse her zaman** daha iyi bir fikirdir.

ASF'yi bir Docker konteynerinde çalıştırmak genellikle yüzleşmeniz ve kendi başınıza çözmeniz gereken **birkaç yeni problem ve sorun** içerir. Bu yüzden, zaten Docker bilginiz yoksa ve iç işleyişini anlama konusunda yardıma ihtiyacınız yoksa (ki bu konuyu burada ASF vikisinde detaylandırmayacağız), bundan kaçınmanızı **şiddetle** tavsiye ederiz. Bu bölüm, çoğunlukla çok karmaşık kurulumların geçerli kullanım durumları içindir; örneğin, ileri düzey ağ yapılandırması veya ASF'nin `systemd` servisiyle birlikte gelen (ve zaten çok gelişmiş güvenlik mekanizmalarıyla üstün süreç izolasyonu sağlayan) standart sanal alan (sandbox) korumasının ötesindeki güvenlik durumları gibi. Bu bir avuç insan için, burada ASF'nin Docker uyumluluğuna ilişkin kavramlarını daha iyi açıklıyoruz, sadece bu kadar. Eğer ASF ile birlikte kullanmaya karar verirseniz, yeterli Docker bilgisine sahip olduğunuz varsayılmaktadır.

---

## Etiketler (Tags)

ASF is available through several types of **[tags](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `main`

Generic build of ASF that is built from the very latest commit in `main` branch, which works the same as grabbing latest artifact directly from our **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pipeline. It's the highest level of bugged software dedicated to developers and advanced users for development purposes. The image is being updated with each commit in the `main` GitHub branch, therefore you can expect very often changes (and stuff being broken). It's here to mark current state of the ASF project, which is not necessarily guaranteed to be stable or tested, just like pointed out in our release cycle. **This tag should not be used in any production environment**. Useful for verification whether particular commit fixed the issue you're encountering, without waiting even for a pre-release with that commit.


### `released`

Generic build of ASF that always points to the latest **[released](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF version, including pre-releases. Compared to `main` tag, image here is being updated each time a new GitHub tag is pushed. Hem kararlı hem de en güncel olmanın sınırlarında yaşamayı seven ileri düzey/güçlü kullanıcılara adanmıştır. Pratikte bu, imajı çektiğiniz anda en son `A.B.C.D` sürümüne işaret eden değişken bir etiket gibi çalışır. Please note that using this tag is equal to using our **[pre-releases](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `kararlı`

Generic build of ASF that always points to the latest **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF version. Compared to `released` tag, image here is being updated once new stable version of ASF is made available. Recommended for people that are looking for stable variant of `released` tag mentioned above.

### `latest`

OS-specific build of ASF that always points to the latest **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF version. In comparison with others, this is the **only tag** that includes ASF auto-updates. Bu etiketin amacı, kendini güncelleyebilen, işletim sistemine özgü bir ASF sürümünü çalıştırabilen, mantıklı bir varsayılan Docker konteyneri sağlamaktır. Bu nedenle, içerdiği ASF sürümü gerektiğinde her zaman kendini güncelleyebileceği için imajın mümkün olduğunca sık güncellenmesi gerekmez.

Of course, `UpdatePeriod` can be safely turned off (set to `0`), but in this case you should probably use `stable` release instead. Likewise, you can modify default `UpdateChannel` in order to track pre-releases instead if you'd like to.

`latest` imajı otomatik güncelleme yeteneğiyle geldiğinden, diğer tüm etiketlerin aksine (ki onlar .NET çalışma zamanı ve `generic` ASF sürümü içerir), bu imaj yalnızca temel bir işletim sistemi ve ona özgü `linux` ASF sürümünü içerir. Bunun nedeni, daha yeni (güncellenmiş) bir ASF sürümünün, imajın oluşturulduğu çalışma zamanından daha yeni bir çalışma zamanı gerektirebilmesidir. Aksi takdirde, imajın sıfırdan yeniden oluşturulması gerekir ki bu da planlanan kullanım amacını boşa çıkarır.

### `A.B.C.D`

Generic build of ASF that points to the fixed ASF version matching the tag. In comparison with above tags, this tag is completely frozen, which means that the image here won't be updated once published. Bu, ilk yayınlandıktan sonra asla dokunulmayan GitHub sürümlerimize benzer şekilde çalışır ve size kararlı ve değişmez bir ortam garanti eder. Typically you should use this tag when you want to use some specific ASF release and expect deterministic outcome of the build (e.g. managing ASF versions yourself instead).

---

## Hangi etiket benim için en iyisi?

Bu, ne aradığınıza bağlıdır. Kullanıcıların çoğunluğu için `latest` etiketi en iyisi olmalıdır, çünkü masaüstü ASF'nin sunduğu özelliklerin aynısını, yalnızca özel bir Docker konteyneri içinde bir servis olarak sunar. However, this is not necessarily how docker should be used - normally you're expected to rebuild your containers and not run them forever, and in this case you should consider `stable` or `released` tag, which follow docker guidelines. Lastly, if you want to run some fixed ASF version instead, then naturally `A.B.C.D` releases are what you're looking for.

Genel olarak `main` sürümlerini denemenizi önermiyoruz, çünkü bunlar ASF projesinin mevcut durumunu işaretlemek için buradadır. Böyle bir durumun düzgün çalışacağını hiçbir şey garanti etmez, ancak ASF geliştirmesiyle ilgileniyorsanız elbette denemekten çekinmeyin.

---

## Mimariler

ASF docker imajı şu anda `linux` platformunda `x64`, `arm` ve `arm64` olmak üzere 3 mimariyi hedef alarak oluşturulmaktadır. Bunlar hakkında daha fazla bilgiyi **[uyumluluk](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-tr-TR)** bölümünde okuyabilirsiniz.

Etiketlerimiz çoklu platform manifestosu kullanır, bu da makinenize kurulu Docker'ın imajı çekerken platformunuz için uygun imajı otomatik olarak seçeceği anlamına gelir. Eğer bir şekilde o an çalıştığınız platformla eşleşmeyen belirli bir platform imajını çekmek isterseniz, bunu `docker run` gibi uygun docker komutlarındaki `--platform` anahtarı aracılığıyla yapabilirsiniz. Daha fazla bilgi için **[imaj manifestosu](https://docs.docker.com/registry/spec/manifest-v2-2)** hakkındaki Docker belgelerine bakın.

---

## Kullanım

Tam bir referans için **[resmi Docker belgelerini](https://docs.docker.com/engine/reference/commandline/docker)** kullanmalısınız. Bu kılavuzda yalnızca temel kullanımı ele alacağız, daha derine inmekten çekinmeyin.

### Merhaba ASF!

Öncelikle Docker'ımızın düzgün çalışıp çalışmadığını doğrulamalıyız, bu bizim ASF "merhaba dünya" testimiz olacak:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm
```

`docker run`, sizin için yeni bir ASF docker konteyneri oluşturur ve onu ön planda (`-it`) çalıştırır. `--pull always`, her zaman güncel imajın çekilmesini sağlar ve `--rm`, şimdilik her şeyin yolunda gidip gitmediğini test ettiğimiz için konteyner durdurulduğunda kaldırılmasını sağlar.

Eğer her şey başarılı bir şekilde bittiyse, tüm katmanları çektikten ve konteyneri başlattıktan sonra, ASF'nin düzgün bir şekilde başladığını ve tanımlanmış bot olmadığını bize bildirdiğini fark etmelisiniz. Bu iyi bir şey - Docker içindeki ASF'nin düzgün çalıştığını doğruladık. ASF sürecini ve dolayısıyla konteyneri de sonlandırmak için `CTRL+C` tuşlarına basın.

Komuta daha yakından bakarsanız, herhangi bir etiket belirtmediğimizi fark edersiniz, bu da otomatik olarak `latest` etiketinin varsayılan olarak kullanılmasına neden oldu. Eğer `latest` dışında bir etiket kullanmak isterseniz, örneğin `released`, bunu açıkça belirtmelisiniz:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm:released
```

---

## Volume (Birim) Kullanımı

Eğer ASF'yi bir Docker konteynerinde kullanıyorsanız, programı yapılandırmanız gerekir. Bunu çeşitli yollarla yapabilirsiniz, ancak önerilen yöntem, yerel makinenizde bir ASF `config` dizini oluşturmak ve ardından bunu ASF Docker konteynerinde paylaşılan bir birim (volume) olarak bağlamaktır.

Örneğin, ASF yapılandırma klasörünüzün `/home/archi/ASF/config` dizininde olduğunu varsayalım. Bu dizin, çalıştırmak istediğimiz botların yanı sıra temel `ASF.json` dosyasını da içerir. Şimdi tek yapmamız gereken, bu dizini ASF'nin yapılandırma dizinini beklediği yere (`/app/config`) Docker konteynerimizde paylaşılan bir birim olarak bağlamaktır.

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Ve işte bu kadar! Artık ASF Docker konteyneriniz, yerel makinenizle paylaşılan dizini okuma-yazma modunda kullanacak. Bu, ASF'yi yapılandırmak için ihtiyacınız olan her şeydir. Benzer şekilde, `/app/logs` veya `/app/plugins` gibi ASF ile paylaşmak istediğiniz diğer birimleri de bağlayabilirsiniz.

Elbette, bu istediğimizi başarmanın yalnızca belirli bir yoludur. Sizi, örneğin kendi `Dockerfile` dosyanızı oluşturarak yapılandırma dosyalarınızı ASF Docker konteyneri içindeki `/app/config` dizinine kopyalamaktan alıkoyan hiçbir şey yok. Bu kılavuzda yalnızca temel kullanımı ele alıyoruz.

### Birim (Volume) İzinleri

ASF konteyneri varsayılan olarak `root` kullanıcısıyla başlatılır. Bu, dahili izin işlemlerini halletmesine ve ardından ana sürecin geri kalanı için `asf` (UID `1000`) kullanıcısına geçmesine olanak tanır. Bu durum kullanıcıların büyük çoğunluğu için yeterli olsa da, paylaşılan birimi etkiler; çünkü yeni oluşturulan dosyaların sahibi normalde `asf` kullanıcısı olacaktır. Eğer paylaşılan biriminiz için başka bir kullanıcı atamak istiyorsanız, bu istenmeyen bir durum olabilir.

ASF'nin çalıştığı kullanıcıyı iki şekilde değiştirebilirsiniz. The first one, recommended, is to declare `ASF_UID` environment variable with target UID you want to run under. İkinci alternatif yöntem ise, doğrudan Docker tarafından desteklenen `--user` **[parametresini](https://docs.docker.com/engine/reference/run/#user)** kullanmaktır.

`uid`'nizi örneğin `id -u` komutuyla kontrol edebilir ve ardından yukarıda belirtildiği gibi bildirebilirsiniz. Örneğin, hedef kullanıcınızın `uid`'si 1001 ise:

```shell
docker run -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm

# Alternatif olarak, aşağıdaki sınırlamaları anlıyorsanız
docker run -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

The difference between `ASF_UID` and `--user` flag is subtle, but important. `ASF_UID` is custom mechanism supported by ASF, in this scenario docker container still starts as `root`, and then ASF startup script starts main binary under `ASF_UID`. `--user` parametresini kullandığınızda ise, ASF başlangıç betiği de dahil olmak üzere tüm süreci belirttiğiniz kullanıcı olarak başlatırsınız. First option allows ASF startup script to handle permissions and other stuff automatically for you, resolving some common issues that you might've caused, for example it ensures that your `/app` and `/asf` directories are actually owned by `ASF_UID`. İkinci senaryoda ise, `root` olarak çalışmadığımız için bunu yapamayız ve tüm bu işlemleri önceden kendinizin halletmesi beklenir.

If you've decided to use `--user` flag, you need to change ownership of all ASF files from default `1000` to your new custom user. Bunu aşağıdaki komutu çalıştırarak yapabilirsiniz:

```shell
# Yalnızca ASF_UID kullanmıyorsanız çalıştırın
docker exec -u root asf_container_name chown -hR 1001 /app /asf
```

Bu işlem, konteynerinizi `docker run` ile oluşturduktan sonra yalnızca bir kez ve yalnızca `--user` Docker parametresi aracılığıyla özel bir kullanıcı kullanmaya karar verdiyseniz yapılmalıdır. Ayrıca, yukarıdaki komutta yer alan `1001` argümanını, ASF'yi gerçekten altında çalıştırmak istediğiniz `UID` ile değiştirmeyi unutmayın.

### SELinux ile Birim (Volume)

Eğer işletim sisteminizde zorunlu modda SELinux kullanıyorsanız (örneğin RHEL tabanlı dağıtımlarda bu varsayılandır), o zaman birimi bağlarken sonuna `:Z` seçeneğini eklemelisiniz. Bu, birim için doğru SELinux bağlamını ayarlayacaktır.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull always justarchi/archisteamfarm
```

Bu, ASF'nin Docker konteyneri içindeyken birimi hedefleyen dosyalar oluşturmasına olanak tanır.

---

## Birden Fazla Örneği Senkronize Etme

**[Yönetim](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-tr-TR#multiple-instances)** bölümünde belirtildiği gibi, ASF birden fazla örneğin senkronizasyonunu destekler. ASF'yi birden fazla konteynerde çalıştırıyorsanız ve bunların birbirleriyle senkronize olmasını istiyorsanız, isteğe bağlı olarak bu sürece "katılabilirsiniz".

Varsayılan olarak, bir Docker konteyneri içinde çalışan her ASF bağımsızdır, bu da senkronizasyonun gerçekleşmediği anlamına gelir. Aralarında senkronizasyonu etkinleştirmek için, senkronize etmek istediğiniz her ASF konteynerindeki `/tmp/ASF` yolunu, Docker ana makinenizdeki tek bir paylaşılan yola, okuma-yazma modunda bağlamanız gerekir. Bu, yukarıda açıklanan bir birimi bağlamakla tamamen aynı şekilde, yalnızca farklı yollarla gerçekleştirilir:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull always justarchi/archisteamfarm
# Ve bu şekilde devam eder, tüm ASF konteynerleri artık birbiriyle senkronize edilir
```

ASF'nin `/tmp/ASF` dizinini makinenizdeki geçici bir `/tmp` dizinine de bağlamanızı öneririz, ancak elbette kullanımınıza uygun başka birini seçmekte özgürsünüz. Senkronize edilmesi beklenen her ASF konteynerinin `/tmp/ASF` dizini, aynı senkronizasyon sürecinde yer alan diğer konteynerlerle paylaşılmalıdır.

Yukarıdaki örnekten de tahmin edebileceğiniz gibi, farklı Docker ana makine yollarını ASF'nin `/tmp/ASF` yoluna bağlayarak iki veya daha fazla "senkronizasyon grubu" oluşturmak da mümkündür.

`/tmp/ASF` yolunu bağlamak tamamen isteğe bağlıdır ve açıkça iki veya daha fazla ASF konteynerini senkronize etmek istemiyorsanız aslında önerilmez. Tek konteyner kullanımı için `/tmp/ASF` bağlamanızı önermiyoruz, çünkü yalnızca bir ASF konteyneri çalıştırmayı bekliyorsanız kesinlikle hiçbir fayda sağlamaz ve hatta aksi takdirde kaçınılabilecek sorunlara neden olabilir.

---

## Komut Satırı Argümanları

ASF, bir Docker konteyneri içinde **[komut satırı argümanlarını](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-tr-TR)** ortam değişkenleri aracılığıyla geçirmenize olanak tanır. Desteklenen anahtarlar için belirli ortam değişkenlerini, geri kalanı için ise `ASF_ARGS` kullanmalısınız. Bu, `docker run` komutuna eklenen `-e` anahtarıyla gerçekleştirilebilir, örneğin:

```shell
docker run -it -e "ASF_CRYPTKEY=Parolam" -e "ASF_ARGS=--no-config-migrate" --name asf --pull always justarchi/archisteamfarm
```

Bu, `--cryptkey` argümanınızı ve diğer argümanları Docker konteyneri içinde çalışan ASF sürecine düzgün bir şekilde geçirecektir. Elbette, eğer ileri düzey bir kullanıcıysanız, `ENTRYPOINT`'i değiştirebilir veya `CMD` ekleyebilir ve kendi özel argümanlarınızı kendiniz geçirebilirsiniz.

Özel şifreleme anahtarı veya diğer gelişmiş seçenekler sağlamak istemediğiniz sürece, genellikle özel ortam değişkenleri eklemenize gerek yoktur, çünkü Docker konteynerlerimiz zaten `--no-restart` gibi mantıklı bir varsayılan seçenekle çalışacak şekilde yapılandırılmıştır, bu nedenle bu bayrağın `ASF_ARGS` içinde açıkça belirtilmesine gerek yoktur.

---

## IPC

`IPC` **[genel yapılandırma özelliğinin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-tr-TR#global-config)** varsayılan değerini değiştirmediğinizi varsayarsak, bu özellik zaten etkindir. Ancak, IPC'nin Docker konteynerinde çalışması için iki ek şey yapmanız gerekir. İlk olarak, dışarıdan parola kullanmadan bağlanmanıza izin vermek için ya `IPCPassword` kullanmalı ya da özel bir `IPC.config` dosyasında varsayılan `KnownNetworks` ayarını değiştirmelisiniz. Ne yaptığınızı gerçekten bilmiyorsanız, sadece `IPCPassword` kullanın. İkinci olarak, Docker dış trafiği geri döngü arayüzüne (loopback interface) yönlendiremediği için varsayılan dinleme adresi olan `localhost`'u değiştirmelisiniz. Tüm arayüzleri dinleyecek bir ayar örneği `http://*:1242` olabilir. Elbette, yalnızca yerel LAN veya VPN ağı gibi daha kısıtlayıcı bağlamalar da kullanabilirsiniz, ancak rotanın dışarıdan erişilebilir olması gerekir - rota tamamen misafir makinenin içinde olduğundan `localhost` işe yaramayacaktır.

Yukarıdakileri yapmak için aşağıdaki gibi **[özel bir IPC yapılandırması](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-tr-TR#custom-configuration)** kullanmalısınız:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

IPC'yi geri döngü olmayan bir arayüzde kurduktan sonra, Docker'a ASF'nin `1242/tcp` portunu `-P` veya `-p` anahtarıyla eşlemesini söylememiz gerekir.

Örneğin, bu komut ASF IPC arayüzünü (yalnızca) ana makineye açar:

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull always justarchi/archisteamfarm
```

Her şeyi doğru ayarlarsanız, yukarıdaki `docker run` komutu, artık misafir makinenize doğru şekilde yönlendirilen standart `localhost:1242` rotası üzerinden ana makinenizden **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-tr-TR)** arayüzünü çalışır hale getirecektir. Ayrıca bu rotayı daha fazla açığa çıkarmadığımızı, bu sayede bağlantının yalnızca Docker ana makinesi içinde yapılabileceğini ve dolayısıyla güvenli kaldığını belirtmekte fayda var. Elbette, ne yaptığınızı biliyorsanız ve uygun güvenlik önlemlerini aldığınızdan eminseniz rotayı daha fazla açığa çıkarabilirsiniz.

---

### Tam Örnek

Yukarıdaki tüm bilgileri birleştirerek, eksiksiz bir kurulum örneği şu şekilde görünecektir:

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull always --restart unless-stopped justarchi/archisteamfarm
```

Bu, `/home/archi/ASF/config` içindeki tüm ASF yapılandırma dosyalarıyla tek bir ASF konteyneri kullanacağınızı varsayar. Yapılandırma yolunu makinenizle eşleşen yolla değiştirmelisiniz. Ayrıca ASF için `/home/archi/ASF/plugins` klasörüne koyabileceğiniz özel eklentiler sağlamak da mümkündür. Bu kurulum, eğer yapılandırma dizininize aşağıdaki gibi bir içerikle bir `IPC.config` dosyası eklemeye karar verdiyseniz, isteğe bağlı IPC kullanımı için de hazırdır:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Yukarıdaki `docker run` komutunun elde ettiği aynı etkiyi aşağıdaki `docker compose` yapılandırmasını kullanarak da elde edebilirsiniz:

```yaml
version: "3.8"
services:
  asf:
    image: justarchi/archisteamfarm
    container_name: asf
    restart: unless-stopped
    ports:
      - "127.0.0.1:1242:1242"
      - "[::1]:1242:1242"
    volumes:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

From things other than we already discussed above, we've added `--restart unless-stopped` to both examples above in order to start this container automatically after restart of your machine. Feel free to remove/change it to suit your needs.

---

## Profesyonel İpuçları

ASF Docker konteyneriniz zaten hazır olduğunda, her seferinde `docker run` kullanmak zorunda değilsiniz. ASF Docker konteynerini `docker stop asf` ve `docker start asf` komutlarıyla kolayca durdurabilir/başlatabilirsiniz. Eğer `latest` etiketini kullanmıyorsanız, güncel bir ASF sürümü kullanmanın yine de sizden `docker stop`, `docker rm` ve tekrar `docker run` komutlarını çalıştırmanızı gerektireceğini unutmayın. Bunun nedeni, o imajda yer alan ASF sürümünü kullanmak istediğiniz her seferinde konteynerinizi yeni ASF Docker imajından yeniden oluşturmanız gerekmesidir. `latest` etiketinde, ASF kendi kendini otomatik güncelleme yeteneğine sahiptir, bu nedenle güncel bir ASF kullanmak için imajı yeniden oluşturmak gerekli değildir (ancak büyük ASF sürüm güncellemeleri arasında geçiş yaparken gerekebilecek olan yeni .NET çalışma zamanı bağımlılıklarını ve temel işletim sistemini kullanmak için zaman zaman bunu yapmak yine de iyi bir fikirdir).

Yukarıda ima edildiği gibi, `latest` dışındaki etiketlerde ASF kendini otomatik olarak güncellemez; bu da güncel `justarchi/archisteamfarm` deposunu kullanmaktan **sizin** sorumlu olduğunuz anlamına gelir. Uygulamanın çalışırken kendi koduna dokunmaması gerektiği için bunun birçok avantajı vardır, ancak Docker konteynerinizdeki ASF sürümü hakkında endişelenmenize gerek kalmamasının getirdiği kolaylığı da anlıyoruz. Eğer iyi uygulamalara ve doğru Docker kullanımına önem veriyorsanız, `latest` yerine `released` etiketini öneririz. Ancak bununla uğraşmak istemiyorsanız ve sadece ASF'nin hem çalışmasını hem de kendini otomatik güncellemesini istiyorsanız, o zaman `latest` işinizi görecektir.

ASF'yi genellikle `Headless: true` genel ayarıyla bir Docker konteynerinde çalıştırmalısınız. Bu, ASF'ye eksik ayrıntıları sağlamak için burada olmadığınızı ve bunları istememesi gerektiğini açıkça bildirecektir. Elbette, ilk kurulum için işleri kolayca ayarlayabilmek adına bu seçeneği `false` olarak bırakmayı düşünebilirsiniz. Ancak uzun vadede genellikle ASF konsoluna bağlı kalmayacağınız için, bu durumu ASF'ye bildirmek ve ihtiyaç doğduğunda `input` **[komutunu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-tr-TR)** kullanmak mantıklı olacaktır. Bu şekilde ASF, gerçekleşmeyecek olan kullanıcı girdisi için sonsuza kadar beklemek (ve bu sırada kaynakları boşa harcamak) zorunda kalmaz. Bu aynı zamanda, ASF'nin konteyner içinde etkileşimli olmayan modda çalışmasına olanak tanır. Bu durum, örneğin sinyallerin yönlendirilmesi açısından kritik öneme sahiptir ve `docker stop asf` isteği üzerine ASF'nin düzgün bir şekilde kapanmasını mümkün kılar.