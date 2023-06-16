
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using SFML.System;
using System;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class MeleeWeapons : Weapon
    {
        public MeleeWeapons(string path, List<Effect> effect) : base(path, effect) 
        { 
            
        }

        public int AttackPower { get; set; }
        public float DistanceOfAttack { get; set; }

        public override void Attack(Entity entity)
        {  
            if (entity.GetEndurance() - AttackPower < 0 ||
                Time.ElapsedTime.AsSeconds() < TimeAttack)
            {
                return;
            }
            
            Time.Restart();
            entity.ReduceEndurance((uint)AttackPower);

            Vector2f delta = entity.world.player.position - entity.position;
            if (Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2) < DistanceOfAttack
               && entity != entity.world.player && delta.X * entity.direction.X > 0)
            {
                for (int j = 0; j < Effects.Count; j++)
                {
                    Effects[j].Employ(entity.world.player);
                }
            }

            for (int i = 0; i < entity.world.mobs.Count; i++)
            {
                if(entity.world.mobs[i].GetIsDead())
                {
                    continue;
                }

                delta = entity.world.mobs[i].position - entity.position;
                if (Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2) < DistanceOfAttack * DistanceOfAttack
                && entity != entity.world.mobs[i] && delta.X * entity.direction.X > 0)
                {
                    for(int j = 0; j < Effects.Count; j++)
                    {
                        Effects[j].Employ(entity.world.mobs[i]);
                    }
                }
            }
        }
    }
}
