using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefaPrimeira
{
    internal class Enemy
    {
        string name;
        int life;
        int points; // bônus de pontuação concedido ao coletar

        public Enemy(string name = "I", int life = 10, int points = 20)
        {
            this.name = name;
            this.life = life;
            this.points = points;
        }

        public int _Points
        {
            get { return points; }
            set { points += value; }
        }
    }
}
