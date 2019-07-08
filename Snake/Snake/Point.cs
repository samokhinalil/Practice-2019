using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }

        public Point()
        {
        }

        public Point(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            Symbol = point.Symbol;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(Symbol);
        }

        public void Clear()
        {
            Symbol = ' ';
            Draw();
        }

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                X += offset;
            }
            if(direction == Direction.LEFT)
            {
                X -= offset;
            }
            if (direction == Direction.DOWN)
            {
                Y += offset;
            }
            if (direction == Direction.UP)
            {
                Y -= offset;
            }
        }

        public bool IsHit(Point point)
        {
            return point.X == X && point.Y == Y;
        }
    }
}
