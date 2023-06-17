
using RPGgame.Modules.Items.Effects;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class Cuirass : Clothes
    {
        public Cuirass() : base("Resources\\EntitySprites\\Cuirass.png", new List<Effect>())
        {
            Effects.Add(
                new ResistanceM() { EffectValue = 20 }
            );
        }

        public override TypeArmor GetTypeArmor()
        {
            return TypeArmor.Body;
        }
    }
}

