# Udostępnianie gier Steam

ASF wspiera współdzielenie Steam Family Sharing - stary i nowy system. Aby zrozumieć, jak ASF współpracuje z tym systemem, najpierw przeczytaj jak **[Steam Family Sharing działa](https://store.steampowered.com/promotion/familysharing)**, który jest dostępny w sklepie Steam. Ponadto sprawdź **[wiadomości](https://store.steampowered.com/news/app/593110/view/4149575031735702628)** o nadchodzący nowy system udostępniania rodziny Steam, z którym ASF jest również kompatybilny.

---

## ASF

Wsparcie dla funkcji udostępniania rodziny Steam w ASF jest przejrzyste, co oznacza, że nie wprowadza żadnych nowych właściwości konfiguracji bota/procesu - wychodzi z pola jako dodatkowa wbudowana funkcjonalność.

ASF zawiera odpowiednią logikę, aby była świadoma tego, że biblioteka jest zablokowana przez użytkowników współdzielonej rodziny, w związku z tym nie będzie „wyrzucać” ich z sesji z powodu rozpoczęcia gry. ASF będzie działać dokładnie tak samo, jak w przypadku rachunku podstawowego posiadającego blokadę, dlatego jeśli ta blokada jest przechowywana przez klienta Steam, lub przez jednego z użytkowników udostępniających rodzinę, ASF nie będzie próbował prowadzić gospodarstwa, a zamiast tego będzie czekać na uwolnienie blokady. Jest to głównie związane ze starym systemem - nowy system pozwala użytkownikom współdzielonej rodziny grać w gry inne niż te, które ASF obecnie uprawia.

Ponadto po zalogowaniu ASF uzyska dostęp do systemów współdzielenia rodziny (starych i nowych), z którego wyodrębni użytkowników (ID zespołu), którzy mogą korzystać z twojej biblioteki. Użytkownicy ci otrzymują uprawnienia `FamilySharing` do używania poleceń **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, zwłaszcza umożliwienie im użycia polecenia `pause~` na koncie bota, które udostępnia im gry, który umożliwia wstrzymanie modułu automatycznego rolniczego kart w celu uruchomienia gry, która może być współdzielona - dotyczy to głównie starego systemu, ale nadal może być używany w nowym systemie w przypadku, gdy ASF jest obecnie grą rolniczą, którą Twoi użytkownicy chcą grać.

Połączenie obu opisanych powyżej funkcji pozwala znajomym `pauza~` proces produkcji kart, rozpocznij grę, graj tak długo, jak tylko sobie tego życzą, a następnie po zakończeniu gry, proces hodowli kart zostanie automatycznie wznowiony przez ASF. Oczywiście wydanie `pause~` nie jest potrzebne, jeśli ASF nie jest obecnie uprawiane w sposób aktywny, ponieważ Twoi znajomi mogą natychmiast uruchomić grę i logika opisana powyżej gwarantuje, że nie zostaną wyrzuceni z sesji.

---

## Ograniczenia

Sieć Steam uwielbia wprowadzać w błąd ASF nadając fałszywe aktualizacje statusu, co może doprowadzić do tego, że ASF wierzy, że wznawia proces i w efekcie zbyt szybko wyrzuci znajomego. To jest dokładnie taki sam problem, jak ten już wyjaśniony przez nas w **[ten wpis](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. Zalecamy dokładnie te same rozwiązania, głównie promuje swoich znajomych dla `Operator` uprawnienie (lub powyżej) i informuje ich o użyciu poleceń `wstrzymaj` i `wznowić`.