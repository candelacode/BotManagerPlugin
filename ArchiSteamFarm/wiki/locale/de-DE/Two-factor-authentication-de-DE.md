# Zwei-Faktor-Authentifizierung (2FA)

Steam beinhaltet ein Zwei-Faktor-Authentifizierungssystem, das zusätzliche Details für verschiedene kontenbezogene Aktivitäten erfordert. Sie können **[hier](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** und **[hier](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)** mehr darüber lesen. Diese Seite befasst sich mit dem 2FA-System sowie unserer Lösung, die mit ihm integriert wird (ASF-2FA).

---

# ASF-Logik

Unabhängig davon, ob Sie ASF 2FA verwenden oder nicht, ASF enthält die richtige Logik und ist sich der Konten, die durch 2FA auf Steam geschützt sind, voll bewusst. Es fragt Sie nach den erforderlichen Details, sobald diese benötigt werden (z. B. beim Anmelden). Während Sie diese Informationen manuell angeben können bestimmte ASF-Funktionalitäten (wie `MatchActively`) erfordern, dass ASF 2FA auf Ihrem Bot-Konto operativ ist die automatisch auf 2FA-Eingabeaufforderungen reagieren kann, wann immer dies von ASF gewünscht wird.

---

# ASF-2FA

ASF-2FA ist ein eingebautes Modul, das für die Bereitstellung von 2FA-Funktionen für den ASF-Prozess verantwortlich ist, wie dem Erzeugen von Codes und das Annehmen von Bestätigungen. Es kann entweder im Standalone-Modus funktionieren oder indem Sie Ihre bestehenden Authentifizierungsdaten duplizieren (so dass Sie Ihren aktuellen Authentifikator und ASF 2FA gleichzeitig verwenden können).

Sie können überprüfen, ob Ihr Bot-Konto bereits ASF-2FA verwendet, indem Sie den **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** `2fa` ausführen. Ohne ASF 2FA sind alle `2fa` Befehle nicht funktionsfähig, was bedeutet, dass Ihr Bot nicht für fortgeschrittene ASF-Funktionen verfügbar ist, die das Modul für den Betrieb benötigen.

---

# Empfehlungen

Wir bieten Ihnen eine Vielzahl an Möglichkeiten, ASF 2FA operativ zu behandeln. Unsere Empfehlungen basieren auf Ihrer aktuellen Situation:

- Wenn Sie bereits eine inoffizielle Drittanbieter-App verwenden, die es Ihnen erlaubt, 2FA-Details mit Leichtigkeit zu extrahieren, einfach **[](#import)** diese nach ASF zu importieren.
- Wenn Sie die offizielle App verwenden und Sie nichts dagegen haben, Ihre 2FA-Anmeldeinformationen zurückzusetzen; dann ist der beste Weg, 2FA zu deaktivieren, dann **[](#erstellung)** neue 2FA-Anmeldedaten unter Verwendung des **[gemeinsamen Authentifikators](#gemeinsamer-authentifikator)**, mit der Sie die offizielle App und ASF-2FA verwenden können. Diese Methode **benötigt keine Root-**, Gefängnisse oder fortgeschrittene Kenntnisse, die hier geschriebenen Anweisungen kaum befolgen und ist für dieses Szenario wohl überlegen.
- Wenn Sie die offizielle App verwenden und Ihre 2FA-Anmeldeinformationen nicht neu erstellen möchten, sind Ihre Optionen sehr begrenzt; typischerweise benötigen Sie *root* und zusätzliches Experimentieren, um diese Details **[zu importieren](#importieren)**, und sogar mit diesem könnte es unmöglich sein.
- Wenn Sie noch keine 2FA verwenden und keine Bedeutung haben wir empfehlen Ihnen, ASF 2FA mit **[Standalone-Authentifikator](#standalone-authenticator)** oder **[joint authenticator](#joint-authenticator)** mit der offiziellen App zu verwenden (dasselbe wie oben).

Im Folgenden diskutieren wir alle möglichen Optionen und bekannte Methoden.

---

## Erstellung

ASF kommt mit einem offiziellen `MobileAuthenticator` ****[Plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** das ASF 2FA weiter erweitert so können Sie einen komplett neuen 2FA-Authentifikator verknüpfen. Dies kann hilfreich sein, wenn Sie nicht bereit oder in der Lage sind, andere Tools zu verwenden und es keine Einwände gibt, dass ASF-2FA Ihr (möglicherweise einziger) Hauptauthentifikator sein wird. Erstellungsprozess wird auch in der Join-Authentifikator-Methode verwendet, natürlich kann Ihr Authentifikator in diesem Szenario an zwei Orten gleichzeitig nebeneinander existieren - beide generieren die gleichen Codes und beide können die gleichen Bestätigungen bestätigen.</p>

### Gemeinsame Schritte für beide Szenarien

Egal ob Sie ASF als eigenständiger oder gemeinsamer Authentifikator verwenden wollen, Sie müssen diese Initialisierungsschritte machen:

1. Erstellen Sie einen ASF-Bot für das Zielkonto, starten Sie ihn und melden Sie sich an (was Sie wahrscheinlich bereits getan haben).
2. Weisen Sie dem Konto **[hier](https://store.steampowered.com/phone/manage)** eine funktionierende und operative Telefonnummer zu, die vom Bot verwendet werden soll. Auf diese Weise können Sie SMS-Code erhalten und bei Bedarf eine Wiederherstellung ermöglichen. Dieser Schritt ist nicht in allen Szenarien zwingend vorgeschrieben, aber wir empfehlen ihn nur, wenn Sie wissen, was Sie tun.
3. Stellen Sie sicher, dass Sie 2FA bisher nicht für Ihr Konto verwenden; deaktivieren Sie es zuerst, falls doch. Diese **wird** Ihr Konto auf einen vorübergehenden Handelsstand stellen, es gibt keinen Weg um es zu umgehen nur **[Import](#import)** Prozess kann ihn überspringen.
4. Führen Sie den Befehl `2fainit [Bot]` aus, indem Sie `[Bot]` durch den Namen Ihres Bots ersetzen.

Angenommenen, Sie haben eine erfolgreiche Antwort erhalten; dann sind die folgenden zwei Dinge passiert:

- Eine neue Datei `<Bot>.maFile.PENDING` wurde von ASF in Ihrem `Konfigurations`-Verzeichnis generiert.
- SMS wurde von Steam an die Telefonnummer gesendet, die Sie für das oben genannte Konto zugewiesen haben. Wenn Sie keine Telefonnummer angegeben haben, wurde stattdessen eine E-Mail an die E-Mail-Adresse des Kontos gesendet.

Die Authentifizierungsdetails sind noch nicht funktionsfähig, aber Sie können die generierte Datei überprüfen, wenn Sie es wünschen. Für den Fall, dass Sie doppelte Sicherheit wünschen, können Sie den Widerrufscode bereits notieren. Die nächsten Schritte hängen von Ihrem gewählten Szenario ab.

### Eigenständiger Authentifikator

Wenn Sie ASF als Hauptauthentifikator (oder sogar nur) verwenden möchten, müssen Sie jetzt den letzten Finalisierungsschritt machen:

5. Führt den Befehl `2fafinalize [Bot] <ActivationCode>` aus; ersetzt `[Bot]` mit dem Namen Ihres Bots und `<ActivationCode>` mit dem Code, den Sie im vorherigen Schritt per SMS oder E-Mail erhalten haben.

### Gemeinsamer Authentifikator

Wenn du den gleichen Authentifikator sowohl in ASF als auch in der offiziellen Steam Mobile App haben möchtest, jetzt musst du die nächsten, schwierigeren Schritte machen:

5. **Ignoriere** die SMS oder den E-Mail-Code, den du im vorherigen Schritt erhalten hast.
6. Installieren Sie die mobilen Steam App, falls sie bisher nicht installiert ist, und öffnen Sie diese. Navigieren Sie zur Registerkarte „Steam Guard“ und fügen Sie einen neuen Authentifikator hinzu, indem Sie den Anweisungen der App folgen.
7. Nachdem Ihr Authentifikator in der mobilen App hinzugefügt wurde und funktioniert, kehren Sie zu ASF zurück. Jetzt müssen wir statt der Fertigstellung nur ASF informieren, dass die mobile App bereits unsere zuvor generierten Details aktiviert hat:
 - Warten Sie, bis der nächste 2FA-Code in der Steam Mobile App angezeigt wird, und verwenden Sie den Befehl `2fafinalized [Bot] <2FACodeFromApp>` ersetze `[Bot]` mit dem Namen deines Bots und `<2FACodeFromApp>` mit dem Code, den du derzeit in der Steam Mobile App siehst - der gleiche Code, den du für die Anmeldung bei Steam verwenden würdest (**NICHT** </strong> ** NICHT ** der, den du bereits für die Aktivierung verwendet hast). Wenn der von ASF generierte Code und der von Ihnen angegebene Code gleich sind, ASF wird davon ausgehen, dass ein Authentifikator korrekt hinzugefügt wurde, und mit dem Import Ihres neu erstellten Authentifikators fortfahren.
 - Wir empfehlen dringend, die vorherige Schritte zu befolgen, um sicherzustellen, dass Ihre Anmeldedaten gültig sind. Wenn Sie jedoch nicht überprüfen möchten (oder können), ob Codes identisch sind und Sie wissen, was Sie tun; dann können Sie stattdessen den Befehl `2fafinalizedforce [Bot]` verwenden (`[Bot]` mit dem Namen Ihres Bots ersetzen). ASF geht davon aus, dass der Authentifikator korrekt eingefügt und Sie nun mit dem Import Ihres neuen Authentifikators beginnen werden. Beachten Sie, dass ASF in diesem Modus nicht überprüfen kann, ob die Codes übereinstimmen, was bedeutet, dass Sie möglicherweise ungültige (nicht aktivierte) Zugangsdaten importieren können.

### Nach Abschluss

Angenommen, alles funktionierte richtig, wurde die zuvor generierte Datei `<Bot>.maFile.PENDING` in `<Bot>.maFile.NEW` umbenannt. Dies belegt, dass Ihre 2FA-Anmeldedaten nun gültig und aktiv sind. Wir empfehlen diese Datei außerhalb des `config`-Ordners an einem **sicheren Speicherort** zu verschieben. Zusätzlich dazu, wenn Sie sich entschieden haben, eigenständige Authentifizierung zu verwenden, dann empfehlen wir Ihnen, die Datei in Ihrem bevorzugten Editor zu öffnen und den `revocation_code`aufzuschreiben, womit Sie den Authentifikator zu widerrufenl können (wie der Name andeutet), falls Sie ihn verlieren. In der Join-Authentifikator-Methode solltest du das bereits in der Steam Mobile App tun, aber du kannst das auch tun, falls du es benötigst.

Bezüglich des technischen Aspekt enthält die generierte `maFile`-Datei alle Details, die wir vom Steam Server während der Verlinkung des Authentifizierers erhalten haben, und darüber hinaus das Feld `device_id` das für andere Authentifikatoren (Drittanbieter) benötigt werden kann, falls Sie sich für den Import der `maFile` entscheiden.

ASF importiert automatisch Ihren Authentifikator. Sobald die Prozedur abgeschlossen ist, sollten `2fa` und andere verwandte Befehle nun für das Bot-Konto funktionieren, mit dem Sie den Authentifikator verbunden haben. Wir empfehlen Ihnen, dies zu überprüfen.

---

## Importieren

Der Import erfordert bereits einen verknüpften und funktionsfähigen Authentifikator, der von ASF unterstüzt wird. Wir haben Anweisungen für ein paar verschiedene offizielle und inoffizielle Quellen von 2FA, auf der manuellen Methode, die es Ihnen erlaubt, die benötigten Anmeldedaten selbst anzugeben. Bitte beachten Sie, dass diese Anweisungen nur **** verwendet werden sollten, wenn Sie bereits eine bestimmte Lösung verwenden - da der Prozess hier Anwendungen und Werkzeuge von Drittanbietern beinhaltet **wir empfehlen sie nicht**zu verwenden , und wir erwähnen es ausschließlich für Leute, die sich bereits entschieden haben, sie zu verwenden und generierte Details in ASF 2FA importieren möchten.

Im Allgemeinen beinhaltet der Importprozess das Ablegen von `maFile` in geeignetes Format in ASF's `config` Verzeichnis, bei der ASF die Datei abholt und sie aus Sicherheitsgründen automatisch löscht.

Alle folgenden Anleitungen erfordern von Ihnen, dass Sie bereits einen **funktionierenden und betriebsbereiten** Authentifikator haben, der mit dem gegebenen Programm/Werkzeug verwendet wird. ASF-2FA funktioniert nicht ordnungsgemäß, wenn Sie ungültige Daten importieren. Stelle daher sicher, dass Ihr Authentifikator ordnungsgemäß funktioniert, bevor Sie versuchen ihn zu importieren. Dies beinhaltet das Testen und Überprüfen, ob die folgenden Authentifikator-Funktionen ordnungsgemäß funktionieren:
- Sie können Codes generieren und diese Codes werden vom Steam-Netzwerk akzeptiert (Sie können sich damit anmelden)
- Sie können Bestätigungen abrufen und diese kommen auf Ihrem mobilen Authentifikator an
- Du kannst auf diese Bestätigungen reagieren und sie werden vom Steam Netzwerk als bestätigt/abgelehnt erkannt

Stellen Sie sicher, dass Ihr Authentifikator funktioniert, indem Sie überprüfen, ob obige Aktionen funktionieren - wenn sie es nicht tun, dann werden sie auch nicht in ASF funktionieren.

### Android-Handy

Im Allgemeinen benötigen Sie für den Import des Authentifikators von Ihrem Android-Handy **[root](https://de.wikipedia.org/wiki/Rooting_(Android_OS))**-Zugriff. Die folgenden Anweisungen erfordern von Ihnen gewisse Kenntnisse aus der „Android Modding-Welt“; wir werden definitiv nicht jeden Schritt hier erklären. Besuchen Sie **[XDA](https://xdaforums.com)** und andere Ressourcen für zusätzliche Informationen/Hilfe zum unten stehenden.

**Ab heute gibt es keine bekannte, bestätigte Extraktionsmethode, die weiterhin funktioniert. Sie können versuchen, den folgenden Schritten zu folgen, z.B. mit veralteter App-Version, aber wir garantieren nicht, dass sie ordnungsgemäß funktioniert. Erwägen Sie stattdessen die Methode des Joint-Authenticators.**

<details>
  <summary>Archivanweisungen</summary>

Angenommen, Sie haben offizielle **[Steam App](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** funktioniert und betriebsbereit (unten muss Ihr Gerät gerootet werden):

- Installieren Sie **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** und aktivieren Sie Zygisk in den Einstellungen.
- Installieren Sie **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (für Zygisk) und stellen Sie sicher, dass es funktioniert.
- Installieren Sie **[SteamGuardDump](https://github.com/YifePlayte/SteamGuardDump/releases/latest)** oder **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** LSPosed Modul und aktivieren Sie es in den LSPosed-Einstellungen.
- Erzwinge die Steam-App zu beenden und dann zu öffnen, sollten die Details des Dampfwachs nun für das Kopieren in die Zwischenablage verfügbar sein.

Nachdem Sie die erforderlichen Details erfolgreich extrahiert haben, deaktivieren Sie das Modul, um die automatische Kopie jedes Mal zu verhindern kopiere dann den Wert von `shared_secret` und `identity_secret` des Kontos das du zu ASF 2FA hinzufügen möchtest in eine neue Textdatei mit untenstehender Struktur:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Ersetzen Sie jeden `STRING` Wert durch einen passenden privaten Schlüssel aus den extrahierten Details. Benennen Sie die Datei in `BotName.maFile` um, wobei `BotName` der Name Ihres Bots ist, zu dem Sie ASF-2FA hinzufügen und legen Sie es in ASF’s Verzeichnis `config` ab, wenn Sie es bislang nicht getan haben.

Starten Sie ASF, der Ihre Datei auffordern und importieren soll. Unter der Annahme, dass Sie die richtige Datei mit gültigen Geheimnissen importiert haben, sollte alles ordnungsgemäß funktionieren, die Sie über `2fa` Befehle überprüfen können. Falls Sie einen Fehler gemacht haben, können Sie `Bot.db` jederzeit entfernen und bei Bedarf neu beginnen.

</details>

### SteamDesktopAuthenticator (SDA)

Wenn Sie Ihren Authentifikator bereits in SDA nutzen, dann sollten Sie die Datei `steamID.maFile` im Ordner `maFiles` beachten. Vergewissern Sie sich, dass `maFile` in unverschlüsselter Form vorliegt, da ASF diese SDA-Dateien nicht entschlüsseln kann – unverschlüsselte Dateiinhalte sollten mit dem Zeichen `{` beginnen und endet mit `}`. Falls notwendig, können Sie die Verschlüsselung zuerst aus den SDA-Einstellungen entfernen und im Anschluss erneut aktivieren, sobald Sie fertig sind. Sobald die Datei in unverschlüsselter Form vorliegt, kopieren Sie sie in das ASF-Verzeichnis `config`.

Sie sollten nun `steamID.maFile` in `BotName.maFile` im ASF-Konfigurationsverzeichnis umbenennen, wobei `BotName` der Name Ihres Bots darstellt, den Sie ASF-2FA hinzufügen. Alternativ können Sie es so lassen wie es ist; ASF wird es dann nach dem Einloggen automatisch auswählen. Die Umbenennung der Datei erlaubt ASF die Verwendung der ASF-2FA vor dem Einloggen. Falls Sie dies unterlassen, dann kann die Datei erst ausgewählt werden, sobald ASF sich erfolgreich einloggt hat (da ASF `steamID` Ihres Kontos nicht kennt, bevor Sie sich tatsächlich anmelden).

Starten Sie ASF, der Ihre Datei auffordern und importieren soll. Unter der Annahme, dass Sie die richtige Datei mit gültigen Geheimnissen importiert haben, sollte alles ordnungsgemäß funktionieren, die Sie über `2fa` Befehle überprüfen können. Falls Sie einen Fehler gemacht haben, können Sie `Bot.db` jederzeit entfernen und bei Bedarf neu beginnen.

### WinAuth

Erstellen Sie zunächst eine neue, leere `BotName.maFile`-Datei im ASF-Konfigurationsverzeichnis, wobei `BotName` der Name Ihres Bot darstellt, dem Sie ASF-2FA hinzufügen. Falls Sie einen falschen Namen angeben, wird dieser nicht von ASF ausgewählt.

Nun starten Sie WinAuth wie gewohnt. Nach einem Rechtsklick auf das Steam-Symbol wählen Sie *»Show SteamGuard and Recovery Code«*. Dann setzen Sie einen Haken bei *»Allow copy«*. Ihnen sollte die JSON-Struktur am unteren Rand des Fensters vertraut vorkommen – beginnend mit `{`. Kopieren Sie den gesamten Text in die Datei `BotName.maFile`, die Sie im vorherigen Schritt erstellt haben.

Starten Sie ASF, der Ihre Datei auffordern und importieren soll. Unter der Annahme, dass Sie die richtige Datei mit gültigen Geheimnissen importiert haben, sollte alles ordnungsgemäß funktionieren, die Sie über `2fa` Befehle überprüfen können. Falls Sie einen Fehler gemacht haben, können Sie `Bot.db` jederzeit entfernen und bei Bedarf neu beginnen.

### Manuell

Wenn Sie ein fortgeschrittener Benutzer sind, können Sie die maFile-Datei auch manuell generieren. Dies kann in solchen Fällen verwendet werden, wenn Sie den Authentifikator aus anderen, als den oben erläuterten Quellen, importieren möchten. Es sollte eine **[gültige JSON-Struktur](https://jsonlint.com)** aufweisen:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Standard-Authentifikatordaten beinhalten mehr Felder – sie werden von ASF beim Import völlig ignoriert, da sie nicht benötigt werden. Sie müssen sie nicht entfernen - ASF benötigt nur gültige JSON mit 2 oben beschriebenen Pflichtfeldern und ignoriert weitere Felder (falls vorhanden). Natürlich müssen Sie im obigen Beispiel `STRING` Platzhalter durch gültige Werte für Ihr Konto ersetzen. Jede `STRING` sollte eine base64 kodierte Darstellung von Bytes sein, aus denen der entsprechende private Schlüssel besteht.

---

## FAQ (häufig gestellte Fragen)

### Wie nutzt ASF das 2FA-Modul?

Wenn ASF-2FA verfügbar ist, wird ASF es für die automatische Bestätigung von Handelsangeboten verwenden, die von ASF gesendet oder akzeptiert werden. Es wird auch in der Lage sein, automatisch 2FA-Codes zu generieren, z. B. um sich anzumelden. Überdies ermöglicht ASF-2FA auch die Verwendung von `2fa`-Befehlen.

### Wie kann ich 2FA-Token erhalten?

Sie benötigen einen 2FA-Code, um auf das 2FA-geschützte Konto zuzugreifen, das auch jedes Konto mit ASF-2FA einbezieht. Wenn Sie sich entschieden haben, einen eigenständigen Authentifikator zu verwenden, sollten Sie den Befehl `2fa <BotNames>` verwenden, um temporäre Token für bestimmte Bot-Instanzen zu generieren. In allen anderen Szenarien empfehlen wir Ihnen, den ursprünglichen Authentifikator zu verwenden, den Sie verwendet haben obwohl Sie auch den Befehl verwenden können, wenn es für Sie bequemer ist.

### Kann ich nach dem Import zu ASF-2FA meinen Original-Authentifikator verwenden?

Ja, Ihr Original-Authentifikator bleibt funktionsfähig und Sie können ihn zusammen mit ASF-2FA verwenden. Beachten Sie jedoch, dass, wenn Sie es durch eine Methode ungültig machen, verknüpfte ASF 2FA Anmeldedaten ebenfalls nicht mehr gültig sind.

### Wie entferne ich ASF-2FA?

Stoppen Sie einfach ASF und entfernen Sie die zugehörige Datei `BotName.db` des Bots mit der verlinkten ASF-2FA, die Sie entfernen möchten. Diese Option wird die zugeordnete 2FA mit ASF entfernen, wird aber Ihren Authentifikator NICHT außer Kraft setzen (unlink). Wenn Sie stattdessen Ihren Authentifikator außer der Entfernung von ASF (zuerst) löschen möchten, sollten Sie ihn im ursprünglichen Authentifikator Ihrer Wahl aufheben. Wenn Sie dies aus irgendeinem Grund nicht tun können, zum Beispiel weil Sie ASF 2FA im Standalone-Modus verwenden, dann verwenden Sie den Widerrufscode, den Sie während der Einrichtung auf der Steam Website erhalten haben. Es ist nicht möglich, den Authentifikator über ASF zu ungültigen.

### Ich habe den Authentifikator in der Drittanbieter-App verlinkt und dann in ASF importiert. Kann ich es nun erneut auf meinem Telefon verlinken?

**Nein**. Dadurch werden die zuvor importierten Anmeldeinformationen ungültig gemacht und deine ASF 2FA wird nicht mehr funktionieren (indem du Codes generierst, die von Steam nicht mehr akzeptiert werden). Entscheiden Sie zuerst, wo Sie Ihren Original-Authentifikator oder den Authentifikator finden möchten, und importieren Sie ihn dann als ASF 2FA.

### Ich benutze Gemeinschaftsauthentifikator, kann ich meine App auf ein anderes Telefon verschieben?

**Nein**. Was Dampf als "bewegen" oder "Transfer"-Authentifikator bezeichnet, ist tatsächlich gleichbedeutend mit der Aufhebung des alten und der Zuweisung eines neuen in einem Schritt. Dadurch können Sie z.B. überspringen. einige übermäßige Abklingzeit im Vergleich zu den beiden unabhängigen Schritten, was ASF betrifft. Dadurch werden die Anmeldeinformationen ungültig, die Sie zuvor in ASF generiert haben, wodurch das gesamte ASF 2FA Modul nicht operativ ist.

Der empfohlene Weg besteht darin, Ihren Authentifikator vollständig auf dem alten Telefon zu entfernen und die gemeinsame Authentifizierungsmethode erneut auf dem neuen Telefon zu verwenden. Wenn Sie Ihren Authentifikator bereits verschoben haben, sind die alten ASF 2FA Anmeldedaten bereits ungültig, das Einzige, was jetzt noch übrig ist, Ihren "verschobenen" Authentifikator zu entfernen und einen neuen mittels der Methode des gemeinsamen Authentifikators erneut zu verknüpfen.

### Ist die Verwendung von ASF 2FA besser als der Authentifikator von Drittanbietern gesetzt, um alle Bestätigungen zu akzeptieren?

**Ja**, auf unterschiedlicher Weise. Die erste und wichtigste – die Verwendung von ASF-2FA erhöht **erheblich** Ihre Sicherheit, da das ASF-2FA-Modul sicherstellt, dass ASF nur automatisch seine eigenen Bestätigungen akzeptiert; sodass, wenngleich der Angreifer ein schädliches Handelsangebot sendet, ASF-2FA dieses Handelsangebot **nicht** akzeptiert, da er nicht von ASF generiert wurde. Zusätzlich zum Sicherheitsteil bringt der Einsatz von ASF 2FA auch Performance/Optimierungsvorteile, da ASF 2FA sofort nach der Erstellung Bestätigungen abruft und annimmt. und nur dann, im Gegensatz zu ineffizienten Umfragen zur Bestätigung jeder X-Minuten, die durch andere Lösungen erreicht wird. Es gibt keinen Grund, den Authentifikator von Drittanbietern über ASF 2FA zu verwenden wenn Sie die Automatisierung von von ASF generierten Bestätigungen planen - das ist genau das, wofür ASF 2FA ist und die Verwendung steht nicht im Widerspruch zu der Bestätigung, dass Sie alles andere im Authentifikator Ihrer Wahl bestätigen. Wir empfehlen dringend, ASF 2FA für die gesamte ASF-Aktivität zu verwenden.