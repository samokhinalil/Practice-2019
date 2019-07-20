using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tanks
{
    public partial class TanksForm : Form
    {
        private PictureBox map;
        private Bitmap backgroungMap;
        private Graphics mapGraphics;

        private Game game;

        public static int CellSize = 25;
        public static Random rnd = new Random();

        public TanksForm()
        {
            InitializeComponent();
        }

        private void TanksForm_Load(object sender, EventArgs e)
        {
            int width = 500;
            int height = 500;
            int applesCount = 5;
            int tanksCount = 5;
            int speed = 10;
            CreateBitmapAtRuntime(width, height);
            game = new Game(width, height, applesCount, tanksCount, speed, mapGraphics);
            game.Start();
            map.Invalidate();
        }

        public void CreateBitmapAtRuntime(int width, int height)
        {
            map = new PictureBox();
            map.Size = new Size(width, height);
            Controls.Add(map);

            backgroungMap = new Bitmap(width, height);
            mapGraphics = Graphics.FromImage(backgroungMap);
            mapGraphics.FillRectangle(Brushes.Black, 0, 0, width, height);
            map.Image = backgroungMap;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            game.Step();
            map.Invalidate();
            tbScore.Text = game.Score.ToString();
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            btnStartGame.Visible = false;
            gameTimer.Enabled = true;
            shotTimer.Enabled = true;
        }

        private void TanksForm_KeyDown(object sender, KeyEventArgs e)
        {
            game.OnKeyDown(e.KeyCode);
        }

        private void ShotTimer_Tick(object sender, EventArgs e)
        {
            game.ShotStep();
        }

        private void TanksForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroungMap.Dispose();
        }
    }
}
