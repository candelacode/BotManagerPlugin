# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` jest oficjalną wtyczką ASF **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** opracowaną przez nas, który pozwala Ci przyczynić się do projektu **[SteamDB](https://steamdb.info)** poprzez udostępnianie tokenów pakietów, tokeny aplikacji i klucze depotów, do których Twoje konto Steam ma dostęp. Rozszerzone informacje na temat zebranych danych i dlaczego SteamDB tego potrzebuje, można je znaleźć na stronie SteamDB **[Token Dumper](https://steamdb.info/tokendumper)**. Przedłożone dane nie obejmują żadnych potencjalnie wrażliwych informacji i nie mają żadnego zagrożenia dla bezpieczeństwa/prywatności, jak wskazano w powyższym opisie.

---

## Włączanie wtyczki

ASF jest z `SteamTokenDumperPlugin` połączony z wydaniem, ale sam plugin jest domyślnie wyłączony. Możesz włączyć wtyczkę poprzez ustawienie `SteamTokenDumperPluginEnabled` ASF globalna właściwość konfiguracji `true`, w składni JSON:

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

Po uruchomieniu programu ASF wtyczka poinformuje Cię, czy została włączona za pomocą standardowego mechanizmu logowania ASF. Możesz również włączyć wtyczkę za pomocą naszego generatora konfiguracyjnego internetowego.

---

## Szczegóły techniczne

Po włączeniu wtyczka użyje botów, które używasz w ASF do gromadzenia danych w formie tokenów pakietów, tokeny aplikacji i klucze depotów, do których mają dostęp. Moduł gromadzenia danych obejmuje pasywne i aktywne rutyny, które mają minimalizować dodatkowe koszty ogólne spowodowane gromadzeniem danych.

W celu spełnienia planowanego przypadku użycia oprócz opisanej powyżej rutynowej procedury gromadzenia danych, rutynowe przedłożenie jest inicjalizowane jako odpowiedzialne za określanie, jakie dane muszą być przesyłane do SteamDB okresowo. Ta rutynowa wystrzeli do `1` godziny od rozpoczęcia ASF i będzie powtarzać się co `24` godziny. Wtyczka zrobi wszystko, co w jej mocy, aby zminimalizować ilość danych, które muszą być wysłane, dlatego istnieje możliwość, że niektóre dane, które zechce zebrać wtyczka, zostaną określone jako bezużyteczne do przesłania, i dlatego pominięto (na przykład aktualizację aplikacji, która nie zmienia tokenu dostępu).

Wtyczka używa trwałej bazy pamięci podręcznej zapisanej w `config/SteamTokenDumper.cache` lokalizacji, która służy podobnemu celowi jak `config/ASF.db` dla ASF. Plik jest używany do zapisywania zgromadzonych i przesłanych danych oraz minimalizowania pracy, którą należy wykonać w różnych operacjach ASF. Usunięcie pliku powoduje ponowne uruchomienie procesu od zera, czego w miarę możliwości należy uniknąć.

---

## Dane

ASF zawiera współtwórcę `steamID` we wniosku, który jest określony jako `SteamOwnerID` ustawiony w ASF, lub w przypadku braku identyfikatora Steam bota, który posiada najwięcej licencji. Zapowiedziany współtwórca może otrzymać dodatkowe umiejętności od SteamDB dla ciągłej pomocy (e. . ranga darczyńcy na stronie internetowej), ale to całkowicie zależy od decyzji SteamDB.

W każdym razie personel SteamDB chciałby z góry podziękować za pomoc. Przesłane dane pozwalają SteamDB na działanie, w szczególności na śledzenie informacji o pakietach, aplikacje i magazyny, które nie byłyby już możliwe bez Twojej pomocy.

---

## Komenda

