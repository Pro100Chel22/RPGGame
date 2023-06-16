
using RPGgame.Modules.Items.Effects;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class MagicBall : DynamicAmmunition
    {
        public MagicBall() : base("Resources\\EntitySprites\\MagicBall.png", new List<Effect>()) 
        {
            Speed = 200;
            HitBox = new FloatRect(2, -30, 25, 25);
            Effects.Add(new Damage() { EffectValue = 50 });
        }
    }
}
