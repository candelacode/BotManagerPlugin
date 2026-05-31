# Segurança

## Criptografia

Atualmente o ASF suporta os seguintes métodos de criptografia como definição de `ECryptoMethod`:

| Valor | Nome                        |
| ----- | --------------------------- |
| 0     | PlainText                   |
| 1     | AES                         |
| 2     | ProtectedDataForCurrentUser |
| 3     | EnvironmentVariable         |
| 4     | File                        |

A descrição e comparação exatas estão disponíveis abaixo.

### Configuração

Para gerar uma senha criptografada, por exemplo, para usar como `SteamPassword` você deve executar o **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)** `encrypt` com o método de criptografia que você escolheu e sua senha original em texto simples. Depois, coloque a string criptografada que você recebeu na propriedade de configuração `SteamPassword` do bot, e mude o campo `PasswordFormat` para o valor que corresponda ao método de criptografia que você escolheu. Alguns formatos não solicitam o comando `encrypt`, por exemplo, `EnvironmentVariable` ou `File`, apenas coloque o caminho apropriado para eles.

---

### `PlainText`

É a forma mais simples e menos segura de salvar uma senha, definido com o valor `0` em `ECryptoMethod`. O ASF espera que a string seja um texto simples - uma senha em sua forma direta. É o método mais fácil de usar, e 100% compatível com todas as configurações, entretanto, sendo a maneira padrão de armazenar segredos, ela é totalmente insegura para um armazenamento seguro.

---

### `AES`

Considerado seguro pelos padrões de hoje, a forma de armazenamento **[AES](https://pt.wikipedia.org/wiki/Advanced_Encryption_Standard)** é definida como `1` em `ECryptoMethod`. O ASF espera que a string seja uma sequência de caracteres codificada em **[base64](https://pt.wikipedia.org/wiki/Base64)**, resultando em um array de bytes criptografado com AES após a tradução, que então deve ser descriptografado usando o **[vetor de inicialização](https://pt.wikipedia.org/wiki/Vetor_de_inicializa%C3%A7%C3%A3o)** incluído e a chave de criptografia do ASF.

O método acima garante segurança, desde que, o invasor não conheça a chave de criptografia que o ASF esteja usando para descriptografia e criptografia de senhas. O ASF permite que você especifique a chave através do **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-pt-BR)** `--cryptkey`, que você deve usar para segurança máxima. Se você decidir omiti-lo, o ASF usará sua própria chave que é **conhecida** e codificada no aplicativo, o que significa que qualquer pessoa pode reverter a criptografia do ASF e obter a senha descriptografada. Ainda requer algum esforço e não é tão fácil de fazer, mas é possível, por isso você deve quase sempre usar a criptografia `AES` com sua própria `--cryptkey` que é mantida em segredo. O método AES usado no ASF fornece segurança que deve ser satisfatória e é um equilíbrio entre a simplicidade de `PlainText` e a complexidade de `ProtectedDataForCurrentUser`, mas é altamente recomendável usá-lo com um `--cryptkey` personalizado.

Se usado corretamente (longo, personalizado `--cryptkey`), garante alta segurança para armazenamento seguro.

---

### `ProtectedDataForCurrentUser`

Considerado seguro, até hoje, as normas. **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** a maneira de armazenar a senha é definida como `ECryptoMethod` of `2`. A maior vantagem deste método é ao mesmo tempo a maior desvantagem - ao invés de usar uma chave de criptografia (como no `AES`), os dados são criptografados usando credenciais de login do usuário conectado no momento, o que significa que **só** é possível descriptografar os dados na máquina em que eles foram criptografados e, além disso, **somente** pelo usuário que emitiu a criptografia.

Isso garante que mesmo que você envie o bot `inteiro. son` com `SteamPassword` criptografado usando este método para outra pessoa, eles não serão capazes de descriptografar a senha sem acesso direto ao seu PC. Esta é uma medida de segurança excelente, mas ao mesmo tempo tem a grande desvantagem de ser menos compatível, já que a senha criptografada usando este método será incompatível com qualquer outro usuário, bem como outro computador - incluindo o **seu** se você decidir, por exemplo, reinstalar seu sistema operacional. Este é o método recomendado se você não tiver que acessar suas configurações de qualquer outro computador que não o seu, e isso também não requer compatibilidade entre as máquinas.

