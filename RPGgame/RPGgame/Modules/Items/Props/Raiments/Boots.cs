using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class Boots: Clothes
    {
        public Boots() : base("Resources\\EntitySprites\\Boots.png") { }

        public override TypeArmor GetTypeArmor()
        {
            return TypeArmor.Foots;
        }
        //right?
    }
}
