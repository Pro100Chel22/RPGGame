
using RPGgame.Modules.Items;
using RPGgame.Modules.Items.Props;
using RPGgame.Modules.Storages;
using RPGgame.Modules.UI.Dialogs;
using SFML.System;
using System;

namespace RPGgame.Modules.Entitys.Behaviours
{
    internal class Blacksmith : Behaviour
    {
        public Blacksmith() : base(false) { }

        public override void Control(float dTime, Entity entity)
        {

        }
        public override Characteristics GetCharacteristics()
        {
            LoadModel loadModel = new LoadModel("Resources\\EntitySprites\\Blacksmith.png");

            Storage inventory = new Storage(true);
            inventory.PutItem(Item.CreateNew(TypeItemToCreate.Key));
            inventory.PutItem(Item.CreateNew(TypeItemToCreate.Arrow));
            inventory.PutItem(Item.CreateNew(TypeItemToCreate.Sword));
            inventory.PutItem(Item.CreateNew(TypeItemToCreate.Crossbow));
            inventory.PutItem(Item.CreateNew(TypeItemToCreate.Axe));
            inventory.PutItem(Item.CreateNew(TypeItemToCreate.Note));

            MainEquipments equipments = new MainEquipments();

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
