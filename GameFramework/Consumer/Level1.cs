using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.Core;
using Framework.CollisionFolder;
using Framework.FireFolder;
using Framework.Movement;
using Framework.BoosterPills;

namespace Consumer
{
    public partial class Level1 : Form
    {
        Game hollowKnight;
        int loopCounter;
        public static ProgressBar h = new ProgressBar(), t = new ProgressBar();
        
        public Level1()
        {
            InitializeComponent();
            this.Controls.Add(h);
            this.WindowState = FormWindowState.Maximized;
            h.Value = 100;
            h.Location = new Point(100, 100);
            this.Controls.Add(t);
            t.Location = new Point(1268- 100, 100);
            t.Value = 100;
        }

        private void HollowKnight_Load(object sender, EventArgs e)
        {
            int ground = this.Height - 160;
            hollowKnight = new Game();
            hollowKnight.OnGameObjectAdded += new EventHandler(OnGameObjectAdded_Game);
            hollowKnight.OnPlayerDeath += new EventHandler(GameOver);
            hollowKnight.OnEnemyDeath += new EventHandler(removeObject);
            hollowKnight.OnFireOutofBoundary += new EventHandler(removeObject);
            hollowKnight.OnPillTaken += new EventHandler(removeObject);

            List<ObjectImage> PlayerActImages = new List<ObjectImage>() { new ObjectImage("ToLeftGif" ,Properties.Resources.ToLeftGif), new ObjectImage("ToRightGif", Properties.Resources.ToRightGif), new ObjectImage("AttackLeft", Properties.Resources.AttackLeft), new ObjectImage("AttackRight", Properties.Resources.AttackRight), new ObjectImage("InAirLeft", Properties.Resources.InAirLeft), new ObjectImage("InAirRight", Properties.Resources.InAirRight), new ObjectImage("JumpToLeft", Properties.Resources.jumpToLeft), new ObjectImage("JumpToRight", Properties.Resources.jumpToRight) };
            Point boundary = new Point(this.Width, this.Height);

            //hollowKnight.addGameObject(ToRightGif, ObjectType.Enemy, 200, 200, new HorizontalMovement(8, boundary, "right"), null, new HorizontalFire());
            hollowKnight.addGameObject(Properties.Resources.ToRightGif, ObjectType.Player, 100, this.Height - 160, new KeyboardMovement(8, boundary, "right",ground, ref loopCounter, PlayerActImages, hollowKnight), new HUD(100,13,20,0.75,40,h), new HorizontalFire());
            hollowKnight.addGameObject(Properties.Resources.HatchlingFlyLeft, ObjectType.Enemy, 600, ground + 60 ,new HorizontalMovement(8,boundary, "left"), new HUD(100, 4, 20, 0.75, 40, t), new HorizontalFire());
            //hollowKnight.addGameObject(Properties.Resources.HatchlingFlyLeft, ObjectType.Enemy, 1000, ground + 60, new HorizontalMovement(8, boundary, "Right")/*new FollowObject(2, hollowKnight.getPlayerObject())*/, new HUD(100, 4, 20, 0.75, 40, t), new HorizontalFire());
            hollowKnight.addGameObject(Properties.Resources.BooflyLeftGif, ObjectType.Enemy, 900, ground + 45, null/*new FollowObject(2, hollowKnight.getPlayerObject())*/, new HUD(100, 4, 20, 0.75, 40, t), new HorizontalTwoFire());

            hollowKnight.addCollision(ObjectType.Player, FireType.EnemyFire, new PlayerCollisionWithFire());
            hollowKnight.addCollision(ObjectType.Enemy, FireType.PlayerFire, new EnemyCollisionWithFire());
            hollowKnight.addCollision(ObjectType.Player, Pilltype.HealthExtendPill, new PlayerCollisionWithPill());
            hollowKnight.addCollision(ObjectType.Player, Pilltype.HealthRecoverPill, new PlayerCollisionWithPill());

            hollowKnight.addPill(Properties.Resources.healhRecoverPill, new Point(-100, -100), Pilltype.HealthRecoverPill, new HealthRecoverPill(25));
            hollowKnight.addPill(Properties.Resources.healthExtendPill, new Point(-100, -100), Pilltype.HealthExtendPill, new MaxHealthIncPill(25));
        }

        private void GameOver(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            this.Controls.Remove(pb);
            this.Hide();
            GameOver form = new GameOver();
            form.Show();
        }

        private void removeObject(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            this.Controls.Remove(pb);
        }

        private void OnGameObjectAdded_Game(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            this.Controls.Add(pb);
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            loopCounter++;
            hollowKnight.update();

            if(hollowKnight.GameObjectList.Count ==1 && hollowKnight.PillsOnStage.Count == 0 && hollowKnight.getPlayerObject().ObjectStats.IsAlive())
            {
                this.Hide();
                Level2 form = new Level2();
                form.Closed += (s,args)=>this.Close();
                
                form.Show();
                GameLoop.Enabled = false;
            }
        }
    }
}
