namespace TarefaPrimeira
{

    internal class Program
    {
        //static int option = -1;
        static int playersOnServe = 0, activePlayerIndex = -1;
        static Random rb = new Random();
        static int maxPlayers = 4;

        static int[] idPlayer = new int[maxPlayers];
        static string[] playerNames = new string[maxPlayers];
        static int[] playerLife = new int[maxPlayers];
        static int[] playerAttack = new int[maxPlayers];
        static int[] playerDefense = new int[maxPlayers];
        static int[] playerPoints = new int[maxPlayers];
        static int playerLine = -1;
        static int playerRow = -1;

        //Mapa
        static char[,] map = new char[10, 10];
        static int[,] mapExploration = new int[10, 10];
        static int[,] mapCodeExploration = new int[12, 12];
        static float maxExploration = 0;
        static int[] elementsCounter = new int[3]; // 0 - Inimigos, 1 - Itens, 2 - Obstaculos
        static bool wasMapGenerated = false, hasPlayBegun = false;

        static void Main(string[] args)
        {
            string option = "";
            bool endGame = false;

            while (endGame == false)
            {
                Console.WriteLine("===== DUNGEON EXPLORER =====");
                Console.WriteLine("1 - Cadastrar jogador");
                Console.WriteLine("2 - Listar jogadores");
                Console.WriteLine("3 - Buscar jogador por ID");
                Console.WriteLine("4 - Remover jogador");
                Console.WriteLine("5 - Gerar mapa da masmorra");
                Console.WriteLine("6 - Mostrar mapa");
                Console.WriteLine("7 - Movimentar jogador");
                Console.WriteLine("8 - Exibir Relatório de Exploração");
                Console.WriteLine("P - Pontuação Total");
                Console.WriteLine("E - Explorar área recursivamente");
                Console.WriteLine("0 – Sair");
                Console.WriteLine("");
                Console.WriteLine("Selecione a opção desejada");
                option = Console.ReadLine();
                //if (choice != "P")
                //{
                //    option = int.Parse(Console.ReadLine());
                //}
                Console.WriteLine("");


                if (option == "1") CadastrarJogador(); //Cadastrar Jogadores                
                else if (option == "2") ListarJogadores();//Listar jogadores                
                else if (option == "3") BuscarJogador(); //Buscar jogador por ID
                else if (option == "4") RemoverJogador(); //Remover jogador pelo ID 
                else if (option == "5") GerandoMapa(); //Gerando Mapa
                else if (option == "6") MostrarMapa(); //Mostrar Mapa
                else if (option == "7") MoverJogador(); //Movimentação do Player
                else if (option == "8") RelatorioExploracao(); //Apresenta relatório de exploração
                else if (option == "9") SecretReport(); //Função para testes, deixarei aqui para as entregas futuras
                else if (option == "P") PontuacaoTotal();
                else if (option == "E") DetectarAreaExploravel();
                else if (option == "0") endGame = true;
                else
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
                    if (wasMapGenerated == true) hasPlayBegun = true;
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
                for (int i = 0; i < mapCodeExploration.GetLength(0); i++)
                {
                    for (int j = 0; j < mapCodeExploration.GetLength(1); j++)
                    {
                        mapCodeExploration[i, j] = 1;
                    }
                }

                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        int n = rb.Next(1, 21);

                        if (n >= 11)
                        {
                            map[i, j] = '.';
                            mapCodeExploration[i + 1, j + 1] = 0;
                        }
                        else if (n <= 2)
                        {
                            map[i, j] = 'E';

                            enemyCounter++;
                            mapCodeExploration[i + 1, j + 1] = 0;
                        }
                        else if (n >= 3 && n <= 6)
                        {
                            map[i, j] = 'I';
                            itemCounter++;
                            mapCodeExploration[i + 1, j + 1] = 0;
                        }
                        else
                        {
                            map[i, j] = 'X';
                            obstaclesCounter++;


                        }

                        mapExploration[i, j] = 0; //Zera o mapa de exploração                        

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

            maxExploration = map.Length - obstaclesCounter; //Calcula o valor máximo da exploração
            wasMapGenerated = true;
            MostrarMapa();

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
                    mapExploration[(x - 1), (y - 1)] = 1;
                    playerLine = x - 1;
                    playerRow = y - 1;
                    canProcede = true;
                }
            }

            if (activePlayerIndex != -1) hasPlayBegun = true;
            MostrarMapa();

            Console.WriteLine();
        }

        private static void MostrarMapa()
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
                for (int i = 0; i < mapCodeExploration.GetLength(0); i++)
                {
                    for (int j = 0; j < mapCodeExploration.GetLength(1); j++)
                    {
                        Console.Write(mapCodeExploration[i, j] + " ");
                    }
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("");
        }

