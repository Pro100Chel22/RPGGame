
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using System;

namespace RPGgame.Modules.Items.Props
{
    internal class LongRangeWeapons : Weapon
    {
        public LongRangeWeapons(string path, Effect effect) : base(path, effect) { }

        public float InistalSpeed { get; private set; }

        public override void Attack(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
