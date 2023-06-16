using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class FireBall : DynamicAmmunition
    {
        public FireBall() : base("Resources\\EntitySprites\\FireBall.png", new Effect()) { }

        public override void Update(float dt)
        {
            return;
        }
    }
}
