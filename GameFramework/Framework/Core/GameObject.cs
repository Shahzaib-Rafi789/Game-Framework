using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Framework.Movement;
using Framework.FireFolder;
using Framework.CollisionFolder;

namespace Framework.Core
{
    public class GameObject
    {
        PictureBox pb;
        ObjectType oType;
        IMovement movement;
        IFire fireStyle;
        HUD objectStats;

        public GameObject(Image img, ObjectType otype, int left, int top, IMovement movement, HUD objectStats, IFire fireStyle)
        {
            Pb = new PictureBox();
            pb.Image = img;
            pb.Size = img.Size;
            pb.BackColor = Color.Transparent;
            pb.Left = left;
            pb.Top = top;
            this.Movement = movement;
            this.OType = otype;
            this.ObjectStats = objectStats;
            this.FireStyle = fireStyle;
        }

        public ObjectType OType { get => oType; set => oType = value; }
        public PictureBox Pb { get => pb; set => pb = value; }
        public HUD ObjectStats { get => objectStats; set => objectStats = value; }
        public IFire FireStyle { get => fireStyle; set => fireStyle = value; }
        internal IMovement Movement { get => movement; set => movement = value; }

        //public void MoveLeft()
        //{
        //    pb.Left -= steps;
        //}

        //public void MoveRight()
        //{
        //    pb.Left += steps;
        //}

        //public void MoveUp()
        //{
        //    pb.Top -= steps;
        //}

        //public void MoveDown()
        //{
        //    pb.Top += steps;
        //}

        //public void MoveViaKeyboard()
        //{
        //    //if (Keyboard.IsKeyPressed(Key.UpArrow)) { MoveUp(); }
        //    //if (Keyboard.IsKeyPressed(Key.DownArrow)) { MoveDown(); }
        //    //if (Keyboard.IsKeyPressed(Key.LeftArrow)) { MoveLeft(); }
        //    //if (Keyboard.IsKeyPressed(Key.RightArrow)) { MoveRight(); }
        //}

        public void move()
        {
            if (Movement != null)
            {
                this.pb.Location = Movement.move(this.pb ,this.pb.Location);
            }
        }
    }
}

