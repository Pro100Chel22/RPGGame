
using RPGgame.Modules.Entitys;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace RPGgame.Modules.Items
{
    public enum TypeItemToCreate
    {
        Key,
        Note,
        EndurancePotion,
        TreatmentPotion,
        ResistancePotion,
        Helmet,
        Cuirass,
        Boots,
        Axe,
        Sword,
        Crossbow,
        Arrow,
        FireBall,
        MagicBall,

    }
    internal class Item
    {
        public Vector2f position { get; set; }
        public Sprite textur { get; private set; }


        public int costCoefficient { get; private set; }
        public int rarity { get; private set; }
        public string description { get; private set; }
        public string type { get; private set; }
        public int id { get; private set; }

        public Item CreateNew(TypeItemToCreate itemType)
        {

            switch (itemType)
            {
                case TypeItemToCreate.Key:
                    return new Item();


            }
            return new Item();
        }

        public static bool Compare(Item item1, Item item2)
        {
            throw new Exception("Сompare недоступен, так как функция не реализована");
        }


        public void Draw(RenderWindow renderIn)
        {
            renderIn.Draw(textur);

        }
        public virtual void UseInStorage(Entity entity)
        {
            throw new Exception("useInStorage недоступен, так как функция не реализована");

        }
    }
}
