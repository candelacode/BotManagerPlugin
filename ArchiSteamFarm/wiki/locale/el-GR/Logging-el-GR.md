# Σύνδεση

Το ASF σας επιτρέπει να ρυθμίσετε το δικό σας προσαρμοσμένο πρόσθετο καταγραφής που θα χρησιμοποιηθεί κατά τη διάρκεια του χρόνου εκτέλεσης. Μπορείτε να το κάνετε τοποθετώντας ειδικό αρχείο με όνομα `NLog.config` στον κατάλογο της εφαρμογής. Μπορείτε να διαβάσετε ολόκληρη την τεκμηρίωση του NLog στο **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**, αλλά εκτός από αυτό θα βρείτε και μερικά χρήσιμα παραδείγματα.

---

## Προεπιλεγμένη σύνδεση

Από προεπιλογή, το ASF καταγράφει σε `ColoredConsole` (τυπική έξοδο) και `File`. `Αρχείο` καταγραφή περιλαμβάνει `log.txt` αρχείο στον κατάλογο του προγράμματος, και `αρχεία καταγραφής` κατάλογο για αρχειοθετικούς σκοπούς.

Χρησιμοποιώντας προσαρμοσμένες ρυθμίσεις NLog απενεργοποιεί αυτόματα το προεπιλεγμένο μέγεθος ASF, η ρύθμιση σας παρακάμπτει εντελώς το **** προεπιλεγμένο αρχείο καταγραφής ASF, το οποίο σημαίνει ότι αν θέλετε να διατηρήσετε. . Στόχος μας `ColoredConsole` , τότε πρέπει να ορίσετε τον εαυτό σας ****. This allows you to not only add **extra** logging targets, but also disable or modify **default** ones.

Αν θέλετε να χρησιμοποιήσετε την προεπιλεγμένη καταγραφή ASF χωρίς τροποποιήσεις, δεν χρειάζεται να κάνετε τίποτα - δεν χρειάζεται επίσης να το ορίσετε στο προσαρμοσμένο `NLog. onfig`. Για αναφορά, ωστόσο, ισοδύναμο της σκληροκωδικοποιημένης καταγραφής ASF σε προεπιλογή θα είναι:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir:cached=true}/logs/log.txt" archiveOldFileOnStartup="true" archiveSuffixFormat=".{1:yyyyMMdd-HHmmss}" fileName="${currentdir:cached=true}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- Below becomes active when ASF's IPC interface is started -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="File" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- Below becomes active when ASF's IPC interface is enabled -->
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="History" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## Ενσωμάτωση ASF

ASF περιλαμβάνει μερικά ωραία κόλπα κώδικα που ενισχύουν την ενσωμάτωσή του με το NLog, επιτρέποντάς σας να πιάσει συγκεκριμένα μηνύματα πιο εύκολα.

Η μεταβλητή `${logger}` θα διακρίνει πάντα την πηγή του μηνύματος - θα είναι είτε `BotName` ενός από τα bot σας, ή `ASF` εάν το μήνυμα προέρχεται απευθείας από τη διαδικασία ASF. Με αυτόν τον τρόπο μπορείτε εύκολα να πάρετε μηνύματα λαμβάνοντας υπόψη συγκεκριμένο(α) bot(s), ή ASF διαδικασία (μόνο), αντί για όλα αυτά, με βάση το όνομα του καταγραφέα.

Το ASF προσπαθεί να σηματοδοτήσει τα μηνύματα κατάλληλα με βάση τα επίπεδα καταγραφής που παρέχονται από το NLog, whichοι οποίες makes it possible for you to catch only specific messages from specific log levels instead of all of them. Φυσικά, το επίπεδο καταγραφής για συγκεκριμένο μήνυμα δεν μπορεί να προσαρμοστεί, καθώς είναι ASF κωδικοποιημένη απόφαση πόσο σοβαρό είναι το συγκεκριμένο μήνυμα, αλλά σίγουρα μπορείτε να κάνετε το ASF λιγότερο / πιο σιωπηλό, όπως σας φαίνεται κατάλληλο.

