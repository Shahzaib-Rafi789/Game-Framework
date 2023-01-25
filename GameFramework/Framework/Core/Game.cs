using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Framework.CollisionFolder;
using Framework.Movement;
using Framework.FireFolder;
using Framework.BoosterPills;

namespace Framework.Core
{
    public class Game : IGame
    {
        List<GameObject> gameObjectList;
        List<Collision> gameCollisions;
        List<Fire> gameFires;
        List<Booster> gamePills, pillsOnStage;


        EventHandler onGameObjectAdded;
        EventHandler onPlayerDeath;
        EventHandler onEnemyDeath;
        EventHandler onFireOutofBoundary;
        EventHandler onPillTaken;

        public Game()
        {
            GameObjectList = new List<GameObject>();
            gameCollisions = new List<Collision>();
            gameFires = new List<Fire>();
            GamePills = new List<Booster>();
            PillsOnStage = new List<Booster>();
        }

        public EventHandler OnGameObjectAdded { get => onGameObjectAdded; set => onGameObjectAdded = value; }
        public List<Collision> GameCollisions { get => gameCollisions; set => gameCollisions = value; }
        public EventHandler OnPlayerDeath { get => onPlayerDeath; set => onPlayerDeath = value; }
        public List<Fire> GameFires { get => gameFires; set => gameFires = value; }
        public EventHandler OnFireOutofBoundary { get => onFireOutofBoundary; set => onFireOutofBoundary = value; }
        public EventHandler OnEnemyDeath { get => onEnemyDeath; set => onEnemyDeath = value; }
        public List<Booster> GamePills { get => gamePills; set => gamePills = value; }
        public List<Booster> PillsOnStage { get => pillsOnStage; set => pillsOnStage = value; }
        public EventHandler OnPillTaken { get => onPillTaken; set => onPillTaken = value; }
        public List<GameObject> GameObjectList { get => gameObjectList; set => gameObjectList = value; }

        public void addGameObject(Image img, ObjectType otype, int left, int top, IMovement movement, HUD hud, IFire firestyle)
        {
            GameObject gameObj = new GameObject(img, otype,left, top, movement, hud, firestyle);
            GameObjectList.Add(gameObj);
            onGameObjectAdded?.Invoke(gameObj.Pb, EventArgs.Empty);
            //gameObj.Movement.
        }

        public void addCollision(ObjectType ob1, ObjectType ob2, ICollisionAction collision)
        {
            Collision c = new Collision(ob1, ob2, collision);
            this.GameCollisions.Add(c);
        }

        public void addCollision(ObjectType ob1, FireType ob2, ICollisionAction collision)
        {
            Collision c = new Collision(ob1, ob2, collision);
            this.GameCollisions.Add(c);
        }

        public void addCollision(ObjectType ob1, Pilltype ob2, ICollisionAction collision)
        {
            Collision c = new Collision(ob1, ob2, collision);
            this.GameCollisions.Add(c);
        }

        public void addPill(Image pillAp, Point location, Pilltype pType, IBooster boosterEffect)
        {
            Booster Pill = new Booster(pillAp, location, pType, boosterEffect);
            gamePills.Add(Pill);
            onGameObjectAdded?.Invoke(Pill.Pill, EventArgs.Empty);
        }

        public GameObject getPlayerObject()
        {
            foreach(GameObject i in GameObjectList)
            {
                if(i.OType == ObjectType.Player) 
                { 
                    return i;
                }                
            }
            return null;
        }

        public void RaisePlayerDeathEvent(PictureBox playerpb)
        {            
            OnPlayerDeath?.Invoke(playerpb, EventArgs.Empty);
        }

        public void RaiseEnemyDeathEvent(PictureBox Enemypb)
        {
            OnEnemyDeath?.Invoke(Enemypb, EventArgs.Empty);
            PlacePill(new Point( Enemypb.Location.X + (int)(0.4 * Enemypb.Width) , Enemypb.Location.Y + Enemypb.Height - 30));

        }

        public void RemoveObject(GameObject ob)
        {
            GameObjectList.Remove(ob);
        }

        public void RaiseFireOutOfBoundaryEvent(Fire fire)
        {
            OnFireOutofBoundary?.Invoke(fire.FireApperance, EventArgs.Empty);
        }

        public void update()
        {
            detectCollision();
            GenerateFire();
            MoveFire();
            //CheckFireLocations();

            foreach (GameObject i in GameObjectList)
            {
                if (i.Movement != null)
                {
                    i.move();
                }
            }
        }

