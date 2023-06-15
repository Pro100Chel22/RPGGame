
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
        float deltaX;
        float deltaY;
        RectangleShape shapeSpace;

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

            deltaX = (shapeBackground.Size.X - 55) / coundHor;
            deltaY = shapeBackground.Size.Y / coundVert;
        }

        public void Update(float dTime, Events events)
        {
            if(events.getButtonOfMouse(MouseEvent.ButtonLeft))
            {

            }
            else if(events.getButtonOfMouse(MouseEvent.ButtonRight))
            {

            }
            else if (events.getButtonOfKeyboard(KeyboardEvent.ButtonEscape))
            {
                IsActive = false;
            }
        }

        public void Draw(RenderWindow renderIn)
        {
            Draw(0, player, renderIn);
            if (player.interaction != null)
            {
                Draw(1, player.interaction, renderIn);
            }
        }
        private void Draw(int numb, IInteractive interactive, RenderWindow renderIn)
        {
            int delta = (numb == 0) ? 0 : 11;
            shapeBackground.Position = ((numb == 0) ?
                new Vector2f(5.0f, 10.0f) :
                new Vector2f(5.0f + shapeBackground.Size.X, 10.0f)
            );
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

            item = interactive.GetMainEquipments().GetWeapon();
            DrawElementOfInventory(item, delta + coundHor, 1, renderIn);

            for (int i = 0; i < 3; i++)
            {
                item = interactive.GetMainEquipments().GetArmor((TypeArmor)i);
                DrawElementOfInventory(item, delta + coundHor, i + 3, renderIn);
            }
        }
        private void DrawElementOfInventory(Item item, int x, int y, RenderWindow renderIn)
        {
            shapeSpace.Position = new Vector2f(10 + x * deltaX, 15 + y * deltaY);
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
            textur.Position = new Vector2f(10 + x * deltaX, 15 + y * deltaY);

            renderIn.Draw(textur);
        }
    }
}
