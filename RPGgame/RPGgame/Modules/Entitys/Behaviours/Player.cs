﻿
using RPGgame.Modules.Items.Props;
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
            if (entity.world.scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonD))
            {
                entity.Move(dTime, new Vector2f(1, 0));
            }
            if (entity.world.scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonA))
            {
                entity.Move(dTime, new Vector2f(-1, 0));
            }
            if (entity.world.scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonE))
            {
                entity.world.scene.SetConfig(Config.DrawInventWin);
            }
            if (entity.world.scene.events.getButtonOfMouse(MouseEvent.ButtonLeft))
            {
                entity.Attack();
            }
        }
        public override Characteristics GetCharacteristics()
        {
            LoadModel loadModel = new LoadModel("Resources\\EntitySprites\\player.png");

            Storage inventory = new Storage(true);
            inventory.PutItem(new Arrow());

            MainEquipments equipments = new MainEquipments();
            equipments.SwapWeapon(new Sword());
            equipments.SwapArmor(new Cuirass());

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