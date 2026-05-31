# Plugin

`ItemsMatcherPlugin` é o ASF oficial **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** que estende as funcionalidades de listagem STM do ASF. Em particular, isto inclui `PublicListing` em **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** e `MatchActively` em **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. O ASF vem com o `ItemsMatcherPlugin` agrupado com a versão, portanto ele está pronto para uso imediatamente.

---

## `Listagem`

A listagem pública, como o nome implica, é uma listagem de bots STM disponíveis no ASF. Está localizado em **[nosso site](https://asf.justarchi.net/STM)**, gerenciado automaticamente e usado como um serviço público para os usuários do ASF que usam `MatchActive`, Assim como usuários que não são do ASF para correspondência manual, tanto quanto do ASF.

Para ser listado, você tem um conjunto de requisitos para cumprir. No mínimo, você deve ter permitido `Publicando Listagem` em `RemoteCommunication` (configuração padrão), `SteamTradeMatcher` ativado em `TradingPreferences`, **[inventário público](https://steamcommunity.com/my/edit/settings)** configurações de privacidade, uma conta **[irrestrita](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** e **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** ativa. Requisitos adicionais incluem a autenticação 2FA ativa desde pelo menos 15 dias, a última alteração de senha há mais de 5 dias falta de limitações de conta, como bloqueios, proibições económicas e proibições de troca. Naturalmente, você também deve ter pelo menos um item (trocável) em seu inventário a partir do especificado `MatchableTypes`, como por exemplo as cartas comerciais. Além disso, bots com mais de `500000` não são aceitos devido a excesso de overhead, Recomendamos dividir seu inventário em várias contas neste caso.

Enquanto o `PublicListing` é ativado por padrão, por favor, note que você irá **não ser** exibido no site se você não cumprir todos os requisitos, especialmente `SteamTradeMatcher`, que não está habilitado por padrão. Para pessoas que não atendem aos critérios, mesmo que eles mantenham `Publicando` habilitado, o ASF não se comunica com o servidor de forma alguma. A listagem pública também é compatível somente com a última versão estável do ASF e pode se recusar a exibir bots desatualizados, especialmente se faltar a funcionalidade principal que pode ser encontrada apenas em versões mais recentes.

### Como exatamente isso funciona

O ASF envia os dados iniciais uma vez após o login, que contém todas as propriedades que a listagem pública usa. Em seguida, a cada 10 minutos o ASF envia uma solicitação muito pequena de "pulso" que notifica o nosso servidor de que o bot ainda está sendo executado. Se por alguma razão o pulso não chegou, por exemplo, devido a problemas de rede, então o ASF tentará enviá-lo novamente a cada minuto, até que o servidor o registre. Desta forma, nosso servidor sabe precisamente quais bots ainda estão em execução e prontos para aceitar ofertas de troca. O ASF também enviará um anúncio inicial conforme necessário, por exemplo, se ele detectar que nosso inventário mudou desde o anterior.

We display all eligible ASF accounts that were active in the **last 15 minutes**. Os usuários são classificados de acordo com sua utilidade relativa - `Combinar tudo` bots que são exibidos com `Qualquer banner` que aceite todas as trocas 1:1, então jogos únicos contam, e finalmente os itens contam.

### API

A listagem do ASF do STM só aceita bots ASF no momento. Não há como listar bots de terceiros em nossa listagem por enquanto, já que não podemos revisar o código deles facilmente e garantir que eles atendam a toda a nossa lógica de negociação. Portanto, a participação na listagem requer a última versão estável do ASF, embora ele possa rodar com um personalizado **[plugins](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

Para os consumidores da listagem, temos um ponto de extremidade muito simples **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** que pode ser usado. Ele inclui todos os dados que temos, além dos inventários dos usuários que fazem parte do recurso `Matchativamente` exclusivamente.

### Política de privacidade

Se você concordar em ser listado em nosso anúncio, ativando `SteamTradeMatcher` e não recusando `PublicListing`, Conforme especificado acima, vamos armazenar temporariamente alguns dos detalhes da sua conta Steam em nosso servidor para fornecer as funcionalidades esperadas.

As informações públicas (expostas pela Steam a todas as partes interessadas) incluem:
- Seu identificador Steam (na forma de 64-bit, para gerar links)
- Seu apelido (para fins de exibição)
- Seu avatar (hash, para fins de exibição)

Informação condicionalmente pública (exposta pela Steam a cada parte interessada se você atender aos requisitos da listagem) inclui:
- Seu **[inventário](https://steamcommunity.com/my/inventory/#753_6)** (para que as pessoas possam usar `Combinar` com os seus itens).

Informação privada (dados selecionados necessários para fornecer as funcionalidades) inclui:
- Seu token de troca **[](https://steamcommunity.com/my/tradeoffers/privacy)** (para que pessoas fora da sua lista de amigos possam lhe enviar trocas)
- Sua configuração `MatchableTypes` (para fins de exibição e combinação)
- Sua configuração `MatchEverything` (para fins de exibição e combinação)
- Sua configuração `MaxTradeHoldDuration` (para que outras pessoas saibam se você está disposto a aceitar suas trocas)

Desde o momento em que você parar de usar (anunciando no) nosso anúncio, seus dados ficam indisponíveis para o público em geral dentro de um máximo de 15 minutos. e é guardado em nosso servidor por um máximo de duas semanas - tudo é automaticamente eliminado após esse período. Nenhuma ação sua é necessária para que isso aconteça.

---

## `Parcialmente`

`MatchActively` setting is active version of **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** including interactive matching in which the bot will send trades to other people. Ele pode funcionar em espera sozinho, ou junto com a configuração `SteamTradeMatcher`. This feature requires `LicenseID` to be set, as it uses third-party server and paid resources to operate.

Para fazer uso dessa opção, você tem um conjunto de requisitos para atender. No mínimo, você deve ter uma conta **[irrestrita](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** , **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** ativo e pelo menos um tipo válido em `MatchableTypes`, como cartas de negociação. Requisitos adicionais incluem a autenticação 2FA ativa desde pelo menos 15 dias, a última alteração de senha há mais de 5 dias falta de limitações de conta, como bloqueios, proibições económicas e proibições de troca.

Se você cumprir todos os requisitos acima, O ASF se comunicará periodicamente com nossa **[pública do ASF STM listando](#publiclisting)** a fim de combinar bots que estejam atualmente disponíveis.

During matching, ASF bot will fetch its own inventory, then communicate with our server with it to find all possible `MatchableTypes` matches from other, currently available bots. Graças a se comunicar diretamente com o nosso servidor, este processo requer uma única requisição e temos informações imediatas se algum bot disponível oferece algo interessante para nós - se for encontrada uma correspondência, O ASF enviará e confirmará a oferta de troca automaticamente.

Este módulo deve ser transparente. A correspondência vai começar aproximadamente `1` hora após o início do ASF e vai se repetir a cada `6` horas (se necessário). `MatchActively` feature is aimed to be used as a long-run, periodical measure to ensure that we're actively heading towards sets completion, however, people that are not running ASF 24/7 may also consider using a `match` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Os usuários alvo deste módulo são principais contas e contas alternativas "ocultas", embora possa ser usado por qualquer bot que não esteja configurado para `MatchEverything`. Além disso, bots com mais de `500000` não são aceitos para correspondência devido a excesso de overhead, Recomendamos dividir seu inventário em várias contas neste caso.

O ASF faz o seu melhor para minimizar a quantidade de pedidos e a pressão gerada pelo uso desta opção, ao mesmo tempo maximizando a eficiência da correspondência ao limite superior. O algoritmo exato de escolher os bots para combinar e organizar todo o processo é o detalhe de implementação do ASF e pode mudar no que diz respeito ao feedback, situação e possíveis ideias futuras.

A versão atual do algoritmo faz com que o ASF priorize `Qualquer bot` primeiro, especialmente aqueles que têm uma maior diversidade de jogos de que seus itens provêm. Quando esgotado de `Qualquer bot` , o ASF vai passar para os bots Justos `` seguindo a mesma regra de diversidade. O ASF tentará corresponder a todos os bots disponíveis pelo menos uma vez, para garantir que não estamos faltando em um possível progresso definido.

`MatchActively` takes into account bots that you blacklisted from trading through `tbadd` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** and will not attempt to actively match them. Isso pode ser usado para dizer ao ASF quais bots nunca devem ser combinados, mesmo que eles tenham potenciais cartas duplicadas para serem usadas.

O ASF também fará o seu melhor para garantir que as ofertas de troca sejam aprovadas. Na próxima execução, o que normalmente acontece em 6 horas, o ASF cancelará quaisquer ofertas de troca pendentes que ainda não foram aceitas, e despriorize as steamIDs participando delas para, esperamos, preferir primeiro os bots mais ativos. Ainda assim, se bots despriorizados forem os últimos que têm a correspondência que precisamos, nós ainda tentaremos combiná-los (novamente).

---

### Por que preciso da `LicenseID` para usar `MatchActive`? Já não estava livre antes?

O ASF é e continua sendo gratuito e de código aberto, tal como foi criado no início do projeto em outubro de 2015. Código fonte do plug-in `ItemsMatcher` e, portanto, `MatchActive` recurso está disponível em nosso repositório, enquanto o programa ASF é totalmente não-comercial, não ganhamos nada com contribuições para ele, compilando ou publicando. Nos últimos 7 anos o ASF recebeu uma enorme quantidade de desenvolvimento, e ainda está sendo melhorado e aprimorado a cada lançamento mensal estável por uma única pessoa, **[JustArchi](https://github.com/JustArchi)** - sem sequências de caracteres anexadas. O único financiamento que recebemos é de doações não obrigatórias provenientes dos nossos utilizadores.

For a very long time, until October 2022, `MatchActively` feature was part of ASF core and available for everyone to use. Em outubro de 2022, a Valve, a empresa atrás da Steam, colocou limites de taxa muito severos na busca de inventário de outros bots - os quais tornaram a funcionalidade anterior completamente quebrada, sem possibilidade de uma solução para resolver este problema. Portanto, devido ao fato de que a característica ficou totalmente defunta sem chance de ser consertada, ele tinha que ser removido do núcleo do ASF como obsoleto.

`MatchActive` foi ressuscitado como parte do plugin Oficial `ItemsMatcher` que ainda melhora o ASF com cartas correspondentes a funcionalidade, baseando-se num conceito retrabalhado completamente. Ressuscitando o recurso `MatchActive` necessário de nós **uma extraordinária quantidade de trabalho** para criar o backend do ASF, novo serviço hospedado em um servidor, com mais de uma centena de proxies pagos anexados para resolução de inventários, tudo exclusivamente para permitir que os clientes do ASF usem o `MatchActive` como antes. Devido à quantidade de trabalho envolvido, além de recursos que não são gratuitos e exigem ser pagos mensalmente por nós (domínio, servidor, proxies), Decidimos oferecer esta funcionalidade aos nossos patrocinadores, ou seja, pessoas que já apoiam o projeto do ASF mensalmente, graças a quem podemos disponibilizar esses recursos pagos.

Nosso objetivo não é lucrar com isso, mas sim cobrir os **custos mensais** que estão exclusivamente relacionados com a oferta desta opção - é por isso que oferecemos basicamente para nada, mas temos que cobrar um pouco por ele, pois não podemos pagar centenas de dólares dos nossos próprios bolsos todos os meses. só para disponibilizá-lo para você. Também não estamos em condições de discutir o preço, é a Valve que forçou esses custos a nós, e a alternativa é não ter tal recurso disponível, que se aplica se você decidir, por qualquer motivo, que você não pode justificar usar nosso plugin nesses termos.

Em qualquer caso, nós entendemos que `MatchActive` não é para todos, e esperamos que você também entenda por que não podemos oferecê-lo de graça. Se ninguém estivesse interessado em ajudar a cobrir os custos dessa característica, não existiria para começar, Como seríamos forçados a cortar nas despesas mensais que ninguém está disposto a manter. Felizmente, estamos em melhor posição do que isso, e você pode decidir se está disposto a usar `Matchativamente` nesses termos, ou não.

---

### Como posso obter um acesso?

`ItemsMatcher` é oferecido como parte de níveis mensais de $5+ patrocinador no GitHub **[JustArchi's](https://github.com/sponsors/JustArchi)**. Também é possível se tornar patrocinador único embora, neste caso, a licença seja válida apenas por um mês (com possibilidade de extensão da mesma forma). Quando você se tornar um patrocinador de $5 tier (ou superior), leia **[configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** seção para obter e preencher `LicenseID`. Depois, você só precisa habilitar `MatchActive` no `TradingPreferences` do seu bot escolhido.

A licença permite que você envie um valor limitado de solicitações para o servidor. $5 tier permite usar `MatchActively` para uma conta bot (4 solicitações diárias), e cada $5 adicional adiciona mais duas contas bot (8 solicitações diariamente). Por exemplo, se você quiser executá-lo em três contas, ele será coberto por US $ 10 nível e superior.