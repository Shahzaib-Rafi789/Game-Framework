using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Framework.Core;

namespace Framework.FireFolder
{
   public class Fire
    {
        PictureBox fireApperance;
        string fireDirection;
        FireType oFire;
        public Fire(PictureBox Apperance, string fireDirection, FireType oFire)
        {
            this.FireApperance = Apperance;
            this.FireDirection = fireDirection;
            this.OFire = oFire;
        }
        public PictureBox FireApperance { get => fireApperance; set => fireApperance = value; }
        public string FireDirection { get => fireDirection; set => fireDirection = value; }
        public FireType OFire { get => oFire; set => oFire = value; }

        //public Fire DrawFire(Image Img, Point location, string direction)
        //{
        //    PictureBox pbFire = new PictureBox();
        //    pbFire.SizeMode = PictureBoxSizeMode.AutoSize;
        //    pbFire.BackColor = Color.Transparent;
        //    pbFire.Image = Img;
        //    pbFire.Location = location;

        //    return new Fire(pbFire, direction);
        //}
    }
}
