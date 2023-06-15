
using RPGgame.Modules.Storages;
using RPGgame.Modules.Entitys;
using SFML.Graphics;
using SFML.System;
using System;
using System.Security.Cryptography;
using RPGgame.Modules.Items.Props;
using System.Linq;
using System.Collections.Generic;
using RPGgame.Modules.Entitys.Behaviours;

namespace RPGgame.Modules.UI
{
    internal class World
    {
        public Scene scene { get; private set; }
        public FloatRect[,] gridCollisions { get; private set; }
        public Entity player { get; private set; }
        private Entity[] mobs;
        private Chest[] chests;
        private Sprite background;
        private Texture tx; //
        private float scale; //
        private List<DynamicAmmunition> dynamicAmmunitions;

        public World(Scene scene)
        {
            LoadWorldMap map = new LoadWorldMap("Resources\\Map");

            this.scene = scene;
            gridCollisions = map.gridCollisions;
            player = new Entity(Behaviour.CreatNew(0), this, map.player, new Vector2f(1, 0));
            //player.interaction = new Entity(Behaviour.CreatNew(0), this, new Vector2f(), new Vector2f());
            //player.interaction.GetInventory().PutItem(new Sword());

            mobs = new Entity[0];
            chests = new Chest[0];

            background = map.background;
            scale = map.scale;

            dynamicAmmunitions = new List<DynamicAmmunition>(0);

            //Console.WriteLine(map.player);
            //Console.WriteLine(map.mobs);
            //Console.WriteLine(map.chests);
        }

        public bool CheckIntersection(FloatRect hitbox)
        {
            for (int i = (int)(hitbox.Top / scale) - 1; i < (hitbox.Top + hitbox.Height / scale) + 1; i++)
            {
                for (int j = (int)(hitbox.Left / scale) - 1; j < (hitbox.Left + hitbox.Width / scale) + 1; j++)
                {
                    if (0 <= i && i < gridCollisions.GetLength(0) &&
                        0 <= j && j < gridCollisions.GetLength(1) &&
                        gridCollisions[i, j].Intersects(hitbox)
                    )
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public void AddDynamicAmmunition(DynamicAmmunition dynamicAmmunition)
        {
            dynamicAmmunitions.Add(dynamicAmmunition);
        }
        public void Update(float dTime)
        {
            player.Update(dTime);
            for (int i = 0; i < mobs.Length; i++)
            {
                mobs[i].Update(dTime);
            }
            for(int i = 0; i < dynamicAmmunitions.Count; i++)
            {
                dynamicAmmunitions[i].Update(dTime);
            }
        }
        public void Draw(RenderWindow renderIn)
        {
            renderIn.Draw(background);
            player.Draw(renderIn);
            for (int i = 0; i < mobs.Length; i++)
            {
                mobs[i].Draw(renderIn);
            }
            for (int i = 0; i < chests.Length; i++)
            {
                chests[i].Draw(renderIn);
            }

            //CircleShape shape2 = new CircleShape(1);
            //CircleShape shape3 = new CircleShape(1);
            //shape2.Origin = new Vector2f(shape2.Radius / 2, shape2.Radius / 2);
            //shape3.Origin = new Vector2f(shape3.Radius / 2, shape3.Radius / 2);
            //for (int i = 0; i < gridCollisions.GetLength(0); i++)
            //{
            //    for (int j = 0; j < gridCollisions.GetLength(1); j++)
            //    {
            //        if (gridCollisions[i, j].Width != 0 && gridCollisions[i, j].Height != 0)
            //        {
            //            Vector2f position = new Vector2f();

            //            shape2.FillColor = Color.Blue;
            //            shape2.Position = new Vector2f(gridCollisions[i, j].Left, gridCollisions[i, j].Top) + position;
            //            renderIn.Draw(shape2);

            //            shape3.FillColor = Color.Blue;
            //            shape3.Position = new Vector2f(gridCollisions[i, j].Left + gridCollisions[i, j].Width, gridCollisions[i, j].Top + gridCollisions[i, j].Height) + position;
            //            renderIn.Draw(shape3);
            //        }
            //    }
            //}
        }
    }
}
