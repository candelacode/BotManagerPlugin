# Kullanımdan Kaldırma

Hem geliştirmeyi hem de kullanımı çok daha tutarlı hale getirmek için tutarlı bir kullanımdan kaldırma politikası izlemek adına elimizden gelenin en iyisini yapıyoruz.

---

## Kullanımdan Kaldırma Nedir?

Kullanımdan kaldırma, daha önce kullanılan seçenekleri, argümanları, işlevleri veya kullanım senaryolarını geçersiz kılan küçük veya büyük çaplı köklü değişiklikler sürecidir. Kullanımdan kaldırma genellikle, belirli bir özelliğin başka (benzer) bir forma yeniden yazıldığı anlamına gelir ve zamanında bu yeni forma uygun geçişi yapmanız gerekir. Bu durumda olay, yalnızca belirli bir işlevselliğin daha uygun bir yere taşınmasıdır.

ASF hızla değişir ve her zaman daha iyi olmayı hedefler. Bu ne yazık ki, yeni özelliklerden, uyumluluktan veya kararlılıktan faydalanabilmesi için mevcut bazı işlevleri programın başka bir bölümüne değiştirebileceğimiz veya taşıyabileceğimiz anlamına gelir. Bu sayede, yıllar önce aldığımız modası geçmiş veya bariz şekilde yanlış olan geliştirme kararlarına bağlı kalmak zorunda değiliz. Her zaman, önceden mevcut olan işlevselliğin beklenen kullanımına uyan makul bir alternatif sunmaya çalışıyoruz. Bu nedenle, kullanımdan kaldırma işlemi çoğunlukla zararsızdır ve yalnızca önceki kullanıma yönelik küçük düzeltmeler gerektirir.

---

## Kullanımdan Kaldırma Aşamaları

ASF, geçişi çok daha kolay ve sorunsuz hale getirmek için 2 aşamalı bir kullanımdan kaldırma süreci izleyecektir.

### Aşama 1

Aşama 1, belirli bir özellik kullanımdan kaldırıldığında başlar ve hemen başka bir çözüm sunulur (veya yeniden sunma planı yoksa hiçbir şey sunulmaz).

Bu aşamada, kullanımdan kaldırılmış bir işlev kullanıldığında ASF uygun bir uyarı mesajı yazdırır. Mümkün olduğu sürece, ASF eski davranışı taklit etmeye ve onunla uyumlu kalmaya çalışacaktır. ASF, bu işlevsellik açısından en azından bir sonraki kararlı sürüme kadar Aşama 1'de kalacaktır. Bu, umarız uyumluluğu bozmadan, tüm araçlarınızda ve kullanım alışkanlıklarınızda yeni davranışa uyum sağlamak için uygun geçişi yapabileceğiniz andır. Tüm uygun değişiklikleri yapıp yapmadığınızı, artık kullanımdan kaldırma uyarısını görmeyerek teyit edebilirsiniz.

### Aşama 2

Aşama 2, yukarıda açıklanan Aşama 1'in gerçekleşip kararlı bir sürümde yayınlanmasından sonra planlanır. Bu aşama, kullanımdan kaldırılmış özelliğin varlığının tamamen ortadan kaldırılmasını içerir. Bu, ASF'nin artık kullanımdan kaldırılmış bir özelliği kullanma girişiminde bulunduğunuzu bile tanımayacağı, ona uymayı bırakın, çünkü bu özellik mevcut kodda basitçe mevcut değildir anlamına gelir. ASF, ne yapmaya çalıştığınızı artık tanımadığı için herhangi bir uyarı yazdırmayacaktır.

---

## Özet

Uygun geçişi yapmak için yaklaşık **bir tam ayınız** vardır, bu süre sıradan bir ASF kullanıcısı olsanız bile fazlasıyla yeterli olmalıdır. Bu süreden sonra ASF, eski ayarların herhangi bir etkisinin olacağını artık garanti etmez (Aşama 2). Bu durum, siz fark etmeden belirli özelliklerin tamamen çalışmayı durdurmasına neden olur. Eğer bir aydan uzun bir aradan sonra ASF'yi başlatıyorsanız, **[sıfırdan başlamanız](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-tr-TR)** veya kaçırdığınız tüm değişiklik günlüklerini okuyup kullanımınızı mevcut duruma manuel olarak uyarlamanız önerilir.

Çoğu durumda, kullanımdan kaldırma uyarısını göz ardı etmek genel ASF işlevselliğini kullanılamaz hale getirmez, ancak varsayılan davranışa geri dönülmesine neden olur (bu da kişisel tercihlerinize uymayabilir).

---

## Örnek

V3.1.2.2 öncesi `--server` **[komut satırı argümanını](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-tr-TR)**, `IPC` **[genel yapılandırma özelliğine](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-tr-TR#global-config)** taşıdık.

### Aşama 1

Aşama 1, `--server` kullanımına uygun bir uyarı eklediğimiz V3.1.2.2 sürümünde gerçekleşti. Artık kullanılmayan `--server` argümanı, geçici bir süre için eski `--server` anahtarıyla tamamen aynı şekilde çalışacak biçimde, otomatik olarak `IPC: true` genel yapılandırma özelliğine eşlendi. Bu, ASF eski argümanı kabul etmeyi bırakmadan önce herkesin uygun geçişi yapmasına olanak tanıdı.

### Aşama 2

Aşama 2, yukarıda açıklanan Aşama 1'i içeren V3.1.2.9 kararlı sürümünün hemen ardından, V3.1.3.0 sürümünde gerçekleşti. Aşama 2, ASF'nin `--server` argümanını artık hiç tanımamasına neden oldu ve bu argümanı, programa artık hiçbir etkisi olmayan diğer geçersiz argümanlar gibi ele aldı. `--server` kullanımını hâlâ `IPC: true` olarak değiştirmemiş olan kişiler için bu durum, ASF artık uygun eşlemeyi yapmadığından IPC'nin tamamen işlevsiz kalmasına neden oldu.