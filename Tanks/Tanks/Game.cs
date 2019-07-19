using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public class Game
    {
        private Kolobok kolobok;
        private List<Wall> walls = new List<Wall>();
        private List<Tank> tanks = new List<Tank>();
        private List<Apple> apples = new List<Apple>();

        private int width;
        private int height;
        private int applesCount;
        private int tanksCount;
        private int speed;
        private Graphics graphics;
        private int delta = 30;
        private bool gameOver;

        private static string[] wallArrangement = {
            "********************",
            "*                  *",
            "*                  *",
            "*   *************  *",
            "*         *        *",
            "*         *        *",
            "*   *  *     *  *  *",
            "*   *  *     *  *  *",
            "*   *  *******  *  *",
            "*   *           *  *",
            "*   *           *  *",
            "*   *     *     *  *",
            "*   *     *     *  *",
            "*   ****  *  ****  *",
            "*      *  *        *",
            "*      *  *        *",
            "*         *  *     *",
            "*         *  *     *",
            "*      *  *  *     *",
            "********************"
        };

        public int Score { get; private set; } = 0;

        public Game(int width, int height, int applesCount, int tanksCount, int speed, Graphics graphics)
        {
            this.width = width;
            this.height = height;
            this.applesCount = applesCount;
            this.tanksCount = tanksCount;
            this.speed = speed;
            this.graphics = graphics;
        }

        public void Start()
        {
            Init();
            Draw();
            Subscribe();
        }

        public void Init()
        {
            walls = new List<Wall>();
            CreateWalls();

            CreateKolobok();

            apples = new List<Apple>();
            CreateApples();

            tanks = new List<Tank>();
            CreateTanks();
        }

        private void CreateKolobok()
        {
            while (true)
            {
                kolobok = new Kolobok();

                if (!kolobok.CollidesWithWalls(walls))
                {
                    break;
                }
            }
        }

        private void CreateTanks()
        {
            while (tanks.Count < tanksCount)
            {
                tanks.Add(new Tank());
                if (tanks.Last().CollidesWith(kolobok))
                {
                    tanks.RemoveAt(tanks.Count - 1);
                    continue;
                }

                foreach (var wall in walls)
                {
                    if (tanks.Last().CollidesWith(wall))
                    {
                        tanks.RemoveAt(tanks.Count - 1);
                        break;
                    }
                }
            }
        }

        private void CreateWalls()
        {
            walls = new List<Wall>();
            for (int i = 0; i < wallArrangement.Count(); i++)
            {
                for (int j = 0; j < wallArrangement[i].Length; j++)
                {
                    if (wallArrangement[i][j] == '*')
                    {
                        walls.Add(new Wall(j, i));
                    }
                }
            }
        }

        public void Draw()
        {
            graphics.DrawImage(kolobok.Img, kolobok.X * kolobok.Size, kolobok.Y * kolobok.Size, kolobok.Size, kolobok.Size);
            DrawWalls();
            DrawTanks();
            DrawApples();
        }

        private void DrawWalls()
        {
            Wall wall;
            for (int i = 0; i < walls.Count; i++)
            {
                wall = walls[i];
                graphics.DrawImage(wall.Img, wall.X * wall.Size,
                    wall.Y * wall.Size, wall.Size, wall.Size);
            }
        }

        private void DrawTanks()
        {
            Tank tank;
            for (int i = 0; i < tanks.Count; i++)
            {
                tank = tanks[i];
                graphics.DrawImage(tank.Img, tank.X * tank.Size, tank.Y * tank.Size,
                    tank.Size, tank.Size);
            }
        }

        private void DrawApples()
        {
            Apple apple;
            for (int i = 0; i < apples.Count; i++)
            {
                apple = apples[i];
                graphics.DrawImage(apple.Img, apple.X * apple.Size, apple.Y * apple.Size,
                    apple.Size, apple.Size);
            }
        }

        public void Step()
        {
            while (delta != TanksForm.CellSize + 5)
            {
                Move(kolobok, delta);

                for (int i = 0; i < tanks.Count; i++)
                {
                    Move(tanks[i], delta);
                }

                delta += 5;
                return;
            }

            kolobok.Move(walls);
            delta = 5;
            Move(kolobok, delta);

            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i].CollidesWith(kolobok))
                {
                    gameOver = true;
                    UnSubscribe();
                    return;
                }
                tanks[i].Move(walls, tanks);

                if (tanks[i].CollidesWith(kolobok))
                {
                    gameOver = true;
                    UnSubscribe();
                    return;
                }
                Move(tanks[i], delta);
            }

            delta += 5;

            for (int i=0; i<apples.Count;i++)
            {
                if (kolobok.CollidesWith(apples[i]))
                {
                    apples.RemoveAt(i);
                    Score++;
                    break;
                }
            }

            CreateApples();
            DrawApples();
        }

        public void Move(MovableMapObject movable, int delta)
        {
            if (movable.PreviousX < movable.X)
            {
                graphics.FillRectangle(Brushes.Black, movable.PreviousX * TanksForm.CellSize + delta - 5, movable.PreviousY * TanksForm.CellSize, TanksForm.CellSize, TanksForm.CellSize);
                graphics.DrawImage(movable.Img, movable.PreviousX * TanksForm.CellSize + delta, movable.PreviousY * TanksForm.CellSize, TanksForm.CellSize, TanksForm.CellSize);
                return;
            }
            if (movable.PreviousX > movable.X)
            {
                graphics.FillRectangle(Brushes.Black, movable.PreviousX * TanksForm.CellSize - delta + 5, movable.PreviousY * TanksForm.CellSize, TanksForm.CellSize, TanksForm.CellSize);
                graphics.DrawImage(movable.Img, movable.PreviousX * TanksForm.CellSize - delta, movable.PreviousY * TanksForm.CellSize, TanksForm.CellSize, TanksForm.CellSize);
                return;
            }
            if (movable.PreviousY < movable.Y)
            {
                graphics.FillRectangle(Brushes.Black, movable.PreviousX * TanksForm.CellSize, movable.PreviousY * TanksForm.CellSize + delta - 5, TanksForm.CellSize, TanksForm.CellSize);
                graphics.DrawImage(movable.Img, movable.PreviousX * TanksForm.CellSize, movable.PreviousY * TanksForm.CellSize + delta, TanksForm.CellSize, TanksForm.CellSize);
                return;
            }
            if (movable.PreviousY > movable.Y)
            {
                graphics.FillRectangle(Brushes.Black, movable.PreviousX * TanksForm.CellSize, movable.PreviousY * TanksForm.CellSize - delta + 5, TanksForm.CellSize, TanksForm.CellSize);
                graphics.DrawImage(movable.Img, movable.PreviousX * TanksForm.CellSize, movable.PreviousY * TanksForm.CellSize - delta, TanksForm.CellSize, TanksForm.CellSize);
                return;
            }
            if (movable.PreviousY == movable.Y && movable.PreviousX > movable.X)
            {
                graphics.FillRectangle(Brushes.Black, movable.PreviousX * TanksForm.CellSize, movable.Y * TanksForm.CellSize, TanksForm.CellSize, TanksForm.CellSize);
                graphics.DrawImage(movable.Img, movable.X * TanksForm.CellSize, movable.Y * TanksForm.CellSize, TanksForm.CellSize, TanksForm.CellSize);
                return;
            }
        }

        private event KeyEventHandler KeyDown;

        public void OnKeyDown(Keys key)
        {
            KeyDown?.Invoke(kolobok, new KeyEventArgs(key));
        }

        public void Subscribe()
        {
            KeyDown += new KeyEventHandler(kolobok.OnKeyDown);
        }

        public void UnSubscribe()
        {
            if (KeyDown != null)
            {
                KeyDown -= new KeyEventHandler(kolobok.OnKeyDown);
            }
        }

        private void CreateApples()
        {
            while (apples.Count < applesCount)
            {
                apples.Add(new Apple());
                if (apples.Last().CollidesWith(kolobok))
                {
                    apples.RemoveAt(apples.Count - 1);
                    continue;
                }

                foreach (var wall in walls)
                {
                    if (apples.Last().CollidesWith(wall))
                    {
                        apples.RemoveAt(apples.Count - 1);
                        break;
                    }
                }
            }
        }
    }
}
