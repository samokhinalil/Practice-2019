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
    public partial class SettingsForm : Form
    {
        public int ApplesCount { get; private set; }
        public int TanksCount { get; private set; }
        public int Speed { get; private set; }
        public int ShotSpeed { get; private set; }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            ApplesCount = (int)ctlApplesCount.Value;
            TanksCount = (int)ctlTanksCount.Value;
            switch (ctlSpeed.Value)
            {
                case 1:
                    Speed = 100;
                    ShotSpeed = 30;
                    break;
                case 2:
                    Speed = 75;
                    ShotSpeed = 20;
                    break;
                case 3:
                    Speed = 50;
                    ShotSpeed = 10;
                    break;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