Wtyczka STD zawiera dodatkowe polecenie ASF, `std [Bots]`, który pozwala na odświeżanie i wysyłanie dla wybranych botów na żądanie. Użycie polecenia nie wymaga włączonej konfiguracji, która pozwala na pominięcie automatycznego gromadzenia i wysyłania danych oraz ręczne kontrolowanie procesu. Oczywiście można to również wykonać z włączoną konfiguracją, która po prostu uruchomi zwykłe procedury gromadzenia i przekazywania danych wcześniej niż oczekiwano.

Zalecamy `!std ASF` , aby uruchomić odświeżanie wszystkich dostępnych botów. Możesz jednak wyzwalać go również dla zaznaczonych, jeśli chcesz.

---

## Konfiguracja zaawansowana

Nasza wtyczka obsługuje zaawansowaną konfigurację, która może być przydatna dla ludzi, którzy chcieliby dostosować wewnętrzne ustawienia do swoich preferencji.

Zaawansowana konfiguracja ma następującą strukturę w `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Enabled": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretPackageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Wszystkie opcje zostały wyjaśnione poniżej:

### `Enabled`

`bool` typ z domyślną wartością `false`. Ta właściwość działa tak samo, jak `SteamTokenDumperPluginEnabled` właściwości poziomu roota objaśnionej powyżej i może być użyta, przeznaczone dla ludzi, którzy wolą mieć całą konfigurację związaną z wtyczką w swojej własnej strukturze (najprawdopodobniej dla tych, którzy już używają innych zaawansowanych właściwości opisanych poniżej).

---

### `Sekretne AppID`

`ImmutableHashSet<uint>` typ z domyślną wartością bycia pustym. Ta właściwość określa `appIDs` , których wtyczka nie rozwiąże i jeśli są już rozwiązane, nie przedłoży tokenu. Ta własność może być przydatna dla osób mających dostęp do potencjalnie wrażliwych informacji o nieopublikowanych przedmiotach, zwłaszcza dla deweloperów, wydawców lub zamkniętych beta testerów.

---

### `SecretDepotID`

`ImmutableHashSet<uint>` typ z domyślną wartością bycia pustym. Ta właściwość określa `depotIDs` , których wtyczka nie rozwiąże i jeśli są już rozwiązane, nie przedłoży klucza. Ta własność może być przydatna dla osób mających dostęp do potencjalnie wrażliwych informacji o nieopublikowanych przedmiotach, zwłaszcza dla deweloperów, wydawców lub zamkniętych beta testerów.

---

### `SecretPackageID`

`ImmutableHashSet<uint>` typ z domyślną wartością bycia pustym. Ta właściwość określa `packageIDs` (znany również jako `subIDs`), których wtyczka nie rozwiąże i jeśli są już rozwiązane, nie zostaną przesłane tokeny. Ta własność może być przydatna dla osób mających dostęp do potencjalnie wrażliwych informacji o nieopublikowanych przedmiotach, zwłaszcza dla deweloperów, wydawców lub zamkniętych beta testerów.

---

### `Pomiń AutoGrantPackages`

`bool` typ z domyślną wartością `true`. Ta właściwość działa bardzo podobnie jak `SecretPackageIDs` i gdy włączone, spowoduje, że pakiety z `EPaymentMethod` z `Autograntant` zostaną pominięte podczas postępowania wyjaśnionego poniżej. `AutoGrant` metoda płatności jest używana przez **[Steamworks](https://partner.steamgames.com)** do automatycznego przyznawania pakietów na kontach programistów. Chociaż nie jest to tak wyraźne jak inne opcje `Secret` , i dlatego nie gwarantuje niczego (ponieważ możesz mieć inne pakiety niż `AutoGrant` , których nadal nie chcesz przesyłać), powinno być wystarczająco dobre, aby pominąć większość, jeśli nie wszystkie, tajne pakiety. Ta opcja jest domyślnie włączona, ponieważ ludzie, którzy faktycznie mają dostęp do `AutoGrant` pakiety prawie nigdy nie będą chciały przeciekać do ogółu społeczeństwa, i dlatego użycie wartości `false` jest bardzo sytuacyjne.

---

## Dalsze wyjaśnienia

Na poziomie głównym każde konto Steam posiada zestaw pakietów (licencje, subskrypcje), które są sklasyfikowane przez `packageID` (znany również jako `subID`). Każdy pakiet może zawierać kilka aplikacji sklasyfikowanych przez `appID`. Każda aplikacja może wtedy zawierać kilka magazynów zaklasyfikowanych przez `depotID`.

```text
├── sub/124923
│     ├── app/292030
│     │     ├── depot/292031
│     │     ├── depot/378648
│     │     └── ...
<unk> <unk> <unk> app/378649
<unk> <unk> <unk> <unk> <unk> <unk> <unk> ...
└── ...
```

Nasza wtyczka zawiera dwie rutyny, które uwzględniają pominięte elementy - rutynowe rozwiązywanie i przesyłanie.

Rozwiązanie jest odpowiedzialne za rozwiązanie drzewa, które możesz zobaczyć powyżej. Poprzez wcześniej czarną listę pakietów/aplikacji/magazynów, skutecznie obcinasz drzewo w miejscu na czarnej liście gałęzi/liścia bez konieczności określenia pozostałych jego części. W naszym przykładzie powyżej, jeśli `124923` pakiet został zignorowany, czy przez `SecretPackageIDs` lub `Pomijanie Pakietów`, i był to jedyny pakiet który posiadasz powiązany z aplikacją `292030` , następnie appID `292030` nie zostanie rozwiązany ani z definicji, jeśli nie było innych rozwiązanych aplikacji, które są powiązane z magazynami `292031` i `378648` , wówczas też nie zostaną rozwiązane. Pamiętaj, że jeśli wtyczka rozwiązała już drzewo, to skutecznie zatrzyma to tylko aktualizację danego elementu (np. dodane nowe aplikacje), nie sprawi, że wtyczka "zapomnij" o istniejących elementach, które zostały już rozwiązane (e. . aplikacje znalezione w tym pakiecie, zanim zdecydujesz się na czarną listę). Jeśli właśnie włączyłeś kilka opcji pomijania i chciałbyś upewnić się, że ASF nie przekroczy już rozwiązanego drzewa, możesz rozważyć jednorazowe usunięcie pliku `z konfiguracją SteamTokenDumper. Pamięć podręczna` , w której wtyczka zachowuje pamięć podręczną.

Przesyłanie jest odpowiedzialne za przesyłanie tokenów pakietów, tokenów aplikacji i kluczy deponujących już rozwiązanych elementów (przez powyższą rutynę rozwiązania). Tutaj twoja czarna lista ma natychmiastowe efekty, ponieważ nawet jeśli wtyczka rozwiązała już informacje, procedura przesyłania nie prześle go do SteamDB, jeśli masz go na czarnej liście, niezależnie od tego, czy został rozwiązany czy nie. Pamiętajmy jednak, że nie mówimy już o drzewie w tym momencie, procedura przesyłania nie wie, czy informacje o aplikacji pochodzą z tego czy z tego pakietu, więc tylko pomija informacje o szczególnych, czarnej liście, niezależnie od relacji z innymi.

Dla większości deweloperów i wydawców powinno wystarczyć aby `SkipAutoGrantPackages` był włączony, potencjalnie upoważniony tylko z `SecretPackageIDs` , ponieważ skutecznie obcina drzewo na początku gałęzi i gwarantuje, że włączone aplikacje i magazyny nie będą składowane, dopóki nie ma innego pakietu łączącego się z tą samą aplikacją. Jeśli chcesz być podwójnym pewnym, oprócz tego możesz również użyć `SecretAppIDs`, który pominie rozwiązanie aplikacji, nawet jeśli są jakieś inne licencje, które nie łączyłeś na czarnej liście. Używanie `SecretDepotIDs` nie powinno być potrzebne, chyba że masz szczególne, szczególne potrzeby (np. pominięcie tylko konkretnego magazynu podczas przesyłania informacji o pakietach i aplikacjach), lub jeśli chcesz dodać kolejną warstwę, aby być bezpiecznym potrójnie.