
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using SFML.System;
using System;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class MeleeWeapons : Weapon
    {
        public MeleeWeapons(string path, List<Effect> effect) : base(path, effect) { }

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

            Vector2f delta = entity.World.Player.Position - entity.Position;
            if (Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2) < DistanceOfAttack * DistanceOfAttack
               && entity != entity.World.Player && delta.X * entity.Direction.X > 0)
            {
                for (int j = 0; j < Effects.Count; j++)
                {
                    Effects[j].Employ(entity.World.Player);
                }
            }

            for (int i = 0; i < entity.World.Mobs.Count; i++)
            {
                if(entity.World.Mobs[i].GetIsDead() || Behaviour.Compare(entity.World.Mobs[i].GetBehaviour(), entity.GetBehaviour()))
                {
                    continue;
                }

                delta = entity.World.Mobs[i].Position - entity.Position;
                if (Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2) < DistanceOfAttack * DistanceOfAttack
                && entity != entity.World.Mobs[i] && delta.X * entity.Direction.X > 0)
                {
                    for(int j = 0; j < Effects.Count; j++)
                    {
                        Effects[j].Employ(entity.World.Mobs[i]);
                    }
                }
            }
        }
    }
}
