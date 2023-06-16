
using RPGgame.Modules.Items.Effects;

namespace RPGgame.Modules.Items.Props
{
    internal class MagicBall : DynamicAmmunition
    {
        public MagicBall() : base("Resources\\EntitySprites\\MagicBall.png", new Effect()) { }

        public override void Update(float dt)
        {
            return;
        }
    }
}
