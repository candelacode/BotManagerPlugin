# Eklentiler

ASF, çalışma zamanı sırasında yüklenebilecek özel eklentiler için destek içerir. Eklentiler ASF'in davranışlarını özelleştirmeye yarar, örnek olarak özel komutlar ve özel takas mantığı eklenebilir. Hatta üçüncü parti servisleri ve API'leri ile kapsamlı şekilde entegre edilebilir.

Bu sayfa ASF eklentilerini normal kullanıcı bakış açısından hazırlanmıştır. Açıklamalar ve nasıl kullanılacağı gibi bilgiler bulunur. Eğer geliştirici bakış açısından bakmak istiyorsanız lütfen **[buraya](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)** gidin.

---

## Kullanım

ASF eklentileri ASF klasöründe bulunan `plugins` dizininden yükler. Kullanmak istediğiniz her eklenti için, `MyPlugin` gibi adına dayalı olabilen özel bir dizin bulundurmak tavsiye edilen bir uygulamadır (eklenti otomatik güncellemeleriyle zorunlu hale gelir). Bunu yapmak, bu dizin yapısıyla sonuçlanacaktır `plugins/MyPlugin`. Son olarak, eklentinin tüm ikili dosyalarını bu belirtilen klasöre koymalısınız, ve ASF yeniden başlatıldıktan sonra eklentinizi doğru bir şekilde keşfedecek ve kullanacaktır.

Genellikle eklenti geliştiricileri, eklentilerinin dosyalarını `zip` formatında yayınlar. Bu yüzden eklentinin dosyalarını `plugins` dosyasının içinde kendisine ait bir alt dizinde olacak şekilde zip'ten çıkartmalısınız.

Eğer eklenti başarılı bir şekilde yüklendi ise, çıktıda ismini ve versiyonunu göreceksiniz. Kullanmaya karar verdiğiniz eklentilerle ilgili sorularınızı, sorunlarınızı veya kullanıma yönelik şeyleri eklenti geliştiricilerinize danışmalısınız.

Öne çıkan bazı eklentileri **[üçüncü-taraf](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** bölümümüzde bulabilirsiniz.

**Lütfen ASF eklentilerinin kötü amaçlı olabileceğini unutmayın**. You should always ensure that you're using plugins made by developers that you can trust, even those from the third-party section above. Herhangi bir özel eklenti kullanmaya karar verirseniz, ASF geliştiricileri artık size normal ASF avantajlarını (kötü amaçlı yazılımın olmaması veya VAC yasaklaması ile karşılaşmama gibi şeyleri) garanti edemez. Eklentilerin yüklendikten sonra ASF süreci üzerinde tam kontrole sahip olduğunu anlamalısınız. Buna ek olarak artık ASF kodu değiştirilmiş olacağından eklentili kurulumları destekleyemiyoruz.

---

## Uyumluluk

Eklentinin karmaşıklığına, kapsamına ve diğer birçok faktöre bağlı olarak, yüksek ihtimalle sizden ASF'nin tavsiye edilen **[OS-specific](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)** varyasyonu yerine **[generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** varyasyonunu kullanmanızı isteyecektir. This is because OS-specific variant comes only with core functionality required for ASF itself, and your plugin may require parts that fall outside of main ASF scope, in result being incompatible with trimmed OS-specific builds.

In general, when using third-party plugins, we recommend using ASF generic variant for maximum compatibility. However, not all plugins may require it - please refer to your plugin's information in order to find out whether you need to use generic ASF variant or not.

---


## Automatic updates

ASF has built-in mechanism for plugins auto-updates. For that feature to work, first of all, your plugin of choice needs to **[support](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)** that mechanism. If you've loaded a plugin that supports auto-updates, ASF will state it in the log appropriately during plugin initialization, such as "plugin has been disabled from automatic updates" or "plugin has been registered and enabled for automatic updates".

By default, automatic updates for custom plugins are **disabled**, due to security reasons. You can configure automatic updates in the config by using **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** and/or **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)**, we recommend to read description of those config properties for more info. It's also nice to note that, like with ASF updates, you can decide to keep automatic updates disabled, and then update on as-needed, manual basis, by issuing `updateplugins` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

Both approaches allow you to update none, some, or all custom plugins that you've loaded into the process.