
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
            win = new RenderWindow(new VideoMode(600, 600), "SFML");
            scene = new Scene(win);
            engineEvents = new Events();

            win.SetVerticalSyncEnabled(true);
            win.Closed += (object obj, EventArgs e) => win.Close();
            win.KeyPressed += (object obj, KeyEventArgs e) => EngineKeyboardEvent(obj, e, true);
            win.KeyReleased += (object obj, KeyEventArgs e) => EngineKeyboardEvent(obj, e, false);
            win.MouseButtonPressed += (object obj, MouseButtonEventArgs e) => EngineMouseEvent(obj, e, true);
            win.MouseButtonReleased += (object obj, MouseButtonEventArgs e) => EngineMouseEvent(obj, e, false);
        }

        public void Start()
        {
            Clock clock = new Clock();

            while (win.IsOpen)
            {
                float dTime = clock.Restart().AsSeconds();

                win.DispatchEvents();
                engineEvents.mousePosition = Mouse.GetPosition(win);

                scene.Update(dTime, engineEvents);

                win.Clear();

                scene.Draw();

                win.Display();
            }
        }

        public void Stop()
        {
            win.SetActive(false);
        }

        private void EngineKeyboardEvent(object obj, KeyEventArgs e, bool pressed)
        {
            switch (e.Code)
            {
                case Keyboard.Key.A:
                    engineEvents.setButtonOfKeyboard(KeyboardEvent.ButtonA, pressed);
                    break;
                case Keyboard.Key.W:
                    engineEvents.setButtonOfKeyboard(KeyboardEvent.ButtonW, pressed);
                    break;
                case Keyboard.Key.S:
                    engineEvents.setButtonOfKeyboard(KeyboardEvent.ButtonS, pressed);
                    break;
                case Keyboard.Key.D:
                    engineEvents.setButtonOfKeyboard(KeyboardEvent.ButtonD, pressed);
                    break;
                case Keyboard.Key.Space:
                    engineEvents.setButtonOfKeyboard(KeyboardEvent.ButtonSpace, pressed);
                    break;
                case Keyboard.Key.E:
                    engineEvents.setButtonOfKeyboard(KeyboardEvent.ButtonE, pressed);
                    break;
                case Keyboard.Key.I:
                    engineEvents.setButtonOfKeyboard(KeyboardEvent.ButtonI, pressed);
                    break;
                case Keyboard.Key.Escape:
                    engineEvents.setButtonOfKeyboard(KeyboardEvent.ButtonEscape, pressed);
                    break;
            }
        }

        private void EngineMouseEvent(object obj, MouseButtonEventArgs e, bool pressed)
        {
            switch (e.Button)
            {
                case Mouse.Button.Left:
                    engineEvents.setButtonOfMouse(MouseEvent.ButtonLeft, pressed);
                    break;
                case Mouse.Button.Right:
                    engineEvents.setButtonOfMouse(MouseEvent.ButtonRight, pressed);
                    break;
                case Mouse.Button.Middle:
                    engineEvents.setButtonOfMouse(MouseEvent.ButtonWheel, pressed);
                    break;
            }
        }
    }
}
