
using RPGgame.Modules;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace RPGgame
{
    internal class Engine
    {
        private RenderWindow win;
        private Scene scene;
        private Events engineEvents;

        public Engine()
        {
            win = new RenderWindow(new VideoMode(1152, 648), "SFML");
            engineEvents = new Events(win);
            scene = new Scene(win, engineEvents); 
            win.Closed += (object obj, EventArgs e) => win.Close();

            win.SetVerticalSyncEnabled(true);      
        }

        public void Start()
        {
            Clock clock = new Clock();

            while (win.IsOpen)
            {
                float dTime = clock.Restart().AsSeconds();

                win.DispatchEvents();

                scene.Update(dTime);

                win.Clear();

                scene.Draw();

                win.Display();
            }
        }
        public void Stop()
        {
            win.SetActive(false);
        }
    }
}
