using System;
using Color = System.ConsoleColor;

namespace Engine
{
    public class Pixel
    {
        public Color cFondo;
        public Color cLetra;
        public Char letra;
        public bool activo;

        public Pixel()
        {
            cFondo = Color.Black;
            cLetra = Color.Green;
            letra = ' ';
            activo = true;
        }

        public Pixel(Color color)
        {
            cFondo = color;
            cLetra = Color.Green;
            letra = ' ';
            activo = true;
        }

        public Pixel(Color colorFondo, Color colorLetra)
        {
            cFondo = colorFondo;
            cLetra = colorLetra;
            letra = ' ';
            activo = true;
        }

        public Pixel(bool activo)
        {
            cFondo = Color.Black;
            cLetra = Color.Green;
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

