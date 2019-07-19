using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class MovableMapObject : MapObject
    {
        public int PreviousX { get; protected set; }
        public int PreviousY { get; protected set; }
        public int DirectionTo { get; set; }

        public MovableMapObject() : base()
        {
            DirectionTo = TanksForm.rnd.Next(0, 4);
        }

        public MovableMapObject(int x, int y) : base(x, y)
        {
            DirectionTo = TanksForm.rnd.Next(0, 4);
        }

        public MovableMapObject(int x, int y, int direction) : base(x, y)
        {
            DirectionTo = direction;
        }

        public void ChangeDirection(int direction)
        {
            switch (direction)
            {
                case (int)Direction.DOWN:
                    {
                        DirectionTo = (int)Direction.DOWN;
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        DirectionTo = (int)Direction.LEFT;
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        DirectionTo = (int)Direction.RIGHT;
                        break;
                    }
                case (int)Direction.UP:
                    {
                        DirectionTo = (int)Direction.UP;
                        break;
                    }
                default:
                    break;
            }
        }

        public bool CollidesWithWalls(List<Wall> Walls)
        {
            foreach (var wall in Walls)
            {
                if (CollidesWith(wall))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
