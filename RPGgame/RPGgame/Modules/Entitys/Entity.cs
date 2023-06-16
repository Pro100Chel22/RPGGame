
using RPGgame.Modules.Items;
using RPGgame.Modules.Storages;
using RPGgame.Modules.UI;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;

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
        private List<TemporaryEffect> effects;
        public IInteractive interaction { get; set; }

        private int money;
        private bool onGround;
        private bool isDead;
        private float speed;
        private int health;
        private int resistance;
        private int endurance;

        private Sprite weaponTextur;

        public Entity(Behaviour behaviour, World world, Vector2f pos, Vector2f dir)
        {
            Characteristics ch = behaviour.GetCharacteristics();

            this.world = world;
            inventory = ch.inventory;
            equipments = ch.equipments;
            this.behaviour = behaviour;

            position = pos;
            direction = dir;
            hitbox = ch.hitbox;
            textur = ch.textur;
            effects = new List<TemporaryEffect>();
            interaction = null;

            money = ch.money;
            onGround = false;
            isDead = false;
            speed = ch.speed;
            health = ch.maxHealth;
            resistance = 0;
            endurance = ch.maxEndurance;

            hitboxOffset = new Vector2f(-textur.Origin.X * textur.Scale.X, -textur.Origin.Y * textur.Scale.Y);
            hitbox.Top = hitboxOffset.Y + position.Y;
            hitbox.Left = hitboxOffset.X + position.X;

            weaponTextur = new Sprite();
            weaponTextur.Origin = new Vector2f(16, 16);

            textur.Scale = new Vector2f(((direction.X > 0) ? 1 : -1) * Math.Abs(textur.Scale.X), textur.Scale.Y);
            weaponTextur.Scale = new Vector2f(((direction.X > 0) ? -1 : 1) * Math.Abs(weaponTextur.Scale.X), weaponTextur.Scale.Y);
            direction = new Vector2f((direction.X > 0) ? 1.0f : -1.0f, 0.0f);
        }
        public void Draw(RenderWindow renderIn)
        {
            renderIn.Draw(textur);

            if(equipments.GetWeapon() != null)
            {
                weaponTextur.Texture = equipments.GetWeapon().Textur.Texture;
                weaponTextur.Position = position;
                renderIn.Draw(weaponTextur);
            }
        }
        public void DeleteInteraction()
        {
            interaction = null;
        }
        public void Move(float dTime, Vector2f dVector)
        { 
            textur.Scale = new Vector2f(((dVector.X > 0) ? 1 : -1) * Math.Abs(textur.Scale.X), textur.Scale.Y);
            weaponTextur.Scale = new Vector2f(((dVector.X > 0) ? -1 : 1) * Math.Abs(weaponTextur.Scale.X), weaponTextur.Scale.Y);
            direction = new Vector2f((dVector.X > 0) ? 1.0f : -1.0f, 0.0f);

            position += dVector * speed * dTime;
            hitbox.Top = hitboxOffset.Y + position.Y;
            hitbox.Left = hitboxOffset.X + position.X;

            if (world.CheckIntersection(hitbox))
            {
                hitbox.Top = hitboxOffset.Y + position.Y - 12.0f;
                if (!world.CheckIntersection(hitbox))
                {
                    onGround = false;
                    hitbox.Top = hitboxOffset.Y + position.Y;
                }
                else
                {
                    position -= dVector * speed * dTime;
                    hitbox.Top = hitboxOffset.Y + position.Y;
                    hitbox.Left = hitboxOffset.X + position.X;
                }
            }
            else
            {
                hitbox.Top = hitboxOffset.Y + position.Y + 1.0f;
                if (!world.CheckIntersection(hitbox))
                {
                    onGround = false;
                }
                hitbox.Top = hitboxOffset.Y + position.Y;
            }
        }
        public void Update(float dTime)
        {
            if(!isDead)
            {
                behaviour.Control(dTime, this);

                if (!onGround)
                {
                    position += new Vector2f(0.0f, 200.0f * dTime);
                    if (world.CheckIntersection(hitbox))
                    {
                        onGround = true;
                        while (world.CheckIntersection(hitbox))
                        {
                            Console.WriteLine(position);
                            position -= new Vector2f(0.0f, 0.1f);
                            hitbox.Top = hitboxOffset.Y + position.Y;
                            hitbox.Left = hitboxOffset.X + position.X;
                        }
                    }
                }

                hitbox.Top = hitboxOffset.Y + position.Y;
                hitbox.Left = hitboxOffset.X + position.X;
                textur.Position = position;

                for (int i = 0; i < effects.Count; i++)
                {
                    effects[i].Employ(this);
                    effects[i].TimeEffect -= dTime;

                    if (effects[i].TimeEffect <= 0)
                    {
                        effects[i].Delete(this);
                        effects.RemoveAt(i);
                        i -= 1;
                    }
                }
            }            
        }
        public void Attack()
        {
            equipments.GetWeapon()?.Attack(this);
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
        public bool IsAlive()
        {
            return true;
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
            DealDamage(100000000);
        }
        public bool GetIsDead()
        {
            return isDead;
        }
        public void DealDamage(uint value)
        {
            health -= (int)((1.0f - (float)resistance / 100.0f) * value);
            Console.WriteLine((int)((1.0f - (float)resistance / 100.0f) * value));
            if (health <= 0)
            {
                isDead = true;
                health = 0;
                textur.Rotation = 90.0f;
                textur.Scale = new Vector2f(-Math.Abs(textur.Scale.X), textur.Scale.Y);
                textur.Origin = new Vector2f(55, 20);
                GetInventory().PutItem(GetMainEquipments().PopWeapon());
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
            int simEff = -1;
            for(int i = 0; i < effects.Count; i++)
            {
                if(TemporaryEffect.Compare(effect, effects[i]))
                {
                    simEff = i;
                    break;
                }
            }

            if(simEff != -1)
            {
                if(effects[simEff].TimeEffect < effect.TimeEffect)
                {
                    effects[simEff].Delete(this);
                    effects.RemoveAt(simEff);
                    effects.Add(effect);
                }
            }
            else
            {
                effects.Add(effect);
            }
        }
    }
}
