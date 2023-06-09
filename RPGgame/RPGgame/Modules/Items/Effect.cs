
using RPGgame.Modules.Entitys;
using System;

namespace RPGgame.Modules.Items
{
    internal class Effect
    {
        public string type { get; private set; }
        public uint effectValue { get; private set; }
        public uint controlValue{ get; private set; }
        public virtual void Employ(IAlive Alive)
        {
            throw new Exception("Employ недоступен, так как функция не реализована");

        }  
        public virtual void Delete(IAlive Alive)
        {
            throw new Exception("Delete недоступен, так как функция не реализована");

        }

    }

    internal class MomentaryEffect : Effect
    {
    }
    internal class TreatmentM : MomentaryEffect
    {
        public override void Employ(IAlive Alive)
        {
            throw new Exception("Employ недоступен, так как функция не реализована");

        }
        public override void Delete(IAlive Alive)
        {
            throw new Exception("Delete недоступен, так как функция не реализована");

        }
    }
    internal class Damage : MomentaryEffect
    {
    }   
    internal class ResistanceM : MomentaryEffect
    {
        public bool WasEmploy { get; private set; }

        public override void Employ(IAlive alive)
        {
            throw new Exception("Employ недоступен, так как функция не реализована");

        }
        public override void Delete(IAlive Alive)
        {
            throw new Exception("Delete недоступен, так как функция не реализована");

        }

    }


    internal class TemporaryEffect: Effect
    {
        public float TimeEffect { get; private set; }
        public bool Compare(TemporaryEffect temporaryEffect)
        {
            return TimeEffect >temporaryEffect.TimeEffect;
        }

        // Для функции AddResistance использовать контрольное значение,
        // при удалении эффекта передавать в ReduceEndurance КОНТРОЛЬНОЕ ЗНАЧЕНИЕ  
    }
}
