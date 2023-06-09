using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class MeleeWeapons:Weapon
    {
        public int AttackPower { get; private set; }
        public float DistanceOfAttack { get; private set; }

    }
}
