# Zabezpieczenia

## Szyfrowanie

ASF obsługuje obecnie następujące metody szyfrowania jako definicję `ECryptoMethod`:

| Wartość | Nazwa                       |
| ------- | --------------------------- |
| 0       | Zwykły tekst                |
| 1       | AES                         |
| 2       | ProtectedDataForCurrentUser |
| 3       | EnvironmentVariable         |
| 4       | Plik                        |

Dokładny opis i porównanie są dostępne poniżej.

### Ustawienia

In order to generate encrypted password, e.g. for `SteamPassword` usage, you should execute `encrypt` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** with the appropriate encryption that you chose and your original plain-text password. Afterwards, put the encrypted string that you've got as `SteamPassword` bot config property, and finally change `PasswordFormat` to the one that matches your chosen encryption method. Some formats do not require `encrypt` command, for example `EnvironmentVariable` or `File`, just put appropriate path for them.

---

### `Zwykły tekst`

This is the most simple and insecure way of storing a password, defined as `ECryptoMethod` of `0`. ASF expects the string to be a plain text - a password in its direct form. It's the easiest one to use, and 100% compatible with all the setups, therefore it's a default way of storing secrets, totally insecure for safe storage.

---

### `AES`

Considered secure by today standards, **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** way of storing the password is defined as `ECryptoMethod` of `1`. ASF expects the string to be a **[base64-encoded](https://en.wikipedia.org/wiki/Base64)** sequence of characters resulting in AES-encrypted byte array after translation, which then should be decrypted using included **[initialization vector](https://en.wikipedia.org/wiki/Initialization_vector)** and ASF encryption key.

The method above guarantees security as long as attacker doesn't know ASF encryption key which is being used for decryption as well as encryption of passwords. ASF allows you to specify key via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, which you should use for maximum security. If you decide to omit it, ASF will use its own key which is **known** and hardcoded into the application, meaning anybody can reverse the ASF encryption and get decrypted password. It still requires some effort and is not that easy to do, but possible, that's why you should almost always use `AES` encryption with your own `--cryptkey` which is kept in secret. AES method used in ASF provides security that should be satisfying and it's a balance between simplicity of `PlainText` and complexity of `ProtectedDataForCurrentUser`, but it's highly recommended to use it with custom `--cryptkey`.

Jeśli używane są poprawnie (długie, niestandardowe `--cryptkey`), gwarantuje bardzo wysokie bezpieczeństwo bezpiecznej pamięci.

---

### `ProtectedDataForCurrentUser`

Zagwarantowano dziś normy, **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** sposób przechowywania hasła jest zdefiniowany jako `ECryptoMethod` of `2`. Główną zaletą tej metody jest jednocześnie największa wada, zamiast używać klucza szyfrowania (jak w `AES`), dane są szyfrowane przy użyciu danych logowania aktualnie zalogowanego użytkownika, co oznacza, że można odszyfrować dane **tylko** na urządzeniu, na którym był zaszyfrowany, i dodatkowo **tylko** przez użytkownika, który wydał szyfrowanie.

Gwarantuje to, że nawet jeśli wyślesz cały swój `Bot. syn` z zaszyfrowanym `SteamPassword` za pomocą tej metody do kogoś innego, nie będą w stanie odszyfrować hasła bez bezpośredniego dostępu do komputera. Jest to doskonały środek bezpieczeństwa, ale jednocześnie ma poważne wady, ponieważ jest on najmniej kompatybilny, ponieważ hasło zaszyfrowane przy użyciu tej metody będzie niekompatybilne z każdym innym użytkownikiem, jak również z maszyną - w tym z **własnym** , jeśli zdecydujesz się. . ponownie zainstaluj swój system operacyjny. Jest to metoda zalecana, jeśli nie musisz mieć dostępu do swoich konfiguracji z innego komputera niż własny, i nie wymagasz kompatybilności międzymaszynowej.

**Pamiętaj, że ta opcja jest dostępna tylko dla maszyn z systemem Windows od teraz.**

---

### `EnvironmentVariable`

Pamięć oparta na pamięci zdefiniowana jako `ECryptoMethod` z `3`. ASF przeczyta hasło ze zmiennej środowiskowej o podanej nazwie w polu hasła (np. `SteamPassword`). Na przykład ustawienie `SteamPassword` na `ASF_PASSWORD_MYACCOUNT` i `PasswordFormat` do `3` sprawi, że ASF oceni zmienną środowiskową `${ASF_PASSWORD_MYACCOUNT}` i wykorzysta dowolną zmienną przypisaną do niego jako hasło do konta.

Pamiętaj, aby zagwarantować, że zmienne środowiskowe procesu ASF nie są dostępne dla nieupoważnionych użytkowników, ponieważ podważa to cały cel stosowania tej metody.

---

### `Plik`

Pamięć oparta na plikach (prawdopodobnie poza katalogiem konfiguracji ASF) zdefiniowana jako `ECryptoMethod` of `4`. ASF odczyta hasło ze ścieżki pliku określonej w polu hasła (np. `SteamPassword`). Podana ścieżka może być bezwzględna lub względna do lokalizacji "domu" ASF (folder z katalogiem `config` wewnątrz, uwzględniając `--path` **[argument wiersza poleceń](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). Ta metoda może być użyta na przykład z **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**, które tworzą takie pliki do użycia, ale mogą być również używane poza Dockerem, jeśli sam stworzysz odpowiedni plik. Na przykład, ustaw `Hasło SteamPassword` na `/etc/secrets/MyAccount. ass` i `PasswordFormat` do `4` spowoduje, że ASF przeczytuje `/etc/secrets/MyAccount. Przekaż` i użyj cokolwiek zostanie napisane do tego pliku jako hasło do konta.

Pamiętaj, aby plik zawierający hasło nie był czytelny przez nieupoważnionych użytkowników, ponieważ narusza to cały cel stosowania tej metody.

---

## Encryption recommendations

Jeśli kompatybilność nie jest dla Ciebie problemem, i jesteś w porządku, w jaki sposób działa metoda `ProtectedDataForCurrentUser` , jest to opcja **rekomendowana** polegająca na przechowywaniu hasła w ASF, ponieważ zapewnia najlepsze bezpieczeństwo i wygodę. Metoda `AES` jest dobrym wyborem dla ludzi, którzy nadal chcą korzystać ze swoich konfiguracji na dowolnych maszynach, których chcą, podczas gdy `PlainText` jest najprostszym sposobem przechowywania hasła, jeśli nie masz nic przeciwko temu, że ktokolwiek może spojrzeć na plik konfiguracyjny JSON.

Pamiętaj, że wszystkie metody szyfrowania są uważane za **niezabezpieczone** , jeśli atakujący ma dostęp do Twojego komputera. ASF musi być w stanie odszyfrować zaszyfrowane hasła i jeśli program uruchomiony na twoim komputerze jest w stanie to zrobić, wtedy każdy inny program uruchomiony na tej samej maszynie również będzie w stanie to zrobić. `ProtectedDataForCurrentUser` jest najbardziej bezpiecznym wariantem, jak **nawet inny użytkownik korzystający z tego samego komputera nie będzie w stanie odszyfrować go**, ale nadal możliwe jest odszyfrowanie danych, jeśli ktoś jest w stanie ukradnąć Twoje dane logowania i informacje maszynowe oprócz pliku konfiguracyjnego ASF.

Dla zaawansowanych ustawień można użyć `EnvironmentVariable` i `File`. Mają ograniczone możliwości użytkowania, `EnvironmentVariable` będzie dobrym pomysłem, jeśli wolisz uzyskać hasło poprzez jakieś niestandardowe rozwiązanie i przechowywać je wyłącznie w pamięci, podczas gdy `Plik` jest dobry na przykład z **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. Obydwa są jednak niezaszyfrowane, więc w zasadzie przenosisz ryzyko z pliku konfiguracyjnego ASF do tego, co wybierzesz spośród tych dwóch.

Oprócz metod szyfrowania określonych powyżej, możliwe jest również uniknięcie całkowitego określenia haseł, na przykład jako `SteamPassword` używając pustego ciągu znaków lub wartości `null`. ASF zapyta Cię o hasło, gdy jest to wymagane, i nie zapisze go nigdzie ale zachowa w pamięci aktualnie uruchomionego procesu, dopóki go nie zamkniesz. będąc najbardziej bezpieczną metodą radzenia sobie z hasłami (nie są one nigdzie zapisywane), jest również najbardziej problematyczna, ponieważ musisz wprowadzić hasło ręcznie przy każdym uruchomieniu ASF (gdy jest wymagany). Jeśli nie jest to dla Ciebie problem, to jest to najlepszy zakład, ponieważ nie możesz przeciekać czegoś, co nie istnieje.

---

## Odszyfrowywanie

ASF nie obsługuje żadnego sposobu odszyfrowania już zaszyfrowanych haseł, ponieważ metody odszyfrowania są używane tylko wewnętrznie do dostępu do danych wewnątrz procesu. Jeśli chcesz przywrócić procedurę szyfrowania, np. aby przenieść ASF na inną maszynę podczas używania `ProtectedDataForCurrentUser`, a następnie powtórzyć procedurę od początku w nowym środowisku.

---

## Hashing

ASF obecnie obsługuje następujące metody haszowania jako definicję `EHashingMethod`:

| Wartość | Nazwa        |
| ------- | ------------ |
| 0       | Zwykły tekst |
| 1       | SCrypt       |
| 2       | Pbkdf2       |

Dokładny opis i porównanie są dostępne poniżej.

### Ustawienia

In order to generate a hash, e.g. for `IPCPassword` usage, you should execute `hash` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** with the appropriate hashing method that you chose and your original plain-text password. Następnie umieść hashowany ciąg tekstowy, który masz jako `IPCPassword` właściwość konfiguracji ASF, i ostatecznie zmień `IPCPasswordFormat` na taki, który pasuje do wybranej przez Ciebie metody haszowania.

---

### `Zwykły tekst`

Jest to najbardziej prosty i niebezpieczny sposób hashowania hasła, zdefiniowany jako `EHashingMethod` of `0`. ASF wygeneruje skrót pasujący do oryginalnego wejścia. Najłatwiejsze do użycia i w 100% kompatybilne z wszystkimi ustawieniami, dlatego jest to domyślny sposób przechowywania tajemnic, całkowicie niezabezpieczony dla bezpiecznego przechowywania.

---

### `SCrypt`

Zagwarantowano dziś normy, **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** sposób hashowania hasła jest zdefiniowany jako `EHashingMethod` of `1`. ASF użyje implementacji `SCrypt` używając bloków `8` , `8192` iteracje, `32` skrót i klucz szyfrowania jako sól do generowania tablicy bajtów. The resulting bytes will then be encoded as **[base64](https://en.wikipedia.org/wiki/Base64)** string.

ASF allows you to specify salt for this method via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, which you should use for maximum security. If you decide to omit it, ASF will use its own key which is **known** and hardcoded into the application, meaning hashing will be less secure.

Jeśli używane są poprawnie (niestandardowa sola, długie hasło), gwarantuje bardzo wysokie bezpieczeństwo bezpiecznego przechowywania.

---

### `Pbkdf2`

Słabe do dzisiejszych standardów, **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** sposób hashowania hasła jest zdefiniowany jako `EHashingMethod` of `2`. ASF użyje implementacji `Pbkdf2` używając iteracji `10000` , `32` długość hashu i klucz szyfrowania jako sola, z `SHA-256` jako algorytm hmac. Otrzymane bajty zostaną następnie zakodowane jako ciąg **[base64](https://en.wikipedia.org/wiki/Base64)**.

ASF pozwala określić sól dla tej metody poprzez `--cryptkey` **[argument linii poleceń](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, których należy użyć dla maksymalnego bezpieczeństwa. Jeśli zdecydujesz się pominąć, ASF użyje własnego klucza, który jest **znany** i jest sprzężony z aplikacją, hashowanie będzie mniej bezpieczne.

---

## Hashing recommendations

Jeśli chcesz użyć metody hashowania do przechowywania niektórych sekretów, takich jak `IPCPassword`, zalecamy używanie `SCrypt` z niestandardową solą, ponieważ zapewnia bardzo przyzwoite zabezpieczenie przed brutalnymi próbami wymuszania.

`Pbkdf2` jest oferowany tylko ze względów zgodności, głównie dlatego, że mamy już sprawne (i potrzebne) wdrożenie go w odniesieniu do innych przypadków użycia na platformie Steam (e. . kręgosłupy rodzicielskie). Jest nadal uważany za bezpieczny, ale słaby w porównaniu z alternatywami (np. `SCrypt`).