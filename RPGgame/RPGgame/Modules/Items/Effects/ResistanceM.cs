using RPGgame.Modules.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Effects
{

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
}
