
using RPGgame.Modules.Storages;
using RPGgame.Modules.UI.Dialogs;
using SFML.Graphics;
using SFML.System;
using System;

namespace RPGgame.Modules.Entitys.Behaviours
{
    internal class Player : Behaviour
    {
        public Player() : base(false)
        {

        }

        public override void Control(float dTime, Entity entity)
        {
            if (entity.world.scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonD))
            {
                entity.Move(dTime, new Vector2f(1, 0));
            }
            if (entity.world.scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonA))
            {
                entity.Move(dTime, new Vector2f(-1, 0));
                //position += new Vector2f(-1 * speed * dTime, 0);
            }
        }
        public override Characteristics GetCharacteristics()
        {
            float scale = 0.7f;
            Texture tx = new Texture("Resources\\EntitySprites\\player.png");
            Sprite textur = new Sprite(tx)
            {
                Scale = new Vector2f(scale, scale),
                Origin = new Vector2f(tx.Size.X / 2, tx.Size.Y / 2),
            };

            return new Characteristics
            {
                inventory = new Storage(true),
                money = 100,
                maxHealth = 100,
                speed = 100,
                maxEndurance = 100,
                textur = textur,
                hitbox = new FloatRect(
                    textur.TextureRect.Left * scale, textur.TextureRect.Top * scale, 
                    textur.TextureRect.Width * scale, textur.TextureRect.Height * scale
                ),
            };
        }
        public override MainEquipments GetSetOfEquipment()
        {
            return new MainEquipments();
        }
        public override Dialog GetDialog()
        {
            throw new NotImplementedException();
        }
    }
}