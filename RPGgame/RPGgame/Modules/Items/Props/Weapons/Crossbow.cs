using RPGgame.Modules.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class Crossbow : LongRangeWeapons
    {
        public Crossbow() : base("Resources\\EntitySprites\\Crossbow.png", new Effect()) { }

        public override void Attack(Entity entity)
        {
           
        }
    }
}
