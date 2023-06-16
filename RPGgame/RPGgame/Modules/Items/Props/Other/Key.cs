using RPGgame.Modules.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class Key: Trash
    {
        public Key() : base("Resources\\EntitySprites\\Key.png") {  }

        public int KeyId { get; private set; }
    }
}
