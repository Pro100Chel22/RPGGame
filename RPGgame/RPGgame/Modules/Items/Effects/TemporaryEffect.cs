using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Effects
{

    internal class TemporaryEffect : Effect
    {
        public float TimeEffect { get; set; }
        public static bool Compare(TemporaryEffect temporaryEffect1, TemporaryEffect temporaryEffect2)
        {
            return temporaryEffect1.GetType() == temporaryEffect2.GetType();
        }
    }
}
