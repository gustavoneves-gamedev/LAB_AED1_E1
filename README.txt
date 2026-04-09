LAB_AED1_E3

Disciplina: Algoritmos e Estruturas de Dados I – Laboratório
Curso: Jogos Digitais – PUC Minas Lourdes
Etapa: Entrega 3 – Funções e movimentação do jogador

Descrição:
O sistema Dungeon Explorer foi expandido com organização em funções e movimentação do jogador no mapa.

Funções implementadas:
CadastrarJogador()
ListarJogadores()
BuscarJogador()
RemoverJogador()
GerandoMapa()
MostrarMapa()
MoverJogador()

Seleção do jogador:
Realizada pela opção 3 (buscar por ID).
O jogador encontrado é definido como jogador ativo.

Movimentação:
Controles:
W - cima
A - esquerda
S - baixo
D - direita
(Case Insensitive)

Regras:
- não pode sair do mapa
- não pode atravessar obstáculos
- posição anterior vira '.'

Interações:
Item (I): +10 pontos
Inimigo (E): +20 pontos
Obstáculo (X): bloqueia movimento

Como compilar:
Abrir TarefaPrimeira.sln no Visual Studio e compilar.

Como executar:
Executar com F5 e utilizar o menu.

Autor:
Gustavo de Carvalho Pinheiro das Neves
Matrícula: 903012