
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
        private Events sceneEvents;
        private World world;

        RectangleShape s = new RectangleShape
        {
            Size = new Vector2f(100, 100),
            FillColor = Color.White,
        };

        public Scene(RenderWindow renderIn, Events sceneEvents)
        {
            isActive = true;
            this.renderIn = renderIn;
            this.sceneEvents = sceneEvents;
            world = new World(this);
        }

        public void Update(float dTime)
        {
            if (sceneEvents.getButtonOfKeyboard(KeyboardEvent.ButtonA))
            {
                s.Position = (Vector2f)sceneEvents.getMousePosition();
            }
        }

        public void Draw()
        {
            renderIn.Draw(s);
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
