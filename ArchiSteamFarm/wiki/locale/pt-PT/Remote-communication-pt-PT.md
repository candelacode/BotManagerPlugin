# Comunicação remota

Esta seção desenvolve a comunicação remota que o ASF inclui, incluindo mais explicações sobre como se pode influenciá-lo. Embora não consideremos nada abaixo como malicioso ou indesejado, nem estamos legalmente obrigados a divulgá-lo, Queremos que você entenda melhor a funcionalidade do programa, especialmente em relação à sua privacidade e dados compartilhados.

## Steam

O ASF se comunica com a rede Steam (**Servidores[CM](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**assim como **[API Steam](https://steamcommunity.com/dev)**, **[Loja Steam](https://store.steampowered.com)** e **[Comunidade Steam](https://steamcommunity.com)**.

Não é possível desativar qualquer uma das comunicações acima, já que é a base principal do ASF se baseia para fornecer sua funcionalidade básica. Você precisará evitar usar o ASF se não estiver confortável com o que foi acima.

## Grupo Steam

O ASF se comunica com nosso grupo **[Steam](https://steamcommunity.com/groups/archiasf)**. O grupo lhe fornece anúncios, especialmente novas versões, problemas críticos, problemas da Steam e outras coisas que são importantes para manter a comunidade atualizada. Ele também permite que você use nosso suporte técnico, fazendo perguntas, resolvendo problemas, relatando problemas ou sugerindo melhorias. Por padrão, as contas usadas no ASF entrarão automaticamente no grupo após o login.

Você pode optar por não entrar no grupo desativando a opção `SteamGroup` nas configurações do bot **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)**.

## GitHub

O ASF se comunica com a API **[do GitHub](https://api.github.com)** para buscar **[o ASF libera](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** para a funcionalidade de atualização. Isso é feito como parte de atualizações automáticas (se você tiver mantido **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** habilitado), Assim como `atualizar o comando` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Você pode influenciar a comunicação do ASF com o GitHub através da propriedade **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** - configurá-la como `None` resultará em desabilitar toda a funcionalidade de atualização, incluindo a comunicação do GitHub a este respeito.

## Servidor do ASF

O ASF se comunica com **[nosso próprio servidor](https://asf.justarchi.net)** para uma funcionalidade mais avançada. Em particular, isto inclui:
- Verificar as somas de verificação de compilações do ASF baixadas do GitHub em nosso próprio banco de dados independente para garantir que todas as compilações baixadas sejam legítimas (livre de malware, Ataques MITM ou outras manipulações)
- Buscando lista de bots ruins para filtrar se você manteve `FilterBadBots` configuração global habilitada.
- Anunciando seu bot em **[nossa listagem](https://asf.justarchi.net/STM)** se você tiver ativado `SteamTradeMatcher` em **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** e atenda a outros critérios
- Baixando bots atualmente disponíveis para negociar de **[nossa listagem](https://asf.justarchi.net/STM)** se você ativou `MatchActive` em **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** e atende a outros critérios

Como um padrão de segurança, não é possível desativar a verificação do checksum para as compilações do ASF. No entanto, você pode desativar as atualizações automáticas inteiramente se você quiser evitar isso, como descrito acima na seção do GitHub.

Você pode desativar a configuração `FilterBadBots` se você quiser evitar a obtenção da lista do servidor.

Você pode optar por não ser anunciado na listagem, desabilitando a `PublicListing` flag nas configurações do bot **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** configurações. Isso pode ser útil se você gostaria de rodar o bot `SteamTradeMatcher` sem ser anunciado ao mesmo tempo.

Baixar bots da nossa listagem é obrigatório para a configuração `MatchAcativamente` , você precisará desativar essa configuração se não estiver disposto a aceitar isso.