
using RPGgame.Modules;
using RPGgame.Modules.UI;
using SFML.Graphics;
using System;

namespace RPGgame
{
    enum Config
    {
        DrawInterWin,
        DrawInventWin,
        ClearDraw
    }

    internal class Scene
    {
        private RenderWindow renderIn;
        public Events events { get; private set; }
        private World world;
        private HUD hud;
        private InventoryWindow inventoryWindow;

        public Scene(RenderWindow renderIn, Events sceneEvents)
        {
            this.renderIn = renderIn;
            events = sceneEvents;
            world = new World(this);
            hud = new HUD(world.player);
            inventoryWindow = new InventoryWindow(world.player);
        }

        public void Update(float dTime)
        { 
            if (inventoryWindow.IsActive) inventoryWindow.Update(dTime, events);
            else if (!inventoryWindow.IsActive) world.Update(dTime);
        }
        public void Draw()
        {
            world.Draw(renderIn);
            if (hud.IsActive)
            {
                hud.Draw(renderIn);
            }
            if (inventoryWindow.IsActive)
            {
                inventoryWindow.Draw(renderIn);
            }
        }
        public void SetConfig(Config config)
        {
            switch (config)
            {
                //case Config.DrawInterWin:
                //    break;
                case Config.DrawInventWin:
                    inventoryWindow.IsActive = !inventoryWindow.IsActive;
                    break;
                //case Config.ClearDraw:
                //    break;
            }
        }
    }
}
