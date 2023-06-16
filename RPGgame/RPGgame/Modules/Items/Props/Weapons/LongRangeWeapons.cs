using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class LongRangeWeapons:Weapon
    {
        public LongRangeWeapons(string path) : base(path) { }

        public float InistalSpeed { get; private set; }
    }
}
