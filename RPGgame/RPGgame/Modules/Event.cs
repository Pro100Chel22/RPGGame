
using SFML.System;
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
        public Vector2i mousePosition { get; set; }
        private bool[] buttomOfMouse;
        private bool[] buttomOfKeyboard;

        public Events()
        {
            mousePosition = new Vector2i();
            buttomOfMouse = new bool[3];
            buttomOfKeyboard = new bool[8];
        }

        public bool getButtonOfMouse(MouseEvent e)
        {
            return buttomOfMouse[(int)e];
        }

        public bool getButtonOfKeyboard(KeyboardEvent e)
        {
            return buttomOfKeyboard[(int)e];
        }

        public void setButtonOfMouse(MouseEvent e, bool pressed)
        {
            buttomOfMouse[(int)e] = pressed;
        }

        public void setButtonOfKeyboard(KeyboardEvent e, bool pressed)
        {
            buttomOfKeyboard[(int)e] = pressed;
        }
    }
}
