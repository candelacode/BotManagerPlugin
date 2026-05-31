# Plugin SteamTokenDumperPlugin

`SteamTokenDumperPlugin` é o ASF oficial **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** desenvolvido por nós, que permite que você contribua com o projeto **[SteamDB](https://steamdb.info)** compartilhando tokens de pacote, tokens de app e chaves de depósito que sua conta Steam tem acesso. A informação estendida sobre os dados coletados e por que o SteamDB precisa que ela possa ser encontrada na página **[Token Dumper](https://steamdb.info/tokendumper)**. Os dados enviados não incluem nenhuma informação potencialmente sensível e não possuem nenhum risco de segurança/privacidade, como mencionado na descrição acima.

---

## Ativando o plugin

O ASF vem com `SteamTokenDumperPlugin` junto com a versão, mas o plugin em si é desativado por padrão. Você pode habilitar o plugin definindo `SteamTokenDumperPluginHabilitado` propriedade de configuração global do ASF para `true`, na sintaxe JSON:

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

Ao abrir o programa do ASF, o plugin lhe dirá se ele foi ativado com sucesso por meio do mecanismo padrão de registro do ASF. Você também pode ativar o plugin através do nosso gerador de configuração baseado na web.

---

## Detalhes técnicos

Ao habilitar, o plugin usará os bots que você está executando no ASF para coletar dados sob a forma de tokens, tokens de aplicativos e chaves de depósito que seus bots têm acesso. O módulo de coleta de dados inclui rotinas ativas e passivas que devem minimizar a sobrecarga adicional causada pela coleta de dados.

Para atender ao caso de uso planejado, além de coleta de dados explicados acima, rotina de submissão é inicializada como responsável por determinar quais dados devem ser enviados ao SteamDB periodicamente. Esta rotina vai disparar em até `1` hora após o início do ASF, e vai se repetir a cada `24` horas. O plugin fará o seu melhor para minimizar a quantidade de dados que precisam ser enviados, Portanto, é possível que alguns dados que o plugin irá coletar sejam determinados como inúteis para enviar, e, portanto, ignorado (por exemplo, atualização do aplicativo que não altera o token de acesso).

The plugin uses a persistent cache database saved in `config/SteamTokenDumper.cache` location, which serves a similar purpose to `config/ASF.db` for ASF. O arquivo é usado para gravar os dados reunidos e enviados e minimizar a quantidade de trabalho que precisa ser feito através de diferentes execuções do ASF. Remoção do arquivo faz com que o processo seja reiniciado do zero, o que deve ser evitado se possível.

---

## Dado

O ASF inclui o colaborador `steamID` na solicitação, que é determinado como `SteamOwnerID` que você definiu no ASF, ou caso não tenha, o Steam ID do bot, que possui a maioria das licenças. O contribuidor anunciado pode receber algumas vantagens adicionais do SteamDB para ajuda contínua (e. . rank do doador no site), mas isso fica inteiramente a critério do SteamDB.

De qualquer forma, a equipe do SteamDB gostaria de agradecer antecipadamente pela sua ajuda. Os dados enviados permitem que o SteamDB opere, em particular para rastrear informações sobre pacotes, aplicativos e depósitos, o que não seria mais possível sem a sua ajuda.

---

## Comando

O plugin STD vem com um comando extra do ASF, `std [Bots]`, , que permite a você acionar a atualização e a submissão dos bots selecionados sob demanda. Usar o comando não requer uma configuração ativada, que permite que você pule a coleta automática e o envio e controle o processo por você mesmo manualmente. Naturalmente também pode ser executado com configuração habilitada, o que simplesmente acionará os procedimentos normais de coleta e envio antes do esperado.

Recomendamos `!std ASF` para acionar a atualização de todos os bots disponíveis. No entanto, você também pode acioná-lo para os selecionados, se você quiser.

---

## Configuração avançada

Nosso plugin suporta configuração avançada, o que pode ser útil para pessoas que gostariam de ajustar os dados internos à sua preferência.

A configuração avançada tem a seguinte estrutura localizada dentro do `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Enabled": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretPackageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Todas as opções são explicadas abaixo:

### `Ativado`

Tipo `bool` com valor padrão de `false`. Essa propriedade atua como `SteamTokenDumperPluginHabilitado` propriedade de raiz explicada acima, e pode ser usada em vez disso, dedicado a pessoas que prefeririam ter toda a configuração relacionada ao plugin em sua própria estrutura (então provavelmente aqueles que já usam outras propriedades avançadas explicadas abaixo).

---

### `SecretAppIDs`

`ImmutableHashSet<uint>` tipo com valor padrão vazio. Esta propriedade especifica os appIDs `` que o plugin não resolverá e se já estiverem resolvidos, não enviará o token. Este propriedade pode ser útil para pessoas com acesso a informações potencialmente sensíveis sobre itens não publicados, especialmente os desenvolvedores, editores ou testadores beta fechados.

---

### `SecretDepotIDs`

`ImmutableHashSet<uint>` tipo com valor padrão vazio. Esta propriedade especifica `depotIDs` que o plugin não resolverá e se já estiverem resolvidos, não enviará a chave. Este propriedade pode ser útil para pessoas com acesso a informações potencialmente sensíveis sobre itens não publicados, especialmente os desenvolvedores, editores ou testadores beta fechados.

---

### `IDs`

`ImmutableHashSet<uint>` tipo com valor padrão vazio. This property specifies `packageIDs` (also known as `subIDs`) that the plugin won't resolve, and if they're already resolved, won't submit the token for. Este propriedade pode ser útil para pessoas com acesso a informações potencialmente sensíveis sobre itens não publicados, especialmente os desenvolvedores, editores ou testadores beta fechados.

---

### `Pacotes`

`bool` modelo com valor padrão de `true`. Essa propriedade atua de forma muito semelhante ao `SecretPackageIDs` e quando ativado, fará com que pacotes com `EPaymentMethod` de `AutoGrant` sejam ignorados durante a resolução da rotina explicada abaixo. `AutoGrant` método de pagamento é usado pela **[Steamworks](https://partner.steamgames.com)** para conceder automaticamente pacotes em contas de desenvolvedores. Embora isto não seja tão explícito como outras opções `Segredo` , e, portanto, não garante nada (já que você pode ter outros pacotes que não `AutoGrant` que você ainda não queira submeter), deveria ser suficientemente bom para saltar a maioria, se não todos os pacotes secretos. Esta opção é habilitada por padrão, já que pessoas que na verdade têm acesso a pacotes `AutoGrant` quase nunca vão querer vazar isso para o público em geral. e, portanto, usando o valor de `false` é muito situacional.

---

## Mais uma explicação

No nível raiz, toda conta Steam possui um conjunto de pacotes (licenças, assinaturas), que são classificados pelo seu `packageID` (também conhecido como `subID`). Cada pacote pode conter várias aplicações classificadas pela `appID`. Cada aplicativo pode incluir vários depósitos classificados pelo `depotID`.

```text
├── sub/124923
├── app/292030
─── depot/292031
├── depot/378648
├── depot/378648 
 ├─ ...
─── app/378649
── ...
└── ...
```

Nosso plugin inclui duas rotinas que levam em conta itens ignorados - a rotina de resolução e submissão.

A rotina de resolução é responsável por resolver a árvore que você pode ver acima. Ao bloquear os pacotes/apps/depósitos com antecedência, você vai cortar a árvore no lugar do ramo/folha da lista negra, sem a necessidade adicional de especificar as partes restantes dela. No nosso exemplo acima, se `124923` pacote foi ignorado, seja por `SecretPackageIDs` ou `SkipAutoGrantPackages`, e foi o único pacote que você possui vinculado ao appID `292030` , então appID `292030` também não teria solução e, por definição, se não houver outros aplicativos resolvidos que estejam ligados aos depósitos `292031` e `378648` , então eles também não seriam resolvidos. No entanto, tenha em mente que se o plugin já resolveu a árvore, então efetivamente isso só impedirá que determinado item seja atualizado (por exemplo, novos apps adicionados), ele não fará o plugin "esquecer" dos itens existentes que já estavam resolvidos (e. . Aplicativos encontrados nesse pacote antes de você decidir colocar na lista negra). Se você acabou de habilitar algumas opções de ignorar, e gostaria de garantir que o ASF não atravesse a árvore já resolvida, você pode considerar a remoção única de `config/SteamTokenDumper. Arquivo ache` onde o plugin mantém o cache.

A rotina de envio é responsável por enviar tokens de pacotes, tokens de aplicativos e chaves de depósito de itens já resolvidos (pela rotina de resolução acima). Aqui sua lista negra tem efeito imediato, como mesmo que o plugin já tenha resolvido as informações, a rotina de submissão não o enviará para o SteamDB se você a tiver colocado na lista negra, independente de ela ter sido resolvida ou não. Tenha em mente, no entanto, não estamos mais falando sobre a árvore neste momento. a rotina de submissão não sabe se as informações sobre o aplicativo vêm deste ou daquele pacote, então ele só pula informações sobre itens particulares, na lista negra, independentemente da relação que estejam com outros.

Para a maioria dos desenvolvedores e publicações, deve ser suficiente manter o `SkipAutoGrantPackages` ativado, potencialmente fortalecido com `SecretPackageIDs` apenas, pois corta efetivamente a árvore na ramificação inicial e garante que os aplicativos e depósitos incluídos ainda não serão enviados enquanto não houver outros pacotes vinculados ao mesmo aplicativo. If you want to be double sure, in addition to that you can also use `SecretAppIDs`, which will skip the resolve of the app even if there are some other licenses you didn't blacklist linking to it. Usar `SecretDepotIDs` não deve ser necessário, a menos que você tenha uma particular, necessidade específica (como pular apenas um depósito em particular enquanto ainda envia informações sobre pacotes e apps), ou se você quiser adicionar mais uma camada para ficar com o triplo seguro.