using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tanks
{
    public class MovableMapObject : MapObject
    {
        private Random rnd = new Random();
        public int PreviousX { get; protected set; }
        public int PreviousY { get; protected set; }
        public int DirectionTo { get; set; }

        public delegate void Shoot(MovableMapObject sender);

        public MovableMapObject() : base()
        {
            DirectionTo = rnd.Next(0, 3);
        }

        public MovableMapObject(int x, int y) : base(x, y)
        {
            DirectionTo = rnd.Next(0, 3);
        }

        public MovableMapObject(int x, int y, int direction) : base(x, y)
        {
            DirectionTo = direction;
        }

        public void ChangePicture(Bitmap imgLeft, Bitmap imgUp, Bitmap imgDown, Bitmap imgRight)
        {
            switch (DirectionTo)
            {
                case (int)Direction.UP:
                    {
                        Img = imgUp;
                        break;
                    }
                case ((int)Direction.DOWN):
                    {
                        Img = imgDown;
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        Img = imgRight;
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        Img = imgLeft;
                        break;
                    }
                default:
                    break;
            }
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
