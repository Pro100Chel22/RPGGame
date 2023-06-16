
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Props;
using SFML.Graphics;
using SFML.System;
using System;

namespace RPGgame.Modules.Items
{
    internal enum TypeItemToCreate
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
        public float scale = 1.0f;

        public int CostCoefficient { get; private set; }
        public int Rarity { get; private set; }
        public string Description { get; private set; }
        public string Type { get; private set; }
        public int Id { get; private set; }

        public Item(string pathToTextur)
        {
            Texture tx = new Texture(pathToTextur);
         
            Textur = new Sprite(tx)
            {
                Scale = new Vector2f(scale, scale),
                Origin = new Vector2f(tx.Size.X, tx.Size.Y),
            };
        }

        public Item CreateNew(TypeItemToCreate itemType) => itemType switch
        {
            TypeItemToCreate.Arrow => new Arrow(),
            TypeItemToCreate.Key => throw new NotImplementedException(),
            TypeItemToCreate.Note => throw new NotImplementedException(),
            TypeItemToCreate.EndurancePotion => throw new NotImplementedException(),
            TypeItemToCreate.TreatmentPotion => throw new NotImplementedException(),
            TypeItemToCreate.ResistancePotion => throw new NotImplementedException(),
            TypeItemToCreate.Helmet => throw new NotImplementedException(),
            TypeItemToCreate.Cuirass => throw new NotImplementedException(),
            TypeItemToCreate.Boots => throw new NotImplementedException(),
            TypeItemToCreate.Axe => throw new NotImplementedException(),
            TypeItemToCreate.Sword => throw new NotImplementedException(),
            TypeItemToCreate.Crossbow => throw new NotImplementedException(),
            TypeItemToCreate.FireBall => throw new NotImplementedException(),
            TypeItemToCreate.MagicBall => throw new NotImplementedException()
        };
        public static bool Compare(Item item1, Item item2)
        {
            return item1.GetType() == item2.GetType();
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
