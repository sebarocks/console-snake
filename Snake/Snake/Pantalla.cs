using System;
using System.Threading;
using static System.ConsoleColor;

namespace Snake
{
    class Pantalla
    {
        public Pixel[,] pixeles;
        public int alto, ancho;

        public Pantalla()
        {
            alto = Console.WindowHeight-1;
            ancho = Console.WindowWidth;
            Console.BufferHeight = alto+1;

            pixeles = new Pixel[alto, ancho];
            
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    pixeles[i, j] = new Pixel(false);
                }
            }
        }

        // Actualiza la pantalla solo escribiendo pixeles 'activos'
        public void Update()
        {
            
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    if (pixeles[i, j].activo)
                    {
                        Console.BackgroundColor = pixeles[i, j].cFondo;
                        Console.ForegroundColor = pixeles[i, j].cLetra;
                        Console.SetCursorPosition(j, i);
                        Console.Write(pixeles[i, j].letra);
                        pixeles[i, j].activo = false;
                        
                    }
                }
            }
            Console.SetCursorPosition(0,0);
        }

        // Edita la informacion de un pixel
        public void editPixel(Point posicion, Pixel px)
        {
            int x = posicion.x;
            int y = posicion.y;
            pixeles[y, x].activo = px.activo;
            pixeles[y, x].cFondo = px.cFondo;
            pixeles[y, x].cLetra = px.cLetra;
            pixeles[y, x].letra = px.letra;
        }

        // Edita la informacion de un pixel
        public void editPixel(int x, int y, Pixel px)
        {
            pixeles[y, x].activo = px.activo;
            pixeles[y, x].cFondo = px.cFondo;
            pixeles[y, x].cLetra = px.cLetra;
            pixeles[y, x].letra = px.letra;
        }


        // Escribe un texto en la pantalla
        public void Texto(int x, int y, string texto)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                pixeles[y, x + i].editLetra(texto[i]);
            }
        }

        // Pinta toda la pantalla de un color
        public void Fill(ConsoleColor color)
        {
            Pixel nuevo = new Pixel(color);
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    editPixel(j, i, nuevo);
                }
            }
        }
                
        //  Copia un array 2d y lo dibuja en la pantalla en la posicion (posx,posy) usando el color ingresado.
        public void drawMap(int posx, int posy, int[,]bmap, ConsoleColor color)
        {
            Pixel px = new Pixel(color);
            for (int i = 0; i < bmap.GetLength(1); i++)
            {
                for (int j = 0; j < bmap.GetLength(0); j++)
                {
                    if (bmap[j, i] == 1)
                        editPixel(posx+i, posy+j, px);
                }
            }
        }

        public void drawMapAncho(int posx, int posy, int[,] bmap, ConsoleColor color)
        {
            Pixel px = new Pixel(color);
            for (int i = 0; i < bmap.GetLength(1); i++)
            {
                for (int j = 0; j < bmap.GetLength(0); j++)
                {
                    if (bmap[j, i] == 1)
                    {
                        editPixel(posx + 2 * i, posy + j, px);
                        editPixel(posx + 2 * i + 1, posy + j, px);
                    }
                }
            }
        }

        public void dibujarCuadrado(Point posicion, int sizex, int sizey, ConsoleColor color)
        {
            Pixel px = new Pixel(color);
            int pos_x = posicion.x;
            int pos_y = posicion.y;

            dibujarRaya(posicion,                                sizex,     'h', px); // techo
            dibujarRaya(new Point(pos_x, pos_y + sizey -1),      sizex,     'h', px); // piso
            dibujarRaya(new Point(pos_x, pos_y + 1),             sizey - 2, 'v', px); // pared izq
            dibujarRaya(new Point(pos_x + sizex - 1, pos_y + 1), sizey - 2, 'v', px); // pared der
        }

        public void dibujarRaya(Point origen, int longitud, char orientacion, Pixel px)
        {
            int orig_x = origen.x;
            int orig_y = origen.y;
            int l=0;

            if (orientacion=='h')
            {
                for (l = 0; l < longitud; l++)
                {                                       
                    editPixel( l+ orig_x, orig_y, px);
                }
            }
            else if(orientacion=='v')
            {
                for (l = 0; l < longitud; l++)
                {
                    editPixel(orig_x, l+ orig_y, px);
                }
            }
        }

        public void log(String str)
        {
            Console.ResetColor();
            Console.SetCursorPosition(0, alto);
            Console.Write(str);
        }

    }
}
