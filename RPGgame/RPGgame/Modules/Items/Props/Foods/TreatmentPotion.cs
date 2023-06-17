
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Effects;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class TreatmentPotion : Food
    {
        public TreatmentPotion() : base("Resources\\EntitySprites\\TreatmentPotion.png", new List<Effect>()) { }
        
        public override bool UseInStorage(Entity entity)
        {
            new TreatmentM().Employ(entity);
            return true;
        }
    }
}
