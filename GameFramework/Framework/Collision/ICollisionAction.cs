using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;

namespace Framework.CollisionFolder
{
    public interface ICollisionAction
    {
        void PerformAction(Game game, Object ob1, Object ob2);
    }
}
