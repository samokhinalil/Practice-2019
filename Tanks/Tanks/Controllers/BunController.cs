using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks.Controllers
{
    public class BunController
    {
        public void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (sender is Bun)
            {
                switch (e.KeyData)
                {
                    case Keys.Up:
                        {
                            ((Bun)sender).IdentifyDirection((int)Direction.UP);
                            break;
                        }
                    case Keys.Down:
                        {
                            ((Bun)sender).IdentifyDirection((int)Direction.DOWN);
                            break;
                        }
                    case Keys.Left:
                        {
                            ((Bun)sender).IdentifyDirection((int)Direction.LEFT);
                            break;
                        }
                    case Keys.Right:
                        {
                            ((Bun)sender).IdentifyDirection((int)Direction.RIGHT);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
