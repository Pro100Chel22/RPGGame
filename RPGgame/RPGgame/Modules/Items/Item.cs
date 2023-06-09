
using RPGgame.Modules.Entitys;
using RPGgame.Modules.UI;
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
        public Vector2f Position { get; set; }
        public Sprite Textur { get; private set; }

        public int CostCoefficient { get; private set; }
        public int Rarity { get; private set; }
        public string Description { get; private set; }
        public string Type { get; private set; }
        public int Id { get; private set; }

        public Item CreateNew(TypeItemToCreate itemType)
        {

            switch (itemType)
            {
                case TypeItemToCreate.Key:
                    return new Item();
                case TypeItemToCreate.Note:
                    return new Item();
                case TypeItemToCreate.EndurancePotion:
                    return new Item();
                case TypeItemToCreate.TreatmentPotion:
                    return new Item();
                case TypeItemToCreate.ResistancePotion:
                    return new Item();
                case TypeItemToCreate.Helmet:
                    return new Item();
                case TypeItemToCreate.Cuirass:
                    return new Item();
                case TypeItemToCreate.Boots:
                    return new Item();
                case TypeItemToCreate.Axe:
                    return new Item();
                case TypeItemToCreate.Crossbow:
                    return new Item();
                case TypeItemToCreate.Arrow:
                    return new Item();
                case TypeItemToCreate.FireBall:
                    return new Item();
                case TypeItemToCreate.MagicBall:
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
            renderIn.Draw(Textur);

        }
        public virtual void UseInStorage(Entity entity)
        {
            throw new Exception("UseInStorage недоступен, так как функция не реализована");

        }
    }



}
