# LAB_AED1_E2

## Disciplina
Algoritmos e Estruturas de Dados I – Laboratório

## Curso
Jogos Digitais – PUC Minas Lourdes

## Etapa
Entrega 2 – Matrizes e geração da masmorra

## Descrição
Este projeto consiste em uma aplicação console em C# do sistema **Dungeon Explorer**.

Nesta etapa, o sistema foi expandido para incluir a geração de um **mapa da masmorra**, utilizando uma matriz bidimensional.

O sistema agora possui duas partes principais:
- Cadastro de jogadores (vetores paralelos)
- Geração e exibição do mapa (matriz)

## Estruturas utilizadas

### Vetores
Foram utilizados vetores paralelos para armazenar os dados dos jogadores:

- ID
- Nome
- Vida
- Ataque
- Defesa
- Pontuação

Também foi utilizada uma variável de controle para a quantidade de jogadores cadastrados no servidor.

### Matriz
Utilizada para representar o mapa da masmorra

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
- `0` - Sair

## Observações sobre a implementação
- O sistema impede cadastro de IDs duplicados.
- Há controle de quantidade máxima de jogadores no servidor.
- A busca de jogadores é feita por ID.
- A remoção reorganiza os vetores, deslocando os jogadores seguintes uma posição para trás.
- Nesta versão, os atributos de vida, ataque e defesa estão sendo gerados com valores aleatórios para facilitar os testes.

## Arquivos da entrega
A entrega da etapa deve conter:

- projeto em C#
- `README.txt`
- `saida_execucao_E1.txt`

## Autor
Nome: Gustavo de Carvalho Pinheiro das Neves
Matrícula: 903012
