# FAQ estendida

Nosso FAQ (Perguntas Frequentes) estendido cobre perguntas e respostas um pouco menos comuns que você pode ter. Para questões mais comuns, por favor visite o nosso **[FAQ básico](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)** em vez disso.

---

### Quem criou o ASF?

O ASF foi criado por **[Archi](https://github.com/JustArchi)** em outubro de 2015. Caso você se pergunte, eu sou um usuário **[Steam](https://steamcommunity.com/profiles/76561198006963719)** do mesmo jeito que você. Além de jogar eu também amo colocar minhas habilidades e determinação para usar, que você pode explorar agora. Não há nenhuma grande empresa envolvida aqui. nenhum time de desenvolvedores e nenhum US$1M de orçamento para cobrir isso - apenas eu, consertando coisas que não estão quebradas.

No entanto, o ASF é um projeto de código aberto e eu não posso dizer o suficiente que eu não sou por trás de tudo o que você vê aqui. Nós temos alguns projetos **[outros](https://github.com/JustArchiNET?q=ASF-)** do ASF que estão sendo desenvolvidos quase exclusivamente por outros desenvolvedores. Até mesmo o núcleo do ASF tem muitos contribuidores **[](https://github.com/JustArchiNET/ArchiSteamFarm/graphs/contributors)** que me ajudaram a tornar isso possível. Além disso, existem vários serviços de terceiros que apoiam o desenvolvimento do ASF, especialmente **[GitHub](https://github.com)**, **[JetBrains](https://www.jetbrains.com)** e **[Crowdin](https://crowdin.com)**. Você também não pode esquecer todas as incríveis bibliotecas e ferramentas que fizeram o ASF acontecer tal como o **[Rider](https://www.jetbrains.com/rider)** que usamos como IDE (amamos adições **[ReSharper](https://www.jetbrains.com/resharper)** ) e especialmente **[SteamKit2](https://github.com/SteamRE/SteamKit)** sem o qual o ASF não existiria. O ASF também não estaria aqui hoje sem meu **[patrocinador](https://github.com/sponsors/JustArchi)** e vários doadores, apoia-me em tudo o que estou fazendo aqui.

Obrigado por ajudar no desenvolvimento do ASF! Você é incrível em :heart:.

---

### Por que o ASF foi criado?

O ASF foi criado com o objetivo principal de ser uma ferramenta totalmente automatizada de coleta Steam para Linux, sem necessidade de dependências externas (como o cliente Steam). Na verdade, este continua a ser o seu principal objectivo e o seu objectivo central. porque meu conceito do ASF não mudou desde então e eu ainda estou usando exatamente da mesma forma que eu o usei em 2015. Claro, houve, realmente, **muito** de mudanças desde então, e estou muito feliz em ver o quão longe o ASF progrediu, A maior parte graças aos seus usuários, porque eu nunca escreveria metade dos recursos apenas para mim.

É bom notar que o ASF nunca foi feito para competir com outros programas semelhantes, especialmente **[Idle Master](https://www.steamidlemaster.com)**, porque o ASF nunca foi projetado para ser um aplicativo de desktop/usuário, e ainda não é hoje. Se você analisar o objetivo primário do ASF descrito acima, então você verá como o Idle Master é **o oposto do**. Enquanto você pode encontrar programas semelhantes aos do ASF hoje, nada era bom o bastante para mim na época (e ainda não é hoje), então eu criei meu próprio software, da maneira que eu queria. Ao longo do tempo os usuários migraram para o ASF principalmente devido à robustez, estabilidade e segurança. mas também todas as funcionalidades que eu desenvolvi ao longo de todos esses anos. Hoje, o ASF está melhor do que nunca.

---

### Ok, onde está a pegadinha? O que você ganha compartilhando o ASF?

Não há captura, Eu criei o ASF **para mim mesmo** e o compartilhei com o resto da comunidade na esperança dele ser útil. Exatamente a mesma coisa aconteceu em 1991, quando Linus Torvalds **[compartilhou seu primeiro kernel do Linux](https://groups.google.com/forum/#!msg/comp.os.Minix/dlNtH7RRrGA/SwRavCzVE7gJ)** com o resto do mundo. Não há malware, mineração de dados, mineração de criptomoedas ou qualquer outra atividade oculta que gerasse qualquer benefício monetário para mim. O projeto ASF é suportado inteiramente por doações não obrigatórias enviadas por usuários contentes como você. Você pode usar o ASF exatamente da mesma forma que eu o uso, e se você gostar, você sempre pode me comprar um café, mostrando sua gratidão pelo que estou fazendo.

Também estou usando o ASF como um exemplo perfeito de um projeto moderno em C# que sempre busca a perfeição e as melhores práticas, seja com tecnologia, gestão de projetos ou com o próprio código. É minha definição de "fazer a coisa certa", Então, se por acaso você conseguir aprender algo útil com o meu projeto, então isso me deixará mais feliz.

---

### Logo após abrir o ASF eu perdi todas as minhas contas/itens/amigos/(...)!

Em termos estatísticos, independentemente do quão triste seja, É garantido que logo após o lançamento do ASF haverá pelo menos um cara que morrerá em um acidente de carro. A diferença é que ninguém sane vai culpar o ASF por causá-lo, mas por algum motivo há pessoas que vão acusar o ASF da mesma coisa só porque aconteceu com suas contas Steam. É claro que podemos entender o raciocínio disso depois que o ASF opera dentro da plataforma Steam, então as pessoas acusarão naturalmente o ASF de tudo o que aconteceu com as propriedades relacionadas ao Steam, independentemente da falta de qualquer evidência de que o software que eles executaram está mesmo ligado remotamente a isso.

ASF, como indicado em **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#is-it-safe)** bem como **[pergunta acima](#ok-where-is-the-catch-what-do-you-gain-from-sharing-asf)**, está livre de malware, spyware, mineração de dados e qualquer outra atividade potencialmente indesejada, **especialmente** submissão de seus detalhes confidenciais do Steam ou assumindo sua propriedade digital. If something like this has happened to you, we can only say that we're sorry for your loss and recommend you to contact **[Steam support](https://help.steampowered.com)** which hopefully will assist you in the recovery process - because we're not responsible for what happened to you in any way and our conscience is clear. Se você acredita no contrário, essa é a sua decisão, não faz sentido de se alongar mais, se os recursos acima fornecendo formas objetivas e verificáveis de confirmar a nossa declaração não convenceram você, então não é nada que escrevamos aqui mesmo assim.

No entanto, o acima não significa que **suas ações** feitas sem o senso comum com o ASF não pode contribuir para um problema de segurança. Por exemplo, você pode ignorar nossas diretrizes de segurança, expor a interface do ASF **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** a toda a internet, e depois fique surpreso com o facto de alguém ter entrado e roubado você de todos os itens. Pessoas fazem isso o tempo todo, eles acham que se não há nenhum domínio ou qualquer conexão com seu endereço IP então ninguém terá certeza de descobrir sua instância do ASF. Bem como você leu, há **milhares de bots** se não for mais automatizado navegando pela web, incluindo endereços IP aleatórios, procurando por vulnerabilidades para descobrir, e o ASF como um programa bem popular é também um destino desses. Já tínhamos pessoas suficientes que foram "pirateadas" através de sua própria estupidez desse jeito, então tente aprender com seus erros e ser mais inteligente em vez de se juntar a eles.

O mesmo vale para a segurança do seu PC. Sim, ter malware no seu PC ruína todos os aspectos de segurança do ASF, já que ele pode ler detalhes confidenciais de arquivos de configuração do ASF ou processar memória e até mesmo influenciar o programa a fazer coisas que ele não faria de outra forma. Não, a última rachadura que você obteve de fonte duvidosa não foi uma "falsa positiva" como alguém disse a você, é uma das maneiras mais efetivas de ganhar controle sobre o PC de alguém. as pessoas vão se infectar e elas vão até seguir as instruções de como fascinante.

Será que usar o ASF é completamente seguro e livre de todos os riscos? Não, nós seríamos hipócritas afirmando isso, já que **todos os softwares** têm seus problemas orientados para a segurança. Contrary to what a lot of companies are doing, we're trying to be as transparent as possible in our **[security advisories](https://github.com/JustArchiNET/ArchiSteamFarm/security/advisories)** and as soon as we find out even a *hypothetical* situation where ASF could contribute in any way to a potentially unwanted from security perspective situation, we announce it immediately. Foi isso que aconteceu com **[CVE-2021-32794](https://github.com/JustArchiNET/ArchiSteamFarm/security/advisories/GHSA-wxx4-66c2-vj2v)** por exemplo, embora o ASF não tenha qualquer falha de segurança, mas sim um bug que poderia levar ao usuário acidentalmente a criar um.

As of today, there are no known, unpatched security flaws in ASF, and as the program is used by more and more people out of which both **[white hats](https://en.wikipedia.org/wiki/White_hat_(computer_security))** as well as **[black hats](https://en.wikipedia.org/wiki/Black_hat_(computer_security))** analyze its source code, the overall trust factor only increases with time, as the number of security flaws to find out is finite, and ASF as a program that focuses first and foremost on its security, definitely isn't making it easy for finding one. Independentemente de nossas melhores intenções, ainda recomendamos manter a cabeça fria e ter sempre cuidado com potenciais ameaças à segurança, também quem vem do uso do ASF.

---

### Como faço para verificar se os arquivos baixados são genuínos?

Como parte de nossas versões no GitHub, utilizamos um processo de verificação muito semelhante ao usado por **[Debian](https://www.debian.org/CD/verify)**. Em cada lançamento oficial, além de `zip` construir ativos, você pode encontrar os arquivos `SHA512SUMS` e `SHA512SUMS.sign`. Faça o download deles para fins de verificação, junto com os arquivos `zip` à sua escolha.

Primeiro, você deve usar o arquivo `SHA512SUMS` para verificar se o arquivo `SHA-512` da soma de verificação do arquivo `zip` selecionado corresponde ao arquivo que nós mesmos calculamos. No Linux, você pode usar a utilidade `sha512sum` para esse fim.


```
$ sha512sum -c --ignore-missing SHA512SUMS
ASF-linux-x64.zip: OK
```

No Windows, podemos fazer isso através do powershell, embora tenha que verificar manualmente com o `SHA512SUMS`:

```
PS > Get-Content SHA512SUMS ├Select-String -Pattern ASF-linux-x64.zip

f605e573cc5e044dd6fadbc44f6643829d11360a2c6e4915b0c0b8f5227bc2a257568a014d3a2c0612fa73907641d0cea455138d2e5a97186a0b417abad45ed9 ASF-linux-x64.zip


PS > Get-FileHash -Algm SHA512 -Path ASF-linux-x64. ip

Algoritmo Hash Path
--------- ---- ----
SHA512 F605E573CC5E044D6FADBC44F6643829D11360A2C6E4915B0C0B8F5227BC2A2575... ASF-linux-x64.zip
```

Desta forma, garantimos que o que foi escrito na `SHA512SUMS` corresponda aos arquivos resultantes e não foram adulterados. No entanto, ainda não prova que o arquivo `SHA512SUMS` que você marcou realmente vem de nós. Há duas maneiras de verificar isso.

A primeira e também a que o ASF usa para o processo de atualização automática, está fazendo uma chamada para o nosso servidor de backend visitando `https://asf. ustArchi. et/Api/Checksum/{Version}/{Variant}` URL, substituindo `{Version}` pelo número da versão do ASF, como `6. .4.3`e `{Variant}` com sua variante selecionada do ASF, tais como `genérico` ou `linux-x64`. Você pode encontrar o checksum na resposta JSON, que você deve comparar com `SHA512SUMS` e/ou o artefato de arquivo zip do ASF. Nosso servidor fornece as somas de verificação somente para a versão **[estável](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** e **[pré-lançamento](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** do ASF, como apenas aqueles ASFs existentes irão considerar atualizar.

```json
{
  "Result": "f605e573cc5e044dd6fadbc44f6643829d11360a2c6e4915b0c0b8f5227bc2a257568a014d3a2c0612fa73907641d0cea455138d2e5a97186a0b417abad45ed9",
  "Message": "OK",
  "Success": true
}
```

A segunda forma inclui o uso de um pacote `SHA512SUMS.sign` que contém assinatura PGP digital que prova a autenticidade da `SHA512SUMS`. Desde que artefatos de compilação bem como assinatura é gerada como parte do processo de compilação. não garante integridade caso o GitHub seja comprometido (é por isso que utilizamos nosso servidor independente para fins de verificação), mas é suficiente se você fez o download do ASF de uma fonte desconhecida e você quer garantir que é um artefato válido produzido pelo nosso processo de lançamento no GitHub, em vez de garantir que o GitHub não foi comprometido completamente.

Podemos usar o utilitário `gpg` para esse propósito, ambos no **[Linux](https://gnupg.org/download/index.html)** e **[Windows](https://gpg4win.org)** (mude o comando `gpg` para `gpg. Enxame` no Windows).

```
$ gpg --verificar SHA512SUMS. ign SHA512SUMS
gpg: Assinatura fez Mon 02 de agosto 2021 00:34:18 CEST
gpg: usando a chave EDDSA 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Não é possível verificar a assinatura: Nenhuma chave pública
```

Como você pode ver, o arquivo de fato possui uma assinatura válida, mas de origem desconhecida. Você precisará importar a chave pública **[ArchiBot](https://raw.githubusercontent.com/JustArchi-ArchiBot/JustArchi-ArchiBot/main/ArchiBot_public.asc)** que assinamos as somas `SHA-512` para validação completa.

```
$ curl https://raw.githubusercontent.com/JustArchi-ArchiBot/JustArchi-ArchiBot/main/ArchiBot_public.asc -o ArchiBot_public.asc
$ gpg --import ArchiBot_public.asc
gpg: /home/archi/. nupg/trustdb. pg: trustdb criado
gpg: key A3D181DF2D554CCF: chave pública "ArchiBot <ArchiBot@JustArchi.net>" importada
gpg: Número total processado: 1
gpg: importado: 1

```

Finalmente, você pode verificar o arquivo `SHA512SUMS` novamente:

```
$ gpg --verificar SHA512SUMS. ign SHA512SUMS
gpg: Assinatura fez Mon 02 de agosto 2021 00:34:18 CEST
gpg: usando a chave EDDSA 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Boa assinatura de "ArchiBot <ArchiBot@JustArchi.net>" [unknown]
gpg: AVIS: Esta chave não é certificada com uma assinatura confiável!
gpg: Não há nenhuma indicação de que a assinatura pertence ao proprietário.
Impressão digital de chave primária: 224D A6DB 47A3 935B DCC3 BE17 A3D1 81DF 2D55 4CCF
```

Isto confirmou que o `SHA512SUMS. ign` contém uma assinatura válida da nossa `224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF` chave para `SHA512SUMS` arquivo que você verificou novamente.

Poderão interrogar-se de onde vem o último aviso. Você importou com sucesso nossa chave, mas ainda não decidiu confiar nela. Embora isto não seja obrigatório, também podemos cobri-lo. Normalmente isso inclui verificação através de um canal diferente (por exemplo, chamada telefônica, SMS) que a chave é válida e, em seguida, assinando a chave com a sua própria confiança nela. Por exemplo, você pode considerar esta entrada no wiki como tal (muito fraco) canal diferente, já que a chave original vem do perfil de **[Archibot](https://github.com/JustArchi-ArchiBot)**. De qualquer forma, partimos do princípio de que você tem bastante confiança como está.

Primeiramente, **[gera uma chave privada para si mesmo](https://help.ubuntu.com/community/GnuPrivacyGuardHowto#Generating_an_OpenPGP_Key)**, se você ainda não tem uma. Nós vamos usar `--quick-gen-key` como um exemplo rápido.

```
$ gpg --batch --passphrase '' --quick-gen-key "$(whoami)"
gpg: /home/archi/.gnupg/trustdb. pg: trustdb criou
gpg: chave E4E763905FAD148B marcada como última confiabilidade de
gpg: diretório '/home/archi/. nupg/openpg-revocs.d' criou
gpg: certificado de revogação armazenado como '/home/archi/.gnupg/openpgp-revocs.d/8E5D685F423A584569686675E4E763905FAD148B.rev'
```

Agora você pode assinar nossa chave com a sua para confiá-lo:

```
$ gpg --sign-key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF

pub ed25519/A3D181DF2D554CCF
     criado: 2021-05-22 expira em: Nunca uso: SC
     trust: validação desconhecida: desconhecido
sub cv25519/E527A892E05B2F38
     created: 2021-05-22 expira: nunca uso: E
[ unknown] ArchiBot <ArchiBot@JustArchi.net>


pub ed25519/A3D181DF2D554CCF
     created: 2021-05-22 expire: Nunca usar: SC
     trust: validação desconhecida: desconhecida: desconhecida: desconhecida
 impressão digital de chave primária: 224D A6DB 47A3 935B DCC3 BE17 A3D1 81DF 2D55 4CCF

     ArchiBot <ArchiBot@JustArchi.net>

Tem certeza de que deseja assinar essa chave com sua "arquivo"
(E4E763905FAD148B)

Sinal? (S/N) y
```

E feito, depois de confiar na nossa chave, a `gpg` não deve mais exibir o aviso ao verificar:

```
$ gpg --verificar SHA512SUMS. ign SHA512SUMS
gpg: Assinatura fez Mon 02 de agosto 2021 00:34:18 CEST
gpg: usando a chave EDDSA 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Boa assinatura de "ArchiBot <ArchiBot@JustArchi.net>" [full]
```

Observe o indicador `[unknown]` que está mudando para `[full]` depois que você assinou nossa chave com a sua.

Parabéns, você verificou que ninguém alterou a versão que você baixou! 👍

---

### O dia 1 de abril e o idioma do ASF mudaram para algo estranho, o que está acontecendo?

format@@0 CONGRATULASHUNS ON DISCOVERIN R APRIL FOOLS EASTR EGG! Se você não definiu a opção `CurrentCulture` personalizada, então ASF em abril, o primeiro usará o idioma **[LOLcat](https://en.wikipedia.org/wiki/Lolcat)** em vez do idioma do seu sistema. Se por acaso você deseja desativar esse comportamento, Você pode simplesmente definir `CurrentCulture` para a localidade que você gostaria de usar em vez disso. Também é legal notar que você pode habilitar nosso ovo de Páscoa incondicionalmente, definindo seu `CurrentCulture` para `qps-Ploc`.