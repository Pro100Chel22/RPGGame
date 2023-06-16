
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace RPGgame.Modules
{
    internal enum KeyboardEvent
    {
        ButtonA = 0,
        ButtonW = 1,
        ButtonS = 2,
        ButtonD = 3,
        ButtonSpace = 4,
        ButtonE = 5,
        ButtonI = 6,
        ButtonEscape = 7,
    }

    internal enum MouseEvent
    {
        ButtonLeft = 0,
        ButtonRight = 1,
        ButtonWheel = 2
    }

    internal class Events
    {
        private bool[] buttomOfMouse;
        private bool[] buttomOfKeyboard;
        private RenderWindow eventsIn;

        public Events(RenderWindow eventsIn)
        {
            buttomOfMouse = new bool[3];
            buttomOfKeyboard = new bool[8];
            this.eventsIn = eventsIn;

            this.eventsIn.KeyPressed += (object obj, KeyEventArgs e) => UpdateKeyboardEvent(obj, e, true);
            this.eventsIn.KeyReleased += (object obj, KeyEventArgs e) => UpdateKeyboardEvent(obj, e, false);
            this.eventsIn.MouseButtonPressed += (object obj, MouseButtonEventArgs e) => UpdateMouseEvent(obj, e, true);
            this.eventsIn.MouseButtonReleased += (object obj, MouseButtonEventArgs e) => UpdateMouseEvent(obj, e, false);
        }

        public Vector2i getMousePosition()
        {
            return new Vector2i(
                (int)(Mouse.GetPosition(eventsIn).X * 1152 / eventsIn.Size.X),
                (int)(Mouse.GetPosition(eventsIn).Y * 648 / eventsIn.Size.Y)
            );
        }
        public bool getButtonOfMouse(MouseEvent e)
        {
            return buttomOfMouse[(int)e];
        }
        public bool getButtonOfKeyboard(KeyboardEvent e)
        {
            return buttomOfKeyboard[(int)e];
        }
        private void setButtonOfMouse(MouseEvent e, bool pressed)
        {
            buttomOfMouse[(int)e] = pressed;
        }
        private void setButtonOfKeyboard(KeyboardEvent e, bool pressed)
        {
            buttomOfKeyboard[(int)e] = pressed;
        }
        private void UpdateKeyboardEvent(object obj, KeyEventArgs e, bool pressed)
        {
            switch (e.Code)
            {
                case Keyboard.Key.A:
                    setButtonOfKeyboard(KeyboardEvent.ButtonA, pressed);
                    break;
                case Keyboard.Key.W:
                    setButtonOfKeyboard(KeyboardEvent.ButtonW, pressed);
                    break;
                case Keyboard.Key.S:
                    setButtonOfKeyboard(KeyboardEvent.ButtonS, pressed);
                    break;
                case Keyboard.Key.D:
                    setButtonOfKeyboard(KeyboardEvent.ButtonD, pressed);
                    break;
                case Keyboard.Key.Space:
                    setButtonOfKeyboard(KeyboardEvent.ButtonSpace, pressed);
                    break;
                case Keyboard.Key.E:
                    setButtonOfKeyboard(KeyboardEvent.ButtonE, pressed);
                    break;
                case Keyboard.Key.I:
                    setButtonOfKeyboard(KeyboardEvent.ButtonI, pressed);
                    break;
                case Keyboard.Key.Escape:
                    setButtonOfKeyboard(KeyboardEvent.ButtonEscape, pressed);
                    break;
            }
        }
        private void UpdateMouseEvent(object obj, MouseButtonEventArgs e, bool pressed)
        {
            switch (e.Button)
            {
                case Mouse.Button.Left:
                    setButtonOfMouse(MouseEvent.ButtonLeft, pressed);
                    break;
                case Mouse.Button.Right:
                    setButtonOfMouse(MouseEvent.ButtonRight, pressed);
                    break;
                case Mouse.Button.Middle:
                    setButtonOfMouse(MouseEvent.ButtonWheel, pressed);
                    break;
            }
        }
    }
}
