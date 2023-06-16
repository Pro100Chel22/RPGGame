
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;

namespace RPGgame.Modules.Items.Props
{
    internal class Axe : MeleeWeapons
    {
        public Axe() : base("Resources\\EntitySprites\\Axe.png", new Effect()) { }

        public override void Attack(Entity entity)
        {
            
        }
    }
}
