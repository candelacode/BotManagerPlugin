# Compatibilidade

O ASF é um aplicativo C# que roda na plataforma .NET. Isso significa que o ASF não é compilado diretamente em **[código do computador](https://en.wikipedia.org/wiki/Machine_code)** que roda na sua CPU, mas em **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)** que requer um tempo de execução compatível com CIL para a sua execução.

Esta abordagem tem uma quantidade gigantesca de vantagens, como a CIL é independente de plataforma, É por isso que o ASF pode funcionar nativamente em muitos sistemas operacionais disponíveis, especialmente no Windows, Linux e macOS. Não só não há necessidade de emulação, como também suporte para todas as otimizações relacionadas a plataforma e hardware, como instruções CPU SSE. Graças a isso, o ASF pode alcançar um desempenho e otimização superiores, enquanto ainda oferece compatibilidade e confiabilidade perfeitas.

This also means that ASF has **no specific OS requirement**, because it requires working **runtime** on that OS and not OS itself. Enquanto esse tempo de execução estiver executando o código ASF corretamente, não importa se o SO é Windows, Linux, baseado em macOS, BSD, Sony Playstation 4, Nintendo Wii ou sua torradeira - contanto que haja **[. ET para isso](https://dotnet.microsoft.com/download/dotnet)**, há **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** para ele (na variante `genérica`.

No entanto, independentemente de onde você rode o ASF, você deve garantir que sua plataforma de destino tenha **[.NET pré-requisitos](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** instalados. Essas são bibliotecas de baixo nível necessárias para a funcionalidade adequada do tempo de execução e são absolutamente fundamentais para o funcionamento do ASF. É muito provável que você já tenha algumas delas (ou mesmo todas) já instaladas.

---

## Empacotamento do ASF

O ASF está disponível em 2 tipos principais: pacote genérico e pacote específico para Sistema Operacional. Funcionalmente ambos os pacotes são exatamente os mesmos, ambos são capazes de se atualizarem automaticamente. A única diferença entre eles é se o pacote **genérico** do ASF também vem com o tempo de execução **específico do sistema operacional** para ligá-lo.

---

### Genérico

Pacote genérico é uma compilação agnóstica de plataforma que não inclui nenhum código específico por máquina. Esta configuração requer que você tenha o tempo de execução .NET já instalado no seu OS **na versão** apropriada. Todos sabemos como é problemático manter as dependências actualizadas, portanto, este pacote é aqui principalmente para pessoas que **já usam** . ET e não quer duplicar seu tempo de execução exclusivamente para o ASF se eles podem usar o que eles já têm instalado. O pacote genérico também permite que você rode o ASF **em qualquer lugar, desde que você possa obter uma implementação funcional do . ET o tempo de execução**, independente de existir ou não uma compilação do ASF específica para Sistema Operacional.

Não é recomendado usar o tipo genérico se você for um usuário casual ou avançado que apenas queira fazer o ASF funcionar e não entrar em contato com o usuário. EQUIPE detalhes técnicos. Em outras palavras: se você sabe o que é, você pode usá-lo, caso contrário é muito melhor usar um pacote específico para o Sistema Operacional explicado abaixo.

---

### Sistema Operacional específico

O pacote para Sistema Operacional específico, além do código gerenciado incluído no pacote genérico, também inclui código nativo para determinada plataforma. Em outras palavras, o pacote para Sistema Operacional específico **já inclui o pacote adequado. ECONOMIZE o tempo de execução dentro do**, que permite que você ignore completamente a bagunça de instalação inteira e apenas abra o ASF diretamente. O pacote para Sistema Operacional específico, como você pode adivinhar a partir do nome, é específico para Sistema Operacional e todo sistema operacional requer sua própria versão - por exemplo, o Windows requer PE32+ `ArchiSteamFarm. Binário xe` enquanto Linux funciona com o binário Unix ELF `ArchiSteamFarm`. Como você deve saber, esses dois tipos não são compatíveis um com o outro.

O ASF está atualmente disponível nas seguintes variantes específicas de Sistema Operacional:

- `linux-arm` funciona com ARM baseado em 32-bit (ARMv7+) GNU/Linux OSes com glibc 2.35/musl 1.2.3 e mais recente. This variant covers platforms such as Raspberry Pi 2 (and newer), it will **not** work with older ARM architectures, such as ARMv6 found in Raspberry Pi 0 & 1, it will also not work with OSes that do not implement required GNU/Linux environment (such as Android).
- `linux-arm64` funciona com ARM baseado em 64-bit (ARMv8+) GNU/Linux OS com glibc 2.27/musl 1.2.3 e mais recente. This variant covers platforms such as Raspberry Pi 3 (and newer), it will **not** work with 32-bit OSes that do not have required 64-bit libraries available (such as 32-bit Raspberry Pi OS), it will also not work with OSes that do not implement required GNU/Linux environment (such as Android).
- `linux-x64` funciona em sistemas operacionais GNU/Linux de 64 bits com glibc 2.27/musl 1.2.3 e mais recentes.
- `osx-arm64` funciona com sistemas operacionais macOS baseados em ARM 64-bit ((Apple silicon) na versão 13 e mais recente.
- `osx-x64` funciona em Sistemas Operacionais macOS 64-bit na versão 15 e mais recente.
- `win-arm64` funciona com **atualizado para ARMs** 64 bits baseado em ARM (ARMv8+) na versão 10, 11 e mais recente.
- `win-x64` funciona no **atualizado** Sistemas Operacionais Windows 64-bit na versão 10, 11, Server 2016+ e mais recente.

Claro, mesmo que você não tenha um pacote específico para Sistema Operacional disponível para sua combinação de arquitetura de Sistema, você sempre pode instalar o apropriado. OBTENHA o tempo de execução e roda o sabor genérico do ASF, que também é a principal razão pela qual ele existe em primeiro lugar. O pacote genérico do ASF é agnóstico de plataforma e será executado em qualquer plataforma que tenha o tempo de execução .NET funcional. É importante notar: o ASF requer o tempo de execução .NET e não um sistema operacional ou arquitetura específicos. For example, if you're running 32-bit Windows then despite of no dedicated `win-x86` ASF version, you can still install .NET SDK in `win-x86` version and run generic ASF just fine. Nós simplesmente não podemos visar todas as combinações de arquitetura de Sistemas Operacionais que existem e são usadas por alguém, então temos que traçar um limite em algum lugar. O x86 é um bom exemplo dessa linha, já que é uma arquitetura obsoleta desde pelo menos 2004.

Para obter uma lista completa de todas as plataformas e Sistemas Operacionais suportados por .NET 10.0, visite **[notas de lançamento](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md)**.

---

## Requisitos de runtime

Se você estiver usando um pacote específico para Sistema Operacional, então você não precisa se preocupar com requisitos de tempo de execução porque o ASF sempre acompanha o tempo de execução necessário e atualizado que funcionará corretamente enquanto você tiver o **[. Emitir pré-requisitos](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** instalado e atualizado. Em outras palavras, **você não precisa instalar. ET tempo de execução ou SDK**, já que as compilações específicas para SO requerem apenas dependências nativas (pré-requisitos) e nada mais.

No entanto, se você está tentando executar o pacote **genérico** do ASF, então você deve garantir que o seu tempo de execução .NET suporta a plataforma requerida pelo ASF.

O ASF, como programa, destina-se ao **.NET 10.0** (`net10.`) agora, mas pode apontar para a nova plataforma no futuro. `net10.0` is supported since 10.0.100 SDK (10.0.0 runtime), although ASF might prefer **latest runtime at the moment of compilation**, so you should ensure that you have **[latest SDK](https://dotnet.microsoft.com/download)** (or at least runtime) available for your machine. A variante genérica do ASF pode se recusar a iniciar se o seu tempo de execução for mais antigo que o mínimo suportado durante a compilação.

Em caso de dúvida, verifique o que a nossa **[integração contínua usa](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** para compilar e implantar as versões do ASF liberadas no GitHub. Você pode encontrar a saída `dotnet --info` a cada compilação como parte da etapa de verificação do .NET.