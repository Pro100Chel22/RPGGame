
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using SFML.System;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class Weapon : Equipment
    {
        public Clock Time { get; set; }
        public int AttackPower { get; set; }
        public bool ReadyToAttack { get; set; }
        public float TimeAttack { get; set; }
        public virtual void Attack(Entity entity) { }

        public Weapon(string path, List<Effect> effect) : base(path, effect)
        {
            Time = new Clock();
        }
    }
}
