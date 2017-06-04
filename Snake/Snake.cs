using Engine;
using System;
using System.Collections.Generic;
using Color = System.ConsoleColor;
using Key = System.ConsoleKey;


namespace Snake
{
    class Snake
    {
        public Point posicion;
        public Point speed;
        public Point food;
        public Point nextPos;
        public int tick = 250; // reloj del juego
        public Rect gameArea;

        List<Point> cuerpo;        
        Random rnd;
        Pixel skin;


        public Snake()
        {
            // define area de juego
            gameArea = new Rect(0, 0, 20, 40);

            // posicion inicial
            posicion = new Point(3, 3);

            // velocidad inicial
            speed = new Point(1, 0);

            // inicia cuerpo
            cuerpo = new List<Point>();
            cuerpo.Add(posicion);

            // color inicial
            skin = new Pixel(Color.White);

            // coloca comida inicial
            rnd = new Random();
            food = new Point(rnd.Next(gameArea.xMin+1, gameArea.xMax),
                                rnd.Next(gameArea.yMin+1, gameArea.yMax));


        }

        public void update(Pantalla scr)
        {
            //borra cuerpo
            for (int i = 0; i < cuerpo.Count; i++)
            {
                scr.editPixel(cuerpo[i], new Pixel());
            }

            // mueve cabeza
            nextPos = posicion + speed;

            //si la siguiente posicion no se sale del 'area de juego'
            if (gameArea.hasInside(nextPos))
            {
                //se avanza a la siguiente posicion
                posicion = nextPos;
            }

            // si come: 
            if (posicion == food)
            {
                // genera una nueva posicion de comida
                food = new Point(rnd.Next(gameArea.xMin + 1, gameArea.xMax),
                                    rnd.Next(gameArea.yMin + 1, gameArea.yMax));

                // alarga y mueve cuerpo
                cuerpo.Add(nextPos);
                for (int i = cuerpo.Count - 1; i > 0; i--)
                {
                    cuerpo[i] = cuerpo[i - 1];
                }
                cuerpo[0] = posicion;

                // acelera el juego, disminuye el periodo (tick) -5%
                tick = (tick * 39) / 40;

            }
            else  // sino: solo mueve cuerpo
            {
                for (int i = cuerpo.Count - 1; i > 0; i--)
                {
                    cuerpo[i] = cuerpo[i - 1];
                }
                cuerpo[0] = posicion;
            }


            //dibuja cuerpo
            for (int i = 0; i < cuerpo.Count; i++)
            {
                scr.editPixel(cuerpo[i], new Pixel(Color.Blue));
            }

            //dibuja cabeza (debug)
            scr.editPixel(posicion, new Pixel(Color.Red));
            scr.log(posicion.x + "," + posicion.y + ". l=" + (cuerpo.Count) + ". t="+tick+"     ");

        }


        public void updateComida(Pantalla scr)
        {
            scr.editPixel(food, new Pixel(Color.Magenta));
        }

        // usar input
        public void accion()
        {
            Key tecla;

            // Si hay una tecla presionada
            if (Input.getKey(out tecla))
            {
                // Lee tecla
                switch (tecla)
                {
                    case Key.UpArrow:
                        mover(Direccion.Arriba);
                        return;
                    case Key.LeftArrow:
                        mover(Direccion.Izquierda);
                        return;
                    case Key.DownArrow:
                        mover(Direccion.Abajo);
                        return;
                    case Key.RightArrow:
                        mover(Direccion.Derecha);
                        return;
                    case Key.D0:
                        mover(Direccion.Ninguno);
                        return;
                    default:
                        return;
                }
            }            
        }

        public void dibujarBorde(Pantalla scr)
        {
            scr.dibujarRect(gameArea, Color.DarkGray);
        }

        void mover(Direccion dir)
        {
            switch (dir)
            {
                case Direccion.Arriba:
                    speed = new Point(0, -1);
                    break;
                case Direccion.Izquierda:
                    speed = new Point(-1, 0);
                    break;
                case Direccion.Abajo:
                    speed = new Point(0, 1);
                    break;
                case Direccion.Derecha:
                    speed = new Point(1, 0);
                    break;
                default:
                    speed = new Point(0, 0);
                    break;
            }
        }
    }
}
