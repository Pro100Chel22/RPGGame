using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Entitys.Behaviours
{
    internal class LoadModel
    {
        public Texture tx;
        public Sprite textur;
        public FloatRect hitbox;
        public LoadModel(string path, float scale = 0.7f)
        {
            tx = new Texture(path);
            textur = new Sprite(tx)
            {
                Scale = new Vector2f(scale, scale),
                Origin = new Vector2f(tx.Size.X / 2, tx.Size.Y / 2),
            };
            hitbox = new FloatRect(
                textur.TextureRect.Left * scale, textur.TextureRect.Top * scale,
                textur.TextureRect.Width * scale, textur.TextureRect.Height * scale
            );
        }
    }
}
