using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleOfMati.CommandLine
{
    public static class StartScreen
    {
        public static void PrintStartScreen()
        {
            var asciiArt = new[]
            {
                @"                                   _____     _               __  ___  ___      _   _                                   ",
                @"                                  |_   _|   | |             / _| |  \/  |     | | (_)                                  ",
                @"                                    | | __ _| | ___    ___ | |_  | .  . | __ _| |_ _                                   ",
                @"                                    | |/ _` | |/ _ \  / _ \|  _| | |\/| |/ _` | __| |                                  ",
                @"                                    | | (_| | |  __/ | (_) | |   | |  | | (_| | |_| |                                  ",
                @"                                    \_/\__,_|_|\___|  \___/|_|   \_|  |_/\__,_|\__|_|                                  ",
                @"                                                                                                                       ",
                @"                                                        Zasady gry:                                                    ",
                @"                                      * Naciśnij TAB, żeby przeglądać dostępne akcje                                   ",
                @"                                      * Naciśnij ENTER, żeby zatwierdzić wybraną akcję                                 ",
                @"                                                                                                                       ",
                @"                                          Naciśnij ENTER, żeby rozpocząć rozgrywkę!                                    ",
            };

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WindowWidth = ConsoleConstants.ConsoleWidth;
            Console.WriteLine("\n\n");
            foreach (string line in asciiArt)
                Console.WriteLine(line);
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            while(true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                    break;
            }
        }
    }
}
