# Compilação

Compilação é o processo de criação de arquivo executável. É isso que você quer fazer se você quiser adicionar suas próprias alterações ao ASF, ou se você, por qualquer motivo, não confia em arquivos executáveis fornecidos no Oficial **[releases](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**. Se você é usuário e não um desenvolvedor, provavelmente você vai querer usar binários já pré-compilados, mas se você quiser usar os seus, ou aprender algo novo, continue a leitura.

O ASF pode ser compilado em qualquer plataforma suportada atualmente, contanto que você tenha todas as ferramentas necessárias.

---

## SDK .NET

Independente da plataforma, você precisa do .NET SDK completo (não apenas o tempo de execução) para compilar o ASF. Instruções de instalação podem ser encontradas na página de download **[.NET](https://dotnet.microsoft.com/download)**. Você precisa instalar a versão apropriada do .NET SDK para seu sistema operacional. Após a instalação bem-sucedida, o comando `dotnet` deve estar funcionando e operativo. Você pode verificar se ele funciona com `dotnet --info`. Também certifique-se de que o seu .NET SDK corresponde aos requisitos **[de tempo de execução](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## Compilação

Supondo que você tenha o .NET SDK na versão apropriada, simplesmente navegue para o diretório de origem do ASF (clonado ou baixado e descompactado o repositório do ASF) e execute:

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic"
```

Se você estiver usando Linux/macOS, em vez disso você pode usar o script `cc.sh` que fará o mesmo, de uma forma um pouco mais complexa.

Se a compilação terminou com sucesso, você pode encontrar sua fonte `fonte` na pasta `fora / genérico`. Isso é o mesmo que a compilação oficial `genérica` do ASF, mas força `UpdateChannel` e `UpdatePeriod` of `0`, o que é apropriado para construir por conta própria.

### Sistema Operacional específico

Você também pode gerar um pacote .NET específico para Sistema Operacional se você tiver uma necessidade específica. In general you shouldn't do that because you've just compiled `generic` flavour that you can run with your already-installed .NET runtime that you've used for the compilation in the first place, but just in case you want to:

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/linux-x64" -r "linux-x64" --autocontain
```

Claro, substitua `linux-x64` com a arquitetura de SO que você quer atingir, como `win-x64`. Essa compilação também terá as atualizações desabilitadas. Ao construir `--self-contained` você também pode opcionalmente declarar mais dois interruptores: `-p:PublishTrimmed=true` irá produzir compilação cortada, enquanto `-p:PublishSingleFile=true` irá produzir um único arquivo. Adicionar ambas resultará nas mesmas configurações que usamos para as nossas próprias compilações.

### ASF-ui

Enquanto os passos acima são tudo o que é necessário para ter uma compilação totalmente funcional do ASF, você pode também ** estar interessado em construir a **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, nossa interface gráfica da web. Do lado do ASF, tudo o que você precisa fazer é colocar a compilação ASF-ui no local padrão `ASF-ui/dist` , então compilar o ASF com ele (novamente, se necessário).

ASF-ui is part of ASF's source tree as a **[git submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, ensure that you've cloned the repo with `git clone --recursive`, as otherwise you'll not have the required files. Você também precisará de um NPM funcional, **[Node.js](https://nodejs.org)** vem com ele. Se você estiver usando Linux/macOS, recomendamos o nosso `cc. h` script, que vai cobrir automaticamente a criação e envio da ASF-ui (se possível, isto é, se você estiver respeitando os requisitos que acabamos de mencionar).

Além do `cc. h` script, também anexamos as instruções de compilação simplificadas abaixo, consulte a **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** para obter documentação adicional. Do local da árvore de origem do ASF, então execute os seguintes comandos:

```shell
rm -rf "ASF-ui/dist" # ASF-ui não se limpa após a antiga compilação

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # Certifique-se de que a saída da nossa compilação está limpa os arquivos antigos
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic" # Ou de acordo com o que você precisa conforme o acima
```

Agora você deve ser capaz de encontrar os arquivos da ASF-ui na pasta `out/generic/www`. O ASF será capaz de servir esses arquivos para o seu navegador.

Como alternativa, você pode simplesmente construir o ASF-ui, seja manualmente ou com a ajuda do nosso repositório, então copie a saída de compilação para a pasta `${OUT}/www` manualmente, onde `${OUT}` é a pasta de saída do ASF que você especificou com o parâmetro `-o`. É exatamente isso que o ASF faz como parte do processo de compilação. ela copia `ASF-ui/dist` (se existir) para `${OUT}/www`, nada especial e também pode ser feito pós-compilação como você pode ver, se necessário.

---

## Desenvolvimento

Se você gostaria de editar o código ASF, você pode usar qualquer um. ET IDE compatível para esse fim, embora até mesmo isso seja opcional, já que você também pode editar com um bloco de notas e compilar com o comando `dotnet` descrito acima.

Se você não tem uma escolha melhor, podemos recomendar **[JetBrains Rider](https://www.jetbrains.com/rider)** e **[Visual Studio Code](https://code.visualstudio.com/download)**sendo o IDE preferido que a equipe do ASF está usando pessoalmente, e o segundo sendo uma alternativa viável. Ambos os programas são multiplataforma e estão disponíveis no Linux, macOS e Windows.

---

## Etiquetas

`principal` não é garantido que esteja em um estado que permita uma compilação bem sucedida ou uma execução sem falhas do ASF, em primeiro lugar, já que é ramo de desenvolvimento como mencionado em nosso ciclo de lançamento **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. Se você deseja compilar ou fazer referência ao ASF da fonte, então você deve usar a tag **[apropriada](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** para essa finalidade, o que garante pelo menos uma compilação bem sucedida, e muito provavelmente uma execução perfeita (se a compilação foi marcada como versão estável). Para verificar a "saúde" atual da árvore, você pode usar nossa CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Versões oficiais

As versões oficiais do ASF são compiladas pela **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, com a última versão . ET SDK que corresponde ao ASF **[requisitos de execução](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. Depois de passar nos testes, todos os pacotes são implantados como release, também no GitHub. Isso também garante transparência, uma vez que o GitHub sempre usa fonte pública oficial para todas as compilações, e você pode comparar as somas de verificação dos artefatos do GitHub com os arquivos de lançamento do GitHub. Os desenvolvedores do ASF não compilam ou publicam as compilações por conta própria, exceto para o processo de desenvolvimento privado e depuração.

Além disso, o ASF mantém a validação manual e publica as somas de verificação de compilação independentes do GitHub, um servidor remoto do ASF, como medida adicional de segurança. Esta etapa é obrigatória para que ASFs existentes considerem a liberação como um candidato válido para a funcionalidade de atualização automática.