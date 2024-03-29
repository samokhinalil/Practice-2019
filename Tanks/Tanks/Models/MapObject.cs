﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class MapObject
    {
        public Bitmap Img { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }

        public MapObject()
        {
            X = TanksForm.rnd.Next(0, 20);
            Y = TanksForm.rnd.Next(0, 20);
            Size = 25;
        }

        public MapObject(int x, int y)
        {
            X = x;
            Y = y;
            Size = 25;
        }

        public bool CollidesWith(MapObject mapObject)
        {
            if (X == mapObject.X && Y == mapObject.Y || X < 0 || X >= 20 || Y < 0 || Y >= 20)
            {
                return true;
            }
            return false;
        }
    }
}
