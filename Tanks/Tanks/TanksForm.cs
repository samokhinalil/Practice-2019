using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tanks
{
    public partial class TanksForm : Form
    {
        private AboutForm aboutForm;

        private Game game;

        public static int CellSize = 25;
        public static Random rnd = new Random();

        public TanksForm()
        {
            InitializeComponent();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            game.Step();
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
                btnStartGame.Enabled = true;
            }
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
            if (settings.DialogResult == DialogResult.OK)
            {
                game = new Game(settings.ApplesCount, settings.TanksCount, ctlMap);
                gameTimer.Interval = settings.Speed;
                shotTimer.Interval = settings.ShotSpeed;
                game.Start();
                ctlAbout.Enabled = true;
                btnStartGame.Enabled = false;
                btnStartGame.Visible = false;
                gameTimer.Enabled = true;
                shotTimer.Enabled = true;
            }
        }

        private void TanksForm_KeyDown(object sender, KeyEventArgs e)
        {
            game.OnKeyDown(e.KeyCode);
        }

        private void ShotTimer_Tick(object sender, EventArgs e)
        {
            game.ShotStep();
        }

        private void CtlAbout_Click(object sender, EventArgs e)
        {
            if (game != null)
            {
                aboutForm = new AboutForm(game.MapObjects);
                aboutForm.Show();
            }
        }

        private void CtlExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
