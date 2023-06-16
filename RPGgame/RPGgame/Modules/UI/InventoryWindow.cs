
using RPGgame.Modules.Entitys;
using RPGgame.Modules.Items;
using RPGgame.Modules.Items.Props;
using SFML.Graphics;
using SFML.System;

namespace RPGgame.Modules.UI
{
    internal class InventoryWindow
    {
        public bool IsActive { get; set; }
        private Entity player;

        RectangleShape shapeBackground;
        int coundVert;
        int coundHor;
        int deltaX;
        int deltaY;
        int startPosX;
        int startPosY;
        RectangleShape shapeSpace;

        Item item;
        Sprite itemTextur;
        Vector2i posInGrid;

        public InventoryWindow(Entity player)
        {
            this.player = player;
            IsActive = false;

            shapeBackground = new RectangleShape();
            shapeBackground.Size = new Vector2f(550.0f, 500.0f);
            shapeBackground.Position = new Vector2f(10.0f, 20.0f);
            shapeBackground.FillColor = new Color(153, 76, 0);

            coundVert = player.GetInventory().Items.GetLength(0);
            coundHor = player.GetInventory().Items.GetLength(1);
            shapeSpace = new RectangleShape()
            {
                Size = new Vector2f(
                    (shapeBackground.Size.X - 55) / (coundHor + 1),
                    shapeBackground.Size.Y / (coundVert + 2)
                ),
                FillColor = Color.Transparent,
                OutlineThickness = 1,
                OutlineColor = new Color(102, 51, 0),
            };

            deltaX = ((int)shapeBackground.Size.X - 55) / coundHor;
            deltaY = (int)shapeBackground.Size.Y / coundVert;
            startPosX = 10;
            startPosY = 15;
        }

        public void Update(Events events)
        {
            Vector2i mPos = events.getMousePosition();
            int x = (mPos.X - startPosX) / deltaX;
            int y = (mPos.Y - startPosY) / deltaY;

            if (events.getButtonOfMouse(MouseEvent.ButtonLeft) && mPos.X >= startPosX && mPos.Y >= startPosY && 0 <= y && y <= 9)
            {
                if (item != null)
                {
                    itemTextur.Position = new Vector2f(mPos.X, mPos.Y);
                    return;
                }

                MousePressed(x, y);
            }
            else if (events.getButtonOfMouse(MouseEvent.ButtonRight))
            {

            }
            else
            {
                MouseReleased(mPos, new Vector2i(x, y));

                if (events.getButtonOfKeyboard(KeyboardEvent.ButtonEscape))
                {
                    IsActive = false;
                }
            }
        }
        private void MousePressed(int x, int y)
        {
            if (0 <= x && x <= 9)
            {
                DraggingAnItem(player, true, new Vector2i(x, y));
            }
            else if (11 <= x && x <= 20 && player.interaction != null)
            {
                DraggingAnItem(player.interaction, true, new Vector2i(x - 11, y));
            }
            else if (x == 10 && (y == 1 || 3 <= y && y <= 5))
            {
                DraggingAnItem(player, false, new Vector2i(x, y));
            }
            else if (x == 21 && player.interaction != null && player.interaction.IsAlive())
            {
                DraggingAnItem(player.interaction, false, new Vector2i(x - 11, y));
            }
            posInGrid = new Vector2i(x, y);
        }
        private void MouseReleased(Vector2i mousePos, Vector2i pos)
        {
            if (mousePos.X >= startPosX && mousePos.Y >= startPosY && 0 <= pos.Y && pos.Y <= 9)
            {
                if (0 <= pos.X && pos.X <= 9)
                {
                    PutItem(player, true, new Vector2i(pos.X, pos.Y));
                }
                else if (11 <= pos.X && pos.X <= 20 && player.interaction != null)
                {
                    PutItem(player.interaction, true, new Vector2i(pos.X - 11, pos.Y));
                }
                else if (pos.X == 10 && (pos.Y == 1 || 3 <= pos.Y && pos.Y <= 5))
                {
                    PutItem(player, false, new Vector2i(pos.X, pos.Y));
                }
                else if (pos.X == 21 && player.interaction != null)
                {
                    PutItem(player.interaction, false, new Vector2i(pos.X - 11, pos.Y));
                }
            }
            ReturnItem();
        }
        private void PutItem(IInteractive interactive, bool isInventory, Vector2i pos)
        {
            if(item == null)
            {
                return;
            }         

            if(isInventory)
            {
                if (interactive.GetInventory().PutItem(pos, item))
                {
                    item = null;
                }
            }
            else
            {
                if (pos.Y == 1)
                {
                    if(item is Weapon weapon)
                    {
                        interactive.GetInventory().PutItem(interactive.GetMainEquipments().SwapWeapon(weapon));
                        item = null;
                    }
                }
                else if(3 <= pos.Y && pos.Y <= 5)
                {
                    if (item is Clothes clothes)
                    {
                        interactive.GetInventory().PutItem(interactive.GetMainEquipments().SwapArmor(clothes));
                        item = null;
                    }
                }
                
            }
            ReturnItem();
        }
        private void ReturnItem()
        {
            if(item != null)
            {
                if (0 <= posInGrid.X && posInGrid.X <= 10)
                {
                    player.GetInventory().PutItem(item);
                }
                else if (player.interaction != null)
                {
                    player.interaction.GetInventory().PutItem(item);
                }
                item = null;
            }
        }
        private void DraggingAnItem(IInteractive interactive, bool isInventory, Vector2i pos)
        {
            if (isInventory)
            {
                item = interactive.GetInventory().GetItem(pos);
            }
            else
            {
                if (pos.Y == 1)
                {
                    item = interactive.GetMainEquipments().PopWeapon();
                }
                else
                {
                    item = interactive.GetMainEquipments().PopArmor((TypeArmor)(pos.Y - 3));
                }
            }

            if (item != null)
            {
                itemTextur = new Sprite(item.Textur.Texture)
                {
                    Origin = new Vector2f(item.Textur.Texture.Size.X / 2, item.Textur.Texture.Size.Y / 2),
                };
            }
        }

