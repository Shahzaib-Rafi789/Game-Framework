using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Framework.Movement;
using Framework.FireFolder;
using Framework.CollisionFolder;

namespace Framework.Core
{
    public interface IGame
    {
        void RaisePlayerDeathEvent(System.Windows.Forms.PictureBox pb);
        void RaiseEnemyDeathEvent(System.Windows.Forms.PictureBox pb);
    }
}
