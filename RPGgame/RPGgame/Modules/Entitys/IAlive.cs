
using RPGgame.Modules.Items.Effects;
using SFML.Graphics;

namespace RPGgame.Modules.Entitys
{
    internal interface IAlive
    {
        void Murder();
        bool GetIsDead();
        void DealDamage(uint value);
        void AddHealth(uint value);
        int GetHealth();
        FloatRect GetHitbox();
        void ReduceEndurance(uint value);
        void AddEndurance(uint value);
        int GetEndurance();
        int GetResistance();
        void AddEffect(TemporaryEffect effect);
    }
}
