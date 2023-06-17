
using RPGgame.Modules.Items.Effects;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class Sword : MeleeWeapons
    {
        public Sword() : base("Resources\\EntitySprites\\Sword.png", new List<Effect>())
        {
            DistanceOfAttack = 50;
            AttackPower = 15;
            TimeAttack = 0.5f;
            Effects.Add(new Damage()
            {
                EffectValue = 30
            });
        }
    }
}
