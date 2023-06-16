
using RPGgame.Modules.Items.Props;
using RPGgame.Modules.Storages;
using RPGgame.Modules.UI.Dialogs;
using SFML.System;
using System;

namespace RPGgame.Modules.Entitys.Behaviours
{
    internal class Guardsman : Behaviour
    {
        public Guardsman() : base(false) { }

        private bool CheckEntity(Entity entity, Entity cur, float dTime)
        {
            Vector2f delta = cur.position - entity.position;
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
            if (entity.world.player.GetBehaviour().isEvil && CheckEntity(entity, entity.world.player, dTime))
            {
                return;
            }

            for (int i = 0; i < entity.world.mobs.Count; i++)
            {
                if (!entity.world.mobs[i].GetIsDead() && entity.world.mobs[i].GetBehaviour().isEvil && CheckEntity(entity, entity.world.mobs[i], dTime))
                {
                    return;
                }
            }
        }
        public override Characteristics GetCharacteristics()
        {
            LoadModel loadModel = new LoadModel("Resources\\EntitySprites\\Guardsman.png");

            Storage inventory = new Storage(true);

            MainEquipments equipments = new MainEquipments();
            equipments.SwapWeapon(new Sword());
            equipments.SwapArmor(new Cuirass());
            equipments.SwapArmor(new Helmet());
            equipments.SwapArmor(new Boots());

            return new Characteristics
            {
                inventory = inventory,
                equipments = equipments,
                money = 100,
                maxHealth = 100,
                speed = 100,
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
