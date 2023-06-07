
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

        private int id;
        private int costCoefficient;
        private int rarity;
        private string description;
        private string type;


        public Item createNew(TypeItemToCreate itemType)
        {

            switch (itemType)
            {
                case TypeItemToCreate.Key:
                    return new Item();


            }
            return new Item();
        }

        public void compare(Item item)
        {
            throw new Exception("Сompare недоступен, так как функция не реализована");
        }

        public int getId(){ 

            return this.id;
        }

        public string getDescribtion()
        {
            return this.description;
        }

        public string getType()
        {
            return this.type;
        }


        public void draw(RenderWindow renderIn)
        {
            renderIn.Draw(textur);

        } 
        public void useInStorage(Entity entity)
        {
            throw new Exception("useInStorage недоступен, так как функция не реализована");

        }

        //public void setPosition(Vector2f position) => this.position = position;
    }
}
