using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.ConsoleColor;

namespace Snake
{
    class Program
    {
        static Pantalla scr;
        static Snake s;
        static int speed;

        static void Setup()
        {
            scr = new Pantalla();
            s = new Snake(scr);
            speed = 50;

            //borde            
            s.dibujarBorde(scr);
            s.updateComida(scr);
        }

        static void Gameloop()
        {
            while (true)
            {
                s.updateComida(scr);
                s.mover();
                s.update(scr);
                scr.Update();
                Thread.Sleep(speed);
            }
        }

        static void Main(string[] args)
        {
            Setup();
            Gameloop();
        }

    }
}
