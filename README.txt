LAB_AED1_E4

Disciplina: Algoritmos e Estruturas de Dados I – Laboratório
Curso: Jogos Digitais – PUC Minas Lourdes
Etapa: Entrega 4 – Relatório de exploração da masmorra

Descrição:
O sistema Dungeon Explorer foi expandido com uma funcionalidade de relatório de exploração.
O relatório permite analisar o estado atual da masmorra e do jogador ativo.

Funcionalidades principais:
- Cadastro de jogadores
- Listagem de jogadores
- Busca de jogador por ID
- Remoção de jogador
- Geração do mapa da masmorra
- Exibição do mapa
- Movimentação do jogador
- Relatório de exploração

Estruturas utilizadas:
- Vetores paralelos para os dados dos jogadores
- Matriz char[,] para o mapa da masmorra
- Matriz int[,] para registrar as posições visitadas
- Vetor int[] para contar inimigos, itens e obstáculos

Funções implementadas:
CadastrarJogador()
ListarJogadores()
BuscarJogador()
RemoverJogador()
GerandoMapa()
MostrarMapa()
MoverJogador()
RelatorioExploracao()
ContarElementos()
PercentualExploracao()
AvaliarSituacaoJogador()
SecretReport()

Explicação das funções da Etapa 4:

RelatorioExploracao():
Exibe o relatório completo da exploração.
Mostra inimigos restantes, itens restantes, obstáculos, percentual explorado, situação da vida e situação do desempenho.

ContarElementos():
Percorre a matriz do mapa e conta inimigos, itens e obstáculos.
Os valores são armazenados no vetor elementsCounter.

PercentualExploracao():
Percorre a matriz mapExploration e calcula o percentual de posições visitadas pelo jogador.

AvaliarSituacaoJogador():
Classifica a situação da vida do jogador e a situação do desempenho com base na vida, pontuação e inimigos restantes.

Menu:
1 - Cadastrar jogador
2 - Listar jogadores
3 - Buscar jogador por ID
4 - Remover jogador
5 - Gerar mapa da masmorra
6 - Mostrar mapa
7 - Movimentar jogador
8 - Exibir Relatório de Exploração
0 - Sair

Como compilar:
Abrir o arquivo TarefaPrimeira.sln no Visual Studio e compilar o projeto.

Como executar:
Executar o projeto com F5 no Visual Studio e utilizar o menu exibido no console.

Fluxo recomendado de teste:
1. Cadastrar um jogador.
2. Buscar o jogador por ID para defini-lo como jogador ativo.
3. Gerar o mapa da masmorra.
4. Movimentar o jogador.
5. Exibir o relatório de exploração.

Autor:
Gustavo de Carvalho Pinheiro das Neves
Matrícula: 903012