LAB_AED1_E5

Disciplina: Algoritmos e Estruturas de Dados I – Laboratório
Curso: Jogos Digitais – PUC Minas Lourdes
Etapa: Entrega 5 – Recursividade

Descrição:
O sistema Dungeon Explorer foi expandido com funções recursivas para análise da masmorra, exploração de área e soma da pontuação total dos jogadores.

Funcionalidades principais:
- Cadastro de jogadores
- Listagem de jogadores
- Busca de jogador por ID
- Remoção de jogador
- Geração do mapa da masmorra
- Exibição do mapa
- Movimentação do jogador
- Relatório de exploração
- Exploração recursiva de área
- Pontuação total recursiva

Estruturas utilizadas:
- Vetores paralelos para os dados dos jogadores
- Matriz char[,] para o mapa da masmorra
- Matriz int[,] para registrar posições visitadas
- Matriz int[,] auxiliar para exploração recursiva
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
ContarInimigosRecursivo()
ContarItensRecursivo()
PercentualExploracao()
AvaliarSituacaoJogador()
ExplorarRecursivamente()
AreaExploravel()
PontuacaoTotal()
SomarPontuacoesRecursivo()
SecretReport()

Funções recursivas da Etapa 5:

1. ContarInimigosRecursivo(char[,] map, int linha, int coluna)
Descrição:
Conta recursivamente a quantidade de inimigos restantes no mapa.

Caso base:
Quando a linha ultrapassa o tamanho da matriz, a função retorna 0.

Caso recursivo:
A função verifica a célula atual.
Se encontrar 'E', soma 1 e chama novamente a função.
Caso contrário, apenas chama novamente a função para continuar percorrendo a matriz.

2. ContarItensRecursivo(char[,] map, int linha, int coluna)
Descrição:
Conta recursivamente a quantidade de itens restantes no mapa.

Caso base:
Quando a linha ultrapassa o tamanho da matriz, a função retorna 0.

Caso recursivo:
A função verifica a célula atual.
Se encontrar 'I', soma 1 e chama novamente a função.
Caso contrário, apenas chama novamente a função para continuar percorrendo a matriz.

3. AreaExploravel(int playerL, int playerR, int[,] map)
Descrição:
Explora recursivamente a área alcançável a partir da posição atual do jogador.

Caso base:
Quando a posição está bloqueada ou já visitada, a função retorna 0.

Caso recursivo:
Quando a posição é válida, a função marca a célula como visitada e chama a si mesma nas quatro direções:
esquerda, direita, baixo e cima.

4. SomarPontuacoesRecursivo(int[] totalPlayerPoints, int players)
Descrição:
Soma recursivamente a pontuação total dos jogadores cadastrados.

Caso base:
Quando o índice é menor que 0, a função retorna 0.

Caso recursivo:
Soma a pontuação do jogador atual com a chamada recursiva para o jogador anterior.

Menu:
1 - Cadastrar jogador
2 - Listar jogadores
3 - Buscar jogador por ID
4 - Remover jogador
5 - Gerar mapa da masmorra
6 - Mostrar mapa
7 - Movimentar jogador
8 - Exibir Relatório de Exploração
9 - Explorar área recursivamente
10 - Pontuação Total
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
6. Explorar a área recursivamente.
7. Exibir a pontuação total.

Autor:
Gustavo de Carvalho Pinheiro das Neves
Matrícula: 903012