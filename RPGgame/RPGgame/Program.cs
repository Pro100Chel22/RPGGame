using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SFML;
using SFML.Graphics;
using SFML.Window;

namespace RPGgame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RenderWindow win = new RenderWindow(new VideoMode(600, 600), "SFML");

            while(win.IsOpen)
            {
                win.DispatchEvents();

                win.Clear();

                win.Display();
            }
        }
    }
}
