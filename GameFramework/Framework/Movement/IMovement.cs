using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Framework.Core;

namespace Framework.Movement
{
    public interface IMovement
    {
        Point move(PictureBox pb, Point location); 
    }
}
