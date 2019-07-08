using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class VerticalLine : Figure
    {
        public VerticalLine(int x, int yUp, int yDown, char symbol)
        {
            points = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                Point point = new Point(x, y, symbol);
                points.Add(point);
            }
        }
    }
}
