
using RPGgame.Modules.Entitys;
using System;

namespace RPGgame.Modules.Items.Effects
{
    internal class Effect
    {
        public string Type { get; set; }
        public uint EffectValue { get; set; }
        public virtual void Employ(IAlive Alive)
        {
            throw new Exception("Employ недоступен, так как функция не реализована");
        }
        public virtual void Delete(IAlive Alive) { }
    }
}
