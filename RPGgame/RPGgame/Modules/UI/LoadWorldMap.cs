using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.UI
{
    internal class LoadWorldMap
    {
        public bool[,] gridCollisions { get; private set; }
        public ConfigMob[] mobs { get; private set; }
        public Vector2f[] chests { get; private set; }
        public Vector2f player { get; private set; }
        public Sprite background { get; private set; }

        public LoadWorldMap(string path)
        {
            LoadPositionsOfGameObjects(path);
            LoadGridCollisions(path);

            background = new Sprite(new Texture(path + "\\Textur.png"));
            background.Scale = new Vector2f(6, 6);
        }

        private void LoadPositionsOfGameObjects(string path)
        {
            StreamReader reader = new StreamReader(path + "\\Config.txt");
            string line; int type = 0;
            ConfigMob[] newMobs = new ConfigMob[0];
            Vector2f[] newChests = new Vector2f[0];
            while ((line = reader.ReadLine()) != null)
            {
                switch (line)
                {
                    case "Player:": type = 0; break;
                    case "Mobs:": type = 1; break;
                    case "Chests:": type = 2; break;
                    default:
                        string[] values = line.Split(' ');
                        switch (type)
                        {
                            case 1:
                                player = new Vector2f(float.Parse(values[0]), float.Parse(values[1]));
                                break;
                            case 2:
                                Array.Resize(ref newMobs, newMobs.Length + 1);
                                newMobs[newMobs.Length - 1] = new ConfigMob
                                {
                                    pos = new Vector2f(float.Parse(values[0]), float.Parse(values[1])),
                                    type = 1
                                };
                                break;
                            case 3:
                                Array.Resize(ref newChests, newChests.Length + 1);
                                newChests[newChests.Length - 1] = new Vector2f(float.Parse(values[0]), float.Parse(values[1]));
                                break;
                        }
                        break;
                }
            }
            mobs = newMobs;
            chests = newChests;
        }

        private void LoadGridCollisions(string path)
        {
            Image imgCollision = new Image(path + "\\GridCollisions.png");
            gridCollisions = new bool[imgCollision.Size.Y, imgCollision.Size.X];
            for (uint i = 0; i < imgCollision.Size.Y; i++)
            {
                for (uint j = 0; j < imgCollision.Size.X; j++)
                {
                    if (imgCollision.GetPixel(j, i) == new Color(255, 255, 255))
                    {
                        gridCollisions[i, j] = true;
                    }
                    else
                    {
                        gridCollisions[i, j] = false;
                    }
                }
            }
        }
    }

    struct ConfigMob
    {
        public Vector2f pos;
        public int type;
    }
}
