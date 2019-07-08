using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class HorizontalLine : Figure
    {
        public HorizontalLine(int xLeft, int xRight, int y, char symbol)
        {
            points = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            {
                Point point = new Point(x, y, symbol);
                points.Add(point);
            }
        }
    }
}
