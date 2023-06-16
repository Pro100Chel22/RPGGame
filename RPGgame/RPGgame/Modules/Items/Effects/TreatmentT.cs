
using RPGgame.Modules.Entitys;

namespace RPGgame.Modules.Items.Effects
{
    internal class TreatmentT : TemporaryEffect
    {
        public TreatmentT()
        {
            EffectValue = 5;
            TimeEffect = 5;
        }

        public override void Employ(IAlive Alive)
        {
            Alive.AddHealth(EffectValue);
        }
    }
}
