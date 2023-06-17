
using RPGgame.Modules.Items.Effects;
using SFML.Graphics;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class Arrow:DynamicAmmunition
    {
        public Arrow() : base("Resources\\EntitySprites\\Arrow.png", new List<Effect>()) 
        {
            Speed = 200;
            HitBox = new FloatRect(0, -20, 28, 6);
            Effects.Add(new Damage() { EffectValue = 20 });
            Effects.Add(new Bleeding());
        }
    }
}
