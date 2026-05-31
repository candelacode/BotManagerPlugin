# Perguntas frequentes

A seção de perguntas frequentes cobre respostas a questões comuns que você pode ter. Para questões menos comuns, por favor visite o nosso **[extended FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ)** em vez disso.

# Tabela de conteúdos

* [Geral](#general)
* [Comparação com ferramentas similares](#comparison-with-similar-tools)
* [Segurança / Privacidade / VAC / Banimentos / Termos de serviço](#security--privacy--vac--bans--tos)
* [Diversos](#misc)
* [Solicitações](#issues)

---

## Geral

### O que é ASF?
### Por que o programa afirma que não há nada para coletar em minha conta?
### Por que o ASF não detecta todos os meus jogos?
### Por que minha conta é limitada?

Before trying to understand what ASF is, you should make sure that you understand what Steam cards are, and how to obtain them, which is nicely described in official FAQ **[here](https://steamcommunity.com/tradingcards/faq)**.

Em resumo, as Cartas Colecionáveis são itens que você pode obter ao possuir um determinado jogo, e pode ser usado para fabricar insígnias, vender no mercado Steam ou qualquer outro propósito de sua escolha.

Os pontos principais são aqui novamente indicados. porque as pessoas em geral não querem concordar com elas e preferem fingir que elas não existem:

- **Você precisa possuir o jogo na sua conta Steam para ser elegível a receber cartas dele. O compartilhamento de família não é propriedade e não conta.**
- **Seu jogo não pode ser marcado como [privado](https://help.steampowered.com/faqs/view/1150-C06F-4D62-4966), o ASF vai automaticamente ignorar esses jogos durante a coleta.**
- **Você não pode coletar do jogo infinitamente, cada jogo tem um número fixo de cartas. Uma vez que você soltar todos eles (cerca de metade do jogo completo), o jogo não será mais candidato à coleta. Não importa se você vendeu, trocou, criou ou esqueceu o que aconteceu com os cartões que você obteve, assim que você ficar sem carta, o jogo será finalizado.**
- **Não é possível coletar cartas de jogos gratuitos sem gastar nenhum dinheiro neles. Isto significa jogos permanentemente gratuitos como Team Fortress 2 ou Dota 2. Possuir jogos F2P não lhe garante cartas.**
- **Não é possível coletar cartas em [contas limitadas](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A), independente dos jogos e do método de ativação.**
- **Os jogos pagos que você obteve gratuitamente durante uma promoção não podem ser obtidos para receber cartas, independentemente do que seja exibido na página da loja.**

Então como você pode ver, Cartas Colecionáveis Steam são concedidas a você por jogar um jogo que você comprou, ou jogo F2P no qual você colocou dinheiro. Se você jogar tal jogo por tempo suficiente, todas as cartas daquele jogo eventualmente cairão no seu inventário, tornando possível que você complete um emblema (depois de obter a metade restante do conjunto), venda-os ou faça o que mais você quiser.

Agora que explicamos as noções básicas do Steam, podemos explicar o ASF. O programa em si é bastante complexo para entender totalmente, então ao invés de analisar todos os detalhes técnicos, vamos oferecer uma explicação muito simplificada abaixo.

O ASF se conecta à sua conta Steam através de nosso cliente Steam personalizado embutido usando as credenciais fornecidas. Após acessar com sucesso, analisa o seu emblema **[](https://steamcommunity.com/my/badges)** a fim de encontrar os jogos que estão disponíveis para coleta (`X` cartas restantes). Depois de analisar todas as páginas e construir a lista final de jogos que estão disponíveis, o ASF escolhe o algoritmo de coleta mais eficiente e inicia o processo. The process depends upon chosen **[cards farming algorithm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** but usually it consists of playing eligible game and periodically (plus on each item drop) checking if game is fully farmed already - if yes, ASF can proceed with the next title, using the same procedure, until all games are fully farmed.

Tenha em mente que a explicação acima é simplificada e não descreve as dezenas de recursos e funções extras que o ASF oferece. Visite o resto de **[nossa wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki)** se você quiser saber todos os detalhes do ASF. Eu tentei torná-lo simples o suficiente para entender para todos, sem trazer detalhes técnicos - usuários avançados são encorajados a cavar mais fundo.

Agora como programa - o ASF oferece alguma mágica. Em primeiro lugar, ele não precisa baixar nenhum arquivo de jogo, ele pode jogar jogos imediatamente. Em segundo lugar, ele é inteiramente independente do seu cliente Steam normal - você não precisa ter o cliente Steam rodando, nem mesmo instalado. Em terceiro lugar, é uma solução automatizada - o que significa que o ASF faz tudo automaticamente atrás de você sem ter de lhe dizer o que fazer - o que nos poupa a aborrecimento e o tempo. Por último, ele não tem que enganar a rede Steam emulando o processo (que, por exemplo, o Idle Master está usando), já que ele pode se comunicar diretamente com ele. Também é super rápido e leve, sendo uma solução incrível para todos que querem obter cartas facilmente sem muita complicação - é especialmente útil deixá-las rodando em segundo plano enquanto faz outra coisa, ou mesmo reproduzindo em modo offline.

Tudo o que foi dito acima é bom, mas o ASF também tem algumas limitações técnicas que são aplicadas pela Steam - nós não podemos coletar de jogos que você não possui, não podemos coletar de jogos para sempre a fim de obter drops extras após o limite imposto e não podemos coletar de jogos enquanto vocês estão jogando. Tudo isso deve ser "lógico", considerando a forma como o ASF funciona, mas é bom notar que o ASF não tem superpoderes e não vai fazer algo que é fisicamente impossível, então tenha isso em mente - é basicamente o mesmo que se você dissesse a alguém fazer login na sua conta de outro PC e colete esses jogos para você.

Então, resumindo - o ASF é um programa que ajuda a pegar as cartas que você é elegível, sem muita complicação. Ele também oferece várias outras funções, mas vamos nos ater a esta por enquanto.

---

### Tenho que colocar minhas credenciais de conta?

**Sim**. O ASF exige suas credenciais de conta da mesma forma que o cliente oficial da Steam, já que ele está usando o mesmo método de interação com a rede Steam. Isso não significa, porém, que você tenha que colocar suas credenciais de conta nas configurações do ASF, você pode continuar usando o ASF usando o `SteamLogin` e/ou `SteamPassword`, e inserir esses dados cada vez que o ASF for executado, quando necessário (assim como várias outras credenciais de login, consulte a configuração). Desta forma, seus dados não são salvos em lugar nenhum, mas é claro que o ASF não pode iniciar automaticamente sem a sua ajuda. O ASF também oferece várias outras formas de aumentar a segurança **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**, então sinta-se livre para ler essa parte da wiki se você for um usuário avançado. Se você não é, e não quer colocar suas credenciais de conta nas configurações do ASF, então simplesmente não faça isso e, em vez disso, insira-as conforme necessário quando o ASF os pedir.

Tenha em mente que a ferramenta ASF é para seu uso pessoal e suas credenciais nunca deixarão seu computador. Você também não está compartilhando com ninguém, o que cumpre **[Acordo de Assinatura do Steam](https://store.steampowered.com/subscriber_agreement)** - uma coisa muito importante da qual muitas pessoas esquecem. Você não está enviando seus dados para nossos servidores ou um terceiro, somente diretamente para os servidores da Steam operados pela Valve. Nós não sabemos suas credenciais e também não somos capazes de recuperá-las para você, independentemente de você colocá-las nas configurações ou não.

---

### Quanto tempo tenho que esperar para receber as cartas?

**As long as it takes** - seriously. Cada jogo tem diferentes dificuldades de coleta definidas pelo desenvolvedor/editor, e cabe totalmente a eles decidir o quão rápido as cartas estão sendo fornecidas. A maioria dos jogos segue 1 carta a cada 30 minutos de jogo, mas também há jogos que exigem que você jogue até várias horas antes de receber uma carta. Além disso, sua conta pode ser impedida de receber cartas de jogos que você ainda não jogou por tempo suficiente. conforme mencionado na seção **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Não tente adivinhar quanto tempo o ASF deve coletar de determinado título - não cabe a você, nem ao ASF decidir. Não há nada que você possa fazer para deixá-lo mais rápido, e não há nenhum "bug" relacionado a cartas não serem recebidas em tempo hábil - você não controla o processo de recebimento de cartas, nem o ASF. Na melhor das hipóteses, você receberá a média de 1 carta a cada 30 minutos. Na pior, você não receberá nenhuma carta em 4 horas desde que iniciou o ASF. Ambas as situações são normais e estão abordadas na seção **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**.

---

### A coleta está demorando muito, posso de alguma forma acelerá-la?

The only thing which heavily affects speed of farming is selected **[cards farming algorithm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** for your bot instance. Tudo o resto tem um efeito insignificante e não vai acelerar a actividade agrícola. enquanto algumas ações, como iniciar o processo do ASF várias vezes, irão até mesmo **piorar o processo**. Se quisermos realmente fazer um apelo a todos os segundos a partir do processo agrícola. então o ASF permite que você configure algumas variáveis principais, como `FarmingDelay` - todas elas são explicadas na configuração **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. No entanto, como disse, o efeito é insignificante, e escolher o algoritmo de coleta de cartas adequado para determinada conta é uma e a única opção crucial que pode afetar fortemente a velocidade de coleta, Tudo o resto é puramente cosmético. Em vez de se preocupar com a velocidade da agricultura, apenas abra o ASF e deixe-o fazer seu trabalho - posso garantir que ele está fazendo isso da forma mais eficaz que eu poderia conseguir. Quanto menos você se importar, mais você ficará satisfeito.

---

### Mas o ASF disse que vai levar cerca de X!

O ASF te dá uma aproximação aproximada com base no número de cartas que você precisa receber, e seu algoritmo escolhido - este não está muito próximo do tempo real que você vai gastar na coleta, que geralmente é maior que isso, já que o ASF assume a melhor das hipóteses e ignora todas as peculiaridades da rede Steam, desconexão da internet, sobrecarga de servidores Steam e coisas do género. Ele deve ser visto apenas como um indicador geral de quanto você pode esperar que o ASF colete, Muitas vezes, na melhor das hipóteses, uma vez que o tempo real será diferente, ou mesmo significativo em alguns casos. Como dito acima, não tente adivinhar por quanto tempo determinado jogo vai ficar coletado, não cabe a você, nem ao ASF decidir.

---

### O ASF funciona no meu android/smartphone?

O ASF é um programa C# que requer a implementação funcional do .NET. Android became a valid platform starting with .NET 6.0, however, there is currently a major blocker in making ASF happen on Android due to **[lack of ASP.NET runtime available on it](https://github.com/dotnet/aspnetcore/issues/35077)**. Mesmo não havendo uma opção nativa disponível, existem compilações adequadas para GNU/Linux na arquitetura ARM, portanto, é totalmente possível usar algo como **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** para instalar o Linux, então usar o ASF em um chroot Linux como de costume.

Quando/Se todos os requisitos do ASF forem satisfeitos, consideraremos lançar uma compilação oficial do Android.

---

### O ASF pode coletar itens de jogos Steam, como CS:GO ou Unturned?

**Não**, isso é contra **[Acordo de Assinatura do Steam](https://store.steampowered.com/subscriber_agreement)** e Valve afirmaram claramente isso com a última onda de proibições da comunidade por coletar itens de TF2. O ASF é um programa de coleta automática de Cartas Colecionáveis Steam, não de itens de jogo - ele não tem capacidade de coletar itens de jogo e não está planejado adicionar tal recurso no futuro, nunca, principalmente por violar os termos de uso do Steam. Por favor, não pergunte sobre isso - o melhor que você pode obter é uma denúncia de algum usuário salgado e você está tendo problemas. O mesmo se aplica a todos os outros tipos de explorações, tais como as quedas agrícolas de emissões de CS:GO. O ASF é focado exclusivamente em cartas colecionáveis Steam.

---

### Posso escolher quais jogos devem ser coletados?

**Sim**, de várias maneiras diferentes. Se você quiser mudar a ordem padrão da fila de coleta, então é isso que `FarmingOrders` **[propriedade de configuração do bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** pode ser usado. Se você quiser bloquear manualmente jogos que foram coletados automaticamente, você pode usar a lista negra de ociosidade que está disponível com o comando `fb` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Se você gostaria de coletar tudo, mas dar prioridade a alguns apps sobre tudo, essa é a fila de prioridade ociosa disponível com o comando `fq` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** pode ser usado. E finalmente, se você deseja coletar de jogos específicos apenas da sua escolha, então você pode declarar `FarmPriorityQueueOnly` no **[`FarmingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)** para conseguir isso, Juntamente com a adição de seus apps selecionados à fila de prioridade ociosa.

Além de gerenciar o módulo de coleta automática que foi descrito acima, você também pode mudar o ASF para o modo de coleta manual com `play` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, ou use algumas outras configurações externas como `GamesPlayedWhileIdle` **[propriedade de configuração do bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

---

### Não estou interessado em receber cartas, gostaria que o horário de coleta fosse possível?

Sim, o ASF permite que você faça isso de várias maneiras.

A melhor maneira de conseguir isso é fazer uso da propriedade de configuração **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** que irá jogar seus appIDs escolhidos quando o ASF não tiver cartas para coletar. If you'd like to play your games all the time, even if you do have card drops from other games, then you can combine it with **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, so ASF will farm only those games for card drops that you explicitly set, or, alternatively, **[`FarmingPausedByDefault`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmingpreferences)**, which will cause cards farming module to be paused until you unpause it yourself.

Você também pode usar o comando **[`jogar`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#commands-1)** que fará com que o ASF jogue seus jogos selecionados. No entanto, tenha em mente que `jogar` deve ser usado apenas para jogos que você quer jogar temporariamente, como não é um estado persistente, fazendo com que o ASF reverta para o estado padrão. . após desconexão da rede Steam. Portanto, recomendamos que você use `GamesPlayedWhileIdle`, a menos que você realmente deseje iniciar seus jogos selecionados apenas por um curto período de tempo e depois reverta para o fluxo geral.

---

### Sou usuário do Linux / macOS, o ASF vai coletar dos jogos que não estão disponíveis para meu sistema operacional? O ASF vai coletar de jogos 64-bit quando eu rodo um SO de 32 bits?

Sim, o ASF nem sequer se preocupa em baixar os arquivos do jogo, portanto, ele funcionará com todas as suas licenças vinculadas à sua conta Steam, independentemente de qualquer plataforma ou requisitos técnicos. Ele também deve funcionar com jogos que tenham bloqueio regional, mesmo quando você não estiver na região de jogo, embora não garantamos que (funcionou da última vez que tentamos).

---

## Comparação com ferramentas similares

---

### O ASF é semelhante ao Idle Master?

A única semelhança é o propósito geral dos dois programas, que é coletar jogos Steam para receber cartas. Tudo o resto, incluindo o método de coleta real, a estrutura do programa, a funcionalidade, a compatibilidade, algoritmos usados, especialmente o próprio código-fonte, é completamente diferente e esses dois programas não têm nada em comum uns com os outros, até mesmo a fundação principal - o IMI está rodando em . ET Framework, ASF em .NET (Core). O ASF foi criado para resolver problemas do IM que não eram possíveis de serem resolvidos com uma simples edição do código; é por isso que o ASF foi escrito do zero, sem utilizar uma única linha de código ou mesmo uma ideia geral do IM, porque esse código e essas ideias eram inicialmente inteiramente errados. O IM e o ASF são como Windows e Linux - ambos são sistemas operacionais e ambos podem ser instalados no seu PC, mas não partilham quase nada uns com os outros, além de servirem o mesmo propósito.

Também é por isso que você não deve comparar o ASF com o IM baseado nas expectativas do IM. Você deve tratar o ASF e o IM como programas completamente independentes com suas próprias funcionalidades exclusivas. Alguns deles de fato se sobrepõem e você pode encontrar uma característica particular em ambos, mas muito raramente, já que o ASF serve seu propósito com uma abordagem completamente diferente em comparação com o IM.

---

### Vale a pena usar o ASF, se eu estiver usando o Idle Master e ele funciona bem para mim?

**Sim**. O ASF é muito mais confiável e inclui muitas funções embutidas **cruciais** independente de como você coletar, que o IM simplesmente não oferece.

ASF has proper logic for **unreleased games** - IM will attempt to farm games that have cards added already, even if they weren't released yet. Claro, não é possível coletar desses jogos até a data de lançamento, então seu processo de coleta estará travado. Isso exigirá que você adicione-o à lista negra, aguarde o lançamento ou pule manualmente. Nenhuma dessas soluções é boa, e todas precisam da sua atenção - o ASF pula automaticamente a coleta de jogos não lançados (temporariamente), e regressa-os mais tarde, quando estiverem, evitando completamente o problema e tratando-o de forma eficiente.

ASF also has proper logic of **series** videos. Há muitos vídeos na Steam que têm cartões, mas são anunciados com o `appID` errado na página de insígnias, tais como **[Double Fine Adventure](https://store.steampowered.com/app/402590)** - IM irá coletar falsamente `appID`, que não trará quaisquer gotas e trará obstáculos. Mais uma vez, você precisará colocar a lista negra ou pular manualmente, ambos exigindo a sua atenção. O ASF descobre automaticamente o appID `apropriado` para coleta, o que resulta na coleta de cartas.

Além disso, O ASF é **muito mais estável e confiável** quando se trata de problemas de rede e peculiaridades da Steam - ele funciona na maioria das vezes e não requer sua atenção uma vez configurado, enquanto o IM geralmente pausa para muitas pessoas, requer correções extras ou simplesmente não funciona de maneira alguma. Ele também é totalmente dependente do seu cliente Steam, o que significa que ele não pode funcionar se seu cliente Steam estiver com problemas sérios. O ASF funciona corretamente enquanto puder se conectar à rede Steam e não precisa que o cliente Steam esteja sendo executado, nem mesmo instalado.

Esses são 3 **** pontos muito importantes por que você deve considerar usar o ASF, já que eles afetam diretamente todos coletam cartas Steam e não há como dizer "isso não me considera", já que as manutenções e pecuárias do Steam acontecem com todo mundo. Há outras dezenas de razões mais ou menos importantes que você poderá aprender no resto do FAQ. Então em breve, falando, **sim**, você deve usar o ASF mesmo quando não precisar de nenhuma função extra do ASF que esteja disponível em comparação ao IM.

Além disso, o MI está oficialmente descontinuado e poderá pausar completamente no futuro. sem ninguém se preocupando em consertá-lo, considerando a existência de soluções muito mais poderosas (não apenas o ASF). O IM já não funciona para muitas pessoas, e esse número só está aumentando, não diminuindo. Você deve evitar usar softwares obsoletos, não apenas o IM, mas todos os outros programas obsoletos também. Nenhum mantenedor ativo significa que ninguém se importa se ele funciona ou não e **ninguém é responsável por sua funcionalidade**, que é uma questão crucial em termos de segurança. É o bastante para que haja um bug crítico que cause problemas na infraestrutura do Steam - com ninguém consertando, O Steam pode emitir outra onda de banimento na qual você será atingido sem sequer estar ciente de que isso é um problema como já aconteceu com as pessoas usando, adivinhe o quê, versão obsoleta do ASF.

---

### Que funcionalidades interessantes o ASF oferece que o Idle Master não?

Depende do que você acha "interessante" para você. Se você planeja coletar mais de uma conta então a resposta já é óbvia já que o ASF permite que você colete todas elas com uma solução superior, poupando recursos, aborrecimento e problemas de compatibilidade. No entanto, se você está fazendo essa pergunta é muito provável que você não tenha essa necessidade em particular. então vamos avaliar outros benefícios que se aplicam a uma única conta usada no ASF.

Primeiro e mais importante você tem alguns recursos embutidos mencionaram **[acima](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** que são principais para a agricultura, independentemente do seu objetivo final, e muitas vezes isso já é suficiente para considerar o uso do ASF. Mas você já sabe disso, então vamos passar para alguns recursos mais interessantes:

- **You can farm offline** (`OnlineStatus` in `Offline` setting). Coletar offline permite que você pule completamente o status do seu Steam no jogo, que te permite coletar com o ASF enquanto mostra "Online" na Steam ao mesmo tempo sem que seus amigos percebam que o ASF está jogando em seu nome. Esse é um recurso superior, pois ele permite que você permaneça online no seu cliente Steam, sem aborrecer seus amigos com constantes mudanças de jogos, ou engane-os a pensar que você está jogando um jogo quando na verdade não está. Se você respeita seus amigos este ponto sozinho faz valer a pena usar o ASF, mas é só o início. Também é bom notar que esse recurso não tem nada a ver com as configurações de privacidade do Steam - se você mesmo abrir o jogo, então você aparecerá corretamente para seus amigos, tornando apenas a parte do ASF invisível e não afetando sua conta.

- **Você pode pular jogos reembolsáveis** (`SkipRefundableGames` no recurso `FarmingPreferences` do bot). O ASF tem uma lógica embutida para jogos reembolsáveis e você pode configurar o ASF para não coletar automaticamente dos jogos reembolsáveis. Isso permite que você avalie se seu jogo recém comprado na loja Steam valeu o seu dinheiro, sem que o ASF tente coletar cartas assim que possível. Se você jogar por mais de 2 horas ou se passarem 2 semanas desde sua compra, então o ASF procederá com aquele jogo pois ele não é mais reembolsável. Até lá, você tem controle total se gosta ou não e você pode facilmente reembolsar se necessário, sem ter que bloquear manualmente esse jogo ou não usar o ASF para a duração inteira.

- **Você pode pular jogos não jogados** (`SkipUnplayedGames` no recurso `FarmingPreferences` do bot). O ASF tem uma lógica embutida durante horas nos jogos e você pode configurar o ASF para não jogar automaticamente jogos. Isso permite que você se controle os jogos que você joga e coleta, sem ter que bloquear manualmente todos eles ou pular usando o ASF completamente.

- **Você pode marcar automaticamente novos itens como recebidos** (`BotBehaviour` of `DismissInventoryNotifications` feature). Coletar com o ASF fará com que sua conta receba novas cartas. Você já sabe que isso vai acontecer, então deixe o ASF limpar essa notificação inútil para você, assegurar que apenas aspectos importantes suscitem a vossa atenção. É claro, só se você quiser.

- **You can customize preferred farming order with more available options** (`FarmingOrders` feature). Talvez você queira coletar dos seus jogos recém-comprados primeiro? Ou os mais velhos? De acordo com a quantidade de cartas disponíveis? Você já criou níveis? Horas jogadas? Alfabético? De acordo com AppIDs? Ou talvez totalmente aleatório? Isso é inteiramente você que decide.

- **O ASF pode ajudá-lo a completar seus conjuntos** (`TradingPreferences` com a função `SteamTradeMatcher`). Com um pouco mais de aperfeiçoamento, você pode converter seu ASF em um bot que automaticamente aceitará ofertas **[STM](https://www.steamtradematcher.com)** , ajudá-lo a todos os dias a coincidir com seus conjuntos sem qualquer interação do usuário. O ASF inclui mesmo seu próprio módulo ASF 2FA que permite que você importe seu autenticador móvel Steam e que você automatize completamente todo o processo aceitando confirmações também. Ou, talvez você queira aceitar manualmente e deixar o ASF apenas preparar essas trocas para você? Mais uma vez, cabe inteiramente a você decidir.

- **O ASF pode resgatar keys em segundo plano para você** (**[recurso "redeemer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** em segundo plano). Talvez você tenha centenas de chaves de vários pacotes que é preguiçoso demais para se resgatar, passar por um monte de janelas e concordar com os termos e condições do Steam várias vezes. Por que não copiar e colar sua lista de keys no ASF e deixá-lo fazer o seu trabalho? O ASF vai resgatar automaticamente todas essas keys em segundo plano, fornecendo uma saída para você saber como cada tentativa de ativação. Além disso, se você tem centenas de chaves, é certo que você terá a taxa limitada pelo Steam mais cedo ou mais tarde. e o ASF também sabe disso, vai esperar pacientemente o limite de tarifa para desaparecer e retomar de onde partiu.

Nós poderíamos continuar com todo o **[ASF wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**, apontando cada uma das características do programa, mas temos de traçar uma linha em algum lugar. É isso, esta é uma lista de recursos que você pode desfrutar como usuário do ASF, onde apenas um desses poderia facilmente ser considerado uma das principais razões para nunca olhar para trás, e na verdade listamos **muito** deles, com ainda mais você pode aprender sobre o resto da nossa wiki. Ah sim, e nem sequer entramos em detalhes com coisas como a API do ASF, permitindo que você escreva seus próprios comandos, ou gestão incrível de bots, uma vez que quisemos manter tudo simples.

---

### O ASF é mais rápido que o Idle Master?

**Sim**, embora a explicação seja um pouco complicada.

Em cada novo processo foi gerado e terminado em seu sistema, O cliente Steam envia automaticamente uma solicitação contendo todos os seus jogos que você está jogando atualmente - dessa forma a rede Steam pode calcular as horas e obter cartas. No entanto, a rede Steam conta seu tempo de jogo em intervalos de 1 segundo, e enviar uma nova solicitação redefine o status atual. Em outras palavras, se você gerar/matar um novo processo a cada 0,5 segundos, você nunca dropará uma carta porque cada 0. o segundo cliente Steam enviaria uma nova solicitação e a rede Steam nunca contaria nem 1 segundo de jogo. Além disso, devido à forma como o sistema operacional funciona, na verdade é bastante comum ver novos processos sendo gerados/encerrados sem que você faça qualquer coisa. então mesmo que você não esteja fazendo nada no seu PC - há muitos processos trabalhando em segundo plano, iniciando/terminando outros processos o tempo todo. O Idle master é baseado no cliente Steam, então esse mecanismo te afeta se você o estiver usando.

O ASF não é baseado no cliente Steam, ele tem sua própria implementação do cliente Steam. Graças a isso, o que o ASF faz não cria nenhum processo, mas na verdade enviando um pedido real para a rede Steam que começamos a jogar um jogo. Este é o mesmo pedido que seria enviado pelo cliente Steam, mas como temos controle sobre o cliente Steam do ASF, não precisamos gerar novos processos, e não estamos imitando o cliente Steam sobre o envio de solicitação em cada mudança de processo, então o mecanismo explicado acima não nos afeta. Graças a isso, nós nunca interrompemos aquele intervalo de 1 segundo no lado do Steam web, e isso aumenta nossa velocidade de coleta.

---

### Mas a diferença é realmente notável?

Não. As interrupções que estão acontecendo com o cliente Steam normal e com o mestre ocioso têm um efeito insignificante nas cartas recebidas, portanto não é uma diferença perceptível que tornaria o ASF superior.

No entanto, existe **é** uma diferença e você pode claramente notar isso, pois dependendo de como seu sistema operacional está ocupado, as cartas **irão** cair mais rápido, de alguns segundos a alguns minutos, se você for extremamente azarado. Embora eu não considerasse usar o ASF apenas porque ele coleta cartas mais rápido, já que tanto o ASF quanto o Idle Master são afetados pela forma que a rede Steam funciona, O ASF apenas interage com a rede Steam de forma mais eficaz, enquanto o Idle Master não consegue controlar o que o cliente Steam está fazendo de fato (então não é culpa do Idle Master, mas o cliente Steam é ele mesmo).

---

### O ASF consegue coletar de vários jogos de uma vez?

**Yes**, although ASF knows better when to use that feature, based on selected **[cards farming algorithm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. A taxa de recebimentos de cartas quando se coleta de vários jogos está perto de zero, É por isso que o ASF usa vários jogos coletando exclusivamente por horas para superar o `HoursUntilCardDrops` mais rápido, para até `32` jogos de uma vez. Também é por isso que você deve se concentrar na configuração de parte do ASF, e deixe os algoritmos decidirem qual é a melhor maneira de atingir o objetivo - o que você acha que está certo, na realidade, coletar de vários jogos de uma só vez não lhe dará nenhuma carta.

---

### O ASF pode pular rapidamente os jogos?

**Não**, o ASF não suporta, nem encoraja o uso de falhas **[Steam](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance#steam-glitches)**.

---

### O ASF pode jogar cada jogo por X horas antes das cartas serem adicionadas?

**No**, the whole point of Steam cards system change was to fight with false statistics and ghost players. O ASF não vai contribuir para isso mais que o necessário, adicionar tal recurso não está planejado e não vai acontecer. Se o seu jogo recebe cartas da forma padrão, o ASF vai coleta-las o mais rápido possível.

---

### Posso jogar um jogo enquanto o ASF estiver coletando?

**Não**. ASF, unlike some other tools that integrate with your Steam client, has its independent implementation of that client included, and Steam network allows only **one Steam client at a time** to play a game. No entanto você pode desconectar o ASF sempre que quiser iniciando um jogo (e clicando em "OK" quando perguntado se a rede Steam deve desconectar outro cliente) - o ASF então vai esperar pacientemente até que você termine de jogar, e retomar o processo depois. Como alternativa, você pode jogar no modo offline sempre que quiser, se isso for satisfatório para você.

Tenha em mente que a taxa de coleta de cartas quando se joga vários jogos é próxima a zero, Portanto, não há benefícios directos de ser capaz de fazer isso com outros instrumentos, enquanto há fortes benefícios de não interferir com outros jogos lançados com o ASF, o que é crucial. . VAC-wise.

---

## Segurança / Privacidade / VAC / Banimentos / Termos de serviço

---

### Posso ser banido pelo VAC por isso?

Não, não é possível porque o ASF (diferente de outras ferramentas, como Idle Master, SGI ou SAM) não interferem de forma alguma com o cliente Steam nem com os seus processos. É fisicamente impossível fazer banimento VAC por usar o ASF, mesmo durante jogos em servidores seguros enquanto o ASF está rodando - isso ocorre porque o **ASF nem precisa que o cliente Steam esteja instalado** para funcionar corretamente. O ASF é um dos únicos programas de coleta que podem atualmente garantir ser livres de VAC.

---

### Can using ASF prevent me from playing on VAC-secured servers, as stated **[here](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**?

O ASF não precisa que o cliente Steam esteja sendo executado e nem mesmo que ele seja instalado. According to this concept, it should **not** cause any VAC-related issues, because ASF guarantees lack of interfering with Steam client and all its processes - this is the main point when talking about VAC-free guarantee that ASF offers.

De acordo com utilizadores e meu conhecimento, esse é o caso agora, como ninguém reportou quaisquer problemas, como mencionado no link acima enquanto usava o ASF. Também não podíamos reproduzir o problema acima com o ASF, enquanto o reproduzíamos claramente com o Idle Master.

No entanto, tenha em mente que a Valve ainda poderia adicionar o ASF à lista negra em algum momento. mas é um completo disparate, como se eles fizessem isso, você ainda poderia jogar jogos protegidos pelo VAC em seu PC e usar o ASF ao mesmo tempo. . em seu servidor, então tenho certeza de que eles sabem muito bem que o ASF não deve ser suspeito em relação ao VAC, e eles não vão dificultar nossas vidas bloqueando o ASF sem motivo. Ainda assim, no pior caso você não poderá jogar, como dito acima, porque a garantia do ASF livre de VAC ainda está aqui, independentemente de o Steam bloquear o binário do ASF, ou não (e você ainda pode abrir o ASF em qualquer outro computador sem que o cliente Steam esteja instalado). No momento, não há necessidade de fazer isso, e vamos esperar que continue assim.

---

### É seguro?

Se você perguntar se o ASF é seguro como um software, o que significa que ele não causará qualquer dano ao seu computador, não vai roubar seus dados privados, instalar vírus ou qualquer outra coisa assim - está seguro. ASF é livre de malware, roubo de dados, mineradores de criptomoeda e qualquer (e todos) outro comportamento duvidoso que possa ser considerado malicioso ou indesejado pelo usuário. In addition to that we have a dedicated **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section which covers our privacy policy and ASF behaviour that goes beyond what you configured the program to do yourself.

Our code is open-source, and distributed binaries are always compiled from **[publicly available sources](https://en.wikipedia.org/wiki/Open-source_software)** by **[automated and trusted continuous integration systems](https://en.wikipedia.org/wiki/Build_automation)**, and not even developers themselves. Each build is reproducible by following our build script and will result in exactly the same, **[deterministic](https://en.wikipedia.org/wiki/Deterministic_system)** IL (binary) code. Se você por qualquer motivo não confia em nossas compilações, você sempre pode compilar e usar o ASF da fonte, incluindo todas as bibliotecas que o ASF usa (como o SteamKit2), que também são de código aberto.

No final, porém, é sempre uma questão de confiança no(s) desenvolvedor(es) do seu aplicativo, então você deve decidir se você considera o ASF seguro ou não, provavelmente apoiando sua decisão com argumentos técnicos especificados acima. Não acredite cegamente em algo só porque nós dissemos isso - verifique você mesmo, pois essa é a única maneira de ter certeza.

---

### Posso ser banido por isso?

Para responder a essa pergunta, devemos dar uma olhada no **[Acordo de Assinatura do Steam](https://store.steampowered.com/subscriber_agreement)**. O Steam não proíbe o uso de várias contas, de fato, **[permite](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)** dizer que você pode usar o mesmo autenticador móvel em mais de uma conta. O que ele não permite é compartilhar sua conta com outras pessoas, mas nós não estamos fazendo isso aqui.

O único ponto que realmente considera o ASF é o seguinte:
> Você não pode usar Cheats, software de automação (bots), mods, hacks, ou qualquer software não autorizado de terceiros, para modificar ou automatizar qualquer processo do Mercado de Assinaturas.

A questão é: o que de fato é o Mercado de Assinaturas? Como podemos ler:

> Um exemplo de Mercado de Assinaturas é o Mercado da Comunidade Steam

Não estamos modificando ou automatizando o processo do Mercado de Assinaturas se entendermos por Mercado de Assinaturas o Mercado da Comunidade ou a Loja Steam. (*,*...

> A Valve pode cancelar sua Conta ou qualquer Assinatura específica a qualquer momento, caso (a) a Valve deixe de fornecer tais Assinaturas a Assinantes em estado similar, ou (b) você viola quaisquer termos deste Acordo (incluindo quaisquer Termos de Assinatura ou Regras de Uso).

Portanto, como em todos os softwares do Steam, O ASF não é autorizado pela Valve e eu não posso garantir que você não será suspenso se a Valve decidir de repente que vão proibir contas que usam o ASF. Isso é muito improvável, considerando o fato de que o ASF está sendo usado em mais de alguns milhões de contas Steam, desde a sua primeira libertação que aconteceu há mais de 10 anos - mas ainda é uma possibilidade, independentemente da probabilidade real.

Especialmente porque:
> Em relação a todas as Assinaturas, Conteúdo e Serviços que não são de autoria da Valve, A Valve não tela esse conteúdo de terceiros disponíveis no Steam ou por meio de outras fontes. A Valve não assume nenhuma responsabilidade ou responsabilidade por esses conteúdos de terceiros. Alguns softwares de aplicativos de terceiros podem ser usados por empresas para fins comerciais - no entanto, você só pode adquirir esse software via Steam para uso privado.

No entanto, a Valve reconhece claramente a existência de "Steam idlers", como indicado **[aqui](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**, então se você me perguntar, Tenho certeza de que se não estivessem bem com eles, eles já teriam feito algo em vez de apontar que poderiam causar problemas com o VAC. A palavra-chave aqui é **Steam** idlers, por exemplo, o ASF e não **jogo** idlers.

Note que acima é apenas nossa interpretação de **[Acordo de Assinatura do Steam](https://store.steampowered.com/subscriber_agreement)** e vários pontos - o ASF é licenciado sob o Apache 2. Licença, que afirma claramente:

```
A menos que exigido por lei aplicável ou acordado por escrito, o software
distribuído sob a Licença é distribuído em "COMO ESTÁ",
SEM GARANTIAS OU CONDIÇÕES DE QUALQUER TIPO, expressas ou implícitas.
```

Você está usando este software por sua conta e risco. É extremamente improvável que você possa ser banido por isso, mas se o fizer, você pode culpar apenas a si mesmo por isso.

---

### Alguém foi banido por isso?

**Sim**, tivemos pelo menos alguns incidentes até agora que resultaram em algum tipo de suspensão do Steam. Se o ASF em si foi a causa principal ou não é uma história completamente diferente que nós provavelmente nunca saberemos.

O primeiro caso envolveu um cara com mais de 1000 bots e ter trocas banidas (junto com todos os bots), provavelmente devido ao uso excessivo do `saque o ASF` executado em todos os bots de uma vez. ou outra suspeita de quantidade de operações unilaterais em um período muito curto.

> Olá, XXX, Obrigado por contatar o suporte Steam. Parece que esta conta foi usada para gerenciar uma rede de contas bot. O uso de bots viola o Acordo de Assinatura do Steam.

Por favor, use o senso comum e não assuma que você pode fazer essas coisas malucas apenas porque o ASF permite que você faça isso. Fazer o `saque ASF` em mais de 1k de bots pode ser facilmente considerado um ataque **[DDoS](https://en.wikipedia.org/wiki/DDoS)** , e, pessoalmente, não estou chocado com o facto de alguém ter sido banido por tal coisa. Mantenha o mínimo de uso justo em relação ao serviço do Steam, e **provavelmente** você estará bem.

Segundo caso envolvia um cara com mais de 170 bots ser banido durante a Promoção de Inverno 2017 do Steam.

> Sua conta foi bloqueada por violação do acordo de assinante do Steam. Julgando pelas trocas e outros fatores, essa conta foi usada para coletar ilegalmente cartas colecionáveis no Steam, Além de actividades relacionadas e não apenas comerciais. A conta foi bloqueada permanentemente e o suporte Steam não pode fornecer suporte adicional sobre esta questão.

Este caso é mais uma vez muito difícil de analisar, por causa da vaga resposta do suporte Steam que mal oferece quaisquer detalhes. Baseado em meus pensamentos pessoais, este usuário provavelmente trocou cartas Steam por algum tipo de dinheiro (bot para subir de nível? ou de alguma outra forma tentou sacar o dinheiro no Steam. In case you were unaware, this is also illegal according to **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Nós não estamos em condições de dizer o que você pode fazer com as cartas colecionáveis obtidas através do ASF, mas o usuário em questão definitivamente não criou as insígnias com elas.

Terceiro caso envolveu banimento de usuário com mais de 120 bots por violação de **[conduta online do Steam](https://store.steampowered.com/online_conduct?l=english)**.

> Olá, XXX, Obrigado por contatar o suporte Steam. Essa e outras contas foram usadas para inundar nossa infraestrutura de rede, o que é uma violação da conduta online do Steam. A conta foi bloqueada permanentemente e o suporte Steam não pode fornecer suporte adicional sobre esta questão.

Este caso é um pouco mais fácil de analisar por causa de detalhes adicionais fornecidos pelo usuário. Aparentemente, o usuário estava usando **uma versão muito desatualizada do ASF** que incluía um bug que fazia com que o ASF enviasse um número excessivo de solicitações para os servidores Steam. O bug em si não existia no início, mas foi ativado devido a uma mudança no Steam que causou falhas e que foi corrigida na futura versão. **O ASF é suportado apenas na versão estável [mais recente do](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) lançado no GitHub**.

Você não pode assumir que uma versão desatualizada do ASF funcionará da mesma forma que ela funciona para sempre, especialmente porque o Steam está constantemente mudando independentemente de você gostar ou não. Se tal coisa acontecer globalmente, ela está sendo rapidamente corrigida e liberada para todos os usuários como uma correção de erros. A Valve não vai banir mais de um milhão de usuários do ASF de repente devido a nosso ou seu erro, por razões óbvias. No entanto, se você intencionalmente desistir de usar o ASF atualizado, em seguida, por definição, você está em uma minoria muito pequena de usuários que estão **expostos a incidentes como estes** devido a **não suporte**, já que ninguém está assistindo sua versão desatualizada do ASF, ninguém vai consertá-lo e ninguém garante que você não seja completamente banido apenas iniciando. **Please use up-to-date software**, not only ASF, but all other applications as well.

O caso mais recente aconteceu por volta de junho de 2021, de acordo com o usuário:

> Usando seu programa, eu faço pacotes com 28 contas há 3 anos e com 128 contas nos últimos 6 meses. Estive online com um máximo de 15 contas simultaneamente para fazer pacotes e enviá-los para a conta principal. No mês passado, aumentei o número de contas online simultaneamente para 20, e 1 semana depois disso, todas as minhas contas foram banidas. Este correio electrónico não vos culpau, pelo contrário, sempre tomei consciência das consequências. Eu queria que você soubesse quais tipos de comportamento resultam em uma proibição permanente.

É difícil dizer se o aumento das contas simultâneas online foi a razão direta do banimento, Eu não contaria com isso, ao invés disso acredito que o número de contas sozinho foi o principal culpado, aumento da concorrência de contas online provavelmente apenas chamou a atenção para o usuário em questão, já que ele claramente tinha muito mais bots do que nossa recomendação.

---

Todos os incidentes acima têm uma coisa em comum - o ASF é apenas uma ferramenta e ele é **sua** decisão de como você vai usar ela. You do not get banned for using ASF directly, but for **how** you're using it. Ele pode ser uma ferramenta de coleta de uma única conta ou uma rede massiva de coleta feita de milhares de bots. Em qualquer caso, eu não estou oferecendo aconselhamento legal, e você deve decidir por sua conta sobre o uso do ASF. Não estou escondendo nenhuma informação que poderia te ajudar, por exemplo. o fato do ASF ter banido algumas pessoas (e em que contexto), como eu não tenho razão para - é sua escolha o que você quer fazer com essas informações.

If you ask me - use some common sense, avoid owning more bots than our recommendation, do not send hundreds of trades at the same time, always use up-to-date ASF version and you _should_ be fine. Cada incidente desta natureza por **alguma razão** sempre aconteceu com pessoas que ignoraram nossas recomendações, as melhores práticas e sugestões, acreditando que sabem melhor do que nós. . quantos bots eles podem executar. Se isso é apenas coincidência ou algum fator real, cabe a você decidir. Não estamos oferecendo qualquer aconselhamento legal, apenas passando nossos pensamentos que você pode achar útil, ou ignore-os totalmente e opere apenas em fatos acima relacionados.

---

### Quais informações de privacidade o ASF divulga?

Você pode encontrar uma explicação detalhada em **[comunicação remota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication).**. Você deve revê-la se você se importa com sua privacidade, por exemplo, se você está se perguntando por que contas usadas no ASF estão entrando em nosso grupo Steam. O ASF não coleta quaisquer informações confidenciais e não as compartilha com quaisquer terceiros.

---

## Diversos

---

### Estou usando um sistema operacional não suportado, como Windows 32-bit por exemplo, ainda posso usar a última versão do ASF?

Sim, e essa versão não é de forma alguma desprovida de suporte, apenas não foi oficialmente construída. Confira a secção **[compatibilidade](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** para a variante genérica. O ASF não tem qualquer forte dependência do SO, e ele pode funcionar em qualquer lugar onde você possa começar a funcionar. Especifica o tempo de execução, que inclui o Windows 32-bit, mesmo que não haja um pacote `win-x86` específico da nossa parte.

---

### O ASF é ótimo! Posso fazer uma doação?

Sim, e estamos muito felizes em saber que você está gostando do nosso projeto! Você pode encontrar várias possibilidades de doação sob cada **[liberar](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** e também **[na página principal](https://github.com/JustArchiNET/ArchiSteamFarm)**. É bom notar que além de doações genéricas em dinheiro também aceitamos itens do Steam, então nada te impede de doar skins, chaves ou uma pequena parte das cartas que você coletou com o ASF caso deseje. Obrigado desde já por sua generosidade!

---

### Eu uso o PIN do modo família para proteger minha conta, eu preciso colocá-lo em algum lugar?

Sim, você deve colocá-lo no parâmetro de configuração do bot `SteamParentalCode`. Isso acontece principalmente porque o ASF acessa muitas partes da sua conta Steam e é impossível que o ASF opere sem isso.

---

### Eu não quero que o ASF colete de nenhum jogo por padrão, ainda quero usar os recursos extras do ASF. Será isto possível?

Sim, se você deseja apenas iniciar o ASF com o módulo de coleta pausado, Você pode definir a propriedade de configuração do bot `FarmingPausedByDefault` no parâmetro `FarmingPreferences` para conseguir isso. This will allow you to `resume` it during runtime.

Se você deseja desativar completamente o módulo de coleta e garantir que ele nunca seja executado sem que você diga explicitamente o contrário, então recomendamos definir `FarmPriorityQueueOnly` no `FarmingPreferences`, do bot que em vez de apenas pausá-la, desativará a coleta completamente até que você adicione os jogos na fila de prioridade de coleta.

Com o módulo de coleta pausado/desativado, você pode utilizar recursos extras do ASF, como o `GamesPlayedWhileIdle`.

---

### O ASF pode minimizar para a bandeja?

O ASF é um aplicativo de console, não há janela para ser minimizada, porque as janelas são criadas para você pelo seu SO. No entanto, você pode usar qualquer ferramenta de terceiros capaz de fazer isso, como **[RBTray](https://github.com/benbuck/rbtray)** para Windows, or **[screen](https://linux.die.net/man/1/screen)** para Linux/macOS. Essas são apenas exemplos, existem muitas outras aplicações com funcionalidades semelhantes.

---

### Usar o ASF mantém a elegibilidade para receber pacotes de cartas?

**Sim**. O ASF usa o mesmo método para se conectar à rede Steam que o cliente oficial, Portanto, ele também preserva a capacidade de receber pacotes de cartas para contas que estão sendo usadas no ASF. Além disso, preservar essa habilidade não requer nem entrar na comunidade Steam, então você pode usar com segurança `OnlineStatus` no ajuste `Offline` se você quiser.

---

### Existe alguma maneira de se comunicar com o ASF?

Sim, de várias maneiras diferentes. Confira **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** na seção para mais informações.

---

### Eu gostaria de ajudar com a tradução do ASF, o que eu preciso fazer?

Obrigado pelo seu interesse! You can find all details in our **[localization](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)** section.

---

### Tenho apenas uma conta (principal) adicionada ao ASF, posso emitir comandos através do chat Steam?

**Sim**, é explicado no comando **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#notes)** seção. You can do so through Steam group chat, although using **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** could be easier for you.

---

### O ASF parece estar funcionando, mas eu não estou recebendo nenhuma carta!

A taxa de coleta de cartas difere de jogo para jogo, pois você pode ler em **[desempenho](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Demora um pouco, geralmente **várias horas por jogo**, e você não deve esperar que as cartas apareçam em poucos minutos após a inicialização de um programa. Se você ver que o ASF verifica ativamente o estado das cartas e troca de jogo após o atual ficar totalmente coletado, então tudo está funcionando bem. É possível que você tenha habilitado uma opção como `DismissInventoryNotifications` of `BotBehaviour` que dispensa automaticamente as notificações de inventário. Confira **[configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** para detalhes.

---

### Como parar completamente o processo do ASF para minha conta?

Simplesmente feche o processo ASF, por exemplo, clicando [X] no Windows. Se, em vez disso, você quiser parar um bot específico de sua escolha, mas mantenha outros executados, em seguida, dê uma olhada no parâmetro `Ativado` **[do bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**, ou `parar` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Se você preferir parar o processo de coleta automática, mantenha o ASF em execução para sua conta, então é isso que o `FarmingPausedByDefault` opção da propriedade `FarmingPreferences` do bot **[config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** e `pause` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** serve.

---

### Quantos bots posso rodar com o ASF?

O ASF em si não tem qualquer limite máximo de contas bot, então você pode correr tanto quanto tem memória na sua máquina, no entanto, você ainda está sendo limitado pela rede Steam e por outros serviços Steam. Atualmente você pode rodar de 100 a 200 bots por IP e por instância do ASF. É possível executar mais bots com mais IPs e mais instâncias do ASF, contornando as limitações de IP. Tenha em mente que se você estiver usando uma grande quantidade de bots, você deve controlar o número deles por conta própria, por exemplo, certificar-se de que todos eles estão, de facto, a entrar e a trabalhar ao mesmo tempo. O ASF não foi ajustado por um grande número de bots, e a regra geral se aplica que **quanto mais bots você tiver, mais problemas você encontrará**. Observe também que o limite acima em geral depende de muitos fatores internos, ele é mais aproximado do que um limite estrito - você provavelmente será capaz de executar mais/menos bots do que o especificado acima.

ASF team suggests **owning** up to **10 Steam accounts in total**, and therefore also running up to **10 bots in total**. Tudo o que foi dito não é apoiado e feito por sua conta e risco, contra a nossa sugestão aqui apresentada. Essa recomendação é baseada em diretrizes internas da Valve, bem como nossas próprias sugestões. Se você vai concordar com essa regra ou não, a escolha é sua, o ASF, como ferramenta, não vai contra sua própria vontade, mesmo se isso resultar em suas contas Steam serem suspensas por isso. Portanto, o ASF vai te mostrar um aviso se você ultrapassar o que recomendamos, mas ainda permite que você execute o que quiser por sua conta e risco e falta de nosso apoio.

---

### Então eu posso rodar mais instâncias do ASF?

Você pode executar quantas instâncias do ASF você quiser em um computador, assumindo que cada instância tenha sua própria pasta e suas próprias configurações, e conta usada em uma instância não é usada em outra. No entanto, pergunte-se por que você quer fazer isso. O ASF é otimizado para lidar com mais de uma centena de contas ao mesmo tempo, e lançar que centenas de bots em suas próprias instâncias do ASF diminui o desempenho, toma mais recursos do sistema operacional (como CPU e memória), e causa possíveis problemas de sincronização entre instâncias independentes do ASF, já que o ASF é forçado a compartilhar seus limitadores com outras instâncias.

Portanto, minha **forte sugestão** é sempre executar o máximo de uma instância do ASF por IP/interface. Se você tiver mais IPs/interfaces, você pode executar mais instâncias do ASF, com cada instância usando seu próprio IP/interface ou configuração `WebProxy` única. Se você não iniciar, abrir mais instâncias do ASF é totalmente inútil, já que você não ganhará nada ao executar mais de 1 instância por apenas IP/interface. O Steam não vai permitir magicamente permitir que você rode mais bots apenas porque você os iniciou em outra instância do ASF. e o ASF não te limita para começar.

Claro, ainda existem casos de uso válidos para várias instâncias do ASF na mesma interface de rede, tal como hospedar o serviço ASF para seus amigos quando cada amigo tiver sua própria instância exclusiva do ASF para garantir o isolamento entre bots e até mesmo os processos do ASF em si, no entanto, você não está contornando nenhuma limitação do Steam desta forma, esse é um propósito totalmente diferente.

---

### Qual é o significado do status ao resgatar uma chave?

O estado indica como determinada tentativa de resgate acabou. Há muitos estados possíveis, os mais comuns incluem:

| Estado                  | Descrição                                                                                                                                                                                                  |
| ----------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| NoDetail                | Estado "OK" que indica sucesso; a key foi resgatada com sucesso.                                                                                                                                           |
| Timeout                 | A rede Steam não respondeu no tempo determinado, não sabemos se a key foi resgatada ou não (provavelmente sim, mas você pode tentar de novo).                                                              |
| BadActivationCode       | A key fornecida é inválida (não reconhecida como uma key válida pela rede Steam).                                                                                                                          |
| DuplicateActivationCode | A key fornecida já foi resgatada por alguma outra conta, ou revogada pelo desenvolvedor/editor.                                                                                                            |
| AlreadyPurchased        | Sua conta já possui `pacote ID` que está conectado com essa chave. Tenha em mente que isso não indica se a chave é `DuplicateActivationCode` ou não - só que ela é válida e não foi usada nesta tentativa. |
| RestrictedCountry       | Esta key está bloqueada por região e sua conta não está na região válida que tem permissão para resgatá-la.                                                                                                |
| DoesNotOwnRequiredApp   | Você não pode resgatar essa key pois está faltando algum outro aplicativo - principalmente quando você está tentando resgatar uma DLC pacote.                                                              |
| RateLimited             | Você fez muitas tentativas de resgate e sua conta foi temporariamente bloqueada. Tente novamente em uma hora.                                                                                              |

---

### Você é afiliado a algum serviço de coleta de cartas?

**Não**. O ASF não é afiliado a nenhum serviço e todas essas reclamações são falsas. Sua conta Steam é propriedade sua e você pode usar sua conta da maneira que quiser, mas a Valve claramente declarada no Acordo de **[oficial](https://store.steampowered.com/subscriber_agreement)** que:

> Você é o responsável pela confidencialidade do seu login e senha e pela segurança do seu sistema de computador. A Valve não é responsável pelo uso da sua senha e Conta nem por toda a comunicação e atividade no Steam que resulte do uso de seu nome de usuário e senha por você, ou por qualquer pessoa a quem você tenha divulgado, de forma intencional ou por negligência, o seu login e/ou senha em violação desta disposição de confidencialidade.

O ASF é licenciado pela licença liberal Apache 2.0, que permite que outros desenvolvedores integrem legalmente o ASF em seus próprios projetos e serviços. No entanto, não é garantido que esses projetos de terceiros utilizando o ASF sejam seguros, revisados, apropriados ou legais de acordo com a **[Acordo de Assinatura do Steam](https://store.steampowered.com/subscriber_agreement)**. Se você quer saber a nossa opinião, **nós encorajamos fortemente você a NÃO compartilhar QUALQUER detalhes de conta com serviços de terceiros**. Se acontecer de tal serviço ser um **típico de fraude**, você será deixado sozinho com o problema, Provavelmente sem sua conta Steam e o ASF não assumirá nenhuma responsabilidade por serviços de terceiros que requeiram estar seguros e seguros, porque a equipe do ASF não autorizou nenhum desses. Em outras palavras, **você os usa por sua conta e risco, contra a sugestão feita acima de**.

Além disso, o **[Acordo de Assinatura do Steam](https://store.steampowered.com/subscriber_agreement)** afirma claramente que:

> Você não poderá revelar, compartilhar ou de outra forma permitir que outras pessoas usem sua senha ou Conta, exceto se for especificamente autorizado de outra forma pela Valve.

É seu cliente e sua escolha. Só não diga que ninguém te avisou. O ASF em si cumpre todas as regras mencionadas acima, já que você não está compartilhando os dados da sua conta com ninguém, e você está utilizando o programa para o seu próprio uso pessoal, mas qualquer outro "serviço de coleta de cartas" requer de você as credenciais da sua conta, então ele também viola a regra acima (na verdade várias delas). Como com a avaliação **[do Acordo de Assinatura](https://store.steampowered.com/subscriber_agreement)** , não estamos oferecendo nenhum aconselhamento legal e você deve decidir por sua conta se quer utilizar esses serviços ou não - de acordo com nós **viola diretamente o [Acordo de Assinatura do Steam](https://store.steampowered.com/subscriber_agreement)** e pode resultar em suspensão se a Valve descobrir. Como salientado acima, **recomendamos fortemente NÃO usar nenhum desses serviços**.

---

## Solicitações

---

### Um dos meus jogos está sendo coletado por mais de 10 horas agora, mas ainda não recebi nenhuma carta!

O motivo para isso poderia estar relacionado a um problema conhecido do Steam, o que acontece quando você tem duas licenças para o mesmo jogo, uma das quais tem carta limitada. Isso geralmente acontece quando você ativa o jogo gratuitamente durante um presente em massa no Steam, e depois ative uma chave para o mesmo jogo (mas sem limitações), e. . de um pacote pago. Se tal situação acontecer, a Steam reporta-se na página de insígnias que o jogo ainda tem cartas a receber, mas não importa o quanto você jogue o jogo - as cartas nunca aparecerão devido à licença gratuita na sua conta. Uma vez que não é um problema do ASF, mas sim do Steam, não podemos de alguma forma contorná-lo do lado do ASF, e você mesmo precisa resolvê-lo.

Há duas maneiras de resolver o problema. Primeiro você pode colocar este jogo na lista negra no ASF, ou com `fbadd` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** ou com `Blacklist` **[propriedade de configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Isso impedirá que o ASF tente coletar cartas deste jogo, mas não resolverá o problema subjacente que impede que você obtenha cartas do jogo afetado. Em segundo lugar, você pode usar a ferramenta de suporte Steam para remover a licença gratuita da sua conta, deixando apenas a licença completa que inclui os recebimentos de cartas. In order to do so, firstly visit your **[licenses and product key activations](https://store.steampowered.com/account/licenses)** page and locate both free and paid license for the affected game. Normalmente é bastante fácil - ambos têm nome semelhante, mas de graça tem "limitado pacote promocional" ou outro "promoção" no nome da licença, mais "cortesia" no campo "método de aquisição". Às vezes pode ser mais complicado, por exemplo, se o pacote livre estivesse em algum pacote e tivesse um nome diferente. Se você encontrou duas licenças como essa - então é de fato o problema descrito aqui, e você pode remover com segurança a licença gratuita sem perder o jogo.

Para remover a licença gratuita da sua conta, visite **[página de suporte Steam](https://help.steampowered.com/wizard/HelpWithGame)** e coloque o nome do jogo afetado no campo de busca, o jogo deve estar disponível na seção "produtos", clique nele. Como alternativa, você pode simplesmente usar `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` link e substituir `<appID>` por appID do jogo que causa problemas. Depois, clique em "Eu quero remover permanentemente este jogo da minha conta" e então selecione a licença gratuita que você encontrou acima, geralmente aquele com "pacote promocional gratuito limitado" no nome (ou semelhante). Após a remoção da licença gratuita, o ASF deverá conseguir coletar cartas do jogo afetado sem problemas, você deve reiniciar a operação de coleta após a remoção, apenas para ter certeza de que o Steam retira a licença certa desta vez.

---

### O ASF não detecta o jogo `X` como disponível para coleta, mas eu sei que ele inclui cartas colecionáveis Steam!

Há aqui duas razões principais. A primeira e mais óbvia razão é o fato de que você está se referindo a **loja Steam** onde determinado jogo é anunciado como um jogo habilitado para cartas. This is **wrong** assumption, as it simply states that the game **has** card drops included, but not necessarily this function for that game is **enabled** right away. Leia mais sobre isso em **[anúncio oficial](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**.

Em suma, o ícone coletar cartas na loja Steam não significa nada, verifique suas páginas **[insígnias](https://steamcommunity.com/my/badges)** para confirmar se um jogo tem cartas ou não; é isso também que o ASF faz. If your game doesn't appear on the list as a game with cards possible to drop, then this game is **not** possible to farm, regardless of reason.

A segunda questão é menos óbvia, e é a situação quando você pode ver que seu jogo de fato está disponível com cartas na sua página de insígnias, ainda assim ele não está sendo executado pelo ASF. A menos que você esteja enfrentando algum bug, tal como o ASF ser incapaz de verificar as páginas de insígnias (descritas abaixo), É simplesmente um efeito de cache e, do lado do ASF, Steam ainda está relatando a página de insígnias desatualizada. Esse problema deve resolver-se mais cedo ou mais tarde, quando o cache for invalidado. Também não há maneira de consertar isso do nosso lado.

Claro, tudo isso pressupõe que você está executando o ASF com as configurações padrão intocadas, já que você também pode adicionar este jogo à lista negra de coleta. usar `FarmingPreferences` selecionado como `FarmPriorityQueueOnly` ou `SkipRefundableGames`, e assim por diante.

---

### Por que o tempo de jogo dos jogos coletados através do ASF não aumenta?

Ele faz, mas **não em tempo real**. O Steam registra seu tempo de jogo em intervalos fixos e agenda a atualização para ele, mas não é garantido que você o atualize imediatamente no momento em que você sair da sessão, muito menos durante esse período. Só porque o tempo de jogo não é atualizado em tempo real não significa que não é gravado, é geralmente atualizado a cada 30 minutos ou assim.

---

### Qual é a diferença entre um aviso e um erro no log?

O ASF grava em seu registro um monte de informações de vários níveis. Nosso objetivo é explicar **precisamente** o que o ASF está fazendo. incluindo quais problemas com o Steam ele tem que resolver, ou outros problemas para superar. Na maioria das vezes, nem tudo é relevante, é por isso que temos dois níveis principais sendo usados no ASF em termos de problemas - um nível de aviso e um nível de erro.

A regra geral do ASF é que avisos não são erros **nem** , portanto eles devem ser reportados pelo **não deve ser**. Um aviso é um indicador de que algo potencialmente indesejado aconteceu. Se o Steam não estava reagindo, a API retornando erros ou a sua conexão de rede está desligada - é um aviso, e isso significa que esperávamos que isso acontecesse, então não se incomode o desenvolvimento do ASF com ele. É claro que você é livre para perguntar sobre eles ou obter ajuda usando o nosso apoio, mas você não deve assumir que esses erros do ASF merecem ser relatados (a menos que confirmemos o contrário).

Por outro lado, os erros indicam uma situação que não deveria acontecer, Portanto, vale a pena relatar desde que nos certifiquemos de que não é você quem os está causando. Se é uma situação comum que esperamos que aconteça, então ele será convertido em um aviso. Caso contrário, possivelmente é um erro que deve ser corrigido, e não ignorado em silêncio, supondo que não seja resultado de seu próprio problema técnico. Por exemplo, colocando conteúdo inválido no `ASF. o arquivo son` irá lançar um erro, já que o ASF não será capaz de analisá-lo, mas foi você quem o colocou lá, então você não deve nos relatar esse erro (a menos que você tenha confirmado se o ASF está errado e sua estrutura está absolutamente correta).

Em suma - reporte erros, não reporte avisos. Você ainda pode perguntar sobre os avisos e receber ajuda em nossas seções de suporte.

---

### O ASF não funciona, a janela do programa fecha imediatamente!

Em condições normais, qualquer falha ou fechamento do ASF gerará um log `. xt` no diretório do programa para você visualizar, que pode ser usado para encontrar a causa disso. Além disso, alguns dos últimos arquivos de log também são arquivados no diretório `logs` , desde o log principal `. O arquivo xt` é substituído toda vez que o ASF é executado.

No entanto, se nem mesmo o tempo de execução .NET não for capaz de ligar no seu computador, então o `log.txt` não será gerado. Se isso acontecer com você, provavelmente você esqueceu de instalar os pré-requisitos .NET, como consta no guia **[configurando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. Outros problemas comuns incluem tentar rodar a variante errada do ASF para seu SO, ou de outra forma a falta de dependências nativas do .NET em tempo de execução. Se a janela de console fechar cedo demais para você ler a mensagem, então abra um console independente e rode o executável do ASF por lá. Por exemplo, no Windows, abra a pasta ASF, segure `Shift`, clique com o botão direito dentro da pasta e escolha "*abra a janela de comando aqui*" (ou *powershell*), em seguida, digite o console `. ArchiSteamFarm.exe` e confirme com enter. Desta forma você obterá a mensagem precisa porque o ASF não está iniciando corretamente.

Se não houver saída, e você estiver no Windows, a razão habitual para isso é não ter todas as atualizações disponíveis do Windows instaladas - certifique-se de estar usando o sistema operacional atualizado, já que não suportamos rodar o ASF no Windows sem atender essa condição de qualquer maneira.

---

### O ASF está expulsando minha sessão no cliente Steam enquanto eu jogo! / *Esta conta está logada em outro PC*

Isto aparece como uma mensagem sobreposta no Steam que a conta está sendo usada em outro lugar enquanto você está jogando. Esse problema pode ter duas razões diferentes.

Um motivo é causado por pacotes quebrados (jogos) que especificamente não são controlados pelo bloqueio do jogo corretamente, no entanto espere que esse bloqueio seja prendido pelo cliente. Um exemplo de tal pacote seria o Skyrim SE. Seu cliente Steam inicia o jogo corretamente, mas esse jogo não se registra como sendo usado. Por esse motivo, o ASF assume que está livre para retomar o processo, o que ele faz. e isso te expulsa da rede Steam, pois o Steam de repente detecta que a conta está sendo usada em outro lugar.

Outro motivo pode ser causado se você estiver jogando em seu PC enquanto o ASF espera (especialmente em outro computador) e você perde sua conexão com a internet. Neste caso, a rede Steam te marca como offline e libera o bloqueio de jogo (como no caso acima), o que faz com que o ASF (por exemplo, em outro computador) retome a coleta. Quando seu PC se reconecta, o Steam não pode mais ativar o bloqueio de jogo (que agora está bloqueado pelo ASF, também similar a acima) e mostra a mesma mensagem.

Ambas as causas do lado do ASF são muito difíceis de se evitar, já que o ASF simplesmente retoma a coleta uma vez que a rede Steam informe que a conta está livre para ser usada novamente. Isto é o que acontece normalmente quando você fecha o jogo, mas com pacotes quebrados isso pode acontecer imediatamente, mesmo se seu jogo ainda estiver em execução. O ASF não tem como saber se você foi desconectado, parou de jogar uma partida ou você ainda está jogando um jogo que não segura o bloqueio apropriadamente.

A única solução adequada para este problema é pausar manualmente o seu bot com `pausar` antes de começar a jogar, e retomá-lo com `resumir` quando estiver pronto. Como alternativa, você pode simplesmente ignorar o problema e agir como se tivesse jogado com o cliente Steam off-line.

---

### `Desconectado do Steam!` - Não consigo estabelecer conexão com servidores Steam.

ASF can only **try** to establish connection with Steam servers, and it can fail due to many reasons, including lack of internet connection, Steam being down, your firewall blocking connection, third-party tools, incorrectly configured routes or temporary failures. Você pode habilitar `Debug` modo para verificar mais informações detalhadas de log informando as razões exatas da falha. embora geralmente seja simplesmente causado por suas próprias ações, tal como usar "CS:GO MM Server Picker" que bloqueia muitos IPs Steam, tornando muito difícil para você realmente alcançar a rede Steam.

O ASF fará o seu melhor para se conectar. que inclui não só perguntar sobre a lista atualizada de servidores, mas também tentar outro IP quando o último falhar, então se for realmente um problema temporário com algum servidor ou rota específica, o ASF se conectará mais cedo ou mais tarde. Entretanto, se você está atrás do firewall ou de alguma outra forma incapaz de alcançar os servidores Steam, então obviamente você precisa consertar isso você mesmo, com a potencial ajuda do modo `Debug`.

Também é possível que seu computador não seja capaz de estabelecer conexão com os servidores Steam usando o protocolo padrão do ASF. Você pode alterar protocolos que o ASF tem permissão de usar modificando o parâmetro de configuração global `SteamProtocols`. Por exemplo, se você tiver problemas em alcançar o protocolo `UDP` do Steam (por exemplo, devido a firewalls), talvez você tenha mais sorte com `TCP` ou `WebSocket`.

Na situação muito improvável de ter servidores incorretos sendo armazenados em cache, por exemplo, devido a mover a pasta `config` do ASF de um computador para outro computador localizado em outro país, excluindo `ASF. b` para atualizar os servidores Steam na próxima execução pode ajudar. Na maioria das vezes não é necessário e não precisa ser feito, já que essa lista é atualizada automaticamente na primeira inicialização, assim como quando a conexão é estabelecida - só estamos mencionando-a como uma maneira de remover qualquer coisa relacionada a lista de servidores Steam armazenada em cache pelo ASF.

---

### `Não foi possível fazer login no Steam: TryAnotherCM/Invalid`, `ServiceUnavailable/Invalid`

Como acima, mas desta vez o servidor com que você se conectou está explicitamente indisponível. Normalmente acontece durante a janela de manutenção do Steam, não há nada que você possa fazer sobre isso, O ASF tentará automaticamente com um servidor diferente até que ocorra para aceitar o pedido. Não deve durar mais do que uma hora máxima.

---

### `Não foi possível obter informações das insígnias, tentaremos novamente mais tarde!`

Normalmente isso significa que você está usando o PIN do modo família para acessar sua conta e esqueceu de colocá-lo na configuração do ASF. Você deve colocar um PIN válido no parâmetro de configuração do bot `SteamParentalCode` , caso contrário o ASF não será capaz de acessar a maioria do conteúdo web, portanto não será capaz de funcionar corretamente. Vá para **[configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** para saber mais sobre `SteamParentalCode`.

Outras razões incluem um problema temporário do Steam, um problema de rede ou coisas assim. Se o problema não se resolver após várias horas e você tem certeza de que configurou o ASF corretamente, sinta-se livre para nos informar sobre isso.

---

### ASF is failing with `Request failed after 5 tries` errors!

Normalmente isso significa que você está usando o PIN do modo família para acessar sua conta e esqueceu de colocá-lo na configuração do ASF. Você deve colocar um PIN válido no parâmetro de configuração do bot `SteamParentalCode` , caso contrário o ASF não será capaz de acessar a maioria do conteúdo web, portanto não será capaz de funcionar corretamente. Vá para **[configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** para saber mais sobre `SteamParentalCode`.

Se o PIN do pai não é a razão, então este é um erro mais comum e você deve se acostumar a isso, significa simplesmente que o ASF enviou um pedido para a rede Steam e não recebeu uma resposta válida cinco vezes seguidas. Normalmente isso significa que a Steam caiu ou está tendo algumas dificuldades ou está em manutenção - o ASF está ciente de tais problemas e você não deve se preocupar com eles, a não ser que estejam acontecendo constantemente por mais do que várias horas, e outros usuários não têm esses problemas.

Como verificar se o Steam caiu? **[Steam Status](https://steamstat.us)** é uma excelente fonte de verificação se o Steam **deve estar** pronto, se você notar erros, especialmente relacionados à API Web ou comunitária, então a Steam está tendo dificuldades. Você pode querer deixar o ASF sozinho e deixá-lo fazer seu trabalho depois de um curto período de tempo de inatividade, ou sair e esperar.

No entanto esse nem sempre é o caso, pois em algumas situações os problemas com o Steam podem não ser detectados pelo Status do Steam, por exemplo, esse caso aconteceu quando a Valve quebrou o suporte HTTPS da Comunidade Steam em 7 de junho de 2016 - acessar **[SteamCommunity](https://steamcommunity.com)** através de HTTPS estava dando um erro. Portanto, não confie cegamente no Steam Status também, é melhor você mesmo verificar se tudo funciona como deveria.

Além disso, o Steam inclui várias medidas para limitar a taxa que vão banir temporariamente seu IP se você fizer um número excessivo de solicitações de uma vez. O ASF está ciente disso e oferece vários limitadores diferentes nas configurações, os quais você deve usar. As configurações padrão foram ajustadas com base na quantidade de bots **sane** , aformat@@0 sane, se você estiver usando tanto dinheiro que até o Steam está te dizendo para sair, então você os ajusta até que não lhe diga mais, ou faz como te mandam. Presumo que a segunda via não é uma opção para você. então vá ler sobre esse tópico e preste especial atenção à `WebLimiterDelay` que é um limitador geral que se aplica a todas as solicitações da web.

Não há nenhuma "regra de ouro" que funcione para todos, porque os blocos são fortemente influenciados por fatores de terceiros, É por isso que você tem que experimentar você mesmo e encontrar um valor que funcione para você. Você também pode ignorar o que eu digo e usar algo como `10000` que é garantido que funciona corretamente, mas então não reclame como seu ASF reage a tudo em 10 segundos e como a análise de insígnias leva 5 minutos. Além disso, é inteiramente possível que nenhum limitador faça qualquer coisa, porque você tem uma quantidade tão grande de bots que você está atingindo **[limite rígido](#how-many-bots-can-i-run-with-asf)** que foi mencionado acima. Sim, é inteiramente possível que você consiga se conectar sem problemas com a rede Steam (cliente), mas a web Steam (website) se recusará a ouvi-lo se você tiver 100 sessões estabelecidas de uma vez. O ASF requer que a rede Steam e o Steam web sejam cooperativos, basta que um caia para que você não recupere nenhum problema.

Se nada for útil e não se fizer ideia do que está quebrado, você sempre pode ativar o modo `Debug` e ver no registro do ASF porque exatamente as solicitações estão falhando. Por exemplo:

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Forbidden <- HEAD https://steamcommunity.com/my/edit/settings
```

Que código `Proibido`? Isso significa que você foi banido temporariamente por excesso de pedidos, porque você ainda não configurou `WebLimiterDelay` corretamente (assumindo que você também obtenha o mesmo código de erro para todas as outras solicitações). Pode haver outros motivos listados aqui, como o `InternalServerError`, `ServiceUnavailable` e tempos limite que indicam manutenção/problemas no Steam. Você sempre pode tentar visitar o link mencionado pelo ASF e verificar se ele funciona, se não funcionar, então você sabe por que o ASF também não pode acessar isso. Se funcionar e o mesmo erro não desaparecer depois de um dia ou dois, pode valer a pena investigar e reportar.

Before doing that you should **make sure that the error is worth reporting in the first place**. Se ele estiver mencionado nesse FAQ, como um problema relacionado a troca, então não. Se for um problema temporário que aconteceu uma ou duas vezes, especialmente quando sua rede estava instável ou o Steam desapareceu - não. No entanto, se você foi capaz de reproduzir seu problema várias vezes seguidas, nos próximos 2 dias. reiniciou o ASF e seu computador no processo e certifique-se de que não há nenhuma resposta para o FAQ aqui para ajudar a resolvê-lo, Nesse caso, talvez valha a pena interrogar-nos.

---

### O ASF parece travar e não imprime nada no console até que eu pressione uma tecla!

Você provavelmente está usando o Windows e seu console está com o modo de edição rápida ativado. Consulte **[esta pergunta](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** no StackOverflow para obter uma explicação técnica. Você deve desativar o modo QuickEdit clicando com o botão direito do mouse na janela do console do ASF, abrindo as propriedades e desmarcando a caixa de seleção apropriada.

---

### O ASF não pode aceitar ou enviar trocas!

O óbvio primeiro: novas contas começam como limitadas. Até que você desbloqueie a conta colocando pelo menos $5 na sua carteira ou gastando esse valor na loja, o ASF não pode aceitar nem enviar trocas usando essa conta. Nesse caso, o ASF indicará que esse inventário parece vazio, porque todas as cartas nele não são trocáveis.

Em seguida, se você não usar **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, é possível que o ASF tenha aceitado/enviado a troca, mas você precisa confirmá-la por meio do seu e-mail. Da mesma forma, se você usa o 2FA padrão, você precisa confirmar a troca através do seu autenticador. As confirmações são **obrigatórias** agora, então se você não quer aceitá-las manualmente, considere importar seu autenticador para o ASF 2FA.

Observe também que você só pode trocar com seus amigos e pessoas com o link de troca. If you're trying to initiate *Bot -> Master* trade, such as `loot`, then you need to either have your bot on your friendlist, or your `SteamTradeToken` declared in Bot's config. Certifique-se de que o token seja válido - caso contrário, você não será capaz de enviar uma troca.

Por último, lembre-se que novos dispositivos tem um bloqueio de trocas de 7 dias, então se você acabou de adicionar sua conta ao ASF, espere pelo menos 7 dias - tudo deve funcionar após esse período. Essa limitação inclui **ambos** aceitar **e** enviar trocas. Nem sempre ele funciona e há pessoas que podem enviar e aceitar trocas instantaneamente. Majority of the people are affected though, and the lock **will** happen, even if you can send and accept trades through your steam client on the same machine. Espere pacientemente, não há nada que você possa fazer para acelerar isso. Da mesma forma, você pode ser bloqueado por remover/mudar várias configurações do Steam relacionadas à segurança, tal como o 2FA, senha, e-mail e afins. Em geral, verifique se você pode enviar uma troca dessa conta por conta própria, caso positivo, é provavelmente o bloqueio clássico de 7 dias de um novo dispositivo.

E finalmente, tenha em mente que uma conta pode ter apenas 5 operações pendentes para outra, Portanto, o ASF falhará em enviar trocas se você tiver 5 (ou mais) pendentes daquele bot para aceitar. Raramente isso é um problema, mas vale a pena mencionar especialmente se você definir o ASF para enviar trocas automaticamente, ainda não está usando o ASF 2FA e esqueceu de confirmar.

Se nada ajudar, você sempre pode habilitar o modo `Depurar` e verificar porque as solicitações estão falhando. Note que o Steam fala bobagens na maioria das vezes e o motivo pode não fazer nenhum sentido lógico. ou pode estar completamente incorreto - se você decidir interpretar esse motivo, certifique-se de ter um conhecimento razoável sobre o Steam e suas peculiaridades. Também é bem comum ver esse problema sem razão lógica. e a única solução sugerida neste caso é readicionar a conta ao ASF (e esperar 7 dias novamente). Às vezes, esse problema também se corrige *magicamente*, da mesma forma que ele quebra. No entanto, geralmente é apenas um bloqueio de 7 dias, um problema temporário do Steam ou ambos. É melhor dar alguns dias antes de verificar manualmente o que está errado, a não ser que você tenha algum desejo de depurar a verdadeira causa (e geralmente você será forçado a esperar mesmo assim, porque a mensagem de erro não fará nenhum sentido, nem te ajuda em parte alguma).

In any case, ASF can only **try** to send a proper request to Steam in order to accept/send trade. Se o Steam aceita esse pedido ou não, está fora do escopo do ASF, e o ASF não vai fazê-lo funcionar magicamente. Não há nenhum bug relacionado a esse recurso, e também não há nada para melhorar, porque a lógica acontece fora do ASF. Por conseguinte, não peçam que se corrija algo que não seja quebrado, e também não se pergunta por que o ASF não pode aceitar ou enviar trocas - **eu não sei e o ASF não sabe nada**. Lide com isso ou conserte você mesmo, se você souber melhor.

---

### Por que tenho que colocar o código 2FA/SteamGuard em cada login? / *Chave de sessão expirada*

O ASF usa chaves de sessão (se você manteve a `UseLoginKeys` habilitada) para manter as credenciais válidas, o mesmo mecanismo que a Steam usa - token 2FA/SteamGuard é necessário apenas uma vez. No entanto, devido a problemas e peculiaridades da rede Steam, é inteiramente possível que a chave de login não seja salva na rede, Já vimos problemas desse tipo não só no ASF, mas com o cliente normal do Steam também (uma necessidade de entrada de login + senha em cada execução, independentemente da opção "lembre-me de mim").

Você pode remover `NomeDoBot.db` e `BotName. em` (se disponível) da conta afetada e tente vincular o ASF a sua conta novamente, mas isso provavelmente não fará nada. Alguns usuários relataram que **[desautorizar todos os dispositivos](https://store.steampowered.com/twofactor/manage)** do lado do Steam deve ajudar, alterar a senha fará o mesmo. No entanto, estas são apenas soluções que nem sequer têm a garantia de funcionar. a solução real baseada no ASF é importar seu autenticador como **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** - dessa forma o ASF pode gerar tokens automaticamente quando necessário. e você não precisa colocá-los manualmente. Geralmente, o problema se resolve magicamente a si mesmo depois de algum tempo, então você pode simplesmente esperar que isso aconteça. Claro que você também pode pedir solução à Valve, porque eu não posso forçar a rede Steam a aceitar nossas chaves de login.

Como nota lateral, Você também pode desativar as chaves de login com `UseLoginKeys` propriedade de configuração definida como `false`, mas isso não vai resolver o problema, apenas pule a chave de login inicial. O ASF já está ciente do problema explicado aqui e vai tentar o melhor possível para não usar as chaves de sessão se ele puder garantir se todas as credenciais de login, então não há necessidade de ajustar `UseLoginKeys` manualmente se você puder fornecer todos os detalhes do login, juntamente com o ASF 2FA.

---

### Estou recebendo o erro: *Não foi possível fazer login no Steam: `InvalidPassword` ou `RateLimitExcedido`*

Este erro pode significar muitas coisas, algumas delas incluem:

- Combinação de login/senha inválida (obviamente)
- A chave de sessão usada pelo ASF expirou
- Muitas tentativas de conexão em um curto período de tempo (anti-bruteforce)
- Muitas tentativas de conexão em um curto período de tempo (limite de tentativas)
- Requisito de captcha para se conectar (muito provavelmente causado por dois motivos acima)
- Qualquer outro motivo pelo qual a rede Steam pode estar te impedindo de se conectar

No caso da força bruta e do limitador de taxas, o problema desaparecerá depois de algum tempo, então espere e não tente logar enquanto isso. Se você tiver esse problema com frequência, talvez seja aconselhável aumentar o parâmetro `LoginLimiterDelay` na configuração do ASF. Reiniciar excessivamente o programa e outras solicitações de login intencionais/não-intencionais definitivamente não ajudarão com isso, então tente evitá-lo, se possível.

No caso de a chave de sessão ter expirado o ASF vai remover a antiga e pedir nova na próxima sessão (o que vai exigir seu token 2FA se sua conta estiver protegida por 2FA. Se sua conta estiver usando o ASF 2FA, o token será gerado e usado automaticamente). Isso pode naturalmente acontecer ao longo do tempo, mas se você resolver esse problema em cada login, é possível que a Steam por algum motivo decida ignorar nossas tentativas de salvar a chave de login, como mencionado na issue **[acima](#why-do-i-have-to-put-2fasteamguard-code-on-each-login--removed-expired-login-key)**. Você pode naturalmente desativar `UseLoginKeys` inteiramente, mas isso não resolverá o problema, apenas evitará a necessidade de remover as chaves de login expiradas a cada vez. A solução real, conforme o problema acima, é usar o ASF 2FA.

E por último, se você usou o usuário + combinação de senha errada, obviamente você precisa corrigir isso, ou desabilite o bot que está tentando se conectar usando essas credenciais. O ASF não consegue adivinhar se `InvalidPassword` significa credenciais inválidas, ou qualquer uma das razões listadas acima, portanto ele continuará tentando até que tenha sucesso.

Tenha em mente que o ASF tem seu próprio sistema interno para reagir de acordo com os erros do Steam, eventualmente ele irá se conectar e retomar o trabalho, portanto não é necessário fazer nada se o problema for temporário. Reiniciar o ASF para corrigir problemas magicamente só vai piorar as coisas (já que o novo ASF não sabe que o estado anterior do ASF não é capaz de se conectar, e tente conectar ao invés de esperar), então evite fazer isso a menos que você saiba o que está fazendo.

Finally, as with every Steam request - ASF can only **try** to log in, using your provided credentials. Se essa solicitação será bem-sucedida ou não está fora do escopo e da lógica do ASF: não há nenhum bug, e nada pode ser corrigido neste tocante.

---

### Não posso inserir detalhes de login que o ASF está pedindo
### `System.InvalidOperationException: Não é possível ler as chaves quando o aplicativo não tem um console ou quando a entrada do console foi redirecionada`
### `System.IO.IOException: Erro de entrada/saída`
### `Entrada RequestInput() é inválida!`

Se esse erro ocorreu durante a entrada do ASF (por exemplo, você pode ver `GetUserInput()` na stacktrace) então ela é causada pelo seu ambiente que proíbe o ASF de ler a entrada padrão do seu console. Isso pode ocorrer por muitos motivos, mas o mais comum é você rodar o ASF no ambiente errado (por exemplo, em `systemd`, `nohup` ou `&` segundo plano ao invés de e. . `tela` no Linux). Se o ASF não conseguir acessar sua entrada padrão, então você verá este erro no registro e a incapacidade do ASF de usar seus dados durante o tempo de execução.

Normalmente você deve corrigir o problema acima, ou seja, permitir que o ASF acesse a entrada padrão para que você possa fornecer os detalhes. However, if you **expect** this to happen, so you **intend** to run ASF in input-less environment, then you should explicitly tell ASF that it's the case, by setting **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** mode appropriately. Isso dirá ao ASF que nunca peça por entradas do usuário sob nenhuma circunstância, permitindo que você execute o ASF em ambientes sem entradas com segurança. Você pode responder às solicitações de entrada selecionadas por outros meios neste modo, por exemplo, na ASF-ui.

---

### `System.Net.Http.WinHttpException: Ocorreu um erro de segurança`

Esse erro acontece quando o ASF não consegue estabelecer uma conexão segura com determinado servidor, quase sempre por causa da desconfiança dos certificados SSL.

Em quase todos os casos, este erro é causado por **data/hora errada no seu computador**. Todo certificado SSL tem uma data de emissão e uma de validade. Se a sua data for inválida e estiver fora desses dois limites, o certificado não poderá ser confiável devido a um potencial ataque **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)** e o ASF se recusa a estabelecer uma conexão.

A solução evidente é marcar a data no seu computador adequadamente. É altamente recomendado usar a sincronização automática de data, como a sincronização nativa disponível no Windows, ou `ntpd` no Linux.

Se você se certificou de que a data no seu computador está correta e o erro não quer sair, Certificados SSL em que seu sistema confia podem estar desatualizados ou inválidos. Neste caso você deve garantir que sua máquina pode estabelecer conexões seguras, por exemplo, verificando se você pode acessar `https://github. encaixe` com qualquer navegador de sua escolha, ou ferramenta CLI como `curl`. Se V. Exa. confirmou que isto funciona correctamente, sinta-se livre de nos pedir apoio.

---

### `System.Threading.Tasks.TaskCanceledException: Uma tarefa foi cancelada`

Este aviso significa que o Steam não respondeu à solicitação do ASF no tempo determinado. Isso normalmente é causado por falhas na rede Steam e não afeta de forma alguma o ASF. Em outros casos é o mesmo que pedidos falhando após 5 tentativas. Reportar esses problemas não faz sentido na maioria das vezes, já que não podemos forçar o Steam a responder nossas solicitações.

---

### `O inicializador tipo para 'System.Security.Cryptography.CngKeyLite' lançou uma exceção`

Este problema é quase exclusivamente causado por este serviço desabilitado/parado `Serviço de Isolamento de Chave CNG` que fornece a funcionalidade de criptografia básica para o ASF, sem a qual o programa não é capaz de executar. Você pode resolver este problema lançando `serviços. sc` e a garantia de que o serviço do Windows `Chave CNG Isolação` não desativou a inicialização e está em execução.

---

### O ASF está sendo detectado como um malware pelo meu antivírus! O que está acontecendo?

**Ensure that you downloaded ASF from trusted source**. A única fonte oficial e confiável é que **[o ASF lança](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** página no GitHub (e essa também é a fonte para atualizações automáticas do ASF) - **qualquer outra fonte não é confiável e pode conter malware adicionado por outras pessoas** - você não deve confiar em nenhum outro local de download, certifique-se de que seu ASF sempre vem de nós.

Se você confirmou que o ASF foi baixado de fonte confiável, então muito provavelmente é simplesmente um falso positivo. Este **aconteceu no passado**, **está acontecendo agora mesmo**e **vai acontecer no futuro**. Se você está preocupado com a segurança ao usar o ASF, então eu sugiro escanear o ASF com vários antivírus diferentes para ver a taxa de detecção real, por exemplo, através **[VirusTotal](https://www.virustotal.com)** (ou qualquer outro serviço da web de sua escolha como este).

Se o antivírus que você está usando detectar falsamente o ASF como um malware, então **é uma boa ideia enviar esta amostra de arquivo para os desenvolvedores do seu AV, para que eles possam analisá-lo e melhorar o seu mecanismo de detecção**, tão claramente ele não está funcionando tão bem quanto você acha que funciona. Não há nenhum problema no código do ASF e também não há nada para nos corrigir, já que não estamos distribuindo malware em primeiro lugar, Portanto, não faz qualquer sentido nos denunciar esses falsos positivos. Nós recomendamos fortemente enviar uma amostra do ASF para futuras análises como descrito acima, mas se você não quiser se preocupar com ela, então você sempre pode adicionar o ASF a algum tipo de exceções de antivírus, desativar seu antivírus ou simplesmente usar outro. Infelizmente, estamos acostumados a antivírus sendo estúpidos, já que de vez em quando alguns antivírus detectam o ASF como vírus, que normalmente dura muito curto e está sendo corrigido rapidamente pelos desenvolvedores, mas como nós apontamos acima - **aconteceu**, **acontece** e **vai acontecer** o tempo todo. O ASF não inclui qualquer código malicioso, você pode revisar o código do ASF e mesmo compilar da fonte você mesmo. Não somos hackers para ofuscar o código do ASF para esconder da heurística do AV e dos falsos positivos, portanto, não esperem que consertemos o que não está quebrado - não há vírus para repararmos.