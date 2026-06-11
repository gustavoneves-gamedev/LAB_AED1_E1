using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefaPrimeira
{
    internal class Item
    {
        string name;
        int points; // bônus de pontuação concedido ao coletar

        public Item(string name = "I", int points = 10)
        {
            this.name = name;
            this.points = points;
        }

        public int _Points
        {
            get { return points; }
            set { points += value; }
        }
    }
}
