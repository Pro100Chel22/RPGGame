
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using RPGgame.Modules.UI;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class DynamicAmmunition : Equipment
    {
        public float Speed { get; set; }
        public bool HittingAnObject { get; set; }
        public Vector2f Direction { get; set; }
        public FloatRect HitBox { get; set; }
        public Entity Owner { get; set; }

        public DynamicAmmunition(string path, List<Effect> effect) : base(path, effect)
        {
            HittingAnObject = false;
        }

        public void Update(float dTime, World world)
        {
            if (HittingAnObject)
            {
                return;
            }

            Textur.Scale = new Vector2f(((Direction.X > 0) ? -1 : 1) * Math.Abs(Textur.Scale.X), Textur.Scale.Y);
            Position += Direction * dTime * Speed;
            Textur.Position = Position;

            FloatRect hitBox = new FloatRect(
                HitBox.Left + Position.X, HitBox.Top + Position.Y,
                HitBox.Width, HitBox.Height
            );

            if (world.CheckIntersection(hitBox))
            {
                HittingAnObject = true;
            }

            if (Owner != world.Player && !world.Player.GetIsDead() && CheckHit(world.Player, hitBox))
            {
                return;
            }

            for (int i = 0; i < world.Mobs.Count; i++)
            {
                if(Owner != world.Mobs[i] && !world.Mobs[i].GetIsDead() && CheckHit(world.Mobs[i], hitBox))
                {
                    break;
                }
            }
        }

        private bool CheckHit(Entity entity, FloatRect hitBox)
        {
            if (entity.GetHitbox().Intersects(hitBox))
            {
                HittingAnObject = true;

                for (int j = 0; j < Effects.Count; j++)
                {
                    if (Effects[j] is TemporaryEffect effect)
                    {
                        entity.AddEffect(effect);
                    }
                    else
                    {
                        Effects[j].Employ(entity);
                    }
                }
                return true;
            }

            return false;
        }
    }
}
