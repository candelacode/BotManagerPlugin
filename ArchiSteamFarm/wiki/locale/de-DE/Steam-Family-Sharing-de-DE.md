# Steam-Familienbibliothek

ASF unterstützt sowohl die alte, als auch die neue Steam-Familienbibliothek. Um zu verstehen, wie ASF damit umgeht, sollten Sie zunächst lesen, wie die **[Steam-Familienbibliothek funktioniert](https://store.steampowered.com/promotion/familysharing)**, welche der Steam-Shop bereitstellt. Überprüfen Sie zusätzlich **[die Nachrichten](https://store.steampowered.com/news/app/593110/view/4149575031735702628)** für bevorstehende Änderungen am System der neuen Steam-Familienbibliothek, mit dem ASF auch kompatibel ist.

---

## ASF

Die Unterstützung für das Steam-Familienbibliothek-Feature in ASF ist transparent, d.h. es werden keine neuen Bot/Prozesskonfigurationseigenschaften eingeführt – es funktioniert sofort als zusätzliche integrierte Funktionalität.

ASF beinhaltet eine entsprechende Logik, um zu erkennen, dass die Bibliothek von Familienmitgliedern gesperrt ist, sodass Sie nicht durch den Start eines Spiels aus der Spielsitzung geworfen werden. ASF verhält sich genau so, wie mit dem primären Konto, das die Sperre hält. Daher wird ASF, wenn diese Sperre entweder von Ihrem Steam-Client oder von einem der Benutzer Ihrer Familie gehalten wird nicht versuchen, einen Sammelprozess zu starten, sondern darauf warten, dass die Sperre freigegeben wird. Dies ist hauptsächlich mit dem alten System verbunden - das neue System ermöglicht es Ihren Nutzern mit Familie teilen zu spielen andere Spiele als die, die derzeit von ASF betrieben werden.

Zusätzlich zu oben, nach dem Einloggen wird ASF auf Ihre Familien-Teilsysteme zugreifen (alt und neu), Aus welchen es Benutzer (Steam IDs) extrahieren darf, die deine Bibliothek verwenden dürfen. Diese Benutzer erhalten die Erlaubnis `FamilySharing` **[Befehle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, erlaubt es ihnen, `Pause~` Befehl auf Bot-Konto zu verwenden, das Spiele mit ihnen teilt das die automatische Kartenzucht pausiert, um ein Spiel zu starten, das geteilt werden kann - dies gilt vor allem auch für das alte System aber könnte immer noch mit dem neuen System verwendet werden, falls ASF derzeit landwirtschaftliche Spiele, die Ihre Nutzer spielen wollen.

Die Verbindung beider oben erläuterten Funktionalitäten ermöglicht es Ihren Freunden, den `pause~` Befehl für Ihren Karten-Sammelprozess zu beginnen, ein Spiel zu starten, so lange zu spielen wie sie möchten; und schließlich, nachdem sie fertig gespielt haben, wird der Karten-Sammelprozess automatisch von ASF wieder aufgenommen. Natürlich ist das Senden von `pause~` nicht erforderlich, wenn ASF derzeit keinen aktiven Sammelprozess betreibt, da Ihre Freunde das Spiel sofort starten können und die oben erläuterte Logik stellt sicher, dass sie nicht aus der Sitzung geworfen werden.

---

## Einschränkungen

Das Steam-Netzwerk neigt dazu ASF falsche Statusupdates zu übermitteln. Dies lässt ASF unter Umständen glauben, der Account sei nicht in Nutzung. Die Folge: Der Freund wird frühzeitig aus seiner Spielsitzung geworfen. Dies ist das gleiche Problem, welches von uns bereits in **[diesem FAQ Artikel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-de-DE#asf-wirft-mich-aus-meiner-steam-client-sitzung-w%C3%A4hrend-ich-spiele--dieser-account-wird-an-einem-anderen-pc-verwendet)** erläutert wurde. Wir empfehlen die gleiche Lösung. Statten Sie Ihren Freund mit `Operator`-Rechten (oder höher) aus und informieren Sie diesen über die Nutzung der `pause` und `resume` Befehle.