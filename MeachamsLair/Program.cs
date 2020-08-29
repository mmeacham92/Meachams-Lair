using System;

namespace MeachamsLair
{
    class Program
    {
        // Initialize Player object
        public static Player currentPlayer = new Player();

        static void Main(string[] args)
        {
            // Start game
            Game.Start(currentPlayer);
        }
    }
}
