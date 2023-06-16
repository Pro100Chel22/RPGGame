
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using System;

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
        public Clothes(string path, Effect effect) : base(path, effect) { }

        public abstract TypeArmor GetTypeArmor();
        public override void UseInStorage(Entity entity)
        {
            throw new Exception("useInStorage недоступен, так как функция не реализована");

        }
    }

}
