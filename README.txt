LAB_AED1_E6

Disciplina: Algoritmos e Estruturas de Dados I – Laboratório
Curso: Jogos Digitais – PUC Minas Lourdes
Etapa: Entrega 6 – POO

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

Classes implementadas:
Jogador
Item
Inimigo
Mapa

Substituição dos vetores paralelos:
Nas etapas anteriores, os dados dos jogadores eram armazenados em vários vetores separados:

idPlayer[]
playerNames[]
playerLife[]
playerAttack[]
playerDefense[]
playerPoints[]

Classes criadas na Etapa 6:

1 - Classe Jogador:
Representa um jogador cadastrado no sistema.

Atributos principais:

id
nome
vida
ataque
defesa
pontuação

Responsabilidades:

armazenar os dados do jogador
iniciar a pontuação com valor 0
permitir acesso aos dados por getters, setters ou propriedades
atualizar a pontuação do jogador
exibir os dados do jogador

2 - Classe Item:
Representa um item coletável na masmorra.

Atributos principais:

nome
valor

Responsabilidades:

armazenar o nome do item
armazenar o valor de pontuação concedido
permitir acesso aos dados do item

3 - Classe Inimigo:
Representa um inimigo presente no mapa.

Atributos principais:

nome
vida
pontuacaoRecompensa

Responsabilidades:

armazenar os dados do inimigo
armazenar a pontuação concedida ao jogador
permitir acesso aos dados do inimigo


4 - Classe Mapa:
Representa a masmorra do jogo.

Atributos principais:

grade
linhas
colunas

Responsabilidades:

inicializar o mapa
gerar o conteúdo da masmorra
exibir o mapa
validar posições
obter o conteúdo de uma célula
alterar o conteúdo de uma célula
marcar posições visitadas.

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