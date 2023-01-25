using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Framework.FireFolder
{
    public class HorizontalThreeFire : IFire
    {
        public List<Fire> DrawFire(Image img, Point point, string Direction, FireType fire)
        {
            PictureBox pbFire = new PictureBox(), pbFire1 = new PictureBox(), pbFire2 = new PictureBox();
            pbFire.SizeMode = PictureBoxSizeMode.AutoSize;
            pbFire1.SizeMode = PictureBoxSizeMode.AutoSize;
            pbFire2.SizeMode = PictureBoxSizeMode.AutoSize;
            pbFire.BackColor = Color.Transparent;
            pbFire1.BackColor = Color.Transparent;
            pbFire2.BackColor = Color.Transparent;
            pbFire.Image = img;
            pbFire1.Image = img;
            pbFire2.Image = img;
            pbFire.Location = new Point(point.X, point.Y - 15);
            pbFire1.Location = new Point(point.X, point.Y);
            pbFire2.Location = new Point(point.X, point.Y + 15);

            return new List<Fire>() { new Fire(pbFire, Direction, fire), new Fire(pbFire1, Direction, fire), new Fire(pbFire2, Direction, fire) };
        }
    }
}
