namespace TarefaPrimeira
{

    internal class Program
    {
        //static int option = -1;
        static int playersOnServe = 0, activePlayerIndex = -1;
        static Random rb = new Random();
        static int maxPlayers = 4;

        static Player[] players = new Player[maxPlayers];
        static int playerLine = -1;
        static int playerRow = -1;

        //Mapa
        static Map mapa = new Map();

        static char[,] map = new char[10, 10];
        //static Item[,] itemsMap = new Item[10, 10];
        //static Enemy[,] enemiesMap = new Enemy[10, 10];
        //static int[,] mapExploration = new int[10, 10];
        //static int[,] mapCodeExploration = new int[12, 12];
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
                Console.WriteLine("9 - Explorar área recursivamente");
                Console.WriteLine("10 - Pontuação Total");
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
                else if (option == "X") SecretReport(); //Função para testes, deixarei aqui para as entregas futuras
                else if (option == "9") ExplorarRecursivamente();
                else if (option == "10") PontuacaoTotal();
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
                    if (players[i] != null)
                    {
                        if (idCheck == players[i]._ID)
                        {
                            i = -1;
                            Console.WriteLine("ID em uso! Digite um novo ID");
                            idCheck = int.Parse(Console.ReadLine());
                        }
                    }
                }

                index = playersOnServe;

                Console.WriteLine("Digite o nome do Personagem");
                string name = Console.ReadLine();

                Console.WriteLine("Digite a Vida do Personagem");
                //playerLife[index] = int.Parse(Console.ReadLine());
                int life = rb.Next(1, 101);

                Console.WriteLine("Digite o Ataque do Personagem");
                //playerAttack[index] = int.Parse(Console.ReadLine());
                int attack = rb.Next(1, 11);

                Console.WriteLine("Digite o Defesa do Personagem");
                //playerDefense[index] = int.Parse(Console.ReadLine());
                int defense = rb.Next(1, 11);

