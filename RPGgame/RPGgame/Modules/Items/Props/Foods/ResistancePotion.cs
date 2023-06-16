
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using System;

namespace RPGgame.Modules.Items.Props
{
    internal class ResistancePotion : Food
    {
        public ResistancePotion() : base("Resources\\EntitySprites\\ResistancePotion.png", new Effect()) { }

        public override void UseInStorage(Entity entity)
        {
            throw new Exception("useInStorage недоступен, так как функция не реализована");

        }
    }
}
