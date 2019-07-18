using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanks.Properties;

namespace Tanks
{
    public class WallView : MapObjectView
    {
        public WallView(PictureBox map, Graphics mapGraphics) : base(map, mapGraphics)
        {
            Model.Img= new Bitmap(Resources.Wall);
        }
    }
}
