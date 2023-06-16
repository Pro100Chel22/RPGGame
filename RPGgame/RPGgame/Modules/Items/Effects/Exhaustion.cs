using RPGgame.Modules.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Effects
{
    internal class Exhaustion: TemporaryEffect
    {
        public Exhaustion() 
        {
            EffectValue = 1;
        }

        public override void Employ(IAlive Alive)
        {
            Alive.ReduceEndurance(EffectValue);
        }
    }
}
