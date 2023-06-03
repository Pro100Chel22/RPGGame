
using SFML.System;

namespace RPGgame.Modules
{
    internal enum KeyboardEvent
    {
        ButtonA,
        ButtonW,
        ButtonS,
        ButtonD,
        ButtonSpace,
        ButtonE,
        ButtonI,
        ButtonEscape
    }

    internal enum MouseEvent
    {
        ButtonLeft,
        ButtonRight,
        ButtonWheel
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
            switch (e)
            {
                case MouseEvent.ButtonLeft: return buttomOfMouse[0];
                case MouseEvent.ButtonRight: return buttomOfMouse[1];
                case MouseEvent.ButtonWheel: return buttomOfMouse[2];

                default: return false;
            }
        }

        public bool getButtonOfKeyboard(KeyboardEvent e)
        {
            switch (e)
            {
                case KeyboardEvent.ButtonA: return buttomOfKeyboard[0];
                case KeyboardEvent.ButtonW: return buttomOfKeyboard[1];
                case KeyboardEvent.ButtonS: return buttomOfKeyboard[2];
                case KeyboardEvent.ButtonD: return buttomOfKeyboard[3];
                case KeyboardEvent.ButtonSpace: return buttomOfKeyboard[4];
                case KeyboardEvent.ButtonE: return buttomOfKeyboard[5];
                case KeyboardEvent.ButtonI: return buttomOfKeyboard[6];
                case KeyboardEvent.ButtonEscape: return buttomOfKeyboard[7];

                default: return false;
            }
        }

        public void setButtonOfMouse(MouseEvent e, bool pressed)
        {
            switch (e)
            {
                case MouseEvent.ButtonLeft: buttomOfMouse[0] = pressed; break;
                case MouseEvent.ButtonRight: buttomOfMouse[1] = pressed; break;
                case MouseEvent.ButtonWheel: buttomOfMouse[2] = pressed; break;
            }
        }

        public void setButtonOfKeyboard(KeyboardEvent e, bool pressed)
        {
            switch (e)
            {
                case KeyboardEvent.ButtonA: buttomOfKeyboard[0] = pressed; break;
                case KeyboardEvent.ButtonW: buttomOfKeyboard[1] = pressed; break;
                case KeyboardEvent.ButtonS: buttomOfKeyboard[2] = pressed; break;
                case KeyboardEvent.ButtonD: buttomOfKeyboard[3] = pressed; break;
                case KeyboardEvent.ButtonSpace: buttomOfKeyboard[4] = pressed; break;
                case KeyboardEvent.ButtonE: buttomOfKeyboard[5] = pressed; break;
                case KeyboardEvent.ButtonI: buttomOfKeyboard[6] = pressed; break;
                case KeyboardEvent.ButtonEscape: buttomOfKeyboard[7] = pressed; break;
            }
        }
    }
}
