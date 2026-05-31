# Segurança

## Encriptação

O ASF atualmente suporta os seguintes métodos de criptografia como uma definição de `ECryptoMethod`:

| Valor | Nome     |
| ----- | -------- |
| 0     | Texto    |
| 1     | AES      |
| 2     | Usuário  |
| 3     | Variável |
| 4     | Ficheiro |

A descrição e comparação exatas estão disponíveis abaixo.

### Configurar

A fim de gerar uma senha criptografada, por exemplo, para uso `SteamPassword` , você deve executar `criptografar` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** com a criptografia apropriada que você escolheu e sua senha original de texto puro. Depois, coloque a string criptografada que você tem como parâmetro de configuração do bot `SteamPassword` , e, finalmente, mudar o `PasswordFormat` para o que corresponde ao método de criptografia escolhido. Alguns formatos não requerem o comando `criptografar` , por exemplo `EnvironmentVariable` ou `File`, apenas coloque o caminho apropriado para eles.

---

### `Texto`

Esta é a maneira mais simples e insegura de armazenar uma senha, definida como `ECryptoMethod` of `0`. O ASF espera que a string seja um texto sem formatação - uma senha na sua forma direta. É o mais fácil de usar, e 100% compatível com todas as configurações, portanto, é uma maneira padrão de armazenar segredos, totalmente insegura para armazenamento seguro.

---

### `AES`

