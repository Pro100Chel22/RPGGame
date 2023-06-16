
using RPGgame.Modules.Items.Effects;

namespace RPGgame.Modules.Items.Props
{
    internal class Helmet : Clothes
    {
        public Helmet() : base("Resources\\EntitySprites\\Helmet.png", new Effect()) { }

        public override TypeArmor GetTypeArmor()
        {
            return TypeArmor.Head;
        }
    }
}
