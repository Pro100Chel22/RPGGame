
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using System;

namespace RPGgame.Modules.Items.Props
{
    internal class TreatmentPotion : Food
    {
        public TreatmentPotion() : base("Resources\\EntitySprites\\TreatmentPotion.png", new Effect()) { }
        
        public override void UseInStorage(Entity entity)
        {
            throw new Exception("useInStorage недоступен, так как функция не реализована");

        }
    }
}
