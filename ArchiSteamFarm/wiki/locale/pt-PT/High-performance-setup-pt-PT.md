# Configuração de alto desempenho

Isto é exatamente o oposto de **[configuração de pouca memória](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** e normalmente você quer seguir essas dicas se você deseja aumentar o desempenho do ASF (em termos de velocidade da CPU), para o custo potencial de aumento do uso de memória.

---

O ASF tenta preferir desempenho quando se trata de uma configuração geral de balanceamento, Portanto, não há muito que você possa fazer para aumentar seu desempenho, embora também não esteja completamente fora de opções. No entanto, tenha em mente que essas opções não estão habilitadas por padrão, que significa que eles não são bons o suficiente para considerá-los balanceados para a maioria dos usos Portanto, você deve decidir por si mesmo se o aumento da memória por eles trazido é aceitável para você.

---

## Ajuste de tempo de execução (avançado)

Os truques **envolvem um sério aumento de memória** e devem, portanto, ser usados com cautela.

A forma recomendada de aplicar essas configurações é através de `DOTNET_` propriedades de ambiente. Claro, você também pode usar outros métodos, ex: `runtimeconfig. son`, mas é impossível definir algumas configurações desta maneira. e além disso, o ASF substituirá sua configuração `personalizada. son` com o seu próprio na próxima atualização, portanto recomendamos as propriedades de ambiente que você pode definir facilmente antes de iniciar o processo.

.NET runtime allows you to **[tweak garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** in a lot of ways, effectively fine-tuning the GC process according to your needs. Documentamos abaixo propriedades que são especialmente importantes em nossa opinião.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Configura se o aplicativo usa a coleta de lixo da estação de trabalho ou coleta de lixo do servidor.

You can read the exact specific of the server GC at **[fundamentals of garbage collection](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

O ASF usa a coleção de lixo de estação de trabalho por padrão. Isto é principalmente por causa de um bom equilíbrio entre uso de memória e desempenho, o que é mais que suficiente para apenas alguns bots, como geralmente um único coletor de lixo em segundo plano simultâneo é rápido o suficiente para lidar com toda a memória alocada pelo ASF.

No entanto, hoje nós temos muitos núcleos de CPU dos quais o ASF pode se beneficiar bastante, ao ter um thread de coleta de lixo dedicado a cada núcleo de CPU que está disponível. Isto pode melhorar muito o desempenho durante tarefas pesadas do ASF, tais como análise de páginas de insígnias ou inventário, já que cada CPU vCore pode ajudar, ao invés de apenas 2 (principal e GC). A coleta de lixo do servidor é recomendada para máquinas com 3 núcleos virtuais de CPU ou mais, a coleta de lixo de estação de trabalho é forçada automaticamente se seu computador tem apenas 1 núcleo virtual de CPU, e se você tem exatamente 2, então você pode considerar tentar ambos (os resultados podem variar).

A coleta de lixo de servidor em si não resulta em um aumento muito grande de memória apenas por estar ativo, mas tem tamanhos de geração muito maiores e, portanto, é muito mais preguiçoso quando se trata de devolver memória ao sistema operacional. Você pode achar um bom ponto quando o coletor de lixo de servidor aumentar significativamente o desempenho e você quiser continuar usando-o, mas ao mesmo tempo você não pode se dar ao luxo de aumentar a memória que resulta do seu uso. Felizmente existem configurações de "melhor dos dois mundos", usando o coletor de lixo de servidor com **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** configuração definida como `0`, que ainda irá habilitar o coletor de lixo de servidor, mas limitar os tamanhos de geração e focar mais na memória. Como alternativa, você também pode experimentar outra propriedade, **[`GCHeLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**, ou mesmo ambas ao mesmo tempo.

No entanto, se memória não é um problema para você (como o coletor de lixo leva em conta sua memória disponível e se auto-ajusta), É uma ideia muito melhor não mudar nada dessas propriedades, alcançando um desempenho superior no resultado.

---

Você pode habilitar as propriedades selecionadas definindo variáveis de ambiente apropriadas. Por exemplo, no Linux (shell):

```shell
export DOTNET_gcServer=1

./ArchiSteamFarm # Para compilação específica do sistema operacional
./ArchiSteamFarm.sh # Para compilação genérica
```

Ou no Windows (powershell):

```powershell
$Env:DOTNET_gcServer=1

.\ArchiSteamFarm.exe # Para uma compilação específica para SO
.\ArchiSteamFarm.cmd # Para uma compilação genérica
```

---

## Otimização recomendada

- Certifique-se de que você está usando o valor padrão de `OptimizationMode` que é `MaxPerformance`. Essa é de longe a configuração mais importante, uma vez que usar `MinMemoryUsage` (uso mínimo de memória tem efeitos dramáticos no desempenho.
- Habilitar coletor de lixo no servidor. A coleta de lixo do servidor pode ser vista imediatamente como ativa por um aumento significativo de memória em comparação com o coletor de lixo de estação de trabalho. Isto irá gerar um thread do coletor de lixo para cada thread do CPU que sua máquina tiver para executar operações de coleta de lixo em paralelo com a velocidade máxima.
- If you can't afford memory increase due to server GC, consider tweaking **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** and/or **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** to achieve "the best of both worlds". No entanto, se sua memória não funcionar, então é melhor mantê-lo como padrão - o coletor de lixo de servidor se ajusta durante o tempo de execução e é inteligente o bastante para usar menos memória quando seu sistema operacional realmente precisará.

A aplicação de recomendações acima permite que você tenha desempenho superior do ASF que deve estar rapidamente mesmo com centenas ou milhares de bots habilitados. O CPU não deve mais ser um gargalo, já que o ASF é capaz de usar todo o seu poder do CPU quando necessário, reduzindo o tempo necessário ao mínimo possível. O próximo passo seria uma atualização da CPU e da RAM ou uma divisão da carga de trabalho entre vários servidores e o ASF.