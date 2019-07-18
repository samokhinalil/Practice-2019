using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanks.MVC;

namespace Tanks
{
    public class MovableMapObjectView:View<MovableMapObject>
    {
        public MovableMapObjectView(PictureBox map, Graphics mapGraphics)
        {
            mapGraphics.DrawImage(Model.Img,
                Model.X * Model.Size,
                Model.Y * Model.Size,
                Model.Size, Model.Size);
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
