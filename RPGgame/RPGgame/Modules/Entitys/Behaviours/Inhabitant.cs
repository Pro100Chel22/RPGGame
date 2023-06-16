
using RPGgame.Modules.Items.Props;
using RPGgame.Modules.Storages;
using RPGgame.Modules.UI.Dialogs;
using SFML.System;
using System;

namespace RPGgame.Modules.Entitys.Behaviours
{
    internal class Inhabitant : Behaviour
    {
        public Inhabitant() : base(false) { }

        private float timer = 0;

        public override void Control(float dTime, Entity entity)
        {
            timer += dTime;
            if (timer >= 14)
            {
                timer = 0;
            }
            else if(7 < timer && timer < 8)
            {
                entity.Move(dTime, new Vector2f(-1, 0));
            }
            else if(3 < timer && timer < 4)
            {
                entity.Move(dTime, new Vector2f(1, 0));
            }
        }
        public override Characteristics GetCharacteristics()
        {
            LoadModel loadModel = new LoadModel("Resources\\EntitySprites\\Inhabitant.png");

            Storage inventory = new Storage(true);

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