**Por favor, note que no momento esta opção está disponível apenas para computadores que executam o Windows.**

---

### `EnvironmentVariable`

Armazenamento baseado em memória definido como `ECryptoMethod` de `3`. O ASF lerá a senha da variável de ambiente com o nome especificado no campo de senha (por exemplo, `SteamPassword`). Por exemplo, definindo `SteamPassword` como `ASF_SENHA_MINHACONTA` e `PasswordFormat` para `3`, fará com o que o ASF avalie a variável de ambiente `${ASF_SENHA_MINHACONTA}` e usará o que lhe for atribuído como senha da conta.

Lembre-se de garantir que as variáveis de ambiente do processo do ASF não sejam acessíveis por usuários não autorizados, pois isso anula completamente o propósito de utilizar esse método.

---

### `Arquivo`

Armazenamento baseado em arquivo (possivelmente fora do diretório de configuração do ASF) definido como `ECryptoMethod` de `4`. O ASF lerá a senha do diretório do arquivo especificado no campo de senha (por exemplo, `SteamPassword`). O caminho especificado pode ser absoluto ou relativo ao local "home" do ASF (a pasta com o diretório `config` dentro, levando em conta `--path` **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). Este método pode ser usado por exemplo com **[Docker secret](https://docs.docker.com/engine/swarm/secrets)**, que criam tais arquivos para uso, mas também podem ser usados fora do Docker se você mesmo criar o arquivo apropriado. Por exemplo, definindo `SteamPassword` para `/etc/secrets/MyAccount.pass` e `PasswordFormat` para `4`, fará com que o ASF leia o arquivo em `/etc/secrets/MyAccount.pass` e use o conteúdo daquele arquivo como a senha da conta.

Lembre-se de garantir que o arquivo contendo a senha não possa ser lido por usuários desautorizados, pois isso vai contra todo o propósito em estar usando este método.

---

## Recomendações de criptografia

Se compatibilidade não é um problema para você, e você se importa com o modo como o método `ProtectedDataForCurrentUser` funciona, é a opção **recomendada** de armazenar a senha no ASF, pois ela fornece a melhor segurança e conveniência. O método `AES` é uma boa escolha para as pessoas que querem usar suas configurações em mais de um computador, enquanto `PlainText` é a forma mais simples de salvar a senha, se você não se importar que qualquer um pode pegá-la no arquivo JSON.

Tenha em mente que todos os métodos de criptografia são considerados **inseguros** se o atacante tiver acesso ao seu PC. O ASF deve ser apto a descriptografar sua senha, e se ele é capaz de fazer isso em seu computador, então qualquer outro programa que rode no mesmo computador também será capaz. `ProtectedDataForCurrentUser` é a variante mais segura já que **mesmo outro usuário usando o mesmo PC não será capaz de descriptografá-lo**, mas ainda é possível descriptografar os dados se alguém for capas de roubar suas credenciais de login e informações do seu computador, juntamente com o arquivo de configuração do ASF.

Para configurações avançadas, você pode utilizar `EnvironmentVariable` e `File`. Eles têm uma utilização limitada. a `EnvironmentVariable` será uma boa idéia se você preferir obter senha através de algum tipo de solução personalizada e armazená-la exclusivamente na memória, enquanto `File` é bom, por exemplo, com **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. No entanto, ambos não são criptografados, então você basicamente transfere o risco do arquivo de configuração do ASF para qualquer outro método que você escolheu desses dois.

Além dos métodos de criptografia especificados acima, também é possível evitar especificar senhas completamente, por exemplo, usando um valor `nulo` ou uma string vazia em `SteamPassword`. O ASF vai pedir sua senha Steam quando for necessário, e não a salvará em lugar algum, mas a manterá na memória do processo executado no momento, até que você o feche. Enquanto sendo o método mais seguro de lidar com senhas (já que não são salvas em nenhum lugar), é também o mais problemático já que você tem que entrar com sua senha manualmente cada vez que abrir o ASF (quando for necessário). Se isso não for um problema para você, essa é sua melhor aposta de segurança, já que você não pode vazar algo que não existe.

---

## Descriptografar

O ASF não suporta nenhuma forma de descriptografar senha já criptografadas, já que os métodos de descriptografia são usados internamente para acessar os dados dentro do processo. Se você quiser reverter o procedimento de criptografia, por exemplo, para mover o ASF para outro computador quando estiver usando o `ProtectedDataForCurrentUser`, então simplesmente repita o procedimento do início no novo ambiente.

---

## Hashing

O ASF suporta atualmente os seguintes métodos de hashing como uma definição de `EHashingMethod`:

| Valor | Nome                             |
| ----- | -------------------------------- |
| 0     | PlainText (Texto sem formatação) |
| 1     | SCrypt                           |
| 2     | Pbkdf2                           |

A descrição e comparação exatas estão disponíveis abaixo.

### Configuração

Para gerar um hash, por exemplo, para `uso do IPCPassword` você deve executar o hash `` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** com o método de hashing apropriado que você escolheu e sua senha de texto simples. Depois, coloque a string hash que você recebeu na propriedade de configuração `IPCPassword` e mude o campo `IPCPasswordFormat` para o valor que corresponda ao método de criptografia que você escolheu.

---

### `PlainText (Texto sem formatação)`

É a forma mais simples e menos segura de fazer hash em uma senha, definido pelo valor `0` em `EHashingMethod`. O ASF gerará o hash correspondente à entrada original. É o método mais fácil de usar, e 100% compatível com todas as configurações, entretanto, sendo a maneira padrão de armazenar segredos, ela é totalmente insegura para um armazenamento seguro.

---

### `SCrypt`

Considerado seguro, até hoje, as normas. **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** maneira de hashar a senha é definida como `EHashingMethod` de `1`. O ASF usará a implementação `SCrypt` com `8` blocos, `8192` iterações, comprimento hash de `32` e uma chave de criptografia como sal para geral um array de bytes. Os bytes resultantes serão então codificados como string de **[base64](https://pt.wikipedia.org/wiki/Base64)**.

O ASF permite que você especifique o sal para esse método através da **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-pt-BR)** `--cryptkey`,que você deve usar para máxima segurança. Se você decidir para omiti-lo, o ASF usará sua própria chave, que é **conhecida** e codificada no aplicativo, tornando o hash menos seguro.

Se usado corretamente (sal personalizado, senha longa), garante alta segurança para o armazenamento seguro.

---

### `Pbkdf2`

Considerado os padrões hoje em dia, mais fracos. **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** a forma de hashing de senha é definida como `Método de EHashingod` de `2`. O ASF usará a implementação `Pbkdf2` usando `10000` iterações, `32` hash tamanho e criptografia da chave de sal, com `SHA-256` como algoritmo hmac. Os bytes resultantes serão codificados como uma string **[base64](https://en.wikipedia.org/wiki/Base64)**.

O ASF permite que você especifique sal para esse método por meio do argumento `--cryptkey` **[de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, que você deve usar para o máximo de segurança. Se você decidir para omiti-lo, o ASF usará sua própria chave, que é **conhecida** e codificada no aplicativo, tornando o hash menos seguro.

---

## Recomendações de hashing

Se você quiser usar um método de hashing para armazenar alguns segredos, como `IPCPassword`, recomendamos usar `SCrypt` com sal personalizado, já que fornece uma segurança decente contra tentativas de quebra pela força bruta.

`Pbkdf2` é oferecido apenas por motivos de compatibilidade, principalmente porque já temos uma implementação ativa (e necessária) dele para outros casos de uso em toda a plataforma Steam (por exemplo o código do modo familia). Ele ainda é considerado seguro, mas fraco em comparação com outras alternativas (por exemplo, `SCrypt`).