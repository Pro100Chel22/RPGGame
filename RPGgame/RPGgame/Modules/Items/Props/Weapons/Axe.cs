﻿using RPGgame.Modules.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class Axe : MeleeWeapons
    {
        public Axe() : base("Resources\\EntitySprites\\Axe.png", new Effect()) { }

        public override void Attack(Entity entity)
        {
            
        }
    }
}
