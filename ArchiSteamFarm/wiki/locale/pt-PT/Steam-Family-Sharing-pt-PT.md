# Partilha de Biblioteca Steam

O ASF suporta o Compartilhamento de Biblioteca Steam - o antigo, bem como o novo sistema. Para entender como funciona o ASF com isso, você deve primeiro ler como **[o Compartilhamento de Biblioteca Steam funciona](https://store.steampowered.com/promotion/familysharing)**, que está disponível na loja Steam. Além disso, verifique **[a notícia](https://store.steampowered.com/news/app/593110/view/4149575031735702628)** para o próximo novo sistema de Compartilhamento de Biblioteca Steam, com o qual o ASF também é compatível.

---

## ASF

O suporte para o recurso de Compartilhamento de Biblioteca Steam no ASF é transparente, o que significa que ele não introduz nenhuma nova propriedade de configuração bot/process - funciona fora da caixa como uma funcionalidade extra embutida.

O ASF inclui uma lógica apropriada para estar ciente de que a biblioteca está bloqueada por usuários do modo familiar, portanto não vai "expulsar" eles da sessão durante o lançamento de um jogo. O ASF agirá exatamente como com a conta principal segurando o bloqueio, portanto se esse bloqueio for mantido pelo seu cliente Steam, ou por um de seus usuários de compartilhamento, o ASF não tentará coletar, em vez disso, vai esperar que o bloqueio seja liberado. Isso está relacionado principalmente ao sistema antigo - o novo sistema permite que seus usuários compartilhem jogos para outros que não aqueles que o ASF está coletando.

Além disso, após o login, o ASF acessará seus sistemas de compartilhamento de família (antigos e novos), Do qual ele extrairá os usuários (Steam IDs) que podem usar a sua biblioteca. Esses usuários recebem permissão `FamilySharing` para usar os comandos **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, especialmente permitindo que eles usem o comando `pause~` na conta do bot que está compartilhando jogos com eles, que permite pausar o módulo de coleta automática de cartas para iniciar um jogo que pode ser compartilhado - o que também se aplica principalmente ao sistema antigo, mas ainda pode ser usado com o novo sistema caso o ASF esteja rodando um jogo que seus usuários querem jogar.

Connecting both functionalities described above allows your friends to `pause~` your cards farming process, start a game, play as long as they wish, and then after they're done playing, cards farming process will be automatically resumed by ASF. Of course, issuing `pause~` is not needed if ASF is currently not farming anything actively, because your friends can launch the game right away, and logic described above ensures that they won't be kicked out of the session.

---

## Limitações

A rede Steam adora enganar o ASF compartilhando atualizações de status falsas, o que pode fazer o ASF acreditar que pode retomar o processo, expulsando seu amigo muito cedo. Esta é exatamente a mesma questão que nós já explicamos em **[esta referência FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. Recomendamos exactamente as mesmas soluções. promova seus amigos à permissão `Operador` (ou acima) e diga a eles para usarem os comandos `pause` e `resumir`.