using System;

namespace Engine
{
    public static class Input
    {
        static ConsoleKey teclaActual;

        public static bool beingPressed(ConsoleKey tecla)
        {
            if (Console.KeyAvailable)
            {
                teclaActual = Console.ReadKey(true).Key;
                return teclaActual.Equals(tecla);

            }
            else return false;
        }

        public static bool getKey(out ConsoleKey tecla)
        {

            if (Console.KeyAvailable)
            {
                tecla = Console.ReadKey(true).Key;
                return true;
            }
            else
            {
                tecla = 0;
                return false;
            }
        }

    }
}
