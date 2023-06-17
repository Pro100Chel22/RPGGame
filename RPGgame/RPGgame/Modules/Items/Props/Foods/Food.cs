
using RPGgame.Modules.Items.Effects;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class Food : Equipment
    {
        public Food(string path, List<Effect> effect) : base(path, effect) { }
    }
}
