
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
        public World world { get; private set; }
        private Storage inventory;
        private MainEquipments equipments;
        private Behaviour behaviour;

        public Vector2f position { get; set; }
        public Vector2f direction { get; set; }
        private FloatRect hitbox;
        private Vector2f hitboxOffset; //
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

        public Entity(Behaviour behaviour, World world, Vector2f pos, Vector2f dir)
        {
            Characteristics ch = behaviour.GetCharacteristics();

            this.world = world;
            inventory = ch.inventory;
            equipments = behaviour.GetSetOfEquipment();
            this.behaviour = behaviour;

            position = pos; position = new Vector2f(100, 260);
            direction = dir;
            hitbox = ch.hitbox;
            textur = ch.textur;
            effects = new TemporaryEffect[0];
            interaction = null;

            money = ch.money;
            onGround = false;
            isDead = false;
            isOpenInventory = false;
            isInteracting = false;
            speed = ch.speed;
            health = ch.maxHealth;
            resistance = 0;
            endurance = ch.maxEndurance;

            hitboxOffset = new Vector2f(-textur.Origin.X * textur.Scale.X, -textur.Origin.Y * textur.Scale.Y);
            hitbox.Top = hitboxOffset.Y + position.Y;
            hitbox.Left = hitboxOffset.X + position.X;
        }
        public void Draw(RenderWindow renderIn)
        {
            renderIn.Draw(textur);

            CircleShape shape = new CircleShape(5);
            shape.Position = position;
            renderIn.Draw(shape);

            CircleShape shape2 = new CircleShape(2);
            shape2.Origin = new Vector2f(shape2.Radius / 2, shape2.Radius / 2);
            shape2.FillColor = Color.Blue;
            shape2.Position = new Vector2f(hitbox.Left, hitbox.Top);
            renderIn.Draw(shape2);

            CircleShape shape3 = new CircleShape(2);
            shape3.Origin = new Vector2f(shape3.Radius/2, shape3.Radius / 2);
            shape3.FillColor = Color.Blue;
            shape3.Position = new Vector2f(hitbox.Left + hitbox.Width, hitbox.Top + hitbox.Height);
            renderIn.Draw(shape3);

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

            //if (world.scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonD))
            //{
            //    position += new Vector2f(1 * speed * dTime, 0);
            //}
            //if (world.scene.events.getButtonOfKeyboard(KeyboardEvent.ButtonA))
            //{
            //    position += new Vector2f(-1 * speed * dTime, 0);
            //}

            
            if(!onGround)
            {
                position += new Vector2f(0.0f, 100.0f * dTime);
                if (world.CheckIntersection(hitbox))
                {
                    onGround = true;
                }
            }

            hitbox.Top = hitboxOffset.Y + position.Y;
            hitbox.Left = hitboxOffset.X + position.X;
            textur.Position = position;
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

            if (health <= 0)
            {
                isDead = true;
                health = 0;
            }
        }
        public void AddHealth(uint value)
        {
            health += (int)value;

            if (health > behaviour.GetCharacteristics().maxHealth)
            {
                health = behaviour.GetCharacteristics().maxHealth;
            }
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

            if (endurance < 0)
            {
                endurance = 0;
            }
        }
        public void AddEndurance(uint value)
        {
            endurance += (int)value;

            if (endurance > behaviour.GetCharacteristics().maxEndurance)
            {
                endurance = behaviour.GetCharacteristics().maxEndurance;
            }
        }
        public int GetEndurance()
        {
            return endurance;
        }
        public void ReduceResistance(uint value)
        {
            if (resistance - value < 0)
            {
                throw new Exception("ReduceResistance неправильные данные, не использовалось контрольное значение");
            }
            resistance -= (int)value;
        }
        public uint AddResistance(uint value)
        {
            if (resistance + value > 50)
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
