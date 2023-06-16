using RPGgame.Modules.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class Weapon:Equipment
    {
        public Weapon(string path) : base(path) { } //= "Resources\\EntitySprites\\Sword.png"

        public bool ReadyToAttack { get; set; }
        public float TimeAttack { get; set; }
        public virtual void Attack(Entity entity)
        {
            if (ReadyToAttack)
            {
                entity.Attack();
            }
        }
        public override void UseInStorage(Entity entity)
        {
            throw new Exception("UseInStorage недоступен, так как функция не реализована");

        }
    }
}
