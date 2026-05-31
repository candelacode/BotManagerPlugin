# IPC

O ASF inclui sua própria interface IPC que pode ser usada para uma interação adicional com o processo. IPC significa comunicação **[inter-process](https://en.wikipedia.org/wiki/Inter-process_communication)** e na definição mais simples que é a "interface web do ASF" baseada em **[Kestrel HTTP server](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel)** que pode ser usada para uma maior integração com o processo, tanto como um frontend para o usuário final (ASF-ui) como o backend para integrações de terceiros (ASF API).

O IPC pode ser usado para muitas coisas diferentes, dependendo de suas necessidades e habilidades. Por exemplo, você pode usá-lo para buscar o status do ASF e de todos os bots, enviar comandos ASF, buscar e editar as configurações global/do bot, adicionando novos bots, excluindo bots existentes, enviando chaves para **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** ou acessando o arquivo de log do ASF. Todas essas ações são expostas pela nossa API, o que significa que você pode codificar suas próprias ferramentas e scripts que serão capazes de se comunicar com o ASF e influenciá-lo durante o tempo de execução. Além disso, ações selecionadas (como o envio de comandos) também são implementadas em nosso ASF-ui que permite que você tenha acesso fácil através de uma interface web amigável.

---

# Utilização

A menos que você tenha desabilitado manualmente o IPC através do `IPC` **[global configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, ele está habilitado por padrão. O ASF indicará a execução do IPC em seu log que você pode usar para verificar se a interface IPC foi iniciada corretamente:

```text
INFO➲ ASF├Start() Iniciando o servidor IPC...
O servidor IPC INFO➲ ASF➲ Start() está pronto!
```

O servidor http do ASF agora vai ouvir nos endpoints selecionados. Se você não forneceu um arquivo de configuração personalizado para o IPC, ele será `localhost`, ambos baseados em IPv6 **[127. .0.1](http://127.0.0.1:1242)** e baseado em IPv6 **[[::1]](http://[::1]:1242)** por padrão `1242` porta. Você pode acessar nossa interface IPC através dos links acima, mas apenas do mesmo computador que o processo em execução do ASF.

A interface IPC do ASF expõe três maneiras diferentes de acessá-lo, dependendo do seu uso planejado.

No nível mais baixo há **[API do ASF](#asf-api)** que é o núcleo da nossa interface IPC e permite que todo o resto opere. É isso que você deseja usar em suas próprias ferramentas, utilitários e projetos para se comunicar diretamente com o ASF.

No nível médio há a nossa documentação **[Swagger](#swagger-documentation)** que atua como um frontend para a API do ASF. Ele apresenta uma documentação completa da API do ASF e também permite que você o acesse mais facilmente. Isso é o que você quer checar se você está planejando escrever uma ferramenta, utilidade ou outros projetos que supostamente se comunicam com o ASF por meio da API.

No nível mais alto existe **[ASF-ui](#asf-ui)** que é baseada no nosso API do ASF e fornece uma forma amigável de executar várias ações do ASF. Essa é nossa interface IPC padrão projetada para usuários finais e um exemplo perfeito do que você pode construir com a API do ASF. Se você quiser, você pode usar sua própria interface web personalizada para usar com o ASF, especificando `--path` **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** e usando diretório `www` personalizado localizado lá.

---

# ASF-ui

ASF-ui é um projeto da comunidade que busca criar uma interface gráfica web amigável para usuários finais. Para conseguir isso, ele atua como um frontend para o nosso **[ASF API](#asf-api)**, permitindo que você faça várias ações com facilidade. Esta é a interface padrão do usuário que acompanha o ASF.

Como mencionado acima, a ASF-ui é um projeto da comunidade que não é mantido pelos principais desenvolvedores do ASF. Ela segue seu próprio fluxo em **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** que deve ser usado para todas as questões relacionadas, problemas, relatórios de bugs e sugestões.

Você pode usar a ASF-ui para gerenciar em geral o processo do ASF. Ele permite por exemplo gerenciar bots, modificar configurações, enviar comandos e alcançar outra funcionalidade normalmente disponível através do ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

Nossa API do ASF é um típico **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** API web que é baseada em JSON como seu formato de dados primários. Estamos fazendo nosso melhor para descrever precisamente a resposta, usando ambos códigos de status HTTP (quando apropriado), bem como uma resposta, você pode analisar a si mesmo para saber se a solicitação foi bem sucedida e, em caso negativo, porquê.

Nossa API do ASF pode ser acessada enviando solicitações apropriadas para os endpoints `/Api`. Você pode usar esses API endpoints para criar seus próprios scripts, ferramentas, interfaces gráficas e afins. Isso é exatamente o que a nossa ASF-ui alcança, e qualquer outra ferramenta pode conseguir o mesmo. O API do ASF é oficialmente suportado e mantido pela equipe principal do ASF.

Para uma documentação completa de endpoints disponíveis, descrições, solicitações, respostas, códigos de status http e tudo o mais considerando o API do ASF, por favor, consulte a nossa documentação **[swagger](#swagger-documentation)**.

![ASF API](https://github.com/user-attachments/assets/08c3d4ad-ea77-403d-a18a-b75c3d0a3097)


---

# Configuração personalizada

Our IPC interface supports extra config file, `IPC.config` that should be put in standard ASF's `config` directory.

Quando disponível, este arquivo especifica configurações avançadas do servidor http Kestrel do ASF, juntamente com outros ajustes relacionados ao IPC. A menos que você tenha uma necessidade específica, não há razão para você usar este arquivo, Como o ASF já usa padrões razoáveis nesse caso.

O arquivo de configuração baseia-se na seguinte estrutura JSON:

```json
{
    "Kestrel": {
        "Endpoints": {
            "example-http4": {
                "Url": "http://127. 0,0. :1242"
            },
            "exemplo-http6": {
                "Url": "http://[::1]:1242"
            },
            "exemplo-https4": {
                "Url": "https://127. .0.1:1242",
                "Certificado": {
                    "Path": "/path/to/certificate. fx",
                    "Senha": "senhaToPfxFileAbove"
                }
            },
            "exemplo-https6": {
                "Url": "https://[::1]:1242",
                "Certificado": {
                    "Path": "/caminho/para/certificado. fx",
                    "senha": "senhaToPfxFileAbove"
                }
            }
        },
        "KnownNetworks": [
            "10. .0.0/8",
            "172.16.0. /12",
            "192.168.0. /16"
        ],
        "PathBase": "/"
    }
}
```

`Endpoints` - Esta é uma coleção de endpoints, cada endpoint tem seu próprio nome único (como `exemplo-http4`) e `Url` propriedade que especifica o endereço de escuta `Protocol://Host:Port`. Por padrão, o ASF escuta nos endereços http IPv4 e IPv6, mas nós adicionamos exemplos https para você usar, se necessário. Você deve declarar apenas os endpoints que você precisa, nós incluímos os 4 exemplos acima para que você possa editá-los mais facilmente.

`Host` aceita `localhost`, um endereço IP fixo da interface na qual ele deve ouvir (IPv4/IPv6), ou `*` valor que liga o servidor http do ASF a todas as interfaces disponíveis. Using other values like `mydomain.com` or `192.168.0.*` acts the same as `*`, there is no IP filtering implemented, therefore be extremely careful when you use `Host` values that allow remote access. Fazer isso vai permitir o acesso à interface IPC do ASF de outros computadores, que pode causar um risco na segurança. Recomendamos fortemente usar `IPCPassword` (e de preferência seu firewall também) **no mínimo** neste caso.

`Conheça Redes` - Esta variável **opcional** especifica endereços de rede que consideramos confiáveis. Por padrão, o ASF é configurado para confiar na interface do loopback (`localhost`, mesmo computador) **apenas**. Esta propriedade é usada de duas maneiras. Primeiramente, se você omitir `IPCPassword`, então permitiremos que somente máquinas de redes conhecidas acessem a API do ASF e negarmos a todos os outros como uma medida de segurança. Em segundo lugar, esta propriedade é crucial para reverter os proxies que acessam o ASF, pois o ASF honrará seus cabeçalhos somente se o servidor proxy reverso for de redes conhecidas. A fiação dos cabeçalhos é crucial no que diz respeito ao mecanismo anti-bruteforce do ASF, em vez de proibir o proxy reverso em caso de problema, vai banir o IP especificado pelo proxy reverso como a fonte da mensagem original. Tenha muito cuidado com as redes especificadas aqui, pois permite um potencial ataque de falsificação de IP e acesso não autorizado caso a máquina confiável esteja comprometida ou incorretamente configurada.

`PathBase` - Este é o caminho base **opcional** que será usado pela interface IPC. O padrão é `/` e não deve ser necessário para modificar a maioria dos casos de uso. Mudar essa propriedade fará com que a interface IPC seja hospedada em um prefixo personalizado, por exemplo `http://localhost:1242/MyPrefix` ao invés de `http://localhost:1242` sozinho. Usar uma configuração personalizada `PathBase` pode ser desejada em combinação com uma configuração específica de proxy reverso, onde você gostaria apenas de proxy uma URL específica, por exemplo `meu domínio. om/ASF` ao invés de todo o domínio `meudominio.com`. Normalmente isso exigiria que você escrevesse uma regra de reescrita para o seu servidor web que mapeasse `meudomínio. om/ASF/Api/X` -> `localhost:1242/Api/X`, mas ao invés disso, você pode definir um `PathBase` personalizado de `/ASF` e obter uma configuração mais fácil do Mito `. om/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

A menos que você realmente precise especificar um caminho base personalizado, é melhor deixá-lo padrão.

## Configurações de exemplo

### Alterando a porta padrão

A configuração a seguir simplesmente muda a porta padrão do ASF que escuta a `1242` para `1337`. Você pode escolher a porta que preferir, mas recomendamos o intervalo `1024-32767` , como outras portas são tipicamente **[registradas](https://en.wikipedia.org/wiki/Registered_port)**, e pode, por exemplo, exigir acesso ao root `` no Linux.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP4": {
                "Url": "http://127. 0,0. :1337"
            },
            "HTTP6": {
                "Url": "http://[::1]:1337"
            }
        }
    }
}
```

---

### Habilitando acesso de todos os IPs

The following config will allow remote access from all sources, therefore you should **ensure that you read and understood our security notice about that**, available above.

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

Se você não precisa de acesso de todas as fontes, mas, por exemplo, apenas da sua LAN, então é uma ideia muito melhor verificar o endereço IP local da máquina que hospeda o ASF, por exemplo `192. 68.0.10` e use-o ao invés de `*` na configuração do exemplo acima. Infelizmente, isso só é possível se o seu endereço em LAN for sempre o mesmo, já que caso contrário, você provavelmente terá resultados mais satisfatórios com `*` e seu próprio firewall além do que permite que apenas as sub-redes locais acessem a porta do ASF.

---

# Autenticação

A interface IPC do ASF por padrão não requer qualquer tipo de autenticação, já que o `IPCPassword` é definido como `null`. No entanto, se `IPCPassword` é definido como qualquer valor não vazio, cada chamada para a API do ASF requer a senha correspondente definida por `IPCPassword`. Se você omitir a autenticação ou inserir a senha errada, você receberá erro `401 - Erro Não autorizado`. Após 5 tentativas de autenticação (senha errada), você será temporariamente bloqueado com o erro `403 - Proibido`.

A autenticação pode ser feita de duas maneiras diferentes.

## `Autenticação` header

Em geral, você deve usar **[endereços de solicitação HTTP](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)**, definindo o campo `Autenticação` com sua senha como um valor. A maneira de fazer isso depende da ferramenta que você está usando para acessar a interface IPC do ASF, por exemplo, se você está usando `curl` então você deve adicionar `-H 'Authentication: MyPassword'` como um parâmetro. Dessa forma, a autenticação é passada nos cabeçalhos da solicitação, onde ela de fato deve ocorrer.

## Parâmetro `senha` na string de consulta

Como alternativa, você pode adicionar o parâmetro `senha` ao final da URL que você está prestes a ligar, por exemplo, chamando `/Api/ASF? assword=MyPassword` em vez de apenas `/Api/ASF`. Essa abordagem é boa o suficiente, mas obviamente ela expõe sua senha aberta, o que não é necessariamente apropriado. Além disso, é um argumento extra na cadeia de consulta, que complica a aparência da URL e a faz sentir que ela é específica da URL, enquanto a senha se aplica a toda a comunicação da API do ASF.

---

Ambas as formas são suportadas e cabe totalmente a você escolher qual você quer escolher. Recomendamos usar cabeçalhos HTTP sempre que possível, já que esse tipo de uso é mais apropriado que uma string de consulta. No entanto, apoiamos a sequência de caracteres de consulta, principalmente por causa de várias limitações relacionadas a solicitar cabeçalhos. Um bom exemplo inclui a falta de cabeçalhos personalizados ao iniciar uma conexão de websocket em javascript (mesmo que seja completamente válido de acordo com a RFC). Nesta situação a string de consulta é a única maneira de autenticar.

---

# Documentação Swagger

Nossa interface IPC, na API do ASF e o ASF-ui, também inclui documentação swagger, que está disponível sob `/swagger` **[URL](http://localhost:1242/swagger)**. A documentação Swagger serve como um intermediário entre a nossa implementação de API e outras ferramentas que a usam (por exemplo, ASF-ui). Ele fornece uma documentação completa e disponibilidade de todos os API endpoints em **[OpenAPI](https://swagger.io/resources/open-api)** especificação que pode ser facilmente consumida por outros projetos, permitindo que você escreva e teste o API do ASF com facilidade.

Além de usar nossa documentação Swagger como uma especificação completa do API do ASF, você também pode usá-lo como uma maneira amigável de executar vários API endpoints, principalmente aqueles que não são implementados pelo ASF-ui. Como nossa documentação Swagger é gerada automaticamente a partir do código ASF, você tem a garantia de que a documentação estará sempre atualizada com os endpoints de API incluídos na sua versão do ASF.

![Documentação Swagger](https://github.com/user-attachments/assets/ce998e08-f5db-46b0-a9e8-e6b69abd94bb)


---

# Perguntas frequentes

### A interface IPC do ASF é segura e segura?

Por padrão o ASF escuta apenas nos endereços `localhost` , o que significa que acessar o IPC do ASF de qualquer outro computador, mas o seu próprio **é impossível**. A menos que você modifique os endpoints padrão, um invasor precisa de um acesso direto ao seu computador para acessar o IPC do ASF, Portanto, está tão seguro quanto pode ser e não há possibilidade de mais ninguém acessá-lo, mesmo da sua própria LAN.

However, if you decide to change default `localhost` bind addresses to something else, then you're supposed to set proper firewall rules **yourself** in order to allow only authorized IPs to access ASF's IPC interface. Além de fazer isso, você precisará configurar `IPCPassword`, já que o ASF se recusará a permitir que outras máquinas acessem o API do ASF sem um, que adiciona outra camada de segurança extra. Você também pode querer rodar a interface IPC do ASF sob um proxy reverso nesse caso, que será mais explicado abaixo.

### Posso acessar o API do ASF através de minhas próprias ferramentas ou userscripts?

Sim, é para isso que a API do ASF foi desenvolvida e você pode usar qualquer coisa capaz de enviar uma solicitação HTTP para acessá-la. Userscripts locais seguem **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** lógica, e permitimos o acesso de todas as origens para elas (`*`), Desde que o `IPCPassword` seja definido, como uma medida de segurança adicional. Isso permite que você execute várias solicitações autenticadas do ASF, sem permitir que scripts potencialmente mal-intencionados façam isso automaticamente (como eles precisariam saber seu `IPCPassword` para fazer isso).

### Posso acessar o IPC do ASF remotamente, de outro computador?

Sim, recomendamos usar um proxy reverso para isso. Dessa forma você pode acessar seu servidor web de um jeito normal, o qual então acessará o IPC do ASF no mesmo computador. Como alternativa, se você não quiser executar um proxy reverso, você pode usar **[configuração personalizada](#enabling-access-from-all-ips)** com a URL apropriada para isso. Por exemplo, se seu computador estiver em uma VPN com o endereço `10.8.0.1` , então você pode definir `http://10.8.0. :1242` URL sendo escutada na configuração do IPC, o que permitiria o acesso IPC de dentro de sua VPN privada, mas não de qualquer outro lugar.

### Posso usar o IPC do ASF atrás de um proxy reverso como Apache ou Nginx?

**Sim**, nosso IPC é totalmente compatível com tal configuração, então você é livre para hospedá-lo também na frente de suas próprias ferramentas para mais segurança e compatibilidade, se quiser. Em geral, o servidor http Kestrel do ASF é muito seguro e não possui nenhum risco ao ser conectado diretamente à internet, mas colocá-lo atrás de um proxy reverso como Apache ou Nginx poderia fornecer funcionalidades extras que não seria possível alcançar de outra forma, tal como proteger a interface do ASF com uma autenticação básica **[básica](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Exemplo de configuração Nginx pode ser encontrado abaixo. Incluímos um bloco `servidor` , embora você esteja interessado principalmente em `local`. Consulte a documentação **[nginx](https://nginx.org/en/docs)** se precisar de mais explicações.

```nginx
server {
    listen *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /path/to/your/fullchain.pem;
    ssl_certificate_key /path/to/your/privkey.pem;

    location ~* /Api/NLog {
        proxy_pass http://127.0.0.1:1242;

        # Only if you need to override default host
#       proxy_set_header Host 127.0.0.1;

        # X-headers should always be specified when proxying requests to ASF
        # They're crucial for proper identification of original IP, allowing ASF to e.g. ban the actual offenders instead of your nginx server
        # Specifying them allows ASF to properly resolve IP addresses of users making requests - making nginx work as a reverse proxy
        # Not specifying them will cause ASF to treat your nginx as the client - nginx will act as a traditional proxy in this case
        # If you're unable to host nginx service on the same machine as ASF, you most likely want to set KnownNetworks appropriately in addition to those
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;

        # We add those 3 extra options for websockets proxying, see https://nginx.org/en/docs/http/websocket.html
        proxy_http_version 1.1;
        proxy_set_header Connection "Upgrade";
        proxy_set_header Upgrade $http_upgrade;
    }

    location / {
        proxy_pass http://127.0.0.1:1242;

        # Only if you need to override default host
#       proxy_set_header Host 127.0.0.1;

        # X-headers should always be specified when proxying requests to ASF
        # They're crucial for proper identification of original IP, allowing ASF to e.g. ban the actual offenders instead of your nginx server
        # Specifying them allows ASF to properly resolve IP addresses of users making requests - making nginx work as a reverse proxy
        # Not specifying them will cause ASF to treat your nginx as the client - nginx will act as a traditional proxy in this case
        # If you're unable to host nginx service on the same machine as ASF, you most likely want to set KnownNetworks appropriately in addition to those
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
    }
}
```

Exemplo de configuração do Apache pode ser encontrado abaixo. Consulte a documentação do apache **[](https://httpd.apache.org/docs)** se precisar de mais explicações.

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerName asf.mydomain.com

        SSLEngine On
        SSLCertificateFile /path/to/your/fullchain.pem
        SSLCertificateKeyFile /path/to/your/privkey.pem

        # TODO: Apache can't do case-insensitive matching properly, so we hardcode two most commonly used cases
        ProxyPass "/api/nlog" "ws://127.0.0.1:1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0.1:1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### Posso acessar a interface IPC através do protocolo HTTPS?

**Sim**, você pode alcançá-lo de duas maneiras diferentes. Uma maneira recomendada seria usar um proxy reverso para isso, onde você pode acessar seu servidor web através de https como de costume, e se conectar através disso com a interface IPC do ASF no mesmo computador. Desta forma, o seu tráfego é totalmente criptografado e você não precisa modificar o IPC para suportar tal configuração.

A segunda forma inclui especificar uma configuração personalizada **[](#custom-configuration)** para a interface IPC do ASF, onde você pode habilitar o endpoint https e fornecer o certificado apropriado diretamente para o nosso servidor http Kestrel. Este modo é recomendado se você não estiver executando nenhum outro servidor web e não quer rodar um exclusivamente para o ASF. Caso contrário, é muito mais fácil alcançar uma configuração satisfatória usando um mecanismo de proxy reverso.

---

### Durante a inicialização do IPC, estou recebendo um erro: `System.IO. OExcepção: Falha ao vincular ao endereço, uma tentativa foi feita de acessar um soquete de uma forma proibida por suas permissões de acesso`

Este erro indica que outra coisa em sua máquina já está usando essa porta ou reservou-a para uso futuro. Esta pode ser você se você estiver tentando executar a segunda instância do ASF no mesmo computador, mas a maioria das vezes é o Windows excluindo a porta `1242` do seu uso, portanto você terá que mover o ASF para outra porta. Para fazer isso, siga **[exemplo de configuração](#changing-default-port)** acima, e simplesmente tentar escolher outro porto, como `12420`.

É claro que você também poderia tentar descobrir o que está bloqueando a porta `1242` do uso do ASF, e remover isso, mas isso geralmente é muito mais problemático do que simplesmente instruir o ASF a usar outra porta, então pularemos a elaboração daqui pra frente.

---

### Por que estou recebendo erro `403 Proibido` quando não estiver usando `IPCPassword`?

O ASF inclui uma medida de segurança adicional que, por padrão, permite apenas a interface loopback (`localhost`, , seu próprio computador) para acessar a API do ASF sem a `IPCPassword` definida na configuração. Isso porque usar o `IPCPassword` deve ser um parâmetro de segurança **mínimo de** definido por todos os que decidem expor ainda mais a interface do ASF.

A mudança foi ditada pelo fato de que uma enorme quantidade de ASFs hospedada globalmente por usuários desconhecidos estavam sendo tomados por intenções maliciosas, geralmente deixar as pessoas sem contas e sem itens nelas. Agora nós poderíamos dizer "eles poderiam ler essa página antes de abrir o ASF para o mundo inteiro", mas em vez disso faz mais sentido não permitir configurações inseguras do ASF por padrão e exigir dos usuários uma ação se eles explicitamente querem permiti-la, sobre a qual elaboramos abaixo.

In particular, you're able to override our decision by specifying the networks which you trust to reach ASF without `IPCPassword` specified, you can set those in `KnownNetworks` property in custom config. However, unless you **really** know what you're doing and fully understand the risks, you should instead use `IPCPassword` as declaring `KnownNetworks` will allow everybody from those networks to access ASF API unconditionally. Nós estamos falando sério, as pessoas já estavam atirando nos pés acreditando que seus proxies reversos e regras iptables estavam seguras, mas não estavam, `IPCPassword` é o primeiro e às vezes o último guardião, se decidir optar por não participar desse mecanismo simples, porém muito eficaz e seguro, você só terá a si mesmo a culpa.