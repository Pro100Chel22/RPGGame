using RPGgame.Modules.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class Crossbow: LongRangeWeapons
    {
        public override void Attack(Entity entity)
        {
            entity.Attack();
        }
    }
}
