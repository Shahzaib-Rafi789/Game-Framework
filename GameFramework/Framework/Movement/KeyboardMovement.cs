using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using EZInput;
using Framework.Core;
using Framework.FireFolder;

namespace Framework.Movement
{
    public class KeyboardMovement : IMovement
    {
        int speed;
        System.Drawing.Point boundary;
        string Direction;
        int loopCounter;
        string State;
        int initialTop, attackGap = 8, iterationCount=0;
        Game game;
        PictureBox Apperance = new PictureBox();
        List<ObjectImage> ObjectImages;

        public PictureBox Apperance1 { get => Apperance; set => Apperance = value; }

        public KeyboardMovement(int speed, System.Drawing.Point boundary, string direction, int top, ref int loopCounter, List<ObjectImage> Resources, Game game)
        {
            this.speed = speed;
            this.boundary = boundary;
            this.Direction = direction;
            this.loopCounter = loopCounter;
            iterationCount = loopCounter;
            State = "Idle";
            ObjectImages = Resources;
            initialTop = top;
            this.game = game;
        }

        public System.Drawing.Point move(PictureBox pb,System.Drawing.Point Location)
        {
            Apperance = pb;
            HUD PlayerHUD = game.getPlayerObject().ObjectStats;
            Location = SetStateToIdle(Location);
            PlayerHUD.RecoverStamina();
            iterationCount++;

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                if (Apperance.Right + speed + 10 <= boundary.X)
                {
                    if (State != "Jump" && State != "InAir")
                    {
                        ChangeStats("Idle", "right", GetImage("ToRightGif"));
                        Location.X += speed;
                    }
                    else
                    {
                        if (Direction == "left" && State == "InAir")
                        {
                            Direction = "right";
                            Apperance1.Image = GetImage("InAirRight");
                        }
                        Location.X += (speed / 2 + speed / 4);

                    }
                }
            }

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                if (Apperance.Left - speed >= 0)
                {
                    if (State != "Jump" && State != "InAir")
                    {
                        ChangeStats("Idle", "left", GetImage("ToLeftGif"));
                        Location.X -= speed;
                    }
                    else
                    {
                        if (Direction == "right" && State == "InAir")
                        {
                            Direction = "left";
                            Apperance1.Image = GetImage("InAirLeft");
                        }
                        Location.X -= (speed / 2 + speed / 4);
                    }
                }
            }

            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                if (State != "Jump" && State != "InAir")
                {
                    Image ImageToSet;
                    if (Direction == "left") { ImageToSet = GetImage("JumpToLeft"); }
                    else { ImageToSet = GetImage("JumpToRight"); }

                    ChangeStats("Jump", Direction, ImageToSet);
                    //Apperance.Top -= 3 * Steps;
                }
            }

            if (Keyboard.IsKeyPressed(Key.Space))
            {
                if (State == "Idle" && PlayerHUD.Stamina + 15 >= PlayerHUD.AttackStamina && attackGap < iterationCount)
                {
                    iterationCount = 0;
                    PlayerHUD.DepleteStamina();

                    Image ImageToSet;
                    if (Direction == "right") { ImageToSet = GetImage("AttackRight"); }
                    else { ImageToSet = GetImage("AttackLeft"); }

                    ChangeStats("Attack", Direction, ImageToSet);

                    List<Fire> f = game.getPlayerObject().FireStyle.DrawFire(Properties.Resources.Fire, new System.Drawing.Point(Apperance.Location.X + Apperance.Width/2, Apperance.Location.Y + Apperance.Height/2), Direction, FireType.PlayerFire);
                    game.AddFireIntoList(f);
                    //Image Img = Properties.Resources.Fire;
                    //Fire PlayerFire = new Fire(null, null);
                    //System.Drawing.Point location = new System.Drawing.Point();
                    //if (Direction == "right") { location = new System.Drawing.Point(Apperance.Right + 8, Apperance.Top + 70); }
                    //else if (Direction == "left") { location = new System.Drawing.Point(Location.X - 24, Apperance.Top + 70); }

                    //PlayerFire = PlayerFire.DrawFire(Img, location, Direction);
                    //Program.form1.Controls.Add(PlayerFire.FireApperance);
                    //AddFire(PlayerFire);
                    //SetToIdle();
                }
            }

            //if (Keyboard.IsKeyPressed(Key.LeftArrow) && (Location.X - speed) >= 0)
            //{
            //    Location.X -= speed;
            //}
            //else if ((Keyboard.IsKeyPressed(Key.RightArrow) && (Location.X + offset) < boundary.X))
            //{
            //    Location.X += speed;
            //}
            //else if(Keyboard.IsKeyPressed(Key.UpArrow) && (Location.Y - speed)>= 0)
            //{
            //    Location.Y -= speed;
            //}
            //else if (Keyboard.IsKeyPressed(Key.DownArrow) && (Location.Y + offset) <= boundary.Y)
            //{
            //    Location.Y += speed;
            //}

            return Location;
        }

        private System.Drawing.Point SetStateToIdle(System.Drawing.Point location)
        {
            if (State == "Attack")
            {
                if (loopCounter % 2 == 0)
                {
                    if (Direction == "left") { ChangeStats("Idle", Direction, GetImage("ToLeftGif")); }
                    else if (Direction == "right") { ChangeStats("Idle", Direction, GetImage("ToRightGif")); }
                }
            }
            else if (State == "Jump")
            {
                if (loopCounter % 3 == 0)
                {
                    if (location.Y > ((initialTop) - 15 * speed))
                    {
                        location.Y -= (int)(2.5 * speed);
                    }
                    else
                    {
                        if (Direction == "left") { ChangeStats("InAir", Direction, GetImage("InAirLeft")); }
                        else if (Direction == "right") { ChangeStats("InAir", Direction, GetImage("InAirRight")); }
                    }
                }
            }
            else if (State == "InAir")
            {
                if (loopCounter % 2 == 0)
                {
                    if (location.Y < (initialTop))
                    {
                        location.Y += (int)(1 * speed);
                    }
                    else
                    {
                        if (Direction == "left") { ChangeStats("Idle", Direction, GetImage("ToLeftGif")); }
                        else if (Direction == "right") { ChangeStats("Idle", Direction, GetImage("ToRightGif")); }
                    }
                }
            }

            return location;
        }

        private void ChangeStats(string NewState, string Direction, Image ImageToSet)
        {
            if (State == NewState)
            {
                if (!CompareDirection(Direction))
                {
                    this.Direction = Direction;
                    Apperance1.Image = ImageToSet;
                }
            }
            else
            {
                State = NewState;
                this.Direction = Direction;
                Apperance1.Image = ImageToSet;
            }
        }

        private bool CompareDirection(string Direction)
        {
            if (this.Direction == Direction) { return true; }
            return false;
        }

        private Image GetImage(string name)
        {
            foreach(ObjectImage i in ObjectImages)
            {
                if(i.ImageName == name)
                {
                    return i.Img;
                }
            }
            return null;
        }
    }
}
