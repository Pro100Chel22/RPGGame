
using RPGgame.Modules.Items.Effects;

namespace RPGgame.Modules.Items.Props
{
    internal class Boots: Clothes
    {
        public Boots() : base("Resources\\EntitySprites\\Boots.png", new Effect()) { }

        public override TypeArmor GetTypeArmor()
        {
            return TypeArmor.Foots;
        }
        //right?
    }
}