Το ASF καταγράφει επιπλέον πληροφορίες, όπως μηνύματα χρήστη/συνομιλίας στο επίπεδο καταγραφής `Trace`. Η προεπιλεγμένη καταγραφή ASF καταγράφει μόνο το επίπεδο `Debug` και παραπάνω, το οποίο αποκρύπτει αυτές τις επιπλέον πληροφορίες, καθώς δεν χρειάζεται για την πλειοψηφία των χρηστών, καθώς και την έξοδο ακαταστατών που περιέχουν δυνητικά πιο σημαντικά μηνύματα. Μπορείτε, ωστόσο, να χρησιμοποιήσετε αυτές τις πληροφορίες ενεργοποιώντας ξανά το επίπεδο καταγραφής `Trace` , ειδικά σε συνδυασμό με τη σύνδεση μόνο ενός συγκεκριμένου bot της επιλογής σας, με συγκεκριμένη εκδήλωση που σας ενδιαφέρει.

Σε γενικές γραμμές, το ASF προσπαθεί να το καταστήσει όσο το δυνατόν πιο εύκολο και βολικό για εσάς, για να καταγράψεις μόνο μηνύματα που θέλεις, αντί να σε αναγκάσεις να το φιλτράρεις χειροκίνητα μέσω εργαλείων τρίτων όπως `grep` και εξίσου. Απλά ρυθμίστε σωστά το NLog όπως γράφεται παρακάτω, και θα πρέπει να είστε σε θέση να καθορίσετε ακόμη και πολύ σύνθετους κανόνες καταγραφής με προσαρμοσμένους στόχους, όπως ολόκληρες βάσεις δεδομένων.

Όσον αφορά την έκδοση - το ASF προσπαθεί να μεταφέρει πάντα με την πιο ενημερωμένη έκδοση του NLog που είναι διαθέσιμη στο **[NuGet](https://www.nuget.org/packages/NLog)** κατά τη στιγμή της απελευθέρωσης του ASF. Δεν πρέπει να είναι πρόβλημα να χρησιμοποιήσετε οποιοδήποτε χαρακτηριστικό που μπορείτε να βρείτε στο NLog wiki στο ASF - απλά βεβαιωθείτε ότι χρησιμοποιείτε επίσης ενημερωμένο ASF.

Ως μέρος της ενσωμάτωσης ASF, η ASF περιλαμβάνει επίσης υποστήριξη για πρόσθετους στόχους καταγραφής ASF NLoging, οι οποίοι θα εξηγηθούν παρακάτω.

---

## Παραδείγματα

Παραδείγματα παρακάτω σας δείχνουν πώς μπορείτε να προσαρμόσετε την καταγραφή σύμφωνα με τις προτιμήσεις σας.

Ως εκκινητής, θα χρησιμοποιήσουμε μόνο τον στόχο **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)**. Το αρχικό μας `NLog.config` θα μοιάζει κάπως έτσι:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Η εξήγηση της παραπάνω ρύθμισης είναι μάλλον απλή - ορίζουμε έναν στόχο **καταγραφής**, ο οποίος είναι `ColoredConsole`, τότε ανακατευθύνουμε **όλους τους καταγραφείς** (`*`) του επιπέδου `Εντοπισμός σφαλμάτων` και υψηλότερο στον στόχο `ColoredConsole` που ορίσαμε νωρίτερα.

Αν ξεκινήσετε το ASF με πάνω από `NLog. onfig` τώρα, μόνο ο στόχος `ColoredConsole` θα είναι ενεργός, και το ASF δεν θα γράψει στο `File`, ανεξάρτητα από τη ρύθμιση παραμέτρων ASF NLog.

Δεδομένου ότι δεν ορίσαμε πολλές ιδιότητες, όπως η διάταξη ``, αρχικοποιήθηκε σε μια προεπιλεγμένη ενσωματωμένη τιμή, σε αυτή την περίπτωση `${longdate}"${level:uppercase=true}"${logger}"${message}`. Μπορούμε να το προσαρμόσουμε, για παράδειγμα καταγράφοντας το μήνυμα μόνο:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Αν εκκινήσετε το ASF τώρα, θα παρατηρήσετε αυτή την ημερομηνία, το επίπεδο και το όνομα καταγραφέα εξαφανίστηκε - αφήνοντάς σας μόνο με μηνύματα ASF σε μορφή `Function() Message`.

