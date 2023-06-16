
using RPGgame.Modules.Items.Effects;

namespace RPGgame.Modules.Items.Props
{
    internal class FireBall : DynamicAmmunition
    {
        public FireBall() : base("Resources\\EntitySprites\\FireBall.png", new Effect()) { }

        public override void Update(float dt)
        {
            return;
        }
    }
}
