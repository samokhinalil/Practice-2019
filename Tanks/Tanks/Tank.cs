using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Properties;

namespace Tanks
{
    public class Tank : MovableMapObject
    {
        public Tank()
        {
            ChangePicture();
        }

        public Tank(int x, int y) : base(x, y)
        {
            ChangePicture();
        }

        public void Move(List<Wall> Walls, List<Tank> Tanks)
        {
            PreviousY = Y;
            PreviousX = X;

            switch (DirectionTo)
            {
                case (int)Direction.DOWN:
                    {
                        PreviousY = Y;
                        PreviousX = X;
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
                        PreviousY = Y;
                        PreviousX = X;
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
                        PreviousY = Y;
                        PreviousX = X;
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
                        PreviousY = Y;
                        PreviousX = X;
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
            ChangePicture();
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

        public void ChangePicture()
        {
            if (Img == null)
            {
                Img = new Bitmap(Resources.TankLeft);
            }
            switch (DirectionTo)
            {
                case (int)Direction.UP:
                    {
                        Img = Resources.TankUp;
                        break;
                    }
                case ((int)Direction.DOWN):
                    {
                        Img = Resources.TankDown;
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        Img = Resources.TankRight;
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        Img = Resources.TankLeft;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