                players[index] = new Player(idCheck, name, life, attack, defense);

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
                players[i].ExibirDados();
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
                if (players[i]._ID == searchID)
                {
                    Console.WriteLine("===== Jogador " + (i + 1) + " =====");
                    Console.WriteLine("");
                    players[i].ExibirDados();
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
                if (players[i]._ID == searchID)
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
                        players[i] = players[i + 1];

                        //idPlayer[i] = idPlayer[i + 1];
                        //playerNames[i] = playerNames[i + 1];
                        //playerLife[i] = playerLife[i + 1];
                        //playerAttack[i] = playerAttack[i + 1];
                        //playerDefense[i] = playerDefense[i + 1];
                        //playerPoints[i] = playerPoints[i + 1];
                    }
                    else
                    {
                        players[i] = new Player();


                        //idPlayer[i] = 0;
                        //playerNames[i] = "";
                        //playerLife[i] = 0;
                        //playerAttack[i] = 0;
                        //playerDefense[i] = 0;
                        //playerPoints[i] = 0;
                    }
                }

                Console.WriteLine("Jogador removido");
                Console.WriteLine("");
                playersOnServe--;
            }
        }

        private static void GerandoMapa()
        {

            mapa.GenerateElements();
            if (activePlayerIndex != -1) hasPlayBegun = true;

            Console.WriteLine();
        }

        private static void MostrarMapa()
        {
            mapa.MostrarMapa();

        }

        private static void MoverJogador()
        {
            //int playerLine = 0, playerRow = 0;
            string moveDirection = "W"; //Usarei para entrar no while ou pulá-lo caso os requisitos não sejam atendidos


            MostrarMapa();

            if (!mapa._WasMapGenerated)
            {
                moveDirection = "NoMap";

            }
            if (activePlayerIndex < 0 && moveDirection != "NoMap")
            {
                Console.WriteLine("Não há jogador ativo! Escolha um jogador primeiro");
                moveDirection = "ESC";
            }

            //mapa.DetectPlayer();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mapa.ShowElement(i, j) == 'P')
                    {
                        playerLine = i;
                        playerRow = j;
                        mapa.DefineMapExplorationElement(i, j, 1);
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
                        if (mapa.ShowElement(playerLine - 1, playerRow) != 'X')
                        {
                            if (mapa.ShowElement(playerLine - 1, playerRow) == 'I')
                            {
                                players[activePlayerIndex]._Points = mapa.ItemPoints(playerLine - 1, playerRow);
                                Console.WriteLine("Peguei um item! (+" + mapa.ItemPoints(playerLine - 1, playerRow) + " pts)");
                                Console.WriteLine();
                            }
                            else if (mapa.ShowElement(playerLine - 1, playerRow) == 'E')
                            {
                                players[activePlayerIndex]._Points = mapa.EnemyPoints(playerLine - 1, playerRow);
                                Console.WriteLine("Matei um inimigo! (+" + mapa.EnemyPoints(playerLine - 1, playerRow) + " pts)");
                                Console.WriteLine();
                            }

                            mapa.DefineElement(playerLine, playerRow, '.');
                            mapa.DefineMapCodeExplorationElement(playerLine + 1, playerRow + 1, 1);
                            mapa.DefineElement(playerLine - 1, playerRow, 'P');
                            mapa.DefineMapExplorationElement(playerLine - 1, playerRow, 1);
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
                    if (playerLine + 1 < 10)
                    {
                        if (mapa.ShowElement(playerLine + 1, playerRow) != 'X')
                        {
                            if (mapa.ShowElement(playerLine + 1, playerRow) == 'I')
                            {
                                players[activePlayerIndex]._Points = mapa.ItemPoints(playerLine + 1, playerRow);
                                Console.WriteLine("Peguei um item! (+" + mapa.ItemPoints(playerLine + 1, playerRow) + "pts)");
                                Console.WriteLine();
                            }
                            else if (mapa.ShowElement(playerLine + 1, playerRow) == 'E')
                            {
                                players[activePlayerIndex]._Points = mapa.EnemyPoints(playerLine + 1, playerRow);
                                Console.WriteLine("Matei um inimigo! (+" + mapa.EnemyPoints(playerLine + 1, playerRow) + " pts)");
                                Console.WriteLine();
                            }

                            mapa.DefineElement(playerLine, playerRow, '.');
                            mapa.DefineMapCodeExplorationElement(playerLine + 1, playerRow + 1, 1);
                            mapa.DefineElement(playerLine + 1, playerRow, 'P');
                            mapa.DefineMapExplorationElement(playerLine + 1, playerRow, 1);
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
                        if (mapa.ShowElement(playerLine, playerRow - 1) != 'X')
                        {
                            if (mapa.ShowElement(playerLine, playerRow - 1) == 'I')
                            {
                                players[activePlayerIndex]._Points = mapa.ItemPoints(playerLine, playerRow - 1);
                                Console.WriteLine("Peguei um item! (+" + mapa.ItemPoints(playerLine, playerRow - 1) + "pts)");
                                Console.WriteLine();
                            }
                            else if (mapa.ShowElement(playerLine, playerRow - 1) == 'E')
                            {
                                players[activePlayerIndex]._Points = mapa.EnemyPoints(playerLine, playerRow - 1);
                                Console.WriteLine("Matei um inimigo! (+" + mapa.EnemyPoints(playerLine, playerRow - 1) + " pts)");
                                Console.WriteLine();
                            }

                            mapa.DefineElement(playerLine, playerRow, '.');
                            mapa.DefineMapCodeExplorationElement(playerLine + 1, playerRow + 1, 1);
                            mapa.DefineElement(playerLine, playerRow - 1, 'P');
                            mapa.DefineMapExplorationElement(playerLine, playerRow - 1, 1);
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
                    if (playerRow + 1 < 10)
                    {
                        if (mapa.ShowElement(playerLine, playerRow + 1) != 'X')
                        {
                            if (mapa.ShowElement(playerLine, playerRow + 1) == 'I')
                            {
                                players[activePlayerIndex]._Points = mapa.ItemPoints(playerLine, playerRow + 1);
                                Console.WriteLine("Peguei um item! (+" + mapa.ItemPoints(playerLine, playerRow + 1) + "pts)");
                                Console.WriteLine();
                            }
                            else if (mapa.ShowElement(playerLine, playerRow + 1) == 'E')
                            {
                                players[activePlayerIndex]._Points = mapa.EnemyPoints(playerLine, playerRow + 1);
                                Console.WriteLine("Matei um inimigo! (+" + mapa.EnemyPoints(playerLine, playerRow + 1) + " pts)");
                                Console.WriteLine();
                            }

                            mapa.DefineElement(playerLine, playerRow, '.');
                            mapa.DefineMapCodeExplorationElement(playerLine + 1, playerRow + 1, 1);
                            mapa.DefineElement(playerLine, playerRow + 1, 'P');
                            mapa.DefineMapExplorationElement(playerLine, playerRow + 1, 1);
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

                mapa.ContarElementos();
                PercentualExploracao();
                AvaliarSituacaoJogador();

                Console.WriteLine();
            }

        }

        private static void ContarElementos(char[,] map)
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
            //float percentage = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    exploredAreas += mapa.MapExplorationElement(i, j);
                }
            }

            //percentage = (exploredAreas / maxExploration) * 100;

            Console.WriteLine("Percentual explorado: " + mapa.Exploration(exploredAreas).ToString("F1") + "%");
        }

        private static void AvaliarSituacaoJogador()
        {
            string playerLifeSituation = "Vida moderada", exploration = "Exploração estável";

            if (players[activePlayerIndex]._Life >= 80) playerLifeSituation = "Vida alta";
            else if (players[activePlayerIndex]._Life < 40) playerLifeSituation = "Vida crítica";
            else playerLifeSituation = "Vida moderada";
            Console.WriteLine("Situação da vida: " + playerLifeSituation);

            if (players[activePlayerIndex]._Points >= 100 && elementsCounter[0] <= 2) exploration = "Exploração excelente";
            else if (players[activePlayerIndex]._Points >= 50) exploration = "Exploração estável";
            else exploration = "Exploração em risco";
            Console.WriteLine("Situação do desempenho: " + exploration);
        }

        private static void SecretReport()//Está aqui para testes apenas
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(mapa.MapExplorationElement(i, j) + " ");
                }
                Console.WriteLine();
            }
        }

        #endregion

        #region Total Points
        private static void PontuacaoTotal()
        {

            int x = SomarPontuacoesRecursivo(players, playersOnServe - 1);
            Console.WriteLine("Pontuação total: " + x);
            Console.WriteLine();
        }

        private static int SomarPontuacoesRecursivo(Player[] totalPlayerPoints, int players)
        {
            if (players < 0)
            {
                return 0;

            }
            else
            {
                return totalPlayerPoints[players]._Points + SomarPontuacoesRecursivo(totalPlayerPoints, players - 1);
            }
        }

        #endregion
                

        private static void ExplorarRecursivamente()
        {

            int[,] tempMap = new int[12, 12];

            for (int i = 0; i < tempMap.GetLength(0); i++)
            {
                for (int j = 0; j < tempMap.GetLength(1); j++)
                {
                    //int x = mapCodeExploration[i, j];
                    tempMap[i, j] = mapa.MapCodeExplorationElement(i, j);
                }
            }

            int counter = AreaExploravel(playerLine + 1, playerRow + 1, tempMap);
            Console.WriteLine();
            Console.WriteLine("===== EXPLORAÇÃO RECURSIVA DA ÁREA =====");
            Console.WriteLine("Posição inicial: " + "[" + (playerLine + 1) + "]" + "[" + (playerRow + 1) + "]");
            Console.WriteLine("Células alcançadas a partir da posição: " + (counter - 1));
            Console.WriteLine();

        }

        private static int AreaExploravel(int playerL, int playerR, int[,] map)
        {


            if (map[playerL, playerR] == 1)
            {
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
