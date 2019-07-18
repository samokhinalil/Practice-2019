﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Properties;

namespace Tanks
{
    public class Wall:MapObject
    {
        public Wall()
        {
            Img = new Bitmap(Resources.Wall);
        }

        public Wall(int x, int y):base(x,y)
        {
            Img = new Bitmap(Resources.Wall);
        }
    }
}
