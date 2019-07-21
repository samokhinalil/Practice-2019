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
        private AboutForm aboutForm;

        private Game game;

        public static int CellSize = 25;
        public static Random rnd = new Random();

        public TanksForm()
        {
            InitializeComponent();
        }

        private void TanksForm_Load(object sender, EventArgs e)
        {
            CreateBitmapAtRuntime(500, 500);
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
            if (aboutForm != null)
            {
                aboutForm.RefreshInformation(game.MapObjects);
            }

            if (game.IsGameOver)
            {
                gameTimer.Enabled = false;
                shotTimer.Enabled = false;
                game.End();
                btnStartGame.Visible = true;
            }
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            StartGame();
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

        private void CtlAbout_Click(object sender, EventArgs e)
        {
            aboutForm = new AboutForm(game.MapObjects);
            aboutForm.Show();
        }

        private void StartGame()
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
            if (settings.DialogResult == DialogResult.OK)
            {
                game = new Game(settings.ApplesCount, settings.TanksCount, mapGraphics);
                gameTimer.Interval = settings.Speed;
                shotTimer.Interval = settings.ShotSpeed;
                game.Start();
                map.Invalidate();
            }
        }
    }
}
