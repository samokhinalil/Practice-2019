using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanks.MVC;
using Tanks.Views;

namespace Tanks
{
    public class GameView : View<Game>
    {
        public List<WallView> WallViews { get; set; } = new List<WallView>();
        public List<TankView> TankViews { get; set; } = new List<TankView>();
        public List<AppleView> AppleViews { get; set; } = new List<AppleView>();
        Graphics mapGraphics;

        public GameView(PictureBox map, Graphics mapGraphics)
        {
            this.mapGraphics = mapGraphics;
        }

        public void Refresh()
        {
            Bun bun = Model.Bun;
            mapGraphics.DrawImage(bun.Img, bun.X, bun.Y, bun.Size, bun.Size);

            WallViews = new List<WallView>();
            Wall wall;
            for (int i = 0; i < Model.Walls.Count; i++)
            {
                wall = Model.Walls[i];
                mapGraphics.DrawImage(wall.Img, wall.X * wall.Size,
                    wall.Y * wall.Size, wall.Size, wall.Size);
            }

            TankViews = new List<TankView>();
            Tank tank;
            for (int i = 0; i < Model.Tanks.Count; i++)
            {
                tank = Model.Tanks[i];
                mapGraphics.DrawImage(tank.Img, tank.X * tank.Size, tank.Y * tank.Size,
                    tank.Size, tank.Size);
            }

            AppleViews = new List<AppleView>();
            Apple apple;
            for (int i = 0; i < Model.Apples.Count; i++)
            {
                apple = Model.Apples[i];
                mapGraphics.DrawImage(apple.Img, apple.X * apple.Size, apple.Y * apple.Size,
                    apple.Size, apple.Size);
            }
        }

        protected override void Update()
        {
            Refresh();
        }
    }
}
