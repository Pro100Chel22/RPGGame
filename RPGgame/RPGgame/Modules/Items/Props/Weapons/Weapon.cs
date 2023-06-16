
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using SFML.System;
using System;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal abstract class Weapon : Equipment
    {
        public Weapon(string path, List<Effect> effect) : base(path, effect)
        {
            Time = new Clock();
        }

        public Clock Time { get; set; }
        public bool ReadyToAttack { get; set; }
        public float TimeAttack { get; set; }
        public abstract void Attack(Entity entity);
        public override void UseInStorage(Entity entity)
        {
            throw new Exception("UseInStorage недоступен, так как функция не реализована");
        }
    }
}
