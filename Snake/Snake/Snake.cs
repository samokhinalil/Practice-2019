using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake : Figure
    {
        private Direction direction;
        public Snake(Point tail, int length, Direction direction)
        {
            this.direction = direction;
            points = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point point = new Point(tail);
                point.Move(i, direction);
                points.Add(point);
            }
        }

        public void Move()
        {
            Point tail = points.First();
            points.Remove(tail);
            Point head = GetNextPoint();
            points.Add(head);
            tail.Clear();
            head.Draw();
            Console.SetCursorPosition(head.X, head.Y);
        }

        public Point GetNextPoint()
        {
            Point head = points.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        public bool IsHitTail()
        {
            var head = points.Last();
            for (int i = 0; i < points.Count - 2; i++)
            {
                if (head.IsHit(points[i]))
                    return true;
            }
            return false;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.Symbol = head.Symbol;
                food.Draw();
                points.Add(food);
                return true;
            }
            return false;
        }
    }
}
