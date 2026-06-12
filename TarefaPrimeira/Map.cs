namespace TarefaPrimeira
{
    internal class Map
    {
        int linhas;
        int colunas;
        int playerLine;
        int playerRow;

        Random rb = new Random();

        char[,] map;
        Item[,] itemsMap = new Item[10, 10];
        Enemy[,] enemiesMap = new Enemy[10, 10];
        int[,] mapExploration = new int[10, 10];
        int[,] mapCodeExploration = new int[12, 12];

        float maxExploration = 0;
        int[] elementsCounter = new int[3]; // 0 - Inimigos, 1 - Itens, 2 - Obstaculos
        bool wasMapGenerated = false;

        public Map(int linhas = 10, int colunas = 10)
        {
            //this.linhas = linhas;
            //this.colunas = colunas;
            map = new char[linhas, colunas];
            Initialize();
        }

        public bool _WasMapGenerated
        {
            get { return wasMapGenerated; }
            set { wasMapGenerated = value; }
        }

        public int _Enemies
        {
            get { return elementsCounter[0]; }
            set { elementsCounter[0] = value; }
        }

        #region Map Manipulation

        public void DefineElement(int line, int row, char value)
        {
            map[line, row] = value;
        }

        public void DefineMapCodeExplorationElement(int line, int row, int value)
        {
            mapCodeExploration[line, row] = value;
        }

        public void DefineMapExplorationElement(int line, int row, int value)
        {
            mapExploration[line, row] = value;
        }

        public char ShowElement(int line, int row)
        {
            return map[line, row];
        }

        public int MapExplorationElement(int line, int row)
        {
            return mapExploration[line, row];
        }

        public int MapCodeExplorationElement(int line, int row)
        {
            return mapCodeExploration[line, row];
        }

        public int ItemPoints(int line, int row)
        {
            return itemsMap[line, row]._Points;
        }

        public int EnemyPoints(int line, int row)
        {
            return enemiesMap[line, row]._Points;
        }


        #endregion

        private void Initialize()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = '.';
                }
            }

            playerLine = 0;
            playerRow = 0;

            //GenerateElements();
        }

        public void GenerateElements()
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
                            enemiesMap[i, j] = new Enemy("E", 10, rb.Next(15, 26));

                            enemyCounter++;
                            mapCodeExploration[i + 1, j + 1] = 0;
                        }
                        else if (n >= 3 && n <= 6)
                        {
                            map[i, j] = 'I';
                            itemsMap[i, j] = new Item("I", rb.Next(5, 16));

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
                    if (x < 1 || y < 1 || x > map.GetLength(0) || y > map.GetLength(1))
                    {
                        Console.WriteLine("Espaço inválido! Escolha coordenadas livres [Linha, Coluna]");
                        x = int.Parse(Console.ReadLine());
                        y = int.Parse(Console.ReadLine());
                    }
                    else if (map[(x - 1), (y - 1)] != '.')
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
            }


            MostrarMapa();

            Console.WriteLine();
        }



        public void MostrarMapa()
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
                //for (int i = 0; i < mapCodeExploration.GetLength(0); i++)
                //{
                //    for (int j = 0; j < mapCodeExploration.GetLength(1); j++)
                //    {
                //        Console.Write(mapCodeExploration[i, j] + " ");
                //    }
                //    Console.WriteLine("");
                //}
            }
            Console.WriteLine("");
        }

        public void ContarElementos()
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

        private int ContarItensRecursivo(char[,] map, int linha, int coluna)
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

        public float Exploration(int exploredAreas)
        {
            return (exploredAreas / maxExploration) * 100;
        }

    }
}
