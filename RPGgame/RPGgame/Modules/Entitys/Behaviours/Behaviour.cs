
using RPGgame.Modules.Entitys.Behaviours;
using RPGgame.Modules.Storages;
using RPGgame.Modules.UI.Dialogs;
using SFML.Graphics;

namespace RPGgame.Modules.Entitys
{
    internal struct Characteristics
    {
        public Storage inventory;
        public MainEquipments equipments;
        public int money;
        public int maxHealth;
        public float speed;
        public int maxEndurance;
        public Sprite textur;
        public FloatRect hitbox;
    }

    internal enum TypeBehaviourToCreat
    {
        Player = 0,
        Trader = 1,
        Inhabitant = 2,
        Blacksmith = 3,
        Mage = 4,
        Guardsman = 5,
        Archer = 6,
        Skeleton = 7,
        Orge = 8
    }

    abstract class Behaviour
    {
        public bool isEvil { get; private set; }

        public Behaviour(bool isEvil) 
        {
            this.isEvil = isEvil;   
        }

        public static Behaviour CreatNew(TypeBehaviourToCreat type)
        {
            switch (type)
            {
                case TypeBehaviourToCreat.Player: return new Player();
                case TypeBehaviourToCreat.Trader: return new Trader();
                case TypeBehaviourToCreat.Inhabitant: return new Inhabitant();
                case TypeBehaviourToCreat.Blacksmith: return new Blacksmith();
                case TypeBehaviourToCreat.Mage: return new Mage();
                case TypeBehaviourToCreat.Guardsman: return new Guardsman();
                case TypeBehaviourToCreat.Archer: return new Archer();
                case TypeBehaviourToCreat.Skeleton: return new Skeleton();
                case TypeBehaviourToCreat.Orge: return new Ogre();
            }

            return null;
        }
        public static bool Compare(Behaviour behaviour1, Behaviour behaviour2)
        {
            return behaviour1.GetType() == behaviour2.GetType();
        }
        public abstract void Control(float dTime, Entity entity); 
        public abstract Characteristics GetCharacteristics();
        public abstract Dialog GetDialog();
    }
}
