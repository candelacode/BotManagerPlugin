# Konfiguracja pod zwiększoną wydajność

Jest to dokładnie przeciwieństwo **[niska pamięć konfiguracja](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** i zazwyczaj chcesz postępować zgodnie z tymi wskazówkami, jeśli chcesz zwiększyć wydajność ASF (pod względem prędkości procesora), potencjalnych kosztów zwiększonego wykorzystania pamięci.

---

ASF już teraz stara się preferować wyniki w odniesieniu do ogólnego wyważonego dostosowania, w związku z tym niewiele można zrobić, aby jeszcze bardziej zwiększyć jego wyniki, chociaż nie jesteś całkowicie poza możliwościami. Należy jednak pamiętać, że te opcje nie są domyślnie włączone, co oznacza, że nie są wystarczająco dobre, aby uznać je za zrównoważone dla większości zastosowań, dlatego należy samodzielnie zdecydować, czy przyniesienie przez nich pamięci jest możliwe do przyjęcia.

---

## Dostosowywanie czasu pracy (zaawansowane)

Poniższe sztuczki **wiążą się z poważnym zwiększeniem pamięci** i dlatego powinny być stosowane ostrożnie.

Zalecany sposób stosowania tych ustawień jest za pomocą właściwości środowiska `DOTNET_`. Oczywiście możesz również użyć innych metod, np. `runtimeconfig. syn`, ale niektóre ustawienia są niemożliwe do ustawienia w ten sposób, i dodatkowo ASF zastąpi twoją niestandardową konfigurację `runtimeconfig. syn` z własną aktualizacją, dlatego zalecamy właściwości środowiskowe, które można łatwo ustawić przed uruchomieniem procesu.

.NET czas pracy pozwala **[dostosować kolektor śmieci](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** na wiele sposobów, skuteczne dostosowanie procesu GC do Twoich potrzeb. Udokumentowaliśmy poniżej właściwości, które w naszej opinii są szczególnie ważne.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Konfiguruje czy aplikacja wykorzystuje zbieranie śmieci na stacji roboczej czy zbieranie śmieci na serwerze.

Możesz przeczytać dokładną specyfikę serwera GC w **[podstawy kolekcji śmieci](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF domyślnie używa zbiórki stacji roboczej. Wynika to głównie z dobrej równowagi między zużyciem pamięci a wydajnością, co jest bardziej niż wystarczające dla kilku botów, jak zwykle pojedynczy równoległy wątek GC w tle jest wystarczająco szybki, aby obsługiwać całą pamięć przydzieloną przez ASF.

Obecnie jednak mamy wiele rdzeni CPU, z których ASF może w znacznym stopniu skorzystać, posiadając dedykowany wątek GC dla każdego CPU vCore który jest dostępny. Może to znacznie poprawić wydajność podczas ciężkich zadań ASF, takich jak strony parsowania odznak lub inwentaryzacja, ponieważ każdy CPU vCore może pomóc, a nie tylko 2 (główny i GC). Serwer GC jest zalecany dla maszyn z 3 procesorami vRre i dłużej, stacja robocza GC jest automatycznie wymuszona, jeśli twoja maszyna ma tylko 1 procesor vCore, i jeśli pacjent ma dokładnie 2, wtedy może rozważyć próbę obu (wyniki mogą się różnić).

Sam serwer GC nie powoduje ogromnego zwiększenia pamięci dzięki aktywności, ale ma znacznie większe rozmiary generacji, a zatem jest o wiele bardziej leniwe, jeśli chodzi o pamięć o OS. Możesz znaleźć się w słodkim miejscu, gdzie GC serwera znacznie zwiększa wydajność i chciałbyś nadal z niego korzystać, ale jednocześnie nie możesz sobie pozwolić na to, że ogromna pamięć rośnie, która powstaje w wyniku jej użycia. Na szczęście dla ciebie istnieje ustawienie "najlepsze z obu światów", używając serwera GC z **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** właściwość konfiguracji ustawiona na `0`, które nadal będą włączać GC serwera, ale ograniczy rozmiary generatorów i skupi się bardziej na pamięci. Alternatywnie, możesz również eksperymentować z inną właściwością, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**, lub nawet oba w tym samym czasie.

Jeśli jednak pamięć nie jest dla Ciebie problemem (ponieważ GC nadal bierze pod uwagę dostępną pamięć i ulepszenia), Jest o wiele lepszym pomysłem, aby w ogóle nie zmieniać tych właściwości, osiągając w ten sposób wyższą wydajność.

---

Możesz włączyć wybrane właściwości poprzez ustawienie odpowiednich zmiennych środowiskowych. Na przykład na Linux (powłoka):

```shell
export DOTNET_gcServer=1

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

Lub na Windows (powershell):

```powershell
$Env:DOTNET_gcServer=1

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

---

## Zalecana optymalizacja

- Upewnij się, że używasz domyślnej wartości `OptimizationMode` , która jest `MaxPerformance`. Jest to zdecydowanie najważniejsze ustawienie, ponieważ użycie wartości `MinMemoryUsage` ma dramatyczny wpływ na wydajność.
- Włącz serwer GC. Serwer GC może być natychmiast postrzegany jako aktywny przez znaczny wzrost pamięci w porównaniu z GC stacji roboczej. Spowoduje to pojawienie się wątku GC dla każdego wątku procesora, który posiadasz w celu wykonywania operacji GC równolegle z maksymalną prędkością.
- Jeśli nie możesz sobie pozwolić na zwiększenie pamięci z powodu serwera GC, Rozważ ulepszenie **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** lub **[`GCHeapHardLimitProcent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** aby osiągnąć "najlepsze z obu światów". Jednakże, jeśli pamięć jest na to stać, wtedy lepiej utrzymać go domyślnie - serwer GC już sam się ulepsza podczas pracy i jest wystarczająco inteligentny, aby użyć mniejszej pamięci, gdy Twój system operacyjny naprawdę tego potrzebuje.

Zastosowanie powyższych rekomendacji pozwala na uzyskanie wyższej wydajności ASF, która powinna być szybka nawet z setkami lub tysiącami włączonych botów. Procesor CPU nie powinien już być wąskim gardłem, ponieważ ASF może w razie potrzeby korzystać z całej twojej mocy procesora, zmniejszając wymagany czas do minimum. Następnym krokiem będą aktualizacje CPU i RAM lub rozdzielenie obciążenia pracą na kilku serwerach i instancjach ASF.