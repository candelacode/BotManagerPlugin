# Weryfikacja dwu-etapowa

Steam zawiera system uwierzytelniania dwuskładnikowego, który wymaga dodatkowych szczegółów dla różnych działań związanych z kontem. Dowiedz się więcej o tym **[tutaj](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** i **[tutaj](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. Ta strona uważa, że system 2FA oraz nasze rozwiązanie, które integruje się z nim, nazywane ASF 2FA.

---

# Logika ASF

Bez względu na to, czy używasz ASF 2FA lub nie, ASF posiada właściwą logikę i jest w pełni świadomy kont chronionych przez 2FA na Steamie. Poprosi Cię o wymagane szczegóły, gdy są potrzebne (np. podczas logowania). Podczas gdy można ręcznie podać te informacje, niektóre funkcje ASF (takie jak `MechActive`) wymagają, aby ASF 2FA działał na Twoim koncie bota, które mogą automatycznie odpowiadać na zapytania 2FA, gdy tylko jest to wymagane przez ASF.

---

# Weryfikacja dwustopniowa ASF

ASF 2FA jest wbudowanym modułem odpowiedzialnym za udostępnianie funkcji 2FA procesowi ASF, takim jak generowanie tokenów i akceptowanie potwierdzeń. Może działać w trybie samodzielnym, lub poprzez duplikowanie istniejących danych uwierzytelniających (tak aby można było użyć jednocześnie swojego obecnego uwierzytelniającego i ASF 2FA).

Możesz sprawdzić, czy Twoje konto bota używa ASF 2FA już wykonując polecenie `2fa` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Bez konfiguracji ASF 2FA, wszystkie standardowe polecenia `2fa` będą nieoperacyjne, co oznacza, że Twój bot jest niedostępny dla zaawansowanych funkcji ASF, które wymagają działania modułu.

---

# Zalecenia

Istnieje wiele sposobów, aby ASF 2FA działał w sposób operacyjny, tutaj zamieszczamy nasze zalecenia w oparciu o obecną sytuację:

- Jeśli używasz już nieoficjalnej aplikacji innych firm, która pozwala na łatwe wypakowywanie szczegółów 2FA, po prostu **[importuj](#import)** do ASF.
- Jeśli używasz oficjalnej aplikacji i nie masz nic przeciwko resetowaniu danych uwierzytelniania 2FA, najlepszym sposobem jest wyłączenie 2FA, następnie **[utwórz](#creation)** nowe poświadczenia 2FA używając **[wspólnego uwierzytelniającego](#joint-authenticator)**, które pozwolą Ci na korzystanie z oficjalnej aplikacji i ASF 2FA. Ta metoda **nie wymaga roota**, więzień ani żadnej zaawansowanej wiedzy, ledwo postępuje zgodnie z instrukcjami tutaj napisanymi i jest prawdopodobnie lepsza dla tego scenariusza.
- Jeśli używasz oficjalnej aplikacji i nie chcesz odtworzyć Twoich danych uwierzytelniania 2FA, twoje opcje są bardzo ograniczone, zwykle będziesz potrzebował roota i dodatkowych plików do **[importuj](#import)** tych szczegółów, a nawet w tym przypadku może być to niemożliwe.
- Jeśli jeszcze nie używasz 2FA i nie dbaj, zalecamy użycie ASF 2FA z **[samodzielnym uwierzytelnianiem](#standalone-authenticator)** lub **[wspólnym uwierzytelniaczem](#joint-authenticator)** z oficjalną aplikacją (tak samo jak powyżej).

Poniżej omawiamy wszystkie możliwe opcje i znane nam metody.

---

## Tworzenie

ASF ma oficjalny `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** , który rozszerza ASF 2FA, pozwalając na połączenie zupełnie nowego uwierzytelniającego 2FA. Może to być przydatne w przypadku, gdy nie jesteś w stanie lub nie chętnie korzystać z innych narzędzi i nie ma nic przeciwko temu, aby ASF 2FA stał się Twoim głównym (i może tylko) uwierzytelniającym. Proces tworzenia jest również wykorzystywany w metodzie współuwierzytelniającej, naturalnie w tym scenariuszu Twój uwierzytelniacz może współistnieć w dwóch miejscach na raz - oba generują te same kody i oba będą w stanie potwierdzić te same potwierdzenia.

### Wspólne kroki dla obu scenariuszy

Bez względu na to, czy planujesz użyć ASF jako samodzielnego lub wspólnego uwierzytelniacza, musisz wykonać te kroki inicjalizacji:

1. Utwórz bota ASF dla konta docelowego, uruchom go i zaloguj się, co prawdopodobnie już zrobiłeś.
2. Przypisz działający i operacyjny numer telefonu do konta **[tutaj](https://store.steampowered.com/phone/manage)** do użycia przez bota. Pozwoli to na otrzymywanie kodu SMS i w razie potrzeby na odzyskiwanie. Ten krok nie jest obowiązkowy we wszystkich scenariuszach, jednak zalecamy go, chyba że wiesz co robisz.
3. Upewnij się, że nie używasz jeszcze 2FA dla swojego konta, jeśli to zrobisz, najpierw go wyłączysz. This **will** put your account on temporary trade-hold, there is no way around it, only **[import](#import)** process can skip it.
4. Wykonaj polecenie `2fainit [Bot]` , zastępując `[Bot]` nazwą bota.

Zakładając, że otrzymali Państwo udaną odpowiedź, zdarzyły się następujące dwie rzeczy:

- Nowy plik `<Bot>.maFile.PENDING` został wygenerowany przez ASF w twoim katalogu `config`.
- SMS został wysłany ze Steam na numer telefonu, który przypisałeś do konta powyżej. Jeśli nie ustawiłeś numeru telefonu, zamiast tego wysłano e-mail na adres e-mail konta.

Szczegóły uwierzytelniające nie są jeszcze operacyjne, jednak możesz przejrzeć wygenerowany plik jeśli chcesz. Jeśli chcesz być podwójnie bezpieczny, możesz na przykład zapisać kod odwołania. Kolejne kroki będą zależeć od wybranego przez Ciebie scenariusza.

### Domyślny uwierzytelniacz

Jeśli chcesz użyć ASF jako głównego (lub nawet tylko) uwierzytelniacza, teraz musisz wykonać ostatni etap zakończenia:

5. Wykonaj polecenie `2fafinalize [Bot] <ActivationCode>` , zastąpienie `[Bot]` nazwą bota i `<ActivationCode>` kodem, który otrzymałeś poprzez SMS lub e-mail w poprzednim kroku.

### Wspólny uwierzytelniacz

Jeśli chcesz mieć ten sam uwierzytelniacz zarówno w ASF, jak i w oficjalnej aplikacji Steam mobilnej, teraz musisz zrobić następne, bardziej skomplikowane kroki:

5. **Ignoruj** SMS lub kod e-mail, które otrzymałeś w poprzednim kroku.
6. Zainstaluj aplikację mobilną Steam, jeśli nie jest jeszcze zainstalowana i otwórz ją. Przejdź do zakładki Steam Guard i dodaj nowego uwierzytelniacza, postępując zgodnie z instrukcjami aplikacji.
7. Po dodaniu i zadziałaniu uwierzytelniającego w aplikacji mobilnej, wróć do ASF. Teraz, zamiast finalizować, musimy tylko poinformować ASF, że aplikacja mobilna już aktywowała nasze wcześniej wygenerowane szczegóły:
 - Poczekaj, aż następny kod 2FA zostanie wyświetlony w aplikacji Steam mobilnej, i użyj polecenia `2fafinalized [Bot] <2FACodeFromApp>` zastępującego `[Bot]` nazwą bota i `<2FACodeFromApp>` kodem, który obecnie widzisz w aplikacji mobilnej Steam - ten sam kod, którego używałbyś do logowania do Steam (**NIE** ten który już użyłeś do aktywacji). Jeśli kod wygenerowany przez ASF i podany kod są takie same, ASF zakłada, że uwierzytelniacz został dodany poprawnie i kontynuuj importowanie nowo utworzonego uwierzytelniacza.
 - Zdecydowanie zalecamy wykonanie powyższych czynników, aby upewnić się, że Twoje dane uwierzytelniające są poprawne. Jeśli jednak nie chcesz (lub nie możesz) sprawdzić, czy kody są takie same i wiesz, co robisz, zamiast tego możesz użyć polecenia `2fafinalizedforce [Bot]`, zastąpienie `[Bot]` nazwą twojego bota. ASF zakłada, że uwierzytelniacz został dodany poprawnie i kontynuuj importowanie nowo utworzonego uwierzytelniacza. Pamiętaj, że ASF w tym trybie nie jest w stanie sprawdzić, czy kody pasują, co oznacza, że możesz zaimportować dane logowania niepoprawne (nie aktywowane).

### Po zakończeniu

Zakładając, że wszystko działało poprawnie, poprzednio wygenerowany plik `<Bot>.maFile.PENDING` został zmieniony na `<Bot>.maFile.NEW`. Oznacza to, że Twoje dane uwierzytelniające 2FA są teraz ważne i aktywne. Zalecamy przeniesienie tego pliku poza katalog `config` i **przechowuj go w bezpiecznym miejscu**. Ponadto jeśli zdecydowałeś się użyć samodzielnego uwierzytelniacza, następnie zalecamy otwarcie pliku w wybranym edytorze i zapisanie `revocation_code`, który pozwoli ci na cofnięcie uwierzytelniania, jak sugeruje nazwa, na wypadek jego utraty. W metodzie współuwierzytelniania, powinieneś był to zrobić już w aplikacji Steam, ale możesz zrobić to samo w razie potrzeby.

W odniesieniu do szczegółów technicznych, wygenerowany `maFile` zawiera wszystkie szczegóły, które otrzymaliśmy z serwera Steam podczas łączenia uwierzytelniacza, i dodatkowo, pole `device_id` , które może być potrzebne innym uwierzytelniaczom (osobom trzecim), jeśli kiedykolwiek zdecydujesz się zaimportować do nich `maFile`.

ASF automatycznie importuje Twój uwierzytelniacz po zakończeniu procedury, i dlatego `2fa` i inne powiązane polecenia powinny teraz działać dla konta bota, z którym połączono uwierzytelniacza. Zalecamy zweryfikowanie tego.

---

## Importowanie

Proces importu wymaga już połączonego i operacyjnego uwierzytelniacza, który jest obsługiwany przez ASF. Dysponujemy instrukcjami dotyczącymi kilku innych oficjalnych i nieoficjalnych źródeł 2FA, oprócz metody ręcznej, która pozwala na samodzielne podanie wymaganych poświadczeń. Pamiętaj, że te instrukcje powinny być używane **tylko** jeśli używasz już danego rozwiązania - ponieważ proces tutaj obejmuje aplikacje i narzędzia firm trzecich, **nie zalecamy używania ich**, a my wspominamy o tym wyłącznie dla osób, które już zdecydowały się z nich korzystać i chcielibyśmy importować wygenerowane szczegóły do ASF 2FA.

Ogólnie rzecz biorąc, proces importu obejmuje upuszczanie `maFile` w odpowiednim formacie do katalogu ASF's `config` w którym ASF pobierze ten plik i automatycznie go usunie ze względów bezpieczeństwa.

Wszystkie następujące przewodniki wymagają od Ciebie aby mieć już **pracujący i operacyjny uwierzytelniacz** używany z danym narzędziem/aplikacją. ASF 2FA nie będzie działać poprawnie, jeśli zaimportujesz nieprawidłowe dane, dlatego upewnij się, że Twój uwierzytelniacz działa poprawnie przed próbą importu. Obejmuje to testy i weryfikację, czy następujące funkcje uwierzytelniające działają poprawnie:
- Możesz wygenerować tokeny i te tokeny są akceptowane przez sieć Steam (możesz się z nimi zalogować)
- Możesz pobrać potwierdzenia i docierają do Twojego uwierzytelniającego urządzenia mobilnego
- Możesz zareagować na te potwierdzenia i są one prawidłowo rozpoznawane przez sieć Steam jako potwierdzone/odrzucone

Upewnij się, że Twój uwierzytelniacz działa poprzez sprawdzenie czy powyższe działania działają - jeśli nie, to również nie będą działać w ASF.

### Smartfon z Androidem

In general for importing authenticator from your Android phone you will need **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))** access. Poniższe instrukcje wymagają od Ciebie dość przyzwoitej wiedzy w świecie modyfikacji Androida, na pewno nie wyjaśnimy każdego kroku tutaj, odwiedź **[XDA](https://xdaforums.com)** i inne zasoby, aby uzyskać dodatkowe informacje/pomoc poniżej.

**Jak dotąd nie wiadomo, potwierdzona metoda ekstrakcji, która nadal funkcjonuje. Możesz spróbować wykonać poniższe kroki, np. z przestarzałą wersją aplikacji, ale nie gwarantujemy, że będzie ona działać poprawnie. Zamiast tego rozważ użycie metody współuwierzytelniania.**

<details>
  <summary>Instrukcje archiwizacji</summary>

Załóżmy, że masz oficjalne **[aplikacja Steam](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** działa i działa (poniżej wymaga rootowania urządzenia):

- Zainstaluj **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** i włącz Zygisk w ustawieniach.
- Zainstaluj **[StrSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (dla Zygisk) i upewnij się, że działa.
- Zainstaluj **[SteamGuardDump](https://github.com/YifePlayte/SteamGuardDump/releases/latest)** lub **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** Utracony moduł i włącz go w utraconych ustawieniach.
- Wymuś zabicie aplikacji Steam, a następnie otwórz ją, szczegóły ochrony Steam powinny być teraz dostępne do kopiowania do schowka.

Teraz, gdy pomyślnie wyodrębniłeś wymagane szczegóły, wyłącz moduł, aby zapobiec automatycznemu kopiowaniu za każdym razem, następnie skopiuj wartość `shared_secret` i `identity_secret` konta, które zamierzasz dodać do ASF 2FA, do nowego pliku tekstowego o poniżej strukturze:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Zastąp każdą wartość `STRING` odpowiednim kluczem prywatnym z wyodrębnionych szczegółów. Once you do that, rename the file to `BotName.maFile`, where `BotName` is the name of your bot you're adding ASF 2FA to, and put it in ASF's `config` directory if you haven't yet.

Uruchom ASF, które powinny zauważyć Twój plik i zaimportować go. Zakładając, że zaimportowałeś poprawny plik z prawidłowymi sekretami, wszystko powinno działać prawidłowo, co można zweryfikować za pomocą poleceń `2fa`. Jeśli popełniłeś błąd, zawsze możesz usunąć `Bot.db` i zacząć w razie potrzeby.

</details>

### SteamDesktopAuthenticator

Jeśli masz już uruchomiony uwierzytelniacz w SDA, powinieneś zauważyć, że jest tam plik `steamID.maFile` dostępny w folderze `maFiles`. Upewnij się, że `maFile` jest w niezaszyfrowanej formie, ponieważ ASF nie może odszyfrować plików SDA - niezaszyfrowana zawartość plików powinna zaczynać się od `{` i kończyć znakiem `}`. W razie potrzeby możesz najpierw usunąć szyfrowanie z ustawień SDA i włączyć je ponownie, gdy skończysz. Gdy plik jest w niezaszyfrowanej formie, skopiuj go do katalogu `config` ASF.

Teraz możesz zmienić nazwę `steamID.maFile` na `BotName. aFile` w katalogu konfiguracyjnym ASF, gdzie `BotName` jest nazwą bota, do którego dodajesz ASF 2FA. Alternatywnie możesz zostawić go w takiej postaci, ASF wybierze go automatycznie po zalogowaniu. Zmiana nazwy pliku pomaga ASF poprzez umożliwienie używania ASF 2FA przed zalogowaniem, jeśli tego nie robisz, wtedy plik może być pobrany tylko po pomyślnym zalogowaniu się ASF (ponieważ ASF nie zna `steamID` Twojego konta przed faktycznym zalogowaniem).

Uruchom ASF, które powinny zauważyć Twój plik i zaimportować go. Zakładając, że zaimportowałeś poprawny plik z prawidłowymi sekretami, wszystko powinno działać prawidłowo, co można zweryfikować za pomocą poleceń `2fa`. Jeśli popełniłeś błąd, zawsze możesz usunąć `Bot.db` i zacząć w razie potrzeby.

### WinAutoryzacja

Po pierwsze stwórz puste pole `BotName. aFile` w katalogu konfiguracyjnym ASF, gdzie `BotName` jest nazwą bota, do którego dodajesz ASF 2FA. Jeśli podasz nieprawidłową nazwę, nie zostanie ona wybrana przez ASF.

Teraz uruchom WinAuth jak zwykle. Kliknij prawym przyciskiem myszy na ikonę Steam i wybierz "Pokaż SteamGuard i kod odzyskiwania". Następnie zaznacz "Zezwalaj na kopiowanie". Powinieneś zwrócić uwagę na strukturę JSON na dole okna, zaczynając od `{`. Skopiuj cały tekst do pliku `BotName.maFile` utworzonego przez Ciebie w poprzednim kroku.

Uruchom ASF, które powinny zauważyć Twój plik i zaimportować go. Zakładając, że zaimportowałeś poprawny plik z prawidłowymi sekretami, wszystko powinno działać prawidłowo, co można zweryfikować za pomocą poleceń `2fa`. Jeśli popełniłeś błąd, zawsze możesz usunąć `Bot.db` i zacząć w razie potrzeby.

### Ręcznie

Jeśli jesteś zaawansowanym użytkownikiem, możesz również ręcznie wygenerować maFile To może być użyte w przypadku, gdy chcesz zaimportować uwierzytelniacz z innych źródeł niż te, które opisaliśmy powyżej. It should have a **[valid JSON structure](https://jsonlint.com)** of:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Standardowe dane uwierzytelniające mają więcej pól - są one całkowicie ignorowane przez ASF podczas importu, ponieważ nie są potrzebne. Nie musisz ich usuwać - ASF wymaga poprawnego JSON z 2 obowiązkowymi polami opisanymi powyżej i zignoruje dodatkowe pola (jeśli występuje). Oczywiście musisz zastąpić `STRING` symbolem zastępczym w przykładzie powyżej poprawnymi wartościami dla Twojego konta. Każdy `STRING` powinien być reprezentacją bajtów zakodowaną przez base64, z którego wykonany jest odpowiedni klucz prywatny.

---

## FAQ

### Jak ASF wykorzystuje moduł 2FA?

Jeżeli ASF 2FA jest dostępny, ASF użyje go do automatycznego potwierdzania transakcji, które są wysyłane/akceptowane przez ASF. Będzie on również w stanie automatycznie generować tokeny 2FA zgodnie z potrzebami, na przykład w celu zalogowania. Ponadto posiadanie ASF 2FA pozwala również na użycie poleceń `2fa`.

### Jak mogę otrzymać token 2FA?

Będziesz potrzebował tokena 2FA, aby uzyskać dostęp do konta zabezpieczonego przed dostępem 2FA, które obejmuje również każde konto z ASF 2FA. Jeśli zdecydowałeś się użyć samodzielnego uwierzytelniacza, powinieneś użyć polecenia `2fa <BotNames>` , aby wygenerować tymczasowy token dla danych instancji bota. We wszystkich innych scenariuszach zalecamy użycie oryginalnego uwierzytelniacza, którego użyłeś, chociaż możesz również użyć komendy jeśli jest dla Ciebie wygodniejsza.

### Czy mogę użyć mojego oryginalnego uwierzytelniającego po zaimportowaniu go jako ASF 2FA?

Tak, Twój oryginalny uwierzytelniacz pozostaje funkcjonalny i możesz go używać razem z ASF 2FA. Pamiętaj jednak, że jeśli unieważnisz go za pomocą dowolnej metody, powiązane dane logowania ASF 2FA nie będą już ważne.

### Jak usunąć ASF 2FA?

Po prostu zatrzymaj ASF i usuń powiązane `BotName.db` z bota połączonego ASF 2FA, który chcesz usunąć. Ta opcja usunie powiązane importowane 2FA z ASF, ale NIE unieważni (odłącz) twojego uwierzytelniacza. Jeśli zamiast tego chcesz unieważnić swój uwierzytelniacz, oprócz usuwania go z ASF (pierwsze), należy odłączyć go w wybranym oryginalnym uwierzytelniaczu. Jeśli nie możesz tego zrobić z jakiegoś powodu, na przykład dlatego, że używasz ASF 2FA w trybie samodzielnym, następnie użyj kodu odwołania, który otrzymałeś podczas konfiguracji, na stronie Steam. Nie jest możliwe unieważnienie uwierzytelniania za pomocą ASF.

### Podłączyłem uwierzytelniacz w aplikacji innej firmy, a następnie zaimportowano do ASF. Czy mogę teraz połączyć je ponownie na swoim telefonie?

**Nr**. To spowoduje unieważnienie wcześniej zaimportowanych danych logowania, a ASF 2FA przestanie działać (generowanie kodów nie jest już akceptowane przez Steam). Najpierw zdecyduj gdzie chcesz zlokalizować oryginalny lub zewnętrzny uwierzytelniacz, a następnie zaimportuj go jako ASF 2FA.

### Używam wspólnego uwierzytelniacza, czy mogę przenieść swoją aplikację do innego telefonu?

**Nr**. Co określa jako "moving" lub "transfering" uwierzytelniacz jest w rzeczywistości równy unieważnieniu starego i przypisaniu nowego w jednym kroku. Pozwala to pominąć np. zbyt długi okres odnowienia w porównaniu z niezależnym wykonywaniem tych dwóch etapów w odniesieniu do ASF, w ten sposób unieważnia dane logowania, które wcześniej wygenerowałeś w ASF, co sprawia, że cały moduł ASF 2FA nie działa.

Zalecaną metodą jest usunięcie uwierzytelniającego całkowicie ze starego telefonu i ponowne użycie metody wspólnego uwierzytelniania na nowym telefonie. Jeśli już przeniosłeś swój uwierzytelniacz, stare dane logowania ASF 2FA są już niepoprawne, więc jedyną pozostałą rzeczą jest usunięcie Twojego "przeniesionego" uwierzytelniającego i ponowne powiązanie nowego uwierzytelniającego za pomocą metody wspólnego uwierzytelnienia.

### Czy korzystanie z ASF 2FA jest lepsze niż uwierzytelnianie zewnętrzne ustawione na akceptowanie wszystkich potwierdzeń?

**Tak**, na kilka sposobów. First and most important one - using ASF 2FA **significantly** increases your security, as ASF 2FA module ensures that ASF will only accept automatically its own confirmations, so even if attacker does request a trade that is harmful, ASF 2FA will **not** accept such trade, as it was not generated by ASF. Poza częścią bezpieczeństwa, użycie ASF 2FA przynosi również korzyści z wydajności/optymalizacji, ponieważ ASF 2FA pobiera i akceptuje potwierdzenia natychmiast po ich wygenerowaniu, i tylko wtedy, w przeciwieństwie do nieskutecznych sondaży w celu potwierdzenia co X minut, co osiąga się za pomocą innych rozwiązań. Nie ma powodu, aby używać uwierzytelniania stron trzecich przez ASF 2FA, jeśli planujesz zautomatyzowanie potwierdzeń generowanych przez ASF - dla tego właśnie jest ASF 2FA, i używanie go nie stoi w sprzeczności z tobą potwierdzając wszystko w wybranym uwierzytelniaczu. Zdecydowanie zalecamy korzystanie z ASF 2FA dla całej aktywności ASF.