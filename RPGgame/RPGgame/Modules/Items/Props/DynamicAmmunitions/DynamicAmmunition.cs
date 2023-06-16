using RPGgame.Modules.Entitys;
using RPGgame.Modules.UI;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Items.Props
{
    internal class DynamicAmmunition : Equipment
    {
        public float Speed { get; private set; }
        public bool HittingAnObject;
        public Vector2f Direction { get; private set; }   
        public FloatRect HitBox { get; private set; }

        public DynamicAmmunition(string path) : base (path) { }

        public void Move(Vector2f Vector2f)
        {
            //object.Move(Vector2f);
            //what?
        }
        public virtual void Update(float dt)
        {
            return;
        }
        public override void UseInStorage(Entity entity)
        {
            throw new Exception("UseInStorage недоступен, так как функция не реализована");

        }
        //right?

    }
}
