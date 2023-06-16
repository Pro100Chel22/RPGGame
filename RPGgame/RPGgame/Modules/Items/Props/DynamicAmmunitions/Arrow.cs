using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class Arrow:DynamicAmmunition
    {
        public Arrow() : base("Resources\\EntitySprites\\Arrow.png") { }

        public override void Update(float dt)
        {
            return;
        }
    }
}
