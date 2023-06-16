
using RPGgame.Modules.Items.Effects;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class Equipment : Item
    {
        public Equipment(string path, List<Effect> effect) : base(path) 
        { 
            Effects = effect;
        }

        public List<Effect> Effects { get; set; }
    }
}
