# Localização

O ASF é fornecido pelo serviço Crowdin, que torna possível que todos ajudem a traduzir o ASF em todas as línguas faladas pelo mundo. Para uma explicação mais detalhada sobre como o Crowdin funciona, por favor confira **[introdução do Crowdin](https://support.crowdin.com/crowdin-intro)**.

Se você estiver interessado no que está acontecendo atualmente, você pode verificar **[a atividade do ASF Crowdin](https://crowdin.com/project/archisteamfarm/activity_stream)**.

---

## Escopo

Nossa plataforma suporta a localização do nosso programa principal do ASF, bem como todo o conteúdo localizável que oferecemos junto com ele. Isso inclui especialmente nosso Gerador de Configuração Web da ASF-WebConfigGenerator, ASF-ui, bem como nossa wiki. Tudo isso é possível traduzir através da interface conveniente do Crowdin.

---

## Cadastrando-se

Se você gostaria de ajudar com o ASF, seja traduzindo, revisando ou aprovando as traduções, por favor, inscreva-se na nossa **[página do projeto Crowdin](https://crowdin.com/project/archisteamfarm)**. O cadastro é fácil e totalmente gratuito! Após o login, você pode selecionar os idiomas aos quais você deseja ser designado então vá para os textos do ASF e ajude o resto da comunidade traduzindo o ASF para todos os idiomas mais populares!

---

### Traduzindo

Se o idioma de sua escolha ainda não tiver algumas frases, você pode pegá-las e começar a trabalhar na tradução. Tentámos fazer o nosso melhor em termos de flexibilidade das traduções, Portanto, muitas strings incluem variáveis extras que o ASF fornecerá durante o tempo de execução - essas são colocadas entre colchetes com um número, como `{0}`. Isso permite que você altere o formato padrão da sequência de caracteres do ASF, por exemplo, movendo a variável fornecida pelo ASF em um lugar que satisfaça o seu idioma e a sua tradução, ao invés de ser forçado a um contexto e formato estritos. Isto é especialmente importante em línguas RTL, como o hebraico.

Por exemplo, você poderia ter uma linha como:

> Temos jogos {0} para fazendas.

Mas de acordo com seu idioma, a seguinte frase poderia fazer mais sentido:

> O número de jogos para coletar é igual a {0}.

Ou,

> {0} é o número de jogos para fazendas.

A flexibilidade é proporcionada especialmente para você, então você pode reformular um pouco a frase do ASF para que caia melhor em seu idioma e mover o número fornecido pelo ASF ou outras informações em um lugar que se encaixa em sua tradução (em vez de traduzir cada parte independentemente). Isso melhora a qualidade geral da tradução.

---

### Revisando

Se a frase já foi traduzida por alguém, você pode votar nela. O voto torna possível escolher a melhor variante da tradução, em vez de se manter com a sugestão inicial - isto melhora ainda mais a qualidade global da tradução. Você pode votar em sugestões já disponíveis ou sugerir sua própria tradução, que passará pelo mesmo processo. Eventualmente, a frase final será escolhida com base na sugestão mais votada, ou como uma escolha de revisor selecionado para esse idioma que aprova pessoalmente determinada tradução (com base em seus votos também).

**You do not need approval to see your translated strings in ASF**. Aprovação significa simplesmente que alguém confiável de nós revisou o conteúdo, e escolheu a versão final da tradução. É perfeitamente normal ter traduções não aprovadas pela comunidade, onde você vota pela melhor. Contanto que esteja traduzido, tudo bem! E se você acha que a tradução atual é ruim, você sempre pode votar pela melhor, ou sugerir uma você mesmo.

---

### Prova de leitura

É uma boa ideia ter uma tradução consistente, mesmo que potencialmente pudesse tomar a liberdade do processo de revisão/votação da comunidade explicado acima. Isto ocorre principalmente porque traduções incorretas que não são necessariamente ruins podem ter tantos votos favoráveis que já não é possível sugerir qualquer tradução melhor, mesmo que alguém o tenha.

Se você tem histórico de contribuições no Crowdin ou qualquer outra plataforma de localização/serviço que podemos verificar e assumir confiável, estamos felizes em lhe dar acesso de revisor ao idioma para o qual você está contribuindo, assim você poderá aprovar determinada tradução e torná-la consistente. A prova de leitura não é uma tarefa fácil, especialmente porque o ASF pode ser muito "técnico" de vez em quando e muito difícil de traduzir, mas entendemos que muitas vezes é necessário para uma tradução perfeita. Portanto, se você pode ajudar revisando determinado idioma, **[nos informe](https://crowdin.com/messages/create/13177432/240376)**, mas tenha em mente que você precisará fazer backup do seu pedido com contribuições de localização anteriores que podemos verificar (e. . trabalhando com a localização do ASF no Crowdin ou com qualquer outro projeto). Nós também podemos permitir que usuários mais avançados obtenham a revisão inicial se nós os conhecemos pessoalmente e eles são capazes de cooperar com o resto da comunidade a fim de melhor localizar o ASF para esse idioma.

Regras gerais se aplicam para a prova de leitura - não tenha pressa, ouça seus usuários, trabalhe como um gerente de projeto, resolva problemas, certifique-se de que você está melhorando as coisas e não pior.

---

### Solicitações

Se você tiver um problema com uma tradução específica, por exemplo, você não sabe como traduzir, a tradução aprovada está incorreta, você precisa de um contexto mais específico, ou mesmo, por favor poste um comentário em uma frase específica, e marque-o com [X] problema.

**Please avoid using issue mark if you do not need technical/development explanation or admin action**. Você pode usar comentários para discussões relacionadas a tradução de determinada string, mas o problema só deve ser usado quando você precisa de mais explicações técnicas ou correção de administrador, e normalmente envolve alguém que nem fala o idioma para o qual você está traduzindo, portanto, por favor fique com o inglês ao escrever um comentário de problema (para que possamos entender qual é o problema).

Existem 4 tipos de problemas suportados atualmente:
- Questões gerais - tudo o que não se encaixa em nenhuma das opções abaixo. In general this type **should be avoided**, as if your problem does not fit, then it's very likely **not** a translation issue. Ainda assim, esta opção está disponível para todos os outros casos.
- A tradução atual está errada - isso deve ser usado **apenas** se a tradução já foi pré-aprovada pelo revisor, e você acredita que está errado, por exemplo, ele tem um erro de digitação ou você tem uma sugestão válida de como melhorá-la. Este tipo nunca deve ser usado em traduções que são alimentadas pela comunidade (votar), como neste caso você deve entrar em contato com o usuário de determinada tradução e pedir correção para ele, ou simplesmente votar a favor de uma melhor tradução, como se afirma na seção de revisão. Vamos remover a aprovação da tradução e notificar o revisor responsável pelo idioma para levar em conta seu comentário e verificar novamente.
- Falta de informações contextuais - é isso que você deve usar se não tiver certeza de que parte do ASF está traduzindo, qual é o contexto de uma dada linha ou seu propósito. Esse tipo deve ser usado apenas para o desenvolvimento do ASF, significa que você precisa de assistência técnica, já que você não tem certeza de como você deve traduzir determinada string.
- Erro na frase de origem - deve ser usado somente se você acredita que a frase original (inglês) está incorreta. Muito raro, mas nem todos nós estamos falando inglês nativamente, então sinta-se à vontade para usá-lo se você tiver uma ideia geral de como pode ser melhorado. Alternativamente, já que isso está estritamente relacionado com o desenvolvimento, você pode usar o nosso **[GitHub issues](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** para esse propósito, se você quiser.

---

### Progresso da tradução

Todo idioma tem dois estados de conclusão: tradução e revisão.

Idioma é considerado **traduzido** quando o seu progresso de tradução atinge 100%. Nesse momento, cada string localizável usada pelo ASF tem o significado correto, o que é ótimo. No entanto isso não significa que não há espaço para melhorias - a votação da comunidade é habilitada o tempo todo e você ainda pode sugerir uma tradução melhor para partes já traduzidas, bem como votar nos já existentes. Por favor, note que as línguas totalmente traduzidas ainda podem cair abaixo de 100% quando mudamos as linhas existentes ou adicionamos novas durante o desenvolvimento. Você pode configurar as notificações do Crowdin se quiser receber um e-mail quando isso acontecer.

Os idiomas selecionados podem ter revisores apropriados que validam as traduções e aprovam as versões finais. Este é o último passo da tradução e permite melhorar ainda mais a localização.

O ASF incluirá determinado idioma **assim que possível**, o que significa que ele não precisa ser aprovado, nem mesmo 100% traduzido. As frases que serão usadas são sempre as mais populares em termos de votos, a menos que o revisor escolhido decida outra forma (raramente). Portanto, você pode ver seus esforços sendo incluídos na próxima versão do ASF - nossos sistemas de automação mesclam as traduções do Crowdin para o repositório do ASF diariamente.

---

## Idiomas ausentes

Por padrão o projeto do ASF tem tradução aberta apenas para os 30 idiomas mais falados no mundo. Se você gostaria de adicionar outro (ou um dialeto local para um já disponível), por favor **[deixe-nos saber](https://crowdin.com/messages/create/13177432/240376)** e vamos adicioná-lo o mais rápido possível. Não queremos abrir várias centenas de idiomas diferentes se ninguém vai traduzi-los, é por isso que limitamos para um número justo. Por favor, não hesite em nos contatar se você gostaria de traduzir um idioma não listado, é muito fácil para nós adicionar outro. Apenas certifique-se de que você tem vontade e determinação reais para traduzir o ASF em seu idioma antes de decidir entrar em contato conosco.

Para obter uma lista completa de todos os idiomas disponíveis para os quais o ASF pode ser traduzido, clique **[aqui](https://developer.crowdin.com/language-codes)**.

---

## Pluração

Cada idioma tem suas próprias regras em relação à pluralização. Essas regras podem ser encontradas no **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** que especifica seu número e exatas condições de idioma.

Estamos fazendo o melhor possível para lhe oferecer uma localização flexível e, enquanto possível, isso também incluirá regras de plural. Por exemplo, vamos traduzir a seguinte frase para o Polonês:

> Released {PLURAL:n|{n} month|{n} months} ago

A palavra-chave `PLURAL` aqui é tratada de uma forma especial, já que ela permite incluir todas as formas de plural que seu idioma suporta. Se você dar uma olhada no CLDR, você verá que em inglês existem apenas 2 formas cardinais - "one" e "other". And as you can see above, we have both of those defined - `{n} month` and `{n} months`.

No entanto, nosso idioma polonês inclui 4 - "um", "alguns", "muitos" e "outro". Isto significa que devemos definir todos eles para serem concluídos. Nossas ferramentas de localização já são inteligentes o suficiente para escolher a forma plural apropriada com base nas regras de idioma. Portanto, você só tem que definir todos eles na tradução:

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

Desta forma definimos todas as 4 formas de plural para o idioma polonês, e desde que a nossa biblioteca de localização já sabe as regras exatas. usará corretamente o formulário correto para o número `{n}` fornecido.

Não é obrigatório definir todas as formas de plural usadas pela sua linguagem. Se faltar, nossa biblioteca de localização usará a última forma definida em seu lugar. É uma boa ideia definir todas as formas de plural usadas pelo seu idioma. mas em alguns casos as formas plurais restantes podem ser as mesmas da última, nesse caso não é necessário repeti-las. No nosso exemplo acima era obrigatório, já que a "outra" forma em polonês para meses é "miesiaie" e não "miesiehope, cy" como em "muitos".

---

## Wiki

Nossa plataforma no Crowdin também permite que você localize até mesmo a própria wiki. Esta é uma ferramenta muito poderosa, pois permite que você crie uma documentação completa do ASF em seu idioma nativo. efetivamente resolver o último problema quando se trata da localização do ASF. Juntamente com a tradução do programa e todas as suas partes, isso completa a localização.

A Wiki é um pouco especial nesse aspecto, uma vez que é uma ajuda on-line onde você não precisa se manter muito na frase original. Isso significa que você quer ser o mais natural possível no seu idioma. e entregar significado e ajuda originais - não necessariamente ficar com a string original, palavras usadas e pontuação real. Não tenha medo de reescrever a cadeia de caracteres em algo muito mais natural para o seu idioma. contanto que você mantenha a direção geral e a ajuda incluídas na frase.

---

### Links globais

Nossa plataforma no Crowdin também permite que você adapte o texto original para que ele aponte para os locais novos (traduzidos).

O ASF inclui links quase todas as páginas para facilitar a navegação, bem como a barra lateral à direita. O fato incrível é que você pode editar tudo isso, "consertar" links para apontar para as páginas traduzidas apropriadas para o seu idioma. É preciso ter um pouco de cuidado ao fazer isso, mas é possível.

Por exemplo, o ASF **[página inicial](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)** inclui um texto como:

> Se você é um novo usuário, recomendamos começar com **[configurando o guia](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)**.

Qual é originalmente escrita:

```markdown
Se você é um novo usuário, recomendamos começar com o guia **[configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)**.
```

No Crowdin, a primeira coisa que você deve fazer é ir para as configurações do editor e garantir que as tags HTML estão configuradas como "Show" para você. Isso é muito importante se você decidir localizar a wiki.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Agora, durante a tradução no Crowdin, dependendo da formatação, você verá links do ASF no texto tanto como:

* Sequência de caracteres para traduzir junto com tags HTML (maioria de frases, onde apenas uma parte da frase é um link)
* Sequência única de caracteres para traduzir, com o link incluído no `Oculto Textos` -> `Endereços` (raros, onde toda a seqüência de caracteres é um link, mais comum na barra lateral - aqueles requerem acesso ao revisor para traduzir, tristemente)

No nosso exemplo acima, é o primeiro caso (já que apenas "setuup" é um link), então no Crowdin veremos como:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Independentemente do caso, você deve copiar a frase de origem e traduzi-la normalmente, deixando todo o HTML (se houver) intacto. Este seria um exemplo de tradução para o polonês:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Agora, se o link for um link genérico que aponte para fora da wiki (por exemplo, para a versão mais recente do ASF), você pode deixá-la como está, já que você não quer editá-la. Você pode salvá-lo e seguir em frente.

However, if the link **does** point further inside the wiki, like the one above, you can actually correct it to point to new (localized) location. Você faz isso anexando cuidadosamente `-locale` ao URL de destino na tag `<a>` , como abaixo:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Tenha muito cuidado com isso e certifique-se de que a sua URL de fato existe, já que se você cometer um erro, esse link vai parar de funcionar. Se tiver êxito, você terá uma tradução totalmente funcional com o link apontando para a página traduzida (no nosso caso `Setting-up-pl-PL`).

Fazer os passos acima corretamente traduzirá nosso HTML de volta para o markdown:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

E no texto da wiki:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

Quando nenhum HTML está presente (segundo caso), isto é ainda mais fácil, já que você pode ir para `textos ocultos` -> `endereços`.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

A partir de lá você pode corrigir facilmente o link para apontar para a nova localização, sem se preocupar com HTML:

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Links locais

Na wiki você também encontrará links locais que apontam para determinada seção do documento. Esses links incluem `#` caractere, indicando ao navegador que ele deve ir para essa seção do documento.

Esses são casos especiais, uma vez que esses links se baseiam nos nomes das seções do documento atual. Enquanto para as URLs, temos uma convenção geral de adicionar `-locale` à URL, e funciona em qualquer lugar, nomes de seção serão traduzidos por você e outras pessoas, então você precisa garantir que eles apontem para a localização adequada.

Por exemplo, você pode encontrar um link `#introduction` na nossa configuração **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#introduction)** seção:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Já que vamos traduzir a palavra "Introduction" para "Wprowadzenie" para a língua polonesa, Precisamos corrigir esse link já que ele vai parar de funcionar no momento em que fizermos isso.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

Desta forma, nosso link local continuará funcionando, já que ele agora vai apontar para o nome da seção que estamos usando. Você pode corrigir links dentro de tags HTML exatamente da mesma maneira.

---

### Blocos de código

Be extremely careful when you translate sentences with `<code></code>` blocks inside. Blocos de código indicam nomes ou termos do ASF que não devem ser traduzidos. Por exemplo:

> Isso é especialmente útil se você tem um monte de keys para resgatar e é certo que você atingirá o status <code>RateLimited</code> antes de terminar o lote todo.

Como você pode ver, `RateLimited` palavra aqui está dentro de um bloco de código e indica um código de estado interno do ASF que não deve ser traduzido. Da mesma forma, você não deve traduzir outros blocos de código, tais como nomes de propriedades de configuração (por exemplo, `TradingPreferences`), membros enum (e. . `Estável` e `Pré-Lançar` opções de `UpdateChannel`) e assim por diante.

No entanto, só porque essas palavras não devem ser traduzidas, não significa que você não pode adicionar a tradução apropriada ao lado delas, por exemplo, entre parênteses.

> Ta funkcja jest wyjątkowo użyteczna w przypadku aktywacji dużej ilości kluczy i gwarancji napotkania statusu <code>RateLimited</code> (zbyt częstej aktywacji) przed ukończeniem całej partii.

Como você pode ver acima, nós adicionamos a atividade "zbyt t" ou estacji", literalmente "muitas vezes ativação" ao lado de `RateLimited` para traduzir esse status de forma amigável, ao mesmo tempo mantendo o ASF original que significa que o usuário pode ver durante o uso do programa. Da mesma forma, você pode traduzir/explicar outros casos semelhantes de várias palavras e sentenças.

Se você acredita que algo inapropriado está incluído em um bloco de código. ou que há um texto que não está em um bloco de código, mas deve estar dentro dele, sinta-se à vontade para perguntar em nosso Crowdin criando **[problema](#issues)** apropriado. Isso também serve como um exemplo prático de como usar um link local.

---

## Salão da Fama

Gostaríamos de mostrar nossa eterna gratidão a pessoas que gastaram uma grande parte de seu tempo e vontade para melhorar a localização do ASF. Seus esforços são incríveis e você pode desfrutar de traduções completas, incluindo a wiki, principalmente graças a eles. Como um sinal de apreciação, todas as pessoas listadas aqui são oferecidas acesso gratuito a **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** sob um pedido **[](https://crowdin.com/messages/create/13177432/240376)**.

| Colaborador                                                | Idiomas          |
| ---------------------------------------------------------- | ---------------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, Espanhol |
| **[Camara_Morta](https://crowdin.com/profile/Dead_Sam)**   | Português (BR)   |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | Chinês (CN)      |
| **[DragonTaki](https://crowdin.com/profile/dragontaki)**   | Chinês (TW)      |
| **[Frete](https://crowdin.com/profile/littlefreak)**       | alemão           |
| **[Rizhehvost](https://crowdin.com/profile/Ryzhehvost)**   | Russo, ucraniano |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT, alemão   |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | Chinês (HK)      |

Obrigado a todos por melhorar a qualidade de localização do ASF!