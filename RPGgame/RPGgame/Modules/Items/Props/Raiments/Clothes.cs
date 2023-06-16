﻿
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using System;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal enum TypeArmor
    {
        Head = 0, 
        Body = 1,
        Foots = 2
    }

    internal abstract class Clothes : Equipment
    {
        public Clothes(string path, List<Effect> effect) : base(path, effect) { }

        public abstract TypeArmor GetTypeArmor();
        public override void UseInStorage(Entity entity)
        {
            throw new Exception("useInStorage недоступен, так как функция не реализована");

        }
    }

}
