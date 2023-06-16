
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;

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
