# Atracador

ASF está disponível como o contêiner **[docker](https://www.docker.com/what-container)**. Nossos pacotes docker estão atualmente disponíveis no **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** bem como **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

É importante notar que a execução do ASF no contêiner Docker é considerada **configuração avançada**, o que **não é necessário** para a grande maioria dos usuários, e normalmente não dá **nenhuma vantagem** sobre a configuração sem contêiner. Se você está considerando o Docker como uma solução para executar o ASF como um serviço, por exemplo, fazendo-o iniciar automaticamente com seu sistema operacional, então você deve considerar ler a seção **[gerenciamento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** em vez disso e configurar um serviço `systemd` adequado que será **quase sempre** uma idéia melhor do que executar o ASF em um contêiner Docker.

Executar o ASF em um contêiner Docker geralmente envolve **vários novos problemas e problemas** que você terá que enfrentar e se resolver. É por isso que nós **fortemente** recomendamos que você evite isso, a menos que você já tenha conhecimento Docker e não precise ajudar a entender seus internos, sobre quais não vamos desenvolver aqui na wiki do ASF. Esta seção é principalmente para casos de uso válidos de configurações muito complexas, por exemplo, no que diz respeito a redes avançadas ou segurança além do plano de segurança padrão com que o ASF vem no serviço `systemd` (que já garante o isolamento do processo superior através de mecânicas de segurança muito avançadas). Para essa meia dúzia de pessoas, aqui explicamos os conceitos melhores do ASF em relação à sua compatibilidade com o Docker, e só isso, presume-se que você tem conhecimento médico adequado se você decidir usá-lo juntamente com o ASF.

---

## Etiquetas

O ASF está disponível através de vários tipos de marcadores **[](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `principal`

Compilação genérica do ASF que é compilada a partir do último commit no ramo `principal` , que funciona o mesmo que pegar o artefato mais recente diretamente da nossa **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pipeline. É o mais alto nível de software com erros, dedicado aos desenvolvedores e usuários avançados para fins de desenvolvimento. A imagem está sendo atualizada a cada commit no branch `principal` GitHub, Portanto, você pode esperar muitas vezes mudanças (e coisas quebradas). Ele está aqui para marcar o estado atual do projeto ASF. que não está necessariamente garantido que seja estável ou testado, tal como foi referido no nosso ciclo de lançamento. **Esta tag não deve ser usada em qualquer ambiente de produção**. Útil para verificar se determinado commit corrigiu o problema que você está encontrando, sem esperar mesmo por um pré-lançamento com esse commit.


### `liberado`

Compilação genérica do ASF que sempre aponta para a versão **[lançada pelo](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** do ASF, incluindo pré-lançamentos. Compared to `main` tag, image here is being updated each time a new GitHub tag is pushed. Dedicado a usuários avançados que adoram viver no limite do que pode ser considerado estável e novo ao mesmo tempo. Na prática, ele funciona o mesmo que a tag rolante apontando para o lançamento `A.B.C.D` mais recente no momento da movimentação. Note que usar esta tag é igual ao usar a nossa **[pre-releases](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `estável`

A compilação genérica do ASF que sempre aponta para a última versão **[estável](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** do ASF. Comparado ao marcador `lançado` , a imagem aqui será atualizada uma vez que uma nova versão estável do ASF seja disponibilizada. Recomendado para pessoas que estão procurando por uma variante estável de `liberado uma tag` mencionada acima.

### `último`

Versão específica para SO do ASF que sempre aponta para a última versão do ASF **[estável](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. Em comparação com outros, este é o **único marcador** que inclui as atualizações automáticas do ASF. O objetivo desse marcador é fornecer um contêiner Docker padrão que seja capaz de executar a compilação do ASF com auto atualização, específica para o SO. Por esse motivo, a imagem não precisa ser atualizada o mais frequentemente possível. como inclusa a versão do ASF sempre será capaz de se atualizar se necessário.

Claro, `UpdatePeriod` pode ser desativado com segurança (definido como `0`), mas, neste caso, você deve provavelmente usar a liberação `estável` em vez disso. Da mesma forma, você pode modificar o padrão `UpdateChannel` a fim de rastrear pré-lançamentos, em vez disso, se você quiser.

Due to the fact that the `latest` image comes with capability of auto-updates, it includes bare OS with OS-specific `linux` ASF version, contrary to all other tags that include OS with .NET runtime and `generic` ASF version. Isso ocorre porque a versão mais recente do ASF (atualizada) também pode exigir tempo de execução mais recente do que aquele com que a imagem possivelmente poderia ser construída. que exigiria que a imagem fosse reconstruída do zero, anulando o caso de uso planejado.

### `A.B.C.D`

A compilação genérica do ASF que aponta para a versão corrigida do ASF que corresponde ao marcador. Em comparação com os marcadores acima, esse marcador é completamente congelado, o que significa que a imagem aqui não será atualizada uma vez que for publicada. Funciona de forma semelhante às nossas versões do GitHub que nunca foram tocadas após o lançamento inicial, o que garante um ambiente estável e congelado. Normalmente você deve usar esse marcador quando você quer usar uma versão específica do ASF e esperar o resultado determinístico da compilação (e. . gerenciar as versões do ASF você mesmo, em vez disso).

---

## Qual é o melhor marcador para mim?

Isso depende do que você procura. For majority of users, `latest` tag should be the best one as it offers exactly what desktop ASF does, just in special Docker container as a service. No entanto, não é necessariamente assim que o docker deve ser usado - normalmente você deve reconstruir seus contêineres e não executá-los para sempre, e neste caso você deve considerar `estável` ou `liberado` , que segue as diretrizes docker. Por fim, se você deseja executar uma versão fixa do ASF naturalmente `A.B.C.D` lançamentos são o que você está procurando.

Nós geralmente desencorajamos o uso de compilações `principais` , já que elas estão aqui para marcarmos o estado atual do projeto ASF. Nada garante que esse Estado funcione devidamente, mas claro que você é bem-vindo para fazer um teste se estiver interessado no desenvolvimento do ASF.

---

## Arquiteturas

A imagem docker do ASF é feita com `linux` plataforma visando 3 arquiteturas - `x64`, `braços` e `arm64`. Você pode ler mais sobre eles em **[compatibilidade](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**.

Nossas tags estão usando manifesto multi-plataforma, o que significa que o Docker instalado na sua máquina irá selecionar automaticamente a imagem adequada da sua plataforma ao puxar a imagem. Se por acaso você gostaria de puxar uma imagem de plataforma específica que não corresponde à que você está executando atualmente, você pode fazer isso através de `--platform` switch em comandos docker apropriados, como `docker executa`. Consulte a documentação docker no manifesto **[imagem](https://docs.docker.com/registry/spec/manifest-v2-2)** para obter mais informações.

---

## Utilização

Para uma referência completa você deve usar **[documentação oficial docker](https://docs.docker.com/engine/reference/commandline/docker)**, cobriremos apenas o uso básico neste guia, você é mais do que bem-vindo para cavar mais fundo.

### Hello ASF!

Em primeiro lugar, devemos verificar se nosso docker está funcionando corretamente, isso funcionará como o ASF "olá mundo":

```shell
docker run -it --name asf --pull sempre --rm justarchi/archisteamfarm
```

`docker roda` cria um novo contêiner docker do ASF para você e o executa em primeiro plano (`-it`). `--pull sempre` garante que a imagem atualizada seja tirada primeiro, e `--rm` garante que nosso contêiner será purgado uma vez que estamos apenas testando se tudo funciona bem por enquanto.

Se tudo terminou com sucesso, após puxar todas as camadas e iniciar contêiner, você deve notar que o ASF iniciou e nos informou que não há bots definidos, o que é bom; verificamos que o ASF no docker funciona corretamente. Pressione `CTRL+C` para finalizar o processo do ASF e, portanto, também o contêiner.

Se você olhar de perto para o comando, então vai notar que não declaramos nenhuma tag, que automaticamente foi padronizado para `mais recente` um. Se você quer usar outra tag que não a `latest`, por exemplo, `released`, então você deve declará-la explicitamente:

```shell
docker run -it --name asf --pull sempre --rm justarchi/archisteamfarm:released
```

---

## Usando um volume

Se você estiver usando o ASF em um contêiner docker, então obviamente você precisa configurar o próprio programa. Você pode fazer isso de várias maneiras diferentes, mas o recomendado seria criar a pasta `config` do ASF no computador local, então o monte como um volume compartilhado no contêiner docker do ASF.

Por exemplo, assumiremos que sua pasta config do ASF está na pasta `/home/archi/ASF/config`. Esta pasta contém o core `ASF.json` bem como os bots que queremos executar. Agora tudo o que precisamos fazer é anexar esse diretório como volume compartilhado no nosso contêiner docker, onde o ASF espera sua pasta de configurações (`/app/config`).

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull sempre justarchi/archisteamfarm
```

E é isso, agora o contêiner docker do ASF usará a pasta compartilhada com seu computador local em modo de leitura e gravação, é tudo o que você precisa para configurar o ASF. Da mesma forma, você pode montar outros volumes que você gostaria de compartilhar com o ASF, tais como `/app/logs` ou `/app/plugins`.

É claro que esta é apenas uma maneira específica de alcançar o que queremos, nada te impede de, por exemplo, criando o seu próprio `Dockerfile` que copiará os seus arquivos de configuração para a pasta `/app/config` dentro do contêiner docker do ASF. Estamos cobrindo apenas o uso básico neste guia.

### Permissões de volume

O contêiner do ASF por padrão é inicializado com o usuário padrão `root` , que lhe permite lidar com as coisas das permissões internas e, eventualmente, mudar para o usuário `asf` (UID `1000`) para a parte restante do processo principal. Embora isso deva ser satisfatório para a grande maioria dos usuários, isso afeta realmente o volume compartilhado, já que os arquivos recém-gerados normalmente pertencerão ao usuário da `asf` , que pode não ser a situação desejada se você quiser outro usuário para seu volume compartilhado.

Há duas maneiras de alterar o usuário em que o ASF está sendo executado. O primeiro, recomendado, é declarar `ASF_UID` variável de ambiente com UID de destino que você deseja executar abaixo. Segundo, um alternativo, é passar `--user` **[flag](https://docs.docker.com/engine/reference/run/#user)**, que é suportado diretamente pelo docker.

You can check your `uid` for example with `id -u` command, then declare it as specified above. Por exemplo, se o usuário alvo tem `uid` de 1001:

```shell
docker run -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull sempre justarchi/archisteamfarm

# Alternativamente, se você entender as limitações abaixo
docker run -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull sempre justarchi/archisteamfarm
```

A diferença entre `ASF_UID` e `--user` flag é subtle, mas importante. `ASF_UID` é um mecanismo personalizado suportado pelo ASF, neste cenário o contêiner docker começa como `root`, e então o script de inicialização do ASF inicia o binário principal sob `ASF_UID`. Ao usar `--user` flag, você está iniciando todo o processo, incluindo o script de inicialização do ASF como determinado usuário. A primeira opção permite que o script de inicialização do ASF lide automaticamente com permissões e outras coisas para você, resolvendo alguns problemas comuns que você pode ter causado, por exemplo, garante que os diretórios do seu `/app` e `/asf` sejam realmente propriedade de `ASF_UID`. No segundo cenário, já que não estamos rodando como `root`, nós não podemos fazer isso e você deve lidar com isso você mesmo com antecedência.

Se você decidiu usar a bandeira `--user` , você precisa alterar a propriedade de todos os arquivos do ASF do padrão `1000` para seu novo usuário personalizado. Você pode fazê-lo executando o comando abaixo:

```shell
# Executar apenas se você não estiver usando ASF_UID
docker exec -u root asf_container_name chown -hR 1001 /app /asf
```

Isso tem que ser feito apenas uma vez depois de criar o seu contêiner com `docker run`, e somente se você decidir usar um usuário personalizado através da bandeira Docker `--user`. Também não se esqueça de alterar o argumento `1001` no comando acima para o `UID` no qual você realmente deseja executar o ASF abaixo.

### Volume com SELinux

Se você estiver usando o SELinux no seu sistema operacional, que é o padrão, por exemplo, em distrações, baseadas em RHEL, em seguida, você deve montar o contexto de volume anexado a opção `:Z` , que definirá o contexto do SELinux correto para isso.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull sempre justarchi/archisteamfarm
```

Isso permitirá que o ASF crie arquivos para o volume enquanto estiver dentro do contêiner do docker.

---

## Sincronização de múltiplas instâncias

ASF includes support for multiple instances synchronization, as stated in **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** section. Ao executar o ASF no contêiner docker, você pode opcionalmente "opt-in" no processo, caso você esteja executando vários contêineres com o ASF e você gostaria que eles sincronizassem um com o outro.

Por padrão, cada ASF rodando dentro de um contêiner docker é independente, o que significa que não há sincronização. Para ativar a sincronização entre eles, você deve vincular o caminho `/tmp/ASF` em cada contêiner do ASF que você deseja sincronizar, para um, caminho compartilhado no seu host docker, em modo de leitura-escrita. Isto é conseguido exactamente o mesmo que vincular um volume que foi descrito acima, apenas com caminhos diferentes:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull sempre justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull sempre justarchi/archisteamfarm
# E assim por diante, todos os contêineres do ASF agora são sincronizados uns com os outros
```

Recomendamos vincular a pasta `/tmp/ASF` do ASF também a uma pasta temporária `/tmp` no seu computador, mas claro que você é livre para escolher qualquer outro que satisfaça o seu uso. Cada contêiner do ASF que se espera seja sincronizado deve ter seu diretório `/tmp/ASF` compartilhado com outros contêineres que participam do mesmo processo de sincronização.

Como você provavelmente adivinhou do exemplo acima, também é possível criar dois ou mais "grupos de sincronização", conectando diferentes caminhos do host docker no `/tmp/ASF` do ASF.

Montar `/tmp/ASF` é completamente opcional e na verdade não é recomendado, a menos que você queira explicitamente sincronizar dois ou mais recipientes do ASF. Não recomendamos montar `/tmp/ASF` para uso de contêiner único, já que não traz absolutamente nenhum benefício se você espera executar apenas um contêiner do ASF, e na verdade poderia causar problemas que, de outra forma, poderiam ser evitados.

---

## Argumentos de linha de comando

O ASF te permite passar argumentos **[de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** no contêiner docker através de variáveis de ambiente. Você deve usar variáveis de ambiente específicas para comutações suportadas, e `ASF_ARGS` para o resto. Isto pode ser alcançado com o switch `-e` adicionado ao `docker run`, por exemplo:

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull sempre justarchi/archisteamfarm
```

Esse comando passará seu argumento `--cryptkey` para o processo do ASF sendo executado dentro do contêiner docker, bem como outros argumentos. Claro, se você for um usuário avançado, então você também pode modificar `ENTRYPOINT` ou adicionar `CMD` e passar seus argumentos personalizados você mesmo.

A menos que você queira fornecer a chave de criptografia personalizada ou outras opções avançadas, geralmente você não precisa incluir nenhuma variável de ambiente especial, como nossos contêineres docker já estão configurados para serem executados com uma opção padrão sane esperada de `--no-restart`, para que a flag não precise ser especificada explicitamente em `ASF_ARGS`.

---

## IPC

Supondo que você não mudou o valor padrão do `IPC` **[global configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, ele já está habilitado. No entanto, você deve fazer duas coisas adicionais para que o IPC funcione no contêiner Docker. Primeiro, você deve usar `IPCPassword` ou modificar o padrão `KnownNetworks` no IP `personalizado. onfig` para permitir que você se conecte do exterior sem usar um. A menos que você realmente saiba o que está fazendo, use `IPCPassword`. Em segundo lugar, você precisa modificar o endereço de escuta padrão de `localhost`, já que o docker não pode rotear tráfego externo para interface de loopback. Um exemplo de configuração que irá escutar em todas as interfaces seria `http://*:1242`. Claro, você também pode usar ligações mais restritivas, como apenas rede LAN ou VPN local, mas tem que ser uma rota acessível a partir do exterior - `localhost` não serve, como a rota está inteiramente dentro de uma máquina convidada.

Por usar o código acima você deve usar **[configuração personalizada do IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** como o exemplo abaixo:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Uma vez que configuramos o IPC na interface não-loopback, precisamos dizer ao docker para mapear a porta `1242/tcp` do ASF seja com a opção `-P` ou `-p`.

Por exemplo, este comando exporia a interface do IPC do ASF para o computador host (somente):

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull sempre justarchi/archisteamfarm
```

Se você definir tudo corretamente, O comando `docker roda` acima fará com que a interface **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** funcione no seu computador de hospedagem, na rota padrão `localhost:1242` que agora é redirecionada corretamente para a sua máquina convidada. Também é bom notar que não expomos essa rota ainda mais, assim a conexão só pode ser feita dentro do host docker e, portanto, mantendo-o seguro. Claro, você pode expor a rota mais adiante se você sabe o que está fazendo e garantir medidas de segurança adequadas.

---

### Exemplo completo

Combinando todo conhecimento acima, um exemplo de uma configuração completa ficaria assim:

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/plugins:/app/plugins --name asf --pull sempre --restart unless-stopped justarchi/archisteamfarm
```

Isso pressupõe que você vai usar um único contêiner do ASF, com todos os arquivos de configuração do ASF em `/home/archi/ASF/config`. Você deve modificar o caminho de configuração para aquele que corresponde à sua máquina. Também é possível fornecer plugins personalizados para o ASF, que você pode colocar em `/home/archi/ASF/plugins`. Esta configuração também está pronta para o uso opcional do IPC se você decidiu incluir `IPC. onfig` no seu diretório de configuração com um conteúdo como abaixo:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Você pode alcançar o mesmo efeito do comando `docker executar` acima usando a configuração `docker compose`:

```yaml
versão: "3. "
services:
  asf:
    image: justarchi/archisteamfarm
    container_name: asf
    restart: unless-stopped
    ports:
      - "127. .0.1:1242:1242"
      - "[::1]:1242:1242"
    volumes:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

De outras coisas que não já discutimos acima, Adicionamos `--restart unless-stopped` aos dois exemplos acima para iniciar este contêiner automaticamente após reiniciar sua máquina. Sinta-se à vontade para remover/mudar isso para atender às suas necessidades.

---

## Pro tips

Quando você já tem seu contêiner docker do ASF pronto, você não precisa usar o `docker rodar` toda vez. Você pode parar/iniciar o contêiner docker do ASF facilmente com `docker stop asf` e `docker start asf`. Tenha em mente que se você não estiver usando o marcador `mais recente do` então usar a versão atualizada do ASF ainda exigirá que o `docker pare`, `docker rm` e `docker roda` novamente. Isto porque você deve recompilar seu contêiner a partir de uma imagem nova do ASF toda vez que você quiser usar a versão do ASF incluída nessa imagem. No marcador `mais recente` , o ASF incluiu a capacidade de se atualizar automaticamente, então reconstruir a imagem não é necessário para usar o ASF atualizado (mas ainda é uma boa ideia fazê-lo de vez em quando para usar o novo. Efetue as dependências de tempo de execução e o SO subjacente, que podem ser necessárias ao pular entre as atualizações principais da versão do ASF).

As hinted by above, ASF in tag other than `latest` won't automatically update itself, which means that **you** are in charge of using up-to-date `justarchi/archisteamfarm` repo. Isso tem muitas vantagens como normalmente o aplicativo não deve tocar em seu próprio código durante a execução, mas também entendemos a conveniência de não ter que se preocupar com a versão do ASF no seu contêiner docker. If you care about good practices and proper docker usage, `released` tag is what we'd suggest instead of `latest`, but if you can't be bothered with it and you just want to make ASF both work and auto-update itself, then `latest` will do.

Você normalmente deve executar o ASF no contêiner docker com `Headless: verdadeira` configuração global. Isso vai dizer claramente ao ASF que você não está aqui para fornecer os dados ausentes e ele não deve pedi-los. Claro, para a configuração inicial você deve deixar essa opção em `false` para que você possa facilmente configurar as coisas. mas em longo prazo você normalmente não está conectado ao console do ASF, portanto, faz sentido informar o ASF sobre isso e usar o comando `input` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** se precisar aparecer. Desta forma o ASF não vai esperar infinitamente por uma entrada do usuário que não acontecerá (e gastar recursos enquanto isso). It will also allow ASF to run in non-interactive mode inside container, which is crucial e.g. in regards to forwarding signals, making it possible for ASF to gracefully close on `docker stop asf` request.