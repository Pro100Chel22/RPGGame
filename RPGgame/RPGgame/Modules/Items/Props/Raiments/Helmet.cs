
using RPGgame.Modules.Items.Effects;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class Helmet : Clothes
    {
        public Helmet() : base("Resources\\EntitySprites\\Helmet.png", new List<Effect>()) 
        {
            Effects.Add(
                new ResistanceM()
                {
                    EffectValue = 15,
                }
            );
        }

        public override TypeArmor GetTypeArmor()
        {
            return TypeArmor.Head;
        }
    }
}
