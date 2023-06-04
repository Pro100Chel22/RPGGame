
using RPGgame.Modules.Storages;
using RPGgame.Modules.Entitys;
using SFML.Graphics;
using SFML.System;

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
        // private DynamicAmmunition[] dynamicAmmunitions;

        public World(Scene scene)
        {
            this.scene = scene;
            //gridCollisions = new bool[,] { { true, true }, { false, false } };
            //player = new Entity();
            //mobs = new Entity[0];
            //chests = new Chest[0];
            //background = new Sprite();
            //// dynamicAmmunitions = new DynamicAmmunitions[0]
            LoadWorldMap map = new LoadWorldMap("Resources\\Map");
        }

        public void addDynamicAmmunition() // DynamicAmmunitions
        {

        }

        public void update(float dTime)
        {

        }

        public void draw(RenderWindow renderIn)
        {

        }
    }

    class LoadWorldMap
    {
        public bool[,] gridCollisions { get; private set; }
        public ConfigMob[] mobs { get; private set; }
        public Vector2f[] chests { get; private set; }
        public Vector2f player { get; private set; }
        public Sprite background { get; private set; }

        public LoadWorldMap(string path)
        {
            gridCollisions = new bool[,] { { true, true }, { false, false } };
            player = new Vector2f();
            mobs = new ConfigMob[0];
            chests = new Vector2f[0];
            background = new Sprite();
        }
    }

    struct ConfigMob
    {
        Vector2f pos;
        int type;
    }
}
