using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Movement;
using Framework.FireFolder;
using Framework.BoosterPills;

namespace Framework.CollisionFolder
{
    public class Collision
    {
        ObjectType object1;
        ObjectType object2;
        FireType object3;
        Pilltype object4; 
        ICollisionAction behaviour;

        public Collision(ObjectType object1, ObjectType object2, ICollisionAction behaviour)
        {
            this.Object1 = object1;
            this.Object2 = object2;
            this.behaviour = behaviour;
        }

        public Collision(ObjectType object1, FireType object3, ICollisionAction behaviour)
        {
            this.object1 = object1;
            this.object2 = ObjectType.None;
            this.Object3 = object3;
            this.object4 = Pilltype.None;
            this.behaviour = behaviour;
        }

        public Collision(ObjectType object1, Pilltype object4, ICollisionAction behaviour)
        {
            this.object1 = object1;
            this.object2 = ObjectType.None;
            this.object3 = FireType.None;
            this.Object4 = object4;
            this.behaviour = behaviour;
        }

        internal ICollisionAction Behaviour { get => behaviour; set => behaviour = value; }
        public ObjectType Object1 { get => object1; set => object1 = value; }
        public ObjectType Object2 { get => object2; set => object2 = value; }
        public FireType Object3 { get => object3; set => object3 = value; }
        public Pilltype Object4 { get => object4; set => object4 = value; }
    }
}
