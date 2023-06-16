
using RPGgame.Modules.Items.Effects;
using System.Collections.Generic;

namespace RPGgame.Modules.Items.Props
{
    internal class Boots: Clothes
    {
        public Boots() : base("Resources\\EntitySprites\\Boots.png", new List<Effect>()) 
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
            return TypeArmor.Foots;
        }
    }
}
