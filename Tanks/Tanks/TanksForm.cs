using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class TanksForm : Form
    {
        public static Random rnd = new Random();
        PictureBox map;
        Bitmap backgroungMap;
        Graphics mapGraphics;

        public TanksForm()
        {
            InitializeComponent();
        }

        private void TanksForm_Load(object sender, EventArgs e)
        {
            CreateBitmapAtRuntime(500, 500);
            Game game = new Game();
            GameView gameView = new GameView(map, mapGraphics);
            gameView.Refresh();
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
    }
}
