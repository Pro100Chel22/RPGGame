
using RPGgame.Modules;
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

        RectangleShape s = new RectangleShape
        {
            Size = new Vector2f(100, 100),
            FillColor = Color.White,
        };

        public Scene(RenderWindow renderIn)
        {
            isActive = true;
            this.renderIn = renderIn;
        }

        public void Update(float dTime, Events e)
        {
            if (e.getButtonOfKeyboard(KeyboardEvent.ButtonA))
            {
                s.Position = (Vector2f)e.mousePosition;
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
