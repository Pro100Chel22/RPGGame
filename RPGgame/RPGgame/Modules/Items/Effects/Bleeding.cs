
using RPGgame.Modules.Entitys;

namespace RPGgame.Modules.Items.Effects
{
    internal class Bleeding : TemporaryEffect
    {
        public Bleeding() 
        {
            EffectValue = 2;
            TimeEffect = 5;
        }

        public override void Employ(IAlive Alive)
        {
            Alive.DealDamage(EffectValue);
        }
    }
}