        public void Draw(RenderWindow renderIn)
        {
            Draw(0, player, renderIn);
            if (player.interaction != null)
            {
                Draw(1, player.interaction, renderIn);
            }

            if (item != null)
            {
                renderIn.Draw(itemTextur);
            }
        }
        private void Draw(int numb, IInteractive interactive, RenderWindow renderIn)
        {
            int delta = (numb == 0) ? 0 : 11;
            shapeBackground.Position = ((numb == 0) ?
                new Vector2f(5.0f, 10.0f) :
                new Vector2f(5.0f + shapeBackground.Size.X, 10.0f)
            );

            shapeBackground.Size = new Vector2f((numb == 0) ? 550.0f : (interactive.IsAlive())? 535.0f : 485.0f, 500.0f);
            renderIn.Draw(shapeBackground);

            Item item;
            for (int i = 0; i < coundVert; i++)
            {
                for (int j = 0; j < coundHor; j++)
                {
                    item = interactive.GetInventory().Items[i, j];
                    DrawElementOfInventory(item, delta + j, i, renderIn);
                }
            }

            if(interactive.IsAlive())
            {
                item = interactive.GetMainEquipments().GetWeapon();
                DrawElementOfInventory(item, delta + coundHor, 1, renderIn);

                for (int i = 0; i < 3; i++)
                {
                    item = interactive.GetMainEquipments().GetArmor((TypeArmor)i);
                    DrawElementOfInventory(item, delta + coundHor, i + 3, renderIn);
                }
            }
        }
        private void DrawElementOfInventory(Item item, int x, int y, RenderWindow renderIn)
        {
            shapeSpace.Position = new Vector2f(startPosX + x * deltaX, startPosY + y * deltaY);
            renderIn.Draw(shapeSpace);
            if (item != null)
            {
                DrawTexturOfItem(item, x, y, renderIn);
            }
        }
        private void DrawTexturOfItem(Item item, int x, int y, RenderWindow renderIn)
        {
            Sprite textur = new Sprite(item.Textur.Texture);
            textur.Scale = new Vector2f(
                shapeSpace.Size.X / textur.Texture.Size.X,
                shapeSpace.Size.Y / textur.Texture.Size.Y
            );
            textur.Position = new Vector2f(startPosX + x * deltaX, startPosY + y * deltaY);

            renderIn.Draw(textur);
        }
    }
}
