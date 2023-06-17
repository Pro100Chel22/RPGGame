using RPGgame.Modules.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Effects
{
    internal class Damage : MomentaryEffect
    {
        public override void Employ(IAlive Alive)
        {
            Alive.DealDamage(EffectValue);
        }
  
    }
}
