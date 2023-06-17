
using RPGgame.Modules.Items.Effects;
using RPGgame.Modules.Items.Props;
using RPGgame.Modules.Items.Props.Weapons;
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
        public World World { get; private set; }
        private Storage inventory;
        private MainEquipments equipments;
        private Behaviour behaviour;

        public Vector2f Position { get; set; }
        public Vector2f Direction { get; set; }
        private FloatRect hitbox;
        private Vector2f hitboxOffset; //
        public Sprite Textur { get; private set; }
        private List<TemporaryEffect> effects;
        public IInteractive Interaction { get; set; }

        private int money;
        private bool onGround;
        private bool isDead;
        private float speed;
        private int health;
        private int endurance;

        private Sprite weaponTextur;
        private float timerEndurance;
        private float timerEffects;

        public Entity(Behaviour behaviour, World world, Vector2f pos, Vector2f dir)
        {
            Characteristics ch = behaviour.GetCharacteristics();

            this.World = world;
            inventory = ch.inventory;
            equipments = ch.equipments;
            this.behaviour = behaviour;

            Position = pos;
            Direction = dir;
            hitbox = ch.hitbox;
            Textur = ch.textur;
            effects = new List<TemporaryEffect>();
            Interaction = null;

            money = ch.money;
            onGround = false;
            isDead = false;
            speed = ch.speed;
            health = ch.maxHealth;
            endurance = ch.maxEndurance;

            hitboxOffset = new Vector2f(-Textur.Origin.X * Textur.Scale.X, -Textur.Origin.Y * Textur.Scale.Y);
            hitbox.Top = hitboxOffset.Y + Position.Y;
            hitbox.Left = hitboxOffset.X + Position.X;

            weaponTextur = new Sprite();
            weaponTextur.Origin = new Vector2f(16, 16);

            Textur.Scale = new Vector2f(((Direction.X > 0) ? 1 : -1) * Math.Abs(Textur.Scale.X), Textur.Scale.Y);
            weaponTextur.Scale = new Vector2f(((Direction.X > 0) ? -1 : 1) * Math.Abs(weaponTextur.Scale.X), weaponTextur.Scale.Y);
            Direction = new Vector2f((Direction.X > 0) ? 1.0f : -1.0f, 0.0f);

            timerEndurance = 0;
            timerEffects = 0;
        }
        public void Draw(RenderWindow renderIn)
        {
            renderIn.Draw(Textur);

            if (equipments.GetWeapon() != null && !(equipments.GetWeapon() is FireRing) && !(equipments.GetWeapon() is MagicRing))
            {
                weaponTextur.Texture = equipments.GetWeapon().Textur.Texture;
                weaponTextur.Position = Position;
                renderIn.Draw(weaponTextur);
            }
        }
        public void DeleteInteraction()
        {
            Interaction = null;
        }
        public void Move(float dTime, Vector2f dVector)
        { 
            Textur.Scale = new Vector2f(((dVector.X > 0) ? 1 : -1) * Math.Abs(Textur.Scale.X), Textur.Scale.Y);
            weaponTextur.Scale = new Vector2f(((dVector.X > 0) ? -1 : 1) * Math.Abs(weaponTextur.Scale.X), weaponTextur.Scale.Y);
            Direction = new Vector2f((dVector.X > 0) ? 1.0f : -1.0f, 0.0f);

            Position += dVector * speed * dTime;
            hitbox.Top = hitboxOffset.Y + Position.Y;
            hitbox.Left = hitboxOffset.X + Position.X;

            if (World.CheckIntersection(hitbox))
            {
                hitbox.Top = hitboxOffset.Y + Position.Y - 12.0f;
                if (!World.CheckIntersection(hitbox))
                {
                    onGround = false;
                    hitbox.Top = hitboxOffset.Y + Position.Y;
                }
                else
                {
                    Position -= dVector * speed * dTime;
                    hitbox.Top = hitboxOffset.Y + Position.Y;
                    hitbox.Left = hitboxOffset.X + Position.X;
                }
            }
            else
            {
                hitbox.Top = hitboxOffset.Y + Position.Y + 1.0f;
                if (!World.CheckIntersection(hitbox))
                {
                    onGround = false;
                }
                hitbox.Top = hitboxOffset.Y + Position.Y;
            }
        }
        public void Update(float dTime)
        {
            if(!isDead)
            {
                behaviour.Control(dTime, this);

                if (!onGround)
                {
                    Position += new Vector2f(0.0f, 200.0f * dTime);
                    if (World.CheckIntersection(hitbox))
                    {
                        onGround = true;
                        while (World.CheckIntersection(hitbox))
                        {
                            Position -= new Vector2f(0.0f, 0.1f);
                            hitbox.Top = hitboxOffset.Y + Position.Y;
                            hitbox.Left = hitboxOffset.X + Position.X;
                        }
                    }
                }

                hitbox.Top = hitboxOffset.Y + Position.Y;
                hitbox.Left = hitboxOffset.X + Position.X;
                Textur.Position = Position;

                timerEffects += dTime;
                if(timerEffects > 1)
                {
                    for (int i = 0; i < effects.Count; i++)
                    {
                        effects[i].Employ(this);
                        effects[i].TimeEffect -= timerEffects;

                        if (effects[i].TimeEffect <= 0)
                        {
                            effects[i].Delete(this);
                            effects.RemoveAt(i);
                            i -= 1;
                        }
                    }
                    timerEffects = 0;
                }

                timerEndurance += dTime;
                if(timerEndurance > 0.5)
                {
                    timerEndurance = 0;
                    AddEndurance(2);
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
            health -= (int)((1.0f - (float)GetResistance()/ 100.0f) * value);
            if (health <= 0)
            {
                isDead = true;
                health = 0;
                Textur.Rotation = 90.0f;
                Textur.Scale = new Vector2f(-Math.Abs(Textur.Scale.X), Textur.Scale.Y);
                Textur.Origin = new Vector2f(55, 20);
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
        public int GetResistance()
        {
            Clothes head = equipments.GetArmor(TypeArmor.Head);
            Clothes body = equipments.GetArmor(TypeArmor.Body);
            Clothes boots = equipments.GetArmor(TypeArmor.Foots);

            int sum = 0;
            if (head != null) { sum += (int)head.Effects[0].EffectValue; }
            if (body != null) { sum += (int)body.Effects[0].EffectValue; }
            if (boots != null) { sum += (int)boots.Effects[0].EffectValue; }
            
            if (sum > 50) sum = 50;

            return sum;
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
