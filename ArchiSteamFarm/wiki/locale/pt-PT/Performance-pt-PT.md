# Desempenho

O principal objetivo do ASF é coletar da forma mais efetiva possível. baseado em dois tipos de dados com os quais pode operar - um pequeno conjunto de dados fornecidos pelo usuário que é impossível para o ASF adivinhar/verificar por conta própria, e um conjunto maior de dados que podem ser verificados automaticamente pelo ASF.

No modo automático, o ASF não permite que você escolha os jogos que devem ser executados, nem permite que você altere o algoritmo de coleta de cartas. **ASF sabe melhor do que você o que ele deve fazer e quais decisões ele deve tomar para coletar o mais rápido possível**. Seu objetivo é definir as propriedades de configuração corretamente já que o ASF não pode adivinhá-las por conta própria, todo o resto é coberto.

---

Há algum tempo a Valve mudou o algoritmo de recebimento de cartas. Desse ponto em diante, nós podemos categorizar as contas Steam em duas categorias: aquelas **com** recebimento de cartas restrito e aquelas **sem**. A única diferença entre esses dois tipos é o fato de que as contas com restrição não conseguem nenhuma carta de determinado jogo até que ele seja jogado por pelo menos `X` horas. Parece que as contas mais antigas que nunca pediram reembolso têm **recebimento de cartas irrestrito**, , enquanto novas contas e aqueles que pediram reembolso têm **restrição na coleta de cartas**. No entanto isto é apenas teoria, e não deve ser tomado como regra. That's why there is **no obvious answer**, and ASF relies on **you** telling it which case is appropriate for your account.

---

O ASF possui atualmente dois algoritmos de coleta:

**`Simple`** algorítimo funciona melhor para contas que possuem restrição no recebimento de cartas. Este é o algoritmo principal usado pelo ASF. O bot encontra jogos para coletar e os executa um por um até que todas as cartas sejam recebidas. Isso porque a taxa de coleta de cartas quando se coleta de mais de um jogo é próxima a zero e totalmente ineficaz.

**`Complex`** é um novo algoritmo que foi implementado para ajudar contas restritas a maximizar seus lucros também. O ASF primeiro usará **`o algorítimo Simples`** em todos os jogos que passaram por `HoursUntilCardDrops` horas de tempo, então, se nenhum jogo com >= `HoursUntilCardDrops` horas forem deixadas vai coletar de todos os jogos (até `32` limite) com < `HoursUntilCardDrops` horas restantes simultaneamente, até que qualquer um deles atinja `HorasUntilCardDrops` horas, então o ASF continuará o loop no início (use **`Simple`** nesse jogo, retorne a simultânea em < `HorasUntilCardDrops` , e assim por diante). Podemos rodar vários jogos, neste caso, para subir horas dos jogos que precisamos coletar até o valor apropriado. Tenha em mente que durante a coleta de horas, o ASF **não coleta cartas** , então também não será verificada a obtenção de cartas durante esse período (por razões acima indicadas).

Atualmente, o ASF escolhe o algoritmo de coleta baseado puramente na propriedade de configuração `HoursUntilCardDrops` (que é definida por **você**). If `HoursUntilCardDrops` is set to `0`, **`Simple`** algorithm will be used, otherwise, **`Complex`** algorithm will be used instead - configured to bump playtime in all games to given amount of hours before farming them for card drops.

---

### **There is no obvious answer which algorithm is better for you**.

Esta é uma das razões pelas quais você não escolhe o algoritmo de coleta, em vez disso, você diz ao ASF se a conta tem restrições na coleta ou não. Se a conta tiver itens não restritos, **`Simple`** Algoritmo irá **funcionar melhor** nessa conta, já que não vamos perder tempo levando todos os jogos para `X` horas - o rácio de coleta de cartas é próximo de 0% ao coletar vários jogos. On the other hand, if your account has card drops restricted, **`Complex`** algorithm will be better for you, as there's no point in farming solo if game didn't reach `HoursUntilCardDrops` hours yet - so we'll farm **playtime** first, **then** cards in solo mode.

