
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using System;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class Axe : MeleeWeapons
    {
        public Axe() : base("Resources\\EntitySprites\\Axe.png", new List<Effect>()) 
        {
            DistanceOfAttack = 50;
            AttackPower = 10;
            TimeAttack = 1;
            Effects.Add(new Damage()
            {
                EffectValue = 50
            });
        }
    }
}
