# Sicherheit

## Verschlüsselung

ASF unterstützt derzeit die folgenden Verschlüsselungsmethoden als Parameter für `ECryptoMethod`:

| Wert | Name                        |
| ---- | --------------------------- |
| 0    | PlainText                   |
| 1    | AES                         |
| 2    | ProtectedDataForCurrentUser |
| 3    | EnvironmentVariable         |
| 4    | File                        |

Die genaue Beschreibung und Unterschiede zwischen diesen sind nachfolgend verfügbar.

### Einrichtung

Um ein verschlüsseltes Password zu generieren, z. B. um es mit `SteamPassword` zu verwenden, müssen Sie den **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** `encrypt` mit der gewünschten Verschlüsselungsmethode und Ihrem ursprünglichen Klartext-Passwort ausführen. Danach setzen Sie die verschlüsselte Zeichenfolge als Bot-Konfigurationsvariable `SteamPassword` haben, und ändern Sie schließlich `PasswordFormat` auf diejenige, die Ihrer gewählten Verschlüsselungsmethode entspricht. Einige Formate benötigen keinen `encrypt` Befehl (z. B. `EnvironmentVariable` oder `File`). Fügen Sie einfach den entsprechenden Pfad an.

---

### `PlainText`

Dies ist die einfachste und zugleich unsicherste Sicherungsmethode fürs Passwort, festgelegt durch `PasswordFormat`, mit einem Wert von `0`. ASF erwartet, dass die Zeichenkette im Klartext vorliegt – ein Passwort in seiner direkten Form. Sie ist am einfachsten zu verwenden und zu 100 % kompatibel mit allen Setups, daher ist sie eine Standardmethode zum Speichern von Geheimnissen, für eine sichere Speicherung vollkommen ungeeignet.

---

### `AES`

