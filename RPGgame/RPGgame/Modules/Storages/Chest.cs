
using RPGgame.Modules.Entitys;
using SFML.Graphics;
using SFML.System;
using System;

namespace RPGgame.Modules.Storages
{
    internal class Chest : Storage, IInteractive
    {
        public int idKey { get; private set; }
        public Sprite textur { get; private set; }
        public Vector2f position { get; set; }

        public MainEquipments GetMainEquipments()
        {
            throw new Exception("GetMainEquipments, сундук не имеет снаряжения");
        }
        public Behaviour GetBehaviour()
        {
            throw new Exception("GetMainEquipments, сундук не имеет поведения");
        }
        public Storage GetInventory()
        {
            return this;
        }
        public bool IsAlive()
        {
            return false;
        }
        public int GetMoney()
        {
            throw new Exception("GetMoney, сундук не имеет денег");
        }
        public void SetMoney(int money)
        {
            throw new Exception("SetMoney, сундук не имеет денег");
        }

        public Chest(int idKey) : base(false)
        {
            this.idKey = idKey;
        }
        public void Draw(RenderWindow renderIn)
        {
            renderIn.Draw(textur);
        }
    }
}
