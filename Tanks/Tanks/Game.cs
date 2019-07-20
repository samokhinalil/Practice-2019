using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tanks.Properties;

namespace Tanks
{
    public class Game
    {
        private Kolobok kolobok;
        private List<Wall> walls = new List<Wall>();
        private List<Tank> tanks = new List<Tank>();
        private List<Apple> apples = new List<Apple>();
        private List<Shot> kolobokShots = new List<Shot>();
        private List<Shot> tanksShots = new List<Shot>();

        private int width;
        private int height;
        private int applesCount;
        private int tanksCount;
        private int speed;
        private Graphics graphics;
        private int delta = 30;
        private int deltaShot = 30;
        private bool gameOver;
        private int cellSize = 25;

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

        public void Step()
        {
            while (delta != cellSize + 5)
            {
                Update(kolobok, delta);

                for (int i = 0; i < tanks.Count; i++)
                {
                    Update(tanks[i], delta);
                }

                delta += 5;
                return;
            }

            kolobok.Move(walls);
            delta = 5;
            Update(kolobok, delta);

            KillKolobokByTank();
            MoveTanks();
            KillKolobokByTank();
            UpdateTanks();

            delta += 5;

            EatApple();
            CreateApples();
            DrawApples();
        }

        public void ShotStep()
        {
            while (deltaShot != cellSize + 5)
            {
                for (int i = 0; i < kolobokShots.Count; i++)
                {
                    Update(kolobokShots[i], deltaShot);
                }

                for (int i = 0; i < tanksShots.Count; i++)
                {
                    Update(tanksShots[i], deltaShot);
                }

                deltaShot += 5;
                return;
            }

            deltaShot = 5;

            KillKolobokByTankShot();
            EraseDestroyedTank();
            EraseKolobokShots();
            EraseTankShots();
            KillKolobokByTankShot();

            CreateApples();
            DrawApples();
        }

