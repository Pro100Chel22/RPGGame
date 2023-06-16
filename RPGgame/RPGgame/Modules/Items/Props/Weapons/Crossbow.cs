
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class Crossbow : LongRangeWeapons
    {
        public Crossbow() : base("Resources\\EntitySprites\\Crossbow.png", new List<Effect>()) { }

        public override void Attack(Entity entity)
        {
           
        }
    }
}
