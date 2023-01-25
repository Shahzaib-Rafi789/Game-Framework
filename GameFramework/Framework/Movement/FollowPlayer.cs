using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;

namespace Framework.Movement
{
    public class FollowObject : IMovement
    {
        int speed;
        GameObject follower;

        public FollowObject(int speed, GameObject follower)
        {
            this.Speed = speed;
            this.Follower = follower;
        }

        public GameObject Follower { get => follower; set => follower = value; }
        public int Speed { get => speed; set => speed = value; }

        public System.Drawing.Point move(System.Windows.Forms.PictureBox pb ,System.Drawing.Point Location)
        {
            if (!IsObjectCoincide(Location))
            {
                if(Location.X < follower.Pb.Location.X) { Location.X += speed; }
                else if (Location.X > follower.Pb.Location.X) { Location.X -= speed; }

                if(Location.Y < follower.Pb.Location.Y) { Location.Y += speed; }
                else if(Location.Y > follower.Pb.Location.Y) { Location.Y -= speed; }
            }

            return Location;
        }

        private bool IsObjectCoincide(System.Drawing.Point location)
        {
            int midX = follower.Pb.Location.X + follower.Pb.Width / 2, midY = follower.Pb.Location.Y + follower.Pb.Height / 2;

            if ((location.X < midX + 25 && location.X > midX -25) && (location.Y < midY + 25 && location.Y > midY - 25))
            {
                return true;
            }
            return false;
        }
    }
}
