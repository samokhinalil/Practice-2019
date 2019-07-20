using Tanks.Properties;

namespace Tanks
{
    public class Shot : MovableMapObject
    {
        public MovableMapObject Sender { get; protected set; }

        public Shot() : base()
        {
        }

        public Shot(int x, int y) : base(x, y)
        {
            PreviousX = x;
            PreviousY = y;
        }

        public Shot(int x, int y, int direction) : base(x, y, direction)
        {
            PreviousX = x;
            PreviousY = y;
        }

        public Shot(int x, int y, int direction, MovableMapObject sender) : base(x, y, direction)
        {
            PreviousX = x;
            PreviousY = y;
            Sender = sender;
        }

        public void Move()
        {
            PreviousY = Y;
            PreviousX = X;

            switch (DirectionTo)
            {
                case (int)Direction.DOWN:
                    {
                        Y++;
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        X--;
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        X++;
                        break;
                    }
                case (int)Direction.UP:
                    {
                        Y--;
                        break;
                    }
                default:
                    break;
            }
            ChangePicture(Resources.ShotLeft, Resources.ShotUp, Resources.ShotDown, Resources.ShotRight);
        }
    }
}
