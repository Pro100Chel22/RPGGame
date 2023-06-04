
using RPGgame.Modules;
using RPGgame.Modules.UI;
using SFML.Graphics;
using SFML.System;
using System;

namespace RPGgame
{
    enum Config
    {
        DrawHUD,
        DrawInterWin,
        DrawInventWin,
        ClearDraw
    }

    internal class Scene
    {
        private bool isActive;
        private RenderWindow renderIn;
        public Events events { get; private set; }
        private World world;

        public Scene(RenderWindow renderIn, Events sceneEvents)
        {
            isActive = true;
            this.renderIn = renderIn;
            this.events = sceneEvents;
            world = new World(this);
        }

        public void Update(float dTime)
        {
            world.Update(dTime);
        }

        public void Draw()
        {
            world.Draw(renderIn);
        }

        public void Pause()
        {
            isActive = false;
        }

        public void Resume()
        {
            isActive = true;
        }

        public void SetConfig(Config config) 
        {
            throw new Exception("SetConfig недоступен, так как функция не реализована");

            switch (config)
            {
                case Config.DrawHUD:
                    break;
                case Config.DrawInterWin:
                    break;
                case Config.DrawInventWin:
                    break;
                case Config.ClearDraw:
                    break;
            }
        }
    }
}