        private static void MoverJogador()
        {
            //int playerLine = 0, playerRow = 0;
            string moveDirection = "W"; //Usarei para entrar no while ou pulá-lo caso os requisitos não sejam atendidos


            MostrarMapa();

            if (!wasMapGenerated)
            {
                moveDirection = "NoMap";

            }
            if (activePlayerIndex < 0 && moveDirection != "NoMap")
            {
                Console.WriteLine("Não há jogador ativo! Escolha um jogador primeiro");
                moveDirection = "ESC";
            }

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 'P')
                    {
                        playerLine = i;
                        playerRow = j;
                        mapExploration[i, j] = 1;
                        //mapCodeExploration[i + 1, j + 1] = 1;
                    }
                }
            }

            Console.WriteLine();


            while (moveDirection == "W" || moveDirection == "A" || moveDirection == "S" || moveDirection == "D"
                || moveDirection == "w" || moveDirection == "a" || moveDirection == "s" || moveDirection == "d")
            {
                Console.WriteLine("Movimente o jogador [W,A,S,D] ou pressione qualquer outra tecla para sair");
                moveDirection = Console.ReadLine();


                if (moveDirection == "W" || moveDirection == "w")
                {
                    if (playerLine - 1 >= 0)
                    {
                        if (map[playerLine - 1, playerRow] != 'X')
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
                            mapCodeExploration[playerLine + 1, playerRow + 1] = 1;
                            map[playerLine - 1, playerRow] = 'P';
                            mapExploration[playerLine - 1, playerRow] = 1;
                            playerLine--;

                        }
                        else
                        {
                            Console.WriteLine("Movimento Inválido!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Movimento Inválido!");
                    }
                }
                else if (moveDirection == "S" || moveDirection == "s")
                {
                    if (playerLine + 1 < map.GetLength(0))
                    {
                        if (map[playerLine + 1, playerRow] != 'X')
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
                            mapCodeExploration[playerLine + 1, playerRow + 1] = 1;
                            map[playerLine + 1, playerRow] = 'P';
                            mapExploration[playerLine + 1, playerRow] = 1;
                            playerLine++;

                        }
                        else
                        {
                            Console.WriteLine("Movimento Inválido!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Movimento Inválido!");
                    }
                }
                else if (moveDirection == "A" || moveDirection == "a")
                {
                    if (playerRow - 1 >= 0)
                    {
                        if (map[playerLine, playerRow - 1] != 'X')
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
                            mapCodeExploration[playerLine + 1, playerRow + 1] = 1;
                            map[playerLine, playerRow - 1] = 'P';
                            mapExploration[playerLine, playerRow - 1] = 1;
                            playerRow--;

                        }
                        else
                        {
                            Console.WriteLine("Movimento Inválido!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Movimento Inválido!");
                    }
                }
                else if (moveDirection == "D" || moveDirection == "d")
                {
                    if (playerRow + 1 < map.GetLength(1))
                    {
                        if (map[playerLine, playerRow + 1] != 'X')
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
                            mapCodeExploration[playerLine + 1, playerRow + 1] = 1;
                            map[playerLine, playerRow + 1] = 'P';
                            mapExploration[playerLine, playerRow + 1] = 1;
                            playerRow++;

                        }
                        else
                        {
                            Console.WriteLine("Movimento Inválido!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Movimento Inválido!");
                    }
                }

                MostrarMapa();
            }

            Console.WriteLine("");
        }

        #region Realtorio de Exploracao
        private static void RelatorioExploracao()
        {
            if (hasPlayBegun == false)
            {
                Console.WriteLine("O jogo ainda não começou! Gere o mapa e defina o jogador primeiro");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("===== RELATÓRIO DA EXPLORAÇÃO =====");
                Console.WriteLine();

                ContarElementos(0, map);
                PercentualExploracao();
                AvaliarSituacaoJogador();

                Console.WriteLine();
            }

        }

        private static void ContarElementos(int elementCode, char[,] map)
        {
            for (int i = 0; i < elementsCounter.Length; i++)
            {
                elementsCounter[i] = 0;
            }

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    //if (map[i, j] == 'E') elementsCounter[0]++;
                    //else if (map[i, j] == 'I') elementsCounter[1]++;
                    if (map[i, j] == 'X') elementsCounter[2]++;
                }
            }

            elementsCounter[0] = ContarInimigosRecursivo(map, 0, 0);
            elementsCounter[1] = ContarItensRecursivo(map, 0, 0);

            Console.WriteLine("Inimigos restantes: " + elementsCounter[0]);
            Console.WriteLine("Itens restantes: " + elementsCounter[1]);
            Console.WriteLine("Obstáculos no mapa: " + elementsCounter[2]);
        }

        private static int ContarInimigosRecursivo(char[,] map, int linha, int coluna)
        {

            if (coluna < map.GetLength(1) - 1)
            {
                coluna++;
            }
            else
            {
                linha++;
                coluna = 0;
            }


            if (linha >= map.GetLength(0))
            {
                return 0;
            }
            else if (map[linha, coluna] == 'E')
            {
                return 1 + ContarInimigosRecursivo(map, linha, coluna);
            }
            else
            {
                return ContarInimigosRecursivo(map, linha, coluna);
            }

        }

        private static int ContarItensRecursivo(char[,] map, int linha, int coluna)
        {

            if (coluna < map.GetLength(1) - 1)
            {
                coluna++;
            }
            else
            {
                linha++;
                coluna = 0;
            }


            if (linha >= map.GetLength(0))
            {
                return 0;
            }
            else if (map[linha, coluna] == 'I')
            {
                return 1 + ContarItensRecursivo(map, linha, coluna);
            }
            else
            {
                return ContarItensRecursivo(map, linha, coluna);
            }

        }

        private static void PercentualExploracao()
        {
            int exploredAreas = 0;
            float percentage = 0;

            for (int i = 0; i < mapExploration.GetLength(0); i++)
            {
                for (int j = 0; j < mapExploration.GetLength(1); j++)
                {
                    exploredAreas += mapExploration[i, j];
                }
            }

            percentage = (exploredAreas / maxExploration) * 100;

            Console.WriteLine("Percentual explorado: " + percentage.ToString("F1") + "%");
        }

        private static void AvaliarSituacaoJogador()
        {
            string playerLifeSituation = "Vida moderada", exploration = "Exploração estável";

            if (playerLife[activePlayerIndex] >= 80) playerLifeSituation = "Vida alta";
            else if (playerLife[activePlayerIndex] < 40) playerLifeSituation = "Vida crítica";
            else playerLifeSituation = "Vida moderada";
            Console.WriteLine("Situação da vida: " + playerLifeSituation);

            if (playerPoints[activePlayerIndex] >= 100 && elementsCounter[0] <= 2) exploration = "Exploração excelente";
            else if (playerPoints[activePlayerIndex] >= 50) exploration = "Exploração estável";
            else exploration = "Exploração em risco";
            Console.WriteLine("Situação do desempenho: " + exploration);
        }

        private static void SecretReport()//Está aqui para testes apenas
        {
            for (int i = 0; i < mapExploration.GetLength(0); i++)
            {
                for (int j = 0; j < mapExploration.GetLength(1); j++)
                {
                    Console.Write(mapExploration[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        #endregion

        #region Total Points
        private static void PontuacaoTotal()
        {

            int x = SomarPontuacoesRecursivo(playerPoints, playersOnServe - 1);
            Console.WriteLine("Pontuação total: " + x);
            Console.WriteLine();
        }

        private static int SomarPontuacoesRecursivo(int[] totalPlayerPoints,
            int players)
        {
            if (players < 0)
            {
                return 0;

            }
            else
            {
                return totalPlayerPoints[players] + SomarPontuacoesRecursivo(totalPlayerPoints, players - 1);
            }
        }

        #endregion

        private static int ContarPerigoArredores(char[,] map, int linha, int coluna)
        {

            if (coluna < map.GetLength(1) - 1)
            {
                coluna++;
            }
            else
            {
                linha++;
                coluna = 0;
            }


            if (linha >= map.GetLength(0))
            {
                return 0;
            }
            else if (map[linha, coluna] == 'I')
            {
                return 1 + ContarPerigoArredores(map, linha, coluna);
            }
            else
            {
                return ContarPerigoArredores(map, linha, coluna);
            }

        }

        private static void DetectarAreaExploravel()
        {

            int[,] tempMap = new int[12, 12];

            for (int i = 0; i < tempMap.GetLength(0); i++)
            {
                for (int j = 0; j < tempMap.GetLength(1); j++)
                {
                    //int x = mapCodeExploration[i, j];
                    tempMap[i, j] = mapCodeExploration[i, j];
                    Console.Write(tempMap[i, j] + " ");
                }
                Console.WriteLine("");
            }

            int counter = AreaExploravel(playerLine+1, playerRow+1, tempMap);
            Console.WriteLine("Explorável: " + (counter - 1));

        }

        private static int AreaExploravel(int playerL, int playerR, int[,] map)
        {

            Console.WriteLine("Linha: " + playerL);
            Console.WriteLine("Coluna: " + playerR);
            Console.WriteLine();

            if (map[playerL, playerR] == 1)
            {
                Console.WriteLine("FUI CHAMADO");
                return 0;
            }
            else
            {
                map[playerL, playerR] = 1;

                return 1 + AreaExploravel(playerL, playerR - 1, map) +
                   AreaExploravel(playerL, playerR + 1, map) +
                   AreaExploravel(playerL + 1, playerR, map) +
                   AreaExploravel(playerL - 1, playerR, map);
            }


        }

    }
}
