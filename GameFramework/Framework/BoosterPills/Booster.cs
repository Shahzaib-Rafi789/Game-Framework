using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Framework.BoosterPills
{
    public class Booster
    {
        PictureBox pill;
        Pilltype pType;
        IBooster boosterEffect;
        bool Effect;

        public Booster(Image pillAp, Point location, Pilltype pType, IBooster boosterEffect)
        {
            this.Pill = new PictureBox();
            Pill.Image = pillAp;
            Pill.Location = location;
            pill.SizeMode = PictureBoxSizeMode.AutoSize;
            pill.BackColor = Color.Transparent;
            this.PType = pType;
            this.BoosterEffect = boosterEffect;
            Effect = true;
        }

        public PictureBox Pill { get => pill; set => pill = value; }
        public IBooster BoosterEffect { get => boosterEffect; set => boosterEffect = value; }
        public Pilltype PType { get => pType; set => pType = value; }
        public bool Effect1 { get => Effect; set => Effect = value; }
    }
}
