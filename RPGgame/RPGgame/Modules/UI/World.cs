
using RPGgame.Modules.Storages;
using RPGgame.Modules.Entitys;
using SFML.Graphics;
using SFML.System;
using RPGgame.Modules.Items.Props;
using System.Collections.Generic;
using System;

namespace RPGgame.Modules.UI
{
    internal class World
    {
        public Scene Scene { get; private set; }
        public FloatRect[,] GridCollisions { get; private set; }
        public Entity Player { get; private set; }
        public List<Entity> Mobs { get; private set; }
        public List<Chest> Chests { get; private set; }
        private Sprite background;
        private float scale; //
        private List<DynamicAmmunition> dynamicAmmunitions;

        public World(Scene scene)
        {
            LoadWorldMap map = new LoadWorldMap("Resources\\Map");

            Scene = scene;
            GridCollisions = map.gridCollisions;
            Player = new Entity(Behaviour.CreatNew(0), this, map.player, new Vector2f(1, 0));

            Mobs = new List<Entity>();
            for (int i = 0; i < map.mobs.Length; i++)
            {
                Mobs.Add(new Entity(Behaviour.CreatNew((TypeBehaviourToCreat)map.mobs[i].type), this, map.mobs[i].pos, new Vector2f(1, 0)));
            }

            Chests = new List<Chest>();
            for (int i = 0;i < map.chests.Length; i++)
            {
                Chests.Add(new Chest(1) { Position = map.chests[i] });
            }

            background = map.background;
            scale = map.scale;

            dynamicAmmunitions = new List<DynamicAmmunition>(0);
        }

        public bool CheckIntersection(FloatRect hitbox)
        {
            for (int i = (int)(hitbox.Top / scale) - 1; i < (hitbox.Top + hitbox.Height / scale) + 1; i++)
            {
                for (int j = (int)(hitbox.Left / scale) - 1; j < (hitbox.Left + hitbox.Width / scale) + 1; j++)
                {
                    if (0 <= i && i < GridCollisions.GetLength(0) &&
                        0 <= j && j < GridCollisions.GetLength(1) &&
                        GridCollisions[i, j].Intersects(hitbox)
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
            Player.Update(dTime);
            for (int i = 0; i < Mobs.Count; i++)
            {
                Mobs[i].Update(dTime);
            }
            for (int i = 0; i < dynamicAmmunitions.Count; i++)
            {
                dynamicAmmunitions[i].Update(dTime, this);
                if (dynamicAmmunitions[i].HittingAnObject)
                {
                    dynamicAmmunitions.RemoveAt(i);
                    i -= 1;
                }
            }
        }
        public void Draw(RenderWindow renderIn)
        {
            renderIn.Draw(background);
            for (int i = 0; i < Chests.Count; i++)
            {
                //chests[i].Draw(renderIn);
            }
            for (int i = 0; i < Mobs.Count; i++)
            {
                Mobs[i].Draw(renderIn);
            }
            Player.Draw(renderIn);
            for(int i = 0;i < dynamicAmmunitions.Count; i++)
            {
                dynamicAmmunitions[i].Draw(renderIn);
            }
        }
    }
}
