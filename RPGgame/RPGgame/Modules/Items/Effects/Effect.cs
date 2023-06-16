
using RPGgame.Modules.Entitys;
using System;

namespace RPGgame.Modules.Items.Effects
{
    internal class Effect
    {
        public string type { get; private set; }
        public uint effectValue { get; private set; }
        public uint controlValue { get; private set; }
        public virtual void Employ(IAlive Alive)
        {
            throw new Exception("Employ недоступен, так как функция не реализована");

        }
        public virtual void Delete(IAlive Alive)
        {
            throw new Exception("Delete недоступен, так как функция не реализована");

        }
    }
}
