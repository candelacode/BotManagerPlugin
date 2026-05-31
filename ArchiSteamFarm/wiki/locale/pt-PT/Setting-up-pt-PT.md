# Configurando acima

Se você chegou aqui pela primeira vez, bem-vindo! We're very happy to see yet another traveler that is interested in our project, although bear in mind that with great power comes great responsibility - ASF is capable of doing a lot of different Steam-related tasks, but only as long as you **care enough to learn how to use it**. Na verdade, ler wiki, Seguir nossas diretrizes e aprender mais sobre vários conceitos do ASF acabará te recompensando com uma habilidade única de usar uma das mais poderosas ferramentas Steam disponíveis a partir de hoje.

Recomendamos que você faça **uma coisa por vez**. O ASF toca muitos aspectos diferentes, alguns dos quais são bastante triviais, outros podem ser excessivamente complexos. Você não precisa entender ou ler sobre tudo de uma só vez, e na verdade recomendamos que você tenha calma. Relaxe, escolhe para si mesmo uma bebida de escolha, Dedique uma hora do seu tempo e mergulhe em nossa aula - podemos prometer que valerá bem o seu tempo.

Vamos começar com o básico - o ASF é um aplicativo de console de acordo com o princípio, o que significa que não criará automaticamente uma interface gráfica com a qual você em geral está acostumado. O ASF é um aplicativo universal que funciona principalmente como um serviço (daemon) e não como um aplicativo da área de trabalho. Um dos seus principais casos de uso considera a execução em máquinas de servidor, para as quais os aplicativos de área de trabalho são totalmente inapropriados. That considers only the absolute core of the program though, because ASF actually **does** include its own graphical interface - in form of its built-in ASF-ui frontend, but we'll get down to that part in due time - we're just mentioning this right away so you won't panic when seeing black console screen or something.

Depois de obter os arquivos binários do ASF, o programa exigirá sua configuração, que especifica o que exatamente você espera que o ASF alcance. Você pode iniciar o programa sem a configuração, neste caso o ASF será executado nas configurações padrão, permitindo que você use o programa. . ASF-ui para a configuração inicial, mas além disso, ela não vai fazer muito sem sua ação prévia.

Isso vai fazer por agora, vamos começar!

---

## Configuração específica do sistema

