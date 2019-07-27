using System;
using System.Collections.Generic;
using Tanks.Properties;

namespace Tanks
{
    public class Tank : MovableMapObject
    {
        private Random rnd = new Random();

        public event Shoot MakeShot;

        public Tank()
        {
            ChangePicture(Resources.TankLeft, Resources.TankUp, Resources.TankDown, Resources.TankRight);
        }

        public Tank(int x, int y) : base(x, y)
        {
            ChangePicture(Resources.TankLeft, Resources.TankUp, Resources.TankDown, Resources.TankRight);
        }

        public void Move(List<Wall> Walls, List<Tank> Tanks)
        {
            var probability = rnd.NextDouble();

            if (probability < 0.4)
            {
                ChangeDirection(rnd.Next(0, 3));
            }

            if (probability < 0.15)
            {
                MakeShot?.Invoke(this);
            }

            PreviousY = Y;
            PreviousX = X;

            switch (DirectionTo)
            {
                case (int)Direction.DOWN:
                    {
                        Y++;
                        if (CollidesWithWalls(Walls) || CollidesWithTanks(Tanks))
                        {
                            Y--;
                            ChangeDirection((int)Direction.UP);
                        }
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        X--;
                        if (CollidesWithWalls(Walls) || CollidesWithTanks(Tanks))
                        {
                            X++;
                            ChangeDirection((int)Direction.RIGHT);
                        }
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        X++;
                        if (CollidesWithWalls(Walls) || CollidesWithTanks(Tanks))
                        {
                            X--;
                            ChangeDirection((int)Direction.LEFT);
                        }
                        break;
                    }
                case (int)Direction.UP:
                    {
                        Y--;
                        if (CollidesWithWalls(Walls) || CollidesWithTanks(Tanks))
                        {
                            Y++;
                            ChangeDirection((int)Direction.DOWN);
                        }
                        break;
                    }
                default:
                    break;
            }
            ChangePicture(Resources.TankLeft, Resources.TankUp, Resources.TankDown, Resources.TankRight);
        }

        public bool CollidesWithTanks(List<Tank> Tanks)
        {
            for (int i = 0; i < Tanks.Count; i++)
            {
                if (CollidesWith(Tanks[i]) && this != Tanks[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
