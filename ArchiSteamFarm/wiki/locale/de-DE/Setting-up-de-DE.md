# Installation

Falls Sie hier zum ersten Mal angekommen sind – herzlich willkommen! Wir freuen uns sehr über einen weiteren Reisenden zu sehen, der an unserem Projekt interessiert ist obwohl man bedenkt, dass mit großer Macht eine große Verantwortung zukommt - ASF ist in der Lage, viele verschiedene Dampf-bezogene Aufgaben zu erledigen, aber nur so lange Sie **achten genug darauf, wie Sie es verwenden**. In der Tat lesen Wiki, Unsere Richtlinien zu befolgen und mehr über verschiedene ASF-Konzepte zu erfahren, wird dich schließlich mit einer einzigartigen Fähigkeit belohnen, eines der mächtigsten Steam Tools zu verwenden, die ab heute verfügbar sind.

Wir empfehlen **eine Sache gleichzeitig** zu tun. ASF berührt viele verschiedene Aspekte, von denen einige eher trivial sind, andere können übermäßig komplex sein. Sie brauchen nicht alles auf einmal zu verstehen oder zu lesen, und wir empfehlen Ihnen, es einfach zu machen. Entspannen Sie sich, wählen Sie ein Getränk der Wahl, widmen Sie eine Stunde Ihrer Zeit und tauchen Sie ein in unsere Vorlesung - wir können Ihnen versprechen, dass es Ihre Zeit wert sein wird.

Beginnen wir mit den Grundlagen - ASF ist eine Konsolen-App in ihrem Prinzip was bedeutet, dass es nicht automatisch eine grafische Oberfläche spawnen wird, an die Sie im Allgemeinen gewöhnt sind. ASF ist eine universelle App, die hauptsächlich als Dienst (Daemon) und nicht als Desktop-App fungiert. Einer seiner Hauptanwendungsfälle berücksichtigt das Laufen auf den Servermaschinen, für die Desktop-Apps völlig ungeeignet sind. Das berücksichtigt jedoch nur den absoluten Kern des Programms weil ASF tatsächlich **** seine eigene grafische Oberfläche enthält - in Form seiner integrierten ASF-ui Frontend, aber wir werden uns rechtzeitig mit diesem Teil befassen - wir erwähnen dies nur sofort, so dass Sie nicht in Panik geraten, wenn Sie schwarze Konsolen sehen oder etwas.

Sobald Sie ASF-Binärdateien erhalten, benötigt das Programm die Konfiguration von Ihnen, was genau Sie von ASF erwarten. Sie können das Programm ohne Konfiguration starten, in diesem Fall wird ASF in den Standardeinstellungen starten, so dass Sie e verwenden können. . ASF-ui für die Anfangskonfiguration, aber es wird nicht viel ohne Ihre vorherige Aktion tun.

Das wird im Moment der Fall sein, lassen Sie uns beginnen!

---

## Betriebssystemspezifisches Einrichtung

