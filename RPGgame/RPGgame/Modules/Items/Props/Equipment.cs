using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class Equipment : Item
    {
        public Equipment(string path, Effect effect) : base(path) 
        { 
            Effect = effect;
        }

        public Effect Effect { get; set; }
    }
}