Μπορούμε επίσης να τροποποιήσουμε τη ρύθμιση για να συνδεθείτε σε περισσότερους από έναν στόχους. Ας κάνουμε log στο `ColoredConsole` και **[`File`](https://github.com/nlog/nlog/wiki/File-target)** ταυτόχρονα.

```xml
<?xml έκδοση="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Debug" writeTo="File" />
  </rules>
</nlog>
```

Και τελειώσαμε, τώρα θα τα καταγράψουμε όλα σε `ColoredConsole` και `File`. Παρατηρήσατε ότι μπορείτε επίσης να καθορίσετε προσαρμοσμένη `αρχείοΌνομα` και επιπλέον επιλογές?

Τέλος, το ASF χρησιμοποιεί διάφορα επίπεδα καταγραφής, για να σας διευκολύνει να κατανοήσετε τι συμβαίνει. Μπορούμε να χρησιμοποιήσουμε αυτές τις πληροφορίες για την τροποποίηση της καταγραφής σοβαρότητας. Let's say that we want to log everything (`Trace`) to `File`, αλλά μόνο `Προειδοποίηση` και πάνω από **[επίπεδο καταγραφής](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** στο `ColoredConsole`. Μπορούμε να το επιτύχουμε αυτό τροποποιώντας τους κανόνες `μας`:

```xml
<?xml έκδοση="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir:cached=true}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Warn" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Trace" writeTo="File" />
  </rules>
</nlog>
```

Αυτό ήταν, τώρα η `ColoredConsole` μας θα εμφανίζει μόνο προειδοποιήσεις και πιο πάνω, ενώ εξακολουθεί να καταγράφει τα πάντα στο `File`. Μπορείτε να το τροποποιήσετε περαιτέρω για να συνδεθείτε π.χ. μόνο `Πληροφορίες` και κάτω και ούτω καθεξής.

Τέλος, ας κάνουμε κάτι λίγο πιο προχωρημένο και ας καταγράφουμε όλα τα μηνύματα στο αρχείο, αλλά μόνο από το bot που ονομάζεται `LogBot`.

```xml
<?xml έκδοση="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="LogBotFile" fileName="${currentdir:cached=true}/LogBot.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="LogBot" minlevel="Trace" writeTo="LogBotFile" />
  </rules>
</nlog>
```

Μπορείτε να δείτε πώς χρησιμοποιήσαμε την ενσωμάτωση ASF πάνω και εύκολα διακεκριμένη πηγή του μηνύματος με βάση την ιδιοκτησία `${logger}`.

---

## Προηγμένη χρήση

Τα παραπάνω παραδείγματα είναι αρκετά απλά και γίνονται για να σας δείξουν πόσο εύκολο είναι να ορίσετε τους δικούς σας κανόνες καταγραφής που μπορούν να χρησιμοποιηθούν με το ASF. Μπορείτε να χρησιμοποιήσετε το NLog για διάφορα πράγματα, συμπεριλαμβανομένων σύνθετων στόχων (όπως η διατήρηση αρχείων καταγραφής στην βάση δεδομένων ``), περιστροφή αρχείων καταγραφής (όπως αφαίρεση παλαιών αρχείων `` logs), χρησιμοποιώντας προσαρμοσμένο `Layout`s, δηλώνοντας το δικό σας `<when>` φίλτρα καταγραφής και πολλά άλλα. Σας ενθαρρύνω να διαβάσετε ολόκληρη την τεκμηρίωση **[NLog](https://github.com/nlog/nlog/wiki/Configuration-file)** για να μάθετε για κάθε επιλογή που είναι διαθέσιμη σε εσάς, σας επιτρέπει να ρυθμίσετε το πρόσθετο καταγραφής ASF με τον τρόπο που θέλετε. Είναι ένα πολύ ισχυρό εργαλείο και η προσαρμογή της καταγραφής ASF δεν ήταν ποτέ ευκολότερη.

---

## Περιορισμοί

Το ASF θα απενεργοποιήσει προσωρινά **όλους τους κανόνες** που περιλαμβάνουν τους στόχους `ColoredConsole` ή `Console` όταν αναμένετε είσοδο χρήστη. Ως εκ τούτου, αν θέλετε να διατηρήσετε την καταγραφή για άλλους στόχους, ακόμη και όταν το ASF αναμένει την εισαγωγή του χρήστη, θα πρέπει να ορίσετε αυτούς τους στόχους με τους δικούς τους κανόνες, όπως φαίνεται στα παραπάνω παραδείγματα, αντί να βάζετε πολλούς στόχους στο `writeTo` του ίδιου κανόνα (εκτός αν αυτή είναι η επιθυμητή συμπεριφορά σας). Προσωρινή απενεργοποίηση των στόχων κονσόλας γίνεται για να διατηρηθεί η κονσόλα καθαρή κατά την αναμονή για την είσοδο του χρήστη.

---

## Σύνδεση συνομιλίας

ASF includes extended support for chat logging by not only recording all received/sent messages on `Trace` logging level, but also exposing extra info related to them in **[event properties](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Αυτό συμβαίνει επειδή πρέπει να χειριστούμε τα μηνύματα συνομιλίας ως εντολές ούτως ή άλλως, έτσι δεν μας κοστίζει τίποτα να καταγράφουμε αυτά τα γεγονότα για να σας δώσουμε τη δυνατότητα να προσθέσετε επιπλέον λογική (όπως να κάνετε το ASF το προσωπικό αρχείο συνομιλίας Steam σας).

### Ιδιότητες συμβάντος

| Όνομα       | Περιγραφή                                                                                                                                                                                                                                          |
| ----------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Ηχώ         | `τύπος bool`. This is set to `true` when message is being sent from us to the recipient, and `false` otherwise.                                                                                                                                    |
| Μήνυμα      | `string` type. Αυτό είναι το πραγματικό μήνυμα που εστάλησε/λήφθηκε.                                                                                                                                                                               |
| ChatGroupID | `ulong` type. Αυτό είναι το ID της ομαδικής συνομιλίας για απεσταλμένα/ληφθέντα μηνύματα. Θα είναι `0` όταν δεν χρησιμοποιείται καμία ομαδική συνομιλία για τη μετάδοση αυτού του μηνύματος.                                                       |
| Συνομιλία   | `ulong` type. Αυτό είναι το ID του καναλιού `ChatGroupID` για τα απεσταλμένα/ληφθέντα μηνύματα. Θα είναι `0` όταν δεν χρησιμοποιείται καμία ομαδική συνομιλία για τη μετάδοση αυτού του μηνύματος.                                                 |
| SteamID     | `ulong` type. Αυτό είναι το ID του χρήστη Steam για τα απεσταλμένα/ληφθέντα μηνύματα. Μπορεί να είναι `0` όταν κανένας συγκεκριμένος χρήστης δεν εμπλέκεται στη μετάδοση μηνυμάτων (π. χ. . όταν μας στέλνει ένα μήνυμα σε μια ομαδική συνομιλία). |

### Παράδειγμα

Αυτό το παράδειγμα βασίζεται στο βασικό παράδειγμα `ColoredConsole`. Πριν προσπαθήσετε να το καταλάβετε, Συστήνω ανεπιφύλακτα να ρίξετε μια ματιά **[πάνω από](#examples)** για να μάθετε πρώτα για τα βασικά στοιχεία της καταγραφής NLoging.

```xml
<?xml έκδοση="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="ChatLogFile" fileName="${currentdir:cached=true}/logs/chat/${event-properties:item=ChatGroupID}-${event-properties:item=ChatID}${when:when='${event-properties:item=ChatGroupID}' == 0:inner=-${event-properties:item=SteamID}}.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss} ${event-properties:item=Message} ${when:when='${event-properties:item=Echo}' == true:inner=-&gt;:else=&lt;-} ${event-properties:item=SteamID}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="MainAccount" level="Trace" writeTo="ChatLogFile">
      <filters defaultAction="Log">
        <when condition="not starts-with('${message}','OnIncoming') and not starts-with('${message}','SendMessage')" action="Ignore" />
      </filters>
    </logger>
  </rules>
</nlog>
```

Ξεκινήσαμε από το βασικό παράδειγμα `ColoredConsole` και επεκτείναμε περαιτέρω. Πρώτα και κύρια, έχουμε ετοιμάσει ένα μόνιμο αρχείο καταγραφής συνομιλίας ανά ομαδικό κανάλι και χρήστη Steam - αυτό είναι δυνατό χάρη σε επιπλέον ιδιότητες που το ASF μας εκθέτει με φανταχτερό τρόπο. Αποφασίσαμε επίσης να πάμε με μια προσαρμοσμένη διάταξη που γράφει μόνο την τρέχουσα ημερομηνία, το μήνυμα, απεστάλη/έλαβε πληροφορίες και τον ίδιο τον χρήστη Steam. Τέλος, έχουμε ενεργοποιήσει τον κανόνα καταγραφής συνομιλίας μόνο για επίπεδο `Trace` , μόνο για το bot `MainAccount` και μόνο για λειτουργίες που σχετίζονται με την καταγραφή συνομιλίας (`OnIncoming*` που χρησιμοποιείται για τη λήψη μηνυμάτων και ηχών, και `SendMessage*` για αποστολή μηνυμάτων ASF).

Το παραπάνω παράδειγμα θα δημιουργήσει αρχείο `logs/chat/0-0-76561198069026042.txt` όταν μιλάτε με **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 πώς κάνετε? -> 76561198069026042
2018-07-26 01:38:38 Είμαι πολύ καλή, πώς για εσάς? <- 76561198069026042
```

Φυσικά, αυτό είναι απλά ένα παράδειγμα εργασίας με μερικά ωραία κόλπα διάταξη έδειξε με πρακτικό τρόπο. Μπορείτε να επεκτείνετε περαιτέρω αυτή την ιδέα στις δικές σας ανάγκες, όπως επιπλέον φιλτράρισμα, προσαρμοσμένη παραγγελία, προσωπική διάταξη, καταγραφή μόνο ληφθέντων μηνυμάτων και ούτω καθεξής.

### Ένα άλλο παράδειγμα

This one uses `SteamTarget` in order to send a message to the main bot's steamID (`76561198006963719`) when bot named `archi` receives a donation trade . Απαιτεί ένα άλλο bot στη διαδικασία (αφού δεν μπορείτε να στείλετε μηνύματα στον εαυτό σας).

```xml
<?xml έκδοση="1. " encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" />
  </targets>

  <rules>
    <logger name="archi" level="Trace" writeTo="Steam">
      <filters defaultAction="Ignore">
        <when condition="starts-with('${message}','ParseTrade() Accepted donation trade: ')" action="Log" />
      </filters>
    </logger>
  </rules>
</nlog>
```

---

## Στόχοι ASF

Εκτός από τους τυπικούς στόχους καταγραφής NLog (όπως το αρχείο `ColoredConsole` και `` που εξηγείται παραπάνω), μπορείτε επίσης να χρησιμοποιήσετε προσαρμοσμένους στόχους καταγραφής ASF.

Για μέγιστη πληρότητα, ο ορισμός των στόχων ASF θα ακολουθήσει τη σύμβαση τεκμηρίωσης NLog.

---

### SteamTarget

Όπως μπορείτε να μαντέψετε, ο στόχος αυτός χρησιμοποιεί μηνύματα συνομιλίας Steam για την καταγραφή μηνυμάτων ASF. Μπορείτε να το ρυθμίσετε ώστε να χρησιμοποιεί είτε μια ομαδική συνομιλία είτε ιδιωτική συνομιλία. Εκτός από τον καθορισμό ενός στόχου Steam για τα μηνύματά σας, μπορείτε επίσης να καθορίσετε `botName` του bot που υποτίθεται ότι τα στέλνει.

Υποστηρίζεται σε όλα τα περιβάλλοντα που χρησιμοποιούνται από το ASF.

---

#### Σύνταξη Ρυθμίσεων
```xml
<targets>
  <target type="Steam"
          name="String"
          layout="Layout"
          chatGroupID="Ulong"
          steamID="Ulong"
          botName="Layout" />
</targets>
```

Διαβάστε περισσότερα για τη χρήση του [Αρχείο διαμόρφωσης](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Παράμετροι

##### Γενικές Επιλογές
_όνομα_ - Όνομα του στόχου.

---

##### Επιλογές Διάταξης
_διάταξη_ - Κείμενο που θα εμφανιστεί. Απαιτείται [Διάταξη](https://github.com/NLog/NLog/wiki/Layouts). Προεπιλογή: `${level:uppercase=true}"${logger}"${message}`

---

##### Επιλογές SteamTarget

_chatGroupID_ - ID της ομαδικής συνομιλίας που δηλώθηκε ως 64-bit μη υπογεγραμμένος ακέραιος. Δεν απαιτείται. Από προεπιλογή σε `0` που θα απενεργοποιήσει τη λειτουργία ομαδικής συνομιλίας και θα χρησιμοποιήσει ιδιωτική συνομιλία. When enabled (set to non-zero value), `steamID` property below acts as `chatID` and specifies ID of the channel in this `chatGroupID` that the bot should send messages to.

_steamID_ - Το SteamID έχει δηλωθεί ως 64-bit μη υπογεγραμμένος ακέραιος αριθμός χρηστών του Steam προορισμού (όπως `SteamOwnerID`) ή ο στόχος `chatID` (όταν `chatGroupID` έχει οριστεί). Απαιτείται. Από προεπιλογή σε `0` που απενεργοποιεί πλήρως τον στόχο καταγραφής.

_botName_ - Όνομα του bot (όπως αναγνωρίζεται από το ASF, διάκριση πεζών-κεφαλαίων) που θα στέλνει μηνύματα στο `steamID` που δηλώνονται παραπάνω. Δεν απαιτείται. Προεπιλογές στο `null` το οποίο θα επιλέξει αυτόματα **οποιοδήποτε** συνδεδεμένο αυτή τη στιγμή. Συνιστάται να ορίσετε αυτήν την τιμή κατάλληλα, καθώς το `SteamTarget` δεν λαμβάνει υπόψη πολλούς περιορισμούς Steam, όπως το γεγονός ότι πρέπει να έχετε `steamID` του στόχου στη λίστα φίλων σας. Αυτή η μεταβλητή ορίζεται ως τύπος [διάταξης](https://github.com/NLog/NLog/wiki/Layouts) , επομένως μπορείτε να χρησιμοποιήσετε ειδική σύνταξη σε αυτήν, όπως `${logger}` για να χρησιμοποιήσετε το bot που δημιούργησε το μήνυμα.

---

#### Παραδείγματα SteamTarget

Για να γράψετε όλα τα μηνύματα του επιπέδου `Debug` και παραπάνω, από bot με το όνομα `MyBot` στο ατμόπλοιο `76561198006963719`, θα πρέπει να χρησιμοποιήσετε `NLog. onfig` παρόμοια με παρακάτω:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**Ειδοποίηση:** Το `SteamTarget` είναι προσαρμοσμένος στόχος, οπότε θα πρέπει να βεβαιωθείτε ότι το δηλώνετε ως `type="Steam"`, ΟΧΙ `xsi:type="Steam"`, καθώς το xsi προορίζεται για επίσημους στόχους που υποστηρίζονται από το NLog.

Όταν εκκινήσετε το ASF με `NLog. onfig` παρόμοια με τα παραπάνω, `MyBot` θα ξεκινήσει την αποστολή μηνυμάτων `76561198006963719` χρήστης Steam με όλα τα συνηθισμένα μηνύματα καταγραφής ASF. Λάβετε υπόψη ότι το `MyBot` πρέπει να συνδεθεί για να στείλει μηνύματα, ώστε όλα τα αρχικά μηνύματα ASF που συνέβησαν πριν το bot μας να μπορεί να συνδεθεί στο δίκτυο Steam, να μην προωθηθούν.

Φυσικά, `SteamTarget` έχει όλες τις τυπικές λειτουργίες που θα μπορούσατε να περιμένετε από το γενικό `TargetWithLayout`, ώστε να μπορείτε να το χρησιμοποιήσετε σε συνδυασμό με e. . προσαρμοσμένες διατάξεις, ονόματα ή προχωρημένους κανόνες καταγραφής. Το παραπάνω παράδειγμα είναι μόνο το βασικότερο.

---

#### Στιγμιότυπα οθόνης

![Στιγμιότυπο οθόνης](https://i.imgur.com/5juKHMt.png)

---

#### Προσοχή

Να είστε προσεκτικοί όταν αποφασίσετε να συνδυάσετε το επίπεδο καταγραφής `Debug` ή κάτω από το επίπεδο καταγραφής `SteamTarget` με το `steamID` που συμμετέχει στη διαδικασία ASF. Αυτό μπορεί να οδηγήσει σε πιθανή `StackOverflowException` επειδή θα δημιουργήσετε έναν άπειρο βρόχο του ASF που θα λαμβάνει δεδομένο μήνυμα, έπειτα η σύνδεση μέσω του Steam, με αποτέλεσμα ένα άλλο μήνυμα που πρέπει να καταγραφεί. Επί του παρόντος, η μόνη δυνατότητα για αυτό να συμβεί είναι να συνδεθείτε επίπεδο `Trace` (όπου το ASF καταγράφει τα δικά του μηνύματα συνομιλίας), ή επίπεδο `Αποσφαλμάτωσης` ενώ εκτελείται επίσης το ASF σε λειτουργία `Debug` (όπου το ASF καταγράφει όλα τα πακέτα Steam).

Εν ολίγοις, αν το `steamID` σας συμμετέχει στην ίδια διαδικασία ASF, τότε το επίπεδο καταγραφής `minlevel` του `SteamTarget` θα πρέπει να είναι `Πληροφορίες` (ή `Debug` αν επίσης δεν εκτελείτε το ASF σε λειτουργία `Debug` ) και παραπάνω. Εναλλακτικά μπορείτε να ορίσετε τα δικά σας φίλτρα `<when>` προκειμένου να αποφύγετε τον άπειρο βρόχο καταγραφής, εάν το επίπεδο τροποποίησης δεν είναι κατάλληλο για την περίπτωσή σας. Αυτό το caveat ισχύει επίσης για ομαδικές συνομιλίες.

---

### HistoryTarget

Αυτός ο στόχος χρησιμοποιείται εσωτερικά από το ASF για την παροχή ιστορικού καταγραφής σταθερού μεγέθους στο τελικό σημείο `/Api/NLog` του **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** το οποίο στη συνέχεια καταναλώνεται από το ASF-ui και άλλα εργαλεία. Γενικά θα πρέπει να ορίσετε αυτόν τον στόχο μόνο αν χρησιμοποιείτε ήδη προσαρμοσμένη ρύθμιση NLog για άλλες προσαρμογές και θέλετε επίσης το αρχείο καταγραφής να εκτεθεί στο ASF API, e. . για το ASF-ui. Μπορεί επίσης να δηλωθεί όταν θέλετε να τροποποιήσετε την προεπιλεγμένη διάταξη ή `maxCount` των αποθηκευμένων μηνυμάτων.

Υποστηρίζεται σε όλα τα περιβάλλοντα που χρησιμοποιούνται από το ASF.

---

#### Σύνταξη Ρυθμίσεων
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Διαβάστε περισσότερα για τη χρήση του [Αρχείο διαμόρφωσης](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Παράμετροι

##### Γενικές Επιλογές
_όνομα_ - Όνομα του στόχου.

---

##### Επιλογές Διάταξης
_διάταξη_ - Κείμενο που θα εμφανιστεί. Απαιτείται [Διάταξη](https://github.com/NLog/NLog/wiki/Layouts). Προεπιλογή: `${date:format=yyyy-MM-dd HH\:mm\:ss}"${processname}-${processid}"${level:uppercase=true}${logger}"${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### Επιλογές HistoryTarget

_maxCount_ - Μέγιστη ποσότητα αποθηκευμένων αρχείων καταγραφής για ιστορικό κατά παραγγελία. Δεν απαιτείται. Προεπιλογές στο `20` που είναι μια καλή ισορροπία για την παροχή του αρχικού ιστορικού, ενώ εξακολουθεί να έχει κατά νου τη χρήση μνήμης που βγαίνει από τις απαιτήσεις αποθήκευσης. Πρέπει να είναι μεγαλύτερη από `0`.