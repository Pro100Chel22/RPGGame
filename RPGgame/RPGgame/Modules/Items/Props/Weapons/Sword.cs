
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;

namespace RPGgame.Modules.Items.Props
{
    internal class Sword : MeleeWeapons
    {
        public Sword() : base("Resources\\EntitySprites\\Sword.png", new Effect()) { }

        public override void Attack(Entity entity)
        {
           
        }
    }
}