Considered secure by today standards, **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** way of storing the password is defined as `ECryptoMethod` of `1`. ASF espera que a string seja uma sequência de caracteres **[codificada em base64](https://en.wikipedia.org/wiki/Base64)** resultando num array de bytes encriptado com AES após a tradução, que então deve ser descriptografado usando o incluso **[vetor de inicialização](https://en.wikipedia.org/wiki/Initialization_vector)** e chave de criptografia do ASF.

O método acima garante segurança enquanto o atacante não souber a chave de criptografia do ASF que está sendo usada para descriptografia e criptografia de senhas. O ASF permite que você especifique a chave via `--cryptkey` **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, que você deve usar para máxima segurança. Se você decidir omitir, o ASF usará sua própria chave, que é **conhecido como** e codificado no aplicativo, significa que qualquer um pode reverter a criptografia do ASF e obter senha descriptografada. Ainda requer algum esforço e não é tão fácil de fazer, mas é possível, É por isso que você deve usar a criptografia `AES` com seu próprio `--cryptkey` que é mantido em segredo. O método AES utilizado pelo ASF fornece segurança que deve ser satisfatória e é um equilíbrio entre a simplicidade do `PlainText` e a complexidade do `ProtectedDataForCurrentUser`, mas é altamente recomendado usá-lo com `--cryptkey` personalizado.

Se usado corretamente (longo, personalizado `--cryptkey`), garante alta segurança para armazenamento seguro.

---

### `Usuário`

Considerado seguro, até hoje, as normas. **[DPAPI](https://en.wikipedia.org/wiki/Data_Protection_API)** a maneira de armazenar a senha é definida como `ECryptoMethod` of `2`. The major advantage of this method is at the same time the major disadvantage - instead of using encryption key (like in `AES`), data is encrypted using login credentials of currently logged in user, which means that it's possible to decrypt the data **only** on the machine it was encrypted on, and in addition to that, **only** by the user who issued the encryption.

Isso garante que mesmo que você envie o bot `inteiro. son` com `SteamPassword` criptografado usando este método para outra pessoa, eles não serão capazes de descriptografar a senha sem acesso direto ao seu PC. Trata-se de uma excelente medida de segurança, mas, ao mesmo tempo, apresenta uma grande desvantagem de ser menos compatível. como a senha criptografada usando este método será incompatível com qualquer outro usuário e também com máquina - incluindo **seu próprio** se você decidir em e. . reinstale o seu sistema operacional. Este é o método recomendado se você não tiver que acessar suas configurações de qualquer outro computador que não o seu, e isso também não requer compatibilidade entre as máquinas.

**Por favor, note que esta opção está disponível apenas para máquinas que executam o Windows OS a partir de agora.**

---

### `Variável`

Armazenamento baseado em memória definido como `ECryptoMethod` de `3`. O ASF lerá a senha do ambiente com o nome especificado no campo senha (por exemplo, `SteamPassword`). For example, setting `SteamPassword` to `ASF_PASSWORD_MYACCOUNT` and `PasswordFormat` to `3` will cause ASF to evaluate `${ASF_PASSWORD_MYACCOUNT}` environment variable and use whatever is assigned to it as the account password.

Lembre-se de garantir que as variáveis de ambiente do processo do ASF não sejam acessíveis por usuários não autorizados. pois isso é contrário a todo o propósito de utilizar este método.

---

### `Ficheiro`

Armazenamento baseado em arquivos (possivelmente fora da pasta config do ASF) definido como `ECryptoMethod` of `4`. O ASF lerá a senha do caminho do arquivo especificado no campo da senha (por exemplo, `SteamPassword`). O caminho especificado pode ser absoluto ou relativo ao local "home" do ASF (a pasta com o diretório `config` dentro, levando em conta `--path` **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). Este método pode ser usado por exemplo com **[Docker secret](https://docs.docker.com/engine/swarm/secrets)**, que criam tais arquivos para uso, mas também podem ser usados fora do Docker se você mesmo criar o arquivo apropriado. Por exemplo, definir `SteamPassword` para `/etc/secrets/MyAccount. ass` e `PasswordFormat` para `4` fará com que o ASF leia `/etc/secrets/MyAccount. ass` e usa o que estiver escrito nesse arquivo como a senha da conta.

Lembre-se de garantir que o arquivo que contém a senha não seja legível por usuários não autorizados, pois isso vai contra todo o propósito de usar este método.

---

## Recomendações de criptografia

Se compatibilidade não é um problema para você, e você se importa com o modo como o método `ProtectedDataForCurrentUser` funciona, é a opção **recomendada** de armazenar a senha no ASF, pois ela fornece a melhor segurança e conveniência. O método `AES` é uma boa escolha para as pessoas que ainda querem usar suas configurações em qualquer máquina que quiserem, enquanto `PlainText` é a maneira mais simples de armazenar a senha, se você não se importa que alguém pode olhar o arquivo de configuração JSON para isso.

Tenha em mente que todos os métodos de criptografia são considerados **inseguros** se o atacante tiver acesso ao seu PC. O ASF deve ser capaz de descriptografar as senhas criptografadas, e se o programa for executado em seu computador é capaz de fazer isso então qualquer outro programa rodando na mesma máquina também será capaz de fazer isso. `ProtectedDataForCurrentUser` é a variante mais segura já que **mesmo outro usuário usando o mesmo PC não será capaz de descriptografar o**, mas ainda é possível descriptografar os dados se alguém for capaz de roubar suas credenciais de login e informações do computador além do arquivo de configuração do ASF.

Para configurações avançadas, é possível utilizar `EnvironmentVariable` e `File`. Eles têm uma utilização limitada. a `EnvironmentVariable` será uma boa idéia se você preferir obter senha através de algum tipo de solução personalizada e armazená-la exclusivamente na memória, enquanto `File` é bom, por exemplo, com **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. No entanto, ambos não são criptografados, então você basicamente move o risco do arquivo de configuração do ASF para o que você escolher desses dois.

Além dos métodos de criptografia especificados acima, também é possível evitar especificar as senhas completamente, por exemplo, como `SteamPassword` usando uma string vazia ou um valor `null`. O ASF vai te pedir sua senha quando for necessário, e não o salvará em lugar nenhum, mas manter na memória do processo de execução atual, até que você o feche. Embora sendo o método mais seguro de lidar com senhas (não são salvas em lugar nenhum), Também é o mais problemático já que você precisa digitar sua senha manualmente cada vez que o ASF for executado (quando for necessário). Se isso não for um problema para você, essa é sua melhor aposta de segurança, já que você não pode vazar algo que não existe.

---

## Descriptografar

O ASF não suporta nenhuma forma de descriptografar senhas já criptografadas, já que os métodos de descriptografia são usados internamente para acessar os dados dentro do processo. Se você quiser reverter o procedimento de criptografia, por exemplo, para mover o ASF para outro computador quando estiver usando `ProtectedDataForCurrentUser`, então simplesmente repita o procedimento desde o início no novo ambiente.

---

## Hashing

O ASF suporta atualmente os seguintes métodos de hashing como uma definição de `EHashingMethod`:

| Valor | Nome   |
| ----- | ------ |
| 0     | Texto  |
| 1     | Cripta |
| 2     | Pbkdf2 |

A descrição e comparação exatas estão disponíveis abaixo.

### Configurar

Para gerar um hash, por exemplo, para `uso do IPCPassword` você deve executar o hash `` **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** com o método de hashing apropriado que você escolheu e sua senha de texto simples. Afterwards, put the hashed string that you've got as `IPCPassword` ASF config property, and finally change `IPCPasswordFormat` to the one that matches your chosen hashing method.

---

### `Texto`

Esta é a maneira mais simples e insegura de hashing uma senha, definida como `EHashingMethod` of `0`. O ASF gerará hash correspondente à entrada original. É o mais fácil de usar, e 100% compatível com todas as configurações, portanto, é uma maneira padrão de armazenar segredos, totalmente insegura para armazenamento seguro.

---

### `Cripta`

Considerado seguro, até hoje, as normas. **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** maneira de hashar a senha é definida como `EHashingMethod` de `1`. O ASF usará a implementação `SCrypt` usando blocos `8` , `8192` iterações, `32` hash length e chave de criptografia como um sal para gerar a matriz de bytes. Os bytes resultantes serão codificados como uma string **[base64](https://en.wikipedia.org/wiki/Base64)**.

O ASF permite que você especifique sal para esse método por meio do argumento `--cryptkey` **[de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, que você deve usar para o máximo de segurança. Se você decidir omitir, o ASF usará sua própria chave, que é **conhecido como** e codificado no aplicativo, significa que o hashing será menos seguro.

Se usado corretamente (sal personalizado, senha longa), garante alta segurança para o armazenamento seguro.

---

### `Pbkdf2`

Considerado os padrões hoje em dia, mais fracos. **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** a forma de hashing de senha é definida como `Método de EHashingod` de `2`. O ASF usará a implementação `Pbkdf2` usando `10000` iterações, `32` hash tamanho e criptografia da chave de sal, com `SHA-256` como algoritmo hmac. Os bytes resultantes serão codificados como uma string **[base64](https://en.wikipedia.org/wiki/Base64)**.

O ASF permite que você especifique sal para esse método por meio do argumento `--cryptkey` **[de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, que você deve usar para o máximo de segurança. Se você decidir omitir, o ASF usará sua própria chave, que é **conhecido como** e codificado no aplicativo, significa que o hashing será menos seguro.

---

## Recomendações de Hashing

Se você quiser usar um método de hashing para armazenar alguns segredos, como `IPCPassword`, recomendamos usar `SCrypt` com sal personalizado, já que fornece uma segurança muito decente contra tentativas de venda bruta.

`Pbkdf2` é oferecido apenas por motivos de compatibilidade. principalmente porque já temos uma implementação ativa (e necessária) disso para outros casos de uso em toda a plataforma Steam (e. . Pins parentais). Ainda é considerado seguro, mas fraco em comparação com alternativas (por exemplo, `SCrypt`).