Em geral, é isso que faremos nos próximos minutos:
- Vamos instalar os pré-requisitos **[.NET](#net-prerequisites)**.
- Então vamos baixar **[a versão mais recente do ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** na variante apropriada para Sistema Operacional.
- Em seguida, extrairemos o arquivo em um novo local.
- Then we'll **[configure ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- E finalmente, vamos executar o ASF e ver sua mágica.

Alguns dos passos são auto-explicativos, outros exigirão mais atenção da sua parte. Não se preocupe, nós te damos conta.

---

### Pré-requisitos .NET

O primeiro passo é garantir que seu sistema operacional pode mesmo executar o ASF corretamente. Você não precisa saber disso, mas o ASF é escrito em C#, com base em . Plataforma ET e pode exigir bibliotecas nativas que ainda não estão disponíveis na sua plataforma. Pense nisso como o DirectX para os jogos 3D, ou como um motor para iniciar o seu carro.

Dependendo do uso de Windows, Linux ou macOS, você terá requisitos diferentes. O documento de referência é **[. Especifica os pré-requisitos](https://docs.microsoft.com/dotnet/core/install)**, mas por uma questão de simplicidade nós detalhamos todos os pacotes necessários abaixo, então você não precisa ler nada, a menos que tenha problemas ou tenha outras perguntas.

É perfeitamente normal que algumas dependências (ou mesmo todas) já existam no seu sistema devido à instalação de um software de terceiros que você está usando. Ainda assim, isso não precisa ser o caso, então você deve executar o instalador apropriado para o seu sistema operacional - sem essas dependências o ASF não vai abrir de todo, e você mal obterá nenhuma informação útil por dizer a você o que está errado.

Tenha em mente que você não precisa fazer mais nada para as compilações específicas de SO, especialmente instalar. ET SDK ou mesmo tempo de execução, já que pacote específico para SO já inclui tudo isso. Você precisa apenas de pré-requisitos .NET (dependências) para rodar . ET o tempo de execução incluído no ASF - então apenas as coisas que especificamos abaixo, sem quaisquer outras adições.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Atualização Redistributável do Microsoft Visual C ++](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** para 64-bit, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** para 32-bit ou **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** para 64 bits de ARM)
- É altamente recomendável garantir que todas as atualizações do Windows já estejam instaladas. Se você não os tiver habilitados, então ao menos você precisa de **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** e **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**mas mais atualizações podem ser necessárias. Você não precisa se preocupar com isso se o seu Windows está atualizado ou pelo menos recente o suficiente.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Os nomes dos pacotes dependem da distribuição do Linux que você está usando, nós listamos as mais comuns. Você pode obter todas elas com o gerenciador de pacotes nativo do seu sistema operacional (como `apt` para Debian ou `yum` para o CentOS). Essas são bibliotecas bastante padrão que devem estar disponíveis, independentemente da distribuição que você estiver usando, É só uma questão de descobrir como eles são chamados em seu ambiente de escolha.

- `ca-certificates` (certificados SSL padrão confiáveis para fazer conexões HTTPS)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, versão mais recente para a sua distribuição, por exemplo, `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-libs`, versão mais recente para a sua distribuição, pelo menos `1.1.X`)
- `libstdc++6` (`libstdc++`, na versão `5.0` ou superior)
- `zlib1g` (`zlib`)

Pelo menos a maioria deles já deve estar disponível nativamente no seu sistema. Por exemplo, a instalação mínima do Debian estável geralmente requer apenas `libicu76`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- Você não precisa de nada especificamente, mas você deve ter a versão mais recente do macOS instalada, pelo menos 12.0 +

---

### Baixando

Uma vez que já temos todas as dependências, o próximo passo é o download da versão **[mais recente do ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. O ASF está disponível em muitas variantes, mas você está interessado em um pacote que corresponde ao seu sistema operacional e arquitetura. Por exemplo, se você estiver usando `64`-bit `Win`dows, então você quer um pacote `ASF-win-x64`. Para obter mais informações sobre as variantes disponíveis, visite **[compatibilidade](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**. ASF is also able to run in the environments that we're not building OS-specific package for, such as **32-bit Windows**, but you'll need **[generic setup](#generic-setup)** for that.

![Mídias](https://i.imgur.com/Ym2xPE5.png)

Após o download, comece extraindo o arquivo zip para sua própria pasta. Se você precisar de uma ferramenta específica para isso, **[7 zip](https://www.7-zip.org)** vai fazer, mas todos os utilitários padrão como a extração do Windows ou `unzip` do Linux/macOS também devem funcionar sem problemas.

Be advised to unpack ASF to **its own directory** and not to any existing directory you're already using for something else - that's important. O ASF inclui o recurso de atualização automática, que substitui seus próprios arquivos, e que geralmente vai apagar todos os arquivos antigos e não relacionados quando atualizados, o que, por sua vez, pode fazer com que você perca qualquer coisa não relacionada que você tenha colocado na pasta do ASF. Se você tiver quaisquer scripts ou arquivos extras que você deseja usar com o ASF, isso não é um problema. crie uma pasta dedicada a esses, você sempre pode colocar o ASF em uma pasta mais profunda.

Uma exemplo de estrutura pode parecer assim:

```text
C:\ASF (onde você coloca suas próprias coisas)
    ── MyNotes. xt (opcional)
    ── AsfMakeMeCoffeeScript.bat (opcional)
    ── (... (todos os outros arquivos que você escolher, opcionais)
    ─ Core (dedicado apenas ao ASF, onde você extraiu o arquivo)
         ─ ArchiSteamFarm(. xe)
         ── config
         ── logs
         ── plugins
         ── www
         ─── www 
 ─ (...)
```

---

### Configuração

Agora estamos prontos para a última etapa, a configuração. O ASF funciona com o conceito de "bots", cada bot geralmente é uma única conta Steam que você gostaria de usar dentro do ASF. Você pode declarar quantos bots quiser, mas para começar, vamos focar em apenas um deles - geralmente sua conta principal. O ASF também tem arquivos de configuração não-bot, o mais importante é o arquivo de configuração global, que afeta todos os bots na instância.

A regra geral do polegar é que **se você não sabe, ou não entender alguma configuração, você deve deixá-lo com seu valor padrão, sem alterar nada**. O ASF oferece inúmeras formas de configurar, personalizar e ajustar quase todos os seus recursos, mas como mencionado acima, tentar entendê-lo direto do morcego é um buraco de coelho que pode rapidamente arrastá-lo para uma confusão severa if not **[straight to the abismo](https://www.youtube.com/watch?v=KK3KXAECte4)**. Em vez disso, recomendamos ter um exemplo de trabalho primeiro, e somente depois começar a cavar opções adicionais, com a ajuda de uma página **[de configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** na wiki, enquanto muda **uma coisa por vez**.

A configuração do ASF pode ser feita de várias maneiras - através de nosso gerador de configuração web autônomo do ASF-ui, ou manualmente. Isto é explicado detalhadamente na seção **[configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** , então consulte isso se você quer informações mais detalhadas. Vamos usar o gerador de configuração web autônomo como ponto de partida, porque ele funciona mesmo se por algum motivo o ASF-ui falhar em iniciar ou funcionar corretamente.

Navegue para a página **[gerador de configuração web](https://justarchinet.github.io/ASF-WebConfigGenerator)** com o seu navegador favorito. Recomendamos o Chrome ou o Firefox, mas não deve importar, enquanto seu navegador funcionar para todo o resto.

Depois de abrir a página, vá para a aba "Bot". Agora você verá uma página semelhante à abaixo:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Se por acaso a versão do ASF que você acabou de baixar é mais antiga que a versão que o gerador de configuração está definida para ser usada por padrão escolha a versão do ASF no menu suspenso. Isso pode (raramente) acontecer, já que o gerador de configuração pode ser usado para gerar configurações para as versões mais recentes (pré-lançamento) do ASF que ainda não foram marcadas como estáveis. Você baixou a última versão estável do ASF que é verificada para funcionar de forma confiável, por isso poderá ser um pouco mais antigo do que a versão de vanguarda absoluta, que não é totalmente adequada para a primeira utilização.

Start from **putting name for your bot** into the field highlighted as red, called `Name`. Pode ser qualquer nome que você queira usar, como seu apelido, nome da conta, um número ou qualquer outra coisa. Há apenas uma palavra que você não pode usar, `ASF`, já que essa palavra-chave é reservada para o arquivo de configuração global. Além disso, o nome do bot não pode começar com um ponto (o ASF ignora esses arquivos). Também recomendamos que você evite usar espaços, você pode usar `_` como um separador de palavra se necessário - não um requisito estrito, mas você terá dificuldade em usar comandos do ASF.

Nome do bot decidido? Ótimo, na próxima etapa, **mudar `Habilitado` switch para estar em**, que define se seu bot deve ser iniciado automaticamente após ser executado (do programa). Não fazer isso fará com que o ASF indique que seu bot está desativado no arquivo de configuração. e esperará que o seu contributo o inicie, o que não é o que queremos fazer neste exemplo.

Agora, há duas propriedades sensíveis vindo a seguir: `SteamLogin` e `SteamPassword`. Você pode tomar outra decisão aqui - ou você pode colocar seus detalhes de login Steam nessas duas propriedades, ou você pode decidir não fazer isso, deixando-os vazios.

O ASF precisa de suas credenciais porque inclui a sua própria implementação do cliente Steam e precisa dos mesmos dados que você usa para se conectar. Suas credenciais de login não são salvas em nenhum lugar além do seu PC na pasta `config` do ASF (depois de baixar a configuração gerada). Nosso gerador de configuração web é baseado em clientes, o que significa que tudo que você está fazendo dentro do nosso site gerador de configuração web autônomo está sendo executado localmente em seu navegador para gerar configurações válidas do ASF, sem dados que você vai inserir e deixar seu PC em primeiro lugar, então não há necessidade de se preocupar com qualquer possível vazamento de dados confidenciais. Ainda assim, se por qualquer motivo você não quer colocar suas credenciais lá, nós entendemos isso, e você pode colocá-los manualmente mais tarde nos arquivos gerados ou omiti-los completamente e operar sem eles.

Se você decidir inserir suas credenciais, o ASF poderá se conectar automaticamente durante a inicialização, que em conjunto com o 2FA opcional permitirá que você apenas clique duas vezes no programa para executar tudo. If you decide to omit them, then ASF will **ask you** to input those details when needed - that approach won't save them anywhere, but naturally ASF won't be able to operate without your help. É sua maneira de preferir mais, e você também pode encontrar informações adicionais na seção **[configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** , como de costume.

Além disso, você também pode decidir deixar apenas um campo vazio, como o `SteamPassword`. O ASF então será capaz de usar seu login automaticamente, mas ainda vai pedir a senha se necessário (semelhante ao cliente Steam). Se por qualquer chance você estiver usando o pin parental de 4 dígitos para desbloquear a sua conta, também recomendamos colocá-lo dentro da caixa `SteamParentalPin` , embora também neste caso se possa deixar este vazio e, em vez disso, observar quão fraca é essa proteção. porque o ASF também pode "quebrar" ele mesmo em apenas alguns segundos após o login. Epa

After following with everything above, so once again, **bot name**, **enabled switch**, and **login credentials** , your web page will now look similar to the one below:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Agora você pode clicar no botão "baixar" e nosso gerador de configuração web vai gerar um novo arquivo `json` com base no nome escolhido. Salve o arquivo no diretório `config` que está localizado na pasta dentro da qual você extraiu o arquivo zip no passo anterior.

Parabéns! Você acabou de terminar a configuração básica de um bot ASF. Há muito mais para descobrir, mas por enquanto isso é tudo o que você precisa.

---

### Executando o ASF

Eu sei que você esteve esperando por este momento, e não podemos te manter por mais tempo, enquanto você estiver pronto para iniciar o programa pela primeira vez. Simplesmente clique duas vezes no binário `ArchiSteamFarm` na pasta do ASF. Você também pode iniciá-lo pelo console.

Agora seria uma boa hora para rever a nossa seção **[comunicação remota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** se você estiver preocupado com coisas para as quais o ASF é programado ações especiais que ele tomará em seu nome, como entrar no nosso grupo Steam por padrão. Você sempre pode desativar as funcionalidades selecionadas mais tarde se você não gostar delas, o ASF simplesmente vem com padrões sensatos, e tivemos de tomar alguma decisão sobre o uso geral que se aplica à maioria da nossa base de usuários. Além de nossa própria visão sobre o programa, de acordo com seu princípio.

Assumindo que tudo correu bem, o que principalmente considera a instalação de todas as dependências necessárias na primeira etapa, e configurando o ASF no terceiro, o ASF deve iniciar corretamente, descobrir seu primeiro bot e tentar se conectar:

![ASF](https://i.imgur.com/u5hrSFz.png)

O ASF provavelmente ainda exigirá mais um detalhe de você - o 2FA para acessar a conta (a menos que você esteja desativado o SteamGuard completamente, então não). Simplesmente siga as instruções na tela, você pode fornecer o código do autenticador/e-mail, ou aceitar a confirmação no aplicativo móvel.

Algo deu errado?

#### O ASF não inicia de todo, sem janela de console

Ou você está sem pré-requisitos do .NET ou baixou a variante incorreta do ASF para o seu computador. Se você não sabe o que está errado, confira nossa **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-doesnt-start-the-program-window-closes-immediately)** para ver como é possível descobrir o problema exato e se você ainda estiver preso, entre em contato com nosso **[suporte](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### Nenhum bot definido

Você não colocou a configuração gerada no diretório `config`. Alguns outros erros comuns neste passo podem incluir a mudança manual da extensão `.json` , por exemplo, para `. xt`e alguns sistemas operacionais (por exemplo, Windows) como ocultar extensões comuns por padrão, garantindo que seu arquivo esteja no lugar apropriado e também com o nome apropriado.

#### Este bot não será iniciado porque está desativado no arquivo de configuração

Você esqueceu de virar o interruptor `habilitado` que diz ao ASF para iniciar seu bot automaticamente. A menos que essa seja a sua intenção, claro, mas então você já deve saber como executar comandos, simplesmente `inicie` o bot após essa mensagem.

#### `Senha inválida`

É provável que suas credenciais de login estejam erradas. Verifique o `SteamLogin` e `SteamPassword` na configuração gerada, se eles estiverem errados, corrija-os voltando para a etapa de configuração. Se você ainda tiver problemas, tente usar as mesmas credenciais em seu próprio cliente Steam - você também não deve fazer o login, e talvez você consiga mais informações sobre o que está errado dessa maneira.

#### Tudo bem?

Após passar pela porta de acesso inicial, assumindo que seus dados estejam corretos, você fará o login com sucesso, e o ASF vai começar a coletar usando as configurações padrão que você não tocou agora:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Isso prova que o ASF está fazendo seu trabalho na sua conta, então você pode minimizar o programa e fazer outra coisa. Vai em frente, você mereceu-o, talvez encha essa bebida de sua escolha, pelo menos!

Os cartões de agricultura são assunto para mais um artigo extenso como este, mas em princípio: depois de bastante tempo (dependendo de **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**, você verá que as cartas do Steam serão recebidas lentamente. Claro, para que isso aconteça, você deve ter jogos válidos para coletar, exibindo como "você pode obter mais X cartas ao jogar este jogo" na sua página de insígnias **[](https://steamcommunity.com/my/badges)** - se não houver jogos para coletar, então o ASF informará que não há nada a fazer, como indicado em nosso **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**, que responde à pergunta mais comum que as pessoas têm neste momento, Se perguntando por que, apesar de possuir 14 jogos na conta, o ASF diz que não há nada para fazer - não, não é um erro.

Isso conclui nosso guia de configuração básica. Como em cada jogo de RPG, você terminou o tutorial e vamos deixar o mundo inteiro do ASF para explorar agora. Por exemplo, agora você pode decidir se quer configurar o ASF ainda mais ou deixá-lo fazer seu trabalho com as configurações padrão. Vamos cobrir mais alguns detalhes básicos se você quiser ler mais um pouco e deixar toda a wiki para você descobrir.

---

### Configuração estendida

#### Agricultura de várias contas de uma só vez

O ASF suporta a coleta de mais de uma conta por vez, o que é sua principal função. Você pode adicionar mais contas ao ASF gerando mais arquivos de configuração de bot, exatamente da mesma forma que você gerou o seu primeiro há poucos minutos. A senhora só tem de garantir duas coisas:

- Único nome de bot, se você já tem o seu primeiro bot chamado `MainAccount`, você não pode ter outro com o mesmo nome.
- Dados de login válidos, como `SteamLogin`, `SteamPassword` e `SteamParentalCode` (se você decidiu preenchê-los)

Em outras palavras, simplesmente volte a configurar e faça exatamente a mesma coisa, só para a segunda ou terceira conta. Lembre-se de usar nomes exclusivos para todos os seus bots, para não substituir as configurações existentes.

---

#### Alterando configurações

Em nosso gerador de configuração web autônomo, você altera as configurações existentes exatamente da mesma maneira - gerando um novo arquivo de configuração. Clique em "alternar as configurações avançadas" e veja o que há para você descobrir. Neste exemplo, vamos mudar a configuração `CustomGamePlayedWhileFarming` , o que permite que você defina o nome personalizado que é exibido quando o ASF está coletando, em vez de mostrar o jogo real.

Vamos analisar isso um pouco primeiro. Se você executar o ASF e começar a coletar, com as configurações padrão você verá que sua conta Steam já está em jogo:

![Steam](https://i.imgur.com/1VCDrGC.png)

Isso faz sentido, depois que todo o ASF disse à plataforma Steam que nós estamos jogando o jogo, nós precisamos dele, certo? Mas ei, nós podemos personalizar isso! Alterne as configurações avançadas se ainda não tiver feito e encontre `CustomGamePlayedWhileFarming`. Simplesmente coloque qualquer texto personalizado que deseja exibir lá, como "Idling Cards":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Now download the new config file in exactly the same way, then **overwrite** your old config file with new one. Você também pode apagar seu antigo arquivo de configuração e colocar o novo em seu lugar, é claro.

O ASF é muito inteligente e deve notar que você mudou de configuração, que ele deve então pegar e aplicar automaticamente, sem que um programa seja reiniciado. Se por qualquer chance que isso não tenha acontecido, você pode simplesmente reiniciar o programa para garantir que sua nova configuração esteja pega. Depois de fazer isso, você vai notar que o ASF agora mostra seu texto personalizado no lugar anterior:

![Vapor 2](https://i.imgur.com/vZg0G8P.png)

Isso confirma que você editou sua configuração com sucesso. Da mesma forma você pode alterar as propriedades globais do ASF, mudando da aba "Bot" para a aba "ASF", baixando o `ASF. o arquivo de configuração` e colocá-lo no seu diretório `config`.

Editar suas configurações do ASF pode ser feito muito mais facilmente usando nossa interface ASF-ui, que será explicada abaixo.

---

#### Usando a ASF-ui

Como mencionamos antes, o ASF é um aplicativo de console e não inicia uma interface gráfica de usuário por padrão. No entanto, estamos trabalhando ativamente em **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** frontend para a nossa interface IPC, que pode ser uma forma muito decente e amigável de acessar vários recursos do ASF.

Para usar a ASF-ui, você precisa ativar `IPC` que é a opção padrão, então, a menos que você a desative manualmente, ela já está ativa. Ao iniciar o ASF, você deve ser capaz de confirmar que ele iniciou a interface IPC automaticamente:

![IPC](https://i.imgur.com/ZmkO8pk.png)

O IPC, em poucas palavras, é um servidor web embutido do ASF que começa localmente em seu computador, permitindo que você interaja com ele usando seu navegador da web favorito. Assumindo que ele começou corretamente, você pode acessar a interface IPC do ASF clicando **[este link](http://localhost:1242)** , Enquanto o ASF estiver rodando, da mesma máquina. Você pode usar a ASF-ui para vários fins, por exemplo, editar os arquivos de configuração no local ou enviar os comandos **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Sinta-se à vontade para dar uma olhada e descobrir todas as funcionalidades da ASF-ui.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Summary

Você configurou com sucesso o ASF para que ele use suas contas Steam e você já o personalizou um pouco. Se você seguiu o guia inteiro, então você também conseguiu ajustar o ASF através da nossa interface ASF-ui e começou a descobrir suas funcionalidades. Isso conclui nosso tutorial, mas vamos deixar você com alguns indicadores adicionais para as coisas em que você pode estar interessado, "missões secundárias", se você insistir:

- Nossa **[configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** vai explicar a você o que **todas as** essas diferentes configurações que você viu realmente fazer, e o que mais o ASF pode te oferecer. Lembre-se de hidratar corretamente durante a leitura, você foi avisado.
- Se você tropeçou em algum problema ou você tem alguma pergunta genérica, considere nosso **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)**, que deve abranger todos, ou pelo menos uma vasta maioria de questões e questões que os senhores deputados possam ter.
- Se você quer aprender tudo sobre o ASF e como ele pode tornar sua vida mais fácil, vá para o resto de **[nossa wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. Use a barra lateral à direita para escolher o assunto que te interessa.
- E finalmente, se você descobriu que nosso programa seria útil para você e aprecia a enorme quantidade de trabalho que foi investida nele. você também pode considerar um pequeno **[doação](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** para nossa causa. O ASF é um trabalho amoroso, temos trabalhado duro em nosso tempo livre pelos últimos 10 anos para tornar essa experiência possível para você, e estamos muito orgulhosos dele - mesmo que $1 seja muito apreciada e mostre que você se importa. De qualquer forma, tenha muita diversão!

---

## Configuração genérica

Este apêndice é para usuários avançados que querem configurar o ASF para serem executados na variante **[genérica](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)**. Embora seja mais problemático no uso do que **[variantes específicas para sistemas operacionais](#os-specific-setup)**, ele também vem com benefícios adicionais.

Você quer usar a variante `genérica` principalmente quando:
- Você está usando um sistema operacional para o qual não criamos um pacote específico (como o Windows 32-bit)
- Você já possui .NET Runtime/SDK, ou deseja instalar e usar um
- Você deseja minimizar o tamanho da estrutura do ASF e o consumo de memória manipulando os requisitos de tempo de execução você mesmo
- Você deseja usar um **Plugin[personalizado](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** que requer um setup `genérico` do ASF para ser executado corretamente (devido à falta de dependências nativas)

Claro, você pode usá-lo também em qualquer outro cenário que você quiser, mas o acima faz mais sentido.

No entanto, tenha em mente que a configuração genérica vem com uma reviravolta - **você** é responsável pelo tempo de execução .NET neste caso. Isso significa que se o seu .NET SDK (tempo de execução) estiver indisponível, desatualizado ou com erro, o ASF simplesmente não funcionará. This is why we totally don't recommend this setup for casual users, since you now need to ensure that your .NET SDK (runtime) matches ASF requirements and can run ASF, as opposed to **us** ensuring that our .NET runtime bundled with ASF can do so.

Para o pacote `genérico` , você pode seguir todo o guia específico para SO acima, com apenas duas pequenas alterações. In addition to installing .NET prerequisites, you also want to install .NET SDK, and instead of downloading and having OS-specific `ArchiSteamFarm(.exe)` executable file, you'll now download and have a generic `ArchiSteamFarm.dll` binary only. Todo o resto é exactamente o mesmo.

Com etapas extras:
- Instalar os pré-requisitos **[.NET](#net-prerequisites)**.
- Instalar **[.NET SDK](https://www.microsoft.com/net/download)** (ou pelo menos ASP.NET Core e .NET runtimes) apropriado para seu sistema operacional. Você provavelmente vai querer usar um instalador. Consulte **[exigências de tempo de execução](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** se você não tiver certeza de qual versão instalar.
- Download **[latest ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** in `generic` variant.
- Extrair o arquivo em um novo local.
- U**[Configure o ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, exatamente da mesma forma que o descrito acima.
- Abra o ASF usando um script auxiliar ou executando `dotnet /path/to/ArchiSteamFarm.dll` manualmente pelo seu shell favorito.

A variante genérica do ASF não tem binários específicos do computador depois de tudo ele é chamado de `genérico` por um motivo - é uma compilação agnóstica de plataforma que pode funcionar em qualquer lugar, então não espere o arquivo `exe` lá.

É por isso que os empacotamos com scripts de ajuda (como `ArchiSteamFarm.cmd` para Windows e `ArchiSteamFarm. h` para Linux/macOS), que estão localizadas ao lado de `ArchiSteamFarm.dll` binário. Você pode usar esses se você não quer executar o comando `dotnet` manualmente.

Obviamente, scripts auxiliares não funcionarão se você não instalar. ET SDK e você não tem o executável `dotnet` disponível no seu executável `PATH`. Eles também são totalmente opcionais, você pode sempre usar `dotnet /path/to/ArchiSteamFarm. irá` manualmente se você quiser, já que sob o capuz com alguns ajustes extras, é exatamente o que esses scripts estão fazendo de qualquer maneira.