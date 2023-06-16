
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using System;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class EndurancePotion: Food
    {
        public EndurancePotion() : base("Resources\\EntitySprites\\EndurancePotion.png", new List<Effect>()) { }

        public override void UseInStorage(Entity entity)
        {
            throw new Exception("useInStorage недоступен, так как функция не реализована");

        }
    }
}
