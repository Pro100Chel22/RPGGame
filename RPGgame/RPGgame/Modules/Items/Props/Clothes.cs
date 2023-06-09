using RPGgame.Modules.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    public enum TypeArmor
    {
        Head, 
        Body,
        Foots
    }
    internal class Clothes : Equipment
    {
        public TypeArmor TypeArmor { get; private set; }
        public override void UseInStorage(Entity entity)
        {
            throw new Exception("useInStorage недоступен, так как функция не реализована");

        }
    }

}
