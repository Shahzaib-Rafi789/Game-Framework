using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Framework.FireFolder
{
    public class HorizontalTwoFire : IFire
    {
        public List<Fire> DrawFire(Image img, Point point, string Direction, FireType fire)
        {
            PictureBox pbFire = new PictureBox(), pbFire1 = new PictureBox();
            pbFire.SizeMode = PictureBoxSizeMode.AutoSize;
            pbFire1.SizeMode = PictureBoxSizeMode.AutoSize;
            pbFire.BackColor = Color.Transparent;
            pbFire1.BackColor = Color.Transparent;
            pbFire.Image = img;
            pbFire1.Image = img;
            pbFire.Location = new Point(point.X, point.Y - 10);
            pbFire1.Location = new Point(point.X, point.Y + 10); 

            return new List<Fire>() { new Fire(pbFire, Direction, fire), new Fire(pbFire1, Direction, fire) };
        }
    }
}
