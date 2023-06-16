using RPGgame.Modules.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class Sword : MeleeWeapons
    {
        public Sword() : base("Resources\\EntitySprites\\Sword.png") { }

        public override void Attack(Entity entity)
        {
            entity.Attack();
        }
    }
}
