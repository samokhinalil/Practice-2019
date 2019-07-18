using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanks.MVC;
using Tanks.Properties;

namespace Tanks.View
{
    public class BunView : MovableMapObjectView
    {
        public BunView(PictureBox map, Graphics mapGraphics) : base(map, mapGraphics)
        {
            Model.Img = new Bitmap(Resources.BunDown);
        }

        public void ChangePicture()
        {
            switch (Model.DirectionTo)
            {
                case (int)Direction.UP:
                    {
                        Model.Img = Resources.BunUp;
                        break;
                    }
                case ((int)Direction.DOWN):
                    {
                        Model.Img = Resources.BunDown;
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        Model.Img = Resources.BunRight;
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        Model.Img = Resources.BunLeft;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
