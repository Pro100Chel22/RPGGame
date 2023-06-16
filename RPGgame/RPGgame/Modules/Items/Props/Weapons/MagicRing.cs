using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props.Weapons
{
    internal class MagicRing : LongRangeWeapons
    {
        public MagicRing() : base("Resources\\EntitySprites\\MagicRing.png", new List<Effect>())
        {
            InistalSpeed = 200;
            AttackPower = 10;
            TimeAttack = 1;
        }

        public override void Attack(Entity entity)
        {
            if (entity.GetEndurance() - AttackPower < 0 ||
                Time.ElapsedTime.AsSeconds() < TimeAttack)
            {
                return;
            }

            Time.Restart();
            entity.ReduceEndurance((uint)AttackPower);

            entity.world.AddDynamicAmmunition(new MagicBall() { Position = entity.position + new Vector2f(0, 15.0f), Direction = entity.direction, Owner = entity });
        }
    }
}