Nach heutigen Standards als sicher angesehen, wird die Methode **[AES](https://de.wikipedia.org/wiki/Advanced_Encryption_Standard)** zum Speichern des Passworts in Form von `ECryptoMethod` mit einem Wert von `1` definiert. ASF erwartet, dass die Zeichenkette aus einer **[base64 kodierten](https://de.wikipedia.org/wiki/Base64)** Zeichenfolge besteht, die nach der Übersetzung zu einem AES-verschlüsselten Byte-Array führt, das dann mit dem enthaltenen **[Initialisierungsvektor](https://de.wikipedia.org/wiki/Initialisierungsvektor)** und dem ASF-Verschlüsselungsschlüssel dechiffriert werden sollte.

Die oben genannte Methode gewährleistet die Sicherheit, solange der Angreifer den ASF-Verschlüsselungsgeheinis (Schlüssel) nicht kennt, der sowohl zur Entschlüsselung als auch zur Verschlüsselung von Passwörtern verwendet wird. ASF erlaubt es Ihnen, den Schlüssel mit dem **[Befehlszeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-de-DE)** `--cryptkey` anzugeben, den Sie für maximale Sicherheit verwenden sollten. Wenn Sie sich dazu entscheiden es wegzulassen, verwendet ASF seinen eigenen Schlüssel, der **bekannt** und fest in der Anwendung programmiert ist, was bedeutet, dass jeder die ASF-Verschlüsselung umkehren und ein entschlüsseltes Passwort erhalten kann. Es erfordert immer noch etwas Aufwand und ist nicht so einfach zu bewerkstelligen, aber möglich, deshalb sollten Sie fast immer die `AES`-Verschlüsselung mit Ihrem eigenen `--cryptkey` verwenden, den Sie geheim halten sollten. Die in ASF verwendete AES-Methode bietet eine zufriedenstellende Sicherheit und es ist ein Kompromiss zwischen der Einfachheit von `PlainText` und der Komplexität von `ProtectedDataForCurrentUser`, aber es wird dringend empfohlen, sie mit einem benutzerdefinierten `--cryptkey` verwenden.

Bei ordnungsgemäßer Verwendung (langer, benutzerdefinierter `--cryptkey`) garantiert sehr hohe Sicherheit für sicheren Speicher.

---

### `ProtectedDataForCurrentUser`

Heute als sicher angesehen **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** Möglichkeit das Passwort zu speichern, wird als `ECryptoMethode` von `2` definiert. Der Hauptvorteil dieser Methode ist gleichzeitig der größte Nachteil - anstelle der Verwendung eines Verschlüsselungsschlüssels (wie in `AES`) werden die Daten mit den Anmeldeinformationen des aktuell angemeldeten Benutzers verschlüsselt, was bedeutet, dass es möglich ist die Daten **nur** auf dem Computer zu entschlüsseln, auf dem sie verschlüsselt wurden, und darüber hinaus **nur** durch den Benutzer der die Verschlüsselung ausgestellt hat.

Dies stellt sicher, auch wenn Sie Ihren gesamten `Bot senden. Sohn` mit verschlüsselter `SteamPassword` mit dieser Methode für jemand anderem, ohne direkten Zugriff auf Ihren PC werden sie das Passwort nicht entschlüsseln können. Dies ist eine ausgezeichnete Sicherheitsmaßnahme, hat aber gleichzeitig den großen Nachteil, am wenigsten kompatibel zu sein, da das mit dieser Methode verschlüsselte Passwort mit jedem anderen Benutzer und Geräte – einschließlich **Ihrem eigenen** – inkompatibel sein wird, wenn Sie sich z. B. für eine Neuinstallation des Betriebssystems entscheiden. Dies ist die empfohlene Methode, wenn Sie nicht auf Ihre Konfigurationen von einem anderen Rechner aus zugreifen müssen und dass Sie auch keine maschinenübergreifende Kompatibilität benötigen.

**Bitte beachten Sie, dass diese Option derzeit nur auf Windows Betriebssystemen zur Verfügung steht.**

---

### `EnvironmentVariable`

RAM-basierter Speicher definiert als `ECryptoMethod` von `3`. ASF liest das Passwort aus der Umgebungsvariable mit dem angegebenen Namen im Passwortfeld (z. B. `SteamPassword`). Wenn Sie beispielsweise `SteamPassword` auf `ASF_PASSWORD_MYACCOUNT` und `PasswordFormat` auf `3` einstellen, wird ASF die Umgebungsvariable `${ASF_PASSWORD_MYACCOUNT}` auswerten und alles verwenden, was ihm als Kontopasswort zugewiesen wurde.

Denken Sie daran, sicherzustellen, dass Umgebungsvariablen des ASF-Prozesses nicht für unbefugte Benutzer zugänglich sind da dies den gesamten Zweck der Verwendung dieser Methode zunichte macht.

---

### `Datei`

Datei-basierter Speicher (möglicherweise außerhalb des ASF-Konfigurationsordners) definiert als `ECryptoMethod` von `4`. ASF liest das Passwort aus dem Dateipfad – spezifiziert im Passwortfeld (z. B. `SteamPassword`). Der angegebene Pfad kann entweder absolut oder relativ zu ASFs "home" Position sein (der Ordner mit `config` Verzeichnis drinnen, unter Berücksichtigung von `--path` **[Kommandozeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). Diese Methode kann zum Beispiel mit **[Docker-Geheimnissen](https://docs.docker.com/engine/swarm/secrets)**verwendet werden die solche Dateien zur Verwendung erstellen, aber auch außerhalb von Docker verwendet werden können, wenn Sie selbst eine entsprechende Datei erstellen. Wenn Sie beispielsweise `SteamPassword` auf `/etc/secrets/MyAccount.pass` und `PasswordFormat` auf `4` einstellen, wird ASF `/etc/secrets/MyAccount.pass` auslesen und alles verwenden, was in diese Datei geschrieben wurde.

Stellen Sie sicher, dass die Datei mit dem Passwort nicht von unbefugten Benutzern gelesen werden kann, da dies den gesamten Zweck der Verwendung dieser Methode zunichtemacht.

---

## Verschlüsselungsempfehlungen

Wenn Kompatibilität kein Problem für Sie ist und Sie gut damit sind, wie `ProtectedDataForCurrentUser` Methode funktioniert Es ist die **empfohlene** Option, das Passwort in ASF zu speichern, da es die beste Sicherheit und Bequemlichkeit bietet. Die Methode `AES` ist eine gute Wahl für jene, die Ihre Konfigurationen immer noch auf jedem beliebigen Gerät verwenden möchten, während `PlainText` die einfachste Art ist, das Passwort zu speichern; sofern es Ihren nichts ausmacht, dass jeder danach in der JSON-Konfigurationsdatei suchen kann.

Please keep in mind that all encryption methods are considered **insecure** if attacker has access to your PC. ASF muss in der Lage sein, das verschlüsselte Passwort zu entschlüsseln; und wenn das auf Ihrer Maschine laufende Programm dazu in der Lage ist, dann kann auch jede andere auf demselben Gerät ausgeführte Anwendung dies bewältigen. `ProtectedDataForCurrentUser` ist die sicherste Variante, da **auch andere Benutzer, die den gleichen PC verwenden, ihn nicht entschlüsseln können**, aber es ist trotzdem möglich, die Daten zu entschlüsseln, wenn jemand in der Lage ist, Ihre Anmeldedaten und Geräteinformationen zusätzlich zur ASF-Konfigurationsdatei zu stehlen.

Für erweiterte Einrichtungen können Sie `EnvironmentVariable` und `File` verwenden. Sie haben eine begrenzte Benutzerfreundlichkeit die `EnvironmentVariable` wird eine gute Idee sein, wenn Sie lieber ein Passwort durch eine benutzerdefinierte Lösung erhalten und es exklusiv im Speicher speichern möchten während `Datei` gut ist zum Beispiel mit **[Docker Geheimnisse](https://docs.docker.com/engine/swarm/secrets)**. Allerdings sind beide unverschlüsselt, sodass Sie das Risiko aus der ASF-Konfigurationsdatei grundsätzlich auf alles umstellen, was Sie aus diesen beiden auswählen.

Zusätzlich zu den oben angegebenen Verschlüsselungsmethoden ist es auch möglich, Passwörter vollständig wegzulassen, zum Beispiel als `SteamPassword` durch Verwendung eines leeren Strings oder `null` Wert. ASF fragt Sie nach Ihrem Passwort, wenn es benötigt wird, und speichert es nirgendwo, außer im Speicher des aktuell laufenden Prozesses, bis Sie diesen schließen. Es ist zwar die sicherste Methode im Umgang mit Passwörtern (diese werden nirgendwo gespeichert), aber auch die lästigste, da Sie Ihr Passwort bei jeder ASF-Ausführung manuell eingeben müssen (sobald es erforderlich ist). Wenn das kein Problem für Sie ist, dann ist das Ihre beste Wette, die Sie sicher einsetzen können, da Sie etwas nicht lecken können, was nicht existiert.

---

## Entschlüsselung

ASF unterstützt keine Möglichkeit, bereits verschlüsselte Passwörter zu entschlüsseln, da Entschlüsselungsmethoden nur intern für den Zugriff auf die Daten innerhalb des Prozesses verwendet werden. Falls Sie die Verschlüsselung rückgängig machen möchten (z. B. zum Verschieben von ASF auf andere Geräte), wenn `ProtectedDataForCurrentUser` verwendet wird, dann wiederholen Sie einfach die Prozedur in der neuen Umgebung von Anfang an.

---

## Hashing

ASF unterstützt derzeit die folgenden Hashmethoden als Parameter für `EHashingMethod`:

| Wert | Name      |
| ---- | --------- |
| 0    | PlainText |
| 1    | SCrypt    |
| 2    | Pbkdf2    |

Die genaue Beschreibung und Unterschiede zwischen diesen sind nachfolgend aufgelistet.

### Einrichtung

Um einen Hash zu generieren, z. für `IPCPassword` Nutzung Sie sollten `Hash` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** mit der passenden Hashing-Methode und Ihrem ursprünglichen Klartext-Passwort ausführen. Danach setzen Sie die gehashte Zeichenfolge, die Ihnen als `IPCPassword` ASF-Konfigurationsvariable vorliegt, und schließlich ändern Sie `PasswordFormat` auf dasjenige, das Ihrer gewählten Hash-Methode entspricht.

---

### `PlainText`

Dies ist die einfachste und zugleich unsicherste Methode das Passwort zu speichern, festgelegt durch `EHashingMethod`, mit dem Wert `0`. ASF wird eine Hash generieren, die mit der ursprünglichen Eingabe übereinstimmt. Sie ist am einfachsten zu verwenden und zu 100 % kompatibel mit allen Setups, daher ist sie eine Standardmethode zum Speichern von Geheimnissen, vollkommen unzuverlässig für eine sichere Speicherung.

---

### `SCrypt`

Heute als sicher angesehen **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** Möglichkeit das Passwort zu hashen ist definiert als `EHashingMethod` von `1`. ASF verwendet die Implementierung `SCrypt` mit `8` Blöcken, `8192` Iterationen, `32` Hashlänge und Verschlüsselungsschlüssel als **[Salt](https://www.security-insider.de/was-ist-ein-salt-a-1052450/), um das Array von Bytes zu erzeugen. Die resultierenden Bytes werden dann als **[base64](https://de.wikipedia.org/wiki/Base64)** Zeichenkette kodiert.</p>

ASF erlaubt es Ihnen, den Schlüssel (**[Salt](https://www.security-insider.de/was-ist-ein-salt-a-1052450/)) mit dem **[Befehlszeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-de-DE)** `--cryptkey` anzugeben, den Sie für maximale Sicherheit verwenden sollten. Falls Sie sich dazu entscheiden es wegzulassen, verwendet ASF seinen eigenen Schlüssel, der **bekannt** und fest in der Anwendung programmiert ist, was bedeutet, dass die Hash-Generierung unsicherer ist.</p>

Bei ordnungsgemäßer Verwendung (benutzerdefiniertes Salz, langes Passwort) garantiert sehr hohe Sicherheit für die sichere Aufbewahrung.

---

### `Pbkdf2`

Wird heute als schwach betrachtet **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** Möglichkeit des Hashens des Passworts wird als `EHashingMethode` von `2` definiert. ASF wird die `Pbkdf2` Implementierung mit `10000` Iterationen verwenden `32` Hashlänge und Verschlüsselungsschlüssel als Salt, mit `SHA-256` als hmac Algorithmus. Die resultierenden Bytes werden dann als **[base64](https://en.wikipedia.org/wiki/Base64)** Zeichenkette kodiert.

ASF erlaubt Ihnen Salz für diese Methode über `--cryptkey` **[Kommandozeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**anzugeben, die Sie für maximale Sicherheit verwenden sollten. Falls Sie sich dazu entscheiden es wegzulassen, verwendet ASF seinen eigenen Schlüssel, der **bekannt** und fest in der Anwendung programmiert ist, was bedeutet, dass die Hash-Generierung unsicherer ist.

---

## „Hashing“-Empfehlungen

Wenn Sie eine Hashing-Methode verwenden möchten, um einige Geheimnisse zu speichern, wie `IPCPassword`, empfehlen wir, `SCrypt` mit benutzerdefinierten **[Salt](https://www.security-insider.de/was-ist-ein-salt-a-1052450/) zu verwenden, da es eine ausgezeichnete Sicherheit gegen brute force Attacken bietet.</p>

`Pbkdf2` wird nur aus Kompatibilitätsgründen angeboten, vor allem weil wir bereits eine funktionierende (und erforderliche) Implementierung für andere Anwendungsfälle auf der Steam Plattform haben (z. B. Familienansicht (PIN)). Es wird zwar immer noch als sicher angesehen, aber im Vergleich zu anderen Möglichkeiten (z. B. `SCrypt`) ist diese schwach.