using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Framework.Core;

namespace Framework.Movement
{
    public class HorizontalMovement : IMovement
    {
        int speed;
        Point boundary;
        string direction;
        int offset = 90;

        public HorizontalMovement(int speed, Point boundary, string direction)
        {
            this.speed = speed;
            this.boundary = boundary;
            this.direction = direction;
        }

        public Point move(PictureBox pb ,Point Location)
        {
            if((Location.X + offset) >= boundary.X)
            {
                direction = "left";
            }
            else if((Location.X) <= 0)
            {
                direction = "right";
            }

            if(direction == "left")
            {
                Location.X -= speed;
            }
            else if(direction == "right")
            {
                Location.X += speed;
            }

            return Location;
        }
    }
}
