using System.Collections.Generic;
using System.Windows.Forms;
using Tanks.Properties;

namespace Tanks
{
    public class Kolobok : MovableMapObject
    {
        public event Shoot MakeShot;

        public Kolobok()
        {
            ChangePicture(Resources.BunLeft, Resources.BunUp, Resources.BunDown, Resources.BunRight);
        }

        public Kolobok(int x, int y) : base(x, y)
        {
            ChangePicture(Resources.BunLeft, Resources.BunUp, Resources.BunDown, Resources.BunRight);
        }

        public Kolobok(int x, int y, int direction) : base(x, y, direction)
        {
            ChangePicture(Resources.BunLeft, Resources.BunUp, Resources.BunDown, Resources.BunRight);
        }

        public void Move(List<Wall> Walls)
        {
            PreviousY = Y;
            PreviousX = X;

            switch (DirectionTo)
            {
                case (int)Direction.DOWN:
                    {
                        Y++;
                        if (CollidesWithWalls(Walls))
                        {
                            Y--;
                            ChangeDirection((int)Direction.UP);
                        }
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        X--;
                        if (CollidesWithWalls(Walls))
                        {
                            X++;
                            ChangeDirection((int)Direction.RIGHT);
                        }
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        X++;
                        if (CollidesWithWalls(Walls))
                        {
                            X--;
                            ChangeDirection((int)Direction.LEFT);
                        }
                        break;
                    }
                case (int)Direction.UP:
                    {
                        Y--;
                        if (CollidesWithWalls(Walls))
                        {
                            Y++;
                            ChangeDirection((int)Direction.DOWN);
                        }
                        break;
                    }
                default:
                    break;
            }
            ChangePicture(Resources.BunLeft, Resources.BunUp, Resources.BunDown, Resources.BunRight);
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (sender is Kolobok)
            {
                switch (e.KeyData)
                {
                    case Keys.Up:
                    case Keys.W:
                        {
                            ((Kolobok)sender).ChangeDirection((int)Direction.UP);
                            break;
                        }
                    case Keys.Down:
                    case Keys.S:
                        {
                            ((Kolobok)sender).ChangeDirection((int)Direction.DOWN);
                            break;
                        }
                    case Keys.Left:
                    case Keys.A:
                        {
                            ((Kolobok)sender).ChangeDirection((int)Direction.LEFT);
                            break;
                        }
                    case Keys.Right:
                    case Keys.D:
                        {
                            ((Kolobok)sender).ChangeDirection((int)Direction.RIGHT);
                            break;
                        }
                    case Keys.Space:
                    case Keys.E:
                        {
                            MakeShot?.Invoke(this);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
