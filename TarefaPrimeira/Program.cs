namespace TarefaPrimeira
{


    internal class Program
    {
        static int option = -1;
        static int playersOnServe = 0, activePlayerIndex = -1;
        static Random rb = new Random();
        static int maxPlayers = 4;

        static int[] idPlayer = new int[maxPlayers];
        static string[] playerNames = new string[maxPlayers];
        static int[] playerLife = new int[maxPlayers];
        static int[] playerAttack = new int[maxPlayers];
        static int[] playerDefense = new int[maxPlayers];
        static int[] playerPoints = new int[maxPlayers];

        //Mapa
        static char[,] map = new char[10, 10];
        static bool wasMapGenerated = false;

        static void Main(string[] args)
        {

            while (option != 0)
            {
                Console.WriteLine("===== DUNGEON EXPLORER =====");
                Console.WriteLine("1 - Cadastrar jogador");
                Console.WriteLine("2 - Listar jogadores");
                Console.WriteLine("3 - Buscar jogador por ID");
                Console.WriteLine("4 - Remover jogador");
                Console.WriteLine("5 - Gerar mapa da masmorra");
                Console.WriteLine("6 - Mostrar mapa");
                Console.WriteLine("7 - Movimentar jogador");
                Console.WriteLine("0 – Sair");
                Console.WriteLine("");
                Console.WriteLine("Selecione a opção desejada");
                option = int.Parse(Console.ReadLine());
                Console.WriteLine("");


                if (option == 1) CadastrarJogador(); //Cadastrar Jogadores                
                else if (option == 2) ListarJogadores();//Listar jogadores                
                else if (option == 3) BuscarJogador(); //Buscar jogador por ID
                else if (option == 4) RemoverJogador(); //Remover jogador pelo ID 
                else if (option == 5) GerandoMapa(); //Gerando Mapa
                else if (option == 6) ShowMap(); //Mostrar Mapa
                else if (option == 7) MovePlayer(); //Movimentação do Player
                else if (option != 0)
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA!");
                    Console.WriteLine("Selecione a opção desejada");
                    Console.WriteLine("");
                }
            }

        }

        private static void CadastrarJogador()
        {
            if (playersOnServe >= maxPlayers)
            {
                Console.WriteLine("Número máximo de jogadores no servidor atingido!");
                Console.WriteLine("Remova um jogador para poder adicionar um novo");
                Console.WriteLine("");
            }
            else
            {
                int index = -1;

                Console.WriteLine("===== Jogador " + (playersOnServe + 1) + " =====");
                Console.WriteLine("");
                Console.WriteLine("Insira o ID do jogador [Número inteiro maior que zero]: ");
                int idCheck = int.Parse(Console.ReadLine());   
                

                for (int i = 0; i < maxPlayers; i++)
                {

                    if (idCheck == idPlayer[i])
                    {
                        i = -1;
                        Console.WriteLine("ID em uso! Digite um novo ID");
                        idCheck = int.Parse(Console.ReadLine());
                    }
                }

                index = playersOnServe;

                idPlayer[index] = idCheck;

                Console.WriteLine("Digite o nome do Personagem");
                playerNames[index] = Console.ReadLine();

                Console.WriteLine("Digite a Vida do Personagem");
                //playerLife[index] = int.Parse(Console.ReadLine());
                playerLife[index] = rb.Next(1, 101);

                Console.WriteLine("Digite o Ataque do Personagem");
                //playerAttack[index] = int.Parse(Console.ReadLine());
                playerAttack[index] = rb.Next(1, 11);

                Console.WriteLine("Digite o Defesa do Personagem");
                //playerDefense[index] = int.Parse(Console.ReadLine());
                playerDefense[index] = rb.Next(1, 11);

                Console.WriteLine("");

                playersOnServe++;
            }
        }

        private static void ListarJogadores()
        {
            for (int i = 0; i < playersOnServe; i++)
            {
                Console.WriteLine("===== Jogador " + (1 + i) + " =====");
                Console.WriteLine("");
                Console.WriteLine("ID: " + idPlayer[i]);
                Console.WriteLine("Nome: " + playerNames[i]);
                Console.WriteLine("Vida: " + playerLife[i]);
                Console.WriteLine("Ataque: " + playerAttack[i]);
                Console.WriteLine("Defesa: " + playerDefense[i]);
                Console.WriteLine("Pontos: " + playerPoints[i]);
                Console.WriteLine("");
            }

            if (playersOnServe <= 0)
            {
                Console.WriteLine("Não há jogadores neste servidor!");
                Console.WriteLine("");
            }
        }

        private static void BuscarJogador()
        {
            Console.WriteLine("Digite o ID do jogador que você procura:");
            int searchID = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            bool hasFound = false;

            for (int i = 0; i < playersOnServe; i++)
            {
                if (idPlayer[i] == searchID)
                {
                    Console.WriteLine("===== Jogador " + (i + 1) + " =====");
                    Console.WriteLine("");
                    Console.WriteLine("ID: " + idPlayer[i]);
                    Console.WriteLine("Nome: " + playerNames[i]);
                    Console.WriteLine("Vida: " + playerLife[i]);
                    Console.WriteLine("Ataque: " + playerAttack[i]);
                    Console.WriteLine("Defesa: " + playerDefense[i]);
                    Console.WriteLine("Pontos: " + playerPoints[i]);
                    Console.WriteLine("");
                    hasFound = true;
                    activePlayerIndex = i;
                }
            }

            if (!hasFound)
            {
                Console.WriteLine("Jogador NÃO encontrado");
                Console.WriteLine("");
            }
        }

        private static void RemoverJogador()
        {
            Console.WriteLine("Digite o ID do jogador que será removido:");
            int searchID = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            bool hasFound = false;
            int index = -1;

            for (int i = 0; i < playersOnServe; i++)
            {
                if (idPlayer[i] == searchID)
                {
                    hasFound = true;
                    index = i;
                }
            }

            if (!hasFound)
            {
                Console.WriteLine("Jogador NÃO encontrado");
                Console.WriteLine("");
            }
            else
            {
                for (int i = index; i < playersOnServe; i++)
                {
                    if ((i + 1) < playersOnServe)
                    {
                        idPlayer[i] = idPlayer[i + 1];
                        playerNames[i] = playerNames[i + 1];
                        playerLife[i] = playerLife[i + 1];
                        playerAttack[i] = playerAttack[i + 1];
                        playerDefense[i] = playerDefense[i + 1];
                        playerPoints[i] = playerPoints[i + 1];
                    }
                    else
                    {
                        idPlayer[i] = 0;
                        playerNames[i] = "";
                        playerLife[i] = 0;
                        playerAttack[i] = 0;
                        playerDefense[i] = 0;
                        playerPoints[i] = 0;
                    }
                }

                Console.WriteLine("Jogador removido");
                Console.WriteLine("");
                playersOnServe--;
            }
        }

        private static void GerandoMapa()
        {
            int enemyCounter = 0, itemCounter = 0, obstaclesCounter = 0;
            bool canProcede = false;

            Console.WriteLine();

            //Gerando o Mapa
            while (!canProcede)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        int n = rb.Next(1, 21);

                        if (n >= 11)
                        {
                            map[i, j] = '.';
                        }
                        else if (n <= 2)
                        {
                            map[i, j] = 'E';
                            enemyCounter++;
                        }
                        else if (n >= 3 && n <= 6)
                        {
                            map[i, j] = 'I';
                            itemCounter++;
                        }
                        else
                        {
                            map[i, j] = 'X';
                            obstaclesCounter++;
                        }

                        //Fazendo o mapa ser gerado novamente caso falhe na conferência
                        if ((i == map.GetLength(0) - 1) && (j == map.GetLength(1) - 1))
                        {
                            if (enemyCounter < 5 || itemCounter < 6 || obstaclesCounter < 10)
                            {
                                enemyCounter = 0;
                                itemCounter = 0;
                                obstaclesCounter = 0;
                            }
                            else
                            {
                                canProcede = true;
                            }
                        }
                    }
                }
            }
            
            wasMapGenerated = true;
            ShowMap();

            Console.WriteLine();

            canProcede = false;
            Console.WriteLine("Escolha as coordenadas do Player [Linha, Coluna]");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            while (canProcede == false)
            {
                if (map[(x - 1), (y - 1)] != '.' || x < 1 || y < 1
                    || x > map.GetLength(0) || y > map.GetLength(1))
                {
                    Console.WriteLine("Espaço inválido! Escolha coordenadas livres [Linha, Coluna]");
                    x = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());
                }
                else
                {
                    map[(x - 1), (y - 1)] = 'P';
                    canProcede = true;
                }
            }

            ShowMap();

            Console.WriteLine();
        }

        private static void ShowMap()
        {
            if (wasMapGenerated == false)
            {
                Console.WriteLine("O mapa ainda não foi gerado!");
                Console.WriteLine("Por favor, gere o mapa primeiro");
            }
            else
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            for (int k = 0; k < map.GetLength(1); k++)
                            {
                                if (k == 0) Console.Write("    " + (k + 1));
                                else if (k == (map.GetLength(1) - 1)) Console.Write("  " + (k + 1));
                                else Console.Write("   " + (k + 1));
                            }

                            Console.WriteLine();
                            Console.WriteLine();
                        }

                        if (j == 0 && i != (map.GetLength(0) - 1))
                        {
                            Console.Write((i + 1) + "   " + map[i, j] + "  ");
                        }
                        else if (i == (map.GetLength(0) - 1) && j == 0)
                        {
                            Console.Write((i + 1) + "  " + map[i, j] + "  ");
                        }
                        else
                        {
                            Console.Write(" " + map[i, j] + "  ");
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            Console.WriteLine("");
        }

        private static void MovePlayer()
        {
            int playerLine = 0, playerRow = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 'P')
                    {
                        playerLine = i;
                        playerRow = j;
                    }
                }
            }

            Console.WriteLine("X = " + playerLine + " | Y = " + playerRow);

            ShowMap();
            if (!wasMapGenerated)
            {
                Console.WriteLine();
                return;
            }
            if (activePlayerIndex < 0)
            {
                Console.WriteLine("Não há jogador ativo! Escolha um jogador primeiro");
                Console.WriteLine();
                return;
            }

            Console.WriteLine();
            string moveDirection = "W";

            while (moveDirection == "W" || moveDirection == "A" || moveDirection == "S" || moveDirection == "D"
                || moveDirection == "w" || moveDirection == "a" || moveDirection == "s" || moveDirection == "d")
            {
                Console.WriteLine("Movimente o jogador [W,A,S,D] ou pressione qualquer outra tecla para sair");
                moveDirection = Console.ReadLine();


                if (moveDirection == "W" || moveDirection == "w")
                {
                    if (map[playerLine - 1, playerRow] != 'X' && playerLine - 1 >= 0)
                    {
                        if (map[playerLine - 1, playerRow] == 'I')
                        {
                            playerPoints[activePlayerIndex] += 10;
                            Console.WriteLine("Peguei um item! (+10 pts)");
                            Console.WriteLine();
                        }
                        else if (map[playerLine - 1, playerRow] == 'E')
                        {
                            playerPoints[activePlayerIndex] += 20;
                            Console.WriteLine("Matei um inimigo! (+20 pts)");
                            Console.WriteLine();
                        }

                        map[playerLine, playerRow] = '.';
                        map[playerLine - 1, playerRow] = 'P';
                        playerLine--;
                    }
                    else
                    {
                        Console.WriteLine("Movimento Inválido!");
                    }
                }
                else if (moveDirection == "S" || moveDirection == "s")
                {
                    if (map[playerLine + 1, playerRow] != 'X' && playerLine + 1 < map.GetLength(0))
                    {
                        if (map[playerLine + 1, playerRow] == 'I')
                        {
                            playerPoints[activePlayerIndex] += 10;
                            Console.WriteLine("Peguei um item! (+10 pts)");
                            Console.WriteLine();
                        }
                        else if (map[playerLine + 1, playerRow] == 'E')
                        {
                            playerPoints[activePlayerIndex] += 20;
                            Console.WriteLine("Matei um inimigo! (+20 pts)");
                            Console.WriteLine();
                        }

                        map[playerLine, playerRow] = '.';
                        map[playerLine + 1, playerRow] = 'P';
                        playerLine++;
                    }
                    else
                    {
                        Console.WriteLine("Movimento Inválido!");
                    }
                }
                else if (moveDirection == "A" || moveDirection == "a")
                {
                    if (map[playerLine, playerRow - 1] != 'X' && playerRow - 1 >= 0)
                    {
                        if (map[playerLine, playerRow - 1] == 'I')
                        {
                            playerPoints[activePlayerIndex] += 10;
                            Console.WriteLine("Peguei um item! (+10 pts)");
                            Console.WriteLine();
                        }
                        else if (map[playerLine, playerRow - 1] == 'E')
                        {
                            playerPoints[activePlayerIndex] += 20;
                            Console.WriteLine("Matei um inimigo! (+20 pts)");
                            Console.WriteLine();
                        }

                        map[playerLine, playerRow] = '.';
                        map[playerLine, playerRow - 1] = 'P';
                        playerRow--;
                    }
                    else
                    {
                        Console.WriteLine("Movimento Inválido!");
                    }
                }
                else if (moveDirection == "D" || moveDirection == "d")
                {
                    if (map[playerLine, playerRow + 1] != 'X' && playerRow + 1 < map.GetLength(1))
                    {
                        if (map[playerLine, playerRow + 1] == 'I')
                        {
                            playerPoints[activePlayerIndex] += 10;
                            Console.WriteLine("Peguei um item! (+10 pts)");
                            Console.WriteLine();
                        }
                        else if (map[playerLine, playerRow + 1] == 'E')
                        {
                            playerPoints[activePlayerIndex] += 20;
                            Console.WriteLine("Matei um inimigo! (+20 pts)");
                            Console.WriteLine();
                        }

                        map[playerLine, playerRow] = '.';
                        map[playerLine, playerRow + 1] = 'P';
                        playerRow++;
                    }
                    else
                    {
                        Console.WriteLine("Movimento Inválido!");
                    }
                }

                ShowMap();
            }

            



            Console.WriteLine("");
        }

        
    }
}
