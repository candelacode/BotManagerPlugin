# Erweiterungen (Plugins)

ASF bietet Unterstützung für benutzerdefinierte Plugins, die während der Ausführung geladen werden können. Erweiterungen ermöglichen es Ihnen, das ASF-Verhalten anzupassen, z. B. durch Hinzufügen von benutzerdefinierten Befehlen, einer benutzerdefinierten Handelslogik oder der vollständigen Integration mit Diensten und APIs von Drittanbietern.

Diese Seite beschreibt ASF-Erweiterungen aus der Nutzerperspektive - Erklärung, Verwendung und Ähnliches. Wenn Sie an einer Entwicklerperspektive interessiert sind, folgen sie **[diesem](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)** link.

---

## Verwendung

ASF lädt Erweiterungen aus dem Verzeichnis `plugins`, das sich in Ihrem ASF-Ordner befindet. Es ist eine empfohlene (und für die automatische Erweiterungsaktualisierung auch notwendige) Praxis für jede Erweiterung, die Sie verwenden möchten, ein eigenes Verzeichnis zu erstellen, das auf dessen Namen basiert, z. B. `MeinPlugin`. Dies führt zur finalen Verzeichnisstruktur `plugins/MeinPlugin`. Schließlich sollten alle Binärdateien der Erweiterungen in diesem speziellen Ordner abgelegt werden. ASF wird Ihre Erweiterung nach dem Neustart ordnungsgemäß erkennen und verwenden.

In der Regel veröffentlichen Plugin-Entwickler ihre Erweiterungen in Form einer `zip`-Datei mit Binärdateien. Demzufolge sollten Sie diese Zip-Datei in ihr eigenes dediziertes Unterverzeichnis innerhalb des Ordners `plugins` entpacken.

Wenn die Erweiterung erfolgreich geladen wurde, dann sehen Sie dessen Namen und Version in Ihrem Protokoll. Sie sollten den Plugin-Entwickler konsultieren, wenn es um Fragen, Probleme oder die Verwendung der Erweiterungen geht, die Sie verwenden.

Sie finden einige der vorgestellten Erweiterungen in unserem Abschnitt **[Drittanbieter](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party-de-DE#asf-plugins)**.

**Bitte beachten Sie, dass ASF-Erweiterungen möglicherweise bösartig sein können**. Sie sollten immer sicherstellen, dass Sie Plugins von Entwicklern verwenden, denen Sie vertrauen können, auch solche aus dem oberen Abschnitt von Dritten. Es ist den ASF-Entwicklern nicht mehr möglich, Ihnen die üblichen ASF-Vorteile (z. B. Schutz vor Schadsoftware oder VAC-Freiheit) zu gewähren, sobald Sie sich dafür entscheiden, individuelle Erweiterungen einzusetzen. Sie müssen verstehen, dass Erweiterungen die volle Kontrolle über den ASF-Prozess haben, sobald diese geladen wurden. Wir können keine Installationen mit benutzerdefinierten Erweiterungen unterstützen, da Sie keinen »Vanilla« ASF Code mehr verwenden.

---

## Kompabilität

Basierend auf der Komplexität der Erweiterung, ihres Umfangs und einer Menge anderer Faktoren, ist es möglich, dass Sie genötigt sind, anstatt der sonst empfohlenen **[betriebssystemspezifischen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**, die **[generische](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)<0> Variante von ASF zu verwenden. Dies ist, weil die betriebssystemspezifischen Varianten nur mit der Kernfunktionalität von ASF selbst kommen und die Erweiterung möglicherweise Teile benötigt, die außerhalb des Hauptfokus fallen, wodurch es inkompatibel mit den beschnittenen betriebssystemspezifischen Applikationen wird.</p>

Generell, wenn sie Drittparteienerweiterungen verwenden, empfehlen wir die generische ASF Variante für ein Maximum an Kompatibilität. Allerdings wird dies nicht von allen Erweiterungen benötigt - Bitte lesen Sie die Informationen bezüglich Ihrer Erweiterung um herauszufinden, ob sie die generische ASF Variante benötigen oder nicht.

---


## Automatische Updates

ASF verfügt über einen integrierten Mechanismus für automatische Updates. Damit diese Funktion funktioniert, muss zuerst Ihr Plugin der Wahl **[unterstützt werden](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)**. Wenn Sie ein Plugin geladen haben, das automatische Updates unterstützt, wird ASF es während der Initialisierung des Plugins entsprechend im Log angeben, z.B. "Plugin wurde von automatischen Updates deaktiviert" oder "Plugin wurde registriert und für automatische Updates aktiviert".

Standardmäßig sind automatische Aktualisierungen für benutzerdefinierte Plugins **deaktiviert**aus Sicherheitsgründen. Sie können automatische Updates in der Konfiguration mit **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** und/oder **

[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)</strong>, wir empfehlen, die Beschreibung dieser Konfigurationseigenschaften für weitere Informationen zu lesen. Es ist auch schön zu beachten, dass Sie wie bei ASF-Updates die automatischen Updates deaktiviert halten und dann bei Bedarf aktualisieren können manuelle Basis, durch Ausgabe von `Updateplugins` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.</p> 

Beide Ansätze erlauben es dir keine, einige oder alle benutzerdefinierten Plugins, die du in den Prozess geladen hast, zu aktualisieren.