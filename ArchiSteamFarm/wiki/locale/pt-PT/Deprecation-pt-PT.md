# Depreciação

Estamos fazendo o nosso melhor para seguir uma política consistente de depreciação, a fim de tornar tanto o desenvolvimento quanto o uso muito mais consistente.

---

## O que é depreciação?

Depreciação é o processo de pequenas ou maiores alterações que tornam obsoletas as opções, argumentos, funcionalidades ou casos de uso anteriores. Depreciação geralmente significa que determinada coisa simplesmente foi reescrita em outra forma (semelhante), e você deve garantir oportunamente que você fará a mudança apropriada. Neste caso, é simplesmente mover determinada funcionalidade para o lugar mais apropriado.

O ASF muda rápido e sempre em busca de se tornar melhor. Infelizmente, isto significa que podemos alterar ou mover algumas funcionalidades existentes para outro segmento do programa a fim de que elas se beneficiem de novos recursos, compatibilidade ou estabilidade. Graças a isso, não precisamos nos manter com decisões de desenvolvimento obsoletas ou dolorosamente erradas que tomamos anos atrás. Estamos sempre tentando oferecer uma substituição razoável que se encaixa ao uso esperado de funcionalidades anteriormente disponíveis, é por isso que a depreciação é quase inofensiva e exige pequenas correções para uso anterior.

---

## Etapas de depreciação

O ASF seguirá 2 fases de depreciação, fazendo a transição muito mais fácil e menos problemática.

### Fase 1

A primeira etapa acontece assim que determinada funcionalidade se torna depreciada, com disponibilidade imediata de outra solução (ou nenhuma, se não houver planos de reintroduzi-la).

Durante esse estágio, o ASF exibirá o aviso apropriado quando a função depreciada estiver sendo usada. Desde que seja possível, o ASF tentará imitar o comportamento antigo e continuar sendo compatível com ele. O ASF continuará no primeiro estágio em relação a essa funcionalidade pelo menos até a próxima versão estável. Esse é o momento em que, esperançosamente sem quebra de compatibilidade, você pode fazer as mudanças necessárias em todas as suas ferramentas e padrões para se adequar ao novo comportamento. Você pode confirmar se fez todas as mudanças apropriadas ao não ver mais o aviso de depreciação.

### Fase 2

A segunda fase é agendada após a primeira fase explicada acima ocorre e é liberada em uma versão estável. Essa etapa introduz a remoção completa do recurso depreciado, o que significa que o ASF não vai reconhecer que você está tentando usar um recurso depreciado, muito menos respeitá-lo, uma vez que ele simplesmente não existe no código atual. O ASF não vai mais mostrar qualquer aviso, já que ele não reconhece o que você está tentando fazer.

---

## Summary

Você tem mais ou menos um **mês inteiro** a fim de fazer a mudança apropriada, o que deve ser mais do que o suficiente, mesmo se você for um usuário casual do ASF. Após esse período, o ASF já não garante que as configurações antigas terão qualquer efeito (segunda etapa), efetivamente fazer com que certos recursos parem de funcionar sem que você perceba. If you're launching ASF after more than a month of inactivity, it's recommended for you to **[start from scratch](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** again, or read all the changelogs that you've missed and manually adapt your usage to current one.

Na maioria dos casos, ignorar o aviso de depreciação não deixará a funcionalidade geral do ASF inutilizável. mas antes voltando ao comportamento padrão (que pode ou não coincidir com suas preferências pessoais).

---

## Exemplo

Movemos pré-V3.1.2.2 `--server` **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** para `IPC` **[propriedade de configuração global](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**.

### Fase 1

A fase 1 aconteceu na versão V3.1.2.2, onde adicionamos o aviso apropriado ao uso de `--server`. O argumento Now-obsolete `--server` foi mapeado automaticamente para o argumento `IPC: true` global config , efetivamente agir exatamente da mesma forma que a opção old `--server` por tempo. Isso permitiu que todos fizessem a mudança apropriada antes que o ASF deixe de aceitar o argumento antigo.

### Fase 2

A fase 2 aconteceu na versão V3.1.3.0, logo após o V3.1.2.9 estável com a fase 1 explicada acima. A segunda fase fez com que o ASF parasse de reconhecer o argumento `--server` , Passando como qualquer outro argumento inválido, que não tem mais qualquer efeito no programa. Para pessoas que ainda não mudaram seu uso de `--server` em `IPC: true`, isso fez com que o IPC parasse completamente de funcionar, já que o ASF já não mapeava corretamente.