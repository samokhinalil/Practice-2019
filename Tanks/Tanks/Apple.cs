using System.Drawing;
using Tanks.Properties;

namespace Tanks
{
    public class Apple : MapObject
    {
        public Apple()
        {
            Img = new Bitmap(Resources.Apple);
        }

        public Apple(int x, int y) : base(x, y)
        {
            Img = new Bitmap(Resources.Apple);
        }
    }
}
