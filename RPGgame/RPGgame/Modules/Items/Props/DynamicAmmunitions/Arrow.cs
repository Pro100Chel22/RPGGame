
using RPGgame.Modules.Items.Effects;

namespace RPGgame.Modules.Items.Props
{
    internal class Arrow:DynamicAmmunition
    {
        public Arrow() : base("Resources\\EntitySprites\\Arrow.png", new Effect()) { }

        public override void Update(float dt)
        {
            return;
        }
    }
}
