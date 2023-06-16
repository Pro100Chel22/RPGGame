using RPGgame.Modules.Items.Props;
using RPGgame.Modules.Storages;
using RPGgame.Modules.UI.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Entitys.Behaviours
{
    internal class Skeleton : Behaviour
    {
        public Skeleton() : base(false) { }

        public override void Control(float dTime, Entity entity)
        {

        }
        public override Characteristics GetCharacteristics()
        {
            LoadModel loadModel = new LoadModel("Resources\\EntitySprites\\Skeleton.png");

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
