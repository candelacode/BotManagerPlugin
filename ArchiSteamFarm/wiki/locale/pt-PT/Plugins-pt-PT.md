# Plugins

O ASF inclui suporte para plugins personalizados que podem ser carregados durante o tempo de execução. Plugins permitem que você personalize o comportamento do ASF, adicionando comandos personalizados, lógica de troca ou toda a integração com serviços de terceiros e APIs.

Essa página descreve os plugins do ASF da perspectiva do usuário - explicação, uso e coisas do género. Se você quer visualizar a perspectiva do desenvolvedor, mova **[aqui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development)** em vez disso.

---

## Utilização

O ASF carrega os plugins `plugins` localizados na pasta do ASF. É uma prática recomendada (que se torna obrigatória com atualizações automáticas de plugins) para manter um diretório dedicado para cada plugin que você deseja usar, que pode ser baseado a partir do seu nome, como `MyPlugin`. Fazer isso resultará na estrutura final de árvore de `plugins/MyPlugin`. Todos os arquivos binários do plugin devem ser colocados dentro dessa pasta dedicada, e o ASF vai descobrir e usar seu plugin corretamente após reiniciar.

Geralmente os desenvolvedores publicarão seus plugins em forma de um arquivo `zip` com binários dentro, o que significa que você deve descompactar o arquivo zip para o seu próprio subdiretório dedicado dentro do diretório `plugins`.

Se o plugin foi carregado com sucesso, você verá seu nome e versão no log. Você deve consultar os desenvolvedores dos plugins em caso de dúvidas, problemas ou uso relacionados aos plugins que você decidiu usar.

You can find some featured plugins in our **[third-party](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** section.

**Por favor, note que os plugins do ASF podem ser maliciosos**. Você deve sempre garantir que está usando plugins feitos por desenvolvedores em que você pode confiar, mesmo aqueles da seção de terceiros acima. Os desenvolvedores do ASF não podem garantir os benefícios normais do ASF (tal como a falta de malware ou ser livre de VAC) caso você decida usar qualquer plugin personalizado. Você precisa entender que os plugins têm controle total sobre o processo do ASF uma vez carregado, Devido a isso, também não podemos suportar configurações que utilizam plugins personalizados, já que você não está executando o código vanilla do ASF.

---

## Compatibilidade

Dependendo da complexidade do plugin, seu escopo e muitos outros fatores, é inteiramente possível que você precise usar **[genérico](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** variante do ASF, em vez do mais recomendado **[específico para SOs](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)**. Isto porque a variante específica para Sistema Operacional só vem com a funcionalidade principal necessária para o próprio ASF, e seu plugin pode exigir partes que não se enquadrem no escopo principal do ASF, resultando em ser incompatível com compilações específicas para SO cortadas.

Em geral, ao usar plugins de terceiros, recomendamos usar a variante genérica do ASF para máxima compatibilidade. No entanto Nem todos os plugins podem exigi-la - por favor, consulte as informações do seu plugin para descobrir se você precisa usar a variante genérica do ASF ou não.

---


## Atualizações automáticas

O ASF possui um mecanismo embutido para atualizações automáticas de plugins. Para que esse recurso funcione, primeiro de tudo, seu plugin de escolha precisa de **[suporte](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-development#automatic-updates)** esse mecanismo. Se você tiver carregado um plugin que suporte atualizações automáticas, o ASF o informará adequadamente durante a inicialização do plugin, como "plugin foi desativado nas atualizações automáticas" ou "plugin foi registrado e habilitado para atualizações automáticas".

Por padrão, as atualizações automáticas para plugins personalizados estão **desabilitadas**, por motivos de segurança. You can configure automatic updates in the config by using **[`PluginsUpdateList`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatelist)** and/or **[`PluginsUpdateMode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#pluginsupdatemode)**, we recommend to read description of those config properties for more info. Também é legal notar que, como nas atualizações do ASF, você pode decidir manter as atualizações automáticas desabilitadas e então atualizar conforme necessário. manual base, emitindo `updateplugins` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

Ambas as abordagens permitem que você atualize nenhum, alguns ou todos os plugins personalizados que você carregou no processo.