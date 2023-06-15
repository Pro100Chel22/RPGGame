using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class Cuirass:Clothes
    {
        public override TypeArmor GetTypeArmor()
        {
            return TypeArmor.Body;
        }
    }
}

