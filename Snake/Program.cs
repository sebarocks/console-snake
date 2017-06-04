using Engine;
using System.Threading;

namespace Snake
{
    class Program
    {
        static Pantalla scr;
        static Snake s;

        static void Setup()
        {
            s = new Snake();
            scr = new Pantalla(s.gameArea.width + 2, s.gameArea.height + 2);
            
            //borde            
            s.dibujarBorde(scr);
            s.updateComida(scr);
        }

        static void Gameloop()
        {
            while (true)
            {
                s.updateComida(scr);
                s.accion();
                s.update(scr);
                scr.Update();
                Thread.Sleep(s.tick);
            }
        }

        static void Main(string[] args)
        {
            Setup();
            Gameloop();
        }

    }
}
