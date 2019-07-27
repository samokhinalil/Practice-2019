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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        public AboutForm(List<MapObject> mapObjects)
        {
            InitializeComponent();
            RefreshInformation(mapObjects);
        }

        public void RefreshInformation(List<MapObject> mapObjects)
        {
            ctlAboutObjects.DataSource = null;
            ctlAboutObjects.DataSource = mapObjects;
        }
    }
}
