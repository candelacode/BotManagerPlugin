# Registo

O ASF permite que configure o seu próprio módulo de registo que será usado durante o tempo de execução. Pode fazê-lo colocando um ficheiro especial chamado `NLog.config` no diretório da aplicação. Toda a documentação do NLog no **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**, mas além disso encontrará alguns exemplos úteis aqui também.

---

## Registo padrão

Por padrão, o ASF registra no `ColoredConsole` (saída padrão) e no arquivo ``. O registro `File` inclui o arquivo `log.txt` no diretório do programa, e o diretório `logs` para fins de arquivamento.

Usar um arquivo NLog personalizado automaticamente desativa a configuração padrão do ASF, sua configuração substitui registros **completamente** padrão do ASF, o que significa que se você quiser manter. . nosso alvo `ColoredConsole` , então você deve defini-lo **você mesmo**. Isso permite que você não só adicione destinos de registro **extra** , mas também desabilite ou modifique **padrão**.

Se você quiser usar o registro padrão do ASF sem quaisquer modificações, você não precisa fazer nada - você também não precisa defini-lo em `personalizado NLog. onfig`. Para referência, porém, o equivalente ao registro padrão do ASF codificado seria:

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

## Integração do ASF

O ASF inclui alguns truques legais de código que melhoram sua integração com o NLog, permitindo que você capture mensagens específicas mais facilmente.

NLog-specific `${logger}` variable will always distinguish the source of the message - it will be either `BotName` of one of your bots, or `ASF` if message comes from ASF process directly. Desta forma você pode capturar facilmente mensagens de bots específicos, ou o processo do ASF (apenas) em vez de todos, com base no nome do registro.

O ASF tenta marcar mensagens adequadamente com base nos níveis de registro fornecidos pelo NLog. o que torna possível para você pegar apenas mensagens específicas de níveis de log específicos, em vez de todas. Claro, o nível de registro de uma mensagem específica não pode ser personalizado, uma vez que é a decisão codificada do ASF quão grave é dada a mensagem, mas você definitivamente pode tornar o ASF menos/mais silencioso conforme achar adequado.

O ASF registra informações extras, tais como mensagens de usuário/chat no nível de registro `Rastrear`. O registro padrão do ASF só contém o nível `Debug` e acima, que oculta essa informação extra. como isso não é necessário para a maioria dos usuários, além de atrapalhar a saída contendo potencialmente mensagens mais importantes. You can however make use of that information by re-enabling `Trace` logging level, especially in combination with logging only one specific bot of your choice, with particular event you're interested in.

Em geral, o ASF tenta torná-lo tão fácil e conveniente para você quanto possível. para registrar apenas mensagens que você deseja ao invés de forçá-lo a filtrar manualmente através de ferramentas de terceiros, como `grep` e similares. Basta configurar o NLog corretamente como escrito abaixo, e você deve ser capaz de especificar até mesmo regras muito complexas de registro com alvos personalizados como bancos de dados inteiros.

Regarding versioning - ASF tries to always ship with most up-to-date version of NLog that is available on **[NuGet](https://www.nuget.org/packages/NLog)** at the time of ASF release. Não será um problema usar qualquer recurso que você encontrar na wiki do NLog no ASF - apenas certifique-se de que você também está usando o ASF atualizado.

Como parte da integração com o ASF, o ASF também inclui suporte para destinos de registros NLog adicionais, que serão explicados abaixo.

---

## Exemplos

Os exemplos abaixo mostram como você pode personalizar o registro ao seu gosto.

Como iniciante, usaremos **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)** apenas alvo. Nosso `NLog.config` inicial ficará assim:

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

A explicação da configuração acima é bastante simples - definimos um **registro alvo**, que é `ColoredConsole`, então redirecionamos **todos os loggers** (`*`) de nível `Debug` e superior a `ColoredConsole` alvo que definimos anteriormente.

If you start ASF with above `NLog.config` now, only `ColoredConsole` target will be active, and ASF won't write to `File`, regardless of hardcoded ASF NLog configuration.

