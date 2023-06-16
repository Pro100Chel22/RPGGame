
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
        public Scene scene { get; private set; }
        public FloatRect[,] gridCollisions { get; private set; }
        public Entity player { get; private set; }
        private List<Entity> mobs;
        private List<Chest> chests;
        private Sprite background;
        private float scale; //
        private List<DynamicAmmunition> dynamicAmmunitions;

        public World(Scene scene)
        {
            LoadWorldMap map = new LoadWorldMap("Resources\\Map");

            this.scene = scene;
            gridCollisions = map.gridCollisions;
            player = new Entity(Behaviour.CreatNew(0), this, map.player, new Vector2f(1, 0));
            //player.interaction = new Chest(1);
            ////player.interaction = new Entity(Behaviour.CreatNew(0), this, new Vector2f(), new Vector2f());
            //player.interaction.GetInventory().PutItem(new Helmet());
            //player.interaction.GetInventory().PutItem(new Boots());  
            //player.interaction.GetInventory().PutItem(new Key());
            //player.interaction.GetInventory().PutItem(new Note());

            //player.interaction.GetInventory().PutItem(new EndurancePotion());
            //player.interaction.GetInventory().PutItem(new TreatmentPotion());
            //player.interaction.GetInventory().PutItem(new ResistancePotion());

            //player.interaction.GetInventory().PutItem(new FireBall());
            //player.interaction.GetInventory().PutItem(new MagicBall());

            //player.interaction.GetInventory().PutItem(new Sword());
            //player.interaction.GetInventory().PutItem(new Axe());
            //player.interaction.GetInventory().PutItem(new Crossbow());

            mobs = new List<Entity>();
            for (int i = 0; i < map.mobs.Length; i++)
            {
                Console.WriteLine(map.mobs[i].type);
                mobs.Add(new Entity(Behaviour.CreatNew((TypeBehaviourToCreat)map.mobs[i].type), this, map.mobs[i].pos, new Vector2f(1, 0)));
            }

            chests = new List<Chest>();

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
            for (int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Update(dTime);
            }
            for (int i = 0; i < dynamicAmmunitions.Count; i++)
            {
                dynamicAmmunitions[i].Update(dTime);
            }
        }
        public void Draw(RenderWindow renderIn)
        {
            renderIn.Draw(background);
            for (int i = 0; i < chests.Count; i++)
            {
                chests[i].Draw(renderIn);
            }
            for (int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Draw(renderIn);
            }
            player.Draw(renderIn);
        }
    }
}
