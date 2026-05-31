# Argumentos de linha de comando

O ASF inclui suporte para vários argumentos de linha de comando que podem afetar o tempo de execução do programa. Eles podem ser usados por usuários avançados para especificar como o programa deve ser executado. Em comparação com o modo padrão de arquivo de configuração `ASF.json` , argumentos de linha de comando são usados para inicialização do núcleo (por exemplo, `--path`), configurações específicas de plataforma (por exemplo, `--system-required`) ou dados confidenciais (por exemplo, `--cryptkey`).

---

## Utilização

O uso depende do seu sistema operacional e da versão do ASF.

Genérico:

```shell
dotnet ArchiSteamFarm.dll --argument --otherOne
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --otherOne
```

Argumentos de linha de comando também são suportados em scripts auxiliares genéricos como `ArchiSteamFarm.cmd` ou `ArchiSteamFarm.sh`. Além disso, você também pode usar uma propriedade de ambiente `ASF_ARGS` , como indicado em nossas seções **[de gerenciamento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** e **docker[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)**.

Se seu argumento inclui espaços, não se esqueça de citar isto. Esses dois estão errados:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Não funciona!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Não funciona!
```

No entanto, esses dois estão completamente corretos:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Argumentos

`--cryptkey <key>` or `--cryptkey=<key>` - will start ASF with custom cryptographic key of `<key>` value. Esta opção afeta **[segurança](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** e fará com que o ASF use a chave `<key>` personalizada em vez de uma chave codificada no executável. Uma vez que essa propriedade afeta a chave de criptografia padrão (para fins de criptografia), bem como sal (para fins de hashing), Tenha em mente que tudo criptografado/hash com essa chave exigirá que ela seja ativado toda vez que o ASF for executado.

Não há nenhuma exigência em `<key>` comprimento ou caracteres, mas, por razões de segurança, recomendamos que você escolha uma senha suficientemente longa de entre ela. . caracteres aleatórios, por exemplo, usando `tr -dc A-Za-z0-9 < /dev/urandom ├head -c 32; comando echo` no Linux.

É bom mencionar que também existem duas outras maneiras de fornecer esse detalhe: `--cryptkey-file` e `--input-cryptkey`.

Devido à natureza desta propriedade, também é possível definir a cryptkey declarando a variável de ambiente `ASF_CRYPTKEY` , que pode ser mais adequado para pessoas que queiram evitar pormenores sensíveis nos argumentos do processo.

---

`--cryptkey-file <path>` or `--cryptkey-file=<path>` - iniciará o ASF com chave de criptografia personalizada lida pelo arquivo `<path>`. Isso serve o mesmo propósito que o `--cryptkey <key>` explicado acima, apenas o mecanismo difere, como esta propriedade irá ler `<key>` no lugar fornecido `<path>`. Se você estiver usando isso junto com `--path`, considere o fato de que o caminho relativo será diferente dependendo da ordem dos argumentos, i. . se você troca `--path` antes ou depois `--cryptkey-file`.

Devido à natureza desta propriedade, também é possível definir o arquivo de criptografia, declarando a variável de ambiente `ASF_CRYPTKEY_FILE` , que pode ser mais adequado para pessoas que queiram evitar pormenores sensíveis nos argumentos do processo.

---

`--ignore-unported-environment` - fará com que o ASF ignore problemas relacionados à execução em ambiente não suportado. que normalmente é sinalizado com um erro e uma saída forçada. O ambiente não suportado inclui, por exemplo, rodando `win-x64` específico para criação em `linux-x64`. Enquanto esse sinalizador permitirá que o ASF tente executar tais cenários, seja avisado de que nós não suportamos oficialmente aqueles e você está forçando o ASF a fazê-lo totalmente **por sua própria conta e risco**. It's important to point out that **all** of the unsupported environment scenarios **can be corrected**. Recomendamos vivamente que se resolvam os problemas pendentes, em vez de declararem este argumento.

---

`--input-cryptkey` - fará o ASF perguntar sobre o `--cryptkey` durante a inicialização. Essa opção pode ser útil para você se ao invés de fornecer criptkey, seja em variáveis de ambiente ou em um arquivo, Você preferiria não tê-lo salvo em nenhum lugar e, em vez disso, colocá-lo manualmente cada vez que o ASF for executado.

---

`--minimized` - minimizará a janela de console do ASF logo após a inicialização. Útil principalmente em cenários de início automático, mas também pode ser usado fora deles. Esta opção exige um apoio adequado ao ambiente - pode não funcionar adequadamente em todos os cenários possíveis.

---

`--network-group <group>` or `--network-group=<group>` - will cause ASF to init its limiters with a custom network group of `<group>` value. Esta opção afeta a execução do ASF em **[várias instâncias](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** assinando que determinada instância é dependente apenas de instâncias que compartilham o mesmo grupo de rede, e independente do resto. Normalmente você vai querer usar essa propriedade somente se você estiver roteando pedidos do ASF através de um mecanismo personalizado (por exemplo, endereços IP diferentes) e você deseja definir grupos de rede você mesmo, sem depender do ASF para fazer isso automaticamente (que atualmente inclui levar em conta apenas `WebProxy`). Keep in mind that when using a custom network group, this is unique identifier within the local machine, and ASF will not take into account any other details, such as `WebProxy` value, allowing you to e.g. start two instances with different `WebProxy` values which are still dependent on each other.

Devido à natureza desta propriedade, também é possível definir o valor declarando a variável de ambiente `ASF_NETWORK_GROUP` , que pode ser mais adequado para pessoas que queiram evitar pormenores sensíveis nos argumentos do processo.

---

`--no-config-migrate` - por padrão o ASF migrará automaticamente os seus arquivos de configuração para a sintaxe mais recente. A migração inclui a conversão de propriedades obsoletas para as mais recentes, removendo propriedades com valores padrão (já que elas não têm efeito), Além de limpar o arquivo em geral (corrigindo indentação e coisas do tipo). Essa é quase sempre uma boa ideia, mas você pode ter uma situação em particular onde você prefere que o ASF nunca substitua os arquivos de configuração automaticamente. Por exemplo, você pode querer `chmod 400` seus arquivos de configuração (somente permissão de leitura para o proprietário) ou colocar `chattr +i` sobre eles, em resultado negando acesso de escrita para todos. . como medida de segurança. Geralmente recomendamos manter a migração de configuração ativada, mas se você tem um motivo particular para desativá-lo e preferiria que o ASF não fizesse isso, você pode usar este interruptor para atingir essa finalidade. No entanto, tenha em mente que fornecer as configurações corretas para o ASF será de agora em diante sua nova responsabilidade especialmente no que se refere às depreciações e refatorações de propriedades em futuras versões do ASF.

---

`--no-config-watch` - por padrão o ASF configura uma pasta `FileSystemWatcher` através do seu arquivo `config` para ouvir os eventos relacionados a mudanças de arquivo para que possa adaptar-se de forma interactiva aos mesmos. Por exemplo, isso inclui parar os bots ao excluir configuração, reiniciar o bot quando a configuração for alterada, ou carregando chaves para **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** quando você as soltar no diretório `config`. Essa opção permite que você desative tal comportamento, o que fará com que o ASF ignore completamente todas as mudanças na pasta `config` , exige que você faça tais ações manualmente, se considerado apropriado (que geralmente significa reiniciar o processo). Recomendamos manter os eventos configurativos ativados mas se você tem um motivo particular para desativá-los e preferiria que o ASF não fizesse isso, você pode usar este interruptor para atingir essa finalidade.

---

`--no-restart` - by default ASF follows **[`AutoRestart`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#autorestart)** config property, which you can use for specifying whether restart is allowed when required. Algumas soluções que fornecemos são responsáveis pela gestão dos processos e são explicitamente incompatíveis com a função de reinício automático do ASF, tal como executar o ASF em `docker` ou `systemd`, já que eles requerem o processo apenas para sair, já que é sua responsabilidade reiniciá-lo depois, se for considerado apropriado. Uma vez que a edição de configuração arbitrária é indesejada da experiência do usuário, essa opção simplesmente substitui a sua propriedade de configuração `AutoRestart` ao inicializá-la explicitamente para `false`, mesmo se você tiver especificado o contrário nas configurações. Graças a isso, o ASF pode ser informado antecipadamente sobre a execução em tal ambiente, sem o requisito de fornecer um arquivo de configuração `AutoRestart: false` compatível.

In addition to the above, `--no-restart`, in contrary to `AutoRestart: false`, will also forbid you from using `restart` command or otherwise issuing ASF process to restart, since the switch explicitly states it's not compatible with such setup, while `AutoRestart` property only specifies default behaviour.

Normalmente você pode (e deve) controlar o comportamento explicado aqui no arquivo de configuração, embora você esteja executando o ASF dentro de um script personalizado ou outro ambiente similar. você também pode querer usar essa opção que vai proibir o ASF de reiniciar por conta própria.

---

`--no-steam-parental-generation` - por padrão o ASF tentará gerar automaticamente os PINs do Steam, conforme descrito na propriedade de configuração **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)**. No entanto, uma vez que isso pode exigir uma quantidade excessiva de recursos do SO, esta opção permite que você desative esse comportamento, o que fará com que o ASF pule a geração automática e vá direto para pedir PIN ao usuário, em vez disso, que é o que normalmente só aconteceria se a geração automática falhasse. Geralmente recomendamos manter a geração ativada. mas se você tem um motivo particular para desativá-lo e preferiria que o ASF não fizesse isso, você pode usar este interruptor para atingir essa finalidade.

---

`--path <path>` or `--path=<path>` - o ASF sempre navega até a sua própria pasta na inicialização. Ao especificar esse argumento, o ASF navegará até determinado diretório após a inicialização, o que permite que você use um caminho personalizado para vários componentes da aplicação (incluindo `config`, `logs`, `plugins` e `www` diretórios, bem como `NLog. onfig` arquivo), sem a necessidade de duplicar o binário no mesmo lugar. Pode ser especialmente útil se você quiser separar os binários das configurações atuais, como acontece em pacotes do tipo Linux - desta forma você pode usar um executável (atualizado) com várias configurações diferentes. O caminho pode ser relativo de acordo com o local atual do executável do ASF ou absoluto. Tenha em mente que este comando aponta para uma nova "casa do ASF" - a pasta que tem a mesma estrutura do ASF original, com o diretório `config` dentro, veja abaixo o exemplo para obter explicação.

Devido à natureza desta propriedade, também é possível definir o caminho esperado declarando a variável de ambiente `ASF_PATH` , que pode ser mais adequado para pessoas que queiram evitar pormenores sensíveis nos argumentos do processo.

Se você está pensando em usar esse argumento de linha de comando para executar várias instâncias do ASF, Recomendamos ler nossa página de gerenciamento **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** desta maneira.

Exemplos:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Caminho absoluto
dotnet /opt/ASF/ArchiSteamFarm.dll --path .. TargetDirectory # Caminho relativo também funciona
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # Mesma como variável env
```

```text
── 📁 /opt
├── 📁 ASF
─── ⚙️ ArchiSteamFarm.dll
── ...
├── 📁 TargetDirectory
─── 📁 config
── 📁 logs (gerados)
├── 📁 plugins (opcional)
├── 📁 plugins (opcional) 📁 www (opcional)
── 📄 log. xt (gerado)
── 📄 NLog.config (opcional)
── ...
```

---

`--service` - esta opção é usada principalmente pelo nosso serviço `systemd` e força `Headless` of `true`. A menos que você tenha uma necessidade específica, você deve configurar `Headless` propriedade diretamente na sua configuração. Essa opção está aqui para que nosso serviço `systemd` não precise tocar na configuração global para adaptá-la ao seu próprio ambiente. Claro, se você tem uma necessidade semelhante você também pode fazer uso deste interruptor (caso contrário é melhor com a propriedade de configuração global).

---

`--system-required` - declarar essa opção fará com que o ASF tente sinalizar ao sistema operacional que o processo precisa que o sistema esteja ativo e rode durante toda a vida. Isso pode ser especialmente útil ao coletar no seu PC ou laptop durante a noite, já que o ASF será capaz de manter seu sistema acordado enquanto está em execução. Este recurso é atualmente suportado no Linux e Windows.

No Linux, você precisará funcionar corretamente **[dbus](https://en.wikipedia.org/wiki/D-Bus)** com login daemon que suporta **[`Inhibit()`](https://systemd.io/INHIBITOR_LOCKS/)** função. Dois daemons mais populares, o `systemd` bem como o `elogind`, estão confirmados para suportar isso. A maioria dos ambientes de área de trabalho (como Gnome ou KDE) deve funcionar fora da caixa, já que eles já dependem dessa funcionalidade para suas próprias necessidades.

Não há quaisquer requisitos especiais para o Windows, o sistema deve funcionar fora da caixa.