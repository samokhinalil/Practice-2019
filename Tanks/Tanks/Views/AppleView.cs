using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanks.Properties;

namespace Tanks.Views
{
    public class AppleView : MapObjectView
    {
        public AppleView(PictureBox map, Graphics mapGraphics) : base(map, mapGraphics)
        {
            Model.Img = new Bitmap(Resources.Wall);
        }
    }
}