Não defina cegamente `HoursUntilCardDrops` apenas porque alguém te disse para fazer - faça testes, compare resultados, e com base nos dados que você obtém, decida qual opção deve ser melhor para você. Se você colocar um mínimo de esforço nisso, você vai garantir que o ASF esteja trabalhando com a máxima eficiência possível na sua conta que é provavelmente o que você quer, considerando que você está lendo esta página wiki agora. Se houvesse uma solução que funcione para todos, você não teria uma escolha: o ASF decidiria por conta própria.

---

### Qual é a melhor maneira de descobrir se sua conta é restrita?

Certifique-se de ter jogos com **sem tempo de jogo registrado** para coletar, de preferência 5+, e execute o ASF com `HoursUntilCardDrops` of `0`. Seria uma boa ideia se você não jogasse nada durante o período de coleta para obter resultados mais precisos (melhor rodar o ASF durante a noite). Deixe o ASF coletar desses 5 jogos e, depois, verificar o registro para ver os resultados.

O ASF diz claramente quando uma carta para determinado jogo foi recebida. Você está interessado no recebimento mais rápido alcançado pelo ASF. Por exemplo, se a sua conta não tiver restrição, então a primeira carta deve aparecer após cerca de 30 minutos de coleta. Caso você observe **pelo menos um jogo** que recebeu cartas nos 30 minutos iniciais então isso é um indicador de que sua conta é **não é** restrita e deve usar `HoursUntilCardDrops` de `0`.

Por outro lado, se você notar que **todo** jogo está levando pelo menos `X` quantidade de horas antes dele dropar seu primeiro cargo, então isso é um indicador para o que você deve definir `HoursUntilCardDrops`. A maioria (se não todos) dos usuários restritos precisam de pelo menos `3` horas de tempo de jogo para que as cartas recebam, e esse também é o valor padrão para a configuração `HoursUntilCardDrops`.

Lembre-se de que os jogos podem ter taxa de recebimento diferente, É por isso que você deveria testar se sua teoria está certa com **pelo menos** 3 jogos, De preferência 5+ para garantir que você não tenha resultados falsos por coincidência. A card drop of one game in less than an hour is a confirmation that your account **is not** restricted and can use `HoursUntilCardDrops` of `0`, but for confirming that your account **is** restricted, you need at least several games that are not dropping cards until you hit a fixed mark.

É importante notar que no passado `HoursUntilCardDrops` era apenas `0` ou `2`, e é por isso que o ASF tinha uma única propriedade `CardDropsRestricted` que permitia alternar entre esses dois valores. Com as mudanças recentes notamos que não só a maioria dos usuários requerem `3` horas ao invés da anterior `2` agora, mas também que `HoursUntilCardDrops` agora é dinâmico e pode atingir qualquer valor por conta.

No final, é claro que a decisão é sua.

E para piorar ainda mais - eu experimentei casos em que as pessoas mudaram de restrito para irrestrito e vice-versa - tanto por causa de uma falha na Steam (sim, temos muitas delas) ou devido a alguns ajustes de lógica feitos por Valve. Então, mesmo que você tenha confirmado se sua conta está restrita (ou não), não acredite que assim será - para mudar de irrestrito para restrito é suficiente pedir um reembolso. Se você sentir que o valor definido anteriormente não é mais apropriado, você pode sempre refazer o teste e atualizá-lo de acordo.

---

Por padrão, o ASF assume que o `HoursUntilCardDrops` é `3`, como efeito negativo de definir isso para `3` quando deve ser menor é menor do que feito da outra maneira. Isto porque, no pior caso possível, vamos desperdiçar `3` horas de coleta por `32` jogos, comparado a desperdiçar `3` horas de coleta por cada jogo se a `HorasUntilCardDrops` foi definida como `0` por padrão. No entanto, você ainda deve ajustar essa variável de forma a corresponder à sua conta por uma eficiência máxima. já que isto é apenas uma estimativa cega baseada em potenciais inconvenientes e na maioria dos usuários (então estamos tentando escolher o "mal menor" por padrão).

No momento dois algoritmos acima são suficientes para todos os cenários de conta atualmente possíveis, a fim de coletar da forma mais efetiva possível, portanto, não está planejado adicionar outros.

É legal notar que o ASF também inclui o modo de coleta manual que pode ser ativado pelo comando `play`. Você pode ler mais sobre isso em **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

