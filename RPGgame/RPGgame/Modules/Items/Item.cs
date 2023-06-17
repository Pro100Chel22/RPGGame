
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items.Props;
using RPGgame.Modules.Items.Props.Weapons;
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
        Helmet,
        Cuirass,
        Boots,
        Axe,
        Sword,
        Crossbow,
        FireRing,
        MagicRing,
        Arrow,
        FireBall,
        MagicBall,
    }

    internal class Item
    {
        public Vector2f Position { get; set; }
        public Sprite Textur { get; set; }
        private float scale = 1.0f;

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

        public static Item CreateNew(TypeItemToCreate itemType) => itemType switch
        {
            TypeItemToCreate.Arrow => new Arrow(),
            TypeItemToCreate.Key => new Key(),
            TypeItemToCreate.Note => new Note(),
            TypeItemToCreate.EndurancePotion => new EndurancePotion(),
            TypeItemToCreate.TreatmentPotion => new TreatmentPotion(),
            TypeItemToCreate.Helmet => new Helmet(),
            TypeItemToCreate.Cuirass => new Cuirass(),
            TypeItemToCreate.Boots => new Boots(),
            TypeItemToCreate.Axe => new Axe(),
            TypeItemToCreate.Sword => new Sword(),
            TypeItemToCreate.Crossbow => new Crossbow(),
            TypeItemToCreate.FireRing => new FireRing(),
            TypeItemToCreate.MagicRing => new MagicRing(),
            TypeItemToCreate.FireBall => new FireBall(),
            TypeItemToCreate.MagicBall => new MagicBall(),
            _ => throw new NotImplementedException()
        };
        public static bool Compare(Item item1, Item item2)
        {
            return item1.GetType() == item2.GetType();
        }
        public void Draw(RenderWindow renderIn)
        {
            renderIn.Draw(Textur);

        }
        public virtual bool UseInStorage(Entity entity)
        {
            return false;
        }
    }
}
