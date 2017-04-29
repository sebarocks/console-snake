using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Pixel
    {
        public ConsoleColor cFondo;
        public ConsoleColor cLetra;
        public Char letra;
        public bool activo;

        public Pixel()
        {
            cFondo = ConsoleColor.Black;
            cLetra = ConsoleColor.Green;
            letra = ' ';
            activo = true;
        }

        public Pixel(ConsoleColor color)
        {
            cFondo = color;
            cLetra = ConsoleColor.Green;
            letra = ' ';
            activo = true;
        }

        public Pixel(bool activo)
        {
            cFondo = ConsoleColor.Black;
            cLetra = ConsoleColor.Green;
            letra = ' ';
            this.activo = activo;
        }

        public void editLetra(char letra)
        {
            activo = true;
            this.letra = letra;
        }

    }
}