## Falhas no Steam

O algoritmo de coleta de cartas nem sempre funciona da maneira que devia, e é inteiramente possível que várias falhas no Steam aconteçam. tais como cartas recebidas em contas restritas, cartas recebidas ao fechar/trocar o jogo, cartas não recebem quando o jogo está sendo jogado, e assim por diante.

Esta seção é principalmente para pessoas que estão se perguntando por que o ASF não faz o **X**, como mudar rapidamente os jogos para cartas mais rápido.

O que é um erro **do Steam** - uma ação específica desencadeando um comportamento **indefinido** , que é **não intencional, sem documentação e considerado como uma falha lógica**. It's **unreliable by definition**, which means that it can't be reproduced reliably with clean testing environment, and therefore, coded without resorting to hacks that are supposed to guess when glitch is happening and how to fight with it / abuse it. Normalmente ele é temporário até que os desenvolvedores consertem a falha de lógica, embora alguns erros podem passar despercebidos por um longo período de tempo.

Um bom exemplo do que é considerado um erro **do Steam** é a situação incomum de receber uma carta quando o jogo é fechado, que pode ser abusado em algum grau com a função de pular de jogo do Idle Mestre.

- **Comportamento indefinido** - não é possível dizer se haverá 0 ou 1 cartas a serem recebidas quando você aciona a falha.
- **Não foi a intenção** - com base na experiência e comportamento anteriores da rede Steam que não resulta no mesmo comportamento ao enviar uma única solicitação.
- **Não documentado** - é claramente documentado no site Steam como as cartas são obtidas, e **em cada lugar** afirma-se claramente que é obtido através de **jogando**, NÃO ESTÁ fechando jogos, obtendo conquistas, mudando de jogo ou lançando 32 jogos simultaneamente.
- **Considered as a logic flaw** - closing game(s) or switching them should have no outcome on cards being dropped which are clearly stated to be obtained through **gaining playtime**.
- **Unreliable by definition, can't be reproduced reliably** - it doesn't work for everybody, and even if it did work for you once, it could no longer work for the second time.

Uma vez que percebemos o que é um erro do Steam, e o fato de as cartas serem recebidas quando um jogo é fechado **é** um, nós podemos passar para o segundo ponto - **o ASF não está abusando da rede Steam de forma alguma por definição, e está fazendo o seu melhor para cumprir o Acordo de Assinatura do Steam, seus protocolos e o que é geralmente aceito**. Spamming de rede Steam com constantes pedidos de abertura/fechamento de jogos pode ser considerado um ataque **[DoS](https://en.wikipedia.org/wiki/Denial-of-service_attack)** e **viola diretamente [Código de Conduta Online do Steam](https://store.steampowered.com/online_conduct/?l=english)**.

> Como um assinante do Steam, você concorda em seguir as regras de conduta a seguir.
> 
> Você não irá:
> 
> Organizar ataques a um servidor do Steam ou interromper o Steam.

Não importa se você consegue ativar a falha no Steam com outros programas (como IM), e também não importa se você concorda conosco e considera tal comportamento como ataque DoS, ou não - cabe à Valve julgar isso, mas se considerarmos isso como exploração/abuso de comportamento não pretendido por meio de solicitações excessivas da rede Steam, então você poderá ter certeza de que a Valve terá uma visão semelhante sobre isso.

ASF is **never** going to take advantage of Steam exploits, abuses, hacks or any other activity that we see as **illegal or unwanted** according to Steam ToS, Steam Online Conduct or any other trusted source that could indicate that ASF activity is unwanted by Steam network, as stated in **[contributing](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)** section.

Se você quiser a todo custo arriscar a sua conta Steam ao coletar algumas cartas de centavos mais rápido que o normal, então infelizmente o ASF nunca vai oferecer algo assim no modo automático, embora você ainda tenha o comando `play` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** que pode ser usado como uma ferramenta para fazer o que quiser em termos de interação de rede Steam. Não recomendamos aproveitar falhas no Steam e explorá-las para seu próprio ganho - não apenas no ASF, mas com qualquer outra ferramenta também. No final, porém, é a sua conta, e sua escolha o que você quer fazer com isso - apenas tenha em mente que nós avisamos você.