        private void detectCollision()
        {

            if (GameObjectList.Count != 0)
            {
                for (int x = 0; x < GameObjectList.Count && GameObjectList.Count != 0; x++)
                {
                    for (int y = 0; y < gameFires.Count && gameFires.Count != 0; y++)
                    {
                        if (GameObjectList.Count >1 && GameObjectList[x].Pb.Bounds.IntersectsWith(gameFires[y].FireApperance.Bounds))
                        {
                            foreach (Collision c in gameCollisions)
                            {
                                if (GameObjectList.Count >1 && c.Object2 == ObjectType.None && c.Object4 == Pilltype.None)
                                {
                                    if (GameObjectList[x].OType == c.Object1 && gameFires[y].OFire == c.Object3)
                                    {
                                        c.Behaviour.PerformAction(this, GameObjectList[x], GameFires[y]);
                                    }
                                }
                            }
                        }
                    }

                }

                for (int x = 0; x < GameObjectList.Count && GameObjectList.Count != 0; x++)
                {
                    if (PillsOnStage.Count > 0)
                    {
                        for (int y = 0; y < PillsOnStage.Count && PillsOnStage.Count > 0; y++)
                        {

                            if (PillsOnStage.Count > 0 && GameObjectList[x].Pb.Bounds.IntersectsWith(PillsOnStage[y].Pill.Bounds))
                            {
                                for(int i = 0; i < gameCollisions.Count && gameCollisions.Count!=0; i++) 
                                {
                                    if (PillsOnStage.Count > 0 && (gameCollisions[i].Object2 == ObjectType.None && gameCollisions[i].Object3 == FireType.None))
                                    {
                                        if (GameObjectList[x].OType.Equals(gameCollisions[i].Object1)  && PillsOnStage[y].PType ==  gameCollisions[i].Object4)
                                        {
                                            gameCollisions[i].Behaviour.PerformAction(this, GameObjectList[x], PillsOnStage[y]);
                                        }
                                    }
                                }
                            }

                        }
                    }

                }

                //for (int x = 0; x < gameObjectList.Count; x++)
                //{
                //    for (int y = 0; y < GameFires.Count; y++)
                //    {
                //        if (gameObjectList[x].Pb.Bounds.IntersectsWith(gameFires[y].FireApperance.Bounds))
                //        {
                //            foreach (Collision c in gameCollisions)
                //            {
                //                if (gameObjectList[x].OType == c.Object1 && gameObjectList[y].OType == c.Object2)
                //                {
                //                    c.Behaviour.PerformAction(this, gameObjectList[x], gameObjectList[y]);
                //                }
                //            }
                //        }
                //    }


                //}
            }
        }

        private void GenerateFire()
        {
            foreach(GameObject i in GameObjectList)
            {
                if(i.OType == ObjectType.Enemy)
                {
                    Random r = new Random();
                    int n = r.Next(0,50);

                    if (n == 4)
                    {
                        List<Fire> f = i.FireStyle.DrawFire( Properties.Resources.EnemyFire, new Point(i.Pb.Left + i.Pb.Width / 2, i.Pb.Top + i.Pb.Height / 2), "left", FireType.EnemyFire);
                        AddFireIntoList(f);
                    }
                }
            }
        }

        public void AddFireIntoList(List<Fire> f)
        {
            for (int j = 0; j < f.Count; j++)
            {
                onGameObjectAdded?.Invoke(f[j].FireApperance, EventArgs.Empty);
            }
            gameFires.AddRange(f);
        }

        private void MoveFire()
        {
            foreach(Fire i in gameFires)
            {
                if(i.FireDirection == "right")
                {
                    i.FireApperance.Left += 12;
                }
                else if (i.FireDirection == "left")
                {
                    i.FireApperance.Left -= 12;
                }
            }
        }

        private void CheckFireLocations()
        {
            for(int i=0; i< gameFires.Count; i++)
            {
                if(gameFires[i].FireApperance.Bottom<0 || gameFires[i].FireApperance.Right<0 || gameFires[i].FireApperance.Top > 800 || gameFires[i].FireApperance.Left<1400)
                {
                    RemoveFire(gameFires[i]);
                }
            }
        }

        public void RemoveFire(Fire f)
        {
            GameFires.Remove(f);
            RaiseFireOutOfBoundaryEvent(f);
        }

        public void RemovePill(Booster b)
        {
            PillsOnStage.Remove(b);
            OnPillTaken?.Invoke(b.Pill, EventArgs.Empty);
        }

        private void PlacePill(Point location)
        {
            Random rnd = new Random();
            int probability = rnd.Next(0, gamePills.Count);

            Booster pill = new Booster(gamePills[probability].Pill.Image, location, gamePills[probability].PType, gamePills[probability].BoosterEffect);
            PillsOnStage.Add(pill);
            onGameObjectAdded?.Invoke(pill.Pill, EventArgs.Empty);
        }
    }
}
