using RPGgame.Modules.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Clothes(string path) : base(path) { }

        public abstract TypeArmor GetTypeArmor();
        public override void UseInStorage(Entity entity)
        {
            throw new Exception("useInStorage недоступен, так как функция не реализована");

        }
    }

}
