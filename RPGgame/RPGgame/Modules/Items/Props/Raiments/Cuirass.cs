
using RPGgame.Modules.Items.Effects;

namespace RPGgame.Modules.Items.Props
{
    internal class Cuirass:Clothes
    {
        public Cuirass() : base("Resources\\EntitySprites\\Cuirass.png", new Effect()) { }

        public override TypeArmor GetTypeArmor()
        {
            return TypeArmor.Body;
        }
    }
}

