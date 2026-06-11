namespace TarefaPrimeira
{
    internal class Player
    {
        protected int id;
        protected string name;
        protected int life;
        protected int attack;
        protected int defense;
        protected int points;

        // Construtor
        public Player(int id = 0, string name = "Class", int life = 0, int attack = 0, int defense = 0)
        {
            this.id = id;
            this.name = name;
            this.life = life;
            this.attack = attack;
            this.defense = defense;
            this.points = 0;
        }

        public int _ID
        {
            get { return id; }
            set { id = value; }
        }

        public void ExibirDados()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Nome: " + name);
            Console.WriteLine("Vida: " + life);
            Console.WriteLine("Ataque: " + attack);
            Console.WriteLine("Defesa: " + defense);
            Console.WriteLine("Pontuação: " + points);
        }

    }
}
