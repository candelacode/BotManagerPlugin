# Configuração

Esta página é dedicada para a configuração do ASF. Ele serve como uma documentação completa do diretório ` config `, permitindo que consigas ajustar o ASF às tuas necessidades.

* **[Introdução](#introduction)**
* **[Gerador de configuração web](#web-based-configgenerator)**
* **[Configuração ASF-ui](#asf-ui-configuration)**
* **[Configuração manual](#manual-configuration)**
* **[Configuração Global](#global-config)**
* **[Bot config](#bot-config)**
* **[Estrutura de arquivos](#file-structure)**
* **[Mapeamento JSON](#json-mapping)**
* **[Mapeamento de compatibilidade](#compatibility-mapping)**
* **[Configurações de compatibilidade](#configs-compatibility)**
* **[Auto-recarregar](#auto-reload)**

---

## Introdução

A configuração do ASF é dividida em duas partes principais: configuração global (do processo) e configuração de cada bot. Cada bot tem seu próprio arquivo de configuração chamado `BotName.json` (onde `BotName` é o nome do bot), enquanto a configuração global do ASF (processo) é um único arquivo chamado `ASF.json`.

O bot é uma única conta Steam que participa do processo do ASF. Para funcionar correctamente, o ASF precisa de pelo menos **uma** conta bot definida. Não há limite imposto pelo processo de contas bot, então você pode usar quantos bots (contas Steam) quiseres.

O ASF usa o formato **[JSON](https://en.wikipedia.org/wiki/JSON)** para armazenar seus arquivos de configuração. É um formato amigável, legível e universal, no qual tu podes configurar o programa. Porém não te preocupes, não precisas saber JSON para configurar o ASF. Eu apenas mencionei isto para o caso de quereres criar configurações em massa do ASF com algum tipo de script.

A configuração pode ser feita de várias maneiras. Podes usar nosso **[Gerador de configuração web](https://justarchinet.github.io/ASF-WebConfigGenerator)**, que é um aplicativo local independente do ASF. Podes usar nosso **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR#asf-ui)** frontend IPC para a configuração diretamente no ASF. Por último, podes sempre gerar arquivos de configuração manualmente, já que eles seguem uma estrutura JSON fixa especificada abaixo. Explicaremos em breve as opções disponíveis.

---

## Gerador de configuração web

O objectivo do nosso **[Gerador de configuração web](https://justarchinet.github.io/ASF-WebConfigGenerator)** é fornecer uma interface amigável que é usada para gerar arquivos de configuração do ASF. O Gerador de configuração web é 100% baseado no cliente, o que significa que os detalhes que inseriste não estão a ser enviados para nenhum lugar, mas processados localmente. Isto garante segurança e fiabilidade, pois ele pode até mesmo funcionar **[offline](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** se quiseres baixar todos os arquivos e executar o índice `. tml` no teu navegador favorito.

O Gerador de Configuração Web foi verificado e funciona correctamente no Chrome e Firefox, mas deve funcionar correctamente em todos os navegadores mais populares com javascript habilitado.

O uso é muito simples - seleciona o que desejas gerar a configuração do `ASF` ou do `Bot` alternando para a aba adequada, certifique-se de que a versão escolhida do arquivo de configuração corresponde à versão do ASF, então insira todos os detalhes e clique no botão "baixar". Move este arquivo para a pasta `config` do ASF, substituindo os arquivos existentes, se necessário. Repita para todas as eventuais modificações e refira o resto desta seção para uma explicação de todas as opções disponíveis de configuração.

---

## Configuração ASF-ui

Nosso **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR#asf-ui)** interface IPC permite que configures o ASF também e é uma solução superior para reconfigurar o ASF após gerar as configurações iniciais devido ao fato de que ele pode editar as configurações no local, em vez do Gerador de Configuração baseado na Web que os gera estaticamente.

Para usar a ASF-ui, deves ter o nosso **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR)** interface habilitada por conta própria. `IPC` está habilitado por padrão, portanto você pode acessá-lo imediatamente, contanto que você não tenha desabilitado você mesmo.

Após o lançamento do programa, simplesmente navegue para o **[endereço IPC](http://localhost:1242)** do ASF. Se tudo funcionou correctamente, tu também poderás alterar a configuração do ASF.

---

## Configuração manual

Em geral, recomendamos fortemente o uso do nosso Gerador de Configuração ou da ASF-ui, como é muito mais fácil e garante que não cometerás um erro na estrutura JSON, mas se por algum motivo não quiseres, então tu também podes criar configurações adequadas manualmente. Verifica os exemplos JSON abaixo para um bom começo na estrutura correta, tu podes copiar o conteúdo em um arquivo e usá-lo como base para suas configurações. Uma vez que não estás a utilizar nenhum dos nossos frontend, certifique-se de que sua configuração é **[válida](https://jsonlint.com)**, já que o ASF não vai carregá-lo se ele não puder ser analisado. Mesmo se for um JSON válido, tu também precisas de garantir que todas as propriedades tenham o tipo adequado, conforme exigido pelo ASF. Para uma estrutura JSON adequada para todos os campos disponíveis, consulte a seção **[mapeamento JSON](#mapeamento-json)** e nossa documentação abaixo.

---

## Configuração Global

A configuração global está localizada no arquivo `ASF.json` e tem a seguinte estrutura:

```json
{
    "AutoRestart": true,
    "Blacklist": [],
    "CommandPrefix": "!",
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "CurrentCulture": null,
    "Debug": false,
    "DefaultBot": null,
    "FarmingDelay": 15,
    "FilterBadBots": true,
    "GiftsLimiterDelay": 1,
    "Headless": false,
    "IdleFarmingPeriod": 8,
    "InventoryLimiterDelay": 4,
    "IPC": true,
    "IPCPassword": null,
    "IPCPasswordFormat": 0,
    "LicenseID": null,
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldDuration": 15,
    "MinFarmingDelayAfterBlock": 60,
    "OptimizationMode": 0,
    "PluginsUpdateList": [],
    "PluginsUpdateMode": 0,
    "ShutdownIfPossible": false,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Todas as opções são explicadas abaixo:

### `Auto Reiniciar`

`bool` modelo com valor padrão de `true`. Esta propriedade define se o ASF pode auto-reiniciar quando necessário. Há alguns eventos que exigirão uma reinicialização automática do ASF. tal como a actualização do ASF (feita com o comando `UpdatePeriod` ou `atualize`), bem como com o `ASF.json` editar config, `reiniciar` e o mesmo. Normalmente, reiniciar inclui duas partes: criar um novo processo e terminar o atual. A maioria dos usuários deve estar bem com ela e manter essa propriedade com valor padrão de `verdadeiro`, No entanto - se você estiver executando o ASF através de seu próprio script e/ou com `dotnet`, você pode querer ter controle total sobre o início do processo, e evitar situações como ter um novo processo (reiniciado) do ASF sendo executado em segundo plano em algum lugar silenciosamente, e não no primeiro plano do script, que foi encerrado junto com o antigo processo do ASF. Isto é especialmente importante tendo em conta o facto de que o novo processo deixará de ser o seu filho directo, o que o tornaria impossível. . para usar a entrada padrão do console para isso.

If that's the case, this property if specially for you and you can set it to `false`. No entanto, tenha em mente que, nesse caso, **você** é responsável por reiniciar o processo. Isso é importante, já que o ASF só sairá ao invés de gerar um novo processo (por exemplo, após a atualização), então se você não adicionar nenhuma lógica, ela vai simplesmente parar de funcionar até que você o inicie novamente. O ASF sempre sai com o código de erro apropriado indicando sucesso (zero) ou insucesso (diferente de zero), dessa forma você pode adicionar a lógica correta em seu script que deve evitar o reinício automático do ASF em caso de falha, ou, pelo menos, fazer uma cópia local do log `. xt` para mais análise. Também tenha em mente que o comando `reiniciar` sempre irá reiniciar o ASF, independente de como essa propriedade é definida, como esta propriedade define o comportamento padrão, enquanto o comando `reiniciar` sempre reinicia o processo. A menos que você tenha um motivo para desativar esse recurso, você deve mantê-lo ativado.

---

### `Lista Negra`

`ImmutableHashSet<uint>` tipo com valor padrão vazio. Como o nome sugere, esta propriedade de configuração global define appIDs (jogos) que serão inteiramente ignorados pelo processo de coleta automático do ASF. Infelizmente, a Steam adora marcar as insígnias das promoções de verão/inverno como "disponível para receber cartas", que confunde o processo do ASF fazendo-o acreditar que é um jogo válido que deve ser coletado. Se não houvesse nenhum tipo de lista negra, o ASF acabaria por "travar" na coleta de um jogo que na verdade não é um jogo. e espere infinitamente pelo recebimento de cartas que não acontecerá. A lista negra do ASF serve para marcar essas insígnias como não disponíveis para a coleta, Assim, podemos ignorá-los silenciosamente ao decidir o que fazer a exploração agrícola e não cair na armadilha.

O ASF inclui duas listas negras por padrão - `SalesBlacklist`, que é codificado no código do ASF e não é possível editar, e a lista negra `normal`, que é definida aqui. `A lista negra` é atualizada juntamente com o ASF e normalmente inclui todos os appIDs "ruins" no momento do lançamento, então se você estiver usando o ASF atualizado então você não precisa manter sua própria `Lista Negra` definida aqui. O principal objetivo dessa propriedade é permitir que você adicione novos appIDs, não conhecidos no momento da liberação do ASF, que não devem ser coletados. `Vendas com Lista Negra` estão sendo atualizadas o mais rápido possível Portanto, não é necessário atualizar a sua própria `Blacklist` se você estiver usando a versão mais recente do ASF, mas sem `Lista Negra` você seria forçado a atualizar o ASF para "continuar rodando" quando a Valve liberar uma nova medalha de venda - eu não quero te forçar a usar o código mais recente do ASF. Portanto, essa propriedade está aqui para permitir que você "arrumando" o ASF se você mesmo não quiser ou não puder atualize para um novo codificado `Lista Negra` em uma nova versão do ASF, mas você quer manter seu antigo ASF rodando. A menos que você tenha uma razão **forte** para editar essa propriedade, você deve mantê-la padrão.

Se você está procurando uma lista negra baseada em bots em vez disso, dê uma olhada no `fb`, `fbadd` e `fbrm` **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `Prefixo`

Tipo `string` com valor padrão de `!`. Esta propriedade especifica o prefixo **sensível a maiúsculas e minúsculas** usado pelo ASF **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Em outras palavras, é isso que você precisa digitar antes de cada comando do ASF para fazer com que ele te ouça. É possível definir esse valor como `null` ou vazio para fazer com que o ASF não use nenhum prefixo de comando, em que caso insere comandos com identificadores simples. No entanto fazer isso pode diminuir o desempenho do ASF já que ele é otimizado para não analisar mensagens além se ele não começar com `CommandPrefix` - se você decidir não usá-la, O ASF será forçado a ler todas as mensagens e a responder a elas, mesmo se elas não forem comandos do ASF. Therefore it's recommended to keep using some `CommandPrefix`, such as `/` if you don't like default value of `!`. Para obter consistência, `CommandPrefix` afeta todo o processo do ASF. A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `ConfirmaçõesLimiterDelay`

Tipo `byte` com valor padrão de `10`. O ASF garantirá que haverá pelo menos `ConfirmationsLimiterDelay` segundos entre duas confirmações consecutivas de 2FA que buscam pedidos para evitar o limite de taxa de ativação - que são usadas por **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** durante o processo. . `2faok` comando, bem como conforme necessário, ao realizar várias operações relacionadas ao trading. O valor padrão foi definido com base em nossos testes e não deve ser reduzido se você não quiser ter problemas. A menos que você tenha uma razão **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `Timeout`

Tipo `byte` com valor padrão de `90`. Essa propriedade define o tempo limite em segundos para várias ações de rede feitas pelo ASF. Em particular, `ConnectionTimeout` define o tempo limite em segundos para solicitações HTTP e IPC, `Timeout / 10` define o número máximo de pulsos falhados, enquanto `Timeout / 30` define o número de minutos que permitimos a solicitação inicial de conexão da rede Steam. O valor padrão de `90` deve ser adequado para a maioria das pessoas, no entanto, se você tiver uma conexão de rede lenta ou PC, talvez você queira aumentar este número para algo mais alto (como `120`). Tenha em mente que valores maiores não vão magicamente resolver lentidão ou até mesmo servidores Steam inacessíveis, então não devemos esperar infinitamente por algo que não vai acontecer e simplesmente tentar novamente mais tarde. Definir um valor muito alto resultará em um atraso excessivo na captura de problemas de rede, bem como na diminuição do desempenho geral. Definir um valor muito baixo irá diminuir a estabilidade geral e o desempenho, já que o ASF abortará solicitações válidas que ainda estejam sendo analisadas. Portanto, definir este valor mais baixo do que o padrão não tem vantagem em geral. como servidores Steam tendem a ser muito lentos de vez em quando e podem exigir mais tempo para analisar pedidos do ASF. O valor padrão é um equilíbrio entre acreditar que nossa conexão de rede é estável e duvidar que a rede Steam manipule nosso pedido em determinado tempo limite. Se você deseja detectar problemas antes e fazer o ASF reconectar/responder mais rápido, valor padrão deve fazer (ou um pouco abaixo, como `60`, tornando o ASF menos paciente). Se você notar que o ASF está tendo problemas de rede, tais como falhas em solicitações, pulsos perdidos ou conexões com a Steam interrompidas, provavelmente faz sentido aumentar esse valor se você tiver certeza de que é **e não** causado pela sua rede, mas pela própria Steam, uma vez que aumentar o tempo de espera torna o ASF mais "paciente" e não decide se reconectar imediatamente.

Um exemplo de situação que pode exigir o aumento desse valor é permitir que o ASF lide com uma quantidade muito grande de ofertas de troca que podem demorar cerca de 2 minutos ou mais para serem totalmente aceitas e manipuladas pelo Steam. Aumentando o tempo padrão, O ASF será mais paciente e esperará mais tempo antes de decidir que a troca não está passando e abandonará o pedido inicial.

Outra situação pode ser causada por um computador ou uma conexão de internet muito lenta que requer mais tempo para lidar com os dados transmitidos. Essa é uma condição muito rara, já que o CPU/largura de banda quase nunca é um gargalo, mas ainda é uma possibilidade que vale a pena mencionar.

Em resumo, o valor padrão é suficiente para a maioria dos casos, mas você pode querer aumentá-lo se necessário. Ainda, indo muito acima do valor padrão também não faz muito sentido, já que tempos limite maiores não consertam magicamente servidores Steam inacessíveis. A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `Cultura-atual`

Tipo `string` com valor padrão `null`. Por padrão o ASF tenta usar o idioma do seu sistema operacional e preferirá usar as strings traduzidas para esse idioma se disponível. Isto é possível graças a nossa comunidade que tenta localizar **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** ASF para todos os idiomas mais populares. Se por algum motivo você não quiser usar o idioma nativo do seu SO, você pode usar esta propriedade de configuração para escolher qualquer idioma válido que você queira usar. Para obter uma lista de todos os idiomas disponíveis, por favor, visite **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** e procure a tag `Language`. É bom notar que o ASF aceita ambas culturas específicas, como `"pt-BR"`, mas também neutros como `"en"`. Especificar o idioma atual também afetará outros comportamentos regionais específicos, como formato de moeda/data e outros. Por favor, note que você pode precisar de pacotes de idioma/fontes adicionais para exibir caracteres específicos do idioma corretamente, se você escolheu um idioma não-nativo que faz uso deles. Normalmente você vai querer fazer uso desta propriedade se você preferir o ASF em inglês ao invés da sua língua nativa.

---

### `Debug`

Tipo `bool` com valor padrão de `false`. Esta propriedade define se o processo deve ser executado no modo de depuração. Quando no modo de depuração, o ASF cria uma pasta `especial debug` ao lado da pasta `config`, que mantém toda a comunicação entre o ASF e os servidores Steam. Informações de depuração podem ajudar a encontrar problemas estranhos relacionados à rede e ao fluxo de trabalho do ASF em geral. Além disso, algumas rotinas do programa serão muito mais detalhadas, tal como o `WebBrowser` informando o motivo exato de que alguns pedidos estão falhando - essas referências são gravadas no registro normal do ASF. **You should not run ASF in Debug mode, unless asked by developer**. Executar o ASF em modo de depuração **diminui o desempenho**, **afeta a estabilidade negativamente** e é **muito mais detalhado em vários lugares**, então deve ser usado **apenas** intencionalmente, a curto prazo, para depurar um problema específico, reproduzindo o problema ou obtendo mais informações sobre uma solicitação em falha, e da mesma forma, mas **não** para execução normal do programa. Você verá **muito** de novos erros, problemas, e exceções - certifique-se de que você tenha um conhecimento decente sobre o ASF, O Steam e suas peculiaridades se você decidir analisar tudo isso por conta própria, pois nem tudo é relevante.

**AVISO:** habilitar este modo inclui registro de informações **potencialmente sensíveis a** , como logins e senhas que você está usando para se conectar ao Steam (devido ao registro de rede). Os dados são gravados tanto no diretório `debug` quanto no log `padrão. xt` (isso agora intencionalmente é muito mais detalhado para registrar esta informação). Você não deve postar o conteúdo de depuração gerado pelo ASF em nenhum local público, O desenvolvedor do ASF sempre deve te lembrar de enviá-lo para seu e-mail, ou outro local seguro. Não estamos armazenando, nem fazendo uso desses detalhes confidenciais, elas estão escritas como parte das rotinas de depuração, já que sua presença pode ser relevante para o problema que está te afetando. Nós preferimos que se você não altere a forma como o ASF faz os registros, mas se você estiver preocupado você pode editar adequadamente esses detalhes confidenciais.

> A edição implica substituir detalhes sensíveis, por exemplo, por estrelas. Você não deve remover inteiramente as linhas confidenciais, já que sua existência pode ser relevante e deve ser preservada.

---

### `PadrãoBot`

Tipo `string` com valor padrão `null`. Em alguns cenários, o ASF funciona com um conceito de um bot padrão responsável por lidar com algo - por exemplo, comandos IPC ou console interativo quando você não especifica o bot de destino. This property allows you to choose default bot responsible for handling such scenarios, by putting its `BotName` here. Se o bot informado não existir, ou você usar um valor padrão de `null`, o ASF escolherá o primeiro bot registrado em ordem alfabética. Typically you want to make use of this config property if you want to omit `[Bots]` argument in IPC and interactive console commands, and always pick the same bot as the default one for such calls.

---

### `Atraso`

Tipo `byte` com valor padrão de `15`. Para que o ASF funcione, vai verificar o jogo que está sendo executado a cada `FarmingDelay` minutos, caso talvez já tenha coletado todas as cartas. Definir muito baixo essa propriedade pode resultar no envio de uma quantidade excessiva de solicitações a vapor enquanto configurá-lo muito alto pode resultar no ASF ainda "coletar" dado título para até o `FarmingDelay` minutos depois que ele é totalmente explorado. O valor padrão deve ser excelente para a maioria dos usuários, mas se você tem muitos bots em execução, você pode considerar aumentar para algo como `30` minutos para limitar o envio de pedidos do Steam. É legal notar que o ASF usa um mecanismo baseado em eventos e verifica a página de insígnia do jogo cada item que aparece no Steam, então em geral **nem precisamos verificá-lo em intervalos de tempo fixos**, mas como não confiamos totalmente na rede Steam - verificamos a página de insígnias do jogo mesmo assim, se não verificarmos através do evento de coleta de cartas nos últimos `minutos do FarmingDelay` (caso a rede Steam não nos informe sobre itens descartados ou coisas assim). Assumindo que a rede Steam está funcionando corretamente, diminuir este valor **não vai melhorar a eficiência da coleta de forma alguma**, enquanto **aumentando a sobrecarga de rede significativamente** - é recomendado aumentá-la apenas (se necessário) a partir do padrão `15` minutos. A menos que você tenha uma razão **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `FilterBadBots`

`bool` modelo com valor padrão de `true`. Esta propriedade define se o ASF rejeitará automaticamente ofertas de troca que são recebidas de agentes de má atividade conhecidos e marcados. Para fazer isso, o ASF se comunicará com nosso servidor conforme a necessidade para obter uma lista de identificadores Steam na lista negra. The bots listed are operated by people that are classified as harmful towards ASF initiative by us, such as those that violate our **[code of conduct](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, use provided functionality and resources by us such as **[`PublicListing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** in order to abuse and exploit other people, or are doing outright criminal activity such as launching DDoS attacks on the server. Já que o ASF tem uma posição forte sobre equidade geral, honestidade e cooperação entre seus usuários, a fim de fazer com que toda a comunidade prospere, esta propriedade é habilitada por padrão e, portanto, o ASF filtra bots que classificamos como prejudiciais a serviços oferecidos. A menos que você tenha uma razão **strong** para editar essa propriedade, tal como discordar com nossa declaração e intencionalmente permitir que esses bots funcionem (incluindo explorar suas contas), você deve mantê-la por padrão.

---

### `GiftsLimiterDelay`

Tipo `byte` com valor padrão de `1`. O ASF garantirá que haverá pelo menos `GiftsLimiterDelay` segundos entre duas manipulações consecutivas de gift/chave/licença (resgatar) para evitar limite de taxa de acionamento. Além disso, ele também será usado como limitador global para solicitações de lista de jogos, tal como o emitido por `é proprietário da` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. A menos que você tenha uma razão **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `Sem Cabeça`

Tipo `bool` com valor padrão de `false`. Esta propriedade define se o processo deve ser executado em modo não-interativo. Quando em modo headless, o ASF assume que está sendo executado em um servidor ou em outro ambiente não interativo, Por conseguinte, não tentará ler qualquer informação através da entrada no console. Isto inclui detalhes sob demanda (credenciais de conta como o código 2FA, o código SteamGuard, o código senha ou qualquer outra variável necessária para que o ASF opere) bem como todas as outras entradas de console (como o console de comando interativo). Em outras palavras, o modo `Headless` é igual a tornar o console do ASF somente leitura. Essa configuração é útil principalmente para usuários que executam o ASF em servidores, em vez de perguntar. . para código 2FA, o ASF simplesmente abortará a operação parando uma conta. A menos que você esteja executando o ASF em um servidor e você confirmou anteriormente que o ASF é capaz de operar em modo não-interativo, você deve manter essa propriedade desativada. Qualquer interação do usuário será negada quando estiver no modo headless, e suas contas não serão executadas se precisarem de **qualquer entrada** no console durante o início. Isso é útil para servidores, já que o ASF pode abortar ao tentar se conectar à conta quando solicitado credenciais, em vez de esperar (infinitamente) para que o usuário os forneça.

Ativar este modo permitirá que você forneça a entrada do console requerido por outros meios, ou seja, ASF-ui (ASF API), ou através do comando **[`entrada`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#input-command)**. If you're not sure how to set this property, leave it with default value of `false`.

---

### `Período IdleFarmingPeriod`

Tipo `byte` com valor padrão de `8`. Quando o ASF não tem nada para coletar, ele vai verificar periodicamente a cada horaformat@@0 do `FarmingPeriod` caso talvez sua conta tenha obtido novos jogos para coletar. Esse recurso não é necessário quando falamos de jogos novos, já que nesse caso o ASF verifica automaticamente as páginas de insígnias. `IdleFarmingPeriod` é principalmente para situações como jogos antigos que já temos cartas colecionáveis. Neste caso não há nenhum evento, então o ASF tem que verificar periodicamente as páginas de insígnias se quisermos que isso fique coberto. O valor de `0` desativa este recurso. Também confira: `ShutdownOnFarmingFinished` preference in `FarmingPreferences`.

---

### `Atraso`

Tipo `byte` com valor padrão de `4`. O ASF garantirá que haja pelo menos `InventoryLimiterDelay` segundos entre dois pedidos de inventário web consecutivos para evitar o limite de taxa de acionamento - esses são usados, por exemplo, durante notificações de inventário como lidas, Também pode ser usado por plugins de terceiros que buscam o inventário de outros usuários. Essa propriedade não é usada para buscar nosso próprio inventário, já que o ASF usa uma chamada de rede interna muito mais eficiente para isso, então ele não afetará comandos como `loot` ou `transfer` de qualquer forma. O valor padrão de `4` foi definido com base na marcação do inventário de mais de 100 contas bot consecutivas, e deve satisfazer a maioria dos usuários (se não todos). No entanto você pode querer reduzi-lo, ou até mesmo mudar para `0` se você tiver uma quantidade muito baixa de bots, então o ASF ignorará o atraso e marcará o inventário da Steam muito mais rápido. Porém seja avisado, uma vez que definir um **muito baixo irá** resultar no Steam banir temporariamente seu IP, e isso vai te impedir de fazer qualquer chamada. Você também pode precisar aumentar esse valor se estiver executando muitos bots com muitos pedidos de inventário, embora, neste caso, você deva provavelmente tentar limitar o número desses pedidos. A menos que você tenha uma razão **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `IPC`

`bool` modelo com valor padrão de `true`. Esta propriedade define se o servidor **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** deve ser iniciado junto com o processo. IPC permite a comunicação entre processos, incluindo o uso de **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, iniciando um servidor HTTP local. Se você não pretende usar nenhuma integração de terceiros com o ASF, incluindo nosso ASF-ui, você pode desativar essa opção com segurança. Caso contrário, é uma boa ideia mantê-lo ativado (opção padrão).

---

### `IPCPassword`

Tipo `string` com valor padrão `null`. Esta propriedade define a senha obrigatória para cada chamada de API feita através do IPC e serve como uma medida de segurança extra. Quando definido como valor não vazio, todas as solicitações do IPC exigirão uma propriedade `password` extra definida com a senha especificada aqui. O valor padrão de um `null` ignorará uma necessidade da senha, fazendo com que o ASF respeite todas as consultas. Além disso, habilitar essa opção também habilita o mecanismo interno IPC anti-bruteforce que irá banir temporariamente dada `IPAddress` após enviar muitas solicitações não autorizadas em muito pouco tempo. A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `Formato IPCsenha`

Tipo `byte` com valor padrão de `0`. Esta propriedade define o formato `propriedade IPCPassword` e usa `EHashingMethod` como tipo subjacente. Consulte a seção **[Segurança](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** se você quiser saber mais, já que você precisará garantir que a propriedade `IPCPassword` de fato inclui senha em correspondência `IPCPasswordFormat`. Por outras palavras, quando você alterar `IPCPasswordFormat` e então seu `IPCPassword` já deve ser **** nesse formato, não apenas visando ser. A menos que você saiba o que está fazendo, você deve mantê-lo com o valor padrão de `0`.

---

### `LicençaID`

`Guid? Tipo` com valor padrão de `null`. Esta propriedade permite que nosso **[patrocinador](https://github.com/sponsors/JustArchi)** melhore o ASF com recursos opcionais que exigem recursos pagos para funcionar. Por enquanto, isso permite o uso de **[`Matchativamente`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** recurso no plugin `ItemsMatcher`.

Apesar de recomendarmos que você utilize o GitHub, pois ele oferece níveis mensais e únicos, bem como permite a automação completa e permite acesso imediato **também** suporte todas as outras disponíveis atualmente **[opções de doação](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. Consulte **[este post](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** para obter instruções sobre como doar usando outros métodos a fim de obter uma licença manual válida para determinado período.

Independentemente do método usado, se você for patrocinador do ASF, você pode obter sua licença **[aqui](https://asf.justarchi.net/User/Status)**. Você precisará entrar com o GitHub para confirmar sua identidade, pedimos apenas informações públicas de somente leitura, que é o seu nome de usuário. `LicenseID` é composto por 32 caracteres hexadecimais, como `f6a0529813f74d119982eb4fe43a9a24`.

**Ensure that you do not share your `LicenseID` with other people**. Como é emitido com base pessoal, pode ser revogado se for vazado. Se por acaso isto aconteceu com você acidentalmente, você pode gerar um novo no mesmo lugar.

A menos que você deseje habilitar funcionalidades extras do ASF, não há necessidade de obter/fornecer a licença.

---

### `Atraso`

Tipo `byte` com valor padrão de `10`. O ASF garantirá que haverá pelo menos `LoginLimiterDelay` segundos entre duas tentativas consecutivas de conexão para evitar o limite de taxa de gatilho. O valor padrão de `10` foi definido com base na conexão de mais de 100 contas bot, e deve satisfazer a maioria dos usuários (se não todos). No entanto você pode querer aumentar/diminuí-lo, ou até mesmo mudar para `0` se você tiver uma quantidade muito baixa de bots, então o ASF ignorará o atraso e se conectará ao Steam muito mais rápido. Be warned though, as setting it too low while having too many bots **will** result in Steam temporarily banning your IP, and that will prevent you from logging in **at all**, with `InvalidPassword/RateLimitExceeded` error - and that also includes your normal Steam client, not only ASF. Da mesma forma, se você estiver rodando um número excessivo de bots, especialmente junto com outros clientes/ferramentas Steam usando o mesmo endereço IP, mais provável que você precise aumentar este valor a fim de espalhar os logins por um período de tempo mais longo.

Como nota, esse valor também é usado como amortecedor de balanceamento de carga em todas as ações regulares do ASF, tais como trocas em `SendTradePeriod`. A menos que você tenha uma razão **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `MaxFarmingTime`

Tipo `byte` com valor padrão de `10`. Como você deve saber, o Steam não está sempre funcionando corretamente, Por vezes acontecem situações estranhas, como o nosso tempo de jogo não está a ser registado, apesar de, de facto, se estar a jogar. O ASF vai coletar um único jogo no modo solo pelo máximo de `MaxFarmingTime` horas, e considerá-lo totalmente explorado após esse período. Isto é necessário para não congelar o processo agrícola em caso de ocorrência de situações estranhas, mas também se, por algum motivo, a Steam lançar uma nova insígnia que impediria o ASF de progredir mais (veja: `Blacklist`). O valor padrão de `10` horas deve ser suficiente para receber todas as cartas Steam de um jogo. Definir uma propriedade muito baixa pode resultar em jogos válidos serem ignorados (e sim, há jogos válidos que levam até 9 horas para a coleta), enquanto definir um valor muito alto pode resultar no congelamento do processo de coleta. Por favor, note que esta propriedade afeta apenas um único jogo em uma única sessão de coleta (por isso, após passar por toda a fila, o ASF retornará a esse título), também ele não é baseado no total de tempo de jogo, mas no tempo de coleta interno do ASF, então o ASF também retornará para esse título após uma reinicialização. A menos que você tenha uma razão **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `MaxTradeHoldDuration`

Tipo `byte` com valor padrão de `15`. Esta propriedade define a duração máxima da retenção de trocas em dias que estamos dispostos a aceitar - o ASF rejeitará trocas que estejam sendo retidas por mais de format@@0 `MaxTradeHoldDuration` dias, conforme definido na seção **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**. Esta opção só faz sentido para bots com `TradingPreferences` do `SteamTradeMatcher`, como isso não afeta as trocas `Master`/`SteamOwnerID` , nem doações. Trocas retidas são irritantes para todos, e ninguém quer lidar com elas. É suposto que o ASF funcione com regras liberais e ajude a todos, independente se no controle de trocas ou não - é por isso que essa opção é definida como `15` por padrão. No entanto, se você preferir rejeitar todas as transações afetadas pela retenção de trocas, você pode especificar `0` aqui. Por favor, considere o fato de que cartas com vida curta não são afetadas por esta opção e rejeitadas automaticamente para pessoas com retenção de trocas, conforme descrito na seção **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** , Portanto, não há necessidade de rejeitar globalmente toda a gente apenas por causa disso. A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.


---

### `BlocoMinFarmingDelayAfterBlock`

Tipo `byte` com valor padrão de `60`. Esta propriedade define a quantidade mínima de tempo, em segundos, que o ASF esperará antes de retomar a coleta de cartas caso tenha sido previamente desconectado do `LoggedInElsewhere`, o que acontece quando você decide desconectar forçosamente a coleta atual do ASF iniciando um jogo. Este atraso existe principalmente por razões de conveniência e de excesso de desempenho. por exemplo, ele permite que você reinicie o jogo sem precisar lutar com o ASF que ocupa sua conta novamente só porque o bloqueio de jogo estava disponível por um segundo dividido. Devido ao fato de que a recarga da sessão causa uma desconexão `LoggedInElsewhere` (LoggedInElsewhere A), o ASF tem de passar por todo o procedimento de reconexão, que coloca pressão adicional na máquina e na rede Steam, portanto evitar desconexões adicionais, se possível, é preferível. Por padrão, isso é configurado em `60` segundos, o que deve ser suficiente para permitir que você reinicie o jogo sem muita complicação. No entanto, há cenários em que você pode estar interessado em aumentá-lo, por exemplo, se a sua rede desconectar com frequência e o ASF tomar conta muito em breve, o que faz com que seja obrigado a passar pelo processo de reconexão. Nós permitimos um valor máximo de `255` para essa propriedade, que deve ser suficiente para todos os cenários comuns. Além do acima, também é possível diminuir o atraso, ou até mesmo remova-o inteiramente com um valor de `0`, embora isso não seja geralmente recomendado por razões acima mencionadas. A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `OtimizationMode`

Tipo `byte` com valor padrão de `0`. Esta propriedade define o modo de otimização que o ASF vai preferir durante o tempo de execução. Atualmente, o ASF suporta dois modos - `0` que se chama `MaxPerformance`, e `1` que se chama `MinMemoryUsage`. Por padrão, o ASF prefere executar o máximo de coisas em paralelo (simultaneamente) possível. que melhora o desempenho pelo balanceamento de carga funciona entre todos os núcleos de CPU, vários threads de CPU, soquetes múltiplos e várias tarefas de pool de threads. Por exemplo, o ASF solicitará sua primeira página de insígnias quando procurar jogos para coletar, e então uma vez que o pedido chegar, O ASF lerá a partir dele quantas páginas de insígnias você tem, e então solicitará uma à outra simultaneamente. Isso é o que você deve querer **quase sempre**, , já que a sobrecarga na maioria dos casos é mínima e os benefícios do código assíncrono do ASF pode ser visto até mesmo no hardware mais antigo com um único núcleo de CPU e potência fortemente limitada. No entanto, com muitas tarefas sendo processadas em paralelo, o tempo de execução do ASF é responsável por sua manutenção, por exemplo, manter soquetes abertos, threads vivos e tarefas sendo processadas, o que pode resultar em aumento de uso de memória de tempos em tempos e se você é extremamente restrito pela memória disponível, você pode querer mudar esta propriedade para `1` (`MinMemoryUsage`) a fim de forçar o ASF a usar o menor número possível de tarefas. e normalmente rodando possíveis códigos assíncronos paralelos de forma síncrona. Você deve considerar mudar essa propriedade somente se você leu anteriormente **[configuração de pouca memória](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** e você quer sacrificar intencionalmente um aumento gigantesco de desempenho, para uma diminuição muito pequena da sobrecarga de memória. Normalmente, esta opção é **muito pior** do que o que você pode conseguir com outras formas possíveis, tal como limitando o uso do ASF ou ajustando o coletor de lixo do tempo de execução, conforme explicado em **[configuração de pouca memória](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Portanto, você deve usar `MinMemoryUsage` como um **último recurso**, antes de recompilar o tempo de execução, se você não conseguiu alcançar resultados satisfatórios com outras opções (muito melhores). A menos que você tenha uma razão **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `PluginsUpdateList`

`ImmutableHashSet<string>` tipo com valor padrão vazio. Esta propriedade define a lista de nomes de conjuntos de plugins que estão na lista negra ou na lista branca para serem considerados para atualizações automáticas, como por `PluginsUpdateMode` definido abaixo.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `PluginsUpdateMode`

Tipo `byte` com valor padrão de `0`. Esta propriedade define o modo de atualização de plugins que dão significado a `PluginsUpdateList` definido acima. Especificando essa propriedade você pode facilmente habilitar/desabilitar atualizações automáticas para todos os plugins, exceto os declarados.

- Valor de `0`, chamado `Whitelist`, **desabilita a atualização automática** de todos os plugins, exceto os definidos na `PluginsUpdateList`.
- Valor de `1`, chamado `Blacklist`, **permite a atualização automática** de todos os plugins, exceto os definidos em `PluginsUpdateList`.

**ASF team would like to remind you that, for your own safety, you should enable automatic updates only from trusted parties**. Tenha em mente que plugins maliciosos podem decidir por si mesmos ou executar comandos remotos **independente de** dessa configuração, é por isso que essa configuração se aplica à funcionalidade de atualização de plugins fornecidos pelo ASF, exclusivamente, e você ainda deve garantir que verificou adequadamente cada plugin que decidiu usar.

As atualizações de plugins são realizadas por padrão juntamente com a rotina de atualização do ASF - **[`UpdateChannel`](#updatechannel)** e **[`UpdatePeriod`](#updateperiod)**. Standard ASF update mechanisms such as `update` command will also trigger optional plugins update. Se em vez disso, você gostaria de atualizar plugins manualmente sem atualizar a versão do ASF ao mesmo tempo, o comando `updateplugins` oferece essa possibilidade.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `DesligamentoPossível`

Tipo `bool` com valor padrão de `false`. Quando habilitado, o ASF tentará desligar o processo, se possível, isto é, quando todos os seus bots registrados forem interrompidos. Isso pode ser especialmente útil quando combinado com `ShutdownOnFarmingFinished` em todos os seus bots de conta, já que dessa forma o ASF será autorizado a desligar automaticamente quando o último dos seus bots terminar a coleta.

Uma vez que a expectativa da maioria dos usuários é de que o processo funcione em todos os momentos. . para o uso `IPC` , esta opção é desativada por padrão.

---

### `Prefixo`

Tipo `string` com valor padrão de `"/me "`. Esta propriedade define um prefixo que será anexado a todas as mensagens da Steam enviadas pelo ASF. Por padrão o ASF usa o prefixo `"/me "` para distinguir as mensagens dos bots mais facilmente, mostrando-as em cores diferentes no chat Steam. Outro prefixo digno de menção é `"/pre"` que atinge resultados semelhantes, mas usa uma formatação diferente. Você também pode definir essa propriedade como vazia ou como `null` para desativar inteiramente o uso do prefixo e enviar todas as mensagens do ASF de uma forma tradicional. É bom notar que esta propriedade afeta apenas mensagens do Steam - as respostas retornadas através de outros canais (como IPC) não são afetadas. A menos que você deseje personalizar o comportamento padrão do ASF, é uma boa ideia deixá-lo assim.

---

### `SteamOwnerID`

Tipo `ulong` com valor padrão de `0`. Esta propriedade define o Steam ID em formato de 64-bit do proprietário do processo ASF, e é muito semelhante à permissão `Master` da conta bot especificada (mas global em vez disso). Você vai querer definir quase sempre essa propriedade com o ID da sua própria conta Steam principal. `Master` permission includes full control over his bot instance, but global commands such as `exit`, `restart` or `update` are reserved for `SteamOwnerID` only. Isto é conveniente, já que você pode querer executar bots para seus amigos não permite que eles controle o processo ASF, tal como sair dele através do comando `exit`. O valor padrão de `0` especifica que não há proprietário do processo ASF, o que significa que ninguém será capaz de emitir comandos globais do ASF. Tenha em mente que esta propriedade se aplica exclusivamente ao chat Steam. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, bem como um console interativo, irá permitir que você execute os comandos `do Proprietário` mesmo que esta propriedade não esteja definida.

---

### `Protocolos SteamProtocols`

`byte flags` tipo com valor padrão de `7`. Esta propriedade define os protocolos Steam que o ASF usará ao se conectar aos servidores Steam, que são definidos abaixo:

| Valor | Nome      | Descrição                                                                                            |
| ----- | --------- | ---------------------------------------------------------------------------------------------------- |
| 0     | Nenhum    | No protocol                                                                                          |
| 1     | TCP       | **[Protocolo de Controle Transmissão](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2     | UDP       | **[Protocolo do Datagrama do Usuário](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**        |
| 4     | WebSocket | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                                             |

Note que esta propriedade é um campo `flags` , portanto é possível escolher qualquer combinação de valores disponíveis. Confira o mapeamento **[json](#json-mapping)** se você quiser saber mais. Não habilitar nenhum flag resulta na opção `None` , e essa opção é inválida, por si só.

Por padrão o ASF usará todos os protocolos Steam disponíveis como uma medida para lutar contra tempos de inatividade e outras questões semelhantes da Steam. Normalmente você vai querer alterar essa propriedade se desejar limitar o ASF para usar apenas um ou dois protocolos específicos. Tais medidas poderiam ser necessárias em diversas situações, por exemplo, se você bloqueou o tráfego UDP no seu firewall e deseja garantir que somente o tráfego TCP passe ou se você estiver usando `WebProxy` e quer usá-lo também para a conexão de cliente Steam, como apenas o protocolo `WebSocket` suporta isso.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `AtualizarCanal`

Tipo `byte` com valor padrão de `1`. Esta propriedade define o canal de atualização que está sendo usado, seja para atualizações automáticas (se `UpdatePeriod` é maior que `0`), ou atualizar as notificações (caso contrário). Atualmente, o ASF suporta três canais de atualização - `0` que é chamado de `None`, `1`, que se chama `Estábulo`, e `2`, que se chama `PreRelease`. O canal `Estável` é o canal de lançamento padrão, que deve ser usado pela maioria dos usuários. `Pré-lançamento de canais` além de versões `Estável` , também inclui **pre-releases** dedicado a usuários avançados e outros desenvolvedores para testar novos recursos, confirmar correções de erros ou dar feedback sobre melhorias planejadas. **As versões de pré-lançamento geralmente contêm bugs não corrigidos, trabalhos em andamento ou implementações reescritas**. Se você não se considera um usuário avançado, por favor, fique com o canal de atualização padrão `1` (`Stable`. `PreRelease` canal é dedicado aos usuários que sabem como relatar bugs, Lidar com problemas e dar feedback, não será dado qualquer apoio técnico. Confira o ciclo de versões **[do ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** se você quiser aprender mais. Você também pode definir `UpdateChannel` para `0` (`None`), se você quiser remover completamente todas as verificações de versão. Configurar o `UpdateChannel` para `0` desativará inteiramente toda funcionalidade relacionada com atualizações, incluindo o comando `atualização`. Usar `Nenhum` canal é **fortemente desencorajado** porque você se expõe a todo o tipo de problemas (mencionados em `UpdatePeriod` descrições abaixo).

**A menos que você saiba o que está fazendo**, nós recomendamos **forte** mantê-lo padrão.

---

### `UpdatePeriod`

Tipo `byte` com valor padrão de `24`. Esta propriedade define quantas vezes o ASF deve procurar por atualizações automáticas. As atualizações são cruciais não só para receber novos recursos e correções de segurança críticas, mas também para receber correções de bugs, melhorias de desempenho, melhorias de estabilidade e muito mais. Quando um valor maior que o `0` for definido, o ASF irá automaticamente baixar, substituir, e reinicie-se (se `AutoReiniciar` permite) quando uma nova atualização estiver disponível. In order to achieve this, ASF will check every `UpdatePeriod` hours if new update is available on our GitHub repo. Um valor de `0` desativa atualizações automáticas, mas ainda permite que você execute o comando `atualizar` manualmente. Você também pode estar interessado em configurar o `UpdateChannel` apropriado que o `UpdatePeriod` deve seguir.

O processo de atualização do ASF envolve atualização da estrutura inteira da pasta que o ASF está usando, mas sem tocar em suas próprias configurações ou bancos de dados localizados na pasta `config` - isso significa que quaisquer arquivos extras não relacionados com o ASF em sua pasta podem ser perdidos durante a atualização. O valor padrão de `24` é um bom equilíbrio entre verificações desnecessárias e o ASF já está fresco.

A menos que você tenha uma razão **strong** para desativar esse recurso, você deve manter as atualizações automáticas habilitadas dentro de `UpdatePeriod` **para o seu próprio**. Isso não acontece apenas porque não suportamos nada além da última versão estável do ASF, mas também porque **nós fornecemos nossa garantia de segurança apenas para a última versão**. Se você está usando uma versão desatualizada do ASF então está intencionalmente se expondo a todo o tipo de problemas, desde pequenos bugs, até funcionalidades quebradas, terminando com **[permanente conta Steam suspensões](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**, então nós recomendamos **fortemente**, para seu próprio bem, para sempre garantir que sua versão do ASF esteja atualizada. Atualizações automáticas nos permitem reagir rapidamente a todo o tipo de problema, desativando ou remendando códigos problemáticos antes que ele possa se agravar - se você optar por não fazê-lo, você perde todas as nossas garantias de segurança e corre o risco de sofrer consequências de um código que pode ser potencialmente prejudicial, Não apenas a rede Steam, mas também (por definição) para a sua própria conta Steam.

---

### `Delay`

Tipo `ushort` com valor padrão de `300`. Esta propriedade define, em milissegundos, a quantidade mínima de atraso entre o envio de dois pedidos consecutivos para o mesmo serviço web do Steam. Tal atraso é necessário pois o serviço **[AkamGhost](https://www.akamai.com)** que o Steam usa internamente inclui um limitador com base no número global de solicitações enviadas em determinado período de tempo. Em circunstâncias normais, o bloqueio da akamai é bastante difícil de atingir, mas sob cargas de trabalho muito pesadas com uma enorme fila de pedidos em andamento, É possível acioná-lo, se continuarmos enviando muitas solicitações por um período de tempo muito curto.

Default value was set based on assumption that ASF is the only tool accessing Steam web-services, in particular `steamcommunity.com`, `api.steampowered.com` and `store.steampowered.com`. If you're using other tools sending requests to the same web-services then you should make sure that your tool includes similar functionality of `WebLimiterDelay` and set both to double of default value, which would be `600`. Isso garante que, sob nenhuma circunstância, você vai exceder o envio de mais de 1 pedido por `300` ms.

Em geral Diminuir o `WebLimiterDelay` abaixo do valor padrão é **fortemente desencorajado** , pois poderia levar a vários blocos relacionados ao IP, Algumas das quais podem ser permanentes. O valor padrão é bom o suficiente para executar uma instância única do ASF no servidor, Além de usar o ASF em um cenário normal juntamente com o cliente Steam original. Deve estar correto para a maioria dos usos e você só deve aumentá-lo (nunca diminuir). Em resumo, número global de todas as solicitações enviadas a partir de um único IP para um único domínio da Steam nunca deve exceder mais de 1 solicitação por `300` ms.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `WebProxy`

Tipo `string` com valor padrão `null`. Esta propriedade define um endereço de proxy web que será usado para comunicação interna HTTP, especialmente para serviços como `github. om`, `api.steampowered.com`, `steamcommunity.com` e `store.steampowered.com`. It applies to general (non-bot specific) communication, as well as bot-specific communication if their equivalent `WebProxy` configuration property is not set. Solicitações de proxy do ASF pode ser excepcionalmente útil para contornar vários tipos de firewalls, especialmente o grande firewall da China.

Essa propriedade é definida como uma sequência de caracteres uri:

> Uma string URI é composta por um esquema (suportado: http/https/socks4/socks4a/socks5), um host e uma porta opcional. Um exemplo de uri completo é `"http://contoso.com:8080"`.

Se seu proxy requer autenticação de usuário, você também precisará configurar a `WebProxyUsername` e/ou `WebProxyPassword`. Se não há tal necessidade, configurar somente essa propriedade é suficiente.

Se você também precisa da comunicação da rede Steam interna (Proxying Network) então você deve configurar a propriedade **[`SteamProtocols`](#steamprotocols)** para um valor que permite apenas o transporte de websocket, i. . um valor de `4`, como apenas websockets são suportados para proxing.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `Senha`

Tipo `string` com valor padrão `null`. Esta propriedade define a senha usada em campo basic, digest, NTLM, e autenticação Kerberos que é suportada por uma máquina `WebProxy` que fornece funcionalidade proxy. Se o seu proxy não requer credenciais de usuário, não há necessidade de você inserir nada aqui. Usar esta opção só faz sentido se o `WebProxy` também for usado, já que ele não tem efeito caso contrário.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `WebProxyUsername`

Tipo `string` com valor padrão `null`. Esta propriedade define o nome de usuário usado em basic, digest, NTLM, e autenticação Kerberos que é suportada por uma máquina `WebProxy` que fornece funcionalidade proxy. Se o seu proxy não requer credenciais de usuário, não há necessidade de você inserir nada aqui. Usar esta opção só faz sentido se o `WebProxy` também for usado, já que ele não tem efeito caso contrário.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

## Bot config

Como você já deve saber, cada bot deve ter sua própria configuração baseada no exemplo de estrutura JSON abaixo. Comece decidindo como você quer nomear seu bot (por exemplo, `1.json`, `principal. son`, `primary.json` ou `AnythingElse.json`) e vá para configuração.

**Notice:** Bot can't be named `ASF` (as that keyword is reserved for global config), ASF will also ignore all configuration files starting with a dot.

A configuração do bot tem a seguinte estrutura:

```json
{
    "AcceptGifts": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Enabled": false,
    "FarmingOrders": [],
    "FarmingPreferences": 0,
    "GamesPlayedWhileIdle": [],
    "GamingDeviceType": 1,
    "HoursUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "MachineName": null,
    "MatchableTypes": [5],
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "RedeemingPreferences": 0,
    "RemoteCommunication": 3,
    "SendTradePeriod": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "TransferableTypes": [1, 3, 5],
    "UseLoginKeys": true,
    "UserInterfaceMode": 0,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Todas as opções são explicadas abaixo:

### `Presentes`

Tipo `bool` com valor padrão de `false`. Quando habilitado, o ASF vai aceitar e resgatar automaticamente todos os presentes Steam (incluindo vales-presente da carteira) enviados para o bot. Isso também inclui presentes enviados de usuários que não estejam definidos no `SteamUserPermissions`. Tenha em mente que presentes enviados para o endereço de e-mail não são encaminhados diretamente para o cliente, então o ASF não os aceitará sem a sua ajuda.

Esta opção é recomendada apenas para contas alternativas, já que é muito provável que você não queira resgatar automaticamente todos os presentes enviados para sua conta principal. If you're unsure whether you want this feature enabled or not, keep it with default value of `false`.

---

### `Comportamento baixo`

`byte flags` tipo com valor padrão de `0`. Esta propriedade define o comportamento do bot do ASF durante vários eventos e é definida abaixo:

| Valor | Nome                             | Descrição                                                                                                         |
| ----- | -------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| 0     | Nenhum                           | Sem comportamento especial de bot, configurações padrão sane                                                      |
| 1     | RejeitarInvalidAmiamInvitais     | Fará com que o ASF rejeite (ao invés de ignorar) convites de amizade inválidos                                    |
| 2     | RejeitarInvalidadoTrocas         | Fará com que o ASF rejeite (ao invés de ignorar) ofertas de troca inválidas                                       |
| 4     | RejeitarInvalidadeInvitações     | Fará com que o ASF rejeite (ao invés de ignorar) convites inválidos para grupos                                   |
| 8     | Notificações                     | Fará com que o ASF descarte automaticamente todas as notificações de inventário                                   |
| 16    | Ler                              | Fará com que o ASF marque automaticamente todas as mensagens recebidas como lidas                                 |
| 32    | Marcar                           | Fará com que o ASF marque automaticamente mensagens de outros bots ASF (executando na mesma instância) como lidas |
| 64    | DesabilitarIncomingTradesParsing | Fará com que o ASF nunca processe ofertas de troca recebidas                                                      |

Note que esta propriedade é um campo `flags` , portanto é possível escolher qualquer combinação de valores disponíveis. Confira o mapeamento **[json](#json-mapping)** se você quiser saber mais. Não habilitar nenhum dos resultados de sinalizadores em `Nenhuma opção`.

Em geral você deseja modificar esta propriedade se você espera alterar várias configurações de automação relacionadas à atividade do bot. As configurações padrão envolvem que o ASF rode em modo não invasivo, o que permite apenas automação benéfica que não vai contra a vontade do usuário.

Convite de amizade inválido é um convite que não vem de um usuário com a permissão `FamilySharing` (definida em `SteamUserPermissions`) ou superior. No modo normal o ASF ignora esses convites, como seria de esperar, dando-lhe liberdade de escolha se deseja aceitá-los ou não. `RejectInvalidFriendInvites` fará com que esses convites sejam rejeitados automaticamente, que praticamente desabilitará a opção para que outras pessoas te adicionem na lista de amigos (já que o ASF negará todos esses pedidos, além das pessoas definidas em `SteamUserPermissions`). A menos que você queira negar completamente todos os convites de amizade, você não deve habilitar esta opção.

Oferta de troca inválida é uma oferta que não é aceita pelo módulo interno do ASF. Mais sobre este assunto pode ser encontrado na seção **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** que define explicitamente quais tipos de trocas o ASF está disposto a aceitar automaticamente. Trocas válidas também são definidas por outras configurações, especialmente `TradingPreferences`. `RejectInvalidTrades` fará com que todas as ofertas de trocas inválidas sejam rejeitadas, em vez de serem ignoradas. A menos que queira negar completamente todas as ofertas de troca que não são automaticamente aceitas pelo ASF, você não deve habilitar esta opção.

Convite de grupo inválido é um convite que não vem do grupo `SteamMasterClanID`. No modo normal o ASF ignora esses convites, como seria de esperar, permitindo que você decida se quer entrar em um determinado grupo Steam ou não. `RejectInvalidGroupInvites` fará com que todos os convites para grupos sejam rejeitados automaticamente, torna impossível convidá-lo para qualquer outro grupo que não o `SteamMasterClanID`. A menos que você queira negar completamente todos os convites de grupo, você não deve habilitar esta opção.

`DismissInventoryNotifications` é extremamente útil quando você começa a ficar irritado com a constante notificação do Steam sobre novos itens. O ASF não pode se livrar da notificação em si, pois ela é embutida no seu cliente Steam, mas ele é capaz de limpar automaticamente a notificação após recebê-la, que não deixará mais a notificação de "novos itens no inventário" pendurada. Se você espera avaliar por sua conta todos os itens recebidos (especialmente as cartas coletadas com o ASF), então você naturalmente não deve habilitar essa opção. Quando você começar a enlouquecer, lembre-se disso é oferecido como opção.

`MarkReceivedMessagesAsRead` marcará automaticamente **todas as mensagens** recebidas pela conta em que o ASF está sendo executado, tanto privado como de grupo, como lido. Essa opção normalmente deve ser usada em contas alternativas apenas para limpar a notificação de "nova mensagem", por exemplo, durante a execução de comandos do ASF. Não recomendamos esta opção para contas principais, a menos que você queira desativar qualquer tipo de novas notificações de mensagens, U **incluindo** aqueles que aconteceram enquanto você estava offline, assumindo que o ASF ainda estava aberto em dispensa-lo.

`MarkBotMessagesAsRead` funciona de forma similar, marcando apenas as mensagens do bot como lidas. No entanto, tenha em mente que ao usar essa opção nos chats em grupo com seus bots e outras pessoas, Implementação do Steam ao reconhecer a mensagem **também** reconhece todas as mensagens que aconteceram **antes de** aquela que você decidiu marcar portanto, se por qualquer chance você não quiser perder uma mensagem não relacionada que aconteceu entre si, você normalmente quer evitar usar esse recurso. Obviamente, também é arriscado quando você tem várias contas primárias (por exemplo, de diferentes usuários) sendo executadas na mesma instância do ASF, já que você também pode perder as mensagens normais fora do ASF.

`DesabilitIncomingTradesParsing` impedirá o ASF de analisar ofertas de troca recebidas, isso significa que toda a funcionalidade de troca relacionada a isso não funcionará. Uma vez que o ASF funciona no modo menos invasivo por padrão, aceita apenas as ofertas de trocas dos usuários `Mestre` e acima, nunca tocar em outras ofertas de negociação - a análise de negociações de entrada é habilitada por padrão. Esta configuração faz mais sentido para pessoas que gostariam de garantir que não há solicitações ou sobrecarga adicionais relacionadas ao processamento de negociações, desabilitando toda a lógica em processo, Por exemplo, porque eles sabem que seus bots nunca receberão solicitações gerais de troca, e, portanto, não exija que o ASF participe em sua atividade de troca. Tenha em mente que ter esta opção especificada desativará todas as outras opções que dependem de negociações de entrada também, tais como `AcceptDonations` ou `SteamTradeMatcher` - plugins personalizados também não serão capazes de processar ofertas de troca de acordo com o costume.

Se você está inseguro de como configurar esta opção, é melhor deixá-la padrão.

---

### `CompleteTypesToSend`

`ImmutableHashSet<byte>` tipo com valor padrão vazio. Quando ASF termina de completar um determinado conjunto de itens especificados aqui, pode automaticamente enviar trocas Steam com todos os conjuntos concluídos para o usuário com a permissão `Master` , que é muito conveniente se você gostaria de utilizar a conta bot indicada para e. . Correspondência STM, ao mover os conjuntos concluídos para alguma outra conta. This option works the same as `loot` command, therefore keep in mind that it requires user with `Master` permission set, you may also need a valid `SteamTradeToken`, as well as using an account that is eligible for trading in the first place.

A partir de hoje, os seguintes tipos de itens são suportados nesta configuração:

| Valor | Nome            | Descrição                                                                   |
| ----- | --------------- | --------------------------------------------------------------------------- |
| 3     | FoilTradingCard | Variante brilhante de `Carta Comercial`                                     |
| 5     | TradingCard     | Cartas colecionáveis Steam, usadas para fabricar insígnias (não brilhantes) |

Observe que, independentemente das configurações acima, O ASF só pedirá por **[itens da comunidade Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` de 753, `contextID` de 6), então todos os itens de jogo, presentes e semelhantes, são excluídos da oferta de negociação por definição.

Devido a sobrecarga adicional ao usar esta opção, É recomendado usá-lo apenas em contas bot que tenham uma chance realista de terminar conjuntos por conta própria - por exemplo, não faz sentido ativar se você já está usando `SendOnFarmingFinished` preference in `FarmingPreferences`, `Normalmente o comando SendTradePeriod` ou `saque`.

Se você está inseguro de como configurar esta opção, é melhor deixá-la padrão.

---

### `CustomGamePlayedWhileFarming`

Tipo `string` com valor padrão `null`. Quando o ASF está coletando, ele pode se mostrar como "Jogando jogo não Steam: `CustomGamePlayedWhileFarming`ao invés do jogo que atualmente está sendo executado. Isso é útil se você quiser que seus amigos saibam que você está coletando, ainda assim você não quer usar `OnlineStatus` of `Offline`. Por favor, note que o ASF não pode garantir a ordem de exibição atual da rede Steam, Por conseguinte, trata-se apenas de uma sugestão que pode, ou não, ser apresentada de forma adequada. Em particular, nome personalizado não será exibido no algorítimo de coleta `Complexo` se o ASF preencher todos os slots `32` com jogos que precisam de horas para serem bombeados. O valor padrão de `null` desativa este recurso.

O ASF fornece algumas variáveis especiais que você pode opcionalmente usar em seu texto. `{0}` será substituído pelo ASF por `AppID` dos jogos que atualmente estão sendo executados, enquanto `{1}` será substituído pelo ASF por `GameName` do(s) jogo(s) que atualmente está sendo executado(s).

---

### `CustomGamePlayedWhiledle`

Tipo `string` com valor padrão `null`. Semelhante a `CustomGamePlayedWhileFarming`, mas para a situação quando o ASF não tem nada a fazer (já que a conta é totalmente explorada). Por favor, note que o ASF não pode garantir a ordem de exibição atual da rede Steam, Por conseguinte, trata-se apenas de uma sugestão que pode, ou não, ser apresentada de forma adequada. Se você está usando `GamesPlayedWhileIdle` junto com esta opção, então tenha em mente que `GamesPlayedWhileIdle` tem prioridade, Portanto, você não pode declarar mais do que `31` como de outra forma `CustomGamePlayedWhileIdle` não será capaz de ocupar o slot para um nome personalizado. O valor padrão de `null` desativa este recurso.

---

### `Ativado`

Tipo `bool` com valor padrão de `false`. Esta propriedade define se o bot está habilitado. A instância bot habilitada (`true`) será iniciada automaticamente quando o ASF for executado, enquanto bot desativado (`false`) precisará ser iniciado manualmente. Por padrão, cada bot está desabilitado, então você provavelmente quer mudar essa propriedade para `verdadeiro` para todos os bots que devem ser iniciados automaticamente.

---

### `Ordens agrícolas`

`ImmutableList<byte>Tipo` com valor padrão vazio. Esta propriedade define a ordem **preferida de coleta** usada pelo ASF para determinada conta bot. Atualmente existem as seguintes ordens disponíveis:

| Valor | Nome                       | Descrição                                                                                             |
| ----- | -------------------------- | ----------------------------------------------------------------------------------------------------- |
| 0     | Desordenado                | Sem ordenação, melhorando ligeiramente a performance da CPU                                           |
| 1     | Crescente                  | Try to farm games with lowest `appIDs` first                                                          |
| 2     | Descendente                | Try to farm games with highest `appIDs` first                                                         |
| 3     | CardDropsAscendente        | Tenta coletar dos jogos com o menor número de cartas disponíveis primeiro                             |
| 4     | CardDropsDescendente       | Tenta coletar dos jogos com o maior número de cartas disponíveis primeiro                             |
| 5     | Crescente                  | Tenta coletar dos jogos com o menor número de horas jogadas primeiro                                  |
| 6     | Descendente                | Tenta coletar dos jogos com o maior número de horas jogadas primeiro                                  |
| 7     | NomesAscendente            | Tenta coletar dos jogos em ordem alfabética, começando do A                                           |
| 8     | Descendente                | Tenta coletar dos jogos em ordem alfabética reversa, começando do Z                                   |
| 9     | Aleatório                  | Tenta coletar dos jogos em ordem totalmente aleatória (diferente cada vez que o programa é executado) |
| 10    | Crescente                  | Tenta coletar dos jogos com o nível de insígnia mais baixo primeiro                                   |
| 11    | Descendente                | Tenta coletar dos jogos com o nível de insígnia mais alto primeiro                                    |
| 12    | Ascendente                 | Tenta coletar dos jogos mais antigos em sua conta primeiro                                            |
| 13    | RedeemDateTimesDescendente | Tenta coletar dos jogos mais novos em sua conta primeiro                                              |
| 14    | Ascendente                 | Tenta coletar dos jogos com cartas não comercializáveis primeiro (aviso: caro para calcular)          |
| 15    | Descendente                | Tenta coletar dos jogos com cartas comercializáveis primeiro (aviso: caro para calcular)              |

Como essa propriedade é um array, ela permite que você use várias configurações diferentes em sua ordem fixa. Por exemplo, você pode incluir os valores de `15`, `11` e `7` para classificar primeiro por jogos comercializáveis então por aqueles com o maior nível de insígnia e, finalmente, em ordem alfabética. Como você pode imaginar, a ordem realmente importa, já que a ordem reversa (`7`, , `11` e `15`) alcança algo completamente diferente (classifique os jogos em ordem alfabética primeiro, e devido ao fato de os nomes dos jogos serem únicos, as outras duas são efetivamente inútil). A maioria das pessoas provavelmente usará apenas uma ordem de todos eles, mas caso você queira, você também pode classificar mais por parâmetros extras.

Also notice the word "try" in all above descriptions - the actual ASF order is heavily affected by selected **[cards farming algorithm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** and sorting will affect only results that ASF considers same performance-wise. Por exemplo, no algorítimo `Simple` `FarmingOrders` selecionados devem ser inteiramente respeitados na sessão atual de coleta (já que cada jogo tem o mesmo valor de performance), enquanto em `Complexo` ordem atual do algoritmo é afetada por horas primeiro, e, em seguida, classificado de acordo com o escolhido `FarmingOrders`. Isto levará a resultados diferentes, já que jogos com tempo de jogo existente terão prioridade sobre os outros. então o ASF preferirá jogos que já passaram necessários `HoursUntilCardDrops` primeiro. e só então classificar melhor esses jogos de acordo com a sua escolha `FarmingOrders`. Da mesma forma, uma vez que o ASF está sem jogos já iniciados, ele ordenará primeiro a fila restante por horas (pois isso diminuirá o tempo necessário para subir qualquer um dos títulos restantes para `HoursUntilCardDrops`). Therefore, this config property is only a **suggestion** that ASF will try to respect, as long as it doesn't affect performance negatively (in this case, ASF will always prefer farming performance over `FarmingOrders`).

Há também uma fila de prioridade de coleta que é acessível através do comando `fq` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Se é usado, a ordem real de coleta é classificada primeiramente pelo desempenho, depois pela fila de coleta e, finalmente, por seus `FarmingOrders`.

---

### `PreferênciaFazenda`

`byte flags` tipo com valor padrão de `0`. Esta propriedade define o comportamento do ASF relacionado à coleta e é definida abaixo:

| Valor | Nome                         |
| ----- | ---------------------------- |
| 0     | Nenhum                       |
| 1     | FarmingPausedByDefault       |
| 2     | EncerradoOnFarmingFinalizado |
| 4     | SendOnFarmingConcluído       |
| 8     | Apenas                       |
| 16    | Jogos                        |
| 32    | SkipUnplayedGames            |
| 64    | Descoberta                   |
| 256   | AutoUnpackBoosterPacks       |

Note que esta propriedade é um campo `flags` , portanto é possível escolher qualquer combinação de valores disponíveis. Confira o mapeamento **[json](#json-mapping)** se você quiser saber mais. Não habilitar nenhum dos resultados de sinalizadores em `Nenhuma opção`.

Todas as opções estão descritas abaixo.

`FarmingPausedByDefault` define o estado inicial do módulo `CardsFarmer`. Normalmente, o bot começará a coletar automaticamente quando for iniciado, seja por causa do comando `Habilitado` ou `iniciar o comando`. Usando `FarmingPausedByDefault` pode ser usado se você quiser manualmente `resumir` processo de coleta automática. por exemplo, porque você deseja usar `play` o tempo todo e nunca usar o módulo `CardsFarmer` automático - isso funciona exatamente do mesmo que `pause` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

`ShutdownOnFarmingFinished` permite que você desligue o bot quando ele estiver acabando de ser coletado. Normalmente, o ASF "ocupa" uma conta durante todo o tempo em que o processo está ativo. Quando determinada conta é feita com coleta, o ASF verifica periodicamente o mesmo (a cada horaformat@@0 do `IdleFarmingPeriod` ), se talvez alguns novos jogos com cartas Steam tenham sido adicionados entretanto, para que possa retomar a criação dessa conta sem necessidade de reiniciar o processo. Isso é útil para a maioria das pessoas, já que o ASF pode retomar automaticamente a coleta quando necessário. No entanto, pode realmente querer parar o processo quando determinada conta for totalmente explorada, pode consegui-lo utilizando esta bandeira. Quando habilitado, o ASF vai desconectar quando a conta for totalmente explorada, o que significa que ela não será periodicamente verificada ou ocupada. Você deve decidir se você prefere que o ASF trabalhe em determinada conta bot o tempo todo. ou se talvez o ASF deva pará-lo quando o processo de coleta for finalizado.

Esta opção faz mais sentido ser combinada com `ShutdownIfPossível`, , portanto, quando todas as contas forem interrompidas, o ASF também será desligado. deixando sua máquina em repouso e permitindo agendar outras ações, como dormir ou desligar no mesmo momento em que você recebe a última carta.

`SendOnFarmingFinished` permite que você envie automaticamente uma troca Steam contendo tudo o que foi cultivado até este momento para o usuário com a permissão `Master` , o que é muito conveniente se você não quiser se preocupar com trocas consigo mesmo. This option works the same as `loot` command, therefore keep in mind that it requires user with `Master` permission set, you may also need a valid `SteamTradeToken`, as well as using an account that is eligible for trading in the first place. Além de iniciar o saque `` após terminar a coleta, O ASF também iniciará `saque` a cada notificação de novos itens (quando não estiver coletando), e depois de completar cada negociação que resulta em novos itens (sempre) quando esta opção está ativa. Isso é especialmente útil para "encaminhar" itens recebidos de outras pessoas para a nossa conta. Normalmente você vai querer usar **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** juntamente com este recurso, embora não seja um requisito se você pretende lidar com as confirmações 2FA manualmente em tempo hábil.

`FarmPriorityQueueOnly` define se o ASF deve considerar para coleta automática apenas os aplicativos que você mesmo adicionou à fila de coleta prioritária disponível com `fq` **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. When this option is enabled, ASF will skip all `appIDs` that are missing on the list, effectively allowing you to cherry-pick games for automatic ASF farming. Tenha em mente que se você não adicionar nenhum jogo na lista o ASF vai se comportar como se não houvesse nada para coletar na sua conta.

`SkipRefundableGames` define se o ASF deve ignorar jogos que ainda são reembolsáveis da coleta automática. Um jogo reembolsável é um jogo que você comprou na loja Steam nas últimas 2 semanas e não jogou por mais de 2 horas ainda, conforme indicado na página **[Steam reembolsa](https://store.steampowered.com/steam_refunds)**. Por padrão, o ASF ignora a política de reembolso inteiramente e coleta tudo, como a maioria das pessoas esperaria. No entanto, você pode usar essa flag se você quiser garantir que o ASF não colete qualquer um dos seus jogos reembolsáveis muito em breve, permitindo que você avalie esses jogos e reembolso, se necessário, sem se preocupar com o ASF afetando negativamente o tempo de jogo. Note que se você habilitar essa opção os jogos que você comprou na loja Steam não serão coletados pelo ASF por até 14 dias desde a data da ativação. que se mostrará como nada a ser coletado se a sua conta não possuir mais.

`SkipUnplayedGames` define se o ASF deve ignorar jogos que você ainda não executou. Jogo não jogado neste contexto significa que você não tem exatamente nenhum tempo registrado para ele na Steam. Se você usar essa flag, então esses jogos serão ignorados até que o Steam registre qualquer tempo de jogo deles. Isso permite que você controle melhor quais jogos o ASF é elegível para coletar, ignorando aqueles que você ainda não tinha chance de testar. manter as características selecionadas do Steam mais úteis - como sugerir jogos não jogados para jogar.

`EnableRiskyCardsDiscovery` permite um recurso adicional que aciona quando o ASF não consegue carregar uma ou mais páginas de insígnias e, portanto, não consegue encontrar jogos disponíveis para a coleta. Em particular, algumas contas com uma enorme quantidade de cartas podem causar uma situação em que o carregamento das páginas de insígnias não é mais possível (devido a excesso), e essas contas são impossíveis para agricultura simplesmente porque não podemos carregar as informações com base nas quais podemos iniciar o processo. Para esses poucos casos, esta opção permite que um algoritmo alternativo seja usado, que usa uma combinação de impulsores possíveis para criar e amplificar pacotes que a conta é elegível, a fim de encontrar jogos potencialmente disponíveis para coleta gastando em seguida quantidade excessiva de recursos para verificar e obter informações necessárias, e tentando iniciar o processo de coleta na quantidade limitada de dados e informações para eventualmente chegar a uma situação quando a página de insígnias carrega e poderemos usar a abordagem normal. Por favor, note que quando esse recurso é usado, o ASF opera apenas com dados limitados, portanto é completamente normal que o ASF encontre menos cartas do que na realidade - outras cartas serão encontradas na fase posterior do processo de coleta.

Essa opção é chamada de "risco" por uma excelente razão - é extremamente lento e requer uma quantidade significativa de recursos (incluindo solicitações de rede) para a operação, portanto, é **não recomendado** estar ativado e especialmente em longo prazo. Você deve usar esta opção somente se você tiver determinado anteriormente que sua conta não será capaz de carregar as páginas de insígnias e que o ASF não possa operar nela, sempre falhando ao carregar as informações necessárias para iniciar o processo. Mesmo que nos esforcemos ao máximo para otimizar o processo tanto quanto possível. ainda é possível para esta opção fazer backup e pode causar resultados indesejados, tal como banimentos temporários e talvez até permanentes do Steam por enviar muitas solicitações e causar sobrecarga nos servidores Steam. Portanto, avisamos você com antecedência e estamos oferecendo esta opção sem absolutamente nenhuma garantia, você está usando por sua conta e risco.

`AutoUnpackBoosterPacks` irá descompactar automaticamente todos os pacotes de cartas ao receber novas notificações de itens. Isso permitirá que você adquira imediatamente cartas adicionais, que podem ser o cenário desejado, especialmente em combinação com outras opções (e. . `SteamTradeMatcher` ou `CompleteTypesToEnviar`).

---

### `GamesPlayedWhiledle`

`ImmutableHashSet<uint>` tipo com valor padrão vazio. Se o ASF não tem nada para coletar ele pode jogar seus jogos Steam (`appIDs`). Jogar jogos de tal forma aumenta suas horas "jogadas" desses jogos, mas nada mais além disso. In order for this feature to work properly, your Steam account **must** own a valid license to all the `appIDs` that you specify here, this includes F2P games as well. Este recurso pode ser ativado ao mesmo tempo com `CustomGamePlayedWhileIdle` para jogar seus jogos selecionados enquanto exibe status personalizado na rede Steam, mas neste caso, como no caso `CustomGamePlayedWhileFarming` , a ordem de exibição atual não é garantida. Por favor, note que o Steam permite que o ASF reproduza apenas até o total de `32` `appIDs` , Portanto, você só pode colocar quantos jogos nesta propriedade.

---

### `TipoGamingDeviceTipo`

Tipo `ushort` com valor padrão de `1`. Esta propriedade pode ativar alguns recursos online adicionais na plataforma Steam e é definida abaixo:

| Valor | Nome       | Descrição                    |
| ----- | ---------- | ---------------------------- |
| 1     | Padrao     | Nenhum modo especial, padrão |
| 544   | Deck Steam | Apresente-se como Deck Steam |

O tipo `EGamingDeviceType` subjacente ao qual esta propriedade é baseada inclui valores mais disponíveis, No entanto, tanto quanto sabemos, eles não têm qualquer efeito a partir de hoje, pelo que foram reduzidos para a visibilidade.

Se você não tem certeza de como definir essa propriedade, deixe-a com o valor padrão de `1`.

---

### `Drops`

Tipo `byte` com valor padrão de `3`. Esta propriedade define se a conta tem restrição na coleta de cartas, e caso sim, por quantas horas. Restrição de coleta de cartas significa que a conta não está recebendo cartas de determinados jogos até que o jogo seja jogado pelo menos por `HoursUntilCardDrops` horas. Infelizmente não há nenhuma forma mágica de detectar isso, então o ASF depende de você. This property affects **[cards farming algorithm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** that will be used. Configurar essa propriedade corretamente irá maximizar os lucros e minimizar o tempo necessário para que as cartas sejam coletadas. Lembre-se que não há nenhuma resposta óbvia se você deve usar um ou outro valor, uma vez que depende totalmente da sua conta. Parece que contas mais antigas que nunca pediram reembolso têm acesso ilimitado a cartas, então eles devem usar um valor de `0`, enquanto novas contas e aqueles que pediram reembolso restringiram o recebimento de cartas com o valor de `3`. No entanto isto é apenas teoria, e não deve ser tomado como regra. O valor padrão para essa propriedade foi definido com base no "mal menor" e a maioria dos casos de uso.

---

### `Tipos`

`ImmutableHashSet<byte>` tipo com valor padrão de tipos de itens Steam `1, 3, 5`. Esta propriedade define o comportamento do ASF quando estiver coletando ambos os manuais, usando o comando **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, além de uma automática, através de uma ou mais propriedades de configuração. O ASF garantirá que somente itens do `LootableTypes` serão incluídos na oferta de troca, Portanto, esta propriedade permite que você escolha o que deseja receber em uma oferta de troca que está sendo enviada para você.

| Valor | Nome            | Descrição                                                                   |
| ----- | --------------- | --------------------------------------------------------------------------- |
| 0     | Desconhecido    | Qualquer tipo que não se encaixa em nenhuma das opções abaixo               |
| 1     | BoosterPack     | Pacote de cartas contendo 3 cartas aleatórias de um jogo                    |
| 2     | Emoticon        | Emoticon para usar no Chat Steam                                            |
| 3     | FoilTradingCard | Variante brilhante de `Carta Comercial`                                     |
| 4     | Fundo           | Fundo do perfil para usar no seu perfil Steam                               |
| 5     | TradingCard     | Cartas colecionáveis Steam, usadas para fabricar insígnias (não brilhantes) |
| 6     | Gemas           | Gemas Steam usadas para criar boosters, pacotes incluídos                   |
| 7     | VendaItem       | Itens especiais recebidos durante as vendas Steam                           |
| 8     | Consumível      | Consumíveis especiais que desaparecem após serem usados                     |
| 9     | Modificador     | Itens especiais que podem modificar a aparência do perfil Steam             |
| 10    | Adesivo         | Itens especiais que podem ser usados no chat Steam                          |
| 11    | ChatEffect      | Itens especiais que podem ser usados no chat Steam                          |
| 12    | Fundo           | Fundo especial para o perfil Steam                                          |
| 13    | Quadro          | Quadro de avatar especial para o perfil Steam                               |
| 14    | AnimatedAvatar  | Avatar animado especial para o perfil Steam                                 |
| 15    | TemaTeclado     | Design de teclado especial para baralho Steam                               |
| 16    | IniciarVídeo    | Vídeo de inicialização especial para baralho Steam                          |

Observe que, independentemente das configurações acima, O ASF só pedirá por **[itens da comunidade Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` de 753, `contextID` de 6), então todos os itens de jogo, presentes e semelhantes, são excluídos da oferta de negociação por definição.

A configuração padrão do ASF baseia-se no uso mais comum do bot, coletando apenas pacotes de cartas e cartas colecionáveis (incluindo as brilhantes). A propriedade definida aqui permite que você altere esse comportamento da forma que te satisfaça. Por favor, tenha em mente que todos os tipos não definidos acima serão exibidos como `Tipo Desconhecido` , o que é especialmente importante quando a Valve liberar um novo item Steam, que será marcado como `Desconhecido` pelo ASF também, até que seja adicionado aqui (na versão futura). É por isso que, em geral, não é recomendado incluir um tipo `Desconhecido` no seu `LootableTypes`, , a menos que você saiba o que está fazendo, e você também entende que o ASF enviará seu inventário inteiro em uma oferta de troca se a rede Steam for quebrada novamente e reportar todos os seus itens como `Unknown`. Minha sugestão é não incluir um tipo `Desconhecido` no `LootableTypes`, mesmo que você espere saquear tudo (senão).

---

### `Nome`

Tipo `string` com valor padrão `null`. O ASF usará essa propriedade ao fazer login na rede Steam, que pode ser usado para personalização em relação a como exatamente o Steam exibirá a sessão e o computador do ASF. . ao exibir dispositivos que estão logados em **[aqui](https://store.steampowered.com/account/authorizeddevices)**.

O ASF fornece algumas variáveis especiais que você pode opcionalmente usar em seu texto. `{0}` será substituído pelo nome da máquina como fornecido pelo seu SO, `{1}` será substituído pelo identificador público do ASF, enquanto `{2}` será substituído pela versão do ASF.

A menos que você saiba o que está fazendo, você deve mantê-lo com o valor padrão de `null`. Neste caso, o ASF decidirá internamente sobre o valor correto, que é `{0} ({1}/{2})` a partir de hoje. Tenha em mente que isso é apenas uma sugestão de que a rede Steam pode, ou não, respeitar na íntegra.

---

### `Tipos`

`ImmutableHashSet<byte>` tipo com valor padrão de tipos de itens Steam `5`. Esta propriedade define quais tipos de itens Steam tem permissão de serem combinados quando a opção `SteamTradeMatcher` estiver habilitada no `TradingPreferences`. Os tipos são definidos abaixo:

| Valor | Nome            | Descrição                                                                   |
| ----- | --------------- | --------------------------------------------------------------------------- |
| 0     | Desconhecido    | Qualquer tipo que não se encaixa em nenhuma das opções abaixo               |
| 1     | BoosterPack     | Pacote de cartas contendo 3 cartas aleatórias de um jogo                    |
| 2     | Emoticon        | Emoticon para usar no Chat Steam                                            |
| 3     | FoilTradingCard | Variante brilhante de `Carta Comercial`                                     |
| 4     | Fundo           | Fundo do perfil para usar no seu perfil Steam                               |
| 5     | TradingCard     | Cartas colecionáveis Steam, usadas para fabricar insígnias (não brilhantes) |
| 6     | Gemas           | Gemas Steam usadas para criar boosters, pacotes incluídos                   |
| 7     | VendaItem       | Itens especiais recebidos durante as vendas Steam                           |
| 8     | Consumível      | Consumíveis especiais que desaparecem após serem usados                     |
| 9     | Modificador     | Itens especiais que podem modificar a aparência do perfil Steam             |
| 10    | Adesivo         | Itens especiais que podem ser usados no chat Steam                          |
| 11    | ChatEffect      | Itens especiais que podem ser usados no chat Steam                          |
| 12    | Fundo           | Fundo especial para o perfil Steam                                          |
| 13    | Quadro          | Quadro de avatar especial para o perfil Steam                               |
| 14    | AnimatedAvatar  | Avatar animado especial para o perfil Steam                                 |
| 15    | TemaTeclado     | Design de teclado especial para baralho Steam                               |
| 16    | IniciarVídeo    | Vídeo de inicialização especial para baralho Steam                          |

Claro, os tipos que você deve usar para esta propriedade normalmente incluem apenas `2`, `3`, `4` e `5`, pois apenas esses tipos são suportados pela STM. O ASF inclui uma lógica adequada para descobrir a raridade dos itens, portanto também é seguro combinar emoticons ou planos de fundo, já que o ASF vai considerar justo apenas os itens do mesmo jogo e tipo, que também compartilham a mesma raridade.

Por favor, note que **ASF não é um bot de troca** e **não vai se importar com o preço do mercado**. Se você não considerar itens da mesma raridade do mesmo conjunto como iguais em termos de preço, então esta opção NÃO é para você. Por favor, avalie duas vezes se você entendeu e concorda com esta declaração antes de decidir alterar esta configuração.

A menos que você saiba o que está fazendo, você deve mantê-lo com o valor padrão de `5`.

---

### `Bandeiras on-line`

`ushort flags` tipo com valor padrão de `0`. Esta propriedade funciona como complemento ao **[`OnlineStatus`](#onlinestatus)** e especifica os recursos adicionais de presença online anunciados para a rede Steam. Requer **[`OnlineStatus`](#onlinestatus)** diferente de `Offline`, e é definido como abaixo:

| Valor | Nome              | Descrição                                              |
| ----- | ----------------- | ------------------------------------------------------ |
| 0     | Nenhum            | Sem sinalizadores especiais de presença online, padrão |
| 2     | InJoinableGame    | Cliente está participando do jogo                      |
| 8     | PlayTogether      | Cliente está usando uma sessão de reprodução remota    |
| 256   | ClientTypeWeb     | Cliente está usando interface web                      |
| 512   | Celular           | Cliente está usando o aplicativo móvel                 |
| 1024  | ClientTypeTenfoot | Cliente está usando uma imagem grande                  |
| 2048  | ClientTypeVR      | Cliente está usando o fone de ouvido VR                |

Note que esta propriedade é um campo `flags` , portanto é possível escolher qualquer combinação de valores disponíveis. Confira o mapeamento **[json](#json-mapping)** se você quiser saber mais. Não habilitar nenhum dos resultados de sinalizadores em `Nenhuma opção`.

O tipo `EPersonaStateFlag` subjacente que essa propriedade é baseada em inclui mais bandeiras disponíveis, No entanto, tanto quanto sabemos, eles não têm qualquer efeito a partir de hoje, pelo que foram reduzidos para a visibilidade.

Se você não tem certeza de como definir essa propriedade, deixe-a com o valor padrão de `0`.

---

### `Status on-line`

Tipo `byte` com valor padrão de `1`. Esta propriedade especifica o status na comunidade Steam com o qual o bot será anunciado após fazer login na rede Steam. Atualmente você pode escolher um dos status abaixo:

| Valor | Nome           |
| ----- | -------------- |
| 0     | Off-line       |
| 1     | Online         |
| 2     | Ocupado        |
| 3     | Ausente        |
| 4     | Silenciar      |
| 5     | LookingToTrade |
| 6     | LookingToPlay  |
| 7     | Invisível      |

O status `Offline` é extremamente útil para contas primárias. Como você deve saber, coletar de um jogo na verdade mostra seu status na Steam como "Em jogo: XXX", que pode enganar seus amigos, confundindo-os que você está jogando um jogo enquanto na verdade você está apenas coletando. Usar `O status` offline resolve esse problema - sua conta nunca aparecerá como "em jogo" quando você estiver coletando cartas Steam com o ASF. Isso é possível graças ao fato de que o ASF não precisa se conectar à comunidade Steam para funcionar corretamente, então estamos, de fato, jogando esses jogos, conectados à rede Steam, mas sem anunciar nossa presença on-line. Tenha em mente que jogos jogados usando o status offline ainda contarão para seu tempo de jogo e serão exibidos como "jogados recentemente" no seu perfil.

Além disso, esse recurso também é importante se você deseja receber notificações e mensagens não lidas quando o ASF estiver sendo executado, enquanto não mantém o cliente Steam aberto ao mesmo tempo. Isso acontece porque o ASF atua como um cliente Steam em si, e quer o ASF goste ou não, O Steam transmite todas essas mensagens e outros eventos para ele. Isso não é um problema se você tiver tanto o ASF quanto seu próprio cliente Steam rodando, já que ambos os clientes recebem exatamente os mesmos eventos. No entanto, se apenas o ASF estiver rodando, a rede Steam poderia marcar certos eventos e mensagens como "entregue", apesar do seu cliente Steam tradicional não recebê-lo por não estar presente. O status off-line também resolve esse problema, já que o ASF nunca é considerado para nenhum evento da comunidade nesse caso, para que todas as mensagens não lidas e outros eventos sejam devidamente marcados como não lidos quando você voltar.

It's important to note that ASF running on `Offline` mode will **not** be able to receive commands in usual Steam chat way, as the chat, as well as entire community presence is in fact, entirely offline. Uma solução para este problema é usar o modo `Invisível` em vez disso, que funciona de forma similar (não expondo status), mas mantém a capacidade de receber e responder mensagens (potencial para descartar notificações e mensagens não lidas conforme descrito acima). `Modo Invisível` faz mais sentido em contas alternativas que você não quer expor (status-wise), mas ainda seja capaz de enviar comandos.

No entanto, há uma captura com o modo `Invisível` - ele não vai bem com contas primárias. Isto porque **qualquer sessão Steam** que está online **expõe o status** , mesmo que o ASF em si não o faça. Isso é causado pela limitação/bug atual da rede Steam que não é possível corrigir no lado do ASF, então se você quiser usar o modo `Invisível` você também precisará garantir que **todas as outras sessões** para o mesmo uso de conta `Modo Invisível` também. Esse será o caso em contas alternativas onde o ASF é, esperamos, a única sessão ativa mas em contas principais, você prefere mostrar como `Online` para seus amigos, ocultando apenas a atividade do ASF, e, neste caso, o modo `Invisível` será inteiramente inútil para você (recomendamos usar o modo `Offline` em vez disso. Espero que essa limitação/bug seja eventualmente resolvida no futuro pela Valve, mas eu não espero que isso aconteça tão cedo...

Se você não tem certeza de como configurar essa propriedade, É recomendado usar um valor de `0` (`Offline`) para contas primárias, e o padrão `1` (`Online`) caso contrário.

---

### `Formatação`

Tipo `byte` com valor padrão `0` (`PlainText`). Esta propriedade define o formato da propriedade `SteamPassword` e atualmente suporta valores especificados na seção de segurança **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**. Você deve seguir as instruções especificadas aqui, já que você precisará garantir que a propriedade `SteamPassword` de fato inclua senha correspondente a `PasswordFormat`. In other words, when you change `PasswordFormat` then your `SteamPassword` should be **already** in that format, not just aiming to be. A menos que você saiba o que está fazendo, você deve mantê-lo com o valor padrão de `0`.

Se você decidir alterar `PasswordFormat` de um bot que já tenha logado na rede Steam pelo menos uma vez, é possível que você tenha um erro único de descriptografar no início do próximo bot - isso é causado pelo fato de o `PasswordFormat` também ser usado em relação à criptografia/descriptografia automática de propriedades sensíveis no bot `. b` arquivo de banco de dados. Você pode ignorar com segurança esse erro, já que o ASF será capaz de recuperar dessa situação por conta própria. No entanto, se isso está acontecendo em uma base constante, por exemplo, cada reinicialização, ele deve ser investigado.

---

### `Preferências`

`byte flags` tipo com valor padrão de `0`. Essa propriedade define o comportamento do ASF quando estiver resgatando cd-keys, e é definida abaixo:

| Valor | Nome             | Descrição                                                                                                                           |
| ----- | ---------------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Nenhum           | Sem preferências especiais de resgate, padrão                                                                                       |
| 1     | Encaminhamento   | Encaminha keys indisponíveis para serem resgatadas por outros bots                                                                  |
| 2     | Distribuição     | Distribui todas as keys entre si e os outros bots                                                                                   |
| 4     | KeepMissingGames | Mantenha as chaves de jogos que (potencialmente) não estejam sendo encaminhados, deixando-os não utilizados                         |
| 8     | Código           | Assume que a tecla `BadActivationCode` é igual a `CannotRedeemCodeFromClient`e, portanto, tente resgatá-las como chaves de carteira |

Note que esta propriedade é um campo `flags` , portanto é possível escolher qualquer combinação de valores disponíveis. Confira o mapeamento **[json](#json-mapping)** se você quiser saber mais. Não habilitar nenhum dos resultados de sinalizadores em `Nenhuma opção`.

`Forwarding` will cause bot to forward a key that is not possible to redeem, to another connected and logged on bot that is missing that particular game (if possible to check). A situação mais comum é encaminhar um jogo `AlreadyPurchased` para outro bot que não tenha aquele jogo em particular. mas esta opção também abrange outros cenários, como `DoesNotOwnRequiredApp`, `Taxa` ou `Restrita`.

`Distribuir` fará com que o bot distribua todas as keys recebidas entre si e outros bots. Isto significa que cada bot receberá uma chave do lote. Normalmente isso é usado somente quando você está resgatando muitas keys do mesmo jogo, e você deseja distribuí-los igualmente entre seus bots, ao invés de resgatar keys para vários jogos diferentes. Este recurso não faz sentido se você for resgatar apenas uma key em um único `resgatar` (pois não há nenhuma key extra para ser distribuída).

`KeepMissingGames` fará com que o bot pule o encaminhamento `` quando não tivermos certeza se a key que está sendo resgatada pertence, na verdade, ao nosso bot, ou não. This basically means that `Forwarding` will apply **only** to `AlreadyPurchased` keys, instead of covering also other cases such as `DoesNotOwnRequiredApp`, `RateLimited` or `RestrictedCountry`. Typically you want to use this option on primary account, to ensure that keys being redeemed on it won't be forwarded further if your bot for example becomes temporarily `RateLimited`. As you can guess from the description, this field has absolutely no effect if `Forwarding` is not enabled.

`AssumeWalletKeyOnBadActivationCode` fará com que as chaves `BadActivationCode` sejam tratadas como `CannotRedeemCodeFromClient`, e, portanto, faz com que o ASF tente resgatá-los como chaves de carteira. Isto é necessário porque o Steam pode anunciar as chaves de carteira como `BadActivationCode` (e não `CannotRedeemCodeFromClient` como usou), resultando no ASF nunca tentando resgatá-los. No entanto, recomendamos **contra** usando essa preferência, já que isso fará com que o ASF tente resgatar cada chave inválida como um código de carteira, resultando em uma quantidade excessiva de solicitações (potencialmente inválidas) enviadas para o serviço Steam, com todas as potenciais consequências. Em vez disso, nós recomendamos usar o modo `ForceAssumeWalletKey` **[`redeem^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** ao resgatar conscientemente as chaves de carteira, que irá habilitar a solução necessária apenas quando for necessário, com base na necessidade.

Ativando ambos `Encaminhamento` e `Distributing` adicionará o recurso de distribuição em cima de um, encaminhamento. que faz com que o ASF tente resgatar uma chave em todos os bots primeiro (encaminhamento) antes de passar para a próxima (distribuição). Typically you want to use this option only when you want `Forwarding`, but with altered behaviour of switching the bot on key being used, instead of always going in-order with every key (which would be `Forwarding` alone). This behaviour can be beneficial if you know that majority or even all of your keys are tied to the same game, because in this situation `Forwarding` alone would try to redeem everything on one bot firstly (which makes sense if your keys are for unique games), and `Forwarding` + `Distributing` will switch the bot on the next key, "distributing" the task of redeeming new key onto another bot than the initial one (which makes sense if keys are for the same game, skipping one pointless attempt per key).

A ordem real para todos os cenários de ativação de keys é alfabética, excluindo os bots que não estão disponíveis (não conectados, parados ou afins). Por favor, tenha em mente que há um limite de tentativas de ativação por IP e por conta a cada hora, e toda tentativa de resgate que não terminou com `OK` contribui para tentativas falhas. O ASF fará o seu melhor para minimizar o número de falhas `AlreadyPurchased` , por exemplo, tentando evitar encaminhar uma key para outro bot que já possui esse jogo em particular. mas nem sempre é garantido que funcione devido a como o Steam está manipulando licenças. Usando resgatar bandeiras como `Encaminhando` ou `Distributing` sempre aumentará a probabilidade de atingir `RateLimited`.

Também tenha em mente que você não pode encaminhar ou distribuir chaves para bots aos quais você não tem acesso. Isto deveria ser óbvio, mas certifique-se de que você seja, pelo menos, `Operador` de todos os bots que você deseja incluir no seu processo de ativação, por exemplo, com o status `do ASF` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `ComunicaçãoRemota`

`byte flags` tipo com valor padrão de `3`. Esta propriedade define o comportamento por bot do ASF quando se trata de comunicação com os serviços de terceiros remotos, e é definida abaixo:

| Valor | Nome     | Descrição                                                                                                                                                                                                                                                         |
| ----- | -------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Nenhum   | Nenhuma comunicação permitida de terceiros, renderizando recursos selecionados do ASF não utilizáveis                                                                                                                                                             |
| 1     | Grupo    | Permite comunicação com o grupo **[do Steam](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                        |
| 2     | Listagem | Permite comunicação com **[A-STM listando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** a fim de ser listado, se o usuário também tiver ativado `SteamTradeMatcher` em **[`TradingPreferences`](#tradingpreferences)** |

Note que esta propriedade é um campo `flags` , portanto é possível escolher qualquer combinação de valores disponíveis. Confira o mapeamento **[json](#json-mapping)** se você quiser saber mais. Não habilitar nenhum dos resultados de sinalizadores em `Nenhuma opção`.

Esta opção não inclui todas as comunicações de terceiros oferecidas pelo ASF, apenas aquelas que não são implícitas pelas outras configurações. Por exemplo, se você habilitou as atualizações automáticas do ASF, o ASF se comunicará com o GitHub (para downloads) e com nosso servidor (para verificação de checksum), conforme sua configuração. Da mesma forma, habilitar `MatchActively` em **[`TradingPreferences`](#tradingpreferences)** implica comunicação com nosso servidor para buscar bots listados, que é necessário para essa funcionalidade.

Mais explicações sobre este assunto estão disponíveis em **[comunicação remota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `Período`

Tipo `byte` com valor padrão de `0`. Esta propriedade funciona de forma muito semelhante à `SendOnFarmingFinished` preference in `FarmingPreferences`, , com uma diferença - em vez de enviar a troca quando a agricultura é feita, também podemos enviá-lo a cada `SendTradePeriod` horas, independente de quanto ainda temos para coletar. Isso é útil se você quiser saquear `saque` suas contas alternativas em vez de esperar que a coleta termine. O valor padrão `0` desativa este recurso, se você quiser que o seu bot lhe envie trocas. . todos os dias, você deveria colocar `24` aqui.

Normalmente você vai querer usar **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** juntamente com este recurso, embora não seja um requisito se você pretende lidar com as confirmações 2FA manualmente em tempo hábil. Se você não tem certeza de como definir essa propriedade, deixe-a com o valor padrão de `0`.

---

### `SteamLogin`

Tipo `string` com valor padrão `null`. Essa propriedade define seu login Steam - aquele que você usa para entrar na Steam. Além de definir o login da Steam aqui, Você também pode manter o valor padrão de `null` se quiser digitar seu login Steam em cada inicialização do ASF em vez de colocá-lo na configuração. Isso pode ser útil para você se você não quiser salvar dados confidenciais no arquivo de configuração.

---

### `SteamMasterClanID`

Tipo `ulong` com valor padrão de `0`. Esta propriedade define a steamID do grupo Steam que bot deve entrar automaticamente, incluindo seu chat em grupo. Você pode verificar a steamID do seu grupo navegando para a página **[](https://steamcommunity.com/groups/archiasf)**e, em seguida, adicionando `/memberslistxml? ml=1` para o final do link, então o link vai se parecer com **[o](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. Em seguida, você poderá obter a steamID do seu grupo no resultado, estará na tag `<groupID64>`. No exemplo acima ele seria `103582791440160998`. Além de tentar entrar no grupo quando iniciado, o bot também aceitará automaticamente convites de grupo para esse grupo. o que torna possível para você convidar o bot manualmente se o grupo tiver uma conta privada. Se você não tem nenhum grupo dedicado aos seus bots, você deve manter essa propriedade com o valor padrão de `0`.

---

### `SteamParentalCode`

Tipo `string` com valor padrão `null`. Essa propriedade define seu PIN do modo família. O ASF requer acesso a recursos protegidos pelo modo família, portanto se você usa esse recurso, você deve fornecer ao ASF o PIN de desbloqueio dos pais para que ele possa operar normalmente. O valor padrão de `null` significa que não há um PIN necessário para desbloquear esta conta, e isso é provavelmente o que você quer se você não usa a funcionalidade dos pais.

Em circunstâncias limitadas, o ASF também pode gerar um código válido do modo família Steam, embora isso exija uma quantidade excessiva de recursos do SO e um tempo adicional para concluir, Sem mencionar que não tem certeza de ter sucesso, Portanto, recomendamos não contar com esse recurso e, em vez disso, colocar `SteamParentalCode` válido na configuração para que o ASF use. Se o ASF determinar que o PIN é necessário e que ele não será capaz de gerar um por conta própria, ele pedirá uma entrada para você.

---

### `SteamPassword`

Tipo `string` com valor padrão `null`. Essa propriedade define sua senha Steam - aquela que você usa para entrar na Steam. Além de definir a senha Steam aqui, Você também pode manter o valor padrão de `null` se você quiser digitar sua senha Steam em cada inicialização do ASF em vez de colocá-lo na configuração. Isso pode ser útil para você se você não quiser salvar dados confidenciais no arquivo de configuração.

---

### `SteamTradeToken`

Tipo `string` com valor padrão `null`. Quando você tem seu bot na sua lista de amigos, ele pode enviar propostas de troca para você imediatamente, sem se preocupar com o token de troca, Portanto, você pode deixar essa propriedade no valor padrão de `null`. Se você decidir, no entanto, não ter o bot na sua lista de amigos, então você precisará gerar e preencher um token de troca como o usuário para o qual este bot está esperando enviar trocas. Por outras palavras, esta propriedade deve ser preenchida com o token de trocas da conta que é definida com a permissão `Master` no `SteamUserPermissions` of **essa conta bot**.

Para encontrar seu token, como logado no usuário com a permissão `Master` , navegue **[aqui](https://steamcommunity.com/my/tradeoffers/privacy)** e dê uma olhada na sua URL de troca. O token que procuramos é composto por 8 caracteres após `&token=` em sua URL de troca. Você deve copiar e colocar esses 8 caracteres aqui, como `SteamTradeToken`. Não inclua toda a URL de troca, nem a parte `&token=` , apenas o próprio token (8 caracteres).

---

### `Permissões`

`Tipo ImmutableDictionary<ulong, byte>` com valor padrão vazio. This property is a dictionary property which maps given Steam user identified by his 64-bit steam ID, to `byte` number that specifies his permission in ASF instance. Atualmente as permissões disponíveis para os bots no ASF são definidas como:

| Valor | Nome           | Descrição                                                                                                                                                                                                      |
| ----- | -------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Nenhum         | Sem permissão especial, esse é principalmente um valor de referência que é atribuído a falta de IDs Steam nesse dicionário - não há necessidade de definir ninguém com essa permissão                          |
| 1     | Compartilhando | Fornece acesso mínimo para usuários do modo família. Novamente, esse é apenas um valor de referência, uma vez que o ASF é capaz de descobrir automaticamente os IDs Steam que permitimos usar nossa biblioteca |
| 2     | Operador       | Fornece acesso básico a determinadas contas bot, principalmente adicionar licenças e resgatar keys                                                                                                             |
| 3     | Mestre         | Fornece acesso total a determinada conta bot                                                                                                                                                                   |

Em resumo, essa propriedade permite que você manipule permissões para determinados usuários. As permissões são importantes principalmente para acessar o comando **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, mas também para habilitar muitos recursos do ASF, como aceitar trocas. Por exemplo, você pode querer definir sua própria conta como `Master`, e dar ao Operador `` acesso a 2-3 dos seus amigos para que eles possam facilmente resgatar keys para seu bot com o ASF, enquanto **não** for candidato. . para pará-lo. Graças a isso você pode facilmente atribuir permissões para determinados usuários e deixá-los usarem seu bot para algumas especificadas pelo seu grau.

We recommend to set exactly one user as `Master`, and any amount you wish as `Operators` and below. Enquanto é tecnicamente possível definir vários `Masters` e o ASF funcionará corretamente com eles. por exemplo, aceitando todas as suas trocas enviadas para o bot, O ASF usará apenas um deles (com o ID Steam mais baixo) para cada ação que requer um único alvo, por exemplo, uma solicitação `loot` assim também propriedades como `SendOnFarmingFinished` preference in `FarmingPreferences` or `SendTradePeriod`. If you perfectly understand those limitations, especially the fact that `loot` request will always send items to the `Master` with lowest steam ID, regardless of the `Master` that actually executed the command, then you can define multiple users with `Master` permission here, but we still recommend a single master scheme.

É bom notar que há mais uma permissão extra `Proprietário` , que é declarada como `SteamOwnerID` propriedade de configuração global. Você não pode atribuir a permissão `Proprietário` para alguém aqui, como a propriedade `SteamUserPermissions` define apenas as permissões que estão relacionadas com a conta bot e não o ASF como um processo. Para tarefas relacionadas aos bots, `SteamOwnerID` é tratado da mesma forma que `Master`, então definir o seu `SteamOwnerID` aqui não é necessário.

---

### `Período`

Tipo `byte` com valor padrão de `60`. Normalmente o ASF lida com ofertas de troca de entrada assim que receber notificações sobre uma, mas às vezes por causa do Steam falhas, não é possível fazer isso naquele momento. e tais ofertas de troca permanecem ignoradas até a próxima notificação de troca ou o reinício do bot ocorrer, que pode fazer com que as negociações sejam canceladas ou os itens não estejam disponíveis no momento posterior. If this parameter is set to a non-zero value, ASF will additionally check for such outstanding trades every `TradeCheckPeriod` minutes. O valor padrão é selecionado com equilíbrio entre pedidos adicionais para servidores Steam e a perda de trocas de entrada em mente. No entanto, se você está apenas usando o ASF para coletar cartas e não planeja processar automaticamente quaisquer trocas recebidas, você pode definir como `0` para desativar este recurso completamente. Por outro lado, se seu bot participar da listagem [pública do STM do ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) ou fornece outros serviços automatizados como um bot de comércio, você pode querer diminuir este parâmetro para `15` minutos ou mais, para processar todas as negociações em tempo hábil.

---

### `TradingPreferences`

`byte flags` tipo com valor padrão de `0`. Esta propriedade define o comportamento do ASF quando estiver trocando, e é definida abaixo:

| Valor | Nome                | Descrição                                                                                                                                                                                                                 |
| ----- | ------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Nenhum              | Sem preferências especiais de troca, padrão                                                                                                                                                                               |
| 1     | Doações             | Aceita trocas nas quais não estamos perdendo nada                                                                                                                                                                         |
| 2     | SteamTradeMatcher   | Participa passivamente de trocas do tipo **[STM](https://www.steamtradematcher.com)**. Visite **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** para mais informações          |
| 4     | Tudo                | Requer que o `SteamTradeMatcher` seja definido, e em combinação com ele - também aceita trocas ruins além de boas e neutras                                                                                               |
| 8     | DontAcceptBotTrades | Não aceita automaticamente as trocas `saque` de outras instâncias bot                                                                                                                                                     |
| 16    | Parcialmente        | Participa ativamente das trocas **[STM](https://www.steamtradematcher.com)**. Visite **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** para mais informações |

Note que esta propriedade é um campo `flags` , portanto é possível escolher qualquer combinação de valores disponíveis. Confira o mapeamento **[json](#json-mapping)** se você quiser saber mais. Não habilitar nenhum dos resultados de sinalizadores em `Nenhuma opção`.

For further explanation of ASF trading logic, and description of every available flag, please visit **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** section.

---

### `Tipos`

`ImmutableHashSet<byte>` tipo com valor padrão de tipos de itens Steam `1, 3, 5`. This property defines which Steam item types will be considered for transfering between bots, during `transfer` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. O ASF garantirá que apenas itens do `TransferableTypes` serão incluídos na oferta de troca, Portanto, esta propriedade permite que você escolha o que deseja receber em uma oferta de troca que está sendo enviada para um de seus bots.

| Valor | Nome            | Descrição                                                                   |
| ----- | --------------- | --------------------------------------------------------------------------- |
| 0     | Desconhecido    | Qualquer tipo que não se encaixa em nenhuma das opções abaixo               |
| 1     | BoosterPack     | Pacote de cartas contendo 3 cartas aleatórias de um jogo                    |
| 2     | Emoticon        | Emoticon para usar no Chat Steam                                            |
| 3     | FoilTradingCard | Variante brilhante de `Carta Comercial`                                     |
| 4     | Fundo           | Fundo do perfil para usar no seu perfil Steam                               |
| 5     | TradingCard     | Cartas colecionáveis Steam, usadas para fabricar insígnias (não brilhantes) |
| 6     | Gemas           | Gemas Steam usadas para criar boosters, pacotes incluídos                   |
| 7     | VendaItem       | Itens especiais recebidos durante as vendas Steam                           |
| 8     | Consumível      | Consumíveis especiais que desaparecem após serem usados                     |
| 9     | Modificador     | Itens especiais que podem modificar a aparência do perfil Steam             |
| 10    | Adesivo         | Itens especiais que podem ser usados no chat Steam                          |
| 11    | ChatEffect      | Itens especiais que podem ser usados no chat Steam                          |
| 12    | Fundo           | Fundo especial para o perfil Steam                                          |
| 13    | Quadro          | Quadro de avatar especial para o perfil Steam                               |
| 14    | AnimatedAvatar  | Avatar animado especial para o perfil Steam                                 |
| 15    | TemaTeclado     | Design de teclado especial para baralho Steam                               |
| 16    | IniciarVídeo    | Vídeo de inicialização especial para baralho Steam                          |

Observe que, independentemente das configurações acima, O ASF só pedirá por **[itens da comunidade Steam](https://steamcommunity.com/my/inventory/#753_6)** (`appID` de 753, `contextID` de 6), então todos os itens de jogo, presentes e semelhantes, são excluídos da oferta de negociação por definição.

A configuração padrão do ASF baseia-se no uso mais comum do bot, transferindo apenas pacotes de cartas e cartas colecionáveis (incluindo as brilhantes). A propriedade definida aqui permite que você altere esse comportamento da forma que te satisfaça. Por favor, tenha em mente que todos os tipos não definidos acima serão exibidos como `Tipo Desconhecido` , o que é especialmente importante quando a Valve liberar um novo item Steam, que será marcado como `Desconhecido` pelo ASF também, até que seja adicionado aqui (na versão futura). É por isso que, em geral, não é recomendado incluir um tipo `Desconhecido` no seu `TransferableTypes`, a menos que você saiba o que está fazendo, e você também entende que o ASF enviará seu inventário inteiro em uma oferta de troca se a rede Steam for quebrada novamente e reportar todos os seus itens como `Unknown`. Minha sugestão é não incluir um tipo `Desconhecido` no tipo `TransferableTypes`, mesmo que você espere transferir tudo.

---

### `UseLoginKeys`

`bool` modelo com valor padrão de `true`. Esta propriedade define se o ASF deve usar o mecanismo de chaves de login para essa conta Steam. O mecanismo de chaves de login funciona de forma muito semelhante à opção "lembre-me" do cliente oficial do Steam, o que torna possível que o ASF armazene e use a chave de login temporária uma vez para a próxima tentativa de logon, efetivamente ignorando a necessidade de fornecer senha, Steam Guard ou código 2FA, desde que nossa chave de login seja válida. A chave de login é armazenada no arquivo `NomeDoBot.db` e atualizada automaticamente. É por isso que você não precisa fornecer senha/SteamGuard/código 2FA após se conectar com o ASF uma vez.

Chaves de login são usadas por padrão para sua conveniência, então você não precisa inserir `SteamPassword`, SteamGuard ou código 2FA (quando não estiver usando **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**) em cada login. Também é uma alternativa superior, já que a chave de login pode ser usada apenas uma única vez e não revela sua senha original de forma alguma. Exatamente o mesmo método é usado pelo seu cliente Steam original, que salva seu nome de conta e chave de login para sua próxima tentativa de logon, sendo efetivamente o mesmo que usar `SteamLogin` com `UseLoginKeys` e o `SteamPassword` vazio no ASF.

No entanto, algumas pessoas poderiam estar preocupadas, mesmo com este pequeno pormenor, Portanto, esta opção está disponível aqui para você se você quiser garantir que o ASF não armazene nenhum tipo de token que permitiria retomar a sessão anterior após ser fechada, que resultará na autenticação total sendo obrigatória em cada tentativa de login. Desabilitar essa opção funcionará exatamente da mesma forma que não marcar a opção "lembrar-me do mim" no cliente Steam oficial. A menos que você saiba o que está fazendo, você deve mantê-lo com o valor padrão de `verdadeiro`.

---

### `InterfaceMode`

Tipo `byte` com valor padrão de `0`. Esta propriedade especifica o modo de interface de usuário com o qual o bot será anunciado após acessar a rede Steam. Ele pode influenciar como a conta é visível, por exemplo, no chat do Steam, se sua presença permite isso através do `OnlineStatus`. Atualmente você pode escolher um dos modos abaixo:

| Valor | Nome       | Descrição                      |
| ----- | ---------- | ------------------------------ |
| `0`   | VGUI       | Modo cliente Steam padrão      |
| `1`   | Tenfoot    | Modo de imagem grande          |
| `2`   | Celular    | Aplicativo móvel Steam         |
| `3`   | Web        | Sessão do navegador da Web     |
| `5`   | MobileChat | Aplicativo de chat móvel Steam |

O tipo `EUIMode` subjacente no qual esta propriedade é baseada inclui mais valores disponíveis, no entanto, Tanto quanto sabemos, não têm qualquer efeito a partir de hoje, pelo que foram reduzidos para a visibilidade. Além disso, você pode estar interessado em verificar `GamingDeviceType`, já que alguns recursos adicionais estão ativados lá.

Se você não tem certeza de como definir essa propriedade, deixe-a com o valor padrão de `0`.

---

### `WebProxy`

Tipo `string` com valor padrão `null`. Esta propriedade define um endereço de proxy web que será usado para comunicação interna de http, específica do bot, especialmente para serviços como `api. teampowered.com`, `steamcommunity.com` e `store.steampowered.com`. Se não for definido, o ASF usará a configuração global `WebProxy` especificada acima. Solicitações de proxy do ASF pode ser excepcionalmente útil para contornar vários tipos de firewalls, especialmente o grande firewall da China.

Essa propriedade é definida como uma sequência de caracteres uri:

> Uma string URI é composta por um esquema (suportado: http/https/socks4/socks4a/socks5), um host e uma porta opcional. Um exemplo de uri completo é `"http://contoso.com:8080"`.

Se seu proxy requer autenticação de usuário, você também precisará configurar a `WebProxyUsername` e/ou `WebProxyPassword`. Se não há tal necessidade, configurar somente essa propriedade é suficiente.

Se você também precisa da comunicação da rede Steam interna (Proxying Network) então você deve configurar a propriedade **[`SteamProtocols`](#steamprotocols)** para um valor que permite apenas o transporte de websocket, i. . um valor de `4`, como apenas websockets são suportados para proxing.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `Senha`

Tipo `string` com valor padrão `null`. Esta propriedade define a senha usada em campo basic, digest, NTLM, e autenticação Kerberos que é suportada por uma máquina `WebProxy` que fornece funcionalidade proxy. Se o seu proxy não requer credenciais de usuário, não há necessidade de você inserir nada aqui. Usar esta opção só faz sentido se o `WebProxy` também for usado, já que ele não tem efeito caso contrário.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `WebProxyUsername`

Tipo `string` com valor padrão `null`. Esta propriedade define o nome de usuário usado em basic, digest, NTLM, e autenticação Kerberos que é suportada por uma máquina `WebProxy` que fornece funcionalidade proxy. Se o seu proxy não requer credenciais de usuário, não há necessidade de você inserir nada aqui. Usar esta opção só faz sentido se o `WebProxy` também for usado, já que ele não tem efeito caso contrário.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

## Estrutura de arquivos

O ASF usa uma estrutura de arquivos bem simples.

```text
── 📁 config
── ASF. son
── ASF.db
── Bot1. son
├── Bot1.db
── Bot2. son
── Bot2.db
── ...
── ArchiSteamFarm.dll
── log.txt
── ...
```

Para mover o ASF para um novo local, por exemplo, outro PC, basta mover/copiar a pasta `config` sozinho, e essa é a forma recomendada de fazer qualquer forma de "backups do ASF", já que você sempre pode baixar a parte (programa) restante do GitHub, sem correr o risco de corromper arquivos internos do ASF. . através de um suporte defeituoso.

O arquivo `log.txt` contém o registro gerado pela última execução do ASF. Este arquivo não contém informações confidenciais, e é extremamente útil quando se trata de issues, falhas ou simplesmente como informação para você o que aconteceu na última vez que o ASF foi executado. Muitas vezes, vamos perguntar sobre este arquivo se você se deparar com problemas. O ASF gerencia automaticamente esse arquivo para você, mas você pode ajustar ainda mais o módulo do ASF **registro[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging)** se você for um usuário avançado.

Diretório `config` é o lugar que mantém a configuração para o ASF, incluindo todos os seus bots.

`ASF.json` é um arquivo de configuração global do ASF. Esta configuração é usada para especificar como o ASF se comporta como um processo, o que afeta todos os bots e o próprio programa. Você pode encontrar propriedades globais aqui, tais como o proprietário do processo ASF, atualizações automáticas ou depuração.

`BotName.json` é uma configuração de determinada conta bot. Esta configuração é usada para especificar como determinado bot se comporta, Portanto, essas configurações são específicas para esse bot e não são compartilhadas entre as outras. Isso permite que você configure bots com várias configurações diferentes e não necessariamente todos eles trabalhando exatamente da mesma maneira. Cada bot é nomeado com um identificador único, escolhido por você no lugar de `BotName`.

Além dos arquivos de configuração, o ASF também usa a pasta `config` para armazenar bancos de dados.

`ASF.db` é um arquivo global de banco de dados do ASF. Ele atua como um armazenamento global persistente e é usado para salvar várias informações relacionadas ao processo ASF, tais como IPs de servidores locais Steam. **You should not edit this file**.

`BotName.db` é um banco de dados da determinada conta bot. Este arquivo é usado para armazenar dados cruciais sobre determinada conta bot em armazenamento persistente, como chaves de login ou ASF 2FA. **You should not edit this file**.

`BotName.keys` é um arquivo especial que pode ser usado para importar as keys para **[do ativador de jogos em segundo plano](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. Ele não é obrigatório e nem gerado, mas reconhecido pelo ASF. Esse arquivo é excluído automaticamente quando as chaves são importadas com sucesso.

`NomeDoBot.maFile` é um arquivo especial que pode ser usado para importar **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**. Ele não é obrigatório e nem gerado, mas reconhecido pelo ASF se o `BotName` ainda não usa o ASF 2FA. Esse arquivo é excluído automaticamente quando o ASF 2FA for importado com sucesso.

---

## Mapeamento JSON

Cada propriedade de configuração tem seu tipo. O tipo da propriedade define os valores que são válidos para ela. Você só pode usar valores válidos para determinado tipo - se você usar um valor inválido, então o ASF não será capaz de analisar sua configuração.

**É altamente recomendável usar o ConfigGenerator para gerar configurações** - ele lida com a maioria das coisas de baixo nível (como validação de tipos) para você, então você só precisa definir valores adequados e você também não precisa entender tipos de variáveis especificados abaixo. Esta seção é dedicada principalmente para as pessoas gerando/editando configurações manualmente, para que elas saibam quais valores podem usar.

Os tipos usados pelo ASF são nativos do C#, que são especificados abaixo:

---

`bool` - Boolean type accepting only `true` and `false` values.

Exemplo: `"Habilitado": true`

---

`byte` - Tipo byte sem sinal, aceita apenas números inteiros da `0` a `255` (inclusive).

Exemplo: `"ConnectionTimeout": 90`

---

`ushort` - Tipo curto sem sinal, aceitando apenas números inteiros da `0` a `65535` (inclusive).

Exemplo: `"WebLimiterDelay": 300`

---

`uint` - Tipo inteiro sem sinal, aceitando apenas números inteiros da `0` a `4294967295` (inclusive).

---

`ulong` - Tipo inteiro longo sem sinal, aceita apenas números inteiros da `0` a `18446744073709551615` (inclusive).

Exemplo: `"SteamMasterClanID": 103582791440160998`

---

`string` - String type, aceita qualquer sequência de caracteres, incluindo sequência de caracteres `""` e `null`. Sequência vazia e valor `null` são tratados da mesma forma pelo ASF, então cabe à sua preferência qual você quer usar (nós mantemos a `null`).

Exemplos: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MeuNomeDaConta"`

---

`Guid?` - Tipo de UUID Nullable, em JSON codificado como string. UUID é feito de 32 caracteres hexadecimais, no intervalo de `0` a `9` e `a` a `f`. O ASF aceita uma variedade de formatos válidos - minúsculas, maiúsculas, com e sem traços. Além de UUID válido, uma vez que essa propriedade é nulável, um valor especial de `null` é aceito para indicar a falta de UUID a fornecer.

Exemplos: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableList<valueType>` - Coleção (lista) imutável de valores de dado `valueType`. Em JSON, é definida como uma matriz de elementos de dado `valueType`. O ASF usa `Lista` para indicar que determinada propriedade suporta vários valores e que sua ordem pode ser relevante.

Exemplo para `ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` - Coleção imutável (conjunto) de valores únicos em dado `valueType`. Em JSON, é definida como uma matriz de elementos de dado `valueType`. O ASF usa `HashSet` para indicar que dada propriedade faz sentido apenas para valores exclusivos e que sua ordem não importa, portanto ele vai intencionalmente ignorar qualquer potencial duplicata durante a análise (se aconteceu de você que forneceu alguma coisa).

Exemplo de `ImmutableHashSet<uint>`: `"Blacklist": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>` - Dicionário (mapa) imutável que mapeia uma chave única especificada em `keyType`, para o valor especificado em seu `valorTipo`. Em JSON, é definido como um objeto com pares de valor chave. Tenha em mente que `keyType` é sempre citado nesse caso, mesmo se for um tipo de valor como `ulong`. Há também uma exigência rigorosa de a chave ser exclusiva através do mapa, desta vez imposta também pelo JSON.

Exemplo de `ImmutableDictionary<ulong, byte>`: `"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`

---

`flags` - O atributo flag combina várias propriedades diferentes em um valor final aplicando operações bit a bit. Isso permite que você escolha qualquer combinação possível de vários valores diferentes ao mesmo tempo. O valor final é construído como uma soma de valores de todas as opções habilitadas.

Por exemplo, dada a seguinte definição:

| Valor | Nome   |
| ----- | ------ |
| 0     | Nenhum |
| 1     | Um     |
| 2     | B      |
| 4     | C      |

Existem exatamente 3 bandeiras significativas e disponíveis para ligar/desligar (`A`, `B`, , `C`) e, portanto, `8` possíveis combinações válidas no total:

| Valor final | Bandeiras habilitadas |
| ----------- | --------------------- |
| 0           | `Nenhum`              |
| 1           | `Um`                  |
| 2           | `B`                   |
| 3           | `A` + `B`             |
| 4           | `C`                   |
| 5           | `A` + `C`             |
| 6           | `B` + `C`             |
| 7           | `A` + `B` + `C`       |

Por definição, para tornar possível o supracitado, cada bandeira autónoma deve, portanto, ser a potência de dois. É por isso que uma flag adicional no exemplo acima, `D`, precisaria carregar o valor de `8` ou superior.

Geralmente, as ferramentas gráficas farão o cálculo para você. Se você estiver editando configurações manualmente, você sempre pode usar a calculadora e simplesmente adicionar os valores subjacentes de todas as bandeiras que você deseja habilitar - como no exemplo acima.

Exemplo: `"SteamProtocols": 7` (que permite sinalizadores com valor de `1`, `2` e `4`, conforme explicado acima)

---

## Mapeamento de compatibilidade

Due to JavaScript limitations of being unable to properly serialize simple `ulong` fields in JSON when using web-based ConfigGenerator, `ulong` fields will be rendered as strings with `s_` prefix in the resulting config. Isso inclui, por exemplo, `"SteamOwnerID": 76561198006963719` que será escrito pelo nosso ConfigGenerator como `"s_SteamOwnerID": "76561198006963719"`. O ASF inclui uma lógica adequada para lidar automaticamente com o mapeamento dessa string, então as entradas `s_` nas suas configurações são válidas e corretamente geradas. Se você estiver gerando as configurações por conta própria, recomendamos manter os campos `ulong` originais se possível, mas se você não puder fazer isso, você também pode seguir este esquema e codificá-los como strings com `s_` prefixo adicionado aos seus nomes. Esperamos resolver essa limitação do JavaScript um dia.

---

## Configurações de compatibilidade

A prioridade máxima do ASF se mantém compatível com configurações antigas. Como você já deve saber, faltando propriedades de configuração são tratadas as mesmas que seriam definidas com **valores padrão**. Portanto, se novas propriedades de configuração forem introduzidas em uma nova versão do ASF, todas as suas configurações permanecerão **compatíveis com** com a nova versão. e o ASF tratará a nova propriedade de configuração como ela seria definida com o valor **padrão**. Você sempre pode adicionar, remover ou editar as propriedades de configuração de acordo com suas necessidades.

Recomendamos limitar as propriedades de configuração definidas apenas para aqueles que você deseja alterar, já que dessa forma você automaticamente herda valores padrão para todas as outras não só mantendo sua configuração limpa, mas também aumentando a compatibilidade caso decidamos alterar um valor padrão para a propriedade que você não quer explicitamente definir a si mesmo. . `WebLimiterDelay`).

Devido a cima, o ASF migrará automaticamente/otimizará suas configurações, reformatando-as e removendo os campos que possuem valor padrão. Você pode desativar esse comportamento com `--no-config-migrate` **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** se você tiver um motivo específico, por exemplo, você está fornecendo arquivos de configuração somente leitura e você não quer que o ASF os modifique.

---

## Auto-recarregar

O ASF está ciente de que as configurações são modificadas em "tempo real" - graças a isso, o ASF vai automaticamente:
- Criar (e iniciar, se necessário) novo bot, quando você criar a configuração do mesmo
- Parar (se necessário) e remover o bot antigo, quando você excluir a sua configuração
- Parar (e iniciar, se necessário) qualquer bot, quando você editar a configuração do mesmo
- Reiniciar (se necessário) o bot com novo nome, quando você renomear sua configuração

Todas as ações acima são transparentes e serão feitas automaticamente, sem a necessidade de reiniciar o programa, ou de matar outros bots (não afetados).

Além disso, o ASF também se reiniciará (se `auto Reiniciar` permitir) caso você modifique a configuração principal do ASF `ASF.json`. Da mesma forma, o programa será encerrado se você excluir ou renomeá-lo.

Você pode desabilitar esse comportamento com o argumento `--no-config-watch` **[de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** se você tiver um motivo específico, por exemplo, você não deseja que o ASF reaja às mudanças no arquivo na pasta `config`.