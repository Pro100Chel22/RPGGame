
using SFML.Graphics;
using SFML.System;

namespace RPGgame.Modules.Storages
{
    internal class Chest : Storage
    {
        public int idKey { get; private set; }
        public Sprite textur { get; private set; }
        public Vector2f position { get; set; }

        public Chest(int idKey) : base(false)
        {
            this.idKey = idKey;
        }

        public void Draw(RenderWindow renderIn)
        {
            renderIn.Draw(textur);
        }
    }
}
