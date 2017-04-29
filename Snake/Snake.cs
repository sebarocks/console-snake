using System;
using System.Collections.Generic;
using static System.ConsoleColor;

namespace Snake
{
    class Snake
    {

        public Point posicion;
        public Point speed;
        public Point food;

        List<Point> cuerpo;        
        Random rnd;
        Pixel skin;
        int borde = 1;


        public Snake(Pantalla scr)
        {
            // posicion inicial
            posicion = new Point(3, 3);

            // velocidad inicial
            speed = new Point(1, 0);

            // inicia cuerpo
            cuerpo = new List<Point>();
            cuerpo.Add(posicion);

            // color inicial
            skin = new Pixel(White);

            // coloca comida inicial
            rnd = new Random();
            food = new Point(rnd.Next(1, scr.ancho - 1), rnd.Next(1, scr.alto - 1));

        }

        public void update(Pantalla scr)
        {
            int x = posicion.x;
            int y = posicion.y;

            //borra cuerpo
            for (int i = 0; i < cuerpo.Count; i++)
            {
                scr.editPixel(cuerpo[i], new Pixel());
            }

            //borra cabeza (debug)
            scr.editPixel(posicion, new Pixel());


            // mueve cabeza
            if (posicion.x + speed.x >= 0 + borde && posicion.x + speed.x < scr.ancho - borde)
                posicion.x = posicion.x + speed.x;
            if (posicion.y + speed.y >= 0 + borde && posicion.y + speed.y < scr.alto - borde)
                posicion.y = posicion.y + speed.y;

            // si come: 
            if (posicion.x == food.x && posicion.y == food.y)
            {
                // genera una nueva posicion de comida
                food.x = rnd.Next(1, scr.ancho - 1);
                food.y = rnd.Next(1, scr.alto - 1);

                // alarga y mueve cuerpo
                cuerpo.Add(new Point());
                for (int i = cuerpo.Count - 1; i > 0; i--)
                {
                    cuerpo[i] = cuerpo[i - 1];
                }
                cuerpo[0] = posicion;
                Console.Beep(1000, 50);

            }
            else  // sino: solo mueve cuerpo
            {
                for (int i = cuerpo.Count - 1; i > 0; i--)
                {
                    cuerpo[i] = cuerpo[i-1];
                }
                cuerpo[0] = posicion;
            }


            //dibuja cuerpo
            for (int i = 0; i < cuerpo.Count; i++)
            {
                scr.editPixel(cuerpo[i], new Pixel(Blue));
            }

            //dibuja cabeza (debug)
            scr.editPixel(posicion, new Pixel(Red));
            scr.log(x + "," + y+". l="+(cuerpo.Count-1)+"   ");
        }

        public void updateComida(Pantalla scr)
        {
            scr.editPixel(food, new Pixel(Magenta));
        }


        public void mover()
        {
            // Si hay una tecla presionada
            if (Console.KeyAvailable)
            {
                // Lee tecla
                switch (Console.ReadKey(true).Key) // ReadKey(true) no escribe en consola
                {
                    case ConsoleKey.UpArrow:
                        speed.x = 0;
                        speed.y = -1;
                        break;
                    case ConsoleKey.LeftArrow:
                        speed.x = -1;
                        speed.y = 0;
                        break;
                    case ConsoleKey.DownArrow:
                        speed.x = 0;
                        speed.y = 1;
                        break;
                    case ConsoleKey.RightArrow:
                        speed.x = 1;
                        speed.y = 0;
                        break;
                    default:
                        break;
                }
            }            
        }

        public void dibujarBorde(Pantalla scr)
        {
            scr.dibujarCuadrado(new Point(0, 0), scr.ancho, scr.alto, DarkGray);
        }
    }
}