Folgendes werden wir in den nächsten paar Minuten durchführen:
- Wir installieren **[.NET Voraussetzungen](#net-prerequisites)**.
- Dann laden wir **[neueste ASF-Version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** in geeigneter OS-spezifischer Variante herunter.
- Als nächstes werden wir das Archiv an einen neuen Ort extrahieren.
- Dann werden wir **[konfigurieren ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- Und schließlich, wir starten ASF und sehen seine Magie.

Einige der Schritte sind selbsterklärend, andere erfordern mehr Aufmerksamkeit von Ihnen. Keine Sorge, wir haben dich abgedeckt.

---

### .NET Abhängigkeiten

Der erste Schritt ist stellt sicher, dass Ihr Betriebssystem ASF überhaupt richtig ausführen kann. Sie müssen das nicht wissen, aber ASF ist in C#, basierend auf . ET-Plattform und benötigen möglicherweise native Bibliotheken, die noch nicht auf Ihrer Plattform verfügbar sind. Man denke an DirectX für die 3D-Spiele oder an den Motor für den Autostart.

Abhängig davon, ob Sie Windows, Linux oder macOS verwenden, haben Sie unterschiedliche Anforderungen. Das Referenzdokument ist **[. ET Voraussetzungen](https://docs.microsoft.com/dotnet/core/install)**, aber um der Einfachheit willen haben wir auch alle benötigten Pakete unten aufgelistet, so dass Sie es nicht lesen müssen, es sei denn, Sie haben Probleme oder Sie haben zusätzliche Fragen.

Es ist vollkommen normal, dass manche (oder sogar alle) Abhängigkeiten bereits in Ihrem System existieren, weil sie mit der Software Dritter, welche Sie verwenden, mitinstalliert wurden. Trotzdem muss das nicht der Fall sein so dass Sie den passenden Installer für Ihr Betriebssystem ausführen sollten - ohne diese Abhängigkeiten wird ASF überhaupt nicht starten und Sie erhalten kaum nützliche Informationen, um Ihnen mitzuteilen, was falsch ist.

Denken Sie daran, dass Sie für betriebssystemspezifische ASF-Versionen nichts Weiteres machen müssen. Insbesondere betrifft dies die Installation des .NET SDK oder der Runtime, da die betriebssystemspezifische Versionen das alles bereits beinhalten. Sie benötigen nur .NET Voraussetzungen (Abhängigkeiten) zum Ausführen . ET Laufzeit in ASF enthalten - also nur die Dinge, die wir unten angeben, ohne weitere Ergänzungen.

#### **[Windows](https://docs.microsoft.com/de-de/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** für 64-bit, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** für 32-bit oder **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** für 64-bit ARM)
- Es wird dringend empfohlen sicherzustellen, dass alle Windows-Updates bereits installiert sind. Wenn Sie es nicht aktiviert haben, dann brauchen Sie mindestens die Updates **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** und **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**. Weitere Updates könnten notwendig sein. Sie müssen sich keine Sorgen darüber machen, wenn Ihr Windows aktuell oder zumindest aktuell genug ist.

#### **[Linux](https://docs.microsoft.com/de-de/dotnet/core/install/linux)**:
Paketnamen hängen von der Linux-Distribution, die Sie verwenden, ab. Wir listen nur die Gebräuchlichsten auf. Sie können alle über den nativen Paketmanager für Ihr Betriebssystem (wie zum Beispiel `apt` unter Debian oder `yum` unter CentOS) installieren. Das sind ziemlich Standard-Bibliotheken, die unabhängig von der verwendeten Distribution verfügbar sein sollten Es geht nur darum, herauszufinden, wie sie in Ihrer Wahlumgebung aufgerufen werden.

- `ca-certificates` (Standard SSL Zertifikate für HTTPS Verbindungen)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, neueste Version für Ihre Distribution, zum Beispiel `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-libs`, die neuste Version für ihre Distribution, mindestens `1.1.X`)
- `libstdc++6` (`libstdc++`, Version `5.0` oder höher)
- `zlib1g` (`zlib`)

Zumindest ein Großteil davon sollte bereits nativ auf Ihrem System verfügbar sein. Zum Beispiel benötigt die minimale Installation von Debian Stable normalerweise nur `libicu76`.

#### **[macOS](https://docs.microsoft.com/de-de/dotnet/core/install/macos)**:
- Sie brauchen nichts spezielles, aber Sie sollten die neueste Version von macOS installiert haben, mindestens 12.0+

---

### Herunterladen

Da wir nun alle benötigten Abhängigkeiten installiert haben, ist der nächste Schritt das Herunterladen der **[neuesten ASF-Version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF ist in mehreren Varianten verfügbar, aber Sie sind nur am Paket interessiert, das Ihrem Betriebssystem und der Architektur Ihres PCs entspricht. Zum Beispiel, wenn Sie 64-Bit Windows verwenden, dann wollen Sie die `ASF-win-x64`-Variante. Für mehr Information über die verfügbaren Varianten, besuche bitte den Abschnitt **[ Kompatibilität](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-de-DE)**. ASF kann auch in Umgebungen ausgeführt werden, für die wir kein OS-spezifisches Paket erstellen wie zum Beispiel **32-Bit Windows**, aber Sie benötigen **[generisches Setup](#generic-setup)** dafür.

![Assets](https://i.imgur.com/Ym2xPE5.png)

Beginnen Sie nach dem Download damit, die Zip-Datei in einen eigenen Ordner zu entpacken. Wenn Sie dafür ein spezielles Tool benötigen, **[7-zip](https://www.7-zip.org)** wird es tun aber alle Standardwerkzeuge wie eingebaute Windows-Extraktion oder `Entpackung` von Linux/macOS sollten ebenfalls problemlos funktionieren.

Bitte entpacken Sie ASF nach **das eigene Verzeichnis** und nicht in ein existierendes Verzeichnis, das Sie bereits für etwas anderes verwenden - das ist wichtig. ASF enthält automatische Aktualisierung-Funktion, die eigene Dateien ersetzt und normalerweise alle alten und nicht zusammenhängenden Dateien beim Upgrade löscht, , was wiederum dazu führen kann, dass Sie alles verlieren, was Sie in das ASF-Verzeichnis einfügen. Wenn du zusätzliche Skripte oder Dateien hast, die du mit ASF verwenden möchtest, ist das kein Problem Erstellen Sie einen dedizierten Ordner für diese, können Sie ASF immer in einem Ordner tiefer legen.

Eine beispielhafte Struktur könnte so aussehen:

```text
C:\ASF (wo Sie Ihre eigenen Dateien gespeichert haben)
    ├── MeineNotizen.txt (optional)
    ├── AsfMakeMeCoffeeScript.bat (optional)
    ├── (…) (alle anderen Dateien ihrer Wahl, optional)
    ├── Core (nur ASF gewidmet, wo Sie das Archiv extrahieren)
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         ├── www
         ├── (…)
```

---

### Konfiguration

Wir sind nun bereit, den allerletzten Schritt, die Konfiguration, durchzuführen. ASF arbeitet mit dem Konzept von "Bots", jeder Bot ist in der Regel ein einzelner Steam Account, den du innerhalb von ASF verwenden möchtest. Du kannst so viele Bots angeben, wie du möchtest, aber für den Starter konzentrieren wir uns nur auf einen von ihnen - normalerweise auf dein Hauptkonto. ASF hat auch Nicht-Bot-Konfigurationsdateien, die wichtigste ist die globale Konfigurationsdatei, die alle Bots in der Instanz betrifft.

Die allgemeine Faustregel ist, dass **wenn du nicht weißt oder keine Einstellung verstehst, lassen Sie es mit seinem Standardwert belassen, ohne etwas** zu ändern. ASF bietet unzählige Möglichkeiten, fast alle Funktionen zu konfigurieren, anzupassen und anzupassen, aber wie oben erwähnt, versuchen es direkt vom Fledermaus zu verstehen ist ein Kaninchenloch, das dich schnell in schwere Verwirrung ziehen kann, wenn nicht **[direkt in den Abgrund](https://www.youtube.com/watch?v=KK3KXAECte4)**. Stattdessen empfehlen wir, zuerst ein funktionierendes Beispiel zu haben und erst dann mit zusätzlichen Optionen anzufangen, mit Hilfe von **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** Seite im Wiki während des Wechsels **eine Sache gleichzeitig**.

ASF-Konfiguration kann auf verschiedene Art und Weise durchgeführt werden - über unsere eingebaute ASF-ui Frontend, einen eigenständigen Web-Konfigurationsgenerator, oder manuell. Dies wird ausführlich auf der Seite **[Installation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)** erläutert, also beziehen Sie sich darauf, wenn Sie detailliertere Informationen benötigen. Wir verwenden eigenständige Web-Konfigurationsgeneratoren als Ausgangspunkt, weil es funktioniert, auch wenn ASF-ui aus irgendeinem Grund nicht richtig gestartet oder funktioniert.

Navigieren Sie zu unserem **[Webkonfigurationsgenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** Seite mit Ihrem bevorzugten Browser. Wir empfehlen Chrome oder Firefox, aber es sollte keine Rolle spielen, solange Ihr Browser für alles andere funktioniert.

Klicken Sie nach dem Öffnen der Seite auf „Bot“. Sie sollten nun eine ähnliche Seite wie die unten sehen:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Wenn die Version von ASF, die Sie gerade heruntergeladen haben, älter ist als der Konfigurationsgenerator, der standardmäßig verwendet wird, dann wählen Sie einfach Ihre ASF-Version aus dem Dropdown-Menü. Dies kann (selten) passieren, da der Konfigurationsgenerator zur Generierung von Konfigurationen auf neuere ASF-Versionen verwendet werden kann, die noch nicht als stabil markiert waren. Sie haben die neueste stabile Version von ASF heruntergeladen, die verifiziert ist, um zuverlässig zu arbeiten so kann es ein bisschen älter sein als die absolute Schneiden-Version, die für den erstmaligen Einsatz völlig ungeeignet ist.

Beginnen Sie mit **und setzen Sie den Namen Ihres Bots** in das als rot markierte Feld mit dem Namen `Name`. Dies kann jeder beliebige Name sein, den Sie verwenden möchten, z. B. Ihr Spitzname, Kontoname, eine Nummer oder etwas anderes. Es gibt nur ein Wort, das Sie nicht verwenden können, nämlich `ASF`, da dieses Schlüsselwort für die globale Konfigurationsdatei reserviert ist. Außerdem kann Ihr Bot-Name nicht mit einem Punkt beginnen (ASF ignoriert diese Dateien absichtlich). Wir empfehlen Ihnen auch, Leerzeichen zu vermeiden, Sie können `_` bei Bedarf als Worttrennzeichen verwenden - keine strikte Anforderung, aber Sie haben sonst Schwierigkeiten mit ASF-Befehlen.

Bot-Name ausgewählt? Super, im nächsten Schritt, **ändern `Aktiviert` wechseln auf**, , dass man festlegt, ob Ihr Bot nach dem Start automatisch von ASF gestartet werden soll (des Programms). Dies führt dazu, dass ASF angibt, dass Ihr Bot in der Konfigurationsdatei deaktiviert ist und es wird warten, bis Ihre Eingabe zu starten, was nicht ist, was wir in diesem Beispiel tun wollen.

Als nächstes stehen zwei empfindliche Eigenschaften an: `SteamLogin` und `SteamPassword`. Du kannst hier eine andere Entscheidung treffen - entweder kannst du deine Steam-Login-Daten in diesen beiden Eigenschaften einfügen, oder Sie können sich entschließen, dies zu tun, so dass sie leer bleiben.

ASF benötigt Ihre Anmeldeinformationen, da es seine eigene Implementierung des Steam-Clients beinhaltet und die gleichen Details benötigt, die Sie selbst benutzten, um sich anzumelden. Ihre Anmeldedaten werden nicht irgendwo gespeichert, sondern nur auf Ihrem PC im ASF `Konfigurationsverzeichnis` (sobald Sie die generierte Konfiguration heruntergeladen haben). Unser Web-Konfigurationsgenerator ist Client-basierte Anwendung, was bedeutet, dass alles, was Sie auf unserer eigenständigen Web-config-Generator-Website tun, lokal in Ihrem Browser läuft, um gültige ASF-Konfigurationen zu generieren, ohne Details verlassen Sie immer Ihren PC an erster Stelle, so dass Sie sich keine Sorgen um mögliche vertrauliche Daten machen müssen. Trotzdem verstehen wir, wenn du aus welchen Gründen auch immer nicht deine Anmeldeinformationen dort stellen möchtest, das und Sie können sie später manuell in generierte Dateien einfügen, oder sie komplett weglassen und ohne sie arbeiten.

Wenn Sie sich für die Eingabe Ihrer Zugangsdaten entscheiden, kann sich ASF beim Start automatisch anmelden, die zusammen mit der optionalen 2FA Ihnen effektiv die Möglichkeit gibt, das Programm durch einen Doppelklick auszuführen. Möchten Sie diese weglassen, wird ASF **bei Bedarf um** die Eingabe **Ihrer Details bitten**. Auf diese Weise wird nichts gespeichert, allerdings kann ASF nicht ohne Ihre Hilfe arbeiten. Es liegt an Ihnen, was Sie mehr bevorzugen, und Sie können weitere Informationen auch im **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)** Abschnitt finden, wie üblich.

Nebenbei bemerkt: Sie können sich auch dazu entschließen, nur ein Feld leer zu lassen, als etwa `SteamPassword`. ASF wird dann in der Lage sein, Ihren Login automatisch zu verwenden, wird aber bei Bedarf immer noch nach Passwort fragen (ähnlich dem Steam Client). Sollten Sie zufällig die vierstellige Kindersicherungs-PIN zur Entsperrung Ihres Accounts verwenden, empfehlen wir Ihnen zudem, diese in das Feld `SteamParentalPin`. Sie können in einigen Fällen das Feld auch leer lassen, und zusehen, wie ASF jene PIN in wenigen Sekunden „errät“. Hoppla.

Nachdem Sie den oben aufgeführten Anweisungen gefolgt sind (also **Bot Name**, **Schalter aktiviert**, und **Anmeldeinformationen** eingegeben), sieht Ihre Webseite sieht nun ähnlich aus wie die untenstehende aus:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Sie können jetzt auf den „Download“-Button klicken und unser Web-Konfigurationsgenerator erzeugt eine neue `json`-Datei basierend auf Ihrem gewählten Namen. Speichern Sie diese Datei in das Verzeichnis `config` , das sich in dem Ordner befindet, in dem Sie die Zip-Datei im vorherigen Schritt entpackt haben.

Glückwunsch! Sie haben gerade die sehr einfache ASF-Bot-Konfiguration abgeschlossen. Es gibt noch viel mehr zu entdecken, aber jetzt ist das alles, was du brauchst.

---

### Ausführen von ASF

Ich weiß, du wartest für diesen Moment und wir können dich nicht länger halten, da Sie jetzt bereit sind, das Programm zum ersten Mal zu starten. Führen Sie einfach einen Doppelklick auf die `ArchiSteamFarm`-Binärdatei im ASF-Verzeichnis aus. Alternativ können Sie diese auch von der Konsole aus starten.

Jetzt wäre ein guter Zeitpunkt, um unsere **[Fernkommunikation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** zu überprüfen, wenn Sie über Dinge besorgt sind, die ASF programmiert hat insbesondere Aktionen, die es in deinem Namen vornehmen wird, wie zum Beispiel in unserer Steam-Gruppe standardmäßig beizutreten. Sie können die ausgewählten Funktionen später immer deaktivieren, wenn Sie sie nicht mögen, ASF kommt einfach mit sinnvollen Standardwerten, und wir mussten einige Entscheidungen über die allgemeine Nutzung treffen, die für die Mehrheit unserer Benutzerbasis gilt, sowie unsere eigene Sicht auf das Programm in seinem Prinzip.

Angenommen alles lief gut, was hauptsächlich die Installation aller erforderlichen Abhängigkeiten im ersten Schritt in Betracht zieht und ASF im dritten konfigurieren, sollte ASF korrekt starten, den ersten Bot entdecken und versuchen, sich einzuloggen:

![ASF](https://i.imgur.com/u5hrSFz.png)

ASF wird wahrscheinlich noch ein Detail von dir benötigen - 2FA um auf das Konto zuzugreifen (es sei denn, du hast SteamGuard komplett deaktiviert, dann nein). Folgen Sie einfach den Anweisungen auf dem Bildschirm, Sie können Code von Authentifizierer/E-Mail oder akzeptieren Sie die Bestätigung in der mobilen App.

Etwas ist schief gelaufen?

#### ASF startet überhaupt nicht, kein Konsolenfenster

Entweder fehlen die .NET Voraussetzungen oder Sie haben eine falsche ASF Variante für Ihren Rechner heruntergeladen. Wenn Sie nicht wissen, was falsch ist, schau in unserer **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)</a>** für eine mögliche Möglichkeit, genaue Probleme zu finden und wenn Sie noch stecken, erreichen Sie unsere **[Support](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### Keine Bots definiert

Sie haben die generierte Konfiguration nicht in das `Config` Verzeichnis gelegt. Einige andere häufige Fehler in diesem Schritt könnten das manuelle Ändern der Erweiterung von `.json` auf `beinhalten. xt`, und einige Betriebssysteme (z. Windows) verstecken übliche Erweiterungen standardmäßig, also stellen Sie sicher, dass Ihre Datei an geeigneter Stelle und auch mit dem entsprechenden Namen ist.

#### Bot wird nicht gestartet, da es in der Konfigurationsdatei deaktiviert ist

Du hast vergessen, den `Aktivierten` Schalter zu drehen, der ASF angibt, den Bot automatisch zu starten. Es sei denn, das war Ihre Absicht, aber dann sollten Sie schon wissen, wie Sie Befehle ausführen sollen, einfach `starten Sie` nach dieser Nachricht.

#### `Ungültiges Passwort`

Ihre Anmeldedaten sind wahrscheinlich falsch. Überprüfen Sie Ihre `SteamLogin` und `SteamPassword` in der generierten Konfiguration, falls sie falsch liegen, korrigieren Sie diese durch die Rückkehr zum Konfigurationsschritt. Wenn du immer noch Probleme hast, versuche die gleichen Anmeldedaten in deinem eigenen Steam Client zu verwenden - du solltest dich auch nicht einloggen und vielleicht erhalten Sie weitere Informationen darüber, was auf diese Weise falsch ist.

#### Alles gut?

Nach dem Durchlaufen des ersten Login-Gate, vorausgesetzt Ihre Daten sind korrekt, Sie werden sich erfolgreich einloggen und ASF verwendet Standardeinstellungen, die Sie bis jetzt nicht berührt haben:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Dies beweist, dass ASF nun erfolgreich seine Arbeit auf Ihrem Konto erledigt, sodass Sie nun das Programm minimieren und etwas anderes tun können. Gehen Sie voran, Sie haben es verdient, vielleicht füllen Sie dieses Getränk Ihrer Wahl zumindest!

Landkarten sind ein Thema für einen weiteren langen Artikel wie diesen aber im Prinzip: nach genug Zeit (abhängig von **[Leistung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), du siehst, wie Steam Trading-Karten langsam fallen gelassen werden. Um das zu erreichen, musst du gültige Spiele zum Bauernhof haben, zeige als "du kannst X weitere Kartendrops vom Spielen dieses Spiels" auf deiner **[Abzeichen Seite](https://steamcommunity.com/my/badges)** - wenn es keine Spiele gibt, dann wird ASF angeben, dass nichts zu tun ist wie in unseren **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**angegeben, welche die am häufigsten gestellten Fragen beantwortet, Wenn man sich fragt, warum es trotz der 14 Spiele auf ihrem Konto nichts zu tun gäbe - nein, es ist kein Bug.

Dies schließt unseren sehr einfachen Einrichtungsleitfaden ab. Wie in jedem RPG-Spiel hast du das Tutorial beendet und wir verlassen dich die ganze ASF-Welt, um jetzt zu erkunden. Zum Beispiel können Sie jetzt entscheiden, ob Sie ASF weiter konfigurieren möchten, oder lassen Sie es in den Standardeinstellungen erledigen. Wir werden ein paar weitere grundlegende Details behandeln, wenn du mehr lesen möchtest und dann das ganze Wiki für Entdeckungen belassen.

---

### Erweiterte Konfiguration

#### Auf mehreren Konten gleichzeitig sammeln

ASF ermöglicht das Sammeln von Karten auf mehreren Konten gleichzeitig. Dies ist seine Hauptfunktion. Sie können weitere Konten zu ASF hinzufügen, indem Sie mehr Bot-Konfigurationsdateien erzeugen, genau so, wie Sie Ihre erste vor wenigen Minuten generiert haben. Sie müssen nur zwei Dinge sicherstellen:

- Einmaliger Bot-Name, wenn Sie bereits Ihren ersten Bot mit dem Namen `MainAccount`haben, können Sie keinen anderen mit dem gleichen Namen haben.
- Gültige Anmeldedaten wie `SteamLogin`, `SteamPassword` und `SteamParentalCode` (wenn du sie ausgefüllt hast)

Mit anderen Worten – gehen Sie einfach erneut zur Konfiguration und machen genau das Gleiche, nur für Ihr zweites oder drittes Konto. Denken Sie daran, eindeutige Namen für alle Bots zu verwenden, um bestehende Konfigurationen nicht zu überschreiben.

---

#### Einstellungen ändern

In unserem eigenständigen Web config-Generator ändern Sie die vorhandenen Einstellungen genau auf die gleiche Art und Weise - indem Sie eine neue Konfigurationsdatei erstellen. Klicken Sie auf "Erweiterte Einstellungen umschalten" und sehen Sie, was Sie entdecken können. In diesem Beispiel ändern wir die `CustomGamePlayedWhileFarming` Einstellungen, , der es dir erlaubt, einen eigenen Namen einzustellen, der angezeigt wird, wenn ASF Landwirtschaft betreibt, anstatt das eigentliche Spiel anzuzeigen.

Lass uns das erst ein wenig analysieren. Wenn du ASF ausführst und Landwirtschaft startest, wirst du in den Standardeinstellungen sehen, dass dein Steam Account jetzt im Spiel ist:

![Steam](https://i.imgur.com/1VCDrGC.png)

Das macht Sinn, nachdem alle ASF gerade der Steam-Plattform mitgeteilt hat, dass wir das Spiel spielen, wir brauchen Karten von ihm, oder? Aber hey, wir können das anpassen! Erweiterte Einstellungen umschalten, wenn du noch nicht fertig bist, dann findest du `CustomGamePlayWhileFarming`. Lege einfach einen benutzerdefinierten Text ein, den du dort anzeigen möchtest, wie zum Beispiel "Idling-Karten":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Nun können Sie die neue Konfigurationsdatei auf genau die gleiche Weise herunterladen, dann **überschreiben** Sie Ihre alte Konfigurationsdatei mit der neuen. Sie können auch Ihre alte Konfigurationsdatei löschen und die neue natürlich an ihre Stelle setzen.

ASF ist ziemlich intelligent und sollte beachten, dass du die Konfiguration geändert hast, , die es dann automatisch abholen und anwenden soll, ohne ein Programm neu zu starten. Falls dies nicht der Fall ist, können Sie das Programm einfach neu starten, um sicherzustellen, dass Ihre neue Konfiguration abgeholt wird. Danach solltest du bemerken, dass ASF jetzt deinen benutzerdefinierten Text an der vorherigen Stelle anzeigt:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

Dies bestätigt, dass Sie Ihre Konfiguration erfolgreich bearbeitet haben. Auf genau die gleiche Weise können Sie globale ASF-Eigenschaften ändern, indem Sie vom Bot-Tab zum »ASF«-Tab wechseln, die generierte Konfigurationsdatei `ASF.json` herunterladen und sie in das `config`-Verzeichnis legen.

Das Bearbeiten Ihrer ASF-Konfigurationen kann durch die Verwendung unserer ASF-ui Frontend, die weiter unten erläutert wird, wesentlich vereinfacht werden.

---

#### Verwendung von ASF-UI

Wie bereits erwähnt, ist ASF eine Konsolen-App und startet standardmäßig keine grafische Benutzeroberfläche. Wir arbeiten jedoch aktiv an unserer IPC-Schnittstellen Frontend **[ASF-UI](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE#asf-ui)**, was eine hervorragende und benutzerfreundliche Möglichkeit sein kann, auf verschiedene ASF-Funktionen zuzugreifen.

Um ASF-ui nutzen zu können, muss `IPC` aktiviert sein, , was die Standardoption ist, also ist es bereits aktiv, wenn Sie sie nicht manuell deaktiviert haben. Beim Start von ASF, sollten Sie in der Lage sein zu bestätigen, dass die IPC-Schnittstelle ebenfalls automatisch gestartet wurde:

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC, kurz gesagt, ist der eingebaute Webserver von ASF, der lokal auf Ihrem Rechner startet, damit Sie mit Ihrem bevorzugten Webbrowser interagieren können. Angenommen, dass es richtig begonnen hat, können Sie auf die IPC-Schnittstelle von ASF zugreifen, indem Sie auf **[diesen](http://localhost:1242)** Link klicken, solange ASF läuft, von derselben Maschine. Sie können ASF-ui für verschiedene Zwecke verwenden, z. B. das Bearbeiten der Konfigurationsdateien vor Ort oder das Senden von **[Befehlen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)**. Schon Sie einfach einen Blick darauf, um alle Funktionalitäten von ASF-UI kennenzulernen.

![ASF-UI](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Zusammenfassung

Sie haben ASF bereits erfolgreich so eingerichtet, dass es Ihre Steam-Konten nutzt, und haben es ein wenig nach Ihren Wünschen angepasst. Wenn Sie unserer gesamten Anleitung gefolgt sind, dann ist es Ihnen auch gelungen, ASF über unsere ASF-ui Schnittstelle zu optimieren und seine Funktionalitäten zu entdecken. Dies schließt unser Tutorial, aber wir verlassen dich mit einigen zusätzlichen Zeigern auf Dinge, die dich interessieren könnten, "Seiten-Quests", wenn du darauf bestehen möchtest:

- Unsere **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** Abschnitt wird Ihnen erklären, was **alle** die verschiedenen Einstellungen tatsächlich tun und was Ihnen ASF sonst noch anbieten kann. Denken Sie daran, während des Lesens richtig zu hydratieren, Sie wurden gewarnt.
- Wenn Sie auf einige Probleme gestoßen sind oder eine generische Frage haben, schauen Sie in unsere **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**, , die alle oder zumindest eine große Mehrheit der Fragen und Fragen, die Sie haben.
- Wenn Sie alles über ASF erfahren möchten und wie es Ihr Leben vereinfachen kann, dann schauen Sie sich den Rest von **[unserem Wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-de-DE)** an. Benutzen Sie die Sidebar auf der rechten Seite, um das Thema auszuwählen, das Sie interessiert.
- Und schließlich wenn Sie herausgefunden haben, dass unser Programm für Sie nützlich ist und Sie den enormen Arbeitsaufwand schätzen, der in dieses Programm investiert wurde Sie können auch eine kleine **[Spende](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** für unsere Sache in Betracht ziehen. ASF ist Arbeit der Liebe, wir haben in unserer Freizeit seit über 10 Jahren hart gearbeitet, um diese Erfahrung für Sie möglich zu machen und wir sind sehr stolz darauf - sogar $1 wird hoch geschätzt und zeigt, dass Sie sich darum kümmern. Auf jeden Fall viel Spaß!

---

## Generisches Setup

Dieser Anhang ist für fortgeschrittene Benutzer gedacht, die ASF einrichten wollen, die in **[generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)** Variante ausgeführt werden soll. Während die Verwendung schwieriger ist als **[OS-spezifische Varianten](#os-specific-setup)**, bietet sie auch zusätzliche Vorteile.

Sie möchten `generische` Variante verwenden, wenn:
- Sie verwenden ein Betriebssystem, für das wir kein OS-spezifisches Paket erstellen (z.B. 32-Bit Windows)
- Sie haben bereits .NET Runtime/SDK, oder möchten eines installieren und verwenden
- Sie möchten die Größe der ASF-Struktur und den Speicherbedarf selbst minimieren, indem Sie die Laufzeitanforderungen selbst bearbeiten
- Sie möchten ein benutzerdefiniertes **[Plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** verwenden, das ein `generisches` Setup für ASF benötigt (aufgrund fehlender nativer Abhängigkeiten)

Natürlich können Sie es auch in jedem anderen Szenario verwenden, aber die oben genannten haben den größten Sinn.

Beachten Sie jedoch, dass generisches Setup mit einer Drehung kommt - **, die Sie** in diesem Fall für .NET Laufzeit verantwortlich sind. Das bedeutet, dass, wenn Ihr .NET SDK (Laufzeit) nicht verfügbar, veraltet oder defekt ist, ASF einfach nicht funktioniert. Aus diesem Grund empfehlen wir diese Einstellung nicht für zufällige Benutzer, da Sie jetzt sicherstellen müssen, dass Sie . ET SDK (Laufzeit) entspricht ASF-Anforderungen und kann ASF ausführen, im Gegensatz zu **uns** und stellt sicher, dass unsere . Die mit ASF gebündelte ET Laufzeit kann dies tun.

Für `generisches` Paket können Sie mit nur zwei kleinen Änderungen dem gesamten OS-spezifischen Leitfaden folgen. Neben der Installation von .NET Voraussetzungen möchten Sie auch .NET SDK installieren und anstelle von OS-spezifischen `ArchiSteamFarm(). xe)` ausführbare Datei, werden nun heruntergeladen und haben eine generische `ArchiSteamFarm.dll` Binärdatei. Alles andere ist identisch.

Mit zusätzlichen Schritten:
- **[.NET Abhängigkeiten](#net-prerequisites)** installieren.
- Installieren Sie **[.NET SDK](https://www.microsoft.com/net/download)** (oder zumindest ASP.NET Core und .NET Runtimes) passend für ihr Betriebssystem. Sie möchten höchstwahrscheinlich ein Installationsprogramm verwenden. Lesen Sie die **[Runtime-Anforderungen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-de-DE#runtime-requirements)**, wenn Sie sich nicht sicher sind, welche Version installiert werden muss.
- Laden Sie die **[neueste ASF-Version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** (latest) der `generic` Variante herunter.
- Das Archiv an einem neuen Ort entpacken.
- **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**so konfigurieren wie oben beschrieben.
- Starten Sie ASF entweder mit einem Hilfsskript oder führen Sie `dotnet /pfad/zu/ArchiSteamFarm.dll` aus Ihrer Lieblingsshell heraus manuell aus.

Generische Variante von ASF hat kein maschinenspezifisches Binärprogramm, nach allem heißt es `generisch` aus einem Grund - es ist plattform-agnostischer Bau, der überall funktionieren kann. also nicht mit `exe` Datei rechnen.

Aus diesem Grund haben wir es mit Helfer-Skripten (wie `ArchiSteamFarm.cmd` für Windows und `ArchiSteamFarm gebündelt. h` für Linux/macOS), die sich neben `ArchiSteamFarm.dll` befinden. Sie können diese verwenden, wenn Sie `dotnet` nicht manuell ausführen möchten.

Natürlich funktionieren Helferskripte nicht, wenn Sie nicht installieren . ET SDK und Sie haben keine `dotnet` ausführbare Datei in Ihrem `PATH`. Sie sind ebenfalls völlig optional zu verwenden, du kannst jederzeit `dotnet /path/to/ArchiSteamFarm verwenden. ll` manuell, wenn Sie möchten, wie unter der Haube mit einigen zusätzlichen Optimierungen, das ist genau das, was diese Skripte ohnehin tun.