
using RPGgame.Modules.Items;
using RPGgame.Modules.Storages;
using RPGgame.Modules.UI;
using SFML.Graphics;
using SFML.System;
using System;

namespace RPGgame.Modules.Entitys
{
    internal class Entity : IInteractive, IAlive 
    {
        private Storage inventory;
        private MainEquipments equipments;
        private Behaviour behaviour;

        public Vector2f position { get; set; }
        public Vector2f direction { get; set; }
        private FloatRect hitbox;
        public Sprite textur { get; private set; }
        private TemporaryEffect[] effects;
        public IInteractive interaction { get; set; }

        private int money;
        private bool onGround;
        private bool isDead;
        private bool isOpenInventory;
        private bool isInteracting;
        private float speed;
        private int health;
        private int resistance;
        private int endurance;

        public void Draw(RenderWindow renderIn)
        {
            renderIn.Draw(textur);
        }
        public void DeleteInteraction()
        {
            interaction = null;
        }
        public void Move(Vector2f dVector)
        {
            throw new Exception("Move не реализована");
        }
        public void Update(float dTime)
        {
            throw new Exception("Update не реализована");
            return;
        }
        public void Attack()
        {
            throw new Exception("Attack не реализована");
            return;
        }

        public MainEquipments GetMainEquipments()
        {
            return equipments;
        }
        public Behaviour GetBehaviour()
        {
            return behaviour;
        }
        public Storage GetInventory()
        {
            return inventory;
        }
        public int GetMoney()
        {
            return money;
        }
        public void SetMoney(int value)
        {
            money = value;
        }

        public void Murder()
        {
            isDead = true;
            health = 0;
        }
        public bool GetIsDead()
        {
            return isDead;
        }
        public void DealDamage(uint value)
        {
            health -= (int)((1.0f - (float)resistance / 100.0f) * value);

            if(health <= 0)
            {
                isDead = true;
                health = 0;
            }
        }
        public void AddHealth(uint value)
        {
            health += (int)value;

            throw new Exception("AddHealth не реализована проверка на максимальное значение здоровья данной сущности");
            return;
        }
        public int GetHealth()
        {
            return health;
        }
        public FloatRect GetHitbox()
        {
            return hitbox;
        }
        public void ReduceEndurance(uint value)
        {
            endurance -= (int)value;

            if(endurance < 0)
            {
                endurance = 0;
            }
        }
        public void AddEndurance(uint value)
        {
            endurance += (int)value;

            throw new Exception("AddEndurance не реализована проверка на максимальное значение здоровья данной сущности");
            return;
        }
        public int GetEndurance()
        {
            return endurance;
        }
        public void ReduceResistance(uint value)
        {
            if(resistance - value < 0)
            {
                throw new Exception("ReduceResistance неправильные данные, не использовалось контрольное значение");
            }
            resistance -= (int)value;
        }
        public uint AddResistance(uint value)
        {
            if(resistance + value > 50)
            {
                int lastResistance = resistance;
                resistance = 50;
                return (uint)(50 - lastResistance);
            }
            else
            {
                resistance += (int)value;
                return value;
            }
        }
        public int GetResistance()
        {
            return resistance; 
        }
        public void AddEffect(TemporaryEffect effect)
        {
            Array.Resize(ref effects, effects.Length + 1);
            effects[effects.Length - 1] = effect;
 
            throw new Exception("AddEffect не реализована проверка на одинаковые эффекты с разным временем");
            return;
        }
    }
}
