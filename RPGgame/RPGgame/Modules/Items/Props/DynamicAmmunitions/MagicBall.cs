using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class MagicBall : DynamicAmmunition
    {
        public MagicBall() : base("Resources\\EntitySprites\\MagicBall.png", new Effect()) { }

        public override void Update(float dt)
        {
            return;
        }
    }
}
