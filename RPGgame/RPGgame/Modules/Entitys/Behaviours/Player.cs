
using RPGgame.Modules.Items.Effects;
using RPGgame.Modules.Items.Props;
using RPGgame.Modules.Items.Props.Weapons;
using RPGgame.Modules.Storages;
using RPGgame.Modules.UI.Dialogs;
using SFML.System;
using System;

namespace RPGgame.Modules.Entitys.Behaviours
{
    internal class Player : Behaviour
    {
        public Player() : base(false) { }

        public override void Control(float dTime, Entity entity)
        {
            if (entity.World.Scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonD))
            {
                entity.Move(dTime, new Vector2f(1, 0));
            }
            if (entity.World.Scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonA))
            {
                entity.Move(dTime, new Vector2f(-1, 0));
            }
            if (entity.World.Scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonE))
            {
                for (int i = 0; i < entity.World.Chests.Count; i++)
                {
                    Vector2f delta = entity.World.Chests[i].Position - entity.Position;
                    if (Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2) < 400)
                    {
                        entity.Interaction = entity.World.Chests[i];
                        entity.World.Scene.SetConfig(Config.DrawInventWin);
                        return;
                    }
                }

                for (int i = 0; i < entity.World.Mobs.Count; i++)
                {
                    Vector2f delta = entity.World.Mobs[i].Position - entity.Position;
                    if ((entity.World.Mobs[i].GetIsDead() || !entity.World.Mobs[i].GetBehaviour().isEvil) && Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2) < 400)
                    {
                        entity.Interaction = entity.World.Mobs[i];
                        entity.World.Scene.SetConfig(Config.DrawInventWin);
                        return;
                    }
                }

                entity.World.Scene.SetConfig(Config.DrawInventWin);
            }
            if (entity.World.Scene.events.getButtonOfMouse(MouseEvent.ButtonLeft))
            {
                entity.Attack();
            }
        }
        public override Characteristics GetCharacteristics()
        {
            LoadModel loadModel = new LoadModel("Resources\\EntitySprites\\player.png");

            Storage inventory = new Storage(true);
            inventory.PutItem(new Axe());
            inventory.PutItem(new EndurancePotion());
            inventory.PutItem(new TreatmentPotion());
            inventory.PutItem(new Sword());
            inventory.PutItem(new MagicRing());
            inventory.PutItem(new FireRing());
            inventory.PutItem(new Sword());

            MainEquipments equipments = new MainEquipments();
            equipments.SwapWeapon(new Crossbow());
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