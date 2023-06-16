
using RPGgame.Modules.Items.Effects;

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
