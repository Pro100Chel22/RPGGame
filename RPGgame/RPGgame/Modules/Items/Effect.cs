
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

        public override void Employ(IAlive Alive)
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
        public float TimeEffect { get; set; }
        public static bool Compare(TemporaryEffect temporaryEffect1, TemporaryEffect temporaryEffect2)
        {
            return temporaryEffect1.GetType() == temporaryEffect2.GetType();
        }

        // Для функции AddResistance использовать контрольное значение,
        // при удалении эффекта передавать в ReduceEndurance КОНТРОЛЬНОЕ ЗНАЧЕНИЕ  
    }
}