Uma vez que não definimos muitas propriedades, como o layout ``, ele foi inicializado para um valor padrão incorporado. neste caso `${longdate}├${level:uppercase=true}├${logger}├${message}`. Nós podemos personalizá-lo, por exemplo, registrando apenas a mensagem:

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

Se você abrir o ASF agora, verá essa data, nível e nome do registro desapareceram - deixando-o apenas com mensagens do ASF no formato `Function() Message`.

Também podemos modificar a configuração de log para mais de um alvo. Vamos entrar no `ColoredConsole` e **[`File`](https://github.com/nlog/nlog/wiki/File-target)** ao mesmo tempo.

```xml
<?xml version="1.0" encoding="utf-8" ?>
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

E feito, agora vamos registrar tudo no `ColoredConsole` e `File`. Você notou que também pode especificar `arquivo` personalizado e opções extras?

O ASF usa vários níveis de registro para tornar mais fácil para você entender o que está acontecendo. Podemos usar essas informações para modificar a gravidade do registro. Digamos que queremos registrar tudo (`Trace`) para `File`, , mas apenas `Aviso` e acima **[nível de log](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** para o `ColoredConsole`. Podemos conseguir isso modificando nossas regras ``:

```xml
<?xml version="1.0" encoding="utf-8" ?>
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

That's it, now our `ColoredConsole` will show only warnings and above, while still logging everything to `File`. Você pode ajustá-lo para registrá-lo, por exemplo, apenas `Info` e abaixo, e assim por diante.

Por último, vamos fazer algo um pouco mais avançado e registrar todas as mensagens no arquivo, mas apenas do bot chamado `LogBot`.

```xml
<?xml version="1.0" encoding="utf-8" ?>
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

Você pode ver como nós usamos a integração do ASF acima e facilmente distinguimos a fonte da mensagem com base na propriedade `${logger}`.

---

## Uso avançado

Os exemplos acima são bastante simples e feitos para te mostrar como é fácil definir suas próprias regras de registro que podem ser usadas com o ASF. You can use NLog for various different things, including complex targets (such as keeping logs in `Database`), logs rotation (such as removing old `File` logs), using custom `Layout`s, declaring your own `<when>` logging filters and much more. Eu te encorajo a ler toda a documentação **[NLog](https://github.com/nlog/nlog/wiki/Configuration-file)** para saber mais sobre todas as opções disponíveis para você, permitindo que você ajuste o módulo de registro do ASF da forma que quiser. É uma ferramenta muito poderosa e personalizar o registro do ASF nunca foi tão fácil.

---

## Limitações

O ASF desativará temporariamente **todas as regras** que incluem os alvos `ColoredConsole` ou `Console` quando estiver esperando uma entrada do usuário. Portanto, se você quiser manter o registro para outros alvos mesmo quando o ASF espera uma entrada do usuário, você deve definir esses alvos com suas próprias regras, como mostrado nos exemplos acima, em vez de colocar muitos alvos no `escreverPara` da mesma regra (a menos que esse seja o seu comportamento desejado). A desativação temporária dos alvos do console é feita a fim de manter o console limpo quando estiver esperando por uma entrada do usuário.

---

## Registro do chat

O ASF inclui suporte estendido para o registro do chat, não apenas gravando todas as mensagens recebidas/enviadas no nível de registro de `Rastreamento` , mas também expondo informações adicionais relacionadas a eles em **[propriedades do evento](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Isso é porque precisamos lidar com mensagens de bate-papo como comandos, mesmo assim, então não nos custa nada registrar esses eventos para que você possa adicionar uma lógica extra (como tornar o ASF seu arquivo pessoal de chat no Steam).

### Propriedades do evento

| Nome     | Descrição                                                                                                                                                                                                                                         |
| -------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Eco      | Tipo `bool`. Isso é definido como `verdadeiro` quando a mensagem está sendo enviada de nós para o destinatário e `false` caso contrário.                                                                                                          |
| mensagem | Tipo `string`. Esta é a mensagem enviada/recebida.                                                                                                                                                                                                |
| ID       | `ulong` type. Este é o ID do chat de grupo para mensagens enviadas/recebidas. Será `0` quando nenhum chat de grupo for usado para transmitir esta mensagem.                                                                                       |
| ChatID   | `ulong` type. Este é o ID do canal `ChatGroupID` para mensagens enviadas/recebidas. Será `0` quando nenhum chat de grupo for usado para transmitir esta mensagem.                                                                                 |
| SteamID  | `ulong` type. Este é o ID do usuário Steam para mensagens enviadas/recebidas. Pode ser `0` quando nenhum usuário em particular está envolvido na transmissão da mensagem (e. . quando é que estamos enviando uma mensagem para um chat em grupo). |

### Exemplo

Este exemplo é baseado em nosso `ColoredConsole` exemplo básico acima. Antes de tentar entendê-lo, Eu recomendo fortemente dar uma olhada **[acima](#examples)** a fim de aprender sobre o básico do registro NLog em primeiro lugar.

```xml
<?xml version="1.0" encoding="utf-8" ?>
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

Começamos com o nosso exemplo `ColoredConsole` básico e estendemo-lo ainda mais. Primeiro e mais importante Preparamos um arquivo de registro de chat permanente para cada canal de grupo e usuário do Steam - isso é possível graças às propriedades extras que o ASF nos expõe de forma chique. Também decidimos escolher um layout personalizado que grava apenas a data atual, a mensagem, informação enviada/recebida e o usuário Steam. Lastly, we've enabled our chat logging rule only for `Trace` level, only for our `MainAccount` bot and only for functions related to chat logging (`OnIncoming*` which is used for receiving messages and echos, and `SendMessage*` for ASF messages sending).

O exemplo acima irá gerar o arquivo `logs/chat/0-0-76561198069026042.txt` quando falar com **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
07-7-01:38:38 como você está? -> 76561198069026042
2018-07-26 01:38:38 Estou indo bem, que tal? <- 76561198069026042
```

Claro que este é apenas um exemplo de trabalho com alguns truques agradáveis de layout mostrados de forma prática. Você pode expandir ainda mais esta ideia para suas próprias necessidades, tais como filtragem extra, ordem personalizada, layout pessoal, gravação apenas de mensagens recebidas e assim por diante.

### Outro exemplo

Este usa `SteamTarget` para enviar uma mensagem para o steamID principal do bot (`76561198006963719`) quando o bot chamado `archi` recebe uma troca de doação. Requer outro bot no processo (já que você não pode enviar mensagens para você mesmo).

```xml
<?xml version="1.0" encoding="utf-8" ?>
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

## Alvos do ASF

Além dos alvos padrão de registro NLog (como `ColoredConsole` e `File` explicado acima), você também pode usar alvos de registro personalizados do ASF.

Para máxima completura, a definição de alvos do ASF seguirá a convenção da documentação do NLog.

---

### Alvo

Como você pode imaginar, este destino usa as mensagens do chat Steam para registrar mensagens do ASF. Você pode configurá-lo para usar um chat em grupo ou um chat privado. Além de especificar um alvo Steam para suas mensagens, você também pode especificar o `botName` do bot que deve enviar eles.

Suportado em todos os ambientes usados pelo ASF.

---

#### Sintaxe de configuração
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

Leia mais sobre como usar o arquivo de configuração [](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parâmetros

##### Opções Gerais
_nome_ - Nome do alvo.

---

##### Opções de layout
_layout_ - Texto a ser processado. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Requerido. Padrão: U `${level:uppercase=true}➲${logger}├${message}`

---

##### Opções do SteamTarget

_chatGroupID_ - ID do chat em grupo declarado como inteiro longo não assinado de 64-bit. Não é necessário. O padrão é `0` que irá desativar a funcionalidade de chat em grupo e usar o chat privado. Quando ativado (definido como valor diferente de zero), A propriedade `steamID` abaixo atua como `chatID` e especifica a ID do canal neste `chatGroupID` para o qual o bot deve enviar mensagens.

_steamID_ - SteamID declared as 64-bit long unsigned integer of target Steam user (like `SteamOwnerID`), or target `chatID` (when `chatGroupID` is set). Obrigatório. O padrão é `0` que desativa totalmente o registro do alvo.

_botName_ - Nome do bot (como é reconhecido pelo ASF, diferenciando maiúsculas de minúsculas) que estará enviando mensagens para `steamID` declaradas acima. Não é necessário. O padrão é `null` que selecionará automaticamente **qualquer** bot conectado atualmente. É recomendado definir esse valor apropriadamente, já que `SteamTarget` não leva em conta muitas limitações do Steam, tal como o fato de que você deve ter `steamID` do alvo na sua lista de amigos. Essa variável é definida como um tipo [layout](https://github.com/NLog/NLog/wiki/Layouts) , portanto você pode usar sintaxe especial nela, como `${logger}` para usar o bot que gerou a mensagem.

---

#### Exemplos de SteamTarget

A fim de escrever todas as mensagens de `Debug` level e acima, de um bot chamado `MyBot` para o steamID de `76561198006963719`, você deve usar o `NLog. onfig` similar a abaixo:

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

**Aviso:** Nosso `SteamTarget` é um alvo personalizado, então você deve se certificar de que você está declarando como `type="Steam"`, NÃO `xsi:type="Steam"`, já que xsi é reservado para alvos oficiais suportados pelo NLog.

Quando você abrir o ASF com o `NLog. onfig` similar a acima, O `MyBot` começará a enviar mensagens `76561198006963719` usuário Steam com todas as mensagens do ASF de costume. Tenha em mente que `MyBot` deve estar conectado para enviar mensagens, então todas as mensagens iniciais do ASF que aconteceram antes que nosso bot pudesse se conectar à rede Steam não serão encaminhadas.

Claro, `SteamTarget` tem todas as funções típicas que você poderia esperar do `TargetWithLayout`, para que você possa usá-lo em conjunto com e. . layouts personalizados, nomes ou regras de log avançadas. O exemplo acima é apenas o mais básico.

---

#### Screenshots

![Pré-visualizar](https://i.imgur.com/5juKHMt.png)

---

#### Ressalvas

Tenha cuidado quando decidir combinar `Debug` nível de registro ou abaixo no seu `SteamTarget` com `steamID` que está participando do processo do ASF. Isto pode levar a uma potencial `StackOverflowException` porque você vai criar um loop infinito de como o ASF recebe uma mensagem dada então registre-o através do Steam, resultando em outra mensagem que precisa ser registrada. Atualmente a única possibilidade disso acontecer é registrar `Rastrear` nível (onde o ASF grava suas próprias mensagens de chat), ou nível `Debug` enquanto executa o ASF no modo `Debug` (onde o ASF grava todos os pacotes Steam).

Em resumo, se o seu `steamID` estiver participando do mesmo processo do ASF. então o nível de registro `minlevel` do `SteamTarget` deve ser `Info` (ou `Debug` se você também não estiver executando o ASF em `Debug` modo acima) e superior. Como alternativa, você pode definir seu próprio `<when>` filtros de registro a fim de evitar um loop infinito de log, se a modificação do nível não for adequada para o seu caso. Essa ressalva também se aplica a chats em grupo.

---

### HistoryTarget

Este alvo é usado internamente pelo ASF para fornecer um histórico de registro de tamanho fixo no endpoint `/Api/NLog` do **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** que depois pode ser usado pela ASF-ui e outras ferramentas. Em geral você deve definir esse alvo somente se você já estiver usando uma configuração NLog personalizada para outras personalizações e também quer que o registro seja exposto na API do ASF. . para a ASF-ui. Também pode ser declarado quando você quiser modificar o layout padrão ou `maxCount` das mensagens salvas.

Suportado em todos os ambientes usados pelo ASF.

---

#### Sintaxe de configuração
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Leia mais sobre como usar o arquivo de configuração [](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parâmetros

##### Opções Gerais
_nome_ - Nome do alvo.

---

##### Opções de layout
_layout_ - Texto a ser processado. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Requerido. Padrão: `${date:format=yyyy-MM-dd HH\:mm\:ss}├${processname}-${processid}➲ ${level:uppercase=true}├${logger}├${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### Opções do HistoryTarget

_maxCount_ - Quantidade máxima de registros armazenados pela história sob demanda. Não é necessário. O padrão é `20` o que é um bom equilíbrio para fornecer histórico inicial, enquanto tivermos em mente o uso de memória que sai das exigências de armazenamento. Deve ser maior que `0`.