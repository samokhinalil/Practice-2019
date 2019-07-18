using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public class Game
    {
        private int applesCount = 5;
        private int tanksCount = 5;
        public Bun Bun { get; set; }
        public List<Wall> Walls { get; set; } = new List<Wall>();
        public List<Tank> Tanks { get; set; } = new List<Tank>();
        public List<Apple> Apples { get; set; } = new List<Apple>();

        private static string[] wallArrangement = {
            "********************",
            "*                  *",
            "*                  *",
            "*   *************  *",
            "*         *        *",
            "*         *        *",
            "*   *  *     *  *  *",
            "*   *  *     *  *  *",
            "*   *  *******  *  *",
            "*   *           *  *",
            "*   *           *  *",
            "*   *     *     *  *",
            "*   *     *     *  *",
            "*   ****  *  ****  *",
            "*      *  *        *",
            "*      *  *        *",
            "*         *  *     *",
            "*         *  *     *",
            "*      *  *  *     *",
            "********************"
        };

        public Game()
        {
            Bun = new Bun(360, 120);

            for (int i = 0; i < wallArrangement.Count(); i++)
            {
                for (int j = 0; j < wallArrangement[i].Length; j++)
                {
                    if (wallArrangement[i][j] == '*')
                    {
                        Walls.Add(new Wall(j, i));
                    }
                }
            }

            while (Apples.Count < applesCount)
            {
                Apples.Add(new Apple());
                if (Apples.Last().CollidesWith(Bun))
                {
                    Apples.RemoveAt(Apples.Count - 1);
                    continue;
                }

                foreach (var wall in Walls)
                {
                    if (Apples.Last().CollidesWith(wall))
                    {
                        Apples.RemoveAt(Apples.Count - 1);
                        break;
                    }
                }
            }

            while (Tanks.Count < tanksCount)
            {
                Tanks.Add(new Tank());
                if (Tanks.Last().CollidesWith(Bun))
                {
                    Tanks.RemoveAt(Tanks.Count - 1);
                    continue;
                }

                foreach (var wall in Walls)
                {
                    if (Tanks.Last().CollidesWith(wall))
                    {
                        Tanks.RemoveAt(Tanks.Count - 1);
                        break;
                    }
                }
            }
        }
    }
}
