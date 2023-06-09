
using RPGgame.Modules.Entitys.Behaviours;
using RPGgame.Modules.Storages;
using RPGgame.Modules.UI.Dialogs;
using SFML.Graphics;

namespace RPGgame.Modules.Entitys
{
    internal struct Characteristics
    {
        public Storage inventory;
        public int money;
        public int maxHealth;
        public float speed;
        public int maxEndurance;
        public Sprite textur;
        public FloatRect hitbox;
    }

    abstract class Behaviour
    {
        public bool isEvil { get; private set; }

        public Behaviour(bool isEvil) 
        {
            this.isEvil = isEvil;   
        }

        public static Behaviour CreatNew(int type)
        {
            switch (type)
            {
                case 0: return new Player();
            }

            return null;
        }
        public static bool Compare(Behaviour behaviour1, Behaviour behaviour2)
        {
            return false;
        }
        public abstract void Control(float dTime, Entity entity); 
        public abstract Characteristics GetCharacteristics();
        public abstract MainEquipments GetSetOfEquipment();
        public abstract Dialog GetDialog();
    }
}
