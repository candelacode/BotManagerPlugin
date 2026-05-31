# Gestão

Esta seção abrange assuntos relacionados ao gerenciamento do processo do ASF de forma ideal. Embora não seja estritamente obrigatório para o uso, ele inclui várias dicas, truques e boas práticas que gostaríamos de compartilhar, especialmente para administradores de sistema, pessoas empacotando o ASF para uso em repositórios de terceiros, bem como usuários avançados e parecidos.

---

## Serviço `systemd` para Linux

Nas variantes `genéricas` e `linux` , o ASF vem com `ArchiSteamFarm@. arquivo ervice` que é um arquivo de configuração do serviço para **[`systemd`](https://systemd.io)**. Se você gostaria de executar o ASF como um serviço, por exemplo, para executá-lo automaticamente após a inicialização do seu computador, então um serviço `systemd` adequado é provavelmente a melhor maneira de fazer isso, Por isso, recomendamos fortemente que ele em vez de gerenciá-lo sozinho através do `nohup`, `screen` ou similar.

Primeiramente, crie uma conta para o usuário que você deseja executar o ASF, assumindo que ela ainda não existe. Nós vamos usar o usuário `asf` neste exemplo, se você decidir usar um diferente, você precisará substituir o usuário `asf` em todos os nossos exemplos abaixo com o seu selecionado. Nosso serviço não permite que você rode o ASF como o `root`, uma vez que é considerado um **[má prática](#never-run-asf-as-administrator)**.

```sh
su # Or sudo -i, para entrar no shell
useradd -m asf # Crie uma conta que você pretende executar o ASF sob
```

Em seguida, descompacte o ASF na pasta `/home/asf/ArchiSteamFarm`. A estrutura de pastas é importante para a nossa unidade de serviço, ela deve ser a pasta `ArchiSteamFarm` no seu `$HOME`, então `/home/<user>`. If you did everything correctly, there will be `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service` file existing. Se você estiver usando a variante `linux` e não descompactar o arquivo no Linux, mas, por exemplo, a transferência de arquivos usada do Windows então você também precisará `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

Nós faremos todas as ações abaixo como `root`, então vá até sua shell com `su` ou `sudo -i`.

Em primeiro lugar, é uma boa ideia garantir que nossa pasta ainda pertence ao nosso usuário `asf` , `chown -hR asf:asf /home/asf/ArchiSteamFarm` executado uma vez fará isso. As permissões podem estar erradas, por exemplo, se você fez o download e/ou descompactar o arquivo zip como raiz ``.

Em segundo lugar, se você estiver usando uma variante genérica do ASF, você precisa garantir que o comando `dotnet` é reconhecido e dentro de um dos locais padrão: `/usr/local/bin`, `/usr/bin` or `/bin`. Isto é necessário para o nosso serviço de sistema que executa o comando `dotnet /path/to/ArchiSteamFarm.dll`. Check if `dotnet --info` works for you, if yes, type `command -v dotnet` to find out where it's located. Se você usou o instalador oficial, ele deve estar em `/usr/bin/dotnet` ou em um dos outros lugares, o que está certo. Se estiver em uma localização personalizada como `/usr/share/dotnet/dotnet`, , crie um link simbólico **[](https://wikipedia.org/wiki/Symbolic_link)** para ele usando `ln -s "$(command -v dotnet)" /usr/bin/dotnet`. Agora, o comando `v dotnet` deve relatar `/usr/bin/dotnet`, o que também fará a nossa unidade de sistema funcionar. Se você estiver usando uma variante específica para Sistema Operacional, você não precisa fazer nada a esse respeito.

Em seguida, execute `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/systemd/system/ArchiSteamFarm\@. ervice`, isso irá criar um link simbólico para a nossa declaração de serviço e registrá-lo no sistema ``. O link simbólico permitirá que o ASF atualize sua unidade `sistema` automaticamente como parte da atualização do ASF - dependendo da sua situação, você pode querer usar essa abordagem, ou simplesmente `cp` o arquivo e gerenciá-lo você mesmo como quiser.

Depois, certifique-se que `systemd` reconhece nosso serviço:

```
ArchiSteamFarm@asf

➤ ArchiSteamFarm@asf.service - ArchiSteamFarm Serviço (no asf)
     Carregado: carregado (/etc/systemd/system/ArchiSteamFarm@. ervice; desabilitado; predefinição do fornecedor: habilitado)
     Ativo: inativo (dead)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Preste atenção especial ao usuário que declaramos após `@`, é `asf` no nosso caso. Nossa unidade de serviço sistema espera que você declare o usuário, já que ele influencia o local exato do binário `/home/<user>/ArchiSteamFarm`, assim como o sistema do usuário real irá gerar o processo como

Se o sistema retornou a saída de forma semelhante ao acima, tudo está em ordem, e estamos quase terminando. Agora só falta iniciar nosso serviço como nosso usuário escolhido: `systemctl start ArchiSteamFarm@asf`. Aguarde alguns segundos ou dois, e você pode verificar o status novamente:

```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (no asf)
     Carregado: carregado (/etc/systemd/system/ArchiSteamFarm@.service; disabled; vendor preset: enabled)
     Ativo: ativo (executado) desde (...)
       Documentos: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   PID principal: (...)
(...)
```

Se `systemd` estados `ativo (executando)`, isso significa que tudo correu bem, e você pode verificar se o processo do ASF deve estar aberto e sendo executado, por exemplo, com o journalctl -r</code>`como o ASF também grava para a saída do console, que é registrado pela <code>systemd`. Se estiver satisfeito com a configuração que tem agora, você pode dizer ao `systemd` para iniciar seu serviço automaticamente durante a inicialização, executando o systemctl `habilitar o comando ArchiSteamFarm@asf`. Isso é tudo.

Se por acaso você quiser parar o processo, simplesmente execute `systemctl stop ArchiSteamFarm@asf`. Da mesma forma, se você deseja desativar o ASF de ser iniciado automaticamente na inicialização, `systemctl disable ArchiSteamFarm@asf` fará isso por você, é muito simples.

Por favor, note que, como não há nenhuma entrada padrão ativada para o serviço `systemd` , você não será capaz de inserir os detalhes através do console de maneira normal. Executar através de `systemd` é equivalente a especificar **[`Headless: verdadeira`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** configuração e vem com todas as suas implicações. Felizmente para você, é muito fácil gerenciar o seu ASF através do **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, que recomendamos no caso de precisar fornecer detalhes adicionais durante o login ou de outra forma gerenciar seu processo do ASF ainda mais.

### Variáveis de ambiente

É possível fornecer variáveis de ambiente adicionais ao nosso serviço `systemd` , que você estará interessado em fazer caso você queira, por exemplo, usar um argumento `--cryptkey` **[de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**portanto, especificando a variável de ambiente `ASF_CRYPTKEY`.

Para fornecer variáveis de ambiente personalizadas, crie a pasta `/etc/asf` (no caso de não existir), `mkdir -p /etc/asf`. Recomendamos a `chown -hR root:root /etc/asf && chmod 700 /etc/asf` para garantir que apenas o usuário `root` tenha acesso para ler esses arquivos, porque eles podem conter propriedades sensíveis como `ASF_CRYPTKEY`. Depois disso, escreva para um arquivo `/etc/asf/<user>` onde `<user>` é o usuário que está executando o serviço em (`asf` em nosso exemplo acima so `/etc/asf/asf`).

O arquivo deve conter todas as variáveis de ambiente que você deseja fornecer ao processo. Those that do not have a dedicated environment variable, can be declared in `ASF_ARGS`:

```sh
# Declare apenas aqueles que você realmente precisa de
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

e quaisquer outras que você esteja interessado
```

### Sobrescrevendo parte da unidade de serviço

Graças à flexibilidade do `systemd`, É possível substituir parte da unidade do ASF enquanto ainda preserva o arquivo unitário original e permite que o ASF o atualize como parte das atualizações automáticas.

Neste exemplo, gostaríamos de modificar o comportamento unitário padrão do ASF `systemd` reiniciando apenas no sucesso, reiniciando também em falhas fatais. Para fazer isso, Nós sobrescreveremos a propriedade `Reiniciar` sob `[Service]` do padrão `on-success` para `sempre`. Simplesmente execute `systemctl edit ArchiSteamFarm@asf`, substituindo naturalmente `asf` pelo usuário de destino do seu serviço. Em seguida, adicione as alterações conforme indicado pelo `systemd` na seção adequada:

```sh
### Editing /etc/systemd/system/ArchiSteamFarm@asf.service.d/override.conf
### Anything between here and the comment below will become the new contents of the file

[Service]
Restart=always

### Lines below this comment will be discarded

### /etc/systemd/system/ArchiSteamFarm@asf.service
# [Install]
# WantedBy=multi-user.target
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm.dll --no-restart --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# User=%i
# (...)
```

E é isso, agora sua unidade age da mesma forma que se tivesse apenas `Restart=sempre` sob `[Service]`.

Claro, alternativa é o `cp` o arquivo e gerenciá-lo você mesmo, mas isso te permite mudanças flexíveis mesmo se você decidiu manter a unidade original do ASF, por exemplo, com um link simbólico **[](https://wikipedia.org/wiki/Symbolic_link)**.

---

## Nunca execute o ASF como administrador!

O ASF inclui a sua própria validação se o processo está sendo executado como administrador (`root`) ou não. Executando como `root` é **não** necessário para qualquer tipo de operação feita pelo processo ASF. Partindo do pressuposto de que o ambiente esteja funcionando corretamente e, portanto, deve ser considerado um **mau prática**. This means that on Windows, ASF should **never** be executed with "run as administrator" setting, and on Unix ASF should have a **dedicated user account** for itself, or re-use your own in case of a desktop system.

Para obter mais explicações sobre *por que* desencorajamos a execução do ASF como a raiz ``, consulte **[superusuário](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** e outros recursos. Se você ainda não está convencido, Pergunte-se o que aconteceria ao seu computador se o processo do ASF executasse o comando `rm -rf /*` logo após seu lançamento.

### Eu rodo como raiz `` porque o ASF não pode escrever em seus arquivos

Isso significa que você configurou incorretamente as permissões dos arquivos que o ASF está tentando acessar. Você deve fazer login como uma conta `root` (ou com `su` ou `sudo -i`) e **corrigir** as permissões emitindo `chown -hR asf:asf /path/to/ASF` comando, substituir `asf:asf` pelo usuário em que você executará o ASF e `/path/to/ASF` de acordo. Se por qualquer chance você estiver usando um personalizado `--path` dizendo ao usuário do ASF para usar a pasta diferente, você deve executar o mesmo comando novamente para esse caminho também.

Depois de fazer isso, você não deverá mais ter nenhum tipo de problema relacionado ao ASF não ser capaz de escrever nos seus próprios arquivos, já que você acabou de alterar o proprietário de tudo o que o ASF está interessado para o usuário, o processo realmente será executado abaixo.

### Eu rodo como `root` porque não sei como fazer do contrário

```sh
su # Ou sudo -i, para entrar no shell
useradd -m asf # Criar conta que você pretende executar o ASF sob
chown -hR asf:asf /path/to/ASF # Certifique-se de que seu novo usuário tenha acesso à pasta
su asf -c /path/to/ASF/ArchiSteamFarm # Ou sudo -u asf /path/to/ASF/ArchiSteamFarm, para iniciar o programa sob seu usuário
```

Isso seria feito manualmente, seria muito mais fácil usar nosso serviço **[`systemd`](#systemd-service-for-linux)** explicado acima.

### Eu sei melhor e ainda quero executar como `root`

O ASF não te impede forçosamente de fazer isso, apenas exibe um aviso com uma nota curta. Só não fique chocado se um dia devido a um erro no programa, ele explodir todo o seu SO com perda completa de dados - você foi avisado.

---

## Múltiplas instâncias

O ASF é compatível com várias instâncias do processo em execução no mesmo computador. As instâncias podem ser completamente autônomas ou derivadas do mesmo local binário (em que caso, você quer executá-los com diferente `--path` **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**).

Ao executar várias instâncias do mesmo binário, tenha em mente que você normalmente deve desativar as atualizações automáticas em todas as suas configurações, já que não há sincronização entre eles no que diz respeito a atualizações automáticas. Se você gostaria de continuar ativando as atualizações automáticas, recomendamos instâncias autônomas, mas você ainda pode fazer atualizações funcionarem, contanto que você possa garantir que todas as outras instâncias do ASF sejam fechadas.

O ASF fará o seu melhor para manter uma quantidade mínima de comunicação entre Sistema Operacional e multi-processo com outras instâncias do ASF. Isso inclui o ASF verificando sua pasta de configuração contra outras instâncias, além de compartilhar limitadores de processos em todo o processo configurados com `*LimiterDelay` **[propriedades globais de configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, garantir que rodar várias instâncias do ASF não causará uma possibilidade de problemas que limitem a tarifa. No que diz respeito a aspectos técnicos, todas as plataformas usam nosso mecanismo dedicado de bloqueios com arquivos personalizados do ASF, criados na pasta temporária, que é `C:\Users\<YourUser>\AppData\Local\Temp\ASF` no Windows e `/tmp/ASF` no Unix.

Não é necessário para rodar as instâncias do ASF para compartilhar as mesmas propriedades `*LimiterDelay` , eles podem usar valores diferentes, já que cada ASF adicionará seu próprio atraso configurado para o tempo de liberação após adquirir o bloqueio. Se a configuração `*LimiterDelay` está configurada como `0`, A instância do ASF vai pular completamente esperando pelo bloqueio de determinado recurso que é compartilhado com outras instâncias (que potencialmente ainda poderia manter um bloqueio compartilhado uns com os outros). Quando definido como outro valor, o ASF irá sincronizar corretamente com outras instâncias do ASF e esperar pela sua vez depois libere o bloqueio após atraso configurado, permitindo que outras instâncias continue.

O ASF leva em conta a configuração `WebProxy` quando decide sobre o escopo compartilhado, o que significa que duas instâncias do ASF usando configurações `WebProxy` diferentes não compartilharão seus limitadores. Isso é implementado para permitir que as configurações do `WebProxy` operem sem atrasos excessivos, como esperado de diferentes interfaces de rede. Isso deve ser bom o suficiente para a maioria dos casos de uso, no entanto, se você tiver uma configuração personalizada específica, na qual você, por exemplo, rotear solicita a si mesmo de uma maneira diferente você pode especificar o grupo de rede através do argumento `--network-group` **[de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**, que permitirá que você declare o grupo do ASF que será sincronizado com esta instância. Tenha em mente que grupos de rede personalizados são usados exclusivamente, que significa que o ASF não vai mais usar `WebProxy` para determinar o grupo certo, já que você é responsável pelo agrupamento nesse caso.

Se você gostaria de usar o nosso serviço **[`systemd`](#systemd-service-for-linux)** explicado acima para várias instâncias do ASF, é muito simples, basta usar outro usuário para nossa declaração de serviço `ArchiSteamFarm@` e seguir com os restantes passos. Isso será o equivalente a rodar várias instâncias do ASF com binários distintos, então eles também podem atualizar automaticamente e operar independentemente um do outro.