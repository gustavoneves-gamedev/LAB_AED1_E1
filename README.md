# LAB_AED1_E6

## Disciplina
Algoritmos e Estruturas de Dados I – Laboratório

## Curso
Jogos Digitais – PUC Minas Lourdes

## Etapa
Entrega 6 – POO

## Descrição
Este projeto consiste em uma aplicação console em C# do sistema **Dungeon Explorer**.

Nesta etapa, o sistema foi evoluído com a implementação de funções recursivas para análise da masmorra, exploração de área e cálculo da pontuação total dos jogadores.

O sistema mantém as funcionalidades das etapas anteriores:

- cadastro de jogadores
- listagem de jogadores
- busca de jogador por ID
- remoção de jogador
- geração do mapa da masmorra
- exibição do mapa
- movimentação do jogador
- relatório de exploração

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


---

## Movimentação
Controles:
W - cima
A - esquerda
S - baixo
D - direita
(Case Insensitive)

## Classes utilizadas

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


## Requisitos para compilação
Para compilar e executar o projeto, é necessário ter instalado:

- Visual Studio 2022 ou superior
- .NET compatível com o projeto

## Como compilar
1. Abrir o arquivo `TarefaPrimeira.sln` no Visual Studio.
2. Restaurar os pacotes automaticamente, se solicitado.
3. Compilar o projeto usando a opção **Compilar** ou executá-lo diretamente.

## Como executar
1. Abrir a solução no Visual Studio.
2. Pressionar `F5` ou clicar em **Iniciar**.
3. O programa será executado no console, exibindo o menu principal do sistema.

## Menu do sistema
O programa apresenta o seguinte menu:

- `1` - Cadastrar jogador
- `2` - Listar jogadores
- `3` - Buscar jogador por ID
- `4` - Remover jogador
- `5` - Gerar mapa da masmorra
- `6` - Mostrar mapa
- `7` - Movimentar jogador
- `8` - Exibir Relatorio de Exploracao
- `9` - Explorar area recursivamente
- `10` - Pontuacao Total
- `0` - Sair

## Observações sobre a implementação
- O sistema impede cadastro de IDs duplicados.
- Há controle de quantidade máxima de jogadores no servidor.
- A busca de jogadores é feita por ID.
- A remoção reorganiza os vetores, deslocando os jogadores seguintes uma posição para trás.
- Nesta versão, os atributos de vida, ataque e defesa estão sendo gerados com valores aleatórios para facilitar os testes.
- O jogador escolhido se move corretamente pelo mapa gerado

## Arquivos da entrega
A entrega da etapa deve conter:

- projeto em C#
- `README.txt`
- `saida_execucao_E1.txt`

## Autor
Nome: Gustavo de Carvalho Pinheiro das Neves
Matrícula: 903012
