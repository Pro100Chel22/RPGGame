
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using System;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class EndurancePotion: Food
    {
        public EndurancePotion() : base("Resources\\EntitySprites\\EndurancePotion.png", new List<Effect>()) { }

        public override bool UseInStorage(Entity entity)
        {
            entity.AddEffect(new Endurance() { EffectValue = 2 });
            return true;
        }
    }
}
