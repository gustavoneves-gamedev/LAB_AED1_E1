using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        bool wasMapGenerated = false, hasPlayBegun = false;

        public Map(int linhas = 10, int colunas = 10)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            map = new char[linhas, colunas];
            Initialize();
        }
        
        public void DefinirCelular(int line, int row, char value)
        {
            map[line, row] = value;
        }

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

                
                MostrarMapa();

                Console.WriteLine();
            }

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
    }
}
