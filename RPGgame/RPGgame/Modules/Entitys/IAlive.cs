using RPGgame.Modules.Items;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void ReduceResistance(uint value);
        uint AddResistance(uint value);
        int GetResistance();
        void AddEffect(TemporaryEffect effect);
    }
}
