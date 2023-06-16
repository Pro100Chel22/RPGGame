
using RPGgame.Modules.Items;
using SFML.System;

namespace RPGgame.Modules.Storages
{
    internal class Storage
    {
        public bool forSale { get; private set; }
        public Item[,] Items { get; private set; }

        public Storage(bool isForSale)
        { 
            forSale = isForSale;
            Items = new Item[10, 10];
        }

        public Vector2i FindItemById(int id)
        {
            for(int i  = 0; i < Items.GetLength(0); i++)
            {
                for (int j = 0; j < Items.GetLength(1); j++) { 
                    if (Items[i, j].Id == id)
                    {
                        return new Vector2i(j, i);
                    }     
                }
            }

            return new Vector2i(-1, -1);
        }

        public Item GetItem(Vector2i pos)
        {
            if (pos.X < 0 || pos.Y < 0 || Items.GetLength(1) < pos.X || Items.GetLength(0) < pos.Y)
            {
                return null;
            }

            Item item = Items[pos.Y, pos.X];
            Items[pos.Y, pos.X] = null;
            return item;
        }

        public bool PutItem(Vector2i pos, Item item)
        {
            if (pos.X < 0 || pos.Y < 0 || Items.GetLength(1) < pos.X || Items.GetLength(0) < pos.Y)
            {
                return false;
            }

            if(Items[pos.Y, pos.X] == null)
            {
                Items[pos.Y, pos.X] = item;
                return true;
            }

            return false;
        }

        public bool PutItem(Item item)
        {
            for (int i = 0; i < Items.GetLength(0); i++)
            {
                for (int j = 0; j < Items.GetLength(1); j++)
                {
                    if (Items[i, j] == null)
                    {
                        Items[i, j] = item;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
