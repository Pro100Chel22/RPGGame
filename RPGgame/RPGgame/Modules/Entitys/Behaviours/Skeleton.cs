
using RPGgame.Modules.Items.Props;
using RPGgame.Modules.Storages;
using RPGgame.Modules.UI.Dialogs;
using SFML.System;
using System;

namespace RPGgame.Modules.Entitys.Behaviours
{
    internal class Skeleton : Behaviour
    {
        public Skeleton() : base(true) { }

        private float timer = 0;

        private bool CheckEntity(Entity entity, Entity cur, float dTime)
        {
            Vector2f delta = cur.Position - entity.Position;
            double len = Math.Sqrt(Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2));
            if (30 < len && len < 200)
            {
                entity.Move(dTime, new Vector2f((delta.X > 0) ? 1 : -1, 0));
                return true;
            }
            else if (len <= 25)
            {
                entity.Move(0, new Vector2f((delta.X > 0) ? 1 : -1, 0));
                entity.Attack();
                return true;
            }

            return false;
        }
        public override void Control(float dTime, Entity entity)
        {
            if(!entity.World.Player.GetIsDead() && CheckEntity(entity, entity.World.Player, dTime))
            {
                return;
            }

            for (int i = 0; i < entity.World.Mobs.Count; i++)
            {
                if (!entity.World.Mobs[i].GetIsDead() && !entity.World.Mobs[i].GetBehaviour().isEvil && CheckEntity(entity, entity.World.Mobs[i], dTime))
                {
                    return;
                }
            }

            timer += dTime;
            if (timer >= 14)
            {
                timer = 0;
            }
            else if (6 < timer && timer < 7)
            {
                entity.Move(dTime, new Vector2f(-1, 0));
            }
            else if (2 < timer && timer < 3)
            {
                entity.Move(dTime, new Vector2f(1, 0));
            }
        }
        public override Characteristics GetCharacteristics()
        {
            LoadModel loadModel = new LoadModel("Resources\\EntitySprites\\Skeleton.png");

            Storage inventory = new Storage(true);

            MainEquipments equipments = new MainEquipments();
            equipments.SwapWeapon(new Sword());

            return new Characteristics
            {
                inventory = inventory,
                equipments = equipments,
                money = 0,
                maxHealth = 50,
                speed = 150,
                maxEndurance = 100,
                textur = loadModel.textur,
                hitbox = loadModel.hitbox
            };
        }

        public override Dialog GetDialog()
        {
            throw new NotImplementedException();
        }
    }
}
