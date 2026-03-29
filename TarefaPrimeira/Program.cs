namespace TarefaPrimeira
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int option = -1;
            int playersOnServe = 0;
            Random rb = new Random();

            int maxPlayers = 4;

            int[] idPlayer = new int[maxPlayers];
            string[] playerNames = new string[maxPlayers];
            int[] playerLife = new int[maxPlayers];
            int[] playerAttack = new int[maxPlayers];
            int[] playerDefense = new int[maxPlayers];
            int[] playerPoints = new int[maxPlayers];

            char[,] map = new char[10, 10];

            while (option != 0)
            {
                Console.WriteLine("===== DUNGEON EXPLORER =====");
                Console.WriteLine("1 - Cadastrar jogador");
                Console.WriteLine("2 - Listar jogadores");
                Console.WriteLine("3 - Buscar jogador por ID");
                Console.WriteLine("4 - Remover jogador");
                Console.WriteLine("5 - Gerar mapa da masmorra");
                Console.WriteLine("6 - Mostrar mapa");
                Console.WriteLine("0 – Sair");
                Console.WriteLine("");
                Console.WriteLine("Selecione a opção desejada");
                option = int.Parse(Console.ReadLine());
                Console.WriteLine("");


                if (option == 1)
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
                else if (option == 2)
                {
                    //Listar jogadores
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
                else if (option == 3)
                {
                    //Buscar jogador por ID
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
                        }
                    }

                    if (!hasFound)
                    {
                        Console.WriteLine("Jogador NÃO encontrado");
                        Console.WriteLine("");
                    }
                }
                else if (option == 4)
                {
                    //Remover jogador pelo ID                    
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
                else if (option == 5)
                {
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            int n = rb.Next(1, 11);

                            if (n >= 4) map[i, j] = '.';
                            else if (n == 1) map[i, j] = 'E';
                            else if (n == 2) map[i, j] = 'X';
                            else map[i, j] = 'I';

                            if (i == 0 && j == 0)
                            {
                                for (int k = 0; k < map.GetLength(1); k++)
                                {
                                    if (k == 0) Console.Write("   " + (k + 1));
                                    else Console.Write("  " + (k + 1));                                
                                   
                                }

                                Console.WriteLine();
                            }

                            if (j == 0)
                            {
                                Console.Write((i + 1) + "  " + map[i, j] + " ");
                            }
                            else
                            {
                                Console.Write(" " + map[i, j] + " ");
                            }

                        }

                        Console.WriteLine();
                    }
                }
                else if (option == 6)
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA!");
                    Console.WriteLine("Selecione a opção desejada");
                    Console.WriteLine("");
                }
                else if (option != 0)
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA!");
                    Console.WriteLine("Selecione a opção desejada");
                    Console.WriteLine("");
                }
            }

        }
    }
}
