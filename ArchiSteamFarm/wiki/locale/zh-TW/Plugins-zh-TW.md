# 外掛程式

ASF支援可在執行期間載入的自訂外掛程式。 外掛程式使您能夠自訂ASF的行為，例如加入自訂指令、自訂交易邏輯，或與第三方服務或是API進行整體整合。

本頁描述了使用者視角的ASF外掛程式⸺詳細說明、使用方式等其他資訊。 若您想從開發人員的角度來看，請前往&#8203;**[這裡](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development-zh-TW)**&#8203;。

---

## 使用方法

ASF會從您的ASF資料夾中的&#8203;`plugins`&#8203;資料夾載入外掛程式。 建議（若外掛程式自動更新，則為強制）為您使用的每個外掛程式提供一個專屬資料夾，該資料夾可以依據外掛程式的名稱命名，例如&#8203;`我的外掛程式`&#8203;。 最終會產生&#8203;`plugins/我的外掛程式`&#8203;的樹狀結構。 最後，外掛程式的所有二進制檔案都應該放在那個專屬資料夾中，ASF會在重新啟動後成功偵測並使用您的外掛程式。

通常，外掛程式開發人員會將他們的外掛程式以&#8203;`zip`&#8203;檔案形式發布，並在其中含有二進制檔案。這代表您需要將zip檔案解壓縮至&#8203;`plugins`&#8203;資料夾下的獨立子資料夾中。

若外掛程式被成功載入，您將會在紀錄中看到它的名稱及版本。 若遇到與您使用的外掛程式相關的問題、或對程式內容或使用方式有疑問時，您應諮詢相應的外掛程式開發人員。

您可以在我們的&#8203;**[第三方工具](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party-zh-TW#asf-外掛程式)**&#8203;章節中找到一些精選的外掛程式。

**請注意，ASF外掛程式可能包含惡意功能**&#8203;。 您應始終確保您使用的外掛程式來自於能被您信任的開發人員，即使是上述第三方工具章節中的外掛程式。 若您決定使用任何自訂外掛程式，ASF開發人員將不再保證您正常的ASF權益（例如無惡意程式或不被VAC）。 您需要了解，只要載入了外掛程式，它就能完全控制ASF程序。因此，我們無法向您支援使用了自訂外掛程式的設定，因為您已不再執行原版的ASF程式碼。

---

## 相容性

取決於外掛程式的複雜程度、功能廣泛性及其他許多因素，有可能會要求您使用&#8203;**[Generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-zh-TW#安裝-generic-版本套件)**&#8203;的ASF變體版本，而非建議的&#8203;**[適用於特定作業系統](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#適用於您的作業系統的設定)**&#8203;的版本。 這是因為適用於特定作業系統的變體版本通常只自帶了ASF所需的核心功能，而您的外掛程式可能會需要ASF沒有的功能，因此導致其與修整過後的特定作業系統組建版本不相容。

在一般情形下，為了最大程度的相容性，在使用第三方外掛程式時，我們建議使用ASF Generic變體版本。 但並非所有的外掛程式都有此需求⸺請參閱您所使用的外掛程式的說明，來確定您是否需要使用ASF Generic版本。

---


## 自動更新

ASF擁有內建的外掛程式自動更新機制。 要讓此功能發揮作用，首先，您的外掛程式需要&#8203;**[支援](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development-zh-TW#自動更新)**&#8203;這項機制。 若您載入了支援自動更新的外掛程式，ASF將會在外掛程式初始化時在日誌紀錄中記錄，例如「外掛程式已被停用自動更新」或「外掛程式已被登錄，並已啟用自動更新」。

出於安全性考量，自訂外掛程式在預設情形下會&#8203;**停用**&#8203;自動更新。 您可以在設定中使用&#8203;**[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#pluginsupdatelist外掛程式更新清單)**&#8203;與／或&#8203;**[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#pluginsupdatemode外掛程式更新模式)**&#8203;來控制自動更新，我們建議您閱讀這些設定屬性的描述，以了解更多。 值得注意的是，與ASF更新相同，您可以停用自動更新，然後在需要時，手動使用&#8203;`updateplugins`&#8203;**[指令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-TW)**&#8203;更新。

兩種方式都能讓您不更新、更新部分、或更新所有已載入至程序中的自訂外掛程式。