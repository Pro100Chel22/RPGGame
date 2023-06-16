
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using SFML.System;
using System;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class LongRangeWeapons : Weapon
    {
        public LongRangeWeapons(string path, List<Effect> effect) : base(path, effect) { }

        public float InistalSpeed { get; set; }
    }
}
