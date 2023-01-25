using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Framework.Core;

namespace Framework.FireFolder
{
    public interface IFire
    {
        List<Fire> DrawFire(Image img, Point point, string Direction, FireType type);
    }
}
