# Erweiterungsentwicklung

ASF bietet Unterstützung für benutzerdefinierte Plugins, die während der Ausführung geladen werden können. Erweiterungen ermöglichen es Ihnen, das ASF-Verhalten anzupassen, z. B. durch Hinzufügen von benutzerdefinierten Befehlen, einer benutzerdefinierten Handelslogik oder der vollständigen Integration mit Diensten und APIs von Drittanbietern.

Diese Seite beschreibt ASF Erweiterungen aus der Perspektive der Entwickler - Erstellung, Wartung, Veröffentlichung und ähnliches. Wenn Sie die Benutzerperspektive sehen wollen, klicken Sie **[hier.](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**

---

## Grundlegendes

Plugins sind standardmäßige .NET Bibliotheken, welche eine Klasse definieren, die von der in ASF deklarierten gemeinsamen `IPlugin` Schnittstelle erbt. Sie können Plugins völlig unabhängig von der ASF-Hauptversion entwickeln und sie in aktuellen und zukünftigen ASF-Versionen wiederverwenden, solange die interne ASF-API kompatibel bleibt. Das in ASF verwendete Plugin-System basiert auf `System.Composition`, früher bekannt als **[Managed Extensibility Framework](https://docs.microsoft.com/dotnet/framework/mef)**, das ASF erlaubt, Ihre Bibliotheken während der Laufzeit zu erkennen und zu laden.

---

### Erste Schritte

Wir haben ein **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate)** für Sie vorbereitet, das Sie als Basis für Ihr Plugin-Projekt verwenden können (und sollten). Die Verwendung der Vorlage ist **keine Voraussetzung** (da Sie alles von Grund auf neu machen können), aber wir empfehlen dringend, sie zu verwenden, da sie Ihre Entwicklung drastisch beschleunigen und die Zeit, die Sie benötigen, um alles richtig zu machen, reduzieren kann. Schauen Sie sich einfach die **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** der Vorlage an, dort finden Sie weitere Anleitungen. Unabhängig davon werden wir im Folgenden die Grundlagen abdecken, für den Fall, dass Sie ganz von vorne anfangen wollen oder die in der Plugin-Vorlage verwendeten Konzepte besser verstehen wollen - das ist normalerweise nicht nötig, wenn Sie sich für unsere Plugin-Vorlage entschieden haben.

Ihr Projekt sollte eine Standard-.NET-Bibliothek sein, die auf das entsprechende Framework Ihrer Ziel-ASF-Version abzielt, wie im Abschnitt **[Kompilierung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation)** angegeben.

Das Projekt muss auf die Haupt-Assembly `ArchiSteamFarm` verweisen, entweder auf die vorgefertigte Bibliothek `ArchiSteamFarm.dll`, die Sie als Teil der Version heruntergeladen haben, oder auf das Quellprojekt (z.B. wenn Sie sich entschieden haben, den ASF-Baum als Submodul hinzuzufügen). Dadurch können Sie auf ASF-Strukturen, Methoden und Eigenschaften zugreifen und diese entdecken, insbesondere die Kernschnittstelle `IPlugin`, von der Sie im nächsten Schritt erben müssen. Das Projekt muss auch mindestens `System.Composition.AttributedModel` referenzieren, was Ihnen erlaubt, Ihr `IPlugin` für ASF zu `exportieren`. Überdies kann/muss man auf andere gemeinsame Bibliotheken verweisen, um die Datenstrukturen zu interpretieren, die man in manchen Schnittstellen erhält, aber wenn man sie nicht explizit benötigt, reicht das fürs Erste.

Wenn Sie alles richtig gemacht haben, wird Ihr `csproj` ähnlich wie unten aussehen:

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netto.</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <! - Da Sie das Plugin in den ASF-Prozess laden, der diese Abhängigkeiten bereits beinhaltet, IncludeAssets="compile" erlaubt es Ihnen, sie von der endgültigen Ausgabe wegzulassen -->
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" IncludeAssets="compile" Version="10.0.0" />
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="10.0.0" />
  </ItemGroup></ItemGroup>

  <ItemGroup>
    <ProjectReference Include="C:\\Path\To\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" />

    <! - Wenn Sie mit heruntergeladener DLL Binärdatei erstellen, verwenden Sie dies anstelle von <ProjectReference> oben -->
    <! - <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" /> -->
  </ItemGroup>
</Project>
```

Codeseitig muss Ihre Plugin-Klasse von der Schnittstelle `IPlugin` (entweder explizit oder implizit durch Erben einer spezielleren Schnittstelle wie `IASF`) und `[Export(typeof(IPlugin))]` erben, um von ASF zur Laufzeit erkannt zu werden. Das einfachste Beispiel, das dies ermöglicht, ist das folgende:

```csharp
using System;
using System.Composition;
using System.Threading.Tasks;
using ArchiSteamFarm;
using ArchiSteamFarm.Plugins;

namespace YourNamespace.YourPluginName;

[Export(typeof(IPlugin))]
public sealed class YourPluginName : IPlugin {
	public string Name => nameof(YourPluginName);
	public Version Version => typeof(YourPluginName).Assembly.GetName().Version;

	public Task OnLoaded() {
		ASF.ArchiLogger.LogGenericInfo("Hello World!");

		return Task.CompletedTask;
	}
}
```

Um Ihre Erweiterung verwenden zu können, müssen Sie diese zunächst kompilieren. Sie können das entweder von Ihrer Entwicklungsumgebung aus oder aus dem Stammverzeichnis Ihres Projekts mittels eines Befehls bewältigen:

```shell
# Wenn Ihr Projekt eigenständig ist (es ist nicht notwendig, seinen Namen zu definieren, da es das Einzige ist)
dotnet publish -c "Release" -o "out"

# Falls Ihr Projekt Teil des ASF-Quellbaums ist (um das Kompilieren unnötiger Teile zu vermeiden)
dotnet publish DeinPluginName -c "Release" -o "out"
```

Danach ist Ihre Erweiterung einsatzbereit. Es bleibt Ihnen überlassen, wie genau Sie Ihr Plugin verteilen und veröffentlichen wollen, aber wir empfehlen, ein Zip-Archiv zu erstellen, in dem Sie Ihr kompiliertes Plugin zusammen mit seinen **[Abhängigkeiten](#plugin-dependencies)** ablegen. Auf diese Weise müssen die Benutzer Ihr Zip-Archiv lediglich in ein eigenständiges Unterverzeichnis innerhalb ihres `plugins`-Verzeichnisses entpacken und nichts weiter tun.

Dies ist nur das grundlegendste Szenario, um zu beginnen. Wir haben ein **[`BeispielPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** Projekt, das Ihnen Beispielschnittstellen und Aktionen zeigt, die Sie in Ihrem eigenen Plugin ausführen können, einschließlich hilfreicher Kommentare. Werfen Sie einen Blick darauf, wenn Sie von einem funktionierenden Code lernen möchten, oder entdecken Sie selbst den `ArchiSteamFarm.Plugins`-Bereich und lesen Sie die mitgelieferte Dokumentation für alle verfügbaren Optionen. Im Folgenden werden wir einige Kernkonzepte näher erläutern, um sie besser zu verstehen.

Wenn Sie statt eines Beispiel-Plugins lieber von echten Projekten lernen möchten, gibt es mehrere offizielle Plugins, die von uns entwickelt wurden, z.B. **[`ItemsMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.ItemsMatcher)**, **[`MobileAuthenticator`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.MobileAuthenticator)** oder **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)**. Darüber hinaus gibt es auch Plugins, die von anderen Entwicklern entwickelt wurden, in unserem **[Drittanbieter](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** Bereich.

---

### API Verfügbarkeit

ASF stellt Ihnen neben dem, worauf Sie in den Schnittstellen selbst Zugriff haben, viele seiner internen APIs zur Verfügung, die Sie verwenden können, um die Funktionalität zu erweitern. Wenn Sie etwa eine neue Art einer Steam-Web-Anfrage senden möchten, dann müssen Sie nicht alles von Grund auf neu implementieren; insbesondere nicht all den Problemen, mit denen wir uns vor Ihnen beschäftigt haben. Verwenden Sie einfach unseren `Bot.ArchiWebHandler`, der bereits eine Menge von `UrlWithSession()`-Methoden für Sie bereitstellt, die alle untergeordneten Dinge wie Authentifizierung, Sitzungsaktualisierung oder Web-Limitierung für Sie erledigen. Auch für das Senden von Web-Anfragen außerhalb der Steam-Plattform könnte man die Standard-.NET-Klasse `HttpClient` verwenden, aber es ist eine viel bessere Idee, `Bot.ArchiWebHandler.WebBrowser` zu verwenden, die für Sie zur Verfügung steht, die Ihnen wiederum eine hilfreiche Hand bietet, zum Beispiel in Bezug auf die Wiederholung von fehlgeschlagenen Anfragen.

Wir haben eine sehr offene Politik in Bezug auf unsere API-Verfügbarkeit. Wenn Sie also etwas nutzen möchten, das bereits im ASF-Code enthalten ist, **[eröffnen Sie einfach ein Problem](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** und erklären Sie darin Ihren geplanten Anwendungsfall unserer ASF-internen API. Wir werden höchstwahrscheinlich nichts dagegen haben, solange Ihr Anwendungsfall Sinn ergibt. Dies schließt auch alle Vorschläge in Bezug auf neue „Plugin“-Schnittstellen ein, die sinnvollerweise hinzugefügt werden könnten, um bestehende Funktionen zu erweitern.

Unabhängig von der Verfügbarkeit der ASF-API hält Sie jedoch nichts davon ab, z. B. die Bibliothek „Discord.Net“ in Ihre Anwendung einzubinden und eine Brücke zwischen Ihrem Discord-Bot und ASF-Befehlen zu schlagen, da Ihr Plugin auch eigene Abhängigkeiten haben kann. Die Möglichkeiten sind endlos, und wir haben unser Bestes getan, um Ihnen so viel Freiheit und Flexibilität wie möglich innerhalb Ihres Plugins zu geben, so dass es keine künstlichen Grenzen gibt - Ihr Plugin wird in den ASF-Hauptprozess geladen und kann alles tun, was realistischerweise innerhalb von C#-Code möglich ist.

---

### API Kompatibilität

Es ist wichtig zu betonen, dass ASF eine Verbraucher-Anwendung ist und nicht eine typische Bibliothek mit fester API-Oberfläche, auf die Sie sich bedingungslos verlassen können. Das bedeutet, dass Sie nicht davon ausgehen können, dass Ihr Plugin nach dem Kompilieren dennoch mit allen zukünftigen ASF-Releases arbeitet es ist einfach unmöglich, wenn wir das Programm weiter entwickeln wollen, und nicht in der Lage, sich um der Rückwärtskompatibilität willen an ständig laufende Steamänderungen anzupassen, ist für uns einfach nicht geeignet. Das sollte für Sie logisch sein, aber es ist wichtig, diese Tatsache hervorzuheben.

Wir werden unser Bestes tun, um öffentliche Teile von ASF stabil und funktionsfähig zu halten aber wir haben keine Angst, die Kompatibilität zu stören, wenn genügend Gründe auftreten, folge unseren **[deprecation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation)** Richtlinien im Prozess. Dies ist besonders wichtig im Hinblick auf interne ASF-Strukturen, die Ihnen als Teil der ASF-Infrastruktur (z. `ArchiWebHandler`), das als Teil von ASF-Erweiterungen in einer der zukünftigen Versionen verbessert werden konnte (und daher neu geschrieben werden kann). Wir werden unser Bestes tun, um Sie in den Änderungsprotokollen angemessen zu informieren und während der Laufzeit (runtime) entsprechende Warnungen über veraltete Funktionen zu geben. Wir beabsichtigen nicht alles neu zu schreiben, um es neu zu schreiben, also können Sie ziemlich sicher sein, dass die nächste kleinere ASF-Version Ihre Erweiterung nicht einfach nur deshalb komplett zerstört, weil es eine höhere Versionsnummer hat. Aber es ist eine gute Idee ein Auge auf Änderungsprotokolle zu werfen und gelegentlich zu überprüfen, ob alles einwandfrei funktioniert.

---

### Plugin-Abhängigkeiten

Dein Plugin wird standardmäßig mindestens zwei Abhängigkeiten beinhalten, die `ArchiSteamFarm` Referenz für interne API (`IPlugin` mindestens) und die `PackageReference` von `System. omposition.AttributedModel` das benötigt wird, um als ASF-Plugin erkannt zu werden um mit (`[Export]` Klausel zu beginnen). Darüber hinaus kann es weitere Abhängigkeiten in Bezug auf das beinhalten, was Sie in Ihrem Plugin beschlossen haben (z. . `Discord.Net` Bibliothek, wenn du dich entschieden hast, in Discord zu integrieren).

Die Ausgabe deiner Build wird deine Kern-Bibliothek `YourPluginName.dll` sowie alle Abhängigkeiten beinhalten, auf die du verwiesen hast. Da Sie ein Plugin für bereits funktionierendes Programm entwickeln, müssen Sie es nicht tun und sogar **sollte** Abhängigkeiten beinhalten, die ASF bereits beinhaltet, zum Beispiel `ArchiSteamFarm`, `SteamKit2` oder `AngleSharp`. Das Entfernen von geteilten ASF-Abhängigkeiten in Ihrem Build ist nicht unbedingt erforderlich für die Funktionsfähigkeit einer Erweiterung, aber dies wird den Speicherbedarf, die Größe dieser drastisch reduzieren, und gleichzeitig die Leistung erhöhen; da ASF seine eigenen Abhängigkeiten mit Ihnen teilt und nur die Bibliotheken lädt, die es nicht über sich selbst kennt.

Generell wird empfohlen, nur Bibliotheken einzubinden, die ASF entweder gar nicht oder nur in einer falschen/inkompatiblen Version enthält. Beispiele dafür wären natürlich `YourPluginName.dll`, aber zum Beispiel auch `Discord.Net.dll`, wenn du dich dafür entschieden hast, dich davon zu abhängig zu machen, da ASF es nicht selbst beinhaltet. Bibliotheken, die mit ASF geteilt werden, können immer noch sinnvoll sein, wenn Sie die API-Kompatibilität gewährleisten möchten (z. ist sicher, dass `AngleSharp`, von dem du in deinem Plugin abhängig bist, immer in Version `X` sein wird und nicht in der von ASF mitgelieferten Version), aber dies natürlich für einen Preis für mehr Speicher/Größe und schlechtere Leistung und sollte daher sorgfältig bewertet werden.

Wenn Sie wissen, dass die benötigte Abhängigkeit in ASF enthalten ist, du kannst es mit `IncludeAssets="compile"` markieren, wie wir dir im obigen Beispiel `csproj` gezeigt haben. Dies wird dem Compiler mitteilen, die Veröffentlichung der referenzierter Bibliothek selbst zu vermeiden, da ASF diese bereits beinhaltet. Gleichermaßen Beachten Sie, dass wir das ASF-Projekt mit `ExcludeAssets="all" Private="false"` referenzieren, das auf eine sehr ähnliche Weise funktioniert - indem wir dem Compiler anweisen, keine ASF-Dateien zu erzeugen (wie der Benutzer sie bereits hat). Dies gilt nur, wenn ASF-Projekt referenziert wird. Wenn du eine `dll` Bibliothek referenzierst, dann produziere du keine ASF-Dateien als Teil deines Plugins.

Wenn du über obige Anweisung verwirrt bist und du es nicht besser weißt, überprüfe, welche `dll` Bibliotheken in `ASF-generic` enthalten sind. ip`-Paket und stelle sicher, dass dein Plugin nur diejenigen enthält, die noch nicht Teil davon sind. Dies wird nur `YourPluginName.dll\` für die einfachsten Plugins sein. Fügen Sie auch die betroffenen Bibliotheken hinzu, wenn Sie während der Laufzeit Probleme in Bezug auf einige Bibliotheken. Wenn alles andere fehlschlägt, können Sie sich jederzeit entscheiden, alles zu bündeln.

---

### Native Abhängigkeiten

Native Abhängigkeiten werden als Teil von betriebssystemspezifischen Builds generiert, da auf dem Host keine .NET Runtime verfügbar ist und ASF seine eigene .NET Runtime nutzt, die als Teil des betriebssystemspezifischen Builds gebündelt wird. Um die Größe des Builds zu minimieren, reduziert ASF seine nativen Abhängigkeiten so, dass nur der Programmcode berücksichtigt wird, der innerhalb des Programms erreichbar ist, was die ungenutzten Teile der Laufzeit effektiv reduziert. Dies kann ein potenzielles Problem für dich in Bezug auf dein Plugin verursachen, , wenn Sie plötzlich herausfinden, in einer Situation, in der Ihr Plugin hängt von einigen . ET-Funktion, die nicht in ASF verwendet wird und daher OS-spezifische Builds nicht richtig ausführen können, in der Regel wird `System.MissingMethodException` oder `System.ReflectionTypeLoadException` im Prozess geworfen. Je größer dein Plugin wird und immer komplexer, Früher oder später werden Sie die Oberfläche treffen, die nicht durch unsere OS-spezifische Konstruktion abgedeckt ist.

Dies ist bei generischen Builds nie ein Problem, da es sich hierbei nie um native Abhängigkeiten handelt (da diese die gesamte lauffähige Runtime auf dem Host haben und ASF ausführen). Aus diesem Grund ist es empfehlenswert, **dein Plugin in generischen Builds exklusiv zu benutzen**, aber das hat natürlich seine eigene Kehrseite, Ihr Plugin von Benutzern zu streichen, die OS-spezifische Versionen von ASF verwenden. Falls Sie sich fragen, ob Ihr Problem im Zusammenhang mit nativen Abhängigkeiten steht, können Sie diese Methode auch zur Überprüfung verwenden. Lade Ihre Erweiterung in der generischen ASF Variante und schauen Sie, ob es funktioniert. Wenn dies der Fall ist, sind die Plugin-Abhängigkeiten abgedeckt, sodass native Abhängigkeiten Probleme verursachen.

Wir mussten entscheiden, ob wir die gesamte Laufzeit als Teil unserer OS-spezifischen Builds veröffentlichen oder es von nicht genutzten Funktionen trennen. Das würde die Builds um über 80 MB im Vergleich zu einer vollständigen Version reduzieren. Wir haben die letzte Option ausgewählt, und es ist leider unmöglich für Sie, die fehlenden Laufzeitfunktionen zusammen mit Ihrer Erweiterung hinzuzufügen. Wenn Ihr Projekt Zugriff auf ausgelassene Laufzeitfunktionen benötigt, müssen Sie vollständig einbinden . ET Laufzeit, von der du abhängig bist, und das bedeutet, dass dein Plugin im `generic` ASF flavour ausgeführt wird. Sie können Ihre Erweiterung nicht in OS-spezifischen Builds ausführen, da diese einfach die benötigte Laufzeit-Funktion vermisst, und .NET Runtime ist derzeit nicht in der Lage native Abhängigkeiten „zusammenzuführen“ (unsere zur Verfügung gestellten mit Ihrer). Vielleicht wird es sich eines Tages bessern, aber zum jetzigen Zeitpunkt ist es einfach nicht möglich.

OS-spezifische -Builds von ASF enthalten das Minimum an zusätzlicher Funktionalität, die für unsere offiziellen Erweiterungen erforderlich ist. Abgesehen von dieser Möglichkeit, ergänzt dies auch die Oberfläche leicht um zusätzliche Abhängigkeiten für die grundlegendsten Erweiterungen. Als Konsequenz müssen sich nicht alle Erweiterungen um native Abhängigkeiten kümmern – nur jene, die über das hinausgehen, was ASF (bzw. unsere offiziellen Erweiterungen) direkt benötigen. Dies geschieht als Extra; da wir selbst bereits zusätzliche native Abhängigkeiten für unsere eigenen Anwendungsfälle einbeziehen müssen, können wir diese auch direkt mit ASF bündeln, sodass sie leichter abdeckbar bleiben, auch für Sie. Leider reicht das nicht immer aus; und da Ihre Erweiterung größer und komplexer wird, erhöht sich die Wahrscheinlichkeit, dass sie mit eingeschränkter Funktionalität ausführbar ist. Daher empfehlen wir dir, deine benutzerdefinierten Plugins ausschließlich im `generic` ASF flavour auszuführen. Sie können immer noch manuell überprüfen, ob OS-spezifische ASF-Versionen alles haben, was die Erweiterung für seine Funktionalität benötigt – aber da sich dies sowohl bei Ihren, als auch bei unserem Update ändert, könnte es schwierig sein dieses zu pflegen.

Manchmal ist es möglich, fehlende Funktionen zu "Workaround" entweder durch Verwendung alternativer Optionen oder Reimplementierung in Ihrem Plugin. Dies ist jedoch nicht immer möglich oder praktikabel, insbesondere, wenn die fehlende Funktion aus Abhängigkeiten von Drittanbietern stammt, die Sie als Teil Ihres Plugins einschließen. Du kannst immer versuchen, dein Plugin in OS-spezifischen Build auszuführen und zu versuchen, es funktionieren zu lassen aber es könnte auf lange Sicht zu viel Ärger werden, vor allem wenn Sie wollen, dass von Ihrem Code nur funktioniert, anstatt mit ASF Oberfläche.

---

## Automatische Updates

ASF bietet Ihnen zwei Schnittstellen zur Implementierung automatischer Updates in Ihrem Plugin:

- `IGitHubPluginUpdates` bietet dir die einfache Möglichkeit, GitHub-basierte Updates ähnlich dem allgemeinen ASF-Update-Mechanismus zu implementieren
- `IPluginUpdates` bietet dir eine niedrigere Funktionalität, die einen benutzerdefinierten Update-Mechanismus ermöglicht, wenn du etwas komplexeres benötigst

---

### **[`IGithubPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs)**

Die minimale Checkliste der Dinge, die für Aktualisierungen benötigt werden:

- Sie müssen `RepositoryName` deklarieren, der definiert, woher die Updates gezogen werden.
- Du musst Tags und Releases von GitHub verwenden. Tag muss im Format parsbar sein, um eine Plugin-Version, z.B. `1.0.0.0`.
- `Version` Eigenschaft des Plugins muss dem Tag entsprechen, aus dem es stammt. Das bedeutet, dass Binärdateien unter dem Tag `1.2.3.4` sich als `1.2.3.4` darstellen müssen.
- Jeder Tag sollte eine entsprechende Veröffentlichung auf GitHub mit einer zip-Datei-Release-Datei haben, die Ihre Plug-In-Binärdateien enthält. Die Binärdateien, die deine `IPlugin` Klassen enthalten, sollten im Stammverzeichnis der Zip-Datei verfügbar sein.

Dies wird den Mechanismus in ASF ermöglichen:

- Löse die aktuelle `Version` deines Plugins, z.B. `1.0.1`.
- Verwende GitHub API, um die aktuellste `tag` im `RepositoryName` Repo abzurufen, z.B. `1.0.2`.
- Lege fest, dass `1.0.2` > `1.0.1`, überprüfe die Veröffentlichung des `1.0.2` Tags, um `.zip` Datei mit dem Plugin Update zu finden.
- Lade diese `.zip`-Datei herunter, entpacke sie und lege ihren Inhalt in das Verzeichnis, das `YourPlugin.dll` vorher enthielt.
- Starte ASF neu, um dein Plugin in der `1.0.2` Version zu laden.

Zusätzliche Anmerkungen:

- Plugin-Aktualisierungen können entsprechende ASF-Konfigurationswerte erfordern, nämlich **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)** und/oder **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)**.
- Unsere Plugin-Vorlage enthält bereits alles, was Sie benötigen einfach **[rename](https://github.com/JustArchiNET/ASF-PluginTemplate?tab=readme-ov-file#renaming-myawesomeplugin)** das Plugin zu korrekten Werten, und es wird aus der Box funktionieren.
- Du kannst eine Kombination von neuester Version und Pre-Releases verwenden, die nach `UpdateChannel` des Benutzers verwendet werden.
- Es gibt `CanUpdate` boolesche Eigenschaft, die du überschreiben kannst, um das Update von Plugins auf deiner Seite zu deaktivieren/aktivieren zum Beispiel, wenn Sie Updates vorübergehend überspringen möchten oder aus irgendeinem anderen Grund.
- Es ist möglich, mehrere Zip-Dateien im Release zu haben, wenn Sie verschiedene ASF-Versionen ansprechen möchten. Siehe `GetTargetReleaseAsset()` **[remarks](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IGitHubPluginUpdates.cs#L79-L106)**. Zum Beispiel kannst du `MyPlugin-V6-0.zip` und `MyPlugin.zip` haben, was ASF in Version `V6 verursacht. .x.x` um die erste zu wählen, während alle anderen ASF-Versionen die zweite verwenden.
- Wenn das oben nicht ausreichend, um Sie und Sie benötigen benutzerdefinierte Logik für die Auswahl der richtigen `. ip`-Datei, du kannst die `GetTargetReleaseAsset()` Funktion überschreiben und das Artefakt für ASF zur Verfügung stellen.
- Wenn dein Plugin vor / nach dem Update etwas extra arbeiten muss, kannst du `OnPluginUpdateProceeding()` und/oder `OnPluginUpdateFinished()` Methoden überschreiben.

---

### **[`IPluginUpdates`](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/ArchiSteamFarm/Plugins/Interfaces/IPluginUpdates.cs)**

Diese Schnittstelle erlaubt dir, benutzerdefinierte Logik für Updates zu implementieren, wenn `IGithubPluginUpdates` für dich nicht ausreichend ist zum Beispiel, weil Sie Tags haben, die nicht auf Versionen parsen, oder weil Sie überhaupt keine GitHub Plattform verwenden.

Es gibt eine einzelne `GetTargetReleaseURL()` Funktion, die du überschreiben kannst, die von dir `Uri?` an der Ziel-Plugin-Update-Position erwartet. ASF liefert Ihnen einige Kernvariablen, die sich auf den Kontext beziehen, mit dem die Funktion aufgerufen wurde, aber andere als dasjenige Sie sind dafür verantwortlich, alles, was Sie in dieser Funktion benötigen, zu implementieren und ASF die URL anzugeben, die verwendet werden soll oder "null", wenn das Update nicht verfügbar ist.

Ansonsten ist es ähnlich zu GitHub Updates, wo die URL auf ein `. ip`-Datei mit den Binärdateien, die im Root-Verzeichnis verfügbar sind.