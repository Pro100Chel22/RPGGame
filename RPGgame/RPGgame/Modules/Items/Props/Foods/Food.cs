
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using System;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class Food : Equipment
    {
        public Food(string path, List<Effect> effect) : base(path, effect) { }

        public override void UseInStorage(Entity entity)
        {
            throw new Exception("useInStorage недоступен, так как функция не реализована");
        }
    }
}
