using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Framework.Core;

namespace Framework.FireFolder
{
    public class HorizontalFire :IFire
    {
        public List<Fire> DrawFire( Image img, Point point, string Direction, FireType fire)
        {
            PictureBox pbFire = new PictureBox();
            pbFire.SizeMode = PictureBoxSizeMode.AutoSize;
            pbFire.BackColor = Color.Transparent;
            pbFire.Image = img;
            pbFire.Location = point;

            return new List<Fire>() { new Fire(pbFire, Direction, fire) };
        }
    }
}
