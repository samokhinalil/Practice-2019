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
            Img = new Bitmap(Resources.TankDown);
        }

        public Tank(int x, int y) : base(x, y)
        {
            Img = new Bitmap(Resources.TankDown);
        }
    }
}
