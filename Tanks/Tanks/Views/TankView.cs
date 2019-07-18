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
    public class TankView : MovableMapObjectView
    {
        public TankView(PictureBox map, Graphics mapGraphics) : base(map, mapGraphics)
        {
            Model.Img = new Bitmap(Resources.TankDown);
        }

        public void ChangePicture()
        {
            switch (Model.DirectionTo)
            {
                case (int)Direction.UP:
                    {
                        Model.Img = Resources.TankUp;
                        break;
                    }
                case ((int)Direction.DOWN):
                    {
                        Model.Img = Resources.TankDown;
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        Model.Img = Resources.TankRight;
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        Model.Img = Resources.TankLeft;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
