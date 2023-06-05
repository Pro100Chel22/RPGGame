
using RPGgame.Modules.Storages;
using RPGgame.Modules.Entitys;
using SFML.Graphics;
using SFML.System;
using System;
using System.IO;

namespace RPGgame.Modules.UI
{
    internal class World
    {
        public Scene scene { get; private set; }
        public bool[,] gridCollisions { get; private set; }
        public Entity player { get; private set; }
        private Entity[] mobs;
        private Chest[] chests;
        private Sprite background;
        private Texture tx;
        // private DynamicAmmunition[] dynamicAmmunitions;

        RectangleShape s = new RectangleShape
        {
            Size = new Vector2f(100, 100),
            FillColor = Color.White,
        };

        public World(Scene scene)
        {
            this.scene = scene;
            //player = new Entity();
            //mobs = new Entity[0];
            //chests = new Chest[0];            
            // dynamicAmmunitions = new DynamicAmmunitions[0]
            LoadWorldMap map = new LoadWorldMap("Resources\\Map");

            gridCollisions = map.gridCollisions;
            background = map.background;

            //Console.WriteLine(map.player);
            //Console.WriteLine(map.mobs);
            //Console.WriteLine(map.chests);
        }

        public void AddDynamicAmmunition() // DynamicAmmunitions
        {
            throw new Exception("AddDynamicAmmunition недоступен, так как функция не реализована");
        }
        public void Update(float dTime)
        {
            if (scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonA))
            {
                s.Position += new Vector2f(-200.0f * dTime, 0);
            }
            if (scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonD))
            {
                s.Position += new Vector2f(200.0f * dTime, 0);
            }
            if (scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonW))
            {
                s.Position += new Vector2f(0, -200.0f * dTime);
            }
            if (scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonS))
            {
                s.Position += new Vector2f(0, 200.0f * dTime);
            }
        }
        public void Draw(RenderWindow renderIn)
        {
            renderIn.Draw(background);
            renderIn.Draw(s);
        }
    }
}