        private void UpdateTanks()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                Update(tanks[i], delta);
            }
        }

        private void MoveTanks()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                tanks[i].Move(walls, tanks);
            }
        }

        private void EatApple()
        {
            for (int i = 0; i < apples.Count; i++)
            {
                if (kolobok.CollidesWith(apples[i]))
                {
                    apples.RemoveAt(i);
                    Score++;
                    break;
                }
            }
        }

        private void KillKolobokByTank()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i].CollidesWith(kolobok))
                {
                    gameOver = true;
                    UnSubscribe();
                    break;
                }
            }
        }

        private void EraseTankShots()
        {
            for (int i = 0; i < tanksShots.Count; i++)
            {
                tanksShots[i].Move();
                if (tanksShots[i].CollidesWithWalls(walls))
                {
                    graphics.FillRectangle(Brushes.Black, tanksShots[i].PreviousX * cellSize, tanksShots[i].PreviousY * cellSize, cellSize, cellSize);
                    tanksShots.RemoveAt(i);
                    i--;
                }
            }
        }

        private void KillKolobokByTankShot()
        {
            for (int j = 0; j < tanksShots.Count; j++)
            {
                if (kolobok.CollidesWith(tanksShots[j]))
                {
                    gameOver = true;
                    break;
                }
            }
        }

        private void EraseKolobokShots()
        {
            for (int i = 0; i < kolobokShots.Count; i++)
            {
                kolobokShots[i].Move();
                if (kolobokShots[i].CollidesWithWalls(walls))
                {
                    graphics.FillRectangle(Brushes.Black, kolobokShots[i].PreviousX * cellSize, kolobokShots[i].PreviousY * cellSize, cellSize, cellSize);
                    kolobokShots.RemoveAt(i);
                    i--;
                }
            }
        }

        private void EraseDestroyedTank()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                for (int j = 0; j < kolobokShots.Count; j++)
                {
                    if (tanks[i].CollidesWith(kolobokShots[j]))
                    {
                        graphics.FillRectangle(Brushes.Black, tanks[i].PreviousX * cellSize, tanks[i].PreviousY * cellSize, cellSize, cellSize);
                        graphics.FillRectangle(Brushes.Black, kolobokShots[j].X * cellSize, kolobokShots[j].Y * cellSize, cellSize, cellSize);
                        graphics.FillRectangle(Brushes.Black, tanks[i].X * cellSize, tanks[i].Y * cellSize, cellSize, cellSize);
                        graphics.FillRectangle(Brushes.Black, kolobokShots[j].PreviousX * cellSize, kolobokShots[j].PreviousY * cellSize, cellSize, cellSize);
                        tanks.RemoveAt(i);
                        kolobokShots.RemoveAt(j);
                        i--;
                        j--;
                        break;
                    }
                }
            }
        }

        private void Init()
        {
            walls = new List<Wall>();
            apples = new List<Apple>();
            tanks = new List<Tank>();

            CreateWalls();
            CreateKolobok();
            CreateApples();
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

        private void Draw()
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

        private void CreateKolobokShot(MovableMapObject sender)
        {
            DefineShotDirection(sender, kolobokShots);

            for (int i = 0; i < kolobokShots.Count - 1; i++)
            {
                if (kolobokShots.Last().CollidesWith(kolobokShots[i]))
                {
                    kolobokShots.RemoveAt(kolobokShots.Count - 1);
                    return;
                }
            }

            if (kolobokShots.Last().CollidesWithWalls(walls))
            {
                kolobokShots.RemoveAt(kolobokShots.Count - 1);
                return;
            }
        }

        private void DefineShotDirection(MovableMapObject sender, List<Shot> senderShots)
        {
            switch (sender.DirectionTo)
            {
                case (int)Direction.DOWN:
                    {
                        senderShots.Add(new Shot(sender.X, sender.Y + 1, sender.DirectionTo, sender));
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        senderShots.Add(new Shot(sender.X - 1, sender.Y, sender.DirectionTo, sender));
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        senderShots.Add(new Shot(sender.X + 1, sender.Y, sender.DirectionTo, sender));
                        break;
                    }
                case (int)Direction.UP:
                    {
                        senderShots.Add(new Shot(sender.X, sender.Y - 1, sender.DirectionTo, sender));
                        break;
                    }
                default:
                    break;
            }
        }

        public void CreateTankShot(MovableMapObject sender)
        {
            DefineShotDirection(sender, tanksShots);

            if (tanksShots.Last().CollidesWithWalls(walls))
            {
                tanksShots.RemoveAt(tanksShots.Count - 1);
            }
        }

        private void Update(MovableMapObject movable, int delta)
        {
            if (movable.PreviousX < movable.X)
            {
                graphics.FillRectangle(Brushes.Black, movable.PreviousX * cellSize + delta - 5, movable.PreviousY * cellSize, cellSize, cellSize);
                graphics.DrawImage(movable.Img, movable.PreviousX * cellSize + delta, movable.PreviousY * cellSize, cellSize, cellSize);
                return;
            }
            if (movable.PreviousX > movable.X)
            {
                graphics.FillRectangle(Brushes.Black, movable.PreviousX * cellSize - delta + 5, movable.PreviousY * cellSize, cellSize, cellSize);
                graphics.DrawImage(movable.Img, movable.PreviousX * cellSize - delta, movable.PreviousY * cellSize, cellSize, cellSize);
                return;
            }
            if (movable.PreviousY < movable.Y)
            {
                graphics.FillRectangle(Brushes.Black, movable.PreviousX * cellSize, movable.PreviousY * cellSize + delta - 5, cellSize, cellSize);
                graphics.DrawImage(movable.Img, movable.PreviousX * cellSize, movable.PreviousY * cellSize + delta, cellSize, cellSize);
                return;
            }
            if (movable.PreviousY > movable.Y)
            {
                graphics.FillRectangle(Brushes.Black, movable.PreviousX * cellSize, movable.PreviousY * cellSize - delta + 5, cellSize, cellSize);
                graphics.DrawImage(movable.Img, movable.PreviousX * cellSize, movable.PreviousY * cellSize - delta, cellSize, cellSize);
                return;
            }
            if (movable.PreviousY == movable.Y && movable.PreviousX > movable.X)
            {
                graphics.FillRectangle(Brushes.Black, movable.PreviousX * cellSize, movable.Y * cellSize, cellSize, cellSize);
                graphics.DrawImage(movable.Img, movable.X * cellSize, movable.Y * cellSize, cellSize, cellSize);
                return;
            }
        }

        private event KeyEventHandler KeyDown;

        public void OnKeyDown(Keys key)
        {
            KeyDown?.Invoke(kolobok, new KeyEventArgs(key));
        }

        private void Subscribe()
        {
            KeyDown += new KeyEventHandler(kolobok.OnKeyDown);
            kolobok.MakeShot += CreateKolobokShot;
            for (int i = 0; i < tanks.Count; i++)
            {
                tanks[i].MakeShot += CreateTankShot;
            }
        }

        private void UnSubscribe()
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
