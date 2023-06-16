using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class Cuirass:Clothes
    {
        public Cuirass() : base("Resources\\EntitySprites\\Cuirass.png", new Effect()) { }

        public override TypeArmor GetTypeArmor()
        {
            return TypeArmor.Body;
        }
    }
}

