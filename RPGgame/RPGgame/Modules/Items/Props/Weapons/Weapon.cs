using RPGgame.Modules.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal abstract class Weapon:Equipment
    {
        public Weapon(string path, Effect effect) : base(path, effect) { }

        public bool ReadyToAttack { get; set; }
        public float TimeAttack { get; set; }
        public abstract void Attack(Entity entity);
        public override void UseInStorage(Entity entity)
        {
            throw new Exception("UseInStorage недоступен, так как функция не реализована");
        }
    }
}
